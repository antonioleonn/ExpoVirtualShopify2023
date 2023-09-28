<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditaCliente
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTags = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblError = New System.Windows.Forms.Label()
        Me.gpoSucursal = New System.Windows.Forms.GroupBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.slcSucursal = New System.Windows.Forms.ComboBox()
        Me.txtMerksyst = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCerrarSucursal = New FontAwesome.Sharp.IconButton()
        Me.btnNuevaSucursal = New FontAwesome.Sharp.IconButton()
        Me.gridSucursales = New System.Windows.Forms.DataGridView()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.txtApellido = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtIdMerksyst = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.btnCerrar = New FontAwesome.Sharp.IconButton()
        Me.borrar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colMerksyst = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.gpoSucursal.SuspendLayout()
        CType(Me.gridSucursales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.Controls.Add(Me.txtTags)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblError)
        Me.GroupBox1.Controls.Add(Me.gpoSucursal)
        Me.GroupBox1.Controls.Add(Me.btnNuevaSucursal)
        Me.GroupBox1.Controls.Add(Me.gridSucursales)
        Me.GroupBox1.Controls.Add(Me.txtTelefono)
        Me.GroupBox1.Controls.Add(Me.txtCorreo)
        Me.GroupBox1.Controls.Add(Me.txtApellido)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Controls.Add(Me.txtIdMerksyst)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnEnviar)
        Me.GroupBox1.Controls.Add(Me.btnCerrar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(481, 430)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtTags
        '
        Me.txtTags.Location = New System.Drawing.Point(12, 264)
        Me.txtTags.Multiline = True
        Me.txtTags.Name = "txtTags"
        Me.txtTags.Size = New System.Drawing.Size(210, 58)
        Me.txtTags.TabIndex = 35
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 244)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Tags"
        '
        'lblError
        '
        Me.lblError.Location = New System.Drawing.Point(12, 337)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(456, 36)
        Me.lblError.TabIndex = 33
        Me.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gpoSucursal
        '
        Me.gpoSucursal.Controls.Add(Me.btnAgregar)
        Me.gpoSucursal.Controls.Add(Me.slcSucursal)
        Me.gpoSucursal.Controls.Add(Me.txtMerksyst)
        Me.gpoSucursal.Controls.Add(Me.Label7)
        Me.gpoSucursal.Controls.Add(Me.Label6)
        Me.gpoSucursal.Controls.Add(Me.btnCerrarSucursal)
        Me.gpoSucursal.Location = New System.Drawing.Point(105, 108)
        Me.gpoSucursal.Name = "gpoSucursal"
        Me.gpoSucursal.Size = New System.Drawing.Size(295, 152)
        Me.gpoSucursal.TabIndex = 32
        Me.gpoSucursal.TabStop = False
        Me.gpoSucursal.Visible = False
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnAgregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnAgregar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAgregar.Location = New System.Drawing.Point(58, 110)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(176, 29)
        Me.btnAgregar.TabIndex = 23
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'slcSucursal
        '
        Me.slcSucursal.FormattingEnabled = True
        Me.slcSucursal.Location = New System.Drawing.Point(91, 69)
        Me.slcSucursal.Name = "slcSucursal"
        Me.slcSucursal.Size = New System.Drawing.Size(104, 24)
        Me.slcSucursal.TabIndex = 22
        '
        'txtMerksyst
        '
        Me.txtMerksyst.Location = New System.Drawing.Point(91, 37)
        Me.txtMerksyst.Name = "txtMerksyst"
        Me.txtMerksyst.Size = New System.Drawing.Size(190, 22)
        Me.txtMerksyst.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 16)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Sucursal"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Id Merksyst"
        '
        'btnCerrarSucursal
        '
        Me.btnCerrarSucursal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrarSucursal.FlatAppearance.BorderSize = 0
        Me.btnCerrarSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrarSucursal.IconChar = FontAwesome.Sharp.IconChar.WindowClose
        Me.btnCerrarSucursal.IconColor = System.Drawing.Color.IndianRed
        Me.btnCerrarSucursal.IconFont = FontAwesome.Sharp.IconFont.Regular
        Me.btnCerrarSucursal.IconSize = 25
        Me.btnCerrarSucursal.Location = New System.Drawing.Point(264, 8)
        Me.btnCerrarSucursal.Name = "btnCerrarSucursal"
        Me.btnCerrarSucursal.Size = New System.Drawing.Size(28, 25)
        Me.btnCerrarSucursal.TabIndex = 3
        Me.btnCerrarSucursal.UseVisualStyleBackColor = True
        '
        'btnNuevaSucursal
        '
        Me.btnNuevaSucursal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevaSucursal.FlatAppearance.BorderSize = 0
        Me.btnNuevaSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevaSucursal.IconChar = FontAwesome.Sharp.IconChar.PlusSquare
        Me.btnNuevaSucursal.IconColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnNuevaSucursal.IconFont = FontAwesome.Sharp.IconFont.Regular
        Me.btnNuevaSucursal.IconSize = 25
        Me.btnNuevaSucursal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevaSucursal.Location = New System.Drawing.Point(228, 21)
        Me.btnNuevaSucursal.Name = "btnNuevaSucursal"
        Me.btnNuevaSucursal.Size = New System.Drawing.Size(163, 35)
        Me.btnNuevaSucursal.TabIndex = 31
        Me.btnNuevaSucursal.Text = "        Nueva Sucursal"
        Me.btnNuevaSucursal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevaSucursal.UseVisualStyleBackColor = True
        '
        'gridSucursales
        '
        Me.gridSucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridSucursales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.borrar, Me.colMerksyst, Me.colSucursal})
        Me.gridSucursales.Location = New System.Drawing.Point(228, 57)
        Me.gridSucursales.Name = "gridSucursales"
        Me.gridSucursales.RowTemplate.Height = 25
        Me.gridSucursales.Size = New System.Drawing.Size(240, 265)
        Me.gridSucursales.TabIndex = 30
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(12, 215)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(199, 22)
        Me.txtTelefono.TabIndex = 29
        '
        'txtCorreo
        '
        Me.txtCorreo.Location = New System.Drawing.Point(12, 171)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(199, 22)
        Me.txtCorreo.TabIndex = 28
        '
        'txtApellido
        '
        Me.txtApellido.Location = New System.Drawing.Point(12, 129)
        Me.txtApellido.Name = "txtApellido"
        Me.txtApellido.Size = New System.Drawing.Size(199, 22)
        Me.txtApellido.TabIndex = 27
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(12, 85)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(199, 22)
        Me.txtNombre.TabIndex = 26
        '
        'txtIdMerksyst
        '
        Me.txtIdMerksyst.Location = New System.Drawing.Point(12, 42)
        Me.txtIdMerksyst.Name = "txtIdMerksyst"
        Me.txtIdMerksyst.Size = New System.Drawing.Size(199, 22)
        Me.txtIdMerksyst.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 16)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Correo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 16)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 16)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Id Merksyst"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 196)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 16)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Telefono"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Apellido"
        '
        'btnEnviar
        '
        Me.btnEnviar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnEnviar.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnEnviar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnEnviar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEnviar.Location = New System.Drawing.Point(133, 392)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(176, 29)
        Me.btnEnviar.TabIndex = 19
        Me.btnEnviar.Text = "Guardar"
        Me.btnEnviar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEnviar.UseVisualStyleBackColor = False
        '
        'btnCerrar
        '
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.FlatAppearance.BorderSize = 0
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.WindowClose
        Me.btnCerrar.IconColor = System.Drawing.Color.IndianRed
        Me.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Regular
        Me.btnCerrar.IconSize = 25
        Me.btnCerrar.Location = New System.Drawing.Point(449, 11)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(28, 25)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'borrar
        '
        Me.borrar.HeaderText = ""
        Me.borrar.Image = Global.Formularios.My.Resources.Resources.trash_solid_15
        Me.borrar.Name = "borrar"
        Me.borrar.ReadOnly = True
        Me.borrar.Width = 40
        '
        'colMerksyst
        '
        Me.colMerksyst.HeaderText = "Id Merksyst"
        Me.colMerksyst.Name = "colMerksyst"
        '
        'colSucursal
        '
        Me.colSucursal.HeaderText = "Suc"
        Me.colSucursal.Name = "colSucursal"
        Me.colSucursal.Width = 50
        '
        'frmEditaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(505, 454)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Name = "frmEditaCliente"
        Me.Text = "frmEditaCliente"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gpoSucursal.ResumeLayout(False)
        Me.gpoSucursal.PerformLayout()
        CType(Me.gridSucursales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents btnEnviar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnNuevaSucursal As FontAwesome.Sharp.IconButton
    Friend WithEvents gridSucursales As DataGridView
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents txtApellido As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtIdMerksyst As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents gpoSucursal As GroupBox
    Friend WithEvents btnCerrarSucursal As FontAwesome.Sharp.IconButton
    Friend WithEvents slcSucursal As ComboBox
    Friend WithEvents txtMerksyst As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblError As Label
    Friend WithEvents btnAgregar As Button
    Friend WithEvents txtTags As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents borrar As DataGridViewImageColumn
    Friend WithEvents colMerksyst As DataGridViewTextBoxColumn
    Friend WithEvents colSucursal As DataGridViewTextBoxColumn
End Class
