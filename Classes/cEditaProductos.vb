Imports System.Data.SqlClient
Imports System.Net
Imports System.Text
Imports System.IO
Imports Newtonsoft.Json
Imports System


Public Class cEditaProductos
    Inherits cEncripta

    Private _host As String
    Private _user As String
    Private _pass As String

    Public Sub New(host As String, user As String, pass As String)
        Me._host = DecodeBase64ToString(host)
        Me._user = DecodeBase64ToString(user)
        Me._pass = DecodeBase64ToString(pass)
    End Sub

    Public Function sqlEmpaque(sku As String) As List(Of String)
        Dim listResult As List(Of String) = New List(Of String)
        'Variables de conexion para sql
        Dim myConn As SqlConnection
        Dim myCmd As SqlCommand
        Dim myReader As SqlDataReader
        Try

            'creamos la coneccion con la BD principal
            myConn = New SqlConnection("Initial Catalog=TCADBMAS; Data Source=" & Me._host & "; User ID=" & Me._user & "; Password=" & Me._pass & ";")

            'Creamos el comando como consulta
            myCmd = myConn.CreateCommand

            If (sku <> "") Then
                myCmd.CommandText = "Select * from (select uds_min as uds from inviar where art like '" + sku + "' union select uds from codbar where art like '" + sku + "') as Codigo order by uds"
            Else
                myCmd.CommandText = "select distinct unidad_producto from BoCFDUniMed where empresa='MAS' order by unidad_producto"
            End If

            'abrimos la coneccion
            myConn.Open()
            myReader = myCmd.ExecuteReader() 'Ejecuta la consulta

            'Repetimos mientras exista informacion
            Do While myReader.Read()
                'Mostramos la informacion en la tabla
                listResult.Add(myReader.GetString(0).ToString.Trim)
            Loop
            'cerramos la conexion
            myConn.Close()
        Catch ex As Exception
            Dim e = ex.Message
        End Try
        Return listResult
    End Function

    Public Function updateClienteShopify(arrayDatos As Dictionary(Of String, String)) As String

        Dim idShopify = arrayDatos("idShopify")
        Dim URL = "https://" + tienda + ".myshopify.com/admin/api/2022-01/customers/" + idShopify + ".json"
        Dim result = ""
        'declaramos las variables necesarias para array
        Dim arrayData = New Dictionary(Of String, Object)
        Dim arrayCostumer = New Dictionary(Of String, Object)
        Dim arrayTags() As String = Trim(arrayDatos("txtTags")).Split(",")
        'convertimos la fila a array
        arrayCostumer.Add("id", idShopify)
        arrayCostumer.Add("id_mertsyst", arrayDatos("txtIdMerksyst"))
        arrayCostumer.Add("first_name", arrayDatos("txtNombre"))
        arrayCostumer.Add("last_name", arrayDatos("txtApellido"))
        arrayCostumer.Add("email", arrayDatos("txtCorreo"))
        arrayCostumer.Add("phone", arrayDatos("txtTelefono"))
        arrayCostumer.Add("verified_email", "True")
        arrayCostumer.Add("state", "enable")
        arrayCostumer.Add("tags", arrayTags)
        arrayCostumer.Add("note", "Actualizado el dia " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"))
        arrayData.Add("customer", arrayCostumer)
        'Variables de conexion propias de VB.net
        Dim myReq As WebRequest
        Dim myResp As HttpWebResponse

        'Variables que llevan las credenciales de Shopify
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Dim appKey As String = VariablesGlobales.APIKey & ":" & VariablesGlobales.Password
        Dim str As String = JsonConvert.SerializeObject(arrayData)
        Dim data As Byte() = Encoding.UTF8.GetBytes(str)
        Dim byteKey As Byte() = Encoding.UTF8.GetBytes(appKey)
        Dim SimpleCredential As NetworkCredential = New NetworkCredential(VariablesGlobales.APIKey, VariablesGlobales.Password)
        appKey = Convert.ToBase64String(byteKey)
        Try
            'Asignamos a la variable la la ruta, las credenciales y el tipo
            myReq = WebRequest.Create(URL)
            myReq.Credentials = SimpleCredential
            myReq.Headers.Add("Authorization", "Basic " & appKey)
            myReq.ContentType = "application/json"

            'Indicamos que el metodo es PUT
            myReq.Method = "PUT"

            'Encriptamos los datos que estamos enviando
            myReq.ContentLength = data.Length
            Dim stream As Stream = myReq.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()

            'Recibimos la respuesta de la pagina de shopify
            myResp = myReq.GetResponse()
            Dim myreader As New StreamReader(myResp.GetResponseStream())

            ' si tiene informacion entra
            If myResp.StatusCode <= 200 Or myResp.StatusCode >= 210 Then
                result = "Ocurrio un error al guardar en shopify"
            End If

        Catch ex As WebException
            Dim tmpErrorWeb As StreamReader = New StreamReader(ex.Response.GetResponseStream)
            result = tmpErrorWeb.ReadToEnd
        End Try
        Return result
    End Function

    Public Function GuardarArticulo(arrayDatos As Dictionary(Of String, String)) As String
        Dim lblError As String = ""
        Dim UrlUpdate As String = "https://" + tienda + ".myshopify.com/admin/api/2022-01/products/"
        Try

            'declaramos las variables necesarias para array
            Dim arrayData = New Dictionary(Of String, Object)
            Dim arrayProduct = New Dictionary(Of String, Object)
            Dim arrayVariant = New List(Of Object)
            Dim arrayVariantes = New Dictionary(Of String, Object)
            Dim arrayOption = New List(Of Object)
            Dim arrayOptiones1 = New Dictionary(Of String, Object)
            Dim arrayOptiones1Val(1) As String
            Dim arrayOptiones2 = New Dictionary(Of String, Object)
            Dim arrayOptiones2Val(1) As String
            Dim arrayTags() As String = Trim(arrayDatos("txtTags")).Split(",")

            'Revisamos el estatus, y lo cambiamos al estatus de la pagina
            Dim Estatus = ""
            If (arrayDatos("slcEstatus") = "Activo") Then
                Estatus = "active"
            ElseIf (arrayDatos("slcEstatus") = "Borrador") Then
                Estatus = "draft"
            End If

            'convertimos los nuevos valores al array
            arrayProduct.Add("title", arrayDatos("txtEncabezado").Trim)
            arrayProduct.Add("body_html", arrayDatos("txtDescripcion").Trim)
            arrayProduct.Add("vendor", arrayDatos("txtProveedor").Trim)
            arrayProduct.Add("status", Estatus)
            arrayVariantes.Add("price", arrayDatos("txtPrecio").Trim)
            arrayVariantes.Add("title", arrayDatos("slcEmpaque"))
            arrayVariantes.Add("option1", arrayDatos("slcEmpaque"))
            arrayVariantes.Add("inventory_policy", "deny")
            arrayVariantes.Add("compare_at_price", "")
            arrayVariantes.Add("fulfillment_service", "manual")
            arrayVariantes.Add("inventory_management", "")
            arrayVariantes.Add("taxable", "false")
            arrayVariantes.Add("sku", arrayDatos("txtSku"))
            arrayVariant.Add(arrayVariantes)
            arrayProduct.Add("variants", arrayVariant)

            'Agregamos el empaque al articulo
            arrayOptiones1.Add("name", "Empaque")
            arrayOptiones1.Add("position", "1")
            arrayOptiones1Val(0) = arrayDatos("slcEmpaque")
            arrayOptiones1.Add("values", arrayOptiones1Val)
            arrayOption.Add(arrayOptiones1)

            arrayProduct.Add("tags", arrayTags)
            arrayProduct.Add("options", arrayOption)
            arrayData.Add("product", arrayProduct)
            'Variables de conexion propias de VB.net
            Dim myReq As WebRequest
            Dim myResp As HttpWebResponse

            'Variables que llevan las credenciales de Shopify
            Dim appKey As String = VariablesGlobales.APIKey & ":" & VariablesGlobales.Password
            Dim str As String = JsonConvert.SerializeObject(arrayData)
            Dim data As Byte() = Encoding.UTF8.GetBytes(str)
            Dim byteKey As Byte() = Encoding.UTF8.GetBytes(appKey)
            Dim SimpleCredential As NetworkCredential = New NetworkCredential(VariablesGlobales.APIKey, VariablesGlobales.Password)
            appKey = Convert.ToBase64String(byteKey)

            'Asignamos a la variable la la ruta, las credenciales y el tipo
            myReq = WebRequest.Create(UrlUpdate + arrayDatos("IdShopify") + ".json")
            myReq.Credentials = SimpleCredential
            myReq.Headers.Add("Authorization", "Basic " & appKey)
            myReq.ContentType = "application/json"

            'Indicamos que el metodo es PUT
            myReq.Method = "PUT"
            myReq.ContentLength = data.Length

            'Encriptamos los datos que estamos enviando
            Dim stream As Stream = myReq.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()

            'Recibimos la respuesta de la pagina de shopify
            myResp = myReq.GetResponse()
            Dim myreader As New StreamReader(myResp.GetResponseStream())

            ' si tiene informacion entra
            If myResp.StatusCode < 200 Or myResp.StatusCode > 210 Then
                lblError = "Ocurrio un error al actualizar los datos"
            End If
            myResp.Close()
        Catch ex As WebException
            Dim data As StreamReader = New StreamReader(ex.Response.GetResponseStream)
            lblError = "Error " & data.ReadToEnd
        End Try
        Return lblError

    End Function



End Class
