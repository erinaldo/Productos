<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormKilometraje
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        If Not IsNothing(MenuItemRegresar) Then MenuItemRegresar.Dispose()
        If Not IsNothing(mainMenuKm) Then mainMenuKm.Dispose()
#If MOD_TERM <> "PALM" Then
        If Not bScanner Is Nothing Then bScanner.Dispose()
        bScanner = Nothing
#End If

        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private mainMenuKm As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenuKm = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.TextBoxKmFinal = New System.Windows.Forms.TextBox
        Me.LabelKmFinal = New System.Windows.Forms.Label
        Me.TextBoxKmInicial = New System.Windows.Forms.TextBox
        Me.LabelKmInicial = New System.Windows.Forms.Label
        Me.TextBoxClave = New System.Windows.Forms.TextBox
        Me.LabelClave = New System.Windows.Forms.Label
        Me.TextBoxPlaca = New System.Windows.Forms.TextBox
        Me.LabelPlaca = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMenuKm
        '
        Me.mainMenuKm.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "Regresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.TextBoxKmFinal)
        Me.Panel1.Controls.Add(Me.LabelKmFinal)
        Me.Panel1.Controls.Add(Me.TextBoxKmInicial)
        Me.Panel1.Controls.Add(Me.LabelKmInicial)
        Me.Panel1.Controls.Add(Me.TextBoxClave)
        Me.Panel1.Controls.Add(Me.LabelClave)
        Me.Panel1.Controls.Add(Me.TextBoxPlaca)
        Me.Panel1.Controls.Add(Me.LabelPlaca)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(90, 261)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 20)
        Me.ButtonRegresar.TabIndex = 12
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(12, 261)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 20)
        Me.ButtonContinuar.TabIndex = 11
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'TextBoxKmFinal
        '
        Me.TextBoxKmFinal.Location = New System.Drawing.Point(97, 126)
        Me.TextBoxKmFinal.Name = "TextBoxKmFinal"
        Me.TextBoxKmFinal.Size = New System.Drawing.Size(132, 23)
        Me.TextBoxKmFinal.TabIndex = 9
        '
        'LabelKmFinal
        '
        Me.LabelKmFinal.Location = New System.Drawing.Point(12, 127)
        Me.LabelKmFinal.Name = "LabelKmFinal"
        Me.LabelKmFinal.Size = New System.Drawing.Size(100, 20)
        Me.LabelKmFinal.Text = "LabelKmFinal"
        '
        'TextBoxKmInicial
        '
        Me.TextBoxKmInicial.Location = New System.Drawing.Point(97, 95)
        Me.TextBoxKmInicial.Name = "TextBoxKmInicial"
        Me.TextBoxKmInicial.Size = New System.Drawing.Size(132, 23)
        Me.TextBoxKmInicial.TabIndex = 6
        '
        'LabelKmInicial
        '
        Me.LabelKmInicial.Location = New System.Drawing.Point(12, 96)
        Me.LabelKmInicial.Name = "LabelKmInicial"
        Me.LabelKmInicial.Size = New System.Drawing.Size(100, 20)
        Me.LabelKmInicial.Text = "LabelKmInicial"
        '
        'TextBoxClave
        '
        Me.TextBoxClave.Location = New System.Drawing.Point(97, 64)
        Me.TextBoxClave.Name = "TextBoxClave"
        Me.TextBoxClave.Size = New System.Drawing.Size(132, 23)
        Me.TextBoxClave.TabIndex = 3
        '
        'LabelClave
        '
        Me.LabelClave.Location = New System.Drawing.Point(12, 65)
        Me.LabelClave.Name = "LabelClave"
        Me.LabelClave.Size = New System.Drawing.Size(100, 20)
        Me.LabelClave.Text = "LabelClave"
        '
        'TextBoxPlaca
        '
        Me.TextBoxPlaca.Location = New System.Drawing.Point(97, 33)
        Me.TextBoxPlaca.Name = "TextBoxPlaca"
        Me.TextBoxPlaca.Size = New System.Drawing.Size(132, 23)
        Me.TextBoxPlaca.TabIndex = 1
        '
        'LabelPlaca
        '
        Me.LabelPlaca.Location = New System.Drawing.Point(12, 34)
        Me.LabelPlaca.Name = "LabelPlaca"
        Me.LabelPlaca.Size = New System.Drawing.Size(100, 20)
        Me.LabelPlaca.Text = "LabelPlaca"
        '
        'FormKilometraje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.mainMenuKm
        Me.MinimizeBox = False
        Me.Name = "FormKilometraje"
        Me.Text = "FormKilometraje"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents TextBoxKmFinal As System.Windows.Forms.TextBox
    Friend WithEvents LabelKmFinal As System.Windows.Forms.Label
    Friend WithEvents TextBoxKmInicial As System.Windows.Forms.TextBox
    Friend WithEvents LabelKmInicial As System.Windows.Forms.Label
    Friend WithEvents LabelClave As System.Windows.Forms.Label
    Friend WithEvents TextBoxPlaca As System.Windows.Forms.TextBox
    Friend WithEvents LabelPlaca As System.Windows.Forms.Label
    Friend WithEvents TextBoxClave As System.Windows.Forms.TextBox
End Class
