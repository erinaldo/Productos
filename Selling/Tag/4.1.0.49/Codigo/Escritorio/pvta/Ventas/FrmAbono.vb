Public Class FrmAbono
    Inherits System.Windows.Forms.Form
    Implements ITeclado

    Public SUCClave As String
    Public dtDocumentos, dtComision As DataTable
    Public CTEClave As String
    Public ConfirmarAbono As Integer = 0
    Public Nota As String
    Public ClaveCliente As String = ""
    Public NombreCliente As String
    Public InterfazSalida As String = ""
    Public Aplicacion As String = ""
    Public bTouch As Boolean = False
    Public bAnticipo As Boolean = False
    Public Pagado As Boolean = False
    Public id_evento As String = ""
    Public sIdTerminal As String = ""
    Public PinPadNumero As String = ""
    Public PagoCXC As Boolean = False

    Private CobranzaVenta As Boolean = False
    Private TipoVenta As String = ""
    Private MonRef As String
    Private Moneda, MonedaCambio As String
    Private Tipo As Integer = 1
    Private TipoDoc As Integer  '1: Ticket, 2:Factura
    Private DocumentoClave As String
    Private ABNClave As String
    Private sClaveSAT As String
    Private ValidaCtaPago As Integer = 1
    Private Folio As String
    Private SaldoDocumento, SaldoOriginal As Decimal
    Private bEfectivo, bCheque, bTarjeta As Boolean
    Private CAJClave, Referencia As String
    Private SaldoPuntos As Decimal
    Private Multiple As Boolean = False
    Private Cajon As Boolean = False
    Private Impresora As String
    Private TipoCambio As Decimal
    Private TotalPago As Decimal = 0
    Private Monto As Decimal = 0
    Private MontoCobro As Decimal = 0
    Private Cambio As Decimal = 0
    Private bError As Boolean = False
    Private alerta(9) As PictureBox
    Private reloj As parpadea
    Private FormaPagoLoad As Boolean = False
    Private iPublicoGral As Integer = 0
    Private FolioAbono As String
    Private terminalPinPad As Boolean = False
    Private PorcentajeCargo As Decimal = 0
    Private pagosPinPad As Boolean = False
    Private pagosTarjetaAmiga As Boolean = False
    Private seleccionarBank As Boolean = False
    Private numAutorizacion, refFinanciera, secuenciaPinPad, afiliacion, transaccion, meses As String
    Private maxMesesSinIntereses As Integer = 0
    Private montoMinSinIntereses As Decimal = 0
    Private pagoTA As Boolean = False
    Private sIdComercio As String
    Private TallaColor As Integer
    Private dtMetodosPago, dtDetallePago As DataTable
    Private textBoxActual As Control
    Private metodoPagoI As Integer
    Private metodoPagoS As String
    Private dtTerminal As DataTable
    Private cargaLlaves As Boolean = False
    Private puntos As Decimal = 0
    Private aid, arqc, puntosAnterior, puntosRedimidos, puntosActual As String
    Private firmaElectronica As Integer = 0

    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LblPuntos As System.Windows.Forms.Label
    Friend WithEvents BtnTC As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents GrpMetodos As System.Windows.Forms.GroupBox
    Friend WithEvents GridMetodos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblReferencia As System.Windows.Forms.Label
    Friend WithEvents LblBanco As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblFolio As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents picKeyboard As System.Windows.Forms.PictureBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents LblCte As System.Windows.Forms.Label
    Friend WithEvents btnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents lblTerminal As System.Windows.Forms.Label
    Friend WithEvents cmbTerminal As Selling.StoreCombo
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents lblMonedaCambio As System.Windows.Forms.Label
    Friend WithEvents TxtNumCta As System.Windows.Forms.TextBox
    Friend WithEvents lblNumCta As System.Windows.Forms.Label
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents txtNota As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents cmbFechaPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBeneficiaria As System.Windows.Forms.Label
    Friend WithEvents cmbBeneficiaria As Selling.StoreCombo
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtTarj As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents LblTarjeta As System.Windows.Forms.Label
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents LblMeses As System.Windows.Forms.Label
    Friend WithEvents numMeses As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnLlaves As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblSaldoTarjeta As System.Windows.Forms.Label
    Friend WithEvents txtSaldoTarjeta As System.Windows.Forms.Label
    Friend WithEvents lblTotalPiezas As System.Windows.Forms.Label
    Friend WithEvents CtxDocumentos As System.Windows.Forms.ContextMenuStrip


    Public WriteOnly Property ImpresoraCajon() As String
        Set(ByVal Value As String)
            Impresora = Value
        End Set
    End Property

    Public WriteOnly Property AperturaCajon() As Boolean
        Set(ByVal Value As Boolean)
            Cajon = Value
        End Set
    End Property

    Public WriteOnly Property SaldoAcumulado() As Double
        Set(ByVal Value As Double)
            SaldoDocumento = Value
        End Set
    End Property

    Public WriteOnly Property VariosPagos() As Boolean
        Set(ByVal Value As Boolean)
            Multiple = Value
        End Set
    End Property


    Public WriteOnly Property TipoDocumento() As Integer
        Set(ByVal Value As Integer)
            TipoDoc = Value
        End Set
    End Property

    Public WriteOnly Property ClaveDocumento() As String
        Set(ByVal Value As String)
            DocumentoClave = Value
        End Set
    End Property

    Public WriteOnly Property CAJA() As String
        Set(ByVal Value As String)
            CAJClave = Value
        End Set
    End Property

    Public WriteOnly Property ClaveCaja() As String
        Set(ByVal Value As String)
            Referencia = Value
        End Set
    End Property


    Public WriteOnly Property ClaveCte() As String
        Set(ByVal Value As String)
            CTEClave = Value
        End Set
    End Property

    Public ReadOnly Property TotalAbono As Double
        Get
            TotalAbono = TotalPago
        End Get
    End Property

    Public ReadOnly Property SaldoVenta() As Double
        Get
            SaldoVenta = SaldoOriginal
        End Get
    End Property

    Public ReadOnly Property TotalCambio() As Double
        Get
            TotalCambio = Cambio
        End Get
    End Property

    Public ReadOnly Property detallePago() As DataTable
        Get
            detallePago = dtDetallePago
        End Get
    End Property

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblSaldo As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents GrpAbono As System.Windows.Forms.GroupBox
    Friend WithEvents cmbMetodoPago As Selling.StoreCombo
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents CmbBanco As Selling.StoreCombo
    Friend WithEvents TxtMonto As Janus.Windows.GridEX.EditControls.NumericEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAbono))
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GrpAbono = New System.Windows.Forms.GroupBox()
        Me.btnLlaves = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.LblMeses = New System.Windows.Forms.Label()
        Me.numMeses = New System.Windows.Forms.NumericUpDown()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.LblTarjeta = New System.Windows.Forms.Label()
        Me.TxtTarj = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.lblBeneficiaria = New System.Windows.Forms.Label()
        Me.cmbBeneficiaria = New Selling.StoreCombo()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.cmbFechaPago = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.lblNumCta = New System.Windows.Forms.Label()
        Me.TxtNumCta = New System.Windows.Forms.TextBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.lblTerminal = New System.Windows.Forms.Label()
        Me.cmbTerminal = New Selling.StoreCombo()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblReferencia = New System.Windows.Forms.Label()
        Me.LblBanco = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblTipoCambio = New System.Windows.Forms.Label()
        Me.BtnTC = New Janus.Windows.EditControls.UIButton()
        Me.CtxDocumentos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.cmbMetodoPago = New Selling.StoreCombo()
        Me.TxtMonto = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.CmbBanco = New Selling.StoreCombo()
        Me.LblSaldo = New System.Windows.Forms.Label()
        Me.BtnOK = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblPuntos = New System.Windows.Forms.Label()
        Me.GrpMetodos = New System.Windows.Forms.GroupBox()
        Me.GridMetodos = New Janus.Windows.GridEX.GridEX()
        Me.LblFolio = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.picKeyboard = New System.Windows.Forms.PictureBox()
        Me.GrpDetalle = New System.Windows.Forms.GroupBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.LblCte = New System.Windows.Forms.Label()
        Me.btnBuscaCte = New Janus.Windows.EditControls.UIButton()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.lblMonedaCambio = New System.Windows.Forms.Label()
        Me.txtNota = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSaldoTarjeta = New System.Windows.Forms.Label()
        Me.txtSaldoTarjeta = New System.Windows.Forms.Label()
        Me.lblTotalPiezas = New System.Windows.Forms.Label()
        Me.GrpAbono.SuspendLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMeses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GrpMetodos.SuspendLayout()
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label12.Location = New System.Drawing.Point(10, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 23)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "FOLIO"
        '
        'GrpAbono
        '
        Me.GrpAbono.Controls.Add(Me.btnLlaves)
        Me.GrpAbono.Controls.Add(Me.PictureBox10)
        Me.GrpAbono.Controls.Add(Me.LblMeses)
        Me.GrpAbono.Controls.Add(Me.numMeses)
        Me.GrpAbono.Controls.Add(Me.PictureBox9)
        Me.GrpAbono.Controls.Add(Me.LblTarjeta)
        Me.GrpAbono.Controls.Add(Me.TxtTarj)
        Me.GrpAbono.Controls.Add(Me.PictureBox8)
        Me.GrpAbono.Controls.Add(Me.lblBeneficiaria)
        Me.GrpAbono.Controls.Add(Me.cmbBeneficiaria)
        Me.GrpAbono.Controls.Add(Me.lblFecha)
        Me.GrpAbono.Controls.Add(Me.cmbFechaPago)
        Me.GrpAbono.Controls.Add(Me.PictureBox7)
        Me.GrpAbono.Controls.Add(Me.lblNumCta)
        Me.GrpAbono.Controls.Add(Me.TxtNumCta)
        Me.GrpAbono.Controls.Add(Me.PictureBox6)
        Me.GrpAbono.Controls.Add(Me.lblTerminal)
        Me.GrpAbono.Controls.Add(Me.cmbTerminal)
        Me.GrpAbono.Controls.Add(Me.PictureBox1)
        Me.GrpAbono.Controls.Add(Me.PictureBox2)
        Me.GrpAbono.Controls.Add(Me.PictureBox4)
        Me.GrpAbono.Controls.Add(Me.Label6)
        Me.GrpAbono.Controls.Add(Me.LblReferencia)
        Me.GrpAbono.Controls.Add(Me.LblBanco)
        Me.GrpAbono.Controls.Add(Me.Label3)
        Me.GrpAbono.Controls.Add(Me.Label5)
        Me.GrpAbono.Controls.Add(Me.LblTipoCambio)
        Me.GrpAbono.Controls.Add(Me.BtnTC)
        Me.GrpAbono.Controls.Add(Me.PictureBox5)
        Me.GrpAbono.Controls.Add(Me.cmbMetodoPago)
        Me.GrpAbono.Controls.Add(Me.TxtMonto)
        Me.GrpAbono.Controls.Add(Me.TxtReferencia)
        Me.GrpAbono.Controls.Add(Me.PictureBox3)
        Me.GrpAbono.Controls.Add(Me.CmbBanco)
        Me.GrpAbono.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpAbono.Location = New System.Drawing.Point(6, 133)
        Me.GrpAbono.Name = "GrpAbono"
        Me.GrpAbono.Size = New System.Drawing.Size(775, 139)
        Me.GrpAbono.TabIndex = 0
        Me.GrpAbono.TabStop = False
        Me.GrpAbono.Text = "Registro de Abono"
        '
        'btnLlaves
        '
        Me.btnLlaves.Icon = CType(resources.GetObject("btnLlaves.Icon"), System.Drawing.Icon)
        Me.btnLlaves.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnLlaves.Location = New System.Drawing.Point(264, 77)
        Me.btnLlaves.Name = "btnLlaves"
        Me.btnLlaves.Size = New System.Drawing.Size(44, 27)
        Me.btnLlaves.TabIndex = 114
        Me.btnLlaves.ToolTipText = "Carga de llaves"
        Me.btnLlaves.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(662, 79)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox10.TabIndex = 113
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'LblMeses
        '
        Me.LblMeses.AutoSize = True
        Me.LblMeses.Location = New System.Drawing.Point(551, 80)
        Me.LblMeses.Name = "LblMeses"
        Me.LblMeses.Size = New System.Drawing.Size(133, 17)
        Me.LblMeses.TabIndex = 112
        Me.LblMeses.Text = "Meses sin intereses"
        '
        'numMeses
        '
        Me.numMeses.Location = New System.Drawing.Point(690, 77)
        Me.numMeses.Name = "numMeses"
        Me.numMeses.Size = New System.Drawing.Size(66, 23)
        Me.numMeses.TabIndex = 111
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(734, 106)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox9.TabIndex = 110
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'LblTarjeta
        '
        Me.LblTarjeta.Location = New System.Drawing.Point(488, 109)
        Me.LblTarjeta.Name = "LblTarjeta"
        Me.LblTarjeta.Size = New System.Drawing.Size(80, 16)
        Me.LblTarjeta.TabIndex = 109
        Me.LblTarjeta.Text = "No. Tarjeta"
        Me.LblTarjeta.Visible = False
        '
        'TxtTarj
        '
        Me.TxtTarj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTarj.Location = New System.Drawing.Point(574, 106)
        Me.TxtTarj.Mask = "0000-0000-0000-0000"
        Me.TxtTarj.Name = "TxtTarj"
        Me.TxtTarj.Size = New System.Drawing.Size(158, 26)
        Me.TxtTarj.TabIndex = 108
        Me.TxtTarj.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtTarj.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(454, 106)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox8.TabIndex = 107
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'lblBeneficiaria
        '
        Me.lblBeneficiaria.Location = New System.Drawing.Point(7, 109)
        Me.lblBeneficiaria.Name = "lblBeneficiaria"
        Me.lblBeneficiaria.Size = New System.Drawing.Size(122, 23)
        Me.lblBeneficiaria.TabIndex = 106
        Me.lblBeneficiaria.Text = "Cta. Beneficiaria"
        '
        'cmbBeneficiaria
        '
        Me.cmbBeneficiaria.BackColor = System.Drawing.SystemColors.Window
        Me.cmbBeneficiaria.Location = New System.Drawing.Point(135, 106)
        Me.cmbBeneficiaria.Name = "cmbBeneficiaria"
        Me.cmbBeneficiaria.Size = New System.Drawing.Size(313, 24)
        Me.cmbBeneficiaria.TabIndex = 105
        '
        'lblFecha
        '
        Me.lblFecha.Location = New System.Drawing.Point(264, 80)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(69, 23)
        Me.lblFecha.TabIndex = 104
        Me.lblFecha.Text = "F. Pago"
        '
        'cmbFechaPago
        '
        Me.cmbFechaPago.CustomFormat = "dd/MM/yyyy hh:mm:ss"
        Me.cmbFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.cmbFechaPago.Location = New System.Drawing.Point(335, 77)
        Me.cmbFechaPago.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaPago.Name = "cmbFechaPago"
        Me.cmbFechaPago.Size = New System.Drawing.Size(209, 23)
        Me.cmbFechaPago.TabIndex = 103
        Me.cmbFechaPago.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(596, 25)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox7.TabIndex = 88
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'lblNumCta
        '
        Me.lblNumCta.AutoSize = True
        Me.lblNumCta.Location = New System.Drawing.Point(551, 26)
        Me.lblNumCta.Name = "lblNumCta"
        Me.lblNumCta.Size = New System.Drawing.Size(70, 17)
        Me.lblNumCta.TabIndex = 87
        Me.lblNumCta.Text = "Núm. Cta."
        '
        'TxtNumCta
        '
        Me.TxtNumCta.Location = New System.Drawing.Point(550, 50)
        Me.TxtNumCta.Name = "TxtNumCta"
        Me.TxtNumCta.Size = New System.Drawing.Size(71, 23)
        Me.TxtNumCta.TabIndex = 86
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(56, 80)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox6.TabIndex = 85
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'lblTerminal
        '
        Me.lblTerminal.AutoSize = True
        Me.lblTerminal.Location = New System.Drawing.Point(7, 80)
        Me.lblTerminal.Name = "lblTerminal"
        Me.lblTerminal.Size = New System.Drawing.Size(67, 17)
        Me.lblTerminal.TabIndex = 84
        Me.lblTerminal.Text = "Terminal "
        '
        'cmbTerminal
        '
        Me.cmbTerminal.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTerminal.Location = New System.Drawing.Point(85, 77)
        Me.cmbTerminal.Name = "cmbTerminal"
        Me.cmbTerminal.Size = New System.Drawing.Size(173, 24)
        Me.cmbTerminal.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(56, 25)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox1.TabIndex = 63
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(236, 25)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox2.TabIndex = 69
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(522, 25)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox4.TabIndex = 65
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(629, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 16)
        Me.Label6.TabIndex = 82
        Me.Label6.Text = "Monto"
        '
        'LblReferencia
        '
        Me.LblReferencia.AutoSize = True
        Me.LblReferencia.Location = New System.Drawing.Point(451, 26)
        Me.LblReferencia.Name = "LblReferencia"
        Me.LblReferencia.Size = New System.Drawing.Size(77, 17)
        Me.LblReferencia.TabIndex = 81
        Me.LblReferencia.Text = "Referencia"
        '
        'LblBanco
        '
        Me.LblBanco.AutoSize = True
        Me.LblBanco.Location = New System.Drawing.Point(264, 26)
        Me.LblBanco.Name = "LblBanco"
        Me.LblBanco.Size = New System.Drawing.Size(48, 17)
        Me.LblBanco.TabIndex = 80
        Me.LblBanco.Text = "Banco"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 17)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "Moneda"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(85, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 17)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "Metodo de Pago"
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.BackColor = System.Drawing.Color.Transparent
        Me.LblTipoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipoCambio.ForeColor = System.Drawing.Color.Navy
        Me.LblTipoCambio.Location = New System.Drawing.Point(550, 80)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(206, 15)
        Me.LblTipoCambio.TabIndex = 77
        Me.LblTipoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnTC
        '
        Me.BtnTC.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton
        Me.BtnTC.ContextMenuStrip = Me.CtxDocumentos
        Me.BtnTC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTC.Location = New System.Drawing.Point(7, 45)
        Me.BtnTC.Name = "BtnTC"
        Me.BtnTC.Size = New System.Drawing.Size(71, 28)
        Me.BtnTC.TabIndex = 1
        Me.BtnTC.Text = "MXN"
        Me.BtnTC.ToolTipText = "Elejir Moneda"
        Me.BtnTC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CtxDocumentos
        '
        Me.CtxDocumentos.Name = "CtxDocumentos"
        Me.CtxDocumentos.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.CtxDocumentos.Size = New System.Drawing.Size(61, 4)
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(685, 24)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox5.TabIndex = 76
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'cmbMetodoPago
        '
        Me.cmbMetodoPago.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMetodoPago.Location = New System.Drawing.Point(85, 49)
        Me.cmbMetodoPago.Name = "cmbMetodoPago"
        Me.cmbMetodoPago.Size = New System.Drawing.Size(173, 24)
        Me.cmbMetodoPago.TabIndex = 2
        '
        'TxtMonto
        '
        Me.TxtMonto.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.TxtMonto.Location = New System.Drawing.Point(627, 50)
        Me.TxtMonto.Name = "TxtMonto"
        Me.TxtMonto.Size = New System.Drawing.Size(129, 23)
        Me.TxtMonto.TabIndex = 0
        Me.TxtMonto.Text = "$0.00"
        Me.TxtMonto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtMonto.Value = 0.0R
        Me.TxtMonto.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(454, 50)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(90, 23)
        Me.TxtReferencia.TabIndex = 4
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(318, 25)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox3.TabIndex = 65
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'CmbBanco
        '
        Me.CmbBanco.BackColor = System.Drawing.SystemColors.Window
        Me.CmbBanco.Location = New System.Drawing.Point(264, 49)
        Me.CmbBanco.Name = "CmbBanco"
        Me.CmbBanco.Size = New System.Drawing.Size(184, 24)
        Me.CmbBanco.TabIndex = 3
        '
        'LblSaldo
        '
        Me.LblSaldo.BackColor = System.Drawing.Color.Transparent
        Me.LblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaldo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblSaldo.Location = New System.Drawing.Point(447, 50)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(321, 37)
        Me.LblSaldo.TabIndex = 63
        Me.LblSaldo.Text = "$0.00 M.N"
        Me.LblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(687, 458)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 37)
        Me.BtnOK.TabIndex = 4
        Me.BtnOK.Text = "Aceptar"
        Me.BtnOK.ToolTipText = "Guardar cambios"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(591, 458)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.LblPuntos)
        Me.GroupBox2.Location = New System.Drawing.Point(298, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(476, 42)
        Me.GroupBox2.TabIndex = 67
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 16)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "SALDO EN PUNTOS:"
        '
        'LblPuntos
        '
        Me.LblPuntos.BackColor = System.Drawing.Color.Transparent
        Me.LblPuntos.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPuntos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblPuntos.Location = New System.Drawing.Point(166, 5)
        Me.LblPuntos.Name = "LblPuntos"
        Me.LblPuntos.Size = New System.Drawing.Size(304, 37)
        Me.LblPuntos.TabIndex = 67
        Me.LblPuntos.Text = "$0.00 M.N"
        Me.LblPuntos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GrpMetodos
        '
        Me.GrpMetodos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpMetodos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpMetodos.Controls.Add(Me.GridMetodos)
        Me.GrpMetodos.Location = New System.Drawing.Point(7, 278)
        Me.GrpMetodos.Name = "GrpMetodos"
        Me.GrpMetodos.Size = New System.Drawing.Size(303, 174)
        Me.GrpMetodos.TabIndex = 73
        Me.GrpMetodos.TabStop = False
        Me.GrpMetodos.Text = "Metodos Preferidos de Pago (Doble Click para Usar)"
        '
        'GridMetodos
        '
        Me.GridMetodos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridMetodos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMetodos.ColumnAutoResize = True
        Me.GridMetodos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridMetodos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridMetodos.Location = New System.Drawing.Point(7, 15)
        Me.GridMetodos.Name = "GridMetodos"
        Me.GridMetodos.RecordNavigator = True
        Me.GridMetodos.Size = New System.Drawing.Size(291, 152)
        Me.GridMetodos.TabIndex = 1
        Me.GridMetodos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LblFolio
        '
        Me.LblFolio.AutoSize = True
        Me.LblFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFolio.Location = New System.Drawing.Point(86, 19)
        Me.LblFolio.Name = "LblFolio"
        Me.LblFolio.Size = New System.Drawing.Size(0, 20)
        Me.LblFolio.TabIndex = 84
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(304, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 16)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "SALDO EFECTIVO"
        '
        'picKeyboard
        '
        Me.picKeyboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picKeyboard.BackColor = System.Drawing.Color.Transparent
        Me.picKeyboard.Image = Global.Selling.My.Resources.Resources._1403657593_519640_141_Keyboard
        Me.picKeyboard.Location = New System.Drawing.Point(12, 462)
        Me.picKeyboard.Name = "picKeyboard"
        Me.picKeyboard.Size = New System.Drawing.Size(35, 33)
        Me.picKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picKeyboard.TabIndex = 86
        Me.picKeyboard.TabStop = False
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Location = New System.Drawing.Point(316, 278)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(465, 174)
        Me.GrpDetalle.TabIndex = 87
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle de Pago"
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
        Me.GridDetalle.Location = New System.Drawing.Point(7, 15)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(453, 152)
        Me.GridDetalle.TabIndex = 1
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LblCte
        '
        Me.LblCte.BackColor = System.Drawing.Color.Transparent
        Me.LblCte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblCte.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblCte.Location = New System.Drawing.Point(11, 91)
        Me.LblCte.Name = "LblCte"
        Me.LblCte.Size = New System.Drawing.Size(48, 20)
        Me.LblCte.TabIndex = 90
        Me.LblCte.Text = "CTE:"
        Me.LblCte.Visible = False
        '
        'btnBuscaCte
        '
        Me.btnBuscaCte.Icon = CType(resources.GetObject("btnBuscaCte.Icon"), System.Drawing.Icon)
        Me.btnBuscaCte.Image = CType(resources.GetObject("btnBuscaCte.Image"), System.Drawing.Image)
        Me.btnBuscaCte.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnBuscaCte.Location = New System.Drawing.Point(187, 84)
        Me.btnBuscaCte.Name = "btnBuscaCte"
        Me.btnBuscaCte.Size = New System.Drawing.Size(44, 27)
        Me.btnBuscaCte.TabIndex = 89
        Me.btnBuscaCte.ToolTipText = "Busqueda de Cliente"
        Me.btnBuscaCte.Visible = False
        Me.btnBuscaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(68, 90)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(113, 20)
        Me.TxtCliente.TabIndex = 88
        Me.TxtCliente.Visible = False
        '
        'LblCliente
        '
        Me.LblCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCliente.BackColor = System.Drawing.Color.Transparent
        Me.LblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCliente.Location = New System.Drawing.Point(9, 116)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(473, 14)
        Me.LblCliente.TabIndex = 91
        Me.LblCliente.Visible = False
        '
        'lblMonedaCambio
        '
        Me.lblMonedaCambio.BackColor = System.Drawing.Color.Transparent
        Me.lblMonedaCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonedaCambio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblMonedaCambio.Location = New System.Drawing.Point(466, 84)
        Me.lblMonedaCambio.Name = "lblMonedaCambio"
        Me.lblMonedaCambio.Size = New System.Drawing.Size(296, 20)
        Me.lblMonedaCambio.TabIndex = 92
        Me.lblMonedaCambio.Text = "$0.00 M.N"
        Me.lblMonedaCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblMonedaCambio.Visible = False
        '
        'txtNota
        '
        Me.txtNota.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNota.Location = New System.Drawing.Point(92, 469)
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(459, 20)
        Me.txtNota.TabIndex = 93
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 472)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Nota"
        '
        'lblSaldoTarjeta
        '
        Me.lblSaldoTarjeta.AutoSize = True
        Me.lblSaldoTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoTarjeta.Location = New System.Drawing.Point(304, 116)
        Me.lblSaldoTarjeta.Name = "lblSaldoTarjeta"
        Me.lblSaldoTarjeta.Size = New System.Drawing.Size(131, 16)
        Me.lblSaldoTarjeta.TabIndex = 94
        Me.lblSaldoTarjeta.Text = "SALDO TARJETA"
        Me.lblSaldoTarjeta.Visible = False
        '
        'txtSaldoTarjeta
        '
        Me.txtSaldoTarjeta.BackColor = System.Drawing.Color.Transparent
        Me.txtSaldoTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoTarjeta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtSaldoTarjeta.Location = New System.Drawing.Point(447, 107)
        Me.txtSaldoTarjeta.Name = "txtSaldoTarjeta"
        Me.txtSaldoTarjeta.Size = New System.Drawing.Size(321, 29)
        Me.txtSaldoTarjeta.TabIndex = 95
        Me.txtSaldoTarjeta.Text = "$0.00 M.N"
        Me.txtSaldoTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.txtSaldoTarjeta.Visible = False
        '
        'lblTotalPiezas
        '
        Me.lblTotalPiezas.AutoSize = True
        Me.lblTotalPiezas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPiezas.Location = New System.Drawing.Point(11, 50)
        Me.lblTotalPiezas.Name = "lblTotalPiezas"
        Me.lblTotalPiezas.Size = New System.Drawing.Size(130, 16)
        Me.lblTotalPiezas.TabIndex = 96
        Me.lblTotalPiezas.Text = "TOTAL PIEZAS: 0"
        Me.lblTotalPiezas.Visible = False
        '
        'FrmAbono
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 503)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblTotalPiezas)
        Me.Controls.Add(Me.txtSaldoTarjeta)
        Me.Controls.Add(Me.lblSaldoTarjeta)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNota)
        Me.Controls.Add(Me.lblMonedaCambio)
        Me.Controls.Add(Me.LblCte)
        Me.Controls.Add(Me.btnBuscaCte)
        Me.Controls.Add(Me.TxtCliente)
        Me.Controls.Add(Me.LblCliente)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.picKeyboard)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblFolio)
        Me.Controls.Add(Me.GrpMetodos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LblSaldo)
        Me.Controls.Add(Me.GrpAbono)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.BtnCancel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(553, 393)
        Me.Name = "FrmAbono"
        Me.Text = "Pagos"
        Me.GrpAbono.ResumeLayout(False)
        Me.GrpAbono.PerformLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMeses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GrpMetodos.ResumeLayout(False)
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDetalle.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmAbono_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If cargaLlaves Then
            modificarArchivo()
        End If
        If bError = False AndAlso Aplicacion <> "" Then
            If sClaveSAT = "04" OrElse sClaveSAT = "28" Then
                Shell(Aplicacion, AppWinStyle.NormalFocus)
            End If
        End If

        If bError Then
            e.Cancel = True
        End If
    End Sub

    Public Function modificarArchivo()
        Dim El_Archivo As String
        Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent
        Dim dir As String = DirActual.FullName()
        El_Archivo = dir & "\PinpadConfig.txt"
        Dim archivoCopia As String = dir & "\PinpadConfig1.txt"
        Try
            Dim lector As IO.StreamReader = IO.File.OpenText(El_Archivo)

            Do While lector.Peek() >= 0
                dir = lector.ReadLine

                Dim escritor As IO.StreamWriter = IO.File.AppendText(archivoCopia)
                If dir.Contains("CARGALLAVE:") Then
                    dir = dir.Replace("1", "0")
                End If
                escritor.WriteLine(dir)
                escritor.Flush()
                escritor.Close()
                escritor.Dispose()
            Loop
            lector.Close()
            lector.Dispose()
            IO.File.Delete(El_Archivo)
            FileSystem.Rename(archivoCopia, El_Archivo)
        Catch ex As Exception

        End Try
    End Function

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        'valida que se encuentre una forma de pago seleccionada
        If cmbMetodoPago.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        Else
            If pagoTA Then

                If TxtTarj.Text = "" Then
                    i += 1
                    reloj = New parpadea(Me.alerta(8))
                    reloj.Enabled = True
                    reloj.Start()
                    MessageBox.Show("El número de tarjeta es querido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                If TxtTarj.Text <> "" AndAlso TxtTarj.Text.Length <> 19 Then
                    i += 1
                    reloj = New parpadea(Me.alerta(8))
                    reloj.Enabled = True
                    reloj.Start()
                    MessageBox.Show("El numero de tarjeta debe contener 16 digitos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                Select Case sClaveSAT
                    Case "04", "28"

                        'Valida Terminal
                        If ValidaCtaPago = 1 AndAlso cmbTerminal.SelectedValue Is Nothing Then
                            i += 1
                            reloj = New parpadea(Me.alerta(5))
                            reloj.Enabled = True
                            reloj.Start()
                        End If

                        'Valida Banco
                        If ValidaCtaPago = 1 AndAlso CmbBanco.SelectedValue Is Nothing AndAlso terminalPinPad = False Then
                            i += 1
                            reloj = New parpadea(Me.alerta(2))
                            reloj.Enabled = True
                            reloj.Start()
                        End If

                        'Valida Referencia

                        If ValidaCtaPago = 1 AndAlso TxtReferencia.Text = "" AndAlso terminalPinPad = False Then
                            i += 1
                            reloj = New parpadea(Me.alerta(3))
                            reloj.Enabled = True
                            reloj.Start()
                            MessageBox.Show("La referencia requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If

                        If TxtReferencia.Text <> "" AndAlso TxtReferencia.TextLength < 4 Then
                            i += 1
                            reloj = New parpadea(Me.alerta(3))
                            reloj.Enabled = True
                            reloj.Start()
                            MessageBox.Show("La referencia debe contener al menos 4 carates o digitos. Por ejemplo los ultimos 4 digitos de la tarjea o de la cuenta bancaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If

                        'Valida Num Cta
                        If TxtNumCta.Text <> "" AndAlso TxtNumCta.TextLength < 4 Then
                            i += 1
                            reloj = New parpadea(Me.alerta(6))
                            reloj.Enabled = True
                            reloj.Start()
                            MessageBox.Show("El número de cuenta debe contener minimo los ultimos 4 digitos de la cuenta bancaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If

                        If terminalPinPad AndAlso numMeses.Value > 0 AndAlso CDbl(TxtMonto.Text) < montoMinSinIntereses Then
                            i += 1
                            reloj = New parpadea(Me.alerta(9))
                            reloj.Enabled = True
                            reloj.Start()
                            MessageBox.Show("El monto no cumple con el minimo para meses sin intereses", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If

                    Case "02"

                        If ValidaCtaPago = 1 AndAlso CmbBanco.SelectedValue Is Nothing Then
                            i += 1
                            reloj = New parpadea(Me.alerta(2))
                            reloj.Enabled = True
                            reloj.Start()
                        End If

                        'Valida Referencia
                        If ValidaCtaPago = 1 AndAlso TxtReferencia.Text = "" Then
                            i += 1
                            reloj = New parpadea(Me.alerta(3))
                            reloj.Enabled = True
                            reloj.Start()
                            MessageBox.Show("El número de cheque es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If

                        If TxtReferencia.Text <> "" AndAlso TxtReferencia.TextLength < 4 Then
                            Dim s As String
                            s = "000" & TxtReferencia.Text

                            TxtReferencia.Text = s.Substring(s.Length - 4, 4)
                        End If

                        'Valida Num Cta
                        If TxtNumCta.Text <> "" AndAlso TxtNumCta.TextLength < 4 Then
                            i += 1
                            reloj = New parpadea(Me.alerta(6))
                            reloj.Enabled = True
                            reloj.Start()
                            MessageBox.Show("El número de cuenta debe contener minimo los 4 ultimos digitos de la cuenta bancaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If

                        'Valida Beneficiaria
                        If cmbBeneficiaria.SelectedValue Is Nothing Then
                            i += 1
                            reloj = New parpadea(Me.alerta(7))
                            reloj.Enabled = True
                            reloj.Start()
                            MessageBox.Show("La Cta Beneficiaria es requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If

                    Case "29", "06", "05", "03"
                        If ValidaCtaPago = 1 AndAlso CmbBanco.SelectedValue Is Nothing Then
                            i += 1
                            reloj = New parpadea(Me.alerta(2))
                            reloj.Enabled = True
                            reloj.Start()
                        End If

                        'Valida Referencia
                        If ValidaCtaPago = 1 AndAlso TxtReferencia.Text = "" Then
                            i += 1
                            reloj = New parpadea(Me.alerta(3))
                            reloj.Enabled = True
                            reloj.Start()
                            MessageBox.Show("La referencia es requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If

                        If TxtReferencia.Text <> "" AndAlso TxtReferencia.TextLength < 6 Then
                            i += 1
                            reloj = New parpadea(Me.alerta(3))
                            reloj.Enabled = True
                            reloj.Start()
                            MessageBox.Show("La referencia debe contener  al menos 6 carates o digitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If

                        If TxtReferencia.Text <> "" AndAlso TxtReferencia.TextLength >= 6 AndAlso TxtReferencia.TextLength < 8 Then
                            Dim s As String
                            s = "000" & TxtReferencia.Text
                            TxtReferencia.Text = s.Substring(s.Length - 8, 8)
                        End If

                        'Valida Num Cta
                        If TxtNumCta.Text <> "" AndAlso TxtNumCta.TextLength < 4 Then
                            i += 1
                            reloj = New parpadea(Me.alerta(6))
                            reloj.Enabled = True
                            reloj.Start()
                            MessageBox.Show("El número de cuenta debe contener minimo los ultimos 4 digitos de la cuenta bancaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If


                        'Valida Beneficiaria
                        If cmbBeneficiaria.SelectedValue Is Nothing Then
                            i += 1
                            reloj = New parpadea(Me.alerta(7))
                            reloj.Enabled = True
                            reloj.Start()
                            MessageBox.Show("La Cta Beneficiaria es requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If

                    Case Else
                        If cmbMetodoPago.SelectedValue = 8 AndAlso CDbl(TxtMonto.Text) > SaldoPuntos Then
                            i += 1
                            reloj = New parpadea(Me.alerta(1))
                            reloj.Enabled = True
                            reloj.Start()
                            MessageBox.Show("¡Los Puntos seleccionados exceden a los acumulados de el Cliente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                End Select
            End If

        End If

        If TxtMonto.Text = "" Then
            Monto = 0
        Else
            Monto = Math.Abs(CDbl(TxtMonto.Text))
        End If

        'valida que el importe sea diferente de cero

        If Monto = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Private Sub recuperaCliente()

        Dim dt As DataTable

        If bAnticipo = False Then
            If Multiple Then
                Folio = "VARIOS"
                dt = ModPOS.Recupera_Tabla("sp_recupera_cte", "@Cliente", CTEClave)
                ClaveCliente = dt.Rows(0)("Clave")
                NombreCliente = dt.Rows(0)("RazonSocial")
                SaldoPuntos = IIf(dt.Rows(0)("Puntos").GetType.Name = "DBNull", 0, dt.Rows(0)("Puntos"))
                dt.Dispose()
                SaldoDocumento = 0
                For i As Integer = 0 To dtDocumentos.Rows.Count - 1
                    dt = ModPOS.Recupera_Tabla("sp_recupera_saldo", "@Tipo", dtDocumentos.Rows(i)("TipoDocumento"), "@Clave", dtDocumentos.Rows(i)("ID"))
                    SaldoDocumento += dt.Rows(0)("Saldo") * dt.Rows(0)("TipoCambio")
                    TipoVenta = dt.Rows(0)("Tipo")
                Next
            Else
                dt = ModPOS.Recupera_Tabla("sp_recupera_saldo", "@Tipo", TipoDoc, "@Clave", DocumentoClave)
                Folio = dt.Rows(0)("Folio")
                ClaveCliente = dt.Rows(0)("Clave")
                NombreCliente = dt.Rows(0)("RazonSocial")
                SaldoPuntos = dt.Rows(0)("Puntos")
                SaldoDocumento = dt.Rows(0)("Saldo") * dt.Rows(0)("TipoCambio")
                TipoVenta = dt.Rows(0)("Tipo")
                dt.Dispose()
            End If
        Else
            Folio = "ANTICIPO"
            dt = ModPOS.Recupera_Tabla("sp_recupera_cte", "@Cliente", CTEClave)
            ClaveCliente = dt.Rows(0)("Clave")
            NombreCliente = dt.Rows(0)("RazonSocial")

            TxtCliente.Text = ClaveCliente
            LblCliente.Text = NombreCliente

            SaldoPuntos = IIf(dt.Rows(0)("Puntos").GetType.Name = "DBNull", 0, dt.Rows(0)("Puntos"))
            dt.Dispose()
            SaldoDocumento = 0
        End If

        dt = ModPOS.Recupera_Tabla("sp_valida_publicogral", "@CTEClave", CTEClave)
        iPublicoGral = dt.Rows(0)("Publico")
        dt.Dispose()

        dtMetodosPago = ModPOS.Recupera_Tabla("sp_recupera_ctepago", "@CTEClave", CTEClave)

        With Me.GridMetodos
            .DataSource = dtMetodosPago
            .RetrieveStructure(True)
            .GroupByBoxVisible = False
            .RootTable.Columns("MTPClave").Visible = False
            .RootTable.Columns("MetodoPago").Visible = False
            .RootTable.Columns("BNKClave").Visible = False
            .CurrentTable.Columns("Tipo").Selectable = False
            .CurrentTable.Columns("Banco").Selectable = False
            .CurrentTable.Columns("Referencia").Selectable = False
        End With


        LblFolio.Text = Folio

        SaldoOriginal = SaldoDocumento

        LblSaldo.Text = MonRef & " " & Format(CStr(ModPOS.TruncateToDecimal(SaldoDocumento, 2)), "Currency")
        LblPuntos.Text = CStr(ModPOS.TruncateToDecimal(SaldoPuntos, 2))

        TxtMonto.Focus()
    End Sub


    Public Sub AddPago(ByVal iTipoPago As Integer, _
                       ByVal sMetodo As String, _
                       ByVal sMoneda As String, _
                       ByVal sMON As String, _
                       ByVal dTC As Decimal, _
                       ByVal dMonto As Decimal, _
                       ByVal sBNKClave As String, _
                       ByVal sBanco As String, _
                       ByVal sRef As String, _
                       ByVal sNumCta As String, _
                       ByVal sTERClave As String, _
                       ByVal dFechaPago As DateTime, _
                       ByVal sMETClave As String, _
                       ByVal numAutorizacion As String, _
                       ByVal referenciaFinanciera As String, _
                       ByVal secuencia As String, _
                       ByVal dImporteComision As Decimal, _
                       ByVal meses As String, _
                       ByVal puntos As Decimal, _
                       ByVal transaccion As String, _
                       ByVal aid As String, _
                       ByVal arqc As String, _
                       ByVal firmaElectronica As Integer, _
                       ByVal puntosAnterior As String, _
                       ByVal puntosRedimidos As String, _
                       ByVal puntosActual As String)



        Select Case sClaveSAT
            Case "04", "28"

            Case "02", "29", "06", "05", "03"
                sTERClave = ""
            Case Else
                sBNKClave = ""
                sBanco = ""
                sTERClave = ""
                sRef = ""
                sNumCta = ""
        End Select


        Dim foundRows() As Data.DataRow
        foundRows = dtDetallePago.Select("TipoPago = " & iTipoPago & " and Moneda = '" & sMoneda & "' and BNKClave ='" & sBNKClave & "' and Ref = '" & sRef & "' and NumCta = '" & sNumCta & "' and NoAutorizacion = '" & numAutorizacion & "' and RefFinanciera = '" & referenciaFinanciera & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtDetallePago.NewRow()
            'declara el nombre de la fila

            TotalPago += (dMonto * dTC)


            If bAnticipo = False AndAlso (dMonto * dTC) > SaldoDocumento Then
                dMonto = SaldoDocumento / dTC
            End If

            row1.Item("ABNClave") = ModPOS.obtenerLlave
            row1.Item("TipoPago") = iTipoPago
            row1.Item("Metodo") = sMetodo
            row1.Item("Moneda") = sMoneda
            row1.Item("MON") = sMON
            row1.Item("Monto") = dMonto
            row1.Item("BNKClave") = sBNKClave
            row1.Item("Banco") = sBanco
            row1.Item("Ref") = sRef
            row1.Item("NumCta") = sNumCta
            row1.Item("TERClave") = sTERClave
            row1.Item("SaldoBase") = dMonto * dTC
            row1.Item("TipoCambio") = dTC
            row1.Item("FechaPago") = dFechaPago
            row1.Item("METClave") = sMETClave
            row1.Item("NoAutorizacion") = numAutorizacion
            row1.Item("RefFinanciera") = referenciaFinanciera
            row1.Item("Secuencia") = secuencia
            row1.Item("ImporteComision") = dImporteComision
            row1.Item("meses") = meses
            row1.Item("puntos") = puntos
            row1.Item("transaccion") = transaccion
            row1.Item("aid") = aid
            row1.Item("arqc") = arqc
            row1.Item("firmaElectronica") = firmaElectronica
            row1.Item("puntosActual") = puntosActual
            row1.Item("puntosRedimidos") = puntosRedimidos
            row1.Item("puntosActual") = puntosActual


            dtDetallePago.Rows.Add(row1)
            'agrega la fila completo a la tabla

            SaldoDocumento -= (dMonto * dTC)
            If iTipoPago = 8 Then
                SaldoPuntos -= (dMonto * dTC)
            End If

            refFinanciera = ""
            numAutorizacion = ""
            secuenciaPinPad = ""
            TxtTarj.Text = ""
            puntos = 0
            meses = ""
            transaccion = ""
            If seleccionarBank Then
                cmbTerminal.Enabled = seleccionarBank
                cmbMetodoPago.Enabled = seleccionarBank
                TxtReferencia.Enabled = seleccionarBank
                TxtMonto.Enabled = seleccionarBank
                seleccionarBank = False
            End If


            If SaldoDocumento < 0 Then
                SaldoDocumento = 0
            End If

            LblSaldo.Text = MonRef & " " & Format(CStr(ModPOS.TruncateToDecimal(SaldoDocumento, 2)), "Currency")
            LblPuntos.Text = CStr(ModPOS.TruncateToDecimal(SaldoPuntos, 2))
            lblMonedaCambio.Text = BtnTC.Text & " " & Format(CStr(TruncateToDecimal(SaldoDocumento / TipoCambio, 2)), "Currency")


        End If
    End Sub

    Private Function ObtenerFolio() As String
        Dim Folio, Periodo, Mes As Integer
        Dim Clave As String
        Dim dt As DataTable

        dt = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 6, "@PDVClave", CAJClave)
        If dt Is Nothing Then
            ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 6, "@PDVClave", CAJClave)
            Folio = 1
            Periodo = Today.Year
            Mes = Today.Month
        Else

            Folio = CInt(dt.Rows(0)("UltimoConsecutivo")) + 1
            Periodo = dt.Rows(0)("Periodo")
            Mes = dt.Rows(0)("Mes")
            ModPOS.Ejecuta("sp_act_folio", "@Tipo", 6, "@PDVClave", CAJClave, "@Incremento", 1)

            dt.Dispose()
        End If

        Clave = "AB" & Referencia & Microsoft.VisualBasic.Right(CStr(Periodo), 2) & Microsoft.VisualBasic.Right("0" & CStr(Mes), 2) & "-" & CStr(Folio)

        Return Clave
    End Function



    Private Sub FrmAbono_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If bAnticipo = True Then
            LblCliente.Visible = True
            LblCte.Visible = True
            TxtCliente.Visible = True
            btnBuscaCte.Visible = True
            Tipo = 2

        End If

        Dim dt As DataTable
        Dim i As Integer


        dtComision = ModPOS.CrearTabla("DetalleComision", _
                                        "VENClave", "System.String", _
                                        "ImporteComision", "System.Decimal")

        dtDetallePago = ModPOS.CrearTabla("DetallePago", _
                     "ABNClave", "System.String", _
                     "TipoPago", "System.Int32", _
                     "Metodo", "System.String", _
                     "Moneda", "System.String", _
                     "MON", "System.String", _
                     "Monto", "System.Double", _
                     "BNKClave", "System.String", _
                     "Banco", "System.String", _
                     "Ref", "System.String", _
                     "NumCta", "System.String", _
                     "TERClave", "System.String", _
                     "SaldoBase", "System.Decimal", _
                     "TipoCambio", "System.Decimal", _
                     "FechaPago", "System.DateTime", _
                     "METClave", "System.String", _
                     "NoAutorizacion", "System.String", _
                     "RefFinanciera", "System.String", _
                     "Secuencia", "System.String", _
                     "ImporteComision", "System.Decimal", _
                     "meses", "System.String", _
                     "puntos", "System.Decimal", _
                     "transaccion", "System.String", _
                     "aid", "System.String", _
                     "arqc", "System.String", _
                     "firmaElectronica", "System.Int32", _
                     "puntosAnterior", "System.String", _
                     "puntosRedimidos", "System.String", _
                     "puntosActual", "System.String")

        GridDetalle.DataSource = dtDetallePago
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("ABNClave").Visible = False
        GridDetalle.RootTable.Columns("TipoPago").Visible = False
        GridDetalle.CurrentTable.Columns("Metodo").Selectable = False
        GridDetalle.RootTable.Columns("Moneda").Visible = False
        GridDetalle.RootTable.Columns("MON").Selectable = False
        GridDetalle.RootTable.Columns("TERClave").Visible = False
        GridDetalle.RootTable.Columns("SaldoBase").Visible = False
        GridDetalle.RootTable.Columns("TipoCambio").Visible = False
        GridDetalle.RootTable.Columns("FechaPago").Visible = False
        GridDetalle.RootTable.Columns("METClave").Visible = False
        GridDetalle.RootTable.Columns("BNKClave").Visible = False
        GridDetalle.RootTable.Columns("Banco").Selectable = False
        GridDetalle.RootTable.Columns("Monto").Selectable = False
        GridDetalle.RootTable.Columns("NoAutorizacion").Selectable = False
        GridDetalle.RootTable.Columns("RefFinanciera").Selectable = False
        GridDetalle.RootTable.Columns("Secuencia").Visible = False
        GridDetalle.RootTable.Columns("ImporteComision").Visible = False
        GridDetalle.RootTable.Columns("meses").Visible = False
        GridDetalle.RootTable.Columns("puntos").Visible = False
        GridDetalle.RootTable.Columns("transaccion").Visible = False
        GridDetalle.RootTable.Columns("aid").Visible = False
        GridDetalle.RootTable.Columns("arqc").Visible = False
        GridDetalle.RootTable.Columns("firmaElectronica").Visible = False
        GridDetalle.RootTable.Columns("puntosAnterior").Visible = False
        GridDetalle.RootTable.Columns("puntosRedimidos").Visible = False
        GridDetalle.RootTable.Columns("puntosActual").Visible = False
        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "CobranzaVenta"
                        CobranzaVenta = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", False, dt.Rows(i)("Valor"))
                    Case "Moneda"
                        Moneda = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "MonedaCambio"
                        MonedaCambio = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "ValidaCtaPago"
                        ValidaCtaPago = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 1, dt.Rows(i)("Valor"))
                    Case "MontoMinSinInteres"
                        montoMinSinIntereses = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                    Case "MaxMesesSinInteres"
                        maxMesesSinIntereses = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 1, dt.Rows(i)("Valor"))
                    Case "IdComercioTA"
                        sIdComercio = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "TallaColor"
                        TallaColor = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                End Select
            Next
        End With
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)

        MonRef = dt.Rows(0)("Referencia")
        TipoCambio = dt.Rows(0)("TipoCambio")
        dt.Dispose()

        BtnTC.Text = MonRef

        dt = ModPOS.Recupera_Tabla("sp_muestra_monedas", Nothing)
        For i = 0 To dt.Rows.Count - 1
            Me.CtxDocumentos.Items.Add(dt.Rows(i)("Referencia"))
        Next
        dt.Dispose()

        Me.StartPosition = FormStartPosition.CenterScreen

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

        With cmbMetodoPago
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_filtra_metodopago"
            .llenar()
        End With

        With CmbBanco
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_bancos"
            .llenar()
        End With

        CmbBanco.SelectedValue = -1

        dtTerminal = ModPOS.Recupera_Tabla("st_filtra_terminal", "CAJClave", CAJClave)

        With cmbTerminal
            .dt = dtTerminal
            .llenar()
        End With

        With cmbBeneficiaria
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_filtra_beneficiario"
            .NombreParametro1 = "CAJClave"
            .Parametro1 = CAJClave
            .NombreParametro2 = "MONClave"
            .Parametro2 = Moneda
            .llenar()
        End With


        If bAnticipo = False Then
            recuperaCliente()
        Else
            LblFolio.Text = "ANTICIPO"
        End If

        FormaPagoLoad = True
        meses = ""
        transaccion = ""
        puntos = 0
        ActMetodoPago(CInt(cmbMetodoPago.SelectedValue))

        TxtMonto.Text = "0.0"
        If TallaColor = 1 Then
            txtNota.Select()
            BtnCancel.TabStop = False
            If Not dtDocumentos Is Nothing Then
                lblTotalPiezas.Visible = True
                lblTotalPiezas.Text = "TOTAL DE PIEZAS: " & CStr(IIf(dtDocumentos.Compute("SUM(Piezas)", "") Is System.DBNull.Value, 0, dtDocumentos.Compute("SUM(Piezas)", "")))
            End If
        End If

    End Sub

    Private Sub ActMetodoPago(ByVal Metodo As Integer)

        metodoPagoI = Metodo
        metodoPagoS = cmbMetodoPago.SelectedItem(1)
        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_valor", "@Tabla", "CFD", "@Campo", "MetodoPago", "@Valor", Metodo)
        sClaveSAT = IIf(dt.Rows(0)("ClaveSAT").GetType.Name = "DBNull", "", dt.Rows(0)("ClaveSAT"))
        Dim descripcion As String = IIf(dt.Rows(0)("Descripcion").GetType.Name = "DBNull", "", dt.Rows(0)("Descripcion"))
        dt.Dispose()
        pagoTA = False
        btnLlaves.Visible = False
        terminalPinPad = False
        CmbBanco.Enabled = True
        TxtNumCta.Enabled = True
        TxtReferencia.Enabled = True
        Select Case sClaveSAT

            Case "04", "28"
                LblBanco.Visible = True
                CmbBanco.Visible = True

                LblReferencia.Text = "Referencia"
                LblReferencia.Visible = True
                TxtReferencia.Visible = True

                lblNumCta.Visible = True
                TxtNumCta.Visible = True

                lblTerminal.Visible = True
                cmbTerminal.Visible = True

                LblMeses.Visible = False
                numMeses.Visible = False
                cmbTerminal.SelectedValue = 0
                If cmbTerminal.Items.Count >= 1 Then
                    cmbTerminal.SelectedValue = dtTerminal.Rows(0)("TERClave")
                End If

                lblFecha.Visible = False
                cmbFechaPago.Visible = False

                lblBeneficiaria.Visible = False
                cmbBeneficiaria.Visible = False

                LblTarjeta.Visible = False
                TxtTarj.Visible = False
            Case "02"
                LblBanco.Visible = True
                CmbBanco.Visible = True

                LblReferencia.Text = "No. Cheque"
                LblReferencia.Visible = True
                TxtReferencia.Visible = True

                lblNumCta.Visible = True
                TxtNumCta.Visible = True

                lblTerminal.Visible = False
                cmbTerminal.Visible = False
                cmbTerminal.SelectedValue = 0

                lblFecha.Visible = True
                cmbFechaPago.Visible = True
                cmbFechaPago.Value = Today

                lblBeneficiaria.Visible = True
                cmbBeneficiaria.Visible = True

                LblTarjeta.Visible = False
                TxtTarj.Visible = False

                LblMeses.Visible = False
                numMeses.Visible = False

            Case "29", "06", "05", "03"
                descripcion.Replace(" ", "")
                If descripcion.ToUpper() <> "TARJETAAMIGA" Then
                    LblBanco.Visible = True
                    CmbBanco.Visible = True

                    LblReferencia.Text = "Referencia"
                    LblReferencia.Visible = True
                    TxtReferencia.Visible = True

                    lblNumCta.Visible = True
                    TxtNumCta.Visible = True

                    lblTerminal.Visible = False
                    cmbTerminal.Visible = False
                    cmbTerminal.SelectedValue = 0


                    lblFecha.Visible = True
                    cmbFechaPago.Visible = True
                    cmbFechaPago.Value = Today

                    lblBeneficiaria.Visible = True
                    cmbBeneficiaria.Visible = True

                    LblTarjeta.Visible = False
                    TxtTarj.Visible = False

                    LblMeses.Visible = False
                    numMeses.Visible = False

                End If
            Case Else

                LblBanco.Visible = False
                CmbBanco.Visible = False

                LblReferencia.Visible = False
                TxtReferencia.Visible = False
                TxtReferencia.Text = ""

                lblNumCta.Visible = False
                TxtNumCta.Text = ""
                TxtNumCta.Visible = False

                lblTerminal.Visible = False
                cmbTerminal.Visible = False
                cmbTerminal.SelectedValue = 0

                lblFecha.Visible = False
                cmbFechaPago.Visible = False

                lblBeneficiaria.Visible = False
                cmbBeneficiaria.Visible = False

                TxtTarj.Visible = False
                LblTarjeta.Visible = False

                LblMeses.Visible = False
                numMeses.Visible = False

        End Select

        If descripcion.ToUpper() = "TARJETAAMIGA" Then
            LblBanco.Visible = False
            CmbBanco.Visible = False

            LblReferencia.Visible = False
            TxtReferencia.Visible = False
            TxtReferencia.Text = ""

            lblNumCta.Visible = False
            TxtNumCta.Text = ""
            TxtNumCta.Visible = False

            lblTerminal.Visible = False
            cmbTerminal.Visible = False
            cmbTerminal.SelectedValue = 0

            lblFecha.Visible = False
            cmbFechaPago.Visible = False

            lblBeneficiaria.Visible = False
            cmbBeneficiaria.Visible = False

            LblMeses.Visible = False
            numMeses.Visible = False

            TxtTarj.Location = New System.Drawing.Point(85, 77)
            LblTarjeta.Location = New System.Drawing.Point(7, 80)
            PictureBox9.Location = New System.Drawing.Point(250, 80)
            TxtTarj.Visible = True
            LblTarjeta.Visible = True

            pagoTA = True
        End If


    End Sub


    Private Sub procesarPago(ByVal PerformClick As Boolean)
        If validaForm() Then

            If bAnticipo = False AndAlso ModPOS.TruncateToDecimal(SaldoDocumento, 2) <= 0 Then
                Beep()
                MessageBox.Show("No es posible registrar pagos debido a que el documento se encuentra totalmente pagado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                bError = True
                Exit Sub
            End If


            If bAnticipo = True Then
                If ClaveCliente = "" Then
                    MessageBox.Show("Debe seleccionar un Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    bError = True
                    Exit Sub
                End If
            End If

            If sClaveSAT = "" Then
                Beep()
                MessageBox.Show("El metodo de pago seleccionado no cuenta con una Clave SAT valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                bError = True
                Exit Sub
            End If

            If sClaveSAT <> "01" Then
                If bAnticipo = False AndAlso ModPOS.TruncateToDecimal(Monto * TipoCambio, 2) > ModPOS.TruncateToDecimal(SaldoDocumento, 2) Then
                    Beep()
                    MessageBox.Show("No es posible registrar pagos debido a que el Monto a pagar es mayor al saldo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    bError = True
                    Exit Sub
                End If
            End If

            If (sClaveSAT = "04" OrElse sClaveSAT = "28") AndAlso PorcentajeCargo > 0 AndAlso terminalPinPad = False Then
                If sClaveSAT = "28" Then

                    If TxtNumCta.Text = "" AndAlso TallaColor Then
                        MessageBox.Show("El número de autorización es requerido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    If TxtReferencia.Text = "" AndAlso TallaColor Then
                        MessageBox.Show("La referencia es requerida", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    numAutorizacion = TxtNumCta.Text
                Else
                    If Not PagoTerminal() Then
                        Exit Sub
                    End If
                End If
                TxtNumCta.Text = ""
            End If


            If terminalPinPad And seleccionarBank = False Then
                If Not PagoPinPad() Then
                    Exit Sub
                End If
            End If



            If pagoTA Then
                If Not pagoTarjetaAmiga() Then
                    Exit Sub
                End If
            End If

            Dim sBNKClave, sBanco, sTerminal, sMETClave As String
            If Not CmbBanco.SelectedValue Is Nothing Then
                sBNKClave = CmbBanco.SelectedValue
                sBanco = CmbBanco.SelectedItem(1)
            Else
                sBNKClave = ""
                sBanco = ""
            End If

            If Not cmbTerminal.SelectedValue Is Nothing Then
                sTerminal = cmbTerminal.SelectedValue
            Else
                sTerminal = ""
            End If


            Select Case sClaveSAT
                Case "04", "28", "02", "29", "06", "05", "03"
                    sMETClave = cmbBeneficiaria.SelectedValue
                Case Else
                    cmbFechaPago.Value = Today
                    sMETClave = ""
            End Select

            Dim ImporteComision As Decimal = 0
            If sClaveSAT = "04" AndAlso MontoCobro > Monto Then
                ImporteComision = MontoCobro - Monto
                Monto = MontoCobro
                SaldoDocumento += ImporteComision
                SaldoOriginal += ImporteComision
            End If

            'AddPago(cmbMetodoPago.SelectedValue, cmbMetodoPago.SelectedItem(1), Moneda, BtnTC.Text, TipoCambio, Monto, sBNKClave, sBanco, TxtReferencia.Text.Trim.ToUpper, TxtNumCta.Text.Trim.ToUpper, sTerminal, cmbFechaPago.Value, sMETClave, numAutorizacion, refFinanciera, secuenciaPinPad)
            AddPago(metodoPagoI, metodoPagoS, Moneda, BtnTC.Text, TipoCambio, Monto, sBNKClave, sBanco, TxtReferencia.Text.Trim.ToUpper, TxtNumCta.Text.Trim.ToUpper, sTerminal, cmbFechaPago.Value, sMETClave, numAutorizacion, refFinanciera, secuenciaPinPad, ImporteComision, meses, puntos, transaccion, aid, arqc, firmaElectronica, puntosAnterior, puntosRedimidos, puntosActual)

            TxtMonto.Text = ""
            TxtReferencia.Text = ""
            TxtNumCta.Text = ""
            Monto = 0
            MontoCobro = 0
            meses = ""
            transaccion = ""
            puntos = 0
            aid = ""
            arqc = ""
            firmaElectronica = 0
            puntosAnterior = ""
            puntosRedimidos = ""
            puntosActual = ""

            bError = False

            If TruncateToDecimal(SaldoDocumento, 2) = 0 Then
                If PerformClick = True Then
                    BtnOK.PerformClick()
                End If
            Else
                cmbMetodoPago.Focus()
            End If

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            bError = True
        End If
    End Sub


    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        bError = False
        If Not ModPOS.Teclado Is Nothing Then
            ModPOS.Teclado.Close()
        End If
        If CDbl(TxtMonto.Text) > 0 Then
            procesarPago(False)
        ElseIf dtDetallePago.Rows.Count = 0 Then
            MessageBox.Show("Operación no registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            bError = True
            Exit Sub
        End If

        If CobranzaVenta = True AndAlso PagoCXC = False AndAlso TipoVenta = "Contado" Then

            If ModPOS.TruncateToDecimal(SaldoDocumento, 2) > 0 Then
                MessageBox.Show("El documento debe ser pagado completamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bError = True
                Exit Sub

            End If

            Pagado = True
        End If


        If ConfirmarAbono = 1 Then
            If MessageBox.Show("¿Esta seguro que desea aplicar el abono/anticipo actual?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.No Then
                bError = True
                Exit Sub
            End If
        End If

        If bError = False Then


            If bAnticipo = False Then
                Select Case TruncateToDecimal(TotalPago, 2)
                    Case Is > TruncateToDecimal(SaldoOriginal, 2)
                        Cambio = TotalPago - TruncateToDecimal(SaldoOriginal, 2)
                    Case Is <= TruncateToDecimal(SaldoOriginal, 2)
                        Cambio = 0
                End Select
            Else

                SaldoOriginal = TotalPago
            End If

            If Cajon = True Then
                ModPOS.AbrirCajon(Impresora)
            End If

            Dim i As Integer

            id_evento = ModPOS.obtenerLlave

            For i = 0 To dtDetallePago.Rows.Count - 1

                FolioAbono = ObtenerFolio()

                ModPOS.Ejecuta("sp_inserta_abono", _
                              "@ABNClave", dtDetallePago.Rows(i)("ABNClave"), _
                              "@Tipo", Tipo, _
                              "@Clave", FolioAbono, _
                              "@CAJClave", CAJClave, _
                              "@CTEClave", CTEClave, _
                              "@TipoPago", dtDetallePago.Rows(i)("TipoPago"), _
                              "@Moneda", dtDetallePago.Rows(i)("Moneda"), _
                              "@TipoCambio", dtDetallePago.Rows(i)("TipoCambio"), _
                              "@Cantidad", Math.Round(dtDetallePago.Rows(i)("Monto"), 2), _
                              "@Saldo", Math.Round(dtDetallePago.Rows(i)("Monto"), 2), _
                              "@BNKClave", dtDetallePago.Rows(i)("BNKClave"), _
                              "@Referencia", dtDetallePago.Rows(i)("Ref"), _
                              "@NumCta", dtDetallePago.Rows(i)("NumCta"), _
                              "@Nota", txtNota.Text, _
                              "@TERClave", dtDetallePago.Rows(i)("TERClave"), _
                              "@Usuario", ModPOS.UsuarioActual, _
                              "@fechaPago", dtDetallePago.Rows(i)("FechaPago"),
                              "@METClave", dtDetallePago.Rows(i)("METClave"), _
                              "@numAutorizacion", dtDetallePago.Rows(i)("NoAutorizacion"), _
                              "@referenciaFinanciera", dtDetallePago.Rows(i)("RefFinanciera"), _
                              "@secuencia", dtDetallePago.Rows(i)("Secuencia"), _
                              "@evento", id_evento, _
                              "@ImporteComision", dtDetallePago.Rows(i)("ImporteComision"), _
                              "@meses", dtDetallePago.Rows(i)("meses"), _
                              "@puntos", dtDetallePago.Rows(i)("puntos"), _
                              "@transaccion", dtDetallePago.Rows(i)("transaccion"), _
                              "@aid", dtDetallePago.Rows(i)("aid"), _
                              "@arqc", dtDetallePago.Rows(i)("arqc"), _
                              "@firmaElectronica", dtDetallePago.Rows(i)("firmaElectronica"), _
                              "@puntosAnterior", dtDetallePago.Rows(i)("puntosAnterior"), _
                              "@puntosRedimidos", dtDetallePago.Rows(i)("puntosRedimidos"), _
                              "@puntosActual", dtDetallePago.Rows(i)("puntosActual")
                               )

                If InterfazSalida <> "" AndAlso Tipo = 2 Then

                    Dim sFolio, sFecha As String
                    Dim dtInterfaz As DataTable
                    sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                    sFolio = dtDetallePago.Rows(i)("ABNClave")

                    dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Cobros", "@COMClave", ModPOS.CompanyActual)
                    If dtInterfaz.Rows.Count > 0 Then
                        If Tipo = 2 Then
                            ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sFolio, "@TipoDocumento", -1, "@Path", InterfazSalida, "@Fecha", sFecha, "@Tipo", -1)
                        End If
                    End If

                End If

                If dtDetallePago.Rows(i)("TipoPago") = 8 Then
                    ModPOS.Ejecuta("sp_act_puntos", "@CTEClave", CTEClave, "@Cantidad", Math.Round(dtDetallePago.Rows(i)("SaldoBase"), 2))
                End If

                ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", CTEClave, "@Importe", Math.Round(dtDetallePago.Rows(i)("SaldoBase"), 2))
            Next


            If dtComision.Rows.Count > 0 Then
                For i = 0 To dtComision.Rows.Count - 1
                    ModPOS.Ejecuta("st_aplica_cargo_comision", "@VENClave", dtComision.Rows(i)("VENClave"), "@ImporteComision", dtComision.Rows(i)("ImporteComision"), "@Usuario", ModPOS.UsuarioActual)
                Next
            End If


            Nota = txtNota.Text
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        If pagosPinPad Then
            bError = True
            MessageBox.Show("Existen pagos que se realizaron por PinPad", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        ElseIf pagosTarjetaAmiga Then
            bError = True
            MessageBox.Show("Existen pagos que se realizaron con Tarjeta Amiga", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            bError = False
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub



    Private Sub TxtReferencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtReferencia.Click
        If bTouch = True Then
            Dim a As New FrmTecladoNum
            a.Text = "Referencia"
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                Me.TxtReferencia.Text = a.Cantidad
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub



    Private Sub Ctrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbMetodoPago.KeyDown, CmbBanco.KeyDown, TxtReferencia.KeyDown, cmbTerminal.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub BtnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                CTEClave = a.valor
                Me.recuperaCliente()
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub TxtImporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMonto.Click
        If bTouch = True Then
            Dim a As New FrmTecladoNum
            a.Text = "Importe"
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                Me.TxtMonto.Text = a.Cantidad
                procesarPago(True)
            End If
        End If
    End Sub

    Private Sub TxtMonto_DoubleClick(sender As Object, e As EventArgs) Handles TxtMonto.DoubleClick
        TxtMonto.Text = ModPOS.TruncateToDecimal(SaldoDocumento / TipoCambio, 2)
    End Sub

    Private Sub TxtImporte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMonto.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            procesarPago(True)
        End If
    End Sub

    Private Sub BtnTC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTC.Click
        BtnTC.ContextMenuStrip.Show(BtnTC, New Point(0, 0), ToolStripDropDownDirection.AboveRight)
    End Sub

    Private Sub CtxDocumentos_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles CtxDocumentos.ItemClicked
        BtnTC.Text = e.ClickedItem.Text

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_tipocambio", "@Moneda", e.ClickedItem.Text)
        Moneda = dt.Rows(0)("MONClave")
        TipoCambio = dt.Rows(0)("TipoCambio")
        dt.Dispose()



        If CInt(TipoCambio) <> 1 Then
            LblTipoCambio.Text = "T.C. " & Format(CStr(ModPOS.TruncateToDecimal(TipoCambio, 2)), "Currency")
            lblMonedaCambio.Text = BtnTC.Text & " " & Format(CStr(TruncateToDecimal(SaldoDocumento / TipoCambio, 2)), "Currency")
            lblMonedaCambio.Visible = True
        Else
            lblMonedaCambio.Visible = False
            LblTipoCambio.Text = ""
        End If
        SendKeys.Send("{TAB}")

        If Moneda = MonedaCambio Then
            cmbMetodoPago.SelectedValue = 1
            cmbMetodoPago.Enabled = False
        Else
            cmbMetodoPago.Enabled = True
        End If


        With cmbBeneficiaria
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_filtra_beneficiario"
            .NombreParametro1 = "CAJClave"
            .Parametro1 = CAJClave
            .NombreParametro2 = "MONClave"
            .Parametro2 = Moneda
            .llenar()
        End With

    End Sub

    Private Sub GridMetodos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridMetodos.DoubleClick
        If Not Me.GridMetodos.GetValue("MTPClave") Is Nothing Then
            cmbMetodoPago.SelectedValue = GridMetodos.GetValue("MetodoPago")
            CmbBanco.SelectedValue = GridMetodos.GetValue("BNKClave")
            TxtNumCta.Text = GridMetodos.GetValue("Referencia")
        End If
    End Sub

    Private Sub TxtReferencia_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtReferencia.Leave
        If TxtReferencia.Text.Length > 16 Then
            If TxtReferencia.Text.Split("&").Length > 1 Then
                Dim sCard, sNombre As String
                sCard = TxtReferencia.Text.Split("&")(0).Remove(0, 2)
                sNombre = TxtReferencia.Text.Split("&")(1)
                TxtReferencia.Text = sCard
            End If
        End If
        TxtMonto.Focus()
    End Sub

    Private Sub picKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picKeyboard.Click
        AbrirTeclado(Me)
    End Sub

    Private Sub Concatenar(dato As String) Implements ITeclado.Concatenar
        Dim texto As String = textBoxActual.Text
        If dato = "DESHACER" OrElse dato = "" And texto.Length > 0 Then
            textBoxActual.Text = textBoxActual.Text.Remove(texto.Length - 1, 1)
        Else
            textBoxActual.Text &= dato
        End If

    End Sub

    Private Sub btnBuscaCte_Click(sender As Object, e As EventArgs) Handles btnBuscaCte.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                CTEClave = a.valor
                recuperaCliente()
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub TxtCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCliente.KeyPress
        If (Asc(e.KeyChar)) = 13 Then
            If Not TxtCliente.Text = vbNullString Then
                Dim dt As DataTable
                dt = ModPOS.SiExisteRecupera("sp_recupera_clavecte", "@Clave", TxtCliente.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual, "@SUCClave", SUCClave)
                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                    CTEClave = (dt.Rows(0)("CTEClave"))
                    dt.Dispose()
                    recuperaCliente()
                Else
                    LblCliente.Text = ""
                    TxtCliente.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub cmbMetodoPago_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMetodoPago.SelectedValueChanged
        If FormaPagoLoad = True AndAlso Not cmbMetodoPago.SelectedValue Is Nothing Then
            ActMetodoPago(CInt(cmbMetodoPago.SelectedValue))
            TxtMonto.Text = "0.0"
        End If
    End Sub

    Private Function obtenerSecuencia() As String
        Dim dt As DataTable = ModPOS.Recupera_Tabla("st_secuencia_PinPad", "@TERClave", cmbTerminal.SelectedValue)
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("secuencia")
            End If
        End If
    End Function

    Private Function PagoPinPad() As Boolean
        Dim comisionesValidas As Integer = 0
        Dim pagoTarjeta As PinPad = New PinPad()
        With pagoTarjeta
            If .r16Leyenda <> "Exitoso" Then
                MessageBox.Show(.r16Leyenda, "PinPad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If sClaveSAT = "04" AndAlso PorcentajeCargo > 0 Then
                Dim ImporteComision As Decimal
                If Not dtDocumentos Is Nothing Then
                    Dim foundRows() As DataRow

                    foundRows = dtDocumentos.Select("TipoDocumento = 1 and Tipo = 'Contado' and DescuentoTot > 0 ")

                    ImporteComision = Math.Round(Monto * (PorcentajeCargo / 100), 2)
                    Dim SaldoComision As Decimal = ImporteComision

                    If foundRows.Length > 0 Then
                        Dim i As Integer

                        For i = 0 To foundRows.Length - 1
                            Dim row1 As DataRow
                            row1 = dtComision.NewRow()

                            If foundRows(i)("DescuentoTot") >= SaldoComision Then
                                row1.Item("VENClave") = foundRows(i)("ID")
                                row1.Item("ImporteComision") = SaldoComision
                                dtComision.Rows.Add(row1)
                                comisionesValidas += 1
                                SaldoComision = 0
                            Else
                                row1.Item("VENClave") = foundRows(0)("ID")
                                row1.Item("ImporteComision") = foundRows(i)("DescuentoTot")
                                dtComision.Rows.Add(row1)
                                comisionesValidas += 1
                                SaldoComision -= foundRows(i)("DescuentoTot")
                            End If
                            'validar is el totaldescuento es mayor 
                            If SaldoComision = 0 Then
                                Exit For
                            End If
                        Next
                    End If
                    ImporteComision -= SaldoComision
                End If

                MontoCobro = Monto + ImporteComision
            Else
                MontoCobro = Monto
            End If

            .e01Transaccion = PinPad.tipoOperacion.VentaNormal
            .leerArchivo()
            If PinPadNumero <> "" Then
                .e02Terminal = PinPadNumero
            End If

            .e03Sesion = Format(Today, "MMdd")
            .e04Secuencia = obtenerSecuencia()
            .e05Importe = pagoTarjeta.formatoImporte(MontoCobro)
            .e06Filler = pagoTarjeta.formatoImporte(0.0)
            '.e07Folio = "0000000"
            '.e08EMV = "3"
            '.e09Tipo = "8"
            '.e10CapCVV2 = "1"
            .e11Pagos = "0"
            .e14Moneda = IIf(Moneda = "MONMXN", PinPad.tipoMoneda.Pesos, PinPad.tipoMoneda.Dolares)
            .e15Autoriza = ""
            .e16Modo = StrDup(2, " ")
            '.e17CVV2 = StrDup(4, " ")
            '.e18TrackII = "                                        "
            '.e19Numero = StrDup(3, " ")
            .e20CashBack = pagoTarjeta.formatoImporte(0.0)
            .e21FechaHora = Now.ToString("yyMMddhhmmss")
            '.e22Comercio = StrDup(45, " ")
            .e23OImporte = pagoTarjeta.formatoImporte(0.0)
            .e24Operador = ModPOS.UsuarioActual
            .e25Afiliacion = afiliacion
            '.e26Filler = "0000"
            .e27Referencia = ""
            '.e28Filler = "0"
            '.e29Filler = "000"
            '.e30Filler = "000"
            '.e31MultiPagos = "0000"
            .e32Id = "0000"
            'If MontoCobro > montoMinSinIntereses AndAlso numMeses.Value > 0 Then
            '    .e12Parciales = numMeses.Value.ToString()
            '    .e13Promocion = PinPad.tipoPromo.SinIntereses
            'Else
            .e12Parciales = "0"
            .e13Promocion = PinPad.tipoPromo.SinPromocion
            'End If

            Dim frmStatusMessage As New frmStatus

            frmStatusMessage.Show("INSERTE / DESLICE LA TARJETA")
            frmStatusMessage.BringToFront()

            pagoTarjeta.Enviar()

            If .miPinPad.RespDLL <> 0 Or (.miPinPad.ClsResponse.C05_CodigoRespuesta <> "00" AndAlso .miPinPad.ClsResponse.C05_CodigoRespuesta <> "") Then
                frmStatusMessage.Dispose()
                Dim respuesta As String = .miPinPad.ClsResponse.ToString
                If .miPinPad.ClsResponse.C16_Leyenda.Length > 0 Then
                    respuesta = .miPinPad.ClsResponse.C16_Leyenda
                End If
                MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                MontoCobro = 0
                Return False
            Else
                frmStatusMessage.Show("Procesando")
                If .miPinPad.NumeroTarjeta.Trim = "" Then
                    'MostrarMensaje("Operacion cancelada...")
                    MessageBox.Show("Error al leer el numero de tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    MontoCobro = 0
                    Return False
                End If

                If .miPinPad.CardTipo = 1 Then
                    If Not metodoPagoS.Contains(.miPinPad.CreditoDebito.ToUpper) Then
                        Dim aux As String
                        For Each item As DataRowView In cmbMetodoPago.Items
                            aux = item.Item(1)
                            If aux.Contains(.miPinPad.CreditoDebito.ToUpper) Then
                                metodoPagoI = item.Item(0)
                                metodoPagoS = item.Item(1)
                            End If
                        Next
                    End If

                    If .miPinPad.CreditoDebito.ToUpper = "DEBITO" Then
                        '.miPinPad.fncTerminaTipoCard(True, "000000000000", "00", Format(.e12Parciales, "00"), Format(.e13Promocion, "00"))
                        .miPinPad.fncTerminaProceso(False)
                    ElseIf .miPinPad.CreditoDebito.ToUpper = "CREDITO" Then
                        'cmbTerminal.SelectedValue = 2
                        If .miPinPad.Bancomer Then
                            Dim mesesSinInt As Boolean = False
                            Dim pagosMeses As DialogResult = System.Windows.Forms.DialogResult.No

                            If MontoCobro >= montoMinSinIntereses AndAlso numMeses.Value > 0 Then
                                pagosMeses = MessageBox.Show("¿Desea pagar a " + numMeses.Value.ToString() + " Meses Sin Intereses?", "Promociones",
                                                                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            End If

                            mesesSinInt = IIf(pagosMeses = System.Windows.Forms.DialogResult.Yes, True, False)

                            If .miPinPad.TnxConPuntos And Not mesesSinInt Then
                                .miPinPad.fncTerminaProceso(MensajePuntos)
                            Else
                                If mesesSinInt Then
                                    '.e13Promocion = PinPad.tipoPromo.SinIntereses
                                    .e13Promocion = Format(Val(PinPad.tipoPromo.SinIntereses), "00")
                                    .e12Parciales = Format(Val(numMeses.Value.ToString()), "00")
                                    meses = numMeses.Value.ToString() & " meses sin intereses"
                                Else
                                    meses = ""
                                    .e13Promocion = Format(PinPad.tipoPromo.SinPromocion.ToString(), "00")
                                    .e12Parciales = "00"
                                End If
                                .miPinPad.fncTerminaTipoCard(True, "000000000000", "00", .e12Parciales, .e13Promocion)
                            End If
                        Else
                            .miPinPad.fncTerminaTipoCard(True, "000000000000", "00", "00", "00")
                        End If
                        'MessageBox.Show(.miPinPad.Response)
                    Else
                        .miPinPad.fncTerminaTipoCard(True, "000000000000", "00", "00", "00")
                    End If
                End If
                'MessageBox.Show(.miPinPad.ClsResponse.ToString)
                frmStatusMessage.Show("RETIRE LA TARJETA")
            End If

            .Recibir()
            numMeses.Value = 0
            frmStatusMessage.Dispose()

            If .miPinPad.RespDLL = 0 AndAlso .miPinPad.ClsResponse.C05_CodigoRespuesta = "00" Then
                TxtReferencia.Text = Mid(.miPinPad.NumeroTarjeta, 13, 4)
                numAutorizacion = .r06Autoriza
                refFinanciera = .r17RefFin
                secuenciaPinPad = .e04Secuencia
                aid = .miPinPad.AID
                puntos = 0
                firmaElectronica = Convert.ToInt32(.miPinPad.FirmaElectronica)
                arqc = .miPinPad.Criptograma
                If .r21DatPuntos.Length > 0 Then
                    puntos = Decimal.Parse(Mid(.r21DatPuntos, 1, 12)) / 100
                    puntosAnterior = Mid(.r21DatPuntos, 37, 10)
                    puntosRedimidos = Mid(.r21DatPuntos, 13, 10)
                    puntosActual = Mid(.r21DatPuntos, 126, 10)
                End If

                Select Case .miPinPad.ModoIngreso
                    Case "05" : transaccion = "I@1"
                    Case "90", "80" : transaccion = "D@1"
                    Case "01" : transaccion = "T@1"
                    Case Else : transaccion = .miPinPad.ModoIngreso
                End Select
                pagosPinPad = True

                Dim dt As DataTable = ModPOS.Recupera_Tabla("st_obtener_BankBin", "@BIN", Mid(.miPinPad.NumeroTarjeta, 1, 6))
                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        CmbBanco.SelectedValue = dt.Rows(0)("BNKClave")
                        If CmbBanco.SelectedValue Is Nothing Then
                            seleccionarBank = True
                        End If
                    Else
                        seleccionarBank = True
                    End If
                Else
                    seleccionarBank = True
                End If

                If seleccionarBank And CmbBanco.SelectedValue Is Nothing Then
                    cmbTerminal.Enabled = False
                    cmbMetodoPago.Enabled = False
                    TxtReferencia.Enabled = False
                    TxtMonto.Enabled = False
                    Dim i As Integer = 0
                    i += 1
                    reloj = New parpadea(Me.alerta(2))
                    reloj.Enabled = True
                    reloj.Start()
                    MessageBox.Show("Banco requerido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    CmbBanco.Enabled = True
                    Return False
                End If
                Return True
            Else
                If comisionesValidas > 0 Then
                    Dim fin As Integer = (dtComision.Rows.Count - comisionesValidas)
                    For inicio As Integer = dtComision.Rows.Count - 1 To fin Step -1
                        dtComision.Rows.Remove(dtComision.Rows(inicio))
                    Next
                End If
                MessageBox.Show(IIf(.r16Leyenda = "" OrElse .r16Leyenda = " ", .miPinPad.ClsResponse.ToString(), .r16Leyenda), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                .ImprimirTicket(Impresora, False, DocumentoClave)
                Return False
            End If

        End With
    End Function

    Private Function MensajePuntos() As Boolean
        Dim pregunta As DialogResult = MessageBox.Show("¿Desea utilizar sus Puntos Bancomer?", "Puntos Bancomer",
                                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Return IIf(pregunta = System.Windows.Forms.DialogResult.Yes, True, False)
    End Function

    Private Function PagoTerminal() As Boolean
        Dim comisionesValidas As Integer = 0
        MontoCobro = 0
        If CmbBanco.SelectedValue Is Nothing Then
            Dim i As Integer = 0
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
            MessageBox.Show("Banco requerido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CmbBanco.Enabled = True
            Return False
        End If

        If TxtNumCta.Text = "" Then
            MessageBox.Show("El número de autorización es requerido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If TxtReferencia.Text = "" Then
            MessageBox.Show("La referencia es requerida", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        numAutorizacion = TxtNumCta.Text
        puntos = 0
        MontoCobro = Monto

        Dim ImporteComision As Decimal
        If Not dtDocumentos Is Nothing Then
            Dim foundRows() As DataRow

            foundRows = dtDocumentos.Select("TipoDocumento = 1 and Tipo = 'Contado' and DescuentoTot > 0 ")

            ImporteComision = Math.Round(Monto * (PorcentajeCargo / 100), 2)
            Dim SaldoComision As Decimal = ImporteComision

            If foundRows.Length > 0 Then
                Dim i As Integer

                For i = 0 To foundRows.Length - 1
                    Dim row1 As DataRow
                    row1 = dtComision.NewRow()

                    If foundRows(i)("DescuentoTot") >= SaldoComision Then
                        row1.Item("VENClave") = foundRows(i)("ID")
                        row1.Item("ImporteComision") = SaldoComision
                        dtComision.Rows.Add(row1)
                        comisionesValidas += 1
                        SaldoComision = 0
                    Else
                        row1.Item("VENClave") = foundRows(0)("ID")
                        row1.Item("ImporteComision") = foundRows(i)("DescuentoTot")
                        dtComision.Rows.Add(row1)
                        comisionesValidas += 1
                        SaldoComision -= foundRows(i)("DescuentoTot")
                    End If
                    'validar is el totaldescuento es mayor 
                    If SaldoComision = 0 Then
                        Exit For
                    End If
                Next
            End If
            ImporteComision -= SaldoComision
        End If

        MontoCobro = Monto + ImporteComision
        Return True
    End Function


    Private Sub cmbTerminal_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTerminal.SelectedValueChanged
        If Not cmbTerminal.SelectedValue Is Nothing Then
            Select Case sClaveSAT
                Case "04", "28"
                    Dim dt As DataTable = ModPOS.Recupera_Tabla("st_valida_pinpad", "@TERClave", cmbTerminal.SelectedValue)
                    If Not dt Is Nothing Then
                        If dt.Rows.Count > 0 Then
                            terminalPinPad = dt.Rows(0)("PinPad")
                            afiliacion = dt.Rows(0)(1)
                            PorcentajeCargo = dt.Rows(0)("PorcentajeCargo")
                            numMeses.Maximum = maxMesesSinIntereses
                            Dim archivoPinPad As PinPad
                            If terminalPinPad Then
                                archivoPinPad = New PinPad()
                                terminalPinPad = archivoPinPad.crearArchivo()
                                If cargaLlaves Then
                                    archivoPinPad.modificarPinPadConfig()
                                End If

                                If archivoPinPad.leerArchivo() Then
                                    btnLlaves.PerformClick()
                                    cargaLlaves = True
                                End If
                            End If
                            
                            If sClaveSAT = "04" AndAlso PorcentajeCargo > 0 Then
                                lblSaldoTarjeta.Visible = True
                                txtSaldoTarjeta.Visible = True
                                txtSaldoTarjeta.Text = Format(CStr(ModPOS.TruncateToDecimal(SaldoDocumento * (1 + (PorcentajeCargo / 100)), 2)), "Currency")
                            Else
                                lblSaldoTarjeta.Visible = False
                                txtSaldoTarjeta.Visible = False
                            End If
                        End If
                        dt.Dispose()
                    End If
                Case Else
                    lblSaldoTarjeta.Visible = False
                    txtSaldoTarjeta.Visible = False
                    terminalPinPad = False
            End Select
            If terminalPinPad = False Then
                CmbBanco.Enabled = True
                TxtNumCta.Enabled = True
                TxtReferencia.Enabled = True
            Else
                'CmbBanco.Enabled = False
                TxtNumCta.Enabled = False
                TxtReferencia.Enabled = False
            End If
        End If

        If maxMesesSinIntereses > 0 AndAlso sClaveSAT = "04" Then
            LblMeses.Visible = terminalPinPad
            numMeses.Visible = terminalPinPad
        End If
        btnLlaves.Visible = terminalPinPad
    End Sub

    Private Sub CmbBanco_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbBanco.SelectedValueChanged
        If seleccionarBank Then
            procesarPago(True)
        End If

    End Sub

    Private Sub cmbMetodoPago_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Function pagoTarjetaAmiga() As Boolean
        If sIdComercio = "" OrElse sIdTerminal = "" Then
            MessageBox.Show("El idComercio y el idTerminal son requeridos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

        Dim datosTarjetaAmiga As New TarjetaAmiga
        Dim frmStatusMessage As New frmStatus
        Dim valido As Boolean = True

        frmStatusMessage.Show("Procesando...")
        frmStatusMessage.BringToFront()


        datosTarjetaAmiga.referencia = DocumentoClave.Replace("-", "")
        datosTarjetaAmiga.tarjeta = TxtTarj.Text.Replace("-", "")
        datosTarjetaAmiga.monto = TxtMonto.Text
        datosTarjetaAmiga.idComercio = sIdComercio
        datosTarjetaAmiga.idTerminal = sIdTerminal
        datosTarjetaAmiga.plazo = "6"
        datosTarjetaAmiga.idTransaccion = ""

        datosTarjetaAmiga = datosTarjetaAmiga.consulta(TarjetaAmiga.Compra)
        If datosTarjetaAmiga.codigo <> 0 Then
            MessageBox.Show(datosTarjetaAmiga.mensaje, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            valido = False
        Else
            If MessageBox.Show("Usted es " + datosTarjetaAmiga.nombre, "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.No Then
                Dim preguntaNombre As TarjetaAmiga

                preguntaNombre.tarjeta = datosTarjetaAmiga.tarjeta
                preguntaNombre.monto = datosTarjetaAmiga.monto
                preguntaNombre.idComercio = datosTarjetaAmiga.idComercio
                preguntaNombre.idTerminal = datosTarjetaAmiga.idTerminal
                preguntaNombre.idTransaccion = datosTarjetaAmiga.clave

                preguntaNombre = preguntaNombre.consulta(TarjetaAmiga.Cancelacion)
                valido = False
            Else
                numAutorizacion = datosTarjetaAmiga.clave
                TxtReferencia.Text = Mid(datosTarjetaAmiga.tarjeta, 13, 4)
                pagosTarjetaAmiga = True
                For aux As Integer = 1 To 2
                    datosTarjetaAmiga.imprimirTicketPago(Impresora, False, TarjetaAmiga.Compra)
                Next
            End If

        End If
        frmStatusMessage.Dispose()
        Return valido

    End Function

    Private Sub TxtReferencia_Enter(sender As Object, e As EventArgs) Handles TxtReferencia.Enter
        textBoxActual = Me.TxtReferencia
    End Sub

    Private Sub TxtNumCta_Enter(sender As Object, e As EventArgs) Handles TxtNumCta.Enter
        textBoxActual = Me.TxtNumCta
    End Sub

    Private Sub TxtTarj_Enter(sender As Object, e As EventArgs) Handles TxtTarj.Enter
        textBoxActual = Me.TxtTarj
    End Sub

    Private Sub TxtMonto_Enter(sender As Object, e As EventArgs) Handles TxtMonto.Enter
        textBoxActual = Me.TxtMonto
    End Sub

    Private Sub txtNota_Enter(sender As Object, e As EventArgs) Handles txtNota.Enter
        textBoxActual = Me.txtNota
    End Sub

    Private Sub btnLlaves_Click(sender As Object, e As EventArgs) Handles btnLlaves.Click
        Dim cargarLlaves As PinPad = New PinPad()
        With cargarLlaves
            .e01Transaccion = PinPad.tipoOperacion.CargarLlaves
            .leerArchivo()
            If PinPadNumero <> "" Then
                .e02Terminal = PinPadNumero
            End If
            .e03Sesion = Format(Today, "MMdd")
            .e04Secuencia = obtenerSecuencia()
            .e05Importe = cargarLlaves.formatoImporte(0.0)
            .e06Filler = cargarLlaves.formatoImporte(0.0)
            '.e07Folio = "0000000"
            '.e08EMV = "3"
            '.e09Tipo = "8"
            .e10CapCVV2 = "0"
            .e11Pagos = "0"
            .e12Parciales = "0"
            .e13Promocion = "0"
            .e14Moneda = PinPad.tipoMoneda.Pesos
            .e15Autoriza = ""
            .e16Modo = "01"
            '.e17CVV2 = StrDup(4, " ")
            '.e18TrackII = "                                        "
            '.e19Numero = StrDup(3, " ")
            .e20CashBack = cargarLlaves.formatoImporte(0.0)
            .e21FechaHora = Now.ToString("yyMMddhhmmss")
            '.e22Comercio = StrDup(45, " ")
            .e23OImporte = cargarLlaves.formatoImporte(0.0)
            .e24Operador = ModPOS.UsuarioActual
            .e25Afiliacion = afiliacion
            '.e26Filler = "0000"
            .e27Referencia = "00000000"
            '.e28Filler = "0"
            '.e29Filler = "000"
            '.e30Filler = "000"
            '.e31MultiPagos = "0000"
            .e32Id = "0000"
        End With
        cargarLlaves.Enviar()

        If cargarLlaves.miPinPad.RespDLL <> 0 Or (cargarLlaves.miPinPad.ClsResponse.C05_CodigoRespuesta <> "00" AndAlso cargarLlaves.miPinPad.ClsResponse.C05_CodigoRespuesta <> "") Then

            Dim respuesta As String = cargarLlaves.miPinPad.ClsResponse.ToString
            If cargarLlaves.miPinPad.ClsResponse.C16_Leyenda.Length > 0 Then
                respuesta = cargarLlaves.miPinPad.ClsResponse.C16_Leyenda
            End If
            MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            cargarLlaves.modificarPinPadConfig()
            MessageBox.Show("Carga de llaves exitosa", "Carga de llaves", MessageBoxButtons.OK, MessageBoxIcon.None)
        End If


    End Sub

End Class
