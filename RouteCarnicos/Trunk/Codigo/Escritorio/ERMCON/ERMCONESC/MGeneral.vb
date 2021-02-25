Imports System.IO
Imports System.Text.RegularExpressions
Public Class MGeneral
    Inherits System.Windows.Forms.Form

    Private vcConfig As ERMCONLOG.cConfiguracion
    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private cnNuevo As Boolean = False
    Private vcClave As New lbGeneral.cKeyGen
    Private vcMensaje As BASMENLOG.CMensaje
    Private vcGuardando As Boolean = False
    Private vcCambioLogo As Boolean = False
    Private vcUsuario As String
    Private vcHuboCambios As Boolean = False
    Private vcCerrar As Boolean = False
    Private vcIniciando As Boolean = False
    Private vcAcceso As LbAcceso.cAcceso
    Private vcActualizarPEM As Boolean

    Friend WithEvents chbMostrarLogo As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbCambioProducto As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbFiltros As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbConversionKg As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbPagoAutomatico As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbAbonoProgramado As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbCobrarVentas As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbModificarVenta As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbClienteVariasRutas As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbCodigoBarrasCliente As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbContrasenaCliente As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbValidaInv As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tabGenerales As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tabProductos As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tabVenta As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel4 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tabVisita As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel5 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tabComunicacion As DevComponents.DotNetBar.TabItem
    Friend WithEvents lbLimiteGPS As System.Windows.Forms.Label
    Friend WithEvents lblIniciarVisita As System.Windows.Forms.Label
    Friend WithEvents ebLimiteGPS As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chbClientesVisitados As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbDatosCteNuevo As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbVenderApartado As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents lbDecimalesImporte As System.Windows.Forms.Label
    Friend WithEvents ebDecimalesImporte As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents cbIniciarVisita As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents chbVentaSinSurtir As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents TabControlPanel6 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tabCorreoElectronico As DevComponents.DotNetBar.TabItem
    Friend WithEvents ebPassword As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblContrasenia As System.Windows.Forms.Label
    Friend WithEvents ebServidorSMTP As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblSMTP As System.Windows.Forms.Label
    Friend WithEvents ebCorreoElectronico As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblPuerto As System.Windows.Forms.Label
    Friend WithEvents lblCorreoElectronico As System.Windows.Forms.Label
    Friend WithEvents ebPuerto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblCOnfirmar As System.Windows.Forms.Label
    Friend WithEvents ebConfirmarPassword As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chbSSL As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents lbPorcentajeInteres As System.Windows.Forms.Label
    Friend WithEvents nbPorcentajeInteres As Janus.Windows.GridEX.EditControls.NumericEditBox
    Private vcFrmBrowseCliente As ERMCLIESC.IGeneral

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
    Friend WithEvents LbEmpresa As System.Windows.Forms.Label
    Friend WithEvents LbPais As System.Windows.Forms.Label
    Friend WithEvents LbRegion As System.Windows.Forms.Label
    Friend WithEvents LbCiudad As System.Windows.Forms.Label
    Friend WithEvents ebEmpresa As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPais As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EbRegion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents EbCiudad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents LbInicio As System.Windows.Forms.Label
    Friend WithEvents lbLenguaje As System.Windows.Forms.Label
    Friend WithEvents LbMoneda As System.Windows.Forms.Label
    Friend WithEvents PbLogo As System.Windows.Forms.PictureBox
    Friend WithEvents cbLenguaje As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents cbMoneda As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents btAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cbFechaInicio As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents lblogotipo As System.Windows.Forms.Label
    Friend WithEvents btHistorico As Janus.Windows.EditControls.UIButton
    Friend WithEvents gbParametros As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents epErrores As System.Windows.Forms.ErrorProvider
    Friend WithEvents lbRFC As System.Windows.Forms.Label
    Friend WithEvents ebRFC As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbCalle As System.Windows.Forms.Label
    Friend WithEvents ebCalle As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbNumero As System.Windows.Forms.Label
    Friend WithEvents ebNumero As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbColonia As System.Windows.Forms.Label
    Friend WithEvents ebColonia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbTipoClaveProducto As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents ebDigitoClaveProd As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lbTipoClaveProducto As System.Windows.Forms.Label
    Friend WithEvents lbDigitoClaveProd As System.Windows.Forms.Label
    Friend WithEvents lbCantidadServicios As System.Windows.Forms.Label
    Friend WithEvents lbDiasSurtido As System.Windows.Forms.Label
    Friend WithEvents nudDiasSurtido As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents nudServiciosActivos As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lbDirectorioSDF As System.Windows.Forms.Label
    Friend WithEvents btSeleccionarDir As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebDirSDF As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents txtRinterfaz As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lblDirInterfaces As System.Windows.Forms.Label
    Friend WithEvents chbIntUnidadVta As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbInterfaz As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbEliminaEnviado As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbPreLiquidacion As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents lbDifPreliquidacion As System.Windows.Forms.Label
    Friend WithEvents ebDifPreliquidacion As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lbDiasAnteriores As System.Windows.Forms.Label
    Friend WithEvents lbDiasPosteriores As System.Windows.Forms.Label
    Friend WithEvents nudDiasAnteriores As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents nudDiasPosteriores As Janus.Windows.GridEX.EditControls.IntegerUpDown
    Friend WithEvents chbAuditarCarga As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbEnvioParcial As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbInventario As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents cbTipoLimiteCredito As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbTipoLimiteCredito As System.Windows.Forms.Label
    Friend WithEvents lbPorcentajeRiesgo As System.Windows.Forms.Label
    Friend WithEvents ebPorcentajeRiesgo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lbTelefono As System.Windows.Forms.Label
    Friend WithEvents ebTelefono As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbTicketConfigurado As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lblTicketConfigurado As System.Windows.Forms.Label
    Friend WithEvents btVistaPrevia As Janus.Windows.EditControls.UIButton
    Friend WithEvents pnGenerales As System.Windows.Forms.Panel
    Friend WithEvents pnProductos As System.Windows.Forms.Panel
    Friend WithEvents pnVenta As System.Windows.Forms.Panel
    Friend WithEvents pnVisita As System.Windows.Forms.Panel
    Friend WithEvents pnComunicacion As System.Windows.Forms.Panel
    Friend WithEvents lbCodigoPostal As System.Windows.Forms.Label
    Friend WithEvents lbNumeroInterior As System.Windows.Forms.Label
    Friend WithEvents ebNumeroInterior As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodigoPostal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbReferenciaDom As System.Windows.Forms.Label
    Friend WithEvents ebReferenciaDom As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbLocalidad As System.Windows.Forms.Label
    Friend WithEvents ebLocalidad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btInterfaces As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MGeneral))
        Me.LbEmpresa = New System.Windows.Forms.Label
        Me.LbPais = New System.Windows.Forms.Label
        Me.LbRegion = New System.Windows.Forms.Label
        Me.LbCiudad = New System.Windows.Forms.Label
        Me.PbLogo = New System.Windows.Forms.PictureBox
        Me.ebEmpresa = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebPais = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EbRegion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.EbCiudad = New Janus.Windows.GridEX.EditControls.EditBox
        Me.gbParametros = New Janus.Windows.EditControls.UIGroupBox
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel
        Me.pnVenta = New System.Windows.Forms.Panel
        Me.lbPorcentajeInteres = New System.Windows.Forms.Label
        Me.nbPorcentajeInteres = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.chbVentaSinSurtir = New Janus.Windows.EditControls.UICheckBox
        Me.lbDecimalesImporte = New System.Windows.Forms.Label
        Me.ebDecimalesImporte = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.chbVenderApartado = New Janus.Windows.EditControls.UICheckBox
        Me.chbPagoAutomatico = New Janus.Windows.EditControls.UICheckBox
        Me.chbModificarVenta = New Janus.Windows.EditControls.UICheckBox
        Me.btVistaPrevia = New Janus.Windows.EditControls.UIButton
        Me.cbTicketConfigurado = New Janus.Windows.EditControls.UIComboBox
        Me.lblTicketConfigurado = New System.Windows.Forms.Label
        Me.lbPorcentajeRiesgo = New System.Windows.Forms.Label
        Me.ebPorcentajeRiesgo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.cbTipoLimiteCredito = New Janus.Windows.EditControls.UIComboBox
        Me.lbTipoLimiteCredito = New System.Windows.Forms.Label
        Me.chbCobrarVentas = New Janus.Windows.EditControls.UICheckBox
        Me.chbAbonoProgramado = New Janus.Windows.EditControls.UICheckBox
        Me.tabVenta = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.pnGenerales = New System.Windows.Forms.Panel
        Me.chbMostrarLogo = New Janus.Windows.EditControls.UICheckBox
        Me.LbMoneda = New System.Windows.Forms.Label
        Me.cbMoneda = New Janus.Windows.EditControls.UIComboBox
        Me.cbLenguaje = New Janus.Windows.EditControls.UIComboBox
        Me.lbLenguaje = New System.Windows.Forms.Label
        Me.tabGenerales = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel
        Me.pnProductos = New System.Windows.Forms.Panel
        Me.chbFiltros = New Janus.Windows.EditControls.UICheckBox
        Me.chbConversionKg = New Janus.Windows.EditControls.UICheckBox
        Me.chbCambioProducto = New Janus.Windows.EditControls.UICheckBox
        Me.nudDiasSurtido = New Janus.Windows.GridEX.EditControls.IntegerUpDown
        Me.cbTipoClaveProducto = New Janus.Windows.EditControls.UIComboBox
        Me.lbDiasSurtido = New System.Windows.Forms.Label
        Me.lbDigitoClaveProd = New System.Windows.Forms.Label
        Me.ebDigitoClaveProd = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.lbTipoClaveProducto = New System.Windows.Forms.Label
        Me.tabProductos = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel
        Me.pnVisita = New System.Windows.Forms.Panel
        Me.chbDatosCteNuevo = New Janus.Windows.EditControls.UICheckBox
        Me.chbClientesVisitados = New Janus.Windows.EditControls.UICheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.nudDiasAnteriores = New Janus.Windows.GridEX.EditControls.IntegerUpDown
        Me.ebLimiteGPS = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.lbLimiteGPS = New System.Windows.Forms.Label
        Me.cbIniciarVisita = New Janus.Windows.EditControls.UIComboBox
        Me.lblIniciarVisita = New System.Windows.Forms.Label
        Me.chbValidaInv = New Janus.Windows.EditControls.UICheckBox
        Me.chbContrasenaCliente = New Janus.Windows.EditControls.UICheckBox
        Me.chbClienteVariasRutas = New Janus.Windows.EditControls.UICheckBox
        Me.lbDiasAnteriores = New System.Windows.Forms.Label
        Me.nudDiasPosteriores = New Janus.Windows.GridEX.EditControls.IntegerUpDown
        Me.lbDiasPosteriores = New System.Windows.Forms.Label
        Me.chbCodigoBarrasCliente = New Janus.Windows.EditControls.UICheckBox
        Me.tabVisita = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel5 = New DevComponents.DotNetBar.TabControlPanel
        Me.pnComunicacion = New System.Windows.Forms.Panel
        Me.btInterfaces = New Janus.Windows.EditControls.UIButton
        Me.ebDirSDF = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblDirInterfaces = New System.Windows.Forms.Label
        Me.nudServiciosActivos = New Janus.Windows.GridEX.EditControls.IntegerUpDown
        Me.chbAuditarCarga = New Janus.Windows.EditControls.UICheckBox
        Me.lbCantidadServicios = New System.Windows.Forms.Label
        Me.lbDifPreliquidacion = New System.Windows.Forms.Label
        Me.ebDifPreliquidacion = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.chbPreLiquidacion = New Janus.Windows.EditControls.UICheckBox
        Me.chbInventario = New Janus.Windows.EditControls.UICheckBox
        Me.btSeleccionarDir = New Janus.Windows.EditControls.UIButton
        Me.lbDirectorioSDF = New System.Windows.Forms.Label
        Me.chbEliminaEnviado = New Janus.Windows.EditControls.UICheckBox
        Me.chbIntUnidadVta = New Janus.Windows.EditControls.UICheckBox
        Me.txtRinterfaz = New Janus.Windows.GridEX.EditControls.EditBox
        Me.chbEnvioParcial = New Janus.Windows.EditControls.UICheckBox
        Me.chbInterfaz = New Janus.Windows.EditControls.UICheckBox
        Me.tabComunicacion = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel6 = New DevComponents.DotNetBar.TabControlPanel
        Me.chbSSL = New Janus.Windows.EditControls.UICheckBox
        Me.lblCOnfirmar = New System.Windows.Forms.Label
        Me.ebPuerto = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebConfirmarPassword = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebPassword = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblContrasenia = New System.Windows.Forms.Label
        Me.ebServidorSMTP = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblSMTP = New System.Windows.Forms.Label
        Me.ebCorreoElectronico = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lblPuerto = New System.Windows.Forms.Label
        Me.lblCorreoElectronico = New System.Windows.Forms.Label
        Me.tabCorreoElectronico = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.cbFechaInicio = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.btHistorico = New Janus.Windows.EditControls.UIButton
        Me.LbInicio = New System.Windows.Forms.Label
        Me.epErrores = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btAceptar = New Janus.Windows.EditControls.UIButton
        Me.btCancelar = New Janus.Windows.EditControls.UIButton
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblogotipo = New System.Windows.Forms.Label
        Me.lbRFC = New System.Windows.Forms.Label
        Me.ebRFC = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbCalle = New System.Windows.Forms.Label
        Me.ebCalle = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbNumero = New System.Windows.Forms.Label
        Me.ebNumero = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbColonia = New System.Windows.Forms.Label
        Me.ebColonia = New Janus.Windows.GridEX.EditControls.EditBox
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.lbTelefono = New System.Windows.Forms.Label
        Me.ebTelefono = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbCodigoPostal = New System.Windows.Forms.Label
        Me.lbNumeroInterior = New System.Windows.Forms.Label
        Me.ebNumeroInterior = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebCodigoPostal = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbReferenciaDom = New System.Windows.Forms.Label
        Me.ebReferenciaDom = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbLocalidad = New System.Windows.Forms.Label
        Me.ebLocalidad = New Janus.Windows.GridEX.EditControls.EditBox
        CType(Me.PbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbParametros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbParametros.SuspendLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel3.SuspendLayout()
        Me.pnVenta.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.pnGenerales.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.pnProductos.SuspendLayout()
        Me.TabControlPanel4.SuspendLayout()
        Me.pnVisita.SuspendLayout()
        Me.TabControlPanel5.SuspendLayout()
        Me.pnComunicacion.SuspendLayout()
        Me.TabControlPanel6.SuspendLayout()
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LbEmpresa
        '
        Me.LbEmpresa.Location = New System.Drawing.Point(164, 12)
        Me.LbEmpresa.Name = "LbEmpresa"
        Me.LbEmpresa.Size = New System.Drawing.Size(132, 20)
        Me.LbEmpresa.TabIndex = 1
        Me.LbEmpresa.Text = "Empresa"
        Me.LbEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LbPais
        '
        Me.LbPais.Location = New System.Drawing.Point(524, 194)
        Me.LbPais.Name = "LbPais"
        Me.LbPais.Size = New System.Drawing.Size(132, 20)
        Me.LbPais.TabIndex = 25
        Me.LbPais.Text = "Pais"
        Me.LbPais.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LbRegion
        '
        Me.LbRegion.Location = New System.Drawing.Point(164, 194)
        Me.LbRegion.Name = "LbRegion"
        Me.LbRegion.Size = New System.Drawing.Size(132, 20)
        Me.LbRegion.TabIndex = 23
        Me.LbRegion.Text = "Región"
        Me.LbRegion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LbCiudad
        '
        Me.LbCiudad.Location = New System.Drawing.Point(524, 168)
        Me.LbCiudad.Name = "LbCiudad"
        Me.LbCiudad.Size = New System.Drawing.Size(132, 20)
        Me.LbCiudad.TabIndex = 21
        Me.LbCiudad.Text = "Ciudad"
        Me.LbCiudad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PbLogo
        '
        Me.PbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PbLogo.Image = CType(resources.GetObject("PbLogo.Image"), System.Drawing.Image)
        Me.PbLogo.Location = New System.Drawing.Point(44, 12)
        Me.PbLogo.Name = "PbLogo"
        Me.PbLogo.Size = New System.Drawing.Size(73, 72)
        Me.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PbLogo.TabIndex = 1
        Me.PbLogo.TabStop = False
        '
        'ebEmpresa
        '
        Me.ebEmpresa.Location = New System.Drawing.Point(300, 12)
        Me.ebEmpresa.MaxLength = 60
        Me.ebEmpresa.Name = "ebEmpresa"
        Me.ebEmpresa.Size = New System.Drawing.Size(572, 20)
        Me.ebEmpresa.TabIndex = 2
        Me.ebEmpresa.Tag = "NombreEmpresa"
        Me.ebEmpresa.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEmpresa.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebPais
        '
        Me.ebPais.Location = New System.Drawing.Point(660, 194)
        Me.ebPais.MaxLength = 40
        Me.ebPais.Name = "ebPais"
        Me.ebPais.Size = New System.Drawing.Size(212, 20)
        Me.ebPais.TabIndex = 26
        Me.ebPais.Tag = "Pais"
        Me.ebPais.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPais.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'EbRegion
        '
        Me.EbRegion.Location = New System.Drawing.Point(300, 194)
        Me.EbRegion.MaxLength = 40
        Me.EbRegion.Name = "EbRegion"
        Me.EbRegion.Size = New System.Drawing.Size(212, 20)
        Me.EbRegion.TabIndex = 24
        Me.EbRegion.Tag = "Region"
        Me.EbRegion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EbRegion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'EbCiudad
        '
        Me.EbCiudad.Location = New System.Drawing.Point(660, 168)
        Me.EbCiudad.MaxLength = 40
        Me.EbCiudad.Name = "EbCiudad"
        Me.EbCiudad.Size = New System.Drawing.Size(212, 20)
        Me.EbCiudad.TabIndex = 22
        Me.EbCiudad.Tag = "Ciudad"
        Me.EbCiudad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.EbCiudad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbParametros
        '
        Me.gbParametros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbParametros.Controls.Add(Me.TabControl1)
        Me.gbParametros.Controls.Add(Me.cbFechaInicio)
        Me.gbParametros.Controls.Add(Me.btHistorico)
        Me.gbParametros.Controls.Add(Me.LbInicio)
        Me.gbParametros.Location = New System.Drawing.Point(8, 217)
        Me.gbParametros.Name = "gbParametros"
        Me.gbParametros.Size = New System.Drawing.Size(872, 285)
        Me.gbParametros.TabIndex = 27
        Me.gbParametros.Text = " Parámetros"
        Me.gbParametros.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'TabControl1
        '
        Me.TabControl1.CanReorderTabs = False
        Me.TabControl1.Controls.Add(Me.TabControlPanel3)
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Controls.Add(Me.TabControlPanel4)
        Me.TabControl1.Controls.Add(Me.TabControlPanel5)
        Me.TabControl1.Controls.Add(Me.TabControlPanel6)
        Me.TabControl1.Location = New System.Drawing.Point(4, 50)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(864, 229)
        Me.TabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005Document
        Me.TabControl1.TabIndex = 39
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.tabGenerales)
        Me.TabControl1.Tabs.Add(Me.tabProductos)
        Me.TabControl1.Tabs.Add(Me.tabVenta)
        Me.TabControl1.Tabs.Add(Me.tabVisita)
        Me.TabControl1.Tabs.Add(Me.tabComunicacion)
        Me.TabControl1.Tabs.Add(Me.tabCorreoElectronico)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.pnVenta)
        Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel3.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel3.Name = "TabControlPanel3"
        Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel3.Size = New System.Drawing.Size(864, 203)
        Me.TabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel3.Style.GradientAngle = 90
        Me.TabControlPanel3.TabIndex = 3
        Me.TabControlPanel3.TabItem = Me.tabVenta
        '
        'pnVenta
        '
        Me.pnVenta.BackColor = System.Drawing.Color.Transparent
        Me.pnVenta.Controls.Add(Me.lbPorcentajeInteres)
        Me.pnVenta.Controls.Add(Me.nbPorcentajeInteres)
        Me.pnVenta.Controls.Add(Me.chbVentaSinSurtir)
        Me.pnVenta.Controls.Add(Me.lbDecimalesImporte)
        Me.pnVenta.Controls.Add(Me.ebDecimalesImporte)
        Me.pnVenta.Controls.Add(Me.chbVenderApartado)
        Me.pnVenta.Controls.Add(Me.chbPagoAutomatico)
        Me.pnVenta.Controls.Add(Me.chbModificarVenta)
        Me.pnVenta.Controls.Add(Me.btVistaPrevia)
        Me.pnVenta.Controls.Add(Me.cbTicketConfigurado)
        Me.pnVenta.Controls.Add(Me.lblTicketConfigurado)
        Me.pnVenta.Controls.Add(Me.lbPorcentajeRiesgo)
        Me.pnVenta.Controls.Add(Me.ebPorcentajeRiesgo)
        Me.pnVenta.Controls.Add(Me.cbTipoLimiteCredito)
        Me.pnVenta.Controls.Add(Me.lbTipoLimiteCredito)
        Me.pnVenta.Controls.Add(Me.chbCobrarVentas)
        Me.pnVenta.Controls.Add(Me.chbAbonoProgramado)
        Me.pnVenta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnVenta.Location = New System.Drawing.Point(1, 1)
        Me.pnVenta.Name = "pnVenta"
        Me.pnVenta.Size = New System.Drawing.Size(862, 201)
        Me.pnVenta.TabIndex = 80
        '
        'lbPorcentajeInteres
        '
        Me.lbPorcentajeInteres.AutoSize = True
        Me.lbPorcentajeInteres.BackColor = System.Drawing.Color.Transparent
        Me.lbPorcentajeInteres.Location = New System.Drawing.Point(588, 90)
        Me.lbPorcentajeInteres.Name = "lbPorcentajeInteres"
        Me.lbPorcentajeInteres.Size = New System.Drawing.Size(98, 13)
        Me.lbPorcentajeInteres.TabIndex = 86
        Me.lbPorcentajeInteres.Text = "lbPorcentajeInteres"
        Me.lbPorcentajeInteres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nbPorcentajeInteres
        '
        Me.nbPorcentajeInteres.DecimalDigits = 2
        Me.nbPorcentajeInteres.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Percent
        Me.nbPorcentajeInteres.Location = New System.Drawing.Point(707, 87)
        Me.nbPorcentajeInteres.MaxLength = 6
        Me.nbPorcentajeInteres.Name = "nbPorcentajeInteres"
        Me.nbPorcentajeInteres.Size = New System.Drawing.Size(132, 20)
        Me.nbPorcentajeInteres.TabIndex = 10
        Me.nbPorcentajeInteres.Tag = "DigitoClaveProd"
        Me.nbPorcentajeInteres.Text = "0.00 %"
        Me.nbPorcentajeInteres.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.nbPorcentajeInteres.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.nbPorcentajeInteres.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'chbVentaSinSurtir
        '
        Me.chbVentaSinSurtir.AutoSize = True
        Me.chbVentaSinSurtir.Location = New System.Drawing.Point(409, 54)
        Me.chbVentaSinSurtir.Name = "chbVentaSinSurtir"
        Me.chbVentaSinSurtir.Size = New System.Drawing.Size(106, 17)
        Me.chbVentaSinSurtir.TabIndex = 7
        Me.chbVentaSinSurtir.Tag = "VenderApartado"
        Me.chbVentaSinSurtir.Text = "chbVentaSinSurtir"
        Me.chbVentaSinSurtir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbDecimalesImporte
        '
        Me.lbDecimalesImporte.AutoSize = True
        Me.lbDecimalesImporte.BackColor = System.Drawing.Color.Transparent
        Me.lbDecimalesImporte.Location = New System.Drawing.Point(588, 17)
        Me.lbDecimalesImporte.Name = "lbDecimalesImporte"
        Me.lbDecimalesImporte.Size = New System.Drawing.Size(94, 13)
        Me.lbDecimalesImporte.TabIndex = 84
        Me.lbDecimalesImporte.Text = "Decimales Importe"
        Me.lbDecimalesImporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebDecimalesImporte
        '
        Me.ebDecimalesImporte.DecimalDigits = 2
        Me.ebDecimalesImporte.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General
        Me.ebDecimalesImporte.Location = New System.Drawing.Point(707, 14)
        Me.ebDecimalesImporte.MaxLength = 2
        Me.ebDecimalesImporte.Name = "ebDecimalesImporte"
        Me.ebDecimalesImporte.Size = New System.Drawing.Size(132, 20)
        Me.ebDecimalesImporte.TabIndex = 4
        Me.ebDecimalesImporte.Tag = "DigitoClaveProd"
        Me.ebDecimalesImporte.Text = "0"
        Me.ebDecimalesImporte.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebDecimalesImporte.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ebDecimalesImporte.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'chbVenderApartado
        '
        Me.chbVenderApartado.AutoSize = True
        Me.chbVenderApartado.Location = New System.Drawing.Point(409, 17)
        Me.chbVenderApartado.Name = "chbVenderApartado"
        Me.chbVenderApartado.Size = New System.Drawing.Size(116, 17)
        Me.chbVenderApartado.TabIndex = 3
        Me.chbVenderApartado.Tag = "VenderApartado"
        Me.chbVenderApartado.Text = "chbVenderApartado"
        Me.chbVenderApartado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chbPagoAutomatico
        '
        Me.chbPagoAutomatico.AutoSize = True
        Me.chbPagoAutomatico.Location = New System.Drawing.Point(203, 54)
        Me.chbPagoAutomatico.Name = "chbPagoAutomatico"
        Me.chbPagoAutomatico.Size = New System.Drawing.Size(99, 17)
        Me.chbPagoAutomatico.TabIndex = 6
        Me.chbPagoAutomatico.Tag = "PagoAutomatico"
        Me.chbPagoAutomatico.Text = "PagoAutomatico"
        Me.chbPagoAutomatico.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chbModificarVenta
        '
        Me.chbModificarVenta.AutoSize = True
        Me.chbModificarVenta.Location = New System.Drawing.Point(8, 17)
        Me.chbModificarVenta.Name = "chbModificarVenta"
        Me.chbModificarVenta.Size = New System.Drawing.Size(110, 17)
        Me.chbModificarVenta.TabIndex = 1
        Me.chbModificarVenta.Tag = "chbModificarVenta"
        Me.chbModificarVenta.Text = "chbModificarVenta"
        Me.chbModificarVenta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btVistaPrevia
        '
        Me.btVistaPrevia.Icon = CType(resources.GetObject("btVistaPrevia.Icon"), System.Drawing.Icon)
        Me.btVistaPrevia.Location = New System.Drawing.Point(262, 121)
        Me.btVistaPrevia.Name = "btVistaPrevia"
        Me.btVistaPrevia.Size = New System.Drawing.Size(100, 24)
        Me.btVistaPrevia.TabIndex = 12
        Me.btVistaPrevia.Text = "Vista Previa"
        Me.btVistaPrevia.Visible = False
        Me.btVistaPrevia.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'cbTicketConfigurado
        '
        Me.cbTicketConfigurado.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTicketConfigurado.Location = New System.Drawing.Point(124, 122)
        Me.cbTicketConfigurado.Name = "cbTicketConfigurado"
        Me.cbTicketConfigurado.Size = New System.Drawing.Size(132, 20)
        Me.cbTicketConfigurado.TabIndex = 11
        Me.cbTicketConfigurado.Tag = "TipoLimiteCredito"
        Me.cbTicketConfigurado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lblTicketConfigurado
        '
        Me.lblTicketConfigurado.AutoSize = True
        Me.lblTicketConfigurado.BackColor = System.Drawing.Color.Transparent
        Me.lblTicketConfigurado.Location = New System.Drawing.Point(5, 126)
        Me.lblTicketConfigurado.Name = "lblTicketConfigurado"
        Me.lblTicketConfigurado.Size = New System.Drawing.Size(68, 13)
        Me.lblTicketConfigurado.TabIndex = 77
        Me.lblTicketConfigurado.Text = "Ticket Venta"
        Me.lblTicketConfigurado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbPorcentajeRiesgo
        '
        Me.lbPorcentajeRiesgo.AutoSize = True
        Me.lbPorcentajeRiesgo.BackColor = System.Drawing.Color.Transparent
        Me.lbPorcentajeRiesgo.Location = New System.Drawing.Point(588, 54)
        Me.lbPorcentajeRiesgo.Name = "lbPorcentajeRiesgo"
        Me.lbPorcentajeRiesgo.Size = New System.Drawing.Size(94, 13)
        Me.lbPorcentajeRiesgo.TabIndex = 75
        Me.lbPorcentajeRiesgo.Text = "Porcentaje Riesgo"
        Me.lbPorcentajeRiesgo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebPorcentajeRiesgo
        '
        Me.ebPorcentajeRiesgo.DecimalDigits = 2
        Me.ebPorcentajeRiesgo.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Percent
        Me.ebPorcentajeRiesgo.Location = New System.Drawing.Point(707, 51)
        Me.ebPorcentajeRiesgo.MaxLength = 6
        Me.ebPorcentajeRiesgo.Name = "ebPorcentajeRiesgo"
        Me.ebPorcentajeRiesgo.Size = New System.Drawing.Size(132, 20)
        Me.ebPorcentajeRiesgo.TabIndex = 8
        Me.ebPorcentajeRiesgo.Tag = "DigitoClaveProd"
        Me.ebPorcentajeRiesgo.Text = "0.00 %"
        Me.ebPorcentajeRiesgo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebPorcentajeRiesgo.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ebPorcentajeRiesgo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbTipoLimiteCredito
        '
        Me.cbTipoLimiteCredito.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipoLimiteCredito.Location = New System.Drawing.Point(124, 88)
        Me.cbTipoLimiteCredito.Name = "cbTipoLimiteCredito"
        Me.cbTipoLimiteCredito.Size = New System.Drawing.Size(132, 20)
        Me.cbTipoLimiteCredito.TabIndex = 9
        Me.cbTipoLimiteCredito.Tag = "TipoLimiteCredito"
        Me.cbTipoLimiteCredito.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbTipoLimiteCredito
        '
        Me.lbTipoLimiteCredito.AutoSize = True
        Me.lbTipoLimiteCredito.BackColor = System.Drawing.Color.Transparent
        Me.lbTipoLimiteCredito.Location = New System.Drawing.Point(5, 90)
        Me.lbTipoLimiteCredito.Name = "lbTipoLimiteCredito"
        Me.lbTipoLimiteCredito.Size = New System.Drawing.Size(94, 13)
        Me.lbTipoLimiteCredito.TabIndex = 73
        Me.lbTipoLimiteCredito.Text = "Tipo Limite Credito"
        Me.lbTipoLimiteCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chbCobrarVentas
        '
        Me.chbCobrarVentas.AutoSize = True
        Me.chbCobrarVentas.Checked = True
        Me.chbCobrarVentas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbCobrarVentas.Enabled = False
        Me.chbCobrarVentas.Location = New System.Drawing.Point(8, 54)
        Me.chbCobrarVentas.Name = "chbCobrarVentas"
        Me.chbCobrarVentas.Size = New System.Drawing.Size(103, 17)
        Me.chbCobrarVentas.TabIndex = 5
        Me.chbCobrarVentas.Tag = "chbCobrarVentas"
        Me.chbCobrarVentas.Text = "chbCobrarVentas"
        Me.chbCobrarVentas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chbAbonoProgramado
        '
        Me.chbAbonoProgramado.AutoSize = True
        Me.chbAbonoProgramado.Location = New System.Drawing.Point(203, 17)
        Me.chbAbonoProgramado.Name = "chbAbonoProgramado"
        Me.chbAbonoProgramado.Size = New System.Drawing.Size(109, 17)
        Me.chbAbonoProgramado.TabIndex = 2
        Me.chbAbonoProgramado.Tag = "AbonoProgramado"
        Me.chbAbonoProgramado.Text = "AbonoProgramado"
        Me.chbAbonoProgramado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'tabVenta
        '
        Me.tabVenta.AttachedControl = Me.TabControlPanel3
        Me.tabVenta.Name = "tabVenta"
        Me.tabVenta.Text = "tabVenta"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.pnGenerales)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(864, 203)
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.tabGenerales
        '
        'pnGenerales
        '
        Me.pnGenerales.BackColor = System.Drawing.Color.Transparent
        Me.pnGenerales.Controls.Add(Me.chbMostrarLogo)
        Me.pnGenerales.Controls.Add(Me.LbMoneda)
        Me.pnGenerales.Controls.Add(Me.cbMoneda)
        Me.pnGenerales.Controls.Add(Me.cbLenguaje)
        Me.pnGenerales.Controls.Add(Me.lbLenguaje)
        Me.pnGenerales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnGenerales.Location = New System.Drawing.Point(1, 1)
        Me.pnGenerales.Name = "pnGenerales"
        Me.pnGenerales.Size = New System.Drawing.Size(862, 201)
        Me.pnGenerales.TabIndex = 74
        '
        'chbMostrarLogo
        '
        Me.chbMostrarLogo.Location = New System.Drawing.Point(572, 8)
        Me.chbMostrarLogo.Name = "chbMostrarLogo"
        Me.chbMostrarLogo.Size = New System.Drawing.Size(267, 23)
        Me.chbMostrarLogo.TabIndex = 74
        Me.chbMostrarLogo.Text = "MostrarLogo"
        Me.chbMostrarLogo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LbMoneda
        '
        Me.LbMoneda.BackColor = System.Drawing.Color.Transparent
        Me.LbMoneda.Location = New System.Drawing.Point(288, 8)
        Me.LbMoneda.Name = "LbMoneda"
        Me.LbMoneda.Size = New System.Drawing.Size(132, 20)
        Me.LbMoneda.TabIndex = 5
        Me.LbMoneda.Text = "Moneda"
        Me.LbMoneda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbMoneda
        '
        Me.cbMoneda.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbMoneda.Location = New System.Drawing.Point(424, 8)
        Me.cbMoneda.Name = "cbMoneda"
        Me.cbMoneda.Size = New System.Drawing.Size(132, 20)
        Me.cbMoneda.TabIndex = 6
        Me.cbMoneda.Tag = "MonedaId"
        Me.cbMoneda.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cbLenguaje
        '
        Me.cbLenguaje.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbLenguaje.Location = New System.Drawing.Point(140, 8)
        Me.cbLenguaje.Name = "cbLenguaje"
        Me.cbLenguaje.Size = New System.Drawing.Size(132, 20)
        Me.cbLenguaje.TabIndex = 4
        Me.cbLenguaje.Tag = "TipoLenguaje"
        Me.cbLenguaje.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbLenguaje
        '
        Me.lbLenguaje.BackColor = System.Drawing.Color.Transparent
        Me.lbLenguaje.Location = New System.Drawing.Point(4, 8)
        Me.lbLenguaje.Name = "lbLenguaje"
        Me.lbLenguaje.Size = New System.Drawing.Size(132, 20)
        Me.lbLenguaje.TabIndex = 3
        Me.lbLenguaje.Text = "Lenguaje"
        Me.lbLenguaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabGenerales
        '
        Me.tabGenerales.AttachedControl = Me.TabControlPanel1
        Me.tabGenerales.Name = "tabGenerales"
        Me.tabGenerales.Text = "tabGenerales"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.pnProductos)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(864, 203)
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.tabProductos
        '
        'pnProductos
        '
        Me.pnProductos.BackColor = System.Drawing.Color.Transparent
        Me.pnProductos.Controls.Add(Me.chbFiltros)
        Me.pnProductos.Controls.Add(Me.chbConversionKg)
        Me.pnProductos.Controls.Add(Me.chbCambioProducto)
        Me.pnProductos.Controls.Add(Me.nudDiasSurtido)
        Me.pnProductos.Controls.Add(Me.cbTipoClaveProducto)
        Me.pnProductos.Controls.Add(Me.lbDiasSurtido)
        Me.pnProductos.Controls.Add(Me.lbDigitoClaveProd)
        Me.pnProductos.Controls.Add(Me.ebDigitoClaveProd)
        Me.pnProductos.Controls.Add(Me.lbTipoClaveProducto)
        Me.pnProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnProductos.Location = New System.Drawing.Point(1, 1)
        Me.pnProductos.Name = "pnProductos"
        Me.pnProductos.Size = New System.Drawing.Size(862, 201)
        Me.pnProductos.TabIndex = 27
        '
        'chbFiltros
        '
        Me.chbFiltros.Location = New System.Drawing.Point(575, 36)
        Me.chbFiltros.Name = "chbFiltros"
        Me.chbFiltros.Size = New System.Drawing.Size(265, 23)
        Me.chbFiltros.TabIndex = 29
        Me.chbFiltros.Tag = "chbFiltros"
        Me.chbFiltros.Text = "chbFiltros"
        Me.chbFiltros.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chbConversionKg
        '
        Me.chbConversionKg.Location = New System.Drawing.Point(287, 36)
        Me.chbConversionKg.Name = "chbConversionKg"
        Me.chbConversionKg.Size = New System.Drawing.Size(282, 23)
        Me.chbConversionKg.TabIndex = 28
        Me.chbConversionKg.Tag = "chbConversionKg"
        Me.chbConversionKg.Text = "chbConversionKg"
        Me.chbConversionKg.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chbCambioProducto
        '
        Me.chbCambioProducto.Location = New System.Drawing.Point(3, 36)
        Me.chbCambioProducto.Name = "chbCambioProducto"
        Me.chbCambioProducto.Size = New System.Drawing.Size(278, 23)
        Me.chbCambioProducto.TabIndex = 27
        Me.chbCambioProducto.Tag = "chbCambioProducto"
        Me.chbCambioProducto.Text = "chbCambioProducto"
        Me.chbCambioProducto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'nudDiasSurtido
        '
        Me.nudDiasSurtido.Location = New System.Drawing.Point(708, 8)
        Me.nudDiasSurtido.Maximum = 32767
        Me.nudDiasSurtido.MaxLength = 5
        Me.nudDiasSurtido.Name = "nudDiasSurtido"
        Me.nudDiasSurtido.Size = New System.Drawing.Size(132, 20)
        Me.nudDiasSurtido.TabIndex = 17
        Me.nudDiasSurtido.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.nudDiasSurtido.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbTipoClaveProducto
        '
        Me.cbTipoClaveProducto.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipoClaveProducto.Location = New System.Drawing.Point(140, 8)
        Me.cbTipoClaveProducto.Name = "cbTipoClaveProducto"
        Me.cbTipoClaveProducto.Size = New System.Drawing.Size(132, 20)
        Me.cbTipoClaveProducto.TabIndex = 11
        Me.cbTipoClaveProducto.Tag = "TipoClaveProducto"
        Me.cbTipoClaveProducto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbDiasSurtido
        '
        Me.lbDiasSurtido.BackColor = System.Drawing.Color.Transparent
        Me.lbDiasSurtido.Location = New System.Drawing.Point(572, 8)
        Me.lbDiasSurtido.Name = "lbDiasSurtido"
        Me.lbDiasSurtido.Size = New System.Drawing.Size(132, 20)
        Me.lbDiasSurtido.TabIndex = 16
        Me.lbDiasSurtido.Text = "Días Surtido de producto"
        Me.lbDiasSurtido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbDigitoClaveProd
        '
        Me.lbDigitoClaveProd.BackColor = System.Drawing.Color.Transparent
        Me.lbDigitoClaveProd.Location = New System.Drawing.Point(288, 8)
        Me.lbDigitoClaveProd.Name = "lbDigitoClaveProd"
        Me.lbDigitoClaveProd.Size = New System.Drawing.Size(132, 20)
        Me.lbDigitoClaveProd.TabIndex = 12
        Me.lbDigitoClaveProd.Text = "Digitos"
        Me.lbDigitoClaveProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebDigitoClaveProd
        '
        Me.ebDigitoClaveProd.DecimalDigits = 0
        Me.ebDigitoClaveProd.Location = New System.Drawing.Point(424, 8)
        Me.ebDigitoClaveProd.MaxLength = 2
        Me.ebDigitoClaveProd.Name = "ebDigitoClaveProd"
        Me.ebDigitoClaveProd.Size = New System.Drawing.Size(132, 20)
        Me.ebDigitoClaveProd.TabIndex = 13
        Me.ebDigitoClaveProd.Tag = "DigitoClaveProd"
        Me.ebDigitoClaveProd.Text = "0"
        Me.ebDigitoClaveProd.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDigitoClaveProd.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ebDigitoClaveProd.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbTipoClaveProducto
        '
        Me.lbTipoClaveProducto.BackColor = System.Drawing.Color.Transparent
        Me.lbTipoClaveProducto.Location = New System.Drawing.Point(4, 8)
        Me.lbTipoClaveProducto.Name = "lbTipoClaveProducto"
        Me.lbTipoClaveProducto.Size = New System.Drawing.Size(132, 20)
        Me.lbTipoClaveProducto.TabIndex = 10
        Me.lbTipoClaveProducto.Text = "Tipo Clave Producto"
        Me.lbTipoClaveProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabProductos
        '
        Me.tabProductos.AttachedControl = Me.TabControlPanel2
        Me.tabProductos.Name = "tabProductos"
        Me.tabProductos.Text = "tabProductos"
        '
        'TabControlPanel4
        '
        Me.TabControlPanel4.Controls.Add(Me.pnVisita)
        Me.TabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel4.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel4.Name = "TabControlPanel4"
        Me.TabControlPanel4.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel4.Size = New System.Drawing.Size(864, 203)
        Me.TabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel4.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel4.Style.GradientAngle = 90
        Me.TabControlPanel4.TabIndex = 4
        Me.TabControlPanel4.TabItem = Me.tabVisita
        '
        'pnVisita
        '
        Me.pnVisita.BackColor = System.Drawing.Color.Transparent
        Me.pnVisita.Controls.Add(Me.chbDatosCteNuevo)
        Me.pnVisita.Controls.Add(Me.chbClientesVisitados)
        Me.pnVisita.Controls.Add(Me.Label1)
        Me.pnVisita.Controls.Add(Me.nudDiasAnteriores)
        Me.pnVisita.Controls.Add(Me.ebLimiteGPS)
        Me.pnVisita.Controls.Add(Me.lbLimiteGPS)
        Me.pnVisita.Controls.Add(Me.cbIniciarVisita)
        Me.pnVisita.Controls.Add(Me.lblIniciarVisita)
        Me.pnVisita.Controls.Add(Me.chbValidaInv)
        Me.pnVisita.Controls.Add(Me.chbContrasenaCliente)
        Me.pnVisita.Controls.Add(Me.chbClienteVariasRutas)
        Me.pnVisita.Controls.Add(Me.lbDiasAnteriores)
        Me.pnVisita.Controls.Add(Me.nudDiasPosteriores)
        Me.pnVisita.Controls.Add(Me.lbDiasPosteriores)
        Me.pnVisita.Controls.Add(Me.chbCodigoBarrasCliente)
        Me.pnVisita.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnVisita.Location = New System.Drawing.Point(1, 1)
        Me.pnVisita.Name = "pnVisita"
        Me.pnVisita.Size = New System.Drawing.Size(862, 201)
        Me.pnVisita.TabIndex = 25
        '
        'chbDatosCteNuevo
        '
        Me.chbDatosCteNuevo.Location = New System.Drawing.Point(570, 83)
        Me.chbDatosCteNuevo.Name = "chbDatosCteNuevo"
        Me.chbDatosCteNuevo.Size = New System.Drawing.Size(215, 20)
        Me.chbDatosCteNuevo.TabIndex = 9
        Me.chbDatosCteNuevo.Text = "DatosCteNuevo"
        Me.chbDatosCteNuevo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chbClientesVisitados
        '
        Me.chbClientesVisitados.Location = New System.Drawing.Point(282, 45)
        Me.chbClientesVisitados.Name = "chbClientesVisitados"
        Me.chbClientesVisitados.Size = New System.Drawing.Size(215, 20)
        Me.chbClientesVisitados.TabIndex = 5
        Me.chbClientesVisitados.Text = "chbClientesVisitados"
        Me.chbClientesVisitados.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(831, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 22)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "m"
        '
        'nudDiasAnteriores
        '
        Me.nudDiasAnteriores.Location = New System.Drawing.Point(124, 9)
        Me.nudDiasAnteriores.Maximum = 365
        Me.nudDiasAnteriores.MaxLength = 5
        Me.nudDiasAnteriores.Name = "nudDiasAnteriores"
        Me.nudDiasAnteriores.Size = New System.Drawing.Size(149, 20)
        Me.nudDiasAnteriores.TabIndex = 1
        Me.nudDiasAnteriores.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.nudDiasAnteriores.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebLimiteGPS
        '
        Me.ebLimiteGPS.DecimalDigits = 2
        Me.ebLimiteGPS.Location = New System.Drawing.Point(703, 45)
        Me.ebLimiteGPS.MaxLength = 0
        Me.ebLimiteGPS.Name = "ebLimiteGPS"
        Me.ebLimiteGPS.Size = New System.Drawing.Size(126, 20)
        Me.ebLimiteGPS.TabIndex = 6
        Me.ebLimiteGPS.Tag = "DigitoClaveProd"
        Me.ebLimiteGPS.Text = "0.00"
        Me.ebLimiteGPS.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebLimiteGPS.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ebLimiteGPS.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbLimiteGPS
        '
        Me.lbLimiteGPS.BackColor = System.Drawing.Color.Transparent
        Me.lbLimiteGPS.Location = New System.Drawing.Point(570, 45)
        Me.lbLimiteGPS.Name = "lbLimiteGPS"
        Me.lbLimiteGPS.Size = New System.Drawing.Size(132, 30)
        Me.lbLimiteGPS.TabIndex = 31
        Me.lbLimiteGPS.Text = "LimiteCoordenadasGPS"
        '
        'cbIniciarVisita
        '
        Me.cbIniciarVisita.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbIniciarVisita.Location = New System.Drawing.Point(703, 9)
        Me.cbIniciarVisita.Name = "cbIniciarVisita"
        Me.cbIniciarVisita.Size = New System.Drawing.Size(149, 20)
        Me.cbIniciarVisita.TabIndex = 3
        Me.cbIniciarVisita.Tag = "TipoLenguaje"
        Me.cbIniciarVisita.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lblIniciarVisita
        '
        Me.lblIniciarVisita.BackColor = System.Drawing.Color.Transparent
        Me.lblIniciarVisita.Location = New System.Drawing.Point(570, 10)
        Me.lblIniciarVisita.Name = "lblIniciarVisita"
        Me.lblIniciarVisita.Size = New System.Drawing.Size(132, 30)
        Me.lblIniciarVisita.TabIndex = 29
        Me.lblIniciarVisita.Text = "IniciarVisita"
        '
        'chbValidaInv
        '
        Me.chbValidaInv.Location = New System.Drawing.Point(5, 121)
        Me.chbValidaInv.Name = "chbValidaInv"
        Me.chbValidaInv.Size = New System.Drawing.Size(268, 20)
        Me.chbValidaInv.TabIndex = 10
        Me.chbValidaInv.Text = "chbValidaInv"
        Me.chbValidaInv.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chbContrasenaCliente
        '
        Me.chbContrasenaCliente.Location = New System.Drawing.Point(282, 83)
        Me.chbContrasenaCliente.Name = "chbContrasenaCliente"
        Me.chbContrasenaCliente.Size = New System.Drawing.Size(268, 20)
        Me.chbContrasenaCliente.TabIndex = 8
        Me.chbContrasenaCliente.Text = "chbContrasenaCliente"
        Me.chbContrasenaCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chbClienteVariasRutas
        '
        Me.chbClienteVariasRutas.Location = New System.Drawing.Point(5, 45)
        Me.chbClienteVariasRutas.Name = "chbClienteVariasRutas"
        Me.chbClienteVariasRutas.Size = New System.Drawing.Size(268, 20)
        Me.chbClienteVariasRutas.TabIndex = 4
        Me.chbClienteVariasRutas.Text = "ClienteVariasRutas"
        Me.chbClienteVariasRutas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbDiasAnteriores
        '
        Me.lbDiasAnteriores.BackColor = System.Drawing.Color.Transparent
        Me.lbDiasAnteriores.Location = New System.Drawing.Point(4, 10)
        Me.lbDiasAnteriores.Name = "lbDiasAnteriores"
        Me.lbDiasAnteriores.Size = New System.Drawing.Size(132, 30)
        Me.lbDiasAnteriores.TabIndex = 16
        Me.lbDiasAnteriores.Text = "DiasAnteriores"
        '
        'nudDiasPosteriores
        '
        Me.nudDiasPosteriores.Location = New System.Drawing.Point(412, 9)
        Me.nudDiasPosteriores.Maximum = 365
        Me.nudDiasPosteriores.MaxLength = 5
        Me.nudDiasPosteriores.Name = "nudDiasPosteriores"
        Me.nudDiasPosteriores.Size = New System.Drawing.Size(149, 20)
        Me.nudDiasPosteriores.TabIndex = 2
        Me.nudDiasPosteriores.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.nudDiasPosteriores.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbDiasPosteriores
        '
        Me.lbDiasPosteriores.BackColor = System.Drawing.Color.Transparent
        Me.lbDiasPosteriores.Location = New System.Drawing.Point(282, 10)
        Me.lbDiasPosteriores.Name = "lbDiasPosteriores"
        Me.lbDiasPosteriores.Size = New System.Drawing.Size(132, 30)
        Me.lbDiasPosteriores.TabIndex = 16
        Me.lbDiasPosteriores.Text = "DiasPosteriores"
        '
        'chbCodigoBarrasCliente
        '
        Me.chbCodigoBarrasCliente.Location = New System.Drawing.Point(5, 83)
        Me.chbCodigoBarrasCliente.Name = "chbCodigoBarrasCliente"
        Me.chbCodigoBarrasCliente.Size = New System.Drawing.Size(268, 20)
        Me.chbCodigoBarrasCliente.TabIndex = 7
        Me.chbCodigoBarrasCliente.Text = "chbCodigoBarrasCliente"
        Me.chbCodigoBarrasCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'tabVisita
        '
        Me.tabVisita.AttachedControl = Me.TabControlPanel4
        Me.tabVisita.Name = "tabVisita"
        Me.tabVisita.Text = "tabVisita"
        '
        'TabControlPanel5
        '
        Me.TabControlPanel5.Controls.Add(Me.pnComunicacion)
        Me.TabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel5.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel5.Name = "TabControlPanel5"
        Me.TabControlPanel5.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel5.Size = New System.Drawing.Size(864, 203)
        Me.TabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel5.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel5.Style.GradientAngle = 90
        Me.TabControlPanel5.TabIndex = 5
        Me.TabControlPanel5.TabItem = Me.tabComunicacion
        '
        'pnComunicacion
        '
        Me.pnComunicacion.BackColor = System.Drawing.Color.Transparent
        Me.pnComunicacion.Controls.Add(Me.btInterfaces)
        Me.pnComunicacion.Controls.Add(Me.ebDirSDF)
        Me.pnComunicacion.Controls.Add(Me.lblDirInterfaces)
        Me.pnComunicacion.Controls.Add(Me.nudServiciosActivos)
        Me.pnComunicacion.Controls.Add(Me.chbAuditarCarga)
        Me.pnComunicacion.Controls.Add(Me.lbCantidadServicios)
        Me.pnComunicacion.Controls.Add(Me.lbDifPreliquidacion)
        Me.pnComunicacion.Controls.Add(Me.ebDifPreliquidacion)
        Me.pnComunicacion.Controls.Add(Me.chbPreLiquidacion)
        Me.pnComunicacion.Controls.Add(Me.chbInventario)
        Me.pnComunicacion.Controls.Add(Me.btSeleccionarDir)
        Me.pnComunicacion.Controls.Add(Me.lbDirectorioSDF)
        Me.pnComunicacion.Controls.Add(Me.chbEliminaEnviado)
        Me.pnComunicacion.Controls.Add(Me.chbIntUnidadVta)
        Me.pnComunicacion.Controls.Add(Me.txtRinterfaz)
        Me.pnComunicacion.Controls.Add(Me.chbEnvioParcial)
        Me.pnComunicacion.Controls.Add(Me.chbInterfaz)
        Me.pnComunicacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnComunicacion.Location = New System.Drawing.Point(1, 1)
        Me.pnComunicacion.Name = "pnComunicacion"
        Me.pnComunicacion.Size = New System.Drawing.Size(862, 201)
        Me.pnComunicacion.TabIndex = 76
        '
        'btInterfaces
        '
        Me.btInterfaces.Location = New System.Drawing.Point(808, 36)
        Me.btInterfaces.Name = "btInterfaces"
        Me.btInterfaces.Size = New System.Drawing.Size(24, 20)
        Me.btInterfaces.TabIndex = 4
        Me.btInterfaces.Text = "..."
        Me.btInterfaces.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'ebDirSDF
        '
        Me.ebDirSDF.Enabled = False
        Me.ebDirSDF.Location = New System.Drawing.Point(136, 4)
        Me.ebDirSDF.MaxLength = 64
        Me.ebDirSDF.Name = "ebDirSDF"
        Me.ebDirSDF.Size = New System.Drawing.Size(672, 20)
        Me.ebDirSDF.TabIndex = 1
        Me.ebDirSDF.Tag = "Calle"
        Me.ebDirSDF.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDirSDF.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblDirInterfaces
        '
        Me.lblDirInterfaces.BackColor = System.Drawing.Color.Transparent
        Me.lblDirInterfaces.Location = New System.Drawing.Point(4, 36)
        Me.lblDirInterfaces.Name = "lblDirInterfaces"
        Me.lblDirInterfaces.Size = New System.Drawing.Size(132, 20)
        Me.lblDirInterfaces.TabIndex = 36
        Me.lblDirInterfaces.Text = "lblDirectorioInterfaces"
        Me.lblDirInterfaces.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudServiciosActivos
        '
        Me.nudServiciosActivos.Location = New System.Drawing.Point(425, 67)
        Me.nudServiciosActivos.Maximum = 32767
        Me.nudServiciosActivos.MaxLength = 5
        Me.nudServiciosActivos.Name = "nudServiciosActivos"
        Me.nudServiciosActivos.Size = New System.Drawing.Size(132, 20)
        Me.nudServiciosActivos.TabIndex = 7
        Me.nudServiciosActivos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.nudServiciosActivos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'chbAuditarCarga
        '
        Me.chbAuditarCarga.BackColor = System.Drawing.Color.Transparent
        Me.chbAuditarCarga.Location = New System.Drawing.Point(637, 102)
        Me.chbAuditarCarga.Name = "chbAuditarCarga"
        Me.chbAuditarCarga.Size = New System.Drawing.Size(196, 20)
        Me.chbAuditarCarga.TabIndex = 11
        Me.chbAuditarCarga.Text = "chbAuditarCarga"
        Me.chbAuditarCarga.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbCantidadServicios
        '
        Me.lbCantidadServicios.BackColor = System.Drawing.Color.Transparent
        Me.lbCantidadServicios.Location = New System.Drawing.Point(290, 67)
        Me.lbCantidadServicios.Name = "lbCantidadServicios"
        Me.lbCantidadServicios.Size = New System.Drawing.Size(132, 30)
        Me.lbCantidadServicios.TabIndex = 14
        Me.lbCantidadServicios.Text = "Cantidad Servicios Activos"
        '
        'lbDifPreliquidacion
        '
        Me.lbDifPreliquidacion.BackColor = System.Drawing.Color.Transparent
        Me.lbDifPreliquidacion.Location = New System.Drawing.Point(4, 67)
        Me.lbDifPreliquidacion.Name = "lbDifPreliquidacion"
        Me.lbDifPreliquidacion.Size = New System.Drawing.Size(132, 30)
        Me.lbDifPreliquidacion.TabIndex = 68
        Me.lbDifPreliquidacion.Text = "Diferencia en la PreLiquidación"
        Me.lbDifPreliquidacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebDifPreliquidacion
        '
        Me.ebDifPreliquidacion.DecimalDigits = 2
        Me.ebDifPreliquidacion.Location = New System.Drawing.Point(136, 67)
        Me.ebDifPreliquidacion.MaxLength = 0
        Me.ebDifPreliquidacion.Name = "ebDifPreliquidacion"
        Me.ebDifPreliquidacion.Size = New System.Drawing.Size(132, 20)
        Me.ebDifPreliquidacion.TabIndex = 6
        Me.ebDifPreliquidacion.Tag = "DigitoClaveProd"
        Me.ebDifPreliquidacion.Text = "0.00"
        Me.ebDifPreliquidacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDifPreliquidacion.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ebDifPreliquidacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'chbPreLiquidacion
        '
        Me.chbPreLiquidacion.BackColor = System.Drawing.Color.Transparent
        Me.chbPreLiquidacion.Location = New System.Drawing.Point(8, 135)
        Me.chbPreLiquidacion.Name = "chbPreLiquidacion"
        Me.chbPreLiquidacion.Size = New System.Drawing.Size(196, 20)
        Me.chbPreLiquidacion.TabIndex = 12
        Me.chbPreLiquidacion.Text = "PreLiquidacion"
        Me.chbPreLiquidacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chbInventario
        '
        Me.chbInventario.BackColor = System.Drawing.Color.Transparent
        Me.chbInventario.Location = New System.Drawing.Point(425, 102)
        Me.chbInventario.Name = "chbInventario"
        Me.chbInventario.Size = New System.Drawing.Size(196, 20)
        Me.chbInventario.TabIndex = 10
        Me.chbInventario.Text = "Inventario"
        Me.chbInventario.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btSeleccionarDir
        '
        Me.btSeleccionarDir.Location = New System.Drawing.Point(808, 4)
        Me.btSeleccionarDir.Name = "btSeleccionarDir"
        Me.btSeleccionarDir.Size = New System.Drawing.Size(25, 20)
        Me.btSeleccionarDir.TabIndex = 2
        Me.btSeleccionarDir.Text = "..."
        Me.btSeleccionarDir.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'lbDirectorioSDF
        '
        Me.lbDirectorioSDF.BackColor = System.Drawing.Color.Transparent
        Me.lbDirectorioSDF.Location = New System.Drawing.Point(4, 4)
        Me.lbDirectorioSDF.Name = "lbDirectorioSDF"
        Me.lbDirectorioSDF.Size = New System.Drawing.Size(132, 20)
        Me.lbDirectorioSDF.TabIndex = 7
        Me.lbDirectorioSDF.Text = "lbDirectorioSDF"
        Me.lbDirectorioSDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chbEliminaEnviado
        '
        Me.chbEliminaEnviado.BackColor = System.Drawing.Color.Transparent
        Me.chbEliminaEnviado.Location = New System.Drawing.Point(425, 135)
        Me.chbEliminaEnviado.Name = "chbEliminaEnviado"
        Me.chbEliminaEnviado.Size = New System.Drawing.Size(196, 20)
        Me.chbEliminaEnviado.TabIndex = 14
        Me.chbEliminaEnviado.Text = "EliminaEnviado"
        Me.chbEliminaEnviado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chbIntUnidadVta
        '
        Me.chbIntUnidadVta.BackColor = System.Drawing.Color.Transparent
        Me.chbIntUnidadVta.Location = New System.Drawing.Point(213, 102)
        Me.chbIntUnidadVta.Name = "chbIntUnidadVta"
        Me.chbIntUnidadVta.Size = New System.Drawing.Size(196, 20)
        Me.chbIntUnidadVta.TabIndex = 9
        Me.chbIntUnidadVta.Text = "chbIntUnidadVta"
        Me.chbIntUnidadVta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtRinterfaz
        '
        Me.txtRinterfaz.Enabled = False
        Me.txtRinterfaz.Location = New System.Drawing.Point(136, 36)
        Me.txtRinterfaz.Name = "txtRinterfaz"
        Me.txtRinterfaz.Size = New System.Drawing.Size(672, 20)
        Me.txtRinterfaz.TabIndex = 3
        Me.txtRinterfaz.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtRinterfaz.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'chbEnvioParcial
        '
        Me.chbEnvioParcial.BackColor = System.Drawing.Color.Transparent
        Me.chbEnvioParcial.Location = New System.Drawing.Point(213, 135)
        Me.chbEnvioParcial.Name = "chbEnvioParcial"
        Me.chbEnvioParcial.Size = New System.Drawing.Size(196, 20)
        Me.chbEnvioParcial.TabIndex = 13
        Me.chbEnvioParcial.Text = "EnvioParcial"
        Me.chbEnvioParcial.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chbInterfaz
        '
        Me.chbInterfaz.BackColor = System.Drawing.Color.Transparent
        Me.chbInterfaz.Location = New System.Drawing.Point(8, 102)
        Me.chbInterfaz.Name = "chbInterfaz"
        Me.chbInterfaz.Size = New System.Drawing.Size(196, 20)
        Me.chbInterfaz.TabIndex = 8
        Me.chbInterfaz.Text = "chbInterfaz"
        Me.chbInterfaz.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'tabComunicacion
        '
        Me.tabComunicacion.AttachedControl = Me.TabControlPanel5
        Me.tabComunicacion.Name = "tabComunicacion"
        Me.tabComunicacion.Text = "tabComunicacion"
        '
        'TabControlPanel6
        '
        Me.TabControlPanel6.Controls.Add(Me.chbSSL)
        Me.TabControlPanel6.Controls.Add(Me.lblCOnfirmar)
        Me.TabControlPanel6.Controls.Add(Me.ebPuerto)
        Me.TabControlPanel6.Controls.Add(Me.ebConfirmarPassword)
        Me.TabControlPanel6.Controls.Add(Me.ebPassword)
        Me.TabControlPanel6.Controls.Add(Me.lblContrasenia)
        Me.TabControlPanel6.Controls.Add(Me.ebServidorSMTP)
        Me.TabControlPanel6.Controls.Add(Me.lblSMTP)
        Me.TabControlPanel6.Controls.Add(Me.ebCorreoElectronico)
        Me.TabControlPanel6.Controls.Add(Me.lblPuerto)
        Me.TabControlPanel6.Controls.Add(Me.lblCorreoElectronico)
        Me.TabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel6.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel6.Name = "TabControlPanel6"
        Me.TabControlPanel6.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel6.Size = New System.Drawing.Size(864, 203)
        Me.TabControlPanel6.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel6.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel6.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel6.Style.GradientAngle = 90
        Me.TabControlPanel6.TabIndex = 6
        Me.TabControlPanel6.TabItem = Me.tabCorreoElectronico
        '
        'chbSSL
        '
        Me.chbSSL.BackColor = System.Drawing.Color.Transparent
        Me.chbSSL.Location = New System.Drawing.Point(433, 10)
        Me.chbSSL.Name = "chbSSL"
        Me.chbSSL.Size = New System.Drawing.Size(267, 23)
        Me.chbSSL.TabIndex = 6
        Me.chbSSL.Text = "SSL"
        Me.chbSSL.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lblCOnfirmar
        '
        Me.lblCOnfirmar.BackColor = System.Drawing.Color.Transparent
        Me.lblCOnfirmar.Location = New System.Drawing.Point(28, 139)
        Me.lblCOnfirmar.Name = "lblCOnfirmar"
        Me.lblCOnfirmar.Size = New System.Drawing.Size(121, 20)
        Me.lblCOnfirmar.TabIndex = 42
        Me.lblCOnfirmar.Text = "ConfirmarContraseña"
        '
        'ebPuerto
        '
        Me.ebPuerto.DecimalDigits = 0
        Me.ebPuerto.Location = New System.Drawing.Point(155, 43)
        Me.ebPuerto.MaxLength = 4
        Me.ebPuerto.Name = "ebPuerto"
        Me.ebPuerto.Size = New System.Drawing.Size(237, 20)
        Me.ebPuerto.TabIndex = 2
        Me.ebPuerto.Tag = "Puerto"
        Me.ebPuerto.Text = "0"
        Me.ebPuerto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPuerto.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ebPuerto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebConfirmarPassword
        '
        Me.ebConfirmarPassword.Location = New System.Drawing.Point(155, 139)
        Me.ebConfirmarPassword.MaxLength = 100
        Me.ebConfirmarPassword.Name = "ebConfirmarPassword"
        Me.ebConfirmarPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ebConfirmarPassword.Size = New System.Drawing.Size(237, 20)
        Me.ebConfirmarPassword.TabIndex = 5
        Me.ebConfirmarPassword.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebConfirmarPassword.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebPassword
        '
        Me.ebPassword.Location = New System.Drawing.Point(155, 108)
        Me.ebPassword.MaxLength = 100
        Me.ebPassword.Name = "ebPassword"
        Me.ebPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ebPassword.Size = New System.Drawing.Size(237, 20)
        Me.ebPassword.TabIndex = 4
        Me.ebPassword.Tag = "Password"
        Me.ebPassword.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPassword.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblContrasenia
        '
        Me.lblContrasenia.BackColor = System.Drawing.Color.Transparent
        Me.lblContrasenia.Location = New System.Drawing.Point(29, 108)
        Me.lblContrasenia.Name = "lblContrasenia"
        Me.lblContrasenia.Size = New System.Drawing.Size(132, 20)
        Me.lblContrasenia.TabIndex = 39
        Me.lblContrasenia.Text = "Contraseña"
        '
        'ebServidorSMTP
        '
        Me.ebServidorSMTP.Location = New System.Drawing.Point(155, 12)
        Me.ebServidorSMTP.MaxLength = 100
        Me.ebServidorSMTP.Name = "ebServidorSMTP"
        Me.ebServidorSMTP.Size = New System.Drawing.Size(237, 20)
        Me.ebServidorSMTP.TabIndex = 1
        Me.ebServidorSMTP.Tag = "ServidorSMTP"
        Me.ebServidorSMTP.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebServidorSMTP.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblSMTP
        '
        Me.lblSMTP.BackColor = System.Drawing.Color.Transparent
        Me.lblSMTP.Location = New System.Drawing.Point(28, 12)
        Me.lblSMTP.Name = "lblSMTP"
        Me.lblSMTP.Size = New System.Drawing.Size(132, 20)
        Me.lblSMTP.TabIndex = 37
        Me.lblSMTP.Text = "Servidor SMTP"
        '
        'ebCorreoElectronico
        '
        Me.ebCorreoElectronico.Location = New System.Drawing.Point(155, 75)
        Me.ebCorreoElectronico.MaxLength = 100
        Me.ebCorreoElectronico.Name = "ebCorreoElectronico"
        Me.ebCorreoElectronico.Size = New System.Drawing.Size(237, 20)
        Me.ebCorreoElectronico.TabIndex = 3
        Me.ebCorreoElectronico.Tag = "Correo"
        Me.ebCorreoElectronico.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCorreoElectronico.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblPuerto
        '
        Me.lblPuerto.BackColor = System.Drawing.Color.Transparent
        Me.lblPuerto.Location = New System.Drawing.Point(29, 46)
        Me.lblPuerto.Name = "lblPuerto"
        Me.lblPuerto.Size = New System.Drawing.Size(132, 16)
        Me.lblPuerto.TabIndex = 35
        Me.lblPuerto.Text = "Puerto"
        '
        'lblCorreoElectronico
        '
        Me.lblCorreoElectronico.BackColor = System.Drawing.Color.Transparent
        Me.lblCorreoElectronico.Location = New System.Drawing.Point(28, 79)
        Me.lblCorreoElectronico.Name = "lblCorreoElectronico"
        Me.lblCorreoElectronico.Size = New System.Drawing.Size(132, 16)
        Me.lblCorreoElectronico.TabIndex = 33
        Me.lblCorreoElectronico.Text = "Correo Electronico"
        '
        'tabCorreoElectronico
        '
        Me.tabCorreoElectronico.AttachedControl = Me.TabControlPanel6
        Me.tabCorreoElectronico.Name = "tabCorreoElectronico"
        Me.tabCorreoElectronico.Text = "tabCorreoElectronico"
        '
        'cbFechaInicio
        '
        Me.cbFechaInicio.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        '
        '
        '
        Me.cbFechaInicio.DropDownCalendar.FirstMonth = New Date(2008, 2, 1, 0, 0, 0, 0)
        Me.cbFechaInicio.DropDownCalendar.Name = ""
        Me.cbFechaInicio.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbFechaInicio.Enabled = False
        Me.cbFechaInicio.Location = New System.Drawing.Point(144, 24)
        Me.cbFechaInicio.Name = "cbFechaInicio"
        Me.cbFechaInicio.Size = New System.Drawing.Size(152, 20)
        Me.cbFechaInicio.TabIndex = 1
        Me.cbFechaInicio.Tag = "FechaIni"
        Me.cbFechaInicio.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'btHistorico
        '
        Me.btHistorico.Icon = CType(resources.GetObject("btHistorico.Icon"), System.Drawing.Icon)
        Me.btHistorico.Location = New System.Drawing.Point(744, 20)
        Me.btHistorico.Name = "btHistorico"
        Me.btHistorico.Size = New System.Drawing.Size(100, 24)
        Me.btHistorico.TabIndex = 2
        Me.btHistorico.Text = "Historial"
        Me.btHistorico.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'LbInicio
        '
        Me.LbInicio.Location = New System.Drawing.Point(8, 24)
        Me.LbInicio.Name = "LbInicio"
        Me.LbInicio.Size = New System.Drawing.Size(132, 20)
        Me.LbInicio.TabIndex = 0
        Me.LbInicio.Text = "Inicio"
        Me.LbInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'epErrores
        '
        Me.epErrores.ContainerControl = Me
        '
        'btAceptar
        '
        Me.btAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btAceptar.Icon = CType(resources.GetObject("btAceptar.Icon"), System.Drawing.Icon)
        Me.btAceptar.Location = New System.Drawing.Point(666, 508)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(104, 24)
        Me.btAceptar.TabIndex = 28
        Me.btAceptar.Text = "Aceptar"
        Me.btAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCancelar
        '
        Me.btCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCancelar.Icon = CType(resources.GetObject("btCancelar.Icon"), System.Drawing.Icon)
        Me.btCancelar.Location = New System.Drawing.Point(776, 508)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(104, 24)
        Me.btCancelar.TabIndex = 29
        Me.btCancelar.Text = "Cancelar"
        Me.btCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'lblogotipo
        '
        Me.lblogotipo.Location = New System.Drawing.Point(16, 88)
        Me.lblogotipo.Name = "lblogotipo"
        Me.lblogotipo.Size = New System.Drawing.Size(132, 20)
        Me.lblogotipo.TabIndex = 0
        Me.lblogotipo.Text = "Logo"
        Me.lblogotipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbRFC
        '
        Me.lbRFC.Location = New System.Drawing.Point(164, 38)
        Me.lbRFC.Name = "lbRFC"
        Me.lbRFC.Size = New System.Drawing.Size(132, 20)
        Me.lbRFC.TabIndex = 3
        Me.lbRFC.Text = "RFC"
        Me.lbRFC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebRFC
        '
        Me.ebRFC.Location = New System.Drawing.Point(300, 38)
        Me.ebRFC.MaxLength = 64
        Me.ebRFC.Name = "ebRFC"
        Me.ebRFC.Size = New System.Drawing.Size(212, 20)
        Me.ebRFC.TabIndex = 4
        Me.ebRFC.Tag = "RFC"
        Me.ebRFC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebRFC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbCalle
        '
        Me.lbCalle.Location = New System.Drawing.Point(164, 64)
        Me.lbCalle.Name = "lbCalle"
        Me.lbCalle.Size = New System.Drawing.Size(132, 20)
        Me.lbCalle.TabIndex = 7
        Me.lbCalle.Text = "Calle"
        Me.lbCalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebCalle
        '
        Me.ebCalle.Location = New System.Drawing.Point(300, 64)
        Me.ebCalle.MaxLength = 64
        Me.ebCalle.Name = "ebCalle"
        Me.ebCalle.Size = New System.Drawing.Size(572, 20)
        Me.ebCalle.TabIndex = 8
        Me.ebCalle.Tag = "Calle"
        Me.ebCalle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbNumero
        '
        Me.lbNumero.Location = New System.Drawing.Point(164, 90)
        Me.lbNumero.Name = "lbNumero"
        Me.lbNumero.Size = New System.Drawing.Size(132, 20)
        Me.lbNumero.TabIndex = 9
        Me.lbNumero.Text = "Número"
        Me.lbNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebNumero
        '
        Me.ebNumero.Location = New System.Drawing.Point(300, 90)
        Me.ebNumero.MaxLength = 16
        Me.ebNumero.Name = "ebNumero"
        Me.ebNumero.Size = New System.Drawing.Size(212, 20)
        Me.ebNumero.TabIndex = 10
        Me.ebNumero.Tag = "Numero"
        Me.ebNumero.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumero.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbColonia
        '
        Me.lbColonia.Location = New System.Drawing.Point(164, 116)
        Me.lbColonia.Name = "lbColonia"
        Me.lbColonia.Size = New System.Drawing.Size(132, 20)
        Me.lbColonia.TabIndex = 13
        Me.lbColonia.Text = "Colonia"
        Me.lbColonia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebColonia
        '
        Me.ebColonia.Location = New System.Drawing.Point(300, 116)
        Me.ebColonia.MaxLength = 64
        Me.ebColonia.Name = "ebColonia"
        Me.ebColonia.Size = New System.Drawing.Size(212, 20)
        Me.ebColonia.TabIndex = 14
        Me.ebColonia.Tag = "Colonia"
        Me.ebColonia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebColonia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbTelefono
        '
        Me.lbTelefono.Location = New System.Drawing.Point(524, 38)
        Me.lbTelefono.Name = "lbTelefono"
        Me.lbTelefono.Size = New System.Drawing.Size(132, 20)
        Me.lbTelefono.TabIndex = 5
        Me.lbTelefono.Text = "Telefono"
        Me.lbTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebTelefono
        '
        Me.ebTelefono.Location = New System.Drawing.Point(660, 38)
        Me.ebTelefono.MaxLength = 32
        Me.ebTelefono.Name = "ebTelefono"
        Me.ebTelefono.Size = New System.Drawing.Size(212, 20)
        Me.ebTelefono.TabIndex = 6
        Me.ebTelefono.Tag = "Numero"
        Me.ebTelefono.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTelefono.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbCodigoPostal
        '
        Me.lbCodigoPostal.Location = New System.Drawing.Point(524, 116)
        Me.lbCodigoPostal.Name = "lbCodigoPostal"
        Me.lbCodigoPostal.Size = New System.Drawing.Size(132, 20)
        Me.lbCodigoPostal.TabIndex = 15
        Me.lbCodigoPostal.Text = "Codigo Postal"
        Me.lbCodigoPostal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbNumeroInterior
        '
        Me.lbNumeroInterior.Location = New System.Drawing.Point(524, 90)
        Me.lbNumeroInterior.Name = "lbNumeroInterior"
        Me.lbNumeroInterior.Size = New System.Drawing.Size(132, 20)
        Me.lbNumeroInterior.TabIndex = 11
        Me.lbNumeroInterior.Text = "Número Interior"
        Me.lbNumeroInterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebNumeroInterior
        '
        Me.ebNumeroInterior.Location = New System.Drawing.Point(660, 90)
        Me.ebNumeroInterior.MaxLength = 16
        Me.ebNumeroInterior.Name = "ebNumeroInterior"
        Me.ebNumeroInterior.Size = New System.Drawing.Size(212, 20)
        Me.ebNumeroInterior.TabIndex = 12
        Me.ebNumeroInterior.Tag = "NumeroInterior"
        Me.ebNumeroInterior.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumeroInterior.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebCodigoPostal
        '
        Me.ebCodigoPostal.Location = New System.Drawing.Point(660, 116)
        Me.ebCodigoPostal.MaxLength = 16
        Me.ebCodigoPostal.Name = "ebCodigoPostal"
        Me.ebCodigoPostal.Size = New System.Drawing.Size(212, 20)
        Me.ebCodigoPostal.TabIndex = 16
        Me.ebCodigoPostal.Tag = "CodigoPostal"
        Me.ebCodigoPostal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigoPostal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbReferenciaDom
        '
        Me.lbReferenciaDom.Location = New System.Drawing.Point(164, 142)
        Me.lbReferenciaDom.Name = "lbReferenciaDom"
        Me.lbReferenciaDom.Size = New System.Drawing.Size(132, 20)
        Me.lbReferenciaDom.TabIndex = 17
        Me.lbReferenciaDom.Text = "Referencia"
        Me.lbReferenciaDom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebReferenciaDom
        '
        Me.ebReferenciaDom.Location = New System.Drawing.Point(300, 142)
        Me.ebReferenciaDom.MaxLength = 100
        Me.ebReferenciaDom.Name = "ebReferenciaDom"
        Me.ebReferenciaDom.Size = New System.Drawing.Size(572, 20)
        Me.ebReferenciaDom.TabIndex = 18
        Me.ebReferenciaDom.Tag = "ReferenciaDom"
        Me.ebReferenciaDom.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebReferenciaDom.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbLocalidad
        '
        Me.lbLocalidad.Location = New System.Drawing.Point(164, 168)
        Me.lbLocalidad.Name = "lbLocalidad"
        Me.lbLocalidad.Size = New System.Drawing.Size(132, 20)
        Me.lbLocalidad.TabIndex = 19
        Me.lbLocalidad.Text = "Localidad"
        Me.lbLocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebLocalidad
        '
        Me.ebLocalidad.Location = New System.Drawing.Point(300, 168)
        Me.ebLocalidad.MaxLength = 40
        Me.ebLocalidad.Name = "ebLocalidad"
        Me.ebLocalidad.Size = New System.Drawing.Size(212, 20)
        Me.ebLocalidad.TabIndex = 20
        Me.ebLocalidad.Tag = "Localidad"
        Me.ebLocalidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebLocalidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'MGeneral
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(888, 545)
        Me.Controls.Add(Me.lbLocalidad)
        Me.Controls.Add(Me.ebLocalidad)
        Me.Controls.Add(Me.lbReferenciaDom)
        Me.Controls.Add(Me.ebReferenciaDom)
        Me.Controls.Add(Me.ebCodigoPostal)
        Me.Controls.Add(Me.lbNumeroInterior)
        Me.Controls.Add(Me.ebNumeroInterior)
        Me.Controls.Add(Me.lbCodigoPostal)
        Me.Controls.Add(Me.ebTelefono)
        Me.Controls.Add(Me.lbTelefono)
        Me.Controls.Add(Me.lbColonia)
        Me.Controls.Add(Me.ebColonia)
        Me.Controls.Add(Me.lbNumero)
        Me.Controls.Add(Me.ebNumero)
        Me.Controls.Add(Me.lbCalle)
        Me.Controls.Add(Me.ebCalle)
        Me.Controls.Add(Me.lbRFC)
        Me.Controls.Add(Me.ebRFC)
        Me.Controls.Add(Me.btAceptar)
        Me.Controls.Add(Me.ebEmpresa)
        Me.Controls.Add(Me.PbLogo)
        Me.Controls.Add(Me.LbEmpresa)
        Me.Controls.Add(Me.LbPais)
        Me.Controls.Add(Me.LbRegion)
        Me.Controls.Add(Me.LbCiudad)
        Me.Controls.Add(Me.ebPais)
        Me.Controls.Add(Me.EbRegion)
        Me.Controls.Add(Me.EbCiudad)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.lblogotipo)
        Me.Controls.Add(Me.gbParametros)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MGeneral"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MGeneral"
        CType(Me.PbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbParametros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbParametros.ResumeLayout(False)
        Me.gbParametros.PerformLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel3.ResumeLayout(False)
        Me.pnVenta.ResumeLayout(False)
        Me.pnVenta.PerformLayout()
        Me.TabControlPanel1.ResumeLayout(False)
        Me.pnGenerales.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        Me.pnProductos.ResumeLayout(False)
        Me.pnProductos.PerformLayout()
        Me.TabControlPanel4.ResumeLayout(False)
        Me.pnVisita.ResumeLayout(False)
        Me.pnVisita.PerformLayout()
        Me.TabControlPanel5.ResumeLayout(False)
        Me.pnComunicacion.ResumeLayout(False)
        Me.pnComunicacion.PerformLayout()
        Me.TabControlPanel6.ResumeLayout(False)
        Me.TabControlPanel6.PerformLayout()
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Shared vgInstance As MGeneral = Nothing

    Public Shared Function Instance() As MGeneral
        If vgInstance Is Nothing OrElse vgInstance.IsDisposed = True Then
            vgInstance = New MGeneral
        End If
        Return vgInstance
    End Function

    Private Sub ConfiguraTitulos()
        lbGeneral.LlenarComboBox(Me.cbLenguaje, "BLENGUA", 0)
        lbGeneral.LlenarComboBox(Me.cbTipoClaveProducto, "TDATO", 0)
        lbGeneral.LlenarComboBox(Me.cbTipoLimiteCredito, "ACTLCRE", 1)
        'lbGeneral.LlenarComboBox(Me.cbTicketConfigurado, "TTICKET", 1)

        Dim Valores As Hashtable = lbGeneral.ValoresDescripcionVARValor("TTICKET", "")
        Dim dtValores As New Data.DataTable("Tickets")
        dtValores.Columns.Add("Valor")
        dtValores.Columns.Add("Descripcion")

        For Each Valor As String In Valores.Keys
            dtValores.Rows.Add(New Object() {Valor, Valores.Item(Valor)})
        Next

        dtValores.DefaultView.Sort = "Descripcion"
        Me.cbTicketConfigurado.DataSource = dtValores.DefaultView.Table
        Me.cbTicketConfigurado.DisplayMember = "Descripcion"
        Me.cbTicketConfigurado.ValueMember = "Valor"


        lbGeneral.LlenarComboBox(Me.cbIniciarVisita, "TINIVIS", 0)

        Me.Text = vcMensaje.RecuperarDescripcion("ERMCONESC_MGeneral")
        gbParametros.Text = vcMensaje.RecuperarDescripcion("XParametros")
        tabGenerales.Text = vcMensaje.RecuperarDescripcion("XGenerales")
        tabProductos.Text = vcMensaje.RecuperarDescripcion("XProductos")
        tabVenta.Text = vcMensaje.RecuperarDescripcion("XVenta")
        tabVisita.Text = vcMensaje.RecuperarDescripcion("XVisita")
        tabComunicacion.Text = vcMensaje.RecuperarDescripcion("XComunicacion")
        tabCorreoElectronico.Text = vcMensaje.RecuperarDescripcion("COHCorreoElectronico")

        ToolTip1.ShowAlways = True
        LbEmpresa.Text = vcMensaje.RecuperarDescripcion("CONNombreEmpresa")
        ToolTip1.SetToolTip(ebEmpresa.TextBox, vcMensaje.RecuperarDescripcion("CONNombreEmpresaT"))
        lbRFC.Text = vcMensaje.RecuperarDescripcion("CONRFC")
        ToolTip1.SetToolTip(ebRFC.TextBox, vcMensaje.RecuperarDescripcion("CONRFCT"))
        lbTelefono.Text = vcMensaje.RecuperarDescripcion("CONTelefono")
        ToolTip1.SetToolTip(ebTelefono.TextBox, vcMensaje.RecuperarDescripcion("CONTelefonoT"))
        LbPais.Text = vcMensaje.RecuperarDescripcion("CONPais")
        ToolTip1.SetToolTip(ebPais.TextBox, vcMensaje.RecuperarDescripcion("CONPaisT"))
        LbRegion.Text = vcMensaje.RecuperarDescripcion("CONRegion")
        ToolTip1.SetToolTip(EbRegion.TextBox, vcMensaje.RecuperarDescripcion("CONRegionT"))
        lbLocalidad.Text = vcMensaje.RecuperarDescripcion("CONLocalidad")
        ToolTip1.SetToolTip(ebLocalidad.TextBox, vcMensaje.RecuperarDescripcion("CONLocalidadT"))
        lbReferenciaDom.Text = vcMensaje.RecuperarDescripcion("CONReferenciaDom")
        ToolTip1.SetToolTip(ebReferenciaDom.TextBox, vcMensaje.RecuperarDescripcion("CONReferenciaDomT"))
        LbCiudad.Text = vcMensaje.RecuperarDescripcion("CONCiudad")
        ToolTip1.SetToolTip(EbCiudad.TextBox, vcMensaje.RecuperarDescripcion("CONCiudadT"))
        lbColonia.Text = vcMensaje.RecuperarDescripcion("CONColonia")
        ToolTip1.SetToolTip(ebColonia.TextBox, vcMensaje.RecuperarDescripcion("CONColoniaT"))
        lbCalle.Text = vcMensaje.RecuperarDescripcion("CONCalle")
        ToolTip1.SetToolTip(ebCalle.TextBox, vcMensaje.RecuperarDescripcion("CONCalleT"))
        lbNumero.Text = vcMensaje.RecuperarDescripcion("CONNumero")
        ToolTip1.SetToolTip(ebNumero.TextBox, vcMensaje.RecuperarDescripcion("CONNumeroT"))
        lbNumeroInterior.Text = vcMensaje.RecuperarDescripcion("CONNumeroInterior")
        ToolTip1.SetToolTip(ebNumeroInterior.TextBox, vcMensaje.RecuperarDescripcion("CONNumeroInteriorT"))
        lbCodigoPostal.Text = vcMensaje.RecuperarDescripcion("CONCodigoPostal")
        ToolTip1.SetToolTip(ebCodigoPostal.TextBox, vcMensaje.RecuperarDescripcion("CONCodigoPostalT"))
        LbInicio.Text = vcMensaje.RecuperarDescripcion("COHCONHistFechaInicio")
        ToolTip1.SetToolTip(cbFechaInicio, vcMensaje.RecuperarDescripcion("COHCONHistFechaInicio"))
        lblogotipo.Text = vcMensaje.RecuperarDescripcion("CONLogotipo")
        ToolTip1.SetToolTip(PbLogo, vcMensaje.RecuperarDescripcion("CONLogotipoT"))
        btHistorico.Text = vcMensaje.RecuperarDescripcion("BTHistorial")
        ToolTip1.SetToolTip(btHistorico, vcMensaje.RecuperarDescripcion("BTHistorialT"))

        'Tab Generales
        lbLenguaje.Text = vcMensaje.RecuperarDescripcion("COHTipoLenguaje")
        ToolTip1.SetToolTip(cbLenguaje, vcMensaje.RecuperarDescripcion("COHTipoLenguajeT"))
        LbMoneda.Text = vcMensaje.RecuperarDescripcion("COHMonedaID")
        ToolTip1.SetToolTip(cbMoneda, vcMensaje.RecuperarDescripcion("COHMonedaIDT"))
        chbMostrarLogo.Text = vcMensaje.RecuperarDescripcion("COHMostrarLogo")
        ToolTip1.SetToolTip(chbMostrarLogo, vcMensaje.RecuperarDescripcion("COHMostrarLogoT"))


        'Tab Productos
        lbTipoClaveProducto.Text = vcMensaje.RecuperarDescripcion("COHTipoClaveProducto")
        ToolTip1.SetToolTip(cbTipoClaveProducto, vcMensaje.RecuperarDescripcion("COHTipoClaveProductoT"))
        lbDigitoClaveProd.Text = vcMensaje.RecuperarDescripcion("COHDigitoClaveProd")
        ToolTip1.SetToolTip(ebDigitoClaveProd.TextBox, vcMensaje.RecuperarDescripcion("COHDigitoClaveProdT"))
        ToolTip1.SetToolTip(Me.nudDiasSurtido, vcMensaje.RecuperarDescripcion("COHDiasSurtidoT"))
        Me.lbDiasSurtido.Text = vcMensaje.RecuperarDescripcion("COHDiasSurtido")
        Me.chbCambioProducto.Text = vcMensaje.RecuperarDescripcion("COHCambioProducto")
        ToolTip1.SetToolTip(Me.chbCambioProducto, vcMensaje.RecuperarDescripcion("COHCambioProductoT"))

        Me.chbConversionKg.Text = vcMensaje.RecuperarDescripcion("COHConversionKg")
        ToolTip1.SetToolTip(Me.chbConversionKg, vcMensaje.RecuperarDescripcion("COHConversionKgT"))
        Me.chbFiltros.Text = vcMensaje.RecuperarDescripcion("COHFiltroProductos")
        ToolTip1.SetToolTip(Me.chbFiltros, vcMensaje.RecuperarDescripcion("COHFiltroProductosT"))

        'Tab Venta
        chbModificarVenta.Text = vcMensaje.RecuperarDescripcion("COHModificarVenta")
        ToolTip1.SetToolTip(chbModificarVenta, vcMensaje.RecuperarDescripcion("COHModificarVentaT"))
        chbAbonoProgramado.Text = vcMensaje.RecuperarDescripcion("COHAbonoProgramado")
        ToolTip1.SetToolTip(chbAbonoProgramado, vcMensaje.RecuperarDescripcion("COHAbonoProgramadoT"))
        chbVenderApartado.Text = vcMensaje.RecuperarDescripcion("COHVenderApartado")
        ToolTip1.SetToolTip(chbVenderApartado, vcMensaje.RecuperarDescripcion("COHVenderApartadoT"))
        Me.chbCobrarVentas.Text = vcMensaje.RecuperarDescripcion("COHCobrarVentas")
        ToolTip1.SetToolTip(Me.chbCobrarVentas, vcMensaje.RecuperarDescripcion("COHCobrarVentasT"))
        chbPagoAutomatico.Text = vcMensaje.RecuperarDescripcion("COHPagoAutomatico")
        ToolTip1.SetToolTip(chbPagoAutomatico, vcMensaje.RecuperarDescripcion("COHPagoAutomaticoT"))
        lbTipoLimiteCredito.Text = vcMensaje.RecuperarDescripcion("COHTipoLimiteCredito")
        ToolTip1.SetToolTip(cbTipoLimiteCredito, vcMensaje.RecuperarDescripcion("COHTipoLimiteCreditoT"))
        lbPorcentajeRiesgo.Text = vcMensaje.RecuperarDescripcion("COHPorcentajeRiesgo")
        ToolTip1.SetToolTip(ebPorcentajeRiesgo, vcMensaje.RecuperarDescripcion("COHPorcentajeRiesgoT"))
        lbDecimalesImporte.Text = vcMensaje.RecuperarDescripcion("COHDecimalesImporte")
        ToolTip1.SetToolTip(ebDecimalesImporte, vcMensaje.RecuperarDescripcion("COHDecimalesImporteT"))
        lbPorcentajeInteres.Text = vcMensaje.RecuperarDescripcion("COHPorcentajeInteres")
        ToolTip1.SetToolTip(nbPorcentajeInteres, vcMensaje.RecuperarDescripcion("COHPorcentajeInteresT"))
        lblTicketConfigurado.Text = vcMensaje.RecuperarDescripcion("COHTicketConfigurado")
        ToolTip1.SetToolTip(cbTicketConfigurado, vcMensaje.RecuperarDescripcion("COHTicketConfiguradoT"))
        Me.chbVentaSinSurtir.Text = vcMensaje.RecuperarDescripcion("COHVentaSinSurtir")
        ToolTip1.SetToolTip(Me.chbVentaSinSurtir, vcMensaje.RecuperarDescripcion("COHVentaSinSurtirT"))

        'Tab Visita
        Me.lbDiasAnteriores.Text = vcMensaje.RecuperarDescripcion("COHDiasAnteriores")
        ToolTip1.SetToolTip(Me.nudDiasAnteriores, vcMensaje.RecuperarDescripcion("COHDiasAnterioresT"))
        Me.lbDiasPosteriores.Text = vcMensaje.RecuperarDescripcion("COHDiasPosteriores")
        ToolTip1.SetToolTip(Me.nudDiasPosteriores, vcMensaje.RecuperarDescripcion("COHDiasPosterioresT"))
        Me.chbClienteVariasRutas.Text = vcMensaje.RecuperarDescripcion("COHClienteVariasRutas")
        ToolTip1.SetToolTip(Me.chbClienteVariasRutas, vcMensaje.RecuperarDescripcion("COHClienteVariasRutasT"))
        lblIniciarVisita.Text = vcMensaje.RecuperarDescripcion("COHTipoIniciarVisita")
        ToolTip1.SetToolTip(cbIniciarVisita, vcMensaje.RecuperarDescripcion("COHTipoIniciarVisitaT"))
        lbLimiteGPS.Text = vcMensaje.RecuperarDescripcion("COHLimiteGPS")
        ToolTip1.SetToolTip(ebLimiteGPS, vcMensaje.RecuperarDescripcion("COHLimiteGPST"))
        Me.chbCodigoBarrasCliente.Text = vcMensaje.RecuperarDescripcion("COHCodigoBarrasCliente")
        ToolTip1.SetToolTip(Me.chbCodigoBarrasCliente, vcMensaje.RecuperarDescripcion("COHCodigoBarrasClienteT"))
        Me.chbContrasenaCliente.Text = vcMensaje.RecuperarDescripcion("COHContrasenaCliente")
        ToolTip1.SetToolTip(Me.chbContrasenaCliente, vcMensaje.RecuperarDescripcion("COHContrasenaClienteT"))
        Me.chbDatosCteNuevo.Text = vcMensaje.RecuperarDescripcion("COHDatosCteNuevo")
        ToolTip1.SetToolTip(Me.chbDatosCteNuevo, vcMensaje.RecuperarDescripcion("COHDatosCteNuevoT"))
        Me.chbValidaInv.Text = vcMensaje.RecuperarDescripcion("COHValidaInv")
        ToolTip1.SetToolTip(Me.chbValidaInv, vcMensaje.RecuperarDescripcion("COHValidaInvT"))
        Me.chbClientesVisitados.Text = vcMensaje.RecuperarDescripcion("COHClientesVisitados")
        ToolTip1.SetToolTip(Me.chbClientesVisitados, vcMensaje.RecuperarDescripcion("COHClientesVisitadosT"))

        'TabComunicacion
        Me.lbDirectorioSDF.Text = vcMensaje.RecuperarDescripcion("COHDirectorioSDF")
        ToolTip1.SetToolTip(Me.ebDirSDF.TextBox, vcMensaje.RecuperarDescripcion("COHDirectorioSDFT"))
        lblDirInterfaces.Text = vcMensaje.RecuperarDescripcion("COHDirInterfaz")
        ToolTip1.SetToolTip(Me.txtRinterfaz, vcMensaje.RecuperarDescripcion("COHDirInterfazT"))
        Me.chbInterfaz.Text = vcMensaje.RecuperarDescripcion("COHInterfazTXT")
        ToolTip1.SetToolTip(Me.chbInterfaz, vcMensaje.RecuperarDescripcion("COHInterfazTXTT"))
        Me.chbIntUnidadVta.Text = vcMensaje.RecuperarDescripcion("COHIntUnidadVta")
        ToolTip1.SetToolTip(Me.chbIntUnidadVta, vcMensaje.RecuperarDescripcion("COHIntUnidadVtaT"))
        chbInventario.Text = vcMensaje.RecuperarDescripcion("COHInventario")
        ToolTip1.SetToolTip(chbInventario, vcMensaje.RecuperarDescripcion("COHInventarioT"))
        chbAuditarCarga.Text = vcMensaje.RecuperarDescripcion("COHAuditarCarga")
        ToolTip1.SetToolTip(chbAuditarCarga, vcMensaje.RecuperarDescripcion("COHAuditarCargaT"))
        chbPreLiquidacion.Text = vcMensaje.RecuperarDescripcion("COHPreLiquidacion")
        ToolTip1.SetToolTip(chbPreLiquidacion, vcMensaje.RecuperarDescripcion("COHPreLiquidacionT"))
        lbDifPreliquidacion.Text = vcMensaje.RecuperarDescripcion("COHDiferenciaPreliqui")
        ToolTip1.SetToolTip(ebDifPreliquidacion, vcMensaje.RecuperarDescripcion("COHDiferenciaPreliquiT"))
        Me.lbCantidadServicios.Text = vcMensaje.RecuperarDescripcion("COHCantidadSerAct")
        ToolTip1.SetToolTip(Me.nudServiciosActivos, vcMensaje.RecuperarDescripcion("COHCantidadSerActT"))
        chbEnvioParcial.Text = vcMensaje.RecuperarDescripcion("COHEnvioParcial")
        ToolTip1.SetToolTip(chbEnvioParcial, vcMensaje.RecuperarDescripcion("COHEnvioParcialT"))
        chbEliminaEnviado.Text = vcMensaje.RecuperarDescripcion("CONEliminaEnviado")
        ToolTip1.SetToolTip(chbEliminaEnviado, vcMensaje.RecuperarDescripcion("CONEliminaEnviadoT"))


        'TabCorreoElectronico
        lblCOnfirmar.Text = vcMensaje.RecuperarDescripcion("COHConfirmarContraseña")
        ToolTip1.SetToolTip(ebConfirmarPassword, vcMensaje.RecuperarDescripcion("COHConfirmarContraseñaT"))
        lblCorreoElectronico.Text = vcMensaje.RecuperarDescripcion("COHCorreoElectronico")
        ToolTip1.SetToolTip(ebCorreoElectronico, vcMensaje.RecuperarDescripcion("COHCorreoElectronicoT"))
        lblContrasenia.Text = vcMensaje.RecuperarDescripcion("COHContraseña")
        ToolTip1.SetToolTip(ebPassword, vcMensaje.RecuperarDescripcion("COHContraseñaT"))
        lblPuerto.Text = vcMensaje.RecuperarDescripcion("COHPuerto")
        ToolTip1.SetToolTip(ebPuerto, vcMensaje.RecuperarDescripcion("COHPuertoT"))
        lblSMTP.Text = vcMensaje.RecuperarDescripcion("COHServidorSMTP")
        ToolTip1.SetToolTip(ebServidorSMTP, vcMensaje.RecuperarDescripcion("COHServidorSMTPT"))
        chbSSL.Text = vcMensaje.RecuperarDescripcion("COHSSL")
        ToolTip1.SetToolTip(chbSSL, vcMensaje.RecuperarDescripcion("COHSSLT"))

        If Not (vcAcceso.Crear Or vcAcceso.Modificar) Then
            btAceptar.Visible = False
            btCancelar.Text = vcMensaje.RecuperarDescripcion("BTRegresar")
            ToolTip1.SetToolTip(Me.btCancelar, vcMensaje.RecuperarDescripcion("BTRegresar"))
            btCancelar.Icon = btAceptar.Icon
        Else
            btAceptar.Text = vcMensaje.RecuperarDescripcion("BTAceptar")
            ToolTip1.SetToolTip(btAceptar, vcMensaje.RecuperarDescripcion("BTAceptarT"))
            btCancelar.Text = vcMensaje.RecuperarDescripcion("BTCancelar")
            ToolTip1.SetToolTip(btCancelar, vcMensaje.RecuperarDescripcion("BTCancelarT"))
        End If
    End Sub

    Public Sub LlenarDatos()
        If Not vcConfig.Recuperar() Then
            cnNuevo = True
            cbTipoClaveProducto.SelectedValue = 1
            ebDigitoClaveProd.Value = 0
            'chbPromocion.Checked = False
            chbAbonoProgramado.Checked = False
            Me.chbClienteVariasRutas.Checked = False
            Me.chbPreLiquidacion.Checked = False
            Me.ebDifPreliquidacion.Enabled = False
            Me.chbEnvioParcial.Checked = False
        Else
            With vcConfig
                Try
                    Dim ms As New MemoryStream(.Logotipo)
                    PbLogo.Image = System.Drawing.Image.FromStream(ms)
                    ms.Close()
                Catch ex As Exception

                End Try
                ebEmpresa.Text = .NombreEmpresa
                ebRFC.Text = .RFC
                ebTelefono.Text = .Telefono
                ebPais.Text = .Pais
                EbRegion.Text = .Region
                ebLocalidad.Text = .Localidad
                ebReferenciaDom.Text = .ReferenciaDom
                EbCiudad.Text = .Ciudad
                ebColonia.Text = .Colonia
                ebCalle.Text = .Calle
                ebNumero.Text = .Numero
                ebNumeroInterior.Text = .NumeroInterior
                ebCodigoPostal.Text = .CodigoPostal
                cbFechaInicio.Value = .FechaInicio.ToString("dd - MMM - yyyy   HH:mm:ss")

                'Tab General
                cbLenguaje.SelectedValue = .TipoLenguaje
                Me.chbMostrarLogo.Checked = .MostrarLogo

                'Tab Productos
                cbTipoClaveProducto.SelectedValue = .TipoClaveProducto
                ebDigitoClaveProd.Value = .DigitoClaveProd
                Me.nudDiasSurtido.Value = .DiasSurtido
                Me.chbCambioProducto.Checked = .CambioProducto
                Me.chbConversionKg.Checked = .ConversionKg
                Me.chbFiltros.Checked = .FiltroProductos

                'Tab Ventas
                Me.chbModificarVenta.Checked = .ModificarVenta
                Me.chbAbonoProgramado.Checked = .AbonoProgramado
                Me.chbVenderApartado.Checked = .VenderApartado
                Me.chbCobrarVentas.Checked = .CobrarVentas
                Me.chbPagoAutomatico.Checked = .PagoAutomatico
                Me.cbTipoLimiteCredito.SelectedValue = .TipoLimiteCredito
                Me.ebPorcentajeRiesgo.Value = .PorcentajeRiesgo / 100
                Me.nbPorcentajeInteres.Value = .PorcentajeInteres / 100
                Me.ebDecimalesImporte.Value = .DecimalesImporte
                Me.cbTicketConfigurado.SelectedValue = .TicketConfigurado
                Me.chbVentaSinSurtir.Checked = .VentaSinSurtir

                'Tab Visita
                Me.nudDiasAnteriores.Value = .DiasAnteriores
                Me.nudDiasPosteriores.Value = .DiasPosteriores
                Me.chbClienteVariasRutas.Checked = .ClienteVariasRutas
                Me.cbIniciarVisita.SelectedValue = .TipoIniciarVisita
                Me.ebLimiteGPS.Value = .LimiteGPS
                Me.chbCodigoBarrasCliente.Checked = .CodigoBarrasCliente
                Me.chbContrasenaCliente.Checked = .ContrasenaCliente
                Me.chbDatosCteNuevo.Checked = .DatosCteNuevo
                Me.chbValidaInv.Checked = .ValidaInv
                Me.chbClientesVisitados.Checked = .ClientesVisitados

                'Tab Comunicacion
                Me.ebDirSDF.Text = .DirectorioSDF
                Me.txtRinterfaz.Text = .DirInterfaz
                Me.chbInterfaz.Checked = .InterfazTXT
                Me.chbIntUnidadVta.Checked = .IntUnidadVta
                Me.chbInventario.Checked = .Inventario
                Me.chbAuditarCarga.Checked = .AuditarCarga
                Me.chbPreLiquidacion.Checked = .PreLiquidacion
                Me.ebDifPreliquidacion.Value = .DiferenciaPreliqui
                Me.nudServiciosActivos.Value = .CantidadSerAct
                Me.chbEnvioParcial.Checked = .EnvioParcial
                Me.chbEliminaEnviado.Checked = .EliminaEnviado
                Me.ebDifPreliquidacion.Enabled = chbPreLiquidacion.Checked

                'Tab Correo Electronico 
                Me.ebPuerto.Value = .Puerto
                Me.ebCorreoElectronico.Text = .Correo
                Me.ebServidorSMTP.Text = .ServidorSMTP
                Me.ebPassword.Text = .Password
                Me.ebConfirmarPassword.Text = .Password
                Me.chbSSL.Checked = .SSL
            End With
        End If

        Dim vlDt As DataTable
        vlDt = vcConfig.Monedas.Recuperar("TipoEstado = 1")
        If vlDt.Rows.Count > 0 Then
            cbMoneda.DataSource = vlDt
            cbMoneda.DisplayMember = "Nombre"
            cbMoneda.ValueMember = "MonedaID"
            cbMoneda.SelectedValue = vcConfig.MonedaID
        End If
    End Sub

    Public Sub Inicio(ByVal pvAcceso As LbAcceso.cAcceso)
        vcIniciando = True
        vcUsuario = pvAcceso.MUsuarioId
        vcAcceso = pvAcceso
        vcConfig = New ERMCONLOG.cConfiguracion
        vcMensaje = New BASMENLOG.CMensaje

        'ConfiguraTitulos()
        'LlenarDatos()
        'HabilitarControles(vcAcceso.Crear Or vcAcceso.Modificar)

        'Call ValidarDigitos()
        'vcIniciando = False

        'vcHuboCambios = False
        Me.ShowDialog()
        Me.Dispose()
    End Sub

    Private Sub PbLogo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PbLogo.DoubleClick
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.Filter = _
    "Images (*.BMP;*.JPG)|*.BMP;*.JPG"



        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PbLogo.Image = System.Drawing.Image.FromFile(Me.OpenFileDialog1.FileName)
            Dim ms As New MemoryStream

            If Path.GetExtension(Me.OpenFileDialog1.FileName) = "png" Then
                PbLogo.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif)
            Else
                PbLogo.Image.Save(ms, PbLogo.Image.RawFormat)
            End If

            vcConfig.Logotipo = ms.GetBuffer
            ms.Close()
            vcCambioLogo = True

        End If

    End Sub

    Private Sub Controles_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebEmpresa.TextChanged, ebRFC.TextChanged, ebPais.TextChanged, EbRegion.TextChanged, ebLocalidad.TextChanged, ebReferenciaDom.TextChanged, EbCiudad.TextChanged, ebColonia.TextChanged, ebCalle.TextChanged, ebNumero.TextChanged, ebNumeroInterior.TextChanged, ebCodigoPostal.TextChanged, cbFechaInicio.ValueChanged, cbLenguaje.SelectedValueChanged, cbMoneda.SelectedValueChanged, cbTipoClaveProducto.SelectedValueChanged, ebDigitoClaveProd.TextChanged, nudDiasSurtido.ValueChanged, nudServiciosActivos.ValueChanged, nudDiasPosteriores.ValueChanged, nudDiasAnteriores.ValueChanged, ebPorcentajeRiesgo.ValueChanged, nbPorcentajeInteres.ValueChanged, chbFiltros.CheckedChanged, ebLimiteGPS.ValueChanged, chbVenderApartado.CheckedChanged
        If vcIniciando = True Then Exit Sub

        Select Case CType(sender, Object).GetType.Name
            Case "UICheckBox"

        End Select

        vcHuboCambios = True
        'vcActualizarPEM = True
    End Sub

    Private Sub ValidarCampos(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebEmpresa.Validated, ebRFC.Validated, ebPais.Validated, EbRegion.Validated, ebLocalidad.Validated, ebReferenciaDom.Validated, EbCiudad.Validated, ebColonia.Validated, ebCalle.Validated, ebNumero.Validated, ebNumeroInterior.Validated, ebCodigoPostal.Validated, cbFechaInicio.Validated, cbLenguaje.Validated, cbMoneda.Validated, cbTipoClaveProducto.Validated, ebDigitoClaveProd.Validated, ebDifPreliquidacion.Validated, ebPorcentajeRiesgo.Validated, nbPorcentajeInteres.Validated, nbPorcentajeInteres.Validated, ebLimiteGPS.Validated, ebServidorSMTP.Validated, ebCorreoElectronico.Validated, ebPassword.Validated
        Select Case CType(sender.Name, String)
            Case "ebEmpresa", "ebRFC", "ebPais", "EbRegion", "EbLocalidad", "EbReferenciaDom", "EbCiudad", "ebColonia", "ebCalle", "ebNumero", "ebNumeroInterior", "ebCodigoPostal", "ebDigitoClaveProd"
                If IsDBNull(sender.Text) Or IsNothing(sender.Text) Then
                    sender.Text = ""
                End If

                If sender.Text = "" Then
                    epErrores.SetError(sender, vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion("CON" & sender.Tag)}))
                    'CType(sender, Windows.Forms.Control).Focus()
                    Exit Sub
                End If

                If sender.Name = "ebDigitoClaveProd" Then
                    If cbTipoClaveProducto.SelectedValue = 2 Then 'Numérico
                        If ebDigitoClaveProd.Value <= 0 Then
                            epErrores.SetError(ebDigitoClaveProd, vcMensaje.RecuperarDescripcion("E0237", New String() {vcMensaje.RecuperarDescripcion("COHDigitoClaveProd")}))
                            Exit Sub
                        End If
                        If ebDigitoClaveProd.Value > 10 Then
                            epErrores.SetError(ebDigitoClaveProd, vcMensaje.RecuperarDescripcion("E0333", New String() {vcMensaje.RecuperarDescripcion("COHDigitoClaveProd"), "10"}))
                            Exit Sub
                        End If
                    End If
                End If
            Case "cbMoneda", "cbLenguaje", "cbTipoClaveProducto"
                If IsDBNull(sender.SelectedValue) Or IsNothing(sender.SelectedValue) Then
                    sender.SelectedValue = ""
                End If
                If sender.SelectedValue.ToString = "" Then
                    epErrores.SetError(sender, vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion("COH" & sender.Tag)}))
                    Exit Sub
                End If
            Case "cbFechaInicio"
                If IsDBNull(sender.Value) Or IsNothing(sender.Value) Then
                    sender.Value = ""
                End If
                If sender.Value.ToString = "" Then
                    epErrores.SetError(sender, vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion("COH" & sender.Tag)}))
                    Exit Sub
                End If
            Case "ebDifPreliquidacion", "ebPorcentajeRiesgo", "nbPorcentajeInteres", "ebLimiteGPS"
                If sender.value < 0 Then
                    epErrores.SetError(sender, vcMensaje.RecuperarDescripcion("E0007"))
                    Exit Sub
                End If
                'Case "ebCuotasGarantia"
                '    If chbDepGarantia.Checked Then
                '        If IsDBNull(sender.Value) Or IsNothing(sender.Value) Then
                '            sender.Value = 0
                '        End If
                '        If sender.Value <= 0 Then
                '            epErrores.SetError(sender, vcMensaje.RecuperarDescripcion("E0012"))
                '            Exit Sub
                '        End If
                '    End If
            Case "ebServidorSMTP"
                Try
                    If ebServidorSMTP.Text <> "" Then
                        vcConfig.ServidorSMTP = ebServidorSMTP.Text
                        vcConfig.ValidarCOH("ServidorSMTP")
                    End If
                    epErrores.SetError(sender, "")
                Catch ex As LbControlError.cError
                    epErrores.SetError(sender, ex.Mensaje)
                    Exit Sub
                End Try
            Case "ebCorreoElectronico"
                Try
                    If ebCorreoElectronico.Text <> "" Then
                        vcConfig.Correo = ebCorreoElectronico.Text
                        vcConfig.ValidarCOH("Correo")
                    End If
                    epErrores.SetError(sender, "")
                Catch ex As LbControlError.cError
                    epErrores.SetError(sender, ex.Mensaje)
                    Exit Sub
                End Try
            Case "ebPassword"
                Try
                    If ebPassword.Text <> "" Then
                        vcConfig.Password = ebPassword.Text
                        vcConfig.ValidarCOH("Password")
                        epErrores.SetError(sender, "")
                    End If
                Catch ex As LbControlError.cError
                    epErrores.SetError(sender, ex.Mensaje)
                    Exit Sub
                End Try

        End Select
        epErrores.SetError(sender, "")
    End Sub

    Private Sub btAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAceptar.Click
        Try
            If IO.Directory.Exists(txtRinterfaz.Text) = False Then
                TabControl1.SelectedTab = tabComunicacion
                btInterfaces.Focus()

                Throw New LbControlError.cError("E0428")
            End If
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try

        'If (ebCorreoElectronico.Text <> "") Then
        '    Try
        '        Dim oReg As New Regex("^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")

        '        If Not oReg.IsMatch(ebCorreoElectronico.Text) Then
        '            TabControl1.SelectedTab = tabCorreoElectronico
        '            ebCorreoElectronico.Focus()
        '            Throw New LbControlError.cError("E0816")
        '        End If
        '    Catch ex As LbControlError.cError
        '        ex.Mostrar()
        '        Exit Sub
        '    End Try
        'End If


        If (ebPassword.Text <> ebConfirmarPassword.Text) Then
            'Throw New LbControlError.cError("E0701", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("XContraseña", True), New LbControlError.cParametroMSG("XConfirmacion", True)})
            Try
                Throw New LbControlError.cError("E0701", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("XContraseña", True), New LbControlError.cParametroMSG("XConfirmacion", True)})
            Catch ex As LbControlError.cError
                ex.Mostrar()
                Exit Sub
            End Try
        End If



        If vcGuardando Then Exit Sub

        With vcConfig
            If cnNuevo Then vcConfig.ConfiguracionID = lbGeneral.cKeyGen.KEYGEN(Now.Second)
            .NombreEmpresa = ebEmpresa.Text
            .RFC = ebRFC.Text
            .Pais = ebPais.Text
            .Region = EbRegion.Text
            .Localidad = ebLocalidad.Text
            .ReferenciaDom = ebReferenciaDom.Text
            .Telefono = ebTelefono.Text
            '.CodigoBarrasCEDI = Me.EbCodigoBarrasCEDI.Text
            .Ciudad = EbCiudad.Text
            .Colonia = ebColonia.Text
            .Calle = ebCalle.Text
            .Numero = ebNumero.Text
            .NumeroInterior = ebNumeroInterior.Text
            .CodigoPostal = ebCodigoPostal.Text
            .MUsuarioId = vcUsuario
            .MonedaID = cbMoneda.SelectedValue
            .TipoLenguaje = cbLenguaje.SelectedValue
            .TipoClaveProducto = cbTipoClaveProducto.SelectedValue
            If cbTipoClaveProducto.SelectedValue = 1 Then 'Cadena
                .DigitoClaveProd = 0
            Else
                .DigitoClaveProd = ebDigitoClaveProd.Value
            End If

            '.Promocion = chbPromocion.Checked
            .AbonoProgramado = chbAbonoProgramado.Checked
            .CantidadSerAct = Me.nudServiciosActivos.Value
            .DiasSurtido = Me.nudDiasSurtido.Value
            .DiasPosteriores = Me.nudDiasPosteriores.Value
            .DiasAnteriores = Me.nudDiasAnteriores.Value
            .FiltroProductos = Me.chbFiltros.Checked
            .DirectorioSDF = Me.ebDirSDF.Text
            .ClienteVariasRutas = Me.chbClienteVariasRutas.Checked
            .MUsuarioId = vcUsuario
            .DirInterfaz = Me.txtRinterfaz.Text
            .InterfazTXT = Me.chbInterfaz.Checked
            .DepGarantia = False
            .CuotasGarantia = 0
            '.CodigoBarrasCEDI = Me.chbCodigoBarrasCEDI.Checked
            .CodigoBarrasCliente = Me.chbCodigoBarrasCliente.Checked
            .ContrasenaCliente = Me.chbContrasenaCliente.Checked
            .ValidaInv = Me.chbValidaInv.Checked
            .CambioProducto = Me.chbCambioProducto.Checked
            .CobrarVentas = Me.chbCobrarVentas.Checked
            .ConversionKg = Me.chbConversionKg.Checked
            .IntUnidadVta = Me.chbIntUnidadVta.Checked
            '.LimiteCredito = Me.chbLimiteCredito.Checked
            '.VencimientoPagos = Me.chbVencimientoPagos.Checked
            '.DiasVencimiento = Convert.ToInt32(Me.ebDiasVencimiento.Value)
            '.PagoContado = Me.chbPagoContado.Checked
            .EliminaEnviado = Me.chbEliminaEnviado.Checked
            '.LimiteCreditoCheque = Me.chbLimiteCreditoCheque.Checked
            .TicketConfigurado = Me.cbTicketConfigurado.SelectedValue
            .PagoAutomatico = Me.chbPagoAutomatico.Checked
            .PreLiquidacion = Me.chbPreLiquidacion.Checked
            .DiferenciaPreliqui = Me.ebDifPreliquidacion.Value
            .AuditarCarga = Me.chbAuditarCarga.Checked
            .Inventario = Me.chbInventario.Checked
            .ModificarVenta = Me.chbModificarVenta.Checked
            .MostrarLogo = Me.chbMostrarLogo.Checked
            .EnvioParcial = Me.chbEnvioParcial.Checked
            .TipoLimiteCredito = Me.cbTipoLimiteCredito.SelectedValue
            .PorcentajeRiesgo = Me.ebPorcentajeRiesgo.Value * 100
            .PorcentajeInteres = Me.nbPorcentajeInteres.Value * 100
            .DecimalesImporte = Me.ebDecimalesImporte.Value
            .TipoIniciarVisita = Me.cbIniciarVisita.SelectedValue
            .LimiteGPS = Me.ebLimiteGPS.Value
            .ClientesVisitados = Me.chbClientesVisitados.Checked
            .DatosCteNuevo = Me.chbDatosCteNuevo.Checked
            .VenderApartado = Me.chbVenderApartado.Checked
            .VentaSinSurtir = Me.chbVentaSinSurtir.Checked
            'Dim i As Short

            .Password = Me.ebPassword.Text
            .Puerto = Me.ebPuerto.Value
            .ServidorSMTP = Me.ebServidorSMTP.Text
            .Correo = Me.ebCorreoElectronico.Text

            .SSL = Me.chbSSL.Checked
        End With
        Try
            vcConfig.Validar()

            vcGuardando = True
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            If Not cnNuevo Then
                vcConfig.Grabar(vcCambioLogo)
            Else
                vcConfig.Insertar()
            End If
        Catch exer As LbControlError.cError
            exer.Mostrar()
            Select Case exer.Source
                Case "NombreEmpresa"
                    Me.ebEmpresa.Focus()
                Case "RFC"
                    Me.ebRFC.Focus()
                Case "Pais"
                    Me.ebPais.Focus()
                Case "Region"
                    Me.EbRegion.Focus()
                Case "Localidad"
                    Me.ebLocalidad.Focus()
                Case "ReferenciaDom"
                    Me.ebReferenciaDom.Focus()
                    'Case "CodigoBarrasCEDI"
                    '    Me.EbCodigoBarrasCEDI.Focus()
                Case "Ciudad"
                    Me.EbCiudad.Focus()
                Case "Colonia"
                    Me.ebColonia.Focus()
                Case "Calle"
                    Me.ebCalle.Focus()
                Case "Numero"
                    Me.ebNumero.Focus()
                Case "NumeroInterior"
                    Me.ebNumeroInterior.Focus()
                Case "CodigoPostal"
                    Me.ebCodigoPostal.Focus()
                Case "CONHistFechaInicio"
                    Me.cbFechaInicio.Focus()
                Case "TipoLenguaje"
                    TabControl1.SelectedTab = tabGenerales
                    Me.cbLenguaje.Focus()
                Case "TipoClaveProducto"
                    TabControl1.SelectedTab = tabProductos
                    Me.cbTipoClaveProducto.Focus()
                Case "DigitoClaveProd"
                    TabControl1.SelectedTab = tabProductos
                    Me.ebDigitoClaveProd.Focus()
                Case "nudDiasSurtido"
                    TabControl1.SelectedTab = tabProductos
                    nudDiasSurtido.Focus()
                Case "nudDiasAnteriores"
                    TabControl1.SelectedTab = tabVisita
                    nudDiasAnteriores.Focus()
                Case "nudDiasPosteriores"
                    TabControl1.SelectedTab = tabVisita
                    nudDiasPosteriores.Focus()
                    'Case "Promocion"
                    '    Me.chbPromocion.Focus()
                Case "AbonoProgramado"
                    Me.chbAbonoProgramado.Focus()
                Case "ClienteVariasRutas"
                    Me.chbClienteVariasRutas.Focus()
                Case "MonedaId"
                    TabControl1.SelectedTab = tabGenerales
                    Me.cbMoneda.Focus()
                Case "txtRinterfaz"
                    Me.txtRinterfaz.Focus()
                Case "chbInterfaz"
                    Me.chbInterfaz.Focus()
                    'Case "chbDepGarantia"
                    '    Me.chbDepGarantia.Focus()
                    'Case "CuotasGarantia"
                    '    Me.ebCuotasGarantia.Focus()
                Case "DiferenciaPreliqui"
                    Me.ebDifPreliquidacion.Focus()
                    TabControl1.SelectedTab = tabComunicacion
                Case "nudServiciosActivos"
                    TabControl1.SelectedTab = tabComunicacion
                    nudServiciosActivos.Focus()
                Case "chbMostrarLogo"
                    TabControl1.SelectedTab = tabGenerales
                    chbMostrarLogo.Focus()
                Case "PorcentajeRiesgo"
                    TabControl1.SelectedTab = tabVenta
                    ebPorcentajeRiesgo.Focus()
                Case "PorcentajeInteres"
                    TabControl1.SelectedTab = tabVenta
                    nbPorcentajeInteres.Focus()
                Case "DecimalesImporte"
                    TabControl1.SelectedTab = tabVenta
                    ebDecimalesImporte.Focus()
                Case "ServidorSMTP"
                    TabControl1.SelectedTab = tabCorreoElectronico
                    ebServidorSMTP.Focus()
                Case "Correo"
                    TabControl1.SelectedTab = tabCorreoElectronico
                    ebCorreoElectronico.Focus()
                Case "Password"
                    TabControl1.SelectedTab = tabCorreoElectronico
                    ebPassword.Focus()

                Case "SSL"
                    TabControl1.SelectedTab = tabCorreoElectronico
            End Select
            Exit Sub
        End Try
        vcConexion.ConfirmarTran()
        vcGuardando = False
        vcCambioLogo = False
        Me.Cursor = System.Windows.Forms.Cursors.Default
        vcCerrar = True
        Me.Close()
    End Sub

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        vcConexion.DeshacerTran()
        Me.Close()
    End Sub

    Private Sub btHistorico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btHistorico.Click
        If vcGuardando Then Exit Sub
        Dim vlHistorico As New HConfiguracion(vcConfig, vcConexion)
        vlHistorico.ShowDialog()
    End Sub

    Private Sub MGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If vcGuardando Then
            e.Cancel = True
            Exit Sub
        End If

        If Not vcCerrar And (vcHuboCambios Or vcCambioLogo) Then
            'Dim vlRespuesta As MsgBoxResult

            Me.DialogResult = Windows.Forms.DialogResult.None

            If MsgBox(vcMensaje.RecuperarDescripcion("BP0001"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, vcMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub cbTipoClaveProducto_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipoClaveProducto.SelectedValueChanged
        If vcIniciando Then Exit Sub
        If vcConfig.TipoClaveProducto <> 0 Then
            If vcConfig.TipoClaveProducto <> cbTipoClaveProducto.SelectedValue Then
                If vcConexion.EjecutarConsulta("SELECT TOP 1 * FROM Producto").Rows.Count > 0 Then
                    MsgBox(vcMensaje.RecuperarDescripcion("E0335"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                    If cbTipoClaveProducto.SelectedValue = 1 Then
                        cbTipoClaveProducto.SelectedValue = 2
                    Else
                        cbTipoClaveProducto.SelectedValue = 1
                    End If
                    Exit Sub
                End If
            End If
        End If
        Call ValidarDigitos()
    End Sub

    Private Sub ValidarDigitos()
        If cbTipoClaveProducto.SelectedValue = 1 Then 'Cadena
            ebDigitoClaveProd.Enabled = False
        Else 'Numérico
            ebDigitoClaveProd.Enabled = True
            If ebDigitoClaveProd.Value = 0 Then
                ebDigitoClaveProd.Value = 10
            End If
        End If
    End Sub

    Private Sub MGeneral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
#If DEBUG Then
        vcConexion.Conectar("Provider=SQLOLEDB;Data Source=localhost\SQL2005;user id=sa;password=Amesol11.;initial catalog=SKBase")
        vcIniciando = True
        vcUsuario = "Admin"
        vcConfig = New ERMCONLOG.cConfiguracion
        vcMensaje = New BASMENLOG.CMensaje
        vcAcceso = New LbAcceso.cAcceso
        vcMensaje.LlenarDataSet()
        vcAcceso.Crear = True
        vcAcceso.Modificar = True
        vcAcceso.Leer = True
#End If

        ConfiguraTitulos()
        LlenarDatos()
        HabilitarControles(vcAcceso.Crear Or vcAcceso.Modificar)

        Call ValidarDigitos()
        vcIniciando = False

        vcHuboCambios = False
        vcActualizarPEM = False
    End Sub

    Private Sub HabilitarControles(ByVal bHabilitar As Boolean)
        'General
        PbLogo.Enabled = bHabilitar
        ebEmpresa.Enabled = bHabilitar
        ebRFC.Enabled = bHabilitar
        ebTelefono.Enabled = bHabilitar
        ebCalle.Enabled = bHabilitar
        ebNumero.Enabled = bHabilitar
        ebNumeroInterior.Enabled = bHabilitar
        ebCodigoPostal.Enabled = bHabilitar
        ebColonia.Enabled = bHabilitar
        EbCiudad.Enabled = bHabilitar
        EbRegion.Enabled = bHabilitar
        ebLocalidad.Enabled = bHabilitar
        ebReferenciaDom.Enabled = bHabilitar
        ebPais.Enabled = bHabilitar

        btHistorico.Enabled = bHabilitar Or vcAcceso.Leer

        'Tabs
        cbFechaInicio.Enabled = bHabilitar
        pnGenerales.Enabled = bHabilitar
        pnProductos.Enabled = bHabilitar
        pnVenta.Enabled = bHabilitar
        pnVisita.Enabled = bHabilitar
        pnComunicacion.Enabled = bHabilitar
    End Sub

    Private Sub btSeleccionarDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSeleccionarDir.Click
        If Me.FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If FolderBrowserDialog1.SelectedPath.Length > 199 Then
                MsgBox(vcMensaje.RecuperarDescripcion("E0632"), MsgBoxStyle.Critical)
                Exit Sub
            End If

            Me.ebDirSDF.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    'Private Sub UiButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.FolderBrowserDialog1.ShowDialog()
    '    Dim rutas As String
    '    rutas = FolderBrowserDialog1.SelectedPath()

    '    If Len(rutas) > 0 Then
    '        txtRinterfaz.Text = rutas
    '    End If
    'End Sub

    Private Sub chbPreLiquidacion_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbPreLiquidacion.CheckedChanged
        If chbPreLiquidacion.Checked Then
            ebDifPreliquidacion.Enabled = True
        Else
            ebDifPreliquidacion.Enabled = False
            ebDifPreliquidacion.Value = 0
        End If
        vcHuboCambios = True
    End Sub


    Private Sub btInterfaces_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInterfaces.Click
        If Me.FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If (FolderBrowserDialog1.SelectedPath.Length > 199) Then
                MsgBox(vcMensaje.RecuperarDescripcion("E0632"), MsgBoxStyle.Critical)
                Exit Sub
            End If
            Me.txtRinterfaz.Text = FolderBrowserDialog1.SelectedPath
        End If
        vcHuboCambios = True
    End Sub


    Private Sub chbMostrarLogo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbMostrarLogo.CheckedChanged
        If chbMostrarLogo.Checked Then
            If vcConexion.EjecutarConsulta("SELECT * FROM VARValor WHERE Grupo='Impacto'AND VAVClave IN (SELECT distinct TipoModImp FROM Vendedor)").Rows.Count > 0 Then
                MsgBox(vcMensaje.RecuperarDescripcion("E0597"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                chbMostrarLogo.Checked = False
            End If
        End If
        vcHuboCambios = True
    End Sub

    Private Sub btVistaPrevia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btVistaPrevia.Click
        Dim vlVistaPrevia As ERMRECESC.VistaPrevia = Nothing

        Select Case CType(cbTicketConfigurado.SelectedValue, Integer)
            Case 1
                Dim sRECId As String
                Dim sConsulta As String = "select RECId from Recibo where Tipo = 1 and TipoEstado = 1 and Predeterminado = 1"
                sRECId = vcConexion.EjecutarComandoScalar(sConsulta)
                If Not IsNothing(sRECId) Then
                    vlVistaPrevia = New ERMRECESC.VistaPrevia(sRECId, vcMensaje)
                    vlVistaPrevia.PreImpresion(ERMRECESC.VistaPrevia.TipoTicket.Configurado)
                    vlVistaPrevia.ShowDialog()
                Else
                    MsgBox(vcMensaje.RecuperarDescripcion("E0635"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                End If
            Case 2
                vlVistaPrevia = New ERMRECESC.VistaPrevia("", vcMensaje)
                vlVistaPrevia.PreImpresion(ERMRECESC.VistaPrevia.TipoTicket.Ticket1)
                vlVistaPrevia.ShowDialog()
            Case 3
                vlVistaPrevia = New ERMRECESC.VistaPrevia("", vcMensaje)
                vlVistaPrevia.PreImpresion(ERMRECESC.VistaPrevia.TipoTicket.Ticket2)
                vlVistaPrevia.ShowDialog()
                'Case 6
                '    vlVistaPrevia = New ERMRECESC.VistaPrevia("", vcMensaje)
                '    vlVistaPrevia.PreImpresion(ERMRECESC.VistaPrevia.TipoTicket.Ticket3)
                '    vlVistaPrevia.ShowDialog()
        End Select
        If Not vlVistaPrevia Is Nothing Then
            vlVistaPrevia.Dispose()
        End If
    End Sub

    Private Sub cbIniciarVisita_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbIniciarVisita.SelectedValueChanged

        Select Case CInt(cbIniciarVisita.SelectedValue)
            Case 1, 3 'Codigo barras o ambas
                'chbCodigoBarrasCliente.Enabled = True
                'If Not Me.vcIniciando Then chbCodigoBarrasCliente.Checked = True
                chbCodigoBarrasCliente.Checked = True
                chbCodigoBarrasCliente.Enabled = False
                chbContrasenaCliente.Enabled = True
            Case Else
                chbCodigoBarrasCliente.Enabled = True
                'chbCodigoBarrasCliente.Checked = False
                chbContrasenaCliente.Enabled = False
                chbContrasenaCliente.Checked = False
        End Select

        ebLimiteGPS.Enabled = (cbIniciarVisita.SelectedValue = 2 Or cbIniciarVisita.SelectedValue = 3)
        If Not ebLimiteGPS.Enabled Then ebLimiteGPS.Value = 0
        If vcIniciando = True Then Exit Sub
        vcHuboCambios = True
    End Sub

End Class
