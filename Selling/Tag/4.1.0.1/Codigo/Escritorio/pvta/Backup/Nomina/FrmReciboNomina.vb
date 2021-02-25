Public Class FrmReciboNomina
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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
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
    Friend WithEvents TxtLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label

    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtNoInterior As System.Windows.Forms.TextBox
    Friend WithEvents TxtNoExterior As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents PictureBox24 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox23 As System.Windows.Forms.PictureBox
    Friend WithEvents GrpMetodos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridMetodos As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnElimina As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNumEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents BtnAbrir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnNuevo As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtRFC As System.Windows.Forms.TextBox
    Friend WithEvents LstDomicilio As System.Windows.Forms.ListBox
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaEmp As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCURP As System.Windows.Forms.TextBox
    Friend WithEvents TxtNSS As System.Windows.Forms.TextBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents LblSubtotal As System.Windows.Forms.Label
    Friend WithEvents LblIVA As System.Windows.Forms.Label
    Friend WithEvents TxtNeto As System.Windows.Forms.TextBox
    Friend WithEvents TxtDeducciones As System.Windows.Forms.TextBox
    Friend WithEvents TxtIngreso As System.Windows.Forms.TextBox
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnConcepto As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbMetodoPago As Selling.StoreCombo
    Friend WithEvents LblMetodoPago As System.Windows.Forms.Label
    Friend WithEvents cmbBanco As Selling.StoreCombo
    Friend WithEvents LblBanco As System.Windows.Forms.Label
    Friend WithEvents TxtRef As System.Windows.Forms.TextBox
    Friend WithEvents LblNoCta As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbFormaPago As Selling.StoreCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnTC As Janus.Windows.EditControls.UIButton
    Friend WithEvents CtxDocumentos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtFechaPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents BtnModifica As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReciboNomina))
        Me.GrpDomicilio = New System.Windows.Forms.GroupBox
        Me.PictureBox24 = New System.Windows.Forms.PictureBox
        Me.PictureBox23 = New System.Windows.Forms.PictureBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.TxtNoInterior = New System.Windows.Forms.TextBox
        Me.TxtNoExterior = New System.Windows.Forms.TextBox
        Me.TxtCodigoPostal = New System.Windows.Forms.TextBox
        Me.TxtLocalidad = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.PictureBox12 = New System.Windows.Forms.PictureBox
        Me.TxtCalle = New System.Windows.Forms.TextBox
        Me.LblCalle = New System.Windows.Forms.Label
        Me.BtnDelDomi = New Janus.Windows.EditControls.UIButton
        Me.LblTipo = New System.Windows.Forms.Label
        Me.LblColonia = New System.Windows.Forms.Label
        Me.LblMnpio = New System.Windows.Forms.Label
        Me.LblEstado = New System.Windows.Forms.Label
        Me.LblPais = New System.Windows.Forms.Label
        Me.BtnAceptarDomi = New Janus.Windows.EditControls.UIButton
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmbTipoDomicilio = New Selling.StoreCombo
        Me.cmbColonia = New Selling.StoreCombo
        Me.cmbMnpio = New Selling.StoreCombo
        Me.cmbEstado = New Selling.StoreCombo
        Me.ChkDomicilio = New Selling.ChkStatus(Me.components)
        Me.cmbPais = New Selling.StoreCombo
        Me.GrpDomicilios = New System.Windows.Forms.GroupBox
        Me.GridDomicilios = New Janus.Windows.GridEX.GridEX
        Me.GrpSaldos = New System.Windows.Forms.GroupBox
        Me.LblSaldo = New System.Windows.Forms.Label
        Me.NumSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.LblCredito = New System.Windows.Forms.Label
        Me.NumDisponible = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.GridSaldos = New Janus.Windows.GridEX.GridEX
        Me.GrpMetodos = New System.Windows.Forms.GroupBox
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GridMetodos = New Janus.Windows.GridEX.GridEX
        Me.BtnElimina = New Janus.Windows.EditControls.UIButton
        Me.BtnModifica = New Janus.Windows.EditControls.UIButton
        Me.GrpCliente = New System.Windows.Forms.GroupBox
        Me.LblTipoCambio = New System.Windows.Forms.Label
        Me.BtnTC = New Janus.Windows.EditControls.UIButton
        Me.CtxDocumentos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.CmbFormaPago = New Selling.StoreCombo
        Me.cmbBanco = New Selling.StoreCombo
        Me.LblBanco = New System.Windows.Forms.Label
        Me.TxtRef = New System.Windows.Forms.TextBox
        Me.LblNoCta = New System.Windows.Forms.Label
        Me.CmbMetodoPago = New Selling.StoreCombo
        Me.LblMetodoPago = New System.Windows.Forms.Label
        Me.TxtNSS = New System.Windows.Forms.TextBox
        Me.TxtNumEmpleado = New System.Windows.Forms.TextBox
        Me.BtnAbrir = New Janus.Windows.EditControls.UIButton
        Me.BtnNuevo = New Janus.Windows.EditControls.UIButton
        Me.TxtRFC = New System.Windows.Forms.TextBox
        Me.LstDomicilio = New System.Windows.Forms.ListBox
        Me.lblRFC = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.BtnBuscaEmp = New Janus.Windows.EditControls.UIButton
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtCURP = New System.Windows.Forms.TextBox
        Me.GrpDetalle = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtFechaPago = New System.Windows.Forms.DateTimePicker
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.BtnConcepto = New Janus.Windows.EditControls.UIButton
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.LblSubtotal = New System.Windows.Forms.Label
        Me.LblIVA = New System.Windows.Forms.Label
        Me.TxtNeto = New System.Windows.Forms.TextBox
        Me.TxtDeducciones = New System.Windows.Forms.TextBox
        Me.TxtIngreso = New System.Windows.Forms.TextBox
        Me.LblTotal = New System.Windows.Forms.Label
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
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
        Me.GrpCliente.SuspendLayout()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpDomicilio
        '
        Me.GrpDomicilio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDomicilio.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpDomicilio.Controls.Add(Me.PictureBox24)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox23)
        Me.GrpDomicilio.Controls.Add(Me.Label18)
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
        'GrpCliente
        '
        Me.GrpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCliente.Controls.Add(Me.LblTipoCambio)
        Me.GrpCliente.Controls.Add(Me.BtnTC)
        Me.GrpCliente.Controls.Add(Me.Label3)
        Me.GrpCliente.Controls.Add(Me.Label6)
        Me.GrpCliente.Controls.Add(Me.CmbFormaPago)
        Me.GrpCliente.Controls.Add(Me.cmbBanco)
        Me.GrpCliente.Controls.Add(Me.LblBanco)
        Me.GrpCliente.Controls.Add(Me.TxtRef)
        Me.GrpCliente.Controls.Add(Me.LblNoCta)
        Me.GrpCliente.Controls.Add(Me.CmbMetodoPago)
        Me.GrpCliente.Controls.Add(Me.LblMetodoPago)
        Me.GrpCliente.Controls.Add(Me.TxtNSS)
        Me.GrpCliente.Controls.Add(Me.TxtNumEmpleado)
        Me.GrpCliente.Controls.Add(Me.BtnAbrir)
        Me.GrpCliente.Controls.Add(Me.BtnNuevo)
        Me.GrpCliente.Controls.Add(Me.TxtRFC)
        Me.GrpCliente.Controls.Add(Me.LstDomicilio)
        Me.GrpCliente.Controls.Add(Me.lblRFC)
        Me.GrpCliente.Controls.Add(Me.Label11)
        Me.GrpCliente.Controls.Add(Me.BtnBuscaEmp)
        Me.GrpCliente.Controls.Add(Me.TxtRazonSocial)
        Me.GrpCliente.Controls.Add(Me.Label2)
        Me.GrpCliente.Controls.Add(Me.TxtCURP)
        Me.GrpCliente.Location = New System.Drawing.Point(5, 4)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.Size = New System.Drawing.Size(769, 211)
        Me.GrpCliente.TabIndex = 4
        Me.GrpCliente.TabStop = False
        Me.GrpCliente.Text = "Datos Empleado"
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.Location = New System.Drawing.Point(641, 48)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(101, 14)
        Me.LblTipoCambio.TabIndex = 127
        '
        'BtnTC
        '
        Me.BtnTC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTC.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton
        Me.BtnTC.ContextMenuStrip = Me.CtxDocumentos
        Me.BtnTC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTC.Location = New System.Drawing.Point(633, 11)
        Me.BtnTC.Name = "BtnTC"
        Me.BtnTC.Size = New System.Drawing.Size(127, 30)
        Me.BtnTC.TabIndex = 126
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
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 15)
        Me.Label3.TabIndex = 125
        Me.Label3.Text = "Domicilio"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(366, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 15)
        Me.Label6.TabIndex = 124
        Me.Label6.Text = "Forma de Pago"
        '
        'CmbFormaPago
        '
        Me.CmbFormaPago.BackColor = System.Drawing.SystemColors.Window
        Me.CmbFormaPago.ItemHeight = 13
        Me.CmbFormaPago.Location = New System.Drawing.Point(460, 161)
        Me.CmbFormaPago.Name = "CmbFormaPago"
        Me.CmbFormaPago.Size = New System.Drawing.Size(182, 21)
        Me.CmbFormaPago.TabIndex = 123
        '
        'cmbBanco
        '
        Me.cmbBanco.Location = New System.Drawing.Point(109, 186)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(252, 21)
        Me.cmbBanco.TabIndex = 103
        '
        'LblBanco
        '
        Me.LblBanco.Location = New System.Drawing.Point(6, 188)
        Me.LblBanco.Name = "LblBanco"
        Me.LblBanco.Size = New System.Drawing.Size(45, 15)
        Me.LblBanco.TabIndex = 104
        Me.LblBanco.Text = "Banco"
        '
        'TxtRef
        '
        Me.TxtRef.Location = New System.Drawing.Point(460, 187)
        Me.TxtRef.Name = "TxtRef"
        Me.TxtRef.Size = New System.Drawing.Size(182, 20)
        Me.TxtRef.TabIndex = 101
        '
        'LblNoCta
        '
        Me.LblNoCta.Location = New System.Drawing.Point(366, 187)
        Me.LblNoCta.Name = "LblNoCta"
        Me.LblNoCta.Size = New System.Drawing.Size(99, 16)
        Me.LblNoCta.TabIndex = 102
        Me.LblNoCta.Text = "No. Cta o Tarjeta"
        '
        'CmbMetodoPago
        '
        Me.CmbMetodoPago.Location = New System.Drawing.Point(109, 161)
        Me.CmbMetodoPago.Name = "CmbMetodoPago"
        Me.CmbMetodoPago.Size = New System.Drawing.Size(252, 21)
        Me.CmbMetodoPago.TabIndex = 98
        '
        'LblMetodoPago
        '
        Me.LblMetodoPago.Location = New System.Drawing.Point(7, 163)
        Me.LblMetodoPago.Name = "LblMetodoPago"
        Me.LblMetodoPago.Size = New System.Drawing.Size(87, 15)
        Me.LblMetodoPago.TabIndex = 99
        Me.LblMetodoPago.Text = "Metodo de Pago"
        '
        'TxtNSS
        '
        Me.TxtNSS.Enabled = False
        Me.TxtNSS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNSS.Location = New System.Drawing.Point(459, 44)
        Me.TxtNSS.Name = "TxtNSS"
        Me.TxtNSS.ReadOnly = True
        Me.TxtNSS.Size = New System.Drawing.Size(182, 21)
        Me.TxtNSS.TabIndex = 97
        '
        'TxtNumEmpleado
        '
        Me.TxtNumEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtNumEmpleado.Location = New System.Drawing.Point(109, 17)
        Me.TxtNumEmpleado.Name = "TxtNumEmpleado"
        Me.TxtNumEmpleado.Size = New System.Drawing.Size(113, 21)
        Me.TxtNumEmpleado.TabIndex = 96
        '
        'BtnAbrir
        '
        Me.BtnAbrir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAbrir.Icon = CType(resources.GetObject("BtnAbrir.Icon"), System.Drawing.Icon)
        Me.BtnAbrir.Location = New System.Drawing.Point(278, 12)
        Me.BtnAbrir.Name = "BtnAbrir"
        Me.BtnAbrir.Size = New System.Drawing.Size(90, 30)
        Me.BtnAbrir.TabIndex = 95
        Me.BtnAbrir.Text = "&Abrir"
        Me.BtnAbrir.ToolTipText = "Modificar datos del Empleado"
        Me.BtnAbrir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNuevo.Icon = CType(resources.GetObject("BtnNuevo.Icon"), System.Drawing.Icon)
        Me.BtnNuevo.Location = New System.Drawing.Point(375, 12)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(90, 30)
        Me.BtnNuevo.TabIndex = 94
        Me.BtnNuevo.Text = "&Nuevo"
        Me.BtnNuevo.ToolTipText = "Agregar nuevo Empleado"
        Me.BtnNuevo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtRFC
        '
        Me.TxtRFC.Enabled = False
        Me.TxtRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRFC.Location = New System.Drawing.Point(108, 44)
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.ReadOnly = True
        Me.TxtRFC.Size = New System.Drawing.Size(165, 21)
        Me.TxtRFC.TabIndex = 93
        '
        'LstDomicilio
        '
        Me.LstDomicilio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LstDomicilio.Enabled = False
        Me.LstDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstDomicilio.ItemHeight = 15
        Me.LstDomicilio.Location = New System.Drawing.Point(108, 96)
        Me.LstDomicilio.Name = "LstDomicilio"
        Me.LstDomicilio.Size = New System.Drawing.Size(652, 34)
        Me.LstDomicilio.TabIndex = 92
        '
        'lblRFC
        '
        Me.lblRFC.Location = New System.Drawing.Point(7, 48)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(100, 15)
        Me.lblRFC.TabIndex = 91
        Me.lblRFC.Text = "RFC / CURP/ NSS"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(6, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 14)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Razón Social"
        '
        'BtnBuscaEmp
        '
        Me.BtnBuscaEmp.Image = CType(resources.GetObject("BtnBuscaEmp.Image"), System.Drawing.Image)
        Me.BtnBuscaEmp.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaEmp.Location = New System.Drawing.Point(242, 12)
        Me.BtnBuscaEmp.Name = "BtnBuscaEmp"
        Me.BtnBuscaEmp.Size = New System.Drawing.Size(30, 30)
        Me.BtnBuscaEmp.TabIndex = 1
        Me.BtnBuscaEmp.ToolTipText = "Busqueda de Empleados"
        Me.BtnBuscaEmp.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRazonSocial.Enabled = False
        Me.TxtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRazonSocial.Location = New System.Drawing.Point(108, 70)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(652, 19)
        Me.TxtRazonSocial.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 14)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Num. "
        '
        'TxtCURP
        '
        Me.TxtCURP.Enabled = False
        Me.TxtCURP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCURP.Location = New System.Drawing.Point(278, 44)
        Me.TxtCURP.Name = "TxtCURP"
        Me.TxtCURP.ReadOnly = True
        Me.TxtCURP.Size = New System.Drawing.Size(176, 21)
        Me.TxtCURP.TabIndex = 3
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.Controls.Add(Me.Label5)
        Me.GrpDetalle.Controls.Add(Me.dtFechaPago)
        Me.GrpDetalle.Controls.Add(Me.BtnEliminar)
        Me.GrpDetalle.Controls.Add(Me.BtnConcepto)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Location = New System.Drawing.Point(5, 217)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(769, 276)
        Me.GrpDetalle.TabIndex = 5
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 15)
        Me.Label5.TabIndex = 127
        Me.Label5.Text = "Fecha de Pago"
        '
        'dtFechaPago
        '
        Me.dtFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaPago.Location = New System.Drawing.Point(96, 18)
        Me.dtFechaPago.Name = "dtFechaPago"
        Me.dtFechaPago.Size = New System.Drawing.Size(118, 20)
        Me.dtFechaPago.TabIndex = 126
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Icon = CType(resources.GetObject("BtnEliminar.Icon"), System.Drawing.Icon)
        Me.BtnEliminar.Location = New System.Drawing.Point(572, 13)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 30)
        Me.BtnEliminar.TabIndex = 97
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.ToolTipText = "Eliminar Concepto Seleccionado"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnConcepto
        '
        Me.BtnConcepto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConcepto.Icon = CType(resources.GetObject("BtnConcepto.Icon"), System.Drawing.Icon)
        Me.BtnConcepto.Location = New System.Drawing.Point(667, 13)
        Me.BtnConcepto.Name = "BtnConcepto"
        Me.BtnConcepto.Size = New System.Drawing.Size(90, 30)
        Me.BtnConcepto.TabIndex = 96
        Me.BtnConcepto.Text = "&Concepto"
        Me.BtnConcepto.ToolTipText = "Agregar Nuevo Concepto"
        Me.BtnConcepto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridDetalle
        '
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(7, 49)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(753, 219)
        Me.GridDetalle.TabIndex = 4
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LblSubtotal
        '
        Me.LblSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSubtotal.Location = New System.Drawing.Point(176, 506)
        Me.LblSubtotal.Name = "LblSubtotal"
        Me.LblSubtotal.Size = New System.Drawing.Size(54, 15)
        Me.LblSubtotal.TabIndex = 98
        Me.LblSubtotal.Text = "Ingresos"
        '
        'LblIVA
        '
        Me.LblIVA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblIVA.Location = New System.Drawing.Point(367, 506)
        Me.LblIVA.Name = "LblIVA"
        Me.LblIVA.Size = New System.Drawing.Size(79, 15)
        Me.LblIVA.TabIndex = 97
        Me.LblIVA.Text = "Deducciones"
        '
        'TxtNeto
        '
        Me.TxtNeto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNeto.Enabled = False
        Me.TxtNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNeto.Location = New System.Drawing.Point(649, 501)
        Me.TxtNeto.Name = "TxtNeto"
        Me.TxtNeto.ReadOnly = True
        Me.TxtNeto.Size = New System.Drawing.Size(125, 26)
        Me.TxtNeto.TabIndex = 95
        Me.TxtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtDeducciones
        '
        Me.TxtDeducciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDeducciones.Enabled = False
        Me.TxtDeducciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDeducciones.Location = New System.Drawing.Point(451, 501)
        Me.TxtDeducciones.Name = "TxtDeducciones"
        Me.TxtDeducciones.ReadOnly = True
        Me.TxtDeducciones.Size = New System.Drawing.Size(125, 26)
        Me.TxtDeducciones.TabIndex = 94
        Me.TxtDeducciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtIngreso
        '
        Me.TxtIngreso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtIngreso.Enabled = False
        Me.TxtIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIngreso.Location = New System.Drawing.Point(239, 501)
        Me.TxtIngreso.Name = "TxtIngreso"
        Me.TxtIngreso.ReadOnly = True
        Me.TxtIngreso.Size = New System.Drawing.Size(125, 26)
        Me.TxtIngreso.TabIndex = 93
        Me.TxtIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.Location = New System.Drawing.Point(578, 508)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(73, 18)
        Me.LblTotal.TabIndex = 96
        Me.LblTotal.Text = "Neto a Pagar"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(684, 532)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(588, 532)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmReciboNomina
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 575)
        Me.Controls.Add(Me.LblSubtotal)
        Me.Controls.Add(Me.LblIVA)
        Me.Controls.Add(Me.TxtNeto)
        Me.Controls.Add(Me.TxtDeducciones)
        Me.Controls.Add(Me.TxtIngreso)
        Me.Controls.Add(Me.LblTotal)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.GrpCliente)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 432)
        Me.Name = "FrmReciboNomina"
        Me.Text = "Recibo Nómina"
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
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        Me.GrpDetalle.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Variables Publicas"

    Public Padre As String

    Public regimenFiscal As String

    Public RENClave As String
    Public NumEmpleado As String
    Public NOMClave As String
    Public SUCClave As String
    Public editado As Boolean = False

    Public PercepcionesGravadas, PercepcionesExentas As Double
    Public DeduccionesGravadas, DeduccionesExentas As Double
    Public TotalaPagar, TotalIncapacidades, TotalHorasExtra As Double
    Public Moneda As String


#End Region

#Region "Variables Privadas"

    Private EMPClave As String
    Private Empleado As String
    Private TipoBanco As Integer

    Private tipoDeComprobante As String = "egreso"
    Private TipoCF As Integer = 2
    Private VersionCF As String = "3.2"

    Private formaDePago, metodoDePago, Referencia As String

    Private fechaPago As Date = Today.Date

    Private aEstado() As String
    Private aMnpio() As String
    Private aColonia() As String

    Private Cnx As String


    Private cargado As Boolean = False

    Private guardado As Boolean = False


    Private dtDetalle, dtIncapacidad, dtHorasExtra As DataTable

    Private MonedaRef, MonedaDesc As String
    Private TipoCambio As Double


    Private FOLClave, Serie, Folio As String


#End Region

#Region "ReciboNomina"

    Private Sub reinicializaEmpleado()

        EMPClave = ""
        TxtNumEmpleado.Text = ""
        TxtRazonSocial.Text = ""
        TxtRFC.Text = ""
        TxtNSS.Text = ""
        TxtCURP.Text = ""
        TxtRef.Text = ""
        Me.LstDomicilio.Items.Clear()
        TxtNumEmpleado.Focus()
    End Sub


    Private Sub FrmReciboNomina_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.BringToFront()

       
        Cnx = ModPOS.BDConexion


        With CmbFormaPago
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "CFD"
            .NombreParametro2 = "campo"
            .Parametro2 = "FormaPago"
            .llenar()
        End With

        With Me.CmbMetodoPago
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "CFD"
            .NombreParametro2 = "campo"
            .Parametro2 = "MetodoPago"
            .llenar()
        End With

        With Me.cmbBanco
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Empleado"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoBanco"
            .llenar()
        End With



        Dim dt As DataTable



        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
        BtnTC.Text = dt.Rows(0)("Referencia")
        MonedaRef = dt.Rows(0)("Referencia")
        MonedaDesc = dt.Rows(0)("Descripcion")
        TipoCambio = dt.Rows(0)("TipoCambio")
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_muestra_monedas", Nothing)

        Dim i As Integer

        For i = 0 To dt.Rows.Count - 1
            Me.CtxDocumentos.Items.Add(dt.Rows(i)("Referencia"))
        Next
        dt.Dispose()




        cargado = True

        If Padre = "Agregar" Then

            RENClave = ModPOS.obtenerLlave

            dtDetalle = ModPOS.CrearTabla("ReciboDetalle", _
                                                  "CONClave", "System.String", _
                                                  "Tipo", "System.Int32", _
                                                  "TipoConcepto", "System.Int32", _
                                                  "Clave", "System.String", _
                                                  "Concepto", "System.String", _
                                                  "ImporteGravado", "System.Double", _
                                                  "ImporteExento", "System.Double", _
                                                  "REDClave", "System.String")

            dtIncapacidad = ModPOS.CrearTabla("IncapacidadDetalle", _
                                                   "Tipo", "System.String", _
                                                   "Dias", "System.Double", _
                                                   "TipoIncapacidad", "System.Int32", _
                                                   "Descuento", "System.Double", _
                                                   "CONClave", "System.String", _
                                                   "REDClave", "System.String")



            dtHorasExtra = ModPOS.CrearTabla("HorasExtraDetalle", _
                                        "Tipo", "System.String", _
                                        "Dias", "System.Int32", _
                                        "HorasExtra", "System.Int32", _
                                        "ImportePagado", "System.Double", _
                                        "CONClave", "System.String", _
                                        "REDClave", "System.String")

        Else

            Me.CargaDatosEmpleado(NumEmpleado)

            dt = ModPOS.Recupera_Tabla("sp_recupera_reciboNomina", "@RENClave", RENClave)


            metodoDePago = dt.Rows(0)("MetodoPago")
            formaDePago = dt.Rows(0)("formaDePago")
            TipoBanco = dt.Rows(0)("TipoBanco")
            Referencia = dt.Rows(0)("Referencia")
            fechaPago = dt.Rows(0)("FechaPago")
            CmbMetodoPago.Text = metodoDePago
            CmbFormaPago.Text = formaDePago
            cmbBanco.SelectedValue = TipoBanco
            TxtRef.Text = Referencia

            dt.Dispose()

            dtDetalle = ModPOS.Recupera_Tabla("sp_recupera_recibodet", "@RENClave", RENClave)
            dtIncapacidad = ModPOS.Recupera_Tabla("sp_recupera_incapacidad", "@RENClave", RENClave)
            dtHorasExtra = ModPOS.Recupera_Tabla("sp_recupera_horasextra", "@RENClave", RENClave)
        End If


       
        If CmbMetodoPago.SelectedValue = 1 OrElse CmbMetodoPago.SelectedValue >= 7 Then
            cmbBanco.Visible = False
            TxtRef.Visible = False
            TxtRef.Text = ""
        Else
            cmbBanco.Visible = True
            TxtRef.Visible = True
        End If


        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("CONClave").Visible = False
        GridDetalle.RootTable.Columns("Tipo").Visible = False
        GridDetalle.RootTable.Columns("TipoConcepto").Visible = False
        GridDetalle.CurrentTable.Columns("Clave").Selectable = False
        GridDetalle.CurrentTable.Columns("Concepto").Selectable = False
        GridDetalle.RootTable.Columns("REDClave").Visible = False

        dtFechaPago.Value = fechaPago

        actualizaTotales()

    End Sub

    Private Sub actualizaTotales()
        Dim fI, fD As Janus.Windows.GridEX.GridEXFilterCondition
        Dim col As Janus.Windows.GridEX.GridEXColumn

        col = Me.GridDetalle.RootTable.Columns("Tipo")

        fI = New Janus.Windows.GridEX.GridEXFilterCondition(col, Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fD = New Janus.Windows.GridEX.GridEXFilterCondition(col, Janus.Windows.GridEX.ConditionOperator.Equal, 2)
        
        PercepcionesGravadas = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns(5), Janus.Windows.GridEX.AggregateFunction.Sum, fI)
        PercepcionesExentas = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns(6), Janus.Windows.GridEX.AggregateFunction.Sum, fI)


        DeduccionesGravadas = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns(5), Janus.Windows.GridEX.AggregateFunction.Sum, fD)
        DeduccionesExentas = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns(6), Janus.Windows.GridEX.AggregateFunction.Sum, fD)

        TotalaPagar = PercepcionesGravadas + PercepcionesExentas - DeduccionesGravadas - DeduccionesExentas

        Me.TxtIngreso.Text = Format(CStr(ModPOS.Redondear(PercepcionesGravadas + PercepcionesExentas, 2)), "Currency")
        TxtDeducciones.Text = Format(CStr(ModPOS.Redondear(DeduccionesGravadas - DeduccionesExentas, 2)), "Currency")
        Me.TxtNeto.Text = Format(CStr(ModPOS.Redondear(TotalaPagar, 2)), "Currency")

        If dtIncapacidad.Rows.Count > 0 Then
            TotalIncapacidades = Me.dtIncapacidad.Compute("SUM(Descuento)", "")
        Else
            TotalIncapacidades = 0
        End If

        If dtHorasExtra.Rows.Count > 0 Then
            TotalHorasExtra = Me.dtHorasExtra.Compute("SUM(ImportePagado)", "")
        Else
            TotalHorasExtra = 0
        End If


    End Sub


    Public Sub AddIncapacidad( _
        ByVal sTipo As String, _
        ByVal dDias As Double, _
        ByVal iTipoIncapacidad As Integer, _
        ByVal dDescuento As Double, _
        ByVal sCONClave As String, _
    ByVal sREDClave As String)


        Dim row1 As DataRow
        row1 = dtIncapacidad.NewRow()
        'declara el nombre de la fila

        row1.Item("Tipo") = sTipo
        row1.Item("Dias") = dDias
        row1.Item("TipoIncapacidad") = iTipoIncapacidad
        row1.Item("Descuento") = dDescuento
        row1.Item("CONClave") = sCONClave
        row1.Item("REDClave") = sREDClave


        dtIncapacidad.Rows.Add(row1)

        editado = True

    End Sub

    Public Sub AddHorasExtras( _
       ByVal sTipo As String, _
       ByVal iDias As Integer, _
       ByVal iHorasExtra As Integer, _
       ByVal dImportePagado As Double, _
       ByVal sCONClave As String, _
    ByVal sREDClave As String)

        Dim row1 As DataRow
        row1 = dtHorasExtra.NewRow()
        'declara el nombre de la fila

        row1.Item("Tipo") = sTipo
        row1.Item("Dias") = iDias
        row1.Item("HorasExtra") = iHorasExtra
        row1.Item("ImportePagado") = dImportePagado
        row1.Item("CONClave") = sCONClave
        row1.Item("REDClave") = sREDClave


        dtHorasExtra.Rows.Add(row1)
        'agrega la fila completo a la tabla
        editado = True

    End Sub


    Public Function AddConceptoNomina( _
    ByVal sCONClave As String, _
    ByVal iTipo As Integer, _
    ByVal iTipoConcepto As Integer, _
    ByVal sClave As String, _
    ByVal sConcepto As String, _
    ByVal dImporteGravado As Double, _
    ByVal dImporteExento As Double, _
    ByVal sREDClave As String) As Boolean

        Dim foundRows() As Data.DataRow
        foundRows = dtDetalle.Select("CONClave Like '" & sCONClave & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtDetalle.NewRow()
            'declara el nombre de la fila


            row1.Item("CONClave") = sCONClave
            row1.Item("Tipo") = iTipo
            row1.Item("TipoConcepto") = iTipoConcepto
            row1.Item("Clave") = sClave
            row1.Item("Concepto") = sConcepto
            row1.Item("ImporteGravado") = dImporteGravado
            row1.Item("ImporteExento") = dImporteExento
            row1.Item("REDClave") = sREDClave

            dtDetalle.Rows.Add(row1)
            'agrega la fila completo a la tabla

            editado = True

            actualizaTotales()

            Return True
        Else
            Beep()
            MessageBox.Show("¡El Concepto que intenta agregar ya existe para el recibo de nómina actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return False
        End If

    End Function

    Private Sub FrmReciboNomina_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.Nomina Is Nothing Then
            If guardado = True Then
                ModPOS.Nomina.actualizaGridRecibos()
            End If
        End If
        ModPOS.ReciboNomina.Dispose()
        ModPOS.ReciboNomina = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        If EMPClave = "" Then
            MessageBox.Show("La información del empleado es requerida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If GridDetalle.RowCount = 0 Then
            MessageBox.Show("Debe agregar por lo menos 1 concepto al recibo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If TotalaPagar <= 0 Then
            MessageBox.Show("El importe a pagar no puede ser menor o igual a cero", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If


        If CmbFormaPago.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar una opcion valida de Forma de Pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        If CmbMetodoPago.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar una opcion valida de Metodo de Pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        If Not (CmbMetodoPago.SelectedValue = 1 OrElse CmbMetodoPago.SelectedValue >= 7) Then
            If TxtRef.Text.Length < 4 Then
                Beep()
                MessageBox.Show("La referencia debe contener al menos 4 carates o digitos. Por ejemplo los ultimos 4 digitos de la tarjea o de la cuenta bancaria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        Else
            TxtRef.Text = ""
        End If


      
        If cmbBanco.SelectedValue Is Nothing AndAlso (CmbMetodoPago.SelectedValue > 1 AndAlso CmbMetodoPago.SelectedValue < 7) Then
            Beep()
            MessageBox.Show("Debe seleccionar un Banco valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If


        Select Case Me.Padre
            Case "Agregar"

                formaDePago = Me.CmbFormaPago.Text.Trim
                metodoDePago = Me.CmbMetodoPago.Text.Trim
                Referencia = TxtRef.Text

                If cmbBanco.SelectedValue Is Nothing OrElse (CmbMetodoPago.SelectedValue = 1 OrElse CmbMetodoPago.SelectedValue >= 7) Then
                    TipoBanco = 0
                Else
                    TipoBanco = cmbBanco.SelectedValue
                End If

               
                If recuperaFolio() = False Then
                    Exit Sub
                End If

                RENClave = ModPOS.obtenerLlave

                fechaPago = dtFechaPago.Value

                ModPOS.Ejecuta("sp_inserta_reciboNomina", _
                                   "@RENClave", RENClave, _
                                   "@NOMClave", NOMClave, _
                                   "@EMPClave", EMPClave, _
                                   "@Serie", Serie, _
                                   "@Folio", Folio, _
                                   "@tipo", tipoDeComprobante, _
                                   "@TipoCF", TipoCF, _
                                   "@VersionCF", VersionCF, _
                                    "@RegimenFiscal", regimenFiscal, _
                                    "@FechaPago", fechaPago, _
                                    "@TotalGravadoP", PercepcionesGravadas, _
                                    "@TotalExentoP", PercepcionesExentas, _
                                    "@TotalGravadoD", DeduccionesGravadas, _
                                    "@TotalExentoD", DeduccionesExentas, _
                                    "@TotalIncapacidades", TotalIncapacidades, _
                                    "@TotalHorasExtra", TotalHorasExtra, _
                                    "@TotalNetoPagar", TotalaPagar, _
                                    "@formaDePago", formaDePago, _
                                    "@MONClave", Moneda, _
                                    "@MetodoPago", metodoDePago, _
                                    "@TipoBanco", TipoBanco, _
                                    "@Referencia", Referencia, _
                                    "@TipoCambio", TipoCambio, _
                                    "@TipoEstado", 2, _
                                    "@Usuario", ModPOS.UsuarioActual)

                Dim fila As Integer

                For fila = 0 To dtDetalle.Rows.Count - 1
                    ModPOS.Ejecuta("sp_inserta_reciboDetalle", _
                                        "@REDClave", dtDetalle.Rows(fila)("REDClave"), _
                                        "@RENClave", RENClave, _
                                        "@CONClave", dtDetalle.Rows(fila)("CONClave"), _
                                        "@ImporteGravado", dtDetalle.Rows(fila)("ImporteGravado"), _
                                        "@ImporteExento", dtDetalle.Rows(fila)("ImporteExento"), _
                                        "@Usuario", ModPOS.UsuarioActual)
                Next


                If dtIncapacidad.Rows.Count > 0 Then

                    For fila = 0 To dtIncapacidad.Rows.Count - 1
                        ModPOS.Ejecuta("sp_inserta_incapacidades", _
                                            "@REDClave", dtIncapacidad.Rows(fila)("REDClave"), _
                                            "@Dias", dtIncapacidad.Rows(fila)("Dias"), _
                                            "@Tipo", dtIncapacidad.Rows(fila)("TipoIncapacidad"), _
                                            "@Descuento", dtIncapacidad.Rows(fila)("Descuento"))
                    Next
                End If

                If dtHorasExtra.Rows.Count > 0 Then
                    For fila = 0 To dtHorasExtra.Rows.Count - 1
                        ModPOS.Ejecuta("sp_inserta_horasextra", _
                                            "@REDClave", dtHorasExtra.Rows(fila)("REDClave"), _
                                            "@Tipo", dtHorasExtra.Rows(fila)("Tipo"), _
                                            "@Dias", dtHorasExtra.Rows(fila)("Dias"), _
                                            "@HorasExtra", dtHorasExtra.Rows(fila)("HorasExtra"), _
                                            "@ImportePagado", dtHorasExtra.Rows(fila)("ImportePagado"))
                    Next
                End If


                guardado = True
                Me.Close()

            Case "Modificar"
                If Not (editado = False AndAlso _
                    CmbMetodoPago.Text = metodoDePago AndAlso _
                    CmbFormaPago.Text = formaDePago AndAlso _
                    cmbBanco.SelectedValue = TipoBanco AndAlso _
                    fechaPago = dtFechaPago.Value AndAlso _
                    TxtRef.Text = Referencia) Then


                    formaDePago = Me.CmbFormaPago.Text.Trim
                    metodoDePago = Me.CmbMetodoPago.Text.Trim
                    Referencia = TxtRef.Text
                    fechaPago = dtFechaPago.Value


                    If cmbBanco.SelectedValue Is Nothing OrElse (CmbMetodoPago.SelectedValue = 1 OrElse CmbMetodoPago.SelectedValue >= 7) Then
                        TipoBanco = 0
                    Else
                        TipoBanco = cmbBanco.SelectedValue
                    End If


                    ModPOS.Ejecuta("sp_actualiza_reciboNomina", _
                                       "@RENClave", RENClave, _
                                       "@EMPClave", EMPClave, _
                                        "@FechaPago", fechaPago, _
                                        "@TotalGravadoP", PercepcionesGravadas, _
                                        "@TotalExentoP", PercepcionesExentas, _
                                        "@TotalGravadoD", DeduccionesGravadas, _
                                        "@TotalExentoD", DeduccionesExentas, _
                                        "@TotalIncapacidades", TotalIncapacidades, _
                                        "@TotalHorasExtra", TotalHorasExtra, _
                                        "@TotalNetoPagar", TotalaPagar, _
                                        "@formaDePago", formaDePago, _
                                        "@MONClave", Moneda, _
                                        "@MetodoPago", metodoDePago, _
                                        "@TipoBanco", TipoBanco, _
                                        "@Referencia", Referencia, _
                                        "@TipoCambio", TipoCambio, _
                                        "@TipoEstado", 2, _
                                        "@Usuario", ModPOS.UsuarioActual)

                    Dim fila As Integer


                    ModPOS.Ejecuta("sp_elimina_reciboDetalle", "@RENClave", RENClave)


                    For fila = 0 To dtDetalle.Rows.Count - 1
                        ModPOS.Ejecuta("sp_inserta_reciboDetalle", _
                                            "@REDClave", dtDetalle.Rows(fila)("REDClave"), _
                                            "@RENClave", RENClave, _
                                            "@CONClave", dtDetalle.Rows(fila)("CONClave"), _
                                            "@ImporteGravado", dtDetalle.Rows(fila)("ImporteGravado"), _
                                            "@ImporteExento", dtDetalle.Rows(fila)("ImporteExento"), _
                                            "@Usuario", ModPOS.UsuarioActual)
                    Next


                    If dtIncapacidad.Rows.Count > 0 Then

                        For fila = 0 To dtIncapacidad.Rows.Count - 1
                            ModPOS.Ejecuta("sp_inserta_incapacidades", _
                                                "@REDClave", dtIncapacidad.Rows(fila)("REDClave"), _
                                                "@Dias", dtIncapacidad.Rows(fila)("Dias"), _
                                                "@Tipo", dtIncapacidad.Rows(fila)("TipoIncapacidad"), _
                                                "@Descuento", dtIncapacidad.Rows(fila)("Descuento"))
                        Next
                    End If

                    If dtHorasExtra.Rows.Count > 0 Then
                        For fila = 0 To dtHorasExtra.Rows.Count - 1
                            ModPOS.Ejecuta("sp_inserta_horasextra", _
                                                "@REDClave", dtHorasExtra.Rows(fila)("REDClave"), _
                                                "@Tipo", dtHorasExtra.Rows(fila)("Tipo"), _
                                                "@Dias", dtHorasExtra.Rows(fila)("Dias"), _
                                                "@HorasExtra", dtHorasExtra.Rows(fila)("HorasExtra"), _
                                                "@ImportePagado", dtHorasExtra.Rows(fila)("ImportePagado"))
                        Next
                    End If



                    guardado = True
                End If
                Me.Close()
        End Select


    End Sub

    Public Function recuperaFolio() As Boolean

        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_recupera_folioactual", "@TipoComprobante", 9, "@SUCClave", SUCClave, "@CAJClave", "")

        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            If dt.Compute("SUM(FolioFinal) - SUM(FolioActual)", "") >= 1 Then
                FOLClave = dt.Rows(0)("FOLClave")
                Serie = dt.Rows(0)("Serie")
                Folio = CStr(dt.Rows(0)("FolioActual") + 1)
                dt.Dispose()

                ModPOS.Ejecuta("sp_incrementa_folio", "@FOLClave", FOLClave)

                Return True
            Else
                MessageBox.Show("No existen suficientes folios disponibles para el tipo de comprobante seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Else
            MessageBox.Show("No existen folios disponibles para el tipo de comprobante seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

    End Function


    Public Sub CargaDatosEmpleado(ByVal NumEmpleado As String)
        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_consulta_empleado", "@NumEmpleado", NumEmpleado, "@COMClave", ModPOS.CompanyActual)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

            EMPClave = dt.Rows(0)("EMPClave")
            NumEmpleado = dt.Rows(0)("NumEmpleado")
            TxtCURP.Text = dt.Rows(0)("CURP")
            TxtNSS.Text = dt.Rows(0)("NumSeguridadSocial")

            TipoBanco = dt.Rows(0)("TipoBanco")


            
            TxtRazonSocial.Text = dt.Rows(0)("NombreCompleto")
            TxtRFC.Text = dt.Rows(0)("id_Fiscal")
 

            LstDomicilio.Items.Clear()
            LstDomicilio.Items.Add(dt.Rows(0)("Calle") & " " & dt.Rows(0)("noExterior") & " " & dt.Rows(0)("noInterior"))
            LstDomicilio.Items.Add(dt.Rows(0)("Colonia") & ", " & dt.Rows(0)("codigoPostal"))
            LstDomicilio.Items.Add(dt.Rows(0)("Municipio") & ", " & dt.Rows(0)("Entidad"))


            cmbBanco.SelectedValue = tipobanco

            dt.Dispose()


             

        Else
            reinicializaEmpleado()
            MessageBox.Show("La información del empleado no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub TxtNumEmpleado_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNumEmpleado.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If TxtNumEmpleado.Text <> "" Then
                    CargaDatosEmpleado(TxtNumEmpleado.Text.Trim.Replace("'", "''"))
                End If
            Case Is = Keys.Right

                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_empleado"
                a.TablaCmb = "Empleado"
                a.CampoCmb = "Filtro"
                a.OcultaID = True
                a.NumColDes = 1
                a.BusquedaInicial = True
                a.CompaniaRequerido = True
                a.Busqueda = TxtNumEmpleado.Text.Trim.ToUpper
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If Not a.Descripcion Is Nothing Then
                        CargaDatosEmpleado(a.Descripcion)
                    End If
                End If
                a.Dispose()
        End Select

    End Sub

    Public Sub modificarEmpleado()

        If ModPOS.Empleado Is Nothing Then

            ModPOS.Empleado = New FrmEmpleado
            With ModPOS.Empleado
                .Text = "Modificar Empleado"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Modificar"
                .TxtNumEmpleado.ReadOnly = True
                .ChkEstado.Enabled = True
                .fromReciboNomina = True

                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_empleado", "@EMPClave", EMPClave)

                .EMPClave = dt.Rows(0)("EMPClave")
                .NumEmpleado = dt.Rows(0)("NumEmpleado")
                .NombreCompleto = dt.Rows(0)("NombreCompleto")
                .RFC = dt.Rows(0)("id_Fiscal")
                .NSS = dt.Rows(0)("NumSeguridadSocial")
                .CURP = dt.Rows(0)("CURP")
                .TipoRegimen = dt.Rows(0)("TipoRegimen")
                .Departamento = dt.Rows(0)("Departamento")
                .Puesto = dt.Rows(0)("Puesto")
                .TipoContrato = dt.Rows(0)("TipoContrato")
                .TipoJornada = dt.Rows(0)("TipoJornada")
                .CLABE = dt.Rows(0)("CLABE")
                .TipoBanco = dt.Rows(0)("TipoBanco")
                .FechaReg = dt.Rows(0)("FechaInicioRelLaboral")
                .PeriodicidadPago = dt.Rows(0)("PeriodicidadPago")
                .SalarioBase = dt.Rows(0)("SalarioBaseCotAport")
                .SalarioDiario = dt.Rows(0)("SalarioDiarioIntegrado")


                .PaisF = dt.Rows(0)("Pais")
                .EntidadF = dt.Rows(0)("Entidad")
                .MnpioF = dt.Rows(0)("Municipio")
                .ColoniaF = dt.Rows(0)("Colonia")
                .CalleF = dt.Rows(0)("Calle")
                .noExteriorF = dt.Rows(0)("noExterior")
                .noInteriorF = dt.Rows(0)("noInterior")
                .codigoPostalF = dt.Rows(0)("codigoPostal")

                .Contacto = dt.Rows(0)("Contacto")
                .Tel1 = dt.Rows(0)("Tel1")
                .Tel2 = dt.Rows(0)("Tel2")
                .email = dt.Rows(0)("Email")

                .TipoEstado = dt.Rows(0)("Estado")


                dt.Dispose()

            End With
        End If

        ModPOS.Empleado.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Empleado.Show()
        ModPOS.Empleado.BringToFront()

    End Sub

    Private Sub BtnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAbrir.Click
        If EMPClave <> "" Then
            modificarEmpleado()
        End If
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        If ModPOS.Empleado Is Nothing Then
            ModPOS.Empleado = New FrmEmpleado
            ModPOS.Empleado.fromReciboNomina = True
            With ModPOS.Empleado
                .Text = "Agregar Empleado"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .ChkEstado.Enabled = False
            End With
        End If
        ModPOS.Empleado.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Empleado.Show()
        ModPOS.Empleado.BringToFront()
    End Sub

    Private Sub BtnConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConcepto.Click
        If ModPOS.AddConcepto Is Nothing Then
            ModPOS.AddConcepto = New FrmAddConcepto
            With ModPOS.AddConcepto
                .Text = "Agregar Concepto de Nómina"
                .StartPosition = FormStartPosition.CenterScreen
            End With
        End If
        ModPOS.AddConcepto.StartPosition = FormStartPosition.CenterScreen
        ModPOS.AddConcepto.Show()
        ModPOS.AddConcepto.BringToFront()
    End Sub

    Private Sub BtnBuscaEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaEmp.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_empleado"
        a.TablaCmb = "Empleado"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.NumColDes = 1
        a.BusquedaInicial = True
        a.CompaniaRequerido = True
        a.Busqueda = TxtNumEmpleado.Text.Trim.ToUpper
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.Descripcion Is Nothing Then
                CargaDatosEmpleado(a.Descripcion)
            End If
        End If
        a.Dispose()
    End Sub


#End Region

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If GridDetalle.Row >= 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara del recibo de nómina actual el concepto :" & GridDetalle.GetValue("Concepto"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    Dim sCONCLAVE As String
                    Dim i As Integer

                    sCONCLAVE = GridDetalle.GetValue("CONClave")

                    foundRows = dtIncapacidad.Select("CONClave = '" & sCONCLAVE & "'")
                    If foundRows.Length > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)
                            dtIncapacidad.Rows.Remove(foundRows(i))
                        Next
                    End If

                    foundRows = dtHorasExtra.Select("CONClave = '" & sCONCLAVE & "'")

                    If foundRows.Length > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)
                            dtHorasExtra.Rows.Remove(foundRows(i))
                        Next
                    End If

                    foundRows = dtDetalle.Select("CONClave = '" & sCONCLAVE & "'")
                    dtDetalle.Rows.Remove(foundRows(0))

                    editado = True
                    actualizaTotales()
            End Select
        End If
    End Sub

    Private Sub GridDetalle_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited


        'importe Gravado
        If GridDetalle.GetValue(5) Is System.DBNull.Value OrElse IsNumeric(GridDetalle.GetValue(5)) = False OrElse GridDetalle.GetValue(5) < 0 Then
            GridDetalle.SetValue(5, 0)

        End If


        'importe exento
        If GridDetalle.GetValue(6) Is System.DBNull.Value OrElse IsNumeric(GridDetalle.GetValue(6)) = False OrElse GridDetalle.GetValue(6) < 0 Then
            GridDetalle.SetValue(6, 0)
        End If

        editado = True


    End Sub

    Private Sub GridDetalle_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.RecordUpdated
        actualizaTotales()
    End Sub

    Private Sub CmbMetodoPago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbMetodoPago.SelectedIndexChanged
        If cargado = True AndAlso (CmbMetodoPago.SelectedValue = 1 OrElse CmbMetodoPago.SelectedValue >= 7) Then
            cmbBanco.Visible = False
            TxtRef.Visible = False
            TxtRef.Text = ""
        Else
            cmbBanco.Visible = True
            TxtRef.Visible = True
            cmbBanco.SelectedValue = TipoBanco
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
        MonedaRef = dt.Rows(0)("Referencia")
        MonedaDesc = dt.Rows(0)("Descripcion")
        TipoCambio = dt.Rows(0)("TipoCambio")
        dt.Dispose()

        If CInt(TipoCambio) <> 1 Then
            LblTipoCambio.Text = "T.C. " & Format(CStr(ModPOS.Redondear(TipoCambio, 2)), "Currency")
        Else
            LblTipoCambio.Text = ""
        End If
        SendKeys.Send("{TAB}")

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
