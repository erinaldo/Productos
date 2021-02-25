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
    Friend WithEvents TxtGerarquia As Janus.Windows.GridEX.EditControls.NumericEditBox
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
    Friend WithEvents UiTabPage1 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregaPro As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminaPro As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents ChkIguales As Selling.ChkStatus
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPromocion))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.UiTabEstructura = New Janus.Windows.UI.Tab.UITab
        Me.TabGeneral = New Janus.Windows.UI.Tab.UITabPage
        Me.GrpProductoRegalo = New System.Windows.Forms.GroupBox
        Me.PictureBox10 = New System.Windows.Forms.PictureBox
        Me.BtnBuscaProducto2 = New Janus.Windows.EditControls.UIButton
        Me.TxtDescripcion2 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtProducto = New System.Windows.Forms.TextBox
        Me.GridRegalo = New Janus.Windows.GridEX.GridEX
        Me.GrpReglaPromocion = New System.Windows.Forms.GroupBox
        Me.PictureBox9 = New System.Windows.Forms.PictureBox
        Me.ChkIguales = New Selling.ChkStatus(Me.components)
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.GrpGeneral = New System.Windows.Forms.GroupBox
        Me.TxtCompany = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.ChkCascada = New Selling.ChkStatus(Me.components)
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.CmbTipoCalculo = New Selling.StoreCombo
        Me.LblTipoCalculo = New System.Windows.Forms.Label
        Me.CmbTipoAplicacion = New Selling.StoreCombo
        Me.CmbFechaFin = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TxtGerarquia = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.CmbTipoPromocion = New Selling.StoreCombo
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmbFechaInicio = New System.Windows.Forms.DateTimePicker
        Me.LblClavePromocion = New System.Windows.Forms.Label
        Me.LblTipoAplicacion = New System.Windows.Forms.Label
        Me.TxtPromocionDesc = New System.Windows.Forms.TextBox
        Me.LblPromocionDesc = New System.Windows.Forms.Label
        Me.TxtPromocionClave = New System.Windows.Forms.TextBox
        Me.LblTipoPromocion = New System.Windows.Forms.Label
        Me.UiTabPage1 = New Janus.Windows.UI.Tab.UITabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnAgregaPro = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminaPro = New Janus.Windows.EditControls.UIButton
        Me.GridProductos = New Janus.Windows.GridEX.GridEX
        Me.TabClientes = New Janus.Windows.UI.Tab.UITabPage
        Me.GrpClientes = New System.Windows.Forms.GroupBox
        Me.BtnAddCte = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminaCte = New Janus.Windows.EditControls.UIButton
        Me.GridClientes = New Janus.Windows.GridEX.GridEX
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
        Me.UiTabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabClientes.SuspendLayout()
        Me.GrpClientes.SuspendLayout()
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(597, 531)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(693, 531)
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
        Me.UiTabEstructura.Size = New System.Drawing.Size(782, 525)
        Me.UiTabEstructura.TabIndex = 10
        Me.UiTabEstructura.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.TabGeneral, Me.UiTabPage1, Me.TabClientes})
        Me.UiTabEstructura.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'TabGeneral
        '
        Me.TabGeneral.Controls.Add(Me.GrpProductoRegalo)
        Me.TabGeneral.Controls.Add(Me.GrpReglaPromocion)
        Me.TabGeneral.Controls.Add(Me.GrpGeneral)
        Me.TabGeneral.Location = New System.Drawing.Point(1, 21)
        Me.TabGeneral.Name = "TabGeneral"
        Me.TabGeneral.Size = New System.Drawing.Size(780, 503)
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
        Me.GrpProductoRegalo.Location = New System.Drawing.Point(2, 276)
        Me.GrpProductoRegalo.Name = "GrpProductoRegalo"
        Me.GrpProductoRegalo.Size = New System.Drawing.Size(775, 224)
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
        Me.GridRegalo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridRegalo.Location = New System.Drawing.Point(7, 44)
        Me.GridRegalo.Name = "GridRegalo"
        Me.GridRegalo.RecordNavigator = True
        Me.GridRegalo.Size = New System.Drawing.Size(761, 172)
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
        Me.GrpReglaPromocion.Location = New System.Drawing.Point(2, 156)
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
        Me.GrpGeneral.Controls.Add(Me.TxtGerarquia)
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
        Me.GrpGeneral.Size = New System.Drawing.Size(775, 146)
        Me.GrpGeneral.TabIndex = 119
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "Datos Generales"
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
        Me.ChkCascada.Location = New System.Drawing.Point(510, 116)
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
        'TxtGerarquia
        '
        Me.TxtGerarquia.Location = New System.Drawing.Point(537, 92)
        Me.TxtGerarquia.Name = "TxtGerarquia"
        Me.TxtGerarquia.Size = New System.Drawing.Size(55, 20)
        Me.TxtGerarquia.TabIndex = 5
        Me.TxtGerarquia.Text = "0"
        Me.TxtGerarquia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtGerarquia.Value = 0
        Me.TxtGerarquia.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
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
        'UiTabPage1
        '
        Me.UiTabPage1.Controls.Add(Me.GroupBox1)
        Me.UiTabPage1.Location = New System.Drawing.Point(1, 21)
        Me.UiTabPage1.Name = "UiTabPage1"
        Me.UiTabPage1.Size = New System.Drawing.Size(780, 503)
        Me.UiTabPage1.TabStop = True
        Me.UiTabPage1.Text = "Productos"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.BtnAgregaPro)
        Me.GroupBox1.Controls.Add(Me.BtnEliminaPro)
        Me.GroupBox1.Controls.Add(Me.GridProductos)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(764, 458)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Productos a los que aplica la promoción"
        '
        'BtnAgregaPro
        '
        Me.BtnAgregaPro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregaPro.Image = CType(resources.GetObject("BtnAgregaPro.Image"), System.Drawing.Image)
        Me.BtnAgregaPro.Location = New System.Drawing.Point(668, 18)
        Me.BtnAgregaPro.Name = "BtnAgregaPro"
        Me.BtnAgregaPro.Size = New System.Drawing.Size(90, 30)
        Me.BtnAgregaPro.TabIndex = 4
        Me.BtnAgregaPro.Text = "&Agregar"
        Me.BtnAgregaPro.ToolTipText = "Agregar nuevos productos a la promoción"
        Me.BtnAgregaPro.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminaPro
        '
        Me.BtnEliminaPro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminaPro.Image = CType(resources.GetObject("BtnEliminaPro.Image"), System.Drawing.Image)
        Me.BtnEliminaPro.Location = New System.Drawing.Point(668, 55)
        Me.BtnEliminaPro.Name = "BtnEliminaPro"
        Me.BtnEliminaPro.Size = New System.Drawing.Size(90, 30)
        Me.BtnEliminaPro.TabIndex = 5
        Me.BtnEliminaPro.Text = "&Eliminar "
        Me.BtnEliminaPro.ToolTipText = "Eliminar producto seleccionado de la promoción"
        Me.BtnEliminaPro.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridProductos
        '
        Me.GridProductos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridProductos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridProductos.ColumnAutoResize = True
        Me.GridProductos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridProductos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridProductos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridProductos.GroupByBoxVisible = False
        Me.GridProductos.Location = New System.Drawing.Point(7, 15)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.RecordNavigator = True
        Me.GridProductos.Size = New System.Drawing.Size(655, 438)
        Me.GridProductos.TabIndex = 1
        Me.GridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'TabClientes
        '
        Me.TabClientes.Controls.Add(Me.GrpClientes)
        Me.TabClientes.Location = New System.Drawing.Point(1, 21)
        Me.TabClientes.Name = "TabClientes"
        Me.TabClientes.Size = New System.Drawing.Size(780, 503)
        Me.TabClientes.TabStop = True
        Me.TabClientes.Text = "Clientes"
        Me.TabClientes.ToolTipText = "Clientes a los que aplica la promoción"
        '
        'GrpClientes
        '
        Me.GrpClientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpClientes.BackColor = System.Drawing.Color.Transparent
        Me.GrpClientes.Controls.Add(Me.BtnAddCte)
        Me.GrpClientes.Controls.Add(Me.BtnEliminaCte)
        Me.GrpClientes.Controls.Add(Me.GridClientes)
        Me.GrpClientes.Location = New System.Drawing.Point(7, 7)
        Me.GrpClientes.Name = "GrpClientes"
        Me.GrpClientes.Size = New System.Drawing.Size(763, 459)
        Me.GrpClientes.TabIndex = 4
        Me.GrpClientes.TabStop = False
        Me.GrpClientes.Text = "Clientes a los que aplica la promoción"
        '
        'BtnAddCte
        '
        Me.BtnAddCte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddCte.Image = CType(resources.GetObject("BtnAddCte.Image"), System.Drawing.Image)
        Me.BtnAddCte.Location = New System.Drawing.Point(667, 18)
        Me.BtnAddCte.Name = "BtnAddCte"
        Me.BtnAddCte.Size = New System.Drawing.Size(90, 30)
        Me.BtnAddCte.TabIndex = 4
        Me.BtnAddCte.Text = "&Agregar"
        Me.BtnAddCte.ToolTipText = "Agregar nuevo cliente a la promoción"
        Me.BtnAddCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminaCte
        '
        Me.BtnEliminaCte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminaCte.Image = CType(resources.GetObject("BtnEliminaCte.Image"), System.Drawing.Image)
        Me.BtnEliminaCte.Location = New System.Drawing.Point(667, 55)
        Me.BtnEliminaCte.Name = "BtnEliminaCte"
        Me.BtnEliminaCte.Size = New System.Drawing.Size(90, 30)
        Me.BtnEliminaCte.TabIndex = 5
        Me.BtnEliminaCte.Text = "&Eliminar "
        Me.BtnEliminaCte.ToolTipText = "Eliminar cliente seleccionado de la promoción"
        Me.BtnEliminaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridClientes
        '
        Me.GridClientes.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridClientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridClientes.ColumnAutoResize = True
        Me.GridClientes.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridClientes.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridClientes.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridClientes.GroupByBoxVisible = False
        Me.GridClientes.Location = New System.Drawing.Point(7, 15)
        Me.GridClientes.Name = "GridClientes"
        Me.GridClientes.RecordNavigator = True
        Me.GridClientes.Size = New System.Drawing.Size(654, 438)
        Me.GridClientes.TabIndex = 1
        Me.GridClientes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmPromocion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 573)
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
        Me.UiTabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabClientes.ResumeLayout(False)
        Me.GrpClientes.ResumeLayout(False)
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).EndInit()
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
    Public Gerarquia As Integer
    Public Cascada As Integer
    Public Estado As Integer
    Public Iguales As Integer

    Private PROClave As String
    Private CveProducto As String
    Private Nombre As String

    Private sClienteSelected, sProductoSelected As String
    Private sNombre, sNombreProducto As String

    Private alerta(9) As PictureBox
    Private reloj As parpadea

    Private cargado As Boolean = False
    Private DetalleEdited As Boolean = False
    Private RegaloEdited As Boolean = False

    Private dtDetalle, dtRegalo, dtCliente, dtProducto As DataTable


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

        If TxtGerarquia.Text = "" Then
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
        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_busca_producto", "@Clave", sClave, "@COMClave", ModPOS.CompanyActual)
        If Not dtProducto Is Nothing Then

            PROClave = dtProducto.Rows(0)("PROClave")
            CveProducto = dtProducto.Rows(0)("Clave")
            Nombre = dtProducto.Rows(0)("Nombre")

            dtProducto.Dispose()

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

    Public Sub addProductoPromocion(ByVal ID As String, ByVal Clave As String, ByVal Nombre As String)
        Dim foundRows() As System.Data.DataRow
        foundRows = dtProducto.Select("PROClave Like '" & ID & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtProducto.NewRow()
            'declara el nombre de la fila
            row1.Item("PROClave") = ID
            row1.Item("Clave") = Clave
            row1.Item("Nombre") = Nombre
            row1.Item("Status") = 0
            dtProducto.Rows.Add(row1)

        Else
            foundRows(0)("Status") = 0
        End If

    End Sub


    Public Sub addClienteDetalle(ByVal ID As String, ByVal Clave As String, ByVal RazonSocial As String, ByVal RFC As String)
        Dim foundRows() As System.Data.DataRow
        foundRows = dtCliente.Select("CTEClave Like '" & ID & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtCliente.NewRow()
            'declara el nombre de la fila
            row1.Item("CTEClave") = ID
            row1.Item("Clave") = Clave
            row1.Item("Razon Social") = RazonSocial
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
                                                    "PROClave", "System.String", _
                                                    "Clave", "System.String", _
                                                    "Nombre", "System.String", _
                                                    "Status", "System.Int32")

            dtCliente = ModPOS.CrearTabla("PromocionCliente", _
                                        "CTEClave", "System.String", _
                                        "Clave", "System.String", _
                                        "Razon Social", "System.String", _
                                        "RFC", "System.String", _
                                        "Status", "System.Int32")

            dtDetalle = ModPOS.CrearTabla("PromocionDetalle", _
                                        "Cantidad", "System.Double", _
                                        "CantidadFinal", "System.Double", _
                                        "Promocion", "System.Double")



            dtRegalo = ModPOS.CrearTabla("PromocionRegalo", "ID", "System.String", _
                                        "PROClave", "System.String", _
                                        "Clave", "System.String", _
                                        "Descripcion", "System.String", _
                                        "Cantidad", "System.Double")



            Dim row1 As DataRow
            row1 = dtDetalle.NewRow()
            'declara el nombre de la fila
            row1.Item("Cantidad") = 1
            row1.Item("CantidadFinal") = 1
            row1.Item("Promocion") = 0.0
            'agrega la fila completo a la tabla
            dtDetalle.Rows.Add(row1)

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

            If Tipo = 3 Then
                dtRegalo = ModPOS.Recupera_Tabla("sp_regalo_promocion", "@PRMClave", PRMClave)
            Else
                dtRegalo = ModPOS.CrearTabla("PromocionRegalo", "ID", "System.String", _
                            "PROClave", "System.String", _
                            "Clave", "System.String", _
                            "Descripcion", "System.String", _
                            "Cantidad", "System.Double")
            End If


            Me.TxtPromocionDesc.Text = Descripcion
            Me.TxtPromocionClave.Text = Clave
            TxtPromocionClave.Enabled = False
            Me.CmbFechaInicio.Value = FechaInicio
            Me.CmbFechaFin.Value = FechaFin
            Me.CmbTipoAplicacion.SelectedValue = Aplicacion
            Me.CmbTipoCalculo.SelectedValue = CalculoBase
            TxtGerarquia.Text = Gerarquia
            ChkCascada.Estado = Math.Abs(Cascada)
            ChkEstado.Estado = Math.Abs(Estado)
            ChkIguales.Estado = Math.Abs(Iguales)

            CmbTipoPromocion.Enabled = False
            TxtPromocionClave.ReadOnly = True
            CmbFechaInicio.Enabled = False
            CmbTipoAplicacion.Enabled = False
            CmbTipoCalculo.Enabled = False

            Me.CmbTipoPromocion.SelectedValue = Tipo


        End If

        cargado = True

        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False



        GridRegalo.DataSource = dtRegalo
        GridRegalo.RetrieveStructure(True)
        GridRegalo.GroupByBoxVisible = False
        GridRegalo.RootTable.Columns("ID").Visible = False
        GridRegalo.RootTable.Columns("PROClave").Visible = False
        GridRegalo.CurrentTable.Columns("Clave").Selectable = False
        GridRegalo.CurrentTable.Columns("Descripcion").Selectable = False


        GridProductos.DataSource = dtProducto
        GridProductos.RetrieveStructure(True)
        GridProductos.GroupByBoxVisible = False
        GridProductos.RootTable.Columns("PROClave").Visible = False
        GridProductos.RootTable.Columns("Status").Visible = False
        GridProductos.CurrentTable.Columns("Clave").Selectable = False
        GridProductos.CurrentTable.Columns("Nombre").Selectable = False

        Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
        fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridProductos.RootTable.Columns("Status"), Janus.Windows.GridEX.ConditionOperator.Equal, -1)
        fc1.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc1.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridProductos.RootTable.FormatConditions.Add(fc1)

        GridClientes.DataSource = dtCliente
        GridClientes.RetrieveStructure(True)
        GridClientes.RootTable.Columns("CTEClave").Visible = False
        GridClientes.RootTable.Columns("Status").Visible = False


        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridClientes.RootTable.Columns("Status"), Janus.Windows.GridEX.ConditionOperator.Equal, -1)
        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridClientes.RootTable.FormatConditions.Add(fc)

        actualizaGridTipo()
        actualizaGridAplicacion()
        actualizaGridCalculo()

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

                Case 2 ' Bonificacion
                    GridDetalle.CurrentTable.Columns("Promocion").Visible = True
                    GridDetalle.CurrentTable.Columns("Promocion").Caption = "Bonificar"

                    GridRegalo.Enabled = False
                    TxtProducto.Enabled = False
                    BtnBuscaProducto2.Enabled = False

                Case 3 ' Producto
                    GridDetalle.CurrentTable.Columns("Promocion").Visible = False
                    GridRegalo.Enabled = True
                    TxtProducto.Enabled = True
                    BtnBuscaProducto2.Enabled = True
                Case 4 'Puntos
                    GridDetalle.CurrentTable.Columns("Promocion").Visible = True
                    GridDetalle.CurrentTable.Columns("Promocion").Caption = "Puntos"

                    GridRegalo.Enabled = False
                    TxtProducto.Enabled = False
                    BtnBuscaProducto2.Enabled = False
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

            If dtCliente.Rows.Count = 0 Then
                MessageBox.Show("¡Debe agregar por lo menos un cliente a esta promoción!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                    Gerarquia = TxtGerarquia.Text
                    Cascada = ChkCascada.GetEstado
                    Iguales = ChkIguales.GetEstado

                    ModPOS.Ejecuta("sp_crea_promocion", _
                                  "@PRMClave", PRMClave, _
                                  "@Clave", Clave, _
                                  "@Descripcion", Descripcion, _
                                  "@Tipo", Tipo, _
                                  "@Aplicacion", Aplicacion, _
                                  "@CalculoBase", CalculoBase, _
                                  "@FechaInicio", FechaInicio, _
                                  "@FechaFin", FechaFin, _
                                  "@Gerarquia", Gerarquia, _
                                  "@Cascada", Cascada, _
                                  "@Iguales", Iguales, _
                                  "@Usuario", ModPOS.UsuarioActual, _
                                  "@COMClave", ModPOS.CompanyActual)

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
                                        "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    Cursor.Current = Cursors.WaitCursor

                    Dim foundRows() As DataRow
                    foundRows = dtCliente.Select("Status=0")
                    If foundRows.GetLength(0) > 0 Then

                        For fila = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_promocioncte", _
                            "@PRMClave", PRMClave, _
                            "@CTEClave", foundRows(fila)("CTEClave"), _
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

                    Cursor.Current = Cursors.Default

                Else

                    If Not (FechaFin.Date = CmbFechaFin.Value.Date AndAlso _
                            Descripcion = TxtPromocionDesc.Text.Trim.ToUpper AndAlso _
                            Gerarquia = TxtGerarquia.Text AndAlso _
                            Estado = ChkEstado.GetEstado AndAlso _
                            Math.Abs(Iguales) = ChkIguales.GetEstado AndAlso _
                            Math.Abs(Cascada) = ChkCascada.GetEstado) Then

                        FechaFin = CmbFechaFin.Value.Date.AddHours(23.9999)
                        Descripcion = TxtPromocionDesc.Text.Trim.ToUpper
                        Gerarquia = TxtGerarquia.Text
                        Cascada = ChkCascada.GetEstado
                        Estado = ChkEstado.GetEstado
                        Iguales = ChkIguales.GetEstado

                        ModPOS.Ejecuta("sp_actualiza_promocion", _
                               "@PRMClave", PRMClave, _
                               "@Descripcion", Descripcion, _
                               "@FechaFin", FechaFin, _
                               "@Gerarquia", Gerarquia, _
                               "@Cascada", Cascada, _
                               "@Estado", Estado, _
                               "@Iguales", Iguales, _
                               "@Usuario", ModPOS.UsuarioActual, _
                                  "@COMClave", ModPOS.CompanyActual)

                    End If

                    Dim fila As Integer

                    Dim foundRows() As DataRow

                    Cursor.Current = Cursors.WaitCursor
                    foundRows = dtCliente.Select("Status=0")

                    If foundRows.GetLength(0) > 0 Then
                        For fila = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_promocioncte", _
                            "@PRMClave", PRMClave, _
                            "@CTEClave", foundRows(fila)("CTEClave"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    foundRows = dtCliente.Select("Status=-1")
                    If foundRows.GetLength(0) > 0 Then
                        For fila = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_promocioncte", "@CTEClave", foundRows(fila)("CTEClave"), "@PRMCLAVE", PRMClave)
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
                                            "@Usuario", ModPOS.UsuarioActual)
                            Next
                        End If

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
            a.ProcedimientoAlmacenado = "sp_search_prod"
            a.TablaCmb = "Producto"
            a.CampoCmb = "Filtro"
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
                    foundRows = dtCliente.Select("CTEClave Like '" & sClienteSelected & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Status") = -1
                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub GridClientes_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridClientes.SelectionChanged
        If Not Me.GridClientes.GetValue(0) Is Nothing Then
            Me.BtnEliminaCte.Enabled = True
            Me.sClienteSelected = GridClientes.GetValue("CTEClave")
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
            End With
        End If
        ModPOS.AddPro.StartPosition = FormStartPosition.CenterScreen
        ModPOS.AddPro.Show()
        ModPOS.AddPro.BringToFront()
    End Sub

    Private Sub BtnEliminaPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminaPro.Click
        If sProductoSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Producto :" & sNombreProducto, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtProducto.Select("PROClave Like '" & sProductoSelected & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Status") = -1

                    End If

                Case DialogResult.No

            End Select
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
        a.ProcedimientoAlmacenado = "sp_search_prod"
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
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
End Class
