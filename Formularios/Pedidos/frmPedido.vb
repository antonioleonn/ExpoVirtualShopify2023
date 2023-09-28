
Imports Classes


Imports System.IO
Imports System.Net
Imports FontAwesome.Sharp
Imports System.Data.SqlClient

Public Class frmPedido
    'Declaramos las variables de uso global del formulario
    Private listServidores
    Private listClientes
    Private tmpPath = Path.GetDirectoryName(Application.ExecutablePath)
    Private diasEjecucion As List(Of String) = New List(Of String)
    Private minutosEjecucion As Integer
    Private MaxFilas = 0
    Private arrayServidores As Dictionary(Of String, Object) = New Dictionary(Of String, Object)

    Dim classPedidos As cPedidos = New cPedidos(VariablesGlobales.conIp, VariablesGlobales.conUsr, VariablesGlobales.conPsw)
    Private Sub frmPedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            frmInicio.cargaVisible()
            'Ejecutamos la busqueda de pedidos en segundo plano
            Dim tmpCargaInicial = New Task(AddressOf cargaInicial)
            tmpCargaInicial.Start()
        Catch ex As Exception
            MsgBox("Error: " + ex.Message)
        End Try
    End Sub

    Private Sub cargaInicial()

        mostrarServidores()
        listClientes = classPedidos.buscarClientes(listServidores)
        Me.Invoke(Sub()
                      frmInicio.cargaNoVisible()
                      'revisamos si existe un movimiento automatico
                      activarAutomatico()
                  End Sub)

    End Sub
    Private Sub mostrarServidores()
        'Declaramos las variables
        Dim classHost As cServidoresSecundarios = New cServidoresSecundarios(tmpPath)
        Dim x1 As Integer = 15
        Dim idElemento As Integer = 1
        'recorremos la lista por cada linea (sucursal)
        listServidores = classHost.leerArchivo()

        'Ordenamos lo servidores 
        For Each item In listServidores
            arrayServidores.Add(classHost.DecodeBase64ToString(item.sAlmacen), item)
        Next
        arrayServidores = arrayServidores.OrderBy(Function(x) x.Key).ToDictionary(Function(x) x.Key, Function(x) x.Value)

        For Each item In arrayServidores
            Dim dynamicCheck As New CheckBox
            Dim dynamicFormato As New IconPictureBox
            Dim subalmacen = item.Key
            'Guardamos la informacion de los servidores para usarla despues
            'arrayServidores.Add(subalmacen, item.Value)
            ' Definimos la distancia a mostrar de cada linea (x,y)
            dynamicFormato.Location = New Point(0, x1 + 3)
            dynamicCheck.Location = New Point(20, x1)
            ' Asignamos los nombres de cada elemento
            dynamicCheck.Name = "chkServer_" + idElemento.ToString
            ' Asignamos el tamaño (ancho y alto)
            dynamicFormato.Height = 20
            dynamicFormato.Width = 20
            dynamicCheck.Width = 81
            dynamicCheck.Height = 25
            ' Asignamos el texto 
            dynamicCheck.Text = subalmacen
            'dynamicButton.Image = Conecta_ShopifyV2.My.Resources.Resources.trash_solid_15
            dynamicFormato.IconColor = Color.IndianRed
            dynamicFormato.IconSize = 20
            dynamicCheck.Checked = True 'Marcamos como seleccionado el checkBox 

            dynamicFormato.BackColor = Color.Transparent
            dynamicCheck.BackColor = Color.Transparent
            'Agregamos los elementos al panel  
            Me.Invoke(Sub()
                          divServidores.Controls.Add(dynamicCheck)
                      End Sub)
            'Declaramos la propiedad onclick  
            x1 = x1 + 30
            idElemento = idElemento + 1
        Next
    End Sub

    Private Sub activarAutomatico()
        Dim classTareas As cTareas = New cTareas(tmpPath)
        Dim maxFila = 0
        For Each Linea As String In classTareas.leerAutomatico
            If (maxFila = 0) Then
                If (Linea = "True") Then
                    Timer1.Enabled = True
                    alertAuto.Visible = True
                End If
            ElseIf (maxFila = 1) Then
                If (Linea <> "") Then
                    minutosEjecucion = Linea
                End If
            ElseIf (maxFila = 2) Then
                If (Linea <> "") Then
                    For Each tmpItem In Linea.Split(Convert.ToChar(Keys.Tab))
                        diasEjecucion.Add(tmpItem)
                    Next
                End If
            ElseIf (maxFila = 3) And (alertAuto.Visible = True) Then
                If (Linea <> "") Then
                    txtSucursales.Text = Linea.Replace(Convert.ToChar(Keys.Tab), ", ")
                    For Each chk As CheckBox In divServidores.Controls.OfType(Of CheckBox)
                        chk.Checked = False
                    Next
                    For Each chk As CheckBox In divServidores.Controls.OfType(Of CheckBox)
                        For Each arrayLinea In Linea.Split(Convert.ToChar(Keys.Tab))
                            If (chk.Text = arrayLinea) Then
                                chk.Checked = True
                            End If
                        Next
                    Next
                End If
            End If
            maxFila = maxFila + 1
        Next

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim hoy = DateTime.Now
        Dim valor = diasEjecucion.IndexOf(hoy.DayOfWeek)
        If (valor < 0) Then
            Dim busca = DateTime.Now
            For i As Integer = 0 To 6
                busca = busca.AddDays(1)
                valor = diasEjecucion.IndexOf(busca.DayOfWeek)
                If (valor >= 0) Then
                    txtProxEjecuta.Text = busca.ToString("dd/MM/yyyy 00:00:00")
                    i = 6
                End If
            Next
        End If
        If ((txtProxEjecuta.Text = "") Or (txtProxEjecuta.Text = Now.ToString("dd/MM/yyyy HH:mm:ss"))) Then
            fechaFin.Value = hoy
            fechaIni.Value = hoy.AddMinutes(-minutosEjecucion)
            btnBuscar.PerformClick()
            hoy = hoy.AddMinutes(minutosEjecucion)
            txtProxEjecuta.Text = hoy.ToString("dd/MM/yyyy HH:mm:ss")
        End If
    End Sub

    Private Sub btnAutomatico_Click(sender As Object, e As EventArgs) Handles btnAutomatico.Click
        alertAuto.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frmInicio.cargaVisible()
        'Limpiamos la tabla
        dataGridErrores.Columns.Clear()
        'Ejecutamos la busqueda de pedidos en segundo plano
        Dim tmpBuscarPedidos = New Task(AddressOf BuscarPedidos)
        tmpBuscarPedidos.Start()
    End Sub

    Sub BuscarPedidos()
        'Creamos la tabla para filtro
        Dim dt As New DataTable
        ' Extraemos las fechas en una variable
        Dim tmpFechaIni = Format(CDate(TimeZoneInfo.ConvertTimeToUtc(fechaIni.Value)), "yyyyMMddTHHmm00")
        Dim tmpFechaFin = Format(CDate(TimeZoneInfo.ConvertTimeToUtc(fechaFin.Value)), "yyyyMMddTHHmm00")

        'Redireccionamos la pagina de pedidos e shopify
        Dim URL As String = "https://" + VariablesGlobales.tienda + ".myshopify.com/admin/api/2021-10/orders.json?fields=id,browser_ip,order_number,created_at,currency,subtotal_price,billing_address,customer,line_items&created_at_min=" + tmpFechaIni + "&created_at_max=" + tmpFechaFin
        Try
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            'Variables de conexion propias de VB.net
            Dim myReq As WebRequest
            Dim myResp As HttpWebResponse

            'Variables que llevan las credenciales de Shopify
            Dim appKey As String = VariablesGlobales.APIKey & ":" & VariablesGlobales.Password
            Dim byteKey As Byte() = System.Text.Encoding.UTF8.GetBytes(appKey)
            Dim SimpleCredential As NetworkCredential = New NetworkCredential(VariablesGlobales.APIKey, VariablesGlobales.Password)
            appKey = System.Convert.ToBase64String(byteKey)

            'Asignamos a la variable la la ruta, las credenciales y el tipo
            myReq = WebRequest.Create(URL)
            myReq.Credentials = SimpleCredential
            myReq.Headers.Add("Authorization", "Basic " & appKey)
            myReq.ContentType = "application/json"

            'Indicamos que el metodo sera de tipo GET
            myReq.Method = "GET"

            'Recibimos la respuesta de la pagina de shopify
            myResp = CType(myReq.GetResponse(), HttpWebResponse)
            Dim myreader As New System.IO.StreamReader(myResp.GetResponseStream())
            ' si tiene informacion entra
            If myResp.StatusCode >= 200 And myResp.StatusCode <= 210 Then
                Dim iconBadUser As Image = Formularios.My.Resources.Resources.user_times_solid
                Dim iconblank As Image = Formularios.My.Resources.Resources.blank
                Dim iconAgotado As Image = Formularios.My.Resources.Resources.Agotado
                dt = classPedidos.listarPedidos(myreader.ReadToEnd(), iconBadUser, iconblank, iconAgotado)
                ' agregamos los pedidos descargados a la tabla
                Me.Invoke(Sub()
                              DataGridView1.DataSource = dt
                              DataGridView1.Columns(0).Width = 40
                              DataGridView1.Columns(5).Width = 70
                              DataGridView1.Columns(7).Width = 40
                              DataGridView1.Columns(8).Width = 40
                              MaxFilas = DataGridView1.Rows.Count - 1
                              lblTotal.Text = "Total de filas procesadas: 0 / " + MaxFilas.ToString()
                              frmInicio.cargaNoVisible()
                              If (Timer1.Enabled = True) Then
                                  'btnDescargar.PerformClick()
                              End If
                          End Sub)
            End If

        Catch ex As WebException
            'En caso de presentarse un error con la conexion con la pagina de Shopify lo mostramos en la tabla de errores 
            Dim tmpError As String = ""
            If Not ex.Response Is Nothing Then
                Dim data As StreamReader = New StreamReader(ex.Response.GetResponseStream)
                tmpError = data.ReadToEnd
            Else
                tmpError = ex.Message
            End If
            Me.Invoke(Sub()
                          dataGridErrores.Columns.Add("Error", "Error")
                          dataGridErrores.Columns(0).Width = dataGridErrores.Width - 25
                          dataGridErrores.Rows.Add(tmpError)
                          frmInicio.cargaNoVisible()

                      End Sub)

        End Try

        Me.Invoke(Sub()
                      frmInicio.cargaNoVisible()
                  End Sub)
    End Sub

    Private Sub btnDescargar_Click(sender As Object, e As EventArgs) Handles btnDescargar.Click
        lblTotal.Text = "Total de filas procesadas: 0 / " + MaxFilas.ToString()
        dataGridErrores.Columns.Clear()
        dataGridErrores.Columns.Add("Pedido", "Pedido")
        dataGridErrores.Columns.Add("Error", "Error")
        dataGridErrores.Columns(0).Width = 100
        dataGridErrores.Columns(1).Width = dataGridErrores.Width - 125
        frmInicio.cargaVisible()
        Dim tmpEnviar = New Task(AddressOf Descargar)
        tmpEnviar.Start()
    End Sub
    Private Sub Descargar()
        Dim fila As Integer = 0
        'Recorremos los almacenes que seleccionamos, estos los obtenemor de la funcion
        For Each item In classPedidos.checkAlmacenes(divServidores.Controls.OfType(Of CheckBox))
            Dim arrayDatos = arrayServidores(item)
            Dim myConn = New SqlConnection("Initial Catalog=TCADBMAS; Data Source=" &
                                              classPedidos.DecodeBase64ToString(arrayDatos.host) &
                                              "; User ID=" & classPedidos.DecodeBase64ToString(arrayDatos.user) &
                                              "; Password=" & classPedidos.DecodeBase64ToString(arrayDatos.pass) & ";")

            'Recorremos la tabla que tiene los pedidos
            For Each data As DataGridViewRow In DataGridView1.Rows
                'Revisamos que la celda que tiene el pedido no este vacia  
                If (Not (IsNothing(data.Cells(1).Value))) Then
                    'si el almacen es igual al que estamos recorriendo entra
                    If (item = data.Cells("Almacen").Value.ToString) Then
                        Dim tmpValue As String = classPedidos.EjecutaSPGuarda(myConn, data)
                        If (tmpValue <> "") Then
                            'Ejecutamos el proceso error si existe algun error en la misma
                            Me.Invoke(Sub()
                                          data.Cells("Estatus").Value = Formularios.My.Resources.Resources.window_close_regular
                                          data.Cells("Error").Value = tmpValue
                                          dataGridErrores.Rows.Add(data.Cells("idOrden").Value.ToString, tmpValue)
                                      End Sub)
                        Else
                            'En caso contrario guarda
                            Me.Invoke(Sub()
                                          fila = fila + 1
                                          data.Cells("Estatus").Value = Formularios.My.Resources.Resources.check_solid
                                          data.Cells("Error").Value = "Guardado"
                                          lblTotal.Text = "Total de filas procesadas: " + fila.ToString() + " / " + MaxFilas.ToString()
                                      End Sub)
                        End If
                    End If
                End If
            Next
        Next

        Me.Invoke(Sub()
                      frmInicio.cargaNoVisible()
                  End Sub)
    End Sub

End Class