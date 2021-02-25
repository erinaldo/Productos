Imports System.Net
Imports System.Net.Mail

Public Class FrmCliente
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
    Friend WithEvents UiTabGestion As Janus.Windows.UI.Tab.UITab
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiTabCliente As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabDomicilio As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabSaldos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpDomicilio As System.Windows.Forms.GroupBox
    Friend WithEvents ChkDomicilio As Selling.ChkStatus
    Friend WithEvents cmbPais As Selling.StoreCombo
    Friend WithEvents BtnAceptarDomi As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpDomicilios As System.Windows.Forms.GroupBox
    Friend WithEvents GridDomicilios As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpSaldos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDelDomi As Janus.Windows.EditControls.UIButton
    Friend WithEvents NumDisponible As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents NumSaldo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents LblColonia As System.Windows.Forms.Label
    Friend WithEvents LblMnpio As System.Windows.Forms.Label
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents LblPais As System.Windows.Forms.Label
    Friend WithEvents LblSaldo As System.Windows.Forms.Label
    Friend WithEvents LblCredito As System.Windows.Forms.Label
    Friend WithEvents TxtCalle As System.Windows.Forms.TextBox
    Friend WithEvents LblCalle As System.Windows.Forms.Label
    Friend WithEvents GridSaldos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDiasCredito As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbListaPrecio As Selling.StoreCombo
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
    Friend WithEvents LblTPersona As System.Windows.Forms.Label
    Friend WithEvents TxtNombreCorto As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents CmbTipoPersona As Selling.StoreCombo
    Friend WithEvents GrpDomicilioFiscal As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtDomicilioFac As System.Windows.Forms.TextBox
    Friend WithEvents CmbPaisFac As Selling.StoreCombo
    Friend WithEvents GrpContacto As System.Windows.Forms.GroupBox
    Friend WithEvents LblEmail As System.Windows.Forms.Label
    Friend WithEvents LblTel2 As System.Windows.Forms.Label
    Friend WithEvents LblTel1 As System.Windows.Forms.Label
    Friend WithEvents TxtTel2 As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents TxtContacto As System.Windows.Forms.TextBox
    Friend WithEvents LblContacto As System.Windows.Forms.Label
    Friend WithEvents TxtMail As System.Windows.Forms.TextBox
    Friend WithEvents ChkDesglosarIVA As System.Windows.Forms.CheckBox
    Friend WithEvents cmbResponsable As Selling.StoreCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmbTipo As Selling.StoreCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtLocalidadFac As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoPostalFac As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtNoInteriorFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtNoExteriorFac As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtReferenciaFac As System.Windows.Forms.TextBox
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
    Friend WithEvents TxtCURP As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TxtEstadoFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtColoniaFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtMunicipioFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtGLN As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents UiTabMetodo As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpMetodos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridMetodos As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnElimina As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModifica As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtColonia As System.Windows.Forms.TextBox
    Friend WithEvents TxtMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents TxtEstado As System.Windows.Forms.TextBox
    Friend WithEvents UiTabClasificaciones As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpClasificaciones As System.Windows.Forms.GroupBox
    Friend WithEvents BtnBuscaClasificacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtClasificacion As System.Windows.Forms.TextBox
    Friend WithEvents LblReferencia As System.Windows.Forms.Label
    Friend WithEvents btnDelClasificacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridClasificaciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents TxtCtaContable As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtAlterno As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoCanal As Selling.StoreCombo
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbRamo As Selling.StoreCombo
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cmbZonaReparto As Selling.StoreCombo
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cmbZonaVenta As Selling.StoreCombo
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cmbZonaRep As Selling.StoreCombo
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cmbZonaVtap As Selling.StoreCombo
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtTelDomicilio As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents TxtConsignatario As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox15 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox17 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox25 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox24 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox23 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox22 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox21 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox20 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox19 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox18 As System.Windows.Forms.PictureBox
    Friend WithEvents GrpDescuentos As System.Windows.Forms.GroupBox
    Friend WithEvents cmbPostVenta As Selling.StoreCombo
    Friend WithEvents PictureBox27 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbDirecto As Selling.StoreCombo
    Friend WithEvents PictureBox26 As System.Windows.Forms.PictureBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents btnPostventa As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDirecto As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cmbVendedor As Selling.StoreCombo
    Friend WithEvents UiTabCredito As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpClase As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddClase As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridClases As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnDelClase As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtClavePE As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents PictureBox28 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox29 As System.Windows.Forms.PictureBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents cmbOrigen As Selling.StoreCombo
    Friend WithEvents PictureBox30 As System.Windows.Forms.PictureBox
    Friend WithEvents lblRegFiscal As System.Windows.Forms.Label
    Friend WithEvents TxtRegFiscal As System.Windows.Forms.TextBox
    Friend WithEvents chkImpresion As System.Windows.Forms.CheckBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cmbUsoCFDI As Selling.StoreCombo
    Friend WithEvents chkFacturable As System.Windows.Forms.CheckBox
    Friend WithEvents grpAccesoWeb As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox31 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox32 As System.Windows.Forms.PictureBox
    Friend WithEvents ChkAccesoWeb As Selling.ChkStatus
    Friend WithEvents TxtConfirmar As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents TxtContraseña As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents lblCtaMaestra As System.Windows.Forms.Label
    Friend WithEvents txtCtaMaestra As System.Windows.Forms.TextBox
    Friend WithEvents btnCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox33 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbTipoImpuesto As Selling.StoreCombo
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents PictureBox34 As System.Windows.Forms.PictureBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtSAP As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipoTel1 As Selling.StoreCombo
    Friend WithEvents cmbTipoTel2 As Selling.StoreCombo
    Friend WithEvents cmbGenero As Selling.StoreCombo
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents cmbFechaNacimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox37 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox36 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox35 As System.Windows.Forms.PictureBox
    Friend WithEvents UiTabCanal As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents grpCanales As System.Windows.Forms.GroupBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents gridCanales As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbListaPrecio2 As Selling.StoreCombo
    Friend WithEvents cmbTipoCanal2 As Selling.StoreCombo
    Friend WithEvents btnAddCanal As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDelCanal As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtTel1 As Janus.Windows.GridEX.EditControls.MaskedEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCliente))
        Me.UiTabGestion = New Janus.Windows.UI.Tab.UITab()
        Me.UiTabCliente = New Janus.Windows.UI.Tab.UITabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grpAccesoWeb = New System.Windows.Forms.GroupBox()
        Me.PictureBox31 = New System.Windows.Forms.PictureBox()
        Me.PictureBox32 = New System.Windows.Forms.PictureBox()
        Me.TxtConfirmar = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.TxtContraseña = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.ChkAccesoWeb = New Selling.ChkStatus(Me.components)
        Me.GrpDescuentos = New System.Windows.Forms.GroupBox()
        Me.btnPostventa = New Janus.Windows.EditControls.UIButton()
        Me.btnDirecto = New Janus.Windows.EditControls.UIButton()
        Me.cmbPostVenta = New Selling.StoreCombo()
        Me.PictureBox27 = New System.Windows.Forms.PictureBox()
        Me.cmbDirecto = New Selling.StoreCombo()
        Me.PictureBox26 = New System.Windows.Forms.PictureBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.GrpDomicilioFiscal = New System.Windows.Forms.GroupBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.cmbUsoCFDI = New Selling.StoreCombo()
        Me.cmbVendedor = New Selling.StoreCombo()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.PictureBox17 = New System.Windows.Forms.PictureBox()
        Me.PictureBox16 = New System.Windows.Forms.PictureBox()
        Me.PictureBox15 = New System.Windows.Forms.PictureBox()
        Me.PictureBox14 = New System.Windows.Forms.PictureBox()
        Me.PictureBox13 = New System.Windows.Forms.PictureBox()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cmbZonaReparto = New Selling.StoreCombo()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cmbZonaVenta = New Selling.StoreCombo()
        Me.TxtColoniaFac = New System.Windows.Forms.TextBox()
        Me.TxtMunicipioFac = New System.Windows.Forms.TextBox()
        Me.TxtEstadoFac = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtReferenciaFac = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtNoInteriorFac = New System.Windows.Forms.TextBox()
        Me.TxtNoExteriorFac = New System.Windows.Forms.TextBox()
        Me.TxtCodigoPostalFac = New System.Windows.Forms.TextBox()
        Me.TxtLocalidadFac = New System.Windows.Forms.TextBox()
        Me.TxtDomicilioFac = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmbPaisFac = New Selling.StoreCombo()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GrpCliente = New System.Windows.Forms.GroupBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtSAP = New System.Windows.Forms.TextBox()
        Me.btnCliente = New Janus.Windows.EditControls.UIButton()
        Me.lblCtaMaestra = New System.Windows.Forms.Label()
        Me.txtCtaMaestra = New System.Windows.Forms.TextBox()
        Me.chkFacturable = New System.Windows.Forms.CheckBox()
        Me.chkImpresion = New System.Windows.Forms.CheckBox()
        Me.PictureBox30 = New System.Windows.Forms.PictureBox()
        Me.TxtRegFiscal = New System.Windows.Forms.TextBox()
        Me.PictureBox29 = New System.Windows.Forms.PictureBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.cmbOrigen = New Selling.StoreCombo()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbRamo = New Selling.StoreCombo()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtAlterno = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmbTipoCanal = New Selling.StoreCombo()
        Me.TxtCtaContable = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtGLN = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TxtCURP = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.CmbTipo = New Selling.StoreCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbResponsable = New Selling.StoreCombo()
        Me.ChkDesglosarIVA = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtDiasCredito = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbListaPrecio = New Selling.StoreCombo()
        Me.lblLimite = New System.Windows.Forms.Label()
        Me.TxtLimite = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.TxtRFC = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnKey = New Janus.Windows.EditControls.UIButton()
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.TxtFechaRegistro = New System.Windows.Forms.TextBox()
        Me.lblFechaReg = New System.Windows.Forms.Label()
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblTPersona = New System.Windows.Forms.Label()
        Me.TxtNombreCorto = New System.Windows.Forms.TextBox()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.CmbTipoPersona = New Selling.StoreCombo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblRegFiscal = New System.Windows.Forms.Label()
        Me.GrpContacto = New System.Windows.Forms.GroupBox()
        Me.PictureBox37 = New System.Windows.Forms.PictureBox()
        Me.PictureBox36 = New System.Windows.Forms.PictureBox()
        Me.PictureBox35 = New System.Windows.Forms.PictureBox()
        Me.cmbFechaNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.cmbGenero = New Selling.StoreCombo()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.cmbTipoTel1 = New Selling.StoreCombo()
        Me.cmbTipoTel2 = New Selling.StoreCombo()
        Me.PictureBox34 = New System.Windows.Forms.PictureBox()
        Me.LblEmail = New System.Windows.Forms.Label()
        Me.LblTel2 = New System.Windows.Forms.Label()
        Me.LblTel1 = New System.Windows.Forms.Label()
        Me.TxtTel2 = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.TxtContacto = New System.Windows.Forms.TextBox()
        Me.LblContacto = New System.Windows.Forms.Label()
        Me.TxtMail = New System.Windows.Forms.TextBox()
        Me.TxtTel1 = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.UiTabCanal = New Janus.Windows.UI.Tab.UITabPage()
        Me.grpCanales = New System.Windows.Forms.GroupBox()
        Me.btnAddCanal = New Janus.Windows.EditControls.UIButton()
        Me.btnDelCanal = New Janus.Windows.EditControls.UIButton()
        Me.cmbListaPrecio2 = New Selling.StoreCombo()
        Me.cmbTipoCanal2 = New Selling.StoreCombo()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.gridCanales = New Janus.Windows.GridEX.GridEX()
        Me.UiTabDomicilio = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpDomicilio = New System.Windows.Forms.GroupBox()
        Me.PictureBox33 = New System.Windows.Forms.PictureBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.PictureBox28 = New System.Windows.Forms.PictureBox()
        Me.TxtClavePE = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.PictureBox25 = New System.Windows.Forms.PictureBox()
        Me.PictureBox24 = New System.Windows.Forms.PictureBox()
        Me.PictureBox23 = New System.Windows.Forms.PictureBox()
        Me.PictureBox22 = New System.Windows.Forms.PictureBox()
        Me.PictureBox21 = New System.Windows.Forms.PictureBox()
        Me.PictureBox20 = New System.Windows.Forms.PictureBox()
        Me.PictureBox19 = New System.Windows.Forms.PictureBox()
        Me.PictureBox18 = New System.Windows.Forms.PictureBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtTelDomicilio = New Janus.Windows.GridEX.EditControls.MaskedEditBox()
        Me.TxtConsignatario = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TxtColonia = New System.Windows.Forms.TextBox()
        Me.TxtMunicipio = New System.Windows.Forms.TextBox()
        Me.TxtEstado = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtNoInterior = New System.Windows.Forms.TextBox()
        Me.TxtNoExterior = New System.Windows.Forms.TextBox()
        Me.TxtCodigoPostal = New System.Windows.Forms.TextBox()
        Me.TxtLocalidad = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtCalle = New System.Windows.Forms.TextBox()
        Me.LblCalle = New System.Windows.Forms.Label()
        Me.BtnDelDomi = New Janus.Windows.EditControls.UIButton()
        Me.LblColonia = New System.Windows.Forms.Label()
        Me.LblMnpio = New System.Windows.Forms.Label()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.LblPais = New System.Windows.Forms.Label()
        Me.BtnAceptarDomi = New Janus.Windows.EditControls.UIButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbTipoImpuesto = New Selling.StoreCombo()
        Me.cmbZonaRep = New Selling.StoreCombo()
        Me.cmbZonaVtap = New Selling.StoreCombo()
        Me.ChkDomicilio = New Selling.ChkStatus(Me.components)
        Me.cmbPais = New Selling.StoreCombo()
        Me.GrpDomicilios = New System.Windows.Forms.GroupBox()
        Me.GridDomicilios = New Janus.Windows.GridEX.GridEX()
        Me.UiTabSaldos = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpSaldos = New System.Windows.Forms.GroupBox()
        Me.LblSaldo = New System.Windows.Forms.Label()
        Me.NumSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.LblCredito = New System.Windows.Forms.Label()
        Me.NumDisponible = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.GridSaldos = New Janus.Windows.GridEX.GridEX()
        Me.UiTabMetodo = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpMetodos = New System.Windows.Forms.GroupBox()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GridMetodos = New Janus.Windows.GridEX.GridEX()
        Me.BtnElimina = New Janus.Windows.EditControls.UIButton()
        Me.BtnModifica = New Janus.Windows.EditControls.UIButton()
        Me.UiTabClasificaciones = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpClasificaciones = New System.Windows.Forms.GroupBox()
        Me.BtnBuscaClasificacion = New Janus.Windows.EditControls.UIButton()
        Me.TxtClasificacion = New System.Windows.Forms.TextBox()
        Me.LblReferencia = New System.Windows.Forms.Label()
        Me.btnDelClasificacion = New Janus.Windows.EditControls.UIButton()
        Me.GridClasificaciones = New Janus.Windows.GridEX.GridEX()
        Me.UiTabCredito = New Janus.Windows.UI.Tab.UITabPage()
        Me.GrpClase = New System.Windows.Forms.GroupBox()
        Me.btnAddClase = New Janus.Windows.EditControls.UIButton()
        Me.GridClases = New Janus.Windows.GridEX.GridEX()
        Me.btnDelClase = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        CType(Me.UiTabGestion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabGestion.SuspendLayout()
        Me.UiTabCliente.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpAccesoWeb.SuspendLayout()
        CType(Me.PictureBox31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox32, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDescuentos.SuspendLayout()
        CType(Me.PictureBox27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox26, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDomicilioFiscal.SuspendLayout()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCliente.SuspendLayout()
        CType(Me.PictureBox30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox29, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GrpContacto.SuspendLayout()
        CType(Me.PictureBox37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox34, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabCanal.SuspendLayout()
        Me.grpCanales.SuspendLayout()
        CType(Me.gridCanales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabDomicilio.SuspendLayout()
        Me.GrpDomicilio.SuspendLayout()
        CType(Me.PictureBox33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDomicilios.SuspendLayout()
        CType(Me.GridDomicilios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabSaldos.SuspendLayout()
        Me.GrpSaldos.SuspendLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabMetodo.SuspendLayout()
        Me.GrpMetodos.SuspendLayout()
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabClasificaciones.SuspendLayout()
        Me.GrpClasificaciones.SuspendLayout()
        CType(Me.GridClasificaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabCredito.SuspendLayout()
        Me.GrpClase.SuspendLayout()
        CType(Me.GridClases, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiTabGestion
        '
        Me.UiTabGestion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabGestion.FlatBorderColor = System.Drawing.Color.LightSteelBlue
        Me.UiTabGestion.Location = New System.Drawing.Point(1, 12)
        Me.UiTabGestion.Name = "UiTabGestion"
        Me.UiTabGestion.Size = New System.Drawing.Size(773, 504)
        Me.UiTabGestion.TabIndex = 0
        Me.UiTabGestion.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabCliente, Me.UiTabCanal, Me.UiTabDomicilio, Me.UiTabSaldos, Me.UiTabMetodo, Me.UiTabClasificaciones, Me.UiTabCredito})
        Me.UiTabGestion.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabCliente
        '
        Me.UiTabCliente.Controls.Add(Me.Panel1)
        Me.UiTabCliente.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCliente.Name = "UiTabCliente"
        Me.UiTabCliente.Size = New System.Drawing.Size(771, 482)
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
        Me.Panel1.Controls.Add(Me.grpAccesoWeb)
        Me.Panel1.Controls.Add(Me.GrpDescuentos)
        Me.Panel1.Controls.Add(Me.GrpDomicilioFiscal)
        Me.Panel1.Controls.Add(Me.GrpCliente)
        Me.Panel1.Controls.Add(Me.GrpContacto)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(772, 480)
        Me.Panel1.TabIndex = 1
        '
        'grpAccesoWeb
        '
        Me.grpAccesoWeb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAccesoWeb.BackColor = System.Drawing.Color.Transparent
        Me.grpAccesoWeb.Controls.Add(Me.PictureBox31)
        Me.grpAccesoWeb.Controls.Add(Me.PictureBox32)
        Me.grpAccesoWeb.Controls.Add(Me.TxtConfirmar)
        Me.grpAccesoWeb.Controls.Add(Me.Label40)
        Me.grpAccesoWeb.Controls.Add(Me.TxtContraseña)
        Me.grpAccesoWeb.Controls.Add(Me.Label41)
        Me.grpAccesoWeb.Controls.Add(Me.ChkAccesoWeb)
        Me.grpAccesoWeb.Location = New System.Drawing.Point(15, 881)
        Me.grpAccesoWeb.Name = "grpAccesoWeb"
        Me.grpAccesoWeb.Size = New System.Drawing.Size(725, 72)
        Me.grpAccesoWeb.TabIndex = 6
        Me.grpAccesoWeb.TabStop = False
        Me.grpAccesoWeb.Text = "Acceso Touch y Web"
        '
        'PictureBox31
        '
        Me.PictureBox31.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox31.Image = CType(resources.GetObject("PictureBox31.Image"), System.Drawing.Image)
        Me.PictureBox31.Location = New System.Drawing.Point(254, 41)
        Me.PictureBox31.Name = "PictureBox31"
        Me.PictureBox31.Size = New System.Drawing.Size(22, 18)
        Me.PictureBox31.TabIndex = 94
        Me.PictureBox31.TabStop = False
        Me.PictureBox31.Visible = False
        '
        'PictureBox32
        '
        Me.PictureBox32.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox32.Image = CType(resources.GetObject("PictureBox32.Image"), System.Drawing.Image)
        Me.PictureBox32.Location = New System.Drawing.Point(433, 41)
        Me.PictureBox32.Name = "PictureBox32"
        Me.PictureBox32.Size = New System.Drawing.Size(22, 18)
        Me.PictureBox32.TabIndex = 92
        Me.PictureBox32.TabStop = False
        Me.PictureBox32.Visible = False
        '
        'TxtConfirmar
        '
        Me.TxtConfirmar.Location = New System.Drawing.Point(320, 41)
        Me.TxtConfirmar.Name = "TxtConfirmar"
        Me.TxtConfirmar.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtConfirmar.Size = New System.Drawing.Size(95, 20)
        Me.TxtConfirmar.TabIndex = 97
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(257, 44)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(67, 15)
        Me.Label40.TabIndex = 99
        Me.Label40.Text = "Confirmar"
        '
        'TxtContraseña
        '
        Me.TxtContraseña.Location = New System.Drawing.Point(141, 41)
        Me.TxtContraseña.Name = "TxtContraseña"
        Me.TxtContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtContraseña.Size = New System.Drawing.Size(95, 20)
        Me.TxtContraseña.TabIndex = 96
        '
        'Label41
        '
        Me.Label41.Location = New System.Drawing.Point(9, 44)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(106, 15)
        Me.Label41.TabIndex = 98
        Me.Label41.Text = "PIN (4 DIGITOS)"
        '
        'ChkAccesoWeb
        '
        Me.ChkAccesoWeb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkAccesoWeb.Checked = True
        Me.ChkAccesoWeb.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAccesoWeb.Location = New System.Drawing.Point(9, 19)
        Me.ChkAccesoWeb.Name = "ChkAccesoWeb"
        Me.ChkAccesoWeb.Size = New System.Drawing.Size(87, 22)
        Me.ChkAccesoWeb.TabIndex = 95
        Me.ChkAccesoWeb.Text = "Acceso"
        '
        'GrpDescuentos
        '
        Me.GrpDescuentos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDescuentos.BackColor = System.Drawing.Color.Transparent
        Me.GrpDescuentos.Controls.Add(Me.btnPostventa)
        Me.GrpDescuentos.Controls.Add(Me.btnDirecto)
        Me.GrpDescuentos.Controls.Add(Me.cmbPostVenta)
        Me.GrpDescuentos.Controls.Add(Me.PictureBox27)
        Me.GrpDescuentos.Controls.Add(Me.cmbDirecto)
        Me.GrpDescuentos.Controls.Add(Me.PictureBox26)
        Me.GrpDescuentos.Controls.Add(Me.Label34)
        Me.GrpDescuentos.Controls.Add(Me.Label36)
        Me.GrpDescuentos.Location = New System.Drawing.Point(15, 780)
        Me.GrpDescuentos.Name = "GrpDescuentos"
        Me.GrpDescuentos.Size = New System.Drawing.Size(725, 93)
        Me.GrpDescuentos.TabIndex = 5
        Me.GrpDescuentos.TabStop = False
        Me.GrpDescuentos.Text = "Descuentos"
        '
        'btnPostventa
        '
        Me.btnPostventa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPostventa.Location = New System.Drawing.Point(412, 58)
        Me.btnPostventa.Name = "btnPostventa"
        Me.btnPostventa.Size = New System.Drawing.Size(119, 21)
        Me.btnPostventa.TabIndex = 98
        Me.btnPostventa.Text = "&Excepción ..."
        Me.btnPostventa.ToolTipText = "Agregar Excepción de descuento postventa por sector de material"
        Me.btnPostventa.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnDirecto
        '
        Me.btnDirecto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDirecto.Location = New System.Drawing.Point(412, 24)
        Me.btnDirecto.Name = "btnDirecto"
        Me.btnDirecto.Size = New System.Drawing.Size(119, 21)
        Me.btnDirecto.TabIndex = 97
        Me.btnDirecto.Text = "&Excepción ..."
        Me.btnDirecto.ToolTipText = "Agregar Excepción de descuento directo por sector de material"
        Me.btnDirecto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbPostVenta
        '
        Me.cmbPostVenta.Location = New System.Drawing.Point(141, 59)
        Me.cmbPostVenta.Name = "cmbPostVenta"
        Me.cmbPostVenta.Size = New System.Drawing.Size(241, 21)
        Me.cmbPostVenta.TabIndex = 95
        '
        'PictureBox27
        '
        Me.PictureBox27.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox27.Image = CType(resources.GetObject("PictureBox27.Image"), System.Drawing.Image)
        Me.PictureBox27.Location = New System.Drawing.Point(100, 61)
        Me.PictureBox27.Name = "PictureBox27"
        Me.PictureBox27.Size = New System.Drawing.Size(22, 18)
        Me.PictureBox27.TabIndex = 94
        Me.PictureBox27.TabStop = False
        Me.PictureBox27.Visible = False
        '
        'cmbDirecto
        '
        Me.cmbDirecto.Location = New System.Drawing.Point(141, 25)
        Me.cmbDirecto.Name = "cmbDirecto"
        Me.cmbDirecto.Size = New System.Drawing.Size(241, 21)
        Me.cmbDirecto.TabIndex = 93
        '
        'PictureBox26
        '
        Me.PictureBox26.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox26.Image = CType(resources.GetObject("PictureBox26.Image"), System.Drawing.Image)
        Me.PictureBox26.Location = New System.Drawing.Point(100, 28)
        Me.PictureBox26.Name = "PictureBox26"
        Me.PictureBox26.Size = New System.Drawing.Size(22, 18)
        Me.PictureBox26.TabIndex = 92
        Me.PictureBox26.TabStop = False
        Me.PictureBox26.Visible = False
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(11, 62)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(120, 15)
        Me.Label34.TabIndex = 63
        Me.Label34.Text = "Descuento PostVenta"
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(13, 28)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(100, 14)
        Me.Label36.TabIndex = 61
        Me.Label36.Text = "Descuento Directo"
        '
        'GrpDomicilioFiscal
        '
        Me.GrpDomicilioFiscal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDomicilioFiscal.BackColor = System.Drawing.Color.Transparent
        Me.GrpDomicilioFiscal.Controls.Add(Me.Label39)
        Me.GrpDomicilioFiscal.Controls.Add(Me.cmbUsoCFDI)
        Me.GrpDomicilioFiscal.Controls.Add(Me.cmbVendedor)
        Me.GrpDomicilioFiscal.Controls.Add(Me.Label35)
        Me.GrpDomicilioFiscal.Controls.Add(Me.PictureBox17)
        Me.GrpDomicilioFiscal.Controls.Add(Me.PictureBox16)
        Me.GrpDomicilioFiscal.Controls.Add(Me.PictureBox15)
        Me.GrpDomicilioFiscal.Controls.Add(Me.PictureBox14)
        Me.GrpDomicilioFiscal.Controls.Add(Me.PictureBox13)
        Me.GrpDomicilioFiscal.Controls.Add(Me.PictureBox12)
        Me.GrpDomicilioFiscal.Controls.Add(Me.PictureBox11)
        Me.GrpDomicilioFiscal.Controls.Add(Me.Label28)
        Me.GrpDomicilioFiscal.Controls.Add(Me.cmbZonaReparto)
        Me.GrpDomicilioFiscal.Controls.Add(Me.Label27)
        Me.GrpDomicilioFiscal.Controls.Add(Me.cmbZonaVenta)
        Me.GrpDomicilioFiscal.Controls.Add(Me.TxtColoniaFac)
        Me.GrpDomicilioFiscal.Controls.Add(Me.TxtMunicipioFac)
        Me.GrpDomicilioFiscal.Controls.Add(Me.TxtEstadoFac)
        Me.GrpDomicilioFiscal.Controls.Add(Me.Label15)
        Me.GrpDomicilioFiscal.Controls.Add(Me.TxtReferenciaFac)
        Me.GrpDomicilioFiscal.Controls.Add(Me.Label14)
        Me.GrpDomicilioFiscal.Controls.Add(Me.Label13)
        Me.GrpDomicilioFiscal.Controls.Add(Me.TxtNoInteriorFac)
        Me.GrpDomicilioFiscal.Controls.Add(Me.TxtNoExteriorFac)
        Me.GrpDomicilioFiscal.Controls.Add(Me.TxtCodigoPostalFac)
        Me.GrpDomicilioFiscal.Controls.Add(Me.TxtLocalidadFac)
        Me.GrpDomicilioFiscal.Controls.Add(Me.TxtDomicilioFac)
        Me.GrpDomicilioFiscal.Controls.Add(Me.Label3)
        Me.GrpDomicilioFiscal.Controls.Add(Me.Label5)
        Me.GrpDomicilioFiscal.Controls.Add(Me.Label6)
        Me.GrpDomicilioFiscal.Controls.Add(Me.Label7)
        Me.GrpDomicilioFiscal.Controls.Add(Me.CmbPaisFac)
        Me.GrpDomicilioFiscal.Controls.Add(Me.Label8)
        Me.GrpDomicilioFiscal.Controls.Add(Me.Label10)
        Me.GrpDomicilioFiscal.Controls.Add(Me.Label12)
        Me.GrpDomicilioFiscal.Location = New System.Drawing.Point(15, 371)
        Me.GrpDomicilioFiscal.MinimumSize = New System.Drawing.Size(725, 209)
        Me.GrpDomicilioFiscal.Name = "GrpDomicilioFiscal"
        Me.GrpDomicilioFiscal.Size = New System.Drawing.Size(725, 240)
        Me.GrpDomicilioFiscal.TabIndex = 4
        Me.GrpDomicilioFiscal.TabStop = False
        Me.GrpDomicilioFiscal.Text = "Domicilio Fiscal"
        '
        'Label39
        '
        Me.Label39.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label39.Location = New System.Drawing.Point(409, 211)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(77, 14)
        Me.Label39.TabIndex = 109
        Me.Label39.Text = "Uso del CFDI"
        '
        'cmbUsoCFDI
        '
        Me.cmbUsoCFDI.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbUsoCFDI.BackColor = System.Drawing.SystemColors.Window
        Me.cmbUsoCFDI.ItemHeight = 13
        Me.cmbUsoCFDI.Location = New System.Drawing.Point(496, 208)
        Me.cmbUsoCFDI.Name = "cmbUsoCFDI"
        Me.cmbUsoCFDI.Size = New System.Drawing.Size(223, 21)
        Me.cmbUsoCFDI.TabIndex = 108
        '
        'cmbVendedor
        '
        Me.cmbVendedor.Location = New System.Drawing.Point(121, 208)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(261, 21)
        Me.cmbVendedor.TabIndex = 102
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(13, 211)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(74, 15)
        Me.Label35.TabIndex = 101
        Me.Label35.Text = "Vendedor"
        '
        'PictureBox17
        '
        Me.PictureBox17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox17.Image = CType(resources.GetObject("PictureBox17.Image"), System.Drawing.Image)
        Me.PictureBox17.Location = New System.Drawing.Point(499, 101)
        Me.PictureBox17.Name = "PictureBox17"
        Me.PictureBox17.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox17.TabIndex = 99
        Me.PictureBox17.TabStop = False
        Me.PictureBox17.Visible = False
        '
        'PictureBox16
        '
        Me.PictureBox16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox16.Image = CType(resources.GetObject("PictureBox16.Image"), System.Drawing.Image)
        Me.PictureBox16.Location = New System.Drawing.Point(499, 72)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox16.TabIndex = 98
        Me.PictureBox16.TabStop = False
        Me.PictureBox16.Visible = False
        '
        'PictureBox15
        '
        Me.PictureBox15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox15.Image = CType(resources.GetObject("PictureBox15.Image"), System.Drawing.Image)
        Me.PictureBox15.Location = New System.Drawing.Point(81, 98)
        Me.PictureBox15.Name = "PictureBox15"
        Me.PictureBox15.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox15.TabIndex = 97
        Me.PictureBox15.TabStop = False
        Me.PictureBox15.Visible = False
        '
        'PictureBox14
        '
        Me.PictureBox14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox14.Image = CType(resources.GetObject("PictureBox14.Image"), System.Drawing.Image)
        Me.PictureBox14.Location = New System.Drawing.Point(80, 75)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox14.TabIndex = 96
        Me.PictureBox14.TabStop = False
        Me.PictureBox14.Visible = False
        '
        'PictureBox13
        '
        Me.PictureBox13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), System.Drawing.Image)
        Me.PictureBox13.Location = New System.Drawing.Point(80, 48)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox13.TabIndex = 95
        Me.PictureBox13.TabStop = False
        Me.PictureBox13.Visible = False
        '
        'PictureBox12
        '
        Me.PictureBox12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), System.Drawing.Image)
        Me.PictureBox12.Location = New System.Drawing.Point(499, 19)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox12.TabIndex = 94
        Me.PictureBox12.TabStop = False
        Me.PictureBox12.Visible = False
        '
        'PictureBox11
        '
        Me.PictureBox11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(80, 22)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(22, 18)
        Me.PictureBox11.TabIndex = 90
        Me.PictureBox11.TabStop = False
        Me.PictureBox11.Visible = False
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(13, 180)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(93, 15)
        Me.Label28.TabIndex = 89
        Me.Label28.Text = "Zona de Reparto"
        '
        'cmbZonaReparto
        '
        Me.cmbZonaReparto.BackColor = System.Drawing.SystemColors.Window
        Me.cmbZonaReparto.ItemHeight = 13
        Me.cmbZonaReparto.Location = New System.Drawing.Point(121, 177)
        Me.cmbZonaReparto.Name = "cmbZonaReparto"
        Me.cmbZonaReparto.Size = New System.Drawing.Size(412, 21)
        Me.cmbZonaReparto.TabIndex = 88
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(13, 153)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(93, 15)
        Me.Label27.TabIndex = 87
        Me.Label27.Text = "Zona de Venta"
        '
        'cmbZonaVenta
        '
        Me.cmbZonaVenta.BackColor = System.Drawing.SystemColors.Window
        Me.cmbZonaVenta.ItemHeight = 13
        Me.cmbZonaVenta.Location = New System.Drawing.Point(121, 150)
        Me.cmbZonaVenta.Name = "cmbZonaVenta"
        Me.cmbZonaVenta.Size = New System.Drawing.Size(412, 21)
        Me.cmbZonaVenta.TabIndex = 86
        '
        'TxtColoniaFac
        '
        Me.TxtColoniaFac.Location = New System.Drawing.Point(121, 72)
        Me.TxtColoniaFac.Name = "TxtColoniaFac"
        Me.TxtColoniaFac.Size = New System.Drawing.Size(263, 20)
        Me.TxtColoniaFac.TabIndex = 5
        '
        'TxtMunicipioFac
        '
        Me.TxtMunicipioFac.Location = New System.Drawing.Point(121, 46)
        Me.TxtMunicipioFac.Name = "TxtMunicipioFac"
        Me.TxtMunicipioFac.Size = New System.Drawing.Size(167, 20)
        Me.TxtMunicipioFac.TabIndex = 3
        '
        'TxtEstadoFac
        '
        Me.TxtEstadoFac.Location = New System.Drawing.Point(532, 17)
        Me.TxtEstadoFac.Name = "TxtEstadoFac"
        Me.TxtEstadoFac.Size = New System.Drawing.Size(178, 20)
        Me.TxtEstadoFac.TabIndex = 2
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(13, 127)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 15)
        Me.Label15.TabIndex = 84
        Me.Label15.Text = "Referencia"
        '
        'TxtReferenciaFac
        '
        Me.TxtReferenciaFac.Location = New System.Drawing.Point(121, 124)
        Me.TxtReferenciaFac.Name = "TxtReferenciaFac"
        Me.TxtReferenciaFac.Size = New System.Drawing.Size(412, 20)
        Me.TxtReferenciaFac.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(601, 100)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 16)
        Me.Label14.TabIndex = 82
        Me.Label14.Text = "No. Int."
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(401, 99)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 16)
        Me.Label13.TabIndex = 81
        Me.Label13.Text = "No. Ext."
        '
        'TxtNoInteriorFac
        '
        Me.TxtNoInteriorFac.Location = New System.Drawing.Point(662, 96)
        Me.TxtNoInteriorFac.Name = "TxtNoInteriorFac"
        Me.TxtNoInteriorFac.Size = New System.Drawing.Size(48, 20)
        Me.TxtNoInteriorFac.TabIndex = 9
        '
        'TxtNoExteriorFac
        '
        Me.TxtNoExteriorFac.Location = New System.Drawing.Point(532, 97)
        Me.TxtNoExteriorFac.Name = "TxtNoExteriorFac"
        Me.TxtNoExteriorFac.Size = New System.Drawing.Size(64, 20)
        Me.TxtNoExteriorFac.TabIndex = 8
        '
        'TxtCodigoPostalFac
        '
        Me.TxtCodigoPostalFac.Location = New System.Drawing.Point(532, 72)
        Me.TxtCodigoPostalFac.Name = "TxtCodigoPostalFac"
        Me.TxtCodigoPostalFac.Size = New System.Drawing.Size(178, 20)
        Me.TxtCodigoPostalFac.TabIndex = 6
        '
        'TxtLocalidadFac
        '
        Me.TxtLocalidadFac.Location = New System.Drawing.Point(532, 42)
        Me.TxtLocalidadFac.Name = "TxtLocalidadFac"
        Me.TxtLocalidadFac.Size = New System.Drawing.Size(178, 20)
        Me.TxtLocalidadFac.TabIndex = 4
        '
        'TxtDomicilioFac
        '
        Me.TxtDomicilioFac.Location = New System.Drawing.Point(121, 98)
        Me.TxtDomicilioFac.Name = "TxtDomicilioFac"
        Me.TxtDomicilioFac.Size = New System.Drawing.Size(263, 20)
        Me.TxtDomicilioFac.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 15)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Calle"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(13, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 18)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Colonia"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(13, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 15)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Municipio"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(401, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 15)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Entidad/Estado"
        '
        'CmbPaisFac
        '
        Me.CmbPaisFac.Location = New System.Drawing.Point(121, 19)
        Me.CmbPaisFac.Name = "CmbPaisFac"
        Me.CmbPaisFac.Size = New System.Drawing.Size(167, 21)
        Me.CmbPaisFac.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(13, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 15)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "País"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(400, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 14)
        Me.Label10.TabIndex = 75
        Me.Label10.Text = "Ciudad/Población"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(401, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 15)
        Me.Label12.TabIndex = 77
        Me.Label12.Text = "Código Postal"
        '
        'GrpCliente
        '
        Me.GrpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCliente.BackColor = System.Drawing.Color.Transparent
        Me.GrpCliente.Controls.Add(Me.Label43)
        Me.GrpCliente.Controls.Add(Me.txtSAP)
        Me.GrpCliente.Controls.Add(Me.btnCliente)
        Me.GrpCliente.Controls.Add(Me.lblCtaMaestra)
        Me.GrpCliente.Controls.Add(Me.txtCtaMaestra)
        Me.GrpCliente.Controls.Add(Me.chkFacturable)
        Me.GrpCliente.Controls.Add(Me.chkImpresion)
        Me.GrpCliente.Controls.Add(Me.PictureBox30)
        Me.GrpCliente.Controls.Add(Me.TxtRegFiscal)
        Me.GrpCliente.Controls.Add(Me.PictureBox29)
        Me.GrpCliente.Controls.Add(Me.Label38)
        Me.GrpCliente.Controls.Add(Me.cmbOrigen)
        Me.GrpCliente.Controls.Add(Me.PictureBox10)
        Me.GrpCliente.Controls.Add(Me.PictureBox9)
        Me.GrpCliente.Controls.Add(Me.PictureBox8)
        Me.GrpCliente.Controls.Add(Me.PictureBox7)
        Me.GrpCliente.Controls.Add(Me.PictureBox6)
        Me.GrpCliente.Controls.Add(Me.PictureBox5)
        Me.GrpCliente.Controls.Add(Me.PictureBox4)
        Me.GrpCliente.Controls.Add(Me.PictureBox3)
        Me.GrpCliente.Controls.Add(Me.PictureBox2)
        Me.GrpCliente.Controls.Add(Me.Label26)
        Me.GrpCliente.Controls.Add(Me.cmbRamo)
        Me.GrpCliente.Controls.Add(Me.Label25)
        Me.GrpCliente.Controls.Add(Me.txtAlterno)
        Me.GrpCliente.Controls.Add(Me.Label24)
        Me.GrpCliente.Controls.Add(Me.cmbTipoCanal)
        Me.GrpCliente.Controls.Add(Me.TxtCtaContable)
        Me.GrpCliente.Controls.Add(Me.Label23)
        Me.GrpCliente.Controls.Add(Me.TxtGLN)
        Me.GrpCliente.Controls.Add(Me.Label22)
        Me.GrpCliente.Controls.Add(Me.TxtCURP)
        Me.GrpCliente.Controls.Add(Me.Label21)
        Me.GrpCliente.Controls.Add(Me.CmbTipo)
        Me.GrpCliente.Controls.Add(Me.Label4)
        Me.GrpCliente.Controls.Add(Me.cmbResponsable)
        Me.GrpCliente.Controls.Add(Me.ChkDesglosarIVA)
        Me.GrpCliente.Controls.Add(Me.Label2)
        Me.GrpCliente.Controls.Add(Me.TxtDiasCredito)
        Me.GrpCliente.Controls.Add(Me.Label1)
        Me.GrpCliente.Controls.Add(Me.cmbListaPrecio)
        Me.GrpCliente.Controls.Add(Me.lblLimite)
        Me.GrpCliente.Controls.Add(Me.TxtLimite)
        Me.GrpCliente.Controls.Add(Me.lblRFC)
        Me.GrpCliente.Controls.Add(Me.TxtRFC)
        Me.GrpCliente.Controls.Add(Me.PictureBox1)
        Me.GrpCliente.Controls.Add(Me.BtnKey)
        Me.GrpCliente.Controls.Add(Me.ChkEstado)
        Me.GrpCliente.Controls.Add(Me.TxtFechaRegistro)
        Me.GrpCliente.Controls.Add(Me.lblFechaReg)
        Me.GrpCliente.Controls.Add(Me.TxtRazonSocial)
        Me.GrpCliente.Controls.Add(Me.Label11)
        Me.GrpCliente.Controls.Add(Me.LblTPersona)
        Me.GrpCliente.Controls.Add(Me.TxtNombreCorto)
        Me.GrpCliente.Controls.Add(Me.LblNombre)
        Me.GrpCliente.Controls.Add(Me.LblClave)
        Me.GrpCliente.Controls.Add(Me.TxtClave)
        Me.GrpCliente.Controls.Add(Me.CmbTipoPersona)
        Me.GrpCliente.Controls.Add(Me.Label9)
        Me.GrpCliente.Controls.Add(Me.lblRegFiscal)
        Me.GrpCliente.Location = New System.Drawing.Point(15, 8)
        Me.GrpCliente.MinimumSize = New System.Drawing.Size(725, 332)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.Size = New System.Drawing.Size(725, 355)
        Me.GrpCliente.TabIndex = 1
        Me.GrpCliente.TabStop = False
        Me.GrpCliente.Text = "Cliente"
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(338, 133)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(33, 14)
        Me.Label43.TabIndex = 107
        Me.Label43.Text = "SAP"
        '
        'txtSAP
        '
        Me.txtSAP.Location = New System.Drawing.Point(393, 130)
        Me.txtSAP.Name = "txtSAP"
        Me.txtSAP.ReadOnly = True
        Me.txtSAP.Size = New System.Drawing.Size(153, 20)
        Me.txtSAP.TabIndex = 106
        '
        'btnCliente
        '
        Me.btnCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCliente.Icon = CType(resources.GetObject("btnCliente.Icon"), System.Drawing.Icon)
        Me.btnCliente.Location = New System.Drawing.Point(280, 127)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(44, 21)
        Me.btnCliente.TabIndex = 105
        Me.btnCliente.ToolTipText = "Modifica Cta.Maestra"
        Me.btnCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lblCtaMaestra
        '
        Me.lblCtaMaestra.Location = New System.Drawing.Point(13, 133)
        Me.lblCtaMaestra.Name = "lblCtaMaestra"
        Me.lblCtaMaestra.Size = New System.Drawing.Size(93, 14)
        Me.lblCtaMaestra.TabIndex = 104
        Me.lblCtaMaestra.Text = "Cta. Maestra"
        '
        'txtCtaMaestra
        '
        Me.txtCtaMaestra.Enabled = False
        Me.txtCtaMaestra.Location = New System.Drawing.Point(121, 127)
        Me.txtCtaMaestra.Name = "txtCtaMaestra"
        Me.txtCtaMaestra.ReadOnly = True
        Me.txtCtaMaestra.Size = New System.Drawing.Size(153, 20)
        Me.txtCtaMaestra.TabIndex = 103
        '
        'chkFacturable
        '
        Me.chkFacturable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFacturable.Checked = True
        Me.chkFacturable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFacturable.Location = New System.Drawing.Point(577, 39)
        Me.chkFacturable.Name = "chkFacturable"
        Me.chkFacturable.Size = New System.Drawing.Size(133, 22)
        Me.chkFacturable.TabIndex = 102
        Me.chkFacturable.Text = "Fact. Automatica"
        '
        'chkImpresion
        '
        Me.chkImpresion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkImpresion.Checked = True
        Me.chkImpresion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkImpresion.Location = New System.Drawing.Point(577, 69)
        Me.chkImpresion.Name = "chkImpresion"
        Me.chkImpresion.Size = New System.Drawing.Size(133, 22)
        Me.chkImpresion.TabIndex = 100
        Me.chkImpresion.Text = "Imprimir Factura"
        '
        'PictureBox30
        '
        Me.PictureBox30.Image = CType(resources.GetObject("PictureBox30.Image"), System.Drawing.Image)
        Me.PictureBox30.Location = New System.Drawing.Point(364, 44)
        Me.PictureBox30.Name = "PictureBox30"
        Me.PictureBox30.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox30.TabIndex = 99
        Me.PictureBox30.TabStop = False
        Me.PictureBox30.Visible = False
        '
        'TxtRegFiscal
        '
        Me.TxtRegFiscal.Location = New System.Drawing.Point(393, 43)
        Me.TxtRegFiscal.Name = "TxtRegFiscal"
        Me.TxtRegFiscal.Size = New System.Drawing.Size(153, 20)
        Me.TxtRegFiscal.TabIndex = 97
        Me.TxtRegFiscal.Visible = False
        '
        'PictureBox29
        '
        Me.PictureBox29.Image = CType(resources.GetObject("PictureBox29.Image"), System.Drawing.Image)
        Me.PictureBox29.Location = New System.Drawing.Point(93, 42)
        Me.PictureBox29.Name = "PictureBox29"
        Me.PictureBox29.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox29.TabIndex = 96
        Me.PictureBox29.TabStop = False
        Me.PictureBox29.Visible = False
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(13, 46)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(93, 15)
        Me.Label38.TabIndex = 95
        Me.Label38.Text = "Origen"
        '
        'cmbOrigen
        '
        Me.cmbOrigen.BackColor = System.Drawing.SystemColors.Window
        Me.cmbOrigen.Items.AddRange(New Object() {"Nacional", "Extranjero"})
        Me.cmbOrigen.Location = New System.Drawing.Point(121, 42)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(153, 21)
        Me.cmbOrigen.TabIndex = 94
        '
        'PictureBox10
        '
        Me.PictureBox10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(530, 330)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox10.TabIndex = 93
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'PictureBox9
        '
        Me.PictureBox9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(530, 302)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(18, 17)
        Me.PictureBox9.TabIndex = 64
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(530, 269)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox8.TabIndex = 92
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(93, 17)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox7.TabIndex = 91
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(93, 304)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox6.TabIndex = 90
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(93, 263)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox5.TabIndex = 89
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(93, 213)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox4.TabIndex = 88
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(93, 158)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox3.TabIndex = 87
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(93, 100)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox2.TabIndex = 86
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(396, 212)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(93, 15)
        Me.Label26.TabIndex = 85
        Me.Label26.Text = "Ramo o Giro"
        '
        'cmbRamo
        '
        Me.cmbRamo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbRamo.ItemHeight = 13
        Me.cmbRamo.Location = New System.Drawing.Point(507, 209)
        Me.cmbRamo.Name = "cmbRamo"
        Me.cmbRamo.Size = New System.Drawing.Size(203, 21)
        Me.cmbRamo.TabIndex = 84
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(338, 103)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(49, 14)
        Me.Label25.TabIndex = 83
        Me.Label25.Text = "Alterno"
        '
        'txtAlterno
        '
        Me.txtAlterno.Location = New System.Drawing.Point(393, 100)
        Me.txtAlterno.Name = "txtAlterno"
        Me.txtAlterno.Size = New System.Drawing.Size(153, 20)
        Me.txtAlterno.TabIndex = 82
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(13, 272)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(93, 15)
        Me.Label24.TabIndex = 80
        Me.Label24.Text = "Canal de Venta"
        '
        'cmbTipoCanal
        '
        Me.cmbTipoCanal.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoCanal.ItemHeight = 13
        Me.cmbTipoCanal.Location = New System.Drawing.Point(121, 266)
        Me.cmbTipoCanal.Name = "cmbTipoCanal"
        Me.cmbTipoCanal.Size = New System.Drawing.Size(242, 21)
        Me.cmbTipoCanal.TabIndex = 79
        '
        'TxtCtaContable
        '
        Me.TxtCtaContable.Location = New System.Drawing.Point(121, 328)
        Me.TxtCtaContable.Name = "TxtCtaContable"
        Me.TxtCtaContable.Size = New System.Drawing.Size(242, 20)
        Me.TxtCtaContable.TabIndex = 77
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(13, 331)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(93, 14)
        Me.Label23.TabIndex = 78
        Me.Label23.Text = "Cta. Contable"
        '
        'TxtGLN
        '
        Me.TxtGLN.Location = New System.Drawing.Point(507, 183)
        Me.TxtGLN.Name = "TxtGLN"
        Me.TxtGLN.Size = New System.Drawing.Size(203, 20)
        Me.TxtGLN.TabIndex = 75
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(398, 186)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 14)
        Me.Label22.TabIndex = 76
        Me.Label22.Text = "GLN"
        '
        'TxtCURP
        '
        Me.TxtCURP.Location = New System.Drawing.Point(121, 236)
        Me.TxtCURP.Name = "TxtCURP"
        Me.TxtCURP.Size = New System.Drawing.Size(242, 20)
        Me.TxtCURP.TabIndex = 7
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(13, 239)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 14)
        Me.Label21.TabIndex = 74
        Me.Label21.Text = "CURP"
        '
        'CmbTipo
        '
        Me.CmbTipo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipo.Location = New System.Drawing.Point(557, 266)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(153, 21)
        Me.CmbTipo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(13, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 15)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Responsable"
        '
        'cmbResponsable
        '
        Me.cmbResponsable.BackColor = System.Drawing.SystemColors.Window
        Me.cmbResponsable.ItemHeight = 13
        Me.cmbResponsable.Location = New System.Drawing.Point(121, 15)
        Me.cmbResponsable.Name = "cmbResponsable"
        Me.cmbResponsable.Size = New System.Drawing.Size(242, 21)
        Me.cmbResponsable.TabIndex = 11
        '
        'ChkDesglosarIVA
        '
        Me.ChkDesglosarIVA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkDesglosarIVA.Location = New System.Drawing.Point(577, 238)
        Me.ChkDesglosarIVA.Name = "ChkDesglosarIVA"
        Me.ChkDesglosarIVA.Size = New System.Drawing.Size(133, 22)
        Me.ChkDesglosarIVA.TabIndex = 2
        Me.ChkDesglosarIVA.Text = "No Desglosar IEPS"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(398, 331)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 15)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Dias de Crédito"
        '
        'TxtDiasCredito
        '
        Me.TxtDiasCredito.Location = New System.Drawing.Point(590, 328)
        Me.TxtDiasCredito.Name = "TxtDiasCredito"
        Me.TxtDiasCredito.Size = New System.Drawing.Size(120, 20)
        Me.TxtDiasCredito.TabIndex = 9
        Me.TxtDiasCredito.Text = "0"
        Me.TxtDiasCredito.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtDiasCredito.Value = 0
        Me.TxtDiasCredito.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 301)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 15)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Lista de Precio"
        '
        'cmbListaPrecio
        '
        Me.cmbListaPrecio.BackColor = System.Drawing.SystemColors.Window
        Me.cmbListaPrecio.ItemHeight = 13
        Me.cmbListaPrecio.Location = New System.Drawing.Point(121, 298)
        Me.cmbListaPrecio.Name = "cmbListaPrecio"
        Me.cmbListaPrecio.Size = New System.Drawing.Size(242, 21)
        Me.cmbListaPrecio.TabIndex = 10
        '
        'lblLimite
        '
        Me.lblLimite.Location = New System.Drawing.Point(398, 301)
        Me.lblLimite.Name = "lblLimite"
        Me.lblLimite.Size = New System.Drawing.Size(90, 15)
        Me.lblLimite.TabIndex = 57
        Me.lblLimite.Text = "Límite de Crédito"
        '
        'TxtLimite
        '
        Me.TxtLimite.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.TxtLimite.Location = New System.Drawing.Point(590, 298)
        Me.TxtLimite.Name = "TxtLimite"
        Me.TxtLimite.Size = New System.Drawing.Size(120, 20)
        Me.TxtLimite.TabIndex = 8
        Me.TxtLimite.Text = "$0.00"
        Me.TxtLimite.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtLimite.Value = 0.0R
        Me.TxtLimite.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'lblRFC
        '
        Me.lblRFC.Location = New System.Drawing.Point(13, 212)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(33, 15)
        Me.lblRFC.TabIndex = 55
        Me.lblRFC.Text = "RFC"
        '
        'TxtRFC
        '
        Me.TxtRFC.Location = New System.Drawing.Point(121, 209)
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.Size = New System.Drawing.Size(127, 20)
        Me.TxtRFC.TabIndex = 6
        Me.TxtRFC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(93, 69)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox1.TabIndex = 40
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnKey
        '
        Me.BtnKey.Image = CType(resources.GetObject("BtnKey.Image"), System.Drawing.Image)
        Me.BtnKey.Location = New System.Drawing.Point(280, 97)
        Me.BtnKey.Name = "BtnKey"
        Me.BtnKey.Size = New System.Drawing.Size(44, 21)
        Me.BtnKey.TabIndex = 1
        Me.BtnKey.ToolTipText = "Generar clave automatica"
        Me.BtnKey.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkEstado
        '
        Me.ChkEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Location = New System.Drawing.Point(653, 15)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(57, 22)
        Me.ChkEstado.TabIndex = 1
        Me.ChkEstado.Text = "Activo"
        '
        'TxtFechaRegistro
        '
        Me.TxtFechaRegistro.Location = New System.Drawing.Point(424, 71)
        Me.TxtFechaRegistro.Name = "TxtFechaRegistro"
        Me.TxtFechaRegistro.ReadOnly = True
        Me.TxtFechaRegistro.Size = New System.Drawing.Size(122, 20)
        Me.TxtFechaRegistro.TabIndex = 51
        Me.TxtFechaRegistro.TabStop = False
        '
        'lblFechaReg
        '
        Me.lblFechaReg.Location = New System.Drawing.Point(280, 73)
        Me.lblFechaReg.Name = "lblFechaReg"
        Me.lblFechaReg.Size = New System.Drawing.Size(88, 15)
        Me.lblFechaReg.TabIndex = 47
        Me.lblFechaReg.Text = "Fecha Registro"
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Location = New System.Drawing.Point(121, 157)
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.Size = New System.Drawing.Size(589, 20)
        Me.TxtRazonSocial.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(13, 160)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 15)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Razón Social"
        '
        'LblTPersona
        '
        Me.LblTPersona.Location = New System.Drawing.Point(13, 73)
        Me.LblTPersona.Name = "LblTPersona"
        Me.LblTPersona.Size = New System.Drawing.Size(93, 15)
        Me.LblTPersona.TabIndex = 23
        Me.LblTPersona.Text = "Tipo de Persona"
        '
        'TxtNombreCorto
        '
        Me.TxtNombreCorto.Location = New System.Drawing.Point(121, 183)
        Me.TxtNombreCorto.Name = "TxtNombreCorto"
        Me.TxtNombreCorto.Size = New System.Drawing.Size(242, 20)
        Me.TxtNombreCorto.TabIndex = 3
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(13, 186)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(102, 15)
        Me.LblNombre.TabIndex = 3
        Me.LblNombre.Text = "Nombre Corto"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(13, 103)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(68, 14)
        Me.LblClave.TabIndex = 1
        Me.LblClave.Text = "Clave"
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(121, 98)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(153, 20)
        Me.TxtClave.TabIndex = 0
        '
        'CmbTipoPersona
        '
        Me.CmbTipoPersona.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipoPersona.Location = New System.Drawing.Point(121, 69)
        Me.CmbTipoPersona.Name = "CmbTipoPersona"
        Me.CmbTipoPersona.Size = New System.Drawing.Size(153, 21)
        Me.CmbTipoPersona.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(398, 269)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 12)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "Tipo Impuesto"
        '
        'lblRegFiscal
        '
        Me.lblRegFiscal.Location = New System.Drawing.Point(280, 48)
        Me.lblRegFiscal.Name = "lblRegFiscal"
        Me.lblRegFiscal.Size = New System.Drawing.Size(107, 14)
        Me.lblRegFiscal.TabIndex = 98
        Me.lblRegFiscal.Text = "Num. Identificación"
        Me.lblRegFiscal.Visible = False
        '
        'GrpContacto
        '
        Me.GrpContacto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpContacto.BackColor = System.Drawing.Color.Transparent
        Me.GrpContacto.Controls.Add(Me.PictureBox37)
        Me.GrpContacto.Controls.Add(Me.PictureBox36)
        Me.GrpContacto.Controls.Add(Me.PictureBox35)
        Me.GrpContacto.Controls.Add(Me.cmbFechaNacimiento)
        Me.GrpContacto.Controls.Add(Me.cmbGenero)
        Me.GrpContacto.Controls.Add(Me.Label45)
        Me.GrpContacto.Controls.Add(Me.Label44)
        Me.GrpContacto.Controls.Add(Me.cmbTipoTel1)
        Me.GrpContacto.Controls.Add(Me.cmbTipoTel2)
        Me.GrpContacto.Controls.Add(Me.PictureBox34)
        Me.GrpContacto.Controls.Add(Me.LblEmail)
        Me.GrpContacto.Controls.Add(Me.LblTel2)
        Me.GrpContacto.Controls.Add(Me.LblTel1)
        Me.GrpContacto.Controls.Add(Me.TxtTel2)
        Me.GrpContacto.Controls.Add(Me.TxtContacto)
        Me.GrpContacto.Controls.Add(Me.LblContacto)
        Me.GrpContacto.Controls.Add(Me.TxtMail)
        Me.GrpContacto.Controls.Add(Me.TxtTel1)
        Me.GrpContacto.Location = New System.Drawing.Point(15, 621)
        Me.GrpContacto.MinimumSize = New System.Drawing.Size(725, 122)
        Me.GrpContacto.Name = "GrpContacto"
        Me.GrpContacto.Size = New System.Drawing.Size(725, 153)
        Me.GrpContacto.TabIndex = 3
        Me.GrpContacto.TabStop = False
        Me.GrpContacto.Text = "Contacto"
        '
        'PictureBox37
        '
        Me.PictureBox37.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox37.Image = CType(resources.GetObject("PictureBox37.Image"), System.Drawing.Image)
        Me.PictureBox37.Location = New System.Drawing.Point(439, 87)
        Me.PictureBox37.Name = "PictureBox37"
        Me.PictureBox37.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox37.TabIndex = 117
        Me.PictureBox37.TabStop = False
        Me.PictureBox37.Visible = False
        '
        'PictureBox36
        '
        Me.PictureBox36.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox36.Image = CType(resources.GetObject("PictureBox36.Image"), System.Drawing.Image)
        Me.PictureBox36.Location = New System.Drawing.Point(93, 86)
        Me.PictureBox36.Name = "PictureBox36"
        Me.PictureBox36.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox36.TabIndex = 116
        Me.PictureBox36.TabStop = False
        Me.PictureBox36.Visible = False
        '
        'PictureBox35
        '
        Me.PictureBox35.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox35.Image = CType(resources.GetObject("PictureBox35.Image"), System.Drawing.Image)
        Me.PictureBox35.Location = New System.Drawing.Point(95, 55)
        Me.PictureBox35.Name = "PictureBox35"
        Me.PictureBox35.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox35.TabIndex = 115
        Me.PictureBox35.TabStop = False
        Me.PictureBox35.Visible = False
        '
        'cmbFechaNacimiento
        '
        Me.cmbFechaNacimiento.CustomFormat = "yyyyMMdd"
        Me.cmbFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFechaNacimiento.Location = New System.Drawing.Point(507, 53)
        Me.cmbFechaNacimiento.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaNacimiento.Name = "cmbFechaNacimiento"
        Me.cmbFechaNacimiento.Size = New System.Drawing.Size(125, 20)
        Me.cmbFechaNacimiento.TabIndex = 114
        Me.cmbFechaNacimiento.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'cmbGenero
        '
        Me.cmbGenero.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbGenero.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGenero.ItemHeight = 13
        Me.cmbGenero.Location = New System.Drawing.Point(121, 52)
        Me.cmbGenero.Name = "cmbGenero"
        Me.cmbGenero.Size = New System.Drawing.Size(167, 21)
        Me.cmbGenero.TabIndex = 113
        '
        'Label45
        '
        Me.Label45.Location = New System.Drawing.Point(375, 55)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(113, 15)
        Me.Label45.TabIndex = 112
        Me.Label45.Text = "Fecha Nacimiento"
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(13, 55)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(63, 15)
        Me.Label44.TabIndex = 111
        Me.Label44.Text = "Genero"
        '
        'cmbTipoTel1
        '
        Me.cmbTipoTel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbTipoTel1.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoTel1.ItemHeight = 13
        Me.cmbTipoTel1.Location = New System.Drawing.Point(121, 84)
        Me.cmbTipoTel1.Name = "cmbTipoTel1"
        Me.cmbTipoTel1.Size = New System.Drawing.Size(86, 21)
        Me.cmbTipoTel1.TabIndex = 110
        '
        'cmbTipoTel2
        '
        Me.cmbTipoTel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbTipoTel2.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoTel2.ItemHeight = 13
        Me.cmbTipoTel2.Location = New System.Drawing.Point(462, 84)
        Me.cmbTipoTel2.Name = "cmbTipoTel2"
        Me.cmbTipoTel2.Size = New System.Drawing.Size(86, 21)
        Me.cmbTipoTel2.TabIndex = 109
        '
        'PictureBox34
        '
        Me.PictureBox34.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox34.Image = CType(resources.GetObject("PictureBox34.Image"), System.Drawing.Image)
        Me.PictureBox34.Location = New System.Drawing.Point(95, 121)
        Me.PictureBox34.Name = "PictureBox34"
        Me.PictureBox34.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox34.TabIndex = 100
        Me.PictureBox34.TabStop = False
        Me.PictureBox34.Visible = False
        '
        'LblEmail
        '
        Me.LblEmail.Location = New System.Drawing.Point(13, 124)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(60, 15)
        Me.LblEmail.TabIndex = 63
        Me.LblEmail.Text = "Correo(s)"
        '
        'LblTel2
        '
        Me.LblTel2.Location = New System.Drawing.Point(375, 87)
        Me.LblTel2.Name = "LblTel2"
        Me.LblTel2.Size = New System.Drawing.Size(63, 15)
        Me.LblTel2.TabIndex = 62
        Me.LblTel2.Text = "Secundario"
        '
        'LblTel1
        '
        Me.LblTel1.Location = New System.Drawing.Point(13, 87)
        Me.LblTel1.Name = "LblTel1"
        Me.LblTel1.Size = New System.Drawing.Size(53, 14)
        Me.LblTel1.TabIndex = 61
        Me.LblTel1.Text = "Principal"
        '
        'TxtTel2
        '
        Me.TxtTel2.Location = New System.Drawing.Point(557, 84)
        Me.TxtTel2.Name = "TxtTel2"
        Me.TxtTel2.Size = New System.Drawing.Size(153, 20)
        Me.TxtTel2.TabIndex = 3
        Me.TxtTel2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'TxtContacto
        '
        Me.TxtContacto.Location = New System.Drawing.Point(121, 20)
        Me.TxtContacto.Name = "TxtContacto"
        Me.TxtContacto.Size = New System.Drawing.Size(427, 20)
        Me.TxtContacto.TabIndex = 1
        '
        'LblContacto
        '
        Me.LblContacto.Location = New System.Drawing.Point(13, 23)
        Me.LblContacto.Name = "LblContacto"
        Me.LblContacto.Size = New System.Drawing.Size(60, 15)
        Me.LblContacto.TabIndex = 34
        Me.LblContacto.Text = "Contacto"
        '
        'TxtMail
        '
        Me.TxtMail.Location = New System.Drawing.Point(121, 121)
        Me.TxtMail.Name = "TxtMail"
        Me.TxtMail.Size = New System.Drawing.Size(493, 20)
        Me.TxtMail.TabIndex = 4
        '
        'TxtTel1
        '
        Me.TxtTel1.Location = New System.Drawing.Point(213, 84)
        Me.TxtTel1.Name = "TxtTel1"
        Me.TxtTel1.Size = New System.Drawing.Size(153, 20)
        Me.TxtTel1.TabIndex = 2
        Me.TxtTel1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'UiTabCanal
        '
        Me.UiTabCanal.Controls.Add(Me.grpCanales)
        Me.UiTabCanal.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCanal.Name = "UiTabCanal"
        Me.UiTabCanal.Size = New System.Drawing.Size(771, 482)
        Me.UiTabCanal.TabStop = True
        Me.UiTabCanal.Text = "Canales de Venta"
        Me.UiTabCanal.ToolTipText = "Agrega listas de precios diferentes por tipo de canal de venta"
        '
        'grpCanales
        '
        Me.grpCanales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCanales.BackColor = System.Drawing.Color.Transparent
        Me.grpCanales.Controls.Add(Me.btnAddCanal)
        Me.grpCanales.Controls.Add(Me.btnDelCanal)
        Me.grpCanales.Controls.Add(Me.cmbListaPrecio2)
        Me.grpCanales.Controls.Add(Me.cmbTipoCanal2)
        Me.grpCanales.Controls.Add(Me.Label46)
        Me.grpCanales.Controls.Add(Me.Label47)
        Me.grpCanales.Controls.Add(Me.gridCanales)
        Me.grpCanales.Location = New System.Drawing.Point(8, 7)
        Me.grpCanales.Name = "grpCanales"
        Me.grpCanales.Size = New System.Drawing.Size(754, 468)
        Me.grpCanales.TabIndex = 11
        Me.grpCanales.TabStop = False
        Me.grpCanales.Text = "Canales"
        '
        'btnAddCanal
        '
        Me.btnAddCanal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddCanal.Icon = CType(resources.GetObject("btnAddCanal.Icon"), System.Drawing.Icon)
        Me.btnAddCanal.Location = New System.Drawing.Point(711, 12)
        Me.btnAddCanal.Name = "btnAddCanal"
        Me.btnAddCanal.Size = New System.Drawing.Size(30, 30)
        Me.btnAddCanal.TabIndex = 108
        Me.btnAddCanal.ToolTipText = "Agregar Canal de Venta"
        Me.btnAddCanal.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnDelCanal
        '
        Me.btnDelCanal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelCanal.Icon = CType(resources.GetObject("btnDelCanal.Icon"), System.Drawing.Icon)
        Me.btnDelCanal.Location = New System.Drawing.Point(675, 12)
        Me.btnDelCanal.Name = "btnDelCanal"
        Me.btnDelCanal.Size = New System.Drawing.Size(30, 30)
        Me.btnDelCanal.TabIndex = 107
        Me.btnDelCanal.ToolTipText = "Eliminar canal de venta seleccionada"
        Me.btnDelCanal.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbListaPrecio2
        '
        Me.cmbListaPrecio2.BackColor = System.Drawing.SystemColors.Window
        Me.cmbListaPrecio2.ItemHeight = 13
        Me.cmbListaPrecio2.Location = New System.Drawing.Point(437, 21)
        Me.cmbListaPrecio2.Name = "cmbListaPrecio2"
        Me.cmbListaPrecio2.Size = New System.Drawing.Size(207, 21)
        Me.cmbListaPrecio2.TabIndex = 81
        '
        'cmbTipoCanal2
        '
        Me.cmbTipoCanal2.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoCanal2.ItemHeight = 13
        Me.cmbTipoCanal2.Location = New System.Drawing.Point(103, 21)
        Me.cmbTipoCanal2.Name = "cmbTipoCanal2"
        Me.cmbTipoCanal2.Size = New System.Drawing.Size(242, 21)
        Me.cmbTipoCanal2.TabIndex = 80
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(351, 24)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(80, 15)
        Me.Label46.TabIndex = 61
        Me.Label46.Text = "Lista de Precio"
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(10, 24)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(98, 15)
        Me.Label47.TabIndex = 59
        Me.Label47.Text = "Canal de Venta"
        '
        'gridCanales
        '
        Me.gridCanales.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.gridCanales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridCanales.ColumnAutoResize = True
        Me.gridCanales.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.gridCanales.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.gridCanales.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.gridCanales.Location = New System.Drawing.Point(13, 48)
        Me.gridCanales.Name = "gridCanales"
        Me.gridCanales.RecordNavigator = True
        Me.gridCanales.Size = New System.Drawing.Size(728, 404)
        Me.gridCanales.TabIndex = 2
        Me.gridCanales.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabDomicilio
        '
        Me.UiTabDomicilio.Controls.Add(Me.GrpDomicilio)
        Me.UiTabDomicilio.Controls.Add(Me.GrpDomicilios)
        Me.UiTabDomicilio.Location = New System.Drawing.Point(1, 21)
        Me.UiTabDomicilio.Name = "UiTabDomicilio"
        Me.UiTabDomicilio.Size = New System.Drawing.Size(771, 482)
        Me.UiTabDomicilio.TabStop = True
        Me.UiTabDomicilio.Text = "Puntos de Entrega"
        Me.UiTabDomicilio.Visible = False
        '
        'GrpDomicilio
        '
        Me.GrpDomicilio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDomicilio.BackColor = System.Drawing.Color.Transparent
        Me.GrpDomicilio.Controls.Add(Me.PictureBox33)
        Me.GrpDomicilio.Controls.Add(Me.Label42)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox28)
        Me.GrpDomicilio.Controls.Add(Me.TxtClavePE)
        Me.GrpDomicilio.Controls.Add(Me.Label37)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox25)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox24)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox23)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox22)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox21)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox20)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox19)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox18)
        Me.GrpDomicilio.Controls.Add(Me.Label33)
        Me.GrpDomicilio.Controls.Add(Me.txtTelDomicilio)
        Me.GrpDomicilio.Controls.Add(Me.TxtConsignatario)
        Me.GrpDomicilio.Controls.Add(Me.Label32)
        Me.GrpDomicilio.Controls.Add(Me.TxtNombre)
        Me.GrpDomicilio.Controls.Add(Me.Label31)
        Me.GrpDomicilio.Controls.Add(Me.Label29)
        Me.GrpDomicilio.Controls.Add(Me.Label30)
        Me.GrpDomicilio.Controls.Add(Me.TxtColonia)
        Me.GrpDomicilio.Controls.Add(Me.TxtMunicipio)
        Me.GrpDomicilio.Controls.Add(Me.TxtEstado)
        Me.GrpDomicilio.Controls.Add(Me.Label18)
        Me.GrpDomicilio.Controls.Add(Me.TxtReferencia)
        Me.GrpDomicilio.Controls.Add(Me.Label19)
        Me.GrpDomicilio.Controls.Add(Me.Label20)
        Me.GrpDomicilio.Controls.Add(Me.TxtNoInterior)
        Me.GrpDomicilio.Controls.Add(Me.TxtNoExterior)
        Me.GrpDomicilio.Controls.Add(Me.TxtCodigoPostal)
        Me.GrpDomicilio.Controls.Add(Me.TxtLocalidad)
        Me.GrpDomicilio.Controls.Add(Me.Label16)
        Me.GrpDomicilio.Controls.Add(Me.TxtCalle)
        Me.GrpDomicilio.Controls.Add(Me.LblCalle)
        Me.GrpDomicilio.Controls.Add(Me.BtnDelDomi)
        Me.GrpDomicilio.Controls.Add(Me.LblColonia)
        Me.GrpDomicilio.Controls.Add(Me.LblMnpio)
        Me.GrpDomicilio.Controls.Add(Me.LblEstado)
        Me.GrpDomicilio.Controls.Add(Me.LblPais)
        Me.GrpDomicilio.Controls.Add(Me.BtnAceptarDomi)
        Me.GrpDomicilio.Controls.Add(Me.Label17)
        Me.GrpDomicilio.Controls.Add(Me.cmbTipoImpuesto)
        Me.GrpDomicilio.Controls.Add(Me.cmbZonaRep)
        Me.GrpDomicilio.Controls.Add(Me.cmbZonaVtap)
        Me.GrpDomicilio.Controls.Add(Me.ChkDomicilio)
        Me.GrpDomicilio.Controls.Add(Me.cmbPais)
        Me.GrpDomicilio.Location = New System.Drawing.Point(7, 3)
        Me.GrpDomicilio.Name = "GrpDomicilio"
        Me.GrpDomicilio.Size = New System.Drawing.Size(754, 325)
        Me.GrpDomicilio.TabIndex = 0
        Me.GrpDomicilio.TabStop = False
        Me.GrpDomicilio.Text = "Domicilio de Punto de Entrega"
        '
        'PictureBox33
        '
        Me.PictureBox33.Image = CType(resources.GetObject("PictureBox33.Image"), System.Drawing.Image)
        Me.PictureBox33.Location = New System.Drawing.Point(441, 28)
        Me.PictureBox33.Name = "PictureBox33"
        Me.PictureBox33.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox33.TabIndex = 116
        Me.PictureBox33.TabStop = False
        Me.PictureBox33.Visible = False
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(309, 28)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(93, 12)
        Me.Label42.TabIndex = 115
        Me.Label42.Text = "Tipo Impuesto"
        '
        'PictureBox28
        '
        Me.PictureBox28.Image = CType(resources.GetObject("PictureBox28.Image"), System.Drawing.Image)
        Me.PictureBox28.Location = New System.Drawing.Point(104, 25)
        Me.PictureBox28.Name = "PictureBox28"
        Me.PictureBox28.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox28.TabIndex = 113
        Me.PictureBox28.TabStop = False
        Me.PictureBox28.Visible = False
        '
        'TxtClavePE
        '
        Me.TxtClavePE.Location = New System.Drawing.Point(130, 25)
        Me.TxtClavePE.Name = "TxtClavePE"
        Me.TxtClavePE.Size = New System.Drawing.Size(147, 20)
        Me.TxtClavePE.TabIndex = 112
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(27, 28)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(97, 15)
        Me.Label37.TabIndex = 111
        Me.Label37.Text = "Clave"
        '
        'PictureBox25
        '
        Me.PictureBox25.Image = CType(resources.GetObject("PictureBox25.Image"), System.Drawing.Image)
        Me.PictureBox25.Location = New System.Drawing.Point(435, 217)
        Me.PictureBox25.Name = "PictureBox25"
        Me.PictureBox25.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox25.TabIndex = 110
        Me.PictureBox25.TabStop = False
        Me.PictureBox25.Visible = False
        '
        'PictureBox24
        '
        Me.PictureBox24.Image = CType(resources.GetObject("PictureBox24.Image"), System.Drawing.Image)
        Me.PictureBox24.Location = New System.Drawing.Point(104, 215)
        Me.PictureBox24.Name = "PictureBox24"
        Me.PictureBox24.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox24.TabIndex = 109
        Me.PictureBox24.TabStop = False
        Me.PictureBox24.Visible = False
        '
        'PictureBox23
        '
        Me.PictureBox23.Image = CType(resources.GetObject("PictureBox23.Image"), System.Drawing.Image)
        Me.PictureBox23.Location = New System.Drawing.Point(470, 188)
        Me.PictureBox23.Name = "PictureBox23"
        Me.PictureBox23.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox23.TabIndex = 108
        Me.PictureBox23.TabStop = False
        Me.PictureBox23.Visible = False
        '
        'PictureBox22
        '
        Me.PictureBox22.Image = CType(resources.GetObject("PictureBox22.Image"), System.Drawing.Image)
        Me.PictureBox22.Location = New System.Drawing.Point(104, 190)
        Me.PictureBox22.Name = "PictureBox22"
        Me.PictureBox22.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox22.TabIndex = 107
        Me.PictureBox22.TabStop = False
        Me.PictureBox22.Visible = False
        '
        'PictureBox21
        '
        Me.PictureBox21.Image = CType(resources.GetObject("PictureBox21.Image"), System.Drawing.Image)
        Me.PictureBox21.Location = New System.Drawing.Point(102, 161)
        Me.PictureBox21.Name = "PictureBox21"
        Me.PictureBox21.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox21.TabIndex = 106
        Me.PictureBox21.TabStop = False
        Me.PictureBox21.Visible = False
        '
        'PictureBox20
        '
        Me.PictureBox20.Image = CType(resources.GetObject("PictureBox20.Image"), System.Drawing.Image)
        Me.PictureBox20.Location = New System.Drawing.Point(423, 133)
        Me.PictureBox20.Name = "PictureBox20"
        Me.PictureBox20.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox20.TabIndex = 105
        Me.PictureBox20.TabStop = False
        Me.PictureBox20.Visible = False
        '
        'PictureBox19
        '
        Me.PictureBox19.Image = CType(resources.GetObject("PictureBox19.Image"), System.Drawing.Image)
        Me.PictureBox19.Location = New System.Drawing.Point(102, 134)
        Me.PictureBox19.Name = "PictureBox19"
        Me.PictureBox19.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox19.TabIndex = 104
        Me.PictureBox19.TabStop = False
        Me.PictureBox19.Visible = False
        '
        'PictureBox18
        '
        Me.PictureBox18.Image = CType(resources.GetObject("PictureBox18.Image"), System.Drawing.Image)
        Me.PictureBox18.Location = New System.Drawing.Point(102, 81)
        Me.PictureBox18.Name = "PictureBox18"
        Me.PictureBox18.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox18.TabIndex = 100
        Me.PictureBox18.TabStop = False
        Me.PictureBox18.Visible = False
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(27, 110)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(53, 14)
        Me.Label33.TabIndex = 103
        Me.Label33.Text = "Tel/Fax"
        '
        'txtTelDomicilio
        '
        Me.txtTelDomicilio.Location = New System.Drawing.Point(130, 106)
        Me.txtTelDomicilio.Mask = "!(##) 000 00 0 00 00"
        Me.txtTelDomicilio.Name = "txtTelDomicilio"
        Me.txtTelDomicilio.Size = New System.Drawing.Size(189, 20)
        Me.txtTelDomicilio.TabIndex = 102
        Me.txtTelDomicilio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'TxtConsignatario
        '
        Me.TxtConsignatario.Location = New System.Drawing.Point(130, 79)
        Me.TxtConsignatario.Name = "TxtConsignatario"
        Me.TxtConsignatario.Size = New System.Drawing.Size(491, 20)
        Me.TxtConsignatario.TabIndex = 100
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(27, 82)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(93, 15)
        Me.Label32.TabIndex = 101
        Me.Label32.Text = "Consignatario"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(130, 52)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(242, 20)
        Me.TxtNombre.TabIndex = 99
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(27, 52)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(97, 15)
        Me.Label31.TabIndex = 98
        Me.Label31.Text = "Nombre Corto"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(231, 298)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(93, 15)
        Me.Label29.TabIndex = 97
        Me.Label29.Text = "Zona de Reparto"
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(231, 271)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(93, 15)
        Me.Label30.TabIndex = 95
        Me.Label30.Text = "Zona de Venta"
        '
        'TxtColonia
        '
        Me.TxtColonia.Location = New System.Drawing.Point(130, 188)
        Me.TxtColonia.Name = "TxtColonia"
        Me.TxtColonia.Size = New System.Drawing.Size(262, 20)
        Me.TxtColonia.TabIndex = 5
        '
        'TxtMunicipio
        '
        Me.TxtMunicipio.Location = New System.Drawing.Point(130, 161)
        Me.TxtMunicipio.Name = "TxtMunicipio"
        Me.TxtMunicipio.Size = New System.Drawing.Size(147, 20)
        Me.TxtMunicipio.TabIndex = 3
        '
        'TxtEstado
        '
        Me.TxtEstado.Location = New System.Drawing.Point(445, 131)
        Me.TxtEstado.Name = "TxtEstado"
        Me.TxtEstado.Size = New System.Drawing.Size(176, 20)
        Me.TxtEstado.TabIndex = 2
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(27, 249)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 14)
        Me.Label18.TabIndex = 90
        Me.Label18.Text = "Referencia"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(130, 242)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(491, 20)
        Me.TxtReferencia.TabIndex = 10
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(515, 218)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 16)
        Me.Label19.TabIndex = 88
        Me.Label19.Text = "No. Int."
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(406, 219)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(51, 16)
        Me.Label20.TabIndex = 87
        Me.Label20.Text = "No. Ext."
        '
        'TxtNoInterior
        '
        Me.TxtNoInterior.Location = New System.Drawing.Point(566, 215)
        Me.TxtNoInterior.Name = "TxtNoInterior"
        Me.TxtNoInterior.Size = New System.Drawing.Size(55, 20)
        Me.TxtNoInterior.TabIndex = 9
        '
        'TxtNoExterior
        '
        Me.TxtNoExterior.Location = New System.Drawing.Point(457, 215)
        Me.TxtNoExterior.Name = "TxtNoExterior"
        Me.TxtNoExterior.Size = New System.Drawing.Size(55, 20)
        Me.TxtNoExterior.TabIndex = 8
        '
        'TxtCodigoPostal
        '
        Me.TxtCodigoPostal.Location = New System.Drawing.Point(498, 186)
        Me.TxtCodigoPostal.Name = "TxtCodigoPostal"
        Me.TxtCodigoPostal.Size = New System.Drawing.Size(123, 20)
        Me.TxtCodigoPostal.TabIndex = 6
        '
        'TxtLocalidad
        '
        Me.TxtLocalidad.Location = New System.Drawing.Point(446, 158)
        Me.TxtLocalidad.Name = "TxtLocalidad"
        Me.TxtLocalidad.Size = New System.Drawing.Size(175, 20)
        Me.TxtLocalidad.TabIndex = 4
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(346, 160)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 14)
        Me.Label16.TabIndex = 77
        Me.Label16.Text = "Ciudad/Población"
        '
        'TxtCalle
        '
        Me.TxtCalle.Location = New System.Drawing.Point(130, 215)
        Me.TxtCalle.Name = "TxtCalle"
        Me.TxtCalle.Size = New System.Drawing.Size(275, 20)
        Me.TxtCalle.TabIndex = 7
        '
        'LblCalle
        '
        Me.LblCalle.Location = New System.Drawing.Point(27, 219)
        Me.LblCalle.Name = "LblCalle"
        Me.LblCalle.Size = New System.Drawing.Size(60, 15)
        Me.LblCalle.TabIndex = 67
        Me.LblCalle.Text = "Calle"
        '
        'BtnDelDomi
        '
        Me.BtnDelDomi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelDomi.Enabled = False
        Me.BtnDelDomi.Image = CType(resources.GetObject("BtnDelDomi.Image"), System.Drawing.Image)
        Me.BtnDelDomi.Location = New System.Drawing.Point(657, 62)
        Me.BtnDelDomi.Name = "BtnDelDomi"
        Me.BtnDelDomi.Size = New System.Drawing.Size(90, 30)
        Me.BtnDelDomi.TabIndex = 12
        Me.BtnDelDomi.Text = "&Eliminar"
        Me.BtnDelDomi.ToolTipText = "Eliminar domicilio seleccionado"
        Me.BtnDelDomi.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblColonia
        '
        Me.LblColonia.Location = New System.Drawing.Point(27, 189)
        Me.LblColonia.Name = "LblColonia"
        Me.LblColonia.Size = New System.Drawing.Size(80, 18)
        Me.LblColonia.TabIndex = 59
        Me.LblColonia.Text = "Colonia"
        '
        'LblMnpio
        '
        Me.LblMnpio.Location = New System.Drawing.Point(27, 162)
        Me.LblMnpio.Name = "LblMnpio"
        Me.LblMnpio.Size = New System.Drawing.Size(53, 15)
        Me.LblMnpio.TabIndex = 57
        Me.LblMnpio.Text = "Municipio"
        '
        'LblEstado
        '
        Me.LblEstado.Location = New System.Drawing.Point(343, 134)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(97, 17)
        Me.LblEstado.TabIndex = 55
        Me.LblEstado.Text = "Entidad/Estado"
        '
        'LblPais
        '
        Me.LblPais.Location = New System.Drawing.Point(27, 136)
        Me.LblPais.Name = "LblPais"
        Me.LblPais.Size = New System.Drawing.Size(36, 15)
        Me.LblPais.TabIndex = 51
        Me.LblPais.Text = "País"
        '
        'BtnAceptarDomi
        '
        Me.BtnAceptarDomi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAceptarDomi.Image = CType(resources.GetObject("BtnAceptarDomi.Image"), System.Drawing.Image)
        Me.BtnAceptarDomi.Location = New System.Drawing.Point(657, 18)
        Me.BtnAceptarDomi.Name = "BtnAceptarDomi"
        Me.BtnAceptarDomi.Size = New System.Drawing.Size(90, 30)
        Me.BtnAceptarDomi.TabIndex = 11
        Me.BtnAceptarDomi.Text = "&Aceptar"
        Me.BtnAceptarDomi.ToolTipText = "Guardar cambios"
        Me.BtnAceptarDomi.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(408, 190)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 15)
        Me.Label17.TabIndex = 79
        Me.Label17.Text = "Código Postal"
        '
        'cmbTipoImpuesto
        '
        Me.cmbTipoImpuesto.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoImpuesto.Location = New System.Drawing.Point(468, 25)
        Me.cmbTipoImpuesto.Name = "cmbTipoImpuesto"
        Me.cmbTipoImpuesto.Size = New System.Drawing.Size(153, 21)
        Me.cmbTipoImpuesto.TabIndex = 114
        '
        'cmbZonaRep
        '
        Me.cmbZonaRep.BackColor = System.Drawing.SystemColors.Window
        Me.cmbZonaRep.ItemHeight = 13
        Me.cmbZonaRep.Location = New System.Drawing.Point(358, 295)
        Me.cmbZonaRep.Name = "cmbZonaRep"
        Me.cmbZonaRep.Size = New System.Drawing.Size(263, 21)
        Me.cmbZonaRep.TabIndex = 96
        '
        'cmbZonaVtap
        '
        Me.cmbZonaVtap.BackColor = System.Drawing.SystemColors.Window
        Me.cmbZonaVtap.ItemHeight = 13
        Me.cmbZonaVtap.Location = New System.Drawing.Point(358, 268)
        Me.cmbZonaVtap.Name = "cmbZonaVtap"
        Me.cmbZonaVtap.Size = New System.Drawing.Size(263, 21)
        Me.cmbZonaVtap.TabIndex = 94
        '
        'ChkDomicilio
        '
        Me.ChkDomicilio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkDomicilio.Checked = True
        Me.ChkDomicilio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkDomicilio.Enabled = False
        Me.ChkDomicilio.Location = New System.Drawing.Point(130, 271)
        Me.ChkDomicilio.Name = "ChkDomicilio"
        Me.ChkDomicilio.Size = New System.Drawing.Size(69, 22)
        Me.ChkDomicilio.TabIndex = 7
        Me.ChkDomicilio.Text = "Activo"
        '
        'cmbPais
        '
        Me.cmbPais.Location = New System.Drawing.Point(130, 133)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(147, 21)
        Me.cmbPais.TabIndex = 13
        '
        'GrpDomicilios
        '
        Me.GrpDomicilios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDomicilios.BackColor = System.Drawing.Color.Transparent
        Me.GrpDomicilios.Controls.Add(Me.GridDomicilios)
        Me.GrpDomicilios.Location = New System.Drawing.Point(8, 334)
        Me.GrpDomicilios.Name = "GrpDomicilios"
        Me.GrpDomicilios.Size = New System.Drawing.Size(755, 141)
        Me.GrpDomicilios.TabIndex = 1
        Me.GrpDomicilios.TabStop = False
        Me.GrpDomicilios.Text = "Domicilios de Punto de Entrega"
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
        Me.GridDomicilios.Location = New System.Drawing.Point(7, 15)
        Me.GridDomicilios.Name = "GridDomicilios"
        Me.GridDomicilios.RecordNavigator = True
        Me.GridDomicilios.Size = New System.Drawing.Size(741, 118)
        Me.GridDomicilios.TabIndex = 1
        Me.GridDomicilios.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabSaldos
        '
        Me.UiTabSaldos.Controls.Add(Me.GrpSaldos)
        Me.UiTabSaldos.Location = New System.Drawing.Point(1, 21)
        Me.UiTabSaldos.Name = "UiTabSaldos"
        Me.UiTabSaldos.Size = New System.Drawing.Size(771, 482)
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
        Me.GrpSaldos.Size = New System.Drawing.Size(754, 468)
        Me.GrpSaldos.TabIndex = 10
        Me.GrpSaldos.TabStop = False
        Me.GrpSaldos.Text = "Saldos de Facturas"
        '
        'LblSaldo
        '
        Me.LblSaldo.Location = New System.Drawing.Point(327, 18)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(80, 15)
        Me.LblSaldo.TabIndex = 61
        Me.LblSaldo.Text = "Total Saldo"
        '
        'NumSaldo
        '
        Me.NumSaldo.Location = New System.Drawing.Point(413, 13)
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
        Me.LblCredito.Size = New System.Drawing.Size(98, 15)
        Me.LblCredito.TabIndex = 59
        Me.LblCredito.Text = "Crédito Disponible"
        '
        'NumDisponible
        '
        Me.NumDisponible.Location = New System.Drawing.Point(119, 13)
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
        Me.GridSaldos.Size = New System.Drawing.Size(728, 415)
        Me.GridSaldos.TabIndex = 2
        Me.GridSaldos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabMetodo
        '
        Me.UiTabMetodo.Controls.Add(Me.GrpMetodos)
        Me.UiTabMetodo.Location = New System.Drawing.Point(1, 21)
        Me.UiTabMetodo.Name = "UiTabMetodo"
        Me.UiTabMetodo.Size = New System.Drawing.Size(771, 482)
        Me.UiTabMetodo.TabStop = True
        Me.UiTabMetodo.Text = "Metodo de Pago"
        '
        'GrpMetodos
        '
        Me.GrpMetodos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpMetodos.BackColor = System.Drawing.Color.Transparent
        Me.GrpMetodos.Controls.Add(Me.BtnAgregar)
        Me.GrpMetodos.Controls.Add(Me.GridMetodos)
        Me.GrpMetodos.Controls.Add(Me.BtnElimina)
        Me.GrpMetodos.Controls.Add(Me.BtnModifica)
        Me.GrpMetodos.Location = New System.Drawing.Point(2, 3)
        Me.GrpMetodos.Name = "GrpMetodos"
        Me.GrpMetodos.Size = New System.Drawing.Size(764, 476)
        Me.GrpMetodos.TabIndex = 5
        Me.GrpMetodos.TabStop = False
        Me.GrpMetodos.Text = "Metodos Preferidos de Pago"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(732, 15)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(30, 30)
        Me.BtnAgregar.TabIndex = 2
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
        Me.GridMetodos.Location = New System.Drawing.Point(7, 51)
        Me.GridMetodos.Name = "GridMetodos"
        Me.GridMetodos.RecordNavigator = True
        Me.GridMetodos.Size = New System.Drawing.Size(755, 418)
        Me.GridMetodos.TabIndex = 1
        Me.GridMetodos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnElimina
        '
        Me.BtnElimina.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnElimina.Image = CType(resources.GetObject("BtnElimina.Image"), System.Drawing.Image)
        Me.BtnElimina.Location = New System.Drawing.Point(660, 15)
        Me.BtnElimina.Name = "BtnElimina"
        Me.BtnElimina.Size = New System.Drawing.Size(30, 30)
        Me.BtnElimina.TabIndex = 4
        Me.BtnElimina.ToolTipText = "Elimina el Metodo de Pago seleccionada"
        Me.BtnElimina.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModifica
        '
        Me.BtnModifica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModifica.Image = CType(resources.GetObject("BtnModifica.Image"), System.Drawing.Image)
        Me.BtnModifica.Location = New System.Drawing.Point(696, 15)
        Me.BtnModifica.Name = "BtnModifica"
        Me.BtnModifica.Size = New System.Drawing.Size(30, 30)
        Me.BtnModifica.TabIndex = 3
        Me.BtnModifica.ToolTipText = "Modifica el Metodo de Pago seleccionada"
        Me.BtnModifica.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTabClasificaciones
        '
        Me.UiTabClasificaciones.Controls.Add(Me.GrpClasificaciones)
        Me.UiTabClasificaciones.Location = New System.Drawing.Point(1, 21)
        Me.UiTabClasificaciones.Name = "UiTabClasificaciones"
        Me.UiTabClasificaciones.Size = New System.Drawing.Size(771, 482)
        Me.UiTabClasificaciones.TabStop = True
        Me.UiTabClasificaciones.Text = "Clasificaciones"
        '
        'GrpClasificaciones
        '
        Me.GrpClasificaciones.BackColor = System.Drawing.Color.Transparent
        Me.GrpClasificaciones.Controls.Add(Me.BtnBuscaClasificacion)
        Me.GrpClasificaciones.Controls.Add(Me.TxtClasificacion)
        Me.GrpClasificaciones.Controls.Add(Me.LblReferencia)
        Me.GrpClasificaciones.Controls.Add(Me.btnDelClasificacion)
        Me.GrpClasificaciones.Controls.Add(Me.GridClasificaciones)
        Me.GrpClasificaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpClasificaciones.Location = New System.Drawing.Point(0, 0)
        Me.GrpClasificaciones.Name = "GrpClasificaciones"
        Me.GrpClasificaciones.Size = New System.Drawing.Size(771, 482)
        Me.GrpClasificaciones.TabIndex = 12
        Me.GrpClasificaciones.TabStop = False
        Me.GrpClasificaciones.Text = "Clasificaciones de Cliente"
        '
        'BtnBuscaClasificacion
        '
        Me.BtnBuscaClasificacion.Image = CType(resources.GetObject("BtnBuscaClasificacion.Image"), System.Drawing.Image)
        Me.BtnBuscaClasificacion.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaClasificacion.Location = New System.Drawing.Point(248, 22)
        Me.BtnBuscaClasificacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscaClasificacion.Name = "BtnBuscaClasificacion"
        Me.BtnBuscaClasificacion.Size = New System.Drawing.Size(30, 30)
        Me.BtnBuscaClasificacion.TabIndex = 133
        Me.BtnBuscaClasificacion.ToolTipText = "Busqueda de clasificaciones"
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
        Me.btnDelClasificacion.Size = New System.Drawing.Size(30, 30)
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
        Me.GridClasificaciones.Size = New System.Drawing.Size(749, 420)
        Me.GridClasificaciones.TabIndex = 4
        Me.GridClasificaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabCredito
        '
        Me.UiTabCredito.Controls.Add(Me.GrpClase)
        Me.UiTabCredito.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCredito.Name = "UiTabCredito"
        Me.UiTabCredito.Size = New System.Drawing.Size(771, 482)
        Me.UiTabCredito.TabStop = True
        Me.UiTabCredito.Text = "Gestión de Crédito"
        '
        'GrpClase
        '
        Me.GrpClase.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpClase.BackColor = System.Drawing.Color.Transparent
        Me.GrpClase.Controls.Add(Me.btnAddClase)
        Me.GrpClase.Controls.Add(Me.GridClases)
        Me.GrpClase.Controls.Add(Me.btnDelClase)
        Me.GrpClase.Location = New System.Drawing.Point(10, 12)
        Me.GrpClase.Name = "GrpClase"
        Me.GrpClase.Size = New System.Drawing.Size(747, 457)
        Me.GrpClase.TabIndex = 104
        Me.GrpClase.TabStop = False
        Me.GrpClase.Text = "Clases de Riesgo"
        '
        'btnAddClase
        '
        Me.btnAddClase.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddClase.Icon = CType(resources.GetObject("btnAddClase.Icon"), System.Drawing.Icon)
        Me.btnAddClase.Location = New System.Drawing.Point(712, 7)
        Me.btnAddClase.Name = "btnAddClase"
        Me.btnAddClase.Size = New System.Drawing.Size(30, 30)
        Me.btnAddClase.TabIndex = 106
        Me.btnAddClase.ToolTipText = "Agregar nueva clase de riesgo"
        Me.btnAddClase.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
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
        Me.GridClases.Location = New System.Drawing.Point(7, 43)
        Me.GridClases.Name = "GridClases"
        Me.GridClases.RecordNavigator = True
        Me.GridClases.Size = New System.Drawing.Size(735, 407)
        Me.GridClases.TabIndex = 1
        Me.GridClases.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnDelClase
        '
        Me.btnDelClase.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelClase.Icon = CType(resources.GetObject("btnDelClase.Icon"), System.Drawing.Icon)
        Me.btnDelClase.Location = New System.Drawing.Point(676, 7)
        Me.btnDelClase.Name = "btnDelClase"
        Me.btnDelClase.Size = New System.Drawing.Size(30, 30)
        Me.btnDelClase.TabIndex = 105
        Me.btnDelClase.ToolTipText = "Eliminar clase de riesgo seleccionada"
        Me.btnDelClase.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(593, 520)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(689, 520)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmCliente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.UiTabGestion)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 432)
        Me.Name = "FrmCliente"
        Me.Text = "Clientes"
        CType(Me.UiTabGestion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabGestion.ResumeLayout(False)
        Me.UiTabCliente.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.grpAccesoWeb.ResumeLayout(False)
        Me.grpAccesoWeb.PerformLayout()
        CType(Me.PictureBox31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox32, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDescuentos.ResumeLayout(False)
        CType(Me.PictureBox27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox26, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDomicilioFiscal.ResumeLayout(False)
        Me.GrpDomicilioFiscal.PerformLayout()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        CType(Me.PictureBox30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox29, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.GrpContacto.ResumeLayout(False)
        Me.GrpContacto.PerformLayout()
        CType(Me.PictureBox37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox34, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabCanal.ResumeLayout(False)
        Me.grpCanales.ResumeLayout(False)
        CType(Me.gridCanales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabDomicilio.ResumeLayout(False)
        Me.GrpDomicilio.ResumeLayout(False)
        Me.GrpDomicilio.PerformLayout()
        CType(Me.PictureBox33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDomicilios.ResumeLayout(False)
        CType(Me.GridDomicilios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabSaldos.ResumeLayout(False)
        Me.GrpSaldos.ResumeLayout(False)
        Me.GrpSaldos.PerformLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabMetodo.ResumeLayout(False)
        Me.GrpMetodos.ResumeLayout(False)
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabClasificaciones.ResumeLayout(False)
        Me.GrpClasificaciones.ResumeLayout(False)
        Me.GrpClasificaciones.PerformLayout()
        CType(Me.GridClasificaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabCredito.ResumeLayout(False)
        Me.GrpClase.ResumeLayout(False)
        CType(Me.GridClases, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Publicas"
    Public numMostrador As Integer
    Public CambiarCliente As Boolean = True
    Public Padre As String
    Public TipoOrigen As Integer = 1
    Public RegFiscal As String = ""
    Public ClienteSAP As String = ""
    Public CTEClave As String = ""
    Public DCTEClaveFiscal As String = ""
    Public Clave As String = ""
    Public FechaReg As Date = DateTime.Today
    Public NombreCorto As String = ""
    Public RazonSocial As String = ""
    Public TPersona As Integer
    Public RFC As String = ""
    Public CURP As String = ""
    Public LCredito As Double
    Public Saldo As Double
    Public Contacto As String = ""
    Public fechaNacimiento As Date = DateTime.Today
    Public Genero As Integer = 0
    Public tipoTel1 As Integer = 1
    Public tipoTel2 As Integer = 1
    Public Tel1 As String = ""
    Public Tel2 As String = ""
    Public email As String = ""
    Public Estado As Integer = 1
    Public CreditoDisponible As Double
    Public TDomicilio As Integer
    Public Pais As String
    Public Entidad As String = ""
    Public Mnpio As String = ""
    Public Colonia As String = ""
    Public Localidad As String = ""
    Public codigoPostal As String = ""
    Public referencia As String = ""
    Public noInterior As String = ""
    Public noExterior As String = ""
    Public GLN As String = ""
    Public ZonaVenta As Integer
    Public ZonaReparto As Integer

    Public TipoImpuesto As Integer = 1
    Public TImpuesto As Integer = 1

    Public ClavePE As String = ""
    Public Nombre As String = ""
    Public Consignatario As String = ""
    Public TelDomicilio As String = ""
    Public PaisF As String
    Public EntidadF As String = ""
    Public MnpioF As String = ""
    Public ColoniaF As String = ""
    Public CalleF As String = ""
    Public LocalidadF As String = ""
    Public codigoPostalF As String = ""
    Public referenciaF As String = ""
    Public noInteriorF As String = ""
    Public noExteriorF As String = ""
    Public ZonaVentaF As Integer
    Public ZonaRepartoF As Integer

    Public listaPrecio As String = ""
    Public DiasCredito As Integer
    Public DesglosaIVA As Boolean = False
    Public ImprimirFac As Boolean = True
    Public Facturable As Boolean = True

    Public CtaContable As String = ""
    Public fromForm As String = ""
    Public ClienteInicial As String = ""

    Public Alterno As String = ""
    Public Responsable As Integer
    Public TipoCanal As Integer
    Public Ramo As Integer

    Public DescuentoDirecto As Double
    Public DescuentoPostVenta As Double

    Public Vendedor As String = ""
    Public UsoCFDI As String = "G03"

    Public CtaMaestra As String = ""
    Public AccesoWeb As Boolean = False
    Private Password As String = ""

#End Region

#Region "Variables Privadas"

    Private TallaColor As Integer = 0
    Private InterfazSalida As String = ""

    Private sMailCliente, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP As String
    Private MailPort As Integer
    Private MailSSL As Boolean

    Private cpyCtaMaestra As String

    Private aEstado() As String
    Private aMnpio() As String
    Private aColonia() As String

    Private DCTEClave As String = ""
    Private sDomicilio As String = ""
    Private DomicilioPadre As String = "Agregar"

    Private Cnx As String
    Private alerta(36) As PictureBox
    Private reloj As parpadea

    Private guardado As Boolean = False
    Private cargado As Boolean = False

    Private dLimite As Double
    Private iDias As Integer

    Private DomicilioEstado As Integer
    Private Calle As String = ""

    Private dtMetodosPago As DataTable
    Private sMetodoPago As String
    Private sTipoMetodo, sBanco, sReferencia, sGestionSelected, sCanalSelected As String

    Private MaxCredito As Double = 0
    Private CambiaLista As Integer

    Private dtDomicilios, dtClasificaciones, dtDirecto, dtPostVenta, dtClase, dtRiesgo, dtCanal, dtTipoCanal, dtLista As DataTable
    Private bDomicilio As Boolean = False
    Private bGeografia As Boolean = False
    Private MaskCte As Integer = 0


#End Region

#Region "Cliente"

    Private Sub recuperaCtaMaestra(ByVal sCta As String, ByVal Inicial As Boolean)
        Dim dt As DataTable
        Dim NIP As String
        Dim sCtaMst As String
        Dim AccesoCorrecto As Boolean = True

        dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", sCta)
        NIP = IIf(dt.Rows(0)("Password").GetType.Name = "DBNull", "", dt.Rows(0)("Password"))
        sCtaMst = dt.Rows(0)("Clave")
        dt.Dispose()

        If Inicial = False AndAlso TallaColor = 1 AndAlso NIP <> "" AndAlso fromForm <> "" Then
            ' Solicita Pin 
            Dim b As New FrmNIP
            b.CTEClave = sCtaMst
            b.ShowDialog()
            If b.DialogResult = DialogResult.OK Then
                AccesoCorrecto = b.Acceso
            End If
            b.Dispose()
        End If

        If AccesoCorrecto = True Then
            txtCtaMaestra.Text = sCtaMst
            cpyCtaMaestra = sCta
        Else
            MessageBox.Show("No se obtuvo la confirmación del concentimiento del cliente para esta acción", "Error", MessageBoxButtons.OK)
        End If

    End Sub


    Private Sub bloquearCondiciones()
        CmbTipo.Enabled = False
        TxtLimite.Enabled = False
        TxtDiasCredito.Enabled = False
        cmbTipoCanal.Enabled = False
        cmbListaPrecio.Enabled = False
        cmbResponsable.Enabled = False
        TxtCtaContable.Enabled = False
        cmbDirecto.Enabled = False
        cmbPostVenta.Enabled = False
        btnDirecto.Enabled = False
        btnPostventa.Enabled = False
        GrpClase.Enabled = False
        grpCanales.Enabled = False
        grpAccesoWeb.Enabled = False
    End Sub

    Private Sub recuperaCondiciones(ByVal sCTEClave As String)
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", sCTEClave)

        TPersona = dt.Rows(0)("TPersona")
        TipoImpuesto = dt.Rows(0)("TipoImpuesto")
        LCredito = dt.Rows(0)("LimiteCredito")
        DiasCredito = dt.Rows(0)("DiasCredito")
        TipoCanal = IIf(dt.Rows(0)("TipoCanal").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoCanal"))
        listaPrecio = dt.Rows(0)("PREClave")
        DesglosaIVA = dt.Rows(0)("DesglosaIVA")
        ImprimirFac = IIf(dt.Rows(0)("ImprimirFac").GetType.Name = "DBNull", True, dt.Rows(0)("ImprimirFac"))
        Facturable = IIf(dt.Rows(0)("facturable").GetType.Name = "DBNull", True, dt.Rows(0)("facturable"))

        PaisF = dt.Rows(0)("Pais")
        Responsable = IIf(dt.Rows(0)("Responsable").GetType.Name = "DBNull", 0, dt.Rows(0)("Responsable"))
        CtaContable = IIf(dt.Rows(0)("CtaContable").GetType.Name = "DBNull", "", dt.Rows(0)("CtaContable"))


        DescuentoDirecto = IIf(dt.Rows(0)("DescuentoDirecto").GetType.Name = "DBNull", -1, dt.Rows(0)("DescuentoDirecto"))
        DescuentoPostVenta = IIf(dt.Rows(0)("DescuentoPostVenta").GetType.Name = "DBNull", -1, dt.Rows(0)("DescuentoPostVenta"))
        ClienteSAP = IIf(dt.Rows(0)("ClienteSAP").GetType.Name = "DBNull", "", dt.Rows(0)("ClienteSAP"))
        UsoCFDI = IIf(dt.Rows(0)("UsoCFDI").GetType.Name = "DBNull", "G03", dt.Rows(0)("UsoCFDI"))

        dt.Dispose()

        CmbTipoPersona.SelectedValue = TPersona
        CmbTipo.SelectedValue = TipoImpuesto
        TxtLimite.Text = CStr(LCredito)
        TxtDiasCredito.Text = CInt(DiasCredito)
        cmbTipoCanal.SelectedValue = TipoCanal
        cmbListaPrecio.SelectedValue = listaPrecio
        ChkDesglosarIVA.Checked = DesglosaIVA
        chkImpresion.Checked = ImprimirFac
        chkFacturable.Checked = Facturable
        CmbPaisFac.Text = PaisF
        cmbResponsable.SelectedValue = Responsable
        TxtCtaContable.Text = CtaContable

        cmbDirecto.SelectedValue = DescuentoDirecto
        cmbPostVenta.SelectedValue = DescuentoPostVenta
        cmbUsoCFDI.SelectedValue = UsoCFDI

        bloquearCondiciones()

        dtPostVenta = ModPOS.Recupera_Tabla("sp_muestra_descuentopostventa", "@CTEClave", sCTEClave, "@Update", 1)
        dtDirecto = ModPOS.Recupera_Tabla("sp_muestra_descuentodirecto", "@CTEClave", sCTEClave, "@Update", 1)

        cargaCanales(True, sCTEClave)

        dt = ModPOS.Recupera_Tabla("st_muestra_riesgo", "@CTEClave", sCTEClave)

        If dt.Rows.Count > 0 Then
            Dim row1 As DataRow
            row1 = dtClase.NewRow()
            'Valor,Descripcion,Orden,0 as Modificado,Baja 
            row1.Item("Riesgo") = dt.Rows(0)("Riesgo")
            row1.Item("TotalComprometido") = 0.0
            row1.Item("TotalVencido") = 0.0
            row1.Item("Bloqueado") = 0
            row1.Item("Verificación") = Today.Date
            row1.Item("Demora") = 0
            row1.Item("Modificado") = 0
            row1.Item("Baja") = 0
            dtClase.Rows.Add(row1)
        End If
        dt.Dispose()



    End Sub


    Public Sub AddMetodoPago(ByVal sMTPClave As String, ByVal iMetodoPago As Integer, ByVal sTipo As String, ByVal sBancoClave As String, ByVal sBancoNombre As String, ByVal sRef As String, ByVal iPreferido As Integer, ByVal iTipoEstado As Integer)

        Dim foundRows() As Data.DataRow
        foundRows = dtMetodosPago.Select("MTPClave Like '" & sMTPClave & "' and Baja = 0")

        If foundRows.Length = 0 Then

            foundRows = dtMetodosPago.Select("MetodoPago = " & iMetodoPago & " and Referencia like '" & sRef & "' and BNKClave like '" & sBancoClave & "' and Baja = 0")
            If foundRows.Length = 0 Then

                Dim row1 As DataRow
                row1 = dtMetodosPago.NewRow()
                'declara el nombre de la fila

                row1.Item("MTPClave") = sMTPClave
                row1.Item("MetodoPago") = iMetodoPago
                row1.Item("Tipo") = sTipo
                row1.Item("BNKClave") = sBancoClave
                row1.Item("Banco") = sBancoNombre
                row1.Item("Referencia") = sRef
                row1.Item("TipoEstado") = iTipoEstado
                row1.Item("Estado") = IIf(iTipoEstado = 1, "Activo", "Inactivo")
                row1.Item("Preferido") = iPreferido
                row1.Item("update") = 1
                row1.Item("Baja") = 0

                dtMetodosPago.Rows.Add(row1)
                'agrega la fila completo a la tabla

            Else
                Beep()
                MessageBox.Show("¡La referencia de Metodo de Pago que intenta agregar ya existe para el cliente actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Else
            foundRows(0)("Referencia") = sRef
            foundRows(0)("Estado") = IIf(iTipoEstado = 1, "Activo", "Inactivo")
            foundRows(0)("TipoEstado") = iTipoEstado
            foundRows(0)("Preferido") = iPreferido
            foundRows(0)("update") = 1
        End If
    End Sub

    Private Sub cargaMetodosPago()
        If Padre = "Agregar" Then

            dtMetodosPago = ModPOS.CrearTabla("ClientePago", _
            "MTPClave", "System.String", _
            "MetodoPago", "System.Int32", _
            "Tipo", "System.String", _
            "BNKClave", "System.String", _
            "Banco", "System.String", _
            "Referencia", "System.String", _
            "TipoEstado", "System.Int32", _
            "Estado", "System.String", _
            "Preferido", "System.Boolean", _
            "update", "System.Int32", _
            "Baja", "System.Int32")
        Else
            dtMetodosPago = ModPOS.Recupera_Tabla("sp_recupera_clientepago", "@CTEClave", CTEClave)
        End If


        With Me.GridMetodos
            .DataSource = dtMetodosPago
            .RetrieveStructure(True)
            .GroupByBoxVisible = False
            .RootTable.Columns("MTPClave").Visible = False
            .RootTable.Columns("MetodoPago").Visible = False
            .RootTable.Columns("BNKClave").Visible = False
            .RootTable.Columns("TipoEstado").Visible = False
            .RootTable.Columns("Update").Visible = False
            .RootTable.Columns("Baja").Visible = False

            .CurrentTable.Columns("Preferido").Selectable = False
            .CurrentTable.Columns("Tipo").Selectable = False
            .CurrentTable.Columns("Banco").Selectable = False
            .CurrentTable.Columns("Referencia").Selectable = False
            .CurrentTable.Columns("Estado").Selectable = False

            Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
            fc = New Janus.Windows.GridEX.GridEXFormatCondition(.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

            fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
            fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
            .RootTable.FormatConditions.Add(fc)


            Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
            fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(.RootTable.Columns("TipoEstado"), Janus.Windows.GridEX.ConditionOperator.Equal, 0)

            fc1.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
            .RootTable.FormatConditions.Add(fc1)

        End With


    End Sub


 
    Private Sub FrmCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.BringToFront()

        Dim dtParam As DataTable
        Dim i As Integer

        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
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
                    Case "Domicilio"
                        bDomicilio = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", False, dtParam.Rows(i)("Valor"))
                    Case "Geografia"
                        bGeografia = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", False, dtParam.Rows(i)("Valor"))
                    Case "MascaraCte"
                        MaskCte = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))

                    Case "InterfazSalida"
                        InterfazSalida = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                    Case "TallaColor"
                        TallaColor = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))

                End Select
            Next
        End With
        dtParam.Dispose()



        If Padre <> "Agregar" Then
            dtParam = ModPOS.Recupera_Tabla("st_recupera_pass_cte", "@CTEClave", CTEClave, "@Pass", "Duxst4r.")
            Password = formateaNIP(dtParam.Rows(0)("Password"))
            dtParam.Dispose()
        Else
            CTEClave = ModPOS.obtenerLlave
        End If



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

        alerta(25) = Me.PictureBox26
        alerta(26) = Me.PictureBox27

        alerta(27) = Me.PictureBox29
        alerta(28) = Me.PictureBox30
        alerta(33) = Me.PictureBox34

        alerta(34) = Me.PictureBox35
        alerta(35) = Me.PictureBox36
        alerta(36) = Me.PictureBox37

        'Domicilio Fiscal
        alerta(10) = Me.PictureBox11
        alerta(11) = Me.PictureBox12
        alerta(12) = Me.PictureBox13
        alerta(13) = Me.PictureBox14
        alerta(14) = Me.PictureBox15
        alerta(15) = Me.PictureBox16
        alerta(16) = Me.PictureBox17


        'Domicilio Entrega
        alerta(17) = Me.PictureBox18
        alerta(18) = Me.PictureBox19
        alerta(19) = Me.PictureBox20
        alerta(20) = Me.PictureBox21
        alerta(21) = Me.PictureBox22
        alerta(22) = Me.PictureBox23
        alerta(23) = Me.PictureBox24
        alerta(24) = Me.PictureBox25
        alerta(29) = Me.PictureBox28
        alerta(30) = Me.PictureBox31
        alerta(31) = Me.PictureBox32
        alerta(32) = Me.PictureBox33

        Cnx = ModPOS.BDConexion

        With cmbUsoCFDI
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_filtra_UsoCFDI"
            .NombreParametro1 = "Grupo"
            .Parametro1 = 1
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

        With Me.CmbTipo
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Impuesto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With Me.cmbTipoImpuesto
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Impuesto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        dtTipoCanal = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "Cliente", "@Campo", "TipoCanal")

        With cmbTipoCanal
            .dt = dtTipoCanal
            '.Conexion = ModPOS.BDConexion
            '.ProcedimientoAlmacenado = "sp_filtra_valorref"
            '.NombreParametro1 = "tabla"
            '.Parametro1 = "Cliente"
            '.NombreParametro2 = "campo"
            '.Parametro2 = "TipoCanal"
            .llenar()
        End With

        With cmbTipoCanal2
            .dt = dtTipoCanal
            .llenar()
        End With



        With cmbResponsable
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "Responsable"
            .llenar()
        End With

        With cmbRamo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "Ramo"
            .llenar()
        End With

        With Me.cmbListaPrecio
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_listas_canal"
            .NombreParametro1 = "TipoCanal"
            .Parametro1 = cmbTipoCanal.SelectedValue
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .NombreParametro3 = "Responsable"
            .Parametro3 = cmbResponsable.SelectedValue
            .llenar()
        End With


        With Me.cmbListaPrecio2
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "st_listas_canal"
            .NombreParametro1 = "TipoCanal"
            .Parametro1 = cmbTipoCanal2.SelectedValue
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        dtLista = ModPOS.Recupera_Tabla("st_listas_canal", "@TipoCanal", 0, "@COMClave", ModPOS.CompanyActual)


        With Me.cmbPais
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Geografia"
            .NombreParametro2 = "campo"
            .Parametro2 = "Pais"
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

        With cmbZonaVenta
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "ZonaVenta"
            .llenar()
        End With

        With cmbZonaReparto
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref_concat"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "ZonaReparto"
            .llenar()
        End With


        With cmbZonaVtap
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "ZonaVenta"
            .llenar()
        End With

        With cmbZonaRep
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref_concat"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "ZonaReparto"
            .llenar()
        End With

        With cmbDirecto
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "DescuentoDirecto"
            .llenar()
        End With

        With cmbPostVenta
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "DescuentoPostVenta"
            .llenar()
        End With

        With Me.cmbVendedor
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "st_recupera_usr_vendedor"
            .llenar()
        End With


        With cmbGenero
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "Campo"
            .Parametro2 = "Genero"
            .llenar()
        End With

        With cmbTipoTel1
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "Campo"
            .Parametro2 = "TipoTelefono"
            .llenar()
        End With

        With cmbTipoTel2
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "Campo"
            .Parametro2 = "TipoTelefono"
            .llenar()
        End With

        Dim dtEstado As DataTable

        dtEstado = ModPOS.Recupera_Tabla("sp_filtra_estado", "@Pais", CmbPaisFac.SelectedValue)
        If dtEstado.Rows.Count > 0 Then
            ReDim aEstado(dtEstado.Rows.Count - 1)

            For i = 0 To dtEstado.Rows.Count - 1
                aEstado(i) = dtEstado.Rows(i)("d_estado")
            Next

            Me.TxtEstadoFac.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Me.TxtEstadoFac.AutoCompleteSource = AutoCompleteSource.CustomSource
            Me.TxtEstadoFac.AutoCompleteCustomSource.AddRange(aEstado)


            Me.TxtEstado.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Me.TxtEstado.AutoCompleteSource = AutoCompleteSource.CustomSource
            Me.TxtEstado.AutoCompleteCustomSource.AddRange(aEstado)

            dtEstado.Dispose()
        End If




        cargado = True

        CmbTipoPersona.SelectedValue = TPersona
        cmbOrigen.SelectedItem = IIf(TipoOrigen = 1, "Nacional", "Extrajero")
        TxtRegFiscal.Text = RegFiscal
        TxtClave.Text = Clave
        TxtNombreCorto.Text = NombreCorto
        TxtRazonSocial.Text = RazonSocial
        TxtRFC.Text = RFC
        TxtCURP.Text = CURP
        cmbResponsable.SelectedValue = Responsable
        cmbTipoCanal.SelectedValue = TipoCanal
        cmbListaPrecio.SelectedValue = listaPrecio
        TxtCtaContable.Text = CtaContable
        TxtFechaRegistro.Text = FechaReg.ToString("MMMM dd,yyyy")
        ChkEstado.Estado = Estado
        txtAlterno.Text = Alterno
        TxtGLN.Text = GLN
        cmbRamo.SelectedValue = Ramo
        ChkDesglosarIVA.Checked = DesglosaIVA
        chkImpresion.Checked = ImprimirFac
        chkFacturable.Checked = Facturable

        CmbTipo.SelectedValue = TipoImpuesto

        cmbTipoImpuesto.SelectedValue = TImpuesto
        TxtLimite.Text = CStr(LCredito)
        TxtDiasCredito.Text = CInt(DiasCredito)

        CmbPaisFac.Text = PaisF
        TxtEstadoFac.Text = EntidadF
        TxtMunicipioFac.Text = MnpioF
        TxtColoniaFac.Text = ColoniaF
        TxtLocalidadFac.Text = LocalidadF
        TxtDomicilioFac.Text = CalleF
        TxtCodigoPostalFac.Text = codigoPostalF
        TxtNoInteriorFac.Text = noInteriorF
        TxtNoExteriorFac.Text = noExteriorF
        TxtReferenciaFac.Text = referenciaF
        cmbZonaVenta.SelectedValue = ZonaVentaF
        cmbZonaReparto.SelectedValue = ZonaRepartoF
        cmbVendedor.SelectedValue = Vendedor

        cmbDirecto.SelectedValue = DescuentoDirecto
        cmbPostVenta.SelectedValue = DescuentoPostVenta

        TxtContacto.Text = Contacto
        TxtTel1.Text = Tel1
        TxtTel2.Text = Tel2
        TxtMail.Text = email

        NumSaldo.Text = CStr(Saldo)
        NumDisponible.Text = CStr(CreditoDisponible)

        ChkAccesoWeb.Checked = AccesoWeb
        TxtContraseña.Text = Password
        TxtConfirmar.Text = TxtContraseña.Text

        txtSAP.Text = ClienteSAP

        cmbFechaNacimiento.Value = fechaNacimiento
        cmbGenero.SelectedValue = Genero
        cmbTipoTel1.SelectedValue = tipoTel1
        cmbTipoTel2.SelectedValue = tipoTel2

        If Padre = "Modificar" Then
            recuperaCtaMaestra(CtaMaestra, True)
            BtnKey.Enabled = False
        End If

        Dim dtMnpio As DataTable
        dtMnpio = ModPOS.Recupera_Tabla("sp_recupera_mnpio", "@Estado", TxtEstadoFac.Text.Trim.ToUpper)
        If dtMnpio.Rows.Count > 0 Then
            ReDim aMnpio(dtMnpio.Rows.Count - 1)
            For i = 0 To dtMnpio.Rows.Count - 1
                aMnpio(i) = dtMnpio.Rows(i)("d_mnpio")
            Next
            Me.TxtMunicipioFac.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Me.TxtMunicipioFac.AutoCompleteSource = AutoCompleteSource.CustomSource
            Me.TxtMunicipioFac.AutoCompleteCustomSource.AddRange(aMnpio)
            dtMnpio.Dispose()
        End If

        Dim dtColonia As DataTable
        dtColonia = ModPOS.Recupera_Tabla("sp_recupera_colonia", "@Estado", TxtEstadoFac.Text.ToUpper.Trim, "@Municipio", TxtMunicipioFac.Text.Trim.ToUpper)
        If dtColonia.Rows.Count > 0 Then
            ReDim aColonia(dtColonia.Rows.Count - 1)
            For i = 0 To dtColonia.Rows.Count - 1
                aColonia(i) = dtColonia.Rows(i)("Nombre")
            Next
            Me.TxtColoniaFac.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Me.TxtColoniaFac.AutoCompleteSource = AutoCompleteSource.CustomSource
            Me.TxtColoniaFac.AutoCompleteCustomSource.AddRange(aColonia)
            dtColonia.Dispose()
        End If

        cargaCanales()

        cargaPuntosdeEntrega()

        cargaMetodosPago()

        cargaClasificaciones()

        cargaDirecto()

        cargaPostVenta()

        cargaRiesgo()

        Dim dtUsuario As DataTable

        dtUsuario = Recupera_Tabla("sp_recupera_usuarioActual", "@Usuario", ModPOS.UsuarioActual)
        MaxCredito = IIf(dtUsuario.Rows(0)("MaxCredito").GetType.FullName = "System.DBNull", 0, dtUsuario.Rows(0)("MaxCredito"))
        CambiaLista = IIf(dtUsuario.Rows(0)("CambiaLista").GetType.FullName = "System.DBNull", 0, dtUsuario.Rows(0)("CambiaLista"))
        dtUsuario.Dispose()


        If MaxCredito = 0 OrElse Me.LCredito > MaxCredito Then
            TxtLimite.Enabled = False
            TxtDiasCredito.Enabled = False
        End If

        If CambiaLista = 0 Then
            cmbListaPrecio.Enabled = False
        End If

        cmbUsoCFDI.SelectedValue = UsoCFDI

       
        If fromForm <> "" Then
            bloquearCondiciones()
        End If


        If Padre = "Agregar" AndAlso TallaColor = 1 Then
            ChkAccesoWeb.Checked = True
        End If

        If Padre = "Agregar" AndAlso ClienteInicial <> "" Then
            recuperaCondiciones(ClienteInicial)
        ElseIf CambiarCliente = False Then
            GrpCliente.Enabled = False
            GrpDomicilioFiscal.Enabled = False
            GrpClase.Enabled = False
            cmbDirecto.Enabled = False
            cmbPostVenta.Enabled = False
            GrpContacto.Enabled = False
            GrpMetodos.Enabled = False
        Else
            If ClienteSAP <> "" AndAlso ClienteSAP = Clave Then
                GrpCliente.Enabled = False
                GrpDomicilioFiscal.Enabled = False
                GrpClase.Enabled = False
                cmbDirecto.Enabled = False
                cmbPostVenta.Enabled = False
                GrpContacto.Enabled = False
                GrpMetodos.Enabled = False
            End If
        End If

        If TallaColor = 1 Then
            TxtLimite.Enabled = False
            TxtDiasCredito.Enabled = False
        End If
    End Sub

    Private Sub FrmCliente_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoCliente Is Nothing Then
            ModPOS.MtoCliente.actGrid(ModPOS.MtoCliente.ultimo_tag)
            If Padre = "Agregar" Then
                ModPOS.MtoCliente.actualizaTree(IIf(ModPOS.MtoCliente.cmbGrupo.SelectedValue Is Nothing, 0, ModPOS.MtoCliente.cmbGrupo.SelectedValue))
            End If
        End If
        ModPOS.Cliente.Dispose()
        ModPOS.Cliente = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub



    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        If Padre = "Agregar" Then
            If TxtRFC.Text = "" Then
                If cmbOrigen.SelectedItem Is Nothing OrElse cmbOrigen.SelectedItem = "Nacional" Then
                    TxtRFC.Text = "XAXX010101000"
                Else
                    TxtRFC.Text = "XEXX010101000"
                End If
                CmbTipoPersona.SelectedValue = 1
            End If

            If TxtClave.Text = "" Then
                BtnKey.PerformClick()
            End If

            If TxtContacto.Text = "" AndAlso (Not CmbTipoPersona.SelectedValue Is Nothing) Then
                If CmbTipoPersona.SelectedValue = 1 Then
                    TxtContacto.Text = TxtRazonSocial.Text
                End If
            End If

            If TallaColor = 1 AndAlso TxtRFC.Text <> "XAXX010101000" AndAlso TxtRFC.Text <> "XEXX010101000" Then
                chkFacturable.Checked = True
            End If

        End If

        If validaForm() Then



            Dim bGeneraInterfaz As Boolean = False

            If chkFacturable.Checked = True Then
                If Padre = "Agregar" OrElse Facturable <> chkFacturable.Checked Then
                    bGeneraInterfaz = True
                End If
            End If

            Dim auxCTEClave As String
            Dim foundRows() As System.Data.DataRow

            If Me.GridMetodos.RecordCount > 0 Then
                foundRows = dtMetodosPago.Select(" Preferido = 1 and Baja = 0 ")

                If foundRows.Length > 1 Then
                    Beep()
                    MessageBox.Show("Debe detener solo un Metodo de Pago marcado como Preferido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            End If

            If cmbUsoCFDI.SelectedValue Is Nothing Then
                cmbUsoCFDI.SelectedValue = "G03"
            End If

            Select Case Me.Padre
                Case "Agregar"


                    If MaxCredito < dLimite Then
                        Beep()
                        MessageBox.Show("El limite de crédito que intenta otorgar excede el rango permitido para el usuario actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If

                    If TxtMail.Text <> "" Then
                        If IsValidEmail(TxtMail.Text) = False Then
                            MessageBox.Show("El formato del correo electronico no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If



                    auxCTEClave = CTEClave
                    If txtCtaMaestra.Text = "" Then
                        CtaMaestra = CTEClave
                    End If

                    TipoOrigen = IIf(cmbOrigen.SelectedItem = "Nacional", 1, 2)
                    RegFiscal = TxtRegFiscal.Text

                    TPersona = CmbTipoPersona.SelectedValue
                    Clave = TxtClave.Text.ToUpper.Trim
                    NombreCorto = TxtNombreCorto.Text.ToUpper.Trim
                    RazonSocial = TxtRazonSocial.Text.ToUpper.Trim
                    RFC = TxtRFC.Text.ToUpper.Trim
                    CURP = TxtCURP.Text.ToUpper.Trim
                    TipoCanal = cmbTipoCanal.SelectedValue
                    listaPrecio = cmbListaPrecio.SelectedValue
                    Responsable = cmbResponsable.SelectedValue
                    CtaContable = TxtCtaContable.Text.Trim.ToUpper

                    Alterno = txtAlterno.Text
                    GLN = TxtGLN.Text.ToUpper.Trim

                    If Not cmbRamo.SelectedValue Is Nothing Then
                        Ramo = cmbRamo.SelectedValue
                    Else
                        Ramo = 0
                    End If

                    DesglosaIVA = ChkDesglosarIVA.Checked
                    ImprimirFac = chkImpresion.Checked
                    Facturable = chkFacturable.Checked

                    TipoImpuesto = CmbTipo.SelectedValue
                    LCredito = dLimite
                    DiasCredito = iDias

                    If LCredito = 0 Then
                        DiasCredito = 0
                    End If

                    Contacto = TxtContacto.Text.ToUpper.Trim

                    fechaNacimiento = cmbFechaNacimiento.Value
                    Genero = cmbGenero.SelectedValue
                    tipoTel1 = cmbTipoTel1.SelectedValue
                    tipoTel2 = cmbTipoTel2.SelectedValue

                    Tel1 = TxtTel1.Text.ToUpper.Trim
                    Tel2 = TxtTel2.Text.ToUpper.Trim
                    email = TxtMail.Text.Trim

                    DescuentoDirecto = cmbDirecto.SelectedValue
                    DescuentoPostVenta = cmbPostVenta.SelectedValue

                    Vendedor = cmbVendedor.SelectedValue
                    UsoCFDI = cmbUsoCFDI.SelectedValue

                    AccesoWeb = ChkAccesoWeb.Checked
                    Password = TxtContraseña.Text.Trim

                    ModPOS.Ejecuta("sp_inserta_cliente", _
                                        "@CTEClave", CTEClave, _
                                        "@Origen", TipoOrigen, _
                                        "@RegFiscal", RegFiscal, _
                                        "@TPersona", TPersona, _
                                        "@Clave", Clave, _
                                        "@CtaMaestra", CtaMaestra, _
                                        "@NombreCorto", NombreCorto, _
                                        "@RazonSocial", RazonSocial, _
                                        "@RFC", RFC, _
                                        "@CURP", CURP, _
                                        "@TipoCanal", TipoCanal, _
                                        "@ListaPrecio", listaPrecio, _
                                        "@Responsable", Responsable, _
                                        "@CtaContable", CtaContable, _
                                        "@Alterno", Alterno, _
                                        "@GLN", GLN, _
                                        "@Ramo", Ramo, _
                                        "@Desglosar", DesglosaIVA, _
                                        "@ImprimirFac", ImprimirFac, _
                                        "@facturable", Facturable, _
                                        "@TipoImpuesto", TipoImpuesto, _
                                        "@LCredito", LCredito, _
                                        "@DCredito", DiasCredito, _
                                        "@Contacto", Contacto, _
                                        "@fechaNacimiento", fechaNacimiento, _
                                        "@Genero", Genero, _
                                        "@tipoTel1", tipoTel1, _
                                        "@tipoTel2", tipoTel2, _
                                        "@Tel1", Tel1, _
                                        "@Tel2", Tel2, _
                                        "@Email", email, _
                                        "@DescuentoDirecto", DescuentoDirecto, _
                                        "@DescuentoPostVenta", DescuentoPostVenta, _
                                        "@Vendedor", Vendedor, _
                                        "@COMClave", ModPOS.CompanyActual, _
                                        "@ClienteSAP", ClienteSAP, _
                                        "@UsoCFDI", UsoCFDI, _
                                         "@AccesoWeb", AccesoWeb, _
                                        "@Password", Password, _
                                        "@Pass", "Duxst4r.", _
                                        "@Usuario", ModPOS.UsuarioActual)


                    PaisF = CmbPaisFac.Text.ToUpper.Trim
                    EntidadF = TxtEstadoFac.Text.ToUpper.Trim
                    MnpioF = TxtMunicipioFac.Text.ToUpper.Trim
                    CalleF = TxtDomicilioFac.Text.ToUpper.Trim
                    ColoniaF = TxtColoniaFac.Text.ToUpper.Trim
                    LocalidadF = TxtLocalidadFac.Text.ToUpper.Trim
                    codigoPostalF = TxtCodigoPostalFac.Text.ToUpper.Trim
                    referenciaF = TxtReferenciaFac.Text.ToUpper.Trim
                    noExteriorF = TxtNoExteriorFac.Text.ToUpper.Trim
                    noInteriorF = TxtNoInteriorFac.Text.ToUpper.Trim

                    If Not cmbZonaVenta.SelectedValue Is Nothing Then
                        ZonaVentaF = cmbZonaVenta.SelectedValue
                    Else
                        ZonaVentaF = 0
                    End If

                    If Not cmbZonaReparto.SelectedValue Is Nothing Then
                        ZonaRepartoF = cmbZonaReparto.SelectedValue
                    Else
                        ZonaRepartoF = 0
                    End If


                    DCTEClaveFiscal = ModPOS.obtenerLlave

                    ModPOS.Ejecuta("sp_inserta_domiciliocliente", _
                                        "@DCTEClave", DCTEClaveFiscal, _
                                        "@TImpuesto", TipoImpuesto, _
                                        "@CTEClave", CTEClave, _
                                        "@TDomicilio", 1, _
                                        "@Clave", Clave, _
                                        "@Pais", PaisF, _
                                        "@Entidad", EntidadF, _
                                        "@Municipio", MnpioF, _
                                        "@Colonia", ColoniaF, _
                                        "@Calle", CalleF, _
                                        "@codigoPostal", codigoPostalF, _
                                        "@Localidad", LocalidadF, _
                                        "@referencia", referenciaF, _
                                        "@noExterior", noExteriorF, _
                                        "@noInterior", noInteriorF, _
                                        "@ZonaVenta", ZonaVentaF, _
                                        "@ZonaReparto", ZonaRepartoF, _
                                        "@NombreCorto", NombreCorto, _
                                        "@Consignatario", RazonSocial, _
                                        "@Telefono", Tel1, _
                                        "@Usuario", ModPOS.UsuarioActual)

                    foundRows = dtDomicilios.Select(" Modificado = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        Dim j As Integer
                        For j = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_inserta_domiciliocliente", _
                                          "@DCTEClave", foundRows(j)("ID"), _
                                           "@TImpuesto", foundRows(j)("TImpuesto"), _
                                          "@CTEClave", CTEClave, _
                                          "@TDomicilio", 2, _
                                          "@Clave", foundRows(j)("Clave"), _
                                          "@Pais", foundRows(j)("País"), _
                                          "@Entidad", foundRows(j)("Entidad"), _
                                          "@Municipio", foundRows(j)("Municipio"), _
                                          "@Colonia", foundRows(j)("Colonia"), _
                                          "@codigoPostal", foundRows(j)("CP"), _
                                          "@Localidad", foundRows(j)("Localidad"), _
                                          "@referencia", foundRows(j)("Ref"), _
                                          "@noExterior", foundRows(j)("noExt"), _
                                          "@noInterior", foundRows(j)("noInt"), _
                                          "@Calle", foundRows(j)("Calle"), _
                                          "@ZonaVenta", foundRows(j)("ZonaVenta"), _
                                        "@ZonaReparto", foundRows(j)("ZonaReparto"), _
                                        "@NombreCorto", foundRows(j)("NombreCorto"), _
                                        "@Consignatario", foundRows(j)("Consignatario"), _
                                        "@Telefono", foundRows(j)("Telefono"), _
                                          "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    Dim z As Integer


                    'Canales 

                    foundRows = dtCanal.Select(" Modificado = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta clasprod
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("st_actualiza_clientecanal", "@CTEClave", CTEClave, "@TipoCanal", foundRows(z)("TipoCanal"), "@PREClave", foundRows(z)("Lista"), "@Usuario", ModPOS.UsuarioActual, "@Baja", 0)
                        Next
                    End If


                    'Clasificaciones

                    foundRows = dtClasificaciones.Select(" Update = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta clasprod
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_clasprod", "@Tipo", 1, "@Class", foundRows(z)("CLAClave"), "@Producto", CTEClave, "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If





                    foundRows = dtMetodosPago.Select(" update = 1 and Baja = 0 ")

                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago


                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_clientepago", _
                            "@MTPClave", foundRows(z)("MTPClave"), _
                            "@CTEClave", CTEClave, _
                            "@MetodoPago", foundRows(z)("MetodoPago"), _
                            "@BNKClave", foundRows(z)("BNKClave"), _
                            "@Referencia", CStr(foundRows(z)("Referencia")).Trim.ToUpper, _
                            "@Preferido", foundRows(z)("Preferido"), _
                            "@Estado", foundRows(z)("TipoEstado"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


                    foundRows = dtDirecto.Select(" Update = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_excepcion_descuento", _
                            "@CTEClave", CTEClave, _
                            "@TipoSector", foundRows(z)("TipoSector"), _
                            "@Descuento", foundRows(z)("TipoDescuento"), _
                            "@Tipo", 1, _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


                    foundRows = dtPostVenta.Select(" Update = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_excepcion_descuento", _
                            "@CTEClave", CTEClave, _
                            "@TipoSector", foundRows(z)("TipoSector"), _
                            "@Descuento", foundRows(z)("TipoDescuento"), _
                            "@Tipo", 2, _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    foundRows = dtClase.Select("Baja = 0")

                    If foundRows.GetLength(0) > 0 Then
                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_gestion", _
                                                  "@CTEClave", CTEClave, _
                                                  "@IdRiesgo", foundRows(z)("Riesgo"), _
                                                  "@TotalComprometido", foundRows(z)("TotalComprometido"), _
                                                  "@TotalVencido", foundRows(z)("TotalVencido"), _
                                                  "@Bloqueado", foundRows(z)("Bloqueado"), _
                                                  "@Verificacion", foundRows(z)("Verificación"), _
                                                  "@Demora", foundRows(z)("Demora"), _
                                                  "@SaldoPreventa", foundRows(z)("SaldoPreventa"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If


                    If fromForm = "Factura" Then
                        If Not ModPOS.Factura Is Nothing Then
                            ModPOS.Factura.CargaDatosCliente(CTEClave)
                        End If

                        Me.Close()
                    ElseIf fromForm = "NotaCargo" Then
                        If Not ModPOS.NotaCargo Is Nothing Then
                            ModPOS.NotaCargo.CargaDatosCliente(CTEClave)
                        End If
                        Me.Close()
                    ElseIf fromForm = "Viaje" Then
                        If Not ModPOS.AddCaja Is Nothing Then
                            ModPOS.Viaje.CargaDatosCliente(CTEClave)
                        End If
                        Me.Close()
                    ElseIf fromForm = "Preventa" Then
                        If Not ModPOS.PreVenta Is Nothing Then
                            ModPOS.PreVenta.changeClient(CTEClave)
                        End If
                        Me.Close()
                    ElseIf fromForm = "Venta" Then
                        If Not ModPOS.Mostradores(numMostrador) Is Nothing Then
                            ModPOS.Mostradores(numMostrador).changeClient(CTEClave)
                        End If
                        Me.Close()
                    ElseIf fromForm = "Bonificacion" Then
                        If Not ModPOS.Bonificacion Is Nothing Then
                            ModPOS.Bonificacion.CargaDatosCliente(CTEClave)
                        End If
                        Me.Close()

                    ElseIf fromForm = "Caja" Then
                        If Not ModPOS.MtoCXC Is Nothing Then
                            ModPOS.MtoCXC.actualizaCliente()
                        End If
                        Me.Close()
                    End If

                    reinicializa()

                Case "Modificar"

                    Dim Limite, Dias As Double

                    Limite = dLimite
                    Dias = iDias

                    If Limite = 0 Then
                        Dias = 0
                    End If


                    If LCredito <> dLimite Then
                        If MaxCredito < dLimite Then
                            Beep()
                            MessageBox.Show("El limite de crédito que intenta otorgar excede el rango permitido para el usuario actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                    End If

                    Dim iRamo, iZV, iZR As Integer
                    If Not cmbZonaVenta.SelectedValue Is Nothing Then
                        iZV = cmbZonaVenta.SelectedValue
                    Else
                        iZV = 0
                    End If


                    If Not cmbZonaReparto.SelectedValue Is Nothing Then
                        iZR = cmbZonaReparto.SelectedValue
                    Else
                        iZR = 0
                    End If

                    If Not cmbRamo.SelectedValue Is Nothing Then
                        iRamo = cmbRamo.SelectedValue
                    Else
                        iRamo = 0
                    End If


                    If Not ( _
                          TipoOrigen = IIf(cmbOrigen.SelectedItem = "Nacional", 1, 2) AndAlso _
                    RegFiscal = TxtRegFiscal.Text AndAlso _
                    TPersona = CmbTipoPersona.SelectedValue AndAlso _
                    NombreCorto = TxtNombreCorto.Text.ToUpper.Trim AndAlso _
                    RazonSocial = TxtRazonSocial.Text.ToUpper.Trim AndAlso _
                    RFC = TxtRFC.Text.ToUpper.Trim AndAlso _
                    CURP = TxtCURP.Text.ToUpper.Trim AndAlso _
                    TipoCanal = cmbTipoCanal.SelectedValue AndAlso _
                    listaPrecio = cmbListaPrecio.SelectedValue AndAlso _
                    Responsable = cmbResponsable.SelectedValue AndAlso _
                    CtaContable = TxtCtaContable.Text.Trim.ToUpper AndAlso _
                    Alterno = txtAlterno.Text AndAlso _
                    GLN = TxtGLN.Text.ToUpper.Trim AndAlso _
                    Ramo = iRamo AndAlso _
                    DesglosaIVA = ChkDesglosarIVA.Checked AndAlso _
                    ImprimirFac = chkImpresion.Checked AndAlso _
                    Facturable = chkFacturable.Checked AndAlso _
                    TipoImpuesto = CmbTipo.SelectedValue AndAlso _
                    LCredito = Limite AndAlso _
                    DiasCredito = Dias AndAlso _
                    Contacto = TxtContacto.Text.ToUpper.Trim AndAlso _
                         fechaNacimiento = cmbFechaNacimiento.Value AndAlso _
                        Genero = cmbGenero.SelectedValue AndAlso _
                        tipoTel1 = cmbTipoTel1.SelectedValue AndAlso _
                        tipoTel2 = cmbTipoTel2.SelectedValue AndAlso _
                    Tel1 = TxtTel1.Text.ToUpper.Trim AndAlso _
                    Tel2 = TxtTel2.Text.ToUpper.Trim AndAlso _
                    email = TxtMail.Text.Trim AndAlso _
                    PaisF = CmbPaisFac.Text.ToUpper.Trim AndAlso _
                    EntidadF = TxtEstadoFac.Text.ToUpper.Trim AndAlso _
                    MnpioF = TxtMunicipioFac.Text.ToUpper.Trim AndAlso _
                    ColoniaF = TxtColoniaFac.Text.ToUpper.Trim AndAlso _
                    CalleF = TxtDomicilioFac.Text.ToUpper.Trim AndAlso _
                    LocalidadF = TxtLocalidadFac.Text.ToUpper.Trim AndAlso _
                    codigoPostalF = TxtCodigoPostalFac.Text.ToUpper.Trim AndAlso _
                    referenciaF = TxtReferenciaFac.Text.ToUpper.Trim AndAlso _
                    noExteriorF = TxtNoExteriorFac.Text.ToUpper.Trim AndAlso _
                    noInteriorF = TxtNoInteriorFac.Text.ToUpper.Trim AndAlso _
                    ZonaVentaF = iZV AndAlso _
                    ZonaRepartoF = iZR AndAlso _
                    DescuentoDirecto = cmbDirecto.SelectedValue AndAlso _
                    DescuentoPostVenta = cmbPostVenta.SelectedValue AndAlso _
                    Vendedor = cmbVendedor.SelectedValue AndAlso _
                    UsoCFDI = cmbUsoCFDI.SelectedValue AndAlso _
                    CtaMaestra = cpyCtaMaestra AndAlso _
                    AccesoWeb = ChkAccesoWeb.Checked AndAlso _
                    Password = TxtContraseña.Text.Trim AndAlso _
                    Estado = Me.ChkEstado.GetEstado) Then


                        If TxtMail.Text.Trim <> email Then
                            If TxtMail.Text <> "" Then
                                If IsValidEmail(TxtMail.Text) = False Then
                                    MessageBox.Show("El formato del correo electronico no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                End If
                            End If
                        End If


                        TipoOrigen = IIf(cmbOrigen.SelectedItem = "Nacional", 1, 2)
                        RegFiscal = TxtRegFiscal.Text

                        TPersona = CmbTipoPersona.SelectedValue
                        NombreCorto = TxtNombreCorto.Text.ToUpper.Trim
                        RazonSocial = TxtRazonSocial.Text.ToUpper.Trim
                        RFC = TxtRFC.Text.ToUpper.Trim
                        CURP = TxtCURP.Text.ToUpper.Trim
                        TipoCanal = cmbTipoCanal.SelectedValue
                        listaPrecio = cmbListaPrecio.SelectedValue
                        Responsable = cmbResponsable.SelectedValue
                        CtaContable = TxtCtaContable.Text.Trim.ToUpper
                        Alterno = txtAlterno.Text
                        GLN = TxtGLN.Text.ToUpper.Trim
                        Ramo = iRamo
                        DesglosaIVA = ChkDesglosarIVA.Checked
                        ImprimirFac = chkImpresion.Checked
                        Facturable = chkFacturable.Checked
                        TipoImpuesto = CmbTipo.SelectedValue
                        LCredito = Limite
                        DiasCredito = Dias
                        Contacto = TxtContacto.Text.ToUpper.Trim
                        fechaNacimiento = cmbFechaNacimiento.Value
                        Genero = cmbGenero.SelectedValue
                        tipoTel1 = cmbTipoTel1.SelectedValue
                        tipoTel2 = cmbTipoTel2.SelectedValue

                        Tel1 = TxtTel1.Text.ToUpper.Trim
                        Tel2 = TxtTel2.Text.ToUpper.Trim
                        email = TxtMail.Text.Trim
                        Estado = Me.ChkEstado.GetEstado
                        AccesoWeb = ChkAccesoWeb.Checked

                        Password = TxtContraseña.Text.Trim
                        CtaMaestra = cpyCtaMaestra

                        DescuentoDirecto = cmbDirecto.SelectedValue
                        DescuentoPostVenta = cmbPostVenta.SelectedValue
                        Vendedor = cmbVendedor.SelectedValue
                        UsoCFDI = cmbUsoCFDI.SelectedValue



                        ModPOS.Ejecuta("sp_modifica_cliente", _
                                        "@CTEClave", CTEClave, _
                                         "@CtaMaestra", CtaMaestra, _
                                         "@Origen", TipoOrigen, _
                                        "@RegFiscal", RegFiscal, _
                                        "@TPersona", TPersona, _
                                        "@NombreCorto", NombreCorto, _
                                        "@RazonSocial", RazonSocial, _
                                        "@RFC", RFC, _
                                        "@CURP", CURP, _
                                        "@TipoCanal", TipoCanal, _
                                        "@ListaPrecio", listaPrecio, _
                                        "@Responsable", Responsable, _
                                        "@CtaContable", CtaContable, _
                                        "@Alterno", Alterno, _
                                        "@GLN", GLN, _
                                        "@Ramo", Ramo, _
                                        "@Desglosar", DesglosaIVA, _
                                        "@ImprimirFac", ImprimirFac, _
                                        "@facturable", Facturable, _
                                        "@TipoImpuesto", TipoImpuesto, _
                                        "@LCredito", LCredito, _
                                        "@DCredito", DiasCredito, _
                                        "@Contacto", Contacto, _
                                        "@fechaNacimiento", fechaNacimiento, _
                                        "@Genero", Genero, _
                                        "@tipoTel1", tipoTel1, _
                                        "@tipoTel2", tipoTel2, _
                                        "@Tel1", Tel1, _
                                        "@Tel2", Tel2, _
                                        "@Email", email, _
                                        "@DescuentoDirecto", DescuentoDirecto, _
                                        "@DescuentoPostVenta", DescuentoPostVenta, _
                                        "@Estado", Estado, _
                                        "@Vendedor", Vendedor, _
                                         "@UsoCFDI", UsoCFDI, _
                                         "@AccesoWeb", AccesoWeb, _
                                         "@Password", Password, _
                                         "@Pass", "Duxst4r.", _
                                        "@Usuario", ModPOS.UsuarioActual)

                        PaisF = CmbPaisFac.Text.ToUpper.Trim
                        EntidadF = TxtEstadoFac.Text.ToUpper.Trim
                        MnpioF = TxtMunicipioFac.Text.ToUpper.Trim
                        ColoniaF = TxtColoniaFac.Text.ToUpper.Trim
                        CalleF = TxtDomicilioFac.Text.ToUpper.Trim
                        LocalidadF = TxtLocalidadFac.Text.ToUpper.Trim
                        codigoPostalF = TxtCodigoPostalFac.Text.ToUpper.Trim
                        referenciaF = TxtReferenciaFac.Text.ToUpper.Trim
                        noExteriorF = TxtNoExteriorFac.Text.ToUpper.Trim
                        noInteriorF = TxtNoInteriorFac.Text.ToUpper.Trim
                        ZonaVentaF = iZV
                        ZonaRepartoF = iZR

                        ModPOS.Ejecuta("sp_modifica_domiciliocliente", _
                                       "@DCTEClave", DCTEClaveFiscal, _
                                          "@TImpuesto", TipoImpuesto, _
                                       "@CTEClave", CTEClave, _
                                       "@TDomicilio", 1, _
                                       "@Clave", Clave, _
                                       "@Pais", PaisF, _
                                       "@Entidad", EntidadF, _
                                       "@Municipio", MnpioF, _
                                       "@Colonia", ColoniaF, _
                                       "@Calle", CalleF, _
                                       "@codigoPostal", codigoPostalF, _
                                       "@Localidad", LocalidadF, _
                                       "@referencia", referenciaF, _
                                       "@noExterior", noExteriorF, _
                                       "@noInterior", noInteriorF, _
                                       "@ZonaVenta", ZonaVentaF, _
                                        "@ZonaReparto", ZonaRepartoF, _
                                        "@NombreCorto", NombreCorto, _
                                        "@Consignatario", RazonSocial, _
                                        "@Telefono", Tel1, _
                                       "@Estado", 1, _
                                       "@Usuario", ModPOS.UsuarioActual)






                    End If


                    Dim j As Integer

                    foundRows = dtDomicilios.Select(" Modificado = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        Dim iEstado As Integer
                        For j = 0 To foundRows.GetUpperBound(0)


                            If foundRows(j)("Estado") = "Activo" Then
                                iEstado = 1
                            Else
                                iEstado = 0
                            End If

                            ModPOS.Ejecuta("sp_modifica_domiciliocliente", _
                                          "@DCTEClave", foundRows(j)("ID"), _
                                             "@TImpuesto", foundRows(j)("TImpuesto"), _
                                          "@CTEClave", CTEClave, _
                                          "@TDomicilio", 2, _
                                          "@Clave", foundRows(j)("Clave"), _
                                          "@Pais", foundRows(j)("Pais"), _
                                          "@Entidad", foundRows(j)("Entidad"), _
                                          "@Municipio", foundRows(j)("Municipio"), _
                                          "@Colonia", foundRows(j)("Colonia"), _
                                          "@codigoPostal", foundRows(j)("CP"), _
                                          "@Localidad", foundRows(j)("Localidad"), _
                                          "@referencia", foundRows(j)("Ref"), _
                                          "@noExterior", foundRows(j)("noExt"), _
                                          "@noInterior", foundRows(j)("noInt"), _
                                          "@Calle", foundRows(j)("Calle"), _
                                           "@ZonaVenta", foundRows(j)("ZonaVenta"), _
                                        "@ZonaReparto", foundRows(j)("ZonaReparto"), _
                                        "@NombreCorto", foundRows(j)("NombreCorto"), _
                                        "@Consignatario", foundRows(j)("Consignatario"), _
                                        "@Telefono", foundRows(j)("Telefono"), _
                                          "@Estado", iEstado, _
                                          "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    'Clasificaciones

                    foundRows = dtClasificaciones.Select(" Update = 1 and  Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta clasprod
                        For j = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_clasprod", "@Tipo", 1, "@Class", foundRows(j)("CLAClave"), "@Producto", CTEClave, "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If



                    foundRows = dtClasificaciones.Select(" Baja = 1 ")
                    If foundRows.Length <> 0 Then
                        'inserta clasprod
                        For j = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_clasprod", "@Tipo", 1, "@Class", foundRows(j)("CLAClave"), "@Producto", CTEClave)

                        Next
                    End If




                    foundRows = dtDomicilios.Select(" Baja = 1 ")
                    If foundRows.Length <> 0 Then

                        For j = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_domiciliocliente", "@DCTEClave", foundRows(j)("ID"), "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


                    Dim z As Integer


                    'Canales 

                    foundRows = dtCanal.Select(" Baja = 1 ")
                    If foundRows.Length <> 0 Then
                        'inserta clasprod
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("st_actualiza_clientecanal", "@CTEClave", CTEClave, "@TipoCanal", foundRows(z)("TipoCanal"), "@PREClave", foundRows(z)("Lista"), "@Usuario", ModPOS.UsuarioActual, "@Baja", 1)
                        Next
                    End If

                    'Canales 

                    foundRows = dtCanal.Select(" Modificado = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta clasprod
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("st_actualiza_clientecanal", "@CTEClave", CTEClave, "@TipoCanal", foundRows(z)("TipoCanal"), "@PREClave", foundRows(z)("Lista"), "@Usuario", ModPOS.UsuarioActual, "@Baja", 0)
                        Next
                    End If




                    foundRows = dtMetodosPago.Select(" update = 1 and Baja = 0")

                    If foundRows.Length <> 0 Then
                        'actualiza denominaciones

                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_actualiza_clientepago", _
                            "@MTPClave", foundRows(z)("MTPClave"), _
                            "@CTEClave", CTEClave, _
                            "@MetodoPago", foundRows(z)("MetodoPago"), _
                            "@BNKClave", foundRows(z)("BNKClave"), _
                            "@Referencia", CStr(foundRows(z)("Referencia")).Trim.ToUpper, _
                            "@Preferido", foundRows(z)("Preferido"), _
                            "@Estado", foundRows(z)("TipoEstado"), _
                            "@Baja", foundRows(z)("Baja"), _
                            "@Usuario", ModPOS.UsuarioActual)


                        Next
                    End If

                    foundRows = dtMetodosPago.Select(" Baja = 1 ")

                    If foundRows.Length <> 0 Then
                        'inserta denominaciones

                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_clientepago", _
                            "@MTPClave", foundRows(z)("MTPClave"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next

                    End If


                    foundRows = dtDirecto.Select(" Baja = 1 ")
                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_excepcion_descuento", _
                            "@CTEClave", CTEClave, _
                            "@TipoSector", foundRows(z)("TipoSector"), _
                            "@Descuento", foundRows(z)("TipoDescuento"), _
                            "@Tipo", 1)
                        Next
                    End If



                    foundRows = dtDirecto.Select(" Update = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_excepcion_descuento", _
                            "@CTEClave", CTEClave, _
                            "@TipoSector", foundRows(z)("TipoSector"), _
                            "@Descuento", foundRows(z)("TipoDescuento"), _
                            "@Tipo", 1, _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


                    foundRows = dtPostVenta.Select(" Baja = 1 ")
                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_excepcion_descuento", _
                            "@CTEClave", CTEClave, _
                            "@TipoSector", foundRows(z)("TipoSector"), _
                            "@Descuento", foundRows(z)("TipoDescuento"), _
                            "@Tipo", 2)
                        Next
                    End If

                    foundRows = dtPostVenta.Select(" Update = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_excepcion_descuento", _
                            "@CTEClave", CTEClave, _
                            "@TipoSector", foundRows(z)("TipoSector"), _
                            "@Descuento", foundRows(z)("TipoDescuento"), _
                            "@Tipo", 2, _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    foundRows = dtClase.Select("Baja = 1")

                    If foundRows.GetLength(0) > 0 Then
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("st_elimina_gestion", _
                                                  "@CTEClave", CTEClave, _
                                                  "@GESClave", foundRows(z)("GESClave"))
                        Next
                    End If




                    foundRows = dtClase.Select("Modificado = 1 and Baja = 0")

                    If foundRows.GetLength(0) > 0 Then
                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_gestion", _
                                                  "@CTEClave", CTEClave, _
                                                  "@IdRiesgo", foundRows(z)("Riesgo"), _
                                                  "@TotalComprometido", foundRows(z)("TotalComprometido"), _
                                                  "@TotalVencido", foundRows(z)("TotalVencido"), _
                                                  "@Bloqueado", foundRows(z)("Bloqueado"), _
                                                  "@Verificacion", foundRows(z)("Verificación"), _
                                                  "@Demora", foundRows(z)("Demora"), _
                                                   "@SaldoPreventa", foundRows(z)("SaldoPreventa"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If

                    If fromForm = "Factura" Then
                        If Not ModPOS.Factura Is Nothing Then
                            ModPOS.Factura.CargaDatosCliente(CTEClave)
                        End If
                        Me.Close()
                    ElseIf fromForm = "NotaCargo" Then
                        If Not ModPOS.NotaCargo Is Nothing Then
                            ModPOS.NotaCargo.CargaDatosCliente(CTEClave)
                        End If
                        Me.Close()
                    ElseIf fromForm = "Viaje" Then
                        If Not ModPOS.AddCaja Is Nothing Then
                            ModPOS.Viaje.CargaDatosCliente(CTEClave)
                        End If
                        Me.Close()
                    ElseIf fromForm = "Preventa" Then
                        If Not ModPOS.PreVenta Is Nothing Then
                            ModPOS.PreVenta.changeClient(CTEClave)
                        End If
                        Me.Close()
                    ElseIf fromForm = "Venta" Then
                        If Not ModPOS.Mostradores(numMostrador) Is Nothing Then
                            ModPOS.Mostradores(numMostrador).changeClient(CTEClave)
                        End If
                        Me.Close()
                    ElseIf fromForm = "Envio" Then
                        If Not ModPOS.Envio Is Nothing Then
                            ModPOS.Envio.CargaDatosCliente(CTEClave)

                        End If
                        Me.Close()
                    ElseIf fromForm = "Bonificacion" Then
                        If Not ModPOS.Bonificacion Is Nothing Then
                            ModPOS.Bonificacion.CargaDatosCliente(CTEClave)
                        End If
                        Me.Close()
                    ElseIf fromForm <> "" Then
                        Me.Close()

                    Else
                        Close()
                    End If

            End Select

            If InterfazSalida <> "" AndAlso bGeneraInterfaz = True Then

                Dim sFolio, sFecha As String
                Dim dtInterfaz As DataTable
                sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")
                If Padre = "Agregar" Then
                    sFolio = auxCTEClave
                Else
                    sFolio = CTEClave
                End If

                dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Cliente", "@COMClave", ModPOS.CompanyActual)
                If dtInterfaz.Rows.Count > 0 Then
                    ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sFolio, "@TipoDocumento", -1, "@Path", InterfazSalida, "@Fecha", sFecha) ', "@Tipo", -1)
                End If

            End If

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.cmbOrigen.SelectedItem Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(27))
            reloj.Enabled = True
            reloj.Start()
        ElseIf cmbOrigen.SelectedItem = "Extrangero" AndAlso TxtRegFiscal.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(28))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbTipoPersona.SelectedValue Is Nothing Then
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
        ElseIf Me.TxtClave.Text.Length > 20 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 20)
        End If

        If Me.TxtRazonSocial.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtRazonSocial.Text.Length > 200 Then
            Me.TxtRazonSocial.Text = Me.TxtRazonSocial.Text.Substring(0, 200)
        End If

        If Me.TxtRFC.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        ElseIf CmbTipoPersona.SelectedValue = 1 AndAlso TxtRFC.Text.Length < 13 Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
            MessageBox.Show("La longitud del RFC para personas Fisicas es de 13 caracteres", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf CmbTipoPersona.SelectedValue = 2 AndAlso TxtRFC.Text.Length < 12 Then

            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
            MessageBox.Show("La longitud del RFC para personas Morales es de 12 caracteres", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf Me.TxtRFC.Text.Length > 32 Then
            Me.TxtRFC.Text = Me.TxtRFC.Text.Substring(0, 32)
        End If

        If Me.cmbTipoCanal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbListaPrecio.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbResponsable.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbTipo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbDirecto.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(25))
            reloj.Enabled = True
            reloj.Start()
        End If
        If Me.cmbPostVenta.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(26))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtLimite.Text = "" Then
            dLimite = 0
        Else
            dLimite = CDbl(TxtLimite.Text)
        End If

        If dLimite < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(8))
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
            reloj = New parpadea(Me.alerta(9))
            reloj.Enabled = True
            reloj.Start()
        End If


        If TxtContacto.Text <> "" AndAlso Me.cmbGenero.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(34))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtTel1.Text <> "" AndAlso Me.cmbTipoTel1.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(35))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtTel2.Text <> "" AndAlso Me.cmbTipoTel2.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(36))
            reloj.Enabled = True
            reloj.Start()
        End If



        If Me.CmbPaisFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(10))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtEstadoFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(11))
            reloj.Enabled = True
            reloj.Start()
        ElseIf bDomicilio = True Then
            If Not ModPOS.SiExite(ModPOS.BDConexion, "st_valida_domicilio", "@Domicilio", Me.TxtEstadoFac.Text.ToUpper.Trim, "@Tipo", 1) > 0 Then
                Beep()
                MessageBox.Show("El estado que intenta agregar no existe en el catalogo de geografia actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                i += 1
                reloj = New parpadea(Me.alerta(11))
                reloj.Enabled = True
                reloj.Start()
            End If
        End If

        If Me.TxtMunicipioFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(12))
            reloj.Enabled = True
            reloj.Start()
        ElseIf bDomicilio = True Then
            If Not ModPOS.SiExite(ModPOS.BDConexion, "st_valida_domicilio", "@Domicilio", Me.TxtMunicipioFac.Text.ToUpper.Trim, "@Tipo", 2) > 0 Then
                Beep()
                MessageBox.Show("El municipio que intenta agregar no existe en el catalogo de geografia actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                i += 1
                reloj = New parpadea(Me.alerta(12))
                reloj.Enabled = True
                reloj.Start()
            End If
        End If

        If bDomicilio AndAlso TxtLocalidadFac.Text <> "" Then
            If Not ModPOS.SiExite(ModPOS.BDConexion, "st_valida_domicilio", "@Domicilio", TxtLocalidadFac.Text.ToUpper.Trim, "@Tipo", 2) > 0 Then
                Beep()
                MessageBox.Show("El asentamiento o poblacion que intenta agregar no existe en el catalogo de geografia actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                i += 1
                reloj = New parpadea(Me.alerta(12))
                reloj.Enabled = True
                reloj.Start()
            End If
        End If


        If Me.TxtColoniaFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(13))
            reloj.Enabled = True
            reloj.Start()
        ElseIf bDomicilio = True Then
            If Not ModPOS.SiExite(ModPOS.BDConexion, "st_valida_domicilio", "@Domicilio", Me.TxtColoniaFac.Text.ToUpper.Trim, "@Tipo", 3) > 0 Then
                Beep()
                MessageBox.Show("La colonia que intenta agregar no existe en el catalogo de geografia actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                i += 1
                reloj = New parpadea(Me.alerta(13))
                reloj.Enabled = True
                reloj.Start()
            End If
        End If

        If Me.TxtDomicilioFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(14))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtCodigoPostalFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(15))
            reloj.Enabled = True
            reloj.Start()
        ElseIf bDomicilio = True Then
            If Not ModPOS.SiExite(ModPOS.BDConexion, "st_valida_domicilio", "@Domicilio", Me.TxtCodigoPostalFac.Text.ToUpper.Trim, "@Tipo", 4) > 0 Then
                i += 1
                reloj = New parpadea(Me.alerta(15))
                reloj.Enabled = True
                reloj.Start()
            End If
        End If

        If Me.TxtNoExteriorFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(16))
            reloj.Enabled = True
            reloj.Start()
        End If

        If chkFacturable.Checked = True AndAlso TxtMail.Text = "" AndAlso TallaColor = 1 Then
            i += 1
            reloj = New parpadea(Me.alerta(33))
            reloj.Enabled = True
            reloj.Start()
            MessageBox.Show("El correo electrónico es requerido", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

        If ChkAccesoWeb.Checked = True AndAlso TxtContraseña.Text <> "" Then

            If TxtContraseña.Text.Trim <> TxtConfirmar.Text.Trim Then
                i += 1
                reloj = New parpadea(Me.alerta(31))
                reloj.Enabled = True
                reloj.Start()
            ElseIf IsNumeric(TxtContraseña.Text.Trim) = False Then
                i += 1
                reloj = New parpadea(Me.alerta(31))
                reloj.Enabled = True
                reloj.Start()

                MessageBox.Show("El PIN debe ser numérico", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf TxtContraseña.Text.Length <> 4 Then
                i += 1
                reloj = New parpadea(Me.alerta(31))
                reloj.Enabled = True
                reloj.Start()
                MessageBox.Show("El PIN debe ser 4 digitos", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If


        If txtAlterno.Text <> "" AndAlso Not cmbResponsable.SelectedValue Is Nothing Then
            If ModPOS.SiExite(ModPOS.BDConexion, "st_valida_alterno", "@CTEClave", CTEClave, "@Responsable", cmbResponsable.SelectedValue, "@Alterno", Me.txtAlterno.Text.ToUpper.Trim, "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("La Referencia que intenta agregar  como código Alterno ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(1))
                reloj.Enabled = True
                reloj.Start()
            End If
        End If


        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Cliente", "@clave", Me.TxtClave.Text.ToUpper.Trim, "@COMClave", ModPOS.CompanyActual) > 0 Then
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

#End Region

#Region "Domicilio"

    'DomicilioCliente, Tipo= 2 = Punto de Entrega

    Public Sub cargaCanales(Optional ByVal Recovery As Boolean = False, Optional ByVal sCTEClave As String = "")

        If Recovery = True Then
            dtCanal = ModPOS.Recupera_Tabla("st_muestra_clientecanal", "@CTEClave", sCTEClave, "@Update", 1)

        ElseIf Padre = "Modificar" Then
            dtCanal = ModPOS.Recupera_Tabla("st_muestra_clientecanal", "@CTEClave", CTEClave)

        Else
            dtCanal = ModPOS.CrearTabla("ClienteCanal", _
                                  "TipoCanal", "System.String", _
                                  "Lista", "System.String", _
                                  "Modificado", "System.Int32", _
                                  "Baja", "System.Boolean")

        End If

        gridCanales.DataSource = dtCanal
        gridCanales.RetrieveStructure(True)
        gridCanales.GroupByBoxVisible = False
        gridCanales.RootTable.Columns("Modificado").Visible = False
        gridCanales.CurrentTable.Columns("Baja").Visible = False


        gridCanales.CurrentTable.Columns("Lista").HasValueList = True
        Dim AircraftTypeValueListItemCollection As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection = gridCanales.Tables(0).Columns("Lista").ValueList
        With AircraftTypeValueListItemCollection
            Dim i As Integer
            For i = 0 To dtLista.Rows.Count - 1
                .Add(dtLista.Rows(i)("PREClave"), dtLista.Rows(i)("Lista"))
            Next
        End With
        gridCanales.CurrentTable.Columns("Lista").EditType = Janus.Windows.GridEX.EditType.Combo


        gridCanales.CurrentTable.Columns("TipoCanal").HasValueList = True
        Dim AircraftTypeValueListItemCollection2 As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection2 = gridCanales.Tables(0).Columns("TipoCanal").ValueList
        With AircraftTypeValueListItemCollection2
            Dim i As Integer
            For i = 0 To dtTipoCanal.Rows.Count - 1
                .Add(dtTipoCanal.Rows(i)("Valor"), dtTipoCanal.Rows(i)("Descripcion"))
            Next
        End With
        gridCanales.CurrentTable.Columns("TipoCanal").EditType = Janus.Windows.GridEX.EditType.Combo


        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(gridCanales.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        gridCanales.RootTable.FormatConditions.Add(fc)

    End Sub


    Public Sub cargaRiesgo()
        If Padre = "Modificar" Then
            dtClase = ModPOS.Recupera_Tabla("st_muestra_riesgo", "@CTEClave", CTEClave)

        Else
            dtClase = ModPOS.CrearTabla("GestionCredito", _
                                  "GESClave", "System.String", _
                                  "Riesgo", "System.String", _
                                  "TotalComprometido", "System.Decimal", _
                                  "TotalVencido", "System.Decimal", _
                                  "Bloqueado", "System.Boolean", _
                                  "Verificación", "System.DateTime", _
                                  "Demora", "System.Int32", _
                                  "SaldoPreventa", "System.Decimal", _
                                  "Modificado", "System.Int32", _
                                  "Baja", "System.Boolean")

        End If

        GridClases.DataSource = dtClase
        GridClases.RetrieveStructure(True)
        GridClases.GroupByBoxVisible = False
        GridClases.RootTable.Columns("GESClave").Visible = False
        GridClases.RootTable.Columns("Modificado").Visible = False
        GridClases.CurrentTable.Columns("Baja").Visible = False
        GridClases.RootTable.Columns("TotalComprometido").Selectable = False
        GridClases.RootTable.Columns("TotalVencido").Selectable = False
        GridClases.RootTable.Columns("SaldoPreventa").Selectable = False
        GridClases.RootTable.Columns("Demora").Selectable = False

        GridClases.CurrentTable.Columns("Riesgo").HasValueList = True
        Dim AircraftTypeValueListItemCollection As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection = GridClases.Tables(0).Columns("Riesgo").ValueList
        With AircraftTypeValueListItemCollection

            dtRiesgo = ModPOS.Recupera_Tabla("st_filtra_riesgos", "@COMClave", ModPOS.CompanyActual)

            Dim i As Integer
            For i = 0 To dtRiesgo.Rows.Count - 1
                .Add(dtRiesgo.Rows(i)("IdRiesgo"), dtRiesgo.Rows(i)("Clave"))
            Next

        End With
        GridClases.CurrentTable.Columns("Riesgo").EditType = Janus.Windows.GridEX.EditType.Combo



        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridClases.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridClases.RootTable.FormatConditions.Add(fc)

    End Sub

    Public Sub cargaPostVenta()
        If Padre = "Modificar" Then

            dtPostVenta = ModPOS.Recupera_Tabla("sp_muestra_descuentopostventa", "@CTEClave", CTEClave)

        Else
            dtPostVenta = ModPOS.CrearTabla("Descuento", _
               "Sector", "System.String", _
               "Descuento", "System.String", _
               "TipoSector", "System.Int32", _
               "TipoDescuento", "System.Int32", _
               "Update", "System.Int32", _
               "Baja", "System.Int32")
        End If

    End Sub

    Public Sub cargaDirecto()
        If Padre = "Modificar" Then

            dtDirecto = ModPOS.Recupera_Tabla("sp_muestra_descuentodirecto", "@CTEClave", CTEClave)

        Else
            dtDirecto = ModPOS.CrearTabla("Descuento", _
               "Sector", "System.String", _
               "Descuento", "System.String", _
               "TipoSector", "System.Int32", _
               "TipoDescuento", "System.Int32", _
               "Update", "System.Int32", _
               "Baja", "System.Int32")
        End If

    End Sub


    Public Sub cargaClasificaciones()
        If Padre = "Modificar" Then

            dtClasificaciones = ModPOS.Recupera_Tabla("sp_muestra_clascte", "@CTEClave", CTEClave)

        Else

            dtClasificaciones = ModPOS.CrearTabla("ClasCte", _
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


    Public Sub cargaPuntosdeEntrega()
        If Padre = "Modificar" Then
            dtDomicilios = ModPOS.Recupera_Tabla("sp_muestra_domicilios", "@CTEClave", CTEClave)

        Else

            dtDomicilios = ModPOS.CrearTabla("DomicilioCliente", _
                     "ID", "System.String", _
                     "TImpuesto", "System.Int32", _
                     "Clave", "System.String", _
                     "NombreCorto", "System.String", _
                     "Consignatario", "System.String", _
                     "Calle", "System.String", _
                     "noExt", "System.String", _
                     "noInt", "System.String", _
                     "Ref", "System.String", _
                     "Colonia", "System.String", _
                     "CP", "System.String", _
                     "Municipio", "System.String", _
                     "Localidad", "System.String", _
                     "Entidad", "System.String", _
                     "Pais", "System.String", _
                     "ZonaVenta", "System.Int32", _
                     "ZonaReparto", "System.Int32", _
                     "Telefono", "System.String", _
                     "Estado", "System.String", _
                     "Baja", "System.Int32", _
                     "Modificado", "System.Int32")

        End If

        GridDomicilios.DataSource = dtDomicilios
        GridDomicilios.RetrieveStructure(True)
        GridDomicilios.GroupByBoxVisible = False
        GridDomicilios.RootTable.Columns("ID").Visible = False
        GridDomicilios.RootTable.Columns("TImpuesto").Visible = False
        GridDomicilios.RootTable.Columns("Calle").Visible = False
        GridDomicilios.RootTable.Columns("noExt").Visible = False
        GridDomicilios.RootTable.Columns("noInt").Visible = False
        GridDomicilios.RootTable.Columns("Ref").Visible = False
        GridDomicilios.RootTable.Columns("Colonia").Visible = False
        GridDomicilios.RootTable.Columns("CP").Visible = False
        GridDomicilios.RootTable.Columns("Municipio").Visible = False
        GridDomicilios.RootTable.Columns("Localidad").Visible = False
        GridDomicilios.RootTable.Columns("Entidad").Visible = False
        GridDomicilios.RootTable.Columns("Pais").Visible = False
        GridDomicilios.RootTable.Columns("Baja").Visible = False
        GridDomicilios.RootTable.Columns("ZonaVenta").Visible = False
        GridDomicilios.RootTable.Columns("ZonaReparto").Visible = False
        GridDomicilios.RootTable.Columns("Modificado").Visible = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDomicilios.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.NotEqual, "Activo")

        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridDomicilios.RootTable.FormatConditions.Add(fc)

        Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
        fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridDomicilios.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc1.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc1.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridDomicilios.RootTable.FormatConditions.Add(fc1)



    End Sub

    Public Sub reiniciaPuntodeEntrega(ByVal dPadre As String)
        Pais = ""
        ClavePE = ""
        Nombre = ""
        Consignatario = ""
        TelDomicilio = ""
        TDomicilio = 0
        Colonia = ""
        Entidad = ""
        Mnpio = ""
        Calle = ""
        Localidad = ""
        codigoPostal = ""
        referencia = ""
        noInterior = ""
        noExterior = ""
        Estado = 1

        TxtClavePE.Text = ClavePE
        TxtNombre.Text = Nombre
        TxtConsignatario.Text = Consignatario
        txtTelDomicilio.Text = TelDomicilio
        TxtCalle.Text = Calle
        TxtEstado.Text = Entidad
        TxtMunicipio.Text = Mnpio
        TxtColonia.Text = Colonia
        TxtLocalidad.Text = Localidad
        TxtCodigoPostal.Text = codigoPostal
        TxtReferencia.Text = referencia
        TxtNoInterior.Text = noInterior
        TxtNoExterior.Text = noExterior
        ChkEstado.Estado = Estado

        If dPadre <> "Agregar" Then
            DomicilioPadre = "Agregar"

            BtnDelDomi.Enabled = False
            ChkDomicilio.Enabled = False
            ChkDomicilio.Enabled = 1
        End If

    End Sub


    Public Sub AddDomicilio(ByVal ID As String, ByVal TImpuesto As Integer, ByVal sClave As String, ByVal sNombre As String, ByVal sConsignatario As String, ByVal sTelDomicllio As String, ByVal sColonia As String, ByVal sCalle As String, ByVal snoExt As String, ByVal snoInt As String, ByVal sRef As String, ByVal sCP As String, ByVal sMunicipio As String, ByVal sLocalidad As String, ByVal sEntidad As String, ByVal sPais As String, ByVal iZonaVta As Integer, ByVal iZonaRep As Integer, ByVal sEstado As String)

        Dim foundRows() As Data.DataRow
        foundRows = dtDomicilios.Select("ID Like '" & ID & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtDomicilios.NewRow()
            'declara el nombre de la fila

            row1.Item("ID") = ID
            row1.Item("Clave") = sClave
            row1.Item("TImpuesto") = TImpuesto
            row1.Item("NombreCorto") = sNombre
            row1.Item("Consignatario") = sConsignatario
            row1.Item("Telefono") = sTelDomicllio

            'row1.Item("Domicilio") = sCalle & " " & snoExt & " " & snoInt & ", " & sColonia & ", CP:" & sCP & ", " & sMunicipio & ", " & sEntidad

            row1.Item("Calle") = sCalle
            row1.Item("noExt") = snoExt
            row1.Item("noInt") = snoInt
            row1.Item("Ref") = sRef
            row1.Item("Colonia") = sColonia
            row1.Item("CP") = sCP
            row1.Item("Municipio") = sMunicipio
            row1.Item("Localidad") = sLocalidad
            row1.Item("Entidad") = sEntidad
            row1.Item("Pais") = sPais
            row1.Item("Estado") = sEstado
            row1.Item("ZonaVenta") = iZonaVta
            row1.Item("ZonaReparto") = iZonaRep


            row1.Item("Baja") = 0
            row1.Item("Modificado") = 1

            dtDomicilios.Rows.Add(row1)
            'agrega la fila completo a la tabla


        Else
            Beep()
            MessageBox.Show("¡El domicilio que intenta agregar ya existe para el cliente actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub


    Public Sub UpdDomicilio(ByVal ID As String, ByVal TImpuesto As Integer, ByVal sClave As String, ByVal sNombre As String, ByVal sConsignatario As String, ByVal sTelDomicllio As String, ByVal sColonia As String, ByVal sCalle As String, ByVal snoExt As String, ByVal snoInt As String, ByVal sRef As String, ByVal sCP As String, ByVal sMunicipio As String, ByVal sLocalidad As String, ByVal sEntidad As String, ByVal sPais As String, ByVal iZonaVta As Integer, ByVal iZonaRep As Integer, ByVal sEstado As String)
        Dim foundRows() As Data.DataRow
        foundRows = dtDomicilios.Select("ID Like '" & ID & "'")

        If foundRows.Length = 1 Then
            ' foundRows(0)("Domiclio") = sCalle & " " & snoExt & " " & snoInt & ", " & sColonia & ", CP:" & sCP & ", " & sMunicipio & ", " & sEntidad
            foundRows(0)("Clave") = sClave
            foundRows(0)("TImpuesto") = TImpuesto
            foundRows(0)("NombreCorto") = sNombre
            foundRows(0)("Consignatario") = sConsignatario
            foundRows(0)("Telefono") = sTelDomicllio
            foundRows(0)("Calle") = sCalle
            foundRows(0)("noExt") = snoExt
            foundRows(0)("noInt") = snoInt
            foundRows(0)("Ref") = sRef
            foundRows(0)("Colonia") = sColonia
            foundRows(0)("CP") = sCP
            foundRows(0)("Municipio") = sMunicipio
            foundRows(0)("Localidad") = sLocalidad
            foundRows(0)("Entidad") = sEntidad
            foundRows(0)("Pais") = sPais
            foundRows(0)("ZonaVenta") = iZonaVta
            foundRows(0)("ZonaReparto") = iZonaRep
            foundRows(0)("Estado") = sEstado
            foundRows(0)("Modificado") = 1
        End If
    End Sub


    Private Function validaDomicilio() As Boolean
        Dim i As Integer = 0

        If Me.TxtClavePE.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(29))
            reloj.Enabled = True
            reloj.Start()

        End If

        If Me.TxtConsignatario.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(17))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtConsignatario.Text.Length > 200 Then
            Me.TxtConsignatario.Text = Me.TxtConsignatario.Text.Substring(0, 200)
        End If


        If Me.cmbPais.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(18))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtEstado.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(19))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtMunicipio.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(20))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtColonia.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(21))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtCodigoPostal.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(22))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtCalle.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(23))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 128 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 128)
        End If

        If Me.TxtNoExterior.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(24))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.cmbTipoImpuesto.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(32))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        Else

            Dim Result As Integer
            Dim dt As DataTable

            dt = ModPOS.Recupera_Tabla("sp_valida_domiciliocliente", _
            "@CTEClave", CTEClave, _
            "@DCTEClave", DCTEClave, _
            "@TDomicilio", 2, _
            "@Pais", cmbPais.Text.ToUpper.Trim, _
            "@Entidad", TxtEstado.Text.ToUpper.Trim, _
            "@Municipio", TxtMunicipio.Text.ToUpper.Trim, _
            "@Colonia", TxtColonia.Text.ToUpper.Trim, _
            "@Calle", TxtCalle.Text.ToUpper.Trim, _
            "@Localidad", TxtLocalidad.Text.ToUpper.Trim, _
            "@Referencia", TxtReferencia.Text.ToUpper.Trim, _
            "@codigoPostal", TxtCodigoPostal.Text.ToUpper.Trim, _
            "@noExterior", TxtNoExterior.Text.ToUpper.Trim, _
            "@noInterior", TxtNoInterior.Text.Trim, _
            "@Estado", ChkDomicilio.GetEstado)

            Result = dt.Rows(0)("Resultado")
            dt.Dispose()

            Select Case Result
                Case 0
                    While i < Me.alerta.Length
                        Me.alerta(i).Visible = False
                        i += 1
                    End While
                    Return True

                Case 1, 3, 5
                    MessageBox.Show("Solo puede existir un domicilio Fiscal activo en el sistema, el domicilio existente tiene que eliminarlo o cambiar su estado a inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Case 2, 4
                    MessageBox.Show("El domicilio que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
            End Select

        End If

    End Function

    Private Sub GridDomicilios_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDomicilios.DoubleClick

        If Not GridDomicilios.GetValue(0) Is Nothing Then

            Me.DCTEClave = GridDomicilios.GetValue("ID")
            Me.sDomicilio = GridDomicilios.GetValue("Calle") & " " & GridDomicilios.GetValue("noExt")
        Else
            Me.DCTEClave = ""
            Me.sDomicilio = ""

        End If

        If DCTEClave <> "" Then

            TDomicilio = 2
            Nombre = GridDomicilios.GetValue("NombreCorto")
            Consignatario = GridDomicilios.GetValue("Consignatario")
            TelDomicilio = GridDomicilios.GetValue("Telefono")
            Pais = GridDomicilios.GetValue("Pais")
            Entidad = GridDomicilios.GetValue("Entidad")
            Mnpio = GridDomicilios.GetValue("Municipio")
            Colonia = GridDomicilios.GetValue("Colonia")
            Localidad = GridDomicilios.GetValue("Localidad")
            referencia = GridDomicilios.GetValue("Ref")
            noExterior = GridDomicilios.GetValue("noExt")
            noInterior = GridDomicilios.GetValue("noInt")
            codigoPostal = GridDomicilios.GetValue("CP")
            Calle = GridDomicilios.GetValue("Calle")
            ZonaVenta = GridDomicilios.GetValue("ZonaVenta")
            ZonaReparto = GridDomicilios.GetValue("ZonaReparto")

            If GridDomicilios.GetValue("Estado") = "Activo" Then
                DomicilioEstado = 1
            Else
                DomicilioEstado = 0
            End If


            TxtNombre.Text = Nombre
            TxtConsignatario.Text = Consignatario
            txtTelDomicilio.Text = TelDomicilio
            cmbPais.Text = Pais
            TxtEstado.Text = Entidad
            TxtMunicipio.Text = Mnpio
            TxtColonia.Text = Colonia
            TxtLocalidad.Text = Localidad
            TxtCodigoPostal.Text = codigoPostal
            TxtReferencia.Text = referencia
            TxtNoInterior.Text = noInterior
            TxtNoExterior.Text = noExterior
            TxtCalle.Text = Calle
            ChkDomicilio.Estado = DomicilioEstado
            cmbZonaVtap.SelectedValue = ZonaVenta
            cmbZonaRep.SelectedValue = ZonaReparto

            DomicilioPadre = "Modificar"
            BtnDelDomi.Enabled = True
            ChkDomicilio.Enabled = True
        End If

    End Sub

    Private Sub cmbPais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPais.SelectedIndexChanged
        If cargado = True AndAlso Not cmbPais.SelectedValue Is Nothing Then
            Dim dtEstado As DataTable

            dtEstado = ModPOS.Recupera_Tabla("sp_filtra_estado", "@Pais", cmbPais.SelectedValue)
            If dtEstado.Rows.Count > 0 Then
                ReDim aEstado(dtEstado.Rows.Count - 1)

                For i As Integer = 0 To dtEstado.Rows.Count - 1
                    aEstado(i) = dtEstado.Rows(i)("d_estado")
                Next

                Me.TxtEstado.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.TxtEstado.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.TxtEstado.AutoCompleteCustomSource.AddRange(aEstado)

                dtEstado.Dispose()
            End If

        End If

    End Sub

    Private Sub UiTab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs) Handles UiTabGestion.SelectedTabChanged
        Select Case e.Page.Name

            Case "UiTabSaldos"
                ModPOS.ActualizaGrid(False, Me.GridSaldos, "sp_muestra_saldos", "@CTEClave", CTEClave)

        End Select

    End Sub

    Private Sub BtnAceptarDomi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptarDomi.Click
        If validaDomicilio() Then
            Select Case Me.DomicilioPadre
                Case "Agregar"

                    DCTEClave = ModPOS.obtenerLlave
                    TImpuesto = cmbTipoImpuesto.SelectedValue
                    ClavePE = TxtClavePE.Text
                    TDomicilio = 2
                    Nombre = TxtNombre.Text
                    Consignatario = TxtConsignatario.Text
                    TelDomicilio = txtTelDomicilio.Text
                    Pais = cmbPais.Text
                    Entidad = TxtEstado.Text
                    Mnpio = TxtMunicipio.Text
                    Colonia = TxtColonia.Text
                    Calle = TxtCalle.Text.ToUpper.Trim
                    Localidad = TxtLocalidad.Text.ToUpper.Trim
                    codigoPostal = TxtCodigoPostal.Text.ToUpper.Trim
                    referencia = TxtReferencia.Text.ToUpper.Trim
                    noExterior = TxtNoExterior.Text.ToUpper.Trim
                    noInterior = TxtNoInterior.Text.ToUpper.Trim

                    If Not cmbZonaVtap.SelectedValue Is Nothing Then
                        ZonaVenta = cmbZonaVtap.SelectedValue
                    Else
                        ZonaVenta = 0
                    End If


                    If Not cmbZonaRep.SelectedValue Is Nothing Then
                        ZonaReparto = cmbZonaRep.SelectedValue
                    Else
                        ZonaReparto = 0
                    End If


                    Dim sEstado As String
                    If Me.ChkDomicilio.GetEstado = 1 Then
                        sEstado = "Activo"
                    Else
                        sEstado = "Inactivo"
                    End If



                    AddDomicilio(DCTEClave, TImpuesto, ClavePE, Nombre, Consignatario, TelDomicilio, Colonia, Calle, noExterior, noInterior, referencia, codigoPostal, Mnpio, Localidad, Entidad, Pais, ZonaVenta, ZonaReparto, sEstado)

                    reiniciaPuntodeEntrega(DomicilioPadre)

                Case "Modificar"

                    Dim iZV, iZR As Integer
                    If Not cmbZonaVtap.SelectedValue Is Nothing Then
                        iZV = cmbZonaVtap.SelectedValue
                    Else
                        iZV = 0
                    End If


                    If Not cmbZonaRep.SelectedValue Is Nothing Then
                        iZR = cmbZonaRep.SelectedValue
                    Else
                        iZR = 0
                    End If


                    If Not ( _
                        ClavePE = TxtClavePE.Text AndAlso _
                        TImpuesto = cmbTipoImpuesto.SelectedValue AndAlso _
                    Nombre = TxtNombre.Text AndAlso _
                    Consignatario = TxtConsignatario.Text AndAlso _
                    TelDomicilio = txtTelDomicilio.Text AndAlso _
                    Pais = cmbPais.Text AndAlso _
                    Entidad = TxtEstado.Text AndAlso _
                    Mnpio = TxtMunicipio.Text AndAlso _
                    Colonia = TxtColonia.Text AndAlso _
                    Calle = TxtCalle.Text.ToUpper.Trim AndAlso _
                    Localidad = TxtLocalidad.Text.ToUpper.Trim AndAlso _
                    codigoPostal = TxtCodigoPostal.Text.ToUpper.Trim AndAlso _
                    referencia = TxtReferencia.Text.ToUpper.Trim AndAlso _
                    noExterior = TxtNoExterior.Text.ToUpper.Trim AndAlso _
                    noInterior = TxtNoInterior.Text.ToUpper.Trim AndAlso _
                    ZonaVenta = iZV AndAlso _
                    ZonaReparto = iZR AndAlso _
                    DomicilioEstado = Me.ChkDomicilio.GetEstado) Then


                        TDomicilio = 2
                        TImpuesto = cmbTipoImpuesto.SelectedValue
                        ClavePE = TxtClavePE.Text
                        Nombre = TxtNombre.Text
                        Consignatario = TxtConsignatario.Text
                        TelDomicilio = txtTelDomicilio.Text
                        Pais = cmbPais.Text
                        Entidad = TxtEstado.Text
                        Mnpio = TxtMunicipio.Text
                        Colonia = TxtColonia.Text
                        Calle = TxtCalle.Text.ToUpper.Trim
                        Localidad = TxtLocalidad.Text.ToUpper.Trim
                        codigoPostal = TxtCodigoPostal.Text.ToUpper.Trim
                        referencia = TxtReferencia.Text.ToUpper.Trim
                        noExterior = TxtNoExterior.Text.ToUpper.Trim
                        noInterior = TxtNoInterior.Text.ToUpper.Trim
                        ZonaVenta = iZV
                        ZonaReparto = iZR

                        Dim sEstado As String
                        If Me.ChkDomicilio.GetEstado = 1 Then
                            sEstado = "Activo"
                        Else
                            sEstado = "Inactivo"
                        End If

                        UpdDomicilio(DCTEClave, TImpuesto, ClavePE, Nombre, Consignatario, TelDomicilio, Colonia, Calle, noExterior, noInterior, referencia, codigoPostal, Mnpio, Localidad, Entidad, Pais, ZonaVenta, ZonaReparto, sEstado)



                    End If

                    reiniciaPuntodeEntrega(DomicilioPadre)


            End Select

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnDelDomi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelDomi.Click
        If DCTEClave <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el domicilio seleccionado  :" & sDomicilio, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtDomicilios.Select("ID Like '" & DCTEClave & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If

                    reiniciaPuntodeEntrega(DomicilioPadre)



            End Select
        End If

    End Sub

#End Region

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

    'Private Sub CmbEstadoFac_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If cargado = True AndAlso Not CmbEstadoFac.SelectedValue Is Nothing Then
    '        With Me.CmbMunicipioFac
    '            .Conexion = Cnx
    '            .ProcedimientoAlmacenado = "sp_filtra_mnpio"
    '            .NombreParametro1 = "Estado"
    '            .Parametro1 = CmbEstadoFac.SelectedValue
    '            .llenar()
    '        End With
    '    End If

    'End Sub

    'Private Sub CmbMunicipioFac_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If cargado = True AndAlso Not CmbMunicipioFac.SelectedValue Is Nothing AndAlso Not CmbEstadoFac.SelectedValue Is Nothing Then
    '        With Me.CmbColoniaFac
    '            .Conexion = Cnx
    '            .ProcedimientoAlmacenado = "sp_filtra_colonia"
    '            .NombreParametro1 = "Estado"
    '            .Parametro1 = CmbEstadoFac.SelectedValue
    '            .NombreParametro2 = "Municipio"
    '            .Parametro2 = CmbMunicipioFac.SelectedValue
    '            .llenar()
    '        End With
    '    End If

    'End Sub

    Private Sub Ctrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClave.KeyDown, TxtNombreCorto.KeyDown, CmbTipoPersona.KeyDown, TxtRazonSocial.KeyDown, TxtRFC.KeyDown, TxtLimite.KeyDown, cmbListaPrecio.KeyDown, TxtDiasCredito.KeyDown, CmbPaisFac.KeyDown, TxtDomicilioFac.KeyDown, TxtContacto.KeyDown, TxtTel1.KeyDown, TxtTel2.KeyDown, TxtMail.KeyDown, TxtEstadoFac.KeyDown, TxtMunicipioFac.KeyDown, TxtColoniaFac.KeyDown, TxtLocalidadFac.KeyDown, TxtCodigoPostalFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub BtnKey_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKey.Click
        If Not cmbResponsable.SelectedValue Is Nothing Then
            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "Digitos", "@COMClave", ModPOS.CompanyActual)
            Dim len As Integer = CInt(dt.Rows(0)("Valor"))
            dt.Dispose()

            dt = ModPOS.Recupera_Tabla("sp_recupera_valor", "@Tabla", "Cliente", "@Campo", "Responsable", "@Valor", cmbResponsable.SelectedValue)
            Dim Refencia As String = CStr(dt.Rows(0)("Clave"))
            dt.Dispose()


            dt = ModPOS.Recupera_Tabla("sp_calcula_cteclave", "@Responsable", cmbResponsable.SelectedValue, "@len", len, "@COMClave", ModPOS.CompanyActual, "@MaskCte", MaskCte)

            If MaskCte = 1 Then
                TxtClave.Text = Refencia & "-" & fxDigitoVerificador(CDbl(dt.Rows(0)("Clave")))
            Else
                TxtClave.Text = dt.Rows(0)("Clave")
            End If
            dt.Dispose()

            SendKeys.Send("{TAB}")
        Else
            MessageBox.Show("Debe asignar un responsable de la cuenta de cliente", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub reinicializa()
        TipoOrigen = 1
        RegFiscal = ""
        CTEClave = ""
        DCTEClaveFiscal = ""
        Clave = ""
        FechaReg = DateTime.Today
        NombreCorto = ""
        RazonSocial = ""
        TPersona = 1
        RFC = ""
        LCredito = 0
        Saldo = 0
        Contacto = ""
        fechaNacimiento = DateTime.Today
        Genero = 0
        tipoTel1 = 1
        tipoTel2 = 1
        Tel1 = ""
        Tel2 = ""
        email = ""
        Estado = 1
        CreditoDisponible = 0
        TDomicilio = 1
        Responsable = 0
        TipoImpuesto = 1

        MnpioF = ""
        ColoniaF = ""
        CalleF = ""
        LocalidadF = ""
        codigoPostalF = ""
        referenciaF = ""
        noInteriorF = ""
        noExteriorF = ""

        DiasCredito = 0
        DesglosaIVA = False
        ImprimirFac = True
        Facturable = True
        ZonaVentaF = 0
        ZonaRepartoF = 0
        DescuentoDirecto = 0
        DescuentoPostVenta = 0
        Vendedor = ""
        UsoCFDI = "G03"
        AccesoWeb = False
        Password = ""
        CtaMaestra = ""
        cpyCtaMaestra = ""


        cmbOrigen.SelectedItem = IIf(TipoOrigen = 1, "Nacional", "Extranjero")
        TxtRegFiscal.Text = RegFiscal
        TxtClave.Text = Clave
        TxtFechaRegistro.Text = FechaReg.ToString("MMMM dd,yyyy")
        TxtNombreCorto.Text = NombreCorto
        TxtRazonSocial.Text = RazonSocial
        CmbTipoPersona.SelectedValue = TPersona
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
        ChkDesglosarIVA.Checked = DesglosaIVA
        chkImpresion.Checked = ImprimirFac
        chkFacturable.Checked = Facturable
        CmbTipo.SelectedValue = TipoImpuesto

        TxtMunicipioFac.Text = MnpioF
        TxtColoniaFac.Text = ColoniaF
        TxtDomicilioFac.Text = CalleF
        TxtLocalidadFac.Text = LocalidadF
        TxtCodigoPostalFac.Text = codigoPostalF
        TxtReferenciaFac.Text = referenciaF
        TxtNoInteriorFac.Text = noInteriorF
        TxtNoExteriorFac.Text = noExteriorF

        cmbResponsable.SelectedValue = Responsable

        cmbZonaVenta.SelectedValue = ZonaVentaF
        cmbZonaReparto.SelectedValue = ZonaRepartoF
        cmbVendedor.SelectedValue = Vendedor

        cmbDirecto.SelectedValue = DescuentoDirecto
        cmbPostVenta.SelectedValue = DescuentoPostVenta

        cmbUsoCFDI.SelectedValue = UsoCFDI

        txtCtaMaestra.Text = ""
        ChkAccesoWeb.Checked = AccesoWeb
        TxtContraseña.Text = Password
        TxtConfirmar.Text = Password

        TxtClave.Focus()
        Me.Panel1.VerticalScroll.Value = 0


        If MaxCredito = 0 OrElse Me.LCredito > MaxCredito Then
            TxtLimite.Enabled = False
            TxtDiasCredito.Enabled = False
        Else
            TxtLimite.Enabled = True
            TxtDiasCredito.Enabled = True
        End If

        cargaCanales()
        cargaPuntosdeEntrega()
        cargaMetodosPago()
        cargaClasificaciones()

        Me.reiniciaPuntodeEntrega("Modificar")

        cargaRiesgo()

    End Sub


    'Private Sub CmbColoniaFac_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If cargado = True AndAlso Not CmbColoniaFac.SelectedValue Is Nothing Then
    '        TxtCodigoPostalFac.Text = CmbColoniaFac.SelectedValue
    '    End If
    'End Sub

    Private Sub TxtEstadoFac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEstadoFac.LostFocus
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

    Private Sub TxtMunicipioFac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMunicipioFac.LostFocus
        If TxtEstadoFac.Text <> "" AndAlso TxtMunicipioFac.Text <> "" Then
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
            If TxtLocalidadFac.Text = "" OrElse TxtMunicipioFac.Text <> MnpioF Then
                Me.TxtLocalidadFac.Text = TxtMunicipioFac.Text
            End If
        End If
    End Sub

    Private Sub TxtColoniaFac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtColoniaFac.LostFocus
        If TxtColoniaFac.Text <> "" AndAlso TxtColoniaFac.Text <> ColoniaF AndAlso TxtEstadoFac.Text <> "" AndAlso TxtMunicipioFac.Text <> "" Then
            Dim dtCP As DataTable
            dtCP = ModPOS.Recupera_Tabla("sp_recupera_cp", "@Estado", TxtEstadoFac.Text.ToUpper.Trim, "@Municipio", TxtMunicipioFac.Text.Trim.ToUpper, "@Colonia", TxtColoniaFac.Text.Trim.ToUpper)
            If dtCP.Rows.Count > 0 Then
                Me.TxtCodigoPostalFac.Text = dtCP.Rows(0)("codigo_postal")
                dtCP.Dispose()
            End If
        End If
    End Sub

    Private Sub CmbTipoPersona_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbTipoPersona.SelectedIndexChanged
        If cargado = True AndAlso CmbTipoPersona.SelectedIndex = 1 Then
            TxtRFC.Mask = "&&&000000&&&" 'Persona Moral
        Else
            TxtRFC.Mask = "&&&&000000&&&" 'Persona Fisica
        End If
    End Sub


    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        Dim a As New FrmAddMetodoPago
        a.Padre = "Agregar"
        a.ShowDialog()
    End Sub

    Private Sub BtnModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModifica.Click
        If sMetodoPago <> "" Then
            Dim a As New FrmAddMetodoPago
            a.Padre = "Modificar"
            a.MTPClave = sMetodoPago
            a.MetodoPago = Me.GridMetodos.GetValue("MetodoPago")
            a.BNKClave = GridMetodos.GetValue("BNKClave")
            a.Referencia = GridMetodos.GetValue("Referencia")
            a.Estado = GridMetodos.GetValue("TipoEstado")
            a.Preferido = GridMetodos.GetValue("Preferido")
            a.ShowDialog()
        End If
    End Sub

    Private Sub BtnElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnElimina.Click
        If Me.sMetodoPago <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el metodo :" & sTipoMetodo & " " & sBanco & " " & sReferencia, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtMetodosPago.Select("MTPClave Like '" & sMetodoPago & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub GridMetodos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridMetodos.DoubleClick
        If Me.sMetodoPago <> "" Then
            Dim a As New FrmAddMetodoPago
            a.Padre = "Modificar"
            a.MTPClave = sMetodoPago
            a.MetodoPago = GridMetodos.GetValue("MetodoPago")
            a.Referencia = IIf(GridMetodos.GetValue("Referencia").GetType.Name = "DBNull", "", GridMetodos.GetValue("Referencia"))
            a.BNKClave = IIf(GridMetodos.GetValue("BNKClave").GetType.Name = "DBNull", "", GridMetodos.GetValue("BNKClave"))
            a.Estado = GridMetodos.GetValue("TipoEstado")
            a.Preferido = IIf(GridMetodos.GetValue("Preferido") = True, 1, 0)
            a.ShowDialog()
        End If
    End Sub

    Private Sub GridMetodos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridMetodos.SelectionChanged
        If Not Me.GridMetodos.GetValue("MTPClave") Is Nothing Then
            Me.BtnElimina.Enabled = True
            Me.sMetodoPago = GridMetodos.GetValue("MTPClave")
            sReferencia = IIf(GridMetodos.GetValue("Referencia").GetType.Name = "DBNull", "", GridMetodos.GetValue("Referencia"))
            sBanco = IIf(GridMetodos.GetValue("Banco").GetType.Name = "DBNull", "", GridMetodos.GetValue("Banco"))
            Me.sTipoMetodo = GridMetodos.GetValue("Tipo")
            Me.BtnModifica.Enabled = True
        Else
            Me.sMetodoPago = ""
            Me.sReferencia = ""
            Me.sBanco = ""
            Me.sTipoMetodo = ""
            Me.BtnElimina.Enabled = False
            Me.BtnModifica.Enabled = False
        End If
    End Sub


    Private Sub TxtEstado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEstado.LostFocus
        If TxtEstado.Text <> "" AndAlso TxtEstado.Text <> Entidad Then
            Dim dtMnpio As DataTable
            dtMnpio = ModPOS.Recupera_Tabla("sp_recupera_mnpio", "@Estado", TxtEstado.Text.Trim.ToUpper)
            If dtMnpio.Rows.Count > 0 Then
                ReDim aMnpio(dtMnpio.Rows.Count - 1)
                For i As Integer = 0 To dtMnpio.Rows.Count - 1
                    aMnpio(i) = dtMnpio.Rows(i)("d_mnpio")
                Next
                Me.TxtMunicipio.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.TxtMunicipio.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.TxtMunicipio.AutoCompleteCustomSource.AddRange(aMnpio)
                dtMnpio.Dispose()
            End If
        End If
    End Sub

    Private Sub TxtMunicipio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMunicipio.LostFocus
        If TxtEstado.Text <> "" AndAlso TxtMunicipio.Text <> "" Then
            Dim dtColonia As DataTable
            dtColonia = ModPOS.Recupera_Tabla("sp_recupera_colonia", "@Estado", TxtEstado.Text.ToUpper.Trim, "@Municipio", TxtMunicipio.Text.Trim.ToUpper)
            If dtColonia.Rows.Count > 0 Then
                ReDim aColonia(dtColonia.Rows.Count - 1)
                For i As Integer = 0 To dtColonia.Rows.Count - 1
                    aColonia(i) = dtColonia.Rows(i)("Nombre")
                Next
                Me.TxtColonia.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.TxtColonia.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.TxtColonia.AutoCompleteCustomSource.AddRange(aColonia)
                dtColonia.Dispose()
            End If
            If TxtLocalidad.Text = "" OrElse TxtMunicipio.Text <> Mnpio Then
                Me.TxtLocalidad.Text = TxtMunicipio.Text
            End If
        End If

    End Sub

    Private Sub TxtColonia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtColonia.LostFocus
        If TxtColonia.Text <> "" AndAlso TxtColonia.Text <> Colonia AndAlso TxtEstado.Text <> "" AndAlso TxtMunicipio.Text <> "" AndAlso TxtMunicipio.Text <> Mnpio Then
            Dim dtCP As DataTable
            dtCP = ModPOS.Recupera_Tabla("sp_recupera_cp", "@Estado", TxtEstado.Text.ToUpper.Trim, "@Municipio", TxtMunicipio.Text.Trim.ToUpper, "@Colonia", TxtColonia.Text.Trim.ToUpper)
            If dtCP.Rows.Count > 0 Then
                Me.TxtCodigoPostal.Text = dtCP.Rows(0)("codigo_postal")
                dtCP.Dispose()
            End If
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
        Else
            MessageBox.Show("El producto actual ya cuenta con una clasificación de Grupo igual al que desea agregar, elimine la anterior para poder agregar otra", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        ModPOS.ActualizaGrid(False, a.GridSearch, "sp_filtra_clasificacion", "@TClasificacion", 1, "@TGrupo", 0, "@COMClave", ModPOS.CompanyActual)
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
            Select Case MessageBox.Show("Se eliminara del cliente actual la clasificación: " & GridClasificaciones.GetValue("Referencia"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
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
                dt = ModPOS.Recupera_Tabla("sp_busca_clasificacion", "@Tipo", 1, "@Grupo", 0, "@Referencia", TxtClasificacion.Text, "@COMClave", ModPOS.CompanyActual)

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
                    MessageBox.Show("No se encontro clasificación de cliente que coincida con la referencia", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                End If
                dt.Dispose()

            End If
        ElseIf e.KeyCode = Keys.Right Then
            BtnBuscaClasificacion.PerformClick()
        End If
    End Sub


    Private Sub cmbTipoCanal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoCanal.SelectedIndexChanged
        If Not cmbTipoCanal.SelectedValue Is Nothing AndAlso cargado Then
            With Me.cmbListaPrecio
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "st_listas_canal"
                .NombreParametro1 = "TipoCanal"
                .Parametro1 = cmbTipoCanal.SelectedValue
                .NombreParametro2 = "COMClave"
                .Parametro2 = ModPOS.CompanyActual
                .NombreParametro3 = "Responsable"
                .Parametro3 = CStr(cmbResponsable.SelectedValue)
                .llenar()
            End With
        End If
    End Sub


    Private Sub btnDirecto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDirecto.Click
        Dim b As New FrmAddExcepcion
        b.Text &= " [Directo]"
        b.ClienteSAP = ClienteSAP
        b.dtDescuento = dtDirecto
        b.TipoDescuento = 1
        b.ShowDialog()
        dtDirecto = b.dtDescuento
        b.Dispose()

    End Sub

    Private Sub btnPostventa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPostventa.Click
        Dim b As New FrmAddExcepcion
        b.Text &= " [PostVenta]"
        b.ClienteSAP = ClienteSAP
        b.dtDescuento = dtPostVenta
        b.TipoDescuento = 2
        b.ShowDialog()
        dtPostVenta = b.dtDescuento
        b.Dispose()
    End Sub

    Private Sub GridDomicilios_SelectionChanged(sender As Object, e As EventArgs) Handles GridDomicilios.SelectionChanged
        If Not GridDomicilios.GetValue(0) Is Nothing Then
            Me.BtnDelDomi.Enabled = True
        Else
            Me.BtnDelDomi.Enabled = False
        End If
    End Sub

    Private Sub btnDelClase_Click(sender As Object, e As EventArgs) Handles btnDelClase.Click
        If sGestionSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la clase de riesgo seleccionada", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtClase.Select(" Riesgo = '" & sGestionSelected & "'")
                    foundRows(0)("Baja") = 1

            End Select
        End If
    End Sub

    Private Sub btnAddClase_Click(sender As Object, e As EventArgs) Handles btnAddClase.Click
        Dim foundRows() As System.Data.DataRow
        foundRows = dtClase.Select("Baja = 0")

        If foundRows.GetLength(0) = 0 Then
            Dim row1 As DataRow
            row1 = dtClase.NewRow()
            'Valor,Descripcion,Orden,0 as Modificado,Baja 
            row1.Item("GESClave") = ""
            row1.Item("Riesgo") = ""
            row1.Item("TotalComprometido") = 0.0
            row1.Item("TotalVencido") = 0.0
            row1.Item("Bloqueado") = 0
            row1.Item("Verificación") = Today.Date
            row1.Item("Demora") = 0
            row1.Item("SaldoPreventa") = 0.0
            row1.Item("Modificado") = 0
            row1.Item("Baja") = 0
            dtClase.Rows.Add(row1)
        Else
            MessageBox.Show("El cliente actual ya cuentan con una clase de riesgo asociada, modifique el registro actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub GridClases_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridClases.CellEdited
        Select Case GridClases.CurrentColumn.Caption
            Case "Riesgo"

                If GridClases.GetValue("Riesgo").GetType.Name = "DBNull" OrElse CStr(GridClases.GetValue("Riesgo")).Length = 0 Then
                    GridClases.SetValue("Modificado", 1)
                Else
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtRiesgo.Select(" IdRiesgo = '" & GridClases.GetValue("Riesgo") & "'")

                    If foundRows.GetLength(0) = 0 Then
                        MessageBox.Show("¡La Clase de riesgo que intenta agregar no es valida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridClases.SetValue("Riesgo", "ERROR")
                        GridClases.SetValue("Modificado", 0)
                    Else
                        GridClases.SetValue("Modificado", 1)
                    End If
                End If
            Case "Verificación"
                If Not IsDate(GridClases.GetValue("Verificación")) Then
                    GridClases.SetValue("Verificación", Today.Date)
                    GridClases.SetValue("Modificado", 1)
                Else
                    If CDate(GridClases.GetValue("Verificación")) < Today.Date Then
                        MessageBox.Show("¡La fecha de verficación no debe ser menor a la fecha actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridClases.SetValue("Verificación", Today.Date)
                        GridClases.SetValue("Modificado", 1)
                    Else
                        GridClases.SetValue("Modificado", 1)
                    End If

                End If
        End Select

    End Sub

    Private Sub GridClases_SelectionChanged(sender As Object, e As EventArgs) Handles GridClases.SelectionChanged
        If Not GridClases.GetValue(0) Is Nothing Then
            Me.btnDelClase.Enabled = True
            Me.sGestionSelected = GridClases.GetValue("Riesgo")
        Else
            Me.btnDelClase.Enabled = False
            Me.sGestionSelected = ""

        End If

    End Sub



    Private Sub cmbOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOrigen.SelectedIndexChanged
        If cargado = True Then
            If cmbOrigen.SelectedIndex = 0 Then
                lblRegFiscal.Visible = False
                TxtRegFiscal.Visible = False
            Else
                lblRegFiscal.Visible = True
                TxtRegFiscal.Visible = True
            End If
        End If
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                recuperaCtaMaestra(a.valor, False)
            End If
        End If
        a.Dispose()
    End Sub

   

    Private Sub cmbTipoCanal2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoCanal2.SelectedIndexChanged
        If Not cmbTipoCanal2.SelectedValue Is Nothing AndAlso cargado Then
            With Me.cmbListaPrecio2
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "st_listas_canal"
                .NombreParametro1 = "TipoCanal"
                .Parametro1 = cmbTipoCanal2.SelectedValue
                .NombreParametro2 = "COMClave"
                .Parametro2 = ModPOS.CompanyActual
                .llenar()
            End With
        End If
    End Sub

    Private Sub btnAddCanal_Click(sender As Object, e As EventArgs) Handles btnAddCanal.Click
        If Not (cmbTipoCanal2.SelectedValue Is Nothing OrElse cmbListaPrecio2.SelectedValue Is Nothing) Then
            Dim foundRows() As System.Data.DataRow
            foundRows = dtCanal.Select("TipoCanal = " & CStr(cmbTipoCanal2.SelectedValue) & " and Baja = 0")
            If foundRows.GetLength(0) = 0 Then
                Dim row1 As DataRow
                row1 = dtCanal.NewRow()
                'Valor,Descripcion,Orden,0 as Modificado,Baja 
                row1.Item("TipoCanal") = cmbTipoCanal2.SelectedValue
                row1.Item("Lista") = cmbListaPrecio2.SelectedValue
                row1.Item("Modificado") = 1
                row1.Item("Baja") = 0
                dtCanal.Rows.Add(row1)
            Else
                MessageBox.Show("El cliente actual ya cuenta con el Canal de Venta seleccionado ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Debe seleccionar un Canal y Lista de Precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnDelCanal_Click(sender As Object, e As EventArgs) Handles btnDelCanal.Click
        If sCanalSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el Canal de Venta seleccionado", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtCanal.Select(" TipoCanal = " & sCanalSelected & " and Baja = 0")
                    foundRows(0)("Baja") = 1
            End Select
        End If
    End Sub

    Private Sub gridCanales_SelectionChanged(sender As Object, e As EventArgs) Handles gridCanales.SelectionChanged
        If Not gridCanales.GetValue(0) Is Nothing Then
            Me.btnDelCanal.Enabled = True
            Me.sCanalSelected = CStr(gridCanales.GetValue("TipoCanal"))
        Else
            Me.btnDelCanal.Enabled = False
            Me.sCanalSelected = ""

        End If
    End Sub

    Private Sub chkFacturable_CheckedChanged(sender As Object, e As EventArgs) Handles chkFacturable.CheckedChanged
        If chkFacturable.Checked AndAlso Facturable = False Then
            Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_facturas", "@CTEClave", CTEClave, "@SUCClave", cmbResponsable.SelectedValue)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("facturasVencidas") > 0 Then
                    MessageBox.Show("El cliente cuenta con facturas por pagar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    chkFacturable.Checked = False
                End If
            End If

            dt.Dispose()
        End If
    End Sub
End Class
