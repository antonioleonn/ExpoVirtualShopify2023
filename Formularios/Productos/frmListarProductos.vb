Imports System.IO
Imports Classes
Imports Microsoft.Office.Interop

Public Class frmListarProductos

    'Variables que usaremos en todo el sistema
    Dim valorActual
    Dim _banTimer = True
    Dim valorAnterior
    Dim ModificaSucursales = False
    Private arrayIdMerksystShopify As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Private tmpForm As Form
    Public globalIdProducto As String = ""
    Public tmpRow As Double = 0


    Public tableFilter As New DataTable
    Private classProd As cListarProductos = New cListarProductos(VariablesGlobales.conIp, VariablesGlobales.conUsr, VariablesGlobales.conPsw)
    Private Sub frmListarProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'iniciamos las variables
        valorActual = 1
        valorAnterior = 0
        'activamos la ventana de carga
        frmInicio.cargaVisible()
        'habilitamos la bandera del reloj
        TimerProducto.Enabled = True
    End Sub

    Private Sub TimerProducto_Tick(sender As Object, e As EventArgs) Handles TimerProducto.Tick

        'Cuando la bandera esta activa 
        If (_banTimer = True) Then
            'ponemos temporalmente la bandera del reloj en falso, esto con la intencion que no se sobrepongan las busquedass en caso de una actualizacion y detecte como un ataque la pagina de shopify
            _banTimer = False
            'si el valor anterior es mayor que el nuevo ya no entra  
            Dim banRepite As Boolean
            For Each item In classProd.listarShoppify()
                banRepite = item.Key
                tableFilter = item.Value
            Next

            If (banRepite = True) Then
                'Guardamos la informacion que hemos obtenido en la tabla 
                gridProductos.DataSource = tableFilter
                _banTimer = True
            Else
                ' en caso contrario deshabilitamos el timer y 
                gridProductos.DataSource = tableFilter
                TimerProducto.Enabled = False
                frmInicio.cargaNoVisible()
                gridProductos.Columns(2).Width = 50
                gridProductos.Columns(5).Width = 50
                gridProductos.Columns(8).Width = 50
                'DataGridView1.DataSource = tableFilter
            End If
        End If
    End Sub

    Private Sub txtEncabezado_TextChanged(sender As Object, e As EventArgs) Handles txtEncabezado.TextChanged
        filtroAvanzado()
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged
        filtroAvanzado()
    End Sub

    Private Sub txtEtiqueta_TextChanged(sender As Object, e As EventArgs) Handles txtEtiqueta.TextChanged
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
        If (txtEncabezado.Text <> "") Then
            If (busca <> "") Then
                busca = busca + " and "
            End If
            busca = busca + String.Format("[Encabezado] LIKE '%{0}%' ", txtEncabezado.Text)
        End If
        If (txtProveedor.Text <> "") Then
            If (busca <> "") Then
                busca = busca + " and "
            End If
            busca = busca + String.Format("[Proveedor] LIKE '%{0}%' ", txtProveedor.Text)
        End If

        If (txtEtiqueta.Text <> "") Then
            If (busca <> "") Then
                busca = busca + " and "
            End If
            busca = busca + String.Format("[Tags] LIKE '%{0}%' ", txtEtiqueta.Text)
        End If

        If (txtIdMerksyst.Text <> "") Then
            If (busca <> "") Then
                busca = busca + " and "
            End If
            busca = busca + String.Format("[sku] LIKE '%{0}%' ", txtIdMerksyst.Text)
        End If
        If (txtIdShopify.Text <> "") Then
            If (busca <> "") Then
                busca = busca + " and "
            End If
            busca = busca + String.Format("[id] LIKE '%{0}%' ", txtIdShopify.Text)
        End If
        If (busca = "") Then
            busca = "1=1"
        End If
        tableFilter.DefaultView.RowFilter = busca
    End Sub

    Private Sub gridProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridProductos.CellClick
        If (e.RowIndex >= 0) Then
            If (gridProductos.Rows(e.RowIndex).Cells(11).Value.ToString <> "") Then
                globalIdProducto = gridProductos.Rows(e.RowIndex).Cells(11).Value.ToString
                tmpRow = e.RowIndex
                If (e.ColumnIndex = 0) Then
                    mostrarFormulario(frmEditaProducto)
                ElseIf (e.ColumnIndex = 1) Then
                    mostrarFormulario(frmImagenesProductos)
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

        MenuStrip1.Visible = False
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

        MenuStrip1.Visible = True
        divEncabezado.Visible = True

        divModifica.Visible = False
        divModifica.Dock = DockStyle.None
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        If (gridProductos.RowCount() > 0) Then
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
            Libro.Worksheets(1).Name = "Productos"

            For i = 0 To gridProductos.Columns.Count() - 1
                Libro.Worksheets("Productos").Cells(maxFila, (i + 2)) = gridProductos.Columns(i).HeaderText
            Next
            maxFila = maxFila + 1
            gridProductos.SelectAll()
            dataObj = gridProductos.GetClipboardContent
            Clipboard.Clear()
            Clipboard.SetDataObject(dataObj)
            Libro.Worksheets("Productos").Select
            Libro.Worksheets("Productos").Cells(maxFila, 1).Select
            Libro.Worksheets("Productos").Paste

            Libro.SaveAs(SaveFileDialog1.FileName)
            oExcel.Quit()
            MsgBox("Se ha exportado correctamente", MsgBoxStyle.Information, "Correcto")
        Catch ex As Exception
            MsgBox("Error: " + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        frmInicio.cargaNoVisible()
    End Sub


End Class