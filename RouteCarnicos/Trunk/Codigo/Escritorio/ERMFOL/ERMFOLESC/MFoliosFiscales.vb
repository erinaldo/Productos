Imports BASMENLOG
Imports ERMFOLLOG
Imports lbGeneral

Public Class MFoliosFiscales
    Inherits System.Windows.Forms.Form

    Public Enum nombreBoton
        btCrearFolios = 1
        btEliminarFolio = 2
        btCrearAsignacion = 3
        btEliminarAsignacion = 4
        btVendedor = 5
        btTerminal = 6
    End Enum

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
    Friend WithEvents lbDescripcion As System.Windows.Forms.Label
    Friend WithEvents ebDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents gbDetalle As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbTipoEstado As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbTipoEstado As System.Windows.Forms.Label
    Friend WithEvents chkFiscal As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents lbValorInicial As System.Windows.Forms.Label
    Friend WithEvents ebValorInicial As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents CtrlFoliosFiscales1 As ERMFOLESC.ctrlFoliosFiscales
    Friend WithEvents btCrearDetalle As Janus.Windows.EditControls.UIButton
    Friend WithEvents btEliminarDetalle As Janus.Windows.EditControls.UIButton
    Friend WithEvents btAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btHistorico As Janus.Windows.EditControls.UIButton
    Friend WithEvents btEliminarFolio As Janus.Windows.EditControls.UIButton
    Friend WithEvents btEliminarAsignacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCrearFolios As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCrearAsignacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents epErrores As System.Windows.Forms.ErrorProvider
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tbGenerales As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tbFiscales As DevComponents.DotNetBar.TabItem
    Friend WithEvents cbSubempresa As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbSubEmpresa As System.Windows.Forms.Label
    Friend WithEvents ebVersionCFD As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblVersionCFD As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MFoliosFiscales))
        Dim GridDetalle_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.btAceptar = New Janus.Windows.EditControls.UIButton
        Me.btCancelar = New Janus.Windows.EditControls.UIButton
        Me.gbDetalle = New Janus.Windows.EditControls.UIGroupBox
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.btEliminarDetalle = New Janus.Windows.EditControls.UIButton
        Me.btCrearDetalle = New Janus.Windows.EditControls.UIButton
        Me.cbTipoEstado = New Janus.Windows.EditControls.UIComboBox
        Me.ebValorInicial = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.chkFiscal = New Janus.Windows.EditControls.UICheckBox
        Me.lbDescripcion = New System.Windows.Forms.Label
        Me.ebDescripcion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbValorInicial = New System.Windows.Forms.Label
        Me.lbTipoEstado = New System.Windows.Forms.Label
        Me.btEliminarFolio = New Janus.Windows.EditControls.UIButton
        Me.btCrearFolios = New Janus.Windows.EditControls.UIButton
        Me.btHistorico = New Janus.Windows.EditControls.UIButton
        Me.btEliminarAsignacion = New Janus.Windows.EditControls.UIButton
        Me.btCrearAsignacion = New Janus.Windows.EditControls.UIButton
        Me.epErrores = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.ebVersionCFD = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblVersionCFD = New System.Windows.Forms.Label
        Me.cbSubempresa = New Janus.Windows.EditControls.UIComboBox
        Me.lbSubEmpresa = New System.Windows.Forms.Label
        Me.tbGenerales = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel
        Me.CtrlFoliosFiscales1 = New ERMFOLESC.ctrlFoliosFiscales
        Me.tbFiscales = New DevComponents.DotNetBar.TabItem(Me.components)
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btAceptar
        '
        Me.btAceptar.Icon = CType(resources.GetObject("btAceptar.Icon"), System.Drawing.Icon)
        Me.btAceptar.Location = New System.Drawing.Point(660, 588)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(104, 24)
        Me.btAceptar.TabIndex = 21
        Me.btAceptar.Text = "btAceptar"
        Me.btAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCancelar
        '
        Me.btCancelar.CausesValidation = False
        Me.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancelar.Icon = CType(resources.GetObject("btCancelar.Icon"), System.Drawing.Icon)
        Me.btCancelar.Location = New System.Drawing.Point(772, 588)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(104, 24)
        Me.btCancelar.TabIndex = 22
        Me.btCancelar.Text = "btCancelar"
        Me.btCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'gbDetalle
        '
        Me.gbDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDetalle.BackColor = System.Drawing.Color.Transparent
        Me.gbDetalle.Controls.Add(Me.GridDetalle)
        Me.gbDetalle.Controls.Add(Me.btEliminarDetalle)
        Me.gbDetalle.Controls.Add(Me.btCrearDetalle)
        Me.gbDetalle.Location = New System.Drawing.Point(9, 71)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(852, 467)
        Me.gbDetalle.TabIndex = 10
        Me.gbDetalle.Text = "gbDetalle"
        Me.gbDetalle.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'GridDetalle
        '
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        GridDetalle_DesignTimeLayout.LayoutString = resources.GetString("GridDetalle_DesignTimeLayout.LayoutString")
        Me.GridDetalle.DesignTimeLayout = GridDetalle_DesignTimeLayout
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GridDetalle.GroupByBoxVisible = False
        Me.GridDetalle.Location = New System.Drawing.Point(12, 24)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.GridDetalle.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridDetalle.Size = New System.Drawing.Size(728, 427)
        Me.GridDetalle.TabIndex = 11
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btEliminarDetalle
        '
        Me.btEliminarDetalle.CausesValidation = False
        Me.btEliminarDetalle.Enabled = False
        Me.btEliminarDetalle.Icon = CType(resources.GetObject("btEliminarDetalle.Icon"), System.Drawing.Icon)
        Me.btEliminarDetalle.Location = New System.Drawing.Point(764, 60)
        Me.btEliminarDetalle.Name = "btEliminarDetalle"
        Me.btEliminarDetalle.Size = New System.Drawing.Size(80, 24)
        Me.btEliminarDetalle.TabIndex = 13
        Me.btEliminarDetalle.Text = "btEliminarDetalle"
        Me.btEliminarDetalle.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCrearDetalle
        '
        Me.btCrearDetalle.Icon = CType(resources.GetObject("btCrearDetalle.Icon"), System.Drawing.Icon)
        Me.btCrearDetalle.Location = New System.Drawing.Point(764, 28)
        Me.btCrearDetalle.Name = "btCrearDetalle"
        Me.btCrearDetalle.Size = New System.Drawing.Size(80, 24)
        Me.btCrearDetalle.TabIndex = 12
        Me.btCrearDetalle.Text = "btCrearDetalle"
        Me.btCrearDetalle.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'cbTipoEstado
        '
        Me.cbTipoEstado.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipoEstado.Location = New System.Drawing.Point(184, 45)
        Me.cbTipoEstado.Name = "cbTipoEstado"
        Me.cbTipoEstado.Size = New System.Drawing.Size(152, 20)
        Me.cbTipoEstado.TabIndex = 4
        Me.cbTipoEstado.Visible = False
        Me.cbTipoEstado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ebValorInicial
        '
        Me.ebValorInicial.Enabled = False
        Me.ebValorInicial.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebValorInicial.Location = New System.Drawing.Point(410, 44)
        Me.ebValorInicial.MaxLength = 16
        Me.ebValorInicial.Name = "ebValorInicial"
        Me.ebValorInicial.ReadOnly = True
        Me.ebValorInicial.Size = New System.Drawing.Size(152, 20)
        Me.ebValorInicial.TabIndex = 5
        Me.ebValorInicial.Text = "0"
        Me.ebValorInicial.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebValorInicial.Value = 0
        Me.ebValorInicial.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        Me.ebValorInicial.Visible = False
        Me.ebValorInicial.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'chkFiscal
        '
        Me.chkFiscal.BackColor = System.Drawing.Color.Transparent
        Me.chkFiscal.Checked = True
        Me.chkFiscal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFiscal.Enabled = False
        Me.chkFiscal.Location = New System.Drawing.Point(25, 42)
        Me.chkFiscal.Name = "chkFiscal"
        Me.chkFiscal.Size = New System.Drawing.Size(80, 23)
        Me.chkFiscal.TabIndex = 3
        Me.chkFiscal.Text = "chkFiscal"
        Me.chkFiscal.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbDescripcion
        '
        Me.lbDescripcion.BackColor = System.Drawing.Color.Transparent
        Me.lbDescripcion.Location = New System.Drawing.Point(21, 18)
        Me.lbDescripcion.Name = "lbDescripcion"
        Me.lbDescripcion.Size = New System.Drawing.Size(96, 20)
        Me.lbDescripcion.TabIndex = 3
        Me.lbDescripcion.Text = "lbDescripcion"
        Me.lbDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebDescripcion
        '
        Me.ebDescripcion.Location = New System.Drawing.Point(117, 18)
        Me.ebDescripcion.MaxLength = 64
        Me.ebDescripcion.Name = "ebDescripcion"
        Me.ebDescripcion.Size = New System.Drawing.Size(344, 20)
        Me.ebDescripcion.TabIndex = 1
        Me.ebDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbValorInicial
        '
        Me.lbValorInicial.BackColor = System.Drawing.Color.Transparent
        Me.lbValorInicial.Location = New System.Drawing.Point(343, 44)
        Me.lbValorInicial.Name = "lbValorInicial"
        Me.lbValorInicial.Size = New System.Drawing.Size(112, 20)
        Me.lbValorInicial.TabIndex = 18
        Me.lbValorInicial.Text = "lbValorInicial"
        Me.lbValorInicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbValorInicial.Visible = False
        '
        'lbTipoEstado
        '
        Me.lbTipoEstado.BackColor = System.Drawing.Color.Transparent
        Me.lbTipoEstado.Location = New System.Drawing.Point(114, 45)
        Me.lbTipoEstado.Name = "lbTipoEstado"
        Me.lbTipoEstado.Size = New System.Drawing.Size(112, 20)
        Me.lbTipoEstado.TabIndex = 15
        Me.lbTipoEstado.Text = "lbTipoEstado"
        Me.lbTipoEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbTipoEstado.Visible = False
        '
        'btEliminarFolio
        '
        Me.btEliminarFolio.CausesValidation = False
        Me.btEliminarFolio.Enabled = False
        Me.btEliminarFolio.Icon = CType(resources.GetObject("btEliminarFolio.Icon"), System.Drawing.Icon)
        Me.btEliminarFolio.Location = New System.Drawing.Point(770, 119)
        Me.btEliminarFolio.Name = "btEliminarFolio"
        Me.btEliminarFolio.Size = New System.Drawing.Size(80, 24)
        Me.btEliminarFolio.TabIndex = 18
        Me.btEliminarFolio.Text = "btEliminarFolio"
        Me.btEliminarFolio.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCrearFolios
        '
        Me.btCrearFolios.Icon = CType(resources.GetObject("btCrearFolios.Icon"), System.Drawing.Icon)
        Me.btCrearFolios.Location = New System.Drawing.Point(770, 87)
        Me.btCrearFolios.Name = "btCrearFolios"
        Me.btCrearFolios.Size = New System.Drawing.Size(80, 24)
        Me.btCrearFolios.TabIndex = 17
        Me.btCrearFolios.Text = "btCrearFolios"
        Me.btCrearFolios.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btHistorico
        '
        Me.btHistorico.Icon = CType(resources.GetObject("btHistorico.Icon"), System.Drawing.Icon)
        Me.btHistorico.Location = New System.Drawing.Point(770, 17)
        Me.btHistorico.Name = "btHistorico"
        Me.btHistorico.Size = New System.Drawing.Size(80, 24)
        Me.btHistorico.TabIndex = 16
        Me.btHistorico.Text = "btHistorico"
        Me.btHistorico.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btEliminarAsignacion
        '
        Me.btEliminarAsignacion.CausesValidation = False
        Me.btEliminarAsignacion.Enabled = False
        Me.btEliminarAsignacion.Icon = CType(resources.GetObject("btEliminarAsignacion.Icon"), System.Drawing.Icon)
        Me.btEliminarAsignacion.Location = New System.Drawing.Point(770, 354)
        Me.btEliminarAsignacion.Name = "btEliminarAsignacion"
        Me.btEliminarAsignacion.Size = New System.Drawing.Size(80, 24)
        Me.btEliminarAsignacion.TabIndex = 20
        Me.btEliminarAsignacion.Text = "btEliminarAsignacion"
        Me.btEliminarAsignacion.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCrearAsignacion
        '
        Me.btCrearAsignacion.Enabled = False
        Me.btCrearAsignacion.Icon = CType(resources.GetObject("btCrearAsignacion.Icon"), System.Drawing.Icon)
        Me.btCrearAsignacion.Location = New System.Drawing.Point(770, 322)
        Me.btCrearAsignacion.Name = "btCrearAsignacion"
        Me.btCrearAsignacion.Size = New System.Drawing.Size(80, 24)
        Me.btCrearAsignacion.TabIndex = 19
        Me.btCrearAsignacion.Text = "btCrearAsignacion"
        Me.btCrearAsignacion.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'epErrores
        '
        Me.epErrores.ContainerControl = Me
        '
        'TabControl1
        '
        Me.TabControl1.CanReorderTabs = False
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Location = New System.Drawing.Point(4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.SelectedTabIndex = 1
        Me.TabControl1.Size = New System.Drawing.Size(872, 576)
        Me.TabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005Document
        Me.TabControl1.TabIndex = 9
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.tbGenerales)
        Me.TabControl1.Tabs.Add(Me.tbFiscales)
        Me.TabControl1.TabStop = False
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.ebVersionCFD)
        Me.TabControlPanel1.Controls.Add(Me.lblVersionCFD)
        Me.TabControlPanel1.Controls.Add(Me.ebValorInicial)
        Me.TabControlPanel1.Controls.Add(Me.gbDetalle)
        Me.TabControlPanel1.Controls.Add(Me.lbDescripcion)
        Me.TabControlPanel1.Controls.Add(Me.cbSubempresa)
        Me.TabControlPanel1.Controls.Add(Me.lbSubEmpresa)
        Me.TabControlPanel1.Controls.Add(Me.cbTipoEstado)
        Me.TabControlPanel1.Controls.Add(Me.lbTipoEstado)
        Me.TabControlPanel1.Controls.Add(Me.chkFiscal)
        Me.TabControlPanel1.Controls.Add(Me.ebDescripcion)
        Me.TabControlPanel1.Controls.Add(Me.lbValorInicial)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(872, 550)
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.tbGenerales
        '
        'ebVersionCFD
        '
        Me.ebVersionCFD.Enabled = False
        Me.ebVersionCFD.Location = New System.Drawing.Point(681, 43)
        Me.ebVersionCFD.MaxLength = 64
        Me.ebVersionCFD.Name = "ebVersionCFD"
        Me.ebVersionCFD.Size = New System.Drawing.Size(152, 20)
        Me.ebVersionCFD.TabIndex = 6
        Me.ebVersionCFD.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebVersionCFD.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblVersionCFD
        '
        Me.lblVersionCFD.BackColor = System.Drawing.Color.Transparent
        Me.lblVersionCFD.Location = New System.Drawing.Point(569, 43)
        Me.lblVersionCFD.Name = "lblVersionCFD"
        Me.lblVersionCFD.Size = New System.Drawing.Size(112, 20)
        Me.lblVersionCFD.TabIndex = 30
        Me.lblVersionCFD.Text = "lblVersionCFD"
        Me.lblVersionCFD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbSubempresa
        '
        Me.cbSubempresa.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbSubempresa.Location = New System.Drawing.Point(681, 16)
        Me.cbSubempresa.Name = "cbSubempresa"
        Me.cbSubempresa.Size = New System.Drawing.Size(152, 20)
        Me.cbSubempresa.TabIndex = 2
        Me.cbSubempresa.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbSubEmpresa
        '
        Me.lbSubEmpresa.BackColor = System.Drawing.Color.Transparent
        Me.lbSubEmpresa.Location = New System.Drawing.Point(569, 16)
        Me.lbSubEmpresa.Name = "lbSubEmpresa"
        Me.lbSubEmpresa.Size = New System.Drawing.Size(112, 20)
        Me.lbSubEmpresa.TabIndex = 15
        Me.lbSubEmpresa.Text = "lbSubEmpresa"
        Me.lbSubEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbGenerales
        '
        Me.tbGenerales.AttachedControl = Me.TabControlPanel1
        Me.tbGenerales.Name = "tbGenerales"
        Me.tbGenerales.Text = "tbGenerales"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.btEliminarFolio)
        Me.TabControlPanel2.Controls.Add(Me.btCrearFolios)
        Me.TabControlPanel2.Controls.Add(Me.btHistorico)
        Me.TabControlPanel2.Controls.Add(Me.btEliminarAsignacion)
        Me.TabControlPanel2.Controls.Add(Me.btCrearAsignacion)
        Me.TabControlPanel2.Controls.Add(Me.CtrlFoliosFiscales1)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(872, 550)
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.tbFiscales
        '
        'CtrlFoliosFiscales1
        '
        Me.CtrlFoliosFiscales1.BackColor = System.Drawing.Color.Transparent
        Me.CtrlFoliosFiscales1.Location = New System.Drawing.Point(0, -6)
        Me.CtrlFoliosFiscales1.Name = "CtrlFoliosFiscales1"
        Me.CtrlFoliosFiscales1.Size = New System.Drawing.Size(764, 550)
        Me.CtrlFoliosFiscales1.TabIndex = 15
        Me.CtrlFoliosFiscales1.VersionCFD = CType(0, Short)
        '
        'tbFiscales
        '
        Me.tbFiscales.AttachedControl = Me.TabControlPanel2
        Me.tbFiscales.Name = "tbFiscales"
        Me.tbFiscales.Text = "tbFiscales"
        '
        'MFoliosFiscales
        '
        Me.AcceptButton = Me.btAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btCancelar
        Me.ClientSize = New System.Drawing.Size(882, 620)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btAceptar)
        Me.Controls.Add(Me.btCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(888, 648)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(888, 648)
        Me.Name = "MFoliosFiscales"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MFoliosFiscales"
        CType(Me.gbDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalle.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        Me.TabControlPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "VARIABLES"
    Private vgMODO As eModo
    Public vcFolio As cFolio
    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vcMensaje As CMensaje
    Private vgCerrar, bHuboCambios As Boolean
    Private htSubempresas As Hashtable
    ' Private htValorCFD As Hashtable
#End Region

#Region "PROPIEDADES"
    Public Property Mensajes() As CMensaje
        Get
            Return vcMensaje
        End Get
        Set(ByVal Value As CMensaje)
            vcMensaje = Value
        End Set
    End Property

#End Region

#Region "FUNCIONES GENERALES"
    Private Sub LimpiarCampos()
        ebDescripcion.Text = ""
        ebValorInicial.Text = ""
        cbTipoEstado.SelectedValue = 1
        GridDetalle.DataSource = vcFolio.FODArray
    End Sub

    Public Function CREAR(ByRef prFolio As cFolio, ByVal pvMUsuarioId As String) As Boolean
        vgMODO = eModo.Crear
        vcFolio = prFolio
        vcFolio.Fiscal = chkFiscal.Checked
        vcFolio.MUsuarioId = pvMUsuarioId


        vcFolio.FolioID = cKeyGen.KEYGEN(1)

        configurarTitulos()
        cbSubempresa.SelectedIndex = 0
        ConfigurarVersionCFDI()

        LimpiarCampos()
        ebDescripcion.Focus()

        bHuboCambios = False

        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function MODIFICAR(ByRef prFolio As cFolio, ByVal pvMusuarioId As String) As Boolean
        vgMODO = eModo.Modificar
        vcFolio = prFolio
        configurarTitulos()
        LlenarCampos()

        cbSubempresa.Enabled = False

        Me.ebValorInicial.Enabled = Not vcFolio.ExisteRelacion
        Me.Text = vcMensaje.RecuperarDescripcion("ERMFOLESC_MGeneralM")
        bHuboCambios = False
        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            vcConexion.ConfirmarTran()
            Return True
        Else
            vcConexion.DeshacerTran()
            Return False
        End If
    End Function

    Public Function CONSULTAR(ByRef prFolio As cFolio, ByVal pvMusuarioId As String) As Boolean
        vgMODO = eModo.Leer
        vcFolio = prFolio
        configurarTitulos()

        LlenarCampos()
        Me.ebValorInicial.Enabled = Not vcFolio.ExisteRelacion
        ebDescripcion.Enabled = False
        ebValorInicial.Enabled = False
        GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
        btCrearFolios.Enabled = False
        btEliminarDetalle.Enabled = False
        cbTipoEstado.Enabled = False
        btCrearDetalle.Enabled = False
        btAceptar.Visible = False
        btCancelar.Text = vcMensaje.RecuperarDescripcion("BTRegresar")
        btCancelar.Icon = btAceptar.Icon
        Me.Text = vcMensaje.RecuperarDescripcion("XCONSULTAR") + " " + vcMensaje.RecuperarDescripcion("ERMFOLESC_NFoliosFiscales")
        vgCerrar = True
        Me.ShowDialog()
    End Function

    Private Sub configurarTitulos()
        ''Generales
        ebDescripcion.Tag = "FOLDescripcion"
        ebValorInicial.Tag = "FOLValorInicial"
        cbTipoEstado.Tag = "FOLTipoEstado"

        Me.Text = Mensajes.RecuperarDescripcion("ERMFOLESC_MFoliosFiscalesC")
        Me.tbGenerales.Text = Mensajes.RecuperarDescripcion("XGenerales")
        Me.tbFiscales.Text = Mensajes.RecuperarDescripcion("XFiscales")
        Me.lbDescripcion.Text = Mensajes.RecuperarDescripcion("FOLDescripcion")
        Me.lbTipoEstado.Text = Mensajes.RecuperarDescripcion("FOLTipoEstado")
        Me.lbValorInicial.Text = Mensajes.RecuperarDescripcion("FOLValorInicial")
        Me.chkFiscal.Text = Mensajes.RecuperarDescripcion("XFiscal")
        Me.btAceptar.Text = Mensajes.RecuperarDescripcion("btAceptar")
        Me.btCancelar.Text = Mensajes.RecuperarDescripcion("btCancelar")
        Me.btCrearDetalle.Text = Mensajes.RecuperarDescripcion("btCrear")
        Me.btCrearAsignacion.Text = Mensajes.RecuperarDescripcion("btCrear")
        Me.btCrearFolios.Text = Mensajes.RecuperarDescripcion("btCrear")
        Me.lbSubEmpresa.Text = Mensajes.RecuperarDescripcion("xSubEmpresa")
        Me.lblVersionCFD.Text = Mensajes.RecuperarDescripcion("SEMVersionCFD")

        Me.btEliminarDetalle.Text = Mensajes.RecuperarDescripcion("btEliminar")
        Me.btEliminarAsignacion.Text = Mensajes.RecuperarDescripcion("btEliminar")
        Me.btEliminarFolio.Text = Mensajes.RecuperarDescripcion("btEliminar")
        Me.btHistorico.Text = Mensajes.RecuperarDescripcion("BtHistorico")

        Me.gbDetalle.Text = vcMensaje.RecuperarDescripcion("XDetalle")

        Dim vlToolTip As New System.Windows.Forms.ToolTip
        With vlToolTip
            .ShowAlways = True
            .SetToolTip(Me.ebDescripcion, vcMensaje.RecuperarDescripcion("FOLDescripcionT"))
            .SetToolTip(Me.cbTipoEstado, vcMensaje.RecuperarDescripcion("FOLTipoEstadoT"))
            .SetToolTip(Me.chkFiscal, Mensajes.RecuperarDescripcion("XFiscal"))
            .SetToolTip(Me.ebValorInicial, vcMensaje.RecuperarDescripcion("FOLValorInicialT"))
            .SetToolTip(Me.btAceptar, Mensajes.RecuperarDescripcion("btAceptarT"))
            .SetToolTip(Me.btCancelar, Mensajes.RecuperarDescripcion("btCancelarT"))
            .SetToolTip(Me.btCrearDetalle, Mensajes.RecuperarDescripcion("btCrearT"))
            .SetToolTip(Me.btCrearFolios, Mensajes.RecuperarDescripcion("btCrearT"))
            .SetToolTip(Me.btCrearAsignacion, Mensajes.RecuperarDescripcion("btCrearT"))
            .SetToolTip(Me.btEliminarDetalle, Mensajes.RecuperarDescripcion("btEliminarT"))
            .SetToolTip(Me.btEliminarFolio, Mensajes.RecuperarDescripcion("btEliminarT"))
            .SetToolTip(Me.btEliminarAsignacion, Mensajes.RecuperarDescripcion("btEliminarT"))
            .SetToolTip(Me.cbSubempresa, Mensajes.RecuperarDescripcion("FOLSubEmpresaT"))
            .SetToolTip(Me.ebVersionCFD, Mensajes.RecuperarDescripcion("SEMVersionCFDT"))

            .SetToolTip(Me.btHistorico, Mensajes.RecuperarDescripcion("FOSHistorico"))

            If vgMODO = eModo.Leer Then
                .SetToolTip(Me.btCancelar, vcMensaje.RecuperarDescripcion("BTRegresar"))
            Else
                .SetToolTip(Me.btCancelar, vcMensaje.RecuperarDescripcion("BTCancelarT"))
            End If
        End With

        GridDetalle.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        With GridDetalle.RootTable
            For Each vlColumna As Janus.Windows.GridEX.GridEXColumn In .Columns
                vlColumna.Caption = vcMensaje.RecuperarDescripcion("FOD" & vlColumna.Key)
                vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("FOD" & vlColumna.Key & "T")
                vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            Next
            .Columns("TipoEstado").DefaultValue = 1
            .Columns("TipoContenido").DefaultValue = 2
        End With
        lbGeneral.LlenarColumna(GridDetalle.RootTable.Columns("TipoContenido"), "TFOLCONT")
        lbGeneral.LlenarColumna(GridDetalle.RootTable.Columns("TipoEstado"), "EDOREG")
        lbGeneral.LlenarComboBox(cbTipoEstado, "EDOREG")

        LlenarCbSubEmpresa()


        'Fiscales
        Me.CtrlFoliosFiscales1.CargarTodo(vgMODO, vcFolio, Mensajes)

        Dim fh As New ERMFOLLOG.Amesol.CFOSHist
        Me.btHistorico.Enabled = fh.Existe(Me.vcFolio.FolioID)

    End Sub

    Private Sub LlenarCbSubEmpresa()
        Dim subempresa As New ERMSEMLOG.cSubEmpresa()
        htSubempresas = New Hashtable
        For Each R As DataRow In subempresa.RecuperarTabla().Rows
            cbSubempresa.Items.Add(R!NombreEmpresa, R!SubEmpresaID)
            subempresa.Recuperar(R!SubEmpresaId)
            htSubempresas.Add(R!SubEmpresaId, subempresa.VersionCFD)
        Next

        'htValorCFD = lbGeneral.ValoresDescripcionVARValor("VERFACTE", Nothing)
    End Sub

    Private Sub PonerFoco(ByVal pvNombreCampo As String)
        Select Case pvNombreCampo
            Case "Descripcion"
                Me.ebDescripcion.Focus()
            Case "ValorInicial"
                Me.ebValorInicial.Focus()
            Case "TipoEstado"
                Me.cbTipoEstado.Focus()
            Case "FolioSolicitado"
                Me.TabControl1.SelectedTabIndex = 1
            Case "Detalle"
                Me.TabControl1.SelectedTabIndex = 0
                Me.GridDetalle.MoveFirst()
            Case "TipoFormato"
                Me.TabControl1.SelectedTabIndex = 0
                Me.GridDetalle.MoveLast()
                Me.GridDetalle.Focus()
        End Select
    End Sub

    Private Sub DeshabilitaCrear(ByRef peGridEx As Janus.Windows.GridEX.GridEX)
        If Not peGridEx.GetRow Is Nothing And peGridEx.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True Then
            If (peGridEx.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Or peGridEx.DataChanged = False) Then
                peGridEx.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                If (peGridEx.Row = 0) Then
                    Try
                        peGridEx.MoveLast()
                    Catch ex As Exception

                    End Try

                End If
            End If
        End If
    End Sub


    Private Sub LlenarCampos()
        With vcFolio
            ebDescripcion.Text = .Descripcion
            ebValorInicial.Text = .ValorInicial
            cbTipoEstado.SelectedValue = .TipoEstado
            cbSubempresa.SelectedValue = .SubEmpresaId
            Me.ebValorInicial.Enabled = False
            Me.ebDescripcion.Enabled = False
            Me.CtrlFoliosFiscales1.Folio = .Descripcion

            GridDetalle.DataSource = vcFolio.FODArray
            GridDetalle.Refresh()
            GridDetalle.Refetch()

        End With
    End Sub

    Private Function ValidarCampos(ByVal pvCelda As Janus.Windows.GridEX.GridEXCell) As Boolean
        Select Case pvCelda.Column.Key
            Case "Formato"
                If Not pvCelda.Value Is Nothing Then
                    Try
                        validarFormato(pvCelda.Value)
                    Catch ex As LbControlError.cError
                        ex.Mostrar()
                        Return False
                    End Try
                End If
            Case "TipoEstado"
                Try
                    If EstadoActivo() And pvCelda.Value = 1 Then Throw New LbControlError.cError("E0658")
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    Return False
                End Try
        End Select

        Return True
    End Function

    Private Function ValidarRow(ByVal pvRow As Janus.Windows.GridEX.GridEXRow) As Boolean
        For Each vlCelda As Janus.Windows.GridEX.GridEXCell In pvRow.Cells
            If ValidarCampos(vlCelda) = False Then
                Return False
            End If
        Next

        Return True
    End Function

    Private Sub validarFormato(ByVal valor As String)

        For Each letra As Char In valor
            If letra <> "0" Then
                Throw New LbControlError.cError("E0669")
            End If
        Next

    End Sub

    Private Function EstadoActivo() As Boolean
        For Each vlRow As Janus.Windows.GridEX.GridEXRow In Me.GridDetalle.GetRows
            If vlRow.Cells("TipoEstado").Value = 1 Then
                Return True
            End If
        Next

        Return False
    End Function
#End Region

#Region "BOTONES"
    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Me.Close()
    End Sub

    Private Sub btVigenciaCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btHistorico.Click
        Dim frmHist As New HFoliosFiscales
        frmHist.vcFolio = New cFolio
        frmHist.vcFolio.vbHistorico = True
        frmHist.vcFolio.Recuperar(vcFolio.FolioID)
        frmHist.CtrlFoliosFiscales1.Folio = vcFolio.Descripcion
        frmHist.ShowDialog()
    End Sub

    Private Sub btAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.None

        If vgMODO = eModo.Crear Or vgMODO = eModo.Modificar Then

            With vcFolio
                .Descripcion = ebDescripcion.Text
                .ValorInicial = ebValorInicial.Text
                .TipoEstado = cbTipoEstado.SelectedValue
                .Fiscal = Me.chkFiscal.Checked
                .SubEmpresaId = Me.cbSubempresa.SelectedValue
            End With

            Try
                If vgMODO = eModo.Crear Then
                    vcFolio.Insertar()
                Else
                    vcFolio.ValidarCampos()
                End If
            Catch ex As LbControlError.cError
                ex.Mostrar()
                PonerFoco(ex.Source)
                Exit Sub
            End Try

        ElseIf vgMODO = eModo.Eliminar Then
            vcFolio.Eliminar()
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        vgCerrar = True
        Me.Close()
    End Sub

    Private Sub btCrearDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCrearDetalle.Click
        Me.GridDetalle.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
        Me.GridDetalle.Col = 0
        Me.GridDetalle.MoveToNewRecord()
        Me.GridDetalle.Focus()

        For Each vlFOD As cFolioDetalle In vcFolio.FODArray
            If vlFOD.TipoEstado = 1 Then
                GridDetalle.SetValue("tipoEstado", 0)
                Exit For
            End If
        Next

        bHuboCambios = True
    End Sub

    Private Sub btEliminarDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEliminarDetalle.Click
        If (GridDetalle.RowCount = 0) Then
            Exit Sub
        End If

        If (GridDetalle.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
            GridDetalle.CancelCurrentEdit()
            DeshabilitaCrear(Me.GridDetalle)
        ElseIf (GridDetalle.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
            If Not vcFolio.FOD(GridDetalle.GetValue("FolioDetClave")) Is Nothing Then
                If vcFolio.FOD(GridDetalle.GetValue("FolioDetClave")).Estado = eEstado.Nuevo Then
                    GridDetalle.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    GridDetalle.Delete()
                    GridDetalle.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                End If
            End If

        End If
        bHuboCambios = True
    End Sub

    Private Sub btnPresionado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCrearFolios.Click, btEliminarFolio.Click, btCrearAsignacion.Click, btEliminarAsignacion.Click
        Me.CtrlFoliosFiscales1.btPresionado(sender)
        bHuboCambios = True
    End Sub

#End Region

#Region "GRIDDetalle"
    Private Sub GridDetalle_AddingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridDetalle.AddingRecord
        If ValidarRow(GridDetalle.GetRow) = False Then
            e.Cancel = True
            Exit Sub
        End If

        Try
            vcFolio.InsertarFOD(vcFolio.FODArray.Count + 1, GridDetalle.GetValue("TipoContenido"), GridDetalle.GetValue("Formato"), GridDetalle.GetValue("TipoEstado"))
        Catch ex As LbControlError.cError
            ex.Mostrar()
            e.Cancel = True
        End Try

    End Sub

    Private Sub GridDetalle_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.Leave
        DeshabilitaCrear(Me.GridDetalle)
    End Sub

    Private Sub GridDetalle_RecordAdded(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.RecordAdded
        If (Me.GridDetalle.Focused = False) Then
            Call DeshabilitaCrear(Me.GridDetalle)
        End If
        Me.GridDetalle.Refresh()
        Me.GridDetalle.Refetch()
    End Sub

    Private Sub GridDetalle_CancelingRowEdit(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionCancelEventArgs) Handles GridDetalle.CancelingRowEdit
        e.Cancel = True
    End Sub

    Private Sub GridDetalle_FirstChange(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles GridDetalle.FirstChange
        If (Me.GridDetalle.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
            Me.btEliminarDetalle.Enabled = True
        End If
        bHuboCambios = True
    End Sub

    Private Sub GridDetalle_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.SelectionChanged
        Try
            Select Case (vgMODO)
                Case eModo.Crear
                    btEliminarDetalle.Enabled = True
                Case eModo.Modificar
                    If Not (GridDetalle.GetRow Is Nothing) Then
                        If (GridDetalle.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                            btEliminarDetalle.Enabled = True
                            GridDetalle.RootTable.Columns("Formato").EditType = Janus.Windows.GridEX.EditType.TextBox
                        Else

                            Dim fh As New ERMFOLLOG.Amesol.CFOSHist
                            If fh.Existe(Me.vcFolio.FolioID) Then
                                GridDetalle.RootTable.Columns("Formato").EditType = Janus.Windows.GridEX.EditType.NoEdit
                            Else
                                GridDetalle.RootTable.Columns("Formato").EditType = Janus.Windows.GridEX.EditType.TextBox
                            End If

                            If Not vcFolio.FOD(GridDetalle.GetValue("FolioDetClave")) Is Nothing Then
                                If vcFolio.FOD(GridDetalle.GetValue("FolioDetClave")).Estado = eEstado.Nuevo Then
                                    btEliminarDetalle.Enabled = True
                                Else
                                    btEliminarDetalle.Enabled = False
                                End If
                            Else
                                btEliminarDetalle.Enabled = True
                            End If
                        End If
                    End If
            End Select

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GridDetalle_UpdatingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridDetalle.UpdatingRecord
        Try

            Dim vcFOD As cFolioDetalle = vcFolio.FOD(GridDetalle.GetValue("FolioDetClave"))
            If vcFOD.TipoContenido = GridDetalle.GetValue("TipoContenido") And vcFOD.Formato = GridDetalle.GetValue("Formato") And vcFOD.TipoEstado = GridDetalle.GetValue("TipoEstado") Then
                Exit Sub
            End If

            With vcFOD
                .TipoContenido = GridDetalle.GetValue("TipoContenido")
                .Formato = GridDetalle.GetValue("Formato")
                .TipoEstado = GridDetalle.GetValue("TipoEstado")
            End With
        Catch ex As LbControlError.cError
            e.Cancel = True
            ex.Mostrar()
        End Try
    End Sub

    Private Sub GridDetalle_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.RecordUpdated
        Me.GridDetalle.Refresh()
        Me.GridDetalle.Refetch()
    End Sub

    Private Sub GridDetalle_RowEditCanceled(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles GridDetalle.RowEditCanceled
        Me.GridDetalle.Refresh()
        Me.GridDetalle.Refetch()
    End Sub

    Private Sub GridDetalle_CellEditCanceled(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEditCanceled
        Me.GridDetalle.Refresh()
        Me.GridDetalle.Refetch()
    End Sub

#End Region

    Private Sub MFoliosFiscales_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If vgCerrar Or bHuboCambios = False Then Exit Sub

        If MsgBox(Mensajes.RecuperarDescripcion("BP0001"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Mensajes.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub cbSubempresa_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSubempresa.SelectedValueChanged
        If cbSubempresa.SelectedValue Is Nothing Then Exit Sub
        If Not IsNothing(vcFolio) Then
            vcFolio.SubEmpresaId = cbSubempresa.SelectedValue
        End If
        ConfigurarVersionCFDI()

        bHuboCambios = True
    End Sub

    Private Sub ConfigurarVersionCFDI()
        If htSubempresas.Contains(cbSubempresa.SelectedValue) Then
            'If htValorCFD.Contains(htSubempresas(cbSubempresa.SelectedValue).ToString) Then
            ebVersionCFD.Text = lbGeneral.ClaveDescripcionVARValor("VERFACTE", htSubempresas(cbSubempresa.SelectedValue).ToString)
            'End If
        End If
        Me.CtrlFoliosFiscales1.VersionCFD = htSubempresas(cbSubempresa.SelectedValue)
        If htSubempresas(cbSubempresa.SelectedValue) = 1 OrElse htSubempresas(cbSubempresa.SelectedValue) = 3 Then
            'CFD
            Me.CtrlFoliosFiscales1.grFolioSolicitado.RootTable.Columns("NumeroAprobacion").Visible = True
            Me.CtrlFoliosFiscales1.grFolioSolicitado.RootTable.Columns("AnioAprobacion").Visible = True
            Me.CtrlFoliosFiscales1.grFolioSolicitado.RootTable.Columns("CantSolicitada").Caption = Mensajes.RecuperarDescripcion("FOSCantSolicitada")
            Me.CtrlFoliosFiscales1.grFolioSolicitado.RootTable.Columns("CantSolicitada").HeaderToolTip = Mensajes.RecuperarDescripcion("FOSCantSolicitada")
        Else
            'CFDI
            Me.CtrlFoliosFiscales1.grFolioSolicitado.RootTable.Columns("NumeroAprobacion").Visible = False
            Me.CtrlFoliosFiscales1.grFolioSolicitado.RootTable.Columns("AnioAprobacion").Visible = False
            Me.CtrlFoliosFiscales1.grFolioSolicitado.RootTable.Columns("CantSolicitada").Caption = Mensajes.RecuperarDescripcion("XTotalFolios")
            Me.CtrlFoliosFiscales1.grFolioSolicitado.RootTable.Columns("CantSolicitada").HeaderToolTip = Mensajes.RecuperarDescripcion("XTotalFolios")
        End If
    End Sub

    Private Sub EbRequeridos_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebDescripcion.Validated, cbTipoEstado.Validated, ebValorInicial.Validated, cbSubempresa.Validated
        Try
            If sender.Text = "" Then
                epErrores.SetError(sender, vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion(sender.tag)}))
                Exit Sub
            End If
            epErrores.SetError(sender, "")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CtrlFoliosFiscales1_HabilitarBtn(ByVal pvNombreBoton As String, ByVal pvHabilitar As Boolean) Handles CtrlFoliosFiscales1.Habilitar

        Select Case pvNombreBoton
            Case "btEliminarFolio"
                Me.btEliminarFolio.Enabled = pvHabilitar
            Case "btEliminarAsignacion"
                Me.btEliminarAsignacion.Enabled = pvHabilitar
            Case "btCrearAsignacion"
                Me.btCrearAsignacion.Enabled = pvHabilitar
            Case "HuboCambios"
                Me.bHuboCambios = pvHabilitar
        End Select
    End Sub

    Private Sub ebDescripcion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebDescripcion.TextChanged
        Me.CtrlFoliosFiscales1.Folio = Me.ebDescripcion.Text
        Me.bHuboCambios = True
    End Sub

    Private Sub CtrlFoliosFiscales1_HuboCambios(ByVal sCadena As String, ByVal pvHuboCambios As Boolean) Handles CtrlFoliosFiscales1.Habilitar
        Me.bHuboCambios = pvHuboCambios
    End Sub

    Private Sub GridDetalle_UpdatingCell(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs) Handles GridDetalle.UpdatingCell

        Select Case e.Column.Key
            Case "TipoEstado"
                If e.Value = 0 Then Exit Sub

                Try
                    If EstadoActivo() Then Throw New LbControlError.cError("E0658")
                Catch ex As LbControlError.cError
                    e.Value = 0
                    e.Cancel = True
                    ex.Mostrar()
                End Try

            Case "Formato"
                If Not e.Value Is Nothing Then
                    Try
                        validarFormato(e.Value)
                    Catch ex As LbControlError.cError
                        ex.Mostrar()
                        e.Cancel = True
                        e.Value = e.InitialValue
                    End Try
                End If
        End Select
    End Sub

    Private Sub UiTab1_SelectedTabChanged(ByVal sender As Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs)
        If vcFolio Is Nothing Then Exit Sub

        If Me.TabControl1.SelectedTabIndex = 1 And vcFolio.ComprobanteDig = False Then

            Try
                Throw New LbControlError.cError("I0177")
            Catch ex As LbControlError.cError
                ex.Mostrar()
            End Try

        End If
    End Sub

    Private formato As String = ""
    Private Sub GridDetalle_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellValueChanged
        If Not e.Column Is Nothing Then
            Select Case e.Column.Key
                Case "Formato"
                    If Not GridDetalle.GetValue(e.Column) Is Nothing Then
                        Try
                            validarFormato(GridDetalle.GetValue(e.Column))
                            formato = GridDetalle.GetValue(e.Column)
                        Catch ex As LbControlError.cError
                            ex.Mostrar()
                            GridDetalle.SetValue(e.Column, formato)
                        End Try
                    End If
            End Select
        End If
    End Sub

    Private Sub ebModulo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        bHuboCambios = True
    End Sub

    Private Sub cbTipoEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipoEstado.SelectedIndexChanged
        bHuboCambios = True
    End Sub

    Private Sub cbTipoDocumento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        bHuboCambios = True
    End Sub

    Private Sub MFoliosFiscales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bHuboCambios = False
        Me.TabControl1.SelectedTabIndex = 0
        If vgMODO = eModo.Crear Then
            Me.ebDescripcion.Focus()
        ElseIf vgMODO = eModo.Modificar Then
            'Me.ebModulo.Focus()
        End If
    End Sub

    Private Sub TabControl1_SelectedTabChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControl1.SelectedTabChanged
        If vcFolio Is Nothing Then Exit Sub

        If Me.TabControl1.SelectedTab.Name = "tbFiscales" And vcFolio.ComprobanteDig = False Then

            Try
                Throw New LbControlError.cError("I0177")
            Catch ex As LbControlError.cError
                ex.Mostrar()
            End Try

        End If
    End Sub

    Private Sub TabControl1_SelectedTabChanging(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControl1.SelectedTabChanging
        Try
            If Me.GridDetalle.EditMode = Janus.Windows.GridEX.EditMode.EditOn _
            Or Me.CtrlFoliosFiscales1.grAsignacion.EditMode = Janus.Windows.GridEX.EditMode.EditOn _
            Or Me.CtrlFoliosFiscales1.grFolioSolicitado.EditMode = Janus.Windows.GridEX.EditMode.EditOn Then
                e.Cancel = True
                Exit Sub
            End If

            Me.CtrlFoliosFiscales1.validarGrids()
        Catch ex As LbControlError.cError
            e.Cancel = True
            ex.Mostrar()
        End Try



    End Sub


    Private Sub TabControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.Click

    End Sub
End Class
