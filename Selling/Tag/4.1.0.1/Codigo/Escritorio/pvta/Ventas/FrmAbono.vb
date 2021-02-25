Public Class FrmAbono
    Inherits System.Windows.Forms.Form

    Public InterfazSalida As String = ""
    Public Aplicacion As String = ""
    Public bTouch As Boolean = False
    Public bAnticipo As Boolean = False
    Private Moneda, MonedaCambio As String
    Private Tipo As Integer = 1
    Private TipoDoc As Integer  '1: Ticket, 2:Factura
    Private DocumentoClave As String
    Private ABNClave As String
    Public CTEClave As String
    Public ConfirmarAbono As Integer = 0



    Public Nota As String

    Public ClaveCliente As String = ""
    Public NombreCliente As String

    Private ValidaCtaPago As Integer = 1
    Private Folio As String
    Private SaldoDocumento, SaldoOriginal As Double
    Private bEfectivo, bCheque, bTarjeta As Boolean
    Private CAJClave, Referencia As String
    Private SaldoPuntos As Double
    Private Multiple As Boolean = False
    Private Cajon As Boolean = False
    Private Impresora As String

    Private TipoCambio As Double
    Private TotalPago As Double = 0
    Private Monto As Double = 0
    Private Cambio As Double = 0
    Private bError As Boolean = False

    Private alerta(6) As PictureBox
    Private reloj As parpadea
    Private FormaPagoLoad As Boolean = False
  
    Private iPublicoGral As Integer = 0
    Private FolioAbono As String

    Private dtMetodosPago, dtDetallePago As DataTable

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
        Me.GrpAbono.SuspendLayout()
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
        Me.GrpAbono.Location = New System.Drawing.Point(7, 101)
        Me.GrpAbono.Name = "GrpAbono"
        Me.GrpAbono.Size = New System.Drawing.Size(775, 107)
        Me.GrpAbono.TabIndex = 0
        Me.GrpAbono.TabStop = False
        Me.GrpAbono.Text = "Registro de Abono"
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
        Me.Label6.Location = New System.Drawing.Point(624, 25)
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
        Me.LblTipoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnTC
        '
        Me.BtnTC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnTC.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton
        Me.BtnTC.ContextMenuStrip = Me.CtxDocumentos
        Me.BtnTC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTC.Location = New System.Drawing.Point(10, 47)
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
        Me.CtxDocumentos.Size = New System.Drawing.Size(153, 26)
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
        Me.LblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaldo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblSaldo.Location = New System.Drawing.Point(443, 50)
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
        Me.BtnOK.Location = New System.Drawing.Point(687, 366)
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
        Me.BtnCancel.Location = New System.Drawing.Point(591, 366)
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
        Me.GroupBox2.Location = New System.Drawing.Point(373, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(401, 42)
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
        Me.LblPuntos.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPuntos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblPuntos.Location = New System.Drawing.Point(166, 5)
        Me.LblPuntos.Name = "LblPuntos"
        Me.LblPuntos.Size = New System.Drawing.Size(224, 37)
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
        Me.GrpMetodos.Location = New System.Drawing.Point(7, 214)
        Me.GrpMetodos.Name = "GrpMetodos"
        Me.GrpMetodos.Size = New System.Drawing.Size(303, 146)
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
        Me.GridMetodos.Size = New System.Drawing.Size(291, 124)
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
        Me.Label4.Location = New System.Drawing.Point(379, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 16)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "SALDO"
        '
        'picKeyboard
        '
        Me.picKeyboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picKeyboard.BackColor = System.Drawing.Color.Transparent
        Me.picKeyboard.Image = Global.Selling.My.Resources.Resources._1403657593_519640_141_Keyboard
        Me.picKeyboard.Location = New System.Drawing.Point(12, 370)
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
        Me.GrpDetalle.Location = New System.Drawing.Point(316, 214)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(465, 146)
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
        Me.GridDetalle.Size = New System.Drawing.Size(453, 124)
        Me.GridDetalle.TabIndex = 1
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LblCte
        '
        Me.LblCte.BackColor = System.Drawing.Color.Transparent
        Me.LblCte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblCte.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblCte.Location = New System.Drawing.Point(11, 50)
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
        Me.btnBuscaCte.Location = New System.Drawing.Point(187, 43)
        Me.btnBuscaCte.Name = "btnBuscaCte"
        Me.btnBuscaCte.Size = New System.Drawing.Size(44, 27)
        Me.btnBuscaCte.TabIndex = 89
        Me.btnBuscaCte.ToolTipText = "Busqueda de Cliente"
        Me.btnBuscaCte.Visible = False
        Me.btnBuscaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(68, 49)
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
        Me.LblCliente.Location = New System.Drawing.Point(11, 79)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(347, 14)
        Me.LblCliente.TabIndex = 91
        Me.LblCliente.Visible = False
        '
        'lblMonedaCambio
        '
        Me.lblMonedaCambio.BackColor = System.Drawing.Color.Transparent
        Me.lblMonedaCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonedaCambio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblMonedaCambio.Location = New System.Drawing.Point(495, 87)
        Me.lblMonedaCambio.Name = "lblMonedaCambio"
        Me.lblMonedaCambio.Size = New System.Drawing.Size(268, 20)
        Me.lblMonedaCambio.TabIndex = 92
        Me.lblMonedaCambio.Text = "$0.00 M.N"
        Me.lblMonedaCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblMonedaCambio.Visible = False
        '
        'txtNota
        '
        Me.txtNota.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNota.Location = New System.Drawing.Point(92, 377)
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(459, 20)
        Me.txtNota.TabIndex = 93
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 380)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Nota"
        '
        'FrmAbono
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 411)
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

        If bError = False AndAlso Aplicacion <> "" Then
            If cmbMetodoPago.SelectedValue = 2 OrElse cmbMetodoPago.SelectedValue = 3 Then
                Shell(Aplicacion, AppWinStyle.NormalFocus)
            End If
        End If

        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        'valida que se encuentre una forma de pago seleccionada
        If cmbMetodoPago.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        Else

            Select Case CInt(cmbMetodoPago.SelectedValue)
                Case 1, 7
                    'If bEfectivo = False Then
                    '    i += 1
                    '    reloj = New parpadea(Me.alerta(1))
                    '    reloj.Enabled = True
                    '    reloj.Start()
                    '    MessageBox.Show("¡La Forma de Pago actual no es valida para este Cliente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'End If
                Case 2, 3

                    'If bTarjeta = False Then
                    '    i += 1
                    '    reloj = New parpadea(Me.alerta(1))
                    '    reloj.Enabled = True
                    '    reloj.Start()
                    '    MessageBox.Show("¡La Forma de Pago actual no es valida para este Cliente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'End If

                    'Valida Terminal
                    If ValidaCtaPago = 1 AndAlso cmbTerminal.SelectedValue Is Nothing Then
                        i += 1
                        reloj = New parpadea(Me.alerta(5))
                        reloj.Enabled = True
                        reloj.Start()
                    End If

                    'Valida Banco
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
                    If TxtNumCta.Text <> "" AndAlso TxtNumCta.TextLength <> 4 Then
                        i += 1
                        reloj = New parpadea(Me.alerta(6))
                        reloj.Enabled = True
                        reloj.Start()
                        MessageBox.Show("El número de cuenta debe contener los ultimos 4 digitos de la cuenta bancaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                   

                Case 4, 8
                    'If bCheque = False Then
                    '    i += 1
                    '    reloj = New parpadea(Me.alerta(1))
                    '    reloj.Enabled = True
                    '    reloj.Start()
                    '    MessageBox.Show("¡La Forma de Pago actual no es valida para este Cliente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    'End If

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
                    If TxtNumCta.Text <> "" AndAlso TxtNumCta.TextLength <> 4 Then
                        i += 1
                        reloj = New parpadea(Me.alerta(6))
                        reloj.Enabled = True
                        reloj.Start()
                        MessageBox.Show("El número de cuenta debe contener los 4 ultimos digitos de la cuenta bancaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                Case 5, 6
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
                    If TxtNumCta.Text <> "" AndAlso TxtNumCta.TextLength <> 4 Then
                        i += 1
                        reloj = New parpadea(Me.alerta(6))
                        reloj.Enabled = True
                        reloj.Start()
                        MessageBox.Show("El número de cuenta debe contener los ultimos 4 digitos de la cuenta bancaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
            Else
                dt = ModPOS.Recupera_Tabla("sp_recupera_saldo", "@Tipo", TipoDoc, "@Clave", DocumentoClave)
                Folio = dt.Rows(0)("Folio")
                ClaveCliente = dt.Rows(0)("Clave")
                NombreCliente = dt.Rows(0)("RazonSocial")
                SaldoPuntos = dt.Rows(0)("Puntos")
                SaldoDocumento = dt.Rows(0)("Saldo")
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

        LblSaldo.Text = Format(CStr(ModPOS.TruncateToDecimal(SaldoDocumento, 2)), "Currency")
        LblPuntos.Text = CStr(ModPOS.TruncateToDecimal(SaldoPuntos, 2))

        TxtMonto.Focus()
    End Sub


    Public Sub AddPago(ByVal iTipoPago As Integer, _
                       ByVal sMetodo As String, _
                       ByVal sMoneda As String, _
                       ByVal sMON As String, _
                       ByVal dTC As Double, _
                       ByVal dMonto As Double, _
                       ByVal sBNKClave As String, _
                       ByVal sBanco As String, _
                       ByVal sRef As String, _
                       ByVal sNumCta As String, _
                       ByVal sTERClave As String)



        If iTipoPago = 1 OrElse iTipoPago = 8 Then
            sBNKClave = ""
            sBanco = ""
        End If

        If Not (iTipoPago = 2 OrElse iTipoPago = 3) Then
            sTERClave = ""
        End If

        Dim foundRows() As Data.DataRow
        foundRows = dtDetallePago.Select("TipoPago = " & iTipoPago & " and Moneda = '" & sMoneda & "' and BNKClave ='" & sBNKClave & "' and Ref = '" & sRef & "' and NumCta = '" & sNumCta & "'")




        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtDetallePago.NewRow()
            'declara el nombre de la fila

            TotalPago += (dMonto * dTC)


            If bAnticipo = False AndAlso dMonto * dTC > SaldoDocumento Then
                dMonto = SaldoDocumento / dTC
            End If

            row1.Item("ABNClave") = ModPOS.obtenerLlave
            row1.Item("TipoPago") = iTipoPago
            row1.Item("Metodo") = sMetodo
            row1.Item("Moneda") = sMoneda
            row1.Item("MON") = sMON
            row1.Item("TC") = dTC
            row1.Item("Monto") = dMonto
            row1.Item("BNKClave") = sBNKClave
            row1.Item("Banco") = sBanco
            row1.Item("Ref") = sRef
            row1.Item("NumCta") = sNumCta
            row1.Item("TERClave") = sTERClave
            row1.Item("Saldo") = dMonto * dTC

            dtDetallePago.Rows.Add(row1)
            'agrega la fila completo a la tabla

            SaldoDocumento -= (dMonto * dTC)
            If iTipoPago = 8 Then
                SaldoPuntos -= (dMonto * dTC)
            End If



            If SaldoDocumento < 0 Then
                SaldoDocumento = 0
            End If

            LblSaldo.Text = Format(CStr(ModPOS.TruncateToDecimal(SaldoDocumento, 2)), "Currency")
            LblPuntos.Text = CStr(ModPOS.TruncateToDecimal(SaldoPuntos, 2))
            lblMonedaCambio.Text = Format(CStr(TruncateToDecimal(SaldoDocumento / TipoCambio, 2)), "Currency")


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

        Clave = "AB" & Referencia & "-" & CStr(Folio) & "-" & CStr(Periodo) & CStr(Mes)

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


        dtDetallePago = ModPOS.CrearTabla("DetallePago", _
                     "ABNClave", "System.String", _
                     "TipoPago", "System.Int32", _
                     "Metodo", "System.String", _
                     "Moneda", "System.String", _
                     "MON", "System.String", _
                     "TC", "System.Double", _
                     "Monto", "System.Double", _
                     "BNKClave", "System.String", _
                     "Banco", "System.String", _
                     "Ref", "System.String", _
                     "NumCta", "System.String", _
                     "TERClave", "System.String", _
                     "Saldo", "System.Double")

        GridDetalle.DataSource = dtDetallePago
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("ABNClave").Visible = False
        GridDetalle.RootTable.Columns("TipoPago").Visible = False
        GridDetalle.CurrentTable.Columns("Metodo").Selectable = False
        GridDetalle.RootTable.Columns("Moneda").Visible = False
        GridDetalle.RootTable.Columns("MON").Selectable = False
        GridDetalle.RootTable.Columns("TC").Visible = False
        GridDetalle.RootTable.Columns("TERClave").Visible = False
        GridDetalle.RootTable.Columns("Saldo").Visible = False

        GridDetalle.RootTable.Columns("BNKClave").Visible = False
        GridDetalle.RootTable.Columns("Banco").Selectable = False
        GridDetalle.RootTable.Columns("Monto").Selectable = False



        If bAnticipo = False Then
            recuperaCliente()
        Else
            LblFolio.Text = "ANTICIPO"
        End If

        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "Moneda"
                        Moneda = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "MonedaCambio"
                        MonedaCambio = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "ValidaCtaPago"
                        ValidaCtaPago = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 1, dt.Rows(i)("Valor"))
                End Select
            Next
        End With
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
        BtnTC.Text = dt.Rows(0)("Referencia")
        TipoCambio = dt.Rows(0)("TipoCambio")
        dt.Dispose()

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

        With cmbTerminal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_filtra_terminal"
            .NombreParametro1 = "CAJClave"
            .Parametro1 = CAJClave
            .llenar()
        End With

        FormaPagoLoad = True


        ActMetodoPago(CInt(cmbMetodoPago.SelectedValue))

        TxtMonto.Text = "0.0"

    End Sub

    Private Sub ActMetodoPago(ByVal metodo As Integer)

        Select Case metodo
            Case 1, 7
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

            Case 2, 3
                LblBanco.Visible = True
                CmbBanco.Visible = True

                LblReferencia.Text = "Referencia"
                LblReferencia.Visible = True
                TxtReferencia.Visible = True

                lblNumCta.Visible = True
                TxtNumCta.Visible = True

                lblTerminal.Visible = True
                cmbTerminal.Visible = True
                cmbTerminal.SelectedValue = 0

            Case 4, 8
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
            Case 5, 6
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
            Case Else
                LblBanco.Visible = False
                CmbBanco.Visible = False

                LblReferencia.Visible = False
                TxtReferencia.Text = ""
                TxtReferencia.Visible = False

                lblNumCta.Visible = False
                TxtNumCta.Text = ""
                TxtNumCta.Visible = False

                lblTerminal.Visible = False
                cmbTerminal.Visible = False
                cmbTerminal.SelectedValue = 0
        End Select


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

            If Not cmbMetodoPago.SelectedValue Is Nothing Then

                Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_valor", "@Tabla", "CFD", "@Campo", "MetodoPago", "@Valor", cmbMetodoPago.SelectedValue)
                Dim sClaveSAT As String
                sClaveSAT = IIf(dt.Rows(0)("ClaveSAT").GetType.Name = "DBNull", "", dt.Rows(0)("ClaveSAT"))
                dt.Dispose()
                If sClaveSAT = "" Then
                    Beep()
                    MessageBox.Show("El metodo de pago seleccionado no cuenta con una Clave SAT valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    bError = True
                    Exit Sub
                End If
            End If




            If cmbMetodoPago.SelectedValue <> 1 Then
                If bAnticipo = False AndAlso ModPOS.TruncateToDecimal(Monto * TipoCambio, 2) > ModPOS.TruncateToDecimal(SaldoDocumento, 2) Then
                    Beep()
                    MessageBox.Show("No es posible registrar pagos debido a que el Monto a pagar es mayor al saldo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    bError = True
                    Exit Sub
                End If
            End If

            Dim sBNKClave, sBanco, sTerminal As String
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

            AddPago(cmbMetodoPago.SelectedValue, cmbMetodoPago.SelectedItem(1), Moneda, BtnTC.Text, TipoCambio, Monto, sBNKClave, sBanco, TxtReferencia.Text.Trim.ToUpper, TxtNumCta.Text.Trim.ToUpper, sTerminal)

            TxtMonto.Text = ""
            TxtReferencia.Text = ""
            TxtNumCta.Text = ""
            Monto = 0

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

        If CDbl(TxtMonto.Text) > 0 Then
            procesarPago(False)
        ElseIf dtDetallePago.Rows.Count = 0 Then
            MessageBox.Show("Operación no registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            bError = True
            Exit Sub
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
                              "@TipoCambio", dtDetallePago.Rows(i)("TC"), _
                              "@Cantidad", Math.Round(dtDetallePago.Rows(i)("Saldo"), 2), _
                              "@Saldo", Math.Round(dtDetallePago.Rows(i)("Saldo"), 2), _
                              "@BNKClave", dtDetallePago.Rows(i)("BNKClave"), _
                              "@Referencia", dtDetallePago.Rows(i)("Ref"), _
                              "@NumCta", dtDetallePago.Rows(i)("NumCta"), _
                              "@Nota", txtNota.Text, _
                              "@TERClave", dtDetallePago.Rows(i)("TERClave"), _
                              "@Usuario", ModPOS.UsuarioActual)


             

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
                    ModPOS.Ejecuta("sp_act_puntos", "@CTEClave", CTEClave, "@Cantidad", Math.Round(dtDetallePago.Rows(i)("Saldo"), 2))
                End If

                ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", CTEClave, "@Importe", Math.Round(dtDetallePago.Rows(i)("Saldo"), 2))
            Next

            Nota = txtNota.Text
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        bError = False
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
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

    Private Sub TxtReferencia_DockChanged(sender As Object, e As EventArgs) Handles TxtReferencia.DockChanged

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
            lblMonedaCambio.Text = Format(CStr(TruncateToDecimal(SaldoDocumento / TipoCambio, 2)), "Currency")
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
        Process.Start("osk.exe")
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
                dt = ModPOS.SiExisteRecupera("sp_recupera_clavecte", "@Clave", TxtCliente.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
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

  
End Class
