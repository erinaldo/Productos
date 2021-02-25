<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormPreguntaCodigo
    Inherits System.Windows.Forms.Form

    Public Sub New(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByRef paroEncuesta As cEncuesta, ByRef paroPregunta As cPreguntaCodigo)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oCliente = paroCliente
        sVisitaClave = parsVisitaClave
        oPregunta = paroPregunta
        oEncuesta = paroEncuesta
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        oCliente = Nothing
        oEncuesta = Nothing
        oPregunta = Nothing
        If Not Me.MenuItemSalir Is Nothing Then Me.MenuItemSalir.Dispose()
        If Not Me.MainMenuPregunta Is Nothing Then Me.MainMenuPregunta.Dispose()
        If Not Me.pcbIcono Is Nothing Then
            Me.pcbIcono.Image = Nothing
            Me.pcbIcono.Dispose()
            Me.pcbIcono = Nothing
        End If
#If MOD_TERM <> "PALM" Then
        If Not bScanner Is Nothing Then bScanner.Dispose()
        bScanner = Nothing
#End If
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ItemTextBox1 As Resco.Controls.DetailView.ItemTextBox = New Resco.Controls.DetailView.ItemTextBox
        Me.MainMenuPregunta = New System.Windows.Forms.MainMenu
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pcbIcono = New System.Windows.Forms.PictureBox
        Me.txtRespuesta = New System.Windows.Forms.TextBox
        Me.ButtonSalir = New System.Windows.Forms.Button
        Me.DetailViewPregunta = New Resco.Controls.DetailView.DetailView
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.MenuItemSalir = New System.Windows.Forms.MenuItem
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuPregunta
        '
        Me.MainMenuPregunta.MenuItems.Add(Me.MenuItemSalir)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pcbIcono)
        Me.Panel1.Controls.Add(Me.txtRespuesta)
        Me.Panel1.Controls.Add(Me.ButtonSalir)
        Me.Panel1.Controls.Add(Me.DetailViewPregunta)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'pcbIcono
        '
        Me.pcbIcono.Location = New System.Drawing.Point(5, 8)
        Me.pcbIcono.Name = "pcbIcono"
        Me.pcbIcono.Size = New System.Drawing.Size(24, 24)
        Me.pcbIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'txtRespuesta
        '
        Me.txtRespuesta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRespuesta.Location = New System.Drawing.Point(5, 94)
        Me.txtRespuesta.Name = "txtRespuesta"
        Me.txtRespuesta.Size = New System.Drawing.Size(224, 23)
        Me.txtRespuesta.TabIndex = 12
        Me.txtRespuesta.TabStop = False
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Location = New System.Drawing.Point(155, 262)
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Size = New System.Drawing.Size(74, 24)
        Me.ButtonSalir.TabIndex = 11
        Me.ButtonSalir.Text = "ButtonSalir"
        Me.ButtonSalir.Visible = False
        '
        'DetailViewPregunta
        '
        Me.DetailViewPregunta.ForeColor = System.Drawing.SystemColors.ControlText
        ItemTextBox1.Height = 72
        ItemTextBox1.ItemBorder = Resco.Controls.DetailView.ItemBorder.None
        ItemTextBox1.MultiLine = True
        ItemTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        ItemTextBox1.WordWrap = True
        Me.DetailViewPregunta.Items.Add(ItemTextBox1)
        Me.DetailViewPregunta.LabelWidth = 0
        Me.DetailViewPregunta.Location = New System.Drawing.Point(30, 8)
        Me.DetailViewPregunta.Name = "DetailViewPregunta"
        Me.DetailViewPregunta.SeparatorWidth = 6
        Me.DetailViewPregunta.Size = New System.Drawing.Size(198, 72)
        Me.DetailViewPregunta.TabIndex = 7
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(5, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 9
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(80, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuar.TabIndex = 10
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'MenuItemSalir
        '
        Me.MenuItemSalir.Text = "MenuItemSalir"
        '
        'FormPreguntaCodigo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenuPregunta
        Me.Name = "FormPreguntaCodigo"
        Me.Text = "FormPreguntaCodigo"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainMenuPregunta As System.Windows.Forms.MainMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonSalir As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents txtRespuesta As System.Windows.Forms.TextBox
    Private WithEvents DetailViewPregunta As Resco.Controls.DetailView.DetailView
    Friend WithEvents pcbIcono As System.Windows.Forms.PictureBox
    Friend WithEvents MenuItemSalir As System.Windows.Forms.MenuItem
End Class
