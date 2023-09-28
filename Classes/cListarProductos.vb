Imports System.Data.SqlClient
Imports System.Net
Imports System.Text
Imports System.IO
Imports Newtonsoft.Json

Public Class cListarProductos
    Inherits cPedidosDatos

    'Variables de conexion para sql
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private _maxProductos As Integer
    Private _cuentaProductos As Integer = 0
    Private _host As String
    Private _user As String
    Private _pass As String
    Private _UltimoProducto = 0
    Private findIdCliente = ""
    Dim tableFilter As DataTable = New DataTable

    'Private listClientes As New List(Of cPedidosDatos)()
    Public Sub New(host As String, user As String, pass As String)
        Me._host = DecodeBase64ToString(host)
        Me._user = DecodeBase64ToString(user)
        Me._pass = DecodeBase64ToString(pass)
        'limpiamos la tabla 
        tableFilter.Clear()
        'Agregamos las columnas que llevara el sistema
        'Agregamos las columnas que llevara el sistema
        tableFilter.Columns.Add("sku")
        tableFilter.Columns("sku").ColumnName = "Sku"
        tableFilter.Columns.Add("title")
        tableFilter.Columns("title").ColumnName = "Encabezado"
        tableFilter.Columns.Add("Vendor")
        tableFilter.Columns("Vendor").ColumnName = "Proveedor"
        tableFilter.Columns.Add("option1")
        tableFilter.Columns("option1").ColumnName = "Empaque"
        tableFilter.Columns.Add("price")
        tableFilter.Columns("price").ColumnName = "Precio"
        tableFilter.Columns.Add("Estatus")
        tableFilter.Columns("Estatus").ColumnName = "Estatus"
        tableFilter.Columns.Add("images")
        tableFilter.Columns("images").ColumnName = "Img"
        tableFilter.Columns.Add("body_html")
        tableFilter.Columns("body_html").ColumnName = "Descripcion"
        tableFilter.Columns.Add("id")
        tableFilter.Columns("id").ColumnName = "Id"
        tableFilter.Columns.Add("Tags")
        tableFilter.Columns("Tags").ColumnName = "Tags"
        maxProductos()

    End Sub

    Public Function listarShoppify() As Dictionary(Of Boolean, DataTable)
        Dim URL As String = "https://" + VariablesGlobales.tienda + ".myshopify.com/admin/api/2023-07/products.json?fields=id,title,body_html,vendor,variants,status,image,tags&limit=150&since_id=" + _UltimoProducto.ToString

        'Variables de conexion propias de VB.net
        Dim myReq As WebRequest
        Dim myResp As HttpWebResponse
        Dim maxFila = 0
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        'Variables que llevan las credenciales de Shopify
        Dim appKey As String = VariablesGlobales.APIKey & ":" & VariablesGlobales.Password
        Dim byteKey As Byte() = Encoding.UTF8.GetBytes(appKey)
        Dim SimpleCredential As NetworkCredential = New NetworkCredential(VariablesGlobales.APIKey, VariablesGlobales.Password)
        appKey = Convert.ToBase64String(byteKey)

        'Asignamos a la variable la la ruta, las credenciales y el tipo
        myReq = WebRequest.Create(URL)
        myReq.Credentials = SimpleCredential
        myReq.Headers.Add("Authorization", "Basic " & appKey)
        myReq.ContentType = "application/json"

        'Indicamos que el metodo sera de tipo GET
        myReq.Method = "GET"

        'Recibimos la respuesta de la pagina de shopify
        myResp = myReq.GetResponse()
        Dim myreader As New StreamReader(myResp.GetResponseStream())
        ' si tiene informacion entra
        If myResp.StatusCode >= 200 And myResp.StatusCode <= 210 Then
            'leemos el json que regresa la pagina de shopify
            Dim jsonShopify As String = myreader.ReadToEnd()

            'Convertimos el json a un array que posteriormente vamos a recorrer
            Dim objJson As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(jsonShopify)
            Dim arrayShopify = objJson("products")
            'Recorremos el array para ver el Id que tenga el cliente
            For Each arrayPartner As Object In arrayShopify
                Dim arrayData As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(arrayPartner.ToString)

                'extraemos la informacion que viene de la pagina
                Dim id As String = arrayData("id")
                Dim title As String = arrayData("title")
                Dim body_html As String = arrayData("body_html")
                Dim vendor As String = arrayData("vendor")
                Dim Estatus As String = arrayData("status")
                Dim variants = arrayData("variants")
                Dim Tags = arrayData("tags")
                Dim option1 As String = ""
                Dim option2 As String = ""
                Dim sku As String = ""
                Dim price As String = ""
                Dim images As String = ""
                If (Estatus = "active") Then
                    Estatus = "Activo"
                ElseIf (Estatus = "draft") Then
                    Estatus = "Borrador"
                End If

                For Each arrayVariants As Object In variants
                    option1 = arrayVariants("option1").ToString
                    If (option1 = "Default Title") Then
                        option1 = ""
                    End If

                    option2 = arrayVariants("option2").ToString()
                    sku = arrayVariants("sku")
                    price = arrayVariants("price")
                Next
                images = "No"
                If (arrayData("image") IsNot Nothing) Then
                    images = "SI"
                End If
                tableFilter.Rows.Add(sku, title, vendor, option1, price, Estatus, images, body_html, id, Tags)
                'asignamos el id que revisamos a la variable de valor actual
                _UltimoProducto = arrayData("id")
                maxFila = maxFila + 1
                _cuentaProductos = _cuentaProductos + 1
            Next
        Else
            'Si existe error de coneccion lo mostramos
            MsgBox("Error al conectar con la pagina")
        End If
        myResp.Close()

        _maxProductos = _cuentaProductos
        Dim resultDic = New Dictionary(Of Boolean, DataTable)
        If (_maxProductos <= _cuentaProductos) Then
            resultDic.Add(False, tableFilter)
        Else
            resultDic.Add(True, tableFilter)
        End If
        Return resultDic
    End Function

    Private Sub maxProductos()
        Dim URL As String = "https://" + VariablesGlobales.tienda + ".myshopify.com/admin/api/2023-07/products/count.json"
        'Variables de conexion propias de VB.net
        Dim myReq As WebRequest
        Dim myResp As HttpWebResponse
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Try
            'Variables que llevan las credenciales de Shopify
            Dim appKey As String = VariablesGlobales.APIKey & ":" & VariablesGlobales.Password
            Dim byteKey As Byte() = Encoding.UTF8.GetBytes(appKey)
            Dim SimpleCredential As NetworkCredential = New NetworkCredential(VariablesGlobales.APIKey, VariablesGlobales.Password)
            appKey = Convert.ToBase64String(byteKey)

            'Asignamos a la variable la la ruta, las credenciales y el tipo
            myReq = WebRequest.Create(URL)
            myReq.Credentials = SimpleCredential
            myReq.Headers.Add("Authorization", "Basic " & appKey)
            myReq.ContentType = "application/json"

            'Indicamos que el metodo sera de tipo GET
            myReq.Method = "GET"

            'Recibimos la respuesta de la pagina de shopify
            myResp = myReq.GetResponse()
            Dim myreader As New StreamReader(myResp.GetResponseStream())
            ' si tiene informacion entra
            If myResp.StatusCode >= 200 And myResp.StatusCode <= 210 Then
                Dim jsonShopify As String = myreader.ReadToEnd()
                Dim objJson As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(jsonShopify)
                Dim arrayShopify = objJson("count")
                _maxProductos = arrayShopify
            End If
            myResp.Close()
        Catch e As WebException

        End Try

    End Sub
End Class
