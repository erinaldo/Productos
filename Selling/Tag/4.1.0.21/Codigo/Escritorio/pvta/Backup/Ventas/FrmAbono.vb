Public Class FrmAbono
    Inherits System.Windows.Forms.Form


    Public Aplicacion As String = ""
    Public bTouch As Boolean = False
    Public bAnticipo As Boolean = False
    Private Moneda As String

    Private TipoDoc As Integer  '1: Ticket, 2:Factura
    Private DocumentoClave As String
    Private ABNClave As String
    Public CTEClave As String

    Private ClaveCliente As String = ""
    Private NombreCliente As String

    Private Folio As String
    Private SaldoDocumento As Double
    Private bEfectivo, bCheque, bTarjeta As Boolean
    Private CAJClave As String
    Private SaldoPuntos As Double
    Private Multiple As Boolean = False
    Private Cajon As Boolean = False
    Private Impresora As String

    Private Importe, TipoCambio As Double
    Private TotalPago As Double = 0
    Private Cambio As Double = 0
    Private bError As Boolean = False

    Private alerta(5) As PictureBox
    Private reloj As parpadea
    Private FormaPagoLoad As Boolean = False

    Private iPublicoGral As Integer = 0

    Private dtMetodosPago As DataTable

    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LblPuntos As System.Windows.Forms.Label
    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblFolio As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents picKeyboard As System.Windows.Forms.PictureBox
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

    Public ReadOnly Property AbonoClave() As String
        Get
            AbonoClave = ABNClave
        End Get
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

    Public WriteOnly Property ClaveCte() As String
        Set(ByVal Value As String)
            CTEClave = Value
        End Set
    End Property

    Public ReadOnly Property SaldoVenta() As Double
        Get
            SaldoVenta = SaldoDocumento
        End Get
    End Property

    Public ReadOnly Property TotalAbono() As Double
        Get
            TotalAbono = TotalPago
        End Get
    End Property

    Public ReadOnly Property TotalCambio() As Double
        Get
            TotalCambio = Cambio
        End Get
    End Property

    Public ReadOnly Property TPago() As Integer
        Get
            TPago = cmbMetodoPago.SelectedValue()
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
    Friend WithEvents TxtImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAbono))
        Me.Label12 = New System.Windows.Forms.Label
        Me.GrpAbono = New System.Windows.Forms.GroupBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.LblReferencia = New System.Windows.Forms.Label
        Me.LblBanco = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.LblTipoCambio = New System.Windows.Forms.Label
        Me.BtnTC = New Janus.Windows.EditControls.UIButton
        Me.CtxDocumentos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.cmbMetodoPago = New Selling.StoreCombo
        Me.TxtImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtReferencia = New System.Windows.Forms.TextBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.CmbBanco = New Selling.StoreCombo
        Me.LblSaldo = New System.Windows.Forms.Label
        Me.BtnOK = New Janus.Windows.EditControls.UIButton
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.TxtCliente = New System.Windows.Forms.TextBox
        Me.BtnCliente = New Janus.Windows.EditControls.UIButton
        Me.LblNombreCliente = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblPuntos = New System.Windows.Forms.Label
        Me.TxtNota = New System.Windows.Forms.TextBox
        Me.GrpMetodos = New System.Windows.Forms.GroupBox
        Me.GridMetodos = New Janus.Windows.GridEX.GridEX
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblFolio = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.picKeyboard = New System.Windows.Forms.PictureBox
        Me.GrpAbono.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GrpMetodos.SuspendLayout()
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label12.Location = New System.Drawing.Point(7, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(172, 23)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "FOLIO"
        '
        'GrpAbono
        '
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
        Me.GrpAbono.Controls.Add(Me.TxtImporte)
        Me.GrpAbono.Controls.Add(Me.TxtReferencia)
        Me.GrpAbono.Controls.Add(Me.PictureBox3)
        Me.GrpAbono.Controls.Add(Me.CmbBanco)
        Me.GrpAbono.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpAbono.Location = New System.Drawing.Point(7, 115)
        Me.GrpAbono.Name = "GrpAbono"
        Me.GrpAbono.Size = New System.Drawing.Size(318, 199)
        Me.GrpAbono.TabIndex = 0
        Me.GrpAbono.TabStop = False
        Me.GrpAbono.Text = "Registro de Abono"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(98, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox1.TabIndex = 63
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(98, 59)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox2.TabIndex = 69
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(98, 128)
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
        Me.Label6.Location = New System.Drawing.Point(5, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 16)
        Me.Label6.TabIndex = 82
        Me.Label6.Text = "IMPORTE"
        '
        'LblReferencia
        '
        Me.LblReferencia.AutoSize = True
        Me.LblReferencia.Location = New System.Drawing.Point(4, 130)
        Me.LblReferencia.Name = "LblReferencia"
        Me.LblReferencia.Size = New System.Drawing.Size(116, 17)
        Me.LblReferencia.TabIndex = 81
        Me.LblReferencia.Text = "No. Cta o Tarjeta"
        '
        'LblBanco
        '
        Me.LblBanco.AutoSize = True
        Me.LblBanco.Location = New System.Drawing.Point(4, 97)
        Me.LblBanco.Name = "LblBanco"
        Me.LblBanco.Size = New System.Drawing.Size(48, 17)
        Me.LblBanco.TabIndex = 80
        Me.LblBanco.Text = "Banco"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 17)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "Moneda"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 61)
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
        Me.LblTipoCambio.Location = New System.Drawing.Point(371, 52)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(126, 15)
        Me.LblTipoCambio.TabIndex = 77
        Me.LblTipoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnTC
        '
        Me.BtnTC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnTC.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton
        Me.BtnTC.ContextMenuStrip = Me.CtxDocumentos
        Me.BtnTC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTC.Location = New System.Drawing.Point(121, 20)
        Me.BtnTC.Name = "BtnTC"
        Me.BtnTC.Size = New System.Drawing.Size(184, 28)
        Me.BtnTC.TabIndex = 3
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
        Me.PictureBox5.Location = New System.Drawing.Point(98, 164)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox5.TabIndex = 76
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'cmbMetodoPago
        '
        Me.cmbMetodoPago.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMetodoPago.Location = New System.Drawing.Point(121, 58)
        Me.cmbMetodoPago.Name = "cmbMetodoPago"
        Me.cmbMetodoPago.Size = New System.Drawing.Size(184, 24)
        Me.cmbMetodoPago.TabIndex = 4
        '
        'TxtImporte
        '
        Me.TxtImporte.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.TxtImporte.Location = New System.Drawing.Point(121, 161)
        Me.TxtImporte.Name = "TxtImporte"
        Me.TxtImporte.Size = New System.Drawing.Size(184, 23)
        Me.TxtImporte.TabIndex = 0
        Me.TxtImporte.Text = "$0.00"
        Me.TxtImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtImporte.Value = 0
        Me.TxtImporte.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(121, 127)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(184, 23)
        Me.TxtReferencia.TabIndex = 2
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(98, 97)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox3.TabIndex = 65
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'CmbBanco
        '
        Me.CmbBanco.BackColor = System.Drawing.SystemColors.Window
        Me.CmbBanco.Location = New System.Drawing.Point(121, 94)
        Me.CmbBanco.Name = "CmbBanco"
        Me.CmbBanco.Size = New System.Drawing.Size(184, 24)
        Me.CmbBanco.TabIndex = 1
        '
        'LblSaldo
        '
        Me.LblSaldo.BackColor = System.Drawing.Color.Transparent
        Me.LblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaldo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblSaldo.Location = New System.Drawing.Point(122, 80)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(203, 37)
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
        Me.BtnOK.Location = New System.Drawing.Point(677, 350)
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
        Me.BtnCancel.Location = New System.Drawing.Point(581, 350)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.PictureBox6)
        Me.GroupBox1.Controls.Add(Me.TxtCliente)
        Me.GroupBox1.Controls.Add(Me.BtnCliente)
        Me.GroupBox1.Controls.Add(Me.LblNombreCliente)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(762, 43)
        Me.GroupBox1.TabIndex = 66
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cliente"
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(163, 16)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(24, 20)
        Me.PictureBox6.TabIndex = 83
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'TxtCliente
        '
        Me.TxtCliente.Enabled = False
        Me.TxtCliente.Location = New System.Drawing.Point(4, 16)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(116, 20)
        Me.TxtCliente.TabIndex = 61
        Me.TxtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnCliente
        '
        Me.BtnCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCliente.Icon = CType(resources.GetObject("BtnCliente.Icon"), System.Drawing.Icon)
        Me.BtnCliente.ImageSize = New System.Drawing.Size(30, 30)
        Me.BtnCliente.Location = New System.Drawing.Point(125, 8)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(33, 33)
        Me.BtnCliente.TabIndex = 3
        Me.BtnCliente.ToolTipText = "Busqueda de Cliente"
        Me.BtnCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblNombreCliente
        '
        Me.LblNombreCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblNombreCliente.BackColor = System.Drawing.Color.Transparent
        Me.LblNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombreCliente.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblNombreCliente.Location = New System.Drawing.Point(167, 15)
        Me.LblNombreCliente.Name = "LblNombreCliente"
        Me.LblNombreCliente.Size = New System.Drawing.Size(587, 17)
        Me.LblNombreCliente.TabIndex = 60
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.LblPuntos)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 345)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(527, 42)
        Me.GroupBox2.TabIndex = 67
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(183, 16)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "PUNTOS ACUMULADOS:"
        '
        'LblPuntos
        '
        Me.LblPuntos.BackColor = System.Drawing.Color.Transparent
        Me.LblPuntos.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPuntos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblPuntos.Location = New System.Drawing.Point(253, 5)
        Me.LblPuntos.Name = "LblPuntos"
        Me.LblPuntos.Size = New System.Drawing.Size(224, 37)
        Me.LblPuntos.TabIndex = 67
        Me.LblPuntos.Text = "$0.00 M.N"
        Me.LblPuntos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtNota
        '
        Me.TxtNota.Location = New System.Drawing.Point(120, 323)
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.Size = New System.Drawing.Size(647, 20)
        Me.TxtNota.TabIndex = 1
        '
        'GrpMetodos
        '
        Me.GrpMetodos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpMetodos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpMetodos.Controls.Add(Me.GridMetodos)
        Me.GrpMetodos.Location = New System.Drawing.Point(330, 84)
        Me.GrpMetodos.Name = "GrpMetodos"
        Me.GrpMetodos.Size = New System.Drawing.Size(441, 230)
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
        Me.GridMetodos.Size = New System.Drawing.Size(429, 208)
        Me.GridMetodos.TabIndex = 1
        Me.GridMetodos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 328)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 16)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "COMENTARIO"
        '
        'LblFolio
        '
        Me.LblFolio.AutoSize = True
        Me.LblFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFolio.Location = New System.Drawing.Point(86, 17)
        Me.LblFolio.Name = "LblFolio"
        Me.LblFolio.Size = New System.Drawing.Size(0, 16)
        Me.LblFolio.TabIndex = 84
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 16)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "CANT. A PAGAR"
        '
        'picKeyboard
        '
        Me.picKeyboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picKeyboard.BackColor = System.Drawing.Color.Transparent
        Me.picKeyboard.Image = Global.Selling.My.Resources.Resources._1403657593_519640_141_Keyboard
        Me.picKeyboard.Location = New System.Drawing.Point(736, 7)
        Me.picKeyboard.Name = "picKeyboard"
        Me.picKeyboard.Size = New System.Drawing.Size(35, 33)
        Me.picKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picKeyboard.TabIndex = 86
        Me.picKeyboard.TabStop = False
        '
        'FrmAbono
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(774, 395)
        Me.Controls.Add(Me.picKeyboard)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblFolio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GrpMetodos)
        Me.Controls.Add(Me.TxtNota)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
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
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GrpMetodos.ResumeLayout(False)
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).EndInit()
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


                Case Is = 1 AndAlso bEfectivo = False
                    i += 1
                    reloj = New parpadea(Me.alerta(1))
                    reloj.Enabled = True
                    reloj.Start()
                    MessageBox.Show("¡La Forma de Pago actual no es valida para este Cliente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)


                Case Is = 4 AndAlso bCheque = False
                    i += 1
                    reloj = New parpadea(Me.alerta(1))
                    reloj.Enabled = True
                    reloj.Start()
                    MessageBox.Show("¡La Forma de Pago actual no es valida para este Cliente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Case Is = (2 OrElse 3) AndAlso bTarjeta = False
                    i += 1
                    reloj = New parpadea(Me.alerta(1))
                    reloj.Enabled = True
                    reloj.Start()
                    MessageBox.Show("¡La Forma de Pago actual no es valida para este Cliente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                Case 8 AndAlso CDbl(TxtImporte.Text) > SaldoPuntos
                    i += 1
                    reloj = New parpadea(Me.alerta(1))
                    reloj.Enabled = True
                    reloj.Start()
                    MessageBox.Show("¡Los Puntos seleccionados exceden a los acumulados de el Cliente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End Select

        End If
        
        If TxtImporte.Text = "" Then
            Importe = 0
        Else
            Importe = Math.Abs(CDbl(TxtImporte.Text))
        End If

        'valida que el importe sea diferente de cero

        If Importe = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If


        'valida que si la forma de pago sea diferente de contado exista un banco
        If (cmbMetodoPago.SelectedValue > 1 AndAlso cmbMetodoPago.SelectedValue <= 6) AndAlso CmbBanco.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        'Valida que si la forma de pago sea diferente de contado exista una referencia
        If (cmbMetodoPago.SelectedValue > 1 AndAlso cmbMetodoPago.SelectedValue <= 6) AndAlso TxtReferencia.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If


        'Valida que si la forma de pago sea diferente de contado exista una referencia
        If TxtReferencia.Text <> "" AndAlso TxtReferencia.TextLength < 4 Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
            MessageBox.Show("La referencia debe contener al menos 4 carates o digitos. Por ejemplo los ultimos 4 digitos de la tarjea o de la cuenta bancaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


        If ClaveCliente = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
            MessageBox.Show("Debe seleccionar un Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
        TxtCliente.Text = ClaveCliente
        LblNombreCliente.Text = NombreCliente
        LblSaldo.Text = Format(CStr(ModPOS.Redondear(SaldoDocumento, 2)), "Currency")
        LblPuntos.Text = CStr(ModPOS.Redondear(SaldoPuntos, 2))


    End Sub

    Private Sub FrmAbono_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dt As DataTable
        Dim i As Integer

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
                        Exit For
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



        With cmbMetodoPago
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "CFD"
            .NombreParametro2 = "campo"
            .Parametro2 = "MetodoPago"
            .llenar()
        End With

        With CmbBanco
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_bancos"
            .llenar()
        End With

        FormaPagoLoad = True


        If CInt(cmbMetodoPago.SelectedValue) = 1 OrElse CInt(cmbMetodoPago.SelectedValue) >= 7 Then
            CmbBanco.Visible = False
            TxtReferencia.Visible = False
        Else
            CmbBanco.Visible = True
            TxtReferencia.Visible = True
        End If

        TxtImporte.Text = "0.0"
        TxtImporte.Focus()

    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If validaForm() Then


            ABNClave = ModPOS.obtenerLlave

            Importe *= TipoCambio

            TotalPago = Redondear(Importe, 2)

            If bAnticipo = False Then
                Select Case TotalPago
                    Case Is > Redondear(SaldoDocumento, 2)
                        Cambio = TotalPago - SaldoDocumento
                    Case Is < Redondear(SaldoDocumento, 2)
                        Cambio = 0
                    Case Is = Redondear(SaldoDocumento, 2)
                        Cambio = 0
                End Select

                If cmbMetodoPago.SelectedValue = 8 Then
                    If SaldoPuntos < TotalPago Then
                        bError = True
                        Me.DialogResult = DialogResult.Cancel
                        Beep()
                        MessageBox.Show("El importe excede el saldo de puntos disponibles para el cliente actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                End If

            Else
                Cambio = 0

                If cmbMetodoPago.SelectedValue = 8 Then
                    Beep()
                    MessageBox.Show("No es posible registrar anticipos cuya forma de Pago sea Puntos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    bError = True
                    Exit Sub
                End If

            End If


           

            If Cajon = True Then
                ModPOS.AbrirCajon(Impresora)
            End If

            If cmbMetodoPago.SelectedValue = 1 OrElse cmbMetodoPago.SelectedValue >= 7 Then

                If TotalPago = Redondear(SaldoDocumento, 2) OrElse TotalPago > Redondear(SaldoDocumento, 2) Then

                    If cmbMetodoPago.SelectedValue = 8 Then
                        ModPOS.Ejecuta("sp_act_puntos", "@CTEClave", CTEClave, "@Cantidad", SaldoDocumento)
                    End If

                    If bAnticipo = True Then
                        SaldoDocumento = TotalPago
                    End If

                    ModPOS.Ejecuta("sp_inserta_abono", _
                                  "@ABNClave", ABNClave, _
                                  "@CAJClave", CAJClave, _
                                  "@CTEClave", CTEClave, _
                                  "@TipoPago", cmbMetodoPago.SelectedValue, _
                                  "@Moneda", Moneda, _
                                  "@TipoCambio", TipoCambio, _
                                  "@Cantidad", SaldoDocumento, _
                                  "@Saldo", SaldoDocumento, _
                                  "@BNKClave", "", _
                                  "@Referencia", "", _
                                  "@Nota", TxtNota.Text.Trim.ToUpper, _
                                  "@Usuario", ModPOS.UsuarioActual)
                Else

                    If cmbMetodoPago.SelectedValue = 8 Then
                        ModPOS.Ejecuta("sp_act_puntos", "@CTEClave", CTEClave, "@Cantidad", TotalPago)
                    End If

                    ModPOS.Ejecuta("sp_inserta_abono", _
                                                    "@ABNClave", ABNClave, _
                                                    "@CAJClave", CAJClave, _
                                                     "@CTEClave", CTEClave, _
                                                     "@TipoPago", cmbMetodoPago.SelectedValue, _
                                                     "@Moneda", Moneda, _
                                                     "@TipoCambio", TipoCambio, _
                                                     "@Cantidad", TotalPago, _
                                                     "@Saldo", TotalPago, _
                                                     "@BNKClave", "", _
                                                     "@Referencia", "", _
                                                     "@Nota", TxtNota.Text.Trim.ToUpper, _
                                                     "@Usuario", ModPOS.UsuarioActual)

                End If

            Else
                ModPOS.Ejecuta("sp_inserta_abono", _
                                "@ABNClave", ABNClave, _
                              "@CAJClave", CAJClave, _
                              "@CTEClave", CTEClave, _
                              "@TipoPago", cmbMetodoPago.SelectedValue, _
                              "@Moneda", Moneda, _
                              "@TipoCambio", TipoCambio, _
                              "@Cantidad", TotalPago, _
                              "@Saldo", TotalPago, _
                              "@BNKClave", CmbBanco.SelectedValue, _
                              "@Referencia", TxtReferencia.Text.ToUpper.Trim, _
                              "@Nota", TxtNota.Text.Trim.ToUpper, _
                              "@Usuario", ModPOS.UsuarioActual)
            End If

            Dim sBNKClave As String

            If cmbMetodoPago.SelectedValue = 1 OrElse cmbMetodoPago.SelectedValue > 7 Then
                sBNKClave = ""
            Else
                sBNKClave = CmbBanco.SelectedValue
            End If

            If Me.GridMetodos.RecordCount = 0 Then
                If iPublicoGral > 0 Then
                    If cmbMetodoPago.SelectedValue = 1 Then
                        ModPOS.Ejecuta("sp_inserta_clientepago", _
                         "@MTPClave", ModPOS.obtenerLlave, _
                         "@CTEClave", CTEClave, _
                         "@MetodoPago", cmbMetodoPago.SelectedValue, _
                         "@BNKClave", sBNKClave, _
                         "@Referencia", TxtReferencia.Text.Trim.ToUpper, _
                         "@Preferido", 1, _
                         "@Estado", 1, _
                         "@Usuario", ModPOS.UsuarioActual)
                    End If
                Else
                    If cmbMetodoPago.SelectedValue < 7 Then
                        ModPOS.Ejecuta("sp_inserta_clientepago", _
                         "@MTPClave", ModPOS.obtenerLlave, _
                         "@CTEClave", CTEClave, _
                         "@MetodoPago", cmbMetodoPago.SelectedValue, _
                         "@BNKClave", sBNKClave, _
                         "@Referencia", TxtReferencia.Text.Trim.ToUpper, _
                         "@Preferido", 1, _
                         "@Estado", 1, _
                         "@Usuario", ModPOS.UsuarioActual)
                    End If
                End If
            Else
                Dim foundRows() As Data.DataRow

                foundRows = dtMetodosPago.Select("MetodoPago = " & cmbMetodoPago.SelectedValue & " and Referencia like '" & TxtReferencia.Text.Trim.ToUpper & "' and BNKClave like '" & sBNKClave & "'")
                If foundRows.Length = 0 Then
                    If iPublicoGral = 0 Then
                        If cmbMetodoPago.SelectedValue < 7 Then
                            'Agrega ClientePago
                            ModPOS.Ejecuta("sp_inserta_clientepago", _
                            "@MTPClave", ModPOS.obtenerLlave, _
                            "@CTEClave", CTEClave, _
                            "@MetodoPago", cmbMetodoPago.SelectedValue, _
                            "@BNKClave", sBNKClave, _
                            "@Referencia", TxtReferencia.Text.Trim.ToUpper, _
                            "@Preferido", 0, _
                            "@Estado", 1, _
                            "@Usuario", ModPOS.UsuarioActual)
                        End If
                    End If
                End If
            End If


            bError = False
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            bError = True
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        bError = False
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmbFormaPago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMetodoPago.SelectedIndexChanged
        If FormaPagoLoad = True Then

            If CInt(cmbMetodoPago.SelectedValue) = 1 OrElse CInt(cmbMetodoPago.SelectedValue) >= 7 Then
                CmbBanco.Visible = False
                TxtReferencia.Visible = False
            Else
                CmbBanco.Visible = True
                TxtReferencia.Visible = True
            End If

            TxtImporte.Text = "0.0"
            
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

    Private Sub Ctrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbMetodoPago.KeyDown, CmbBanco.KeyDown, TxtReferencia.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub BtnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCliente.Click
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

    Private Sub TxtImporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtImporte.Click
        If bTouch = True Then
            Dim a As New FrmTecladoNum
            a.Text = "Importe"
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                Me.TxtImporte.Text = a.Cantidad
                BtnOK.PerformClick()
            End If
        End If
    End Sub

    Private Sub TxtImporte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtImporte.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            BtnOK.PerformClick()
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
            LblTipoCambio.Text = "T.C. " & Format(CStr(ModPOS.Redondear(TipoCambio, 2)), "Currency")
        Else
            LblTipoCambio.Text = ""
        End If
        SendKeys.Send("{TAB}")

    End Sub

    Private Sub GridMetodos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridMetodos.DoubleClick
        If Not Me.GridMetodos.GetValue("MTPClave") Is Nothing Then
            cmbMetodoPago.SelectedValue = GridMetodos.GetValue("MetodoPago")
            CmbBanco.SelectedValue = GridMetodos.GetValue("BNKClave")
            TxtReferencia.Text = GridMetodos.GetValue("Referencia")
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
    End Sub

    Private Sub picKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picKeyboard.Click
        Process.Start("osk.exe")
    End Sub
End Class
