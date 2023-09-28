
Imports System.IO
Imports Classes
Public Class frmImportarClientes


    Private archivoSeleccionado As String
    Private MaxFilas As Integer = 0
    Private classCte As cImportarClientes = New cImportarClientes(VariablesGlobales.conIp, VariablesGlobales.conUsr, VariablesGlobales.conPsw)

    Private Sub btnFile_Click(sender As Object, e As EventArgs) Handles btnFile.Click
        'Cambiamos el boton de csv a invisible
        btnCSV.Visible = False
        'Abrimos el cuadro de dialogo
        OpenFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        OpenFileDialog1.Filter = "CSV files | *.csv" 'Solo archivos csv
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        'Si tenemos un archivo entramos
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            'Limpiamos la tabla
            DataGridView1.DataSource = Nothing
            'abimos el archivo y lo guardamos en una variable
            archivoSeleccionado = OpenFileDialog1.FileName
            'Extraemos el nombre del archivo para mostrarlo en el label (dividimos el archivo por el caracter "\")
            Dim testArray() As String = Split(archivoSeleccionado, {"\"c})
            lblFile.Text = testArray(testArray.Length - 1)
            Dim userA As Image = Formularios.My.Resources.Resources.Alternativo
            Dim blank As Image = Formularios.My.Resources.Resources.blank
            Dim userD As Image = Formularios.My.Resources.Resources.Duplicado
            Dim arrayTables = classCte.cargarArchivo(archivoSeleccionado, userD, userA, blank)
            DataGridView1.DataSource = arrayTables(0)
            gridErrores.DataSource = arrayTables(1)
            DataGridView1.Columns(0).Width = 35
            gridErrores.Columns(1).Width = gridErrores.Width - 100
            'Incrementamos el contador de la fila, y lo mostramos 
            lblTotal.Text = "Total de filas procesadas: 0 / " + MaxFilas.ToString()
            'DataGridView1.ReadOnly = True
        End If
    End Sub

    Private Sub frmImportarClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        'llamamos al metodo de enviar
        frmInicio.cargaVisible()
        gridErrores.DataSource = Nothing
        Dim tmpEnviar = New Task(AddressOf Enviar)
        tmpEnviar.Start()
    End Sub

    Private Sub Enviar()
        If (archivoSeleccionado <> "") Then

            Dim iconE As Image = Formularios.My.Resources.Resources.window_close_regular
            Dim iconB As Image = Formularios.My.Resources.Resources.check_solid
            Dim arrayTables = classCte.guardaShopify(iconE, iconB)
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
    End Sub
End Class