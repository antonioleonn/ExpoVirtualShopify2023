'Importamos las librerias 
Imports System.IO
Imports Classes
Imports Microsoft.Office.Interop

Public Class frmReportes

    Dim classReportes As cReportes = New cReportes(VariablesGlobales.conIp, VariablesGlobales.conUsr, VariablesGlobales.conPsw)

    Private Sub frmReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim subAlmacen = classReportes.buscaSucursales(Path.GetDirectoryName(Application.ExecutablePath))
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        'activamos la ventana de carga
        frmInicio.cargaVisible()
        Dim tmpBuscarSQL = New Task(AddressOf buscarSQL)
        tmpBuscarSQL.Start()
    End Sub

    Private Sub buscarSQL()
        Dim tmpFechaInicio = Format(fechaIni.Value, "yyyyMMddHHmm00")
        Dim tmpFechaFin = Format(fechaFin.Value, "yyyyMMddHHmm59")
        Dim maxInfo = classReportes.realizarBusqueda(tmpFechaInicio, tmpFechaFin)
        If (maxInfo.Count() > 0) Then
            Me.Invoke(Sub()
                          DataGridView1.DataSource = maxInfo("concentrado")
                          gridVentasGeneral.DataSource = maxInfo("VentasPrincipal")
                          gridVentasFecha.DataSource = maxInfo("VentasFecha")
                          gridPedidosFecha.DataSource = maxInfo("PedidosFecha")
                          gridArticulos.DataSource = maxInfo("Articulos")
                          DataGridError.DataSource = maxInfo("Error")

                          DataGridError.Columns(1).Width = DataGridError.Width - 25
                      End Sub)
        End If
        Me.Invoke(Sub()
                      frmInicio.cargaNoVisible()
                  End Sub)
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
            Libro.Worksheets(1).Name = "Totales"
            Libro.Worksheets(2).Name = "Concentrado"

            For i = 0 To gridVentasGeneral.Columns.Count() - 1
                Libro.Worksheets("Totales").Cells(maxFila, (i + 2)) = gridVentasGeneral.Columns(i).HeaderText
            Next
            maxFila = maxFila + 1
            gridVentasGeneral.SelectAll()
            dataObj = gridVentasGeneral.GetClipboardContent
            Clipboard.Clear()
            Clipboard.SetDataObject(dataObj)
            Libro.Worksheets("Totales").Select
            Libro.Worksheets("Totales").Cells(maxFila, 1).Select
            Libro.Worksheets("Totales").Paste
            maxFila = maxFila + gridVentasGeneral.Rows.Count + 2



            For i = 0 To gridVentasFecha.Columns.Count() - 1
                Libro.Worksheets("Totales").Cells(maxFila, (i + 2)) = gridVentasFecha.Columns(i).HeaderText
            Next
            maxFila = maxFila + 1
            gridVentasFecha.SelectAll()
            dataObj = gridVentasFecha.GetClipboardContent
            Clipboard.Clear()
            Clipboard.SetDataObject(dataObj)
            Libro.Worksheets("Totales").Select
            Libro.Worksheets("Totales").Cells(maxFila, 1).Select
            Libro.Worksheets("Totales").Paste
            maxFila = maxFila + gridVentasFecha.Rows.Count + 2


            For i = 0 To gridPedidosFecha.Columns.Count() - 1
                Libro.Worksheets("Totales").Cells(maxFila, (i + 2)) = gridPedidosFecha.Columns(i).HeaderText
            Next
            maxFila = maxFila + 1
            gridPedidosFecha.SelectAll()
            dataObj = gridPedidosFecha.GetClipboardContent
            Clipboard.Clear()
            Clipboard.SetDataObject(dataObj)
            Libro.Worksheets("Totales").Select
            Libro.Worksheets("Totales").Cells(maxFila, 1).Select
            Libro.Worksheets("Totales").Paste
            maxFila = maxFila + gridPedidosFecha.Rows.Count + 2



            For i = 0 To gridArticulos.Columns.Count() - 1
                Libro.Worksheets("Totales").Cells(maxFila, (i + 2)) = gridArticulos.Columns(i).HeaderText
            Next
            maxFila = maxFila + 1
            gridArticulos.SelectAll()
            dataObj = gridArticulos.GetClipboardContent
            Clipboard.Clear()
            Clipboard.SetDataObject(dataObj)
            Libro.Worksheets("Totales").Select
            Libro.Worksheets("Totales").Cells(maxFila, 1).Select
            Libro.Worksheets("Totales").Paste
            maxFila = maxFila + gridArticulos.Rows.Count + 2


            For i = 0 To DataGridView1.Columns.Count() - 1
                Libro.Worksheets("Concentrado").Cells(1, (i + 2)) = DataGridView1.Columns(i).HeaderText
            Next
            DataGridView1.SelectAll()
            dataObj = DataGridView1.GetClipboardContent
            Clipboard.Clear()
            Clipboard.SetDataObject(dataObj)
            Libro.Worksheets("Concentrado").Select
            Libro.Worksheets("Concentrado").Cells(2, 1).Select
            Libro.Worksheets("Concentrado").Paste
            Libro.SaveAs(SaveFileDialog1.FileName)
            oExcel.Quit()
            MsgBox("Se ha exportado correctamente", MsgBoxStyle.Information, "Correcto")
        Catch ex As Exception
            MsgBox("Error: " + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        frmInicio.cargaNoVisible()
    End Sub

End Class