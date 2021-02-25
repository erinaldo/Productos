

Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmApartado
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
    Friend WithEvents BtnCancelarTicket As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnPagos As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LstDomicilio As System.Windows.Forms.ListBox
    Friend WithEvents TxtRFC As System.Windows.Forms.TextBox
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents TxtTotalApartados As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtSaldoApartados As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UiTab As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabApartados As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UiTabAbonos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpSaldos As System.Windows.Forms.GroupBox
    Friend WithEvents GridSaldos As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpDomicilio As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox24 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox23 As System.Windows.Forms.PictureBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxtNoInterior As System.Windows.Forms.TextBox
    Friend WithEvents TxtNoExterior As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents TxtLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtCalle As System.Windows.Forms.TextBox
    Friend WithEvents LblCalle As System.Windows.Forms.Label
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnDelDomi As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblTipo As System.Windows.Forms.Label
    Friend WithEvents LblColonia As System.Windows.Forms.Label
    Friend WithEvents LblMnpio As System.Windows.Forms.Label
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents LblPais As System.Windows.Forms.Label
    Friend WithEvents BtnAceptarDomi As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDomicilio As Selling.StoreCombo
    Friend WithEvents cmbColonia As Selling.StoreCombo
    Friend WithEvents cmbMnpio As Selling.StoreCombo
    Friend WithEvents cmbEstado As Selling.StoreCombo
    Friend WithEvents ChkDomicilio As Selling.ChkStatus
    Friend WithEvents cmbPais As Selling.StoreCombo
    Friend WithEvents GrpDomicilios As System.Windows.Forms.GroupBox
    Friend WithEvents GridDomicilios As Janus.Windows.GridEX.GridEX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtSaldoDocumento As System.Windows.Forms.TextBox
    Friend WithEvents LblIVA As System.Windows.Forms.Label
    Friend WithEvents TxtTotalDocumento As System.Windows.Forms.TextBox
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents GrpSinAsignar As System.Windows.Forms.GroupBox
    Friend WithEvents LstApartados As System.Windows.Forms.ListBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnConsultar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelarProducto As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmApartado))
        Me.GrpCliente = New System.Windows.Forms.GroupBox()
        Me.TxtTotalApartados = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtSaldoApartados = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtRFC = New System.Windows.Forms.TextBox()
        Me.LstDomicilio = New System.Windows.Forms.ListBox()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BtnBuscaCte = New Janus.Windows.EditControls.UIButton()
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.BtnCancelarProducto = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelarTicket = New Janus.Windows.EditControls.UIButton()
        Me.BtnPagos = New Janus.Windows.EditControls.UIButton()
        Me.UiTab = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabApartados = New Janus.Windows.UI.Tab.UITabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtSaldoDocumento = New System.Windows.Forms.TextBox()
        Me.LblIVA = New System.Windows.Forms.Label()
        Me.TxtTotalDocumento = New System.Windows.Forms.TextBox()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.GrpSinAsignar = New System.Windows.Forms.GroupBox()
        Me.LstApartados = New System.Windows.Forms.ListBox()
        Me.GrpDetalle = New System.Windows.Forms.GroupBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.UiTabAbonos = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpSaldos = New System.Windows.Forms.GroupBox()
        Me.GridSaldos = New Janus.Windows.GridEX.GridEX()
        Me.GrpDomicilio = New System.Windows.Forms.GroupBox()
        Me.PictureBox24 = New System.Windows.Forms.PictureBox()
        Me.PictureBox23 = New System.Windows.Forms.PictureBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtNoInterior = New System.Windows.Forms.TextBox()
        Me.TxtNoExterior = New System.Windows.Forms.TextBox()
        Me.TxtCodigoPostal = New System.Windows.Forms.TextBox()
        Me.TxtLocalidad = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.TxtCalle = New System.Windows.Forms.TextBox()
        Me.LblCalle = New System.Windows.Forms.Label()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.BtnDelDomi = New Janus.Windows.EditControls.UIButton()
        Me.LblTipo = New System.Windows.Forms.Label()
        Me.LblColonia = New System.Windows.Forms.Label()
        Me.LblMnpio = New System.Windows.Forms.Label()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.LblPais = New System.Windows.Forms.Label()
        Me.BtnAceptarDomi = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cmbTipoDomicilio = New Selling.StoreCombo()
        Me.cmbColonia = New Selling.StoreCombo()
        Me.cmbMnpio = New Selling.StoreCombo()
        Me.cmbEstado = New Selling.StoreCombo()
        Me.ChkDomicilio = New Selling.ChkStatus(Me.components)
        Me.cmbPais = New Selling.StoreCombo()
        Me.GrpDomicilios = New System.Windows.Forms.GroupBox()
        Me.GridDomicilios = New Janus.Windows.GridEX.GridEX()
        Me.BtnConsultar = New Janus.Windows.EditControls.UIButton()
        Me.GrpCliente.SuspendLayout()
        CType(Me.UiTab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab.SuspendLayout()
        Me.UiTabApartados.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GrpSinAsignar.SuspendLayout()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabAbonos.SuspendLayout()
        Me.GrpSaldos.SuspendLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDomicilio.SuspendLayout()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDomicilios.SuspendLayout()
        CType(Me.GridDomicilios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpCliente
        '
        Me.GrpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCliente.Controls.Add(Me.TxtTotalApartados)
        Me.GrpCliente.Controls.Add(Me.Label1)
        Me.GrpCliente.Controls.Add(Me.TxtSaldoApartados)
        Me.GrpCliente.Controls.Add(Me.Label3)
        Me.GrpCliente.Controls.Add(Me.TxtRFC)
        Me.GrpCliente.Controls.Add(Me.LstDomicilio)
        Me.GrpCliente.Controls.Add(Me.lblRFC)
        Me.GrpCliente.Controls.Add(Me.Label11)
        Me.GrpCliente.Controls.Add(Me.BtnBuscaCte)
        Me.GrpCliente.Controls.Add(Me.TxtRazonSocial)
        Me.GrpCliente.Controls.Add(Me.Label2)
        Me.GrpCliente.Controls.Add(Me.TxtClave)
        Me.GrpCliente.Location = New System.Drawing.Point(7, 6)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.Size = New System.Drawing.Size(672, 175)
        Me.GrpCliente.TabIndex = 2
        Me.GrpCliente.TabStop = False
        Me.GrpCliente.Text = "Datos Cliente"
        '
        'TxtTotalApartados
        '
        Me.TxtTotalApartados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotalApartados.Enabled = False
        Me.TxtTotalApartados.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalApartados.Location = New System.Drawing.Point(218, 138)
        Me.TxtTotalApartados.Name = "TxtTotalApartados"
        Me.TxtTotalApartados.ReadOnly = True
        Me.TxtTotalApartados.Size = New System.Drawing.Size(176, 26)
        Me.TxtTotalApartados.TabIndex = 94
        Me.TxtTotalApartados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(400, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 18)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "Saldo (Apartados)"
        '
        'TxtSaldoApartados
        '
        Me.TxtSaldoApartados.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSaldoApartados.Enabled = False
        Me.TxtSaldoApartados.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaldoApartados.Location = New System.Drawing.Point(505, 138)
        Me.TxtSaldoApartados.Name = "TxtSaldoApartados"
        Me.TxtSaldoApartados.ReadOnly = True
        Me.TxtSaldoApartados.Size = New System.Drawing.Size(159, 26)
        Me.TxtSaldoApartados.TabIndex = 95
        Me.TxtSaldoApartados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(121, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 21)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "Total (Apartados)"
        '
        'TxtRFC
        '
        Me.TxtRFC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRFC.Enabled = False
        Me.TxtRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRFC.Location = New System.Drawing.Point(505, 16)
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.ReadOnly = True
        Me.TxtRFC.Size = New System.Drawing.Size(160, 21)
        Me.TxtRFC.TabIndex = 93
        '
        'LstDomicilio
        '
        Me.LstDomicilio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LstDomicilio.Enabled = False
        Me.LstDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstDomicilio.ItemHeight = 15
        Me.LstDomicilio.Location = New System.Drawing.Point(7, 94)
        Me.LstDomicilio.Name = "LstDomicilio"
        Me.LstDomicilio.Size = New System.Drawing.Size(658, 19)
        Me.LstDomicilio.TabIndex = 92
        '
        'lblRFC
        '
        Me.lblRFC.Location = New System.Drawing.Point(465, 21)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(34, 14)
        Me.lblRFC.TabIndex = 91
        Me.lblRFC.Text = "RFC"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(7, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 31)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Nombre ó Razón Social "
        '
        'BtnBuscaCte
        '
        Me.BtnBuscaCte.Image = CType(resources.GetObject("BtnBuscaCte.Image"), System.Drawing.Image)
        Me.BtnBuscaCte.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaCte.Location = New System.Drawing.Point(217, 17)
        Me.BtnBuscaCte.Name = "BtnBuscaCte"
        Me.BtnBuscaCte.Size = New System.Drawing.Size(23, 22)
        Me.BtnBuscaCte.TabIndex = 1
        Me.BtnBuscaCte.ToolTipText = "Busqueda de Cliente"
        Me.BtnBuscaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRazonSocial.Enabled = False
        Me.TxtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRazonSocial.Location = New System.Drawing.Point(80, 49)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(585, 30)
        Me.TxtRazonSocial.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Clave"
        '
        'TxtClave
        '
        Me.TxtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClave.Location = New System.Drawing.Point(80, 17)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(132, 21)
        Me.TxtClave.TabIndex = 3
        '
        'BtnCancelarProducto
        '
        Me.BtnCancelarProducto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelarProducto.Image = CType(resources.GetObject("BtnCancelarProducto.Image"), System.Drawing.Image)
        Me.BtnCancelarProducto.Location = New System.Drawing.Point(691, 101)
        Me.BtnCancelarProducto.Name = "BtnCancelarProducto"
        Me.BtnCancelarProducto.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelarProducto.TabIndex = 95
        Me.BtnCancelarProducto.Text = "&Producto"
        Me.BtnCancelarProducto.ToolTipText = "Cancelar Producto Apartado"
        Me.BtnCancelarProducto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelarTicket
        '
        Me.BtnCancelarTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelarTicket.Image = CType(resources.GetObject("BtnCancelarTicket.Image"), System.Drawing.Image)
        Me.BtnCancelarTicket.Location = New System.Drawing.Point(691, 144)
        Me.BtnCancelarTicket.Name = "BtnCancelarTicket"
        Me.BtnCancelarTicket.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelarTicket.TabIndex = 5
        Me.BtnCancelarTicket.Text = "&Ticket"
        Me.BtnCancelarTicket.ToolTipText = "Cancelar Venta de Apartado"
        Me.BtnCancelarTicket.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnPagos
        '
        Me.BtnPagos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPagos.Icon = CType(resources.GetObject("BtnPagos.Icon"), System.Drawing.Icon)
        Me.BtnPagos.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnPagos.Location = New System.Drawing.Point(691, 11)
        Me.BtnPagos.Name = "BtnPagos"
        Me.BtnPagos.Size = New System.Drawing.Size(90, 37)
        Me.BtnPagos.TabIndex = 4
        Me.BtnPagos.Text = "&Abono"
        Me.BtnPagos.ToolTipText = "Registrar Pagos o Abonos"
        Me.BtnPagos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTab
        '
        Me.UiTab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTab.FlatBorderColor = System.Drawing.Color.LightSteelBlue
        Me.UiTab.Location = New System.Drawing.Point(7, 187)
        Me.UiTab.Name = "UiTab"
        Me.UiTab.Size = New System.Drawing.Size(782, 385)
        Me.UiTab.TabIndex = 96
        Me.UiTab.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabApartados, Me.UiTabAbonos})
        Me.UiTab.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabApartados
        '
        Me.UiTabApartados.Controls.Add(Me.Panel1)
        Me.UiTabApartados.Icon = CType(resources.GetObject("UiTabApartados.Icon"), System.Drawing.Icon)
        Me.UiTabApartados.Location = New System.Drawing.Point(1, 23)
        Me.UiTabApartados.Name = "UiTabApartados"
        Me.UiTabApartados.Size = New System.Drawing.Size(780, 361)
        Me.UiTabApartados.TabStop = True
        Me.UiTabApartados.Text = "Apartados"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GrpSinAsignar)
        Me.Panel1.Controls.Add(Me.GrpDetalle)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(893, 367)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TxtSaldoDocumento)
        Me.GroupBox1.Controls.Add(Me.LblIVA)
        Me.GroupBox1.Controls.Add(Me.TxtTotalDocumento)
        Me.GroupBox1.Controls.Add(Me.LblTotal)
        Me.GroupBox1.Location = New System.Drawing.Point(170, 310)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(607, 48)
        Me.GroupBox1.TabIndex = 97
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información del Documento Seleccionado"
        '
        'TxtSaldoDocumento
        '
        Me.TxtSaldoDocumento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSaldoDocumento.Enabled = False
        Me.TxtSaldoDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaldoDocumento.Location = New System.Drawing.Point(232, 16)
        Me.TxtSaldoDocumento.Name = "TxtSaldoDocumento"
        Me.TxtSaldoDocumento.ReadOnly = True
        Me.TxtSaldoDocumento.Size = New System.Drawing.Size(151, 26)
        Me.TxtSaldoDocumento.TabIndex = 16
        Me.TxtSaldoDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblIVA
        '
        Me.LblIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblIVA.Location = New System.Drawing.Point(190, 23)
        Me.LblIVA.Name = "LblIVA"
        Me.LblIVA.Size = New System.Drawing.Size(47, 15)
        Me.LblIVA.TabIndex = 91
        Me.LblIVA.Text = "Saldo"
        '
        'TxtTotalDocumento
        '
        Me.TxtTotalDocumento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTotalDocumento.Enabled = False
        Me.TxtTotalDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalDocumento.Location = New System.Drawing.Point(430, 15)
        Me.TxtTotalDocumento.Name = "TxtTotalDocumento"
        Me.TxtTotalDocumento.ReadOnly = True
        Me.TxtTotalDocumento.Size = New System.Drawing.Size(169, 26)
        Me.TxtTotalDocumento.TabIndex = 17
        Me.TxtTotalDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.Location = New System.Drawing.Point(389, 24)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(35, 15)
        Me.LblTotal.TabIndex = 90
        Me.LblTotal.Text = "Total"
        '
        'GrpSinAsignar
        '
        Me.GrpSinAsignar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpSinAsignar.Controls.Add(Me.LstApartados)
        Me.GrpSinAsignar.Location = New System.Drawing.Point(4, 2)
        Me.GrpSinAsignar.Name = "GrpSinAsignar"
        Me.GrpSinAsignar.Size = New System.Drawing.Size(160, 357)
        Me.GrpSinAsignar.TabIndex = 96
        Me.GrpSinAsignar.TabStop = False
        Me.GrpSinAsignar.Text = "Ventas con Apartado"
        '
        'LstApartados
        '
        Me.LstApartados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LstApartados.HorizontalScrollbar = True
        Me.LstApartados.Location = New System.Drawing.Point(7, 12)
        Me.LstApartados.Name = "LstApartados"
        Me.LstApartados.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LstApartados.ScrollAlwaysVisible = True
        Me.LstApartados.Size = New System.Drawing.Size(146, 342)
        Me.LstApartados.TabIndex = 10
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Location = New System.Drawing.Point(169, 4)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(608, 301)
        Me.GrpDetalle.TabIndex = 95
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle de Apartados"
        '
        'GridDetalle
        '
        Me.GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Enabled = False
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(7, 15)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(595, 279)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabAbonos
        '
        Me.UiTabAbonos.Controls.Add(Me.GrpSaldos)
        Me.UiTabAbonos.Icon = CType(resources.GetObject("UiTabAbonos.Icon"), System.Drawing.Icon)
        Me.UiTabAbonos.Location = New System.Drawing.Point(1, 23)
        Me.UiTabAbonos.Name = "UiTabAbonos"
        Me.UiTabAbonos.Size = New System.Drawing.Size(780, 361)
        Me.UiTabAbonos.TabStop = True
        Me.UiTabAbonos.Text = "Abonos"
        '
        'GrpSaldos
        '
        Me.GrpSaldos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpSaldos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpSaldos.Controls.Add(Me.GridSaldos)
        Me.GrpSaldos.Location = New System.Drawing.Point(7, 7)
        Me.GrpSaldos.Name = "GrpSaldos"
        Me.GrpSaldos.Size = New System.Drawing.Size(763, 347)
        Me.GrpSaldos.TabIndex = 10
        Me.GrpSaldos.TabStop = False
        Me.GrpSaldos.Text = "Abonos Realizados"
        '
        'GridSaldos
        '
        Me.GridSaldos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridSaldos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridSaldos.ColumnAutoResize = True
        Me.GridSaldos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridSaldos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridSaldos.Location = New System.Drawing.Point(-2, 0)
        Me.GridSaldos.Name = "GridSaldos"
        Me.GridSaldos.RecordNavigator = True
        Me.GridSaldos.Size = New System.Drawing.Size(773, 346)
        Me.GridSaldos.TabIndex = 2
        Me.GridSaldos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpDomicilio
        '
        Me.GrpDomicilio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDomicilio.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpDomicilio.Controls.Add(Me.PictureBox24)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox23)
        Me.GrpDomicilio.Controls.Add(Me.Label21)
        Me.GrpDomicilio.Controls.Add(Me.TxtReferencia)
        Me.GrpDomicilio.Controls.Add(Me.Label22)
        Me.GrpDomicilio.Controls.Add(Me.Label23)
        Me.GrpDomicilio.Controls.Add(Me.TxtNoInterior)
        Me.GrpDomicilio.Controls.Add(Me.TxtNoExterior)
        Me.GrpDomicilio.Controls.Add(Me.TxtCodigoPostal)
        Me.GrpDomicilio.Controls.Add(Me.TxtLocalidad)
        Me.GrpDomicilio.Controls.Add(Me.Label24)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox12)
        Me.GrpDomicilio.Controls.Add(Me.TxtCalle)
        Me.GrpDomicilio.Controls.Add(Me.LblCalle)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox11)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox10)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox9)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox8)
        Me.GrpDomicilio.Controls.Add(Me.BtnDelDomi)
        Me.GrpDomicilio.Controls.Add(Me.LblTipo)
        Me.GrpDomicilio.Controls.Add(Me.LblColonia)
        Me.GrpDomicilio.Controls.Add(Me.LblMnpio)
        Me.GrpDomicilio.Controls.Add(Me.LblEstado)
        Me.GrpDomicilio.Controls.Add(Me.LblPais)
        Me.GrpDomicilio.Controls.Add(Me.BtnAceptarDomi)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox7)
        Me.GrpDomicilio.Controls.Add(Me.Label25)
        Me.GrpDomicilio.Controls.Add(Me.cmbTipoDomicilio)
        Me.GrpDomicilio.Controls.Add(Me.cmbColonia)
        Me.GrpDomicilio.Controls.Add(Me.cmbMnpio)
        Me.GrpDomicilio.Controls.Add(Me.cmbEstado)
        Me.GrpDomicilio.Controls.Add(Me.ChkDomicilio)
        Me.GrpDomicilio.Controls.Add(Me.cmbPais)
        Me.GrpDomicilio.Location = New System.Drawing.Point(8, 16)
        Me.GrpDomicilio.Name = "GrpDomicilio"
        Me.GrpDomicilio.Size = New System.Drawing.Size(674, 196)
        Me.GrpDomicilio.TabIndex = 0
        Me.GrpDomicilio.TabStop = False
        Me.GrpDomicilio.Text = "Domicilio"
        '
        'PictureBox24
        '
        Me.PictureBox24.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox24.Image = CType(resources.GetObject("PictureBox24.Image"), System.Drawing.Image)
        Me.PictureBox24.Location = New System.Drawing.Point(443, 141)
        Me.PictureBox24.Name = "PictureBox24"
        Me.PictureBox24.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox24.TabIndex = 92
        Me.PictureBox24.TabStop = False
        Me.PictureBox24.Visible = False
        '
        'PictureBox23
        '
        Me.PictureBox23.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox23.Image = CType(resources.GetObject("PictureBox23.Image"), System.Drawing.Image)
        Me.PictureBox23.Location = New System.Drawing.Point(57, 142)
        Me.PictureBox23.Name = "PictureBox23"
        Me.PictureBox23.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox23.TabIndex = 91
        Me.PictureBox23.TabStop = False
        Me.PictureBox23.Visible = False
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(9, 173)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(67, 16)
        Me.Label21.TabIndex = 90
        Me.Label21.Text = "Referencia"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(80, 166)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(569, 20)
        Me.TxtReferencia.TabIndex = 11
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(531, 140)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(48, 17)
        Me.Label22.TabIndex = 88
        Me.Label22.Text = "No. Int."
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(411, 141)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(48, 17)
        Me.Label23.TabIndex = 87
        Me.Label23.Text = "No. Ext."
        '
        'TxtNoInterior
        '
        Me.TxtNoInterior.Location = New System.Drawing.Point(583, 137)
        Me.TxtNoInterior.Name = "TxtNoInterior"
        Me.TxtNoInterior.Size = New System.Drawing.Size(66, 20)
        Me.TxtNoInterior.TabIndex = 10
        '
        'TxtNoExterior
        '
        Me.TxtNoExterior.Location = New System.Drawing.Point(463, 137)
        Me.TxtNoExterior.Name = "TxtNoExterior"
        Me.TxtNoExterior.Size = New System.Drawing.Size(66, 20)
        Me.TxtNoExterior.TabIndex = 9
        '
        'TxtCodigoPostal
        '
        Me.TxtCodigoPostal.Location = New System.Drawing.Point(424, 108)
        Me.TxtCodigoPostal.Name = "TxtCodigoPostal"
        Me.TxtCodigoPostal.Size = New System.Drawing.Size(147, 20)
        Me.TxtCodigoPostal.TabIndex = 7
        '
        'TxtLocalidad
        '
        Me.TxtLocalidad.Location = New System.Drawing.Point(361, 76)
        Me.TxtLocalidad.Name = "TxtLocalidad"
        Me.TxtLocalidad.Size = New System.Drawing.Size(210, 20)
        Me.TxtLocalidad.TabIndex = 5
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(260, 79)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(99, 15)
        Me.Label24.TabIndex = 77
        Me.Label24.Text = "Ciudad/Población"
        '
        'PictureBox12
        '
        Me.PictureBox12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), System.Drawing.Image)
        Me.PictureBox12.Location = New System.Drawing.Point(398, 109)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox12.TabIndex = 68
        Me.PictureBox12.TabStop = False
        Me.PictureBox12.Visible = False
        '
        'TxtCalle
        '
        Me.TxtCalle.Location = New System.Drawing.Point(79, 138)
        Me.TxtCalle.Name = "TxtCalle"
        Me.TxtCalle.Size = New System.Drawing.Size(330, 20)
        Me.TxtCalle.TabIndex = 8
        '
        'LblCalle
        '
        Me.LblCalle.Location = New System.Drawing.Point(6, 141)
        Me.LblCalle.Name = "LblCalle"
        Me.LblCalle.Size = New System.Drawing.Size(72, 16)
        Me.LblCalle.TabIndex = 67
        Me.LblCalle.Text = "Calle"
        '
        'PictureBox11
        '
        Me.PictureBox11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(56, 107)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox11.TabIndex = 65
        Me.PictureBox11.TabStop = False
        Me.PictureBox11.Visible = False
        '
        'PictureBox10
        '
        Me.PictureBox10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(56, 81)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox10.TabIndex = 64
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'PictureBox9
        '
        Me.PictureBox9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(389, 49)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox9.TabIndex = 63
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(56, 53)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox8.TabIndex = 62
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'BtnDelDomi
        '
        Me.BtnDelDomi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelDomi.Enabled = False
        Me.BtnDelDomi.Image = CType(resources.GetObject("BtnDelDomi.Image"), System.Drawing.Image)
        Me.BtnDelDomi.Location = New System.Drawing.Point(586, 80)
        Me.BtnDelDomi.Name = "BtnDelDomi"
        Me.BtnDelDomi.Size = New System.Drawing.Size(75, 32)
        Me.BtnDelDomi.TabIndex = 9
        Me.BtnDelDomi.Text = "&Eliminar"
        Me.BtnDelDomi.ToolTipText = "Eliminar domicilio seleccionado"
        Me.BtnDelDomi.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblTipo
        '
        Me.LblTipo.Location = New System.Drawing.Point(8, 24)
        Me.LblTipo.Name = "LblTipo"
        Me.LblTipo.Size = New System.Drawing.Size(32, 16)
        Me.LblTipo.TabIndex = 61
        Me.LblTipo.Text = "Tipo"
        '
        'LblColonia
        '
        Me.LblColonia.Location = New System.Drawing.Point(7, 109)
        Me.LblColonia.Name = "LblColonia"
        Me.LblColonia.Size = New System.Drawing.Size(72, 19)
        Me.LblColonia.TabIndex = 59
        Me.LblColonia.Text = "Colonia/C.P."
        '
        'LblMnpio
        '
        Me.LblMnpio.Location = New System.Drawing.Point(7, 80)
        Me.LblMnpio.Name = "LblMnpio"
        Me.LblMnpio.Size = New System.Drawing.Size(64, 16)
        Me.LblMnpio.TabIndex = 57
        Me.LblMnpio.Text = "Municipio"
        '
        'LblEstado
        '
        Me.LblEstado.Location = New System.Drawing.Point(310, 51)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(93, 18)
        Me.LblEstado.TabIndex = 55
        Me.LblEstado.Text = "Entidad/Estado"
        '
        'LblPais
        '
        Me.LblPais.Location = New System.Drawing.Point(8, 52)
        Me.LblPais.Name = "LblPais"
        Me.LblPais.Size = New System.Drawing.Size(32, 16)
        Me.LblPais.TabIndex = 51
        Me.LblPais.Text = "País"
        '
        'BtnAceptarDomi
        '
        Me.BtnAceptarDomi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAceptarDomi.Image = CType(resources.GetObject("BtnAceptarDomi.Image"), System.Drawing.Image)
        Me.BtnAceptarDomi.Location = New System.Drawing.Point(586, 16)
        Me.BtnAceptarDomi.Name = "BtnAceptarDomi"
        Me.BtnAceptarDomi.Size = New System.Drawing.Size(75, 32)
        Me.BtnAceptarDomi.TabIndex = 8
        Me.BtnAceptarDomi.Text = "&Aceptar"
        Me.BtnAceptarDomi.ToolTipText = "Guardar cambios"
        Me.BtnAceptarDomi.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox7
        '
        Me.PictureBox7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(56, 19)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox7.TabIndex = 60
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(335, 111)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(82, 16)
        Me.Label25.TabIndex = 79
        Me.Label25.Text = "Código Postal"
        '
        'cmbTipoDomicilio
        '
        Me.cmbTipoDomicilio.Location = New System.Drawing.Point(78, 18)
        Me.cmbTipoDomicilio.Name = "cmbTipoDomicilio"
        Me.cmbTipoDomicilio.Size = New System.Drawing.Size(160, 21)
        Me.cmbTipoDomicilio.TabIndex = 1
        '
        'cmbColonia
        '
        Me.cmbColonia.Location = New System.Drawing.Point(78, 107)
        Me.cmbColonia.Name = "cmbColonia"
        Me.cmbColonia.Size = New System.Drawing.Size(251, 21)
        Me.cmbColonia.TabIndex = 6
        '
        'cmbMnpio
        '
        Me.cmbMnpio.Location = New System.Drawing.Point(78, 76)
        Me.cmbMnpio.Name = "cmbMnpio"
        Me.cmbMnpio.Size = New System.Drawing.Size(176, 21)
        Me.cmbMnpio.TabIndex = 4
        '
        'cmbEstado
        '
        Me.cmbEstado.Location = New System.Drawing.Point(411, 46)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(160, 21)
        Me.cmbEstado.TabIndex = 3
        '
        'ChkDomicilio
        '
        Me.ChkDomicilio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkDomicilio.Checked = True
        Me.ChkDomicilio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkDomicilio.Enabled = False
        Me.ChkDomicilio.Location = New System.Drawing.Point(398, 16)
        Me.ChkDomicilio.Name = "ChkDomicilio"
        Me.ChkDomicilio.Size = New System.Drawing.Size(56, 24)
        Me.ChkDomicilio.TabIndex = 7
        Me.ChkDomicilio.Text = "Activo"
        '
        'cmbPais
        '
        Me.cmbPais.Location = New System.Drawing.Point(78, 49)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(176, 21)
        Me.cmbPais.TabIndex = 2
        '
        'GrpDomicilios
        '
        Me.GrpDomicilios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDomicilios.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpDomicilios.Controls.Add(Me.GridDomicilios)
        Me.GrpDomicilios.Location = New System.Drawing.Point(10, 218)
        Me.GrpDomicilios.Name = "GrpDomicilios"
        Me.GrpDomicilios.Size = New System.Drawing.Size(674, 184)
        Me.GrpDomicilios.TabIndex = 1
        Me.GrpDomicilios.TabStop = False
        Me.GrpDomicilios.Text = "Domicilios"
        '
        'GridDomicilios
        '
        Me.GridDomicilios.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridDomicilios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDomicilios.ColumnAutoResize = True
        Me.GridDomicilios.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDomicilios.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDomicilios.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridDomicilios.Location = New System.Drawing.Point(8, 16)
        Me.GridDomicilios.Name = "GridDomicilios"
        Me.GridDomicilios.RecordNavigator = True
        Me.GridDomicilios.Size = New System.Drawing.Size(658, 160)
        Me.GridDomicilios.TabIndex = 1
        Me.GridDomicilios.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConsultar.Icon = CType(resources.GetObject("BtnConsultar.Icon"), System.Drawing.Icon)
        Me.BtnConsultar.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnConsultar.Location = New System.Drawing.Point(691, 56)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(90, 37)
        Me.BtnConsultar.TabIndex = 97
        Me.BtnConsultar.Text = "&Consultar"
        Me.BtnConsultar.ToolTipText = "Consulta de Apartados"
        Me.BtnConsultar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmApartado
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.BtnConsultar)
        Me.Controls.Add(Me.UiTab)
        Me.Controls.Add(Me.BtnCancelarProducto)
        Me.Controls.Add(Me.GrpCliente)
        Me.Controls.Add(Me.BtnCancelarTicket)
        Me.Controls.Add(Me.BtnPagos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmApartado"
        Me.Text = "Mantenimiento de Productos Apartados por Clientes"
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        CType(Me.UiTab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab.ResumeLayout(False)
        Me.UiTabApartados.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GrpSinAsignar.ResumeLayout(False)
        Me.GrpDetalle.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabAbonos.ResumeLayout(False)
        Me.GrpSaldos.ResumeLayout(False)
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDomicilio.ResumeLayout(False)
        Me.GrpDomicilio.PerformLayout()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDomicilios.ResumeLayout(False)
        CType(Me.GridDomicilios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Cliente As String = ""
    Public SUCClave As String
    Public ALMClave As String
    Public CAJClave As String
    Public AtiendeNombre As String
    Public Impresora As String
    Public PrintGeneric As Boolean
    Public Recibo As String
    Public Cajon As Boolean = False
    Public Picking As Boolean = False
  
    Private VENClave As String
    Private SaldoApartados As Double
    Private ClaveCaja As String
    Private TotalDoc As Decimal
    Private SaldoDoc As Decimal
    Private ClienteClave As String
    Private Moneda, MonedaCambio, TipoCambio, TipoCambioBase As Decimal
    Private MonRefBase, MonRefActual As String
    Private bLoad As Boolean

    Private dtAsignados, dtDetalle As DataTable

  
    Private Sub CargaTickets(ByVal Clave As String)
        bLoad = False
        dtAsignados = ModPOS.Recupera_Tabla("sp_filtra_TicketsApartados", "@CTEClave", Clave)
        Me.LstApartados.DataSource = dtAsignados
        Me.LstApartados.DisplayMember = dtAsignados.Columns(1).ColumnName
        Me.LstApartados.ValueMember = dtAsignados.Columns(0).ColumnName

        If dtAsignados Is Nothing OrElse dtAsignados.Rows.Count = 0 Then
            TxtTotalApartados.Text = Format(CStr(0), "Currency") & " " & MonRefBase
            TxtSaldoApartados.Text = Format(CStr(0), "Currency") & " " & MonRefBase
            TotalDoc = 0
            SaldoDoc = 0
            TxtSaldoDocumento.Text = Format(CStr(0), "Currency") & " " & MonRefBase
            TxtTotalDocumento.Text = Format(CStr(0), "Currency") & " " & MonRefBase
        End If

        bLoad = True
        If Not LstApartados.SelectedItem Is Nothing Then
            VENClave = LstApartados.SelectedItem(0)
            CargaDetalleTicket(VENClave)
        Else
            VENClave = ""
            GridDetalle.DataSource = Nothing
        End If
    End Sub

    Public Sub CargaDetalleTicket(ByVal VENClave As String)
        ModPOS.ActualizaGrid(False, Me.GridDetalle, "sp_muestra_detalleapartados", "@VENClave", VENClave)
        GridDetalle.RootTable.Columns("PROClave").Visible = False
        GridDetalle.RootTable.Columns("DVEClave").Visible = False
        GridDetalle.RootTable.Columns("Costo").Visible = False
        GridDetalle.RootTable.Columns("Impuesto").Visible = False
        GridDetalle.RootTable.Columns("Total").Visible = False
        GridDetalle.RootTable.Columns("Saldo").Visible = False
        GridDetalle.RootTable.Columns("TipoCambio").Visible = False
        GridDetalle.RootTable.Columns("MON").Visible = False
        GridDetalle.GroupByBoxVisible = False

        If GridDetalle.RowCount > 0 Then
            TotalDoc = GridDetalle.GetValue("Total")
            SaldoDoc = GridDetalle.GetValue("Saldo")
            MonRefActual = GridDetalle.GetValue("MON")
            TipoCambio = GridDetalle.GetValue("TipoCambio")
        Else
            TotalDoc = 0
            SaldoDoc = 0
            MonRefActual = MonRefBase
            TipoCambio = TipoCambioBase
        End If


        TxtSaldoDocumento.Text = Format(Redondear(SaldoDoc, 2).ToString, "Currency") & " " & MonRefActual
        TxtTotalDocumento.Text = Format(Redondear(TotalDoc, 2).ToString, "Currency") & " " & MonRefActual
    End Sub

    Private Sub FrmApartado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        'LstDomicilio.Items.Clear()
        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
        ClaveCaja = dt.Rows(0)("Clave")
        dt.Dispose()


        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "Moneda"
                        Moneda = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "MonedaCambio"
                        MonedaCambio = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                End Select
            Next
        End With

        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
        TipoCambioBase = dt.Rows(0)("TipoCambio")
        MonRefBase = dt.Rows(0)("Referencia")
        dt.Dispose()

        TipoCambio = TipoCambioBase

        TxtClave.Focus()
        BtnPagos.Enabled = False
        UiTabAbonos.Enabled = False


        If Cliente <> "" Then
            recuperaCte(Cliente)
        End If

    End Sub

    Private Sub BtnBuscaCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaCte.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                ClienteClave = a.valor

                recuperaCte(a.Descripcion)

              
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub recuperaCte(ByVal sCliente As String)
        Dim dtCliente As DataTable = ModPOS.SiExisteRecupera("sp_consulta_clienteapartado", "@Cliente", sCliente.ToUpper.Trim.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
        If Not dtCliente Is Nothing Then
            ClienteClave = dtCliente.Rows(0)("CTEClave")
            TxtClave.Text = dtCliente.Rows(0)("Clave")
            TxtRFC.Text = dtCliente.Rows(0)("id_Fiscal")
            TxtRazonSocial.Text = dtCliente.Rows(0)("RazonSocial")
            SaldoApartados = dtCliente.Rows(0)("Saldo")
            LstDomicilio.Items.Clear()
            LstDomicilio.Items.Add(dtCliente.Rows(0)("Calle"))
            LstDomicilio.Items.Add(dtCliente.Rows(0)("Domicilio1"))
            LstDomicilio.Items.Add(dtCliente.Rows(0)("Domicilio2"))
            TxtTotalApartados.Text = Format(CStr(ModPOS.Redondear(dtCliente.Rows(0)("Total"), 2)), "Currency") & " " & MonRefBase
            TxtSaldoApartados.Text = Format(CStr(ModPOS.Redondear(SaldoApartados, 2)), "Currency") & " " & MonRefBase
            dtCliente.Dispose()
            CargaTickets(ClienteClave)
            UiTabAbonos.Enabled = True
            BtnPagos.Enabled = True
        Else
            BtnPagos.Enabled = False
            UiTabAbonos.Enabled = False
            ClienteClave = ""
            MessageBox.Show("El Cliente seleccionado no cuenta con domicilio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub TxtClave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClave.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtClave.Text = vbNullString Then
                recuperaCte(TxtClave.Text)
            End If
        End If
    End Sub

    Private Sub LstApartados_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstApartados.SelectedValueChanged
        If bload = True AndAlso Not LstApartados.SelectedItem Is Nothing Then
            VENClave = LstApartados.SelectedItem(0)
            CargaDetalleTicket(VENClave)
        Else
            VENClave = ""
        End If
    End Sub

    Private Sub UiTab_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs) Handles UiTab.SelectedTabChanged
        Select Case e.Page.Name
              Case "UiTabAbonos"
                ModPOS.ActualizaGrid(False, Me.GridSaldos, "sp_consulta_abnapartados", "@CTEClave", ClienteClave)
                GridSaldos.GroupByBoxVisible = False
        End Select
    End Sub

    Private Sub BtnPagos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPagos.Click
        If VENClave <> "" Then

            Dim a As New FrmAbono
            a.TipoDocumento = 1
            a.CAJA = CAJClave
            a.ClaveCaja = ClaveCaja
            a.ClaveCte = ClienteClave
            a.ClaveDocumento = VENClave
            a.AperturaCajon = Cajon
            a.ImpresoraCajon = Impresora
            a.SaldoAcumulado = SaldoDoc * TipoCambio
            a.ShowDialog()

            If a.DialogResult = DialogResult.OK Then
                Dim i As Integer

                Dim dtApartado As DataTable = ModPOS.CrearTabla("Apartado", _
                                                                          "ID", "System.String", _
                                                                          "TipoDocumento", "System.Int32", _
                                                                          "SaldoBase", "System.Decimal", _
                                                                           "TipoCambio", "System.Decimal")
                Dim row1 As DataRow
                row1 = dtApartado.NewRow()
                row1.Item("ID") = VENClave
                row1.Item("TipoDocumento") = 1
                row1.Item("SaldoBase") = SaldoDoc * TipoCambio
                row1.Item("TipoCambio") = TipoCambio
                dtApartado.Rows.Add(row1)


                For i = 0 To a.detallePago.Rows.Count - 1
                    ModPOS.Aplica_Pagos(dtApartado, ClienteClave, a.detallePago.Rows(i)("ABNClave"), a.detallePago.Rows(i)("TipoPago"), a.detallePago.Rows(i)("SaldoBase"), CAJClave, 1)
                Next


                If a.TotalAbono > 0 Then

                    Dim msg As New FrmMeMsg
                    msg.TxtTiulo = "Su Cambio es:"
                    msg.TxtMsg = MonRefBase & " " & Format(CStr(Math.Round(a.TotalCambio, 2)), "Currency")
                    msg.TxtMsg2 = Letras(CStr(Math.Round(a.TotalCambio, 2))).ToUpper & " " & MonRefBase
                   
                    msg.ShowDialog()
                    msg.Dispose()

                    SaldoApartados -= (a.TotalAbono - a.TotalCambio)
                    TxtSaldoApartados.Text = Format(CStr(ModPOS.Redondear(SaldoApartados, 2)), "Currency")

                    Select Case MessageBox.Show("¿Desea imprimir un recibo de los pagos realizados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.Yes
                            imprimeRecibo(a.detallePago.Rows(0)("ABNClave"), a.TotalAbono, a.TotalCambio, Impresora, PrintGeneric, Recibo, AtiendeNombre)
                        Case Else
                    End Select


                    If SaldoApartados <= 0 Then

                        'Tipo 1 = Folio 2= VENClave
                        Dim sFolio As String
                        Dim dtVenta As DataTable = ModPOS.SiExisteRecupera("sp_recupera_vta_gral", "@VENClave", VENClave)
                        sFolio = dtVenta.Rows(0)("Folio")
                        dtVenta.Dispose()

                        ModPOS.Ejecuta("sp_convierte_venta", "@VENClave", VENClave)

                        If Picking = False Then
                            ModPOS.GeneraMovInv(2, 1, 1, VENClave, ALMClave, sFolio, Nothing)
                            actualizaSeguimiento(VENClave)
                            ModPOS.Ejecuta("sp_actualiza_venta_apartado", "@VENClave", VENClave)
                        Else
                            ModPOS.Ejecuta("sp_actualiza_venta_apartado", "@VENClave", VENClave)
                            ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", 7, "@ALMClave", ALMClave)
                            ModPOS.calculaRecoleccion(1, VENClave, ALMClave, "", 0)
                        End If

                        If Picking = True Then
                            ModPOS.ImprimirSurtido(1, VENClave, False, True)
                        End If

                        MessageBox.Show("Puede realizar la entrega de producto. El Apartado actual no cuenta con saldo pendiente, para futuras referencias podra consultar la venta con el mismo numero de ticket", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If

                a.Dispose()
                CargaDetalleTicket(VENClave)
            Else
                a.Dispose()
                '     Exit Sub
            End If
        Else
            MessageBox.Show("Debe seleccionar un Documento o Ticket para realizar el pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Sub actualizaSeguimiento(ByVal VENClave As String)
        Dim dtDetalleVenta As DataTable
        dtDetalleVenta = ModPOS.SiExisteRecupera("sp_qry_ventadetalle", "@VENClave", VENClave)

        If Not dtDetalleVenta Is Nothing AndAlso dtDetalleVenta.Rows.Count > 0 Then
            Dim foundRows() As System.Data.DataRow
            foundRows = dtDetalleVenta.Select("Seguimiento > 1")
            Dim dCantidad As Double = 1.0

            If foundRows.Length = 0 Then
                Dim i As Integer
                For i = 0 To foundRows.GetUpperBound(0)

                    'SI REQUIERE SEGUIMIENTO DE SERIAL
                    If foundRows(i)("Seguimiento") = 2 Then
                        Dim SerialReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = dCantidad
                        Do
                            Dim a As New FrmSerial
                            a.DOCClave = VENClave
                            a.PROClave = foundRows(i)("PROClave")
                            a.Clave = foundRows(i)("Clave")
                            a.Nombre = foundRows(i)("Nombre")
                            a.Cantidad = foundRows(i)("Cantidad")
                            a.Dias = foundRows(i)("DiasGarantia")
                            a.TipoDoc = 1
                            a.TipoMov = 2
                            a.ShowDialog()
                            SerialReg = SerialReg + a.NumSerialRegistrados
                            PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                            a.Dispose()
                        Loop Until SerialReg = foundRows(i)("Cantidad") OrElse PorRegistrar = 0
                    End If

                    'SI REQUIERE SEGUIMIENTO DE LOTE
                    If foundRows(i)("Seguimiento") = 3 Then
                        Dim LoteReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = dCantidad
                        Do
                            Dim a As New FrmLote
                            a.DOCClave = VENClave
                            a.PROClave = foundRows(i)("PROClave")
                            a.Clave = foundRows(i)("Clave")
                            a.Nombre = foundRows(i)("Nombre")
                            a.CantXRegistrar = PorRegistrar
                            a.TipoDoc = 1
                            a.TipoMov = 2
                            a.ShowDialog()
                            LoteReg = LoteReg + a.NumSerialRegistrados
                            PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                            a.Dispose()
                        Loop Until LoteReg = foundRows(i)("Cantidad") OrElse PorRegistrar = 0
                    End If
                Next i
            End If
            dtDetalleVenta.Dispose()
        End If
    End Sub

    Private Function imprimeRecibo(ByVal Abono As String, ByVal Importe As Double, ByVal Cambio As Double, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String, ByVal Usu As String) As Boolean
        Dim dTotalPagos, dPagos As Double

        Dim Tickets As Imprimir = New Imprimir '.PrintTicket.Ticket
        Tickets.Generic = Generic

        Dim dtTicket As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            If dtTicket.Rows(0)("url_imagen") <> "" Then
                Tickets.ImgHeader = ModPOS.RecuperaImagen(dtTicket.Rows(0)("url_imagen"))
            End If
            dtTicket.Dispose()
        End If


        Dim dtHeadTicket As DataTable
        dtHeadTicket = ModPOS.SiExisteRecupera("sp_filtra_encabezado", "@TIKClave", Ticket)

        If Not dtHeadTicket Is Nothing Then
            Dim i As Integer
            For i = 0 To dtHeadTicket.Rows.Count - 1
                Tickets.AddHeaderLine(CStr(dtHeadTicket.Rows(i)("Texto")), Math.Abs(CInt(dtHeadTicket.Rows(i)("Negrita"))), CInt(dtHeadTicket.Rows(i)("Alinear")))
            Next
            dtHeadTicket.Dispose()
        End If


        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 
        Tickets.AddSubHeaderLine("RECIBO", 1, 3)
        Tickets.AddSubHeaderLine("LE ATENDIO: " & Usu, 0, 1)
        Tickets.AddSubHeaderLine(DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToShortTimeString(), 0, 1)

        Dim dtRef As DataTable = ModPOS.Recupera_Tabla("sp_recibo_enc", "@ABNClave", Abono)

        Tickets.AddSubHeaderBloqLine("CLIENTE: " & Me.TxtClave.Text.ToUpper.Trim, 0, 1)
        Tickets.AddSubHeaderBloqLine(Me.TxtRazonSocial.Text.ToUpper.Trim, 0, 1)
        Tickets.AddSubHeaderBloqLine("TOTAL APARTADOS: " & Me.TxtTotalApartados.Text, 0, 1)
        Tickets.AddSubHeaderBloqLine("SALDO APARTADOS: " & Me.TxtSaldoApartados.Text, 0, 1)
        Tickets.AddSubHeaderBloqLine("REFERENCIA: " & dtRef.Rows(0)("Referencia"), 0, 1)
        Tickets.AddSubHeaderBloqLine("FORMA PAGO: " & dtRef.Rows(0)("Descripcion"), 0, 1)

        dtRef.Dispose()

        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
        'del producto y el tercero es el precio 
        Dim dtPagosDetalle As DataTable
        dtPagosDetalle = ModPOS.SiExisteRecupera("sp_recibo_detalle", "@ABNClave", Abono)

        If Not dtPagosDetalle Is Nothing Then
            Dim i As Integer = 0
            dPagos = dtPagosDetalle.Rows.Count()
            For i = 0 To dPagos - 1
                Dim sFolio As String = dtPagosDetalle.Rows(i)("Tipo")
                Dim sTipo As String = dtPagosDetalle.Rows(i)("Folio")
                Dim dImporte As Double = dtPagosDetalle.Rows(i)("Importe")


                ' AGREGAR PAGOS A LISTA
                Tickets.AddItemRecibo(sFolio, sTipo, dImporte)

                dTotalPagos += (dImporte)
            Next
            dtPagosDetalle.Dispose()
        End If

        'El metodo AddTotalRecibo requiere 4 parametros 
        Tickets.AddTotalRecibo(dTotalPagos, Importe, Cambio, Imprimir.FontEstilo.Negrita)

        'El metodo AddFooterLine funciona igual que la cabecera 

        Tickets.AddFooterLine("GRACIAS POR SU PAGO", 1, 3)

        'Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        'parametro de tipo string que debe de ser el nombre de la impresora. 
        Tickets.PrintTicket(Impresora, 70, 0)

    End Function

    Private Function imprimeDevolucion(ByVal ClaveCTE As String, ByVal Folio As String, ByVal Importe As Double, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String, ByVal Usu As String, ByVal Cte As String) As Boolean
        Dim Tickets As Imprimir = New Imprimir '.PrintTicket.Ticket
        Tickets.Generic = Generic

        Dim dtTicket As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            If dtTicket.Rows(0)("url_imagen") <> "" Then
                Tickets.ImgHeader = ModPOS.RecuperaImagen(dtTicket.Rows(0)("url_imagen"))
            End If
            dtTicket.Dispose()
        End If


        Dim dtHeadTicket As DataTable
        dtHeadTicket = ModPOS.SiExisteRecupera("sp_filtra_encabezado", "@TIKClave", Ticket)

        If Not dtHeadTicket Is Nothing Then
            Dim i As Integer
            For i = 0 To dtHeadTicket.Rows.Count - 1
                Tickets.AddHeaderLine(CStr(dtHeadTicket.Rows(i)("Texto")), Math.Abs(CInt(dtHeadTicket.Rows(i)("Negrita"))), CInt(dtHeadTicket.Rows(i)("Alinear")))
            Next
            dtHeadTicket.Dispose()
        End If


        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 
        Tickets.AddSubHeaderLine("DEVOLUCION DE ANTICIPO", 1, 3)
        Tickets.AddSubHeaderLine("CTE: " & Cte, 0, 3)
        Tickets.AddSubHeaderLine("LE ATENDIO: " & Usu, 0, 1)
        Tickets.AddSubHeaderLine(DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToShortTimeString(), 0, 1)

        Tickets.AddSubHeaderBloqLine("CLIENTE: " & ClaveCTE, 0, 1)
        Tickets.AddSubHeaderBloqLine("REFERENCIA: " & Folio, 0, 1)
        Tickets.AddSubHeaderBloqLine("IMPORTE: " & Format(Redondear(Importe, 2).ToString, "Currency"), 0, 1)


        'El metodo AddFooterLine funciona igual que la cabecera 

        Tickets.AddFooterLine("____________________", 1, 3)
        Tickets.AddFooterLine("FIRMA", 1, 3)
        'Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        'parametro de tipo string que debe de ser el nombre de la impresora. 
        Tickets.PrintTicket(Impresora, 70, 0)

    End Function

    Private Sub BtnCancelarTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelarTicket.Click
        If VENClave <> "" Then
            Select Case MessageBox.Show("Se cancelara la venta con apartado :" & LstApartados.SelectedItem(1), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim a As New MeAutorizacion
                    a.Sucursal = SUCClave
                    a.MontodeAutorizacion = TotalDoc * TipoCambio
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then
                            If TotalDoc > SaldoDoc Then
                                ModPOS.Ejecuta("sp_cancela_pagos_apartados", "@VENClave", VENClave, "@CAJClave", CAJClave, "@CTEClave", ClienteClave, "@Importe", (TotalDoc - SaldoDoc) * TipoCambio, "@Usuario", ModPOS.UsuarioActual)

                                Dim msg As New FrmMeMsg
                                msg.TxtTiulo = "la devolución de su anticipo es:"
                                msg.TxtMsg = MonRefBase & " " & Format(CStr(ModPOS.Redondear((TotalDoc - SaldoDoc) * TipoCambio, 2)), "Currency")
                                msg.TxtMsg2 = Letras(CStr(ModPOS.Redondear((TotalDoc - SaldoDoc) * TipoCambio, 2))).ToUpper & " " & MonRefBase
                                msg.ShowDialog()
                                msg.Dispose()
                                imprimeDevolucion(TxtClave.Text.ToUpper.Trim.Replace("'", "''"), LstApartados.SelectedItem(1), (TotalDoc - SaldoDoc) * TipoCambio, Impresora, PrintGeneric, Recibo, AtiendeNombre, TxtRazonSocial.Text.ToUpper.Trim.Replace("'", "''"))

                                If Cajon = True Then
                                    AbrirCajon(Impresora)
                                End If

                            End If
                            ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", VENClave, "@TipoDoc", 4, "@Autoriza", a.Autoriza)
                            ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", VENClave, "@Tipo", 1)
                            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", ClienteClave, "@Importe", SaldoDoc * TipoCambio)

                            CargaTickets(ClienteClave)
                        End If
                    End If
                    a.Dispose()
            End Select
        Else
            MessageBox.Show("Debe seleccionar un Documento o Ticket para realizar la cancelación", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BtnCancelarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelarProducto.Click
        If VENClave <> "" Then
            Dim a As New FrmCancelaApartado
            a.Sucursal = SUCClave
            a.Almacen = ALMClave
            a.VentaClave = VENClave
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If a.SeCancela Then
                    If Redondear(TotalDoc, 2) = Redondear(a.PrecioNetoDetalle * a.CantidadCancelada, 2) Then
                        If TotalDoc > SaldoDoc Then
                            ModPOS.Ejecuta("sp_cancela_pagos_apartados", "@VENClave", VENClave, "@CAJClave", CAJClave, "@CTEClave", ClienteClave, "@Importe", (TotalDoc - SaldoDoc) * TipoCambio, "@Usuario", ModPOS.UsuarioActual)

                            Dim msg As New FrmMeMsg
                            msg.TxtTiulo = "la devolución de su anticipo es:"
                            msg.TxtMsg = MonRefBase & " " & Format(CStr(ModPOS.Redondear((TotalDoc - SaldoDoc) * TipoCambio, 2)), "Currency")
                            msg.TxtMsg2 = Letras(CStr(ModPOS.Redondear((TotalDoc - SaldoDoc) * TipoCambio, 2))).ToUpper & " " & MonRefBase
                            msg.ShowDialog()
                            msg.Dispose()
                            imprimeDevolucion(TxtClave.Text.ToUpper.Trim.Replace("'", "''"), LstApartados.SelectedItem(1), (TotalDoc - SaldoDoc) * TipoCambio, Impresora, PrintGeneric, Recibo, AtiendeNombre, TxtRazonSocial.Text.ToUpper.Trim.Replace("'", "''"))

                            If Cajon = True Then
                                AbrirCajon(Impresora)

                            End If
                            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", ClienteClave, "@Importe", SaldoDoc * TipoCambio)
                        Else
                            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", ClienteClave, "@Importe", TotalDoc * TipoCambio)
                        End If

                        ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", VENClave, "@TipoDoc", 4, "@Autoriza", ModPOS.UsuarioActual)
                        ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", VENClave, "@Tipo", 1)

                        CargaTickets(ClienteClave)
                        Exit Sub
                    End If

                    If TotalDoc > SaldoDoc Then
                        Dim ImporteDevolucion As Double = 0.0
                        If Redondear(SaldoDoc, 2) < Redondear(a.PrecioNetoDetalle * a.CantidadCancelada, 2) Then
                            ImporteDevolucion = (a.PrecioNetoDetalle * a.CantidadCancelada) - SaldoDoc
                            ModPOS.Ejecuta("sp_cancela_pagos_apartados", "@VENClave", VENClave, "@CAJClave", CAJClave, "@CTEClave", ClienteClave, "@Importe", ImporteDevolucion * TipoCambio, "@Usuario", ModPOS.UsuarioActual)
                            Dim msg As New FrmMeMsg
                            msg.TxtTiulo = "la devolución de su anticipo es:"
                            msg.TxtMsg = MonRefBase & " " & Format(CStr(ModPOS.Redondear(ImporteDevolucion * TipoCambio, 2)), "Currency")
                            msg.TxtMsg2 = Letras(CStr(ModPOS.Redondear(ImporteDevolucion * TipoCambio, 2))).ToUpper & " " & MonRefBase
                            msg.ShowDialog()
                            msg.Dispose()
                            imprimeDevolucion(TxtClave.Text.ToUpper.Trim.Replace("'", "''"), LstApartados.SelectedItem(1), ImporteDevolucion * TipoCambio, Impresora, PrintGeneric, Recibo, AtiendeNombre, TxtRazonSocial.Text.ToUpper.Trim.Replace("'", "''"))

                            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", ClienteClave, "@Importe", SaldoDoc * TipoCambio)
                            If Cajon = True Then
                                AbrirCajon(Impresora)
                            End If
                        Else
                            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", ClienteClave, "@Importe", Redondear((a.PrecioNetoDetalle * a.CantidadCancelada) * TipoCambio, 2))
                        End If
                    End If

                    Dim GeneraSalida As Boolean = False
                    If Redondear(SaldoDoc, 2) <= Redondear(a.PrecioNetoDetalle * a.CantidadCancelada, 2) Then                        'actualiza saldo de venta
                        ModPOS.Ejecuta("sp_act_saldo_apartado", "@VENClave", VENClave, "@Importe", 0.0)
                        GeneraSalida = True
                    Else
                        ModPOS.Ejecuta("sp_act_saldo_apartado", "@VENClave", VENClave, "@Importe", SaldoDoc - (a.PrecioNetoDetalle * a.CantidadCancelada))
                    End If

                    
                    If GeneraSalida Then

                        'Tipo 1 = Folio 2= VENClave
                        Dim sFolio As String
                        Dim dtVenta As DataTable = ModPOS.SiExisteRecupera("sp_recupera_vta_gral", "@VENClave", VENClave)
                        sFolio = dtVenta.Rows(0)("Folio")
                        dtVenta.Dispose()

                        ModPOS.Ejecuta("sp_convierte_venta", "@VENClave", VENClave)
                        ModPOS.GeneraMovInv(2, 1, 1, VENClave, ALMClave, sFolio, ModPOS.UsuarioActual)
                        actualizaSeguimiento(VENClave)
                        ModPOS.Ejecuta("sp_actualiza_venta_apartado", "@VENClave", VENClave)
                        MessageBox.Show("Puede realizar la entrega de producto. El Apartado actual no cuenta con saldo pendiente, para futuras referencias podra consultar la venta con el mismo numero de ticket", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    CargaTickets(ClienteClave)
                End If
            End If
            a.Dispose()
        Else
            MessageBox.Show("Debe seleccionar un Documento o Ticket para realizar la cancelación de productos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        Dim a As New MeFiltroCobra
        a.Titulo = "Reporte de Apartados"
        a.GrpVencimiento.Text = "Antiguedad de Apartados"
        a.ShowDialog()
        If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
            'obtenerReporteCobra("CRCobranza.rpt", "Reporte de Cobranza", a.AlmacenOrigen, a.VencimientoDias)
            Dim OpenReport As New Report
            Dim pvtaDataSet As New DataSet
            pvtaDataSet.DataSetName = "reportDataSet"
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_apartados", "@ALMClave", a.SucursalOrigen, "@Dias", a.VencimientoDias))
            OpenReport.PrintPreview("Reporte de Cobranza", "CRApartados.rpt", pvtaDataSet, "")

        End If
        a.Dispose()
    End Sub
End Class
