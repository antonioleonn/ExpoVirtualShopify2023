Imports System.IO
Imports Classes

Public Class frmInicio

    Public opcion As Integer = 1
    Private idMenuSelect As Integer = 1
    Private tmpForm As Form
    Dim classFile As cServidorPrincipal = New cServidorPrincipal(Path.GetDirectoryName(Application.ExecutablePath))

    Private Sub frmInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        idMenuSelect = 5
        conecta()
    End Sub

    Public Sub conecta()
        If classFile.revisarConeccion("conn.conf") = False Then
            opcion = 0
        Else
            VariablesGlobales.conIp = classFile.host
            VariablesGlobales.conUsr = classFile.user
            VariablesGlobales.conPsw = classFile.pass
        End If
        revisaColor()
    End Sub

    Private Sub revisaColor()
        btnDescargas.BackColor = Color.Transparent
        btnImportarClientes.BackColor = Color.Transparent
        btnListarClientes.BackColor = Color.Transparent
        btnImportarProductos.BackColor = Color.Transparent
        btnListarProductos.BackColor = Color.Transparent
        btnServidores.BackColor = Color.Transparent
        btnTareas.BackColor = Color.Transparent
        btnReportes.BackColor = Color.Transparent
        btnModificarProductos.BackColor = Color.Transparent
        btnLayOuts.BackColor = Color.Transparent
        If idMenuSelect = 1 Then
            btnDescargas.BackColor = Color.FromArgb(120, 218, 169)
        End If
        If idMenuSelect = 2 Then
            btnImportarClientes.BackColor = Color.FromArgb(120, 218, 169)
        End If
        If idMenuSelect = 3 Then
            btnListarClientes.BackColor = Color.FromArgb(120, 218, 169)
        End If
        If idMenuSelect = 4 Then
            btnImportarProductos.BackColor = Color.FromArgb(120, 218, 169)
        End If
        If idMenuSelect = 5 Then
            btnListarProductos.BackColor = Color.FromArgb(120, 218, 169)
        End If
        If idMenuSelect = 6 Then
            btnTareas.BackColor = Color.FromArgb(120, 218, 169)
        End If
        If idMenuSelect = 7 Then
            btnServidores.BackColor = Color.FromArgb(120, 218, 169)
        End If
        If idMenuSelect = 8 Then
            btnReportes.BackColor = Color.FromArgb(120, 218, 169)
        End If
        If idMenuSelect = 9 Then
            btnModificarProductos.BackColor = Color.FromArgb(120, 218, 169)
        End If
        If idMenuSelect = 10 Then
            btnLayOuts.BackColor = Color.FromArgb(120, 218, 169)
        End If
        ifrmMostrar()
    End Sub

    Private Sub ifrmMostrar()
        divCarga.Visible = False
        If tmpForm IsNot Nothing Then
            tmpForm.Close()
            tmpForm = Nothing
        End If
        If opcion = 0 Then
            tmpForm = frmServidorPrincipal
        Else
            If idMenuSelect = 1 Then
                tmpForm = frmPedido
            End If
            If idMenuSelect = 2 Then
                tmpForm = frmImportarClientes
            End If
            If idMenuSelect = 3 Then
                tmpForm = frmListarClientes
            End If
            If idMenuSelect = 4 Then
                tmpForm = frmImportarProductos
            End If
            If idMenuSelect = 5 Then
                tmpForm = frmListarProductos
            End If
            If idMenuSelect = 6 Then
                tmpForm = frmTareas
            End If
            If idMenuSelect = 7 Then
                tmpForm = frmServidoresPedidos
            End If
            If idMenuSelect = 8 Then
                tmpForm = frmReportes
            End If
            If idMenuSelect = 9 Then
                tmpForm = frmEditarListaProductos
            End If
            If idMenuSelect = 10 Then
                tmpForm = frmLayOuts
            End If
        End If
        If tmpForm IsNot Nothing Then
            tmpForm.TopLevel = False
            tmpForm.Dock = DockStyle.Fill
            tmpForm.FormBorderStyle = FormBorderStyle.None
            tmpForm.Show()
            panelPrincipal.Controls.Add(tmpForm)
        End If
    End Sub

    Private Sub btnDescargas_Click(sender As Object, e As EventArgs) Handles btnDescargas.Click
        idMenuSelect = 1
        conecta()
    End Sub

    Private Sub btnReportes_Click(sender As Object, e As EventArgs) Handles btnReportes.Click
        idMenuSelect = 8
        revisaColor()
    End Sub

    Private Sub btnImportarClientes_Click(sender As Object, e As EventArgs) Handles btnImportarClientes.Click
        idMenuSelect = 2
        revisaColor()
    End Sub

    Private Sub btnListarClientes_Click(sender As Object, e As EventArgs) Handles btnListarClientes.Click
        idMenuSelect = 3
        revisaColor()
    End Sub

    Private Sub btnImportarProductos_Click(sender As Object, e As EventArgs) Handles btnImportarProductos.Click
        idMenuSelect = 4
        revisaColor()
    End Sub

    Private Sub btnListarProductos_Click(sender As Object, e As EventArgs) Handles btnListarProductos.Click
        idMenuSelect = 5
        revisaColor()
    End Sub

    Private Sub btnTareas_Click(sender As Object, e As EventArgs) Handles btnTareas.Click
        idMenuSelect = 6
        revisaColor()
    End Sub

    Private Sub btnServidores_Click(sender As Object, e As EventArgs) Handles btnServidores.Click
        idMenuSelect = 7
        revisaColor()
    End Sub

    Public Sub cargaVisible()
        divCarga.Dock = DockStyle.Fill
        divCarga.Visible = True
    End Sub

    Public Sub cargaNoVisible()
        divCarga.Dock = DockStyle.None
        divCarga.Visible = False
    End Sub

    Private Sub btnModificarProductos_Click(sender As Object, e As EventArgs) Handles btnModificarProductos.Click

        idMenuSelect = 9
        revisaColor()
    End Sub

    Private Sub btnLayOuts_Click(sender As Object, e As EventArgs) Handles btnLayOuts.Click

        idMenuSelect = 10
        revisaColor()
    End Sub
End Class
