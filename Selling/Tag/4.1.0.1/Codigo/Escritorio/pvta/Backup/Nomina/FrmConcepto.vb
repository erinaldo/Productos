Public Class FrmConcepto
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
    Friend WithEvents cmbTipoConcepto As Selling.StoreCombo
    Friend WithEvents lblConcepto As System.Windows.Forms.Label
    Friend WithEvents CmbTipo As Selling.StoreCombo
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnModifica As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConcepto))
        Me.GrpDomicilio = New System.Windows.Forms.GroupBox
        Me.PictureBox24 = New System.Windows.Forms.PictureBox
        Me.PictureBox23 = New System.Windows.Forms.PictureBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxtReferencia = New System.Windows.Forms.TextBox
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
        Me.Lbl = New System.Windows.Forms.Label
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
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpConcepto = New System.Windows.Forms.GroupBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.cmbTipoConcepto = New Selling.StoreCombo
        Me.lblConcepto = New System.Windows.Forms.Label
        Me.CmbTipo = New Selling.StoreCombo
        Me.lblTipo = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.lblDescripcion = New System.Windows.Forms.Label
        Me.LblClave = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
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
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(290, 159)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(386, 159)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpConcepto
        '
        Me.GrpConcepto.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpConcepto.Controls.Add(Me.PictureBox4)
        Me.GrpConcepto.Controls.Add(Me.BtnCancelar)
        Me.GrpConcepto.Controls.Add(Me.BtnGuardar)
        Me.GrpConcepto.Controls.Add(Me.PictureBox3)
        Me.GrpConcepto.Controls.Add(Me.PictureBox2)
        Me.GrpConcepto.Controls.Add(Me.cmbTipoConcepto)
        Me.GrpConcepto.Controls.Add(Me.lblConcepto)
        Me.GrpConcepto.Controls.Add(Me.CmbTipo)
        Me.GrpConcepto.Controls.Add(Me.lblTipo)
        Me.GrpConcepto.Controls.Add(Me.PictureBox1)
        Me.GrpConcepto.Controls.Add(Me.ChkEstado)
        Me.GrpConcepto.Controls.Add(Me.TxtDescripcion)
        Me.GrpConcepto.Controls.Add(Me.lblDescripcion)
        Me.GrpConcepto.Controls.Add(Me.LblClave)
        Me.GrpConcepto.Controls.Add(Me.TxtClave)
        Me.GrpConcepto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpConcepto.Location = New System.Drawing.Point(0, 0)
        Me.GrpConcepto.Name = "GrpConcepto"
        Me.GrpConcepto.Size = New System.Drawing.Size(482, 202)
        Me.GrpConcepto.TabIndex = 4
        Me.GrpConcepto.TabStop = False
        Me.GrpConcepto.Text = "Concepto"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(80, 106)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox4.TabIndex = 106
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(80, 74)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox3.TabIndex = 105
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(79, 45)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox2.TabIndex = 104
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'cmbTipoConcepto
        '
        Me.cmbTipoConcepto.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoConcepto.Location = New System.Drawing.Point(97, 106)
        Me.cmbTipoConcepto.Name = "cmbTipoConcepto"
        Me.cmbTipoConcepto.Size = New System.Drawing.Size(365, 21)
        Me.cmbTipoConcepto.TabIndex = 103
        '
        'lblConcepto
        '
        Me.lblConcepto.Location = New System.Drawing.Point(16, 109)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(66, 14)
        Me.lblConcepto.TabIndex = 102
        Me.lblConcepto.Text = "Concepto"
        '
        'CmbTipo
        '
        Me.CmbTipo.Location = New System.Drawing.Point(97, 16)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(167, 21)
        Me.CmbTipo.TabIndex = 83
        '
        'lblTipo
        '
        Me.lblTipo.Location = New System.Drawing.Point(16, 19)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(26, 14)
        Me.lblTipo.TabIndex = 91
        Me.lblTipo.Text = "Tipo"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(79, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 40
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Enabled = False
        Me.ChkEstado.Location = New System.Drawing.Point(394, 16)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(68, 22)
        Me.ChkEstado.TabIndex = 1
        Me.ChkEstado.Text = "Activo"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(97, 73)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(365, 20)
        Me.TxtDescripcion.TabIndex = 5
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Location = New System.Drawing.Point(16, 71)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(76, 18)
        Me.lblDescripcion.TabIndex = 34
        Me.lblDescripcion.Text = "Descripción"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(16, 44)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(76, 14)
        Me.LblClave.TabIndex = 1
        Me.LblClave.Text = "Clave"
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(97, 45)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(140, 20)
        Me.TxtClave.TabIndex = 0
        '
        'FrmConcepto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(482, 202)
        Me.Controls.Add(Me.GrpConcepto)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(498, 223)
        Me.Name = "FrmConcepto"
        Me.Text = "Concepto de Nómina"
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
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Publicas"

    Public Padre As String

    Public CONClave As String = ""
    Public Clave As String = ""
    Public Concepto As String = ""
    Public Tipo As Integer
    Public TipoConcepto As Integer
    Public TipoEstado As Integer = 1


#End Region

#Region "Variables Privadas"

    Private Cnx As String
    Private alerta(3) As PictureBox
    Private reloj As parpadea

    Private cargado As Boolean = False

    Private guardado As Boolean = False

#End Region

#Region "Concepto"

    Private Sub reinicializa()


        CONClave = ""
        Clave = ""
        Concepto = ""
        TipoEstado = 1

        TxtClave.Text = Clave
        TxtDescripcion.Text = Concepto
        ChkEstado.Estado = TipoEstado

        TxtClave.Focus()

    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0



        If Me.CmbTipo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 15 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 15)
        End If


        If Me.TxtDescripcion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtDescripcion.Text.Length > 30 Then
            Me.TxtDescripcion.Text = Me.TxtDescripcion.Text.Substring(0, 30)
        End If


        If Me.cmbTipoConcepto.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If


        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "ConceptoNomina", "@clave", Me.TxtClave.Text.ToUpper.Trim, "@COMClave", ModPOS.CompanyActual) > 0 Then
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

    Private Sub FrmConcepto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.BringToFront()

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4


        Cnx = ModPOS.BDConexion

        With Me.CmbTipo
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Nomina"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoConcepto"
            .llenar()
        End With

        TxtClave.Text = Clave
        TxtDescripcion.Text = Concepto
        ChkEstado.Estado = TipoEstado
        CmbTipo.SelectedValue = Tipo

        cargado = True

        If Not CmbTipo.SelectedValue Is Nothing Then
            Select Case CInt(CmbTipo.SelectedValue)
                Case 1
                    cmbTipoConcepto.Visible = True
                    lblConcepto.Visible = True
                    With Me.cmbTipoConcepto
                        .Conexion = Cnx
                        .ProcedimientoAlmacenado = "sp_filtra_valorref"
                        .NombreParametro1 = "tabla"
                        .Parametro1 = "Nomina"
                        .NombreParametro2 = "campo"
                        .Parametro2 = "TipoPercepcion"
                        .llenar()
                    End With
                Case 2
                    cmbTipoConcepto.Visible = True
                    lblConcepto.Visible = True
                    With Me.cmbTipoConcepto
                        .Conexion = Cnx
                        .ProcedimientoAlmacenado = "sp_filtra_valorref"
                        .NombreParametro1 = "tabla"
                        .Parametro1 = "Nomina"
                        .NombreParametro2 = "campo"
                        .Parametro2 = "TipoDeduccion"
                        .llenar()
                    End With
                Case 3
                    cmbTipoConcepto.Visible = False
                    lblConcepto.Visible = False
            End Select
        End If

        cmbTipoConcepto.SelectedValue = TipoConcepto



    End Sub

    Private Sub FrmConcepto_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoConceptos Is Nothing Then
            If guardado = True Then
                ModPOS.MtoConceptos.actualizaGrid()
            End If
        End If
        ModPOS.Concepto.Dispose()
        ModPOS.Concepto = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            If Me.TxtClave.Text.Length < 3 OrElse Me.TxtClave.Text.Length > 15 Then
                Beep()
                MessageBox.Show("La Clave solo puede contener de 3 hasta 15 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Select Case Me.Padre
                Case "Agregar"

                    CONClave = ModPOS.obtenerLlave
                    Clave = TxtClave.Text.ToUpper.Trim
                    Concepto = TxtDescripcion.Text.ToUpper.Trim
                    Tipo = CmbTipo.SelectedValue
                    TipoConcepto = cmbTipoConcepto.SelectedValue

                    If Tipo = 3 Then
                        TipoConcepto = 0
                    End If

                    ModPOS.Ejecuta("sp_inserta_conceptoNomina", _
                                        "@CONClave", CONClave, _
                                        "@COMClave", ModPOS.CompanyActual, _
                                        "@Tipo", Tipo, _
                                        "@Clave", Clave, _
                                        "@Concepto", Concepto, _
                                        "@TipoConcepto", TipoConcepto, _
                                        "@Usuario", ModPOS.UsuarioActual)

                    guardado = True

                    reinicializa()

                Case "Modificar"


                    If Not ( _
                        Concepto = TxtDescripcion.Text.ToUpper.Trim AndAlso _
                        TipoConcepto = cmbTipoConcepto.SelectedValue AndAlso _
                        TipoEstado = Me.ChkEstado.GetEstado) Then



                        Concepto = TxtDescripcion.Text.ToUpper.Trim
                        TipoConcepto = cmbTipoConcepto.SelectedValue
                        TipoEstado = Me.ChkEstado.GetEstado

                        ModPOS.Ejecuta("sp_modifica_conceptoNomina", _
                                        "@CONClave", CONClave, _
                                        "@Concepto", Concepto, _
                                        "@TipoConcepto", TipoConcepto, _
                                        "@Estado", TipoEstado, _
                                        "@Usuario", ModPOS.UsuarioActual)
                    End If
                    guardado = True
                    Me.Close()
            End Select

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

#End Region


    Private Sub CmbTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbTipo.SelectedIndexChanged
        If cargado = True Then
            If Not CmbTipo.SelectedValue Is Nothing Then
                Select Case CInt(CmbTipo.SelectedValue)
                    Case 1
                        cmbTipoConcepto.Visible = True
                        lblConcepto.Visible = True
                        With Me.cmbTipoConcepto
                            .Conexion = Cnx
                            .ProcedimientoAlmacenado = "sp_filtra_valorref"
                            .NombreParametro1 = "tabla"
                            .Parametro1 = "Nomina"
                            .NombreParametro2 = "campo"
                            .Parametro2 = "TipoPercepcion"
                            .llenar()
                        End With
                    Case 2
                        cmbTipoConcepto.Visible = True
                        lblConcepto.Visible = True
                        With Me.cmbTipoConcepto
                            .Conexion = Cnx
                            .ProcedimientoAlmacenado = "sp_filtra_valorref"
                            .NombreParametro1 = "tabla"
                            .Parametro1 = "Nomina"
                            .NombreParametro2 = "campo"
                            .Parametro2 = "TipoDeduccion"
                            .llenar()
                        End With
                    Case 3
                        cmbTipoConcepto.Visible = False
                        lblConcepto.Visible = False
                End Select
            End If
        End If
    End Sub
End Class
