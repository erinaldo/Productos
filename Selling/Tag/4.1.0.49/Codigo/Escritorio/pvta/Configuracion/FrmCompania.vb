Imports System.Net
Imports System.Net.Mail

Public Class FrmCompania
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
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiTab1 As Janus.Windows.UI.Tab.UITab
    Friend WithEvents GrpDomicilio As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GrpIcono As System.Windows.Forms.GroupBox
    Friend WithEvents PictIcono As System.Windows.Forms.PictureBox
    Friend WithEvents GrpActividad As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents UiTabCompania As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabParam As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtFax As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents TxtTelefono As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents NumLineNota As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumLineFactura As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumCliente As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumProveedor As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumCompra As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CmbImpuesto As Selling.StoreCombo
    Friend WithEvents NumHistorico As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNoInterior As System.Windows.Forms.TextBox
    Friend WithEvents TxtNoExterior As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents TxtLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents TxtDomicilioFac As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents CmbPaisFac As Selling.StoreCombo
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents TxtRFC As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents UiTabMail As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxtHostSMTP As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TxtMailUser As System.Windows.Forms.TextBox
    Friend WithEvents TxtDisplayName As System.Windows.Forms.TextBox
    Friend WithEvents TxtMailAdress As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents ChkMailSSL As Selling.ChkStatus
    Friend WithEvents TxtMailPassword As System.Windows.Forms.TextBox
    Friend WithEvents BtnTest As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents CmbFormatOC As System.Windows.Forms.ComboBox
    Friend WithEvents NumTimeOut As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents UiTabCFD As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents BtnXML As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtXML As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoCF As Selling.StoreCombo
    Friend WithEvents cmbVersionCF As Selling.StoreCombo
    Friend WithEvents cmbRegimenFiscal As Selling.StoreCombo
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents cmbMetodoPago As Selling.StoreCombo
    Friend WithEvents PictureBox18 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox17 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox15 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox19 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox21 As System.Windows.Forms.PictureBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents PictureBox20 As System.Windows.Forms.PictureBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cmbMonedaCambio As Selling.StoreCombo
    Friend WithEvents cmbMoneda As Selling.StoreCombo
    Friend WithEvents TxtColoniaFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtMunicipioFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtEstadoFac As System.Windows.Forms.TextBox
    Friend WithEvents GrpPAC As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAddPAC As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox22 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnDelPAC As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridPAC As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbFactura As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents TxtRegPatronal As System.Windows.Forms.TextBox
    Friend WithEvents cmbRiesgoPuesto As Selling.StoreCombo
    Friend WithEvents lblRiesgo As System.Windows.Forms.Label
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents ChkAplicacion As Selling.ChkStatus
    Friend WithEvents PictureBox24 As System.Windows.Forms.PictureBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbCosteo As Selling.StoreCombo
    Friend WithEvents UiTabRiesgo As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents btnAddClase As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDelClase As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpClase As System.Windows.Forms.GroupBox
    Friend WithEvents GridClases As Janus.Windows.GridEX.GridEX
    Friend WithEvents PictureBox23 As System.Windows.Forms.PictureBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents ChkDomicilio As Selling.ChkStatus
    Friend WithEvents cmbCargo As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox27 As System.Windows.Forms.PictureBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents cmbNC As System.Windows.Forms.ComboBox
    Friend WithEvents txtReemplazo As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents PictureBox29 As System.Windows.Forms.PictureBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents cmbNomina As Selling.StoreCombo
    Friend WithEvents TxtCURP As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents ChkValidaCtaPago As Selling.ChkStatus
    Friend WithEvents ChkActPrecios As Selling.ChkStatus
    Friend WithEvents ChkPrecioBase As Selling.ChkStatus
    Friend WithEvents PictureBox30 As System.Windows.Forms.PictureBox
    Friend WithEvents LblTPersona As System.Windows.Forms.Label
    Friend WithEvents CmbTipoPersona As Selling.StoreCombo
    Friend WithEvents PictureBox31 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkCompartir As Selling.ChkStatus
    Friend WithEvents ChkTallaColor As Selling.ChkStatus
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents PictIcono2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox32 As System.Windows.Forms.PictureBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents TxtDescVale As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents numPedidosOpen As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox28 As System.Windows.Forms.PictureBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents btnVersion As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox26 As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnInterfaz As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtInterfaz As System.Windows.Forms.TextBox
    Friend WithEvents btnImagenes As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox25 As System.Windows.Forms.PictureBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents BtnExploraImg As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtImagenUrl As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents BtnExplorador As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents cmbPedido As System.Windows.Forms.ComboBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents PictureBox33 As System.Windows.Forms.PictureBox
    Friend WithEvents chkDevConcentra As Selling.ChkStatus
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents txtConcentrador As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents diasMaxDev As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtComercial As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents chkMaskCte As Selling.ChkStatus
    Friend WithEvents UiTabParam3 As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents chkCobranzaVenta As Selling.ChkStatus
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents btnEntrada As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtEntrada As System.Windows.Forms.TextBox
    Friend WithEvents txtidTerminalTA As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents numMaxMesesSinInteres As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents txtMontoMinSinInteres As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtIdComercioTA As System.Windows.Forms.TextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents txturlServicioTA As System.Windows.Forms.TextBox
    Friend WithEvents chkSincronizarCte As Selling.ChkStatus
    Friend WithEvents txtPoliticaPrivacidad As System.Windows.Forms.TextBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents chkNegados As Selling.ChkStatus
    Friend WithEvents chkAplicaPromo As Selling.ChkStatus
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents txtLimitaCompraEmp As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ChkReciboAreas As Selling.ChkStatus
    Friend WithEvents ChkLimitarCobroFac As Selling.ChkStatus
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents ChkIngresoSimple As Selling.ChkStatus
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents txtUrlVentek As System.Windows.Forms.TextBox
    Friend WithEvents txtPwdVentek As System.Windows.Forms.TextBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents txtUsuarioVentek As System.Windows.Forms.TextBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents TxtMailPort As Janus.Windows.GridEX.EditControls.NumericEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompania))
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabCompania = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.PictIcono2 = New System.Windows.Forms.PictureBox()
        Me.GrpActividad = New System.Windows.Forms.GroupBox()
        Me.txtPoliticaPrivacidad = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.txtComercial = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.PictureBox31 = New System.Windows.Forms.PictureBox()
        Me.PictureBox30 = New System.Windows.Forms.PictureBox()
        Me.CmbTipoPersona = New Selling.StoreCombo()
        Me.TxtCURP = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox13 = New System.Windows.Forms.PictureBox()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.TxtRFC = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.LblTPersona = New System.Windows.Forms.Label()
        Me.GrpIcono = New System.Windows.Forms.GroupBox()
        Me.PictIcono = New System.Windows.Forms.PictureBox()
        Me.GrpDomicilio = New System.Windows.Forms.GroupBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.cmbRiesgoPuesto = New Selling.StoreCombo()
        Me.lblRiesgo = New System.Windows.Forms.Label()
        Me.TxtRegPatronal = New System.Windows.Forms.TextBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.TxtColoniaFac = New System.Windows.Forms.TextBox()
        Me.TxtMunicipioFac = New System.Windows.Forms.TextBox()
        Me.TxtEstadoFac = New System.Windows.Forms.TextBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtNoInterior = New System.Windows.Forms.TextBox()
        Me.TxtNoExterior = New System.Windows.Forms.TextBox()
        Me.TxtCodigoPostal = New System.Windows.Forms.TextBox()
        Me.TxtLocalidad = New System.Windows.Forms.TextBox()
        Me.TxtDomicilioFac = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CmbPaisFac = New Selling.StoreCombo()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TxtFax = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.TxtTelefono = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UiTabCFD = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.PictureBox29 = New System.Windows.Forms.PictureBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.GrpPAC = New System.Windows.Forms.GroupBox()
        Me.BtnAddPAC = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox22 = New System.Windows.Forms.PictureBox()
        Me.BtnDelPAC = New Janus.Windows.EditControls.UIButton()
        Me.GridPAC = New Janus.Windows.GridEX.GridEX()
        Me.PictureBox19 = New System.Windows.Forms.PictureBox()
        Me.PictureBox18 = New System.Windows.Forms.PictureBox()
        Me.PictureBox17 = New System.Windows.Forms.PictureBox()
        Me.PictureBox16 = New System.Windows.Forms.PictureBox()
        Me.PictureBox15 = New System.Windows.Forms.PictureBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.BtnXML = New Janus.Windows.EditControls.UIButton()
        Me.TxtXML = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cmbNomina = New Selling.StoreCombo()
        Me.cmbTipoCF = New Selling.StoreCombo()
        Me.cmbVersionCF = New Selling.StoreCombo()
        Me.cmbRegimenFiscal = New Selling.StoreCombo()
        Me.cmbMetodoPago = New Selling.StoreCombo()
        Me.UiTabRiesgo = New Janus.Windows.UI.Tab.UITabPage()
        Me.btnAddClase = New Janus.Windows.EditControls.UIButton()
        Me.btnDelClase = New Janus.Windows.EditControls.UIButton()
        Me.GrpClase = New System.Windows.Forms.GroupBox()
        Me.GridClases = New Janus.Windows.GridEX.GridEX()
        Me.UiTabMail = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.btnEntrada = New Janus.Windows.EditControls.UIButton()
        Me.txtEntrada = New System.Windows.Forms.TextBox()
        Me.PictureBox28 = New System.Windows.Forms.PictureBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.btnVersion = New Janus.Windows.EditControls.UIButton()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.PictureBox26 = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnInterfaz = New Janus.Windows.EditControls.UIButton()
        Me.txtInterfaz = New System.Windows.Forms.TextBox()
        Me.btnImagenes = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox25 = New System.Windows.Forms.PictureBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.BtnExploraImg = New Janus.Windows.EditControls.UIButton()
        Me.TxtImagenUrl = New System.Windows.Forms.TextBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.BtnExplorador = New Janus.Windows.EditControls.UIButton()
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TxtMailPort = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.BtnTest = New Janus.Windows.EditControls.UIButton()
        Me.TxtMailPassword = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtHostSMTP = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TxtMailUser = New System.Windows.Forms.TextBox()
        Me.TxtDisplayName = New System.Windows.Forms.TextBox()
        Me.TxtMailAdress = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.ChkMailSSL = New Selling.ChkStatus(Me.components)
        Me.UiTabParam = New Janus.Windows.UI.Tab.UITabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.txtLimitaCompraEmp = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.chkAplicaPromo = New Selling.ChkStatus(Me.components)
        Me.chkMaskCte = New Selling.ChkStatus(Me.components)
        Me.diasMaxDev = New System.Windows.Forms.NumericUpDown()
        Me.txtConcentrador = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.chkDevConcentra = New Selling.ChkStatus(Me.components)
        Me.PictureBox33 = New System.Windows.Forms.PictureBox()
        Me.cmbPedido = New System.Windows.Forms.ComboBox()
        Me.numPedidosOpen = New System.Windows.Forms.NumericUpDown()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.PictureBox32 = New System.Windows.Forms.PictureBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.TxtDescVale = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtReemplazo = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cmbCargo = New System.Windows.Forms.ComboBox()
        Me.PictureBox27 = New System.Windows.Forms.PictureBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.cmbNC = New System.Windows.Forms.ComboBox()
        Me.PictureBox23 = New System.Windows.Forms.PictureBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.PictureBox24 = New System.Windows.Forms.PictureBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.cmbFactura = New System.Windows.Forms.ComboBox()
        Me.PictureBox21 = New System.Windows.Forms.PictureBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.PictureBox20 = New System.Windows.Forms.PictureBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.NumTimeOut = New System.Windows.Forms.NumericUpDown()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.PictureBox14 = New System.Windows.Forms.PictureBox()
        Me.CmbFormatOC = New System.Windows.Forms.ComboBox()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.NumHistorico = New System.Windows.Forms.NumericUpDown()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.ChkTallaColor = New Selling.ChkStatus(Me.components)
        Me.ChkCompartir = New Selling.ChkStatus(Me.components)
        Me.ChkPrecioBase = New Selling.ChkStatus(Me.components)
        Me.ChkActPrecios = New Selling.ChkStatus(Me.components)
        Me.ChkValidaCtaPago = New Selling.ChkStatus(Me.components)
        Me.ChkDomicilio = New Selling.ChkStatus(Me.components)
        Me.cmbCosteo = New Selling.StoreCombo()
        Me.ChkAplicacion = New Selling.ChkStatus(Me.components)
        Me.cmbMonedaCambio = New Selling.StoreCombo()
        Me.cmbMoneda = New Selling.StoreCombo()
        Me.CmbImpuesto = New Selling.StoreCombo()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.NumLineNota = New System.Windows.Forms.NumericUpDown()
        Me.NumLineFactura = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NumCliente = New System.Windows.Forms.NumericUpDown()
        Me.NumProveedor = New System.Windows.Forms.NumericUpDown()
        Me.NumCompra = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.UiTabParam3 = New Janus.Windows.UI.Tab.UITabPage()
        Me.ChkIngresoSimple = New Selling.ChkStatus(Me.components)
        Me.Label62 = New System.Windows.Forms.Label()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.ChkReciboAreas = New Selling.ChkStatus(Me.components)
        Me.ChkLimitarCobroFac = New Selling.ChkStatus(Me.components)
        Me.chkNegados = New Selling.ChkStatus(Me.components)
        Me.chkSincronizarCte = New Selling.ChkStatus(Me.components)
        Me.Label59 = New System.Windows.Forms.Label()
        Me.txturlServicioTA = New System.Windows.Forms.TextBox()
        Me.txtidTerminalTA = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.numMaxMesesSinInteres = New System.Windows.Forms.NumericUpDown()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.txtMontoMinSinInteres = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtIdComercioTA = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.chkCobranzaVenta = New Selling.ChkStatus(Me.components)
        Me.Label63 = New System.Windows.Forms.Label()
        Me.txtUrlVentek = New System.Windows.Forms.TextBox()
        Me.txtPwdVentek = New System.Windows.Forms.TextBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.txtUsuarioVentek = New System.Windows.Forms.TextBox()
        Me.Label65 = New System.Windows.Forms.Label()
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabCompania.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.PictIcono2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpActividad.SuspendLayout()
        CType(Me.PictureBox31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpIcono.SuspendLayout()
        CType(Me.PictIcono, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDomicilio.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabCFD.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.PictureBox29, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpPAC.SuspendLayout()
        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPAC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabRiesgo.SuspendLayout()
        Me.GrpClase.SuspendLayout()
        CType(Me.GridClases, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabMail.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.UiTabParam.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.diasMaxDev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPedidosOpen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumTimeOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumHistorico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NumLineNota, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumLineFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabParam3.SuspendLayout()
        CType(Me.numMaxMesesSinInteres, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(595, 583)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 10
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(499, 583)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 11
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTab1
        '
        Me.UiTab1.Location = New System.Drawing.Point(7, 7)
        Me.UiTab1.Name = "UiTab1"
        Me.UiTab1.Size = New System.Drawing.Size(678, 570)
        Me.UiTab1.TabIndex = 19
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabCompania, Me.UiTabCFD, Me.UiTabRiesgo, Me.UiTabMail, Me.UiTabParam, Me.UiTabParam3})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabCompania
        '
        Me.UiTabCompania.Controls.Add(Me.GroupBox7)
        Me.UiTabCompania.Controls.Add(Me.GrpActividad)
        Me.UiTabCompania.Controls.Add(Me.GrpIcono)
        Me.UiTabCompania.Controls.Add(Me.GrpDomicilio)
        Me.UiTabCompania.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCompania.Name = "UiTabCompania"
        Me.UiTabCompania.Size = New System.Drawing.Size(676, 548)
        Me.UiTabCompania.TabStop = True
        Me.UiTabCompania.Text = "General"
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Controls.Add(Me.PictIcono2)
        Me.GroupBox7.Location = New System.Drawing.Point(356, 179)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(315, 162)
        Me.GroupBox7.TabIndex = 22
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Logo2 (518 x 262)"
        '
        'PictIcono2
        '
        Me.PictIcono2.BackColor = System.Drawing.Color.Transparent
        Me.PictIcono2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictIcono2.Location = New System.Drawing.Point(7, 18)
        Me.PictIcono2.Name = "PictIcono2"
        Me.PictIcono2.Size = New System.Drawing.Size(302, 139)
        Me.PictIcono2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictIcono2.TabIndex = 0
        Me.PictIcono2.TabStop = False
        '
        'GrpActividad
        '
        Me.GrpActividad.BackColor = System.Drawing.Color.Transparent
        Me.GrpActividad.Controls.Add(Me.txtPoliticaPrivacidad)
        Me.GrpActividad.Controls.Add(Me.Label60)
        Me.GrpActividad.Controls.Add(Me.txtComercial)
        Me.GrpActividad.Controls.Add(Me.Label53)
        Me.GrpActividad.Controls.Add(Me.PictureBox31)
        Me.GrpActividad.Controls.Add(Me.PictureBox30)
        Me.GrpActividad.Controls.Add(Me.CmbTipoPersona)
        Me.GrpActividad.Controls.Add(Me.TxtCURP)
        Me.GrpActividad.Controls.Add(Me.Label47)
        Me.GrpActividad.Controls.Add(Me.PictureBox1)
        Me.GrpActividad.Controls.Add(Me.PictureBox13)
        Me.GrpActividad.Controls.Add(Me.lblRFC)
        Me.GrpActividad.Controls.Add(Me.TxtRFC)
        Me.GrpActividad.Controls.Add(Me.TxtNombre)
        Me.GrpActividad.Controls.Add(Me.LblNombre)
        Me.GrpActividad.Controls.Add(Me.LblClave)
        Me.GrpActividad.Controls.Add(Me.TxtClave)
        Me.GrpActividad.Controls.Add(Me.LblTPersona)
        Me.GrpActividad.Location = New System.Drawing.Point(10, 5)
        Me.GrpActividad.Name = "GrpActividad"
        Me.GrpActividad.Size = New System.Drawing.Size(661, 171)
        Me.GrpActividad.TabIndex = 19
        Me.GrpActividad.TabStop = False
        Me.GrpActividad.Text = "Compañia"
        '
        'txtPoliticaPrivacidad
        '
        Me.txtPoliticaPrivacidad.Location = New System.Drawing.Point(124, 120)
        Me.txtPoliticaPrivacidad.Name = "txtPoliticaPrivacidad"
        Me.txtPoliticaPrivacidad.Size = New System.Drawing.Size(400, 20)
        Me.txtPoliticaPrivacidad.TabIndex = 67
        '
        'Label60
        '
        Me.Label60.Location = New System.Drawing.Point(5, 123)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(126, 14)
        Me.Label60.TabIndex = 68
        Me.Label60.Text = "Política de Privacidad"
        '
        'txtComercial
        '
        Me.txtComercial.Location = New System.Drawing.Point(124, 69)
        Me.txtComercial.Name = "txtComercial"
        Me.txtComercial.Size = New System.Drawing.Size(248, 20)
        Me.txtComercial.TabIndex = 65
        '
        'Label53
        '
        Me.Label53.Location = New System.Drawing.Point(5, 72)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(93, 14)
        Me.Label53.TabIndex = 66
        Me.Label53.Text = "Nom. Comercial"
        '
        'PictureBox31
        '
        Me.PictureBox31.Image = CType(resources.GetObject("PictureBox31.Image"), System.Drawing.Image)
        Me.PictureBox31.Location = New System.Drawing.Point(43, 145)
        Me.PictureBox31.Name = "PictureBox31"
        Me.PictureBox31.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox31.TabIndex = 64
        Me.PictureBox31.TabStop = False
        Me.PictureBox31.Visible = False
        '
        'PictureBox30
        '
        Me.PictureBox30.Image = CType(resources.GetObject("PictureBox30.Image"), System.Drawing.Image)
        Me.PictureBox30.Location = New System.Drawing.Point(47, 95)
        Me.PictureBox30.Name = "PictureBox30"
        Me.PictureBox30.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox30.TabIndex = 63
        Me.PictureBox30.TabStop = False
        Me.PictureBox30.Visible = False
        '
        'CmbTipoPersona
        '
        Me.CmbTipoPersona.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipoPersona.Location = New System.Drawing.Point(124, 93)
        Me.CmbTipoPersona.Name = "CmbTipoPersona"
        Me.CmbTipoPersona.Size = New System.Drawing.Size(153, 21)
        Me.CmbTipoPersona.TabIndex = 61
        '
        'TxtCURP
        '
        Me.TxtCURP.Location = New System.Drawing.Point(124, 145)
        Me.TxtCURP.Name = "TxtCURP"
        Me.TxtCURP.Size = New System.Drawing.Size(248, 20)
        Me.TxtCURP.TabIndex = 59
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(5, 148)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(75, 14)
        Me.Label47.TabIndex = 60
        Me.Label47.Text = "CURP"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(45, 45)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 16)
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox13
        '
        Me.PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), System.Drawing.Image)
        Me.PictureBox13.Location = New System.Drawing.Point(347, 94)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox13.TabIndex = 58
        Me.PictureBox13.TabStop = False
        Me.PictureBox13.Visible = False
        '
        'lblRFC
        '
        Me.lblRFC.Location = New System.Drawing.Point(307, 96)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(34, 15)
        Me.lblRFC.TabIndex = 57
        Me.lblRFC.Text = "RFC"
        '
        'TxtRFC
        '
        Me.TxtRFC.Location = New System.Drawing.Point(397, 93)
        Me.TxtRFC.Mask = "AAAA00000aaaa"
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.Size = New System.Drawing.Size(127, 20)
        Me.TxtRFC.TabIndex = 2
        Me.TxtRFC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(124, 44)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(400, 20)
        Me.TxtNombre.TabIndex = 1
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(5, 47)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(75, 14)
        Me.LblNombre.TabIndex = 3
        Me.LblNombre.Text = "Razon Social"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(7, 20)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(60, 15)
        Me.LblClave.TabIndex = 1
        Me.LblClave.Text = "Clave"
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(124, 17)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(140, 20)
        Me.TxtClave.TabIndex = 0
        '
        'LblTPersona
        '
        Me.LblTPersona.Location = New System.Drawing.Point(5, 99)
        Me.LblTPersona.Name = "LblTPersona"
        Me.LblTPersona.Size = New System.Drawing.Size(93, 15)
        Me.LblTPersona.TabIndex = 62
        Me.LblTPersona.Text = "T. Persona"
        '
        'GrpIcono
        '
        Me.GrpIcono.BackColor = System.Drawing.Color.Transparent
        Me.GrpIcono.Controls.Add(Me.PictIcono)
        Me.GrpIcono.Location = New System.Drawing.Point(10, 179)
        Me.GrpIcono.Name = "GrpIcono"
        Me.GrpIcono.Size = New System.Drawing.Size(315, 162)
        Me.GrpIcono.TabIndex = 20
        Me.GrpIcono.TabStop = False
        Me.GrpIcono.Text = "Logo (518 x 262)"
        '
        'PictIcono
        '
        Me.PictIcono.BackColor = System.Drawing.Color.Transparent
        Me.PictIcono.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictIcono.Location = New System.Drawing.Point(7, 18)
        Me.PictIcono.Name = "PictIcono"
        Me.PictIcono.Size = New System.Drawing.Size(302, 139)
        Me.PictIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictIcono.TabIndex = 0
        Me.PictIcono.TabStop = False
        '
        'GrpDomicilio
        '
        Me.GrpDomicilio.BackColor = System.Drawing.Color.Transparent
        Me.GrpDomicilio.Controls.Add(Me.PictureBox3)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox5)
        Me.GrpDomicilio.Controls.Add(Me.cmbRiesgoPuesto)
        Me.GrpDomicilio.Controls.Add(Me.lblRiesgo)
        Me.GrpDomicilio.Controls.Add(Me.TxtRegPatronal)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox6)
        Me.GrpDomicilio.Controls.Add(Me.TxtColoniaFac)
        Me.GrpDomicilio.Controls.Add(Me.TxtMunicipioFac)
        Me.GrpDomicilio.Controls.Add(Me.TxtEstadoFac)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox7)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox8)
        Me.GrpDomicilio.Controls.Add(Me.Label1)
        Me.GrpDomicilio.Controls.Add(Me.TxtReferencia)
        Me.GrpDomicilio.Controls.Add(Me.Label4)
        Me.GrpDomicilio.Controls.Add(Me.TxtNoInterior)
        Me.GrpDomicilio.Controls.Add(Me.TxtNoExterior)
        Me.GrpDomicilio.Controls.Add(Me.TxtCodigoPostal)
        Me.GrpDomicilio.Controls.Add(Me.TxtLocalidad)
        Me.GrpDomicilio.Controls.Add(Me.TxtDomicilioFac)
        Me.GrpDomicilio.Controls.Add(Me.Label6)
        Me.GrpDomicilio.Controls.Add(Me.Label18)
        Me.GrpDomicilio.Controls.Add(Me.Label19)
        Me.GrpDomicilio.Controls.Add(Me.CmbPaisFac)
        Me.GrpDomicilio.Controls.Add(Me.Label21)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox9)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox4)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox2)
        Me.GrpDomicilio.Controls.Add(Me.TxtFax)
        Me.GrpDomicilio.Controls.Add(Me.TxtTelefono)
        Me.GrpDomicilio.Controls.Add(Me.Label7)
        Me.GrpDomicilio.Controls.Add(Me.Label8)
        Me.GrpDomicilio.Controls.Add(Me.Label2)
        Me.GrpDomicilio.Controls.Add(Me.Label3)
        Me.GrpDomicilio.Controls.Add(Me.Label33)
        Me.GrpDomicilio.Controls.Add(Me.Label20)
        Me.GrpDomicilio.Controls.Add(Me.Label5)
        Me.GrpDomicilio.Location = New System.Drawing.Point(10, 343)
        Me.GrpDomicilio.Name = "GrpDomicilio"
        Me.GrpDomicilio.Size = New System.Drawing.Size(661, 202)
        Me.GrpDomicilio.TabIndex = 21
        Me.GrpDomicilio.TabStop = False
        Me.GrpDomicilio.Text = "Domicilio"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(567, 23)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(22, 16)
        Me.PictureBox3.TabIndex = 31
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(567, 48)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox5.TabIndex = 33
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'cmbRiesgoPuesto
        '
        Me.cmbRiesgoPuesto.BackColor = System.Drawing.SystemColors.Window
        Me.cmbRiesgoPuesto.Location = New System.Drawing.Point(433, 176)
        Me.cmbRiesgoPuesto.Name = "cmbRiesgoPuesto"
        Me.cmbRiesgoPuesto.Size = New System.Drawing.Size(140, 21)
        Me.cmbRiesgoPuesto.TabIndex = 103
        '
        'lblRiesgo
        '
        Me.lblRiesgo.Location = New System.Drawing.Point(329, 178)
        Me.lblRiesgo.Name = "lblRiesgo"
        Me.lblRiesgo.Size = New System.Drawing.Size(96, 17)
        Me.lblRiesgo.TabIndex = 102
        Me.lblRiesgo.Text = "Riesgo Puesto"
        '
        'TxtRegPatronal
        '
        Me.TxtRegPatronal.Location = New System.Drawing.Point(88, 175)
        Me.TxtRegPatronal.Name = "TxtRegPatronal"
        Me.TxtRegPatronal.Size = New System.Drawing.Size(165, 20)
        Me.TxtRegPatronal.TabIndex = 100
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(335, 71)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(19, 24)
        Me.PictureBox6.TabIndex = 34
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'TxtColoniaFac
        '
        Me.TxtColoniaFac.Location = New System.Drawing.Point(88, 71)
        Me.TxtColoniaFac.Name = "TxtColoniaFac"
        Me.TxtColoniaFac.Size = New System.Drawing.Size(251, 20)
        Me.TxtColoniaFac.TabIndex = 5
        '
        'TxtMunicipioFac
        '
        Me.TxtMunicipioFac.Location = New System.Drawing.Point(88, 45)
        Me.TxtMunicipioFac.Name = "TxtMunicipioFac"
        Me.TxtMunicipioFac.Size = New System.Drawing.Size(166, 20)
        Me.TxtMunicipioFac.TabIndex = 3
        '
        'TxtEstadoFac
        '
        Me.TxtEstadoFac.Location = New System.Drawing.Point(381, 19)
        Me.TxtEstadoFac.Name = "TxtEstadoFac"
        Me.TxtEstadoFac.Size = New System.Drawing.Size(192, 20)
        Me.TxtEstadoFac.TabIndex = 2
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(567, 72)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(27, 18)
        Me.PictureBox7.TabIndex = 35
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(345, 96)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(27, 20)
        Me.PictureBox8.TabIndex = 36
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 15)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Referencia"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(88, 122)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(251, 20)
        Me.TxtReferencia.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(365, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 15)
        Me.Label4.TabIndex = 95
        Me.Label4.Text = "Código Postal"
        '
        'TxtNoInterior
        '
        Me.TxtNoInterior.Location = New System.Drawing.Point(518, 96)
        Me.TxtNoInterior.Name = "TxtNoInterior"
        Me.TxtNoInterior.Size = New System.Drawing.Size(55, 20)
        Me.TxtNoInterior.TabIndex = 9
        '
        'TxtNoExterior
        '
        Me.TxtNoExterior.Location = New System.Drawing.Point(383, 98)
        Me.TxtNoExterior.Name = "TxtNoExterior"
        Me.TxtNoExterior.Size = New System.Drawing.Size(55, 20)
        Me.TxtNoExterior.TabIndex = 8
        '
        'TxtCodigoPostal
        '
        Me.TxtCodigoPostal.Location = New System.Drawing.Point(451, 71)
        Me.TxtCodigoPostal.Name = "TxtCodigoPostal"
        Me.TxtCodigoPostal.Size = New System.Drawing.Size(122, 20)
        Me.TxtCodigoPostal.TabIndex = 6
        '
        'TxtLocalidad
        '
        Me.TxtLocalidad.Location = New System.Drawing.Point(381, 45)
        Me.TxtLocalidad.Name = "TxtLocalidad"
        Me.TxtLocalidad.Size = New System.Drawing.Size(192, 20)
        Me.TxtLocalidad.TabIndex = 4
        '
        'TxtDomicilioFac
        '
        Me.TxtDomicilioFac.Location = New System.Drawing.Point(88, 96)
        Me.TxtDomicilioFac.Name = "TxtDomicilioFac"
        Me.TxtDomicilioFac.Size = New System.Drawing.Size(251, 20)
        Me.TxtDomicilioFac.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(5, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 15)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "Calle"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(5, 71)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 18)
        Me.Label18.TabIndex = 88
        Me.Label18.Text = "Colonia"
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(5, 47)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 15)
        Me.Label19.TabIndex = 87
        Me.Label19.Text = "Municipio"
        '
        'CmbPaisFac
        '
        Me.CmbPaisFac.Location = New System.Drawing.Point(88, 18)
        Me.CmbPaisFac.Name = "CmbPaisFac"
        Me.CmbPaisFac.Size = New System.Drawing.Size(165, 21)
        Me.CmbPaisFac.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(5, 21)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 15)
        Me.Label21.TabIndex = 85
        Me.Label21.Text = "País"
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(444, 100)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(24, 18)
        Me.PictureBox9.TabIndex = 37
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(285, 48)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox4.TabIndex = 32
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(263, 22)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 17)
        Me.PictureBox2.TabIndex = 30
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TxtFax
        '
        Me.TxtFax.Location = New System.Drawing.Point(433, 147)
        Me.TxtFax.Mask = "!(##) 000 00 0 00 00"
        Me.TxtFax.Name = "TxtFax"
        Me.TxtFax.Size = New System.Drawing.Size(140, 20)
        Me.TxtFax.TabIndex = 12
        Me.TxtFax.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(88, 149)
        Me.TxtTelefono.Mask = "!(##) 000 00 0 00 00"
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(165, 20)
        Me.TxtTelefono.TabIndex = 11
        Me.TxtTelefono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(348, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 15)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Fax"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(5, 150)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 15)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Telefono"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(474, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 14)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "No. Int."
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(342, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 17)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "No. Ext."
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(6, 176)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(76, 17)
        Me.Label33.TabIndex = 101
        Me.Label33.Text = "Reg. Patronal"
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(283, 22)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(81, 16)
        Me.Label20.TabIndex = 86
        Me.Label20.Text = "Entidad/Estado"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(283, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 14)
        Me.Label5.TabIndex = 94
        Me.Label5.Text = "Ciudad/Población"
        '
        'UiTabCFD
        '
        Me.UiTabCFD.Controls.Add(Me.GroupBox6)
        Me.UiTabCFD.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCFD.Name = "UiTabCFD"
        Me.UiTabCFD.Size = New System.Drawing.Size(676, 548)
        Me.UiTabCFD.TabStop = True
        Me.UiTabCFD.Text = "Comprobante Fiscal"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.PictureBox29)
        Me.GroupBox6.Controls.Add(Me.Label46)
        Me.GroupBox6.Controls.Add(Me.GrpPAC)
        Me.GroupBox6.Controls.Add(Me.PictureBox19)
        Me.GroupBox6.Controls.Add(Me.PictureBox18)
        Me.GroupBox6.Controls.Add(Me.PictureBox17)
        Me.GroupBox6.Controls.Add(Me.PictureBox16)
        Me.GroupBox6.Controls.Add(Me.PictureBox15)
        Me.GroupBox6.Controls.Add(Me.Label38)
        Me.GroupBox6.Controls.Add(Me.Label24)
        Me.GroupBox6.Controls.Add(Me.BtnXML)
        Me.GroupBox6.Controls.Add(Me.TxtXML)
        Me.GroupBox6.Controls.Add(Me.Label34)
        Me.GroupBox6.Controls.Add(Me.Label35)
        Me.GroupBox6.Controls.Add(Me.Label36)
        Me.GroupBox6.Controls.Add(Me.cmbNomina)
        Me.GroupBox6.Controls.Add(Me.cmbTipoCF)
        Me.GroupBox6.Controls.Add(Me.cmbVersionCF)
        Me.GroupBox6.Controls.Add(Me.cmbRegimenFiscal)
        Me.GroupBox6.Controls.Add(Me.cmbMetodoPago)
        Me.GroupBox6.Location = New System.Drawing.Point(5, 7)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(666, 538)
        Me.GroupBox6.TabIndex = 23
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Configuración de Comprobantes Fiscales"
        '
        'PictureBox29
        '
        Me.PictureBox29.Image = CType(resources.GetObject("PictureBox29.Image"), System.Drawing.Image)
        Me.PictureBox29.Location = New System.Drawing.Point(351, 62)
        Me.PictureBox29.Name = "PictureBox29"
        Me.PictureBox29.Size = New System.Drawing.Size(18, 17)
        Me.PictureBox29.TabIndex = 128
        Me.PictureBox29.TabStop = False
        Me.PictureBox29.Visible = False
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(7, 63)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(129, 14)
        Me.Label46.TabIndex = 126
        Me.Label46.Text = "Versión Nomina"
        '
        'GrpPAC
        '
        Me.GrpPAC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpPAC.BackColor = System.Drawing.Color.Transparent
        Me.GrpPAC.Controls.Add(Me.BtnAddPAC)
        Me.GrpPAC.Controls.Add(Me.PictureBox22)
        Me.GrpPAC.Controls.Add(Me.BtnDelPAC)
        Me.GrpPAC.Controls.Add(Me.GridPAC)
        Me.GrpPAC.Location = New System.Drawing.Point(11, 194)
        Me.GrpPAC.Name = "GrpPAC"
        Me.GrpPAC.Size = New System.Drawing.Size(649, 338)
        Me.GrpPAC.TabIndex = 125
        Me.GrpPAC.TabStop = False
        Me.GrpPAC.Text = "Proveedores Autorizados de Certificación"
        '
        'BtnAddPAC
        '
        Me.BtnAddPAC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAddPAC.Icon = CType(resources.GetObject("BtnAddPAC.Icon"), System.Drawing.Icon)
        Me.BtnAddPAC.Location = New System.Drawing.Point(604, 10)
        Me.BtnAddPAC.Name = "BtnAddPAC"
        Me.BtnAddPAC.Size = New System.Drawing.Size(33, 22)
        Me.BtnAddPAC.TabIndex = 101
        Me.BtnAddPAC.ToolTipText = "Agregar nuevo PAC"
        Me.BtnAddPAC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox22
        '
        Me.PictureBox22.Image = CType(resources.GetObject("PictureBox22.Image"), System.Drawing.Image)
        Me.PictureBox22.Location = New System.Drawing.Point(217, 19)
        Me.PictureBox22.Name = "PictureBox22"
        Me.PictureBox22.Size = New System.Drawing.Size(19, 16)
        Me.PictureBox22.TabIndex = 74
        Me.PictureBox22.TabStop = False
        Me.PictureBox22.Visible = False
        '
        'BtnDelPAC
        '
        Me.BtnDelPAC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelPAC.Icon = CType(resources.GetObject("BtnDelPAC.Icon"), System.Drawing.Icon)
        Me.BtnDelPAC.Location = New System.Drawing.Point(564, 10)
        Me.BtnDelPAC.Name = "BtnDelPAC"
        Me.BtnDelPAC.Size = New System.Drawing.Size(34, 22)
        Me.BtnDelPAC.TabIndex = 5
        Me.BtnDelPAC.ToolTipText = "Eliminar PAC seleccionado"
        Me.BtnDelPAC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridPAC
        '
        Me.GridPAC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPAC.ColumnAutoResize = True
        Me.GridPAC.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPAC.Location = New System.Drawing.Point(10, 36)
        Me.GridPAC.Name = "GridPAC"
        Me.GridPAC.RecordNavigator = True
        Me.GridPAC.Size = New System.Drawing.Size(628, 296)
        Me.GridPAC.TabIndex = 4
        Me.GridPAC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PictureBox19
        '
        Me.PictureBox19.Image = CType(resources.GetObject("PictureBox19.Image"), System.Drawing.Image)
        Me.PictureBox19.Location = New System.Drawing.Point(98, 165)
        Me.PictureBox19.Name = "PictureBox19"
        Me.PictureBox19.Size = New System.Drawing.Size(19, 17)
        Me.PictureBox19.TabIndex = 64
        Me.PictureBox19.TabStop = False
        Me.PictureBox19.Visible = False
        '
        'PictureBox18
        '
        Me.PictureBox18.Image = CType(resources.GetObject("PictureBox18.Image"), System.Drawing.Image)
        Me.PictureBox18.Location = New System.Drawing.Point(501, 136)
        Me.PictureBox18.Name = "PictureBox18"
        Me.PictureBox18.Size = New System.Drawing.Size(18, 17)
        Me.PictureBox18.TabIndex = 124
        Me.PictureBox18.TabStop = False
        Me.PictureBox18.Visible = False
        '
        'PictureBox17
        '
        Me.PictureBox17.Image = CType(resources.GetObject("PictureBox17.Image"), System.Drawing.Image)
        Me.PictureBox17.Location = New System.Drawing.Point(501, 113)
        Me.PictureBox17.Name = "PictureBox17"
        Me.PictureBox17.Size = New System.Drawing.Size(18, 17)
        Me.PictureBox17.TabIndex = 123
        Me.PictureBox17.TabStop = False
        Me.PictureBox17.Visible = False
        '
        'PictureBox16
        '
        Me.PictureBox16.Image = CType(resources.GetObject("PictureBox16.Image"), System.Drawing.Image)
        Me.PictureBox16.Location = New System.Drawing.Point(352, 89)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(18, 17)
        Me.PictureBox16.TabIndex = 122
        Me.PictureBox16.TabStop = False
        Me.PictureBox16.Visible = False
        '
        'PictureBox15
        '
        Me.PictureBox15.Image = CType(resources.GetObject("PictureBox15.Image"), System.Drawing.Image)
        Me.PictureBox15.Location = New System.Drawing.Point(352, 33)
        Me.PictureBox15.Name = "PictureBox15"
        Me.PictureBox15.Size = New System.Drawing.Size(18, 17)
        Me.PictureBox15.TabIndex = 121
        Me.PictureBox15.TabStop = False
        Me.PictureBox15.Visible = False
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(8, 141)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(172, 19)
        Me.Label38.TabIndex = 117
        Me.Label38.Text = "Metodo de Pago Predeterminado"
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(8, 169)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(105, 16)
        Me.Label24.TabIndex = 72
        Me.Label24.Text = "Repositorio XML"
        '
        'BtnXML
        '
        Me.BtnXML.Image = CType(resources.GetObject("BtnXML.Image"), System.Drawing.Image)
        Me.BtnXML.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnXML.Location = New System.Drawing.Point(506, 154)
        Me.BtnXML.Name = "BtnXML"
        Me.BtnXML.Size = New System.Drawing.Size(33, 30)
        Me.BtnXML.TabIndex = 71
        '
        'TxtXML
        '
        Me.TxtXML.Location = New System.Drawing.Point(118, 164)
        Me.TxtXML.Name = "TxtXML"
        Me.TxtXML.Size = New System.Drawing.Size(378, 20)
        Me.TxtXML.TabIndex = 70
        Me.TxtXML.TabStop = False
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(8, 34)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(128, 14)
        Me.Label34.TabIndex = 89
        Me.Label34.Text = "Tipo Comprobante"
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(8, 115)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(117, 17)
        Me.Label35.TabIndex = 88
        Me.Label35.Text = "Regimen Fiscal"
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(8, 90)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(129, 14)
        Me.Label36.TabIndex = 87
        Me.Label36.Text = "Versión CFD"
        '
        'cmbNomina
        '
        Me.cmbNomina.Location = New System.Drawing.Point(185, 59)
        Me.cmbNomina.Name = "cmbNomina"
        Me.cmbNomina.Size = New System.Drawing.Size(161, 21)
        Me.cmbNomina.TabIndex = 127
        '
        'cmbTipoCF
        '
        Me.cmbTipoCF.Location = New System.Drawing.Point(186, 29)
        Me.cmbTipoCF.Name = "cmbTipoCF"
        Me.cmbTipoCF.Size = New System.Drawing.Size(161, 21)
        Me.cmbTipoCF.TabIndex = 120
        '
        'cmbVersionCF
        '
        Me.cmbVersionCF.Location = New System.Drawing.Point(186, 86)
        Me.cmbVersionCF.Name = "cmbVersionCF"
        Me.cmbVersionCF.Size = New System.Drawing.Size(161, 21)
        Me.cmbVersionCF.TabIndex = 119
        '
        'cmbRegimenFiscal
        '
        Me.cmbRegimenFiscal.Location = New System.Drawing.Point(186, 112)
        Me.cmbRegimenFiscal.Name = "cmbRegimenFiscal"
        Me.cmbRegimenFiscal.Size = New System.Drawing.Size(310, 21)
        Me.cmbRegimenFiscal.TabIndex = 118
        '
        'cmbMetodoPago
        '
        Me.cmbMetodoPago.Location = New System.Drawing.Point(185, 138)
        Me.cmbMetodoPago.Name = "cmbMetodoPago"
        Me.cmbMetodoPago.Size = New System.Drawing.Size(311, 21)
        Me.cmbMetodoPago.TabIndex = 116
        '
        'UiTabRiesgo
        '
        Me.UiTabRiesgo.Controls.Add(Me.btnAddClase)
        Me.UiTabRiesgo.Controls.Add(Me.btnDelClase)
        Me.UiTabRiesgo.Controls.Add(Me.GrpClase)
        Me.UiTabRiesgo.Location = New System.Drawing.Point(1, 21)
        Me.UiTabRiesgo.Name = "UiTabRiesgo"
        Me.UiTabRiesgo.Size = New System.Drawing.Size(676, 548)
        Me.UiTabRiesgo.TabStop = True
        Me.UiTabRiesgo.Text = "Clases de Riesgo"
        '
        'btnAddClase
        '
        Me.btnAddClase.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddClase.Icon = CType(resources.GetObject("btnAddClase.Icon"), System.Drawing.Icon)
        Me.btnAddClase.Location = New System.Drawing.Point(636, 3)
        Me.btnAddClase.Name = "btnAddClase"
        Me.btnAddClase.Size = New System.Drawing.Size(33, 22)
        Me.btnAddClase.TabIndex = 103
        Me.btnAddClase.ToolTipText = "Agregar nueva clase de riesgo"
        Me.btnAddClase.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnDelClase
        '
        Me.btnDelClase.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelClase.Icon = CType(resources.GetObject("btnDelClase.Icon"), System.Drawing.Icon)
        Me.btnDelClase.Location = New System.Drawing.Point(595, 3)
        Me.btnDelClase.Name = "btnDelClase"
        Me.btnDelClase.Size = New System.Drawing.Size(34, 22)
        Me.btnDelClase.TabIndex = 102
        Me.btnDelClase.ToolTipText = "Eliminar clase de riesgo seleccionada"
        Me.btnDelClase.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpClase
        '
        Me.GrpClase.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpClase.BackColor = System.Drawing.Color.Transparent
        Me.GrpClase.Controls.Add(Me.GridClases)
        Me.GrpClase.Location = New System.Drawing.Point(1, 24)
        Me.GrpClase.Name = "GrpClase"
        Me.GrpClase.Size = New System.Drawing.Size(669, 521)
        Me.GrpClase.TabIndex = 12
        Me.GrpClase.TabStop = False
        Me.GrpClase.Text = "Clases"
        '
        'GridClases
        '
        Me.GridClases.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridClases.ColumnAutoResize = True
        Me.GridClases.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridClases.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridClases.GroupByBoxVisible = False
        Me.GridClases.Location = New System.Drawing.Point(7, 15)
        Me.GridClases.Name = "GridClases"
        Me.GridClases.RecordNavigator = True
        Me.GridClases.Size = New System.Drawing.Size(657, 499)
        Me.GridClases.TabIndex = 1
        Me.GridClases.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabMail
        '
        Me.UiTabMail.Controls.Add(Me.GroupBox3)
        Me.UiTabMail.Controls.Add(Me.GroupBox5)
        Me.UiTabMail.Location = New System.Drawing.Point(1, 21)
        Me.UiTabMail.Name = "UiTabMail"
        Me.UiTabMail.Size = New System.Drawing.Size(676, 548)
        Me.UiTabMail.TabStop = True
        Me.UiTabMail.Text = "Parametros "
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Label54)
        Me.GroupBox3.Controls.Add(Me.btnEntrada)
        Me.GroupBox3.Controls.Add(Me.txtEntrada)
        Me.GroupBox3.Controls.Add(Me.PictureBox28)
        Me.GroupBox3.Controls.Add(Me.Label44)
        Me.GroupBox3.Controls.Add(Me.btnVersion)
        Me.GroupBox3.Controls.Add(Me.txtVersion)
        Me.GroupBox3.Controls.Add(Me.PictureBox26)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.btnInterfaz)
        Me.GroupBox3.Controls.Add(Me.txtInterfaz)
        Me.GroupBox3.Controls.Add(Me.btnImagenes)
        Me.GroupBox3.Controls.Add(Me.PictureBox25)
        Me.GroupBox3.Controls.Add(Me.Label41)
        Me.GroupBox3.Controls.Add(Me.BtnExploraImg)
        Me.GroupBox3.Controls.Add(Me.TxtImagenUrl)
        Me.GroupBox3.Controls.Add(Me.PictureBox10)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.BtnExplorador)
        Me.GroupBox3.Controls.Add(Me.TxtDireccion)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 220)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(666, 199)
        Me.GroupBox3.TabIndex = 23
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Directorios"
        '
        'Label54
        '
        Me.Label54.Location = New System.Drawing.Point(4, 167)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(131, 19)
        Me.Label54.TabIndex = 77
        Me.Label54.Text = "Dir. Interfaz Entrada"
        '
        'btnEntrada
        '
        Me.btnEntrada.Image = CType(resources.GetObject("btnEntrada.Image"), System.Drawing.Image)
        Me.btnEntrada.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnEntrada.Location = New System.Drawing.Point(512, 157)
        Me.btnEntrada.Name = "btnEntrada"
        Me.btnEntrada.Size = New System.Drawing.Size(33, 29)
        Me.btnEntrada.TabIndex = 79
        Me.btnEntrada.ToolTipText = "Ubicación donde se almacenaran los archivos de interfaz de entrada"
        '
        'txtEntrada
        '
        Me.txtEntrada.Location = New System.Drawing.Point(148, 164)
        Me.txtEntrada.Name = "txtEntrada"
        Me.txtEntrada.Size = New System.Drawing.Size(359, 20)
        Me.txtEntrada.TabIndex = 78
        Me.txtEntrada.TabStop = False
        '
        'PictureBox28
        '
        Me.PictureBox28.Image = CType(resources.GetObject("PictureBox28.Image"), System.Drawing.Image)
        Me.PictureBox28.Location = New System.Drawing.Point(114, 126)
        Me.PictureBox28.Name = "PictureBox28"
        Me.PictureBox28.Size = New System.Drawing.Size(28, 20)
        Me.PictureBox28.TabIndex = 76
        Me.PictureBox28.TabStop = False
        Me.PictureBox28.Visible = False
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(4, 129)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(131, 19)
        Me.Label44.TabIndex = 73
        Me.Label44.Text = "Directorio de Versión"
        '
        'btnVersion
        '
        Me.btnVersion.Image = CType(resources.GetObject("btnVersion.Image"), System.Drawing.Image)
        Me.btnVersion.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnVersion.Location = New System.Drawing.Point(512, 119)
        Me.btnVersion.Name = "btnVersion"
        Me.btnVersion.Size = New System.Drawing.Size(33, 29)
        Me.btnVersion.TabIndex = 75
        Me.btnVersion.ToolTipText = "Ubicación donde se almacenaran los archivos de interfaz de salida"
        '
        'txtVersion
        '
        Me.txtVersion.Location = New System.Drawing.Point(148, 126)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(359, 20)
        Me.txtVersion.TabIndex = 74
        Me.txtVersion.TabStop = False
        '
        'PictureBox26
        '
        Me.PictureBox26.Image = CType(resources.GetObject("PictureBox26.Image"), System.Drawing.Image)
        Me.PictureBox26.Location = New System.Drawing.Point(114, 91)
        Me.PictureBox26.Name = "PictureBox26"
        Me.PictureBox26.Size = New System.Drawing.Size(28, 20)
        Me.PictureBox26.TabIndex = 72
        Me.PictureBox26.TabStop = False
        Me.PictureBox26.Visible = False
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(4, 94)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(131, 19)
        Me.Label15.TabIndex = 69
        Me.Label15.Text = "Dir. Interfaz Salida"
        '
        'btnInterfaz
        '
        Me.btnInterfaz.Image = CType(resources.GetObject("btnInterfaz.Image"), System.Drawing.Image)
        Me.btnInterfaz.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnInterfaz.Location = New System.Drawing.Point(512, 84)
        Me.btnInterfaz.Name = "btnInterfaz"
        Me.btnInterfaz.Size = New System.Drawing.Size(33, 29)
        Me.btnInterfaz.TabIndex = 71
        Me.btnInterfaz.ToolTipText = "Ubicación donde se almacenaran los archivos de interfaz de salida"
        '
        'txtInterfaz
        '
        Me.txtInterfaz.Location = New System.Drawing.Point(148, 91)
        Me.txtInterfaz.Name = "txtInterfaz"
        Me.txtInterfaz.Size = New System.Drawing.Size(359, 20)
        Me.txtInterfaz.TabIndex = 70
        Me.txtInterfaz.TabStop = False
        '
        'btnImagenes
        '
        Me.btnImagenes.Image = CType(resources.GetObject("btnImagenes.Image"), System.Drawing.Image)
        Me.btnImagenes.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnImagenes.Location = New System.Drawing.Point(551, 50)
        Me.btnImagenes.Name = "btnImagenes"
        Me.btnImagenes.Size = New System.Drawing.Size(33, 29)
        Me.btnImagenes.TabIndex = 68
        Me.btnImagenes.ToolTipText = "Importar Imagenes"
        '
        'PictureBox25
        '
        Me.PictureBox25.Image = CType(resources.GetObject("PictureBox25.Image"), System.Drawing.Image)
        Me.PictureBox25.Location = New System.Drawing.Point(114, 57)
        Me.PictureBox25.Name = "PictureBox25"
        Me.PictureBox25.Size = New System.Drawing.Size(28, 20)
        Me.PictureBox25.TabIndex = 67
        Me.PictureBox25.TabStop = False
        Me.PictureBox25.Visible = False
        '
        'Label41
        '
        Me.Label41.Location = New System.Drawing.Point(4, 60)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(131, 19)
        Me.Label41.TabIndex = 64
        Me.Label41.Text = "Imagenes de Producto"
        '
        'BtnExploraImg
        '
        Me.BtnExploraImg.Image = CType(resources.GetObject("BtnExploraImg.Image"), System.Drawing.Image)
        Me.BtnExploraImg.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnExploraImg.Location = New System.Drawing.Point(512, 50)
        Me.BtnExploraImg.Name = "BtnExploraImg"
        Me.BtnExploraImg.Size = New System.Drawing.Size(33, 29)
        Me.BtnExploraImg.TabIndex = 66
        Me.BtnExploraImg.ToolTipText = "Ubicación en el servidor donde se guardaran las imagenes de productos"
        '
        'TxtImagenUrl
        '
        Me.TxtImagenUrl.Location = New System.Drawing.Point(148, 57)
        Me.TxtImagenUrl.Name = "TxtImagenUrl"
        Me.TxtImagenUrl.Size = New System.Drawing.Size(359, 20)
        Me.TxtImagenUrl.TabIndex = 65
        Me.TxtImagenUrl.TabStop = False
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(114, 21)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(28, 20)
        Me.PictureBox10.TabIndex = 63
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(4, 24)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(131, 19)
        Me.Label22.TabIndex = 8
        Me.Label22.Text = "CFDI de Proveedores"
        '
        'BtnExplorador
        '
        Me.BtnExplorador.Image = CType(resources.GetObject("BtnExplorador.Image"), System.Drawing.Image)
        Me.BtnExplorador.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnExplorador.Location = New System.Drawing.Point(512, 14)
        Me.BtnExplorador.Name = "BtnExplorador"
        Me.BtnExplorador.Size = New System.Drawing.Size(33, 29)
        Me.BtnExplorador.TabIndex = 30
        Me.BtnExplorador.ToolTipText = "Ubicación en el servidor donde se guardaran los XML y PDF de proveedores"
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(148, 21)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.Size = New System.Drawing.Size(359, 20)
        Me.TxtDireccion.TabIndex = 28
        Me.TxtDireccion.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.TxtMailPort)
        Me.GroupBox5.Controls.Add(Me.BtnTest)
        Me.GroupBox5.Controls.Add(Me.TxtMailPassword)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.TxtHostSMTP)
        Me.GroupBox5.Controls.Add(Me.Label25)
        Me.GroupBox5.Controls.Add(Me.TxtMailUser)
        Me.GroupBox5.Controls.Add(Me.TxtDisplayName)
        Me.GroupBox5.Controls.Add(Me.TxtMailAdress)
        Me.GroupBox5.Controls.Add(Me.Label27)
        Me.GroupBox5.Controls.Add(Me.Label28)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.Label31)
        Me.GroupBox5.Controls.Add(Me.ChkMailSSL)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(666, 202)
        Me.GroupBox5.TabIndex = 22
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Configuración de Correo Electrónico"
        '
        'TxtMailPort
        '
        Me.TxtMailPort.Location = New System.Drawing.Point(113, 147)
        Me.TxtMailPort.Name = "TxtMailPort"
        Me.TxtMailPort.Size = New System.Drawing.Size(58, 20)
        Me.TxtMailPort.TabIndex = 100
        Me.TxtMailPort.Text = "1"
        Me.TxtMailPort.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtMailPort.Value = 1
        Me.TxtMailPort.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'BtnTest
        '
        Me.BtnTest.Icon = CType(resources.GetObject("BtnTest.Icon"), System.Drawing.Icon)
        Me.BtnTest.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnTest.Location = New System.Drawing.Point(527, 162)
        Me.BtnTest.Name = "BtnTest"
        Me.BtnTest.Size = New System.Drawing.Size(133, 29)
        Me.BtnTest.TabIndex = 8
        Me.BtnTest.Text = "Probar Configuración"
        Me.BtnTest.ToolTipText = "Prueba de envio de correo"
        '
        'TxtMailPassword
        '
        Me.TxtMailPassword.Location = New System.Drawing.Point(113, 96)
        Me.TxtMailPassword.Name = "TxtMailPassword"
        Me.TxtMailPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtMailPassword.Size = New System.Drawing.Size(140, 20)
        Me.TxtMailPassword.TabIndex = 4
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(8, 124)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(83, 15)
        Me.Label23.TabIndex = 99
        Me.Label23.Text = "Servidor SMTP"
        '
        'TxtHostSMTP
        '
        Me.TxtHostSMTP.Location = New System.Drawing.Point(113, 122)
        Me.TxtHostSMTP.Name = "TxtHostSMTP"
        Me.TxtHostSMTP.Size = New System.Drawing.Size(421, 20)
        Me.TxtHostSMTP.TabIndex = 5
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(7, 98)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(68, 15)
        Me.Label25.TabIndex = 95
        Me.Label25.Text = "Contraseña"
        '
        'TxtMailUser
        '
        Me.TxtMailUser.Location = New System.Drawing.Point(113, 70)
        Me.TxtMailUser.Name = "TxtMailUser"
        Me.TxtMailUser.Size = New System.Drawing.Size(255, 20)
        Me.TxtMailUser.TabIndex = 3
        '
        'TxtDisplayName
        '
        Me.TxtDisplayName.Location = New System.Drawing.Point(113, 45)
        Me.TxtDisplayName.Name = "TxtDisplayName"
        Me.TxtDisplayName.Size = New System.Drawing.Size(255, 20)
        Me.TxtDisplayName.TabIndex = 2
        '
        'TxtMailAdress
        '
        Me.TxtMailAdress.Location = New System.Drawing.Point(113, 19)
        Me.TxtMailAdress.Name = "TxtMailAdress"
        Me.TxtMailAdress.Size = New System.Drawing.Size(255, 20)
        Me.TxtMailAdress.TabIndex = 1
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(7, 23)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(111, 15)
        Me.Label27.TabIndex = 89
        Me.Label27.Text = "Dirección de correo"
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(7, 72)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(45, 18)
        Me.Label28.TabIndex = 88
        Me.Label28.Text = "Usuario"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(6, 48)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(53, 15)
        Me.Label29.TabIndex = 87
        Me.Label29.Text = "Nombre"
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(8, 150)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(44, 15)
        Me.Label31.TabIndex = 85
        Me.Label31.Text = "Puerto"
        '
        'ChkMailSSL
        '
        Me.ChkMailSSL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkMailSSL.Checked = True
        Me.ChkMailSSL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkMailSSL.Location = New System.Drawing.Point(9, 176)
        Me.ChkMailSSL.Name = "ChkMailSSL"
        Me.ChkMailSSL.Size = New System.Drawing.Size(119, 15)
        Me.ChkMailSSL.TabIndex = 7
        Me.ChkMailSSL.Text = "Habilitar SSL"
        '
        'UiTabParam
        '
        Me.UiTabParam.Controls.Add(Me.GroupBox4)
        Me.UiTabParam.Controls.Add(Me.GroupBox2)
        Me.UiTabParam.Controls.Add(Me.GroupBox1)
        Me.UiTabParam.Location = New System.Drawing.Point(1, 21)
        Me.UiTabParam.Name = "UiTabParam"
        Me.UiTabParam.Size = New System.Drawing.Size(676, 548)
        Me.UiTabParam.TabStop = True
        Me.UiTabParam.Text = "Parametros 2"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.Label61)
        Me.GroupBox4.Controls.Add(Me.txtLimitaCompraEmp)
        Me.GroupBox4.Controls.Add(Me.chkAplicaPromo)
        Me.GroupBox4.Controls.Add(Me.chkMaskCte)
        Me.GroupBox4.Controls.Add(Me.diasMaxDev)
        Me.GroupBox4.Controls.Add(Me.txtConcentrador)
        Me.GroupBox4.Controls.Add(Me.Label52)
        Me.GroupBox4.Controls.Add(Me.Label51)
        Me.GroupBox4.Controls.Add(Me.chkDevConcentra)
        Me.GroupBox4.Controls.Add(Me.PictureBox33)
        Me.GroupBox4.Controls.Add(Me.cmbPedido)
        Me.GroupBox4.Controls.Add(Me.numPedidosOpen)
        Me.GroupBox4.Controls.Add(Me.Label49)
        Me.GroupBox4.Controls.Add(Me.PictureBox32)
        Me.GroupBox4.Controls.Add(Me.Label48)
        Me.GroupBox4.Controls.Add(Me.TxtDescVale)
        Me.GroupBox4.Controls.Add(Me.txtReemplazo)
        Me.GroupBox4.Controls.Add(Me.Label45)
        Me.GroupBox4.Controls.Add(Me.cmbCargo)
        Me.GroupBox4.Controls.Add(Me.PictureBox27)
        Me.GroupBox4.Controls.Add(Me.Label43)
        Me.GroupBox4.Controls.Add(Me.cmbNC)
        Me.GroupBox4.Controls.Add(Me.PictureBox23)
        Me.GroupBox4.Controls.Add(Me.Label42)
        Me.GroupBox4.Controls.Add(Me.PictureBox24)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.txtSucursal)
        Me.GroupBox4.Controls.Add(Me.Label37)
        Me.GroupBox4.Controls.Add(Me.cmbFactura)
        Me.GroupBox4.Controls.Add(Me.PictureBox21)
        Me.GroupBox4.Controls.Add(Me.Label40)
        Me.GroupBox4.Controls.Add(Me.PictureBox20)
        Me.GroupBox4.Controls.Add(Me.Label39)
        Me.GroupBox4.Controls.Add(Me.NumTimeOut)
        Me.GroupBox4.Controls.Add(Me.Label30)
        Me.GroupBox4.Controls.Add(Me.PictureBox14)
        Me.GroupBox4.Controls.Add(Me.CmbFormatOC)
        Me.GroupBox4.Controls.Add(Me.PictureBox12)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Controls.Add(Me.NumHistorico)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.PictureBox11)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Label32)
        Me.GroupBox4.Controls.Add(Me.Label50)
        Me.GroupBox4.Controls.Add(Me.ChkTallaColor)
        Me.GroupBox4.Controls.Add(Me.ChkCompartir)
        Me.GroupBox4.Controls.Add(Me.ChkPrecioBase)
        Me.GroupBox4.Controls.Add(Me.ChkActPrecios)
        Me.GroupBox4.Controls.Add(Me.ChkValidaCtaPago)
        Me.GroupBox4.Controls.Add(Me.ChkDomicilio)
        Me.GroupBox4.Controls.Add(Me.cmbCosteo)
        Me.GroupBox4.Controls.Add(Me.ChkAplicacion)
        Me.GroupBox4.Controls.Add(Me.cmbMonedaCambio)
        Me.GroupBox4.Controls.Add(Me.cmbMoneda)
        Me.GroupBox4.Controls.Add(Me.CmbImpuesto)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 102)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(666, 437)
        Me.GroupBox4.TabIndex = 114
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Varios"
        '
        'Label61
        '
        Me.Label61.Location = New System.Drawing.Point(7, 349)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(215, 15)
        Me.Label61.TabIndex = 175
        Me.Label61.Text = "Limitar Compra Mensual a Empleado"
        '
        'txtLimitaCompraEmp
        '
        Me.txtLimitaCompraEmp.Location = New System.Drawing.Point(227, 347)
        Me.txtLimitaCompraEmp.Name = "txtLimitaCompraEmp"
        Me.txtLimitaCompraEmp.Size = New System.Drawing.Size(75, 20)
        Me.txtLimitaCompraEmp.TabIndex = 174
        Me.txtLimitaCompraEmp.Text = "0.00"
        Me.txtLimitaCompraEmp.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtLimitaCompraEmp.Value = 0.0R
        Me.txtLimitaCompraEmp.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'chkAplicaPromo
        '
        Me.chkAplicaPromo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAplicaPromo.Location = New System.Drawing.Point(347, 219)
        Me.chkAplicaPromo.Name = "chkAplicaPromo"
        Me.chkAplicaPromo.Size = New System.Drawing.Size(237, 24)
        Me.chkAplicaPromo.TabIndex = 173
        Me.chkAplicaPromo.Text = "Aplicar Promoción al Cierre"
        '
        'chkMaskCte
        '
        Me.chkMaskCte.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkMaskCte.Location = New System.Drawing.Point(347, 189)
        Me.chkMaskCte.Name = "chkMaskCte"
        Me.chkMaskCte.Size = New System.Drawing.Size(237, 24)
        Me.chkMaskCte.TabIndex = 172
        Me.chkMaskCte.Text = "Aplicar Mascara a Cve. de Cliente"
        '
        'diasMaxDev
        '
        Me.diasMaxDev.Location = New System.Drawing.Point(227, 317)
        Me.diasMaxDev.Maximum = New Decimal(New Integer() {365, 0, 0, 0})
        Me.diasMaxDev.Name = "diasMaxDev"
        Me.diasMaxDev.Size = New System.Drawing.Size(75, 20)
        Me.diasMaxDev.TabIndex = 171
        '
        'txtConcentrador
        '
        Me.txtConcentrador.Location = New System.Drawing.Point(171, 181)
        Me.txtConcentrador.Name = "txtConcentrador"
        Me.txtConcentrador.Size = New System.Drawing.Size(131, 20)
        Me.txtConcentrador.TabIndex = 170
        '
        'Label52
        '
        Me.Label52.Location = New System.Drawing.Point(7, 184)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(158, 15)
        Me.Label52.TabIndex = 169
        Me.Label52.Text = "IP\ServerName (Concentrador)"
        '
        'Label51
        '
        Me.Label51.Location = New System.Drawing.Point(10, 319)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(197, 15)
        Me.Label51.TabIndex = 167
        Me.Label51.Text = "Dias Max. Devolución"
        '
        'chkDevConcentra
        '
        Me.chkDevConcentra.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDevConcentra.Location = New System.Drawing.Point(347, 164)
        Me.chkDevConcentra.Name = "chkDevConcentra"
        Me.chkDevConcentra.Size = New System.Drawing.Size(237, 24)
        Me.chkDevConcentra.TabIndex = 166
        Me.chkDevConcentra.Text = "Aplicar Devolución en Concentrador"
        '
        'PictureBox33
        '
        Me.PictureBox33.Image = CType(resources.GetObject("PictureBox33.Image"), System.Drawing.Image)
        Me.PictureBox33.Location = New System.Drawing.Point(449, 379)
        Me.PictureBox33.Name = "PictureBox33"
        Me.PictureBox33.Size = New System.Drawing.Size(29, 20)
        Me.PictureBox33.TabIndex = 165
        Me.PictureBox33.TabStop = False
        Me.PictureBox33.Visible = False
        '
        'cmbPedido
        '
        Me.cmbPedido.FormattingEnabled = True
        Me.cmbPedido.Items.AddRange(New Object() {"Clasico", "Pagare", "Pagare2", "Radec", "Ticket"})
        Me.cmbPedido.Location = New System.Drawing.Point(475, 378)
        Me.cmbPedido.Name = "cmbPedido"
        Me.cmbPedido.Size = New System.Drawing.Size(149, 21)
        Me.cmbPedido.TabIndex = 164
        '
        'numPedidosOpen
        '
        Me.numPedidosOpen.Location = New System.Drawing.Point(228, 288)
        Me.numPedidosOpen.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.numPedidosOpen.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numPedidosOpen.Name = "numPedidosOpen"
        Me.numPedidosOpen.Size = New System.Drawing.Size(75, 20)
        Me.numPedidosOpen.TabIndex = 162
        Me.numPedidosOpen.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label49
        '
        Me.Label49.Location = New System.Drawing.Point(8, 290)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(214, 23)
        Me.Label49.TabIndex = 161
        Me.Label49.Text = "Número de días para pedidos abiertos"
        '
        'PictureBox32
        '
        Me.PictureBox32.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox32.Image = CType(resources.GetObject("PictureBox32.Image"), System.Drawing.Image)
        Me.PictureBox32.Location = New System.Drawing.Point(206, 266)
        Me.PictureBox32.Name = "PictureBox32"
        Me.PictureBox32.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox32.TabIndex = 160
        Me.PictureBox32.TabStop = False
        Me.PictureBox32.Visible = False
        '
        'Label48
        '
        Me.Label48.Location = New System.Drawing.Point(8, 266)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(214, 15)
        Me.Label48.TabIndex = 159
        Me.Label48.Text = "Porc. Desc. Vale Extraviado"
        '
        'TxtDescVale
        '
        Me.TxtDescVale.Location = New System.Drawing.Point(228, 264)
        Me.TxtDescVale.Name = "TxtDescVale"
        Me.TxtDescVale.Size = New System.Drawing.Size(75, 20)
        Me.TxtDescVale.TabIndex = 158
        Me.TxtDescVale.Text = "0.00"
        Me.TxtDescVale.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtDescVale.Value = 0.0R
        Me.TxtDescVale.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'txtReemplazo
        '
        Me.txtReemplazo.Location = New System.Drawing.Point(269, 238)
        Me.txtReemplazo.MaxLength = 1
        Me.txtReemplazo.Name = "txtReemplazo"
        Me.txtReemplazo.Size = New System.Drawing.Size(33, 20)
        Me.txtReemplazo.TabIndex = 151
        Me.txtReemplazo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'Label45
        '
        Me.Label45.Location = New System.Drawing.Point(8, 240)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(239, 15)
        Me.Label45.TabIndex = 152
        Me.Label45.Text = "Caracter de reemplazo en clave de producto"
        '
        'cmbCargo
        '
        Me.cmbCargo.FormattingEnabled = True
        Me.cmbCargo.Items.AddRange(New Object() {"Clasico", "Radec"})
        Me.cmbCargo.Location = New System.Drawing.Point(475, 316)
        Me.cmbCargo.Name = "cmbCargo"
        Me.cmbCargo.Size = New System.Drawing.Size(149, 21)
        Me.cmbCargo.TabIndex = 149
        '
        'PictureBox27
        '
        Me.PictureBox27.Image = CType(resources.GetObject("PictureBox27.Image"), System.Drawing.Image)
        Me.PictureBox27.Location = New System.Drawing.Point(449, 320)
        Me.PictureBox27.Name = "PictureBox27"
        Me.PictureBox27.Size = New System.Drawing.Size(17, 20)
        Me.PictureBox27.TabIndex = 147
        Me.PictureBox27.TabStop = False
        Me.PictureBox27.Visible = False
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(343, 319)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(129, 21)
        Me.Label43.TabIndex = 148
        Me.Label43.Text = "Formato N. Cargo"
        '
        'cmbNC
        '
        Me.cmbNC.FormattingEnabled = True
        Me.cmbNC.Items.AddRange(New Object() {"Clasico", "Radec", "Cklass"})
        Me.cmbNC.Location = New System.Drawing.Point(475, 288)
        Me.cmbNC.Name = "cmbNC"
        Me.cmbNC.Size = New System.Drawing.Size(149, 21)
        Me.cmbNC.TabIndex = 146
        '
        'PictureBox23
        '
        Me.PictureBox23.Image = CType(resources.GetObject("PictureBox23.Image"), System.Drawing.Image)
        Me.PictureBox23.Location = New System.Drawing.Point(449, 292)
        Me.PictureBox23.Name = "PictureBox23"
        Me.PictureBox23.Size = New System.Drawing.Size(17, 20)
        Me.PictureBox23.TabIndex = 144
        Me.PictureBox23.TabStop = False
        Me.PictureBox23.Visible = False
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(343, 291)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(129, 21)
        Me.Label42.TabIndex = 145
        Me.Label42.Text = "Formato de NC"
        '
        'PictureBox24
        '
        Me.PictureBox24.Image = CType(resources.GetObject("PictureBox24.Image"), System.Drawing.Image)
        Me.PictureBox24.Location = New System.Drawing.Point(45, 43)
        Me.PictureBox24.Name = "PictureBox24"
        Me.PictureBox24.Size = New System.Drawing.Size(29, 20)
        Me.PictureBox24.TabIndex = 143
        Me.PictureBox24.TabStop = False
        Me.PictureBox24.Visible = False
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(6, 45)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 20)
        Me.Label17.TabIndex = 142
        Me.Label17.Text = "Tipo Costeo"
        '
        'txtSucursal
        '
        Me.txtSucursal.Location = New System.Drawing.Point(171, 155)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Size = New System.Drawing.Size(132, 20)
        Me.txtSucursal.TabIndex = 139
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(8, 158)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(134, 15)
        Me.Label37.TabIndex = 138
        Me.Label37.Text = "IP\ServerName (Sucursal)"
        '
        'cmbFactura
        '
        Me.cmbFactura.FormattingEnabled = True
        Me.cmbFactura.Items.AddRange(New Object() {"Clasico", "Con Notas", "Pagare", "Pagare2", "Radec", "Aseguradora", "LaLa", "Daimler", "AutoZone", "Zeus", "Cklass"})
        Me.cmbFactura.Location = New System.Drawing.Point(475, 260)
        Me.cmbFactura.Name = "cmbFactura"
        Me.cmbFactura.Size = New System.Drawing.Size(149, 21)
        Me.cmbFactura.TabIndex = 137
        '
        'PictureBox21
        '
        Me.PictureBox21.Image = CType(resources.GetObject("PictureBox21.Image"), System.Drawing.Image)
        Me.PictureBox21.Location = New System.Drawing.Point(45, 96)
        Me.PictureBox21.Name = "PictureBox21"
        Me.PictureBox21.Size = New System.Drawing.Size(29, 20)
        Me.PictureBox21.TabIndex = 132
        Me.PictureBox21.TabStop = False
        Me.PictureBox21.Visible = False
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(7, 98)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(123, 15)
        Me.Label40.TabIndex = 131
        Me.Label40.Text = "Moneda Cambiaria"
        '
        'PictureBox20
        '
        Me.PictureBox20.Image = CType(resources.GetObject("PictureBox20.Image"), System.Drawing.Image)
        Me.PictureBox20.Location = New System.Drawing.Point(45, 69)
        Me.PictureBox20.Name = "PictureBox20"
        Me.PictureBox20.Size = New System.Drawing.Size(29, 20)
        Me.PictureBox20.TabIndex = 129
        Me.PictureBox20.TabStop = False
        Me.PictureBox20.Visible = False
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(6, 71)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(131, 15)
        Me.Label39.TabIndex = 128
        Me.Label39.Text = "Moneda Predeterminada"
        '
        'NumTimeOut
        '
        Me.NumTimeOut.Location = New System.Drawing.Point(228, 129)
        Me.NumTimeOut.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NumTimeOut.Name = "NumTimeOut"
        Me.NumTimeOut.Size = New System.Drawing.Size(75, 20)
        Me.NumTimeOut.TabIndex = 127
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(6, 132)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(280, 22)
        Me.Label30.TabIndex = 126
        Me.Label30.Text = "TimeOut para Consultas a la base de datos"
        '
        'PictureBox14
        '
        Me.PictureBox14.Image = CType(resources.GetObject("PictureBox14.Image"), System.Drawing.Image)
        Me.PictureBox14.Location = New System.Drawing.Point(449, 352)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(29, 20)
        Me.PictureBox14.TabIndex = 117
        Me.PictureBox14.TabStop = False
        Me.PictureBox14.Visible = False
        '
        'CmbFormatOC
        '
        Me.CmbFormatOC.FormattingEnabled = True
        Me.CmbFormatOC.Items.AddRange(New Object() {"Clasico", "Con Columnas"})
        Me.CmbFormatOC.Location = New System.Drawing.Point(475, 349)
        Me.CmbFormatOC.Name = "CmbFormatOC"
        Me.CmbFormatOC.Size = New System.Drawing.Size(149, 21)
        Me.CmbFormatOC.TabIndex = 118
        '
        'PictureBox12
        '
        Me.PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), System.Drawing.Image)
        Me.PictureBox12.Location = New System.Drawing.Point(449, 256)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(17, 20)
        Me.PictureBox12.TabIndex = 125
        Me.PictureBox12.TabStop = False
        Me.PictureBox12.Visible = False
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(343, 352)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(129, 15)
        Me.Label26.TabIndex = 59
        Me.Label26.Text = "Formato de OC"
        '
        'NumHistorico
        '
        Me.NumHistorico.Location = New System.Drawing.Point(228, 211)
        Me.NumHistorico.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.NumHistorico.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumHistorico.Name = "NumHistorico"
        Me.NumHistorico.Size = New System.Drawing.Size(75, 20)
        Me.NumHistorico.TabIndex = 121
        Me.NumHistorico.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(8, 213)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(189, 23)
        Me.Label16.TabIndex = 119
        Me.Label16.Text = "Numero de Periodos a conservar "
        '
        'PictureBox11
        '
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(45, 16)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(29, 20)
        Me.PictureBox11.TabIndex = 116
        Me.PictureBox11.TabStop = False
        Me.PictureBox11.Visible = False
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(6, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(136, 20)
        Me.Label14.TabIndex = 115
        Me.Label14.Text = "Impuesto predeterminado"
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(343, 263)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(129, 21)
        Me.Label32.TabIndex = 135
        Me.Label32.Text = "Formato de Factura"
        '
        'Label50
        '
        Me.Label50.Location = New System.Drawing.Point(343, 381)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(129, 15)
        Me.Label50.TabIndex = 163
        Me.Label50.Text = "Formato de Pedido"
        '
        'ChkTallaColor
        '
        Me.ChkTallaColor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkTallaColor.Location = New System.Drawing.Point(347, 50)
        Me.ChkTallaColor.Name = "ChkTallaColor"
        Me.ChkTallaColor.Size = New System.Drawing.Size(237, 23)
        Me.ChkTallaColor.TabIndex = 157
        Me.ChkTallaColor.Text = "Talla y Color"
        '
        'ChkCompartir
        '
        Me.ChkCompartir.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkCompartir.Location = New System.Drawing.Point(347, 13)
        Me.ChkCompartir.Name = "ChkCompartir"
        Me.ChkCompartir.Size = New System.Drawing.Size(237, 15)
        Me.ChkCompartir.TabIndex = 156
        Me.ChkCompartir.Text = "Compartir Punto de Venta"
        '
        'ChkPrecioBase
        '
        Me.ChkPrecioBase.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkPrecioBase.Location = New System.Drawing.Point(347, 141)
        Me.ChkPrecioBase.Name = "ChkPrecioBase"
        Me.ChkPrecioBase.Size = New System.Drawing.Size(237, 24)
        Me.ChkPrecioBase.TabIndex = 155
        Me.ChkPrecioBase.Text = "Desglose de Descuento en Ticket"
        '
        'ChkActPrecios
        '
        Me.ChkActPrecios.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkActPrecios.Location = New System.Drawing.Point(347, 118)
        Me.ChkActPrecios.Name = "ChkActPrecios"
        Me.ChkActPrecios.Size = New System.Drawing.Size(237, 24)
        Me.ChkActPrecios.TabIndex = 154
        Me.ChkActPrecios.Text = "Act. Prec. Compra"
        '
        'ChkValidaCtaPago
        '
        Me.ChkValidaCtaPago.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkValidaCtaPago.Location = New System.Drawing.Point(347, 95)
        Me.ChkValidaCtaPago.Name = "ChkValidaCtaPago"
        Me.ChkValidaCtaPago.Size = New System.Drawing.Size(237, 24)
        Me.ChkValidaCtaPago.TabIndex = 153
        Me.ChkValidaCtaPago.Text = "Valida Cta Pago"
        '
        'ChkDomicilio
        '
        Me.ChkDomicilio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkDomicilio.Location = New System.Drawing.Point(347, 74)
        Me.ChkDomicilio.Name = "ChkDomicilio"
        Me.ChkDomicilio.Size = New System.Drawing.Size(237, 15)
        Me.ChkDomicilio.TabIndex = 150
        Me.ChkDomicilio.Text = "Valida Domicilio Clientes"
        '
        'cmbCosteo
        '
        Me.cmbCosteo.Location = New System.Drawing.Point(142, 39)
        Me.cmbCosteo.Name = "cmbCosteo"
        Me.cmbCosteo.Size = New System.Drawing.Size(161, 21)
        Me.cmbCosteo.TabIndex = 141
        '
        'ChkAplicacion
        '
        Me.ChkAplicacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkAplicacion.Location = New System.Drawing.Point(347, 34)
        Me.ChkAplicacion.Name = "ChkAplicacion"
        Me.ChkAplicacion.Size = New System.Drawing.Size(237, 15)
        Me.ChkAplicacion.TabIndex = 140
        Me.ChkAplicacion.Text = "Aplicación Automotriz"
        '
        'cmbMonedaCambio
        '
        Me.cmbMonedaCambio.Location = New System.Drawing.Point(142, 95)
        Me.cmbMonedaCambio.Name = "cmbMonedaCambio"
        Me.cmbMonedaCambio.Size = New System.Drawing.Size(160, 21)
        Me.cmbMonedaCambio.TabIndex = 134
        '
        'cmbMoneda
        '
        Me.cmbMoneda.Location = New System.Drawing.Point(142, 68)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(160, 21)
        Me.cmbMoneda.TabIndex = 133
        '
        'CmbImpuesto
        '
        Me.CmbImpuesto.Location = New System.Drawing.Point(142, 13)
        Me.CmbImpuesto.Name = "CmbImpuesto"
        Me.CmbImpuesto.Size = New System.Drawing.Size(161, 21)
        Me.CmbImpuesto.TabIndex = 114
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.NumLineNota)
        Me.GroupBox2.Controls.Add(Me.NumLineFactura)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Location = New System.Drawing.Point(259, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(412, 93)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Maximo de Lineas de Impresión"
        '
        'NumLineNota
        '
        Me.NumLineNota.Location = New System.Drawing.Point(111, 55)
        Me.NumLineNota.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.NumLineNota.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumLineNota.Name = "NumLineNota"
        Me.NumLineNota.Size = New System.Drawing.Size(100, 20)
        Me.NumLineNota.TabIndex = 7
        Me.NumLineNota.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumLineFactura
        '
        Me.NumLineFactura.Location = New System.Drawing.Point(111, 20)
        Me.NumLineFactura.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.NumLineFactura.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumLineFactura.Name = "NumLineFactura"
        Me.NumLineFactura.Size = New System.Drawing.Size(100, 20)
        Me.NumLineFactura.TabIndex = 6
        Me.NumLineFactura.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(10, 57)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 27)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Nota de Crédito"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(12, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 15)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Factura"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.NumCliente)
        Me.GroupBox1.Controls.Add(Me.NumProveedor)
        Me.GroupBox1.Controls.Add(Me.NumCompra)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(252, 93)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Numero de Digitos en Consecutivo"
        '
        'NumCliente
        '
        Me.NumCliente.Location = New System.Drawing.Point(136, 66)
        Me.NumCliente.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumCliente.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumCliente.Name = "NumCliente"
        Me.NumCliente.Size = New System.Drawing.Size(100, 20)
        Me.NumCliente.TabIndex = 7
        Me.NumCliente.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumProveedor
        '
        Me.NumProveedor.Location = New System.Drawing.Point(136, 44)
        Me.NumProveedor.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumProveedor.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumProveedor.Name = "NumProveedor"
        Me.NumProveedor.Size = New System.Drawing.Size(100, 20)
        Me.NumProveedor.TabIndex = 6
        Me.NumProveedor.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumCompra
        '
        Me.NumCompra.Location = New System.Drawing.Point(136, 22)
        Me.NumCompra.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumCompra.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumCompra.Name = "NumCompra"
        Me.NumCompra.Size = New System.Drawing.Size(100, 20)
        Me.NumCompra.TabIndex = 5
        Me.NumCompra.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(4, 68)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 16)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Clave de Cliente"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(4, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(118, 19)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Clave de Proveedor"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(4, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 19)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Orden de Compra"
        '
        'UiTabParam3
        '
        Me.UiTabParam3.Controls.Add(Me.Label63)
        Me.UiTabParam3.Controls.Add(Me.txtUrlVentek)
        Me.UiTabParam3.Controls.Add(Me.txtPwdVentek)
        Me.UiTabParam3.Controls.Add(Me.Label64)
        Me.UiTabParam3.Controls.Add(Me.txtUsuarioVentek)
        Me.UiTabParam3.Controls.Add(Me.Label65)
        Me.UiTabParam3.Controls.Add(Me.ChkIngresoSimple)
        Me.UiTabParam3.Controls.Add(Me.Label62)
        Me.UiTabParam3.Controls.Add(Me.CmbSucursal)
        Me.UiTabParam3.Controls.Add(Me.ChkReciboAreas)
        Me.UiTabParam3.Controls.Add(Me.ChkLimitarCobroFac)
        Me.UiTabParam3.Controls.Add(Me.chkNegados)
        Me.UiTabParam3.Controls.Add(Me.chkSincronizarCte)
        Me.UiTabParam3.Controls.Add(Me.Label59)
        Me.UiTabParam3.Controls.Add(Me.txturlServicioTA)
        Me.UiTabParam3.Controls.Add(Me.txtidTerminalTA)
        Me.UiTabParam3.Controls.Add(Me.Label55)
        Me.UiTabParam3.Controls.Add(Me.numMaxMesesSinInteres)
        Me.UiTabParam3.Controls.Add(Me.Label56)
        Me.UiTabParam3.Controls.Add(Me.Label57)
        Me.UiTabParam3.Controls.Add(Me.txtMontoMinSinInteres)
        Me.UiTabParam3.Controls.Add(Me.txtIdComercioTA)
        Me.UiTabParam3.Controls.Add(Me.Label58)
        Me.UiTabParam3.Controls.Add(Me.chkCobranzaVenta)
        Me.UiTabParam3.Location = New System.Drawing.Point(1, 21)
        Me.UiTabParam3.Name = "UiTabParam3"
        Me.UiTabParam3.Size = New System.Drawing.Size(676, 548)
        Me.UiTabParam3.TabStop = True
        Me.UiTabParam3.Text = "Parametros 3"
        '
        'ChkIngresoSimple
        '
        Me.ChkIngresoSimple.BackColor = System.Drawing.Color.Transparent
        Me.ChkIngresoSimple.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkIngresoSimple.Location = New System.Drawing.Point(7, 320)
        Me.ChkIngresoSimple.Name = "ChkIngresoSimple"
        Me.ChkIngresoSimple.Size = New System.Drawing.Size(175, 24)
        Me.ChkIngresoSimple.TabIndex = 193
        Me.ChkIngresoSimple.Text = "Ingreso Simplificado"
        Me.ChkIngresoSimple.UseVisualStyleBackColor = False
        '
        'Label62
        '
        Me.Label62.BackColor = System.Drawing.Color.Transparent
        Me.Label62.Location = New System.Drawing.Point(3, 285)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(158, 15)
        Me.Label62.TabIndex = 192
        Me.Label62.Text = "Sucursal para  Dev. Proveedor"
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(166, 282)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(422, 21)
        Me.CmbSucursal.TabIndex = 191
        '
        'ChkReciboAreas
        '
        Me.ChkReciboAreas.BackColor = System.Drawing.Color.Transparent
        Me.ChkReciboAreas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkReciboAreas.Location = New System.Drawing.Point(3, 252)
        Me.ChkReciboAreas.Name = "ChkReciboAreas"
        Me.ChkReciboAreas.Size = New System.Drawing.Size(179, 24)
        Me.ChkReciboAreas.TabIndex = 189
        Me.ChkReciboAreas.Text = "Recibo por Areas"
        Me.ChkReciboAreas.UseVisualStyleBackColor = False
        '
        'ChkLimitarCobroFac
        '
        Me.ChkLimitarCobroFac.BackColor = System.Drawing.Color.Transparent
        Me.ChkLimitarCobroFac.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkLimitarCobroFac.Location = New System.Drawing.Point(3, 222)
        Me.ChkLimitarCobroFac.Name = "ChkLimitarCobroFac"
        Me.ChkLimitarCobroFac.Size = New System.Drawing.Size(179, 24)
        Me.ChkLimitarCobroFac.TabIndex = 188
        Me.ChkLimitarCobroFac.Text = "Limitar cobro a Factura"
        Me.ChkLimitarCobroFac.UseVisualStyleBackColor = False
        '
        'chkNegados
        '
        Me.chkNegados.BackColor = System.Drawing.Color.Transparent
        Me.chkNegados.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNegados.Location = New System.Drawing.Point(3, 192)
        Me.chkNegados.Name = "chkNegados"
        Me.chkNegados.Size = New System.Drawing.Size(179, 24)
        Me.chkNegados.TabIndex = 187
        Me.chkNegados.Text = "Busqueda Negados"
        Me.chkNegados.UseVisualStyleBackColor = False
        '
        'chkSincronizarCte
        '
        Me.chkSincronizarCte.BackColor = System.Drawing.Color.Transparent
        Me.chkSincronizarCte.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSincronizarCte.Location = New System.Drawing.Point(3, 169)
        Me.chkSincronizarCte.Name = "chkSincronizarCte"
        Me.chkSincronizarCte.Size = New System.Drawing.Size(179, 24)
        Me.chkSincronizarCte.TabIndex = 186
        Me.chkSincronizarCte.Text = "Sincronizar Clientes"
        Me.chkSincronizarCte.UseVisualStyleBackColor = False
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.Color.Transparent
        Me.Label59.Location = New System.Drawing.Point(3, 90)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(83, 15)
        Me.Label59.TabIndex = 185
        Me.Label59.Text = "urlServicioTA"
        '
        'txturlServicioTA
        '
        Me.txturlServicioTA.Location = New System.Drawing.Point(167, 88)
        Me.txturlServicioTA.Name = "txturlServicioTA"
        Me.txturlServicioTA.Size = New System.Drawing.Size(421, 20)
        Me.txturlServicioTA.TabIndex = 183
        '
        'txtidTerminalTA
        '
        Me.txtidTerminalTA.Location = New System.Drawing.Point(167, 62)
        Me.txtidTerminalTA.Name = "txtidTerminalTA"
        Me.txtidTerminalTA.Size = New System.Drawing.Size(131, 20)
        Me.txtidTerminalTA.TabIndex = 182
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.Color.Transparent
        Me.Label55.Location = New System.Drawing.Point(3, 65)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(158, 15)
        Me.Label55.TabIndex = 181
        Me.Label55.Text = "idTerminalTA"
        '
        'numMaxMesesSinInteres
        '
        Me.numMaxMesesSinInteres.Location = New System.Drawing.Point(167, 143)
        Me.numMaxMesesSinInteres.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.numMaxMesesSinInteres.Name = "numMaxMesesSinInteres"
        Me.numMaxMesesSinInteres.Size = New System.Drawing.Size(75, 20)
        Me.numMaxMesesSinInteres.TabIndex = 180
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.Color.Transparent
        Me.Label56.Location = New System.Drawing.Point(3, 143)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(158, 23)
        Me.Label56.TabIndex = 179
        Me.Label56.Text = "MaxMesesSinInteres"
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.Color.Transparent
        Me.Label57.Location = New System.Drawing.Point(3, 119)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(158, 15)
        Me.Label57.TabIndex = 178
        Me.Label57.Text = "MontoMinSinInteres"
        '
        'txtMontoMinSinInteres
        '
        Me.txtMontoMinSinInteres.Location = New System.Drawing.Point(167, 116)
        Me.txtMontoMinSinInteres.Name = "txtMontoMinSinInteres"
        Me.txtMontoMinSinInteres.Size = New System.Drawing.Size(75, 20)
        Me.txtMontoMinSinInteres.TabIndex = 177
        Me.txtMontoMinSinInteres.Text = "0.00"
        Me.txtMontoMinSinInteres.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtMontoMinSinInteres.Value = 0.0R
        Me.txtMontoMinSinInteres.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'txtIdComercioTA
        '
        Me.txtIdComercioTA.Location = New System.Drawing.Point(167, 36)
        Me.txtIdComercioTA.Name = "txtIdComercioTA"
        Me.txtIdComercioTA.Size = New System.Drawing.Size(132, 20)
        Me.txtIdComercioTA.TabIndex = 176
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.Color.Transparent
        Me.Label58.Location = New System.Drawing.Point(4, 39)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(134, 15)
        Me.Label58.TabIndex = 175
        Me.Label58.Text = "IdComercioTA"
        '
        'chkCobranzaVenta
        '
        Me.chkCobranzaVenta.BackColor = System.Drawing.Color.Transparent
        Me.chkCobranzaVenta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCobranzaVenta.Location = New System.Drawing.Point(4, 12)
        Me.chkCobranzaVenta.Name = "chkCobranzaVenta"
        Me.chkCobranzaVenta.Size = New System.Drawing.Size(179, 24)
        Me.chkCobranzaVenta.TabIndex = 174
        Me.chkCobranzaVenta.Text = "Cobranza Ventas"
        Me.chkCobranzaVenta.UseVisualStyleBackColor = False
        '
        'Label63
        '
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.Location = New System.Drawing.Point(5, 402)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(83, 15)
        Me.Label63.TabIndex = 199
        Me.Label63.Text = "urlServicio Ventek"
        '
        'txtUrlVentek
        '
        Me.txtUrlVentek.Location = New System.Drawing.Point(166, 400)
        Me.txtUrlVentek.Name = "txtUrlVentek"
        Me.txtUrlVentek.Size = New System.Drawing.Size(421, 20)
        Me.txtUrlVentek.TabIndex = 198
        '
        'txtPwdVentek
        '
        Me.txtPwdVentek.Location = New System.Drawing.Point(166, 374)
        Me.txtPwdVentek.Name = "txtPwdVentek"
        Me.txtPwdVentek.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwdVentek.Size = New System.Drawing.Size(131, 20)
        Me.txtPwdVentek.TabIndex = 197
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.Color.Transparent
        Me.Label64.Location = New System.Drawing.Point(4, 377)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(158, 15)
        Me.Label64.TabIndex = 196
        Me.Label64.Text = "Contraseña Ventek"
        '
        'txtUsuarioVentek
        '
        Me.txtUsuarioVentek.Location = New System.Drawing.Point(166, 348)
        Me.txtUsuarioVentek.Name = "txtUsuarioVentek"
        Me.txtUsuarioVentek.Size = New System.Drawing.Size(282, 20)
        Me.txtUsuarioVentek.TabIndex = 195
        '
        'Label65
        '
        Me.Label65.BackColor = System.Drawing.Color.Transparent
        Me.Label65.Location = New System.Drawing.Point(5, 351)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(134, 15)
        Me.Label65.TabIndex = 194
        Me.Label65.Text = "Usuario Ventek"
        '
        'FrmCompania
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(691, 625)
        Me.Controls.Add(Me.UiTab1)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCompania"
        Me.Text = "Compañia"
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        Me.UiTabCompania.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.PictIcono2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpActividad.ResumeLayout(False)
        Me.GrpActividad.PerformLayout()
        CType(Me.PictureBox31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpIcono.ResumeLayout(False)
        CType(Me.PictIcono, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDomicilio.ResumeLayout(False)
        Me.GrpDomicilio.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabCFD.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.PictureBox29, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpPAC.ResumeLayout(False)
        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPAC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabRiesgo.ResumeLayout(False)
        Me.GrpClase.ResumeLayout(False)
        CType(Me.GridClases, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabMail.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.UiTabParam.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.diasMaxDev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPedidosOpen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumTimeOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumHistorico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.NumLineNota, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumLineFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.NumCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabParam3.ResumeLayout(False)
        Me.UiTabParam3.PerformLayout()
        CType(Me.numMaxMesesSinInteres, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String = ""
    Private aEstado() As String
    Private aMnpio() As String
    Private aColonia() As String

    Public COMClave As String
    Public Icono As Byte()
    Public Icono2 As Byte()

    Private alerta(30) As PictureBox
    Private reloj As parpadea
    Private cargado As Boolean = False

    Private correo As New MailMessage
    Private adjuntos As Attachment
    Private autenticar As New NetworkCredential
    Private envio As New SmtpClient

    Private EstadoFac, MunicipioFac, ColoniaFac, sRiesgoSelected, sClave As String


    Private dtPAC, dtClase As DataTable
    Private ActualizaPAC As Boolean

    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If TxtDescVale.Text < 0 OrElse TxtDescVale.Text > 100 Then
            i += 1
            reloj = New parpadea(Me.alerta(29))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbTipoPersona.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(27))
            reloj.Enabled = True
            reloj.Start()
        Else
            If CmbTipoPersona.SelectedValue = 1 AndAlso TxtCURP.Text = "" Then
                i += 1
                reloj = New parpadea(Me.alerta(28))
                reloj.Enabled = True
                reloj.Start()
            End If
        End If

        If Me.TxtNombre.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtNombre.Text.Length > 60 Then
            Me.TxtNombre.Text = Me.TxtNombre.Text.Substring(0, 60)
        End If

        If Me.CmbPaisFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtEstadoFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtMunicipioFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtLocalidad.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtColoniaFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtCodigoPostal.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtDomicilioFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtNoExterior.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(8))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.TxtDireccion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(9))
            reloj.Enabled = True
            reloj.Start()
        End If



        If CmbImpuesto.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(10))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cmbCosteo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(23))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbFactura.SelectedItem Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(11))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbNC.SelectedItem Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(22))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbCargo.SelectedItem Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(25))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtRFC.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(12))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbFormatOC.SelectedItem Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(13))
            reloj.Enabled = True
            reloj.Start()
        End If


        If cmbTipoCF.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(14))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cmbVersionCF.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(15))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cmbRegimenFiscal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(16))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cmbMetodoPago.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(17))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.TxtXML.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(18))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cmbMoneda.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(19))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cmbMonedaCambio.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(20))
            reloj.Enabled = True
            reloj.Start()
        End If


        If cmbVersionCF.SelectedValue Is Nothing Then

            If Not (cmbVersionCF.SelectedValue = 1 Or cmbVersionCF.SelectedValue = 3 Or cmbVersionCF.SelectedValue = 5) AndAlso GridPAC.RowCount = 0 Then
                i += 1
                reloj = New parpadea(Me.alerta(21))
                reloj.Enabled = True
                reloj.Start()
            End If
        End If


        If Me.TxtImagenUrl.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(24))
            reloj.Enabled = True
            reloj.Start()
        End If

        If cmbNomina.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(26))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbPedido.SelectedItem Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(30))
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

    Private Sub FrmCompania_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor

        Dim dt As DataTable
        Dim Cnx As String

        Cnx = ModPOS.BDConexion

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
        alerta(11) = Me.PictureBox12
        alerta(12) = Me.PictureBox13
        alerta(13) = Me.PictureBox14

        alerta(14) = Me.PictureBox15
        alerta(15) = Me.PictureBox16
        alerta(16) = Me.PictureBox17
        alerta(17) = Me.PictureBox18
        alerta(18) = Me.PictureBox19
        alerta(19) = Me.PictureBox20
        alerta(20) = Me.PictureBox21

        alerta(21) = Me.PictureBox22
        alerta(22) = Me.PictureBox23
        alerta(23) = Me.PictureBox24
        alerta(24) = Me.PictureBox25
        alerta(25) = Me.PictureBox27
        alerta(26) = Me.PictureBox29
        alerta(27) = Me.PictureBox30
        alerta(28) = Me.PictureBox31
        alerta(29) = Me.PictureBox32
        alerta(30) = Me.PictureBox33

        With Me.CmbPaisFac
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Geografia"
            .NombreParametro2 = "campo"
            .Parametro2 = "Pais"
            .llenar()
        End With

        With Me.cmbCosteo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Producto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Costo"
            .llenar()
        End With

        With Me.CmbImpuesto
            .Conexion = BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_impuesto"
            .llenar()
        End With


        With Me.cmbTipoCF
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "CFD"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With Me.cmbVersionCF
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_versioncfd"
            .NombreParametro1 = "Grupo"
            .Parametro1 = IIf(cmbTipoCF.SelectedValue Is Nothing, 1, cmbTipoCF.SelectedValue)
            .llenar()
        End With

        With Me.cmbNomina
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Nomina"
            .NombreParametro2 = "campo"
            .Parametro2 = "Version"
            .llenar()
        End With

        With Me.cmbRegimenFiscal
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "CFD"
            .NombreParametro2 = "campo"
            .Parametro2 = "RegimenFiscal"
            .llenar()
        End With


        With Me.cmbMetodoPago
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "CFD"
            .NombreParametro2 = "campo"
            .Parametro2 = "MetodoPago"
            .llenar()
        End With

        With Me.cmbMoneda
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_monedas"
            .llenar()
        End With

        With Me.cmbMonedaCambio
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_monedas"
            .llenar()
        End With


        With Me.cmbRiesgoPuesto
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Empleado"
            .NombreParametro2 = "campo"
            .Parametro2 = "RiesgoPuesto"
            .llenar()
        End With

        With Me.CmbTipoPersona
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With


        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        If Padre = "Agregar" Then
            COMClave = ModPOS.obtenerLlave

            dtPAC = ModPOS.CrearTabla("CompanyPAC", _
            "TipoPAC", "System.Int32", _
            "PAC", "System.String", _
            "RFC", "System.String", _
            "UserId", "System.String", _
            "CustomerKey", "System.String", _
            "Serv. Timbrado", "System.String", _
            "Serv. Cancelación", "System.Int32", _
            "Timbres", "System.Int32", _
            "Orden", "System.Int32")


            dtClase = ModPOS.CrearTabla("ClaseRiesgo", _
                                    "IdRiesgo", "System.String", _
                                    "Clave", "System.String", _
                                    "Descripción", "System.String", _
                                    "Limite", "System.Boolean", _
                                    "ValorPedido", "System.Decimal", _
                                    "Verificación", "System.Boolean", _
                                    "Porc.Vencido", "System.Double", _
                                    "Antiguedad", "System.Int32", _
                                    "DiasCreditoPreventa", "System.Int32", _
                                    "LimiteCreditoPreventa", "System.Decimal", _
                                    "Modificado", "System.Int32", _
                                    "Baja", "System.Boolean")

        Else
            dt = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", COMClave)

            dtPAC = ModPOS.Recupera_Tabla("sp_recupera_companyPAC", "@COMClave", COMClave)

            dtClase = ModPOS.Recupera_Tabla("st_recupera_riesgos", "@COMClave", COMClave)

            With Me

                .TxtClave.Text = IIf(dt.Rows(0)("Clave").GetType.Name = "DBNull", "", dt.Rows(0)("Clave"))
                .TxtNombre.Text = dt.Rows(0)("Nombre")
                .txtComercial.Text = IIf(dt.Rows(0)("NomComercial").GetType.Name = "DBNull", "", dt.Rows(0)("NomComercial"))
                .txtPoliticaPrivacidad.Text = IIf(dt.Rows(0)("PoliticaPrivacidad").GetType.Name = "DBNull", "", dt.Rows(0)("PoliticaPrivacidad"))
                .CmbTipoPersona.SelectedValue = IIf(dt.Rows(0)("TPersona").GetType.Name = "DBNull", 2, dt.Rows(0)("TPersona"))
                .TxtRFC.Text = dt.Rows(0)("id_Fiscal")
                .TxtCURP.Text = IIf(dt.Rows(0)("CURP").GetType.Name = "DBNull", "", dt.Rows(0)("CURP"))
                .CmbPaisFac.Text = dt.Rows(0)("Pais")
                .EstadoFac = dt.Rows(0)("Estado")
                .MunicipioFac = dt.Rows(0)("Municipio")
                .ColoniaFac = dt.Rows(0)("Colonia")
                .TxtDomicilioFac.Text = dt.Rows(0)("Calle")
                .TxtCodigoPostal.Text = dt.Rows(0)("CodigoPostal")
                .TxtReferencia.Text = dt.Rows(0)("Referencia")
                .TxtLocalidad.Text = dt.Rows(0)("Localidad")
                .TxtNoExterior.Text = dt.Rows(0)("noExterior")
                .TxtNoInterior.Text = dt.Rows(0)("noInterior")
                .TxtTelefono.Text = dt.Rows(0)("Telefono")
                .TxtFax.Text = dt.Rows(0)("Fax")
                .TxtEstadoFac.Text = EstadoFac
                .TxtMunicipioFac.Text = MunicipioFac
                .TxtColoniaFac.Text = ColoniaFac
                .TxtRegPatronal.Text = IIf(dt.Rows(0)("registroPatronal").GetType.Name = "DBNull", "", dt.Rows(0)("registroPatronal"))
                .cmbRiesgoPuesto.SelectedValue = IIf(dt.Rows(0)("RiesgoPuesto").GetType.Name = "DBNull", 0, dt.Rows(0)("RiesgoPuesto"))


               


                If Not dt.Rows(0)("Logo") Is System.DBNull.Value Then
                    .PictIcono.Image = ModPOS.RecuperaIcono(CType(dt.Rows(0)("Logo"), Byte()))
                    .Icono = CType(dt.Rows(0)("Logo"), Byte())
                End If


                If Not dt.Rows(0)("Logo2") Is System.DBNull.Value Then
                    .PictIcono2.Image = ModPOS.RecuperaIcono(CType(dt.Rows(0)("Logo2"), Byte()))
                    .Icono2 = CType(dt.Rows(0)("Logo2"), Byte())
                End If


            End With


            cargado = True

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


            dt.Dispose()


            dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", COMClave)
            With Me
                Dim i As Integer
                For i = 0 To dt.Rows.Count - 1
                    Select Case CStr(dt.Rows(i)("PARClave"))
                        Case "DigitoOrd"
                            .NumCompra.Value = CInt(dt.Rows(i)("Valor"))
                        Case "DigitoProv"
                            .NumProveedor.Value = CInt(dt.Rows(i)("Valor"))
                        Case "Digitos"
                            .NumCliente.Value = CInt(dt.Rows(i)("Valor"))
                        Case "DirXML"
                            .TxtXML.Text = dt.Rows(i)("Valor")
                        Case "Imagenes"
                            .TxtImagenUrl.Text = dt.Rows(i)("Valor")
                        Case "Impuesto"
                            .CmbImpuesto.SelectedValue = dt.Rows(i)("Valor")
                        Case "LineasFac"
                            .NumLineFactura.Value = CInt(dt.Rows(i)("Valor"))
                        Case "LineasNC"
                            .NumLineNota.Value = CInt(dt.Rows(i)("Valor"))
                        Case "NumMesHist"
                            .NumHistorico.Value = dt.Rows(i)("Valor")
                        Case "InterfazSalida"
                            .txtInterfaz.Text = dt.Rows(i)("Valor")
                        Case "MailAdress"
                            .TxtMailAdress.Text = dt.Rows(i)("Valor")
                        Case "DisplayName"
                            .TxtDisplayName.Text = dt.Rows(i)("Valor")
                        Case "MailUser"
                            .TxtMailUser.Text = dt.Rows(i)("Valor")
                        Case "MailPassword"
                            .TxtMailPassword.Text = dt.Rows(i)("Valor")
                        Case "HostSMTP"
                            .TxtHostSMTP.Text = dt.Rows(i)("Valor")
                        Case "MailPort"
                            If dt.Rows(i)("Valor") <> "" Then
                                .TxtMailPort.Text = dt.Rows(i)("Valor")
                            Else
                                .TxtMailPort.Text = 1
                            End If
                        Case "MailSSL"
                            .ChkMailSSL.Estado = dt.Rows(i)("Valor")
                        Case "RepOrden"
                            .CmbFormatOC.SelectedItem = dt.Rows(i)("Valor")
                        Case "TimeOut"
                            .NumTimeOut.Value = IIf(IsNumeric(dt.Rows(i)("Valor")) = True, CInt(dt.Rows(i)("Valor")), 0)
                        Case "TipoCF"
                            .cmbTipoCF.SelectedValue = dt.Rows(i)("Valor")
                        Case "VersionCF"
                            .cmbVersionCF.SelectedValue = dt.Rows(i)("Valor")
                        Case "RegimenFiscal"
                            .cmbRegimenFiscal.SelectedValue = dt.Rows(i)("Valor")
                        Case "MetodoPago"
                            .cmbMetodoPago.SelectedValue = dt.Rows(i)("Valor")
                        Case "Moneda"
                            .cmbMoneda.SelectedValue = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "MonedaCambio"
                            .cmbMonedaCambio.SelectedValue = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "FormatFac"
                            .cmbFactura.SelectedItem = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "FormatNC"
                            .cmbNC.SelectedItem = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "FormatCargo"
                            .cmbCargo.SelectedItem = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "FormatPedido"
                            .cmbPedido.SelectedItem = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "SUCURSAL"
                            .txtSucursal.Text = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "CONCENTRADOR"
                            .txtConcentrador.Text = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "Aplicacion"
                            .ChkAplicacion.Estado = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "Costeo"
                            .cmbCosteo.SelectedValue = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "CFDCompras"
                            .TxtDireccion.Text = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "Version"
                            .txtVersion.Text = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "Domicilio"
                            .ChkDomicilio.Estado = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "Reemplazo"
                            .txtReemplazo.Text = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "VersionNomina"
                            .cmbNomina.SelectedValue = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "ValidaCtaPago"
                            .ChkValidaCtaPago.Estado = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 1, dt.Rows(i)("Valor"))
                        Case "ActPreCompra"
                            .ChkActPrecios.Estado = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "PrecioBase"
                            .ChkPrecioBase.Estado = IIf(IsNumeric(dt.Rows(i)("Valor")) = True, CInt(dt.Rows(i)("Valor")), 0)
                        Case "Compartir"
                            .ChkCompartir.Estado = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "TallaColor"
                            .ChkTallaColor.Estado = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "MascaraCte"
                            .chkMaskCte.Estado = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "CobranzaVenta"
                            .chkCobranzaVenta.Estado = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "DescVale"
                            .TxtDescVale.Text = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "NumDiasAbierto"
                            .numPedidosOpen.Value = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "DevConcentra"
                            .chkDevConcentra.Estado = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "BusqDev"
                            .diasMaxDev.Value = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "IdComercioTA"
                            .txtIdComercioTA.Text = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "idTerminalTA"
                            .txtidTerminalTA.Text = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "MontoMinSinInteres"
                            .txtMontoMinSinInteres.Text = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "0", dt.Rows(i)("Valor"))
                        Case "MaxMesesSinInteres"
                            .numMaxMesesSinInteres.Value = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "urlServicioTA"
                            .txturlServicioTA.Text = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "DirIntEntrada"
                            .txtEntrada.Text = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "SincronizaCliente"
                            .chkSincronizarCte.Estado = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "BuscaNegados"
                            .chkNegados.Estado = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "AplicaPromocionFinal"
                            .chkAplicaPromo.Estado = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 1, dt.Rows(i)("Valor"))
                        Case "LimitaCompraEmp"
                            .txtLimitaCompraEmp.Text = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "PrvSucursal"
                            .CmbSucursal.SelectedValue = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "LimitarCobroFactura"
                            .ChkLimitarCobroFac.Estado = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "ReciboPorAreas"
                            .ChkReciboAreas.Estado = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "IngresoSimple"
                            .ChkIngresoSimple.Estado = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Case "UsuarioRecargas"
                            .txtUsuarioVentek.Text = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "ContrasenaRecargas"
                            .txtPwdVentek.Text = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                        Case "urlRecargasTel"
                            .txtUrlVentek.Text = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))

                    End Select
                Next
            End With

            dt.Dispose()

        End If


        GridPAC.DataSource = dtPAC
        GridPAC.RetrieveStructure(True)
        GridPAC.GroupByBoxVisible = False
        GridPAC.RootTable.Columns("TipoPAC").Visible = False
        GridPAC.CurrentTable.Columns("PAC").Selectable = False
        Cursor.Current = Cursors.Default


        GridClases.DataSource = dtClase
        GridClases.RetrieveStructure(True)
        GridClases.GroupByBoxVisible = False
        GridClases.RootTable.Columns("IdRiesgo").Visible = False
        GridClases.RootTable.Columns("Modificado").Visible = False
        GridClases.CurrentTable.Columns("Baja").Visible = False
        GridClases.RootTable.Columns("Clave").Selectable = False



        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridClases.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridClases.RootTable.FormatConditions.Add(fc)

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



            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub testMail()
        Dim frmStatusMessage As New frmStatus
        Try
            correo.Body = "Prueba de Correo Electrónico Selling"
            correo.Subject = "eMail Test"
            correo.IsBodyHtml = True
            correo.To.Clear()
            correo.CC.Clear()
            correo.Bcc.Clear()

            correo.To.Add(Trim(TxtMailAdress.Text))

            correo.From = New MailAddress(TxtMailAdress.Text.Trim, TxtDisplayName.Text.Trim)
            envio.Credentials = New NetworkCredential(TxtMailUser.Text.Trim, TxtMailPassword.Text.Trim)
            envio.Host = TxtHostSMTP.Text.Trim  '"smtp.live.com"
            envio.Port = CInt(TxtMailPort.Text.Trim)  '587
            envio.EnableSsl = IIf(ChkMailSSL.GetEstado = 1, True, False) 'True
            frmStatusMessage.Show("Enviando correo electrónico...")
            envio.Send(correo)
            MessageBox.Show("El mensaje fue enviado correctamente a el destinatario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmStatusMessage.Dispose()
        Catch ex As Exception
            frmStatusMessage.Dispose()
            MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Me.validaForm() Then

            'If txtConcentrador.Text <> "" Then
            '    If ValidaIP(txtConcentrador.Text) = False Then
            '        MessageBox.Show("La IP del Concentrador es Invalida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        Exit Sub
            '    Else
            '        txtConcentrador.Text = System.Net.IPAddress.Parse(txtConcentrador.Text).ToString

            '    End If
            'End If

            Try
                If Not System.IO.Directory.Exists(TxtDireccion.Text) Then
                    MessageBox.Show("No se tiene acceso al directorio de Comprobantes Fiscales Digitales (XML) de Proveedores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
            End Try

            Try
                If Not System.IO.Directory.Exists(TxtImagenUrl.Text) Then
                    MessageBox.Show("No se tiene acceso al directorio de Imagenes de Productos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
            End Try


            Try
                If Not System.IO.Directory.Exists(TxtXML.Text) Then
                    MessageBox.Show("No se tiene acceso al directorio de Comprobantes Fiscales Digitales (XML)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
            End Try

            Try
                If Not System.IO.Directory.Exists(txtVersion.Text) Then
                    MessageBox.Show("No se tiene acceso al directorio de versión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As Exception
            End Try

            Dim i As Integer
            Dim foundRows() As DataRow

            If Padre = "Agregar" Then
                ModPOS.Ejecuta("sp_insertar_Compania", _
                              "@COMClave", COMClave, _
                              "@Clave", UCase(Trim(TxtClave.Text)), _
                              "@Logo", Icono, _
                              "@Nombre", UCase(Trim(TxtNombre.Text)), _
                              "@Comercial", Trim(txtComercial.Text), _
                               "@Politica", Trim(txtPoliticaPrivacidad.Text), _
                              "@TPersona", CmbTipoPersona.SelectedValue, _
                              "@RFC", TxtRFC.Text.ToUpper.Trim, _
                              "@CURP", TxtCURP.Text.ToUpper.Trim, _
                              "@Pais", CmbPaisFac.Text.ToUpper.Trim, _
                              "@Entidad", TxtEstadoFac.Text.ToUpper.Trim, _
                              "@Municipio", TxtMunicipioFac.Text.ToUpper.Trim, _
                              "@Colonia", TxtColoniaFac.Text.ToUpper.Trim, _
                              "@Calle", TxtDomicilioFac.Text.ToUpper.Trim, _
                              "@codigoPostal", TxtCodigoPostal.Text.ToUpper.Trim, _
                              "@Localidad", TxtLocalidad.Text.ToUpper.Trim, _
                              "@referencia", TxtReferencia.Text.ToUpper.Trim, _
                              "@noExterior", TxtNoExterior.Text.ToUpper.Trim, _
                              "@noInterior", TxtNoInterior.Text.ToUpper.Trim, _
                              "@Telefono", TxtTelefono.Text, _
                              "@Fax", TxtFax.Text, _
                              "@Ticket", 1, _
                              "@Factura", 1, _
                              "@Folio", 0, _
                              "@registroPatronal", TxtRegPatronal.Text, _
                               "@Logo2", Icono2, _
                              "@RiesgoPuesto", cmbRiesgoPuesto.SelectedValue, _
                              "@Usuario", ModPOS.UsuarioActual)

                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "DigitoOrd", "@Orden", 1, "@Valor", CStr(Me.NumCompra.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "DigitoProv", "@Orden", 2, "@Valor", CStr(Me.NumProveedor.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "Digitos", "@Orden", 3, "@Valor", CStr(Me.NumCliente.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "DirXML", "@Orden", 4, "@Valor", TxtXML.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "Imagenes", "@Orden", 5, "@Valor", TxtImagenUrl.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "Impuesto", "@Orden", 6, "@Valor", CmbImpuesto.SelectedValue, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "LineasFac", "@Orden", 7, "@Valor", CStr(Me.NumLineFactura.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "LineasNC", "@Orden", 8, "@Valor", CStr(Me.NumLineNota.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "SUCURSAL", "@Orden", 9, "@Valor", txtSucursal.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "NumMesHist", "@Orden", 10, "@Valor", CStr(Me.NumHistorico.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "InterfazSalida", "@Orden", 11, "@Valor", txtInterfaz.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "MailAdress", "@Orden", 12, "@Valor", TxtMailAdress.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "DisplayName", "@Orden", 13, "@Valor", TxtDisplayName.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "MailUser", "@Orden", 14, "@Valor", TxtMailUser.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "MailPassword", "@Orden", 15, "@Valor", TxtMailPassword.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "HostSMTP", "@Orden", 16, "@Valor", TxtHostSMTP.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "MailPort", "@Orden", 17, "@Valor", TxtMailPort.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "MailSSL", "@Orden", 18, "@Valor", ChkMailSSL.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "RepOrden", "@Orden", 19, "@Valor", CmbFormatOC.SelectedItem, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "TimeOut", "@Orden", 20, "@Valor", CStr(Me.NumTimeOut.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "TipoCF", "@Orden", 21, "@Valor", CStr(cmbTipoCF.SelectedValue), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "VersionCF", "@Orden", 22, "@Valor", CStr(cmbVersionCF.SelectedValue), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "RegimenFiscal", "@Orden", 23, "@Valor", CStr(cmbRegimenFiscal.SelectedValue), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "MetodoPago", "@Orden", 24, "@Valor", CStr(cmbMetodoPago.SelectedValue), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "Moneda", "@Orden", 25, "@Valor", cmbMoneda.SelectedValue, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "MonedaCambio", "@Orden", 26, "@Valor", cmbMonedaCambio.SelectedValue, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "FormatFac", "@Orden", 27, "@Valor", cmbFactura.SelectedItem, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "Aplicacion", "@Orden", 28, "@Valor", ChkAplicacion.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "Costeo", "@Orden", 29, "@Valor", cmbCosteo.SelectedValue, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "CFDCompras", "@Orden", 30, "@Valor", TxtDireccion.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "FormatNC", "@Orden", 31, "@Valor", cmbNC.SelectedItem, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "FormatCargo", "@Orden", 32, "@Valor", cmbCargo.SelectedItem, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "Version", "@Orden", 33, "@Valor", txtVersion.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "Domicilio", "@Orden", 34, "@Valor", ChkDomicilio.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "Reemplazo", "@Orden", 35, "@Valor", txtReemplazo.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "VersionNomina", "@Orden", 36, "@Valor", cmbNomina.SelectedValue, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "ValidaCtaPago", "@Orden", 37, "@Valor", ChkValidaCtaPago.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "ActPreCompra", "@Orden", 38, "@Valor", ChkActPrecios.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "PrecioBase", "@Orden", 39, "@Valor", ChkPrecioBase.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "Compartir", "@Orden", 40, "@Valor", ChkCompartir.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "TallaColor", "@Orden", 41, "@Valor", ChkTallaColor.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "DescVale", "@Orden", 42, "@Valor", TxtDescVale.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "NumDiasAbierto", "@Orden", 43, "@Valor", CStr(Me.numPedidosOpen.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "FormatPedido", "@Orden", 44, "@Valor", cmbPedido.SelectedItem, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "DevConcentra", "@Orden", 45, "@Valor", chkDevConcentra.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "BusqDev", "@Orden", 46, "@Valor", diasMaxDev.Value, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "CONCENTRADOR", "@Orden", 47, "@Valor", txtConcentrador.Text, "@COMClave", COMClave)

                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "MascaraCte", "@Orden", 48, "@Valor", chkMaskCte.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "CobranzaVenta", "@Orden", 49, "@Valor", chkCobranzaVenta.GetEstado, "@COMClave", COMClave)

                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "IdComercioTA", "@Orden", 50, "@Valor", txtIdComercioTA.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "idTerminalTA", "@Orden", 51, "@Valor", txtidTerminalTA.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "MontoMinSinInteres", "@Orden", 52, "@Valor", txtMontoMinSinInteres.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "MaxMesesSinInteres", "@Orden", 53, "@Valor", CStr(numMaxMesesSinInteres.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "urlServicioTA", "@Orden", 54, "@Valor", txturlServicioTA.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "DirIntEntrada", "@Orden", 55, "@Valor", txtEntrada.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "SincronizaCliente", "@Orden", 56, "@Valor", chkSincronizarCte.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "BuscaNegados", "@Orden", 57, "@Valor", chkNegados.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "AplicaPromocionFinal", "@Orden", 58, "@Valor", chkAplicaPromo.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "LimitaCompraEmp", "@Orden", 59, "@Valor", txtLimitaCompraEmp.Text, "@COMClave", COMClave)

                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "PrvSucursal", "@Orden", 60, "@Valor", CmbSucursal.SelectedValue, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "LimitarCobroFactura", "@Orden", 61, "@Valor", ChkLimitarCobroFac.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "ReciboPorAreas", "@Orden", 62, "@Valor", ChkReciboAreas.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "IngresoSimple", "@Orden", 63, "@Valor", ChkIngresoSimple.GetEstado, "@COMClave", COMClave)

                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "urlRecargasTel", "@Orden", 64, "@Valor", txtUrlVentek.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "UsuarioRecargas", "@Orden", 65, "@Valor", txtUsuarioVentek.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_inserta_parametro", "@PARClave", "ContrasenaRecargas", "@Orden", 66, "@Valor", txtPwdVentek.Text, "@COMClave", COMClave)
               
                'PAC
                If dtPAC.Rows.Count > 0 Then
                    For i = 0 To dtPAC.Rows.Count - 1
                        ModPOS.Ejecuta("sp_inserta_PAC", _
                      "@COMClave", COMClave, _
                      "@TipoPAC", dtPAC.Rows(i)("TipoPAC"), _
                      "@RFC", dtPAC.Rows(i)("RFC"), _
                      "@UserId", dtPAC.Rows(i)("UserId"), _
                      "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), _
                      "@ServerTimbre", IIf(dtPAC.Rows(i)("Serv. Timbrado") = "Error", "", dtPAC.Rows(i)("Serv. Timbrado")), _
                      "@ServerCancel", IIf(dtPAC.Rows(i)("Serv. Cancelación") = "Error", "", dtPAC.Rows(i)("Serv. Cancelación")), _
                      "@Timbres", dtPAC.Rows(i)("Timbres"), _
                      "@Orden", dtPAC.Rows(i)("Orden"), _
                      "@Usuario", ModPOS.UsuarioActual)
                    Next
                End If

                foundRows = dtClase.Select("Baja = 0")

                If foundRows.GetLength(0) > 0 Then
                    For i = 0 To foundRows.GetUpperBound(0)

                        ModPOS.Ejecuta("st_inserta_riesgo", _
                                              "@COMClave", COMClave, _
                                              "@IdRiesgo", foundRows(i)("IdRiesgo"), _
                                              "@Clave", foundRows(i)("Clave"), _
                                              "@Descripcion", foundRows(i)("Descripción"), _
                                              "@Limite", foundRows(i)("Limite"), _
                                              "@ValorPedido", foundRows(i)("ValorPedido"), _
                                              "@Verificacion", foundRows(i)("Verificación"), _
                                              "@PorcPedido", foundRows(i)("Porc.Vencido"), _
                                              "@Dias", foundRows(i)("Antiguedad"), _
                                              "@DiasCreditoPreventa", foundRows(i)("DiasCreditoPreventa"), _
                                              "@LimiteCreditoPreventa", foundRows(i)("LimiteCreditoPreventa"), _
                                              "@Baja", foundRows(i)("Baja"), _
                                              "@Usuario", ModPOS.UsuarioActual)

                    Next
                End If


                Me.Close()
            Else

                ModPOS.Ejecuta("sp_actualiza_Compania", _
                "@COMClave", COMClave, _
                "@Clave", UCase(Trim(TxtClave.Text)), _
                 "@Comercial", Trim(txtComercial.Text), _
                  "@Politica", Trim(txtPoliticaPrivacidad.Text), _
                "@Logo", Icono, _
                "@Nombre", UCase(Trim(TxtNombre.Text)), _
                 "@TPersona", CmbTipoPersona.SelectedValue, _
                "@RFC", TxtRFC.Text.ToUpper.Trim, _
                 "@CURP", TxtCURP.Text.ToUpper.Trim, _
                "@Pais", CmbPaisFac.Text.ToUpper.Trim, _
                "@Entidad", TxtEstadoFac.Text.ToUpper.Trim, _
                "@Municipio", TxtMunicipioFac.Text.ToUpper.Trim, _
                "@Colonia", TxtColoniaFac.Text.ToUpper.Trim, _
                "@Calle", TxtDomicilioFac.Text.ToUpper.Trim, _
                "@codigoPostal", TxtCodigoPostal.Text.ToUpper.Trim, _
                "@Localidad", TxtLocalidad.Text.ToUpper.Trim, _
                "@referencia", TxtReferencia.Text.ToUpper.Trim, _
                "@noExterior", TxtNoExterior.Text.ToUpper.Trim, _
                "@noInterior", TxtNoInterior.Text.ToUpper.Trim, _
                "@Telefono", TxtTelefono.Text, _
                "@Fax", TxtFax.Text, _
                "@Ticket", 1, _
                "@Factura", 1, _
                "@Folio", 0, _
                "@registroPatronal", TxtRegPatronal.Text, _
                 "@Logo2", Icono2, _
                "@RiesgoPuesto", cmbRiesgoPuesto.SelectedValue, _
                "@Usuario", ModPOS.UsuarioActual)

                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "DigitoOrd", "@Valor", CStr(Me.NumCompra.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "DigitoProv", "@Valor", CStr(Me.NumProveedor.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "Digitos", "@Valor", CStr(Me.NumCliente.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "DirXML", "@Valor", TxtXML.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "Imagenes", "@Valor", TxtImagenUrl.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "Impuesto", "@Valor", CmbImpuesto.SelectedValue, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "LineasFac", "@Valor", CStr(Me.NumLineFactura.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "LineasNC", "@Valor", CStr(Me.NumLineNota.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "SUCURSAL", "@Valor", txtSucursal.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "NumMesHist", "@Valor", CStr(Me.NumHistorico.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "InterfazSalida", "@Valor", txtInterfaz.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "MailAdress", "@Valor", TxtMailAdress.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "DisplayName", "@Valor", TxtDisplayName.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "MailUser", "@Valor", TxtMailUser.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "MailPassword", "@Valor", TxtMailPassword.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "HostSMTP", "@Valor", TxtHostSMTP.Text.Trim, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "MailPort", "@Valor", TxtMailPort.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "MailSSL", "@Valor", ChkMailSSL.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "RepOrden", "@Valor", CmbFormatOC.SelectedItem, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "TimeOut", "@Valor", CStr(Me.NumTimeOut.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "TipoCF", "@Valor", CStr(cmbTipoCF.SelectedValue), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "VersionCF", "@Valor", CStr(cmbVersionCF.SelectedValue), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "RegimenFiscal", "@Valor", CStr(cmbRegimenFiscal.SelectedValue), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "Moneda", "@Valor", cmbMoneda.SelectedValue, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "MonedaCambio", "@Valor", cmbMonedaCambio.SelectedValue, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "MetodoPago", "@Valor", CStr(cmbMetodoPago.SelectedValue), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "FormatFac", "@Valor", cmbFactura.SelectedItem, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "Aplicacion", "@Valor", ChkAplicacion.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "Costeo", "@Valor", cmbCosteo.SelectedValue, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "CFDCompras", "@Valor", TxtDireccion.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "FormatNC", "@Valor", cmbNC.SelectedItem, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "FormatCargo", "@Valor", cmbCargo.SelectedItem, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "Version", "@Valor", txtVersion.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "Domicilio", "@Valor", ChkDomicilio.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "Reemplazo", "@Valor", txtReemplazo.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "VersionNomina", "@Valor", cmbNomina.SelectedValue, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "ValidaCtaPago", "@Valor", ChkValidaCtaPago.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "ActPreCompra", "@Valor", ChkActPrecios.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "PrecioBase", "@Valor", ChkPrecioBase.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "Compartir", "@Valor", ChkCompartir.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "TallaColor", "@Valor", ChkTallaColor.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "DescVale", "@Valor", TxtDescVale.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "NumDiasAbierto", "@Valor", CStr(Me.numPedidosOpen.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "FormatPedido", "@Valor", cmbPedido.SelectedItem, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "DevConcentra", "@Valor", chkDevConcentra.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "BusqDev", "@Valor", diasMaxDev.Value, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "CONCENTRADOR", "@Valor", txtConcentrador.Text, "@COMClave", COMClave)

                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "MascaraCte", "@Valor", chkMaskCte.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "CobranzaVenta", "@Valor", chkCobranzaVenta.GetEstado, "@COMClave", COMClave)


                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "IdComercioTA", "@Valor", txtIdComercioTA.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "idTerminalTA", "@Valor", txtidTerminalTA.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "MontoMinSinInteres", "@Valor", txtMontoMinSinInteres.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "MaxMesesSinInteres", "@Valor", CStr(numMaxMesesSinInteres.Value), "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "urlServicioTA", "@Valor", txturlServicioTA.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "DirIntEntrada", "@Valor", txtEntrada.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "SincronizaCliente", "@Valor", chkSincronizarCte.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "BuscaNegados", "@Valor", chkNegados.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "AplicaPromocionFinal", "@Valor", chkAplicaPromo.GetEstado, "@COMClave", COMClave)

                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "LimitaCompraEmp", "@Valor", txtLimitaCompraEmp.Text, "@COMClave", COMClave)


                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "PrvSucursal", "@Valor", CmbSucursal.SelectedValue, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "LimitarCobroFactura", "@Valor", ChkLimitarCobroFac.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "ReciboPorAreas", "@Valor", ChkReciboAreas.GetEstado, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "IngresoSimple", "@Valor", ChkIngresoSimple.GetEstado, "@COMClave", COMClave)


                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "urlRecargasTel", "@Valor", txtUrlVentek.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "UsuarioRecargas", "@Valor", txtUsuarioVentek.Text, "@COMClave", COMClave)
                ModPOS.Ejecuta("sp_actualiza_parametro", "@Clave", "ContrasenaRecargas", "@Valor", txtPwdVentek.Text, "@COMClave", COMClave)


                'PAC
                If ActualizaPAC AndAlso dtPAC.Rows.Count > 0 Then

                    ModPOS.Ejecuta("sp_elimina_PAC", "@COMClave", COMClave)


                    For i = 0 To dtPAC.Rows.Count - 1
                        ModPOS.Ejecuta("sp_inserta_PAC", _
                      "@COMClave", COMClave, _
                      "@TipoPAC", dtPAC.Rows(i)("TipoPAC"), _
                      "@UserId", dtPAC.Rows(i)("UserId"), _
                      "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), _
                      "@ServerTimbre", IIf(dtPAC.Rows(i)("Serv. Timbrado") = "Error", "", dtPAC.Rows(i)("Serv. Timbrado")), _
                      "@ServerCancel", IIf(dtPAC.Rows(i)("Serv. Cancelación") = "Error", "", dtPAC.Rows(i)("Serv. Cancelación")), _
                      "@Timbres", dtPAC.Rows(i)("Timbres"), _
                      "@Orden", dtPAC.Rows(i)("Orden"), _
                      "@Usuario", ModPOS.UsuarioActual)
                    Next

                    ActualizaPAC = False
                End If

                foundRows = dtClase.Select("Modificado = 1")

                If foundRows.GetLength(0) > 0 Then
                    For i = 0 To foundRows.GetUpperBound(0)

                        ModPOS.Ejecuta("st_inserta_riesgo", _
                                              "@COMClave", COMClave, _
                                              "@IdRiesgo", foundRows(i)("IdRiesgo"), _
                                              "@Clave", foundRows(i)("Clave"), _
                                              "@Descripcion", foundRows(i)("Descripción"), _
                                              "@Limite", foundRows(i)("Limite"), _
                                              "@ValorPedido", foundRows(i)("ValorPedido"), _
                                              "@Verificacion", foundRows(i)("Verificación"), _
                                              "@PorcPedido", foundRows(i)("Porc.Vencido"), _
                                              "@Dias", foundRows(i)("Antiguedad"), _
                                              "@DiasCreditoPreventa", foundRows(i)("DiasCreditoPreventa"), _
                                              "@LimiteCreditoPreventa", foundRows(i)("LimiteCreditoPreventa"), _
                                              "@Baja", foundRows(i)("Baja"), _
                                              "@Usuario", ModPOS.UsuarioActual)

                    Next
                End If


                Me.Close()

            End If

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmCompania_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoCompania Is Nothing Then
            ModPOS.ActualizaGrid(False, ModPOS.MtoCompania.GridCompania, "sp_muestra_companias", Nothing)
            ModPOS.MtoCompania.GridCompania.RootTable.Columns("COMClave").Visible = False
        End If
        ModPOS.Compania.Dispose()
        ModPOS.Compania = Nothing
    End Sub

    Private Sub BtnExplorador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExplorador.Click
        Dim a As New System.Windows.Forms.FolderBrowserDialog
        If (a.ShowDialog() = DialogResult.OK) Then
            TxtDireccion.Text = a.SelectedPath
        End If
    End Sub


    Private Sub BtnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTest.Click
        testMail()
    End Sub

    Private Sub BtnXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnXML.Click
        Dim a As New System.Windows.Forms.FolderBrowserDialog
        If (a.ShowDialog() = DialogResult.OK) Then

            If a.SelectedPath.Length <= 3 Then
                TxtXML.Text = a.SelectedPath
            Else
                TxtXML.Text = a.SelectedPath
            End If
        End If
    End Sub

    Private Sub cmbTipoCF_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoCF.SelectedValueChanged
        If cargado = True AndAlso Not cmbTipoCF.SelectedValue Is Nothing Then
            With Me.cmbVersionCF
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_versioncfd"
                .NombreParametro1 = "Grupo"
                .Parametro1 = cmbTipoCF.SelectedValue
                .llenar()
            End With
        End If
    End Sub

    Private Sub TxtEstadoFac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtEstadoFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtEstadoFac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEstadoFac.LostFocus
        If TxtEstadoFac.Text <> "" AndAlso TxtEstadoFac.Text <> EstadoFac Then
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
        If TxtEstadoFac.Text <> "" AndAlso TxtMunicipioFac.Text <> "" AndAlso TxtMunicipioFac.Text <> MunicipioFac Then
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
            If TxtLocalidad.Text = "" Then
                Me.TxtLocalidad.Text = TxtMunicipioFac.Text
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
        If TxtColoniaFac.Text <> "" AndAlso TxtColoniaFac.Text <> ColoniaFac AndAlso TxtEstadoFac.Text <> "" AndAlso TxtMunicipioFac.Text <> "" AndAlso TxtMunicipioFac.Text <> MunicipioFac Then
            Dim dtCP As DataTable
            dtCP = ModPOS.Recupera_Tabla("sp_recupera_cp", "@Estado", TxtEstadoFac.Text.ToUpper.Trim, "@Municipio", TxtMunicipioFac.Text.Trim.ToUpper, "@Colonia", TxtColoniaFac.Text.Trim.ToUpper)
            If dtCP.Rows.Count > 0 Then
                Me.TxtCodigoPostal.Text = dtCP.Rows(0)("codigo_postal")
                dtCP.Dispose()
            End If
        End If
    End Sub

    Private Sub TxtLocalidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLocalidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtCodigoPostal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoPostal.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtDireccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDireccion.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtNoExterior_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNoExterior.KeyDown
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

    Private Sub BtnAddPAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddPAC.Click
        Dim a As New FrmPAC
        a.COMClave = COMClave
        a.ShowDialog()
    End Sub

    Public Sub AddRiesgo( _
 ByVal sClave As String, _
 ByVal sDescripcion As String, _
 ByVal bLimite As Boolean, _
 ByVal dValorPedido As Double, _
 ByVal bVerificacion As Boolean, _
 ByVal dPorcVencido As Double, _
 ByVal iDias As Integer, _
 ByVal iDiasPreventa As Integer, _
 ByVal dCreditoPreventa As Decimal)


        Dim foundRows() As Data.DataRow
        foundRows = dtClase.Select("Clave = '" & sClave & "' and Baja=0")

        If foundRows.Length = 0 Then

            Dim row1 As DataRow
            row1 = dtClase.NewRow()
            'declara el nombre de la fila

            row1.Item("IdRiesgo") = ModPOS.obtenerLlave
            row1.Item("Clave") = sClave
            row1.Item("Descripción") = sDescripcion
            row1.Item("Limite") = bLimite
            row1.Item("ValorPedido") = dValorPedido
            row1.Item("Verificación") = bVerificacion
            row1.Item("Porc.Vencido") = dPorcVencido
            row1.Item("Antiguedad") = iDias
            row1.Item("DiasCreditoPreventa") = iDiasPreventa
            row1.Item("LimiteCreditoPreventa") = dCreditoPreventa
            row1.Item("Modificado") = 1
            row1.Item("Baja") = 0

            dtClase.Rows.Add(row1)
            'agrega la fila completo a la tabla


        Else
            Beep()
            MessageBox.Show("¡La clave de clase de riesgo ya existe para la Compañia actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub


    Public Sub AddPAC( _
    ByVal TipoPac As Integer, _
    ByVal PAC As String, _
    ByVal CustomerKey As String, _
    ByVal ServerTimbre As String, _
    ByVal ServerCancel As String, _
    ByVal UserId As String, _
    ByVal Timbres As Integer, _
    ByVal rfc As String)


        Dim foundRows() As Data.DataRow
        foundRows = dtPAC.Select("TipoPAC = " & CStr(TipoPac))

        If foundRows.Length = 0 Then

            Dim row1 As DataRow
            row1 = dtPAC.NewRow()
            'declara el nombre de la fila

            row1.Item("TipoPAC") = TipoPac
            row1.Item("PAC") = PAC
            row1.Item("RFC") = rfc
            row1.Item("UserId") = UserId
            row1.Item("CustomerKey") = CustomerKey
            row1.Item("Serv. Timbrado") = ServerTimbre
            row1.Item("Serv. Cancelación") = ServerCancel
            row1.Item("Timbres") = Timbres
            row1.Item("Orden") = dtPAC.Rows.Count + 1
            dtPAC.Rows.Add(row1)
            'agrega la fila completo a la tabla

            If Padre = "Modificar" Then
                ActualizaPAC = True
            End If
        Else
            Beep()
            MessageBox.Show("¡El PAC que intenta agregar ya existe para la Compañia actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnDelPAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelPAC.Click
        If GridPAC.Row >= 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el PAC: " & GridPAC.GetValue("PAC"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtPAC.Select("TipoPAC = " & CStr(GridPAC.GetValue("TipoPAC")))

                    dtPAC.Rows.Remove(foundRows(0))

                    If Padre = "Modificar" Then
                        ActualizaPAC = True
                    End If
            End Select
        End If
    End Sub

    Private Sub GridPAC_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridPAC.CellEdited
        Select Case GridPAC.CurrentColumn.Caption.Replace(" ", "")
            Case "CustomerKey"
                If (GridPAC.GetValue("CustomerKey").GetType.Name = "DBNull" OrElse CStr(GridPAC.GetValue("CustomerKey")).Length = 0) Then
                    GridPAC.SetValue("CustomerKey", "Error")
                End If


            Case "Serv.Timbrado"
                If (GridPAC.GetValue("Serv. Timbrado").GetType.Name = "DBNull" OrElse CStr(GridPAC.GetValue("Serv. Timbrado")).Length = 0) Then
                    GridPAC.SetValue("Serv. Timbrado", "Error")
                End If

            Case "Serv.Cancelación"
                If (GridPAC.GetValue("Serv. Cancelación").GetType.Name = "DBNull" OrElse CStr(GridPAC.GetValue("Serv. Cancelación")).Length = 0) Then
                    GridPAC.SetValue("Serv. Cancelación", "Error")
                End If

            Case "UserId"
                If (GridPAC.GetValue("TipoPAC") = 2 OrElse GridPAC.GetValue("TipoPAC") = 3) AndAlso (GridPAC.GetValue("UserId").GetType.Name = "DBNull" OrElse CStr(GridPAC.GetValue("UserId")).Length = 0) Then
                    GridPAC.SetValue("UserId", "Error")
                ElseIf GridPAC.GetValue("TipoPAC") = 1 Then
                    GridPAC.SetValue("UserId", "")
                End If


            Case "Orden"
                If Not (IsNumeric(GridPAC.GetValue("Orden")) AndAlso CDbl(GridPAC.GetValue("Orden")) > 0) Then
                    GridPAC.SetValue("Orden", 1)
                End If


            Case "Timbres"
                If Not (IsNumeric(GridPAC.GetValue("Timbres")) AndAlso CDbl(GridPAC.GetValue("Timbres")) > 0) Then
                    GridPAC.SetValue("Timbres", 1)
                End If

            Case "RFC"
                If (GridPAC.GetValue("RFC").GetType.Name = "DBNull" OrElse CStr(GridPAC.GetValue("RFC")).Length < 0) Then
                    GridPAC.SetValue("RFC", "Error")
                End If

        End Select

        ActualizaPAC = True

    End Sub

    Private Sub BtnExploraImg_Click(sender As Object, e As EventArgs) Handles BtnExploraImg.Click
        Dim a As New System.Windows.Forms.FolderBrowserDialog
        If (a.ShowDialog() = DialogResult.OK) Then
            TxtImagenUrl.Text = a.SelectedPath
        End If
    End Sub

    Private Sub btnImagenes_Click(sender As Object, e As EventArgs) Handles btnImagenes.Click
        If TxtImagenUrl.Text = "" Then
            MessageBox.Show("Debe definir directorio para almacenar las imagenes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim a As New System.Windows.Forms.FolderBrowserDialog
        If (a.ShowDialog() = DialogResult.OK) Then
            Dim Path As String = a.SelectedPath

            Dim Lista As String()

            Lista = System.IO.Directory.GetFiles(Path, "*.jpg")

            If Not Path.Substring(Path.Length - 1, 1) = "\" Then
                Path &= "\"
            End If

            If Lista.Length > 0 Then

                Dim total As Integer = Lista.Length
                Dim i As Integer
                Dim Directorio, fname, sClave, sPROClave, sIMGClave, sModelo, sColor As String
                Dim dtProducto As DataTable
                Dim iProcesados As Integer = 0
               
                Directorio = TxtImagenUrl.Text
                If Not Directorio.Substring(Directorio.Length - 1, 1) = "\" Then
                    Directorio &= "\"
                End If

                Dim frmStatusMessage As New frmStatus
                frmStatusMessage.BringToFront()

                For i = 0 To Lista.Length - 1
                    frmStatusMessage.Show("Procesando " & CStr(i + 1) & " de " & CStr(total) & "imagenes")

                    fname = System.IO.Path.GetFileName(Lista(i))
                    sClave = fname.Split(".")(0)

                    If ChkTallaColor.GetEstado = 1 Then
                        If sClave.Split(" ").Length = 2 Then
                            sModelo = sClave.Split(" ")(0)
                            sColor = sClave.Split(" ")(1)

                            If IsNumeric(sColor) = True Then

                                dtProducto = ModPOS.SiExisteRecupera("st_recuperar_tallas", "@COMClave", Me.COMClave, "@Modelo", sModelo, "@Color", CDbl(sColor))
                                If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0 Then

                                    Dim j As Integer
                                    sIMGClave = ModPOS.obtenerLlave
                                    My.Computer.FileSystem.MoveFile(Lista(i), Directorio & sIMGClave & ".jpg", True)
                                  
                                    For j = 0 To dtProducto.Rows.Count - 1
                                        sPROClave = dtProducto.Rows(j)("PROClave")

                                        Try

                                            ModPOS.Ejecuta("sp_inserta_imagen", "@PROClave", sPROClave, "@IMGClave", sIMGClave, "@Imagen", sIMGClave & ".jpg", "@Usuario", ModPOS.UsuarioActual, "@TallaColor", ChkTallaColor.GetEstado)
                                        Catch ex As Exception
                                            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                                        End Try
                                    Next
                                    dtProducto.Dispose()
                                    iProcesados += 1
                                End If
                            End If
                        Else
                            Dim dtModelo As DataTable = ModPOS.Recupera_Tabla("st_valida_modelo", "@COMClave", ModPOS.CompanyActual, "@Modelo", sClave)
                            If dtModelo.Rows.Count = 1 Then
                                Dim j As Integer
                                sIMGClave = ModPOS.obtenerLlave
                                My.Computer.FileSystem.MoveFile(Lista(i), Directorio & sIMGClave & ".jpg", True)

                                For j = 0 To dtModelo.Rows.Count - 1
                                    sPROClave = dtModelo.Rows(j)("PROClave")

                                    Try

                                        ModPOS.Ejecuta("sp_inserta_imagen", "@PROClave", sPROClave, "@IMGClave", sIMGClave, "@Imagen", sIMGClave & ".jpg", "@Usuario", ModPOS.UsuarioActual, "@TallaColor", ChkTallaColor.GetEstado)
                                    Catch ex As Exception
                                        MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                                    End Try
                                Next
                                dtModelo.Dispose()
                                iProcesados += 1
                            End If
                        End If
                    Else
                        dtProducto = ModPOS.SiExisteRecupera("sp_compra_producto", "@COMClave", Me.COMClave, "@Clave", sClave, "@Char", cReplace)
                        If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0 Then
                            sPROClave = dtProducto.Rows(0)("PROClave")
                            dtProducto.Dispose()
                            sIMGClave = ModPOS.obtenerLlave
                            'Copia la imagen del archivo
                            Try
                                'Renombra el archivo
                                '  My.Computer.FileSystem.RenameFile(Lista(i), Path & sIMGClave & ".jpg")
                                My.Computer.FileSystem.MoveFile(Lista(i), Directorio & sIMGClave & ".jpg", True)
                                ModPOS.Ejecuta("sp_inserta_imagen", "@PROClave", sPROClave, "@IMGClave", sIMGClave, "@Imagen", sIMGClave & ".jpg", "@Usuario", ModPOS.UsuarioActual, "@TallaColor", ChkTallaColor.GetEstado)
                                iProcesados += 1
                            Catch ex As Exception
                                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                            End Try
                        End If
                    End If
                Next

                frmStatusMessage.Dispose()

                If iProcesados = 0 Then
                    MessageBox.Show("No fue posible procesar imagenes debido a que el nombre de las imagenes no coincide con la clave de algun producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Se procesaron exitosamente " & CStr(iProcesados) & " imagenes", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Else
                MessageBox.Show("No se encontraron archivos de Imagen (JPG) en el directorio seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        End If
    End Sub

    Private Sub btnDelClase_Click(sender As Object, e As EventArgs) Handles btnDelClase.Click
        If sRiesgoSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la clase de riesgo :" & sClave, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtClase.Select(" IdRiesgo = '" & sRiesgoSelected & "'")
                    foundRows(0)("Baja") = 1

            End Select
        End If
    End Sub

    Private Sub btnAddClase_Click(sender As Object, e As EventArgs) Handles btnAddClase.Click
        Dim a As New FrmRiesgo
        a.COMClave = COMClave
        a.ShowDialog()
    End Sub

    Private Sub GridClases_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridClases.CellEdited
        Select Case GridClases.CurrentColumn.Caption
            Case "Descripción"

                If GridClases.GetValue("Descripción").GetType.Name = "DBNull" OrElse CStr(GridClases.GetValue("Descripción")).Length = 0 Then
                    GridClases.SetValue("Descripción", "ERROR")
                    GridClases.SetValue("Modificado", 0)
                Else
                    GridClases.SetValue("Descripción", CStr(GridClases.GetValue("Descripción")).Trim)
                    GridClases.SetValue("Modificado", 1)
                End If

            Case "ValorPedido"

                If Not IsNumeric(GridClases.GetValue("ValorPedido")) Then
                    GridClases.SetValue("Modificado", 0)
                Else

                    If CDbl(GridClases.GetValue("ValorPedido")) < -1 Then
                        MessageBox.Show("¡El valor del pedido debe ser mayor o igual a -1!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridClases.SetValue("ValorPedido", 0)
                        GridClases.SetValue("Modificado", 0)
                    Else
                        GridClases.SetValue("Modificado", 1)
                    End If
                End If

            Case "Porc.Vencido"

                If Not IsNumeric(GridClases.GetValue("Porc.Vencido")) Then
                    GridClases.SetValue("Modificado", 0)
                Else

                    If CDbl(GridClases.GetValue("Porc.Vencido")) < -1 OrElse CDbl(GridClases.GetValue("Porc.Vencido")) > 100 Then
                        MessageBox.Show("¡El valor del porcentaje no es valido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridClases.SetValue("Porc.Vencido", 0)
                        GridClases.SetValue("Modificado", 0)
                    Else
                        GridClases.SetValue("Modificado", 1)
                    End If
                End If

            Case "Antiguedad"

                If Not IsNumeric(GridClases.GetValue("Antiguedad")) Then
                    GridClases.SetValue("Modificado", 0)
                Else

                    If CDbl(GridClases.GetValue("Antiguedad")) < -1 Then
                        MessageBox.Show("¡El valor debe ser mayor o igual a -1!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridClases.SetValue("Antiguedad", 0)
                        GridClases.SetValue("Modificado", 0)
                    Else
                        GridClases.SetValue("Modificado", 1)
                    End If
                End If

            Case "Dias Credito Preventa"

                If Not IsNumeric(GridClases.GetValue("DiasCreditoPreventa")) Then
                    GridClases.SetValue("Modificado", 0)
                Else

                    If CDbl(GridClases.GetValue("DiasCreditoPreventa")) < -1 Then
                        MessageBox.Show("¡El valor debe ser mayor o igual a -1!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridClases.SetValue("DiasCreditoPreventa", 0)
                        GridClases.SetValue("Modificado", 0)
                    Else
                        GridClases.SetValue("Modificado", 1)
                    End If
                End If


            Case "Limite Credito Preventa"

                If Not IsNumeric(GridClases.GetValue("LimiteCreditoPreventa")) Then
                    GridClases.SetValue("Modificado", 0)
                Else

                    If CDbl(GridClases.GetValue("LimiteCreditoPreventa")) < -1 Then
                        MessageBox.Show("¡El valor debe ser mayor o igual a -1!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridClases.SetValue("LimiteCreditoPreventa", 0)
                        GridClases.SetValue("Modificado", 0)
                    Else
                        GridClases.SetValue("Modificado", 1)
                    End If
                End If

        End Select

    End Sub

    Private Sub GridClases_SelectionChanged(sender As Object, e As EventArgs) Handles GridClases.SelectionChanged
        If Not GridClases.GetValue(0) Is Nothing Then
            Me.btnDelClase.Enabled = True
            Me.sRiesgoSelected = GridClases.GetValue("IdRiesgo")
            Me.sClave = GridClases.GetValue("Clave")
        Else
            Me.btnDelClase.Enabled = False
            Me.sRiesgoSelected = ""
            Me.sClave = ""
        End If
    End Sub

    Private Sub btnInterfaz_Click(sender As Object, e As EventArgs) Handles btnInterfaz.Click
        Dim a As New System.Windows.Forms.FolderBrowserDialog
        If (a.ShowDialog() = DialogResult.OK) Then
            txtInterfaz.Text = a.SelectedPath
        End If
    End Sub

    Private Sub btnVersion_Click(sender As Object, e As EventArgs) Handles btnVersion.Click
        Dim a As New System.Windows.Forms.FolderBrowserDialog
        If (a.ShowDialog() = DialogResult.OK) Then
            txtVersion.Text = a.SelectedPath
        End If
    End Sub


    Private Sub CmbTipoPersona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoPersona.SelectedIndexChanged
        If cargado = True AndAlso CmbTipoPersona.SelectedIndex = 1 Then
            TxtRFC.Mask = "&&&000000&&&" 'Persona Moral
        Else
            TxtRFC.Mask = "&&&&000000&&&" 'Persona Fisica
        End If
    End Sub




    Private Sub PictIcono2_DoubleClick(sender As Object, e As EventArgs) Handles PictIcono2.DoubleClick
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
                ReDim Icono2(lung)
                fsIcono.Read(Icono2, 0, lung)
                fsIcono.Close()

                Me.PictIcono2.Image = Image.FromFile(curFileName)



            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

  
    Private Sub btnEntrada_Click(sender As Object, e As EventArgs) Handles btnEntrada.Click
        Dim a As New System.Windows.Forms.FolderBrowserDialog
        If (a.ShowDialog() = DialogResult.OK) Then
            txtEntrada.Text = a.SelectedPath
        End If
    End Sub
End Class
