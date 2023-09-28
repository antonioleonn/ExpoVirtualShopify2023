Imports System.Data.SqlClient
Imports System.Net
Imports System.Text
Imports System.IO
Imports Newtonsoft.Json

Public Class cListarClientes
    Inherits cPedidosDatos

    'Variables de conexion para sql
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private _maxClientes As Integer
    Private _cuentaClietes As Integer = 0
    Private _host As String
    Private _user As String
    Private _pass As String
    Private _UltimoCte = 0
    Private findIdCliente = ""
    Dim tableFilter As DataTable

    Private listClientes As New List(Of cPedidosDatos)()
    Public Sub New(host As String, user As String, pass As String)
        Me._host = DecodeBase64ToString(host)
        Me._user = DecodeBase64ToString(user)
        Me._pass = DecodeBase64ToString(pass)
        maxClientes()
    End Sub

    Public Sub buscaClienteSQL()

        tableFilter = New DataTable
        'limpiamos la tabla 
        tableFilter.Clear()
        'Agregamos las columnas que llevara el sistema
        tableFilter.Columns.Add(New DataColumn("IdMerksyst", GetType(String)))
        tableFilter.Columns.Add(New DataColumn("Nombre", GetType(String)))
        tableFilter.Columns.Add(New DataColumn("Apellidos", GetType(String)))
        tableFilter.Columns.Add(New DataColumn("Email", GetType(String)))
        tableFilter.Columns.Add(New DataColumn("Telefono", GetType(String)))
        tableFilter.Columns.Add(New DataColumn("IdShopify", GetType(String)))
        tableFilter.Columns.Add(New DataColumn("Sucursal", GetType(String)))
        tableFilter.Columns.Add(New DataColumn("Tags", GetType(String)))
        tableFilter.Columns.Add(New DataColumn("Estatus", GetType(String)))

        listClientes.Clear()
        'creamos la coneccion con la BD principal
        myConn = New SqlConnection("Initial Catalog=TCADBMAS; Data Source=TBCMERKSYST; User ID=sa; Password=So9=69WkY3wP;")

        'Creamos el comando como consulta
        myCmd = myConn.CreateCommand
        myCmd.CommandText = "select distinct rtrim(ltrim(id_Shopify)) as id_Shopify, id_Merksyst, rtrim(ltrim(suc)) as suc from shopify_cliente INNER JOIN cxccli ON cxccli.cve=id_Merksyst "

        'abrimos la coneccion
        myConn.Open()
        myReader = myCmd.ExecuteReader() 'Ejecuta la consulta

        'Repetimos mientras exista informacion
        Do While myReader.Read()
            'almacenamos la informacion en un diccionario el Id de shopify como KEY y Id de Merksyst como VALUE
            listClientes.Add(New cPedidosDatos With {
                    .id_Shopify = myReader.GetString(0).ToString,
                    .Almacen = myReader.GetString(2).ToString,
                    .idCliente = myReader.GetString(1).ToString,
                    .subAlmacen = ""})
        Loop
        'cerramos la conexion
        myConn.Close()

    End Sub

    Public Function listarShoppify() As Dictionary(Of Boolean, DataTable)
        Dim URL As String = "https://" + VariablesGlobales.tienda + ".myshopify.com/admin/api/2023-07/customers.json?fields=id,first_name,last_name,email,phone,tags,state&limit=150&since_id=" + _UltimoCte.ToString
        'Dim URL As String = "https://" + VariablesGlobales.tienda + ".myshopify.com/admin/api/2021-10/customers.json?fields=id,first_name,last_name,email,phone,tags,state&limit=150&ids=6221711605955"

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
            Dim arrayShopify = objJson("customers")
            'Recorremos el array para ver el Id que tenga el cliente
            For Each arrayPartner As Object In arrayShopify
                Dim arrayData As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(arrayPartner.ToString)

                'extraemos la informacion que viene de la pagina
                Dim Nombre As String = arrayData("first_name")
                Dim Apellidos As String = arrayData("last_name")
                Dim Email As String = arrayData("email")
                Dim Telefono As String = arrayData("phone")
                Dim IdShopify As String = arrayData("id")
                Dim Tag As String = arrayData("tags")
                Dim Estatus As String = arrayData("state")
                Dim IdMerksyst As String = ""
                Dim Sucursal As String = ""
                'revisamos que el cliente este registrado y que almacen tiene
                findIdCliente = IdShopify.ToString
                'Buscamos el Id de shopify, buscandolo en el array anterior
                Dim indexIdCte = listClientes.FindIndex(AddressOf EncontrarCliente)
                If (indexIdCte > -1) Then
                    IdMerksyst = listClientes(indexIdCte).idCliente
                    Sucursal = listClientes(indexIdCte).Almacen
                End If
                'Revisamos si el cliente tiene un telefono activo
                Dim banTelefono = True
                If (Telefono = "") Then
                    banTelefono = False
                End If
                'Revisamos si el cliente tiene un email activo
                Dim banMail = True
                If (banTelefono = False) Then
                    If (Email <> "") Then
                        If (Email.Substring(0, 6) = "nobody") Then
                            banMail = False
                        End If
                    Else
                        banMail = False
                    End If
                End If
                'Si tiene telefono o email, lo listamos
                If (banTelefono = True Or banMail = True) Then
                    tableFilter.Rows.Add(IdMerksyst, Nombre, Apellidos, Email, Telefono, IdShopify, Sucursal, Tag, Estatus)
                End If
                'asignamos el id que revisamos a la variable de valor actual
                _UltimoCte = arrayData("id")
                maxFila = maxFila + 1
                _cuentaClietes = _cuentaClietes + 1
            Next
        Else
            'Si existe error de coneccion lo mostramos
            MsgBox("Error al conectar con la pagina")
        End If
        myResp.Close()
        '_maxClientes = _cuentaClietes
        Dim resultDic = New Dictionary(Of Boolean, DataTable)
        If (_maxClientes <= _cuentaClietes) Then
            resultDic.Add(False, tableFilter)
        Else
            resultDic.Add(True, tableFilter)
        End If
        Return resultDic
    End Function

    Private Function EncontrarCliente(item As cPedidosDatos) As Boolean
        Return (item.id_Shopify = findIdCliente)
    End Function

    Private Sub maxClientes()
        Dim URL As String = "https://" + VariablesGlobales.tienda + ".myshopify.com/admin/api/2023-07/customers/count.json"
        'Variables de conexion propias de VB.net
        Dim myReq As WebRequest
        Dim myResp As HttpWebResponse

        Try

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
                Dim jsonShopify As String = myreader.ReadToEnd()
                Dim objJson As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(jsonShopify)
                Dim arrayShopify = objJson("count")
                _maxClientes = arrayShopify
            End If
            myResp.Close()
        Catch e As WebException

        End Try

    End Sub
End Class
