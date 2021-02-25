<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormPreguntaMatricial
    Inherits System.Windows.Forms.Form


    Public Sub New(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByRef paroEncuesta As cEncuesta, ByRef paroPregunta As cPreguntaMatricial)
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
        If Not Me.grdMatricial Is Nothing Then Me.grdMatricial.Dispose()
        Me.grdMatricial = Nothing
        If Not Me.pcbIcono Is Nothing Then
            Me.pcbIcono.Image = Nothing
            Me.pcbIcono.Dispose()
            Me.pcbIcono = Nothing
        End If
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPreguntaMatricial))
        Dim ItemTextBox1 As Resco.Controls.DetailView.ItemTextBox = New Resco.Controls.DetailView.ItemTextBox
        Me.MainMenuPregunta = New System.Windows.Forms.MainMenu
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pcbIcono = New System.Windows.Forms.PictureBox
        Me.grdMatricial = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ButtonSalir = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.DetailViewPregunta = New Resco.Controls.DetailView.DetailView
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
        Me.Panel1.Controls.Add(Me.grdMatricial)
        Me.Panel1.Controls.Add(Me.ButtonSalir)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.DetailViewPregunta)
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
        'grdMatricial
        '
        Me.grdMatricial.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.grdMatricial.AllowEditing = True
        Me.grdMatricial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdMatricial.AutoResize = True
        Me.grdMatricial.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor
        Me.grdMatricial.AutoSearchDelay = 2
        Me.grdMatricial.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdMatricial.Clip = ""
        Me.grdMatricial.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.grdMatricial.Col = 1
        Me.grdMatricial.ColSel = 1
        Me.grdMatricial.ComboList = Nothing
        Me.grdMatricial.EditMask = Nothing
        Me.grdMatricial.ExtendLastCol = False
        Me.grdMatricial.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.grdMatricial.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grdMatricial.LeftCol = 1
        Me.grdMatricial.Location = New System.Drawing.Point(5, 58)
        Me.grdMatricial.Name = "grdMatricial"
        Me.grdMatricial.Redraw = True
        Me.grdMatricial.Row = 1
        Me.grdMatricial.RowSel = 1
        Me.grdMatricial.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.grdMatricial.ScrollTrack = True
        Me.grdMatricial.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.grdMatricial.ShowCursor = False
        Me.grdMatricial.ShowSort = True
        Me.grdMatricial.Size = New System.Drawing.Size(224, 200)
        Me.grdMatricial.StyleInfo = resources.GetString("grdMatricial.StyleInfo")
        Me.grdMatricial.SupportInfo = "jwDWACABcgE9AEoBCAGzAGwADgGuAMsAYgGiAAEBugAmAe0AowAOAWYAuwDGAI0AgwBSAAwBJwGLAKAAd" & _
            "QA="
        Me.grdMatricial.TabIndex = 12
        Me.grdMatricial.Text = "C1FlexGrid1"
        Me.grdMatricial.TopRow = 1
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
        'DetailViewPregunta
        '
        Me.DetailViewPregunta.ForeColor = System.Drawing.SystemColors.ControlText
        ItemTextBox1.Height = 46
        ItemTextBox1.ItemBorder = Resco.Controls.DetailView.ItemBorder.None
        ItemTextBox1.MultiLine = True
        ItemTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        ItemTextBox1.WordWrap = True
        Me.DetailViewPregunta.Items.Add(ItemTextBox1)
        Me.DetailViewPregunta.LabelWidth = 0
        Me.DetailViewPregunta.Location = New System.Drawing.Point(30, 8)
        Me.DetailViewPregunta.Name = "DetailViewPregunta"
        Me.DetailViewPregunta.SeparatorWidth = 6
        Me.DetailViewPregunta.Size = New System.Drawing.Size(198, 46)
        Me.DetailViewPregunta.TabIndex = 12
        '
        'MenuItemSalir
        '
        Me.MenuItemSalir.Text = "MenuItemSalir"
        '
        'FormPreguntaMatricial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenuPregunta
        Me.Name = "FormPreguntaMatricial"
        Me.Text = "FormPreguntaMatricial"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainMenuPregunta As System.Windows.Forms.MainMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonSalir As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents grdMatricial As C1.Win.C1FlexGrid.C1FlexGrid
    Private WithEvents DetailViewPregunta As Resco.Controls.DetailView.DetailView
    Friend WithEvents pcbIcono As System.Windows.Forms.PictureBox
    Friend WithEvents MenuItemSalir As System.Windows.Forms.MenuItem
End Class
