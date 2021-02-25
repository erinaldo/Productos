Imports System.Reflection
Imports System.Security.Permissions
Imports DevComponents.DotNetBar
Imports System.Drawing
Imports System.IO

Public Class FormaPadre
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents SideBar1 As DevComponents.DotNetBar.SideBar
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabControl2 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem3 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabStrip1 As DevComponents.DotNetBar.TabStrip
    Friend WithEvents DotNetBarManager1 As DevComponents.DotNetBar.DotNetBarManager
    Friend WithEvents barLeftDockSite As DevComponents.DotNetBar.DockSite
    Friend WithEvents barRightDockSite As DevComponents.DotNetBar.DockSite
    Friend WithEvents barTopDockSite As DevComponents.DotNetBar.DockSite
    Friend WithEvents barBottomDockSite As DevComponents.DotNetBar.DockSite
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem7 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ExpandableSplitter1 As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TmrTiempo As System.Windows.Forms.Timer
    Friend WithEvents DockSite1 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite2 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite3 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite5 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite6 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite7 As DevComponents.DotNetBar.DockSite
    Friend WithEvents mainmenu As DevComponents.DotNetBar.Bar
    Friend WithEvents DockSite8 As DevComponents.DotNetBar.DockSite
    Friend WithEvents statusBar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents lbUsuario As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lbFechaHora As DevComponents.DotNetBar.LabelItem
    Friend WithEvents DockSite4 As DevComponents.DotNetBar.DockSite
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormaPadre))
        Me.SideBar1 = New DevComponents.DotNetBar.SideBar
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControl2 = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabItem3 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabStrip1 = New DevComponents.DotNetBar.TabStrip
        Me.DotNetBarManager1 = New DevComponents.DotNetBar.DotNetBarManager(Me.components)
        Me.barBottomDockSite = New DevComponents.DotNetBar.DockSite
        Me.barLeftDockSite = New DevComponents.DotNetBar.DockSite
        Me.barRightDockSite = New DevComponents.DotNetBar.DockSite
        Me.DockSite8 = New DevComponents.DotNetBar.DockSite
        Me.statusBar2 = New DevComponents.DotNetBar.Bar
        Me.lbUsuario = New DevComponents.DotNetBar.LabelItem
        Me.lbFechaHora = New DevComponents.DotNetBar.LabelItem
        Me.DockSite5 = New DevComponents.DotNetBar.DockSite
        Me.DockSite6 = New DevComponents.DotNetBar.DockSite
        Me.DockSite7 = New DevComponents.DotNetBar.DockSite
        Me.mainmenu = New DevComponents.DotNetBar.Bar
        Me.barTopDockSite = New DevComponents.DotNetBar.DockSite
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem7 = New DevComponents.DotNetBar.ButtonItem
        Me.ExpandableSplitter1 = New DevComponents.DotNetBar.ExpandableSplitter
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TmrTiempo = New System.Windows.Forms.Timer(Me.components)
        Me.DockSite1 = New DevComponents.DotNetBar.DockSite
        Me.DockSite2 = New DevComponents.DotNetBar.DockSite
        Me.DockSite3 = New DevComponents.DotNetBar.DockSite
        Me.DockSite4 = New DevComponents.DotNetBar.DockSite
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl2.SuspendLayout()
        Me.DockSite8.SuspendLayout()
        CType(Me.statusBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockSite7.SuspendLayout()
        CType(Me.mainmenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SideBar1
        '
        Me.SideBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.SideBar1.AllowUserCustomize = False
        Me.SideBar1.Appearance = DevComponents.DotNetBar.eSideBarAppearance.Flat
        Me.SideBar1.BackColor = System.Drawing.SystemColors.Control
        Me.SideBar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.SideBar1.ExpandedPanel = Nothing
        Me.SideBar1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.SideBar1.Location = New System.Drawing.Point(0, 25)
        Me.SideBar1.Name = "SideBar1"
        Me.SideBar1.Size = New System.Drawing.Size(168, 673)
        Me.SideBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.SideBar1.TabIndex = 1
        Me.SideBar1.Text = "SideBar1"
        Me.SideBar1.UsingSystemColors = True
        '
        'TabControl1
        '
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Location = New System.Drawing.Point(240, 208)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(256, 152)
        Me.TabControl1.TabIndex = 4
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem1)
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(256, 126)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.TabItem1
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "TabItem1"
        '
        'TabControl2
        '
        Me.TabControl2.CanReorderTabs = True
        Me.TabControl2.Controls.Add(Me.TabControlPanel2)
        Me.TabControl2.Location = New System.Drawing.Point(368, 200)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl2.SelectedTabIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(848, 712)
        Me.TabControl2.TabIndex = 4
        Me.TabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl2.Tabs.Add(Me.TabItem2)
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(848, 686)
        Me.TabControlPanel2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(124, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 1
        Me.TabControlPanel2.TabItem = Me.TabItem2
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel2
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "TabItem2"
        '
        'TabItem3
        '
        Me.TabItem3.Name = "TabItem3"
        Me.TabItem3.Text = "TabItem3"
        '
        'TabStrip1
        '
        Me.TabStrip1.AutoSelectAttachedControl = True
        Me.TabStrip1.CanReorderTabs = True
        Me.TabStrip1.CloseButtonVisible = True
        Me.TabStrip1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabStrip1.Location = New System.Drawing.Point(174, 25)
        Me.TabStrip1.MdiTabbedDocuments = True
        Me.TabStrip1.Name = "TabStrip1"
        Me.TabStrip1.SelectedTab = Nothing
        Me.TabStrip1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabStrip1.Size = New System.Drawing.Size(828, 26)
        Me.TabStrip1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document
        Me.TabStrip1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top
        Me.TabStrip1.TabIndex = 7
        Me.TabStrip1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabStrip1.Text = "TabStrip1"
        '
        'DotNetBarManager1
        '
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.F1)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Del)
        Me.DotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Ins)
        Me.DotNetBarManager1.BottomDockSite = Me.barBottomDockSite
        Me.DotNetBarManager1.DefinitionName = ""
        Me.DotNetBarManager1.LeftDockSite = Me.barLeftDockSite
        Me.DotNetBarManager1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.DotNetBarManager1.MdiSystemItemVisible = False
        Me.DotNetBarManager1.ParentForm = Me
        Me.DotNetBarManager1.RightDockSite = Me.barRightDockSite
        Me.DotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.DotNetBarManager1.ToolbarBottomDockSite = Me.DockSite8
        Me.DotNetBarManager1.ToolbarLeftDockSite = Me.DockSite5
        Me.DotNetBarManager1.ToolbarRightDockSite = Me.DockSite6
        Me.DotNetBarManager1.ToolbarTopDockSite = Me.DockSite7
        Me.DotNetBarManager1.TopDockSite = Me.barTopDockSite
        Me.DotNetBarManager1.UseGlobalColorScheme = True
        '
        'barBottomDockSite
        '
        Me.barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.barBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barBottomDockSite.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer
        Me.barBottomDockSite.Location = New System.Drawing.Point(174, 698)
        Me.barBottomDockSite.Name = "barBottomDockSite"
        Me.barBottomDockSite.Size = New System.Drawing.Size(828, 0)
        Me.barBottomDockSite.TabIndex = 12
        Me.barBottomDockSite.TabStop = False
        '
        'barLeftDockSite
        '
        Me.barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.barLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left
        Me.barLeftDockSite.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer
        Me.barLeftDockSite.Location = New System.Drawing.Point(174, 25)
        Me.barLeftDockSite.Name = "barLeftDockSite"
        Me.barLeftDockSite.Size = New System.Drawing.Size(0, 673)
        Me.barLeftDockSite.TabIndex = 9
        Me.barLeftDockSite.TabStop = False
        '
        'barRightDockSite
        '
        Me.barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.barRightDockSite.Dock = System.Windows.Forms.DockStyle.Right
        Me.barRightDockSite.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer
        Me.barRightDockSite.Location = New System.Drawing.Point(1002, 25)
        Me.barRightDockSite.Name = "barRightDockSite"
        Me.barRightDockSite.Size = New System.Drawing.Size(0, 673)
        Me.barRightDockSite.TabIndex = 10
        Me.barRightDockSite.TabStop = False
        '
        'DockSite8
        '
        Me.DockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite8.Controls.Add(Me.statusBar2)
        Me.DockSite8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DockSite8.Location = New System.Drawing.Point(0, 698)
        Me.DockSite8.Name = "DockSite8"
        Me.DockSite8.Size = New System.Drawing.Size(1002, 22)
        Me.DockSite8.TabIndex = 26
        Me.DockSite8.TabStop = False
        '
        'statusBar2
        '
        Me.statusBar2.AccessibleDescription = "Status (statusBar2)"
        Me.statusBar2.AccessibleName = "Status"
        Me.statusBar2.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.statusBar2.DockSide = DevComponents.DotNetBar.eDockSide.Bottom
        Me.statusBar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.lbUsuario, Me.lbFechaHora})
        Me.statusBar2.ItemSpacing = 2
        Me.statusBar2.Location = New System.Drawing.Point(0, 0)
        Me.statusBar2.Name = "statusBar2"
        Me.statusBar2.Size = New System.Drawing.Size(1002, 21)
        Me.statusBar2.Stretch = True
        Me.statusBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.statusBar2.TabIndex = 0
        Me.statusBar2.TabStop = False
        Me.statusBar2.Text = "Status"
        '
        'lbUsuario
        '
        Me.lbUsuario.BorderType = DevComponents.DotNetBar.eBorderType.None
        Me.lbUsuario.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbUsuario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.lbUsuario.GlobalName = "lbUsuario"
        Me.lbUsuario.Icon = CType(resources.GetObject("lbUsuario.Icon"), System.Drawing.Icon)
        Me.lbUsuario.Name = "lbUsuario"
        Me.lbUsuario.PaddingLeft = 5
        Me.lbUsuario.PaddingRight = 5
        Me.lbUsuario.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.lbUsuario.Text = "José Ramiro Ceballos Méndez"
        '
        'lbFechaHora
        '
        Me.lbFechaHora.BorderType = DevComponents.DotNetBar.eBorderType.None
        Me.lbFechaHora.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbFechaHora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.lbFechaHora.GlobalName = "lbFechaHora"
        Me.lbFechaHora.Icon = CType(resources.GetObject("lbFechaHora.Icon"), System.Drawing.Icon)
        Me.lbFechaHora.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.lbFechaHora.Name = "lbFechaHora"
        Me.lbFechaHora.PaddingLeft = 5
        Me.lbFechaHora.PaddingRight = 5
        Me.lbFechaHora.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.lbFechaHora.Text = "10 de Marzo de 2006"
        '
        'DockSite5
        '
        Me.DockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite5.Dock = System.Windows.Forms.DockStyle.Left
        Me.DockSite5.Location = New System.Drawing.Point(0, 25)
        Me.DockSite5.Name = "DockSite5"
        Me.DockSite5.Size = New System.Drawing.Size(0, 673)
        Me.DockSite5.TabIndex = 23
        Me.DockSite5.TabStop = False
        '
        'DockSite6
        '
        Me.DockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite6.Dock = System.Windows.Forms.DockStyle.Right
        Me.DockSite6.Location = New System.Drawing.Point(1002, 25)
        Me.DockSite6.Name = "DockSite6"
        Me.DockSite6.Size = New System.Drawing.Size(0, 673)
        Me.DockSite6.TabIndex = 24
        Me.DockSite6.TabStop = False
        '
        'DockSite7
        '
        Me.DockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite7.Controls.Add(Me.mainmenu)
        Me.DockSite7.Dock = System.Windows.Forms.DockStyle.Top
        Me.DockSite7.Location = New System.Drawing.Point(0, 0)
        Me.DockSite7.Name = "DockSite7"
        Me.DockSite7.Size = New System.Drawing.Size(1002, 25)
        Me.DockSite7.TabIndex = 25
        Me.DockSite7.TabStop = False
        '
        'mainmenu
        '
        Me.mainmenu.AccessibleDescription = "DotNetBar Bar (mainmenu)"
        Me.mainmenu.AccessibleName = "DotNetBar Bar"
        Me.mainmenu.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.mainmenu.DockSide = DevComponents.DotNetBar.eDockSide.Top
        Me.mainmenu.Location = New System.Drawing.Point(0, 0)
        Me.mainmenu.MenuBar = True
        Me.mainmenu.Name = "mainmenu"
        Me.mainmenu.Size = New System.Drawing.Size(36, 24)
        Me.mainmenu.Stretch = True
        Me.mainmenu.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.mainmenu.TabIndex = 0
        Me.mainmenu.TabStop = False
        Me.mainmenu.Text = "Main Menu"
        '
        'barTopDockSite
        '
        Me.barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.barTopDockSite.Dock = System.Windows.Forms.DockStyle.Top
        Me.barTopDockSite.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer
        Me.barTopDockSite.Location = New System.Drawing.Point(0, 25)
        Me.barTopDockSite.Name = "barTopDockSite"
        Me.barTopDockSite.Size = New System.Drawing.Size(1002, 0)
        Me.barTopDockSite.TabIndex = 11
        Me.barTopDockSite.TabStop = False
        '
        'ButtonItem5
        '
        Me.ButtonItem5.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.SubItemsExpandWidth = 11
        Me.ButtonItem5.Text = "New Button"
        '
        'ButtonItem6
        '
        Me.ButtonItem6.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem6.Name = "ButtonItem6"
        Me.ButtonItem6.SubItemsExpandWidth = 11
        Me.ButtonItem6.Text = "New Button"
        '
        'ButtonItem7
        '
        Me.ButtonItem7.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem7.Name = "ButtonItem7"
        Me.ButtonItem7.SubItemsExpandWidth = 11
        Me.ButtonItem7.Text = "New Button"
        '
        'ExpandableSplitter1
        '
        Me.ExpandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandableSplitter1.ExpandableControl = Me.SideBar1
        Me.ExpandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExpandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ExpandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.ExpandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
        Me.ExpandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.ExpandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ExpandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ExpandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExpandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter1.Location = New System.Drawing.Point(168, 25)
        Me.ExpandableSplitter1.Name = "ExpandableSplitter1"
        Me.ExpandableSplitter1.Size = New System.Drawing.Size(6, 673)
        Me.ExpandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
        Me.ExpandableSplitter1.TabIndex = 14
        Me.ExpandableSplitter1.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(174, 51)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(828, 647)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'TmrTiempo
        '
        Me.TmrTiempo.Interval = 60000
        '
        'DockSite1
        '
        Me.DockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DockSite1.Location = New System.Drawing.Point(0, 25)
        Me.DockSite1.Name = "DockSite1"
        Me.DockSite1.Size = New System.Drawing.Size(0, 673)
        Me.DockSite1.TabIndex = 18
        Me.DockSite1.TabStop = False
        '
        'DockSite2
        '
        Me.DockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite2.Dock = System.Windows.Forms.DockStyle.Right
        Me.DockSite2.Location = New System.Drawing.Point(1002, 25)
        Me.DockSite2.Name = "DockSite2"
        Me.DockSite2.Size = New System.Drawing.Size(0, 673)
        Me.DockSite2.TabIndex = 19
        Me.DockSite2.TabStop = False
        '
        'DockSite3
        '
        Me.DockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite3.Dock = System.Windows.Forms.DockStyle.Top
        Me.DockSite3.Location = New System.Drawing.Point(0, 25)
        Me.DockSite3.Name = "DockSite3"
        Me.DockSite3.Size = New System.Drawing.Size(1002, 0)
        Me.DockSite3.TabIndex = 20
        Me.DockSite3.TabStop = False
        '
        'DockSite4
        '
        Me.DockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DockSite4.Location = New System.Drawing.Point(0, 698)
        Me.DockSite4.Name = "DockSite4"
        Me.DockSite4.Size = New System.Drawing.Size(1002, 0)
        Me.DockSite4.TabIndex = 21
        Me.DockSite4.TabStop = False
        '
        'FormaPadre
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1002, 720)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TabStrip1)
        Me.Controls.Add(Me.barLeftDockSite)
        Me.Controls.Add(Me.barRightDockSite)
        Me.Controls.Add(Me.barBottomDockSite)
        Me.Controls.Add(Me.ExpandableSplitter1)
        Me.Controls.Add(Me.SideBar1)
        Me.Controls.Add(Me.barTopDockSite)
        Me.Controls.Add(Me.DockSite1)
        Me.Controls.Add(Me.DockSite2)
        Me.Controls.Add(Me.DockSite3)
        Me.Controls.Add(Me.DockSite4)
        Me.Controls.Add(Me.DockSite5)
        Me.Controls.Add(Me.DockSite6)
        Me.Controls.Add(Me.DockSite7)
        Me.Controls.Add(Me.DockSite8)
        Me.DoubleBuffered = True
        Me.IsMdiContainer = True
        Me.Name = "FormaPadre"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AMESOL Base"
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl2.ResumeLayout(False)
        Me.DockSite8.ResumeLayout(False)
        CType(Me.statusBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockSite7.ResumeLayout(False)
        CType(Me.mainmenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vcModulo As BASMODLOG.cModulo
    Private vcActividad As BASACTLOG.cActividad
    Private vcGeneral As New lbGeneral.cKeyGen
    Private vcMensaje As BASMENLOG.CMensaje
    Private vcUsuario As BASUSULOG.cUsuario
    Private vcPerfil As BASPERLOG.cPerfil
    Private vcIntPer As BASPERLOG.cIntPer
    Private vcFecha As Date

    Private Sub FormaPadre_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim vlMODRow As DataRow
        Dim vlMODDataTable As New DataTable
        Dim vlKeyGen As New lbGeneral.cKeyGen

        Dim vlIcon1 As New Icon(System.Windows.Forms.Application.StartupPath + "\Imagenes\Icono.dat")
        Dim vlParametros As lbGeneral.cParametros

        Me.Hide()

        Me.Icon = vlIcon1
        PictureBox1.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "\Imagenes\Logo.dat")
        Dim imagen As New System.Drawing.Bitmap(100, 100)
        Dim g As System.Drawing.Graphics
        g = System.Drawing.Graphics.FromImage(imagen)
        g.FillRectangle(Brushes.White, 0, 0, 100, 100)
        Me.BackgroundImage = imagen
        Me.BackgroundImageLayout = Windows.Forms.ImageLayout.Stretch
        g.Dispose()

        vcModulo = New BASMODLOG.cModulo
        vcActividad = New BASACTLOG.cActividad
        vcMensaje = New BASMENLOG.CMensaje
        vcUsuario = New BASUSULOG.cUsuario
        vcPerfil = New BASPERLOG.cPerfil
        vcUsuario.Recuperar(vlParametros.UsuarioID)
        vcPerfil.Recuperar(vcUsuario.PERClave)
        vcIntPer = New BASPERLOG.cIntPer(vcPerfil)

        Me.Text = vcMensaje.RecuperarDescripcion("BI0002") & "-" '& vVer

        If TmrTiempo.Enabled Then
            Revisar_Caption()
        End If

        'Call EstiloTabSrtip(TabStrip1)

        vlMODDataTable = vcModulo.TablaNodo.Recuperar("MODId1 is NULL ORDER BY SECUENCIA")
        For Each vlMODRow In vlMODDataTable.Rows
          
            Dim vlItem As New ButtonItem

            vlItem.Name = Trim(vlMODRow("MODId"))
            vlItem.Text = vcMensaje.RecuperarDescripcion(Trim(vlMODRow("MENNombreClave")))
            Call AgregarMenu(vlMODRow, vlItem)
            If vlItem.SubItems.Count > 0 Then
                DotNetBarManager1.Bars("mainmenu").Items.Add(vlItem)
            End If

            Dim vlItemPanel As New SideBarPanelItem

            Try
                If Not IsDBNull(vlMODRow("Imagen")) Then
                    Dim vlArrayImage() As Byte = CType(vlMODRow("Imagen"), Byte())
                    Dim vlMS As New MemoryStream(vlArrayImage)
                    Dim vlIcon As New Icon(vlMS)
                    vlMS.Close()
                    vlItemPanel.Icon = vlIcon
                End If
            Catch ex As Exception

            End Try

            vlItemPanel.Name = Trim(vlMODRow("MODId"))
            vlItemPanel.Text = vcMensaje.RecuperarDescripcion(Trim(vlMODRow("MENNombreClave")))
            vlItemPanel.Tooltip = vcMensaje.RecuperarDescripcion(Trim(vlMODRow("MENDescripcionClave")))
            vlItemPanel.Style = eDotNetBarStyle.Office2007
            'Call EstiloSidePanel(vlItemPanel)
            Call AgregarPanel(vlMODRow, vlItemPanel)
            If vlItemPanel.SubItems.Count > 0 Then
                SideBar1.Panels.Add(vlItemPanel)
            End If
        Next

        'SideBar1.PredefinedColorScheme = DevComponents.DotNetBar.eSideBarColorScheme.SystemColors
        SideBar1.PredefinedColorScheme = DevComponents.DotNetBar.eSideBarColorScheme.Blue
        SideBar1.Style = eDotNetBarStyle.Office2007
        SideBar1.Refresh()

        'DotNetBarManager1.ColorScheme.PredefinedColorScheme = ePredefinedColorScheme.OliveGreen2003
        'DotNetBarManager1.ColorScheme.Refresh()

        Dim vlAcercaDe As New ButtonItem
        vlAcercaDe.Name = "Acercade"
        vlAcercaDe.Text = "Acerca de" 'vcMensaje.RecuperarDescripcion("XAcercaDe")
        AddHandler vlAcercaDe.Click, AddressOf Me.MenuSelect
        DotNetBarManager1.Bars("mainmenu").Items.Add(vlAcercaDe)

        Me.DotNetBarManager1.Bars("statusBar2").Items("lbUsuario").Text = vcUsuario.Nombre
        vcFecha = vcConexion.ObtenerFecha
        Call ActualizaFechaHora()
        Timer1.Enabled = True

        TabStrip1.MdiForm = Me

        Me.WindowState = Windows.Forms.FormWindowState.Maximized
        Me.Show()
    End Sub

    Sub AgregarMenu(ByVal peMODRow As DataRow, ByRef peItem As ButtonItem)
        Dim vlMODRow As DataRow
        Dim vlACTRow As DataRow
        Dim vlMODDataTable As DataTable
        Dim vlDataTable As DataTable
        Dim vldtMenu As New DataTable

        vldtMenu.Columns.Add("ACTID", GetType(String))
        vldtMenu.Columns.Add("Secuencia", GetType(Integer))

        vlMODDataTable = vcModulo.TablaNodo.Recuperar("MODId1 = '" + peMODRow("MODId") + "' ORDER BY SECUENCIA")

        For Each vlMODRow In vlMODDataTable.Rows
            Dim vlItem As New ButtonItem
            vlItem.Name = Trim(vlMODRow("MODId"))
            vlItem.Text = vcMensaje.RecuperarDescripcion(Trim(vlMODRow("MENNombreClave")))
            Call AgregarMenu(vlMODRow, vlItem)
            If vlItem.SubItems.Count > 0 Then
                peItem.SubItems.Add(vlItem)
            End If
        Next

        vlDataTable = vcIntPer.TablaNodo.Recuperar("PERClave='" & vcPerfil.PERClave & "' AND MODId='" & peMODRow!MODId & "' AND INTTipoInterfaz=1 ORDER BY Secuencia")
        For Each vlDataRow As DataRow In vlDataTable.Rows
            If vcUsuario.IntUsu.Tabla.Existe(vcUsuario.USUId, vlDataRow!ACTId, 1) = False Then
                vldtMenu.Rows.Add(New Object() {vlDataRow!ACTId, vlDataRow!Secuencia})
            End If
        Next

        vlDataTable = vcUsuario.IntUsu.Tabla.Recuperar("USUId='" & vcUsuario.USUId & "' AND MODId='" & peMODRow!MODId & "' AND INTTipoInterfaz=1 ORDER BY Secuencia")
        For Each vlDataRow As DataRow In vlDataTable.Rows
            If vlDataRow!TipoVisible = 1 Then
                vldtMenu.Rows.Add(New Object() {vlDataRow!ACTId, vlDataRow!Secuencia})
            End If
        Next

        Dim vlDataRows() As DataRow = vldtMenu.Select("", "Secuencia")
        For Each vlDataRow As DataRow In vlDataRows
            Dim vlItem As New ButtonItem

            vlACTRow = vcActividad.TablaNodo.Recuperar("ACTId='" & vlDataRow!ACTId & "'").Rows(0)
            If Not IsDBNull(vlACTRow("Imagen")) Then
                Dim vlArrayImage() As Byte = CType(vlACTRow("Imagen"), Byte())
                Dim vlMS As New MemoryStream(vlArrayImage)
                Dim vlIcon As New Icon(vlMS)
                Dim vlSizef As SizeF

                vlMS.Close()
                vlItem.Icon = vlIcon
                vlSizef.Height = 16
                vlSizef.Width = 16
                vlItem.ImageFixedSize = vlSizef.ToSize
            End If

            vlItem.Name = Trim(vlACTRow("ACTId"))
            vlItem.Text = vcMensaje.RecuperarDescripcion(Trim(vlACTRow("MENNombreClave")))
            AddHandler vlItem.Click, AddressOf Me.MenuSelect
            peItem.SubItems.Add(vlItem)
        Next
    End Sub

    Sub AgregarPanel(ByVal peMODRow As DataRow, ByRef peItem As SideBarPanelItem)
        Dim vlACTRow As DataRow
        Dim vlDataTable As DataTable
        Dim vldtPanel As New DataTable

        vldtPanel.Columns.Add("ACTID", GetType(String))
        vldtPanel.Columns.Add("Secuencia", GetType(Integer))

        vlDataTable = vcIntPer.TablaNodo.Recuperar("PERClave='" & vcPerfil.PERClave & "' AND MODId='" & peMODRow!MODId & "' AND INTTipoInterfaz=1 ORDER BY Secuencia")
        For Each vlDataRow As DataRow In vlDataTable.Rows
            If vcUsuario.IntUsu.Tabla.Existe(vcUsuario.USUId, vlDataRow!ACTId, 1) = False Then
                vldtPanel.Rows.Add(New Object() {vlDataRow!ACTId, vlDataRow!Secuencia})
            End If
        Next

        vlDataTable = vcUsuario.IntUsu.Tabla.Recuperar("USUId='" & vcUsuario.USUId & "' AND MODId='" & peMODRow!MODId & "' AND INTTipoInterfaz=1 ORDER BY Secuencia")
        For Each vlDataRow As DataRow In vlDataTable.Rows
            If vlDataRow!TipoVisible = 1 Then
                vldtPanel.Rows.Add(New Object() {vlDataRow!ACTId, vlDataRow!Secuencia})
            End If
        Next

        Dim vlDataRows() As DataRow = vldtPanel.Select("", "Secuencia")
        For Each vlDataRow As DataRow In vlDataRows
            Dim vlItem As New ButtonItem
            vlACTRow = vcActividad.TablaNodo.Recuperar("ACTId='" & vlDataRow!ACTId & "'").Rows(0)

            If Not IsDBNull(vlACTRow("Imagen")) Then
                Dim vlArrayImage() As Byte = CType(vlACTRow("Imagen"), Byte())
                Dim vlMS As New MemoryStream(vlArrayImage)
                Dim vlIcon As New Icon(vlMS)
                Dim vlSizef As SizeF

                vlMS.Close()
                vlItem.Icon = vlIcon
                vlSizef.Height = 32
                vlSizef.Width = 32
                vlItem.ImageFixedSize = vlSizef.ToSize
            End If

            vlItem.Name = Trim(vlACTRow("ACTId"))
            vlItem.Text = vcMensaje.RecuperarDescripcion(Trim(vlACTRow("MENNombreClave")))
            vlItem.Tooltip = vcMensaje.RecuperarDescripcion(Trim(vlACTRow("MENDescripcionClave")))
            vlItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            vlItem.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
            vlItem.ImagePosition = eImagePosition.Top
            AddHandler vlItem.Click, AddressOf Me.MenuSelect
            peItem.SubItems.Add(vlItem)
        Next

    End Sub

    Private Sub MenuSelect(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim vlINTRow As DataRow
        Dim vlDataTable As New DataTable
        Dim vlComponente As String
        Dim vlProcedimiento As String
        Dim vlClase As String
        Dim vlAcceso As New LbAcceso.cAcceso
        Dim vlTipo As Integer
        Dim vlPermiso As String

        If sender.Name = "Acercade" Then
            Dim vlAcercaDe As New FormaAcercaDe
            vlAcercaDe.ShowDialog()
            Exit Sub
        End If

        vlDataTable = vcUsuario.IntUsu.Tabla.Recuperar("USUId='" & vcUsuario.USUId & "' AND ACTId = '" + sender.name + "' AND INTTipoInterfaz=1")
        If vlDataTable.Rows.Count > 0 Then
            vlPermiso = vlDataTable.Rows(0)!Permiso
        Else
            vlDataTable = vcIntPer.TablaNodo.Recuperar("PERClave='" & vcPerfil.PERClave & "' AND ACTId='" & sender.name & "' AND INTTipoInterfaz=1")
            If vlDataTable.Rows.Count > 0 Then
                vlPermiso = vlDataTable.Rows(0)!Permiso
            Else
                vlPermiso = ""
            End If
        End If

        vlAcceso.MUsuarioId = vcUsuario.USUId
        vlAcceso.Crear = False
        vlAcceso.Leer = False
        vlAcceso.Modificar = False
        vlAcceso.Eliminar = False
        vlAcceso.Ejecutar = False
        vlAcceso.Otros = False
        vlAcceso.Print = False
        If vlPermiso.IndexOf("C") >= 0 Then
            vlAcceso.Crear = True
        End If
        If vlPermiso.IndexOf("R") >= 0 Then
            vlAcceso.Leer = True
        End If
        If vlPermiso.IndexOf("U") >= 0 Then
            vlAcceso.Modificar = True
        End If
        If vlPermiso.IndexOf("D") >= 0 Then
            vlAcceso.Eliminar = True
        End If
        If vlPermiso.IndexOf("E") >= 0 Then
            vlAcceso.Ejecutar = True
        End If
        If vlPermiso.IndexOf("O") >= 0 Then
            vlAcceso.Otros = True
        End If
        If vlPermiso.IndexOf("P") >= 0 Then
            vlAcceso.Print = True
        End If
        vlINTRow = vcActividad.Interfaz.TablaNodo.Recuperar("ACTId = '" + sender.name + "' AND INTTipoInterfaz=1").Rows(0)
        vlTipo = vlINTRow!Tipo
        vlComponente = Trim(vlINTRow("Componente"))
        vlClase = Trim(vlINTRow("Clase"))
        vlProcedimiento = Trim(vlINTRow("Procedimiento"))

        If vlComponente.Substring(vlComponente.Length - 4).ToUpper = ".EXE" Then
            Dim vlProcess As New Process
            Dim vlProcessStartInfo As New ProcessStartInfo(vlComponente)

            vlProcessStartInfo.WindowStyle = ProcessWindowStyle.Normal
            vlProcess.StartInfo = vlProcessStartInfo
            vlProcess.Start()
            Dim lsWindowsState As Windows.Forms.FormWindowState = Me.WindowState
            Me.WindowState = Windows.Forms.FormWindowState.Minimized
            vlProcess.WaitForExit()
            Me.WindowState = lsWindowsState
        Else
            Dim vlEnsamblado As Assembly = Assembly.LoadFrom(System.Windows.Forms.Application.StartupPath & "\" & vlComponente)
            Dim vlMyTypes As Type() = vlEnsamblado.GetTypes()
            Dim vlType As Type

            For Each vlType In vlMyTypes
                If (vlType.Name.ToLower = vlClase.ToLower) Then
                    Dim vlMethod As MethodInfo = vlType.GetMethod(vlProcedimiento)
                    Dim vlObject As [Object] = Activator.CreateInstance(vlType)
                    Dim vlObject2 As Object
                    Dim vlParmas As Object()

                    vlObject2 = vlObject.Instance()
                    vlObject = Nothing

                    If vlObject2.MdiParent Is Me Then
                        For Each loTab As DevComponents.DotNetBar.TabItem In TabStrip1.Tabs
                            If loTab.AttachedControl Is vlObject2 Then
                                TabStrip1.SelectedTab = loTab
                                Exit For
                            End If
                        Next
                    Else
                        If vlTipo = 1 Then
                            vlObject2.WindowState = System.Windows.Forms.FormWindowState.Maximized
                            vlObject2.MdiParent = Me
                        End If
                        vlParmas = New Object() {vlAcceso}
                        vlMethod.Invoke(vlObject2, vlParmas)
                        If vlTipo = 1 Then
                            TabStrip1.Tabs(TabStrip1.SelectedTabIndex).Icon = sender.icon
                        End If
                    End If

                End If
            Next vlType
            If vlTipo = 1 And TabStrip1.Tabs.Count > 0 And PictureBox1.Visible Then
                PictureBox1.Visible = False
            End If
        End If
    End Sub

    'Sub EstiloSidePanel(ByRef vItemPanel As DevComponents.DotNetBar.SideBarPanelItem)
    '    Dim vFont As Font


    '    vItemPanel.Style = eDotNetBarStyle.Office2007
    '    'vItemPanel.BackgroundStyle.BackColor1.Color = System.Drawing.SystemColors.

    '    'vItemPanel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
    '    'vItemPanel.ItemImageSize = eBarImageSize.Large

    '    'vItemPanel.BackgroundStyle.BackColor1.Color = System.Drawing.Color.FromArgb(232, 232, 232)
    '    'vItemPanel.BackgroundStyle.BackColor2.Color = System.Drawing.Color.White
    '    'vItemPanel.BackgroundStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine
    '    'vItemPanel.BackgroundStyle.BorderColor.Color = System.Drawing.Color.FromArgb(59, 97, 156)

    '    'vItemPanel.HeaderHotStyle.BackColor1.Color = System.Drawing.Color.FromArgb(133, 171, 228)
    '    'vItemPanel.HeaderHotStyle.BackColor2.Color = System.Drawing.Color.FromArgb(221, 236, 254)
    '    'vItemPanel.HeaderHotStyle.GradientAngle = 90

    '    'vItemPanel.HeaderSideHotStyle.BackColor1.Color = System.Drawing.Color.FromArgb(133, 171, 228)
    '    'vItemPanel.HeaderSideHotStyle.BackColor2.Color = System.Drawing.Color.FromArgb(221, 236, 254)
    '    'vItemPanel.HeaderSideHotStyle.GradientAngle = 90

    '    'vItemPanel.HeaderSideStyle.BackColor1.Color = System.Drawing.Color.FromArgb(200, 220, 248)
    '    'vItemPanel.HeaderSideStyle.BackColor2.Color = System.Drawing.Color.FromArgb(94, 137, 207)
    '    'vItemPanel.HeaderSideStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine
    '    'vItemPanel.HeaderSideStyle.BorderColor.Color = System.Drawing.Color.FromArgb(59, 97, 156)
    '    'vItemPanel.HeaderSideStyle.BorderSide = DevComponents.DotNetBar.eBorderSide.Left + DevComponents.DotNetBar.eBorderSide.Top + DevComponents.DotNetBar.eBorderSide.Bottom
    '    'vItemPanel.HeaderSideStyle.GradientAngle = 90

    '    'vItemPanel.HeaderStyle.BackColor1.Color = System.Drawing.Color.FromArgb(221, 236, 254)
    '    'vItemPanel.HeaderStyle.BackColor2.Color = System.Drawing.Color.FromArgb(133, 171, 228)
    '    'vItemPanel.HeaderStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine
    '    'vItemPanel.HeaderStyle.BorderColor.Color = System.Drawing.Color.FromArgb(59, 97, 156)
    '    'vItemPanel.HeaderStyle.BorderSide = DevComponents.DotNetBar.eBorderSide.Right + DevComponents.DotNetBar.eBorderSide.Top + DevComponents.DotNetBar.eBorderSide.Bottom

    '    'vFont = New System.Drawing.Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point, 1, False)
    '    'vItemPanel.HeaderStyle.Font = vFont
    '    'vItemPanel.HeaderStyle.ForeColor.Color = System.Drawing.Color.FromArgb(0, 51, 102)
    '    'vItemPanel.HeaderStyle.GradientAngle = 90
    'End Sub

    'Sub EstiloTabSrtip(ByRef prTabStrip As DevComponents.DotNetBar.TabStrip)
    '    Dim vFont As Font

    '    prTabStrip.ColorScheme.TabBackground = System.Drawing.Color.FromArgb(196, 218, 250)
    '    prTabStrip.ColorScheme.TabBackground2 = System.Drawing.Color.FromArgb(253, 254, 255)
    '    prTabStrip.ColorScheme.TabBackgroundGradientAngle = 90
    '    prTabStrip.ColorScheme.TabBorder = System.Drawing.Color.FromArgb(255, 255, 255)

    '    prTabStrip.ColorScheme.TabItemBackground = System.Drawing.Color.FromArgb(236, 243, 252)
    '    prTabStrip.ColorScheme.TabItemBackground2 = System.Drawing.Color.FromArgb(191, 214, 246)
    '    prTabStrip.ColorScheme.TabItemBackgroundGradientAngle = 90
    '    prTabStrip.ColorScheme.TabItemBorder = System.Drawing.Color.FromArgb(0, 53, 154)
    '    prTabStrip.ColorScheme.TabItemBorderDark = System.Drawing.Color.FromArgb(117, 166, 241)
    '    prTabStrip.ColorScheme.TabItemBorderLight = System.Drawing.Color.White

    '    prTabStrip.ColorScheme.TabItemHotBackground = System.Drawing.Color.FromArgb(255, 249, 237)
    '    prTabStrip.ColorScheme.TabItemHotBackground2 = System.Drawing.Color.FromArgb(255, 240, 199)
    '    prTabStrip.ColorScheme.TabItemHotBackgroundGradientAngle = 90
    '    prTabStrip.ColorScheme.TabItemHotBorder = System.Drawing.Color.FromArgb(0, 0, 128)
    '    prTabStrip.ColorScheme.TabItemHotBorderDark = System.Drawing.Color.FromArgb(0, 0, 128)
    '    prTabStrip.ColorScheme.TabItemHotBorderLight = System.Drawing.Color.FromArgb(0, 0, 128)
    '    prTabStrip.ColorScheme.TabItemHotText = System.Drawing.Color.FromKnownColor(KnownColor.ControlText)

    '    prTabStrip.ColorScheme.TabItemSelectedBackground = System.Drawing.Color.FromArgb(223, 237, 254)
    '    prTabStrip.ColorScheme.TabItemSelectedBackground2 = System.Drawing.Color.FromArgb(142, 179, 231)
    '    prTabStrip.ColorScheme.TabItemSelectedBorder = System.Drawing.Color.FromArgb(59, 97, 156)
    '    prTabStrip.ColorScheme.TabItemSelectedBorderDark = System.Drawing.Color.White
    '    prTabStrip.ColorScheme.TabItemSelectedBorderLight = System.Drawing.Color.White
    '    prTabStrip.ColorScheme.TabItemSelectedText = System.Drawing.Color.FromKnownColor(KnownColor.ControlText)

    '    prTabStrip.ColorScheme.TabItemSeparator = System.Drawing.Color.White
    '    prTabStrip.ColorScheme.TabItemSeparatorShade = System.Drawing.Color.White

    '    prTabStrip.ColorScheme.TabItemText = System.Drawing.Color.FromKnownColor(KnownColor.ControlText)

    '    prTabStrip.ColorScheme.TabPanelBackground = System.Drawing.Color.FromArgb(142, 179, 231)
    '    prTabStrip.ColorScheme.TabPanelBackground2 = System.Drawing.Color.FromArgb(223, 237, 254)
    '    prTabStrip.ColorScheme.TabPanelBackgroundGradientAngle = 90
    '    prTabStrip.ColorScheme.TabPanelBorder = System.Drawing.Color.FromArgb(59, 97, 156)

    '    vFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold, GraphicsUnit.Point, 1, False)
    '    prTabStrip.SelectedTabFont = vFont
    'End Sub
    Private Sub TabStrip1_TabItemClose(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripActionEventArgs) Handles TabStrip1.TabItemClose
        If TabStrip1.Tabs.Count = 1 Then
            PictureBox1.Visible = True
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        vcFecha = vcFecha.AddSeconds(1)
        Call ActualizaFechaHora()
    End Sub

    Private Sub ActualizaFechaHora()
        Me.DotNetBarManager1.Bars("statusBar2").Items("lbFechaHora").Text = vcFecha.ToLongDateString & "    " & vcFecha.ToLongTimeString
    End Sub

    Private Sub ExpandableSplitter1_SystemColorsChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExpandableSplitter1.SystemColorsChanged
        ExpandableSplitter1.ApplyStyle(eSplitterStyle.Office2007)
        ExpandableSplitter1.Refresh()
    End Sub

    Private Sub barTopDockSite_SystemColorsChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles barTopDockSite.SystemColorsChanged
        'DotNetBarManager1.ColorScheme.PredefinedColorScheme = ePredefinedColorScheme.OliveGreen2003
        'DotNetBarManager1.ColorScheme.Refresh()
        DotNetBarManager1.Bars("mainmenu").ColorScheme.PredefinedColorScheme = ePredefinedColorScheme.AutoGenerated
        DotNetBarManager1.Bars("mainmenu").ColorScheme.Refresh()
        'DotNetBarManager1.Bars("mainmenu").Refresh()
    End Sub

    Private Sub TmrTiempo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrTiempo.Tick

        If Not oRegistro.Descontar() Then
            MsgBox("Licencia Expirada")
            End
        Else
            Revisar_Caption()
        End If

    End Sub

    Public Sub Revisar_Caption()
        Static Caption As String = ""

        If Caption = "" Then
            Caption = Me.Text
        End If

        Me.Text = Caption & " Minutos Restantes: " & oRegistro.MinutosLeft

    End Sub

    Private Sub barBottomDockSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles barBottomDockSite.Click

    End Sub
End Class
