
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Windows.Forms
Imports Newtonsoft.Json
Public Class cPedidosDatos
    'Declaramos las propiedades a utilizar
    Inherits cEncripta
    Implements iDatosClientes

    Private _id_Shopify As String
    Private _Almacen As String
    Private _idCliente As String
    Private _subAlmacen As String

    Public Property id_Shopify As String Implements iDatosClientes.id_Shopify
        Get
            Return _id_Shopify
        End Get
        Set(value As String)
            _id_Shopify = value
        End Set
    End Property

    Public Property Almacen As String Implements iDatosClientes.Almacen
        Get
            Return _Almacen
        End Get
        Set(value As String)
            _Almacen = value
        End Set
    End Property

    Public Property idCliente As String Implements iDatosClientes.idCliente
        Get
            Return _idCliente
        End Get
        Set(value As String)
            _idCliente = value
        End Set
    End Property

    Public Property subAlmacen As String Implements iDatosClientes.subAlmacen
        Get
            Return _subAlmacen
        End Get
        Set(value As String)
            _subAlmacen = value
        End Set
    End Property
End Class
Public Class cPedidos
    Inherits cPedidosDatos

    'Variables de conexion para sql
    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader
    Private _host As String
    Private _user As String
    Private _pass As String
    Private findIdCliente As String

    Private _arrayTagsItem As Dictionary(Of String, String) = New Dictionary(Of String, String)()

    Private listClientes As New List(Of cPedidosDatos)()

    Public Sub New(host As String, user As String, pass As String)
        Me._host = DecodeBase64ToString(host)
        Me._user = DecodeBase64ToString(user)
        Me._pass = DecodeBase64ToString(pass)
    End Sub

    Public Function buscarClientes(listServidores As List(Of cServidoresSecundariosDatos)) As List(Of cPedidosDatos)
        ' Variables a usar
        Dim subAlmacen As String = ""
        listClientes.Clear()
        'creamos la coneccion con la BD principal
        myConn = New SqlConnection("Initial Catalog=TCADBMAS; Data Source=TBCMERKSYST; User ID=sa; Password=So9=69WkY3wP;")
        myCmd = myConn.CreateCommand

        'Recorremos el sistema por cada servidor que este dado de alta
        For Each vServer In listServidores
            subAlmacen = subAlmacen + "'" + DecodeBase64ToString(vServer.sAlmacen) + "'," 'Guardamos en una la lista de los subalmacenes
        Next
        If (subAlmacen <> "") Then
            'Quitamos el ultimo caracter que es una ","
            subAlmacen = subAlmacen.Substring(0, subAlmacen.Length - 1)
            'Hacemos una consulta por los subalmacenes Listados
            myCmd.CommandText = "select  distinct rtrim(ltrim(id_Shopify)) as id_Shopify, isnull(cxccli.suc,'') as Almacen, cxccli.cve as idCliente, isnull(invsas.cve,'') as subAlmacen from shopify_cliente join cxccli as cxccli ON  cxccli.cve = id_Merksyst left join invsas as invsas ON  cxccli.suc = invsas.cve_suc and invsas.cve in (" + subAlmacen + ")"
            myConn.Open()
            myReader = myCmd.ExecuteReader()
            'si la consulta trae datos los guardamos en las variables
            Do While myReader.Read()
                'Datos del cliente
                listClientes.Add(New cPedidosDatos With {
                    .id_Shopify = myReader.GetString(0).ToString,
                    .Almacen = myReader.GetString(1).ToString,
                    .idCliente = myReader.GetString(2).ToString,
                    .subAlmacen = myReader.GetString(3).ToString})
            Loop
            'Cerramos la coneccion
            myConn.Close()
        End If

        Dim banRevisaArt = False
        Dim idArticulo = "0"
        Dim maxFila = 0
        While banRevisaArt = False
            For Each item In llenaDicArticulo(idArticulo)
                banRevisaArt = item.Key
                idArticulo = item.Value
            Next
            maxFila = maxFila + 1
        End While
        Return listClientes

    End Function
    Public Function llenarArticulos() As DataTable
        'Variables de conexion para sql 
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet

        'creamos la coneccion con la BD principal
        myConn = New SqlConnection("Initial Catalog=TCADBMAS; Data Source=TBCMERKSYST; User ID=sa; Password=So9=69WkY3wP;")
        myCmd = myConn.CreateCommand
        'Hacemos una consulta para revisar los codigos alternativos del cliente 
        myConn.Open()
        command = New SqlCommand("select distinct rtrim(ltrim(invars.cve_art)) as cve_art, rtrim(ltrim(invars.sub_alm)) as sub_alm,  rtrim(ltrim(invsas.cve_suc)) as cve_suc, invars.existencia from invars as invars INNER JOIN invsas as invsas ON invars.cia = invsas.cia and invsas.alm = invars.alm and invsas.cve = invars.sub_alm where invars.cia <>'' and invars.sub_alm<>'' order by cve_art, cve_suc, sub_alm", myConn)
        adapter.SelectCommand = command
        adapter.Fill(ds, "dbArt")
        adapter.Dispose()
        command.Dispose()
        'Cerramos la coneccion
        myConn.Close()
        Return ds.Tables("dbArt")
    End Function

    Public Function listarPedidos(tablaJson As String, iconBadUser As Image, iconBlank As Image, iconAgotado As Image) As DataTable

        'creamos una tabla que contendra los datos de los articulos
        Dim tablaArticulos As New DataView(llenarArticulos())


        'Creamos la tabla para filtro
        Dim dt As New DataTable
        'Variables de las tablas
        Dim idOrden, divisa, idCliente, total, nombre, direccion, ciudad, telefono, idItem, cp As String, fecha As String, browser_ip As String

        'leemos el json que regresa la pagina de shopify
        Dim jsonShopify As String = tablaJson

        'Convertimos el json a un array que posteriormente vamos a recorrer
        Dim objJson As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(jsonShopify)
        Dim arrayShopify = objJson("orders")

        'Indicamos que usaremos una columna de tipo imagen
        Dim imageColumn As New DataColumn
        imageColumn.ColumnName = "Estatus"
        imageColumn.DataType = GetType(Bitmap)

        'Agregamos las cabeceras de la tabla
        dt.Columns.Add(imageColumn)
        dt.Columns.Add("idOrden")
        dt.Columns.Add("Fecha")
        dt.Columns.Add("IdMerksyst")
        dt.Columns.Add("Nombre")
        dt.Columns.Add("Almacen")
        dt.Columns.Add("idArticulo")
        dt.Columns.Add("Cant")
        dt.Columns.Add("U.M.")
        dt.Columns.Add("Precio")
        dt.Columns.Add("Subtotal")
        dt.Columns.Add("Bebida")
        dt.Columns.Add("idItem")
        dt.Columns.Add("divisa")
        dt.Columns.Add("TotalOrden")
        dt.Columns.Add("direccion")
        dt.Columns.Add("ciudad")
        dt.Columns.Add("cp")
        dt.Columns.Add("telefono")
        dt.Columns.Add("idCliente")
        dt.Columns.Add("Error")
        dt.Columns.Add("browser_ip")
        'Recorremos el array (cada compra que esta registrada)
        For Each orden As Object In arrayShopify
            'Extraemos los datos principales de la orden
            Dim arrayData As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(orden.ToString)
            'Extraemos los datos de los articulos
            Dim arrayCliente As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(arrayData("customer").ToString)
            'Extraemos los de la factura
            Dim arrayFactura As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(arrayData("billing_address").ToString)
            'Extraemos los datos de la direccion
            Dim arrayDireccion As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(arrayCliente("default_address").ToString)

            ' Agregamos a las variables los datos que trae el json segun la parte que sea necesaria
            idOrden = arrayData("order_number")
            browser_ip = arrayData("browser_ip")
            fecha = Format(arrayData("created_at"), "dd/MM/yyyy HH:mm:ss")
            divisa = arrayData("currency")
            total = arrayData("subtotal_price")
            idCliente = arrayCliente("id")
            nombre = arrayDireccion("first_name") + " " + arrayDireccion("last_name")
            direccion = arrayDireccion("address1") + arrayDireccion("address2")
            ciudad = arrayDireccion("city")
            cp = arrayDireccion("zip")
            telefono = ""
            'Si tiene un telefono registrado lo asignamos a la variable
            If (arrayCliente("phone")) Then
                telefono = arrayCliente("phone")
            End If

            Dim ant_IdCte = idCliente
            'Recorremos el array de articulos por cada articulo registrado en el pedido
            For Each arrayArticulo As Object In arrayData("line_items")


                'Si la cantidad pedida es mayor a 0 entramos
                If (arrayArticulo("fulfillable_quantity") > 0) Then

                    'creamos la fila de la tabla asi como las variables necesarias
                    Dim R As DataRow = dt.NewRow
                    Dim idArticulo, precio, cantidad
                    Dim medida = ""
                    Dim bebida = ""
                    Dim Subtotal As Double
                    Dim almacen As String = ""
                    Dim cve_almacen As String = ""
                    Dim IdMerksyst As String = ""
                    Dim vError As String = "Cliente no registrado"
                    Dim tempBanFormato = False

                    'Asignamos el icono que veremos al principio de la tabla
                    Dim vIcon = iconBadUser

                    'Asignamos los datos de los articulos a las variables
                    idItem = arrayArticulo("id")
                    idArticulo = arrayArticulo("sku")
                    precio = arrayArticulo("price").ToString
                    cantidad = arrayArticulo("quantity").ToString
                    Subtotal = precio * cantidad


                    'Revisamos los tags del articulo
                    If (Not (_arrayTagsItem.ContainsKey(idArticulo))) Then
                        revisaArticulo(arrayArticulo("product_id"), idArticulo)
                    End If

                    If (arrayArticulo("variant_title") <> "") Then
                        'Convertimos la cadena en un array separado por el caracter "/"
                        Dim arrayMedida = arrayArticulo("variant_title").ToString.Split("/")
                        medida = arrayMedida(0) ' Unidad de medida 
                    End If

                    'revisamos que el cliente este registrado y que almacen tiene
                    findIdCliente = idCliente.ToString
                    Dim indexIdCte = listClientes.FindIndex(AddressOf EncontrarCliente)
                    If (indexIdCte > -1) Then
                        IdMerksyst = listClientes(indexIdCte).idCliente
                        almacen = listClientes(indexIdCte).subAlmacen
                        vIcon = iconBlank
                        vError = ""
                    End If
                    'Revisamos que el articulo este en el almacen princpal del cliente
                    Dim maxval = 0
                    tablaArticulos.RowFilter = "cve_art = '" & idArticulo & "' AND sub_alm ='" & almacen & "'"
                    maxval = tablaArticulos.Count
                    If (maxval = 0 And almacen = "MIN1") Then
                        tablaArticulos.RowFilter = "cve_art = '" & idArticulo & "' AND sub_alm ='MIN3'"
                        maxval = tablaArticulos.Count
                    End If
                    Dim tmpExistencia As Double = 0
                    If (maxval > 0) Then

                        Dim tmpSuc = ""
                        For Each tmpItemBD In tablaArticulos
                            tmpSuc = tmpItemBD("cve_suc")
                            tmpExistencia = tmpItemBD("existencia")
                        Next
                        Dim tmpMaxVal As Integer = 0
                        Dim tmpArrayItem = _arrayTagsItem(idArticulo).Split(",")
                        For Each tmpTag In tmpArrayItem
                            tmpTag = tmpTag.Trim
                            If (tmpTag = "CBA") Then
                                tmpTag = "COR"
                            ElseIf (tmpTag = "BEB") Then
                                tmpTag = "TBE"
                            End If

                            If (tmpSuc.Trim() = tmpTag.Trim()) Then
                                tmpMaxVal = 1
                            End If
                        Next
                        If (tmpMaxVal = 0) Then
                            maxval = 0
                        End If
                    End If
                    If (maxval = 0) Then
                        Dim myResult As SqlDataReader
                        'Hacemos una consulta para revisar los codigos alternativos del cliente
                        myCmd.CommandText = "select id_Merksyst, sucursal from shopify_cliente_sucursal where id_Shopify = '" & idCliente.ToString & "'"
                        myConn.Open()
                        myResult = myCmd.ExecuteReader()
                        Dim tmpBanError = False
                        'si la consulta trae datos revisamos que la informacion sea correcta
                        Do While myResult.Read()
                            Dim tempSucursal = myResult.GetString(1).ToString
                            Dim tempCliente = myResult.GetString(0).ToString

                            tablaArticulos.RowFilter = "cve_art = '" & idArticulo & "' AND sub_alm ='" & tempSucursal & "'"
                            maxval = tablaArticulos.Count
                            For Each tmpItemBD In tablaArticulos
                                tmpExistencia = tmpItemBD("existencia")
                            Next


                            If (maxval = 0 And almacen = "MIN1") Then
                                tablaArticulos.RowFilter = "cve_art = '" & idArticulo & "' AND sub_alm ='MIN3'"
                                maxval = tablaArticulos.Count
                            End If
                            If (maxval > 0) Then
                                'En caso de encontralo,asignamo el ID, el Numero de cliente y el icono a la tabla del cliente
                                tmpBanError = True
                                IdMerksyst = tempCliente
                                almacen = tempSucursal
                                vIcon = iconBlank
                                vError = ""
                            End If
                        Loop

                        'Cerramos la coneccion
                        myConn.Close()
                        'En caso de no encontrar al cliente alternativo mostramos el error
                        If (maxval = 0) Then
                            IdMerksyst = ""
                            almacen = ""
                            vIcon = iconBadUser
                            vError = "Este articulo no se encuentra la sucursal"
                        End If
                    End If

                    If (maxval > 0) And (tmpExistencia = 0) Then
                        vIcon = iconAgotado
                        vError = "Articulo agotado"
                        almacen = ""
                    End If
                    'Agregamos filas que llevara la tabla
                    R("idOrden") = idOrden.ToString
                    R("Fecha") = fecha.ToString
                    R("idCliente") = idCliente.ToString
                    If (nombre.ToString.Length >= 50) Then
                        R("Nombre") = nombre.ToString.Substring(0, 49)
                    Else
                        R("Nombre") = nombre.ToString
                    End If
                    R("direccion") = direccion.ToString
                    R("ciudad") = ciudad.ToString
                    R("cp") = cp.ToString
                    R("telefono") = telefono.ToString
                    R("divisa") = divisa.ToString
                    R("TotalOrden") = total.ToString
                    R("idArticulo") = idArticulo.ToString
                    R("Cant") = cantidad.ToString
                    R("precio") = precio.ToString
                    R("Subtotal") = Format(Subtotal, "0.00")
                    R("U.M.") = medida.ToString
                    R("Bebida") = bebida.ToString
                    R("idItem") = idItem.ToString
                    R("Estatus") = vIcon
                    R("Almacen") = almacen
                    R("IdMerksyst") = IdMerksyst
                    R("Error") = vError
                    R("browser_ip") = browser_ip
                    dt.Rows.Add(R)
                End If
            Next
        Next
        Return dt
    End Function
    Private Function EncontrarCliente(item As cPedidosDatos) As Boolean
        Return (item.id_Shopify = findIdCliente)
    End Function

    Public Function checkAlmacenes(arrayCheck As IEnumerable(Of CheckBox)) As List(Of String)
        'declaramos las Variables a usar 
        Dim arrayServidoresCheck As List(Of String) = New List(Of String)

        'determinamos que almacenes estan activos 
        For Each chk As CheckBox In arrayCheck
            Dim arrayNombre = chk.Name.Split("_")
            Dim IdBusca = arrayNombre(1)
            If (arrayNombre(0) = "chkServer") Then
                If chk.Checked = True Then
                    arrayServidoresCheck.Add(chk.Text)
                End If
            End If
        Next
        Return arrayServidoresCheck
    End Function

    Public Function EjecutaSPGuarda(myConn As SqlConnection, data As DataGridViewRow) As String
        Dim result As String = ""
        Try
            'Creamos el comando como procedimiento almacenado
            myCmd = myConn.CreateCommand
            myCmd.CommandType = CommandType.StoredProcedure
            'Enviamos los parametros
            myCmd.Parameters.Add(New SqlParameter("@subAlmacen", data.Cells("Almacen").Value.ToString))
            myCmd.Parameters.Add(New SqlParameter("@idOrden", data.Cells("idOrden").Value.ToString))
            myCmd.Parameters.Add(New SqlParameter("@fecha", data.Cells("Fecha").Value.ToString))
            myCmd.Parameters.Add(New SqlParameter("@idCliente", data.Cells("idCliente").Value.ToString))
            myCmd.Parameters.Add(New SqlParameter("@nombre", data.Cells("Nombre").Value.ToString))
            myCmd.Parameters.Add(New SqlParameter("@direccion", data.Cells("direccion").Value.ToString))
            myCmd.Parameters.Add(New SqlParameter("@ciudad", data.Cells("ciudad").Value.ToString))
            myCmd.Parameters.Add(New SqlParameter("@cp", data.Cells("cp").Value.ToString))
            myCmd.Parameters.Add(New SqlParameter("@telefono", data.Cells("telefono").Value.ToString))
            myCmd.Parameters.Add(New SqlParameter("@divisa", data.Cells("divisa").Value.ToString))
            myCmd.Parameters.Add(New SqlParameter("@total", data.Cells("TotalOrden").Value.ToString))
            myCmd.Parameters.Add(New SqlParameter("@idArticulo", data.Cells("idArticulo").Value.ToString))
            myCmd.Parameters.Add(New SqlParameter("@cantidad", data.Cells("Cant").Value.ToString))
            myCmd.Parameters.Add(New SqlParameter("@unidad", data.Cells("U.M.").Value.ToString))
            myCmd.Parameters.Add(New SqlParameter("@precio", data.Cells("Precio").Value.ToString))
            myCmd.Parameters.Add(New SqlParameter("@idItemShopify", data.Cells("idItem").Value.ToString))
            myCmd.Parameters.Add(New SqlParameter("@id_cteMerksist", data.Cells("IdMerksyst").Value.ToString))
            'declaramos una variable de tipo OUTPUT del procedimiento almacenado
            myCmd.Parameters.Add("@respuesta", SqlDbType.VarChar, 255)
            myCmd.Parameters("@respuesta").Direction = ParameterDirection.Output
            myCmd.CommandText = "sp_insertPedidoShopify"
            'abrimos la coneccion
            myConn.Open()
            myCmd.ExecuteNonQuery() ' Ejecuta el procedimiento almacenado 
            'almacenamos la respuesta que envia el procedimiento
            Dim resultado = myCmd.Parameters("@respuesta").Value
            result = resultado.Replace(" "c, String.Empty)
            'cerramos la conexion
            myConn.Close()
        Catch ex As Exception
            myConn.Close()
            result = ex.ToString()

        End Try
        Return result
    End Function

    Private Sub revisaArticulo(idItem As String, idArticulo As String)
        Dim URL As String = "https://" + VariablesGlobales.tienda + ".myshopify.com/admin/api/2023-07/products/" + idItem + ".json?fields=id,tags"
        'URL = URL & "?limit=150&ids=7249915412675,6753624359107"
        Try
            'Variables de conexion propias de VB.net
            Dim myReq As WebRequest
            Dim myResp As HttpWebResponse

            'Variables que llevan las credenciales de Shopify
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim appKey As String = VariablesGlobales.APIKey & ":" & VariablesGlobales.Password
            Dim byteKey As Byte() = Encoding.UTF8.GetBytes(appKey)
            Dim SimpleCredential As NetworkCredential = New NetworkCredential(VariablesGlobales.APIKey, VariablesGlobales.Password)
            appKey = Convert.ToBase64String(byteKey)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

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

                Dim arrayShopify = objJson("product")
                Dim arrayData As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(arrayShopify.ToString)
                _arrayTagsItem.Add(idArticulo, arrayData("tags"))
            End If
            myResp.Close()
        Catch ex As WebException
            Dim tmpError As String = ""
            If Not ex.Response Is Nothing Then
                Dim data As StreamReader = New StreamReader(ex.Response.GetResponseStream)
                tmpError = data.ReadToEnd
            Else
                tmpError = ex.Message
            End If
        End Try

    End Sub

    Private Function llenaDicArticulo(idArticulo As String) As Dictionary(Of Boolean, String)
        Dim URL As String = "https://" + tienda + ".myshopify.com/admin/api/2023-07/products.json"
        URL = URL & "?fields=id,variants,tags&limit=150&status=active&since_id=" + idArticulo
        Dim lastIdrticulo = idArticulo
        Dim resultDic As Dictionary(Of Boolean, String) = New Dictionary(Of Boolean, String)()
        Try
            'Variables de conexion propias de VB.net
            Dim myReq As WebRequest
            Dim myResp As HttpWebResponse

            'Variables que llevan las credenciales de Shopify
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim appKey As String = VariablesGlobales.APIKey & ":" & VariablesGlobales.Password
            Dim byteKey As Byte() = Encoding.UTF8.GetBytes(appKey)
            Dim SimpleCredential As NetworkCredential = New NetworkCredential(VariablesGlobales.APIKey, VariablesGlobales.Password)
            appKey = Convert.ToBase64String(byteKey)
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

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
                Dim arrayShopify = objJson("products")
                For Each arrayPrincipal As Object In arrayShopify
                    Dim arrayData As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(arrayPrincipal.ToString)
                    Dim id As String = arrayData("id")
                    Dim variants = arrayData("variants")
                    Dim Tags = arrayData("tags")
                    Dim sku As String = ""
                    For Each arrayVariants As Object In variants
                        If arrayVariants("sku") <> Nothing Then
                            sku = arrayVariants("sku")
                        End If
                    Next
                    If (sku <> "") Then
                        _arrayTagsItem.Add(sku, Tags)
                    End If
                    idArticulo = id
                Next
            End If
            myResp.Close()
        Catch ex As WebException
            Dim tmpError As String = ""
            If Not ex.Response Is Nothing Then
                Dim data As StreamReader = New StreamReader(ex.Response.GetResponseStream)
                tmpError = data.ReadToEnd
            Else
                tmpError = ex.Message
            End If
        End Try
        If (idArticulo = lastIdrticulo) Then
            resultDic.Add(True, idArticulo)
        Else
            resultDic.Add(False, idArticulo)
        End If
        Return resultDic
    End Function

End Class
