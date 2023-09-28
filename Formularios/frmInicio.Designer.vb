<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInicio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInicio))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnServidores = New FontAwesome.Sharp.IconButton()
        Me.btnTareas = New FontAwesome.Sharp.IconButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnModificarProductos = New FontAwesome.Sharp.IconButton()
        Me.btnListarProductos = New FontAwesome.Sharp.IconButton()
        Me.btnImportarProductos = New FontAwesome.Sharp.IconButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnListarClientes = New FontAwesome.Sharp.IconButton()
        Me.btnImportarClientes = New FontAwesome.Sharp.IconButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnReportes = New FontAwesome.Sharp.IconButton()
        Me.btnDescargas = New FontAwesome.Sharp.IconButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.panelPrincipal = New System.Windows.Forms.Panel()
        Me.divCarga = New Formularios.TransparentPanel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnLayOuts = New FontAwesome.Sharp.IconButton()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelPrincipal.SuspendLayout()
        Me.divCarga.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(204, 507)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.btnLayOuts)
        Me.Panel2.Controls.Add(Me.btnServidores)
        Me.Panel2.Controls.Add(Me.btnTareas)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.btnModificarProductos)
        Me.Panel2.Controls.Add(Me.btnListarProductos)
        Me.Panel2.Controls.Add(Me.btnImportarProductos)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.btnListarClientes)
        Me.Panel2.Controls.Add(Me.btnImportarClientes)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.btnReportes)
        Me.Panel2.Controls.Add(Me.btnDescargas)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 51)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(202, 435)
        Me.Panel2.TabIndex = 6
        '
        'btnServidores
        '
        Me.btnServidores.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnServidores.FlatAppearance.BorderSize = 0
        Me.btnServidores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnServidores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnServidores.IconChar = FontAwesome.Sharp.IconChar.LaptopCode
        Me.btnServidores.IconColor = System.Drawing.Color.Black
        Me.btnServidores.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnServidores.IconSize = 25
        Me.btnServidores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnServidores.Location = New System.Drawing.Point(0, 432)
        Me.btnServidores.Name = "btnServidores"
        Me.btnServidores.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnServidores.Size = New System.Drawing.Size(185, 40)
        Me.btnServidores.TabIndex = 29
        Me.btnServidores.Text = "        Servidores"
        Me.btnServidores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnServidores.UseVisualStyleBackColor = True
        '
        'btnTareas
        '
        Me.btnTareas.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnTareas.FlatAppearance.BorderSize = 0
        Me.btnTareas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTareas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTareas.IconChar = FontAwesome.Sharp.IconChar.Clock
        Me.btnTareas.IconColor = System.Drawing.Color.Black
        Me.btnTareas.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnTareas.IconSize = 25
        Me.btnTareas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTareas.Location = New System.Drawing.Point(0, 392)
        Me.btnTareas.Name = "btnTareas"
        Me.btnTareas.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnTareas.Size = New System.Drawing.Size(185, 40)
        Me.btnTareas.TabIndex = 28
        Me.btnTareas.Text = "        Configurar tareas"
        Me.btnTareas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTareas.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label5.Location = New System.Drawing.Point(0, 364)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(185, 28)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Configuracion"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnModificarProductos
        '
        Me.btnModificarProductos.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnModificarProductos.FlatAppearance.BorderSize = 0
        Me.btnModificarProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModificarProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificarProductos.IconChar = FontAwesome.Sharp.IconChar.Edit
        Me.btnModificarProductos.IconColor = System.Drawing.Color.Black
        Me.btnModificarProductos.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnModificarProductos.IconSize = 25
        Me.btnModificarProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificarProductos.Location = New System.Drawing.Point(0, 324)
        Me.btnModificarProductos.Name = "btnModificarProductos"
        Me.btnModificarProductos.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnModificarProductos.Size = New System.Drawing.Size(185, 40)
        Me.btnModificarProductos.TabIndex = 26
        Me.btnModificarProductos.Text = "       Editar lista prod."
        Me.btnModificarProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificarProductos.UseVisualStyleBackColor = True
        '
        'btnListarProductos
        '
        Me.btnListarProductos.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnListarProductos.FlatAppearance.BorderSize = 0
        Me.btnListarProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnListarProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnListarProductos.IconChar = FontAwesome.Sharp.IconChar.Dolly
        Me.btnListarProductos.IconColor = System.Drawing.Color.Black
        Me.btnListarProductos.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnListarProductos.IconSize = 25
        Me.btnListarProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnListarProductos.Location = New System.Drawing.Point(0, 284)
        Me.btnListarProductos.Name = "btnListarProductos"
        Me.btnListarProductos.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnListarProductos.Size = New System.Drawing.Size(185, 40)
        Me.btnListarProductos.TabIndex = 22
        Me.btnListarProductos.Text = "       Listar productos"
        Me.btnListarProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnListarProductos.UseVisualStyleBackColor = True
        '
        'btnImportarProductos
        '
        Me.btnImportarProductos.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnImportarProductos.FlatAppearance.BorderSize = 0
        Me.btnImportarProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportarProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportarProductos.IconChar = FontAwesome.Sharp.IconChar.FileCsv
        Me.btnImportarProductos.IconColor = System.Drawing.Color.Black
        Me.btnImportarProductos.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnImportarProductos.IconSize = 25
        Me.btnImportarProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportarProductos.Location = New System.Drawing.Point(0, 244)
        Me.btnImportarProductos.Name = "btnImportarProductos"
        Me.btnImportarProductos.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnImportarProductos.Size = New System.Drawing.Size(185, 40)
        Me.btnImportarProductos.TabIndex = 21
        Me.btnImportarProductos.Text = "       Importar productos"
        Me.btnImportarProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportarProductos.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Location = New System.Drawing.Point(0, 216)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(185, 28)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Productos"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnListarClientes
        '
        Me.btnListarClientes.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnListarClientes.FlatAppearance.BorderSize = 0
        Me.btnListarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnListarClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnListarClientes.IconChar = FontAwesome.Sharp.IconChar.UserCheck
        Me.btnListarClientes.IconColor = System.Drawing.Color.Black
        Me.btnListarClientes.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnListarClientes.IconSize = 25
        Me.btnListarClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnListarClientes.Location = New System.Drawing.Point(0, 176)
        Me.btnListarClientes.Name = "btnListarClientes"
        Me.btnListarClientes.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnListarClientes.Size = New System.Drawing.Size(185, 40)
        Me.btnListarClientes.TabIndex = 19
        Me.btnListarClientes.Text = "       Listar clientes"
        Me.btnListarClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnListarClientes.UseVisualStyleBackColor = True
        '
        'btnImportarClientes
        '
        Me.btnImportarClientes.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnImportarClientes.FlatAppearance.BorderSize = 0
        Me.btnImportarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportarClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportarClientes.IconChar = FontAwesome.Sharp.IconChar.FileCsv
        Me.btnImportarClientes.IconColor = System.Drawing.Color.Black
        Me.btnImportarClientes.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnImportarClientes.IconSize = 25
        Me.btnImportarClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportarClientes.Location = New System.Drawing.Point(0, 136)
        Me.btnImportarClientes.Name = "btnImportarClientes"
        Me.btnImportarClientes.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnImportarClientes.Size = New System.Drawing.Size(185, 40)
        Me.btnImportarClientes.TabIndex = 18
        Me.btnImportarClientes.Text = "       Importar clientes"
        Me.btnImportarClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportarClientes.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(0, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(185, 28)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Clientes"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnReportes
        '
        Me.btnReportes.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnReportes.FlatAppearance.BorderSize = 0
        Me.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReportes.IconChar = FontAwesome.Sharp.IconChar.ChartLine
        Me.btnReportes.IconColor = System.Drawing.Color.Black
        Me.btnReportes.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnReportes.IconSize = 25
        Me.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReportes.Location = New System.Drawing.Point(0, 68)
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnReportes.Size = New System.Drawing.Size(185, 40)
        Me.btnReportes.TabIndex = 16
        Me.btnReportes.Text = "       Reportes"
        Me.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReportes.UseVisualStyleBackColor = True
        '
        'btnDescargas
        '
        Me.btnDescargas.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnDescargas.FlatAppearance.BorderSize = 0
        Me.btnDescargas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDescargas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDescargas.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart
        Me.btnDescargas.IconColor = System.Drawing.Color.Black
        Me.btnDescargas.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnDescargas.IconSize = 25
        Me.btnDescargas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDescargas.Location = New System.Drawing.Point(0, 28)
        Me.btnDescargas.Name = "btnDescargas"
        Me.btnDescargas.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnDescargas.Size = New System.Drawing.Size(185, 40)
        Me.btnDescargas.TabIndex = 15
        Me.btnDescargas.Text = "       Descargar pedidos"
        Me.btnDescargas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDescargas.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(185, 28)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Pedidos"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(0, 486)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(202, 19)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "V. 5.0.0"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = Global.Formularios.My.Resources.Resources.Razon
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(202, 51)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'panelPrincipal
        '
        Me.panelPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelPrincipal.Controls.Add(Me.divCarga)
        Me.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelPrincipal.Location = New System.Drawing.Point(204, 0)
        Me.panelPrincipal.Margin = New System.Windows.Forms.Padding(4)
        Me.panelPrincipal.Name = "panelPrincipal"
        Me.panelPrincipal.Size = New System.Drawing.Size(608, 507)
        Me.panelPrincipal.TabIndex = 1
        '
        'divCarga
        '
        Me.divCarga.Controls.Add(Me.PictureBox2)
        Me.divCarga.Location = New System.Drawing.Point(111, 119)
        Me.divCarga.Name = "divCarga"
        Me.divCarga.Size = New System.Drawing.Size(343, 301)
        Me.divCarga.TabIndex = 0
        Me.divCarga.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox2.Image = Global.Formularios.My.Resources.Resources.Cargando
        Me.PictureBox2.Location = New System.Drawing.Point(47, 28)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(262, 243)
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'btnLayOuts
        '
        Me.btnLayOuts.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnLayOuts.FlatAppearance.BorderSize = 0
        Me.btnLayOuts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLayOuts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLayOuts.IconChar = FontAwesome.Sharp.IconChar.Code
        Me.btnLayOuts.IconColor = System.Drawing.Color.Black
        Me.btnLayOuts.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnLayOuts.IconSize = 25
        Me.btnLayOuts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLayOuts.Location = New System.Drawing.Point(0, 472)
        Me.btnLayOuts.Name = "btnLayOuts"
        Me.btnLayOuts.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnLayOuts.Size = New System.Drawing.Size(185, 40)
        Me.btnLayOuts.TabIndex = 30
        Me.btnLayOuts.Text = "        Descargar Layouts"
        Me.btnLayOuts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLayOuts.UseVisualStyleBackColor = True
        '
        'frmInicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(812, 507)
        Me.Controls.Add(Me.panelPrincipal)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmInicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conecta shopify"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelPrincipal.ResumeLayout(False)
        Me.divCarga.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents panelPrincipal As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnListarProductos As FontAwesome.Sharp.IconButton
    Friend WithEvents btnImportarProductos As FontAwesome.Sharp.IconButton
    Friend WithEvents Label4 As Label
    Friend WithEvents btnListarClientes As FontAwesome.Sharp.IconButton
    Friend WithEvents btnImportarClientes As FontAwesome.Sharp.IconButton
    Friend WithEvents Label2 As Label
    Friend WithEvents btnReportes As FontAwesome.Sharp.IconButton
    Friend WithEvents btnDescargas As FontAwesome.Sharp.IconButton
    Friend WithEvents Label1 As Label
    Friend WithEvents divCarga As TransparentPanel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnServidores As FontAwesome.Sharp.IconButton
    Friend WithEvents btnTareas As FontAwesome.Sharp.IconButton
    Friend WithEvents Label5 As Label
    Friend WithEvents btnModificarProductos As FontAwesome.Sharp.IconButton
    Friend WithEvents btnLayOuts As FontAwesome.Sharp.IconButton
End Class
