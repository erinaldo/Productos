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
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDevolucion))
        Me.GrpTickets = New System.Windows.Forms.GroupBox()
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
        Me.Label4.Location = New System.Drawing.Point(258, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(149, 20)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Motivo de Devolución"
        '
        'cmbMotivo
        '
        Me.cmbMotivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMotivo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbMotivo.Location = New System.Drawing.Point(413, 17)
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


    Private TipoSucursal As Integer

    Private VALClave As String = ""
    Private ImpresoraFac As String = ""

    Private CTEClave, PROClave, IPConcentrador As String
    Private DiasMaxDev As Integer = 0
    Private TallaColor, DevConcentra As Integer
  
    Private Folio As Integer
    Private SUCClavePadre As String
    Private Autoriza, Stage As String
    Private InterfazSalida As String = ""
    Private Estado As Integer = 0

    Private dtVenta, dtDetalle, dtMotivo As DataTable
    Private CantidadDevolver As Double

    Private bLoad As Boolean = False

    Private Mes As Integer
    Private Periodo As Integer
    Private dtBloqueados As DataTable

    Private Moneda As String
    Private MonedaRef As String
    Private MonedaDesc As String

    Private bError As Boolean = False



  
    Private Sub FrmDevolucion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)


        Me.StartPosition = FormStartPosition.CenterScreen

        Dim dt As DataTable

        If reciboTicket = 0 OrElse TicketDev = "" Then

            Dim sImpresora As String
            dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
            sImpresora = dt.Rows(0)("ImpresoraFac")
            dt.Dispose()

            dt = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", sImpresora)
            ImpresoraFac = dt.Rows(0)("Referencia")
            dt.Dispose()

        End If

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
            Stage = IIf(dt.Rows(0)("Stage").GetType.Name = "DBNull", "", dt.Rows(0)("Stage"))
            dt.Dispose()
        End If


        Dim dtParam As DataTable

        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave ", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))

                    Case "InterfazSalida"
                        InterfazSalida = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                    Case "Moneda"
                        Moneda = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                    Case "TallaColor"
                        TallaColor = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))

                    Case "TallaColor"
                        TallaColor = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))

                    Case "DevConcentra"
                        DevConcentra = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))
                    Case "BusqDev"
                        DiasMaxDev = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))
                    Case "CONCENTRADOR"
                        IPConcentrador = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "0.0.0.0", dtParam.Rows(i)("Valor"))

                End Select
            Next
        End With
        dtParam.Dispose()





        dtBloqueados = ModPOS.CrearTabla("Bloqueados", _
                                             "PROClave", "System.String", _
                                             "Bloquear", "System.Double")




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

        If Not Ventas Is Nothing AndAlso Ventas.GetLength(0) = 1 Then
            TxtFolio.Text = Ventas(0)("Folio")
            Me.AgregarFolio(False, Ventas(0)("Folio"))

        End If

        bLoad = True
    End Sub


    Private Sub AgregarFolio(ByVal bCliente As Boolean, Optional ByVal Folio As String = "")
        If Not dtDetalle Is Nothing Then
            dtDetalle.Dispose()
        End If

        If Not dtVenta Is Nothing Then
            dtVenta.Dispose()
        End If

        dtVenta = ModPOS.CrearTabla("Venta", _
                                          "FACClave", "System.String", _
                                          "VENClave", "System.String", _
                                          "MONClave", "System.String", _
                                          "TipoCambio", "System.Decimal", _
                                          "Saldo", "System.Decimal")
       
        If bCliente = True Then
            dtDetalle = ModPOS.CrearTabla("Detalle", _
                                           "FACClave", "System.String", _
                                           "Saldo", "System.Decimal", _
                                           "VENClave", "System.String", _
                                           "DVEClave", "System.String", _
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
                                           "PRVClave", "System.String")

        Else
            dtDetalle = ModPOS.Recupera_Tabla("sp_detalle_dev", "@Folio", Folio, "@SUCClave", SUCClave)


            If dtDetalle.Rows.Count > 0 Then
                Dim row1 As DataRow
                row1 = dtVenta.NewRow()
                row1.Item("FACClave") = dtDetalle.Rows(0)("FACClave")
                row1.Item("VENClave") = dtDetalle.Rows(0)("VENClave")
                row1.Item("MONClave") = dtDetalle.Rows(0)("MONClave")
                row1.Item("TipoCambio") = dtDetalle.Rows(0)("TipoCambio")
                row1.Item("Saldo") = dtDetalle.Rows(0)("Saldo")
                dtVenta.Rows.Add(row1)
            End If

        End If


            GridDetalle.DataSource = dtDetalle
            GridDetalle.RetrieveStructure()
            GridDetalle.AutoSizeColumns()
        GridDetalle.RootTable.Columns("FACClave").Visible = False
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
            GridDetalle.RootTable.Columns("Defecto").Visible = False

            GridDetalle.RootTable.Columns("Precio").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            GridDetalle.RootTable.Columns("Importe").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

            GridDetalle.RootTable.Columns("Folio").Width = 40
            GridDetalle.RootTable.Columns("Fecha").Width = 30
            GridDetalle.RootTable.Columns("Devolver").Width = 20
            GridDetalle.RootTable.Columns("Motivo").Width = 40
            GridDetalle.RootTable.Columns("Venta").Width = 20
            GridDetalle.RootTable.Columns("Disp").Width = 20


            GridDetalle.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True
            GridDetalle.RootTable.Columns("Importe").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
            GridDetalle.RootTable.Columns("Importe").TotalFormatString = "c"

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


            If bCliente = False AndAlso dtDetalle.Rows.Count = 0 Then
                MessageBox.Show("No se encontro producto disponible para devolver en el documento: " & TxtFolio.Text & " o se encuentra Apartado/Facturado/Cancelado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

    End Sub

    Private Function imprimeRecibo(ByVal Abono As String, ByVal Importe As Double, ByVal Cambio As Double, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String, ByVal Usu As String, ByVal Cte As String) As Boolean
        Dim dTotalPagos, dPagos As Double

        Dim Tickets As Imprimir = New Imprimir
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
        Tickets.AddSubHeaderLine("CTE: " & Cte, 0, 3)
        Tickets.AddSubHeaderLine("LE ATENDIO: " & Usu, 0, 1)
        Tickets.AddSubHeaderLine(DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToShortTimeString(), 0, 1)

        Dim dtRef As DataTable = ModPOS.Recupera_Tabla("sp_recibo_enc", "@ABNClave", Abono)

        Tickets.AddSubHeaderBloqLine("REFERENCIA: " & dtRef.Rows(0)("Referencia"), 0, 1)
        Tickets.AddSubHeaderBloqLine("FORMA PAGO: " & dtRef.Rows(0)("Descripcion"), 0, 1)
        Tickets.AddSubHeaderBloqLine("IMPORTE: " & Format(CStr(ModPOS.Redondear(Importe, 2)), "Currency"), 0, 1)

        dtRef.Dispose()

        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
        'del producto y el tercero es el precio 
        Dim dtPagosDetalle As DataTable
        dtPagosDetalle = ModPOS.SiExisteRecupera("sp_recibo_detalle", "@ABNClave", Abono)

        If Not dtPagosDetalle Is Nothing Then
            Dim i As Integer = 0
            dPagos = dtPagosDetalle.Rows.Count()
            For i = 0 To dPagos - 1
                Dim sFolio As String = dtPagosDetalle.Rows(i)("Folio")
                Dim sTipo As String = dtPagosDetalle.Rows(i)("Tipo")
                Dim dImporte As Double = dtPagosDetalle.Rows(i)("Importe")


                ' AGREGAR PAGOS A LISTA
                Tickets.AddItemRecibo(sFolio, sTipo, dImporte)

                dTotalPagos += (dImporte)
            Next
            dtPagosDetalle.Dispose()
        End If

        'El metodo AddTotalRecibo requiere 4 parametros 
        '  Tickets.AddTotalRecibo(dTotalPagos, 0, 0, 1)
        Tickets.AddFooterLine("TOTAL APLICADO: " & Format(CStr(ModPOS.Redondear(dTotalPagos, 2)), "Currency"), 1, 2)
        Tickets.AddFooterLine("CAMBIO: " & Format(CStr(ModPOS.Redondear(Cambio, 2)), "Currency"), 0, 2)

        'El metodo AddFooterLine funciona igual que la cabecera 

        Dim dtPieTicket As DataTable
        dtPieTicket = ModPOS.SiExisteRecupera("sp_filtra_pie", "@TIKClave", Ticket)

        If Not dtPieTicket Is Nothing Then
            Dim i As Integer
            For i = 0 To dtPieTicket.Rows.Count - 1
                Tickets.AddFooterLine(CStr(dtPieTicket.Rows(i)("Texto")), Math.Abs(CInt(dtPieTicket.Rows(i)("Negrita"))), CInt(dtPieTicket.Rows(i)("Alinear")))
            Next
            dtPieTicket.Dispose()
        End If

        'Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        'parametro de tipo string que debe de ser el nombre de la impresora. 
        Tickets.PrintTicket(Impresora, 70, 0)

    End Function

    Private Sub TxtFolio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFolio.KeyPress

        If Asc(e.KeyChar) = 13 Then
            AgregarFolio(False, TxtFolio.Text.Trim.ToUpper.Replace("'", "''"))
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

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If dtDetalle.Rows.Count > 0 Then

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


                Dim i As Integer
                Dim Efectivo, ImporteDevolver As Decimal


                If ActivaDevolucion Then

                    foundRows = dtDetalle.Select("Devolver > 0 and Disp >= Devolver")
                    For i = 0 To foundRows.Length - 1
                        ImporteDevolver += foundRows(i)("Importe") * foundRows(i)("TipoCambio")
                    Next

                    Dim a As New MeAutorizacion
                    a.Sucursal = SUCClave
                    a.MontodeAutorizacion = ImporteDevolver
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
                If Stage <> "" Then
                    Dim dtU As DataTable = ModPOS.Recupera_Tabla("sp_recupera_ubicacion", "@UBCClave", Stage)
                    EstadoUBC = CInt(dtU.Rows(0)("Estado"))
                    dtU.Dispose()
                End If

                Dim Ref, FolioDevolucion As String

                Dim dSubtotal, dImpuesto, dDescuento As Decimal

                Dim dAplica As Decimal = 0



                'Crea Vale
                If TallaColor = 1 Then
                    VALClave = obtenerLlave()

                    dt = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 13, "@PDVClave", CAJClave)
                    If dt Is Nothing Then
                        ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 13, "@PDVClave", CAJClave)
                        Folio = 1
                        Periodo = Today.Year
                        Mes = Today.Month
                    Else
                        Folio = CInt(dt.Rows(0)("UltimoConsecutivo")) + 1
                        Periodo = dt.Rows(0)("Periodo")
                        Mes = dt.Rows(0)("Mes")
                        ModPOS.Ejecuta("sp_act_folio", "@Tipo", 13, "@PDVClave", CAJClave, "@Incremento", 1)
                        dt.Dispose()
                    End If

                    Dim FolioVale As String = "VL" & Referencia & CStr(Periodo) & CStr(Mes) & "-" & CStr(Folio)

                    ModPOS.Ejecuta("st_crea_Vale", _
                                     "@VALClave", VALClave, _
                                     "@CTEClave", dtDetalle.Rows(0)("Cliente"), _
                                     "@Folio", FolioVale, _
                                     "@CAJClave", CAJClave, _
                                     "@Usuario", ModPOS.UsuarioActual, _
                                     "@MONClave", Moneda, _
                                     "@TipoCambio", 1)
                End If



                For i = 0 To dtVenta.Rows.Count - 1
                    ' Por cada venta genera una Devolucion 

                    dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", IIf(dtVenta.Rows(i)("MONClave").GetType.Name = "DBNull", Moneda, dtVenta.Rows(i)("MONClave")))
                    MonedaRef = dt.Rows(0)("Referencia")
                    MonedaDesc = dt.Rows(0)("Descripcion")
                    dt.Dispose()

                    dt = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 2, "@PDVClave", CAJClave)
                    If dt Is Nothing Then
                        ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 2, "@PDVClave", CAJClave)
                        Folio = 1
                        Periodo = Today.Year
                        Mes = Today.Month
                    Else
                        Folio = CInt(dt.Rows(0)("UltimoConsecutivo")) + 1
                        Periodo = dt.Rows(0)("Periodo")
                        Mes = dt.Rows(0)("Mes")
                        ModPOS.Ejecuta("sp_act_folio", "@Tipo", 2, "@PDVClave", CAJClave, "@Incremento", 1)
                        dt.Dispose()
                    End If

                    DEVClave = ModPOS.obtenerLlave

                    FolioDevolucion = "DV" & Referencia & CStr(Periodo) & CStr(Mes) & "-" & CStr(Folio)

                    foundRows = dtDetalle.Select("VENClave ='" & dtVenta.Rows(i)("VENClave") & "' and Devolver > 0")
                   

                    If dtVenta.Rows(i)("FACClave") <> "" Then
                        'Devolucion Facturada

                        ModPOS.Ejecuta("sp_crea_devolucion", _
                                    "@DEVClave", DEVClave, _
                                    "@Tipo", 2, _
                                    "@FACClave", dtVenta.Rows(i)("FACClave"), _
                                    "@VENClave", dtVenta.Rows(i)("VENClave"), _
                                    "@Referencia", dtDetalle.Rows(i)("Folio"), _
                                    "@CTEClave", dtDetalle.Rows(0)("Cliente"), _
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
                                    "@VALClave", VALClave)

                     
                    Else
                        'Devolucion Convencional = 1
                        

                        ModPOS.Ejecuta("sp_crea_devolucion", _
                                    "@DEVClave", DEVClave, _
                                    "@Tipo", 1, _
                                    "@VENClave", dtVenta.Rows(i)("VENClave"), _
                                    "@Referencia", dtDetalle.Rows(i)("Folio"), _
                                    "@CTEClave", dtDetalle.Rows(0)("Cliente"), _
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
                                    "@VALClave", VALClave)

                    End If

                    Ref = ModPOS.obtenerLlave

                    For j = 0 To foundRows.Length - 1
                        ModPOS.Ejecuta("sp_actualiza_cantdev", "@Tipo", 1, "@Documento", foundRows(j)("VENClave"), "@Partida", foundRows(j)("DVEClave"), "@Cantidad", foundRows(j)("Devolver"))

                        dSubtotal = Math.Round(foundRows(j)("PrecioBruto") * foundRows(j)("Devolver"), 2)
                        dDescuento = Math.Round(dSubtotal * foundRows(j)("PorcDesc"), 2)
                        dImpuesto = Math.Round((dSubtotal - dDescuento) * foundRows(j)("PorcImp"), 2)

                        ModPOS.Ejecuta("sp_inserta_devdet", _
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


                        If Stage <> "" Then
                            dt = Recupera_Tabla("st_recupera_peu", "@PROClave", foundRows(j)("PROClave"), "@UBCClave", Stage)
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

                    ModPOS.Ejecuta("sp_actualiza_devolucion", "@DEVClave", DEVClave)

                    dt = ModPOS.Recupera_Tabla("sp_encabezado_dev", "@DEVClave", DEVClave)
                    TotalDevolucion = dt.Rows(0)("Total")
                    dt.Dispose()


                    If dtVenta.Rows(i)("FACClave") <> "" Then
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
                            ModPOS.Ejecuta("sp_actualiza_saldo_doc", "@Tipo", 1, "@Documento", dtVenta.Rows(i)("VENClave"), "@Importe", dAplica * dtVenta.Rows(i)("TipoCambio"))

                            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("Cliente"), "@Importe", dAplica * dtVenta.Rows(i)("TipoCambio"))

                        Else
                            dAplica = 0
                            ImporteReembolso += (TotalDevolucion * dtVenta.Rows(i)("TipoCambio"))
                        End If
                        dt.Dispose()


                    End If

                    ModPOS.Ejecuta("st_actualiza_dev", "@DEVClave", DEVClave, "@Importe", dAplica)

                    If Stage = "" Then
                        ModPOS.GeneraMovInv(1, 3, 3, DEVClave, ALMClave, FolioDevolucion, Autoriza)
                    Else
                        ModPOS.GeneraMovInv(1, 3, 3, DEVClave, ALMClave, FolioDevolucion, Autoriza, 1, Stage)

                        If CambioEstado = True AndAlso InterfazSalida <> "" Then


                            For j = 0 To dtBloqueados.Rows.Count - 1

                                ModPOS.Ejecuta("st_act_bloqueado_ubc", _
                                                 "@UBCClave", Stage, _
                                                 "@PROClave", dtBloqueados.Rows(i)("PROClave"), _
                                                 "@Cantidad", dtBloqueados.Rows(i)("Bloquear"))


                                ModPOS.Ejecuta("st_cambio_estado", _
                                            "@SUCClave", SUCClave, _
                                            "@ALMClave", ALMClave, _
                                            "@UBCClave", Stage, _
                                            "@PROClave", dtBloqueados.Rows(i)("PROClave"), _
                                            "@Cantidad", dtBloqueados.Rows(i)("Bloquear"), _
                                            "@Estado", EstadoPEU, _
                                            "@Referencia", Referencia, _
                                            "@Actualiza", 1, _
                                            "@Usuario", ModPOS.UsuarioActual)

                            Next

                            Dim dtInterfaz As DataTable
                            Dim sFecha As String

                            sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                            dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CambioEstado", "@COMClave", ModPOS.CompanyActual)
                            If dtInterfaz.Rows.Count > 0 Then
                                ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", Referencia, "@TipoDocumento", 0, "@Path", InterfazSalida, "@Fecha", sFecha)
                            End If
                        End If

                    End If


                    If TallaColor = 0 Then

                        imprimeDevolucion(DEVClave, Impresora, TicketDev, reciboTicket, ImpresoraFac, MonedaDesc, MonedaRef, 1, True)


                        Dim StopPrint As Boolean = False
                        Do
                            Select Case MessageBox.Show("¿Desea Reimprimir el Ticket de Devolución", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                Case DialogResult.Yes
                                    imprimeDevolucion(DEVClave, Impresora, TicketDev, reciboTicket, ImpresoraFac, MonedaDesc, MonedaRef, 1, True)
                                Case Else
                                    StopPrint = True
                            End Select
                        Loop While Not StopPrint

                        ' reembolso


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

                            If dEfectivo >= (TotalDevolucion - dAplica) Then


                                Select Case MessageBox.Show("¿Desea aplicar un reembolso por " & Format(CStr(ModPOS.Redondear(Efectivo, 2)), "Currency") & " " & MonedaRef & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                    Case DialogResult.Yes
                                        ModPOS.Ejecuta("st_aplica_reembolso", _
                                                       "@CTEClave", foundRows(0)("Cliente"), _
                                                       "@DOCClave", DEVClave, _
                                                       "@TipoDocumento", 5, _
                                                       "@CAJClave", CAJClave, _
                                                       "@Moneda", IIf(foundRows(0)("MONClave").GetType.Name = "DBNull", Moneda, foundRows(0)("MONClave")), _
                                                       "@TipoCambio", foundRows(0)("TipoCambio"), _
                                                       "@Saldo", (TotalDevolucion - dAplica), _
                                                       "@Usuario", ModPOS.UsuarioActual)
                                        If Cajon = True Then
                                            AbrirCajon(Impresora)
                                        End If
                                End Select
                            End If
                        End If
                    Else
                        If TipoSucursal = 5 Then
                            'Crea Traspaso a Sucursal
                            ModPOS.Ejecuta("st_crea_traslado_aut", "@DEVClave", DEVClave, "@SUCClave", SUCClave, "@ALMClave", ALMClave, "@UBCClave", Stage, "@SUCDestino", SUCClavePadre, "@CLAClave", -1, "@Usuario", ModPOS.UsuarioActual)
                        Else
                            'Crea un traspaso por cada grupo de material que se encuentre a un posible destino diferente
                            Dim dtGrupo As DataTable = ModPOS.Recupera_Tabla("st_muestra_sucursaltraslado", "@SUCClave", SUCClave)
                            Dim k As Integer
                            For k = 0 To dtGrupo.Rows.Count - 1
                                ModPOS.Ejecuta("st_crea_traslado_aut", "@DEVClave", DEVClave, "@SUCClave", SUCClave, "@ALMClave", ALMClave, "@UBCClave", Stage, "@SUCDestino", dtGrupo.Rows(k)("Traslado"), "@CLAClave", dtGrupo.Rows(k)("Grupo"), "@Usuario", ModPOS.UsuarioActual)
                            Next
                        End If
                    End If
                Next

                If TallaColor = 1 Then

                    Dim ImporteCargo As Decimal = 0
                    Dim SaldoCargo As Decimal

                    Select Case MessageBox.Show("¿Desea agregar un Cargo a la Devolución?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.Yes
                            Dim cr As New FrmCargo
                            cr.VALClave = Me.VALClave
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

                    If ImporteCargo <= ImporteReembolso Then
                        ImporteReembolso -= ImporteCargo
                        SaldoCargo = 0
                    Else
                        SaldoCargo = ImporteCargo - ImporteReembolso
                        ImporteReembolso = 0
                    End If
                    'Crear Vale

                    ModPOS.Ejecuta("st_act_vale", _
                                              "@VALClave", VALClave, _
                                              "@Total", ImporteReembolso)




                    imprimeVale(VALClave, Impresora, TicketDev)



                   



                End If

                dtDetalle.Dispose()

              




                Me.Close()
            Else
                MessageBox.Show("Debe indicar una cantidad a devolver mayor o igual al disponible", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("No se encontraron productos a devolver en el documento actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        Else
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
                    a.sModelo = dtModelo.Rows(0)("Modelo")
                    a.ALMClave = ALMClave
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        Codigo = a.Clave
                    End If
                    dtModelo.Dispose()
                End If
            End If


            dt = ModPOS.SiExisteRecupera("sp_compra_producto", "@COMClave", ModPOS.CompanyActual, "@Clave", Codigo.Replace("'", "''"), "@Char", cReplace)


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


                dt = ModPOS.Recupera_Tabla("st_recupera_producto_dev", "@CONCENTRA", 0, "@SUCClave", SUCClave, "@CTEClave", CTEClave, "@PROClave", PROClave, "@Criterio", DiasMaxDev)


                'Si debe buscar en concentrador
                If dt.Rows.Count = 0 AndAlso DevConcentra = 1 AndAlso IPConcentrador <> "" Then
                    Dim frmstatusmessage As frmStatus = Nothing

                    frmstatusmessage = New frmStatus
                    frmstatusmessage.Show("Buscando en Concentrador...")


                    Dim ip As System.Net.IPAddress = System.Net.IPAddress.Parse(IPConcentrador)
                    Dim ping As System.Net.NetworkInformation.Ping = New System.Net.NetworkInformation.Ping()

                    Dim pr As System.Net.NetworkInformation.PingReply = ping.Send(ip)
                    If pr.Status.ToString() = "Success" Then

                        dt = ModPOS.Recupera_Tabla("st_recupera_producto_dev", "@CONCENTRA", 1, "@SUCClave", SUCClave, "@CTEClave", CTEClave, "@PROClave", PROClave, "@Criterio", DiasMaxDev)

                    Else
                        MsgBox("No se puede conectar al Servidor " & IPConcentrador, MsgBoxStyle.Information, "Error")

                    End If

                    frmstatusmessage.Close()

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


                            If CDate(dt.Rows(i)("Fecha")) < Today.Date.AddDays(-30) Then

                                MessageBox.Show("El Producto que desea devolver cuenta con más de 30 dias de haberlo comprado, requiere autorización para continuar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
 
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

                            End If


                            foundRows2 = dtVenta.Select("VENClave = '" & dt.Rows(i)("VENClave") & "'")

                            If foundRows2.Length = 0 Then
                                row1 = dtVenta.NewRow()
                                row1.Item("FACClave") = dt.Rows(i)("FACClave")
                                row1.Item("VENClave") = dt.Rows(i)("VENClave")
                                row1.Item("MONClave") = dt.Rows(i)("MONClave")
                                row1.Item("TipoCambio") = dt.Rows(i)("TipoCambio")
                                row1.Item("Saldo") = dt.Rows(i)("Saldo")
                                dtVenta.Rows.Add(row1)
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

                            ' Recupera Proveedor 
                            If bDefecto = True Then

                                Dim dtPrv As DataTable

                                dtPrv = ModPOS.Recupera_Tabla("st_recupera_prvprod", "@PROClave", PROClave)

                                If dtPrv.Rows.Count = 0 Then
                                    PRVClave = "NA"
                                ElseIf dtPrv.Rows.Count = 1 Then
                                    PRVClave = dtPrv.Rows(0)("PRVClave")
                                Else
                                    Do
                                        Dim a As New FrmConsulta
                                        a.Text = "Selección de Proveedor"
                                        a.Campo = "PRVClave"
                                        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_recupera_prvprod", "@PROClave", PROClave)
                                        a.GridConsultaGen.RootTable.Columns("PRVClave").Visible = False
                                        a.ShowDialog()
                                        If a.DialogResult = DialogResult.OK Then
                                            If a.ID <> "" Then
                                                PRVClave = a.ID
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


                            row1 = dtDetalle.NewRow()
                            'declara el nombre de la fila
                            row1.Item("FACClave") = dt.Rows(i)("FACClave")
                            row1.Item("Saldo") = dt.Rows(i)("Saldo")
                            row1.Item("VENClave") = dt.Rows(i)("VENClave")
                            row1.Item("DVEClave") = dt.Rows(i)("DVEClave")
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
                            row1.Item("Precio") = dt.Rows(i)("Precio")
                            row1.Item("Importe") = Devolver * dt.Rows(i)("Precio")
                            row1.Item("Costo") = dt.Rows(i)("Costo")
                            row1.Item("PrecioBruto") = dt.Rows(i)("PrecioBruto")
                            row1.Item("PorcImp") = dt.Rows(i)("PorcImp")
                            row1.Item("PorcDesc") = dt.Rows(i)("PorcDesc")
                            row1.Item("PuntosImp") = dt.Rows(i)("Puntosimp")
                            row1.Item("Cliente") = dt.Rows(i)("Cliente")
                            row1.Item("MONClave") = dt.Rows(i)("MONClave")
                            row1.Item("TipoCambio") = dt.Rows(i)("TipoCambio")
                            row1.Item("PRVClave") = PRVClave

                            dtDetalle.Rows.Add(row1)

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
        a.ProcedimientoAlmacenado = "sp_search_prod"
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
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
                Dim dt As DataTable
                dt = ModPOS.SiExisteRecupera("sp_recupera_clavecte", "@Clave", txtCliente.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
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
            AgregarFolio(True)
        End If
    End Sub

    Private Sub rbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rbCliente.CheckedChanged
        If rbCliente.Checked Then

            rbCliente.Checked = True
            txtCliente.Enabled = True
            txtProducto.Enabled = True
            btnCliente.Enabled = True
            btnProducto.Enabled = True
            TxtCantidad.Enabled = True
            TxtCantidad.Text = "1"

            TxtFolio.Enabled = False
            btnFolio.Enabled = False
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
            If CDbl(TxtCantidad.Text) = 0 Then
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

End Class
