Imports CrystalDecisions.CrystalReports.Engine


Public Class FrmPromocion
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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiTabEstructura As Janus.Windows.UI.Tab.UITab
    Friend WithEvents TabGeneral As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpProductoRegalo As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnBuscaProducto2 As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDescripcion2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtProducto As System.Windows.Forms.TextBox
    Friend WithEvents GridRegalo As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpReglaPromocion As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents CmbFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtJerarquia As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbTipoPromocion As Selling.StoreCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblClavePromocion As System.Windows.Forms.Label
    Friend WithEvents LblTipoAplicacion As System.Windows.Forms.Label
    Friend WithEvents TxtPromocionDesc As System.Windows.Forms.TextBox
    Friend WithEvents LblPromocionDesc As System.Windows.Forms.Label
    Friend WithEvents TxtPromocionClave As System.Windows.Forms.TextBox
    Friend WithEvents LblTipoPromocion As System.Windows.Forms.Label
    Friend WithEvents TabClientes As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpClientes As System.Windows.Forms.GroupBox
    Friend WithEvents GridClientes As Janus.Windows.GridEX.GridEX
    Friend WithEvents CmbTipoAplicacion As Selling.StoreCombo
    Friend WithEvents CmbTipoCalculo As Selling.StoreCombo
    Friend WithEvents LblTipoCalculo As System.Windows.Forms.Label
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnAddCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkCascada As Selling.ChkStatus
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents UiTabProductos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregaPro As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminaPro As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents ChkIguales As Selling.ChkStatus
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UiTabSucursal As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents chkTodosClientes As Selling.ChkStatus
    Friend WithEvents grpSucursales As System.Windows.Forms.GroupBox
    Friend WithEvents ChkTodasSucursales As Selling.ChkStatus
    Friend WithEvents btnAddSuc As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDelSuc As Janus.Windows.EditControls.UIButton
    Friend WithEvents gridSucursales As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnImportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ckLimitaPago As Selling.ChkStatus
    Friend WithEvents ChkVtaPaquete As Selling.ChkStatus
    Friend WithEvents ChkTodosProductos As Selling.ChkStatus
    Friend WithEvents ChkCompraHist As Selling.ChkStatus
    Friend WithEvents UiTabPage1 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btAddProdCom As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCanProdComp As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridProdCompra As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbFechaFinCom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbFechaInComp As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnImpCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkTodos As Selling.ChkStatus
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPromocion))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.UiTabEstructura = New Janus.Windows.UI.Tab.UITab()
        Me.TabGeneral = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpProductoRegalo = New System.Windows.Forms.GroupBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.BtnBuscaProducto2 = New Janus.Windows.EditControls.UIButton()
        Me.TxtDescripcion2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtProducto = New System.Windows.Forms.TextBox()
        Me.GridRegalo = New Janus.Windows.GridEX.GridEX()
        Me.GrpReglaPromocion = New System.Windows.Forms.GroupBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.ChkIguales = New Selling.ChkStatus(Me.components)
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.GrpGeneral = New System.Windows.Forms.GroupBox()
        Me.ChkCompraHist = New Selling.ChkStatus(Me.components)
        Me.ChkVtaPaquete = New Selling.ChkStatus(Me.components)
        Me.ChkTodosProductos = New Selling.ChkStatus(Me.components)
        Me.ckLimitaPago = New Selling.ChkStatus(Me.components)
        Me.TxtCompany = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.ChkCascada = New Selling.ChkStatus(Me.components)
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.CmbTipoCalculo = New Selling.StoreCombo()
        Me.LblTipoCalculo = New System.Windows.Forms.Label()
        Me.CmbTipoAplicacion = New Selling.StoreCombo()
        Me.CmbFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtJerarquia = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmbTipoPromocion = New Selling.StoreCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.LblClavePromocion = New System.Windows.Forms.Label()
        Me.LblTipoAplicacion = New System.Windows.Forms.Label()
        Me.TxtPromocionDesc = New System.Windows.Forms.TextBox()
        Me.LblPromocionDesc = New System.Windows.Forms.Label()
        Me.TxtPromocionClave = New System.Windows.Forms.TextBox()
        Me.LblTipoPromocion = New System.Windows.Forms.Label()
        Me.UiTabProductos = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChkTodos = New Selling.ChkStatus(Me.components)
        Me.btnImportar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregaPro = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminaPro = New Janus.Windows.EditControls.UIButton()
        Me.GridProductos = New Janus.Windows.GridEX.GridEX()
        Me.TabClientes = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpClientes = New System.Windows.Forms.GroupBox()
        Me.btnImpCte = New Janus.Windows.EditControls.UIButton()
        Me.BtnAddCte = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminaCte = New Janus.Windows.EditControls.UIButton()
        Me.GridClientes = New Janus.Windows.GridEX.GridEX()
        Me.chkTodosClientes = New Selling.ChkStatus(Me.components)
        Me.UiTabSucursal = New Janus.Windows.UI.Tab.UITabPage()
        Me.grpSucursales = New System.Windows.Forms.GroupBox()
        Me.ChkTodasSucursales = New Selling.ChkStatus(Me.components)
        Me.btnAddSuc = New Janus.Windows.EditControls.UIButton()
        Me.btnDelSuc = New Janus.Windows.EditControls.UIButton()
        Me.gridSucursales = New Janus.Windows.GridEX.GridEX()
        Me.UiTabPage1 = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbFechaFinCom = New System.Windows.Forms.DateTimePicker()
        Me.btAddProdCom = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btCanProdComp = New Janus.Windows.EditControls.UIButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbFechaInComp = New System.Windows.Forms.DateTimePicker()
        Me.GridProdCompra = New Janus.Windows.GridEX.GridEX()
        CType(Me.UiTabEstructura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabEstructura.SuspendLayout()
        Me.TabGeneral.SuspendLayout()
        Me.GrpProductoRegalo.SuspendLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridRegalo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpReglaPromocion.SuspendLayout()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpGeneral.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabProductos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabClientes.SuspendLayout()
        Me.GrpClientes.SuspendLayout()
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabSucursal.SuspendLayout()
        Me.grpSucursales.SuspendLayout()
        CType(Me.gridSucursales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridProdCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(597, 563)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(693, 563)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTabEstructura
        '
        Me.UiTabEstructura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabEstructura.BackColor = System.Drawing.Color.Transparent
        Me.UiTabEstructura.Location = New System.Drawing.Point(1, 0)
        Me.UiTabEstructura.Name = "UiTabEstructura"
        Me.UiTabEstructura.Size = New System.Drawing.Size(782, 557)
        Me.UiTabEstructura.TabIndex = 10
        Me.UiTabEstructura.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.TabGeneral, Me.UiTabProductos, Me.TabClientes, Me.UiTabSucursal, Me.UiTabPage1})
        Me.UiTabEstructura.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'TabGeneral
        '
        Me.TabGeneral.Controls.Add(Me.GrpProductoRegalo)
        Me.TabGeneral.Controls.Add(Me.GrpReglaPromocion)
        Me.TabGeneral.Controls.Add(Me.GrpGeneral)
        Me.TabGeneral.Location = New System.Drawing.Point(1, 21)
        Me.TabGeneral.Name = "TabGeneral"
        Me.TabGeneral.Size = New System.Drawing.Size(780, 535)
        Me.TabGeneral.TabStop = True
        Me.TabGeneral.Text = "Promoción"
        '
        'GrpProductoRegalo
        '
        Me.GrpProductoRegalo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpProductoRegalo.BackColor = System.Drawing.Color.Transparent
        Me.GrpProductoRegalo.Controls.Add(Me.PictureBox10)
        Me.GrpProductoRegalo.Controls.Add(Me.BtnBuscaProducto2)
        Me.GrpProductoRegalo.Controls.Add(Me.TxtDescripcion2)
        Me.GrpProductoRegalo.Controls.Add(Me.Label8)
        Me.GrpProductoRegalo.Controls.Add(Me.TxtProducto)
        Me.GrpProductoRegalo.Controls.Add(Me.GridRegalo)
        Me.GrpProductoRegalo.Location = New System.Drawing.Point(2, 305)
        Me.GrpProductoRegalo.Name = "GrpProductoRegalo"
        Me.GrpProductoRegalo.Size = New System.Drawing.Size(775, 227)
        Me.GrpProductoRegalo.TabIndex = 9
        Me.GrpProductoRegalo.TabStop = False
        Me.GrpProductoRegalo.Text = "Producto de Regalo"
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(214, 21)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox10.TabIndex = 129
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'BtnBuscaProducto2
        '
        Me.BtnBuscaProducto2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaProducto2.Image = CType(resources.GetObject("BtnBuscaProducto2.Image"), System.Drawing.Image)
        Me.BtnBuscaProducto2.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProducto2.Location = New System.Drawing.Point(743, 16)
        Me.BtnBuscaProducto2.Name = "BtnBuscaProducto2"
        Me.BtnBuscaProducto2.Size = New System.Drawing.Size(24, 24)
        Me.BtnBuscaProducto2.TabIndex = 1
        Me.BtnBuscaProducto2.ToolTipText = "Busqueda de Producto"
        Me.BtnBuscaProducto2.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtDescripcion2
        '
        Me.TxtDescripcion2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcion2.Enabled = False
        Me.TxtDescripcion2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion2.Location = New System.Drawing.Point(200, 17)
        Me.TxtDescripcion2.Multiline = True
        Me.TxtDescripcion2.Name = "TxtDescripcion2"
        Me.TxtDescripcion2.ReadOnly = True
        Me.TxtDescripcion2.Size = New System.Drawing.Size(527, 19)
        Me.TxtDescripcion2.TabIndex = 97
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(7, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 15)
        Me.Label8.TabIndex = 98
        Me.Label8.Text = "Prod. Cve."
        '
        'TxtProducto
        '
        Me.TxtProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProducto.Location = New System.Drawing.Point(80, 17)
        Me.TxtProducto.Name = "TxtProducto"
        Me.TxtProducto.Size = New System.Drawing.Size(114, 21)
        Me.TxtProducto.TabIndex = 0
        '
        'GridRegalo
        '
        Me.GridRegalo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridRegalo.ColumnAutoResize = True
        Me.GridRegalo.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridRegalo.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridRegalo.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridRegalo.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridRegalo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridRegalo.Location = New System.Drawing.Point(7, 44)
        Me.GridRegalo.Name = "GridRegalo"
        Me.GridRegalo.RecordNavigator = True
        Me.GridRegalo.Size = New System.Drawing.Size(761, 175)
        Me.GridRegalo.TabIndex = 4
        Me.GridRegalo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpReglaPromocion
        '
        Me.GrpReglaPromocion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpReglaPromocion.BackColor = System.Drawing.Color.Transparent
        Me.GrpReglaPromocion.Controls.Add(Me.PictureBox9)
        Me.GrpReglaPromocion.Controls.Add(Me.ChkIguales)
        Me.GrpReglaPromocion.Controls.Add(Me.GridDetalle)
        Me.GrpReglaPromocion.Location = New System.Drawing.Point(2, 182)
        Me.GrpReglaPromocion.Name = "GrpReglaPromocion"
        Me.GrpReglaPromocion.Size = New System.Drawing.Size(775, 117)
        Me.GrpReglaPromocion.TabIndex = 8
        Me.GrpReglaPromocion.TabStop = False
        Me.GrpReglaPromocion.Text = "Regla de Promoción"
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(106, 24)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox9.TabIndex = 130
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'ChkIguales
        '
        Me.ChkIguales.Checked = True
        Me.ChkIguales.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkIguales.Location = New System.Drawing.Point(8, 18)
        Me.ChkIguales.Name = "ChkIguales"
        Me.ChkIguales.Size = New System.Drawing.Size(200, 27)
        Me.ChkIguales.TabIndex = 129
        Me.ChkIguales.Text = "Del mismo producto"
        '
        'GridDetalle
        '
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(7, 45)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(761, 66)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpGeneral.BackColor = System.Drawing.Color.Transparent
        Me.GrpGeneral.Controls.Add(Me.ChkCompraHist)
        Me.GrpGeneral.Controls.Add(Me.ChkVtaPaquete)
        Me.GrpGeneral.Controls.Add(Me.ChkTodosProductos)
        Me.GrpGeneral.Controls.Add(Me.ckLimitaPago)
        Me.GrpGeneral.Controls.Add(Me.TxtCompany)
        Me.GrpGeneral.Controls.Add(Me.Label1)
        Me.GrpGeneral.Controls.Add(Me.ChkEstado)
        Me.GrpGeneral.Controls.Add(Me.ChkCascada)
        Me.GrpGeneral.Controls.Add(Me.PictureBox8)
        Me.GrpGeneral.Controls.Add(Me.PictureBox7)
        Me.GrpGeneral.Controls.Add(Me.PictureBox6)
        Me.GrpGeneral.Controls.Add(Me.PictureBox4)
        Me.GrpGeneral.Controls.Add(Me.PictureBox3)
        Me.GrpGeneral.Controls.Add(Me.CmbTipoCalculo)
        Me.GrpGeneral.Controls.Add(Me.LblTipoCalculo)
        Me.GrpGeneral.Controls.Add(Me.CmbTipoAplicacion)
        Me.GrpGeneral.Controls.Add(Me.CmbFechaFin)
        Me.GrpGeneral.Controls.Add(Me.Label2)
        Me.GrpGeneral.Controls.Add(Me.PictureBox5)
        Me.GrpGeneral.Controls.Add(Me.PictureBox2)
        Me.GrpGeneral.Controls.Add(Me.PictureBox1)
        Me.GrpGeneral.Controls.Add(Me.txtJerarquia)
        Me.GrpGeneral.Controls.Add(Me.Label7)
        Me.GrpGeneral.Controls.Add(Me.CmbTipoPromocion)
        Me.GrpGeneral.Controls.Add(Me.Label4)
        Me.GrpGeneral.Controls.Add(Me.CmbFechaInicio)
        Me.GrpGeneral.Controls.Add(Me.LblClavePromocion)
        Me.GrpGeneral.Controls.Add(Me.LblTipoAplicacion)
        Me.GrpGeneral.Controls.Add(Me.TxtPromocionDesc)
        Me.GrpGeneral.Controls.Add(Me.LblPromocionDesc)
        Me.GrpGeneral.Controls.Add(Me.TxtPromocionClave)
        Me.GrpGeneral.Controls.Add(Me.LblTipoPromocion)
        Me.GrpGeneral.Location = New System.Drawing.Point(2, 4)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(775, 172)
        Me.GrpGeneral.TabIndex = 119
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "Datos Generales"
        '
        'ChkCompraHist
        '
        Me.ChkCompraHist.Checked = True
        Me.ChkCompraHist.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkCompraHist.Location = New System.Drawing.Point(642, 139)
        Me.ChkCompraHist.Name = "ChkCompraHist"
        Me.ChkCompraHist.Size = New System.Drawing.Size(101, 27)
        Me.ChkCompraHist.TabIndex = 135
        Me.ChkCompraHist.Text = "Compras Hist"
        '
        'ChkVtaPaquete
        '
        Me.ChkVtaPaquete.Checked = True
        Me.ChkVtaPaquete.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkVtaPaquete.Location = New System.Drawing.Point(479, 139)
        Me.ChkVtaPaquete.Name = "ChkVtaPaquete"
        Me.ChkVtaPaquete.Size = New System.Drawing.Size(184, 27)
        Me.ChkVtaPaquete.TabIndex = 134
        Me.ChkVtaPaquete.Text = "Aplica solo para Paquetes"
        '
        'ChkTodosProductos
        '
        Me.ChkTodosProductos.Checked = True
        Me.ChkTodosProductos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkTodosProductos.Location = New System.Drawing.Point(277, 141)
        Me.ChkTodosProductos.Name = "ChkTodosProductos"
        Me.ChkTodosProductos.Size = New System.Drawing.Size(196, 27)
        Me.ChkTodosProductos.TabIndex = 133
        Me.ChkTodosProductos.Text = "Adquiriendo Todos los Productos"
        '
        'ckLimitaPago
        '
        Me.ckLimitaPago.Checked = True
        Me.ckLimitaPago.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckLimitaPago.Location = New System.Drawing.Point(139, 141)
        Me.ckLimitaPago.Name = "ckLimitaPago"
        Me.ckLimitaPago.Size = New System.Drawing.Size(151, 27)
        Me.ckLimitaPago.TabIndex = 132
        Me.ckLimitaPago.Text = "Limitar forma de pago"
        '
        'TxtCompany
        '
        Me.TxtCompany.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCompany.Enabled = False
        Me.TxtCompany.Location = New System.Drawing.Point(90, 14)
        Me.TxtCompany.Name = "TxtCompany"
        Me.TxtCompany.ReadOnly = True
        Me.TxtCompany.Size = New System.Drawing.Size(521, 20)
        Me.TxtCompany.TabIndex = 131
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 15)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Compañia"
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(550, 10)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(61, 27)
        Me.ChkEstado.TabIndex = 129
        Me.ChkEstado.Text = "Activo"
        '
        'ChkCascada
        '
        Me.ChkCascada.Checked = True
        Me.ChkCascada.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkCascada.Location = New System.Drawing.Point(13, 142)
        Me.ChkCascada.Name = "ChkCascada"
        Me.ChkCascada.Size = New System.Drawing.Size(101, 27)
        Me.ChkCascada.TabIndex = 128
        Me.ChkCascada.Text = "Aplica Cascada"
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(482, 119)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox8.TabIndex = 127
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(233, 118)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox7.TabIndex = 126
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(597, 91)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox6.TabIndex = 125
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(194, 92)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox4.TabIndex = 124
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(596, 65)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox3.TabIndex = 117
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'CmbTipoCalculo
        '
        Me.CmbTipoCalculo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipoCalculo.Location = New System.Drawing.Point(332, 118)
        Me.CmbTipoCalculo.Name = "CmbTipoCalculo"
        Me.CmbTipoCalculo.Size = New System.Drawing.Size(146, 21)
        Me.CmbTipoCalculo.TabIndex = 7
        '
        'LblTipoCalculo
        '
        Me.LblTipoCalculo.Location = New System.Drawing.Point(233, 122)
        Me.LblTipoCalculo.Name = "LblTipoCalculo"
        Me.LblTipoCalculo.Size = New System.Drawing.Size(103, 16)
        Me.LblTipoCalculo.TabIndex = 122
        Me.LblTipoCalculo.Text = "Calcular en base a"
        '
        'CmbTipoAplicacion
        '
        Me.CmbTipoAplicacion.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipoAplicacion.Location = New System.Drawing.Point(90, 118)
        Me.CmbTipoAplicacion.Name = "CmbTipoAplicacion"
        Me.CmbTipoAplicacion.Size = New System.Drawing.Size(137, 21)
        Me.CmbTipoAplicacion.TabIndex = 6
        '
        'CmbFechaFin
        '
        Me.CmbFechaFin.CustomFormat = "yyyyMMdd"
        Me.CmbFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CmbFechaFin.Location = New System.Drawing.Point(251, 91)
        Me.CmbFechaFin.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.CmbFechaFin.Name = "CmbFechaFin"
        Me.CmbFechaFin.Size = New System.Drawing.Size(98, 20)
        Me.CmbFechaFin.TabIndex = 4
        Me.CmbFechaFin.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(213, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 15)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "al"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(354, 91)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox5.TabIndex = 118
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(482, 39)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox2.TabIndex = 115
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(297, 40)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 114
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'txtJerarquia
        '
        Me.txtJerarquia.Location = New System.Drawing.Point(537, 92)
        Me.txtJerarquia.Name = "txtJerarquia"
        Me.txtJerarquia.Size = New System.Drawing.Size(55, 20)
        Me.txtJerarquia.TabIndex = 5
        Me.txtJerarquia.Text = "0"
        Me.txtJerarquia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtJerarquia.Value = 0
        Me.txtJerarquia.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(470, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 16)
        Me.Label7.TabIndex = 106
        Me.Label7.Text = "Jerarquía"
        '
        'CmbTipoPromocion
        '
        Me.CmbTipoPromocion.Location = New System.Drawing.Point(90, 39)
        Me.CmbTipoPromocion.Name = "CmbTipoPromocion"
        Me.CmbTipoPromocion.Size = New System.Drawing.Size(202, 21)
        Me.CmbTipoPromocion.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(10, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 102
        Me.Label4.Text = "Vigencia del"
        '
        'CmbFechaInicio
        '
        Me.CmbFechaInicio.CustomFormat = "yyyyMMdd"
        Me.CmbFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CmbFechaInicio.Location = New System.Drawing.Point(90, 91)
        Me.CmbFechaInicio.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.CmbFechaInicio.Name = "CmbFechaInicio"
        Me.CmbFechaInicio.Size = New System.Drawing.Size(98, 20)
        Me.CmbFechaInicio.TabIndex = 3
        Me.CmbFechaInicio.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'LblClavePromocion
        '
        Me.LblClavePromocion.Location = New System.Drawing.Point(307, 42)
        Me.LblClavePromocion.Name = "LblClavePromocion"
        Me.LblClavePromocion.Size = New System.Drawing.Size(46, 16)
        Me.LblClavePromocion.TabIndex = 100
        Me.LblClavePromocion.Text = "Clave"
        '
        'LblTipoAplicacion
        '
        Me.LblTipoAplicacion.Location = New System.Drawing.Point(10, 123)
        Me.LblTipoAplicacion.Name = "LblTipoAplicacion"
        Me.LblTipoAplicacion.Size = New System.Drawing.Size(90, 16)
        Me.LblTipoAplicacion.TabIndex = 95
        Me.LblTipoAplicacion.Text = "Tipo Aplicación"
        '
        'TxtPromocionDesc
        '
        Me.TxtPromocionDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPromocionDesc.Location = New System.Drawing.Point(90, 64)
        Me.TxtPromocionDesc.Name = "TxtPromocionDesc"
        Me.TxtPromocionDesc.Size = New System.Drawing.Size(503, 21)
        Me.TxtPromocionDesc.TabIndex = 2
        '
        'LblPromocionDesc
        '
        Me.LblPromocionDesc.Location = New System.Drawing.Point(8, 69)
        Me.LblPromocionDesc.Name = "LblPromocionDesc"
        Me.LblPromocionDesc.Size = New System.Drawing.Size(65, 15)
        Me.LblPromocionDesc.TabIndex = 26
        Me.LblPromocionDesc.Text = "Descripción"
        '
        'TxtPromocionClave
        '
        Me.TxtPromocionClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPromocionClave.Location = New System.Drawing.Point(357, 38)
        Me.TxtPromocionClave.MaxLength = 5
        Me.TxtPromocionClave.Name = "TxtPromocionClave"
        Me.TxtPromocionClave.Size = New System.Drawing.Size(121, 21)
        Me.TxtPromocionClave.TabIndex = 1
        '
        'LblTipoPromocion
        '
        Me.LblTipoPromocion.Location = New System.Drawing.Point(7, 43)
        Me.LblTipoPromocion.Name = "LblTipoPromocion"
        Me.LblTipoPromocion.Size = New System.Drawing.Size(100, 15)
        Me.LblTipoPromocion.TabIndex = 108
        Me.LblTipoPromocion.Text = "Tipo Promoción"
        '
        'UiTabProductos
        '
        Me.UiTabProductos.Controls.Add(Me.GroupBox1)
        Me.UiTabProductos.Location = New System.Drawing.Point(1, 21)
        Me.UiTabProductos.Name = "UiTabProductos"
        Me.UiTabProductos.Size = New System.Drawing.Size(780, 535)
        Me.UiTabProductos.TabStop = True
        Me.UiTabProductos.Text = "Productos"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.ChkTodos)
        Me.GroupBox1.Controls.Add(Me.btnImportar)
        Me.GroupBox1.Controls.Add(Me.BtnAgregaPro)
        Me.GroupBox1.Controls.Add(Me.BtnEliminaPro)
        Me.GroupBox1.Controls.Add(Me.GridProductos)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(764, 518)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Productos a los que aplica la promoción"
        '
        'ChkTodos
        '
        Me.ChkTodos.Location = New System.Drawing.Point(7, 21)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(143, 27)
        Me.ChkTodos.TabIndex = 160
        Me.ChkTodos.Text = "Seleccionar todos"
        '
        'btnImportar
        '
        Me.btnImportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImportar.Image = Global.Selling.My.Resources.Resources._1451374105_icon_57_document_download
        Me.btnImportar.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnImportar.Location = New System.Drawing.Point(617, 18)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(43, 30)
        Me.btnImportar.TabIndex = 159
        Me.btnImportar.ToolTipText = "Importar productos"
        Me.btnImportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregaPro
        '
        Me.BtnAgregaPro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregaPro.Image = CType(resources.GetObject("BtnAgregaPro.Image"), System.Drawing.Image)
        Me.BtnAgregaPro.Location = New System.Drawing.Point(715, 18)
        Me.BtnAgregaPro.Name = "BtnAgregaPro"
        Me.BtnAgregaPro.Size = New System.Drawing.Size(43, 30)
        Me.BtnAgregaPro.TabIndex = 4
        Me.BtnAgregaPro.ToolTipText = "Agregar nuevos productos a la promoción"
        Me.BtnAgregaPro.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminaPro
        '
        Me.BtnEliminaPro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminaPro.Image = CType(resources.GetObject("BtnEliminaPro.Image"), System.Drawing.Image)
        Me.BtnEliminaPro.Location = New System.Drawing.Point(666, 18)
        Me.BtnEliminaPro.Name = "BtnEliminaPro"
        Me.BtnEliminaPro.Size = New System.Drawing.Size(43, 30)
        Me.BtnEliminaPro.TabIndex = 5
        Me.BtnEliminaPro.ToolTipText = "Eliminar producto seleccionado de la promoción"
        Me.BtnEliminaPro.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridProductos
        '
        Me.GridProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridProductos.AutoEdit = True
        Me.GridProductos.ColumnAutoResize = True
        Me.GridProductos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridProductos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridProductos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridProductos.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridProductos.GroupByBoxVisible = False
        Me.GridProductos.Location = New System.Drawing.Point(7, 54)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.RecordNavigator = True
        Me.GridProductos.Size = New System.Drawing.Size(751, 458)
        Me.GridProductos.TabIndex = 1
        Me.GridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'TabClientes
        '
        Me.TabClientes.Controls.Add(Me.GrpClientes)
        Me.TabClientes.Location = New System.Drawing.Point(1, 21)
        Me.TabClientes.Name = "TabClientes"
        Me.TabClientes.Size = New System.Drawing.Size(780, 535)
        Me.TabClientes.TabStop = True
        Me.TabClientes.Text = "Clientes"
        Me.TabClientes.ToolTipText = "Clientes a los que aplica la promoción"
        '
        'GrpClientes
        '
        Me.GrpClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpClientes.BackColor = System.Drawing.Color.Transparent
        Me.GrpClientes.Controls.Add(Me.btnImpCte)
        Me.GrpClientes.Controls.Add(Me.BtnAddCte)
        Me.GrpClientes.Controls.Add(Me.BtnEliminaCte)
        Me.GrpClientes.Controls.Add(Me.GridClientes)
        Me.GrpClientes.Controls.Add(Me.chkTodosClientes)
        Me.GrpClientes.Location = New System.Drawing.Point(7, 7)
        Me.GrpClientes.Name = "GrpClientes"
        Me.GrpClientes.Size = New System.Drawing.Size(763, 481)
        Me.GrpClientes.TabIndex = 4
        Me.GrpClientes.TabStop = False
        Me.GrpClientes.Text = "Clientes a los que aplica la promoción"
        '
        'btnImpCte
        '
        Me.btnImpCte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImpCte.Enabled = False
        Me.btnImpCte.Image = Global.Selling.My.Resources.Resources._1451374105_icon_57_document_download
        Me.btnImpCte.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnImpCte.Location = New System.Drawing.Point(619, 19)
        Me.btnImpCte.Name = "btnImpCte"
        Me.btnImpCte.Size = New System.Drawing.Size(43, 30)
        Me.btnImpCte.TabIndex = 160
        Me.btnImpCte.ToolTipText = "Importar clientes"
        Me.btnImpCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAddCte
        '
        Me.BtnAddCte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddCte.Enabled = False
        Me.BtnAddCte.Image = CType(resources.GetObject("BtnAddCte.Image"), System.Drawing.Image)
        Me.BtnAddCte.Location = New System.Drawing.Point(717, 19)
        Me.BtnAddCte.Name = "BtnAddCte"
        Me.BtnAddCte.Size = New System.Drawing.Size(40, 30)
        Me.BtnAddCte.TabIndex = 4
        Me.BtnAddCte.ToolTipText = "Agregar cliente a la promoción"
        Me.BtnAddCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminaCte
        '
        Me.BtnEliminaCte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminaCte.Enabled = False
        Me.BtnEliminaCte.Image = CType(resources.GetObject("BtnEliminaCte.Image"), System.Drawing.Image)
        Me.BtnEliminaCte.Location = New System.Drawing.Point(668, 19)
        Me.BtnEliminaCte.Name = "BtnEliminaCte"
        Me.BtnEliminaCte.Size = New System.Drawing.Size(43, 30)
        Me.BtnEliminaCte.TabIndex = 5
        Me.BtnEliminaCte.ToolTipText = "Eliminar cliente seleccionado de la promoción"
        Me.BtnEliminaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridClientes
        '
        Me.GridClientes.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridClientes.ColumnAutoResize = True
        Me.GridClientes.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridClientes.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridClientes.Enabled = False
        Me.GridClientes.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridClientes.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridClientes.GroupByBoxVisible = False
        Me.GridClientes.Location = New System.Drawing.Point(7, 55)
        Me.GridClientes.Name = "GridClientes"
        Me.GridClientes.RecordNavigator = True
        Me.GridClientes.Size = New System.Drawing.Size(750, 420)
        Me.GridClientes.TabIndex = 1
        Me.GridClientes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'chkTodosClientes
        '
        Me.chkTodosClientes.Checked = True
        Me.chkTodosClientes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodosClientes.Location = New System.Drawing.Point(7, 22)
        Me.chkTodosClientes.Name = "chkTodosClientes"
        Me.chkTodosClientes.Size = New System.Drawing.Size(293, 27)
        Me.chkTodosClientes.TabIndex = 129
        Me.chkTodosClientes.Text = "Aplica a todos los clientes"
        '
        'UiTabSucursal
        '
        Me.UiTabSucursal.Controls.Add(Me.grpSucursales)
        Me.UiTabSucursal.Location = New System.Drawing.Point(1, 21)
        Me.UiTabSucursal.Name = "UiTabSucursal"
        Me.UiTabSucursal.Size = New System.Drawing.Size(780, 535)
        Me.UiTabSucursal.TabStop = True
        Me.UiTabSucursal.Text = "Sucursales"
        '
        'grpSucursales
        '
        Me.grpSucursales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSucursales.BackColor = System.Drawing.Color.Transparent
        Me.grpSucursales.Controls.Add(Me.ChkTodasSucursales)
        Me.grpSucursales.Controls.Add(Me.btnAddSuc)
        Me.grpSucursales.Controls.Add(Me.btnDelSuc)
        Me.grpSucursales.Controls.Add(Me.gridSucursales)
        Me.grpSucursales.Location = New System.Drawing.Point(7, 8)
        Me.grpSucursales.Name = "grpSucursales"
        Me.grpSucursales.Size = New System.Drawing.Size(763, 482)
        Me.grpSucursales.TabIndex = 5
        Me.grpSucursales.TabStop = False
        Me.grpSucursales.Text = "Sucursales en las que aplica la promoción"
        '
        'ChkTodasSucursales
        '
        Me.ChkTodasSucursales.Checked = True
        Me.ChkTodasSucursales.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkTodasSucursales.Location = New System.Drawing.Point(7, 22)
        Me.ChkTodasSucursales.Name = "ChkTodasSucursales"
        Me.ChkTodasSucursales.Size = New System.Drawing.Size(238, 27)
        Me.ChkTodasSucursales.TabIndex = 129
        Me.ChkTodasSucursales.Text = "Aplica a todas las sucursales"
        '
        'btnAddSuc
        '
        Me.btnAddSuc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddSuc.Enabled = False
        Me.btnAddSuc.Image = CType(resources.GetObject("btnAddSuc.Image"), System.Drawing.Image)
        Me.btnAddSuc.Location = New System.Drawing.Point(717, 19)
        Me.btnAddSuc.Name = "btnAddSuc"
        Me.btnAddSuc.Size = New System.Drawing.Size(40, 30)
        Me.btnAddSuc.TabIndex = 4
        Me.btnAddSuc.ToolTipText = "Agregar sucursal a la promoción"
        Me.btnAddSuc.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnDelSuc
        '
        Me.btnDelSuc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelSuc.Enabled = False
        Me.btnDelSuc.Image = CType(resources.GetObject("btnDelSuc.Image"), System.Drawing.Image)
        Me.btnDelSuc.Location = New System.Drawing.Point(668, 19)
        Me.btnDelSuc.Name = "btnDelSuc"
        Me.btnDelSuc.Size = New System.Drawing.Size(43, 30)
        Me.btnDelSuc.TabIndex = 5
        Me.btnDelSuc.ToolTipText = "Eliminar sucursal seleccionada de la promoción"
        Me.btnDelSuc.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gridSucursales
        '
        Me.gridSucursales.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.gridSucursales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridSucursales.ColumnAutoResize = True
        Me.gridSucursales.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.gridSucursales.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.gridSucursales.Enabled = False
        Me.gridSucursales.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.gridSucursales.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.gridSucursales.GroupByBoxVisible = False
        Me.gridSucursales.Location = New System.Drawing.Point(7, 55)
        Me.gridSucursales.Name = "gridSucursales"
        Me.gridSucursales.RecordNavigator = True
        Me.gridSucursales.Size = New System.Drawing.Size(750, 421)
        Me.gridSucursales.TabIndex = 1
        Me.gridSucursales.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabPage1
        '
        Me.UiTabPage1.Controls.Add(Me.GroupBox2)
        Me.UiTabPage1.Location = New System.Drawing.Point(1, 21)
        Me.UiTabPage1.Name = "UiTabPage1"
        Me.UiTabPage1.Size = New System.Drawing.Size(780, 535)
        Me.UiTabPage1.TabStop = True
        Me.UiTabPage1.Text = "Compras Hist"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.cmbFechaFinCom)
        Me.GroupBox2.Controls.Add(Me.btAddProdCom)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btCanProdComp)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbFechaInComp)
        Me.GroupBox2.Controls.Add(Me.GridProdCompra)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(764, 507)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Productos que se tendrian que haber comprado"
        '
        'cmbFechaFinCom
        '
        Me.cmbFechaFinCom.CustomFormat = "yyyyMMdd"
        Me.cmbFechaFinCom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFechaFinCom.Location = New System.Drawing.Point(248, 21)
        Me.cmbFechaFinCom.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaFinCom.Name = "cmbFechaFinCom"
        Me.cmbFechaFinCom.Size = New System.Drawing.Size(98, 20)
        Me.cmbFechaFinCom.TabIndex = 121
        Me.cmbFechaFinCom.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'btAddProdCom
        '
        Me.btAddProdCom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btAddProdCom.Image = CType(resources.GetObject("btAddProdCom.Image"), System.Drawing.Image)
        Me.btAddProdCom.Location = New System.Drawing.Point(715, 15)
        Me.btAddProdCom.Name = "btAddProdCom"
        Me.btAddProdCom.Size = New System.Drawing.Size(43, 30)
        Me.btAddProdCom.TabIndex = 4
        Me.btAddProdCom.ToolTipText = "Agregar nuevos productos a la promoción"
        Me.btAddProdCom.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(210, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 15)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "al"
        '
        'btCanProdComp
        '
        Me.btCanProdComp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCanProdComp.Image = CType(resources.GetObject("btCanProdComp.Image"), System.Drawing.Image)
        Me.btCanProdComp.Location = New System.Drawing.Point(666, 15)
        Me.btCanProdComp.Name = "btCanProdComp"
        Me.btCanProdComp.Size = New System.Drawing.Size(43, 30)
        Me.btCanProdComp.TabIndex = 5
        Me.btCanProdComp.ToolTipText = "Eliminar producto seleccionado de la promoción"
        Me.btCanProdComp.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 15)
        Me.Label5.TabIndex = 122
        Me.Label5.Text = "Vigencia del"
        '
        'cmbFechaInComp
        '
        Me.cmbFechaInComp.CustomFormat = "yyyyMMdd"
        Me.cmbFechaInComp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFechaInComp.Location = New System.Drawing.Point(87, 21)
        Me.cmbFechaInComp.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaInComp.Name = "cmbFechaInComp"
        Me.cmbFechaInComp.Size = New System.Drawing.Size(98, 20)
        Me.cmbFechaInComp.TabIndex = 120
        Me.cmbFechaInComp.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'GridProdCompra
        '
        Me.GridProdCompra.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridProdCompra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridProdCompra.ColumnAutoResize = True
        Me.GridProdCompra.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridProdCompra.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridProdCompra.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridProdCompra.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridProdCompra.GroupByBoxVisible = False
        Me.GridProdCompra.Location = New System.Drawing.Point(7, 53)
        Me.GridProdCompra.Name = "GridProdCompra"
        Me.GridProdCompra.RecordNavigator = True
        Me.GridProdCompra.Size = New System.Drawing.Size(751, 448)
        Me.GridProdCompra.TabIndex = 1
        Me.GridProdCompra.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmPromocion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 605)
        Me.Controls.Add(Me.UiTabEstructura)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmPromocion"
        Me.Text = "Promoción"
        CType(Me.UiTabEstructura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabEstructura.ResumeLayout(False)
        Me.TabGeneral.ResumeLayout(False)
        Me.GrpProductoRegalo.ResumeLayout(False)
        Me.GrpProductoRegalo.PerformLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridRegalo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpReglaPromocion.ResumeLayout(False)
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpGeneral.ResumeLayout(False)
        Me.GrpGeneral.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabProductos.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabClientes.ResumeLayout(False)
        Me.GrpClientes.ResumeLayout(False)
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabSucursal.ResumeLayout(False)
        Me.grpSucursales.ResumeLayout(False)
        CType(Me.gridSucursales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridProdCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String
    Public PRMClave As String
    Public FechaInicio As DateTime
    Public FechaFin As DateTime
    Public Clave As String
    Public Descripcion As String
    Public Tipo As Integer
    Public Aplicacion As Integer
    Public CalculoBase As Integer
    Public Jerarquia As Integer
    Public Cascada As Integer
    Public LimitaPago As Integer
    Public Estado As Integer
    Public Iguales As Integer
    Public TodasSucursales As Integer = 1
    Public TodosProductos As Integer = 0
    Public VtaPaquete As Integer = 0
    Public TodosClientes As Integer = 1
    Public CompraHist As Integer = 0
    Public FechaInicioHist As DateTime
    Public FechaFinHist As DateTime
    Private PROClave As String
    Private CveProducto As String
    Private Nombre As String
    Private TallaColor As Integer = 0
    Private sClienteSelected, sProductoSelected, sSucursalSelected As String
    Private sNombre, sNombreProducto, sNombreSucursal As String

    Private alerta(9) As PictureBox
    Private reloj As parpadea

    Private cargado As Boolean = False
    Private DetalleEdited As Boolean = False
    Private RegaloEdited As Boolean = False

    Private dtDetalle, dtRegalo, dtCliente, dtProducto, dtSucursal, dtPromocionCompra As DataTable


    Private Function ImportarClientes() As Boolean
        Dim curFileName As String = ""
        Try
            Dim openDlg As OpenFileDialog = New OpenFileDialog
            openDlg.Filter = "Todos los archivos de CSV|*.CSV|Todos los archivos TXT|*.TXT"
            ' Dim filter As String = openDlg.Filter
            openDlg.Title = "Abrir un Archivo de CSV o TXT"
            If (openDlg.ShowDialog() = DialogResult.OK) Then
                curFileName = openDlg.FileName

                Dim dtTemporal As DataTable = ReadCSV(curFileName, 1)

                If dtTemporal.Rows.Count > 0 Then


                    Dim frmStatusMessage As New frmStatus
                    frmStatusMessage.BringToFront()

                    Dim i As Integer
                    Dim CTEClave, Clave, Nombre, RFC As String

                    Dim dtError As DataTable = ModPOS.CrearTabla("Error", _
                                              "Fila", "System.String", _
                                              "Cliente", "System.String", _
                                              "Error", "System.String")

                    Dim dt As DataTable


                    For i = 0 To dtTemporal.Rows.Count - 1
                        frmStatusMessage.Show("Procesando " & CStr(i + 1) & " de " & CStr(dtTemporal.Rows.Count) & " registros")
                        ' valida el producto
                        If dtTemporal.Rows(i)("GTIN").GetType.FullName <> "System.DBNull" Then

                            dt = ModPOS.Recupera_Tabla("sp_recupera_clavecte", "@Clave", dtTemporal.Rows(i)("GTIN").ToString.Replace("'", "''").Trim, "@COMClave", ModPOS.CompanyActual)


                            If dt.Rows.Count > 0 Then
                                CTEClave = dt.Rows(0)("CTEClave")
                                Clave = dt.Rows(0)("Clave")
                                Nombre = dt.Rows(0)("RazonSocial")
                                RFC = dt.Rows(0)("Id_Fiscal")
                                dt.Dispose()
                                addClienteDetalle(CTEClave, Clave, Nombre, RFC)
                            Else
                                dt.Dispose()
                                Dim row1 As DataRow
                                row1 = dtError.NewRow()
                                'declara el nombre de la fila
                                row1.Item("Fila") = i + 1
                                row1.Item("Cliente") = dtTemporal.Rows(i)("GTIN").ToString
                                row1.Item("Error") = "La clave de cliente no existe"
                                dtError.Rows.Add(row1)
                            End If
                        Else
                            Dim row1 As DataRow
                            row1 = dtError.NewRow()
                            'declara el nombre de la fila
                            row1.Item("Fila") = i + 1
                            row1.Item("Cliente") = dtTemporal.Rows(i)("GTIN").ToString
                            row1.Item("Error") = "La clave de Cliente se encuentra vacia"
                            dtError.Rows.Add(row1)
                        End If
                    Next

                    If dtError.Rows.Count > 0 Then
                        MessageBox.Show("Se encontraron " & CStr(dtError.Rows.Count) & "Errores, al procesar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Dim b As New FrmConsultaGen
                        b.Text = "Errores"
                        b.GridConsultaGen.DataSource = dtError
                        b.GridConsultaGen.RetrieveStructure(True)
                        b.GridConsultaGen.GroupByBoxVisible = False
                        b.ShowDialog()
                        b.Dispose()
                        dtError.Dispose()
                    Else
                        MessageBox.Show("El archivo se proceso sin errores", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                    frmStatusMessage.Close()
                    Cursor.Current = Cursors.Default
                Else
                    MessageBox.Show("El archivo no cuenta con el formato: ClaveCliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function



    Private Function ImportarProductos() As Boolean
        Dim curFileName As String = ""
        Try
            Dim openDlg As OpenFileDialog = New OpenFileDialog
            openDlg.Filter = "Todos los archivos de CSV|*.CSV|Todos los archivos TXT|*.TXT"
            ' Dim filter As String = openDlg.Filter
            openDlg.Title = "Abrir un Archivo de CSV o TXT"
            If (openDlg.ShowDialog() = DialogResult.OK) Then
                curFileName = openDlg.FileName

                Dim dtTemporal As DataTable = ReadCSV(curFileName, 1)

                If dtTemporal.Rows.Count > 0 Then


                    Dim frmStatusMessage As New frmStatus
                    frmStatusMessage.BringToFront()

                    Dim i As Integer
                    Dim PROClave, Clave, Nombre As String

                    Dim dtError As DataTable = ModPOS.CrearTabla("Error", _
                                              "Fila", "System.String", _
                                              "Producto", "System.String", _
                                              "Error", "System.String")

                    Dim dt As DataTable


                    For i = 0 To dtTemporal.Rows.Count - 1
                        frmStatusMessage.Show("Procesando " & CStr(i + 1) & " de " & CStr(dtTemporal.Rows.Count) & " registros")
                        ' valida el producto
                        If dtTemporal.Rows(i)("GTIN").GetType.FullName <> "System.DBNull" Then
                            dt = Recupera_Tabla("sp_compra_producto", "@COMClave", ModPOS.CompanyActual, "@Clave", dtTemporal.Rows(i)("GTIN").ToString.Replace("'", "''").Trim, "@Char", cReplace)
                            If dt.Rows.Count > 0 Then
                                PROClave = dt.Rows(0)("PROClave")
                                Clave = dt.Rows(0)("Clave")
                                Nombre = dt.Rows(0)("Nombre")
                                dt.Dispose()
                                addProductoPromocion(PROClave, Clave, Nombre, 1)
                            Else
                                dt.Dispose()
                                Dim row1 As DataRow
                                row1 = dtError.NewRow()
                                'declara el nombre de la fila
                                row1.Item("Fila") = i + 1
                                row1.Item("Producto") = dtTemporal.Rows(i)("GTIN").ToString
                                row1.Item("Error") = "La clave de producto no existe"
                                dtError.Rows.Add(row1)
                            End If
                        Else
                            Dim row1 As DataRow
                            row1 = dtError.NewRow()
                            'declara el nombre de la fila
                            row1.Item("Fila") = i + 1
                            row1.Item("Producto") = dtTemporal.Rows(i)("GTIN").ToString
                            row1.Item("Error") = "La clave de producto se encuentra vacia"
                            dtError.Rows.Add(row1)
                        End If
                    Next

                    If dtError.Rows.Count > 0 Then
                        MessageBox.Show("Se encontraron " & CStr(dtError.Rows.Count) & "Errores, al procesar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Dim b As New FrmConsultaGen
                        b.Text = "Errores"
                        b.GridConsultaGen.DataSource = dtError
                        b.GridConsultaGen.RetrieveStructure(True)
                        b.GridConsultaGen.GroupByBoxVisible = False
                        b.ShowDialog()
                        b.Dispose()
                        dtError.Dispose()
                    Else
                        MessageBox.Show("El archivo se proceso sin errores", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                    frmStatusMessage.Close()
                    Cursor.Current = Cursors.Default
                Else
                    MessageBox.Show("El archivo no cuenta con el formato: Productoid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbTipoPromocion.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtPromocionClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtPromocionDesc.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If txtJerarquia.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbTipoAplicacion.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbTipoCalculo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()
        End If

        If GridDetalle.RowCount <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(8))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CmbTipoPromocion.SelectedValue = 3 AndAlso GridRegalo.RowCount <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(9))
            reloj.Enabled = True
            reloj.Start()
        End If


        If CmbFechaInicio.Value > CmbFechaFin.Value Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Promocion", "@clave", UCase(Trim(Me.TxtPromocionClave.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("La Referencia que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(0))
                reloj.Enabled = True
                reloj.Start()
                Return False
            Else
                While i < Me.alerta.Length
                    Me.alerta(i).Visible = False
                    i += 1
                End While
                Return True
            End If
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Private Sub recuperaProducto(ByVal sClave As String)
        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_busca_producto", "@Clave", sClave, "@COMClave", ModPOS.CompanyActual, "@Char", cReplace)
        Dim TipoProducto As Integer
        If Not dtProducto Is Nothing Then

            PROClave = dtProducto.Rows(0)("PROClave")
            CveProducto = dtProducto.Rows(0)("Clave")
            Nombre = dtProducto.Rows(0)("Nombre")
            TipoProducto = dtProducto.Rows(0)("TProducto")
            dtProducto.Dispose()


            If TipoProducto > 2 Then
                PROClave = ""
                CveProducto = ""

                MessageBox.Show("¡Solo aplica productos de tipo Convencional o Promocional!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Dim foundRows() As System.Data.DataRow
            foundRows = dtRegalo.Select("PROClave Like '" & PROClave & "'")

            If foundRows.Length = 0 Then
                Dim row1 As DataRow
                row1 = dtRegalo.NewRow()
                'declara el nombre de la fila
                row1.Item("ID") = PRMClave
                row1.Item("PROClave") = PROClave
                row1.Item("Clave") = CveProducto
                row1.Item("Descripcion") = Nombre
                row1.Item("Cantidad") = 1
                row1.Item("Descuento") = 100
                'agrega la fila completo a la tabla
                dtRegalo.Rows.Add(row1)
                RegaloEdited = True
            End If
            Me.TxtDescripcion2.Text = Nombre
            TxtProducto.Text = CveProducto
        Else
            PROClave = ""
            CveProducto = ""

            MessageBox.Show("¡La Clave de producto no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub FrmPromocion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoPromocion Is Nothing Then

            ModPOS.ActualizaGrid(True, ModPOS.MtoPromocion.GridPromociones, "sp_muestra_promociones", "@COMClave", ModPOS.CompanyActual)
            ModPOS.MtoPromocion.GridPromociones.RootTable.Columns("ID").Visible = False

        End If

        ModPOS.Promocion.Dispose()
        ModPOS.Promocion = Nothing
    End Sub

    Public Sub addProductoPromocion(ByVal ID As String, ByVal Clave As String, ByVal Nombre As String, ByVal grid As Integer)
        Dim foundRows() As System.Data.DataRow
        If grid = 1 Then
            foundRows = dtProducto.Select("PROClave Like '" & ID & "'")

            If foundRows.Length = 0 Then
                Dim row1 As DataRow
                row1 = dtProducto.NewRow()
                'declara el nombre de la fila
                row1.Item("Marca") = False
                row1.Item("PROClave") = ID
                row1.Item("Clave") = Clave
                row1.Item("Nombre") = Nombre
                row1.Item("Status") = 0
                dtProducto.Rows.Add(row1)

            Else
                foundRows(0)("Status") = 0
            End If
        Else
            foundRows = dtPromocionCompra.Select("PROClave Like '" & ID & "'")

            If foundRows.Length = 0 Then
                Dim row1 As DataRow
                row1 = dtPromocionCompra.NewRow()
                'declara el nombre de la fila
                row1.Item("PROClave") = ID
                row1.Item("Clave") = Clave
                row1.Item("Nombre") = Nombre
                dtPromocionCompra.Rows.Add(row1)
            End If
        End If
    End Sub



    Public Sub addClienteDetalle(ByVal ID As String, ByVal Clave As String, ByVal RazonSocial As String, ByVal RFC As String)
        Dim foundRows() As System.Data.DataRow
        foundRows = dtCliente.Select("CTEClave = '" & ID & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtCliente.NewRow()
            'declara el nombre de la fila
            row1.Item("ID") = ModPOS.obtenerLlave
            row1.Item("CTEClave") = ID
            row1.Item("Clave") = Clave
            row1.Item("Razón Social") = RazonSocial
            row1.Item("RFC") = RFC
            row1.Item("Status") = 0

            dtCliente.Rows.Add(row1)

        Else
            foundRows(0)("Status") = 0
        End If

    End Sub

    Private Sub FrmPromocion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Me.TxtCompany.Text = ModPOS.CompanyName

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6
        alerta(6) = Me.PictureBox7
        alerta(7) = Me.PictureBox8
        alerta(8) = Me.PictureBox9
        alerta(9) = Me.PictureBox10


        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "TallaColor", "@COMClave", ModPOS.CompanyActual)
        If dt.Rows.Count > 0 Then
            TallaColor = IIf(dt.Rows(0)("Valor").GetType.Name = "DBNull", 0, dt.Rows(0)("Valor"))
        End If
        dt.Dispose()

        With Me.CmbTipoPromocion
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Promocion"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With Me.CmbTipoAplicacion
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Promocion"
            .NombreParametro2 = "campo"
            .Parametro2 = "Aplicacion"
            .llenar()
        End With

        With Me.CmbTipoCalculo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Promocion"
            .NombreParametro2 = "campo"
            .Parametro2 = "Calculo"
            .llenar()
        End With


        If Padre = "Nuevo" Then


            PRMClave = ModPOS.obtenerLlave

            CmbFechaInicio.Value = Today
            CmbFechaFin.Value = Today

            dtProducto = ModPOS.CrearTabla("PromocionProducto", _
                                                     "Marca", "System.Boolean", _
                                                    "PROClave", "System.String", _
                                                    "Clave", "System.String", _
                                                    "Nombre", "System.String", _
                                                    "Status", "System.Int32")

            dtCliente = ModPOS.CrearTabla("PromocionCliente", _
                                        "ID", "System.String", _
                                        "CTEClave", "System.String", _
                                        "Clave", "System.String", _
                                        "Razón Social", "System.String", _
                                        "RFC", "System.String", _
                                        "Status", "System.Int32")


            dtSucursal = ModPOS.CrearTabla("PromocionSucursal", _
                                     "ID", "System.String", _
                                     "SUCClave", "System.String", _
                                     "Clave", "System.String", _
                                     "Nombre", "System.String", _
                                     "Status", "System.Int32")

            dtDetalle = ModPOS.CrearTabla("PromocionDetalle", _
                                        "Cantidad", "System.Double", _
                                        "CantidadFinal", "System.Double", _
                                        "Promocion", "System.Double")



            dtRegalo = ModPOS.CrearTabla("PromocionRegalo", "ID", "System.String", _
                                        "PROClave", "System.String", _
                                        "Clave", "System.String", _
                                        "Descripcion", "System.String", _
                                        "Cantidad", "System.Double", _
                                        "Descuento", "System.Double")



            Dim row1 As DataRow
            row1 = dtDetalle.NewRow()
            'declara el nombre de la fila
            row1.Item("Cantidad") = 1
            row1.Item("CantidadFinal") = 1
            row1.Item("Promocion") = 0.0
            'agrega la fila completo a la tabla
            dtDetalle.Rows.Add(row1)

            cmbFechaFinCom.Value = Today
            cmbFechaFinCom.Value = Today

            dtPromocionCompra = ModPOS.CrearTabla("PromocionCompra", _
                                                    "PROClave", "System.String", _
                                                    "Clave", "System.String", _
                                                    "Nombre", "System.String")


        Else

            dtDetalle = ModPOS.Recupera_Tabla("sp_detalle_promocion", "@PRMClave", PRMClave)

            If dtDetalle.Rows.Count = 0 Then
                Dim row1 As DataRow
                row1 = dtDetalle.NewRow()
                'declara el nombre de la fila
                row1.Item("Cantidad") = 1
                row1.Item("CantidadFinal") = 1
                row1.Item("Promocion") = 0.0
                'agrega la fila completo a la tabla
                dtDetalle.Rows.Add(row1)
            End If

            dtCliente = ModPOS.Recupera_Tabla("sp_muestra_promocioncte", "@Promocion", PRMClave)

            dtProducto = Recupera_Tabla("sp_producto_promocion", "@PRMClave", PRMClave)

            dtSucursal = Recupera_Tabla("st_muestra_promocionsuc", "@Promocion", PRMClave)

            dtPromocionCompra = Recupera_Tabla("st_muestra_promocionCompra", "@PRMClave", PRMClave)

            If Tipo = 3 Then
                dtRegalo = ModPOS.Recupera_Tabla("sp_regalo_promocion", "@PRMClave", PRMClave)
            Else
                dtRegalo = ModPOS.CrearTabla("PromocionRegalo", "ID", "System.String", _
                            "PROClave", "System.String", _
                            "Clave", "System.String", _
                            "Descripcion", "System.String", _
                            "Cantidad", "System.Double", _
                            "Descuento", "System.Double")
            End If


            Me.TxtPromocionDesc.Text = Descripcion
            Me.TxtPromocionClave.Text = Clave
            TxtPromocionClave.Enabled = False
            Me.CmbFechaInicio.Value = FechaInicio
            Me.CmbFechaFin.Value = FechaFin
            Me.CmbTipoAplicacion.SelectedValue = Aplicacion
            Me.CmbTipoCalculo.SelectedValue = CalculoBase
            txtJerarquia.Text = Jerarquia
            ChkCascada.Estado = Math.Abs(Cascada)
            ChkEstado.Estado = Math.Abs(Estado)
            ChkIguales.Estado = Math.Abs(Iguales)
            ckLimitaPago.Estado = Math.Abs(LimitaPago)
            ChkCompraHist.Estado = Math.Abs(CompraHist)
            cmbFechaInComp.Value = FechaInicioHist
            cmbFechaFinCom.Value = FechaFinHist
            chkTodosClientes.Estado = Math.Abs(TodosClientes)
            ChkTodasSucursales.Estado = Math.Abs(TodasSucursales)

            ChkTodosProductos.Estado = Math.Abs(TodosProductos)
            ChkVtaPaquete.Estado = Math.Abs(VtaPaquete)

            CmbTipoPromocion.Enabled = False
            TxtPromocionClave.ReadOnly = True
            CmbFechaInicio.Enabled = False
            CmbTipoAplicacion.Enabled = False
            CmbTipoCalculo.Enabled = False
            cmbFechaInComp.Enabled = False

            Me.CmbTipoPromocion.SelectedValue = Tipo



        End If

        cargado = True




        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("Cantidad").FormatString = "0.00"
        GridDetalle.RootTable.Columns("CantidadFinal").FormatString = "0.00"



        GridRegalo.DataSource = dtRegalo
        GridRegalo.RetrieveStructure(True)
        GridRegalo.GroupByBoxVisible = False
        GridRegalo.RootTable.Columns("ID").Visible = False
        GridRegalo.RootTable.Columns("PROClave").Visible = False
        GridRegalo.CurrentTable.Columns("Clave").Selectable = False
        GridRegalo.CurrentTable.Columns("Descripcion").Selectable = False
        GridRegalo.RootTable.Columns("Cantidad").FormatString = "0.00"
        GridRegalo.RootTable.Columns("Descuento").FormatString = "0.000"


        GridProductos.DataSource = dtProducto
        GridProductos.RetrieveStructure(True)
        GridProductos.GroupByBoxVisible = False
        GridProductos.RootTable.Columns("PROClave").Visible = False
        GridProductos.RootTable.Columns("Status").Visible = False
      
        Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
        fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridProductos.RootTable.Columns("Status"), Janus.Windows.GridEX.ConditionOperator.Equal, -1)
        fc1.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc1.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridProductos.RootTable.FormatConditions.Add(fc1)

        GridClientes.DataSource = dtCliente
        GridClientes.RetrieveStructure(True)
        GridClientes.RootTable.Columns("ID").Visible = False
        GridClientes.RootTable.Columns("CTEClave").Visible = False
        GridClientes.RootTable.Columns("Status").Visible = False


        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridClientes.RootTable.Columns("Status"), Janus.Windows.GridEX.ConditionOperator.Equal, -1)
        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridClientes.RootTable.FormatConditions.Add(fc)


        gridSucursales.DataSource = dtSucursal
        gridSucursales.RetrieveStructure(True)
        gridSucursales.RootTable.Columns("ID").Visible = False
        gridSucursales.RootTable.Columns("SUCClave").Visible = False
        gridSucursales.RootTable.Columns("Status").Visible = False


        Dim fc2 As Janus.Windows.GridEX.GridEXFormatCondition
        fc2 = New Janus.Windows.GridEX.GridEXFormatCondition(gridSucursales.RootTable.Columns("Status"), Janus.Windows.GridEX.ConditionOperator.Equal, -1)
        fc2.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc2.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        gridSucursales.RootTable.FormatConditions.Add(fc2)

        GridProdCompra.DataSource = dtPromocionCompra
        GridProdCompra.RetrieveStructure(True)
        GridProdCompra.RootTable.Columns("PROClave").Visible = False

        actualizaGridTipo()
        actualizaGridAplicacion()
        actualizaGridCalculo()


        If chkTodosClientes.Checked = True Then
            BtnAddCte.Enabled = False
            BtnEliminaCte.Enabled = False
            GridClientes.Enabled = False
            btnImpCte.Enabled = False

        Else
            BtnAddCte.Enabled = True
            BtnEliminaCte.Enabled = True
            GridClientes.Enabled = True
            btnImpCte.Enabled = True
        End If

        If ChkTodasSucursales.Checked = True Then
            btnAddSuc.Enabled = False
            btnDelSuc.Enabled = False
            gridSucursales.Enabled = False
        Else
            btnAddSuc.Enabled = True
            btnDelSuc.Enabled = True
            gridSucursales.Enabled = True
        End If


    End Sub

    Private Sub actualizaGridTipo()
        If cargado = True AndAlso Not CmbTipoPromocion.SelectedValue Is Nothing Then
            Select Case CInt(CmbTipoPromocion.SelectedValue)
                Case 1 ' Descuento
                    GridDetalle.CurrentTable.Columns("Promocion").Visible = True
                    GridDetalle.CurrentTable.Columns("Promocion").Caption = "% Descuento"

                    GridRegalo.Enabled = False
                    TxtProducto.Enabled = False
                    BtnBuscaProducto2.Enabled = False

                    CmbTipoAplicacion.Enabled = True
                    CmbTipoCalculo.Enabled = True

                Case 2 ' Bonificacion
                    GridDetalle.CurrentTable.Columns("Promocion").Visible = True
                    GridDetalle.CurrentTable.Columns("Promocion").Caption = "Bonificar"

                    GridRegalo.Enabled = False
                    TxtProducto.Enabled = False
                    BtnBuscaProducto2.Enabled = False

                    CmbTipoAplicacion.Enabled = True
                    CmbTipoCalculo.Enabled = True

                Case 3 ' Producto
                    GridDetalle.CurrentTable.Columns("Promocion").Visible = False
                    GridRegalo.Enabled = True
                    TxtProducto.Enabled = True
                    BtnBuscaProducto2.Enabled = True

                    CmbTipoAplicacion.Enabled = True
                    CmbTipoCalculo.Enabled = True

                Case 4 'Puntos
                    GridDetalle.CurrentTable.Columns("Promocion").Visible = True
                    GridDetalle.CurrentTable.Columns("Promocion").Caption = "Puntos"

                    GridRegalo.Enabled = False
                    TxtProducto.Enabled = False
                    BtnBuscaProducto2.Enabled = False

                    CmbTipoAplicacion.Enabled = True
                    CmbTipoCalculo.Enabled = True

                Case 5 ' Menor Precio
                    GridDetalle.CurrentTable.Columns("Promocion").Visible = True
                    GridDetalle.CurrentTable.Columns("Promocion").Caption = "Regalo"

                    GridRegalo.Enabled = False
                    TxtProducto.Enabled = False
                    BtnBuscaProducto2.Enabled = False

                    CmbTipoAplicacion.SelectedValue = 1
                    CmbTipoCalculo.SelectedValue = 1
                    CmbTipoAplicacion.Enabled = False
                    CmbTipoCalculo.Enabled = False

                Case 6 ' Precio
                    GridDetalle.CurrentTable.Columns("Promocion").Visible = True
                    GridDetalle.CurrentTable.Columns("Promocion").Caption = "Precio"

                    GridRegalo.Enabled = False
                    TxtProducto.Enabled = False
                    BtnBuscaProducto2.Enabled = False

                    CmbTipoAplicacion.SelectedValue = 1
                    CmbTipoCalculo.SelectedValue = 1
                    CmbTipoAplicacion.Enabled = False
                    CmbTipoCalculo.Enabled = False


                Case 7 ' Desc Menor Precio
                    GridDetalle.CurrentTable.Columns("Promocion").Visible = True
                    GridDetalle.CurrentTable.Columns("Promocion").Caption = "% Descuento"

                    GridRegalo.Enabled = False
                    TxtProducto.Enabled = False
                    BtnBuscaProducto2.Enabled = False

                    CmbTipoAplicacion.SelectedValue = 1
                    CmbTipoCalculo.SelectedValue = 1
                    CmbTipoAplicacion.Enabled = False
                    CmbTipoCalculo.Enabled = False
            End Select
        End If
    End Sub

    Private Sub actualizaGridAplicacion()
        If cargado = True AndAlso Not CmbTipoAplicacion.SelectedValue Is Nothing Then
            Select Case CInt(CmbTipoAplicacion.SelectedValue)
                Case 1 ' Cantidad
                    GridDetalle.CurrentTable.Columns("Cantidad").Caption = "Cantidad"
                    GridDetalle.CurrentTable.Columns("CantidadFinal").Caption = "Cantidad Final"
                Case 2 ' Importe
                    GridDetalle.CurrentTable.Columns("Cantidad").Caption = "Importe "
                    GridDetalle.CurrentTable.Columns("CantidadFinal").Caption = "Importe Final"
            End Select
        End If
    End Sub

    Private Sub actualizaGridCalculo()
        If cargado = True AndAlso Not CmbTipoCalculo.SelectedValue Is Nothing Then
            Select Case CInt(CmbTipoCalculo.SelectedValue)
                Case 1 ' Cantidad
                    GridDetalle.CurrentTable.Columns("CantidadFinal").Visible = False
                Case 2 ' Rango
                    GridDetalle.CurrentTable.Columns("CantidadFinal").Visible = True
            End Select
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub CmbTipoPromocion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTipoPromocion.SelectedIndexChanged
        actualizaGridTipo()
    End Sub

    Private Sub CmbTipoAplicacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTipoAplicacion.SelectedIndexChanged
        actualizaGridAplicacion()
    End Sub

    Private Sub CmbTipoCalculo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTipoCalculo.SelectedIndexChanged
        actualizaGridCalculo()
    End Sub


    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            If chkTodosClientes.Checked = False AndAlso dtCliente.Rows.Count = 0 Then
                MessageBox.Show("¡Debe agregar por lo menos un cliente a esta promoción!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If ChkTodasSucursales.Checked = False AndAlso dtSucursal.Rows.Count = 0 Then
                MessageBox.Show("¡Debe agregar por lo menos una sucursal a esta promoción!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If ChkCompraHist.Checked AndAlso dtPromocionCompra.Rows.Count = 0 Then
                MessageBox.Show("¡Debe de agregar por lo menos un producto para verificar sus compras historicas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If GridDetalle.RowCount > 0 Then
                If Padre = "Nuevo" Then

                    FechaInicio = CmbFechaInicio.Value
                    FechaFin = CmbFechaFin.Value.AddHours(23.9999)
                    Clave = TxtPromocionClave.Text.Trim.ToUpper
                    Descripcion = TxtPromocionDesc.Text.Trim.ToUpper
                    Tipo = CmbTipoPromocion.SelectedValue
                    Aplicacion = CmbTipoAplicacion.SelectedValue
                    CalculoBase = CmbTipoCalculo.SelectedValue
                    Jerarquia = txtJerarquia.Text
                    Cascada = ChkCascada.GetEstado
                    LimitaPago = ckLimitaPago.GetEstado
                    Iguales = ChkIguales.GetEstado
                    TodosClientes = chkTodosClientes.GetEstado
                    TodasSucursales = ChkTodasSucursales.GetEstado
                    CompraHist = ChkCompraHist.GetEstado
                    FechaInicioHist = cmbFechaInComp.Value
                    FechaFinHist = cmbFechaFinCom.Value.AddHours(23.9999)

                    TodosProductos = ChkTodosProductos.GetEstado
                    VtaPaquete = ChkVtaPaquete.GetEstado


                    ModPOS.Ejecuta("sp_crea_promocion", _
                                  "@PRMClave", PRMClave, _
                                  "@Clave", Clave, _
                                  "@Descripcion", Descripcion, _
                                  "@Tipo", Tipo, _
                                  "@Aplicacion", Aplicacion, _
                                  "@CalculoBase", CalculoBase, _
                                  "@FechaInicio", FechaInicio, _
                                  "@FechaFin", FechaFin, _
                                  "@Jerarquia", Jerarquia, _
                                  "@LimitaPago", LimitaPago, _
                                  "@Cascada", Cascada, _
                                  "@Iguales", Iguales, _
                                  "@TodosClientes", TodosClientes, _
                                  "@TodasSucursales", TodasSucursales, _
                                  "@TodosProductos", TodosProductos, _
                                  "@vtaPaquete", VtaPaquete, _
                                  "@Usuario", ModPOS.UsuarioActual, _
                                  "@COMClave", ModPOS.CompanyActual, _
                                  "@compraHist", CompraHist, _
                                  "@InicioCompra", FechaInicioHist, _
                                  "@FinCompra", FechaFinHist)

                    Dim fila As Integer

                    For fila = 0 To dtDetalle.Rows.Count - 1
                        ModPOS.Ejecuta("sp_inserta_promociondetalle", _
                                    "@PRMClave", PRMClave, _
                                    "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
                                    "@CantidadFinal", dtDetalle.Rows(fila)("CantidadFinal"), _
                                    "@Promocion", dtDetalle.Rows(fila)("Promocion"), _
                                    "@Usuario", ModPOS.UsuarioActual)
                    Next

                    If Tipo = 3 Then 'Producto regalado
                        For fila = 0 To dtRegalo.Rows.Count - 1
                            ModPOS.Ejecuta("sp_inserta_promocionregalo", _
                                        "@PRMClave", PRMClave, _
                                        "@PROClave", dtRegalo.Rows(fila)("PROClave"), _
                                        "@Cantidad", dtRegalo.Rows(fila)("Cantidad"), _
                                        "@Descuento", dtRegalo.Rows(fila)("Descuento"), _
                                        "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    Cursor.Current = Cursors.WaitCursor

                    Dim foundRows() As DataRow
                    foundRows = dtCliente.Select("Status=0")
                    If foundRows.GetLength(0) > 0 Then

                        For fila = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_promocioncte", _
                            "@ID", foundRows(fila)("ID"), _
                            "@PRMClave", PRMClave, _
                            "@CTEClave", foundRows(fila)("CTEClave"), _
                            "@Status", foundRows(fila)("Status"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


                    foundRows = dtSucursal.Select("Status=0")
                    If foundRows.GetLength(0) > 0 Then

                        For fila = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("st_inserta_promocionsuc", _
                            "@ID", foundRows(fila)("ID"), _
                            "@PRMClave", PRMClave, _
                            "@SUCClave", foundRows(fila)("SUCClave"), _
                            "@Status", foundRows(fila)("Status"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If



                    foundRows = dtProducto.Select("Status=0")
                    If foundRows.GetLength(0) > 0 Then

                        For fila = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_producto_pro", _
                            "@PRMClave", PRMClave, _
                            "@PROClave", foundRows(fila)("PROClave"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    If ChkCompraHist.Checked Then
                        foundRows = dtPromocionCompra.Select("")
                        For fila = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("st_inserta_PromocionCompra", _
                                           "@PRMClave", PRMClave, _
                                           "@PROClave", foundRows(fila)("PROClave"), _
                                           "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    Cursor.Current = Cursors.Default

                Else

                    If Not (FechaFin.Date = CmbFechaFin.Value.Date AndAlso _
                            Descripcion = TxtPromocionDesc.Text.Trim.ToUpper AndAlso _
                            Jerarquia = txtJerarquia.Text AndAlso _
                            Estado = ChkEstado.GetEstado AndAlso _
                              Math.Abs(TodosClientes) = chkTodosClientes.GetEstado AndAlso _
                        Math.Abs(TodasSucursales) = ChkTodasSucursales.GetEstado AndAlso _
                         Math.Abs(TodosProductos) = ChkTodosProductos.GetEstado AndAlso _
                          Math.Abs(VtaPaquete) = ChkVtaPaquete.GetEstado AndAlso _
                            Math.Abs(Iguales) = ChkIguales.GetEstado AndAlso _
                             Math.Abs(LimitaPago) = ckLimitaPago.GetEstado AndAlso _
                            Math.Abs(Cascada) = ChkCascada.GetEstado AndAlso _
                            Math.Abs(CompraHist) = ChkCompraHist.GetEstado AndAlso _
                            FechaFinHist.Date = cmbFechaFinCom.Value.Date) Then

                        FechaFin = CmbFechaFin.Value.Date.AddHours(23.9999)
                        Descripcion = TxtPromocionDesc.Text.Trim.ToUpper
                        Jerarquia = txtJerarquia.Text
                        Cascada = ChkCascada.GetEstado
                        LimitaPago = ckLimitaPago.GetEstado
                        Estado = ChkEstado.GetEstado
                        Iguales = ChkIguales.GetEstado
                        TodasSucursales = ChkTodasSucursales.GetEstado
                        TodosClientes = chkTodosClientes.GetEstado
                        TodosProductos = ChkTodosProductos.GetEstado
                        VtaPaquete = ChkVtaPaquete.GetEstado
                        CompraHist = ChkCompraHist.GetEstado
                        FechaFinHist = cmbFechaFinCom.Value.Date.AddHours(23.9999)

                        ModPOS.Ejecuta("sp_actualiza_promocion", _
                               "@PRMClave", PRMClave, _
                               "@Descripcion", Descripcion, _
                               "@FechaFin", FechaFin, _
                               "@Jerarquia", Jerarquia, _
                                "@LimitaPago", LimitaPago, _
                               "@Cascada", Cascada, _
                               "@Estado", Estado, _
                               "@Iguales", Iguales, _
                                "@TodosClientes", TodosClientes, _
                                  "@TodasSucursales", TodasSucursales, _
                                   "@TodosProductos", TodosProductos, _
                                  "@vtaPaquete", VtaPaquete, _
                               "@Usuario", ModPOS.UsuarioActual, _
                                  "@COMClave", ModPOS.CompanyActual, _
                                  "@CompraHist", CompraHist, _
                                  "@FinCompra", FechaFinHist)

                    End If

                    Dim fila As Integer

                    Dim foundRows() As DataRow

                    Cursor.Current = Cursors.WaitCursor


                    foundRows = dtCliente.Select("Status<>1")
                    If foundRows.GetLength(0) > 0 Then

                        For fila = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_promocioncte", _
                            "@ID", foundRows(fila)("ID"), _
                            "@PRMClave", PRMClave, _
                            "@CTEClave", foundRows(fila)("CTEClave"), _
                            "@Status", foundRows(fila)("Status"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    foundRows = dtSucursal.Select("Status<>1")
                    If foundRows.GetLength(0) > 0 Then

                        For fila = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("st_inserta_promocionsuc", _
                            "@ID", foundRows(fila)("ID"), _
                            "@PRMClave", PRMClave, _
                            "@SUCClave", foundRows(fila)("SUCClave"), _
                            "@Status", foundRows(fila)("Status"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    foundRows = dtProducto.Select("Status=0")
                    If foundRows.GetLength(0) > 0 Then
                        For fila = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_producto_pro", _
                            "@PRMClave", PRMClave, _
                            "@PROClave", foundRows(fila)("PROClave"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


                    foundRows = dtProducto.Select("Status=-1")
                    If foundRows.GetLength(0) > 0 Then
                        For fila = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_producto_pro", "@PROClave", foundRows(fila)("PROClave"), "@PRMCLAVE", PRMClave)
                        Next
                    End If


                    Cursor.Current = Cursors.Default


                    If DetalleEdited = True Then
                        ModPOS.Ejecuta("sp_elimina_promociondet", _
                                                 "@PRMClave", PRMClave)


                        For fila = 0 To dtDetalle.Rows.Count - 1
                            ModPOS.Ejecuta("sp_inserta_promociondetalle", _
                                        "@PRMClave", PRMClave, _
                                        "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
                                        "@CantidadFinal", dtDetalle.Rows(fila)("CantidadFinal"), _
                                        "@Promocion", dtDetalle.Rows(fila)("Promocion"), _
                                        "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    If RegaloEdited = True Then
                        ModPOS.Ejecuta("sp_elimina_promocionreg", _
                                        "@PRMClave", PRMClave)

                        If Tipo = 3 Then 'Producto regalado
                            For fila = 0 To dtRegalo.Rows.Count - 1
                                ModPOS.Ejecuta("sp_inserta_promocionregalo", _
                                            "@PRMClave", PRMClave, _
                                            "@PROClave", dtRegalo.Rows(fila)("PROClave"), _
                                            "@Cantidad", dtRegalo.Rows(fila)("Cantidad"), _
                                              "@Descuento", dtRegalo.Rows(fila)("Descuento"), _
                                            "@Usuario", ModPOS.UsuarioActual)
                            Next
                        End If

                    End If


                    ModPOS.Ejecuta("st_elimina_PromocionCompra", _
                                   "@PRMClave", PRMClave)

                    If ChkCompraHist.Checked Then
                        For fila = 0 To dtPromocionCompra.Rows.Count - 1
                            ModPOS.Ejecuta("st_inserta_PromocionCompra", _
                                           "@PRMClave", PRMClave, _
                                           "@PROClave", dtPromocionCompra.Rows(fila)("PROClave"), _
                                           "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If
                End If
            End If

            Me.Close()

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub TxtProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtProducto.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not TxtProducto.Text = vbNullString Then
                recuperaProducto(TxtProducto.Text.Trim.ToUpper.Replace("'", "''"))
            End If
        ElseIf e.KeyCode = Keys.Right Then
            'Busca y recupera los datos del producto
            Dim a As New MeSearch
            If TallaColor = 1 Then
                a.ProcedimientoAlmacenado = "st_search_prod_tc"
                a.CampoCmb = "FiltroTC"
            Else
                a.ProcedimientoAlmacenado = "sp_search_prod"
                a.CampoCmb = "Filtro"
            End If
            a.bReplace = True
            a.TablaCmb = "Producto"
            a.NumColDes = 2
            a.CompaniaRequerido = True
            a.BusquedaInicial = True
            a.Busqueda = TxtProducto.Text.Trim.ToUpper.Replace("'", "''")
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                recuperaProducto(a.valor)
            End If
            a.Dispose()
        End If
    End Sub

    Private Sub GridDetalle_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        DetalleEdited = True
        Select Case GridDetalle.CurrentColumn.DataMember
            Case Is = "Cantidad"
                If Not (IsNumeric(GridDetalle.GetValue("Cantidad")) AndAlso GridDetalle.GetValue("Cantidad") > 0) Then
                    Beep()
                    MessageBox.Show("¡La cantidad debe ser mayor a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridDetalle.SetValue("Cantidad", 1)
                ElseIf IsNumeric(GridDetalle.GetValue("Cantidad")) AndAlso GridDetalle.GetValue("Cantidad") > 0 Then
                    If Not CmbTipoCalculo.SelectedValue Is Nothing AndAlso CInt(CmbTipoCalculo.SelectedValue) = 1 Then
                        GridDetalle.SetValue("CantidadFinal", GridDetalle.GetValue("Cantidad"))
                    End If
                End If
            Case Is = "CantidadFinal"
                If Not (IsNumeric(GridDetalle.GetValue("CantidadFinal")) AndAlso GridDetalle.GetValue("CantidadFinal") >= GridDetalle.GetValue("Cantidad")) Then
                    Beep()
                    MessageBox.Show("¡La cantidad final debe ser mayor o igual a la cantidad inicial!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridDetalle.SetValue("CantidadFinal", GridDetalle.GetValue("Cantidad"))
                End If
            Case Is = "Promocion"
                If Not (IsNumeric(GridDetalle.GetValue("Promocion")) AndAlso GridDetalle.GetValue("Promocion") >= 0) Then
                    Beep()
                    MessageBox.Show("¡La cantidad debe ser mayor a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridDetalle.SetValue("Promocion", 0)
                Else

                    Select Case CInt(CmbTipoPromocion.SelectedValue)
                        Case 1 ' Descuento
                            If GridDetalle.GetValue("Promocion") > 100 Then
                                Beep()
                                MessageBox.Show("¡La cantidad debe ser menor o igual a 100!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                GridDetalle.SetValue("Promocion", 0)
                            End If

                        Case 5 ' Menor Precio
                            If GridDetalle.GetValue("Promocion") >= GridDetalle.GetValue("Cantidad") Then
                                Beep()
                                MessageBox.Show("¡La cantidad a Regalar debe ser menor a la Cantidad de Venta!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                GridDetalle.SetValue("Promocion", 0)
                            End If


                        Case 6 '  Precio
                            If GridDetalle.GetValue("Promocion") <= 0 Then
                                Beep()
                                MessageBox.Show("¡El precio debe ser mayor a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                GridDetalle.SetValue("Promocion", 1)
                            End If

                        Case 7 ' Descuento
                            If GridDetalle.GetValue("Promocion") > 100 Then
                                Beep()
                                MessageBox.Show("¡La cantidad debe ser menor o igual a 100!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                GridDetalle.SetValue("Promocion", 0)
                            End If
                    End Select




                End If
        End Select
    End Sub

    Private Sub GridDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridDetalle.KeyDown
        If e.KeyCode = Keys.Delete AndAlso GridDetalle.RowCount > 0 Then
            Dim foundRows() As System.Data.DataRow
            foundRows = dtDetalle.Select("PROClave Like '" & GridDetalle.GetValue("PROClave") & "'")
            dtDetalle.Rows.Remove(foundRows(0))
            DetalleEdited = True
        End If
    End Sub

    Private Sub GridRegalo_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridRegalo.CellEdited
        RegaloEdited = True
        Select Case GridRegalo.CurrentColumn.DataMember
            Case Is = "Cantidad"
                If Not (IsNumeric(GridRegalo.GetValue("Cantidad")) AndAlso GridRegalo.GetValue("Cantidad") > 0) Then
                    Beep()
                    MessageBox.Show("¡La cantidad debe ser mayor a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridRegalo.SetValue("Cantidad", 1)
                End If
            Case Is = "Descuento"
                If Not (IsNumeric(GridRegalo.GetValue("Descuento")) AndAlso GridRegalo.GetValue("Descuento") > 0 AndAlso GridRegalo.GetValue("Descuento") <= 100) Then
                    Beep()
                    MessageBox.Show("¡El porcentaje descuento debe ser mayor a cero y menor o igual a 100!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridRegalo.SetValue("Descuento", 100)
                End If
        End Select
    End Sub

    Private Sub GridRegalo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridRegalo.KeyDown
        If e.KeyCode = Keys.Delete AndAlso GridRegalo.RowCount > 0 Then
            Dim foundRows() As System.Data.DataRow
            foundRows = dtRegalo.Select("PROClave Like '" & GridRegalo.GetValue("PROClave") & "'")
            dtRegalo.Rows.Remove(foundRows(0))
            RegaloEdited = True
        End If
    End Sub


    Private Sub BtnAddCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddCte.Click
        If ModPOS.AddCteProm Is Nothing Then
            ModPOS.AddCteProm = New FrmAddCteProm
            With ModPOS.AddCteProm
                .Text = "Agregar Cliente a la Promoción"
                .StartPosition = FormStartPosition.CenterScreen
                .PRMClave = PRMClave

            End With
        End If
        ModPOS.AddCteProm.StartPosition = FormStartPosition.CenterScreen
        ModPOS.AddCteProm.Show()
        ModPOS.AddCteProm.BringToFront()
    End Sub

    Private Sub BtnEliminaCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminaCte.Click
        If sClienteSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Cliente :" & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtCliente.Select("ID = '" & sClienteSelected & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Status") = -1
                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub GridClientes_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridClientes.SelectionChanged
        If cargado = True AndAlso Not Me.GridClientes.GetValue(0) Is Nothing Then
            Me.BtnEliminaCte.Enabled = True
            Me.sClienteSelected = GridClientes.GetValue("ID")
            Me.sNombre = GridClientes.GetValue(1)
        Else
            Me.sClienteSelected = ""
            Me.sNombre = ""
            Me.BtnEliminaCte.Enabled = False
        End If
    End Sub

    Private Sub BtnAgregaPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregaPro.Click
        If ModPOS.AddPro Is Nothing Then
            ModPOS.AddPro = New FrmAddPro
            With ModPOS.AddPro
                .Text = "Agregar Productos a la Promoción"
                .StartPosition = FormStartPosition.CenterScreen
                .PRMClave = PRMClave
                .grid = 1
            End With
        End If
        ModPOS.AddPro.StartPosition = FormStartPosition.CenterScreen
        ModPOS.AddPro.Show()
        ModPOS.AddPro.BringToFront()
    End Sub

    Private Sub BtnEliminaPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminaPro.Click
        Dim foundRows() As System.Data.DataRow
        foundRows = dtProducto.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Producto :" & sNombreProducto, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim i As Integer
                    For i = 0 To foundRows.GetUpperBound(0)
                        foundRows(0)("Status") = -1
                    Next
            End Select
        Else
            MessageBox.Show("Debe marcar los productos que desea remover del listado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    Private Sub GridProductos_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridProductos.CurrentCellChanged
        If Not GridProductos.CurrentColumn Is Nothing Then
            If GridProductos.CurrentColumn.Caption = "Marca" Then
                GridProductos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridProductos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub



    Private Sub GridProductos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridProductos.SelectionChanged
        If Not Me.GridProductos.GetValue(0) Is Nothing Then
            Me.BtnEliminaPro.Enabled = True
            Me.sProductoSelected = GridProductos.GetValue("PROClave")
            Me.sNombreProducto = GridProductos.GetValue("Nombre")
        Else
            Me.sProductoSelected = ""
            Me.sNombreProducto = ""
            Me.BtnEliminaPro.Enabled = False
        End If
    End Sub

    Private Sub BtnBuscaProducto2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaProducto2.Click
        'Busca y recupera los datos del producto
        Dim a As New MeSearch
        If TallaColor = 1 Then
            a.ProcedimientoAlmacenado = "st_search_prod_tc"
            a.CampoCmb = "FiltroTC"
        Else
            a.ProcedimientoAlmacenado = "sp_search_prod"
            a.CampoCmb = "Filtro"
        End If
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.NumColDes = 2
        a.CompaniaRequerido = True
        a.BusquedaInicial = True
        a.Busqueda = TxtProducto.Text.Trim.ToUpper.Replace("'", "''")
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            recuperaProducto(a.valor)
        End If
        a.Dispose()
    End Sub

    Private Sub chkTodosClientes_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosClientes.CheckedChanged
        If chkTodosClientes.Checked = True Then
            BtnAddCte.Enabled = False
            BtnEliminaCte.Enabled = False
            GridClientes.Enabled = False
            btnImpCte.Enabled = False
        Else
            btnImpCte.Enabled = True
            BtnAddCte.Enabled = True
            BtnEliminaCte.Enabled = True
            GridClientes.Enabled = True
        End If
    End Sub

    Private Sub ChkTodasSucursales_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTodasSucursales.CheckedChanged
        If ChkTodasSucursales.Checked = True Then
            btnAddSuc.Enabled = False
            btnDelSuc.Enabled = False
            gridSucursales.Enabled = False
        Else
            btnAddSuc.Enabled = True
            btnDelSuc.Enabled = True
            gridSucursales.Enabled = True
        End If
    End Sub

    Private Sub gridSucursales_SelectionChanged(sender As Object, e As EventArgs) Handles gridSucursales.SelectionChanged
        If cargado = True AndAlso Not Me.gridSucursales.GetValue(0) Is Nothing Then
            Me.btnDelSuc.Enabled = True
            Me.sSucursalSelected = gridSucursales.GetValue("ID")
            Me.sNombreSucursal = gridSucursales.GetValue("Nombre")
        Else
            Me.sSucursalSelected = ""
            Me.sNombreSucursal = ""
            Me.btnDelSuc.Enabled = False
        End If
    End Sub

    Private Sub btnDelSuc_Click(sender As Object, e As EventArgs) Handles btnDelSuc.Click
        If sSucursalSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la Sucursal :" & sNombreSucursal, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtSucursal.Select("ID = '" & sSucursalSelected & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Status") = -1
                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub btnAddSuc_Click(sender As Object, e As EventArgs) Handles btnAddSuc.Click
        Dim a As New MeSearchSimple
        ModPOS.ActualizaGrid(False, a.GridSearch, "sp_muestra_sucursales", "@COMClave", ModPOS.CompanyActual)
        a.GridSearch.RootTable.Columns("SUCClave").Visible = False
        a.numColValor = 0
        a.numColDescripcion = 1
        a.numColDescripcion2 = 3
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                Dim foundRows() As System.Data.DataRow
                foundRows = dtSucursal.Select("SUCClave = '" & a.valor & "'")

                If foundRows.Length = 0 Then
                    Dim row1 As DataRow
                    row1 = dtSucursal.NewRow()
                    'declara el nombre de la fila
                    row1.Item("ID") = ModPOS.obtenerLlave
                    row1.Item("SUCClave") = a.valor
                    row1.Item("Clave") = a.Descripcion
                    row1.Item("Nombre") = a.Descripcion2
                    row1.Item("Status") = 0
                    dtSucursal.Rows.Add(row1)

                Else
                    foundRows(0)("Status") = 0
                End If



            End If
        End If
        a.Dispose()
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        ImportarProductos()
    End Sub

    Private Sub btAddProdCom_Click(sender As Object, e As EventArgs) Handles btAddProdCom.Click
        If ModPOS.AddPro Is Nothing Then
            ModPOS.AddPro = New FrmAddPro
            With ModPOS.AddPro
                .Text = "Agregar Productos al historico de compras"
                .StartPosition = FormStartPosition.CenterScreen
                .PRMClave = PRMClave
                .grid = 2
            End With
        End If
        ModPOS.AddPro.StartPosition = FormStartPosition.CenterScreen
        ModPOS.AddPro.Show()
        ModPOS.AddPro.BringToFront()
    End Sub

    Private Sub GridProdCompra_SelectionChanged(sender As Object, e As EventArgs) Handles GridProdCompra.SelectionChanged
        If Not Me.GridProdCompra.GetValue(0) Is Nothing Then
            Me.BtnEliminaPro.Enabled = True
            Me.sProductoSelected = GridProdCompra.GetValue("PROClave")
            Me.sNombreProducto = GridProdCompra.GetValue("Nombre")
        Else
            Me.sProductoSelected = ""
            Me.sNombreProducto = ""
            Me.BtnEliminaPro.Enabled = False
        End If
    End Sub

    Private Sub btCanProdComp_Click(sender As Object, e As EventArgs) Handles btCanProdComp.Click
        If sProductoSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Producto :" & sNombreProducto, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtPromocionCompra.Select("PROClave Like '" & sProductoSelected & "'")

                    If foundRows.Length <> 0 Then
                        dtPromocionCompra.Rows.Remove(foundRows(0))

                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub btnImpCte_Click(sender As Object, e As EventArgs) Handles btnImpCte.Click
        ImportarClientes()
    End Sub

    Private Sub ChkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTodos.CheckedChanged
        If dtProducto.Rows.Count > 0 Then
            Dim i As Integer
            If ChkTodos.Checked Then
                For i = 0 To GridProductos.GetDataRows.Length - 1
                    GridProductos.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridProductos.GetDataRows.Length - 1
                    GridProductos.GetDataRows(i).DataRow("Marca") = False
                Next
            End If
            dtProducto.AcceptChanges()
            GridProductos.Refresh()

        End If
    End Sub
End Class
