Imports System.Data.SqlClient
Imports System.Net
Imports System.Text
Imports System.IO
Imports Newtonsoft.Json

Public Class cEditaCliente
    Inherits cEncripta

    Private _host As String
    Private _user As String
    Private _pass As String

    Public Sub New(host As String, user As String, pass As String)
        Me._host = DecodeBase64ToString(host)
        Me._user = DecodeBase64ToString(user)
        Me._pass = DecodeBase64ToString(pass)
    End Sub

    Public Function sqlClienteAlternativo(idShopify As String) As DataTable
        Dim tableResult As DataTable = New DataTable
        tableResult.Columns.Clear()
        tableResult.Columns.Add("Id Shopify")
        tableResult.Columns.Add("Suc")
        'Variables de conexion para sql
        Dim myConn As SqlConnection
        Dim myCmd As SqlCommand
        Dim myReader As SqlDataReader
        Try
            'creamos la coneccion con la BD principal
            myConn = New SqlConnection("Initial Catalog=TCADBMAS; Data Source=" & Me._host & "; User ID=" & Me._user & "; Password=" & Me._pass & ";")

            'Creamos el comando como consulta
            myCmd = myConn.CreateCommand
            myCmd.CommandText = "select distinct id_Merksyst, sucursal from shopify_cliente_sucursal where id_Shopify =  " & idShopify

            'abrimos la coneccion
            myConn.Open()
            myReader = myCmd.ExecuteReader() 'Ejecuta la consulta

            'Repetimos mientras exista informacion
            Do While myReader.Read()
                'Mostramos la informacion en la tabla
                tableResult.Rows.Add(myReader.GetString(0).ToString.Trim, myReader.GetString(1).ToString.Trim)
            Loop
            'cerramos la conexion
            myConn.Close()
        Catch ex As Exception
            Dim e = ex.Message
        End Try
        Return tableResult
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

    Public Function updateClienteMerksyst(arrayDatos As Dictionary(Of String, String)) As String
        Dim result = ""
        'Variables de conexion para sql
        Dim myConn As SqlConnection
        Dim myCmd As SqlCommand
        Try
            'creamos la coneccion con la BD principal
            myConn = New SqlConnection("Initial Catalog=TCADBMAS; Data Source=" & Me._host & "; User ID=" & Me._user & "; Password=" & Me._pass & ";")

            'Creamos el comando como procedimiento almacenado
            myCmd = myConn.CreateCommand
            myCmd.CommandType = CommandType.StoredProcedure

            'Enviamos los parametros
            myCmd.Parameters.Add(New SqlParameter("@id_Shopify", arrayDatos("idShopify")))
            myCmd.Parameters.Add(New SqlParameter("@id_Merksyst", arrayDatos("txtIdMerksyst")))
            'declaramos una variable de tipo OUTPUT del procedimiento almacenado
            myCmd.Parameters.Add("@respuesta", SqlDbType.VarChar, 255)
            myCmd.Parameters("@respuesta").Direction = ParameterDirection.Output
            myCmd.CommandText = "sp_insertClienteShoppify"

            'abrimos la coneccion
            myConn.Open()
            myCmd.ExecuteNonQuery() ' Ejecuta el procedimiento almacenado 
            'almacenamos la respuesta que envia el procedimiento
            Dim resultado As String = myCmd.Parameters("@respuesta").Value
            'Limpiamos caracteres en blanco y determinamos si existe un error (si trae algun mensaje)
            If (resultado.Replace(" "c, String.Empty) <> "") Then
                result = myCmd.Parameters("@respuesta").Value
            End If
            'cerramos la conexion
            myConn.Close()
        Catch ex As Exception
            result = "Error al guardar en la DB de Merksyst"
        End Try
        Return result
    End Function

    Public Function actualizaSucursales(idShopify As String, mov As String, idMersyst As String, Sucursal As String)
        Dim respuesta = ""
        'Variables de conexion para sql
        Dim myConn As SqlConnection
        Dim myCmd As SqlCommand
        Try
            'creamos la coneccion con la BD principal
            myConn = New SqlConnection("Initial Catalog=TCADBMAS; Data Source=" & Me._host & "; User ID=" & Me._user & "; Password=" & Me._pass & ";")

            'Creamos el comando como procedimiento almacenado
            myCmd = myConn.CreateCommand
            myCmd.CommandType = CommandType.StoredProcedure

            'Enviamos los parametros
            myCmd.Parameters.Add(New SqlParameter("@movimiento", mov))
            myCmd.Parameters.Add(New SqlParameter("@id_Shopify", idShopify))
            myCmd.Parameters.Add(New SqlParameter("@id_Merksyst", idMersyst))
            myCmd.Parameters.Add(New SqlParameter("@sucursal", Sucursal))
            'declaramos una variable de tipo OUTPUT del procedimiento almacenado
            myCmd.Parameters.Add("@respuesta", SqlDbType.VarChar, 255)
            myCmd.Parameters("@respuesta").Direction = ParameterDirection.Output
            myCmd.CommandText = "sp_insertSucursalClienteShoppify"

            'abrimos la coneccion
            myConn.Open()
            myCmd.ExecuteNonQuery() ' Ejecuta el procedimiento almacenado 

            'almacenamos la respuesta que envia el procedimiento
            Dim resultado As String = myCmd.Parameters("@respuesta").Value
            'Limpiamos caracteres en blanco y determinamos si existe un error (si trae algun mensaje)
            If (resultado.Replace(" "c, String.Empty) <> "") Then
                '   lblError.Text = myCmd.Parameters("@respuesta").Value
                respuesta = myCmd.Parameters("@respuesta").Value
            End If
            'cerramos la conexion
            myConn.Close()
        Catch ex As Exception
            'lblError.Text = ex.Message
            respuesta = ex.Message
        End Try
        Return respuesta
    End Function

End Class
