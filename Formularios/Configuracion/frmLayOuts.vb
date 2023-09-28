Imports Microsoft.Office.Interop

Public Class frmLayOuts
    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        guardaFile("LayOut_clientes", 1)
    End Sub

    Private Sub btnArticulos_Click(sender As Object, e As EventArgs) Handles btnArticulos.Click
        guardaFile("LayOut_Atriculos", 2)
    End Sub

    Private Sub btnListaArticulos_Click(sender As Object, e As EventArgs) Handles btnListaArticulos.Click
        guardaFile("LayOut_Editar_Atriculos", 3)
    End Sub

    Private Sub guardaFile(nombre As String, id As Double)
        'Abrimos el cuadro de dialogo
        SaveFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        SaveFileDialog1.Filter = "csv files | *.csv" 'Solo archivos csv
        SaveFileDialog1.Title = "Guardar archivo"
        SaveFileDialog1.FileName = nombre
        'Si tenemos un archivo entramos
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            'abimos el archivo y lo guardamos en una variable
            If (SaveFileDialog1.FileName <> "") Then

                frmInicio.cargaVisible()
                generaExcel(id)
            End If
        End If
    End Sub

    Private Sub generaExcel(index)

        Try
            Dim oExcel As Excel.Application = New Excel.Application()
            Dim Libro = oExcel.Workbooks.Add
            Dim Hoja = Libro.Worksheets(1)
            Dim maxFila = 1, maxColumna = 1
            Dim dataObj As DataObject
            Libro.Worksheets.Add()
            If (index = 1) Then
                Libro.Worksheets(1).Cells(1, 1) = "Nombre"
                Libro.Worksheets(1).Cells(1, 2) = "Apellidos"
                Libro.Worksheets(1).Cells(1, 3) = "Correo"
                Libro.Worksheets(1).Cells(1, 4) = "Telefono"
                Libro.Worksheets(1).Cells(1, 5) = "Direccion"
                Libro.Worksheets(1).Cells(1, 6) = "Colonia"
                Libro.Worksheets(1).Cells(1, 7) = "Ciudad"
                Libro.Worksheets(1).Cells(1, 8) = "Estado"
                Libro.Worksheets(1).Cells(1, 9) = "Pais"
                Libro.Worksheets(1).Cells(1, 10) = "Pais"
                Libro.Worksheets(1).Cells(1, 11) = "CP"
                Libro.Worksheets(1).Cells(1, 12) = "Tags"
                Libro.Worksheets(1).Cells(1, 13) = "Id"
                Libro.Worksheets(1).Cells(1, 14) = "Notas"
                Libro.Worksheets(1).Cells(1, 15) = "Id_direccion_1"
                Libro.Worksheets(1).Cells(1, 15) = "Tienda_Origen"
            ElseIf (index = 2) Then
                Libro.Worksheets(1).Cells(1, 1) = "Producto"
                Libro.Worksheets(1).Cells(1, 2) = "Descripcion"
                Libro.Worksheets(1).Cells(1, 3) = "Marca"
                Libro.Worksheets(1).Cells(1, 4) = "Categoria"
                Libro.Worksheets(1).Cells(1, 5) = "Estatus"
                Libro.Worksheets(1).Cells(1, 6) = "Codigo_barras_1"
                Libro.Worksheets(1).Cells(1, 7) = "Sku_1"
                Libro.Worksheets(1).Cells(1, 8) = "Precio_1"
                Libro.Worksheets(1).Cells(1, 9) = "Unidad"
                Libro.Worksheets(1).Cells(1, 10) = "BEBIDA"
                Libro.Worksheets(1).Cells(1, 11) = "SUCURSALES"
            ElseIf (index = 3) Then
                Libro.Worksheets(1).Cells(1, 1) = "IdMerksyst"
                Libro.Worksheets(1).Cells(1, 2) = "IdShopify"
                Libro.Worksheets(1).Cells(1, 3) = "Titulo"
                Libro.Worksheets(1).Cells(1, 4) = "Descripcion"
                Libro.Worksheets(1).Cells(1, 5) = "Precio"
                Libro.Worksheets(1).Cells(1, 6) = "Empaque"
                Libro.Worksheets(1).Cells(1, 7) = "Etiqueta"

            End If
            Libro.SaveAs(SaveFileDialog1.FileName)
            oExcel.Quit()
            MsgBox("Se ha exportado correctamente", MsgBoxStyle.Information, "Correcto")
        Catch ex As Exception
            MsgBox("Error: " + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

        frmInicio.cargaNoVisible()
    End Sub

End Class