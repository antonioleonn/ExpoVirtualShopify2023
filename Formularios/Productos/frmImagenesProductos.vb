Imports System.IO
Imports Classes

Public Class frmImagenesProductos
    Private fila As Integer
    Private IdShopify As String
    Private archivoSeleccionado As String

    Private classImagen As cImagenesProductos = New cImagenesProductos()

    Private Sub frmImagenesProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fila = frmListarProductos.tmpRow
        IdShopify = frmListarProductos.gridProductos.Rows(fila).Cells(10).Value.ToString()
        DataGridView1.DataSource = classImagen.ListarImagenes(IdShopify)
        DataGridView1.Columns(1).Width = 150
        DataGridView1.Columns(2).Visible = False

        Dim url = DataGridView1.Rows(0).Cells(2).Value
        PictureBox1.Image = classImagen.mostrarArticulos(url)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        frmListarProductos.ocultarFormulario()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If (e.RowIndex >= 0) Then
            Dim idValor = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
            If (idValor <> "") Then
                'globalIdProducto = gridProductos.Rows(e.RowIndex).Cells(10).Value.ToString
                'tmpRow = e.RowIndex
                If (e.ColumnIndex = 0) Then
                    Dim result As DialogResult = MessageBox.Show("Realmente desea eliminar esta imagen?", "Title", MessageBoxButtons.YesNo)
                    If (result = DialogResult.Yes) Then
                        Dim errores = classImagen.eliminaImagen(IdShopify, idValor)
                        If (errores = "") Then
                            DataGridView1.DataSource = classImagen.ListarImagenes(IdShopify)
                        Else
                            MsgBox(errores, MessageBoxButtons.OK, "Error")
                        End If
                    End If
                ElseIf (e.ColumnIndex = 1) Then
                    Dim url = DataGridView1.Rows(e.RowIndex).Cells(2).Value
                    PictureBox1.Image = classImagen.mostrarArticulos(url)

                End If
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        divSubir.Visible = True
    End Sub

    Private Sub btnFile_Click(sender As Object, e As EventArgs) Handles btnFile.Click
        'Abrimos el cuadro de dialogo
        OpenFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        OpenFileDialog1.Filter = "Picture Files (*)|*.bmp;*.gif;*.jpg" 'Solo archivos csv
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        'Si tenemos un archivo entramos
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            'abimos el archivo y lo guardamos en una variable
            archivoSeleccionado = OpenFileDialog1.FileName
            'Extraemos el nombre del archivo para mostrarlo en el label (dividimos el archivo por el caracter "\")
            Dim testArray() As String = Split(archivoSeleccionado, {"\"c})
            lblFile.Text = testArray(testArray.Length - 1)
            Dim tImage As Bitmap = Bitmap.FromFile(OpenFileDialog1.FileName)
            PictureBox2.Image = tImage


        End If

    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        divSubir.Visible = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (archivoSeleccionado <> "") Then
            Dim imagen As Image = PictureBox2.Image
            Dim valor As String = classImagen.ImageToBase64(imagen, imagen.RawFormat)
            Dim errores = classImagen.guardaArchivo(valor, lblFile.Text)
            If (errores = "") Then
                lblFile.Text = ""
                PictureBox2.Image = Nothing
                DataGridView1.DataSource = classImagen.ListarImagenes(IdShopify)
                Dim url = DataGridView1.Rows(0).Cells(2).Value
                PictureBox1.Image = classImagen.mostrarArticulos(url)
                divSubir.Visible = False
            Else
                MsgBox(errores, MessageBoxButtons.OK, "Error")
            End If
        End If
    End Sub
End Class