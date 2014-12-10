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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Server))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtMD5 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDesencriptado = New System.Windows.Forms.TextBox()
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtSalMD5 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSalDesencriptado = New System.Windows.Forms.TextBox()
        Me.txtSalEncriptado = New System.Windows.Forms.TextBox()
        Me.Lista = New System.Windows.Forms.ListBox()
        Me.txtPuerto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnBitacora = New System.Windows.Forms.Button()
        Me.btnBoton = New System.Windows.Forms.Button()
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
        'txtMD5
        '
        Me.txtMD5.Location = New System.Drawing.Point(113, 284)
        Me.txtMD5.Multiline = True
        Me.txtMD5.Name = "txtMD5"
        Me.txtMD5.ReadOnly = True
        Me.txtMD5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMD5.Size = New System.Drawing.Size(206, 69)
        Me.txtMD5.TabIndex = 4
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
        Me.txtDesencriptado.ReadOnly = True
        Me.txtDesencriptado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDesencriptado.Size = New System.Drawing.Size(205, 246)
        Me.txtDesencriptado.TabIndex = 1
        '
        'txtMensaje
        '
        Me.txtMensaje.Location = New System.Drawing.Point(7, 31)
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.ReadOnly = True
        Me.txtMensaje.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
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
        'txtSalMD5
        '
        Me.txtSalMD5.Location = New System.Drawing.Point(112, 281)
        Me.txtSalMD5.Multiline = True
        Me.txtSalMD5.Name = "txtSalMD5"
        Me.txtSalMD5.ReadOnly = True
        Me.txtSalMD5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
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
        Me.txtSalDesencriptado.ReadOnly = True
        Me.txtSalDesencriptado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSalDesencriptado.Size = New System.Drawing.Size(205, 246)
        Me.txtSalDesencriptado.TabIndex = 6
        '
        'txtSalEncriptado
        '
        Me.txtSalEncriptado.Location = New System.Drawing.Point(6, 28)
        Me.txtSalEncriptado.Multiline = True
        Me.txtSalEncriptado.Name = "txtSalEncriptado"
        Me.txtSalEncriptado.ReadOnly = True
        Me.txtSalEncriptado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSalEncriptado.Size = New System.Drawing.Size(206, 246)
        Me.txtSalEncriptado.TabIndex = 5
        '
        'Lista
        '
        Me.Lista.FormattingEnabled = True
        Me.Lista.Location = New System.Drawing.Point(458, 35)
        Me.Lista.Name = "Lista"
        Me.Lista.Size = New System.Drawing.Size(161, 355)
        Me.Lista.TabIndex = 1
        '
        'txtPuerto
        '
        Me.txtPuerto.Location = New System.Drawing.Point(227, 424)
        Me.txtPuerto.Name = "txtPuerto"
        Me.txtPuerto.Size = New System.Drawing.Size(100, 20)
        Me.txtPuerto.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(162, 427)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Puerto"
        '
        'btnBitacora
        '
        Me.btnBitacora.Image = Global.ProyectoServer.My.Resources.Resources.log
        Me.btnBitacora.Location = New System.Drawing.Point(513, 401)
        Me.btnBitacora.Name = "btnBitacora"
        Me.btnBitacora.Size = New System.Drawing.Size(50, 50)
        Me.btnBitacora.TabIndex = 5
        Me.btnBitacora.UseVisualStyleBackColor = True
        '
        'btnBoton
        '
        Me.btnBoton.Image = Global.ProyectoServer.My.Resources.Resources.Encender
        Me.btnBoton.Location = New System.Drawing.Point(47, 404)
        Me.btnBoton.Name = "btnBoton"
        Me.btnBoton.Size = New System.Drawing.Size(50, 50)
        Me.btnBoton.TabIndex = 2
        Me.btnBoton.UseVisualStyleBackColor = True
        '
        'Server
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 457)
        Me.Controls.Add(Me.btnBitacora)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPuerto)
        Me.Controls.Add(Me.btnBoton)
        Me.Controls.Add(Me.Lista)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Server"
        Me.Text = "Server"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents btnBoton As System.Windows.Forms.Button
    Friend WithEvents txtPuerto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBitacora As System.Windows.Forms.Button
End Class
