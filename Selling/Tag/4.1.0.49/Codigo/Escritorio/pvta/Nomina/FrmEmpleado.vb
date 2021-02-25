Public Class FrmEmpleado
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
    Friend WithEvents UiTabCliente As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpDomicilio As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipoDomicilio As Selling.StoreCombo
    Friend WithEvents cmbColonia As Selling.StoreCombo
    Friend WithEvents cmbMnpio As Selling.StoreCombo
    Friend WithEvents cmbEstado As Selling.StoreCombo
    Friend WithEvents ChkDomicilio As Selling.ChkStatus
    Friend WithEvents cmbPais As Selling.StoreCombo
    Friend WithEvents BtnAceptarDomi As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpDomicilios As System.Windows.Forms.GroupBox
    Friend WithEvents GridDomicilios As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpSaldos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDelDomi As Janus.Windows.EditControls.UIButton
    Friend WithEvents NumDisponible As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents NumSaldo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents LblTipo As System.Windows.Forms.Label
    Friend WithEvents LblColonia As System.Windows.Forms.Label
    Friend WithEvents LblMnpio As System.Windows.Forms.Label
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents LblPais As System.Windows.Forms.Label
    Friend WithEvents LblSaldo As System.Windows.Forms.Label
    Friend WithEvents LblCredito As System.Windows.Forms.Label
    Friend WithEvents TxtCalle As System.Windows.Forms.TextBox
    Friend WithEvents LblCalle As System.Windows.Forms.Label
    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
    Friend WithEvents GridSaldos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GrpEmpleado As System.Windows.Forms.GroupBox
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents TxtRFC As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents BtnKey As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblPuesto As System.Windows.Forms.Label
    Friend WithEvents lblTipoRegimen As System.Windows.Forms.Label
    Friend WithEvents LblNumEmpleado As System.Windows.Forms.Label
    Friend WithEvents TxtNumEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents CmbTipoRegimen As Selling.StoreCombo
    Friend WithEvents grpNomina As System.Windows.Forms.GroupBox
    Friend WithEvents GrpContacto As System.Windows.Forms.GroupBox
    Friend WithEvents LblEmail As System.Windows.Forms.Label
    Friend WithEvents LblTel2 As System.Windows.Forms.Label
    Friend WithEvents LblTel1 As System.Windows.Forms.Label
    Friend WithEvents TxtTel2 As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents TxtContacto As System.Windows.Forms.TextBox
    Friend WithEvents LblContacto As System.Windows.Forms.Label
    Friend WithEvents TxtMail As System.Windows.Forms.TextBox
    Friend WithEvents TxtLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtNoInterior As System.Windows.Forms.TextBox
    Friend WithEvents TxtNoExterior As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents PictureBox24 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox23 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents lblDepto As System.Windows.Forms.Label
    Friend WithEvents GrpMetodos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridMetodos As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnElimina As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModifica As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtCURP As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents TxtNSS As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtPuesto As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbTipoContrato As Selling.StoreCombo
    Friend WithEvents lblTipoContrato As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtColoniaFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtMunicipioFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtEstadoFac As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtNoInteriorFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtNoExteriorFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtCPFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtDomicilioFac As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbPaisFac As Selling.StoreCombo
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoJornada As Selling.StoreCombo
    Friend WithEvents lblTipoJornada As System.Windows.Forms.Label
    Friend WithEvents dFechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbPeriodicidadPago As Selling.StoreCombo
    Friend WithEvents lblPeriodicidad As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCLABE As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipoBanco As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSalarioDiario As System.Windows.Forms.Label
    Friend WithEvents lblSalarioBase As System.Windows.Forms.Label
    Friend WithEvents txtSalarioDiario As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtSalarioBase As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents dVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbTipoLicencia As Selling.StoreCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TxtNumLicencia As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox15 As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbSucursalD As Selling.StoreCombo
    Friend WithEvents cmbTipoEmpleado As Selling.StoreCombo
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkSindicalizado As Selling.ChkStatus
    Friend WithEvents PictureBox17 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbPaisLabora As Selling.StoreCombo
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents PictureBox18 As System.Windows.Forms.PictureBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbEdoLabora As Selling.StoreCombo
    Friend WithEvents TxtTel1 As Janus.Windows.GridEX.EditControls.MaskedEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEmpleado))
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabCliente = New Janus.Windows.UI.Tab.UITabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GrpEmpleado = New System.Windows.Forms.GroupBox()
        Me.PictureBox16 = New System.Windows.Forms.PictureBox()
        Me.cmbTipoEmpleado = New Selling.StoreCombo()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtCLABE = New System.Windows.Forms.TextBox()
        Me.cmbTipoBanco = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dFechaIngreso = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtColoniaFac = New System.Windows.Forms.TextBox()
        Me.TxtMunicipioFac = New System.Windows.Forms.TextBox()
        Me.TxtEstadoFac = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtNoInteriorFac = New System.Windows.Forms.TextBox()
        Me.TxtNoExteriorFac = New System.Windows.Forms.TextBox()
        Me.TxtCPFac = New System.Windows.Forms.TextBox()
        Me.TxtDomicilioFac = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmbPaisFac = New Selling.StoreCombo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtNSS = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtCURP = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.TxtRFC = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnKey = New Janus.Windows.EditControls.UIButton()
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblNumEmpleado = New System.Windows.Forms.Label()
        Me.TxtNumEmpleado = New System.Windows.Forms.TextBox()
        Me.grpNomina = New System.Windows.Forms.GroupBox()
        Me.cmbEdoLabora = New Selling.StoreCombo()
        Me.PictureBox18 = New System.Windows.Forms.PictureBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.PictureBox17 = New System.Windows.Forms.PictureBox()
        Me.cmbPaisLabora = New Selling.StoreCombo()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.ChkSindicalizado = New Selling.ChkStatus(Me.components)
        Me.PictureBox15 = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbSucursalD = New Selling.StoreCombo()
        Me.PictureBox14 = New System.Windows.Forms.PictureBox()
        Me.PictureBox13 = New System.Windows.Forms.PictureBox()
        Me.txtSalarioDiario = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TxtSalarioBase = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblSalarioDiario = New System.Windows.Forms.Label()
        Me.lblSalarioBase = New System.Windows.Forms.Label()
        Me.lblTipoContrato = New System.Windows.Forms.Label()
        Me.cmbPeriodicidadPago = New Selling.StoreCombo()
        Me.lblPeriodicidad = New System.Windows.Forms.Label()
        Me.cmbTipoJornada = New Selling.StoreCombo()
        Me.lblTipoJornada = New System.Windows.Forms.Label()
        Me.cmbTipoContrato = New Selling.StoreCombo()
        Me.TxtPuesto = New System.Windows.Forms.TextBox()
        Me.CmbTipoRegimen = New Selling.StoreCombo()
        Me.lblTipoRegimen = New System.Windows.Forms.Label()
        Me.lblPuesto = New System.Windows.Forms.Label()
        Me.lblDepto = New System.Windows.Forms.Label()
        Me.TxtDepartamento = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.cmbTipoLicencia = New Selling.StoreCombo()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TxtNumLicencia = New System.Windows.Forms.TextBox()
        Me.GrpContacto = New System.Windows.Forms.GroupBox()
        Me.LblEmail = New System.Windows.Forms.Label()
        Me.LblTel2 = New System.Windows.Forms.Label()
        Me.LblTel1 = New System.Windows.Forms.Label()
        Me.TxtTel2 = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.TxtContacto = New System.Windows.Forms.TextBox()
        Me.LblContacto = New System.Windows.Forms.Label()
        Me.TxtMail = New System.Windows.Forms.TextBox()
        Me.TxtTel1 = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.GrpDomicilio = New System.Windows.Forms.GroupBox()
        Me.PictureBox24 = New System.Windows.Forms.PictureBox()
        Me.PictureBox23 = New System.Windows.Forms.PictureBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtNoInterior = New System.Windows.Forms.TextBox()
        Me.TxtNoExterior = New System.Windows.Forms.TextBox()
        Me.TxtCodigoPostal = New System.Windows.Forms.TextBox()
        Me.TxtLocalidad = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.TxtCalle = New System.Windows.Forms.TextBox()
        Me.LblCalle = New System.Windows.Forms.Label()
        Me.BtnDelDomi = New Janus.Windows.EditControls.UIButton()
        Me.LblTipo = New System.Windows.Forms.Label()
        Me.LblColonia = New System.Windows.Forms.Label()
        Me.LblMnpio = New System.Windows.Forms.Label()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.LblPais = New System.Windows.Forms.Label()
        Me.BtnAceptarDomi = New Janus.Windows.EditControls.UIButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbTipoDomicilio = New Selling.StoreCombo()
        Me.cmbColonia = New Selling.StoreCombo()
        Me.cmbMnpio = New Selling.StoreCombo()
        Me.cmbEstado = New Selling.StoreCombo()
        Me.ChkDomicilio = New Selling.ChkStatus(Me.components)
        Me.cmbPais = New Selling.StoreCombo()
        Me.GrpDomicilios = New System.Windows.Forms.GroupBox()
        Me.GridDomicilios = New Janus.Windows.GridEX.GridEX()
        Me.GrpSaldos = New System.Windows.Forms.GroupBox()
        Me.LblSaldo = New System.Windows.Forms.Label()
        Me.NumSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.LblCredito = New System.Windows.Forms.Label()
        Me.NumDisponible = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.GridSaldos = New Janus.Windows.GridEX.GridEX()
        Me.GrpMetodos = New System.Windows.Forms.GroupBox()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GridMetodos = New Janus.Windows.GridEX.GridEX()
        Me.BtnElimina = New Janus.Windows.EditControls.UIButton()
        Me.BtnModifica = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabCliente.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GrpEmpleado.SuspendLayout()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNomina.SuspendLayout()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GrpContacto.SuspendLayout()
        Me.GrpDomicilio.SuspendLayout()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDomicilios.SuspendLayout()
        CType(Me.GridDomicilios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpSaldos.SuspendLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpMetodos.SuspendLayout()
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiTab1
        '
        Me.UiTab1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTab1.FlatBorderColor = System.Drawing.Color.LightSteelBlue
        Me.UiTab1.Location = New System.Drawing.Point(7, 0)
        Me.UiTab1.Name = "UiTab1"
        Me.UiTab1.Size = New System.Drawing.Size(781, 380)
        Me.UiTab1.TabIndex = 0
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabCliente})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabCliente
        '
        Me.UiTabCliente.Controls.Add(Me.Panel1)
        Me.UiTabCliente.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCliente.Name = "UiTabCliente"
        Me.UiTabCliente.Size = New System.Drawing.Size(779, 358)
        Me.UiTabCliente.TabStop = True
        Me.UiTabCliente.Text = "General"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.GrpEmpleado)
        Me.Panel1.Controls.Add(Me.grpNomina)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GrpContacto)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(780, 359)
        Me.Panel1.TabIndex = 1
        '
        'GrpEmpleado
        '
        Me.GrpEmpleado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpEmpleado.BackColor = System.Drawing.Color.Transparent
        Me.GrpEmpleado.Controls.Add(Me.PictureBox16)
        Me.GrpEmpleado.Controls.Add(Me.cmbTipoEmpleado)
        Me.GrpEmpleado.Controls.Add(Me.Label24)
        Me.GrpEmpleado.Controls.Add(Me.PictureBox11)
        Me.GrpEmpleado.Controls.Add(Me.PictureBox10)
        Me.GrpEmpleado.Controls.Add(Me.PictureBox9)
        Me.GrpEmpleado.Controls.Add(Me.PictureBox8)
        Me.GrpEmpleado.Controls.Add(Me.PictureBox7)
        Me.GrpEmpleado.Controls.Add(Me.PictureBox6)
        Me.GrpEmpleado.Controls.Add(Me.PictureBox5)
        Me.GrpEmpleado.Controls.Add(Me.PictureBox4)
        Me.GrpEmpleado.Controls.Add(Me.PictureBox3)
        Me.GrpEmpleado.Controls.Add(Me.PictureBox2)
        Me.GrpEmpleado.Controls.Add(Me.Label4)
        Me.GrpEmpleado.Controls.Add(Me.TxtCLABE)
        Me.GrpEmpleado.Controls.Add(Me.cmbTipoBanco)
        Me.GrpEmpleado.Controls.Add(Me.Label1)
        Me.GrpEmpleado.Controls.Add(Me.dFechaIngreso)
        Me.GrpEmpleado.Controls.Add(Me.Label2)
        Me.GrpEmpleado.Controls.Add(Me.TxtColoniaFac)
        Me.GrpEmpleado.Controls.Add(Me.TxtMunicipioFac)
        Me.GrpEmpleado.Controls.Add(Me.TxtEstadoFac)
        Me.GrpEmpleado.Controls.Add(Me.Label14)
        Me.GrpEmpleado.Controls.Add(Me.Label13)
        Me.GrpEmpleado.Controls.Add(Me.TxtNoInteriorFac)
        Me.GrpEmpleado.Controls.Add(Me.TxtNoExteriorFac)
        Me.GrpEmpleado.Controls.Add(Me.TxtCPFac)
        Me.GrpEmpleado.Controls.Add(Me.TxtDomicilioFac)
        Me.GrpEmpleado.Controls.Add(Me.Label3)
        Me.GrpEmpleado.Controls.Add(Me.Label5)
        Me.GrpEmpleado.Controls.Add(Me.Label6)
        Me.GrpEmpleado.Controls.Add(Me.Label7)
        Me.GrpEmpleado.Controls.Add(Me.CmbPaisFac)
        Me.GrpEmpleado.Controls.Add(Me.Label8)
        Me.GrpEmpleado.Controls.Add(Me.Label12)
        Me.GrpEmpleado.Controls.Add(Me.TxtNSS)
        Me.GrpEmpleado.Controls.Add(Me.Label23)
        Me.GrpEmpleado.Controls.Add(Me.Label9)
        Me.GrpEmpleado.Controls.Add(Me.TxtCURP)
        Me.GrpEmpleado.Controls.Add(Me.lblRFC)
        Me.GrpEmpleado.Controls.Add(Me.TxtRFC)
        Me.GrpEmpleado.Controls.Add(Me.PictureBox1)
        Me.GrpEmpleado.Controls.Add(Me.BtnKey)
        Me.GrpEmpleado.Controls.Add(Me.ChkEstado)
        Me.GrpEmpleado.Controls.Add(Me.TxtRazonSocial)
        Me.GrpEmpleado.Controls.Add(Me.Label11)
        Me.GrpEmpleado.Controls.Add(Me.LblNumEmpleado)
        Me.GrpEmpleado.Controls.Add(Me.TxtNumEmpleado)
        Me.GrpEmpleado.Location = New System.Drawing.Point(10, 9)
        Me.GrpEmpleado.Name = "GrpEmpleado"
        Me.GrpEmpleado.Size = New System.Drawing.Size(745, 305)
        Me.GrpEmpleado.TabIndex = 1
        Me.GrpEmpleado.TabStop = False
        Me.GrpEmpleado.Text = "Datos Personales"
        '
        'PictureBox16
        '
        Me.PictureBox16.Image = CType(resources.GetObject("PictureBox16.Image"), System.Drawing.Image)
        Me.PictureBox16.Location = New System.Drawing.Point(112, 44)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(17, 22)
        Me.PictureBox16.TabIndex = 118
        Me.PictureBox16.TabStop = False
        Me.PictureBox16.Visible = False
        '
        'cmbTipoEmpleado
        '
        Me.cmbTipoEmpleado.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoEmpleado.Location = New System.Drawing.Point(144, 38)
        Me.cmbTipoEmpleado.Name = "cmbTipoEmpleado"
        Me.cmbTipoEmpleado.Size = New System.Drawing.Size(206, 21)
        Me.cmbTipoEmpleado.TabIndex = 117
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(7, 41)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(109, 15)
        Me.Label24.TabIndex = 116
        Me.Label24.Text = "Tipo Empleado"
        '
        'PictureBox11
        '
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(426, 225)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(22, 23)
        Me.PictureBox11.TabIndex = 115
        Me.PictureBox11.TabStop = False
        Me.PictureBox11.Visible = False
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(112, 228)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(17, 22)
        Me.PictureBox10.TabIndex = 114
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(477, 198)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(22, 22)
        Me.PictureBox9.TabIndex = 113
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(112, 204)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(17, 21)
        Me.PictureBox8.TabIndex = 112
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(112, 177)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(17, 21)
        Me.PictureBox7.TabIndex = 111
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(376, 144)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(22, 23)
        Me.PictureBox6.TabIndex = 110
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(112, 147)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(17, 22)
        Me.PictureBox5.TabIndex = 109
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(295, 94)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(23, 23)
        Me.PictureBox4.TabIndex = 108
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(112, 97)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(17, 22)
        Me.PictureBox3.TabIndex = 107
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(112, 70)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(17, 22)
        Me.PictureBox2.TabIndex = 106
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(7, 254)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 15)
        Me.Label4.TabIndex = 105
        Me.Label4.Text = "Cuenta CLABE"
        '
        'TxtCLABE
        '
        Me.TxtCLABE.Location = New System.Drawing.Point(144, 248)
        Me.TxtCLABE.Name = "TxtCLABE"
        Me.TxtCLABE.Size = New System.Drawing.Size(263, 20)
        Me.TxtCLABE.TabIndex = 104
        '
        'cmbTipoBanco
        '
        Me.cmbTipoBanco.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoBanco.Location = New System.Drawing.Point(143, 274)
        Me.cmbTipoBanco.Name = "cmbTipoBanco"
        Me.cmbTipoBanco.Size = New System.Drawing.Size(264, 21)
        Me.cmbTipoBanco.TabIndex = 103
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 280)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Banco"
        '
        'dFechaIngreso
        '
        Me.dFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dFechaIngreso.Location = New System.Drawing.Point(143, 119)
        Me.dFechaIngreso.Name = "dFechaIngreso"
        Me.dFechaIngreso.Size = New System.Drawing.Size(86, 20)
        Me.dFechaIngreso.TabIndex = 101
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 18)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "Inicio Relación Laboral"
        '
        'TxtColoniaFac
        '
        Me.TxtColoniaFac.Location = New System.Drawing.Point(144, 199)
        Me.TxtColoniaFac.Name = "TxtColoniaFac"
        Me.TxtColoniaFac.Size = New System.Drawing.Size(263, 20)
        Me.TxtColoniaFac.TabIndex = 86
        '
        'TxtMunicipioFac
        '
        Me.TxtMunicipioFac.Location = New System.Drawing.Point(143, 172)
        Me.TxtMunicipioFac.Name = "TxtMunicipioFac"
        Me.TxtMunicipioFac.Size = New System.Drawing.Size(168, 20)
        Me.TxtMunicipioFac.TabIndex = 85
        '
        'TxtEstadoFac
        '
        Me.TxtEstadoFac.Location = New System.Drawing.Point(430, 142)
        Me.TxtEstadoFac.Name = "TxtEstadoFac"
        Me.TxtEstadoFac.Size = New System.Drawing.Size(198, 20)
        Me.TxtEstadoFac.TabIndex = 84
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(522, 226)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 16)
        Me.Label14.TabIndex = 98
        Me.Label14.Text = "No. Int."
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(409, 226)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 16)
        Me.Label13.TabIndex = 97
        Me.Label13.Text = "No. Ext."
        '
        'TxtNoInteriorFac
        '
        Me.TxtNoInteriorFac.Location = New System.Drawing.Point(572, 222)
        Me.TxtNoInteriorFac.Name = "TxtNoInteriorFac"
        Me.TxtNoInteriorFac.Size = New System.Drawing.Size(55, 20)
        Me.TxtNoInteriorFac.TabIndex = 90
        '
        'TxtNoExteriorFac
        '
        Me.TxtNoExteriorFac.Location = New System.Drawing.Point(463, 223)
        Me.TxtNoExteriorFac.Name = "TxtNoExteriorFac"
        Me.TxtNoExteriorFac.Size = New System.Drawing.Size(55, 20)
        Me.TxtNoExteriorFac.TabIndex = 89
        '
        'TxtCPFac
        '
        Me.TxtCPFac.Location = New System.Drawing.Point(505, 198)
        Me.TxtCPFac.Name = "TxtCPFac"
        Me.TxtCPFac.Size = New System.Drawing.Size(123, 20)
        Me.TxtCPFac.TabIndex = 87
        '
        'TxtDomicilioFac
        '
        Me.TxtDomicilioFac.Location = New System.Drawing.Point(144, 223)
        Me.TxtDomicilioFac.Name = "TxtDomicilioFac"
        Me.TxtDomicilioFac.Size = New System.Drawing.Size(263, 20)
        Me.TxtDomicilioFac.TabIndex = 88
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 228)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 15)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "Calle"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 201)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 17)
        Me.Label5.TabIndex = 94
        Me.Label5.Text = "Colonia"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(7, 177)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 14)
        Me.Label6.TabIndex = 93
        Me.Label6.Text = "Municipio"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(316, 146)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 15)
        Me.Label7.TabIndex = 92
        Me.Label7.Text = "Entidad/Estado"
        '
        'CmbPaisFac
        '
        Me.CmbPaisFac.Location = New System.Drawing.Point(144, 143)
        Me.CmbPaisFac.Name = "CmbPaisFac"
        Me.CmbPaisFac.Size = New System.Drawing.Size(167, 21)
        Me.CmbPaisFac.TabIndex = 83
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(7, 147)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 15)
        Me.Label8.TabIndex = 91
        Me.Label8.Text = "País"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(412, 201)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 15)
        Me.Label12.TabIndex = 96
        Me.Label12.Text = "Código Postal"
        '
        'TxtNSS
        '
        Me.TxtNSS.Location = New System.Drawing.Point(572, 92)
        Me.TxtNSS.Name = "TxtNSS"
        Me.TxtNSS.Size = New System.Drawing.Size(158, 20)
        Me.TxtNSS.TabIndex = 81
        Me.TxtNSS.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(532, 95)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(34, 17)
        Me.Label23.TabIndex = 80
        Me.Label23.Text = "NSS"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(276, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 16)
        Me.Label9.TabIndex = 79
        Me.Label9.Text = "CURP"
        '
        'TxtCURP
        '
        Me.TxtCURP.Location = New System.Drawing.Point(325, 93)
        Me.TxtCURP.Name = "TxtCURP"
        Me.TxtCURP.Size = New System.Drawing.Size(201, 20)
        Me.TxtCURP.TabIndex = 77
        Me.TxtCURP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'lblRFC
        '
        Me.lblRFC.Location = New System.Drawing.Point(7, 97)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(79, 16)
        Me.lblRFC.TabIndex = 55
        Me.lblRFC.Text = "RFC"
        '
        'TxtRFC
        '
        Me.TxtRFC.Location = New System.Drawing.Point(142, 93)
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.Size = New System.Drawing.Size(128, 20)
        Me.TxtRFC.TabIndex = 6
        Me.TxtRFC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(112, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(17, 22)
        Me.PictureBox1.TabIndex = 40
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnKey
        '
        Me.BtnKey.Image = CType(resources.GetObject("BtnKey.Image"), System.Drawing.Image)
        Me.BtnKey.Location = New System.Drawing.Point(292, 11)
        Me.BtnKey.Name = "BtnKey"
        Me.BtnKey.Size = New System.Drawing.Size(26, 21)
        Me.BtnKey.TabIndex = 1
        Me.BtnKey.ToolTipText = "Generar clave automatica"
        Me.BtnKey.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkEstado
        '
        Me.ChkEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Enabled = False
        Me.ChkEstado.Location = New System.Drawing.Point(554, 10)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(71, 22)
        Me.ChkEstado.TabIndex = 1
        Me.ChkEstado.Text = "Activo"
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Location = New System.Drawing.Point(143, 67)
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.Size = New System.Drawing.Size(482, 20)
        Me.TxtRazonSocial.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(7, 70)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(114, 18)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Nombre Completo"
        '
        'LblNumEmpleado
        '
        Me.LblNumEmpleado.Location = New System.Drawing.Point(7, 16)
        Me.LblNumEmpleado.Name = "LblNumEmpleado"
        Me.LblNumEmpleado.Size = New System.Drawing.Size(99, 15)
        Me.LblNumEmpleado.TabIndex = 1
        Me.LblNumEmpleado.Text = "NumEmpleado"
        '
        'TxtNumEmpleado
        '
        Me.TxtNumEmpleado.Location = New System.Drawing.Point(145, 12)
        Me.TxtNumEmpleado.Name = "TxtNumEmpleado"
        Me.TxtNumEmpleado.Size = New System.Drawing.Size(140, 20)
        Me.TxtNumEmpleado.TabIndex = 0
        '
        'grpNomina
        '
        Me.grpNomina.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpNomina.Controls.Add(Me.cmbEdoLabora)
        Me.grpNomina.Controls.Add(Me.PictureBox18)
        Me.grpNomina.Controls.Add(Me.Label26)
        Me.grpNomina.Controls.Add(Me.PictureBox17)
        Me.grpNomina.Controls.Add(Me.cmbPaisLabora)
        Me.grpNomina.Controls.Add(Me.Label25)
        Me.grpNomina.Controls.Add(Me.ChkSindicalizado)
        Me.grpNomina.Controls.Add(Me.PictureBox15)
        Me.grpNomina.Controls.Add(Me.Label15)
        Me.grpNomina.Controls.Add(Me.cmbSucursalD)
        Me.grpNomina.Controls.Add(Me.PictureBox14)
        Me.grpNomina.Controls.Add(Me.PictureBox13)
        Me.grpNomina.Controls.Add(Me.txtSalarioDiario)
        Me.grpNomina.Controls.Add(Me.TxtSalarioBase)
        Me.grpNomina.Controls.Add(Me.lblSalarioDiario)
        Me.grpNomina.Controls.Add(Me.lblSalarioBase)
        Me.grpNomina.Controls.Add(Me.lblTipoContrato)
        Me.grpNomina.Controls.Add(Me.cmbPeriodicidadPago)
        Me.grpNomina.Controls.Add(Me.lblPeriodicidad)
        Me.grpNomina.Controls.Add(Me.cmbTipoJornada)
        Me.grpNomina.Controls.Add(Me.lblTipoJornada)
        Me.grpNomina.Controls.Add(Me.cmbTipoContrato)
        Me.grpNomina.Controls.Add(Me.TxtPuesto)
        Me.grpNomina.Controls.Add(Me.CmbTipoRegimen)
        Me.grpNomina.Controls.Add(Me.lblTipoRegimen)
        Me.grpNomina.Controls.Add(Me.lblPuesto)
        Me.grpNomina.Controls.Add(Me.lblDepto)
        Me.grpNomina.Controls.Add(Me.TxtDepartamento)
        Me.grpNomina.Location = New System.Drawing.Point(10, 322)
        Me.grpNomina.MinimumSize = New System.Drawing.Size(728, 181)
        Me.grpNomina.Name = "grpNomina"
        Me.grpNomina.Size = New System.Drawing.Size(745, 223)
        Me.grpNomina.TabIndex = 2
        Me.grpNomina.TabStop = False
        Me.grpNomina.Text = "Condiciones Laborales"
        '
        'cmbEdoLabora
        '
        Me.cmbEdoLabora.Location = New System.Drawing.Point(469, 196)
        Me.cmbEdoLabora.Name = "cmbEdoLabora"
        Me.cmbEdoLabora.Size = New System.Drawing.Size(189, 21)
        Me.cmbEdoLabora.TabIndex = 141
        '
        'PictureBox18
        '
        Me.PictureBox18.Image = CType(resources.GetObject("PictureBox18.Image"), System.Drawing.Image)
        Me.PictureBox18.Location = New System.Drawing.Point(440, 198)
        Me.PictureBox18.Name = "PictureBox18"
        Me.PictureBox18.Size = New System.Drawing.Size(17, 22)
        Me.PictureBox18.TabIndex = 140
        Me.PictureBox18.TabStop = False
        Me.PictureBox18.Visible = False
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(355, 199)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(99, 15)
        Me.Label26.TabIndex = 139
        Me.Label26.Text = "Estado Labora"
        '
        'PictureBox17
        '
        Me.PictureBox17.Image = CType(resources.GetObject("PictureBox17.Image"), System.Drawing.Image)
        Me.PictureBox17.Location = New System.Drawing.Point(108, 200)
        Me.PictureBox17.Name = "PictureBox17"
        Me.PictureBox17.Size = New System.Drawing.Size(17, 22)
        Me.PictureBox17.TabIndex = 138
        Me.PictureBox17.TabStop = False
        Me.PictureBox17.Visible = False
        '
        'cmbPaisLabora
        '
        Me.cmbPaisLabora.Location = New System.Drawing.Point(140, 196)
        Me.cmbPaisLabora.Name = "cmbPaisLabora"
        Me.cmbPaisLabora.Size = New System.Drawing.Size(167, 21)
        Me.cmbPaisLabora.TabIndex = 136
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(7, 199)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(99, 15)
        Me.Label25.TabIndex = 137
        Me.Label25.Text = "País Labora"
        '
        'ChkSindicalizado
        '
        Me.ChkSindicalizado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkSindicalizado.Checked = True
        Me.ChkSindicalizado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkSindicalizado.Location = New System.Drawing.Point(554, 72)
        Me.ChkSindicalizado.Name = "ChkSindicalizado"
        Me.ChkSindicalizado.Size = New System.Drawing.Size(103, 22)
        Me.ChkSindicalizado.TabIndex = 119
        Me.ChkSindicalizado.Text = "Sindicalizado"
        '
        'PictureBox15
        '
        Me.PictureBox15.Image = CType(resources.GetObject("PictureBox15.Image"), System.Drawing.Image)
        Me.PictureBox15.Location = New System.Drawing.Point(111, 47)
        Me.PictureBox15.Name = "PictureBox15"
        Me.PictureBox15.Size = New System.Drawing.Size(18, 18)
        Me.PictureBox15.TabIndex = 135
        Me.PictureBox15.TabStop = False
        Me.PictureBox15.Visible = False
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(7, 47)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 14)
        Me.Label15.TabIndex = 134
        Me.Label15.Text = "Sucursal"
        '
        'cmbSucursalD
        '
        Me.cmbSucursalD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSucursalD.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSucursalD.Location = New System.Drawing.Point(141, 44)
        Me.cmbSucursalD.Name = "cmbSucursalD"
        Me.cmbSucursalD.Size = New System.Drawing.Size(204, 21)
        Me.cmbSucursalD.TabIndex = 133
        '
        'PictureBox14
        '
        Me.PictureBox14.Image = CType(resources.GetObject("PictureBox14.Image"), System.Drawing.Image)
        Me.PictureBox14.Location = New System.Drawing.Point(425, 109)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(17, 19)
        Me.PictureBox14.TabIndex = 117
        Me.PictureBox14.TabStop = False
        Me.PictureBox14.Visible = False
        '
        'PictureBox13
        '
        Me.PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), System.Drawing.Image)
        Me.PictureBox13.Location = New System.Drawing.Point(111, 19)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(18, 17)
        Me.PictureBox13.TabIndex = 116
        Me.PictureBox13.TabStop = False
        Me.PictureBox13.Visible = False
        '
        'txtSalarioDiario
        '
        Me.txtSalarioDiario.Location = New System.Drawing.Point(527, 166)
        Me.txtSalarioDiario.Name = "txtSalarioDiario"
        Me.txtSalarioDiario.Size = New System.Drawing.Size(130, 20)
        Me.txtSalarioDiario.TabIndex = 94
        Me.txtSalarioDiario.Text = "0.00"
        Me.txtSalarioDiario.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtSalarioDiario.Value = 0.0R
        Me.txtSalarioDiario.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtSalarioBase
        '
        Me.TxtSalarioBase.Location = New System.Drawing.Point(527, 139)
        Me.TxtSalarioBase.Name = "TxtSalarioBase"
        Me.TxtSalarioBase.Size = New System.Drawing.Size(130, 20)
        Me.TxtSalarioBase.TabIndex = 93
        Me.TxtSalarioBase.Text = "0.00"
        Me.TxtSalarioBase.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtSalarioBase.Value = 0.0R
        Me.TxtSalarioBase.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'lblSalarioDiario
        '
        Me.lblSalarioDiario.Location = New System.Drawing.Point(355, 169)
        Me.lblSalarioDiario.Name = "lblSalarioDiario"
        Me.lblSalarioDiario.Size = New System.Drawing.Size(125, 15)
        Me.lblSalarioDiario.TabIndex = 91
        Me.lblSalarioDiario.Text = "Salario Diario Integrado"
        '
        'lblSalarioBase
        '
        Me.lblSalarioBase.Location = New System.Drawing.Point(355, 142)
        Me.lblSalarioBase.Name = "lblSalarioBase"
        Me.lblSalarioBase.Size = New System.Drawing.Size(125, 15)
        Me.lblSalarioBase.TabIndex = 89
        Me.lblSalarioBase.Text = "Salario Base Cot. Aport."
        '
        'lblTipoContrato
        '
        Me.lblTipoContrato.Location = New System.Drawing.Point(7, 145)
        Me.lblTipoContrato.Name = "lblTipoContrato"
        Me.lblTipoContrato.Size = New System.Drawing.Size(90, 15)
        Me.lblTipoContrato.TabIndex = 83
        Me.lblTipoContrato.Text = "Tipo Contrato"
        '
        'cmbPeriodicidadPago
        '
        Me.cmbPeriodicidadPago.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPeriodicidadPago.Location = New System.Drawing.Point(469, 107)
        Me.cmbPeriodicidadPago.Name = "cmbPeriodicidadPago"
        Me.cmbPeriodicidadPago.Size = New System.Drawing.Size(188, 21)
        Me.cmbPeriodicidadPago.TabIndex = 88
        '
        'lblPeriodicidad
        '
        Me.lblPeriodicidad.Location = New System.Drawing.Point(354, 108)
        Me.lblPeriodicidad.Name = "lblPeriodicidad"
        Me.lblPeriodicidad.Size = New System.Drawing.Size(107, 21)
        Me.lblPeriodicidad.TabIndex = 87
        Me.lblPeriodicidad.Text = "Periodicidad Pago"
        '
        'cmbTipoJornada
        '
        Me.cmbTipoJornada.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoJornada.Location = New System.Drawing.Point(140, 165)
        Me.cmbTipoJornada.Name = "cmbTipoJornada"
        Me.cmbTipoJornada.Size = New System.Drawing.Size(205, 21)
        Me.cmbTipoJornada.TabIndex = 86
        '
        'lblTipoJornada
        '
        Me.lblTipoJornada.Location = New System.Drawing.Point(7, 167)
        Me.lblTipoJornada.Name = "lblTipoJornada"
        Me.lblTipoJornada.Size = New System.Drawing.Size(90, 15)
        Me.lblTipoJornada.TabIndex = 85
        Me.lblTipoJornada.Text = "Tipo Jornada"
        '
        'cmbTipoContrato
        '
        Me.cmbTipoContrato.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoContrato.Location = New System.Drawing.Point(141, 137)
        Me.cmbTipoContrato.Name = "cmbTipoContrato"
        Me.cmbTipoContrato.Size = New System.Drawing.Size(204, 21)
        Me.cmbTipoContrato.TabIndex = 84
        '
        'TxtPuesto
        '
        Me.TxtPuesto.Location = New System.Drawing.Point(142, 105)
        Me.TxtPuesto.Name = "TxtPuesto"
        Me.TxtPuesto.Size = New System.Drawing.Size(203, 20)
        Me.TxtPuesto.TabIndex = 82
        '
        'CmbTipoRegimen
        '
        Me.CmbTipoRegimen.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipoRegimen.Location = New System.Drawing.Point(142, 16)
        Me.CmbTipoRegimen.Name = "CmbTipoRegimen"
        Me.CmbTipoRegimen.Size = New System.Drawing.Size(515, 21)
        Me.CmbTipoRegimen.TabIndex = 4
        '
        'lblTipoRegimen
        '
        Me.lblTipoRegimen.Location = New System.Drawing.Point(7, 24)
        Me.lblTipoRegimen.Name = "lblTipoRegimen"
        Me.lblTipoRegimen.Size = New System.Drawing.Size(129, 15)
        Me.lblTipoRegimen.TabIndex = 3
        Me.lblTipoRegimen.Text = "Tipo Regimen"
        '
        'lblPuesto
        '
        Me.lblPuesto.Location = New System.Drawing.Point(7, 110)
        Me.lblPuesto.Name = "lblPuesto"
        Me.lblPuesto.Size = New System.Drawing.Size(74, 15)
        Me.lblPuesto.TabIndex = 23
        Me.lblPuesto.Text = "Puesto"
        '
        'lblDepto
        '
        Me.lblDepto.Location = New System.Drawing.Point(7, 80)
        Me.lblDepto.Name = "lblDepto"
        Me.lblDepto.Size = New System.Drawing.Size(76, 14)
        Me.lblDepto.TabIndex = 76
        Me.lblDepto.Text = "Departamento"
        '
        'TxtDepartamento
        '
        Me.TxtDepartamento.Location = New System.Drawing.Point(141, 75)
        Me.TxtDepartamento.Name = "TxtDepartamento"
        Me.TxtDepartamento.Size = New System.Drawing.Size(204, 20)
        Me.TxtDepartamento.TabIndex = 75
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.dVencimiento)
        Me.GroupBox1.Controls.Add(Me.cmbTipoLicencia)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.TxtNumLicencia)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 551)
        Me.GroupBox1.MinimumSize = New System.Drawing.Size(728, 82)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(745, 82)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Licencia"
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(359, 22)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(77, 15)
        Me.Label21.TabIndex = 103
        Me.Label21.Text = "Vencimiento"
        '
        'dVencimiento
        '
        Me.dVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dVencimiento.Location = New System.Drawing.Point(477, 19)
        Me.dVencimiento.Name = "dVencimiento"
        Me.dVencimiento.Size = New System.Drawing.Size(86, 20)
        Me.dVencimiento.TabIndex = 102
        '
        'cmbTipoLicencia
        '
        Me.cmbTipoLicencia.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoLicencia.Location = New System.Drawing.Point(140, 16)
        Me.cmbTipoLicencia.Name = "cmbTipoLicencia"
        Me.cmbTipoLicencia.Size = New System.Drawing.Size(206, 21)
        Me.cmbTipoLicencia.TabIndex = 89
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(7, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 15)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "Número"
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(8, 22)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(60, 15)
        Me.Label22.TabIndex = 34
        Me.Label22.Text = "Tipo"
        '
        'TxtNumLicencia
        '
        Me.TxtNumLicencia.Location = New System.Drawing.Point(140, 48)
        Me.TxtNumLicencia.Name = "TxtNumLicencia"
        Me.TxtNumLicencia.Size = New System.Drawing.Size(205, 20)
        Me.TxtNumLicencia.TabIndex = 4
        '
        'GrpContacto
        '
        Me.GrpContacto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpContacto.BackColor = System.Drawing.Color.Transparent
        Me.GrpContacto.Controls.Add(Me.LblEmail)
        Me.GrpContacto.Controls.Add(Me.LblTel2)
        Me.GrpContacto.Controls.Add(Me.LblTel1)
        Me.GrpContacto.Controls.Add(Me.TxtTel2)
        Me.GrpContacto.Controls.Add(Me.TxtContacto)
        Me.GrpContacto.Controls.Add(Me.LblContacto)
        Me.GrpContacto.Controls.Add(Me.TxtMail)
        Me.GrpContacto.Controls.Add(Me.TxtTel1)
        Me.GrpContacto.Location = New System.Drawing.Point(9, 637)
        Me.GrpContacto.MinimumSize = New System.Drawing.Size(728, 100)
        Me.GrpContacto.Name = "GrpContacto"
        Me.GrpContacto.Size = New System.Drawing.Size(746, 100)
        Me.GrpContacto.TabIndex = 3
        Me.GrpContacto.TabStop = False
        Me.GrpContacto.Text = "Contacto"
        '
        'LblEmail
        '
        Me.LblEmail.Location = New System.Drawing.Point(7, 69)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(60, 15)
        Me.LblEmail.TabIndex = 63
        Me.LblEmail.Text = "Email"
        '
        'LblTel2
        '
        Me.LblTel2.Location = New System.Drawing.Point(377, 44)
        Me.LblTel2.Name = "LblTel2"
        Me.LblTel2.Size = New System.Drawing.Size(62, 15)
        Me.LblTel2.TabIndex = 62
        Me.LblTel2.Text = "Celular"
        '
        'LblTel1
        '
        Me.LblTel1.Location = New System.Drawing.Point(7, 45)
        Me.LblTel1.Name = "LblTel1"
        Me.LblTel1.Size = New System.Drawing.Size(53, 15)
        Me.LblTel1.TabIndex = 61
        Me.LblTel1.Text = "Tel/Fax"
        '
        'TxtTel2
        '
        Me.TxtTel2.Location = New System.Drawing.Point(445, 42)
        Me.TxtTel2.Mask = "!(###) 000 00 0 00 00"
        Me.TxtTel2.Name = "TxtTel2"
        Me.TxtTel2.Size = New System.Drawing.Size(158, 20)
        Me.TxtTel2.TabIndex = 3
        Me.TxtTel2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'TxtContacto
        '
        Me.TxtContacto.Location = New System.Drawing.Point(141, 16)
        Me.TxtContacto.Name = "TxtContacto"
        Me.TxtContacto.Size = New System.Drawing.Size(463, 20)
        Me.TxtContacto.TabIndex = 1
        '
        'LblContacto
        '
        Me.LblContacto.Location = New System.Drawing.Point(7, 18)
        Me.LblContacto.Name = "LblContacto"
        Me.LblContacto.Size = New System.Drawing.Size(60, 14)
        Me.LblContacto.TabIndex = 34
        Me.LblContacto.Text = "Contacto"
        '
        'TxtMail
        '
        Me.TxtMail.Location = New System.Drawing.Point(141, 67)
        Me.TxtMail.Name = "TxtMail"
        Me.TxtMail.Size = New System.Drawing.Size(462, 20)
        Me.TxtMail.TabIndex = 4
        '
        'TxtTel1
        '
        Me.TxtTel1.Location = New System.Drawing.Point(141, 42)
        Me.TxtTel1.Mask = "!(##) 000 00 0 00 00"
        Me.TxtTel1.Name = "TxtTel1"
        Me.TxtTel1.Size = New System.Drawing.Size(155, 20)
        Me.TxtTel1.TabIndex = 2
        Me.TxtTel1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'GrpDomicilio
        '
        Me.GrpDomicilio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDomicilio.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpDomicilio.Controls.Add(Me.PictureBox24)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox23)
        Me.GrpDomicilio.Controls.Add(Me.Label18)
        Me.GrpDomicilio.Controls.Add(Me.TxtReferencia)
        Me.GrpDomicilio.Controls.Add(Me.Label19)
        Me.GrpDomicilio.Controls.Add(Me.Label20)
        Me.GrpDomicilio.Controls.Add(Me.TxtNoInterior)
        Me.GrpDomicilio.Controls.Add(Me.TxtNoExterior)
        Me.GrpDomicilio.Controls.Add(Me.TxtCodigoPostal)
        Me.GrpDomicilio.Controls.Add(Me.TxtLocalidad)
        Me.GrpDomicilio.Controls.Add(Me.Label16)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox12)
        Me.GrpDomicilio.Controls.Add(Me.TxtCalle)
        Me.GrpDomicilio.Controls.Add(Me.LblCalle)
        Me.GrpDomicilio.Controls.Add(Me.BtnDelDomi)
        Me.GrpDomicilio.Controls.Add(Me.LblTipo)
        Me.GrpDomicilio.Controls.Add(Me.LblColonia)
        Me.GrpDomicilio.Controls.Add(Me.LblMnpio)
        Me.GrpDomicilio.Controls.Add(Me.LblEstado)
        Me.GrpDomicilio.Controls.Add(Me.LblPais)
        Me.GrpDomicilio.Controls.Add(Me.BtnAceptarDomi)
        Me.GrpDomicilio.Controls.Add(Me.Label17)
        Me.GrpDomicilio.Controls.Add(Me.cmbTipoDomicilio)
        Me.GrpDomicilio.Controls.Add(Me.cmbColonia)
        Me.GrpDomicilio.Controls.Add(Me.cmbMnpio)
        Me.GrpDomicilio.Controls.Add(Me.cmbEstado)
        Me.GrpDomicilio.Controls.Add(Me.ChkDomicilio)
        Me.GrpDomicilio.Controls.Add(Me.cmbPais)
        Me.GrpDomicilio.Location = New System.Drawing.Point(4, 491)
        Me.GrpDomicilio.Name = "GrpDomicilio"
        Me.GrpDomicilio.Size = New System.Drawing.Size(757, 196)
        Me.GrpDomicilio.TabIndex = 0
        Me.GrpDomicilio.TabStop = False
        Me.GrpDomicilio.Text = "Domicilio"
        '
        'PictureBox24
        '
        Me.PictureBox24.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox24.Image = CType(resources.GetObject("PictureBox24.Image"), System.Drawing.Image)
        Me.PictureBox24.Location = New System.Drawing.Point(526, 141)
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
        Me.PictureBox23.Location = New System.Drawing.Point(140, 142)
        Me.PictureBox23.Name = "PictureBox23"
        Me.PictureBox23.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox23.TabIndex = 91
        Me.PictureBox23.TabStop = False
        Me.PictureBox23.Visible = False
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(9, 173)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 16)
        Me.Label18.TabIndex = 90
        Me.Label18.Text = "Referencia"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(80, 166)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(569, 20)
        Me.TxtReferencia.TabIndex = 11
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(531, 140)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 17)
        Me.Label19.TabIndex = 88
        Me.Label19.Text = "No. Int."
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(411, 141)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 17)
        Me.Label20.TabIndex = 87
        Me.Label20.Text = "No. Ext."
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
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(260, 79)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(99, 15)
        Me.Label16.TabIndex = 77
        Me.Label16.Text = "Ciudad/Población"
        '
        'PictureBox12
        '
        Me.PictureBox12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), System.Drawing.Image)
        Me.PictureBox12.Location = New System.Drawing.Point(481, 109)
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
        'BtnDelDomi
        '
        Me.BtnDelDomi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelDomi.Enabled = False
        Me.BtnDelDomi.Image = CType(resources.GetObject("BtnDelDomi.Image"), System.Drawing.Image)
        Me.BtnDelDomi.Location = New System.Drawing.Point(669, 80)
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
        Me.BtnAceptarDomi.Location = New System.Drawing.Point(669, 16)
        Me.BtnAceptarDomi.Name = "BtnAceptarDomi"
        Me.BtnAceptarDomi.Size = New System.Drawing.Size(75, 32)
        Me.BtnAceptarDomi.TabIndex = 8
        Me.BtnAceptarDomi.Text = "&Aceptar"
        Me.BtnAceptarDomi.ToolTipText = "Guardar cambios"
        Me.BtnAceptarDomi.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(335, 111)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(82, 16)
        Me.Label17.TabIndex = 79
        Me.Label17.Text = "Código Postal"
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
        Me.ChkDomicilio.Location = New System.Drawing.Point(481, 16)
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
        Me.GrpDomicilios.Location = New System.Drawing.Point(4, 491)
        Me.GrpDomicilios.Name = "GrpDomicilios"
        Me.GrpDomicilios.Size = New System.Drawing.Size(757, 139)
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
        Me.GridDomicilios.Size = New System.Drawing.Size(741, 115)
        Me.GridDomicilios.TabIndex = 1
        Me.GridDomicilios.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GrpSaldos
        '
        Me.GrpSaldos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpSaldos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpSaldos.Controls.Add(Me.LblSaldo)
        Me.GrpSaldos.Controls.Add(Me.NumSaldo)
        Me.GrpSaldos.Controls.Add(Me.LblCredito)
        Me.GrpSaldos.Controls.Add(Me.NumDisponible)
        Me.GrpSaldos.Controls.Add(Me.GridSaldos)
        Me.GrpSaldos.Location = New System.Drawing.Point(4, 491)
        Me.GrpSaldos.Name = "GrpSaldos"
        Me.GrpSaldos.Size = New System.Drawing.Size(757, 349)
        Me.GrpSaldos.TabIndex = 10
        Me.GrpSaldos.TabStop = False
        Me.GrpSaldos.Text = "Saldos de Facturas"
        '
        'LblSaldo
        '
        Me.LblSaldo.Location = New System.Drawing.Point(392, 16)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(96, 16)
        Me.LblSaldo.TabIndex = 61
        Me.LblSaldo.Text = "Total Saldo"
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
        Me.GrpMetodos.Location = New System.Drawing.Point(4, 491)
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
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(602, 386)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(698, 386)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmEmpleado
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 427)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.UiTab1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 432)
        Me.Name = "FrmEmpleado"
        Me.Text = "Empleados"
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        Me.UiTabCliente.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GrpEmpleado.ResumeLayout(False)
        Me.GrpEmpleado.PerformLayout()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNomina.ResumeLayout(False)
        Me.grpNomina.PerformLayout()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GrpContacto.ResumeLayout(False)
        Me.GrpContacto.PerformLayout()
        Me.GrpDomicilio.ResumeLayout(False)
        Me.GrpDomicilio.PerformLayout()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDomicilios.ResumeLayout(False)
        CType(Me.GridDomicilios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpSaldos.ResumeLayout(False)
        Me.GrpSaldos.PerformLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpMetodos.ResumeLayout(False)
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Publicas"

    Public Padre As String
    Public fromReciboNomina As Boolean = False

    Public EMPClave As String = ""
    Public NumEmpleado As String = ""
    Public NombreCompleto As String = ""
    Public RFC As String = ""
    Public NSS As String = ""
    Public CURP As String = ""
    Public TipoRegimen As Integer
    Public Departamento As String = ""
    Public Puesto As String = ""
    Public TipoContrato As Integer
    Public TipoJornada As Integer
    Public CLABE As String
    Public TipoBanco As Integer
    Public FechaReg As Date = DateTime.Today
    Public PeriodicidadPago As Integer
    Public SalarioBase As Double
    Public SalarioDiario As Double
    Public PaisF As String
    Public EntidadF As String = ""
    Public MnpioF As String = ""
    Public ColoniaF As String = ""
    Public CalleF As String = ""
    Public codigoPostalF As String = ""
    Public noInteriorF As String = ""
    Public noExteriorF As String = ""

    Public TipoLicencia As Integer = 0
    Public Licencia As String = ""
    Public Vencimiento As Date = DateTime.Today

    Public Contacto As String = ""
    Public Tel1 As String = ""
    Public Tel2 As String = ""
    Public email As String = ""
    Public TipoEstado As Integer = 1
    Public TipoEmpleado As Integer
    Public SUCClave As String = ""
    Public Sindicalizado As Integer = 0
    Public PaisLabora As Integer = 1
    Public EdoLabora As String = ""


#End Region

#Region "Variables Privadas"

    Private aEstado() As String
    Private aMnpio() As String
    Private aColonia() As String

    Private Cnx As String
    Private alerta(16) As PictureBox
    Private reloj As parpadea

    Private cargado As Boolean = False

    Private guardado As Boolean = False

    Private RegPatronal As String

#End Region

#Region "Empleado"

    Private Sub reinicializa()


        EMPClave = ""
        NumEmpleado = ""
        NombreCompleto = ""
        RFC = ""
        NSS = ""
        CURP = ""
        Departamento = ""
        Puesto = ""
        CLABE = ""
        FechaReg = DateTime.Today
        SalarioBase = 0
        SalarioDiario = 0

        MnpioF = ""
        ColoniaF = ""
        CalleF = ""
        codigoPostalF = ""
        noInteriorF = ""
        noExteriorF = ""

        TipoLicencia = 0
        Licencia = ""
        Vencimiento = DateTime.Today

        Contacto = ""
        Tel1 = ""
        Tel2 = ""
        email = ""

        TipoEstado = 1
        TipoEmpleado = 0

        TxtNumEmpleado.Text = NumEmpleado
        TxtRazonSocial.Text = NombreCompleto
        TxtRFC.Text = RFC
        TxtNSS.Text = NSS
        TxtCURP.Text = CURP
        TxtDepartamento.Text = Departamento
        TxtPuesto.Text = Puesto
        TxtCLABE.Text = CLABE
        dFechaIngreso.Value = FechaReg
        TxtSalarioBase.Text = SalarioBase
        txtSalarioDiario.Text = SalarioDiario

        TxtMunicipioFac.Text = MnpioF
        TxtColoniaFac.Text = ColoniaF
        TxtDomicilioFac.Text = CalleF
        TxtCPFac.Text = codigoPostalF
        TxtNoInteriorFac.Text = noInteriorF
        TxtNoExteriorFac.Text = noExteriorF


        cmbTipoLicencia.SelectedValue = TipoLicencia
        TxtNumLicencia.Text = Licencia
        dVencimiento.Value = Vencimiento

        TxtContacto.Text = Contacto
        TxtTel1.Text = Tel1
        TxtTel2.Text = Tel2
        TxtMail.Text = email

        ChkEstado.Estado = TipoEstado

        cmbTipoEmpleado.SelectedValue = TipoEmpleado
        
        TxtNumEmpleado.Focus()
        Me.Panel1.VerticalScroll.Value = 0

    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtNumEmpleado.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNumEmpleado.Text.Length > 20 Then
            Me.TxtNumEmpleado.Text = Me.TxtNumEmpleado.Text.Substring(0, 20)
        End If


        If Me.TxtRazonSocial.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtRazonSocial.Text.Length > 200 Then
            Me.TxtRazonSocial.Text = Me.TxtRazonSocial.Text.Substring(0, 200)
        End If


        If RegPatronal <> "" AndAlso Me.TxtRFC.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtRFC.Text.Length > 32 Then
            Me.TxtRFC.Text = Me.TxtRFC.Text.Substring(0, 32)
        End If


        If RegPatronal <> "" AndAlso Me.TxtCURP.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtCURP.Text.Length > 18 Then
            Me.TxtCURP.Text = Me.TxtCURP.Text.Substring(0, 18)
        End If


        If Me.CmbPaisFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtEstadoFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtEstadoFac.Text.Length > 30 Then
            Me.TxtEstadoFac.Text = Me.TxtEstadoFac.Text.Substring(0, 30)

        End If

        If Me.TxtMunicipioFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtMunicipioFac.Text.Length > 50 Then
            Me.TxtMunicipioFac.Text = Me.TxtMunicipioFac.Text.Substring(0, 50)

        End If

        If Me.TxtColoniaFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtColoniaFac.Text.Length > 80 Then
            Me.TxtColoniaFac.Text = Me.TxtColoniaFac.Text.Substring(0, 80)
        End If

        If Me.TxtCPFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(8))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtCPFac.Text.Length > 10 Then
            Me.TxtCPFac.Text = Me.TxtCPFac.Text.Substring(0, 10)

        End If



        If Me.TxtDomicilioFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(9))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtDomicilioFac.Text.Length > 128 Then
            Me.TxtDomicilioFac.Text = Me.TxtDomicilioFac.Text.Substring(0, 128)
        End If


        If Me.TxtNoExteriorFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(10))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNoExteriorFac.Text.Length > 10 Then
            Me.TxtNoExteriorFac.Text = Me.TxtNoExteriorFac.Text.Substring(0, 10)
        End If


        If Me.CmbTipoRegimen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(11))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbPeriodicidadPago.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(12))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbTipoEmpleado.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(13))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbSucursalD.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(14))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.cmbPaisLabora.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(15))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbEdoLabora.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(16))
            reloj.Enabled = True
            reloj.Start()
        End If


        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Empleado", "@clave", Me.TxtNumEmpleado.Text.ToUpper.Trim, "@COMClave", ModPOS.CompanyActual) > 0 Then
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

    Private Sub FrmEmpleado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.BringToFront()

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
        alerta(10) = Me.PictureBox11
        alerta(11) = Me.PictureBox13
        alerta(12) = Me.PictureBox14
        alerta(13) = Me.PictureBox16
        alerta(14) = Me.PictureBox15
        alerta(15) = Me.PictureBox17
        alerta(16) = Me.PictureBox18

        Cnx = ModPOS.BDConexion

        With Me.CmbPaisFac
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Geografia"
            .NombreParametro2 = "campo"
            .Parametro2 = "Pais"
            .llenar()
        End With


        With Me.cmbTipoBanco
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Empleado"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoBanco"
            .llenar()
        End With

        With Me.CmbTipoRegimen
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Empleado"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoRegimen"
            .llenar()
        End With

     

        With Me.cmbPeriodicidadPago
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Empleado"
            .NombreParametro2 = "campo"
            .Parametro2 = "PeriodicidadPago"
            .llenar()
        End With


        With Me.cmbTipoContrato
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Empleado"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoContrato"
            .llenar()
        End With

        With Me.cmbTipoJornada
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Empleado"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoJornada"
            .llenar()
        End With

        With Me.cmbTipoLicencia
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Empleado"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoLicencia"
            .llenar()
        End With

        With Me.cmbTipoEmpleado
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Empleado"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoEmpleado"
            .llenar()
        End With

        With cmbSucursalD
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_all_sucursal"
            .NombreParametro1 = "COMClave"
            .Parametro1 = ModPOS.CompanyActual
            .llenar()
        End With


        With Me.cmbPaisLabora
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Geografia"
            .NombreParametro2 = "campo"
            .Parametro2 = "Pais"
            .llenar()
        End With

        With Me.cmbEdoLabora
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_estado"
            .NombreParametro1 = "Pais"
            .Parametro1 = CmbPaisFac.SelectedValue
            .llenar()
        End With

        Dim dtEstado As DataTable

        dtEstado = ModPOS.Recupera_Tabla("sp_filtra_estado", "@Pais", CmbPaisFac.SelectedValue)
        If dtEstado.Rows.Count > 0 Then
            ReDim aEstado(dtEstado.Rows.Count - 1)

            For i As Integer = 0 To dtEstado.Rows.Count - 1
                aEstado(i) = dtEstado.Rows(i)("d_estado")
            Next

            Me.TxtEstadoFac.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Me.TxtEstadoFac.AutoCompleteSource = AutoCompleteSource.CustomSource
            Me.TxtEstadoFac.AutoCompleteCustomSource.AddRange(aEstado)

            dtEstado.Dispose()
        End If


        cargado = True

        TxtNumEmpleado.Text = NumEmpleado
        TxtRazonSocial.Text = NombreCompleto
        CmbTipoRegimen.SelectedValue = TipoRegimen
        TxtRFC.Text = RFC
        TxtCURP.Text = CURP
        TxtNSS.Text = NSS
        txtSalarioDiario.Text = SalarioDiario
        TxtSalarioBase.Text = SalarioBase

        TxtContacto.Text = Contacto
        TxtTel1.Text = Tel1
        TxtTel2.Text = Tel2
        TxtMail.Text = email
        ChkEstado.Estado = TipoEstado
        TxtDepartamento.Text = Departamento
        TxtPuesto.Text = Puesto
        TxtCLABE.Text = CLABE

        CmbPaisFac.Text = PaisF
        TxtEstadoFac.Text = EntidadF
        TxtMunicipioFac.Text = MnpioF
        TxtColoniaFac.Text = ColoniaF
        TxtDomicilioFac.Text = CalleF
        TxtCPFac.Text = codigoPostalF
        TxtNoInteriorFac.Text = noInteriorF
        TxtNoExteriorFac.Text = noExteriorF

        cmbTipoBanco.SelectedValue = TipoBanco
        cmbPeriodicidadPago.SelectedValue = PeriodicidadPago
        cmbTipoContrato.SelectedValue = TipoContrato
        cmbTipoJornada.SelectedValue = TipoJornada

        dFechaIngreso.Value = FechaReg

        ChkSindicalizado.Estado = Sindicalizado
        cmbTipoLicencia.SelectedValue = TipoLicencia
        TxtNumLicencia.Text = Licencia
        dVencimiento.Value = Vencimiento
        cmbTipoEmpleado.SelectedValue = TipoEmpleado
        cmbSucursalD.SelectedValue = SUCClave
        cmbPaisLabora.SelectedValue = PaisLabora
        cmbEdoLabora.SelectedValue = EdoLabora

        If Padre = "Modificar" Then
            BtnKey.Enabled = False
        End If

        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)
        RegPatronal = IIf(dt.Rows(0)("registroPatronal").GetType.Name = "DBNull", "", dt.Rows(0)("registroPatronal"))
        dt.Dispose()
    End Sub

    Private Sub FrmEmpleado_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoEmpleados Is Nothing Then
            If guardado = True Then
                ModPOS.MtoEmpleados.actualizaGrid()
            End If
        End If
        ModPOS.Empleado.Dispose()
        ModPOS.Empleado = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            If RegPatronal <> "" AndAlso TxtCURP.Text.Length < 18 Then
                Beep()
                MessageBox.Show("CURP Invalida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If RegPatronal <> "" AndAlso TxtCLABE.Text <> "" AndAlso TxtCLABE.Text.Length < 18 Then
                Beep()
                MessageBox.Show("Cuenta CLABE Invalida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If


            Select Case Me.Padre
                Case "Agregar"

                    EMPClave = ModPOS.obtenerLlave
                    NumEmpleado = TxtNumEmpleado.Text.ToUpper.Trim
                    NombreCompleto = TxtRazonSocial.Text.ToUpper.Trim
                    RFC = TxtRFC.Text.ToUpper.Trim
                    NSS = TxtNSS.Text.ToUpper.Trim
                    CURP = TxtCURP.Text.ToUpper.Trim
                    TipoRegimen = CmbTipoRegimen.SelectedValue
                    Departamento = TxtDepartamento.Text.ToUpper.Trim
                    Puesto = TxtPuesto.Text.ToUpper.Trim
                    TipoContrato = cmbTipoContrato.SelectedValue
                    TipoJornada = cmbTipoJornada.SelectedValue
                    CLABE = TxtCLABE.Text.ToUpper.Trim
                    TipoBanco = cmbTipoBanco.SelectedValue
                    FechaReg = Me.dFechaIngreso.Value
                    PeriodicidadPago = cmbPeriodicidadPago.SelectedValue
                    SalarioBase = TxtSalarioBase.Text
                    SalarioDiario = txtSalarioDiario.Text

                    PaisF = CmbPaisFac.Text.ToUpper.Trim
                    EntidadF = TxtEstadoFac.Text.ToUpper.Trim
                    MnpioF = TxtMunicipioFac.Text.ToUpper.Trim
                    CalleF = TxtDomicilioFac.Text.ToUpper.Trim
                    ColoniaF = TxtColoniaFac.Text.ToUpper.Trim
                    codigoPostalF = TxtCPFac.Text.ToUpper.Trim
                    noExteriorF = TxtNoExteriorFac.Text.ToUpper.Trim
                    noInteriorF = TxtNoInteriorFac.Text.ToUpper.Trim
                    Contacto = TxtContacto.Text.ToUpper.Trim
                    Tel1 = TxtTel1.Text.ToUpper.Trim
                    Tel2 = TxtTel2.Text.ToUpper.Trim
                    email = TxtMail.Text.Trim


                    TipoLicencia = cmbTipoLicencia.SelectedValue
                    Licencia = TxtNumLicencia.Text
                    Vencimiento = dVencimiento.Value

                    TipoEmpleado = cmbTipoEmpleado.SelectedValue
                    SUCClave = cmbSucursalD.SelectedValue
                    Sindicalizado = ChkSindicalizado.GetEstado

                    PaisLabora = cmbPaisLabora.SelectedValue
                    EdoLabora = cmbEdoLabora.SelectedValue
                    TipoEstado = 1

                    ModPOS.Ejecuta("sp_inserta_empleado", _
                                        "@EMPClave", EMPClave, _
                                        "@COMClave", ModPOS.CompanyActual, _
                                        "@NumEmpleado", NumEmpleado, _
                                        "@NombreCompleto", NombreCompleto, _
                                        "@RFC", RFC, _
                                        "@CURP", CURP, _
                                        "@NSS", NSS, _
                                        "@TipoRegimen", TipoRegimen, _
                                        "@Departamento", Departamento, _
                                        "@Puesto", Puesto, _
                                        "@TipoContrato", TipoContrato, _
                                        "@TipoJornada", TipoJornada, _
                                        "@CLABE", CLABE, _
                                        "@TipoBanco", TipoBanco, _
                                        "@FechaReg", FechaReg, _
                                        "@PeriodicidadPago", PeriodicidadPago, _
                                        "@SalarioBase", SalarioBase, _
                                        "@SalarioDiario", SalarioDiario, _
                                        "@Pais", PaisF, _
                                        "@Estado", EntidadF, _
                                        "@Municipio", MnpioF, _
                                        "@Colonia", ColoniaF, _
                                        "@Calle", CalleF, _
                                        "@codigoPostal", codigoPostalF, _
                                        "@noExterior", noExteriorF, _
                                        "@noInterior", noInteriorF, _
                                        "@Contacto", Contacto, _
                                        "@Tel1", Tel1, _
                                        "@Tel2", Tel2, _
                                        "@Email", email, _
                                        "@TipoLicencia", TipoLicencia, _
                                        "@Licencia", Licencia, _
                                        "@Vencimiento", Vencimiento, _
                                        "@TipoEstado", TipoEstado, _
                                        "@TipoEmpleado", TipoEmpleado, _
                                        "@SUCClave", SUCClave, _
                                        "@Sindicalizado", Sindicalizado, _
                                        "@PaisLabora", PaisLabora, _
                                        "@EdoLabora", EdoLabora, _
                                        "@Usuario", ModPOS.UsuarioActual)

                    guardado = True

                    If fromReciboNomina = True Then
                        If Not ModPOS.ReciboNomina Is Nothing Then
                            ModPOS.ReciboNomina.CargaDatosEmpleado(NumEmpleado)
                            ModPOS.ReciboNomina.editado = True
                        End If
                        Me.Close()
                    End If

                    reinicializa()

                Case "Modificar"


                    If Not ( _
                        NombreCompleto = TxtRazonSocial.Text.ToUpper.Trim AndAlso _
                        RFC = TxtRFC.Text.ToUpper.Trim AndAlso _
                        NSS = TxtNSS.Text.ToUpper.Trim AndAlso _
                        CURP = TxtCURP.Text.ToUpper.Trim AndAlso _
                        TipoRegimen = CmbTipoRegimen.SelectedValue AndAlso _
                        Departamento = TxtDepartamento.Text.ToUpper.Trim AndAlso _
                        Puesto = TxtPuesto.Text.ToUpper.Trim AndAlso _
                        TipoContrato = cmbTipoContrato.SelectedValue AndAlso _
                        TipoJornada = cmbTipoJornada.SelectedValue AndAlso _
                        CLABE = TxtCLABE.Text.ToUpper.Trim AndAlso _
                        TipoBanco = cmbTipoBanco.SelectedValue AndAlso _
                        FechaReg = Me.dFechaIngreso.Value AndAlso _
                        PeriodicidadPago = cmbPeriodicidadPago.SelectedValue AndAlso _
                        SalarioBase = TxtSalarioBase.Text AndAlso _
                        SalarioDiario = txtSalarioDiario.Text AndAlso _
                        PaisF = CmbPaisFac.Text.ToUpper.Trim AndAlso _
                        EntidadF = TxtEstadoFac.Text.ToUpper.Trim AndAlso _
                        MnpioF = TxtMunicipioFac.Text.ToUpper.Trim AndAlso _
                        CalleF = TxtDomicilioFac.Text.ToUpper.Trim AndAlso _
                        ColoniaF = TxtColoniaFac.Text.ToUpper.Trim AndAlso _
                        codigoPostalF = TxtCPFac.Text.ToUpper.Trim AndAlso _
                        noExteriorF = TxtNoExteriorFac.Text.ToUpper.Trim AndAlso _
                        noInteriorF = TxtNoInteriorFac.Text.ToUpper.Trim AndAlso _
                        Contacto = TxtContacto.Text.ToUpper.Trim AndAlso _
                        Tel1 = TxtTel1.Text.ToUpper.Trim AndAlso _
                        Tel2 = TxtTel2.Text.ToUpper.Trim AndAlso _
                        email = TxtMail.Text.Trim AndAlso _
                        cmbTipoLicencia.SelectedValue = TipoLicencia AndAlso _
                        TxtNumLicencia.Text = Licencia AndAlso _
                        dVencimiento.Value = Vencimiento AndAlso _
                        TipoEmpleado = cmbTipoEmpleado.SelectedValue AndAlso _
                        SUCClave = cmbSucursalD.SelectedValue AndAlso _
                        Sindicalizado = ChkSindicalizado.GetEstado AndAlso _
                        PaisLabora = cmbPaisLabora.SelectedValue AndAlso _
                        EdoLabora = cmbEdoLabora.SelectedValue AndAlso _
                        TipoEstado = Me.ChkEstado.GetEstado) Then



                        NumEmpleado = TxtNumEmpleado.Text.ToUpper.Trim
                        NombreCompleto = TxtRazonSocial.Text.ToUpper.Trim
                        RFC = TxtRFC.Text.ToUpper.Trim
                        NSS = TxtNSS.Text.ToUpper.Trim
                        CURP = TxtCURP.Text.ToUpper.Trim
                        TipoRegimen = CmbTipoRegimen.SelectedValue
                        Departamento = TxtDepartamento.Text.ToUpper.Trim
                        Puesto = TxtPuesto.Text.ToUpper.Trim
                        TipoContrato = cmbTipoContrato.SelectedValue
                        TipoJornada = cmbTipoJornada.SelectedValue
                        CLABE = TxtCLABE.Text.ToUpper.Trim
                        TipoBanco = cmbTipoBanco.SelectedValue
                        FechaReg = Me.dFechaIngreso.Value
                        PeriodicidadPago = cmbPeriodicidadPago.SelectedValue
                        SalarioBase = TxtSalarioBase.Text
                        SalarioDiario = txtSalarioDiario.Text
                        PaisF = CmbPaisFac.Text.ToUpper.Trim
                        EntidadF = TxtEstadoFac.Text.ToUpper.Trim
                        MnpioF = TxtMunicipioFac.Text.ToUpper.Trim
                        CalleF = TxtDomicilioFac.Text.ToUpper.Trim
                        ColoniaF = TxtColoniaFac.Text.ToUpper.Trim
                        codigoPostalF = TxtCPFac.Text.ToUpper.Trim
                        noExteriorF = TxtNoExteriorFac.Text.ToUpper.Trim
                        noInteriorF = TxtNoInteriorFac.Text.ToUpper.Trim
                        Contacto = TxtContacto.Text.ToUpper.Trim
                        Tel1 = TxtTel1.Text.ToUpper.Trim
                        Tel2 = TxtTel2.Text.ToUpper.Trim
                        email = TxtMail.Text.Trim
                        TipoLicencia = cmbTipoLicencia.SelectedValue
                        Licencia = TxtNumLicencia.Text
                        Vencimiento = dVencimiento.Value
                        TipoEstado = Me.ChkEstado.GetEstado
                        Sindicalizado = ChkSindicalizado.GetEstado
                        TipoEmpleado = cmbTipoEmpleado.SelectedValue
                        SUCClave = cmbSucursalD.SelectedValue
                        PaisLabora = cmbPaisLabora.SelectedValue
                        EdoLabora = cmbEdoLabora.SelectedValue

                        ModPOS.Ejecuta("sp_modifica_empleado", _
                                        "@EMPClave", EMPClave, _
                                        "@NombreCompleto", NombreCompleto, _
                                        "@RFC", RFC, _
                                        "@CURP", CURP, _
                                        "@NSS", NSS, _
                                        "@TipoRegimen", TipoRegimen, _
                                        "@Departamento", Departamento, _
                                        "@Puesto", Puesto, _
                                        "@TipoContrato", TipoContrato, _
                                        "@TipoJornada", TipoJornada, _
                                        "@CLABE", CLABE, _
                                        "@TipoBanco", TipoBanco, _
                                        "@FechaReg", FechaReg, _
                                        "@PeriodicidadPago", PeriodicidadPago, _
                                        "@SalarioBase", SalarioBase, _
                                        "@SalarioDiario", SalarioDiario, _
                                        "@Pais", PaisF, _
                                        "@Estado", EntidadF, _
                                        "@Municipio", MnpioF, _
                                        "@Colonia", ColoniaF, _
                                        "@Calle", CalleF, _
                                        "@codigoPostal", codigoPostalF, _
                                        "@noExterior", noExteriorF, _
                                        "@noInterior", noInteriorF, _
                                        "@Contacto", Contacto, _
                                        "@Tel1", Tel1, _
                                        "@Tel2", Tel2, _
                                        "@Email", email, _
                                        "@TipoEstado", TipoEstado, _
                                        "@TipoLicencia", TipoLicencia, _
                                        "@Licencia", Licencia, _
                                        "@Vencimiento", Vencimiento, _
                                        "@TipoEmpleado", TipoEmpleado, _
                                        "@SUCClave", SUCClave, _
                                        "@Sindicalizado", Sindicalizado, _
                                          "@PaisLabora", PaisLabora, _
                                        "@EdoLabora", EdoLabora, _
                                        "@Usuario", ModPOS.UsuarioActual)
                    End If
                    guardado = True

                    If fromReciboNomina = True Then
                        If Not ModPOS.ReciboNomina Is Nothing Then
                            ModPOS.ReciboNomina.CargaDatosEmpleado(NumEmpleado)
                            ModPOS.ReciboNomina.editado = True
                        End If
                    End If


                    Me.Close()
            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub


    Private Sub Ctrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNumEmpleado.KeyDown, CmbTipoRegimen.KeyDown, TxtRazonSocial.KeyDown, TxtRFC.KeyDown, TxtContacto.KeyDown, TxtTel1.KeyDown, TxtTel2.KeyDown, TxtMail.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub BtnKey_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKey.Click

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "Digitos", "@COMClave", ModPOS.CompanyActual)
        Dim len As Integer = CInt(dt.Rows(0)("Valor"))
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_calcula_empclave", "@len", len, "@COMClave", ModPOS.CompanyActual)

        TxtNumEmpleado.Text = dt.Rows(0)("Clave")
        dt.Dispose()

        SendKeys.Send("{TAB}")

    End Sub


    Private Sub TxtEstadoFac_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEstadoFac.LostFocus
        If TxtEstadoFac.Text <> "" AndAlso TxtEstadoFac.Text <> EntidadF Then
            Dim dtMnpio As DataTable
            dtMnpio = ModPOS.Recupera_Tabla("sp_recupera_mnpio", "@Estado", TxtEstadoFac.Text.Trim.ToUpper)
            If dtMnpio.Rows.Count > 0 Then
                ReDim aMnpio(dtMnpio.Rows.Count - 1)
                For i As Integer = 0 To dtMnpio.Rows.Count - 1
                    aMnpio(i) = dtMnpio.Rows(i)("d_mnpio")
                Next
                Me.TxtMunicipioFac.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.TxtMunicipioFac.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.TxtMunicipioFac.AutoCompleteCustomSource.AddRange(aMnpio)
                dtMnpio.Dispose()
            End If
        End If
    End Sub

    Private Sub TxtColoniaFac_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtColoniaFac.LostFocus
        If TxtColoniaFac.Text <> "" AndAlso TxtColoniaFac.Text <> ColoniaF AndAlso TxtEstadoFac.Text <> "" AndAlso TxtMunicipioFac.Text <> "" AndAlso TxtMunicipioFac.Text <> MnpioF Then
            Dim dtCP As DataTable
            dtCP = ModPOS.Recupera_Tabla("sp_recupera_cp", "@Estado", TxtEstadoFac.Text.ToUpper.Trim, "@Municipio", TxtMunicipioFac.Text.Trim.ToUpper, "@Colonia", TxtColoniaFac.Text.Trim.ToUpper)
            If dtCP.Rows.Count > 0 Then
                Me.TxtCPFac.Text = dtCP.Rows(0)("codigo_postal")
                dtCP.Dispose()
            End If
        End If
    End Sub

    Private Sub TxtMunicipioFac_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMunicipioFac.LostFocus
        If TxtEstadoFac.Text <> "" AndAlso TxtMunicipioFac.Text <> "" AndAlso TxtMunicipioFac.Text <> MnpioF Then
            Dim dtColonia As DataTable
            dtColonia = ModPOS.Recupera_Tabla("sp_recupera_colonia", "@Estado", TxtEstadoFac.Text.ToUpper.Trim, "@Municipio", TxtMunicipioFac.Text.Trim.ToUpper)
            If dtColonia.Rows.Count > 0 Then
                ReDim aColonia(dtColonia.Rows.Count - 1)
                For i As Integer = 0 To dtColonia.Rows.Count - 1
                    aColonia(i) = dtColonia.Rows(i)("Nombre")
                Next
                Me.TxtColoniaFac.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.TxtColoniaFac.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.TxtColoniaFac.AutoCompleteCustomSource.AddRange(aColonia)
                dtColonia.Dispose()
            End If
        End If
    End Sub

    Private Sub CmbPaisFac_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPaisFac.SelectedIndexChanged
        If cargado = True AndAlso Not CmbPaisFac.SelectedValue Is Nothing Then
            Dim dtEstado As DataTable

            dtEstado = ModPOS.Recupera_Tabla("sp_filtra_estado", "@Pais", CmbPaisFac.SelectedValue)
            If dtEstado.Rows.Count > 0 Then
                ReDim aEstado(dtEstado.Rows.Count - 1)

                For i As Integer = 0 To dtEstado.Rows.Count - 1
                    aEstado(i) = dtEstado.Rows(i)("d_estado")
                Next

                Me.TxtEstadoFac.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.TxtEstadoFac.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.TxtEstadoFac.AutoCompleteCustomSource.AddRange(aEstado)

                dtEstado.Dispose()
            End If

        End If

    End Sub

#End Region

 
  
End Class
