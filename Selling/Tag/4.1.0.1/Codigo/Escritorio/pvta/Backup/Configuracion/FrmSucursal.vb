Public Class FrmSucursal
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
    Friend WithEvents GrpSucursal As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtReferenciaFac As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtNoInteriorFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtNoExteriorFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoPostalFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtLocalidadFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtDomicilioFac As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbPaisFac As Selling.StoreCombo
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmbTipo As Selling.StoreCombo
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LblTel1 As System.Windows.Forms.Label
    Friend WithEvents TxtTel1 As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpAutorizacion As System.Windows.Forms.GroupBox
    Friend WithEvents GridAutorizan As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbCertificado As Selling.StoreCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GrpIcono As System.Windows.Forms.GroupBox
    Friend WithEvents PictIcono As System.Windows.Forms.PictureBox
    Friend WithEvents TxtColoniaFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtMunicipioFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtEstadoFac As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtTel2 As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents TxtCompany As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents UiTab1 As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabCompania As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabAutorizacion As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabEstrategia As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents ChkPicking As Selling.ChkStatus
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GridProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnEstrategia As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkTransito As Selling.ChkStatus
    Friend WithEvents ChkMovilidad As Selling.ChkStatus
    Friend WithEvents txtResponsable As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtServidor As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents BtnRestablecer As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TxtMaxHits As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents CmbCampo As Selling.StoreCombo
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSucursal))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpSucursal = New System.Windows.Forms.GroupBox
        Me.txtServidor = New System.Windows.Forms.TextBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.TxtCorreo = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtResponsable = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TxtLocalidadFac = New System.Windows.Forms.TextBox
        Me.TxtCompany = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtTel2 = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.TxtColoniaFac = New System.Windows.Forms.TextBox
        Me.TxtMunicipioFac = New System.Windows.Forms.TextBox
        Me.TxtEstadoFac = New System.Windows.Forms.TextBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.GrpIcono = New System.Windows.Forms.GroupBox
        Me.PictIcono = New System.Windows.Forms.PictureBox
        Me.CmbCertificado = New Selling.StoreCombo
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox11 = New System.Windows.Forms.PictureBox
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox10 = New System.Windows.Forms.PictureBox
        Me.PictureBox9 = New System.Windows.Forms.PictureBox
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.LblTel1 = New System.Windows.Forms.Label
        Me.TxtTel1 = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.CmbTipo = New Selling.StoreCombo
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtReferenciaFac = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtNoInteriorFac = New System.Windows.Forms.TextBox
        Me.TxtNoExteriorFac = New System.Windows.Forms.TextBox
        Me.TxtCodigoPostalFac = New System.Windows.Forms.TextBox
        Me.TxtDomicilioFac = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.CmbPaisFac = New Selling.StoreCombo
        Me.Label8 = New System.Windows.Forms.Label
        Me.GrpAutorizacion = New System.Windows.Forms.GroupBox
        Me.GridAutorizan = New Janus.Windows.GridEX.GridEX
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab
        Me.UiTabCompania = New Janus.Windows.UI.Tab.UITabPage
        Me.UiTabAutorizacion = New Janus.Windows.UI.Tab.UITabPage
        Me.UiTabEstrategia = New Janus.Windows.UI.Tab.UITabPage
        Me.BtnRestablecer = New Janus.Windows.EditControls.UIButton
        Me.ChkMovilidad = New Selling.ChkStatus(Me.components)
        Me.ChkTransito = New Selling.ChkStatus(Me.components)
        Me.BtnEstrategia = New Janus.Windows.EditControls.UIButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.TxtMaxHits = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.CmbCampo = New Selling.StoreCombo
        Me.TxtBuscar = New System.Windows.Forms.TextBox
        Me.GridProductos = New Janus.Windows.GridEX.GridEX
        Me.ChkPicking = New Selling.ChkStatus(Me.components)
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.GrpSucursal.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpIcono.SuspendLayout()
        CType(Me.PictIcono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpAutorizacion.SuspendLayout()
        CType(Me.GridAutorizan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabCompania.SuspendLayout()
        Me.UiTabAutorizacion.SuspendLayout()
        Me.UiTabEstrategia.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(592, 523)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(690, 523)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpSucursal
        '
        Me.GrpSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpSucursal.BackColor = System.Drawing.Color.Transparent
        Me.GrpSucursal.Controls.Add(Me.txtServidor)
        Me.GrpSucursal.Controls.Add(Me.Label37)
        Me.GrpSucursal.Controls.Add(Me.TxtCorreo)
        Me.GrpSucursal.Controls.Add(Me.Label18)
        Me.GrpSucursal.Controls.Add(Me.txtResponsable)
        Me.GrpSucursal.Controls.Add(Me.Label17)
        Me.GrpSucursal.Controls.Add(Me.TxtLocalidadFac)
        Me.GrpSucursal.Controls.Add(Me.TxtCompany)
        Me.GrpSucursal.Controls.Add(Me.Label16)
        Me.GrpSucursal.Controls.Add(Me.PictureBox4)
        Me.GrpSucursal.Controls.Add(Me.Label4)
        Me.GrpSucursal.Controls.Add(Me.TxtTel2)
        Me.GrpSucursal.Controls.Add(Me.TxtColoniaFac)
        Me.GrpSucursal.Controls.Add(Me.TxtMunicipioFac)
        Me.GrpSucursal.Controls.Add(Me.TxtEstadoFac)
        Me.GrpSucursal.Controls.Add(Me.PictureBox2)
        Me.GrpSucursal.Controls.Add(Me.GrpIcono)
        Me.GrpSucursal.Controls.Add(Me.CmbCertificado)
        Me.GrpSucursal.Controls.Add(Me.Label2)
        Me.GrpSucursal.Controls.Add(Me.PictureBox11)
        Me.GrpSucursal.Controls.Add(Me.TxtClave)
        Me.GrpSucursal.Controls.Add(Me.Label1)
        Me.GrpSucursal.Controls.Add(Me.PictureBox10)
        Me.GrpSucursal.Controls.Add(Me.PictureBox9)
        Me.GrpSucursal.Controls.Add(Me.PictureBox8)
        Me.GrpSucursal.Controls.Add(Me.PictureBox7)
        Me.GrpSucursal.Controls.Add(Me.PictureBox6)
        Me.GrpSucursal.Controls.Add(Me.PictureBox5)
        Me.GrpSucursal.Controls.Add(Me.PictureBox3)
        Me.GrpSucursal.Controls.Add(Me.PictureBox1)
        Me.GrpSucursal.Controls.Add(Me.LblTel1)
        Me.GrpSucursal.Controls.Add(Me.TxtTel1)
        Me.GrpSucursal.Controls.Add(Me.Label9)
        Me.GrpSucursal.Controls.Add(Me.CmbTipo)
        Me.GrpSucursal.Controls.Add(Me.TxtNombre)
        Me.GrpSucursal.Controls.Add(Me.Label11)
        Me.GrpSucursal.Controls.Add(Me.Label15)
        Me.GrpSucursal.Controls.Add(Me.TxtReferenciaFac)
        Me.GrpSucursal.Controls.Add(Me.Label14)
        Me.GrpSucursal.Controls.Add(Me.Label13)
        Me.GrpSucursal.Controls.Add(Me.Label12)
        Me.GrpSucursal.Controls.Add(Me.Label10)
        Me.GrpSucursal.Controls.Add(Me.TxtNoInteriorFac)
        Me.GrpSucursal.Controls.Add(Me.TxtNoExteriorFac)
        Me.GrpSucursal.Controls.Add(Me.TxtCodigoPostalFac)
        Me.GrpSucursal.Controls.Add(Me.TxtDomicilioFac)
        Me.GrpSucursal.Controls.Add(Me.Label3)
        Me.GrpSucursal.Controls.Add(Me.Label5)
        Me.GrpSucursal.Controls.Add(Me.Label6)
        Me.GrpSucursal.Controls.Add(Me.Label7)
        Me.GrpSucursal.Controls.Add(Me.CmbPaisFac)
        Me.GrpSucursal.Controls.Add(Me.Label8)
        Me.GrpSucursal.Location = New System.Drawing.Point(6, 4)
        Me.GrpSucursal.Name = "GrpSucursal"
        Me.GrpSucursal.Size = New System.Drawing.Size(766, 465)
        Me.GrpSucursal.TabIndex = 4
        Me.GrpSucursal.TabStop = False
        Me.GrpSucursal.Text = "Sucursal"
        '
        'txtServidor
        '
        Me.txtServidor.Location = New System.Drawing.Point(86, 301)
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Size = New System.Drawing.Size(254, 20)
        Me.txtServidor.TabIndex = 141
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(5, 304)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(70, 15)
        Me.Label37.TabIndex = 140
        Me.Label37.Text = "Servidor BD"
        '
        'TxtCorreo
        '
        Me.TxtCorreo.Location = New System.Drawing.Point(550, 271)
        Me.TxtCorreo.Name = "TxtCorreo"
        Me.TxtCorreo.Size = New System.Drawing.Size(195, 20)
        Me.TxtCorreo.TabIndex = 138
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(513, 274)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 15)
        Me.Label18.TabIndex = 139
        Me.Label18.Text = "eMail"
        '
        'txtResponsable
        '
        Me.txtResponsable.Location = New System.Drawing.Point(86, 270)
        Me.txtResponsable.Name = "txtResponsable"
        Me.txtResponsable.Size = New System.Drawing.Size(254, 20)
        Me.txtResponsable.TabIndex = 136
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(5, 273)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 15)
        Me.Label17.TabIndex = 137
        Me.Label17.Text = "Responsable"
        '
        'TxtLocalidadFac
        '
        Me.TxtLocalidadFac.Location = New System.Drawing.Point(550, 135)
        Me.TxtLocalidadFac.Name = "TxtLocalidadFac"
        Me.TxtLocalidadFac.Size = New System.Drawing.Size(195, 20)
        Me.TxtLocalidadFac.TabIndex = 5
        '
        'TxtCompany
        '
        Me.TxtCompany.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCompany.Enabled = False
        Me.TxtCompany.Location = New System.Drawing.Point(86, 16)
        Me.TxtCompany.Name = "TxtCompany"
        Me.TxtCompany.ReadOnly = True
        Me.TxtCompany.Size = New System.Drawing.Size(660, 20)
        Me.TxtCompany.TabIndex = 135
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(5, 19)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 14)
        Me.Label16.TabIndex = 134
        Me.Label16.Text = "Compañia"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(749, 96)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox4.TabIndex = 89
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(563, 250)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 15)
        Me.Label4.TabIndex = 102
        Me.Label4.Text = "Tel 2"
        '
        'TxtTel2
        '
        Me.TxtTel2.Location = New System.Drawing.Point(618, 246)
        Me.TxtTel2.Mask = "!(##) 0000-0000"
        Me.TxtTel2.Name = "TxtTel2"
        Me.TxtTel2.Size = New System.Drawing.Size(127, 20)
        Me.TxtTel2.TabIndex = 13
        Me.TxtTel2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'TxtColoniaFac
        '
        Me.TxtColoniaFac.Location = New System.Drawing.Point(85, 161)
        Me.TxtColoniaFac.Name = "TxtColoniaFac"
        Me.TxtColoniaFac.Size = New System.Drawing.Size(195, 20)
        Me.TxtColoniaFac.TabIndex = 6
        '
        'TxtMunicipioFac
        '
        Me.TxtMunicipioFac.Location = New System.Drawing.Point(84, 134)
        Me.TxtMunicipioFac.Name = "TxtMunicipioFac"
        Me.TxtMunicipioFac.Size = New System.Drawing.Size(195, 20)
        Me.TxtMunicipioFac.TabIndex = 4
        '
        'TxtEstadoFac
        '
        Me.TxtEstadoFac.Location = New System.Drawing.Point(550, 108)
        Me.TxtEstadoFac.Name = "TxtEstadoFac"
        Me.TxtEstadoFac.Size = New System.Drawing.Size(195, 20)
        Me.TxtEstadoFac.TabIndex = 3
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(286, 79)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox2.TabIndex = 87
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'GrpIcono
        '
        Me.GrpIcono.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpIcono.Controls.Add(Me.PictIcono)
        Me.GrpIcono.Location = New System.Drawing.Point(7, 330)
        Me.GrpIcono.Name = "GrpIcono"
        Me.GrpIcono.Size = New System.Drawing.Size(754, 126)
        Me.GrpIcono.TabIndex = 21
        Me.GrpIcono.TabStop = False
        Me.GrpIcono.Text = "Publicidad (1024 x 262)"
        '
        'PictIcono
        '
        Me.PictIcono.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictIcono.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PictIcono.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictIcono.Location = New System.Drawing.Point(7, 16)
        Me.PictIcono.Name = "PictIcono"
        Me.PictIcono.Size = New System.Drawing.Size(741, 100)
        Me.PictIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictIcono.TabIndex = 0
        Me.PictIcono.TabStop = False
        '
        'CmbCertificado
        '
        Me.CmbCertificado.Location = New System.Drawing.Point(86, 243)
        Me.CmbCertificado.Name = "CmbCertificado"
        Me.CmbCertificado.Size = New System.Drawing.Size(254, 21)
        Me.CmbCertificado.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(5, 245)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 18)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "Certificado"
        '
        'PictureBox11
        '
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(194, 53)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox11.TabIndex = 98
        Me.PictureBox11.TabStop = False
        Me.PictureBox11.Visible = False
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(86, 53)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(103, 20)
        Me.TxtClave.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 14)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "Clave"
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(614, 194)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox10.TabIndex = 95
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(456, 189)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox9.TabIndex = 94
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(749, 152)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox8.TabIndex = 93
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(285, 161)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox7.TabIndex = 92
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(749, 123)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox6.TabIndex = 91
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(285, 137)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox5.TabIndex = 90
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(255, 108)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox3.TabIndex = 88
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(659, 57)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(15, 15)
        Me.PictureBox1.TabIndex = 86
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'LblTel1
        '
        Me.LblTel1.Location = New System.Drawing.Point(563, 222)
        Me.LblTel1.Name = "LblTel1"
        Me.LblTel1.Size = New System.Drawing.Size(37, 15)
        Me.LblTel1.TabIndex = 85
        Me.LblTel1.Text = "Tel 1"
        '
        'TxtTel1
        '
        Me.TxtTel1.Location = New System.Drawing.Point(618, 218)
        Me.TxtTel1.Mask = "!(##) 0000-0000"
        Me.TxtTel1.Name = "TxtTel1"
        Me.TxtTel1.Size = New System.Drawing.Size(127, 20)
        Me.TxtTel1.TabIndex = 12
        Me.TxtTel1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(500, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 12)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "Tipo"
        '
        'CmbTipo
        '
        Me.CmbTipo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipo.Location = New System.Drawing.Point(550, 54)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(103, 21)
        Me.CmbTipo.TabIndex = 0
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(85, 79)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(195, 20)
        Me.TxtNombre.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(5, 82)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 15)
        Me.Label11.TabIndex = 81
        Me.Label11.Text = "Nombre"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(5, 217)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 15)
        Me.Label15.TabIndex = 79
        Me.Label15.Text = "Referencia"
        '
        'TxtReferenciaFac
        '
        Me.TxtReferenciaFac.Location = New System.Drawing.Point(85, 215)
        Me.TxtReferenciaFac.Name = "TxtReferenciaFac"
        Me.TxtReferenciaFac.Size = New System.Drawing.Size(255, 20)
        Me.TxtReferenciaFac.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(633, 193)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 16)
        Me.Label14.TabIndex = 76
        Me.Label14.Text = "No. Int."
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(500, 193)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 16)
        Me.Label13.TabIndex = 75
        Me.Label13.Text = "No. Ext."
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(543, 164)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 15)
        Me.Label12.TabIndex = 74
        Me.Label12.Text = "Código Postal"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(441, 139)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 14)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "Ciudad/Población"
        '
        'TxtNoInteriorFac
        '
        Me.TxtNoInteriorFac.Location = New System.Drawing.Point(691, 189)
        Me.TxtNoInteriorFac.Name = "TxtNoInteriorFac"
        Me.TxtNoInteriorFac.Size = New System.Drawing.Size(55, 20)
        Me.TxtNoInteriorFac.TabIndex = 10
        '
        'TxtNoExteriorFac
        '
        Me.TxtNoExteriorFac.Location = New System.Drawing.Point(550, 190)
        Me.TxtNoExteriorFac.Name = "TxtNoExteriorFac"
        Me.TxtNoExteriorFac.Size = New System.Drawing.Size(55, 20)
        Me.TxtNoExteriorFac.TabIndex = 9
        '
        'TxtCodigoPostalFac
        '
        Me.TxtCodigoPostalFac.Location = New System.Drawing.Point(623, 162)
        Me.TxtCodigoPostalFac.Name = "TxtCodigoPostalFac"
        Me.TxtCodigoPostalFac.Size = New System.Drawing.Size(123, 20)
        Me.TxtCodigoPostalFac.TabIndex = 7
        '
        'TxtDomicilioFac
        '
        Me.TxtDomicilioFac.Location = New System.Drawing.Point(85, 189)
        Me.TxtDomicilioFac.Name = "TxtDomicilioFac"
        Me.TxtDomicilioFac.Size = New System.Drawing.Size(337, 20)
        Me.TxtDomicilioFac.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(5, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 15)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Calle"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(5, 161)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 18)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Colonia"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(5, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 15)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Municipio"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(489, 111)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 15)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Entidad"
        '
        'CmbPaisFac
        '
        Me.CmbPaisFac.Location = New System.Drawing.Point(85, 106)
        Me.CmbPaisFac.Name = "CmbPaisFac"
        Me.CmbPaisFac.Size = New System.Drawing.Size(167, 21)
        Me.CmbPaisFac.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(5, 109)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 15)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "País"
        '
        'GrpAutorizacion
        '
        Me.GrpAutorizacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpAutorizacion.BackColor = System.Drawing.Color.Transparent
        Me.GrpAutorizacion.Controls.Add(Me.GridAutorizan)
        Me.GrpAutorizacion.Location = New System.Drawing.Point(2, 39)
        Me.GrpAutorizacion.Name = "GrpAutorizacion"
        Me.GrpAutorizacion.Size = New System.Drawing.Size(770, 442)
        Me.GrpAutorizacion.TabIndex = 5
        Me.GrpAutorizacion.TabStop = False
        Me.GrpAutorizacion.Text = "Autorizan"
        '
        'GridAutorizan
        '
        Me.GridAutorizan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridAutorizan.ColumnAutoResize = True
        Me.GridAutorizan.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridAutorizan.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridAutorizan.GroupByBoxVisible = False
        Me.GridAutorizan.Location = New System.Drawing.Point(7, 15)
        Me.GridAutorizan.Name = "GridAutorizan"
        Me.GridAutorizan.RecordNavigator = True
        Me.GridAutorizan.Size = New System.Drawing.Size(758, 420)
        Me.GridAutorizan.TabIndex = 1
        Me.GridAutorizan.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(704, 7)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(63, 30)
        Me.BtnAgregar.TabIndex = 2
        Me.BtnAgregar.ToolTipText = "Agregar personal para Autorización"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEliminar.Icon = CType(resources.GetObject("BtnEliminar.Icon"), System.Drawing.Icon)
        Me.BtnEliminar.Location = New System.Drawing.Point(636, 7)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(62, 30)
        Me.BtnEliminar.TabIndex = 4
        Me.BtnEliminar.ToolTipText = "Eliminar personal para Autorización"
        Me.BtnEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTab1
        '
        Me.UiTab1.BackColor = System.Drawing.Color.Transparent
        Me.UiTab1.Location = New System.Drawing.Point(3, 4)
        Me.UiTab1.Name = "UiTab1"
        Me.UiTab1.Size = New System.Drawing.Size(777, 506)
        Me.UiTab1.TabIndex = 20
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabCompania, Me.UiTabAutorizacion, Me.UiTabEstrategia})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabCompania
        '
        Me.UiTabCompania.Controls.Add(Me.GrpSucursal)
        Me.UiTabCompania.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCompania.Name = "UiTabCompania"
        Me.UiTabCompania.Size = New System.Drawing.Size(775, 484)
        Me.UiTabCompania.TabStop = True
        Me.UiTabCompania.Text = "General"
        '
        'UiTabAutorizacion
        '
        Me.UiTabAutorizacion.Controls.Add(Me.GrpAutorizacion)
        Me.UiTabAutorizacion.Controls.Add(Me.BtnEliminar)
        Me.UiTabAutorizacion.Controls.Add(Me.BtnAgregar)
        Me.UiTabAutorizacion.Location = New System.Drawing.Point(1, 21)
        Me.UiTabAutorizacion.Name = "UiTabAutorizacion"
        Me.UiTabAutorizacion.Size = New System.Drawing.Size(775, 484)
        Me.UiTabAutorizacion.TabStop = True
        Me.UiTabAutorizacion.Text = "Autorizaciones"
        '
        'UiTabEstrategia
        '
        Me.UiTabEstrategia.Controls.Add(Me.BtnRestablecer)
        Me.UiTabEstrategia.Controls.Add(Me.ChkMovilidad)
        Me.UiTabEstrategia.Controls.Add(Me.ChkTransito)
        Me.UiTabEstrategia.Controls.Add(Me.BtnEstrategia)
        Me.UiTabEstrategia.Controls.Add(Me.GroupBox2)
        Me.UiTabEstrategia.Controls.Add(Me.ChkPicking)
        Me.UiTabEstrategia.Location = New System.Drawing.Point(1, 21)
        Me.UiTabEstrategia.Name = "UiTabEstrategia"
        Me.UiTabEstrategia.Size = New System.Drawing.Size(775, 484)
        Me.UiTabEstrategia.TabStop = True
        Me.UiTabEstrategia.Text = "Productos"
        '
        'BtnRestablecer
        '
        Me.BtnRestablecer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRestablecer.Icon = CType(resources.GetObject("BtnRestablecer.Icon"), System.Drawing.Icon)
        Me.BtnRestablecer.Location = New System.Drawing.Point(499, 9)
        Me.BtnRestablecer.Name = "BtnRestablecer"
        Me.BtnRestablecer.Size = New System.Drawing.Size(131, 30)
        Me.BtnRestablecer.TabIndex = 142
        Me.BtnRestablecer.Text = "Restablecer"
        Me.BtnRestablecer.ToolTipText = "Agrega los productos faltantes a la sucursal y restablece los valores predetermin" & _
            "ados de los productos actuales."
        Me.BtnRestablecer.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkMovilidad
        '
        Me.ChkMovilidad.BackColor = System.Drawing.Color.Transparent
        Me.ChkMovilidad.Location = New System.Drawing.Point(239, 6)
        Me.ChkMovilidad.Name = "ChkMovilidad"
        Me.ChkMovilidad.Size = New System.Drawing.Size(91, 22)
        Me.ChkMovilidad.TabIndex = 141
        Me.ChkMovilidad.Text = "Movilidad"
        Me.ChkMovilidad.UseVisualStyleBackColor = False
        '
        'ChkTransito
        '
        Me.ChkTransito.BackColor = System.Drawing.Color.Transparent
        Me.ChkTransito.Checked = True
        Me.ChkTransito.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkTransito.Location = New System.Drawing.Point(103, 6)
        Me.ChkTransito.Name = "ChkTransito"
        Me.ChkTransito.Size = New System.Drawing.Size(166, 22)
        Me.ChkTransito.TabIndex = 140
        Me.ChkTransito.Text = "Confirmar Transito"
        Me.ChkTransito.UseVisualStyleBackColor = False
        '
        'BtnEstrategia
        '
        Me.BtnEstrategia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEstrategia.Image = CType(resources.GetObject("BtnEstrategia.Image"), System.Drawing.Image)
        Me.BtnEstrategia.Location = New System.Drawing.Point(636, 9)
        Me.BtnEstrategia.Name = "BtnEstrategia"
        Me.BtnEstrategia.Size = New System.Drawing.Size(131, 30)
        Me.BtnEstrategia.TabIndex = 139
        Me.BtnEstrategia.Text = "Estrategia"
        Me.BtnEstrategia.ToolTipText = "Modificar registro seleccionado"
        Me.BtnEstrategia.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.TxtMaxHits)
        Me.GroupBox2.Controls.Add(Me.CmbCampo)
        Me.GroupBox2.Controls.Add(Me.TxtBuscar)
        Me.GroupBox2.Controls.Add(Me.GridProductos)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(770, 440)
        Me.GroupBox2.TabIndex = 138
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Productos"
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(573, 23)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(99, 13)
        Me.Label19.TabIndex = 154
        Me.Label19.Text = "Max. Coincidencias"
        '
        'TxtMaxHits
        '
        Me.TxtMaxHits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMaxHits.DecimalDigits = 0
        Me.TxtMaxHits.Location = New System.Drawing.Point(710, 19)
        Me.TxtMaxHits.Name = "TxtMaxHits"
        Me.TxtMaxHits.Size = New System.Drawing.Size(55, 20)
        Me.TxtMaxHits.TabIndex = 153
        Me.TxtMaxHits.Text = "1,000"
        Me.TxtMaxHits.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.TxtMaxHits.Value = 1000
        Me.TxtMaxHits.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(7, 19)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(166, 21)
        Me.CmbCampo.TabIndex = 152
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Location = New System.Drawing.Point(178, 19)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(335, 20)
        Me.TxtBuscar.TabIndex = 151
        '
        'GridProductos
        '
        Me.GridProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridProductos.AutoEdit = True
        Me.GridProductos.ColumnAutoResize = True
        Me.GridProductos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridProductos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridProductos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridProductos.GroupByBoxVisible = False
        Me.GridProductos.Location = New System.Drawing.Point(7, 46)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.RecordNavigator = True
        Me.GridProductos.Size = New System.Drawing.Size(758, 387)
        Me.GridProductos.TabIndex = 1
        Me.GridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ChkPicking
        '
        Me.ChkPicking.BackColor = System.Drawing.Color.Transparent
        Me.ChkPicking.Checked = True
        Me.ChkPicking.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPicking.Location = New System.Drawing.Point(6, 6)
        Me.ChkPicking.Name = "ChkPicking"
        Me.ChkPicking.Size = New System.Drawing.Size(91, 22)
        Me.ChkPicking.TabIndex = 137
        Me.ChkPicking.Text = "Picking"
        Me.ChkPicking.UseVisualStyleBackColor = False
        '
        'Clock
        '
        Me.Clock.Interval = 500
        '
        'FrmSucursal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.UiTab1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmSucursal"
        Me.Text = "Sucursal"
        Me.GrpSucursal.ResumeLayout(False)
        Me.GrpSucursal.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpIcono.ResumeLayout(False)
        CType(Me.PictIcono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpAutorizacion.ResumeLayout(False)
        CType(Me.GridAutorizan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        Me.UiTabCompania.ResumeLayout(False)
        Me.UiTabAutorizacion.ResumeLayout(False)
        Me.UiTabEstrategia.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private aEstado() As String
    Private aMnpio() As String
    Private aColonia() As String

    Public Padre As String = ""
    Public Icono As Byte()
    Public NuevoIcono As Boolean = False
    Public SUCClave As String = ""
    Public Clave As String = ""
    Public Nombre As String = ""
    Public Tipo As Integer = 1
    Public Pais As String = ""
    Public Estado As String = ""
    Public Mnpio As String = ""
    Public Colonia As String = ""
    Public Calle As String = ""
    Public CodigoPostal As String = ""
    Public Referencia As String = ""
    Public Localidad As String = ""
    Public noExterior As String = ""
    Public noInterior As String = ""
    Public Tel As String = ""
    Public Tel2 As String = ""

    Public CERClave As String = ""

    Public Picking As Boolean = False
    Public Transito As Boolean = False
    Public Movilidad As Boolean = False

    Public Responsable As String = ""
    Public eMail As String = ""
    Public Servidor As String = ""

    Private cargado As Boolean = False
    Private alerta(10) As PictureBox
    Private reloj As parpadea

    Private sAutorizaSelected, sNombre, sListaSelected, sLista, sProductoSelected, sClave, sRecolectorSelected, sRecolector, sRecNombre, sProductoNombre As String
    Private iRecOrden As Integer

    Private bCambiosAutorizacion As Boolean = False
    Private bCambiosListas As Boolean = False

    Private dtAutoriza, dtImpuesto, dtRotacion, dtSucursalProducto, dtRecolectores, dtEstrategia As DataTable

    Private Sub actGrid(ByVal MaxHits As Integer, ByVal iCampo As Integer, ByVal sBusqueda As String, ByVal Reinicia As Boolean)
        Clock.Stop()
        If cargado Then

            If Not dtSucursalProducto Is Nothing Then
                Dim foundRows() As DataRow
                foundRows = dtSucursalProducto.Select("Actualizado = 1")

                If foundRows.GetLength(0) > 0 AndAlso Reinicia = False Then
                    Select Case MessageBox.Show("¿Desea continuar con la busqueda y perder los cambios realizados?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        Case DialogResult.No
                            Exit Sub
                    End Select
                End If

                dtSucursalProducto.Dispose()
            End If

            If Padre = "Agregar" Then

                dtSucursalProducto = ModPOS.CrearTabla("SucursalProducto", _
                                                 "PROClave", "System.String", _
                                                 "Clave", "System.String", _
                                                 "Nombre", "System.String", _
                                                 "CostoVigente", "System.Double", _
                                                 "Minimo", "System.Double", _
                                                 "Maximo", "System.Double", _
                                                 "Reorden", "System.Double", _
                                                 "Rotación", "System.Int32", _
                                                 "TipoImpuesto", "System.Int32", _
                                                 "Estrategia", "System.Boolean", _
                                                 "Actualizado", "System.Int32", _
                                                 "Edited", "System.Int32")
            Else

                dtSucursalProducto = ModPOS.Recupera_Tabla("sp_muestra_sucursalproducto", "@Max", MaxHits, "@Campo", iCampo, "@Busqueda", sBusqueda, "@SUCClave", SUCClave)


            End If

            GridProductos.DataSource = dtSucursalProducto
            GridProductos.RetrieveStructure(True)
            GridProductos.GroupByBoxVisible = False



            GridProductos.RootTable.Columns("PROClave").Visible = False
            GridProductos.RootTable.Columns("Actualizado").Visible = False
            GridProductos.RootTable.Columns("Edited").Visible = False


            GridProductos.CurrentTable.Columns("Rotación").HasValueList = True
            Dim AircraftTypeValueListItemCollection As Janus.Windows.GridEX.GridEXValueListItemCollection
            AircraftTypeValueListItemCollection = GridProductos.Tables(0).Columns("Rotación").ValueList
            With AircraftTypeValueListItemCollection

                dtRotacion = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Producto", "@Campo", "Rotacion")

                Dim i As Integer

                For i = 0 To dtRotacion.Rows.Count - 1
                    .Add(dtRotacion.Rows(i)("valor"), dtRotacion.Rows(i)("descripcion"))
                Next

            End With
            GridProductos.CurrentTable.Columns("Rotación").EditType = Janus.Windows.GridEX.EditType.Combo



            GridProductos.CurrentTable.Columns("TipoImpuesto").HasValueList = True
            Dim AircraftTypeValueListItemCollection2 As Janus.Windows.GridEX.GridEXValueListItemCollection
            AircraftTypeValueListItemCollection2 = GridProductos.Tables(0).Columns("TipoImpuesto").ValueList
            With AircraftTypeValueListItemCollection2

                dtImpuesto = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Impuesto", "@Campo", "Tipo")

                Dim i As Integer

                For i = 0 To dtImpuesto.Rows.Count - 1
                    .Add(dtImpuesto.Rows(i)("valor"), dtImpuesto.Rows(i)("descripcion"))
                Next

            End With
            GridProductos.CurrentTable.Columns("TipoImpuesto").EditType = Janus.Windows.GridEX.EditType.Combo

            Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
            fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridProductos.RootTable.Columns("Edited"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

            fc.FormatStyle.ForeColor = System.Drawing.Color.Red
            GridProductos.RootTable.FormatConditions.Add(fc)

            Dim fc2 As Janus.Windows.GridEX.GridEXFormatCondition
            fc2 = New Janus.Windows.GridEX.GridEXFormatCondition(GridProductos.RootTable.Columns("Estrategia"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

            fc2.FormatStyle.ForeColor = System.Drawing.Color.Gray
            GridProductos.RootTable.FormatConditions.Add(fc2)

        End If

    End Sub


    Private Sub reinicializa()
        CmbTipo.SelectedValue = 0
        TxtClave.Text = ""
        TxtNombre.Text = ""
        TxtEstadoFac.Text = ""
        TxtMunicipioFac.Text = ""
        TxtColoniaFac.Text = ""
        TxtDomicilioFac.Text = ""
        TxtCodigoPostalFac.Text = ""
        TxtReferenciaFac.Text = ""
        TxtLocalidadFac.Text = ""
        TxtNoExteriorFac.Text = ""
        TxtNoInteriorFac.Text = ""
        TxtTel1.Text = ""
        TxtTel2.Text = ""
        CmbCertificado.SelectedValue = ""
        ChkPicking.Estado = 0
        ChkTransito.Estado = 0
        ChkMovilidad.Estado = 0
        txtResponsable.Text = ""
        TxtCorreo.Text = ""
        txtServidor.Text = ""

        If Not PictIcono.Image Is Nothing Then
            PictIcono.Image.Dispose()
        End If

        If Not dtAutoriza Is Nothing Then
            dtAutoriza.Dispose()
        End If


        NuevoIcono = False



        dtEstrategia = ModPOS.CrearTabla("Estrategia", _
          "id", "System.String", _
          "Tipo", "System.Int32", _
          "PROClave", "System.String", _
          "Orden", "System.Int32", _
          "ALMClave", "System.String", _
          "AREClave", "System.String", _
          "ESTClave", "System.String", _
          "Zona", "System.Int32", _
          "UBCClave", "System.String", _
          "Update", "System.Int32", _
          "Baja", "System.Int32")

        dtAutoriza = ModPOS.CrearTabla("Autorizacion", _
                                        "USRClave", "System.String", _
                                        "Nombre", "System.String", _
                                        "Firma", "System.String", _
                                        "Firma2", "System.String", _
                                        "Monto Inicial", "System.Double", _
                                        "Monto Final", "System.Double", _
                                        "Dias", "System.Int32", _
                                        "FechaInicio", "System.DateTime")



        dtRecolectores = ModPOS.CrearTabla("Recolectores", _
                                "USRClave", "System.String", _
                                "Clave", "System.String", _
                                "Nombre", "System.String", _
                                "Orden", "System.Int32", _
                                "Baja", "System.Int32")



        GridAutorizan.DataSource = dtAutoriza
        GridAutorizan.RetrieveStructure(True)
        GridAutorizan.GroupByBoxVisible = False
        GridAutorizan.RootTable.Columns("USRClave").Visible = False
        GridAutorizan.RootTable.Columns("Firma2").Visible = False
        GridAutorizan.CurrentTable.Columns("Nombre").Selectable = False



       
        Me.actGrid(CInt(TxtMaxHits.Text), CmbCampo.SelectedValue, TxtBuscar.Text, True)


    End Sub


    Public Sub setEstrategia(ByVal dt As DataTable, ByVal sPROClave As String)
        Dim foundRows() As DataRow
        Dim frEstrategia() As DataRow
        Dim j As Integer

        foundRows = dt.Select("Update = 1")
        For j = 0 To foundRows.GetUpperBound(0)
            frEstrategia = dtEstrategia.Select("PROClave = '" & foundRows(j)("PROClave") & "' and ALMClave = '" & foundRows(j)("ALMClave") & "' and ESTClave = '" & foundRows(j)("ESTClave") & "' and Zona = " & CStr(foundRows(j)("Zona")) & " and UBCClave = '" & foundRows(j)("UBCClave") & "' and Tipo = " & CStr(foundRows(j)("Tipo")))
            If frEstrategia.Length = 0 Then
                'Agrega estrategia

                Dim row1 As DataRow
                row1 = dtEstrategia.NewRow()
                'declara el nombre de la fila
                row1.Item("id") = foundRows(j)("id")
                row1.Item("Tipo") = foundRows(j)("Tipo")
                row1.Item("PROClave") = foundRows(j)("PROClave")
                row1.Item("Orden") = foundRows(j)("Orden")
                row1.Item("ALMClave") = foundRows(j)("ALMClave")
                row1.Item("AREClave") = foundRows(j)("AREClave")
                row1.Item("ESTClave") = foundRows(j)("ESTClave")
                row1.Item("Zona") = foundRows(j)("Zona")
                row1.Item("UBCClave") = foundRows(j)("UBCClave")
                row1.Item("Update") = foundRows(j)("Update")
                row1.Item("Baja") = foundRows(j)("Baja")
                'agrega la fila completo a la tabla
                dtEstrategia.Rows.Add(row1)
            Else
                'Actualiza estrategia

                frEstrategia(0)("Tipo") = foundRows(j)("Tipo")
                frEstrategia(0)("PROClave") = foundRows(j)("PROClave")
                frEstrategia(0)("Orden") = foundRows(j)("Orden")
                frEstrategia(0)("ALMClave") = foundRows(j)("ALMClave")
                frEstrategia(0)("AREClave") = foundRows(j)("AREClave")
                frEstrategia(0)("ESTClave") = foundRows(j)("ESTClave")
                frEstrategia(0)("Zona") = foundRows(j)("Zona")
                frEstrategia(0)("UBCClave") = foundRows(j)("UBCClave")
                frEstrategia(0)("Update") = foundRows(j)("Update")
                frEstrategia(0)("Baja") = foundRows(j)("Baja")

            End If
        Next

        foundRows = dtSucursalProducto.Select("PROClave ='" & sPROClave & "'")

        foundRows(0)("Edited") = 1
        foundRows(0)("Estrategia") = 1




    End Sub


    Public Sub updEstrategia()
        If sProductoSelected <> "" Then

            Dim foundRows() As DataRow


            foundRows = dtSucursalProducto.Select("PROClave='" & sProductoSelected & "' and Edited=1")
            If foundRows.Length = 0 Then

                If ModPOS.Estrategia Is Nothing Then
                    ModPOS.Estrategia = New FrmEstrategia
                    With ModPOS.Estrategia
                        Text = "Estrategia Colocación/Recolección"
                        .Padre = Me.Padre
                        .SUCClave = Me.SUCClave
                        .PROClave = Me.sProductoSelected
                        .Clave = sClave
                        .Nombre = sProductoNombre

                    End With
                End If
                ModPOS.Estrategia.StartPosition = FormStartPosition.CenterScreen
                ModPOS.Estrategia.Show()
                ModPOS.Estrategia.BringToFront()
            Else
                MessageBox.Show("No es posible modificar la estrategia del producto seleccionado debido a que se encontraron cambios pendientes de aplicar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbTipo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbPaisFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtEstadoFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtMunicipioFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtLocalidadFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtColoniaFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtCodigoPostalFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtDomicilioFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(8))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtNoExteriorFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(9))
            reloj.Enabled = True
            reloj.Start()
        End If


        If TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(10))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Sucursal", "@clave", Me.TxtClave.Text.ToUpper.Trim, "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("La Referencia que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(1))
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

    Private Sub FrmSucursal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        Me.TxtCompany.Text = ModPOS.CompanyName

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

        With Me.CmbCampo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Producto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Filtro"
            .llenar()
        End With

        With Me.CmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Sucursal"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With Me.CmbPaisFac
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Geografia"
            .NombreParametro2 = "campo"
            .Parametro2 = "Pais"
            .llenar()
        End With

        With Me.CmbCertificado
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_certificado"
            .NombreParametro1 = "COMClave"
            .Parametro1 = ModPOS.CompanyActual
            .llenar()
        End With

        CmbTipo.SelectedValue = Tipo
        TxtClave.Text = Clave
        TxtNombre.Text = Nombre
        CmbPaisFac.Text = Pais

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


        TxtEstadoFac.Text = Estado
        TxtMunicipioFac.Text = Mnpio
        TxtColoniaFac.Text = Colonia
        TxtDomicilioFac.Text = Calle
        TxtCodigoPostalFac.Text = CodigoPostal
        TxtReferenciaFac.Text = Referencia
        TxtLocalidadFac.Text = Localidad
        TxtNoExteriorFac.Text = noExterior
        TxtNoInteriorFac.Text = noInterior
        TxtTel1.Text = Tel
        TxtTel2.Text = Tel2

        CmbCertificado.SelectedValue = CERClave

        ChkPicking.Estado = Math.Abs(CInt(Picking))

        ChkTransito.Estado = Math.Abs(CInt(Transito))

        ChkMovilidad.Estado = Math.Abs(CInt(Movilidad))

        txtResponsable.Text = Responsable
        TxtCorreo.Text = eMail
        txtServidor.Text = Servidor


        cargado = True

        dtEstrategia = ModPOS.CrearTabla("Estrategia", _
          "id", "System.String", _
          "Tipo", "System.Int32", _
          "PROClave", "System.String", _
          "Orden", "System.Int32", _
          "ALMClave", "System.String", _
          "AREClave", "System.String", _
          "ESTClave", "System.String", _
          "Zona", "System.Int32", _
          "UBCClave", "System.String", _
          "Update", "System.Int32", _
          "Baja", "System.Int32")

        If Padre = "Agregar" Then

            Me.BtnEstrategia.Enabled = False



            dtAutoriza = ModPOS.CrearTabla("Autorizacion", _
           "USRClave", "System.String", _
           "Nombre", "System.String", _
           "Firma", "System.String", _
           "Firma2", "System.String", _
           "Monto Inicial", "System.Double", _
           "Monto Final", "System.Double", _
           "Dias", "System.Int32", _
           "FechaInicio", "System.DateTime")





          

        Else
            TxtClave.Enabled = False
            dtAutoriza = ModPOS.Recupera_Tabla("sp_muestra_autorizaciones", "@SUCClave", SUCClave)
        End If


        Me.actGrid(CInt(TxtMaxHits.Text), CmbCampo.SelectedValue, "%", False)

        GridAutorizan.DataSource = dtAutoriza
        GridAutorizan.RetrieveStructure(True)
        GridAutorizan.GroupByBoxVisible = False
        GridAutorizan.RootTable.Columns("USRClave").Visible = False
        GridAutorizan.RootTable.Columns("Firma2").Visible = False
        GridAutorizan.CurrentTable.Columns("Nombre").Selectable = False



    End Sub


    Public Sub agregaSucursalProducto(ByVal sPROClave As String, ByVal sClave As String, ByVal sNombre As String, ByVal sUbicacion As String, ByVal sRotacion As String, ByVal sZona As String, ByVal dMinimo As Double, ByVal dMaximo As Double, ByVal dReorden As Double)
        Dim foundRows() As Data.DataRow
        foundRows = dtSucursalProducto.Select("PROClave = '" & sPROClave & "'")
        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtSucursalProducto.NewRow()
            'declara el nombre de la fila
            row1.Item("PROClave") = sPROClave
            row1.Item("Clave") = sClave
            row1.Item("Nombre") = sNombre
            row1.Item("Ubicación") = sUbicacion
            row1.Item("Rotación") = sRotacion
            row1.Item("Zona") = sZona
            row1.Item("Minimo") = dMinimo
            row1.Item("Maximo") = dMaximo
            row1.Item("Reorden") = dReorden
            row1.Item("Baja") = 0
            dtSucursalProducto.Rows.Add(row1)
        Else
            foundRows(0)("PROClave") = sPROClave
            foundRows(0)("Clave") = sClave
            foundRows(0)("Nombre") = sNombre
            foundRows(0)("Ubicación") = sUbicacion
            foundRows(0)("Rotación") = sRotacion
            foundRows(0)("Zona") = sZona
            foundRows(0)("Minimo") = dMinimo
            foundRows(0)("Maximo") = dMaximo
            foundRows(0)("Reorden") = dReorden
            foundRows(0)("Baja") = 0
        End If
    End Sub


    Public Sub agregaRecolector(ByVal sUSRClave As String, ByVal sClave As String, ByVal sNombre As String, ByVal iOrden As Integer)
        Dim foundRows() As Data.DataRow
        foundRows = dtRecolectores.Select("USRClave = '" & sUSRClave & "'")
        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtRecolectores.NewRow()
            'declara el nombre de la fila
            row1.Item("USRClave") = sUSRClave
            row1.Item("Clave") = sClave
            row1.Item("Nombre") = sNombre
            row1.Item("Orden") = iOrden

            row1.Item("Baja") = 0
            dtRecolectores.Rows.Add(row1)
        Else

            foundRows(0)("Orden") = iOrden

            foundRows(0)("Baja") = 0
        End If
    End Sub


    'Private Function RecuperaImpuesto(ByVal sPROClave As String, ByVal iTImpuesto As Integer) As Double

    '    Dim PrecioImp As Double = 100
    '    Dim ImpImporte As Double = 0
    '    Dim dtImpuesto As DataTable
    '    Dim i As Integer

    '    Dim PorcImp As Double = 0

    '    dtImpuesto = ModPOS.SiExisteRecupera("sp_venta_impuesto", "@PROClave", sPROClave, "@TImpuesto", iTImpuesto)
    '    If Not dtImpuesto Is Nothing AndAlso Not dtImpuesto.Rows(0)("Valor") Is DBNull.Value Then
    '        For i = 0 To dtImpuesto.Rows.Count() - 1
    '            If dtImpuesto.Rows(i)("SobreImp") Then ' Si aplica sobre impuesto
    '                If dtImpuesto.Rows(i)("TAplicacion") = 1 Then '1  = Porcentaje
    '                    ImpImporte = PrecioImp * dtImpuesto.Rows(i)("Valor")
    '                Else
    '                    ImpImporte = dtImpuesto.Rows(i)("Valor")
    '                End If
    '            Else
    '                If dtImpuesto.Rows(i)("TAplicacion") = 1 Then '1 = Porcentaje
    '                    ImpImporte = 100 * dtImpuesto.Rows(i)("Valor")
    '                Else
    '                    ImpImporte = dtImpuesto.Rows(i)("Valor")
    '                End If
    '            End If
    '            PrecioImp += ImpImporte
    '        Next
    '        dtImpuesto.Dispose()
    '        PorcImp = (PrecioImp - 100) / 100
    '    End If

    '    Return Redondear(PorcImp, 2)

    'End Function


    'Private Sub ModCosto(ByVal sPROClave As String, ByVal CostoVigente As Double, ByVal Cost As Double)
    '    Dim dNeto, PorcImp As Double
    '    Dim dtPrecios As DataTable
    '    Dim i As Integer
    '    PorcImp = RecuperaImpuesto(sPROClave, 1)

    '    dtPrecios = ModPOS.Recupera_Tabla("sp_recupera_precios_suc", "@PROClave", sPROClave, "@SUCClave", SUCClave)

    '    If Cost > CostoVigente Then
    '        For i = 0 To dtPrecios.Rows.Count - 1
    '            dtPrecios.Rows(i)("Costo") = Math.Abs(Cost)
    '            If dtPrecios.Rows(i)("Factor") = 0 Then
    '                dtPrecios.Rows(i)("Precio") = dtPrecios.Rows(i)("Costo")
    '            Else
    '                dtPrecios.Rows(i)("Precio") = Redondear(Math.Abs(Cost) * (1 + IIf(dtPrecios.Rows(i)("Factor") < 0, 1, dtPrecios.Rows(i)("Factor")) / 100), 2)
    '            End If

    '            dNeto = dtPrecios.Rows(i)("Neto")

    '            dtPrecios.Rows(i)("Neto") = Redondear(dtPrecios.Rows(i)("Precio") * (1 + PorcImp), 2)
    '            dtPrecios.Rows(i)("Minimo") = dtPrecios.Rows(i)("Minimo") + ((Redondear(dtPrecios.Rows(i)("Precio") * (1 + PorcImp), 2)) - dNeto)


    '            ModPOS.Ejecuta("sp_modifica_precio_lista", _
    '                           "@PREClave", dtPrecios.Rows(i)("PREClave"), _
    '                           "@PROClave", sPROClave, _
    '                           "@Costo", CDbl(dtPrecios.Rows(i)("Costo")), _
    '                           "@Utilidad", Math.Abs(CDbl(dtPrecios.Rows(i)("Factor") / 100)), _
    '                           "@Precio", CDbl(dtPrecios.Rows(i)("Precio")), _
    '                           "@General", dtPrecios.Rows(i)("Neto"), _
    '                           "@Minimo", dtPrecios.Rows(i)("Minimo"), _
    '                           "@Usuario", ModPOS.UsuarioActual)

    '        Next

    '    Else
    '        'Recalcula Utilidad
    '        For i = 0 To dtPrecios.Rows.Count - 1
    '            dtPrecios.Rows(i)("Costo") = Math.Abs(Cost)
    '            dtPrecios.Rows(i)("Factor") = Redondear((dtPrecios.Rows(i)("Precio") / Math.Abs(Cost)) - 1, 2) * 100

    '            ModPOS.Ejecuta("sp_modifica_precio_lista", _
    '                           "@PREClave", dtPrecios.Rows(i)("PREClave"), _
    '                           "@PROClave", sPROClave, _
    '                           "@Costo", CDbl(dtPrecios.Rows(i)("Costo")), _
    '                           "@Utilidad", Math.Abs(CDbl(dtPrecios.Rows(i)("Factor") / 100)), _
    '                           "@Precio", CDbl(dtPrecios.Rows(i)("Precio")), _
    '                           "@General", dtPrecios.Rows(i)("Neto"), _
    '                           "@Minimo", dtPrecios.Rows(i)("Minimo"), _
    '                           "@Usuario", ModPOS.UsuarioActual)

    '        Next
    '    End If




    'End Sub


    Private Sub ActualizaSucursalProducto()
        dtSucursalProducto = ModPOS.Recupera_Tabla("sp_muestra_sucursalproducto", "@SUCClave", SUCClave)

        GridProductos.DataSource = dtSucursalProducto
        GridProductos.RetrieveStructure(True)
        GridProductos.GroupByBoxVisible = False
        GridProductos.RootTable.Columns("PROClave").Visible = False
        GridProductos.RootTable.Columns("CostoVigente").Visible = False
        GridProductos.RootTable.Columns("Actualizado").Visible = False


        GridProductos.CurrentTable.Columns("Rotación").HasValueList = True
        Dim AircraftTypeValueListItemCollection As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection = GridProductos.Tables(0).Columns("Rotación").ValueList
        With AircraftTypeValueListItemCollection

            dtRotacion = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Producto", "@Campo", "Rotacion")

            Dim i As Integer

            For i = 0 To dtRotacion.Rows.Count - 1
                .Add(dtRotacion.Rows(i)("valor"), dtRotacion.Rows(i)("descripcion"))
            Next

        End With
        GridProductos.CurrentTable.Columns("Rotación").EditType = Janus.Windows.GridEX.EditType.Combo

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridProductos.RootTable.Columns("Actualizado"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)


        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridProductos.RootTable.FormatConditions.Add(fc)


    End Sub



    Public Function insertaAutorizacion( _
                ByVal USRClave As String, _
                ByVal Nombre As String, _
                ByVal Firma As String, _
                ByVal Inicial As Double, _
                ByVal Final As Double, _
                ByVal Dias As Integer, _
                ByVal FechaIni As Date) As Boolean

        Dim foundRows() As System.Data.DataRow
        foundRows = dtAutoriza.Select(" USRClave Like '" & USRClave & "'")
        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtAutoriza.NewRow()
            row1.Item("USRClave") = USRClave
            row1.Item("Nombre") = Nombre
            row1.Item("Firma") = Firma
            row1.Item("Firma2") = Firma
            row1.Item("Monto Inicial") = Inicial
            row1.Item("Monto Final") = Final
            row1.Item("Dias") = Dias
            row1.Item("FechaInicio") = FechaIni
            dtAutoriza.Rows.Add(row1)
            bCambiosAutorizacion = True
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Dim i As Integer
            Dim foundRows() As DataRow

            Select Case Me.Padre
                Case "Agregar"
                    SUCClave = ModPOS.obtenerLlave
                    Tipo = CmbTipo.SelectedValue
                    Clave = TxtClave.Text.ToUpper.Trim
                    Nombre = TxtNombre.Text.ToUpper.Trim
                    Pais = CmbPaisFac.Text.ToUpper.Trim
                    Estado = TxtEstadoFac.Text.ToUpper.Trim
                    Mnpio = TxtMunicipioFac.Text.ToUpper.Trim
                    Colonia = TxtColoniaFac.Text.ToUpper.Trim
                    Calle = TxtDomicilioFac.Text.ToUpper.Trim
                    CodigoPostal = TxtCodigoPostalFac.Text.ToUpper.Trim
                    Referencia = TxtReferenciaFac.Text.ToUpper.Trim
                    Localidad = TxtLocalidadFac.Text.ToUpper.Trim
                    noExterior = TxtNoExteriorFac.Text.ToUpper.Trim
                    noInterior = TxtNoInteriorFac.Text.ToUpper.Trim
                    Tel = TxtTel1.Text.ToUpper.Trim
                    Tel2 = TxtTel2.Text.ToUpper.Trim

                    CERClave = IIf(CmbCertificado.SelectedValue Is Nothing, "", CmbCertificado.SelectedValue)

                    Picking = CBool(ChkPicking.GetEstado)

                    Transito = CBool(ChkTransito.GetEstado)

                    Movilidad = CBool(ChkMovilidad.GetEstado)

                    Responsable = txtResponsable.Text
                    eMail = TxtCorreo.Text
                    Servidor = txtServidor.Text

                    ModPOS.Ejecuta("sp_inserta_sucursal", _
                                    "@SUCClave", SUCClave, _
                                    "@Tipo", Tipo, _
                                    "@Clave", Clave, _
                                    "@Nombre", Nombre, _
                                    "@Pais", Pais, _
                                    "@Entidad", Estado, _
                                    "@Municipio", Mnpio, _
                                    "@Colonia", Colonia, _
                                    "@Calle", Calle, _
                                    "@codigoPostal", CodigoPostal, _
                                    "@Localidad", Localidad, _
                                    "@referencia", Referencia, _
                                    "@noExterior", noExterior, _
                                    "@noInterior", noInterior, _
                                    "@Tel", Tel, _
                                    "@Tel2", Tel2, _
                                    "@CERClave", CERClave, _
                                    "@Publicidad", Icono, _
                                    "@Picking", Picking, _
                                    "@Transito", Transito, _
                                    "@Movilidad", Movilidad, _
                                    "@Responsable", Responsable, _
                                    "@eMail", eMail, _
                                    "@Servidor", Servidor, _
                                    "@Usuario", ModPOS.UsuarioActual, _
                                    "@COMClave", ModPOS.CompanyActual)


                    If Not dtAutoriza Is Nothing AndAlso dtAutoriza.Rows.Count > 0 Then
                        For i = 0 To dtAutoriza.Rows.Count - 1

                            If dtAutoriza.Rows(i)("Firma") <> dtAutoriza.Rows(i)("Firma2") Then
                                dtAutoriza.Rows(i)("Firma") = ModPOS.EncryptText(dtAutoriza.Rows(i)("Firma"), "AlpeGroup")
                                dtAutoriza.Rows(i)("Firma2") = dtAutoriza.Rows(i)("Firma")
                            End If

                            ModPOS.Ejecuta("sp_inserta_autorizacion", _
                                                  "@SUCClave", SUCClave, _
                                                  "@USRClave", dtAutoriza.Rows(i)("USRClave"), _
                                                  "@Firma", dtAutoriza.Rows(i)("Firma"), _
                                                  "@Inicio", dtAutoriza.Rows(i)("Monto Inicial"), _
                                                  "@Fin", dtAutoriza.Rows(i)("Monto Final"), _
                                                  "@Renovacion", dtAutoriza.Rows(i)("Dias"), _
                                                  "@Fecha", dtAutoriza.Rows(i)("FechaInicio"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If




                    If Not dtSucursalProducto Is Nothing AndAlso dtSucursalProducto.Rows.Count > 0 Then
                        For i = 0 To dtSucursalProducto.Rows.Count - 1
                            ModPOS.Ejecuta("sp_inserta_sucursalproducto", _
                                                  "@SUCClave", SUCClave, _
                                                  "@PROClave", dtSucursalProducto.Rows(i)("PROClave"), _
                                                  "@Minimo", dtSucursalProducto.Rows(i)("Minimo"), _
                                                  "@Maximo", dtSucursalProducto.Rows(i)("Maximo"), _
                                                  "@Reorden", dtSucursalProducto.Rows(i)("Reorden"), _
                                                  "@Rotacion", dtSucursalProducto.Rows(i)("Rotación"), _
                                                  "@Costo", dtSucursalProducto.Rows(i)("CostoVigente"), _
                                                  "@TipoImpuesto", dtSucursalProducto.Rows(i)("TipoImpuesto"), _
                                                  "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If




                    'Estrategia


                    foundRows = dtEstrategia.Select("Baja = 0")
                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_agrega_estrategia", "@Tipo", foundRows(i)("Tipo"), "@Id", foundRows(i)("id"), "@SUCClave", SUCClave, "@PROClave", foundRows(i)("PROClave"), "@ALMClave", foundRows(i)("ALMClave"), "@AREClave", foundRows(i)("AREClave"), "@ESTClave", foundRows(i)("ESTClave"), "@Zona", foundRows(i)("Zona"), "@UBCClave", foundRows(i)("UBCClave"), "@Orden", foundRows(i)("Orden"), "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    reinicializa()

                    If Not ModPOS.MtoSucursales Is Nothing Then
                        ModPOS.ActualizaGrid(False, ModPOS.MtoSucursales.GridSucursales, "sp_muestra_sucursales", "@COMClave", ModPOS.CompanyActual)
                        MtoSucursales.GridSucursales.RootTable.Columns("SUCClave").Visible = False
                    End If



                Case "Modificar"
                    If Not (Tipo = CmbTipo.SelectedValue AndAlso _
                        Nombre = TxtNombre.Text.ToUpper.Trim AndAlso _
                        Pais = CmbPaisFac.Text.ToUpper.Trim AndAlso _
                        Estado = TxtEstadoFac.Text.ToUpper.Trim AndAlso _
                        Mnpio = TxtMunicipioFac.Text.ToUpper.Trim AndAlso _
                        Colonia = TxtColoniaFac.Text.ToUpper.Trim AndAlso _
                        Calle = TxtDomicilioFac.Text.ToUpper.Trim AndAlso _
                        CodigoPostal = TxtCodigoPostalFac.Text.ToUpper.Trim AndAlso _
                        Referencia = TxtReferenciaFac.Text.ToUpper.Trim AndAlso _
                        Localidad = TxtLocalidadFac.Text.ToUpper.Trim AndAlso _
                        noExterior = TxtNoExteriorFac.Text.ToUpper.Trim AndAlso _
                        noInterior = TxtNoInteriorFac.Text.ToUpper.Trim AndAlso _
                        Tel = TxtTel1.Text.ToUpper.Trim AndAlso _
                        Tel2 = TxtTel2.Text.ToUpper.Trim AndAlso _
                        Picking = CBool(ChkPicking.GetEstado) AndAlso _
                        Transito = CBool(ChkTransito.GetEstado) AndAlso _
                        Movilidad = CBool(ChkMovilidad.GetEstado) AndAlso _
                        Responsable = txtResponsable.Text AndAlso _
                        eMail = TxtCorreo.Text AndAlso _
                        Servidor = txtServidor.Text AndAlso _
                        CERClave = IIf(CmbCertificado.SelectedValue Is Nothing, "", CmbCertificado.SelectedValue) AndAlso _
                        bCambiosAutorizacion = False AndAlso bCambiosListas = False AndAlso Not NuevoIcono) Then


                        Tipo = CmbTipo.SelectedValue
                        Nombre = TxtNombre.Text.ToUpper.Trim
                        Pais = CmbPaisFac.Text.ToUpper.Trim
                        Estado = TxtEstadoFac.Text.ToUpper.Trim
                        Mnpio = TxtMunicipioFac.Text.ToUpper.Trim
                        Colonia = TxtColoniaFac.Text.ToUpper.Trim
                        Calle = TxtDomicilioFac.Text.ToUpper.Trim
                        CodigoPostal = TxtCodigoPostalFac.Text.ToUpper.Trim
                        Referencia = TxtReferenciaFac.Text.ToUpper.Trim
                        Localidad = TxtLocalidadFac.Text.ToUpper.Trim
                        noExterior = TxtNoExteriorFac.Text.ToUpper.Trim
                        noInterior = TxtNoInteriorFac.Text.ToUpper.Trim
                        Tel = TxtTel1.Text.ToUpper.Trim
                        Tel2 = TxtTel2.Text.ToUpper.Trim
                        CERClave = IIf(CmbCertificado.SelectedValue Is Nothing, "", CmbCertificado.SelectedValue)

                        Picking = CBool(ChkPicking.GetEstado)
                        Transito = CBool(ChkTransito.GetEstado)
                        Movilidad = CBool(ChkMovilidad.GetEstado)

                        Responsable = txtResponsable.Text
                        eMail = TxtCorreo.Text
                        Servidor = txtServidor.Text



                        ModPOS.Ejecuta("sp_actualiza_sucursal", _
                                        "SUCClave", SUCClave, _
                                        "@Tipo", Tipo, _
                                        "@Nombre", Nombre, _
                                        "@Pais", Pais, _
                                        "@Entidad", Estado, _
                                        "@Municipio", Mnpio, _
                                        "@Colonia", Colonia, _
                                        "@Calle", Calle, _
                                        "@codigoPostal", CodigoPostal, _
                                        "@Localidad", Localidad, _
                                        "@referencia", Referencia, _
                                        "@noExterior", noExterior, _
                                        "@noInterior", noInterior, _
                                        "@Tel", Tel, _
                                        "@Tel2", Tel2, _
                                        "@CERClave", CERClave, _
                                        "@Publicidad", Icono, _
                                        "@Usuario", ModPOS.UsuarioActual, _
                                        "@Picking", Picking, _
                                        "@Transito", Transito, _
                                        "@Movilidad", Movilidad, _
                                        "@Responsable", Responsable, _
                                        "@eMail", eMail, _
                                        "@Servidor", Servidor, _
                                        "@COMClave", ModPOS.CompanyActual)

                        ModPOS.Ejecuta("sp_elimina_autorizacion", "@SUCClave", SUCClave)


                        If dtAutoriza.Rows.Count > 0 Then

                            For i = 0 To dtAutoriza.Rows.Count - 1

                                If dtAutoriza.Rows(i)("Firma") <> dtAutoriza.Rows(i)("Firma2") Then
                                    dtAutoriza.Rows(i)("Firma") = ModPOS.EncryptText(dtAutoriza.Rows(i)("Firma"), "AlpeGroup")
                                    dtAutoriza.Rows(i)("Firma2") = dtAutoriza.Rows(i)("Firma")
                                End If

                                ModPOS.Ejecuta("sp_inserta_autorizacion", _
                                                      "@SUCClave", SUCClave, _
                                                      "@USRClave", dtAutoriza.Rows(i)("USRClave"), _
                                                      "@Firma", dtAutoriza.Rows(i)("Firma"), _
                                                      "@Inicio", dtAutoriza.Rows(i)("Monto Inicial"), _
                                                      "@Fin", dtAutoriza.Rows(i)("Monto Final"), _
                                                      "@Renovacion", dtAutoriza.Rows(i)("Dias"), _
                                                      "@Fecha", dtAutoriza.Rows(i)("FechaInicio"), _
                                                      "@Usuario", ModPOS.UsuarioActual)
                            Next

                        End If


                        If Not ModPOS.MtoSucursales Is Nothing Then
                            ModPOS.ActualizaGrid(False, ModPOS.MtoSucursales.GridSucursales, "sp_muestra_sucursales", "@COMClave", ModPOS.CompanyActual)
                            MtoSucursales.GridSucursales.RootTable.Columns("SUCClave").Visible = False
                        End If

                    End If

                    'Sucursal Producto

                    foundRows = dtSucursalProducto.Select("Actualizado = 1")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_actualiza_sucursalproducto", _
                                                  "@SUCClave", SUCClave, _
                                                  "@PROClave", dtSucursalProducto.Rows(i)("PROClave"), _
                                                  "@Minimo", dtSucursalProducto.Rows(i)("Minimo"), _
                                                  "@Maximo", dtSucursalProducto.Rows(i)("Maximo"), _
                                                  "@Reorden", dtSucursalProducto.Rows(i)("Reorden"), _
                                                  "@Rotacion", dtSucursalProducto.Rows(i)("Rotación"), _
                                                  "@Costo", dtSucursalProducto.Rows(i)("CostoVigente"), _
                                                  "@TipoImpuesto", dtSucursalProducto.Rows(i)("TipoImpuesto"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                            'If foundRows(i)("CostoVigente") <> foundRows(i)("Costo") Then

                            '    ModCosto(foundRows(i)("PROClave"), foundRows(i)("CostoVigente"), foundRows(i)("Costo"))
                            'End If

                        Next
                    End If





                    'Estrategia


                    foundRows = dtEstrategia.Select("Baja = 1")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_estrategia", "@Id", foundRows(i)("id"))
                        Next
                    End If


                    foundRows = dtEstrategia.Select("Update=1 and Baja = 0")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_modifica_estrategia", "@Tipo", foundRows(i)("Tipo"), "@Id", foundRows(i)("id"), "@SUCClave", SUCClave, "@PROClave", foundRows(i)("PROClave"), "@ALMClave", foundRows(i)("ALMClave"), "@AREClave", foundRows(i)("AREClave"), "@ESTClave", foundRows(i)("ESTClave"), "@Zona", foundRows(i)("Zona"), "@UBCClave", foundRows(i)("UBCClave"), "@Orden", foundRows(i)("Orden"), "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    Me.Close()
            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmSucursal_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Sucursal.Dispose()
        ModPOS.Sucursal = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If ModPOS.Autoriza Is Nothing Then

            ModPOS.Autoriza = New FrmAutoriza
            With ModPOS.Autoriza

                .Text = "Agregar Autorización"
                .StartPosition = FormStartPosition.CenterScreen
            End With
        End If
        ModPOS.Autoriza.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Autoriza.Show()
        ModPOS.Autoriza.BringToFront()
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If sAutorizaSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la autorización de :" & sNombre, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtAutoriza.Select(" USRClave Like '" & sAutorizaSelected & "'")
                    dtAutoriza.Rows.Remove(foundRows(0))
                    bCambiosAutorizacion = True
            End Select
        End If
    End Sub

    Private Sub GridAutorizan_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridAutorizan.CellEdited
        Select Case GridAutorizan.CurrentColumn.Caption
            Case "Monto Inicial"
                If Not (IsNumeric(GridAutorizan.GetValue("Monto Inicial")) AndAlso CDbl(GridAutorizan.GetValue("Monto Inicial")) > 0) Then
                    GridAutorizan.SetValue("Monto Inicial", 0)
                End If

            Case "Monto Final"
                If Not (IsNumeric(GridAutorizan.GetValue("Monto Final")) AndAlso CDbl(GridAutorizan.GetValue("Monto Final")) > GridAutorizan.GetValue("Monto Inicial")) Then
                    GridAutorizan.SetValue("Monto Final", GridAutorizan.GetValue("Monto Inicial") + 1)
                End If
            Case "Dias"
                If (IsNumeric(GridAutorizan.GetValue("Dias")) AndAlso CDbl(GridAutorizan.GetValue("Dias")) < 0) Then
                    GridAutorizan.SetValue("Dias", 0)
                End If

            Case "Firma"
                If (GridAutorizan.GetValue("Firma").GetType.Name = "DBNull" OrElse (CStr(GridAutorizan.GetValue("Firma")).Length = 0 OrElse CStr(GridAutorizan.GetValue("Firma")).Length > 60)) Then
                    GridAutorizan.SetValue("Firma", GridAutorizan.GetValue("Firma2"))
                End If

            Case "Fecha Inicio"
                If GridAutorizan.GetValue("FechaInicio").GetType.Name = "DBNull" Then
                    GridAutorizan.SetValue("FechaInicio", Today.Date)
                End If

        End Select

        bCambiosAutorizacion = True
    End Sub

    Private Sub GridAutorizan_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridAutorizan.SelectionChanged
        If Not GridAutorizan.GetValue(0) Is Nothing Then
            Me.BtnEliminar.Enabled = True
            Me.sAutorizaSelected = GridAutorizan.GetValue("USRClave")
            Me.sNombre = GridAutorizan.GetValue("Nombre")
        Else
            Me.BtnEliminar.Enabled = False
            Me.sAutorizaSelected = ""
            Me.sNombre = ""
        End If
    End Sub


    Private Sub PictIcono_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictIcono.DoubleClick
        Dim curFileName As String = ""


        'buscamos la imagen a grabar
        Try
            Dim openDlg As OpenFileDialog = New OpenFileDialog
            openDlg.Filter = "Todos los archivos de JPG|*.JPG"
            Dim filter As String = openDlg.Filter
            openDlg.Title = "Abrir un Archivo JPG"
            If (openDlg.ShowDialog() = DialogResult.OK) Then
                curFileName = openDlg.FileName



                Dim fsIcono As System.IO.FileStream
                fsIcono = New System.IO.FileStream(curFileName, System.IO.FileMode.Open)
                Dim fiIcono As System.IO.FileInfo = New System.IO.FileInfo(curFileName)
                Dim Temp As Long = fiIcono.Length
                Dim lung As Long = Convert.ToInt32(Temp)
                ReDim Icono(lung)
                fsIcono.Read(Icono, 0, lung)
                fsIcono.Close()

                Me.PictIcono.Image = Image.FromFile(curFileName)

                NuevoIcono = True

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub




    Private Sub TxtEstadoFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEstadoFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtMunicipioFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMunicipioFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtLocalidadFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLocalidadFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtColoniaFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtColoniaFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtCodigoPostalFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoPostalFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtDomicilioFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDomicilioFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtNoExteriorFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNoExteriorFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtEstadoFac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEstadoFac.LostFocus
        If TxtEstadoFac.Text <> "" AndAlso TxtEstadoFac.Text <> Estado Then
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

    Private Sub TxtMunicipioFac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMunicipioFac.LostFocus
        If TxtEstadoFac.Text <> "" AndAlso TxtMunicipioFac.Text <> "" AndAlso TxtMunicipioFac.Text <> Mnpio Then
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
            If TxtLocalidadFac.Text = "" Then
                Me.TxtLocalidadFac.Text = TxtMunicipioFac.Text
            End If
        End If

    End Sub

    Private Sub TxtColoniaFac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtColoniaFac.LostFocus
        If TxtColoniaFac.Text <> "" AndAlso TxtColoniaFac.Text <> Colonia AndAlso TxtEstadoFac.Text <> "" AndAlso TxtMunicipioFac.Text <> "" AndAlso TxtMunicipioFac.Text <> Mnpio Then
            Dim dtCP As DataTable
            dtCP = ModPOS.Recupera_Tabla("sp_recupera_cp", "@Estado", TxtEstadoFac.Text.ToUpper.Trim, "@Municipio", TxtMunicipioFac.Text.Trim.ToUpper, "@Colonia", TxtColoniaFac.Text.Trim.ToUpper)
            If dtCP.Rows.Count > 0 Then
                Me.TxtCodigoPostalFac.Text = dtCP.Rows(0)("codigo_postal")
                dtCP.Dispose()
            End If
        End If

    End Sub

    Private Sub GridProductos_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridProductos.CellEdited
        Select Case GridProductos.CurrentColumn.Caption
            Case "Costo"
                If Not (IsNumeric(GridProductos.GetValue("CostoVigente")) AndAlso CDbl(GridProductos.GetValue("CostoVigente")) > 0) Then
                    GridProductos.SetValue("CostoVigente", 1)
                End If

            Case "Minimo"
                If Not (IsNumeric(GridProductos.GetValue("Minimo")) AndAlso CDbl(GridProductos.GetValue("Minimo")) >= 0) Then
                    GridProductos.SetValue("Minimo", 0)
                End If
            Case "Maximo"
                If Not (IsNumeric(GridProductos.GetValue("Maximo")) AndAlso CDbl(GridProductos.GetValue("Maximo")) >= GridProductos.GetValue("Minimo")) Then
                    GridProductos.SetValue("Maximo", GridProductos.GetValue("Minimo"))
                End If
            Case "Reorden"
                If Not (IsNumeric(GridProductos.GetValue("Reorden")) AndAlso CDbl(GridProductos.GetValue("Reorden")) >= GridProductos.GetValue("Minimo")) Then
                    GridProductos.SetValue("Reorden", GridProductos.GetValue("Minimo"))
                End If

            Case "Rotación"
                If GridProductos.GetValue("Rotación").GetType.Name = "DBNull" Then
                    GridProductos.SetValue("Rotación", 1)
                End If

            Case "TipoImpuesto"
                If GridProductos.GetValue("TipoImpuesto").GetType.Name = "DBNull" Then
                    GridProductos.SetValue("TipoImpuesto", 1)
                End If

        End Select

        GridProductos.SetValue("Actualizado", 1)
    End Sub

    Private Sub GridProductos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridProductos.CurrentCellChanged
        If Not GridProductos.CurrentColumn Is Nothing Then
            If GridProductos.CurrentColumn.Caption = "Clave" OrElse GridProductos.CurrentColumn.Caption = "Nombre" Then
                GridProductos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            Else
                GridProductos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            End If
        End If
    End Sub




    Private Sub GridProductos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridProductos.DoubleClick
        updEstrategia()
    End Sub



    Private Sub GridProductos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridProductos.SelectionChanged
        If Not GridProductos.GetValue(0) Is Nothing Then

            Me.BtnEstrategia.Enabled = True
            Me.sProductoSelected = GridProductos.GetValue("PROClave")
            Me.sClave = GridProductos.GetValue("Clave")
            Me.sProductoNombre = GridProductos.GetValue("Nombre")
        Else
            Me.BtnEstrategia.Enabled = False
            Me.sProductoSelected = ""
            Me.sClave = ""
            Me.sProductoNombre = ""
        End If
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEstrategia.Click
        updEstrategia()
    End Sub

    Private Sub BtnRestablecer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRestablecer.Click
        Select Case MessageBox.Show("Desea continuar y restablecer los valores predeterminados de cada producto y se agregaran los productos faltantes?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            Case DialogResult.Yes
                Cursor.Current = Cursors.WaitCursor
                ModPOS.Ejecuta("sp_restablecer_sucursalproducto", _
                                       "@SUCClave", SUCClave, _
                                       "@Usuario", ModPOS.UsuarioActual)

                Me.actGrid(CInt(TxtMaxHits.Text), CmbCampo.SelectedValue, "%", True)

                Cursor.Current = Cursors.Default
        End Select
    End Sub

    Private Sub TxtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
        Clock.Stop()
    End Sub

    Private Sub TxtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyUp
        Clock.Start()
    End Sub

    Private Sub Clock_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Clock.Tick
        If Not CmbCampo.SelectedValue Is Nothing Then
            Me.actGrid(CInt(TxtMaxHits.Text), CmbCampo.SelectedValue, TxtBuscar.Text, False)
        End If
    End Sub
End Class
