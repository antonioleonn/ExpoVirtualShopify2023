<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImportarClientes
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
        Me.divSubir = New System.Windows.Forms.GroupBox()
        Me.lblFile = New System.Windows.Forms.Label()
        Me.btnFile = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.btnCSV = New FontAwesome.Sharp.IconButton()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.gridErrores = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.IdMerksyst = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.divSubir.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'divSubir
        '
        Me.divSubir.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.divSubir.BackColor = System.Drawing.Color.Transparent
        Me.divSubir.Controls.Add(Me.lblFile)
        Me.divSubir.Controls.Add(Me.btnFile)
        Me.divSubir.Location = New System.Drawing.Point(32, 2)
        Me.divSubir.Name = "divSubir"
        Me.divSubir.Size = New System.Drawing.Size(537, 48)
        Me.divSubir.TabIndex = 0
        Me.divSubir.TabStop = False
        '
        'lblFile
        '
        Me.lblFile.AutoSize = True
        Me.lblFile.BackColor = System.Drawing.Color.Transparent
        Me.lblFile.Location = New System.Drawing.Point(196, 19)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(140, 16)
        Me.lblFile.TabIndex = 12
        Me.lblFile.Text = "Selecciona un archivo"
        '
        'btnFile
        '
        Me.btnFile.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnFile.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnFile.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnFile.Location = New System.Drawing.Point(15, 14)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(169, 25)
        Me.btnFile.TabIndex = 11
        Me.btnFile.Text = "Buscar"
        Me.btnFile.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnFile.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 57)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 25
        Me.DataGridView1.Size = New System.Drawing.Size(618, 237)
        Me.DataGridView1.TabIndex = 1
        '
        'btnEnviar
        '
        Me.btnEnviar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnEnviar.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnEnviar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnEnviar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEnviar.Location = New System.Drawing.Point(228, 300)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(176, 29)
        Me.btnEnviar.TabIndex = 17
        Me.btnEnviar.Text = "Enviar y guardar CSV"
        Me.btnEnviar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEnviar.UseVisualStyleBackColor = False
        '
        'btnCSV
        '
        Me.btnCSV.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCSV.FlatAppearance.BorderSize = 0
        Me.btnCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCSV.IconChar = FontAwesome.Sharp.IconChar.FileCsv
        Me.btnCSV.IconColor = System.Drawing.Color.DarkGreen
        Me.btnCSV.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.btnCSV.IconSize = 40
        Me.btnCSV.Location = New System.Drawing.Point(588, 10)
        Me.btnCSV.Name = "btnCSV"
        Me.btnCSV.Size = New System.Drawing.Size(42, 40)
        Me.btnCSV.TabIndex = 18
        Me.btnCSV.UseVisualStyleBackColor = True
        Me.btnCSV.Visible = False
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Location = New System.Drawing.Point(390, 313)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(240, 19)
        Me.lblTotal.TabIndex = 19
        Me.lblTotal.Text = "Total de filas procesadas: 0 / 0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gridErrores
        '
        Me.gridErrores.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridErrores.Location = New System.Drawing.Point(12, 335)
        Me.gridErrores.Name = "gridErrores"
        Me.gridErrores.RowTemplate.Height = 25
        Me.gridErrores.Size = New System.Drawing.Size(618, 124)
        Me.gridErrores.TabIndex = 20
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'IdMerksyst
        '
        Me.IdMerksyst.HeaderText = "Id Merksyst"
        Me.IdMerksyst.Name = "IdMerksyst"
        Me.IdMerksyst.ReadOnly = True
        Me.IdMerksyst.Width = 75
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 75
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'frmImportarClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(642, 470)
        Me.Controls.Add(Me.gridErrores)
        Me.Controls.Add(Me.btnCSV)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.divSubir)
        Me.Controls.Add(Me.lblTotal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Name = "frmImportarClientes"
        Me.Text = "frmImportarClientes"
        Me.divSubir.ResumeLayout(False)
        Me.divSubir.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridErrores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents divSubir As GroupBox
    Friend WithEvents btnFile As Button
    Friend WithEvents lblFile As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnEnviar As Button
    Friend WithEvents btnCSV As FontAwesome.Sharp.IconButton
    Friend WithEvents lblTotal As Label
    Friend WithEvents gridErrores As DataGridView
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents IdMerksyst As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
End Class
