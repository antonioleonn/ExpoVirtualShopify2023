
Imports System.IO
Imports Classes

Public Class frmImportarProductos

    'Variables que usaremos en todo el sistema 
    Private archivoSeleccionado As String
    Private MaxFilas As Integer = 0
    Private fila As Integer = 0
    Private classProd As cImportarProductos = New cImportarProductos(VariablesGlobales.conIp, VariablesGlobales.conUsr, VariablesGlobales.conPsw)

    Private Sub btnFile_Click(sender As Object, e As EventArgs) Handles btnFile.Click
        'Abrimos el cuadro de dialogo
        OpenFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        OpenFileDialog1.Filter = "CSV files | *.csv" 'Solo archivos csv
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        'Si tenemos un archivo entramos
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            'abimos el archivo y lo guardamos en una variable
            archivoSeleccionado = OpenFileDialog1.FileName
            'Extraemos el nombre del archivo para mostrarlo en el label (dividimos el archivo por el caracter "\")
            Dim testArray() As String = Split(archivoSeleccionado, {"\"c})
            lblFile.Text = testArray(testArray.Length - 1)

            Dim blank As Image = Formularios.My.Resources.Resources.blank
            Dim arrayTables = classProd.cargarArchivo(archivoSeleccionado, blank)

            DataGridView1.DataSource = arrayTables(0)
            gridErrores.DataSource = arrayTables(1)
            DataGridView1.Columns(0).Width = 35
            gridErrores.Columns(1).Width = gridErrores.Width - 100
            'Incrementamos el contador de la fila, y lo mostramos 
            lblTotal.Text = "Total de filas procesadas: 0 / " + MaxFilas.ToString()
        End If
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        fila = 0
        'llamamos al metodo de enviar
        frmInicio.cargaVisible()
        Dim tmpEnviar = New Task(AddressOf Enviar)
        tmpEnviar.Start()
    End Sub

    Private Function Enviar()
        Dim fila As Integer = 0
        If (archivoSeleccionado <> "") Then
            Dim iconE As Image = Formularios.My.Resources.Resources.window_close_regular
            Dim iconB As Image = Formularios.My.Resources.Resources.check_solid
            Dim arrayTables = classProd.guardaShopify(iconE, iconB)
            Me.Invoke(Sub()
                          DataGridView1.DataSource = arrayTables(0)
                          gridErrores.DataSource = arrayTables(1)
                          gridErrores.Columns(1).Width = gridErrores.Width - 100
                      End Sub)

        End If
        ' al terminar ocultamos el icono de carga
        Me.Invoke(Sub()
                      frmInicio.cargaNoVisible()
                  End Sub)
        Return False
    End Function
End Class