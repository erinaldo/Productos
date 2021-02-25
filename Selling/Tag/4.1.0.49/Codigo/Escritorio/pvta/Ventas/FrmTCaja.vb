Imports CrystalDecisions.CrystalReports.Engine
Imports System.Net
Imports System.Net.Mail
Imports System.IO

Public Class FrmTCaja
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
    Friend WithEvents LblCaja As System.Windows.Forms.Label
    Friend WithEvents LblAtiende As System.Windows.Forms.Label
    Friend WithEvents LblDescripcion As System.Windows.Forms.Label
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents BtnPago As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnRecibo As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnDevolucion As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents BtnFacturar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnNC As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnRetiro As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCambio As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAuditoria As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiTab1 As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabGeneral As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabCXC As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpSaldos As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents NumSaldo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents LblCredito As System.Windows.Forms.Label
    Friend WithEvents NumDisponible As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents GridSaldos As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpMetodos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridMetodos As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnElimina As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModifica As Janus.Windows.EditControls.UIButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GridCreditos As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpTickets As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnRefresh As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents LblSaldo As System.Windows.Forms.Label
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridCxC As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiTabPendientes As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpPendientes As System.Windows.Forms.GroupBox
    Friend WithEvents GridPendientes As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnRegenerar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCertificar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoTrans As Selling.StoreCombo
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents btnCancelaPendiente As Janus.Windows.EditControls.UIButton
    Friend WithEvents picKeyboard As System.Windows.Forms.PictureBox
    Friend WithEvents UiTabContrarecibos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents dtPickerContrarecibo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbEdoContrarecibo As Selling.StoreCombo
    Friend WithEvents GridContrarecibos As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnEditContrarecibo As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAddContrarecibo As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnNotaCargo As Janus.Windows.EditControls.UIButton
    Friend WithEvents chkIncluir As System.Windows.Forms.CheckBox
    Friend WithEvents BtnConsultar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnReembolso As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnMasiva As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnReenvio As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAcumulado As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCorte As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents btnPrint As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents lblMonedaCambio As System.Windows.Forms.Label
    Friend WithEvents BtnGlobal As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiTabClientes As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents grpClientes As System.Windows.Forms.GroupBox
    Friend WithEvents gridClientes As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnEdoCta As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbCampo As Selling.StoreCombo
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents btnCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents Clock2 As System.Windows.Forms.Timer
    Friend WithEvents btnVerificador As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnNota As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCerrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiTabComplementoPago As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents grpComplementoPago As System.Windows.Forms.GroupBox
    Friend WithEvents btnCertificaPago As Janus.Windows.EditControls.UIButton
    Friend WithEvents chkCompTodos As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbCompFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents gridComplementoPago As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnPrintCompl As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSendCompl As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnActCxC As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnPedido As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnServicios As Janus.Windows.EditControls.UIButton
    Friend WithEvents CtxDocumentos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ItemTarjetaAmiga As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UiTabAbonos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabApartados As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents grpApartados As System.Windows.Forms.GroupBox
    Friend WithEvents btnActApartados As Janus.Windows.EditControls.UIButton
    Friend WithEvents gridApartados As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnApartados As Janus.Windows.EditControls.UIButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelarAbono As Janus.Windows.EditControls.UIButton
    Friend WithEvents gridAbonos As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnAbono As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbFiltro As Selling.StoreCombo
    Friend WithEvents btnAnticipo As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnConsultaAbn As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCompInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnOtroPago As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnConsultaNC As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnNuevo As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnPreventa As Janus.Windows.EditControls.UIButton
    Friend WithEvents RecargaTelefonicaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnComision As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTCaja))
        Me.LblCaja = New System.Windows.Forms.Label()
        Me.LblAtiende = New System.Windows.Forms.Label()
        Me.LblDescripcion = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.BtnPago = New Janus.Windows.EditControls.UIButton()
        Me.BtnRetiro = New Janus.Windows.EditControls.UIButton()
        Me.BtnAuditoria = New Janus.Windows.EditControls.UIButton()
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton()
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabGeneral = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpTickets = New System.Windows.Forms.GroupBox()
        Me.btnNuevo = New Janus.Windows.EditControls.UIButton()
        Me.BtnOtroPago = New Janus.Windows.EditControls.UIButton()
        Me.lblMonedaCambio = New System.Windows.Forms.Label()
        Me.btnPedido = New Janus.Windows.EditControls.UIButton()
        Me.BtnNota = New Janus.Windows.EditControls.UIButton()
        Me.chkIncluir = New System.Windows.Forms.CheckBox()
        Me.picKeyboard = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.btnReembolso = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnReenvio = New Janus.Windows.EditControls.UIButton()
        Me.LblTipoCambio = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnMasiva = New Janus.Windows.EditControls.UIButton()
        Me.btnNotaCargo = New Janus.Windows.EditControls.UIButton()
        Me.cmbTipoTrans = New Selling.StoreCombo()
        Me.BtnRefresh = New Janus.Windows.EditControls.UIButton()
        Me.BtnConsultar = New Janus.Windows.EditControls.UIButton()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.LblSaldo = New System.Windows.Forms.Label()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridCxC = New Janus.Windows.GridEX.GridEX()
        Me.BtnDevolucion = New Janus.Windows.EditControls.UIButton()
        Me.BtnFacturar = New Janus.Windows.EditControls.UIButton()
        Me.BtnNC = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.UiTabAbonos = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnAnticipo = New Janus.Windows.EditControls.UIButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CmbFecha = New System.Windows.Forms.DateTimePicker()
        Me.TxtBusqueda = New System.Windows.Forms.TextBox()
        Me.btnAbono = New Janus.Windows.EditControls.UIButton()
        Me.btnCancelarAbono = New Janus.Windows.EditControls.UIButton()
        Me.gridAbonos = New Janus.Windows.GridEX.GridEX()
        Me.BtnRecibo = New Janus.Windows.EditControls.UIButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CmbFiltro = New Selling.StoreCombo()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.UiTabCXC = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnActCxC = New Janus.Windows.EditControls.UIButton()
        Me.GridCreditos = New Janus.Windows.GridEX.GridEX()
        Me.UiTabComplementoPago = New Janus.Windows.UI.Tab.UITabPage()
        Me.grpComplementoPago = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCompInicial = New System.Windows.Forms.DateTimePicker()
        Me.btnConsultaAbn = New Janus.Windows.EditControls.UIButton()
        Me.btnPrintCompl = New Janus.Windows.EditControls.UIButton()
        Me.btnSendCompl = New Janus.Windows.EditControls.UIButton()
        Me.btnCertificaPago = New Janus.Windows.EditControls.UIButton()
        Me.chkCompTodos = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbCompFinal = New System.Windows.Forms.DateTimePicker()
        Me.gridComplementoPago = New Janus.Windows.GridEX.GridEX()
        Me.UiTabPendientes = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpPendientes = New System.Windows.Forms.GroupBox()
        Me.btnCancelaPendiente = New Janus.Windows.EditControls.UIButton()
        Me.btnRegenerar = New Janus.Windows.EditControls.UIButton()
        Me.GridPendientes = New Janus.Windows.GridEX.GridEX()
        Me.btnCertificar = New Janus.Windows.EditControls.UIButton()
        Me.UiTabContrarecibos = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnPrint = New Janus.Windows.EditControls.UIButton()
        Me.ChkTodos = New System.Windows.Forms.CheckBox()
        Me.btnEditContrarecibo = New Janus.Windows.EditControls.UIButton()
        Me.btnAddContrarecibo = New Janus.Windows.EditControls.UIButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtPickerContrarecibo = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GridContrarecibos = New Janus.Windows.GridEX.GridEX()
        Me.cmbEdoContrarecibo = New Selling.StoreCombo()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.UiTabClientes = New Janus.Windows.UI.Tab.UITabPage()
        Me.grpClientes = New System.Windows.Forms.GroupBox()
        Me.btnConsultaNC = New Janus.Windows.EditControls.UIButton()
        Me.btnCliente = New Janus.Windows.EditControls.UIButton()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.BtnEdoCta = New Janus.Windows.EditControls.UIButton()
        Me.gridClientes = New Janus.Windows.GridEX.GridEX()
        Me.CmbCampo = New Selling.StoreCombo()
        Me.UiTabApartados = New Janus.Windows.UI.Tab.UITabPage()
        Me.grpApartados = New System.Windows.Forms.GroupBox()
        Me.btnApartados = New Janus.Windows.EditControls.UIButton()
        Me.btnActApartados = New Janus.Windows.EditControls.UIButton()
        Me.gridApartados = New Janus.Windows.GridEX.GridEX()
        Me.GrpSaldos = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.NumSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.LblCredito = New System.Windows.Forms.Label()
        Me.NumDisponible = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.GridSaldos = New Janus.Windows.GridEX.GridEX()
        Me.GrpMetodos = New System.Windows.Forms.GroupBox()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GridMetodos = New Janus.Windows.GridEX.GridEX()
        Me.BtnElimina = New Janus.Windows.EditControls.UIButton()
        Me.BtnModifica = New Janus.Windows.EditControls.UIButton()
        Me.BtnComision = New Janus.Windows.EditControls.UIButton()
        Me.BtnCambio = New Janus.Windows.EditControls.UIButton()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.btnAcumulado = New Janus.Windows.EditControls.UIButton()
        Me.btnCorte = New Janus.Windows.EditControls.UIButton()
        Me.BtnGlobal = New Janus.Windows.EditControls.UIButton()
        Me.Clock2 = New System.Windows.Forms.Timer(Me.components)
        Me.btnVerificador = New Janus.Windows.EditControls.UIButton()
        Me.BtnCerrar = New Janus.Windows.EditControls.UIButton()
        Me.btnServicios = New Janus.Windows.EditControls.UIButton()
        Me.CtxDocumentos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ItemTarjetaAmiga = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecargaTelefonicaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPreventa = New Janus.Windows.EditControls.UIButton()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabGeneral.SuspendLayout()
        Me.GrpTickets.SuspendLayout()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCxC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabAbonos.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.gridAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabCXC.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridCreditos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabComplementoPago.SuspendLayout()
        Me.grpComplementoPago.SuspendLayout()
        CType(Me.gridComplementoPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabPendientes.SuspendLayout()
        Me.GrpPendientes.SuspendLayout()
        CType(Me.GridPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabContrarecibos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridContrarecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabClientes.SuspendLayout()
        Me.grpClientes.SuspendLayout()
        CType(Me.gridClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabApartados.SuspendLayout()
        Me.grpApartados.SuspendLayout()
        CType(Me.gridApartados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpSaldos.SuspendLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpMetodos.SuspendLayout()
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CtxDocumentos.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblCaja
        '
        Me.LblCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCaja.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblCaja.Location = New System.Drawing.Point(17, 9)
        Me.LblCaja.Name = "LblCaja"
        Me.LblCaja.Size = New System.Drawing.Size(54, 15)
        Me.LblCaja.TabIndex = 5
        Me.LblCaja.Text = "CAJA"
        '
        'LblAtiende
        '
        Me.LblAtiende.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAtiende.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblAtiende.Location = New System.Drawing.Point(17, 37)
        Me.LblAtiende.Name = "LblAtiende"
        Me.LblAtiende.Size = New System.Drawing.Size(81, 15)
        Me.LblAtiende.TabIndex = 6
        Me.LblAtiende.Text = "ATIENDE"
        '
        'LblDescripcion
        '
        Me.LblDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescripcion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblDescripcion.Location = New System.Drawing.Point(99, 6)
        Me.LblDescripcion.Name = "LblDescripcion"
        Me.LblDescripcion.Size = New System.Drawing.Size(366, 22)
        Me.LblDescripcion.TabIndex = 7
        Me.LblDescripcion.Text = "Folio"
        Me.LblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblUsuario
        '
        Me.LblUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblUsuario.Location = New System.Drawing.Point(99, 33)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(366, 23)
        Me.LblUsuario.TabIndex = 8
        Me.LblUsuario.Text = "Folio"
        Me.LblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'BtnPago
        '
        Me.BtnPago.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPago.Icon = CType(resources.GetObject("BtnPago.Icon"), System.Drawing.Icon)
        Me.BtnPago.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnPago.Location = New System.Drawing.Point(530, 45)
        Me.BtnPago.Name = "BtnPago"
        Me.BtnPago.Size = New System.Drawing.Size(83, 30)
        Me.BtnPago.TabIndex = 1
        Me.BtnPago.Text = " Pagar"
        Me.BtnPago.ToolTipText = "Registrar Pago de registros seleccionados [F10]"
        Me.BtnPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnRetiro
        '
        Me.BtnRetiro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRetiro.Icon = CType(resources.GetObject("BtnRetiro.Icon"), System.Drawing.Icon)
        Me.BtnRetiro.ImageSize = New System.Drawing.Size(24, 24)
        Me.BtnRetiro.Location = New System.Drawing.Point(554, 62)
        Me.BtnRetiro.Name = "BtnRetiro"
        Me.BtnRetiro.Size = New System.Drawing.Size(90, 30)
        Me.BtnRetiro.TabIndex = 10
        Me.BtnRetiro.Text = "F5- Retiro"
        Me.BtnRetiro.ToolTipText = "Retiro de Caja"
        Me.BtnRetiro.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAuditoria
        '
        Me.BtnAuditoria.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAuditoria.Icon = CType(resources.GetObject("BtnAuditoria.Icon"), System.Drawing.Icon)
        Me.BtnAuditoria.Location = New System.Drawing.Point(2, 62)
        Me.BtnAuditoria.Name = "BtnAuditoria"
        Me.BtnAuditoria.Size = New System.Drawing.Size(90, 30)
        Me.BtnAuditoria.TabIndex = 17
        Me.BtnAuditoria.Text = "F3- Auditoria"
        Me.BtnAuditoria.ToolTipText = "Consulta de auditoria de pedidos o ventas"
        Me.BtnAuditoria.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnReimpresion
        '
        Me.BtnReimpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Icon = CType(resources.GetObject("BtnReimpresion.Icon"), System.Drawing.Icon)
        Me.BtnReimpresion.Location = New System.Drawing.Point(906, 45)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(43, 30)
        Me.BtnReimpresion.TabIndex = 18
        Me.BtnReimpresion.ToolTipText = "impresión de documentos seleccionados"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTab1
        '
        Me.UiTab1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTab1.FlatBorderColor = System.Drawing.Color.LightSteelBlue
        Me.UiTab1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiTab1.Location = New System.Drawing.Point(2, 98)
        Me.UiTab1.Name = "UiTab1"
        Me.UiTab1.Size = New System.Drawing.Size(1058, 461)
        Me.UiTab1.TabIndex = 21
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabGeneral, Me.UiTabAbonos, Me.UiTabCXC, Me.UiTabComplementoPago, Me.UiTabPendientes, Me.UiTabContrarecibos, Me.UiTabClientes, Me.UiTabApartados})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabGeneral
        '
        Me.UiTabGeneral.Controls.Add(Me.GrpTickets)
        Me.UiTabGeneral.Location = New System.Drawing.Point(1, 21)
        Me.UiTabGeneral.Name = "UiTabGeneral"
        Me.UiTabGeneral.Size = New System.Drawing.Size(1056, 439)
        Me.UiTabGeneral.TabStop = True
        Me.UiTabGeneral.Text = "General"
        '
        'GrpTickets
        '
        Me.GrpTickets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.btnNuevo)
        Me.GrpTickets.Controls.Add(Me.BtnOtroPago)
        Me.GrpTickets.Controls.Add(Me.lblMonedaCambio)
        Me.GrpTickets.Controls.Add(Me.btnPedido)
        Me.GrpTickets.Controls.Add(Me.BtnNota)
        Me.GrpTickets.Controls.Add(Me.chkIncluir)
        Me.GrpTickets.Controls.Add(Me.picKeyboard)
        Me.GrpTickets.Controls.Add(Me.Label4)
        Me.GrpTickets.Controls.Add(Me.PictureBox1)
        Me.GrpTickets.Controls.Add(Me.dtPicker)
        Me.GrpTickets.Controls.Add(Me.btnReembolso)
        Me.GrpTickets.Controls.Add(Me.PictureBox2)
        Me.GrpTickets.Controls.Add(Me.btnReenvio)
        Me.GrpTickets.Controls.Add(Me.LblTipoCambio)
        Me.GrpTickets.Controls.Add(Me.Label3)
        Me.GrpTickets.Controls.Add(Me.btnMasiva)
        Me.GrpTickets.Controls.Add(Me.btnNotaCargo)
        Me.GrpTickets.Controls.Add(Me.cmbTipoTrans)
        Me.GrpTickets.Controls.Add(Me.BtnRefresh)
        Me.GrpTickets.Controls.Add(Me.BtnReimpresion)
        Me.GrpTickets.Controls.Add(Me.BtnPago)
        Me.GrpTickets.Controls.Add(Me.BtnConsultar)
        Me.GrpTickets.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpTickets.Controls.Add(Me.LblSaldo)
        Me.GrpTickets.Controls.Add(Me.LblTotal)
        Me.GrpTickets.Controls.Add(Me.TxtFolio)
        Me.GrpTickets.Controls.Add(Me.Label1)
        Me.GrpTickets.Controls.Add(Me.GridCxC)
        Me.GrpTickets.Controls.Add(Me.BtnDevolucion)
        Me.GrpTickets.Controls.Add(Me.BtnFacturar)
        Me.GrpTickets.Controls.Add(Me.BtnNC)
        Me.GrpTickets.Controls.Add(Me.BtnCancelar)
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(2, 3)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(1052, 433)
        Me.GrpTickets.TabIndex = 2
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Cobranza General"
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevo.Icon = CType(resources.GetObject("btnNuevo.Icon"), System.Drawing.Icon)
        Me.btnNuevo.Location = New System.Drawing.Point(717, 45)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(43, 30)
        Me.btnNuevo.TabIndex = 95
        Me.btnNuevo.ToolTipText = "Crear un Pedido Nuevo"
        Me.btnNuevo.Visible = False
        Me.btnNuevo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnOtroPago
        '
        Me.BtnOtroPago.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOtroPago.Icon = CType(resources.GetObject("BtnOtroPago.Icon"), System.Drawing.Icon)
        Me.BtnOtroPago.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnOtroPago.Location = New System.Drawing.Point(617, 45)
        Me.BtnOtroPago.Name = "BtnOtroPago"
        Me.BtnOtroPago.Size = New System.Drawing.Size(83, 30)
        Me.BtnOtroPago.TabIndex = 94
        Me.BtnOtroPago.Text = "Aplica P."
        Me.BtnOtroPago.ToolTipText = "Aplica Ancipos, Vales o Notas de Crédito a los documentos seleccionados."
        Me.BtnOtroPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lblMonedaCambio
        '
        Me.lblMonedaCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMonedaCambio.BackColor = System.Drawing.Color.Transparent
        Me.lblMonedaCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonedaCambio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblMonedaCambio.Location = New System.Drawing.Point(327, 382)
        Me.lblMonedaCambio.Name = "lblMonedaCambio"
        Me.lblMonedaCambio.Size = New System.Drawing.Size(268, 20)
        Me.lblMonedaCambio.TabIndex = 93
        Me.lblMonedaCambio.Text = "$0.00 M.N"
        Me.lblMonedaCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblMonedaCambio.Visible = False
        '
        'btnPedido
        '
        Me.btnPedido.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPedido.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPedido.Icon = CType(resources.GetObject("btnPedido.Icon"), System.Drawing.Icon)
        Me.btnPedido.Location = New System.Drawing.Point(859, 45)
        Me.btnPedido.Name = "btnPedido"
        Me.btnPedido.Size = New System.Drawing.Size(43, 30)
        Me.btnPedido.TabIndex = 84
        Me.btnPedido.ToolTipText = "Modificar Pedido Seleccionado"
        Me.btnPedido.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnNota
        '
        Me.BtnNota.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNota.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNota.Icon = CType(resources.GetObject("BtnNota.Icon"), System.Drawing.Icon)
        Me.BtnNota.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnNota.Location = New System.Drawing.Point(765, 45)
        Me.BtnNota.Name = "BtnNota"
        Me.BtnNota.Size = New System.Drawing.Size(43, 30)
        Me.BtnNota.TabIndex = 82
        Me.BtnNota.ToolTipText = "Agregar nota a la venta seleccionada"
        Me.BtnNota.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chkIncluir
        '
        Me.chkIncluir.Location = New System.Drawing.Point(619, 20)
        Me.chkIncluir.Name = "chkIncluir"
        Me.chkIncluir.Size = New System.Drawing.Size(133, 19)
        Me.chkIncluir.TabIndex = 89
        Me.chkIncluir.Text = "Incluir cobrados"
        '
        'picKeyboard
        '
        Me.picKeyboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picKeyboard.BackColor = System.Drawing.Color.Transparent
        Me.picKeyboard.Image = Global.Selling.My.Resources.Resources._1403657593_519640_141_Keyboard
        Me.picKeyboard.Location = New System.Drawing.Point(7, 394)
        Me.picKeyboard.Name = "picKeyboard"
        Me.picKeyboard.Size = New System.Drawing.Size(35, 33)
        Me.picKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picKeyboard.TabIndex = 87
        Me.picKeyboard.TabStop = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(836, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "Periodo"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(110, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 19)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(898, 19)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(145, 20)
        Me.dtPicker.TabIndex = 85
        Me.dtPicker.Value = New Date(2015, 1, 27, 0, 0, 0, 0)
        '
        'btnReembolso
        '
        Me.btnReembolso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReembolso.Icon = CType(resources.GetObject("btnReembolso.Icon"), System.Drawing.Icon)
        Me.btnReembolso.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnReembolso.Location = New System.Drawing.Point(180, 45)
        Me.btnReembolso.Name = "btnReembolso"
        Me.btnReembolso.Size = New System.Drawing.Size(86, 30)
        Me.btnReembolso.TabIndex = 25
        Me.btnReembolso.Text = "Reembolso"
        Me.btnReembolso.ToolTipText = "Reembolso a cliente"
        Me.btnReembolso.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(299, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(22, 20)
        Me.PictureBox2.TabIndex = 84
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'btnReenvio
        '
        Me.btnReenvio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReenvio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReenvio.Icon = CType(resources.GetObject("btnReenvio.Icon"), System.Drawing.Icon)
        Me.btnReenvio.Location = New System.Drawing.Point(953, 45)
        Me.btnReenvio.Name = "btnReenvio"
        Me.btnReenvio.Size = New System.Drawing.Size(43, 30)
        Me.btnReenvio.TabIndex = 28
        Me.btnReenvio.ToolTipText = "Envia por correo electronico  los documentos seleccionados"
        Me.btnReenvio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTipoCambio.BackColor = System.Drawing.Color.Transparent
        Me.LblTipoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTipoCambio.ForeColor = System.Drawing.Color.Navy
        Me.LblTipoCambio.Location = New System.Drawing.Point(327, 409)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(268, 20)
        Me.LblTipoCambio.TabIndex = 78
        Me.LblTipoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(94, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 14)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "Tipo"
        '
        'btnMasiva
        '
        Me.btnMasiva.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMasiva.Icon = CType(resources.GetObject("btnMasiva.Icon"), System.Drawing.Icon)
        Me.btnMasiva.Location = New System.Drawing.Point(443, 45)
        Me.btnMasiva.Name = "btnMasiva"
        Me.btnMasiva.Size = New System.Drawing.Size(83, 30)
        Me.btnMasiva.TabIndex = 26
        Me.btnMasiva.Text = "F. Masiva"
        Me.btnMasiva.ToolTipText = "Crea un factura por cada documento seleccionado."
        Me.btnMasiva.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnNotaCargo
        '
        Me.btnNotaCargo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNotaCargo.Icon = CType(resources.GetObject("btnNotaCargo.Icon"), System.Drawing.Icon)
        Me.btnNotaCargo.Location = New System.Drawing.Point(269, 45)
        Me.btnNotaCargo.Name = "btnNotaCargo"
        Me.btnNotaCargo.Size = New System.Drawing.Size(83, 30)
        Me.btnNotaCargo.TabIndex = 23
        Me.btnNotaCargo.Text = "N. Cargo"
        Me.btnNotaCargo.ToolTipText = "Crear Nota de Cargo [F9]"
        Me.btnNotaCargo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbTipoTrans
        '
        Me.cmbTipoTrans.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoTrans.Location = New System.Drawing.Point(136, 18)
        Me.cmbTipoTrans.Name = "cmbTipoTrans"
        Me.cmbTipoTrans.Size = New System.Drawing.Size(139, 21)
        Me.cmbTipoTrans.TabIndex = 82
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Icon = CType(resources.GetObject("BtnRefresh.Icon"), System.Drawing.Icon)
        Me.BtnRefresh.Location = New System.Drawing.Point(502, 16)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(109, 21)
        Me.BtnRefresh.TabIndex = 50
        Me.BtnRefresh.Text = "F12 - Actualizar"
        Me.BtnRefresh.ToolTipText = "Actualizar"
        Me.BtnRefresh.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsultar.Icon = CType(resources.GetObject("BtnConsultar.Icon"), System.Drawing.Icon)
        Me.BtnConsultar.Location = New System.Drawing.Point(1000, 45)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(43, 30)
        Me.BtnConsultar.TabIndex = 24
        Me.BtnConsultar.ToolTipText = "Consultar documento"
        Me.BtnConsultar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(7, 20)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(76, 19)
        Me.ChkMarcaTodos.TabIndex = 49
        Me.ChkMarcaTodos.Text = "Todos"
        '
        'LblSaldo
        '
        Me.LblSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaldo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblSaldo.Location = New System.Drawing.Point(847, 390)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(197, 35)
        Me.LblSaldo.TabIndex = 48
        Me.LblSaldo.Text = "0.00"
        Me.LblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LblTotal.Location = New System.Drawing.Point(613, 398)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(229, 27)
        Me.LblTotal.TabIndex = 47
        Me.LblTotal.Text = "TOTAL A PAGAR"
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(325, 18)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(167, 21)
        Me.TxtFolio.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(281, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Folio"
        '
        'GridCxC
        '
        Me.GridCxC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCxC.ColumnAutoResize = True
        Me.GridCxC.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader
        Me.GridCxC.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCxC.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridCxC.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridCxC.GroupByBoxVisible = False
        Me.GridCxC.Location = New System.Drawing.Point(7, 81)
        Me.GridCxC.Name = "GridCxC"
        Me.GridCxC.RecordNavigator = True
        Me.GridCxC.Size = New System.Drawing.Size(1037, 298)
        Me.GridCxC.TabIndex = 4
        Me.GridCxC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnDevolucion
        '
        Me.BtnDevolucion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDevolucion.Icon = CType(resources.GetObject("BtnDevolucion.Icon"), System.Drawing.Icon)
        Me.BtnDevolucion.Location = New System.Drawing.Point(7, 45)
        Me.BtnDevolucion.Name = "BtnDevolucion"
        Me.BtnDevolucion.Size = New System.Drawing.Size(83, 30)
        Me.BtnDevolucion.TabIndex = 5
        Me.BtnDevolucion.Text = "Devolución"
        Me.BtnDevolucion.ToolTipText = "Crear Devolución [F4]"
        Me.BtnDevolucion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnFacturar
        '
        Me.BtnFacturar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFacturar.Icon = CType(resources.GetObject("BtnFacturar.Icon"), System.Drawing.Icon)
        Me.BtnFacturar.Location = New System.Drawing.Point(356, 45)
        Me.BtnFacturar.Name = "BtnFacturar"
        Me.BtnFacturar.Size = New System.Drawing.Size(83, 30)
        Me.BtnFacturar.TabIndex = 3
        Me.BtnFacturar.Text = "Facturar"
        Me.BtnFacturar.ToolTipText = "Crear nueva factura de registros seleccionados [F8]"
        Me.BtnFacturar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnNC
        '
        Me.BtnNC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNC.Icon = CType(resources.GetObject("BtnNC.Icon"), System.Drawing.Icon)
        Me.BtnNC.Location = New System.Drawing.Point(93, 45)
        Me.BtnNC.Name = "BtnNC"
        Me.BtnNC.Size = New System.Drawing.Size(83, 30)
        Me.BtnNC.TabIndex = 4
        Me.BtnNC.Text = "N. Crédito"
        Me.BtnNC.ToolTipText = "Crear Nota de Crédito de registro seleccionado [F7]"
        Me.BtnNC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(812, 45)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(43, 30)
        Me.BtnCancelar.TabIndex = 6
        Me.BtnCancelar.ToolTipText = "Cancela el Ticket o Factura"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTabAbonos
        '
        Me.UiTabAbonos.Controls.Add(Me.GroupBox3)
        Me.UiTabAbonos.Location = New System.Drawing.Point(1, 21)
        Me.UiTabAbonos.Name = "UiTabAbonos"
        Me.UiTabAbonos.Size = New System.Drawing.Size(1056, 439)
        Me.UiTabAbonos.TabStop = True
        Me.UiTabAbonos.Text = "Abonos y Anticipos"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox3.Controls.Add(Me.btnAnticipo)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.CmbFecha)
        Me.GroupBox3.Controls.Add(Me.TxtBusqueda)
        Me.GroupBox3.Controls.Add(Me.btnAbono)
        Me.GroupBox3.Controls.Add(Me.btnCancelarAbono)
        Me.GroupBox3.Controls.Add(Me.gridAbonos)
        Me.GroupBox3.Controls.Add(Me.BtnRecibo)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.CmbFiltro)
        Me.GroupBox3.Controls.Add(Me.PictureBox3)
        Me.GroupBox3.Controls.Add(Me.PictureBox4)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1052, 433)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Abonos y Anticipos"
        '
        'btnAnticipo
        '
        Me.btnAnticipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnticipo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnticipo.Icon = CType(resources.GetObject("btnAnticipo.Icon"), System.Drawing.Icon)
        Me.btnAnticipo.ImageSize = New System.Drawing.Size(24, 16)
        Me.btnAnticipo.Location = New System.Drawing.Point(846, 11)
        Me.btnAnticipo.Name = "btnAnticipo"
        Me.btnAnticipo.Size = New System.Drawing.Size(62, 30)
        Me.btnAnticipo.TabIndex = 81
        Me.btnAnticipo.ToolTipText = "Registrar Anticipo"
        Me.btnAnticipo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "Filtro"
        '
        'CmbFecha
        '
        Me.CmbFecha.CustomFormat = "yyyyMMdd"
        Me.CmbFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CmbFecha.Location = New System.Drawing.Point(419, 17)
        Me.CmbFecha.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.CmbFecha.Name = "CmbFecha"
        Me.CmbFecha.Size = New System.Drawing.Size(119, 20)
        Me.CmbFecha.TabIndex = 77
        Me.CmbFecha.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'TxtBusqueda
        '
        Me.TxtBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBusqueda.Location = New System.Drawing.Point(51, 16)
        Me.TxtBusqueda.Name = "TxtBusqueda"
        Me.TxtBusqueda.Size = New System.Drawing.Size(132, 21)
        Me.TxtBusqueda.TabIndex = 74
        '
        'btnAbono
        '
        Me.btnAbono.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbono.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAbono.Icon = CType(resources.GetObject("btnAbono.Icon"), System.Drawing.Icon)
        Me.btnAbono.Location = New System.Drawing.Point(778, 11)
        Me.btnAbono.Name = "btnAbono"
        Me.btnAbono.Size = New System.Drawing.Size(62, 30)
        Me.btnAbono.TabIndex = 52
        Me.btnAbono.ToolTipText = "Modifica Abono"
        Me.btnAbono.Visible = False
        Me.btnAbono.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnCancelarAbono
        '
        Me.btnCancelarAbono.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelarAbono.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelarAbono.Icon = CType(resources.GetObject("btnCancelarAbono.Icon"), System.Drawing.Icon)
        Me.btnCancelarAbono.Location = New System.Drawing.Point(982, 11)
        Me.btnCancelarAbono.Name = "btnCancelarAbono"
        Me.btnCancelarAbono.Size = New System.Drawing.Size(62, 30)
        Me.btnCancelarAbono.TabIndex = 21
        Me.btnCancelarAbono.ToolTipText = "Cancela el documento seleccionado"
        Me.btnCancelarAbono.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gridAbonos
        '
        Me.gridAbonos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridAbonos.ColumnAutoResize = True
        Me.gridAbonos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.gridAbonos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.gridAbonos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.gridAbonos.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.gridAbonos.GroupByBoxVisible = False
        Me.gridAbonos.Location = New System.Drawing.Point(7, 44)
        Me.gridAbonos.Name = "gridAbonos"
        Me.gridAbonos.RecordNavigator = True
        Me.gridAbonos.Size = New System.Drawing.Size(1037, 383)
        Me.gridAbonos.TabIndex = 4
        Me.gridAbonos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnRecibo
        '
        Me.BtnRecibo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRecibo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRecibo.Icon = CType(resources.GetObject("BtnRecibo.Icon"), System.Drawing.Icon)
        Me.BtnRecibo.Location = New System.Drawing.Point(914, 11)
        Me.BtnRecibo.Name = "BtnRecibo"
        Me.BtnRecibo.Size = New System.Drawing.Size(62, 30)
        Me.BtnRecibo.TabIndex = 2
        Me.BtnRecibo.ToolTipText = "Imprimir Recibo de registro seleccionado"
        Me.BtnRecibo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(364, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 79
        Me.Label9.Text = "Fecha"
        '
        'CmbFiltro
        '
        Me.CmbFiltro.BackColor = System.Drawing.SystemColors.Window
        Me.CmbFiltro.Location = New System.Drawing.Point(214, 16)
        Me.CmbFiltro.Name = "CmbFiltro"
        Me.CmbFiltro.Size = New System.Drawing.Size(140, 21)
        Me.CmbFiltro.TabIndex = 76
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(189, 17)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox3.TabIndex = 78
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(360, 17)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox4.TabIndex = 75
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'UiTabCXC
        '
        Me.UiTabCXC.Controls.Add(Me.GroupBox1)
        Me.UiTabCXC.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCXC.Name = "UiTabCXC"
        Me.UiTabCXC.Size = New System.Drawing.Size(1056, 439)
        Me.UiTabCXC.TabStop = True
        Me.UiTabCXC.Text = "Cuentas por Cobrar"
        Me.UiTabCXC.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox1.Controls.Add(Me.btnActCxC)
        Me.GroupBox1.Controls.Add(Me.GridCreditos)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(2, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1052, 430)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cobranza"
        '
        'btnActCxC
        '
        Me.btnActCxC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActCxC.Icon = CType(resources.GetObject("btnActCxC.Icon"), System.Drawing.Icon)
        Me.btnActCxC.Location = New System.Drawing.Point(981, 12)
        Me.btnActCxC.Name = "btnActCxC"
        Me.btnActCxC.Size = New System.Drawing.Size(62, 30)
        Me.btnActCxC.TabIndex = 51
        Me.btnActCxC.ToolTipText = "Actualizar"
        Me.btnActCxC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridCreditos
        '
        Me.GridCreditos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCreditos.ColumnAutoResize = True
        Me.GridCreditos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCreditos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCreditos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridCreditos.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridCreditos.GroupByBoxVisible = False
        Me.GridCreditos.Location = New System.Drawing.Point(7, 46)
        Me.GridCreditos.Name = "GridCreditos"
        Me.GridCreditos.RecordNavigator = True
        Me.GridCreditos.Size = New System.Drawing.Size(1037, 378)
        Me.GridCreditos.TabIndex = 4
        Me.GridCreditos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabComplementoPago
        '
        Me.UiTabComplementoPago.Controls.Add(Me.grpComplementoPago)
        Me.UiTabComplementoPago.Location = New System.Drawing.Point(1, 21)
        Me.UiTabComplementoPago.Name = "UiTabComplementoPago"
        Me.UiTabComplementoPago.Size = New System.Drawing.Size(1056, 439)
        Me.UiTabComplementoPago.TabStop = True
        Me.UiTabComplementoPago.Text = "Complemento de Pago"
        '
        'grpComplementoPago
        '
        Me.grpComplementoPago.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpComplementoPago.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpComplementoPago.Controls.Add(Me.Label2)
        Me.grpComplementoPago.Controls.Add(Me.cmbCompInicial)
        Me.grpComplementoPago.Controls.Add(Me.btnConsultaAbn)
        Me.grpComplementoPago.Controls.Add(Me.btnPrintCompl)
        Me.grpComplementoPago.Controls.Add(Me.btnSendCompl)
        Me.grpComplementoPago.Controls.Add(Me.btnCertificaPago)
        Me.grpComplementoPago.Controls.Add(Me.chkCompTodos)
        Me.grpComplementoPago.Controls.Add(Me.Label7)
        Me.grpComplementoPago.Controls.Add(Me.cmbCompFinal)
        Me.grpComplementoPago.Controls.Add(Me.gridComplementoPago)
        Me.grpComplementoPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpComplementoPago.ForeColor = System.Drawing.Color.Black
        Me.grpComplementoPago.Location = New System.Drawing.Point(2, 3)
        Me.grpComplementoPago.Name = "grpComplementoPago"
        Me.grpComplementoPago.Size = New System.Drawing.Size(1052, 433)
        Me.grpComplementoPago.TabIndex = 4
        Me.grpComplementoPago.TabStop = False
        Me.grpComplementoPago.Text = "Comprobantes de Pago"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(75, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 149
        Me.Label2.Text = "Inicial"
        '
        'cmbCompInicial
        '
        Me.cmbCompInicial.CustomFormat = "MMMM yyyy"
        Me.cmbCompInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbCompInicial.Location = New System.Drawing.Point(129, 19)
        Me.cmbCompInicial.Name = "cmbCompInicial"
        Me.cmbCompInicial.Size = New System.Drawing.Size(113, 20)
        Me.cmbCompInicial.TabIndex = 148
        '
        'btnConsultaAbn
        '
        Me.btnConsultaAbn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultaAbn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultaAbn.Icon = CType(resources.GetObject("btnConsultaAbn.Icon"), System.Drawing.Icon)
        Me.btnConsultaAbn.Location = New System.Drawing.Point(778, 10)
        Me.btnConsultaAbn.Name = "btnConsultaAbn"
        Me.btnConsultaAbn.Size = New System.Drawing.Size(62, 30)
        Me.btnConsultaAbn.TabIndex = 147
        Me.btnConsultaAbn.ToolTipText = "Consultar documento"
        Me.btnConsultaAbn.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnPrintCompl
        '
        Me.btnPrintCompl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintCompl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrintCompl.Icon = CType(resources.GetObject("btnPrintCompl.Icon"), System.Drawing.Icon)
        Me.btnPrintCompl.Location = New System.Drawing.Point(846, 10)
        Me.btnPrintCompl.Name = "btnPrintCompl"
        Me.btnPrintCompl.Size = New System.Drawing.Size(62, 30)
        Me.btnPrintCompl.TabIndex = 83
        Me.btnPrintCompl.ToolTipText = "impresión de documentos seleccionados"
        Me.btnPrintCompl.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnSendCompl
        '
        Me.btnSendCompl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSendCompl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSendCompl.Icon = CType(resources.GetObject("btnSendCompl.Icon"), System.Drawing.Icon)
        Me.btnSendCompl.Location = New System.Drawing.Point(914, 10)
        Me.btnSendCompl.Name = "btnSendCompl"
        Me.btnSendCompl.Size = New System.Drawing.Size(62, 30)
        Me.btnSendCompl.TabIndex = 146
        Me.btnSendCompl.ToolTipText = "envia por correo electronico los documentos seleccionados"
        Me.btnSendCompl.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnCertificaPago
        '
        Me.btnCertificaPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCertificaPago.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCertificaPago.Icon = CType(resources.GetObject("btnCertificaPago.Icon"), System.Drawing.Icon)
        Me.btnCertificaPago.Location = New System.Drawing.Point(982, 10)
        Me.btnCertificaPago.Name = "btnCertificaPago"
        Me.btnCertificaPago.Size = New System.Drawing.Size(62, 30)
        Me.btnCertificaPago.TabIndex = 145
        Me.btnCertificaPago.ToolTipText = "Realiza un reintento de certificación del documento seleccionado"
        Me.btnCertificaPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chkCompTodos
        '
        Me.chkCompTodos.Location = New System.Drawing.Point(7, 23)
        Me.chkCompTodos.Name = "chkCompTodos"
        Me.chkCompTodos.Size = New System.Drawing.Size(76, 19)
        Me.chkCompTodos.TabIndex = 143
        Me.chkCompTodos.Text = "Todos"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(248, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 86
        Me.Label7.Text = "Final"
        '
        'cmbCompFinal
        '
        Me.cmbCompFinal.CustomFormat = "MMMM yyyy"
        Me.cmbCompFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbCompFinal.Location = New System.Drawing.Point(302, 19)
        Me.cmbCompFinal.Name = "cmbCompFinal"
        Me.cmbCompFinal.Size = New System.Drawing.Size(113, 20)
        Me.cmbCompFinal.TabIndex = 85
        '
        'gridComplementoPago
        '
        Me.gridComplementoPago.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridComplementoPago.ColumnAutoResize = True
        Me.gridComplementoPago.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.gridComplementoPago.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.gridComplementoPago.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.gridComplementoPago.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.gridComplementoPago.GroupByBoxVisible = False
        Me.gridComplementoPago.Location = New System.Drawing.Point(7, 44)
        Me.gridComplementoPago.Name = "gridComplementoPago"
        Me.gridComplementoPago.RecordNavigator = True
        Me.gridComplementoPago.Size = New System.Drawing.Size(1037, 384)
        Me.gridComplementoPago.TabIndex = 4
        Me.gridComplementoPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabPendientes
        '
        Me.UiTabPendientes.Controls.Add(Me.GrpPendientes)
        Me.UiTabPendientes.Location = New System.Drawing.Point(1, 21)
        Me.UiTabPendientes.Name = "UiTabPendientes"
        Me.UiTabPendientes.Size = New System.Drawing.Size(1056, 439)
        Me.UiTabPendientes.TabStop = True
        Me.UiTabPendientes.Text = "Pendientes de Certificar"
        '
        'GrpPendientes
        '
        Me.GrpPendientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpPendientes.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpPendientes.Controls.Add(Me.btnCancelaPendiente)
        Me.GrpPendientes.Controls.Add(Me.btnRegenerar)
        Me.GrpPendientes.Controls.Add(Me.GridPendientes)
        Me.GrpPendientes.Controls.Add(Me.btnCertificar)
        Me.GrpPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpPendientes.ForeColor = System.Drawing.Color.Black
        Me.GrpPendientes.Location = New System.Drawing.Point(2, 3)
        Me.GrpPendientes.Name = "GrpPendientes"
        Me.GrpPendientes.Size = New System.Drawing.Size(1052, 433)
        Me.GrpPendientes.TabIndex = 3
        Me.GrpPendientes.TabStop = False
        Me.GrpPendientes.Text = "Documentos Pendientes de Certificar"
        '
        'btnCancelaPendiente
        '
        Me.btnCancelaPendiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelaPendiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelaPendiente.Icon = CType(resources.GetObject("btnCancelaPendiente.Icon"), System.Drawing.Icon)
        Me.btnCancelaPendiente.Location = New System.Drawing.Point(845, 15)
        Me.btnCancelaPendiente.Name = "btnCancelaPendiente"
        Me.btnCancelaPendiente.Size = New System.Drawing.Size(62, 30)
        Me.btnCancelaPendiente.TabIndex = 23
        Me.btnCancelaPendiente.ToolTipText = "Cancela el registro seleccionado"
        Me.btnCancelaPendiente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnRegenerar
        '
        Me.btnRegenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRegenerar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRegenerar.Icon = CType(resources.GetObject("btnRegenerar.Icon"), System.Drawing.Icon)
        Me.btnRegenerar.Location = New System.Drawing.Point(913, 15)
        Me.btnRegenerar.Name = "btnRegenerar"
        Me.btnRegenerar.Size = New System.Drawing.Size(62, 30)
        Me.btnRegenerar.TabIndex = 22
        Me.btnRegenerar.ToolTipText = "Regenera el XML "
        Me.btnRegenerar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridPendientes
        '
        Me.GridPendientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPendientes.ColumnAutoResize = True
        Me.GridPendientes.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPendientes.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPendientes.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridPendientes.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridPendientes.GroupByBoxVisible = False
        Me.GridPendientes.Location = New System.Drawing.Point(5, 48)
        Me.GridPendientes.Name = "GridPendientes"
        Me.GridPendientes.RecordNavigator = True
        Me.GridPendientes.Size = New System.Drawing.Size(1038, 377)
        Me.GridPendientes.TabIndex = 4
        Me.GridPendientes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnCertificar
        '
        Me.btnCertificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCertificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCertificar.Icon = CType(resources.GetObject("btnCertificar.Icon"), System.Drawing.Icon)
        Me.btnCertificar.Location = New System.Drawing.Point(981, 15)
        Me.btnCertificar.Name = "btnCertificar"
        Me.btnCertificar.Size = New System.Drawing.Size(62, 30)
        Me.btnCertificar.TabIndex = 21
        Me.btnCertificar.ToolTipText = "Realiza un reintento de certificación del documento seleccionado"
        Me.btnCertificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTabContrarecibos
        '
        Me.UiTabContrarecibos.Controls.Add(Me.GroupBox2)
        Me.UiTabContrarecibos.Location = New System.Drawing.Point(1, 21)
        Me.UiTabContrarecibos.Name = "UiTabContrarecibos"
        Me.UiTabContrarecibos.Size = New System.Drawing.Size(1000, 439)
        Me.UiTabContrarecibos.TabStop = True
        Me.UiTabContrarecibos.Text = "Contrarecibos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox2.Controls.Add(Me.btnPrint)
        Me.GroupBox2.Controls.Add(Me.ChkTodos)
        Me.GroupBox2.Controls.Add(Me.btnEditContrarecibo)
        Me.GroupBox2.Controls.Add(Me.btnAddContrarecibo)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.dtPickerContrarecibo)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.GridContrarecibos)
        Me.GroupBox2.Controls.Add(Me.cmbEdoContrarecibo)
        Me.GroupBox2.Controls.Add(Me.PictureBox5)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(996, 433)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Gestión de Contrarecibos"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.Icon = CType(resources.GetObject("btnPrint.Icon"), System.Drawing.Icon)
        Me.btnPrint.Location = New System.Drawing.Point(790, 12)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(62, 30)
        Me.btnPrint.TabIndex = 144
        Me.btnPrint.ToolTipText = "Impresion de relación de facturas"
        Me.btnPrint.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkTodos
        '
        Me.ChkTodos.Location = New System.Drawing.Point(519, 20)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(76, 19)
        Me.ChkTodos.TabIndex = 143
        Me.ChkTodos.Text = "Todos"
        '
        'btnEditContrarecibo
        '
        Me.btnEditContrarecibo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditContrarecibo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditContrarecibo.Icon = CType(resources.GetObject("btnEditContrarecibo.Icon"), System.Drawing.Icon)
        Me.btnEditContrarecibo.Location = New System.Drawing.Point(858, 12)
        Me.btnEditContrarecibo.Name = "btnEditContrarecibo"
        Me.btnEditContrarecibo.Size = New System.Drawing.Size(62, 30)
        Me.btnEditContrarecibo.TabIndex = 90
        Me.btnEditContrarecibo.ToolTipText = "Actualiza el registro seleccionado"
        Me.btnEditContrarecibo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAddContrarecibo
        '
        Me.btnAddContrarecibo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddContrarecibo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddContrarecibo.Icon = CType(resources.GetObject("btnAddContrarecibo.Icon"), System.Drawing.Icon)
        Me.btnAddContrarecibo.Location = New System.Drawing.Point(926, 12)
        Me.btnAddContrarecibo.Name = "btnAddContrarecibo"
        Me.btnAddContrarecibo.Size = New System.Drawing.Size(62, 30)
        Me.btnAddContrarecibo.TabIndex = 89
        Me.btnAddContrarecibo.ToolTipText = "Agrega nuevo documento a la gestión de contrarecibos"
        Me.btnAddContrarecibo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(267, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "Periodo"
        '
        'dtPickerContrarecibo
        '
        Me.dtPickerContrarecibo.CustomFormat = "MMMM yyyy"
        Me.dtPickerContrarecibo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPickerContrarecibo.Location = New System.Drawing.Point(329, 18)
        Me.dtPickerContrarecibo.Name = "dtPickerContrarecibo"
        Me.dtPickerContrarecibo.Size = New System.Drawing.Size(184, 20)
        Me.dtPickerContrarecibo.TabIndex = 85
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(7, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 14)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "Estado"
        '
        'GridContrarecibos
        '
        Me.GridContrarecibos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridContrarecibos.ColumnAutoResize = True
        Me.GridContrarecibos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridContrarecibos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridContrarecibos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridContrarecibos.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridContrarecibos.GroupByBoxVisible = False
        Me.GridContrarecibos.Location = New System.Drawing.Point(7, 44)
        Me.GridContrarecibos.Name = "GridContrarecibos"
        Me.GridContrarecibos.RecordNavigator = True
        Me.GridContrarecibos.Size = New System.Drawing.Size(981, 384)
        Me.GridContrarecibos.TabIndex = 4
        Me.GridContrarecibos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbEdoContrarecibo
        '
        Me.cmbEdoContrarecibo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbEdoContrarecibo.Location = New System.Drawing.Point(72, 18)
        Me.cmbEdoContrarecibo.Name = "cmbEdoContrarecibo"
        Me.cmbEdoContrarecibo.Size = New System.Drawing.Size(154, 21)
        Me.cmbEdoContrarecibo.TabIndex = 82
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(232, 19)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(22, 20)
        Me.PictureBox5.TabIndex = 39
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'UiTabClientes
        '
        Me.UiTabClientes.Controls.Add(Me.grpClientes)
        Me.UiTabClientes.Location = New System.Drawing.Point(1, 21)
        Me.UiTabClientes.Name = "UiTabClientes"
        Me.UiTabClientes.Size = New System.Drawing.Size(1056, 439)
        Me.UiTabClientes.TabStop = True
        Me.UiTabClientes.Text = "Clientes"
        '
        'grpClientes
        '
        Me.grpClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpClientes.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpClientes.Controls.Add(Me.btnConsultaNC)
        Me.grpClientes.Controls.Add(Me.btnCliente)
        Me.grpClientes.Controls.Add(Me.TxtBuscar)
        Me.grpClientes.Controls.Add(Me.BtnEdoCta)
        Me.grpClientes.Controls.Add(Me.gridClientes)
        Me.grpClientes.Controls.Add(Me.CmbCampo)
        Me.grpClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpClientes.ForeColor = System.Drawing.Color.Black
        Me.grpClientes.Location = New System.Drawing.Point(2, 4)
        Me.grpClientes.Name = "grpClientes"
        Me.grpClientes.Size = New System.Drawing.Size(1052, 430)
        Me.grpClientes.TabIndex = 3
        Me.grpClientes.TabStop = False
        Me.grpClientes.Text = "Clientes"
        '
        'btnConsultaNC
        '
        Me.btnConsultaNC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultaNC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsultaNC.Icon = CType(resources.GetObject("btnConsultaNC.Icon"), System.Drawing.Icon)
        Me.btnConsultaNC.Location = New System.Drawing.Point(835, 12)
        Me.btnConsultaNC.Name = "btnConsultaNC"
        Me.btnConsultaNC.Size = New System.Drawing.Size(73, 30)
        Me.btnConsultaNC.TabIndex = 25
        Me.btnConsultaNC.Text = "Vales"
        Me.btnConsultaNC.ToolTipText = "Consultar Vales"
        Me.btnConsultaNC.Visible = False
        Me.btnConsultaNC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnCliente
        '
        Me.btnCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCliente.Icon = CType(resources.GetObject("btnCliente.Icon"), System.Drawing.Icon)
        Me.btnCliente.Location = New System.Drawing.Point(914, 12)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(62, 30)
        Me.btnCliente.TabIndex = 23
        Me.btnCliente.ToolTipText = "Edita Cliente Seleccionado"
        Me.btnCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBuscar.Location = New System.Drawing.Point(178, 19)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(337, 20)
        Me.TxtBuscar.TabIndex = 21
        '
        'BtnEdoCta
        '
        Me.BtnEdoCta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEdoCta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEdoCta.Icon = CType(resources.GetObject("BtnEdoCta.Icon"), System.Drawing.Icon)
        Me.BtnEdoCta.Location = New System.Drawing.Point(982, 12)
        Me.BtnEdoCta.Name = "BtnEdoCta"
        Me.BtnEdoCta.Size = New System.Drawing.Size(62, 30)
        Me.BtnEdoCta.TabIndex = 20
        Me.BtnEdoCta.ToolTipText = "Impresión de Estado de Cuenta"
        Me.BtnEdoCta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gridClientes
        '
        Me.gridClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridClientes.ColumnAutoResize = True
        Me.gridClientes.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.gridClientes.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.gridClientes.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.gridClientes.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.gridClientes.GroupByBoxVisible = False
        Me.gridClientes.Location = New System.Drawing.Point(7, 48)
        Me.gridClientes.Name = "gridClientes"
        Me.gridClientes.RecordNavigator = True
        Me.gridClientes.Size = New System.Drawing.Size(1037, 376)
        Me.gridClientes.TabIndex = 4
        Me.gridClientes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(7, 18)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(166, 21)
        Me.CmbCampo.TabIndex = 22
        '
        'UiTabApartados
        '
        Me.UiTabApartados.Controls.Add(Me.grpApartados)
        Me.UiTabApartados.Location = New System.Drawing.Point(1, 21)
        Me.UiTabApartados.Name = "UiTabApartados"
        Me.UiTabApartados.Size = New System.Drawing.Size(1056, 439)
        Me.UiTabApartados.TabStop = True
        Me.UiTabApartados.Text = "Apartados"
        '
        'grpApartados
        '
        Me.grpApartados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpApartados.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpApartados.Controls.Add(Me.btnApartados)
        Me.grpApartados.Controls.Add(Me.btnActApartados)
        Me.grpApartados.Controls.Add(Me.gridApartados)
        Me.grpApartados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpApartados.ForeColor = System.Drawing.Color.Black
        Me.grpApartados.Location = New System.Drawing.Point(2, 4)
        Me.grpApartados.Name = "grpApartados"
        Me.grpApartados.Size = New System.Drawing.Size(1052, 430)
        Me.grpApartados.TabIndex = 3
        Me.grpApartados.TabStop = False
        Me.grpApartados.Text = "Apartados"
        '
        'btnApartados
        '
        Me.btnApartados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApartados.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApartados.Icon = CType(resources.GetObject("btnApartados.Icon"), System.Drawing.Icon)
        Me.btnApartados.Location = New System.Drawing.Point(914, 11)
        Me.btnApartados.Name = "btnApartados"
        Me.btnApartados.Size = New System.Drawing.Size(62, 30)
        Me.btnApartados.TabIndex = 52
        Me.btnApartados.ToolTipText = "Mantenimiento de Productos Apartados"
        Me.btnApartados.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnActApartados
        '
        Me.btnActApartados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActApartados.Icon = CType(resources.GetObject("btnActApartados.Icon"), System.Drawing.Icon)
        Me.btnActApartados.Location = New System.Drawing.Point(982, 11)
        Me.btnActApartados.Name = "btnActApartados"
        Me.btnActApartados.Size = New System.Drawing.Size(62, 30)
        Me.btnActApartados.TabIndex = 51
        Me.btnActApartados.ToolTipText = "Actualizar"
        Me.btnActApartados.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gridApartados
        '
        Me.gridApartados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridApartados.ColumnAutoResize = True
        Me.gridApartados.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.gridApartados.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.gridApartados.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.gridApartados.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.gridApartados.GroupByBoxVisible = False
        Me.gridApartados.Location = New System.Drawing.Point(7, 47)
        Me.gridApartados.Name = "gridApartados"
        Me.gridApartados.RecordNavigator = True
        Me.gridApartados.Size = New System.Drawing.Size(1037, 377)
        Me.gridApartados.TabIndex = 4
        Me.gridApartados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpSaldos
        '
        Me.GrpSaldos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpSaldos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpSaldos.Controls.Add(Me.Label26)
        Me.GrpSaldos.Controls.Add(Me.NumSaldo)
        Me.GrpSaldos.Controls.Add(Me.LblCredito)
        Me.GrpSaldos.Controls.Add(Me.NumDisponible)
        Me.GrpSaldos.Controls.Add(Me.GridSaldos)
        Me.GrpSaldos.Location = New System.Drawing.Point(8, 8)
        Me.GrpSaldos.Name = "GrpSaldos"
        Me.GrpSaldos.Size = New System.Drawing.Size(757, 349)
        Me.GrpSaldos.TabIndex = 10
        Me.GrpSaldos.TabStop = False
        Me.GrpSaldos.Text = "Saldos de Facturas"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(392, 16)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(96, 16)
        Me.Label26.TabIndex = 61
        Me.Label26.Text = "Total Saldo"
        '
        'NumSaldo
        '
        Me.NumSaldo.Location = New System.Drawing.Point(496, 16)
        Me.NumSaldo.Name = "NumSaldo"
        Me.NumSaldo.ReadOnly = True
        Me.NumSaldo.Size = New System.Drawing.Size(160, 20)
        Me.NumSaldo.TabIndex = 60
        Me.NumSaldo.Text = "0.00"
        Me.NumSaldo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.NumSaldo.Value = 0.0R
        Me.NumSaldo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'LblCredito
        '
        Me.LblCredito.Location = New System.Drawing.Point(16, 16)
        Me.LblCredito.Name = "LblCredito"
        Me.LblCredito.Size = New System.Drawing.Size(104, 16)
        Me.LblCredito.TabIndex = 59
        Me.LblCredito.Text = "Crédito Disponible"
        '
        'NumDisponible
        '
        Me.NumDisponible.Location = New System.Drawing.Point(128, 16)
        Me.NumDisponible.Name = "NumDisponible"
        Me.NumDisponible.ReadOnly = True
        Me.NumDisponible.Size = New System.Drawing.Size(160, 20)
        Me.NumDisponible.TabIndex = 58
        Me.NumDisponible.Text = "0.00"
        Me.NumDisponible.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.NumDisponible.Value = 0.0R
        Me.NumDisponible.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
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
        Me.GridSaldos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridSaldos.Location = New System.Drawing.Point(16, 40)
        Me.GridSaldos.Name = "GridSaldos"
        Me.GridSaldos.RecordNavigator = True
        Me.GridSaldos.Size = New System.Drawing.Size(725, 293)
        Me.GridSaldos.TabIndex = 2
        Me.GridSaldos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpMetodos
        '
        Me.GrpMetodos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpMetodos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpMetodos.Controls.Add(Me.BtnAgregar)
        Me.GrpMetodos.Controls.Add(Me.GridMetodos)
        Me.GrpMetodos.Controls.Add(Me.BtnElimina)
        Me.GrpMetodos.Controls.Add(Me.BtnModifica)
        Me.GrpMetodos.Location = New System.Drawing.Point(3, 3)
        Me.GrpMetodos.Name = "GrpMetodos"
        Me.GrpMetodos.Size = New System.Drawing.Size(768, 359)
        Me.GrpMetodos.TabIndex = 5
        Me.GrpMetodos.TabStop = False
        Me.GrpMetodos.Text = "Metodos Preferidos de Pago"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(680, 16)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(80, 24)
        Me.BtnAgregar.TabIndex = 2
        Me.BtnAgregar.Text = "&Agregar"
        Me.BtnAgregar.ToolTipText = "Agrega nuevo Metodo de Pago"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
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
        Me.GridMetodos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridMetodos.Location = New System.Drawing.Point(8, 16)
        Me.GridMetodos.Name = "GridMetodos"
        Me.GridMetodos.RecordNavigator = True
        Me.GridMetodos.Size = New System.Drawing.Size(664, 335)
        Me.GridMetodos.TabIndex = 1
        Me.GridMetodos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnElimina
        '
        Me.BtnElimina.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnElimina.Image = CType(resources.GetObject("BtnElimina.Image"), System.Drawing.Image)
        Me.BtnElimina.Location = New System.Drawing.Point(680, 104)
        Me.BtnElimina.Name = "BtnElimina"
        Me.BtnElimina.Size = New System.Drawing.Size(80, 24)
        Me.BtnElimina.TabIndex = 4
        Me.BtnElimina.Text = "&Eliminar "
        Me.BtnElimina.ToolTipText = "Elimina el Metodo de Pago seleccionada"
        Me.BtnElimina.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModifica
        '
        Me.BtnModifica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModifica.Image = CType(resources.GetObject("BtnModifica.Image"), System.Drawing.Image)
        Me.BtnModifica.Location = New System.Drawing.Point(680, 64)
        Me.BtnModifica.Name = "BtnModifica"
        Me.BtnModifica.Size = New System.Drawing.Size(80, 24)
        Me.BtnModifica.TabIndex = 3
        Me.BtnModifica.Text = "&Modificar "
        Me.BtnModifica.ToolTipText = "Modifica el Metodo de Pago seleccionada"
        Me.BtnModifica.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnComision
        '
        Me.BtnComision.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnComision.Icon = CType(resources.GetObject("BtnComision.Icon"), System.Drawing.Icon)
        Me.BtnComision.Location = New System.Drawing.Point(370, 62)
        Me.BtnComision.Name = "BtnComision"
        Me.BtnComision.Size = New System.Drawing.Size(90, 30)
        Me.BtnComision.TabIndex = 20
        Me.BtnComision.Text = " Comisión"
        Me.BtnComision.ToolTipText = "Registrar Pago de Comisionistas"
        Me.BtnComision.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCambio
        '
        Me.BtnCambio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCambio.Icon = CType(resources.GetObject("BtnCambio.Icon"), System.Drawing.Icon)
        Me.BtnCambio.Location = New System.Drawing.Point(462, 62)
        Me.BtnCambio.Name = "BtnCambio"
        Me.BtnCambio.Size = New System.Drawing.Size(90, 30)
        Me.BtnCambio.TabIndex = 16
        Me.BtnCambio.Text = "Cambios"
        Me.BtnCambio.ToolTipText = "Registrar Cambio de Producto"
        Me.BtnCambio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'lblDate
        '
        Me.lblDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblDate.Location = New System.Drawing.Point(467, 3)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(590, 22)
        Me.lblDate.TabIndex = 22
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAcumulado
        '
        Me.btnAcumulado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAcumulado.Icon = CType(resources.GetObject("btnAcumulado.Icon"), System.Drawing.Icon)
        Me.btnAcumulado.Location = New System.Drawing.Point(738, 62)
        Me.btnAcumulado.Name = "btnAcumulado"
        Me.btnAcumulado.Size = New System.Drawing.Size(90, 30)
        Me.btnAcumulado.TabIndex = 29
        Me.btnAcumulado.Text = "Acumulado"
        Me.btnAcumulado.ToolTipText = "Consulta de auditoria de pedidos o ventas"
        Me.btnAcumulado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnCorte
        '
        Me.btnCorte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCorte.Icon = CType(resources.GetObject("btnCorte.Icon"), System.Drawing.Icon)
        Me.btnCorte.Location = New System.Drawing.Point(646, 62)
        Me.btnCorte.Name = "btnCorte"
        Me.btnCorte.Size = New System.Drawing.Size(90, 30)
        Me.btnCorte.TabIndex = 30
        Me.btnCorte.Text = "F11 - Corte"
        Me.btnCorte.ToolTipText = "Imprimir Corte"
        Me.btnCorte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGlobal
        '
        Me.BtnGlobal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnGlobal.Icon = CType(resources.GetObject("BtnGlobal.Icon"), System.Drawing.Icon)
        Me.BtnGlobal.Location = New System.Drawing.Point(278, 62)
        Me.BtnGlobal.Name = "BtnGlobal"
        Me.BtnGlobal.Size = New System.Drawing.Size(90, 30)
        Me.BtnGlobal.TabIndex = 79
        Me.BtnGlobal.Text = "Fac. Global"
        Me.BtnGlobal.ToolTipText = "Crea un factura Global"
        Me.BtnGlobal.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Clock2
        '
        Me.Clock2.Interval = 500
        '
        'btnVerificador
        '
        Me.btnVerificador.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVerificador.Icon = CType(resources.GetObject("btnVerificador.Icon"), System.Drawing.Icon)
        Me.btnVerificador.Location = New System.Drawing.Point(94, 62)
        Me.btnVerificador.Name = "btnVerificador"
        Me.btnVerificador.Size = New System.Drawing.Size(90, 30)
        Me.btnVerificador.TabIndex = 81
        Me.btnVerificador.Text = "Ver. Precio"
        Me.btnVerificador.ToolTipText = "Verificador de Precios"
        Me.btnVerificador.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCerrar.Icon = CType(resources.GetObject("BtnCerrar.Icon"), System.Drawing.Icon)
        Me.BtnCerrar.Location = New System.Drawing.Point(922, 62)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(90, 30)
        Me.BtnCerrar.TabIndex = 80
        Me.BtnCerrar.Text = "Cerrar"
        Me.BtnCerrar.ToolTipText = "Cerrar Caja"
        Me.BtnCerrar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnServicios
        '
        Me.btnServicios.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton
        Me.btnServicios.ContextMenuStrip = Me.CtxDocumentos
        Me.btnServicios.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnServicios.Icon = CType(resources.GetObject("btnServicios.Icon"), System.Drawing.Icon)
        Me.btnServicios.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnServicios.Location = New System.Drawing.Point(186, 62)
        Me.btnServicios.Name = "btnServicios"
        Me.btnServicios.Size = New System.Drawing.Size(90, 30)
        Me.btnServicios.TabIndex = 83
        Me.btnServicios.Text = "Servicios"
        Me.btnServicios.ToolTipText = "Pago de servicios seleccionados"
        Me.btnServicios.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CtxDocumentos
        '
        Me.CtxDocumentos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemTarjetaAmiga, Me.RecargaTelefonicaToolStripMenuItem})
        Me.CtxDocumentos.Name = "CtxDocumentos"
        Me.CtxDocumentos.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.CtxDocumentos.Size = New System.Drawing.Size(173, 70)
        '
        'ItemTarjetaAmiga
        '
        Me.ItemTarjetaAmiga.Image = Global.Selling.My.Resources.Resources.if_credit_card_blue_10412
        Me.ItemTarjetaAmiga.Name = "ItemTarjetaAmiga"
        Me.ItemTarjetaAmiga.Size = New System.Drawing.Size(172, 22)
        Me.ItemTarjetaAmiga.Text = "Tarjeta Amiga"
        Me.ItemTarjetaAmiga.ToolTipText = "Servicios de Tarjeta Amiga"
        '
        'RecargaTelefonicaToolStripMenuItem
        '
        Me.RecargaTelefonicaToolStripMenuItem.Image = Global.Selling.My.Resources.Resources.RecargaTelefonica
        Me.RecargaTelefonicaToolStripMenuItem.Name = "RecargaTelefonicaToolStripMenuItem"
        Me.RecargaTelefonicaToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.RecargaTelefonicaToolStripMenuItem.Text = "Recarga Telefonica"
        '
        'btnPreventa
        '
        Me.btnPreventa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPreventa.Icon = CType(resources.GetObject("btnPreventa.Icon"), System.Drawing.Icon)
        Me.btnPreventa.Location = New System.Drawing.Point(830, 62)
        Me.btnPreventa.Name = "btnPreventa"
        Me.btnPreventa.Size = New System.Drawing.Size(90, 30)
        Me.btnPreventa.TabIndex = 84
        Me.btnPreventa.Text = "Entrega"
        Me.btnPreventa.ToolTipText = "Cerrar Caja"
        Me.btnPreventa.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmTCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1064, 564)
        Me.Controls.Add(Me.btnPreventa)
        Me.Controls.Add(Me.btnServicios)
        Me.Controls.Add(Me.btnVerificador)
        Me.Controls.Add(Me.BtnCerrar)
        Me.Controls.Add(Me.BtnGlobal)
        Me.Controls.Add(Me.btnCorte)
        Me.Controls.Add(Me.btnAcumulado)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.UiTab1)
        Me.Controls.Add(Me.BtnComision)
        Me.Controls.Add(Me.BtnAuditoria)
        Me.Controls.Add(Me.BtnCambio)
        Me.Controls.Add(Me.BtnRetiro)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.LblDescripcion)
        Me.Controls.Add(Me.LblAtiende)
        Me.Controls.Add(Me.LblCaja)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmTCaja"
        Me.Text = " "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        Me.UiTabGeneral.ResumeLayout(False)
        Me.GrpTickets.ResumeLayout(False)
        Me.GrpTickets.PerformLayout()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCxC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabAbonos.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.gridAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabCXC.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridCreditos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabComplementoPago.ResumeLayout(False)
        Me.grpComplementoPago.ResumeLayout(False)
        Me.grpComplementoPago.PerformLayout()
        CType(Me.gridComplementoPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabPendientes.ResumeLayout(False)
        Me.GrpPendientes.ResumeLayout(False)
        CType(Me.GridPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabContrarecibos.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.GridContrarecibos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabClientes.ResumeLayout(False)
        Me.grpClientes.ResumeLayout(False)
        Me.grpClientes.PerformLayout()
        CType(Me.gridClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabApartados.ResumeLayout(False)
        Me.grpApartados.ResumeLayout(False)
        CType(Me.gridApartados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpSaldos.ResumeLayout(False)
        Me.GrpSaldos.PerformLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpMetodos.ResumeLayout(False)
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CtxDocumentos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public PDVClave As String = ""
    Public StageLU As String = ""
    Public FormatoRecibo As String = "Carta"
    Public eTPersona As Integer
    Public Mostrador As String = ""
    Public SUCClave As String
    Public CAJClave, ClaveCaja As String
    Public ALMClave As String
    Public Recibo As String
    Public TICDevolucion As String
    Public PrintGeneric As Boolean
    Public Impresora As String
    Public Clave As String
    Public ImpresoraFac As String
    Public Manual As Integer
    Public LEfectivo, LCheques, LVales As Double
    Public Cajon As Boolean = False
    Public Aplicacion As String = ""
    Public PRNClavePic As String
    Public CorteDetallado As Integer = 0
    Public ConfirmarAbono As Integer = 0
    Public muestraNotas As Integer = 0
    Public reciboTicket As Integer = 0
    Public NumCopias As Integer
    Public MaxEfectivo As Double 'Maximo Efectivo en Caja
    Public Transferencia As Integer
    Public FormatoCorte As String
    Public Bloqueo As String
    Public Stage As String
    Public StageCancelacion As String
    Public IncluirCierre As Boolean = False
    Public idCajero As Integer
    Public idPOS As String
    Public passCajero As String

    Private ticketPicking As Boolean = False
    Private TIKClave As String = ""
    Private IDCorte As String = ""
    Private Picking As Boolean = False
    Private Packing As Boolean = False
    Private MaskCte As Integer = 0
    Private SucursalClave As String = ""
    Private alerta(3) As PictureBox
    Private reloj As parpadea
    Private dtCxC As DataTable
    Private TipoCambio, TipoCambiario, SaldoBase, dSaldoAnticipo As Decimal
    Private bload As Boolean = False
    Private dtPAC, dtPendientes, dtAnticipos, dtContrarecibos, dtComplementoPago As DataTable
    Private cobranzaGeneral As Boolean = True
    Private CTEClave As String = ""
    Private sRazonSocial As String = ""
    Private MailSSL As Boolean
    Private TipoCF, Periodo, PeriodoContra, Mes, MesContra, MailPort As Integer
    Private TallaColor As Integer = 0
    Private correo As MailMessage
    Private adjuntos As Attachment
    Private autenticar As NetworkCredential
    Private envio As SmtpClient
    Private dato As FileStream
    Private Moneda, RefMoneda, MonedaCambio, MonedaDesc, MonedaRef, CTEClaveActual, CTENombreActual, PrinterInvoice, ServidorCancelacion, Autoriza, PathXML, FormatoPedido, FormatNC, FormatCargo, FormatoFactura, sPendienteSelected, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP, VersionCF, regimenFiscal As String
    Private InterfazSalida As String = ""
    Private RefCambio As String = ""
    Private iRegimenFiscal As Integer
    Private bPreCorte As Boolean = False
    Private bRetiroCorte As Boolean = False
    Private CobranzaVenta As Boolean = False
    Private iDesglosarPrecio As Integer = 0
    Private bExit As Boolean = False
    Private interfazTallaColor As Boolean
    Private idEventoGlobal As String
    Private CerrarDias As Boolean = False
    Private LimitarCobrosFactura As Integer = 0


    Private Sub TxtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
        Clock2.Stop()
    End Sub

    Private Sub TxtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyUp
        Clock2.Start()
    End Sub

    Private Function validaAbonos() As Boolean
        Dim i As Integer = 0

        If TxtBusqueda.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbFiltro.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
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


    Private Sub FrmTCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        If PDVClave <> "" AndAlso StageLU <> "" Then
            btnNuevo.Visible = True
        End If

        Me.StartPosition = FormStartPosition.CenterScreen

        cmbCompFinal.Value = Today
        cmbCompInicial.Value = Today

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4

        With Me.CmbFiltro
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "Filtro"
            .llenar()
        End With

        CmbFecha.Value = Today


        With Me.CmbCampo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "Filtro"
            .llenar()
        End With
        Dim dtmsg As DataTable
        Dim dtParam, dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)
        eTPersona = IIf(dt.Rows(0)("TPersona").GetType.Name = "DBNull", 2, dt.Rows(0)("TPersona"))
        dt.Dispose()

        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "TipoCF"
                        TipoCF = CInt(dtParam.Rows(i)("Valor"))
                    Case "DirXML"
                        PathXML = dtParam.Rows(i)("Valor")
                    Case "FormatFac"
                        FormatoFactura = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
                    Case "FormatNC"
                        FormatNC = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
                    Case "FormatCargo"
                        FormatCargo = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
                    Case "FormatPedido"
                        FormatoPedido = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
                    Case "CobranzaVenta"
                        CobranzaVenta = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", False, dtParam.Rows(i)("Valor"))
                    Case "VersionCF"
                        dtmsg = Recupera_Tabla("sp_recupera_valorref", "@Tabla", "CFD", "@Campo", "Version", "@estado", CInt(dtParam.Rows(i)("Valor")))
                        VersionCF = dtmsg.Rows(0)("Descripcion")
                        dtmsg.Dispose()
                    Case "RegimenFiscal"
                        iRegimenFiscal = CInt(dtParam.Rows(i)("Valor"))
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
                    Case "Moneda"
                        Moneda = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                    Case "MonedaCambio"
                        MonedaCambio = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                    Case "InterfazSalida"
                        InterfazSalida = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                    Case "PrecioBase"
                        iDesglosarPrecio = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))
                    Case "TallaColor"
                        TallaColor = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))
                    Case "MascaraCte"
                        MaskCte = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))
                    Case "LimitarCobroFactura"
                        LimitarCobrosFactura = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))
                End Select
            Next
        End With
        dtParam.Dispose()


        If TallaColor = 1 Then
            BtnOtroPago.Text = "Vales"
            btnConsultaNC.Visible = True
        End If

        dtmsg = Recupera_Tabla("sp_recupera_valor", "@Tabla", "CFD", "@Campo", "RegimenFiscal", "@Valor", iRegimenFiscal)
        If VersionCF = "3.3" Then
            regimenFiscal = dtmsg.Rows(0)("ClaveSAT")
            UiTabComplementoPago.TabVisible = True
        Else
            regimenFiscal = dtmsg.Rows(0)("Descripcion")
            UiTabComplementoPago.TabVisible = False
        End If
        dtmsg.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
        TipoCambio = dt.Rows(0)("TipoCambio")
        RefMoneda = dt.Rows(0)("Referencia")
        dt.Dispose()

        LblTotal.Text = "TOTAL A PAGAR: " & RefMoneda

        dt = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", ImpresoraFac)
        PrinterInvoice = dt.Rows(0)("Referencia")
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)
        SucursalClave = dt.Rows(0)("Clave")
        Picking = IIf(dt.Rows(0)("Picking").GetType.Name = "DBNull", False, dt.Rows(0)("Picking"))
        Packing = IIf(dt.Rows(0)("Packing").GetType.Name = "DBNull", False, dt.Rows(0)("Packing"))
        ticketPicking = IIf(dt.Rows(0)("ticketPicking").GetType.Name = "DBNull", False, dt.Rows(0)("ticketPicking"))
        TIKClave = IIf(dt.Rows(0)("TIKClave").GetType.Name = "DBNull", "", dt.Rows(0)("TIKClave"))
        dt.Dispose()

        If Picking = True Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", PRNClavePic)
            PRNClavePic = dt.Rows(0)("Referencia")
            dt.Dispose()
        End If

        If TipoCF = 2 Then
            dtPAC = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)
        End If


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



        Dim dtAutoriza As DataTable = ModPOS.Recupera_Tabla("sp_valida_autorizacion", "@SUCClave", SUCClave, "@Usuario", ModPOS.UsuarioActual)
        If dtAutoriza.Rows.Count = 1 Then
            bRetiroCorte = IIf(dtAutoriza.Rows(0)("RetiroCaja").GetType.Name <> "DBNull", dtAutoriza.Rows(0)("RetiroCaja"), False)
            bPreCorte = IIf(dtAutoriza.Rows(0)("PreCorte").GetType.Name <> "DBNull", dtAutoriza.Rows(0)("PreCorte"), False)
        Else
            bRetiroCorte = False
            bPreCorte = False
        End If
        dtAutoriza.Dispose()

        btnAcumulado.Visible = bPreCorte


        If Manual = 1 AndAlso IDCorte <> "" Then

            Dim ac As New FrmCerrarCaja
            ac.TxtLeyenda.Text = "La caja se encuentra abierta desde el " & sFechaApertura
            ac.StartPosition = FormStartPosition.CenterScreen
            ac.Transferencia = Transferencia
            ac.Cierre = False
            If ac.ShowDialog() = System.Windows.Forms.DialogResult.OK AndAlso ac.Accion = "Corte" Then

                If Transferencia = 1 Then
                    Dim bTransBanco As Boolean = False
                    Do
                        Dim a As New FrmTransBanco
                        a.IdCorte = IDCorte
                        a.CAJClave = CAJClave
                        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                            bTransBanco = True
                        ElseIf a.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                            bTransBanco = True

                        Else
                            If a.iTransBanco = 0 Then
                                bTransBanco = True
                            End If
                        End If

                    Loop While bTransBanco = False
                ElseIf IDCorte = "" Then
                    If CorteDetallado = 1 Then
                        Dim a As New FrmAperturaCaja
                        a.SUCClave = SUCClave
                        a.FormatoCorte = FormatoCorte
                        a.reciboTicket = Me.reciboTicket
                        a.Accion = "Apertura"
                        a.IDCorte = IDCorte
                        a.CAJClave = CAJClave
                        a.Referencia = ClaveCaja
                        a.Cajon = Cajon
                        a.Generic = PrintGeneric
                        a.Recibo = Recibo
                        a.Impresora = Impresora
                        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                            IDCorte = a.IDCorte
                        End If
                    Else
                        Dim a As New FrmAperturaSimple
                        a.SUCClave = SUCClave
                        a.FormatoCorte = FormatoCorte
                        a.reciboTicket = Me.reciboTicket
                        a.Accion = "Apertura"
                        a.IDCorte = IDCorte
                        a.CAJClave = CAJClave
                        a.Referencia = ClaveCaja
                        a.Cajon = Cajon
                        a.Generic = PrintGeneric
                        a.Recibo = Recibo
                        a.Impresora = Impresora
                        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                            IDCorte = a.IDCorte
                        End If
                    End If
                Else
                    If CorteDetallado = 1 Then
                        Dim a As New FrmAperturaCaja
                        a.SUCClave = SUCClave
                        a.FormatoCorte = FormatoCorte
                        a.reciboTicket = Me.reciboTicket
                        a.LBTitulo.Text = "Corte de Caja al Cierre"
                        a.Accion = "Cierre"
                        a.CAJClave = CAJClave

                        a.Referencia = ClaveCaja
                        a.Impresora = Impresora
                        a.Generic = PrintGeneric
                        a.Recibo = Recibo
                        a.IDCorte = IDCorte
                        a.BtnCancelar.Visible = True
                        a.Cajon = Cajon
                        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                            IDCorte = a.IDCorte
                        End If

                    Else
                        Dim a As New FrmAperturaSimple
                        a.SUCClave = SUCClave
                        a.FormatoCorte = FormatoCorte
                        a.reciboTicket = Me.reciboTicket
                        a.LBTitulo.Text = "Corte de Caja al Cierre"
                        a.Accion = "Cierre"
                        a.CAJClave = CAJClave
                        a.Referencia = ClaveCaja
                        a.Impresora = Impresora
                        a.Generic = PrintGeneric
                        a.Recibo = Recibo
                        a.IDCorte = IDCorte
                        a.BtnCancelar.Visible = True
                        a.Cajon = Cajon
                        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                            IDCorte = a.IDCorte
                        End If

                    End If
                End If
            ElseIf ac.Accion = "PreCorte" Then

                If bPreCorte = False Then

                    Dim bAutorizado As Boolean = False
                    Dim bSalir As Boolean = False
                    Do

                        Dim a As New MeAutorizacion

                        a.Sucursal = SUCClave
                        a.sp = "st_filtra_precorte"
                        a.MontodeAutorizacion = 0
                        a.StartPosition = FormStartPosition.CenterScreen
                        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                            bAutorizado = a.Autorizado
                        Else
                            bSalir = True
                        End If

                    Loop While bAutorizado = False AndAlso bSalir = False


                    If bPreCorte = False AndAlso bAutorizado = False Then
                        Exit Sub
                    End If

                End If


                Dim StopPrint As Boolean = False

                Dim sPrintMessage As String = "¿Desea Reimprimir el Pre Corte de Caja?"
                Do

                    If reciboTicket = 1 Then
                        imprimeTicketPreCorte(IDCorte, Impresora, PrintGeneric, Recibo)
                    Else
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "pvtaDataSet"

                        If Transferencia = 1 Then
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco_enc", "@IdCorte", IDCorte))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco", "@IdCorte", IDCorte))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_reembolso", "@IdCorte", IDCorte))
                            OpenReport.PrintPreview("Acumulado", "CRAcumulado.rpt", pvtaDataSet, "")
                        Else
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco_enc", "@IdCorte", IDCorte))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_acumulado", "@IdCorte", IDCorte))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_cobranzaCredito", "@IDCorte", IDCorte))
                            OpenReport.PrintPreview("Acumulado", "CRAcumula.rpt", pvtaDataSet, "")
                        End If
                    End If


                    Select Case MessageBox.Show(sPrintMessage, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.No
                            StopPrint = True
                    End Select

                Loop While Not StopPrint
            ElseIf ac.Accion = "" Then
                bExit = True
                Me.Close()
                Exit Sub
            End If
        Else
            If Transferencia = 1 AndAlso IDCorte <> "" Then
                Dim bTransBanco As Boolean = False
                Do
                    Dim a As New FrmTransBanco
                    a.IdCorte = IDCorte
                    a.CAJClave = CAJClave
                    If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        bTransBanco = True
                    ElseIf a.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                        bTransBanco = True
                    Else
                        If a.iTransBanco = 0 Then
                            bTransBanco = True
                        End If
                    End If

                Loop While bTransBanco = False
            Else
                If IncluirCierre Then
                    Dim dtCierre As DataTable = ModPOS.SiExisteRecupera("st_validaCierreDia", "@CAJClave", CAJClave)
                    If Not dtCierre Is Nothing Then
                        If dtCierre.Rows(0)("Cuantos") > 0 Then
                            MessageBox.Show("Se debe de realizar el cierre de dia antes de realizar la apertura de la caja", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            CerrarDias = True
                            Me.Close()
                            Exit Sub
                        End If
                    End If
                End If
                If CorteDetallado = 1 Then
                    Dim a As New FrmAperturaCaja
                    a.SUCClave = SUCClave
                    a.FormatoCorte = FormatoCorte
                    a.reciboTicket = Me.reciboTicket
                    a.Accion = "Apertura"
                    a.IDCorte = IDCorte
                    a.CAJClave = CAJClave
                    a.Referencia = ClaveCaja
                    a.Cajon = Cajon
                    a.Generic = PrintGeneric
                    a.Recibo = Recibo
                    a.Impresora = Impresora
                    If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        IDCorte = a.IDCorte
                    End If
                Else
                    Dim a As New FrmAperturaSimple
                    a.SUCClave = SUCClave
                    a.FormatoCorte = FormatoCorte
                    a.reciboTicket = Me.reciboTicket
                    a.Accion = "Apertura"
                    a.IDCorte = IDCorte
                    a.CAJClave = CAJClave
                    a.Referencia = ClaveCaja
                    a.Cajon = Cajon
                    a.Generic = PrintGeneric
                    a.Recibo = Recibo
                    a.Impresora = Impresora
                    If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        IDCorte = a.IDCorte
                    End If
                End If
            End If
        End If


        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
        TipoCambiario = dt.Rows(0)("TipoCambio")
        RefCambio = dt.Rows(0)("Referencia")
        dt.Dispose()

        If CInt(TipoCambiario) <> 1 Then
            LblTipoCambio.Text = "T.C. " & Format(CStr(ModPOS.Redondear(TipoCambiario, 2)), "Currency")
            lblMonedaCambio.Text = Format(CStr(Redondear(SaldoBase / TipoCambiario, 2)), "Currency")
            lblMonedaCambio.Visible = True
        Else
            lblMonedaCambio.Visible = False
            LblTipoCambio.Text = ""
        End If

        dtPicker.Value = Today

        If dtPicker.Value.Day > 28 Then
            Dim Dias As Integer = dtPicker.Value.Day
            dtPicker.Value = dtPicker.Value.AddDays(28 - Dias)
        End If

        Periodo = dtPicker.Value.Year
        Mes = dtPicker.Value.Month




        With Me.cmbTipoTrans
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Liquidacion"
            .NombreParametro2 = "campo"
            .Parametro2 = "Transaccion"
            .llenar()
        End With

        With Me.cmbEdoContrarecibo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Contrarecibo"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoEstado"
            .llenar()
        End With



        bload = True

        If Not cmbTipoTrans.SelectedValue Is Nothing Then
            preparaBotones(cmbTipoTrans.SelectedValue)
        End If

        Clock.Start()

        Me.AgregarFolio()


        If Bloqueo.Split("|").Length >= 5 Then
            Dim i As Integer
            For i = 0 To Bloqueo.Split("|").Length - 1
                Select Case i
                    Case Is = 0
                        BtnRetiro.Visible = CBool(Bloqueo.Split("|")(i))
                    Case Is = 1
                        BtnCambio.Visible = CBool(Bloqueo.Split("|")(i))
                    Case Is = 2
                        btnReembolso.Visible = CBool(Bloqueo.Split("|")(i))
                    Case Is = 3
                        BtnComision.Visible = CBool(Bloqueo.Split("|")(i))
                    Case Is = 4
                        BtnDevolucion.Visible = CBool(Bloqueo.Split("|")(i))
                    Case Is = 5
                        BtnFacturar.Visible = CBool(Bloqueo.Split("|")(i))
                    Case Is = 6
                        btnNotaCargo.Visible = CBool(Bloqueo.Split("|")(i))
                    Case Is = 7
                        btnMasiva.Visible = CBool(Bloqueo.Split("|")(i))
                    Case Is = 8
                        BtnGlobal.Visible = CBool(Bloqueo.Split("|")(i))
                    Case Is = 9
                        btnPedido.Visible = CBool(Bloqueo.Split("|")(i))
                    Case Is = 10
                        btnServicios.Visible = CBool(Bloqueo.Split("|")(i))
                    Case Is = 11
                        BtnNC.Visible = CBool(Bloqueo.Split("|")(i))
                    Case Is = 12
                        BtnPago.Visible = CBool(Bloqueo.Split("|")(i))
                    Case Is = 13
                        UiTabApartados.Enabled = CBool(Bloqueo.Split("|")(i))

                End Select
            Next
        End If


        If muestraNotas = 0 Then
            BtnNota.Visible = False
        End If


        TxtFolio.Focus()

    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If Me.cmbTipoTrans.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
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

    Public Sub AgregarFolio()
        If bload Then
            If validaForm() Then

                If Not dtCxC Is Nothing Then
                    dtCxC.Dispose()
                End If

                dtCxC = ModPOS.Recupera_Tabla("sp_recupera_cxc", "@Folio", TxtFolio.Text.Trim.ToUpper.Replace("'", "-"), "@Periodo", Periodo, "@Mes", Mes, "@Tipo", cmbTipoTrans.SelectedValue, "@COMClave", ModPOS.CompanyActual, "@Cobrados", chkIncluir.Checked)
                GridCxC.DataSource = dtCxC
                GridCxC.RetrieveStructure()
                GridCxC.AutoSizeColumns()
                GridCxC.CurrentTable.Columns("DescuentoTot").Visible = False
                GridCxC.RootTable.Columns("ID").Visible = False
                GridCxC.CurrentTable.Columns("TipoDocumento").Visible = False
                GridCxC.CurrentTable.Columns("CTEClave").Visible = False
                GridCxC.CurrentTable.Columns("DevTipo").Visible = False
                GridCxC.CurrentTable.Columns("TipoCF").Visible = False
                GridCxC.CurrentTable.Columns("Email").Visible = False
                GridCxC.CurrentTable.Columns("TipoNC").Visible = False

                GridCxC.RootTable.Columns("Piezas").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

                If muestraNotas = 0 Then
                    GridCxC.CurrentTable.Columns("Nota").Visible = False
                Else
                    GridCxC.CurrentTable.Columns("Nota").Visible = True
                    GridCxC.RootTable.Columns("Nota").Width = 90
                End If
                GridCxC.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                GridCxC.RootTable.Columns("Saldo").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

                GridCxC.RootTable.Columns("Folio").Width = 90
                GridCxC.RootTable.Columns("Cve. Cte.").Width = 45
                GridCxC.RootTable.Columns("RFC").Width = 55
                GridCxC.CurrentTable.Columns("SaldoBase").Visible = False
                GridCxC.CurrentTable.Columns("MONClave").Visible = False
                GridCxC.CurrentTable.Columns("Logo").Visible = False
                GridCxC.CurrentTable.Columns("Facturable").Visible = False
                GridCxC.CurrentTable.Columns("TipoImpuesto").Visible = False
                SaldoBase = 0
                Me.LblSaldo.Text = Format(CStr(ModPOS.Redondear(SaldoBase, 2)), "Currency")

                lblMonedaCambio.Text = RefCambio & " " & Format("0.00", "Currency")
                ChkMarcaTodos.Enabled = True

            Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub


    Private Sub FrmTCaja_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If CerrarDias = False Then
            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_busca_corteCaja", "@CAJClave", CAJClave)

            Dim IDCorte As String = ""
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


            If bExit = False Then

                If Manual = 1 AndAlso IDCorte <> "" Then
                    Dim ac As New FrmCerrarCaja
                    ac.TxtLeyenda.Text = "La caja se encuentra abierta desde el " & sFechaApertura
                    ac.StartPosition = FormStartPosition.CenterScreen
                    ac.Transferencia = Transferencia
                    ac.Cierre = True
                    If ac.ShowDialog() = System.Windows.Forms.DialogResult.OK AndAlso ac.Accion = "Corte" Then

                        'Valida si hay Complemento de Pago pendiente de Timbrar

                        actualizaComplementoPago()

                        Dim foundRows() As DataRow

                        foundRows = dtComplementoPago.Select("UUID ='Pendiente'")

                        If foundRows.GetLength(0) > 0 Then

                            Select Case MessageBox.Show("Existen complementos de pago pendientes de Certificar. ¿Desea continuar y cerrar Sin certificarlos?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                                Case System.Windows.Forms.DialogResult.No
                                    e.Cancel = True
                                    Exit Sub
                            End Select

                        End If


                        If Transferencia = 1 Then
                            Dim bCancel As Boolean = False
                            Dim bTransBanco As Boolean = False
                            Do
                                Dim a As New FrmTransBanco
                                a.InterfazSalida = InterfazSalida
                                a.IdCorte = IDCorte
                                a.CAJClave = CAJClave
                                If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                    bTransBanco = True
                                ElseIf a.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                                    bTransBanco = True
                                    bCancel = True
                                Else
                                    If a.iTransBanco = 0 Then
                                        bTransBanco = True
                                    End If
                                End If

                            Loop While bTransBanco = False

                            If bCancel = True Then
                                e.Cancel = True
                                Exit Sub
                            End If


                        Else

                            If CorteDetallado = 1 Then
                                Dim a As New FrmAperturaCaja
                                a.SUCClave = SUCClave
                                a.FormatoCorte = FormatoCorte
                                a.reciboTicket = Me.reciboTicket
                                a.LBTitulo.Text = "Corte de Caja al Cierre"
                                a.Accion = "Cierre"
                                a.CAJClave = CAJClave

                                a.Referencia = ClaveCaja
                                a.Impresora = Impresora
                                a.Generic = PrintGeneric
                                a.Recibo = Recibo
                                a.IDCorte = IDCorte
                                a.BtnCancelar.Visible = True
                                a.Cajon = Cajon
                                If a.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then

                                    e.Cancel = True
                                    Exit Sub
                                End If
                            Else
                                Dim a As New FrmAperturaSimple
                                a.SUCClave = SUCClave
                                a.FormatoCorte = FormatoCorte
                                a.reciboTicket = Me.reciboTicket
                                a.LBTitulo.Text = "Corte de Caja al Cierre"
                                a.Accion = "Cierre"
                                a.CAJClave = CAJClave
                                a.Referencia = ClaveCaja
                                a.Impresora = Impresora
                                a.Generic = PrintGeneric
                                a.Recibo = Recibo
                                a.IDCorte = IDCorte
                                a.BtnCancelar.Visible = True
                                a.Cajon = Cajon
                                If a.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If

                        End If

                    ElseIf ac.Accion = "PreCorte" Then
                        Dim StopPrint As Boolean = False

                        If bPreCorte = False Then
                            Dim bAutorizado As Boolean = False
                            Dim bSalir As Boolean = False
                            Do

                                Dim a As New MeAutorizacion

                                a.Sucursal = SUCClave
                                a.sp = "st_filtra_precorte"
                                a.MontodeAutorizacion = 0
                                a.StartPosition = FormStartPosition.CenterScreen
                                If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                    bAutorizado = a.Autorizado
                                Else
                                    bSalir = True
                                End If

                            Loop While bAutorizado = False AndAlso bSalir = False


                            If bPreCorte = False AndAlso bAutorizado = False Then
                                e.Cancel = True
                                Exit Sub
                            End If

                        End If

                        Dim sPrintMessage As String = "¿Desea Reimprimir el Pre Corte de Caja?"
                        Do


                            If reciboTicket = 1 Then
                                imprimeTicketPreCorte(IDCorte, Impresora, PrintGeneric, Recibo)
                            Else
                                Dim OpenReport As New Report
                                Dim pvtaDataSet As New DataSet
                                pvtaDataSet.DataSetName = "pvtaDataSet"

                                If Transferencia = 1 Then
                                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco_enc", "@IdCorte", IDCorte))
                                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco", "@IdCorte", IDCorte))
                                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_reembolso", "@IdCorte", IDCorte))
                                    OpenReport.PrintPreview("Acumulado", "CRAcumulado.rpt", pvtaDataSet, "")
                                Else
                                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco_enc", "@IdCorte", IDCorte))
                                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_acumulado", "@IdCorte", IDCorte))
                                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_cobranzaCredito", "@IDCorte", IDCorte))
                                    OpenReport.PrintPreview("Acumulado", "CRAcumula.rpt", pvtaDataSet, "")
                                End If
                            End If

                            Select Case MessageBox.Show(sPrintMessage, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                Case DialogResult.No
                                    StopPrint = True
                            End Select

                        Loop While Not StopPrint

                        e.Cancel = True
                        Exit Sub
                    ElseIf ac.Accion = "" Then
                        e.Cancel = True
                        Exit Sub
                    End If
                Else

                    'Valida si hay Complemento de Pago pendiente de Timbrar

                    actualizaComplementoPago()

                    Dim foundRows() As DataRow

                    foundRows = dtComplementoPago.Select("UUID ='Pendiente'")

                    If foundRows.GetLength(0) > 0 Then

                        Select Case MessageBox.Show("Existen complementos de pago pendientes de Certificar. ¿Desea continuar y cerrar Sin certificarlos?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                            Case System.Windows.Forms.DialogResult.No
                                e.Cancel = True
                                Exit Sub
                        End Select

                    End If



                    If Transferencia = 1 Then
                        Dim bCancel As Boolean = False
                        Dim bTransBanco As Boolean = False
                        Do
                            Dim a As New FrmTransBanco
                            a.InterfazSalida = InterfazSalida
                            a.IdCorte = IDCorte
                            a.CAJClave = CAJClave
                            If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                bTransBanco = True
                            ElseIf a.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                                bTransBanco = True
                                bCancel = True
                            Else
                                If a.iTransBanco = 0 Then
                                    bTransBanco = True
                                End If
                            End If

                        Loop While bTransBanco = False


                        If bCancel = True Then
                            e.Cancel = True
                            Exit Sub
                        End If

                    Else
                        If CorteDetallado = 1 Then
                            Dim a As New FrmAperturaCaja
                            a.SUCClave = SUCClave
                            a.FormatoCorte = FormatoCorte
                            a.reciboTicket = Me.reciboTicket
                            a.LBTitulo.Text = "Corte de Caja al Cierre"
                            a.Accion = "Cierre"
                            a.CAJClave = CAJClave
                            a.Referencia = ClaveCaja
                            a.Impresora = Impresora
                            a.Generic = PrintGeneric
                            a.Recibo = Recibo
                            a.IDCorte = IDCorte
                            a.BtnCancelar.Visible = True
                            a.Cajon = Cajon
                            If a.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                                e.Cancel = True
                                Exit Sub
                            End If
                        Else
                            Dim a As New FrmAperturaSimple
                            a.SUCClave = SUCClave
                            a.FormatoCorte = FormatoCorte
                            a.reciboTicket = Me.reciboTicket
                            a.LBTitulo.Text = "Corte de Caja al Cierre"
                            a.Accion = "Cierre"
                            a.CAJClave = CAJClave
                            a.Referencia = ClaveCaja
                            a.Impresora = Impresora
                            a.Generic = PrintGeneric
                            a.Recibo = Recibo
                            a.IDCorte = IDCorte
                            a.BtnCancelar.Visible = True
                            a.Cajon = Cajon
                            If a.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                                e.Cancel = True
                                Exit Sub
                            End If
                        End If

                    End If
                End If
            End If
        End If
        ModPOS.Ejecuta("sp_act_caja", "@CAJClave", CAJClave, "@Fase", 0)

        ModPOS.MtoCXC.Dispose()
        ModPOS.MtoCXC = Nothing
    End Sub


    Private Sub BtnPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPago.Click
        Dim idEvento As String = ""
        If cobranzaGeneral Then
            If Not dtCxC Is Nothing Then

                Dim foundRows() As DataRow

                foundRows = dtCxC.Select("Marca ='True' and SaldoBase > 0")

                If foundRows.GetLength(0) > 0 Then

                    Dim fr() As DataRow
                    fr = dtCxC.Select("Marca ='True' and SaldoBase > 0 and CTEClave <> '" & foundRows(0)("CTEClave") & "'")

                    If fr.GetLength(0) >= 1 Then
                        MessageBox.Show("No es posible realizar pagos de diferentes clientes a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        TxtFolio.Text = ""
                        TxtFolio.Focus()
                        Exit Sub
                    End If

                    If CobranzaVenta = True Then
                        fr = dtCxC.Select("Marca ='True' and TipoDocumento = 1 and Tipo <> 'Contado'")
                        If fr.GetLength(0) > 0 Then
                            BtnFacturar.PerformClick()
                            TxtFolio.Text = ""
                            TxtFolio.Focus()
                            Exit Sub
                        End If
                    End If


                    Dim dtDoctos As DataTable
                    dtDoctos = foundRows.CopyToDataTable()

                    Dim foundRowsFac() As DataRow
                    foundRowsFac = dtDoctos.Select("TipoDocumento=2")
                    If foundRowsFac.GetLength(0) > 0 AndAlso Me.LimitarCobrosFactura = 1 Then
                        If ModPOS.ValidaCobroFactura(foundRowsFac.CopyToDataTable(), IDCorte) = False Then
                            Exit Sub
                        End If
                    End If


                    Dim SaldoDoctos As Decimal = IIf(dtDoctos.Compute("Sum(SaldoBase)", "SaldoBase > 0") Is System.DBNull.Value, 0, dtDoctos.Compute("Sum(SaldoBase)", "SaldoBase > 0"))

                    If SaldoDoctos > 0 Then
                        Dim a As New FrmAbono
                        a.SUCClave = SUCClave
                        a.dtDocumentos = dtDoctos
                        a.InterfazSalida = InterfazSalida
                        a.Aplicacion = Aplicacion
                        a.VariosPagos = IIf(dtDoctos.Rows.Count = 1, False, True)
                        a.TipoDocumento = dtDoctos.Rows(0)("TipoDocumento")
                        a.CAJA = CAJClave
                        a.ClaveCaja = ClaveCaja
                        a.ClaveCte = dtDoctos.Rows(0)("CTEClave")
                        a.ClaveDocumento = dtDoctos.Rows(0)("ID")
                        a.SaldoAcumulado = SaldoDoctos
                        a.AperturaCajon = Cajon
                        a.ImpresoraCajon = Impresora
                        a.ConfirmarAbono = ConfirmarAbono
                        If ClaveCaja.Length >= 3 Then
                            a.sIdTerminal = SucursalClave + ClaveCaja.Substring(ClaveCaja.Length - 3, 3)
                        Else
                            a.sIdTerminal = SucursalClave + ClaveCaja
                        End If

                        If ClaveCaja.Length >= 4 Then
                            a.PinPadNumero = SucursalClave.PadLeft(4, "0"c) + ClaveCaja.Substring(ClaveCaja.Length - 4, 4).PadLeft(4, "0"c)
                        Else
                            a.PinPadNumero = SucursalClave.PadLeft(4, "0"c) + ClaveCaja.PadLeft(4, "0"c)
                        End If

                        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                            If a.detallePago.Rows.Count > 0 Then

                                Dim i As Integer
                                Dim sFolio, sFecha As String
                                Dim dtInterfaz As DataTable = Nothing
                                idEvento = IIf(idEventoGlobal = "", a.id_evento, idEventoGlobal)

                                If InterfazSalida <> "" AndAlso (dtDoctos.Rows(0)("TipoDocumento") = 2 OrElse dtDoctos.Rows(0)("TipoDocumento") = 6) Then
                                    dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Cobros", "@COMClave", ModPOS.CompanyActual)
                                End If

                                For i = 0 To a.detallePago.Rows.Count - 1

                                    ModPOS.Aplica_Pagos(dtDoctos, dtDoctos.Rows(0)("CTEClave"), a.detallePago.Rows(i)("ABNClave"), a.detallePago.Rows(i)("TipoPago"), a.detallePago.Rows(i)("SaldoBase"), CAJClave, 1, a.detallePago.Rows(i)("FechaPago"), idEvento, TallaColor, reciboTicket, FormatoRecibo, Impresora)

                                    If InterfazSalida <> "" AndAlso (dtDoctos.Rows(0)("TipoDocumento") = 2 OrElse dtDoctos.Rows(0)("TipoDocumento") = 6) AndAlso TallaColor = 0 Then
                                        sFolio = a.detallePago.Rows(i)("ABNClave")
                                        sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")
                                        If Not dtInterfaz Is Nothing AndAlso dtInterfaz.Rows.Count > 0 Then
                                            ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sFolio, "@TipoDocumento", a.detallePago.Rows(i)("TipoPago"), "@Path", InterfazSalida, "@Fecha", sFecha, "@Tipo", CInt(dtDoctos.Rows(0)("TipoDocumento")))
                                        End If
                                    End If

                                Next


                                Dim comprobacionPago As Decimal = 0
                                For i = 0 To dtDoctos.Rows.Count - 1
                                    Dim dts As DataTable = ModPOS.Recupera_Tabla("sp_recupera_saldo", "@Tipo", dtDoctos.Rows(i)("TipoDocumento"), "@Clave", dtDoctos.Rows(i)("ID"))
                                    If dts.Rows(0)("Tipo") = "Contado" Then
                                        comprobacionPago += dts.Rows(0)("Saldo")
                                    End If
                                Next

                                If Math.Round(comprobacionPago, 2) > 0 Then
                                    MessageBox.Show("Se detecto un faltante de Cobro por " & Format(CStr(Math.Round(comprobacionPago, 2)), "Currency"), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Sub
                                End If


                                If TallaColor AndAlso InterfazSalida <> "" Then

                                    If dtDoctos.Rows(0)("TipoDocumento") = 1 Then
                                        dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Pedidos", "@COMClave", ModPOS.CompanyActual)
                                        If Not dtInterfaz Is Nothing AndAlso dtInterfaz.Rows.Count > 0 Then
                                            For i = 0 To dtDoctos.Rows.Count - 1
                                                sFecha = DateTime.Now.AddSeconds(i).ToString("yyyyMMdd_HHmmssfff")
                                                ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", dtDoctos.Rows(i)("ID"), "@TipoDocumento", dtDoctos.Rows(i)("TipoDocumento"), "@Path", InterfazSalida, "@Fecha", sFecha)
                                            Next
                                        End If

                                    End If

                                    dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Cobros", "@COMClave", ModPOS.CompanyActual)

                                    If Not dtInterfaz Is Nothing AndAlso dtInterfaz.Rows.Count > 0 Then
                                        'For i = 0 To dtDoctos.Rows.Count - 1
                                        sFecha = DateTime.Now.AddSeconds(dtDoctos.Rows.Count + 1).ToString("yyyyMMdd_HHmmssfff")
                                        'ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", dtDoctos.Rows(i)("ID"), "@TipoDocumento", dtDoctos.Rows(0)("TipoDocumento"), "@Path", InterfazSalida, "@Fecha", sFecha, "@Tipo", CInt(dtDoctos.Rows(0)("TipoDocumento")))
                                        ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", idEvento, "@TipoDocumento", dtDoctos.Rows(0)("TipoDocumento"), "@Path", InterfazSalida, "@Fecha", sFecha, "@Tipo", CInt(dtDoctos.Rows(0)("TipoDocumento")))
                                        'Next
                                        idEvento = ""
                                        idEventoGlobal = ""
                                    End If

                                End If

                                If TallaColor = 1 Then
                                    Dim PrintTickets() As DataRow
                                    PrintTickets = dtDoctos.Select("TipoDocumento = 1 and Tipo = 'Contado' ")
                                    If PrintTickets.Length > 0 Then
                                        Dim k As Integer
                                        For k = 0 To PrintTickets.Length - 1
                                            Dim proximaCat As String = ""
                                            Dim dtProximaCat As DataTable = Recupera_Tabla("st_recupera_proximaCategoria", "@CTEClave", dtDoctos.Rows(0)("CTEClave"))
                                            If Not dtProximaCat Is Nothing Then
                                                proximaCat = IIf(dtProximaCat.Rows(0)("Total") < 0, "0", dtProximaCat.Rows(0)("Total").ToString())
                                            End If
                                            previewPedido(FormatoPedido, PrintTickets(k)("ID"), PrintTickets(k)("Total"), SUCClave, Impresora, True, 1, False, False, a.TotalCambio.ToString(), proximaCat, PrintGeneric)

                                        Next
                                    End If

                                End If


                                If a.TotalAbono > 0 Then

                                    If ConfirmarAbono = 1 Then
                                        Dim msg As New FrmMeMsg
                                        msg.TxtTiulo = "Su Cambio es:"
                                        msg.TxtMsg = RefMoneda & " " & Format(CStr(Math.Round(a.TotalCambio, 2)), "Currency")
                                        msg.TxtMsg2 = Letras(CStr(Math.Round(a.TotalCambio, 2))).ToUpper & " " & RefMoneda

                                        msg.StartPosition = FormStartPosition.CenterScreen
                                        msg.BringToFront()
                                        If msg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                        End If
                                        msg.Dispose()
                                    End If

                                    If reciboTicket = 1 Then

                                        Select Case MessageBox.Show("¿Desea imprimir Recibo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                            Case DialogResult.Yes
                                                imprimeRecibo(a.detallePago, a.TotalAbono, Math.Round(a.TotalCambio, 2), Impresora, PrintGeneric, Recibo, MPrincipal.StUsuario.Text, a.ClaveCliente, a.NombreCliente, a.Nota)
                                                Dim reimprimir As Boolean = True

                                                Do
                                                    Select Case MessageBox.Show("¿Desea reimprimir Recibo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                                        Case DialogResult.Yes
                                                            imprimeRecibo(a.detallePago, a.TotalAbono, Math.Round(a.TotalCambio, 2), Impresora, PrintGeneric, Recibo, MPrincipal.StUsuario.Text, a.ClaveCliente, a.NombreCliente, a.Nota)
                                                        Case System.Windows.Forms.DialogResult.No
                                                            reimprimir = False
                                                    End Select
                                                Loop While reimprimir = True
                                        End Select

                                    End If


                                    If CobranzaVenta = True AndAlso a.Pagado = True Then
                                        fr = dtDoctos.Select("Marca ='True' and TipoDocumento = 1 and Tipo = 'Contado'")
                                        If fr.GetLength(0) > 0 Then
                                            If CBool(fr(0)("Facturable")) = True Then
                                                Factura_Automatica(fr)
                                            End If
                                        End If
                                    End If

                                End If

                                dtCxC.Dispose()
                                TxtFolio.Text = ""
                                TxtFolio.Focus()
                                AgregarFolio()
                                RetiroProgramado()

                            End If
                            TxtFolio.Text = ""
                            TxtFolio.Focus()
                        Else
                            interfazTallaColor = True
                        End If
                    Else
                        dtCxC.Dispose()
                        TxtFolio.Text = ""
                        TxtFolio.Focus()
                        AgregarFolio()
                    End If
                Else
                    MessageBox.Show("Debe marcar por lo menos un registro con Saldo mayor a Cero", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Else 'Tab de CXC
            PagoCreditos()
        End If
    End Sub

    Public Sub RetiroProgramado()
        'Solicita Retiro de Caja

        If IDCorte <> "" AndAlso MaxEfectivo > 0 Then
            Dim dt As DataTable
            dt = Recupera_Tabla("st_recupera_efectivo", "@IDCorte", IDCorte)
            Dim MontoEfectivo As Decimal
            Dim FondoCaja As Decimal
            If dt.Rows.Count > 0 Then
                MontoEfectivo = CDec(dt.Rows(0)("Efectivo")) - CDec(dt.Rows(0)("FondoCaja"))

                If MontoEfectivo >= MaxEfectivo Then
                    MessageBox.Show("El monto de fectivo maximo recomendado (" & Strings.Format(Redondear(MaxEfectivo, 2).ToString, "Currency") & ") se ha excedido. Le recordamos realizar el retiro de fectivo de caja", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)


                    Dim a As New FrmRetiroCaja
                    a.bRetiroProgramado = True
                    a.SUCClave = SUCClave
                    a.ALMClave = ALMClave
                    a.CAJClave = CAJClave
                    a.Referencia = ClaveCaja
                    a.Impresora = Impresora
                    a.Generic = PrintGeneric
                    a.Ticket = Recibo
                    a.Cajon = Cajon
                    If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    End If

                End If

            End If
            dt.Dispose()
        End If

    End Sub



    Private Sub PagoCreditos()
        If CTEClave <> "" Then
            Dim a As New FrmPagoCXC
            a.TallaColor = Me.TallaColor
            a.TICDevolucion = Me.TICDevolucion
            a.InterfazSalida = InterfazSalida
            a.CAJClave = CAJClave
            a.Cajon = Cajon
            a.RefMoneda = RefMoneda
            a.sCTEClave = Me.CTEClave
            a.sRazonSocial = Me.sRazonSocial
            a.Impresora = Me.Impresora
            a.SUCClave = Me.SUCClave
            a.FormatoFactura = Me.FormatoFactura
            a.FormatoPedido = Me.FormatoPedido
            a.FormatoRecibo = Me.FormatoRecibo
            a.reciboTicket = Me.reciboTicket
            a.PrintGeneric = Me.PrintGeneric
            a.Recibo = Me.Recibo
            a.ConfirmarAbono = Me.ConfirmarAbono
            a.idCorte = Me.IDCorte
            a.LimitarCobrosFactura = Me.LimitarCobrosFactura
            If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                RetiroProgramado()

            End If
            a.Dispose()
        End If
    End Sub



    Public Sub actualizaGridCreditos()
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(False, Me.GridCreditos, "sp_obtener_cobranza", "@SUCClave", SUCClave)
        Me.GridCreditos.RootTable.Columns("CTEClave").Visible = False

        Me.GridCreditos.RootTable.Columns("Clave").Width = 50
        Me.GridCreditos.RootTable.Columns("RFC").Width = 50
        Me.GridCreditos.RootTable.Columns("RazonSocial").Width = 120
        Me.GridCreditos.RootTable.Columns("Contacto").Width = 70
        Me.GridCreditos.RootTable.Columns("Tel1").Width = 40
        Me.GridCreditos.RootTable.Columns("email").Width = 60
        Me.GridCreditos.RootTable.Columns("Limite").Width = 30
        Me.GridCreditos.RootTable.Columns("DiasCredito").Width = 20
        Me.GridCreditos.RootTable.Columns("Cobranza").Width = 50
        ' GridCreditos.AutoSizeColumns()
        Cursor.Current = Cursors.Default
    End Sub

    Public Sub ActualizaGridAbonos()
        If validaForm() Then

            ModPOS.ActualizaGrid(False, Me.gridAbonos, "sp_recupera_abonos", "@Campo", CmbFiltro.SelectedValue, "@Busqueda", TxtBusqueda.Text.Trim.ToUpper.Replace("'", "''"), "@Inicio", CmbFecha.Value, "@Fin", CmbFecha.Value.AddHours(23.9999))
            Me.gridAbonos.RootTable.Columns("ID").Visible = False
            Me.gridAbonos.RootTable.Columns("Metodo").Width = 50
            Me.gridAbonos.RootTable.Columns("Ref").Width = 30
            Me.gridAbonos.RootTable.Columns("Folio").Width = 90
            Me.gridAbonos.RootTable.Columns("Importe").Width = 70
            Me.gridAbonos.RootTable.Columns("Saldo").Width = 50
            Me.gridAbonos.RootTable.Columns("Aplicado").Width = 50
            Me.gridAbonos.RootTable.Columns("Clave").Width = 70
            Me.gridAbonos.RootTable.Columns("Razón Social").Width = 190
            Me.gridAbonos.RootTable.Columns("Nota").Visible = False
            Me.gridAbonos.RootTable.Columns("Banco").Visible = False
            Me.gridAbonos.RootTable.Columns("NumCta").Visible = False
            Me.gridAbonos.RootTable.Columns("MONClave").Visible = False
            Me.gridAbonos.RootTable.Columns("TipoPago").Visible = False
            Me.gridAbonos.RootTable.Columns("idPago").Visible = False
            gridAbonos.RootTable.Columns("Importe").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            gridAbonos.RootTable.Columns("Saldo").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            gridAbonos.RootTable.Columns("Aplicado").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Public Sub actualizaGridApartados()
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(False, Me.gridApartados, "st_recupera_apartados", "@SUCClave", SUCClave)
        Me.gridApartados.RootTable.Columns("CTEClave").Visible = False

        Me.gridApartados.RootTable.Columns("Clave").Width = 50
        Me.gridApartados.RootTable.Columns("RFC").Width = 50
        Me.gridApartados.RootTable.Columns("RazonSocial").Width = 120
        Me.gridApartados.RootTable.Columns("Contacto").Width = 70
        Me.gridApartados.RootTable.Columns("Tel1").Width = 40
        Me.gridApartados.RootTable.Columns("email").Width = 60
        Me.gridApartados.RootTable.Columns("Apartados").Width = 50
        Cursor.Current = Cursors.Default
    End Sub


    Public Sub actualizaGridPendientes()
        Cursor.Current = Cursors.WaitCursor


        dtPendientes = ModPOS.Recupera_Tabla("sp_obtener_pendientes", "@SUCClave", SUCClave)
        GridPendientes.DataSource = dtPendientes
        GridPendientes.RetrieveStructure(True)
        GridPendientes.RootTable.Columns("Periodo").Visible = False
        GridPendientes.RootTable.Columns("Tipo").Visible = False
        GridPendientes.RootTable.Columns("tipoDeComprobante").Visible = False
        GridPendientes.RootTable.Columns("Cliente").Visible = False
        GridPendientes.RootTable.Columns("Clave").Visible = False
        GridPendientes.RootTable.Columns("Version").Visible = False
        GridPendientes.RootTable.Columns("formaDePago").Visible = False
        GridPendientes.RootTable.Columns("RegimenFiscal").Visible = False
        GridPendientes.RootTable.Columns("Descuento").Visible = False
        GridPendientes.RootTable.Columns("TipoCF").Visible = False
        GridPendientes.RootTable.Columns("Estado").Visible = False
        GridPendientes.RootTable.Columns("Impuesto").Visible = False
        GridPendientes.RootTable.Columns("Global").Visible = False
        GridPendientes.RootTable.Columns("Email").Visible = False
        GridPendientes.RootTable.Columns("Logo").Visible = False

        GridPendientes.AutoSizeColumns()
        Cursor.Current = Cursors.Default
    End Sub



    Public Sub actualizaContrarecibos()
        PeriodoContra = dtPickerContrarecibo.Value.Year
        MesContra = dtPickerContrarecibo.Value.Month
        Cursor.Current = Cursors.WaitCursor
        dtContrarecibos = ModPOS.Recupera_Tabla("sp_busca_contrarecibos", "@Periodo", PeriodoContra, "@Mes", MesContra, "@Estado", Me.cmbEdoContrarecibo.SelectedValue, "@COMClave", ModPOS.CompanyActual)
        GridContrarecibos.DataSource = dtContrarecibos
        GridContrarecibos.RetrieveStructure(True)

        GridContrarecibos.RootTable.Columns("FACClave").Visible = False
        GridContrarecibos.AutoSizeColumns()

        Cursor.Current = Cursors.Default
    End Sub

    Public Sub actualizaComplementoPago()
        Dim fechaInicial, fechaFinal As Date
        fechaInicial = cmbCompInicial.Value.Date
        fechaFinal = cmbCompFinal.Value.Date

        If fechaInicial > fechaFinal Then
            MessageBox.Show("La fecha inicial no puede ser mayor que la final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Cursor.Current = Cursors.WaitCursor
        dtComplementoPago = ModPOS.Recupera_Tabla("st_recupera_complementoPago", "@Inicio", fechaInicial, "@Fin", fechaFinal.AddHours(23.9999), "@COMClave", ModPOS.CompanyActual)
        gridComplementoPago.DataSource = dtComplementoPago
        gridComplementoPago.RetrieveStructure(True)
        gridComplementoPago.RootTable.Columns("ABNClave").Visible = False
        gridComplementoPago.RootTable.Columns("email").Visible = False
        gridComplementoPago.RootTable.Columns("MONClave").Visible = False
        gridComplementoPago.RootTable.Columns("FechaSAT").Visible = False
        gridComplementoPago.AutoSizeColumns()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub BtnCancelaTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        If Not dtCxC Is Nothing Then

            Dim foundRows() As DataRow
            Dim bmotivo As Boolean = False
            Dim motCancelacion As Integer = -1

            foundRows = dtCxC.Select("Marca ='True'")

            If foundRows.GetLength(0) = 1 Then


                If foundRows(0)("TipoDocumento") = 1 OrElse foundRows(0)("TipoDocumento") = 3 Then
                    If foundRows(0)("Total") <> foundRows(0)("Saldo") Then
                        MessageBox.Show("El documento con Folio " & foundRows(0)("Folio") & " no es posible cancelarlo porque tiene pagos aplicados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                'Valida si tiene devoluciones aplicadas

                If foundRows(0)("TipoDocumento") = 1 OrElse foundRows(0)("TipoDocumento") = 2 Then
                    Dim dtDevo As DataTable = ModPOS.Recupera_Tabla("st_recupera_devoluciones_aplicadas", "@DOCClave", foundRows(0)("ID"), "@TipoDoc", foundRows(0)("TipoDocumento"))
                    If dtDevo.Rows.Count > 0 Then
                        MessageBox.Show("El documento con Folio " & foundRows(0)("Folio") & " no es posible cancelarlo porque tiene Devoluciones asociadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Dim b As New FrmConsultaGen
                        b.Text = "Devoluciones Asociadas"
                        b.GridConsultaGen.DataSource = dtDevo
                        b.GridConsultaGen.RetrieveStructure(True)
                        b.GridConsultaGen.GroupByBoxVisible = False
                        b.ShowDialog()
                        b.Dispose()
                        dtDevo.Dispose()
                        Exit Sub
                    End If
                    dtDevo.Dispose()
                End If


                Select Case MessageBox.Show("¿Esta seguro de Cancelar el documento " & foundRows(0)("Folio") & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        Dim a As New MeAutorizacion

                        a.Sucursal = SUCClave
                        a.MontodeAutorizacion = foundRows(0)("Total") * foundRows(0)("TipoCambio")
                        a.StartPosition = FormStartPosition.CenterScreen
                        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                            If a.Autorizado Then
                                Autoriza = a.Autoriza

                                Dim dt As DataTable
                                Dim TipoCF As Integer
                                Dim uuid, rfc As String
                                Dim estado As Integer
                                Dim sVersionCF As String

                                If foundRows(0)("TipoDocumento") = 1 Then 'Venta

                                    dt = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", foundRows(0)("ID"))
                                    If dt.Rows.Count > 0 Then
                                        If dt.Rows(0)("Estado") = 4 Then
                                            MessageBox.Show("El pedido seleccionado fue cancelado previamente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            AgregarFolio()
                                            Exit Sub
                                        End If
                                    End If

                                    Dim iTipoAplicacion As Integer = 0

                                    iTipoAplicacion = dt.Rows(0)("TipoAplicacion")

                                    Do
                                        Dim m As New FrmMotivo
                                        m.Tabla = "Venta"
                                        m.Campo = "Cancelacion"
                                        If m.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                            bmotivo = True
                                            motCancelacion = m.Motivo
                                        End If
                                        m.Dispose()
                                    Loop While bmotivo = False

                                    ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", foundRows(0)("ID"), "@TipoDoc", foundRows(0)("TipoDocumento"), "@Motivo", motCancelacion, "@Autoriza", Autoriza, "@TipoAplicacion", iTipoAplicacion)

                                    If StageCancelacion <> "" Then
                                        ModPOS.GeneraMovInv(1, 5, 1, foundRows(0)("ID"), ALMClave, foundRows(0)("Folio"), Autoriza, False, 1, StageCancelacion)
                                    Else
                                        ModPOS.GeneraMovInv(1, 5, 1, foundRows(0)("ID"), ALMClave, foundRows(0)("Folio"), Autoriza, False)
                                    End If

                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total") * foundRows(0)("TipoCambio"))

                                    ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(0)("ID"), "@Tipo", 1)

                                    'Inicia Cancelación

                                    'If TallaColor = 1 Then

                                    '    Dim sImpresora As String
                                    '    Dim iCopias As Integer = 1
                                    '    If PrinterInvoice <> "" Then
                                    '        sImpresora = PrinterInvoice
                                    '    Else
                                    '        If PrintDialog1.ShowDialog() = DialogResult.OK Then
                                    '            sImpresora = PrintDialog1.PrinterSettings.PrinterName
                                    '            iCopias = PrintDialog1.PrinterSettings.Copies
                                    '        Else
                                    '            Exit Sub
                                    '        End If
                                    '    End If

                                    '    If Impresora <> "" Then
                                    '        sImpresora = Impresora
                                    '    Else
                                    '        If PrintDialog1.ShowDialog() = DialogResult.OK Then
                                    '            sImpresora = PrintDialog1.PrinterSettings.PrinterName
                                    '            iCopias = PrintDialog1.PrinterSettings.Copies
                                    '        Else
                                    '            Exit Sub
                                    '        End If
                                    '    End If

                                    'previewPedido(FormatoPedido, foundRows(0)("ID"), foundRows(0)("Total"), SUCClave, sImpresora, True, iCopias, True, False, IIf(TallaColor = 1, "0", ""), IIf(TallaColor = 1, "0", ""), PrintGeneric)

                                    'End If


                                ElseIf foundRows(0)("TipoDocumento") = 2 Then 'Factura

                                    Do
                                        Dim m As New FrmMotivo
                                        m.Tabla = "Factura"
                                        m.Campo = "Cancelacion"
                                        If m.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                            bmotivo = True
                                            motCancelacion = m.Motivo
                                        End If
                                        m.Dispose()
                                    Loop While bmotivo = False


                                    dt = Recupera_Tabla("sp_recupera_fac", "@FACClave", foundRows(0)("ID"))
                                    TipoCF = dt.Rows(0)("TipoCF")
                                    uuid = dt.Rows(0)("UUID")
                                    rfc = dt.Rows(0)("id_Fiscal")
                                    estado = dt.Rows(0)("estado")
                                    sVersionCF = dt.Rows(0)("VersionCF")
                                    dt.Dispose()



                                    If TipoCF = 2 AndAlso estado = 1 Then

                                        If foundRows(0)("Total") <> foundRows(0)("Saldo") Then
                                            MessageBox.Show("EL documento con Folio " & foundRows(0)("Folio") & " no es posible cancelarlo porque tiene pagos aplicados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Exit Sub
                                        End If


                                        Dim eRFC, rRFC, sFolio As String
                                        dt = ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", foundRows(0)("ID"))
                                        eRFC = dt.Rows(0)("cRFC")
                                        rRFC = dt.Rows(0)("id_Fiscal")
                                        sFolio = dt.Rows(0)("Serie") & dt.Rows(0)("Folio")
                                        dt.Dispose()

                                        If ModPOS.cancelarXML(dtPAC, sFolio, uuid, eRFC, sVersionCF, foundRows(0)("TipoDocumento"), foundRows(0)("ID")) = False Then
                                            Exit Sub

                                        End If
                                    ElseIf estado = 3 Then
                                        If ModPOS.ObtenerEspera(dtPAC, rfc, foundRows(0)("TipoDocumento"), foundRows(0)("ID"), uuid) = False Then
                                            Exit Sub
                                        End If
                                    End If



                                    ModPOS.Ejecuta("sp_cancela_factura", "@FACClave", foundRows(0)("ID"), "@Motivo", motCancelacion, "@Autoriza", Autoriza)

                                    If StageCancelacion <> "" Then
                                        ModPOS.GeneraMovInv(1, 5, 2, foundRows(0)("ID"), ALMClave, foundRows(0)("Folio"), Autoriza, False, 1, StageCancelacion)
                                    Else
                                        ModPOS.GeneraMovInv(1, 5, 2, foundRows(0)("ID"), ALMClave, foundRows(0)("Folio"), Autoriza, False)
                                    End If

                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total") * foundRows(0)("TipoCambio"))

                                    ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(0)("ID"), "@Tipo", 2)

                                    If TipoCF = 2 AndAlso estado <> 1 Then
                                        ModPOS.Ejecuta("sp_libera_pagos_fac", "@FACClave", foundRows(0)("ID"))
                                    End If

                                    If InterfazSalida <> "" Then
                                        Dim sFecha As String
                                        Dim dtInterfaz As DataTable
                                        sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                                        dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CancelacionFactura", "@COMClave", ModPOS.CompanyActual)
                                        If dtInterfaz.Rows.Count > 0 Then
                                            ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", foundRows(0)("ID"), "@TipoDocumento", 0, "@Path", InterfazSalida, "@Fecha", sFecha)
                                        End If

                                    End If


                                ElseIf foundRows(0)("TipoDocumento") = 3 Then 'Cargo
                                    ModPOS.Ejecuta("sp_cancela_cargo", "@CARClave", foundRows(0)("ID"))

                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total") * foundRows(0)("TipoCambio"))


                                ElseIf foundRows(0)("TipoDocumento") = 4 Then ' NC

                                    If foundRows(0)("DevTipo") = 1 Then
                                        If VerificaExistencia(4, foundRows(0)("ID"), ALMClave) = False Then
                                            Exit Sub
                                        End If
                                    End If

                                    Do
                                        Dim m As New FrmMotivo
                                        m.Tabla = "NC"
                                        m.Campo = "Cancelacion"
                                        If m.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                            bmotivo = True
                                            motCancelacion = m.Motivo
                                        End If
                                        m.Dispose()
                                    Loop While bmotivo = False

                                    Dim eRFC, sFolio As String

                                    dt = Recupera_Tabla("sp_recupera_nc", "@NCClave", foundRows(0)("ID"))
                                    TipoCF = dt.Rows(0)("TipoCF")
                                    uuid = IIf(dt.Rows(0)("UUID").GetType.Name = "DBNull", "", dt.Rows(0)("UUID"))
                                    rfc = dt.Rows(0)("id_Fiscal")
                                    estado = dt.Rows(0)("estado")
                                    sVersionCF = dt.Rows(0)("VersionCF")
                                    sFolio = dt.Rows(0)("Serie") & dt.Rows(0)("Folio")
                                    dt.Dispose()

                                    If TipoCF = 2 AndAlso estado = 1 Then

                                        dt = Recupera_Tabla("sp_encabezado_nc", "@NCClave", foundRows(0)("ID"))
                                        eRFC = dt.Rows(0)("cRFC")
                                        dt.Dispose()

                                        If ModPOS.cancelarXML(dtPAC, sFolio, uuid, eRFC, sVersionCF, 4, foundRows(0)("ID")) = False Then
                                            Exit Sub
                                        End If
                                    ElseIf estado = 3 Then
                                        Dim bCancela As Boolean
                                        bCancela = ModPOS.ObtenerEspera(dtPAC, rfc, 4, foundRows(0)("ID"), uuid)
                                        If bCancela = False Then
                                            Exit Sub
                                        End If
                                    End If

                                    ModPOS.Ejecuta("sp_cancela_nc", "@NCClave", foundRows(0)("ID"), "@Motivo", motCancelacion, "@Autoriza", Autoriza)

                                    'Actualiza el Saldo del Documento
                                    ModPOS.Ejecuta("sp_act_saldo_fac", "@NCClave", foundRows(0)("ID"))
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total") * foundRows(0)("TipoCambio"))

                                    'Si es de tipo devolución, realiza salida de producto de almacén

                                    If foundRows(0)("DevTipo") = 1 Then
                                        ReubicaStage(4, foundRows(0)("ID"), ALMClave, Stage, Autoriza)
                                        ModPOS.GeneraMovInv(2, 5, 4, foundRows(0)("ID"), ALMClave, foundRows(0)("Folio"), Autoriza, False, 1, Stage)

                                    End If

                                ElseIf foundRows(0)("TipoDocumento") = 5 Then ' Devolución

                                    If VerificaExistencia(5, foundRows(0)("ID"), ALMClave) = False Then
                                        Exit Sub
                                    End If


                                    Do
                                        Dim m As New FrmMotivo
                                        m.Tabla = "NC"
                                        m.Campo = "Cancelacion"
                                        If m.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                            bmotivo = True
                                            motCancelacion = m.Motivo
                                        End If
                                        m.Dispose()
                                    Loop While bmotivo = False


                                    ModPOS.Ejecuta("sp_cancela_devolucion", "@DEVClave", foundRows(0)("ID"), "@Motivo", motCancelacion, "@Autoriza", Autoriza)

                                    'Actualiza el Saldo del Documento
                                    ModPOS.Ejecuta("sp_act_saldo_vta", "@DEVClave", foundRows(0)("ID"))
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total") * foundRows(0)("TipoCambio"))

                                    'Si es de tipo devolución, realiza salida de producto de almacén
                                    ReubicaStage(5, foundRows(0)("ID"), ALMClave, Stage, Autoriza)
                                    ModPOS.GeneraMovInv(2, 5, 3, foundRows(0)("ID"), ALMClave, foundRows(0)("Folio"), Autoriza, False, 1, Stage)


                                ElseIf foundRows(0)("TipoDocumento") = 6 Then ' Nota Cargo

                                    Do
                                        Dim m As New FrmMotivo
                                        m.Tabla = "Factura"
                                        m.Campo = "Cancelacion"
                                        If m.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                            bmotivo = True
                                            motCancelacion = m.Motivo
                                        End If
                                        m.Dispose()
                                    Loop While bmotivo = False

                                    dt = Recupera_Tabla("sp_recupera_cargo", "@CARClave", foundRows(0)("ID"))
                                    TipoCF = dt.Rows(0)("TipoCF")
                                    uuid = IIf(dt.Rows(0)("UUID").GetType.Name = "DBNull", "", dt.Rows(0)("UUID"))
                                    rfc = dt.Rows(0)("id_Fiscal")
                                    estado = dt.Rows(0)("estado")
                                    sVersionCF = dt.Rows(0)("VersionCF")
                                    dt.Dispose()



                                    If TipoCF = 2 AndAlso estado = 1 Then

                                        If foundRows(0)("Total") <> foundRows(0)("Saldo") Then
                                            MessageBox.Show("EL documento con Folio " & foundRows(0)("Folio") & " no es posible cancelarlo porque tiene pagos aplicados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Exit Sub
                                        End If

                                        Dim eRFC, sFolio As String
                                        dt = ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", foundRows(0)("ID"))
                                        eRFC = dt.Rows(0)("cRFC")
                                        sFolio = dt.Rows(0)("Serie") & dt.Rows(0)("Folio")
                                        dt.Dispose()

                                        If ModPOS.cancelarXML(dtPAC, sFolio, uuid, eRFC, sVersionCF, foundRows(0)("TipoDocumento"), foundRows(0)("ID")) = False Then
                                            Exit Sub
                                        End If
                                    ElseIf estado = 3 Then
                                        If ModPOS.ObtenerEspera(dtPAC, rfc, foundRows(0)("TipoDocumento"), foundRows(0)("ID"), uuid) = False Then
                                            Exit Sub
                                        End If
                                    End If


                                    ModPOS.Ejecuta("sp_cancela_notacargo", "@CARClave", foundRows(0)("ID"), "@Motivo", motCancelacion, "@Autoriza", Autoriza)

                                    'Actualiza el Saldo del Documento
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total") * foundRows(0)("TipoCambio"))

                                    If TipoCF = 2 AndAlso estado <> 1 Then
                                        ModPOS.Ejecuta("sp_libera_pagos_fac", "@FACClave", foundRows(0)("ID"))
                                    End If

                                    If InterfazSalida <> "" Then
                                        Dim sFecha As String
                                        Dim dtInterfaz As DataTable
                                        sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                                        dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CancelacionCargo", "@COMClave", ModPOS.CompanyActual)
                                        If dtInterfaz.Rows.Count > 0 Then
                                            ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", foundRows(0)("ID"), "@TipoDocumento", 0, "@Path", InterfazSalida, "@Fecha", sFecha)
                                        End If

                                    End If


                                End If
                            End If
                        End If
                        a.Dispose()
                End Select

                AgregarFolio()
            Else
                MessageBox.Show("Debe marcar solo el documento que desea cancelar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub BtnDevolucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDevolucion.Click

        Dim foundRows() As DataRow

        foundRows = dtCxC.Select("Marca ='True' and TipoDocumento = 1")

        If foundRows.GetLength(0) = 1 Then

            'foundRows(0)("ID")

            If ModPOS.Devolucion Is Nothing Then
                ModPOS.Devolucion = New FrmDevolucion
                ModPOS.Devolucion.Padre = "Caja"
                ModPOS.Devolucion.ActivaDevolucion = True
                ModPOS.Devolucion.ActivaCaja = True
                ModPOS.Devolucion.CAJClave = CAJClave
                ModPOS.Devolucion.Referencia = Clave
                ModPOS.Devolucion.Atiende = MPrincipal.StUsuario.Text
                ModPOS.Devolucion.SUCClave = SUCClave
                ModPOS.Devolucion.ALMClave = ALMClave
                ModPOS.Devolucion.Impresora = Impresora
                ModPOS.Devolucion.reciboTicket = reciboTicket
                ModPOS.Devolucion.TicketDev = TICDevolucion
                ModPOS.Devolucion.Caja = LblDescripcion.Text
                ModPOS.Devolucion.Cajon = Cajon
                ModPOS.Devolucion.Ventas = foundRows
                ModPOS.Devolucion.bLiquidacion = True
            End If
            ModPOS.Devolucion.StartPosition = FormStartPosition.CenterScreen
            If ModPOS.Devolucion.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            End If
        Else
            If ModPOS.Devolucion Is Nothing Then
                ModPOS.Devolucion = New FrmDevolucion
                ModPOS.Devolucion.Padre = "Caja"
                ModPOS.Devolucion.ActivaDevolucion = True
                ModPOS.Devolucion.ActivaCaja = True
                ModPOS.Devolucion.CAJClave = CAJClave
                ModPOS.Devolucion.Referencia = Clave
                ModPOS.Devolucion.Atiende = MPrincipal.StUsuario.Text
                ModPOS.Devolucion.SUCClave = SUCClave
                ModPOS.Devolucion.ALMClave = ALMClave
                ModPOS.Devolucion.Impresora = Impresora
                ModPOS.Devolucion.reciboTicket = reciboTicket
                ModPOS.Devolucion.TicketDev = TICDevolucion
                ModPOS.Devolucion.Caja = LblDescripcion.Text
                ModPOS.Devolucion.Cajon = Cajon
            End If
            ModPOS.Devolucion.StartPosition = FormStartPosition.CenterScreen
            If ModPOS.Devolucion.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            End If
        End If

        AgregarFolio()


    End Sub

    Private Sub BtnFacturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFacturar.Click

        Dim foundRows() As DataRow

        foundRows = dtCxC.Select("Marca ='True' and TipoDocumento=1")

        If foundRows.GetLength(0) >= 1 Then

            Dim fr() As DataRow
            fr = dtCxC.Select("Marca ='True' and TipoDocumento=1 and RFC <> '" & foundRows(0)("RFC") & "'")

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir ventas de diferentes clientes en una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            fr = dtCxC.Select("Marca ='True' and TipoDocumento=1 and TipoImpuesto <> " & CStr(foundRows(0)("TipoImpuesto")))

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir ventas de diferentes Tipos de Impuesto (General/Frontera) de clientes en una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            fr = dtCxC.Select("Marca ='True' and TipoDocumento=1 and MONClave <> '" & foundRows(0)("MONClave") & "'")

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir ventas de diferentes Monedas en una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            fr = dtCxC.Select("Marca ='True' and TipoDocumento=1 and MONClave = '" & foundRows(0)("MONClave") & "' and TipoCambio <> " & CStr(foundRows(0)("TipoCambio")))

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir ventas de Tipo de Cambio Diferente en una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            fr = dtCxC.Select("Marca ='True' and TipoDocumento=1 and Tipo <> '" & foundRows(0)("Tipo") & "'")

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir ventas de  Crédito y Contado en la misma factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            If ModPOS.Factura Is Nothing Then
                ModPOS.Factura = New FrmFactura
                ModPOS.Factura.SUCClave = SUCClave
                ModPOS.Factura.CAJClave = CAJClave
                ModPOS.Factura.CajaActiva = True
                ModPOS.Factura.Cajero = LblUsuario.Text
                ModPOS.Factura.PrintGeneric = PrintGeneric
                ModPOS.Factura.Recibo = Recibo
                ModPOS.Factura.Cajon = Cajon
                ModPOS.Factura.ImpresoraCajon = Impresora
                ModPOS.Factura.Ventas = foundRows
                ModPOS.Factura.ClienteInicial = Mostrador
            End If
            ModPOS.Factura.StartPosition = FormStartPosition.CenterScreen
            If ModPOS.Factura.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                interfazTallaColor = True
            End If
            If Not ModPOS.Factura Is Nothing Then
                ModPOS.Factura.BringToFront()
            End If

        Else

            If ModPOS.Factura Is Nothing Then
                ModPOS.Factura = New FrmFactura
                ModPOS.Factura.SUCClave = SUCClave
                ModPOS.Factura.CAJClave = CAJClave
                ModPOS.Factura.CajaActiva = True
                ModPOS.Factura.Cajero = LblUsuario.Text
                ModPOS.Factura.PrintGeneric = PrintGeneric
                ModPOS.Factura.Recibo = Recibo
                ModPOS.Factura.Cajon = Cajon
                ModPOS.Factura.ImpresoraCajon = Impresora
                ModPOS.Factura.ClienteInicial = Mostrador
            End If
            ModPOS.Factura.StartPosition = FormStartPosition.CenterScreen
            If ModPOS.Factura.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
                interfazTallaColor = True
            End If

            If Not ModPOS.Factura Is Nothing Then
                ModPOS.Factura.BringToFront()
            End If


        End If

    End Sub

    Private Sub BtnRecibo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecibo.Click
        If Not gridAbonos.GetValue(0) Is Nothing Then

            If gridAbonos.GetValue("TipoPago") = "99" Then
                ImprimeVale(gridAbonos.GetValue(0), Impresora, Recibo, True, 1, True, PrintGeneric)
                Return
            End If

            'INICIO
            If reciboTicket = 1 Then

                Dim dtDetallePago As DataTable = ModPOS.CrearTabla("DetallePago", _
              "ABNClave", "System.String", _
              "Metodo", "System.String", _
              "Monto", "System.Double", _
              "Banco", "System.String", _
              "Ref", "System.String", _
              "NumCta", "System.String", _
              "Cliente", "System.String", _
              "Nombre", "System.String", _
              "Nota", "System.String", _
              "TipoCambio", "System.Decimal")

                Dim row1 As DataRow
                row1 = dtDetallePago.NewRow()
                'declara el nombre de la fila



                row1.Item("ABNClave") = gridAbonos.GetValue("ID")
                row1.Item("Metodo") = gridAbonos.GetValue("Metodo")
                row1.Item("Monto") = gridAbonos.GetValue("Importe")
                row1.Item("Banco") = gridAbonos.GetValue("Banco")
                row1.Item("Ref") = gridAbonos.GetValue("Ref")
                row1.Item("NumCta") = gridAbonos.GetValue("NumCta")
                row1.Item("Cliente") = gridAbonos.GetValue("Clave")
                row1.Item("Nombre") = gridAbonos.GetValue("Razón Social")
                row1.Item("Nota") = gridAbonos.GetValue("Nota")
                row1.Item("TipoCambio") = gridAbonos.GetValue("TipoCambio")

                dtDetallePago.Rows.Add(row1)



                imprimeRecibo(dtDetallePago, dtDetallePago.Rows(0)("Monto"), 0, Impresora, PrintGeneric, Recibo, MPrincipal.StUsuario.Text, dtDetallePago.Rows(0)("Cliente"), dtDetallePago.Rows(0)("Nombre"), dtDetallePago.Rows(0)("Nota"))

            Else
                Dim copias As Integer = 1
                Dim metodo As String = gridAbonos.GetValue("Metodo")
                If TallaColor = 1 AndAlso metodo.Contains("Tarjeta") Then
                    copias = 2
                End If
                imprimirRecibo(gridAbonos.GetValue("ID"), FormatoRecibo, True, Impresora, 0, "REIMPRESIÓN", copias)
            End If



            'FIN


        Else
            MessageBox.Show("Debe seleccionar el abono que desea imprimir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNC.Click
        Dim foundRows() As DataRow
        foundRows = dtCxC.Select("Marca ='True'")

        foundRows = dtCxC.Select("Marca ='True' and TipoDocumento = 2 ")

        If foundRows.GetLength(0) > 1 Then

            Dim fr() As DataRow
            fr = dtCxC.Select("Marca ='True' and TipoDocumento = 2 and RFC <> '" & foundRows(0)("RFC") & "'")

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir Facturas de diferentes clientes ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            fr = dtCxC.Select("Marca ='True' and TipoDocumento=2 and TipoImpuesto <> " & CStr(foundRows(0)("TipoImpuesto")))

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir facturas de diferentes Tipos de Impuesto (General/Frontera) de clientes ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            fr = dtCxC.Select("Marca ='True' and TipoDocumento=2 and MONClave <> '" & foundRows(0)("MONClave") & "'")

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir facturas de diferentes Monedas ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            fr = dtCxC.Select("Marca ='True' and TipoDocumento=2 and MONClave = '" & foundRows(0)("MONClave") & "' and TipoCambio <> " & CStr(foundRows(0)("TipoCambio")))

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir facturas de Tipo de Cambio Diferente ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


        End If

        Dim a As New FrmFiltroNC
        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            If a.Tipo = 1 Then

                foundRows = dtCxC.Select("Marca ='True' and TipoDocumento = 2 ")

                If foundRows.GetLength(0) = 1 Then
                    If ModPOS.NC Is Nothing Then
                        ModPOS.NC = New FrmNC
                        ModPOS.NC.ALMClave = ALMClave
                        ModPOS.NC.SUCClave = SUCClave
                        ModPOS.NC.CAJClave = CAJClave
                        ModPOS.NC.Cajon = Cajon
                        ModPOS.NC.PrinterName = Impresora
                        ModPOS.NC.Facturas = foundRows
                    End If
                    ModPOS.NC.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.NC.Show()
                    If Not ModPOS.NC Is Nothing Then
                        ModPOS.NC.BringToFront()
                    End If
                Else
                    MessageBox.Show("Debe marcar solo el documento al que desea aplicar la devolución", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf a.Tipo = 2 Then
                If ModPOS.DevSin Is Nothing Then
                    ModPOS.DevSin = New FrmDevSin
                    ModPOS.DevSin.ALMClave = ALMClave
                    ModPOS.DevSin.SUCClave = SUCClave
                    ModPOS.DevSin.CAJClave = CAJClave
                End If
                ModPOS.DevSin.StartPosition = FormStartPosition.CenterScreen
                ModPOS.DevSin.Show()
                If Not ModPOS.DevSin Is Nothing Then
                    ModPOS.DevSin.BringToFront()
                End If
            ElseIf a.Tipo = 3 Then
                If ModPOS.Bonificacion Is Nothing Then
                    ModPOS.Bonificacion = New FrmBonificacion
                    ModPOS.Bonificacion.SUCClave = SUCClave
                    ModPOS.Bonificacion.CAJClave = CAJClave
                    ModPOS.Bonificacion.Facturas = foundRows
                End If

                ModPOS.Bonificacion.StartPosition = FormStartPosition.CenterScreen
                ModPOS.Bonificacion.Show()
                If Not ModPOS.Bonificacion Is Nothing Then
                    ModPOS.Bonificacion.BringToFront()
                End If
            End If
        End If



    End Sub

    Private Sub GridCreditos_CurrentCellChanging(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.CurrentCellChangingEventArgs) Handles GridCreditos.CurrentCellChanging
        GridCreditos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
    End Sub

    Private Sub GridCreditos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridCreditos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnPago.PerformClick()
        End If
    End Sub


    Private Sub GridPendientes_CurrentCellChanging(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.CurrentCellChangingEventArgs) Handles GridPendientes.CurrentCellChanging
        GridPendientes.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
    End Sub

    Private Sub GridContrarecibos_CurrentCellChanging(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.CurrentCellChangingEventArgs) Handles GridContrarecibos.CurrentCellChanging
        If Not GridContrarecibos.CurrentColumn Is Nothing Then
            If GridContrarecibos.CurrentColumn.Caption = "Marca" Then
                GridContrarecibos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridContrarecibos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub



    Private Sub GridCxC_Click(sender As Object, e As EventArgs) Handles GridCxC.Click
        If Not GridCxC.CurrentColumn Is Nothing Then
            If GridCxC.CurrentColumn.Caption <> "Marca" And Not GridCxC.GetValue("Marca") Is Nothing Then
                If GridCxC.GetValue("Marca") = False Then
                    GridCxC.SetValue("Marca", True)
                Else
                    GridCxC.SetValue("Marca", False)
                End If

                dtCxC.AcceptChanges()

                GridCxC.Refresh()

                SaldoBase = ModPOS.Redondear(IIf(dtCxC.Compute("Sum(SaldoBase)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(SaldoBase)", "Marca = True")), 2)
                Me.LblSaldo.Text = Format(CStr(SaldoBase), "Currency")
                If TipoCambiario <> 1 Then
                    If SaldoBase > 0 Then
                        lblMonedaCambio.Text = RefCambio & " " & Format(CStr(Redondear(SaldoBase / TipoCambiario, 2)), "Currency")
                    Else
                        lblMonedaCambio.Text = RefCambio & " " & Format("0.00", "Currency")
                    End If
                End If


            End If


        End If
    End Sub

    Private Sub GridCxC_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridCxC.CurrentCellChanged
        If Not GridCxC.CurrentColumn Is Nothing Then
            If GridCxC.CurrentColumn.Caption = "Marca" Then
                GridCxC.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridCxC.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub GridCxC_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridCxC.DoubleClick
        If GridCxC.GetValue("TipoDocumento") = 2 Then
            Dim a As New FrmConsultaGen
            a.Text = "Detalle de Ventas incluidas en la Factura"
            ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_recupera_ventafac", "@FACClave", GridCxC.GetValue("ID"))
            a.GridConsultaGen.GroupByBoxVisible = False
            If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            End If
            a.Dispose()
        ElseIf GridCxC.GetValue("TipoDocumento") = 4 Then
            Dim a As New FrmConsultaGen
            a.Text = "Detalle de Facturas incluidas en la NC"
            ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_recupera_facturasnc", "@NCClave", GridCxC.GetValue("ID"))
            a.GridConsultaGen.GroupByBoxVisible = False
            If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            End If
            a.Dispose()
        End If
    End Sub



    Private Sub Controls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, BtnPago.KeyUp, BtnCancelar.KeyUp, BtnDevolucion.KeyUp, BtnFacturar.KeyUp, BtnNC.KeyUp, BtnRecibo.KeyUp, BtnRetiro.KeyUp, BtnCambio.KeyUp, BtnAuditoria.KeyUp, BtnReimpresion.KeyUp, BtnComision.KeyUp, UiTab1.KeyUp, UiTabCXC.KeyUp, UiTabGeneral.KeyUp, GridCreditos.KeyUp, GridPendientes.KeyUp, btnCertificar.KeyUp, btnRegenerar.KeyUp, cmbTipoTrans.KeyUp, GridContrarecibos.KeyUp, cmbEdoContrarecibo.KeyUp, dtPickerContrarecibo.KeyUp, btnEditContrarecibo.KeyUp, btnAddContrarecibo.KeyUp, btnNotaCargo.KeyUp, chkIncluir.KeyUp, btnReembolso.KeyUp, btnAcumulado.KeyUp, btnReenvio.KeyUp, BtnNota.KeyUp, btnServicios.KeyUp, btnPedido.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.F2
                Me.BtnRecibo.PerformClick()
            Case Is = Keys.F3
                Me.BtnAuditoria.PerformClick()
            Case Is = Keys.F4
                Me.BtnDevolucion.PerformClick()
            Case Is = Keys.F5
                Me.btnReembolso.PerformClick()
            Case Is = Keys.F6
                Me.BtnCancelar.PerformClick()
            Case Is = Keys.F7
                BtnNC.PerformClick()
            Case Is = Keys.F8
                Me.BtnFacturar.PerformClick()
            Case Is = Keys.F9
                Me.btnNotaCargo.PerformClick()
            Case Is = Keys.F10
                Me.BtnPago.PerformClick()
            Case Is = Keys.F11
                btnCorte.PerformClick()
            Case Is = Keys.F12
                BtnRefresh.PerformClick()
        End Select
    End Sub

    Private Sub BtnRetiro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRetiro.Click

        If bRetiroCorte = False Then
            Dim bAutorizado As Boolean = False
            Dim bSalir As Boolean = False
            Do

                Dim b As New MeAutorizacion

                b.Sucursal = SUCClave
                b.sp = "st_filtra_retirocaja"
                b.MontodeAutorizacion = 0
                b.StartPosition = FormStartPosition.CenterScreen
                If b.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    bAutorizado = b.Autorizado
                Else
                    bSalir = True
                End If

            Loop While bAutorizado = False AndAlso bSalir = False


            If bRetiroCorte = False AndAlso bAutorizado = False Then
                Exit Sub
            End If

        End If

        Dim a As New FrmRetiroCaja
        a.SUCClave = SUCClave
        a.ALMClave = ALMClave
        a.CAJClave = CAJClave
        a.Referencia = ClaveCaja
        a.Impresora = Impresora
        a.Generic = PrintGeneric
        a.Ticket = Recibo
        a.Cajon = Cajon
        If a.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
        End If

    End Sub



    Private Sub BtnCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCambio.Click

        Dim b As New FrmSolicitaCliente
        b.ClienteInicial = ""
        b.ValidaCredito = False
        If b.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            CTEClaveActual = b.ClienteClave
            CTENombreActual = b.ClienteNombre
        Else
            CTEClaveActual = ""
            CTENombreActual = ""
            MessageBox.Show("No es posible realizar el cambio debido a que no se ha especificado al cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        b.Dispose()

        Dim a As New FrmCambios
        a.CAJClave = CAJClave
        a.PDVClave = ""
        a.ClienteActual = Me.CTEClaveActual
        a.NombreClienteActual = Me.CTENombreActual
        a.Almacen = ALMClave
        a.Generic = Me.PrintGeneric
        a.Ticket = Recibo
        a.Impresora = Me.Impresora
        a.Cajero = Me.LblUsuario.Text
        a.Cajon = Cajon
        a.Referencia = Me.Clave
        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

        End If
        a.Dispose()

    End Sub

    Private Sub BtnAuditoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAuditoria.Click
        Dim a As New FrmAuditoria
        a.MaskCte = MaskCte
        a.Prefijo = SucursalClave
        a.SUCClave = SUCClave
        a.FormatoPedido = Me.FormatoPedido
        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim b As New FrmConsultaGen
            b.Text = "Auditoría de Pedidos/Ventas"
            ModPOS.ActualizaGrid(False, b.GridConsultaGen, "st_muestra_auditoria", "@VENClave", a.valor)
            If b.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            End If
            b.Dispose()
        End If
        a.Dispose()


    End Sub

    Private Sub BtnReimpresion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click

        Dim i As Integer

        Dim foundRows() As DataRow

        ' Usa el metodo select para filtrar los registros seleccionados.
        foundRows = dtCxC.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then

            Dim sImpresora As String
            Dim iCopias As Integer = 1
            If PrinterInvoice <> "" Then
                sImpresora = PrinterInvoice
            Else
                If PrintDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    sImpresora = PrintDialog1.PrinterSettings.PrinterName
                    iCopias = PrintDialog1.PrinterSettings.Copies
                Else
                    Exit Sub
                End If
            End If

            For i = 0 To foundRows.GetUpperBound(0)

                Dim iTipoCF As Integer = IIf(foundRows(i)("TipoCF").GetType.Name = "DBNull", 1, foundRows(i)("TipoCF"))

                Dim MonRef, MonDesc, sVersionCF As String
                Dim TipoCambio As Double
                Dim dt As DataTable

                Select Case CInt(foundRows(i)("TipoDocumento"))
                    Case Is = 1 ' Venta

                        If Impresora <> "" Then
                            sImpresora = Impresora
                        Else
                            If PrintDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                sImpresora = PrintDialog1.PrinterSettings.PrinterName
                                iCopias = PrintDialog1.PrinterSettings.Copies
                            Else
                                Exit Sub
                            End If
                        End If

                        previewPedido(FormatoPedido, foundRows(i)("ID"), foundRows(i)("Total"), SUCClave, sImpresora, True, iCopias, True, False, IIf(TallaColor = 1, "0", ""), IIf(TallaColor = 1, "0", ""), PrintGeneric)
                    Case Is = 3 'Cargos
                        If Impresora <> "" Then
                            sImpresora = Impresora
                        Else
                            If PrintDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                sImpresora = PrintDialog1.PrinterSettings.PrinterName
                                iCopias = PrintDialog1.PrinterSettings.Copies
                            Else
                                Exit Sub
                            End If
                        End If

                        previewTicketCargo(FormatoPedido, foundRows(i)("ID"), foundRows(i)("Total"), SUCClave, sImpresora, True, iCopias, True, False, IIf(TallaColor = 1, "0", ""), IIf(TallaColor = 1, "0", ""), PrintGeneric)
                    Case Is = 2 'FAC
                        Dim sFormato As String
                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "F", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        sFormato = IIf(dt.Rows(0)("Formato").GetType.Name = "DBNull", "Clasico", dt.Rows(0)("Formato"))
                        sVersionCF = dt.Rows(0)("VersionCF")
                        dt.Dispose()

                        ModPOS.imprimirFactura(iTipoCF, sFormato, foundRows(i)("ID"), foundRows(i)("Total"), SUCClave, TipoCambio, MonDesc, MonRef, sImpresora, iCopias, sVersionCF, foundRows(i)("Logo"))

                    Case Is = 4 'NC
                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "N", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        sVersionCF = dt.Rows(0)("VersionCF")
                        dt.Dispose()

                        ModPOS.imprimirNC(iTipoCF, FormatNC, foundRows(i)("ID"), foundRows(i)("Total"), SUCClave, TipoCambio, MonDesc, MonRef, sImpresora, iCopias, VersionCF, foundRows(i)("Logo"))

                    Case Is = 5 'Devolucion

                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "D", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        dt.Dispose()

                        If TallaColor = 1 Then
                            ImprimeVale(foundRows(i)("ID"), Impresora, TICDevolucion, False, -1, False, PrintGeneric)
                        Else
                            imprimeDevolucion(foundRows(i)("ID"), Impresora, TICDevolucion, reciboTicket, sImpresora, MonDesc, MonRef, iCopias, True, PrintGeneric)
                        End If


                    Case Is = 6 'Nota de Cargo

                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "C", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        sVersionCF = dt.Rows(0)("VersionCF")
                        dt.Dispose()


                        ModPOS.imprimirCargo(FormatCargo, foundRows(i)("ID"), foundRows(i)("Total"), TipoCambio, MonDesc, MonRef, sImpresora, iCopias, sVersionCF, foundRows(i)("logo"))

                End Select

                foundRows(i)("Marca") = False
            Next
            ChkMarcaTodos.Checked = False
            chkIncluir.Checked = False

            SaldoBase = ModPOS.Redondear(IIf(dtCxC.Compute("Sum(SaldoBase)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(SaldoBase)", "Marca = True")), 2)
            Me.LblSaldo.Text = Format(CStr(SaldoBase), "Currency")



            If TipoCambiario <> 1 Then
                If SaldoBase > 0 Then
                    lblMonedaCambio.Text = RefCambio & " " & Format(CStr(TruncateToDecimal(SaldoBase / TipoCambiario, 2)), "Currency")
                Else
                    lblMonedaCambio.Text = RefCambio & " " & Format("0.00", "Currency")
                End If
            End If

        Else
            MessageBox.Show("Para reimprimir, debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BtnComision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnComision.Click
        If ModPOS.ComisionVta Is Nothing Then
            ModPOS.ComisionVta = New FrmComisionVta
            ModPOS.ComisionVta.MONRefBase = RefMoneda
            ModPOS.ComisionVta.SUCClave = SUCClave
            ModPOS.ComisionVta.ALMClave = ALMClave
            ModPOS.ComisionVta.Impresora = Impresora
            ModPOS.ComisionVta.Referencia = Clave
            ModPOS.ComisionVta.CAJClave = CAJClave
            ModPOS.ComisionVta.PrintGeneric = PrintGeneric
            ModPOS.ComisionVta.Ticket = Recibo
            ModPOS.ComisionVta.Cajon = Cajon
        End If
        ModPOS.ComisionVta.StartPosition = FormStartPosition.CenterScreen
        ModPOS.ComisionVta.Show()
        ModPOS.ComisionVta.BringToFront()
    End Sub



    Private Sub UiTab1_SelectedTabChanged(ByVal sender As Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs) Handles UiTab1.SelectedTabChanged
        Select Case e.Page.Name
            Case "UiTabCXC"
                actualizaGridCreditos()
                Me.cobranzaGeneral = False
            Case "UiTabGeneral"
                AgregarFolio()
                Me.cobranzaGeneral = True
            Case "UiTabPendientes"
                actualizaGridPendientes()
            Case "UiTabContrarecibos"
                actualizaContrarecibos()
            Case "UiTabComplementoPago"
                actualizaComplementoPago()
            Case "UiTabApartados"
                actualizaGridApartados()
            Case "UiTabAbonos"
                ActualizaGridAbonos()
        End Select
    End Sub

    Private Sub GridCreditos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridCreditos.DoubleClick
        PagoCreditos()
    End Sub

    Private Sub GridCreditos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridCreditos.SelectionChanged
        If Not GridCreditos.GetValue("CTEClave") Is Nothing Then
            Me.CTEClave = GridCreditos.GetValue("CTEClave")
            sRazonSocial = GridCreditos.GetValue("RazonSocial")
        Else
            Me.CTEClave = ""
            sRazonSocial = ""
        End If
    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtCxC.Rows.Count > 0 Then
            Dim i As Integer

            If ChkMarcaTodos.Checked Then
                SaldoBase = 0
                For i = 0 To GridCxC.GetDataRows.Length - 1
                    GridCxC.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridCxC.GetDataRows.Length - 1
                    GridCxC.GetDataRows(i).DataRow("Marca") = False
                Next
            End If

            dtCxC.AcceptChanges()

            GridCxC.Refresh()


            SaldoBase = ModPOS.Redondear(IIf(dtCxC.Compute("Sum(SaldoBase)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(SaldoBase)", "Marca = True")), 2)
            Me.LblSaldo.Text = Format(CStr(SaldoBase), "Currency")

            If TipoCambiario <> 1 Then
                If SaldoBase > 0 Then
                    lblMonedaCambio.Text = RefCambio & " " & Format(CStr(Redondear(SaldoBase / TipoCambiario, 2)), "Currency")
                Else
                    lblMonedaCambio.Text = RefCambio & " " & Format("0.00", "Currency")
                End If
            End If
        End If

    End Sub

    Private Sub GridCxC_CellValueChanged1(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridCxC.CellValueChanged
        dtCxC.AcceptChanges()

        GridCxC.Refresh()
        SaldoBase = ModPOS.Redondear(IIf(dtCxC.Compute("Sum(SaldoBase)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(SaldoBase)", "Marca = True")), 2)
        Me.LblSaldo.Text = Format(CStr(SaldoBase), "Currency")

        If TipoCambiario <> 1 Then
            If SaldoBase > 0 Then
                lblMonedaCambio.Text = RefCambio & " " & Format(CStr(Redondear(SaldoBase / TipoCambiario, 2)), "Currency")
            Else
                lblMonedaCambio.Text = RefCambio & " " & Format("0.00", "Currency")
            End If
        End If

    End Sub

    Private Sub TxtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolio.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFolio.Text = TxtFolio.Text.ToUpper.Replace("'", "-")
            If TxtFolio.Text <> "" Then

                If Split(TxtFolio.Text, "-").Length = 3 Then
                    TxtFolio.Text = Split(TxtFolio.Text, "-")(1) & "-" & Split(TxtFolio.Text, "-")(2)
                End If

                Dim foundRows() As DataRow
                foundRows = dtCxC.Select("Folio like '*" & TxtFolio.Text.ToUpper.Replace("'", "-") & "' and SaldoBase > 0")
                If foundRows.GetLength(0) > 0 Then
                    foundRows(0)("Marca") = True
                    Me.BtnPago.PerformClick()
                End If
            End If
        End If
    End Sub

    Private Sub TxtFolio_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolio.KeyUp
        If TallaColor = 0 AndAlso TxtFolio.Text <> "" Then
            AgregarFolio()
        End If

    End Sub

    Private Sub BtnRefresh_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        Me.AgregarFolio()
    End Sub

    Private Sub CertificarCFD()
        If sPendienteSelected <> "" Then
            Dim sDOCClave As String = sPendienteSelected
            Dim iTipoPAC As Integer
            Dim iTipoComprobante As Integer
            Select Case CInt(GridPendientes.GetValue("tipo"))
                Case Is = 0
                    iTipoComprobante = 1
                Case 1, 2
                    iTipoComprobante = 7
                Case Is = 6
                    iTipoComprobante = 6
            End Select

            If MessageBox.Show("¿Desea intentar Certificar el documento " & GridPendientes.GetValue("Serie") & GridPendientes.GetValue("Folio") & "?", "Pregunta", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                iTipoPAC = ModPOS.crearXML(2, dtPAC, PathXML, GridPendientes.GetValue("Serie") & GridPendientes.GetValue("Folio"), sPendienteSelected, GridPendientes.GetValue("tipoDeComprobante"), Nothing, Nothing, Nothing, iTipoComprobante, InterfazSalida)
                If iTipoPAC <> 0 Then
                    If Not (MailAdress = "" OrElse MailUser = "" OrElse MailPassword = "" OrElse HostSMTP = "" OrElse MailPort = 0) Then
                        Try
                            If System.IO.Directory.Exists(PathXML) Then

                                Dim PathPDF As String
                                Dim i, j As Integer

                                Dim MonRef, MonDesc, sVersionCF As String
                                Dim TipoCambio As Double
                                Dim dt As DataTable
                                Dim eMailCte As String = ""

                                eMailCte = GridPendientes.GetValue("Email").ToString.Trim


                                If eMailCte <> "" Then
                                    If eMailCte <> "Salir" Then
                                        PathPDF = pathActual & "Temp\" & GridPendientes.GetValue("Serie") & GridPendientes.GetValue("Folio") & ".PDF"

                                        Dim iTipoCF As Integer = IIf(GridPendientes.GetValue("TipoCF").GetType.Name = "DBNull", 1, GridPendientes.GetValue("TipoCF"))

                                        Select Case CInt(GridPendientes.GetValue("tipo"))

                                            Case Is = 0 'FAC

                                                'Genera PDF

                                                dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "F", "@Documento", sDOCClave)
                                                TipoCambio = dt.Rows(0)("TipoCambio")
                                                MonRef = dt.Rows(0)("Referencia")
                                                MonDesc = dt.Rows(0)("Descripcion")
                                                sVersionCF = dt.Rows(0)("VersionCF")
                                                Dim sFormato As String
                                                sFormato = IIf(dt.Rows(0)("Formato").GetType.Name = "DBNull", "Clasico", dt.Rows(0)("Formato"))

                                                dt.Dispose()

                                                ModPOS.SendMail(sVersionCF, eMailCte, iTipoCF, sFormato, CDate(GridPendientes.GetValue("Fecha")), GridPendientes.GetValue("Serie") & GridPendientes.GetValue("Folio"), sDOCClave, GridPendientes.GetValue("Total"), MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonRef, MonDesc, GridPendientes.GetValue("Logo"))




                                            Case Is = 6 'Nota de Cargo


                                                dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "C", "@Documento", sDOCClave)
                                                TipoCambio = dt.Rows(0)("TipoCambio")
                                                MonRef = dt.Rows(0)("Referencia")
                                                MonDesc = dt.Rows(0)("Descripcion")
                                                sVersionCF = dt.Rows(0)("VersionCF")
                                                dt.Dispose()
                                                ModPOS.SendMailCargo(VersionCF, eMailCte, FormatNC, CDate(GridPendientes.GetValue("Fecha")), GridPendientes.GetValue("Serie") & GridPendientes.GetValue("Folio"), sDOCClave, GridPendientes.GetValue("Total"), MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, TipoCambio, MonDesc, MonRef, GridPendientes.GetValue("Logo"), True)

                                            Case Else

                                                dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "N", "@Documento", sDOCClave)
                                                TipoCambio = dt.Rows(0)("TipoCambio")
                                                MonRef = dt.Rows(0)("Referencia")
                                                MonDesc = dt.Rows(0)("Descripcion")
                                                sVersionCF = dt.Rows(0)("VersionCF")
                                                dt.Dispose()


                                                ModPOS.SendMailNC(VersionCF, eMailCte, iTipoCF, FormatNC, CDate(GridPendientes.GetValue("Fecha")), GridPendientes.GetValue("Serie") & GridPendientes.GetValue("Folio"), sDOCClave, GridPendientes.GetValue("Total"), MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonDesc, MonRef, GridPendientes.GetValue("Logo"), True)


                                        End Select
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                        End Try

                    End If

                    actualizaGridPendientes()
                End If
            End If 'Estado Pendiente
        Else
            MessageBox.Show("¡No se ha seleccionado algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If 'Seleccion de factura
    End Sub

    Private Sub GridPendientes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPendientes.DoubleClick
        If Not GridPendientes.GetValue(0) Is Nothing Then
            CertificarCFD()
        End If
    End Sub

    Private Sub GridPendientes_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPendientes.SelectionChanged
        If Not GridPendientes.GetValue(0) Is Nothing Then
            sPendienteSelected = GridPendientes.GetValue("Clave")
        Else
            sPendienteSelected = ""
        End If
    End Sub

    Private Sub btnCertificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCertificar.Click
        CertificarCFD()
    End Sub

    Private Sub btnRegenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegenerar.Click
        If sPendienteSelected <> "" Then
            If MessageBox.Show("¿Desea Regenerar el XML del documento " & GridPendientes.GetValue("Serie") & GridPendientes.GetValue("Folio") & "?", "Pregunta", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                ModPOS.regenerarCFD(GridPendientes.GetValue("TipoCF"), sPendienteSelected, SUCClave)
            End If
        Else
            MessageBox.Show("¡No se ha seleccionado algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If '
    End Sub

    Public Sub preparaBotones(ByVal iTipo As Integer)
        BtnOtroPago.Enabled = True
        BtnPago.Enabled = True
        BtnFacturar.Enabled = True
        BtnDevolucion.Enabled = True
        BtnReimpresion.Enabled = True
        BtnNC.Enabled = True
        BtnAuditoria.Enabled = True
        btnReenvio.Enabled = True
        btnReembolso.Enabled = False
        chkIncluir.Enabled = True
        btnMasiva.Enabled = True
        BtnNota.Enabled = True
        btnNotaCargo.Enabled = True
        BtnGlobal.Enabled = True

        Select Case iTipo
            Case 1 'Venta y cargos
                BtnNC.Enabled = False
                btnNotaCargo.Enabled = False
                btnReenvio.Enabled = False

            Case 2 'Factura
                btnMasiva.Enabled = False
                Me.BtnDevolucion.Enabled = False

                BtnNota.Enabled = False

            Case 3 'NC
                BtnGlobal.Enabled = False
                btnMasiva.Enabled = False
                BtnDevolucion.Enabled = False
                BtnOtroPago.Enabled = False
                BtnPago.Enabled = False
                BtnFacturar.Enabled = False
                chkIncluir.Enabled = False
                BtnNota.Enabled = False
                btnNotaCargo.Enabled = False
                btnReembolso.Enabled = True

            Case 4 'Devolucion
                BtnGlobal.Enabled = False
                btnMasiva.Enabled = False
                BtnOtroPago.Enabled = False
                BtnPago.Enabled = False
                BtnFacturar.Enabled = False
                BtnNC.Enabled = False
                btnReenvio.Enabled = False
                chkIncluir.Enabled = False
                BtnNota.Enabled = False
                btnNotaCargo.Enabled = False
                btnReembolso.Enabled = True

            Case 5 'Nota de Cargo
                BtnDevolucion.Enabled = False
                btnMasiva.Enabled = False
                BtnGlobal.Enabled = False
                BtnFacturar.Enabled = False
                BtnNC.Enabled = False
                chkIncluir.Enabled = False
                BtnNota.Enabled = False

        End Select
    End Sub


    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bload = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            If Not dtCxC Is Nothing Then
                dtCxC.Dispose()
                SaldoBase = 0
                Me.LblSaldo.Text = Format(CStr(ModPOS.Redondear(SaldoBase, 2)), "Currency")
                lblMonedaCambio.Text = RefCambio & " " & Format("0.00", "Currency")

                ChkMarcaTodos.Enabled = False
            End If
            AgregarFolio()
        End If
    End Sub

    Private Sub Clock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock.Tick
        lblDate.Text = DateTime.Today.ToLongDateString & " " & DateTime.Now.ToShortTimeString 'ToString("MMMM dd, yyyy")

    End Sub

    Private Sub btnCancelaPendiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelaPendiente.Click

        If sPendienteSelected <> "" Then
            Dim sFolio As String = GridPendientes.GetValue("Serie") & CStr(GridPendientes.GetValue("Folio"))

            Select Case MessageBox.Show("¿Esta seguro de Cancelar el documento " & sFolio & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Dim a As New MeAutorizacion

                    a.Sucursal = SUCClave
                    a.MontodeAutorizacion = GridPendientes.GetValue("Total") * GridPendientes.GetValue("TipoCambio")
                    a.StartPosition = FormStartPosition.CenterScreen
                    If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        If a.Autorizado Then
                            Autoriza = a.Autoriza

                            Dim dt As DataTable
                            Dim eRFC, sCTEClave As String
                            Dim dTotal, dTipoCambio As Decimal
                            Dim iTipo As Integer

                            If GridPendientes.GetValue("tipoDeComprobante") = "ingreso" OrElse GridPendientes.GetValue("tipoDeComprobante") = "I" Then
                                If GridPendientes.GetValue("tipo") = 6 Then
                                    dt = ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", sPendienteSelected)
                                Else
                                    dt = ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", sPendienteSelected)
                                End If
                            Else
                                dt = ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", sPendienteSelected)
                                iTipo = dt.Rows(0)("Tipo")
                            End If

                            If GridPendientes.GetValue("TipodeComprobante") = "ingreso" OrElse GridPendientes.GetValue("tipoDeComprobante") = "I" Then
                                If dt.Rows(0)("saldo") <> dt.Rows(0)("total") Then
                                    MessageBox.Show("No es posible realizar la cancelación del documento debido a que tiene pagos aplicados")
                                    Exit Sub
                                End If
                            End If

                            eRFC = dt.Rows(0)("cRFC")
                            sCTEClave = dt.Rows(0)("CTEClave")
                            dTotal = dt.Rows(0)("total")
                            dTipoCambio = dt.Rows(0)("TipoCambio")
                            dt.Dispose()



                            If GridPendientes.GetValue("TipodeComprobante") = "ingreso" OrElse GridPendientes.GetValue("tipoDeComprobante") = "I" Then

                                Dim bmotivo As Boolean = False
                                Dim MotCancelacion As Integer
                                Do
                                    Dim m As New FrmMotivo
                                    m.Tabla = "Factura"
                                    m.Campo = "Cancelacion"
                                    If m.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                        bmotivo = True
                                        MotCancelacion = m.Motivo
                                    End If
                                    m.Dispose()
                                Loop While bmotivo = False

                                If GridPendientes.GetValue("tipo") = 6 Then

                                    ModPOS.Ejecuta("sp_cancela_notacargo", "@CARClave", sPendienteSelected, "@Motivo", MotCancelacion, "@Autoriza", Autoriza)
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", sCTEClave, "@Importe", dTotal * dTipoCambio)
                                    ModPOS.Ejecuta("sp_libera_pagos_fac", "@FACClave", sPendienteSelected)
                                Else
                                    ModPOS.Ejecuta("sp_cancela_factura", "@FACClave", sPendienteSelected, "@Motivo", MotCancelacion, "@Autoriza", Autoriza)

                                    If StageCancelacion <> "" Then
                                        ModPOS.GeneraMovInv(1, 5, 2, sPendienteSelected, ALMClave, sFolio, Autoriza, False, 1, StageCancelacion)
                                    Else
                                        ModPOS.GeneraMovInv(1, 5, 2, sPendienteSelected, ALMClave, sFolio, Autoriza, False)
                                    End If

                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", sCTEClave, "@Importe", dTotal * dTipoCambio)
                                    ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", sPendienteSelected, "@Tipo", 2)
                                    ModPOS.Ejecuta("sp_libera_pagos_fac", "@FACClave", sPendienteSelected)
                                End If
                            Else

                                If iTipo = 1 Then
                                    MessageBox.Show("No es posible realizar la cancelación de una Nota de Credito por devolución")

                                    'If iTipo = 1 Then
                                    '    ModPOS.GeneraMovInv(2, 5, 4, sPendienteSelected, ALMClave, sFolio, Autoriza)
                                    '    ModPOS.ActualizaExistAlm(2, 4, sPendienteSelected, ALMClave)
                                    '    ModPOS.ActualizaExistUbc(2, 4, sPendienteSelected, ALMClave)
                                    'End If
                                Else

                                    Dim bmotivo As Boolean = False
                                    Dim MotCancelacion As Integer
                                    Do
                                        Dim m As New FrmMotivo
                                        m.Tabla = "NC"
                                        m.Campo = "Cancelacion"
                                        If m.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                            bmotivo = True
                                            MotCancelacion = m.Motivo
                                        End If
                                        m.Dispose()
                                    Loop While bmotivo = False
                                    ModPOS.Ejecuta("sp_cancela_nc", "@NCClave", sPendienteSelected, "@Motivo", MotCancelacion, "@Autoriza", Autoriza)

                                    'Actualiza el Saldo del Documento
                                    ModPOS.Ejecuta("sp_act_saldo_fac", "@NCClave", sPendienteSelected)
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", sCTEClave, "@Importe", dTotal * dTipoCambio)


                                    'Si es de tipo devolución, realiza salida de producto de almacén
                                End If



                            End If

                            Me.actualizaGridPendientes()


                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub cmbEdoContrarecibo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEdoContrarecibo.SelectedIndexChanged
        If bload = True AndAlso Not cmbEdoContrarecibo.SelectedValue Is Nothing Then
            actualizaContrarecibos()
        End If

    End Sub

    Private Sub dtPickerContrarecibo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPickerContrarecibo.ValueChanged
        If bload = True AndAlso (PeriodoContra <> dtPickerContrarecibo.Value.Year OrElse MesContra <> dtPickerContrarecibo.Value.Month) Then
            actualizaContrarecibos()
        End If
    End Sub

    Private Sub btnEditContrarecibo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditContrarecibo.Click
        Dim foundRows() As DataRow

        foundRows = dtContrarecibos.Select("Marca ='True' and Estado='Pendiente'")
        If foundRows.GetLength(0) > 0 Then
            Dim i As Integer
            For i = 0 To foundRows.GetUpperBound(0)
                ModPOS.Ejecuta("sp_actualiza_contrarecibo", "@FACClave", foundRows(i)("FACClave"), "@Estado", 1, "@Usuario", ModPOS.UsuarioActual)
            Next
            ModPOS.MtoCXC.actualizaContrarecibos()
        Else
            Beep()
            MessageBox.Show("Debe marcar aquellas facturas que se encuentran pendientes de recibir", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnAddContrarecibo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddContrarecibo.Click
        Dim a As New FrmContrarecibo
        a.CAJClave = Me.CAJClave
        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub btnNotaCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotaCargo.Click
        Dim foundRows() As DataRow

        foundRows = dtCxC.Select("Marca ='True' and TipoDocumento = 2 ")

        If foundRows.GetLength(0) >= 1 Then

            Dim fr() As DataRow
            fr = dtCxC.Select("Marca ='True' and TipoDocumento = 2  and RFC <> '" & foundRows(0)("RFC") & "'")

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir Facturas de diferentes clientes en una Nota de Cargo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            fr = dtCxC.Select("Marca ='True' and TipoDocumento=2 and TipoImpuesto <> " & CStr(foundRows(0)("TipoImpuesto")))

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir facturas de diferentes Tipos de Impuesto (General/Frontera) de clientes en una Nota de Cargo ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            fr = dtCxC.Select("Marca ='True' and TipoDocumento=2 and MONClave <> '" & foundRows(0)("MONClave") & "'")

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir facturas de diferentes Monedas en una Nota de Cargo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            fr = dtCxC.Select("Marca ='True' and TipoDocumento=2 and MONClave = '" & foundRows(0)("MONClave") & "' and TipoCambio <> " & CStr(foundRows(0)("TipoCambio")))

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir facturas de Tipo de Cambio Diferente ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If



            If ModPOS.NotaCargo Is Nothing Then
                ModPOS.NotaCargo = New FrmNotaCargo
                ModPOS.NotaCargo.SUCClave = SUCClave
                ModPOS.NotaCargo.CAJClave = CAJClave
                ModPOS.NotaCargo.Facturas = foundRows
                ModPOS.NotaCargo.Cajon = Cajon
                ModPOS.NotaCargo.ImpresoraCajon = Impresora
            End If

            ModPOS.NotaCargo.StartPosition = FormStartPosition.CenterScreen
            ModPOS.NotaCargo.Show()
            If Not ModPOS.NotaCargo Is Nothing Then
                ModPOS.NotaCargo.BringToFront()
            End If


        Else

            If ModPOS.NotaCargo Is Nothing Then
                ModPOS.NotaCargo = New FrmNotaCargo
                ModPOS.NotaCargo.SUCClave = SUCClave
                ModPOS.NotaCargo.CAJClave = CAJClave
                ModPOS.NotaCargo.Cajon = Cajon
                ModPOS.NotaCargo.ImpresoraCajon = Impresora
            End If

            ModPOS.NotaCargo.StartPosition = FormStartPosition.CenterScreen
            ModPOS.NotaCargo.Show()
            If Not ModPOS.NotaCargo Is Nothing Then
                ModPOS.NotaCargo.BringToFront()
            End If

        End If



    End Sub

    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        Dim i As Integer

        Dim foundRows() As DataRow

        ' Usa el metodo select para filtrar los registros seleccionados.
        foundRows = dtCxC.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then



            For i = 0 To foundRows.GetUpperBound(0)


                Dim iTipoCF As Integer = IIf(foundRows(i)("TipoCF").GetType.Name = "DBNull", 1, foundRows(i)("TipoCF"))

                Dim MonRef, MonDesc, sVersionCF As String
                Dim TipoCambio As Double
                Dim dt As DataTable

                Select Case CInt(foundRows(i)("TipoDocumento"))
                    Case Is = 1 ' Venta

                        previewPedido(FormatoPedido, foundRows(i)("ID"), foundRows(i)("Total"), SUCClave, "", False, 0, False, False, " ", IIf(TallaColor = 1, "0", ""), PrintGeneric)

                    Case Is = 2 'FAC

                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "F", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        sVersionCF = dt.Rows(0)("VersionCF")
                        Dim sFormato As String
                        sFormato = IIf(dt.Rows(0)("Formato").GetType.Name = "DBNull", "Clasico", dt.Rows(0)("Formato"))

                        dt.Dispose()

                        ModPOS.previewFactura(iTipoCF, sFormato, foundRows(i)("ID"), foundRows(i)("Total"), SUCClave, TipoCambio, MonDesc, MonRef, sVersionCF, foundRows(i)("Logo"))



                    Case Is = 4 'NC
                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "N", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        sVersionCF = dt.Rows(0)("VersionCF")
                        dt.Dispose()

                        ModPOS.previewNC(iTipoCF, FormatNC, foundRows(i)("ID"), foundRows(i)("Total"), SUCClave, TipoCambio, MonDesc, MonRef, sVersionCF, foundRows(i)("Logo"))

                    Case Is = 5 'Devolucion
                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "D", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")

                        dt.Dispose()

                        imprimeDevolucion(foundRows(i)("ID"), Impresora, TICDevolucion, reciboTicket, PrinterInvoice, MonDesc, MonRef, 1, False, False)



                    Case Is = 6 'Nota de Cargo

                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "C", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        sVersionCF = dt.Rows(0)("VersionCF")
                        dt.Dispose()

                        ModPOS.previewCargo(FormatCargo, foundRows(i)("ID"), foundRows(i)("Total"), TipoCambio, MonDesc, MonRef, sVersionCF, foundRows(i)("Logo"))

                End Select
                foundRows(i)("Marca") = False
            Next
            ChkMarcaTodos.Checked = False
            chkIncluir.Checked = False
            SaldoBase = ModPOS.Redondear(IIf(dtCxC.Compute("Sum(SaldoBase)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(SaldoBase)", "Marca = True")), 2)
            Me.LblSaldo.Text = Format(CStr(SaldoBase), "Currency")

            If TipoCambiario <> 1 Then
                If SaldoBase > 0 Then
                    lblMonedaCambio.Text = RefCambio & " " & Format(CStr(TruncateToDecimal(SaldoBase / TipoCambiario, 2)), "Currency")
                Else
                    lblMonedaCambio.Text = RefCambio & " " & Format("0.00", "Currency")
                End If
            End If

        Else
            MessageBox.Show("Para reimprimir, debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function VerificaDatoFiscalCte(ByVal oCFD As CFD) As Boolean
        Dim Cadena As String = ""
        Dim Valido As Boolean = True

        If oCFD.Pais = "" Then
            Cadena &= "Pais,"
        End If

        If oCFD.Entidad = "" Then
            Cadena &= "Entidad,"
        End If

        If oCFD.Mnpio = "" Then
            Cadena &= "Municipio,"
        End If
        If oCFD.Colonia = "" Then
            Cadena &= "Colonia,"
        End If

        If oCFD.Calle = "" Then
            Cadena &= "Calle,"
        End If

        If oCFD.noExterior = "" Then
            Cadena &= "No. Exterior,"
        End If

        If oCFD.codigoPostal = "" Then
            Cadena &= "Código Postal,"
        End If

        If oCFD.RazonSocial = "" Then
            Cadena &= "Razón Social,"
        End If


        If oCFD.RFC <> "" AndAlso oCFD.RFC.Length >= 12 AndAlso oCFD.RFC.Length <= 13 Then
            If oCFD.TPersona = 1 Then
                If ModPOS.soloLetras(oCFD.RFC.Substring(3, 1)) = False Then
                    Cadena &= "RFC,"
                End If
            End If
        Else
            Cadena &= "RFC,"
        End If


        If Cadena = "" Then
            Valido = True
        Else
            '      MessageBox.Show("La siguiente información del cliente No es valida ó es requerida para facturar: " & Cadena & " para completarla, edite la información del cliente seleccionado presionando el botón de Abrir junto al Filtro de busqueda y selección de cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Valido = False
        End If

        Return Valido
    End Function



    Private Sub Factura_Automatica(ByVal foundRows() As DataRow)
        If foundRows.GetLength(0) > 0 Then
            Cursor.Current = Cursors.WaitCursor

            Dim iTipoPac, i, iCredito As Integer
            Dim Vencimiento As DateTime
            Dim dt, dtPac, dtConcepto, dtImpuesto, dtDetalleImpuesto As DataTable
            Dim oCFD As New CFD
            Dim ImprimeFactura As Boolean = False
            Dim EnviaFactura As Boolean = False
            Dim FacturaId As String
            Dim FACClave As String
            Dim MONClave As String = ""

            oCFD.TipoCF = TipoCF
            oCFD.VersionCF = VersionCF
            oCFD.regimenFiscal = regimenFiscal

            If oCFD.VersionCF = "3.3" Then
                oCFD.tipoDeComprobante = "I"
            Else
                oCFD.tipoDeComprobante = "ingreso"
            End If

            'Verifica Timbres
            If oCFD.TipoCF = 2 Then
                dtPac = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)

                If dtPac Is Nothing OrElse dtPac.Rows.Count <= 0 Then
                    MessageBox.Show("No se encontraron timbres disponibles, verifique la configuración de timbres en la Compañia actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            ' Verifica Certificado
            dt = ModPOS.Recupera_Tabla("sp_recupera_certificadovigente", "@COMClave", ModPOS.CompanyActual)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                oCFD.noCertificado = dt.Rows(0)("Serie")
                oCFD.Certificado64 = dt.Rows(0)("Certificado")
                oCFD.LlaveFile = dt.Rows(0)("Llave")
                oCFD.ContrasenaClave = dt.Rows(0)("Password")
                dt.Dispose()
            Else
                MessageBox.Show("No existen certificado vigente disponible para emitir algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Verifica que exista el path
            Try
                If Not System.IO.Directory.Exists(PathXML) Then
                    MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
            End Try

            'Verifica que exista el path del .Key
            Try
                If Not System.IO.File.Exists(oCFD.LlaveFile) Then
                    MessageBox.Show("El archivo " & oCFD.LlaveFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
            End Try

            Dim NumFacturas As Integer = foundRows.GetLength(0)

            If Not ModPOS.validaFolio(SUCClave, CAJClave, 1, NumFacturas) Then
                Exit Sub
            End If

            'Recupera la llave 
            Dim DirSello As String = "C:\SelladoDigital\" & System.IO.Path.GetFileName(oCFD.LlaveFile)

            If Not System.IO.File.Exists(DirSello) Then
                If System.IO.File.Exists(oCFD.LlaveFile) Then
                    System.IO.File.Copy(oCFD.LlaveFile, DirSello)
                Else
                    MessageBox.Show("El archivo " & oCFD.LlaveFile & " no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            Dim dir As String
            Dim DirArchivoPEM As String = DirSello & ".pem"

            dir = "C:\OpenSSL\bin\openssl.exe"

            Shell(dir & " pkcs8 -inform DER -in " & DirSello & " -passin pass:" & oCFD.ContrasenaClave & " -out " & DirArchivoPEM, AppWinStyle.Hide, True)


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

            ImprimeFactura = False

            EnviaFactura = True



            Dim frmStatusMessage As New frmStatus
            Dim Referencia As String
            Dim Banco As String
            Dim Tipo As String
            Dim SAT As String
            Dim Logo As Integer = 1
            Dim sFormatoFactura As String

            For i = 0 To foundRows.GetUpperBound(0)

                frmStatusMessage.Show("Generando Comprobantes Fiscales Digitales " & CStr(i + 1) & "/" & CStr(foundRows.GetLength(0)))

                sFormatoFactura = FormatoFactura


                If MONClave <> foundRows(i)("MONClave") Then
                    dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", foundRows(i)("MONClave"))
                    MONClave = dt.Rows(0)("MONClave")
                    MonedaRef = dt.Rows(0)("Referencia")
                    MonedaDesc = dt.Rows(0)("Descripcion")
                    TipoCambio = foundRows(i)("TipoCambio")
                    dt.Dispose()
                End If

                oCFD.TImpuesto = foundRows(i)("TipoImpuesto")

                'Carga datos Receptor
                Dim SaldoCliente As Double
                dt = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", foundRows(i)("CTEClave"))


                oCFD.CTEClave = dt.Rows(0)("CTEClave")
                oCFD.CURP = dt.Rows(0)("CURP")
                oCFD.Clave = dt.Rows(0)("Clave")

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


                If oCFD.Referencia = "" Then
                    oCFD.Referencia = "SIN REFERENCIA"
                End If

                If oCFD.noInterior <> "" Then
                    oCFD.brnoInterior = True
                Else
                    oCFD.brnoInterior = False
                End If

                SaldoCliente = dt.Rows(0)("Disponible")
                oCFD.UsoCFDI = IIf(dt.Rows(0)("UsoCFDI").GetType.Name = "DBNull", "G03", dt.Rows(0)("UsoCFDI"))

                dt.Dispose()
                'Fin receptor

                dt = ModPOS.SiExisteRecupera("sp_recupera_addcte", "@CTEClave", oCFD.CTEClave)

                If Not dt Is Nothing Then
                    oCFD.tieneAddenda = True
                    oCFD.Tipo = dt.Rows(0)("Tipo")
                    oCFD.TipoConexion = dt.Rows(0)("TipoConexion")
                    oCFD.UsuarioFTP = dt.Rows(0)("UsuarioFTP")
                    oCFD.PwdFTP = dt.Rows(0)("PwdFTP")
                    oCFD.FTP = dt.Rows(0)("FTP")
                    oCFD.Firma = dt.Rows(0)("FirmaWeb")
                    oCFD.emailAdd = dt.Rows(0)("email")
                    oCFD.NoProveedor = dt.Rows(0)("NoProveedor")
                    sFormatoFactura = dt.Rows(0)("FormatoFactura")
                Else
                    oCFD.tieneAddenda = False
                End If



                If VerificaDatoFiscalCte(oCFD) = True Then

                    'Valida credito
                    If foundRows(i)("Tipo") = "Credito" Then
                        Dim dtVencimiento As DataTable = ModPOS.SiExisteRecupera("sp_calcula_vencimiento", "@Dias", oCFD.DiasCredito)
                        If Not dtVencimiento Is Nothing Then
                            Vencimiento = dtVencimiento.Rows(0)("Vencimiento")
                            dtVencimiento.Dispose()
                        End If
                        iCredito = 1
                        oCFD.CondicionesDePago = CStr(oCFD.DiasCredito) & " días"
                    Else
                        iCredito = 0
                        Vencimiento = Today.Date
                        oCFD.CondicionesDePago = "Contado"
                    End If


                    'metodo de pago
                    If oCFD.VersionCF = "3.3" Then
                        If iCredito = 1 Then
                            oCFD.formaDePago = "PPD"
                            oCFD.metodoDePago = "99"
                        Else
                            oCFD.formaDePago = "PUE"
                        End If
                    Else
                        oCFD.formaDePago = "Pago en una sola exhibición"
                    End If


                    FacturaId = ModPOS.obtenerLlave
                    FACClave = ModPOS.obtenerLlave


                    ' Graba factura y detalle

                    NumFacturas -= 1

                    oCFD.DOCClave = FACClave

                    ModPOS.recuperaFolio(SUCClave, CAJClave, 1, oCFD)


                    Dim dtLogo As DataTable = ModPOS.Recupera_Tabla("st_recupera_logo_fac", "@FACClave", FACClave, "@VENClave", foundRows(i)("ID"))
                    Logo = dtLogo.Rows(0)("Logo")
                    dtLogo.Dispose()

                    ModPOS.Ejecuta("st_venta_factura", _
                                   "@idFactura", FacturaId, _
                                   "@FACClave", FACClave, _
                                   "@VENClave", foundRows(i)("ID"), _
                                   "@CAJClave", CAJClave, _
                                   "@tipo", oCFD.tipoDeComprobante, _
                                   "@TipoCF", oCFD.TipoCF, _
                                   "@VersionCF", oCFD.VersionCF, _
                                   "@RegimenFiscal", oCFD.regimenFiscal, _
                                   "@fechaAprobacion", oCFD.fechaAprobacion, _
                                   "@Serie", oCFD.Serie, _
                                   "@Folio", oCFD.Folio, _
                                   "@CTEClave", oCFD.CTEClave, _
                                   "@Credito", iCredito, _
                                   "@DiasCredito", oCFD.DiasCredito, _
                                   "@FechaVencimiento", Vencimiento, _
                                   "@Desglosar", oCFD.NoDesglosaIEPS, _
                                   "@formaDePago", oCFD.formaDePago, _
                                   "@MONClave", MONClave, _
                                   "@TipoCambio", TipoCambio, _
                                   "@Formato", sFormatoFactura, _
                                   "@Nota", foundRows(i)("Nota"), _
                                   "@UsoCFDI", oCFD.UsoCFDI, _
                                   "@Logo", Logo, _
                                   "@Usuario", ModPOS.UsuarioActual, _
                                   "@TallaColor", TallaColor)


                    If CobranzaVenta = False Then
                        Dim dtAbonos As DataTable
                        dtAbonos = ModPOS.Recupera_Tabla("sp_obtiene_saldofac", "@idFactura", FacturaId)

                        ModPOS.Ejecuta("sp_cambia_ticketfactura", "@idFactura", FacturaId, "@CTEClave", oCFD.CTEClave)

                        If dtAbonos.Rows.Count > 0 Then
                            Dim y As Integer
                            For y = 0 To dtAbonos.Rows.Count - 1
                                If CDbl(dtAbonos.Rows(y)("Abonos")) > 0 Then
                                    ModPOS.Aplica_Pagos_Tickets(FacturaId, CDbl(dtAbonos.Rows(y)("Abonos")), oCFD.CTEClave)
                                End If
                            Next
                        End If

                        dtAbonos.Dispose()
                    Else
                        ' recupera el saldo de las ventas de las facturas 
                        ModPOS.Ejecuta("st_saldo_ticketfactura", "@FacturaId", FacturaId, "@CTEClave", oCFD.CTEClave)

                    End If

                    'Seccion para agregar multiples metodos de pago

                    If oCFD.VersionCF = "3.3" AndAlso iCredito = 1 Then

                        ModPOS.Ejecuta("sp_agregar_metodopagofac", _
                           "@FacturaID", FacturaId, _
                           "@MetodoPago", "", _
                           "@Banco", "", _
                           "@Referencia", "", _
                           "@SAT", "99")

                    Else

                        Dim dtFacturas As DataTable
                        Dim SaldoFactura As Decimal
                        dtFacturas = ModPOS.Recupera_Tabla("sp_recupera_factura", "@FacturaID", FacturaId)
                        SaldoFactura = IIf(dtFacturas.Compute("Sum(SaldoBase)", "SaldoBase > 0") Is System.DBNull.Value, 0, dtFacturas.Compute("Sum(SaldoBase)", "SaldoBase > 0"))

                        oCFD.metodoDePago = ""
                        oCFD.NumCtaPago = ""
                        Dim dtMetodosPago As DataTable


                        Dim bMetodoCte As Boolean = False

                        If ModPOS.TruncateToDecimal(SaldoFactura, 1) > 0 Then
                            dtMetodosPago = ModPOS.Recupera_Tabla("sp_recupera_metodospago_cte", "@CTEClave", oCFD.CTEClave)
                            bMetodoCte = True
                        Else
                            dtMetodosPago = ModPOS.Recupera_Tabla("st_recupera_metodospago_fac", "@FacturaId", FacturaId)
                        End If

                        If dtMetodosPago.Rows.Count = 0 OrElse (dtMetodosPago.Rows.Count > 1 AndAlso bMetodoCte = True) Then
                            If ModPOS.MetodoPago Is Nothing Then
                                ModPOS.MetodoPago = New FrmMetodoPago
                                With ModPOS.MetodoPago
                                    .CTEClave = oCFD.CTEClave
                                    .FacturaId = FacturaId
                                    .VersionCF = oCFD.VersionCF
                                End With
                            End If

                            ModPOS.MetodoPago.StartPosition = FormStartPosition.CenterScreen

                            If ModPOS.MetodoPago.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                                If ModPOS.MetodoPago.MetodoDePago <> "" Then
                                    oCFD.metodoDePago = ModPOS.MetodoPago.MetodoDePago
                                    oCFD.NumCtaPago = ModPOS.MetodoPago.NumCtaPago
                                End If
                            End If

                            ModPOS.MetodoPago.Dispose()
                            ModPOS.MetodoPago = Nothing
                        Else
                            Dim x As Integer
                            For x = 0 To dtMetodosPago.Rows.Count - 1
                                Referencia = IIf(dtMetodosPago.Rows(x)("Referencia").GetType.Name <> "DBNull", CStr(dtMetodosPago.Rows(x)("Referencia")).Trim.ToUpper, "")
                                Banco = IIf(dtMetodosPago.Rows(x)("Banco").GetType.Name <> "DBNull", dtMetodosPago.Rows(x)("Banco"), "")
                                Tipo = IIf(dtMetodosPago.Rows(x)("Tipo").GetType.Name <> "DBNull", dtMetodosPago.Rows(x)("Tipo"), "")
                                SAT = IIf(dtMetodosPago.Rows(x)("SAT").GetType.Name <> "DBNull", dtMetodosPago.Rows(x)("SAT"), "99")


                                ModPOS.Ejecuta("sp_agregar_metodopagofac", _
                                       "@FacturaID", FacturaId, _
                                       "@MetodoPago", Tipo, _
                                       "@Banco", Banco, _
                                       "@Referencia", Referencia, _
                                       "@SAT", SAT)

                                If oCFD.VersionCF <> "3.3" Then
                                    If SAT <> "" Then
                                        If oCFD.metodoDePago = "" Then
                                            oCFD.metodoDePago = SAT
                                        Else
                                            oCFD.metodoDePago &= "," & SAT
                                        End If
                                    End If

                                    If Referencia <> "" Then
                                        If oCFD.NumCtaPago = "" Then
                                            oCFD.NumCtaPago = Referencia
                                        Else
                                            oCFD.NumCtaPago &= "," & Referencia
                                        End If
                                    End If
                                ElseIf oCFD.metodoDePago = "" And SAT <> "" Then
                                    oCFD.metodoDePago = SAT
                                    If Referencia <> "" AndAlso oCFD.NumCtaPago = "" Then
                                        oCFD.NumCtaPago = Referencia
                                    End If
                                    Exit For
                                End If
                            Next

                        End If

                        dtMetodosPago.Dispose()

                    End If

                    'valida addenda  soriana
                    If oCFD.tieneAddenda = True Then
                        If oCFD.Tipo = 1 Then
                            'abrir cuadro de dialogo para registro de 
                            Dim a As New FrmComplemento
                            a.FacturaId = FacturaId
                            If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                If a.Autorizado Then
                                    oCFD.FechaEntrega = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", a.FechaEntrega)
                                    oCFD.NotaEntrada = a.NotaEntrada
                                    oCFD.NoCita = a.NoCita
                                    oCFD.FACClave = FACClave
                                Else
                                    a.Dispose()
                                    frmStatusMessage.Dispose()
                                    Exit Sub
                                End If
                            ElseIf a.DialogResult = DialogResult.Cancel Then
                                a.Dispose()
                                frmStatusMessage.Dispose()
                                Exit Sub
                            End If
                            a.Dispose()
                        End If
                    End If


                    'Se llena la tabla dt con todos los FACClave relacionados al FacturaID
                    dt = ModPOS.Recupera_Tabla("sp_recupera_facturas", "@FacturaID", FacturaId)

                    dtConcepto = ModPOS.Recupera_Tabla("sp_recupera_concepto", "@FacturaID", FacturaId)

                    dtImpuesto = ModPOS.Recupera_Tabla("sp_recupera_impuestos", "@FacturaID", FacturaId)

                    oCFD.Serie = dt.Rows(0)("Serie")
                    oCFD.Folio = dt.Rows(0)("Folio")
                    oCFD.descuento = dt.Rows(0)("descuentoTot")
                    oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", dt.Rows(0)("fechaFactura"))
                    oCFD.Moneda = dt.Rows(0)("Moneda")
                    oCFD.TipoCambio = dt.Rows(0)("TipoCambio")
                    oCFD.total = dt.Rows(0)("Total")

                    If oCFD.TipoCF = 1 OrElse oCFD.TipoCF = 2 Then

                        oCFD.DOCClave = dt.Rows(0)("FACClave")

                        If oCFD.VersionCF = "3.3" Then
                            dtDetalleImpuesto = ModPOS.Recupera_Tabla("st_recupera_impuesto_det", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", 1, "@Clave", oCFD.DOCClave)
                        End If

                        If oCFD.TipoCF = 1 Then
                            oCFD.cadenaOriginal = generarCadenaOriginal(oCFD, dtConcepto, dtImpuesto)
                        Else
                            oCFD.cadenaOriginal = generarCadenaOriginalCFDI(oCFD, dtConcepto, dtImpuesto, 1, dtDetalleImpuesto)
                        End If

                        oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)


                        iTipoPac = crearXML(1, dtPac, PathXML, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, 1, InterfazSalida, dtDetalleImpuesto)

                    Else
                        actualizaEdoCFD(oCFD.tipoDeComprobante, oCFD.DOCClave, 1, 1)
                    End If


                    If oCFD.tieneAddenda = True Then
                        If oCFD.Tipo = 1 Then

                            Dim NombreArchivo As String = oCFD.Serie & oCFD.Folio & ".xml"

                            Try
                                'Dim osvSoriana As New com.soriana.www.wseDocRecibo()
                                'osvSoriana.Url = oCFD.Firma
                                'osvSoriana.Timeout = 50000

                                Dim xmlDoc As New System.Xml.XmlDocument()
                                xmlDoc.Load(System.IO.Path.Combine(PathXML, NombreArchivo))

                                ' Now create StringWriter object to get data from xml document.
                                Dim sw As New System.IO.StringWriter()
                                Dim xw As New System.Xml.XmlTextWriter(sw)
                                xmlDoc.WriteTo(xw)

                                Dim res As String ' = osvSoriana.RecibeCFD(sw.ToString())

                                Dim dsRes As New System.Data.DataSet()
                                Dim ms As System.IO.MemoryStream
                                Dim buf As [Byte]()

                                buf = System.Text.ASCIIEncoding.ASCII.GetBytes(res)
                                ms = New System.IO.MemoryStream(buf)
                                dsRes.ReadXml(ms)

                                If dsRes.Tables("AckErrorApplication").Rows(0)("documentStatus").ToString().ToUpper() = "ACCEPTED" Then
                                    Dim sAPERAK As String = System.IO.Path.Combine(PathXML, "APERAK_" & System.IO.Path.GetFileNameWithoutExtension(NombreArchivo) & "_" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".xml")
                                    Using fs As System.IO.FileStream = System.IO.File.Open(sAPERAK, System.IO.FileMode.Create, System.IO.FileAccess.Write)
                                        ms.WriteTo(fs)
                                        ms.Dispose()
                                    End Using
                                    dsRes.Dispose()


                                    ModPOS.Ejecuta("sp_upd_complemento_envio", "@FACClave", oCFD.FACClave)

                                    MessageBox.Show("XML Aceptado : FACTURA " & oCFD.Serie & oCFD.Folio & ": Revisar " & sAPERAK, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Else
                                    Dim sAPERAK As String = System.IO.Path.Combine(PathXML, "APERAK_" & System.IO.Path.GetFileNameWithoutExtension(NombreArchivo) & "_" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".xml")
                                    Using fs As System.IO.FileStream = System.IO.File.Open(sAPERAK, System.IO.FileMode.Create, System.IO.FileAccess.Write)
                                        ms.WriteTo(fs)
                                        ms.Dispose()
                                    End Using
                                    Throw New Exception("XML Rechazado: Revisar " & sAPERAK)
                                End If
                            Catch ex As System.Exception
                                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End Try

                        End If
                    End If

                    dt.Dispose()
                    dtConcepto.Dispose()
                    dtImpuesto.Dispose()

                End If

                If ImprimeFactura = True Then
                    If oCFD.ImprimirFac = True Then
                        ModPOS.imprimirFacturas(oCFD.TipoCF, FacturaId, SUCClave, TipoCambio, MonedaDesc, MonedaRef, PrinterInvoice, IIf(iCredito = 1, NumCopias + 1, 1), oCFD.VersionCF)
                    End If
                End If

                If EnviaFactura = True Then
                    If oCFD.email <> "" Then
                        ModPOS.SendMail(oCFD.VersionCF, oCFD.email, oCFD.TipoCF, sFormatoFactura, CDate(oCFD.Fecha), oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.total, MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonedaDesc, MonedaRef, Logo)
                    End If
                End If

                System.Threading.Thread.Sleep(1000)

            Next
            frmStatusMessage.Dispose()

            Cursor.Current = Cursors.Default
        End If
    End Sub


    Private Sub btnMasiva_Click(sender As Object, e As EventArgs) Handles btnMasiva.Click
        Dim foundRows() As DataRow
        foundRows = dtCxC.Select("Marca ='True' and TipoDocumento=1 and Tipo='Credito' and Total=Saldo ")
        If foundRows.GetLength(0) > 0 Then

            Cursor.Current = Cursors.WaitCursor
            Select Case MessageBox.Show("Se re generaran una Factura por cada documento marcado, esta de acuerdo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes

                    Dim iTipoPac, i, iCredito As Integer
                    Dim Vencimiento As DateTime
                    Dim dt, dtPac, dtConcepto, dtImpuesto, dtDetalleImpuesto As DataTable
                    Dim oCFD As New CFD
                    Dim ImprimeFactura As Boolean = False
                    Dim EnviaFactura As Boolean = False
                    Dim FacturaId As String
                    Dim FACClave As String
                    Dim MONClave As String = ""

                    oCFD.TipoCF = TipoCF
                    oCFD.VersionCF = VersionCF
                    oCFD.regimenFiscal = regimenFiscal

                    If oCFD.VersionCF = "3.3" Then
                        oCFD.tipoDeComprobante = "I"
                    Else
                        oCFD.tipoDeComprobante = "ingreso"
                    End If

                    'Verifica Timbres
                    If oCFD.TipoCF = 2 Then
                        dtPac = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)

                        If dtPac Is Nothing OrElse dtPac.Rows.Count <= 0 Then
                            MessageBox.Show("No se encontraron timbres disponibles, verifique la configuración de timbres en la Compañia actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If

                    ' Verifica Certificado
                    dt = ModPOS.Recupera_Tabla("sp_recupera_certificadovigente", "@COMClave", ModPOS.CompanyActual)
                    If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                        oCFD.noCertificado = dt.Rows(0)("Serie")
                        oCFD.Certificado64 = dt.Rows(0)("Certificado")
                        oCFD.LlaveFile = dt.Rows(0)("Llave")
                        oCFD.ContrasenaClave = dt.Rows(0)("Password")
                        dt.Dispose()
                    Else
                        MessageBox.Show("No existen certificado vigente disponible para emitir algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    'Verifica que exista el path
                    Try
                        If Not System.IO.Directory.Exists(PathXML) Then
                            MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    Catch ex As Exception
                    End Try

                    'Verifica que exista el path del .Key
                    Try
                        If Not System.IO.File.Exists(oCFD.LlaveFile) Then
                            MessageBox.Show("El archivo " & oCFD.LlaveFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    Catch ex As Exception
                    End Try

                    Dim NumFacturas As Integer = foundRows.GetLength(0)

                    If Not ModPOS.validaFolio(SUCClave, CAJClave, 1, NumFacturas) Then
                        Exit Sub
                    End If

                    'Recupera la llave 
                    Dim DirSello As String = "C:\SelladoDigital\" & System.IO.Path.GetFileName(oCFD.LlaveFile)

                    If Not System.IO.File.Exists(DirSello) Then
                        If System.IO.File.Exists(oCFD.LlaveFile) Then
                            System.IO.File.Copy(oCFD.LlaveFile, DirSello)
                        Else
                            MessageBox.Show("El archivo " & oCFD.LlaveFile & " no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If

                    Dim dir As String
                    Dim DirArchivoPEM As String = DirSello & ".pem"

                    dir = "C:\OpenSSL\bin\openssl.exe"

                    Shell(dir & " pkcs8 -inform DER -in " & DirSello & " -passin pass:" & oCFD.ContrasenaClave & " -out " & DirArchivoPEM, AppWinStyle.Hide, True)


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


                    If MessageBox.Show("¿Desea imprimir los documento(s)?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        ImprimeFactura = True
                    End If

                    If MessageBox.Show("¿Desea enviar los documento(s) por correo electrónico?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        EnviaFactura = True
                    End If



                    Dim frmStatusMessage As New frmStatus
                    Dim Referencia As String
                    Dim Banco As String
                    Dim Tipo As String
                    Dim SAT As String
                    Dim Logo As Integer = 1
                    Dim sFormatoFactura As String

                    For i = 0 To foundRows.GetUpperBound(0)

                        frmStatusMessage.Show("Generando Comprobantes Fiscales Digitales " & CStr(i + 1) & "/" & CStr(foundRows.GetLength(0)))

                        sFormatoFactura = FormatoFactura


                        If MONClave <> foundRows(i)("MONClave") Then
                            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", foundRows(i)("MONClave"))
                            MONClave = dt.Rows(0)("MONClave")
                            MonedaRef = dt.Rows(0)("Referencia")
                            MonedaDesc = dt.Rows(0)("Descripcion")
                            TipoCambio = foundRows(i)("TipoCambio")
                            dt.Dispose()
                        End If

                        oCFD.TImpuesto = foundRows(i)("TipoImpuesto")

                        'Carga datos Receptor
                        Dim SaldoCliente As Double
                        dt = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", foundRows(i)("CTEClave"))


                        oCFD.CTEClave = dt.Rows(0)("CTEClave")
                        oCFD.CURP = dt.Rows(0)("CURP")
                        oCFD.Clave = dt.Rows(0)("Clave")

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


                        If oCFD.Referencia = "" Then
                            oCFD.Referencia = "SIN REFERENCIA"
                        End If

                        If oCFD.noInterior <> "" Then
                            oCFD.brnoInterior = True
                        Else
                            oCFD.brnoInterior = False
                        End If

                        SaldoCliente = dt.Rows(0)("Disponible")
                        oCFD.UsoCFDI = IIf(dt.Rows(0)("UsoCFDI").GetType.Name = "DBNull", "G03", dt.Rows(0)("UsoCFDI"))

                        dt.Dispose()
                        'Fin receptor

                        dt = ModPOS.SiExisteRecupera("sp_recupera_addcte", "@CTEClave", oCFD.CTEClave)

                        If Not dt Is Nothing Then
                            oCFD.tieneAddenda = True
                            oCFD.Tipo = dt.Rows(0)("Tipo")
                            oCFD.TipoConexion = dt.Rows(0)("TipoConexion")
                            oCFD.UsuarioFTP = dt.Rows(0)("UsuarioFTP")
                            oCFD.PwdFTP = dt.Rows(0)("PwdFTP")
                            oCFD.FTP = dt.Rows(0)("FTP")
                            oCFD.Firma = dt.Rows(0)("FirmaWeb")
                            oCFD.emailAdd = dt.Rows(0)("email")
                            oCFD.NoProveedor = dt.Rows(0)("NoProveedor")
                            sFormatoFactura = dt.Rows(0)("FormatoFactura")
                        Else
                            oCFD.tieneAddenda = False
                        End If



                        If VerificaDatoFiscalCte(oCFD) = True Then

                            'Valida credito
                            If foundRows(i)("Tipo") = "Credito" Then
                                Dim dtVencimiento As DataTable = ModPOS.SiExisteRecupera("sp_calcula_vencimiento", "@Dias", oCFD.DiasCredito)
                                If Not dtVencimiento Is Nothing Then
                                    Vencimiento = dtVencimiento.Rows(0)("Vencimiento")
                                    dtVencimiento.Dispose()
                                End If
                                iCredito = 1
                                oCFD.CondicionesDePago = CStr(oCFD.DiasCredito) & " días"
                            Else
                                iCredito = 0
                                Vencimiento = Today.Date
                                oCFD.CondicionesDePago = "Contado"
                            End If


                            'metodo de pago
                            If oCFD.VersionCF = "3.3" Then
                                If iCredito = 1 Then
                                    oCFD.formaDePago = "PPD"
                                    oCFD.metodoDePago = "99"
                                Else
                                    oCFD.formaDePago = "PUE"
                                End If
                            Else
                                oCFD.formaDePago = "Pago en una sola exhibición"
                            End If


                            FacturaId = ModPOS.obtenerLlave
                            FACClave = ModPOS.obtenerLlave


                            ' Graba factura y detalle

                            NumFacturas -= 1

                            oCFD.DOCClave = FACClave

                            ModPOS.recuperaFolio(SUCClave, CAJClave, 1, oCFD)


                            Dim dtLogo As DataTable = ModPOS.Recupera_Tabla("st_recupera_logo_fac", "@FACClave", FACClave, "@VENClave", foundRows(i)("ID"))
                            Logo = dtLogo.Rows(0)("Logo")
                            dtLogo.Dispose()

                            ModPOS.Ejecuta("st_venta_factura", _
                                           "@idFactura", FacturaId, _
                                           "@FACClave", FACClave, _
                                           "@VENClave", foundRows(i)("ID"), _
                                           "@CAJClave", CAJClave, _
                                           "@tipo", oCFD.tipoDeComprobante, _
                                           "@TipoCF", oCFD.TipoCF, _
                                           "@VersionCF", oCFD.VersionCF, _
                                           "@RegimenFiscal", oCFD.regimenFiscal, _
                                           "@fechaAprobacion", oCFD.fechaAprobacion, _
                                           "@Serie", oCFD.Serie, _
                                           "@Folio", oCFD.Folio, _
                                           "@CTEClave", oCFD.CTEClave, _
                                           "@Credito", iCredito, _
                                           "@DiasCredito", oCFD.DiasCredito, _
                                           "@FechaVencimiento", Vencimiento, _
                                           "@Desglosar", oCFD.NoDesglosaIEPS, _
                                           "@formaDePago", oCFD.formaDePago, _
                                           "@MONClave", MONClave, _
                                           "@TipoCambio", TipoCambio, _
                                           "@Formato", sFormatoFactura, _
                                           "@Nota", foundRows(i)("Nota"), _
                                           "@UsoCFDI", oCFD.UsoCFDI, _
                                           "@Logo", Logo, _
                                           "@Usuario", ModPOS.UsuarioActual, _
                                           "@TallaColor", TallaColor)


                            'Seccion para agregar multiples metodos de pago

                            If oCFD.VersionCF = "3.3" AndAlso iCredito = 1 Then

                                ModPOS.Ejecuta("sp_agregar_metodopagofac", _
                                   "@FacturaID", FacturaId, _
                                   "@MetodoPago", "", _
                                   "@Banco", "", _
                                   "@Referencia", "", _
                                   "@SAT", "99")

                            Else
                                oCFD.metodoDePago = ""
                                oCFD.NumCtaPago = ""
                                Dim dtMetodosPago As DataTable = ModPOS.Recupera_Tabla("sp_recupera_metodospago_cte", "@CTEClave", oCFD.CTEClave)

                                If dtMetodosPago.Rows.Count <> 1 Then
                                    If ModPOS.MetodoPago Is Nothing Then
                                        ModPOS.MetodoPago = New FrmMetodoPago
                                        With ModPOS.MetodoPago
                                            .CTEClave = oCFD.CTEClave
                                            .FacturaId = FacturaId
                                            .VersionCF = oCFD.VersionCF
                                        End With
                                    End If

                                    ModPOS.MetodoPago.StartPosition = FormStartPosition.CenterScreen

                                    If ModPOS.MetodoPago.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                                        If ModPOS.MetodoPago.MetodoDePago <> "" Then
                                            oCFD.metodoDePago = ModPOS.MetodoPago.MetodoDePago
                                            oCFD.NumCtaPago = ModPOS.MetodoPago.NumCtaPago
                                        End If
                                    End If

                                    ModPOS.MetodoPago.Dispose()
                                    ModPOS.MetodoPago = Nothing
                                Else
                                    Dim x As Integer
                                    For x = 0 To dtMetodosPago.Rows.Count - 1
                                        Referencia = IIf(dtMetodosPago.Rows(x)("Referencia").GetType.Name <> "DBNull", CStr(dtMetodosPago.Rows(x)("Referencia")).Trim.ToUpper, "")
                                        Banco = IIf(dtMetodosPago.Rows(x)("Banco").GetType.Name <> "DBNull", dtMetodosPago.Rows(x)("Banco"), "")
                                        Tipo = IIf(dtMetodosPago.Rows(x)("Tipo").GetType.Name <> "DBNull", dtMetodosPago.Rows(x)("Tipo"), "")
                                        SAT = IIf(dtMetodosPago.Rows(x)("SAT").GetType.Name <> "DBNull", dtMetodosPago.Rows(x)("SAT"), "99")


                                        ModPOS.Ejecuta("sp_agregar_metodopagofac", _
                                               "@FacturaID", FacturaId, _
                                               "@MetodoPago", Tipo, _
                                               "@Banco", Banco, _
                                               "@Referencia", Referencia, _
                                               "@SAT", SAT)

                                        If oCFD.VersionCF <> "3.3" Then
                                            If SAT <> "" Then
                                                If oCFD.metodoDePago = "" Then
                                                    oCFD.metodoDePago = SAT
                                                Else
                                                    oCFD.metodoDePago &= "," & SAT
                                                End If
                                            End If

                                            If Referencia <> "" Then
                                                If oCFD.NumCtaPago = "" Then
                                                    oCFD.NumCtaPago = Referencia
                                                Else
                                                    oCFD.NumCtaPago &= "," & Referencia
                                                End If
                                            End If
                                        ElseIf oCFD.metodoDePago = "" And SAT <> "" Then
                                            oCFD.metodoDePago = SAT
                                            If Referencia <> "" AndAlso oCFD.NumCtaPago = "" Then
                                                oCFD.NumCtaPago = Referencia
                                            End If
                                            Exit For
                                        End If
                                    Next

                                End If

                                dtMetodosPago.Dispose()

                            End If

                            'valida addenda  soriana
                            If oCFD.tieneAddenda = True Then
                                If oCFD.Tipo = 1 Then
                                    'abrir cuadro de dialogo para registro de 
                                    Dim a As New FrmComplemento
                                    a.FacturaId = FacturaId
                                    If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                        If a.Autorizado Then
                                            oCFD.FechaEntrega = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", a.FechaEntrega)
                                            oCFD.NotaEntrada = a.NotaEntrada
                                            oCFD.NoCita = a.NoCita
                                            oCFD.FACClave = FACClave
                                        Else
                                            a.Dispose()
                                            frmStatusMessage.Dispose()
                                            Exit Sub
                                        End If
                                    ElseIf a.DialogResult = DialogResult.Cancel Then
                                        a.Dispose()
                                        frmStatusMessage.Dispose()
                                        Exit Sub
                                    End If
                                    a.Dispose()
                                End If
                            End If


                            'Se llena la tabla dt con todos los FACClave relacionados al FacturaID
                            dt = ModPOS.Recupera_Tabla("sp_recupera_facturas", "@FacturaID", FacturaId)

                            dtConcepto = ModPOS.Recupera_Tabla("sp_recupera_concepto", "@FacturaID", FacturaId)

                            dtImpuesto = ModPOS.Recupera_Tabla("sp_recupera_impuestos", "@FacturaID", FacturaId)

                            oCFD.Serie = dt.Rows(0)("Serie")
                            oCFD.Folio = dt.Rows(0)("Folio")
                            oCFD.descuento = dt.Rows(0)("descuentoTot")
                            oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", dt.Rows(0)("fechaFactura"))
                            oCFD.Moneda = dt.Rows(0)("Moneda")
                            oCFD.TipoCambio = dt.Rows(0)("TipoCambio")
                            oCFD.total = dt.Rows(0)("Total")

                            If oCFD.TipoCF = 1 OrElse oCFD.TipoCF = 2 Then

                                oCFD.DOCClave = dt.Rows(0)("FACClave")

                                If oCFD.VersionCF = "3.3" Then
                                    dtDetalleImpuesto = ModPOS.Recupera_Tabla("st_recupera_impuesto_det", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", 1, "@Clave", oCFD.DOCClave)
                                End If

                                If oCFD.TipoCF = 1 Then
                                    oCFD.cadenaOriginal = generarCadenaOriginal(oCFD, dtConcepto, dtImpuesto)
                                Else
                                    oCFD.cadenaOriginal = generarCadenaOriginalCFDI(oCFD, dtConcepto, dtImpuesto, 1, dtDetalleImpuesto)
                                End If

                                oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)


                                iTipoPac = crearXML(1, dtPac, PathXML, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, 1, InterfazSalida, dtDetalleImpuesto)

                            Else
                                actualizaEdoCFD(oCFD.tipoDeComprobante, oCFD.DOCClave, 1, 1)
                            End If


                            If oCFD.tieneAddenda = True Then
                                If oCFD.Tipo = 1 Then

                                    Dim NombreArchivo As String = oCFD.Serie & oCFD.Folio & ".xml"

                                    Try
                                        'Dim osvSoriana As New com.soriana.www.wseDocRecibo()
                                        'osvSoriana.Url = oCFD.Firma
                                        'osvSoriana.Timeout = 50000

                                        Dim xmlDoc As New System.Xml.XmlDocument()
                                        xmlDoc.Load(System.IO.Path.Combine(PathXML, NombreArchivo))

                                        ' Now create StringWriter object to get data from xml document.
                                        Dim sw As New System.IO.StringWriter()
                                        Dim xw As New System.Xml.XmlTextWriter(sw)
                                        xmlDoc.WriteTo(xw)

                                        Dim res As String ' = osvSoriana.RecibeCFD(sw.ToString())

                                        Dim dsRes As New System.Data.DataSet()
                                        Dim ms As System.IO.MemoryStream
                                        Dim buf As [Byte]()

                                        buf = System.Text.ASCIIEncoding.ASCII.GetBytes(res)
                                        ms = New System.IO.MemoryStream(buf)
                                        dsRes.ReadXml(ms)

                                        If dsRes.Tables("AckErrorApplication").Rows(0)("documentStatus").ToString().ToUpper() = "ACCEPTED" Then
                                            Dim sAPERAK As String = System.IO.Path.Combine(PathXML, "APERAK_" & System.IO.Path.GetFileNameWithoutExtension(NombreArchivo) & "_" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".xml")
                                            Using fs As System.IO.FileStream = System.IO.File.Open(sAPERAK, System.IO.FileMode.Create, System.IO.FileAccess.Write)
                                                ms.WriteTo(fs)
                                                ms.Dispose()
                                            End Using
                                            dsRes.Dispose()


                                            ModPOS.Ejecuta("sp_upd_complemento_envio", "@FACClave", oCFD.FACClave)

                                            MessageBox.Show("XML Aceptado : FACTURA " & oCFD.Serie & oCFD.Folio & ": Revisar " & sAPERAK, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Else
                                            Dim sAPERAK As String = System.IO.Path.Combine(PathXML, "APERAK_" & System.IO.Path.GetFileNameWithoutExtension(NombreArchivo) & "_" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".xml")
                                            Using fs As System.IO.FileStream = System.IO.File.Open(sAPERAK, System.IO.FileMode.Create, System.IO.FileAccess.Write)
                                                ms.WriteTo(fs)
                                                ms.Dispose()
                                            End Using
                                            Throw New Exception("XML Rechazado: Revisar " & sAPERAK)
                                        End If
                                    Catch ex As System.Exception
                                        MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End Try

                                End If
                            End If

                            dt.Dispose()
                            dtConcepto.Dispose()
                            dtImpuesto.Dispose()

                        End If

                        If ImprimeFactura = True Then
                            If oCFD.ImprimirFac = True Then
                                ModPOS.imprimirFacturas(oCFD.TipoCF, FacturaId, SUCClave, TipoCambio, MonedaDesc, MonedaRef, PrinterInvoice, IIf(iCredito = 1, NumCopias + 1, 1), oCFD.VersionCF)
                            End If
                        End If

                        If EnviaFactura = True Then
                            If oCFD.email <> "" Then
                                ModPOS.SendMail(oCFD.VersionCF, oCFD.email, oCFD.TipoCF, sFormatoFactura, CDate(oCFD.Fecha), oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.total, MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonedaDesc, MonedaRef, Logo)
                            End If
                        End If

                        System.Threading.Thread.Sleep(1000)

                    Next
                    frmStatusMessage.Dispose()
            End Select
            Cursor.Current = Cursors.Default
            Me.AgregarFolio()
        Else
            MessageBox.Show("Debe seleccionar unicamente ventas de tipo Crédito que no hayan sido pagadas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnReenvio_Click(sender As Object, e As EventArgs) Handles btnReenvio.Click

        Dim foundRows() As DataRow

        ' Usa el metodo select para filtrar los registros seleccionados.
        foundRows = dtCxC.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then

            If MailAdress = "" OrElse MailUser = "" OrElse MailPassword = "" OrElse HostSMTP = "" OrElse MailPort = 0 Then
                MessageBox.Show("No se ha configurado una cuenta de correo para envio de información en el Menú de Configuración\Compañia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            Try
                If Not System.IO.Directory.Exists(PathXML) Then
                    MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
            End Try

            Dim PathPDF As String
            Dim i, j As Integer
            Dim frmStatusMessage As New frmStatus

            Dim MonRef, MonDesc, sVersionCF As String
            Dim TipoCambio As Double
            Dim dt As DataTable
            Dim eMailCte As String = ""
            Dim sMailCliente As String = ""
            Dim sClienteActual As String = ""

            For i = 0 To foundRows.GetUpperBound(0)

                If sClienteActual <> foundRows(i)("Cve. Cte.") Then
                    eMailCte = foundRows(i)("Email").ToString.Trim
                    sClienteActual = foundRows(i)("Cve. Cte.")
                End If


                If eMailCte = "" OrElse eMailCte <> sMailCliente Then
                    Dim m As New FrmCorreo
                    m.eMail = eMailCte
                    m.Folio = " Folio: " & foundRows(i)("Folio") & " Cliente: " & foundRows(i)("Cve. Cte.")
                    If m.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        eMailCte = m.Correo
                    Else
                        eMailCte = "Salir"
                    End If
                    m.Dispose()
                End If

                If eMailCte <> "" Then
                    If eMailCte <> "Salir" Then
                        PathPDF = pathActual & "Temp\" & foundRows(i)("Folio") & ".PDF"

                        Dim iTipoCF As Integer = IIf(foundRows(i)("TipoCF").GetType.Name = "DBNull", 1, foundRows(i)("TipoCF"))

                        Select Case CInt(foundRows(i)("TipoDocumento"))

                            Case Is = 2 'FAC

                                'Genera PDF

                                dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "F", "@Documento", foundRows(i)("ID"))
                                TipoCambio = dt.Rows(0)("TipoCambio")
                                MonRef = dt.Rows(0)("Referencia")
                                MonDesc = dt.Rows(0)("Descripcion")
                                sVersionCF = dt.Rows(0)("VersionCF")
                                Dim sFormato As String
                                sFormato = IIf(dt.Rows(0)("Formato").GetType.Name = "DBNull", "Clasico", dt.Rows(0)("Formato"))

                                dt.Dispose()

                                ModPOS.SendMail(sVersionCF, eMailCte, iTipoCF, sFormato, foundRows(i)("Fecha"), foundRows(i)("Folio"), foundRows(i)("ID"), foundRows(i)("Total"), MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonRef, MonDesc, foundRows(i)("Logo"))


                            Case Is = 4 'NC

                                dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "N", "@Documento", foundRows(i)("ID"))
                                TipoCambio = dt.Rows(0)("TipoCambio")
                                MonRef = dt.Rows(0)("Referencia")
                                MonDesc = dt.Rows(0)("Descripcion")
                                sVersionCF = dt.Rows(0)("VersionCF")
                                dt.Dispose()


                                ModPOS.SendMailNC(VersionCF, eMailCte, iTipoCF, FormatNC, CDate(foundRows(i)("Fecha")), foundRows(i)("Folio"), foundRows(i)("ID"), foundRows(i)("Total"), MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonDesc, MonRef, foundRows(i)("Logo"), True)


                            Case Is = 6 'Nota de Cargo


                                dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "C", "@Documento", foundRows(i)("ID"))
                                TipoCambio = dt.Rows(0)("TipoCambio")
                                MonRef = dt.Rows(0)("Referencia")
                                MonDesc = dt.Rows(0)("Descripcion")
                                sVersionCF = dt.Rows(0)("VersionCF")

                                dt.Dispose()



                                ModPOS.SendMailCargo(VersionCF, eMailCte, FormatNC, CDate(foundRows(i)("Fecha")), foundRows(i)("Folio"), foundRows(i)("ID"), foundRows(i)("Total"), MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, TipoCambio, MonDesc, MonRef, foundRows(i)("Logo"), True)


                        End Select

                    End If
                    foundRows(i)("Marca") = False
                Else
                    MessageBox.Show("El cliente " & foundRows(i)("Cve. Cte.").ToString & ", no cuenta con dirección de correo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Next
            frmStatusMessage.Dispose()
            ChkMarcaTodos.Checked = False
            chkIncluir.Checked = False
            SaldoBase = ModPOS.Redondear(IIf(dtCxC.Compute("Sum(SaldoBase)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(SaldoBase)", "Marca = True")), 2)
            Me.LblSaldo.Text = Format(CStr(SaldoBase), "Currency")

            If TipoCambio <> 1 Then
                If SaldoBase > 0 Then
                    lblMonedaCambio.Text = RefCambio & " " & Format(CStr(Redondear(SaldoBase / TipoCambio, 2)), "Currency")
                Else
                    lblMonedaCambio.Text = RefCambio & " " & Format("0.00", "Currency")
                End If
            End If
        Else
            MessageBox.Show("Para reenviar, debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cmbTipoTrans_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoTrans.SelectedValueChanged
        If bload = True AndAlso Not cmbTipoTrans.SelectedValue Is Nothing Then
            preparaBotones(cmbTipoTrans.SelectedValue)
            If Not dtCxC Is Nothing Then
                dtCxC.Dispose()
                SaldoBase = 0
                Me.LblSaldo.Text = Format(CStr(ModPOS.Redondear(SaldoBase, 2)), "Currency")

                lblMonedaCambio.Text = RefCambio & " " & Format("0.00", "Currency")
                ChkMarcaTodos.Enabled = False
            End If
            AgregarFolio()
        End If

    End Sub

    Private Sub btnReembolso_Click(sender As Object, e As EventArgs) Handles btnReembolso.Click
        Dim i As Integer

        Dim foundRows() As DataRow

        ' Usa el metodo select para filtrar los registros seleccionados.
        foundRows = dtCxC.Select("Marca ='True' and SaldoBase > 0 and TipoNC = 1 ")
        If foundRows.GetLength(0) > 0 Then


            Dim fr() As DataRow

            fr = dtCxC.Select("Marca ='True' and SaldoBase > 0 and TipoNC = 1  and MONClave <> '" & foundRows(0)("MONClave") & "'")

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible reembolsar documentos de diferentes Monedas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            fr = dtCxC.Select("Marca ='True' and SaldoBase > 0 and TipoNC = 1  and MONClave = '" & foundRows(0)("MONClave") & "' and TipoCambio <> " & CStr(foundRows(0)("TipoCambio")))

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible reembolsar documentos de Tipo de Cambio diferentes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_busca_corteCaja", "@CAJClave", CAJClave)

            Dim IDCorte As String = ""
            Dim dEfectivo, dSaldo As Double

            If dt.Rows.Count > 0 Then
                IDCorte = dt.Rows(0)("ID")
            End If
            dt.Dispose()

            dt = Recupera_Tabla("st_recupera_efectivo_mon", "@IDCorte", IDCorte, "@COMClave", ModPOS.CompanyActual, "@MONClave", foundRows(0)("MONClave"))

            If dt.Rows.Count > 0 Then
                dEfectivo = dt.Rows(0)("Efectivo")
            End If
            dt.Dispose()

            dSaldo = ModPOS.Redondear(IIf(dtCxC.Compute("Sum(SaldoBase)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(SaldoBase)", "Marca = True")), 2)

            If (dSaldo / foundRows(0)("TipoCambio")) <= dEfectivo Then

                Select Case MessageBox.Show("¿Esta seguro de aplicar el reembolso a los documentos seleccionados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes

                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_aplica_reembolso", _
                                           "@CTEClave", foundRows(i)("CTEClave"), _
                                           "@DOCClave", foundRows(i)("ID"), _
                                           "@TipoDocumento", foundRows(i)("TipoDocumento"), _
                                           "@CAJClave", CAJClave, _
                                           "@Moneda", foundRows(i)("MONClave"), _
                                           "@TipoCambio", foundRows(i)("TipoCambio"), _
                                           "@Saldo", foundRows(i)("Saldo"), _
                                           "@Usuario", ModPOS.UsuarioActual)

                            foundRows(i)("Marca") = False
                        Next
                        ChkMarcaTodos.Checked = False
                        chkIncluir.Checked = False
                        dSaldo = ModPOS.Redondear(IIf(dtCxC.Compute("Sum(SaldoBase)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(SaldoBase)", "Marca = True")), 2)
                        Me.LblSaldo.Text = Format(CStr(dSaldo), "Currency")

                        If TipoCambiario <> 1 Then
                            If dSaldo > 0 Then
                                lblMonedaCambio.Text = RefCambio & " " & Format(CStr(Redondear(dSaldo / TipoCambiario, 2)), "Currency")
                            Else
                                lblMonedaCambio.Text = RefCambio & " " & Format("0.00", "Currency")
                            End If
                        End If

                        MessageBox.Show("La operación se realizo exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.AgregarFolio()
                End Select
            Else
                MessageBox.Show("El efectivo en Caja no es suficiente para realizar el reembolso", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else
            MessageBox.Show("Para aplicar el reembolso, debe marcar por lo menos un registro con Saldo mayor a cero y que sea una Devolución", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub


    Private Sub btnAcumulado_Click(sender As Object, e As EventArgs) Handles btnAcumulado.Click
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_busca_corteCaja", "@CAJClave", CAJClave)

        Dim IDCorte As String = ""

        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                IDCorte = dt.Rows(0)("ID")

                Dim OpenReport As New Report
                Dim pvtaDataSet As New DataSet
                pvtaDataSet.DataSetName = "pvtaDataSet"

                If Transferencia = 1 Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco_enc", "@IdCorte", IDCorte))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco", "@IdCorte", IDCorte))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_reembolso", "@IdCorte", IDCorte))
                    OpenReport.PrintPreview("Acumulado", "CRAcumulado.rpt", pvtaDataSet, "")
                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco_enc", "@IdCorte", IDCorte))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_acumulado", "@IdCorte", IDCorte))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_cobranzaCredito", "@IDCorte", IDCorte))
                    OpenReport.PrintPreview("Acumulado", "CRAcumula.rpt", pvtaDataSet, "")
                End If

            End If
            dt.Dispose()
        End If


    End Sub

    Private Sub btnCorte_Click(sender As Object, e As EventArgs) Handles btnCorte.Click
        Dim a As New FrmBuscaCorte
        a.CAJClave = Me.CAJClave
        a.inicio = Today
        a.fin = Today
        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            If a.IdCorte <> "" Then
                Dim OpenReport As New Report
                Dim pvtaDataSet As New DataSet

                If Transferencia = 1 Then
                    pvtaDataSet.DataSetName = "pvtaDataSet"
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco_enc", "@IdCorte", a.IdCorte))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_corte_det", "@IdCorte", a.IdCorte))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_creditos", "@IdCorte", a.IdCorte))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_otrospagos", "@IdCorte", a.IdCorte))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_tarjetaAmiga_det", "@IdCorte", a.IdCorte))

                    OpenReport.PrintPreview("Corte de Caja", "CRCorte.rpt", pvtaDataSet, "")
                Else
                    pvtaDataSet.DataSetName = "reportDataSet"

                    If TallaColor = 0 Then

                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco_enc", "@IdCorte", a.IdCorte))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_corte_det", "@IdCorte", a.IdCorte))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_corte_creditos", "@IdCorte", a.IdCorte))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_tarjetaAmiga_det", "@IdCorte", a.IdCorte))

                        OpenReport.PrintPreview("Reporte de Corte de Caja", "CRCorteCaja.rpt", pvtaDataSet, "")

                    Else
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco_enc", "@IdCorte", a.IdCorte))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_corte_cklass_det", "@IdCorte", a.IdCorte))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_corte_cklass", "@IdCorte", a.IdCorte))


                        Dim sImpresora As String
                        Dim iCopias As Integer = 1

                        If PrintDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                            sImpresora = PrintDialog1.PrinterSettings.PrinterName
                            iCopias = PrintDialog1.PrinterSettings.Copies
                        Else
                            Exit Sub
                        End If


                        OpenReport.Print(iCopias, "crCorteTicket.rpt", pvtaDataSet, "", sImpresora)

                    End If


                End If
            End If
        End If
        a.Dispose()
    End Sub


    Private Sub ChkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTodos.CheckedChanged
        If dtContrarecibos.Rows.Count > 0 Then
            Dim i As Integer
            If ChkTodos.Checked Then
                For i = 0 To GridContrarecibos.GetDataRows.Length - 1
                    GridContrarecibos.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridContrarecibos.GetDataRows.Length - 1
                    GridContrarecibos.GetDataRows(i).DataRow("Marca") = False
                Next
            End If

            dtContrarecibos.AcceptChanges()

        End If

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim a As New MeFiltroEmpHr
        a.Text = "Reporte de Relación de Facturas"
        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim OpenReport As New Report
            Dim pvtaDataSet As New DataSet
            pvtaDataSet.DataSetName = "reportDataSet"
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_contrarecibo", "@EMPClave", a.Empleado, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
            OpenReport.PrintPreview("Reporte de Relación de Facturas", "CRContrarecibos.rpt", pvtaDataSet, "")
        End If
        a.Dispose()
    End Sub

    Private Sub chkIncluir_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncluir.CheckedChanged
        AgregarFolio()
    End Sub

    Private Sub GridCxC_KeyUp(sender As Object, e As KeyEventArgs) Handles GridCxC.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If Not cmbTipoTrans.SelectedValue Is Nothing AndAlso (cmbTipoTrans.SelectedValue = 1 OrElse cmbTipoTrans.SelectedValue = 2) Then
                    Dim foundRows() As DataRow
                    foundRows = dtCxC.Select("Marca = True and SaldoBase > 0")
                    If foundRows.GetLength(0) > 0 Then
                        Me.BtnPago.PerformClick()
                    End If
                End If
            Case Is = Keys.F2
                Me.BtnRecibo.PerformClick()
            Case Is = Keys.F3
                Me.BtnAuditoria.PerformClick()
            Case Is = Keys.F4
                Me.BtnDevolucion.PerformClick()
            Case Is = Keys.F5
                Me.btnReembolso.PerformClick()
            Case Is = Keys.F6
                Me.BtnCancelar.PerformClick()
            Case Is = Keys.F7
                BtnNC.PerformClick()
            Case Is = Keys.F8
                Me.BtnFacturar.PerformClick()
            Case Is = Keys.F9
                Me.btnNotaCargo.PerformClick()
            Case Is = Keys.F10
                Me.BtnPago.PerformClick()
            Case Is = Keys.F11
                btnCorte.PerformClick()
            Case Is = Keys.F12
                BtnRefresh.PerformClick()
        End Select
    End Sub

    Private Sub BtnGlobal_Click(sender As Object, e As EventArgs) Handles BtnGlobal.Click
        Dim a As New FrmFacGlobal
        a.SUCClave = SUCClave
        a.CAJClave = CAJClave
        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

        End If
        a.Dispose()
        If validaForm() Then
            Me.AgregarFolio()
        End If
    End Sub



    Public Sub actualizaCliente()
        ModPOS.ActualizaGrid(True, Me.gridClientes, "sp_busca_clientes", "@Campo", CmbCampo.SelectedValue, "@Busca", TxtBuscar.Text.ToUpper.Trim.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
        Me.gridClientes.RootTable.Columns("ID").Visible = False
    End Sub

    Private Sub Clock2_Tick(sender As Object, e As EventArgs) Handles Clock2.Tick
        Clock2.Stop()
        If Not CmbCampo.SelectedValue Is Nothing Then
            If TxtBuscar.Text <> "" Then
                actualizaCliente()
            End If
        Else
            Beep()
            MessageBox.Show("¡No esta el filtro seleccionado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnEdoCta_Click(sender As Object, e As EventArgs) Handles BtnEdoCta.Click
        Dim a As New MeFiltroCte
        a.Text = "Reporte de Estado de Cuenta"
        If Not gridClientes.GetValue(0) Is Nothing Then
            a.CargaDatosCliente(gridClientes.GetValue(0))
        End If
        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim OpenReport As New Report
            Dim pvtaDataSet As New DataSet
            pvtaDataSet.DataSetName = "pvtaDataSet"
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_edocta_enc", "@CTEClave", a.Cliente))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_edocta_detalle", "@CTEClave", a.Cliente, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
            OpenReport.PrintPreview("Reporte de Estado de Cuenta del Cliente", "CREdoCte.rpt", pvtaDataSet, "")
        End If
        a.Dispose()

    End Sub

    Private Sub modificarCte(ByVal sCteSelected As String)
        If ModPOS.Cliente Is Nothing Then
            ModPOS.Cliente = New FrmCliente
            With ModPOS.Cliente
                .Text = "Modificar Cliente"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Modificar"
                .TxtClave.ReadOnly = True
                .fromForm = "Caja"
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", sCteSelected)
                .TipoOrigen = IIf(dt.Rows(0)("TipoOrigen").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoOrigen"))
                .RegFiscal = IIf(dt.Rows(0)("NumRegIdTrib").GetType.Name = "DBNull", "", dt.Rows(0)("NumRegIdTrib"))
                .CTEClave = dt.Rows(0)("CTEClave")
                .TPersona = dt.Rows(0)("TPersona")
                .Clave = dt.Rows(0)("Clave")
                .NombreCorto = dt.Rows(0)("NombreCorto")
                .RazonSocial = dt.Rows(0)("RazonSocial")
                .RFC = dt.Rows(0)("id_Fiscal")
                .CURP = dt.Rows(0)("CURP")
                .TipoCanal = IIf(dt.Rows(0)("TipoCanal").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoCanal"))
                .listaPrecio = IIf(dt.Rows(0)("PREClave").GetType.Name = "DBNull", "", dt.Rows(0)("PREClave"))
                .Responsable = IIf(dt.Rows(0)("Responsable").GetType.Name = "DBNull", 0, dt.Rows(0)("Responsable"))
                .CtaContable = IIf(dt.Rows(0)("CtaContable").GetType.Name = "DBNull", "", dt.Rows(0)("CtaContable"))

                .FechaReg = dt.Rows(0)("FechaRegistro")
                .Estado = dt.Rows(0)("Estado")
                .Alterno = IIf(dt.Rows(0)("Alterno").GetType.Name = "DBNull", "", dt.Rows(0)("Alterno"))
                .GLN = IIf(dt.Rows(0)("GLN").GetType.Name = "DBNull", "", dt.Rows(0)("GLN"))
                .Ramo = IIf(dt.Rows(0)("Ramo").GetType.Name = "DBNull", 0, dt.Rows(0)("Ramo"))
                .DesglosaIVA = dt.Rows(0)("DesglosaIVA")
                .ImprimirFac = IIf(dt.Rows(0)("ImprimirFac").GetType.Name = "DBNull", True, dt.Rows(0)("ImprimirFac"))
                .Facturable = IIf(dt.Rows(0)("facturable").GetType.Name = "DBNull", True, dt.Rows(0)("facturable"))

                .TipoImpuesto = dt.Rows(0)("TipoImpuesto")
                .LCredito = dt.Rows(0)("LimiteCredito")
                .DiasCredito = dt.Rows(0)("DiasCredito")

                .PaisF = dt.Rows(0)("Pais")
                .EntidadF = dt.Rows(0)("Entidad")
                .MnpioF = dt.Rows(0)("Municipio")
                .ColoniaF = dt.Rows(0)("Colonia")
                .CalleF = dt.Rows(0)("Calle")
                .LocalidadF = dt.Rows(0)("Localidad")
                .referenciaF = dt.Rows(0)("referencia")
                .noExteriorF = dt.Rows(0)("noExterior")
                .noInteriorF = dt.Rows(0)("noInterior")
                .codigoPostalF = dt.Rows(0)("codigoPostal")
                .ZonaVentaF = IIf(dt.Rows(0)("ZonaVenta").GetType.Name = "DBNull", 0, dt.Rows(0)("ZonaVenta"))
                .ZonaRepartoF = IIf(dt.Rows(0)("ZonaReparto").GetType.Name = "DBNull", 0, dt.Rows(0)("ZonaReparto"))

                .Contacto = dt.Rows(0)("Contacto")
                .fechaNacimiento = IIf(dt.Rows(0)("fechaNacimiento").GetType.Name = "DBNull", Today.Date, dt.Rows(0)("fechaNacimiento"))
                .Genero = IIf(dt.Rows(0)("Genero").GetType.Name = "DBNull", 0, dt.Rows(0)("Genero"))
                .tipoTel1 = IIf(dt.Rows(0)("tipoTel1").GetType.Name = "DBNull", 1, dt.Rows(0)("tipoTel1"))
                .tipoTel2 = IIf(dt.Rows(0)("tipoTel2").GetType.Name = "DBNull", 1, dt.Rows(0)("tipoTel2"))

                .Tel1 = dt.Rows(0)("Tel1")
                .Tel2 = dt.Rows(0)("Tel2")
                .email = dt.Rows(0)("Email")

                .Saldo = dt.Rows(0)("Saldo")
                .CreditoDisponible = dt.Rows(0)("Disponible")

                .DCTEClaveFiscal = IIf(dt.Rows(0)("DCTEClave").GetType.Name = "DBNull", "", dt.Rows(0)("DCTEClave"))

                .DescuentoDirecto = IIf(dt.Rows(0)("DescuentoDirecto").GetType.Name = "DBNull", -1, dt.Rows(0)("DescuentoDirecto"))
                .DescuentoPostVenta = IIf(dt.Rows(0)("DescuentoPostVenta").GetType.Name = "DBNull", -1, dt.Rows(0)("DescuentoPostVenta"))
                .Vendedor = IIf(dt.Rows(0)("Vendedor").GetType.Name = "DBNull", "", dt.Rows(0)("Vendedor"))
                .ClienteSAP = IIf(dt.Rows(0)("ClienteSAP").GetType.Name = "DBNull", "", dt.Rows(0)("ClienteSAP"))
                .UsoCFDI = IIf(dt.Rows(0)("UsoCFDI").GetType.Name = "DBNull", "G03", dt.Rows(0)("UsoCFDI"))
                .AccesoWeb = IIf(dt.Rows(0)("AccesoWeb").GetType.Name = "DBNull", False, dt.Rows(0)("AccesoWeb"))
                .CtaMaestra = IIf(dt.Rows(0)("CtaMaestra").GetType.Name = "DBNull", dt.Rows(0)("CTEClave"), dt.Rows(0)("CtaMaestra"))
                dt.Dispose()

            End With
        End If

        ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Cliente.Show()
        ModPOS.Cliente.BringToFront()

    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        If Not gridClientes.GetValue(0) Is Nothing Then
            modificarCte(gridClientes.GetValue(0))
        End If
    End Sub

    Private Sub gridClientes_DoubleClick(sender As Object, e As EventArgs) Handles gridClientes.DoubleClick
        If Not gridClientes.GetValue(0) Is Nothing Then
            modificarCte(gridClientes.GetValue(0))
        End If
    End Sub

    Private Sub btnVerificador_Click(sender As Object, e As EventArgs) Handles btnVerificador.Click
        Dim a As New FrmConsultaPrecio
        a.SUCClave = SUCClave
        a.ClienteActual = Mostrador
        a.Almacen = Me.ALMClave
        a.Width = Screen.PrimaryScreen.Bounds.Width
        a.Height = Screen.PrimaryScreen.Bounds.Height
        a.StartPosition = FormStartPosition.CenterScreen
        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

        End If
        a.Dispose()
    End Sub

    Private Sub BtnNota_Click(sender As Object, e As EventArgs) Handles BtnNota.Click
        Dim foundRows() As DataRow

        foundRows = dtCxC.Select("Marca ='True' and TipoDocumento = 1")

        If foundRows.GetLength(0) = 1 Then
            Dim i As Integer
            Dim sNota As String
            sNota = IIf(foundRows(0)("Nota").GetType.Name = "DBNull", "", foundRows(0)("Nota"))

            If sNota.Length > 0 Then
                i = Split(sNota, vbCrLf).Length
            Else
                i = 0
            End If

            Dim a As New FrmObservaciones
            a.Nota = sNota
            a.lineas = i
            If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                foundRows(0)("Nota") = a.Nota
                ModPOS.Ejecuta("st_agrega_nota", "@VENClave", foundRows(0)("ID"), "@Nota", a.Nota)
            End If
            a.Dispose()

        Else
            MessageBox.Show("Debe seleccionar unicamente un registro")
        End If
    End Sub

    Private Sub gridComplementoPago_Click(sender As Object, e As EventArgs) Handles gridComplementoPago.Click
        If Not gridComplementoPago.CurrentColumn Is Nothing Then
            If gridComplementoPago.CurrentColumn.Caption <> "Marca" And Not gridComplementoPago.GetValue("Marca") Is Nothing Then
                If gridComplementoPago.GetValue("Marca") = False Then
                    gridComplementoPago.SetValue("Marca", True)
                Else
                    gridComplementoPago.SetValue("Marca", False)
                End If
                dtComplementoPago.AcceptChanges()
                gridComplementoPago.Refresh()

            End If
        End If
    End Sub

    Private Sub gridComplementoPago_CurrentCellChanged(sender As Object, e As EventArgs) Handles gridComplementoPago.CurrentCellChanged
        If Not gridComplementoPago.CurrentColumn Is Nothing Then
            If gridComplementoPago.CurrentColumn.Caption = "Marca" Then
                gridComplementoPago.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                gridComplementoPago.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub chkCompTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkCompTodos.CheckedChanged
        If dtComplementoPago.Rows.Count > 0 Then
            Dim i As Integer
            If chkCompTodos.Checked Then
                For i = 0 To gridComplementoPago.GetDataRows.Length - 1
                    gridComplementoPago.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To gridComplementoPago.GetDataRows.Length - 1
                    gridComplementoPago.GetDataRows(i).DataRow("Marca") = False
                Next
            End If
            dtComplementoPago.AcceptChanges()
        End If
    End Sub

    Private Sub cmbCompInicial_ValueChanged(sender As Object, e As EventArgs) Handles cmbCompInicial.ValueChanged
        actualizaComplementoPago()
    End Sub

    Private Sub cmbCompFinal_ValueChanged(sender As Object, e As EventArgs) Handles cmbCompFinal.ValueChanged
        actualizaComplementoPago()
    End Sub

    Private Sub btnCertificaPago_Click(sender As Object, e As EventArgs) Handles btnCertificaPago.Click
        Dim foundRows() As DataRow
        foundRows = dtComplementoPago.Select("Marca ='True' and UUID = 'Pendiente' ")
        If foundRows.GetLength(0) > 0 Then
            Dim i As Integer

            Dim oCFD As New CFD


            Dim dt As DataTable

            dt = ModPOS.Recupera_Tabla("sp_recupera_certificadovigente", "@COMClave", ModPOS.CompanyActual)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                oCFD.noCertificado = dt.Rows(0)("Serie")
                oCFD.Certificado64 = dt.Rows(0)("Certificado")
                oCFD.LlaveFile = dt.Rows(0)("Llave")
                oCFD.ContrasenaClave = dt.Rows(0)("Password")
                dt.Dispose()
            Else
                MessageBox.Show("No existen certificado vigente disponible para emitir algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Verifica que exista el path
            Try
                If Not System.IO.Directory.Exists(PathXML) Then
                    MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
            End Try

            'Verifica que exista el path del .Key
            Try
                If Not System.IO.File.Exists(oCFD.LlaveFile) Then
                    MessageBox.Show("El archivo " & oCFD.LlaveFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
            End Try


            oCFD.VersionCF = VersionCF
            oCFD.TipoCF = 2
            oCFD.regimenFiscal = regimenFiscal

            'Recupera información del Emisor

            dt = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)
            oCFD.eRazonSocial = dt.Rows(0)("Nombre")
            oCFD.eRFC = dt.Rows(0)("id_Fiscal")
            dt.Dispose()





            Dim bImprimir As Boolean = False
            Dim sImpresora As String = ""
            Dim iCopias As Integer

            If MessageBox.Show("¿Desea Imprimir el Documento?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                If PrintDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    bImprimir = True
                    sImpresora = PrintDialog1.PrinterSettings.PrinterName
                    iCopias = PrintDialog1.PrinterSettings.Copies
                Else
                    bImprimir = False
                End If
            End If

            For i = 0 To foundRows.GetUpperBound(0)

                If foundRows(i)("Tipo") = "Aplicación" Then
                    Dim sDOCClave As String = ""
                    Dim iTipoDocumento As Integer
                    Dim dtf As DataTable = Recupera_Tabla("st_obtiene_apl_anticipo", "@DOCClave", foundRows(i)("ABNClave"))
                    If dtf.Rows.Count > 0 Then
                        sDOCClave = dtf.Rows(0)("DOCClave")
                        iTipoDocumento = IIf(dtf.Rows(0)("TipoDocumento").GetType.Name = "DBNull", 2, dtf.Rows(0)("TipoDocumento"))
                    End If
                    dtf.Dispose()

                    TimbraEgreso(foundRows(i)("ABNClave"), sDOCClave, iTipoDocumento, PathXML, oCFD.VersionCF, dtPAC, oCFD.regimenFiscal, InterfazSalida, True, bImprimir, sImpresora, iCopias)

                Else
                    dt = ModPOS.Recupera_Tabla("st_encabezado_abono", "@ABNClave", foundRows(i)("ABNClave"))

                    Dim iTipoPAC As Integer
                    Dim sTipoComprobante As String

                    If dt.Rows.Count = 1 Then

                        oCFD.DOCClave = dt.Rows(0)("ABNClave")
                        oCFD.Folio = dt.Rows(0)("Clave")

                        sTipoComprobante = "I"


                        Dim dFecha, dFechaPago As DateTime

                        If DateDiff(DateInterval.Hour, CDate(dt.Rows(0)("MFechaHora")), DateTime.Now) >= 72 Then
                            dFecha = DateTime.Now

                        Else
                            dFecha = dt.Rows(0)("MFechaHora")
                        End If

                        dFechaPago = dt.Rows(0)("fechaPago")


                        oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", dFecha)
                        oCFD.FechaPago = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", dFechaPago)


                        ModPOS.Ejecuta("st_act_abn_fechasat", "@ABNClave", dt.Rows(0)("ABNClave"), "@Fecha", dFecha)


                        oCFD.sCodigoPostal = dt.Rows(0)("sCodigoPostal")
                        oCFD.RFC = dt.Rows(0)("rRFC")
                        oCFD.RazonSocial = dt.Rows(0)("rRazonSocial")
                        oCFD.Nacionalidad = dt.Rows(0)("Origen")
                        oCFD.NumRegIdTrib = dt.Rows(0)("NumRegIdTrib")
                        oCFD.metodoDePago = dt.Rows(0)("MetodoDePago")
                        oCFD.Moneda = dt.Rows(0)("Moneda")
                        oCFD.TipoCambio = dt.Rows(0)("TipoCambio")

                        oCFD.total = dt.Rows(0)("Importe")



                        oCFD.cadenaOriginal = generarCadenaOriginalPago(oCFD, dt.Rows(0)("Tipo"), sTipoComprobante)


                        oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, "", oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)


                        iTipoPAC = crearXMLPago(1, dtPAC, PathXML, oCFD.Folio, oCFD.DOCClave, dt.Rows(0)("Tipo"), sTipoComprobante, "", oCFD, InterfazSalida)


                        If bImprimir = True Then

                            imprimirCfdiPago(oCFD.DOCClave, CStr(dt.Rows(0)("Tipo")), iCopias, sImpresora)

                        End If

                    End If






                End If
                dt.Dispose()


            Next

            actualizaComplementoPago()

        Else
            MessageBox.Show("¡No se ha seleccionado un Documento Pendiente de Certificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnPrintCompl_Click(sender As Object, e As EventArgs) Handles btnPrintCompl.Click
        Dim sImpresora As String = ""
        Dim iCopias As Integer

        If PrintDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            sImpresora = PrintDialog1.PrinterSettings.PrinterName
            iCopias = PrintDialog1.PrinterSettings.Copies
        Else
            Exit Sub
        End If

        Dim foundRows() As DataRow
        foundRows = dtComplementoPago.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then
            Dim i As Integer
            'Imprime CFDI
            For i = 0 To foundRows.GetUpperBound(0)



                imprimirCfdiPago(foundRows(i)("ABNClave"), foundRows(i)("Tipo"), iCopias, sImpresora)
                foundRows(i)("Marca") = False
            Next
            chkCompTodos.Checked = False
        Else
            MessageBox.Show("¡No se ha seleccionado un registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub btnSendCompl_Click(sender As Object, e As EventArgs) Handles btnSendCompl.Click
        Dim foundRows() As DataRow


        foundRows = dtComplementoPago.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then

            If MailAdress = "" OrElse MailUser = "" OrElse MailPassword = "" OrElse HostSMTP = "" OrElse MailPort = 0 Then
                MessageBox.Show("No se ha configurado una cuenta de correo para envio de información en el Menú de Configuración\Compañia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            Try
                If Not System.IO.Directory.Exists(PathXML) Then
                    MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
            End Try

            Dim PathPDF, sPathXML As String
            Dim i, j As Integer
            Dim frmStatusMessage As New frmStatus

            Dim MonRef, MonDesc As String
            Dim TipoCambio, total As Double
            Dim dt As DataTable
            Dim eMailCte As String = ""
            Dim sMailCliente As String = ""
            Dim sClienteActual As String = ""

            For i = 0 To foundRows.GetUpperBound(0)

                If sClienteActual <> foundRows(i)("Clave") Then
                    eMailCte = foundRows(i)("email").ToString.Trim
                    sClienteActual = foundRows(i)("Clave")
                End If

                If eMailCte = "" OrElse eMailCte <> sMailCliente Then
                    Dim m As New FrmCorreo
                    m.eMail = eMailCte
                    m.Folio = " Folio: " & foundRows(i)("Folio") & " Cliente: " & foundRows(i)("Clave")
                    If m.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        eMailCte = m.Correo
                    Else
                        eMailCte = "Salir"
                    End If
                    m.Dispose()
                End If

                If eMailCte <> "" Then
                    If eMailCte <> "Salir" Then
                        PathPDF = pathActual & "Temp\" & foundRows(i)("Folio") & ".PDF"

                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", IIf(foundRows(i)("Tipo") = "Aplicación", "A", "P"), "@Documento", foundRows(i)("ABNClave"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        total = dt.Rows(0)("Importe")
                        dt.Dispose()

                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "pvtaDataSet"

                        If foundRows(i)("Tipo") <> "Aplicación" Then
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_abono", "@ABNClave", foundRows(i)("ABNClave")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_sello_pago", "@ABNClave", foundRows(i)("ABNClave")))
                        End If


                        If foundRows(i)("Tipo") = "Anticipo" Then
                            'Anticipo
                            Dim Base As Decimal = Math.Round(total / 1.16, 2)
                            Dim IVA As Decimal = Math.Round(Base * 0.16, 2)

                            OpenReport.PrintPDF("CRAnticipoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal((Base + IVA), 2), MonDesc, MonRef).ToUpper, PathPDF)

                        ElseIf foundRows(i)("Tipo") = "Pago" Then

                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_recupera_relacionado", "@DOCClave", foundRows(i)("ABNClave"), "@Tipo", "P"))
                            OpenReport.PrintPDF("CRPagoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(total, 2), MonDesc, MonRef).ToUpper, PathPDF)
                        Else




                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_aplicacion", "@ANTClave", foundRows(i)("ABNClave")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_sello_anticipo", "@ANTClave", foundRows(i)("ABNClave")))

                            Dim Base As Decimal = Math.Round(total / 1.16, 2)
                            Dim IVA As Decimal = Math.Round(Base * 0.16, 2)
                            OpenReport.PrintPDF("CRAplicacionCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal((Base + IVA), 2), MonDesc, MonRef).ToUpper, PathPDF)

                        End If

                        Dim sFolio As String

                        sFolio = foundRows(i)("Folio").ToString

                        If foundRows(i)("Tipo") = "Aplicación" Then
                            sFolio &= "_A"
                        End If


                        sPathXML = PathXML
                        If sPathXML.Length > 3 AndAlso sPathXML.Substring(sPathXML.Length - 1, 1) <> "\" Then
                            sPathXML &= "\"
                        End If

                        sPathXML &= CDate(foundRows(i)("FechaSAT")).Year.ToString & "\" & CDate(foundRows(i)("FechaSAT")).Month.ToString & "\" & CDate(foundRows(i)("FechaSAT")).Day.ToString & "\" & sFolio & ".xml"





                        If Not System.IO.File.Exists(PathPDF) Then
                            MessageBox.Show("Ha ocurrido un error al generar el archivo: " & PathPDF, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ElseIf Not System.IO.File.Exists(sPathXML) Then
                            MessageBox.Show("Ha ocurrido un error, No se ha encontrado el archivo: " & sPathXML, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            Try
                                correo = New MailMessage
                                autenticar = New NetworkCredential
                                envio = New SmtpClient
                                If foundRows(i)("Tipo") = "Anticipo" Then
                                    correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Anticipo (*.PDF) y el Comprobante Fiscal Digital (*.XML), Agradecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
                                    correo.Subject = "Anticipo " & CStr(foundRows(i)("Folio"))

                                Else
                                    correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Complemento de Pago (*.PDF) y el Comprobante Fiscal Digital (*.XML), Agradecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
                                    correo.Subject = "Pago " & CStr(foundRows(i)("Folio"))

                                End If


                                correo.IsBodyHtml = True
                                correo.To.Clear()
                                correo.CC.Clear()
                                correo.Bcc.Clear()

                                sMailCliente = eMailCte

                                If sMailCliente.Split(",").Length >= 1 Then

                                    For j = 0 To sMailCliente.Split(",").Length - 1
                                        If sMailCliente.Split(",")(j) <> "" Then
                                            correo.To.Add(sMailCliente.Split(",")(j))
                                        End If
                                    Next
                                Else
                                    correo.To.Add(sMailCliente)
                                End If


                                correo.From = New MailAddress(MailAdress, DisplayName)
                                envio.Credentials = New NetworkCredential(MailUser, MailPassword)
                                envio.Host = HostSMTP  '"smtp.live.com"
                                envio.Port = MailPort  '587
                                envio.EnableSsl = MailSSL 'True

                                frmStatusMessage.Show("Enviando correo electrónico...")


                                dato = New FileStream(sPathXML, FileMode.Open, FileAccess.Read)
                                adjuntos = New Attachment(dato, CStr(foundRows(i)("Folio")) & ".XML")
                                correo.Attachments.Add(adjuntos)


                                dato = New FileStream(PathPDF, FileMode.Open, FileAccess.Read)
                                adjuntos = New Attachment(dato, CStr(foundRows(i)("Folio")) & ".PDF")
                                correo.Attachments.Add(adjuntos)

                                envio.Send(correo)
                                correo.Dispose()

                                MessageBox.Show("El mensaje fue enviado correctamente a el destinatario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try

                            If Not dato Is Nothing Then
                                dato.Close()
                            End If

                            Try
                                My.Computer.FileSystem.DeleteFile(PathPDF, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                            Catch ex As Exception
                                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                            End Try
                        End If
                    End If
                    foundRows(i)("Marca") = False
                Else
                    MessageBox.Show("El cliente " & foundRows(i)("Clave").ToString & ", no cuenta con dirección de correo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Next
            frmStatusMessage.Dispose()
            chkCompTodos.Checked = False

        Else
            MessageBox.Show("Para reenviar, debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnActCxC_Click(sender As Object, e As EventArgs) Handles btnActCxC.Click
        ModPOS.Ejecuta("st_act_saldo_ctes", Nothing)
        actualizaGridCreditos()
        Me.cobranzaGeneral = False

    End Sub

    Private Sub ItemTarjetaAmiga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemTarjetaAmiga.Click
        Dim a As New FrmTarjetaAmiga
        a.IDCorte = Me.IDCorte
        a.CAJClave = CAJClave
        a.impresora = Impresora

        If ClaveCaja.Length >= 3 Then
            a.sIdTerminal = SucursalClave + ClaveCaja.Substring(ClaveCaja.Length - 3, 3)
        Else
            a.sIdTerminal = SucursalClave + ClaveCaja
        End If

        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

        End If
        a.Dispose()
    End Sub


    Private Sub btnServicios_Click(sender As Object, e As EventArgs) Handles btnServicios.Click
        btnServicios.ContextMenuStrip.Show(btnServicios, New Point(0, btnServicios.Height), ToolStripDropDownDirection.BelowRight)
    End Sub

    Private Sub btnActApartados_Click(sender As Object, e As EventArgs) Handles btnActApartados.Click
        actualizaGridApartados()
        Me.cobranzaGeneral = False
    End Sub

    Private Sub btnApartados_Click_1(sender As Object, e As EventArgs) Handles btnApartados.Click
        If Not gridApartados.GetValue(0) Is Nothing Then
            Dim a As New FrmApartado
            a.ticketPicking = ticketPicking
            a.TIKClave = TIKClave
            a.Cliente = gridApartados.GetValue("Clave")
            a.CAJClave = CAJClave
            a.SUCClave = SUCClave
            a.ALMClave = ALMClave
            a.AtiendeNombre = LblUsuario.Text
            a.Impresora = Impresora
            a.PrintGeneric = PrintGeneric
            a.Recibo = Recibo
            a.Cajon = Cajon
            a.Picking = Picking
            a.Packing = Packing
            If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            End If
        Else
            MessageBox.Show("Debe seleccionar un clinete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub gridApartados_CurrentCellChanging(sender As Object, e As Janus.Windows.GridEX.CurrentCellChangingEventArgs) Handles gridApartados.CurrentCellChanging
        gridApartados.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
    End Sub

    Private Sub gridApartados_KeyDown(sender As Object, e As KeyEventArgs) Handles gridApartados.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnApartados.PerformClick()
        End If
    End Sub



    Private Sub btnCancelarAbono_Click(sender As Object, e As EventArgs) Handles btnCancelarAbono.Click
        If Not gridAbonos.GetValue(0) Is Nothing Then

            Dim Tipo, Estado As Integer
            Dim Importe, Saldo, TipoCambio As Decimal
            Dim SUCClave, Clave As String


            If CmbFecha.Value <> Today Then
                MessageBox.Show("El Abono seleccionado no se puede cancelar debido a que no corresponde a la fecha actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim Duracion As Integer
            Dim MetodoPago As String

            Dim dt As DataTable
            If gridAbonos.GetValue(1) = "99" Then
                dt = ModPOS.Recupera_Tabla("st_detalle_pago", "@ABNClave", gridAbonos.GetValue("idPago"), "@MetodoPago", gridAbonos.GetValue(1))

                Dim foundRows() As DataRow = dt.Select("SaldoRemanente <> SaldoActual")

                If foundRows.GetLength(0) > 0 Then
                    MessageBox.Show("El Abono seleccionado No puede ser cancelado debido a que No es el ultimo numero de pago aplicado a los documentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                dt = ModPOS.Recupera_Tabla("st_encabezado_vale", "@NCClave", gridAbonos.GetValue(0))
                Importe = gridAbonos.GetValue(10)
                Saldo = dt.Rows(0)("Saldo")
                SUCClave = dt.Rows(0)("SUCClave")
                TipoCambio = dt.Rows(0)("TipoCambio")
                dt.Dispose()

                Select Case MessageBox.Show("¿Esta seguro de Cancelar la aplicacion del vale " & gridAbonos.GetValue(3) & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        Dim a As New MeAutorizacion

                        a.Sucursal = SUCClave
                        a.MontodeAutorizacion = Importe * TipoCambio
                        a.StartPosition = FormStartPosition.CenterScreen
                        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                            If a.Autorizado Then

                                If TallaColor AndAlso InterfazSalida <> "" Then
                                    Dim sFecha As String
                                    Dim dtInterfaz As DataTable
                                    sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                                    dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CancelacionAnticipo", "@COMClave", ModPOS.CompanyActual)
                                    If dtInterfaz.Rows.Count > 0 Then
                                        ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", gridAbonos.GetValue(0), "@TipoDocumento", -1, "@Path", InterfazSalida, "@Fecha", sFecha)
                                    End If
                                    sFecha = DateTime.Now.AddSeconds(1).ToString("yyyyMMdd_HHmmssfff")
                                    dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CancelacionPedido", "@COMClave", ModPOS.CompanyActual)
                                    If dtInterfaz.Rows.Count > 0 Then
                                        ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", gridAbonos.GetValue(0), "@TipoDocumento", -1, "@Path", InterfazSalida, "@Fecha", sFecha)
                                    End If

                                End If

                                Dim mensaje As String = ModPOS.Ejecuta("st_cancela_AplicacionVale", "@idNC", gridAbonos.GetValue(18), "@Autoriza", a.Autoriza)
                                If mensaje <> "OK" Then
                                    MessageBox.Show(mensaje, "Cancelar abono", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If

                                If reciboTicket = 0 AndAlso TallaColor = 1 Then
                                    ImprimeVale(gridAbonos.GetValue("ID"), Impresora, Recibo, True, -1, True, PrintGeneric)
                                    'imprimirRecibo(gridAbonos.GetValue("ID"), FormatoRecibo, True, Impresora, 0, "CANCELADO", copias)
                                End If

                                If Tipo = 2 Then

                                    If InterfazSalida <> "" Then
                                        Dim sFecha As String
                                        Dim dtInterfaz As DataTable
                                        sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                                        dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CancelacionAnticipo", "@COMClave", ModPOS.CompanyActual)
                                        If dtInterfaz.Rows.Count > 0 Then
                                            ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", gridAbonos.GetValue(0), "@TipoDocumento", -1, "@Path", InterfazSalida, "@Fecha", sFecha)
                                        End If

                                    End If

                                End If

                                ActualizaGridAbonos()

                            End If
                        End If

                End Select

            Else
                dt = ModPOS.Recupera_Tabla("st_encabezado_abono", "@ABNClave", gridAbonos.GetValue(0))
                Tipo = dt.Rows(0)("Tipo")
                Importe = dt.Rows(0)("Importe")
                Saldo = dt.Rows(0)("Saldo")
                SUCClave = dt.Rows(0)("SUCClave")
                Clave = dt.Rows(0)("Clave")
                TipoCambio = dt.Rows(0)("TipoCambio")
                Duracion = dt.Rows(0)("Duracion")
                MetodoPago = dt.Rows(0)("MetodoDePago")
                dt.Dispose()


                'If TallaColor = 1 AndAlso Duracion > 30 Then
                '    MessageBox.Show("El Abono seleccionado no se puede cancelar debido a que han transcurrido más de 30 minutos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Exit Sub
                'End If

                If Tipo = 1 Then
                    dt = ModPOS.Recupera_Tabla("st_sello_pago", "@ABNClave", gridAbonos.GetValue(0))
                Else
                    dt = ModPOS.Recupera_Tabla("st_sello_anticipo", "@ANTClave", gridAbonos.GetValue(0))
                End If

                If dt.Rows.Count = 0 Then
                    Estado = 2
                Else
                    Estado = dt.Rows(0)("estado")
                End If
                dt.Dispose()

                If Estado = 1 Then
                    MessageBox.Show("El Abono seleccionado no se puede cancelar debido a que se encuentra Certificado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If Saldo <> Importe Then

                    dt = ModPOS.Recupera_Tabla("st_detalle_pago", "@ABNClave", gridAbonos.GetValue(0))

                    Dim foundRows() As DataRow = dt.Select("SaldoRemanente <> SaldoActual")

                    If foundRows.GetLength(0) > 0 Then
                        MessageBox.Show("El Abono seleccionado No puede ser cancelado debido a que No es el ultimo numero de pago aplicado a los documentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If


                Select Case MessageBox.Show("¿Esta seguro de Cancelar el documento " & Clave & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        Dim a As New MeAutorizacion

                        a.Sucursal = SUCClave
                        a.MontodeAutorizacion = Importe * TipoCambio
                        a.StartPosition = FormStartPosition.CenterScreen
                        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                            If a.Autorizado Then
                                Dim copias As Integer = 1
                                If MetodoPago = "04" OrElse MetodoPago = "28" OrElse MetodoPago = "29" Then
                                    copias = 2
                                    If cancelarPinPad(gridAbonos.GetValue(0), MetodoPago, Importe) = False Then
                                        If MetodoPago <> "29" Then
                                            MessageBox.Show("Este pago no se puede ya que fue realizado por medio de una PinPad", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End If
                                        Exit Sub
                                    End If
                                End If

                                If reciboTicket = 0 AndAlso TallaColor = 1 Then
                                    imprimirRecibo(gridAbonos.GetValue("ID"), FormatoRecibo, True, Impresora, 0, "CANCELADO", copias)
                                End If

                                If TallaColor AndAlso InterfazSalida <> "" AndAlso Tipo = 1 Then
                                    Dim sFecha As String
                                    Dim dtInterfaz As DataTable
                                    sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                                    dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CancelacionAnticipo", "@COMClave", ModPOS.CompanyActual)
                                    If dtInterfaz.Rows.Count > 0 Then
                                        ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", gridAbonos.GetValue(0), "@TipoDocumento", -1, "@Path", InterfazSalida, "@Fecha", sFecha)
                                    End If
                                    sFecha = DateTime.Now.AddSeconds(1).ToString("yyyyMMdd_HHmmssfff")
                                    dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CancelacionPedido", "@COMClave", ModPOS.CompanyActual)
                                    If dtInterfaz.Rows.Count > 0 Then
                                        ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", gridAbonos.GetValue(0), "@TipoDocumento", -1, "@Path", InterfazSalida, "@Fecha", sFecha)
                                    End If

                                End If

                                Dim mensaje As String = ModPOS.Ejecuta("st_cancela_abono", "@ABNClave", gridAbonos.GetValue(0), "@Autoriza", a.Autoriza)
                                If mensaje <> "OK" Then
                                    MessageBox.Show(mensaje, "Cancelar abono", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                                If Tipo = 2 Then

                                    If InterfazSalida <> "" Then
                                        Dim sFecha As String
                                        Dim dtInterfaz As DataTable
                                        sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                                        dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CancelacionAnticipo", "@COMClave", ModPOS.CompanyActual)
                                        If dtInterfaz.Rows.Count > 0 Then
                                            ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", gridAbonos.GetValue(0), "@TipoDocumento", -1, "@Path", InterfazSalida, "@Fecha", sFecha)
                                        End If

                                    End If

                                End If

                                ActualizaGridAbonos()

                            End If
                        End If

                End Select

            End If

        End If
    End Sub

    Private Sub btnAbono_Click(sender As Object, e As EventArgs) Handles btnAbono.Click
        If Not gridAbonos.GetValue(0) Is Nothing Then
            Dim a As New FrmEditAbono
            a.ABNClave = gridAbonos.GetValue(0)

            If ClaveCaja.Length >= 3 Then
                a.sIdTerminal = SucursalClave + ClaveCaja.Substring(ClaveCaja.Length - 3, 3)
            Else
                a.sIdTerminal = SucursalClave + ClaveCaja
            End If

            If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            End If
            a.Dispose()
        End If
    End Sub

    Private Sub CmbFecha_ValueChanged(sender As Object, e As EventArgs) Handles CmbFecha.ValueChanged
        If bload Then
            ActualizaGridAbonos()
        End If
    End Sub

    Private Sub CmbFiltro_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbFiltro.SelectedValueChanged
        If bload AndAlso Not CmbFiltro.SelectedValue Is Nothing Then
            ActualizaGridAbonos()
        End If
    End Sub

    Private Sub TxtBusqueda_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtBusqueda.KeyUp
        If TxtBusqueda.Text <> "" Then
            ActualizaGridAbonos()
        End If
    End Sub

    Private Sub gridAbonos_CurrentCellChanged(sender As Object, e As EventArgs) Handles gridAbonos.CurrentCellChanged
        gridAbonos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False

    End Sub

    Private Sub gridAbonos_SelectionChanged(sender As Object, e As EventArgs) Handles gridAbonos.SelectionChanged
        If Not gridAbonos.GetValue(0) Is Nothing Then
            If Not gridAbonos.GetValue("Metodo").GetType.ToString = "System.DBNull" Then
                Select Case CInt(gridAbonos.GetValue("TipoPago"))
                    Case 2, 3, 4, 5, 6, 8
                        btnAbono.Visible = True
                    Case Else
                        btnAbono.Visible = False

                End Select
            Else
                btnAbono.Visible = False
            End If
        End If
    End Sub


    Private Sub btnAnticipo_Click_1(sender As Object, e As EventArgs) Handles btnAnticipo.Click
        Dim a As New FrmAbono
        a.SUCClave = SUCClave
        a.bAnticipo = True
        a.Aplicacion = Aplicacion
        a.CAJA = CAJClave
        a.ClaveCaja = ClaveCaja
        a.SaldoAcumulado = 0
        a.AperturaCajon = Cajon
        a.ImpresoraCajon = Impresora
        a.InterfazSalida = InterfazSalida
        a.ConfirmarAbono = ConfirmarAbono
        If ClaveCaja.Length >= 3 Then
            a.sIdTerminal = SucursalClave + ClaveCaja.Substring(ClaveCaja.Length - 3, 3)
        Else
            a.sIdTerminal = SucursalClave + ClaveCaja
        End If

        If ClaveCaja.Length >= 4 Then
            a.PinPadNumero = SucursalClave.PadLeft(4, "0"c) + ClaveCaja.Substring(ClaveCaja.Length - 4, 4).PadLeft(4, "0"c)
        Else
            a.PinPadNumero = SucursalClave.PadLeft(4, "0"c) + ClaveCaja.PadLeft(4, "0"c)
        End If



        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            ActualizaGridAbonos()
            RetiroProgramado()
        End If
    End Sub



    Private Sub btnConsultaAbn_Click(sender As Object, e As EventArgs) Handles btnConsultaAbn.Click

        Dim foundRows() As DataRow
        foundRows = dtComplementoPago.Select("Marca ='True'")
        If foundRows.GetLength(0) = 1 Then
            Dim i As Integer
            'Imprime CFDI
            For i = 0 To foundRows.GetUpperBound(0)
                previewCfdiPago(foundRows(i)("ABNClave"), foundRows(i)("Tipo"))
                foundRows(i)("Marca") = False
            Next
            chkCompTodos.Checked = False
        Else
            MessageBox.Show("¡Debe seleccionar un registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnPedido_Click(sender As Object, e As EventArgs) Handles btnPedido.Click
        Dim foundRows() As DataRow
        foundRows = dtCxC.Select("Marca ='True' and ( TipoDocumento = 1 or TipoDocumento = 3 )")
        If foundRows.GetLength(0) = 1 Then


            If foundRows(0)("TipoDocumento") = 1 OrElse foundRows(0)("TipoDocumento") = 3 Then
                If foundRows(0)("Total") <> foundRows(0)("Saldo") Then
                    MessageBox.Show("EL documento con Folio " & foundRows(0)("Folio") & " no es posible editarlo porque tiene pagos o devoluciones aplicadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            Dim a As New FrmPedido
            a.FormatoPedido = Me.FormatoPedido
            a.sImpresora = Impresora
            a.VENClave = foundRows(0)("ID")
            a.CAJClave = CAJClave
            a.Generic = PrintGeneric
            If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                AgregarFolio()
            End If

        End If
    End Sub

    Public Function cancelarPinPad(ByVal abnClave As String, Optional ByVal tipoPago As String = "", Optional ByVal monto As Decimal = 0) As Boolean

        Dim valido As Boolean = True
        Dim pagoTarjetaAmiga As Boolean = False
        Dim dt As DataTable = ModPOS.Recupera_Tabla("st_detalle_pagoPinPad", "@ABNClave", abnClave)
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                If tipoPago = "04" Or tipoPago = "28" Then
                    If dt.Rows(0)("numAutorizacion").ToString().Length > 1 And dt.Rows(0)("referenciaFinanciera").ToString().Length > 1 Then
                        'Dim min As Long = DateDiff(DateInterval.Minute, dt.Rows(0)("fechaPago"), DateTime.Now)
                        'If min > 30 Then
                        '    valido = False
                        '    MessageBox.Show("El pago no se puede cancelar despues de media hora", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        '    Exit Function
                        'End If

                        Dim a As New FrmEditAbono
                        a.ABNClave = gridAbonos.GetValue(0)
                        a.cancelarPago = True
                        a.dtDatosPinPad = dt
                        a.pagoTarjetaAmiga = pagoTarjetaAmiga
                        a.monto = monto
                        If ClaveCaja.Length >= 3 Then
                            a.sIdTerminal = SucursalClave + ClaveCaja.Substring(ClaveCaja.Length - 3, 3)
                        Else
                            a.sIdTerminal = SucursalClave + ClaveCaja
                        End If

                        If ClaveCaja.Length >= 4 Then
                            a.PinPadNumero = SucursalClave.PadLeft(4, "0"c) + ClaveCaja.Substring(ClaveCaja.Length - 4, 4).PadLeft(4, "0"c)
                        Else
                            a.PinPadNumero = SucursalClave.PadLeft(4, "0"c) + ClaveCaja.PadLeft(4, "0"c)
                        End If

                        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                        End If
                        a.Dispose()
                        valido = a.pagoCancelado

                    End If
                ElseIf tipoPago = "29" Then
                    pagoTarjetaAmiga = True
                    If dt.Rows(0)("numAutorizacion").ToString().Length = 0 Then
                        valido = False
                        Exit Function
                    End If

                    Dim a As New FrmEditAbono
                    a.ABNClave = gridAbonos.GetValue(0)
                    a.cancelarPago = True
                    a.dtDatosPinPad = dt
                    a.pagoTarjetaAmiga = pagoTarjetaAmiga
                    a.monto = monto
                    If ClaveCaja.Length >= 3 Then
                        a.sIdTerminal = SucursalClave + ClaveCaja.Substring(ClaveCaja.Length - 3, 3)
                    Else
                        a.sIdTerminal = SucursalClave + ClaveCaja
                    End If

                    If ClaveCaja.Length >= 4 Then
                        a.PinPadNumero = SucursalClave.PadLeft(4, "0"c) + ClaveCaja.Substring(ClaveCaja.Length - 4, 4).PadLeft(4, "0"c)
                    Else
                        a.PinPadNumero = SucursalClave.PadLeft(4, "0"c) + ClaveCaja.PadLeft(4, "0"c)
                    End If

                    If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                    End If
                    a.Dispose()
                    valido = a.pagoCancelado

                Else
                    valido = True
                    Exit Function
                End If

            End If
            dt.Dispose()
        End If
        Return valido
    End Function


    Private Sub BtnOtroPago_Click(sender As Object, e As EventArgs) Handles BtnOtroPago.Click
        Dim idEvento As String = ""
        idEventoGlobal = ""
        If cobranzaGeneral Then
            If Not dtCxC Is Nothing Then

                Dim foundRows() As DataRow

                foundRows = dtCxC.Select("Marca ='True' and SaldoBase > 0")

                If foundRows.GetLength(0) > 0 Then

                    Dim fr() As DataRow
                    fr = dtCxC.Select("Marca ='True' AND SaldoBase > 0 and CTEClave <> '" & foundRows(0)("CTEClave") & "'")

                    If fr.GetLength(0) >= 1 Then
                        MessageBox.Show("No es posible realizar pagos de diferentes clientes a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        TxtFolio.Text = ""
                        TxtFolio.Focus()
                        Exit Sub
                    End If


                    If LimitarCobrosFactura = 1 Then
                        fr = dtCxC.Select("Marca ='True' and TipoDocumento = 1 and Tipo <> 'Contado'")

                        If fr.GetLength(0) >= 1 Then
                            MessageBox.Show("No es posible aplicar pagos o vales a ventas de crédito no facturadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            TxtFolio.Text = ""
                            TxtFolio.Focus()
                            Exit Sub
                        End If

                    End If


                    Dim dtDoctos, dtAbnSaldo As DataTable
                    dtDoctos = foundRows.CopyToDataTable()

                    dtAbnSaldo = Recupera_Tabla("sp_aplicar_abn", "@CTEClave", dtDoctos.Rows(0)("CTEClave"))
                    If dtAbnSaldo.Rows.Count > 0 Then

                        'Validar Promociones Pago
                        Dim i As Integer
                        Dim dtPromo As DataTable
                        For i = 0 To dtDoctos.Rows.Count - 1
                            If CInt(dtDoctos.Rows(i)("TipoDocumento")) = 1 Then
                                dtPromo = ModPOS.Recupera_Tabla("st_valida_pago_promo", "@VENClave", CStr(dtDoctos.Rows(i)("ID")))

                                If dtPromo.Rows.Count > 0 Then
                                    MessageBox.Show("El documento: " & CStr(dtDoctos.Rows(i)("Folio")) & ", tiene promociones que limitan esta forma de pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    TxtFolio.Text = ""
                                    TxtFolio.Focus()
                                    Exit Sub
                                End If
                            End If
                        Next

                        Dim foundRowsFac() As DataRow
                        foundRowsFac = dtDoctos.Select("TipoDocumento=2")
                        If foundRowsFac.GetLength(0) > 0 AndAlso Me.LimitarCobrosFactura = 1 Then
                            If ModPOS.ValidaCobroFactura(foundRowsFac.CopyToDataTable(), IDCorte) = False Then
                                Exit Sub
                            End If
                        End If


                        Dim b As New FrmAbnPendiente
                        b.Abonos = dtAbnSaldo
                        b.MonRef = RefMoneda
                        b.SaldoDocumento = SaldoBase
                        If b.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                            If Not b.drAbonos Is Nothing AndAlso b.drAbonos.Length > 0 Then
                                idEvento = ModPOS.obtenerLlave
                                idEventoGlobal = idEvento

                                Dim sFolio, sFecha As String
                                Dim dtInterfaz As DataTable = Nothing

                                If InterfazSalida <> "" AndAlso (dtDoctos.Rows(0)("TipoDocumento") = 2 OrElse dtDoctos.Rows(0)("TipoDocumento") = 6) Then
                                    dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "AplicacionNC", "@COMClave", ModPOS.CompanyActual)
                                End If

                                For i = 0 To b.drAbonos.Length - 1
                                    ModPOS.Aplica_Pagos(dtDoctos, foundRows(0)("CTEClave"), b.drAbonos(i)("ID"), b.drAbonos(i)("TipoPago"), b.drAbonos(i)("SaldoBase"), CAJClave, b.drAbonos(i)("Tipo"), b.drAbonos(i)("Fecha"), idEvento, TallaColor, reciboTicket, FormatoRecibo, Impresora)

                                    Try
                                        If b.drAbonos(i)("Vale") = 1 AndAlso TallaColor = 1 Then
                                            ImprimeVale(b.drAbonos(i)("ID"), Impresora, TICDevolucion, True, b.drAbonos(i)("Tipo"), True, PrintGeneric)
                                        End If

                                        If b.drAbonos(i)("Tipo") <> -1 AndAlso TallaColor = 1 Then
                                            imprimirRecibo(b.drAbonos(i)("ID"), FormatoRecibo, True, Impresora, 0, " ", 2)
                                        End If



                                    Catch ex As Exception
                                        MessageBox.Show(ex.Message)
                                    End Try


                                    Try
                                        If InterfazSalida <> "" AndAlso (dtDoctos.Rows(0)("TipoDocumento") = 1 OrElse dtDoctos.Rows(0)("TipoDocumento") = 2 OrElse dtDoctos.Rows(0)("TipoDocumento") = 6) Then
                                            sFolio = b.drAbonos(i)("ID")
                                            sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")
                                            If Not dtInterfaz Is Nothing AndAlso dtInterfaz.Rows.Count > 0 Then
                                                ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sFolio, "@TipoDocumento", b.drAbonos(i)("TipoPago"), "@Path", InterfazSalida, "@Fecha", sFecha, "@Tipo", CInt(dtDoctos.Rows(0)("TipoDocumento")))
                                            End If
                                        End If
                                    Catch ex As Exception
                                        MessageBox.Show(ex.Message)
                                    End Try


                                Next



                                Dim SaldoDoctos As Decimal = IIf(dtDoctos.Compute("Sum(SaldoBase)", "SaldoBase > 0") Is System.DBNull.Value, 0, dtDoctos.Compute("Sum(SaldoBase)", "SaldoBase > 0"))
                                If TallaColor = 1 AndAlso SaldoDoctos < 0.5 Then
                                    SaldoDoctos = 0
                                End If
                                interfazTallaColor = False
                                If CobranzaVenta = True AndAlso SaldoDoctos > 0 Then
                                    BtnPago.PerformClick()
                                ElseIf CobranzaVenta = True AndAlso SaldoDoctos = 0 Then
                                    fr = dtDoctos.Select("Marca ='True' and TipoDocumento = 1 and Tipo = 'Contado'")
                                    idEventoGlobal = ""
                                    If TallaColor = 1 Then
                                        Dim PrintTickets() As DataRow
                                        PrintTickets = dtDoctos.Select("TipoDocumento = 1 and Tipo = 'Contado' ")
                                        If PrintTickets.Length > 0 Then
                                            Dim k As Integer
                                            For k = 0 To PrintTickets.Length - 1
                                                Dim proximaCat As String = ""
                                                Dim dtProximaCat As DataTable = Recupera_Tabla("st_recupera_proximaCategoria", "@CTEClave", dtDoctos.Rows(0)("CTEClave"))
                                                If Not dtProximaCat Is Nothing Then
                                                    proximaCat = IIf(dtProximaCat.Rows(0)("Total") < 0, "0", dtProximaCat.Rows(0)("Total").ToString())
                                                End If
                                                previewPedido(FormatoPedido, PrintTickets(k)("ID"), PrintTickets(k)("Total"), SUCClave, Impresora, True, 1, False, False, "0", "0", PrintGeneric)

                                            Next
                                        End If
                                    End If

                                    If fr.GetLength(0) > 0 Then
                                        generarInterfazTC(dtDoctos, idEvento)
                                        If CBool(fr(0)("Facturable")) = True Then
                                            BtnFacturar.PerformClick()
                                        End If
                                    Else
                                        interfazTallaColor = True
                                    End If
                                End If
                                If interfazTallaColor Then
                                    generarInterfazTC(dtDoctos, idEvento)
                                End If
                                dtCxC.Dispose()
                                TxtFolio.Text = ""
                                TxtFolio.Focus()
                                AgregarFolio()


                            End If
                        End If

                    Else
                        MessageBox.Show("El Cliente No cuenta con documentos (Anticipos/Notas de Crédito/Vales/Bonificaciones) con saldo pendientes por aplicar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    dtAbnSaldo.Dispose()

                Else
                    MessageBox.Show("Debe marcar por lo menos un registro con Saldo mayor a Cero", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Else 'Tab de CXC
            PagoCreditos()
        End If

    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

    Private Sub generarInterfazTC(ByVal dtDoctos As DataTable, ByVal idEvento As String)
        Dim dtInterfaz As DataTable
        Dim sFecha As String
        If TallaColor AndAlso InterfazSalida <> "" Then
            If dtDoctos.Rows(0)("TipoDocumento") = 1 Then
                dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Pedidos", "@COMClave", ModPOS.CompanyActual)
                If Not dtInterfaz Is Nothing AndAlso dtInterfaz.Rows.Count > 0 Then
                    For i As Integer = 0 To dtDoctos.Rows.Count - 1
                        sFecha = DateTime.Now.AddSeconds(i).ToString("yyyyMMdd_HHmmssfff")
                        ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", dtDoctos.Rows(i)("ID"), "@TipoDocumento", dtDoctos.Rows(i)("TipoDocumento"), "@Path", InterfazSalida, "@Fecha", sFecha)
                    Next
                End If

            End If

            dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Cobros", "@COMClave", ModPOS.CompanyActual)

            If Not dtInterfaz Is Nothing AndAlso dtInterfaz.Rows.Count > 0 Then
                sFecha = DateTime.Now.AddSeconds(1).ToString("yyyyMMdd_HHmmssfff")
                ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", idEvento, "@TipoDocumento", "10", "@Path", InterfazSalida, "@Fecha", sFecha, "@Tipo", CInt(dtDoctos.Rows(0)("TipoDocumento")))
                idEvento = ""
            End If

        End If
    End Sub

    Private Sub btnConsultaNC_Click(sender As Object, e As EventArgs) Handles btnConsultaNC.Click
        If Not gridClientes.GetValue(0) Is Nothing Then
            Dim dtVales As DataTable
            dtVales = Recupera_Tabla("sp_aplicar_abn", "@CTEClave", gridClientes.GetValue(0))
            If dtVales.Rows.Count > 0 Then
                Dim b As New FrmVales
                b.Ticket = Recibo
                b.Impresora = Impresora
                b.Vales = dtVales
                b.MonRef = RefMoneda
                b.SaldoDocumento = SaldoBase
                b.Generic = PrintGeneric
                If b.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                End If
                b.Dispose()

            Else
                MessageBox.Show("El cliente no cuenta con Vales activos con saldo")
            End If

        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim a As New FrmPedido
        a.Padre = "Nuevo"
        a.FormatoPedido = Me.FormatoPedido
        a.sImpresora = Impresora
        a.CAJClave = CAJClave
        a.Generic = PrintGeneric
        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            AgregarFolio()
        End If
    End Sub

    Private Sub btnPreventa_Click(sender As Object, e As EventArgs) Handles btnPreventa.Click
        Dim a As New FrmEntregaPreventa
        a.CAJClave = CAJClave
        a.impresora = Impresora
        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub RecargaTelefonicaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecargaTelefonicaToolStripMenuItem.Click

        If idCajero = 0 Or idPOS = "" Or passCajero = "" Then
            MessageBox.Show("La información del cajero para el sistemas de recargas esta incompleta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim car As New FrmRecargaTelefonica
        car.CAJClave = CAJClave
        car.impresora = Impresora
        car.Padre = car.Operador
        car.ClienteMostrador = Mostrador
        car.ClaveCaja = ClaveCaja
        car.Moneda = Moneda
        car.TipoCambio = TipoCambio
        If car.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim dtCargo As DataTable = ModPOS.CrearTabla("Cargo", _
                                        "ID", "System.String", _
                                        "Piezas", "System.Int32", _
                                        "TipoDocumento", "System.Int32", _
                                        "Tipo", "System.String", _
                                        "DescuentoTot", "System.Decimal", _
                                        "SaldoBase", "System.Decimal", _
                                        "Fecha", "System.DateTime")
            Dim row1 As DataRow
            row1 = dtCargo.NewRow()
            row1.Item("ID") = car.CARClave
            row1.Item("Piezas") = 1
            row1.Item("TipoDocumento") = 3
            row1.Item("Tipo") = "Contado"
            row1.Item("DescuentoTot") = 0
            row1.Item("SaldoBase") = 0
            row1.Item("Fecha") = Today
            dtCargo.Rows.Add(row1)

            Dim a As New FrmAbono
            a.SUCClave = SUCClave
            a.dtDocumentos = dtCargo
            a.InterfazSalida = InterfazSalida
            a.Aplicacion = Aplicacion
            a.VariosPagos = False
            a.TipoDocumento = dtCargo.Rows(0)("TipoDocumento")
            a.CAJA = CAJClave
            a.ClaveCaja = ClaveCaja
            a.ClaveCte = car.ClienteMostrador
            a.ClaveDocumento = car.CARClave
            a.SaldoAcumulado = 0
            a.AperturaCajon = Cajon
            a.ImpresoraCajon = Impresora
            a.ConfirmarAbono = ConfirmarAbono
            a.ClaveDocumento = car.CARClave
            If ClaveCaja.Length >= 3 Then
                a.sIdTerminal = SucursalClave + ClaveCaja.Substring(ClaveCaja.Length - 3, 3)
            Else
                a.sIdTerminal = SucursalClave + ClaveCaja
            End If

            If ClaveCaja.Length >= 4 Then
                a.PinPadNumero = SucursalClave.PadLeft(4, "0"c) + ClaveCaja.Substring(ClaveCaja.Length - 4, 4).PadLeft(4, "0"c)
            Else
                a.PinPadNumero = SucursalClave.PadLeft(4, "0"c) + ClaveCaja.PadLeft(4, "0"c)
            End If

            If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                If a.detallePago.Rows.Count > 0 Then
                    Dim i As Integer
                    Dim sFolio, sFecha As String
                    Dim dtInterfaz As DataTable = Nothing
                    Dim idEvento As String = a.id_evento

                    For i = 0 To a.detallePago.Rows.Count - 1
                        ModPOS.Aplica_Pagos(dtCargo, car.ClienteMostrador, a.detallePago.Rows(i)("ABNClave"), a.detallePago.Rows(i)("TipoPago"), a.detallePago.Rows(i)("SaldoBase"), CAJClave, 1, a.detallePago.Rows(i)("FechaPago"), idEvento, TallaColor, reciboTicket, FormatoRecibo, Impresora)
                    Next

                    Dim tel As New MeTelefono
                    tel.idPOS = idPOS
                    tel.idCajero = idCajero
                    tel.idPOS = idPOS
                    tel.Producto = car.PROClave
                    If tel.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        If a.TotalAbono > 0 Then
                            'Imprimir ticket con datos del cargo
                            If ConfirmarAbono = 1 Then
                                Dim msg As New FrmMeMsg
                                msg.TxtTiulo = "Su Cambio es:"
                                msg.TxtMsg = RefMoneda & " " & Format(CStr(Math.Round(a.TotalCambio, 2)), "Currency")
                                msg.TxtMsg2 = Letras(CStr(Math.Round(a.TotalCambio, 2))).ToUpper & " " & RefMoneda

                                msg.StartPosition = FormStartPosition.CenterScreen
                                msg.BringToFront()
                                If msg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                End If
                                msg.Dispose()
                            End If
                        End If
                        previewTicketCargo(FormatoPedido, car.CARClave, a.TotalAbono, SUCClave, Impresora, True, 1, False, False, a.TotalCambio.ToString(), IIf(TallaColor = 1, "0", ""), PrintGeneric)
                    Else
                        'Realizar el reembolso al cliente 

                        If MessageBox.Show("¿Desea aplicar un reembolso por " & Format(CStr(ModPOS.Redondear(a.TotalAbono, 2)), "Currency") & " " & MonedaRef & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then


                            Dim aut As New MeAutorizacion
                            aut.Sucursal = SUCClave
                            aut.MontodeAutorizacion = a.TotalAbono
                            aut.StartPosition = FormStartPosition.CenterScreen
                            aut.ShowDialog()
                            If aut.DialogResult = DialogResult.OK Then
                                If aut.Autorizado Then
                                    If Cajon = True Then
                                        AbrirCajon(Impresora)
                                    End If

                                    ModPOS.Ejecuta("st_aplica_reembolso", _
                                                          "@CTEClave", car.ClienteMostrador, _
                                                          "@DOCClave", car.CARClave, _
                                                          "@TipoDocumento", 3, _
                                                          "@CAJClave", CAJClave, _
                                                          "@Moneda", car.Moneda, _
                                                          "@TipoCambio", car.TipoCambio, _
                                                          "@Saldo", a.TotalAbono, _
                                                          "@Usuario", ModPOS.UsuarioActual)

                                End If
                            End If
                            a.Dispose()

                        End If

                    End If
                    tel.Dispose()
                End If
            Else
                'elimina cargo 
                ModPOS.Ejecuta("st_elimina_cargo", "@CARClave", car.CARClave)
            End If


        End If
        car.Dispose()
    End Sub
End Class
