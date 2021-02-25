Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmDevolucion
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
    Friend WithEvents GrpTickets As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbMotivo As Selling.StoreCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnFolio As Janus.Windows.EditControls.UIButton
    Friend WithEvents rbCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rbFolio As System.Windows.Forms.RadioButton
    Friend WithEvents btnCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnProducto As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents grpBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents ChkFijar As Selling.ChkStatus
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents BtnDel As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnConsultar As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDevolucion))
        Me.GrpTickets = New System.Windows.Forms.GroupBox()
        Me.BtnDel = New Janus.Windows.EditControls.UIButton()
        Me.ChkFijar = New Selling.ChkStatus(Me.components)
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbMotivo = New Selling.StoreCombo()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.btnFolio = New Janus.Windows.EditControls.UIButton()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.BtnOK = New Janus.Windows.EditControls.UIButton()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.btnCliente = New Janus.Windows.EditControls.UIButton()
        Me.rbFolio = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbCliente = New System.Windows.Forms.RadioButton()
        Me.btnProducto = New Janus.Windows.EditControls.UIButton()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.grpBusqueda = New System.Windows.Forms.GroupBox()
        Me.BtnConsultar = New Janus.Windows.EditControls.UIButton()
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.GrpTickets.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBusqueda.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpTickets
        '
        Me.GrpTickets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.BtnDel)
        Me.GrpTickets.Controls.Add(Me.ChkFijar)
        Me.GrpTickets.Controls.Add(Me.GridDetalle)
        Me.GrpTickets.Controls.Add(Me.Label4)
        Me.GrpTickets.Controls.Add(Me.cmbMotivo)
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(7, 118)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(785, 306)
        Me.GrpTickets.TabIndex = 0
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Detalle Devolución"
        '
        'BtnDel
        '
        Me.BtnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.Location = New System.Drawing.Point(721, 16)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(58, 24)
        Me.BtnDel.TabIndex = 130
        Me.BtnDel.ToolTipText = "Elimina la partida seleccionada"
        Me.BtnDel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkFijar
        '
        Me.ChkFijar.Location = New System.Drawing.Point(7, 19)
        Me.ChkFijar.Name = "ChkFijar"
        Me.ChkFijar.Size = New System.Drawing.Size(142, 22)
        Me.ChkFijar.TabIndex = 129
        Me.ChkFijar.Text = "Fijar Motivo"
        '
        'GridDetalle
        '
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.GroupByBoxVisible = False
        Me.GridDetalle.Location = New System.Drawing.Point(7, 44)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(772, 256)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridDetalle.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(155, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(149, 20)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Motivo de Devolución"
        '
        'cmbMotivo
        '
        Me.cmbMotivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMotivo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMotivo.Location = New System.Drawing.Point(310, 17)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.Size = New System.Drawing.Size(366, 24)
        Me.cmbMotivo.TabIndex = 42
        '
        'txtCliente
        '
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(146, 47)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(122, 21)
        Me.txtCliente.TabIndex = 50
        '
        'btnFolio
        '
        Me.btnFolio.Image = CType(resources.GetObject("btnFolio.Image"), System.Drawing.Image)
        Me.btnFolio.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnFolio.Location = New System.Drawing.Point(274, 15)
        Me.btnFolio.Name = "btnFolio"
        Me.btnFolio.Size = New System.Drawing.Size(48, 26)
        Me.btnFolio.TabIndex = 49
        Me.btnFolio.ToolTipText = "Busqueda de Ticket"
        Me.btnFolio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(146, 18)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(122, 21)
        Me.TxtFolio.TabIndex = 0
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(702, 430)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 37)
        Me.BtnOK.TabIndex = 10
        Me.BtnOK.Text = "Aceptar"
        Me.BtnOK.ToolTipText = "Guardar cambios"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(606, 430)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 5
        Me.BtnSalir.Text = "ESC- Salir"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnCliente
        '
        Me.btnCliente.Image = CType(resources.GetObject("btnCliente.Image"), System.Drawing.Image)
        Me.btnCliente.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnCliente.Location = New System.Drawing.Point(274, 44)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(48, 26)
        Me.btnCliente.TabIndex = 52
        Me.btnCliente.ToolTipText = "Busqueda de Ticket"
        Me.btnCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'rbFolio
        '
        Me.rbFolio.AutoSize = True
        Me.rbFolio.Checked = True
        Me.rbFolio.Location = New System.Drawing.Point(7, 21)
        Me.rbFolio.Name = "rbFolio"
        Me.rbFolio.Size = New System.Drawing.Size(95, 17)
        Me.rbFolio.TabIndex = 53
        Me.rbFolio.TabStop = True
        Me.rbFolio.Text = "Folio de Ticket"
        Me.rbFolio.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(23, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 14)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Producto"
        '
        'rbCliente
        '
        Me.rbCliente.AutoSize = True
        Me.rbCliente.Location = New System.Drawing.Point(7, 50)
        Me.rbCliente.Name = "rbCliente"
        Me.rbCliente.Size = New System.Drawing.Size(57, 17)
        Me.rbCliente.TabIndex = 54
        Me.rbCliente.Text = "Cliente"
        Me.rbCliente.UseVisualStyleBackColor = True
        '
        'btnProducto
        '
        Me.btnProducto.Image = CType(resources.GetObject("btnProducto.Image"), System.Drawing.Image)
        Me.btnProducto.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnProducto.Location = New System.Drawing.Point(328, 75)
        Me.btnProducto.Name = "btnProducto"
        Me.btnProducto.Size = New System.Drawing.Size(48, 26)
        Me.btnProducto.TabIndex = 57
        Me.btnProducto.ToolTipText = "Busqueda de Ticket"
        Me.btnProducto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtProducto
        '
        Me.txtProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.Location = New System.Drawing.Point(200, 78)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(122, 21)
        Me.txtProducto.TabIndex = 56
        '
        'grpBusqueda
        '
        Me.grpBusqueda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpBusqueda.Controls.Add(Me.BtnConsultar)
        Me.grpBusqueda.Controls.Add(Me.TxtCantidad)
        Me.grpBusqueda.Controls.Add(Me.txtNombre)
        Me.grpBusqueda.Controls.Add(Me.txtRazonSocial)
        Me.grpBusqueda.Controls.Add(Me.btnProducto)
        Me.grpBusqueda.Controls.Add(Me.rbFolio)
        Me.grpBusqueda.Controls.Add(Me.txtProducto)
        Me.grpBusqueda.Controls.Add(Me.Label2)
        Me.grpBusqueda.Controls.Add(Me.rbCliente)
        Me.grpBusqueda.Controls.Add(Me.btnFolio)
        Me.grpBusqueda.Controls.Add(Me.txtCliente)
        Me.grpBusqueda.Controls.Add(Me.TxtFolio)
        Me.grpBusqueda.Controls.Add(Me.btnCliente)
        Me.grpBusqueda.Location = New System.Drawing.Point(7, 4)
        Me.grpBusqueda.Name = "grpBusqueda"
        Me.grpBusqueda.Size = New System.Drawing.Size(785, 108)
        Me.grpBusqueda.TabIndex = 57
        Me.grpBusqueda.TabStop = False
        Me.grpBusqueda.Text = "Busqueda"
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsultar.Icon = CType(resources.GetObject("BtnConsultar.Icon"), System.Drawing.Icon)
        Me.BtnConsultar.Location = New System.Drawing.Point(692, 11)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(87, 30)
        Me.BtnConsultar.TabIndex = 129
        Me.BtnConsultar.Text = "Historico"
        Me.BtnConsultar.ToolTipText = "Consultar historico de devoluciones"
        Me.BtnConsultar.Visible = False
        Me.BtnConsultar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(146, 79)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(48, 20)
        Me.TxtCantidad.TabIndex = 60
        Me.TxtCantidad.Text = "1.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 1.0R
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(380, 78)
        Me.txtNombre.Multiline = True
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(399, 21)
        Me.txtNombre.TabIndex = 59
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRazonSocial.Enabled = False
        Me.txtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazonSocial.Location = New System.Drawing.Point(328, 47)
        Me.txtRazonSocial.Multiline = True
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(451, 21)
        Me.txtRazonSocial.TabIndex = 58
        '
        'FrmDevolucion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(799, 473)
        Me.Controls.Add(Me.grpBusqueda)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.GrpTickets)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmDevolucion"
        Me.Text = "Devolución de Venta"
        Me.GrpTickets.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBusqueda.ResumeLayout(False)
        Me.grpBusqueda.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Padre As String = ""
    Public bLiquidacion As Boolean = False
    Public Ventas() As DataRow
    Public Referencia As String
    Public DEVClave As String
    Public CAJClave As String
    Public ALMClave As String
    Public Impresora As String
    Public Caja As String
    Public Cajon As Boolean = False
    Public reciboTicket As Integer = 1
    Public TicketDev As String = ""
    Public ActivaCaja As Boolean = False
    Public ActivaDevolucion As Boolean = False
    Public SUCClave As String
    Public Atiende As String
    Public PrintGeneric As Boolean

    Private IDCorte As String = ""
    Private ListaPrecio As String = ""
    Private MaskCte As Integer = 0
    Private TipoSucursal As Integer

    Private NCClave As String = ""
    Private ImpresoraFac As String = ""
    
    Private CTEClave, PROClave, IPConcentrador As String
    Private DiasMaxDev As Integer = 0
    Private TallaColor, DevConcentra As Integer

    Private Folio As Integer
    Private SUCClavePadre As String
    Private Autoriza, StageDev, StageCan As String
    Private InterfazSalida As String = ""
    Private Estado As Integer = 0

    Private dtVenta, dtDetalle, dtMotivo As DataTable
    Private CantidadDevolver As Double

    Private bLoad As Boolean = False

    Private Mes As Integer
    Private Periodo As Integer
    Private dtBloqueados, dtPAC, dtReembolsos As DataTable

    Private Moneda, FormatNC As String
    Private MonedaRef As String
    Private MonedaDesc As String

    Private bError As Boolean = False
    Private oCFD As CFD
    Private MaxRow As Integer
    Private iRegimenFiscal As Integer
    Private MailAdress, DisplayName, MailUser, MailPassword, HostSMTP As String
    Private MailPort As Integer
    Private MailSSL As Boolean

    Private PathXML As String


    Private Sub reinicializa()
        dtBloqueados = ModPOS.CrearTabla("Bloqueados", _
                                             "PROClave", "System.String", _
                                             "Bloquear", "System.Double")


        dtReembolsos = ModPOS.CrearTabla("Reembolsos", _
                                                "DEVClave", "System.String", _
                                                "MONClave", "System.String", _
                                                "TipoCambio", "System.Double", _
                                                "Importe", "System.Double")




        TxtFolio.Enabled = False
        btnFolio.Enabled = False
        rbFolio.Checked = False
        rbCliente.Checked = True
        BtnDel.Enabled = True

        txtCliente.Enabled = True
        txtProducto.Enabled = True
        btnCliente.Enabled = True
        btnProducto.Enabled = True
        TxtCantidad.Enabled = True
        TxtCantidad.Text = "1"

        TxtFolio.Text = ""
        txtNombre.Text = ""
        txtRazonSocial.Text = ""
        CTEClave = ""
        PROClave = ""

        AgregarFolio(True)

    End Sub


    Private Sub FrmDevolucion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        oCFD = New CFD

        Me.StartPosition = FormStartPosition.CenterScreen

        Dim dt As DataTable


        Dim sImpresora As String
        dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
        sImpresora = dt.Rows(0)("ImpresoraFac")
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", sImpresora)
        ImpresoraFac = dt.Rows(0)("Referencia")
        dt.Dispose()


        dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)
        TipoSucursal = dt.Rows(0)("Tipo")
        SUCClavePadre = IIf(dt.Rows(0)("SUCClavePadre").GetType.Name = "DBNull", "", dt.Rows(0)("SUCClavePadre"))
        dt.Dispose()

        With Me.cmbMotivo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Devolucion"
            .NombreParametro2 = "campo"
            .Parametro2 = "Motivo"
            .llenar()
        End With

        cmbMotivo.SelectedValue = 0

        If ActivaCaja = True Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
            StageDev = IIf(dt.Rows(0)("Stage").GetType.Name = "DBNull", "", dt.Rows(0)("Stage"))
            StageCan = IIf(dt.Rows(0)("StageCancelacion").GetType.Name = "DBNull", "", dt.Rows(0)("StageCancelacion"))
            dt.Dispose()
        End If


        Dim dtParam, dtmsg As DataTable

        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "LineasNC"
                        MaxRow = CInt(dtParam.Rows(i)("Valor"))
                    Case "TipoCF"
                        oCFD.TipoCF = CInt(dtParam.Rows(i)("Valor"))
                    Case "VersionCF"
                        dtmsg = Recupera_Tabla("sp_recupera_valorref", "@Tabla", "CFD", "@Campo", "Version", "@estado", CInt(dtParam.Rows(i)("Valor")))
                        oCFD.VersionCF = dtmsg.Rows(0)("Descripcion")
                        dtmsg.Dispose()
                    Case "RegimenFiscal"
                        iRegimenFiscal = CInt(dtParam.Rows(i)("Valor"))
                    Case "DirXML"
                        PathXML = dtParam.Rows(i)("Valor")
                    Case "MailAdress"
                        MailAdress = dtParam.Rows(i)("Valor")
                    Case "DisplayName"
                        DisplayName = dtParam.Rows(i)("Valor")
                    Case "MailUser"
                        MailUser = dtParam.Rows(i)("Valor")
                    Case "MailPassword"
                        MailPassword = dtParam.Rows(i)("Valor")
                    Case "HostSMTP"
                        HostSMTP = dtParam.Rows(i)("Valor")
                    Case "MailPort"
                        MailPort = IIf(IsNumeric(dtParam.Rows(i)("Valor")) = True, CInt(dtParam.Rows(i)("Valor")), 0)
                    Case "MailSSL"
                        MailSSL = IIf(dtParam.Rows(i)("Valor") = 1, True, False)
                    Case "InterfazSalida"
                        InterfazSalida = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                    Case "Moneda"
                        Moneda = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                    Case "TallaColor"
                        TallaColor = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))
                    Case "DevConcentra"
                        DevConcentra = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))
                    Case "BusqDev"
                        DiasMaxDev = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))
                    Case "CONCENTRADOR"
                        IPConcentrador = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "0.0.0.0", dtParam.Rows(i)("Valor"))
                    Case "FormatNC"
                        FormatNC = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
                    Case "MascaraCte"
                        MaskCte = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))


                End Select
            Next
        End With
        dtParam.Dispose()

        dtmsg = Recupera_Tabla("sp_recupera_valor", "@Tabla", "CFD", "@Campo", "RegimenFiscal", "@Valor", iRegimenFiscal)
        If oCFD.VersionCF = "3.3" Then
            oCFD.regimenFiscal = dtmsg.Rows(0)("ClaveSAT")
        Else
            oCFD.regimenFiscal = dtmsg.Rows(0)("Descripcion")
        End If
        dtmsg.Dispose()

        If oCFD.VersionCF = "3.3" Then
            oCFD.tipoDeComprobante = "E"
            oCFD.CondicionesDePago = "Contado"
        Else
            oCFD.tipoDeComprobante = "egreso"
        End If

        If TallaColor = 1 Then

            BtnConsultar.Visible = True

            If oCFD.TipoCF = 2 Then
                dtPAC = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)

                If dtPAC Is Nothing OrElse dtPAC.Rows.Count <= 0 Then
                    MessageBox.Show("No se encontraron timbres disponibles, verifique la configuración de timbres en la Compañia actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If
            End If



            dt = ModPOS.Recupera_Tabla("sp_recupera_certificadovigente", "@COMClave", ModPOS.CompanyActual)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                oCFD.noCertificado = dt.Rows(0)("Serie")
                oCFD.Certificado64 = dt.Rows(0)("Certificado")
                oCFD.LlaveFile = dt.Rows(0)("Llave")
                oCFD.ContrasenaClave = dt.Rows(0)("Password")
                dt.Dispose()
            Else
                MessageBox.Show("No existen certificado vigente disponible para emitir algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

            'Verifica que exista el path
            Try
                If Not System.IO.Directory.Exists(PathXML) Then
                    MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If
            Catch ex As Exception
            End Try

            'Verifica que exista el path del .Key
            Try
                If Not System.IO.File.Exists(oCFD.LlaveFile) Then
                    MessageBox.Show("El archivo " & oCFD.LlaveFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If
            Catch ex As Exception
            End Try


            dt = ModPOS.Recupera_Tabla("sp_recupera_folioactual", "@TipoComprobante", 7, "@SUCClave", SUCClave, "@CAJClave", CAJClave)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("No existen folios fiscales disponibles para el tipo de Nota de Crédito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If

        End If

        dtBloqueados = ModPOS.CrearTabla("Bloqueados", _
                                             "PROClave", "System.String", _
                                             "Bloquear", "System.Double")


        dtReembolsos = ModPOS.CrearTabla("Reembolsos", _
                                                "DEVClave", "System.String", _
                                                "MONClave", "System.String", _
                                                "TipoCambio", "System.Double", _
                                                "Importe", "System.Double")

        BtnDel.Enabled = False
        txtCliente.Enabled = False
        txtProducto.Enabled = False
        btnCliente.Enabled = False
        btnProducto.Enabled = False
        txtNombre.Text = ""
        txtRazonSocial.Text = ""
        TxtCantidad.Enabled = False
        TxtCantidad.Text = "1"

        CTEClave = ""
        PROClave = ""

        If Padre = "Menu" Then
            dt = ModPOS.Recupera_Tabla("sp_busca_corteCaja", "@CAJClave", CAJClave)

            Dim sFechaApertura As String = ""
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    IDCorte = dt.Rows(0)("ID")
                    sFechaApertura = dt.Rows(0)("FechaApertura").ToString
                Else
                    IDCorte = ""
                End If
                dt.Dispose()
            End If


            If IDCorte <> "" Then

                If MessageBox.Show("La caja se encuentra abierta desde el " & sFechaApertura & ", ¿Desea continuar(Sí) o Realizar Corte de Caja (No)?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.No Then
                    'Cierre de caja
                    ModPOS.Ejecuta("sp_cierra_corteCaja", "@ID", IDCorte, "@CAJClave", CAJClave, "@Saldo", 0, "@Usuario", ModPOS.UsuarioActual)

                    imprimeTicketCierreDev(IDCorte, Impresora, TicketDev, SUCClave, PrintGeneric)


                    IDCorte = ModPOS.obtenerLlave
                    ModPOS.Ejecuta("sp_crea_corteCaja", "@ID", IDCorte, "@CAJClave", CAJClave, "@Saldo", 0, "@Usuario", ModPOS.UsuarioActual, "@TipoCambio", 1)

                End If


            Else

                IDCorte = ModPOS.obtenerLlave
                ModPOS.Ejecuta("sp_crea_corteCaja", "@ID", IDCorte, "@CAJClave", CAJClave, "@Saldo", 0, "@Usuario", ModPOS.UsuarioActual, "@TipoCambio", 1)

            End If


        End If


        bLoad = True

        If Not Ventas Is Nothing AndAlso Ventas.GetLength(0) = 1 Then
            TxtFolio.Text = Ventas(0)("Folio")
            Me.AgregarFolio(False, Ventas(0)("Folio"))

        End If


    End Sub


    Private Sub AgregarFolio(ByVal bCliente As Boolean, Optional ByVal Folio As String = "")
        If bLoad = True Then
            If Not dtDetalle Is Nothing Then
                dtDetalle.Dispose()
            End If

            If Not dtVenta Is Nothing Then
                dtVenta.Dispose()
            End If

            dtVenta = ModPOS.CrearTabla("Venta", _
                                              "uuid", "System.String", _
                                              "VENClave", "System.String", _
                                              "Folio", "System.String", _
                                              "Cliente", "System.String", _
                                              "MONClave", "System.String", _
                                              "TipoCambio", "System.Decimal", _
                                              "Saldo", "System.Decimal", _
                                              "Historico", "System.Boolean")

            If bCliente = True Then
                dtDetalle = ModPOS.CrearTabla("Detalle", _
                                               "uuid", "System.String", _
                                               "Saldo", "System.Decimal", _
                                               "VENClave", "System.String", _
                                               "DVEClave", "System.String", _
                                               "PREClave", "System.String", _
                                               "Fecha", "System.DateTime", _
                                               "Folio", "System.String", _
                                               "Venta", "System.Double", _
                                               "Disp", "System.Double", _
                                               "Devolver", "System.Double", _
                                               "Motivo", "System.Int32", _
                                               "Defecto", "System.Boolean", _
                                               "PROClave", "System.String", _
                                               "TProducto", "System.Int32", _
                                               "Seguimiento", "System.Int32", _
                                               "DiasGarantia", "System.Int32", _
                                               "Clave", "System.String", _
                                               "Nombre", "System.String", _
                                               "Precio", "System.Decimal", _
                                               "Importe", "System.Decimal", _
                                               "Costo", "System.Decimal", _
                                               "PrecioBruto", "System.Decimal", _
                                               "PorcImp", "System.Double", _
                                               "PorcDesc", "System.Double", _
                                               "PuntosImp", "System.Double", _
                                               "Cliente", "System.String", _
                                               "MONClave", "System.String", _
                                               "TipoCambio", "System.Decimal", _
                                               "PRVClave", "System.String", _
                                               "Sector", "System.Int32", _
                                               "SectorActual", "System.Int32", _
                                               "IdKIT", "System.String", _
                                               "PROClaveKIT", "System.String", _
                                               "KIT", "System.String", _
                                               "PiezasKIT", "System.Double", _
                                               "Historico", "System.Boolean", _
                                               "Proveedor", "System.String"
                                               )

            Else
                Dim dt As DataTable
                dtDetalle = ModPOS.Recupera_Tabla("sp_detalle_dev", "@Folio", Folio, "@SUCClave", SUCClave)

                If dtDetalle.Rows.Count > 0 Then

                    ListaPrecio = dtDetalle.Rows(0)("PREClave")
                    CTEClave = dtDetalle.Rows(0)("Cliente")

                    dt = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", dtDetalle.Rows(0)("VENClave"))

                    If TallaColor = 1 AndAlso CDec(dt.Rows(0)("Saldo")) > 0 AndAlso CInt(dt.Rows(0)("Tipo")) = 1 Then
                        MessageBox.Show("No es posible devolver debido a que el Pedido: " & TxtFolio.Text & " tiene Saldo pendiente de cobro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    If CDate(dt.Rows(0)("Fecha")) < Today.Date.AddDays(-30) Then

                        If MessageBox.Show("El Producto que desea devolver cuenta con más de 30 dias de haberlo comprado, requiere autorización para continuar", "Información", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = System.Windows.Forms.DialogResult.OK Then

                            Dim a As New MeAutorizacion
                            a.Sucursal = SUCClave
                            a.MontodeAutorizacion = (dt.Rows(0)("Total") * dt.Rows(0)("TipoCambio"))
                            a.StartPosition = FormStartPosition.CenterScreen
                            a.ShowDialog()
                            If a.DialogResult = DialogResult.OK Then
                                If Not a.Autorizado Then
                                    a.Dispose()

                                    If Not dtDetalle Is Nothing Then
                                        dtDetalle.Clear()
                                    End If

                                    If Not dtVenta Is Nothing Then
                                        dtVenta.Clear()
                                    End If

                                End If
                                Autoriza = a.Autoriza
                            ElseIf a.DialogResult = DialogResult.Cancel Then
                                a.Dispose()
                                If Not dtDetalle Is Nothing Then
                                    dtDetalle.Clear()
                                End If

                                If Not dtVenta Is Nothing Then
                                    dtVenta.Clear()
                                End If


                            End If
                            a.Dispose()
                        Else

                            If Not dtDetalle Is Nothing Then
                                dtDetalle.Clear()
                            End If

                            If Not dtVenta Is Nothing Then
                                dtVenta.Clear()
                            End If
                        End If



                    End If

                    If dtDetalle.Rows.Count > 0 Then
                        Dim row1 As DataRow
                        row1 = dtVenta.NewRow()
                        row1.Item("uuid") = dtDetalle.Rows(0)("uuid")
                        row1.Item("VENClave") = dtDetalle.Rows(0)("VENClave")
                        row1.Item("Folio") = dtDetalle.Rows(0)("Folio")
                        row1.Item("Cliente") = dtDetalle.Rows(0)("Cliente")
                        row1.Item("MONClave") = dtDetalle.Rows(0)("MONClave")
                        row1.Item("TipoCambio") = dtDetalle.Rows(0)("TipoCambio")
                        row1.Item("Saldo") = dtDetalle.Rows(0)("Saldo")
                        row1.Item("Historico") = dtDetalle.Rows(0)("Historico")
                        dtVenta.Rows.Add(row1)

                    End If
                Else
                    If Folio <> "" Then
                        MessageBox.Show("No se encontro producto disponible para devolver en el documento: " & TxtFolio.Text & " o se encuentra Apartado/Facturado/Cancelado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

            End If


            GridDetalle.DataSource = dtDetalle
            GridDetalle.RetrieveStructure()
            GridDetalle.AutoSizeColumns()
            GridDetalle.RootTable.Columns("uuid").Visible = False
            GridDetalle.RootTable.Columns("Saldo").Visible = False
            GridDetalle.RootTable.Columns("VENClave").Visible = False
            GridDetalle.RootTable.Columns("DVEClave").Visible = False
            GridDetalle.RootTable.Columns("PROClave").Visible = False
            GridDetalle.RootTable.Columns("TProducto").Visible = False
            GridDetalle.RootTable.Columns("Seguimiento").Visible = False
            GridDetalle.RootTable.Columns("DiasGarantia").Visible = False
            GridDetalle.RootTable.Columns("Costo").Visible = False
            GridDetalle.RootTable.Columns("PrecioBruto").Visible = False
            GridDetalle.RootTable.Columns("PorcImp").Visible = False
            GridDetalle.RootTable.Columns("PorcDesc").Visible = False
            GridDetalle.RootTable.Columns("PuntosImp").Visible = False
            GridDetalle.RootTable.Columns("Cliente").Visible = False
            GridDetalle.RootTable.Columns("MONClave").Visible = False
            GridDetalle.RootTable.Columns("TipoCambio").Visible = False
            GridDetalle.RootTable.Columns("PRVClave").Visible = False
            ' GridDetalle.RootTable.Columns("Defecto").Visible = False

            GridDetalle.RootTable.Columns("Precio").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridDetalle.RootTable.Columns("Importe").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

            GridDetalle.RootTable.Columns("Folio").Width = 40
            GridDetalle.RootTable.Columns("Fecha").Width = 30
            GridDetalle.RootTable.Columns("Devolver").Width = 20
            GridDetalle.RootTable.Columns("Motivo").Width = 40
            GridDetalle.RootTable.Columns("Venta").Width = 20
            GridDetalle.RootTable.Columns("Disp").Width = 20

            GridDetalle.RootTable.Columns("Sector").Visible = False
            GridDetalle.RootTable.Columns("SectorActual").Visible = False
            GridDetalle.RootTable.Columns("IdKIT").Visible = False
            GridDetalle.RootTable.Columns("PROClaveKIT").Visible = False
            GridDetalle.RootTable.Columns("PiezasKIT").Visible = False
            GridDetalle.RootTable.Columns("Historico").Visible = False

            GridDetalle.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True
            GridDetalle.RootTable.Columns("Importe").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
            GridDetalle.RootTable.Columns("Importe").TotalFormatString = "c"


            GridDetalle.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True
            GridDetalle.RootTable.Columns("Devolver").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
            '  GridDetalle.RootTable.Columns("Devolver").TotalFormatString = "c"



            GridDetalle.CurrentTable.Columns("Motivo").HasValueList = True
            Dim AircraftTypeValueListItemCollection As Janus.Windows.GridEX.GridEXValueListItemCollection
            AircraftTypeValueListItemCollection = GridDetalle.Tables(0).Columns("Motivo").ValueList
            With AircraftTypeValueListItemCollection

                Dim i As Integer

                dtMotivo = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Devolucion", "@Campo", "Motivo")

                For i = 0 To dtMotivo.Rows.Count - 1
                    .Add(dtMotivo.Rows(i)("valor"), dtMotivo.Rows(i)("descripcion"))
                Next

            End With
            GridDetalle.CurrentTable.Columns("Motivo").EditType = Janus.Windows.GridEX.EditType.Combo



        End If
    End Sub

    'Private Function imprimeRecibo(ByVal Abono As String, ByVal Importe As Double, ByVal Cambio As Double, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String, ByVal Usu As String, ByVal Cte As String) As Boolean
    '    Dim dTotalPagos, dPagos As Double

    '    Dim Tickets As Imprimir = New Imprimir
    '    Tickets.Generic = Generic
    '    Dim dtTicket As DataTable
    '    dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

    '    If Not dtTicket Is Nothing Then
    '        Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
    '        Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
    '        Tickets.LetraName = dtTicket.Rows(0)("FontName")
    '        If dtTicket.Rows(0)("url_imagen") <> "" Then
    '            Tickets.ImgHeader = ModPOS.RecuperaImagen(dtTicket.Rows(0)("url_imagen"))
    '        End If
    '        dtTicket.Dispose()
    '    End If


    '    Dim dtHeadTicket As DataTable
    '    dtHeadTicket = ModPOS.SiExisteRecupera("sp_filtra_encabezado", "@TIKClave", Ticket)

    '    If Not dtHeadTicket Is Nothing Then
    '        Dim i As Integer
    '        For i = 0 To dtHeadTicket.Rows.Count - 1
    '            Tickets.AddHeaderLine(CStr(dtHeadTicket.Rows(i)("Texto")), Math.Abs(CInt(dtHeadTicket.Rows(i)("Negrita"))), CInt(dtHeadTicket.Rows(i)("Alinear")))
    '        Next
    '        dtHeadTicket.Dispose()
    '    End If


    '    'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
    '    'de que al final de cada linea agrega una linea punteada "==========" 
    '    Tickets.AddSubHeaderLine("RECIBO", 1, 3)
    '    Tickets.AddSubHeaderLine("CTE: " & Cte, 0, 3)
    '    Tickets.AddSubHeaderLine("LE ATENDIO: " & Usu, 0, 1)
    '    Tickets.AddSubHeaderLine(DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToShortTimeString(), 0, 1)

    '    Dim dtRef As DataTable = ModPOS.Recupera_Tabla("sp_recibo_enc", "@ABNClave", Abono)

    '    Tickets.AddSubHeaderBloqLine("REFERENCIA: " & dtRef.Rows(0)("Referencia"), 0, 1)
    '    Tickets.AddSubHeaderBloqLine("FORMA PAGO: " & dtRef.Rows(0)("Descripcion"), 0, 1)
    '    Tickets.AddSubHeaderBloqLine("IMPORTE: " & Format(CStr(ModPOS.Redondear(Importe, 2)), "Currency"), 0, 1)

    '    dtRef.Dispose()

    '    'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
    '    'del producto y el tercero es el precio 
    '    Dim dtPagosDetalle As DataTable
    '    dtPagosDetalle = ModPOS.SiExisteRecupera("sp_recibo_detalle", "@ABNClave", Abono)

    '    If Not dtPagosDetalle Is Nothing Then
    '        Dim i As Integer = 0
    '        dPagos = dtPagosDetalle.Rows.Count()
    '        For i = 0 To dPagos - 1
    '            Dim sFolio As String = dtPagosDetalle.Rows(i)("Folio")
    '            Dim sTipo As String = dtPagosDetalle.Rows(i)("Tipo")
    '            Dim dImporte As Double = dtPagosDetalle.Rows(i)("Importe")


    '            ' AGREGAR PAGOS A LISTA
    '            Tickets.AddItemRecibo(sFolio, sTipo, dImporte)

    '            dTotalPagos += (dImporte)
    '        Next
    '        dtPagosDetalle.Dispose()
    '    End If

    '    'El metodo AddTotalRecibo requiere 4 parametros 
    '    '  Tickets.AddTotalRecibo(dTotalPagos, 0, 0, 1)
    '    Tickets.AddFooterLine("TOTAL APLICADO: " & Format(CStr(ModPOS.Redondear(dTotalPagos, 2)), "Currency"), 1, 2)
    '    Tickets.AddFooterLine("CAMBIO: " & Format(CStr(ModPOS.Redondear(Cambio, 2)), "Currency"), 0, 2)

    '    'El metodo AddFooterLine funciona igual que la cabecera 

    '    Dim dtPieTicket As DataTable
    '    dtPieTicket = ModPOS.SiExisteRecupera("sp_filtra_pie", "@TIKClave", Ticket)

    '    If Not dtPieTicket Is Nothing Then
    '        Dim i As Integer
    '        For i = 0 To dtPieTicket.Rows.Count - 1
    '            Tickets.AddFooterLine(CStr(dtPieTicket.Rows(i)("Texto")), Math.Abs(CInt(dtPieTicket.Rows(i)("Negrita"))), CInt(dtPieTicket.Rows(i)("Alinear")))
    '        Next
    '        dtPieTicket.Dispose()
    '    End If

    '    'Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
    '    'parametro de tipo string que debe de ser el nombre de la impresora. 
    '    Tickets.PrintTicket(Impresora, 70, 0)

    'End Function

    Private Sub TxtFolio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFolio.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TxtFolio.Text = TxtFolio.Text.Trim.ToUpper.Replace("'", "-")

            If Split(TxtFolio.Text, "-").Length = 3 Then
                TxtFolio.Text = Split(TxtFolio.Text, "-")(1) & "-" & Split(TxtFolio.Text, "-")(2)
            End If
            AgregarFolio(False, TxtFolio.Text)
        End If
    End Sub

    Private Sub FrmDevolucion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If bError Then
            e.Cancel = True
        Else
            If bLiquidacion = True AndAlso Not ModPOS.Liquid Is Nothing Then
                ModPOS.Liquid.ActualizaGridTransac()
            End If

            If bLiquidacion = True AndAlso Not ModPOS.MtoVenta Is Nothing Then
                ModPOS.MtoVenta.ActualizaGridTransac()
            End If

            If Padre = "Menu" Then

                If IDCorte <> "" Then

                    If MessageBox.Show(" ¿Desea continuar con la Caja Abierta (Sí) o Realizar Corte de Caja (No)?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.No Then
                        'Cierre de caja
                        ModPOS.Ejecuta("sp_cierra_corteCaja", "@ID", IDCorte, "@CAJClave", CAJClave, "@Saldo", 0, "@Usuario", ModPOS.UsuarioActual)

                        imprimeTicketCierreDev(IDCorte, Impresora, TicketDev, SUCClave, PrintGeneric)
                    
                    End If
                End If


                ModPOS.Ejecuta("sp_act_caja", "@CAJClave", CAJClave, "@Fase", 0)
            End If

            ModPOS.Devolucion.Dispose()
            ModPOS.Devolucion = Nothing

            End If

    End Sub

    Private Sub Combo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not dtDetalle Is Nothing Then
            dtDetalle.Dispose()
        End If
    End Sub

    Private Sub GridDetalle_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited

        If GridDetalle.CurrentColumn.Caption = "Devolver" Then
            If IsNumeric(GridDetalle.GetValue("Devolver")) Then
                If GridDetalle.GetValue("Disp") >= GridDetalle.GetValue("Devolver") Then
                    Dim Actual As Double
                    Actual = Math.Abs(CDbl(GridDetalle.GetValue("Devolver"))) * GridDetalle.GetValue("Precio")
                    GridDetalle.SetValue("Importe", Actual)
                    dtDetalle.AcceptChanges()

                    GridDetalle.Refresh()

                Else
                    Beep()
                    MessageBox.Show("¡La cantidad a devolver no puede ser mayor al disponible!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    GridDetalle.SetValue("Devolver", 0)
                    GridDetalle.SetValue("Importe", 0)
                    dtDetalle.AcceptChanges()

                    GridDetalle.Refresh()
                End If
            Else
                GridDetalle.SetValue("Devolver", 0)
                dtDetalle.AcceptChanges()
                GridDetalle.SetValue("Importe", 0)
                GridDetalle.Refresh()
            End If

        ElseIf GridDetalle.CurrentColumn.Caption = "Motivo" Then
            If IsNumeric(GridDetalle.GetValue("Motivo")) = True Then
                Dim dtValor As DataTable
                dtValor = Recupera_Tabla("sp_obtener_valorref", "@Tabla", "Devolucion", "@Campo", "Motivo", "@Valor", GridDetalle.GetValue("Motivo"))
                If dtValor.Rows.Count > 0 Then

                    If dtValor.Rows(0)("Grupo").GetType.Name = "DBNull" Then
                        GridDetalle.SetValue("Defecto", False)
                    Else
                        GridDetalle.SetValue("Defecto", IIf(CInt(dtValor.Rows(0)("Grupo")) = 0, False, True))
                    End If
                Else
                    GridDetalle.SetValue("Defecto", False)
                End If
                dtValor.Dispose()

                If GridDetalle.GetValue("Defecto") = True AndAlso GridDetalle.GetValue("PRVClave") = "NA" Then

                    Dim dtPrv As DataTable
                    Dim PRVClave, Proveedor As String
                    dtPrv = ModPOS.Recupera_Tabla("st_recupera_prvprod", "@PROClave", GridDetalle.GetValue("PROClave"))

                    If dtPrv.Rows.Count = 0 Then
                        PRVClave = "NA"
                        Proveedor = ""
                    ElseIf dtPrv.Rows.Count = 1 Then
                        PRVClave = dtPrv.Rows(0)("PRVClave")
                        Proveedor = dtPrv.Rows(0)("Clave")
                    Else
                        Do
                            Dim a As New FrmBoxConsulta
                            a.ObjetoCaptura = "Proveedor"
                            a.Text = "Selección de Proveedor"
                            a.Campo = "PRVClave"
                            a.Campo2 = "Clave"
                            a.dtConsulta = dtPrv
                            '  ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_recupera_prvprod", "@PROClave", PROClave)
                            'a.GridConsultaGen.RootTable.Columns("PRVClave").Visible = False
                            a.ShowDialog()
                            If a.DialogResult = DialogResult.OK Then
                                If a.ID <> "" Then
                                    PRVClave = a.ID
                                    Proveedor = a.ID2
                                End If
                            End If
                            a.Dispose()
                        Loop While PRVClave = ""
                    End If
                    GridDetalle.SetValue("PRVClave", PRVClave)
                    GridDetalle.SetValue("Proveedor", Proveedor)
                Else
                    GridDetalle.SetValue("PRVClave", "NA")
                    GridDetalle.SetValue("Proveedor", "")
                End If
            End If

        End If
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        bError = False
        Me.Close()
    End Sub

    Private Sub GridDetalle_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridDetalle.CurrentCellChanged
        If Not GridDetalle.CurrentColumn Is Nothing Then
            If GridDetalle.CurrentColumn.Caption = "Devolver" OrElse GridDetalle.CurrentColumn.Caption = "Motivo" Then
                GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub crearCF()
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", CTEClave)

        oCFD.CURP = dt.Rows(0)("CURP")
        oCFD.Clave = dt.Rows(0)("Clave")
        oCFD.TImpuesto = dt.Rows(0)("TipoImpuesto")
        oCFD.NombreCorto = dt.Rows(0)("NombreCorto")
        oCFD.RazonSocial = dt.Rows(0)("RazonSocial")
        oCFD.TPersona = dt.Rows(0)("TPersona")
        oCFD.RFC = dt.Rows(0)("id_Fiscal")
        oCFD.LCredito = dt.Rows(0)("LimiteCredito")
        oCFD.DiasCredito = dt.Rows(0)("DiasCredito")
        oCFD.Contacto = dt.Rows(0)("Contacto")
        oCFD.Tel1 = dt.Rows(0)("Tel1")
        oCFD.Tel2 = dt.Rows(0)("Tel2")
        oCFD.email = dt.Rows(0)("Email")
        oCFD.listaPrecio = dt.Rows(0)("PREClave")
        oCFD.NoDesglosaIEPS = dt.Rows(0)("DesglosaIVA")
        oCFD.ImprimirFac = IIf(dt.Rows(0)("ImprimirFac").GetType.Name = "DBNull", True, dt.Rows(0)("ImprimirFac"))

        oCFD.FechaReg = dt.Rows(0)("FechaRegistro")
        oCFD.Estado = dt.Rows(0)("Estado")
        oCFD.DCTEClave = dt.Rows(0)("DCTEClave")

        oCFD.Pais = dt.Rows(0)("Pais")
        oCFD.Entidad = dt.Rows(0)("Entidad")
        oCFD.Mnpio = dt.Rows(0)("Municipio")
        oCFD.Colonia = dt.Rows(0)("Colonia")
        oCFD.Calle = dt.Rows(0)("Calle")
        oCFD.Localidad = dt.Rows(0)("Localidad")
        oCFD.Referencia = dt.Rows(0)("referencia")
        oCFD.noExterior = dt.Rows(0)("noExterior")
        oCFD.noInterior = dt.Rows(0)("noInterior")
        oCFD.codigoPostal = dt.Rows(0)("codigoPostal")


        dt.Dispose()


        'Recupera información del Emisor

        dt = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)

        oCFD.eRazonSocial = dt.Rows(0)("Nombre")
        oCFD.eTPersona = IIf(dt.Rows(0)("TPersona").GetType.Name = "DBNull", 2, dt.Rows(0)("TPersona"))
        oCFD.eRFC = dt.Rows(0)("id_Fiscal")
        oCFD.ePais = dt.Rows(0)("Pais")
        oCFD.eEntidad = dt.Rows(0)("Estado")
        oCFD.eMnpio = dt.Rows(0)("Municipio")
        oCFD.eColonia = dt.Rows(0)("Colonia")
        oCFD.eCalle = dt.Rows(0)("Calle")
        oCFD.eCodigoPostal = dt.Rows(0)("CodigoPostal")
        oCFD.eReferencia = dt.Rows(0)("Referencia")
        oCFD.eLocalidad = dt.Rows(0)("Localidad")
        oCFD.enoExterior = dt.Rows(0)("noExterior")
        oCFD.enoInterior = dt.Rows(0)("noInterior")
        dt.Dispose()

        If oCFD.eReferencia = "" Then
            oCFD.eReferencia = "SIN REFERENCIA"
        End If

        If oCFD.enoInterior <> "" Then
            oCFD.benoInterior = True
        Else
            oCFD.benoInterior = False
        End If


        'Recupera Información del Centro de Expedición

        dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)

        oCFD.iTipoSucursal = dt.Rows(0)("Tipo")
        oCFD.sPais = dt.Rows(0)("Pais")
        oCFD.sEntidad = dt.Rows(0)("Entidad")
        oCFD.sMnpio = dt.Rows(0)("Municipio")
        oCFD.sColonia = dt.Rows(0)("Colonia")
        oCFD.sCalle = dt.Rows(0)("Calle")
        oCFD.sCodigoPostal = dt.Rows(0)("CodigoPostal")
        oCFD.sReferencia = dt.Rows(0)("Referencia")
        oCFD.sLocalidad = dt.Rows(0)("Localidad")
        oCFD.snoExterior = dt.Rows(0)("noExterior")
        oCFD.snoInterior = dt.Rows(0)("noInterior")
        dt.Dispose()

        If oCFD.sReferencia = "" Then
            oCFD.sReferencia = "SIN REFERENCIA"
        End If

        If oCFD.snoInterior <> "" Then
            oCFD.bsnoInterior = True
        Else
            oCFD.bsnoInterior = False
        End If

        oCFD.LugarExpedicion = oCFD.sCalle & " " & oCFD.snoExterior & IIf(oCFD.bsnoInterior, " INT " & oCFD.snoInterior, "") & "," & oCFD.sMnpio & "," & oCFD.sEntidad


        'Receptor

        If oCFD.Referencia = "" Then
            oCFD.Referencia = "SIN REFERENCIA"
        End If

        If oCFD.noInterior <> "" Then
            oCFD.brnoInterior = True
        Else
            oCFD.brnoInterior = False
        End If

        dt = ModPOS.Recupera_Tabla("sp_recupera_nc", "@NCClave", NCClave)

        Dim dtConcepto As DataTable = ModPOS.Recupera_Tabla("sp_recupera_conceptonc", "@Clave", NCClave)
        Dim dtImpuesto As DataTable = ModPOS.Recupera_Tabla("sp_recupera_impuestosnc", "@Clave", NCClave)
        Dim dtDetalleImpuesto, dtRetencion, dtRetencionDet As DataTable

        'NOTA: Las retenciones no estan implementadas en este modulo
        oCFD.UsoCFDI = "G02"
        oCFD.Serie = dt.Rows(0)("Serie")
        oCFD.Folio = dt.Rows(0)("Folio")
        oCFD.total = dt.Rows(0)("total")
        oCFD.formaDePago = dt.Rows(0)("formaDePago")
        Dim sFolio As String = oCFD.Serie & oCFD.Folio

        oCFD.descuento = IIf(dt.Rows(0)("DescuentoTot").GetType.ToString = "System.DBNull", 0, dt.Rows(0)("DescuentoTot"))

        oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", DateTime.Now)


        'oCFD.extra = TxtExtra.Text
        oCFD.Moneda = MonedaRef
        oCFD.TipoCambio = 1

        If oCFD.TipoCF <= 2 Then

            oCFD.DOCClave = NCClave

            If oCFD.VersionCF = "3.3" Then
                dtDetalleImpuesto = ModPOS.Recupera_Tabla("st_recupera_impuesto_det", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", 8, "@Clave", oCFD.DOCClave)
            End If

            oCFD.cadenaOriginal = generarCadenaOriginalCFDI(oCFD, dtConcepto, dtImpuesto, 8, dtDetalleImpuesto, dtRetencionDet, dtRetencion)

            oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)

            Dim iTipoPAC As Integer = 0

            iTipoPAC = crearXML(1, dtPAC, PathXML, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, 8, InterfazSalida, dtDetalleImpuesto, dtRetencionDet, dtRetencion)


            If iTipoPAC = 0 Then
                MessageBox.Show("No ha sido posible certificar este documento, le recomendamos intentar certificarlo más tarde", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'Select Case MessageBox.Show("¿Desea imprimir la nota de crédito?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                '    Case DialogResult.Yes
                '        'Imprime NCBonificación

                '        imprimirNC(oCFD.TipoCF, FormatNC, NCClave, oCFD.total, SUCClave, oCFD.TipoCambio, MonedaDesc, MonedaRef, ImpresoraFac, 1, oCFD.VersionCF, 1, "V")

                'End Select

                If oCFD.email.Trim <> "" Then
                    Select Case MessageBox.Show("¿Desea enviar el documento por correo electrónico?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.Yes
                            ModPOS.SendMailNC(oCFD.VersionCF, oCFD.email, oCFD.TipoCF, FormatNC, CDate(oCFD.Fecha), sFolio, NCClave, oCFD.total, MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, oCFD.TipoCambio, MonedaDesc, MonedaRef, 1, True, "V")

                    End Select
                End If

            End If

        Else
            actualizaEdoCFD(oCFD.tipoDeComprobante, oCFD.DOCClave, 1, 8)
        End If


        dt.Dispose()
        dtConcepto.Dispose()
        dtImpuesto.Dispose()
        dtDetalleImpuesto.Dispose()
        'dtRetencion.Dispose()
        'dtRetencionDet.Dispose()


    End Sub


    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If dtDetalle.Rows.Count > 0 Then
            Dim msg As String
            bError = False

            Dim foundRows() As DataRow
            foundRows = dtDetalle.Select("Devolver > 0 and Disp >= Devolver")
            If foundRows.GetLength(0) > 0 Then
                foundRows = dtDetalle.Select("Motivo = 0 and Devolver > 0")
                If foundRows.GetLength(0) > 0 Then
                    Beep()
                    MessageBox.Show("¡El Motivo de devolución es Requerido para todos los productos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    bError = True
                    Exit Sub
                Else
                    If cmbMotivo.SelectedValue Is Nothing Then
                        foundRows = dtDetalle.Select("Devolver > 0")
                        cmbMotivo.SelectedValue = foundRows(0)("Motivo")
                    End If
                End If


                If TallaColor = 1 Then
                    foundRows = dtDetalle.Select("Defecto = 1 and Devolver > 0 and Proveedor=''")
                    If foundRows.GetLength(0) > 0 Then
                        Beep()
                        MessageBox.Show("¡No se ha especificado Proveedor para los productos con Defecto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        bError = True
                        Exit Sub
                    End If
                End If

                Dim i As Integer


                foundRows = dtDetalle.Select("Devolver > 0 and  PROClaveKIT <> '' and Defecto = 0 ")
                If foundRows.GetLength(0) > 0 Then
                    Dim dPiezasKIT, dKIT As Double

                    Dim lError As Boolean = False
                    For i = 0 To foundRows.Length - 1

                        dPiezasKIT = foundRows(i)("PiezasKIT")
                        dKIT = dtDetalle.Compute("SUM(Devolver)", "Devolver > 0 and  PROClaveKIT = '" & CStr(foundRows(i)("PROClaveKIT")) & "' and IdKIT ='" & CStr(foundRows(i)("IdKIT")) & "'")
                        If dPiezasKIT <> dKIT Then
                            lError = True
                            Exit For
                        End If
                    Next

                    If lError = True Then
                        Beep()
                        MessageBox.Show("¡Algunos productos que intenta devolver no tienen defecto y pertenecen a un DUO o SIX por lo que debe devolverse completo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        bError = True
                        Exit Sub
                    End If

                End If


                foundRows = dtDetalle.Select("Devolver > 0 ")
                If foundRows.Length > 0 Then
                    Dim dtLimitaDevolucion As DataTable = ModPOS.SiExisteRecupera("st_recupera_LimitaDevolucion", "@SUCClave", SUCClave)
                    If Not dtLimitaDevolucion Is Nothing Then
                        Dim foundLimitar() As DataRow
                        For i = 0 To foundRows.Length - 1

                            foundLimitar = dtLimitaDevolucion.Select("PROClave = '" & foundRows(i)("PROClave") & "'")
                            If foundLimitar.Length = 0 Then
                                Beep()
                                MessageBox.Show("¡No esta permitida la devolución del producto: " & foundRows(i)("PROClave") & " " & foundRows(i)("Nombre") & " en la sucursal actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                bError = True
                                Exit Sub
                            End If
                        Next
                    End If
                End If

                If rbFolio.Checked And TallaColor = 1 Then

                    foundRows = dtDetalle.Select("Devolver > 0 and  Sector = 509 ")
                    If foundRows.Length > 0 Then
                        Beep()
                        MessageBox.Show("¡Algunos productos que intenta devolver no estan disponibles ya que fueron adquiridos como Saldo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        bError = True
                        Exit Sub
                    End If


                    foundRows = dtDetalle.Select("Devolver > 0 and  Sector = 512  and SectorActual = 510 ")
                    If foundRows.Length > 0 Then
                        For i = 0 To foundRows.Length - 1
                            Dim dtPrecio As DataTable = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 3, "@Busca", foundRows(i)("PROClave"), "@SUCClave", SUCClave, "@PREClave", foundRows(i)("PREClave"), "@CTEClave", CTEClave, "@Cantidad", 1, "@Char", cReplace, "@Servicio", 0, "@TallaColor", TallaColor)
                            If Not dtPrecio Is Nothing Then
                                foundRows(i)("Precio") = dtPrecio.Rows(0)("PrecioNeto") / foundRows(i)("TipoCambio")
                                foundRows(i)("Importe") = foundRows(i)("Devolver") * (dtPrecio.Rows(0)("PrecioNeto") / foundRows(i)("TipoCambio"))
                                foundRows(i)("PrecioBruto") = dtPrecio.Rows(0)("PrecioBruto")
                                foundRows(i)("PorcDesc") = dtPrecio.Rows(0)("DescGeneral") / 100
                            End If
                        Next
                    End If
                End If



                Dim ImporteDevolver As Decimal


                If ActivaDevolucion Then

                    foundRows = dtDetalle.Select("Devolver > 0 and Disp >= Devolver")
                    For i = 0 To foundRows.Length - 1
                        ImporteDevolver += foundRows(i)("Importe") * foundRows(i)("TipoCambio")
                    Next

                    Dim a As New MeAutorizacion
                    a.Sucursal = SUCClave
                    a.sp = "st_filtra_devoluciones"
                    a.MontodeAutorizacion = 0
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If Not a.Autorizado Then
                            a.Dispose()
                            bError = True
                            Exit Sub
                        End If
                        Autoriza = a.Autoriza
                    ElseIf a.DialogResult = DialogResult.Cancel Then
                        a.Dispose()
                        bError = True
                        Exit Sub
                    End If
                    a.Dispose()


                End If


                Dim dt As DataTable
                Dim TotalDevolucion As Decimal
                Dim ImporteReembolso As Decimal = 0
                Dim j As Integer

                If ActivaCaja Then
                    Estado = 1
                Else
                    Estado = 0
                End If

                Dim CambioEstado As Boolean = False
                Dim EstadoUBC, EstadoPEU As Integer
                If StageDev <> "" Then
                    Dim dtU As DataTable = ModPOS.Recupera_Tabla("sp_recupera_ubicacion", "@UBCClave", StageDev)
                    EstadoUBC = CInt(dtU.Rows(0)("Estado"))
                    dtU.Dispose()
                End If

                Dim FolioDevolucion As String

                Dim dSubtotal, dImpuesto, dDescuento As Decimal

                Dim dAplica As Decimal = 0



                'Crea Vale
                If TallaColor = 1 Then
                    NCClave = obtenerLlave()


                    Dim FOLClave As String
                    dt = ModPOS.Recupera_Tabla("sp_recupera_folioactual", "@TipoComprobante", 7, "@SUCClave", SUCClave, "@CAJClave", CAJClave)
                    FOLClave = dt.Rows(0)("FOLClave")

                    oCFD.noAprobacion = dt.Rows(0)("NoAprobacion")
                    oCFD.anoAprobacion = CStr(dt.Rows(0)("AnoAprobacion"))
                    oCFD.Serie = dt.Rows(0)("Serie")
                    oCFD.Folio = CStr(dt.Rows(0)("FolioActual") + 1)
                    oCFD.fechaAprobacion = IIf(dt.Rows(0)("fechaAprobacion").GetType.Name = "DBNull", Today(), dt.Rows(0)("fechaAprobacion"))

                    If Not dt.Rows(0)("CBB") Is System.DBNull.Value Then
                        oCFD.CBB = CType(dt.Rows(0)("CBB"), Byte())
                    End If

                    dt.Dispose()


                    oCFD.formaDePago = "PUE"
                    oCFD.metodoDePago = "99"

                    msg = ModPOS.Ejecuta("sp_incrementa_folio", "@FOLClave", FOLClave)

                    If msg <> "OK" Then
                        MessageBox.Show(msg)
                    End If

                    msg = ModPOS.Ejecuta("st_crea_vale", _
                                    "@NCClave", NCClave, _
                                    "@CTEClave", dtDetalle.Rows(0)("Cliente"), _
                                    "@Serie", oCFD.Serie, _
                                    "@Folio", oCFD.Folio, _
                                    "@CAJClave", CAJClave, _
                                    "@Atendio", ModPOS.UsuarioActual, _
                                    "@formaDePago", oCFD.formaDePago, _
                                    "@noCertificado", oCFD.noCertificado, _
                                    "@tipoComprobante", oCFD.tipoDeComprobante, _
                                    "@TipoCF", oCFD.TipoCF, _
                                    "@VersionCF", oCFD.VersionCF, _
                                    "@RegimenFiscal", oCFD.regimenFiscal, _
                                    "@MONClave", Moneda, _
                                    "@TipoCambio", 1)

                    If msg <> "OK" Then
                        MessageBox.Show(msg)
                    End If

                End If



                For i = 0 To dtVenta.Rows.Count - 1
                    ' Por cada venta genera una Devolucion 

                    dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", IIf(dtVenta.Rows(i)("MONClave").GetType.Name = "DBNull", Moneda, dtVenta.Rows(i)("MONClave")))
                    MonedaRef = dt.Rows(0)("Referencia")
                    MonedaDesc = dt.Rows(0)("Descripcion")
                    dt.Dispose()

                    dt = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 2, "@PDVClave", CAJClave)
                    If dt Is Nothing Then
                        msg = ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 2, "@PDVClave", CAJClave)
                        Folio = 1
                        Periodo = Today.Year
                        Mes = Today.Month
                    Else
                        Folio = CInt(dt.Rows(0)("UltimoConsecutivo")) + 1
                        Periodo = dt.Rows(0)("Periodo")
                        Mes = dt.Rows(0)("Mes")
                        msg = ModPOS.Ejecuta("sp_act_folio", "@Tipo", 2, "@PDVClave", CAJClave, "@Incremento", 1)
                        dt.Dispose()
                    End If

                    If msg <> "OK" Then
                        MessageBox.Show(msg)
                    End If

                    DEVClave = ModPOS.obtenerLlave

                    FolioDevolucion = "DV" & Referencia & Microsoft.VisualBasic.Right(CStr(Periodo), 2) & Microsoft.VisualBasic.Right("0" & CStr(Mes), 2) & "-" & CStr(Folio)

                    foundRows = dtDetalle.Select("VENClave ='" & dtVenta.Rows(i)("VENClave") & "' and Devolver > 0")


                    If dtVenta.Rows(i)("uuid") <> "" Then
                        'Devolucion Facturada

                        msg = ModPOS.Ejecuta("sp_crea_devolucion", _
                                    "@DEVClave", DEVClave, _
                                    "@Tipo", 2, _
                                    "@FACClave", dtVenta.Rows(i)("uuid"), _
                                    "@VENClave", dtVenta.Rows(i)("VENClave"), _
                                    "@Referencia", dtVenta.Rows(i)("Folio"), _
                                    "@CTEClave", dtVenta.Rows(0)("Cliente"), _
                                    "@CAJClave", CAJClave, _
                                    "@Folio", FolioDevolucion, _
                                    "@Motivo", cmbMotivo.SelectedValue, _
                                    "@Usuario", ModPOS.UsuarioActual, _
                                    "@Costo", 0, _
                                    "@Subtotal", 0, _
                                    "@ImpuestoTot", 0, _
                                    "@DescuentoTot", 0, _
                                    "@Total", 0, _
                                    "@MONClave", IIf(dtVenta.Rows(i)("MONClave").GetType.Name = "DBNull", Moneda, dtVenta.Rows(i)("MONClave")), _
                                    "@TipoCambio", dtVenta.Rows(i)("TipoCambio"), _
                                    "@Estado", Estado, _
                                    "@Autorizo", Autoriza, _
                                    "@NCClave", NCClave, _
                                    "@Historico", dtVenta.Rows(i)("Historico"))




                    Else
                        'Devolucion Convencional = 1


                        msg = ModPOS.Ejecuta("sp_crea_devolucion", _
                                    "@DEVClave", DEVClave, _
                                    "@Tipo", 1, _
                                    "@VENClave", dtVenta.Rows(i)("VENClave"), _
                                    "@Referencia", dtVenta.Rows(i)("Folio"), _
                                    "@CTEClave", dtVenta.Rows(0)("Cliente"), _
                                    "@CAJClave", CAJClave, _
                                    "@Folio", FolioDevolucion, _
                                    "@Motivo", cmbMotivo.SelectedValue, _
                                    "@Usuario", ModPOS.UsuarioActual, _
                                    "@Costo", 0, _
                                    "@Subtotal", 0, _
                                    "@ImpuestoTot", 0, _
                                    "@DescuentoTot", 0, _
                                    "@Total", 0, _
                                    "@MONClave", IIf(dtVenta.Rows(i)("MONClave").GetType.Name = "DBNull", Moneda, dtVenta.Rows(i)("MONClave")), _
                                    "@TipoCambio", dtVenta.Rows(i)("TipoCambio"), _
                                    "@Estado", Estado, _
                                    "@Autorizo", Autoriza, _
                                    "@NCClave", NCClave, _
                                    "@Historico", dtVenta.Rows(i)("Historico"))

                    End If


                    If msg <> "OK" Then
                        MessageBox.Show(msg)
                    End If


                    For j = 0 To foundRows.Length - 1
                        msg = ModPOS.Ejecuta("sp_actualiza_cantdev", "@Tipo", 1, "@Documento", foundRows(j)("VENClave"), "@Partida", foundRows(j)("DVEClave"), "@Cantidad", foundRows(j)("Devolver"), "@Historico", foundRows(j)("Historico"))

                        If msg <> "OK" Then
                            MessageBox.Show(msg)
                        End If

                        dSubtotal = Math.Round(foundRows(j)("PrecioBruto") * foundRows(j)("Devolver"), 2)
                        dDescuento = Math.Round(dSubtotal * foundRows(j)("PorcDesc"), 2)
                        dImpuesto = Math.Round((dSubtotal - dDescuento) * foundRows(j)("PorcImp"), 2)

                        msg = ModPOS.Ejecuta("sp_inserta_devdet", _
                                                "@DEVClave", DEVClave, _
                                                "@Partida", (j + 1) * 10, _
                                                "@PROClave", foundRows(j)("PROClave"), _
                                                "@TProducto", foundRows(j)("TProducto"), _
                                                "@Costo", foundRows(j)("Costo"), _
                                                "@Precio", foundRows(j)("PrecioBruto"), _
                                                "@Cantidad", foundRows(j)("Devolver"), _
                                                "@Subtotal", dSubtotal, _
                                                "@Descuento", dDescuento, _
                                                "@Impuesto", dImpuesto, _
                                                "@Puntos", foundRows(j)("PuntosImp") / foundRows(j)("Devolver"), _
                                                "@Total", dSubtotal - dDescuento + dImpuesto, _
                                                "@Motivo", foundRows(j)("Motivo"), _
                                                "@Defecto", foundRows(j)("Defecto"), _
                                                "@PRVClave", foundRows(j)("PRVClave"))

                        If msg <> "OK" Then
                            MessageBox.Show(msg)
                        End If

                        'SI REQUIERE SEGUIMIENTO DE SERIAL
                        If foundRows(j)("Seguimiento") = 2 Then
                            Dim SerialReg As Integer = 0
                            Dim PorRegistrar As Double
                            PorRegistrar = foundRows(j)("Devolver")
                            Do
                                Dim b As New FrmSerial
                                b.DOCClave = foundRows(j)("VENClave")
                                b.PROClave = foundRows(j)("PROClave")
                                b.Clave = foundRows(j)("Clave")
                                b.Nombre = foundRows(j)("Nombre")
                                b.Cantidad = PorRegistrar
                                b.Dias = foundRows(j)("DiasGarantia")
                                b.TipoDoc = 3
                                b.TipoMov = 1
                                b.ShowDialog()
                                SerialReg = SerialReg + b.NumSerialRegistrados
                                PorRegistrar = PorRegistrar - b.NumSerialRegistrados
                                b.Dispose()
                            Loop Until SerialReg = foundRows(j)("Devolver") OrElse PorRegistrar = 0
                        End If

                        'SI REQUIERE SEGUIMIENTO DE LOTE
                        If foundRows(j)("Seguimiento") = 3 Then
                            Dim LoteReg As Integer = 0
                            Dim PorRegistrar As Double
                            PorRegistrar = foundRows(j)("Devolver")
                            Do
                                Dim b As New FrmLote
                                b.DOCClave = foundRows(j)("VENClave")
                                b.PROClave = foundRows(j)("PROClave")
                                b.Clave = foundRows(j)("Clave")
                                b.Nombre = foundRows(j)("Nombre")
                                b.CantXRegistrar = PorRegistrar
                                b.TipoDoc = 3
                                b.TipoMov = 1
                                b.ShowDialog()
                                LoteReg = LoteReg + b.NumSerialRegistrados
                                PorRegistrar = PorRegistrar - b.NumSerialRegistrados
                                b.Dispose()
                            Loop Until LoteReg = foundRows(j)("Devolver") OrElse PorRegistrar = 0
                        End If


                        If StageDev <> "" Then
                            dt = Recupera_Tabla("st_recupera_peu", "@PROClave", foundRows(j)("PROClave"), "@UBCClave", StageDev)
                            If dt.Rows.Count = 1 Then
                                EstadoPEU = CInt(dt.Rows(0)("Estado"))
                                If CDbl(dt.Rows(0)("Existencia")) <= 0 Then
                                    EstadoPEU = EstadoUBC
                                End If
                            Else
                                EstadoPEU = EstadoUBC
                            End If
                            dt.Dispose()

                            If 1 <> EstadoPEU Then


                                Dim row1 As DataRow
                                row1 = dtBloqueados.NewRow()
                                'declara el nombre de la fila
                                row1.Item("PROClave") = foundRows(i)("PROClave")
                                row1.Item("Bloquear") = foundRows(i)("Devolver")
                                dtBloqueados.Rows.Add(row1)

                                CambioEstado = True
                            End If

                        End If

                    Next

                    msg = ModPOS.Ejecuta("sp_actualiza_devolucion", "@DEVClave", DEVClave)

                    If msg <> "OK" Then
                        MessageBox.Show(msg)
                    End If

                    dt = ModPOS.Recupera_Tabla("sp_encabezado_dev", "@DEVClave", DEVClave)
                    TotalDevolucion = dt.Rows(0)("Total")
                    dt.Dispose()

                    If TallaColor = 0 Then
                        If dtVenta.Rows(i)("uuid") <> "" Then
                            If dtVenta.Rows(i)("Saldo") > 0 Then
                                If dtVenta.Rows(i)("Saldo") >= TotalDevolucion Then
                                    dAplica = TotalDevolucion
                                Else
                                    dAplica = dtVenta.Rows(i)("Saldo")
                                    ImporteReembolso += ((TotalDevolucion - dtVenta.Rows(i)("Saldo")) * dtVenta.Rows(i)("TipoCambio"))
                                End If
                            Else
                                dAplica = 0
                                ImporteReembolso += (TotalDevolucion * dtVenta.Rows(i)("TipoCambio"))
                            End If
                        Else

                            If dtVenta.Rows(i)("Saldo") > 0 Then
                                If dtVenta.Rows(i)("Saldo") >= TotalDevolucion Then
                                    dAplica = TotalDevolucion
                                Else
                                    dAplica = dtVenta.Rows(i)("Saldo")
                                    ImporteReembolso += ((TotalDevolucion - dtVenta.Rows(i)("Saldo")) * dtVenta.Rows(i)("TipoCambio"))
                                End If
                                msg = ModPOS.Ejecuta("sp_actualiza_saldo_doc", "@Tipo", 1, "@Documento", dtVenta.Rows(i)("VENClave"), "@Importe", dAplica * dtVenta.Rows(i)("TipoCambio"))

                                If msg <> "OK" Then
                                    MessageBox.Show(msg)
                                End If

                                msg = ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("Cliente"), "@Importe", dAplica * dtVenta.Rows(i)("TipoCambio"))

                                If msg <> "OK" Then
                                    MessageBox.Show(msg)
                                End If

                            Else
                                dAplica = 0
                                ImporteReembolso += (TotalDevolucion * dtVenta.Rows(i)("TipoCambio"))
                            End If
                            dt.Dispose()
                        End If

                    Else
                        dAplica = 0
                        ImporteReembolso += (TotalDevolucion * dtVenta.Rows(i)("TipoCambio"))
                    End If

                    msg = ModPOS.Ejecuta("st_actualiza_dev", "@DEVClave", DEVClave, "@Importe", dAplica)

                    If msg <> "OK" Then
                        MessageBox.Show(msg)
                    End If

                    If StageDev = "" Then
                        ModPOS.GeneraMovInv(1, 3, 3, DEVClave, ALMClave, FolioDevolucion, Autoriza, False)
                    Else
                        ModPOS.GeneraMovInv(1, 3, 3, DEVClave, ALMClave, FolioDevolucion, Autoriza, False, 1, StageDev, StageCan)

                        If CambioEstado = True AndAlso InterfazSalida <> "" Then


                            For j = 0 To dtBloqueados.Rows.Count - 1

                                msg = ModPOS.Ejecuta("st_act_bloqueado_ubc", _
                                                         "@UBCClave", StageDev, _
                                                         "@PROClave", dtBloqueados.Rows(i)("PROClave"), _
                                                         "@Cantidad", dtBloqueados.Rows(i)("Bloquear"))

                                If msg <> "OK" Then
                                    MessageBox.Show(msg)
                                End If

                                msg = ModPOS.Ejecuta("st_cambio_estado", _
                                                    "@SUCClave", SUCClave, _
                                                    "@ALMClave", ALMClave, _
                                                    "@UBCClave", StageDev, _
                                                    "@PROClave", dtBloqueados.Rows(i)("PROClave"), _
                                                    "@Cantidad", dtBloqueados.Rows(i)("Bloquear"), _
                                                    "@Estado", EstadoPEU, _
                                                    "@Referencia", Referencia, _
                                                    "@Actualiza", 1, _
                                                    "@Usuario", ModPOS.UsuarioActual)

                                If msg <> "OK" Then
                                    MessageBox.Show(msg)
                                End If

                            Next

                            Dim dtInterfaz As DataTable
                            Dim sFecha As String

                            sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                            dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CambioEstado", "@COMClave", ModPOS.CompanyActual)
                            If dtInterfaz.Rows.Count > 0 Then
                                msg = ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", Referencia, "@TipoDocumento", 0, "@Path", InterfazSalida, "@Fecha", sFecha)

                                If msg <> "OK" Then
                                    MessageBox.Show(msg)
                                End If

                            End If

                        End If

                    End If


                    If TallaColor = 0 Then

                        imprimeDevolucion(DEVClave, Impresora, TicketDev, reciboTicket, ImpresoraFac, MonedaDesc, MonedaRef, 1, True, PrintGeneric)

                        If ActivaCaja = True AndAlso (TotalDevolucion - dAplica) > 0 Then

                            dt = ModPOS.Recupera_Tabla("sp_busca_corteCaja", "@CAJClave", CAJClave)

                            Dim IDCorte As String = ""
                            Dim dEfectivo As Decimal

                            If dt.Rows.Count > 0 Then
                                IDCorte = dt.Rows(0)("ID")
                            End If
                            dt.Dispose()

                            dt = Recupera_Tabla("st_recupera_efectivo_mon", "@IDCorte", IDCorte, "@COMClave", ModPOS.CompanyActual, "@MONClave", IIf(foundRows(0)("MONClave").GetType.Name = "DBNull", Moneda, foundRows(0)("MONClave")))

                            If dt.Rows.Count > 0 Then
                                dEfectivo = dt.Rows(0)("Efectivo")
                            End If
                            dt.Dispose()

                            If dEfectivo >= ImporteReembolso Then
                                Dim row1 As DataRow
                                row1 = dtReembolsos.NewRow()
                                row1.Item("DEVClave") = DEVClave
                                row1.Item("MONClave") = IIf(foundRows(0)("MONClave").GetType.Name = "DBNull", Moneda, foundRows(0)("MONClave"))
                                row1.Item("TipoCambio") = foundRows(0)("TipoCambio")
                                row1.Item("Importe") = (TotalDevolucion - dAplica)
                                dtReembolsos.Rows.Add(row1)


                            End If
                        End If
                    Else
                        'If TipoSucursal = 5 Then
                        '    'Crea Traspaso a Sucursal
                        '    msg = ModPOS.Ejecuta("st_crea_traslado_aut", "@DEVClave", DEVClave, "@SUCClave", SUCClave, "@ALMClave", ALMClave, "@UBCClave", StageDev, "@SUCDestino", SUCClavePadre, "@Todos", 1, "@Usuario", ModPOS.UsuarioActual)

                        '    If msg <> "OK" Then
                        '        MessageBox.Show(msg)
                        '    End If
                        'Else

                        foundRows = dtDetalle.Select("Devolver > 0 and  Defecto = 1 ")
                        If foundRows.Length > 0 Then

                            'Crea un traspaso por cada grupo de material que se encuentre a un posible destino diferente
                            Dim dtDestino As DataTable = ModPOS.Recupera_Tabla("st_muestra_suc_devolucion", "@DEVClave", DEVClave)
                            Dim k As Integer
                            For k = 0 To dtDestino.Rows.Count - 1
                                msg = ModPOS.Ejecuta("st_crea_traslado_aut", "@DEVClave", DEVClave, "@SUCClave", SUCClave, "@ALMClave", ALMClave, "@UBCClave", StageDev, "@SUCDestino", dtDestino.Rows(k)("SUCClave"), "@ALMDestino", dtDestino.Rows(k)("ALMClave"), "@Todos", 0, "@Usuario", ModPOS.UsuarioActual)

                                If msg <> "OK" Then
                                    MessageBox.Show(msg)
                                End If

                            Next
                        End If
                        'End If
                    End If


                Next

                If TallaColor = 1 Then


                    ModPOS.Ejecuta("st_crea_cargoproveedor", "@NCClave", NCClave, "@Usuario", ModPOS.UsuarioActual)

                    If msg <> "OK" Then
                        MessageBox.Show(msg)
                    End If

                    Dim ImporteCargo As Decimal = 0
                    Dim SaldoCargo As Decimal

                    Dim dtCargo As DataTable = ModPOS.Recupera_Tabla("st_busca_servicios", "@Campo", 1, "@Busqueda", "%", "@COMClave", ModPOS.CompanyActual, "@noFacturable", 1)

                    If dtCargo.Rows.Count > 1 Then
                        Select Case MessageBox.Show("¿Desea agregar un Cargo a la Devolución?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            Case DialogResult.Yes
                                Dim cr As New FrmCargo
                                cr.NCClave = Me.NCClave
                                cr.SUCClave = Me.SUCClave
                                cr.CTEClave = Me.dtDetalle.Rows(0)("Cliente")
                                cr.CAJClave = Me.CAJClave
                                cr.ClaveCaja = Me.Referencia
                                cr.StartPosition = FormStartPosition.CenterScreen
                                cr.ShowDialog()
                                If cr.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                    ImporteCargo = cr.Total
                                End If
                                cr.Dispose()
                        End Select
                    End If

                    If ImporteCargo <= ImporteReembolso Then
                        ImporteReembolso -= ImporteCargo
                        SaldoCargo = 0
                    Else
                        SaldoCargo = ImporteCargo - ImporteReembolso
                        ImporteReembolso = 0
                    End If
                    'se recalcula y guardan las tablas de Vale, ValeDet y ValeImp

                    msg = ModPOS.Ejecuta("st_act_vale", _
                                    "@NCClave", NCClave, _
                                    "@Total", ImporteReembolso)

                    If msg <> "OK" Then
                        MessageBox.Show(msg)
                    End If

                    ImprimeVale(NCClave, Impresora, TicketDev, False, -1, True, PrintGeneric)


                    foundRows = dtDetalle.Select("Devolver > 0 and  Defecto = 1 ")
                    If foundRows.Length > 0 Then
                        ImprimeDefectos(NCClave, Impresora, TicketDev)
                    End If

                    'Genera interfaz de Devolucion

                    Dim dtInterfaz As DataTable
                    Dim sFecha As String

                    sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                    dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Devolucion", "@COMClave", ModPOS.CompanyActual)
                    If dtInterfaz.Rows.Count > 0 AndAlso ImporteReembolso > 0 Then
                        ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", NCClave, "@TipoDocumento", 0, "@Path", InterfazSalida, "@Fecha", sFecha)

                        If msg <> "OK" Then
                            MessageBox.Show(msg)
                        End If

                    End If

                    'valida si todo el vale puede timbrarse

                    foundRows = dtDetalle.Select("Devolver > 0 and uuid =''")
                    If foundRows.GetLength(0) = 0 Then
                        ' Crear nota de credito
                        crearCF()

                    End If


                Else

                    If dtReembolsos.Rows.Count > 0 Then
                        'Select Case MessageBox.Show("¿Desea aplicar un reembolso por " & Format(CStr(ModPOS.Redondear(ImporteReembolso, 2)), "Currency") & " " & MonedaRef & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        '    Case DialogResult.Yes

                        For i = 0 To dtReembolsos.Rows.Count - 1
                            msg = ModPOS.Ejecuta("st_aplica_reembolso", _
                                           "@CTEClave", foundRows(0)("Cliente"), _
                                           "@DOCClave", dtReembolsos.Rows(i)("DEVClave"), _
                                           "@TipoDocumento", 5, _
                                           "@CAJClave", CAJClave, _
                                           "@Moneda", dtReembolsos.Rows(i)("MONClave"), _
                                           "@TipoCambio", dtReembolsos.Rows(i)("TipoCambio"), _
                                           "@Saldo", dtReembolsos.Rows(i)("Importe"), _
                                           "@Usuario", ModPOS.UsuarioActual)

                            If msg <> "OK" Then
                                MessageBox.Show(msg)
                            End If

                        Next
                        If Cajon = True Then
                            AbrirCajon(Impresora)
                        End If
                        '  End Select


                    End If
                End If


                dtDetalle.Dispose()
                If Padre = "Menu" Then
                    reinicializa()
                    bError = True
                Else
                    bError = False
                    Me.Close()
                End If
            Else
                MessageBox.Show("Debe indicar una cantidad a devolver mayor o igual al disponible", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bError = True
            End If
        Else
            MessageBox.Show("No se encontraron productos a devolver en el documento actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bError = True
        End If
    End Sub

    Private Sub BtnBuscaTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFolio.Click
        Dim a As New MeSearchDate
        a.ProcedimientoAlmacenado = "sp_search_ticket"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            TxtFolio.Text = a.Descripcion
            Me.AgregarFolio(False, a.Descripcion)
        End If
        a.Dispose()
    End Sub



    Private Function cambiaCliente(ByVal sCTEClave As String) As Boolean
        Dim dt As DataTable
        Dim result As Boolean
        dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", sCTEClave)
        If dt.Rows.Count = 0 Then
            MessageBox.Show("Error al intentar cargar información de domicilios del cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)


            CTEClave = ""
            txtRazonSocial.Text = ""
            txtCliente.Text = ""
            result = False
            ListaPrecio = ""
        Else
            ListaPrecio = dt.Rows(0)("PREClave")
            CTEClave = sCTEClave
            txtRazonSocial.Text = dt.Rows(0)("RazonSocial")
            txtCliente.Text = dt.Rows(0)("Clave")
            result = True
        End If


        Return result

    End Function


    Private Function leeCodigoBarras(ByVal Codigo As String) As Boolean

        CantidadDevolver = Math.Abs(CDbl(TxtCantidad.Text))


        If CTEClave = "" Then
            MessageBox.Show("El Cliente es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        'Valida que el campo producto no se encuentre vacio
        If Not Codigo = vbNullString Then


            Dim dt As DataTable = Nothing


            'Busca y recupera los datos del producto


            'Si Modulo TallaColor 
            If TallaColor = 1 Then
                Dim dtModelo As DataTable = ModPOS.Recupera_Tabla("st_valida_modelo", "@COMClave", ModPOS.CompanyActual, "@Modelo", Codigo)
                If dtModelo.Rows.Count > 0 Then
                    Dim a As New FrmTallaColor
                    a.SUCClave = SUCClave
                    a.PREClave = ListaPrecio
                    a.CTEClave = CTEClave
                    a.sModelo = dtModelo.Rows(0)("Modelo")
                    a.ALMClave = ALMClave
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Codigo = a.Clave
                    Else
                        dtModelo.Dispose()
                        Return False
                    End If
                    dtModelo.Dispose()
                End If
            End If


            dt = ModPOS.SiExisteRecupera("sp_compra_producto", "@COMClave", ModPOS.CompanyActual, "@Clave", Codigo.Replace("'", "''"), "@Char", cReplace, "@TallaColor", TallaColor)

            Dim TipoBusqueda As String = ""

            If dt Is Nothing Then
                Beep()
                PROClave = ""
                txtProducto.Text = ""
                txtNombre.Text = ""
                MessageBox.Show("El Código " & Codigo & " no corresponde a un Producto Existente o Activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Else

                PROClave = dt.Rows(0)("PROClave")
                txtProducto.Text = dt.Rows(0)("Clave")
                txtNombre.Text = dt.Rows(0)("Nombre")

                'Si debe buscar en Historico
                If TallaColor = 1 Then
                    Dim frmstatusmessage As frmStatus = Nothing

                    frmstatusmessage = New frmStatus
                    frmstatusmessage.Show("Buscando en Historico...")

                    dt = ModPOS.Recupera_Tabla("st_recupera_producto_dev_hist", "@CTEClave", CTEClave, "@PROClave", PROClave, "@Criterio", DiasMaxDev)

                    TipoBusqueda = "Historico"

                    frmstatusmessage.Close()

                End If


                'Si debe buscar en concentrador
                If dt.Rows.Count = 0 AndAlso DevConcentra = 1 AndAlso IPConcentrador <> "" Then
                    Dim frmstatusmessage As frmStatus = Nothing

                    frmstatusmessage = New frmStatus
                    frmstatusmessage.Show("Buscando en Concentrador...")


                    Dim ip As System.Net.IPAddress = System.Net.IPAddress.Parse(IPConcentrador)
                    Dim ping As System.Net.NetworkInformation.Ping = New System.Net.NetworkInformation.Ping()

                    Dim pr As System.Net.NetworkInformation.PingReply = ping.Send(ip)
                    If pr.Status.ToString() = "Success" Then

                        dt = ModPOS.Recupera_Tabla("st_recupera_producto_dev", "@CONCENTRA", 1, "@DevConcentra", DevConcentra, "@SUCClave", SUCClave, "@CTEClave", CTEClave, "@PROClave", PROClave, "@Criterio", DiasMaxDev)

                        TipoBusqueda = "Concentrador"

                    Else
                        MsgBox("No se puede conectar al Servidor " & IPConcentrador, MsgBoxStyle.Information, "Error")

                    End If

                    frmstatusmessage.Close()

                End If


                If dt.Rows.Count = 0 Then
                    dt = ModPOS.Recupera_Tabla("st_recupera_producto_dev", "@CONCENTRA", 0, "@DevConcentra", DevConcentra, "@SUCClave", SUCClave, "@CTEClave", CTEClave, "@PROClave", PROClave, "@Criterio", DiasMaxDev)
                    TipoBusqueda = "Local"
                End If



                Dim Cantidad As Double = CantidadDevolver

                If dt.Rows.Count > 0 Then
                    Dim i As Integer
                    Dim row1 As DataRow

                    Dim foundRows() As System.Data.DataRow
                    Dim foundRows2() As System.Data.DataRow

                    For i = 0 To dt.Rows.Count - 1

                        foundRows = dtDetalle.Select("VENClave = '" & dt.Rows(i)("VENClave") & "' and DVEClave = '" & dt.Rows(i)("DVEClave") & "'")

                        Dim Disponible As Double

                        If foundRows.Length = 1 Then

                            Disponible = foundRows(0)("Disp") - foundRows(0)("Devolver")

                            If Disponible >= Cantidad Then
                                foundRows(0)("Devolver") += Cantidad
                                Cantidad = 0
                            Else
                                foundRows(0)("Devolver") += Disponible
                                Cantidad -= Disponible
                            End If

                            foundRows(0)("Importe") = foundRows(0)("Devolver") * foundRows(0)("Precio")

                        Else

                            If TallaColor = 1 AndAlso dt.Rows(i)("Sector") = 509 Then
                                MessageBox.Show("El Producto no esta disponible para devolución ya que se compro en Saldos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ElseIf TallaColor = 1 AndAlso CStr(dt.Rows(i)("uuid")) = "" AndAlso CInt(dt.Rows(i)("Tipo")) = 1 AndAlso CDec(dt.Rows(i)("Saldo")) > 0 Then
                                MessageBox.Show("No se puede regresar un producto de una venta con saldo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                If CDate(dt.Rows(i)("Fecha")) < Today.Date.AddDays(-30) Then

                                    If MessageBox.Show("El Producto que desea devolver cuenta con más de 30 dias de haberlo comprado, requiere autorización para continuar", "Información", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = System.Windows.Forms.DialogResult.OK Then

                                        Dim a As New MeAutorizacion
                                        a.Sucursal = SUCClave
                                        a.MontodeAutorizacion = (Cantidad * dt.Rows(i)("Precio")) * dt.Rows(i)("TipoCambio")
                                        a.StartPosition = FormStartPosition.CenterScreen
                                        a.ShowDialog()
                                        If a.DialogResult = DialogResult.OK Then
                                            If Not a.Autorizado Then
                                                a.Dispose()
                                                Return False

                                            End If
                                            Autoriza = a.Autoriza
                                        ElseIf a.DialogResult = DialogResult.Cancel Then
                                            a.Dispose()
                                            Return False

                                        End If
                                        a.Dispose()

                                    Else
                                        Return False
                                    End If
                                End If



                                Dim bDefecto As Boolean = False
                                Dim bMotivo As Boolean = False
                                Dim iMotivo, iGrupo As Integer

                                'Seleccionar Motivo
                                If ChkFijar.Checked = False Then

                                    Select Case MessageBox.Show("¿Los Productos tienen Defecto?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                        Case DialogResult.Yes
                                            iGrupo = 1
                                        Case System.Windows.Forms.DialogResult.No
                                            iGrupo = 0
                                    End Select

                                    Do
                                        Dim m As New FrmMotivo
                                        m.Text = "Motivo de Devolución"
                                        m.Tabla = "Devolucion"
                                        m.Campo = "Motivo"
                                        m.Grupo = CStr(iGrupo)
                                        m.ShowDialog()
                                        If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                            bMotivo = True
                                            iMotivo = m.Motivo
                                            cmbMotivo.SelectedValue = iMotivo
                                        End If
                                        m.Dispose()
                                    Loop While bMotivo = False
                                    'Si tiene Defecto, seleccionar Proveedor

                                    Select Case MessageBox.Show("¿Desea Fijar el Motivo de Devolución?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                        Case DialogResult.Yes
                                            ChkFijar.Checked = True
                                            cmbMotivo.Enabled = False
                                    End Select
                                Else
                                    'obtener valor del defecto 
                                    iMotivo = cmbMotivo.SelectedValue
                                End If

                                Dim dtValor As DataTable
                                dtValor = Recupera_Tabla("sp_obtener_valorref", "@Tabla", "Devolucion", "@Campo", "Motivo", "@Valor", cmbMotivo.SelectedValue)
                                If dtValor.Rows.Count > 0 Then
                                    bDefecto = IIf(CInt(dtValor.Rows(0)("Grupo")) = 0, False, True)
                                Else
                                    bDefecto = False
                                End If
                                dtValor.Dispose()


                                Dim PRVClave As String = ""
                                Dim Proveedor As String = ""

                                ' Recupera Proveedor 
                                If bDefecto = True Then

                                    Dim dtPrv As DataTable

                                    dtPrv = ModPOS.Recupera_Tabla("st_recupera_prvprod", "@PROClave", PROClave)

                                    If dtPrv.Rows.Count = 0 Then
                                        PRVClave = "NA"
                                        Proveedor = ""
                                    ElseIf dtPrv.Rows.Count = 1 Then
                                        PRVClave = dtPrv.Rows(0)("PRVClave")
                                        Proveedor = dtPrv.Rows(0)("Clave")
                                    Else
                                        Do
                                            Dim a As New FrmBoxConsulta
                                            a.ObjetoCaptura = "Proveedor"
                                            a.Text = "Selección de Proveedor"
                                            a.Campo = "PRVClave"
                                            a.Campo2 = "Clave"
                                            a.dtConsulta = dtPrv
                                            '  ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_recupera_prvprod", "@PROClave", PROClave)
                                            'a.GridConsultaGen.RootTable.Columns("PRVClave").Visible = False
                                            a.ShowDialog()
                                            If a.DialogResult = DialogResult.OK Then
                                                If a.ID <> "" Then
                                                    PRVClave = a.ID
                                                    Proveedor = a.ID2
                                                End If
                                            End If
                                            a.Dispose()
                                        Loop While PRVClave = ""
                                    End If

                                End If


                                Dim Devolver As Double = 0
                                Disponible = dt.Rows(i)("Disp")

                                If Disponible >= Cantidad Then
                                    Devolver = Cantidad
                                    Cantidad = 0
                                Else
                                    Devolver = Disponible
                                    Cantidad -= Disponible
                                End If

                                Dim dPrecio As Decimal = dt.Rows(i)("Precio")
                                Dim dImporte As Decimal = Devolver * dt.Rows(i)("Precio")
                                Dim dPrecioBruto As Decimal = dt.Rows(i)("PrecioBruto")
                                Dim dPorcDesc As Double = dt.Rows(i)("PorcDesc")


                                If TallaColor = 1 Then



                                    If dt.Rows(i)("Sector") = 512 And dt.Rows(i)("SectorActual") = 510 Then
                                        'Pasa de Linea a Oferta y se recalcula precio
                                        Dim dtPrecio As DataTable = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 3, "@Busca", dt.Rows(i)("PROClave"), "@SUCClave", SUCClave, "@PREClave", dt.Rows(i)("PREClave"), "@CTEClave", CTEClave, "@Cantidad", 1, "@Char", cReplace, "@Servicio", 0, "@TallaColor", TallaColor)
                                        If Not dtPrecio Is Nothing Then
                                            dPrecio = dtPrecio.Rows(0)("PrecioNeto") / dt.Rows(i)("TipoCambio")
                                            dImporte = Devolver * (dtPrecio.Rows(0)("PrecioNeto") / dt.Rows(i)("TipoCambio"))
                                            dPrecioBruto = dtPrecio.Rows(0)("PrecioBruto")
                                            dPorcDesc = dtPrecio.Rows(0)("DescGeneral") / 100
                                        End If

                                    End If
                                End If

                                row1 = dtDetalle.NewRow()
                                'declara el nombre de la fila


                                Dim idVenta As String = dt.Rows(i)("VENClave")

                                row1.Item("uuid") = dt.Rows(i)("uuid")
                                row1.Item("Saldo") = dt.Rows(i)("Saldo")
                                row1.Item("VENClave") = idVenta
                                row1.Item("DVEClave") = dt.Rows(i)("DVEClave")
                                row1.Item("PREClave") = dt.Rows(i)("PREClave")
                                row1.Item("Fecha") = dt.Rows(i)("Fecha")
                                row1.Item("Folio") = dt.Rows(i)("Folio")
                                row1.Item("Venta") = dt.Rows(i)("Venta")
                                row1.Item("Disp") = dt.Rows(i)("Disp")
                                row1.Item("Devolver") = Devolver
                                row1.Item("Motivo") = iMotivo
                                row1.Item("Defecto") = bDefecto
                                row1.Item("PROClave") = dt.Rows(i)("PROClave")
                                row1.Item("TProducto") = dt.Rows(i)("TProducto")
                                row1.Item("Seguimiento") = dt.Rows(i)("Seguimiento")
                                row1.Item("DiasGarantia") = dt.Rows(i)("DiasGarantia")
                                row1.Item("Clave") = dt.Rows(i)("Clave")
                                row1.Item("Nombre") = dt.Rows(i)("Nombre")
                                row1.Item("Precio") = dPrecio
                                row1.Item("Importe") = dImporte
                                row1.Item("Costo") = dt.Rows(i)("Costo")
                                row1.Item("PrecioBruto") = dPrecioBruto
                                row1.Item("PorcImp") = dt.Rows(i)("PorcImp")
                                row1.Item("PorcDesc") = dPorcDesc
                                row1.Item("PuntosImp") = dt.Rows(i)("Puntosimp")
                                row1.Item("Cliente") = dt.Rows(i)("Cliente")
                                row1.Item("MONClave") = dt.Rows(i)("MONClave")
                                row1.Item("TipoCambio") = dt.Rows(i)("TipoCambio")
                                row1.Item("PRVClave") = PRVClave
                                row1.Item("Sector") = dt.Rows(i)("Sector")
                                row1.Item("SectorActual") = dt.Rows(i)("SectorActual")
                                row1.Item("IdKIT") = dt.Rows(i)("IdKIT")
                                row1.Item("PROClaveKIT") = dt.Rows(i)("PROClaveKIT")
                                row1.Item("KIT") = dt.Rows(i)("KIT")
                                row1.Item("PiezasKIT") = dt.Rows(i)("PiezasKIT")
                                row1.Item("Historico") = dt.Rows(i)("Historico")
                                row1.Item("Proveedor") = Proveedor
                                dtDetalle.Rows.Add(row1)


                                If bDefecto = False AndAlso dt.Rows(i)("IdKIT") <> "" Then
                                    'Recupera  KIT
                                    If MessageBox.Show("El producto devuelto pertenece a un paquete. ¿Desea devolver el resto de los productos del paquete?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then

                                        Dim dtPaq As DataTable = ModPOS.Recupera_Tabla("st_recupera_dev_paq", "@IdKIT", dt.Rows(i)("IdKIT"), "@VENClave", dt.Rows(i)("VENClave"), "@DVEClave", dt.Rows(i)("DVEClave"), "@TipoBusqueda", TipoBusqueda)

                                        If dtPaq.Rows.Count > 0 Then
                                            Dim k As Integer
                                            For k = 0 To dtPaq.Rows.Count - 1
                                                foundRows = dtDetalle.Select("VENClave = '" & dtPaq.Rows(k)("VENClave") & "' and DVEClave = '" & dtPaq.Rows(k)("DVEClave") & "'")
                                                If foundRows.Length = 0 Then

                                                    Dim dPrecioP As Decimal = dtPaq.Rows(k)("Precio")
                                                    Dim dImporteP As Decimal = dtPaq.Rows(k)("Disp") * dtPaq.Rows(k)("Precio")
                                                    Dim dPrecioBrutoP As Decimal = dtPaq.Rows(k)("PrecioBruto")
                                                    Dim dPorcDescP As Double = dtPaq.Rows(k)("PorcDesc")


                                                    If TallaColor = 1 Then



                                                        If dtPaq.Rows(k)("Sector") = 512 And dtPaq.Rows(k)("SectorActual") = 510 Then
                                                            'Pasa de Linea a Oferta y se recalcula precio
                                                            Dim dtPrecio As DataTable = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 3, "@Busca", dtPaq.Rows(k)("PROClave"), "@SUCClave", SUCClave, "@PREClave", dtPaq.Rows(k)("PREClave"), "@CTEClave", CTEClave, "@Cantidad", 1, "@Char", cReplace, "@Servicio", 0, "@TallaColor", TallaColor)
                                                            If Not dtPrecio Is Nothing Then
                                                                dPrecioP = dtPrecio.Rows(0)("PrecioNeto") / dt.Rows(i)("TipoCambio")
                                                                dImporteP = dtPaq.Rows(k)("Disp") * (dtPrecio.Rows(0)("PrecioNeto") / dt.Rows(i)("TipoCambio"))
                                                                '  dPrecioBrutoP = dtPrecio.Rows(0)("PrecioBruto")
                                                                dPorcDescP = dtPrecio.Rows(0)("DescGeneral") / 100
                                                            End If

                                                        End If
                                                    End If

                                                    row1 = dtDetalle.NewRow()
                                                    row1.Item("uuid") = dtPaq.Rows(k)("uuid")
                                                    row1.Item("Saldo") = dtPaq.Rows(k)("Saldo")
                                                    row1.Item("VENClave") = dtPaq.Rows(k)("VENClave")
                                                    row1.Item("DVEClave") = dtPaq.Rows(k)("DVEClave")
                                                    row1.Item("PREClave") = dtPaq.Rows(k)("PREClave")
                                                    row1.Item("Fecha") = dtPaq.Rows(k)("Fecha")
                                                    row1.Item("Folio") = dtPaq.Rows(k)("Folio")
                                                    row1.Item("Venta") = dtPaq.Rows(k)("Venta")
                                                    row1.Item("Disp") = dtPaq.Rows(k)("Disp")
                                                    row1.Item("Devolver") = dtPaq.Rows(k)("Disp")
                                                    row1.Item("Motivo") = iMotivo
                                                    row1.Item("Defecto") = bDefecto
                                                    row1.Item("PROClave") = dtPaq.Rows(k)("PROClave")
                                                    row1.Item("TProducto") = dtPaq.Rows(k)("TProducto")
                                                    row1.Item("Seguimiento") = dtPaq.Rows(k)("Seguimiento")
                                                    row1.Item("DiasGarantia") = dtPaq.Rows(k)("DiasGarantia")
                                                    row1.Item("Clave") = dtPaq.Rows(k)("Clave")
                                                    row1.Item("Nombre") = dtPaq.Rows(k)("Nombre")
                                                    row1.Item("Precio") = dPrecioP
                                                    row1.Item("Importe") = dImporteP
                                                    row1.Item("Costo") = dtPaq.Rows(k)("Costo")
                                                    row1.Item("PrecioBruto") = dPrecioBrutoP
                                                    row1.Item("PorcImp") = dtPaq.Rows(k)("PorcImp")
                                                    row1.Item("PorcDesc") = dPorcDescP
                                                    row1.Item("PuntosImp") = dtPaq.Rows(k)("Puntosimp")
                                                    row1.Item("Cliente") = dtPaq.Rows(k)("Cliente")
                                                    row1.Item("MONClave") = dtPaq.Rows(k)("MONClave")
                                                    row1.Item("TipoCambio") = dtPaq.Rows(k)("TipoCambio")
                                                    row1.Item("PRVClave") = PRVClave
                                                    row1.Item("Sector") = dtPaq.Rows(k)("Sector")
                                                    row1.Item("SectorActual") = dtPaq.Rows(k)("SectorActual")
                                                    row1.Item("IdKIT") = dtPaq.Rows(k)("IdKIT")
                                                    row1.Item("PROClaveKIT") = dtPaq.Rows(k)("PROClaveKIT")
                                                    row1.Item("KIT") = dtPaq.Rows(k)("KIT")
                                                    row1.Item("PiezasKIT") = dtPaq.Rows(k)("PiezasKIT")
                                                    row1.Item("Historico") = dtPaq.Rows(k)("Historico")
                                                    row1.Item("Proveedor") = Proveedor
                                                    dtDetalle.Rows.Add(row1)



                                                End If
                                            Next


                                        End If



                                    End If

                                End If


                                foundRows = dtVenta.Select("VENClave = '" & idVenta & "'")
                                If foundRows.Length = 0 Then

                                    row1 = dtVenta.NewRow()
                                    row1.Item("uuid") = dt.Rows(i)("uuid")
                                    row1.Item("VENClave") = dt.Rows(i)("VENClave")
                                    row1.Item("Folio") = dt.Rows(i)("Folio")
                                    row1.Item("Cliente") = dt.Rows(i)("Cliente")
                                    row1.Item("MONClave") = dt.Rows(i)("MONClave")
                                    row1.Item("TipoCambio") = dt.Rows(i)("TipoCambio")
                                    row1.Item("Saldo") = dt.Rows(i)("Saldo")
                                    row1.Item("Historico") = dt.Rows(i)("Historico")
                                    dtVenta.Rows.Add(row1)
                                End If

                                End If

                        End If

                        If Cantidad = 0 Then
                            Exit For
                        End If

                    Next


                End If

                dt.Dispose()

                If Cantidad > 0 Then
                    Beep()
                    MessageBox.Show("No hay suficiente producto disponible para devolver. Cantidad faltante: " & CStr(Cantidad))
                End If

                CantidadDevolver = 1
                TxtCantidad.Text = CantidadDevolver
                PROClave = ""
                txtProducto.Text = ""
                txtNombre.Text = ""
                txtProducto.Focus()

                Return True
                End If

        End If
    End Function



    Private Sub btnProducto_Click(sender As Object, e As EventArgs) Handles btnProducto.Click

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
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            leeCodigoBarras(a.valor)
        End If
        a.Dispose()
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim a As New MeSearch
        a.MaskCte = MaskCte
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then

                cambiaCliente(a.valor)

            End If

        End If
        a.Dispose()
    End Sub

    Private Sub txtCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCliente.KeyPress
        If (Asc(e.KeyChar)) = 13 Then
            If Not txtCliente.Text = vbNullString Then


                If MaskCte = 1 Then
                    If txtCliente.Text.Split("-").Length = 2 Then
                        If IsNumeric(txtCliente.Text.Split("-")(0)) AndAlso IsNumeric(txtCliente.Text.Split("-")(1)) Then

                            Dim sSucursal As String
                            Dim sClaveCte As String

                            sSucursal = String.Format("{0:000}", Val(CDbl(txtCliente.Text.Split("-")(0))))
                            sClaveCte = String.Format("{0:0000000}", Val(CDbl(txtCliente.Text.Split("-")(1))))


                            txtCliente.Text = sSucursal & "-" & sClaveCte
                        End If
                    End If
                End If

                Dim dt As DataTable
                dt = ModPOS.SiExisteRecupera("sp_recupera_clavecte", "@Clave", txtCliente.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual, "@SUCClave", SUCClave)
                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                    cambiaCliente(dt.Rows(0)("CTEClave"))
                    dt.Dispose()
                Else
                    MessageBox.Show("No se encontro registro que coincida con la clave proporcionada", "Información", MessageBoxButtons.OK)
                End If
            End If
        End If
    End Sub

    Private Sub txtProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProducto.KeyPress
        If Asc(e.KeyChar) = 13 Then
            leeCodigoBarras(txtProducto.Text.Trim.ToUpper.Replace("'", "''"))
        End If
    End Sub

    Private Sub rbFolio_CheckedChanged(sender As Object, e As EventArgs) Handles rbFolio.CheckedChanged
        If rbFolio.Checked Then
            TxtFolio.Enabled = True
            btnFolio.Enabled = True
            rbCliente.Checked = False
            BtnDel.Enabled = False

            txtCliente.Enabled = False
            txtProducto.Enabled = False
            btnCliente.Enabled = False
            btnProducto.Enabled = False
            TxtCantidad.Enabled = False
            TxtCantidad.Text = "1"

            txtNombre.Text = ""
            txtRazonSocial.Text = ""
            CTEClave = ""
            PROClave = ""
            AgregarFolio(False)
        End If
    End Sub

    Private Sub rbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rbCliente.CheckedChanged
        If rbCliente.Checked Then
            TxtFolio.Enabled = False
            btnFolio.Enabled = False
            rbFolio.Checked = False
            BtnDel.Enabled = True

            txtCliente.Enabled = True
            txtProducto.Enabled = True
            btnCliente.Enabled = True
            btnProducto.Enabled = True
            TxtCantidad.Enabled = True
            TxtCantidad.Text = "1"

            TxtFolio.Text = ""

            AgregarFolio(True)
        End If
    End Sub

    Private Sub CmbMotivo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMotivo.SelectedValueChanged
        If bLoad = True Then
            If Not cmbMotivo.SelectedValue Is Nothing Then
                Dim i As Integer


                Dim dtValor As DataTable
                Dim bDefecto As Boolean = False
                dtValor = Recupera_Tabla("sp_obtener_valorref", "@Tabla", "Devolucion", "@Campo", "Motivo", "@Valor", cmbMotivo.SelectedValue)
                If dtValor.Rows.Count > 0 Then

                    If dtValor.Rows(0)("Grupo").GetType.Name = "DBNull" Then
                        bDefecto = False
                    Else
                        bDefecto = IIf(CInt(dtValor.Rows(0)("Grupo")) = 0, False, True)
                    End If
                Else
                    bDefecto = False
                End If
                dtValor.Dispose()

                Dim foundRows() As DataRow
                foundRows = dtDetalle.Select("Motivo = 0")
                If foundRows.GetLength(0) > 0 Then
                    For i = 0 To foundRows.GetUpperBound(0)
                        If foundRows(i)("Devolver") > 0 Then

                            If bDefecto = True AndAlso foundRows(i)("PRVClave") = "NA" Then

                                Dim dtPrv As DataTable
                                Dim PRVClave, Proveedor As String
                                dtPrv = ModPOS.Recupera_Tabla("st_recupera_prvprod", "@PROClave", foundRows(i)("PROClave"))

                                If dtPrv.Rows.Count = 0 Then
                                    PRVClave = "NA"
                                    Proveedor = ""
                                ElseIf dtPrv.Rows.Count = 1 Then
                                    PRVClave = dtPrv.Rows(0)("PRVClave")
                                    Proveedor = dtPrv.Rows(0)("Clave")
                                Else
                                    Do
                                        Dim a As New FrmBoxConsulta
                                        a.ObjetoCaptura = "Proveedor"
                                        a.Text = "Selección de Proveedor"
                                        a.Campo = "PRVClave"
                                        a.Campo2 = "Clave"
                                        a.dtConsulta = dtPrv
                                        '  ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_recupera_prvprod", "@PROClave", PROClave)
                                        'a.GridConsultaGen.RootTable.Columns("PRVClave").Visible = False
                                        a.ShowDialog()
                                        If a.DialogResult = DialogResult.OK Then
                                            If a.ID <> "" Then
                                                PRVClave = a.ID
                                                Proveedor = a.ID2
                                            End If
                                        End If
                                        a.Dispose()
                                    Loop While PRVClave = ""
                                End If
                                foundRows(i)("PRVClave") = PRVClave
                                foundRows(i)("Proveedor") = Proveedor
                            Else
                                foundRows(i)("PRVClave") = "NA"
                                foundRows(i)("Proveedor") = ""

                            End If

                            foundRows(i)("Motivo") = cmbMotivo.SelectedValue
                            foundRows(i)("Defecto") = bDefecto

                        End If
                    Next
                End If
            End If
        End If

    End Sub

    Private Sub TxtCantidad_Leave(sender As Object, e As EventArgs) Handles TxtCantidad.Leave
        If Not TxtCantidad.Text = vbNullString Then
            If CDbl(TxtCantidad.Text) <= 0 Then
                CantidadDevolver = 1
                TxtCantidad.Text = CStr(CantidadDevolver)
            Else
                CantidadDevolver = Math.Abs(CDbl(TxtCantidad.Text))
            End If

        Else
            CantidadDevolver = 1
            TxtCantidad.Text = CStr(CantidadDevolver)
        End If

        TxtProducto.Focus()
    End Sub

    Private Sub ChkFijar_CheckedChanged(sender As Object, e As EventArgs) Handles ChkFijar.CheckedChanged
        If ChkFijar.Checked Then
            cmbMotivo.Enabled = False

        Else
            cmbMotivo.Enabled = True
        End If
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        If rbCliente.Checked = True AndAlso dtDetalle.Rows.Count > 0 Then
            Beep()
            Select Case MessageBox.Show("Se removera el Producto: " & GridDetalle.GetValue("Clave"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow

                    Dim sVENClave As String

                    sVENClave = GridDetalle.GetValue("VENClave")
                    foundRows = dtDetalle.Select("VENClave = '" & sVENClave & "' and DVEClave = '" & GridDetalle.GetValue("DVEClave") & "'")
                    If foundRows.Length = 1 Then
                        dtDetalle.Rows.Remove(foundRows(0))
                    End If

                    foundRows = dtDetalle.Select("VENClave = '" & sVENClave & "'")
                    If foundRows.Length = 0 Then
                        foundRows = dtVenta.Select("VENClave = '" & sVENClave & "'")
                        dtVenta.Rows.Remove(foundRows(0))
                    End If

            End Select

        End If
    End Sub

    Private Sub BtnConsultar_Click(sender As Object, e As EventArgs) Handles BtnConsultar.Click
        If CTEClave = "" Then
            MessageBox.Show("El Cliente es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

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
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then

            Dim b As New FrmConsultaGen
            b.Text = "Detalle de productos devueltos"
            ModPOS.ActualizaGrid(False, b.GridConsultaGen, "st_recupera_devoluciones", "@CTEClave", CTEClave, "@PROClave", a.valor, "@TallaColor", TallaColor)
            b.GridConsultaGen.GroupByBoxVisible = False
            If b.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            End If


        End If
        a.Dispose()


    End Sub
End Class
