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
    Friend WithEvents UiTabTipoDoc As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabCompania As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabAutorizacion As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabProductos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents ChkPicking As Selling.ChkStatus
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GridProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents ChkTransito As Selling.ChkStatus
    Friend WithEvents ChkReciboRF As Selling.ChkStatus
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
    Friend WithEvents ChkSurtidoRF As Selling.ChkStatus
    Friend WithEvents UiTabTerminales As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpTerminales As System.Windows.Forms.GroupBox
    Friend WithEvents GridTerminal As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnDelTerminal As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAddTerminal As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtOficina As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents UiTabPage1 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpDocto As System.Windows.Forms.GroupBox
    Friend WithEvents GridDoctos As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnDelDocto As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAddDocto As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiTabLibro As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpLibro As System.Windows.Forms.GroupBox
    Friend WithEvents GridLibro As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnDelLibro As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAddLibro As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiTabLista As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpLista As System.Windows.Forms.GroupBox
    Friend WithEvents GridLista As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnDelLista As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAddLista As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkInventario As Selling.ChkStatus
    Friend WithEvents ChkMostradorRF As Selling.ChkStatus
    Friend WithEvents LblTPersona As System.Windows.Forms.Label
    Friend WithEvents CmbResponsable As Selling.StoreCombo
    Friend WithEvents UiTabBeneficiaria As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpBeneficiaria As System.Windows.Forms.GroupBox
    Friend WithEvents GridBeneficiarias As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnDelBeneficiaria As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAddBeneficiaria As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkUbicacionRecibo As Selling.ChkStatus
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GridCliente As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnDelCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAddCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiTabPage2 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents grpCluster As System.Windows.Forms.GroupBox
    Friend WithEvents gridCluster As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnDelCluster As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAddCluster As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkPacking As Selling.ChkStatus
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSucursal))
        Me.GrpSucursal = New System.Windows.Forms.GroupBox()
        Me.LblTPersona = New System.Windows.Forms.Label()
        Me.CmbResponsable = New Selling.StoreCombo()
        Me.txtOficina = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtServidor = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TxtCorreo = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtResponsable = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TxtLocalidadFac = New System.Windows.Forms.TextBox()
        Me.TxtCompany = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtTel2 = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.TxtColoniaFac = New System.Windows.Forms.TextBox()
        Me.TxtMunicipioFac = New System.Windows.Forms.TextBox()
        Me.TxtEstadoFac = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GrpIcono = New System.Windows.Forms.GroupBox()
        Me.PictIcono = New System.Windows.Forms.PictureBox()
        Me.CmbCertificado = New Selling.StoreCombo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblTel1 = New System.Windows.Forms.Label()
        Me.TxtTel1 = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CmbTipo = New Selling.StoreCombo()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtReferenciaFac = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtNoInteriorFac = New System.Windows.Forms.TextBox()
        Me.TxtNoExteriorFac = New System.Windows.Forms.TextBox()
        Me.TxtCodigoPostalFac = New System.Windows.Forms.TextBox()
        Me.TxtDomicilioFac = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmbPaisFac = New Selling.StoreCombo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GrpAutorizacion = New System.Windows.Forms.GroupBox()
        Me.GridAutorizan = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.BtnEliminar = New Janus.Windows.EditControls.UIButton()
        Me.UiTabTipoDoc = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabCompania = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiTabAutorizacion = New Janus.Windows.UI.Tab.UITabPage()
        Me.UiTabProductos = New Janus.Windows.UI.Tab.UITabPage()
        Me.ChkUbicacionRecibo = New Selling.ChkStatus(Me.components)
        Me.ChkInventario = New Selling.ChkStatus(Me.components)
        Me.ChkMostradorRF = New Selling.ChkStatus(Me.components)
        Me.ChkSurtidoRF = New Selling.ChkStatus(Me.components)
        Me.BtnRestablecer = New Janus.Windows.EditControls.UIButton()
        Me.ChkReciboRF = New Selling.ChkStatus(Me.components)
        Me.ChkTransito = New Selling.ChkStatus(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TxtMaxHits = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.GridProductos = New Janus.Windows.GridEX.GridEX()
        Me.CmbCampo = New Selling.StoreCombo()
        Me.ChkPicking = New Selling.ChkStatus(Me.components)
        Me.UiTabTerminales = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpTerminales = New System.Windows.Forms.GroupBox()
        Me.GridTerminal = New Janus.Windows.GridEX.GridEX()
        Me.btnDelTerminal = New Janus.Windows.EditControls.UIButton()
        Me.btnAddTerminal = New Janus.Windows.EditControls.UIButton()
        Me.UiTabPage1 = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpDocto = New System.Windows.Forms.GroupBox()
        Me.GridDoctos = New Janus.Windows.GridEX.GridEX()
        Me.btnDelDocto = New Janus.Windows.EditControls.UIButton()
        Me.BtnAddDocto = New Janus.Windows.EditControls.UIButton()
        Me.UiTabLibro = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpLibro = New System.Windows.Forms.GroupBox()
        Me.GridLibro = New Janus.Windows.GridEX.GridEX()
        Me.btnDelLibro = New Janus.Windows.EditControls.UIButton()
        Me.btnAddLibro = New Janus.Windows.EditControls.UIButton()
        Me.UiTabLista = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GridCliente = New Janus.Windows.GridEX.GridEX()
        Me.btnDelCte = New Janus.Windows.EditControls.UIButton()
        Me.btnAddCte = New Janus.Windows.EditControls.UIButton()
        Me.GrpLista = New System.Windows.Forms.GroupBox()
        Me.GridLista = New Janus.Windows.GridEX.GridEX()
        Me.btnDelLista = New Janus.Windows.EditControls.UIButton()
        Me.btnAddLista = New Janus.Windows.EditControls.UIButton()
        Me.UiTabBeneficiaria = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpBeneficiaria = New System.Windows.Forms.GroupBox()
        Me.GridBeneficiarias = New Janus.Windows.GridEX.GridEX()
        Me.BtnDelBeneficiaria = New Janus.Windows.EditControls.UIButton()
        Me.BtnAddBeneficiaria = New Janus.Windows.EditControls.UIButton()
        Me.UiTabPage2 = New Janus.Windows.UI.Tab.UITabPage()
        Me.grpCluster = New System.Windows.Forms.GroupBox()
        Me.gridCluster = New Janus.Windows.GridEX.GridEX()
        Me.btnDelCluster = New Janus.Windows.EditControls.UIButton()
        Me.btnAddCluster = New Janus.Windows.EditControls.UIButton()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.ChkPacking = New Selling.ChkStatus(Me.components)
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
        CType(Me.UiTabTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabTipoDoc.SuspendLayout()
        Me.UiTabCompania.SuspendLayout()
        Me.UiTabAutorizacion.SuspendLayout()
        Me.UiTabProductos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabTerminales.SuspendLayout()
        Me.GrpTerminales.SuspendLayout()
        CType(Me.GridTerminal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabPage1.SuspendLayout()
        Me.GrpDocto.SuspendLayout()
        CType(Me.GridDoctos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabLibro.SuspendLayout()
        Me.GrpLibro.SuspendLayout()
        CType(Me.GridLibro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabLista.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpLista.SuspendLayout()
        CType(Me.GridLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabBeneficiaria.SuspendLayout()
        Me.GrpBeneficiaria.SuspendLayout()
        CType(Me.GridBeneficiarias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabPage2.SuspendLayout()
        Me.grpCluster.SuspendLayout()
        CType(Me.gridCluster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpSucursal
        '
        Me.GrpSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpSucursal.BackColor = System.Drawing.Color.Transparent
        Me.GrpSucursal.Controls.Add(Me.LblTPersona)
        Me.GrpSucursal.Controls.Add(Me.CmbResponsable)
        Me.GrpSucursal.Controls.Add(Me.txtOficina)
        Me.GrpSucursal.Controls.Add(Me.Label20)
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
        Me.GrpSucursal.Size = New System.Drawing.Size(914, 465)
        Me.GrpSucursal.TabIndex = 4
        Me.GrpSucursal.TabStop = False
        Me.GrpSucursal.Text = "Sucursal"
        '
        'LblTPersona
        '
        Me.LblTPersona.Location = New System.Drawing.Point(436, 310)
        Me.LblTPersona.Name = "LblTPersona"
        Me.LblTPersona.Size = New System.Drawing.Size(93, 15)
        Me.LblTPersona.TabIndex = 145
        Me.LblTPersona.Text = "Responsable"
        '
        'CmbResponsable
        '
        Me.CmbResponsable.BackColor = System.Drawing.SystemColors.Window
        Me.CmbResponsable.Location = New System.Drawing.Point(550, 307)
        Me.CmbResponsable.Name = "CmbResponsable"
        Me.CmbResponsable.Size = New System.Drawing.Size(195, 21)
        Me.CmbResponsable.TabIndex = 144
        '
        'txtOficina
        '
        Me.txtOficina.Location = New System.Drawing.Point(550, 79)
        Me.txtOficina.Name = "txtOficina"
        Me.txtOficina.Size = New System.Drawing.Size(195, 20)
        Me.txtOficina.TabIndex = 142
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(437, 82)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(98, 15)
        Me.Label20.TabIndex = 143
        Me.Label20.Text = "Oficina de Ventas"
        '
        'txtServidor
        '
        Me.txtServidor.Location = New System.Drawing.Point(86, 304)
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Size = New System.Drawing.Size(254, 20)
        Me.txtServidor.TabIndex = 141
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(5, 307)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(128, 15)
        Me.Label37.TabIndex = 140
        Me.Label37.Text = "Servidor BD"
        '
        'TxtCorreo
        '
        Me.TxtCorreo.Location = New System.Drawing.Point(550, 273)
        Me.TxtCorreo.Name = "TxtCorreo"
        Me.TxtCorreo.Size = New System.Drawing.Size(195, 20)
        Me.TxtCorreo.TabIndex = 138
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(513, 276)
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
        Me.TxtCompany.Size = New System.Drawing.Size(808, 20)
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
        Me.PictureBox4.Size = New System.Drawing.Size(17, 27)
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
        Me.PictureBox2.Size = New System.Drawing.Size(23, 18)
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
        Me.GrpIcono.Size = New System.Drawing.Size(902, 126)
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
        Me.PictIcono.Size = New System.Drawing.Size(889, 100)
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
        Me.PictureBox11.Size = New System.Drawing.Size(23, 18)
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
        Me.PictureBox10.Size = New System.Drawing.Size(23, 18)
        Me.PictureBox10.TabIndex = 95
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(456, 189)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(23, 18)
        Me.PictureBox9.TabIndex = 94
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(749, 152)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(17, 27)
        Me.PictureBox8.TabIndex = 93
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(285, 161)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(23, 18)
        Me.PictureBox7.TabIndex = 92
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(749, 123)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(17, 27)
        Me.PictureBox6.TabIndex = 91
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(285, 137)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(23, 18)
        Me.PictureBox5.TabIndex = 90
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(255, 108)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(23, 18)
        Me.PictureBox3.TabIndex = 88
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(749, 53)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 18)
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
        Me.TxtTel1.Name = "TxtTel1"
        Me.TxtTel1.Size = New System.Drawing.Size(127, 20)
        Me.TxtTel1.TabIndex = 12
        Me.TxtTel1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(500, 55)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 12)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "Tipo"
        '
        'CmbTipo
        '
        Me.CmbTipo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipo.Location = New System.Drawing.Point(550, 52)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(193, 21)
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
        'UiTabTipoDoc
        '
        Me.UiTabTipoDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabTipoDoc.BackColor = System.Drawing.Color.Transparent
        Me.UiTabTipoDoc.Location = New System.Drawing.Point(3, 4)
        Me.UiTabTipoDoc.Name = "UiTabTipoDoc"
        Me.UiTabTipoDoc.Size = New System.Drawing.Size(925, 506)
        Me.UiTabTipoDoc.TabIndex = 20
        Me.UiTabTipoDoc.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabCompania, Me.UiTabAutorizacion, Me.UiTabProductos, Me.UiTabTerminales, Me.UiTabPage1, Me.UiTabLibro, Me.UiTabLista, Me.UiTabBeneficiaria, Me.UiTabPage2})
        Me.UiTabTipoDoc.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabCompania
        '
        Me.UiTabCompania.Controls.Add(Me.GrpSucursal)
        Me.UiTabCompania.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCompania.Name = "UiTabCompania"
        Me.UiTabCompania.Size = New System.Drawing.Size(923, 484)
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
        'UiTabProductos
        '
        Me.UiTabProductos.Controls.Add(Me.ChkPacking)
        Me.UiTabProductos.Controls.Add(Me.ChkUbicacionRecibo)
        Me.UiTabProductos.Controls.Add(Me.ChkInventario)
        Me.UiTabProductos.Controls.Add(Me.ChkMostradorRF)
        Me.UiTabProductos.Controls.Add(Me.ChkSurtidoRF)
        Me.UiTabProductos.Controls.Add(Me.BtnRestablecer)
        Me.UiTabProductos.Controls.Add(Me.ChkReciboRF)
        Me.UiTabProductos.Controls.Add(Me.ChkTransito)
        Me.UiTabProductos.Controls.Add(Me.GroupBox2)
        Me.UiTabProductos.Controls.Add(Me.ChkPicking)
        Me.UiTabProductos.Location = New System.Drawing.Point(1, 21)
        Me.UiTabProductos.Name = "UiTabProductos"
        Me.UiTabProductos.Size = New System.Drawing.Size(923, 484)
        Me.UiTabProductos.TabStop = True
        Me.UiTabProductos.Text = "Productos"
        '
        'ChkUbicacionRecibo
        '
        Me.ChkUbicacionRecibo.BackColor = System.Drawing.Color.Transparent
        Me.ChkUbicacionRecibo.Location = New System.Drawing.Point(330, 36)
        Me.ChkUbicacionRecibo.Name = "ChkUbicacionRecibo"
        Me.ChkUbicacionRecibo.Size = New System.Drawing.Size(171, 22)
        Me.ChkUbicacionRecibo.TabIndex = 146
        Me.ChkUbicacionRecibo.Text = "Crear Ubicación Recibo"
        Me.ChkUbicacionRecibo.UseVisualStyleBackColor = False
        '
        'ChkInventario
        '
        Me.ChkInventario.BackColor = System.Drawing.Color.Transparent
        Me.ChkInventario.Location = New System.Drawing.Point(330, 17)
        Me.ChkInventario.Name = "ChkInventario"
        Me.ChkInventario.Size = New System.Drawing.Size(129, 22)
        Me.ChkInventario.TabIndex = 145
        Me.ChkInventario.Text = "Valida Inventario"
        Me.ChkInventario.UseVisualStyleBackColor = False
        '
        'ChkMostradorRF
        '
        Me.ChkMostradorRF.BackColor = System.Drawing.Color.Transparent
        Me.ChkMostradorRF.Location = New System.Drawing.Point(222, 36)
        Me.ChkMostradorRF.Name = "ChkMostradorRF"
        Me.ChkMostradorRF.Size = New System.Drawing.Size(115, 22)
        Me.ChkMostradorRF.TabIndex = 144
        Me.ChkMostradorRF.Text = "Mostrador RF"
        Me.ChkMostradorRF.UseVisualStyleBackColor = False
        '
        'ChkSurtidoRF
        '
        Me.ChkSurtidoRF.BackColor = System.Drawing.Color.Transparent
        Me.ChkSurtidoRF.Location = New System.Drawing.Point(222, 17)
        Me.ChkSurtidoRF.Name = "ChkSurtidoRF"
        Me.ChkSurtidoRF.Size = New System.Drawing.Size(91, 22)
        Me.ChkSurtidoRF.TabIndex = 143
        Me.ChkSurtidoRF.Text = "Surtido RF"
        Me.ChkSurtidoRF.UseVisualStyleBackColor = False
        '
        'BtnRestablecer
        '
        Me.BtnRestablecer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRestablecer.Icon = CType(resources.GetObject("BtnRestablecer.Icon"), System.Drawing.Icon)
        Me.BtnRestablecer.Location = New System.Drawing.Point(789, 9)
        Me.BtnRestablecer.Name = "BtnRestablecer"
        Me.BtnRestablecer.Size = New System.Drawing.Size(131, 30)
        Me.BtnRestablecer.TabIndex = 142
        Me.BtnRestablecer.Text = "Restablecer"
        Me.BtnRestablecer.ToolTipText = "Agrega los productos faltantes a la sucursal y restablece los valores predetermin" & _
    "ados de los productos actuales."
        Me.BtnRestablecer.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkReciboRF
        '
        Me.ChkReciboRF.BackColor = System.Drawing.Color.Transparent
        Me.ChkReciboRF.Location = New System.Drawing.Point(92, 36)
        Me.ChkReciboRF.Name = "ChkReciboRF"
        Me.ChkReciboRF.Size = New System.Drawing.Size(91, 22)
        Me.ChkReciboRF.TabIndex = 141
        Me.ChkReciboRF.Text = "Recibo RF"
        Me.ChkReciboRF.UseVisualStyleBackColor = False
        '
        'ChkTransito
        '
        Me.ChkTransito.BackColor = System.Drawing.Color.Transparent
        Me.ChkTransito.Checked = True
        Me.ChkTransito.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkTransito.Location = New System.Drawing.Point(92, 17)
        Me.ChkTransito.Name = "ChkTransito"
        Me.ChkTransito.Size = New System.Drawing.Size(166, 22)
        Me.ChkTransito.TabIndex = 140
        Me.ChkTransito.Text = "Confirmar Transito"
        Me.ChkTransito.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.TxtMaxHits)
        Me.GroupBox2.Controls.Add(Me.TxtBuscar)
        Me.GroupBox2.Controls.Add(Me.GridProductos)
        Me.GroupBox2.Controls.Add(Me.CmbCampo)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(918, 417)
        Me.GroupBox2.TabIndex = 138
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Productos"
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(721, 23)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(99, 13)
        Me.Label19.TabIndex = 154
        Me.Label19.Text = "Max. Coincidencias"
        '
        'TxtMaxHits
        '
        Me.TxtMaxHits.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMaxHits.DecimalDigits = 0
        Me.TxtMaxHits.Location = New System.Drawing.Point(858, 19)
        Me.TxtMaxHits.Name = "TxtMaxHits"
        Me.TxtMaxHits.Size = New System.Drawing.Size(55, 20)
        Me.TxtMaxHits.TabIndex = 153
        Me.TxtMaxHits.Text = "1,000"
        Me.TxtMaxHits.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Me.TxtMaxHits.Value = 1000
        Me.TxtMaxHits.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
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
        Me.GridProductos.Size = New System.Drawing.Size(906, 364)
        Me.GridProductos.TabIndex = 1
        Me.GridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(7, 19)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(166, 21)
        Me.CmbCampo.TabIndex = 152
        '
        'ChkPicking
        '
        Me.ChkPicking.BackColor = System.Drawing.Color.Transparent
        Me.ChkPicking.Checked = True
        Me.ChkPicking.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPicking.Location = New System.Drawing.Point(9, 17)
        Me.ChkPicking.Name = "ChkPicking"
        Me.ChkPicking.Size = New System.Drawing.Size(91, 22)
        Me.ChkPicking.TabIndex = 137
        Me.ChkPicking.Text = "Picking"
        Me.ChkPicking.UseVisualStyleBackColor = False
        '
        'UiTabTerminales
        '
        Me.UiTabTerminales.Controls.Add(Me.GrpTerminales)
        Me.UiTabTerminales.Controls.Add(Me.btnDelTerminal)
        Me.UiTabTerminales.Controls.Add(Me.btnAddTerminal)
        Me.UiTabTerminales.Location = New System.Drawing.Point(1, 21)
        Me.UiTabTerminales.Name = "UiTabTerminales"
        Me.UiTabTerminales.Size = New System.Drawing.Size(923, 484)
        Me.UiTabTerminales.TabStop = True
        Me.UiTabTerminales.Text = "Terminales de Cobro"
        '
        'GrpTerminales
        '
        Me.GrpTerminales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpTerminales.BackColor = System.Drawing.Color.Transparent
        Me.GrpTerminales.Controls.Add(Me.GridTerminal)
        Me.GrpTerminales.Location = New System.Drawing.Point(2, 37)
        Me.GrpTerminales.Name = "GrpTerminales"
        Me.GrpTerminales.Size = New System.Drawing.Size(918, 442)
        Me.GrpTerminales.TabIndex = 8
        Me.GrpTerminales.TabStop = False
        Me.GrpTerminales.Text = "Terminales"
        '
        'GridTerminal
        '
        Me.GridTerminal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridTerminal.ColumnAutoResize = True
        Me.GridTerminal.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridTerminal.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridTerminal.GroupByBoxVisible = False
        Me.GridTerminal.Location = New System.Drawing.Point(7, 15)
        Me.GridTerminal.Name = "GridTerminal"
        Me.GridTerminal.RecordNavigator = True
        Me.GridTerminal.Size = New System.Drawing.Size(906, 420)
        Me.GridTerminal.TabIndex = 1
        Me.GridTerminal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnDelTerminal
        '
        Me.btnDelTerminal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelTerminal.Icon = CType(resources.GetObject("btnDelTerminal.Icon"), System.Drawing.Icon)
        Me.btnDelTerminal.Location = New System.Drawing.Point(784, 5)
        Me.btnDelTerminal.Name = "btnDelTerminal"
        Me.btnDelTerminal.Size = New System.Drawing.Size(62, 30)
        Me.btnDelTerminal.TabIndex = 7
        Me.btnDelTerminal.ToolTipText = "Elimina terminal de cobro seleccionada"
        Me.btnDelTerminal.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAddTerminal
        '
        Me.btnAddTerminal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddTerminal.Icon = CType(resources.GetObject("btnAddTerminal.Icon"), System.Drawing.Icon)
        Me.btnAddTerminal.Location = New System.Drawing.Point(852, 5)
        Me.btnAddTerminal.Name = "btnAddTerminal"
        Me.btnAddTerminal.Size = New System.Drawing.Size(63, 30)
        Me.btnAddTerminal.TabIndex = 6
        Me.btnAddTerminal.ToolTipText = "Agrega nueva terminal de cobro"
        Me.btnAddTerminal.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTabPage1
        '
        Me.UiTabPage1.Controls.Add(Me.GrpDocto)
        Me.UiTabPage1.Controls.Add(Me.btnDelDocto)
        Me.UiTabPage1.Controls.Add(Me.BtnAddDocto)
        Me.UiTabPage1.Location = New System.Drawing.Point(1, 21)
        Me.UiTabPage1.Name = "UiTabPage1"
        Me.UiTabPage1.Size = New System.Drawing.Size(923, 484)
        Me.UiTabPage1.TabStop = True
        Me.UiTabPage1.Text = "Clases de Documento"
        '
        'GrpDocto
        '
        Me.GrpDocto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDocto.BackColor = System.Drawing.Color.Transparent
        Me.GrpDocto.Controls.Add(Me.GridDoctos)
        Me.GrpDocto.Location = New System.Drawing.Point(2, 37)
        Me.GrpDocto.Name = "GrpDocto"
        Me.GrpDocto.Size = New System.Drawing.Size(918, 442)
        Me.GrpDocto.TabIndex = 11
        Me.GrpDocto.TabStop = False
        Me.GrpDocto.Text = "Clases"
        '
        'GridDoctos
        '
        Me.GridDoctos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDoctos.ColumnAutoResize = True
        Me.GridDoctos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDoctos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDoctos.GroupByBoxVisible = False
        Me.GridDoctos.Location = New System.Drawing.Point(7, 15)
        Me.GridDoctos.Name = "GridDoctos"
        Me.GridDoctos.RecordNavigator = True
        Me.GridDoctos.Size = New System.Drawing.Size(906, 420)
        Me.GridDoctos.TabIndex = 1
        Me.GridDoctos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnDelDocto
        '
        Me.btnDelDocto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelDocto.Icon = CType(resources.GetObject("btnDelDocto.Icon"), System.Drawing.Icon)
        Me.btnDelDocto.Location = New System.Drawing.Point(784, 5)
        Me.btnDelDocto.Name = "btnDelDocto"
        Me.btnDelDocto.Size = New System.Drawing.Size(62, 30)
        Me.btnDelDocto.TabIndex = 10
        Me.btnDelDocto.ToolTipText = "Elimina clase de documento seleccionada"
        Me.btnDelDocto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAddDocto
        '
        Me.BtnAddDocto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddDocto.Icon = CType(resources.GetObject("BtnAddDocto.Icon"), System.Drawing.Icon)
        Me.BtnAddDocto.Location = New System.Drawing.Point(852, 5)
        Me.BtnAddDocto.Name = "BtnAddDocto"
        Me.BtnAddDocto.Size = New System.Drawing.Size(63, 30)
        Me.BtnAddDocto.TabIndex = 9
        Me.BtnAddDocto.ToolTipText = "Agrega nueva clase de documento"
        Me.BtnAddDocto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTabLibro
        '
        Me.UiTabLibro.Controls.Add(Me.GrpLibro)
        Me.UiTabLibro.Controls.Add(Me.btnDelLibro)
        Me.UiTabLibro.Controls.Add(Me.btnAddLibro)
        Me.UiTabLibro.Location = New System.Drawing.Point(1, 21)
        Me.UiTabLibro.Name = "UiTabLibro"
        Me.UiTabLibro.Size = New System.Drawing.Size(923, 484)
        Me.UiTabLibro.TabStop = True
        Me.UiTabLibro.Text = "Libros Contables"
        '
        'GrpLibro
        '
        Me.GrpLibro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpLibro.BackColor = System.Drawing.Color.Transparent
        Me.GrpLibro.Controls.Add(Me.GridLibro)
        Me.GrpLibro.Location = New System.Drawing.Point(2, 37)
        Me.GrpLibro.Name = "GrpLibro"
        Me.GrpLibro.Size = New System.Drawing.Size(918, 442)
        Me.GrpLibro.TabIndex = 11
        Me.GrpLibro.TabStop = False
        Me.GrpLibro.Text = "Libros"
        '
        'GridLibro
        '
        Me.GridLibro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridLibro.ColumnAutoResize = True
        Me.GridLibro.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridLibro.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridLibro.GroupByBoxVisible = False
        Me.GridLibro.Location = New System.Drawing.Point(7, 15)
        Me.GridLibro.Name = "GridLibro"
        Me.GridLibro.RecordNavigator = True
        Me.GridLibro.Size = New System.Drawing.Size(906, 420)
        Me.GridLibro.TabIndex = 1
        Me.GridLibro.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnDelLibro
        '
        Me.btnDelLibro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelLibro.Icon = CType(resources.GetObject("btnDelLibro.Icon"), System.Drawing.Icon)
        Me.btnDelLibro.Location = New System.Drawing.Point(784, 5)
        Me.btnDelLibro.Name = "btnDelLibro"
        Me.btnDelLibro.Size = New System.Drawing.Size(62, 30)
        Me.btnDelLibro.TabIndex = 10
        Me.btnDelLibro.ToolTipText = "Elimina terminal de cobro seleccionada"
        Me.btnDelLibro.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAddLibro
        '
        Me.btnAddLibro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddLibro.Icon = CType(resources.GetObject("btnAddLibro.Icon"), System.Drawing.Icon)
        Me.btnAddLibro.Location = New System.Drawing.Point(852, 5)
        Me.btnAddLibro.Name = "btnAddLibro"
        Me.btnAddLibro.Size = New System.Drawing.Size(63, 30)
        Me.btnAddLibro.TabIndex = 9
        Me.btnAddLibro.ToolTipText = "Agrega nueva terminal de cobro"
        Me.btnAddLibro.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTabLista
        '
        Me.UiTabLista.Controls.Add(Me.GroupBox1)
        Me.UiTabLista.Controls.Add(Me.btnDelCte)
        Me.UiTabLista.Controls.Add(Me.btnAddCte)
        Me.UiTabLista.Controls.Add(Me.GrpLista)
        Me.UiTabLista.Controls.Add(Me.btnDelLista)
        Me.UiTabLista.Controls.Add(Me.btnAddLista)
        Me.UiTabLista.Location = New System.Drawing.Point(1, 21)
        Me.UiTabLista.Name = "UiTabLista"
        Me.UiTabLista.Size = New System.Drawing.Size(923, 484)
        Me.UiTabLista.TabStop = True
        Me.UiTabLista.Text = "Excepción de Lista de Precios"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.GridCliente)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 263)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(918, 218)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Clientes"
        '
        'GridCliente
        '
        Me.GridCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCliente.AutoEdit = True
        Me.GridCliente.ColumnAutoResize = True
        Me.GridCliente.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCliente.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCliente.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridCliente.GroupByBoxVisible = False
        Me.GridCliente.Location = New System.Drawing.Point(7, 15)
        Me.GridCliente.Name = "GridCliente"
        Me.GridCliente.RecordNavigator = True
        Me.GridCliente.Size = New System.Drawing.Size(906, 196)
        Me.GridCliente.TabIndex = 1
        Me.GridCliente.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnDelCte
        '
        Me.btnDelCte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelCte.Icon = CType(resources.GetObject("btnDelCte.Icon"), System.Drawing.Icon)
        Me.btnDelCte.Location = New System.Drawing.Point(784, 231)
        Me.btnDelCte.Name = "btnDelCte"
        Me.btnDelCte.Size = New System.Drawing.Size(62, 30)
        Me.btnDelCte.TabIndex = 16
        Me.btnDelCte.ToolTipText = "Elimina excepción  de cliente seleccionada"
        Me.btnDelCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAddCte
        '
        Me.btnAddCte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddCte.Icon = CType(resources.GetObject("btnAddCte.Icon"), System.Drawing.Icon)
        Me.btnAddCte.Location = New System.Drawing.Point(852, 231)
        Me.btnAddCte.Name = "btnAddCte"
        Me.btnAddCte.Size = New System.Drawing.Size(63, 30)
        Me.btnAddCte.TabIndex = 15
        Me.btnAddCte.ToolTipText = "Agrega excepción de cliente"
        Me.btnAddCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpLista
        '
        Me.GrpLista.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpLista.BackColor = System.Drawing.Color.Transparent
        Me.GrpLista.Controls.Add(Me.GridLista)
        Me.GrpLista.Location = New System.Drawing.Point(2, 37)
        Me.GrpLista.Name = "GrpLista"
        Me.GrpLista.Size = New System.Drawing.Size(918, 191)
        Me.GrpLista.TabIndex = 14
        Me.GrpLista.TabStop = False
        Me.GrpLista.Text = "Listas"
        '
        'GridLista
        '
        Me.GridLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridLista.ColumnAutoResize = True
        Me.GridLista.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridLista.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridLista.GroupByBoxVisible = False
        Me.GridLista.Location = New System.Drawing.Point(7, 15)
        Me.GridLista.Name = "GridLista"
        Me.GridLista.RecordNavigator = True
        Me.GridLista.Size = New System.Drawing.Size(906, 169)
        Me.GridLista.TabIndex = 1
        Me.GridLista.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnDelLista
        '
        Me.btnDelLista.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelLista.Icon = CType(resources.GetObject("btnDelLista.Icon"), System.Drawing.Icon)
        Me.btnDelLista.Location = New System.Drawing.Point(784, 5)
        Me.btnDelLista.Name = "btnDelLista"
        Me.btnDelLista.Size = New System.Drawing.Size(62, 30)
        Me.btnDelLista.TabIndex = 13
        Me.btnDelLista.ToolTipText = "Elimina la excepción de lista seleccionada"
        Me.btnDelLista.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAddLista
        '
        Me.btnAddLista.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddLista.Icon = CType(resources.GetObject("btnAddLista.Icon"), System.Drawing.Icon)
        Me.btnAddLista.Location = New System.Drawing.Point(852, 5)
        Me.btnAddLista.Name = "btnAddLista"
        Me.btnAddLista.Size = New System.Drawing.Size(63, 30)
        Me.btnAddLista.TabIndex = 12
        Me.btnAddLista.ToolTipText = "Agrega nueva excepción de lista"
        Me.btnAddLista.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTabBeneficiaria
        '
        Me.UiTabBeneficiaria.Controls.Add(Me.GrpBeneficiaria)
        Me.UiTabBeneficiaria.Controls.Add(Me.BtnDelBeneficiaria)
        Me.UiTabBeneficiaria.Controls.Add(Me.BtnAddBeneficiaria)
        Me.UiTabBeneficiaria.Location = New System.Drawing.Point(1, 21)
        Me.UiTabBeneficiaria.Name = "UiTabBeneficiaria"
        Me.UiTabBeneficiaria.Size = New System.Drawing.Size(923, 484)
        Me.UiTabBeneficiaria.TabStop = True
        Me.UiTabBeneficiaria.Text = "Cuentas Beneficiarias"
        '
        'GrpBeneficiaria
        '
        Me.GrpBeneficiaria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpBeneficiaria.BackColor = System.Drawing.Color.Transparent
        Me.GrpBeneficiaria.Controls.Add(Me.GridBeneficiarias)
        Me.GrpBeneficiaria.Location = New System.Drawing.Point(2, 37)
        Me.GrpBeneficiaria.Name = "GrpBeneficiaria"
        Me.GrpBeneficiaria.Size = New System.Drawing.Size(918, 442)
        Me.GrpBeneficiaria.TabIndex = 11
        Me.GrpBeneficiaria.TabStop = False
        Me.GrpBeneficiaria.Text = "Cuentas Beneficiarias"
        '
        'GridBeneficiarias
        '
        Me.GridBeneficiarias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridBeneficiarias.ColumnAutoResize = True
        Me.GridBeneficiarias.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridBeneficiarias.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridBeneficiarias.GroupByBoxVisible = False
        Me.GridBeneficiarias.Location = New System.Drawing.Point(7, 15)
        Me.GridBeneficiarias.Name = "GridBeneficiarias"
        Me.GridBeneficiarias.RecordNavigator = True
        Me.GridBeneficiarias.Size = New System.Drawing.Size(906, 420)
        Me.GridBeneficiarias.TabIndex = 1
        Me.GridBeneficiarias.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnDelBeneficiaria
        '
        Me.BtnDelBeneficiaria.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelBeneficiaria.Icon = CType(resources.GetObject("BtnDelBeneficiaria.Icon"), System.Drawing.Icon)
        Me.BtnDelBeneficiaria.Location = New System.Drawing.Point(784, 5)
        Me.BtnDelBeneficiaria.Name = "BtnDelBeneficiaria"
        Me.BtnDelBeneficiaria.Size = New System.Drawing.Size(62, 30)
        Me.BtnDelBeneficiaria.TabIndex = 10
        Me.BtnDelBeneficiaria.ToolTipText = "Elimina cuenta beneficiaria seleccionada"
        Me.BtnDelBeneficiaria.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAddBeneficiaria
        '
        Me.BtnAddBeneficiaria.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddBeneficiaria.Icon = CType(resources.GetObject("BtnAddBeneficiaria.Icon"), System.Drawing.Icon)
        Me.BtnAddBeneficiaria.Location = New System.Drawing.Point(852, 5)
        Me.BtnAddBeneficiaria.Name = "BtnAddBeneficiaria"
        Me.BtnAddBeneficiaria.Size = New System.Drawing.Size(63, 30)
        Me.BtnAddBeneficiaria.TabIndex = 9
        Me.BtnAddBeneficiaria.ToolTipText = "Agrega nueva cuenta beneficiaria"
        Me.BtnAddBeneficiaria.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTabPage2
        '
        Me.UiTabPage2.Controls.Add(Me.grpCluster)
        Me.UiTabPage2.Controls.Add(Me.btnDelCluster)
        Me.UiTabPage2.Controls.Add(Me.btnAddCluster)
        Me.UiTabPage2.Location = New System.Drawing.Point(1, 21)
        Me.UiTabPage2.Name = "UiTabPage2"
        Me.UiTabPage2.Size = New System.Drawing.Size(923, 484)
        Me.UiTabPage2.TabStop = True
        Me.UiTabPage2.Text = "Cluster"
        '
        'grpCluster
        '
        Me.grpCluster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCluster.BackColor = System.Drawing.Color.Transparent
        Me.grpCluster.Controls.Add(Me.gridCluster)
        Me.grpCluster.Location = New System.Drawing.Point(2, 37)
        Me.grpCluster.Name = "grpCluster"
        Me.grpCluster.Size = New System.Drawing.Size(918, 442)
        Me.grpCluster.TabIndex = 14
        Me.grpCluster.TabStop = False
        Me.grpCluster.Text = "Sucursales"
        '
        'gridCluster
        '
        Me.gridCluster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridCluster.ColumnAutoResize = True
        Me.gridCluster.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.gridCluster.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.gridCluster.GroupByBoxVisible = False
        Me.gridCluster.Location = New System.Drawing.Point(7, 15)
        Me.gridCluster.Name = "gridCluster"
        Me.gridCluster.RecordNavigator = True
        Me.gridCluster.Size = New System.Drawing.Size(906, 420)
        Me.gridCluster.TabIndex = 1
        Me.gridCluster.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnDelCluster
        '
        Me.btnDelCluster.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelCluster.Icon = CType(resources.GetObject("btnDelCluster.Icon"), System.Drawing.Icon)
        Me.btnDelCluster.Location = New System.Drawing.Point(784, 5)
        Me.btnDelCluster.Name = "btnDelCluster"
        Me.btnDelCluster.Size = New System.Drawing.Size(62, 30)
        Me.btnDelCluster.TabIndex = 13
        Me.btnDelCluster.ToolTipText = "Elimina terminal de cobro seleccionada"
        Me.btnDelCluster.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAddCluster
        '
        Me.btnAddCluster.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddCluster.Icon = CType(resources.GetObject("btnAddCluster.Icon"), System.Drawing.Icon)
        Me.btnAddCluster.Location = New System.Drawing.Point(852, 5)
        Me.btnAddCluster.Name = "btnAddCluster"
        Me.btnAddCluster.Size = New System.Drawing.Size(63, 30)
        Me.btnAddCluster.TabIndex = 12
        Me.btnAddCluster.ToolTipText = "Agrega nueva terminal de cobro"
        Me.btnAddCluster.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Clock
        '
        Me.Clock.Interval = 500
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(740, 523)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(838, 523)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkPacking
        '
        Me.ChkPacking.BackColor = System.Drawing.Color.Transparent
        Me.ChkPacking.Location = New System.Drawing.Point(9, 36)
        Me.ChkPacking.Name = "ChkPacking"
        Me.ChkPacking.Size = New System.Drawing.Size(77, 22)
        Me.ChkPacking.TabIndex = 147
        Me.ChkPacking.Text = "Packing"
        Me.ChkPacking.UseVisualStyleBackColor = False
        '
        'FrmSucursal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(932, 561)
        Me.Controls.Add(Me.UiTabTipoDoc)
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
        CType(Me.UiTabTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabTipoDoc.ResumeLayout(False)
        Me.UiTabCompania.ResumeLayout(False)
        Me.UiTabAutorizacion.ResumeLayout(False)
        Me.UiTabProductos.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabTerminales.ResumeLayout(False)
        Me.GrpTerminales.ResumeLayout(False)
        CType(Me.GridTerminal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabPage1.ResumeLayout(False)
        Me.GrpDocto.ResumeLayout(False)
        CType(Me.GridDoctos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabLibro.ResumeLayout(False)
        Me.GrpLibro.ResumeLayout(False)
        CType(Me.GridLibro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabLista.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpLista.ResumeLayout(False)
        CType(Me.GridLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabBeneficiaria.ResumeLayout(False)
        Me.GrpBeneficiaria.ResumeLayout(False)
        CType(Me.GridBeneficiarias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabPage2.ResumeLayout(False)
        Me.grpCluster.ResumeLayout(False)
        CType(Me.gridCluster, System.ComponentModel.ISupportInitialize).EndInit()
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
    Public Packing As Boolean = False
    Public Transito As Boolean = False
    Public ReciboRF As Boolean = False
    Public SurtidoRF As Boolean = False
    Public MostradorRF As Boolean = False
    Public Inventario As Boolean = False
    Public UbicacionRecibo As Boolean = False

    Public TipoResponsable As Integer = 1
    Public Responsable As String = ""
    Public eMail As String = ""
    Public Servidor As String = ""
    Public Oficina As String = ""

    Private cargado As Boolean = False
    Private alerta(10) As PictureBox
    Private reloj As parpadea

    Private sAutorizaSelected, sDoctoSelected, sClase, sTerminalSelected, sClusterSelected, sTerminal, sLibro, sLibroSelected, sNombre, sClienteSelected, sListaSelected, sBeneficiariaSelected, sBeneficiaria, sProductoSelected, sClave, sRecolectorSelected, sRecolector, sRecNombre, sProductoNombre As String
    Private iRecOrden As Integer

    Private bCambiosAutorizacion As Boolean = False
   
    Private dtAutoriza, dtLista, dtCliente, dtTerminal, dtSucursal, dtLibro, dtCluster, dtMoneda, dtTipoPago, dtDocto, dtTipo, dtCanal, dtBanco, dtPrecio, dtEstTerminal, dtImpuesto, dtRotacion, dtSucursalProducto, dtBeneficiaria As DataTable

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
                                                 "Actualizado", "System.Int32", _
                                                 "Edited", "System.Int32")
            Else

                dtSucursalProducto = ModPOS.Recupera_Tabla("sp_muestra_sucursalproducto", "@Max", MaxHits, "@Campo", iCampo, "@Busqueda", sBusqueda, "@SUCClave", SUCClave, "@Char", cReplace)


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
        ChkPacking.Estado = 0
        ChkTransito.Estado = 0
        ChkReciboRF.Estado = 0
        txtResponsable.Text = ""
        TxtCorreo.Text = ""
        txtServidor.Text = ""
        txtOficina.Text = ""

        If Not PictIcono.Image Is Nothing Then
            PictIcono.Image.Dispose()
        End If

        If Not dtAutoriza Is Nothing Then
            dtAutoriza.Dispose()
        End If


        NuevoIcono = False



      
        dtAutoriza = ModPOS.CrearTabla("Autorizacion", _
                                        "USRClave", "System.String", _
                                        "Nombre", "System.String", _
                                        "Firma", "System.String", _
                                        "Firma2", "System.String", _
                                        "Monto Inicial", "System.Double", _
                                        "Monto Final", "System.Double", _
                                        "Dias", "System.Int32", _
                                        "FechaInicio", "System.DateTime", _
                                        "TraspasoVale", "System.Boolean", _
                                        "TipoCambio", "System.Boolean", _
                                        "PreCorte", "System.Boolean", _
                                        "RetiroCaja", "System.Boolean")


        dtTerminal = ModPOS.CrearTabla("Terminales", _
                                     "TERClave", "System.String", _
                                     "Clave", "System.String", _
                                     "Banco", "System.String", _
                                     "PorcentajeCargo", "Systeml.Double", _
                                     "PinPad", "System.Booolean", _
                                     "Orden", "System.Int32", _
                                     "Estado", "System.Int32", _
                                     "Modificado", "System.Int32", _
                                     "Baja", "System.Int32")


        dtDocto = ModPOS.CrearTabla("Documentos", _
                                   "IdClase", "System.String", _
                                   "Clase", "System.String", _
                                   "Tipo", "System.Int32", _
                                   "Modificado", "System.Int32", _
                                   "Baja", "System.Int32")


        dtLibro = ModPOS.CrearTabla("Libro", _
                             "LIBClave", "System.String", _
                             "Moneda", "System.String", _
                             "Libro", "System.String", _
                             "Modificado", "System.Int32", _
                             "Baja", "System.Int32")

        dtLista = ModPOS.CrearTabla("Lista", _
                              "Id", "System.String", _
                              "Lista", "System.String", _
                              "Modificado", "System.Int32", _
                              "Baja", "System.Int32")

        dtCliente = ModPOS.CrearTabla("Cliente", _
                      "Id", "System.String", _
                      "CTEClave", "System.String", _
                      "Cliente", "System.String", _
                      "RazonSocial", "System.String", _
                       "Canal", "System.Int32", _
                      "Lista", "System.String", _
                      "Modificado", "System.Int32", _
                      "Baja", "System.Int32")

        dtCluster = ModPOS.CrearTabla("Cluster", _
                                "ClusterId", "System.String", _
                                "Cluster", "System.String", _
                                "Orden", "System.Int32", _
                                "Modificado", "System.Int32", _
                                "Baja", "System.Int32")

        GridAutorizan.DataSource = dtAutoriza
        GridAutorizan.RetrieveStructure(True)
        GridAutorizan.GroupByBoxVisible = False
        GridAutorizan.RootTable.Columns("USRClave").Visible = False
        GridAutorizan.RootTable.Columns("Firma2").Visible = False
        GridAutorizan.CurrentTable.Columns("Nombre").Selectable = False


        Me.actGrid(CInt(TxtMaxHits.Text), CmbCampo.SelectedValue, TxtBuscar.Text, True)

        GridTerminal.DataSource = dtTerminal
        GridTerminal.RetrieveStructure(True)
        GridTerminal.GroupByBoxVisible = False
        GridTerminal.RootTable.Columns("TERClave").Visible = False
        GridTerminal.RootTable.Columns("Modificado").Visible = False
        GridTerminal.CurrentTable.Columns("Baja").Visible = False


        GridTerminal.CurrentTable.Columns("Banco").HasValueList = True
        Dim AircraftTypeValueListItemCollection As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection = GridTerminal.Tables(0).Columns("Banco").ValueList
        With AircraftTypeValueListItemCollection

            dtBanco = ModPOS.Recupera_Tabla("sp_filtra_bancos", Nothing)

            Dim i As Integer
            For i = 0 To dtBanco.Rows.Count - 1
                .Add(dtBanco.Rows(i)("BNKClave"), dtBanco.Rows(i)("Nombre"))
            Next

        End With
        GridTerminal.CurrentTable.Columns("Banco").EditType = Janus.Windows.GridEX.EditType.Combo


        GridTerminal.CurrentTable.Columns("Estado").HasValueList = True
        Dim AircraftTypeValueListItemCollection2 As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection2 = GridTerminal.Tables(0).Columns("Estado").ValueList
        With AircraftTypeValueListItemCollection2

            dtEstTerminal = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "TerminalCobro", "@Campo", "Estado")

            Dim i As Integer
            For i = 0 To dtEstTerminal.Rows.Count - 1
                .Add(dtEstTerminal.Rows(i)("Valor"), dtEstTerminal.Rows(i)("Descripcion"))
            Next

        End With
        GridTerminal.CurrentTable.Columns("Estado").EditType = Janus.Windows.GridEX.EditType.Combo


        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridTerminal.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridTerminal.RootTable.FormatConditions.Add(fc)


        gridCluster.DataSource = dtCluster
        gridCluster.RetrieveStructure(True)
        gridCluster.GroupByBoxVisible = False
        gridCluster.RootTable.Columns("ClusterId").Visible = False
        gridCluster.RootTable.Columns("Modificado").Visible = False
        gridCluster.CurrentTable.Columns("Baja").Visible = False
        gridCluster.CurrentTable.Columns("Cluster").HasValueList = True

        Dim AircraftTypeValueListItemCollectionCl As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollectionCl = gridCluster.Tables(0).Columns("Cluster").ValueList
        With AircraftTypeValueListItemCollectionCl

            dtSucursal = ModPOS.Recupera_Tabla("sp_filtra_sucursal", "@USRClave", ModPOS.UsuarioActual, "@COMClave", ModPOS.CompanyActual)

            Dim i As Integer
            For i = 0 To dtSucursal.Rows.Count - 1
                .Add(dtSucursal.Rows(i)("SUCClave"), dtSucursal.Rows(i)("Nombre"))
            Next

        End With
        gridCluster.CurrentTable.Columns("Cluster").EditType = Janus.Windows.GridEX.EditType.Combo





        GridDoctos.DataSource = dtDocto
        GridDoctos.RetrieveStructure(True)
        GridDoctos.GroupByBoxVisible = False
        GridDoctos.RootTable.Columns("IdClase").Visible = False
        GridDoctos.RootTable.Columns("Modificado").Visible = False
        GridDoctos.CurrentTable.Columns("Baja").Visible = False


        GridDoctos.CurrentTable.Columns("Tipo").HasValueList = True
        Dim AircraftTypeValueListItemCollection3 As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection3 = GridDoctos.Tables(0).Columns("Tipo").ValueList
        With AircraftTypeValueListItemCollection3

            dtTipo = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Precio", "@Campo", "TipoDocumento")

            Dim i As Integer
            For i = 0 To dtTipo.Rows.Count - 1
                .Add(dtTipo.Rows(i)("Valor"), dtTipo.Rows(i)("Descripcion"))
            Next

        End With
        GridDoctos.CurrentTable.Columns("Tipo").EditType = Janus.Windows.GridEX.EditType.Combo

        Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
        fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridDoctos.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fc1.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc1.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridDoctos.RootTable.FormatConditions.Add(fc1)

        GridLibro.DataSource = dtLibro
        GridLibro.RetrieveStructure(True)
        GridLibro.GroupByBoxVisible = False
        GridLibro.RootTable.Columns("LIBClave").Visible = False
        GridLibro.RootTable.Columns("Modificado").Visible = False
        GridLibro.CurrentTable.Columns("Baja").Visible = False


        GridLibro.CurrentTable.Columns("Moneda").HasValueList = True
        Dim AircraftTypeValueListItemCollection4 As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection4 = GridLibro.Tables(0).Columns("Moneda").ValueList
        With AircraftTypeValueListItemCollection4

            dtMoneda = ModPOS.Recupera_Tabla("st_filtra_moneda", Nothing)

            Dim i As Integer
            For i = 0 To dtMoneda.Rows.Count - 1
                .Add(dtMoneda.Rows(i)("MONClave"), dtMoneda.Rows(i)("Referencia"))
            Next

        End With
        GridLibro.CurrentTable.Columns("Moneda").EditType = Janus.Windows.GridEX.EditType.Combo

        Dim fc4 As Janus.Windows.GridEX.GridEXFormatCondition
        fc4 = New Janus.Windows.GridEX.GridEXFormatCondition(GridLibro.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fc4.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc4.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridLibro.RootTable.FormatConditions.Add(fc4)

        GridLista.DataSource = dtLista
        GridLista.RetrieveStructure(True)
        GridLista.GroupByBoxVisible = False
        GridLista.RootTable.Columns("Id").Visible = False
        GridLista.RootTable.Columns("Modificado").Visible = False
        GridLista.CurrentTable.Columns("Baja").Visible = False

        GridLista.CurrentTable.Columns("Lista").HasValueList = True
        Dim AircraftTypeValueListItemCollectionL As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollectionL = GridLista.Tables(0).Columns("Lista").ValueList
        With AircraftTypeValueListItemCollectionL

            dtPrecio = ModPOS.Recupera_Tabla("sp_filtra_listas", "@COMClave", ModPOS.CompanyActual)

            Dim i As Integer
            For i = 0 To dtPrecio.Rows.Count - 1
                .Add(dtPrecio.Rows(i)("PREClave"), dtPrecio.Rows(i)("ListaPrecio"))
            Next

        End With
        GridLista.CurrentTable.Columns("Lista").EditType = Janus.Windows.GridEX.EditType.Combo




        Dim fcl As Janus.Windows.GridEX.GridEXFormatCondition
        fcl = New Janus.Windows.GridEX.GridEXFormatCondition(GridLista.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fcl.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fcl.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridLista.RootTable.FormatConditions.Add(fcl)



        GridCliente.DataSource = dtCliente
        GridCliente.RetrieveStructure(True)
        GridCliente.GroupByBoxVisible = False
        GridCliente.RootTable.Columns("Id").Visible = False
        GridCliente.RootTable.Columns("CTEClave").Visible = False
        GridCliente.RootTable.Columns("Modificado").Visible = False
        GridCliente.CurrentTable.Columns("Baja").Visible = False


        GridCliente.CurrentTable.Columns("Lista").HasValueList = True
        Dim AircraftTypeValueListItemCollectionC As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollectionC = GridCliente.Tables(0).Columns("Lista").ValueList
        With AircraftTypeValueListItemCollectionC

            Dim i As Integer
            For i = 0 To dtPrecio.Rows.Count - 1
                .Add(dtPrecio.Rows(i)("PREClave"), dtPrecio.Rows(i)("ListaPrecio"))
            Next

        End With
        GridCliente.CurrentTable.Columns("Lista").EditType = Janus.Windows.GridEX.EditType.Combo

        GridCliente.CurrentTable.Columns("Canal").HasValueList = True
        Dim AircraftTypeValueListItemCollection5 As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection5 = GridCliente.Tables(0).Columns("Canal").ValueList
        With AircraftTypeValueListItemCollection5

            dtCanal = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Cliente", "@Campo", "TipoCanal")

            Dim i As Integer
            For i = 0 To dtCanal.Rows.Count - 1
                .Add(dtCanal.Rows(i)("Valor"), dtCanal.Rows(i)("Descripcion"))
            Next

        End With
        GridCliente.CurrentTable.Columns("Canal").EditType = Janus.Windows.GridEX.EditType.Combo




        Dim fcc As Janus.Windows.GridEX.GridEXFormatCondition
        fcc = New Janus.Windows.GridEX.GridEXFormatCondition(GridCliente.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fcc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fcc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridCliente.RootTable.FormatConditions.Add(fcc)


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

        Dim foundRows() As System.Data.DataRow
        foundRows = dtLista.Select("( Lista = 'Error' or   Lista = '') and Baja = 0 ")

        If foundRows.GetLength(0) > 0 Then
            i += 1
            MessageBox.Show("Existe una Excepción de Lista de Precios Invalida")
        End If

        foundRows = dtCliente.Select(" (Lista = 'Error' or   Lista = '' ) and Baja = 0 ")

        If foundRows.GetLength(0) > 0 Then
            i += 1
            MessageBox.Show("Existe una Excepción de Cliente Invalida")
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

        With CmbResponsable
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "Responsable"
            .llenar()
        End With

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
        CmbResponsable.SelectedValue = TipoResponsable

        ChkPicking.Estado = Math.Abs(CInt(Picking))
        ChkPacking.Estado = Math.Abs(CInt(Packing))
        ChkTransito.Estado = Math.Abs(CInt(Transito))

        ChkReciboRF.Estado = Math.Abs(CInt(ReciboRF))
        ChkSurtidoRF.Estado = Math.Abs(CInt(SurtidoRF))
        ChkMostradorRF.Estado = Math.Abs(CInt(MostradorRF))
        ChkInventario.Estado = Math.Abs(CInt(Inventario))
        ChkUbicacionRecibo.Estado = Math.Abs(CInt(UbicacionRecibo))

        txtResponsable.Text = Responsable
        TxtCorreo.Text = eMail
        txtServidor.Text = Servidor
        txtOficina.Text = Oficina
      
      
        cargado = True


        If Padre = "Agregar" Then


            dtAutoriza = ModPOS.CrearTabla("Autorizacion", _
           "USRClave", "System.String", _
           "Nombre", "System.String", _
           "Firma", "System.String", _
           "Firma2", "System.String", _
           "Monto Inicial", "System.Double", _
           "Monto Final", "System.Double", _
           "Dias", "System.Int32", _
           "FechaInicio", "System.DateTime")


            dtTerminal = ModPOS.CrearTabla("Terminales", _
                                         "TERClave", "System.String", _
                                         "Clave", "System.String", _
                                         "Banco", "System.String", _
                                         "Cuenta", "System.String", _
                                         "Orden", "System.Int32", _
                                         "Estado", "System.Int32", _
                                         "Modificado", "System.Int32", _
                                         "Baja", "System.Int32")


            dtDocto = ModPOS.CrearTabla("Documentos", _
                                       "IdClase", "System.String", _
                                       "Clase", "System.String", _
                                       "Tipo", "System.Int32", _
                                       "Modificado", "System.Int32", _
                                       "Baja", "System.Int32")


            dtLibro = ModPOS.CrearTabla("Libro", _
                                 "LIBClave", "System.String", _
                                 "Moneda", "System.String", _
                                 "Libro", "System.String", _
                                 "Modificado", "System.Int32", _
                                 "Baja", "System.Int32")


            dtLista = ModPOS.CrearTabla("Lista", _
                                 "Id", "System.String", _
                                 "Lista", "System.String", _
                                 "Modificado", "System.Int32", _
                                 "Baja", "System.Int32")

            dtCluster = ModPOS.CrearTabla("Cluster", _
                                 "ClusterId", "System.String", _
                                 "Cluster", "System.String", _
                                 "Orden", "System.Int32", _
                                 "Modificado", "System.Int32", _
                                 "Baja", "System.Int32")


            dtCliente = ModPOS.CrearTabla("Cliente", _
                     "Id", "System.String", _
                     "CTEClave", "System.String", _
                     "Cliente", "System.String", _
                     "RazonSocial", "System.String", _
                     "Canal", "System.Int32", _
                     "Lista", "System.String", _
                     "Modificado", "System.Int32", _
                     "Baja", "System.Int32")


            dtBeneficiaria = ModPOS.CrearTabla("Beneficiaria", _
                                         "METClave", "System.String", _
                                         "TipoPago", "System.Int32", _
                                         "Moneda", "System.String", _
                                         "Banco", "System.String", _
                                         "Cuenta", "System.String", _
                                         "Modificado", "System.Int32", _
                                         "Baja", "System.Int32")
        Else
            TxtClave.Enabled = False
            dtAutoriza = ModPOS.Recupera_Tabla("sp_muestra_autorizaciones", "@SUCClave", SUCClave)
            dtTerminal = ModPOS.Recupera_Tabla("st_muestra_terminales", "@SUCClave", SUCClave)
            dtDocto = ModPOS.Recupera_Tabla("st_muestra_clasedocumento", "@SUCClave", SUCClave)
            dtLibro = ModPOS.Recupera_Tabla("st_muestra_libro", "@SUCClave", SUCClave)
            dtLista = ModPOS.Recupera_Tabla("st_muestra_lista_sucursal", "@SUCClave", SUCClave)
            dtCliente = ModPOS.Recupera_Tabla("st_muestra_cte_sucursal", "@SUCClave", SUCClave)
            dtBeneficiaria = ModPOS.Recupera_Tabla("st_muestra_sucursalpago", "@SUCClave", SUCClave)
            dtCluster = ModPOS.Recupera_Tabla("st_muestra_sucursalcluster", "@SUCClave", SUCClave)

        End If

        Me.actGrid(CInt(TxtMaxHits.Text), CmbCampo.SelectedValue, "%", False)

        GridAutorizan.DataSource = dtAutoriza
        GridAutorizan.RetrieveStructure(True)
        GridAutorizan.GroupByBoxVisible = False
        GridAutorizan.RootTable.Columns("USRClave").Visible = False
        GridAutorizan.RootTable.Columns("Firma2").Visible = False
        GridAutorizan.CurrentTable.Columns("Nombre").Selectable = False


        GridTerminal.DataSource = dtTerminal
        GridTerminal.RetrieveStructure(True)
        GridTerminal.GroupByBoxVisible = False
        GridTerminal.RootTable.Columns("TERClave").Visible = False
        GridTerminal.RootTable.Columns("Modificado").Visible = False
        GridTerminal.CurrentTable.Columns("Baja").Visible = False


        GridTerminal.CurrentTable.Columns("Banco").HasValueList = True
        Dim AircraftTypeValueListItemCollection As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection = GridTerminal.Tables(0).Columns("Banco").ValueList
        With AircraftTypeValueListItemCollection

            dtBanco = ModPOS.Recupera_Tabla("sp_filtra_bancos", Nothing)

            Dim i As Integer
            For i = 0 To dtBanco.Rows.Count - 1
                .Add(dtBanco.Rows(i)("BNKClave"), dtBanco.Rows(i)("Nombre"))
            Next

        End With
        GridTerminal.CurrentTable.Columns("Banco").EditType = Janus.Windows.GridEX.EditType.Combo


        GridTerminal.CurrentTable.Columns("Estado").HasValueList = True
        Dim AircraftTypeValueListItemCollection2 As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection2 = GridTerminal.Tables(0).Columns("Estado").ValueList
        With AircraftTypeValueListItemCollection2

            dtEstTerminal = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "TerminalCobro", "@Campo", "Estado")

            Dim i As Integer
            For i = 0 To dtestterminal.Rows.Count - 1
                .Add(dtestterminal.Rows(i)("Valor"), dtestterminal.Rows(i)("Descripcion"))
            Next

        End With
        GridTerminal.CurrentTable.Columns("Estado").EditType = Janus.Windows.GridEX.EditType.Combo


        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridTerminal.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridTerminal.RootTable.FormatConditions.Add(fc)


        gridCluster.DataSource = dtCluster
        gridCluster.RetrieveStructure(True)
        gridCluster.GroupByBoxVisible = False
        gridCluster.RootTable.Columns("ClusterId").Visible = False
        gridCluster.RootTable.Columns("Modificado").Visible = False
        gridCluster.CurrentTable.Columns("Baja").Visible = False
        gridCluster.CurrentTable.Columns("Cluster").HasValueList = True

        Dim AircraftTypeValueListItemCollectionCl As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollectionCl = gridCluster.Tables(0).Columns("Cluster").ValueList
        With AircraftTypeValueListItemCollectionCl

            dtSucursal = ModPOS.Recupera_Tabla("sp_filtra_sucursal", "@USRClave", ModPOS.UsuarioActual, "@COMClave", ModPOS.CompanyActual)

            Dim i As Integer
            For i = 0 To dtSucursal.Rows.Count - 1
                .Add(dtSucursal.Rows(i)("SUCClave"), dtSucursal.Rows(i)("Nombre"))
            Next

        End With
        gridCluster.CurrentTable.Columns("Cluster").EditType = Janus.Windows.GridEX.EditType.Combo


        Dim fccl As Janus.Windows.GridEX.GridEXFormatCondition
        fccl = New Janus.Windows.GridEX.GridEXFormatCondition(gridCluster.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fccl.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fccl.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        gridCluster.RootTable.FormatConditions.Add(fccl)

        'Fin cluster

        GridDoctos.DataSource = dtDocto
        GridDoctos.RetrieveStructure(True)
        GridDoctos.GroupByBoxVisible = False
        GridDoctos.RootTable.Columns("IdClase").Visible = False
        GridDoctos.RootTable.Columns("Modificado").Visible = False
        GridDoctos.CurrentTable.Columns("Baja").Visible = False


        GridDoctos.CurrentTable.Columns("Tipo").HasValueList = True
        Dim AircraftTypeValueListItemCollection3 As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection3 = GridDoctos.Tables(0).Columns("Tipo").ValueList
        With AircraftTypeValueListItemCollection3

            dtTipo = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Precio", "@Campo", "TipoDocumento")

            Dim i As Integer
            For i = 0 To dtTipo.Rows.Count - 1
                .Add(dtTipo.Rows(i)("Valor"), dtTipo.Rows(i)("Descripcion"))
            Next

        End With
        GridDoctos.CurrentTable.Columns("Tipo").EditType = Janus.Windows.GridEX.EditType.Combo

        Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
        fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridDoctos.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fc1.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc1.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridDoctos.RootTable.FormatConditions.Add(fc1)


        GridLibro.DataSource = dtLibro
        GridLibro.RetrieveStructure(True)
        GridLibro.GroupByBoxVisible = False
        GridLibro.RootTable.Columns("LIBClave").Visible = False
        GridLibro.RootTable.Columns("Modificado").Visible = False
        GridLibro.CurrentTable.Columns("Baja").Visible = False


        GridLibro.CurrentTable.Columns("Moneda").HasValueList = True
        Dim AircraftTypeValueListItemCollection4 As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection4 = GridLibro.Tables(0).Columns("Moneda").ValueList
        With AircraftTypeValueListItemCollection4

            dtMoneda = ModPOS.Recupera_Tabla("st_filtra_moneda", Nothing)

            Dim i As Integer
            For i = 0 To dtMoneda.Rows.Count - 1
                .Add(dtMoneda.Rows(i)("MONClave"), dtMoneda.Rows(i)("Referencia"))
            Next

        End With
        GridLibro.CurrentTable.Columns("Moneda").EditType = Janus.Windows.GridEX.EditType.Combo

        Dim fc4 As Janus.Windows.GridEX.GridEXFormatCondition
        fc4 = New Janus.Windows.GridEX.GridEXFormatCondition(GridLibro.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fc4.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc4.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridLibro.RootTable.FormatConditions.Add(fc4)



        GridLista.DataSource = dtLista
        GridLista.RetrieveStructure(True)
        GridLista.GroupByBoxVisible = False
        GridLista.RootTable.Columns("Id").Visible = False
        GridLista.RootTable.Columns("Modificado").Visible = False
        GridLista.CurrentTable.Columns("Baja").Visible = False


        GridLista.CurrentTable.Columns("Lista").HasValueList = True
        Dim AircraftTypeValueListItemCollectionL As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollectionL = GridLista.Tables(0).Columns("Lista").ValueList
        With AircraftTypeValueListItemCollectionL

            dtPrecio = ModPOS.Recupera_Tabla("sp_filtra_listas", "@COMClave", ModPOS.CompanyActual)

            Dim i As Integer
            For i = 0 To dtPrecio.Rows.Count - 1
                .Add(dtPrecio.Rows(i)("PREClave"), dtPrecio.Rows(i)("ListaPrecio"))
            Next

        End With
        GridLista.CurrentTable.Columns("Lista").EditType = Janus.Windows.GridEX.EditType.Combo

        Dim fcl As Janus.Windows.GridEX.GridEXFormatCondition
        fcl = New Janus.Windows.GridEX.GridEXFormatCondition(GridLista.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fcl.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fcl.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridLista.RootTable.FormatConditions.Add(fcl)

        GridBeneficiarias.DataSource = dtBeneficiaria
        GridBeneficiarias.RetrieveStructure(True)
        GridBeneficiarias.GroupByBoxVisible = False
        GridBeneficiarias.RootTable.Columns("METClave").Visible = False
        GridBeneficiarias.RootTable.Columns("Modificado").Visible = False
        GridBeneficiarias.CurrentTable.Columns("Baja").Visible = False

        GridBeneficiarias.CurrentTable.Columns("Banco").HasValueList = True
        Dim AircraftTypeValueListItemCollectionB As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollectionB = GridBeneficiarias.Tables(0).Columns("Banco").ValueList
        With AircraftTypeValueListItemCollectionB

            dtBanco = ModPOS.Recupera_Tabla("sp_filtra_bancos", Nothing)

            Dim i As Integer
            For i = 0 To dtBanco.Rows.Count - 1
                .Add(dtBanco.Rows(i)("BNKClave"), dtBanco.Rows(i)("Nombre"))
            Next

        End With
        GridBeneficiarias.CurrentTable.Columns("Banco").EditType = Janus.Windows.GridEX.EditType.Combo

        GridBeneficiarias.CurrentTable.Columns("Moneda").HasValueList = True
        Dim AircraftTypeValueListItemCollectionM As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollectionM = GridBeneficiarias.Tables(0).Columns("Moneda").ValueList
        With AircraftTypeValueListItemCollectionM

            dtMoneda = ModPOS.Recupera_Tabla("st_filtra_moneda", Nothing)

            Dim i As Integer
            For i = 0 To dtMoneda.Rows.Count - 1
                .Add(dtMoneda.Rows(i)("MONClave"), dtMoneda.Rows(i)("Referencia"))
            Next

        End With
        GridBeneficiarias.CurrentTable.Columns("Moneda").EditType = Janus.Windows.GridEX.EditType.Combo

        GridBeneficiarias.CurrentTable.Columns("Tipopago").HasValueList = True
        Dim AircraftTypeValueListItemCollectionT As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollectionT = GridBeneficiarias.Tables(0).Columns("TipoPago").ValueList
        With AircraftTypeValueListItemCollectionT

            dtTipoPago = ModPOS.Recupera_Tabla("st_filtra_metodopagob", Nothing)

            Dim i As Integer
            For i = 0 To dtTipoPago.Rows.Count - 1
                .Add(dtTipoPago.Rows(i)("Valor"), dtTipoPago.Rows(i)("Descripcion"))
            Next

        End With
        GridBeneficiarias.CurrentTable.Columns("TipoPago").EditType = Janus.Windows.GridEX.EditType.Combo

        Dim fcb As Janus.Windows.GridEX.GridEXFormatCondition
        fcb = New Janus.Windows.GridEX.GridEXFormatCondition(GridBeneficiarias.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fcb.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fcb.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridBeneficiarias.RootTable.FormatConditions.Add(fcb)


        GridCliente.DataSource = dtCliente
        GridCliente.RetrieveStructure(True)
        GridCliente.GroupByBoxVisible = False
        GridCliente.RootTable.Columns("Id").Visible = False
        GridCliente.RootTable.Columns("CTEClave").Visible = False
        GridCliente.RootTable.Columns("Modificado").Visible = False
        GridCliente.CurrentTable.Columns("Baja").Visible = False

        GridCliente.CurrentTable.Columns("Lista").HasValueList = True
        Dim AircraftTypeValueListItemCollectionC As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollectionC = GridCliente.Tables(0).Columns("Lista").ValueList
        With AircraftTypeValueListItemCollectionC

            Dim i As Integer
            For i = 0 To dtPrecio.Rows.Count - 1
                .Add(dtPrecio.Rows(i)("PREClave"), dtPrecio.Rows(i)("ListaPrecio"))
            Next

        End With
        GridCliente.CurrentTable.Columns("Lista").EditType = Janus.Windows.GridEX.EditType.Combo



        GridCliente.CurrentTable.Columns("Canal").HasValueList = True
        Dim AircraftTypeValueListItemCollection5 As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection5 = GridCliente.Tables(0).Columns("Canal").ValueList
        With AircraftTypeValueListItemCollection5

            dtCanal = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Cliente", "@Campo", "TipoCanal")

            Dim i As Integer
            For i = 0 To dtCanal.Rows.Count - 1
                .Add(dtCanal.Rows(i)("Valor"), dtCanal.Rows(i)("Descripcion"))
            Next

        End With
        GridCliente.CurrentTable.Columns("Canal").EditType = Janus.Windows.GridEX.EditType.Combo



        Dim fcc As Janus.Windows.GridEX.GridEXFormatCondition
        fcc = New Janus.Windows.GridEX.GridEXFormatCondition(GridCliente.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fcc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fcc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridCliente.RootTable.FormatConditions.Add(fcc)

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

    Private Sub ActualizaSucursalProducto()
        dtSucursalProducto = ModPOS.Recupera_Tabla("sp_muestra_sucursalproducto", "@SUCClave", SUCClave, "@Char", cReplace)

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
                ByVal FechaIni As Date, _
                ByVal TraspasoVale As Boolean, _
                ByVal TipoCambio As Boolean, _
                ByVal PreCorte As Boolean, _
                ByVal RetiroCaja As Boolean) As Boolean

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

            row1.Item("TraspasoVale") = TraspasoVale
            row1.Item("TipoCambio") = TipoCambio
            row1.Item("PreCorte") = PreCorte
            row1.Item("RetiroCaja") = RetiroCaja
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
                    TipoResponsable = IIf(CmbResponsable.SelectedValue Is Nothing, 0, CmbResponsable.SelectedValue)

                    Picking = CBool(ChkPicking.GetEstado)
                    Packing = CBool(ChkPacking.GetEstado)
                    Transito = CBool(ChkTransito.GetEstado)

                    ReciboRF = CBool(ChkReciboRF.GetEstado)
                    SurtidoRF = CBool(ChkSurtidoRF.GetEstado)
                    MostradorRF = CBool(ChkMostradorRF.GetEstado)
                    Inventario = CBool(ChkInventario.GetEstado)
                    UbicacionRecibo = CBool(ChkUbicacionRecibo.GetEstado)

                    Responsable = txtResponsable.Text
                    eMail = TxtCorreo.Text
                    Servidor = txtServidor.Text
                    Oficina = txtOficina.Text

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
                                    "@Packing", Packing, _
                                    "@Transito", Transito, _
                                    "@ReciboRF", ReciboRF, _
                                    "@SurtidoRF", SurtidoRF, _
                                    "@MostradorRF", MostradorRF, _
                                    "@Inventario", Inventario, _
                                    "@UbicacionRecibo", UbicacionRecibo, _
                                    "@Responsable", Responsable, _
                                    "@eMail", eMail, _
                                    "@Servidor", Servidor, _
                                    "@OficinaVta", Oficina, _
                                    "@COMClave", ModPOS.CompanyActual, _
                                    "@TipoResponsable", TipoResponsable, _
                                    "@Usuario", ModPOS.UsuarioActual)


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
                                                 "@TraspasoVale", dtAutoriza.Rows(i)("TraspasoVale"), _
                                                 "@TipoCambio", dtAutoriza.Rows(i)("TipoCambio"), _
                                                 "@PreCorte", dtAutoriza.Rows(i)("PreCorte"), _
                                                 "@RetiroCaja", dtAutoriza.Rows(i)("RetiroCaja"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If

                    foundRows = dtTerminal.Select("Baja = 0")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_terminalcobro", _
                                                  "@SUCClave", SUCClave, _
                                                  "@TERClave", foundRows(i)("TERClave"), _
                                                  "@Clave", foundRows(i)("Clave"), _
                                                  "@Banco", foundRows(i)("Banco"), _
                                                  "@Cuenta", foundRows(i)("Cuenta"), _
                                                  "@PorcCargo", foundRows(i)("PorcentajeCargo"), _
                                                  "@PinPad", foundRows(i)("PinPad"), _
                                                  "@Orden", foundRows(i)("Orden"), _
                                                  "@Estado", foundRows(i)("Estado"), _
                                                  "@Baja", foundRows(i)("Baja"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If

                    foundRows = dtBeneficiaria.Select("Baja = 0")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_sucursalpago", _
                                                  "@SUCClave", SUCClave, _
                                                  "@METClave", foundRows(i)("METClave"), _
                                                  "@TipoPago", foundRows(i)("TipoPago"), _
                                                  "@Banco", foundRows(i)("Banco"), _
                                                  "@Cuenta", foundRows(i)("Cuenta"), _
                                                  "@Moneda", foundRows(i)("Moneda"), _
                                                  "@Baja", foundRows(i)("Baja"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If
                    foundRows = dtDocto.Select("Baja = 0")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_clasedocumento", _
                                                  "@SUCClave", SUCClave, _
                                                  "@IdClase", foundRows(i)("IdClase"), _
                                                  "@Clase", foundRows(i)("Clase"), _
                                                  "@Tipo", foundRows(i)("Tipo"), _
                                                  "@Baja", foundRows(i)("Baja"), _
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
                                                  "@Preventa", dtSucursalProducto.Rows(i)("Preventa"), _
                                                  "@vtaPaquete", dtSucursalProducto.Rows(i)("vtaPaquete"), _
                                                  "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


                    foundRows = dtLibro.Select("Baja = 0")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_libro", _
                                                  "@SUCClave", SUCClave, _
                                                  "@LIBClave", foundRows(i)("LIBClave"), _
                                                  "@Libro", foundRows(i)("Libro"), _
                                                  "@Moneda", foundRows(i)("Moneda"), _
                                                  "@Baja", foundRows(i)("Baja"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If


                    'Estrategia

                    foundRows = dtLista.Select("Baja = 0")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_lista_sucursal", _
                                                  "@SUCClave", SUCClave, _
                                                  "@PREClave", foundRows(i)("Lista"), _
                                                  "@id", foundRows(i)("id"), _
                                                  "@Baja", foundRows(i)("Baja"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If


                    'Estrategia

                    foundRows = dtCliente.Select("Baja = 0")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_cte_sucursal", _
                                                  "@id", foundRows(i)("id"), _
                                                  "@SUCClave", SUCClave, _
                                                  "@Canal", foundRows(i)("Canal"), _
                                                  "@PREClave", foundRows(i)("Lista"), _
                                                  "@CTEClave", foundRows(i)("CTEClave"), _
                                                  "@Baja", foundRows(i)("Baja"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If

                    'Cluster 

                    foundRows = dtCluster.Select("Baja = 0")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_sucursalcluster", _
                                                  "@SUCClave", SUCClave, _
                                                  "@ClusterId", foundRows(i)("ClusterId"), _
                                                  "@Cluster", foundRows(i)("Cluster"), _
                                                  "@Orden", foundRows(i)("Orden"), _
                                                  "@Baja", foundRows(i)("Baja"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

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
                        Packing = CBool(ChkPacking.GetEstado) AndAlso _
                        Transito = CBool(ChkTransito.GetEstado) AndAlso _
                        ReciboRF = CBool(ChkReciboRF.GetEstado) AndAlso _
                        SurtidoRF = CBool(ChkSurtidoRF.GetEstado) AndAlso _
                          MostradorRF = CBool(ChkMostradorRF.GetEstado) AndAlso _
                        Inventario = CBool(ChkInventario.GetEstado) AndAlso _
                        UbicacionRecibo = CBool(ChkUbicacionRecibo.GetEstado) AndAlso _
                        Responsable = txtResponsable.Text AndAlso _
                        eMail = TxtCorreo.Text AndAlso _
                        Servidor = txtServidor.Text AndAlso _
                        Oficina = txtOficina.Text AndAlso _
                        TipoResponsable = IIf(CmbResponsable.SelectedValue Is Nothing, 0, CmbResponsable.SelectedValue) AndAlso _
                        CERClave = IIf(CmbCertificado.SelectedValue Is Nothing, "", CmbCertificado.SelectedValue) AndAlso _
                        bCambiosAutorizacion = False AndAlso Not NuevoIcono) Then


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
                        TipoResponsable = IIf(CmbResponsable.SelectedValue Is Nothing, 0, CmbResponsable.SelectedValue)

                        Picking = CBool(ChkPicking.GetEstado)
                        Packing = CBool(ChkPacking.GetEstado)
                        Transito = CBool(ChkTransito.GetEstado)
                        ReciboRF = CBool(ChkReciboRF.GetEstado)
                        SurtidoRF = CBool(ChkSurtidoRF.GetEstado)
                        MostradorRF = CBool(ChkMostradorRF.GetEstado)
                        Inventario = CBool(ChkInventario.GetEstado)
                        UbicacionRecibo = CBool(ChkUbicacionRecibo.GetEstado)

                        Responsable = txtResponsable.Text
                        eMail = TxtCorreo.Text
                        Servidor = txtServidor.Text
                        Oficina = txtOficina.Text

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
                                        "@Picking", Picking, _
                                        "@Packing", Packing, _
                                        "@Transito", Transito, _
                                        "@ReciboRF", ReciboRF, _
                                        "@SurtidoRF", SurtidoRF, _
                                        "@MostradorRF", MostradorRF, _
                                        "@Inventario", Inventario, _
                                        "@UbicacionRecibo", UbicacionRecibo, _
                                        "@Responsable", Responsable, _
                                        "@eMail", eMail, _
                                        "@Servidor", Servidor, _
                                        "@OficinaVta", Oficina, _
                                        "@TipoResponsable", TipoResponsable, _
                                        "@COMClave", ModPOS.CompanyActual, _
                                        "@Usuario", ModPOS.UsuarioActual)

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
                                                      "@TraspasoVale", dtAutoriza.Rows(i)("TraspasoVale"), _
                                                 "@TipoCambio", dtAutoriza.Rows(i)("TipoCambio"), _
                                                 "@PreCorte", dtAutoriza.Rows(i)("PreCorte"), _
                                                 "@RetiroCaja", dtAutoriza.Rows(i)("RetiroCaja"), _
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
                                                  "@PROClave", foundRows(i)("PROClave"), _
                                                  "@Minimo", foundRows(i)("Minimo"), _
                                                  "@Maximo", foundRows(i)("Maximo"), _
                                                  "@Reorden", foundRows(i)("Reorden"), _
                                                  "@Rotacion", foundRows(i)("Rotación"), _
                                                  "@Costo", foundRows(i)("CostoVigente"), _
                                                  "@TipoImpuesto", foundRows(i)("TipoImpuesto"), _
                                                   "@Preventa", foundRows(i)("Preventa"), _
                                                  "@vtaPaquete", foundRows(i)("vtaPaquete"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                            'If foundRows(i)("CostoVigente") <> foundRows(i)("Costo") Then

                            '    ModCosto(foundRows(i)("PROClave"), foundRows(i)("CostoVigente"), foundRows(i)("Costo"))
                            'End If

                        Next
                    End If

                    foundRows = dtTerminal.Select("Modificado = 1")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_terminalcobro", _
                                          "@SUCClave", SUCClave, _
                                          "@TERClave", foundRows(i)("TERClave"), _
                                          "@Clave", foundRows(i)("Clave"), _
                                          "@Banco", foundRows(i)("Banco"), _
                                          "@Cuenta", foundRows(i)("Cuenta"), _
                                          "@PorcCargo", foundRows(i)("PorcentajeCargo"), _
                                          "@PinPad", foundRows(i)("PinPad"), _
                                          "@Orden", foundRows(i)("Orden"), _
                                          "@Estado", foundRows(i)("Estado"), _
                                          "@Baja", foundRows(i)("Baja"), _
                                          "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If

                    foundRows = dtBeneficiaria.Select("Modificado = 1")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_sucursalpago", _
                                                  "@SUCClave", SUCClave, _
                                                  "@METClave", foundRows(i)("METClave"), _
                                                  "@TipoPago", foundRows(i)("TipoPago"), _
                                                  "@Banco", foundRows(i)("Banco"), _
                                                  "@Cuenta", foundRows(i)("Cuenta"), _
                                                  "@Moneda", foundRows(i)("Moneda"), _
                                                  "@Baja", foundRows(i)("Baja"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If

                    foundRows = dtDocto.Select("Modificado= 1")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_clasedocumento", _
                                                  "@SUCClave", SUCClave, _
                                                  "@IdClase", foundRows(i)("IdClase"), _
                                                  "@Clase", foundRows(i)("Clase"), _
                                                  "@Tipo", foundRows(i)("Tipo"), _
                                                  "@Baja", foundRows(i)("Baja"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If


                    foundRows = dtLibro.Select("Modificado = 1")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_libro", _
                                                  "@SUCClave", SUCClave, _
                                                  "@LIBClave", foundRows(i)("LIBClave"), _
                                                  "@Libro", foundRows(i)("Libro"), _
                                                  "@Moneda", foundRows(i)("Moneda"), _
                                                  "@Baja", foundRows(i)("Baja"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If

                    foundRows = dtLista.Select("Modificado = 1")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_lista_sucursal", _
                                                  "@SUCClave", SUCClave, _
                                                  "@PREClave", foundRows(i)("Lista"), _
                                                  "@id", foundRows(i)("id"), _
                                                  "@Baja", foundRows(i)("Baja"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If



                    foundRows = dtCliente.Select("Modificado = 1")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_cte_sucursal", _
                                                  "@id", foundRows(i)("id"), _
                                                  "@SUCClave", SUCClave, _
                                                  "@Canal", foundRows(i)("Canal"), _
                                                  "@PREClave", foundRows(i)("Lista"), _
                                                  "@CTEClave", foundRows(i)("CTEClave"), _
                                                  "@Baja", foundRows(i)("Baja"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If


                    foundRows = dtCluster.Select("Modificado = 1")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_sucursalcluster", _
                                                  "@SUCClave", SUCClave, _
                                                  "@ClusterId", foundRows(i)("ClusterId"), _
                                                  "@Cluster", foundRows(i)("Cluster"), _
                                                  "@Orden", foundRows(i)("Orden"), _
                                                  "@Baja", foundRows(i)("Baja"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

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
                    foundRows = dtAutoriza.Select(" USRClave = '" & sAutorizaSelected & "'")
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

    Private Sub btnDelTerminal_Click(sender As Object, e As EventArgs) Handles btnDelTerminal.Click
        If sTerminalSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la terminal de cobro :" & sTerminal, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtTerminal.Select(" TERClave = '" & sTerminalSelected & "'")
                    foundRows(0)("Baja") = 1

            End Select
        End If
    End Sub

    Private Sub GridTerminal_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridTerminal.CellEdited

        Select Case GridTerminal.CurrentColumn.Caption
            Case "Clave"

                If GridTerminal.GetValue("Clave").GetType.Name = "DBNull" OrElse CStr(GridTerminal.GetValue("Clave")).Length = 0 Then
                    GridTerminal.SetValue("Clave", "ERROR")
                    GridTerminal.SetValue("Modificado", 0)
                Else
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtTerminal.Select(" TERClave <> '" & GridTerminal.GetValue("TERClave") & "' and Baja = 0 and Clave = '" & CStr(GridTerminal.GetValue("Clave")).Trim & "'")

                    If foundRows.GetLength(0) > 0 Then
                        MessageBox.Show("¡La Clave que intenta agregar ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridTerminal.SetValue("Clave", "ERROR")
                        GridTerminal.SetValue("Modificado", 0)
                    Else
                        GridTerminal.SetValue("Clave", CStr(GridTerminal.GetValue("Clave")).Trim)
                        GridTerminal.SetValue("Modificado", 1)
                    End If
                End If


            Case "Banco"
                If GridTerminal.GetValue("Banco").GetType.Name = "DBNull" OrElse CStr(GridTerminal.GetValue("Banco")).Length = 0 Then
                    GridTerminal.SetValue("Banco", "ERROR")
                    GridTerminal.SetValue("Modificado", 0)
                Else
                    GridTerminal.SetValue("Modificado", 1)
                End If

            Case "Cuenta"
                If GridTerminal.GetValue("Cuenta").GetType.Name = "DBNull" OrElse CStr(GridTerminal.GetValue("Cuenta")).Length = 0 Then
                    GridTerminal.SetValue("Cuenta", "")
                    GridTerminal.SetValue("Modificado", 0)
                Else
                    GridTerminal.SetValue("Modificado", 1)
                End If


            Case "Porcentaje Cargo"

                If Not IsNumeric(GridTerminal.GetValue("PorcentajeCargo")) Then
                    GridTerminal.SetValue("PorcentajeCargo", 0)
                    GridTerminal.SetValue("Modificado", 0)
                ElseIf CDbl(GridTerminal.GetValue("PorcentajeCargo")) > 100 OrElse CDbl(GridTerminal.GetValue("PorcentajeCargo")) < 0 Then
                    GridTerminal.SetValue("PorcentajeCargo", 0)
                    GridTerminal.SetValue("Modificado", 0)
                Else
                    GridTerminal.SetValue("Modificado", 1)
                End If

            Case "Orden"

                If Not IsNumeric(GridTerminal.GetValue("Orden")) Then
                    GridTerminal.SetValue("Orden", GridTerminal.GetTotal(GridTerminal.CurrentTable.Columns("Orden"), Janus.Windows.GridEX.AggregateFunction.Max) + 1)
                    GridTerminal.SetValue("Modificado", 1)
                Else
                    GridTerminal.SetValue("Modificado", 1)
                End If

            Case "Estado"

                If Not IsNumeric(GridTerminal.GetValue("Estado")) Then
                    GridTerminal.SetValue("Estado", 1)
                    GridTerminal.SetValue("Modificado", 1)
                Else
                    GridTerminal.SetValue("Modificado", 1)
                End If

        End Select

    End Sub

    Private Sub GridTerminal_SelectionChanged(sender As Object, e As EventArgs) Handles GridTerminal.SelectionChanged
        If Not GridTerminal.GetValue(0) Is Nothing Then
            Me.btnDelTerminal.Enabled = True
            Me.sTerminalSelected = GridTerminal.GetValue("TERClave")
            Me.sTerminal = GridTerminal.GetValue("Clave")
        Else
            Me.btnDelTerminal.Enabled = False
            Me.sTerminalSelected = ""
            Me.sTerminal = ""
        End If
    End Sub

    Private Sub btnAddTerminal_Click(sender As Object, e As EventArgs) Handles btnAddTerminal.Click
        Dim row1 As DataRow
        row1 = dtTerminal.NewRow()
        'Valor,Descripcion,Orden,0 as Modificado,Baja 
        row1.Item("TERClave") = obtenerLlave()
        row1.Item("Clave") = ""
        row1.Item("Banco") = ""
        row1.Item("Cuenta") = ""
        row1.Item("PorcentajeCargo") = 0
        row1.Item("PinPad") = 0
        row1.Item("Orden") = GridTerminal.GetTotal(GridTerminal.CurrentTable.Columns("Orden"), Janus.Windows.GridEX.AggregateFunction.Max) + 1
        row1.Item("Estado") = 1
        row1.Item("Modificado") = 1
        row1.Item("Baja") = 0
        dtTerminal.Rows.Add(row1)
    End Sub

    Private Sub btnDelDocto_Click(sender As Object, e As EventArgs) Handles btnDelDocto.Click
        If sDoctoSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la clase de documento :" & sClase, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtDocto.Select(" IdClase = '" & sDoctoSelected & "'")
                    foundRows(0)("Baja") = 1

            End Select
        End If
    End Sub

    Private Sub BtnAddDocto_Click(sender As Object, e As EventArgs) Handles BtnAddDocto.Click
        Dim row1 As DataRow
        row1 = dtDocto.NewRow()
        'Valor,Descripcion,Orden,0 as Modificado,Baja 
        row1.Item("IdClase") = obtenerLlave()
        row1.Item("Clase") = ""
        row1.Item("Tipo") = 1
        row1.Item("Modificado") = 1
        row1.Item("Baja") = 0
        dtDocto.Rows.Add(row1)
    End Sub

    Private Sub GridDoctos_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDoctos.CellEdited
        Select Case GridDoctos.CurrentColumn.Caption
            Case "Clase"

                If GridDoctos.GetValue("Clase").GetType.Name = "DBNull" OrElse CStr(GridDoctos.GetValue("Clase")).Length = 0 Then
                    GridDoctos.SetValue("Clase", "ERROR")
                    GridDoctos.SetValue("Modificado", 0)
                Else
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtDocto.Select(" IdClase <> '" & GridDoctos.GetValue("IdClase") & "' and Baja = 0 and Clase = '" & CStr(GridDoctos.GetValue("Clase")).Trim & "'")

                    If foundRows.GetLength(0) > 0 Then
                        MessageBox.Show("¡La Clase que intenta agregar ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridDoctos.SetValue("Clase", "ERROR")
                        GridDoctos.SetValue("Modificado", 0)
                    Else
                        GridDoctos.SetValue("Clase", CStr(GridDoctos.GetValue("Clase")).Trim)
                        GridDoctos.SetValue("Modificado", 1)
                    End If
                End If

            Case "Tipo"

                If Not IsNumeric(GridDoctos.GetValue("Tipo")) Then
                    GridDoctos.SetValue("Modificado", 0)
                Else
                    'Dim foundRows() As System.Data.DataRow
                    'foundRows = dtDocto.Select(" IdClase <> '" & GridDoctos.GetValue("IdClase") & "' and Baja = 0 and Tipo = " & CStr(GridDoctos.GetValue("Tipo")))

                    'If foundRows.GetLength(0) > 0 Then
                    '    MessageBox.Show("¡El tipo de documento que intenta agregar ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    GridDoctos.SetValue("Tipo", 0)
                    '    GridDoctos.SetValue("Modificado", 0)
                    'Else
                    GridDoctos.SetValue("Modificado", 1)
                End If
                '  End If

        End Select

    End Sub

    Private Sub GridDoctos_SelectionChanged(sender As Object, e As EventArgs) Handles GridDoctos.SelectionChanged
        If Not GridDoctos.GetValue(0) Is Nothing Then
            Me.btnDelDocto.Enabled = True
            Me.sDoctoSelected = GridDoctos.GetValue("IdClase")
            Me.sClase = GridDoctos.GetValue("Clase")
        Else
            Me.btnDelDocto.Enabled = False
            Me.sDoctoSelected = ""
            Me.sClase = ""
        End If
    End Sub

    Private Sub btnAddLibro_Click(sender As Object, e As EventArgs) Handles btnAddLibro.Click
        Dim row1 As DataRow
        row1 = dtLibro.NewRow()
        'Valor,Descripcion,Orden,0 as Modificado,Baja 
        row1.Item("LIBClave") = obtenerLlave()
        row1.Item("Moneda") = ""
        row1.Item("Libro") = ""
        row1.Item("Modificado") = 1
        row1.Item("Baja") = 0
        dtLibro.Rows.Add(row1)
    End Sub

    Private Sub btnDelLibro_Click(sender As Object, e As EventArgs) Handles btnDelLibro.Click
        If sLibroSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el libro: " & sLibro, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtLibro.Select(" LIBClave = '" & sLibroSelected & "'")
                    foundRows(0)("Baja") = 1
            End Select
        End If
    End Sub

    Private Sub GridLibro_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridLibro.CellEdited
        Select Case GridLibro.CurrentColumn.Caption
            Case "Libro"
                If GridLibro.GetValue("Libro").GetType.Name = "DBNull" OrElse CStr(GridLibro.GetValue("Libro")).Length = 0 Then
                    GridLibro.SetValue("Libro", "ERROR")
                    GridLibro.SetValue("Modificado", 0)
                Else
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtLibro.Select(" LIBClave <> '" & GridLibro.GetValue("LIBClave") & "' and Baja = 0 and Libro = '" & CStr(GridLibro.GetValue("Libro")).Trim & "'")
                    If foundRows.GetLength(0) > 0 Then
                        MessageBox.Show("¡El Libro que intenta agregar ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridLibro.SetValue("Libro", "ERROR")
                        GridLibro.SetValue("Modificado", 0)
                    Else
                        GridLibro.SetValue("Libro", CStr(GridLibro.GetValue("Libro")).Trim)
                        GridLibro.SetValue("Modificado", 1)
                    End If
                End If
            Case "Moneda"
                If GridLibro.GetValue("Moneda").GetType.Name = "DBNull" OrElse CStr(GridLibro.GetValue("Moneda")).Length = 0 Then
                    GridLibro.SetValue("Moneda", "ERROR")
                    GridLibro.SetValue("Modificado", 0)
                Else
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtLibro.Select(" LIBClave <> '" & GridLibro.GetValue("LIBClave") & "' and Baja = 0 and Moneda = '" & CStr(GridLibro.GetValue("Moneda")).Trim & "'")

                    If foundRows.GetLength(0) > 0 Then
                        MessageBox.Show("¡La moneda que intenta agregar ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridLibro.SetValue("Moneda", "ERROR")
                        GridLibro.SetValue("Modificado", 0)
                    Else
                        GridLibro.SetValue("Moneda", CStr(GridLibro.GetValue("Moneda")).Trim)
                        GridLibro.SetValue("Modificado", 1)
                    End If
                End If
        End Select
    End Sub

    Private Sub GridLibro_SelectionChanged(sender As Object, e As EventArgs) Handles GridLibro.SelectionChanged
        If Not GridLibro.GetValue(0) Is Nothing Then
            btnDelLibro.Enabled = True
            Me.sLibroSelected = GridLibro.GetValue("LIBClave")
            Me.sLibro = GridLibro.GetValue("Libro")
        Else
            Me.btnDelDocto.Enabled = False
            Me.sLibroSelected = ""
            Me.sLibro = ""
        End If
    End Sub

    Private Sub btnDelLista_Click(sender As Object, e As EventArgs) Handles btnDelLista.Click
        If sListaSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se quitara de la excepción la lista de precios seleccionada", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtLista.Select(" Id = '" & sListaSelected & "'")
                    foundRows(0)("Baja") = 1

            End Select
        End If
    End Sub

    Private Sub btnAddLista_Click(sender As Object, e As EventArgs) Handles btnAddLista.Click
        Dim row1 As DataRow
        row1 = dtLista.NewRow()
        'Valor,Descripcion,Orden,0 as Modificado,Baja 
        row1.Item("Id") = obtenerLlave()
        row1.Item("Lista") = ""
        row1.Item("Modificado") = 1
        row1.Item("Baja") = 0
        dtLista.Rows.Add(row1)
    End Sub

    Private Sub GridLista_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridLista.CellEdited
        Select Case GridLista.CurrentColumn.Caption
            Case "Lista"

                If GridLista.GetValue("Lista").GetType.Name = "DBNull" OrElse CStr(GridLista.GetValue("Lista")).Length = 0 Then
                    GridLista.SetValue("Lista", "ERROR")
                    GridLista.SetValue("Modificado", 0)
                Else
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtLista.Select(" Id <> '" & GridLista.GetValue("Id") & "' and Baja = 0 and Lista = '" & CStr(GridLista.GetValue("Lista")).Trim & "'")

                    If foundRows.GetLength(0) > 0 Then
                        MessageBox.Show("¡La Lista de precios que intenta agregar ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridLista.SetValue("Lista", "ERROR")
                        GridLista.SetValue("Modificado", 0)
                    Else
                        GridLista.SetValue("Lista", CStr(GridLista.GetValue("Lista")).Trim)
                        GridLista.SetValue("Modificado", 1)
                    End If
                End If
        End Select

    End Sub

    Private Sub GridLista_SelectionChanged(sender As Object, e As EventArgs) Handles GridLista.SelectionChanged
        If Not GridLista.GetValue(0) Is Nothing Then
            btnDelLista.Enabled = True
            Me.sListaSelected = GridLista.GetValue("Id")
        Else
            Me.btnDelLista.Enabled = False
            Me.sListaSelected = ""
        End If
    End Sub

    Private Sub BtnAddBeneficiaria_Click(sender As Object, e As EventArgs) Handles BtnAddBeneficiaria.Click
        Dim row1 As DataRow
        row1 = dtBeneficiaria.NewRow()
        'Valor,Descripcion,Orden,0 as Modificado,Baja 
        row1.Item("METClave") = obtenerLlave()
        row1.Item("TipoPago") = 1
        row1.Item("Moneda") = ""
        row1.Item("Banco") = ""
        row1.Item("Cuenta") = ""
        row1.Item("Modificado") = 1
        row1.Item("Baja") = 0
        dtBeneficiaria.Rows.Add(row1)
    End Sub

    Private Sub BtnDelBeneficiaria_Click(sender As Object, e As EventArgs) Handles BtnDelBeneficiaria.Click
        If sBeneficiariaSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la Cuenta Beneficieria :" & sBeneficiaria, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtBeneficiaria.Select(" METClave = '" & sBeneficiariaSelected & "'")
                    foundRows(0)("Baja") = 1

            End Select
        End If
    End Sub

    Private Sub GridBeneficiarias_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridBeneficiarias.CellEdited
        Select Case GridBeneficiarias.CurrentColumn.Caption
            Case "Tipo Pago"

                If GridBeneficiarias.GetValue("TipoPago").GetType.Name = "DBNull" Then
                    GridBeneficiarias.SetValue("TipoPago", 0)
                    GridBeneficiarias.SetValue("Modificado", 0)
                Else
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtBeneficiaria.Select(" METClave <> '" & GridBeneficiarias.GetValue("METClave") & "' and Baja = 0 and Moneda='" & GridBeneficiarias.GetValue("Moneda") & "' and TipoPago = " & CStr(GridBeneficiarias.GetValue("TipoPago")).Trim)

                    If foundRows.GetLength(0) > 0 Then
                        MessageBox.Show("¡El tipo de pago que intenta agregar ya existe para la moneda seleccionada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridBeneficiarias.SetValue("TipoPago", 0)
                        GridBeneficiarias.SetValue("Modificado", 0)
                    Else
                        GridBeneficiarias.SetValue("TipoPago", GridBeneficiarias.GetValue("TipoPago"))
                        GridBeneficiarias.SetValue("Modificado", 1)
                    End If
                End If
            Case "Moneda"
                If GridBeneficiarias.GetValue("Moneda").GetType.Name = "DBNull" OrElse CStr(GridBeneficiarias.GetValue("Moneda")).Length = 0 Then
                    GridBeneficiarias.SetValue("Moneda", "Error")
                    GridBeneficiarias.SetValue("Modificado", 0)
                Else
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtBeneficiaria.Select(" METClave <> '" & GridBeneficiarias.GetValue("METClave") & "' and Baja = 0 and Moneda='" & GridBeneficiarias.GetValue("Moneda") & "' and TipoPago = " & CStr(GridBeneficiarias.GetValue("TipoPago")).Trim)

                    If foundRows.GetLength(0) > 0 Then
                        MessageBox.Show("¡La moneda que intenta agregar ya existe para el tipo de pago seleccionado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridBeneficiarias.SetValue("Moneda", "Error")
                        GridBeneficiarias.SetValue("Modificado", 0)
                    Else
                        GridBeneficiarias.SetValue("Moneda", CStr(GridBeneficiarias.GetValue("Moneda")))
                        GridBeneficiarias.SetValue("Modificado", 1)
                    End If
                End If

            Case "Banco"
                If GridBeneficiarias.GetValue("Banco").GetType.Name = "DBNull" OrElse CStr(GridBeneficiarias.GetValue("Banco")).Length = 0 Then
                    GridBeneficiarias.SetValue("Banco", "ERROR")
                    GridBeneficiarias.SetValue("Modificado", 0)
                Else
                    GridBeneficiarias.SetValue("Modificado", 1)
                End If

            Case "Cuenta"
                If GridBeneficiarias.GetValue("Cuenta").GetType.Name = "DBNull" OrElse CStr(GridBeneficiarias.GetValue("Cuenta")).Length = 0 Then
                    GridBeneficiarias.SetValue("Cuenta", "")
                    GridBeneficiarias.SetValue("Modificado", 0)
                Else
                    GridBeneficiarias.SetValue("Modificado", 1)
                End If



        End Select
    End Sub

    Private Sub GridBeneficiarias_SelectionChanged(sender As Object, e As EventArgs) Handles GridBeneficiarias.SelectionChanged
        If Not GridBeneficiarias.GetValue(0) Is Nothing Then
            Me.BtnDelBeneficiaria.Enabled = True
            Me.sBeneficiariaSelected = GridBeneficiarias.GetValue("METClave")
            Me.sBeneficiaria = GridBeneficiarias.GetValue("Cuenta")
        Else
            Me.BtnDelBeneficiaria.Enabled = False
            Me.sBeneficiariaSelected = ""
            Me.sBeneficiaria = ""
        End If
    End Sub

    Private Sub btnDelCte_Click(sender As Object, e As EventArgs) Handles btnDelCte.Click
        If sClienteSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se quitara de la excepción de Cliente seleccionada", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtCliente.Select(" id = '" & sClienteSelected & "'")
                    foundRows(0)("Modificado") = 1
                    foundRows(0)("Baja") = 1

            End Select
        End If
    End Sub

    Private Sub GridCliente_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridCliente.CellEdited
        Select Case GridCliente.CurrentColumn.Caption
            Case "Lista"

                If GridCliente.GetValue("Lista").GetType.Name = "DBNull" OrElse CStr(GridCliente.GetValue("Lista")).Length = 0 Then
                    GridCliente.SetValue("Lista", "ERROR")
                    GridCliente.SetValue("Modificado", 0)
                Else
                   
                    GridCliente.SetValue("Lista", CStr(GridCliente.GetValue("Lista")).Trim)
                    GridCliente.SetValue("Modificado", 1)
                End If

            Case "Canal"

                If GridCliente.GetValue("Canal").GetType.Name = "DBNull" OrElse CStr(GridCliente.GetValue("Canal")).Length = 0 Then
                    GridCliente.SetValue("Canal", -1)
                    GridCliente.SetValue("Modificado", 0)
                Else

                    GridCliente.SetValue("Canal", GridCliente.GetValue("Canal"))
                    GridCliente.SetValue("Modificado", 1)
                End If


        End Select

    End Sub

    Private Sub GridCliente_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridCliente.CurrentCellChanged
        If Not GridCliente.CurrentColumn Is Nothing Then
            If GridCliente.CurrentColumn.Caption = "Lista" OrElse GridCliente.CurrentColumn.Caption = "Canal" Then
                GridCliente.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridCliente.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

  
    Private Sub GridCliente_SelectionChanged(sender As Object, e As EventArgs) Handles GridCliente.SelectionChanged
        If Not GridCliente.GetValue(0) Is Nothing Then
            btnDelCte.Enabled = True
            Me.sClienteSelected = GridCliente.GetValue("Id")
        Else
            Me.btnDelCte.Enabled = False
            Me.sClienteSelected = ""
        End If
    End Sub

    Private Sub btnAddCte_Click(sender As Object, e As EventArgs) Handles btnAddCte.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                Dim foundRows() As System.Data.DataRow
                foundRows = dtCliente.Select(" CTEClave = '" & a.valor & "' and Baja = 0 ")
                If foundRows.GetLength(0) > 0 Then
                    MessageBox.Show("El Cliente " & a.Descripcion & ", ya cuenta con una excepción de Lista de Precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Dim row1 As DataRow
                    row1 = dtCliente.NewRow()
                    'Valor,Descripcion,Orden,0 as Modificado,Baja 
                    row1.Item("Id") = obtenerLlave()
                    row1.Item("CTEClave") = a.valor
                    row1.Item("Clave") = a.Descripcion
                    row1.Item("RazonSocial") = a.Descripcion2
                    row1.Item("Canal") = -1
                    row1.Item("Lista") = ""
                    row1.Item("Modificado") = 1
                    row1.Item("Baja") = 0
                    dtCliente.Rows.Add(row1)
                End If
            End If
            End If
            a.Dispose()
    End Sub

    Private Sub btnDelCluster_Click(sender As Object, e As EventArgs) Handles btnDelCluster.Click
        If sClusterSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la Sucursal seleccionada del Cluster actual", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtCluster.Select(" ClusterId = '" & sClusterSelected & "'")
                    foundRows(0)("Baja") = 1

            End Select
        End If
    End Sub

    Private Sub btnAddCluster_Click(sender As Object, e As EventArgs) Handles btnAddCluster.Click
        Dim row1 As DataRow
        row1 = dtCluster.NewRow()
        'Valor,Descripcion,Orden,0 as Modificado,Baja 
        row1.Item("ClusterId") = obtenerLlave()
        row1.Item("Cluster") = ""
        row1.Item("Orden") = gridCluster.GetTotal(gridCluster.CurrentTable.Columns("Orden"), Janus.Windows.GridEX.AggregateFunction.Max) + 1
        row1.Item("Modificado") = 1
        row1.Item("Baja") = 0
        dtCluster.Rows.Add(row1)
    End Sub

    Private Sub gridCluster_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles gridCluster.CellEdited
        Select Case gridCluster.CurrentColumn.Caption
            Case "Cluster"

                If gridCluster.GetValue("Cluster").GetType.Name = "DBNull" OrElse CStr(gridCluster.GetValue("Cluster")).Length = 0 Then
                    gridCluster.SetValue("Cluster", "ERROR")
                    gridCluster.SetValue("Modificado", 0)
                Else
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtCluster.Select(" ClusterId <> '" & gridCluster.GetValue("ClusterId") & "' and Baja = 0 and Cluster = '" & CStr(gridCluster.GetValue("Cluster")).Trim & "'")

                    If foundRows.GetLength(0) > 0 Then
                        MessageBox.Show("¡La Sucursal que intenta agregar ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        gridCluster.SetValue("Cluster", "ERROR")
                        gridCluster.SetValue("Modificado", 0)
                    Else
                        gridCluster.SetValue("Cluster", CStr(gridCluster.GetValue("Cluster")).Trim)
                        gridCluster.SetValue("Modificado", 1)
                    End If
                End If

            Case "Orden"

                If Not IsNumeric(gridCluster.GetValue("Orden")) Then
                    gridCluster.SetValue("Orden", gridCluster.GetTotal(gridCluster.CurrentTable.Columns("Orden"), Janus.Windows.GridEX.AggregateFunction.Max) + 1)
                    gridCluster.SetValue("Modificado", 1)
                Else
                    gridCluster.SetValue("Modificado", 1)
                End If

        End Select
    End Sub

    Private Sub gridCluster_SelectionChanged(sender As Object, e As EventArgs) Handles gridCluster.SelectionChanged
        If Not gridCluster.GetValue(0) Is Nothing Then
            Me.btnDelCluster.Enabled = True
            Me.sClusterSelected = gridCluster.GetValue("ClusterId")

        Else
            Me.btnDelCluster.Enabled = False
            Me.sClusterSelected = ""
        End If
    End Sub
End Class
