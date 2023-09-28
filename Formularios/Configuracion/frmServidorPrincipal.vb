Imports System.IO
Imports Classes
Public Class frmServidorPrincipal
    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        If (btnMostrar.IconChar.ToString = "Eye") Then
            btnMostrar.IconChar = FontAwesome.Sharp.IconChar.EyeSlash
            txtPassword.PasswordChar = CChar("")

        ElseIf (btnMostrar.IconChar.ToString = "EyeSlash") Then
            btnMostrar.IconChar = FontAwesome.Sharp.IconChar.Eye
            txtPassword.PasswordChar = CChar("●")
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        'Pintamos el fondo de las cajas de texto, de color blanco
        txtHost.BackColor = Color.FromArgb(255, 255, 255)
        txtUsuario.BackColor = Color.FromArgb(255, 255, 255)
        txtPassword.BackColor = Color.FromArgb(255, 255, 255)

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
        ' si la bandera es 1 entonces mostramos el mensaje de error y terminamos el proceso
        If bandera = 1 Then
            lblError.Visible = True
            Exit Sub
        Else
            Dim classFile As cServidorPrincipal = New cServidorPrincipal(Path.GetDirectoryName(Application.ExecutablePath))
            classFile.guardaConeccion("conn.conf", txtHost.Text, txtUsuario.Text, txtPassword.Text)
            'Refrescamos el apartado de los servidores
            frmInicio.opcion = 1
            frmInicio.conecta()
            Me.Close() 'Cerramos la ventana actual
        End If
    End Sub

    Private Sub frmServidorPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class