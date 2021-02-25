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
    Friend WithEvents BtnApartados As Janus.Windows.EditControls.UIButton
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
    Friend WithEvents UiTabAnticipos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpAnticipos As System.Windows.Forms.GroupBox
    Friend WithEvents btnAnticipo As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridAnticipos As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkAnticipos As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblSaldoAnticipos As System.Windows.Forms.Label
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
    Friend WithEvents btnBonificacion As Janus.Windows.EditControls.UIButton
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
    Friend WithEvents cmbComplemento As System.Windows.Forms.DateTimePicker
    Friend WithEvents gridComplementoPago As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnPrintCompl As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSendCompl As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnActCxC As Janus.Windows.EditControls.UIButton
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
        Me.BtnApartados = New Janus.Windows.EditControls.UIButton()
        Me.BtnAuditoria = New Janus.Windows.EditControls.UIButton()
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton()
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabGeneral = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpTickets = New System.Windows.Forms.GroupBox()
        Me.lblMonedaCambio = New System.Windows.Forms.Label()
        Me.chkIncluir = New System.Windows.Forms.CheckBox()
        Me.picKeyboard = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipoTrans = New Selling.StoreCombo()
        Me.BtnRefresh = New Janus.Windows.EditControls.UIButton()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.LblSaldo = New System.Windows.Forms.Label()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridCxC = New Janus.Windows.GridEX.GridEX()
        Me.UiTabCXC = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GridCreditos = New Janus.Windows.GridEX.GridEX()
        Me.UiTabAnticipos = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpAnticipos = New System.Windows.Forms.GroupBox()
        Me.ChkAnticipos = New System.Windows.Forms.CheckBox()
        Me.btnAnticipo = New Janus.Windows.EditControls.UIButton()
        Me.btnCancel = New Janus.Windows.EditControls.UIButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblSaldoAnticipos = New System.Windows.Forms.Label()
        Me.GridAnticipos = New Janus.Windows.GridEX.GridEX()
        Me.UiTabComplementoPago = New Janus.Windows.UI.Tab.UITabPage()
        Me.grpComplementoPago = New System.Windows.Forms.GroupBox()
        Me.btnPrintCompl = New Janus.Windows.EditControls.UIButton()
        Me.btnSendCompl = New Janus.Windows.EditControls.UIButton()
        Me.btnCertificaPago = New Janus.Windows.EditControls.UIButton()
        Me.chkCompTodos = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbComplemento = New System.Windows.Forms.DateTimePicker()
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
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.cmbEdoContrarecibo = New Selling.StoreCombo()
        Me.UiTabClientes = New Janus.Windows.UI.Tab.UITabPage()
        Me.grpClientes = New System.Windows.Forms.GroupBox()
        Me.btnCliente = New Janus.Windows.EditControls.UIButton()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.BtnEdoCta = New Janus.Windows.EditControls.UIButton()
        Me.gridClientes = New Janus.Windows.GridEX.GridEX()
        Me.CmbCampo = New Selling.StoreCombo()
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
        Me.BtnNC = New Janus.Windows.EditControls.UIButton()
        Me.BtnFacturar = New Janus.Windows.EditControls.UIButton()
        Me.BtnRecibo = New Janus.Windows.EditControls.UIButton()
        Me.BtnDevolucion = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.btnNotaCargo = New Janus.Windows.EditControls.UIButton()
        Me.BtnConsultar = New Janus.Windows.EditControls.UIButton()
        Me.btnReembolso = New Janus.Windows.EditControls.UIButton()
        Me.btnMasiva = New Janus.Windows.EditControls.UIButton()
        Me.btnBonificacion = New Janus.Windows.EditControls.UIButton()
        Me.btnReenvio = New Janus.Windows.EditControls.UIButton()
        Me.btnAcumulado = New Janus.Windows.EditControls.UIButton()
        Me.btnCorte = New Janus.Windows.EditControls.UIButton()
        Me.LblTipoCambio = New System.Windows.Forms.Label()
        Me.BtnGlobal = New Janus.Windows.EditControls.UIButton()
        Me.Clock2 = New System.Windows.Forms.Timer(Me.components)
        Me.btnVerificador = New Janus.Windows.EditControls.UIButton()
        Me.BtnNota = New Janus.Windows.EditControls.UIButton()
        Me.BtnCerrar = New Janus.Windows.EditControls.UIButton()
        Me.btnActCxC = New Janus.Windows.EditControls.UIButton()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabGeneral.SuspendLayout()
        Me.GrpTickets.SuspendLayout()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCxC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabCXC.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridCreditos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabAnticipos.SuspendLayout()
        Me.GrpAnticipos.SuspendLayout()
        CType(Me.GridAnticipos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GrpSaldos.SuspendLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpMetodos.SuspendLayout()
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BtnPago.Location = New System.Drawing.Point(783, 62)
        Me.BtnPago.Name = "BtnPago"
        Me.BtnPago.Size = New System.Drawing.Size(91, 30)
        Me.BtnPago.TabIndex = 1
        Me.BtnPago.Text = "F10 - Pagar"
        Me.BtnPago.ToolTipText = "Registrar Pago de registros seleccionados"
        Me.BtnPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnRetiro
        '
        Me.BtnRetiro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRetiro.Icon = CType(resources.GetObject("BtnRetiro.Icon"), System.Drawing.Icon)
        Me.BtnRetiro.ImageSize = New System.Drawing.Size(24, 24)
        Me.BtnRetiro.Location = New System.Drawing.Point(298, 62)
        Me.BtnRetiro.Name = "BtnRetiro"
        Me.BtnRetiro.Size = New System.Drawing.Size(91, 30)
        Me.BtnRetiro.TabIndex = 10
        Me.BtnRetiro.Text = "F5- Retiro"
        Me.BtnRetiro.ToolTipText = "Retiro de Caja"
        Me.BtnRetiro.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnApartados
        '
        Me.BtnApartados.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnApartados.Icon = CType(resources.GetObject("BtnApartados.Icon"), System.Drawing.Icon)
        Me.BtnApartados.Location = New System.Drawing.Point(104, 96)
        Me.BtnApartados.Name = "BtnApartados"
        Me.BtnApartados.Size = New System.Drawing.Size(91, 30)
        Me.BtnApartados.TabIndex = 15
        Me.BtnApartados.Text = "Apartados"
        Me.BtnApartados.ToolTipText = "Mantenimiento de Productos Apartados"
        Me.BtnApartados.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAuditoria
        '
        Me.BtnAuditoria.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAuditoria.Icon = CType(resources.GetObject("BtnAuditoria.Icon"), System.Drawing.Icon)
        Me.BtnAuditoria.Location = New System.Drawing.Point(104, 62)
        Me.BtnAuditoria.Name = "BtnAuditoria"
        Me.BtnAuditoria.Size = New System.Drawing.Size(91, 30)
        Me.BtnAuditoria.TabIndex = 17
        Me.BtnAuditoria.Text = "F3- Auditoria"
        Me.BtnAuditoria.ToolTipText = "Consulta de auditoria de pedidos o ventas"
        Me.BtnAuditoria.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnReimpresion
        '
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Icon = CType(resources.GetObject("BtnReimpresion.Icon"), System.Drawing.Icon)
        Me.BtnReimpresion.Location = New System.Drawing.Point(783, 96)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(91, 30)
        Me.BtnReimpresion.TabIndex = 18
        Me.BtnReimpresion.Text = "Imprimir"
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
        Me.UiTab1.Location = New System.Drawing.Point(2, 132)
        Me.UiTab1.Name = "UiTab1"
        Me.UiTab1.Size = New System.Drawing.Size(1161, 427)
        Me.UiTab1.TabIndex = 21
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabGeneral, Me.UiTabCXC, Me.UiTabAnticipos, Me.UiTabComplementoPago, Me.UiTabPendientes, Me.UiTabContrarecibos, Me.UiTabClientes})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabGeneral
        '
        Me.UiTabGeneral.Controls.Add(Me.GrpTickets)
        Me.UiTabGeneral.Location = New System.Drawing.Point(1, 21)
        Me.UiTabGeneral.Name = "UiTabGeneral"
        Me.UiTabGeneral.Size = New System.Drawing.Size(1159, 405)
        Me.UiTabGeneral.TabStop = True
        Me.UiTabGeneral.Text = "General"
        '
        'GrpTickets
        '
        Me.GrpTickets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.lblMonedaCambio)
        Me.GrpTickets.Controls.Add(Me.chkIncluir)
        Me.GrpTickets.Controls.Add(Me.picKeyboard)
        Me.GrpTickets.Controls.Add(Me.Label4)
        Me.GrpTickets.Controls.Add(Me.PictureBox1)
        Me.GrpTickets.Controls.Add(Me.dtPicker)
        Me.GrpTickets.Controls.Add(Me.PictureBox2)
        Me.GrpTickets.Controls.Add(Me.Label3)
        Me.GrpTickets.Controls.Add(Me.cmbTipoTrans)
        Me.GrpTickets.Controls.Add(Me.BtnRefresh)
        Me.GrpTickets.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpTickets.Controls.Add(Me.LblSaldo)
        Me.GrpTickets.Controls.Add(Me.LblTotal)
        Me.GrpTickets.Controls.Add(Me.TxtFolio)
        Me.GrpTickets.Controls.Add(Me.Label1)
        Me.GrpTickets.Controls.Add(Me.GridCxC)
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(2, 3)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(1155, 399)
        Me.GrpTickets.TabIndex = 2
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Cobranza General"
        '
        'lblMonedaCambio
        '
        Me.lblMonedaCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMonedaCambio.BackColor = System.Drawing.Color.Transparent
        Me.lblMonedaCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonedaCambio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblMonedaCambio.Location = New System.Drawing.Point(509, 364)
        Me.lblMonedaCambio.Name = "lblMonedaCambio"
        Me.lblMonedaCambio.Size = New System.Drawing.Size(268, 20)
        Me.lblMonedaCambio.TabIndex = 93
        Me.lblMonedaCambio.Text = "$0.00 M.N"
        Me.lblMonedaCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblMonedaCambio.Visible = False
        '
        'chkIncluir
        '
        Me.chkIncluir.Location = New System.Drawing.Point(551, 20)
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
        Me.picKeyboard.Location = New System.Drawing.Point(7, 360)
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
        Me.Label4.Location = New System.Drawing.Point(939, 22)
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
        Me.dtPicker.Location = New System.Drawing.Point(1001, 17)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(145, 20)
        Me.dtPicker.TabIndex = 85
        Me.dtPicker.Value = New Date(2015, 1, 27, 0, 0, 0, 0)
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
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(95, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 14)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "Tipo"
        '
        'cmbTipoTrans
        '
        Me.cmbTipoTrans.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoTrans.Location = New System.Drawing.Point(136, 15)
        Me.cmbTipoTrans.Name = "cmbTipoTrans"
        Me.cmbTipoTrans.Size = New System.Drawing.Size(139, 21)
        Me.cmbTipoTrans.TabIndex = 82
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Icon = CType(resources.GetObject("BtnRefresh.Icon"), System.Drawing.Icon)
        Me.BtnRefresh.Location = New System.Drawing.Point(417, 18)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(126, 21)
        Me.BtnRefresh.TabIndex = 50
        Me.BtnRefresh.Text = "F12 - Actualizar"
        Me.BtnRefresh.ToolTipText = "Actualizar"
        Me.BtnRefresh.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
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
        Me.LblSaldo.Location = New System.Drawing.Point(950, 356)
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
        Me.LblTotal.Location = New System.Drawing.Point(795, 364)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(150, 27)
        Me.LblTotal.TabIndex = 47
        Me.LblTotal.Text = "TOTAL A PAGAR"
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(325, 18)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(84, 21)
        Me.TxtFolio.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(281, 21)
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
        Me.GridCxC.GroupByBoxVisible = False
        Me.GridCxC.Location = New System.Drawing.Point(7, 44)
        Me.GridCxC.Name = "GridCxC"
        Me.GridCxC.RecordNavigator = True
        Me.GridCxC.Size = New System.Drawing.Size(1140, 301)
        Me.GridCxC.TabIndex = 4
        Me.GridCxC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabCXC
        '
        Me.UiTabCXC.Controls.Add(Me.GroupBox1)
        Me.UiTabCXC.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCXC.Name = "UiTabCXC"
        Me.UiTabCXC.Size = New System.Drawing.Size(1159, 405)
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
        Me.GroupBox1.Size = New System.Drawing.Size(1155, 396)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cobranza"
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
        Me.GridCreditos.GroupByBoxVisible = False
        Me.GridCreditos.Location = New System.Drawing.Point(7, 35)
        Me.GridCreditos.Name = "GridCreditos"
        Me.GridCreditos.RecordNavigator = True
        Me.GridCreditos.Size = New System.Drawing.Size(1140, 355)
        Me.GridCreditos.TabIndex = 4
        Me.GridCreditos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabAnticipos
        '
        Me.UiTabAnticipos.Controls.Add(Me.GrpAnticipos)
        Me.UiTabAnticipos.Location = New System.Drawing.Point(1, 21)
        Me.UiTabAnticipos.Name = "UiTabAnticipos"
        Me.UiTabAnticipos.Size = New System.Drawing.Size(1159, 405)
        Me.UiTabAnticipos.TabStop = True
        Me.UiTabAnticipos.Text = "Anticipos"
        '
        'GrpAnticipos
        '
        Me.GrpAnticipos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpAnticipos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpAnticipos.Controls.Add(Me.ChkAnticipos)
        Me.GrpAnticipos.Controls.Add(Me.btnAnticipo)
        Me.GrpAnticipos.Controls.Add(Me.btnCancel)
        Me.GrpAnticipos.Controls.Add(Me.Label2)
        Me.GrpAnticipos.Controls.Add(Me.LblSaldoAnticipos)
        Me.GrpAnticipos.Controls.Add(Me.GridAnticipos)
        Me.GrpAnticipos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpAnticipos.ForeColor = System.Drawing.Color.Black
        Me.GrpAnticipos.Location = New System.Drawing.Point(2, 3)
        Me.GrpAnticipos.Name = "GrpAnticipos"
        Me.GrpAnticipos.Size = New System.Drawing.Size(1155, 399)
        Me.GrpAnticipos.TabIndex = 4
        Me.GrpAnticipos.TabStop = False
        Me.GrpAnticipos.Text = "Abonos con saldo pendiente de aplicar"
        '
        'ChkAnticipos
        '
        Me.ChkAnticipos.Location = New System.Drawing.Point(8, 22)
        Me.ChkAnticipos.Name = "ChkAnticipos"
        Me.ChkAnticipos.Size = New System.Drawing.Size(182, 20)
        Me.ChkAnticipos.TabIndex = 51
        Me.ChkAnticipos.Text = "Seleccionar Todos"
        '
        'btnAnticipo
        '
        Me.btnAnticipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnticipo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnticipo.Icon = CType(resources.GetObject("btnAnticipo.Icon"), System.Drawing.Icon)
        Me.btnAnticipo.ImageSize = New System.Drawing.Size(24, 16)
        Me.btnAnticipo.Location = New System.Drawing.Point(959, 13)
        Me.btnAnticipo.Name = "btnAnticipo"
        Me.btnAnticipo.Size = New System.Drawing.Size(92, 28)
        Me.btnAnticipo.TabIndex = 22
        Me.btnAnticipo.Text = "Anticipo"
        Me.btnAnticipo.ToolTipText = "Registrar Anticipo"
        Me.btnAnticipo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.Icon = CType(resources.GetObject("btnCancel.Icon"), System.Drawing.Icon)
        Me.btnCancel.Location = New System.Drawing.Point(1056, 13)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 28)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "Cancelar"
        Me.btnCancel.ToolTipText = "Cancela el documento seleccionado"
        Me.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(935, 368)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 18)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "TOTAL "
        '
        'LblSaldoAnticipos
        '
        Me.LblSaldoAnticipos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSaldoAnticipos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblSaldoAnticipos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaldoAnticipos.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblSaldoAnticipos.Location = New System.Drawing.Point(993, 358)
        Me.LblSaldoAnticipos.Name = "LblSaldoAnticipos"
        Me.LblSaldoAnticipos.Size = New System.Drawing.Size(154, 35)
        Me.LblSaldoAnticipos.TabIndex = 53
        Me.LblSaldoAnticipos.Text = "0.00"
        Me.LblSaldoAnticipos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GridAnticipos
        '
        Me.GridAnticipos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridAnticipos.ColumnAutoResize = True
        Me.GridAnticipos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridAnticipos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridAnticipos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridAnticipos.GroupByBoxVisible = False
        Me.GridAnticipos.Location = New System.Drawing.Point(7, 44)
        Me.GridAnticipos.Name = "GridAnticipos"
        Me.GridAnticipos.RecordNavigator = True
        Me.GridAnticipos.Size = New System.Drawing.Size(1140, 309)
        Me.GridAnticipos.TabIndex = 4
        Me.GridAnticipos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabComplementoPago
        '
        Me.UiTabComplementoPago.Controls.Add(Me.grpComplementoPago)
        Me.UiTabComplementoPago.Location = New System.Drawing.Point(1, 21)
        Me.UiTabComplementoPago.Name = "UiTabComplementoPago"
        Me.UiTabComplementoPago.Size = New System.Drawing.Size(1159, 405)
        Me.UiTabComplementoPago.TabStop = True
        Me.UiTabComplementoPago.Text = "Complemento de Pago"
        '
        'grpComplementoPago
        '
        Me.grpComplementoPago.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpComplementoPago.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpComplementoPago.Controls.Add(Me.btnPrintCompl)
        Me.grpComplementoPago.Controls.Add(Me.btnSendCompl)
        Me.grpComplementoPago.Controls.Add(Me.btnCertificaPago)
        Me.grpComplementoPago.Controls.Add(Me.chkCompTodos)
        Me.grpComplementoPago.Controls.Add(Me.Label7)
        Me.grpComplementoPago.Controls.Add(Me.cmbComplemento)
        Me.grpComplementoPago.Controls.Add(Me.gridComplementoPago)
        Me.grpComplementoPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpComplementoPago.ForeColor = System.Drawing.Color.Black
        Me.grpComplementoPago.Location = New System.Drawing.Point(2, 3)
        Me.grpComplementoPago.Name = "grpComplementoPago"
        Me.grpComplementoPago.Size = New System.Drawing.Size(1155, 399)
        Me.grpComplementoPago.TabIndex = 4
        Me.grpComplementoPago.TabStop = False
        Me.grpComplementoPago.Text = "Comprobantes de Pago"
        '
        'btnPrintCompl
        '
        Me.btnPrintCompl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintCompl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrintCompl.Icon = CType(resources.GetObject("btnPrintCompl.Icon"), System.Drawing.Icon)
        Me.btnPrintCompl.Location = New System.Drawing.Point(861, 10)
        Me.btnPrintCompl.Name = "btnPrintCompl"
        Me.btnPrintCompl.Size = New System.Drawing.Size(91, 30)
        Me.btnPrintCompl.TabIndex = 83
        Me.btnPrintCompl.Text = "Imprimir"
        Me.btnPrintCompl.ToolTipText = "impresión de documentos seleccionados"
        Me.btnPrintCompl.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnSendCompl
        '
        Me.btnSendCompl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSendCompl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSendCompl.Icon = CType(resources.GetObject("btnSendCompl.Icon"), System.Drawing.Icon)
        Me.btnSendCompl.Location = New System.Drawing.Point(958, 10)
        Me.btnSendCompl.Name = "btnSendCompl"
        Me.btnSendCompl.Size = New System.Drawing.Size(91, 30)
        Me.btnSendCompl.TabIndex = 146
        Me.btnSendCompl.Text = "Enviar"
        Me.btnSendCompl.ToolTipText = "envia por correo electronico los documentos seleccionados"
        Me.btnSendCompl.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnCertificaPago
        '
        Me.btnCertificaPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCertificaPago.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCertificaPago.Icon = CType(resources.GetObject("btnCertificaPago.Icon"), System.Drawing.Icon)
        Me.btnCertificaPago.Location = New System.Drawing.Point(1055, 10)
        Me.btnCertificaPago.Name = "btnCertificaPago"
        Me.btnCertificaPago.Size = New System.Drawing.Size(91, 30)
        Me.btnCertificaPago.TabIndex = 145
        Me.btnCertificaPago.Text = "Certificar"
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
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(688, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 86
        Me.Label7.Text = "Fecha"
        '
        'cmbComplemento
        '
        Me.cmbComplemento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbComplemento.CustomFormat = "MMMM yyyy"
        Me.cmbComplemento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbComplemento.Location = New System.Drawing.Point(742, 16)
        Me.cmbComplemento.Name = "cmbComplemento"
        Me.cmbComplemento.Size = New System.Drawing.Size(113, 20)
        Me.cmbComplemento.TabIndex = 85
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
        Me.gridComplementoPago.GroupByBoxVisible = False
        Me.gridComplementoPago.Location = New System.Drawing.Point(7, 44)
        Me.gridComplementoPago.Name = "gridComplementoPago"
        Me.gridComplementoPago.RecordNavigator = True
        Me.gridComplementoPago.Size = New System.Drawing.Size(1140, 350)
        Me.gridComplementoPago.TabIndex = 4
        Me.gridComplementoPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabPendientes
        '
        Me.UiTabPendientes.Controls.Add(Me.GrpPendientes)
        Me.UiTabPendientes.Location = New System.Drawing.Point(1, 21)
        Me.UiTabPendientes.Name = "UiTabPendientes"
        Me.UiTabPendientes.Size = New System.Drawing.Size(1159, 405)
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
        Me.GrpPendientes.Size = New System.Drawing.Size(1155, 399)
        Me.GrpPendientes.TabIndex = 3
        Me.GrpPendientes.TabStop = False
        Me.GrpPendientes.Text = "Documentos Pendientes de Certificar"
        '
        'btnCancelaPendiente
        '
        Me.btnCancelaPendiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelaPendiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelaPendiente.Icon = CType(resources.GetObject("btnCancelaPendiente.Icon"), System.Drawing.Icon)
        Me.btnCancelaPendiente.Location = New System.Drawing.Point(860, 15)
        Me.btnCancelaPendiente.Name = "btnCancelaPendiente"
        Me.btnCancelaPendiente.Size = New System.Drawing.Size(92, 28)
        Me.btnCancelaPendiente.TabIndex = 23
        Me.btnCancelaPendiente.Text = "Cancelar"
        Me.btnCancelaPendiente.ToolTipText = "Cancela el registro seleccionado"
        Me.btnCancelaPendiente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnRegenerar
        '
        Me.btnRegenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRegenerar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRegenerar.Icon = CType(resources.GetObject("btnRegenerar.Icon"), System.Drawing.Icon)
        Me.btnRegenerar.Location = New System.Drawing.Point(957, 15)
        Me.btnRegenerar.Name = "btnRegenerar"
        Me.btnRegenerar.Size = New System.Drawing.Size(91, 28)
        Me.btnRegenerar.TabIndex = 22
        Me.btnRegenerar.Text = "Regenerar"
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
        Me.GridPendientes.GroupByBoxVisible = False
        Me.GridPendientes.Location = New System.Drawing.Point(5, 48)
        Me.GridPendientes.Name = "GridPendientes"
        Me.GridPendientes.RecordNavigator = True
        Me.GridPendientes.Size = New System.Drawing.Size(1141, 343)
        Me.GridPendientes.TabIndex = 4
        Me.GridPendientes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnCertificar
        '
        Me.btnCertificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCertificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCertificar.Icon = CType(resources.GetObject("btnCertificar.Icon"), System.Drawing.Icon)
        Me.btnCertificar.Location = New System.Drawing.Point(1054, 15)
        Me.btnCertificar.Name = "btnCertificar"
        Me.btnCertificar.Size = New System.Drawing.Size(92, 28)
        Me.btnCertificar.TabIndex = 21
        Me.btnCertificar.Text = "Certificar"
        Me.btnCertificar.ToolTipText = "Realiza un reintento de certificación del documento seleccionado"
        Me.btnCertificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTabContrarecibos
        '
        Me.UiTabContrarecibos.Controls.Add(Me.GroupBox2)
        Me.UiTabContrarecibos.Location = New System.Drawing.Point(1, 21)
        Me.UiTabContrarecibos.Name = "UiTabContrarecibos"
        Me.UiTabContrarecibos.Size = New System.Drawing.Size(1159, 405)
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
        Me.GroupBox2.Controls.Add(Me.PictureBox5)
        Me.GroupBox2.Controls.Add(Me.cmbEdoContrarecibo)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1155, 399)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Gestión de Contrarecibos"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.Icon = CType(resources.GetObject("btnPrint.Icon"), System.Drawing.Icon)
        Me.btnPrint.Location = New System.Drawing.Point(862, 12)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(92, 28)
        Me.btnPrint.TabIndex = 144
        Me.btnPrint.Text = "Imprimir"
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
        Me.btnEditContrarecibo.Location = New System.Drawing.Point(959, 12)
        Me.btnEditContrarecibo.Name = "btnEditContrarecibo"
        Me.btnEditContrarecibo.Size = New System.Drawing.Size(92, 28)
        Me.btnEditContrarecibo.TabIndex = 90
        Me.btnEditContrarecibo.Text = "Recibir"
        Me.btnEditContrarecibo.ToolTipText = "Actualiza el registro seleccionado"
        Me.btnEditContrarecibo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAddContrarecibo
        '
        Me.btnAddContrarecibo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddContrarecibo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddContrarecibo.Icon = CType(resources.GetObject("btnAddContrarecibo.Icon"), System.Drawing.Icon)
        Me.btnAddContrarecibo.Location = New System.Drawing.Point(1056, 12)
        Me.btnAddContrarecibo.Name = "btnAddContrarecibo"
        Me.btnAddContrarecibo.Size = New System.Drawing.Size(91, 28)
        Me.btnAddContrarecibo.TabIndex = 89
        Me.btnAddContrarecibo.Text = "Agregar"
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
        Me.GridContrarecibos.GroupByBoxVisible = False
        Me.GridContrarecibos.Location = New System.Drawing.Point(7, 44)
        Me.GridContrarecibos.Name = "GridContrarecibos"
        Me.GridContrarecibos.RecordNavigator = True
        Me.GridContrarecibos.Size = New System.Drawing.Size(1140, 350)
        Me.GridContrarecibos.TabIndex = 4
        Me.GridContrarecibos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
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
        'cmbEdoContrarecibo
        '
        Me.cmbEdoContrarecibo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbEdoContrarecibo.Location = New System.Drawing.Point(72, 18)
        Me.cmbEdoContrarecibo.Name = "cmbEdoContrarecibo"
        Me.cmbEdoContrarecibo.Size = New System.Drawing.Size(154, 21)
        Me.cmbEdoContrarecibo.TabIndex = 82
        '
        'UiTabClientes
        '
        Me.UiTabClientes.Controls.Add(Me.grpClientes)
        Me.UiTabClientes.Location = New System.Drawing.Point(1, 21)
        Me.UiTabClientes.Name = "UiTabClientes"
        Me.UiTabClientes.Size = New System.Drawing.Size(1159, 405)
        Me.UiTabClientes.TabStop = True
        Me.UiTabClientes.Text = "Clientes"
        '
        'grpClientes
        '
        Me.grpClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpClientes.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpClientes.Controls.Add(Me.btnCliente)
        Me.grpClientes.Controls.Add(Me.TxtBuscar)
        Me.grpClientes.Controls.Add(Me.BtnEdoCta)
        Me.grpClientes.Controls.Add(Me.gridClientes)
        Me.grpClientes.Controls.Add(Me.CmbCampo)
        Me.grpClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpClientes.ForeColor = System.Drawing.Color.Black
        Me.grpClientes.Location = New System.Drawing.Point(2, 4)
        Me.grpClientes.Name = "grpClientes"
        Me.grpClientes.Size = New System.Drawing.Size(1155, 396)
        Me.grpClientes.TabIndex = 3
        Me.grpClientes.TabStop = False
        Me.grpClientes.Text = "Clientes"
        '
        'btnCliente
        '
        Me.btnCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCliente.Icon = CType(resources.GetObject("btnCliente.Icon"), System.Drawing.Icon)
        Me.btnCliente.Location = New System.Drawing.Point(859, 12)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(140, 30)
        Me.btnCliente.TabIndex = 23
        Me.btnCliente.Text = "Editar Cliente"
        Me.btnCliente.ToolTipText = "Edita Cliente Seleccionado"
        Me.btnCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBuscar.Location = New System.Drawing.Point(178, 19)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(440, 20)
        Me.TxtBuscar.TabIndex = 21
        '
        'BtnEdoCta
        '
        Me.BtnEdoCta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEdoCta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEdoCta.Icon = CType(resources.GetObject("BtnEdoCta.Icon"), System.Drawing.Icon)
        Me.BtnEdoCta.Location = New System.Drawing.Point(1007, 12)
        Me.BtnEdoCta.Name = "BtnEdoCta"
        Me.BtnEdoCta.Size = New System.Drawing.Size(140, 30)
        Me.BtnEdoCta.TabIndex = 20
        Me.BtnEdoCta.Text = "Estado de Cuenta"
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
        Me.gridClientes.GroupByBoxVisible = False
        Me.gridClientes.Location = New System.Drawing.Point(7, 48)
        Me.gridClientes.Name = "gridClientes"
        Me.gridClientes.RecordNavigator = True
        Me.gridClientes.Size = New System.Drawing.Size(1140, 342)
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
        Me.BtnComision.Location = New System.Drawing.Point(201, 96)
        Me.BtnComision.Name = "BtnComision"
        Me.BtnComision.Size = New System.Drawing.Size(91, 30)
        Me.BtnComision.TabIndex = 20
        Me.BtnComision.Text = " Comisión"
        Me.BtnComision.ToolTipText = "Registrar Pago de Comisionistas"
        Me.BtnComision.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCambio
        '
        Me.BtnCambio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCambio.Icon = CType(resources.GetObject("BtnCambio.Icon"), System.Drawing.Icon)
        Me.BtnCambio.Location = New System.Drawing.Point(7, 96)
        Me.BtnCambio.Name = "BtnCambio"
        Me.BtnCambio.Size = New System.Drawing.Size(91, 30)
        Me.BtnCambio.TabIndex = 16
        Me.BtnCambio.Text = "Cambios"
        Me.BtnCambio.ToolTipText = "Registrar Cambio de Producto"
        Me.BtnCambio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnNC
        '
        Me.BtnNC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNC.Icon = CType(resources.GetObject("BtnNC.Icon"), System.Drawing.Icon)
        Me.BtnNC.Location = New System.Drawing.Point(492, 62)
        Me.BtnNC.Name = "BtnNC"
        Me.BtnNC.Size = New System.Drawing.Size(91, 30)
        Me.BtnNC.TabIndex = 4
        Me.BtnNC.Text = "F7- NC"
        Me.BtnNC.ToolTipText = "Crear Nota de Crédito de registro seleccionado"
        Me.BtnNC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnFacturar
        '
        Me.BtnFacturar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFacturar.Icon = CType(resources.GetObject("BtnFacturar.Icon"), System.Drawing.Icon)
        Me.BtnFacturar.Location = New System.Drawing.Point(589, 62)
        Me.BtnFacturar.Name = "BtnFacturar"
        Me.BtnFacturar.Size = New System.Drawing.Size(91, 30)
        Me.BtnFacturar.TabIndex = 3
        Me.BtnFacturar.Text = "F8-Facturar"
        Me.BtnFacturar.ToolTipText = "Crear nueva factura de registros seleccionados"
        Me.BtnFacturar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnRecibo
        '
        Me.BtnRecibo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRecibo.Icon = CType(resources.GetObject("BtnRecibo.Icon"), System.Drawing.Icon)
        Me.BtnRecibo.Location = New System.Drawing.Point(7, 62)
        Me.BtnRecibo.Name = "BtnRecibo"
        Me.BtnRecibo.Size = New System.Drawing.Size(91, 30)
        Me.BtnRecibo.TabIndex = 2
        Me.BtnRecibo.Text = "F2 - Abonos"
        Me.BtnRecibo.ToolTipText = "Imprimir Recibo de registro seleccionado"
        Me.BtnRecibo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnDevolucion
        '
        Me.BtnDevolucion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDevolucion.Icon = CType(resources.GetObject("BtnDevolucion.Icon"), System.Drawing.Icon)
        Me.BtnDevolucion.Location = New System.Drawing.Point(201, 62)
        Me.BtnDevolucion.Name = "BtnDevolucion"
        Me.BtnDevolucion.Size = New System.Drawing.Size(91, 30)
        Me.BtnDevolucion.TabIndex = 5
        Me.BtnDevolucion.Text = "F4- Devolución"
        Me.BtnDevolucion.ToolTipText = "Crear Devolución"
        Me.BtnDevolucion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(395, 62)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(91, 30)
        Me.BtnCancelar.TabIndex = 6
        Me.BtnCancelar.Text = "F6- Cancelar"
        Me.BtnCancelar.ToolTipText = "Cancela el Ticket o Factura"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
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
        Me.lblDate.Location = New System.Drawing.Point(467, 6)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(693, 22)
        Me.lblDate.TabIndex = 22
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnNotaCargo
        '
        Me.btnNotaCargo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNotaCargo.Icon = CType(resources.GetObject("btnNotaCargo.Icon"), System.Drawing.Icon)
        Me.btnNotaCargo.Location = New System.Drawing.Point(686, 62)
        Me.btnNotaCargo.Name = "btnNotaCargo"
        Me.btnNotaCargo.Size = New System.Drawing.Size(91, 30)
        Me.btnNotaCargo.TabIndex = 23
        Me.btnNotaCargo.Text = "F9- Cargo"
        Me.btnNotaCargo.ToolTipText = "Crear Nota de Cargo "
        Me.btnNotaCargo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsultar.Icon = CType(resources.GetObject("BtnConsultar.Icon"), System.Drawing.Icon)
        Me.BtnConsultar.Location = New System.Drawing.Point(298, 96)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(91, 30)
        Me.BtnConsultar.TabIndex = 24
        Me.BtnConsultar.Text = "Consultar"
        Me.BtnConsultar.ToolTipText = "Consultar documento"
        Me.BtnConsultar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnReembolso
        '
        Me.btnReembolso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReembolso.Icon = CType(resources.GetObject("btnReembolso.Icon"), System.Drawing.Icon)
        Me.btnReembolso.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnReembolso.Location = New System.Drawing.Point(395, 96)
        Me.btnReembolso.Name = "btnReembolso"
        Me.btnReembolso.Size = New System.Drawing.Size(91, 30)
        Me.btnReembolso.TabIndex = 25
        Me.btnReembolso.Text = "Reembolso"
        Me.btnReembolso.ToolTipText = "Reembolso a cliente"
        Me.btnReembolso.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnMasiva
        '
        Me.btnMasiva.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMasiva.Icon = CType(resources.GetObject("btnMasiva.Icon"), System.Drawing.Icon)
        Me.btnMasiva.Location = New System.Drawing.Point(589, 96)
        Me.btnMasiva.Name = "btnMasiva"
        Me.btnMasiva.Size = New System.Drawing.Size(91, 30)
        Me.btnMasiva.TabIndex = 26
        Me.btnMasiva.Text = "Fac. Masiva"
        Me.btnMasiva.ToolTipText = "Crea un factura por cada documento seleccionado."
        Me.btnMasiva.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnBonificacion
        '
        Me.btnBonificacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBonificacion.Icon = CType(resources.GetObject("btnBonificacion.Icon"), System.Drawing.Icon)
        Me.btnBonificacion.Location = New System.Drawing.Point(492, 96)
        Me.btnBonificacion.Name = "btnBonificacion"
        Me.btnBonificacion.Size = New System.Drawing.Size(91, 30)
        Me.btnBonificacion.TabIndex = 27
        Me.btnBonificacion.Text = "Bonificación"
        Me.btnBonificacion.ToolTipText = "Crea Nota de Crédito por Bonificación"
        Me.btnBonificacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnReenvio
        '
        Me.btnReenvio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReenvio.Icon = CType(resources.GetObject("btnReenvio.Icon"), System.Drawing.Icon)
        Me.btnReenvio.Location = New System.Drawing.Point(880, 96)
        Me.btnReenvio.Name = "btnReenvio"
        Me.btnReenvio.Size = New System.Drawing.Size(91, 30)
        Me.btnReenvio.TabIndex = 28
        Me.btnReenvio.Text = "Enviar"
        Me.btnReenvio.ToolTipText = "Envia por correo electronico  los documentos seleccionados"
        Me.btnReenvio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAcumulado
        '
        Me.btnAcumulado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAcumulado.Icon = CType(resources.GetObject("btnAcumulado.Icon"), System.Drawing.Icon)
        Me.btnAcumulado.Location = New System.Drawing.Point(977, 96)
        Me.btnAcumulado.Name = "btnAcumulado"
        Me.btnAcumulado.Size = New System.Drawing.Size(91, 30)
        Me.btnAcumulado.TabIndex = 29
        Me.btnAcumulado.Text = "Acumulado"
        Me.btnAcumulado.ToolTipText = "Consulta de auditoria de pedidos o ventas"
        Me.btnAcumulado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnCorte
        '
        Me.btnCorte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCorte.Icon = CType(resources.GetObject("btnCorte.Icon"), System.Drawing.Icon)
        Me.btnCorte.Location = New System.Drawing.Point(880, 62)
        Me.btnCorte.Name = "btnCorte"
        Me.btnCorte.Size = New System.Drawing.Size(91, 30)
        Me.btnCorte.TabIndex = 30
        Me.btnCorte.Text = "F11 - Corte"
        Me.btnCorte.ToolTipText = "Imprimir Corte"
        Me.btnCorte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTipoCambio.BackColor = System.Drawing.Color.Transparent
        Me.LblTipoCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipoCambio.ForeColor = System.Drawing.Color.Navy
        Me.LblTipoCambio.Location = New System.Drawing.Point(952, 37)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(206, 15)
        Me.LblTipoCambio.TabIndex = 78
        Me.LblTipoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnGlobal
        '
        Me.BtnGlobal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnGlobal.Icon = CType(resources.GetObject("BtnGlobal.Icon"), System.Drawing.Icon)
        Me.BtnGlobal.Location = New System.Drawing.Point(686, 96)
        Me.BtnGlobal.Name = "BtnGlobal"
        Me.BtnGlobal.Size = New System.Drawing.Size(91, 30)
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
        Me.btnVerificador.Location = New System.Drawing.Point(977, 62)
        Me.btnVerificador.Name = "btnVerificador"
        Me.btnVerificador.Size = New System.Drawing.Size(91, 30)
        Me.btnVerificador.TabIndex = 81
        Me.btnVerificador.Text = "Ver. Precio"
        Me.btnVerificador.ToolTipText = "Verificador de Precios"
        Me.btnVerificador.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnNota
        '
        Me.BtnNota.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNota.Icon = CType(resources.GetObject("BtnNota.Icon"), System.Drawing.Icon)
        Me.BtnNota.Location = New System.Drawing.Point(1072, 96)
        Me.BtnNota.Name = "BtnNota"
        Me.BtnNota.Size = New System.Drawing.Size(91, 30)
        Me.BtnNota.TabIndex = 82
        Me.BtnNota.Text = "Nota"
        Me.BtnNota.ToolTipText = "Agregar nota a la venta seleccionada"
        Me.BtnNota.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCerrar.Icon = CType(resources.GetObject("BtnCerrar.Icon"), System.Drawing.Icon)
        Me.BtnCerrar.Location = New System.Drawing.Point(1072, 62)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(91, 30)
        Me.BtnCerrar.TabIndex = 80
        Me.BtnCerrar.Text = "Cerrar"
        Me.BtnCerrar.ToolTipText = "Cerrar Caja"
        Me.BtnCerrar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnActCxC
        '
        Me.btnActCxC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActCxC.Icon = CType(resources.GetObject("btnActCxC.Icon"), System.Drawing.Icon)
        Me.btnActCxC.Location = New System.Drawing.Point(1021, 11)
        Me.btnActCxC.Name = "btnActCxC"
        Me.btnActCxC.Size = New System.Drawing.Size(126, 21)
        Me.btnActCxC.TabIndex = 51
        Me.btnActCxC.Text = "Actualizar"
        Me.btnActCxC.ToolTipText = "Actualizar"
        Me.btnActCxC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmTCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1167, 564)
        Me.Controls.Add(Me.BtnNota)
        Me.Controls.Add(Me.btnVerificador)
        Me.Controls.Add(Me.BtnCerrar)
        Me.Controls.Add(Me.BtnGlobal)
        Me.Controls.Add(Me.LblTipoCambio)
        Me.Controls.Add(Me.btnCorte)
        Me.Controls.Add(Me.btnAcumulado)
        Me.Controls.Add(Me.btnReenvio)
        Me.Controls.Add(Me.btnBonificacion)
        Me.Controls.Add(Me.btnMasiva)
        Me.Controls.Add(Me.btnReembolso)
        Me.Controls.Add(Me.BtnConsultar)
        Me.Controls.Add(Me.btnNotaCargo)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.UiTab1)
        Me.Controls.Add(Me.BtnComision)
        Me.Controls.Add(Me.BtnReimpresion)
        Me.Controls.Add(Me.BtnAuditoria)
        Me.Controls.Add(Me.BtnCambio)
        Me.Controls.Add(Me.BtnApartados)
        Me.Controls.Add(Me.BtnRetiro)
        Me.Controls.Add(Me.BtnNC)
        Me.Controls.Add(Me.BtnFacturar)
        Me.Controls.Add(Me.BtnPago)
        Me.Controls.Add(Me.BtnRecibo)
        Me.Controls.Add(Me.BtnDevolucion)
        Me.Controls.Add(Me.BtnCancelar)
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
        Me.UiTabCXC.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridCreditos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabAnticipos.ResumeLayout(False)
        Me.GrpAnticipos.ResumeLayout(False)
        CType(Me.GridAnticipos, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.GrpSaldos.ResumeLayout(False)
        Me.GrpSaldos.PerformLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpMetodos.ResumeLayout(False)
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
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

    Private IDCorte As String = ""
    Private Picking As Boolean = False
    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private dtCxC As DataTable
    Private TipoCambio, TipoCambiario, dSaldo, dSaldoAnticipo As Double
    Private bload As Boolean = False
    Private dtPAC, dtPendientes, dtAnticipos, dtContrarecibos, dtComplementoPago As DataTable
    Private cobranzaGeneral As Boolean = True
    Private CTEClave As String = ""
    Private sRazonSocial As String = ""
    Private MailSSL As Boolean
    Private TipoCF, Periodo, PeriodoContra, Mes, MesContra, MailPort As Integer
    Private correo As MailMessage
    Private adjuntos As Attachment
    Private autenticar As NetworkCredential
    Private envio As SmtpClient
    Private dato As FileStream
    Private Moneda, MonedaCambio, MonedaDesc, MonedaRef, CTEClaveActual, CTENombreActual, PrinterInvoice, ServidorCancelacion, Autoriza, PathXML, FormatNC, FormatCargo, FormatoFactura, sPendienteSelected, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP, VersionCF, regimenFiscal As String
    Private InterfazSalida As String = ""
    Private RefCambio As String = ""
    Private iRegimenFiscal As Integer

    Private Sub TxtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
        Clock2.Stop()
    End Sub

    Private Sub TxtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyUp
        Clock2.Start()
    End Sub

    Private Sub FrmTCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        cmbComplemento.Value = Today

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

                End Select
            Next
        End With
        dtParam.Dispose()

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
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", ImpresoraFac)
        PrinterInvoice = dt.Rows(0)("Referencia")
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)
        Picking = IIf(dt.Rows(0)("Picking").GetType.Name = "DBNull", False, dt.Rows(0)("Picking"))

        If Picking = True Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", PRNClavePic)
            PRNClavePic = dt.Rows(0)("Referencia")
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

        If Manual = 1 AndAlso IDCorte <> "" Then

            Dim ac As New FrmCerrarCaja
            ac.TxtLeyenda.Text = "La caja se encuentra abierta desde el " & sFechaApertura
            ac.StartPosition = FormStartPosition.CenterScreen
            ac.Transferencia = Transferencia
            ac.ShowDialog()
            If ac.DialogResult = System.Windows.Forms.DialogResult.OK AndAlso ac.Accion = "Corte" Then

                If Transferencia = 1 Then
                    Dim bTransBanco As Boolean = False
                    Do
                        Dim a As New FrmTransBanco
                        a.IdCorte = IDCorte
                        a.CAJClave = CAJClave
                        a.ShowDialog()
                        If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                            bTransBanco = True
                        Else
                            If a.iTransBanco = 0 Then
                                bTransBanco = True
                            End If
                        End If

                    Loop While bTransBanco = False
                Else
                    If CorteDetallado = 1 Then
                        Dim a As New FrmAperturaCaja
                        a.reciboTicket = Me.reciboTicket
                        a.Accion = "Apertura"
                        a.IDCorte = IDCorte
                        a.CAJClave = CAJClave
                        a.Cajon = Cajon
                        a.Generic = PrintGeneric
                        a.Recibo = Recibo
                        a.Impresora = Impresora
                        a.ShowDialog()
                    Else
                        Dim a As New FrmAperturaSimple
                        a.reciboTicket = Me.reciboTicket
                        a.Accion = "Apertura"
                        a.IDCorte = IDCorte
                        a.CAJClave = CAJClave
                        a.Cajon = Cajon
                        a.Generic = PrintGeneric
                        a.Recibo = Recibo
                        a.Impresora = Impresora
                        a.ShowDialog()
                    End If

                End If
            ElseIf ac.Accion = "PreCorte" Then
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
                            OpenReport.PrintPreview("Acumulado", "CRAcumula.rpt", pvtaDataSet, "")
                        End If
                    End If


                    Select Case MessageBox.Show(sPrintMessage, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.No
                            StopPrint = True
                    End Select

                Loop While Not StopPrint
            ElseIf ac.Accion = "" Then
                Me.Close()
            End If
        Else
            If Transferencia = 1 AndAlso IDCorte <> "" Then
                Dim bTransBanco As Boolean = False
                Do
                    Dim a As New FrmTransBanco
                    a.IdCorte = IDCorte
                    a.CAJClave = CAJClave
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        bTransBanco = True
                    Else
                        If a.iTransBanco = 0 Then
                            bTransBanco = True
                        End If
                    End If

                Loop While bTransBanco = False
            Else
                If CorteDetallado = 1 Then
                    Dim a As New FrmAperturaCaja
                    a.reciboTicket = Me.reciboTicket
                    a.Accion = "Apertura"
                    a.IDCorte = IDCorte
                    a.CAJClave = CAJClave
                    a.Cajon = Cajon
                    a.Generic = PrintGeneric
                    a.Recibo = Recibo
                    a.Impresora = Impresora
                    a.ShowDialog()
                Else
                    Dim a As New FrmAperturaSimple
                    a.reciboTicket = Me.reciboTicket
                    a.Accion = "Apertura"
                    a.IDCorte = IDCorte
                    a.CAJClave = CAJClave
                    a.Cajon = Cajon
                    a.Generic = PrintGeneric
                    a.Recibo = Recibo
                    a.Impresora = Impresora
                    a.ShowDialog()
                End If

            End If
        End If


        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
        TipoCambiario = dt.Rows(0)("TipoCambio")
        RefCambio = dt.Rows(0)("Referencia")
        dt.Dispose()

        If CInt(TipoCambiario) <> 1 Then
            LblTipoCambio.Text = "T.C. " & Format(CStr(ModPOS.Redondear(TipoCambiario, 2)), "Currency")
            lblMonedaCambio.Text = Format(CStr(Redondear(dSaldo / TipoCambiario, 2)), "Currency")
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


        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2


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
                        BtnApartados.Visible = CBool(Bloqueo.Split("|")(i))
                    Case Is = 3
                        BtnComision.Visible = CBool(Bloqueo.Split("|")(i))
                    Case Is = 4
                        BtnDevolucion.Visible = CBool(Bloqueo.Split("|")(i))


                    Case Is = 5
                        btnBonificacion.Visible = CBool(Bloqueo.Split("|")(i))
                    Case Is = 6
                        btnNotaCargo.Visible = CBool(Bloqueo.Split("|")(i))
                    Case Is = 7
                        btnMasiva.Visible = CBool(Bloqueo.Split("|")(i))
                    Case Is = 8
                        BtnGlobal.Visible = CBool(Bloqueo.Split("|")(i))
                End Select
            Next
        End If


        If muestraNotas = 0 Then
            BtnNota.Visible = False
        End If

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

                dtCxC = ModPOS.Recupera_Tabla("sp_recupera_cxc", "@Folio", TxtFolio.Text.Trim.ToUpper.Replace("'", "''"), "@Periodo", Periodo, "@Mes", Mes, "@Tipo", cmbTipoTrans.SelectedValue, "@COMClave", ModPOS.CompanyActual, "@Cobrados", chkIncluir.Checked)
                GridCxC.DataSource = dtCxC
                GridCxC.RetrieveStructure()
                GridCxC.AutoSizeColumns()

                GridCxC.RootTable.Columns("ID").Visible = False
                GridCxC.CurrentTable.Columns("TipoDocumento").Visible = False
                GridCxC.CurrentTable.Columns("CTEClave").Visible = False
                GridCxC.CurrentTable.Columns("DevTipo").Visible = False
                GridCxC.CurrentTable.Columns("TipoCF").Visible = False
                GridCxC.CurrentTable.Columns("Email").Visible = False
                GridCxC.CurrentTable.Columns("TipoNC").Visible = False
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
                GridCxC.CurrentTable.Columns("dSaldo").Visible = False
                dSaldo = 0
                Me.LblSaldo.Text = Format(CStr(ModPOS.Redondear(dSaldo, 2)), "Currency")

                lblMonedaCambio.Text = RefCambio & " " & Format("0.00", "Currency")
                ChkMarcaTodos.Enabled = True

            Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Public Function imprimeRecibo(ByVal dtAbono As DataTable, ByVal Importe As Double, ByVal Cambio As Double, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String, ByVal Usu As String, ByVal Cte As String, ByVal Nombre As String, ByVal Nota As String) As Boolean
        Dim dTotalPagos, dPagos As Double
        Dim i As Integer
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

            For i = 0 To dtHeadTicket.Rows.Count - 1
                Tickets.AddHeaderLine(CStr(dtHeadTicket.Rows(i)("Texto")), Math.Abs(CInt(dtHeadTicket.Rows(i)("Negrita"))), CInt(dtHeadTicket.Rows(i)("Alinear")))
            Next
            dtHeadTicket.Dispose()
        End If


        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 


        Tickets.AddHeaderLine(" ", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine("RECIBO", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine("LE ATENDIO: " & Usu, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine(DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToShortTimeString(), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)

        Tickets.AddHeaderLine("CTE: " & Cte, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine(Nombre, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)


        Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        Dim Ref As String = ""

        Tickets.AddSubHeaderBloqLine("METODOS DE PAGO:", 0, 1)
        For i = 0 To dtAbono.Rows.Count - 1
            Tickets.AddSubHeaderBloqLine(dtAbono.Rows(i)("Metodo") & " " & Strings.Format(TruncateToDecimal(dtAbono.Rows(i)("Monto"), 2).ToString, "Currency"), 0, 1)

            If dtAbono.Rows(i)("Banco").GetType.ToString <> "System.DBNull" AndAlso dtAbono.Rows(i)("Banco") <> "" Then
                Tickets.AddSubHeaderBloqLine("BANCO: " & dtAbono.Rows(i)("Banco"), 0, 1)
            End If

            Ref = ""
            If dtAbono.Rows(i)("Ref") <> "" Then
                Ref &= dtAbono.Rows(i)("Ref")
            End If

            If dtAbono.Rows(i)("NumCta") <> "" Then
                Ref &= "," & dtAbono.Rows(i)("NumCta")
            End If


            If Ref <> "" Then
                Tickets.AddSubHeaderBloqLine("REF: " & Ref, 0, 1)
            End If
        Next

        If Nota <> "" Then
            Tickets.AddSubHeaderBloqLine("NOTA: " & Nota, 0, 1)
        End If
        '        Tickets.AddSubHeaderBloqLine("IMPORTE: " & Format(CStr(ModPOS.Redondear(Importe, 2)), "Currency"), 0, 1)

        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
        'del producto y el tercero es el precio 
        Dim dtPagosDetalle As DataTable
        For i = 0 To dtAbono.Rows.Count - 1
            dtPagosDetalle = ModPOS.SiExisteRecupera("sp_recibo_detalle", "@ABNClave", dtAbono.Rows(i)("ABNClave"))

            If Not dtPagosDetalle Is Nothing Then
                Dim j As Integer
                dPagos = dtPagosDetalle.Rows.Count()
                For j = 0 To dPagos - 1
                    Dim sFolio As String = dtPagosDetalle.Rows(j)("Tipo")
                    Dim sTipo As String = dtPagosDetalle.Rows(j)("Folio")
                    Dim dImporte As Double = dtPagosDetalle.Rows(j)("Importe")


                    ' AGREGAR PAGOS A LISTA
                    Tickets.AddItemRecibo(sFolio, sTipo, dImporte)

                    dTotalPagos += (dImporte)
                Next
                dtPagosDetalle.Dispose()

            End If
        Next

        'El metodo AddTotalRecibo requiere 4 parametros 
        Tickets.AddTotalRecibo(dTotalPagos, Importe, Cambio, Imprimir.FontEstilo.Negrita)

        'El metodo AddFooterLine funciona igual que la cabecera 

        Dim dtPieTicket As DataTable
        dtPieTicket = ModPOS.SiExisteRecupera("sp_filtra_pie", "@TIKClave", Ticket)

        If Not dtPieTicket Is Nothing Then

            For i = 0 To dtPieTicket.Rows.Count - 1
                Tickets.AddFooterLine(CStr(dtPieTicket.Rows(i)("Texto")), Math.Abs(CInt(dtPieTicket.Rows(i)("Negrita"))), CInt(dtPieTicket.Rows(i)("Alinear")))
            Next
            dtPieTicket.Dispose()
        End If

        'Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        'parametro de tipo string que debe de ser el nombre de la impresora. 
        Tickets.PrintTicket(Impresora, 70, 0)

    End Function

    Private Sub FrmTCaja_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

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

        If Manual = 1 AndAlso IDCorte <> "" Then
            Dim ac As New FrmCerrarCaja
            ac.TxtLeyenda.Text = "La caja se encuentra abierta desde el " & sFechaApertura
            ac.StartPosition = FormStartPosition.CenterScreen
            ac.Transferencia = Transferencia
            ac.ShowDialog()
            If ac.DialogResult = System.Windows.Forms.DialogResult.OK AndAlso ac.Accion = "Corte" Then

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
                    Dim bTransBanco As Boolean = False
                    Do
                        Dim a As New FrmTransBanco
                        a.InterfazSalida = InterfazSalida
                        a.IdCorte = IDCorte
                        a.CAJClave = CAJClave
                        a.ShowDialog()
                        If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                            bTransBanco = True
                        Else
                            If a.iTransBanco = 0 Then
                                bTransBanco = True
                            End If
                        End If

                    Loop While bTransBanco = False
                Else

                    If CorteDetallado = 1 Then
                        Dim a As New FrmAperturaCaja
                        a.reciboTicket = Me.reciboTicket
                        a.LBTitulo.Text = "Corte de Caja al Cierre"
                        a.Accion = "Cierre"
                        a.CAJClave = CAJClave
                        a.Impresora = Impresora
                        a.Generic = PrintGeneric
                        a.Recibo = Recibo
                        a.IDCorte = IDCorte
                        a.BtnCancelar.Visible = True
                        a.Cajon = Cajon
                        a.ShowDialog()
                        If a.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                            e.Cancel = True
                            Exit Sub
                        End If
                    Else
                        Dim a As New FrmAperturaSimple
                        a.reciboTicket = Me.reciboTicket
                        a.LBTitulo.Text = "Corte de Caja al Cierre"
                        a.Accion = "Cierre"
                        a.CAJClave = CAJClave
                        a.Impresora = Impresora
                        a.Generic = PrintGeneric
                        a.Recibo = Recibo
                        a.IDCorte = IDCorte
                        a.BtnCancelar.Visible = True
                        a.Cajon = Cajon
                        a.ShowDialog()
                        If a.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If

                End If

            ElseIf ac.Accion = "PreCorte" Then
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
                Dim bTransBanco As Boolean = False
                Do
                    Dim a As New FrmTransBanco
                    a.InterfazSalida = InterfazSalida
                    a.IdCorte = IDCorte
                    a.CAJClave = CAJClave
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        bTransBanco = True
                    Else
                        If a.iTransBanco = 0 Then
                            bTransBanco = True
                        End If
                    End If

                Loop While bTransBanco = False
            Else
                If CorteDetallado = 1 Then
                    Dim a As New FrmAperturaCaja
                    a.reciboTicket = Me.reciboTicket
                    a.LBTitulo.Text = "Corte de Caja al Cierre"
                    a.Accion = "Cierre"
                    a.CAJClave = CAJClave
                    a.Impresora = Impresora
                    a.Generic = PrintGeneric
                    a.Recibo = Recibo
                    a.IDCorte = IDCorte
                    a.BtnCancelar.Visible = True
                    a.Cajon = Cajon
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    Dim a As New FrmAperturaSimple
                    a.reciboTicket = Me.reciboTicket
                    a.LBTitulo.Text = "Corte de Caja al Cierre"
                    a.Accion = "Cierre"
                    a.CAJClave = CAJClave
                    a.Impresora = Impresora
                    a.Generic = PrintGeneric
                    a.Recibo = Recibo
                    a.IDCorte = IDCorte
                    a.BtnCancelar.Visible = True
                    a.Cajon = Cajon
                    a.ShowDialog()
                    If a.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                        e.Cancel = True
                        Exit Sub
                    End If
                End If

            End If
        End If

        ModPOS.Ejecuta("sp_act_caja", "@CAJClave", CAJClave, "@Fase", 0)

        ModPOS.MtoCXC.Dispose()
        ModPOS.MtoCXC = Nothing
    End Sub


    Private Sub BtnPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPago.Click
        If cobranzaGeneral Then
            If Not dtCxC Is Nothing Then

                Dim foundRows() As DataRow

                foundRows = dtCxC.Select("Marca ='True' and Saldo > 0")

                If foundRows.GetLength(0) > 0 Then

                    Dim fr() As DataRow
                    fr = dtCxC.Select("Marca ='True' AND Saldo > 0 and CTEClave <> '" & foundRows(0)("CTEClave") & "'")

                    If fr.GetLength(0) >= 1 Then
                        MessageBox.Show("No es posible realizar pagos de diferentes clientes a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If


                    

                    Dim dtDoctos, dtAbnSaldo As DataTable
                    dtDoctos = foundRows.CopyToDataTable()


                    dtAbnSaldo = Recupera_Tabla("sp_aplicar_abn", "@CTEClave", dtDoctos.Rows(0)("CTEClave"))
                    If dtAbnSaldo.Rows.Count > 0 Then

                        Dim b As New FrmAbnPendiente
                        b.Abonos = dtAbnSaldo
                        b.SaldoDocumento = dSaldo
                        b.ShowDialog()

                        If b.DialogResult = DialogResult.OK Then
                            If Not b.drAbonos Is Nothing AndAlso b.drAbonos.Length > 0 Then
                                Dim i As Integer
                                For i = 0 To b.drAbonos.Length - 1
                                    ModPOS.Aplica_Pagos(dtDoctos, foundRows(0)("CTEClave"), b.drAbonos(i)("ID"), b.drAbonos(i)("TipoPago"), b.drAbonos(i)("Saldo"), CAJClave, b.drAbonos(i)("Tipo"))
                                Next

                            End If
                        End If
                    End If
                    dtAbnSaldo.Dispose()

                    Dim SaldoDoctos As Decimal = IIf(dtDoctos.Compute("Sum(Saldo)", "Saldo > 0") Is System.DBNull.Value, 0, dtDoctos.Compute("Sum(Saldo)", "Saldo > 0"))

                    If SaldoDoctos > 0 Then
                        Dim a As New FrmAbono
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
                        a.ShowDialog()

                        If a.DialogResult = DialogResult.OK Then
                            If a.detallePago.Rows.Count > 0 Then

                                Dim i As Integer
                                Dim sFolio, sFecha As String
                                Dim dtInterfaz As DataTable = Nothing

                                If InterfazSalida <> "" AndAlso (dtDoctos.Rows(0)("TipoDocumento") = 2 OrElse dtDoctos.Rows(0)("TipoDocumento") = 6) Then
                                    dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Cobros", "@COMClave", ModPOS.CompanyActual)
                                End If

                                For i = 0 To a.detallePago.Rows.Count - 1

                                    ModPOS.Aplica_Pagos(dtDoctos, dtDoctos.Rows(0)("CTEClave"), a.detallePago.Rows(i)("ABNClave"), a.detallePago.Rows(i)("TipoPago"), a.detallePago.Rows(i)("Saldo"), CAJClave, 1)

                                    If InterfazSalida <> "" AndAlso (dtDoctos.Rows(0)("TipoDocumento") = 2 OrElse dtDoctos.Rows(0)("TipoDocumento") = 6) Then
                                        sFolio = a.detallePago.Rows(i)("ABNClave")
                                        sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")
                                        If Not dtInterfaz Is Nothing AndAlso dtInterfaz.Rows.Count > 0 Then
                                            ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sFolio, "@TipoDocumento", a.detallePago.Rows(i)("TipoPago"), "@Path", InterfazSalida, "@Fecha", sFecha, "@Tipo", CInt(dtDoctos.Rows(0)("TipoDocumento")))
                                        End If
                                    End If

                                Next

                                If a.TotalAbono > 0 Then

                                    Dim msg As New FrmMeMsg
                                    msg.TxtTiulo = "Su Cambio es:"
                                    msg.TxtMsg = Format(CStr(Math.Round(a.TotalCambio, 2)), "Currency")
                                    msg.TxtMsg2 = Letras(CStr(Math.Round(a.TotalCambio, 2))).ToUpper
                                    msg.ShowDialog()
                                    msg.Dispose()


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


                                End If

                                dtCxC.Dispose()
                                AgregarFolio()
                                RetiroProgramado()
                            End If

                        End If
                    Else
                        dtCxC.Dispose()
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
            Dim MontoEfectivo As Double

            If dt.Rows.Count > 0 Then
                MontoEfectivo = CDbl(dt.Rows(0)("Efectivo"))

                If MontoEfectivo > MaxEfectivo Then
                    MessageBox.Show("El monto de fectivo maximo recomendado (" & Strings.Format(Redondear(MaxEfectivo, 2).ToString, "Currency") & ") se ha excedido. Le recordamos realizar el retiro de fectivo de caja", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If
            dt.Dispose()
        End If



        'If LEfectivo > 0 OrElse LCheques > 0 OrElse LVales > 0 Then
        '    Dim dt As DataTable
        '    dt = SiExisteRecupera("sp_limite_caja", "@CAJClave", CAJClave, "@Fecha", Today)
        '    Dim bRetirar As Boolean = False
        '    Dim MontoEfectivo, MontoCheques, MontoVales As Double
        '    Dim retiroEfectivo, retiroCheques, retiroVales As Double
        '    Dim aperturaEfectivo, aperturaCheques, aperturaVales As Double

        '    If Not dt Is Nothing Then
        '        Dim fila As Integer
        '        For fila = 0 To dt.Rows.Count - 1
        '            Select Case CInt(dt.Rows(fila)("TipoPago"))
        '                Case Is = 1
        '                    If LEfectivo < (CDbl(dt.Rows(fila)("Monto")) - CDbl(dt.Rows(fila)("Retiro"))) Then
        '                        MontoEfectivo = CDbl(dt.Rows(fila)("Monto"))
        '                        retiroEfectivo = CDbl(dt.Rows(fila)("Retiro"))
        '                        aperturaEfectivo = CDbl(dt.Rows(fila)("Apertura"))

        '                        bRetirar = True

        '                    End If
        '                Case Is = 2
        '                    If LCheques < (CDbl(dt.Rows(fila)("Monto")) - CDbl(dt.Rows(fila)("Retiro"))) Then
        '                        MontoCheques = CDbl(dt.Rows(fila)("Monto"))
        '                        retiroCheques = CDbl(dt.Rows(fila)("Retiro"))
        '                        aperturaCheques = CDbl(dt.Rows(fila)("Apertura"))

        '                        bRetirar = True

        '                    End If
        '                Case Is = 4
        '                    If LVales < (CDbl(dt.Rows(fila)("Monto")) - CDbl(dt.Rows(fila)("Retiro"))) Then
        '                        MontoVales = CDbl(dt.Rows(fila)("Monto"))
        '                        retiroVales = CDbl(dt.Rows(fila)("Retiro"))
        '                        aperturaVales = CDbl(dt.Rows(fila)("Apertura"))
        '                        bRetirar = True

        '                    End If
        '            End Select
        '        Next
        '        If bRetirar Then
        '            Dim a As New FrmRetiroCaja
        '            a.SUCClave = SUCClave
        '            a.ALMClave = ALMClave
        '            a.CAJClave = CAJClave
        '            a.Impresora = Impresora
        '            a.Generic = PrintGeneric
        '            a.Ticket = Recibo
        '            a.Cajon = Cajon
        '            a.MontoEfectivo = MontoEfectivo + aperturaEfectivo
        '            a.MontoCheques = MontoCheques + aperturaCheques
        '            a.MontoVales = MontoVales + aperturaVales
        '            a.retiroEfectivo = retiroEfectivo
        '            a.retiroCheques = retiroCheques
        '            a.retiroVales = retiroVales
        '            a.ShowDialog()
        '        End If
        '    End If
        'End If

    End Sub

    Private Sub PagoCreditos()
        If CTEClave <> "" Then
            Dim a As New FrmPagoCXC
            a.CAJClave = CAJClave
            a.Cajon = Cajon
            a.sCTEClave = Me.CTEClave
            a.sRazonSocial = Me.sRazonSocial
            a.Impresora = Me.Impresora
            a.SUCClave = Me.SUCClave
            a.FormatoFactura = Me.FormatoFactura
            a.ShowDialog()
            a.Dispose()
        End If
    End Sub

    Private Sub imprimirRecibo(ByVal Abono As String)
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_rec", "@ABNClave", Abono))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_rec", "@ABNClave", Abono))
        OpenReport.PrintPreview("Recibo", "CRRecibo.rpt", pvtaDataSet, "")
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
        GridPendientes.RootTable.Columns("Moneda").Visible = False
        GridPendientes.RootTable.Columns("TipoCambio").Visible = False
        GridPendientes.RootTable.Columns("TipoCF").Visible = False
        GridPendientes.RootTable.Columns("Estado").Visible = False
        GridPendientes.RootTable.Columns("Impuesto").Visible = False


        GridPendientes.AutoSizeColumns()
        Cursor.Current = Cursors.Default
    End Sub

    Public Sub actualizaAnticipos()
        Cursor.Current = Cursors.WaitCursor
        dtAnticipos = ModPOS.Recupera_Tabla("sp_busca_abonos_pendientes", "@SUCClave", SUCClave)
        GridAnticipos.DataSource = dtAnticipos
        GridAnticipos.RetrieveStructure(True)
        GridAnticipos.RootTable.Columns("ABNClave").Visible = False
        'GridAnticipos.CurrentTable.Columns("Clave").Selectable = False
        'GridAnticipos.CurrentTable.Columns("RFC").Selectable = False
        'GridAnticipos.CurrentTable.Columns("Razón Social").Selectable = False
        'GridAnticipos.CurrentTable.Columns("Fecha").Selectable = False
        'GridAnticipos.CurrentTable.Columns("Forma de Pago").Selectable = False
        'GridAnticipos.CurrentTable.Columns("Importe").Selectable = False
        'GridAnticipos.CurrentTable.Columns("Saldo").Selectable = False
        'GridAnticipos.CurrentTable.Columns("Nota").Selectable = False
        GridAnticipos.AutoSizeColumns()
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
        Dim fechaPago As Date
        fechaPago = cmbComplemento.Value.Date
        Cursor.Current = Cursors.WaitCursor
        dtComplementoPago = ModPOS.Recupera_Tabla("st_recupera_complementoPago", "@Inicio", fechaPago, "@Fin", fechaPago.AddHours(23.9999), "@COMClave", ModPOS.CompanyActual)
        gridComplementoPago.DataSource = dtComplementoPago
        gridComplementoPago.RetrieveStructure(True)
        gridComplementoPago.RootTable.Columns("ABNClave").Visible = False
        gridComplementoPago.RootTable.Columns("email").Visible = False
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
                    If foundRows(0)(6) <> foundRows(0)(7) Then
                        MessageBox.Show("EL documento con Folio " & foundRows(0)(2) & " no es posible cancelarlo porque tiene pagos aplicados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If

                If foundRows(0)("TipoDocumento") = 4 Then
                    MessageBox.Show("No es posible cancelar este tipo de documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Select Case MessageBox.Show("¿Esta seguro de Cancelar el documento " & foundRows(0)(2) & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        Dim a As New MeAutorizacion

                        a.Sucursal = SUCClave
                        a.MontodeAutorizacion = foundRows(0)(6)
                        a.StartPosition = FormStartPosition.CenterScreen
                        a.ShowDialog()
                        If a.DialogResult = DialogResult.OK Then
                            If a.Autorizado Then
                                Autoriza = a.Autoriza

                                Dim dt As DataTable
                                Dim TipoCF As Integer
                                Dim uuid, rfc As String
                                Dim estado As Integer
                                Dim sVersionCF As String

                                If foundRows(0)("TipoDocumento") = 1 Then 'Venta

                                    dt = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", foundRows(0)(0))
                                    If dt.Rows.Count > 0 Then
                                        If dt.Rows(0)("Estado") = 4 Then
                                            MessageBox.Show("El pedido seleccionado fue cancelado previamente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            AgregarFolio()
                                            Exit Sub
                                        End If
                                    End If

                                    Do
                                        Dim m As New FrmMotivo
                                        m.Tabla = "Venta"
                                        m.Campo = "Cancelacion"
                                        m.ShowDialog()
                                        If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                            bmotivo = True
                                            motCancelacion = m.Motivo
                                        End If
                                        m.Dispose()
                                    Loop While bmotivo = False

                                    ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", foundRows(0)(0), "@TipoDoc", foundRows(0)("TipoDocumento"), "@Motivo", motCancelacion, "@Autoriza", Autoriza)

                                    ModPOS.GeneraMovInv(1, 5, 1, foundRows(0)(0), ALMClave, foundRows(0)(2), Autoriza)
                                    ModPOS.ActualizaExistAlm(1, 1, foundRows(0)(0), ALMClave)
                                    If StageCancelacion <> "" Then
                                        ModPOS.ActualizaExistUbc(1, 1, foundRows(0)(0), ALMClave, StageCancelacion)
                                    Else
                                        ModPOS.ActualizaExistUbc(1, 1, foundRows(0)(0), ALMClave)
                                    End If
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))

                                    ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(0)(0), "@Tipo", 1)

                                ElseIf foundRows(0)("TipoDocumento") = 2 Then 'Factura

                                    Do
                                        Dim m As New FrmMotivo
                                        m.Tabla = "Factura"
                                        m.Campo = "Cancelacion"
                                        m.ShowDialog()
                                        If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                            bmotivo = True
                                            motCancelacion = m.Motivo
                                        End If
                                        m.Dispose()
                                    Loop While bmotivo = False


                                    dt = Recupera_Tabla("sp_recupera_fac", "@FACClave", foundRows(0)(0))
                                    TipoCF = dt.Rows(0)("TipoCF")
                                    uuid = dt.Rows(0)("UUID")
                                    rfc = dt.Rows(0)("id_Fiscal")
                                    estado = dt.Rows(0)("estado")
                                    sVersionCF = dt.Rows(0)("VersionCF")
                                    dt.Dispose()


                                    If TipoCF = 2 AndAlso estado = 1 Then

                                        If foundRows(0)(6) <> foundRows(0)(7) Then
                                            MessageBox.Show("EL documento con Folio " & foundRows(0)(2) & " no es posible cancelarlo porque tiene pagos aplicados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Exit Sub
                                        End If

                                        Dim eRFC, sFolio As String
                                        dt = ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", foundRows(0)(0))
                                        eRFC = dt.Rows(0)("cRFC")
                                        sFolio = dt.Rows(0)("Serie") & dt.Rows(0)("Folio")

                                        dt.Dispose()

                                        If ModPOS.cancelarXML(dtPAC, sFolio, uuid, eRFC, sVersionCF) = False Then
                                            Exit Sub
                                        End If

                                    End If

                                    ModPOS.Ejecuta("sp_cancela_factura", "@FACClave", foundRows(0)(0), "@Motivo", motCancelacion, "@Autoriza", Autoriza)

                                    ModPOS.GeneraMovInv(1, 5, 2, foundRows(0)(0), ALMClave, foundRows(0)(2), Autoriza)
                                    ModPOS.ActualizaExistAlm(1, 2, foundRows(0)(0), ALMClave)

                                    If StageCancelacion <> "" Then
                                        ModPOS.ActualizaExistUbc(1, 2, foundRows(0)(0), ALMClave, StageCancelacion)
                                    Else
                                        ModPOS.ActualizaExistUbc(1, 2, foundRows(0)(0), ALMClave)
                                    End If

                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))

                                    ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(0)(0), "@Tipo", 2)

                                    If TipoCF = 2 AndAlso estado <> 1 Then
                                        ModPOS.Ejecuta("sp_libera_pagos_fac", "@FACClave", foundRows(0)(0))
                                    End If

                                    If InterfazSalida <> "" Then
                                        Dim sFecha As String
                                        Dim dtInterfaz As DataTable
                                        sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                                        dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CancelacionFactura", "@COMClave", ModPOS.CompanyActual)
                                        If dtInterfaz.Rows.Count > 0 Then
                                            ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", foundRows(0)(0), "@TipoDocumento", 0, "@Path", InterfazSalida, "@Fecha", sFecha)
                                        End If

                                    End If


                                ElseIf foundRows(0)("TipoDocumento") = 3 Then 'Cargo
                                    ModPOS.Ejecuta("sp_cancela_cargo", "@CARClave", foundRows(0)(0))

                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))


                                    'ElseIf foundRows(0)("TipoDocumento") = 4 Then ' NC

                                    '    Dim bmotivo As Boolean = False
                                    '    Dim MotCancelacion As Integer
                                    '    Do
                                    '        Dim m As New FrmMotivo
                                    '        m.Tabla = "NC"
                                    '        m.Campo = "Cancelacion"
                                    '        m.ShowDialog()
                                    '        If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                    '            bmotivo = True
                                    '            MotCancelacion = m.Motivo
                                    '        End If
                                    '        m.Dispose()
                                    '    Loop While bmotivo = False

                                    '    dt = Recupera_Tabla("sp_recupera_nc", "@NCClave", foundRows(0)(0))
                                    '    TipoCF = dt.Rows(0)("TipoCF")
                                    '    uuid = IIf(dt.Rows(0)("UUID").GetType.Name = "DBNull", "", dt.Rows(0)("UUID"))
                                    '    rfc = dt.Rows(0)("id_Fiscal")
                                    '    estado = dt.Rows(0)("estado")
                                    '    dt.Dispose()

                                    '    If TipoCF = 2 AndAlso estado = 1 Then


                                    '        Dim eRFC, sFolio As String
                                    '        dt = ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", foundRows(0)(0))
                                    '        eRFC = dt.Rows(0)("cRFC")
                                    '        sFolio = dt.Rows(0)("Serie") & dt.Rows(0)("Folio")
                                    '        dt.Dispose()

                                    '        If ModPOS.cancelarXML(dtPAC, sFolio, uuid, eRFC) = False Then
                                    '            Exit Sub
                                    '        End If

                                    '    End If

                                    '    ModPOS.Ejecuta("sp_cancela_nc", "@NCClave", foundRows(0)("ID"), "@Motivo", MotCancelacion,"@Autoriza",Autoriza)

                                    '    'Actualiza el Saldo del Documento
                                    '    ModPOS.Ejecuta("sp_act_saldo_fac", "@NCClave", foundRows(0)("ID"))
                                    '    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))

                                    '    'Si es de tipo devolución, realiza salida de producto de almacén

                                    '    If foundRows(0)("DevTipo") = 1 Then
                                    '        ModPOS.GeneraMovInv(2, 5, 4, foundRows(0)("ID"), ALMClave, foundRows(0)("Folio"), Autoriza)
                                    '        ModPOS.ActualizaExistAlm(2, 4, foundRows(0)("ID"), ALMClave)
                                    '        ModPOS.ActualizaExistUbc(2, 4, foundRows(0)("ID"), ALMClave)
                                    '    End If

                                    'ElseIf foundRows(0)("TipoDocumento") = 5 Then ' Devolución

                                    '    ModPOS.Ejecuta("sp_cancela_devolucion", "@DEVClave", foundRows(0)("ID"))

                                    '    'Actualiza el Saldo del Documento
                                    '    ModPOS.Ejecuta("sp_act_saldo_vta", "@DEVClave", foundRows(0)("ID"))
                                    '    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))

                                    '    'Si es de tipo devolución, realiza salida de producto de almacén

                                    '    ModPOS.GeneraMovInv(2, 5, 3, foundRows(0)("ID"), ALMClave, foundRows(0)("Folio"), Autoriza)
                                    '    ModPOS.ActualizaExistAlm(2, 3, foundRows(0)("ID"), ALMClave)
                                    '    ModPOS.ActualizaExistUbc(2, 3, foundRows(0)("ID"), ALMClave)

                                ElseIf foundRows(0)("TipoDocumento") = 6 Then ' Nota Cargo

                                    Do
                                        Dim m As New FrmMotivo
                                        m.Tabla = "Factura"
                                        m.Campo = "Cancelacion"
                                        m.ShowDialog()
                                        If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                            bmotivo = True
                                            motCancelacion = m.Motivo
                                        End If
                                        m.Dispose()
                                    Loop While bmotivo = False

                                    dt = Recupera_Tabla("sp_recupera_cargo", "@CARClave", foundRows(0)(0))
                                    TipoCF = dt.Rows(0)("TipoCF")
                                    uuid = IIf(dt.Rows(0)("UUID").GetType.Name = "DBNull", "", dt.Rows(0)("UUID"))
                                    rfc = dt.Rows(0)("id_Fiscal")
                                    estado = dt.Rows(0)("estado")
                                    sVersionCF = dt.Rows(0)("VersionCF")
                                    dt.Dispose()



                                    If TipoCF = 2 AndAlso estado = 1 Then

                                        If foundRows(0)(6) <> foundRows(0)(7) Then
                                            MessageBox.Show("EL documento con Folio " & foundRows(0)(2) & " no es posible cancelarlo porque tiene pagos aplicados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Exit Sub
                                        End If

                                        Dim eRFC, sFolio As String
                                        dt = ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", foundRows(0)(0))
                                        eRFC = dt.Rows(0)("cRFC")
                                        sFolio = dt.Rows(0)("Serie") & dt.Rows(0)("Folio")
                                        dt.Dispose()

                                        If ModPOS.cancelarXML(dtPAC, sFolio, uuid, eRFC, sVersionCF) = False Then
                                            Exit Sub
                                        End If

                                    End If

                                    ModPOS.Ejecuta("sp_cancela_notacargo", "@CARClave", foundRows(0)("ID"), "@Motivo", motCancelacion, "@Autoriza", Autoriza)

                                    'Actualiza el Saldo del Documento
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))

                                    If TipoCF = 2 AndAlso estado <> 1 Then
                                        ModPOS.Ejecuta("sp_libera_pagos_fac", "@FACClave", foundRows(0)(0))
                                    End If

                                    If InterfazSalida <> "" Then
                                        Dim sFecha As String
                                        Dim dtInterfaz As DataTable
                                        sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                                        dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CancelacionCargo", "@COMClave", ModPOS.CompanyActual)
                                        If dtInterfaz.Rows.Count > 0 Then
                                            ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", foundRows(0)(0), "@TipoDocumento", 0, "@Path", InterfazSalida, "@Fecha", sFecha)
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
                ModPOS.Devolucion.ActivaDevolucion = True
                ModPOS.Devolucion.ActivaCaja = True
                ModPOS.Devolucion.CAJClave = CAJClave
                ModPOS.Devolucion.Referencia = Clave
                ModPOS.Devolucion.LblUsuario.Text = MPrincipal.StUsuario.Text
                ModPOS.Devolucion.SUCClave = SUCClave
                ModPOS.Devolucion.ALMClave = ALMClave
                ModPOS.Devolucion.Impresora = Impresora
                ModPOS.Devolucion.TicketDev = TICDevolucion
                ModPOS.Devolucion.Caja = LblDescripcion.Text
                ModPOS.Devolucion.Cajon = Cajon
                ModPOS.Devolucion.Ventas = foundRows
                ModPOS.Devolucion.bLiquidacion = True
                ModPOS.Devolucion.Moneda = Moneda
            End If
            ModPOS.Devolucion.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Devolucion.ShowDialog()
        Else
            If ModPOS.Devolucion Is Nothing Then
                ModPOS.Devolucion = New FrmDevolucion
                ModPOS.Devolucion.ActivaDevolucion = True
                ModPOS.Devolucion.ActivaCaja = True
                ModPOS.Devolucion.CAJClave = CAJClave
                ModPOS.Devolucion.Referencia = Clave
                ModPOS.Devolucion.LblUsuario.Text = MPrincipal.StUsuario.Text
                ModPOS.Devolucion.SUCClave = SUCClave
                ModPOS.Devolucion.ALMClave = ALMClave
                ModPOS.Devolucion.Impresora = Impresora
                ModPOS.Devolucion.TicketDev = TICDevolucion
                ModPOS.Devolucion.Caja = LblDescripcion.Text
                ModPOS.Devolucion.Cajon = Cajon
            End If
            ModPOS.Devolucion.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Devolucion.ShowDialog()
        End If
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
            ModPOS.Factura.Show()
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
            ModPOS.Factura.Show()
            If Not ModPOS.Factura Is Nothing Then
                ModPOS.Factura.BringToFront()
            End If

        End If

    End Sub

    Private Sub BtnRecibo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecibo.Click
        Dim a As New FrmBuscaAbono
        a.ReciboTicket = reciboTicket
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If a.ABNClave <> "" Then
                If reciboTicket = 0 Then
                    imprimirRecibo(a.ABNClave)
                Else
                    imprimeRecibo(a.dtDetallePago, a.dtDetallePago.Rows(0)("Monto"), 0, Impresora, PrintGeneric, Recibo, MPrincipal.StUsuario.Text, a.dtDetallePago.Rows(0)("Cliente"), a.dtDetallePago.Rows(0)("Nombre"), a.dtDetallePago.Rows(0)("Nota"))
                End If
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub BtnNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNC.Click
        Dim foundRows() As DataRow
        foundRows = dtCxC.Select("Marca ='True'")

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
            Dim a As New FrmFiltroNC
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If a.Tipo = 1 Then


                    foundRows = dtCxC.Select("Marca ='True'")

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
                    End If

                    ModPOS.Bonificacion.StartPosition = FormStartPosition.CenterScreen
                    ModPOS.Bonificacion.Show()
                    If Not ModPOS.Bonificacion Is Nothing Then
                        ModPOS.Bonificacion.BringToFront()
                    End If
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

    Private Sub GridAnticipos_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridAnticipos.CellValueChanged

        dtAnticipos.AcceptChanges()
        GridAnticipos.Refresh()

        If dtAnticipos.Compute("Sum(Saldo)", "Marca = True") Is System.DBNull.Value Then
            dSaldoAnticipo = 0
        Else
            dSaldoAnticipo = dtAnticipos.Compute("Sum(Saldo)", "Marca = True")
        End If

        Me.LblSaldoAnticipos.Text = Format(CStr(ModPOS.Redondear(dSaldoAnticipo, 2)), "Currency")

    End Sub

    Private Sub GridAnticipos_Click(sender As Object, e As EventArgs) Handles GridAnticipos.Click
        If Not GridAnticipos.CurrentColumn Is Nothing Then
            If GridAnticipos.CurrentColumn.Caption <> "Marca" AndAlso Not GridAnticipos.GetValue("Marca") Is Nothing Then
                If GridAnticipos.GetValue("Marca") = False Then
                    GridAnticipos.SetValue("Marca", True)
                Else
                    GridAnticipos.SetValue("Marca", False)
                End If


                dtAnticipos.AcceptChanges()
                GridAnticipos.Refresh()

                If dtAnticipos.Compute("Sum(Saldo)", "Marca = True") Is System.DBNull.Value Then
                    dSaldoAnticipo = 0
                Else
                    dSaldoAnticipo = dtAnticipos.Compute("Sum(Saldo)", "Marca = True")
                End If

                Me.LblSaldoAnticipos.Text = Format(CStr(ModPOS.Redondear(dSaldoAnticipo, 2)), "Currency")


            End If
        End If
    End Sub

    Private Sub GridAnticipos_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridAnticipos.CurrentCellChanged
        If Not GridAnticipos.CurrentColumn Is Nothing Then
            If GridAnticipos.CurrentColumn.Caption = "Marca" Then
                GridAnticipos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridAnticipos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
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

    Private Sub GridCxC_ChangeUICues(sender As Object, e As UICuesEventArgs) Handles GridCxC.ChangeUICues

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

                dSaldo = ModPOS.Redondear(IIf(dtCxC.Compute("Sum(dSaldo)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(dSaldo)", "Marca = True")), 2)
                Me.LblSaldo.Text = Format(CStr(dSaldo), "Currency")
                If TipoCambiario <> 1 Then
                    If dSaldo > 0 Then
                        lblMonedaCambio.Text = RefCambio & " " & Format(CStr(Redondear(dSaldo / TipoCambiario, 2)), "Currency")
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
            a.ShowDialog()
            a.Dispose()
        ElseIf GridCxC.GetValue("TipoDocumento") = 4 Then
            Dim a As New FrmConsultaGen
            a.Text = "Detalle de Facturas incluidas en la NC"
            ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_recupera_facturasnc", "@NCClave", GridCxC.GetValue("ID"))
            a.GridConsultaGen.GroupByBoxVisible = False
            a.ShowDialog()
            a.Dispose()
        End If
    End Sub



    Private Sub Controls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, BtnPago.KeyUp, BtnCancelar.KeyUp, BtnDevolucion.KeyUp, BtnFacturar.KeyUp, BtnNC.KeyUp, BtnRecibo.KeyUp, BtnRetiro.KeyUp, BtnCambio.KeyUp, BtnAuditoria.KeyUp, BtnReimpresion.KeyUp, BtnComision.KeyUp, UiTab1.KeyUp, UiTabCXC.KeyUp, UiTabGeneral.KeyUp, GridCreditos.KeyUp, TxtFolio.KeyUp, GridPendientes.KeyUp, btnCertificar.KeyUp, btnRegenerar.KeyUp, cmbTipoTrans.KeyUp, btnCancel.KeyUp, btnAnticipo.KeyUp, GridAnticipos.KeyUp, GridContrarecibos.KeyUp, cmbEdoContrarecibo.KeyUp, dtPickerContrarecibo.KeyUp, btnEditContrarecibo.KeyUp, btnAddContrarecibo.KeyUp, btnNotaCargo.KeyUp, chkIncluir.KeyUp, btnReembolso.KeyUp, btnAcumulado.KeyUp, btnReenvio.KeyUp, btnBonificacion.KeyUp, BtnNota.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                Me.Close()
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
        Dim dt As DataTable
        dt = SiExisteRecupera("sp_limite_caja", "@CAJClave", CAJClave, "@Fecha", Today)

        Dim MontoEfectivo, MontoCheques, MontoVales As Double
        Dim retiroEfectivo, retiroCheques, retiroVales As Double
        Dim aperturaEfectivo, aperturaCheques, aperturaVales As Double

        If Not dt Is Nothing Then
            Dim fila As Integer
            For fila = 0 To dt.Rows.Count - 1
                Select Case CInt(dt.Rows(fila)("TipoPago"))
                    Case Is = 1
                        MontoEfectivo = CDbl(dt.Rows(fila)("Monto"))
                        retiroEfectivo = CDbl(dt.Rows(fila)("Retiro"))
                        aperturaEfectivo = CDbl(dt.Rows(fila)("Apertura"))

                    Case Is = 2
                        MontoCheques = CDbl(dt.Rows(fila)("Monto"))
                        retiroCheques = CDbl(dt.Rows(fila)("Retiro"))
                        aperturaCheques = CDbl(dt.Rows(fila)("Apertura"))

                    Case Is = 4
                        MontoVales = CDbl(dt.Rows(fila)("Monto"))
                        retiroVales = CDbl(dt.Rows(fila)("Retiro"))
                        aperturaVales = CDbl(dt.Rows(fila)("Apertura"))

                End Select
            Next

            Dim a As New FrmRetiroCaja
            a.SUCClave = SUCClave
            a.ALMClave = ALMClave
            a.CAJClave = CAJClave
            a.Impresora = Impresora
            a.Generic = PrintGeneric
            a.Ticket = Recibo
            a.MontoEfectivo = MontoEfectivo + aperturaEfectivo
            a.MontoCheques = MontoCheques + aperturaCheques
            a.MontoVales = MontoVales + aperturaVales
            a.retiroEfectivo = retiroEfectivo
            a.retiroCheques = retiroCheques
            a.retiroVales = retiroVales
            a.Cajon = Cajon
            a.ShowDialog()
        Else
            MessageBox.Show("No se han registrado ingresos en la caja el día actual para ser retirados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub BtnApartados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApartados.Click
        Dim a As New FrmApartado
        a.CAJClave = CAJClave
        a.SUCClave = SUCClave
        a.ALMClave = ALMClave
        a.AtiendeNombre = LblUsuario.Text
        a.Impresora = Impresora
        a.PrintGeneric = PrintGeneric
        a.Recibo = Recibo
        a.Cajon = Cajon
        a.Picking = Picking
        a.ShowDialog()
    End Sub

    Private Sub BtnCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCambio.Click

        Dim b As New FrmSolicitaCliente
        b.ClienteInicial = ""
        b.ValidaCredito = False
        b.ShowDialog()
        If b.DialogResult = DialogResult.OK Then
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
        a.ShowDialog()
        a.Dispose()

    End Sub

    Private Sub BtnAuditoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAuditoria.Click
        Dim a As New FrmAuditoria
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Dim b As New FrmConsultaGen
            b.Text = "Auditoría de Pedidos/Ventas"
            ModPOS.ActualizaGrid(False, b.GridConsultaGen, "st_muestra_auditoria", "@VENClave", a.valor)
            b.ShowDialog()
            b.Dispose()
        End If
        a.Dispose()

        'If Not dtCxC Is Nothing Then

        '    Dim foundRows() As DataRow

        '    foundRows = dtCxC.Select("Marca ='True' and TipoDocumento = 1 and Saldo > 0")

        '    If foundRows.GetLength(0) > 0 Then
        '        Dim i As Integer
        '        For i = 0 To foundRows.GetUpperBound(0)
        '            ModPOS.Ejecuta("sp_recalcula_documento", _
        '                           "@Tipo", foundRows(0)("TipoDocumento"), _
        '                           "@Documento", foundRows(0)("ID"))
        '        Next
        '    Else
        '        MessageBox.Show("Debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'End If
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
                If PrintDialog1.ShowDialog() = DialogResult.OK Then
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
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_ped", "@VENClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                        pvtaDataSet.DataSetName = "pvtaDataSet"
                        OpenReport.Print(iCopias, "CRPedido.rpt", pvtaDataSet, ModPOS.Letras(ModPOS.TruncateToDecimal(foundRows(i)("Total"), 2)).ToUpper, sImpresora)

                    Case Is = 2 'FAC
                        Dim sFormato As String
                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "F", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        sFormato = IIf(dt.Rows(0)("Formato").GetType.Name = "DBNull", "Clasico", dt.Rows(0)("Formato"))
                        sVersionCF = dt.Rows(0)("VersionCF")
                        dt.Dispose()

                        ModPOS.imprimirFactura(iTipoCF, sFormato, foundRows(i)("ID"), foundRows(i)("Total"), SUCClave, TipoCambio, MonDesc, MonRef, sImpresora, iCopias, sVersionCF)

                    Case Is = 4 'NC
                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "N", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        sVersionCF = dt.Rows(0)("VersionCF")
                        dt.Dispose()

                        ModPOS.imprimirNC(iTipoCF, FormatNC, foundRows(i)("ID"), foundRows(i)("Total"), SUCClave, TipoCambio, MonDesc, MonRef, sImpresora, iCopias, VersionCF)

                    Case Is = 5 'Devolucion

                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_dev", "@DEVClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_devolucion_det", "@DEVClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                        pvtaDataSet.DataSetName = "pvtaDataSet"
                        OpenReport.Print(iCopias, "CRDevolucion.rpt", pvtaDataSet, ModPOS.Letras(ModPOS.TruncateToDecimal(foundRows(i)("Total"), 2)).ToUpper, sImpresora)


                    Case Is = 6 'Nota de Cargo

                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "C", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        sVersionCF = dt.Rows(0)("VersionCF")
                        dt.Dispose()


                        ModPOS.imprimirCargo(FormatCargo, foundRows(i)("ID"), foundRows(i)("Total"), TipoCambio, MonDesc, MonRef, sImpresora, iCopias, sVersionCF)

                End Select

                foundRows(i)("Marca") = False
            Next
            ChkMarcaTodos.Checked = False
            chkIncluir.Checked = False

            dSaldo = ModPOS.Redondear(IIf(dtCxC.Compute("Sum(dSaldo)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(dSaldo)", "Marca = True")), 2)
            Me.LblSaldo.Text = Format(CStr(dSaldo), "Currency")



            If TipoCambiario <> 1 Then
                If dSaldo > 0 Then
                    lblMonedaCambio.Text = RefCambio & " " & Format(CStr(TruncateToDecimal(dSaldo / TipoCambiario, 2)), "Currency")
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
            Case "UiTabAnticipos"
                actualizaAnticipos()

            Case "UiTabContrarecibos"
                actualizaContrarecibos()

            Case "UiTabComplementoPago"
                actualizaComplementoPago()
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
                dSaldo = 0
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


            dSaldo = ModPOS.Redondear(IIf(dtCxC.Compute("Sum(dSaldo)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(dSaldo)", "Marca = True")), 2)
            Me.LblSaldo.Text = Format(CStr(dSaldo), "Currency")

            If TipoCambiario <> 1 Then
                If dSaldo > 0 Then
                    lblMonedaCambio.Text = RefCambio & " " & Format(CStr(Redondear(dSaldo / TipoCambiario, 2)), "Currency")
                Else
                    lblMonedaCambio.Text = RefCambio & " " & Format("0.00", "Currency")
                End If
            End If
        End If

    End Sub

    Private Sub GridCxC_CellValueChanged1(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridCxC.CellValueChanged
        dtCxC.AcceptChanges()

        GridCxC.Refresh()
        dSaldo = ModPOS.Redondear(IIf(dtCxC.Compute("Sum(dSaldo)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(dSaldo)", "Marca = True")), 2)
        Me.LblSaldo.Text = Format(CStr(dSaldo), "Currency")

        If TipoCambiario <> 1 Then
            If dSaldo > 0 Then
                lblMonedaCambio.Text = RefCambio & " " & Format(CStr(Redondear(dSaldo / TipoCambiario, 2)), "Currency")
            Else
                lblMonedaCambio.Text = RefCambio & " " & Format("0.00", "Currency")
            End If
        End If

    End Sub

    Private Sub TxtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolio.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtFolio.Text <> "" Then
                Dim foundRows() As DataRow
                foundRows = dtCxC.Select("Folio ='" & TxtFolio.Text.ToUpper & "' and Saldo > 0")
                If foundRows.GetLength(0) > 0 Then
                    foundRows(0)("Marca") = True
                    Me.BtnPago.PerformClick()
                End If
            End If
        End If
    End Sub

    Private Sub TxtFolio_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolio.KeyUp
        If TxtFolio.Text <> "" Then
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
                Case Is = (1 OrElse 2)
                    iTipoComprobante = 7
                Case Is = 6
                    iTipoComprobante = 6
            End Select

            If MessageBox.Show("¿Desea intentar Certificar el documento " & GridPendientes.GetValue("Serie") & GridPendientes.GetValue("Folio") & "?", "Pregunta", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                iTipoPAC = ModPOS.crearXML(2, dtPAC, PathXML, GridPendientes.GetValue("Serie") & GridPendientes.GetValue("Folio"), sPendienteSelected, GridPendientes.GetValue("tipoDeComprobante"), Nothing, Nothing, Nothing, iTipoComprobante, InterfazSalida)
                If iTipoPAC <> 0 Then
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
                Dim i As Integer
                Dim dt, dtConcepto, dtImpuesto, dtDetalleImpuesto, dtRetencionDet, dtRetencion As DataTable
                Dim oCFD As New CFD


                Dim foundRows() As DataRow
                foundRows = dtPendientes.Select("Clave='" & sPendienteSelected & "'")

                Dim frmStatusMessage As New frmStatus
                frmStatusMessage.Show("Regenerando Comprobantes Fiscales Digitales...")

                oCFD.TipoCF = GridPendientes.GetValue("TipoCF")

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


                oCFD.noCertificado = ""
                oCFD.Certificado64 = ""

                Dim DirArchivoPEM As String = ""


                Dim dtPAC As DataTable = Nothing
                Dim foundRows2() As DataRow

                Dim url As String = ""
                Dim UserId As String = ""
                Dim CustomerKey As String = ""

                For i = 0 To foundRows.GetUpperBound(0)

                    If foundRows(i)("TipoCF") = 2 AndAlso foundRows(i)("Estado") = 1 Then

                        'Recuperar Timbre

                        If dtPAC Is Nothing Then
                            dtPAC = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)
                            foundRows2 = dtPAC.Select("TipoPAC = 2")
                            If foundRows.GetLength(0) = 0 Then
                                MessageBox.Show("El servicio de recuperación de CFDI solo esta disponible para el el PAC iTimbre", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            Else
                                url = foundRows2(0)("ServerTimbre")
                                UserId = foundRows2(0)("UserId")
                                CustomerKey = foundRows2(0)("CustomerKey")
                            End If
                        End If
                        Dim CBB() As Byte = Nothing

                        'If oCFD.VersionCF = "3.3" Then
                        '    CBB = ModPOS.crearQR33(oCFD.eRFC, foundRows(i)("RFC"), foundRows(i)("Total"), foundRows(i)("UUID"))

                        'Else
                        CBB = ModPOS.crearQR(oCFD.eRFC, foundRows(i)("RFC"), foundRows(i)("Total"), foundRows(i)("UUID"))
                        'End If


                        ModPOS.Ejecuta("sp_actualiza_cbb", "@Tipo", foundRows(i)("TipoDeComprobante"), "@DOCClave", foundRows(i)("Clave"), "@CBB", CBB, "@TipoComprobante", foundRows(i)("tipo"))

                        Dim consulta As String = BuscarCFDiTimbre(UserId, CustomerKey, oCFD.eRFC, foundRows(i)("Serie") & foundRows(i)("Folio"), foundRows(i)("UUID"))

                        Dim content2 As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)
                        Dim peticion2 As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

                        peticion2.Method = "POST"
                        peticion2.ContentType = "application/x-www-form-urlencoded"
                        peticion2.ContentLength = content2.Length


                        Dim requestStream2 As System.IO.Stream = peticion2.GetRequestStream()

                        requestStream2.Write(content2, 0, content2.Length)
                        requestStream2.Close()

                        Dim resp2 As System.Net.HttpWebResponse = peticion2.GetResponse()
                        Dim respuesta2 As String = New System.IO.StreamReader(resp2.GetResponseStream).ReadToEnd

                        If respuesta2.Contains("error") = False Then
                            Dim respJson2 As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta2)

                            Dim jResult As Newtonsoft.Json.Linq.JArray = respJson2.Item("result").item("data")

                            Dim Elementos As Xml.XmlDocument = New Xml.XmlDocument()

                            Elementos.LoadXml(jResult.Item(0).Item("xml_data").ToString())


                            Elementos.Save(pathActual & "CFD\" & foundRows(i)("Serie") & foundRows(i)("Folio") & ".xml")
                        End If
                    Else
                        Dim bSinSello As Boolean = False
                        dt = ModPOS.Recupera_Tabla("st_recupera_uuid", "@Tipo", foundRows(i)("tipo"), "@TipoComprobante", foundRows(i)("TipoDeComprobante"), "@Clave", foundRows(i)("Clave"))
                        If dt.Rows.Count = 0 Then
                            bSinSello = True
                        End If
                        dt.Dispose()

                        ' Generar CFD
                        If bSinSello OrElse foundRows(i)("noCertificado").GetType.Name = "DBNull" Then

                            dt = ModPOS.Recupera_Tabla("sp_recupera_certificadovigente", "@COMClave", ModPOS.CompanyActual)
                            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                                foundRows(i)("noCertificado") = dt.Rows(0)("Serie")
                                dt.Dispose()

                                foundRows(i)("anoAprobacion") = Today.Year
                                foundRows(i)("noAprobacion") = "1"



                                ModPOS.Ejecuta("st_act_documento", "@Tipo", foundRows(i)("tipo"), "@TipoComprobante", foundRows(i)("TipoDeComprobante"), "@Clave", foundRows(i)("Clave"), _
                                                                           "noCertificado", foundRows(i)("noCertificado"), "anoAprobacion", foundRows(i)("anoAprobacion"), "noAprobacion", foundRows(i)("noAprobacion"))

                            End If
                        End If


                        If oCFD.noCertificado <> foundRows(i)("noCertificado") Then
                            oCFD.noCertificado = foundRows(i)("noCertificado")

                            'recuperar certificado64

                            dt = ModPOS.Recupera_Tabla("sp_recupera_cert", "@Certificado", oCFD.noCertificado)
                            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                                oCFD.LlaveFile = dt.Rows(0)("Llave")
                                oCFD.ContrasenaClave = dt.Rows(0)("Password")
                                oCFD.Certificado64 = dt.Rows(0)("Certificado")
                                dt.Dispose()
                            Else
                                MessageBox.Show("No existen certificado vigente disponible para emitir algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If

                            'Verifica que exista el path del .Key
                            Try
                                If Not System.IO.File.Exists(oCFD.LlaveFile) Then
                                    MessageBox.Show("El archivo " & oCFD.LlaveFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                End If
                            Catch ex As Exception
                            End Try


                            'Verifica que exista el path
                            Try
                                If Not System.IO.Directory.Exists("C:\SelladoDigital\") Then
                                    System.IO.Directory.CreateDirectory("C:\SelladoDigital\")
                                End If
                            Catch ex As Exception
                            End Try

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
                            DirArchivoPEM = DirSello & ".pem"

                            dir = "C:\OpenSSL\bin\openssl.exe"

                            Shell(dir & " pkcs8 -inform DER -in " & DirSello & " -passin pass:" & oCFD.ContrasenaClave & " -out " & DirArchivoPEM, AppWinStyle.Hide, True)

                        End If

                        'Carga datos Receptor

                        dt = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", foundRows(i)("Cliente"))

                        oCFD.CTEClave = dt.Rows(0)("CTEClave")
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


                        If oCFD.Referencia = "" Then
                            oCFD.Referencia = "SIN REFERENCIA"
                        End If

                        If oCFD.noInterior <> "" Then
                            oCFD.brnoInterior = True
                        Else
                            oCFD.brnoInterior = False
                        End If

                        dt.Dispose()


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

                        End If

                        'Fin receptor

                        oCFD.VersionCF = foundRows(i)("Version")
                        oCFD.regimenFiscal = foundRows(i)("RegimenFiscal")
                        oCFD.Serie = foundRows(i)("Serie")
                        oCFD.Folio = foundRows(i)("Folio")
                        oCFD.descuento = foundRows(i)("Descuento")
                        oCFD.anoAprobacion = foundRows(i)("anoAprobacion")
                        oCFD.noAprobacion = foundRows(i)("noAprobacion")
                        oCFD.tipoDeComprobante = foundRows(i)("tipoDeComprobante")
                        oCFD.formaDePago = foundRows(i)("formaDePago")
                        oCFD.UsoCFDI = foundRows(i)("UsoCFDI")
                        'oCFD.metodoDePago = foundRows(i)("metodoPago")

                        Dim dtMetodoPagos As DataTable
                        dtMetodoPagos = ModPOS.Recupera_Tabla("sp_obtener_metodopago", "@Tipo", foundRows(i)("tipo"), "@TipoComprobante", foundRows(i)("TipoDeComprobante"), "@Clave", foundRows(i)("Clave"))

                        oCFD.metodoDePago = ""
                        oCFD.NumCtaPago = ""

                        If dtMetodoPagos.Rows.Count > 0 Then

                            Dim j As Integer
                            For j = 0 To dtMetodoPagos.Rows.Count - 1

                                If j > 0 Then
                                    oCFD.metodoDePago &= ","

                                    If oCFD.NumCtaPago <> "" AndAlso dtMetodoPagos.Rows(j)("Referencia") <> "" Then
                                        oCFD.NumCtaPago &= ","
                                    End If
                                End If

                                oCFD.metodoDePago &= CStr(dtMetodoPagos.Rows(j)("ClaveSAT"))

                                'If dtMetodoPagos.Rows(j)("Banco") <> "" Then
                                '    oCFD.metodoDePago &= " " & CStr(dtMetodoPagos.Rows(j)("Banco"))
                                'End If

                                oCFD.NumCtaPago &= CStr(dtMetodoPagos.Rows(j)("Referencia"))
                            Next
                        Else
                            If oCFD.metodoDePago = "" Then
                                If oCFD.VersionCF <> "3.3" Then
                                    oCFD.metodoDePago = "Por Definir"
                                Else
                                    oCFD.metodoDePago = "99"
                                End If
                            End If
                        End If
                        '99
                        Dim horas As Long

                        horas = DateDiff(DateInterval.Hour, CDate(foundRows(i)("Fecha")), Today.Date)

                        If horas <= 72 Then
                            oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", CDate(foundRows(i)("Fecha")))
                        Else
                            If MessageBox.Show("El documento seleccionado cuenta con más de 72 hrs. ¿Desea actualizar la fecha de generacón?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                                Dim fechaActual As Date = Today.Date
                                ModPOS.Ejecuta("st_act_fecha", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", foundRows(i)("Tipo"), "@Clave", foundRows(i)("Clave"), "@Fecha", fechaActual)
                                oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", fechaActual)
                            Else
                                oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", foundRows(i)("Fecha"))
                            End If
                        End If

                        oCFD.DOCClave = foundRows(i)("Clave")


                        Dim iTipoComprobante As Integer
                        Select Case CInt(foundRows(i)("Tipo"))
                            Case Is = 0
                                iTipoComprobante = 1
                            Case Is = 1
                                iTipoComprobante = 7
                            Case Is = 2
                                iTipoComprobante = 7
                            Case Is = 6
                                iTipoComprobante = 6
                        End Select

                        If iTipoComprobante = 1 Then
                            'Verifica si el comprobante cuenta con aplicacion de anticipo
                            dt = ModPOS.Recupera_Tabla("st_obtiene_apl_anticipo", "@DOCClave", oCFD.DOCClave)
                            If dt.Rows.Count > 0 Then
                                oCFD.AplicaAnticipo = True
                            Else
                                oCFD.AplicaAnticipo = False
                            End If
                            dt.Dispose()
                        End If

                        ModPOS.Ejecuta("st_recalcula_documento", "@DOCClave", oCFD.DOCClave, "@Tipo", iTipoComprobante)

                        dt = ModPOS.Recupera_Tabla("st_recupera_comprobante", "@TipoComprobante", foundRows(i)("tipo"), "@Tipo", foundRows(i)("tipoDeComprobante"), "@Clave", foundRows(i)("Clave"))
                        oCFD.total = dt.Rows(0)("total")
                        oCFD.DiasCredito = CInt(dt.Rows(0)("diasCredito"))
                        oCFD.CondicionesDePago = IIf(oCFD.DiasCredito > 0, CStr(oCFD.DiasCredito) & " días", "")
                        dt.Dispose()

                        oCFD.Moneda = foundRows(i)("Moneda")
                        oCFD.TipoCambio = foundRows(i)("TipoCambio")
                        'Me.CargaDatosCliente(foundRows(i)("Cliente"))
                        dtConcepto = ModPOS.Recupera_Tabla("sp_recupera_elemento", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", iTipoComprobante, "@Clave", oCFD.DOCClave)
                        dtImpuesto = ModPOS.Recupera_Tabla("sp_recupera_imp_elemento", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", iTipoComprobante, "@Clave", oCFD.DOCClave)

                        If oCFD.VersionCF = "3.3" Then
                            dtDetalleImpuesto = ModPOS.Recupera_Tabla("st_recupera_impuesto_det", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", iTipoComprobante, "@Clave", oCFD.DOCClave)
                            dtRetencionDet = ModPOS.Recupera_Tabla("st_recupera_retencion_det", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", iTipoComprobante, "@Clave", oCFD.DOCClave)
                            dtRetencion = ModPOS.Recupera_Tabla("st_recupera_retenciones", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", iTipoComprobante, "@Clave", oCFD.DOCClave)

                        End If


                        If oCFD.TipoCF = 1 Then
                            oCFD.cadenaOriginal = generarCadenaOriginal(oCFD, dtConcepto, dtImpuesto)
                        Else


                            oCFD.cadenaOriginal = generarCadenaOriginalCFDI(oCFD, dtConcepto, dtImpuesto, iTipoComprobante, dtDetalleImpuesto, dtRetencionDet, dtRetencion)
                        End If

                        oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)


                        ModPOS.crearXML(3, dtPAC, pathActual & "CFD\", oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, iTipoComprobante, "", dtDetalleImpuesto, dtRetencionDet, dtRetencion)


                        ' Dim cadenaOriginal As String = generarCadenaOriginal(Fecha)
                        'Dim selloDigital As String = generarSelloDigital(foundRows(i)("Periodo"), cadenaOriginal, DirArchivoPEM)
                        'crearXML(Fecha, selloDigital)

                        ModPOS.Ejecuta("sp_actualiza_sello", "@TipoComprobante", foundRows(i)("tipo"), "@Tipo", foundRows(i)("tipoDeComprobante"), "@Clave", foundRows(i)("Clave"), "@cadenaOriginal", oCFD.cadenaOriginal, "@Sello", oCFD.sello, "@Certificado", oCFD.Certificado64)

                        dtConcepto.Dispose()
                        dtImpuesto.Dispose()
                    End If
                Next
                frmStatusMessage.Dispose()
            End If
        Else
            MessageBox.Show("¡No se ha seleccionado algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If '
    End Sub

    Public Sub preparaBotones(ByVal iTipo As Integer)
        BtnPago.Enabled = True
        BtnFacturar.Enabled = True
        BtnDevolucion.Enabled = True
        BtnReimpresion.Enabled = True
        BtnNC.Enabled = True
        btnBonificacion.Enabled = True
        BtnAuditoria.Enabled = True
        btnReenvio.Enabled = True
        btnReembolso.Enabled = True
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
                btnBonificacion.Enabled = False
            Case 2 'Factura
                btnMasiva.Enabled = False
                Me.BtnDevolucion.Enabled = False
                Me.BtnAuditoria.Enabled = False
                BtnNota.Enabled = False

            Case 3 'NC
                BtnGlobal.Enabled = False
                btnMasiva.Enabled = False
                BtnDevolucion.Enabled = False
                BtnAuditoria.Enabled = False
                BtnPago.Enabled = False
                BtnFacturar.Enabled = False
                chkIncluir.Enabled = False
                BtnNota.Enabled = False
                btnNotaCargo.Enabled = False
                btnReembolso.Enabled = False

            Case 4 'Devolucion
                BtnGlobal.Enabled = False
                btnMasiva.Enabled = False
                BtnAuditoria.Enabled = False
                BtnPago.Enabled = False
                BtnFacturar.Enabled = False
                BtnNC.Enabled = False
                btnReenvio.Enabled = False
                chkIncluir.Enabled = False
                BtnNota.Enabled = False
                btnBonificacion.Enabled = False
                btnNotaCargo.Enabled = False
                btnReembolso.Enabled = False

            Case 5 'Nota de Cargo
                BtnDevolucion.Enabled = False
                btnMasiva.Enabled = False
                BtnGlobal.Enabled = False
                BtnAuditoria.Enabled = False
                BtnFacturar.Enabled = False
                BtnNC.Enabled = False
                chkIncluir.Enabled = False
                btnBonificacion.Enabled = False
                BtnNota.Enabled = False

        End Select
    End Sub

    Private Sub btnAnticipo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnticipo.Click
        Dim a As New FrmAbono
        a.bAnticipo = True
        a.Aplicacion = Aplicacion
        a.CAJA = CAJClave
        a.ClaveCaja = ClaveCaja
        a.SaldoAcumulado = dSaldo
        a.AperturaCajon = Cajon
        a.ImpresoraCajon = Impresora
        a.InterfazSalida = InterfazSalida
        a.ConfirmarAbono = ConfirmarAbono
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.actualizaAnticipos()
            RetiroProgramado()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim foundRows() As DataRow
        foundRows = dtAnticipos.Select("Marca ='True'and Importe = Saldo and Fecha >= #" & Today.Date.ToString("MM/dd/yyyy") & "#")
        If foundRows.GetLength(0) > 0 Then
            Dim a As New MeAutorizacion
            a.Sucursal = SUCClave
            a.MontodeAutorizacion = dSaldoAnticipo
            a.StartPosition = FormStartPosition.CenterScreen
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If a.Autorizado Then
                    Dim i As Integer
                    For i = 0 To foundRows.GetUpperBound(0)
                        ModPOS.Ejecuta("sp_cancela_abn", "@ABNClave", foundRows(i)("ABNClave"))

                        If InterfazSalida <> "" Then
                            Dim sFecha As String
                            Dim dtInterfaz As DataTable
                            sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                            dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CancelacionAnticipo", "@COMClave", ModPOS.CompanyActual)
                            If dtInterfaz.Rows.Count > 0 Then
                                ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", foundRows(i)("ABNClave"), "@TipoDocumento", -1, "@Path", InterfazSalida, "@Fecha", sFecha)
                            End If

                        End If

                    Next
                    Me.actualizaAnticipos()
                End If
            End If
        Else
            MessageBox.Show("Debe marcar por lo menos un registro, con fecha igual a la actual y que no se haya aplicado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ChkAnticipos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAnticipos.CheckedChanged
        If dtAnticipos.Rows.Count > 0 Then
            Dim i As Integer
            If ChkAnticipos.Checked Then
                dSaldoAnticipo = 0
                For i = 0 To GridAnticipos.GetDataRows.Length - 1
                    GridAnticipos.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridAnticipos.GetDataRows.Length - 1
                    GridAnticipos.GetDataRows(i).DataRow("Marca") = False
                Next
            End If

            dtAnticipos.AcceptChanges()
            GridAnticipos.Refresh()

            If dtAnticipos.Compute("Sum(Saldo)", "Marca = True") Is System.DBNull.Value Then
                dSaldoAnticipo = 0
            Else
                dSaldoAnticipo = dtAnticipos.Compute("Sum(Saldo)", "Marca = True")
            End If

            Me.LblSaldoAnticipos.Text = Format(CStr(ModPOS.Redondear(dSaldoAnticipo, 2)), "Currency")


        End If
    End Sub

    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bload = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            If Not dtCxC Is Nothing Then
                dtCxC.Dispose()
                dSaldo = 0
                Me.LblSaldo.Text = Format(CStr(ModPOS.Redondear(dSaldo, 2)), "Currency")
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
                    a.MontodeAutorizacion = GridPendientes.GetValue("Total")
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then
                            Autoriza = a.Autoriza

                            Dim dt As DataTable
                            Dim eRFC, sCTEClave As String
                            Dim dTotal As Double
                            Dim iTipo As Integer

                            If GridPendientes.GetValue("tipoDeComprobante") = "ingreso" Then
                                If GridPendientes.GetValue("tipo") = 6 Then
                                    dt = ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", sPendienteSelected)
                                Else
                                    dt = ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", sPendienteSelected)
                                End If
                            Else
                                dt = ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", sPendienteSelected)
                                iTipo = dt.Rows(0)("Tipo")
                            End If

                            eRFC = dt.Rows(0)("cRFC")
                            sCTEClave = dt.Rows(0)("CTEClave")
                            dTotal = dt.Rows(0)("total")
                            dt.Dispose()



                            If GridPendientes.GetValue("TipodeComprobante") = "ingreso" Then

                                Dim bmotivo As Boolean = False
                                Dim MotCancelacion As Integer
                                Do
                                    Dim m As New FrmMotivo
                                    m.Tabla = "Factura"
                                    m.Campo = "Cancelacion"
                                    m.ShowDialog()
                                    If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                        bmotivo = True
                                        MotCancelacion = m.Motivo
                                    End If
                                    m.Dispose()
                                Loop While bmotivo = False

                                If GridPendientes.GetValue("tipo") = 6 Then

                                    ModPOS.Ejecuta("sp_cancela_notacargo", "@CARClave", sPendienteSelected, "@Motivo", MotCancelacion, "@Autoriza", Autoriza)
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", sCTEClave, "@Importe", dTotal)
                                    ModPOS.Ejecuta("sp_libera_pagos_fac", "@FACClave", sPendienteSelected)
                                Else
                                    ModPOS.Ejecuta("sp_cancela_factura", "@FACClave", sPendienteSelected, "@Motivo", MotCancelacion, "@Autoriza", Autoriza)
                                    ModPOS.GeneraMovInv(1, 5, 2, sPendienteSelected, ALMClave, sFolio, Autoriza)
                                    ModPOS.ActualizaExistAlm(1, 2, sPendienteSelected, ALMClave)


                                    If StageCancelacion <> "" Then
                                        ModPOS.ActualizaExistUbc(1, 2, sPendienteSelected, ALMClave, StageCancelacion)
                                    Else
                                        ModPOS.ActualizaExistUbc(1, 2, sPendienteSelected, ALMClave)
                                    End If

                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", sCTEClave, "@Importe", dTotal)
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
                                        m.ShowDialog()
                                        If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                            bmotivo = True
                                            MotCancelacion = m.Motivo
                                        End If
                                        m.Dispose()
                                    Loop While bmotivo = False
                                    ModPOS.Ejecuta("sp_cancela_nc", "@NCClave", sPendienteSelected, "@Motivo", MotCancelacion, "@Autoriza", Autoriza)

                                    'Actualiza el Saldo del Documento
                                    ModPOS.Ejecuta("sp_act_saldo_fac", "@NCClave", sPendienteSelected)
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", sCTEClave, "@Importe", dTotal)


                                    'Si es de tipo devolución, realiza salida de producto de almacén
                                End If



                            End If

                            Me.actualizaGridPendientes()


                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub picSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
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
        a.ShowDialog()
    End Sub

    Private Sub btnNotaCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotaCargo.Click
        Dim foundRows() As DataRow

        foundRows = dtCxC.Select("Marca ='True' and TipoDocumento = 2 ")

        If foundRows.GetLength(0) >= 1 Then

            Dim fr() As DataRow
            fr = dtCxC.Select("Marca ='True'  and RFC <> '" & foundRows(0)("RFC") & "'")

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir Facturas de diferentes clientes en una Nota de Cargo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_ped", "@VENClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                        pvtaDataSet.DataSetName = "pvtaDataSet"
                        OpenReport.PrintPreview("Pedido", "CRPedido.rpt", pvtaDataSet, ModPOS.Letras(ModPOS.TruncateToDecimal(foundRows(i)("Total"), 2)).ToUpper)



                    Case Is = 2 'FAC

                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "F", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        sVersionCF = dt.Rows(0)("VersionCF")
                        Dim sFormato As String
                        sFormato = IIf(dt.Rows(0)("Formato").GetType.Name = "DBNull", "Clasico", dt.Rows(0)("Formato"))

                        dt.Dispose()

                        ModPOS.previewFactura(iTipoCF, sFormato, foundRows(i)("ID"), foundRows(i)("Total"), SUCClave, TipoCambio, MonDesc, MonRef, sVersionCF)



                    Case Is = 4 'NC
                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "N", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        sVersionCF = dt.Rows(0)("VersionCF")
                        dt.Dispose()

                        ModPOS.previewNC(iTipoCF, FormatNC, foundRows(i)("ID"), foundRows(i)("Total"), SUCClave, TipoCambio, MonDesc, MonRef, sVersionCF)

                    Case Is = 5 'Devolucion

                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_dev", "@DEVClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_devolucion_det", "@DEVClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                        pvtaDataSet.DataSetName = "pvtaDataSet"
                        OpenReport.PrintPreview("Devolución", "CRDevolucion.rpt", pvtaDataSet, ModPOS.Letras(ModPOS.TruncateToDecimal(foundRows(i)("Total"), 2)).ToUpper)


                    Case Is = 6 'Nota de Cargo

                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "C", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        sVersionCF = dt.Rows(0)("VersionCF")
                        dt.Dispose()

                        ModPOS.previewCargo(FormatCargo, foundRows(i)("ID"), foundRows(i)("Total"), TipoCambio, MonDesc, MonRef, sVersionCF)

                End Select
                foundRows(i)("Marca") = False
            Next
            ChkMarcaTodos.Checked = False
            chkIncluir.Checked = False
            dSaldo = ModPOS.Redondear(IIf(dtCxC.Compute("Sum(dSaldo)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(dSaldo)", "Marca = True")), 2)
            Me.LblSaldo.Text = Format(CStr(dSaldo), "Currency")

            If TipoCambiario <> 1 Then
                If dSaldo > 0 Then
                    lblMonedaCambio.Text = RefCambio & " " & Format(CStr(TruncateToDecimal(dSaldo / TipoCambiario, 2)), "Currency")
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



                    dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
                    MonedaRef = dt.Rows(0)("Referencia")
                    MonedaDesc = dt.Rows(0)("Descripcion")
                    TipoCambio = dt.Rows(0)("TipoCambio")
                    dt.Dispose()


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

                    Dim sFormatoFactura As String
                    For i = 0 To foundRows.GetUpperBound(0)

                        frmStatusMessage.Show("Generando Comprobantes Fiscales Digitales " & CStr(i + 1) & "/" & CStr(foundRows.GetLength(0)))

                        sFormatoFactura = FormatoFactura

                        'Carga datos Receptor
                        Dim SaldoCliente As Double
                        dt = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", foundRows(i)("CTEClave"))


                        oCFD.CTEClave = dt.Rows(0)("CTEClave")
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
                                           "@MONClave", Moneda, _
                                           "@TipoCambio", TipoCambio, _
                                           "@Formato", sFormatoFactura, _
                                           "@Nota", foundRows(i)("Nota"), _
                                           "@UsoCFDI", oCFD.UsoCFDI, _
                                           "@Usuario", ModPOS.UsuarioActual)


                            'Seccion para agregar multiples metodos de pago

                            If oCFD.VersionCF = "3.3" AndAlso iCredito = 1 Then

                                ModPOS.Ejecuta("sp_agregar_metodopagofac", _
                                   "@FacturaID", FacturaId, _
                                   "@MetodoPago", 0, _
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
                                    a.ShowDialog()

                                    If a.DialogResult = DialogResult.OK Then
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
                                        ModPOS.SendMail(oCFD.VersionCF, oCFD.email, oCFD.TipoCF, sFormatoFactura, CDate(oCFD.Fecha), oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.total, MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonedaDesc, MonedaRef)
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
                    m.ShowDialog()
                    If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
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

                                ModPOS.SendMail(sVersionCF, eMailCte, iTipoCF, sFormato, foundRows(i)("Fecha"), foundRows(i)("Folio"), foundRows(i)("ID"), foundRows(i)("Total"), MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonRef, MonDesc)


                            Case Is = 4 'NC

                                dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "N", "@Documento", foundRows(i)("ID"))
                                TipoCambio = dt.Rows(0)("TipoCambio")
                                MonRef = dt.Rows(0)("Referencia")
                                MonDesc = dt.Rows(0)("Descripcion")
                                sVersionCF = dt.Rows(0)("VersionCF")
                                dt.Dispose()


                                ModPOS.SendMailNC(VersionCF, eMailCte, iTipoCF, FormatNC, CDate(foundRows(i)("Fecha")), foundRows(i)("Folio"), foundRows(i)("ID"), foundRows(i)("Total"), MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, SUCClave, TipoCambio, MonDesc, MonRef, True)


                            Case Is = 6 'Nota de Cargo


                                dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "C", "@Documento", foundRows(i)("ID"))
                                TipoCambio = dt.Rows(0)("TipoCambio")
                                MonRef = dt.Rows(0)("Referencia")
                                MonDesc = dt.Rows(0)("Descripcion")
                                sVersionCF = dt.Rows(0)("VersionCF")

                                dt.Dispose()



                                ModPOS.SendMailCargo(VersionCF, eMailCte, FormatNC, CDate(foundRows(i)("Fecha")), foundRows(i)("Folio"), foundRows(i)("ID"), foundRows(i)("Total"), MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, TipoCambio, MonDesc, MonRef, True)


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
            dSaldo = ModPOS.Redondear(IIf(dtCxC.Compute("Sum(dSaldo)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(dSaldo)", "Marca = True")), 2)
            Me.LblSaldo.Text = Format(CStr(dSaldo), "Currency")

            If TipoCambio <> 1 Then
                If dSaldo > 0 Then
                    lblMonedaCambio.Text = RefCambio & " " & Format(CStr(Redondear(dSaldo / TipoCambio, 2)), "Currency")
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
                dSaldo = 0
                Me.LblSaldo.Text = Format(CStr(ModPOS.Redondear(dSaldo, 2)), "Currency")

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
        foundRows = dtCxC.Select("Marca ='True' and Saldo > 0 and TipoNC = 1 ")
        If foundRows.GetLength(0) > 0 Then

            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_busca_corteCaja", "@CAJClave", CAJClave)

            Dim IDCorte As String = ""
            Dim dEfectivo, dSaldo As Double

            If dt.Rows.Count > 0 Then
                IDCorte = dt.Rows(0)("ID")
            End If
            dt.Dispose()


            dt = ModPOS.Recupera_Tabla("st_recupera_efectivo", "@IDCorte", IDCorte)
            If dt.Rows.Count > 0 Then
                dEfectivo = dt.Rows(0)("Efectivo")
            End If
            dt.Dispose()

            dSaldo = ModPOS.Redondear(IIf(dtCxC.Compute("Sum(dSaldo)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(dSaldo)", "Marca = True")), 2)

            If dSaldo <= dEfectivo Then

                Select Case MessageBox.Show("¿Esta seguro de aplicar el reembolso a los documentos seleccionados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes

                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_aplica_reembolso", _
                                           "@CTEClave", foundRows(i)("CTEClave"), _
                                           "@DOCClave", foundRows(i)("ID"), _
                                           "@TipoDocumento", foundRows(i)("TipoDocumento"), _
                                           "@CAJClave", CAJClave, _
                                           "@Moneda", Moneda, _
                                           "@TipoCambio", TipoCambio, _
                                           "@Saldo", foundRows(i)("Saldo"), _
                                           "@Usuario", ModPOS.UsuarioActual)

                            foundRows(i)("Marca") = False
                        Next
                        ChkMarcaTodos.Checked = False
                        chkIncluir.Checked = False
                        dSaldo = ModPOS.Redondear(IIf(dtCxC.Compute("Sum(dSaldo)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(dSaldo)", "Marca = True")), 2)
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

    Private Sub btnBonificacion_Click(sender As Object, e As EventArgs) Handles btnBonificacion.Click
        Dim foundRows() As DataRow

        foundRows = dtCxC.Select("Marca ='True' and TipoDocumento = 2 ")

        If foundRows.GetLength(0) >= 1 Then

            Dim fr() As DataRow
            fr = dtCxC.Select("Marca ='True'  and RFC <> '" & foundRows(0)("RFC") & "'")

            If fr.GetLength(0) >= 1 Then
                MessageBox.Show("No es posible incluir Facturas de diferentes clientes en una bonificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

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

        Else

            If ModPOS.Bonificacion Is Nothing Then
                ModPOS.Bonificacion = New FrmBonificacion
                ModPOS.Bonificacion.SUCClave = SUCClave
                ModPOS.Bonificacion.CAJClave = CAJClave
            End If

            ModPOS.Bonificacion.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Bonificacion.Show()
            If Not ModPOS.Bonificacion Is Nothing Then
                ModPOS.Bonificacion.BringToFront()
            End If

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
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then

            If a.IdCorte <> "" Then
                Dim OpenReport As New Report
                Dim pvtaDataSet As New DataSet

                If Transferencia = 1 Then
                    pvtaDataSet.DataSetName = "pvtaDataSet"
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco_enc", "@IdCorte", a.IdCorte))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_corte_det", "@IdCorte", a.IdCorte))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_creditos", "@IdCorte", a.IdCorte))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_otrospagos", "@IdCorte", a.IdCorte))
                    OpenReport.PrintPreview("Corte de Caja", "CRCorte.rpt", pvtaDataSet, "")
                Else
                    pvtaDataSet.DataSetName = "reportDataSet"
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_transbanco_enc", "@IdCorte", a.IdCorte))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_corte_det", "@IdCorte", a.IdCorte))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_corte_creditos", "@IdCorte", a.IdCorte))

                    ' pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_balanza", "@ID", a.IdCorte))
                    OpenReport.PrintPreview("Reporte de Corte de Caja", "CRCorteCaja.rpt", pvtaDataSet, "")
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
        a.ShowDialog()
        If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
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
                    foundRows = dtCxC.Select("Marca = True and Saldo > 0")
                    If foundRows.GetLength(0) > 0 Then
                        Me.BtnPago.PerformClick()
                    End If
                End If
            Case Is = Keys.Escape
                Me.Close()
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
        a.ShowDialog()
        a.Dispose()
        If validaForm() Then
            Me.AgregarFolio()
        End If
    End Sub

    Private Sub BtnCerrar_Click_1(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
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
        a.ShowDialog()
        If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
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
        a.ShowDialog()
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
            a.ShowDialog()
            foundRows(0)("Nota") = a.Nota
            ModPOS.Ejecuta("st_agrega_nota", "@VENClave", foundRows(0)("ID"), "@Nota", a.Nota)
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

    Private Sub cmbComplemento_ValueChanged(sender As Object, e As EventArgs) Handles cmbComplemento.ValueChanged
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
                If PrintDialog1.ShowDialog() = DialogResult.OK Then
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
                      

                        Dim dFecha As DateTime

                        If DateDiff(DateInterval.Hour, CDate(dt.Rows(0)("MFechaHora")), DateTime.Now) > 72 Then
                            dFecha = DateTime.Now

                        Else
                            dFecha = dt.Rows(0)("MFechaHora")
                        End If


                        oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", dFecha)

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

        If PrintDialog1.ShowDialog() = DialogResult.OK Then
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
                    m.ShowDialog()
                    If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        eMailCte = m.Correo
                    End If
                    m.Dispose()
                End If

                If eMailCte <> "" Then
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

                        OpenReport.PrintPDF("CRAnticipoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal((Base + IVA) / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)

                    ElseIf foundRows(i)("Tipo") = "Pago" Then

                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_recupera_relacionado", "@DOCClave", foundRows(i)("ABNClave"), "@Tipo", "P"))
                        OpenReport.PrintPDF("CRPagoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(total / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)
                    Else




                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_aplicacion", "@ANTClave", foundRows(i)("ABNClave")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_sello_anticipo", "@ANTClave", foundRows(i)("ABNClave")))

                        Dim Base As Decimal = Math.Round(total / 1.16, 2)
                        Dim IVA As Decimal = Math.Round(Base * 0.16, 2)
                        OpenReport.PrintPDF("CRAplicacionCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal((Base + IVA) / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)

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

                    sPathXML &= CDate(foundRows(i)("Fecha")).Year.ToString & "\" & CDate(foundRows(i)("Fecha")).Month.ToString & "\" & CDate(foundRows(i)("Fecha")).Day.ToString & "\" & sFolio & ".xml"



                    If Not System.IO.File.Exists(sPathXML) Then
                        If PathXML.Length <= 3 Then
                            sPathXML = PathXML & foundRows(i)("Folio") & ".xml"
                        Else
                            sPathXML = PathXML & "\" & foundRows(i)("Folio") & ".xml"
                        End If

                    End If

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
End Class
