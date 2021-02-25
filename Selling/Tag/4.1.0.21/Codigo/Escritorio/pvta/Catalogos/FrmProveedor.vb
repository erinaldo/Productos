Public Class FrmProveedor
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
    Friend WithEvents UiTabSaldos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpSaldos As System.Windows.Forms.GroupBox
    Friend WithEvents NumDisponible As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents NumSaldo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents LblSaldo As System.Windows.Forms.Label
    Friend WithEvents LblCredito As System.Windows.Forms.Label
    Friend WithEvents GridSaldos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GrpProveedor As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDiasCredito As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents lblLimite As System.Windows.Forms.Label
    Friend WithEvents TxtLimite As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents TxtRFC As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnKey As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents TxtFechaRegistro As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaReg As System.Windows.Forms.Label
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtNombreCorto As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents GrpDomicilio As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox15 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox17 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox18 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox19 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtDomicilioFac As System.Windows.Forms.TextBox
    Friend WithEvents CmbPaisFac As Selling.StoreCombo
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GrpContacto As System.Windows.Forms.GroupBox
    Friend WithEvents LblEmail As System.Windows.Forms.Label
    Friend WithEvents LblTel2 As System.Windows.Forms.Label
    Friend WithEvents LblTel1 As System.Windows.Forms.Label
    Friend WithEvents TxtTel2 As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents TxtContacto As System.Windows.Forms.TextBox
    Friend WithEvents LblContacto As System.Windows.Forms.Label
    Friend WithEvents TxtMail As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtDiasEntrega As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmbTipo As Selling.StoreCombo
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtNoInteriorFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtNoExteriorFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoPostalFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtLocalidadFac As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtReferenciaFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtCURP As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtNoCliente As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtEstadoFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtMunicipioFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtColoniaFac As System.Windows.Forms.TextBox
    Friend WithEvents UiTabClasificaciones As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpClasificaciones As System.Windows.Forms.GroupBox
    Friend WithEvents BtnBuscaClasificacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtClasificacion As System.Windows.Forms.TextBox
    Friend WithEvents LblReferencia As System.Windows.Forms.Label
    Friend WithEvents btnDelClasificacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridClasificaciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents TxtCtaContable As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents UiTabProducto As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents grpProducto As System.Windows.Forms.GroupBox
    Friend WithEvents btnProducto As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnDelProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents gridProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents TxtTel1 As Janus.Windows.GridEX.EditControls.MaskedEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProveedor))
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabCliente = New Janus.Windows.UI.Tab.UITabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GrpDomicilio = New System.Windows.Forms.GroupBox()
        Me.TxtReferenciaFac = New System.Windows.Forms.TextBox()
        Me.PictureBox17 = New System.Windows.Forms.PictureBox()
        Me.PictureBox16 = New System.Windows.Forms.PictureBox()
        Me.TxtColoniaFac = New System.Windows.Forms.TextBox()
        Me.TxtMunicipioFac = New System.Windows.Forms.TextBox()
        Me.TxtEstadoFac = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtNoInteriorFac = New System.Windows.Forms.TextBox()
        Me.TxtNoExteriorFac = New System.Windows.Forms.TextBox()
        Me.TxtCodigoPostalFac = New System.Windows.Forms.TextBox()
        Me.TxtLocalidadFac = New System.Windows.Forms.TextBox()
        Me.PictureBox15 = New System.Windows.Forms.PictureBox()
        Me.TxtDomicilioFac = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox18 = New System.Windows.Forms.PictureBox()
        Me.PictureBox19 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmbPaisFac = New Selling.StoreCombo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GrpProveedor = New System.Windows.Forms.GroupBox()
        Me.TxtCtaContable = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtNoCliente = New System.Windows.Forms.TextBox()
        Me.TxtCURP = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CmbTipo = New Selling.StoreCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtDiasEntrega = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.PictureBox14 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtDiasCredito = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.PictureBox13 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.lblLimite = New System.Windows.Forms.Label()
        Me.TxtLimite = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.TxtRFC = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnKey = New Janus.Windows.EditControls.UIButton()
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.TxtFechaRegistro = New System.Windows.Forms.TextBox()
        Me.lblFechaReg = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtNombreCorto = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.GrpContacto = New System.Windows.Forms.GroupBox()
        Me.LblEmail = New System.Windows.Forms.Label()
        Me.LblTel2 = New System.Windows.Forms.Label()
        Me.LblTel1 = New System.Windows.Forms.Label()
        Me.TxtTel2 = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.TxtContacto = New System.Windows.Forms.TextBox()
        Me.LblContacto = New System.Windows.Forms.Label()
        Me.TxtMail = New System.Windows.Forms.TextBox()
        Me.TxtTel1 = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.UiTabSaldos = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpSaldos = New System.Windows.Forms.GroupBox()
        Me.LblSaldo = New System.Windows.Forms.Label()
        Me.NumSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.LblCredito = New System.Windows.Forms.Label()
        Me.NumDisponible = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.GridSaldos = New Janus.Windows.GridEX.GridEX()
        Me.UiTabClasificaciones = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpClasificaciones = New System.Windows.Forms.GroupBox()
        Me.BtnBuscaClasificacion = New Janus.Windows.EditControls.UIButton()
        Me.TxtClasificacion = New System.Windows.Forms.TextBox()
        Me.LblReferencia = New System.Windows.Forms.Label()
        Me.btnDelClasificacion = New Janus.Windows.EditControls.UIButton()
        Me.GridClasificaciones = New Janus.Windows.GridEX.GridEX()
        Me.UiTabProducto = New Janus.Windows.UI.Tab.UITabPage()
        Me.grpProducto = New System.Windows.Forms.GroupBox()
        Me.btnProducto = New Janus.Windows.EditControls.UIButton()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnDelProd = New Janus.Windows.EditControls.UIButton()
        Me.gridProductos = New Janus.Windows.GridEX.GridEX()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabCliente.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GrpDomicilio.SuspendLayout()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpProveedor.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpContacto.SuspendLayout()
        Me.UiTabSaldos.SuspendLayout()
        Me.GrpSaldos.SuspendLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabClasificaciones.SuspendLayout()
        Me.GrpClasificaciones.SuspendLayout()
        CType(Me.GridClasificaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabProducto.SuspendLayout()
        Me.grpProducto.SuspendLayout()
        CType(Me.gridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.UiTab1.Size = New System.Drawing.Size(642, 521)
        Me.UiTab1.TabIndex = 0
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabCliente, Me.UiTabSaldos, Me.UiTabClasificaciones, Me.UiTabProducto})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabCliente
        '
        Me.UiTabCliente.Controls.Add(Me.Panel1)
        Me.UiTabCliente.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCliente.Name = "UiTabCliente"
        Me.UiTabCliente.Size = New System.Drawing.Size(640, 499)
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
        Me.Panel1.Controls.Add(Me.GrpDomicilio)
        Me.Panel1.Controls.Add(Me.GrpProveedor)
        Me.Panel1.Controls.Add(Me.GrpContacto)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(641, 498)
        Me.Panel1.TabIndex = 1
        '
        'GrpDomicilio
        '
        Me.GrpDomicilio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDomicilio.BackColor = System.Drawing.Color.Transparent
        Me.GrpDomicilio.Controls.Add(Me.TxtReferenciaFac)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox17)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox16)
        Me.GrpDomicilio.Controls.Add(Me.TxtColoniaFac)
        Me.GrpDomicilio.Controls.Add(Me.TxtMunicipioFac)
        Me.GrpDomicilio.Controls.Add(Me.TxtEstadoFac)
        Me.GrpDomicilio.Controls.Add(Me.Label15)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox4)
        Me.GrpDomicilio.Controls.Add(Me.Label14)
        Me.GrpDomicilio.Controls.Add(Me.Label13)
        Me.GrpDomicilio.Controls.Add(Me.Label12)
        Me.GrpDomicilio.Controls.Add(Me.Label10)
        Me.GrpDomicilio.Controls.Add(Me.TxtNoInteriorFac)
        Me.GrpDomicilio.Controls.Add(Me.TxtNoExteriorFac)
        Me.GrpDomicilio.Controls.Add(Me.TxtCodigoPostalFac)
        Me.GrpDomicilio.Controls.Add(Me.TxtLocalidadFac)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox15)
        Me.GrpDomicilio.Controls.Add(Me.TxtDomicilioFac)
        Me.GrpDomicilio.Controls.Add(Me.Label3)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox18)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox19)
        Me.GrpDomicilio.Controls.Add(Me.Label5)
        Me.GrpDomicilio.Controls.Add(Me.Label6)
        Me.GrpDomicilio.Controls.Add(Me.Label7)
        Me.GrpDomicilio.Controls.Add(Me.CmbPaisFac)
        Me.GrpDomicilio.Controls.Add(Me.Label8)
        Me.GrpDomicilio.Location = New System.Drawing.Point(7, 253)
        Me.GrpDomicilio.Name = "GrpDomicilio"
        Me.GrpDomicilio.Size = New System.Drawing.Size(622, 147)
        Me.GrpDomicilio.TabIndex = 2
        Me.GrpDomicilio.TabStop = False
        Me.GrpDomicilio.Text = "Domicilio "
        '
        'TxtReferenciaFac
        '
        Me.TxtReferenciaFac.Location = New System.Drawing.Point(108, 122)
        Me.TxtReferenciaFac.Name = "TxtReferenciaFac"
        Me.TxtReferenciaFac.Size = New System.Drawing.Size(474, 20)
        Me.TxtReferenciaFac.TabIndex = 10
        '
        'PictureBox17
        '
        Me.PictureBox17.Image = CType(resources.GetObject("PictureBox17.Image"), System.Drawing.Image)
        Me.PictureBox17.Location = New System.Drawing.Point(280, 48)
        Me.PictureBox17.Name = "PictureBox17"
        Me.PictureBox17.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox17.TabIndex = 64
        Me.PictureBox17.TabStop = False
        Me.PictureBox17.Visible = False
        '
        'PictureBox16
        '
        Me.PictureBox16.Image = CType(resources.GetObject("PictureBox16.Image"), System.Drawing.Image)
        Me.PictureBox16.Location = New System.Drawing.Point(375, 74)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox16.TabIndex = 65
        Me.PictureBox16.TabStop = False
        Me.PictureBox16.Visible = False
        '
        'TxtColoniaFac
        '
        Me.TxtColoniaFac.Location = New System.Drawing.Point(108, 71)
        Me.TxtColoniaFac.Name = "TxtColoniaFac"
        Me.TxtColoniaFac.Size = New System.Drawing.Size(262, 20)
        Me.TxtColoniaFac.TabIndex = 5
        '
        'TxtMunicipioFac
        '
        Me.TxtMunicipioFac.Location = New System.Drawing.Point(108, 45)
        Me.TxtMunicipioFac.Name = "TxtMunicipioFac"
        Me.TxtMunicipioFac.Size = New System.Drawing.Size(167, 20)
        Me.TxtMunicipioFac.TabIndex = 3
        '
        'TxtEstadoFac
        '
        Me.TxtEstadoFac.Location = New System.Drawing.Point(387, 18)
        Me.TxtEstadoFac.Name = "TxtEstadoFac"
        Me.TxtEstadoFac.Size = New System.Drawing.Size(195, 20)
        Me.TxtEstadoFac.TabIndex = 2
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 124)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 15)
        Me.Label15.TabIndex = 79
        Me.Label15.Text = "Referencia"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(581, 75)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox4.TabIndex = 77
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(480, 99)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 16)
        Me.Label14.TabIndex = 76
        Me.Label14.Text = "No. Int."
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(379, 99)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 16)
        Me.Label13.TabIndex = 75
        Me.Label13.Text = "No. Ext."
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(375, 75)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 15)
        Me.Label12.TabIndex = 74
        Me.Label12.Text = "Código Postal"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(285, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 14)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "Ciudad/Población"
        '
        'TxtNoInteriorFac
        '
        Me.TxtNoInteriorFac.Location = New System.Drawing.Point(527, 96)
        Me.TxtNoInteriorFac.Name = "TxtNoInteriorFac"
        Me.TxtNoInteriorFac.Size = New System.Drawing.Size(55, 20)
        Me.TxtNoInteriorFac.TabIndex = 9
        '
        'TxtNoExteriorFac
        '
        Me.TxtNoExteriorFac.Location = New System.Drawing.Point(424, 97)
        Me.TxtNoExteriorFac.Name = "TxtNoExteriorFac"
        Me.TxtNoExteriorFac.Size = New System.Drawing.Size(55, 20)
        Me.TxtNoExteriorFac.TabIndex = 8
        '
        'TxtCodigoPostalFac
        '
        Me.TxtCodigoPostalFac.Location = New System.Drawing.Point(459, 71)
        Me.TxtCodigoPostalFac.Name = "TxtCodigoPostalFac"
        Me.TxtCodigoPostalFac.Size = New System.Drawing.Size(123, 20)
        Me.TxtCodigoPostalFac.TabIndex = 6
        '
        'TxtLocalidadFac
        '
        Me.TxtLocalidadFac.Location = New System.Drawing.Point(387, 45)
        Me.TxtLocalidadFac.Name = "TxtLocalidadFac"
        Me.TxtLocalidadFac.Size = New System.Drawing.Size(195, 20)
        Me.TxtLocalidadFac.TabIndex = 4
        '
        'PictureBox15
        '
        Me.PictureBox15.Image = CType(resources.GetObject("PictureBox15.Image"), System.Drawing.Image)
        Me.PictureBox15.Location = New System.Drawing.Point(366, 100)
        Me.PictureBox15.Name = "PictureBox15"
        Me.PictureBox15.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox15.TabIndex = 68
        Me.PictureBox15.TabStop = False
        Me.PictureBox15.Visible = False
        '
        'TxtDomicilioFac
        '
        Me.TxtDomicilioFac.Location = New System.Drawing.Point(108, 96)
        Me.TxtDomicilioFac.Name = "TxtDomicilioFac"
        Me.TxtDomicilioFac.Size = New System.Drawing.Size(255, 20)
        Me.TxtDomicilioFac.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 15)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Calle"
        '
        'PictureBox18
        '
        Me.PictureBox18.Image = CType(resources.GetObject("PictureBox18.Image"), System.Drawing.Image)
        Me.PictureBox18.Location = New System.Drawing.Point(582, 21)
        Me.PictureBox18.Name = "PictureBox18"
        Me.PictureBox18.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox18.TabIndex = 63
        Me.PictureBox18.TabStop = False
        Me.PictureBox18.Visible = False
        '
        'PictureBox19
        '
        Me.PictureBox19.Image = CType(resources.GetObject("PictureBox19.Image"), System.Drawing.Image)
        Me.PictureBox19.Location = New System.Drawing.Point(279, 22)
        Me.PictureBox19.Name = "PictureBox19"
        Me.PictureBox19.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox19.TabIndex = 62
        Me.PictureBox19.TabStop = False
        Me.PictureBox19.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 18)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Colonia"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 15)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Municipio"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(288, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 16)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Entidad/Estado"
        '
        'CmbPaisFac
        '
        Me.CmbPaisFac.Location = New System.Drawing.Point(108, 18)
        Me.CmbPaisFac.Name = "CmbPaisFac"
        Me.CmbPaisFac.Size = New System.Drawing.Size(166, 21)
        Me.CmbPaisFac.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 15)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "País"
        '
        'GrpProveedor
        '
        Me.GrpProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpProveedor.BackColor = System.Drawing.Color.Transparent
        Me.GrpProveedor.Controls.Add(Me.TxtCtaContable)
        Me.GrpProveedor.Controls.Add(Me.Label23)
        Me.GrpProveedor.Controls.Add(Me.PictureBox7)
        Me.GrpProveedor.Controls.Add(Me.Label16)
        Me.GrpProveedor.Controls.Add(Me.TxtNoCliente)
        Me.GrpProveedor.Controls.Add(Me.TxtCURP)
        Me.GrpProveedor.Controls.Add(Me.Label21)
        Me.GrpProveedor.Controls.Add(Me.PictureBox3)
        Me.GrpProveedor.Controls.Add(Me.Label9)
        Me.GrpProveedor.Controls.Add(Me.CmbTipo)
        Me.GrpProveedor.Controls.Add(Me.Label4)
        Me.GrpProveedor.Controls.Add(Me.TxtDiasEntrega)
        Me.GrpProveedor.Controls.Add(Me.PictureBox14)
        Me.GrpProveedor.Controls.Add(Me.Label2)
        Me.GrpProveedor.Controls.Add(Me.TxtDiasCredito)
        Me.GrpProveedor.Controls.Add(Me.PictureBox13)
        Me.GrpProveedor.Controls.Add(Me.Label1)
        Me.GrpProveedor.Controls.Add(Me.PictureBox6)
        Me.GrpProveedor.Controls.Add(Me.PictureBox5)
        Me.GrpProveedor.Controls.Add(Me.lblLimite)
        Me.GrpProveedor.Controls.Add(Me.TxtLimite)
        Me.GrpProveedor.Controls.Add(Me.lblRFC)
        Me.GrpProveedor.Controls.Add(Me.TxtRFC)
        Me.GrpProveedor.Controls.Add(Me.PictureBox1)
        Me.GrpProveedor.Controls.Add(Me.BtnKey)
        Me.GrpProveedor.Controls.Add(Me.ChkEstado)
        Me.GrpProveedor.Controls.Add(Me.TxtFechaRegistro)
        Me.GrpProveedor.Controls.Add(Me.lblFechaReg)
        Me.GrpProveedor.Controls.Add(Me.PictureBox2)
        Me.GrpProveedor.Controls.Add(Me.TxtRazonSocial)
        Me.GrpProveedor.Controls.Add(Me.Label11)
        Me.GrpProveedor.Controls.Add(Me.TxtNombreCorto)
        Me.GrpProveedor.Controls.Add(Me.LblNombre)
        Me.GrpProveedor.Controls.Add(Me.LblClave)
        Me.GrpProveedor.Controls.Add(Me.TxtClave)
        Me.GrpProveedor.Location = New System.Drawing.Point(7, 0)
        Me.GrpProveedor.Name = "GrpProveedor"
        Me.GrpProveedor.Size = New System.Drawing.Size(622, 247)
        Me.GrpProveedor.TabIndex = 1
        Me.GrpProveedor.TabStop = False
        Me.GrpProveedor.Text = "Proveedor"
        '
        'TxtCtaContable
        '
        Me.TxtCtaContable.Location = New System.Drawing.Point(108, 218)
        Me.TxtCtaContable.Name = "TxtCtaContable"
        Me.TxtCtaContable.Size = New System.Drawing.Size(304, 20)
        Me.TxtCtaContable.TabIndex = 83
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(9, 221)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(93, 14)
        Me.Label23.TabIndex = 84
        Me.Label23.Text = "Cta. Contable"
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(428, 218)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox7.TabIndex = 82
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(329, 76)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 15)
        Me.Label16.TabIndex = 79
        Me.Label16.Text = "No. Cliente"
        '
        'TxtNoCliente
        '
        Me.TxtNoCliente.Location = New System.Drawing.Point(419, 73)
        Me.TxtNoCliente.Name = "TxtNoCliente"
        Me.TxtNoCliente.Size = New System.Drawing.Size(153, 20)
        Me.TxtNoCliente.TabIndex = 78
        '
        'TxtCURP
        '
        Me.TxtCURP.Location = New System.Drawing.Point(108, 157)
        Me.TxtCURP.Name = "TxtCURP"
        Me.TxtCURP.Size = New System.Drawing.Size(203, 20)
        Me.TxtCURP.TabIndex = 5
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(6, 161)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 14)
        Me.Label21.TabIndex = 77
        Me.Label21.Text = "CURP"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(262, 76)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox3.TabIndex = 75
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(6, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 12)
        Me.Label9.TabIndex = 74
        Me.Label9.Text = "Tipo Impuesto"
        '
        'CmbTipo
        '
        Me.CmbTipo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipo.Location = New System.Drawing.Point(108, 72)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(153, 21)
        Me.CmbTipo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 15)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "Dias para Entrega"
        '
        'TxtDiasEntrega
        '
        Me.TxtDiasEntrega.Location = New System.Drawing.Point(191, 187)
        Me.TxtDiasEntrega.Name = "TxtDiasEntrega"
        Me.TxtDiasEntrega.Size = New System.Drawing.Size(120, 20)
        Me.TxtDiasEntrega.TabIndex = 8
        Me.TxtDiasEntrega.Text = "0"
        Me.TxtDiasEntrega.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtDiasEntrega.Value = 0
        Me.TxtDiasEntrega.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'PictureBox14
        '
        Me.PictureBox14.Image = CType(resources.GetObject("PictureBox14.Image"), System.Drawing.Image)
        Me.PictureBox14.Location = New System.Drawing.Point(575, 188)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox14.TabIndex = 65
        Me.PictureBox14.TabStop = False
        Me.PictureBox14.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(333, 190)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 15)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Dias de Crédito"
        '
        'TxtDiasCredito
        '
        Me.TxtDiasCredito.Location = New System.Drawing.Point(445, 187)
        Me.TxtDiasCredito.Name = "TxtDiasCredito"
        Me.TxtDiasCredito.Size = New System.Drawing.Size(126, 20)
        Me.TxtDiasCredito.TabIndex = 7
        Me.TxtDiasCredito.Text = "0"
        Me.TxtDiasCredito.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtDiasCredito.Value = 0
        Me.TxtDiasCredito.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'PictureBox13
        '
        Me.PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), System.Drawing.Image)
        Me.PictureBox13.Location = New System.Drawing.Point(312, 189)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox13.TabIndex = 62
        Me.PictureBox13.TabStop = False
        Me.PictureBox13.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 187)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 14)
        Me.Label1.TabIndex = 61
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(575, 157)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox6.TabIndex = 59
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(575, 127)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox5.TabIndex = 58
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'lblLimite
        '
        Me.lblLimite.Location = New System.Drawing.Point(333, 160)
        Me.lblLimite.Name = "lblLimite"
        Me.lblLimite.Size = New System.Drawing.Size(108, 15)
        Me.lblLimite.TabIndex = 57
        Me.lblLimite.Text = "Límite de Crédito"
        '
        'TxtLimite
        '
        Me.TxtLimite.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.TxtLimite.Location = New System.Drawing.Point(445, 157)
        Me.TxtLimite.Name = "TxtLimite"
        Me.TxtLimite.Size = New System.Drawing.Size(126, 20)
        Me.TxtLimite.TabIndex = 6
        Me.TxtLimite.Text = "$0.00"
        Me.TxtLimite.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtLimite.Value = 0.0R
        Me.TxtLimite.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'lblRFC
        '
        Me.lblRFC.Location = New System.Drawing.Point(333, 130)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(33, 15)
        Me.lblRFC.TabIndex = 55
        Me.lblRFC.Text = "RFC"
        '
        'TxtRFC
        '
        Me.TxtRFC.Location = New System.Drawing.Point(445, 127)
        Me.TxtRFC.Mask = "AAAA00000aaaa"
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.Size = New System.Drawing.Size(127, 20)
        Me.TxtRFC.TabIndex = 4
        Me.TxtRFC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(262, 48)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 40
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnKey
        '
        Me.BtnKey.Image = CType(resources.GetObject("BtnKey.Image"), System.Drawing.Image)
        Me.BtnKey.Location = New System.Drawing.Point(279, 45)
        Me.BtnKey.Name = "BtnKey"
        Me.BtnKey.Size = New System.Drawing.Size(26, 22)
        Me.BtnKey.TabIndex = 1
        Me.BtnKey.ToolTipText = "Generar clave automatica"
        Me.BtnKey.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Enabled = False
        Me.ChkEstado.Location = New System.Drawing.Point(519, 17)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(66, 23)
        Me.ChkEstado.TabIndex = 1
        Me.ChkEstado.Text = "Activo"
        '
        'TxtFechaRegistro
        '
        Me.TxtFechaRegistro.Location = New System.Drawing.Point(438, 45)
        Me.TxtFechaRegistro.Name = "TxtFechaRegistro"
        Me.TxtFechaRegistro.ReadOnly = True
        Me.TxtFechaRegistro.Size = New System.Drawing.Size(133, 20)
        Me.TxtFechaRegistro.TabIndex = 51
        Me.TxtFechaRegistro.TabStop = False
        '
        'lblFechaReg
        '
        Me.lblFechaReg.Location = New System.Drawing.Point(332, 45)
        Me.lblFechaReg.Name = "lblFechaReg"
        Me.lblFechaReg.Size = New System.Drawing.Size(99, 15)
        Me.lblFechaReg.TabIndex = 47
        Me.lblFechaReg.Text = "Fecha Registro"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(575, 102)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 41
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Location = New System.Drawing.Point(108, 99)
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.Size = New System.Drawing.Size(464, 20)
        Me.TxtRazonSocial.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(6, 99)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 15)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Razón Social"
        '
        'TxtNombreCorto
        '
        Me.TxtNombreCorto.Location = New System.Drawing.Point(108, 127)
        Me.TxtNombreCorto.Name = "TxtNombreCorto"
        Me.TxtNombreCorto.Size = New System.Drawing.Size(203, 20)
        Me.TxtNombreCorto.TabIndex = 3
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(6, 130)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(96, 15)
        Me.LblNombre.TabIndex = 3
        Me.LblNombre.Text = "Nombre Corto"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(6, 53)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(60, 15)
        Me.LblClave.TabIndex = 1
        Me.LblClave.Text = "Referencia"
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(108, 45)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(153, 20)
        Me.TxtClave.TabIndex = 0
        '
        'GrpContacto
        '
        Me.GrpContacto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
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
        Me.GrpContacto.Location = New System.Drawing.Point(7, 403)
        Me.GrpContacto.Name = "GrpContacto"
        Me.GrpContacto.Size = New System.Drawing.Size(622, 91)
        Me.GrpContacto.TabIndex = 4
        Me.GrpContacto.TabStop = False
        Me.GrpContacto.Text = "Contacto"
        '
        'LblEmail
        '
        Me.LblEmail.Location = New System.Drawing.Point(15, 70)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(60, 14)
        Me.LblEmail.TabIndex = 63
        Me.LblEmail.Text = "Email"
        '
        'LblTel2
        '
        Me.LblTel2.Location = New System.Drawing.Point(305, 44)
        Me.LblTel2.Name = "LblTel2"
        Me.LblTel2.Size = New System.Drawing.Size(44, 14)
        Me.LblTel2.TabIndex = 62
        Me.LblTel2.Text = "Tel/Fax"
        '
        'LblTel1
        '
        Me.LblTel1.Location = New System.Drawing.Point(14, 44)
        Me.LblTel1.Name = "LblTel1"
        Me.LblTel1.Size = New System.Drawing.Size(66, 14)
        Me.LblTel1.TabIndex = 61
        Me.LblTel1.Text = "Tel/Fax"
        '
        'TxtTel2
        '
        Me.TxtTel2.Location = New System.Drawing.Point(367, 41)
        Me.TxtTel2.Name = "TxtTel2"
        Me.TxtTel2.Size = New System.Drawing.Size(169, 20)
        Me.TxtTel2.TabIndex = 3
        Me.TxtTel2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'TxtContacto
        '
        Me.TxtContacto.Location = New System.Drawing.Point(109, 16)
        Me.TxtContacto.Name = "TxtContacto"
        Me.TxtContacto.Size = New System.Drawing.Size(427, 20)
        Me.TxtContacto.TabIndex = 1
        '
        'LblContacto
        '
        Me.LblContacto.Location = New System.Drawing.Point(14, 21)
        Me.LblContacto.Name = "LblContacto"
        Me.LblContacto.Size = New System.Drawing.Size(76, 15)
        Me.LblContacto.TabIndex = 34
        Me.LblContacto.Text = "Contacto"
        '
        'TxtMail
        '
        Me.TxtMail.Location = New System.Drawing.Point(109, 67)
        Me.TxtMail.Name = "TxtMail"
        Me.TxtMail.Size = New System.Drawing.Size(427, 20)
        Me.TxtMail.TabIndex = 4
        '
        'TxtTel1
        '
        Me.TxtTel1.Location = New System.Drawing.Point(109, 41)
        Me.TxtTel1.Name = "TxtTel1"
        Me.TxtTel1.Size = New System.Drawing.Size(153, 20)
        Me.TxtTel1.TabIndex = 2
        Me.TxtTel1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'UiTabSaldos
        '
        Me.UiTabSaldos.Controls.Add(Me.GrpSaldos)
        Me.UiTabSaldos.Location = New System.Drawing.Point(1, 21)
        Me.UiTabSaldos.Name = "UiTabSaldos"
        Me.UiTabSaldos.Size = New System.Drawing.Size(640, 499)
        Me.UiTabSaldos.TabStop = True
        Me.UiTabSaldos.Text = "Saldos"
        '
        'GrpSaldos
        '
        Me.GrpSaldos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpSaldos.BackColor = System.Drawing.Color.Transparent
        Me.GrpSaldos.Controls.Add(Me.LblSaldo)
        Me.GrpSaldos.Controls.Add(Me.NumSaldo)
        Me.GrpSaldos.Controls.Add(Me.LblCredito)
        Me.GrpSaldos.Controls.Add(Me.NumDisponible)
        Me.GrpSaldos.Controls.Add(Me.GridSaldos)
        Me.GrpSaldos.Location = New System.Drawing.Point(7, 7)
        Me.GrpSaldos.Name = "GrpSaldos"
        Me.GrpSaldos.Size = New System.Drawing.Size(624, 485)
        Me.GrpSaldos.TabIndex = 10
        Me.GrpSaldos.TabStop = False
        Me.GrpSaldos.Text = "Saldos de Facturas"
        '
        'LblSaldo
        '
        Me.LblSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSaldo.Location = New System.Drawing.Point(391, 18)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(80, 15)
        Me.LblSaldo.TabIndex = 61
        Me.LblSaldo.Text = "Total Saldo"
        '
        'NumSaldo
        '
        Me.NumSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumSaldo.Location = New System.Drawing.Point(477, 13)
        Me.NumSaldo.Name = "NumSaldo"
        Me.NumSaldo.ReadOnly = True
        Me.NumSaldo.Size = New System.Drawing.Size(134, 20)
        Me.NumSaldo.TabIndex = 60
        Me.NumSaldo.Text = "0.00"
        Me.NumSaldo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.NumSaldo.Value = 0.0R
        Me.NumSaldo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'LblCredito
        '
        Me.LblCredito.Location = New System.Drawing.Point(13, 18)
        Me.LblCredito.Name = "LblCredito"
        Me.LblCredito.Size = New System.Drawing.Size(106, 15)
        Me.LblCredito.TabIndex = 59
        Me.LblCredito.Text = "Crédito Disponible"
        '
        'NumDisponible
        '
        Me.NumDisponible.Location = New System.Drawing.Point(120, 13)
        Me.NumDisponible.Name = "NumDisponible"
        Me.NumDisponible.ReadOnly = True
        Me.NumDisponible.Size = New System.Drawing.Size(133, 20)
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
        Me.GridSaldos.Location = New System.Drawing.Point(13, 37)
        Me.GridSaldos.Name = "GridSaldos"
        Me.GridSaldos.RecordNavigator = True
        Me.GridSaldos.Size = New System.Drawing.Size(598, 432)
        Me.GridSaldos.TabIndex = 2
        Me.GridSaldos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabClasificaciones
        '
        Me.UiTabClasificaciones.Controls.Add(Me.GrpClasificaciones)
        Me.UiTabClasificaciones.Location = New System.Drawing.Point(1, 21)
        Me.UiTabClasificaciones.Name = "UiTabClasificaciones"
        Me.UiTabClasificaciones.Size = New System.Drawing.Size(640, 499)
        Me.UiTabClasificaciones.TabStop = True
        Me.UiTabClasificaciones.Text = "Clasificaciones"
        '
        'GrpClasificaciones
        '
        Me.GrpClasificaciones.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpClasificaciones.Controls.Add(Me.BtnBuscaClasificacion)
        Me.GrpClasificaciones.Controls.Add(Me.TxtClasificacion)
        Me.GrpClasificaciones.Controls.Add(Me.LblReferencia)
        Me.GrpClasificaciones.Controls.Add(Me.btnDelClasificacion)
        Me.GrpClasificaciones.Controls.Add(Me.GridClasificaciones)
        Me.GrpClasificaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpClasificaciones.Location = New System.Drawing.Point(0, 0)
        Me.GrpClasificaciones.Name = "GrpClasificaciones"
        Me.GrpClasificaciones.Size = New System.Drawing.Size(640, 499)
        Me.GrpClasificaciones.TabIndex = 13
        Me.GrpClasificaciones.TabStop = False
        Me.GrpClasificaciones.Text = "Clasificaciones de proveedor"
        '
        'BtnBuscaClasificacion
        '
        Me.BtnBuscaClasificacion.Image = CType(resources.GetObject("BtnBuscaClasificacion.Image"), System.Drawing.Image)
        Me.BtnBuscaClasificacion.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaClasificacion.Location = New System.Drawing.Point(248, 22)
        Me.BtnBuscaClasificacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscaClasificacion.Name = "BtnBuscaClasificacion"
        Me.BtnBuscaClasificacion.Size = New System.Drawing.Size(31, 30)
        Me.BtnBuscaClasificacion.TabIndex = 133
        Me.BtnBuscaClasificacion.ToolTipText = "Busqueda de Clasificación"
        Me.BtnBuscaClasificacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtClasificacion
        '
        Me.TxtClasificacion.Location = New System.Drawing.Point(88, 29)
        Me.TxtClasificacion.Name = "TxtClasificacion"
        Me.TxtClasificacion.Size = New System.Drawing.Size(154, 20)
        Me.TxtClasificacion.TabIndex = 102
        '
        'LblReferencia
        '
        Me.LblReferencia.Location = New System.Drawing.Point(13, 32)
        Me.LblReferencia.Name = "LblReferencia"
        Me.LblReferencia.Size = New System.Drawing.Size(66, 15)
        Me.LblReferencia.TabIndex = 103
        Me.LblReferencia.Text = "Referencia"
        '
        'btnDelClasificacion
        '
        Me.btnDelClasificacion.Icon = CType(resources.GetObject("btnDelClasificacion.Icon"), System.Drawing.Icon)
        Me.btnDelClasificacion.Location = New System.Drawing.Point(285, 22)
        Me.btnDelClasificacion.Name = "btnDelClasificacion"
        Me.btnDelClasificacion.Size = New System.Drawing.Size(31, 30)
        Me.btnDelClasificacion.TabIndex = 5
        Me.btnDelClasificacion.ToolTipText = "Eliminar clasificación seleccionada"
        Me.btnDelClasificacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridClasificaciones
        '
        Me.GridClasificaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridClasificaciones.ColumnAutoResize = True
        Me.GridClasificaciones.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridClasificaciones.Location = New System.Drawing.Point(10, 57)
        Me.GridClasificaciones.Name = "GridClasificaciones"
        Me.GridClasificaciones.RecordNavigator = True
        Me.GridClasificaciones.Size = New System.Drawing.Size(618, 437)
        Me.GridClasificaciones.TabIndex = 4
        Me.GridClasificaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabProducto
        '
        Me.UiTabProducto.Controls.Add(Me.grpProducto)
        Me.UiTabProducto.Location = New System.Drawing.Point(1, 21)
        Me.UiTabProducto.Name = "UiTabProducto"
        Me.UiTabProducto.Size = New System.Drawing.Size(640, 499)
        Me.UiTabProducto.TabStop = True
        Me.UiTabProducto.Text = "Productos"
        '
        'grpProducto
        '
        Me.grpProducto.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grpProducto.Controls.Add(Me.btnProducto)
        Me.grpProducto.Controls.Add(Me.txtProducto)
        Me.grpProducto.Controls.Add(Me.Label17)
        Me.grpProducto.Controls.Add(Me.btnDelProd)
        Me.grpProducto.Controls.Add(Me.gridProductos)
        Me.grpProducto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpProducto.Location = New System.Drawing.Point(0, 0)
        Me.grpProducto.Name = "grpProducto"
        Me.grpProducto.Size = New System.Drawing.Size(640, 499)
        Me.grpProducto.TabIndex = 15
        Me.grpProducto.TabStop = False
        Me.grpProducto.Text = "Productos"
        '
        'btnProducto
        '
        Me.btnProducto.Image = CType(resources.GetObject("btnProducto.Image"), System.Drawing.Image)
        Me.btnProducto.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnProducto.Location = New System.Drawing.Point(248, 22)
        Me.btnProducto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnProducto.Name = "btnProducto"
        Me.btnProducto.Size = New System.Drawing.Size(31, 30)
        Me.btnProducto.TabIndex = 133
        Me.btnProducto.ToolTipText = "Busqueda de Clasificación"
        Me.btnProducto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtProducto
        '
        Me.txtProducto.Location = New System.Drawing.Point(88, 29)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(154, 20)
        Me.txtProducto.TabIndex = 102
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(7, 34)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 15)
        Me.Label17.TabIndex = 103
        Me.Label17.Text = "Producto"
        '
        'btnDelProd
        '
        Me.btnDelProd.Icon = CType(resources.GetObject("btnDelProd.Icon"), System.Drawing.Icon)
        Me.btnDelProd.Location = New System.Drawing.Point(285, 22)
        Me.btnDelProd.Name = "btnDelProd"
        Me.btnDelProd.Size = New System.Drawing.Size(31, 30)
        Me.btnDelProd.TabIndex = 5
        Me.btnDelProd.ToolTipText = "Eliminar clasificación seleccionada"
        Me.btnDelProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gridProductos
        '
        Me.gridProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridProductos.ColumnAutoResize = True
        Me.gridProductos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.gridProductos.Location = New System.Drawing.Point(10, 57)
        Me.gridProductos.Name = "gridProductos"
        Me.gridProductos.RecordNavigator = True
        Me.gridProductos.Size = New System.Drawing.Size(618, 437)
        Me.gridProductos.TabIndex = 4
        Me.gridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(460, 524)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(557, 524)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmProveedor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(652, 567)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.UiTab1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 530)
        Me.Name = "FrmProveedor"
        Me.Text = "Proveedores"
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        Me.UiTabCliente.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GrpDomicilio.ResumeLayout(False)
        Me.GrpDomicilio.PerformLayout()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpProveedor.ResumeLayout(False)
        Me.GrpProveedor.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpContacto.ResumeLayout(False)
        Me.GrpContacto.PerformLayout()
        Me.UiTabSaldos.ResumeLayout(False)
        Me.GrpSaldos.ResumeLayout(False)
        Me.GrpSaldos.PerformLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabClasificaciones.ResumeLayout(False)
        Me.GrpClasificaciones.ResumeLayout(False)
        Me.GrpClasificaciones.PerformLayout()
        CType(Me.GridClasificaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabProducto.ResumeLayout(False)
        Me.grpProducto.ResumeLayout(False)
        Me.grpProducto.PerformLayout()
        CType(Me.gridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Publicas"

    Private aEstado() As String
    Private aMnpio() As String
    Private aColonia() As String

    Public Padre As String

    Public CtaContable As String
    Public PRVClave As String = ""
    Public Clave As String = ""
    Public FechaReg As Date = DateTime.Today
    Public NombreCorto As String = ""
    Public RazonSocial As String = ""
    Public RFC As String = ""
    Public CURP As String = ""
    Public LCredito As Double
    Public Saldo As Double
    Public Contacto As String = ""
    Public Tel1 As String = ""
    Public Tel2 As String = ""
    Public email As String = ""
    Public Estado As Integer = 1
    Public CreditoDisponible As Double
    Public TImpuesto As Integer = 1

    Public PaisF As String
    Public EstadoF As String = ""
    Public MnpioF As String = ""
    Public Localidad As String = ""
    Public Referencia As String = ""
    Public CodigoPostal As String = ""
    Public Colonia As String = ""
    Public CalleF As String = ""
    Public noExterior As String = ""
    Public noInterior As String = ""

    Public DiasCredito As Integer
    Public DiasEntrega As Integer

    Public NoCliente As String = ""
    Public FromForm As String = ""
    Public ProveedorSAP As String = ""
#End Region

#Region "Variables Privadas"

    Private DCTEClave As String = ""
    Private sDomicilio As String = ""
    Private DomicilioPadre As String = "Agregar"

    Private Cnx As String
    Private alerta(13) As PictureBox
    Private reloj As parpadea

    Private guardado As Boolean = False
    Private cargado As Boolean = False

    Private dLimite As Double
    Private iDias As Integer
    Private iDiasE As Integer

    Private DomicilioEstado As Integer
    Private Calle As String = ""

    Private dtClasificaciones, dtProductos As DataTable

#End Region

#Region "Proveedor"

    Private Sub cargaProductos()
        If Padre = "Modificar" Then

            dtProductos = ModPOS.Recupera_Tabla("st_muestra_prvprod", "@PRVClave", PRVClave)

        Else

            dtProductos = ModPOS.CrearTabla("PrvProd", _
               "PROClave", "System.String", _
               "Clave", "System.String", _
               "Nombre", "System.String", _
               "Desc", "System.Double", _
               "Activo", "System.Boolean", _
               "Update", "System.Int32", _
               "Baja", "System.Int32")

        End If


        gridProductos.DataSource = dtProductos
        gridProductos.RetrieveStructure(True)
        gridProductos.GroupByBoxVisible = False
        gridProductos.RootTable.Columns("PROClave").Visible = False
        gridProductos.RootTable.Columns("Update").Visible = False
        gridProductos.RootTable.Columns("Baja").Visible = False

        Dim fc0 As Janus.Windows.GridEX.GridEXFormatCondition
        fc0 = New Janus.Windows.GridEX.GridEXFormatCondition(gridProductos.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc0.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc0.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        gridProductos.RootTable.FormatConditions.Add(fc0)
    End Sub


    Public Sub cargaClasificaciones()
        If Padre = "Modificar" Then

            dtClasificaciones = ModPOS.Recupera_Tabla("sp_muestra_clasprv", "@PRVClave", PRVClave)

        Else

            dtClasificaciones = ModPOS.CrearTabla("ClasPrv", _
               "CLAClave", "System.Int32", _
               "Grupo", "System.String", _
               "Referencia", "System.String", _
               "Nombre", "System.String", _
               "TGrupo", "System.Int32", _
               "Update", "System.Int32", _
               "Baja", "System.Int32")

        End If

        GridClasificaciones.DataSource = dtClasificaciones
        GridClasificaciones.RetrieveStructure(True)
        GridClasificaciones.GroupByBoxVisible = False
        GridClasificaciones.RootTable.Columns("CLAClave").Visible = False
        GridClasificaciones.RootTable.Columns("TGrupo").Visible = False
        GridClasificaciones.RootTable.Columns("Update").Visible = False
        GridClasificaciones.RootTable.Columns("Baja").Visible = False

        Dim fc0 As Janus.Windows.GridEX.GridEXFormatCondition
        fc0 = New Janus.Windows.GridEX.GridEXFormatCondition(GridClasificaciones.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc0.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc0.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridClasificaciones.RootTable.FormatConditions.Add(fc0)
    End Sub

    Private Sub FrmProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)



        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox5
        alerta(3) = Me.PictureBox6
        alerta(4) = Me.PictureBox13
        alerta(5) = Me.PictureBox14
        alerta(6) = Me.PictureBox19
        alerta(7) = Me.PictureBox18
        alerta(8) = Me.PictureBox17
        alerta(9) = Me.PictureBox16
        alerta(10) = Me.PictureBox15
        alerta(11) = Me.PictureBox3
        alerta(12) = Me.PictureBox4
        alerta(13) = Me.PictureBox7


        Cnx = ModPOS.BDConexion


        With Me.CmbTipo
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Impuesto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With Me.CmbPaisFac
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Geografia"
            .NombreParametro2 = "campo"
            .Parametro2 = "Pais"
            .llenar()
        End With

        If Padre = "Modificar" Then
            BtnKey.Enabled = False
        Else
            PRVClave = obtenerLlave()
        End If

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



        CmbPaisFac.Text = PaisF

        cargado = True

        TxtClave.Text = Clave
        TxtFechaRegistro.Text = FechaReg.ToString("MMMM dd, yyyy")
        TxtNombreCorto.Text = NombreCorto
        TxtRazonSocial.Text = RazonSocial
        TxtRFC.Text = RFC
        TxtCURP.Text = CURP
        TxtLimite.Text = CStr(LCredito)
        NumSaldo.Text = CStr(Saldo)
        NumDisponible.Text = CStr(CreditoDisponible)
        TxtContacto.Text = Contacto
        TxtTel1.Text = Tel1
        TxtTel2.Text = Tel2
        TxtMail.Text = email
        ChkEstado.Estado = Estado
        TxtDiasCredito.Text = CInt(DiasCredito)
        TxtDiasEntrega.Text = CInt(DiasEntrega)
        CmbTipo.SelectedValue = TImpuesto

        TxtEstadoFac.Text = EstadoF
        TxtMunicipioFac.Text = MnpioF
        TxtColoniaFac.Text = Colonia
        TxtDomicilioFac.Text = CalleF
        TxtCodigoPostalFac.Text = CodigoPostal
        TxtReferenciaFac.Text = Referencia
        TxtLocalidadFac.Text = Localidad
        TxtNoExteriorFac.Text = noExterior
        TxtNoInteriorFac.Text = noInterior

        TxtNoCliente.Text = NoCliente
        TxtCtaContable.Text = CtaContable
        Me.cargaClasificaciones()
        cargaProductos()


        If PRVClave = Clave Then
            GrpProveedor.Enabled = False
            GrpDomicilio.Enabled = False
            GrpContacto.Enabled = False
            GrpClasificaciones.Enabled = False
            GrpSaldos.Enabled = False
        End If

    End Sub

    Public Sub reinicializa()
        PRVClave = ""
        Clave = ""
        FechaReg = DateTime.Today
        NombreCorto = ""
        RazonSocial = ""
        RFC = ""
        Contacto = ""
        Tel1 = ""
        Tel2 = ""
        email = ""
        Estado = 1
        TImpuesto = 1
        LCredito = 0
        Saldo = 0
        CreditoDisponible = 0

        Colonia = ""
        CalleF = ""
        CodigoPostal = ""
        Referencia = ""
        Localidad = ""
        noExterior = ""
        noInterior = ""
        NoCliente = ""

        TxtClave.Text = Clave
        TxtFechaRegistro.Text = FechaReg.ToString("MMMM dd, yyyy")
        TxtNombreCorto.Text = NombreCorto
        TxtRazonSocial.Text = RazonSocial
        TxtRFC.Text = RFC
        TxtLimite.Text = CStr(LCredito)
        NumSaldo.Text = CStr(Saldo)
        NumDisponible.Text = CStr(CreditoDisponible)
        TxtContacto.Text = Contacto
        TxtTel1.Text = Tel1
        TxtTel2.Text = Tel2
        TxtMail.Text = email
        ChkEstado.Estado = Estado
        TxtDiasCredito.Text = CInt(DiasCredito)
        TxtDiasEntrega.Text = CInt(DiasEntrega)
        CmbTipo.SelectedValue = TImpuesto

        CmbPaisFac.Text = PaisF
        TxtEstadoFac.Text = EstadoF
        TxtMunicipioFac.Text = MnpioF
        TxtColoniaFac.Text = Colonia
        TxtDomicilioFac.Text = CalleF
        TxtCodigoPostalFac.Text = CodigoPostal
        TxtReferenciaFac.Text = Referencia
        TxtLocalidadFac.Text = Localidad
        TxtNoExteriorFac.Text = noExterior
        TxtNoInteriorFac.Text = noInterior
        TxtNoCliente.Text = NoCliente

        TxtClave.Focus()
        Me.cargaClasificaciones()
        cargaProductos()

        Me.Panel1.VerticalScroll.Value = 0
    End Sub

    Private Sub FrmProveedor_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoProveedor Is Nothing Then
            ModPOS.MtoProveedor.actGrid("0")
            If Padre = "Agregar" Then
                ModPOS.MtoProveedor.actualizaTree(IIf(ModPOS.MtoProveedor.cmbGrupo.SelectedValue Is Nothing, 0, ModPOS.MtoProveedor.cmbGrupo.SelectedValue))
            End If
        End If
        ModPOS.Proveedor.Dispose()
        ModPOS.Proveedor = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            Dim foundRows() As System.Data.DataRow
            Dim z As Integer

            Select Case Me.Padre
                Case "Agregar"


                    Clave = TxtClave.Text.ToUpper.Trim
                    NombreCorto = TxtNombreCorto.Text.ToUpper.Trim
                    RazonSocial = TxtRazonSocial.Text.ToUpper.Trim
                    RFC = TxtRFC.Text.ToUpper.Trim
                    LCredito = dLimite
                    DiasCredito = iDias
                    DiasEntrega = iDiasE
                    TImpuesto = CmbTipo.SelectedValue
                    CURP = TxtCURP.Text.ToUpper.Trim
                    CtaContable = TxtCtaContable.Text


                    NoCliente = TxtNoCliente.Text.Trim.ToUpper

                    If LCredito = 0 Then
                        DiasCredito = 0
                    End If

                    Contacto = TxtContacto.Text.ToUpper.Trim
                    Tel1 = TxtTel1.Text.ToUpper.Trim
                    Tel2 = TxtTel2.Text.ToUpper.Trim
                    email = TxtMail.Text.ToUpper.Trim

                    PaisF = CmbPaisFac.Text.ToUpper.Trim
                    EstadoF = TxtEstadoFac.Text.ToUpper.Trim
                    MnpioF = TxtMunicipioFac.Text.ToUpper.Trim
                    Colonia = TxtColoniaFac.Text.ToUpper.Trim
                    CalleF = TxtDomicilioFac.Text.ToUpper.Trim
                    CodigoPostal = TxtCodigoPostalFac.Text.ToUpper.Trim
                    Referencia = TxtReferenciaFac.Text.ToUpper.Trim
                    Localidad = TxtLocalidadFac.Text.ToUpper.Trim
                    noExterior = TxtNoExteriorFac.Text.ToUpper.Trim
                    noInterior = TxtNoInteriorFac.Text.ToUpper.Trim



                    ModPOS.Ejecuta("sp_inserta_proveedor", _
                                        "@PRVClave", PRVClave, _
                                        "@Clave", Clave, _
                                        "@NombreCorto", NombreCorto, _
                                        "@RazonSocial", RazonSocial, _
                                        "@RFC", RFC, _
                                        "@CURP", CURP, _
                                        "@LCredito", LCredito, _
                                        "@DCredito", DiasCredito, _
                                        "@DEntrega", DiasEntrega, _
                                        "@Contacto", Contacto, _
                                        "@Tel1", Tel1, _
                                        "@Tel2", Tel2, _
                                        "@Email", email, _
                                        "@Pais", PaisF, _
                                        "@Entidad", EstadoF, _
                                        "@Municipio", MnpioF, _
                                        "@Colonia", Colonia, _
                                        "@Calle", CalleF, _
                                        "@codigoPostal", CodigoPostal, _
                                        "@Localidad", Localidad, _
                                        "@referencia", Referencia, _
                                        "@noExterior", noExterior, _
                                        "@noInterior", noInterior, _
                                        "@TImpuesto", TImpuesto, _
                                        "@NoCliente", NoCliente, _
                                        "@CtaContable", CtaContable, _
                                        "@COMClave", ModPOS.CompanyActual, _
                                        "@Usuario", ModPOS.UsuarioActual)

                    'Clasificaciones

                    foundRows = dtClasificaciones.Select(" Update = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta clasprod
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_clasprod", "@Tipo", 2, "@Class", foundRows(z)("CLAClave"), "@Producto", PRVClave, "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    foundRows = dtProductos.Select(" Update = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta clasprod
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_prvprod", "@PRVClave", PRVClave, "@PROClave", foundRows(z)("PROClave"), "@Descuento", foundRows(z)("Desc"), "@Estado", foundRows(z)("Activo"), "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


                    If FromForm = "Compra" Then
                        If Not ModPOS.Compras Is Nothing Then
                            ModPOS.Compras.CargaDatosProveedor(Clave)
                        End If
                        Me.Close()
                    ElseIf FromForm = "Orden" Then
                        If Not ModPOS.Orden Is Nothing Then
                            ModPOS.Orden.CargaDatosProveedor(Clave)
                        End If
                        Me.Close()
                    ElseIf FromForm = "Ingreso" Then
                        If Not ModPOS.Ingreso Is Nothing Then
                            ModPOS.Ingreso.CargaDatosProveedor(Clave)
                        End If
                        Me.Close()
                    Else
                        Me.reinicializa()
                    End If

                Case "Modificar"
                    Dim Limite, Dias As Double

                    Limite = dLimite
                    Dias = iDias

                    If LCredito = 0 Then
                        Dias = 0
                    End If

                    If Not ( _
                    NombreCorto = TxtNombreCorto.Text.ToUpper.Trim AndAlso _
                    RazonSocial = TxtRazonSocial.Text.ToUpper.Trim AndAlso _
                    RFC = TxtRFC.Text.ToUpper.Trim AndAlso _
                    CURP = TxtCURP.Text.ToUpper.Trim AndAlso _
                    LCredito = Limite AndAlso _
                    DiasCredito = Dias AndAlso _
                    DiasEntrega = iDiasE AndAlso _
                    Contacto = TxtContacto.Text.ToUpper.Trim AndAlso _
                    Tel1 = TxtTel1.Text.ToUpper.Trim AndAlso _
                    Tel2 = TxtTel2.Text.ToUpper.Trim AndAlso _
                    email = TxtMail.Text.ToUpper.Trim AndAlso _
                    PaisF = CmbPaisFac.Text.ToUpper.Trim AndAlso _
                    EstadoF = TxtEstadoFac.Text.ToUpper.Trim AndAlso _
                    MnpioF = TxtMunicipioFac.Text.ToUpper.Trim AndAlso _
                    Colonia = TxtColoniaFac.Text.ToUpper.Trim AndAlso _
                    CalleF = TxtDomicilioFac.Text.ToUpper.Trim AndAlso _
                    TImpuesto = CmbTipo.SelectedValue AndAlso _
                    CodigoPostal = TxtCodigoPostalFac.Text.ToUpper.Trim AndAlso _
                    Referencia = TxtReferenciaFac.Text.ToUpper.Trim AndAlso _
                    Localidad = TxtLocalidadFac.Text.ToUpper.Trim AndAlso _
                    noExterior = TxtNoExteriorFac.Text.ToUpper.Trim AndAlso _
                    noInterior = TxtNoInteriorFac.Text.ToUpper.Trim AndAlso _
                    NoCliente = TxtNoCliente.Text.Trim.ToUpper AndAlso _
                    CtaContable = TxtCtaContable.Text AndAlso _
                    Estado = Me.ChkEstado.GetEstado) Then



                        NombreCorto = TxtNombreCorto.Text.ToUpper.Trim
                        RazonSocial = TxtRazonSocial.Text.ToUpper.Trim
                        RFC = TxtRFC.Text.ToUpper.Trim
                        CURP = TxtCURP.Text.ToUpper.Trim
                        LCredito = Limite
                        DiasCredito = Dias
                        DiasEntrega = iDiasE
                        Contacto = TxtContacto.Text.ToUpper.Trim
                        Tel1 = TxtTel1.Text.ToUpper.Trim
                        Tel2 = TxtTel2.Text.ToUpper.Trim
                        email = TxtMail.Text.ToUpper.Trim
                        Estado = Me.ChkEstado.GetEstado
                        TImpuesto = CmbTipo.SelectedValue
                        NoCliente = TxtNoCliente.Text.Trim.ToUpper
                        CtaContable = TxtCtaContable.Text


                        PaisF = CmbPaisFac.Text.ToUpper.Trim
                        EstadoF = TxtEstadoFac.Text.ToUpper.Trim
                        MnpioF = TxtMunicipioFac.Text.ToUpper.Trim
                        Colonia = TxtColoniaFac.Text.ToUpper.Trim
                        CalleF = TxtDomicilioFac.Text.ToUpper.Trim
                        CodigoPostal = TxtCodigoPostalFac.Text.ToUpper.Trim
                        Referencia = TxtReferenciaFac.Text.ToUpper.Trim
                        Localidad = TxtLocalidadFac.Text.ToUpper.Trim
                        noExterior = TxtNoExteriorFac.Text.ToUpper.Trim
                        noInterior = TxtNoInteriorFac.Text.ToUpper.Trim


                        ModPOS.Ejecuta("sp_modifica_proveedor", _
                                        "@PRVClave", PRVClave, _
                                        "@NombreCorto", NombreCorto, _
                                        "@RazonSocial", RazonSocial, _
                                        "@RFC", RFC, _
                                        "@CURP", CURP, _
                                        "@LCredito", LCredito, _
                                        "@DCredito", DiasCredito, _
                                        "@DEntrega", DiasEntrega, _
                                        "@Contacto", Contacto, _
                                        "@Tel1", Tel1, _
                                        "@Tel2", Tel2, _
                                        "@Email", email, _
                                        "@Estado", Estado, _
                                        "@Pais", PaisF, _
                                        "@Entidad", EstadoF, _
                                        "@Municipio", MnpioF, _
                                        "@Colonia", Colonia, _
                                        "@Calle", CalleF, _
                                        "@codigoPostal", CodigoPostal, _
                                        "@Localidad", Localidad, _
                                        "@referencia", Referencia, _
                                        "@noExterior", noExterior, _
                                        "@noInterior", noInterior, _
                                        "@TImpuesto", TImpuesto, _
                                        "@NoCliente", NoCliente, _
                                        "@CtaContable", CtaContable, _
                                        "@Usuario", ModPOS.UsuarioActual)

                    End If

                    'Clasificaciones

                    foundRows = dtClasificaciones.Select(" Update = 1 and  Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta clasprod
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_clasprod", "@Tipo", 2, "@Class", foundRows(z)("CLAClave"), "@Producto", PRVClave, "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    foundRows = dtProductos.Select(" Update = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta clasprod
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_prvprod", "@PRVClave", PRVClave, "@PROClave", foundRows(z)("PROClave"), "@Descuento", foundRows(z)("Desc"), "@Estado", foundRows(z)("Activo"), "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


                    foundRows = dtClasificaciones.Select(" Baja = 1 ")
                    If foundRows.Length <> 0 Then
                        'inserta clasprod
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_clasprod", "@Tipo", 2, "@Class", foundRows(z)("CLAClave"), "@Producto", PRVClave)

                        Next
                    End If

                    foundRows = dtProductos.Select("  Baja = 1 ")
                    If foundRows.Length <> 0 Then
                        'inserta clasprod
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("st_elimina_prvprod", "@PRVClave", PRVClave, "@PROClave", foundRows(z)("PROClave"))
                        Next
                    End If
                    Me.Close()

            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 20 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 20)
        End If

        If Me.CmbTipo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(11))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtRazonSocial.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtRazonSocial.Text.Length > 200 Then
            Me.TxtRazonSocial.Text = Me.TxtRazonSocial.Text.Substring(0, 200)

        End If

        If Me.TxtRFC.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtRFC.Text.Length > 32 Then
            Me.TxtRFC.Text = Me.TxtRFC.Text.Substring(0, 32)
        End If

        If TxtLimite.Text = "" Then
            dLimite = 0
        Else
            dLimite = CDbl(TxtLimite.Text)
        End If

        If dLimite < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtDiasCredito.Text = "" Then
            iDias = 0
        Else
            iDias = CInt(TxtDiasCredito.Text)
        End If

        If dLimite > 0 AndAlso iDias <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If


        If TxtDiasEntrega.Text = "" Then
            iDiasE = 0
        Else
            iDiasE = CInt(TxtDiasEntrega.Text)
        End If


        If Me.CmbPaisFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtEstadoFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtMunicipioFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(8))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtColoniaFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(9))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtDomicilioFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(10))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 128 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 128)
        End If

        If Me.TxtCodigoPostalFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(12))
            reloj.Enabled = True
            reloj.Start()
        End If


        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Proveedor", "@clave", Me.TxtClave.Text.ToUpper.Trim, "@COMClave", ModPOS.CompanyActual) > 0 Then
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

#End Region


    Private Sub Ctrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClave.KeyDown, TxtNombreCorto.KeyDown, TxtRazonSocial.KeyDown, TxtRFC.KeyDown, TxtLimite.KeyDown, TxtDiasCredito.KeyDown, CmbPaisFac.KeyDown, TxtDomicilioFac.KeyDown, TxtContacto.KeyDown, TxtTel1.KeyDown, TxtTel2.KeyDown, TxtMail.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub BtnKey_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKey.Click

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "DigitoProv", "@COMClave", ModPOS.CompanyActual)
        Dim len As Integer = CInt(dt.Rows(0)("Valor"))
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_calcula_prvclave", "@len", len, "@COMClave", ModPOS.CompanyActual)

        TxtClave.Text = dt.Rows(0)("Clave")
        dt.Dispose()

        SendKeys.Send("{TAB}")

    End Sub

    Private Sub UiTab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs) Handles UiTab1.SelectedTabChanged
        Select Case e.Page.Name

            Case "UiTabSaldos"
                ModPOS.ActualizaGrid(False, Me.GridSaldos, "sp_muestra_saldos_prv", "@PRVClave", PRVClave)
        End Select

    End Sub

    Private Sub TxtEstadoFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEstadoFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub




    Private Sub TxtEstadoFac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEstadoFac.LostFocus
        If TxtEstadoFac.Text <> "" AndAlso TxtEstadoFac.Text <> EstadoF Then
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

    Private Sub TxtMunicipioFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMunicipioFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtMunicipioFac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMunicipioFac.LostFocus
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
            If TxtLocalidadFac.Text = "" Then
                Me.TxtLocalidadFac.Text = TxtMunicipioFac.Text
            End If
        End If

    End Sub

    Private Sub TxtColoniaFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtColoniaFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtColoniaFac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtColoniaFac.LostFocus
        If TxtColoniaFac.Text <> "" AndAlso TxtColoniaFac.Text <> Colonia AndAlso TxtEstadoFac.Text <> "" AndAlso TxtMunicipioFac.Text <> "" AndAlso TxtMunicipioFac.Text <> MnpioF Then
            Dim dtCP As DataTable
            dtCP = ModPOS.Recupera_Tabla("sp_recupera_cp", "@Estado", TxtEstadoFac.Text.ToUpper.Trim, "@Municipio", TxtMunicipioFac.Text.Trim.ToUpper, "@Colonia", TxtColoniaFac.Text.Trim.ToUpper)
            If dtCP.Rows.Count > 0 Then
                Me.TxtCodigoPostalFac.Text = dtCP.Rows(0)("codigo_postal")
                dtCP.Dispose()
            End If
        End If
    End Sub

    Private Sub TxtLocalidadFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLocalidadFac.KeyDown
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

    Private Sub TxtCodigoPostalFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoPostalFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CmbPaisFac_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPaisFac.SelectedIndexChanged
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

    Private Sub addProductos(ByVal PROClave As String, ByVal Clave As String, ByVal Nombre As String)

        Dim foundRows() As Data.DataRow
        foundRows = dtProductos.Select("PROClave = '" & PROClave & "' and Baja = 0 ")

        If foundRows.Length = 0 Then

            Dim row1 As DataRow
            row1 = dtProductos.NewRow()
            'declara el nombre de la fila
            row1.Item("PROClave") = PROClave
            row1.Item("Clave") = Clave
            row1.Item("Nombre") = Nombre
            row1.Item("Desc") = 0
            row1.Item("Activo") = 1
            row1.Item("Update") = 1
            row1.Item("Baja") = 0

            dtProductos.Rows.Add(row1)
            'agrega la fila completo a la tabla
        End If

    End Sub



    Private Sub AddClasificaciones(ByVal iCLAClave As Integer, ByVal sGrupo As String, ByVal sReferencia As String, ByVal sNombre As String, ByVal iGrupo As Integer)

        Dim foundRows() As Data.DataRow
        foundRows = dtClasificaciones.Select("TGrupo = " & iGrupo & " and Baja = 0 ")

        If foundRows.Length = 0 Then

            Dim row1 As DataRow
            row1 = dtClasificaciones.NewRow()
            'declara el nombre de la fila
            row1.Item("CLAClave") = iCLAClave
            row1.Item("Grupo") = sGrupo
            row1.Item("Referencia") = sReferencia
            row1.Item("Nombre") = sNombre
            row1.Item("TGrupo") = iGrupo
            row1.Item("Update") = 1
            row1.Item("Baja") = 0

            dtClasificaciones.Rows.Add(row1)
            'agrega la fila completo a la tabla
        End If

    End Sub


    Private Sub recuperaClasificacion(ByVal Clase As Integer)
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_clase", "@Clase", Clase)

        Dim iGrupo As Integer
        Dim sGrupo As String

        iGrupo = IIf(dt.Rows(0)("TGrupo").GetType.Name = "DBNull", 0, dt.Rows(0)("TGrupo"))

        Dim dtGrupo As DataTable
        dtGrupo = ModPOS.Recupera_Tabla("sp_recupera_valor", "@Tabla", "Clasificacion", "@Campo", "Grupo", "@Valor", iGrupo)

        If dtGrupo.Rows.Count > 0 Then
            sGrupo = dtGrupo.Rows(0)("Descripcion")
        Else
            sGrupo = ""
        End If

        dtGrupo.Dispose()

        Me.AddClasificaciones(CInt(dt.Rows(0)("CLAClave")), sGrupo, dt.Rows(0)("Referencia"), dt.Rows(0)("Nombre"), iGrupo)

        dt.Dispose()




    End Sub

    Private Sub BtnBuscaClasificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaClasificacion.Click
        Dim a As New MeSearchSimple
        ModPOS.ActualizaGrid(False, a.GridSearch, "sp_filtra_clasificacion", "@TClasificacion", 2, "@TGrupo", 0, "@COMClave", ModPOS.CompanyActual)
        a.GridSearch.RootTable.Columns("CLAClave").Visible = False
        a.numColValor = 0
        a.numColDescripcion = 1
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.recuperaClasificacion(a.valor)
        End If
        a.Dispose()
    End Sub

    Private Sub btnDelClasificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelClasificacion.Click
        If GridClasificaciones.Row >= 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara del proveedor actual la clasificación: " & GridClasificaciones.GetValue("Referencia"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtClasificaciones.Select("CLAClave = '" & GridClasificaciones.GetValue("CLAClave") & "'")



                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If



            End Select
        End If
    End Sub

    Private Sub TxtClasificacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClasificacion.KeyDown
        If e.KeyCode = Keys.Enter Then

            If TxtClasificacion.Text <> "" Then



                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_busca_clasificacion", "@Tipo", 2, "@Grupo", 0, "@Referencia", TxtClasificacion.Text, "@COMClave", ModPOS.CompanyActual)

                If dt.Rows.Count > 0 Then
                    Dim iGrupo As Integer
                    Dim sGrupo As String

                    iGrupo = IIf(dt.Rows(0)("TGrupo").GetType.Name = "DBNull", 0, dt.Rows(0)("TGrupo"))

                    Dim dtGrupo As DataTable
                    dtGrupo = ModPOS.Recupera_Tabla("sp_recupera_valor", "@Tabla", "Clasificacion", "@Campo", "Grupo", "@Valor", iGrupo)

                    If dtGrupo.Rows.Count > 0 Then
                        sGrupo = dtGrupo.Rows(0)("Descripcion")
                    Else
                        sGrupo = ""
                    End If

                    dtGrupo.Dispose()

                    Me.AddClasificaciones(CInt(dt.Rows(0)("CLAClave")), sGrupo, dt.Rows(0)("Referencia"), dt.Rows(0)("Nombre"), iGrupo)

                Else
                    MessageBox.Show("No se encontro clasificación de proveedor que coincida con la referencia", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                End If
                dt.Dispose()

            End If
        ElseIf e.KeyCode = Keys.Right Then
            BtnBuscaClasificacion.PerformClick()
        End If
    End Sub

    Public Sub recuperaProducto(ByVal sClave As String)

        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_compra_producto", "@COMClave", ModPOS.CompanyActual, "@Clave", sClave.Replace("'", "''"), "@Char", cReplace)
        If Not dtProducto Is Nothing Then

            addProductos(dtProducto.Rows(0)("PROClave"), _
            dtProducto.Rows(0)("Clave"), _
            dtProducto.Rows(0)("Nombre"))

            dtProducto.Dispose()
            
        Else
            MessageBox.Show("¡La Clave de producto no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub



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
            recuperaProducto(a.valor)
        End If
        a.Dispose()

    End Sub


    Private Sub txtProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProducto.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtProducto.Text.Trim <> "" Then
                recuperaProducto(txtProducto.Text.Trim.ToUpper)
            Else
                MessageBox.Show("¡Clave de producto es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

  
    Private Sub btnDelProd_Click(sender As Object, e As EventArgs) Handles btnDelProd.Click
        If gridProductos.Row >= 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara del Proveedor el  producto: " & gridProductos.GetValue("Clave"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtProductos.Select("PROClave = '" & gridProductos.GetValue("PROClave") & "'")



                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If



            End Select
        End If
    End Sub

  
    Private Sub gridProductos_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles gridProductos.CellEdited
        If gridProductos.CurrentColumn.Caption = "Desc" Then
            If IsNumeric(gridProductos.GetValue("Desc")) Then
                If gridProductos.GetValue("Desc") < 0 Then

                    Beep()
                    MessageBox.Show("¡El Descuento no puede ser menor a Cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    gridProductos.SetValue("Desc", 0)
                    gridProductos.SetValue("Update", 1)
                    dtProductos.AcceptChanges()

                    gridProductos.Refresh()
                Else
                    gridProductos.SetValue("Update", 1)
                    dtProductos.AcceptChanges()

                    gridProductos.Refresh()
                End If
            Else
                gridProductos.SetValue("Desc", 0)
                gridProductos.SetValue("Update", 1)
                dtProductos.AcceptChanges()

                gridProductos.Refresh()
            End If
        ElseIf gridProductos.CurrentColumn.Caption = "Activo" Then
            gridProductos.SetValue("Update", 1)
            dtProductos.AcceptChanges()

            gridProductos.Refresh()
        End If

    End Sub

    Private Sub gridProductos_CurrentCellChanged(sender As Object, e As EventArgs) Handles gridProductos.CurrentCellChanged
        If Not gridProductos.CurrentColumn Is Nothing Then
            If gridProductos.CurrentColumn.Caption = "Desc" OrElse gridProductos.CurrentColumn.Caption = "Activo" Then
                gridProductos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                gridProductos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub
End Class
