Imports System.IO
Imports Classes
Public Class frmServidoresPedidos
    'Declaramos las variables
    Dim ListServidores As List(Of String)
    Dim movimiento
    Dim idSeleccion = 0

    Dim classHost As cServidoresSecundarios = New cServidoresSecundarios(Path.GetDirectoryName(Application.ExecutablePath))
    Private Sub frmServidoresPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Llenamos la tabla
        llenarGrid()
    End Sub

    Private Sub btnNuevaSucursal_Click(sender As Object, e As EventArgs) Handles btnNuevaSucursal.Click
        ' indicamos que el movimiento va a se alta
        movimiento = "ALTA"
        abrirEdicion("localhost", "sa", "")
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        'Cambiamos la forma de mostrar el password ya sea oculto o normal
        If (btnMostrar.IconChar.ToString = "Eye") Then
            btnMostrar.IconChar = FontAwesome.Sharp.IconChar.EyeSlash
            txtPassword.PasswordChar = ""
        ElseIf (btnMostrar.IconChar.ToString = "EyeSlash") Then
            btnMostrar.IconChar = FontAwesome.Sharp.IconChar.Eye
            txtPassword.PasswordChar = "●"
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            'Pintamos el fondo de las cajas de texto, de color blanco
            txtHost.BackColor = Color.FromArgb(255, 255, 255)
            txtUsuario.BackColor = Color.FromArgb(255, 255, 255)
            txtPassword.BackColor = Color.FromArgb(255, 255, 255)
            txtSubalmacen.BackColor = Color.FromArgb(255, 255, 255)

            lblError.Visible = False ' Escondemos el mensaje de error
            Dim bandera = 0 'Convertimos la bandera de error a 0

            'si la textbox de host viene vacio lo pintamos de color amarillo y cambiamos la bandera a 1
            If (txtHost.Text = "") Then
                txtHost.BackColor = Color.FromArgb(250, 249, 205)
                bandera = 1
            End If
            'si la textbox de usuario viene vacio lo pintamos de color amarillo y cambiamos la bandera a 1
            If (txtUsuario.Text = "") Then
                txtUsuario.BackColor = Color.FromArgb(250, 249, 205)
                bandera = 1
            End If
            'si la textbox de sucursal viene vacio lo pintamos de color amarillo y cambiamos la bandera a 1
            If (txtSubalmacen.Text = "") Then
                txtSubalmacen.BackColor = Color.FromArgb(250, 249, 205)
                bandera = 1
            End If
            ' si la bandera es 1 entonces mostramos el mensaje de error y terminamos el proceso
            If bandera = 1 Then
                lblError.Visible = True
                Exit Sub
            Else
                'Almacenamos la informacion en las variables de la clase
                classHost.host = classHost.EncodeStrToBase64(txtHost.Text)
                classHost.user = classHost.EncodeStrToBase64(txtUsuario.Text)
                classHost.pass = classHost.EncodeStrToBase64(txtPassword.Text)
                classHost.sAlmacen = classHost.EncodeStrToBase64(txtSubalmacen.Text)

                'Mandamos llamar a la funcion que guarda
                classHost.guardarCambios(movimiento, idSeleccion)

                'Cerramos el cuadro de edicion
                divEdicion.Visible = False
                llenarGrid() 'actualizamos la Grid 

            End If
        Catch ex As Exception
            MsgBox("Error: " + ex.Message)
        End Try
    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        'ocultamos el cuadro de texto
        divEdicion.Visible = False
    End Sub


    Private Sub gridServidores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridServidores.CellContentClick
        Dim maxFila = gridServidores.Rows.Count - 1
        If (e.RowIndex >= 0) And (e.RowIndex < maxFila) Then
            idSeleccion = gridServidores.Rows(e.RowIndex).Cells(1).Value - 1
            If (gridServidores.Rows(e.RowIndex).Cells(2).Value.ToString <> "") Then
                Dim item = classHost.ListServidores(idSeleccion)
                If (e.ColumnIndex = 0) Then
                    movimiento = "MODIFICACION"
                    abrirEdicion(classHost.DecodeBase64ToString(item.host), classHost.DecodeBase64ToString(item.user), classHost.DecodeBase64ToString(item.sAlmacen))
                End If
                If (e.ColumnIndex = 4) Then
                    Dim resultado = MsgBox("Realmente desea eliminar esta sucursal (" + classHost.DecodeBase64ToString(item.sAlmacen) + ") ?", MsgBoxStyle.YesNo, "Borrar")
                    If resultado = vbYes Then
                        movimiento = "BORRAR"
                        'Mandamos llamar a la funcion que guarda
                        classHost.guardarCambios(movimiento, idSeleccion)
                        llenarGrid()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub abrirEdicion(host, usuario, subalmacen)
        'Ponemos los campos en sus valores por default 
        txtHost.Text = host
        txtUsuario.Text = usuario
        txtPassword.Text = ""
        txtSubalmacen.Text = subalmacen
        'Mostramos la ventana de captura
        divEdicion.Dock = Dock.Fill
        divEdicion.Visible = True
    End Sub

    Private Sub llenarGrid()
        Dim fila = 1
        gridServidores.Rows.Clear() ' Limpiamos la tabla
        'Recorremos por cada item guardado en la tabla

        For Each item In classHost.leerArchivo()
            gridServidores.Rows.Add(Nothing, fila, classHost.DecodeBase64ToString(item.sAlmacen), classHost.DecodeBase64ToString(item.host), Nothing)
            fila = fila + 1
        Next
    End Sub
End Class