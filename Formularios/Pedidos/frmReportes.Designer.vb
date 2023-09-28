<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReportes
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.fechaFin = New System.Windows.Forms.DateTimePicker()
        Me.fechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.timerReporte = New System.Windows.Forms.Timer(Me.components)
        Me.DataGridError = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.divModifica = New System.Windows.Forms.Panel()
        Me.gridArticulos = New System.Windows.Forms.DataGridView()
        Me.gridPedidosFecha = New System.Windows.Forms.DataGridView()
        Me.gridVentasFecha = New System.Windows.Forms.DataGridView()
        Me.gridVentasGeneral = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ExportarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.gridArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridPedidosFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridVentasFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridVentasGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnBuscar.Location = New System.Drawing.Point(479, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(88, 25)
        Me.btnBuscar.TabIndex = 15
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'fechaFin
        '
        Me.fechaFin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.fechaFin.CustomFormat = "yyyy-MM-dd HH:mm"
        Me.fechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechaFin.Location = New System.Drawing.Point(323, 10)
        Me.fechaFin.Name = "fechaFin"
        Me.fechaFin.Size = New System.Drawing.Size(139, 22)
        Me.fechaFin.TabIndex = 14
        '
        'fechaIni
        '
        Me.fechaIni.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.fechaIni.CustomFormat = "yyyy-MM-dd HH:mm"
        Me.fechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechaIni.Location = New System.Drawing.Point(125, 10)
        Me.fechaIni.Name = "fechaIni"
        Me.fechaIni.Size = New System.Drawing.Size(141, 22)
        Me.fechaIni.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(271, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Hasta: "
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(68, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Desde: "
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnBuscar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.fechaFin)
        Me.Panel1.Controls.Add(Me.fechaIni)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(642, 40)
        Me.Panel1.TabIndex = 17
        '
        'DataGridError
        '
        Me.DataGridError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridError.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGridError.Location = New System.Drawing.Point(0, 345)
        Me.DataGridError.Name = "DataGridError"
        Me.DataGridError.RowTemplate.Height = 25
        Me.DataGridError.Size = New System.Drawing.Size(642, 125)
        Me.DataGridError.TabIndex = 20
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(642, 281)
        Me.TabControl1.TabIndex = 21
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.divModifica)
        Me.TabPage1.Controls.Add(Me.gridArticulos)
        Me.TabPage1.Controls.Add(Me.gridPedidosFecha)
        Me.TabPage1.Controls.Add(Me.gridVentasFecha)
        Me.TabPage1.Controls.Add(Me.gridVentasGeneral)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(634, 252)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Totales"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(27, 677)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(556, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Cantidad de articulos vendidos en shopify"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(27, 455)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(556, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Cantidad de pedidos registrados en shopify"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(26, 234)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(555, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Total en ventas registradas en shopify"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(25, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(555, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Total en shopify"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'divModifica
        '
        Me.divModifica.Location = New System.Drawing.Point(169, 65)
        Me.divModifica.Name = "divModifica"
        Me.divModifica.Size = New System.Drawing.Size(316, 100)
        Me.divModifica.TabIndex = 6
        Me.divModifica.Visible = False
        '
        'gridArticulos
        '
        Me.gridArticulos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridArticulos.Location = New System.Drawing.Point(26, 694)
        Me.gridArticulos.Name = "gridArticulos"
        Me.gridArticulos.RowTemplate.Height = 25
        Me.gridArticulos.Size = New System.Drawing.Size(557, 200)
        Me.gridArticulos.TabIndex = 3
        '
        'gridPedidosFecha
        '
        Me.gridPedidosFecha.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridPedidosFecha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridPedidosFecha.Location = New System.Drawing.Point(26, 474)
        Me.gridPedidosFecha.Name = "gridPedidosFecha"
        Me.gridPedidosFecha.RowTemplate.Height = 25
        Me.gridPedidosFecha.Size = New System.Drawing.Size(557, 200)
        Me.gridPedidosFecha.TabIndex = 2
        '
        'gridVentasFecha
        '
        Me.gridVentasFecha.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridVentasFecha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridVentasFecha.Location = New System.Drawing.Point(26, 252)
        Me.gridVentasFecha.Name = "gridVentasFecha"
        Me.gridVentasFecha.RowTemplate.Height = 25
        Me.gridVentasFecha.Size = New System.Drawing.Size(556, 200)
        Me.gridVentasFecha.TabIndex = 1
        '
        'gridVentasGeneral
        '
        Me.gridVentasGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridVentasGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridVentasGeneral.Location = New System.Drawing.Point(25, 31)
        Me.gridVentasGeneral.Name = "gridVentasGeneral"
        Me.gridVentasGeneral.RowTemplate.Height = 25
        Me.gridVentasGeneral.Size = New System.Drawing.Size(556, 200)
        Me.gridVentasGeneral.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(634, 252)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Concentrado"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 25
        Me.DataGridView1.Size = New System.Drawing.Size(628, 246)
        Me.DataGridView1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Controls.Add(Me.MenuStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(642, 305)
        Me.Panel2.TabIndex = 22
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportarAExcelToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(642, 24)
        Me.MenuStrip1.TabIndex = 22
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ExportarAExcelToolStripMenuItem
        '
        Me.ExportarAExcelToolStripMenuItem.Image = Global.Formularios.My.Resources.Resources.file_excel_solid
        Me.ExportarAExcelToolStripMenuItem.Name = "ExportarAExcelToolStripMenuItem"
        Me.ExportarAExcelToolStripMenuItem.Size = New System.Drawing.Size(118, 20)
        Me.ExportarAExcelToolStripMenuItem.Text = "Exportar a excel"
        '
        'frmReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(642, 470)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.DataGridError)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmReportes"
        Me.Text = "frmReportes"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.gridArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridPedidosFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridVentasFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridVentasGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnBuscar As Button
    Friend WithEvents fechaFin As DateTimePicker
    Friend WithEvents fechaIni As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents timerReporte As Timer
    Friend WithEvents DataGridError As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents divModifica As Panel
    Friend WithEvents gridArticulos As DataGridView
    Friend WithEvents gridPedidosFecha As DataGridView
    Friend WithEvents gridVentasFecha As DataGridView
    Friend WithEvents gridVentasGeneral As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ExportarAExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
