Imports System.IO
Imports Classes
Public Class frmEditaCliente
    'variables globales del modulo
    Private fila As Integer
    Private IdMerksyst As String
    Private Nombre As String
    Private Apellido As String
    Private Correo As String
    Private Telefono As String
    Private idShopify As String
    Private Tags As String
    Private ModificaSucursales As String = False

    Private classCte As cEditaCliente = New cEditaCliente(VariablesGlobales.conIp, VariablesGlobales.conUsr, VariablesGlobales.conPsw)
    Private Sub frmEditaCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fila = frmListarClientes._tmpRow
        Dim tmpPath = Path.GetDirectoryName(Application.ExecutablePath)
        'Cargamos la informacion de la tabla principal (frmListarClientes) a variables que usaremos de comparacion mas adelante
        IdMerksyst = frmListarClientes.DataGridView1.Rows(fila).Cells(2).Value.ToString()
        Nombre = frmListarClientes.DataGridView1.Rows(fila).Cells(3).Value.ToString()
        Apellido = frmListarClientes.DataGridView1.Rows(fila).Cells(4).Value.ToString()
        Correo = frmListarClientes.DataGridView1.Rows(fila).Cells(5).Value.ToString()
        Telefono = frmListarClientes.DataGridView1.Rows(fila).Cells(6).Value.ToString()
        Tags = frmListarClientes.DataGridView1.Rows(fila).Cells(9).Value.ToString()
        idShopify = frmListarClientes._IdCliente
        ' Pasamos la informacion a cada cuadro de texto
        txtIdMerksyst.Text = IdMerksyst
        txtNombre.Text = Nombre
        txtApellido.Text = Apellido
        txtCorreo.Text = Correo
        txtTelefono.Text = Telefono
        txtTags.Text = Tags
        Dim subalmacen = ""
        Dim tableData = classCte.sqlClienteAlternativo(idShopify)
        For Each item As DataRow In tableData.Rows
            gridSucursales.Rows.Add(Nothing, item.ItemArray(0), item.ItemArray(1))
        Next
        'Llenamos el combo box de la sucursal con los valores que el archivo de sucursales
        Dim classHost As cServidoresSecundarios = New cServidoresSecundarios(tmpPath)
        For Each item In classHost.leerArchivo()
            'For Each item In archivos.AcualizarLista()
            'Dim arrayCelda() As String = item.Split(Convert.ToChar(Keys.Tab))
            'subalmacen = encripta.DecodeBase64ToString(arrayCelda(3))
            slcSucursal.Items.Add(classHost.DecodeBase64ToString(item.sAlmacen))
        Next
        slcSucursal.Sorted = True
        'Si existen almacenes, pone la primer sucursal por default
        If (subalmacen <> "") Then
            slcSucursal.SelectedIndex = 0
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        frmListarClientes.ocultarFormulario()
    End Sub

    Private Sub btnNuevaSucursal_Click(sender As Object, e As EventArgs) Handles btnNuevaSucursal.Click
        gpoSucursal.Visible = True
    End Sub

    Private Sub btnCerrarSucursal_Click(sender As Object, e As EventArgs) Handles btnCerrarSucursal.Click
        gpoSucursal.Visible = False
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        Dim banError = False
        'regresamos las cajas de texto a su color original
        txtMerksyst.BackColor = Color.White
        'Revisamos qyue esten los datos principales
        If (txtMerksyst.Text.Trim = "") Then
            txtMerksyst.BackColor = Color.Yellow
            banError = True
        End If
        'si se llenaron los datos agrega una fila en la tabla de sucursales
        If (banError = False) Then
            ModificaSucursales = True
            gridSucursales.Rows.Add(Nothing, txtMerksyst.Text.Trim, slcSucursal.Text.Trim)
            gpoSucursal.Visible = False
        End If
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Dim banMerksyst = False
        Dim banWeb = False
        'regresamos las cajas de texto a su color original
        txtIdMerksyst.BackColor = Color.White
        txtCorreo.BackColor = Color.White
        txtTelefono.BackColor = Color.White
        txtNombre.BackColor = Color.White
        lblError.Text = ""
        'Revisamos qyue esten los datos principales, en caso contrario aborta
        If (txtTelefono.Text.Trim = "") And (txtCorreo.Text.Trim = "") Then
            txtCorreo.BackColor = Color.Yellow
            txtTelefono.BackColor = Color.Yellow
            lblError.Text = lblError.Text + " Se requiere el telefono o el correo."
        End If
        If (txtNombre.Text.Trim = "") Then
            txtNombre.BackColor = Color.Yellow
            lblError.Text = lblError.Text + " Se requiere el nombre."
        End If
        If (txtIdMerksyst.Text.Trim = "") Then
            txtIdMerksyst.BackColor = Color.Yellow
            lblError.Text = lblError.Text + " Se requiere el id de Merksyst."
        End If
        If (lblError.Text = "") Then
            'Revisamos si existe algun cambio comparando las variables iniciales con la caja de texto
            If (txtIdMerksyst.Text <> IdMerksyst) Then
                banMerksyst = True
                banWeb = True
            End If
            If (txtNombre.Text <> Nombre) Then
                banWeb = True
            End If
            If (txtApellido.Text <> Apellido) Then
                banWeb = True
            End If
            If (txtCorreo.Text <> Correo) Then
                banWeb = True
            End If
            If (txtTelefono.Text <> Telefono) Then
                banWeb = True
            End If
            If (txtTags.Text <> Tags) Then
                banWeb = True
            End If
            If (banWeb = True) Then
                Dim arrayDatos = New Dictionary(Of String, String)
                arrayDatos.Add("idShopify", idShopify)
                arrayDatos.Add("txtIdMerksyst", txtIdMerksyst.Text)
                arrayDatos.Add("txtNombre", txtNombre.Text)
                arrayDatos.Add("txtApellido", txtApellido.Text)
                arrayDatos.Add("txtCorreo", txtCorreo.Text)
                arrayDatos.Add("txtTelefono", txtTelefono.Text)
                arrayDatos.Add("txtTags", txtTags.Text)

                lblError.Text = classCte.updateClienteShopify(arrayDatos)
                If (banMerksyst = True) And (lblError.Text = "") Then
                    lblError.Text = classCte.updateClienteMerksyst(arrayDatos)
                End If
            End If
        End If

        'si no existen errores entra y si se realizaron cambios en las sucursales entra
        If (lblError.Text = "" And ModificaSucursales = True) Then
            'Borramos las sucursales asignadas al cliente (0), para posteriormente llenar de la tabla
            Dim respuesta = classCte.actualizaSucursales(idShopify, 0, "", "")
            'Repite por cada fila
            For Each row As DataGridViewRow In gridSucursales.Rows
                'Si no se recibe error al hacer la operacion en las sucursales entra
                If (respuesta = "") Then
                    'asignamos el valor del id de merksyst a una variable y revisamos que no este vacia
                    Dim valorSub1 = row.Cells(1).Value
                    If (Not (IsNothing(valorSub1))) Then
                        'Insertamos la nueva fila en la BD (1)
                        respuesta = classCte.actualizaSucursales(idShopify, 1, row.Cells(1).Value, row.Cells(2).Value)
                        lblError.Text = respuesta
                    End If
                End If
            Next
        End If
        If (lblError.Text = "") Then
            frmListarClientes.ocultarFormulario()
        End If
    End Sub

    Private Sub gridSucursales_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridSucursales.CellClick
        'Revisamos que el click no se haya realizado en la cabecera
        If (e.RowIndex >= 0) Then
            'si la celda tiene  valor entra
            If (gridSucursales.Rows(e.RowIndex).Cells(1).Value <> Nothing) Then
                'Si la coluna donce se dio el clic es la 0, borra la fila completa donde se preciono
                If (e.ColumnIndex = 0) Then
                    ModificaSucursales = True
                    gridSucursales.Rows.Remove(gridSucursales.Rows(e.RowIndex))
                End If
            End If
        End If
    End Sub
End Class