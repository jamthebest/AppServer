<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Server
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDesencriptado = New System.Windows.Forms.TextBox()
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Lista = New System.Windows.Forms.ListBox()
        Me.txtMD5 = New System.Windows.Forms.TextBox()
        Me.txtSalMD5 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSalDesencriptado = New System.Windows.Forms.TextBox()
        Me.txtSalEncriptado = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(13, 13)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(439, 385)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtMD5)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtDesencriptado)
        Me.TabPage1.Controls.Add(Me.txtMensaje)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(431, 359)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Input"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(278, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Desencriptado"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(82, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Encriptado"
        '
        'txtDesencriptado
        '
        Me.txtDesencriptado.Location = New System.Drawing.Point(220, 31)
        Me.txtDesencriptado.Multiline = True
        Me.txtDesencriptado.Name = "txtDesencriptado"
        Me.txtDesencriptado.Size = New System.Drawing.Size(205, 246)
        Me.txtDesencriptado.TabIndex = 1
        '
        'txtMensaje
        '
        Me.txtMensaje.Location = New System.Drawing.Point(7, 31)
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(206, 246)
        Me.txtMensaje.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtSalMD5)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.txtSalDesencriptado)
        Me.TabPage2.Controls.Add(Me.txtSalEncriptado)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(431, 359)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Output"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Lista
        '
        Me.Lista.FormattingEnabled = True
        Me.Lista.Location = New System.Drawing.Point(458, 35)
        Me.Lista.Name = "Lista"
        Me.Lista.Size = New System.Drawing.Size(161, 355)
        Me.Lista.TabIndex = 1
        '
        'txtMD5
        '
        Me.txtMD5.Location = New System.Drawing.Point(113, 284)
        Me.txtMD5.Multiline = True
        Me.txtMD5.Name = "txtMD5"
        Me.txtMD5.Size = New System.Drawing.Size(206, 69)
        Me.txtMD5.TabIndex = 4
        '
        'txtSalMD5
        '
        Me.txtSalMD5.Location = New System.Drawing.Point(112, 281)
        Me.txtSalMD5.Multiline = True
        Me.txtSalMD5.Name = "txtSalMD5"
        Me.txtSalMD5.Size = New System.Drawing.Size(206, 69)
        Me.txtSalMD5.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(277, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Desencriptado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(81, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Encriptado"
        '
        'txtSalDesencriptado
        '
        Me.txtSalDesencriptado.Location = New System.Drawing.Point(219, 28)
        Me.txtSalDesencriptado.Multiline = True
        Me.txtSalDesencriptado.Name = "txtSalDesencriptado"
        Me.txtSalDesencriptado.Size = New System.Drawing.Size(205, 246)
        Me.txtSalDesencriptado.TabIndex = 6
        '
        'txtSalEncriptado
        '
        Me.txtSalEncriptado.Location = New System.Drawing.Point(6, 28)
        Me.txtSalEncriptado.Multiline = True
        Me.txtSalEncriptado.Name = "txtSalEncriptado"
        Me.txtSalEncriptado.Size = New System.Drawing.Size(206, 246)
        Me.txtSalEncriptado.TabIndex = 5
        '
        'Server
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 410)
        Me.Controls.Add(Me.Lista)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Server"
        Me.Text = "Server"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Lista As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDesencriptado As System.Windows.Forms.TextBox
    Friend WithEvents txtMensaje As System.Windows.Forms.TextBox
    Friend WithEvents txtMD5 As System.Windows.Forms.TextBox
    Friend WithEvents txtSalMD5 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSalDesencriptado As System.Windows.Forms.TextBox
    Friend WithEvents txtSalEncriptado As System.Windows.Forms.TextBox
End Class
