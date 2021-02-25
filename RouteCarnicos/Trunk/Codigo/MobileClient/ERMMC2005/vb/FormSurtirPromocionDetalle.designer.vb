<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormSurtirPromocionDetalle
    Inherits System.Windows.Forms.Form

    Public Sub New(ByVal parsTransProdId As String, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByVal paroMMDA As Modulos.GrupoModuloMovDetalle)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        sTransProdId = parsTransProdId
        oCliente = paroCliente
        sVisitaClave = parsVisitaClave
        oMMDA = paroMMDA
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenuPromo Is Nothing Then Me.MainMenuPromo.Dispose()
        If Not Me.fgPromociones Is Nothing Then Me.fgPromociones.Dispose()
        Me.fgPromociones = Nothing
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private MainMenuPromo As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSurtirPromocionDetalle))
        Me.MainMenuPromo = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.fgPromociones = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.PanelFecha = New System.Windows.Forms.Panel
        Me.TextBoxFecha = New System.Windows.Forms.TextBox
        Me.LabelFecha = New System.Windows.Forms.Label
        Me.PanelConsulta = New System.Windows.Forms.Panel
        Me.LabelFase = New System.Windows.Forms.Label
        Me.TextBoxFase = New System.Windows.Forms.TextBox
        Me.LabelFolio = New System.Windows.Forms.Label
        Me.TextBoxFolio = New System.Windows.Forms.TextBox
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonTerminar = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.PanelFecha.SuspendLayout()
        Me.PanelConsulta.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuPromo
        '
        Me.MainMenuPromo.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.fgPromociones)
        Me.Panel1.Controls.Add(Me.PanelFecha)
        Me.Panel1.Controls.Add(Me.PanelConsulta)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonTerminar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'fgPromociones
        '
        Me.fgPromociones.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fgPromociones.AllowEditing = False
        Me.fgPromociones.AutoResize = True
        Me.fgPromociones.AutoSearchDelay = 2
        Me.fgPromociones.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fgPromociones.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgPromociones.Clip = ""
        Me.fgPromociones.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.fgPromociones.Col = 1
        Me.fgPromociones.ColSel = 1
        Me.fgPromociones.ComboList = Nothing
        Me.fgPromociones.EditMask = Nothing
        Me.fgPromociones.ExtendLastCol = False
        Me.fgPromociones.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.fgPromociones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgPromociones.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgPromociones.LeftCol = 1
        Me.fgPromociones.Location = New System.Drawing.Point(7, 96)
        Me.fgPromociones.Name = "fgPromociones"
        Me.fgPromociones.Redraw = True
        Me.fgPromociones.Row = 1
        Me.fgPromociones.RowSel = 1
        Me.fgPromociones.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.fgPromociones.ScrollTrack = True
        Me.fgPromociones.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgPromociones.ShowCursor = False
        Me.fgPromociones.ShowSort = True
        Me.fgPromociones.Size = New System.Drawing.Size(226, 166)
        Me.fgPromociones.StyleInfo = resources.GetString("fgPromociones.StyleInfo")
        Me.fgPromociones.SupportInfo = "BgEuAeIAMgFgAPwA/ABHAXYAIAEqAWIBMgEjAXsAdwDXACMBdwCcABUBYQCpAL8A6wB5ANoAkwBLAMMAx" & _
            "gCcAA=="
        Me.fgPromociones.TabIndex = 26
        Me.fgPromociones.Text = "C1FlexGrid1"
        Me.fgPromociones.TopRow = 1
        '
        'PanelFecha
        '
        Me.PanelFecha.Controls.Add(Me.TextBoxFecha)
        Me.PanelFecha.Controls.Add(Me.LabelFecha)
        Me.PanelFecha.Location = New System.Drawing.Point(0, 67)
        Me.PanelFecha.Name = "PanelFecha"
        Me.PanelFecha.Size = New System.Drawing.Size(236, 28)
        '
        'TextBoxFecha
        '
        Me.TextBoxFecha.Enabled = False
        Me.TextBoxFecha.Location = New System.Drawing.Point(123, 2)
        Me.TextBoxFecha.Name = "TextBoxFecha"
        Me.TextBoxFecha.Size = New System.Drawing.Size(110, 23)
        Me.TextBoxFecha.TabIndex = 28
        '
        'LabelFecha
        '
        Me.LabelFecha.Location = New System.Drawing.Point(3, 4)
        Me.LabelFecha.Name = "LabelFecha"
        Me.LabelFecha.Size = New System.Drawing.Size(119, 19)
        Me.LabelFecha.Text = "LabelFecha"
        '
        'PanelConsulta
        '
        Me.PanelConsulta.Controls.Add(Me.LabelFase)
        Me.PanelConsulta.Controls.Add(Me.TextBoxFase)
        Me.PanelConsulta.Controls.Add(Me.LabelFolio)
        Me.PanelConsulta.Controls.Add(Me.TextBoxFolio)
        Me.PanelConsulta.Location = New System.Drawing.Point(0, 16)
        Me.PanelConsulta.Name = "PanelConsulta"
        Me.PanelConsulta.Size = New System.Drawing.Size(236, 52)
        '
        'LabelFase
        '
        Me.LabelFase.Location = New System.Drawing.Point(3, 29)
        Me.LabelFase.Name = "LabelFase"
        Me.LabelFase.Size = New System.Drawing.Size(119, 14)
        Me.LabelFase.Text = "LabelFase"
        '
        'TextBoxFase
        '
        Me.TextBoxFase.Enabled = False
        Me.TextBoxFase.Location = New System.Drawing.Point(123, 27)
        Me.TextBoxFase.Name = "TextBoxFase"
        Me.TextBoxFase.Size = New System.Drawing.Size(110, 23)
        Me.TextBoxFase.TabIndex = 35
        '
        'LabelFolio
        '
        Me.LabelFolio.Location = New System.Drawing.Point(3, 4)
        Me.LabelFolio.Name = "LabelFolio"
        Me.LabelFolio.Size = New System.Drawing.Size(119, 19)
        Me.LabelFolio.Text = "LabelFolio"
        '
        'TextBoxFolio
        '
        Me.TextBoxFolio.Enabled = False
        Me.TextBoxFolio.Location = New System.Drawing.Point(123, 2)
        Me.TextBoxFolio.Name = "TextBoxFolio"
        Me.TextBoxFolio.Size = New System.Drawing.Size(110, 23)
        Me.TextBoxFolio.TabIndex = 31
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(85, 265)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 3
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonTerminar
        '
        Me.ButtonTerminar.Location = New System.Drawing.Point(5, 265)
        Me.ButtonTerminar.Name = "ButtonTerminar"
        Me.ButtonTerminar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonTerminar.TabIndex = 4
        Me.ButtonTerminar.Text = "ButtonTerminar"
        '
        'FormSurtirPromocionDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenuPromo
        Me.Name = "FormSurtirPromocionDetalle"
        Me.Text = "FormSurtirPromocionDetalle"
        Me.Panel1.ResumeLayout(False)
        Me.PanelFecha.ResumeLayout(False)
        Me.PanelConsulta.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonTerminar As System.Windows.Forms.Button
    Friend WithEvents fgPromociones As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TextBoxFecha As System.Windows.Forms.TextBox
    Friend WithEvents LabelFecha As System.Windows.Forms.Label
    Friend WithEvents LabelFase As System.Windows.Forms.Label
    Friend WithEvents TextBoxFase As System.Windows.Forms.TextBox
    Friend WithEvents LabelFolio As System.Windows.Forms.Label
    Friend WithEvents TextBoxFolio As System.Windows.Forms.TextBox
    Private WithEvents PanelConsulta As System.Windows.Forms.Panel
    Friend WithEvents PanelFecha As System.Windows.Forms.Panel
End Class
