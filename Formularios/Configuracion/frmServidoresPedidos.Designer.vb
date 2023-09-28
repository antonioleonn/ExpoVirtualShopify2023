<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServidoresPedidos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gridServidores = New System.Windows.Forms.DataGridView()
        Me.divEdicion = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSubalmacen = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.IconButton1 = New FontAwesome.Sharp.IconButton()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnMostrar = New FontAwesome.Sharp.IconButton()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.lblError = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btnNuevaSucursal = New FontAwesome.Sharp.IconButton()
        Me.colModif = New System.Windows.Forms.DataGridViewImageColumn()
        Me.IdLinea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSubAlmacen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBorrar = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.gridServidores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.divEdicion.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridServidores
        '
        Me.gridServidores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridServidores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridServidores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colModif, Me.IdLinea, Me.colSubAlmacen, Me.Ip, Me.colBorrar})
        Me.gridServidores.Location = New System.Drawing.Point(13, 13)
        Me.gridServidores.Name = "gridServidores"
        Me.gridServidores.Size = New System.Drawing.Size(566, 359)
        Me.gridServidores.TabIndex = 0
        '
        'divEdicion
        '
        Me.divEdicion.Controls.Add(Me.Panel1)
        Me.divEdicion.Location = New System.Drawing.Point(82, 98)
        Me.divEdicion.Name = "divEdicion"
        Me.divEdicion.Size = New System.Drawing.Size(430, 265)
        Me.divEdicion.TabIndex = 2
        Me.divEdicion.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtSubalmacen)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.IconButton1)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.btnMostrar)
        Me.Panel1.Controls.Add(Me.txtPassword)
        Me.Panel1.Controls.Add(Me.txtUsuario)
        Me.Panel1.Controls.Add(Me.txtHost)
        Me.Panel1.Controls.Add(Me.lblError)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(22, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(387, 231)
        Me.Panel1.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(194, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(184, 16)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "(Ejemplo TBC1,ACA1, MAM1)"
        '
        'txtSubalmacen
        '
        Me.txtSubalmacen.Location = New System.Drawing.Point(109, 137)
        Me.txtSubalmacen.Name = "txtSubalmacen"
        Me.txtSubalmacen.Size = New System.Drawing.Size(79, 22)
        Me.txtSubalmacen.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 16)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Sub almacen"
        '
        'IconButton1
        '
        Me.IconButton1.FlatAppearance.BorderSize = 0
        Me.IconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton1.IconChar = FontAwesome.Sharp.IconChar.WindowClose
        Me.IconButton1.IconColor = System.Drawing.Color.IndianRed
        Me.IconButton1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton1.IconSize = 30
        Me.IconButton1.Location = New System.Drawing.Point(351, 3)
        Me.IconButton1.Name = "IconButton1"
        Me.IconButton1.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.IconButton1.Size = New System.Drawing.Size(31, 26)
        Me.IconButton1.TabIndex = 20
        Me.IconButton1.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGuardar.Location = New System.Drawing.Point(91, 199)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(189, 27)
        Me.btnGuardar.TabIndex = 19
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnMostrar
        '
        Me.btnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMostrar.IconChar = FontAwesome.Sharp.IconChar.Eye
        Me.btnMostrar.IconColor = System.Drawing.Color.Black
        Me.btnMostrar.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnMostrar.IconSize = 25
        Me.btnMostrar.Location = New System.Drawing.Point(259, 109)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(40, 22)
        Me.btnMostrar.TabIndex = 18
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(109, 109)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPassword.Size = New System.Drawing.Size(154, 22)
        Me.txtPassword.TabIndex = 17
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(109, 78)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(190, 22)
        Me.txtUsuario.TabIndex = 16
        Me.txtUsuario.Text = "sa"
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(109, 51)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(190, 22)
        Me.txtHost.TabIndex = 15
        Me.txtHost.Text = "localhost"
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.ForeColor = System.Drawing.Color.IndianRed
        Me.lblError.Location = New System.Drawing.Point(110, 175)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(160, 16)
        Me.lblError.TabIndex = 14
        Me.lblError.Text = "Existen datos sin capturar"
        Me.lblError.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Usuario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Host"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(77, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(225, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Ingrese los datos de coneccion"
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.Frozen = True
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = Global.Formularios.My.Resources.Resources.Edit
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Width = 30
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.Frozen = True
        Me.DataGridViewImageColumn2.HeaderText = ""
        Me.DataGridViewImageColumn2.Image = Global.Formularios.My.Resources.Resources.trash_solid_15
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.ReadOnly = True
        Me.DataGridViewImageColumn2.Width = 30
        '
        'btnNuevaSucursal
        '
        Me.btnNuevaSucursal.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnNuevaSucursal.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnNuevaSucursal.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnNuevaSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevaSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevaSucursal.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnNuevaSucursal.IconChar = FontAwesome.Sharp.IconChar.Store
        Me.btnNuevaSucursal.IconColor = System.Drawing.Color.White
        Me.btnNuevaSucursal.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnNuevaSucursal.IconSize = 25
        Me.btnNuevaSucursal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevaSucursal.Location = New System.Drawing.Point(218, 390)
        Me.btnNuevaSucursal.Name = "btnNuevaSucursal"
        Me.btnNuevaSucursal.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnNuevaSucursal.Size = New System.Drawing.Size(157, 37)
        Me.btnNuevaSucursal.TabIndex = 1
        Me.btnNuevaSucursal.Text = "       Nueva sucursal"
        Me.btnNuevaSucursal.UseVisualStyleBackColor = False
        '
        'colModif
        '
        Me.colModif.Frozen = True
        Me.colModif.HeaderText = ""
        Me.colModif.Image = Global.Formularios.My.Resources.Resources.Edit
        Me.colModif.Name = "colModif"
        Me.colModif.ReadOnly = True
        Me.colModif.Width = 30
        '
        'IdLinea
        '
        Me.IdLinea.Frozen = True
        Me.IdLinea.HeaderText = "Id"
        Me.IdLinea.Name = "IdLinea"
        Me.IdLinea.ReadOnly = True
        Me.IdLinea.Width = 35
        '
        'colSubAlmacen
        '
        Me.colSubAlmacen.Frozen = True
        Me.colSubAlmacen.HeaderText = "SubAlmacen"
        Me.colSubAlmacen.Name = "colSubAlmacen"
        Me.colSubAlmacen.ReadOnly = True
        Me.colSubAlmacen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colSubAlmacen.Width = 90
        '
        'Ip
        '
        Me.Ip.Frozen = True
        Me.Ip.HeaderText = "Host"
        Me.Ip.Name = "Ip"
        Me.Ip.ReadOnly = True
        Me.Ip.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Ip.Width = 150
        '
        'colBorrar
        '
        Me.colBorrar.Frozen = True
        Me.colBorrar.HeaderText = ""
        Me.colBorrar.Image = Global.Formularios.My.Resources.Resources.trash_solid_15
        Me.colBorrar.Name = "colBorrar"
        Me.colBorrar.ReadOnly = True
        Me.colBorrar.Width = 30
        '
        'frmServidoresPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(591, 439)
        Me.Controls.Add(Me.divEdicion)
        Me.Controls.Add(Me.btnNuevaSucursal)
        Me.Controls.Add(Me.gridServidores)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmServidoresPedidos"
        Me.Text = "frmServidoresPedidos"
        CType(Me.gridServidores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.divEdicion.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gridServidores As DataGridView
    Friend WithEvents btnNuevaSucursal As FontAwesome.Sharp.IconButton
    Friend WithEvents divEdicion As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnMostrar As FontAwesome.Sharp.IconButton
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtHost As TextBox
    Friend WithEvents lblError As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSubalmacen As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
    Friend WithEvents colModif As DataGridViewImageColumn
    Friend WithEvents IdLinea As DataGridViewTextBoxColumn
    Friend WithEvents colSubAlmacen As DataGridViewTextBoxColumn
    Friend WithEvents Ip As DataGridViewTextBoxColumn
    Friend WithEvents colBorrar As DataGridViewImageColumn
End Class
