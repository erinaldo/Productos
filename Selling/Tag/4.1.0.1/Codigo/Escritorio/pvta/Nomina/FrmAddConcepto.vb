Public Class FrmAddConcepto
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
    Friend WithEvents Lbl As System.Windows.Forms.Label
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
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
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
    Friend WithEvents GrpConcepto As System.Windows.Forms.GroupBox
    Friend WithEvents lblImporteExcento As System.Windows.Forms.Label
    Friend WithEvents lblImporteGravado As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnBuscaConcepto As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtImporteExento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtImporteGravado As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents grpIncapacidad As System.Windows.Forms.GroupBox
    Friend WithEvents GridIncapacidad As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnDelIncapacidad As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAddIncapacidad As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbTipoIncapacidad As Selling.StoreCombo
    Friend WithEvents grpHorasExtra As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoHorasExtra As Selling.StoreCombo
    Friend WithEvents btnDelHoraExtra As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAddHoraExtra As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridHoraExtra As Janus.Windows.GridEX.GridEX
    Friend WithEvents grpAcciones As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDelAccion As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAddAccion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridAcciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents grpJubilacion As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelJubilacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAddJubilacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridJubilacion As Janus.Windows.GridEX.GridEX
    Friend WithEvents grpSeparacion As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelSerparacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAddSeparacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridSeparacion As Janus.Windows.GridEX.GridEX
    Friend WithEvents grpCompensacion As System.Windows.Forms.GroupBox
    Friend WithEvents btnDelCompensacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAddCompensacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridCompensacion As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnModifica As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddConcepto))
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
        Me.Lbl = New System.Windows.Forms.Label()
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
        Me.GrpConcepto = New System.Windows.Forms.GroupBox()
        Me.txtImporteExento = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TxtImporteGravado = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.BtnBuscaConcepto = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblImporteExcento = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblImporteGravado = New System.Windows.Forms.Label()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.grpCompensacion = New System.Windows.Forms.GroupBox()
        Me.btnDelCompensacion = New Janus.Windows.EditControls.UIButton()
        Me.btnAddCompensacion = New Janus.Windows.EditControls.UIButton()
        Me.GridCompensacion = New Janus.Windows.GridEX.GridEX()
        Me.grpSeparacion = New System.Windows.Forms.GroupBox()
        Me.btnDelSerparacion = New Janus.Windows.EditControls.UIButton()
        Me.btnAddSeparacion = New Janus.Windows.EditControls.UIButton()
        Me.GridSeparacion = New Janus.Windows.GridEX.GridEX()
        Me.grpJubilacion = New System.Windows.Forms.GroupBox()
        Me.btnDelJubilacion = New Janus.Windows.EditControls.UIButton()
        Me.btnAddJubilacion = New Janus.Windows.EditControls.UIButton()
        Me.GridJubilacion = New Janus.Windows.GridEX.GridEX()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.grpIncapacidad = New System.Windows.Forms.GroupBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbTipoIncapacidad = New Selling.StoreCombo()
        Me.BtnDelIncapacidad = New Janus.Windows.EditControls.UIButton()
        Me.BtnAddIncapacidad = New Janus.Windows.EditControls.UIButton()
        Me.GridIncapacidad = New Janus.Windows.GridEX.GridEX()
        Me.grpHorasExtra = New System.Windows.Forms.GroupBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoHorasExtra = New Selling.StoreCombo()
        Me.btnDelHoraExtra = New Janus.Windows.EditControls.UIButton()
        Me.btnAddHoraExtra = New Janus.Windows.EditControls.UIButton()
        Me.GridHoraExtra = New Janus.Windows.GridEX.GridEX()
        Me.grpAcciones = New System.Windows.Forms.GroupBox()
        Me.BtnDelAccion = New Janus.Windows.EditControls.UIButton()
        Me.BtnAddAccion = New Janus.Windows.EditControls.UIButton()
        Me.GridAcciones = New Janus.Windows.GridEX.GridEX()
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
        Me.GrpConcepto.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCompensacion.SuspendLayout()
        CType(Me.GridCompensacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSeparacion.SuspendLayout()
        CType(Me.GridSeparacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpJubilacion.SuspendLayout()
        CType(Me.GridJubilacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpIncapacidad.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridIncapacidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpHorasExtra.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridHoraExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAcciones.SuspendLayout()
        CType(Me.GridAcciones, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GrpDomicilio.Controls.Add(Me.Lbl)
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
        'Lbl
        '
        Me.Lbl.Location = New System.Drawing.Point(8, 24)
        Me.Lbl.Name = "Lbl"
        Me.Lbl.Size = New System.Drawing.Size(32, 16)
        Me.Lbl.TabIndex = 61
        Me.Lbl.Text = "Tipo"
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
        'GrpConcepto
        '
        Me.GrpConcepto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpConcepto.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpConcepto.Controls.Add(Me.txtImporteExento)
        Me.GrpConcepto.Controls.Add(Me.TxtImporteGravado)
        Me.GrpConcepto.Controls.Add(Me.TxtDescripcion)
        Me.GrpConcepto.Controls.Add(Me.BtnBuscaConcepto)
        Me.GrpConcepto.Controls.Add(Me.PictureBox3)
        Me.GrpConcepto.Controls.Add(Me.PictureBox2)
        Me.GrpConcepto.Controls.Add(Me.lblImporteExcento)
        Me.GrpConcepto.Controls.Add(Me.lblTipo)
        Me.GrpConcepto.Controls.Add(Me.PictureBox1)
        Me.GrpConcepto.Controls.Add(Me.lblImporteGravado)
        Me.GrpConcepto.Controls.Add(Me.LblClave)
        Me.GrpConcepto.Controls.Add(Me.TxtClave)
        Me.GrpConcepto.Location = New System.Drawing.Point(0, 0)
        Me.GrpConcepto.Name = "GrpConcepto"
        Me.GrpConcepto.Size = New System.Drawing.Size(585, 140)
        Me.GrpConcepto.TabIndex = 4
        Me.GrpConcepto.TabStop = False
        Me.GrpConcepto.Text = "Concepto"
        '
        'txtImporteExento
        '
        Me.txtImporteExento.Location = New System.Drawing.Point(115, 109)
        Me.txtImporteExento.Name = "txtImporteExento"
        Me.txtImporteExento.Size = New System.Drawing.Size(130, 20)
        Me.txtImporteExento.TabIndex = 110
        Me.txtImporteExento.Text = "0.00"
        Me.txtImporteExento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtImporteExento.Value = 0.0R
        Me.txtImporteExento.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtImporteGravado
        '
        Me.TxtImporteGravado.Location = New System.Drawing.Point(115, 74)
        Me.TxtImporteGravado.Name = "TxtImporteGravado"
        Me.TxtImporteGravado.Size = New System.Drawing.Size(130, 20)
        Me.TxtImporteGravado.TabIndex = 109
        Me.TxtImporteGravado.Text = "0.00"
        Me.TxtImporteGravado.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtImporteGravado.Value = 0.0R
        Me.TxtImporteGravado.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcion.Enabled = False
        Me.TxtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(115, 45)
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(470, 19)
        Me.TxtDescripcion.TabIndex = 108
        '
        'BtnBuscaConcepto
        '
        Me.BtnBuscaConcepto.Image = CType(resources.GetObject("BtnBuscaConcepto.Image"), System.Drawing.Image)
        Me.BtnBuscaConcepto.ImageSize = New System.Drawing.Size(24, 24)
        Me.BtnBuscaConcepto.Location = New System.Drawing.Point(250, 13)
        Me.BtnBuscaConcepto.Name = "BtnBuscaConcepto"
        Me.BtnBuscaConcepto.Size = New System.Drawing.Size(24, 24)
        Me.BtnBuscaConcepto.TabIndex = 107
        Me.BtnBuscaConcepto.ToolTipText = "Busqueda de Conceptos"
        Me.BtnBuscaConcepto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(80, 110)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox3.TabIndex = 105
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(80, 77)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 104
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'lblImporteExcento
        '
        Me.lblImporteExcento.Location = New System.Drawing.Point(10, 111)
        Me.lblImporteExcento.Name = "lblImporteExcento"
        Me.lblImporteExcento.Size = New System.Drawing.Size(102, 15)
        Me.lblImporteExcento.TabIndex = 102
        Me.lblImporteExcento.Text = "Importe Exento"
        '
        'lblTipo
        '
        Me.lblTipo.Location = New System.Drawing.Point(11, 49)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(75, 15)
        Me.lblTipo.TabIndex = 91
        Me.lblTipo.Text = "Descripción"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(79, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 40
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'lblImporteGravado
        '
        Me.lblImporteGravado.Location = New System.Drawing.Point(10, 77)
        Me.lblImporteGravado.Name = "lblImporteGravado"
        Me.lblImporteGravado.Size = New System.Drawing.Size(102, 19)
        Me.lblImporteGravado.TabIndex = 34
        Me.lblImporteGravado.Text = "Importe Gravado"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(11, 19)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(76, 14)
        Me.LblClave.TabIndex = 1
        Me.LblClave.Text = "Clave"
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(115, 15)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(130, 20)
        Me.TxtClave.TabIndex = 0
        '
        'grpCompensacion
        '
        Me.grpCompensacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCompensacion.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpCompensacion.Controls.Add(Me.btnDelCompensacion)
        Me.grpCompensacion.Controls.Add(Me.btnAddCompensacion)
        Me.grpCompensacion.Controls.Add(Me.GridCompensacion)
        Me.grpCompensacion.Location = New System.Drawing.Point(7, 154)
        Me.grpCompensacion.Name = "grpCompensacion"
        Me.grpCompensacion.Size = New System.Drawing.Size(585, 120)
        Me.grpCompensacion.TabIndex = 113
        Me.grpCompensacion.TabStop = False
        Me.grpCompensacion.Text = "Detalle de Compensación"
        Me.grpCompensacion.Visible = False
        '
        'btnDelCompensacion
        '
        Me.btnDelCompensacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelCompensacion.Icon = CType(resources.GetObject("btnDelCompensacion.Icon"), System.Drawing.Icon)
        Me.btnDelCompensacion.Location = New System.Drawing.Point(480, 14)
        Me.btnDelCompensacion.Name = "btnDelCompensacion"
        Me.btnDelCompensacion.Size = New System.Drawing.Size(42, 24)
        Me.btnDelCompensacion.TabIndex = 99
        Me.btnDelCompensacion.ToolTipText = "Eliminar detalle de Incapacidad seleccionada"
        Me.btnDelCompensacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAddCompensacion
        '
        Me.btnAddCompensacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddCompensacion.Icon = CType(resources.GetObject("btnAddCompensacion.Icon"), System.Drawing.Icon)
        Me.btnAddCompensacion.Location = New System.Drawing.Point(532, 14)
        Me.btnAddCompensacion.Name = "btnAddCompensacion"
        Me.btnAddCompensacion.Size = New System.Drawing.Size(46, 24)
        Me.btnAddCompensacion.TabIndex = 98
        Me.btnAddCompensacion.ToolTipText = "Agregar detalle de Incapacidad"
        Me.btnAddCompensacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridCompensacion
        '
        Me.GridCompensacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCompensacion.ColumnAutoResize = True
        Me.GridCompensacion.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCompensacion.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCompensacion.GroupByBoxVisible = False
        Me.GridCompensacion.Location = New System.Drawing.Point(5, 44)
        Me.GridCompensacion.Name = "GridCompensacion"
        Me.GridCompensacion.RecordNavigator = True
        Me.GridCompensacion.Size = New System.Drawing.Size(575, 70)
        Me.GridCompensacion.TabIndex = 5
        Me.GridCompensacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'grpSeparacion
        '
        Me.grpSeparacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSeparacion.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpSeparacion.Controls.Add(Me.btnDelSerparacion)
        Me.grpSeparacion.Controls.Add(Me.btnAddSeparacion)
        Me.grpSeparacion.Controls.Add(Me.GridSeparacion)
        Me.grpSeparacion.Location = New System.Drawing.Point(7, 154)
        Me.grpSeparacion.Name = "grpSeparacion"
        Me.grpSeparacion.Size = New System.Drawing.Size(585, 120)
        Me.grpSeparacion.TabIndex = 112
        Me.grpSeparacion.TabStop = False
        Me.grpSeparacion.Text = "Detalle de Separación"
        Me.grpSeparacion.Visible = False
        '
        'btnDelSerparacion
        '
        Me.btnDelSerparacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelSerparacion.Icon = CType(resources.GetObject("btnDelSerparacion.Icon"), System.Drawing.Icon)
        Me.btnDelSerparacion.Location = New System.Drawing.Point(480, 14)
        Me.btnDelSerparacion.Name = "btnDelSerparacion"
        Me.btnDelSerparacion.Size = New System.Drawing.Size(42, 24)
        Me.btnDelSerparacion.TabIndex = 99
        Me.btnDelSerparacion.ToolTipText = "Eliminar detalle de Incapacidad seleccionada"
        Me.btnDelSerparacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAddSeparacion
        '
        Me.btnAddSeparacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddSeparacion.Icon = CType(resources.GetObject("btnAddSeparacion.Icon"), System.Drawing.Icon)
        Me.btnAddSeparacion.Location = New System.Drawing.Point(532, 14)
        Me.btnAddSeparacion.Name = "btnAddSeparacion"
        Me.btnAddSeparacion.Size = New System.Drawing.Size(46, 24)
        Me.btnAddSeparacion.TabIndex = 98
        Me.btnAddSeparacion.ToolTipText = "Agregar detalle de Incapacidad"
        Me.btnAddSeparacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridSeparacion
        '
        Me.GridSeparacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridSeparacion.ColumnAutoResize = True
        Me.GridSeparacion.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridSeparacion.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridSeparacion.GroupByBoxVisible = False
        Me.GridSeparacion.Location = New System.Drawing.Point(5, 44)
        Me.GridSeparacion.Name = "GridSeparacion"
        Me.GridSeparacion.RecordNavigator = True
        Me.GridSeparacion.Size = New System.Drawing.Size(575, 70)
        Me.GridSeparacion.TabIndex = 5
        Me.GridSeparacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'grpJubilacion
        '
        Me.grpJubilacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJubilacion.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpJubilacion.Controls.Add(Me.btnDelJubilacion)
        Me.grpJubilacion.Controls.Add(Me.btnAddJubilacion)
        Me.grpJubilacion.Controls.Add(Me.GridJubilacion)
        Me.grpJubilacion.Location = New System.Drawing.Point(7, 154)
        Me.grpJubilacion.Name = "grpJubilacion"
        Me.grpJubilacion.Size = New System.Drawing.Size(585, 120)
        Me.grpJubilacion.TabIndex = 111
        Me.grpJubilacion.TabStop = False
        Me.grpJubilacion.Text = "Detalle de Jubilación"
        Me.grpJubilacion.Visible = False
        '
        'btnDelJubilacion
        '
        Me.btnDelJubilacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelJubilacion.Icon = CType(resources.GetObject("btnDelJubilacion.Icon"), System.Drawing.Icon)
        Me.btnDelJubilacion.Location = New System.Drawing.Point(480, 14)
        Me.btnDelJubilacion.Name = "btnDelJubilacion"
        Me.btnDelJubilacion.Size = New System.Drawing.Size(42, 24)
        Me.btnDelJubilacion.TabIndex = 99
        Me.btnDelJubilacion.ToolTipText = "Eliminar detalle de Incapacidad seleccionada"
        Me.btnDelJubilacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAddJubilacion
        '
        Me.btnAddJubilacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddJubilacion.Icon = CType(resources.GetObject("btnAddJubilacion.Icon"), System.Drawing.Icon)
        Me.btnAddJubilacion.Location = New System.Drawing.Point(532, 14)
        Me.btnAddJubilacion.Name = "btnAddJubilacion"
        Me.btnAddJubilacion.Size = New System.Drawing.Size(46, 24)
        Me.btnAddJubilacion.TabIndex = 98
        Me.btnAddJubilacion.ToolTipText = "Agregar detalle de Incapacidad"
        Me.btnAddJubilacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridJubilacion
        '
        Me.GridJubilacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridJubilacion.ColumnAutoResize = True
        Me.GridJubilacion.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridJubilacion.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridJubilacion.GroupByBoxVisible = False
        Me.GridJubilacion.Location = New System.Drawing.Point(5, 44)
        Me.GridJubilacion.Name = "GridJubilacion"
        Me.GridJubilacion.RecordNavigator = True
        Me.GridJubilacion.Size = New System.Drawing.Size(575, 70)
        Me.GridJubilacion.TabIndex = 5
        Me.GridJubilacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(502, 158)
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
        Me.BtnCancelar.Location = New System.Drawing.Point(403, 158)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'grpIncapacidad
        '
        Me.grpIncapacidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpIncapacidad.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpIncapacidad.Controls.Add(Me.PictureBox5)
        Me.grpIncapacidad.Controls.Add(Me.Label4)
        Me.grpIncapacidad.Controls.Add(Me.CmbTipoIncapacidad)
        Me.grpIncapacidad.Controls.Add(Me.BtnDelIncapacidad)
        Me.grpIncapacidad.Controls.Add(Me.BtnAddIncapacidad)
        Me.grpIncapacidad.Controls.Add(Me.GridIncapacidad)
        Me.grpIncapacidad.Location = New System.Drawing.Point(7, 154)
        Me.grpIncapacidad.Name = "grpIncapacidad"
        Me.grpIncapacidad.Size = New System.Drawing.Size(585, 120)
        Me.grpIncapacidad.TabIndex = 5
        Me.grpIncapacidad.TabStop = False
        Me.grpIncapacidad.Text = "Detalle de Incapacidad"
        Me.grpIncapacidad.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(79, 19)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(15, 14)
        Me.PictureBox5.TabIndex = 126
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(7, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 17)
        Me.Label4.TabIndex = 125
        Me.Label4.Text = "Tipo Incapacidad"
        '
        'CmbTipoIncapacidad
        '
        Me.CmbTipoIncapacidad.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipoIncapacidad.ItemHeight = 13
        Me.CmbTipoIncapacidad.Location = New System.Drawing.Point(115, 16)
        Me.CmbTipoIncapacidad.Name = "CmbTipoIncapacidad"
        Me.CmbTipoIncapacidad.Size = New System.Drawing.Size(209, 21)
        Me.CmbTipoIncapacidad.TabIndex = 124
        '
        'BtnDelIncapacidad
        '
        Me.BtnDelIncapacidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelIncapacidad.Icon = CType(resources.GetObject("BtnDelIncapacidad.Icon"), System.Drawing.Icon)
        Me.BtnDelIncapacidad.Location = New System.Drawing.Point(480, 14)
        Me.BtnDelIncapacidad.Name = "BtnDelIncapacidad"
        Me.BtnDelIncapacidad.Size = New System.Drawing.Size(42, 24)
        Me.BtnDelIncapacidad.TabIndex = 99
        Me.BtnDelIncapacidad.ToolTipText = "Eliminar detalle de Incapacidad seleccionada"
        Me.BtnDelIncapacidad.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAddIncapacidad
        '
        Me.BtnAddIncapacidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddIncapacidad.Icon = CType(resources.GetObject("BtnAddIncapacidad.Icon"), System.Drawing.Icon)
        Me.BtnAddIncapacidad.Location = New System.Drawing.Point(532, 14)
        Me.BtnAddIncapacidad.Name = "BtnAddIncapacidad"
        Me.BtnAddIncapacidad.Size = New System.Drawing.Size(46, 24)
        Me.BtnAddIncapacidad.TabIndex = 98
        Me.BtnAddIncapacidad.ToolTipText = "Agregar detalle de Incapacidad"
        Me.BtnAddIncapacidad.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridIncapacidad
        '
        Me.GridIncapacidad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridIncapacidad.ColumnAutoResize = True
        Me.GridIncapacidad.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridIncapacidad.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridIncapacidad.GroupByBoxVisible = False
        Me.GridIncapacidad.Location = New System.Drawing.Point(5, 44)
        Me.GridIncapacidad.Name = "GridIncapacidad"
        Me.GridIncapacidad.RecordNavigator = True
        Me.GridIncapacidad.Size = New System.Drawing.Size(575, 70)
        Me.GridIncapacidad.TabIndex = 5
        Me.GridIncapacidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'grpHorasExtra
        '
        Me.grpHorasExtra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpHorasExtra.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpHorasExtra.Controls.Add(Me.PictureBox4)
        Me.grpHorasExtra.Controls.Add(Me.Label1)
        Me.grpHorasExtra.Controls.Add(Me.cmbTipoHorasExtra)
        Me.grpHorasExtra.Controls.Add(Me.btnDelHoraExtra)
        Me.grpHorasExtra.Controls.Add(Me.btnAddHoraExtra)
        Me.grpHorasExtra.Controls.Add(Me.GridHoraExtra)
        Me.grpHorasExtra.Location = New System.Drawing.Point(7, 154)
        Me.grpHorasExtra.Name = "grpHorasExtra"
        Me.grpHorasExtra.Size = New System.Drawing.Size(585, 120)
        Me.grpHorasExtra.TabIndex = 6
        Me.grpHorasExtra.TabStop = False
        Me.grpHorasExtra.Text = "Detalle de Horas Extras"
        Me.grpHorasExtra.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(79, 19)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(15, 14)
        Me.PictureBox4.TabIndex = 126
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 17)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Tipo Hora Extra"
        '
        'cmbTipoHorasExtra
        '
        Me.cmbTipoHorasExtra.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoHorasExtra.ItemHeight = 13
        Me.cmbTipoHorasExtra.Location = New System.Drawing.Point(98, 16)
        Me.cmbTipoHorasExtra.Name = "cmbTipoHorasExtra"
        Me.cmbTipoHorasExtra.Size = New System.Drawing.Size(129, 21)
        Me.cmbTipoHorasExtra.TabIndex = 124
        '
        'btnDelHoraExtra
        '
        Me.btnDelHoraExtra.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelHoraExtra.Icon = CType(resources.GetObject("btnDelHoraExtra.Icon"), System.Drawing.Icon)
        Me.btnDelHoraExtra.Location = New System.Drawing.Point(480, 14)
        Me.btnDelHoraExtra.Name = "btnDelHoraExtra"
        Me.btnDelHoraExtra.Size = New System.Drawing.Size(42, 24)
        Me.btnDelHoraExtra.TabIndex = 99
        Me.btnDelHoraExtra.ToolTipText = "Eliminar detalle de Hora Extra seleccionada"
        Me.btnDelHoraExtra.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAddHoraExtra
        '
        Me.btnAddHoraExtra.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddHoraExtra.Icon = CType(resources.GetObject("btnAddHoraExtra.Icon"), System.Drawing.Icon)
        Me.btnAddHoraExtra.Location = New System.Drawing.Point(531, 14)
        Me.btnAddHoraExtra.Name = "btnAddHoraExtra"
        Me.btnAddHoraExtra.Size = New System.Drawing.Size(46, 24)
        Me.btnAddHoraExtra.TabIndex = 98
        Me.btnAddHoraExtra.ToolTipText = "Agregar Detalle de Hora Extra"
        Me.btnAddHoraExtra.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridHoraExtra
        '
        Me.GridHoraExtra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridHoraExtra.ColumnAutoResize = True
        Me.GridHoraExtra.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridHoraExtra.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridHoraExtra.GroupByBoxVisible = False
        Me.GridHoraExtra.Location = New System.Drawing.Point(5, 44)
        Me.GridHoraExtra.Name = "GridHoraExtra"
        Me.GridHoraExtra.RecordNavigator = True
        Me.GridHoraExtra.Size = New System.Drawing.Size(575, 70)
        Me.GridHoraExtra.TabIndex = 5
        Me.GridHoraExtra.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'grpAcciones
        '
        Me.grpAcciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAcciones.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpAcciones.Controls.Add(Me.BtnDelAccion)
        Me.grpAcciones.Controls.Add(Me.BtnAddAccion)
        Me.grpAcciones.Controls.Add(Me.GridAcciones)
        Me.grpAcciones.Location = New System.Drawing.Point(7, 154)
        Me.grpAcciones.Name = "grpAcciones"
        Me.grpAcciones.Size = New System.Drawing.Size(585, 120)
        Me.grpAcciones.TabIndex = 127
        Me.grpAcciones.TabStop = False
        Me.grpAcciones.Text = "Detalle de Acciones o Titulos"
        Me.grpAcciones.Visible = False
        '
        'BtnDelAccion
        '
        Me.BtnDelAccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelAccion.Icon = CType(resources.GetObject("BtnDelAccion.Icon"), System.Drawing.Icon)
        Me.BtnDelAccion.Location = New System.Drawing.Point(480, 14)
        Me.BtnDelAccion.Name = "BtnDelAccion"
        Me.BtnDelAccion.Size = New System.Drawing.Size(42, 24)
        Me.BtnDelAccion.TabIndex = 99
        Me.BtnDelAccion.ToolTipText = "Eliminar detalle de Incapacidad seleccionada"
        Me.BtnDelAccion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAddAccion
        '
        Me.BtnAddAccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddAccion.Icon = CType(resources.GetObject("BtnAddAccion.Icon"), System.Drawing.Icon)
        Me.BtnAddAccion.Location = New System.Drawing.Point(532, 14)
        Me.BtnAddAccion.Name = "BtnAddAccion"
        Me.BtnAddAccion.Size = New System.Drawing.Size(46, 24)
        Me.BtnAddAccion.TabIndex = 98
        Me.BtnAddAccion.ToolTipText = "Agregar detalle de Incapacidad"
        Me.BtnAddAccion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridAcciones
        '
        Me.GridAcciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridAcciones.ColumnAutoResize = True
        Me.GridAcciones.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridAcciones.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridAcciones.GroupByBoxVisible = False
        Me.GridAcciones.Location = New System.Drawing.Point(5, 44)
        Me.GridAcciones.Name = "GridAcciones"
        Me.GridAcciones.RecordNavigator = True
        Me.GridAcciones.Size = New System.Drawing.Size(575, 70)
        Me.GridAcciones.TabIndex = 5
        Me.GridAcciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmAddConcepto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(599, 202)
        Me.Controls.Add(Me.GrpConcepto)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.grpJubilacion)
        Me.Controls.Add(Me.grpSeparacion)
        Me.Controls.Add(Me.grpCompensacion)
        Me.Controls.Add(Me.grpAcciones)
        Me.Controls.Add(Me.grpIncapacidad)
        Me.Controls.Add(Me.grpHorasExtra)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(615, 241)
        Me.Name = "FrmAddConcepto"
        Me.Text = "Agregar Concepto de Nómina"
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
        Me.GrpConcepto.ResumeLayout(False)
        Me.GrpConcepto.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCompensacion.ResumeLayout(False)
        CType(Me.GridCompensacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSeparacion.ResumeLayout(False)
        CType(Me.GridSeparacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpJubilacion.ResumeLayout(False)
        CType(Me.GridJubilacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpIncapacidad.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridIncapacidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpHorasExtra.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridHoraExtra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAcciones.ResumeLayout(False)
        CType(Me.GridAcciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Privadas"

    Private Cnx As String
    Private alerta(2) As PictureBox
    Private reloj As parpadea

    Private cargado As Boolean = False

    Private guardado As Boolean = False

    Private CONClave As String = ""
    Private Clave As String = ""
    Private Concepto As String = ""
    Private Tipo As Integer
    Private TipoConcepto As Integer
    Private ImporteGravado As Double = 0
    Private ImporteExento As Double = 0
    Private Descuento As Double = 0
    Private HorasExtra As Integer = 0
    Private DiasIncapacidad As Integer = 0

    Private dtIncapacidad, dtHorasExtra, dtAcciones, dtJubilacion, dtSeparacion, dtCompensacion As DataTable

#End Region

#Region "Concepto"

    Private Sub reinicializa()


        CONClave = ""
        Clave = ""
        Concepto = ""
        ImporteGravado = 0
        ImporteExento = 0
        Descuento = 0
        HorasExtra = 0
        DiasIncapacidad = 0

        TxtClave.Text = Clave
        TxtDescripcion.Text = Concepto
        TxtImporteGravado.Text = ImporteGravado
        txtImporteExento.Text = ImporteExento

        TxtClave.Focus()

        Me.Size = New System.Drawing.Size(615, 241)
        grpIncapacidad.Visible = False
        grpHorasExtra.Visible = False
        grpAcciones.Visible = False
        grpJubilacion.Visible = False
        grpSeparacion.Visible = False
        grpCompensacion.Visible = False
        dtIncapacidad.Rows.Clear()
        dtHorasExtra.Rows.Clear()
        dtAcciones.Rows.Clear()
        dtJubilacion.Rows.Clear()
        dtSeparacion.Rows.Clear()
        dtCompensacion.Rows.Clear()



    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length < 3 OrElse Me.TxtClave.Text.Length > 15 Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.TxtDescripcion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtDescripcion.Text.Length > 30 Then
            Me.TxtDescripcion.Text = Me.TxtDescripcion.Text.Substring(0, 30)
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

    Private Sub FrmAddConcepto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.BringToFront()

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3

        Cnx = ModPOS.BDConexion


        TxtClave.Text = Clave
        TxtDescripcion.Text = Concepto


        With Me.CmbTipoIncapacidad
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Nomina"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoIncapacidad"
            .llenar()
        End With



        With Me.cmbTipoHorasExtra
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Nomina"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoHorasExtra"
            .llenar()
        End With

        dtIncapacidad = ModPOS.CrearTabla("IncapacidadDetalle", _
                                               "Tipo", "System.String", _
                                               "Dias", "System.Double", _
                                               "TipoIncapacidad", "System.Int32", _
                                               "Descuento", "System.Double")


        GridIncapacidad.DataSource = dtIncapacidad
        GridIncapacidad.RetrieveStructure(True)
        GridIncapacidad.GroupByBoxVisible = False
        GridIncapacidad.RootTable.Columns("TipoIncapacidad").Visible = False
        GridIncapacidad.CurrentTable.Columns("Tipo").Selectable = False

        dtHorasExtra = ModPOS.CrearTabla("HorasExtraDetalle", _
                                              "Tipo", "System.String", _
                                              "Dias", "System.Int32", _
                                              "HorasExtra", "System.Int32", _
                                              "ImportePagado", "System.Double")

        GridHoraExtra.DataSource = dtHorasExtra
        GridHoraExtra.RetrieveStructure(True)
        GridHoraExtra.GroupByBoxVisible = False
        GridHoraExtra.CurrentTable.Columns("Tipo").Selectable = False


        dtAcciones = ModPOS.CrearTabla("Acciones", _
                                            "ValorMercado", "System.Double", _
                                            "PrecioAlOtorgante", "System.Double")
        GridAcciones.DataSource = dtAcciones
        GridAcciones.RetrieveStructure(True)
        GridAcciones.GroupByBoxVisible = False


        dtJubilacion = ModPOS.CrearTabla("Jubilacion", _
                                             "Tipo", "System.String", _
                                             "Importe", "System.Double", _
                                             "MontoDiario", "System.Double", _
                                             "IngresoAcumulable", "System.Double", _
                                             "IngresoNoAcumulable", "System.Double")

        GridJubilacion.DataSource = dtJubilacion
        GridJubilacion.RetrieveStructure(True)
        GridJubilacion.GroupByBoxVisible = False
        GridJubilacion.CurrentTable.Columns("Tipo").Selectable = False




        dtSeparacion = ModPOS.CrearTabla("Separacion", _
                                             "TotalPagado", "System.Double", _
                                             "AñosServicio", "System.Int32", _
                                             "UltimoSueldo", "System.Double", _
                                             "IngresoAcumulable", "System.Double", _
                                             "IngresoNoAcumulable", "System.Double")

        GridSeparacion.DataSource = dtSeparacion
        GridSeparacion.RetrieveStructure(True)
        GridSeparacion.GroupByBoxVisible = False
   

        dtCompensacion = ModPOS.CrearTabla("Compensacion", _
                                        "SaldoFavor", "System.Double", _
                                        "Año", "System.Int32", _
                                        "Remanente", "System.Double")

        GridCompensacion.DataSource = dtCompensacion
        GridCompensacion.RetrieveStructure(True)
        GridCompensacion.GroupByBoxVisible = False


        cargado = True




    End Sub

    Private Sub FrmAddConcepto_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.AddConcepto.Dispose()
        ModPOS.AddConcepto = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            ImporteGravado = TxtImporteGravado.Text
            ImporteExento = txtImporteExento.Text


            If ImporteGravado + ImporteExento <= 0 Then
                Beep()
                MessageBox.Show("¡La suma de los importes del concepto actual deben ser mayor a Cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If


            If Tipo = 2 Then
                If TipoConcepto = 6 Then
                    If GridIncapacidad.RowCount = 0 Then
                        Beep()
                        MessageBox.Show("Debe especificar por lo menos un detalle de la incapacidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    ElseIf GridIncapacidad.GetTotal(GridIncapacidad.CurrentTable.Columns(3), Janus.Windows.GridEX.AggregateFunction.Sum) <> (ImporteGravado + ImporteExento) Then
                        Beep()
                        MessageBox.Show("La suma de los descuentos del detalle de las incapacidades debe ser igual a la suma de importes del concepto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                End If
            ElseIf Tipo = 3 Then
                If TipoConcepto = 4 AndAlso GridCompensacion.RowCount <> 1 Then
                    Beep()
                    MessageBox.Show("Debe especificar detalle de la compensación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            ElseIf Tipo = 1 Then
                If TipoConcepto = 19 Then
                    If GridHoraExtra.RowCount = 0 Then
                        Beep()
                        MessageBox.Show("Debe especificar por lo menos un detalle de Hora Extras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    ElseIf GridHoraExtra.GetTotal(GridHoraExtra.CurrentTable.Columns(3), Janus.Windows.GridEX.AggregateFunction.Sum) <> (ImporteGravado + ImporteExento) Then
                        Beep()
                        MessageBox.Show("La suma de los importes pagados del detalle de horas extras debe ser igual a la suma de importes del concepto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                ElseIf TipoConcepto = 45 Then
                    If GridAcciones.RowCount <> 1 Then
                        Beep()
                        MessageBox.Show("Debe detallar los valores del titulo o acción ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                ElseIf TipoConcepto = 39 OrElse TipoConcepto = 44 Then
                    If GridJubilacion.RowCount <> 1 Then
                        Beep()
                        MessageBox.Show("Debe especificar el detalle de la jubilación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If

                ElseIf TipoConcepto = 22 OrElse TipoConcepto = 23 OrElse TipoConcepto = 25 Then
                    If GridSeparacion.RowCount <> 1 Then
                        Beep()
                        MessageBox.Show("Debe especificar el detalle de la separación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If

                End If
            End If

                If Not ModPOS.ReciboNomina Is Nothing Then

                    Dim REDClave As String = ModPOS.obtenerLlave

                    If ModPOS.ReciboNomina.AddConceptoNomina(CONClave, Tipo, TipoConcepto, Clave, Concepto, ImporteGravado, ImporteExento, REDClave) = False Then
                        Exit Sub
                    End If

                    Dim i As Integer

                If dtAcciones.Rows.Count > 0 Then
                    ModPOS.ReciboNomina.AddAcciones( _
                        dtAcciones.Rows(0)("ValorMercado"), _
                        dtAcciones.Rows(0)("PrecioAlOtorgante"), _
                        CONClave, REDClave)
                End If


                If dtJubilacion.Rows.Count > 0 Then
                    ModPOS.ReciboNomina.AddJubilacion( _
                        dtJubilacion.Rows(0)("Tipo"), _
                        dtJubilacion.Rows(0)("Importe"), _
                        dtJubilacion.Rows(0)("MontoDiario"), _
                        dtJubilacion.Rows(0)("IngresoAcumulable"), _
                        dtJubilacion.Rows(0)("IngresoNoAcumulable"), _
                        CONClave, REDClave)
                End If

                If dtSeparacion.Rows.Count > 0 Then
                    ModPOS.ReciboNomina.AddSeparacion( _
                        dtSeparacion.Rows(0)("TotalPagado"), _
                        dtSeparacion.Rows(0)("AñosServicio"), _
                        dtSeparacion.Rows(0)("UltimoSueldo"), _
                        dtSeparacion.Rows(0)("IngresoAcumulable"), _
                        dtSeparacion.Rows(0)("IngresoNoAcumulable"), _
                        CONClave, REDClave)
                End If

                If dtCompensacion.Rows.Count > 0 Then
                    ModPOS.ReciboNomina.AddCompensaciones( _
                        dtCompensacion.Rows(0)("SaldoFavor"), _
                        dtCompensacion.Rows(0)("Año"), _
                        dtCompensacion.Rows(0)("Remanente"), _
                        CONClave, REDClave)
                End If


                    If dtIncapacidad.Rows.Count > 0 Then
                        For i = 0 To dtIncapacidad.Rows.Count - 1
                            ModPOS.ReciboNomina.AddIncapacidad( _
                             dtIncapacidad.Rows(i)("Tipo"), _
                             dtIncapacidad.Rows(i)("Dias"), _
                             dtIncapacidad.Rows(i)("TipoIncapacidad"), _
                             dtIncapacidad.Rows(i)("Descuento"), _
                             CONClave, REDClave)
                        Next
                    End If


                    If dtHorasExtra.Rows.Count > 0 Then
                        For i = 0 To dtHorasExtra.Rows.Count - 1
                            ModPOS.ReciboNomina.AddHorasExtras( _
                             dtHorasExtra.Rows(i)("Tipo"), _
                             dtHorasExtra.Rows(i)("Dias"), _
                             dtHorasExtra.Rows(i)("HorasExtra"), _
                             dtHorasExtra.Rows(i)("ImportePagado"), _
                             CONClave, REDClave)
                        Next
                    End If

                End If



                reinicializa()


            Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

    End Sub

    Private Sub Ctrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CargaDatosConcepto(ByVal sClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_consulta_concepto", "@Clave", sClave, "@COMClave", ModPOS.CompanyActual)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

            CONClave = dt.Rows(0)("CONClave")
            Tipo = dt.Rows(0)("Tipo")
            TipoConcepto = dt.Rows(0)("TipoConcepto")
            Clave = dt.Rows(0)("Clave")
            Concepto = dt.Rows(0)("Concepto")

            dt.Dispose()

            TxtClave.Text = Clave
            TxtDescripcion.Text = Concepto

            dtIncapacidad.Rows.Clear()
            dtHorasExtra.Rows.Clear()

            If Tipo = 2 Then

                lblImporteExcento.Visible = False
                lblImporteGravado.Text = "Importe"
                txtImporteExento.Visible = False

                If TipoConcepto = 6 Then
                    Me.Size = New System.Drawing.Size(617, 375)
                    grpIncapacidad.Visible = True
                    grpHorasExtra.Visible = False
                    grpAcciones.Visible = False
                    grpJubilacion.Visible = False
                    grpSeparacion.Visible = False
                    grpCompensacion.Visible = False
                Else
                    grpIncapacidad.Visible = False
                    grpHorasExtra.Visible = False
                    grpAcciones.Visible = False
                    grpJubilacion.Visible = False
                    grpSeparacion.Visible = False
                    grpCompensacion.Visible = False
                End If



            ElseIf Tipo = 1 Then

                lblImporteExcento.Visible = True
                txtImporteExento.Visible = True
                lblImporteExcento.Text = "Importe Excento"

                lblImporteGravado.Text = "Importe Gravado"


                If TipoConcepto = 19 Then
                    Me.Size = New System.Drawing.Size(617, 375)
                    grpIncapacidad.Visible = False
                    grpHorasExtra.Visible = True
                    grpAcciones.Visible = False
                    grpJubilacion.Visible = False
                    grpSeparacion.Visible = False
                    grpCompensacion.Visible = False

                ElseIf TipoConcepto = 45 Then

                    Me.Size = New System.Drawing.Size(617, 375)
                    grpIncapacidad.Visible = False
                    grpHorasExtra.Visible = False
                    grpAcciones.Visible = True
                    grpJubilacion.Visible = False
                    grpSeparacion.Visible = False
                    grpCompensacion.Visible = False
                ElseIf TipoConcepto = 39 OrElse TipoConcepto = 44 Then
                    Me.Size = New System.Drawing.Size(617, 375)
                    grpIncapacidad.Visible = False
                    grpHorasExtra.Visible = False
                    grpAcciones.Visible = False
                    grpJubilacion.Visible = True
                    grpSeparacion.Visible = False
                    grpCompensacion.Visible = False

                    If TipoConcepto = 39 Then
                        GridJubilacion.RootTable.Columns("MontoDiario").Visible = False
                    End If


                ElseIf TipoConcepto = 22 OrElse TipoConcepto = 23 OrElse TipoConcepto = 25 Then
                    Me.Size = New System.Drawing.Size(617, 375)
                    grpIncapacidad.Visible = False
                    grpHorasExtra.Visible = False
                    grpAcciones.Visible = False
                    grpJubilacion.Visible = False
                    grpSeparacion.Visible = True
                    grpCompensacion.Visible = False

                Else
                    grpIncapacidad.Visible = False
                    grpHorasExtra.Visible = False
                    grpAcciones.Visible = False
                    grpJubilacion.Visible = False
                    grpSeparacion.Visible = False
                    grpCompensacion.Visible = False

                End If
            ElseIf Tipo = 3 Then

                lblImporteExcento.Visible = False
                lblImporteGravado.Text = "Importe"
                txtImporteExento.Visible = False

                If TipoConcepto = 4 Then
                    Me.Size = New System.Drawing.Size(617, 375)
                    grpIncapacidad.Visible = False
                    grpHorasExtra.Visible = False
                    grpAcciones.Visible = False
                    grpJubilacion.Visible = False
                    grpSeparacion.Visible = False
                    grpCompensacion.Visible = True

                Else
                    Me.Size = New System.Drawing.Size(617, 241)
                    grpIncapacidad.Visible = False
                    grpHorasExtra.Visible = False
                    grpAcciones.Visible = False
                    grpJubilacion.Visible = False
                    grpSeparacion.Visible = False
                    grpCompensacion.Visible = False

                End If
            End If
        Else
            Beep()
            MessageBox.Show("La Clave de Concepto no exite o se encuentra inactiva", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            TxtClave.Text = ""
            TxtDescripcion.Text = ""
        End If

    End Sub

    Private Sub TxtClave_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClave.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If TxtClave.Text <> "" Then
                    CargaDatosConcepto(TxtClave.Text.Trim.Replace("'", "''"))
                End If
            Case Is = Keys.Right

                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_concepto"
                a.TablaCmb = "ConceptoNomina"
                a.CampoCmb = "Filtro"
                a.OcultaID = True
                a.NumColDes = 1
                a.BusquedaInicial = True
                a.CompaniaRequerido = True
                a.Busqueda = TxtClave.Text.Trim.ToUpper
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If Not a.Descripcion Is Nothing Then
                        CargaDatosConcepto(a.Descripcion)
                    End If
                End If
                a.Dispose()
        End Select

    End Sub

    Private Sub BtnBuscaConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaConcepto.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_concepto"
        a.TablaCmb = "ConceptoNomina"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.NumColDes = 1
        a.BusquedaInicial = True
        a.CompaniaRequerido = True
        a.Busqueda = TxtClave.Text.Trim.ToUpper
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.Descripcion Is Nothing Then
                CargaDatosConcepto(a.Descripcion)
            End If
        End If
        a.Dispose()
    End Sub


#End Region




    Private Sub BtnAddIncapacidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddIncapacidad.Click

        If CmbTipoIncapacidad.SelectedValue Is Nothing Then
            Beep()
            MessageBox.Show("Debe seleccionar un tipo de incapacidad valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Dim foundRows() As Data.DataRow
        foundRows = dtIncapacidad.Select("TipoIncapacidad = " & CStr(CmbTipoIncapacidad.SelectedValue))

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtIncapacidad.NewRow()
            'declara el nombre de la fila

            row1.Item("Tipo") = CmbTipoIncapacidad.Text.Trim
            row1.Item("Dias") = 1
            row1.Item("TipoIncapacidad") = CmbTipoIncapacidad.SelectedValue
            row1.Item("Descuento") = 0


            dtIncapacidad.Rows.Add(row1)
            'agrega la fila completo a la tabla

        Else
            Beep()
            MessageBox.Show("¡El Tipo de Incapacidad que intenta agregar ya existe para el concepto actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub btnAddHoraExtra_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddHoraExtra.Click
        If cmbTipoHorasExtra.SelectedValue Is Nothing Then
            Beep()
            MessageBox.Show("Debe seleccionar un tipo de horas extra valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Dim foundRows() As Data.DataRow
        foundRows = dtHorasExtra.Select("Tipo like '" & cmbTipoHorasExtra.Text.Trim & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtHorasExtra.NewRow()
            'declara el nombre de la fila

            row1.Item("Tipo") = cmbTipoHorasExtra.Text.Trim
            row1.Item("Dias") = 1
            row1.Item("HorasExtra") = 1
            row1.Item("ImportePagado") = 0


            dtHorasExtra.Rows.Add(row1)
            'agrega la fila completo a la tabla

        Else
            Beep()
            MessageBox.Show("¡El Tipo de Hora Extra que intenta agregar ya existe para el concepto actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnDelIncapacidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelIncapacidad.Click
        If GridIncapacidad.Row >= 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara del detalle de incapacidad :" & GridIncapacidad.GetValue("Tipo"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtIncapacidad.Select("Tipo = '" & GridIncapacidad.GetValue("Tipo") & "'")

                    dtIncapacidad.Rows.Remove(foundRows(0))

            End Select
        End If
    End Sub

    Private Sub btnDelHoraExtra_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelHoraExtra.Click
        If GridHoraExtra.Row >= 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara del detalle de hora extra :" & GridHoraExtra.GetValue("Tipo"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtIncapacidad.Select("Tipo = '" & GridHoraExtra.GetValue("Tipo") & "'")

                    dtHorasExtra.Rows.Remove(foundRows(0))

            End Select
        End If
    End Sub

    Private Sub GridHoraExtra_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridHoraExtra.CellEdited

        'Importe Dias
        If GridHoraExtra.GetValue("Dias") Is System.DBNull.Value OrElse IsNumeric(GridHoraExtra.GetValue("Dias")) = False OrElse GridHoraExtra.GetValue("Dias") <= 0 Then
            GridHoraExtra.SetValue("Dias", 1)
        End If


        'importe Horas Extra
        If GridHoraExtra.GetValue("HorasExtra") Is System.DBNull.Value OrElse IsNumeric(GridHoraExtra.GetValue("HorasExtra")) = False OrElse GridHoraExtra.GetValue("HorasExtra") <= 0 Then
            GridHoraExtra.SetValue("HorasExtra", 1)
        End If


        'importe Importe Pagado
        If GridHoraExtra.GetValue("ImportePagado") Is System.DBNull.Value OrElse IsNumeric(GridHoraExtra.GetValue("ImportePagado")) = False OrElse GridHoraExtra.GetValue("ImportePagado") <= 0 Then
            GridHoraExtra.SetValue("ImportePagado", 1)
        End If

    End Sub

    Private Sub GridIncapacidad_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridIncapacidad.CellEdited
        'Importe Dias
        If GridIncapacidad.GetValue("Dias") Is System.DBNull.Value OrElse IsNumeric(GridIncapacidad.GetValue("Dias")) = False OrElse GridIncapacidad.GetValue("Dias") <= 0 Then
            GridIncapacidad.SetValue("Dias", 1)
        End If

        'Descuento
        If GridIncapacidad.GetValue("Descuento") Is System.DBNull.Value OrElse IsNumeric(GridIncapacidad.GetValue("Descuento")) = False OrElse GridIncapacidad.GetValue("Descuento") <= 0 Then
            GridIncapacidad.SetValue("Descuento", 1)
        End If

    End Sub

    Private Sub BtnAddAccion_Click(sender As Object, e As EventArgs) Handles BtnAddAccion.Click
        If GridAcciones.RecordCount = 0 Then
            Dim row1 As DataRow
            row1 = dtAcciones.NewRow()
            'declara el nombre de la fila
            row1.Item("ValorMercado") = 1
            row1.Item("PrecioAlOtorgante") = 1
            dtAcciones.Rows.Add(row1)
        Else
            Beep()
            MessageBox.Show("ya existe registro de Accion o Titulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnDelAccion_Click(sender As Object, e As EventArgs) Handles BtnDelAccion.Click
        If GridAcciones.RecordCount > 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara del detalle de Accion o Titulo ", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtAcciones.Select("")

                    dtAcciones.Rows.Remove(foundRows(0))

            End Select
        End If
    End Sub

    Private Sub btnAddJubilacion_Click(sender As Object, e As EventArgs) Handles btnAddJubilacion.Click

       

        If GridJubilacion.RecordCount = 0 Then
            Dim row1 As DataRow
            row1 = dtJubilacion.NewRow()
            'declara el nombre de la fila
            If TipoConcepto = 39 Then
                row1.Item("Tipo") = "TotalUnaExhibicion"
            ElseIf TipoConcepto = 44 Then
                row1.Item("Tipo") = "TotalParcialidad"
            End If

            row1.Item("Importe") = 1
            row1.Item("MontoDiario") = 0
            row1.Item("IngresoAcumulable") = 1
            row1.Item("IngresoNoAcumulable") = 1
            dtJubilacion.Rows.Add(row1)
        Else
            Beep()
            MessageBox.Show("ya existe registro de detalle de jubilación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnDelJubilacion_Click(sender As Object, e As EventArgs) Handles btnDelJubilacion.Click
        If GridJubilacion.RecordCount > 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara del detalle de jubilación ", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtJubilacion.Select("")

                    dtJubilacion.Rows.Remove(foundRows(0))

            End Select
        End If
    End Sub

    Private Sub btnAddSeparacion_Click(sender As Object, e As EventArgs) Handles btnAddSeparacion.Click
        If GridSeparacion.RecordCount = 0 Then
            Dim row1 As DataRow
            row1 = dtSeparacion.NewRow()
            'declara el nombre de la fila

            row1.Item("TotalPagado") = 1
            row1.Item("AñosServicio") = 0
            row1.Item("UltimoSueldo") = 1
            row1.Item("IngresoAcumulable") = 1
            row1.Item("IngresoNoAcumulable") = 1
            dtSeparacion.Rows.Add(row1)
        Else
            Beep()
            MessageBox.Show("ya existe registro de Separación o indemnización", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnDelSerparacion_Click(sender As Object, e As EventArgs) Handles btnDelSerparacion.Click
        If GridSeparacion.RecordCount > 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara del detalle de Separación o indemnización", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtSeparacion.Select("")

                    dtSeparacion.Rows.Remove(foundRows(0))

            End Select
        End If
    End Sub

    Private Sub btnAddCompensacion_Click(sender As Object, e As EventArgs) Handles btnAddCompensacion.Click
        If GridCompensacion.RecordCount = 0 Then
            Dim row1 As DataRow
            row1 = dtCompensacion.NewRow()
            'declara el nombre de la fila
            row1.Item("SaldoFavor") = 1
            row1.Item("Año") = Today.Year
            row1.Item("Remanente") = 1
            dtCompensacion.Rows.Add(row1)
        Else
            Beep()
            MessageBox.Show("ya existe registro de Accion o Titulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub btnDelCompensacion_Click(sender As Object, e As EventArgs) Handles btnDelCompensacion.Click
        If GridCompensacion.RecordCount > 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara del detalle de Compensación ", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtCompensacion.Select("")

                    dtCompensacion.Rows.Remove(foundRows(0))

            End Select
        End If
    End Sub

    Private Sub GridAcciones_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridAcciones.CellEdited
        'Valor Mercado
        If GridAcciones.GetValue("ValorMercado") Is System.DBNull.Value OrElse IsNumeric(GridAcciones.GetValue("ValorMercado")) = False OrElse GridAcciones.GetValue("ValorMercado") <= 0 Then
            GridAcciones.SetValue("ValorMercado", 1)
        End If

        'PrecioAlOtorgante
        If GridAcciones.GetValue("PrecioAlOtorgante") Is System.DBNull.Value OrElse IsNumeric(GridAcciones.GetValue("PrecioAlOtorgante")) = False OrElse GridAcciones.GetValue("PrecioAlOtorgante") <= 0 Then
            GridAcciones.SetValue("PrecioAlOtorgante", 1)
        End If

    End Sub


    Private Sub GridJubilacion_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridJubilacion.CellEdited
        'Valor Mercado
        If GridJubilacion.GetValue("Importe") Is System.DBNull.Value OrElse IsNumeric(GridJubilacion.GetValue("Importe")) = False OrElse GridJubilacion.GetValue("Importe") <= 0 Then
            GridJubilacion.SetValue("Importe", 1)
        End If

        'PrecioAlOtorgante
        If GridJubilacion.GetValue("MontoDiario") Is System.DBNull.Value OrElse IsNumeric(GridJubilacion.GetValue("MontoDiario")) = False OrElse (GridJubilacion.GetValue("MontoDiario") <= 0 AndAlso TipoConcepto = 44) Then
            GridJubilacion.SetValue("MontoDiario", 1)
        End If

        'Valor Mercado
        If GridJubilacion.GetValue("IngresoAcumulable") Is System.DBNull.Value OrElse IsNumeric(GridJubilacion.GetValue("IngresoAcumulable")) = False OrElse GridJubilacion.GetValue("IngresoAcumulable") <= 0 Then
            GridJubilacion.SetValue("IngresoAcumulable", 1)
        End If

        'PrecioAlOtorgante
        If GridJubilacion.GetValue("IngresoNoAcumulable") Is System.DBNull.Value OrElse IsNumeric(GridJubilacion.GetValue("IngresoNoAcumulable")) = False OrElse GridJubilacion.GetValue("IngresoNoAcumulable") <= 0 Then
            GridJubilacion.SetValue("IngresoNoAcumulable", 1)
        End If

    End Sub

    Private Sub GridSeparacion_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridSeparacion.CellEdited

        If GridSeparacion.GetValue("AñosServicio") Is System.DBNull.Value OrElse IsNumeric(GridSeparacion.GetValue("AñosServicio")) = False OrElse GridSeparacion.GetValue("AñosServicio") < 0 Then
            GridSeparacion.SetValue("AñosServicio", 0)
        End If

        'Valor Mercado
        If GridSeparacion.GetValue("TotalPagado") Is System.DBNull.Value OrElse IsNumeric(GridSeparacion.GetValue("TotalPagado")) = False OrElse GridSeparacion.GetValue("TotalPagado") <= 0 Then
            GridSeparacion.SetValue("TotalPagado", 1)
        End If

        'PrecioAlOtorgante
        If GridSeparacion.GetValue("UltimoSueldo") Is System.DBNull.Value OrElse IsNumeric(GridSeparacion.GetValue("UltimoSueldo")) = False OrElse GridSeparacion.GetValue("UltimoSueldo") <= 0 Then
            GridSeparacion.SetValue("UltimoSueldo", 1)
        End If


        'Valor Mercado
        If GridSeparacion.GetValue("IngresoAcumulable") Is System.DBNull.Value OrElse IsNumeric(GridSeparacion.GetValue("IngresoAcumulable")) = False OrElse GridSeparacion.GetValue("IngresoAcumulable") <= 0 Then
            GridSeparacion.SetValue("IngresoAcumulable", 1)
        End If

        'PrecioAlOtorgante
        If GridSeparacion.GetValue("IngresoNoAcumulable") Is System.DBNull.Value OrElse IsNumeric(GridSeparacion.GetValue("IngresoNoAcumulable")) = False OrElse GridSeparacion.GetValue("IngresoNoAcumulable") <= 0 Then
            GridSeparacion.SetValue("IngresoNoAcumulable", 1)
        End If

    End Sub

    Private Sub GridCompensacion_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridCompensacion.CellEdited
        'SaldoFavor
        If GridCompensacion.GetValue("SaldoFavor") Is System.DBNull.Value OrElse IsNumeric(GridCompensacion.GetValue("SaldoFavor")) = False OrElse GridCompensacion.GetValue("SaldoFavor") <= 0 Then
            GridCompensacion.SetValue("SaldoFavor", 1)
        End If

        'Año
        If GridCompensacion.GetValue("Año") Is System.DBNull.Value OrElse IsNumeric(GridCompensacion.GetValue("Año")) = False OrElse GridCompensacion.GetValue("Año") <= 1990 Then
            GridCompensacion.SetValue("Año", Today.Year)
        End If

        'Remanente
        If GridCompensacion.GetValue("Remanente") Is System.DBNull.Value OrElse IsNumeric(GridCompensacion.GetValue("Remanente")) = False OrElse GridCompensacion.GetValue("Remanente") <= 0 Then
            GridCompensacion.SetValue("Remanente", 1)
        End If
    End Sub
End Class
