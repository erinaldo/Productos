<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormPreguntaGPS
    Inherits System.Windows.Forms.Form

    Public Sub New(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByRef paroEncuesta As cEncuesta, ByRef paroPregunta As cPreguntaGPS)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oCliente = paroCliente
        sVisitaClave = parsVisitaClave
        oEncuesta = paroEncuesta
        oPregunta = paroPregunta
        Me.HabilitarBotones(False)
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
#If SO_WCE = 1 And MOD_TERM = "HHP" Then
        'oGPS.Dispose()
#End If
        If Not Me.TimerBloquear Is Nothing Then
            Me.TimerBloquear.Dispose()
            Me.TimerBloquear = Nothing
        End If
        If Not Me.TimerGPS Is Nothing Then
            Me.TimerGPS.Dispose()
            Me.TimerGPS = Nothing
        End If

        'oGPS = Nothing
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
        Dim ItemTextBox2 As Resco.Controls.DetailView.ItemTextBox = New Resco.Controls.DetailView.ItemTextBox
        Me.MainMenuPregunta = New System.Windows.Forms.MainMenu
        Me.MenuItemGPS = New System.Windows.Forms.MenuItem
        Me.MenuItemConectar = New System.Windows.Forms.MenuItem
        Me.MenuItemDesconectar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LabelSatelites = New System.Windows.Forms.Label
        Me.LabelStatus = New System.Windows.Forms.Label
        Me.LabelFechaHora = New System.Windows.Forms.Label
        Me.TextBoxFechaHora = New System.Windows.Forms.TextBox
        Me.LabelLongitud = New System.Windows.Forms.Label
        Me.TextBoxLongitud = New System.Windows.Forms.TextBox
        Me.LabelLatitud = New System.Windows.Forms.Label
        Me.TextBoxLatitud = New System.Windows.Forms.TextBox
        Me.LabelAltitud = New System.Windows.Forms.Label
        Me.TextBoxAltitud = New System.Windows.Forms.TextBox
        Me.pcbIcono = New System.Windows.Forms.PictureBox
        Me.ButtonSalir = New System.Windows.Forms.Button
        Me.DetailViewPregunta = New Resco.Controls.DetailView.DetailView
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.TimerGPS = New System.Windows.Forms.Timer
        Me.TimerBloquear = New System.Windows.Forms.Timer
        Me.MenuItemSalir = New System.Windows.Forms.MenuItem
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuPregunta
        '
        Me.MainMenuPregunta.MenuItems.Add(Me.MenuItemSalir)
        Me.MainMenuPregunta.MenuItems.Add(Me.MenuItemGPS)
        '
        'MenuItemGPS
        '
        Me.MenuItemGPS.MenuItems.Add(Me.MenuItemConectar)
        Me.MenuItemGPS.MenuItems.Add(Me.MenuItemDesconectar)
        Me.MenuItemGPS.Text = "MenuItemGPS"
        '
        'MenuItemConectar
        '
        Me.MenuItemConectar.Text = "MenuItemConectar"
        '
        'MenuItemDesconectar
        '
        Me.MenuItemDesconectar.Text = "MenuItemDesconectar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LabelSatelites)
        Me.Panel1.Controls.Add(Me.LabelStatus)
        Me.Panel1.Controls.Add(Me.LabelFechaHora)
        Me.Panel1.Controls.Add(Me.TextBoxFechaHora)
        Me.Panel1.Controls.Add(Me.LabelLongitud)
        Me.Panel1.Controls.Add(Me.TextBoxLongitud)
        Me.Panel1.Controls.Add(Me.LabelLatitud)
        Me.Panel1.Controls.Add(Me.TextBoxLatitud)
        Me.Panel1.Controls.Add(Me.LabelAltitud)
        Me.Panel1.Controls.Add(Me.TextBoxAltitud)
        Me.Panel1.Controls.Add(Me.pcbIcono)
        Me.Panel1.Controls.Add(Me.ButtonSalir)
        Me.Panel1.Controls.Add(Me.DetailViewPregunta)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'LabelSatelites
        '
        Me.LabelSatelites.Location = New System.Drawing.Point(3, 209)
        Me.LabelSatelites.Name = "LabelSatelites"
        Me.LabelSatelites.Size = New System.Drawing.Size(236, 20)
        Me.LabelSatelites.Text = "LabelSatelites"
        '
        'LabelStatus
        '
        Me.LabelStatus.Location = New System.Drawing.Point(3, 229)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(236, 28)
        Me.LabelStatus.Text = "LabelStatus"
        '
        'LabelFechaHora
        '
        Me.LabelFechaHora.Location = New System.Drawing.Point(5, 170)
        Me.LabelFechaHora.Name = "LabelFechaHora"
        Me.LabelFechaHora.Size = New System.Drawing.Size(79, 20)
        Me.LabelFechaHora.Text = "LabelFechaHora"
        '
        'TextBoxFechaHora
        '
        Me.TextBoxFechaHora.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxFechaHora.Location = New System.Drawing.Point(90, 170)
        Me.TextBoxFechaHora.Name = "TextBoxFechaHora"
        Me.TextBoxFechaHora.ReadOnly = True
        Me.TextBoxFechaHora.Size = New System.Drawing.Size(139, 23)
        Me.TextBoxFechaHora.TabIndex = 22
        Me.TextBoxFechaHora.TabStop = False
        '
        'LabelLongitud
        '
        Me.LabelLongitud.Location = New System.Drawing.Point(5, 143)
        Me.LabelLongitud.Name = "LabelLongitud"
        Me.LabelLongitud.Size = New System.Drawing.Size(79, 20)
        Me.LabelLongitud.Text = "LabelLongitud"
        '
        'TextBoxLongitud
        '
        Me.TextBoxLongitud.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxLongitud.Location = New System.Drawing.Point(90, 143)
        Me.TextBoxLongitud.Name = "TextBoxLongitud"
        Me.TextBoxLongitud.ReadOnly = True
        Me.TextBoxLongitud.Size = New System.Drawing.Size(139, 23)
        Me.TextBoxLongitud.TabIndex = 19
        Me.TextBoxLongitud.TabStop = False
        '
        'LabelLatitud
        '
        Me.LabelLatitud.Location = New System.Drawing.Point(5, 116)
        Me.LabelLatitud.Name = "LabelLatitud"
        Me.LabelLatitud.Size = New System.Drawing.Size(79, 20)
        Me.LabelLatitud.Text = "LabelLatitud"
        '
        'TextBoxLatitud
        '
        Me.TextBoxLatitud.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxLatitud.Location = New System.Drawing.Point(90, 116)
        Me.TextBoxLatitud.Name = "TextBoxLatitud"
        Me.TextBoxLatitud.ReadOnly = True
        Me.TextBoxLatitud.Size = New System.Drawing.Size(139, 23)
        Me.TextBoxLatitud.TabIndex = 16
        Me.TextBoxLatitud.TabStop = False
        '
        'LabelAltitud
        '
        Me.LabelAltitud.Location = New System.Drawing.Point(5, 89)
        Me.LabelAltitud.Name = "LabelAltitud"
        Me.LabelAltitud.Size = New System.Drawing.Size(79, 20)
        Me.LabelAltitud.Text = "LabelAltitud"
        '
        'TextBoxAltitud
        '
        Me.TextBoxAltitud.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxAltitud.Location = New System.Drawing.Point(90, 89)
        Me.TextBoxAltitud.Name = "TextBoxAltitud"
        Me.TextBoxAltitud.ReadOnly = True
        Me.TextBoxAltitud.Size = New System.Drawing.Size(139, 23)
        Me.TextBoxAltitud.TabIndex = 13
        Me.TextBoxAltitud.TabStop = False
        '
        'pcbIcono
        '
        Me.pcbIcono.Location = New System.Drawing.Point(5, 8)
        Me.pcbIcono.Name = "pcbIcono"
        Me.pcbIcono.Size = New System.Drawing.Size(24, 24)
        Me.pcbIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
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
        Me.DetailViewPregunta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DetailViewPregunta.ForeColor = System.Drawing.SystemColors.ControlText
        ItemTextBox2.Height = 60
        ItemTextBox2.ItemBorder = Resco.Controls.DetailView.ItemBorder.None
        ItemTextBox2.MultiLine = True
        ItemTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        ItemTextBox2.WordWrap = True
        Me.DetailViewPregunta.Items.Add(ItemTextBox2)
        Me.DetailViewPregunta.LabelWidth = 0
        Me.DetailViewPregunta.Location = New System.Drawing.Point(30, 8)
        Me.DetailViewPregunta.Name = "DetailViewPregunta"
        Me.DetailViewPregunta.SeparatorWidth = 6
        Me.DetailViewPregunta.Size = New System.Drawing.Size(198, 60)
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
        'TimerGPS
        '
        '
        '
        'TimerBloquear
        '
        Me.TimerBloquear.Enabled = True
        Me.TimerBloquear.Interval = 60000
        'MenuItemSalir
        '
        Me.MenuItemSalir.Text = "MenuItemSalir"
        '
        'FormPreguntaGPS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenuPregunta
        Me.Name = "FormPreguntaGPS"
        Me.Text = "FormPreguntaGPS"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainMenuPregunta As System.Windows.Forms.MainMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pcbIcono As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonSalir As System.Windows.Forms.Button
    Private WithEvents DetailViewPregunta As Resco.Controls.DetailView.DetailView
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents LabelStatus As System.Windows.Forms.Label
    Friend WithEvents LabelFechaHora As System.Windows.Forms.Label
    Friend WithEvents TextBoxFechaHora As System.Windows.Forms.TextBox
    Friend WithEvents LabelLongitud As System.Windows.Forms.Label
    Friend WithEvents TextBoxLongitud As System.Windows.Forms.TextBox
    Friend WithEvents LabelLatitud As System.Windows.Forms.Label
    Friend WithEvents TextBoxLatitud As System.Windows.Forms.TextBox
    Friend WithEvents LabelAltitud As System.Windows.Forms.Label
    Friend WithEvents TextBoxAltitud As System.Windows.Forms.TextBox
    Friend WithEvents LabelSatelites As System.Windows.Forms.Label
    Friend WithEvents MenuItemGPS As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemConectar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemDesconectar As System.Windows.Forms.MenuItem
    Friend WithEvents TimerGPS As System.Windows.Forms.Timer
    Friend WithEvents MenuItemSalir As System.Windows.Forms.MenuItem
    Friend WithEvents TimerBloquear As System.Windows.Forms.Timer
End Class
