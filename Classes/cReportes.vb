'Importamos las librerias  
Imports Microsoft.VisualBasic.FileIO
Imports System.IO
Imports System.Text
Imports System.Net
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Windows.Forms

Public Class cReportes
    Inherits cEncripta


    'Variables que usaremos en todo el sistema 
    Private _host As String
    Private _user As String
    Private _pass As String
    Public tableFilter As New DataTable
    Public tableError As New DataTable
    Public listServer As List(Of Object) = New List(Of Object)()
    Private arrayClienteMerk As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Private arraySubalmacenClienteMerk As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Public fomatoServidor As Dictionary(Of String, String) = New Dictionary(Of String, String)

    Private listReturn As Dictionary(Of String, DataTable) = New Dictionary(Of String, DataTable)()
    Private dataSet As New DataSet

    Public Sub New(host As String, user As String, pass As String)
        Me._host = DecodeBase64ToString(host)
        Me._user = DecodeBase64ToString(user)
        Me._pass = DecodeBase64ToString(pass)

        'Agregamos las cabeceras de la tabla 
        tableFilter.Columns.Add("idOrden")
        tableFilter.Columns.Add("Fecha")
        tableFilter.Columns.Add("Hora")
        tableFilter.Columns.Add("IdMerksyst")
        tableFilter.Columns.Add("Nombre")
        tableFilter.Columns.Add("Almacen")
        tableFilter.Columns.Add("idArticulo")
        tableFilter.Columns.Add("Cant", GetType(Decimal))
        tableFilter.Columns.Add("U.M.")
        tableFilter.Columns.Add("Precio")
        tableFilter.Columns.Add("Subtotal", GetType(Decimal))
        tableFilter.Columns.Add("Vendedor")

        tableError.Columns.Add("Sucursal")
        tableError.Columns.Add("Error")
    End Sub

    Public Function buscaSucursales(tmpPath As String) As String
        Dim classHost As cServidoresSecundarios = New cServidoresSecundarios(tmpPath)
        Dim subAlmacen As String = ""
        'recorremos la lista por cada linea obtenida del paso anterior
        For Each item In classHost.leerArchivo()
            Dim vServer = classHost.DecodeBase64ToString(item.sAlmacen)
            subAlmacen = subAlmacen + "'" + vServer + "'," 'Guardamos en una la lista de los subalmacenes 
            listServer.Add(item)
        Next
        Return subAlmacen
    End Function

    Public Function realizarBusqueda(FechaInicio As String, FechaFinal As String) As Dictionary(Of String, DataTable)
        listReturn.Clear()
        For Each item In listServer
            'Variables de conexion para sql
            Dim myConn As SqlConnection
            Dim myCmd As SqlCommand
            Dim command As SqlCommand
            Dim adapter As New SqlDataAdapter
            Dim ds As New DataSet
            Dim ip = DecodeBase64ToString(item.host)
            Dim user = DecodeBase64ToString(item.user)
            Dim pass = DecodeBase64ToString(item.pass)
            Dim suc = DecodeBase64ToString(item.sAlmacen)
            'creamos la coneccion con la BD principal
            Try
                myConn = New SqlConnection("Initial Catalog=TCADBMAS; Data Source=" & ip & "; User ID=" & user & "; Password=" & pass & ";")
                myCmd = myConn.CreateCommand
                'Hacemos una consulta para revisar los codigos alternativos del cliente 
                myConn.Open()
                command = New SqlCommand("select pedped.ord as idOrden, pedped.serie +'-' +pedped.num+'-'+pedped.par as Id_Merksyst, pedped.fec_ped as Fecha, pedped.hra_ped as Hora, pedped.cte as IdMerksyst, pedped.contacto as Nombre, sub_alm as Almacen, cve_art as idArticulo, ped as Cant, uds as [U.M.], precio as Precio, (precio * ped) as  Subtotal, pedped.ven as Vendedor, pedped.status from peddet inner JOIN pedped ON peddet.cia = pedped.cia and peddet.serie = pedped.serie and peddet.cve =pedped.num where ((pedped.fec_ped+pedped.hra_ped) >='" & FechaInicio & "' and (pedped.fec_ped+pedped.hra_ped) <= '" & FechaFinal & "') and pedped.ord like '%-" & suc & "%' order by  pedped.ord", myConn)

                adapter.SelectCommand = command
                adapter.Fill(ds, "dbArt")
                adapter.Dispose()
                command.Dispose()
                'Cerramos la coneccion
                dataSet.Merge(ds)
                myConn.Close()
            Catch e As Exception '
                tableError.Rows.Add(suc, e.Message) '

            End Try
            'Dim pass = encripta.DecodeBase64ToString(arrayCelda(2))
            'Dim suc = encripta.DecodeBase64ToString(arrayCelda(3))
        Next
        Dim view1 As New DataView(dataSet.Tables("dbArt"))
        If (view1.Count > 0) Then
            tableFilter = dataSet.Tables(0)
            listReturn.Add("concentrado", tableFilter)
            listReturn.Add("VentasPrincipal", fGridVentasPrincipal())
            listReturn.Add("VentasFecha", fGridVentasFecha())
            listReturn.Add("PedidosFecha", fGridPedidosFecha())
            listReturn.Add("Articulos", fGridArticulos())
            listReturn.Add("Error", tableError)
        End If
        Return listReturn
    End Function


    Private Function fGridVentasPrincipal() As DataTable
        'gridGeneral.DataSource = tableFilter.DefaultView.ToTable(True, "Almacen")
        Dim almacenLookup = tableFilter.AsEnumerable().ToLookup(Function(r) r("Almacen"))
        Dim orderLookup = tableFilter.DefaultView.ToTable(True, "idOrden", "Almacen")
        Dim clientesLookup = tableFilter.DefaultView.ToTable(True, "IdMerksyst", "Almacen")
        Dim tableGeneral As New DataTable

        tableGeneral.Columns.Add("Almacen")
        tableGeneral.Columns.Add("Total Ventas")
        tableGeneral.Columns.Add("Cantidad de pedidos")
        tableGeneral.Columns.Add("Clientes que participaron")
        tableGeneral.Columns.Add("Articulo mas Vendido")
        tableGeneral.Columns.Add("Cant. Vendidos")
        For Each item In almacenLookup
            Dim sumVentas As String = tableFilter.Compute("SUM(Subtotal)", "Almacen = '" & item.Key.ToString & "'")
            Dim contarPedidos As String = orderLookup.Compute("Count(idOrden)", "Almacen = '" & item.Key.ToString & "'")
            Dim contarClientes As String = clientesLookup.Compute("Count(IdMerksyst)", "Almacen = '" & item.Key.ToString & "'")
            Dim sqlArticulo = From row In tableFilter
                              Where row.Field(Of String)("Almacen") = item.Key.ToString
                              Group row By idArticulo = row.Field(Of String)("idArticulo") Into MonthGroup = Group Select New With {Key idArticulo, .cantMax = MonthGroup.Sum(Function(r) r.Field(Of Decimal)("Cant"))}
            Dim vMaxId = ""
            Dim vMax = -1

            For Each itemArt In sqlArticulo
                If (vMax < itemArt.cantMax) Then
                    vMax = itemArt.cantMax
                    vMaxId = itemArt.idArticulo
                End If
            Next
            tableGeneral.Rows.Add(item.Key, sumVentas, contarPedidos, contarClientes, vMaxId, vMax)
        Next
        Return tableGeneral
    End Function

    Private Function fGridVentasFecha() As DataTable
        'gridGeneral.DataSource = tableFilter.DefaultView.ToTable(True, "Almacen")
        Dim dateLookup = tableFilter.AsEnumerable().ToLookup(Function(r) r("Fecha"))
        Dim almacenLookup = tableFilter.AsEnumerable().ToLookup(Function(r) r("Almacen"))
        Dim tableGeneral As New DataTable
        Dim maxCol = 0
        tableGeneral.Columns.Add("Almacen")

        For Each item In dateLookup
            tableGeneral.Columns.Add(item.Key.ToString)
            maxCol = maxCol + 1
        Next
        For Each item In almacenLookup
            Dim arrayTotal(maxCol)
            arrayTotal(0) = item.Key
            Dim col = 1
            For Each itemFecha In dateLookup
                arrayTotal(col) = tableFilter.Compute("SUM(Subtotal)", "Almacen = '" & item.Key.ToString & "' and Fecha = '" & itemFecha.Key.ToString & "'")
                col = col + 1
            Next
            tableGeneral.Rows.Add(arrayTotal)
        Next
        Return tableGeneral
    End Function

    Private Function fGridPedidosFecha() As DataTable

        'gridGeneral.DataSource = tableFilter.DefaultView.ToTable(True, "Almacen")
        Dim almacenLookup = tableFilter.AsEnumerable().ToLookup(Function(r) r("Almacen"))
        Dim dateLookup = tableFilter.AsEnumerable().ToLookup(Function(r) r("Fecha"))
        Dim orderLookup = tableFilter.DefaultView.ToTable(True, "idOrden", "Almacen", "Fecha")
        Dim tableGeneral As New DataTable
        Dim maxCol = 0
        tableGeneral.Columns.Add("Almacen")

        For Each item In dateLookup
            tableGeneral.Columns.Add(item.Key.ToString)
            maxCol = maxCol + 1
        Next
        For Each item In almacenLookup
            Dim arrayTotal(maxCol)
            arrayTotal(0) = item.Key
            Dim col = 1
            For Each itemFecha In dateLookup
                arrayTotal(col) = orderLookup.Compute("Count(idOrden)", "Almacen = '" & item.Key.ToString & "' and Fecha = '" & itemFecha.Key.ToString & "'")
                col = col + 1
            Next
            tableGeneral.Rows.Add(arrayTotal)
        Next
        Return tableGeneral
    End Function

    Private Function fGridArticulos() As DataTable
        Dim almacenLookup = tableFilter.AsEnumerable().ToLookup(Function(r) r("Almacen"))
        Dim articuloLookup = tableFilter.AsEnumerable().ToLookup(Function(r) r("idArticulo"))
        Dim tableGeneral As New DataTable
        Dim maxCol = 0
        tableGeneral.Columns.Add("Articulo")

        For Each item In almacenLookup
            tableGeneral.Columns.Add(item.Key.ToString)
            maxCol = maxCol + 1
        Next
        For Each item In articuloLookup
            Dim arrayTotal(maxCol)
            arrayTotal(0) = item.Key
            Dim col = 1
            For Each itemAlmacen In almacenLookup
                arrayTotal(col) = tableFilter.Compute("sum(Cant)", "Almacen = '" & itemAlmacen.Key.ToString & "' and idArticulo = '" & item.Key.ToString & "'")
                col = col + 1
            Next
            tableGeneral.Rows.Add(arrayTotal)
        Next
        Return tableGeneral
    End Function


End Class
