Imports System.IO
Imports Classes
Public Class frmCambiarPassword


    Private classCte As cEditaPassword = New cEditaPassword()

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        If (txtPass.Text.Trim() <> "") Then
            txtPass.BackColor = Color.White
            Dim result = classCte.guardaPassword(txtPass.Text, frmListarClientes._IdCliente)
            If (result <> "") Then
                frmListarClientes.ocultarFormulario()
            Else
                MsgBox(result, MsgBoxStyle.Critical, "Error")
            End If
        Else
                txtPass.BackColor = Color.LightYellow
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        frmListarClientes.ocultarFormulario()
    End Sub

End Class