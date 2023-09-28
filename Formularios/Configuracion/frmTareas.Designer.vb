<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTareas
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
        Me.chkAutomatico = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.Panel()
        Me.chkDia0 = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkSucusrales = New System.Windows.Forms.CheckBox()
        Me.chkDia6 = New System.Windows.Forms.CheckBox()
        Me.chkDia5 = New System.Windows.Forms.CheckBox()
        Me.chkDia4 = New System.Windows.Forms.CheckBox()
        Me.chkDia3 = New System.Windows.Forms.CheckBox()
        Me.chkDia2 = New System.Windows.Forms.CheckBox()
        Me.chkDia1 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMinutos = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkAutomatico
        '
        Me.chkAutomatico.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkAutomatico.AutoSize = True
        Me.chkAutomatico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutomatico.Location = New System.Drawing.Point(164, 12)
        Me.chkAutomatico.Name = "chkAutomatico"
        Me.chkAutomatico.Size = New System.Drawing.Size(148, 20)
        Me.chkAutomatico.TabIndex = 0
        Me.chkAutomatico.Text = "Activar repeticion"
        Me.chkAutomatico.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GroupBox1.Controls.Add(Me.chkDia0)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.chkSucusrales)
        Me.GroupBox1.Controls.Add(Me.chkDia6)
        Me.GroupBox1.Controls.Add(Me.chkDia5)
        Me.GroupBox1.Controls.Add(Me.chkDia4)
        Me.GroupBox1.Controls.Add(Me.chkDia3)
        Me.GroupBox1.Controls.Add(Me.chkDia2)
        Me.GroupBox1.Controls.Add(Me.chkDia1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtMinutos)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(419, 383)
        Me.GroupBox1.TabIndex = 1
        '
        'chkDia0
        '
        Me.chkDia0.AutoSize = True
        Me.chkDia0.Location = New System.Drawing.Point(54, 216)
        Me.chkDia0.Name = "chkDia0"
        Me.chkDia0.Size = New System.Drawing.Size(82, 20)
        Me.chkDia0.TabIndex = 10
        Me.chkDia0.Text = "Domingo"
        Me.chkDia0.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Location = New System.Drawing.Point(206, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(197, 315)
        Me.Panel1.TabIndex = 9
        '
        'chkSucusrales
        '
        Me.chkSucusrales.AutoSize = True
        Me.chkSucusrales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSucusrales.Location = New System.Drawing.Point(206, 21)
        Me.chkSucusrales.Name = "chkSucusrales"
        Me.chkSucusrales.Size = New System.Drawing.Size(110, 20)
        Me.chkSucusrales.TabIndex = 8
        Me.chkSucusrales.Text = "Marcar todo"
        Me.chkSucusrales.UseVisualStyleBackColor = True
        '
        'chkDia6
        '
        Me.chkDia6.AutoSize = True
        Me.chkDia6.Location = New System.Drawing.Point(54, 190)
        Me.chkDia6.Name = "chkDia6"
        Me.chkDia6.Size = New System.Drawing.Size(76, 20)
        Me.chkDia6.TabIndex = 7
        Me.chkDia6.Text = "Sabado"
        Me.chkDia6.UseVisualStyleBackColor = True
        '
        'chkDia5
        '
        Me.chkDia5.AutoSize = True
        Me.chkDia5.Location = New System.Drawing.Point(54, 164)
        Me.chkDia5.Name = "chkDia5"
        Me.chkDia5.Size = New System.Drawing.Size(73, 20)
        Me.chkDia5.TabIndex = 6
        Me.chkDia5.Text = "Viernes"
        Me.chkDia5.UseVisualStyleBackColor = True
        '
        'chkDia4
        '
        Me.chkDia4.AutoSize = True
        Me.chkDia4.Location = New System.Drawing.Point(54, 138)
        Me.chkDia4.Name = "chkDia4"
        Me.chkDia4.Size = New System.Drawing.Size(71, 20)
        Me.chkDia4.TabIndex = 5
        Me.chkDia4.Text = "Jueves"
        Me.chkDia4.UseVisualStyleBackColor = True
        '
        'chkDia3
        '
        Me.chkDia3.AutoSize = True
        Me.chkDia3.Location = New System.Drawing.Point(54, 112)
        Me.chkDia3.Name = "chkDia3"
        Me.chkDia3.Size = New System.Drawing.Size(86, 20)
        Me.chkDia3.TabIndex = 4
        Me.chkDia3.Text = "Miercoles"
        Me.chkDia3.UseVisualStyleBackColor = True
        '
        'chkDia2
        '
        Me.chkDia2.AutoSize = True
        Me.chkDia2.Location = New System.Drawing.Point(54, 86)
        Me.chkDia2.Name = "chkDia2"
        Me.chkDia2.Size = New System.Drawing.Size(68, 20)
        Me.chkDia2.TabIndex = 3
        Me.chkDia2.Text = "Martes"
        Me.chkDia2.UseVisualStyleBackColor = True
        '
        'chkDia1
        '
        Me.chkDia1.AutoSize = True
        Me.chkDia1.Location = New System.Drawing.Point(54, 60)
        Me.chkDia1.Name = "chkDia1"
        Me.chkDia1.Size = New System.Drawing.Size(63, 20)
        Me.chkDia1.TabIndex = 2
        Me.chkDia1.Text = "Lunes"
        Me.chkDia1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(119, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Minutos"
        '
        'txtMinutos
        '
        Me.txtMinutos.Location = New System.Drawing.Point(54, 18)
        Me.txtMinutos.Name = "txtMinutos"
        Me.txtMinutos.Size = New System.Drawing.Size(59, 22)
        Me.txtMinutos.TabIndex = 0
        Me.txtMinutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGuardar.Location = New System.Drawing.Point(105, 427)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(189, 27)
        Me.btnGuardar.TabIndex = 20
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'frmTareas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(445, 462)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkAutomatico)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmTareas"
        Me.Text = "frmTareas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkAutomatico As CheckBox
    Friend WithEvents GroupBox1 As Panel
    Friend WithEvents chkDia6 As CheckBox
    Friend WithEvents chkDia5 As CheckBox
    Friend WithEvents chkDia4 As CheckBox
    Friend WithEvents chkDia3 As CheckBox
    Friend WithEvents chkDia2 As CheckBox
    Friend WithEvents chkDia1 As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMinutos As TextBox
    Friend WithEvents chkSucusrales As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents chkDia0 As CheckBox
End Class
