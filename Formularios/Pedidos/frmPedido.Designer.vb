<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedido
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.alertAuto = New System.Windows.Forms.GroupBox()
        Me.btnAutomatico = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSucursales = New System.Windows.Forms.Label()
        Me.txtProxEjecuta = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnDescargar = New System.Windows.Forms.Button()
        Me.dataGridErrores = New System.Windows.Forms.DataGridView()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.fechaFin = New System.Windows.Forms.DateTimePicker()
        Me.fechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.divServidores = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.alertAuto.SuspendLayout()
        CType(Me.dataGridErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.alertAuto)
        Me.Panel1.Controls.Add(Me.btnDescargar)
        Me.Panel1.Controls.Add(Me.dataGridErrores)
        Me.Panel1.Controls.Add(Me.lblTotal)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.btnBuscar)
        Me.Panel1.Controls.Add(Me.fechaFin)
        Me.Panel1.Controls.Add(Me.fechaIni)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(642, 470)
        Me.Panel1.TabIndex = 0
        '
        'alertAuto
        '
        Me.alertAuto.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.alertAuto.BackColor = System.Drawing.Color.Yellow
        Me.alertAuto.Controls.Add(Me.btnAutomatico)
        Me.alertAuto.Controls.Add(Me.Label3)
        Me.alertAuto.Controls.Add(Me.txtSucursales)
        Me.alertAuto.Controls.Add(Me.txtProxEjecuta)
        Me.alertAuto.Controls.Add(Me.Label4)
        Me.alertAuto.Location = New System.Drawing.Point(52, 165)
        Me.alertAuto.Name = "alertAuto"
        Me.alertAuto.Size = New System.Drawing.Size(413, 235)
        Me.alertAuto.TabIndex = 1
        Me.alertAuto.TabStop = False
        Me.alertAuto.Visible = False
        '
        'btnAutomatico
        '
        Me.btnAutomatico.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAutomatico.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAutomatico.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAutomatico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutomatico.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAutomatico.Location = New System.Drawing.Point(110, 199)
        Me.btnAutomatico.Name = "btnAutomatico"
        Me.btnAutomatico.Size = New System.Drawing.Size(189, 27)
        Me.btnAutomatico.TabIndex = 20
        Me.btnAutomatico.Text = "Cambiar a manual"
        Me.btnAutomatico.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(52, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(311, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Se ejecutara el sistema de forma automatica a las: "
        '
        'txtSucursales
        '
        Me.txtSucursales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSucursales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSucursales.Location = New System.Drawing.Point(17, 85)
        Me.txtSucursales.Name = "txtSucursales"
        Me.txtSucursales.Size = New System.Drawing.Size(378, 107)
        Me.txtSucursales.TabIndex = 3
        Me.txtSucursales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtProxEjecuta
        '
        Me.txtProxEjecuta.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtProxEjecuta.Location = New System.Drawing.Point(129, 40)
        Me.txtProxEjecuta.Name = "txtProxEjecuta"
        Me.txtProxEjecuta.Size = New System.Drawing.Size(150, 24)
        Me.txtProxEjecuta.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(149, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "En las sucursales: "
        '
        'btnDescargar
        '
        Me.btnDescargar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnDescargar.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnDescargar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDescargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDescargar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDescargar.Location = New System.Drawing.Point(100, 277)
        Me.btnDescargar.Name = "btnDescargar"
        Me.btnDescargar.Size = New System.Drawing.Size(303, 27)
        Me.btnDescargar.TabIndex = 21
        Me.btnDescargar.Text = "Descargar"
        Me.btnDescargar.UseVisualStyleBackColor = False
        '
        'dataGridErrores
        '
        Me.dataGridErrores.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataGridErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridErrores.Location = New System.Drawing.Point(10, 329)
        Me.dataGridErrores.Name = "dataGridErrores"
        Me.dataGridErrores.Size = New System.Drawing.Size(501, 129)
        Me.dataGridErrores.TabIndex = 7
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.Location = New System.Drawing.Point(245, 308)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(265, 18)
        Me.lblTotal.TabIndex = 6
        Me.lblTotal.Text = "Total de filas procesadas 0 / 0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(9, 39)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(501, 232)
        Me.DataGridView1.TabIndex = 5
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnBuscar.Location = New System.Drawing.Point(413, 5)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(88, 25)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'fechaFin
        '
        Me.fechaFin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.fechaFin.CustomFormat = "yyyy-MM-dd HH:mm"
        Me.fechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechaFin.Location = New System.Drawing.Point(267, 7)
        Me.fechaFin.Name = "fechaFin"
        Me.fechaFin.Size = New System.Drawing.Size(136, 22)
        Me.fechaFin.TabIndex = 3
        '
        'fechaIni
        '
        Me.fechaIni.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.fechaIni.CustomFormat = "yyyy-MM-dd HH:mm"
        Me.fechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechaIni.Location = New System.Drawing.Point(72, 7)
        Me.fechaIni.Name = "fechaIni"
        Me.fechaIni.Size = New System.Drawing.Size(136, 22)
        Me.fechaIni.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(218, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Hasta:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Desde:"
        '
        'divServidores
        '
        Me.divServidores.AutoScroll = True
        Me.divServidores.BackColor = System.Drawing.SystemColors.Control
        Me.divServidores.Dock = System.Windows.Forms.DockStyle.Right
        Me.divServidores.Location = New System.Drawing.Point(519, 0)
        Me.divServidores.Name = "divServidores"
        Me.divServidores.Size = New System.Drawing.Size(123, 470)
        Me.divServidores.TabIndex = 1
        '
        'Timer1
        '
        '
        'frmPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(642, 470)
        Me.Controls.Add(Me.divServidores)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmPedido"
        Me.Text = "frmPedido"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.alertAuto.ResumeLayout(False)
        Me.alertAuto.PerformLayout()
        CType(Me.dataGridErrores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents divServidores As Panel
    Friend WithEvents btnBuscar As Button
    Friend WithEvents fechaFin As DateTimePicker
    Friend WithEvents fechaIni As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lblTotal As Label
    Friend WithEvents dataGridErrores As DataGridView
    Friend WithEvents txtSucursales As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtProxEjecuta As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnAutomatico As Button
    Friend WithEvents alertAuto As GroupBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents btnDescargar As Button
End Class
