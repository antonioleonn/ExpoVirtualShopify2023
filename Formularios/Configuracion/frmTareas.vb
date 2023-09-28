Imports System.IO
Imports Classes

Public Class frmTareas

    Dim classTareas As cTareas = New cTareas(Path.GetDirectoryName(Application.ExecutablePath))

    Private Sub frmTareas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarServidores()
        Dim maxFila = 0
        GroupBox1.Enabled = False
        For Each Linea As String In classTareas.leerAutomatico
            If (maxFila = 0) Then
                If (Linea = "True") Then
                    chkAutomatico.Checked = True
                    GroupBox1.Enabled = True
                End If
            ElseIf (maxFila = 1) Then
                If (Linea <> "") Then
                    txtMinutos.Text = Linea
                End If
            ElseIf (maxFila = 2) Then
                If (Linea <> "") Then
                    Dim arrayDia() As String = Linea.Split(Convert.ToChar(Keys.Tab))
                    For Each dia As String In arrayDia
                        If (dia = "0") Then chkDia0.Checked = True
                        If (dia = "1") Then chkDia1.Checked = True
                        If (dia = "2") Then chkDia2.Checked = True
                        If (dia = "3") Then chkDia3.Checked = True
                        If (dia = "4") Then chkDia4.Checked = True
                        If (dia = "5") Then chkDia5.Checked = True
                        If (dia = "6") Then chkDia6.Checked = True
                    Next
                End If

            ElseIf (maxFila = 3) Then
                If (Linea <> "") Then
                    Dim arrayServer() As String = Linea.Split(Convert.ToChar(Keys.Tab))
                    Dim tmpMaxfila = 0
                    Dim tmpFila = 0
                    For Each chk As CheckBox In Panel1.Controls.OfType(Of CheckBox)
                        For Each server As String In arrayServer
                            If (server.ToLower = chk.Text.ToLower) Then
                                chk.Checked = True
                                tmpFila = tmpFila + 1
                                Exit For
                            End If
                        Next
                        tmpMaxfila = tmpMaxfila + 1
                    Next
                    If (tmpMaxfila = tmpFila) Then
                        chkSucusrales.Text = "Desmarcar todo"
                        chkSucusrales.Checked = True
                    End If
                End If


            End If
            maxFila = maxFila + 1
        Next
    End Sub

    Private Sub cargarServidores()
        'Declaramos las variables
        Dim x1 = 0
        Dim idElemento = 1
        Dim classHost As cServidoresSecundarios = New cServidoresSecundarios(Path.GetDirectoryName(Application.ExecutablePath))


        Dim listServidores = classHost.leerArchivo()
        Dim arrayServidores As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()
        'Ordenamos lo servidores 
        For Each item In listServidores
            arrayServidores.Add(classHost.DecodeBase64ToString(item.sAlmacen), item)
        Next
        arrayServidores = arrayServidores.OrderBy(Function(x) x.Key).ToDictionary(Function(x) x.Key, Function(x) x.Value)

        'recorremos la lista por cada linea obtenida del paso anterior
        For Each item In arrayServidores
            Dim dynamicCheck As New CheckBox
            'Convertimos la linea en un array separando cada item por el carater "TAB" 
            Dim subalmacen = item.Key
            'Guardamos la informacion de los servidores para usarla despues
            'listaServisores.Add(subalmacen, item)
            ' Definimos la distancia a mostrar de cada linea (x,y) 
            dynamicCheck.Location = New Point(20, x1)
            ' Asignamos los nombres de cada elemento
            dynamicCheck.Name = "chkServer_" + idElemento.ToString
            ' Asignamos el tamaño (ancho y alto)
            dynamicCheck.Width = 81
            dynamicCheck.Height = 25
            ' Asignamos el texto 
            dynamicCheck.Text = subalmacen
            'Agregamos los elementos al panel 
            Panel1.Controls.Add(dynamicCheck)
            'Declaramos la propiedad onclick  
            x1 = x1 + 25
            idElemento = idElemento + 1
        Next
    End Sub
    Private Sub chkAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutomatico.CheckedChanged
        If (chkAutomatico.Checked = True) Then
            GroupBox1.Enabled = True
        Else
            GroupBox1.Enabled = False
        End If
    End Sub

    Private Sub txtMinutos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMinutos.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            If (Not Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub chkSucusrales_CheckedChanged(sender As Object, e As EventArgs) Handles chkSucusrales.CheckedChanged

        If (chkSucusrales.Checked = True) Then
            chkSucusrales.Text = "Desmarcar todo"
            For Each chk As CheckBox In Panel1.Controls.OfType(Of CheckBox)
                Dim arrayNombre = chk.Name.Split("_")
                If (arrayNombre(0) = "chkServer") Then
                    chk.Checked = True
                End If
            Next

        Else
            chkSucusrales.Text = "Marcar todo"
            For Each chk As CheckBox In Panel1.Controls.OfType(Of CheckBox)
                Dim arrayNombre = chk.Name.Split("_")
                If (arrayNombre(0) = "chkServer") Then
                    chk.Checked = False
                End If
            Next
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim Data = ""
        Data = Data + chkAutomatico.Checked.ToString() + Convert.ToChar(Keys.Enter)
        Data = Data + txtMinutos.Text + Convert.ToChar(Keys.Enter)
        If (chkDia0.Checked = True) Then
            Data = Data + "0" + Convert.ToChar(Keys.Tab)
        End If
        If (chkDia1.Checked = True) Then
            Data = Data + "1" + Convert.ToChar(Keys.Tab)
        End If
        If (chkDia2.Checked = True) Then
            Data = Data + "2" + Convert.ToChar(Keys.Tab)
        End If
        If (chkDia3.Checked = True) Then
            Data = Data + "3" + Convert.ToChar(Keys.Tab)
        End If
        If (chkDia4.Checked = True) Then
            Data = Data + "4" + Convert.ToChar(Keys.Tab)
        End If
        If (chkDia5.Checked = True) Then
            Data = Data + "5" + Convert.ToChar(Keys.Tab)
        End If
        If (chkDia6.Checked = True) Then
            Data = Data + "6" + Convert.ToChar(Keys.Tab)
        End If
        Data = Data + Convert.ToChar(Keys.Enter)
        Dim DataChk = ""
        For Each chk As CheckBox In Panel1.Controls.OfType(Of CheckBox)
            Dim arrayNombre = chk.Name.Split("_")
            Dim IdBusca = arrayNombre(1)
            If (arrayNombre(0) = "chkServer") Then
                If chk.Checked = True Then
                    DataChk = DataChk + chk.Text + Convert.ToChar(Keys.Tab)
                End If
            End If
        Next
        Data = Data + DataChk
        Data = Data + Convert.ToChar(Keys.Enter)
        MsgBox(classTareas.GuardarAutomatico(Data))
    End Sub
End Class