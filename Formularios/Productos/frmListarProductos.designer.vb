<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListarProductos
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
        Me.components = New System.ComponentModel.Container()
        Me.gridProductos = New System.Windows.Forms.DataGridView()
        Me.modifica = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_image = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtIdShopify = New System.Windows.Forms.TextBox()
        Me.txtIdMerksyst = New System.Windows.Forms.TextBox()
        Me.txtEtiqueta = New System.Windows.Forms.TextBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.txtEncabezado = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TimerProducto = New System.Windows.Forms.Timer(Me.components)
        Me.divModifica = New System.Windows.Forms.Panel()
        Me.divEncabezado = New System.Windows.Forms.Panel()
        Me.divCuerpo = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.gridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.divEncabezado.SuspendLayout()
        Me.divCuerpo.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridProductos
        '
        Me.gridProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.modifica, Me.col_image})
        Me.gridProductos.Location = New System.Drawing.Point(3, 27)
        Me.gridProductos.Name = "gridProductos"
        Me.gridProductos.RowTemplate.Height = 25
        Me.gridProductos.Size = New System.Drawing.Size(605, 345)
        Me.gridProductos.TabIndex = 4
        '
        'modifica
        '
        Me.modifica.HeaderText = ""
        Me.modifica.Image = Global.Formularios.My.Resources.Resources.Edit
        Me.modifica.Name = "modifica"
        Me.modifica.ReadOnly = True
        Me.modifica.Width = 40
        '
        'col_image
        '
        Me.col_image.HeaderText = ""
        Me.col_image.Image = Global.Formularios.My.Resources.Resources.image
        Me.col_image.Name = "col_image"
        Me.col_image.ReadOnly = True
        Me.col_image.Width = 40
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtIdShopify)
        Me.GroupBox1.Controls.Add(Me.txtIdMerksyst)
        Me.GroupBox1.Controls.Add(Me.txtEtiqueta)
        Me.GroupBox1.Controls.Add(Me.txtProveedor)
        Me.GroupBox1.Controls.Add(Me.txtEncabezado)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(608, 93)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'txtIdShopify
        '
        Me.txtIdShopify.Location = New System.Drawing.Point(383, 65)
        Me.txtIdShopify.Name = "txtIdShopify"
        Me.txtIdShopify.Size = New System.Drawing.Size(216, 22)
        Me.txtIdShopify.TabIndex = 9
        '
        'txtIdMerksyst
        '
        Me.txtIdMerksyst.Location = New System.Drawing.Point(94, 66)
        Me.txtIdMerksyst.Name = "txtIdMerksyst"
        Me.txtIdMerksyst.Size = New System.Drawing.Size(213, 22)
        Me.txtIdMerksyst.TabIndex = 8
        '
        'txtEtiqueta
        '
        Me.txtEtiqueta.Location = New System.Drawing.Point(383, 37)
        Me.txtEtiqueta.Name = "txtEtiqueta"
        Me.txtEtiqueta.Size = New System.Drawing.Size(216, 22)
        Me.txtEtiqueta.TabIndex = 7
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(94, 37)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(213, 22)
        Me.txtProveedor.TabIndex = 6
        '
        'txtEncabezado
        '
        Me.txtEncabezado.Location = New System.Drawing.Point(94, 11)
        Me.txtEncabezado.Name = "txtEncabezado"
        Me.txtEncabezado.Size = New System.Drawing.Size(505, 22)
        Me.txtEncabezado.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(315, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Id Shopify"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(315, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Etiqueta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Id Merksyst"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Proveedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Encabezado"
        '
        'TimerProducto
        '
        '
        'divModifica
        '
        Me.divModifica.Location = New System.Drawing.Point(217, 82)
        Me.divModifica.Name = "divModifica"
        Me.divModifica.Size = New System.Drawing.Size(200, 100)
        Me.divModifica.TabIndex = 5
        Me.divModifica.Visible = False
        '
        'divEncabezado
        '
        Me.divEncabezado.Controls.Add(Me.GroupBox1)
        Me.divEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.divEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.divEncabezado.Name = "divEncabezado"
        Me.divEncabezado.Size = New System.Drawing.Size(611, 95)
        Me.divEncabezado.TabIndex = 6
        '
        'divCuerpo
        '
        Me.divCuerpo.Controls.Add(Me.divModifica)
        Me.divCuerpo.Controls.Add(Me.gridProductos)
        Me.divCuerpo.Controls.Add(Me.MenuStrip1)
        Me.divCuerpo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.divCuerpo.Location = New System.Drawing.Point(0, 95)
        Me.divCuerpo.Name = "divCuerpo"
        Me.divCuerpo.Size = New System.Drawing.Size(611, 375)
        Me.divCuerpo.TabIndex = 7
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportarAExcelToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(611, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ExportarAExcelToolStripMenuItem
        '
        Me.ExportarAExcelToolStripMenuItem.Image = Global.Formularios.My.Resources.Resources.file_excel_solid
        Me.ExportarAExcelToolStripMenuItem.Name = "ExportarAExcelToolStripMenuItem"
        Me.ExportarAExcelToolStripMenuItem.Size = New System.Drawing.Size(118, 20)
        Me.ExportarAExcelToolStripMenuItem.Text = "Exportar a excel"
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = Global.Formularios.My.Resources.Resources.Edit
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Width = 40
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.HeaderText = ""
        Me.DataGridViewImageColumn2.Image = Global.Formularios.My.Resources.Resources.image
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.ReadOnly = True
        '
        'frmListarProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(611, 470)
        Me.Controls.Add(Me.divCuerpo)
        Me.Controls.Add(Me.divEncabezado)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmListarProductos"
        Me.Text = "frmListarProductos"
        CType(Me.gridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.divEncabezado.ResumeLayout(False)
        Me.divCuerpo.ResumeLayout(False)
        Me.divCuerpo.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridProductos As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtIdShopify As TextBox
    Friend WithEvents txtIdMerksyst As TextBox
    Friend WithEvents txtEtiqueta As TextBox
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents txtEncabezado As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TimerProducto As Timer
    Friend WithEvents divModifica As Panel
    Friend WithEvents iconImage As DataGridViewImageColumn
    Friend WithEvents divEncabezado As Panel
    Friend WithEvents divCuerpo As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ExportarAExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents modifica As DataGridViewImageColumn
    Friend WithEvents col_image As DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn2 As DataGridViewImageColumn
End Class
