Imports System.IO
Imports Classes

Public Class frmEditaProducto
    'variables globales del modulo
    Private IdShopify As String
    Private fila As Integer
    Private Encabezado As String
    Private Descripcion As String
    Private Proveedor As String
    Private Sku As String
    Private Empaque As String
    Private Precio As String
    Private Estatus As String
    Private Tags As String


    Private classProd As cEditaProductos = New cEditaProductos(VariablesGlobales.conIp, VariablesGlobales.conUsr, VariablesGlobales.conPsw)
    Private Sub frmEditaProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fila = frmListarProductos.tmpRow
        lblError.Visible = False
        'Cargamos la informacion de la tabla principal (frmListarClientes) a variables que usaremos de comparacion mas adelante
        IdShopify = frmListarProductos.gridProductos.Rows(fila).Cells(10).Value.ToString()
        Sku = frmListarProductos.gridProductos.Rows(fila).Cells(2).Value.ToString()
        Encabezado = frmListarProductos.gridProductos.Rows(fila).Cells(3).Value.ToString()
        Proveedor = frmListarProductos.gridProductos.Rows(fila).Cells(4).Value.ToString()
        Empaque = frmListarProductos.gridProductos.Rows(fila).Cells(5).Value.ToString()
        Precio = frmListarProductos.gridProductos.Rows(fila).Cells(6).Value.ToString()
        Estatus = frmListarProductos.gridProductos.Rows(fila).Cells(7).Value.ToString()
        Descripcion = frmListarProductos.gridProductos.Rows(fila).Cells(9).Value.ToString()
        Tags = frmListarProductos.gridProductos.Rows(fila).Cells(11).Value.ToString()

        'Repetimos mientras exista informacion
        For Each item In classProd.sqlEmpaque(Sku)
            'Agregamos los empaques al combobox
            slcEmpaque.Items.Add(item)
        Next
        'determinamamos si el empaque que tiene esta existe en la BD para ese producto, en caso contrario agregamos la palabra no aplica y la seleccionamos
        Dim idEmpaque = slcEmpaque.Items.IndexOf(Empaque)
        If (idEmpaque < 0) Then
            slcEmpaque.Items.Add("No Aplica")
            idEmpaque = slcEmpaque.Items.Count() - 1
        End If
        slcEmpaque.SelectedIndex = idEmpaque
        'Agregamos Los estatus al combobox 
        slcEstatus.Items.Add("Activo")
        slcEstatus.Items.Add("Borrador")
        txtEncabezado.Text = Encabezado
        txtDescripcion.Text = Descripcion
        txtProveedor.Text = Proveedor
        txtSku.Text = Sku
        txtPrecio.Text = Precio
        slcEstatus.SelectedItem = Estatus
        txtTags.Text = Tags

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        frmListarProductos.ocultarFormulario()
    End Sub

    Private Sub btnGuardaModif_Click(sender As Object, e As EventArgs) Handles btnGuardaModif.Click
        Dim banError = False
        txtEncabezado.BackColor = Color.White
        slcEmpaque.BackColor = Color.White
        lblError.Text = ""
        If (txtEncabezado.Text.Trim = "") Then
            txtEncabezado.BackColor = Color.Yellow
            banError = True
        End If
        If (slcEmpaque.Text.Trim = "No Aplica") Then
            slcEmpaque.BackColor = Color.Yellow
            banError = True
        End If
        If (banError = True) Then
            lblError.Visible = True
            lblError.Text = "Los campos marcados contienen errores"
        Else
            Dim arrayItems As Dictionary(Of String, String) = New Dictionary(Of String, String)()
            arrayItems.Add("slcEmpaque", slcEmpaque.Text)
            arrayItems.Add("slcEstatus", slcEstatus.Text)
            arrayItems.Add("txtEncabezado", txtEncabezado.Text)
            arrayItems.Add("txtDescripcion", txtDescripcion.Text)
            arrayItems.Add("txtProveedor", txtProveedor.Text)
            arrayItems.Add("txtSku", txtSku.Text)
            arrayItems.Add("txtPrecio", txtPrecio.Text)
            arrayItems.Add("txtTags", txtTags.Text)
            arrayItems.Add("IdShopify", IdShopify)
            lblError.Text = classProd.GuardarArticulo(arrayItems)
            If (lblError.Text = "") Then
                'actualizamos la tabla princial
                frmListarProductos.gridProductos.Rows(fila).Cells(2).Value = txtSku.Text
                frmListarProductos.gridProductos.Rows(fila).Cells(3).Value = txtEncabezado.Text
                frmListarProductos.gridProductos.Rows(fila).Cells(4).Value = txtProveedor.Text
                frmListarProductos.gridProductos.Rows(fila).Cells(5).Value = slcEmpaque.Text
                frmListarProductos.gridProductos.Rows(fila).Cells(6).Value = txtPrecio.Text
                frmListarProductos.gridProductos.Rows(fila).Cells(7).Value = slcEstatus.Text
                frmListarProductos.gridProductos.Rows(fila).Cells(8).Value = txtDescripcion.Text
                frmListarProductos.gridProductos.Rows(fila).Cells(11).Value = txtTags.Text
                frmListarProductos.ocultarFormulario()
            Else
                lblError.Visible = True
            End If
        End If
    End Sub


End Class