Imports Classes

Public Class frmEditarListaProductos
    Dim archivoSeleccionado As String

    Dim classPedido As cEditarListaProductos = New cEditarListaProductos(VariablesGlobales.conIp, VariablesGlobales.conUsr, VariablesGlobales.conPsw)
    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        OpenFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        OpenFileDialog1.Filter = "CSV files | *.csv" 'Solo archivos csv
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.RestoreDirectory = True
        'Si tenemos un archivo entramos
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            'Limpiamos la tabla
            'DataGridView1Clear()
            'abimos el archivo y lo guardamos en una variable
            archivoSeleccionado = OpenFileDialog1.FileName
            'Extraemos el nombre del archivo para mostrarlo en el label (dividimos el archivo por el caracter "\")

            Dim testArray() As String = Split(archivoSeleccionado, {"\"c})
            lblFile.Text = testArray(testArray.Length - 1)

            frmInicio.cargaVisible()
            Dim tmpCargar = New Task(AddressOf cargarArchivo)
            tmpCargar.Start()
        End If
    End Sub

    Private Sub cargarArchivo()
        Me.Invoke(Sub()
                      DataGridView1.DataSource = classPedido.listarArticulos(archivoSeleccionado)
                      'Oculta titulo
                      DataGridView1.Columns(3).Visible = CheckedListBox1.GetItemChecked(0)
                      'Oculta Descripcion
                      DataGridView1.Columns(4).Visible = CheckedListBox1.GetItemChecked(1)
                      'Oculta Precio
                      DataGridView1.Columns(5).Visible = CheckedListBox1.GetItemChecked(2)
                      'Oculta Empaque y las Observaciones del mismo
                      DataGridView1.Columns(6).Visible = CheckedListBox1.GetItemChecked(3) 'empaque
                      DataGridView1.Columns(8).Visible = CheckedListBox1.GetItemChecked(3) 'Observaciones
                      'Oculta Etiquetas
                      DataGridView1.Columns(7).Visible = CheckedListBox1.GetItemChecked(4)

                      frmInicio.cargaNoVisible()
                  End Sub)
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        frmInicio.cargaVisible()
        Dim tmpEnviar = New Task(AddressOf guardaShopify)
        tmpEnviar.Start()
    End Sub

    Private Sub guardaShopify()
        If (archivoSeleccionado <> "") Then
            Dim tmpBan = False
            Dim tmpBanEmpaque = False
            Dim tmpTxtEstatus = ""
            Me.Invoke(Sub()
                          tmpTxtEstatus = txtEstatus.SelectedItem.ToString
                      End Sub)
            'si cambia el titulo entra
            If (DataGridView1.Columns(3).Visible = True) Then
                tmpBan = True
            End If
            'si cambia la descripcion entra
            If (DataGridView1.Columns(4).Visible = True) Then
                tmpBan = True
            End If
            'si cambia la Precio entra
            If (DataGridView1.Columns(5).Visible = True) Then
                tmpBan = True
            End If
            'si cambia la Empaque entra
            If (DataGridView1.Columns(6).Visible = True) Then
                tmpBan = True
                tmpBanEmpaque = True
            End If
            'si cambia la Etiquetas entra
            If (tmpTxtEstatus <> "Sin cambios") Then
                tmpBan = True
            End If
            'si cambia el estatus Entra


            If tmpBan = True Then
                For Each data As DataGridViewRow In DataGridView1.Rows
                    Dim enviaInformacion = True
                    If (tmpBanEmpaque = True) Then
                        If (data.Cells("Observacion").Value <> "") Then
                            enviaInformacion = False
                        End If
                    End If


                    Dim lstEstatus As Dictionary(Of String, String) = New Dictionary(Of String, String)()
                    lstEstatus.Add("guardaTitulo", CheckedListBox1.GetItemChecked(0))
                    lstEstatus.Add("guardaDescripcion", CheckedListBox1.GetItemChecked(1))
                    lstEstatus.Add("guardaPrecio", CheckedListBox1.GetItemChecked(2))
                    lstEstatus.Add("guardaEmpaque", CheckedListBox1.GetItemChecked(3))
                    lstEstatus.Add("guardaEtiqueta", CheckedListBox1.GetItemChecked(4))
                    Me.Invoke(Sub()
                                  lstEstatus.Add("Estatus", txtEstatus.SelectedItem.ToString)
                              End Sub)
                    If (enviaInformacion = True) Then
                        Dim arrayError = classPedido.enviaShopify(data, lstEstatus)
                        'Extraemos la informacion de array Error, 
                        For Each item In arrayError
                            'Si existe error cambimos el icono y escribimos en la tabla de error
                            If (item.Value <> "") Then
                                Me.Invoke(Sub()
                                              data.Cells("icon").Value = Formularios.My.Resources.Resources.window_close_regular
                                              data.Cells("Errores").Value = item.Value
                                          End Sub)
                            Else
                                'Si no existe error cambimos el icono y establecemos el valor del id de shopify 
                                Me.Invoke(Sub()
                                              data.Cells("icon").Value = Formularios.My.Resources.Resources.check_solid
                                              data.Cells("Errores").Value = ""
                                          End Sub)
                            End If
                        Next
                    Else
                        Me.Invoke(Sub()
                                      data.Cells("icon").Value = Formularios.My.Resources.Resources.window_close_regular
                                      data.Cells("Errores").Value = "Error en el empaque"
                                  End Sub)
                    End If
                    Me.Invoke(Sub()
                                  frmInicio.cargaNoVisible()
                              End Sub)
                Next
            End If
        End If
        Me.Invoke(Sub()
                      frmInicio.cargaNoVisible()
                  End Sub)
    End Sub

    Private Sub frmEditarListaProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckedListBox1.SetItemChecked(0, True)
        CheckedListBox1.SetItemChecked(1, True)
        CheckedListBox1.SetItemChecked(2, True)
        CheckedListBox1.SetItemChecked(3, True)
        CheckedListBox1.SetItemChecked(4, True)

        txtEstatus.SelectedIndex = 0
    End Sub

    Private Sub CheckedListBox1_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles CheckedListBox1.ItemCheck
        Try
            If (e.Index = 0) Then
                DataGridView1.Columns(3).Visible = e.NewValue
            ElseIf (e.Index = 1) Then
                DataGridView1.Columns(4).Visible = e.NewValue
            ElseIf (e.Index = 2) Then
                DataGridView1.Columns(5).Visible = e.NewValue
            ElseIf (e.Index = 3) Then
                DataGridView1.Columns(6).Visible = e.NewValue
                DataGridView1.Columns(8).Visible = e.NewValue
            ElseIf (e.Index = 4) Then
                DataGridView1.Columns(7).Visible = e.NewValue
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class