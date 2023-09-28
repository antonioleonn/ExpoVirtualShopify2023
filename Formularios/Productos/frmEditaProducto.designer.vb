<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditaProducto
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblError = New System.Windows.Forms.Label()
        Me.slcEstatus = New System.Windows.Forms.ComboBox()
        Me.slcEmpaque = New System.Windows.Forms.ComboBox()
        Me.btnGuardaModif = New System.Windows.Forms.Button()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.txtSku = New System.Windows.Forms.TextBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtEncabezado = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCerrar = New FontAwesome.Sharp.IconButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Controls.Add(Me.txtTags)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblError)
        Me.GroupBox1.Controls.Add(Me.slcEstatus)
        Me.GroupBox1.Controls.Add(Me.slcEmpaque)
        Me.GroupBox1.Controls.Add(Me.btnGuardaModif)
        Me.GroupBox1.Controls.Add(Me.txtPrecio)
        Me.GroupBox1.Controls.Add(Me.txtSku)
        Me.GroupBox1.Controls.Add(Me.txtProveedor)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion)
        Me.GroupBox1.Controls.Add(Me.txtEncabezado)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnCerrar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(497, 389)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtTags
        '
        Me.txtTags.Location = New System.Drawing.Point(102, 248)
        Me.txtTags.Multiline = True
        Me.txtTags.Name = "txtTags"
        Me.txtTags.Size = New System.Drawing.Size(366, 57)
        Me.txtTags.TabIndex = 36
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(24, 258)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 16)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Etiquetas"
        '
        'lblError
        '
        Me.lblError.Location = New System.Drawing.Point(23, 312)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(456, 36)
        Me.lblError.TabIndex = 34
        Me.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'slcEstatus
        '
        Me.slcEstatus.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.slcEstatus.FormattingEnabled = True
        Me.slcEstatus.Location = New System.Drawing.Point(101, 211)
        Me.slcEstatus.Name = "slcEstatus"
        Me.slcEstatus.Size = New System.Drawing.Size(150, 24)
        Me.slcEstatus.TabIndex = 18
        '
        'slcEmpaque
        '
        Me.slcEmpaque.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.slcEmpaque.FormattingEnabled = True
        Me.slcEmpaque.Location = New System.Drawing.Point(101, 171)
        Me.slcEmpaque.Name = "slcEmpaque"
        Me.slcEmpaque.Size = New System.Drawing.Size(150, 24)
        Me.slcEmpaque.TabIndex = 15
        '
        'btnGuardaModif
        '
        Me.btnGuardaModif.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnGuardaModif.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnGuardaModif.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnGuardaModif.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardaModif.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnGuardaModif.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGuardaModif.Location = New System.Drawing.Point(159, 354)
        Me.btnGuardaModif.Name = "btnGuardaModif"
        Me.btnGuardaModif.Size = New System.Drawing.Size(176, 29)
        Me.btnGuardaModif.TabIndex = 20
        Me.btnGuardaModif.Text = "Guardar"
        Me.btnGuardaModif.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardaModif.UseVisualStyleBackColor = False
        '
        'txtPrecio
        '
        Me.txtPrecio.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtPrecio.Location = New System.Drawing.Point(318, 171)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(150, 22)
        Me.txtPrecio.TabIndex = 17
        '
        'txtSku
        '
        Me.txtSku.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtSku.Location = New System.Drawing.Point(365, 133)
        Me.txtSku.Name = "txtSku"
        Me.txtSku.Size = New System.Drawing.Size(102, 22)
        Me.txtSku.TabIndex = 14
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtProveedor.Location = New System.Drawing.Point(101, 133)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(221, 22)
        Me.txtProveedor.TabIndex = 13
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtDescripcion.Location = New System.Drawing.Point(113, 61)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(354, 63)
        Me.txtDescripcion.TabIndex = 12
        '
        'txtEncabezado
        '
        Me.txtEncabezado.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtEncabezado.Location = New System.Drawing.Point(113, 30)
        Me.txtEncabezado.Name = "txtEncabezado"
        Me.txtEncabezado.Size = New System.Drawing.Size(354, 22)
        Me.txtEncabezado.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 214)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 16)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Estatus"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(264, 174)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 16)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Precio"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Empaque"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(328, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Sku"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Proveedor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Descripcion"
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
        Me.btnCerrar.Location = New System.Drawing.Point(467, 9)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(28, 25)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Encabezado"
        '
        'frmEditaProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(522, 413)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Name = "frmEditaProducto"
        Me.Text = "frmEditaProducto"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCerrar As FontAwesome.Sharp.IconButton
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents txtSku As TextBox
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents txtEncabezado As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnGuardaModif As Button
    Friend WithEvents slcEmpaque As ComboBox
    Friend WithEvents slcEstatus As ComboBox
    Friend WithEvents lblError As Label
    Friend WithEvents txtTags As TextBox
    Friend WithEvents Label9 As Label
End Class
