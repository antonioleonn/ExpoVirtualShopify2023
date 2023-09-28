Imports System.IO
Imports Classes
Imports Microsoft.Office.Interop

Public Class frmListarClientes

    Private _banTimer
    Public _IdCliente
    Public _tmpRow
    Private tmpForm

    Public tableFilter As New DataTable
    Private classCte As cListarClientes = New cListarClientes(VariablesGlobales.conIp, VariablesGlobales.conUsr, VariablesGlobales.conPsw)
    Private Sub frmListarClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'iniciamos las variables
        divModifica.Visible = False
        _banTimer = True
        'activamos la ventana de carga
        frmInicio.cargaVisible()

        'Ejecutamos el proceso de llenado de clientes  desde SQL
        classCte.buscaClienteSQL()
        'habilitamos la bandera del reloj
        TimerCliente.Enabled = True

    End Sub

    Private Sub TimerCliente_Tick(sender As Object, e As EventArgs) Handles TimerCliente.Tick
        'Cuando la bandera esta activa 
        If (_banTimer = True) Then
            'ponemos temporalmente la bandera del reloj en falso, esto con la intencion que no se sobrepongan las busquedass en caso de una actualizacion y detecte como un ataque la pagina de shopify
            _banTimer = False
            'si el valor anterior es mayor que el nuevo ya no entra  
            Dim banRepite As Boolean
            For Each item In classCte.listarShoppify()
                banRepite = item.Key
                tableFilter = item.Value
            Next

            If (banRepite = True) Then
                'Guardamos la informacion que hemos obtenido en la tabla 
                DataGridView1.DataSource = tableFilter
                _banTimer = True
            Else
                ' en caso contrario deshabilitamos el timer y 
                DataGridView1.DataSource = tableFilter
                TimerCliente.Enabled = False
                frmInicio.cargaNoVisible()
                'DataGridView1.DataSource = tableFilter
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If (e.RowIndex >= 0) Then
            If (DataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString <> "") Then
                _IdCliente = DataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
                _tmpRow = e.RowIndex
                If (e.ColumnIndex = 0) Then
                    mostrarFormulario(frmEditaCliente)
                ElseIf (e.ColumnIndex = 1) Then
                    mostrarFormulario(frmCambiarPassword)
                End If
            End If
        End If

    End Sub


    Private Sub mostrarFormulario(formulario)
        If tmpForm IsNot Nothing Then
            tmpForm.Close()
            tmpForm = Nothing
        End If
        tmpForm = formulario
        tmpForm.TopLevel = False
        tmpForm.Dock = DockStyle.Fill
        tmpForm.FormBorderStyle = FormBorderStyle.None
        tmpForm.Show()


        MenuStrip2.Visible = False
        divEncabezado.Visible = False

        divModifica.Visible = True
        divModifica.Dock = DockStyle.Fill
        divModifica.Controls.Add(tmpForm)
    End Sub

    Public Sub ocultarFormulario()
        If tmpForm IsNot Nothing Then
            tmpForm.Close()
            tmpForm = Nothing
        End If

        MenuStrip2.Visible = True
        divEncabezado.Visible = True

        divModifica.Visible = False
        divModifica.Dock = DockStyle.None
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        filtroAvanzado()
    End Sub

    Private Sub txtTelefono_TextChanged(sender As Object, e As EventArgs) Handles txtTelefono.TextChanged
        filtroAvanzado()
    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged
        filtroAvanzado()
    End Sub

    Private Sub txtIdMerksyst_TextChanged(sender As Object, e As EventArgs) Handles txtIdMerksyst.TextChanged
        filtroAvanzado()
    End Sub

    Private Sub txtIdShopify_TextChanged(sender As Object, e As EventArgs) Handles txtIdShopify.TextChanged
        filtroAvanzado()
    End Sub

    Private Sub filtroAvanzado()
        Dim busca As String = ""
        If (txtNombre.Text <> "") Then
            If (busca <> "") Then
                busca = busca + " and "
            End If
            busca = busca + String.Format("[Nombre] LIKE '%{0}%' OR [Apellidos] LIKE '%{0}%'", txtNombre.Text)
        End If
        If (txtTelefono.Text <> "") Then
            If (busca <> "") Then
                busca = busca + " and "
            End If
            busca = busca + String.Format("[Telefono] LIKE '%{0}%' ", txtTelefono.Text)
        End If
        If (txtEmail.Text <> "") Then
            If (busca <> "") Then
                busca = busca + " and "
            End If
            busca = busca + String.Format("[Email] LIKE '%{0}%' ", txtEmail.Text)
        End If
        If (txtIdMerksyst.Text <> "") Then
            If (busca <> "") Then
                busca = busca + " and "
            End If
            busca = busca + String.Format("[IdMerksyst] LIKE '%{0}%' ", txtIdMerksyst.Text)
        End If
        If (txtIdShopify.Text <> "") Then
            If (busca <> "") Then
                busca = busca + " and "
            End If
            busca = busca + String.Format("[IdShopify] LIKE '%{0}%' ", txtIdShopify.Text)
        End If
        If (busca = "") Then
            busca = "1=1"
        End If
        tableFilter.DefaultView.RowFilter = busca
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        If (DataGridView1.RowCount() > 0) Then
            'Abrimos el cuadro de dialogo
            SaveFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            SaveFileDialog1.Filter = "xlsx files | *.xlsx" 'Solo archivos csv
            SaveFileDialog1.Title = "Guardar archivo"
            'Si tenemos un archivo entramos
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                'abimos el archivo y lo guardamos en una variable
                If (SaveFileDialog1.FileName <> "") Then

                    frmInicio.cargaVisible()
                    generaExcel()
                End If
            End If
        End If
    End Sub

    Private Sub generaExcel()

        Try
            Dim oExcel As Excel.Application = New Excel.Application()
            Dim Libro = oExcel.Workbooks.Add
            Dim Hoja = Libro.Worksheets(1)
            Dim maxFila = 1, maxColumna = 1
            Dim dataObj As DataObject
            Libro.Worksheets.Add()
            Libro.Worksheets(1).Name = "Clientes"

            For i = 0 To DataGridView1.Columns.Count() - 1
                Libro.Worksheets("Clientes").Cells(maxFila, (i + 2)) = DataGridView1.Columns(i).HeaderText
            Next
            maxFila = maxFila + 1
            DataGridView1.SelectAll()
            dataObj = DataGridView1.GetClipboardContent
            Clipboard.Clear()
            Clipboard.SetDataObject(dataObj)
            Libro.Worksheets("Clientes").Select
            Libro.Worksheets("Clientes").Cells(maxFila, 1).Select
            Libro.Worksheets("Clientes").Paste

            Libro.SaveAs(SaveFileDialog1.FileName)
            oExcel.Quit()
            MsgBox("Se ha exportado correctamente", MsgBoxStyle.Information, "Correcto")
        Catch ex As Exception
            MsgBox("Error: " + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        frmInicio.cargaNoVisible()
    End Sub
End Class