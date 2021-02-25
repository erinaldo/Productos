Imports CrystalDecisions.CrystalReports.Engine
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
    Friend WithEvents BtnRecalcular As Janus.Windows.EditControls.UIButton
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
    Friend WithEvents picSalir As System.Windows.Forms.PictureBox
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
    Friend WithEvents BtnComision As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTCaja))
        Me.LblCaja = New System.Windows.Forms.Label
        Me.LblAtiende = New System.Windows.Forms.Label
        Me.LblDescripcion = New System.Windows.Forms.Label
        Me.LblUsuario = New System.Windows.Forms.Label
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.BtnPago = New Janus.Windows.EditControls.UIButton
        Me.BtnRetiro = New Janus.Windows.EditControls.UIButton
        Me.BtnApartados = New Janus.Windows.EditControls.UIButton
        Me.BtnRecalcular = New Janus.Windows.EditControls.UIButton
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab
        Me.UiTabGeneral = New Janus.Windows.UI.Tab.UITabPage
        Me.GrpTickets = New System.Windows.Forms.GroupBox
        Me.chkIncluir = New System.Windows.Forms.CheckBox
        Me.picSalir = New System.Windows.Forms.PictureBox
        Me.picKeyboard = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.dtPicker = New System.Windows.Forms.DateTimePicker
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbTipoTrans = New Selling.StoreCombo
        Me.BtnRefresh = New Janus.Windows.EditControls.UIButton
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox
        Me.LblSaldo = New System.Windows.Forms.Label
        Me.LblTotal = New System.Windows.Forms.Label
        Me.TxtFolio = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GridCxC = New Janus.Windows.GridEX.GridEX
        Me.UiTabCXC = New Janus.Windows.UI.Tab.UITabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GridCreditos = New Janus.Windows.GridEX.GridEX
        Me.UiTabAnticipos = New Janus.Windows.UI.Tab.UITabPage
        Me.GrpAnticipos = New System.Windows.Forms.GroupBox
        Me.ChkAnticipos = New System.Windows.Forms.CheckBox
        Me.btnAnticipo = New Janus.Windows.EditControls.UIButton
        Me.btnCancel = New Janus.Windows.EditControls.UIButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblSaldoAnticipos = New System.Windows.Forms.Label
        Me.GridAnticipos = New Janus.Windows.GridEX.GridEX
        Me.UiTabPendientes = New Janus.Windows.UI.Tab.UITabPage
        Me.GrpPendientes = New System.Windows.Forms.GroupBox
        Me.btnCancelaPendiente = New Janus.Windows.EditControls.UIButton
        Me.btnRegenerar = New Janus.Windows.EditControls.UIButton
        Me.GridPendientes = New Janus.Windows.GridEX.GridEX
        Me.btnCertificar = New Janus.Windows.EditControls.UIButton
        Me.UiTabContrarecibos = New Janus.Windows.UI.Tab.UITabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnEditContrarecibo = New Janus.Windows.EditControls.UIButton
        Me.btnAddContrarecibo = New Janus.Windows.EditControls.UIButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.dtPickerContrarecibo = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.GridContrarecibos = New Janus.Windows.GridEX.GridEX
        Me.cmbEdoContrarecibo = New Selling.StoreCombo
        Me.GrpSaldos = New System.Windows.Forms.GroupBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.NumSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.LblCredito = New System.Windows.Forms.Label
        Me.NumDisponible = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.GridSaldos = New Janus.Windows.GridEX.GridEX
        Me.GrpMetodos = New System.Windows.Forms.GroupBox
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GridMetodos = New Janus.Windows.GridEX.GridEX
        Me.BtnElimina = New Janus.Windows.EditControls.UIButton
        Me.BtnModifica = New Janus.Windows.EditControls.UIButton
        Me.BtnComision = New Janus.Windows.EditControls.UIButton
        Me.BtnCambio = New Janus.Windows.EditControls.UIButton
        Me.BtnNC = New Janus.Windows.EditControls.UIButton
        Me.BtnFacturar = New Janus.Windows.EditControls.UIButton
        Me.BtnRecibo = New Janus.Windows.EditControls.UIButton
        Me.BtnDevolucion = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.lblDate = New System.Windows.Forms.Label
        Me.btnNotaCargo = New Janus.Windows.EditControls.UIButton
        Me.BtnConsultar = New Janus.Windows.EditControls.UIButton
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabGeneral.SuspendLayout()
        Me.GrpTickets.SuspendLayout()
        CType(Me.picSalir, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.UiTabPendientes.SuspendLayout()
        Me.GrpPendientes.SuspendLayout()
        CType(Me.GridPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabContrarecibos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridContrarecibos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BtnPago.Location = New System.Drawing.Point(382, 98)
        Me.BtnPago.Name = "BtnPago"
        Me.BtnPago.Size = New System.Drawing.Size(91, 30)
        Me.BtnPago.TabIndex = 1
        Me.BtnPago.Text = "F5- Pagar"
        Me.BtnPago.ToolTipText = "Registrar Pago de registros seleccionados"
        Me.BtnPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnRetiro
        '
        Me.BtnRetiro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRetiro.Icon = CType(resources.GetObject("BtnRetiro.Icon"), System.Drawing.Icon)
        Me.BtnRetiro.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnRetiro.Location = New System.Drawing.Point(382, 61)
        Me.BtnRetiro.Name = "BtnRetiro"
        Me.BtnRetiro.Size = New System.Drawing.Size(91, 30)
        Me.BtnRetiro.TabIndex = 10
        Me.BtnRetiro.Text = "F10- Retiro"
        Me.BtnRetiro.ToolTipText = "Retiro de Caja"
        Me.BtnRetiro.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnApartados
        '
        Me.BtnApartados.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnApartados.Icon = CType(resources.GetObject("BtnApartados.Icon"), System.Drawing.Icon)
        Me.BtnApartados.Location = New System.Drawing.Point(287, 60)
        Me.BtnApartados.Name = "BtnApartados"
        Me.BtnApartados.Size = New System.Drawing.Size(91, 30)
        Me.BtnApartados.TabIndex = 15
        Me.BtnApartados.Text = "F11- Apartados"
        Me.BtnApartados.ToolTipText = "Mantenimiento de Productos Apartados"
        Me.BtnApartados.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnRecalcular
        '
        Me.BtnRecalcular.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRecalcular.Icon = CType(resources.GetObject("BtnRecalcular.Icon"), System.Drawing.Icon)
        Me.BtnRecalcular.Location = New System.Drawing.Point(192, 98)
        Me.BtnRecalcular.Name = "BtnRecalcular"
        Me.BtnRecalcular.Size = New System.Drawing.Size(91, 30)
        Me.BtnRecalcular.TabIndex = 17
        Me.BtnRecalcular.Text = "F3- Recalcular"
        Me.BtnRecalcular.ToolTipText = "Recalcula ventas que no han sido pagadas total o parcialmente"
        Me.BtnRecalcular.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnReimpresion
        '
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Icon = CType(resources.GetObject("BtnReimpresion.Icon"), System.Drawing.Icon)
        Me.BtnReimpresion.Location = New System.Drawing.Point(3, 98)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(91, 30)
        Me.BtnReimpresion.TabIndex = 18
        Me.BtnReimpresion.Text = "Reimprimir"
        Me.BtnReimpresion.ToolTipText = "Reimpresión de documento"
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
        Me.UiTab1.Size = New System.Drawing.Size(794, 427)
        Me.UiTab1.TabIndex = 21
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabGeneral, Me.UiTabCXC, Me.UiTabAnticipos, Me.UiTabPendientes, Me.UiTabContrarecibos})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabGeneral
        '
        Me.UiTabGeneral.Controls.Add(Me.GrpTickets)
        Me.UiTabGeneral.Location = New System.Drawing.Point(1, 21)
        Me.UiTabGeneral.Name = "UiTabGeneral"
        Me.UiTabGeneral.Size = New System.Drawing.Size(792, 405)
        Me.UiTabGeneral.TabStop = True
        Me.UiTabGeneral.Text = "General"
        '
        'GrpTickets
        '
        Me.GrpTickets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.chkIncluir)
        Me.GrpTickets.Controls.Add(Me.picSalir)
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
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(2, 3)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(788, 399)
        Me.GrpTickets.TabIndex = 2
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Cobranza General"
        '
        'chkIncluir
        '
        Me.chkIncluir.Location = New System.Drawing.Point(433, 18)
        Me.chkIncluir.Name = "chkIncluir"
        Me.chkIncluir.Size = New System.Drawing.Size(133, 19)
        Me.chkIncluir.TabIndex = 89
        Me.chkIncluir.Text = "Incluir cobrados"
        '
        'picSalir
        '
        Me.picSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picSalir.BackColor = System.Drawing.Color.Transparent
        Me.picSalir.Image = Global.Selling.My.Resources.Resources._1403660273_exit
        Me.picSalir.Location = New System.Drawing.Point(8, 361)
        Me.picSalir.Name = "picSalir"
        Me.picSalir.Size = New System.Drawing.Size(27, 30)
        Me.picSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSalir.TabIndex = 88
        Me.picSalir.TabStop = False
        '
        'picKeyboard
        '
        Me.picKeyboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picKeyboard.BackColor = System.Drawing.Color.Transparent
        Me.picKeyboard.Image = Global.Selling.My.Resources.Resources._1403657593_519640_141_Keyboard
        Me.picKeyboard.Location = New System.Drawing.Point(53, 361)
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
        Me.Label4.Location = New System.Drawing.Point(574, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "Periodo"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(80, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(634, 17)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(145, 22)
        Me.dtPicker.TabIndex = 85
        Me.dtPicker.Value = New Date(2015, 1, 27, 0, 0, 0, 0)
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(288, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 84
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(79, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 14)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "Tipo"
        '
        'cmbTipoTrans
        '
        Me.cmbTipoTrans.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoTrans.Location = New System.Drawing.Point(120, 15)
        Me.cmbTipoTrans.Name = "cmbTipoTrans"
        Me.cmbTipoTrans.Size = New System.Drawing.Size(139, 24)
        Me.cmbTipoTrans.TabIndex = 82
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Icon = CType(resources.GetObject("BtnRefresh.Icon"), System.Drawing.Icon)
        Me.BtnRefresh.Location = New System.Drawing.Point(401, 15)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(26, 21)
        Me.BtnRefresh.TabIndex = 50
        Me.BtnRefresh.ToolTipText = "Actualizar"
        Me.BtnRefresh.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(7, 19)
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
        Me.LblSaldo.Location = New System.Drawing.Point(583, 356)
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
        Me.LblTotal.Location = New System.Drawing.Point(428, 364)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(150, 27)
        Me.LblTotal.TabIndex = 47
        Me.LblTotal.Text = "TOTAL A PAGAR"
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(309, 16)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(84, 21)
        Me.TxtFolio.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(265, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Folio"
        '
        'GridCxC
        '
        Me.GridCxC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCxC.ColumnAutoResize = True
        Me.GridCxC.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCxC.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCxC.GroupByBoxVisible = False
        Me.GridCxC.Location = New System.Drawing.Point(7, 44)
        Me.GridCxC.Name = "GridCxC"
        Me.GridCxC.RecordNavigator = True
        Me.GridCxC.Size = New System.Drawing.Size(773, 301)
        Me.GridCxC.TabIndex = 4
        Me.GridCxC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabCXC
        '
        Me.UiTabCXC.Controls.Add(Me.GroupBox1)
        Me.UiTabCXC.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCXC.Name = "UiTabCXC"
        Me.UiTabCXC.Size = New System.Drawing.Size(792, 405)
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
        Me.GroupBox1.Controls.Add(Me.GridCreditos)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(2, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(788, 396)
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
        Me.GridCreditos.Location = New System.Drawing.Point(7, 19)
        Me.GridCreditos.Name = "GridCreditos"
        Me.GridCreditos.RecordNavigator = True
        Me.GridCreditos.Size = New System.Drawing.Size(773, 372)
        Me.GridCreditos.TabIndex = 4
        Me.GridCreditos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabAnticipos
        '
        Me.UiTabAnticipos.Controls.Add(Me.GrpAnticipos)
        Me.UiTabAnticipos.Location = New System.Drawing.Point(1, 21)
        Me.UiTabAnticipos.Name = "UiTabAnticipos"
        Me.UiTabAnticipos.Size = New System.Drawing.Size(792, 405)
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
        Me.GrpAnticipos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpAnticipos.ForeColor = System.Drawing.Color.Black
        Me.GrpAnticipos.Location = New System.Drawing.Point(2, 3)
        Me.GrpAnticipos.Name = "GrpAnticipos"
        Me.GrpAnticipos.Size = New System.Drawing.Size(788, 399)
        Me.GrpAnticipos.TabIndex = 4
        Me.GrpAnticipos.TabStop = False
        Me.GrpAnticipos.Text = "Abonos con saldo pendiente de aplicar"
        '
        'ChkAnticipos
        '
        Me.ChkAnticipos.Location = New System.Drawing.Point(8, 22)
        Me.ChkAnticipos.Name = "ChkAnticipos"
        Me.ChkAnticipos.Size = New System.Drawing.Size(124, 20)
        Me.ChkAnticipos.TabIndex = 51
        Me.ChkAnticipos.Text = "Seleccionar Todos"
        '
        'btnAnticipo
        '
        Me.btnAnticipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnticipo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnticipo.Icon = CType(resources.GetObject("btnAnticipo.Icon"), System.Drawing.Icon)
        Me.btnAnticipo.ImageSize = New System.Drawing.Size(24, 16)
        Me.btnAnticipo.Location = New System.Drawing.Point(592, 13)
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
        Me.btnCancel.Location = New System.Drawing.Point(689, 13)
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
        Me.Label2.Location = New System.Drawing.Point(568, 368)
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
        Me.LblSaldoAnticipos.Location = New System.Drawing.Point(626, 358)
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
        Me.GridAnticipos.Size = New System.Drawing.Size(773, 309)
        Me.GridAnticipos.TabIndex = 4
        Me.GridAnticipos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabPendientes
        '
        Me.UiTabPendientes.Controls.Add(Me.GrpPendientes)
        Me.UiTabPendientes.Location = New System.Drawing.Point(1, 21)
        Me.UiTabPendientes.Name = "UiTabPendientes"
        Me.UiTabPendientes.Size = New System.Drawing.Size(792, 405)
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
        Me.GrpPendientes.Size = New System.Drawing.Size(788, 399)
        Me.GrpPendientes.TabIndex = 3
        Me.GrpPendientes.TabStop = False
        Me.GrpPendientes.Text = "Documentos Pendientes de Certificar"
        '
        'btnCancelaPendiente
        '
        Me.btnCancelaPendiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelaPendiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelaPendiente.Icon = CType(resources.GetObject("btnCancelaPendiente.Icon"), System.Drawing.Icon)
        Me.btnCancelaPendiente.Location = New System.Drawing.Point(493, 15)
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
        Me.btnRegenerar.Location = New System.Drawing.Point(590, 15)
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
        Me.GridPendientes.Size = New System.Drawing.Size(774, 343)
        Me.GridPendientes.TabIndex = 4
        Me.GridPendientes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnCertificar
        '
        Me.btnCertificar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCertificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCertificar.Icon = CType(resources.GetObject("btnCertificar.Icon"), System.Drawing.Icon)
        Me.btnCertificar.Location = New System.Drawing.Point(687, 15)
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
        Me.UiTabContrarecibos.Size = New System.Drawing.Size(792, 405)
        Me.UiTabContrarecibos.TabStop = True
        Me.UiTabContrarecibos.Text = "Contrarecibos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GroupBox2.Controls.Add(Me.btnEditContrarecibo)
        Me.GroupBox2.Controls.Add(Me.btnAddContrarecibo)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.PictureBox5)
        Me.GroupBox2.Controls.Add(Me.dtPickerContrarecibo)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.GridContrarecibos)
        Me.GroupBox2.Controls.Add(Me.cmbEdoContrarecibo)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(788, 399)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Gestión de Contrarecibos"
        '
        'btnEditContrarecibo
        '
        Me.btnEditContrarecibo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditContrarecibo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditContrarecibo.Icon = CType(resources.GetObject("btnEditContrarecibo.Icon"), System.Drawing.Icon)
        Me.btnEditContrarecibo.Location = New System.Drawing.Point(592, 12)
        Me.btnEditContrarecibo.Name = "btnEditContrarecibo"
        Me.btnEditContrarecibo.Size = New System.Drawing.Size(92, 28)
        Me.btnEditContrarecibo.TabIndex = 90
        Me.btnEditContrarecibo.Text = "Editar"
        Me.btnEditContrarecibo.ToolTipText = "Actualiza el registro seleccionado"
        Me.btnEditContrarecibo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAddContrarecibo
        '
        Me.btnAddContrarecibo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddContrarecibo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddContrarecibo.Icon = CType(resources.GetObject("btnAddContrarecibo.Icon"), System.Drawing.Icon)
        Me.btnAddContrarecibo.Location = New System.Drawing.Point(689, 12)
        Me.btnAddContrarecibo.Name = "btnAddContrarecibo"
        Me.btnAddContrarecibo.Size = New System.Drawing.Size(91, 28)
        Me.btnAddContrarecibo.TabIndex = 89
        Me.btnAddContrarecibo.Text = "Nuevo"
        Me.btnAddContrarecibo.ToolTipText = "Agrega nuevo documento a la gestión de contrarecibos"
        Me.btnAddContrarecibo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(177, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "Periodo"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(44, 20)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox5.TabIndex = 39
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'dtPickerContrarecibo
        '
        Me.dtPickerContrarecibo.CustomFormat = "MMMM yyyy"
        Me.dtPickerContrarecibo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPickerContrarecibo.Location = New System.Drawing.Point(227, 17)
        Me.dtPickerContrarecibo.Name = "dtPickerContrarecibo"
        Me.dtPickerContrarecibo.Size = New System.Drawing.Size(184, 22)
        Me.dtPickerContrarecibo.TabIndex = 85
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(7, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 14)
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
        Me.GridContrarecibos.Size = New System.Drawing.Size(773, 350)
        Me.GridContrarecibos.TabIndex = 4
        Me.GridContrarecibos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cmbEdoContrarecibo
        '
        Me.cmbEdoContrarecibo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbEdoContrarecibo.Location = New System.Drawing.Point(58, 18)
        Me.cmbEdoContrarecibo.Name = "cmbEdoContrarecibo"
        Me.cmbEdoContrarecibo.Size = New System.Drawing.Size(100, 24)
        Me.cmbEdoContrarecibo.TabIndex = 82
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
        Me.NumSaldo.Value = 0
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
        Me.NumDisponible.Value = 0
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
        Me.BtnComision.Location = New System.Drawing.Point(97, 61)
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
        Me.BtnCambio.Location = New System.Drawing.Point(192, 61)
        Me.BtnCambio.Name = "BtnCambio"
        Me.BtnCambio.Size = New System.Drawing.Size(91, 30)
        Me.BtnCambio.TabIndex = 16
        Me.BtnCambio.Text = "F12- Cambios"
        Me.BtnCambio.ToolTipText = "Registrar Cambio de Producto"
        Me.BtnCambio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnNC
        '
        Me.BtnNC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNC.Icon = CType(resources.GetObject("BtnNC.Icon"), System.Drawing.Icon)
        Me.BtnNC.Location = New System.Drawing.Point(572, 98)
        Me.BtnNC.Name = "BtnNC"
        Me.BtnNC.Size = New System.Drawing.Size(91, 30)
        Me.BtnNC.TabIndex = 4
        Me.BtnNC.Text = "F7-NC"
        Me.BtnNC.ToolTipText = "Crear Nota de Crédito de registro seleccionado"
        Me.BtnNC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnFacturar
        '
        Me.BtnFacturar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFacturar.Icon = CType(resources.GetObject("BtnFacturar.Icon"), System.Drawing.Icon)
        Me.BtnFacturar.Location = New System.Drawing.Point(571, 61)
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
        Me.BtnRecibo.Location = New System.Drawing.Point(477, 61)
        Me.BtnRecibo.Name = "BtnRecibo"
        Me.BtnRecibo.Size = New System.Drawing.Size(91, 30)
        Me.BtnRecibo.TabIndex = 2
        Me.BtnRecibo.Text = "F9- Recibo"
        Me.BtnRecibo.ToolTipText = "Imprimir Recibo de registro seleccionado"
        Me.BtnRecibo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnDevolucion
        '
        Me.BtnDevolucion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDevolucion.Icon = CType(resources.GetObject("BtnDevolucion.Icon"), System.Drawing.Icon)
        Me.BtnDevolucion.Location = New System.Drawing.Point(287, 98)
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
        Me.BtnCancelar.Location = New System.Drawing.Point(477, 98)
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
        Me.lblDate.Size = New System.Drawing.Size(326, 14)
        Me.lblDate.TabIndex = 22
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnNotaCargo
        '
        Me.btnNotaCargo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNotaCargo.Icon = CType(resources.GetObject("btnNotaCargo.Icon"), System.Drawing.Icon)
        Me.btnNotaCargo.Location = New System.Drawing.Point(97, 98)
        Me.btnNotaCargo.Name = "btnNotaCargo"
        Me.btnNotaCargo.Size = New System.Drawing.Size(91, 30)
        Me.btnNotaCargo.TabIndex = 23
        Me.btnNotaCargo.Text = "F2-Nota Cargo"
        Me.btnNotaCargo.ToolTipText = "Crear Nota de Cargo "
        Me.btnNotaCargo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsultar.Icon = CType(resources.GetObject("BtnConsultar.Icon"), System.Drawing.Icon)
        Me.BtnConsultar.Location = New System.Drawing.Point(3, 61)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(91, 30)
        Me.BtnConsultar.TabIndex = 24
        Me.BtnConsultar.Text = "Consultar"
        Me.BtnConsultar.ToolTipText = "Consultar documento"
        Me.BtnConsultar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmTCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(800, 564)
        Me.Controls.Add(Me.BtnConsultar)
        Me.Controls.Add(Me.btnNotaCargo)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.UiTab1)
        Me.Controls.Add(Me.BtnComision)
        Me.Controls.Add(Me.BtnReimpresion)
        Me.Controls.Add(Me.BtnRecalcular)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmTCaja"
        Me.Text = "Control de Caja"
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        Me.UiTabGeneral.ResumeLayout(False)
        Me.GrpTickets.ResumeLayout(False)
        Me.GrpTickets.PerformLayout()
        CType(Me.picSalir, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.UiTabPendientes.ResumeLayout(False)
        Me.GrpPendientes.ResumeLayout(False)
        CType(Me.GridPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabContrarecibos.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridContrarecibos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpSaldos.ResumeLayout(False)
        Me.GrpSaldos.PerformLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpMetodos.ResumeLayout(False)
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public SUCClave As String
    Public CAJClave As String
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
    Private Picking As Boolean = False

    Private Autoriza As String
    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private dtCxC As DataTable
    Private dSaldo, dSaldoAnticipo As Double
    Private bload As Boolean = False
    Private dtPAC, dtPendientes, dtAnticipos, dtContrarecibos As DataTable

    Private TipoCF As Integer
    Private CTEClaveActual As String
    Private CTENombreActual As String

    Private ServidorCancelacion As String
    Private Customerkey As String
    Private cobranzaGeneral As Boolean = True
    Private CTEClave As String = ""
    Private sRazonSocial As String = ""
    Private PathXML, FormatoFactura, sPendienteSelected, sContrareciboSelected As String

    Private Periodo, PeriodoContra, Mes, MesContra As Integer


    Private Sub FrmTCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        Dim dtParam As DataTable


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
                        FormatoFactura = IIf(dtParam.Rows(0)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(0)("Valor"))
                End Select
            Next
        End With
        dtParam.Dispose()

        Dim dt As DataTable


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
            ac.ShowDialog()
            If ac.DialogResult = System.Windows.Forms.DialogResult.OK AndAlso ac.Accion = "Corte" Then
                
                If CorteDetallado = 1 Then
                    Dim a As New FrmAperturaCaja
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
                    a.Accion = "Apertura"
                    a.IDCorte = IDCorte
                    a.CAJClave = CAJClave
                    a.Cajon = Cajon
                    a.Generic = PrintGeneric
                    a.Recibo = Recibo
                    a.Impresora = Impresora
                    a.ShowDialog()
                End If

                
            ElseIf ac.Accion = "PreCorte" Then
                Dim StopPrint As Boolean = False

                Dim sPrintMessage As String = "¿Desea Reimprimir el Pre Corte de Caja?"
                Do

                    imprimeTicketPreCorte(IDCorte, Impresora, PrintGeneric, Recibo)

                    Select Case MessageBox.Show(sPrintMessage, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.No
                            StopPrint = True
                    End Select

                Loop While Not StopPrint
            ElseIf ac.Accion = "" Then
                Me.Close()
            End If
        Else
            
            If CorteDetallado = 1 Then
                Dim a As New FrmAperturaCaja
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
        If validaForm() Then

            If Not dtCxC Is Nothing Then
                dtCxC.Dispose()
            End If

            dtCxC = ModPOS.Recupera_Tabla("sp_recupera_cxc", "@Folio", TxtFolio.Text.Trim.ToUpper.Replace("'", "''"), "@Periodo", Periodo, "@Mes", Mes, "@Tipo", cmbTipoTrans.SelectedValue, "@COMClave", ModPOS.CompanyActual, "@Cobrados", chkIncluir.Checked)
            GridCxC.DataSource = dtCxC
            GridCxC.RetrieveStructure()
            GridCxC.AutoSizeColumns()

            GridCxC.RootTable.Columns("ID").Visible = False
            GridCxC.CurrentTable.Columns(2).Selectable = False
            GridCxC.CurrentTable.Columns(3).Selectable = False
            GridCxC.CurrentTable.Columns(4).Selectable = False
            GridCxC.CurrentTable.Columns(5).Selectable = False
            GridCxC.CurrentTable.Columns(6).Selectable = False
            GridCxC.CurrentTable.Columns(7).Selectable = False
            GridCxC.CurrentTable.Columns("TipoDocumento").Visible = False
            GridCxC.CurrentTable.Columns("CTEClave").Visible = False
            GridCxC.CurrentTable.Columns("Nota").Selectable = False
            GridCxC.CurrentTable.Columns("DevTipo").Visible = False
            GridCxC.CurrentTable.Columns("TipoCF").Visible = False
            dSaldo = 0
            Me.LblSaldo.Text = Format(CStr(ModPOS.Redondear(dSaldo, 2)), "Currency")
            ChkMarcaTodos.Enabled = True

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Public Function imprimeRecibo(ByVal Abono As String, ByVal Importe As Double, ByVal Cambio As Double, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String, ByVal Usu As String, ByVal Cte As String) As Boolean
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
        Tickets.AddSubHeaderLine("CTE: " & Cte, 0, 3)
        Tickets.AddSubHeaderLine("LE ATENDIO: " & Usu, 0, 1)
        Tickets.AddSubHeaderLine(DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToShortTimeString(), 0, 1)

        Dim dtRef As DataTable = ModPOS.Recupera_Tabla("sp_recibo_enc", "@ABNClave", Abono)

        Tickets.AddSubHeaderBloqLine("REFERENCIA: " & dtRef.Rows(0)("Referencia"), 0, 1)
        Tickets.AddSubHeaderBloqLine("FORMA PAGO: " & dtRef.Rows(0)("Descripcion"), 0, 1)
        Tickets.AddSubHeaderBloqLine("NOTA: " & dtRef.Rows(0)("Nota"), 0, 1)

        '        Tickets.AddSubHeaderBloqLine("IMPORTE: " & Format(CStr(ModPOS.Redondear(Importe, 2)), "Currency"), 0, 1)

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
            ac.ShowDialog()
            If ac.DialogResult = System.Windows.Forms.DialogResult.OK AndAlso ac.Accion = "Corte" Then


                If CorteDetallado = 1 Then
                    Dim a As New FrmAperturaCaja
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

               

            ElseIf ac.Accion = "PreCorte" Then
                Dim StopPrint As Boolean = False

                Dim sPrintMessage As String = "¿Desea Reimprimir el Pre Corte de Caja?"
                Do

                    imprimeTicketPreCorte(IDCorte, Impresora, PrintGeneric, Recibo)

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

            If CorteDetallado = 1 Then
                Dim a As New FrmAperturaCaja
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

        ModPOS.Ejecuta("sp_act_caja", "@CAJClave", CAJClave, "@Fase", 0)

        ModPOS.MtoCXC.Dispose()
        ModPOS.MtoCXC = Nothing
    End Sub

    Private Sub Aplica_Pagos(ByVal foundRows() As DataRow, ByVal CTEClave As String, ByVal AbonoClave As String, ByVal TPago As Integer, ByVal TotalAbono As Double, ByVal SaldoVenta As Double, ByVal TotalCambio As Double, ByVal bShowCambio As Boolean)
        Dim i As Integer
        Dim dts As DataTable
        Dim AcumulaPuntos As Integer
        dts = ModPOS.Recupera_Tabla("sp_recupera_cte_mostrador", "@Cliente", CTEClave)
        If dts.Rows(0)("POS") = 0 Then
            AcumulaPuntos = 1
        Else
            AcumulaPuntos = 0
        End If

        dts.Dispose()

        If foundRows.GetLength(0) = 1 Then

            Dim TotalPagoAplicar As Double

            Select Case Redondear(TotalAbono, 2)
                Case Is > Redondear(SaldoVenta, 2)
                    TotalPagoAplicar = SaldoVenta

                    ModPOS.Ejecuta("sp_paga_documento", _
                                                  "@ABNClave", AbonoClave, _
                                                  "@TipoDoc", foundRows(0)("TipoDocumento"), _
                                                  "@Documento", foundRows(0)("ID"), _
                                                  "@Pago", TotalPagoAplicar, _
                                                  "@AcumulaPuntos", AcumulaPuntos, _
                                                  "Tipo", TPago, _
                                                  "@Usuario", ModPOS.UsuarioActual)
                Case Is < Redondear(SaldoVenta, 2)
                    TotalPagoAplicar = TotalAbono

                    ModPOS.Ejecuta("sp_actualiza_saldo", _
                                   "@ABNClave", AbonoClave, _
                                   "@Pago", TotalPagoAplicar, _
                                   "@TipoDoc", foundRows(0)("TipoDocumento"), _
                                   "@Documento", foundRows(0)("ID"), _
                                   "Tipo", TPago, _
                                   "@Usuario", ModPOS.UsuarioActual)

                Case Is = Redondear(SaldoVenta, 2)
                    TotalPagoAplicar = SaldoVenta

                    ModPOS.Ejecuta("sp_paga_documento", _
                                   "@ABNClave", AbonoClave, _
                                   "@TipoDoc", foundRows(0)("TipoDocumento"), _
                                   "@Documento", foundRows(0)("ID"), _
                                   "@Pago", TotalPagoAplicar, _
                                   "@AcumulaPuntos", AcumulaPuntos, _
                                   "Tipo", TPago, _
                                   "@Usuario", ModPOS.UsuarioActual)
            End Select

        Else
            Dim SaldoDisponible As Double
            SaldoDisponible = TotalAbono

            For i = 0 To foundRows.GetUpperBound(0)

                Select Case Redondear(SaldoDisponible, 2)
                    Case Is > Redondear(foundRows(i)("Saldo"), 2)
                        ModPOS.Ejecuta("sp_paga_documento", _
                                                      "@ABNClave", AbonoClave, _
                                                      "@TipoDoc", foundRows(i)("TipoDocumento"), _
                                                      "@Documento", foundRows(i)("ID"), _
                                                      "@Pago", foundRows(i)("Saldo"), _
                                                      "@AcumulaPuntos", AcumulaPuntos, _
                                                      "Tipo", TPago, _
                                                      "@Usuario", ModPOS.UsuarioActual)
                        SaldoDisponible -= foundRows(i)("Saldo")
                    Case Is < Redondear(foundRows(i)("Saldo"), 2)
                        ModPOS.Ejecuta("sp_actualiza_saldo", _
                                       "@ABNClave", AbonoClave, _
                                       "@Pago", SaldoDisponible, _
                                       "@TipoDoc", foundRows(i)("TipoDocumento"), _
                                       "@Documento", foundRows(i)("ID"), _
                                       "Tipo", TPago, _
                                       "@Usuario", ModPOS.UsuarioActual)
                        SaldoDisponible -= SaldoDisponible

                    Case Is = Redondear(foundRows(i)("Saldo"), 2)
                        ModPOS.Ejecuta("sp_paga_documento", _
                                       "@ABNClave", AbonoClave, _
                                       "@TipoDoc", foundRows(i)("TipoDocumento"), _
                                       "@Documento", foundRows(i)("ID"), _
                                       "@Pago", foundRows(i)("Saldo"), _
                                       "@AcumulaPuntos", AcumulaPuntos, _
                                       "Tipo", TPago, _
                                       "@Usuario", ModPOS.UsuarioActual)
                        SaldoDisponible -= SaldoDisponible
                End Select

                If SaldoDisponible <= 0 Then
                    Exit For
                End If
            Next
        End If


        If TotalAbono > 0 Then

            If bShowCambio = True Then

                Dim msg As New FrmMeMsg
                If TPago = 1 Then
                    msg.TxtTiulo = "Su Cambio es:"
                Else
                    msg.TxtTiulo = "Su Saldo a favor es:"
                End If
                msg.TxtMsg = Format(CStr(ModPOS.Redondear(TotalCambio, 2)), "Currency")
                msg.TxtMsg2 = Letras(CStr(ModPOS.Redondear(TotalCambio, 2))).ToUpper
                msg.ShowDialog()
                msg.Dispose()

                Dim RazonSocial As String

                Select Case MessageBox.Show("¿Desea imprimir un recibo de los pagos realizados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes

                        Dim dt As DataTable
                        dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", CTEClave)

                        RazonSocial = dt.Rows(0)("RazonSocial")
                        dt.Dispose()

                        imprimeRecibo(AbonoClave, TotalAbono, TotalCambio, Impresora, PrintGeneric, Recibo, LblUsuario.Text, RazonSocial)

                        Dim bReimprimir As Boolean = True
                        Do
                            Select Case MessageBox.Show("¿Desea reimprimir un recibo de los pagos realizados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                Case DialogResult.Yes
                                    imprimeRecibo(AbonoClave, TotalAbono, TotalCambio, Impresora, PrintGeneric, Recibo, LblUsuario.Text, RazonSocial)
                                Case Else
                                    bReimprimir = False
                            End Select
                        Loop While bReimprimir = True

                    Case Else
                End Select

            End If
            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", CTEClave, "@Importe", TotalAbono)


        End If

    End Sub

    Private Sub BtnPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPago.Click
        If cobranzaGeneral Then
            If Not dtCxC Is Nothing Then

                Dim foundRows() As DataRow

                foundRows = dtCxC.Select("Marca ='True' and Saldo > 0")

                If foundRows.GetLength(0) > 0 Then

                    If ModPOS.SiExite(ModPOS.BDConexion, "sp_aplicar_abn", "@CTEClave", foundRows(0)("CTEClave")) > 0 Then
                        Dim b As New FrmAbnPendiente
                        b.Cliente = foundRows(0)("CTEClave")
                        b.CAJClave = Me.CAJClave
                        b.SaldoDocumento = dSaldo
                        b.ShowDialog()

                        If b.DialogResult = DialogResult.OK Then
                            If Not b.drAbonos Is Nothing AndAlso b.drAbonos.Length > 0 Then
                                Dim i As Integer
                                For i = 0 To b.drAbonos.Length - 1
                                    Aplica_Pagos(foundRows, foundRows(0)("CTEClave"), b.drAbonos(i)("ID"), b.drAbonos(i)("TipoPago"), b.drAbonos(i)("Saldo"), dSaldo, IIf(b.drAbonos(i)("Saldo") > dSaldo, b.drAbonos(i)("Saldo") - dSaldo, 0), False)
                                Next
                                dtCxC.Dispose()

                                AgregarFolio()
                                Exit Sub
                            End If
                        End If
                    End If

                    Dim a As New FrmAbono
                    a.Aplicacion = Aplicacion
                    a.VariosPagos = IIf(foundRows.GetLength(0) = 1, False, True)
                    a.TipoDocumento = foundRows(0)("TipoDocumento")
                    a.CAJA = CAJClave
                    a.ClaveCte = foundRows(0)("CTEClave")
                    a.ClaveDocumento = foundRows(0)("ID")
                    a.SaldoAcumulado = dSaldo
                    a.AperturaCajon = Cajon
                    a.ImpresoraCajon = Impresora
                    a.ShowDialog()

                    If a.DialogResult = DialogResult.OK Then
                        Aplica_Pagos(foundRows, foundRows(0)("CTEClave"), a.AbonoClave, a.TPago, a.TotalAbono, a.SaldoVenta, a.TotalCambio, True)
                        dtCxC.Dispose()
                        AgregarFolio()
                        RetiroProgramado()
                    End If

                    chkIncluir.Enabled = False
                Else
                    MessageBox.Show("Debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Else 'Tab de CXC
            PagoCreditos()
        End If
    End Sub

    Public Sub RetiroProgramado()
        'Solicita Retiro de Caja
        If LEfectivo > 0 OrElse LCheques > 0 OrElse LVales > 0 Then
            Dim dt As DataTable
            dt = SiExisteRecupera("sp_limite_caja", "@CAJClave", CAJClave, "@Fecha", Today)
            Dim bRetirar As Boolean = False
            Dim MontoEfectivo, MontoCheques, MontoVales As Double
            Dim retiroEfectivo, retiroCheques, retiroVales As Double
            Dim aperturaEfectivo, aperturaCheques, aperturaVales As Double

            If Not dt Is Nothing Then
                Dim fila As Integer
                For fila = 0 To dt.Rows.Count - 1
                    Select Case CInt(dt.Rows(fila)("TipoPago"))
                        Case Is = 1
                            If LEfectivo < (CDbl(dt.Rows(fila)("Monto")) - CDbl(dt.Rows(fila)("Retiro"))) Then
                                MontoEfectivo = CDbl(dt.Rows(fila)("Monto"))
                                retiroEfectivo = CDbl(dt.Rows(fila)("Retiro"))
                                aperturaEfectivo = CDbl(dt.Rows(fila)("Apertura"))

                                bRetirar = True

                            End If
                        Case Is = 2
                            If LCheques < (CDbl(dt.Rows(fila)("Monto")) - CDbl(dt.Rows(fila)("Retiro"))) Then
                                MontoCheques = CDbl(dt.Rows(fila)("Monto"))
                                retiroCheques = CDbl(dt.Rows(fila)("Retiro"))
                                aperturaCheques = CDbl(dt.Rows(fila)("Apertura"))

                                bRetirar = True

                            End If
                        Case Is = 4
                            If LVales < (CDbl(dt.Rows(fila)("Monto")) - CDbl(dt.Rows(fila)("Retiro"))) Then
                                MontoVales = CDbl(dt.Rows(fila)("Monto"))
                                retiroVales = CDbl(dt.Rows(fila)("Retiro"))
                                aperturaVales = CDbl(dt.Rows(fila)("Apertura"))
                                bRetirar = True

                            End If
                    End Select
                Next
                If bRetirar Then
                    Dim a As New FrmRetiroCaja
                    a.SUCClave = SUCClave
                    a.ALMClave = ALMClave
                    a.CAJClave = CAJClave
                    a.Impresora = Impresora
                    a.Generic = PrintGeneric
                    a.Ticket = Recibo
                    a.Cajon = Cajon
                    a.MontoEfectivo = MontoEfectivo + aperturaEfectivo
                    a.MontoCheques = MontoCheques + aperturaCheques
                    a.MontoVales = MontoVales + aperturaVales
                    a.retiroEfectivo = retiroEfectivo
                    a.retiroCheques = retiroCheques
                    a.retiroVales = retiroVales
                    a.ShowDialog()
                End If
            End If
        End If

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
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_rec", "@ABNClave", Abono))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_rec", "@ABNClave", Abono))
        OpenReport.PrintPreview("Recibo", "CRRecibo.rpt", pvtaDataSet, "")
    End Sub

    Public Sub actualizaGridCreditos()
        Cursor.Current = Cursors.WaitCursor
        ModPOS.ActualizaGrid(False, Me.GridCreditos, "sp_obtener_cobranza", "@SUCClave", SUCClave)
        Me.GridCreditos.RootTable.Columns("CTEClave").Visible = False
     
        Me.GridCreditos.RootTable.Columns("Clave").Width = 30
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
        '        GridPendientes.RootTable.Columns("Serie").Selectable = False
        '       GridPendientes.RootTable.Columns("Folio").Selectable = False
        '      GridPendientes.RootTable.Columns("RFC").Selectable = False
        '     GridPendientes.RootTable.Columns("AnoAprobacion").Selectable = False
        '    GridPendientes.RootTable.Columns("noAprobacion").Selectable = False
        '   GridPendientes.RootTable.Columns("noCertificado").Selectable = False
        GridPendientes.RootTable.Columns("formaDePago").Visible = False
        GridPendientes.RootTable.Columns("RegimenFiscal").Visible = False
        '  GridPendientes.RootTable.Columns("Fecha").Selectable = False
        GridPendientes.RootTable.Columns("Descuento").Visible = False
        ' GridPendientes.RootTable.Columns("Impuesto").Selectable = False
        'GridPendientes.RootTable.Columns("Total").Selectable = False
        GridPendientes.RootTable.Columns("Moneda").Visible = False
        GridPendientes.RootTable.Columns("TipoCambio").Visible = False
        GridPendientes.RootTable.Columns("TipoCF").Visible = False
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

#Region "Aplica pagos fuera de funcion"
    'Dim dts As DataTable
    'Dim AcumulaPuntos As Integer
    'dts = ModPOS.Recupera_Tabla("sp_recupera_cte_mostrador", "@Cliente", a.CTEClave)
    'If dts.Rows(0)("POS") = 0 Then
    '    AcumulaPuntos = 1
    'Else
    '    AcumulaPuntos = 0
    'End If

    'dts.Dispose()

    'If foundRows.GetLength(0) = 1 Then

    '    Dim TotalPagoAplicar As Double

    '    Select Case a.TotalAbono
    '        Case Is > a.SaldoVenta
    '            TotalPagoAplicar = a.SaldoVenta

    '            ModPOS.Ejecuta("sp_paga_documento", _
    '                                          "@ABNClave", a.AbonoClave, _
    '                                          "@Tipo", CmbTipo.SelectedValue, _
    '                                          "@Documento", foundRows(0)(0), _
    '                                          "@Pago", TotalPagoAplicar, _
    '                                          "@AcumulaPuntos", AcumulaPuntos, _
    '                                          "@Usuario", ModPOS.UsuarioActual)
    '        Case Is < a.SaldoVenta
    '            TotalPagoAplicar = a.TotalAbono

    '            ModPOS.Ejecuta("sp_actualiza_saldo", _
    '                           "@ABNClave", a.AbonoClave, _
    '                           "@Pago", TotalPagoAplicar, _
    '                           "@Tipo", CmbTipo.SelectedValue, _
    '                           "@Documento", foundRows(0)(0), _
    '                           "@Usuario", ModPOS.UsuarioActual)

    '        Case Is = a.SaldoVenta
    '            TotalPagoAplicar = a.SaldoVenta

    '            ModPOS.Ejecuta("sp_paga_documento", _
    '                           "@ABNClave", a.AbonoClave, _
    '                           "@Tipo", CmbTipo.SelectedValue, _
    '                           "@Documento", foundRows(0)(0), _
    '                           "@Pago", TotalPagoAplicar, _
    '                           "@AcumulaPuntos", AcumulaPuntos, _
    '                           "@Usuario", ModPOS.UsuarioActual)
    '    End Select

    'Else
    '    Dim SaldoDisponible As Double
    '    SaldoDisponible = a.TotalAbono

    '    For i = 0 To foundRows.GetUpperBound(0)

    '        Select Case SaldoDisponible
    '            Case Is > foundRows(i)(7)
    '                ModPOS.Ejecuta("sp_paga_documento", _
    '                                              "@ABNClave", a.AbonoClave, _
    '                                              "@Tipo", CmbTipo.SelectedValue, _
    '                                              "@Documento", foundRows(i)(0), _
    '                                              "@Pago", foundRows(i)(7), _
    '                                              "@AcumulaPuntos", AcumulaPuntos, _
    '                                              "@Usuario", ModPOS.UsuarioActual)
    '                SaldoDisponible -= foundRows(i)(7)
    '            Case Is < foundRows(i)(7)
    '                ModPOS.Ejecuta("sp_actualiza_saldo", _
    '                               "@ABNClave", a.AbonoClave, _
    '                               "@Pago", SaldoDisponible, _
    '                               "@Tipo", CmbTipo.SelectedValue, _
    '                               "@Documento", foundRows(i)(0), _
    '                               "@Usuario", ModPOS.UsuarioActual)
    '                SaldoDisponible -= SaldoDisponible

    '            Case Is = foundRows(i)(7)
    '                ModPOS.Ejecuta("sp_paga_documento", _
    '                               "@ABNClave", a.AbonoClave, _
    '                               "@Tipo", CmbTipo.SelectedValue, _
    '                               "@Documento", foundRows(i)(0), _
    '                               "@Pago", SaldoDisponible, _
    '                               "@AcumulaPuntos", AcumulaPuntos, _
    '                               "@Usuario", ModPOS.UsuarioActual)
    '                SaldoDisponible -= SaldoDisponible
    '        End Select

    '        If SaldoDisponible <= 0 Then
    '            Exit For
    '        End If
    '    Next

    'End If


    'If a.TotalAbono > 0 Then
    '    Dim msg As New FrmMeMsg
    '    If a.TPago = 1 Then
    '        msg.TxtTiulo = "Su Cambio es:"
    '    Else
    '        msg.TxtTiulo = "Su Saldo a favor es:"
    '    End If
    '    msg.TxtMsg = Format(CStr(ModPOS.Redondear(a.TotalCambio, 2)), "Currency")
    '    msg.TxtMsg2 = Letras(CStr(a.TotalCambio)).ToUpper
    '    msg.ShowDialog()
    '    msg.Dispose()

    '    Select Case MessageBox.Show("¿Desea imprimir un recibo de los pagos realizados?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '        Case DialogResult.Yes
    '            imprimeRecibo(a.AbonoClave, a.TotalAbono, a.TotalCambio, Impresora, Recibo, LblUsuario.Text)
    '        Case Else
    '    End Select

    'End If
#End Region

    Private Sub BtnCancelaTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        If Not dtCxC Is Nothing Then

            Dim foundRows() As DataRow

            foundRows = dtCxC.Select("Marca ='True'")

            If foundRows.GetLength(0) = 1 Then


                If foundRows(0)("TipoDocumento") = 1 OrElse foundRows(0)("TipoDocumento") = 3 Then
                    If foundRows(0)(6) <> foundRows(0)(7) Then
                        MessageBox.Show("EL documento con Folio " & foundRows(0)(2) & " no es posible cancelarlo porque tiene pagos aplicados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
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

                                If foundRows(0)("TipoDocumento") = 1 Then 'Venta
                                    ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", foundRows(0)(0), "@TipoDoc", foundRows(0)("TipoDocumento"))

                                    ModPOS.GeneraMovInv(1, 5, 1, foundRows(0)(0), ALMClave, foundRows(0)(2), Autoriza)
                                    ModPOS.ActualizaExistAlm(1, 1, foundRows(0)(0), ALMClave)
                                    ModPOS.ActualizaExistUbc(1, 1, foundRows(0)(0), ALMClave)
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))

                                    ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(0)(0), "@Tipo", 1)

                                ElseIf foundRows(0)("TipoDocumento") = 2 Then 'Factura


                                    dt = Recupera_Tabla("sp_recupera_fac", "@FACClave", foundRows(0)(0))
                                    TipoCF = dt.Rows(0)("TipoCF")
                                    uuid = dt.Rows(0)("UUID")
                                    rfc = dt.Rows(0)("id_Fiscal")
                                    estado = dt.Rows(0)("estado")
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

                                        If ModPOS.cancelarXML(dtPAC, sFolio, uuid, eRFC) = False Then
                                            Exit Sub
                                        End If

                                    End If

                                    ModPOS.Ejecuta("sp_cancela_factura", "@FACClave", foundRows(0)(0))
                                    ModPOS.GeneraMovInv(1, 5, 2, foundRows(0)(0), ALMClave, foundRows(0)(2), Autoriza)
                                    ModPOS.ActualizaExistAlm(1, 2, foundRows(0)(0), ALMClave)
                                    ModPOS.ActualizaExistUbc(1, 2, foundRows(0)(0), ALMClave)

                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))

                                    ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", foundRows(0)(0), "@Tipo", 2)

                                    If TipoCF = 2 AndAlso estado <> 1 Then
                                        ModPOS.Ejecuta("sp_libera_pagos_fac", "@FACClave", foundRows(0)(0))
                                    End If

                                ElseIf foundRows(0)("TipoDocumento") = 3 Then 'Cargo
                                    ModPOS.Ejecuta("sp_cancela_cargo", "@CARClave", foundRows(0)(0))

                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))


                                ElseIf foundRows(0)("TipoDocumento") = 4 Then ' NC

                                    dt = Recupera_Tabla("sp_recupera_nc", "@NCClave", foundRows(0)(0))
                                    TipoCF = dt.Rows(0)("TipoCF")
                                    uuid = IIf(dt.Rows(0)("UUID").GetType.Name = "DBNull", "", dt.Rows(0)("UUID"))
                                    rfc = dt.Rows(0)("id_Fiscal")
                                    estado = dt.Rows(0)("estado")
                                    dt.Dispose()

                                    If TipoCF = 2 AndAlso estado = 1 Then


                                        Dim eRFC, sFolio As String
                                        dt = ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", foundRows(0)(0))
                                        eRFC = dt.Rows(0)("cRFC")
                                        sFolio = dt.Rows(0)("Serie") & dt.Rows(0)("Folio")
                                        dt.Dispose()

                                        If ModPOS.cancelarXML(dtPAC, sFolio, uuid, eRFC) = False Then
                                            Exit Sub
                                        End If

                                    End If

                                    ModPOS.Ejecuta("sp_cancela_nc", "@NCClave", foundRows(0)("ID"))

                                    'Actualiza el Saldo del Documento
                                    ModPOS.Ejecuta("sp_act_saldo_fac", "@NCClave", foundRows(0)("ID"))
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))

                                    'Si es de tipo devolución, realiza salida de producto de almacén

                                    If foundRows(0)("DevTipo") = 1 Then
                                        ModPOS.GeneraMovInv(2, 5, 4, foundRows(0)("ID"), ALMClave, foundRows(0)("Folio"), Autoriza)
                                        ModPOS.ActualizaExistAlm(2, 4, foundRows(0)("ID"), ALMClave)
                                        ModPOS.ActualizaExistUbc(2, 4, foundRows(0)("ID"), ALMClave)
                                    End If

                                ElseIf foundRows(0)("TipoDocumento") = 5 Then ' Devolución

                                    ModPOS.Ejecuta("sp_cancela_devolucion", "@DEVClave", foundRows(0)("ID"))

                                    'Actualiza el Saldo del Documento
                                    ModPOS.Ejecuta("sp_act_saldo_vta", "@DEVClave", foundRows(0)("ID"))
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))

                                    'Si es de tipo devolución, realiza salida de producto de almacén

                                    ModPOS.GeneraMovInv(2, 5, 3, foundRows(0)("ID"), ALMClave, foundRows(0)("Folio"), Autoriza)
                                    ModPOS.ActualizaExistAlm(2, 3, foundRows(0)("ID"), ALMClave)
                                    ModPOS.ActualizaExistUbc(2, 3, foundRows(0)("ID"), ALMClave)

                                ElseIf foundRows(0)("TipoDocumento") = 6 Then ' Nota Cargo

                                    dt = Recupera_Tabla("sp_recupera_cargo", "@CARClave", foundRows(0)(0))
                                    TipoCF = dt.Rows(0)("TipoCF")
                                    uuid = IIf(dt.Rows(0)("UUID").GetType.Name = "DBNull", "", dt.Rows(0)("UUID"))
                                    rfc = dt.Rows(0)("id_Fiscal")
                                    estado = dt.Rows(0)("estado")
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

                                        If ModPOS.cancelarXML(dtPAC, sFolio, uuid, eRFC) = False Then
                                            Exit Sub
                                        End If

                                    End If

                                    ModPOS.Ejecuta("sp_cancela_notacargo", "@CARClave", foundRows(0)("ID"))

                                    'Actualiza el Saldo del Documento
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total"))

                                    If TipoCF = 2 AndAlso estado <> 1 Then
                                        ModPOS.Ejecuta("sp_libera_pagos_fac", "@FACClave", foundRows(0)(0))
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
                ModPOS.Devolucion.LblDescripcion.Text = LblDescripcion.Text
                ModPOS.Devolucion.LblUsuario.Text = MPrincipal.StUsuario.Text
                ModPOS.Devolucion.SUCClave = SUCClave
                ModPOS.Devolucion.ALMClave = ALMClave
                ModPOS.Devolucion.Impresora = Impresora
                ModPOS.Devolucion.TicketDev = TICDevolucion
                ModPOS.Devolucion.Caja = LblDescripcion.Text
                ModPOS.Devolucion.Cajon = Cajon
                ModPOS.Devolucion.Ventas = foundRows
                ModPOS.Devolucion.bLiquidacion = True
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
                ModPOS.Devolucion.LblDescripcion.Text = LblDescripcion.Text
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
            fr = dtCxC.Select("Marca ='True' and TipoDocumento=1 and Cliente <> '" & foundRows(0)("Cliente") & "'")

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
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If a.ABNClave <> "" Then
                imprimirRecibo(a.ABNClave)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub BtnNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNC.Click

        Dim foundRows() As DataRow

        foundRows = dtCxC.Select("Marca ='True' and TipoDocumento = 2")

        If foundRows.GetLength(0) = 1 Then

            If ModPOS.NC Is Nothing Then
                ModPOS.NC = New FrmNC
                ModPOS.NC.ALMClave = ALMClave
                ModPOS.NC.SUCClave = SUCClave
                ModPOS.NC.CAJClave = CAJClave
                ModPOS.NC.Facturas = foundRows
                ModPOS.NC.bLiquidacion = True
            End If
            ModPOS.NC.StartPosition = FormStartPosition.CenterScreen
            ModPOS.NC.Show()
            If Not ModPOS.NC Is Nothing Then
                ModPOS.NC.BringToFront()
            End If

        Else
            If ModPOS.NC Is Nothing Then
                ModPOS.NC = New FrmNC
                ModPOS.NC.ALMClave = ALMClave
                ModPOS.NC.SUCClave = SUCClave
                ModPOS.NC.CAJClave = CAJClave
                ModPOS.NC.Cajon = Cajon
                ModPOS.NC.PrinterName = Impresora
            End If

            ModPOS.NC.StartPosition = FormStartPosition.CenterScreen
            ModPOS.NC.Show()
            If Not ModPOS.NC Is Nothing Then
                ModPOS.NC.BringToFront()
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
        If GridAnticipos.GetValue("Marca") = True Then
            dSaldoAnticipo += CDbl(GridAnticipos.GetValue("Saldo"))
        Else
            dSaldoAnticipo -= CDbl(GridAnticipos.GetValue("Saldo"))
        End If
        Me.LblSaldoAnticipos.Text = Format(CStr(ModPOS.Redondear(dSaldoAnticipo, 2)), "Currency")
    End Sub

    Private Sub GridAnticipos_CurrentCellChanging(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.CurrentCellChangingEventArgs) Handles GridAnticipos.CurrentCellChanging
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
        GridContrarecibos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
    End Sub

    Private Sub GridContrarecibos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridContrarecibos.DoubleClick
        editaContrarecibo()
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

 

    Private Sub Controls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, BtnPago.KeyUp, BtnCancelar.KeyUp, BtnDevolucion.KeyUp, BtnFacturar.KeyUp, BtnNC.KeyUp, BtnRecibo.KeyUp, BtnRetiro.KeyUp, BtnCambio.KeyUp, BtnRecalcular.KeyUp, BtnReimpresion.KeyUp, BtnComision.KeyUp, UiTab1.KeyUp, UiTabCXC.KeyUp, UiTabGeneral.KeyUp, GridCreditos.KeyUp, GridCxC.KeyUp, TxtFolio.KeyUp, GridPendientes.KeyUp, btnCertificar.KeyUp, btnRegenerar.KeyUp, cmbTipoTrans.KeyUp, btnCancel.KeyUp, btnAnticipo.KeyUp, GridAnticipos.KeyUp, GridContrarecibos.KeyUp, cmbEdoContrarecibo.KeyUp, dtPickerContrarecibo.KeyUp, btnEditContrarecibo.KeyUp, btnAddContrarecibo.KeyUp, btnNotaCargo.KeyUp, chkIncluir.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                Me.Close()
            Case Is = Keys.F2
                Me.btnNotaCargo.PerformClick()
            Case Is = Keys.F3
                Me.BtnRecalcular.PerformClick()
            Case Is = Keys.F4
                Me.BtnDevolucion.PerformClick()
            Case Is = Keys.F5
                Me.BtnPago.PerformClick()
            Case Is = Keys.F6
                Me.BtnCancelar.PerformClick()
            Case Is = Keys.F7
                BtnNC.PerformClick()
            Case Is = Keys.F8
                Me.BtnFacturar.PerformClick()
            Case Is = Keys.F9
                Me.BtnRecibo.PerformClick()
            Case Is = Keys.F10
                Me.BtnRetiro.PerformClick()
            Case Is = Keys.F11
                BtnApartados.PerformClick()
            Case Is = Keys.F12
                BtnCambio.PerformClick()
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
        a.PRNClavePic = PRNClavePic
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

    Private Sub BtnRecalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecalcular.Click
        If Not dtCxC Is Nothing Then

            Dim foundRows() As DataRow

            foundRows = dtCxC.Select("Marca ='True' and TipoDocumento = 1 and Saldo > 0")

            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                For i = 0 To foundRows.GetUpperBound(0)
                    ModPOS.Ejecuta("sp_recalcula_documento", _
                                   "@Tipo", foundRows(0)("TipoDocumento"), _
                                   "@Documento", foundRows(0)("ID"))
                Next
            Else
                MessageBox.Show("Debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub BtnReimpresion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click

        Dim i As Integer

        Dim foundRows() As DataRow

        ' Usa el metodo select para filtrar los registros seleccionados.
        foundRows = dtCxC.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then

            Dim sImpresora As String

            If Impresora <> "" Then
                Dim dtPrinter As DataTable = ModPOS.Recupera_Tabla("sp_recupera_print", "@PRNClave", ImpresoraFac)
                sImpresora = dtPrinter.Rows(0)("Referencia")
                dtPrinter.Dispose()
            Else
                If PrintDialog1.ShowDialog() = DialogResult.OK Then
                    sImpresora = PrintDialog1.PrinterSettings.PrinterName
                Else
                    Exit Sub
                End If
            End If

            For i = 0 To foundRows.GetUpperBound(0)

                Dim iTipoCF As Integer = IIf(foundRows(i)("TipoCF").GetType.Name = "DBNull", 1, foundRows(i)("TipoCF"))

                Dim MonRef, MonDesc As String
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
                        OpenReport.Print("CRPedido.rpt", pvtaDataSet, ModPOS.Letras(ModPOS.Redondear(foundRows(i)("Total"), 2)).ToUpper, sImpresora)





                    Case Is = 2 'FAC

                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "F", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        dt.Dispose()


                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "pvtaDataSet"

                        'OpenReport.PrintPreview("Factura", "CRFactura.rpt", pvtaDataSet, ModPOS.Letras(ModPOS.Redondear(TotalFactura, 2)).ToUpper)
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_fac", "@FACClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_fac", "@FACClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", foundRows(i)("ID")))

                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", foundRows(i)("ID")))

                        If iTipoCF = 1 Then
                            If FormatoFactura = "Clasico" Then
                                OpenReport.Print("CRIngresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)
                            Else
                                OpenReport.Print("CRIngresoNCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)
                            End If
                        ElseIf iTipoCF = 2 Then
                            If FormatoFactura = "Clasico" Then
                                OpenReport.Print("CRIngresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)
                            Else
                                OpenReport.Print("CRIngresoNCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)
                            End If
                        ElseIf iTipoCF = 3 Then
                            OpenReport.Print("CRIngresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)
                        End If

                    Case Is = 4 'NC
                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "N", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        dt.Dispose()

                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "pvtaDataSet"

                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_detalle", "@NCClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_impuestos", "@NCClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_referencia_factura", "@NCClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_nc", "@NCClave", foundRows(i)("ID")))

                        If iTipoCF = 1 Then
                            OpenReport.Print("CREgresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)
                        ElseIf iTipoCF = 2 Then
                            OpenReport.Print("CREgresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)

                        ElseIf iTipoCF = 3 Then
                            OpenReport.Print("CREgresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)

                        End If

                    Case Is = 5 'Devolucion

                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_dev", "@DEVClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_devolucion_det", "@DEVClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                        pvtaDataSet.DataSetName = "pvtaDataSet"
                        OpenReport.Print("CRDevolucion.rpt", pvtaDataSet, ModPOS.Letras(ModPOS.Redondear(foundRows(i)("Total"), 2)).ToUpper, sImpresora)


                    Case Is = 6 'Nota de Cargo

                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "C", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        dt.Dispose()

                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "pvtaDataSet"

                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_cargo", "@CARClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_cargo", "@CARClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_cargo", "@CARClave", foundRows(i)("ID")))

                        OpenReport.Print("CRNotaCargo.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)

                End Select

                foundRows(i)("Marca") = False
            Next
            ChkMarcaTodos.Checked = False
            chkIncluir.Checked = False
            dSaldo = IIf(dtCxC.Compute("Sum(Saldo)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(Saldo)", "Marca = True"))
            Me.LblSaldo.Text = Format(CStr(ModPOS.Redondear(dSaldo, 2)), "Currency")

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
                Me.cobranzaGeneral = True
            Case "UiTabPendientes"
                actualizaGridPendientes()
            Case "UiTabAnticipos"
                actualizaAnticipos()

            Case "UiTabContrarecibos"
                actualizaContrarecibos()
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
                For i = 0 To dtCxC.Rows.Count - 1
                    dtCxC.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dtCxC.Rows.Count - 1
                    dtCxC.Rows(i)("Marca") = False
                Next
            End If
            dSaldo = IIf(dtCxC.Compute("Sum(Saldo)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(Saldo)", "Marca = True"))
            Me.LblSaldo.Text = Format(CStr(ModPOS.Redondear(dSaldo, 2)), "Currency")
        End If

    End Sub

    Private Sub GridCxC_CellValueChanged1(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridCxC.CellValueChanged
        If GridCxC.GetValue("Marca") = True Then
            dSaldo += CDbl(IIf(GridCxC.GetValue("Saldo").GetType.Name = "DBNull", 0, GridCxC.GetValue("Saldo")))
        Else
            dSaldo -= CDbl(IIf(GridCxC.GetValue("Saldo").GetType.Name = "DBNull", 0, GridCxC.GetValue("Saldo")))
        End If
        Me.LblSaldo.Text = Format(CStr(ModPOS.Redondear(dSaldo, 2)), "Currency")

    End Sub

    Private Sub GridCxC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridCxC.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnPago.PerformClick()
        End If

    End Sub

    Private Sub TxtFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFolio.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtFolio.Text <> "" Then
                Dim foundRows() As DataRow
                foundRows = dtCxC.Select("Folio ='" & TxtFolio.Text.ToUpper & "'")
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
                iTipoPAC = ModPOS.crearXML(2, dtPAC, PathXML, GridPendientes.GetValue("Serie") & GridPendientes.GetValue("Folio"), sPendienteSelected, GridPendientes.GetValue("tipoDeComprobante"), Nothing, Nothing, Nothing, iTipoComprobante)
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
                Dim dt, dtConcepto, dtImpuesto As DataTable
                Dim oCFD As New CFD


                Dim foundRows() As DataRow
                foundRows = dtPendientes.Select("Clave='" & sPendienteSelected & "'")

                Dim frmStatusMessage As New frmStatus
                frmStatusMessage.Show("Regenerando Comprobantes Fiscales Digitales...")

                oCFD.TipoCF = GridPendientes.GetValue("TipoCF")

                'Recupera información del Emisor

                dt = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)

                oCFD.eRazonSocial = dt.Rows(0)("Nombre")
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
                                Customerkey = foundRows2(0)("CustomerKey")
                            End If
                        End If
                        Dim CBB() As Byte = Nothing

                        CBB = ModPOS.crearQR(oCFD.eRFC, foundRows(i)("RFC"), foundRows(i)("Total"), foundRows(i)("UUID"))

                        ModPOS.Ejecuta("sp_actualiza_cbb", "@Tipo", foundRows(i)("TipoDeComprobante"), "@DOCClave", foundRows(i)("Clave"), "@CBB", CBB, "@TipoComprobante", foundRows(i)("tipo"))

                        Dim consulta As String = BuscarCFDiTimbre(UserId, Customerkey, oCFD.eRFC, foundRows(i)("Serie") & foundRows(i)("Folio"), foundRows(i)("UUID"))

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

                        ' Generar CFD

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
                        oCFD.TImpuesto = dt.Rows(0)("TImpuesto")
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
                        'SUCClave = dt.Rows(0)("SUCClave")

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

                        oCFD.NoDesglosaIEPS = dt.Rows(0)("DesglosaIVA")

                        If oCFD.Referencia = "" Then
                            oCFD.Referencia = "SIN REFERENCIA"
                        End If

                        If oCFD.noInterior <> "" Then
                            oCFD.brnoInterior = True
                        Else
                            oCFD.brnoInterior = False
                        End If

                        dt.Dispose()



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

                                oCFD.metodoDePago &= CStr(dtMetodoPagos.Rows(j)("MetodoPago"))

                                If dtMetodoPagos.Rows(j)("Banco") <> "" Then
                                    oCFD.metodoDePago &= " " & CStr(dtMetodoPagos.Rows(j)("Banco"))
                                End If

                                oCFD.NumCtaPago &= CStr(dtMetodoPagos.Rows(j)("Referencia"))
                            Next

                        End If
                        '99
                        oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", foundRows(i)("Fecha"))
                        oCFD.Moneda = foundRows(i)("Moneda")
                        oCFD.TipoCambio = foundRows(i)("TipoCambio")
                        'Me.CargaDatosCliente(foundRows(i)("Cliente"))
                        dtConcepto = ModPOS.Recupera_Tabla("sp_recupera_elemento", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", foundRows(i)("Tipo"), "@Clave", foundRows(i)("Clave"))
                        dtImpuesto = ModPOS.Recupera_Tabla("sp_recupera_imp_elemento", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", foundRows(i)("Tipo"), "@Clave", foundRows(i)("Clave"))

                        oCFD.DOCClave = foundRows(i)("Clave")


                        Dim iTipoComprobante As Integer
                        Select Case CInt(foundRows(i)("Tipo"))
                            Case Is = 0
                                iTipoComprobante = 1
                            Case Is = (1 OrElse 2)
                                iTipoComprobante = 7
                            Case Is = 6
                                iTipoComprobante = 6
                        End Select


                        If oCFD.TipoCF = 1 Then
                            oCFD.cadenaOriginal = generarCadenaOriginal(oCFD, dtConcepto, dtImpuesto)
                        Else


                            oCFD.cadenaOriginal = generarCadenaOriginalCFDI(oCFD, dtConcepto, dtImpuesto, iTipoComprobante)
                        End If

                        oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave)

                        
                        ModPOS.crearXML(3, dtPAC, pathActual & "CFD\", oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, iTipoComprobante)


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
        BtnRecalcular.Enabled = True

        Select Case iTipo
            Case 1 'Venta y cargos

                Me.BtnNC.Enabled = False
            Case 2 'Factura
                Me.BtnDevolucion.Enabled = False
                Me.BtnRecalcular.Enabled = False
            Case 3 'NC
                BtnDevolucion.Enabled = False
                BtnRecalcular.Enabled = False
                BtnPago.Enabled = False
                BtnFacturar.Enabled = False
            Case 4 'Devolucion
                BtnRecalcular.Enabled = False
                BtnPago.Enabled = False
                BtnFacturar.Enabled = False
                BtnNC.Enabled = False
        End Select
    End Sub

    Private Sub cmbTipoTrans_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoTrans.SelectedIndexChanged
        If bload = True AndAlso Not cmbTipoTrans.SelectedValue Is Nothing Then
            preparaBotones(cmbTipoTrans.SelectedValue)
            If Not dtCxC Is Nothing Then
                dtCxC.Dispose()
                dSaldo = 0
                Me.LblSaldo.Text = Format(CStr(ModPOS.Redondear(dSaldo, 2)), "Currency")
                ChkMarcaTodos.Enabled = False
            End If
            AgregarFolio()
        End If




    End Sub


    Private Sub btnAnticipo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnticipo.Click
        Dim a As New FrmAbono
        a.bAnticipo = True
        a.Aplicacion = Aplicacion
        a.CAJA = CAJClave
        a.SaldoAcumulado = dSaldo
        a.AperturaCajon = Cajon
        a.ImpresoraCajon = Impresora
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.actualizaAnticipos()
            RetiroProgramado()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim foundRows() As DataRow
        foundRows = dtAnticipos.Select("Marca ='True'")
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
                    Next
                    Me.actualizaAnticipos()
                End If
            End If
        Else
            MessageBox.Show("Debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ChkAnticipos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAnticipos.CheckedChanged
        If dtAnticipos.Rows.Count > 0 Then
            Dim i As Integer
            If ChkAnticipos.Checked Then
                dSaldoAnticipo = 0
                For i = 0 To dtAnticipos.Rows.Count - 1
                    dtAnticipos.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dtAnticipos.Rows.Count - 1
                    dtAnticipos.Rows(i)("Marca") = False
                Next
            End If

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
                                If GridPendientes.GetValue("tipo") = 6 Then
                                    ModPOS.Ejecuta("sp_cancela_notacargo", "@CARClave", sPendienteSelected)
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", sCTEClave, "@Importe", dTotal)
                                    ModPOS.Ejecuta("sp_libera_pagos_fac", "@FACClave", sPendienteSelected)
                                Else
                                    ModPOS.Ejecuta("sp_cancela_factura", "@FACClave", sPendienteSelected)
                                    ModPOS.GeneraMovInv(1, 5, 2, sPendienteSelected, ALMClave, sFolio, Autoriza)
                                    ModPOS.ActualizaExistAlm(1, 2, sPendienteSelected, ALMClave)
                                    ModPOS.ActualizaExistUbc(1, 2, sPendienteSelected, ALMClave)
                                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", sCTEClave, "@Importe", dTotal)
                                    ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", sPendienteSelected, "@Tipo", 2)
                                    ModPOS.Ejecuta("sp_libera_pagos_fac", "@FACClave", sPendienteSelected)
                                End If
                            Else
                                ModPOS.Ejecuta("sp_cancela_nc", "@NCClave", sPendienteSelected)

                                'Actualiza el Saldo del Documento
                                ModPOS.Ejecuta("sp_act_saldo_fac", "@NCClave", sPendienteSelected)
                                ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", sCTEClave, "@Importe", dTotal)


                                'Si es de tipo devolución, realiza salida de producto de almacén

                                If iTipo = 1 Then
                                    ModPOS.GeneraMovInv(2, 5, 4, sPendienteSelected, ALMClave, sFolio, Autoriza)
                                    ModPOS.ActualizaExistAlm(2, 4, sPendienteSelected, ALMClave)
                                    ModPOS.ActualizaExistUbc(2, 4, sPendienteSelected, ALMClave)
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

    Private Sub picKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picKeyboard.Click
        Process.Start("osk.exe")
    End Sub

    Private Sub picSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picSalir.Click
        Me.Close()
    End Sub

    Private Sub UiTabPendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiTabPendientes.Click

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

    Private Sub editaContrarecibo()
        If sContrareciboSelected <> "" Then
            Dim a As New FrmContrarecibo
            a.Padre = "Modificar"
            a.FACClave = sContrareciboSelected
            a.ShowDialog()
        End If
    End Sub

    Private Sub btnEditContrarecibo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditContrarecibo.Click
        editaContrarecibo()
    End Sub

    Private Sub GridContrarecibos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridContrarecibos.SelectionChanged
        If Not GridContrarecibos.GetValue("FACClave") Is Nothing Then
            sContrareciboSelected = GridContrarecibos.GetValue("FACClave")
        Else
            sContrareciboSelected = ""
        End If
    End Sub

    Private Sub btnAddContrarecibo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddContrarecibo.Click
        Dim a As New FrmContrarecibo
        a.Padre = "Agregar"
        a.ShowDialog()
    End Sub

  
    Private Sub btnNotaCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotaCargo.Click
        If ModPOS.NotaCargo Is Nothing Then
            ModPOS.NotaCargo = New FrmNotaCargo
            ModPOS.NotaCargo.SUCClave = SUCClave
            ModPOS.NotaCargo.CAJClave = CAJClave
        End If

        ModPOS.NotaCargo.StartPosition = FormStartPosition.CenterScreen
        ModPOS.NotaCargo.Show()
        If Not ModPOS.NotaCargo Is Nothing Then
            ModPOS.NotaCargo.BringToFront()
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

                Dim MonRef, MonDesc As String
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
                        OpenReport.PrintPreview("Pedido", "CRPedido.rpt", pvtaDataSet, ModPOS.Letras(ModPOS.Redondear(foundRows(i)("Total"), 2)).ToUpper)

                        

                    Case Is = 2 'FAC

                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "F", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        dt.Dispose()


                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "pvtaDataSet"

                        'OpenReport.PrintPreview("Factura", "CRFactura.rpt", pvtaDataSet, ModPOS.Letras(ModPOS.Redondear(TotalFactura, 2)).ToUpper)
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_fac", "@FACClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_fac", "@FACClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", foundRows(i)("ID")))

                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", foundRows(i)("ID")))

                        If iTipoCF = 1 Then
                            If FormatoFactura = "Clasico" Then
                                OpenReport.PrintPreview("Factura", "CRIngresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper)
                            Else
                                OpenReport.PrintPreview("Factura", "CRIngresoNCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper)
                            End If
                        ElseIf iTipoCF = 2 Then
                            If FormatoFactura = "Clasico" Then
                                OpenReport.PrintPreview("Factura", "CRIngresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper)
                            Else
                                OpenReport.PrintPreview("Factura", "CRIngresoNCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper)
                            End If
                        ElseIf iTipoCF = 3 Then
                            OpenReport.PrintPreview("Factura", "CRIngresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper)
                        End If

                    Case Is = 4 'NC
                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "N", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        dt.Dispose()

                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "pvtaDataSet"

                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_detalle", "@NCClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_impuestos", "@NCClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_referencia_factura", "@NCClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_nc", "@NCClave", foundRows(i)("ID")))

                        If iTipoCF = 1 Then
                            OpenReport.PrintPreview("Nota de Crédito", "CREgresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper)
                        ElseIf iTipoCF = 2 Then
                            OpenReport.PrintPreview("Nota de Crédito", "CREgresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper)

                        ElseIf iTipoCF = 3 Then
                            OpenReport.PrintPreview("Nota de Crédito", "CREgresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper)

                        End If

                    Case Is = 5 'Devolucion

                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_dev", "@DEVClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_devolucion_det", "@DEVClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                        pvtaDataSet.DataSetName = "pvtaDataSet"
                        OpenReport.PrintPreview("Devolución", "CRDevolucion.rpt", pvtaDataSet, ModPOS.Letras(ModPOS.Redondear(foundRows(i)("Total"), 2)).ToUpper)


                    Case Is = 6 'Nota de Cargo

                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "C", "@Documento", foundRows(i)("ID"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        dt.Dispose()

                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "pvtaDataSet"

                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_cargo", "@CARClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_cargo", "@CARClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", foundRows(i)("ID")))
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_cargo", "@CARClave", foundRows(i)("ID")))

                        OpenReport.PrintPreview("Nota de Cargo", "CRNotaCargo.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(foundRows(i)("Total") / TipoCambio, 2), MonDesc, MonRef).ToUpper)

                End Select
                foundRows(i)("Marca") = False
            Next
            ChkMarcaTodos.Checked = False
            chkIncluir.Checked = False
            dSaldo = IIf(dtCxC.Compute("Sum(Saldo)", "Marca = True") Is System.DBNull.Value, 0, dtCxC.Compute("Sum(Saldo)", "Marca = True"))
            Me.LblSaldo.Text = Format(CStr(ModPOS.Redondear(dSaldo, 2)), "Currency")

        Else
            MessageBox.Show("Para reimprimir, debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

  
End Class
