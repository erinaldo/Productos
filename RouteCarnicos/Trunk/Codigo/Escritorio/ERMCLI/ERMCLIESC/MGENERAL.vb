Imports System.Text.RegularExpressions
Public Enum eModo
    Crear = 1
    Modificar
    Eliminar
    Leer
End Enum

Public Class MGENERAL

    Inherits FormasBase.Mantenimiento01

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents epErrores As System.Windows.Forms.ErrorProvider
    Friend WithEvents cbTipoImpuesto As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbTipoImpuesto As System.Windows.Forms.Label
    Friend WithEvents ebLimiteCreditoDinero As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ccFechaRegistroSistema As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents cbTipoFiscal As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents cbTipoEstado As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents gbEsquemas As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents grClienteEsquema As Janus.Windows.GridEX.GridEX
    Friend WithEvents btCLECrear As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCLEEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btESQBuscar As Janus.Windows.EditControls.UIButton
    Friend WithEvents gbContacto As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lbTelefonoContacto As System.Windows.Forms.Label
    Friend WithEvents ebTelefonoContacto As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbNombreContacto As System.Windows.Forms.Label
    Friend WithEvents ebNombreContacto As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbLimiteCreditoDinero As System.Windows.Forms.Label
    Friend WithEvents lbFechaNacimiento As System.Windows.Forms.Label
    Friend WithEvents lbIdFiscal As System.Windows.Forms.Label
    Friend WithEvents ebIdFiscal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbTipoFiscal As System.Windows.Forms.Label
    Friend WithEvents lbRazonSocial As System.Windows.Forms.Label
    Friend WithEvents ebRazonSocial As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbNombreCorto As System.Windows.Forms.Label
    Friend WithEvents ebNombreCorto As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbIdElectronico As System.Windows.Forms.Label
    Friend WithEvents ebIdElectronico As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbTipoEstado As System.Windows.Forms.Label
    Friend WithEvents lbFechaRegistroSistema As System.Windows.Forms.Label
    Friend WithEvents lbClienteClave As System.Windows.Forms.Label
    Friend WithEvents ebClienteClave As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ccFechaNacimiento As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents ebLimiteDescuento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lbLimiteDescuento As System.Windows.Forms.Label
    Friend WithEvents sbClienteDomicilio As System.Windows.Forms.VScrollBar
    Friend WithEvents gbClienteDomicilio As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents ebClienteDomicilioId As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCodigoPostal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebNumero As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbCopiar As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents btCopiar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cbTipo As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbCodigoPostal As System.Windows.Forms.Label
    Friend WithEvents ebPoblacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbPoblacion As System.Windows.Forms.Label
    Friend WithEvents lbPais As System.Windows.Forms.Label
    Friend WithEvents ebCalle As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbNumero As System.Windows.Forms.Label
    Friend WithEvents lbColonia As System.Windows.Forms.Label
    Friend WithEvents ebColonia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebPais As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbEntidad As System.Windows.Forms.Label
    Friend WithEvents ebEntidad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbCalle As System.Windows.Forms.Label
    Friend WithEvents lbTipo As System.Windows.Forms.Label
    Friend WithEvents grFrecuencia As Janus.Windows.GridEX.GridEX
    Friend WithEvents btCLDCrear As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCLDEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btMMEBuscar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btMMENuevo As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCLMEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCLPCrear As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCLPEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents grClientePago As Janus.Windows.GridEX.GridEX
    Friend WithEvents lbSaldoEfectivo As System.Windows.Forms.Label
    Friend WithEvents grClienteProducto As Janus.Windows.GridEX.GridEX
    Friend WithEvents lbLineaFrecuencia As System.Windows.Forms.Label
    Friend WithEvents lbFrecuencia As System.Windows.Forms.Label
    Friend WithEvents grCLIFormaVenta As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbClientePago As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbCLIFormaVenta As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents btCFVCrear As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCFVEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCFVHistorico As Janus.Windows.EditControls.UIButton
    Friend WithEvents chbPrestamo As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents btCPRHistorico As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebSaldoEfectivo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents ebSaldoPrestamo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lbSaldoPrestamo As System.Windows.Forms.Label
    Friend WithEvents chbActualizaSaldoCheque As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbVencimientoVenta As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ebDiasVencimiento As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lbDiasVencimiento As System.Windows.Forms.Label
    Friend WithEvents chbExclusividad As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents lbVigExclusividad As System.Windows.Forms.Label
    Friend WithEvents ebVigExclusividad As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents gbParametros As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lbFechaFactura As System.Windows.Forms.Label
    Friend WithEvents ebFechaFactura As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents lbNumInt As System.Windows.Forms.Label
    Friend WithEvents ebNumInt As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebReferencia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbReferencia As System.Windows.Forms.Label
    Friend WithEvents ebLocalidad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbLocalidad As System.Windows.Forms.Label
    Friend WithEvents lbCorreoElectronico As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tabGenerales As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tabDomicilio As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tabMensajes As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel4 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tabConVenta As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel5 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tabSaldos As DevComponents.DotNetBar.TabItem
    Friend WithEvents lbCoordenadaY As System.Windows.Forms.Label
    Friend WithEvents lbCoordenadaX As System.Windows.Forms.Label
    Friend WithEvents ebCoordenadaY As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebCoordenadaX As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbSaldoProducto As System.Windows.Forms.Label
    Friend WithEvents ebSaldoProducto As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents chbExigirOrden As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents TabControlPanel6 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tabDesglosaImpuesto As DevComponents.DotNetBar.TabItem
    Friend WithEvents chbDesgloseImpuesto As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents grClienteMensaje As Janus.Windows.GridEX.GridEX
    Friend WithEvents chbCriterioCredito As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbImprimirPagare As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents gbConfNumCta As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents grCLIConfNumCta As Janus.Windows.GridEX.GridEX
    Friend WithEvents gbExcepcionDesglose As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents grDesgloseImpuesto As Janus.Windows.GridEX.GridEX
    Friend WithEvents btCNDIBuscar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCNDINuevo As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCNDIEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents chbCapturaDatosFacturacion As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents ebCorreoElectronico As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim grClienteEsquema_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grFrecuencia_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grClientePago_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grClienteProducto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grCLIFormaVenta_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grCLIConfNumCta_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grDesgloseImpuesto_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grClienteMensaje_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MGENERAL))
        Me.epErrores = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cbTipoImpuesto = New Janus.Windows.EditControls.UIComboBox
        Me.lbTipoImpuesto = New System.Windows.Forms.Label
        Me.ebLimiteCreditoDinero = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ccFechaRegistroSistema = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.cbTipoFiscal = New Janus.Windows.EditControls.UIComboBox
        Me.cbTipoEstado = New Janus.Windows.EditControls.UIComboBox
        Me.gbEsquemas = New Janus.Windows.EditControls.UIGroupBox
        Me.grClienteEsquema = New Janus.Windows.GridEX.GridEX
        Me.btCLECrear = New Janus.Windows.EditControls.UIButton
        Me.btCLEEliminar = New Janus.Windows.EditControls.UIButton
        Me.btESQBuscar = New Janus.Windows.EditControls.UIButton
        Me.gbContacto = New Janus.Windows.EditControls.UIGroupBox
        Me.lbCorreoElectronico = New System.Windows.Forms.Label
        Me.ebCorreoElectronico = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbTelefonoContacto = New System.Windows.Forms.Label
        Me.ebTelefonoContacto = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbNombreContacto = New System.Windows.Forms.Label
        Me.ebNombreContacto = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbLimiteCreditoDinero = New System.Windows.Forms.Label
        Me.lbFechaNacimiento = New System.Windows.Forms.Label
        Me.lbIdFiscal = New System.Windows.Forms.Label
        Me.ebIdFiscal = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbTipoFiscal = New System.Windows.Forms.Label
        Me.lbRazonSocial = New System.Windows.Forms.Label
        Me.ebRazonSocial = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbNombreCorto = New System.Windows.Forms.Label
        Me.ebNombreCorto = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbIdElectronico = New System.Windows.Forms.Label
        Me.ebIdElectronico = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbTipoEstado = New System.Windows.Forms.Label
        Me.lbFechaRegistroSistema = New System.Windows.Forms.Label
        Me.lbClienteClave = New System.Windows.Forms.Label
        Me.ebClienteClave = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ccFechaNacimiento = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.ebLimiteDescuento = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.lbLimiteDescuento = New System.Windows.Forms.Label
        Me.sbClienteDomicilio = New System.Windows.Forms.VScrollBar
        Me.gbClienteDomicilio = New Janus.Windows.EditControls.UIGroupBox
        Me.ebCoordenadaY = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebCoordenadaX = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbCoordenadaY = New System.Windows.Forms.Label
        Me.lbCoordenadaX = New System.Windows.Forms.Label
        Me.ebReferencia = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbReferencia = New System.Windows.Forms.Label
        Me.lbFrecuencia = New System.Windows.Forms.Label
        Me.lbLineaFrecuencia = New System.Windows.Forms.Label
        Me.ebClienteDomicilioId = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebCodigoPostal = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebNumero = New Janus.Windows.GridEX.EditControls.EditBox
        Me.cbCopiar = New Janus.Windows.EditControls.UIComboBox
        Me.btCopiar = New Janus.Windows.EditControls.UIButton
        Me.cbTipo = New Janus.Windows.EditControls.UIComboBox
        Me.lbCodigoPostal = New System.Windows.Forms.Label
        Me.ebPoblacion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbPoblacion = New System.Windows.Forms.Label
        Me.lbPais = New System.Windows.Forms.Label
        Me.ebCalle = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbNumero = New System.Windows.Forms.Label
        Me.lbColonia = New System.Windows.Forms.Label
        Me.ebColonia = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebPais = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbEntidad = New System.Windows.Forms.Label
        Me.ebEntidad = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbCalle = New System.Windows.Forms.Label
        Me.lbTipo = New System.Windows.Forms.Label
        Me.grFrecuencia = New Janus.Windows.GridEX.GridEX
        Me.lbNumInt = New System.Windows.Forms.Label
        Me.ebNumInt = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebLocalidad = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbLocalidad = New System.Windows.Forms.Label
        Me.btCLDCrear = New Janus.Windows.EditControls.UIButton
        Me.btCLDEliminar = New Janus.Windows.EditControls.UIButton
        Me.btMMEBuscar = New Janus.Windows.EditControls.UIButton
        Me.btMMENuevo = New Janus.Windows.EditControls.UIButton
        Me.btCLMEliminar = New Janus.Windows.EditControls.UIButton
        Me.btCLPCrear = New Janus.Windows.EditControls.UIButton
        Me.btCLPEliminar = New Janus.Windows.EditControls.UIButton
        Me.grClientePago = New Janus.Windows.GridEX.GridEX
        Me.lbSaldoEfectivo = New System.Windows.Forms.Label
        Me.grClienteProducto = New Janus.Windows.GridEX.GridEX
        Me.gbParametros = New Janus.Windows.EditControls.UIGroupBox
        Me.chbImprimirPagare = New Janus.Windows.EditControls.UICheckBox
        Me.chbCriterioCredito = New Janus.Windows.EditControls.UICheckBox
        Me.chbExigirOrden = New Janus.Windows.EditControls.UICheckBox
        Me.ebDiasVencimiento = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.lbDiasVencimiento = New System.Windows.Forms.Label
        Me.chbVencimientoVenta = New Janus.Windows.EditControls.UICheckBox
        Me.chbActualizaSaldoCheque = New Janus.Windows.EditControls.UICheckBox
        Me.ebVigExclusividad = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.lbVigExclusividad = New System.Windows.Forms.Label
        Me.chbExclusividad = New Janus.Windows.EditControls.UICheckBox
        Me.chbPrestamo = New Janus.Windows.EditControls.UICheckBox
        Me.gbClientePago = New Janus.Windows.EditControls.UIGroupBox
        Me.gbCLIFormaVenta = New Janus.Windows.EditControls.UIGroupBox
        Me.btCFVHistorico = New Janus.Windows.EditControls.UIButton
        Me.btCFVCrear = New Janus.Windows.EditControls.UIButton
        Me.btCFVEliminar = New Janus.Windows.EditControls.UIButton
        Me.grCLIFormaVenta = New Janus.Windows.GridEX.GridEX
        Me.lbFechaFactura = New System.Windows.Forms.Label
        Me.ebFechaFactura = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.ebSaldoEfectivo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebSaldoPrestamo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.lbSaldoPrestamo = New System.Windows.Forms.Label
        Me.btCPRHistorico = New Janus.Windows.EditControls.UIButton
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel6 = New DevComponents.DotNetBar.TabControlPanel
        Me.gbConfNumCta = New Janus.Windows.EditControls.UIGroupBox
        Me.grCLIConfNumCta = New Janus.Windows.GridEX.GridEX
        Me.gbExcepcionDesglose = New Janus.Windows.EditControls.UIGroupBox
        Me.grDesgloseImpuesto = New Janus.Windows.GridEX.GridEX
        Me.btCNDIBuscar = New Janus.Windows.EditControls.UIButton
        Me.btCNDINuevo = New Janus.Windows.EditControls.UIButton
        Me.btCNDIEliminar = New Janus.Windows.EditControls.UIButton
        Me.chbDesgloseImpuesto = New Janus.Windows.EditControls.UICheckBox
        Me.tabDesglosaImpuesto = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.tabGenerales = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel
        Me.grClienteMensaje = New Janus.Windows.GridEX.GridEX
        Me.tabMensajes = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel
        Me.tabConVenta = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel
        Me.tabDomicilio = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel5 = New DevComponents.DotNetBar.TabControlPanel
        Me.ebSaldoProducto = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.lbSaldoProducto = New System.Windows.Forms.Label
        Me.tabSaldos = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.chbCapturaDatosFacturacion = New Janus.Windows.EditControls.UICheckBox
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbEsquemas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEsquemas.SuspendLayout()
        CType(Me.grClienteEsquema, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbContacto.SuspendLayout()
        CType(Me.gbClienteDomicilio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbClienteDomicilio.SuspendLayout()
        CType(Me.grFrecuencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grClientePago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grClienteProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbParametros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbParametros.SuspendLayout()
        CType(Me.gbClientePago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbClientePago.SuspendLayout()
        CType(Me.gbCLIFormaVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCLIFormaVenta.SuspendLayout()
        CType(Me.grCLIFormaVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel6.SuspendLayout()
        CType(Me.gbConfNumCta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbConfNumCta.SuspendLayout()
        CType(Me.grCLIConfNumCta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbExcepcionDesglose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbExcepcionDesglose.SuspendLayout()
        CType(Me.grDesgloseImpuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel1.SuspendLayout()
        Me.TabControlPanel3.SuspendLayout()
        CType(Me.grClienteMensaje, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel4.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.TabControlPanel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'EbClave
        '
        Me.EbClave.Location = New System.Drawing.Point(20, 364)
        Me.EbClave.Size = New System.Drawing.Size(4, 20)
        Me.EbClave.Visible = False
        '
        'lbClave
        '
        Me.lbClave.Location = New System.Drawing.Point(8, 364)
        Me.lbClave.Size = New System.Drawing.Size(4, 20)
        Me.lbClave.Visible = False
        '
        'BtAceptar
        '
        Me.BtAceptar.Location = New System.Drawing.Point(632, 640)
        Me.BtAceptar.TabIndex = 1
        '
        'BtCancelar
        '
        Me.BtCancelar.Location = New System.Drawing.Point(744, 640)
        Me.BtCancelar.TabIndex = 2
        '
        'lbLinea
        '
        Me.lbLinea.Location = New System.Drawing.Point(32, 372)
        Me.lbLinea.Size = New System.Drawing.Size(4, 3)
        Me.lbLinea.Visible = False
        '
        'epErrores
        '
        Me.epErrores.ContainerControl = Me
        '
        'cbTipoImpuesto
        '
        Me.cbTipoImpuesto.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipoImpuesto.Location = New System.Drawing.Point(640, 16)
        Me.cbTipoImpuesto.Name = "cbTipoImpuesto"
        Me.cbTipoImpuesto.Size = New System.Drawing.Size(176, 20)
        Me.cbTipoImpuesto.TabIndex = 14
        Me.cbTipoImpuesto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbTipoImpuesto
        '
        Me.lbTipoImpuesto.BackColor = System.Drawing.Color.Transparent
        Me.lbTipoImpuesto.Location = New System.Drawing.Point(484, 16)
        Me.lbTipoImpuesto.Name = "lbTipoImpuesto"
        Me.lbTipoImpuesto.Size = New System.Drawing.Size(149, 20)
        Me.lbTipoImpuesto.TabIndex = 4
        Me.lbTipoImpuesto.Text = "Tipo Impuesto"
        Me.lbTipoImpuesto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebLimiteCreditoDinero
        '
        Me.ebLimiteCreditoDinero.DecimalDigits = 2
        Me.ebLimiteCreditoDinero.EditMode = Janus.Windows.GridEX.NumericEditMode.Value
        Me.ebLimiteCreditoDinero.FormatString = "##,###,##0.00"
        Me.ebLimiteCreditoDinero.Location = New System.Drawing.Point(352, 16)
        Me.ebLimiteCreditoDinero.MaxLength = 11
        Me.ebLimiteCreditoDinero.Name = "ebLimiteCreditoDinero"
        Me.ebLimiteCreditoDinero.Size = New System.Drawing.Size(48, 20)
        Me.ebLimiteCreditoDinero.TabIndex = 13
        Me.ebLimiteCreditoDinero.Text = "0.00"
        Me.ebLimiteCreditoDinero.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebLimiteCreditoDinero.Value = 0
        Me.ebLimiteCreditoDinero.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        Me.ebLimiteCreditoDinero.Visible = False
        Me.ebLimiteCreditoDinero.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ccFechaRegistroSistema
        '
        '
        '
        '
        Me.ccFechaRegistroSistema.DropDownCalendar.FirstMonth = New Date(2006, 5, 1, 0, 0, 0, 0)
        Me.ccFechaRegistroSistema.DropDownCalendar.Name = ""
        Me.ccFechaRegistroSistema.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.ccFechaRegistroSistema.Location = New System.Drawing.Point(417, 8)
        Me.ccFechaRegistroSistema.Name = "ccFechaRegistroSistema"
        Me.ccFechaRegistroSistema.Size = New System.Drawing.Size(128, 20)
        Me.ccFechaRegistroSistema.TabIndex = 2
        Me.ccFechaRegistroSistema.Value = New Date(2007, 10, 12, 0, 0, 0, 0)
        Me.ccFechaRegistroSistema.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbTipoFiscal
        '
        Me.cbTipoFiscal.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipoFiscal.Location = New System.Drawing.Point(136, 16)
        Me.cbTipoFiscal.Name = "cbTipoFiscal"
        Me.cbTipoFiscal.Size = New System.Drawing.Size(151, 20)
        Me.cbTipoFiscal.TabIndex = 12
        Me.cbTipoFiscal.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cbTipoEstado
        '
        Me.cbTipoEstado.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipoEstado.Location = New System.Drawing.Point(693, 8)
        Me.cbTipoEstado.Name = "cbTipoEstado"
        Me.cbTipoEstado.Size = New System.Drawing.Size(128, 20)
        Me.cbTipoEstado.TabIndex = 3
        Me.cbTipoEstado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbEsquemas
        '
        Me.gbEsquemas.BackColor = System.Drawing.Color.Transparent
        Me.gbEsquemas.Controls.Add(Me.grClienteEsquema)
        Me.gbEsquemas.Controls.Add(Me.btCLECrear)
        Me.gbEsquemas.Controls.Add(Me.btCLEEliminar)
        Me.gbEsquemas.Controls.Add(Me.btESQBuscar)
        Me.gbEsquemas.Location = New System.Drawing.Point(5, 368)
        Me.gbEsquemas.Name = "gbEsquemas"
        Me.gbEsquemas.Size = New System.Drawing.Size(832, 156)
        Me.gbEsquemas.TabIndex = 18
        Me.gbEsquemas.Text = "Esquemas"
        Me.gbEsquemas.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2003
        '
        'grClienteEsquema
        '
        grClienteEsquema_DesignTimeLayout.LayoutString = resources.GetString("grClienteEsquema_DesignTimeLayout.LayoutString")
        Me.grClienteEsquema.DesignTimeLayout = grClienteEsquema_DesignTimeLayout
        Me.grClienteEsquema.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grClienteEsquema.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grClienteEsquema.GroupByBoxVisible = False
        Me.grClienteEsquema.Location = New System.Drawing.Point(12, 16)
        Me.grClienteEsquema.Name = "grClienteEsquema"
        Me.grClienteEsquema.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grClienteEsquema.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grClienteEsquema.Size = New System.Drawing.Size(720, 128)
        Me.grClienteEsquema.TabIndex = 23
        Me.grClienteEsquema.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        Me.grClienteEsquema.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btCLECrear
        '
        Me.btCLECrear.Icon = CType(resources.GetObject("btCLECrear.Icon"), System.Drawing.Icon)
        Me.btCLECrear.Location = New System.Drawing.Point(740, 20)
        Me.btCLECrear.Name = "btCLECrear"
        Me.btCLECrear.Size = New System.Drawing.Size(80, 24)
        Me.btCLECrear.TabIndex = 24
        Me.btCLECrear.Text = "Crear"
        Me.btCLECrear.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCLEEliminar
        '
        Me.btCLEEliminar.CausesValidation = False
        Me.btCLEEliminar.Icon = CType(resources.GetObject("btCLEEliminar.Icon"), System.Drawing.Icon)
        Me.btCLEEliminar.Location = New System.Drawing.Point(740, 52)
        Me.btCLEEliminar.Name = "btCLEEliminar"
        Me.btCLEEliminar.Size = New System.Drawing.Size(80, 24)
        Me.btCLEEliminar.TabIndex = 25
        Me.btCLEEliminar.Text = "Eliminar"
        Me.btCLEEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btESQBuscar
        '
        Me.btESQBuscar.Icon = CType(resources.GetObject("btESQBuscar.Icon"), System.Drawing.Icon)
        Me.btESQBuscar.Location = New System.Drawing.Point(740, 84)
        Me.btESQBuscar.Name = "btESQBuscar"
        Me.btESQBuscar.Size = New System.Drawing.Size(80, 24)
        Me.btESQBuscar.TabIndex = 26
        Me.btESQBuscar.Text = "Buscar"
        Me.btESQBuscar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'gbContacto
        '
        Me.gbContacto.BackColor = System.Drawing.Color.Transparent
        Me.gbContacto.Controls.Add(Me.lbCorreoElectronico)
        Me.gbContacto.Controls.Add(Me.ebCorreoElectronico)
        Me.gbContacto.Controls.Add(Me.lbTelefonoContacto)
        Me.gbContacto.Controls.Add(Me.ebTelefonoContacto)
        Me.gbContacto.Controls.Add(Me.lbNombreContacto)
        Me.gbContacto.Controls.Add(Me.ebNombreContacto)
        Me.gbContacto.Location = New System.Drawing.Point(5, 156)
        Me.gbContacto.Name = "gbContacto"
        Me.gbContacto.Size = New System.Drawing.Size(832, 76)
        Me.gbContacto.TabIndex = 16
        Me.gbContacto.Text = "Contacto"
        Me.gbContacto.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lbCorreoElectronico
        '
        Me.lbCorreoElectronico.BackColor = System.Drawing.Color.Transparent
        Me.lbCorreoElectronico.Location = New System.Drawing.Point(8, 40)
        Me.lbCorreoElectronico.Name = "lbCorreoElectronico"
        Me.lbCorreoElectronico.Size = New System.Drawing.Size(128, 20)
        Me.lbCorreoElectronico.TabIndex = 4
        Me.lbCorreoElectronico.Text = "Correo Electronico"
        Me.lbCorreoElectronico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebCorreoElectronico
        '
        Me.ebCorreoElectronico.Location = New System.Drawing.Point(140, 40)
        Me.ebCorreoElectronico.MaxLength = 64
        Me.ebCorreoElectronico.Name = "ebCorreoElectronico"
        Me.ebCorreoElectronico.Size = New System.Drawing.Size(260, 20)
        Me.ebCorreoElectronico.TabIndex = 11
        Me.ebCorreoElectronico.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCorreoElectronico.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbTelefonoContacto
        '
        Me.lbTelefonoContacto.BackColor = System.Drawing.Color.Transparent
        Me.lbTelefonoContacto.Location = New System.Drawing.Point(556, 16)
        Me.lbTelefonoContacto.Name = "lbTelefonoContacto"
        Me.lbTelefonoContacto.Size = New System.Drawing.Size(132, 20)
        Me.lbTelefonoContacto.TabIndex = 2
        Me.lbTelefonoContacto.Text = "Teléfono"
        Me.lbTelefonoContacto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebTelefonoContacto
        '
        Me.ebTelefonoContacto.Location = New System.Drawing.Point(692, 16)
        Me.ebTelefonoContacto.MaxLength = 64
        Me.ebTelefonoContacto.Name = "ebTelefonoContacto"
        Me.ebTelefonoContacto.Size = New System.Drawing.Size(126, 20)
        Me.ebTelefonoContacto.TabIndex = 10
        Me.ebTelefonoContacto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTelefonoContacto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbNombreContacto
        '
        Me.lbNombreContacto.BackColor = System.Drawing.Color.Transparent
        Me.lbNombreContacto.Location = New System.Drawing.Point(8, 16)
        Me.lbNombreContacto.Name = "lbNombreContacto"
        Me.lbNombreContacto.Size = New System.Drawing.Size(128, 20)
        Me.lbNombreContacto.TabIndex = 0
        Me.lbNombreContacto.Text = "Nombre"
        Me.lbNombreContacto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebNombreContacto
        '
        Me.ebNombreContacto.Location = New System.Drawing.Point(140, 16)
        Me.ebNombreContacto.MaxLength = 64
        Me.ebNombreContacto.Name = "ebNombreContacto"
        Me.ebNombreContacto.Size = New System.Drawing.Size(404, 20)
        Me.ebNombreContacto.TabIndex = 9
        Me.ebNombreContacto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombreContacto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbLimiteCreditoDinero
        '
        Me.lbLimiteCreditoDinero.BackColor = System.Drawing.Color.Transparent
        Me.lbLimiteCreditoDinero.Location = New System.Drawing.Point(307, 16)
        Me.lbLimiteCreditoDinero.Name = "lbLimiteCreditoDinero"
        Me.lbLimiteCreditoDinero.Size = New System.Drawing.Size(45, 20)
        Me.lbLimiteCreditoDinero.TabIndex = 2
        Me.lbLimiteCreditoDinero.Text = "Límite Crédito"
        Me.lbLimiteCreditoDinero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbLimiteCreditoDinero.Visible = False
        '
        'lbFechaNacimiento
        '
        Me.lbFechaNacimiento.BackColor = System.Drawing.Color.Transparent
        Me.lbFechaNacimiento.Location = New System.Drawing.Point(557, 112)
        Me.lbFechaNacimiento.Name = "lbFechaNacimiento"
        Me.lbFechaNacimiento.Size = New System.Drawing.Size(132, 20)
        Me.lbFechaNacimiento.TabIndex = 14
        Me.lbFechaNacimiento.Text = "Fecha Nacimiento"
        Me.lbFechaNacimiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbIdFiscal
        '
        Me.lbIdFiscal.BackColor = System.Drawing.Color.Transparent
        Me.lbIdFiscal.Location = New System.Drawing.Point(5, 86)
        Me.lbIdFiscal.Name = "lbIdFiscal"
        Me.lbIdFiscal.Size = New System.Drawing.Size(132, 20)
        Me.lbIdFiscal.TabIndex = 10
        Me.lbIdFiscal.Text = "RFC"
        Me.lbIdFiscal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebIdFiscal
        '
        Me.ebIdFiscal.Location = New System.Drawing.Point(141, 86)
        Me.ebIdFiscal.MaxLength = 20
        Me.ebIdFiscal.Name = "ebIdFiscal"
        Me.ebIdFiscal.Size = New System.Drawing.Size(264, 20)
        Me.ebIdFiscal.TabIndex = 6
        Me.ebIdFiscal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebIdFiscal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbTipoFiscal
        '
        Me.lbTipoFiscal.BackColor = System.Drawing.Color.Transparent
        Me.lbTipoFiscal.Location = New System.Drawing.Point(8, 16)
        Me.lbTipoFiscal.Name = "lbTipoFiscal"
        Me.lbTipoFiscal.Size = New System.Drawing.Size(132, 20)
        Me.lbTipoFiscal.TabIndex = 0
        Me.lbTipoFiscal.Text = "Documento"
        Me.lbTipoFiscal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbRazonSocial
        '
        Me.lbRazonSocial.BackColor = System.Drawing.Color.Transparent
        Me.lbRazonSocial.Location = New System.Drawing.Point(5, 60)
        Me.lbRazonSocial.Name = "lbRazonSocial"
        Me.lbRazonSocial.Size = New System.Drawing.Size(132, 20)
        Me.lbRazonSocial.TabIndex = 8
        Me.lbRazonSocial.Text = "Razón Social"
        Me.lbRazonSocial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebRazonSocial
        '
        Me.ebRazonSocial.Location = New System.Drawing.Point(141, 60)
        Me.ebRazonSocial.MaxLength = 128
        Me.ebRazonSocial.Name = "ebRazonSocial"
        Me.ebRazonSocial.Size = New System.Drawing.Size(680, 20)
        Me.ebRazonSocial.TabIndex = 5
        Me.ebRazonSocial.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebRazonSocial.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbNombreCorto
        '
        Me.lbNombreCorto.BackColor = System.Drawing.Color.Transparent
        Me.lbNombreCorto.Location = New System.Drawing.Point(5, 112)
        Me.lbNombreCorto.Name = "lbNombreCorto"
        Me.lbNombreCorto.Size = New System.Drawing.Size(132, 20)
        Me.lbNombreCorto.TabIndex = 12
        Me.lbNombreCorto.Text = "Nombre Corto"
        Me.lbNombreCorto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebNombreCorto
        '
        Me.ebNombreCorto.Location = New System.Drawing.Point(141, 112)
        Me.ebNombreCorto.MaxLength = 32
        Me.ebNombreCorto.Name = "ebNombreCorto"
        Me.ebNombreCorto.Size = New System.Drawing.Size(264, 20)
        Me.ebNombreCorto.TabIndex = 7
        Me.ebNombreCorto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombreCorto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbIdElectronico
        '
        Me.lbIdElectronico.BackColor = System.Drawing.Color.Transparent
        Me.lbIdElectronico.Location = New System.Drawing.Point(5, 34)
        Me.lbIdElectronico.Name = "lbIdElectronico"
        Me.lbIdElectronico.Size = New System.Drawing.Size(132, 20)
        Me.lbIdElectronico.TabIndex = 6
        Me.lbIdElectronico.Text = "Código de Barras"
        Me.lbIdElectronico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebIdElectronico
        '
        Me.ebIdElectronico.Location = New System.Drawing.Point(141, 34)
        Me.ebIdElectronico.MaxLength = 64
        Me.ebIdElectronico.Name = "ebIdElectronico"
        Me.ebIdElectronico.Size = New System.Drawing.Size(404, 20)
        Me.ebIdElectronico.TabIndex = 4
        Me.ebIdElectronico.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebIdElectronico.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbTipoEstado
        '
        Me.lbTipoEstado.BackColor = System.Drawing.Color.Transparent
        Me.lbTipoEstado.Location = New System.Drawing.Point(557, 8)
        Me.lbTipoEstado.Name = "lbTipoEstado"
        Me.lbTipoEstado.Size = New System.Drawing.Size(132, 20)
        Me.lbTipoEstado.TabIndex = 4
        Me.lbTipoEstado.Text = "Estado"
        Me.lbTipoEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbFechaRegistroSistema
        '
        Me.lbFechaRegistroSistema.BackColor = System.Drawing.Color.Transparent
        Me.lbFechaRegistroSistema.Location = New System.Drawing.Point(281, 8)
        Me.lbFechaRegistroSistema.Name = "lbFechaRegistroSistema"
        Me.lbFechaRegistroSistema.Size = New System.Drawing.Size(132, 20)
        Me.lbFechaRegistroSistema.TabIndex = 2
        Me.lbFechaRegistroSistema.Text = "Fecha Registro"
        Me.lbFechaRegistroSistema.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbClienteClave
        '
        Me.lbClienteClave.BackColor = System.Drawing.Color.Transparent
        Me.lbClienteClave.Location = New System.Drawing.Point(5, 8)
        Me.lbClienteClave.Name = "lbClienteClave"
        Me.lbClienteClave.Size = New System.Drawing.Size(132, 20)
        Me.lbClienteClave.TabIndex = 0
        Me.lbClienteClave.Text = "Clave"
        Me.lbClienteClave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebClienteClave
        '
        Me.ebClienteClave.Location = New System.Drawing.Point(141, 8)
        Me.ebClienteClave.MaxLength = 10
        Me.ebClienteClave.Name = "ebClienteClave"
        Me.ebClienteClave.Size = New System.Drawing.Size(128, 20)
        Me.ebClienteClave.TabIndex = 1
        Me.ebClienteClave.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteClave.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ccFechaNacimiento
        '
        '
        '
        '
        Me.ccFechaNacimiento.DropDownCalendar.FirstMonth = New Date(2006, 5, 1, 0, 0, 0, 0)
        Me.ccFechaNacimiento.DropDownCalendar.Name = ""
        Me.ccFechaNacimiento.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.ccFechaNacimiento.Location = New System.Drawing.Point(693, 112)
        Me.ccFechaNacimiento.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.ccFechaNacimiento.Name = "ccFechaNacimiento"
        Me.ccFechaNacimiento.Size = New System.Drawing.Size(128, 20)
        Me.ccFechaNacimiento.TabIndex = 8
        Me.ccFechaNacimiento.Value = New Date(2007, 10, 12, 0, 0, 0, 0)
        Me.ccFechaNacimiento.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'ebLimiteDescuento
        '
        Me.ebLimiteDescuento.DecimalDigits = 2
        Me.ebLimiteDescuento.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Percent
        Me.ebLimiteDescuento.Location = New System.Drawing.Point(17, 4)
        Me.ebLimiteDescuento.MaxLength = 10
        Me.ebLimiteDescuento.Name = "ebLimiteDescuento"
        Me.ebLimiteDescuento.Size = New System.Drawing.Size(16, 20)
        Me.ebLimiteDescuento.TabIndex = 10
        Me.ebLimiteDescuento.Text = "0.00 %"
        Me.ebLimiteDescuento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebLimiteDescuento.Value = 0
        Me.ebLimiteDescuento.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        Me.ebLimiteDescuento.Visible = False
        Me.ebLimiteDescuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbLimiteDescuento
        '
        Me.lbLimiteDescuento.BackColor = System.Drawing.Color.Transparent
        Me.lbLimiteDescuento.Location = New System.Drawing.Point(5, 4)
        Me.lbLimiteDescuento.Name = "lbLimiteDescuento"
        Me.lbLimiteDescuento.Size = New System.Drawing.Size(8, 20)
        Me.lbLimiteDescuento.TabIndex = 21
        Me.lbLimiteDescuento.Text = "Límite Descuento"
        Me.lbLimiteDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbLimiteDescuento.Visible = False
        '
        'sbClienteDomicilio
        '
        Me.sbClienteDomicilio.LargeChange = 1
        Me.sbClienteDomicilio.Location = New System.Drawing.Point(716, 0)
        Me.sbClienteDomicilio.Maximum = 0
        Me.sbClienteDomicilio.Name = "sbClienteDomicilio"
        Me.sbClienteDomicilio.Size = New System.Drawing.Size(25, 585)
        Me.sbClienteDomicilio.TabIndex = 0
        '
        'gbClienteDomicilio
        '
        Me.gbClienteDomicilio.BackColor = System.Drawing.Color.Transparent
        Me.gbClienteDomicilio.Controls.Add(Me.ebCoordenadaY)
        Me.gbClienteDomicilio.Controls.Add(Me.ebCoordenadaX)
        Me.gbClienteDomicilio.Controls.Add(Me.lbCoordenadaY)
        Me.gbClienteDomicilio.Controls.Add(Me.lbCoordenadaX)
        Me.gbClienteDomicilio.Controls.Add(Me.ebReferencia)
        Me.gbClienteDomicilio.Controls.Add(Me.lbReferencia)
        Me.gbClienteDomicilio.Controls.Add(Me.lbFrecuencia)
        Me.gbClienteDomicilio.Controls.Add(Me.lbLineaFrecuencia)
        Me.gbClienteDomicilio.Controls.Add(Me.ebClienteDomicilioId)
        Me.gbClienteDomicilio.Controls.Add(Me.ebCodigoPostal)
        Me.gbClienteDomicilio.Controls.Add(Me.ebNumero)
        Me.gbClienteDomicilio.Controls.Add(Me.cbCopiar)
        Me.gbClienteDomicilio.Controls.Add(Me.btCopiar)
        Me.gbClienteDomicilio.Controls.Add(Me.cbTipo)
        Me.gbClienteDomicilio.Controls.Add(Me.lbCodigoPostal)
        Me.gbClienteDomicilio.Controls.Add(Me.ebPoblacion)
        Me.gbClienteDomicilio.Controls.Add(Me.lbPoblacion)
        Me.gbClienteDomicilio.Controls.Add(Me.lbPais)
        Me.gbClienteDomicilio.Controls.Add(Me.ebCalle)
        Me.gbClienteDomicilio.Controls.Add(Me.lbNumero)
        Me.gbClienteDomicilio.Controls.Add(Me.lbColonia)
        Me.gbClienteDomicilio.Controls.Add(Me.ebColonia)
        Me.gbClienteDomicilio.Controls.Add(Me.ebPais)
        Me.gbClienteDomicilio.Controls.Add(Me.lbEntidad)
        Me.gbClienteDomicilio.Controls.Add(Me.ebEntidad)
        Me.gbClienteDomicilio.Controls.Add(Me.lbCalle)
        Me.gbClienteDomicilio.Controls.Add(Me.lbTipo)
        Me.gbClienteDomicilio.Controls.Add(Me.grFrecuencia)
        Me.gbClienteDomicilio.Controls.Add(Me.lbNumInt)
        Me.gbClienteDomicilio.Controls.Add(Me.ebNumInt)
        Me.gbClienteDomicilio.Controls.Add(Me.ebLocalidad)
        Me.gbClienteDomicilio.Controls.Add(Me.lbLocalidad)
        Me.gbClienteDomicilio.Location = New System.Drawing.Point(4, 2)
        Me.gbClienteDomicilio.Name = "gbClienteDomicilio"
        Me.gbClienteDomicilio.Size = New System.Drawing.Size(709, 581)
        Me.gbClienteDomicilio.TabIndex = 0
        Me.gbClienteDomicilio.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'ebCoordenadaY
        '
        Me.ebCoordenadaY.Location = New System.Drawing.Point(496, 208)
        Me.ebCoordenadaY.MaxLength = 32
        Me.ebCoordenadaY.Name = "ebCoordenadaY"
        Me.ebCoordenadaY.Size = New System.Drawing.Size(196, 20)
        Me.ebCoordenadaY.TabIndex = 17
        Me.ebCoordenadaY.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCoordenadaY.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebCoordenadaX
        '
        Me.ebCoordenadaX.Location = New System.Drawing.Point(152, 208)
        Me.ebCoordenadaX.MaxLength = 32
        Me.ebCoordenadaX.Name = "ebCoordenadaX"
        Me.ebCoordenadaX.Size = New System.Drawing.Size(196, 20)
        Me.ebCoordenadaX.TabIndex = 16
        Me.ebCoordenadaX.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCoordenadaX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbCoordenadaY
        '
        Me.lbCoordenadaY.BackColor = System.Drawing.Color.Transparent
        Me.lbCoordenadaY.Location = New System.Drawing.Point(360, 208)
        Me.lbCoordenadaY.Name = "lbCoordenadaY"
        Me.lbCoordenadaY.Size = New System.Drawing.Size(132, 20)
        Me.lbCoordenadaY.TabIndex = 304
        Me.lbCoordenadaY.Text = "Coordenada Y"
        Me.lbCoordenadaY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbCoordenadaX
        '
        Me.lbCoordenadaX.BackColor = System.Drawing.Color.Transparent
        Me.lbCoordenadaX.Location = New System.Drawing.Point(16, 208)
        Me.lbCoordenadaX.Name = "lbCoordenadaX"
        Me.lbCoordenadaX.Size = New System.Drawing.Size(132, 20)
        Me.lbCoordenadaX.TabIndex = 302
        Me.lbCoordenadaX.Text = "Coordenada X"
        Me.lbCoordenadaX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebReferencia
        '
        Me.ebReferencia.Location = New System.Drawing.Point(152, 124)
        Me.ebReferencia.MaxLength = 100
        Me.ebReferencia.Name = "ebReferencia"
        Me.ebReferencia.Size = New System.Drawing.Size(540, 20)
        Me.ebReferencia.TabIndex = 9
        Me.ebReferencia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebReferencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbReferencia
        '
        Me.lbReferencia.BackColor = System.Drawing.Color.Transparent
        Me.lbReferencia.Location = New System.Drawing.Point(16, 124)
        Me.lbReferencia.Name = "lbReferencia"
        Me.lbReferencia.Size = New System.Drawing.Size(132, 20)
        Me.lbReferencia.TabIndex = 15
        Me.lbReferencia.Text = "Referencia"
        Me.lbReferencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbFrecuencia
        '
        Me.lbFrecuencia.BackColor = System.Drawing.Color.Transparent
        Me.lbFrecuencia.Location = New System.Drawing.Point(16, 241)
        Me.lbFrecuencia.Name = "lbFrecuencia"
        Me.lbFrecuencia.Size = New System.Drawing.Size(132, 20)
        Me.lbFrecuencia.TabIndex = 25
        Me.lbFrecuencia.Text = "Frecuencias"
        Me.lbFrecuencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLineaFrecuencia
        '
        Me.lbLineaFrecuencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbLineaFrecuencia.Location = New System.Drawing.Point(16, 257)
        Me.lbLineaFrecuencia.Name = "lbLineaFrecuencia"
        Me.lbLineaFrecuencia.Size = New System.Drawing.Size(676, 2)
        Me.lbLineaFrecuencia.TabIndex = 301
        '
        'ebClienteDomicilioId
        '
        Me.ebClienteDomicilioId.Location = New System.Drawing.Point(664, 44)
        Me.ebClienteDomicilioId.Name = "ebClienteDomicilioId"
        Me.ebClienteDomicilioId.Size = New System.Drawing.Size(4, 20)
        Me.ebClienteDomicilioId.TabIndex = 6
        Me.ebClienteDomicilioId.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteDomicilioId.Visible = False
        Me.ebClienteDomicilioId.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebCodigoPostal
        '
        Me.ebCodigoPostal.Location = New System.Drawing.Point(496, 96)
        Me.ebCodigoPostal.MaxLength = 16
        Me.ebCodigoPostal.Name = "ebCodigoPostal"
        Me.ebCodigoPostal.Size = New System.Drawing.Size(196, 20)
        Me.ebCodigoPostal.TabIndex = 8
        Me.ebCodigoPostal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigoPostal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebNumero
        '
        Me.ebNumero.Location = New System.Drawing.Point(152, 68)
        Me.ebNumero.MaxLength = 16
        Me.ebNumero.Name = "ebNumero"
        Me.ebNumero.Size = New System.Drawing.Size(196, 20)
        Me.ebNumero.TabIndex = 5
        Me.ebNumero.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumero.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbCopiar
        '
        Me.cbCopiar.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbCopiar.Location = New System.Drawing.Point(496, 16)
        Me.cbCopiar.Name = "cbCopiar"
        Me.cbCopiar.Size = New System.Drawing.Size(196, 20)
        Me.cbCopiar.TabIndex = 3
        Me.cbCopiar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btCopiar
        '
        Me.btCopiar.Location = New System.Drawing.Point(424, 16)
        Me.btCopiar.Name = "btCopiar"
        Me.btCopiar.Size = New System.Drawing.Size(68, 20)
        Me.btCopiar.TabIndex = 2
        Me.btCopiar.Text = "Copiar"
        Me.btCopiar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'cbTipo
        '
        Me.cbTipo.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipo.Location = New System.Drawing.Point(152, 16)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(196, 20)
        Me.cbTipo.TabIndex = 1
        Me.cbTipo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbCodigoPostal
        '
        Me.lbCodigoPostal.BackColor = System.Drawing.Color.Transparent
        Me.lbCodigoPostal.Location = New System.Drawing.Point(360, 96)
        Me.lbCodigoPostal.Name = "lbCodigoPostal"
        Me.lbCodigoPostal.Size = New System.Drawing.Size(132, 20)
        Me.lbCodigoPostal.TabIndex = 13
        Me.lbCodigoPostal.Text = "Código Postal"
        Me.lbCodigoPostal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebPoblacion
        '
        Me.ebPoblacion.Location = New System.Drawing.Point(496, 152)
        Me.ebPoblacion.MaxLength = 64
        Me.ebPoblacion.Name = "ebPoblacion"
        Me.ebPoblacion.Size = New System.Drawing.Size(196, 20)
        Me.ebPoblacion.TabIndex = 13
        Me.ebPoblacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPoblacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbPoblacion
        '
        Me.lbPoblacion.BackColor = System.Drawing.Color.Transparent
        Me.lbPoblacion.Location = New System.Drawing.Point(360, 152)
        Me.lbPoblacion.Name = "lbPoblacion"
        Me.lbPoblacion.Size = New System.Drawing.Size(132, 20)
        Me.lbPoblacion.TabIndex = 19
        Me.lbPoblacion.Text = "Municipio"
        Me.lbPoblacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbPais
        '
        Me.lbPais.BackColor = System.Drawing.Color.Transparent
        Me.lbPais.Location = New System.Drawing.Point(360, 180)
        Me.lbPais.Name = "lbPais"
        Me.lbPais.Size = New System.Drawing.Size(132, 20)
        Me.lbPais.TabIndex = 23
        Me.lbPais.Text = "País"
        Me.lbPais.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebCalle
        '
        Me.ebCalle.Location = New System.Drawing.Point(152, 42)
        Me.ebCalle.MaxLength = 64
        Me.ebCalle.Name = "ebCalle"
        Me.ebCalle.Size = New System.Drawing.Size(472, 20)
        Me.ebCalle.TabIndex = 4
        Me.ebCalle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbNumero
        '
        Me.lbNumero.BackColor = System.Drawing.Color.Transparent
        Me.lbNumero.Location = New System.Drawing.Point(16, 68)
        Me.lbNumero.Name = "lbNumero"
        Me.lbNumero.Size = New System.Drawing.Size(132, 20)
        Me.lbNumero.TabIndex = 7
        Me.lbNumero.Text = "Número"
        Me.lbNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbColonia
        '
        Me.lbColonia.BackColor = System.Drawing.Color.Transparent
        Me.lbColonia.Location = New System.Drawing.Point(16, 96)
        Me.lbColonia.Name = "lbColonia"
        Me.lbColonia.Size = New System.Drawing.Size(132, 20)
        Me.lbColonia.TabIndex = 11
        Me.lbColonia.Text = "Colonia"
        Me.lbColonia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebColonia
        '
        Me.ebColonia.Location = New System.Drawing.Point(152, 96)
        Me.ebColonia.MaxLength = 64
        Me.ebColonia.Name = "ebColonia"
        Me.ebColonia.Size = New System.Drawing.Size(196, 20)
        Me.ebColonia.TabIndex = 7
        Me.ebColonia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebColonia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebPais
        '
        Me.ebPais.Location = New System.Drawing.Point(496, 180)
        Me.ebPais.MaxLength = 32
        Me.ebPais.Name = "ebPais"
        Me.ebPais.Size = New System.Drawing.Size(196, 20)
        Me.ebPais.TabIndex = 15
        Me.ebPais.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPais.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbEntidad
        '
        Me.lbEntidad.BackColor = System.Drawing.Color.Transparent
        Me.lbEntidad.Location = New System.Drawing.Point(16, 180)
        Me.lbEntidad.Name = "lbEntidad"
        Me.lbEntidad.Size = New System.Drawing.Size(132, 20)
        Me.lbEntidad.TabIndex = 21
        Me.lbEntidad.Text = "Entidad"
        Me.lbEntidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebEntidad
        '
        Me.ebEntidad.Location = New System.Drawing.Point(152, 180)
        Me.ebEntidad.MaxLength = 32
        Me.ebEntidad.Name = "ebEntidad"
        Me.ebEntidad.Size = New System.Drawing.Size(196, 20)
        Me.ebEntidad.TabIndex = 14
        Me.ebEntidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEntidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbCalle
        '
        Me.lbCalle.BackColor = System.Drawing.Color.Transparent
        Me.lbCalle.Location = New System.Drawing.Point(16, 42)
        Me.lbCalle.Name = "lbCalle"
        Me.lbCalle.Size = New System.Drawing.Size(132, 20)
        Me.lbCalle.TabIndex = 4
        Me.lbCalle.Text = "Calle"
        Me.lbCalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbTipo
        '
        Me.lbTipo.BackColor = System.Drawing.Color.Transparent
        Me.lbTipo.Location = New System.Drawing.Point(16, 16)
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(132, 20)
        Me.lbTipo.TabIndex = 0
        Me.lbTipo.Text = "Tipo"
        Me.lbTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grFrecuencia
        '
        grFrecuencia_DesignTimeLayout.LayoutString = resources.GetString("grFrecuencia_DesignTimeLayout.LayoutString")
        Me.grFrecuencia.DesignTimeLayout = grFrecuencia_DesignTimeLayout
        Me.grFrecuencia.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grFrecuencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grFrecuencia.GroupByBoxVisible = False
        Me.grFrecuencia.Location = New System.Drawing.Point(12, 271)
        Me.grFrecuencia.Name = "grFrecuencia"
        Me.grFrecuencia.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grFrecuencia.Size = New System.Drawing.Size(680, 292)
        Me.grFrecuencia.TabIndex = 26
        Me.grFrecuencia.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        Me.grFrecuencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbNumInt
        '
        Me.lbNumInt.BackColor = System.Drawing.Color.Transparent
        Me.lbNumInt.Location = New System.Drawing.Point(360, 68)
        Me.lbNumInt.Name = "lbNumInt"
        Me.lbNumInt.Size = New System.Drawing.Size(132, 20)
        Me.lbNumInt.TabIndex = 9
        Me.lbNumInt.Text = "Número Interior"
        Me.lbNumInt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebNumInt
        '
        Me.ebNumInt.Location = New System.Drawing.Point(496, 68)
        Me.ebNumInt.MaxLength = 16
        Me.ebNumInt.Name = "ebNumInt"
        Me.ebNumInt.Size = New System.Drawing.Size(196, 20)
        Me.ebNumInt.TabIndex = 6
        Me.ebNumInt.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNumInt.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebLocalidad
        '
        Me.ebLocalidad.Location = New System.Drawing.Point(152, 152)
        Me.ebLocalidad.MaxLength = 32
        Me.ebLocalidad.Name = "ebLocalidad"
        Me.ebLocalidad.Size = New System.Drawing.Size(196, 20)
        Me.ebLocalidad.TabIndex = 12
        Me.ebLocalidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebLocalidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbLocalidad
        '
        Me.lbLocalidad.BackColor = System.Drawing.Color.Transparent
        Me.lbLocalidad.Location = New System.Drawing.Point(16, 152)
        Me.lbLocalidad.Name = "lbLocalidad"
        Me.lbLocalidad.Size = New System.Drawing.Size(132, 20)
        Me.lbLocalidad.TabIndex = 17
        Me.lbLocalidad.Text = "Localidad"
        Me.lbLocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btCLDCrear
        '
        Me.btCLDCrear.Icon = CType(resources.GetObject("btCLDCrear.Icon"), System.Drawing.Icon)
        Me.btCLDCrear.Location = New System.Drawing.Point(744, 8)
        Me.btCLDCrear.Name = "btCLDCrear"
        Me.btCLDCrear.Size = New System.Drawing.Size(80, 24)
        Me.btCLDCrear.TabIndex = 1
        Me.btCLDCrear.Text = "Crear"
        Me.btCLDCrear.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCLDEliminar
        '
        Me.btCLDEliminar.CausesValidation = False
        Me.btCLDEliminar.Icon = CType(resources.GetObject("btCLDEliminar.Icon"), System.Drawing.Icon)
        Me.btCLDEliminar.Location = New System.Drawing.Point(744, 40)
        Me.btCLDEliminar.Name = "btCLDEliminar"
        Me.btCLDEliminar.Size = New System.Drawing.Size(80, 24)
        Me.btCLDEliminar.TabIndex = 2
        Me.btCLDEliminar.Text = "Eliminar"
        Me.btCLDEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btMMEBuscar
        '
        Me.btMMEBuscar.CausesValidation = False
        Me.btMMEBuscar.Icon = CType(resources.GetObject("btMMEBuscar.Icon"), System.Drawing.Icon)
        Me.btMMEBuscar.Location = New System.Drawing.Point(744, 8)
        Me.btMMEBuscar.Name = "btMMEBuscar"
        Me.btMMEBuscar.Size = New System.Drawing.Size(80, 24)
        Me.btMMEBuscar.TabIndex = 1
        Me.btMMEBuscar.Text = "Buscar"
        Me.btMMEBuscar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btMMENuevo
        '
        Me.btMMENuevo.Icon = CType(resources.GetObject("btMMENuevo.Icon"), System.Drawing.Icon)
        Me.btMMENuevo.Location = New System.Drawing.Point(744, 72)
        Me.btMMENuevo.Name = "btMMENuevo"
        Me.btMMENuevo.Size = New System.Drawing.Size(80, 24)
        Me.btMMENuevo.TabIndex = 3
        Me.btMMENuevo.Text = "Nuevo"
        Me.btMMENuevo.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCLMEliminar
        '
        Me.btCLMEliminar.CausesValidation = False
        Me.btCLMEliminar.Icon = CType(resources.GetObject("btCLMEliminar.Icon"), System.Drawing.Icon)
        Me.btCLMEliminar.Location = New System.Drawing.Point(744, 40)
        Me.btCLMEliminar.Name = "btCLMEliminar"
        Me.btCLMEliminar.Size = New System.Drawing.Size(80, 24)
        Me.btCLMEliminar.TabIndex = 2
        Me.btCLMEliminar.Text = "Eliminar"
        Me.btCLMEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCLPCrear
        '
        Me.btCLPCrear.Icon = CType(resources.GetObject("btCLPCrear.Icon"), System.Drawing.Icon)
        Me.btCLPCrear.Location = New System.Drawing.Point(732, 20)
        Me.btCLPCrear.Name = "btCLPCrear"
        Me.btCLPCrear.Size = New System.Drawing.Size(80, 24)
        Me.btCLPCrear.TabIndex = 1
        Me.btCLPCrear.Text = "Crear"
        Me.btCLPCrear.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCLPEliminar
        '
        Me.btCLPEliminar.CausesValidation = False
        Me.btCLPEliminar.Icon = CType(resources.GetObject("btCLPEliminar.Icon"), System.Drawing.Icon)
        Me.btCLPEliminar.Location = New System.Drawing.Point(732, 52)
        Me.btCLPEliminar.Name = "btCLPEliminar"
        Me.btCLPEliminar.Size = New System.Drawing.Size(80, 24)
        Me.btCLPEliminar.TabIndex = 2
        Me.btCLPEliminar.Text = "Eliminar"
        Me.btCLPEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'grClientePago
        '
        grClientePago_DesignTimeLayout.LayoutString = resources.GetString("grClientePago_DesignTimeLayout.LayoutString")
        Me.grClientePago.DesignTimeLayout = grClientePago_DesignTimeLayout
        Me.grClientePago.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grClientePago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grClientePago.GroupByBoxVisible = False
        Me.grClientePago.Location = New System.Drawing.Point(8, 20)
        Me.grClientePago.Name = "grClientePago"
        Me.grClientePago.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grClientePago.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grClientePago.Size = New System.Drawing.Size(712, 192)
        Me.grClientePago.TabIndex = 0
        Me.grClientePago.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        Me.grClientePago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbSaldoEfectivo
        '
        Me.lbSaldoEfectivo.BackColor = System.Drawing.Color.Transparent
        Me.lbSaldoEfectivo.Location = New System.Drawing.Point(16, 11)
        Me.lbSaldoEfectivo.Name = "lbSaldoEfectivo"
        Me.lbSaldoEfectivo.Size = New System.Drawing.Size(90, 20)
        Me.lbSaldoEfectivo.TabIndex = 0
        Me.lbSaldoEfectivo.Text = "Saldo Efectivo"
        Me.lbSaldoEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grClienteProducto
        '
        Me.grClienteProducto.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        grClienteProducto_DesignTimeLayout.LayoutString = resources.GetString("grClienteProducto_DesignTimeLayout.LayoutString")
        Me.grClienteProducto.DesignTimeLayout = grClienteProducto_DesignTimeLayout
        Me.grClienteProducto.GroupByBoxVisible = False
        Me.grClienteProducto.Location = New System.Drawing.Point(12, 47)
        Me.grClienteProducto.Name = "grClienteProducto"
        Me.grClienteProducto.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grClienteProducto.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grClienteProducto.Size = New System.Drawing.Size(824, 376)
        Me.grClienteProducto.TabIndex = 5
        Me.grClienteProducto.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        Me.grClienteProducto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbParametros
        '
        Me.gbParametros.BackColor = System.Drawing.Color.Transparent
        Me.gbParametros.Controls.Add(Me.cbTipoFiscal)
        Me.gbParametros.Controls.Add(Me.chbCapturaDatosFacturacion)
        Me.gbParametros.Controls.Add(Me.chbImprimirPagare)
        Me.gbParametros.Controls.Add(Me.chbCriterioCredito)
        Me.gbParametros.Controls.Add(Me.chbExigirOrden)
        Me.gbParametros.Controls.Add(Me.ebDiasVencimiento)
        Me.gbParametros.Controls.Add(Me.lbDiasVencimiento)
        Me.gbParametros.Controls.Add(Me.chbVencimientoVenta)
        Me.gbParametros.Controls.Add(Me.lbTipoFiscal)
        Me.gbParametros.Controls.Add(Me.cbTipoImpuesto)
        Me.gbParametros.Controls.Add(Me.chbActualizaSaldoCheque)
        Me.gbParametros.Controls.Add(Me.ebVigExclusividad)
        Me.gbParametros.Controls.Add(Me.lbLimiteCreditoDinero)
        Me.gbParametros.Controls.Add(Me.lbVigExclusividad)
        Me.gbParametros.Controls.Add(Me.chbExclusividad)
        Me.gbParametros.Controls.Add(Me.chbPrestamo)
        Me.gbParametros.Controls.Add(Me.ebLimiteCreditoDinero)
        Me.gbParametros.Controls.Add(Me.lbTipoImpuesto)
        Me.gbParametros.Location = New System.Drawing.Point(5, 238)
        Me.gbParametros.Name = "gbParametros"
        Me.gbParametros.Size = New System.Drawing.Size(832, 124)
        Me.gbParametros.TabIndex = 17
        Me.gbParametros.Text = "Parametros"
        Me.gbParametros.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'chbImprimirPagare
        '
        Me.chbImprimirPagare.BackColor = System.Drawing.Color.Transparent
        Me.chbImprimirPagare.Location = New System.Drawing.Point(484, 94)
        Me.chbImprimirPagare.Name = "chbImprimirPagare"
        Me.chbImprimirPagare.Size = New System.Drawing.Size(136, 20)
        Me.chbImprimirPagare.TabIndex = 23
        Me.chbImprimirPagare.Text = "chbImprimirPagare"
        Me.chbImprimirPagare.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chbCriterioCredito
        '
        Me.chbCriterioCredito.BackColor = System.Drawing.Color.Transparent
        Me.chbCriterioCredito.Location = New System.Drawing.Point(310, 94)
        Me.chbCriterioCredito.Name = "chbCriterioCredito"
        Me.chbCriterioCredito.Size = New System.Drawing.Size(176, 20)
        Me.chbCriterioCredito.TabIndex = 22
        Me.chbCriterioCredito.Text = "chbCriterioCredito"
        Me.chbCriterioCredito.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chbExigirOrden
        '
        Me.chbExigirOrden.BackColor = System.Drawing.Color.Transparent
        Me.chbExigirOrden.Location = New System.Drawing.Point(7, 94)
        Me.chbExigirOrden.Name = "chbExigirOrden"
        Me.chbExigirOrden.Size = New System.Drawing.Size(176, 20)
        Me.chbExigirOrden.TabIndex = 21
        Me.chbExigirOrden.Text = "Exigir Orden Compra"
        Me.chbExigirOrden.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ebDiasVencimiento
        '
        Me.ebDiasVencimiento.DecimalDigits = 0
        Me.ebDiasVencimiento.EditMode = Janus.Windows.GridEX.NumericEditMode.Value
        Me.ebDiasVencimiento.FormatString = "##,###,##0"
        Me.ebDiasVencimiento.Location = New System.Drawing.Point(640, 68)
        Me.ebDiasVencimiento.MaxLength = 11
        Me.ebDiasVencimiento.Name = "ebDiasVencimiento"
        Me.ebDiasVencimiento.Size = New System.Drawing.Size(176, 20)
        Me.ebDiasVencimiento.TabIndex = 20
        Me.ebDiasVencimiento.Text = "0"
        Me.ebDiasVencimiento.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebDiasVencimiento.Value = CType(0, Short)
        Me.ebDiasVencimiento.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int16
        Me.ebDiasVencimiento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbDiasVencimiento
        '
        Me.lbDiasVencimiento.BackColor = System.Drawing.Color.Transparent
        Me.lbDiasVencimiento.Location = New System.Drawing.Point(484, 68)
        Me.lbDiasVencimiento.Name = "lbDiasVencimiento"
        Me.lbDiasVencimiento.Size = New System.Drawing.Size(149, 20)
        Me.lbDiasVencimiento.TabIndex = 12
        Me.lbDiasVencimiento.Text = "Días Vencimiento"
        Me.lbDiasVencimiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chbVencimientoVenta
        '
        Me.chbVencimientoVenta.BackColor = System.Drawing.Color.Transparent
        Me.chbVencimientoVenta.Location = New System.Drawing.Point(310, 68)
        Me.chbVencimientoVenta.Name = "chbVencimientoVenta"
        Me.chbVencimientoVenta.Size = New System.Drawing.Size(132, 20)
        Me.chbVencimientoVenta.TabIndex = 19
        Me.chbVencimientoVenta.Text = "Vencimiento Venta"
        Me.chbVencimientoVenta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chbActualizaSaldoCheque
        '
        Me.chbActualizaSaldoCheque.BackColor = System.Drawing.Color.Transparent
        Me.chbActualizaSaldoCheque.Location = New System.Drawing.Point(8, 68)
        Me.chbActualizaSaldoCheque.Name = "chbActualizaSaldoCheque"
        Me.chbActualizaSaldoCheque.Size = New System.Drawing.Size(132, 20)
        Me.chbActualizaSaldoCheque.TabIndex = 18
        Me.chbActualizaSaldoCheque.Text = "Actualiza Cheque"
        Me.chbActualizaSaldoCheque.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ebVigExclusividad
        '
        '
        '
        '
        Me.ebVigExclusividad.DropDownCalendar.FirstMonth = New Date(2007, 1, 1, 0, 0, 0, 0)
        Me.ebVigExclusividad.DropDownCalendar.Name = ""
        Me.ebVigExclusividad.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.ebVigExclusividad.Location = New System.Drawing.Point(640, 42)
        Me.ebVigExclusividad.Name = "ebVigExclusividad"
        Me.ebVigExclusividad.Size = New System.Drawing.Size(176, 20)
        Me.ebVigExclusividad.TabIndex = 17
        Me.ebVigExclusividad.Value = New Date(2007, 10, 12, 0, 0, 0, 0)
        Me.ebVigExclusividad.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'lbVigExclusividad
        '
        Me.lbVigExclusividad.BackColor = System.Drawing.Color.Transparent
        Me.lbVigExclusividad.Location = New System.Drawing.Point(484, 42)
        Me.lbVigExclusividad.Name = "lbVigExclusividad"
        Me.lbVigExclusividad.Size = New System.Drawing.Size(149, 20)
        Me.lbVigExclusividad.TabIndex = 8
        Me.lbVigExclusividad.Text = "Vigencia Exclusividad"
        Me.lbVigExclusividad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chbExclusividad
        '
        Me.chbExclusividad.BackColor = System.Drawing.Color.Transparent
        Me.chbExclusividad.Location = New System.Drawing.Point(310, 42)
        Me.chbExclusividad.Name = "chbExclusividad"
        Me.chbExclusividad.Size = New System.Drawing.Size(132, 20)
        Me.chbExclusividad.TabIndex = 16
        Me.chbExclusividad.Text = "Exclusividad"
        Me.chbExclusividad.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chbPrestamo
        '
        Me.chbPrestamo.BackColor = System.Drawing.Color.Transparent
        Me.chbPrestamo.Location = New System.Drawing.Point(8, 42)
        Me.chbPrestamo.Name = "chbPrestamo"
        Me.chbPrestamo.Size = New System.Drawing.Size(132, 20)
        Me.chbPrestamo.TabIndex = 15
        Me.chbPrestamo.Text = "Prestamo"
        Me.chbPrestamo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbClientePago
        '
        Me.gbClientePago.BackColor = System.Drawing.Color.Transparent
        Me.gbClientePago.Controls.Add(Me.btCLPCrear)
        Me.gbClientePago.Controls.Add(Me.btCLPEliminar)
        Me.gbClientePago.Controls.Add(Me.grClientePago)
        Me.gbClientePago.Location = New System.Drawing.Point(4, 4)
        Me.gbClientePago.Name = "gbClientePago"
        Me.gbClientePago.Size = New System.Drawing.Size(824, 220)
        Me.gbClientePago.TabIndex = 0
        Me.gbClientePago.Text = "Formas de Pago"
        Me.gbClientePago.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'gbCLIFormaVenta
        '
        Me.gbCLIFormaVenta.BackColor = System.Drawing.Color.Transparent
        Me.gbCLIFormaVenta.Controls.Add(Me.btCFVHistorico)
        Me.gbCLIFormaVenta.Controls.Add(Me.btCFVCrear)
        Me.gbCLIFormaVenta.Controls.Add(Me.btCFVEliminar)
        Me.gbCLIFormaVenta.Controls.Add(Me.grCLIFormaVenta)
        Me.gbCLIFormaVenta.Location = New System.Drawing.Point(4, 232)
        Me.gbCLIFormaVenta.Name = "gbCLIFormaVenta"
        Me.gbCLIFormaVenta.Size = New System.Drawing.Size(824, 216)
        Me.gbCLIFormaVenta.TabIndex = 1
        Me.gbCLIFormaVenta.Text = "Formas de Venta"
        Me.gbCLIFormaVenta.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'btCFVHistorico
        '
        Me.btCFVHistorico.CausesValidation = False
        Me.btCFVHistorico.Icon = CType(resources.GetObject("btCFVHistorico.Icon"), System.Drawing.Icon)
        Me.btCFVHistorico.Location = New System.Drawing.Point(732, 84)
        Me.btCFVHistorico.Name = "btCFVHistorico"
        Me.btCFVHistorico.Size = New System.Drawing.Size(80, 24)
        Me.btCFVHistorico.TabIndex = 3
        Me.btCFVHistorico.Text = "Histórico"
        Me.btCFVHistorico.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCFVCrear
        '
        Me.btCFVCrear.Icon = CType(resources.GetObject("btCFVCrear.Icon"), System.Drawing.Icon)
        Me.btCFVCrear.Location = New System.Drawing.Point(732, 20)
        Me.btCFVCrear.Name = "btCFVCrear"
        Me.btCFVCrear.Size = New System.Drawing.Size(80, 24)
        Me.btCFVCrear.TabIndex = 1
        Me.btCFVCrear.Text = "Crear"
        Me.btCFVCrear.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCFVEliminar
        '
        Me.btCFVEliminar.CausesValidation = False
        Me.btCFVEliminar.Icon = CType(resources.GetObject("btCFVEliminar.Icon"), System.Drawing.Icon)
        Me.btCFVEliminar.Location = New System.Drawing.Point(732, 52)
        Me.btCFVEliminar.Name = "btCFVEliminar"
        Me.btCFVEliminar.Size = New System.Drawing.Size(80, 24)
        Me.btCFVEliminar.TabIndex = 2
        Me.btCFVEliminar.Text = "Eliminar"
        Me.btCFVEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'grCLIFormaVenta
        '
        grCLIFormaVenta_DesignTimeLayout.LayoutString = resources.GetString("grCLIFormaVenta_DesignTimeLayout.LayoutString")
        Me.grCLIFormaVenta.DesignTimeLayout = grCLIFormaVenta_DesignTimeLayout
        Me.grCLIFormaVenta.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grCLIFormaVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grCLIFormaVenta.GroupByBoxVisible = False
        Me.grCLIFormaVenta.Location = New System.Drawing.Point(8, 20)
        Me.grCLIFormaVenta.Name = "grCLIFormaVenta"
        Me.grCLIFormaVenta.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grCLIFormaVenta.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grCLIFormaVenta.Size = New System.Drawing.Size(712, 188)
        Me.grCLIFormaVenta.TabIndex = 0
        Me.grCLIFormaVenta.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        Me.grCLIFormaVenta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbFechaFactura
        '
        Me.lbFechaFactura.BackColor = System.Drawing.Color.Transparent
        Me.lbFechaFactura.Location = New System.Drawing.Point(269, 11)
        Me.lbFechaFactura.Name = "lbFechaFactura"
        Me.lbFechaFactura.Size = New System.Drawing.Size(93, 20)
        Me.lbFechaFactura.TabIndex = 2
        Me.lbFechaFactura.Text = "Fecha Factura"
        Me.lbFechaFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebFechaFactura
        '
        '
        '
        '
        Me.ebFechaFactura.DropDownCalendar.FirstMonth = New Date(2007, 1, 1, 0, 0, 0, 0)
        Me.ebFechaFactura.DropDownCalendar.Name = ""
        Me.ebFechaFactura.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.ebFechaFactura.Location = New System.Drawing.Point(368, 11)
        Me.ebFechaFactura.Name = "ebFechaFactura"
        Me.ebFechaFactura.Size = New System.Drawing.Size(128, 20)
        Me.ebFechaFactura.TabIndex = 3
        Me.ebFechaFactura.Value = New Date(2007, 10, 12, 0, 0, 0, 0)
        Me.ebFechaFactura.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'ebSaldoEfectivo
        '
        Me.ebSaldoEfectivo.DecimalDigits = 2
        Me.ebSaldoEfectivo.Enabled = False
        Me.ebSaldoEfectivo.Location = New System.Drawing.Point(113, 11)
        Me.ebSaldoEfectivo.Name = "ebSaldoEfectivo"
        Me.ebSaldoEfectivo.Size = New System.Drawing.Size(128, 20)
        Me.ebSaldoEfectivo.TabIndex = 1
        Me.ebSaldoEfectivo.Text = "0.00"
        Me.ebSaldoEfectivo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSaldoEfectivo.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ebSaldoEfectivo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebSaldoPrestamo
        '
        Me.ebSaldoPrestamo.DecimalDigits = 2
        Me.ebSaldoPrestamo.Enabled = False
        Me.ebSaldoPrestamo.Location = New System.Drawing.Point(444, 431)
        Me.ebSaldoPrestamo.Name = "ebSaldoPrestamo"
        Me.ebSaldoPrestamo.Size = New System.Drawing.Size(128, 20)
        Me.ebSaldoPrestamo.TabIndex = 7
        Me.ebSaldoPrestamo.Text = "0.00"
        Me.ebSaldoPrestamo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSaldoPrestamo.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ebSaldoPrestamo.Visible = False
        Me.ebSaldoPrestamo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbSaldoPrestamo
        '
        Me.lbSaldoPrestamo.BackColor = System.Drawing.Color.Transparent
        Me.lbSaldoPrestamo.Location = New System.Drawing.Point(308, 431)
        Me.lbSaldoPrestamo.Name = "lbSaldoPrestamo"
        Me.lbSaldoPrestamo.Size = New System.Drawing.Size(132, 20)
        Me.lbSaldoPrestamo.TabIndex = 6
        Me.lbSaldoPrestamo.Text = "Saldo Prestamo"
        Me.lbSaldoPrestamo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbSaldoPrestamo.Visible = False
        '
        'btCPRHistorico
        '
        Me.btCPRHistorico.CausesValidation = False
        Me.btCPRHistorico.Icon = CType(resources.GetObject("btCPRHistorico.Icon"), System.Drawing.Icon)
        Me.btCPRHistorico.Location = New System.Drawing.Point(752, 11)
        Me.btCPRHistorico.Name = "btCPRHistorico"
        Me.btCPRHistorico.Size = New System.Drawing.Size(80, 24)
        Me.btCPRHistorico.TabIndex = 4
        Me.btCPRHistorico.Text = "Histórico"
        Me.btCPRHistorico.Visible = False
        Me.btCPRHistorico.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'TabControl1
        '
        Me.TabControl1.CanReorderTabs = False
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Controls.Add(Me.TabControlPanel6)
        Me.TabControl1.Controls.Add(Me.TabControlPanel3)
        Me.TabControl1.Controls.Add(Me.TabControlPanel4)
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Controls.Add(Me.TabControlPanel5)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(11, 10)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(844, 624)
        Me.TabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005Document
        Me.TabControl1.TabIndex = 15
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.tabGenerales)
        Me.TabControl1.Tabs.Add(Me.tabDomicilio)
        Me.TabControl1.Tabs.Add(Me.tabMensajes)
        Me.TabControl1.Tabs.Add(Me.tabConVenta)
        Me.TabControl1.Tabs.Add(Me.tabSaldos)
        Me.TabControl1.Tabs.Add(Me.tabDesglosaImpuesto)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel6
        '
        Me.TabControlPanel6.Controls.Add(Me.gbConfNumCta)
        Me.TabControlPanel6.Controls.Add(Me.gbExcepcionDesglose)
        Me.TabControlPanel6.Controls.Add(Me.chbDesgloseImpuesto)
        Me.TabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel6.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel6.Name = "TabControlPanel6"
        Me.TabControlPanel6.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel6.Size = New System.Drawing.Size(844, 598)
        Me.TabControlPanel6.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel6.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel6.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel6.Style.GradientAngle = 90
        Me.TabControlPanel6.TabIndex = 6
        Me.TabControlPanel6.TabItem = Me.tabDesglosaImpuesto
        '
        'gbConfNumCta
        '
        Me.gbConfNumCta.BackColor = System.Drawing.Color.Transparent
        Me.gbConfNumCta.Controls.Add(Me.grCLIConfNumCta)
        Me.gbConfNumCta.Location = New System.Drawing.Point(523, 41)
        Me.gbConfNumCta.Name = "gbConfNumCta"
        Me.gbConfNumCta.Size = New System.Drawing.Size(306, 165)
        Me.gbConfNumCta.TabIndex = 20
        Me.gbConfNumCta.Text = "Configuración de Número de Cuenta"
        Me.gbConfNumCta.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'grCLIConfNumCta
        '
        grCLIConfNumCta_DesignTimeLayout.LayoutString = resources.GetString("grCLIConfNumCta_DesignTimeLayout.LayoutString")
        Me.grCLIConfNumCta.DesignTimeLayout = grCLIConfNumCta_DesignTimeLayout
        Me.grCLIConfNumCta.GroupByBoxVisible = False
        Me.grCLIConfNumCta.Location = New System.Drawing.Point(9, 31)
        Me.grCLIConfNumCta.Name = "grCLIConfNumCta"
        Me.grCLIConfNumCta.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grCLIConfNumCta.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grCLIConfNumCta.Size = New System.Drawing.Size(284, 109)
        Me.grCLIConfNumCta.TabIndex = 12
        Me.grCLIConfNumCta.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        Me.grCLIConfNumCta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbExcepcionDesglose
        '
        Me.gbExcepcionDesglose.BackColor = System.Drawing.Color.Transparent
        Me.gbExcepcionDesglose.Controls.Add(Me.grDesgloseImpuesto)
        Me.gbExcepcionDesglose.Controls.Add(Me.btCNDIBuscar)
        Me.gbExcepcionDesglose.Controls.Add(Me.btCNDINuevo)
        Me.gbExcepcionDesglose.Controls.Add(Me.btCNDIEliminar)
        Me.gbExcepcionDesglose.Location = New System.Drawing.Point(12, 41)
        Me.gbExcepcionDesglose.Name = "gbExcepcionDesglose"
        Me.gbExcepcionDesglose.Size = New System.Drawing.Size(490, 165)
        Me.gbExcepcionDesglose.TabIndex = 19
        Me.gbExcepcionDesglose.Text = "Excepcion"
        Me.gbExcepcionDesglose.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'grDesgloseImpuesto
        '
        grDesgloseImpuesto_DesignTimeLayout.LayoutString = resources.GetString("grDesgloseImpuesto_DesignTimeLayout.LayoutString")
        Me.grDesgloseImpuesto.DesignTimeLayout = grDesgloseImpuesto_DesignTimeLayout
        Me.grDesgloseImpuesto.GroupByBoxVisible = False
        Me.grDesgloseImpuesto.Location = New System.Drawing.Point(9, 31)
        Me.grDesgloseImpuesto.Name = "grDesgloseImpuesto"
        Me.grDesgloseImpuesto.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grDesgloseImpuesto.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grDesgloseImpuesto.Size = New System.Drawing.Size(378, 109)
        Me.grDesgloseImpuesto.TabIndex = 12
        Me.grDesgloseImpuesto.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        Me.grDesgloseImpuesto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btCNDIBuscar
        '
        Me.btCNDIBuscar.CausesValidation = False
        Me.btCNDIBuscar.Icon = CType(resources.GetObject("btCNDIBuscar.Icon"), System.Drawing.Icon)
        Me.btCNDIBuscar.Location = New System.Drawing.Point(396, 29)
        Me.btCNDIBuscar.Name = "btCNDIBuscar"
        Me.btCNDIBuscar.Size = New System.Drawing.Size(80, 24)
        Me.btCNDIBuscar.TabIndex = 13
        Me.btCNDIBuscar.Text = "Buscar"
        Me.btCNDIBuscar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCNDINuevo
        '
        Me.btCNDINuevo.Icon = CType(resources.GetObject("btCNDINuevo.Icon"), System.Drawing.Icon)
        Me.btCNDINuevo.Location = New System.Drawing.Point(396, 93)
        Me.btCNDINuevo.Name = "btCNDINuevo"
        Me.btCNDINuevo.Size = New System.Drawing.Size(80, 24)
        Me.btCNDINuevo.TabIndex = 15
        Me.btCNDINuevo.Text = "Nuevo"
        Me.btCNDINuevo.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCNDIEliminar
        '
        Me.btCNDIEliminar.CausesValidation = False
        Me.btCNDIEliminar.Icon = CType(resources.GetObject("btCNDIEliminar.Icon"), System.Drawing.Icon)
        Me.btCNDIEliminar.Location = New System.Drawing.Point(396, 61)
        Me.btCNDIEliminar.Name = "btCNDIEliminar"
        Me.btCNDIEliminar.Size = New System.Drawing.Size(80, 24)
        Me.btCNDIEliminar.TabIndex = 14
        Me.btCNDIEliminar.Text = "Eliminar"
        Me.btCNDIEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'chbDesgloseImpuesto
        '
        Me.chbDesgloseImpuesto.BackColor = System.Drawing.Color.Transparent
        Me.chbDesgloseImpuesto.Location = New System.Drawing.Point(12, 15)
        Me.chbDesgloseImpuesto.Name = "chbDesgloseImpuesto"
        Me.chbDesgloseImpuesto.Size = New System.Drawing.Size(172, 20)
        Me.chbDesgloseImpuesto.TabIndex = 11
        Me.chbDesgloseImpuesto.Text = "DesgloseImpuesto"
        Me.chbDesgloseImpuesto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'tabDesglosaImpuesto
        '
        Me.tabDesglosaImpuesto.AttachedControl = Me.TabControlPanel6
        Me.tabDesglosaImpuesto.Name = "tabDesglosaImpuesto"
        Me.tabDesglosaImpuesto.Text = "tabDesglosaImpuesto"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.ccFechaRegistroSistema)
        Me.TabControlPanel1.Controls.Add(Me.gbParametros)
        Me.TabControlPanel1.Controls.Add(Me.cbTipoEstado)
        Me.TabControlPanel1.Controls.Add(Me.gbEsquemas)
        Me.TabControlPanel1.Controls.Add(Me.lbFechaNacimiento)
        Me.TabControlPanel1.Controls.Add(Me.gbContacto)
        Me.TabControlPanel1.Controls.Add(Me.lbIdFiscal)
        Me.TabControlPanel1.Controls.Add(Me.lbClienteClave)
        Me.TabControlPanel1.Controls.Add(Me.ebIdFiscal)
        Me.TabControlPanel1.Controls.Add(Me.lbLimiteDescuento)
        Me.TabControlPanel1.Controls.Add(Me.lbRazonSocial)
        Me.TabControlPanel1.Controls.Add(Me.ebLimiteDescuento)
        Me.TabControlPanel1.Controls.Add(Me.ebRazonSocial)
        Me.TabControlPanel1.Controls.Add(Me.ccFechaNacimiento)
        Me.TabControlPanel1.Controls.Add(Me.lbNombreCorto)
        Me.TabControlPanel1.Controls.Add(Me.ebClienteClave)
        Me.TabControlPanel1.Controls.Add(Me.ebNombreCorto)
        Me.TabControlPanel1.Controls.Add(Me.lbFechaRegistroSistema)
        Me.TabControlPanel1.Controls.Add(Me.lbIdElectronico)
        Me.TabControlPanel1.Controls.Add(Me.lbTipoEstado)
        Me.TabControlPanel1.Controls.Add(Me.ebIdElectronico)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(844, 598)
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.tabGenerales
        '
        'tabGenerales
        '
        Me.tabGenerales.AttachedControl = Me.TabControlPanel1
        Me.tabGenerales.Name = "tabGenerales"
        Me.tabGenerales.Text = "tabGenerales"
        '
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.grClienteMensaje)
        Me.TabControlPanel3.Controls.Add(Me.btMMEBuscar)
        Me.TabControlPanel3.Controls.Add(Me.btMMENuevo)
        Me.TabControlPanel3.Controls.Add(Me.btCLMEliminar)
        Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel3.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel3.Name = "TabControlPanel3"
        Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel3.Size = New System.Drawing.Size(844, 598)
        Me.TabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel3.Style.GradientAngle = 90
        Me.TabControlPanel3.TabIndex = 3
        Me.TabControlPanel3.TabItem = Me.tabMensajes
        '
        'grClienteMensaje
        '
        grClienteMensaje_DesignTimeLayout.LayoutString = resources.GetString("grClienteMensaje_DesignTimeLayout.LayoutString")
        Me.grClienteMensaje.DesignTimeLayout = grClienteMensaje_DesignTimeLayout
        Me.grClienteMensaje.GroupByBoxVisible = False
        Me.grClienteMensaje.Location = New System.Drawing.Point(9, 6)
        Me.grClienteMensaje.Name = "grClienteMensaje"
        Me.grClienteMensaje.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grClienteMensaje.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grClienteMensaje.Size = New System.Drawing.Size(728, 444)
        Me.grClienteMensaje.TabIndex = 4
        Me.grClienteMensaje.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        Me.grClienteMensaje.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'tabMensajes
        '
        Me.tabMensajes.AttachedControl = Me.TabControlPanel3
        Me.tabMensajes.Name = "tabMensajes"
        Me.tabMensajes.Text = "tabMensajes"
        '
        'TabControlPanel4
        '
        Me.TabControlPanel4.Controls.Add(Me.gbClientePago)
        Me.TabControlPanel4.Controls.Add(Me.gbCLIFormaVenta)
        Me.TabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel4.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel4.Name = "TabControlPanel4"
        Me.TabControlPanel4.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel4.Size = New System.Drawing.Size(844, 598)
        Me.TabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel4.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel4.Style.GradientAngle = 90
        Me.TabControlPanel4.TabIndex = 4
        Me.TabControlPanel4.TabItem = Me.tabConVenta
        '
        'tabConVenta
        '
        Me.tabConVenta.AttachedControl = Me.TabControlPanel4
        Me.tabConVenta.Name = "tabConVenta"
        Me.tabConVenta.Text = "tabCondiciones de Venta"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.sbClienteDomicilio)
        Me.TabControlPanel2.Controls.Add(Me.gbClienteDomicilio)
        Me.TabControlPanel2.Controls.Add(Me.btCLDEliminar)
        Me.TabControlPanel2.Controls.Add(Me.btCLDCrear)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(844, 598)
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.tabDomicilio
        '
        'tabDomicilio
        '
        Me.tabDomicilio.AttachedControl = Me.TabControlPanel2
        Me.tabDomicilio.Name = "tabDomicilio"
        Me.tabDomicilio.Text = "tabDomicilio"
        '
        'TabControlPanel5
        '
        Me.TabControlPanel5.Controls.Add(Me.ebSaldoProducto)
        Me.TabControlPanel5.Controls.Add(Me.lbSaldoProducto)
        Me.TabControlPanel5.Controls.Add(Me.lbFechaFactura)
        Me.TabControlPanel5.Controls.Add(Me.lbSaldoEfectivo)
        Me.TabControlPanel5.Controls.Add(Me.ebFechaFactura)
        Me.TabControlPanel5.Controls.Add(Me.grClienteProducto)
        Me.TabControlPanel5.Controls.Add(Me.ebSaldoEfectivo)
        Me.TabControlPanel5.Controls.Add(Me.btCPRHistorico)
        Me.TabControlPanel5.Controls.Add(Me.ebSaldoPrestamo)
        Me.TabControlPanel5.Controls.Add(Me.lbSaldoPrestamo)
        Me.TabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel5.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel5.Name = "TabControlPanel5"
        Me.TabControlPanel5.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel5.Size = New System.Drawing.Size(844, 598)
        Me.TabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel5.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel5.Style.GradientAngle = 90
        Me.TabControlPanel5.TabIndex = 5
        Me.TabControlPanel5.TabItem = Me.tabSaldos
        '
        'ebSaldoProducto
        '
        Me.ebSaldoProducto.DecimalDigits = 2
        Me.ebSaldoProducto.Enabled = False
        Me.ebSaldoProducto.Location = New System.Drawing.Point(621, 11)
        Me.ebSaldoProducto.Name = "ebSaldoProducto"
        Me.ebSaldoProducto.Size = New System.Drawing.Size(128, 20)
        Me.ebSaldoProducto.TabIndex = 9
        Me.ebSaldoProducto.Text = "0.00"
        Me.ebSaldoProducto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebSaldoProducto.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ebSaldoProducto.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbSaldoProducto
        '
        Me.lbSaldoProducto.BackColor = System.Drawing.Color.Transparent
        Me.lbSaldoProducto.Location = New System.Drawing.Point(520, 11)
        Me.lbSaldoProducto.Name = "lbSaldoProducto"
        Me.lbSaldoProducto.Size = New System.Drawing.Size(100, 20)
        Me.lbSaldoProducto.TabIndex = 8
        Me.lbSaldoProducto.Text = "lbSaldoProducto"
        Me.lbSaldoProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabSaldos
        '
        Me.tabSaldos.AttachedControl = Me.TabControlPanel5
        Me.tabSaldos.Name = "tabSaldos"
        Me.tabSaldos.Text = "tabSaldos"
        '
        'chbCapturaDatosFacturacion
        '
        Me.chbCapturaDatosFacturacion.BackColor = System.Drawing.Color.Transparent
        Me.chbCapturaDatosFacturacion.Location = New System.Drawing.Point(640, 94)
        Me.chbCapturaDatosFacturacion.Name = "chbCapturaDatosFacturacion"
        Me.chbCapturaDatosFacturacion.Size = New System.Drawing.Size(176, 20)
        Me.chbCapturaDatosFacturacion.TabIndex = 24
        Me.chbCapturaDatosFacturacion.Text = "chbCapturaDatosFacturacion"
        Me.chbCapturaDatosFacturacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'MGENERAL
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(865, 682)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "MGENERAL"
        Me.Text = "Mantener Cliente"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.EbClave, 0)
        Me.Controls.SetChildIndex(Me.lbClave, 0)
        Me.Controls.SetChildIndex(Me.lbLinea, 0)
        Me.Controls.SetChildIndex(Me.BtAceptar, 0)
        Me.Controls.SetChildIndex(Me.BtCancelar, 0)
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbEsquemas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEsquemas.ResumeLayout(False)
        CType(Me.grClienteEsquema, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbContacto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbContacto.ResumeLayout(False)
        Me.gbContacto.PerformLayout()
        CType(Me.gbClienteDomicilio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbClienteDomicilio.ResumeLayout(False)
        Me.gbClienteDomicilio.PerformLayout()
        CType(Me.grFrecuencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grClientePago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grClienteProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbParametros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbParametros.ResumeLayout(False)
        Me.gbParametros.PerformLayout()
        CType(Me.gbClientePago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbClientePago.ResumeLayout(False)
        CType(Me.gbCLIFormaVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCLIFormaVenta.ResumeLayout(False)
        CType(Me.grCLIFormaVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel6.ResumeLayout(False)
        CType(Me.gbConfNumCta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbConfNumCta.ResumeLayout(False)
        CType(Me.grCLIConfNumCta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbExcepcionDesglose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbExcepcionDesglose.ResumeLayout(False)
        CType(Me.grDesgloseImpuesto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        Me.TabControlPanel3.ResumeLayout(False)
        CType(Me.grClienteMensaje, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanel4.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        Me.TabControlPanel5.ResumeLayout(False)
        Me.TabControlPanel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Variables de Clase"
    Private vcMODO As eModo
    Private vcCliente As ERMCLILOG.cCliente
    Private vcMUsuarioId As String
    Private vcMensaje As New BASMENLOG.CMensaje
    Private vcEsquema As New ERMESQLOG.CEsquema
    Private vcImpuesto As New ERMIMPLOG.CImpuesto
    Private vcEsquemaId As String
    Private vcCLDModo As eModo
    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vcClienteMensaje As New ERMCLILOG.cClienteMensaje
    Private vcMDBMensaje As New ERMMMELOG.cMDBMensaje
    Private vcClienteProducto As New ERMCLILOG.cClienteProducto
    Private vcFrecuencia As New ERMFRELOG.cFrecuencia
    Private vcSecuencia As New ERMSECLOG.cSecuencia
    Private vcCLDIndex As Integer
    Private vcHuboCambios As Boolean = False
    Private vcCerrar As Boolean = False
    Private vcHSFrecuencia As New Hashtable(10)
    Private vcCFVTipo As Integer
    Private vcActualizandoInicial As Boolean = False
    Private vcDireccionValidada As Boolean = True
    Private vcTipoIniciarVisita As Integer
    Private nEstadoInicial As Integer
    Private aValGrupoE As ArrayList = New ArrayList
#End Region

#Region "Funciones Generales"
    Private Sub LimpiarErrores()
        Dim ctrl As Control
        For Each ctrl In gbClienteDomicilio.Controls
            epErrores.SetError(ctrl, "")
        Next
    End Sub
    Private Sub LlenarValoresIniciales()

        vcTipoIniciarVisita = LbConexion.cConexion.Instancia.EjecutarComandoScalar("select top 1 TipoIniciarVisita from conhist order by MFechaHora desc")
        lbClienteClave.Text = vcMensaje.RecuperarDescripcion("CLIClave")
        lbFechaRegistroSistema.Text = vcMensaje.RecuperarDescripcion("CLIFechaRegistroSistema")
        lbTipoEstado.Text = vcMensaje.RecuperarDescripcion("CLITipoEstado")
        lbIdElectronico.Text = vcMensaje.RecuperarDescripcion("CLIIdElectronico")
        lbNombreCorto.Text = vcMensaje.RecuperarDescripcion("CLINombreCorto")
        lbRazonSocial.Text = vcMensaje.RecuperarDescripcion("CLIRazonSocial")
        lbTipoFiscal.Text = vcMensaje.RecuperarDescripcion("CLITipoFiscal")
        lbTipoImpuesto.Text = vcMensaje.RecuperarDescripcion("CLITipoImpuesto")
        lbIdFiscal.Text = vcMensaje.RecuperarDescripcion("CLIIdFiscal")
        lbFechaNacimiento.Text = vcMensaje.RecuperarDescripcion("CLIFechaNacimiento")
        lbLimiteCreditoDinero.Text = vcMensaje.RecuperarDescripcion("CLILimiteCreditoDinero")
        chbPrestamo.Text = vcMensaje.RecuperarDescripcion("CLIPrestamo")
        chbExclusividad.Text = vcMensaje.RecuperarDescripcion("CLIExclusividad")
        lbVigExclusividad.Text = vcMensaje.RecuperarDescripcion("CLIVigExclusividad")
        chbActualizaSaldoCheque.Text = vcMensaje.RecuperarDescripcion("CLIActualizaSaldoCheque")
        chbVencimientoVenta.Text = vcMensaje.RecuperarDescripcion("CLIVencimientoVenta")
        lbDiasVencimiento.Text = vcMensaje.RecuperarDescripcion("CLIDiasVencimiento")
        lbLimiteDescuento.Text = vcMensaje.RecuperarDescripcion("CLILimiteDescuento")
        lbNombreContacto.Text = vcMensaje.RecuperarDescripcion("CLINombreContacto")
        lbTelefonoContacto.Text = vcMensaje.RecuperarDescripcion("CLITelefonoContacto")
        lbSaldoEfectivo.Text = vcMensaje.RecuperarDescripcion("CLISaldoEfectivo")
        lbSaldoPrestamo.Text = vcMensaje.RecuperarDescripcion("CLISaldoPrestamo")
        lbFechaFactura.Text = vcMensaje.RecuperarDescripcion("CLIFechaFactura")
        Me.lbSaldoProducto.Text = vcMensaje.RecuperarDescripcion("CLISaldoProducto")

        chbDesgloseImpuesto.Text = vcMensaje.RecuperarDescripcion("CLIDesglose")
        chbExigirOrden.Text = vcMensaje.RecuperarDescripcion("CLIExigirOrdenCompra")
        chbCriterioCredito.Text = vcMensaje.RecuperarDescripcion("CLICriterioCredito")
        chbImprimirPagare.Text = vcMensaje.RecuperarDescripcion("CLIImprimirPagare")
        chbCapturaDatosFacturacion.Text = vcMensaje.RecuperarDescripcion("CLICapturaDatosFacturacion")
        lbCorreoElectronico.Text = vcMensaje.RecuperarDescripcion("CLICorreoElectronico")


        lbNumInt.Text = vcMensaje.RecuperarDescripcion("CLDNumInt")
        lbReferencia.Text = vcMensaje.RecuperarDescripcion("CLDReferenciaDom")
        lbLocalidad.Text = vcMensaje.RecuperarDescripcion("CLDLocalidad")

        lbTipo.Text = vcMensaje.RecuperarDescripcion("CLDTipo")
        lbCalle.Text = vcMensaje.RecuperarDescripcion("CLDCalle")
        lbNumero.Text = vcMensaje.RecuperarDescripcion("CLDNumero")
        lbCodigoPostal.Text = vcMensaje.RecuperarDescripcion("CLDCodigoPostal")
        lbColonia.Text = vcMensaje.RecuperarDescripcion("CLDColonia")
        lbPoblacion.Text = vcMensaje.RecuperarDescripcion("CLDPoblacion")
        lbEntidad.Text = vcMensaje.RecuperarDescripcion("CLDEntidad")
        lbPais.Text = vcMensaje.RecuperarDescripcion("CLDPais")
        lbCoordenadaX.Text = vcMensaje.RecuperarDescripcion("CLDCoordenadaX")
        lbCoordenadaY.Text = vcMensaje.RecuperarDescripcion("CLDCoordenadaY")

        ebClienteClave.Tag = "Clave"
        ccFechaRegistroSistema.Tag = "FechaRegistroSistema"
        cbTipoEstado.Tag = "TipoEstado"
        ebIdElectronico.Tag = "IdElectronico"
        ebNombreCorto.Tag = "NombreCorto"
        ebRazonSocial.Tag = "RazonSocial"
        cbTipoFiscal.Tag = "TipoFiscal"
        cbTipoImpuesto.Tag = "TipoImpuesto"
        ebIdFiscal.Tag = "IdFiscal"
        ccFechaNacimiento.Tag = "FechaNacimiento"
        ebLimiteCreditoDinero.Tag = "LimiteCreditoDinero"
        chbPrestamo.Tag = "Prestamo"
        chbExclusividad.Tag = "Exclusividad"
        chbExigirOrden.Tag = "ExigirOrdenCompra"
        chbCriterioCredito.Tag = "CriterioCredito"
        chbImprimirPagare.Tag = "ImprimirPagare"
        chbCapturaDatosFacturacion.Tag = "CapturaDatosFacturacion"
        ebVigExclusividad.Tag = "VigExclusividad"
        ebLimiteDescuento.Tag = "LimiteDescuento"
        chbActualizaSaldoCheque.Tag = "ActualizaSaldoCheque"
        chbVencimientoVenta.Tag = "VencimientoVenta"
        ebDiasVencimiento.Tag = "DiasVencimiento"
        ebNombreContacto.Tag = "NombreContacto"
        ebTelefonoContacto.Tag = "TelefonoContacto"
        ebSaldoEfectivo.Tag = "SaldoEfectivo"
        ebSaldoPrestamo.Tag = "SaldoPrestamo"
        ebFechaFactura.Tag = "FechaFactura"
        ebCorreoElectronico.Tag = "CorreoElectronico"
        ebCodigoPostal.Tag = "CodigoPostal"
        ebEntidad.Tag = "Entidad"
        ebPoblacion.Tag = "Municipio"
        ebCalle.Tag = "Calle"
        ebCoordenadaX.Tag = "CoordenadaX"
        ebCoordenadaY.Tag = "CoordenadaY"

        Dim vlToolTip As New ToolTip
        With vlToolTip
            .ShowAlways = True
            .SetToolTip(Me.ebClienteClave, vcMensaje.RecuperarDescripcion("CLIClaveT"))
            .SetToolTip(Me.ccFechaRegistroSistema, vcMensaje.RecuperarDescripcion("CLIFechaRegistroSistemaT"))
            .SetToolTip(Me.cbTipoEstado, vcMensaje.RecuperarDescripcion("CLITipoEstadoT"))
            .SetToolTip(Me.ebIdElectronico, vcMensaje.RecuperarDescripcion("CLIIdElectronicoT"))
            .SetToolTip(Me.ebNombreCorto, vcMensaje.RecuperarDescripcion("CLINombreCortoT"))
            .SetToolTip(Me.ebRazonSocial, vcMensaje.RecuperarDescripcion("CLIRazonSocialT"))
            .SetToolTip(Me.cbTipoFiscal, vcMensaje.RecuperarDescripcion("CLITipoFiscalT"))
            .SetToolTip(Me.cbTipoImpuesto, vcMensaje.RecuperarDescripcion("CLITipoImpuestoT"))
            .SetToolTip(Me.ebIdFiscal, vcMensaje.RecuperarDescripcion("CLIIdFiscalT"))
            .SetToolTip(Me.ccFechaNacimiento, vcMensaje.RecuperarDescripcion("CLIFechaNacimientoT"))
            .SetToolTip(Me.ebLimiteCreditoDinero, vcMensaje.RecuperarDescripcion("CLILimiteCreditoDineroT"))
            .SetToolTip(Me.chbPrestamo, vcMensaje.RecuperarDescripcion("CLIPrestamoT"))
            .SetToolTip(Me.chbExclusividad, vcMensaje.RecuperarDescripcion("CLIExclusividadT"))
            .SetToolTip(Me.ebVigExclusividad, vcMensaje.RecuperarDescripcion("CLIVigExclusividadT"))
            .SetToolTip(Me.chbActualizaSaldoCheque, vcMensaje.RecuperarDescripcion("CLIActualizaSaldoChequeT"))
            .SetToolTip(Me.chbVencimientoVenta, vcMensaje.RecuperarDescripcion("CLIVencimientoVentaT"))
            .SetToolTip(Me.ebDiasVencimiento, vcMensaje.RecuperarDescripcion("CLIDiasVencimiento"))

            .SetToolTip(Me.ebLimiteDescuento, vcMensaje.RecuperarDescripcion("CLILimiteDescuentoT"))
            .SetToolTip(Me.ebNombreContacto, vcMensaje.RecuperarDescripcion("CLINombreContactoT"))
            .SetToolTip(Me.ebTelefonoContacto, vcMensaje.RecuperarDescripcion("CLITelefonoContactoT"))
            .SetToolTip(Me.ebSaldoEfectivo, vcMensaje.RecuperarDescripcion("CLISaldoEfectivoT"))
            '.SetToolTip(Me.ebSaldoGarantia, vcMensaje.RecuperarDescripcion("CLISaldoGarantiaT"))
            .SetToolTip(Me.ebSaldoPrestamo, vcMensaje.RecuperarDescripcion("CLISaldoPrestamoT"))
            .SetToolTip(Me.ebSaldoProducto, vcMensaje.RecuperarDescripcion("CLISaldoProductoT"))
            .SetToolTip(Me.ebFechaFactura, vcMensaje.RecuperarDescripcion("CLIFechaFacturaT"))

            .SetToolTip(Me.chbDesgloseImpuesto, vcMensaje.RecuperarDescripcion("CLIDesgloseT"))
            .SetToolTip(Me.ebCorreoElectronico, vcMensaje.RecuperarDescripcion("CLICorreoElectronicoT"))
            .SetToolTip(Me.chbExigirOrden, vcMensaje.RecuperarDescripcion("CLIExigirOrdenCompraT"))
            .SetToolTip(Me.chbCriterioCredito, vcMensaje.RecuperarDescripcion("CLICriterioCreditoT"))
            .SetToolTip(Me.chbImprimirPagare, vcMensaje.RecuperarDescripcion("CLIImprimirPagareT"))
            .SetToolTip(Me.chbCapturaDatosFacturacion, vcMensaje.RecuperarDescripcion("CLICapturaDatosFacturacionT"))

            .SetToolTip(Me.ebNumInt, vcMensaje.RecuperarDescripcion("CLDNumIntT"))
            .SetToolTip(Me.ebReferencia, vcMensaje.RecuperarDescripcion("CLDReferenciaDomT"))
            .SetToolTip(Me.ebLocalidad, vcMensaje.RecuperarDescripcion("CLDLocalidadT"))


            .SetToolTip(Me.cbTipo, vcMensaje.RecuperarDescripcion("CLDTipoT"))
            .SetToolTip(Me.ebCalle, vcMensaje.RecuperarDescripcion("CLDCalleT"))
            .SetToolTip(Me.ebNumero, vcMensaje.RecuperarDescripcion("CLDNumeroT"))
            .SetToolTip(Me.ebCodigoPostal, vcMensaje.RecuperarDescripcion("CLDCodigoPostalT"))
            .SetToolTip(Me.ebColonia, vcMensaje.RecuperarDescripcion("CLDColoniaT"))
            .SetToolTip(Me.ebPoblacion, vcMensaje.RecuperarDescripcion("CLDPoblacionT"))
            .SetToolTip(Me.ebEntidad, vcMensaje.RecuperarDescripcion("CLDEntidadT"))
            .SetToolTip(Me.ebPais, vcMensaje.RecuperarDescripcion("CLDPaisT"))
            .SetToolTip(Me.ebCoordenadaX, vcMensaje.RecuperarDescripcion("CLDCoordenadaXT"))
            .SetToolTip(Me.ebCoordenadaY, vcMensaje.RecuperarDescripcion("CLDCoordenadaYT"))
            '.SetToolTip(Me.ebVigExclusividad, vcMensaje.RecuperarDescripcion("CLIVigExclusividadT"))

            .SetToolTip(Me.btCLECrear, vcMensaje.RecuperarDescripcion("BTCrearT"))
            .SetToolTip(Me.btCLEEliminar, vcMensaje.RecuperarDescripcion("BTEliminarT"))
            .SetToolTip(Me.btESQBuscar, vcMensaje.RecuperarDescripcion("BTBuscarT"))
            .SetToolTip(Me.btCopiar, vcMensaje.RecuperarDescripcion("BTCopiarT"))
            .SetToolTip(Me.btCLDCrear, vcMensaje.RecuperarDescripcion("BTCrearT"))
            .SetToolTip(Me.btCLDEliminar, vcMensaje.RecuperarDescripcion("BTEliminarT"))
            .SetToolTip(Me.btMMEBuscar, vcMensaje.RecuperarDescripcion("BTBuscarT"))
            .SetToolTip(Me.btMMENuevo, vcMensaje.RecuperarDescripcion("BTNuevoT"))
            .SetToolTip(Me.btCLMEliminar, vcMensaje.RecuperarDescripcion("BTEliminarT"))
            .SetToolTip(Me.btCLPCrear, vcMensaje.RecuperarDescripcion("BTCrearT"))
            .SetToolTip(Me.btCLPEliminar, vcMensaje.RecuperarDescripcion("BTEliminarT"))
            .SetToolTip(Me.btCFVCrear, vcMensaje.RecuperarDescripcion("BTCrearT"))
            .SetToolTip(Me.btCFVEliminar, vcMensaje.RecuperarDescripcion("BTEliminarT"))
            .SetToolTip(Me.btCFVHistorico, vcMensaje.RecuperarDescripcion("BTHistoricoT"))

            .SetToolTip(Me.btCNDINuevo, vcMensaje.RecuperarDescripcion("BTCrearT"))
            .SetToolTip(Me.btCNDIEliminar, vcMensaje.RecuperarDescripcion("BTEliminarT"))
            .SetToolTip(Me.btCNDIBuscar, vcMensaje.RecuperarDescripcion("BTBuscarT"))


            .SetToolTip(Me.BtAceptar, vcMensaje.RecuperarDescripcion("BTAceptarT"))
            If vcMODO = eModo.Leer Then
                .SetToolTip(Me.BtCancelar, vcMensaje.RecuperarDescripcion("BTregresar"))
            Else
                .SetToolTip(Me.BtCancelar, vcMensaje.RecuperarDescripcion("BTCancelarT"))
            End If

        End With

        Me.btCLECrear.Text = vcMensaje.RecuperarDescripcion("BTCrear")
        Me.btCLEEliminar.Text = vcMensaje.RecuperarDescripcion("BTEliminar")
        Me.btESQBuscar.Text = vcMensaje.RecuperarDescripcion("BTBuscar")
        Me.btCopiar.Text = vcMensaje.RecuperarDescripcion("BTCopiar")
        Me.btCLDCrear.Text = vcMensaje.RecuperarDescripcion("BTCrear")
        Me.btCLDEliminar.Text = vcMensaje.RecuperarDescripcion("BTEliminar")
        Me.btMMEBuscar.Text = vcMensaje.RecuperarDescripcion("BTBuscar")
        Me.btMMENuevo.Text = vcMensaje.RecuperarDescripcion("BTNuevo")
        Me.btCLMEliminar.Text = vcMensaje.RecuperarDescripcion("BTEliminar")
        Me.btCLPCrear.Text = vcMensaje.RecuperarDescripcion("BTCrear")
        Me.btCLPEliminar.Text = vcMensaje.RecuperarDescripcion("BTEliminar")
        Me.btCFVCrear.Text = vcMensaje.RecuperarDescripcion("BTCrear")
        Me.btCFVEliminar.Text = vcMensaje.RecuperarDescripcion("BTEliminar")
        Me.btCFVHistorico.Text = vcMensaje.RecuperarDescripcion("BTHistorico")

        Me.btCNDIEliminar.Text = vcMensaje.RecuperarDescripcion("BTEliminar")
        Me.btCNDIBuscar.Text = vcMensaje.RecuperarDescripcion("BTBuscar")
        Me.btCNDINuevo.Text = vcMensaje.RecuperarDescripcion("BTNuevo")


        Me.BtAceptar.Text = vcMensaje.RecuperarDescripcion("BTAceptar")
        Me.BtCancelar.Text = vcMensaje.RecuperarDescripcion("BTCancelar")

        Me.gbContacto.Text = vcMensaje.RecuperarDescripcion("XContacto")
        Me.gbParametros.Text = vcMensaje.RecuperarDescripcion("XParametros")

        Me.gbEsquemas.Text = vcMensaje.RecuperarDescripcion("XEsquemas")
        With grClienteEsquema.RootTable
            .Columns("Clave").Caption = vcMensaje.RecuperarDescripcion("ESQClave")
            .Columns("Clave").HeaderToolTip = vcMensaje.RecuperarDescripcion("ESQClaveT")
            .Columns("Nombre").Caption = vcMensaje.RecuperarDescripcion("ESQNombre")
            .Columns("Nombre").HeaderToolTip = vcMensaje.RecuperarDescripcion("ESQNombreT")
            .Columns("TipoEstado").Caption = vcMensaje.RecuperarDescripcion("ESQTipoEstado")
            .Columns("TipoEstado").HeaderToolTip = vcMensaje.RecuperarDescripcion("ESQTipoEstadoT")
        End With

        With grDesgloseImpuesto.RootTable
            .Columns("ImpuestoClave").Caption = vcMensaje.RecuperarDescripcion("IMPImpuestoClave")
            .Columns("ImpuestoClave").HeaderToolTip = vcMensaje.RecuperarDescripcion("IMPImpuestoClaveT")
            .Columns("Nombre").Caption = vcMensaje.RecuperarDescripcion("IMPNombre")
            .Columns("Nombre").HeaderToolTip = vcMensaje.RecuperarDescripcion("IMPNombreT")
            .Columns("Abreviatura").Caption = vcMensaje.RecuperarDescripcion("IMPAbreviatura")
            .Columns("Abreviatura").HeaderToolTip = vcMensaje.RecuperarDescripcion("IMPAbreviaturaT")
        End With
        tabDesglosaImpuesto.Text = vcMensaje.RecuperarDescripcion("CLIDesglose")
        gbExcepcionDesglose.Text = vcMensaje.RecuperarDescripcion("BTExcepciones")

        With grFrecuencia.RootTable
            .Columns("FrecuenciaClave").Caption = vcMensaje.RecuperarDescripcion("FREFrecuenciaClave")
            .Columns("FrecuenciaClave").HeaderToolTip = vcMensaje.RecuperarDescripcion("FREFrecuenciaClaveT")
            .Columns("Descripcion").Caption = vcMensaje.RecuperarDescripcion("FREDescripcion")
            .Columns("Descripcion").HeaderToolTip = vcMensaje.RecuperarDescripcion("FREDescripcionT")
            .Columns("Tipo").Caption = vcMensaje.RecuperarDescripcion("FRETipo")
            .Columns("Tipo").HeaderToolTip = vcMensaje.RecuperarDescripcion("FRETipoT")
            .Columns("FechaInicio").Caption = vcMensaje.RecuperarDescripcion("FREFechaInicio")
            .Columns("FechaInicio").HeaderToolTip = vcMensaje.RecuperarDescripcion("FREFechaInicioT")
            .Columns("FechaFinal").Caption = vcMensaje.RecuperarDescripcion("FREFechaFinal")
            .Columns("FechaFinal").HeaderToolTip = vcMensaje.RecuperarDescripcion("FREFechaFinalT")
            .Columns("UnidadInicio").Caption = vcMensaje.RecuperarDescripcion("FREUnidadInicio")
            .Columns("UnidadInicio").HeaderToolTip = vcMensaje.RecuperarDescripcion("FREUnidadInicioT")
            .Columns("Repeticion").Caption = vcMensaje.RecuperarDescripcion("FRERepeticion")
            .Columns("Repeticion").HeaderToolTip = vcMensaje.RecuperarDescripcion("FRERepeticionT")
            .Columns("Intervalo").Caption = vcMensaje.RecuperarDescripcion("FREIntervalo")
            .Columns("Intervalo").HeaderToolTip = vcMensaje.RecuperarDescripcion("FREIntervaloT")
            .Columns("RUTClave").Caption = vcMensaje.RecuperarDescripcion("SECRUTClave")
            .Columns("RUTClave").HeaderToolTip = vcMensaje.RecuperarDescripcion("SECRUTClaveT")

        End With

        With grClienteMensaje.RootTable
            .Columns("Numero").Caption = vcMensaje.RecuperarDescripcion("MMENumero")
            .Columns("Numero").HeaderToolTip = vcMensaje.RecuperarDescripcion("MMENumeroT")
            .Columns("MDBMensajeTipo").Caption = vcMensaje.RecuperarDescripcion("MMEMDBMensajeTipo")
            .Columns("MDBMensajeTipo").HeaderToolTip = vcMensaje.RecuperarDescripcion("MMEMDBMensajeTipoT")
            .Columns("Descripcion").Caption = vcMensaje.RecuperarDescripcion("MMEDescripcion")
            .Columns("Descripcion").HeaderToolTip = vcMensaje.RecuperarDescripcion("MMEDescripcionT")
            .Columns("TipoEstado").Caption = vcMensaje.RecuperarDescripcion("CLMTipoEstado")
            .Columns("TipoEstado").HeaderToolTip = vcMensaje.RecuperarDescripcion("CLMTipoEstadoT")
        End With

        Me.gbClientePago.Text = vcMensaje.RecuperarDescripcion("ERMCLIESC_gbClientePago")
        With grClientePago.RootTable
            .Columns("Tipo").Caption = vcMensaje.RecuperarDescripcion("CLPTipo")
            .Columns("Tipo").HeaderToolTip = vcMensaje.RecuperarDescripcion("CLPTipoT")
            .Columns("TipoBanco").Caption = vcMensaje.RecuperarDescripcion("CLPTipoBanco")
            .Columns("TipoBanco").HeaderToolTip = vcMensaje.RecuperarDescripcion("CLPTipoBancoT")
            .Columns("Cuenta").Caption = vcMensaje.RecuperarDescripcion("CLPCuenta")
            .Columns("Cuenta").HeaderToolTip = vcMensaje.RecuperarDescripcion("CLPCuentaT")
            .Columns("TipoEstado").Caption = vcMensaje.RecuperarDescripcion("CLPTipoEstado")
            .Columns("TipoEstado").HeaderToolTip = vcMensaje.RecuperarDescripcion("CLPTipoEstadoT")
        End With

        Me.gbCLIFormaVenta.Text = vcMensaje.RecuperarDescripcion("ERMCLIESC_gbCLIFormaVenta")
        With grCLIFormaVenta.RootTable
            .Columns("CFVTipo").Caption = vcMensaje.RecuperarDescripcion("CFVCFVTipo")
            .Columns("CFVTipo").HeaderToolTip = vcMensaje.RecuperarDescripcion("CFVCFVTipoT")
            .Columns("LimiteCredito").Caption = vcMensaje.RecuperarDescripcion("CFVLimiteCredito")
            .Columns("LimiteCredito").HeaderToolTip = vcMensaje.RecuperarDescripcion("CFVLimiteCreditoT")
            .Columns("DiasCredito").Caption = vcMensaje.RecuperarDescripcion("CFVDiasCredito")
            .Columns("DiasCredito").HeaderToolTip = vcMensaje.RecuperarDescripcion("CFVDiasCreditoT")
            .Columns("Inicial").Caption = vcMensaje.RecuperarDescripcion("CFVInicial")
            .Columns("Inicial").HeaderToolTip = vcMensaje.RecuperarDescripcion("CFVInicialT")
            .Columns("CapturaDias").Caption = vcMensaje.RecuperarDescripcion("CFVCapturaDias")
            .Columns("CapturaDias").HeaderToolTip = vcMensaje.RecuperarDescripcion("CFVCapturaDiasT")
            .Columns("ValidaLimite").Caption = vcMensaje.RecuperarDescripcion("CFVValidaLimite")
            .Columns("ValidaLimite").HeaderToolTip = vcMensaje.RecuperarDescripcion("CFVValidaLimiteT")
            .Columns("ValidaPago").Caption = vcMensaje.RecuperarDescripcion("CFVValidaPago")
            .Columns("ValidaPago").HeaderToolTip = vcMensaje.RecuperarDescripcion("CFVValidaPagoT")
            .Columns("Estado").Caption = vcMensaje.RecuperarDescripcion("CFVEstado")
            .Columns("Estado").HeaderToolTip = vcMensaje.RecuperarDescripcion("CFVEstadoT")
        End With

        With grClienteProducto.RootTable
            .Columns("ProductoClave").Caption = vcMensaje.RecuperarDescripcion("XClave")
            .Columns("ProductoClave").HeaderToolTip = vcMensaje.RecuperarDescripcion("PROProductoClaveT")
            .Columns("NombreLargo").Caption = vcMensaje.RecuperarDescripcion("PRONombreLargo")
            .Columns("NombreLargo").HeaderToolTip = vcMensaje.RecuperarDescripcion("PRONombreLargoT")
            .Columns("Saldo").Caption = vcMensaje.RecuperarDescripcion("XSaldo")
            .Columns("Saldo").HeaderToolTip = vcMensaje.RecuperarDescripcion("XSaldoActual")
        End With

        tabGenerales.Text = vcMensaje.RecuperarDescripcion("XGenerales")
        tabDomicilio.Text = vcMensaje.RecuperarDescripcion("XDomicilio")
        tabMensajes.Text = vcMensaje.RecuperarDescripcion("XMensajes")
        tabConVenta.Text = vcMensaje.RecuperarDescripcion("XCondicionesdeVenta")
        tabSaldos.Text = vcMensaje.RecuperarDescripcion("XSaldos")
        tabDesglosaImpuesto.Text = vcMensaje.RecuperarDescripcion("XFacturacion")

        With grCLIConfNumCta.RootTable
            .Columns("Campo").Caption = vcMensaje.RecuperarDescripcion("TIPMDBCampoClave")
            .Columns("Campo").HeaderToolTip = vcMensaje.RecuperarDescripcion("TIPMDBCampoClave")
            .Columns("Orden").Caption = vcMensaje.RecuperarDescripcion("SECOrden")
            .Columns("Orden").HeaderToolTip = vcMensaje.RecuperarDescripcion("SECOrden")
        End With
        'UiTabPage1.Text = vcMensaje.RecuperarDescripcion("XGenerales")
        'UiTabPage2.Text = vcMensaje.RecuperarDescripcion("XDomicilio")
        'UiTabPage4.Text = vcMensaje.RecuperarDescripcion("XMensajes")
        'UiTabPage5.Text = vcMensaje.RecuperarDescripcion("XCondicionesdeVenta")
        'UiTabPage6.Text = vcMensaje.RecuperarDescripcion("XSaldos")

        'Tab 1
        lbGeneral.LlenarComboBox(cbTipoEstado, "EDOREG")
        lbGeneral.LlenarComboBox(cbTipoFiscal, "DOCFISC")
        lbGeneral.LlenarComboBox(cbTipoImpuesto, "IMPCTE")
        lbGeneral.LlenarColumna(grClienteEsquema.RootTable.Columns("TipoEstado"), "EDOREG")

        'Tab 2
        lbGeneral.LlenarComboBox(cbTipo, "DOMTIPO")
        lbGeneral.LlenarComboBox(cbCopiar, "DOMTIPO")
        lbGeneral.LlenarColumna(grFrecuencia.RootTable.Columns("Tipo"), "FRETIPO")

        'Tab 3
        lbGeneral.LlenarColumna(grClienteMensaje.RootTable.Columns("TipoEstado"), "EDOREG")
        lbGeneral.LlenarColumna(grClienteMensaje.RootTable.Columns("MDBMensajeTipo"), "MDBMENT")

        'Tab 4
        lbGeneral.LlenarColumna(grClientePago.RootTable.Columns("Tipo"), "PAGO")
        Dim vl As Janus.Windows.GridEX.GridEXValueListItem
        Dim valorRef As BASVARLOG.cValorReferencia = New BASVARLOG.cValorReferencia
        valorRef.Recuperar("PAGO")
        Dim dtPagos As DataTable = valorRef.VARValor.ToDataTable()
        grClientePago.RootTable.Columns("Tipo").EditValueList = New Janus.Windows.GridEX.GridEXValueListItemCollection
        For Each vl In grClientePago.RootTable.Columns("Tipo").ValueList
            Dim drs As DataRow() = dtPagos.Select("VAVClave = '" + vl.Value + "'")
            If drs.Length > 0 AndAlso drs(0)("Estado") = 1 Then
                Dim vlItem As New Janus.Windows.GridEX.GridEXValueListItem
                vlItem.Text = vl.Text
                vlItem.Value = vl.Value
                grClientePago.RootTable.Columns("Tipo").EditValueList.Add(vlItem)
                If drs(0)("Grupo") = "E" Then
                    aValGrupoE.Add(vl.Value)
                End If
            End If
        Next
        lbGeneral.LlenarColumna(grClientePago.RootTable.Columns("TipoBanco"), "TBANCO")
        lbGeneral.LlenarColumna(grClientePago.RootTable.Columns("TipoEstado"), "EDOREG")
        lbGeneral.LlenarColumna(grCLIFormaVenta.RootTable.Columns("CFVTipo"), "FVENTA")
        lbGeneral.LlenarColumna(grCLIFormaVenta.RootTable.Columns("Estado"), "EDOREG")
        lbGeneral.LlenarColumna(grCLIConfNumCta.RootTable.Columns("Campo"), "CONFCTA")
    End Sub

    Public Function CREAR(ByRef prCliente As ERMCLILOG.cCliente, ByVal pvMUsuarioId As String) As Boolean
        Dim vlDataTable As DataTable

        vcMODO = eModo.Crear
        vcCliente = prCliente
        vcMUsuarioId = pvMUsuarioId

        Me.Text = vcMensaje.RecuperarDescripcion("ERMCLIESC_MGeneralC")

        Call LlenarValoresIniciales()

        'Tab 1
        vcCliente.ClienteClave = lbGeneral.cKeyGen.KEYGEN(0)
        ccFechaRegistroSistema.Value = LbConexion.cConexion.Instancia.ObtenerFecha.Date
        cbTipoEstado.SelectedValue = 1
        cbTipoFiscal.SelectedValue = 1
        cbTipoImpuesto.SelectedValue = 1
        ccFechaNacimiento.Value = Today.AddDays(-1)
        chbPrestamo.Checked = True
        ebVigExclusividad.Enabled = False
        chbActualizaSaldoCheque.Checked = True
        chbVencimientoVenta.Checked = True
        chbExigirOrden.Checked = False
        btCLEEliminar.Enabled = False

        vlDataTable = vcCliente.ClienteEsquema.ToDataTable
        vlDataTable.Columns.Add("Clave", GetType(String))
        vlDataTable.Columns.Add("Nombre", GetType(String))
        grClienteEsquema.DataSource = vlDataTable
        grClienteEsquema.DataMember = "ClienteEsquema"

        'Tab 2
        gbClienteDomicilio.Enabled = False
        btCLDEliminar.Enabled = False

        'Tab 3
        vlDataTable = vcClienteMensaje.Tabla.Recuperar("ClienteClave=''")
        vlDataTable.Columns.Add("Numero", GetType(Integer))
        vlDataTable.Columns.Add("MDBMensajeTipo", GetType(Integer))
        vlDataTable.Columns.Add("Descripcion", GetType(String))
        grClienteMensaje.DataSource = vlDataTable
        grClienteMensaje.DataMember = "ClienteMensaje"
        btCLMEliminar.Enabled = False

        'Tab 4
        grClientePago.DataSource = vcCliente.ClientePago.ToDataTable
        grClientePago.DataMember = "ClientePago"
        btCLPEliminar.Enabled = False

        grCLIFormaVenta.DataSource = vcCliente.CLIFormaVenta.ToDataTable
        grCLIFormaVenta.DataMember = "CLIFormaVenta"
        btCFVEliminar.Enabled = False
        btCFVHistorico.Enabled = False

        'Tab 5
        ebFechaFactura.Value = Date.MaxValue.Date
        btCPRHistorico.Enabled = False

        'tab 6
        Dim dtTablaTemp As DataTable = vcImpuesto.Tabla.RecuperarTabla("ImpuestoClave=''")
        dtTablaTemp.TableName = "CLINoDesImp"
        grDesgloseImpuesto.DataSource = dtTablaTemp
        grDesgloseImpuesto.DataMember = "CLINoDesImp"
        btCLPEliminar.Enabled = False

        chbDesgloseImpuesto_CheckedChanged(Nothing, Nothing)

        Dim dtConfig As DataTable = vcCliente.CLIConfNumCta.ToDataTable()
        dtConfig.Columns.Add("Seleccionado", GetType(Boolean))
        For Each drConfig As DataRow In dtConfig.Rows
            drConfig("Seleccionado") = drConfig("Seleccion")
        Next
        grCLIConfNumCta.DataSource = dtConfig
        grCLIConfNumCta.DataMember = "CLIConfNumCta"

        vcHuboCambios = False
        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function Consultar(ByRef prCliente As ERMCLILOG.cCliente, ByVal pvMUsuarioId As String) As Boolean
        Dim vlDataTable As DataTable

        vcMODO = eModo.Leer
        vcCliente = prCliente
        vcMUsuarioId = pvMUsuarioId


        Call LlenarValoresIniciales()

        'Tab 1
        ebClienteClave.Text = vcCliente.Clave
        ccFechaRegistroSistema.Value = vcCliente.FechaRegistroSistema
        cbTipoEstado.SelectedValue = vcCliente.TipoEstado
        ebIdElectronico.Text = vcCliente.IdElectronico
        ebNombreCorto.Text = vcCliente.NombreCorto
        ebRazonSocial.Text = vcCliente.RazonSocial
        cbTipoFiscal.SelectedValue = vcCliente.TipoFiscal
        cbTipoImpuesto.SelectedValue = vcCliente.TipoImpuesto
        ebIdFiscal.Text = vcCliente.IdFiscal
        'se retorna esta fecha para indicar que el valor e null
        If vcCliente.FechaNacimiento = "01/01/1900" Then
            ccFechaNacimiento.Value = Now.ToShortDateString
        Else
            ccFechaNacimiento.Value = vcCliente.FechaNacimiento
        End If
        chbDesgloseImpuesto.Checked = vcCliente.DesgloseImpuesto
        chbPrestamo.Checked = vcCliente.Prestamo
        Me.chbExclusividad.Checked = vcCliente.Exclusividad
        ' se retorna esta fecha para infdicar que el valor es null
        If vcCliente.VigExclusividad = "01/01/1900" Then
            ebVigExclusividad.Value = Now.ToShortDateString
        Else
            ebVigExclusividad.Value = vcCliente.VigExclusividad
        End If
        If chbExclusividad.Checked = True Then
            ebVigExclusividad.Enabled = True
        Else
            ebVigExclusividad.Enabled = False
        End If

        chbActualizaSaldoCheque.Checked = vcCliente.ActualizaSaldoCheque
        chbVencimientoVenta.Checked = vcCliente.VencimientoVenta
        If chbVencimientoVenta.Checked = True Then
            ebDiasVencimiento.Enabled = True
        Else
            ebDiasVencimiento.Enabled = False
        End If
        ebDiasVencimiento.Value = vcCliente.DiasVencimiento

        ebLimiteCreditoDinero.Value = vcCliente.LimiteCreditoDinero
        ebLimiteDescuento.Value = vcCliente.LimiteDescuento / 100
        ebNombreContacto.Text = vcCliente.NombreContacto
        ebTelefonoContacto.Text = vcCliente.TelefonoContacto
        ebCorreoElectronico.Text = vcCliente.CorreoElectronico
        chbExigirOrden.Checked = vcCliente.ExigirOrdenCompra
        chbCriterioCredito.Checked = vcCliente.CriterioCredito
        chbImprimirPagare.Checked = vcCliente.ImprimirPagare
        chbCapturaDatosFacturacion.Checked = vcCliente.CapturaDatosFacturacion
        'ebClienteClave.Enabled = False

        vlDataTable = vcCliente.ClienteEsquema.ToDataTable
        vlDataTable.Columns.Add("Clave", GetType(String))
        vlDataTable.Columns.Add("Nombre", GetType(String))
        If vlDataTable.Rows.Count = 0 Then
            btCLEEliminar.Enabled = False
        End If
        For Each vlDataRow As DataRow In vlDataTable.Rows
            Dim vlESQDataTable As DataTable
            Dim vlESQDataRow As DataRow

            vlESQDataTable = vcEsquema.Tabla.RecuperarTabla("EsquemaId='" + vlDataRow!EsquemaId + "'")
            If vlESQDataTable.Rows.Count = 0 Then
                MsgBox(vcMensaje.RecuperarDescripcion("E0013"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                Exit Function
            End If
            vlESQDataRow = vlESQDataTable.Rows(0)
            vlDataRow!Clave = vlESQDataRow!Clave
            vlDataRow!Nombre = vlESQDataRow!Nombre
        Next
        grClienteEsquema.DataSource = vlDataTable
        grClienteEsquema.DataMember = "ClienteEsquema"

        'Tab 2
        If vcCliente.ClienteDomicilio.Conteo > 0 Then
            sbClienteDomicilio.Maximum = vcCliente.ClienteDomicilio.Conteo - 1
            Call CLDLeerActual()
        Else
            gbClienteDomicilio.Enabled = False
            btCLDEliminar.Enabled = False
        End If

        'Tab 3
        vlDataTable = vcClienteMensaje.Tabla.Recuperar("ClienteClave='" + lbGeneral.ValidaFormatoSQLString(vcCliente.ClienteClave) + "'")
        vlDataTable.Columns.Add("Numero", GetType(Integer))
        vlDataTable.Columns.Add("MDBMensajeTipo", GetType(Integer))
        vlDataTable.Columns.Add("Descripcion", GetType(String))
        If vlDataTable.Rows.Count = 0 Then
            btCLMEliminar.Enabled = False
        End If
        For Each vlDataRow As DataRow In vlDataTable.Rows
            Dim vlMMSDataTable As DataTable
            Dim vlMMSDataRow As DataRow

            vlMMSDataTable = vcMDBMensaje.Tabla.Recuperar("MDBMensajeId='" + lbGeneral.ValidaFormatoSQLString(vlDataRow!MDBMensajeId) + "'")
            'If vlMMSDataTable.Rows.Count = 0 Then
            '    MsgBox(vcMensaje.RecuperarDescripcion("E0013"))
            '    Exit Function
            'End If
            vlMMSDataRow = vlMMSDataTable.Rows(0)
            vlDataRow!Numero = vlMMSDataRow!Numero
            vlDataRow!MDBMensajeTipo = vlMMSDataRow!MDBMensajeTipo
            vlDataRow!Descripcion = vlMMSDataRow!Descripcion
        Next
        grClienteMensaje.DataSource = vlDataTable
        grClienteMensaje.DataMember = "ClienteMensaje"

        'Tab 4
        grClientePago.DataSource = vcCliente.ClientePago.ToDataTable
        grClientePago.DataMember = "ClientePago"
        If vcCliente.ClientePago.Conteo = 0 Then
            btCLPEliminar.Enabled = False
        End If

        grCLIFormaVenta.DataSource = vcCliente.CLIFormaVenta.ToDataTable
        grCLIFormaVenta.DataMember = "CLIFormaVenta"
        If vcCliente.CLIFormaVenta.Conteo = 0 Then
            btCFVEliminar.Enabled = False
            btCFVHistorico.Enabled = False
        End If

        'Tab 5
        ebSaldoEfectivo.Value = vcCliente.SaldoEfectivo
        'ebSaldoGarantia.Value = vcCliente.SaldoGarantia
        'ebSaldoPrestamo.Value = vcCliente.SaldoPrestamo
        ebFechaFactura.Value = vcCliente.FechaFactura
        Me.ebSaldoProducto.Value = vcCliente.SaldoProducto

        Dim lsQuery As String
        lsQuery = "SELECT     PPC.ProductoClave as ProductoDetClave, PR.NombreLargo, PPC.Saldo AS Saldo, PPC.ClienteClave " & _
        "from ProductoPrestamoCli AS PPC " & _
        "INNER JOIN Producto AS PR ON PR.ProductoClave = PPC.ProductoClave " & _
        "WHERE PPC.Saldo <> 0 AND (PPC.ClienteClave = '" & lbGeneral.ValidaFormatoSQLString(vcCliente.ClienteClave) & "') "
        vlDataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(lsQuery)
        grClienteProducto.DataSource = vlDataTable

        vlDataTable = vcCliente.CLINoDesImp.ToDataTable
        vlDataTable.Columns.Add("Nombre", GetType(String))
        vlDataTable.Columns.Add("Abreviatura", GetType(String))
        If vlDataTable.Rows.Count = 0 Then
            btCNDIEliminar.Enabled = False
        End If
        For Each vlDataRow As DataRow In vlDataTable.Rows
            Dim vlIMPDataTable As DataTable
            Dim vlIMPDataRow As DataRow

            vlIMPDataTable = vcImpuesto.Tabla.RecuperarTabla("ImpuestoClave='" + vlDataRow!ImpuestoClave + "'")
            If vlIMPDataTable.Rows.Count = 0 Then
                MsgBox(vcMensaje.RecuperarDescripcion("E0013"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                Exit Function
            End If
            vlIMPDataRow = vlIMPDataTable.Rows(0)
            vlDataRow!Nombre = vlIMPDataRow!Nombre
            vlDataRow!Abreviatura = vlIMPDataRow!Abreviatura
        Next
        grDesgloseImpuesto.DataSource = vlDataTable
        grDesgloseImpuesto.DataMember = "CLINoDesImp"


        vcHuboCambios = False



        For Each tabs As Control In TabControl1.Controls

            For Each ctrls As Control In tabs.Controls
                ctrls.Enabled = False
            Next

        Next
        Me.Text = vcMensaje.RecuperarDescripcion("xconsultar") + " " + vcMensaje.RecuperarDescripcion("ERMCLIESC_NGeneral")

        BtAceptar.Visible = False
        BtCancelar.Text = vcMensaje.RecuperarDescripcion("BTRegresar")
        BtCancelar.Icon = BtAceptar.Icon

        Me.ShowDialog()


    End Function
    Public Function MODIFICAR(ByRef prCliente As ERMCLILOG.cCliente, ByVal pvMUsuarioId As String) As Boolean
        Dim vlDataTable As DataTable

        vcMODO = eModo.Modificar
        vcCliente = prCliente
        vcMUsuarioId = pvMUsuarioId

        Me.Text = vcMensaje.RecuperarDescripcion("ERMCLIESC_MGeneralM")

        Call LlenarValoresIniciales()

        'Tab 1
        ebClienteClave.Text = vcCliente.Clave
        ccFechaRegistroSistema.Value = vcCliente.FechaRegistroSistema
        cbTipoEstado.SelectedValue = vcCliente.TipoEstado
        nEstadoInicial = vcCliente.TipoEstado
        ebIdElectronico.Text = vcCliente.IdElectronico
        ebNombreCorto.Text = vcCliente.NombreCorto
        ebRazonSocial.Text = vcCliente.RazonSocial
        cbTipoFiscal.SelectedValue = vcCliente.TipoFiscal
        cbTipoImpuesto.SelectedValue = vcCliente.TipoImpuesto
        ebIdFiscal.Text = vcCliente.IdFiscal
        'se retorna esta fecha para indicar que el valor e null
        If vcCliente.FechaNacimiento = "01/01/1900" Then
            ccFechaNacimiento.Value = Now.ToShortDateString
        Else
            ccFechaNacimiento.Value = vcCliente.FechaNacimiento
        End If
        chbDesgloseImpuesto.Checked = vcCliente.DesgloseImpuesto
        chbDesgloseImpuesto_CheckedChanged(Nothing, Nothing)
        chbPrestamo.Checked = vcCliente.Prestamo
        Me.chbExclusividad.Checked = vcCliente.Exclusividad
        ' se retorna esta fecha para infdicar que el valor es null
        If vcCliente.VigExclusividad = "01/01/1900" Then
            ebVigExclusividad.Value = Now.ToShortDateString
        Else
            ebVigExclusividad.Value = vcCliente.VigExclusividad
        End If
        If chbExclusividad.Checked = True Then
            ebVigExclusividad.Enabled = True
        Else
            ebVigExclusividad.Enabled = False
        End If

        chbActualizaSaldoCheque.Checked = vcCliente.ActualizaSaldoCheque
        chbVencimientoVenta.Checked = vcCliente.VencimientoVenta
        If chbVencimientoVenta.Checked = True Then
            ebDiasVencimiento.Enabled = True
        Else
            ebDiasVencimiento.Enabled = False
        End If
        ebDiasVencimiento.Value = vcCliente.DiasVencimiento

        ebLimiteCreditoDinero.Value = vcCliente.LimiteCreditoDinero
        ebLimiteDescuento.Value = vcCliente.LimiteDescuento / 100
        ebNombreContacto.Text = vcCliente.NombreContacto
        ebTelefonoContacto.Text = vcCliente.TelefonoContacto
        ebCorreoElectronico.Text = vcCliente.CorreoElectronico
        chbExigirOrden.Checked = vcCliente.ExigirOrdenCompra
        chbCriterioCredito.Checked = vcCliente.CriterioCredito
        chbImprimirPagare.Checked = vcCliente.ImprimirPagare
        chbCapturaDatosFacturacion.Checked = vcCliente.CapturaDatosFacturacion
        vlDataTable = vcCliente.ClienteEsquema.ToDataTable

        vlDataTable.Columns.Add("Clave", GetType(String))
        vlDataTable.Columns.Add("Nombre", GetType(String))
        If vlDataTable.Rows.Count = 0 Then
            btCLEEliminar.Enabled = False
        End If
        For Each vlDataRow As DataRow In vlDataTable.Rows
            Dim vlESQDataTable As DataTable
            Dim vlESQDataRow As DataRow

            vlESQDataTable = vcEsquema.Tabla.RecuperarTabla("EsquemaId='" + vlDataRow!EsquemaId + "'")
            If vlESQDataTable.Rows.Count = 0 Then
                MsgBox(vcMensaje.RecuperarDescripcion("E0013"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                Exit Function
            End If
            vlESQDataRow = vlESQDataTable.Rows(0)
            vlDataRow!Clave = vlESQDataRow!Clave
            vlDataRow!Nombre = vlESQDataRow!Nombre
        Next
        grClienteEsquema.DataSource = vlDataTable
        grClienteEsquema.DataMember = "ClienteEsquema"

        'Tab 2
        If vcCliente.ClienteDomicilio.Conteo > 0 Then
            sbClienteDomicilio.Maximum = vcCliente.ClienteDomicilio.Conteo - 1
            Call CLDLeerActual()
        Else
            gbClienteDomicilio.Enabled = False
            btCLDEliminar.Enabled = False
        End If

        'Tab 3
        vlDataTable = vcClienteMensaje.Tabla.Recuperar("ClienteClave='" + lbGeneral.ValidaFormatoSQLString(vcCliente.ClienteClave) + "'")
        vlDataTable.Columns.Add("Numero", GetType(Integer))
        vlDataTable.Columns.Add("MDBMensajeTipo", GetType(Integer))
        vlDataTable.Columns.Add("Descripcion", GetType(String))
        If vlDataTable.Rows.Count = 0 Then
            btCLMEliminar.Enabled = False
        End If
        For Each vlDataRow As DataRow In vlDataTable.Rows
            Dim vlMMSDataTable As DataTable
            Dim vlMMSDataRow As DataRow

            vlMMSDataTable = vcMDBMensaje.Tabla.Recuperar("MDBMensajeId='" + lbGeneral.ValidaFormatoSQLString(vlDataRow!MDBMensajeId) + "'")
            'If vlMMSDataTable.Rows.Count = 0 Then
            '    MsgBox(vcMensaje.RecuperarDescripcion("E0013"))
            '    Exit Function
            'End If
            vlMMSDataRow = vlMMSDataTable.Rows(0)
            vlDataRow!Numero = vlMMSDataRow!Numero
            vlDataRow!MDBMensajeTipo = vlMMSDataRow!MDBMensajeTipo
            vlDataRow!Descripcion = vlMMSDataRow!Descripcion
        Next
        grClienteMensaje.DataSource = vlDataTable
        grClienteMensaje.DataMember = "ClienteMensaje"

        'Tab 4
        grClientePago.DataSource = vcCliente.ClientePago.ToDataTable
        grClientePago.DataMember = "ClientePago"
        If vcCliente.ClientePago.Conteo = 0 Then
            btCLPEliminar.Enabled = False
        End If

        grCLIFormaVenta.DataSource = vcCliente.CLIFormaVenta.ToDataTable
        grCLIFormaVenta.DataMember = "CLIFormaVenta"
        If vcCliente.CLIFormaVenta.Conteo = 0 Then
            btCFVEliminar.Enabled = False
            btCFVHistorico.Enabled = False
        End If

        'Tab 5
        ebSaldoEfectivo.Value = vcCliente.SaldoEfectivo
        'ebSaldoGarantia.Value = vcCliente.SaldoGarantia
        'ebSaldoPrestamo.Value = vcCliente.SaldoPrestamo
        ebFechaFactura.Value = vcCliente.FechaFactura
        Me.ebSaldoProducto.Value = vcCliente.SaldoProducto

        Dim lsQuery As String
        lsQuery = "SELECT     PPC.ProductoClave as ProductoDetClave, PR.NombreLargo, PPC.Saldo AS Saldo, PPC.ClienteClave " & _
        "from ProductoPrestamoCli AS PPC " & _
        "INNER JOIN Producto AS PR ON PR.ProductoClave = PPC.ProductoClave " & _
        "WHERE PPC.Saldo <> 0 AND (PPC.ClienteClave = '" & lbGeneral.ValidaFormatoSQLString(vcCliente.ClienteClave) & "') "
        vlDataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(lsQuery)
        grClienteProducto.DataSource = vlDataTable


        'TAB(6)
        vlDataTable = vcCliente.CLINoDesImp.ToDataTable
        vlDataTable.Columns.Add("Nombre", GetType(String))
        vlDataTable.Columns.Add("Abreviatura", GetType(String))
        If vlDataTable.Rows.Count = 0 Then
            btCNDIEliminar.Enabled = False
        End If
        For Each vlDataRow As DataRow In vlDataTable.Rows
            Dim vlIMPDataTable As DataTable
            Dim vlIMPDataRow As DataRow

            vlIMPDataTable = vcImpuesto.Tabla.RecuperarTabla("ImpuestoClave='" + vlDataRow!ImpuestoClave + "'")
            If vlIMPDataTable.Rows.Count = 0 Then
                MsgBox(vcMensaje.RecuperarDescripcion("E0013"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                Exit Function
            End If
            vlIMPDataRow = vlIMPDataTable.Rows(0)
            vlDataRow!Nombre = vlIMPDataRow!Nombre
            vlDataRow!Abreviatura = vlIMPDataRow!Abreviatura
        Next
        grDesgloseImpuesto.DataSource = vlDataTable
        grDesgloseImpuesto.DataMember = "CLINoDesImp"

        Dim dtConfig As DataTable = vcCliente.CLIConfNumCta.ToDataTable()
        dtConfig.Columns.Add("Seleccionado", GetType(Boolean))
        For Each drConfig As DataRow In dtConfig.Rows
            drConfig("Seleccionado") = drConfig("Seleccion")
        Next
        grCLIConfNumCta.DataSource = dtConfig
        grCLIConfNumCta.DataMember = "CLIConfNumCta"

        vcHuboCambios = False
        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return True
        Else
            Return False
        End If
    End Function

    'Private Sub ebIdFiscal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ebIdFiscal.KeyDown
    '    Dim sCadena As String = Me.ebIdFiscal.Text.Replace("-", "") & e.KeyCode
    '    If sCadena.Length >= 14 Then
    '        e.Handled = True
    '        MsgBox(vcMensaje.RecuperarDescripcion("E0718").Replace("$0$", Me.lbIdFiscal.Text).Replace("$1$", "14"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
    '    End If
    'End Sub

    'Private Sub ebIdFiscal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ebIdFiscal.KeyPress
    '    Dim sCadena As String = Me.ebIdFiscal.Text.Replace("-", "") & e.KeyChar
    '    If sCadena.Length > 14 Then
    '        e.Handled = True
    '        MsgBox(vcMensaje.RecuperarDescripcion("E0718").Replace("$0$", Me.lbIdFiscal.Text).Replace("$1$", "14"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
    '    End If
    'End Sub

    Private Sub Controles_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipoImpuesto.SelectedValueChanged, ebLimiteCreditoDinero.ValueChanged, ccFechaRegistroSistema.ValueChanged, cbTipoFiscal.SelectedValueChanged, cbTipoEstado.SelectedValueChanged, ebTelefonoContacto.TextChanged, ebNombreContacto.TextChanged, ebRazonSocial.TextChanged, ebNombreCorto.TextChanged, ebIdElectronico.TextChanged, ebClienteClave.TextChanged, ccFechaNacimiento.ValueChanged, ebLimiteDescuento.ValueChanged, chbPrestamo.CheckStateChanged, chbActualizaSaldoCheque.CheckStateChanged, chbVencimientoVenta.CheckStateChanged, ebDiasVencimiento.ValueChanged, chbExclusividad.CheckStateChanged, cbTipo.SelectedValueChanged
        vcHuboCambios = True
        'If (vcTipoIniciarVisita = 2 Or vcTipoIniciarVisita = 3) And cbTipo.SelectedValue = 2 Then
        '    ebCoordenadaX.Enabled = True
        '    ebCoordenadaY.Enabled = True
        'Else
        '    ebCoordenadaX.Enabled = False
        '    ebCoordenadaY.Enabled = False
        '    ebCoordenadaX.Text = Nothing
        '    ebCoordenadaY.Text = Nothing
        'End If
        'If vcCLDModo = eModo.Leer Then
        '    vcCLDModo = eModo.Modificar
        'End If
    End Sub

    Private Sub grClienteEsquema_BackgroundImageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grClienteEsquema.BackgroundImageChanged

    End Sub

    Private Sub Grids_CellValueChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grClienteEsquema.CellValueChanged, grFrecuencia.CellValueChanged, grClientePago.CellValueChanged, grClienteProducto.CellValueChanged
        vcHuboCambios = True

    End Sub

    Dim sCadIdFiscal As String = ""
    Private Sub ebIdFiscal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebIdFiscal.TextChanged
        Dim sCadena As String = Me.ebIdFiscal.Text.Replace("-", "")
        If sCadena.Length >= 14 Then
            Me.ebIdFiscal.Text = sCadIdFiscal
            MsgBox(vcMensaje.RecuperarDescripcion("E0718").Replace("$0$", Me.lbIdFiscal.Text).Replace("$1$", "14"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
        Else
            sCadIdFiscal = Me.ebIdFiscal.Text
        End If
    End Sub

    Private Sub ValidarCampos(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipoImpuesto.Validated, ebLimiteCreditoDinero.Validated, ccFechaRegistroSistema.Validated, cbTipoFiscal.Validated, cbTipoEstado.Validated, ebTelefonoContacto.Validated, ebNombreContacto.Validated, ebIdFiscal.Validated, ebRazonSocial.Validated, ebNombreCorto.Validated, ebIdElectronico.Validated, ebClienteClave.Validated, ccFechaNacimiento.Validated, ebLimiteDescuento.Validated, chbPrestamo.Validated, chbActualizaSaldoCheque.Validated, chbVencimientoVenta.Validated, ebDiasVencimiento.Validated, chbExclusividad.Validated, ebCorreoElectronico.Validated, ebCodigoPostal.Validated, ebPoblacion.Validated, ebEntidad.Validated, ebCalle.Validated, ebPais.Validated, ebCoordenadaX.Validated, ebCoordenadaY.Validated
        Call ValidarCampos(sender)
    End Sub

    Private Sub ValidarCampos(ByVal pvSender As System.Object)
        Dim vlCampo As String

        vlCampo = pvSender.tag
        Select Case pvSender.name.ToString()
            Case "ebCorreoElectronico"
                If ebCorreoElectronico.Text <> "" Then
                    vcCliente.CorreoElectronico = ebCorreoElectronico.Text
                    Dim oReg As New Regex("^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")
                    If Not oReg.IsMatch(ebCorreoElectronico.Text) Then
                        epErrores.SetError(pvSender, vcMensaje.RecuperarDescripcion("E0593", New String() {lbCorreoElectronico.Text, "XX@XX.XX"}))
                        Exit Sub
                    End If
                End If
            Case "ebClienteClave"
                vcCliente.Clave = ebClienteClave.Text
                If ebClienteClave.Text <> "" Then
                    If vcCliente.Tabla.Recuperar("ClienteClave<>'" + lbGeneral.ValidaFormatoSQLString(vcCliente.ClienteClave) + "' and Clave='" & lbGeneral.ValidaFormatoSQLString(vcCliente.Clave) & "'").Rows.Count > 0 Then
                        epErrores.SetError(pvSender, vcMensaje.RecuperarDescripcion("BE0002"))
                        Exit Sub
                    End If
                    If vcCliente.Clave.ToUpper.StartsWith("NUEVO") Then
                        epErrores.SetError(pvSender, vcMensaje.RecuperarDescripcion("E0736"))
                        Exit Sub
                    End If
                End If
            Case "ebCalle"

                If cbTipo.SelectedValue = 1 Then
                    If ebCalle.Text = "" Then
                        Dim msgError As String = vcMensaje.RecuperarDescripcion("BE0001")
                        epErrores.SetError(pvSender, msgError.Replace("$0$", pvSender.tag))
                        Me.vcDireccionValidada = False
                        Exit Sub
                    Else
                        epErrores.SetError(pvSender, "")
                        Me.vcDireccionValidada = True
                        Exit Sub
                    End If
                Else
                    epErrores.SetError(pvSender, "")
                    Me.vcDireccionValidada = True
                    Exit Sub
                End If
            Case "ebCodigoPostal"
                If cbTipo.SelectedValue = 1 Then
                    If ebCodigoPostal.Text = "" Then
                        Dim msgError As String = vcMensaje.RecuperarDescripcion("BE0001")
                        epErrores.SetError(pvSender, msgError.Replace("$0$", pvSender.tag))
                        Me.vcDireccionValidada = False
                        Exit Sub
                    Else
                        epErrores.SetError(pvSender, "")
                        Me.vcDireccionValidada = True
                        Exit Sub
                    End If
                Else
                    epErrores.SetError(pvSender, "")
                    Me.vcDireccionValidada = True
                    Exit Sub
                End If
            Case "ebPoblacion"
                If cbTipo.SelectedValue = 1 Then
                    If ebPoblacion.Text = "" Then
                        Dim msgError As String = vcMensaje.RecuperarDescripcion("BE0001")
                        epErrores.SetError(pvSender, msgError.Replace("$0$", pvSender.tag))
                        Me.vcDireccionValidada = False
                        Exit Sub
                    Else
                        epErrores.SetError(pvSender, "")
                        Me.vcDireccionValidada = True
                        Exit Sub
                    End If
                Else
                    epErrores.SetError(pvSender, "")
                    Me.vcDireccionValidada = True
                    Exit Sub
                End If
            Case "ebEntidad"
                If cbTipo.SelectedValue = 1 Then
                    If ebEntidad.Text = "" Then
                        Dim msgError As String = vcMensaje.RecuperarDescripcion("BE0001")
                        epErrores.SetError(pvSender, msgError.Replace("$0$", pvSender.tag))
                        Me.vcDireccionValidada = False
                        Exit Sub
                    Else
                        epErrores.SetError(pvSender, "")
                        Me.vcDireccionValidada = True
                        Exit Sub
                    End If
                Else
                    epErrores.SetError(pvSender, "")
                    Me.vcDireccionValidada = True
                    Exit Sub
                End If
            Case "ebPais"
                If ebPais.Text = "" Then
                    Dim msgError As String = vcMensaje.RecuperarDescripcion("BE0001")
                    epErrores.SetError(pvSender, msgError.Replace("$0$", pvSender.tag))
                    Me.vcDireccionValidada = False
                    Exit Sub
                Else
                    epErrores.SetError(pvSender, "")
                    Me.vcDireccionValidada = True
                    Exit Sub
                End If
            Case "ebCoordenadaX"
                If ebCoordenadaX.Text <> "" AndAlso Not IsNumeric(ebCoordenadaX.Text) Then
                    epErrores.SetError(ebCoordenadaX, vcMensaje.RecuperarDescripcion("E0553"))
                    Me.vcDireccionValidada = False
                    Exit Sub
                Else
                    epErrores.SetError(ebCoordenadaX, "")
                    Me.vcDireccionValidada = True
                    Exit Sub
                End If
            Case "ebCoordenadaY"
                If ebCoordenadaY.Text <> "" AndAlso Not IsNumeric(ebCoordenadaY.Text) Then
                    epErrores.SetError(ebCoordenadaY, vcMensaje.RecuperarDescripcion("E0553"))
                    Me.vcDireccionValidada = False
                    Exit Sub
                Else
                    epErrores.SetError(ebCoordenadaY, "")
                    Me.vcDireccionValidada = True
                    Exit Sub
                End If

            Case "ccFechaRegistroSistema"
                If IsNothing(ccFechaRegistroSistema.Value) = False Then
                    vcCliente.FechaRegistroSistema = ccFechaRegistroSistema.Value
                End If
            Case "cbTipoEstado"
                If IsNothing(cbTipoEstado.SelectedValue) = False Then
                    vcCliente.TipoEstado = cbTipoEstado.SelectedValue
                End If
            Case "ebIdElectronico"
                vcCliente.IdElectronico = ebIdElectronico.Text

            Case "ebNombreCorto"
                vcCliente.NombreCorto = ebNombreCorto.Text
            Case "ebRazonSocial"
                vcCliente.RazonSocial = ebRazonSocial.Text
            Case "cbTipoFiscal"
                If IsNothing(cbTipoFiscal.SelectedValue) = False Then
                    vcCliente.TipoFiscal = cbTipoFiscal.SelectedValue
                End If
            Case "ebIdFiscal"
                vcCliente.IdFiscal = ebIdFiscal.Text.Replace("-", "")
                If ebIdFiscal.Text = "" Then
                    Dim msgError As String = vcMensaje.RecuperarDescripcion("BE0001")
                    epErrores.SetError(pvSender, msgError.Replace("$0$", lbIdFiscal.Text))
                    Exit Sub
                Else
                    Dim sCadena As String = Me.ebIdFiscal.Text.Replace("-", "")
                    If sCadena.Length >= 14 Then
                        epErrores.SetError(pvSender, vcMensaje.RecuperarDescripcion("E0718").Replace("$0$", Me.lbIdFiscal.Text).Replace("$1$", "14"))
                        Exit Sub
                    End If

                    epErrores.SetError(pvSender, "")
                    Exit Sub
                End If
            Case "ccFechaNacimiento"
                If IsNothing(ccFechaNacimiento.Value) = False Then
                    vcCliente.FechaNacimiento = ccFechaNacimiento.Value
                End If
            Case "ebLimiteCreditoDinero"
                vcCliente.LimiteCreditoDinero = ebLimiteCreditoDinero.Value
            Case "chbPrestamo"
                vcCliente.Prestamo = chbPrestamo.Checked
            Case "chbExclusividad"
                vcCliente.Exclusividad = chbExclusividad.Checked
            Case "ebVigExclusividad"
                vcCliente.VigExclusividad = ebVigExclusividad.Value
            Case "chbActualizaSaldoCheque"
                vcCliente.ActualizaSaldoCheque = chbActualizaSaldoCheque.Checked
            Case "chbVencimientoVenta"
                vcCliente.VencimientoVenta = chbVencimientoVenta.Checked
            Case "ebDiasVencimiento"
                vcCliente.DiasVencimiento = ebDiasVencimiento.Value
            Case "cbTipoImpuesto"
                If IsNothing(cbTipoImpuesto.SelectedValue) = False Then
                    vcCliente.TipoImpuesto = cbTipoImpuesto.SelectedValue
                End If
            Case "ebLimiteDescuento"
                vcCliente.LimiteDescuento = ebLimiteDescuento.Value * 100
            Case "ebNombreContacto"
                vcCliente.NombreContacto = ebNombreContacto.Text
            Case "ebTelefonoContacto"
                vcCliente.TelefonoContacto = ebTelefonoContacto.Text
            Case "ebSaldoEfectivo"
                vcCliente.SaldoEfectivo = ebSaldoEfectivo.Text
                'Case "ebSaldoGarantia"
                '    vcCliente.SaldoGarantia = ebSaldoGarantia.Text
            Case "ebSaldoPrestamo"
                ' vcCliente.SaldoPrestamo = ebSaldoPrestamo.Text
            Case "ebFechaFactura"
                vcCliente.FechaFactura = ebFechaFactura.Value
        End Select

        Try
            vcCliente.ValidarCampos(New String() {vlCampo})
        Catch ex As LbControlError.cError
            epErrores.SetError(pvSender, ex.Mensaje)
            Exit Sub
        End Try
        epErrores.SetError(pvSender, "")
    End Sub

    Private Sub LlenarNulos(ByRef prGrid As Janus.Windows.GridEX.GridEX)
        For Each vlCelda As Janus.Windows.GridEX.GridEXCell In prGrid.GetRow.Cells

            If IsDBNull(vlCelda.Value) Or IsNothing(vlCelda.Value) Then
                Select Case prGrid.Name
                    Case "grClienteEsquema"
                        Select Case vlCelda.Column.Key
                            Case "Clave"
                                vlCelda.Value = ""
                            Case "TipoEstado"
                                vlCelda.Value = 1
                        End Select
                    Case "grClienteMensaje"
                        Select Case vlCelda.Column.Key
                            Case "TipoEstado"
                                vlCelda.Value = 1
                        End Select
                    Case "grClientePago"
                        Select Case vlCelda.Column.Key
                            Case "Tipo"
                                vlCelda.Value = 1
                            Case "TipoBanco"
                                vlCelda.Value = 0
                            Case "Cuenta"
                                vlCelda.Value = ""
                            Case "TipoEstado"
                                vlCelda.Value = 1
                        End Select
                    Case "grCLIFormaVenta"
                        Select Case vlCelda.Column.Key
                            Case "CFVTipo"
                                vlCelda.Value = 1
                            Case "LimiteCredito"
                                vlCelda.Value = 0
                            Case "DiasCredito"
                                vlCelda.Value = 0
                            Case "Inicial"
                                vlCelda.Value = False
                            Case "CapturaDias"
                                vlCelda.Value = False
                            Case "ValidaLimite"
                                vlCelda.Value = False
                            Case "ValidaPago"
                                vlCelda.Value = False
                            Case "Estado"
                                vlCelda.Value = 1
                        End Select
                End Select
            End If
        Next
    End Sub
#End Region

#Region " Tab 1 General "
    'Private Sub MGENERAL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    If chbExclusividad.Checked = True Then
    '        ebVigExclusividad.Enabled = True
    '    Else
    '        ebVigExclusividad.Enabled = False
    '    End If
    'End Sub

    Private Sub chbExclusividad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbExclusividad.CheckedChanged
        If chbExclusividad.Checked = True Then
            ebVigExclusividad.Enabled = True
            ebVigExclusividad.Value = Now.ToShortDateString
        Else
            ebVigExclusividad.Enabled = False
        End If
    End Sub

    Private Sub chbVencimientoVenta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVencimientoVenta.CheckedChanged
        If chbVencimientoVenta.Checked = True Then
            ebDiasVencimiento.Enabled = True
        Else
            ebDiasVencimiento.Enabled = False
            ebDiasVencimiento.Value = 0
            ValidarCampos(ebDiasVencimiento, New System.EventArgs)
        End If
    End Sub

    Private Sub btCLECrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCLECrear.Click
        grClienteEsquema.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
        grClienteEsquema.MoveToNewRecord()
        grClienteEsquema.Col = 1
        'Call LlenarNulos(grClienteEsquema)
        'vcCliente.ClienteEsquema.EsquemaId = grClienteEsquema.GetValue("EsquemaId")
        'vcCliente.ClienteEsquema.TipoEstado = grClienteEsquema.GetValue("TipoEstado")
        'vcCliente.ClienteEsquema.MUsuarioId = vcMUsuarioId
        ''Try
        ''    vcCliente.ClienteEsquema.Insertar(New String() {"EsquemaId", "TipoEstado", "MUsuarioId"})
        ''Catch ex As LbControlError.cError
        ''    ex.Mostrar()
        ''    grClienteEsquema.Col = 1
        ''    'e.Cancel = True
        ''End Try
        'vcEsquemaId = grClienteEsquema.GetValue("EsquemaId")
        grClienteEsquema.Focus()
        'grClienteEsquema.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
    End Sub

    Private Sub btCLEEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCLEEliminar.Click
        If (grClienteEsquema.RowCount = 0) Then
            Exit Sub
        End If

        grClienteEsquema.CancelCurrentEdit()
        If (grClienteEsquema.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
            Call DeshabilitaCrear(grClienteEsquema)
        ElseIf (grClienteEsquema.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
            If Not grClienteEsquema.GetValue("EsquemaId") Is DBNull.Value AndAlso Not vcCliente.ClienteEsquema(grClienteEsquema.GetValue("EsquemaId")) Is Nothing Then
                'Dim cCEsq As ERMCLILOG.cClienteEsquema
                If CType(vcCliente.ClienteEsquema(grClienteEsquema.GetValue("EsquemaId")), ERMCLILOG.cClienteEsquema).cEstado = ERMCLILOG.eEstado.Nuevo Then
                    vcCliente.ClienteEsquema(CType(grClienteEsquema.GetValue("EsquemaId"), String)).Eliminar()
                    grClienteEsquema.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    grClienteEsquema.Delete()
                    grClienteEsquema.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False

                Else

                    'vcCliente.ClienteEsquema(CType(grClienteEsquema.GetValue("EsquemaId"), String)).TipoEstado = 0
                    'cCEsq.TipoEstado = 0
                    'cCEsq.Grabar()
                    'grClienteEsquema.SetValue("TipoEstado", 0)
                    'grClienteEsquema.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    'grClienteEsquema.Delete()
                    'grClienteEsquema.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                End If
            Else
                grClienteEsquema.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                grClienteEsquema.Delete()
                grClienteEsquema.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub btESQBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btESQBuscar.Click
        Dim vlEsquemaIndex As New ERMESQESC.IGeneral(True, , "Tipo=1 AND TipoEstado = 1")
        Dim vlArrayList As ArrayList
        Dim vlDataTable As DataTable
        vcHuboCambios = True
        vlEsquemaIndex.ShowDialog()
        vlArrayList = vlEsquemaIndex.Seleccion
        If IsNothing(vlArrayList) = False Then
            vlDataTable = grClienteEsquema.DataSource
            For Each vlEsquema As DataRow In vlArrayList
                If vlDataTable.Select("EsquemaID='" + vlEsquema!EsquemaID + "'").Length = 0 Then
                    grClienteEsquema.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    grClienteEsquema.MoveToNewRecord()
                    grClienteEsquema.GetRow.Cells("Clave").Value = vlEsquema!Clave
                    ObtenerEsquema(vlEsquema!Clave)
                    grClienteEsquema.GetRow.Cells("TipoEstado").Value = 1
                    grClienteEsquema.UpdateData()
                End If
            Next
            grClienteEsquema.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
            grClienteEsquema.Focus()
        End If
    End Sub

    Private Sub DeshabilitaCrear(ByRef peGridEx As Janus.Windows.GridEX.GridEX)
        If peGridEx.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True Then
            If (peGridEx.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Or peGridEx.DataChanged = False) Then
                peGridEx.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                If (peGridEx.Row = 0) Then
                    peGridEx.MoveLast()
                End If
            End If
        End If
    End Sub

    Private Sub grClienteEsquema_AddingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grClienteEsquema.AddingRecord
        'Paula: checar porque se puso esta linea
        'If Not grClienteEsquema.GetValue("EsquemaId") Is Nothing AndAlso Not grClienteEsquema.GetValue("EsquemaId") Is DBNull.Value AndAlso Not grClienteEsquema.GetValue("EsquemaId") = "" Then
        Call LlenarNulos(grClienteEsquema)
        vcCliente.ClienteEsquema.EsquemaId = grClienteEsquema.GetValue("EsquemaId")
        vcCliente.ClienteEsquema.TipoEstado = grClienteEsquema.GetValue("TipoEstado")
        vcCliente.ClienteEsquema.MUsuarioId = vcMUsuarioId
        Try
            vcCliente.ClienteEsquema.Insertar(New String() {"EsquemaId", "TipoEstado", "MUsuarioId"})
        Catch ex As LbControlError.cError
            ex.Mostrar()
            e.Cancel = True
            grClienteEsquema.Col = 1

        End Try
        vcEsquemaId = grClienteEsquema.GetValue("EsquemaId")
        'End If

    End Sub

    Private Sub grClienteEsquema_FirstChange(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles grClienteEsquema.FirstChange
        vcHuboCambios = True
        If (grClienteEsquema.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
            btCLEEliminar.Enabled = True
            btCLECrear.Enabled = True

            If Not IsNothing(grClienteEsquema.CurrentColumn) Then
                If grClienteEsquema.CurrentColumn.Key <> "TipoEstado" Then
                    grClienteEsquema.GetRow.Cells("TipoEstado").Value = 1
                End If
            End If
        End If
    End Sub

    Private Sub grClienteEsquema_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grClienteEsquema.Leave
        Call DeshabilitaCrear(grClienteEsquema)
    End Sub

    Private Sub grClienteEsquema_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grClienteEsquema.RecordAdded
        If (grClienteEsquema.Focused = False) Then
            Call DeshabilitaCrear(grClienteEsquema)
        End If
    End Sub

    Private Sub grClienteEsquema_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grClienteEsquema.SelectionChanged
        Select Case (vcMODO)
            Case eModo.Crear
                grClienteEsquema.RootTable.Columns("Clave").EditType = Janus.Windows.GridEX.EditType.TextBox
            Case eModo.Modificar
                If Not (grClienteEsquema.GetRow Is Nothing) Then
                    If (grClienteEsquema.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                        grClienteEsquema.RootTable.Columns("Clave").EditType = Janus.Windows.GridEX.EditType.TextBox
                    Else
                        If grClienteEsquema.GetRow.DataRow.Row.RowState = DataRowState.Added Then
                            grClienteEsquema.RootTable.Columns("Clave").EditType = Janus.Windows.GridEX.EditType.TextBox
                        Else
                            grClienteEsquema.RootTable.Columns("Clave").EditType = Janus.Windows.GridEX.EditType.NoEdit
                        End If
                    End If
                End If
        End Select




        If grClienteEsquema.RowCount > 0 And (vcMODO = eModo.Crear Or vcMODO = eModo.Modificar) Then
            If Not grClienteEsquema.GetRow Is Nothing Then
                If (grClienteEsquema.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                    btCLEEliminar.Enabled = False
                Else
                    If grClienteEsquema.GetRow.DataRow.Row.RowState = DataRowState.Added Then
                        btCLEEliminar.Enabled = True
                    Else
                        btCLEEliminar.Enabled = False
                    End If
                End If
            End If
        Else
            btCLEEliminar.Enabled = False
        End If
        If Not grClienteEsquema.GetValue("EsquemaId") Is Nothing AndAlso Not grClienteEsquema.GetValue("EsquemaId") Is DBNull.Value Then
            vcEsquemaId = grClienteEsquema.GetValue("EsquemaId")
        End If
    End Sub

    Private Sub ObtenerEsquema(ByVal pvClave As String)
        Dim vlDataTable As New DataTable

        If IsNothing(pvClave) = True Then
            grClienteEsquema.GetRow.Cells("EsquemaId").Value = ""
            grClienteEsquema.GetRow.Cells("Nombre").Value = ""
            Exit Sub
        End If

        vlDataTable = vcEsquema.Tabla.RecuperarTabla("Clave='" + lbGeneral.ValidaFormatoSQLString(pvClave) + "' AND Tipo=1")
        If vlDataTable.Rows.Count = 0 Then
            Throw New LbControlError.cError("E0013")
            Exit Sub
        ElseIf vlDataTable.Rows(0)!TipoEstado = 0 Then
            Throw New LbControlError.cError("E0576")
            Exit Sub
        End If
        grClienteEsquema.GetRow.Cells("EsquemaId").Value = vlDataTable.Rows(0)!EsquemaId
        grClienteEsquema.GetRow.Cells("Nombre").Value = vlDataTable.Rows(0)!Nombre
    End Sub

    Private Sub grClienteEsquema_UpdatingCell(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs) Handles grClienteEsquema.UpdatingCell
        Dim vlDataTable As New DataTable

        If e.Column.Key = "Clave" Then
            If IsNothing(e.Value) Or IsDBNull(e.Value) Then
                e.Value = ""
            End If
            If e.Value = "" Then
                grClienteEsquema.GetRow.Cells("EsquemaId").Value = ""
                'grClienteEsquema.GetRow.Cells("TipoEstado").Value = ""
                grClienteEsquema.GetRow.Cells("Nombre").Value = ""
                Exit Sub
            End If
            If IsNothing(e.InitialValue) = False Then
                If LCase(e.Value) = LCase(e.InitialValue) Then
                    Exit Sub
                End If
            End If
            For Each vlDataRow As Janus.Windows.GridEX.GridEXRow In grClienteEsquema.GetRows
                If LCase(e.InitialValue) = LCase(e.Value) Then
                    MsgBox(vcMensaje.RecuperarDescripcion("BE0002"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                    e.Value = e.InitialValue
                    e.Cancel = True
                    Exit Sub
                End If
            Next
            Try
                ObtenerEsquema(e.Value)
            Catch ex As LbControlError.cError
                ex.Mostrar()
                e.Value = e.InitialValue
                e.Cancel = True
                Exit Sub
            End Try
        End If
        'If e.Column.Key = "TipoEstado" Then
        '    Dim ccEsq As ERMCLILOG.cClienteEsquema = vcCliente.ClienteEsquema(grClienteEsquema.GetValue("EsquemaId"))
        '    ccEsq.TipoEstado = e.Value
        '    ccEsq.Grabar()
        'End If
    End Sub

    Private Sub grClienteEsquema_UpdatingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grClienteEsquema.UpdatingRecord
        Call LlenarNulos(grClienteEsquema)

        If grClienteEsquema.GetValue("EsquemaId") Is DBNull.Value OrElse grClienteEsquema.GetValue("EsquemaId") = "" Then
            MsgBox(vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion("ESQClave")}), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
            e.Cancel = True
            Exit Sub
        End If

        vcCliente.ClienteEsquema(vcEsquemaId).EsquemaId = grClienteEsquema.GetValue("EsquemaId")
        vcCliente.ClienteEsquema(vcEsquemaId).TipoEstado = grClienteEsquema.GetValue("TipoEstado")
        vcCliente.ClienteEsquema(grClienteEsquema.GetValue("EsquemaId")).MUsuarioId = vcMUsuarioId
        Try
            vcCliente.ClienteEsquema(grClienteEsquema.GetValue("EsquemaId")).ValidarCampos(New String() {"EsquemaId", "TipoEstado", "MUsuarioId"})

        Catch ex As LbControlError.cError
            ex.Mostrar()
            e.Cancel = True
        End Try
        vcEsquemaId = grClienteEsquema.GetValue("EsquemaId")
    End Sub

    Private Sub grClienteEsquema_CancelingRowEdit(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowActionCancelEventArgs) Handles grClienteEsquema.CancelingRowEdit
        e.Cancel = True
    End Sub
#End Region

#Region " Tab 2 Domicilio "

    Private Sub btCLDCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCLDCrear.Click
        Dim vlKeyGen As New lbGeneral.cKeyGen

        sbClienteDomicilio.Maximum = vcCliente.ClienteDomicilio.Conteo
        sbClienteDomicilio.Value = vcCliente.ClienteDomicilio.Conteo
        grFrecuencia.Enabled = False
        gbClienteDomicilio.Enabled = True
        vcCLDModo = eModo.Crear
        vcCliente.ClienteDomicilio.ClienteDomicilioId = lbGeneral.cKeyGen.KEYGEN(1)
        ebClienteDomicilioId.Text = vcCliente.ClienteDomicilio.ClienteDomicilioId
        cbTipo.SelectedValue = 1
        ebCalle.Text = Nothing
        ebNumero.Text = Nothing
        ebCodigoPostal.Text = Nothing
        ebColonia.Text = Nothing
        ebPoblacion.Text = Nothing
        ebEntidad.Text = Nothing
        ebPais.Text = Nothing
        ebReferencia.Text = Nothing
        ebNumInt.Text = Nothing
        ebLocalidad.Text = Nothing
        ebCoordenadaX.Text = Nothing
        ebCoordenadaY.Text = Nothing
        cbTipo.Enabled = True
        btCLDEliminar.Enabled = True
        cbTipo.Focus()
    End Sub

    Private Sub btCLDEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCLDEliminar.Click
        LimpiarErrores()
        If vcCLDModo <> eModo.Crear Then
            vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).Eliminar()
        End If
        If vcHSFrecuencia.ContainsKey(ebClienteDomicilioId.Text) Then
            vcHSFrecuencia.Remove(ebClienteDomicilioId.Text)
        End If
        If vcCliente.ClienteDomicilio.Conteo > 0 Then
            sbClienteDomicilio.Maximum = vcCliente.ClienteDomicilio.Conteo - 1
            If sbClienteDomicilio.Value = vcCliente.ClienteDomicilio.Conteo And sbClienteDomicilio.Value > 0 Then
                sbClienteDomicilio.Value = sbClienteDomicilio.Value - 1
            End If
        Else
            sbClienteDomicilio.Maximum = 0
            sbClienteDomicilio.Value = 0
        End If
        Call CLDLeerActual()
    End Sub

    Private Sub gbClienteDomicilio_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles gbClienteDomicilio.Validating
        If vcCLDModo = eModo.Leer Then
            Exit Sub
        End If

        Try
            If ebCoordenadaX.Text <> "" And Not IsNumeric(ebCoordenadaX.Text) Then
                Throw New LbControlError.cError("E0553", , "CoordenadaX")
            End If
            If ebCoordenadaY.Text <> "" And Not IsNumeric(ebCoordenadaY.Text) Then
                Throw New LbControlError.cError("E0553", , "CoordenadaY")
            End If
        Catch ex As LbControlError.cError
            Select Case ex.Source
                Case "CoordenadaX"
                    ebCoordenadaX.Focus()
                Case "CoordenadaY"
                    ebCoordenadaY.Focus()
            End Select
            e.Cancel = True
            ex.Mostrar()
            Exit Sub
        End Try



        vcCLDIndex = sbClienteDomicilio.Value
        If vcCLDModo = eModo.Crear Then
            If (IsDBNull(cbTipo.SelectedValue) = False) Then
                vcCliente.ClienteDomicilio.Tipo = cbTipo.SelectedValue
            End If
            vcCliente.ClienteDomicilio.Calle = ebCalle.Text
            vcCliente.ClienteDomicilio.Numero = ebNumero.Text
            vcCliente.ClienteDomicilio.CodigoPostal = ebCodigoPostal.Text
            vcCliente.ClienteDomicilio.Colonia = ebColonia.Text
            vcCliente.ClienteDomicilio.Poblacion = ebPoblacion.Text
            vcCliente.ClienteDomicilio.Entidad = ebEntidad.Text
            vcCliente.ClienteDomicilio.Localidad = ebLocalidad.Text
            vcCliente.ClienteDomicilio.ReferenciaDom = ebReferencia.Text
            vcCliente.ClienteDomicilio.NumInt = ebNumInt.Text

            vcCliente.ClienteDomicilio.Pais = ebPais.Text
            vcCliente.ClienteDomicilio.CoordenadaX = IIf(ebCoordenadaX.Text = "", Nothing, ebCoordenadaX.Text)
            vcCliente.ClienteDomicilio.CoordenadaY = IIf(ebCoordenadaY.Text = "", Nothing, ebCoordenadaY.Text)
            vcCliente.ClienteDomicilio.MUsuarioId = vcMUsuarioId
        Else
            vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).Tipo = cbTipo.SelectedValue
            vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).Calle = ebCalle.Text
            vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).Numero = ebNumero.Text
            vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).CodigoPostal = ebCodigoPostal.Text
            vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).Colonia = ebColonia.Text
            vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).Poblacion = ebPoblacion.Text
            vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).Entidad = ebEntidad.Text
            vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).Pais = ebPais.Text
            vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).MUsuarioId = vcMUsuarioId
            vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).Localidad = ebLocalidad.Text
            vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).ReferenciaDom = ebReferencia.Text
            vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).NumInt = ebNumInt.Text
            vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).CoordenadaX = IIf(ebCoordenadaX.Text = "", Nothing, ebCoordenadaX.Text)
            vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).CoordenadaY = IIf(ebCoordenadaY.Text = "", Nothing, ebCoordenadaY.Text)
        End If
        Try
            If vcCLDModo = eModo.Crear Then
                '--Fix antes de insertar verificaos no este dado de alta un cliente domicilio de tipo fiscal

                If Me.vcDireccionValidada Then
                    vcCliente.ClienteDomicilio.Insertar()
                Else
                    btCLDEliminar_Click(Nothing, Nothing)
                End If
            Else
                vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).ValidarCampos()
            End If
        Catch ex As LbControlError.cError
            Select Case ex.Source
                Case "Tipo"
                    cbTipo.Focus()
                Case "Calle"
                    ebCalle.Focus()
                Case "Numero"
                    ebNumero.Focus()
                Case "CodigoPostal"
                    ebCodigoPostal.Focus()
                Case "Colonia"
                    ebColonia.Focus()
                Case "Poblacion"
                    ebPoblacion.Focus()
                Case "Entidad"
                    ebEntidad.Focus()
                Case "Pais"
                    ebPais.Focus()
                Case "CoordenadaX"
                    ebCoordenadaX.Focus()
                Case "CoordenadaY"
                    ebCoordenadaY.Focus()
            End Select
            e.Cancel = True
            ex.Mostrar()
            Exit Sub
        End Try

        If cbTipo.SelectedValue = 2 Then
            If vcHSFrecuencia.ContainsKey(ebClienteDomicilioId.Text) Then
                vcHSFrecuencia(ebClienteDomicilioId.Text) = grFrecuencia.DataSource
            Else
                vcHSFrecuencia.Add(ebClienteDomicilioId.Text, grFrecuencia.DataSource)
            End If
        End If
        vcCLDModo = eModo.Leer
    End Sub

    Private Sub CLDLeerActual()
        Dim vlSECDataTable As DataTable
        Dim vlFREDataTable As DataTable
        Dim vlFiltro As String = String.Empty
        Dim vlDataTable As DataTable

        vcCLDModo = eModo.Leer
        If vcCliente.ClienteDomicilio.Conteo = 0 Then
            gbClienteDomicilio.Enabled = False
            btCLDEliminar.Enabled = False
            ebClienteDomicilioId.Text = Nothing
            cbTipo.SelectedValue = Nothing
            ebCalle.Text = Nothing
            ebNumero.Text = Nothing
            ebCodigoPostal.Text = Nothing
            ebColonia.Text = Nothing
            ebPoblacion.Text = Nothing
            ebEntidad.Text = Nothing
            ebPais.Text = Nothing
            ebReferencia.Text = Nothing
            ebLocalidad.Text = Nothing
            ebNumInt.Text = Nothing
            ebCoordenadaX.Text = Nothing
            ebCoordenadaY.Text = Nothing
            Exit Sub
        End If
        If vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).cEstado = ERMCLILOG.eEstado.Nuevo Then
            cbTipo.Enabled = True
            btCLDEliminar.Enabled = True
        Else
            cbTipo.Enabled = False
            btCLDEliminar.Enabled = False
        End If
        ebClienteDomicilioId.Text = vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).ClienteDomicilioId
        cbTipo.SelectedValue = vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).Tipo
        ebCalle.Text = vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).Calle
        ebNumero.Text = vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).Numero
        ebCodigoPostal.Text = vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).CodigoPostal
        ebColonia.Text = vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).Colonia
        ebPoblacion.Text = vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).Poblacion
        ebEntidad.Text = vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).Entidad
        ebPais.Text = vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).Pais
        ebVigExclusividad.Value = vcCliente.VigExclusividad
        ebReferencia.Text = vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).ReferenciaDom
        ebLocalidad.Text = vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).Localidad
        ebNumInt.Text = vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).NumInt

        'If (vcTipoIniciarVisita = 2 Or vcTipoIniciarVisita = 3) And cbTipo.SelectedValue = 2 Then
        ebCoordenadaX.Text = vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).CoordenadaX
        ebCoordenadaY.Text = vcCliente.ClienteDomicilio(sbClienteDomicilio.Value).CoordenadaY
        '    ebCoordenadaX.Enabled = True
        '    ebCoordenadaY.Enabled = True
        'Else
        '    ebCoordenadaX.Enabled = False
        '    ebCoordenadaY.Enabled = False
        'End If

        If cbTipo.SelectedValue = 2 Then
            grFrecuencia.Enabled = True
            If vcHSFrecuencia.ContainsKey(ebClienteDomicilioId.Text) Then
                grFrecuencia.DataSource = vcHSFrecuencia(ebClienteDomicilioId.Text)
                grFrecuencia.DataMember = "Frecuencia"
            Else
                vlSECDataTable = vcSecuencia.Tabla.Recuperar("ClienteClave='" + lbGeneral.ValidaFormatoSQLString(vcCliente.ClienteClave) + "' AND ClienteDomicilioId='" & lbGeneral.ValidaFormatoSQLString(ebClienteDomicilioId.Text) & "'")
                If vlSECDataTable.Rows.Count > 0 Then
                    vlFREDataTable = vcFrecuencia.Tabla.Recuperar("FrecuenciaClave =''", "FrecuenciaClave,Descripcion,Tipo,FechaInicio,FechaFinal, (CASE Tipo WHEN 1 THEN (select Descripcion from vavdescripcion where VARCodigo = 'FREDIA' and VADTipoLenguaje = (select top 1 TipoLenguaje from conhist order by MFechaHora desc) and VAVCLave = UnidadInicio) ELSE Cast(UnidadInicio as varchar(8)) END ) as UnidadInicio,UnidadInicio as UnidadInicio1,Repeticion,Intervalo, MFechaHora, MUsuarioId")
                    Call FREAgregarColumnas(vlFREDataTable)
                    For Each vlSECDataRow As DataRow In vlSECDataTable.Rows
                        Dim vlFREDataTable1 As DataTable
                        Dim vlDataRow As DataRow

                        vlFiltro = vlFiltro + "'" + lbGeneral.ValidaFormatoSQLString(vlSECDataRow!FrecuenciaClave) + "',"

                        vlFREDataTable1 = vcFrecuencia.Tabla.Recuperar("FrecuenciaClave ='" & lbGeneral.ValidaFormatoSQLString(vlSECDataRow!FrecuenciaClave) & "'", "FrecuenciaClave,Descripcion,Tipo,FechaInicio,FechaFinal, (CASE Tipo WHEN 1 THEN (select Descripcion from vavdescripcion where VARCodigo = 'FREDIA' and VADTipoLenguaje = (select top 1 TipoLenguaje from conhist order by MFechaHora desc) and VAVCLave = UnidadInicio) ELSE Cast(UnidadInicio as varchar(8)) END ) as UnidadInicio,UnidadInicio as UnidadInicio1,Repeticion,Intervalo, MFechaHora, MUsuarioId")
                        Call FREAgregarColumnas(vlFREDataTable1)
                        vlDataRow = vlFREDataTable1.Rows(0)
                        vlDataRow!SECId = vlSECDataRow!SECId
                        vlDataRow!Estado = eModo.Leer
                        vlDataRow!Selector = True
                        vlDataRow!RUTClave = vlSECDataRow!RUTClave
                        vlFREDataTable.ImportRow(vlDataRow)
                    Next
                    vlFiltro = vlFiltro.Substring(0, vlFiltro.Length - 1)

                    'vlFREDataTable = vcFrecuencia.Tabla.Recuperar("FrecuenciaClave in (" + vlFiltro + ")")
                    'Call FREAgregarColumnas(vlFREDataTable)
                    'For Each vlDataRow As DataRow In vlFREDataTable.Rows
                    '    vldatarow!Estado = eModo.Leer
                    '    vldatarow!Selector = True
                    'Next

                    vlDataTable = vcFrecuencia.Tabla.Recuperar("FrecuenciaClave not in (" + vlFiltro + ") AND FechaFinal >= " & vcConexion.UniFechaSQL(vcConexion.ObtenerFecha, , "dd/MM/yyyy"), "FrecuenciaClave,Descripcion,Tipo,FechaInicio,FechaFinal, (CASE Tipo WHEN 1 THEN (select Descripcion from vavdescripcion where VARCodigo = 'FREDIA' and VADTipoLenguaje = (select top 1 TipoLenguaje from conhist order by MFechaHora desc) and VAVCLave = UnidadInicio) ELSE Cast(UnidadInicio as varchar(8)) END ) as UnidadInicio,UnidadInicio as UnidadInicio1,Repeticion,Intervalo, MFechaHora, MUsuarioId")

                    Call FREAgregarColumnas(vlDataTable)
                    For Each vlDataRow As DataRow In vlDataTable.Rows
                        vlFREDataTable.ImportRow(vlDataRow)
                    Next
                Else
                    vlFREDataTable = vcFrecuencia.Tabla.Recuperar("")
                    Call FREAgregarColumnas(vlFREDataTable)
                End If
                grFrecuencia.DataSource = vlFREDataTable
                grFrecuencia.DataMember = "Frecuencia"
                vcHSFrecuencia.Add(ebClienteDomicilioId.Text, grFrecuencia.DataSource)
            End If
        Else
            grFrecuencia.DataSource = Nothing
            grFrecuencia.DataMember = Nothing
            grFrecuencia.Enabled = False
        End If
    End Sub

    Private Sub sbClienteDomicilio_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles sbClienteDomicilio.Scroll
        If Validate() = True Then
            If e.Type = ScrollEventType.EndScroll Then
                Call CLDLeerActual()
            End If
        Else
            e.NewValue = vcCLDIndex
        End If
    End Sub

    Private Sub cbTipo_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTipo.SelectedValueChanged
        Dim vldatatable As DataTable

        If vcCLDModo = eModo.Leer Then
            vcCLDModo = eModo.Modificar
        End If

        If cbTipo.SelectedValue = 2 Then
            If vcHSFrecuencia.ContainsKey(ebClienteDomicilioId.Text) Then
                grFrecuencia.DataSource = vcHSFrecuencia(ebClienteDomicilioId.Text)
            Else
                vldatatable = vcFrecuencia.Tabla.Recuperar(" FechaFinal >= " & vcConexion.UniFechaSQL(vcConexion.ObtenerFecha, , "dd/MM/yyyy"))
                Call FREAgregarColumnas(vldatatable)
                grFrecuencia.DataSource = vldatatable
                grFrecuencia.DataMember = "Frecuencia"
                grFrecuencia.Enabled = True
            End If
        Else
            grFrecuencia.DataSource = Nothing
            grFrecuencia.DataMember = Nothing
            grFrecuencia.Enabled = False
        End If
    End Sub

    Private Sub control_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebCalle.TextChanged, ebNumero.TextChanged, ebNumInt.TextChanged, ebColonia.TextChanged, ebCodigoPostal.TextChanged, ebReferencia.TextChanged, ebLocalidad.TextChanged, ebPoblacion.TextChanged, ebEntidad.TextChanged, ebPais.TextChanged, ebCoordenadaX.TextChanged, ebCoordenadaY.TextChanged
        If vcCLDModo = eModo.Leer Then
            vcCLDModo = eModo.Modificar
        End If
        vcHuboCambios = True
    End Sub

    'Private Sub ebCalle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebCalle.TextChanged
    '    If vcCLDModo = eModo.Leer Then
    '        vcCLDModo = eModo.Modificar
    '    End If
    'End Sub

    'Private Sub ebNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebNumero.TextChanged
    '    If vcCLDModo = eModo.Leer Then
    '        vcCLDModo = eModo.Modificar
    '    End If
    'End Sub

    'Private Sub ebCodigoPostal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebCodigoPostal.TextChanged
    '    If vcCLDModo = eModo.Leer Then
    '        vcCLDModo = eModo.Modificar
    '    End If
    'End Sub

    'Private Sub ebColonia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebColonia.TextChanged
    '    If vcCLDModo = eModo.Leer Then
    '        vcCLDModo = eModo.Modificar
    '    End If
    'End Sub

    'Private Sub ebPoblacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebPoblacion.TextChanged
    '    If vcCLDModo = eModo.Leer Then
    '        vcCLDModo = eModo.Modificar
    '    End If
    'End Sub

    'Private Sub ebEntidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebEntidad.TextChanged
    '    If vcCLDModo = eModo.Leer Then
    '        vcCLDModo = eModo.Modificar
    '    End If
    'End Sub

    'Private Sub ebPais_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebPais.TextChanged
    '    If vcCLDModo = eModo.Leer Then
    '        vcCLDModo = eModo.Modificar
    '    End If
    'End Sub

    'Private Sub ebCoordenada_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If vcCLDModo = eModo.Leer Then
    '        vcCLDModo = eModo.Modificar
    '    End If
    'End Sub

    Private Sub btCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCopiar.Click
        Dim vlCopiar As Integer

        vlCopiar = cbCopiar.SelectedValue
        For i As Integer = 0 To vcCliente.ClienteDomicilio.Conteo - 1
            If (vcCliente.ClienteDomicilio(i).Tipo = vlCopiar) Then
                ebCalle.Text = vcCliente.ClienteDomicilio(i).Calle
                ebNumero.Text = vcCliente.ClienteDomicilio(i).Numero
                ebCodigoPostal.Text = vcCliente.ClienteDomicilio(i).CodigoPostal
                ebColonia.Text = vcCliente.ClienteDomicilio(i).Colonia
                ebPoblacion.Text = vcCliente.ClienteDomicilio(i).Poblacion
                ebEntidad.Text = vcCliente.ClienteDomicilio(i).Entidad
                ebPais.Text = vcCliente.ClienteDomicilio(i).Pais
                ebCoordenadaX.Text = vcCliente.ClienteDomicilio(i).CoordenadaX
                ebCoordenadaY.Text = vcCliente.ClienteDomicilio(i).CoordenadaY

                ebNumInt.Text = vcCliente.ClienteDomicilio(i).NumInt
                ebReferencia.Text = vcCliente.ClienteDomicilio(i).ReferenciaDom
                ebLocalidad.Text = vcCliente.ClienteDomicilio(i).Localidad
                Exit For
            End If
        Next
    End Sub

    Private Sub FREAgregarColumnas(ByRef prDataTable As DataTable)
        Dim vlDataColumn As DataColumn

        vlDataColumn = New DataColumn("Estado")
        vlDataColumn.DefaultValue = 0
        vlDataColumn.DataType = GetType(Integer)
        prDataTable.Columns.Add(vlDataColumn)
        vlDataColumn = New DataColumn("Selector")
        vlDataColumn.DefaultValue = False
        vlDataColumn.DataType = GetType(Boolean)
        prDataTable.Columns.Add(vlDataColumn)
        vlDataColumn = New DataColumn("SECId")
        vlDataColumn.DefaultValue = ""
        vlDataColumn.DataType = GetType(String)
        prDataTable.Columns.Add(vlDataColumn)
        vlDataColumn = New DataColumn("ClienteDomicilioId")
        vlDataColumn.DefaultValue = ""
        vlDataColumn.DataType = GetType(String)
        prDataTable.Columns.Add(vlDataColumn)
        vlDataColumn = New DataColumn("RUTClave")
        vlDataColumn.DefaultValue = ""
        vlDataColumn.DataType = GetType(String)
        prDataTable.Columns.Add(vlDataColumn)


    End Sub
    Private Sub grFrecuencia_UpdatingCell(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs) Handles grFrecuencia.UpdatingCell
        If e.Column.Key = "Selector" And e.Value = True Then
            Select Case CType(grFrecuencia.GetRow.Cells("Estado").Value, eModo)
                Case 0
                    grFrecuencia.GetRow.Cells("Estado").Value = eModo.Crear
                Case eModo.Eliminar
                    grFrecuencia.GetRow.Cells("Estado").Value = eModo.Leer
            End Select
        End If

        If e.Column.Key = "Selector" And e.Value = False Then
            Select Case CType(grFrecuencia.GetRow.Cells("Estado").Value, eModo)
                Case eModo.Crear
                    grFrecuencia.GetRow.Cells("Estado").Value = 0
                Case eModo.Leer
                    grFrecuencia.GetRow.Cells("Estado").Value = eModo.Eliminar
            End Select
        End If

        If vcCLDModo = eModo.Leer Then
            vcCLDModo = eModo.Modificar
        End If
    End Sub
#End Region

#Region " Tab 3 Mensajes "
    Private Sub btMMEBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btMMEBuscar.Click
        Dim vlMMEIndice As New ERMMMEESC.IGeneral
        Dim vlMMEArrayList As New ArrayList
        Dim vlDataTable As DataTable
        vcHuboCambios = True
        vlMMEArrayList = vlMMEIndice.Seleccionar("MDBMensajeTipo <> 4 AND MDBMensajeTipo <> 1")
        If IsNothing(vlMMEArrayList) = False Then
            grClienteMensaje.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
            vlDataTable = grClienteMensaje.DataSource
            For Each vlMDBMensaje As ERMMMELOG.cMDBMensaje In vlMMEArrayList
                If vlDataTable.Select("MDBMensajeId='" + lbGeneral.ValidaFormatoSQLString(vlMDBMensaje.MDBMensajeID) + "'").Length = 0 Then
                    grClienteMensaje.MoveToNewRecord()
                    grClienteMensaje.GetRow.Cells("MDBMensajeId").Value = vlMDBMensaje.MDBMensajeID
                    grClienteMensaje.GetRow.Cells("Numero").Value = vlMDBMensaje.Numero
                    grClienteMensaje.GetRow.Cells("MDBMensajeTipo").Value = vlMDBMensaje.MDBMensajeTipo
                    grClienteMensaje.GetRow.Cells("Descripcion").Value = vlMDBMensaje.Descripcion
                    grClienteMensaje.GetRow.Cells("TipoEstado").Value = 1
                    grClienteMensaje.UpdateData()
                End If
            Next
            grClienteMensaje.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
            grClienteMensaje.Focus()
        End If
    End Sub

    Private Sub btCLMEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCLMEliminar.Click
        grClienteMensaje.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
        grClienteMensaje.Delete()
        grClienteMensaje.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
    End Sub

    Private Sub btMMENuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btMMENuevo.Click
        Dim vlFormaMDBMensaje As New ERMMMEESC.MGeneral
        Dim vlMDBMensaje As New ERMMMELOG.cMDBMensaje()
        vlFormaMDBMensaje.ListaExcluidos = New String() {"4", "1"}
        If vlFormaMDBMensaje.CrearDesdeCliente(vlMDBMensaje, vcMUsuarioId) Then
            grClienteMensaje.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
            grClienteMensaje.MoveToNewRecord()
            grClienteMensaje.GetRow.Cells("MDBMensajeId").Value = vlMDBMensaje.MDBMensajeID
            grClienteMensaje.GetRow.Cells("Numero").Value = vlMDBMensaje.Numero
            grClienteMensaje.GetRow.Cells("MDBMensajeTipo").Value = vlMDBMensaje.MDBMensajeTipo
            grClienteMensaje.GetRow.Cells("Descripcion").Value = vlMDBMensaje.Descripcion
            grClienteMensaje.GetRow.Cells("TipoEstado").Value = 1
            grClienteMensaje.UpdateData()
            grClienteMensaje.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
            grClienteMensaje.Focus()
        End If
    End Sub

    Private Sub grClienteMensaje_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If grClienteMensaje.RowCount > 0 And (vcMODO = eModo.Crear Or vcMODO = eModo.Modificar) Then
            If grClienteMensaje.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Then
                btCLMEliminar.Enabled = True
            Else
                If grClienteMensaje.GetRow.DataRow.Row.RowState = DataRowState.Added Then
                    btCLMEliminar.Enabled = True
                Else
                    btCLMEliminar.Enabled = False
                End If
            End If
        Else
            btCLMEliminar.Enabled = False
        End If
    End Sub

    Private Sub grClienteMensaje_UpdatingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Call LlenarNulos(grClienteMensaje)

    End Sub
#End Region

#Region " Tab 4 Condiciones de Venta "

#Region "Formas de Pago"
    Private Sub btCLPCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCLPCrear.Click
        grClientePago.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
        grClientePago.MoveToNewRecord()
        grClientePago.Col = 1
        grClientePago.Focus()
    End Sub

    Private Sub btCLPEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCLPEliminar.Click
        If (grClientePago.RowCount = 0) Then
            Exit Sub
        End If

        grClientePago.CancelCurrentEdit()
        If (grClientePago.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
            Call DeshabilitaCrear(grClientePago)
        ElseIf (grClientePago.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
            vcCliente.ClientePago(grClientePago.GetValue("ClientePagoId")).Eliminar()
            grClientePago.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
            grClientePago.Delete()
            grClientePago.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
        End If
    End Sub

    Private Sub grClientePago_FirstChange(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles grClientePago.FirstChange
        vcHuboCambios = True
        If (grClientePago.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then

            btCLPEliminar.Enabled = True
            btCLPCrear.Enabled = True
            If grClientePago.CurrentColumn.Key <> "Tipo" Then
                grClientePago.GetRow.Cells("Tipo").Value = 1
            End If
            If grClientePago.CurrentColumn.Key <> "TipoBanco" Then
                grClientePago.GetRow.Cells("TipoBanco").Value = 0
            End If
            If grClientePago.CurrentColumn.Key <> "TipoEstado" Then
                grClientePago.GetRow.Cells("TipoEstado").Value = 1
            End If
        End If
    End Sub

    Private Sub grClientePago_AddingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grClientePago.AddingRecord


        Call LlenarNulos(grClientePago)

        vcCliente.ClientePago.ClientePagoId = lbGeneral.cKeyGen.KEYGEN(1)
        grClientePago.GetRow.Cells("ClientePagoId").Value = vcCliente.ClientePago.ClientePagoId
        vcCliente.ClientePago.Tipo = grClientePago.GetValue("Tipo")
        vcCliente.ClientePago.Grupo = IIf(aValGrupoE.Contains(vcCliente.ClientePago.Tipo.ToString), "E", "C")
        vcCliente.ClientePago.TipoBanco = grClientePago.GetValue("TipoBanco")
        vcCliente.ClientePago.Cuenta = lbGeneral.ChkDbNull(grClientePago.GetValue("Cuenta"))
        vcCliente.ClientePago.TipoEstado = grClientePago.GetValue("TipoEstado")
        vcCliente.ClientePago.MUsuarioId = vcMUsuarioId
        Try
            vcCliente.ClientePago.Insertar()
        Catch ex As LbControlError.cError
            ex.Mostrar()
            e.Cancel = True
            Exit Sub
        End Try
    End Sub

    Private Sub grClientePago_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grClientePago.Leave
        Call DeshabilitaCrear(grClientePago)
    End Sub

    Private Sub grClientePago_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grClientePago.RecordAdded
        If (grClientePago.Focused = False) Then
            Call DeshabilitaCrear(grClientePago)
        End If
    End Sub

    Private Sub grClientePago_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grClientePago.SelectionChanged
        Select Case (vcMODO)
            Case eModo.Crear
                grClientePago.RootTable.Columns("Tipo").EditType = Janus.Windows.GridEX.EditType.DropDownList
            Case eModo.Modificar
                If Not (grClientePago.GetRow Is Nothing) Then
                    If (grClientePago.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                        grClientePago.RootTable.Columns("Tipo").EditType = Janus.Windows.GridEX.EditType.DropDownList
                    Else
                        If grClientePago.GetRow.DataRow.Row.RowState = DataRowState.Added Then
                            grClientePago.RootTable.Columns("Tipo").EditType = Janus.Windows.GridEX.EditType.DropDownList
                        Else
                            grClientePago.RootTable.Columns("Tipo").EditType = Janus.Windows.GridEX.EditType.NoEdit
                        End If
                    End If
                End If
        End Select



        If grClientePago.RowCount > 0 And (vcMODO = eModo.Crear Or vcMODO = eModo.Modificar) Then
            If Not grClientePago.GetRow Is Nothing Then
                If (grClientePago.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                    btCLPEliminar.Enabled = False
                Else
                    If grClientePago.GetRow.DataRow.Row.RowState = DataRowState.Added Then
                        btCLPEliminar.Enabled = True
                    Else
                        btCLPEliminar.Enabled = False
                    End If
                End If
            Else
                btCLPEliminar.Enabled = False
            End If
        Else
            btCLPEliminar.Enabled = False
        End If

    End Sub

    Private Sub grClientePago_UpdatingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grClientePago.UpdatingRecord
        Call LlenarNulos(grClientePago)
        If Not IsNothing(grClientePago.GetValue("ClientePagoId")) Then

            vcCliente.ClientePago(grClientePago.GetValue("ClientePagoId")).Tipo = grClientePago.GetValue("Tipo")
            vcCliente.ClientePago(grClientePago.GetValue("ClientePagoId")).Grupo = IIf(aValGrupoE.Contains(vcCliente.ClientePago(grClientePago.GetValue("ClientePagoId")).Tipo.ToString), "E", "C")
            vcCliente.ClientePago(grClientePago.GetValue("ClientePagoId")).TipoBanco = grClientePago.GetValue("TipoBanco")
            vcCliente.ClientePago(grClientePago.GetValue("ClientePagoId")).Cuenta = grClientePago.GetValue("Cuenta")
            vcCliente.ClientePago(grClientePago.GetValue("ClientePagoId")).TipoEstado = grClientePago.GetValue("TipoEstado")
            vcCliente.ClientePago(grClientePago.GetValue("ClientePagoId")).MUsuarioId = vcMUsuarioId
            Try
                vcCliente.ClientePago(grClientePago.GetValue("ClientePagoId")).ValidarCampos()
            Catch ex As LbControlError.cError
                ex.Mostrar()
                e.Cancel = True
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub grClientePago_CancelingRowEdit(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowActionCancelEventArgs) Handles grClientePago.CancelingRowEdit
        e.Cancel = True
    End Sub

    Private Sub grClientePago_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grClientePago.CurrentCellChanged
        Dim vlRegistro As Janus.Windows.GridEX.GridEXRow = grClientePago.GetRow
        If vlRegistro Is Nothing Then Exit Sub
        If aValGrupoE.Contains(vlRegistro.Cells("Tipo").Value.ToString) Then
            grClientePago.RootTable.Columns("Cuenta").EditType = Janus.Windows.GridEX.EditType.NoEdit
            grClientePago.RootTable.Columns("TipoBanco").EditType = Janus.Windows.GridEX.EditType.NoEdit
            grClientePago.GetRow.Cells("Cuenta").Value = ""
            grClientePago.GetRow.Cells("TipoBanco").Value = 0
        Else
            grClientePago.RootTable.Columns("Cuenta").EditType = Janus.Windows.GridEX.EditType.TextBox
            grClientePago.RootTable.Columns("TipoBanco").EditType = Janus.Windows.GridEX.EditType.DropDownList
        End If
    End Sub
#End Region

#Region "Formas de Venta"
    Private Sub btCFVCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCFVCrear.Click
        grCLIFormaVenta.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
        grCLIFormaVenta.MoveToNewRecord()
        grCLIFormaVenta.Col = 0
        grCLIFormaVenta.Focus()

        If grCLIFormaVenta.RowCount = 0 Then
            grCLIFormaVenta.RootTable.Columns("Inicial").EditType = Janus.Windows.GridEX.EditType.NoEdit
            grCLIFormaVenta.RootTable.Columns("Estado").EditType = Janus.Windows.GridEX.EditType.NoEdit
            grCLIFormaVenta.RootTable.Columns("ValidaLimite").EditType = Janus.Windows.GridEX.EditType.NoEdit
            grCLIFormaVenta.RootTable.Columns("ValidaPago").EditType = Janus.Windows.GridEX.EditType.NoEdit
        End If
    End Sub

    Private Sub btCFVEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCFVEliminar.Click
        If (grCLIFormaVenta.RowCount = 0) Then
            Exit Sub
        End If

        grCLIFormaVenta.CancelCurrentEdit()
        If (grCLIFormaVenta.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
            Call DeshabilitaCrear(grCLIFormaVenta)
        ElseIf (grCLIFormaVenta.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
            vcCliente.CLIFormaVenta(grCLIFormaVenta.GetValue("CFVTipo")).Eliminar()
            grCLIFormaVenta.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
            grCLIFormaVenta.Delete()
            grCLIFormaVenta.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
        End If
    End Sub

    Private Sub btCFVHistorico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCFVHistorico.Click
        Dim oHistorico As New DFormaVenta
        oHistorico.CONSULTAR(vcCliente.CLIFormaVenta(CType(grCLIFormaVenta.GetValue("CFVTipo"), Integer)))
    End Sub

    Private Sub grCLIFormaVenta_FirstChange(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles grCLIFormaVenta.FirstChange
        vcHuboCambios = True
        If (grCLIFormaVenta.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
            btCFVEliminar.Enabled = True
            btCFVCrear.Enabled = True
            If grCLIFormaVenta.CurrentColumn.Key <> "CFVTipo" Then
                grCLIFormaVenta.GetRow.Cells("CFVTipo").Value = 1
                grCLIFormaVenta.RootTable.Columns("ValidaPago").EditType = Janus.Windows.GridEX.EditType.CheckBox
            End If
            If grCLIFormaVenta.CurrentColumn.Key <> "Inicial" Then
                grCLIFormaVenta.GetRow.Cells("Inicial").Value = False
            End If
            If grCLIFormaVenta.CurrentColumn.Key <> "ValidaLimite" Then
                grCLIFormaVenta.GetRow.Cells("ValidaLimite").Value = False
            End If
            If grCLIFormaVenta.CurrentColumn.Key <> "ValidaPago" Then
                grCLIFormaVenta.GetRow.Cells("ValidaPago").Value = False
            End If
            If grCLIFormaVenta.CurrentColumn.Key <> "Estado" Then
                grCLIFormaVenta.GetRow.Cells("Estado").Value = 1
            End If
            If grCLIFormaVenta.RecordCount = 0 Then
                grCLIFormaVenta.GetRow.Cells("Inicial").Value = True
                grCLIFormaVenta.GetRow.Cells("Estado").Value = 1
            End If
        End If
    End Sub

    Private Sub grCLIFormaVenta_AddingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grCLIFormaVenta.AddingRecord
        Call LlenarNulos(grCLIFormaVenta)

        Dim lnIndexActualRow As Integer = grCLIFormaVenta.GetRow.RowIndex
        For Each vlDataRow As Janus.Windows.GridEX.GridEXRow In grCLIFormaVenta.GetRows
            If Not IsDBNull(vlDataRow.Cells("CFVTipo").Value) Then
                If vlDataRow.Cells("CFVTipo").Value = grCLIFormaVenta.GetValue("CFVTipo") And vlDataRow.RowIndex <> lnIndexActualRow Then
                    MsgBox(vcMensaje.RecuperarDescripcion("BE0002"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                    e.Cancel = True
                    Exit Sub
                End If
            End If

        Next

        If grCLIFormaVenta.GetValue("CFVTipo") = 2 And grCLIFormaVenta.GetValue("LimiteCredito") <= 0 Then
            'MsgBox(vcMensaje.RecuperarDescripcion("E0007"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
            MsgBox(vcMensaje.RecuperarDescripcion("E0334", New String() {vcMensaje.RecuperarDescripcion("CLILimiteCreditoDinero")}), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
            e.Cancel = True
            Exit Sub
        End If

        vcCliente.CLIFormaVenta.CFVTipo = grCLIFormaVenta.GetValue("CFVTipo")
        vcCliente.CLIFormaVenta.LimiteCredito = grCLIFormaVenta.GetValue("LimiteCredito")
        vcCliente.CLIFormaVenta.DiasCredito = grCLIFormaVenta.GetValue("DiasCredito")
        vcCliente.CLIFormaVenta.Inicial = grCLIFormaVenta.GetValue("Inicial")
        vcCliente.CLIFormaVenta.CapturaDias = grCLIFormaVenta.GetValue("CapturaDias")
        vcCliente.CLIFormaVenta.ValidaLimite = grCLIFormaVenta.GetValue("ValidaLimite")
        vcCliente.CLIFormaVenta.ValidaPago = grCLIFormaVenta.GetValue("ValidaPago")
        vcCliente.CLIFormaVenta.Estado = grCLIFormaVenta.GetValue("Estado")
        vcCliente.CLIFormaVenta.MUsuarioId = vcMUsuarioId
        Try
            vcCliente.CLIFormaVenta.Insertar()
        Catch ex As LbControlError.cError
            ex.Mostrar()
            e.Cancel = True
            Exit Sub
        End Try

        vcCFVTipo = grCLIFormaVenta.GetValue("CFVTipo")

        'Try
        '    Call ActualizarCFVHist()
        'Catch ex As LbControlError.cError
        '    ex.Mostrar()
        '    e.Cancel = True
        '    Exit Sub
        'End Try
    End Sub

    Private Sub grCLIFormaVenta_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grCLIFormaVenta.Leave
        Call DeshabilitaCrear(grCLIFormaVenta)
    End Sub

    Private Sub grCLIFormaVenta_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grCLIFormaVenta.RecordAdded
        If (grCLIFormaVenta.Focused = False) Then
            Call DeshabilitaCrear(grCLIFormaVenta)
        End If
    End Sub

    Private Sub grCLIFormaVenta_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grCLIFormaVenta.CellValueChanged
        Select Case e.Column.Key
            Case "Inicial"
                If vcActualizandoInicial Then Exit Sub
                If grCLIFormaVenta.GetValue("Inicial") = False Then
                    vcActualizandoInicial = True
                    grCLIFormaVenta.GetRow.Cells("Inicial").Value = True
                    vcActualizandoInicial = False
                Else
                    For Each ldr As Janus.Windows.GridEX.GridEXRow In grCLIFormaVenta.GetRows
                        If ldr.Cells("Inicial").Value = True And grCLIFormaVenta.GetRow.RowIndex <> ldr.RowIndex Then
                            vcActualizandoInicial = True
                            ldr.BeginEdit()
                            ldr.Cells("Inicial").Value = False
                            ldr.EndEdit()
                            vcCliente.CLIFormaVenta(CType(ldr.Cells("CFVTipo").Value, Integer)).Inicial = False
                            vcActualizandoInicial = False
                            Exit For
                        End If
                    Next
                    grCLIFormaVenta.RootTable.Columns("Estado").EditType = Janus.Windows.GridEX.EditType.NoEdit
                End If
            Case "Estado"
                If grCLIFormaVenta.GetValue("Estado") = 0 Then
                    grCLIFormaVenta.RootTable.Columns("Inicial").EditType = Janus.Windows.GridEX.EditType.NoEdit
                End If
            Case "CFVTipo"
                grCLIFormaVenta.RootTable.Columns("LimiteCredito").EditType = Janus.Windows.GridEX.EditType.NoEdit
                grCLIFormaVenta.RootTable.Columns("DiasCredito").EditType = Janus.Windows.GridEX.EditType.NoEdit
                grCLIFormaVenta.RootTable.Columns("CapturaDias").EditType = Janus.Windows.GridEX.EditType.NoEdit
                grCLIFormaVenta.RootTable.Columns("ValidaLimite").EditType = Janus.Windows.GridEX.EditType.NoEdit
                grCLIFormaVenta.RootTable.Columns("ValidaPago").EditType = Janus.Windows.GridEX.EditType.NoEdit
                If Not IsDBNull(grCLIFormaVenta.GetValue("CFVTipo")) Then
                    Select Case CType(grCLIFormaVenta.GetValue("CFVTipo"), Integer)
                        Case 1
                            grCLIFormaVenta.RootTable.Columns("ValidaPago").EditType = Janus.Windows.GridEX.EditType.CheckBox
                            grCLIFormaVenta.SetValue("LimiteCredito", 0)
                            grCLIFormaVenta.SetValue("DiasCredito", 0)
                            grCLIFormaVenta.SetValue("CapturaDias", False)
                            grCLIFormaVenta.SetValue("ValidaLimite", False)
                        Case 2
                            grCLIFormaVenta.RootTable.Columns("LimiteCredito").EditType = Janus.Windows.GridEX.EditType.TextBox
                            grCLIFormaVenta.RootTable.Columns("DiasCredito").EditType = Janus.Windows.GridEX.EditType.TextBox
                            grCLIFormaVenta.RootTable.Columns("CapturaDias").EditType = Janus.Windows.GridEX.EditType.CheckBox
                            grCLIFormaVenta.RootTable.Columns("ValidaLimite").EditType = Janus.Windows.GridEX.EditType.CheckBox
                            grCLIFormaVenta.SetValue("ValidaPago", False)
                    End Select
                End If
        End Select
        vcHuboCambios = True
    End Sub

    Private Sub grCLIFormaVenta_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grCLIFormaVenta.SelectionChanged
        Select Case (vcMODO)
            Case eModo.Crear
                grCLIFormaVenta.RootTable.Columns("CFVTipo").EditType = Janus.Windows.GridEX.EditType.DropDownList
            Case eModo.Modificar
                If Not (grCLIFormaVenta.GetRow Is Nothing) Then
                    If (grCLIFormaVenta.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                        grCLIFormaVenta.RootTable.Columns("CFVTipo").EditType = Janus.Windows.GridEX.EditType.DropDownList
                    Else
                        If grCLIFormaVenta.GetRow.DataRow.Row.RowState = DataRowState.Added Then
                            grCLIFormaVenta.RootTable.Columns("CFVTipo").EditType = Janus.Windows.GridEX.EditType.DropDownList
                        Else
                            grCLIFormaVenta.RootTable.Columns("CFVTipo").EditType = Janus.Windows.GridEX.EditType.NoEdit
                        End If
                    End If
                End If
        End Select

        If vcMODO = eModo.Crear Or vcMODO = eModo.Modificar Then
            If Not IsNothing(grCLIFormaVenta.GetRow) Then
                If Not IsDBNull(grCLIFormaVenta.GetValue("Estado")) Then
                    If Not String.IsNullOrEmpty(grCLIFormaVenta.GetValue("Estado")) Then
                        If grCLIFormaVenta.GetValue("Estado") = 0 Then
                            grCLIFormaVenta.RootTable.Columns("Inicial").EditType = Janus.Windows.GridEX.EditType.NoEdit
                        Else
                            grCLIFormaVenta.RootTable.Columns("Inicial").EditType = Janus.Windows.GridEX.EditType.CheckBox
                        End If
                    End If
                End If
                If Not IsDBNull(grCLIFormaVenta.GetValue("Inicial")) Then
                    If grCLIFormaVenta.GetValue("Inicial") = True Then
                        grCLIFormaVenta.RootTable.Columns("Estado").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    Else
                        grCLIFormaVenta.RootTable.Columns("Estado").EditType = Janus.Windows.GridEX.EditType.DropDownList
                    End If
                End If

                grCLIFormaVenta.RootTable.Columns("LimiteCredito").EditType = Janus.Windows.GridEX.EditType.NoEdit
                grCLIFormaVenta.RootTable.Columns("DiasCredito").EditType = Janus.Windows.GridEX.EditType.NoEdit
                grCLIFormaVenta.RootTable.Columns("CapturaDias").EditType = Janus.Windows.GridEX.EditType.NoEdit
                grCLIFormaVenta.RootTable.Columns("ValidaLimite").EditType = Janus.Windows.GridEX.EditType.NoEdit
                grCLIFormaVenta.RootTable.Columns("ValidaPago").EditType = Janus.Windows.GridEX.EditType.NoEdit
                If Not IsDBNull(grCLIFormaVenta.GetValue("CFVTipo")) Then
                    Select Case CType(grCLIFormaVenta.GetValue("CFVTipo"), Integer)
                        Case 1
                            grCLIFormaVenta.RootTable.Columns("ValidaPago").EditType = Janus.Windows.GridEX.EditType.CheckBox
                        Case 2
                            grCLIFormaVenta.RootTable.Columns("LimiteCredito").EditType = Janus.Windows.GridEX.EditType.TextBox
                            grCLIFormaVenta.RootTable.Columns("DiasCredito").EditType = Janus.Windows.GridEX.EditType.TextBox
                            grCLIFormaVenta.RootTable.Columns("CapturaDias").EditType = Janus.Windows.GridEX.EditType.CheckBox
                            grCLIFormaVenta.RootTable.Columns("ValidaLimite").EditType = Janus.Windows.GridEX.EditType.CheckBox
                    End Select
                End If
            End If
        End If




        If grCLIFormaVenta.RowCount > 0 And (vcMODO = eModo.Crear Or vcMODO = eModo.Modificar) Then
            If Not grCLIFormaVenta.GetRow Is Nothing Then
                If (grCLIFormaVenta.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                    btCFVEliminar.Enabled = False
                    btCFVHistorico.Enabled = False
                Else
                    If grCLIFormaVenta.GetRow.DataRow.Row.RowState = DataRowState.Added Then
                        btCFVEliminar.Enabled = True
                        btCFVHistorico.Enabled = False
                    Else
                        btCFVEliminar.Enabled = False
                        btCFVHistorico.Enabled = True
                    End If
                End If
            Else
                btCFVEliminar.Enabled = False
            End If
        Else
            btCFVEliminar.Enabled = False
            btCFVHistorico.Enabled = False
        End If
        vcCFVTipo = grCLIFormaVenta.GetValue("CFVTipo")
    End Sub

    Private Sub grCLIFormaVenta_UpdatingCell(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs) Handles grCLIFormaVenta.UpdatingCell
        If e.Column.Key = "CFVTipo" Then
            If e.Value = e.InitialValue Then
                e.Value = e.InitialValue
                Exit Sub
            End If
            For Each vlDataRow As Janus.Windows.GridEX.GridEXRow In grCLIFormaVenta.GetRows
                If e.InitialValue = e.Value Then
                    MsgBox(vcMensaje.RecuperarDescripcion("BE0002"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                    e.Value = e.InitialValue
                    e.Cancel = True
                    Exit Sub
                End If
            Next
            vcCFVTipo = grCLIFormaVenta.GetValue("CFVTipo")
        End If
    End Sub

    Private Sub ActualizarCFVHist()
        If IsNothing(vcCliente.CLIFormaVenta(vcCFVTipo).CFVHist(LbConexion.cConexion.Instancia.ObtenerFecha.Date)) Then
            vcCliente.CLIFormaVenta(vcCFVTipo).CFVHist.CFHFechaInicio = LbConexion.cConexion.Instancia.ObtenerFecha.Date
            vcCliente.CLIFormaVenta(vcCFVTipo).CFVHist.LimiteCredito = grCLIFormaVenta.GetValue("LimiteCredito")
            vcCliente.CLIFormaVenta(vcCFVTipo).CFVHist.DiasCredito = grCLIFormaVenta.GetValue("DiasCredito")
            vcCliente.CLIFormaVenta(vcCFVTipo).CFVHist.CapturaDias = grCLIFormaVenta.GetValue("CapturaDias")
            vcCliente.CLIFormaVenta(vcCFVTipo).CFVHist.ValidaLimite = grCLIFormaVenta.GetValue("ValidaLimite")
            vcCliente.CLIFormaVenta(vcCFVTipo).CFVHist.ValidaPago = grCLIFormaVenta.GetValue("ValidaPago")
            vcCliente.CLIFormaVenta(vcCFVTipo).CFVHist.MUsuarioId = vcMUsuarioId
            Try
                vcCliente.CLIFormaVenta(vcCFVTipo).CFVHist.Insertar()
            Catch ex As LbControlError.cError
                Throw ex
            End Try
        Else
            vcCliente.CLIFormaVenta(vcCFVTipo).CFVHist(LbConexion.cConexion.Instancia.ObtenerFecha.Date).LimiteCredito = grCLIFormaVenta.GetValue("LimiteCredito")
            vcCliente.CLIFormaVenta(vcCFVTipo).CFVHist(LbConexion.cConexion.Instancia.ObtenerFecha.Date).DiasCredito = grCLIFormaVenta.GetValue("DiasCredito")
            vcCliente.CLIFormaVenta(vcCFVTipo).CFVHist(LbConexion.cConexion.Instancia.ObtenerFecha.Date).CapturaDias = grCLIFormaVenta.GetValue("CapturaDias")
            vcCliente.CLIFormaVenta(vcCFVTipo).CFVHist(LbConexion.cConexion.Instancia.ObtenerFecha.Date).ValidaLimite = grCLIFormaVenta.GetValue("ValidaLimite")
            vcCliente.CLIFormaVenta(vcCFVTipo).CFVHist(LbConexion.cConexion.Instancia.ObtenerFecha.Date).ValidaPago = grCLIFormaVenta.GetValue("ValidaPago")
            vcCliente.CLIFormaVenta(vcCFVTipo).CFVHist(LbConexion.cConexion.Instancia.ObtenerFecha.Date).MUsuarioId = vcMUsuarioId
            Try
                vcCliente.CLIFormaVenta(vcCFVTipo).CFVHist(LbConexion.cConexion.Instancia.ObtenerFecha.Date).ValidarCampos()
            Catch ex As LbControlError.cError
                Throw ex
            End Try
        End If
    End Sub
    Private Sub grCLIFormaVenta_UpdatingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grCLIFormaVenta.UpdatingRecord

        Call LlenarNulos(grCLIFormaVenta)
        If IsNothing(vcCliente.CLIFormaVenta(vcCFVTipo)) Then
            Return
        End If
        If grCLIFormaVenta.GetValue("CFVTipo") = 2 And grCLIFormaVenta.GetValue("LimiteCredito") <= 0 Then
            'MsgBox(vcMensaje.RecuperarDescripcion("E0007"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
            MsgBox(vcMensaje.RecuperarDescripcion("E0334", New String() {vcMensaje.RecuperarDescripcion("CLILimiteCreditoDinero")}), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
            e.Cancel = True
            Exit Sub
        End If

        Try
            If vcCliente.CLIFormaVenta(vcCFVTipo).cEstado <> ERMCLILOG.eEstado.Nuevo _
            And (vcCliente.CLIFormaVenta(vcCFVTipo).LimiteCredito <> grCLIFormaVenta.GetValue("LimiteCredito") _
            Or vcCliente.CLIFormaVenta(vcCFVTipo).DiasCredito <> grCLIFormaVenta.GetValue("DiasCredito") _
            Or vcCliente.CLIFormaVenta(vcCFVTipo).CapturaDias <> grCLIFormaVenta.GetValue("CapturaDias") _
            Or vcCliente.CLIFormaVenta(vcCFVTipo).ValidaLimite <> grCLIFormaVenta.GetValue("ValidaLimite") _
            Or vcCliente.CLIFormaVenta(vcCFVTipo).ValidaPago <> grCLIFormaVenta.GetValue("ValidaPago")) Then
                Call ActualizarCFVHist()
            End If
        Catch ex As LbControlError.cError
            ex.Mostrar()
            e.Cancel = True
            Exit Sub
        End Try

        vcCliente.CLIFormaVenta(vcCFVTipo).CFVTipo = grCLIFormaVenta.GetValue("CFVTipo")
        vcCliente.CLIFormaVenta(CType(grCLIFormaVenta.GetValue("CFVTipo"), Integer)).LimiteCredito = grCLIFormaVenta.GetValue("LimiteCredito")
        vcCliente.CLIFormaVenta(CType(grCLIFormaVenta.GetValue("CFVTipo"), Integer)).DiasCredito = grCLIFormaVenta.GetValue("DiasCredito")
        vcCliente.CLIFormaVenta(CType(grCLIFormaVenta.GetValue("CFVTipo"), Integer)).Inicial = grCLIFormaVenta.GetValue("Inicial")
        vcCliente.CLIFormaVenta(CType(grCLIFormaVenta.GetValue("CFVTipo"), Integer)).CapturaDias = grCLIFormaVenta.GetValue("CapturaDias")
        vcCliente.CLIFormaVenta(CType(grCLIFormaVenta.GetValue("CFVTipo"), Integer)).ValidaLimite = grCLIFormaVenta.GetValue("ValidaLimite")
        vcCliente.CLIFormaVenta(CType(grCLIFormaVenta.GetValue("CFVTipo"), Integer)).ValidaPago = grCLIFormaVenta.GetValue("ValidaPago")
        vcCliente.CLIFormaVenta(CType(grCLIFormaVenta.GetValue("CFVTipo"), Integer)).Estado = grCLIFormaVenta.GetValue("Estado")
        vcCliente.CLIFormaVenta(CType(grCLIFormaVenta.GetValue("CFVTipo"), Integer)).MUsuarioId = vcMUsuarioId
        Try
            vcCliente.CLIFormaVenta(CType(grCLIFormaVenta.GetValue("CFVTipo"), Integer)).ValidarCampos()
        Catch ex As LbControlError.cError
            ex.Mostrar()
            e.Cancel = True
            Exit Sub
        End Try
        vcCFVTipo = grCLIFormaVenta.GetValue("CFVTipo")
    End Sub

    Private Sub grCLIFormaVenta_CancelingRowEdit(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowActionCancelEventArgs) Handles grCLIFormaVenta.CancelingRowEdit
        e.Cancel = True
    End Sub
#End Region

#End Region

#Region "Tab 5 Saldos"
    Private Sub btCPRHistorico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCPRHistorico.Click
        Dim oHistorico As New DClienteProducto
        oHistorico.CONSULTAR(vcCliente)
    End Sub
#End Region

#Region "Tab 6 Facturación"

    Private Sub grCLIConfNumCta_EditingCell(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.EditingCellEventArgs) Handles grCLIConfNumCta.EditingCell
        Select Case (e.Column.Key)
            Case "Seleccionado"
                If (grCLIConfNumCta.GetValue("Campo") = 1 Or grCLIConfNumCta.GetValue("Campo") = 3) Then
                    e.Cancel = True
                Else
                    If grCLIConfNumCta.GetRow.Cells("Orden").Value.Equals(DBNull.Value) Then
                        Exit Sub
                    Else
                        grCLIConfNumCta.GetRow.Cells("Orden").Value = DBNull.Value
                        grCLIConfNumCta.GetRow.Cells("Seleccionado").Value = Not grCLIConfNumCta.GetValue("Seleccionado")
                        vcCliente.CLIConfNumCta(grCLIConfNumCta.GetValue("Campo")).Eliminar()

                    End If
                End If
            Case "Orden"
                If grCLIConfNumCta.GetValue("Seleccionado") = 0 Then
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub grCLIConfNumCta_UpdatingCell(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs) Handles grCLIConfNumCta.UpdatingCell
        Try
            If e.Column.Key = "Orden" Then
                If IsDBNull(grCLIConfNumCta.GetValue("Orden")) Then
                    'e.Cancel = True
                    Exit Sub
                Else
                    If vcCliente.CLIConfNumCta(grCLIConfNumCta.GetValue("Campo")) Is Nothing Then
                        vcCliente.CLIConfNumCta.CampoC = grCLIConfNumCta.GetValue("Campo")
                        vcCliente.CLIConfNumCta.Orden = grCLIConfNumCta.GetValue("Orden")
                        vcCliente.CLIConfNumCta.MUsuarioId = vcMUsuarioId
                        vcCliente.CLIConfNumCta.Insertar(New String() {"Orden"})
                    Else
                        vcCliente.CLIConfNumCta(grCLIConfNumCta.GetValue("Campo")).Orden = grCLIConfNumCta.GetValue("Orden")
                        vcCliente.CLIConfNumCta(grCLIConfNumCta.GetValue("Campo")).MUsuarioId = vcMUsuarioId
                    End If
                End If
            End If
        Catch ex As LbControlError.cError
            ex.Mostrar()
            e.Cancel = True
            Exit Sub
        End Try
    End Sub
#End Region

#Region " Aceptar y Cancelar "
    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click
        Dim vlExisteSecuencia As Boolean
        Dim vlDataTable As DataTable

        Me.DialogResult = Windows.Forms.DialogResult.None

        If vcMODO = eModo.Crear Or vcMODO = eModo.Modificar Then
            'TAB 1
            If vcMODO = eModo.Crear Then
                vcCliente.Clave = ebClienteClave.Text
                vcCliente.SaldoEfectivo = 0
                vcCliente.SaldoGarantia = 0
                ' vcCliente.SaldoPrestamo = 0

                'If ebClienteClave.Text <> "" Then
                '    If vcCliente.Tabla.Recuperar("ClienteClave='" + ebClienteClave.Text + "'").Rows.Count > 0 Then
                '        MsgBox(vcMensaje.RecuperarDescripcion("BE0002"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                '        ebClienteClave.Focus()
                '        Exit Sub
                '    End If
                'End If
            End If
            vcCliente.FechaRegistroSistema = ccFechaRegistroSistema.Value
            If vcMODO = eModo.Modificar And cbTipoEstado.SelectedValue = 0 And cbTipoEstado.SelectedValue <> nEstadoInicial Then
                If Not vcCliente.ValidarSaldos Then
                    If MsgBox(vcMensaje.RecuperarDescripcion("P0216"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo, vcMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                        vcCliente.TipoEstado = cbTipoEstado.SelectedValue
                    Else
                        vcCliente.TipoEstado = nEstadoInicial
                    End If
                Else
                    vcCliente.TipoEstado = cbTipoEstado.SelectedValue
                End If
            Else
                vcCliente.TipoEstado = cbTipoEstado.SelectedValue
            End If
            vcCliente.IdElectronico = ebIdElectronico.TextBox.Text

            vcCliente.NombreCorto = ebNombreCorto.Text
            vcCliente.RazonSocial = ebRazonSocial.Text
            If cbTipoFiscal.SelectedValue <> Nothing Then
                vcCliente.TipoFiscal = cbTipoFiscal.SelectedValue
            End If
            If cbTipoImpuesto.SelectedValue <> Nothing Then
                vcCliente.TipoImpuesto = cbTipoImpuesto.SelectedValue
            End If
            vcCliente.IdFiscal = ebIdFiscal.Text.Replace("-", "")
            vcCliente.FechaNacimiento = ccFechaNacimiento.Value
            vcCliente.LimiteCreditoDinero = ebLimiteCreditoDinero.Value
            vcCliente.Prestamo = chbPrestamo.Checked
            vcCliente.Exclusividad = chbExclusividad.Checked

            Try
                If Me.chbExclusividad.Checked = True Then
                    vcCliente.VigExclusividad = ebVigExclusividad.Value
                End If
            Catch ex As Exception
                MessageBox.Show("Fecha no valida")
            End Try

            vcCliente.ActualizaSaldoCheque = chbActualizaSaldoCheque.Checked
            vcCliente.VencimientoVenta = chbVencimientoVenta.Checked
            vcCliente.DiasVencimiento = ebDiasVencimiento.Value
            vcCliente.CorreoElectronico = ebCorreoElectronico.Text
            vcCliente.LimiteDescuento = ebLimiteDescuento.Value * 100
            vcCliente.NombreContacto = ebNombreContacto.Text
            vcCliente.TelefonoContacto = ebTelefonoContacto.Text
            vcCliente.FechaFactura = ebFechaFactura.Value
            vcCliente.DesgloseImpuesto = chbDesgloseImpuesto.Checked
            vcCliente.ExigirOrdenCompra = chbExigirOrden.Checked
            vcCliente.CriterioCredito = chbCriterioCredito.Checked
            vcCliente.ImprimirPagare = chbImprimirPagare.Checked
            vcCliente.CapturaDatosFacturacion = chbCapturaDatosFacturacion.Checked

            vcCliente.MUsuarioId = vcMUsuarioId
            Try
                If vcMODO = eModo.Crear Then
                    vcCliente.Insertar()
                Else
                    vcCliente.ValidarCampos()
                End If
            Catch ex As LbControlError.cError
                Select Case ex.Source
                    Case "Clave"
                        ebClienteClave.Focus()
                    Case "FechaRegistroSistema"
                        ccFechaRegistroSistema.Focus()
                    Case "TipoEstado"
                        cbTipoEstado.Focus()
                    Case "IdElectronico"
                        ebIdElectronico.Focus()
                    Case "NombreCorto"
                        ebNombreCorto.Focus()
                    Case "RazonSocial"
                        ebRazonSocial.Focus()
                    Case "TipoFiscal"
                        cbTipoFiscal.Focus()
                    Case "TipoImpuesto"
                        cbTipoImpuesto.Focus()
                    Case "IdFiscal"
                        ebIdFiscal.Focus()
                    Case "FechaNacimiento"
                        ccFechaNacimiento.Focus()
                    Case "LimiteCreditoDinero"
                        ebLimiteCreditoDinero.Focus()
                    Case "Prestamo"
                        chbPrestamo.Focus()
                    Case "Exclusividad"
                        chbExclusividad.Focus()
                    Case "VigExclusividad"
                        ebVigExclusividad.Focus()
                    Case "ActualizaSaldoCheque"
                        chbActualizaSaldoCheque.Focus()
                    Case "VencimientoVenta"
                        chbVencimientoVenta.Focus()
                    Case "DiasVencimiento"
                        ebDiasVencimiento.Focus()
                    Case "LimiteDescuento"
                        ebLimiteDescuento.Focus()
                    Case "NombreContacto"
                        ebNombreContacto.Focus()
                    Case "TelefonoContacto"
                        ebTelefonoContacto.Focus()
                    Case "Calle"
                        Me.ebCalle.Focus()
                    Case "Poblacion"
                        Me.ebPoblacion.Focus()
                    Case "Pais"
                        Me.ebPais.Focus()
                    Case "ExigirOrdenCompra"
                        Me.chbExigirOrden.Focus()
                    Case "CriterioCredito"
                        Me.chbCriterioCredito.Focus()
                    Case "ImprimirPagare"
                        Me.chbImprimirPagare.Focus()
                    Case "CapturaDatosFacturacion"
                        Me.chbCapturaDatosFacturacion.Focus()
                End Select
                ex.Mostrar()
                Exit Sub
            End Try

            If ebIdFiscal.Text = "" Then
                MsgBox(vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion("CLIIdFiscal")}), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                'UiTab1.TabPages("Generales").Selected = True
                TabControl1.SelectedTab = tabGenerales

                ebIdFiscal.Focus()
                Exit Sub
            End If

            If ebCorreoElectronico.Text <> "" Then
                vcCliente.CorreoElectronico = ebCorreoElectronico.Text
                Dim oReg As New Regex("^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")
                If Not oReg.IsMatch(ebCorreoElectronico.Text) Then
                    MsgBox(vcMensaje.RecuperarDescripcion("E0593", New String() {lbCorreoElectronico.Text, "XX@XX.XX"}), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                    Exit Sub
                End If
            End If
            If grClienteEsquema.RowCount = 0 Then
                MsgBox(vcMensaje.RecuperarDescripcion("E0006"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                'UiTab1.TabPages("Generales").Selected = True
                TabControl1.SelectedTab = tabGenerales

                Exit Sub
            End If
            If vcMODO = eModo.Modificar Or vcMODO = eModo.Crear Then
                Dim vlActivo As Boolean = False
                For Each row As DataRow In Me.grClienteEsquema.DataSource.Rows
                    If row("TipoEstado") = 1 Then
                        vlActivo = True
                        Exit For
                    End If
                Next
                If Not vlActivo Then
                    MsgBox(vcMensaje.RecuperarDescripcion("E0006"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                    'UiTab1.TabPages("Generales").Selected = True
                    TabControl1.SelectedTab = tabGenerales
                    Exit Sub
                End If

            End If

            'TAB 2
            If vcCliente.ClienteDomicilio.Conteo = 0 Then
                MsgBox(vcMensaje.RecuperarDescripcion("E0018", New String() {""}), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                'UiTab1.TabPages("Domicilio").Selected = True
                TabControl1.SelectedTab = tabDomicilio

                Exit Sub
            End If

            If chbDesgloseImpuesto.Checked Then
                Dim cantFiscales As Integer = 0
                For y As Integer = 0 To vcCliente.ClienteDomicilio.Conteo - 1

                    If vcCliente.ClienteDomicilio(y).Tipo = 1 Then
                        cantFiscales += 1
                        If vcCliente.ClienteDomicilio(y).CodigoPostal = "" Then
                            MsgBox(vcMensaje.RecuperarDescripcion("BE0001", New String() {lbCodigoPostal.Text}), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                            'UiTab1.TabPages("Domicilio").Selected = True
                            TabControl1.SelectedTab = tabDomicilio
                            Exit Sub
                        End If
                        If vcCliente.ClienteDomicilio(y).Poblacion = "" Then
                            MsgBox(vcMensaje.RecuperarDescripcion("BE0001", New String() {lbPoblacion.Text}), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                            'UiTab1.TabPages("Domicilio").Selected = True
                            TabControl1.SelectedTab = tabDomicilio
                            Exit Sub
                        End If
                        If vcCliente.ClienteDomicilio(y).Entidad = "" Then
                            MsgBox(vcMensaje.RecuperarDescripcion("BE0001", New String() {lbEntidad.Text}), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                            'UiTab1.TabPages("Domicilio").Selected = True
                            TabControl1.SelectedTab = tabDomicilio
                            Exit Sub
                        End If
                    End If
                Next
                If cantFiscales = 0 Then
                    MsgBox(vcMensaje.RecuperarDescripcion("E0018", New String() {cbTipo.Items(0).Text}), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                    'UiTab1.TabPages("Domicilio").Selected = True
                    TabControl1.SelectedTab = tabDomicilio
                    Exit Sub
                End If
            End If

            'TAB 3
            For Each vlClienteDomicilioId As String In vcHSFrecuencia.Keys
                vlDataTable = vcHSFrecuencia(vlClienteDomicilioId)
                vlExisteSecuencia = False
                For Each vlDataRow As DataRow In vlDataTable.Rows
                    If vlDataRow("Selector") = True Then
                        vlExisteSecuencia = True
                        Exit For
                    End If
                Next
                If vlExisteSecuencia = False Then
                    MsgBox(vcMensaje.RecuperarDescripcion("E0017"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                    'UiTab1.TabPages("Domicilio").Selected = True
                    TabControl1.SelectedTab = tabDomicilio
                    For a As Integer = 0 To vcCliente.ClienteDomicilio.Conteo - 1
                        If vcCliente.ClienteDomicilio(a).ClienteDomicilioId = vlClienteDomicilioId Then
                            sbClienteDomicilio.Value = a
                            Call CLDLeerActual()
                            Exit For
                        End If
                    Next
                    Exit Sub
                End If
            Next

            'TAB 4
            If vcCliente.CLIFormaVenta.Conteo = 0 Then
                MsgBox(vcMensaje.RecuperarDescripcion("E0341"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                'UiTab1.TabPages("Condiciones de Venta").Selected = True
                TabControl1.SelectedTab = tabConVenta
                Exit Sub
            End If

            'TAB 6
            For Each vlDataRow As Janus.Windows.GridEX.GridEXRow In grCLIConfNumCta.GetRows()
                Dim x As Janus.Windows.GridEX.GridEXCell = vlDataRow.Cells("Seleccionado")
                If (vlDataRow.Cells("Seleccionado").Value = True And vlDataRow.Cells("Orden").Value.Equals(DBNull.Value)) Then
                    MsgBox(vcMensaje.RecuperarDescripcion("I0231"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                    TabControl1.SelectedTab = tabDesglosaImpuesto
                    Exit Sub
                End If
            Next

            Dim bEliminarSecuencia As Boolean = False
            If vcMODO = eModo.Modificar And vcCliente.TipoEstado = 0 And vcCliente.TipoEstado <> nEstadoInicial Then
                bEliminarSecuencia = (MsgBox(vcMensaje.RecuperarDescripcion("P0217"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo, vcMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes)
            End If

            'INICIA GRABAR
            'TAB 1, 2 y 5
            Try
                vcCliente.Grabar()
            Catch ex As LbControlError.cError
                vcConexion.DeshacerTran()
                ex.Mostrar()
                Exit Sub
            End Try

            'TAB 3
            Dim i As Integer = 1
            For Each vlClienteDomicilioId As String In vcHSFrecuencia.Keys
                vlDataTable = vcHSFrecuencia(vlClienteDomicilioId)
                For Each vlDataRow As DataRow In vlDataTable.Rows
                    If vlDataRow("Selector") = True Then
                        If vlDataRow("Estado") = eModo.Crear Then
                            vcSecuencia.Limpiar()
                            vcSecuencia.SECId = lbGeneral.cKeyGen.KEYGEN(1)
                            vcSecuencia.ClienteClave = vcCliente.ClienteClave
                            vcSecuencia.ClienteDomicilioID = vlClienteDomicilioId
                            vcSecuencia.FrecuenciaClave = vlDataRow("FrecuenciaClave")
                            vcSecuencia.MUsuarioId = vcMUsuarioId
                            vcSecuencia.Insertar()
                            Try
                                vcSecuencia.Grabar()
                            Catch ex As LbControlError.cError
                                vcConexion.DeshacerTran()
                                ex.Mostrar()
                                Exit Sub
                            End Try
                        End If
                    Else
                        If vlDataRow("Estado") = eModo.Eliminar Then
                            vcSecuencia.Limpiar()
                            vcSecuencia.Recuperar(vlDataRow("SECId"))
                            If vcSecuencia.HaveRUTClave Then
                                If MsgBox(vcMensaje.RecuperarDescripcion("P0085", New String() {vcSecuencia.FrecuenciaClave, vcSecuencia.RUTClave}), MsgBoxStyle.YesNo, "") = MsgBoxResult.No Then
                                    vcConexion.DeshacerTran()
                                    Exit Sub
                                End If
                            End If
                            vcSecuencia.Eliminar()
                            Try
                                vcSecuencia.Grabar()
                            Catch ex As LbControlError.cError
                                vcConexion.DeshacerTran()
                                ex.Mostrar()
                                Exit Sub
                            End Try
                        End If
                    End If
                Next
            Next

            'TAB 4
            For Each vlDataRow As Janus.Windows.GridEX.GridEXRow In grClienteMensaje.GetRows
                If vlDataRow.DataRow.Row.RowState = DataRowState.Added Then
                    vcClienteMensaje.Limpiar()
                    vcClienteMensaje.ClienteClave = vcCliente.ClienteClave
                    vcClienteMensaje.MDBMensajeId = vlDataRow.Cells("MDBMensajeId").Value
                    vcClienteMensaje.TipoEstado = vlDataRow.Cells("TipoEstado").Value
                    vcClienteMensaje.MUsuarioId = vcMUsuarioId
                    vcClienteMensaje.Insertar()
                ElseIf vlDataRow.DataRow.Row.RowState = DataRowState.Modified Then
                    vcClienteMensaje.Limpiar()
                    vcClienteMensaje.Recuperar(vcCliente.ClienteClave, vlDataRow.Cells("MDBMensajeId").Value)
                    vcClienteMensaje.TipoEstado = vlDataRow.Cells("TipoEstado").Value
                    vcClienteMensaje.MUsuarioId = vcMUsuarioId
                    vcClienteMensaje.Grabar()
                ElseIf vlDataRow.DataRow.Row.RowState = DataRowState.Deleted Then
                    vcClienteMensaje.Limpiar()
                    vcClienteMensaje.Recuperar(vcCliente.ClienteClave, vlDataRow.Cells("MDBMensajeId").Value)
                    vcClienteMensaje.Eliminar()
                End If
                Try
                    vcClienteMensaje.Grabar()
                Catch ex As LbControlError.cError
                    vcConexion.DeshacerTran()
                    ex.Mostrar()
                    Exit Sub
                End Try
            Next

            If bEliminarSecuencia Then
                vcCliente.EliminarSecuencias(vcMUsuarioId)
            End If

            If (vcMODO = eModo.Crear) Then
                For Each fila As Janus.Windows.GridEX.GridEXRow In grDesgloseImpuesto.GetRows()
                    Dim oCliNoDesImp As New ERMCLILOG.cCLINoDesImp(vcCliente)

                    oCliNoDesImp.CNDIID = lbGeneral.cKeyGen.KEYGEN(1)
                    oCliNoDesImp.FechaFin = "9998-12-31T00:00:00"
                    oCliNoDesImp.FechaInicio = LbConexion.cConexion.Instancia.ObtenerFecha()
                    oCliNoDesImp.ImpuestoClave = fila.Cells("ImpuestoClave").Value
                    oCliNoDesImp.Grabar()
                Next

            ElseIf vcMODO = eModo.Modificar Then
                Dim dtOriginales As DataTable = vcCliente.CLINoDesImp.ToDataTable.Copy
                dtOriginales.RejectChanges()
                Dim bExiste As Boolean = False
                For Each filaOriginal As DataRow In dtOriginales.Rows
                    bExiste = False
                    For Each filaGrid As Janus.Windows.GridEX.GridEXRow In grDesgloseImpuesto.GetRows()
                        If (filaOriginal("ImpuestoClave") = filaGrid.Cells("ImpuestoClave").Value) Then
                            bExiste = True
                        End If
                    Next
                    If (bExiste) Then
                        Continue For
                    End If
                    Dim oCliNoDesImp As New ERMCLILOG.cCLINoDesImp(vcCliente)
                    oCliNoDesImp.Recuperar(filaOriginal("CNDIID"))
                    oCliNoDesImp.FechaFin = LbConexion.cConexion.Instancia.ObtenerFecha()
                    oCliNoDesImp.Grabar()
                Next

                For Each filaGrid As Janus.Windows.GridEX.GridEXRow In grDesgloseImpuesto.GetRows()
                    bExiste = False
                    For Each filaOriginal As DataRow In dtOriginales.Rows
                        If (filaOriginal("ImpuestoClave") = filaGrid.Cells("ImpuestoClave").Value) Then
                            bExiste = True
                        End If
                    Next
                    If (bExiste) Then
                        Continue For
                    End If
                    Dim oCliNoDesImp As New ERMCLILOG.cCLINoDesImp(vcCliente)

                    oCliNoDesImp.CNDIID = lbGeneral.cKeyGen.KEYGEN(1)
                    oCliNoDesImp.FechaFin = "9998-12-31T00:00:00"
                    oCliNoDesImp.FechaInicio = LbConexion.cConexion.Instancia.ObtenerFecha()
                    oCliNoDesImp.ImpuestoClave = filaGrid.Cells("ImpuestoClave").Value
                    oCliNoDesImp.Grabar()
                Next

            End If




            vcConexion.ConfirmarTran()
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        vcCerrar = True
        Me.Close()
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        Me.Close()
    End Sub

    Private Sub MGENERAL_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not vcCerrar And vcHuboCambios And vcMODO <> eModo.Leer Then

            Me.DialogResult = Windows.Forms.DialogResult.None

            If MsgBox(vcMensaje.RecuperarDescripcion("BP0001"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, vcMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                vcCliente = New ERMCLILOG.cCliente()
            Else
                e.Cancel = False
            End If
        End If
    End Sub
#End Region

    Private Sub MGENERAL_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If vcMODO = eModo.Leer Then BtCancelar.Focus()
    End Sub

    'Private Sub grClienteEsquema_EditModeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grClienteEsquema.EditModeChanged
    '    If grClienteEsquema.EditMode = Janus.Windows.GridEX.EditMode.EditOff Then
    '        UiTab1.ShowTabs = True
    '    Else
    '        UiTab1.ShowTabs = False
    '    End If
    'End Sub

    Private Sub TabControl1_SelectedTabChanging(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControl1.SelectedTabChanging
        'If Not e.OldTab Is Nothing Then
        '    Select Case e.OldTab.Name
        '        Case tabGenerales.Name
        If grClienteEsquema.EditMode = Janus.Windows.GridEX.EditMode.EditOn _
            Or grFrecuencia.EditMode = Janus.Windows.GridEX.EditMode.EditOn _
            Or grClienteMensaje.EditMode = Janus.Windows.GridEX.EditMode.EditOn _
            Or grClientePago.EditMode = Janus.Windows.GridEX.EditMode.EditOn _
            Or grCLIFormaVenta.EditMode = Janus.Windows.GridEX.EditMode.EditOn _
            Or grClienteProducto.EditMode = Janus.Windows.GridEX.EditMode.EditOn Then
            e.Cancel = True
        End If
        'Case tabDomicilio.Name

        'End Select
        'End If

    End Sub


    'Private Sub ebCoordenadaX_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebCoordenadaX.Validating
    '    If Not IsNumeric(ebCoordenadaX.Text) Then
    '        epErrores.SetError(ebCoordenadaX, vcMensaje.RecuperarDescripcion("E0553"))
    '    Else
    '        epErrores.SetError(ebCoordenadaX, "")
    '    End If
    'End Sub

    Private Sub ebCoordenadaX_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCoordenadaX.TextChanged
        If vcCLDModo = eModo.Leer Then
            vcCLDModo = eModo.Modificar
        End If
    End Sub

    Private Sub ebCoordenadaY_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebCoordenadaY.TextChanged
        If vcCLDModo = eModo.Leer Then
            vcCLDModo = eModo.Modificar
        End If
    End Sub


    Private Sub chbDesgloseImpuesto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDesgloseImpuesto.CheckedChanged
        gbExcepcionDesglose.Enabled = chbDesgloseImpuesto.Checked
    End Sub

    Private Sub btCNDINuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grDesgloseImpuesto.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
        grDesgloseImpuesto.MoveToNewRecord()
        grDesgloseImpuesto.Col = 0
        grDesgloseImpuesto.Focus()



        If grDesgloseImpuesto.RowCount = 0 Then
            grDesgloseImpuesto.RootTable.Columns("Nombre").EditType = Janus.Windows.GridEX.EditType.NoEdit
            grDesgloseImpuesto.RootTable.Columns("Abreviatura").EditType = Janus.Windows.GridEX.EditType.NoEdit

        End If

    End Sub

    Private Sub btCNDIBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oImpuesto As New ERMIMPESC.IGeneral(False, "ImpuestoClave,Nombre,Abreviatura", "TipoEstado<>0")

        Try
            oImpuesto.ShowDialog()
        Catch ex As Exception
            Exit Sub
        End Try
        If (oImpuesto.Seleccion.Count > 0) Then


            Dim vlDataTable As DataTable = grDesgloseImpuesto.DataSource

            If vlDataTable.Select("ImpuestoClave='" + lbGeneral.ValidaFormatoSQLString(oImpuesto.Seleccion(0)("ImpuestoClave")) + "'").Length = 0 Then

                grDesgloseImpuesto.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                grDesgloseImpuesto.MoveToNewRecord()
                grDesgloseImpuesto.GetRow.Cells("ImpuestoClave").Value = oImpuesto.Seleccion(0)("ImpuestoClave")
                grDesgloseImpuesto.GetRow.Cells("Nombre").Value = oImpuesto.Seleccion(0)("Nombre")
                grDesgloseImpuesto.GetRow.Cells("Abreviatura").Value = oImpuesto.Seleccion(0)("Abreviatura")
                grDesgloseImpuesto.UpdateData()
                grDesgloseImpuesto.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If




    End Sub

    Private Sub btCNDIEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (grDesgloseImpuesto.RowCount = 0) Then
            Exit Sub
        End If

        grDesgloseImpuesto.CancelCurrentEdit()

        grDesgloseImpuesto.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
        grDesgloseImpuesto.Delete()
        grDesgloseImpuesto.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False


    End Sub

    Private Sub grDesgloseImpuesto_AddingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub grDesgloseImpuesto_FirstChange(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs)
        vcHuboCambios = True
    End Sub

    Private Sub grDesgloseImpuesto_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (grDesgloseImpuesto.GetRow Is Nothing) Then
            btCNDIEliminar.Enabled = False
            Exit Sub
        End If
        If (grDesgloseImpuesto.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
            grDesgloseImpuesto.RootTable.Columns("ImpuestoClave").EditType = Janus.Windows.GridEX.EditType.TextBox
        Else
            grDesgloseImpuesto.RootTable.Columns("ImpuestoClave").EditType = Janus.Windows.GridEX.EditType.NoEdit
        End If

        If grDesgloseImpuesto.RowCount > 0 And (vcMODO = eModo.Crear Or vcMODO = eModo.Modificar) Then
            btCNDIEliminar.Enabled = True
        Else
            btCNDIEliminar.Enabled = False
        End If


    End Sub

    Private Sub grDesgloseImpuesto_UpdatingCell(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs)
        Dim vlDataTable As New DataTable

        If e.Column.Key = "ImpuestoClave" Then
            If IsNothing(e.Value) Or IsDBNull(e.Value) Then
                e.Value = ""
            End If
            If e.Value = "" Then
                grDesgloseImpuesto.GetRow.Cells("Nombre").Value = ""
                grDesgloseImpuesto.GetRow.Cells("Abreviatura").Value = ""

                MsgBox(vcMensaje.RecuperarDescripcion("BE0001").Replace("$0$", e.Column.Caption), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                e.Cancel = True
                Exit Sub
            End If
            If IsNothing(e.InitialValue) = False Then
                If LCase(e.Value) = LCase(e.InitialValue) Then
                    Exit Sub
                End If
            End If
            For Each vlDataRow As Janus.Windows.GridEX.GridEXRow In grDesgloseImpuesto.GetRows
                If LCase(vlDataRow.Cells(0).Value) = LCase(e.Value) Then
                    MsgBox(vcMensaje.RecuperarDescripcion("BE0002"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                    e.Value = e.InitialValue
                    e.Cancel = True
                    Exit Sub
                End If
            Next

            Try

                If IsNothing(e.Value) = True Then
                    grDesgloseImpuesto.GetRow.Cells("Nombre").Value = ""
                    grDesgloseImpuesto.GetRow.Cells("Abreviatura").Value = ""
                    Exit Sub
                End If

                vlDataTable = vcImpuesto.Tabla.RecuperarTabla("ImpuestoClave='" + e.Value + "'", "ImpuestoClave,Nombre,Abreviatura,TipoEstado")
                If vlDataTable.Rows.Count = 0 Then
                    'TODO:
                    'Cambiar mensaje Impuesto Inexistente
                    Throw New LbControlError.cError("BE0003", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("XImpuesto", True)})
                    Exit Sub
                ElseIf vlDataTable.Rows(0)!TipoEstado = 0 Then
                    'TODO:
                    'Cambiar mensaje Impuesto Inactivo
                    Throw New LbControlError.cError("E0576")
                    Exit Sub
                End If
                e.Value = vlDataTable.Rows(0)!ImpuestoClave
                grDesgloseImpuesto.GetRow.Cells("Abreviatura").Value = vlDataTable.Rows(0)!Abreviatura
                grDesgloseImpuesto.GetRow.Cells("Nombre").Value = vlDataTable.Rows(0)!Nombre
            Catch ex As LbControlError.cError
                ex.Mostrar()
                e.Value = e.InitialValue
                e.Cancel = True
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub MGENERAL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

