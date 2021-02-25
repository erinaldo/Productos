Imports System.IO

Public Class FrmProducto
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
    Friend WithEvents UiTab1 As Janus.Windows.UI.Tab.UITab
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiTabProducto As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabCosto As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabEquivalentes As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpEquivalentes As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDelEquivalente As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAddEquivalente As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridEquivalentes As Janus.Windows.GridEX.GridEX
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GrpProd As System.Windows.Forms.GroupBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents lblCosto As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents GrpMultiproducto As System.Windows.Forms.GroupBox
    Friend WithEvents BtnModProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnDelProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAddProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridMultiproducto As Janus.Windows.GridEX.GridEX
    Friend WithEvents TxtNumParte As System.Windows.Forms.TextBox
    Friend WithEvents GrpCosto As System.Windows.Forms.GroupBox
    Friend WithEvents UiTabKits As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCost As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents GrpUnidades As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDelUnidad As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridUnidades As Janus.Windows.GridEX.GridEX
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbSeguimiento As Selling.StoreCombo
    Friend WithEvents TxtDiasGarantia As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnReemplazo As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnKey As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpPrv As System.Windows.Forms.GroupBox
    Friend WithEvents GridPrv As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpConfiguracion As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents GrpInventario As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
    Friend WithEvents NumMaximo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents NumReorden As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents NumMinimo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GrpImpuestos As System.Windows.Forms.GroupBox
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CmbTipo As Selling.StoreCombo
    Friend WithEvents NumDec As System.Windows.Forms.NumericUpDown
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox15 As System.Windows.Forms.PictureBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CmbCompra As Selling.StoreCombo
    Friend WithEvents CmbTipoComision As Selling.StoreCombo
    Friend WithEvents CmbRotacion As Selling.StoreCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GrpImagen As System.Windows.Forms.GroupBox
    Friend WithEvents PicProducto As System.Windows.Forms.PictureBox
    Friend WithEvents BtnAddUnidad As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridImpuestos As Janus.Windows.GridEX.GridEX
    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtAlterno3 As System.Windows.Forms.TextBox
    Friend WithEvents Lbl3 As System.Windows.Forms.Label
    Friend WithEvents TxtAlterno2 As System.Windows.Forms.TextBox
    Friend WithEvents Lbl2 As System.Windows.Forms.Label
    Friend WithEvents TxtAlterno1 As System.Windows.Forms.TextBox
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents UiTabClasificaciones As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabAplicaciones As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpClasificaciones As System.Windows.Forms.GroupBox
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents LblReferencia As System.Windows.Forms.Label
    Friend WithEvents btnDelClasificacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridClasificaciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpAplicacion As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelAplicacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAddAplicacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridAplicacion As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnBuscaClasificacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkEscala As Selling.ChkStatus
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents GrpAduana As System.Windows.Forms.GroupBox
    Friend WithEvents lblPedimento As System.Windows.Forms.Label
    Friend WithEvents ChkKgLt As Selling.ChkStatus
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbTipoImpuesto As Selling.StoreCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAduana As System.Windows.Forms.TextBox
    Friend WithEvents txtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtPedimento As System.Windows.Forms.TextBox
    Friend WithEvents TxtClaveSAT As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbColor As Selling.StoreCombo
    Friend WithEvents PictureBox18 As System.Windows.Forms.PictureBox
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents cmbTalla As Selling.StoreCombo
    Friend WithEvents PictureBox17 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTalla As System.Windows.Forms.Label
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents lblModelo As System.Windows.Forms.Label
    Friend WithEvents txtModelo As System.Windows.Forms.TextBox
    Friend WithEvents chkNoFacturable As Selling.ChkStatus
    Friend WithEvents UiTabRetencion As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents grpRetenciones As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelRetencion As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAddRetencion As Janus.Windows.EditControls.UIButton
    Friend WithEvents gridRetencion As Janus.Windows.GridEX.GridEX
    Friend WithEvents ChkPreventa As Selling.ChkStatus
    Friend WithEvents ChkPaquete As Selling.ChkStatus
    Friend WithEvents Label17 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProducto))
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabProducto = New Janus.Windows.UI.Tab.UITabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GrpProd = New System.Windows.Forms.GroupBox()
        Me.chkNoFacturable = New Selling.ChkStatus(Me.components)
        Me.cmbColor = New Selling.StoreCombo()
        Me.PictureBox18 = New System.Windows.Forms.PictureBox()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.cmbTalla = New Selling.StoreCombo()
        Me.PictureBox17 = New System.Windows.Forms.PictureBox()
        Me.lblTalla = New System.Windows.Forms.Label()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.lblModelo = New System.Windows.Forms.Label()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.TxtClaveSAT = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TxtAlterno3 = New System.Windows.Forms.TextBox()
        Me.Lbl3 = New System.Windows.Forms.Label()
        Me.TxtAlterno2 = New System.Windows.Forms.TextBox()
        Me.Lbl2 = New System.Windows.Forms.Label()
        Me.TxtAlterno1 = New System.Windows.Forms.TextBox()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.GrpConfiguracion = New System.Windows.Forms.GroupBox()
        Me.ChkPreventa = New Selling.ChkStatus(Me.components)
        Me.ChkPaquete = New Selling.ChkStatus(Me.components)
        Me.PictureBox16 = New System.Windows.Forms.PictureBox()
        Me.cmbTipoImpuesto = New Selling.StoreCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChkKgLt = New Selling.ChkStatus(Me.components)
        Me.GrpAduana = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAduana = New System.Windows.Forms.TextBox()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmbFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtPedimento = New System.Windows.Forms.TextBox()
        Me.lblPedimento = New System.Windows.Forms.Label()
        Me.ChkEscala = New Selling.ChkStatus(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtDiasGarantia = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.CmbSeguimiento = New Selling.StoreCombo()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.GrpInventario = New System.Windows.Forms.GroupBox()
        Me.PictureBox14 = New System.Windows.Forms.PictureBox()
        Me.PictureBox13 = New System.Windows.Forms.PictureBox()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.NumMaximo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.NumReorden = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NumMinimo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CmbTipo = New Selling.StoreCombo()
        Me.NumDec = New System.Windows.Forms.NumericUpDown()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox15 = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CmbCompra = New Selling.StoreCombo()
        Me.CmbTipoComision = New Selling.StoreCombo()
        Me.CmbRotacion = New Selling.StoreCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GrpImagen = New System.Windows.Forms.GroupBox()
        Me.PicProducto = New System.Windows.Forms.PictureBox()
        Me.TxtCompany = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GrpImpuestos = New System.Windows.Forms.GroupBox()
        Me.GridImpuestos = New Janus.Windows.GridEX.GridEX()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.TxtNota = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnKey = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.GrpUnidades = New System.Windows.Forms.GroupBox()
        Me.BtnAddUnidad = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.BtnDelUnidad = New Janus.Windows.EditControls.UIButton()
        Me.GridUnidades = New Janus.Windows.GridEX.GridEX()
        Me.TxtNumParte = New System.Windows.Forms.TextBox()
        Me.GrpCosto = New System.Windows.Forms.GroupBox()
        Me.TxtCost = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.lblCosto = New System.Windows.Forms.Label()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.UiTabRetencion = New Janus.Windows.UI.Tab.UITabPage()
        Me.grpRetenciones = New System.Windows.Forms.GroupBox()
        Me.btnDelRetencion = New Janus.Windows.EditControls.UIButton()
        Me.btnAddRetencion = New Janus.Windows.EditControls.UIButton()
        Me.gridRetencion = New Janus.Windows.GridEX.GridEX()
        Me.UiTabClasificaciones = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpClasificaciones = New System.Windows.Forms.GroupBox()
        Me.BtnBuscaClasificacion = New Janus.Windows.EditControls.UIButton()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.LblReferencia = New System.Windows.Forms.Label()
        Me.btnDelClasificacion = New Janus.Windows.EditControls.UIButton()
        Me.GridClasificaciones = New Janus.Windows.GridEX.GridEX()
        Me.UiTabAplicaciones = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpAplicacion = New System.Windows.Forms.GroupBox()
        Me.btnDelAplicacion = New Janus.Windows.EditControls.UIButton()
        Me.btnAddAplicacion = New Janus.Windows.EditControls.UIButton()
        Me.GridAplicacion = New Janus.Windows.GridEX.GridEX()
        Me.UiTabKits = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpMultiproducto = New System.Windows.Forms.GroupBox()
        Me.BtnModProd = New Janus.Windows.EditControls.UIButton()
        Me.BtnDelProd = New Janus.Windows.EditControls.UIButton()
        Me.BtnAddProd = New Janus.Windows.EditControls.UIButton()
        Me.GridMultiproducto = New Janus.Windows.GridEX.GridEX()
        Me.UiTabEquivalentes = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpEquivalentes = New System.Windows.Forms.GroupBox()
        Me.BtnDelEquivalente = New Janus.Windows.EditControls.UIButton()
        Me.BtnAddEquivalente = New Janus.Windows.EditControls.UIButton()
        Me.GridEquivalentes = New Janus.Windows.GridEX.GridEX()
        Me.UiTabCosto = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpPrv = New System.Windows.Forms.GroupBox()
        Me.GridPrv = New Janus.Windows.GridEX.GridEX()
        Me.BtnReemplazo = New Janus.Windows.EditControls.UIButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabProducto.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GrpProd.SuspendLayout()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpConfiguracion.SuspendLayout()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpAduana.SuspendLayout()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpInventario.SuspendLayout()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumDec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpImagen.SuspendLayout()
        CType(Me.PicProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpImpuestos.SuspendLayout()
        CType(Me.GridImpuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpUnidades.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridUnidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCosto.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabRetencion.SuspendLayout()
        Me.grpRetenciones.SuspendLayout()
        CType(Me.gridRetencion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabClasificaciones.SuspendLayout()
        Me.GrpClasificaciones.SuspendLayout()
        CType(Me.GridClasificaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabAplicaciones.SuspendLayout()
        Me.GrpAplicacion.SuspendLayout()
        CType(Me.GridAplicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabKits.SuspendLayout()
        Me.GrpMultiproducto.SuspendLayout()
        CType(Me.GridMultiproducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabEquivalentes.SuspendLayout()
        Me.GrpEquivalentes.SuspendLayout()
        CType(Me.GridEquivalentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabCosto.SuspendLayout()
        Me.GrpPrv.SuspendLayout()
        CType(Me.GridPrv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiTab1
        '
        Me.UiTab1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTab1.Location = New System.Drawing.Point(1, 1)
        Me.UiTab1.Name = "UiTab1"
        Me.UiTab1.Size = New System.Drawing.Size(782, 516)
        Me.UiTab1.TabIndex = 0
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabProducto, Me.UiTabRetencion, Me.UiTabClasificaciones, Me.UiTabAplicaciones, Me.UiTabKits, Me.UiTabEquivalentes, Me.UiTabCosto})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabProducto
        '
        Me.UiTabProducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabProducto.Controls.Add(Me.Panel1)
        Me.UiTabProducto.Location = New System.Drawing.Point(1, 21)
        Me.UiTabProducto.Name = "UiTabProducto"
        Me.UiTabProducto.Size = New System.Drawing.Size(780, 494)
        Me.UiTabProducto.TabStop = True
        Me.UiTabProducto.Text = "General"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.GrpProd)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(780, 492)
        Me.Panel1.TabIndex = 3
        '
        'GrpProd
        '
        Me.GrpProd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpProd.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpProd.Controls.Add(Me.chkNoFacturable)
        Me.GrpProd.Controls.Add(Me.cmbColor)
        Me.GrpProd.Controls.Add(Me.PictureBox18)
        Me.GrpProd.Controls.Add(Me.lblColor)
        Me.GrpProd.Controls.Add(Me.cmbTalla)
        Me.GrpProd.Controls.Add(Me.PictureBox17)
        Me.GrpProd.Controls.Add(Me.lblTalla)
        Me.GrpProd.Controls.Add(Me.PictureBox10)
        Me.GrpProd.Controls.Add(Me.lblModelo)
        Me.GrpProd.Controls.Add(Me.txtModelo)
        Me.GrpProd.Controls.Add(Me.TxtClaveSAT)
        Me.GrpProd.Controls.Add(Me.Label19)
        Me.GrpProd.Controls.Add(Me.TxtAlterno3)
        Me.GrpProd.Controls.Add(Me.Lbl3)
        Me.GrpProd.Controls.Add(Me.TxtAlterno2)
        Me.GrpProd.Controls.Add(Me.Lbl2)
        Me.GrpProd.Controls.Add(Me.TxtAlterno1)
        Me.GrpProd.Controls.Add(Me.lbl1)
        Me.GrpProd.Controls.Add(Me.GrpConfiguracion)
        Me.GrpProd.Controls.Add(Me.GrpImagen)
        Me.GrpProd.Controls.Add(Me.TxtCompany)
        Me.GrpProd.Controls.Add(Me.Label18)
        Me.GrpProd.Controls.Add(Me.GrpImpuestos)
        Me.GrpProd.Controls.Add(Me.TxtNota)
        Me.GrpProd.Controls.Add(Me.Label16)
        Me.GrpProd.Controls.Add(Me.PictureBox4)
        Me.GrpProd.Controls.Add(Me.PictureBox1)
        Me.GrpProd.Controls.Add(Me.BtnKey)
        Me.GrpProd.Controls.Add(Me.PictureBox5)
        Me.GrpProd.Controls.Add(Me.GrpUnidades)
        Me.GrpProd.Controls.Add(Me.TxtNumParte)
        Me.GrpProd.Controls.Add(Me.GrpCosto)
        Me.GrpProd.Controls.Add(Me.ChkEstado)
        Me.GrpProd.Controls.Add(Me.lblCosto)
        Me.GrpProd.Controls.Add(Me.TxtDescripcion)
        Me.GrpProd.Controls.Add(Me.Label11)
        Me.GrpProd.Controls.Add(Me.TxtNombre)
        Me.GrpProd.Controls.Add(Me.LblNombre)
        Me.GrpProd.Controls.Add(Me.LblClave)
        Me.GrpProd.Controls.Add(Me.TxtClave)
        Me.GrpProd.Location = New System.Drawing.Point(6, 3)
        Me.GrpProd.MinimumSize = New System.Drawing.Size(754, 863)
        Me.GrpProd.Name = "GrpProd"
        Me.GrpProd.Size = New System.Drawing.Size(754, 908)
        Me.GrpProd.TabIndex = 1
        Me.GrpProd.TabStop = False
        '
        'chkNoFacturable
        '
        Me.chkNoFacturable.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkNoFacturable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNoFacturable.Checked = True
        Me.chkNoFacturable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNoFacturable.Location = New System.Drawing.Point(360, 16)
        Me.chkNoFacturable.Name = "chkNoFacturable"
        Me.chkNoFacturable.Size = New System.Drawing.Size(101, 22)
        Me.chkNoFacturable.TabIndex = 122
        Me.chkNoFacturable.Text = "No Facturable"
        '
        'cmbColor
        '
        Me.cmbColor.BackColor = System.Drawing.SystemColors.Window
        Me.cmbColor.Location = New System.Drawing.Point(342, 146)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(119, 21)
        Me.cmbColor.TabIndex = 119
        Me.cmbColor.Visible = False
        '
        'PictureBox18
        '
        Me.PictureBox18.Image = CType(resources.GetObject("PictureBox18.Image"), System.Drawing.Image)
        Me.PictureBox18.Location = New System.Drawing.Point(316, 153)
        Me.PictureBox18.Name = "PictureBox18"
        Me.PictureBox18.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox18.TabIndex = 121
        Me.PictureBox18.TabStop = False
        Me.PictureBox18.Visible = False
        '
        'lblColor
        '
        Me.lblColor.Location = New System.Drawing.Point(254, 149)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(78, 15)
        Me.lblColor.TabIndex = 120
        Me.lblColor.Text = "Color"
        Me.lblColor.Visible = False
        '
        'cmbTalla
        '
        Me.cmbTalla.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTalla.Location = New System.Drawing.Point(342, 120)
        Me.cmbTalla.Name = "cmbTalla"
        Me.cmbTalla.Size = New System.Drawing.Size(119, 21)
        Me.cmbTalla.TabIndex = 116
        Me.cmbTalla.Visible = False
        '
        'PictureBox17
        '
        Me.PictureBox17.Image = CType(resources.GetObject("PictureBox17.Image"), System.Drawing.Image)
        Me.PictureBox17.Location = New System.Drawing.Point(316, 124)
        Me.PictureBox17.Name = "PictureBox17"
        Me.PictureBox17.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox17.TabIndex = 118
        Me.PictureBox17.TabStop = False
        Me.PictureBox17.Visible = False
        '
        'lblTalla
        '
        Me.lblTalla.Location = New System.Drawing.Point(254, 124)
        Me.lblTalla.Name = "lblTalla"
        Me.lblTalla.Size = New System.Drawing.Size(78, 15)
        Me.lblTalla.TabIndex = 117
        Me.lblTalla.Text = "Talla"
        Me.lblTalla.Visible = False
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(316, 93)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox10.TabIndex = 115
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'lblModelo
        '
        Me.lblModelo.Location = New System.Drawing.Point(254, 98)
        Me.lblModelo.Name = "lblModelo"
        Me.lblModelo.Size = New System.Drawing.Size(56, 15)
        Me.lblModelo.TabIndex = 113
        Me.lblModelo.Text = "Modelo"
        Me.lblModelo.Visible = False
        '
        'txtModelo
        '
        Me.txtModelo.Location = New System.Drawing.Point(342, 93)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Size = New System.Drawing.Size(119, 20)
        Me.txtModelo.TabIndex = 114
        Me.txtModelo.Visible = False
        '
        'TxtClaveSAT
        '
        Me.TxtClaveSAT.Location = New System.Drawing.Point(92, 281)
        Me.TxtClaveSAT.Name = "TxtClaveSAT"
        Me.TxtClaveSAT.Size = New System.Drawing.Size(154, 20)
        Me.TxtClaveSAT.TabIndex = 111
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(7, 284)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(66, 15)
        Me.Label19.TabIndex = 112
        Me.Label19.Text = "Clave SAT"
        '
        'TxtAlterno3
        '
        Me.TxtAlterno3.Location = New System.Drawing.Point(92, 174)
        Me.TxtAlterno3.Name = "TxtAlterno3"
        Me.TxtAlterno3.Size = New System.Drawing.Size(154, 20)
        Me.TxtAlterno3.TabIndex = 109
        '
        'Lbl3
        '
        Me.Lbl3.Location = New System.Drawing.Point(6, 176)
        Me.Lbl3.Name = "Lbl3"
        Me.Lbl3.Size = New System.Drawing.Size(66, 15)
        Me.Lbl3.TabIndex = 110
        Me.Lbl3.Text = "Alterno 3"
        '
        'TxtAlterno2
        '
        Me.TxtAlterno2.Location = New System.Drawing.Point(92, 147)
        Me.TxtAlterno2.Name = "TxtAlterno2"
        Me.TxtAlterno2.Size = New System.Drawing.Size(154, 20)
        Me.TxtAlterno2.TabIndex = 107
        '
        'Lbl2
        '
        Me.Lbl2.Location = New System.Drawing.Point(7, 150)
        Me.Lbl2.Name = "Lbl2"
        Me.Lbl2.Size = New System.Drawing.Size(66, 15)
        Me.Lbl2.TabIndex = 108
        Me.Lbl2.Text = "Alterno 2"
        '
        'TxtAlterno1
        '
        Me.TxtAlterno1.Location = New System.Drawing.Point(92, 121)
        Me.TxtAlterno1.Name = "TxtAlterno1"
        Me.TxtAlterno1.Size = New System.Drawing.Size(154, 20)
        Me.TxtAlterno1.TabIndex = 105
        '
        'lbl1
        '
        Me.lbl1.Location = New System.Drawing.Point(7, 124)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(66, 15)
        Me.lbl1.TabIndex = 106
        Me.lbl1.Text = "Alterno 1"
        '
        'GrpConfiguracion
        '
        Me.GrpConfiguracion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpConfiguracion.Controls.Add(Me.ChkPreventa)
        Me.GrpConfiguracion.Controls.Add(Me.ChkPaquete)
        Me.GrpConfiguracion.Controls.Add(Me.PictureBox16)
        Me.GrpConfiguracion.Controls.Add(Me.cmbTipoImpuesto)
        Me.GrpConfiguracion.Controls.Add(Me.Label4)
        Me.GrpConfiguracion.Controls.Add(Me.ChkKgLt)
        Me.GrpConfiguracion.Controls.Add(Me.GrpAduana)
        Me.GrpConfiguracion.Controls.Add(Me.ChkEscala)
        Me.GrpConfiguracion.Controls.Add(Me.Label6)
        Me.GrpConfiguracion.Controls.Add(Me.TxtDiasGarantia)
        Me.GrpConfiguracion.Controls.Add(Me.PictureBox11)
        Me.GrpConfiguracion.Controls.Add(Me.CmbSeguimiento)
        Me.GrpConfiguracion.Controls.Add(Me.PictureBox3)
        Me.GrpConfiguracion.Controls.Add(Me.GrpInventario)
        Me.GrpConfiguracion.Controls.Add(Me.Label14)
        Me.GrpConfiguracion.Controls.Add(Me.CmbTipo)
        Me.GrpConfiguracion.Controls.Add(Me.NumDec)
        Me.GrpConfiguracion.Controls.Add(Me.PictureBox2)
        Me.GrpConfiguracion.Controls.Add(Me.Label9)
        Me.GrpConfiguracion.Controls.Add(Me.PictureBox15)
        Me.GrpConfiguracion.Controls.Add(Me.Label12)
        Me.GrpConfiguracion.Controls.Add(Me.Label15)
        Me.GrpConfiguracion.Controls.Add(Me.CmbCompra)
        Me.GrpConfiguracion.Controls.Add(Me.CmbTipoComision)
        Me.GrpConfiguracion.Controls.Add(Me.CmbRotacion)
        Me.GrpConfiguracion.Controls.Add(Me.Label2)
        Me.GrpConfiguracion.Controls.Add(Me.Label17)
        Me.GrpConfiguracion.Location = New System.Drawing.Point(475, 312)
        Me.GrpConfiguracion.Name = "GrpConfiguracion"
        Me.GrpConfiguracion.Size = New System.Drawing.Size(273, 590)
        Me.GrpConfiguracion.TabIndex = 2
        Me.GrpConfiguracion.TabStop = False
        Me.GrpConfiguracion.Text = "Configuración"
        '
        'ChkPreventa
        '
        Me.ChkPreventa.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkPreventa.Location = New System.Drawing.Point(16, 259)
        Me.ChkPreventa.Name = "ChkPreventa"
        Me.ChkPreventa.Size = New System.Drawing.Size(243, 22)
        Me.ChkPreventa.TabIndex = 118
        Me.ChkPreventa.Text = "Permite Preventa"
        '
        'ChkPaquete
        '
        Me.ChkPaquete.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkPaquete.Location = New System.Drawing.Point(15, 284)
        Me.ChkPaquete.Name = "ChkPaquete"
        Me.ChkPaquete.Size = New System.Drawing.Size(243, 22)
        Me.ChkPaquete.TabIndex = 117
        Me.ChkPaquete.Text = "Venta  por Paquete"
        '
        'PictureBox16
        '
        Me.PictureBox16.Image = CType(resources.GetObject("PictureBox16.Image"), System.Drawing.Image)
        Me.PictureBox16.Location = New System.Drawing.Point(92, 165)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox16.TabIndex = 115
        Me.PictureBox16.TabStop = False
        Me.PictureBox16.Visible = False
        '
        'cmbTipoImpuesto
        '
        Me.cmbTipoImpuesto.Location = New System.Drawing.Point(118, 159)
        Me.cmbTipoImpuesto.Name = "cmbTipoImpuesto"
        Me.cmbTipoImpuesto.Size = New System.Drawing.Size(142, 21)
        Me.cmbTipoImpuesto.TabIndex = 114
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 14)
        Me.Label4.TabIndex = 116
        Me.Label4.Text = "T. Impuesto"
        '
        'ChkKgLt
        '
        Me.ChkKgLt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkKgLt.Location = New System.Drawing.Point(15, 328)
        Me.ChkKgLt.Name = "ChkKgLt"
        Me.ChkKgLt.Size = New System.Drawing.Size(243, 22)
        Me.ChkKgLt.TabIndex = 113
        Me.ChkKgLt.Text = "Unidades por Kg/Lt"
        '
        'GrpAduana
        '
        Me.GrpAduana.Controls.Add(Me.Label10)
        Me.GrpAduana.Controls.Add(Me.txtAduana)
        Me.GrpAduana.Controls.Add(Me.txtOrigen)
        Me.GrpAduana.Controls.Add(Me.Label5)
        Me.GrpAduana.Controls.Add(Me.CmbFecha)
        Me.GrpAduana.Controls.Add(Me.Label3)
        Me.GrpAduana.Controls.Add(Me.TxtPedimento)
        Me.GrpAduana.Controls.Add(Me.lblPedimento)
        Me.GrpAduana.Location = New System.Drawing.Point(19, 455)
        Me.GrpAduana.Name = "GrpAduana"
        Me.GrpAduana.Size = New System.Drawing.Size(236, 129)
        Me.GrpAduana.TabIndex = 112
        Me.GrpAduana.TabStop = False
        Me.GrpAduana.Text = "Aduana"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(6, 100)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 17)
        Me.Label10.TabIndex = 120
        Me.Label10.Text = "Aduana"
        '
        'txtAduana
        '
        Me.txtAduana.Location = New System.Drawing.Point(76, 97)
        Me.txtAduana.Name = "txtAduana"
        Me.txtAduana.Size = New System.Drawing.Size(154, 20)
        Me.txtAduana.TabIndex = 119
        '
        'txtOrigen
        '
        Me.txtOrigen.Location = New System.Drawing.Point(76, 13)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Size = New System.Drawing.Size(154, 20)
        Me.txtOrigen.TabIndex = 118
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 15)
        Me.Label5.TabIndex = 117
        Me.Label5.Text = "Fecha "
        '
        'CmbFecha
        '
        Me.CmbFecha.CustomFormat = "yyyyMMdd"
        Me.CmbFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CmbFecha.Location = New System.Drawing.Point(117, 69)
        Me.CmbFecha.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.CmbFecha.Name = "CmbFecha"
        Me.CmbFecha.Size = New System.Drawing.Size(113, 20)
        Me.CmbFecha.TabIndex = 116
        Me.CmbFecha.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 17)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "Origen"
        '
        'TxtPedimento
        '
        Me.TxtPedimento.Location = New System.Drawing.Point(76, 41)
        Me.TxtPedimento.Name = "TxtPedimento"
        Me.TxtPedimento.Size = New System.Drawing.Size(154, 20)
        Me.TxtPedimento.TabIndex = 111
        '
        'lblPedimento
        '
        Me.lblPedimento.Location = New System.Drawing.Point(6, 44)
        Me.lblPedimento.Name = "lblPedimento"
        Me.lblPedimento.Size = New System.Drawing.Size(66, 15)
        Me.lblPedimento.TabIndex = 112
        Me.lblPedimento.Text = "Pedimento"
        '
        'ChkEscala
        '
        Me.ChkEscala.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkEscala.Location = New System.Drawing.Point(15, 304)
        Me.ChkEscala.Name = "ChkEscala"
        Me.ChkEscala.Size = New System.Drawing.Size(243, 22)
        Me.ChkEscala.TabIndex = 111
        Me.ChkEscala.Text = "Escala de Precios"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 15)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "Días de Garantía"
        '
        'TxtDiasGarantia
        '
        Me.TxtDiasGarantia.Enabled = False
        Me.TxtDiasGarantia.Location = New System.Drawing.Point(204, 206)
        Me.TxtDiasGarantia.Name = "TxtDiasGarantia"
        Me.TxtDiasGarantia.Size = New System.Drawing.Size(55, 20)
        Me.TxtDiasGarantia.TabIndex = 83
        Me.TxtDiasGarantia.Text = "0"
        Me.TxtDiasGarantia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.TxtDiasGarantia.Value = 0
        Me.TxtDiasGarantia.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'PictureBox11
        '
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(91, 138)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox11.TabIndex = 85
        Me.PictureBox11.TabStop = False
        Me.PictureBox11.Visible = False
        '
        'CmbSeguimiento
        '
        Me.CmbSeguimiento.Location = New System.Drawing.Point(117, 132)
        Me.CmbSeguimiento.Name = "CmbSeguimiento"
        Me.CmbSeguimiento.Size = New System.Drawing.Size(142, 21)
        Me.CmbSeguimiento.TabIndex = 7
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(91, 51)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox3.TabIndex = 35
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'GrpInventario
        '
        Me.GrpInventario.Controls.Add(Me.PictureBox14)
        Me.GrpInventario.Controls.Add(Me.PictureBox13)
        Me.GrpInventario.Controls.Add(Me.PictureBox12)
        Me.GrpInventario.Controls.Add(Me.NumMaximo)
        Me.GrpInventario.Controls.Add(Me.Label13)
        Me.GrpInventario.Controls.Add(Me.NumReorden)
        Me.GrpInventario.Controls.Add(Me.Label8)
        Me.GrpInventario.Controls.Add(Me.NumMinimo)
        Me.GrpInventario.Controls.Add(Me.Label7)
        Me.GrpInventario.Location = New System.Drawing.Point(19, 356)
        Me.GrpInventario.Name = "GrpInventario"
        Me.GrpInventario.Size = New System.Drawing.Size(237, 93)
        Me.GrpInventario.TabIndex = 102
        Me.GrpInventario.TabStop = False
        Me.GrpInventario.Text = "Inventario"
        '
        'PictureBox14
        '
        Me.PictureBox14.Image = CType(resources.GetObject("PictureBox14.Image"), System.Drawing.Image)
        Me.PictureBox14.Location = New System.Drawing.Point(92, 67)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox14.TabIndex = 100
        Me.PictureBox14.TabStop = False
        Me.PictureBox14.Visible = False
        '
        'PictureBox13
        '
        Me.PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), System.Drawing.Image)
        Me.PictureBox13.Location = New System.Drawing.Point(93, 41)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox13.TabIndex = 99
        Me.PictureBox13.TabStop = False
        Me.PictureBox13.Visible = False
        '
        'PictureBox12
        '
        Me.PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), System.Drawing.Image)
        Me.PictureBox12.Location = New System.Drawing.Point(93, 12)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox12.TabIndex = 98
        Me.PictureBox12.TabStop = False
        Me.PictureBox12.Visible = False
        '
        'NumMaximo
        '
        Me.NumMaximo.Location = New System.Drawing.Point(118, 68)
        Me.NumMaximo.Name = "NumMaximo"
        Me.NumMaximo.Size = New System.Drawing.Size(89, 20)
        Me.NumMaximo.TabIndex = 96
        Me.NumMaximo.Text = "0.00"
        Me.NumMaximo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.NumMaximo.Value = 0.0R
        Me.NumMaximo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(11, 71)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 12)
        Me.Label13.TabIndex = 97
        Me.Label13.Text = "Maximo"
        '
        'NumReorden
        '
        Me.NumReorden.Location = New System.Drawing.Point(120, 41)
        Me.NumReorden.Name = "NumReorden"
        Me.NumReorden.Size = New System.Drawing.Size(87, 20)
        Me.NumReorden.TabIndex = 94
        Me.NumReorden.Text = "0.00"
        Me.NumReorden.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.NumReorden.Value = 0.0R
        Me.NumReorden.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(10, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 17)
        Me.Label8.TabIndex = 95
        Me.Label8.Text = "Punto de Reorden"
        '
        'NumMinimo
        '
        Me.NumMinimo.Location = New System.Drawing.Point(120, 15)
        Me.NumMinimo.Name = "NumMinimo"
        Me.NumMinimo.Size = New System.Drawing.Size(86, 20)
        Me.NumMinimo.TabIndex = 92
        Me.NumMinimo.Text = "0.00"
        Me.NumMinimo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.NumMinimo.Value = 0.0R
        Me.NumMinimo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(10, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 14)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "Minimo"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(16, 235)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(119, 16)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "Numero de Decimales "
        '
        'CmbTipo
        '
        Me.CmbTipo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipo.Location = New System.Drawing.Point(118, 20)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(141, 21)
        Me.CmbTipo.TabIndex = 3
        '
        'NumDec
        '
        Me.NumDec.Location = New System.Drawing.Point(204, 233)
        Me.NumDec.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.NumDec.Name = "NumDec"
        Me.NumDec.Size = New System.Drawing.Size(55, 20)
        Me.NumDec.TabIndex = 10
        Me.NumDec.ThousandsSeparator = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(91, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox2.TabIndex = 52
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 15)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "T. Producto"
        '
        'PictureBox15
        '
        Me.PictureBox15.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PictureBox15.Image = CType(resources.GetObject("PictureBox15.Image"), System.Drawing.Image)
        Me.PictureBox15.Location = New System.Drawing.Point(91, 112)
        Me.PictureBox15.Name = "PictureBox15"
        Me.PictureBox15.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox15.TabIndex = 99
        Me.PictureBox15.TabStop = False
        Me.PictureBox15.Visible = False
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(16, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 17)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "T. Compra"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(16, 107)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 14)
        Me.Label15.TabIndex = 98
        Me.Label15.Text = "T. Comisión"
        '
        'CmbCompra
        '
        Me.CmbCompra.Location = New System.Drawing.Point(118, 48)
        Me.CmbCompra.Name = "CmbCompra"
        Me.CmbCompra.Size = New System.Drawing.Size(141, 21)
        Me.CmbCompra.TabIndex = 4
        '
        'CmbTipoComision
        '
        Me.CmbTipoComision.Location = New System.Drawing.Point(118, 104)
        Me.CmbTipoComision.Name = "CmbTipoComision"
        Me.CmbTipoComision.Size = New System.Drawing.Size(141, 21)
        Me.CmbTipoComision.TabIndex = 11
        '
        'CmbRotacion
        '
        Me.CmbRotacion.Location = New System.Drawing.Point(118, 76)
        Me.CmbRotacion.Name = "CmbRotacion"
        Me.CmbRotacion.Size = New System.Drawing.Size(141, 21)
        Me.CmbRotacion.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "T. Rotación"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(16, 135)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(95, 14)
        Me.Label17.TabIndex = 103
        Me.Label17.Text = "Seguimiento"
        '
        'GrpImagen
        '
        Me.GrpImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpImagen.Controls.Add(Me.PicProducto)
        Me.GrpImagen.Location = New System.Drawing.Point(475, 11)
        Me.GrpImagen.Name = "GrpImagen"
        Me.GrpImagen.Size = New System.Drawing.Size(273, 295)
        Me.GrpImagen.TabIndex = 103
        Me.GrpImagen.TabStop = False
        Me.GrpImagen.Text = "Imagen"
        '
        'PicProducto
        '
        Me.PicProducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicProducto.Location = New System.Drawing.Point(5, 17)
        Me.PicProducto.Name = "PicProducto"
        Me.PicProducto.Size = New System.Drawing.Size(264, 272)
        Me.PicProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicProducto.TabIndex = 54
        Me.PicProducto.TabStop = False
        '
        'TxtCompany
        '
        Me.TxtCompany.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCompany.Enabled = False
        Me.TxtCompany.Location = New System.Drawing.Point(92, 41)
        Me.TxtCompany.Name = "TxtCompany"
        Me.TxtCompany.ReadOnly = True
        Me.TxtCompany.Size = New System.Drawing.Size(369, 20)
        Me.TxtCompany.TabIndex = 104
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(7, 44)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 15)
        Me.Label18.TabIndex = 103
        Me.Label18.Text = "Compañia"
        '
        'GrpImpuestos
        '
        Me.GrpImpuestos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpImpuestos.Controls.Add(Me.GridImpuestos)
        Me.GrpImpuestos.Controls.Add(Me.PictureBox9)
        Me.GrpImpuestos.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpImpuestos.Location = New System.Drawing.Point(2, 618)
        Me.GrpImpuestos.Name = "GrpImpuestos"
        Me.GrpImpuestos.Size = New System.Drawing.Size(464, 284)
        Me.GrpImpuestos.TabIndex = 101
        Me.GrpImpuestos.TabStop = False
        Me.GrpImpuestos.Text = "Impuestos"
        '
        'GridImpuestos
        '
        Me.GridImpuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridImpuestos.AutoEdit = True
        Me.GridImpuestos.ColumnAutoResize = True
        Me.GridImpuestos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridImpuestos.Location = New System.Drawing.Point(5, 33)
        Me.GridImpuestos.Name = "GridImpuestos"
        Me.GridImpuestos.RecordNavigator = True
        Me.GridImpuestos.Size = New System.Drawing.Size(454, 245)
        Me.GridImpuestos.TabIndex = 8
        Me.GridImpuestos.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate
        Me.GridImpuestos.UpdateOnLeave = False
        Me.GridImpuestos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(121, 12)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox9.TabIndex = 74
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(6, 12)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(135, 22)
        Me.ChkMarcaTodos.TabIndex = 6
        Me.ChkMarcaTodos.Text = "Marcar Todos"
        '
        'TxtNota
        '
        Me.TxtNota.Location = New System.Drawing.Point(92, 255)
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.Size = New System.Drawing.Size(376, 20)
        Me.TxtNota.TabIndex = 102
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(7, 258)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 14)
        Me.Label16.TabIndex = 101
        Me.Label16.Text = "Observación"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(56, 201)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox4.TabIndex = 42
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(56, 70)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.TabIndex = 40
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnKey
        '
        Me.BtnKey.Image = CType(resources.GetObject("BtnKey.Image"), System.Drawing.Image)
        Me.BtnKey.Location = New System.Drawing.Point(252, 69)
        Me.BtnKey.Name = "BtnKey"
        Me.BtnKey.Size = New System.Drawing.Size(27, 21)
        Me.BtnKey.TabIndex = 100
        Me.BtnKey.ToolTipText = "Generar clave automatica"
        Me.BtnKey.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(56, 231)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox5.TabIndex = 72
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'GrpUnidades
        '
        Me.GrpUnidades.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpUnidades.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpUnidades.Controls.Add(Me.BtnAddUnidad)
        Me.GrpUnidades.Controls.Add(Me.PictureBox8)
        Me.GrpUnidades.Controls.Add(Me.BtnDelUnidad)
        Me.GrpUnidades.Controls.Add(Me.GridUnidades)
        Me.GrpUnidades.Location = New System.Drawing.Point(5, 360)
        Me.GrpUnidades.Name = "GrpUnidades"
        Me.GrpUnidades.Size = New System.Drawing.Size(464, 257)
        Me.GrpUnidades.TabIndex = 10
        Me.GrpUnidades.TabStop = False
        Me.GrpUnidades.Text = "Unidades de Venta"
        '
        'BtnAddUnidad
        '
        Me.BtnAddUnidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddUnidad.Icon = CType(resources.GetObject("BtnAddUnidad.Icon"), System.Drawing.Icon)
        Me.BtnAddUnidad.Location = New System.Drawing.Point(418, 13)
        Me.BtnAddUnidad.Name = "BtnAddUnidad"
        Me.BtnAddUnidad.Size = New System.Drawing.Size(34, 20)
        Me.BtnAddUnidad.TabIndex = 101
        Me.BtnAddUnidad.ToolTipText = "Agregar nueva unidad "
        Me.BtnAddUnidad.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(216, 13)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox8.TabIndex = 74
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'BtnDelUnidad
        '
        Me.BtnDelUnidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelUnidad.Icon = CType(resources.GetObject("BtnDelUnidad.Icon"), System.Drawing.Icon)
        Me.BtnDelUnidad.Location = New System.Drawing.Point(378, 13)
        Me.BtnDelUnidad.Name = "BtnDelUnidad"
        Me.BtnDelUnidad.Size = New System.Drawing.Size(34, 20)
        Me.BtnDelUnidad.TabIndex = 5
        Me.BtnDelUnidad.ToolTipText = "Eliminar unidad seleccionada"
        Me.BtnDelUnidad.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridUnidades
        '
        Me.GridUnidades.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridUnidades.ColumnAutoResize = True
        Me.GridUnidades.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridUnidades.Location = New System.Drawing.Point(10, 36)
        Me.GridUnidades.Name = "GridUnidades"
        Me.GridUnidades.RecordNavigator = True
        Me.GridUnidades.Size = New System.Drawing.Size(442, 216)
        Me.GridUnidades.TabIndex = 4
        Me.GridUnidades.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'TxtNumParte
        '
        Me.TxtNumParte.Location = New System.Drawing.Point(92, 95)
        Me.TxtNumParte.Name = "TxtNumParte"
        Me.TxtNumParte.Size = New System.Drawing.Size(154, 20)
        Me.TxtNumParte.TabIndex = 6
        '
        'GrpCosto
        '
        Me.GrpCosto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCosto.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpCosto.Controls.Add(Me.TxtCost)
        Me.GrpCosto.Controls.Add(Me.PictureBox6)
        Me.GrpCosto.Controls.Add(Me.PictureBox7)
        Me.GrpCosto.Controls.Add(Me.Label1)
        Me.GrpCosto.Location = New System.Drawing.Point(4, 304)
        Me.GrpCosto.Name = "GrpCosto"
        Me.GrpCosto.Size = New System.Drawing.Size(462, 52)
        Me.GrpCosto.TabIndex = 9
        Me.GrpCosto.TabStop = False
        Me.GrpCosto.Text = "Costo"
        '
        'TxtCost
        '
        Me.TxtCost.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.TxtCost.Location = New System.Drawing.Point(86, 21)
        Me.TxtCost.Name = "TxtCost"
        Me.TxtCost.Size = New System.Drawing.Size(140, 20)
        Me.TxtCost.TabIndex = 11
        Me.TxtCost.Text = "$0.00"
        Me.TxtCost.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCost.Value = 0.0R
        Me.TxtCost.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(240, 21)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox6.TabIndex = 73
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(60, 24)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox7.TabIndex = 73
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 15)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Costo Inicial"
        '
        'ChkEstado
        '
        Me.ChkEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(7, 16)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(101, 22)
        Me.ChkEstado.TabIndex = 52
        Me.ChkEstado.Text = "Activo"
        '
        'lblCosto
        '
        Me.lblCosto.Location = New System.Drawing.Point(7, 98)
        Me.lblCosto.Name = "lblCosto"
        Me.lblCosto.Size = New System.Drawing.Size(66, 15)
        Me.lblCosto.TabIndex = 47
        Me.lblCosto.Text = "Num. Parte"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(92, 228)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(376, 20)
        Me.TxtDescripcion.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(6, 231)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(102, 14)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Descrip. Larga"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(92, 201)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(244, 20)
        Me.TxtNombre.TabIndex = 7
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(7, 204)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(139, 15)
        Me.LblNombre.TabIndex = 3
        Me.LblNombre.Text = "Descrip. Corta"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(6, 72)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(56, 15)
        Me.LblClave.TabIndex = 1
        Me.LblClave.Text = "Clave"
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(92, 69)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(154, 20)
        Me.TxtClave.TabIndex = 5
        '
        'UiTabRetencion
        '
        Me.UiTabRetencion.Controls.Add(Me.grpRetenciones)
        Me.UiTabRetencion.Location = New System.Drawing.Point(1, 21)
        Me.UiTabRetencion.Name = "UiTabRetencion"
        Me.UiTabRetencion.Size = New System.Drawing.Size(780, 494)
        Me.UiTabRetencion.TabStop = True
        Me.UiTabRetencion.Text = "Retenciones"
        '
        'grpRetenciones
        '
        Me.grpRetenciones.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpRetenciones.Controls.Add(Me.btnDelRetencion)
        Me.grpRetenciones.Controls.Add(Me.btnAddRetencion)
        Me.grpRetenciones.Controls.Add(Me.gridRetencion)
        Me.grpRetenciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpRetenciones.Location = New System.Drawing.Point(0, 0)
        Me.grpRetenciones.Name = "grpRetenciones"
        Me.grpRetenciones.Size = New System.Drawing.Size(780, 494)
        Me.grpRetenciones.TabIndex = 13
        Me.grpRetenciones.TabStop = False
        Me.grpRetenciones.Text = "Retenciones"
        '
        'btnDelRetencion
        '
        Me.btnDelRetencion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelRetencion.Image = CType(resources.GetObject("btnDelRetencion.Image"), System.Drawing.Image)
        Me.btnDelRetencion.Location = New System.Drawing.Point(683, 55)
        Me.btnDelRetencion.Name = "btnDelRetencion"
        Me.btnDelRetencion.Size = New System.Drawing.Size(90, 30)
        Me.btnDelRetencion.TabIndex = 10
        Me.btnDelRetencion.Text = "&Eliminar"
        Me.btnDelRetencion.ToolTipText = "Eliminar impuesto seleccionado"
        Me.btnDelRetencion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAddRetencion
        '
        Me.btnAddRetencion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddRetencion.Image = CType(resources.GetObject("btnAddRetencion.Image"), System.Drawing.Image)
        Me.btnAddRetencion.Location = New System.Drawing.Point(683, 19)
        Me.btnAddRetencion.Name = "btnAddRetencion"
        Me.btnAddRetencion.Size = New System.Drawing.Size(90, 30)
        Me.btnAddRetencion.TabIndex = 9
        Me.btnAddRetencion.Text = "&Agregar "
        Me.btnAddRetencion.ToolTipText = "Agregar retención de impuestos"
        Me.btnAddRetencion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gridRetencion
        '
        Me.gridRetencion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridRetencion.ColumnAutoResize = True
        Me.gridRetencion.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.gridRetencion.Location = New System.Drawing.Point(10, 19)
        Me.gridRetencion.Name = "gridRetencion"
        Me.gridRetencion.RecordNavigator = True
        Me.gridRetencion.Size = New System.Drawing.Size(667, 470)
        Me.gridRetencion.TabIndex = 4
        Me.gridRetencion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabClasificaciones
        '
        Me.UiTabClasificaciones.Controls.Add(Me.GrpClasificaciones)
        Me.UiTabClasificaciones.Location = New System.Drawing.Point(1, 21)
        Me.UiTabClasificaciones.Name = "UiTabClasificaciones"
        Me.UiTabClasificaciones.Size = New System.Drawing.Size(780, 494)
        Me.UiTabClasificaciones.TabStop = True
        Me.UiTabClasificaciones.Text = "Clasificaciones"
        '
        'GrpClasificaciones
        '
        Me.GrpClasificaciones.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpClasificaciones.Controls.Add(Me.BtnBuscaClasificacion)
        Me.GrpClasificaciones.Controls.Add(Me.TxtReferencia)
        Me.GrpClasificaciones.Controls.Add(Me.LblReferencia)
        Me.GrpClasificaciones.Controls.Add(Me.btnDelClasificacion)
        Me.GrpClasificaciones.Controls.Add(Me.GridClasificaciones)
        Me.GrpClasificaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpClasificaciones.Location = New System.Drawing.Point(0, 0)
        Me.GrpClasificaciones.Name = "GrpClasificaciones"
        Me.GrpClasificaciones.Size = New System.Drawing.Size(780, 494)
        Me.GrpClasificaciones.TabIndex = 11
        Me.GrpClasificaciones.TabStop = False
        Me.GrpClasificaciones.Text = "Clasificaciones"
        '
        'BtnBuscaClasificacion
        '
        Me.BtnBuscaClasificacion.Image = CType(resources.GetObject("BtnBuscaClasificacion.Image"), System.Drawing.Image)
        Me.BtnBuscaClasificacion.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaClasificacion.Location = New System.Drawing.Point(248, 22)
        Me.BtnBuscaClasificacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscaClasificacion.Name = "BtnBuscaClasificacion"
        Me.BtnBuscaClasificacion.Size = New System.Drawing.Size(31, 30)
        Me.BtnBuscaClasificacion.TabIndex = 133
        Me.BtnBuscaClasificacion.ToolTipText = "Busqueda de Clasificaciones"
        Me.BtnBuscaClasificacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(88, 29)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(154, 20)
        Me.TxtReferencia.TabIndex = 102
        '
        'LblReferencia
        '
        Me.LblReferencia.Location = New System.Drawing.Point(13, 32)
        Me.LblReferencia.Name = "LblReferencia"
        Me.LblReferencia.Size = New System.Drawing.Size(66, 15)
        Me.LblReferencia.TabIndex = 103
        Me.LblReferencia.Text = "Referencia"
        '
        'btnDelClasificacion
        '
        Me.btnDelClasificacion.Icon = CType(resources.GetObject("btnDelClasificacion.Icon"), System.Drawing.Icon)
        Me.btnDelClasificacion.Location = New System.Drawing.Point(285, 22)
        Me.btnDelClasificacion.Name = "btnDelClasificacion"
        Me.btnDelClasificacion.Size = New System.Drawing.Size(31, 30)
        Me.btnDelClasificacion.TabIndex = 5
        Me.btnDelClasificacion.ToolTipText = "Eliminar clasificación seleccionada"
        Me.btnDelClasificacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridClasificaciones
        '
        Me.GridClasificaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridClasificaciones.ColumnAutoResize = True
        Me.GridClasificaciones.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridClasificaciones.Location = New System.Drawing.Point(10, 57)
        Me.GridClasificaciones.Name = "GridClasificaciones"
        Me.GridClasificaciones.RecordNavigator = True
        Me.GridClasificaciones.Size = New System.Drawing.Size(758, 432)
        Me.GridClasificaciones.TabIndex = 4
        Me.GridClasificaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabAplicaciones
        '
        Me.UiTabAplicaciones.Controls.Add(Me.GrpAplicacion)
        Me.UiTabAplicaciones.Location = New System.Drawing.Point(1, 21)
        Me.UiTabAplicaciones.Name = "UiTabAplicaciones"
        Me.UiTabAplicaciones.Size = New System.Drawing.Size(780, 494)
        Me.UiTabAplicaciones.TabStop = True
        Me.UiTabAplicaciones.Text = "Aplicaciones"
        '
        'GrpAplicacion
        '
        Me.GrpAplicacion.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpAplicacion.Controls.Add(Me.btnDelAplicacion)
        Me.GrpAplicacion.Controls.Add(Me.btnAddAplicacion)
        Me.GrpAplicacion.Controls.Add(Me.GridAplicacion)
        Me.GrpAplicacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpAplicacion.Location = New System.Drawing.Point(0, 0)
        Me.GrpAplicacion.Name = "GrpAplicacion"
        Me.GrpAplicacion.Size = New System.Drawing.Size(780, 494)
        Me.GrpAplicacion.TabIndex = 12
        Me.GrpAplicacion.TabStop = False
        Me.GrpAplicacion.Text = "Aplicaciones "
        '
        'btnDelAplicacion
        '
        Me.btnDelAplicacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelAplicacion.Image = CType(resources.GetObject("btnDelAplicacion.Image"), System.Drawing.Image)
        Me.btnDelAplicacion.Location = New System.Drawing.Point(683, 55)
        Me.btnDelAplicacion.Name = "btnDelAplicacion"
        Me.btnDelAplicacion.Size = New System.Drawing.Size(90, 30)
        Me.btnDelAplicacion.TabIndex = 10
        Me.btnDelAplicacion.Text = "&Eliminar"
        Me.btnDelAplicacion.ToolTipText = "Eliminar aplicación seleccionada"
        Me.btnDelAplicacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAddAplicacion
        '
        Me.btnAddAplicacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddAplicacion.Image = CType(resources.GetObject("btnAddAplicacion.Image"), System.Drawing.Image)
        Me.btnAddAplicacion.Location = New System.Drawing.Point(683, 19)
        Me.btnAddAplicacion.Name = "btnAddAplicacion"
        Me.btnAddAplicacion.Size = New System.Drawing.Size(90, 30)
        Me.btnAddAplicacion.TabIndex = 9
        Me.btnAddAplicacion.Text = "&Agregar "
        Me.btnAddAplicacion.ToolTipText = "Agregar aplicación"
        Me.btnAddAplicacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridAplicacion
        '
        Me.GridAplicacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridAplicacion.ColumnAutoResize = True
        Me.GridAplicacion.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridAplicacion.Location = New System.Drawing.Point(10, 19)
        Me.GridAplicacion.Name = "GridAplicacion"
        Me.GridAplicacion.RecordNavigator = True
        Me.GridAplicacion.Size = New System.Drawing.Size(667, 470)
        Me.GridAplicacion.TabIndex = 4
        Me.GridAplicacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabKits
        '
        Me.UiTabKits.Controls.Add(Me.GrpMultiproducto)
        Me.UiTabKits.Location = New System.Drawing.Point(1, 21)
        Me.UiTabKits.Name = "UiTabKits"
        Me.UiTabKits.Size = New System.Drawing.Size(780, 494)
        Me.UiTabKits.TabStop = True
        Me.UiTabKits.Text = "Kit Detalle"
        '
        'GrpMultiproducto
        '
        Me.GrpMultiproducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpMultiproducto.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpMultiproducto.Controls.Add(Me.BtnModProd)
        Me.GrpMultiproducto.Controls.Add(Me.BtnDelProd)
        Me.GrpMultiproducto.Controls.Add(Me.BtnAddProd)
        Me.GrpMultiproducto.Controls.Add(Me.GridMultiproducto)
        Me.GrpMultiproducto.Location = New System.Drawing.Point(11, 22)
        Me.GrpMultiproducto.Name = "GrpMultiproducto"
        Me.GrpMultiproducto.Size = New System.Drawing.Size(758, 462)
        Me.GrpMultiproducto.TabIndex = 7
        Me.GrpMultiproducto.TabStop = False
        Me.GrpMultiproducto.Text = "Detalle de Multiempaque"
        '
        'BtnModProd
        '
        Me.BtnModProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModProd.Image = CType(resources.GetObject("BtnModProd.Image"), System.Drawing.Image)
        Me.BtnModProd.Location = New System.Drawing.Point(660, 54)
        Me.BtnModProd.Name = "BtnModProd"
        Me.BtnModProd.Size = New System.Drawing.Size(90, 30)
        Me.BtnModProd.TabIndex = 7
        Me.BtnModProd.Text = "&Modificar"
        Me.BtnModProd.ToolTipText = "Modificar producto seleccionado"
        Me.BtnModProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnDelProd
        '
        Me.BtnDelProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelProd.Image = CType(resources.GetObject("BtnDelProd.Image"), System.Drawing.Image)
        Me.BtnDelProd.Location = New System.Drawing.Point(660, 93)
        Me.BtnDelProd.Name = "BtnDelProd"
        Me.BtnDelProd.Size = New System.Drawing.Size(90, 30)
        Me.BtnDelProd.TabIndex = 8
        Me.BtnDelProd.Text = "&Eliminar"
        Me.BtnDelProd.ToolTipText = "Eliminar producto seleccionado"
        Me.BtnDelProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAddProd
        '
        Me.BtnAddProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddProd.Image = CType(resources.GetObject("BtnAddProd.Image"), System.Drawing.Image)
        Me.BtnAddProd.Location = New System.Drawing.Point(660, 15)
        Me.BtnAddProd.Name = "BtnAddProd"
        Me.BtnAddProd.Size = New System.Drawing.Size(90, 30)
        Me.BtnAddProd.TabIndex = 6
        Me.BtnAddProd.Text = "&Agregar "
        Me.BtnAddProd.ToolTipText = "Agregar producto"
        Me.BtnAddProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridMultiproducto
        '
        Me.GridMultiproducto.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridMultiproducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMultiproducto.ColumnAutoResize = True
        Me.GridMultiproducto.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridMultiproducto.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridMultiproducto.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridMultiproducto.Location = New System.Drawing.Point(7, 15)
        Me.GridMultiproducto.Name = "GridMultiproducto"
        Me.GridMultiproducto.RecordNavigator = True
        Me.GridMultiproducto.Size = New System.Drawing.Size(647, 440)
        Me.GridMultiproducto.TabIndex = 1
        Me.GridMultiproducto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabEquivalentes
        '
        Me.UiTabEquivalentes.Controls.Add(Me.GrpEquivalentes)
        Me.UiTabEquivalentes.Location = New System.Drawing.Point(1, 21)
        Me.UiTabEquivalentes.Name = "UiTabEquivalentes"
        Me.UiTabEquivalentes.Size = New System.Drawing.Size(780, 494)
        Me.UiTabEquivalentes.TabStop = True
        Me.UiTabEquivalentes.Text = "Sustitutos"
        '
        'GrpEquivalentes
        '
        Me.GrpEquivalentes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpEquivalentes.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpEquivalentes.Controls.Add(Me.BtnDelEquivalente)
        Me.GrpEquivalentes.Controls.Add(Me.BtnAddEquivalente)
        Me.GrpEquivalentes.Controls.Add(Me.GridEquivalentes)
        Me.GrpEquivalentes.Location = New System.Drawing.Point(13, 19)
        Me.GrpEquivalentes.Name = "GrpEquivalentes"
        Me.GrpEquivalentes.Size = New System.Drawing.Size(757, 456)
        Me.GrpEquivalentes.TabIndex = 0
        Me.GrpEquivalentes.TabStop = False
        Me.GrpEquivalentes.Text = "Sustitutos"
        '
        'BtnDelEquivalente
        '
        Me.BtnDelEquivalente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelEquivalente.Image = CType(resources.GetObject("BtnDelEquivalente.Image"), System.Drawing.Image)
        Me.BtnDelEquivalente.Location = New System.Drawing.Point(660, 59)
        Me.BtnDelEquivalente.Name = "BtnDelEquivalente"
        Me.BtnDelEquivalente.Size = New System.Drawing.Size(90, 30)
        Me.BtnDelEquivalente.TabIndex = 1
        Me.BtnDelEquivalente.Text = "&Eliminar"
        Me.BtnDelEquivalente.ToolTipText = "Eliminar producto seleccionado"
        Me.BtnDelEquivalente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAddEquivalente
        '
        Me.BtnAddEquivalente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddEquivalente.Image = CType(resources.GetObject("BtnAddEquivalente.Image"), System.Drawing.Image)
        Me.BtnAddEquivalente.Location = New System.Drawing.Point(660, 22)
        Me.BtnAddEquivalente.Name = "BtnAddEquivalente"
        Me.BtnAddEquivalente.Size = New System.Drawing.Size(90, 30)
        Me.BtnAddEquivalente.TabIndex = 0
        Me.BtnAddEquivalente.Text = "&Agregar "
        Me.BtnAddEquivalente.ToolTipText = "Agregar producto"
        Me.BtnAddEquivalente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridEquivalentes
        '
        Me.GridEquivalentes.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEquivalentes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridEquivalentes.ColumnAutoResize = True
        Me.GridEquivalentes.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridEquivalentes.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridEquivalentes.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridEquivalentes.Location = New System.Drawing.Point(13, 22)
        Me.GridEquivalentes.Name = "GridEquivalentes"
        Me.GridEquivalentes.RecordNavigator = True
        Me.GridEquivalentes.Size = New System.Drawing.Size(641, 420)
        Me.GridEquivalentes.TabIndex = 2
        Me.GridEquivalentes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabCosto
        '
        Me.UiTabCosto.Controls.Add(Me.GrpPrv)
        Me.UiTabCosto.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCosto.Name = "UiTabCosto"
        Me.UiTabCosto.Size = New System.Drawing.Size(780, 494)
        Me.UiTabCosto.TabStop = True
        Me.UiTabCosto.Text = "Historico"
        Me.UiTabCosto.Visible = False
        '
        'GrpPrv
        '
        Me.GrpPrv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpPrv.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpPrv.Controls.Add(Me.GridPrv)
        Me.GrpPrv.Location = New System.Drawing.Point(5, 1)
        Me.GrpPrv.Name = "GrpPrv"
        Me.GrpPrv.Size = New System.Drawing.Size(772, 490)
        Me.GrpPrv.TabIndex = 2
        Me.GrpPrv.TabStop = False
        Me.GrpPrv.Text = "Proveedores"
        '
        'GridPrv
        '
        Me.GridPrv.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridPrv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPrv.ColumnAutoResize = True
        Me.GridPrv.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPrv.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPrv.GroupByBoxVisible = False
        Me.GridPrv.Location = New System.Drawing.Point(7, 15)
        Me.GridPrv.Name = "GridPrv"
        Me.GridPrv.RecordNavigator = True
        Me.GridPrv.Size = New System.Drawing.Size(759, 467)
        Me.GridPrv.TabIndex = 1
        Me.GridPrv.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnReemplazo
        '
        Me.BtnReemplazo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReemplazo.Enabled = False
        Me.BtnReemplazo.Icon = CType(resources.GetObject("BtnReemplazo.Icon"), System.Drawing.Icon)
        Me.BtnReemplazo.Location = New System.Drawing.Point(593, 520)
        Me.BtnReemplazo.Name = "BtnReemplazo"
        Me.BtnReemplazo.Size = New System.Drawing.Size(90, 37)
        Me.BtnReemplazo.TabIndex = 95
        Me.BtnReemplazo.Text = "&Remplazo Clave"
        Me.BtnReemplazo.ToolTipText = "Sustituir Clave de Producto"
        Me.BtnReemplazo.Visible = False
        Me.BtnReemplazo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(692, 520)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 1
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(495, 521)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmProducto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.BtnReemplazo)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.UiTab1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 551)
        Me.Name = "FrmProducto"
        Me.Text = "Producto"
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        Me.UiTabProducto.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GrpProd.ResumeLayout(False)
        Me.GrpProd.PerformLayout()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpConfiguracion.ResumeLayout(False)
        Me.GrpConfiguracion.PerformLayout()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpAduana.ResumeLayout(False)
        Me.GrpAduana.PerformLayout()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpInventario.ResumeLayout(False)
        Me.GrpInventario.PerformLayout()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumDec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpImagen.ResumeLayout(False)
        CType(Me.PicProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpImpuestos.ResumeLayout(False)
        CType(Me.GridImpuestos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpUnidades.ResumeLayout(False)
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridUnidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCosto.ResumeLayout(False)
        Me.GrpCosto.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabRetencion.ResumeLayout(False)
        Me.grpRetenciones.ResumeLayout(False)
        CType(Me.gridRetencion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabClasificaciones.ResumeLayout(False)
        Me.GrpClasificaciones.ResumeLayout(False)
        Me.GrpClasificaciones.PerformLayout()
        CType(Me.GridClasificaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabAplicaciones.ResumeLayout(False)
        Me.GrpAplicacion.ResumeLayout(False)
        CType(Me.GridAplicacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabKits.ResumeLayout(False)
        Me.GrpMultiproducto.ResumeLayout(False)
        CType(Me.GridMultiproducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabEquivalentes.ResumeLayout(False)
        Me.GrpEquivalentes.ResumeLayout(False)
        CType(Me.GridEquivalentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabCosto.ResumeLayout(False)
        Me.GrpPrv.ResumeLayout(False)
        CType(Me.GridPrv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Publicas"

    '  Public IncluyeIva As Boolean = False
    Public bIngreso As Boolean = False
    Public TImpuesto As Integer = 0
    Public Padre As String
    Public PROClave As String
    Public Clave As String
    Public NumParte As String

    Public Alterno1 As String
    Public Alterno2 As String
    Public Alterno3 As String
    Public Pedimento As String
    Public Fecha As Date = Today.Date
    Public Escala As Integer
    Public KgLt As Integer


    Public Descripcion As String
    Public Nombre As String
    Public Marca, Linea, Sublinea As Integer
    Public Estado As Integer
    Public Tipo As Integer = 1
    Public TCompra As Integer = 1
    Public Origen As String = ""
    Public Aduana As String = ""
    Public TRotacion As Integer = 1
    Public Costo As Double
    'Public flag As String = "Second"
    Private url_imagen As String = ""
    Private TallaColor As Integer = 0
    Public Seguimiento As Integer = 1
    Public DiasGarantia As Integer
    Public Minimo As Double
    Public Reorden As Double
    Public Maximo As Double
    Public NumDecimales As Integer
    Public CMIClave As String = ""
    Public Nota As String = ""
    Public FromForm As String = ""
    Public ClaveSAT As String = "01010101"

    Public Modelo As String = ""
    Public Talla As Double = -1
    Public Color As Double = -1
    Public noFacturable As Boolean = False
    Public vtaPaquete As Boolean = False
    Public Preventa As Boolean = False

#End Region

#Region "Variables Privadas"


    Private tmpCosto As Double

    Private RegistroGuardado As Boolean = False

    Private Enum Ejecutar
        Insert = 1
        Update = 0
    End Enum

    Public ActualizaCosto As Boolean = False

    Public ActualizaNeto As Boolean = False

    Private ActualizaUnidad As Boolean = False



    Private dtImpuesto, dtImpuestoProd, dtUnidades, dtClasificaciones, dtAplicaciones, dtRetenciones As DataTable
    Private dtMultiproducto As DataTable
    Private dtEquivalentes As DataTable

    Private SourceToImage As Bitmap

    Private alerta(17) As PictureBox
    Private reloj As parpadea
    Private guardado As Boolean = False

    Private sMLTSelected As String
    Private sNombre As String

    Private sMatNombre As String


    Private sIMPSelected As String
    Private sImp As String

    Private sUnidad As String
    Private sUnidadNombre As String

    Private sEquivalente As String
    Private sProductoEquivalente As String
    Private combosCargados As Boolean = False

    Private bCostoChanged As Boolean = False


    'Private EditaCosto As Integer = 1

    Private PicLoad As Boolean = False
    Private Imagenes(0) As Foto

#End Region

#Region "Producto General"

    Public Function RecuperaImpuesto(ByVal iTipo As Integer) As Double
        Dim FactorImpuesto As Double = 1

        If Not dtImpuesto Is Nothing AndAlso dtImpuesto.Rows.Count > 0 Then
            Dim foundRows() As DataRow
            foundRows = dtImpuesto.Select("Marca=True and TImpuesto=" & CStr(iTipo))

            If foundRows.GetLength(0) > 0 Then

                Dim i As Integer
                Dim PrecioImp As Double = 100
                Dim ImpImporte As Double = 0
                For i = 0 To foundRows.GetUpperBound(0)

                    If foundRows(i)("SobreImp") = 1 Then
                        If foundRows(i)("TAplicacion") = 1 Then
                            ImpImporte = PrecioImp * (foundRows(i)("Valor") / 100)
                        Else
                            ImpImporte = foundRows(i)("Valor")
                        End If
                    Else
                        If foundRows(i)("TAplicacion") = 1 Then
                            ImpImporte = foundRows(i)("Valor")
                        Else
                            ImpImporte = foundRows(i)("Valor")
                        End If
                    End If
                    PrecioImp = PrecioImp + ImpImporte
                Next

                FactorImpuesto = (1 + ((PrecioImp - 100) / 100))
            End If
        End If

        Return FactorImpuesto

    End Function


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 20 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 20)
        End If


        If Me.CmbTipo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.CmbCompra.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 50 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 50)
        End If


        If Me.TxtDescripcion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtDescripcion.Text.Length > 60 Then
            Me.TxtDescripcion.Text = Me.TxtDescripcion.Text.Substring(0, 60)
        End If



        If TxtCost.Text = "" OrElse CDbl(TxtCost.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If GridUnidades.RowCount = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()

        End If

        If GridImpuestos.RowCount = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(8))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CmbTipo.SelectedIndex = 2 AndAlso GridMultiproducto.RowCount = 0 Then
            i += 1
            Beep()
            MessageBox.Show("¡No se han agregado productos al kit o multiproducto actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        If Me.CmbSeguimiento.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(9))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CDbl(NumMinimo.Text) > CDbl(NumReorden.Text) Then
            i += 1
            reloj = New parpadea(Me.alerta(10))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CDbl(NumReorden.Text) > CDbl(NumMaximo.Text) Then
            i += 1
            reloj = New parpadea(Me.alerta(11))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbTipoComision.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(13))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.cmbTipoImpuesto.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(14))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TallaColor = 1 Then

            If Me.txtModelo.Text = "" Then
                i += 1
                reloj = New parpadea(Me.alerta(15))
                reloj.Enabled = True
                reloj.Start()
            End If

            If Me.cmbTalla.SelectedValue Is Nothing Then
                i += 1
                reloj = New parpadea(Me.alerta(16))
                reloj.Enabled = True
                reloj.Start()
            End If

            If Me.cmbColor.SelectedValue Is Nothing Then
                i += 1
                reloj = New parpadea(Me.alerta(17))
                reloj.Enabled = True
                reloj.Start()
            End If

        End If


        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Producto", "@clave", UCase(Trim(Me.TxtClave.Text)), "@COMClave", ModPOS.CompanyActual) > 0 Then
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

    Private Sub FrmProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Dim i As Integer
        Dim dtParam As DataTable = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "Imagenes", "@COMClave", ModPOS.CompanyActual)
        If dtParam.Rows.Count > 0 Then
            url_imagen = CStr(dtParam.Rows(i)("Valor"))
            If Not url_imagen.Substring(url_imagen.Length - 1, 1) = "\" Then
                url_imagen &= "\"
            End If
        End If
        dtParam.Dispose()


        dtParam = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "TallaColor", "@COMClave", ModPOS.CompanyActual)
        If dtParam.Rows.Count > 0 Then
            TallaColor = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))
        End If
        dtParam.Dispose()

        If TallaColor = 1 Then
            lblModelo.Visible = True
            txtModelo.Visible = True
            lblTalla.Visible = True
            cmbTalla.Visible = True
            cmbColor.Visible = True
            lblColor.Visible = True
        End If

        If ModPOS.AplicacionAutomotriz = 0 Then
            UiTabAplicaciones.TabVisible = False
        End If

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
        alerta(9) = Me.PictureBox11
        alerta(10) = Me.PictureBox12
        alerta(11) = Me.PictureBox13
        alerta(12) = Me.PictureBox14
        alerta(13) = Me.PictureBox15
        alerta(14) = Me.PictureBox16
        alerta(15) = Me.PictureBox10
        alerta(16) = Me.PictureBox17
        alerta(17) = Me.PictureBox18

        With Me.CmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Producto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With Me.CmbCompra
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Producto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Compra"
            .llenar()
        End With


        With Me.CmbRotacion
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Producto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Rotacion"
            .llenar()
        End With

        With Me.cmbTipoImpuesto
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Impuesto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        'sp_filtra_marca

        With Me.CmbSeguimiento
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Producto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Seguimiento"
            .llenar()
        End With


        With Me.CmbTipoComision
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_comision_producto"
            .llenar()
        End With

        If TallaColor = 1 Then

            With Me.cmbTalla
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_valorref"
                .NombreParametro1 = "tabla"
                .Parametro1 = "Producto"
                .NombreParametro2 = "campo"
                .Parametro2 = "Talla"
                .llenar()
            End With

            With Me.cmbColor
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_valorref"
                .NombreParametro1 = "tabla"
                .Parametro1 = "Producto"
                .NombreParametro2 = "campo"
                .Parametro2 = "Color"
                .llenar()
            End With

            txtModelo.Text = Modelo
            cmbTalla.SelectedValue = Talla
            cmbColor.SelectedValue = Color

        End If



        combosCargados = True

        TxtClave.Text = Clave
        TxtNumParte.Text = NumParte
        TxtNombre.Text = Nombre
        TxtDescripcion.Text = Descripcion
        TxtCost.Text = Costo
        tmpCosto = Costo
        TxtNota.Text = Nota
        TxtClaveSAT.Text = ClaveSAT
        TxtDiasGarantia.Text = CStr(DiasGarantia)
        NumMinimo.Text = Minimo
        NumReorden.Text = Reorden
        NumMaximo.Text = Maximo
        NumDec.Value = NumDecimales

        TxtAlterno1.Text = Alterno1
        TxtAlterno2.Text = Alterno2
        TxtAlterno3.Text = Alterno3
        TxtPedimento.Text = Pedimento
        ChkEscala.Estado = Escala
        ChkKgLt.Estado = KgLt
        CmbFecha.Value = Fecha

        chkNoFacturable.Checked = noFacturable
        ChkPaquete.Checked = vtaPaquete
        ChkPreventa.Checked = Preventa


        If Padre = "Agregar" Then

            PROClave = ModPOS.obtenerLlave

            dtUnidades = ModPOS.CrearTabla("ProductoUnidad", _
            "ID", "System.String", _
            "Unidad", "System.String", _
            "EAN", "System.String", _
            "Barras", "System.String", _
            "Factor", "System.Int32", _
            "Peso", "System.Double", _
            "Volumen", "System.Double", _
            "Alto", "System.Double", _
            "Largo", "System.Double", _
            "Ancho", "System.Double", _
            "Uso", "System.Int32", _
            "Tipo", "System.String")

            dtClasificaciones = ModPOS.CrearTabla("ClasProd", _
            "CLAClave", "System.Int32", _
            "Grupo", "System.String", _
            "Referencia", "System.String", _
            "Nombre", "System.String", _
            "TGrupo", "System.Int32", _
            "Update", "System.Int32", _
            "Baja", "System.Int32")

            dtMultiproducto = ModPOS.CrearTabla("Multiproducto", _
            "ID", "System.String", _
            "PROClave", "System.String", _
            "Clave", "System.String", _
            "Nombre", "System.String", _
            "Unidad", "System.String", _
            "Cantidad", "System.Double", _
            "Estado", "System.String", _
            "iEstado", "System.Int32", _
            "Update", "System.Int32", _
            "Baja", "System.Int32", _
            "TProducto", "System.Int32")

            dtEquivalentes = ModPOS.CrearTabla("Equivalentes", _
            "ID", "System.String", _
            "Clave", "System.String", _
            "Nombre", "System.String", _
            "Descripción", "System.String", _
            "Update", "System.Int32", _
            "Baja", "System.Int32")


            dtAplicaciones = ModPOS.CrearTabla("Aplicaciones", _
                       "ID", "System.String", _
                       "Marca", "System.String", _
                       "Modelo", "System.String", _
                       "Año", "System.Int32", _
                       "Hasta", "System.Int32", _
                       "Update", "System.Int32", _
                       "Baja", "System.Int32")

            dtRetenciones = ModPOS.CrearTabla("Retenciones", _
                     "IMPClave", "System.String", _
                     "Impuesto", "System.String", _
                     "Tasa", "System.Double", _
                     "Update", "System.Int32", _
                     "Baja", "System.Int32")

        Else

            CmbTipo.SelectedValue = Tipo
            CmbCompra.SelectedValue = TCompra
            txtOrigen.Text = Origen
            txtAduana.Text = Aduana
            ChkEstado.Estado = Estado
            CmbRotacion.SelectedValue = TRotacion
            CmbSeguimiento.SelectedValue = Seguimiento
            CmbTipoComision.SelectedValue = CMIClave
            cmbTipoImpuesto.SelectedValue = TImpuesto

            TxtCost.Enabled = False
            BtnKey.Enabled = False
            BtnReemplazo.Visible = True
            BtnReemplazo.Enabled = True

            dtUnidades = ModPOS.Recupera_Tabla("sp_muestra_productounidad", "@PROClave", PROClave)

            dtClasificaciones = ModPOS.Recupera_Tabla("sp_muestra_clasprod", "@PROClave", PROClave)


            dtMultiproducto = ModPOS.Recupera_Tabla("sp_muestra_multiproductos", "@ProductoPadre", PROClave)

            dtEquivalentes = ModPOS.Recupera_Tabla("sp_muestra_equivalentes", "@PROClave", PROClave)


            dtAplicaciones = ModPOS.Recupera_Tabla("sp_muestra_aplicaciones", "@PROClave", PROClave)

            dtRetenciones = ModPOS.Recupera_Tabla("st_muestra_retenciones", "@PROClave", PROClave)

            If PROClave = Clave Then
                GrpProd.Enabled = False
                GrpClasificaciones.Enabled = False
                GrpAplicacion.Enabled = False
                GrpMultiproducto.Enabled = False
                GrpEquivalentes.Enabled = False
                GrpPrv.Enabled = False
            End If

        End If


        GridUnidades.DataSource = dtUnidades
        GridUnidades.RetrieveStructure(True)
        GridUnidades.GroupByBoxVisible = False
        GridUnidades.RootTable.Columns("ID").Visible = False
        GridUnidades.RootTable.Columns("EAN").Visible = False
        GridUnidades.CurrentTable.Columns(1).Selectable = False
        GridUnidades.CurrentTable.Columns("Tipo").Selectable = False
        GridUnidades.RootTable.Columns("Uso").Visible = False

        GridUnidades.RootTable.Columns("Peso").FormatString = "0.00"
        GridUnidades.RootTable.Columns("Volumen").FormatString = "0.00"
        GridUnidades.RootTable.Columns("Alto").FormatString = "0.00"
        GridUnidades.RootTable.Columns("Largo").FormatString = "0.00"
        GridUnidades.RootTable.Columns("Ancho").FormatString = "0.00"


        GridClasificaciones.DataSource = dtClasificaciones
        GridClasificaciones.RetrieveStructure(True)
        GridClasificaciones.GroupByBoxVisible = False
        GridClasificaciones.RootTable.Columns("CLAClave").Visible = False
        GridClasificaciones.RootTable.Columns("TGrupo").Visible = False
        GridClasificaciones.RootTable.Columns("Update").Visible = False
        GridClasificaciones.RootTable.Columns("Baja").Visible = False

        Dim fc0 As Janus.Windows.GridEX.GridEXFormatCondition
        fc0 = New Janus.Windows.GridEX.GridEXFormatCondition(GridClasificaciones.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc0.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc0.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridClasificaciones.RootTable.FormatConditions.Add(fc0)

        GridMultiproducto.DataSource = dtMultiproducto
        GridMultiproducto.RetrieveStructure(True)
        GridMultiproducto.GroupByBoxVisible = False
        GridMultiproducto.RootTable.Columns("ID").Visible = False
        GridMultiproducto.RootTable.Columns("PROClave").Visible = False
        GridMultiproducto.RootTable.Columns("iEstado").Visible = False
        GridMultiproducto.CurrentTable.Columns(1).Selectable = False
        GridMultiproducto.RootTable.Columns("Update").Visible = False
        GridMultiproducto.RootTable.Columns("Baja").Visible = False
        GridMultiproducto.RootTable.Columns("TProducto").Visible = False


        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridMultiproducto.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridMultiproducto.RootTable.FormatConditions.Add(fc)

        GridEquivalentes.DataSource = dtEquivalentes
        GridEquivalentes.RetrieveStructure(True)
        GridEquivalentes.GroupByBoxVisible = False
        GridEquivalentes.RootTable.Columns("ID").Visible = False
        GridEquivalentes.RootTable.Columns("Update").Visible = False
        GridEquivalentes.RootTable.Columns("Baja").Visible = False

        Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
        fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridEquivalentes.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc1.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc1.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridEquivalentes.RootTable.FormatConditions.Add(fc1)




        GridAplicacion.DataSource = dtAplicaciones
        GridAplicacion.RetrieveStructure(True)
        GridAplicacion.GroupByBoxVisible = False
        GridAplicacion.RootTable.Columns("ID").Visible = False
        GridAplicacion.RootTable.Columns("Update").Visible = False
        GridAplicacion.RootTable.Columns("Baja").Visible = False

        Dim fc3 As Janus.Windows.GridEX.GridEXFormatCondition
        fc3 = New Janus.Windows.GridEX.GridEXFormatCondition(GridAplicacion.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc3.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc3.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridAplicacion.RootTable.FormatConditions.Add(fc3)


        gridRetencion.DataSource = dtRetenciones
        gridRetencion.RetrieveStructure(True)
        gridRetencion.GroupByBoxVisible = False
        gridRetencion.RootTable.Columns("IMPClave").Visible = False
        gridRetencion.RootTable.Columns("Update").Visible = False
        gridRetencion.RootTable.Columns("Baja").Visible = False

        Dim fc4 As Janus.Windows.GridEX.GridEXFormatCondition
        fc4 = New Janus.Windows.GridEX.GridEXFormatCondition(gridRetencion.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc4.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc4.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        gridRetencion.RootTable.FormatConditions.Add(fc4)


        Me.RecuperaImagenProducto(url_imagen)

        dtImpuesto = ModPOS.Recupera_Tabla("sp_filtra_impuestos", "@COMClave", ModPOS.CompanyActual)
        If Not dtImpuesto Is Nothing Then
            GridImpuestos.DataSource = dtImpuesto
            GridImpuestos.RetrieveStructure(True)
            GridImpuestos.GroupByBoxVisible = False
            GridImpuestos.RootTable.Columns("IMPClave").Visible = False
            GridImpuestos.CurrentTable.Columns("Nombre").Selectable = False
            GridImpuestos.CurrentTable.Columns("Tipo").Selectable = False


            ChkMarcaTodos.Enabled = True

            If Padre = "Agregar" Then
                dtImpuestoProd = ModPOS.Recupera_Tabla("sp_filtra_impuestos_def", "@COMClave", ModPOS.CompanyActual)
            Else
                dtImpuestoProd = ModPOS.Recupera_Tabla("sp_filtra_impuestos_prod", "@Producto", PROClave)
            End If

            If Not dtImpuestoProd Is Nothing Then
                Dim y, x As Integer
                For y = 0 To dtImpuesto.Rows.Count - 1
                    For x = 0 To dtImpuestoProd.Rows.Count - 1
                        If dtImpuesto.Rows(y)("IMPClave") = dtImpuestoProd.Rows(x)("IMPClave") Then
                            dtImpuesto.Rows(y)("Marca") = True
                            Exit For
                        End If
                    Next
                Next
            End If
        End If
    End Sub

    Private Sub Reinicializa()

        Me.AutoScrollPosition = New Point(0, 0)
        tmpCosto = 0
        Clave = ""
        Nombre = ""
        Descripcion = ""
        Costo = 0
        NumParte = ""
        DiasGarantia = 0
        Estado = 1
        Tipo = 1
        Origen = ""
        Aduana = ""
        Fecha = Today.Date
        TCompra = 1
        TRotacion = 1
        TImpuesto = 1
        Minimo = 0
        Reorden = 1
        Maximo = 2
        url_imagen = ""
        Seguimiento = 1
        NumDecimales = 0
        Nota = ""
        Alterno1 = ""
        Alterno2 = ""
        Alterno3 = ""
        Pedimento = ""
        Escala = 0
        KgLt = 0
        ClaveSAT = "01010101"
        Modelo = ""
        Talla = -1
        Color = -1
        noFacturable = False
        vtaPaquete = False
        Preventa = False
        Nota = TxtNota.Text.ToUpper.Trim

        TxtClave.Text = Clave
        TxtNombre.Text = Nombre
        TxtDescripcion.Text = Descripcion
        TxtCost.Text = Costo
        CmbTipo.SelectedValue = Tipo
        CmbCompra.SelectedValue = TCompra
        txtOrigen.Text = Origen
        txtAduana.Text = Aduana
        ChkEstado.Estado = Estado
        CmbRotacion.SelectedValue = TRotacion
        CmbSeguimiento.SelectedValue = Seguimiento
        TxtDiasGarantia.Text = CStr(DiasGarantia)
        NumMinimo.Text = Minimo
        NumReorden.Text = Reorden
        NumMaximo.Text = Maximo
        NumDec.Value = NumDecimales
        CmbFecha.Value = Fecha
        TxtAlterno1.Text = Alterno1
        TxtAlterno2.Text = Alterno2
        TxtAlterno3.Text = Alterno3
        TxtPedimento.Text = Pedimento
        ChkEscala.Estado = Escala
        ChkKgLt.Estado = KgLt
        TxtClaveSAT.Text = ClaveSAT
        PROClave = ModPOS.obtenerLlave
        chkNoFacturable.Checked = noFacturable
        ChkPaquete.Checked = vtaPaquete
        ChkPreventa.Checked = Preventa
        If TallaColor = 1 Then
            txtModelo.Text = Modelo
            cmbTalla.SelectedValue = Talla
            cmbColor.SelectedValue = Color
        End If
        dtUnidades.Dispose()

        dtUnidades = ModPOS.CrearTabla("ProductoUnidad", _
        "ID", "System.String", _
        "Unidad", "System.String", _
        "EAN", "System.String", _
        "Barras", "System.String", _
        "Factor", "System.Int32", _
        "Peso", "System.Double", _
        "Volumen", "System.Double", _
        "Alto", "System.Double", _
        "Largo", "System.Double", _
        "Ancho", "System.Double", _
        "Uso", "System.Int32", _
        "Tipo", "System.String")


        dtMultiproducto.Dispose()

        dtMultiproducto = ModPOS.CrearTabla("Multiproducto", _
            "ID", "System.String", _
            "PROClave", "System.String", _
            "Clave", "System.String", _
            "Nombre", "System.String", _
            "Unidad", "System.String", _
            "Cantidad", "System.Double", _
            "Estado", "System.String", _
            "iEstado", "System.Int32", _
            "Update", "System.Int32", _
            "Baja", "System.Int32", _
            "TProducto", "System.Int32")

        dtClasificaciones = ModPOS.CrearTabla("ClasProd", _
            "CLAClave", "System.Int32", _
            "Grupo", "System.String", _
            "Referencia", "System.String", _
            "Nombre", "System.String", _
            "TGrupo", "System.Int32", _
            "Update", "System.Int32", _
            "Baja", "System.Int32")

        dtEquivalentes = ModPOS.CrearTabla("Equivalentes", _
            "ID", "System.String", _
            "Clave", "System.String", _
            "Nombre", "System.String", _
            "Descripción", "System.String", _
            "Update", "System.Int32", _
            "Baja", "System.Int32")



        dtAplicaciones = ModPOS.CrearTabla("Aplicaciones", _
                     "ID", "System.String", _
                     "Marca", "System.String", _
                     "Modelo", "System.String", _
                     "Año", "System.Int32", _
                     "Hasta", "System.Int32", _
                     "Update", "System.Int32", _
                     "Baja", "System.Int32")

        dtRetenciones = ModPOS.CrearTabla("Retenciones", _
                 "IMClave", "System.String", _
                 "Impuesto", "System.String", _
                 "Tasa", "System.Double", _
                 "Update", "System.Int32", _
                 "Baja", "System.Int32")


        GridUnidades.DataSource = dtUnidades
        GridUnidades.RetrieveStructure(True)
        GridUnidades.GroupByBoxVisible = False
        GridUnidades.RootTable.Columns("ID").Visible = False
        GridUnidades.RootTable.Columns("EAN").Visible = False
        GridUnidades.CurrentTable.Columns(1).Selectable = False
        GridUnidades.CurrentTable.Columns("Tipo").Selectable = False
        GridUnidades.RootTable.Columns("Uso").Visible = False

        GridClasificaciones.DataSource = dtClasificaciones
        GridClasificaciones.RetrieveStructure(True)
        GridClasificaciones.GroupByBoxVisible = False
        GridClasificaciones.RootTable.Columns("CLAClave").Visible = False
        GridClasificaciones.RootTable.Columns("TGrupo").Visible = False
        GridClasificaciones.RootTable.Columns("Update").Visible = False
        GridClasificaciones.RootTable.Columns("Baja").Visible = False

        Dim fc0 As Janus.Windows.GridEX.GridEXFormatCondition
        fc0 = New Janus.Windows.GridEX.GridEXFormatCondition(GridClasificaciones.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc0.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc0.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridClasificaciones.RootTable.FormatConditions.Add(fc0)


        GridMultiproducto.DataSource = dtMultiproducto
        GridMultiproducto.RetrieveStructure(True)
        GridMultiproducto.GroupByBoxVisible = False
        GridMultiproducto.RootTable.Columns("ID").Visible = False
        GridMultiproducto.RootTable.Columns("PROClave").Visible = False
        GridMultiproducto.RootTable.Columns("iEstado").Visible = False
        GridMultiproducto.CurrentTable.Columns(1).Selectable = False
        GridMultiproducto.RootTable.Columns("Update").Visible = False
        GridMultiproducto.RootTable.Columns("Baja").Visible = False
        GridMultiproducto.RootTable.Columns("TProducto").Visible = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridMultiproducto.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridMultiproducto.RootTable.FormatConditions.Add(fc)

        GridEquivalentes.DataSource = dtEquivalentes
        GridEquivalentes.RetrieveStructure(True)
        GridEquivalentes.GroupByBoxVisible = False
        GridEquivalentes.RootTable.Columns("ID").Visible = False
        GridEquivalentes.RootTable.Columns("Update").Visible = False
        GridEquivalentes.RootTable.Columns("Baja").Visible = False

        Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
        fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridEquivalentes.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc1.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc1.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridEquivalentes.RootTable.FormatConditions.Add(fc1)


        GridAplicacion.DataSource = dtAplicaciones
        GridAplicacion.RetrieveStructure(True)
        GridAplicacion.GroupByBoxVisible = False
        GridAplicacion.RootTable.Columns("ID").Visible = False
        GridAplicacion.RootTable.Columns("Update").Visible = False
        GridAplicacion.RootTable.Columns("Baja").Visible = False

        Dim fc3 As Janus.Windows.GridEX.GridEXFormatCondition
        fc3 = New Janus.Windows.GridEX.GridEXFormatCondition(GridAplicacion.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc3.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc3.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridAplicacion.RootTable.FormatConditions.Add(fc3)



        gridRetencion.DataSource = dtRetenciones
        gridRetencion.RetrieveStructure(True)
        gridRetencion.GroupByBoxVisible = False
        gridRetencion.RootTable.Columns("IMPClave").Visible = False
        gridRetencion.RootTable.Columns("Update").Visible = False
        gridRetencion.RootTable.Columns("Baja").Visible = False

        Dim fc4 As Janus.Windows.GridEX.GridEXFormatCondition
        fc4 = New Janus.Windows.GridEX.GridEXFormatCondition(gridRetencion.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc4.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc4.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        gridRetencion.RootTable.FormatConditions.Add(fc4)


        If Not dtImpuestoProd Is Nothing Then
            Dim y, x As Integer
            Dim fila As String
            For y = 0 To dtImpuesto.Rows.Count - 1
                For x = 0 To dtImpuestoProd.Rows.Count - 1
                    fila = dtImpuesto.Rows(y)("IMPClave")
                    If fila = dtImpuestoProd.Rows(x)("IMPClave") Then
                        dtImpuesto.Rows(y)("Marca") = True
                    Else
                        dtImpuesto.Rows(y)("Marca") = False
                    End If
                Next
            Next
        End If


    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Dim foundRows() As DataRow
            Dim z As Integer

            ' Valida IEPS
            foundRows = dtImpuesto.Select("Marca=True and Tipo='IEPS'")

            If foundRows.GetLength(0) > 0 Then
                foundRows = dtImpuesto.Select("Marca=True and Tipo='IVA'")
                If foundRows.GetLength(0) = 0 Then
                    Beep()
                    MessageBox.Show("¡Debe especificar un impuesto de tipo IVA!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            End If



            foundRows = dtUnidades.Select("Factor = 1")

            If foundRows.GetLength(0) = 0 Then
                Beep()
                MessageBox.Show("¡No se ha declarado unidad con Factor igual a 1!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Exit Sub
            End If

            Select Case Me.Padre
                Case "Agregar"
                    Try

                        Clave = Me.TxtClave.Text.ToUpper.Trim
                        NumParte = TxtNumParte.Text.ToUpper.Trim
                        Nombre = Me.TxtNombre.Text.ToUpper.Trim
                        Descripcion = Me.TxtDescripcion.Text.ToUpper.Trim
                        Nota = TxtNota.Text.ToUpper.Trim
                        Tipo = Me.CmbTipo.SelectedValue
                        TCompra = Me.CmbCompra.SelectedValue
                        Origen = txtOrigen.Text
                        Aduana = txtAduana.Text
                        TRotacion = IIf(CmbRotacion.SelectedValue Is Nothing, 0, CmbRotacion.SelectedValue)
                        Seguimiento = CmbSeguimiento.SelectedValue
                        DiasGarantia = IIf(TxtDiasGarantia.Text = "", 0, Math.Abs(CInt(TxtDiasGarantia.Text)))
                        Minimo = IIf(NumMinimo.Text = "", 0, Math.Abs(CDbl(NumMinimo.Text)))
                        Reorden = IIf(NumReorden.Text = "", 0, Math.Abs(CDbl(NumReorden.Text)))
                        Maximo = IIf(NumMaximo.Text = "", 0, Math.Abs(CDbl(NumMaximo.Text)))
                        NumDecimales = NumDec.Value
                        CMIClave = CmbTipoComision.SelectedValue
                        Fecha = CmbFecha.Value

                        KgLt = ChkKgLt.GetEstado
                        Escala = ChkEscala.GetEstado
                        Alterno1 = TxtAlterno1.Text.ToUpper.Trim
                        Alterno2 = TxtAlterno2.Text.ToUpper.Trim
                        Alterno3 = TxtAlterno3.Text.ToUpper.Trim
                        Pedimento = TxtPedimento.Text.ToUpper.Trim

                        TImpuesto = cmbTipoImpuesto.SelectedValue
                        Costo = CDbl(TxtCost.Text)
                        ClaveSAT = TxtClaveSAT.Text.ToUpper.Trim

                        vtaPaquete = ChkPaquete.Checked
                        Preventa = ChkPreventa.Checked

                        If TallaColor = 1 Then
                            Modelo = txtModelo.Text
                            Talla = cmbTalla.SelectedValue
                            Color = cmbColor.SelectedValue
                        End If

                        noFacturable = chkNoFacturable.Checked

                        ModPOS.Ejecuta("sp_inserta_producto", _
                        "@PROClave", PROClave, _
                        "@Clave", Clave, _
                        "@NumParte", NumParte, _
                        "@Alterno1", Alterno1, _
                        "@Alterno2", Alterno2, _
                        "@Alterno3", Alterno3, _
                        "@Nombre", Nombre, _
                        "@Descripcion", Descripcion, _
                        "@Tipo", Tipo, _
                        "@TCompra", TCompra, _
                        "@TImpuesto", TImpuesto, _
                        "@TRotacion", TRotacion, _
                        "@Costo", Costo, _
                        "@Seguimiento", Seguimiento, _
                        "@DiasGarantia", DiasGarantia, _
                        "@Minimo", Minimo, _
                        "@Maximo", Maximo, _
                        "@Reorden", Reorden, _
                        "@NumDecimales", NumDecimales, _
                        "@CMIClave", CMIClave, _
                        "@Nota", Nota, _
                        "@Origen", Origen, _
                        "@Aduana", Aduana, _
                        "@Pedimento", Pedimento, _
                        "@Fecha", Fecha, _
                        "@Escala", Escala, _
                        "@KgLt", KgLt, _
                        "@ClaveSAT", ClaveSAT, _
                        "@Modelo", Modelo, _
                        "@Talla", Talla, _
                        "@Color", Color, _
                        "@noFacturable", noFacturable, _
                         "@vtaPaquete", vtaPaquete, _
                        "@Preventa", Preventa, _
                        "@Usuario", ModPOS.UsuarioActual, _
                        "@COMClave", ModPOS.CompanyActual)


                        'Clasificaciones

                        foundRows = dtClasificaciones.Select(" Update = 1 and Baja = 0 ")
                        If foundRows.Length <> 0 Then
                            'inserta clasprod
                            For z = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("sp_inserta_clasprod", "@Tipo", 3, "@Class", foundRows(z)("CLAClave"), "@Producto", PROClave, "@Usuario", ModPOS.UsuarioActual)
                            Next
                        End If


                        'Impuesto

                        foundRows = dtImpuesto.Select("Marca=True")

                        If foundRows.GetLength(0) > 0 Then
                            Dim sIMPClave As String
                            For z = 0 To foundRows.GetUpperBound(0)
                                sIMPClave = foundRows(z)("IMPClave")
                                ModPOS.Ejecuta("sp_inserta_impprod", "@IMPClave", sIMPClave, "@Producto", PROClave, "@Usuario", ModPOS.UsuarioActual)
                            Next
                        End If

                        'Sucursal producto

                        Dim dtSucursal As DataTable

                        dtSucursal = ModPOS.Recupera_Tabla("sp_muestra_sucursales", "@COMClave", ModPOS.CompanyActual)

                        dtSucursal = SelectDistinc("Sucursal", dtSucursal, "SUCClave")

                        For z = 0 To dtSucursal.Rows.Count - 1
                            ModPOS.Ejecuta("sp_inserta_sucursalproducto", _
                                                 "@SUCClave", dtSucursal.Rows(z)("SUCClave"), _
                                                 "@PROClave", PROClave, _
                                                 "@Costo", Math.Abs(CDbl(TxtCost.Text)), _
                                                 "@Rotacion", TRotacion, _
                                                 "@Minimo", Minimo, _
                                                 "@Maximo", Maximo, _
                                                 "@Reorden", Reorden, _
                                                 "@TipoImpuesto", TImpuesto, _
                                                 "@Preventa", Preventa, _
                                                 "@vtaPaquete", vtaPaquete, _
                                                 "@Usuario", ModPOS.UsuarioActual)

                        Next


                        'Unidades
                        If dtUnidades.Rows.Count > 0 Then
                            Dim i As Integer
                            For i = 0 To dtUnidades.Rows.Count - 1
                                ModPOS.Ejecuta("sp_inserta_productounidad", _
                              "@UNDClave", dtUnidades.Rows(i)("ID"), _
                                                      "@PROClave", PROClave, _
                                                      "@GTIN", dtUnidades.Rows(i)("Barras"), _
                                                      "@Factor", dtUnidades.Rows(i)("Factor"), _
                                                      "@Peso", IIf(dtUnidades.Rows(i)("Peso").GetType.Name = "DBNull", 0, dtUnidades.Rows(i)("Peso")), _
                                                      "@Volumen", IIf(dtUnidades.Rows(i)("Volumen").GetType.Name = "DBNull", 0, dtUnidades.Rows(i)("Volumen")), _
                                                      "@Tipo", IIf(dtUnidades.Rows(i)("Uso").GetType.Name = "DBNull", 1, dtUnidades.Rows(i)("Uso")), _
                                                      "@Alto", IIf(dtUnidades.Rows(i)("Alto").GetType.Name = "DBNull", 0, dtUnidades.Rows(i)("Alto")), _
                                                      "@Largo", IIf(dtUnidades.Rows(i)("Largo").GetType.Name = "DBNull", 0, dtUnidades.Rows(i)("Largo")), _
                                                      "@Ancho", IIf(dtUnidades.Rows(i)("Ancho").GetType.Name = "DBNull", 0, dtUnidades.Rows(i)("Ancho")), _
                                                      "@Usuario", ModPOS.UsuarioActual)
                            Next
                        End If


                        'Si es un multiproducto

                        If Tipo = 3 OrElse Tipo = 5 Then
                            foundRows = dtMultiproducto.Select(" Update = 1 and Baja = 0 ")
                            If foundRows.Length <> 0 Then
                                'inserta metodos de pago
                                For z = 0 To foundRows.GetUpperBound(0)
                                    ModPOS.Ejecuta("sp_inserta_proddet", _
                                    "@MLTClave", foundRows(z)("ID"), _
                                    "@PROClavePadre", PROClave, _
                                    "@PROClave", foundRows(z)("PROClave"), _
                                    "@CantidadUnidades", foundRows(z)("Cantidad"), _
                                    "@Estado", foundRows(z)("iEstado"), _
                                    "@Usuario", ModPOS.UsuarioActual)
                                Next
                            End If
                        End If

                        'Si es Aplicacion Automotriz

                        If ModPOS.AplicacionAutomotriz = 1 Then
                            foundRows = dtAplicaciones.Select(" Update = 1 and Baja = 0 ")
                            If foundRows.Length <> 0 Then
                                'inserta metodos de pago
                                For z = 0 To foundRows.GetUpperBound(0)
                                    ModPOS.Ejecuta("sp_inserta_aplicacion", _
                                    "@APLClave", foundRows(z)("ID"), _
                                    "@PROClave", PROClave, _
                                    "@Marca", foundRows(z)("Marca"), _
                                    "@Modelo", foundRows(z)("Modelo"), _
                                    "@Año", foundRows(z)("Año"), _
                                    "@Hasta", foundRows(z)("Hasta"), _
                                    "@Usuario", ModPOS.UsuarioActual)
                                Next
                            End If
                        End If

                        'Retenciones

                        foundRows = dtRetenciones.Select(" Update = 1 and Baja = 0 ")
                        If foundRows.Length <> 0 Then
                            'inserta metodos de pago
                            For z = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("st_inserta_retencion", _
                                "@IMPClave", foundRows(z)("IMPClave"), _
                                "@PROClave", PROClave, _
                                "@Tasa", foundRows(z)("Tasa"), _
                                "@Usuario", ModPOS.UsuarioActual)
                            Next
                        End If

                        'Equivalentes

                        foundRows = dtEquivalentes.Select(" Update = 1 and Baja = 0 ")

                        If foundRows.Length <> 0 Then
                            'inserta metodos de pago
                            For z = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("sp_inserta_equivalente", _
                                "@PROClave", Me.PROClave, _
                                "@ProductoEquivalente", foundRows(z)("ID"), _
                                "@Usuario", ModPOS.UsuarioActual)
                            Next
                        End If

                        'Agrega producto a listas de precio

                        Dim dtPrecios As DataTable = ModPOS.Recupera_Tabla("sp_recupera_litaprecios", "@COMClave", ModPOS.CompanyActual)
                        If dtPrecios.Rows.Count > 0 Then
                            For z = 0 To dtPrecios.Rows.Count - 1
                                ModPOS.Ejecuta("sp_agrega_vigencia", _
                                             "@PREClave", dtPrecios.Rows(z)("PREClave"), _
                                             "@PROClave", PROClave, _
                                             "@Inicio", Today.Date, _
                                             "@Precio", Costo * dtPrecios.Rows(z)("Utilidad"), _
                                             "@Minimo", Costo * dtPrecios.Rows(z)("Utilidad"), _
                                             "@Usuario", ModPOS.UsuarioActual)
                            Next
                        End If

                        'Actualización 18 de Junio 2007 graba registro en existencia.

                        Dim fila As Integer

                        Dim dtalm, dtubc As DataTable


                        dtalm = ModPOS.Recupera_Tabla("st_muestra_almacenes", "@COMClave", ModPOS.CompanyActual)
                        If Not dtalm Is Nothing AndAlso dtalm.Rows.Count > 0 Then
                            For fila = 0 To dtalm.Rows.Count - 1
                                If dtalm.Rows(fila)("ALMClave").GetType.Name <> "DBNull" Then
                                    dtubc = ModPOS.Recupera_Tabla("sp_ubc_inicial", "@ALMClave", dtalm.Rows(fila)("ALMClave"), "@PROClave", PROClave)
                                    If Not dtubc Is Nothing AndAlso dtubc.Rows.Count > 0 Then
                                        If dtubc.Rows(0)("UBCClave").GetType.Name <> "DBNull" Then
                                            ModPOS.Ejecuta("sp_ingreso_ubc", "@PROClave", PROClave, "@UBCClave", dtubc.Rows(0)("UBCClave"), "@Cantidad", 0, "@Usuario", ModPOS.UsuarioActual)
                                        End If
                                        dtubc.Dispose()
                                    End If
                                End If
                            Next
                            dtalm.Dispose()
                        End If

                        ModPOS.Ejecuta("sp_inserta_existencia", _
                       "@PROClave", Me.PROClave, _
                       "@Usuario", ModPOS.UsuarioActual)


                        If PicLoad = True Then
                            Dim i As Integer
                            PicProducto.Image = Nothing
                            PicProducto.Dispose()
                            For i = 0 To Imagenes.Length - 1
                                If Imagenes(i) IsNot Nothing Then
                                    If Imagenes(i).Estado = 1 Then
                                        Try
                                            Imagenes(i).Image = Nothing
                                            If System.IO.File.Exists(Application.StartupPath & "\Temp\" & Imagenes(i).NombreImagen) Then
                                                My.Computer.FileSystem.MoveFile(Application.StartupPath & "\Temp\" & Imagenes(i).NombreImagen, url_imagen & Imagenes(i).NombreImagen, True)
                                                ModPOS.Ejecuta("sp_inserta_imagen", "@PROClave", PROClave, "@IMGClave", Imagenes(i).IMGClave, "@Imagen", Imagenes(i).NombreImagen, "@Usuario", ModPOS.UsuarioActual)
                                            End If
                                        Catch ex As Exception
                                            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                                        End Try
                                    End If
                                End If
                            Next
                        End If


                        If FromForm = "Compra" Then
                            If Not ModPOS.Compras Is Nothing Then
                                ModPOS.Compras.recuperaProducto(Clave)
                            End If
                            Me.Close()
                        ElseIf FromForm = "Orden" Then
                            If Not ModPOS.Orden Is Nothing Then
                                ModPOS.Orden.recuperaProducto(Clave)
                            End If
                            Me.Close()
                        Else
                            Me.Reinicializa()
                        End If


                    Catch ex As Exception
                        ModPOS.Ejecuta("sp_deshacer_altaprod", "@PROClave", PROClave)
                    End Try

                Case "Modificar"
                    Dim mTallaColor As Boolean = True

                    If TallaColor = 1 Then
                        mTallaColor = (Modelo = txtModelo.Text AndAlso Talla = cmbTalla.SelectedValue AndAlso Color = cmbColor.SelectedValue)
                    End If

                    If Not ( _
                    Clave = Me.TxtClave.Text.Trim.ToUpper AndAlso _
                    NumParte = Me.TxtNumParte.Text.ToUpper.Trim AndAlso _
                    Nombre = Me.TxtNombre.Text.ToUpper.Trim AndAlso _
                    Descripcion = Me.TxtDescripcion.Text.ToUpper.Trim AndAlso _
                    Tipo = Me.CmbTipo.SelectedValue AndAlso _
                    TCompra = Me.CmbCompra.SelectedValue AndAlso _
                    Fecha = CmbFecha.Value AndAlso _
                    Origen = txtOrigen.Text AndAlso _
                    Aduana = txtAduana.Text AndAlso _
                    TRotacion = IIf(CmbRotacion.SelectedValue Is Nothing, 0, CmbRotacion.SelectedValue) AndAlso _
                    Costo = Math.Abs(CDbl(TxtCost.Text)) AndAlso _
                    Seguimiento = CmbSeguimiento.SelectedValue AndAlso _
                    DiasGarantia = Math.Abs(CInt(TxtDiasGarantia.Text)) AndAlso _
                    Minimo = Math.Abs(CDbl(NumMinimo.Text)) AndAlso _
                    Reorden = Math.Abs(CDbl(NumReorden.Text)) AndAlso _
                    Maximo = Math.Abs(CDbl(NumMaximo.Text)) AndAlso _
                    NumDecimales = NumDec.Value AndAlso _
                    Estado = Me.ChkEstado.GetEstado AndAlso _
                    CmbTipoComision.SelectedValue = CMIClave AndAlso _
                    ActualizaCosto = False AndAlso _
                    Nota = TxtNota.Text.ToUpper.Trim AndAlso _
                    Escala = ChkEscala.GetEstado AndAlso _
                    KgLt = ChkKgLt.GetEstado AndAlso _
                    Alterno1 = TxtAlterno1.Text.ToUpper.Trim AndAlso _
                    Alterno2 = TxtAlterno2.Text.ToUpper.Trim AndAlso _
                    Alterno3 = TxtAlterno3.Text.ToUpper.Trim AndAlso _
                    Pedimento = TxtPedimento.Text.ToUpper.Trim AndAlso _
                    ActualizaNeto = False AndAlso _
                    TImpuesto = cmbTipoImpuesto.SelectedValue AndAlso _
                    ClaveSAT = TxtClaveSAT.Text.ToUpper.Trim AndAlso _
                    mTallaColor AndAlso _
                    noFacturable = chkNoFacturable.Checked AndAlso _
                    vtaPaquete = ChkPaquete.Checked AndAlso _
                    Preventa = ChkPreventa.Checked AndAlso _
                    Costo = CDbl(TxtCost.Text)) Then

                        Clave = Me.TxtClave.Text.Trim.ToUpper
                        Nombre = Me.TxtNombre.Text.ToUpper.Trim
                        NumParte = Me.TxtNumParte.Text.ToUpper.Trim
                        Descripcion = Me.TxtDescripcion.Text.ToUpper.Trim
                        Tipo = Me.CmbTipo.SelectedValue
                        TCompra = Me.CmbCompra.SelectedValue
                        Fecha = CmbFecha.Value
                        Origen = txtOrigen.Text
                        Aduana = txtAduana.Text
                        Estado = Me.ChkEstado.GetEstado
                        TRotacion = IIf(CmbRotacion.SelectedValue Is Nothing, 0, CmbRotacion.SelectedValue)
                        Seguimiento = CmbSeguimiento.SelectedValue
                        DiasGarantia = IIf(TxtDiasGarantia.Text = "", 0, Math.Abs(CInt(TxtDiasGarantia.Text)))
                        Minimo = IIf(NumMinimo.Text = "", 0, Math.Abs(CDbl(NumMinimo.Text)))
                        Reorden = IIf(NumReorden.Text = "", 0, Math.Abs(CDbl(NumReorden.Text)))
                        Maximo = IIf(NumMaximo.Text = "", 0, Math.Abs(CDbl(NumMaximo.Text)))
                        NumDecimales = NumDec.Value
                        CMIClave = CmbTipoComision.SelectedValue
                        Nota = TxtNota.Text.ToUpper.Trim
                        ClaveSAT = TxtClaveSAT.Text.ToUpper.Trim

                        KgLt = ChkKgLt.GetEstado
                        Escala = ChkEscala.GetEstado
                        Alterno1 = TxtAlterno1.Text.ToUpper.Trim
                        Alterno2 = TxtAlterno2.Text.ToUpper.Trim
                        Alterno3 = TxtAlterno3.Text.ToUpper.Trim
                        Pedimento = TxtPedimento.Text.ToUpper.Trim

                        TImpuesto = cmbTipoImpuesto.SelectedValue
                        Costo = CDbl(TxtCost.Text)

                        If TallaColor = 1 Then
                            Modelo = txtModelo.Text
                            Talla = cmbTalla.SelectedValue
                            Color = cmbColor.SelectedValue
                        End If

                        noFacturable = chkNoFacturable.Checked

                        vtaPaquete = ChkPaquete.Checked
                        Preventa = ChkPreventa.Checked


                        ModPOS.Ejecuta("sp_modifica_producto", _
                        "@PROClave", PROClave, _
                        "@Clave", Clave, _
                        "@NumParte", NumParte, _
                        "@Alterno1", Alterno1, _
                        "@Alterno2", Alterno2, _
                        "@Alterno3", Alterno3, _
                        "@Nombre", Nombre, _
                        "@Descripcion", Descripcion, _
                        "@Tipo", Tipo, _
                        "@TCompra", TCompra, _
                        "@TRotacion", TRotacion, _
                         "@TImpuesto", TImpuesto, _
                         "@Costo", Costo, _
                        "@Estado", Estado, _
                        "@Seguimiento", Seguimiento, _
                        "@DiasGarantia", DiasGarantia, _
                        "@Minimo", Minimo, _
                        "@Maximo", Maximo, _
                        "@Reorden", Reorden, _
                        "@NumDecimales", NumDecimales, _
                        "@CMIClave", CMIClave, _
                        "@Nota", Nota, _
                        "@Origen", Origen, _
                        "@Aduana", Aduana, _
                        "@Pedimento", Pedimento, _
                        "@Fecha", Fecha, _
                        "@Escala", Escala, _
                        "@KgLt", KgLt, _
                        "@ClaveSAT", ClaveSAT, _
                         "@Modelo", Modelo, _
                        "@Talla", Talla, _
                        "@Color", Color, _
                        "@noFacturable", noFacturable, _
                        "@vtaPaquete", vtaPaquete, _
                        "@Preventa", Preventa, _
                        "@Usuario", ModPOS.UsuarioActual, _
                        "@COMClave", ModPOS.CompanyActual)





                    End If

                    'Impuesto

                    ModPOS.Ejecuta("sp_elimina_impprod", "@Producto", PROClave)


                    foundRows = dtImpuesto.Select("Marca=True")

                    If foundRows.GetLength(0) > 0 Then
                        Dim sIMPClave As String
                        For z = 0 To foundRows.GetUpperBound(0)
                            sIMPClave = foundRows(z)("IMPClave")
                            ModPOS.Ejecuta("sp_inserta_impprod", "@IMPClave", sIMPClave, "@Producto", PROClave, "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    'Clasificaciones

                    foundRows = dtClasificaciones.Select(" Update = 1 and  Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta clasprod
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_clasprod", "@Tipo", 3, "@Class", foundRows(z)("CLAClave"), "@Producto", PROClave, "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If



                    foundRows = dtClasificaciones.Select(" Baja = 1 ")
                    If foundRows.Length <> 0 Then
                        'inserta clasprod
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_clasprod", "@Tipo", 3, "@Class", foundRows(z)("CLAClave"), "@Producto", PROClave)

                        Next
                    End If


                    'Unidades
                    If ActualizaUnidad AndAlso dtUnidades.Rows.Count > 0 Then

                        ModPOS.Ejecuta("sp_elimina_productounidad", "@PROClave", PROClave)

                        Dim i As Integer
                        For i = 0 To dtUnidades.Rows.Count - 1
                            ModPOS.Ejecuta("sp_inserta_productounidad", _
                          "@UNDClave", dtUnidades.Rows(i)("ID"), _
                                                  "@PROClave", PROClave, _
                                                  "@GTIN", dtUnidades.Rows(i)("Barras"), _
                                                  "@Factor", dtUnidades.Rows(i)("Factor"), _
                                                  "@Peso", IIf(dtUnidades.Rows(i)("Peso").GetType.Name = "DBNull", 0, dtUnidades.Rows(i)("Peso")), _
                                                  "@Volumen", IIf(dtUnidades.Rows(i)("Volumen").GetType.Name = "DBNull", 0, dtUnidades.Rows(i)("Volumen")), _
                                                   "@Tipo", IIf(dtUnidades.Rows(i)("Uso").GetType.Name = "DBNull", 1, dtUnidades.Rows(i)("Uso")), _
                                                  "@Alto", IIf(dtUnidades.Rows(i)("Alto").GetType.Name = "DBNull", 0, dtUnidades.Rows(i)("Alto")), _
                                                  "@Largo", IIf(dtUnidades.Rows(i)("Largo").GetType.Name = "DBNull", 0, dtUnidades.Rows(i)("Largo")), _
                                                  "@Ancho", IIf(dtUnidades.Rows(i)("Ancho").GetType.Name = "DBNull", 0, dtUnidades.Rows(i)("Ancho")), _
                                                  "@Usuario", ModPOS.UsuarioActual)
                        Next
                        ActualizaUnidad = False
                    End If


                    'Si es un multiproducto


                    If Tipo = 3 OrElse Tipo = 5 Then

                        foundRows = dtMultiproducto.Select(" Baja = 1 ")

                        If foundRows.Length <> 0 Then

                            For z = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("sp_elimina_proddet", "@MLTClave", foundRows(z)("ID"), "@Usuario", ModPOS.UsuarioActual)
                            Next
                        End If

                        foundRows = dtMultiproducto.Select(" Update = 1 and Baja = 0 ")
                        If foundRows.Length <> 0 Then
                            For z = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("sp_actualiza_proddet", _
                                "@MLTClave", foundRows(z)("ID"), _
                                "@PROClavePadre", PROClave, _
                                "@PROClave", foundRows(z)("PROClave"), _
                                "@CantidadUnidades", foundRows(z)("Cantidad"), _
                                "@Estado", foundRows(z)("iEstado"), _
                                "@Usuario", ModPOS.UsuarioActual)
                            Next
                        End If
                    End If


                    'Si es Aplicacion

                    If ModPOS.AplicacionAutomotriz = 1 Then

                        foundRows = dtAplicaciones.Select(" Baja = 1 ")

                        If foundRows.Length <> 0 Then

                            For z = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("sp_elimina_aplicacion", "@APLClave", foundRows(z)("ID"))
                            Next
                        End If



                        foundRows = dtAplicaciones.Select(" Update = 1 and Baja = 0 ")
                        If foundRows.Length <> 0 Then
                            'inserta metodos de pago
                            For z = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("sp_inserta_aplicacion", _
                                     "@APLClave", foundRows(z)("ID"), _
                                     "@PROClave", PROClave, _
                                     "@Marca", foundRows(z)("Marca"), _
                                     "@Modelo", foundRows(z)("Modelo"), _
                                     "@Año", foundRows(z)("Año"), _
                                     "@Hasta", foundRows(z)("Hasta"), _
                                     "@Usuario", ModPOS.UsuarioActual)
                            Next
                        End If
                    End If


                    'Retenciones

                    foundRows = dtRetenciones.Select(" Baja = 1 ")

                    If foundRows.Length <> 0 Then

                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("st_elimina_retencion", "@IMPClave", foundRows(z)("IMPClave"), "@PROClave", PROClave)
                        Next
                    End If


                    foundRows = dtRetenciones.Select(" Update = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("st_inserta_retencion", _
                            "@IMPClave", foundRows(z)("IMPClave"), _
                            "@PROClave", PROClave, _
                            "@Tasa", foundRows(z)("Tasa"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    'Equivalentes

                    foundRows = dtEquivalentes.Select(" Baja = 1 ")

                    If foundRows.Length <> 0 Then

                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_productoequivalente", "@PROClave", Me.PROClave, "@Equivalente", foundRows(z)("ID"))
                        Next
                    End If


                    foundRows = dtEquivalentes.Select(" Update = 1 and Baja = 0 ")

                    If foundRows.Length <> 0 Then

                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_equivalente", _
                            "@PROClave", Me.PROClave, _
                            "@ProductoEquivalente", foundRows(z)("ID"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If



                    If PicLoad = True Then
                        Dim i As Integer
                        PicProducto.Image = Nothing
                        PicProducto.Dispose()
                        For i = 0 To Imagenes.Length - 1
                            If Imagenes(i) IsNot Nothing Then
                                If Imagenes(i).Nuevo = True Then
                                    If Imagenes(i).Estado = 1 Then

                                        Try
                                            Imagenes(i).Image = Nothing
                                            If System.IO.File.Exists(Application.StartupPath & "\Temp\" & Imagenes(i).NombreImagen) Then
                                                My.Computer.FileSystem.MoveFile(Application.StartupPath & "\Temp\" & Imagenes(i).NombreImagen, url_imagen & Imagenes(i).NombreImagen, True)
                                                ModPOS.Ejecuta("sp_inserta_imagen", "@PROClave", PROClave, "@IMGClave", Imagenes(i).IMGClave, "@Imagen", Imagenes(i).NombreImagen, "@Usuario", ModPOS.UsuarioActual)
                                            End If
                                        Catch ex As Exception
                                            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                                        End Try
                                    End If
                                Else
                                    If Imagenes(i).Estado = 2 Then
                                        Try
                                            Imagenes(i).Image = Nothing
                                            If System.IO.File.Exists(Application.StartupPath & "\Temp\" & Imagenes(i).NombreImagen) Then
                                                My.Computer.FileSystem.MoveFile(Application.StartupPath & "\Temp\" & Imagenes(i).NombreImagen, url_imagen & Imagenes(i).NombreImagen, True)
                                                ModPOS.Ejecuta("sp_actualiza_imagen", "@PROClave", PROClave, "@IMGClave", Imagenes(i).IMGClave, "@Imagen", Imagenes(i).NombreImagen, "@Usuario", ModPOS.UsuarioActual)
                                            End If
                                        Catch ex As Exception
                                            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                                        End Try
                                    ElseIf Imagenes(i).Estado = 0 Then
                                        Try
                                            Imagenes(i).Image = Nothing
                                            If System.IO.File.Exists((url_imagen & Imagenes(i).NombreImagen)) Then
                                                My.Computer.FileSystem.DeleteFile(url_imagen & Imagenes(i).NombreImagen, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

                                            End If
                                            If System.IO.File.Exists(Application.StartupPath & "\Temp\" & Imagenes(i).NombreImagen) Then
                                                My.Computer.FileSystem.DeleteFile(Application.StartupPath & "\Temp\" & Imagenes(i).NombreImagen, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                                            End If
                                            ModPOS.Ejecuta("sp_remueve_imagen", "@PROClave", PROClave, "@IMGClave", Imagenes(i).IMGClave, "@Usuario", ModPOS.UsuarioActual)

                                        Catch ex As Exception
                                            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                                        End Try
                                    End If
                                End If
                            End If
                        Next
                    End If

                    If bIngreso = True Then
                        If Not ModPOS.Entrada Is Nothing Then
                            ModPOS.Entrada.leeCodigoBarras(Clave)
                        End If
                    End If
                    Me.Close()
            End Select
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmProducto_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        PicProducto.Image = Nothing
        ModPOS.Producto.Dispose()
        ModPOS.Producto = Nothing

        If Not ModPOS.MtoProductos Is Nothing Then
            If Padre = "Agregar" Then
                ModPOS.MtoProductos.actualizaTree(IIf(ModPOS.MtoProductos.cmbGrupo.SelectedValue Is Nothing, 0, ModPOS.MtoProductos.cmbGrupo.SelectedValue))

            End If
        End If

    End Sub

    Private Sub UiTab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs) Handles UiTab1.SelectedTabChanged
        Select Case e.Page.Name
            Case "UiTabCosto"

                ModPOS.ActualizaGrid(False, GridPrv, "sp_muestra_prvpro", "@PROClave", PROClave)

                'Case "UiTabKits"
                '    If Padre = "Modificar" AndAlso CmbTipo.SelectedIndex = 2 Then
                '        ModPOS.ActualizaGrid(True, Me.GridMultiproducto, "sp_muestra_multiproductos", "@ProductoPadre", PROClave)

                '        Me.GridMultiproducto.RootTable.Columns("ID").Visible = False
                '    ElseIf CmbTipo.SelectedIndex = 2 Then
                '        BtnModProd.Enabled = False
                '    End If

                'Case "UiTabEquivalentes"
                '    ModPOS.ActualizaGrid(False, GridEquivalentes, "sp_muestra_equivalentes", "@PROClave", PROClave)
                '    GridEquivalentes.RootTable.Columns("ID").Visible = False
        End Select

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

#End Region

#Region "Multiproducto"

    Public Sub AddMultiproducto(ByVal sPROClave As String, ByVal sClave As String, ByVal sNombre As String, ByVal sUnidad As String, ByVal dCantidad As Double, ByVal iEstado As Integer, ByVal sEstado As String, ByVal TProducto As Integer)

        Dim foundRows() As Data.DataRow
        foundRows = dtMultiproducto.Select("PROClave = '" & sPROClave & "' and Baja = 0 ")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = ModPOS.Producto.dtMultiproducto.NewRow()
            'declara el nombre de la fila
            row1.Item("ID") = ModPOS.obtenerLlave
            row1.Item("PROClave") = sPROClave
            row1.Item("Clave") = sClave
            row1.Item("Nombre") = sNombre
            row1.Item("Unidad") = sUnidad
            row1.Item("Cantidad") = dCantidad
            row1.Item("Estado") = sEstado
            row1.Item("iEstado") = iEstado
            row1.Item("Update") = 1
            row1.Item("Baja") = 0
            row1.Item("TProducto") = TProducto

            dtMultiproducto.Rows.Add(row1)
            'agrega la fila completo a la tabla
        Else
            foundRows(0)("Cantidad") = dCantidad
            foundRows(0)("Estado") = sEstado
            foundRows(0)("iEstado") = iEstado
            foundRows(0)("Update") = 1
        End If

    End Sub

    Public Sub modificarDet()
        If sMLTSelected <> "" Then
            If GridMultiproducto.GetValue("Baja") = 0 Then

                If ModPOS.ProdDet Is Nothing Then

                    ModPOS.ProdDet = New FrmProdDet
                    With ModPOS.ProdDet
                        .Text = "Modificar Producto de Multiempaque"
                        .StartPosition = FormStartPosition.CenterScreen
                        .Padre = "Modificar"

                        .PROClavePadre = PROClave
                        .MLTClave = GridMultiproducto.GetValue("ID")
                        .PROClave = GridMultiproducto.GetValue("PROClave")
                        .Clave = GridMultiproducto.GetValue("Clave")
                        .Nombre = GridMultiproducto.GetValue("Nombre")
                        .Unidad = GridMultiproducto.GetValue("Unidad")
                        .CantidadUnidades = GridMultiproducto.GetValue("Cantidad")
                        .Estado = GridMultiproducto.GetValue("iEstado")
                        .TProducto = GridMultiproducto.GetValue("TProducto")


                    End With
                End If
                ModPOS.ProdDet.TxtClave.ReadOnly = True
                ModPOS.ProdDet.BtnBusqueda.Enabled = False
                ModPOS.ProdDet.StartPosition = FormStartPosition.CenterScreen
                ModPOS.ProdDet.Show()
                ModPOS.ProdDet.BringToFront()
            End If
        End If
    End Sub

    Public Sub AddRetencion(ByVal sIMPClave As String, ByVal sDescricion As String, ByVal dTasa As Decimal)

        Dim foundRows() As Data.DataRow
        foundRows = dtRetenciones.Select("IMPClave = '" & sIMPClave & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = ModPOS.Producto.dtRetenciones.NewRow()
            'declara el nombre de la fila
            row1.Item("IMPClave") = sIMPClave
            row1.Item("Impuesto") = sDescricion
            row1.Item("Tasa") = dTasa
            row1.Item("Update") = 1
            row1.Item("Baja") = 0

            dtRetenciones.Rows.Add(row1)
            'agrega la fila completo a la tabla
        Else
            foundRows(0)("Tasa") = dTasa
            foundRows(0)("Update") = 1
        End If

    End Sub



    Public Sub AddAplicacion(ByVal sMarca As String, ByVal sModelo As String, ByVal iAño As Integer, ByVal iHasta As Integer)

        Dim foundRows() As Data.DataRow
        foundRows = dtAplicaciones.Select("Marca = '" & sMarca & "' and Modelo = '" & sModelo & "' and Año = " & iAño & " and Baja = 0 ")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = ModPOS.Producto.dtAplicaciones.NewRow()
            'declara el nombre de la fila
            row1.Item("ID") = ModPOS.obtenerLlave
            row1.Item("Marca") = sMarca
            row1.Item("Modelo") = sModelo
            row1.Item("Año") = iAño
            row1.Item("Hasta") = iHasta
            row1.Item("Update") = 1
            row1.Item("Baja") = 0

            dtAplicaciones.Rows.Add(row1)
            'agrega la fila completo a la tabla
        Else
            foundRows(0)("Hasta") = iHasta

            foundRows(0)("Update") = 1
        End If

    End Sub



#End Region
#Region "Clasificacion"

    Private Sub AddClasificaciones(ByVal iCLAClave As Integer, ByVal sGrupo As String, ByVal sReferencia As String, ByVal sNombre As String, ByVal iGrupo As Integer)

        Dim foundRows() As Data.DataRow
        foundRows = dtClasificaciones.Select("TGrupo = " & iGrupo & " and Baja = 0 ")

        If foundRows.Length = 0 Then

            Dim row1 As DataRow
            row1 = ModPOS.Producto.dtClasificaciones.NewRow()
            'declara el nombre de la fila
            row1.Item("CLAClave") = iCLAClave
            row1.Item("Grupo") = sGrupo
            row1.Item("Referencia") = sReferencia
            row1.Item("Nombre") = sNombre
            row1.Item("TGrupo") = iGrupo
            row1.Item("Update") = 1
            row1.Item("Baja") = 0

            dtClasificaciones.Rows.Add(row1)
            'agrega la fila completo a la tabla
        Else
            MessageBox.Show("El producto actual ya cuenta con una clasificación de Grupo igual al que desea agregar, elimine la anterior para poder agregar otra", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub recuperaClasificacion(ByVal Clase As Integer)
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_clase", "@Clase", Clase)

        Dim iGrupo As Integer
        Dim sGrupo As String

        iGrupo = IIf(dt.Rows(0)("TGrupo").GetType.Name = "DBNull", 0, dt.Rows(0)("TGrupo"))

        Dim dtGrupo As DataTable
        dtGrupo = ModPOS.Recupera_Tabla("sp_recupera_valor", "@Tabla", "Clasificacion", "@Campo", "Grupo", "@Valor", iGrupo)

        If dtGrupo.Rows.Count > 0 Then
            sGrupo = dtGrupo.Rows(0)("Descripcion")
        Else
            sGrupo = ""
        End If

        dtGrupo.Dispose()

        Me.AddClasificaciones(CInt(dt.Rows(0)("CLAClave")), sGrupo, dt.Rows(0)("Referencia"), dt.Rows(0)("Nombre"), iGrupo)

        dt.Dispose()




    End Sub


#End Region

#Region "Unidad de Venta"

    Private Sub BtnDelUnidad_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelUnidad.Click
        If GridUnidades.Row >= 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara del producto actual la unidad de venta :" & GridUnidades.GetValue("Unidad"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtUnidades.Select("Unidad Like '" & GridUnidades.GetValue("Unidad") & "'")

                    dtUnidades.Rows.Remove(foundRows(0))

                    If Padre = "Modificar" Then
                        ActualizaUnidad = True
                    End If
            End Select
        End If
    End Sub


#End Region

#Region "Producto Equivalente"



    Public Sub AddEquivalente(ByVal sPROClave As String, ByVal sClave As String, ByVal sNombre As String, ByVal sDescripcion As String)

        Dim foundRows() As Data.DataRow
        foundRows = dtEquivalentes.Select("ID = '" & sPROClave & "' and Baja = 0 ")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = ModPOS.Producto.dtEquivalentes.NewRow()
            'declara el nombre de la fila
            row1.Item("ID") = sPROClave
            row1.Item("Clave") = sClave
            row1.Item("Nombre") = sNombre
            row1.Item("Descripción") = sDescripcion
            row1.Item("Update") = 1
            row1.Item("Baja") = 0

            dtEquivalentes.Rows.Add(row1)
            'agrega la fila completo a la tabla
        End If

    End Sub

    Private Sub BtnAddEquivalente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddEquivalente.Click
        If ModPOS.ProductoEquivalente Is Nothing Then
            ModPOS.ProductoEquivalente = New FrmAddEquivalente
            With ModPOS.ProductoEquivalente
                .Text = "Agregar Productos Equivalentes"
                .StartPosition = FormStartPosition.CenterScreen
                .PROClave = Me.PROClave
            End With
        End If
        ModPOS.ProductoEquivalente.StartPosition = FormStartPosition.CenterScreen
        ModPOS.ProductoEquivalente.Show()
        ModPOS.ProductoEquivalente.BringToFront()

    End Sub

    Private Sub BtnDelEquivalente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelEquivalente.Click
        If sEquivalente <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara del producto actual el producto equivalente :" & sProductoEquivalente, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtEquivalentes.Select("ID = '" & sEquivalente & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If

            End Select
        End If

    End Sub

    Private Sub GridEquivalentes_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridEquivalentes.SelectionChanged
        If Not GridEquivalentes.GetValue(0) Is Nothing Then
            Me.BtnDelEquivalente.Enabled = True

            Me.sEquivalente = GridEquivalentes.GetValue(0)
            Me.sProductoEquivalente = GridEquivalentes.GetValue(2)
        Else
            Me.sEquivalente = ""
            Me.sProductoEquivalente = ""
            Me.BtnDelEquivalente.Enabled = False
        End If
    End Sub

#End Region


    Private Sub RecuperaImagenProducto(ByVal path As String)
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_imagenes", "@PROClave", PROClave)
        If dt.Rows.Count > 0 Then
            PicProducto.Image = ModPOS.RecuperaImagen(path & CStr(dt.Rows(0)("Imagen")))
        End If
        dt.Dispose()
    End Sub

    Private Sub Ctrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClave.KeyDown, TxtDescripcion.KeyDown, TxtNombre.KeyDown, TxtNumParte.KeyDown, UiTab1.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

            'If Not Me.GetNextControl(sender, True) Is Nothing Then Me.GetNextControl(sender, True).Focus()
        End If
    End Sub



    Public Sub AddUnidad(ByVal CodigoBarras As String, ByVal Factor As Integer, ByVal Tipo As String, ByVal Unidad As String, ByVal Volumen As Double, ByVal Alto As Double, ByVal Largo As Double, ByVal Ancho As Double, ByVal Uso As Integer, ByVal TipoUso As String, ByVal Peso As Double)
        If ModPOS.SiExite(ModPOS.BDConexion, "sp_valida_gtin", "@PROClave", PROClave, "@GTIN", CodigoBarras.ToUpper.Trim) = 0 Then

            Dim foundRows() As Data.DataRow
            foundRows = dtUnidades.Select("ID = '" & Tipo & "'")

            If foundRows.Length = 0 Then
                foundRows = dtUnidades.Select("Barras = '" & CodigoBarras.ToUpper.Trim & "'")
                If foundRows.Length = 0 Then
                    foundRows = dtUnidades.Select("Factor =" & CStr(Factor))
                    If foundRows.Length = 0 Then
                        Dim row1 As DataRow
                        row1 = dtUnidades.NewRow()
                        'declara el nombre de la fila

                        row1.Item("ID") = Tipo
                        row1.Item("Unidad") = Unidad
                        row1.Item("Factor") = Factor
                        row1.Item("EAN") = CodigoBarras.ToUpper.Trim
                        row1.Item("Barras") = CodigoBarras.ToUpper.Trim
                        row1.Item("Volumen") = Volumen
                        row1.Item("Alto") = Alto
                        row1.Item("Largo") = Largo
                        row1.Item("Ancho") = Ancho
                        row1.Item("Uso") = Uso
                        row1.Item("Tipo") = TipoUso
                        row1.Item("Peso") = Peso
                        dtUnidades.Rows.Add(row1)
                        'agrega la fila completo a la tabla

                        If Padre = "Modificar" Then
                            ActualizaUnidad = True
                        End If
                    Else
                        Beep()
                        MessageBox.Show("¡El Factor que intenta agregar ya existe para el producto actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                Else
                    Beep()
                    MessageBox.Show("¡El Código de Barras que intenta agregar ya existe para el producto actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Else
                Beep()
                MessageBox.Show("¡La Unidad de venta que intenta agregar ya existe para el producto actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else
            Beep()
            MessageBox.Show("¡El Código de Barras que intenta agregar ya existe en otro producto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Public Sub ActualizaImagenes(ByVal Array() As Foto)
        PicLoad = True
        Imagenes = Array

        Dim i As Integer
        For i = 0 To Imagenes.Length - 1
            If Imagenes(i) IsNot Nothing Then
                If Imagenes(i).Estado = 1 OrElse Imagenes(i).Estado = 2 Then
                    PicProducto.Image = Imagenes(i).Image
                    Exit For
                End If
            End If
        Next

    End Sub


    Private Sub GridUnidades_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridUnidades.CellEdited

        If GridUnidades.CurrentColumn.Caption = "Barras" Then

            If GridUnidades.GetValue("Barras") Is System.DBNull.Value Then
                GridUnidades.SetValue("Barras", GridUnidades.GetValue("EAN"))

            ElseIf ModPOS.SiExite(ModPOS.BDConexion, "sp_valida_gtin", "@PROClave", PROClave, "@GTIN", GridUnidades.GetValue("Barras")) = 0 Then
                Dim foundRows() As Data.DataRow
                foundRows = dtUnidades.Select("Barras Like '" & GridUnidades.GetValue("Barras") & "'")
                If foundRows.Length = 0 Then
                    GridUnidades.SetValue("EAN", GridUnidades.GetValue("Barras"))
                    If Padre = "Modificar" Then
                        ActualizaUnidad = True
                    End If
                Else
                    If GridUnidades.GetValue("EAN") <> GridUnidades.GetValue("Barras") Then
                        Beep()
                        MessageBox.Show("¡El Código de Barras que intenta agregar ya existe para el producto actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridUnidades.SetValue("Barras", GridUnidades.GetValue("EAN"))
                    End If
                End If
            Else
                Beep()
                MessageBox.Show("¡El Código de Barras que intenta agregar ya existe en otro producto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                GridUnidades.SetValue("Barras", GridUnidades.GetValue("EAN"))
            End If
        ElseIf GridUnidades.CurrentColumn.Caption = "Factor" Then
            If IsNumeric(GridUnidades.GetValue("Factor")) Then
                ActualizaUnidad = True
            Else
                GridUnidades.SetValue("Factor", 1)
            End If
        ElseIf GridUnidades.CurrentColumn.Caption = "Volumen" Then
            If IsNumeric(GridUnidades.GetValue("Volumen")) Then
                ActualizaUnidad = True
            Else
                GridUnidades.SetValue("Volumen", 1)
            End If
        ElseIf GridUnidades.CurrentColumn.Caption = "Alto" Then
            If IsNumeric(GridUnidades.GetValue("Alto")) Then
                ActualizaUnidad = True
            Else
                GridUnidades.SetValue("Alto", 1)
            End If
        ElseIf GridUnidades.CurrentColumn.Caption = "Largo" Then
            If IsNumeric(GridUnidades.GetValue("Largo")) Then
                ActualizaUnidad = True
            Else
                GridUnidades.SetValue("Largo", 1)
            End If
        ElseIf GridUnidades.CurrentColumn.Caption = "Ancho" Then
            If IsNumeric(GridUnidades.GetValue("Ancho")) Then
                ActualizaUnidad = True
            Else
                GridUnidades.SetValue("Ancho", 1)
            End If
        ElseIf GridUnidades.CurrentColumn.Caption = "Peso" Then
            If IsNumeric(GridUnidades.GetValue("Peso")) Then
                ActualizaUnidad = True
            Else
                GridUnidades.SetValue("Peso", 1)
            End If

        End If


    End Sub



    Private Sub BtnAddProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddProd.Click
        If ModPOS.ProdDet Is Nothing Then
            ModPOS.ProdDet = New FrmProdDet
            With ModPOS.ProdDet
                .Text = "Agregar Producto a Multiempaque"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .SubPadre = Padre
                .Estado = 1
                .ChkEstado.Enabled = True
                .PROClavePadre = Me.PROClave
            End With
        End If
        ModPOS.ProdDet.StartPosition = FormStartPosition.CenterScreen
        ModPOS.ProdDet.Show()
        ModPOS.ProdDet.BringToFront()

    End Sub

    Private Sub BtnModProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModProd.Click
        modificarDet()

    End Sub

    Private Sub BtnDelProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelProd.Click

        If Me.sMLTSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Producto: " & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtMultiproducto.Select("ID = '" & sMLTSelected & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If

                Case DialogResult.No

            End Select
        End If

    End Sub

    Private Sub GridMultiproducto_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridMultiproducto.DoubleClick
        Me.modificarDet()
    End Sub

    Private Sub GridMultiproducto_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridMultiproducto.SelectionChanged
        If Not GridMultiproducto.GetValue(0) Is Nothing Then
            Me.BtnModProd.Enabled = True
            Me.BtnDelProd.Enabled = True
            Me.sMLTSelected = GridMultiproducto.GetValue("ID")
            Me.sNombre = GridMultiproducto.GetValue("Clave")
        Else
            Me.sMLTSelected = ""
            Me.sNombre = ""
            Me.BtnModProd.Enabled = False
            Me.BtnDelProd.Enabled = False
        End If

    End Sub

    Private Sub CmbSeguimiento_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSeguimiento.SelectedValueChanged
        If Not CmbSeguimiento.SelectedValue Is Nothing AndAlso combosCargados Then
            If CmbSeguimiento.SelectedValue = 2 Then
                TxtDiasGarantia.Enabled = True
                TxtDiasGarantia.Text = "0"
            Else
                TxtDiasGarantia.Enabled = False
                TxtDiasGarantia.Text = "0"
            End If
        End If
    End Sub

    Private Sub BtnReemplazo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReemplazo.Click
        Dim a As New MeRemplazoClave
        a.Clave = Clave
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.TxtClave.Text = a.NuevaClave
        End If
        a.Dispose()
    End Sub

    Private Sub BtnKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKey.Click
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "Digitos", "@COMClave", ModPOS.CompanyActual)
        Dim len As Integer = CInt(dt.Rows(0)("Valor"))
        dt.Dispose()
        Dim CLAClave As Integer



        dt = ModPOS.Recupera_Tabla("sp_calcula_proclave", "@CLAClave", CLAClave, "@len", len, "@COMClave", ModPOS.CompanyActual)

        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                TxtClave.Text = dt.Rows(0)("Clave")
            Else
                MessageBox.Show("No fue posible sugerir Clave", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            dt.Dispose()
        Else
            MessageBox.Show("No fue posible sugerir Clave", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        TxtNombre.Focus()

    End Sub


    Private Sub BtnAddUnidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddUnidad.Click
        Dim a As New FrmAddUnidad
        a.Clave = TxtClave.Text
        a.ShowDialog()
    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtImpuesto.Rows.Count > 0 Then
            Dim i As Integer
            If ChkMarcaTodos.Checked Then
                For i = 0 To dtImpuesto.Rows.Count - 1
                    dtImpuesto.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dtImpuesto.Rows.Count - 1
                    dtImpuesto.Rows(i)("Marca") = False
                Next
            End If
        End If
    End Sub

    Private Sub PicProducto_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicProducto.DoubleClick
        Dim a As New FrmPicture
        a.ClaveProducto = TxtClave.Text
        a.NombreProducto = TxtNombre.Text
        a.url_imagen = url_imagen
        a.PROClave = Me.PROClave
        a.Padre = "Producto"
        a.ShowDialog()
        a.Dispose()

    End Sub

    Private Sub BtnCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As New FrmModCosto
        a.PROClave = PROClave
        a.Padre = Padre
        a.Costo = CDbl(TxtCost.Text)
        a.ShowDialog()
    End Sub

    Private Sub TxtNombre_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNombre.Leave
        If TxtNombre.Text <> "" Then
            TxtDescripcion.Text = TxtNombre.Text
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub GridImpuestos_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridImpuestos.CellValueChanged

        If GridImpuestos.Row = 0 Then
            GridImpuestos.MoveNext()
            GridImpuestos.MovePrevious()
        Else
            GridImpuestos.MovePrevious()
            GridImpuestos.MoveNext()
        End If

    End Sub

    Private Sub CmbTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbTipo.SelectedIndexChanged
        If Not CmbTipo.SelectedValue Is Nothing AndAlso IsNumeric(CmbTipo.SelectedValue) = True Then
            Select Case CInt(CmbTipo.SelectedValue)
                Case Is = 3
                    UiTabKits.TabVisible = True
                    UiTabRetencion.TabVisible = False
                Case Is = 4
                    UiTabRetencion.TabVisible = True
                Case Is = 5
                    UiTabKits.TabVisible = True
                    UiTabRetencion.TabVisible = False
                Case Else
                    UiTabKits.TabVisible = False
                    UiTabRetencion.TabVisible = False

            End Select
        End If
    End Sub

    Private Sub GridUnidades_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridUnidades.SelectionChanged
        If Not GridUnidades.GetValue(0) Is Nothing Then
            Me.BtnDelUnidad.Enabled = True

            Me.sUnidad = GridUnidades.GetValue(0)
            Me.sUnidadNombre = GridUnidades.GetValue(2)
        Else
            Me.sUnidad = ""
            Me.sUnidadNombre = ""
            Me.BtnDelUnidad.Enabled = False
        End If

    End Sub

    Private Sub BtnBuscaClasificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaClasificacion.Click
        Dim a As New MeSearchSimple
        ModPOS.ActualizaGrid(False, a.GridSearch, "sp_filtra_clasificacion", "@TClasificacion", 3, "@TGrupo", 0, "@COMClave", ModPOS.CompanyActual)
        a.GridSearch.RootTable.Columns("CLAClave").Visible = False
        a.numColValor = 0
        a.numColDescripcion = 1
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.recuperaClasificacion(a.valor)
        End If
        a.Dispose()
    End Sub

    Private Sub btnDelClasificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelClasificacion.Click
        If GridClasificaciones.Row >= 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara del producto actual la clasificación: " & GridClasificaciones.GetValue("Referencia"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtClasificaciones.Select("CLAClave = '" & GridClasificaciones.GetValue("CLAClave") & "'")



                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If



            End Select
        End If
    End Sub

    Private Sub btnDelAplicacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelAplicacion.Click

        If GridAplicacion.Row >= 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara del producto actual la aplicación: " & GridAplicacion.GetValue("Marca") & " " & GridAplicacion.GetValue("Modelo") & " " & GridAplicacion.GetValue("Año") & " - " & GridAplicacion.GetValue("Hasta"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtAplicaciones.Select("ID = '" & GridAplicacion.GetValue("ID") & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If

            End Select
        End If

    End Sub

    Private Sub TxtReferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtReferencia.KeyDown
        If e.KeyCode = Keys.Enter Then

            If TxtReferencia.Text <> "" Then



                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_busca_clasificacion", "@Tipo", 3, "@Grupo", 0, "@Referencia", TxtReferencia.Text, "@COMClave", ModPOS.CompanyActual)

                If dt.Rows.Count > 0 Then
                    Dim iGrupo As Integer
                    Dim sGrupo As String

                    iGrupo = IIf(dt.Rows(0)("TGrupo").GetType.Name = "DBNull", 0, dt.Rows(0)("TGrupo"))

                    Dim dtGrupo As DataTable
                    dtGrupo = ModPOS.Recupera_Tabla("sp_recupera_valor", "@Tabla", "Clasificacion", "@Campo", "Grupo", "@Valor", iGrupo)

                    If dtGrupo.Rows.Count > 0 Then
                        sGrupo = dtGrupo.Rows(0)("Descripcion")
                    Else
                        sGrupo = ""
                    End If

                    dtGrupo.Dispose()

                    Me.AddClasificaciones(CInt(dt.Rows(0)("CLAClave")), sGrupo, dt.Rows(0)("Referencia"), dt.Rows(0)("Nombre"), iGrupo)

                Else
                    MessageBox.Show("No se encontro clasificación de producto que coincida con la referencia", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                End If
                dt.Dispose()

            End If
        End If
    End Sub



    Private Sub GridAplicacion_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridAplicacion.SelectionChanged

        If Not GridAplicacion.GetValue(0) Is Nothing Then
            Me.btnDelAplicacion.Enabled = True

        Else
            Me.btnDelAplicacion.Enabled = False
        End If
    End Sub

    Private Sub btnAddAplicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAplicacion.Click
        If ModPOS.Aplicacion Is Nothing Then
            ModPOS.Aplicacion = New FrmAplicacion
            With ModPOS.Aplicacion
                .Text = "Agregar Aplicación"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
            End With
        End If
        ModPOS.Aplicacion.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Aplicacion.Show()
        ModPOS.Aplicacion.BringToFront()

    End Sub


    Private Sub btnAddRetencion_Click(sender As Object, e As EventArgs) Handles btnAddRetencion.Click
        If ModPOS.Retencion Is Nothing Then
            ModPOS.Retencion = New FrmRetencion
            With ModPOS.Retencion
                .Text = "Agregar Retención"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
            End With
        End If
        ModPOS.Retencion.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Retencion.Show()
        ModPOS.Retencion.BringToFront()
    End Sub

    Private Sub btnDelRetencion_Click(sender As Object, e As EventArgs) Handles btnDelRetencion.Click
        If gridRetencion.Row >= 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el impuesto: " & gridRetencion.GetValue("Impuesto"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtRetenciones.Select("IMPClave = '" & gridRetencion.GetValue("IMPClave") & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If

            End Select
        End If
    End Sub

    Private Sub gridRetencion_SelectionChanged(sender As Object, e As EventArgs) Handles gridRetencion.SelectionChanged
        If Not gridRetencion.GetValue(0) Is Nothing Then
            Me.btnDelRetencion.Enabled = True

        Else
            Me.btnDelRetencion.Enabled = False
        End If
    End Sub
End Class
