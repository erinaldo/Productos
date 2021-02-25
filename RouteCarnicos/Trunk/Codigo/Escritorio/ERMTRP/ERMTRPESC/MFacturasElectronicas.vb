Imports ERMTRPLOG
Imports BASMENLOG
Imports lbGeneral
Imports System.Collections.Generic

Public Class MFacturasElectronicas
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
    Public WithEvents BtAceptar As Janus.Windows.EditControls.UIButton
    Public WithEvents BtCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cbFolio As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbFolio As System.Windows.Forms.Label
    Friend WithEvents btEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btBuscar As Janus.Windows.EditControls.UIButton
    Friend WithEvents gbPedidos As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lbTotalFactura As System.Windows.Forms.Label
    Friend WithEvents grPedidos As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebOrdenCompra As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbOrdenCompra As System.Windows.Forms.Label
    Friend WithEvents btBuscarCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebClienteNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebClienteClave As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chClienteGenerico As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents cbFormaPago As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbFormaPago As System.Windows.Forms.Label
    Friend WithEvents ebFechaFacturacion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbFase As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbFase As System.Windows.Forms.Label
    Friend WithEvents lbFechaFacturacion As System.Windows.Forms.Label
    Friend WithEvents ebPais As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbPais As System.Windows.Forms.Label
    Friend WithEvents ebEntidad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbEntidad As System.Windows.Forms.Label
    Friend WithEvents ebMunicipio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbMunicipio As System.Windows.Forms.Label
    Friend WithEvents ebLocalidad As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbLocalidad As System.Windows.Forms.Label
    Friend WithEvents ebReferencia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbReferencia As System.Windows.Forms.Label
    Friend WithEvents ebCodigoPostal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbCodigoPostal As System.Windows.Forms.Label
    Friend WithEvents ebColonia As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbColonia As System.Windows.Forms.Label
    Friend WithEvents ebInterior As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbInterior As System.Windows.Forms.Label
    Friend WithEvents ebExterior As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbExterior As System.Windows.Forms.Label
    Friend WithEvents ebCalle As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbCalle As System.Windows.Forms.Label
    Friend WithEvents ebRFC As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbRFC As System.Windows.Forms.Label
    Friend WithEvents ebClienteDatos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebFolioDatos As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbClienteDatos As System.Windows.Forms.Label
    Friend WithEvents lbFolioDatos As System.Windows.Forms.Label
    Friend WithEvents epErrores As System.Windows.Forms.ErrorProvider
    Friend WithEvents ebTotalFactura As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TabFacturacion As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TpGenerales As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TpDatosFiscales As DevComponents.DotNetBar.TabItem
    Friend WithEvents lbMoneda As System.Windows.Forms.Label
    Friend WithEvents cbMoneda As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents btBuscarEsquema As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebEsquemaNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebEsquemaClave As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chbVentaEsquema As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblEsquema As System.Windows.Forms.Label
    Friend WithEvents BTVistaPrevia As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents btBuscarRuta As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebRutDescripcion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebRutClave As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents btMetodoPago As Janus.Windows.EditControls.UIButton
    Friend WithEvents lbMetodoPago As System.Windows.Forms.Label
    Friend WithEvents grMetodosPago As Janus.Windows.GridEX.GridEX
    Friend WithEvents ebTelefonoContacto As Janus.Windows.GridEX.EditControls.EditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MFacturasElectronicas))
        Dim grPedidos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grMetodosPago_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.BtAceptar = New Janus.Windows.EditControls.UIButton
        Me.BtCancelar = New Janus.Windows.EditControls.UIButton
        Me.ebTelefonoContacto = New Janus.Windows.GridEX.EditControls.EditBox
        Me.gbPedidos = New Janus.Windows.EditControls.UIGroupBox
        Me.lbTotalFactura = New System.Windows.Forms.Label
        Me.BTVistaPrevia = New Janus.Windows.EditControls.UIButton
        Me.btBuscar = New Janus.Windows.EditControls.UIButton
        Me.grPedidos = New Janus.Windows.GridEX.GridEX
        Me.btEliminar = New Janus.Windows.EditControls.UIButton
        Me.ebTotalFactura = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.ebOrdenCompra = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbOrdenCompra = New System.Windows.Forms.Label
        Me.btBuscarCliente = New Janus.Windows.EditControls.UIButton
        Me.ebClienteNombre = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebClienteClave = New Janus.Windows.GridEX.EditControls.EditBox
        Me.chClienteGenerico = New Janus.Windows.EditControls.UICheckBox
        Me.cbFormaPago = New Janus.Windows.EditControls.UIComboBox
        Me.lbFormaPago = New System.Windows.Forms.Label
        Me.ebFechaFacturacion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.cbFase = New Janus.Windows.EditControls.UIComboBox
        Me.lbFase = New System.Windows.Forms.Label
        Me.lbFechaFacturacion = New System.Windows.Forms.Label
        Me.cbFolio = New Janus.Windows.EditControls.UIComboBox
        Me.lbFolio = New System.Windows.Forms.Label
        Me.ebPais = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbPais = New System.Windows.Forms.Label
        Me.ebEntidad = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbEntidad = New System.Windows.Forms.Label
        Me.ebMunicipio = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbMunicipio = New System.Windows.Forms.Label
        Me.ebLocalidad = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbLocalidad = New System.Windows.Forms.Label
        Me.ebReferencia = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbReferencia = New System.Windows.Forms.Label
        Me.ebCodigoPostal = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbCodigoPostal = New System.Windows.Forms.Label
        Me.ebColonia = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbColonia = New System.Windows.Forms.Label
        Me.ebInterior = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbInterior = New System.Windows.Forms.Label
        Me.ebExterior = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbExterior = New System.Windows.Forms.Label
        Me.ebCalle = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbCalle = New System.Windows.Forms.Label
        Me.ebRFC = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbRFC = New System.Windows.Forms.Label
        Me.ebClienteDatos = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebFolioDatos = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbClienteDatos = New System.Windows.Forms.Label
        Me.lbFolioDatos = New System.Windows.Forms.Label
        Me.epErrores = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabFacturacion = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.grMetodosPago = New Janus.Windows.GridEX.GridEX
        Me.btMetodoPago = New Janus.Windows.EditControls.UIButton
        Me.lbMetodoPago = New System.Windows.Forms.Label
        Me.lblRuta = New System.Windows.Forms.Label
        Me.btBuscarRuta = New Janus.Windows.EditControls.UIButton
        Me.ebRutDescripcion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebRutClave = New Janus.Windows.GridEX.EditControls.EditBox
        Me.chbVentaEsquema = New Janus.Windows.EditControls.UICheckBox
        Me.lblCliente = New System.Windows.Forms.Label
        Me.lblEsquema = New System.Windows.Forms.Label
        Me.btBuscarEsquema = New Janus.Windows.EditControls.UIButton
        Me.ebEsquemaNombre = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebEsquemaClave = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbMoneda = New System.Windows.Forms.Label
        Me.cbMoneda = New Janus.Windows.EditControls.UIComboBox
        Me.TpGenerales = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel
        Me.TpDatosFiscales = New DevComponents.DotNetBar.TabItem(Me.components)
        CType(Me.gbPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPedidos.SuspendLayout()
        CType(Me.grPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabFacturacion.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        CType(Me.grMetodosPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtAceptar
        '
        Me.BtAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAceptar.Icon = CType(resources.GetObject("BtAceptar.Icon"), System.Drawing.Icon)
        Me.BtAceptar.Location = New System.Drawing.Point(616, 568)
        Me.BtAceptar.Name = "BtAceptar"
        Me.BtAceptar.Size = New System.Drawing.Size(104, 24)
        Me.BtAceptar.TabIndex = 2
        Me.BtAceptar.Text = "Aceptar"
        Me.BtAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'BtCancelar
        '
        Me.BtCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtCancelar.CausesValidation = False
        Me.BtCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancelar.Icon = CType(resources.GetObject("BtCancelar.Icon"), System.Drawing.Icon)
        Me.BtCancelar.Location = New System.Drawing.Point(728, 568)
        Me.BtCancelar.Name = "BtCancelar"
        Me.BtCancelar.Size = New System.Drawing.Size(104, 24)
        Me.BtCancelar.TabIndex = 3
        Me.BtCancelar.Text = "Cancelar"
        Me.BtCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'ebTelefonoContacto
        '
        Me.ebTelefonoContacto.Location = New System.Drawing.Point(776, 34)
        Me.ebTelefonoContacto.Name = "ebTelefonoContacto"
        Me.ebTelefonoContacto.Size = New System.Drawing.Size(8, 20)
        Me.ebTelefonoContacto.TabIndex = 16
        Me.ebTelefonoContacto.Text = "EditBox1"
        Me.ebTelefonoContacto.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTelefonoContacto.Visible = False
        '
        'gbPedidos
        '
        Me.gbPedidos.BackColor = System.Drawing.Color.Transparent
        Me.gbPedidos.Controls.Add(Me.lbTotalFactura)
        Me.gbPedidos.Controls.Add(Me.BTVistaPrevia)
        Me.gbPedidos.Controls.Add(Me.btBuscar)
        Me.gbPedidos.Controls.Add(Me.grPedidos)
        Me.gbPedidos.Controls.Add(Me.btEliminar)
        Me.gbPedidos.Controls.Add(Me.ebTotalFactura)
        Me.gbPedidos.Location = New System.Drawing.Point(11, 281)
        Me.gbPedidos.Name = "gbPedidos"
        Me.gbPedidos.Size = New System.Drawing.Size(792, 233)
        Me.gbPedidos.TabIndex = 20
        Me.gbPedidos.Text = "Pedidos"
        Me.gbPedidos.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lbTotalFactura
        '
        Me.lbTotalFactura.BackColor = System.Drawing.Color.Transparent
        Me.lbTotalFactura.Location = New System.Drawing.Point(408, 201)
        Me.lbTotalFactura.Name = "lbTotalFactura"
        Me.lbTotalFactura.Size = New System.Drawing.Size(132, 20)
        Me.lbTotalFactura.TabIndex = 3
        Me.lbTotalFactura.Text = "Total Factura"
        Me.lbTotalFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BTVistaPrevia
        '
        Me.BTVistaPrevia.CausesValidation = False
        Me.BTVistaPrevia.Icon = CType(resources.GetObject("BTVistaPrevia.Icon"), System.Drawing.Icon)
        Me.BTVistaPrevia.Location = New System.Drawing.Point(696, 80)
        Me.BTVistaPrevia.Name = "BTVistaPrevia"
        Me.BTVistaPrevia.Size = New System.Drawing.Size(80, 24)
        Me.BTVistaPrevia.TabIndex = 4
        Me.BTVistaPrevia.Text = "Preview"
        Me.BTVistaPrevia.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btBuscar
        '
        Me.btBuscar.CausesValidation = False
        Me.btBuscar.Icon = CType(resources.GetObject("btBuscar.Icon"), System.Drawing.Icon)
        Me.btBuscar.Location = New System.Drawing.Point(696, 18)
        Me.btBuscar.Name = "btBuscar"
        Me.btBuscar.Size = New System.Drawing.Size(80, 24)
        Me.btBuscar.TabIndex = 2
        Me.btBuscar.Text = "Buscar"
        Me.btBuscar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'grPedidos
        '
        grPedidos_DesignTimeLayout.LayoutString = resources.GetString("grPedidos_DesignTimeLayout.LayoutString")
        Me.grPedidos.DesignTimeLayout = grPedidos_DesignTimeLayout
        Me.grPedidos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grPedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grPedidos.GroupByBoxVisible = False
        Me.grPedidos.Location = New System.Drawing.Point(16, 18)
        Me.grPedidos.Name = "grPedidos"
        Me.grPedidos.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grPedidos.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grPedidos.Size = New System.Drawing.Size(672, 174)
        Me.grPedidos.TabIndex = 1
        Me.grPedidos.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        Me.grPedidos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btEliminar
        '
        Me.btEliminar.CausesValidation = False
        Me.btEliminar.Icon = CType(resources.GetObject("btEliminar.Icon"), System.Drawing.Icon)
        Me.btEliminar.Location = New System.Drawing.Point(696, 50)
        Me.btEliminar.Name = "btEliminar"
        Me.btEliminar.Size = New System.Drawing.Size(80, 24)
        Me.btEliminar.TabIndex = 3
        Me.btEliminar.Text = "Eliminar"
        Me.btEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'ebTotalFactura
        '
        Me.ebTotalFactura.DecimalDigits = 2
        Me.ebTotalFactura.Enabled = False
        Me.ebTotalFactura.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.ebTotalFactura.Location = New System.Drawing.Point(544, 201)
        Me.ebTotalFactura.Name = "ebTotalFactura"
        Me.ebTotalFactura.Size = New System.Drawing.Size(144, 20)
        Me.ebTotalFactura.TabIndex = 5
        Me.ebTotalFactura.Text = "$0.00"
        Me.ebTotalFactura.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebTotalFactura.Value = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ebTotalFactura.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebOrdenCompra
        '
        Me.ebOrdenCompra.Location = New System.Drawing.Point(403, 130)
        Me.ebOrdenCompra.MaxLength = 500
        Me.ebOrdenCompra.Name = "ebOrdenCompra"
        Me.ebOrdenCompra.Size = New System.Drawing.Size(400, 20)
        Me.ebOrdenCompra.TabIndex = 17
        Me.ebOrdenCompra.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebOrdenCompra.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbOrdenCompra
        '
        Me.lbOrdenCompra.BackColor = System.Drawing.Color.Transparent
        Me.lbOrdenCompra.Location = New System.Drawing.Point(283, 130)
        Me.lbOrdenCompra.Name = "lbOrdenCompra"
        Me.lbOrdenCompra.Size = New System.Drawing.Size(120, 20)
        Me.lbOrdenCompra.TabIndex = 13
        Me.lbOrdenCompra.Text = "Orden compra"
        Me.lbOrdenCompra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btBuscarCliente
        '
        Me.btBuscarCliente.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Ellipsis
        Me.btBuscarCliente.Location = New System.Drawing.Point(259, 82)
        Me.btBuscarCliente.Name = "btBuscarCliente"
        Me.btBuscarCliente.Size = New System.Drawing.Size(24, 20)
        Me.btBuscarCliente.TabIndex = 12
        Me.btBuscarCliente.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'ebClienteNombre
        '
        Me.ebClienteNombre.Enabled = False
        Me.ebClienteNombre.Location = New System.Drawing.Point(283, 82)
        Me.ebClienteNombre.Name = "ebClienteNombre"
        Me.ebClienteNombre.Size = New System.Drawing.Size(520, 20)
        Me.ebClienteNombre.TabIndex = 13
        Me.ebClienteNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebClienteClave
        '
        Me.ebClienteClave.Location = New System.Drawing.Point(131, 82)
        Me.ebClienteClave.Name = "ebClienteClave"
        Me.ebClienteClave.Size = New System.Drawing.Size(128, 20)
        Me.ebClienteClave.TabIndex = 11
        Me.ebClienteClave.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteClave.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'chClienteGenerico
        '
        Me.chClienteGenerico.BackColor = System.Drawing.Color.Transparent
        Me.chClienteGenerico.Location = New System.Drawing.Point(11, 8)
        Me.chClienteGenerico.Name = "chClienteGenerico"
        Me.chClienteGenerico.Size = New System.Drawing.Size(176, 23)
        Me.chClienteGenerico.TabIndex = 1
        Me.chClienteGenerico.Text = "Factura cliente genérico"
        Me.chClienteGenerico.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cbFormaPago
        '
        Me.cbFormaPago.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbFormaPago.Location = New System.Drawing.Point(131, 130)
        Me.cbFormaPago.Name = "cbFormaPago"
        Me.cbFormaPago.Size = New System.Drawing.Size(128, 20)
        Me.cbFormaPago.TabIndex = 16
        Me.cbFormaPago.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbFormaPago
        '
        Me.lbFormaPago.BackColor = System.Drawing.Color.Transparent
        Me.lbFormaPago.Location = New System.Drawing.Point(11, 130)
        Me.lbFormaPago.Name = "lbFormaPago"
        Me.lbFormaPago.Size = New System.Drawing.Size(120, 20)
        Me.lbFormaPago.TabIndex = 11
        Me.lbFormaPago.Text = "Forma de pago"
        Me.lbFormaPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebFechaFacturacion
        '
        Me.ebFechaFacturacion.Location = New System.Drawing.Point(467, 8)
        Me.ebFechaFacturacion.Name = "ebFechaFacturacion"
        Me.ebFechaFacturacion.Size = New System.Drawing.Size(128, 20)
        Me.ebFechaFacturacion.TabIndex = 3
        Me.ebFechaFacturacion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFechaFacturacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbFase
        '
        Me.cbFase.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbFase.Location = New System.Drawing.Point(675, 8)
        Me.cbFase.Name = "cbFase"
        Me.cbFase.Size = New System.Drawing.Size(128, 20)
        Me.cbFase.TabIndex = 4
        Me.cbFase.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbFase
        '
        Me.lbFase.BackColor = System.Drawing.Color.Transparent
        Me.lbFase.Location = New System.Drawing.Point(613, 8)
        Me.lbFase.Name = "lbFase"
        Me.lbFase.Size = New System.Drawing.Size(57, 20)
        Me.lbFase.TabIndex = 4
        Me.lbFase.Text = "Fase"
        Me.lbFase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbFechaFacturacion
        '
        Me.lbFechaFacturacion.BackColor = System.Drawing.Color.Transparent
        Me.lbFechaFacturacion.Location = New System.Drawing.Point(353, 8)
        Me.lbFechaFacturacion.Name = "lbFechaFacturacion"
        Me.lbFechaFacturacion.Size = New System.Drawing.Size(110, 20)
        Me.lbFechaFacturacion.TabIndex = 2
        Me.lbFechaFacturacion.Text = "Fecha Facturación"
        Me.lbFechaFacturacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbFolio
        '
        Me.cbFolio.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbFolio.Location = New System.Drawing.Point(403, 106)
        Me.cbFolio.Name = "cbFolio"
        Me.cbFolio.Size = New System.Drawing.Size(128, 20)
        Me.cbFolio.TabIndex = 15
        Me.cbFolio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbFolio
        '
        Me.lbFolio.BackColor = System.Drawing.Color.Transparent
        Me.lbFolio.Location = New System.Drawing.Point(283, 106)
        Me.lbFolio.Name = "lbFolio"
        Me.lbFolio.Size = New System.Drawing.Size(120, 20)
        Me.lbFolio.TabIndex = 0
        Me.lbFolio.Text = "Folio"
        Me.lbFolio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebPais
        '
        Me.ebPais.Location = New System.Drawing.Point(608, 312)
        Me.ebPais.MaxLength = 32
        Me.ebPais.Name = "ebPais"
        Me.ebPais.Size = New System.Drawing.Size(184, 20)
        Me.ebPais.TabIndex = 25
        Me.ebPais.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPais.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbPais
        '
        Me.lbPais.BackColor = System.Drawing.Color.Transparent
        Me.lbPais.Location = New System.Drawing.Point(464, 312)
        Me.lbPais.Name = "lbPais"
        Me.lbPais.Size = New System.Drawing.Size(132, 20)
        Me.lbPais.TabIndex = 24
        Me.lbPais.Text = "País"
        Me.lbPais.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebEntidad
        '
        Me.ebEntidad.Location = New System.Drawing.Point(168, 312)
        Me.ebEntidad.MaxLength = 32
        Me.ebEntidad.Name = "ebEntidad"
        Me.ebEntidad.Size = New System.Drawing.Size(184, 20)
        Me.ebEntidad.TabIndex = 23
        Me.ebEntidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEntidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbEntidad
        '
        Me.lbEntidad.BackColor = System.Drawing.Color.Transparent
        Me.lbEntidad.Location = New System.Drawing.Point(24, 312)
        Me.lbEntidad.Name = "lbEntidad"
        Me.lbEntidad.Size = New System.Drawing.Size(132, 20)
        Me.lbEntidad.TabIndex = 22
        Me.lbEntidad.Text = "Entidad"
        Me.lbEntidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebMunicipio
        '
        Me.ebMunicipio.Location = New System.Drawing.Point(608, 280)
        Me.ebMunicipio.MaxLength = 64
        Me.ebMunicipio.Name = "ebMunicipio"
        Me.ebMunicipio.Size = New System.Drawing.Size(184, 20)
        Me.ebMunicipio.TabIndex = 21
        Me.ebMunicipio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebMunicipio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbMunicipio
        '
        Me.lbMunicipio.BackColor = System.Drawing.Color.Transparent
        Me.lbMunicipio.Location = New System.Drawing.Point(464, 280)
        Me.lbMunicipio.Name = "lbMunicipio"
        Me.lbMunicipio.Size = New System.Drawing.Size(132, 20)
        Me.lbMunicipio.TabIndex = 20
        Me.lbMunicipio.Text = "Municipio"
        Me.lbMunicipio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebLocalidad
        '
        Me.ebLocalidad.Location = New System.Drawing.Point(168, 280)
        Me.ebLocalidad.MaxLength = 40
        Me.ebLocalidad.Name = "ebLocalidad"
        Me.ebLocalidad.Size = New System.Drawing.Size(184, 20)
        Me.ebLocalidad.TabIndex = 19
        Me.ebLocalidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebLocalidad.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbLocalidad
        '
        Me.lbLocalidad.BackColor = System.Drawing.Color.Transparent
        Me.lbLocalidad.Location = New System.Drawing.Point(24, 280)
        Me.lbLocalidad.Name = "lbLocalidad"
        Me.lbLocalidad.Size = New System.Drawing.Size(132, 20)
        Me.lbLocalidad.TabIndex = 18
        Me.lbLocalidad.Text = "Localidad"
        Me.lbLocalidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebReferencia
        '
        Me.ebReferencia.Location = New System.Drawing.Point(168, 248)
        Me.ebReferencia.MaxLength = 100
        Me.ebReferencia.Name = "ebReferencia"
        Me.ebReferencia.Size = New System.Drawing.Size(624, 20)
        Me.ebReferencia.TabIndex = 17
        Me.ebReferencia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebReferencia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbReferencia
        '
        Me.lbReferencia.BackColor = System.Drawing.Color.Transparent
        Me.lbReferencia.Location = New System.Drawing.Point(24, 248)
        Me.lbReferencia.Name = "lbReferencia"
        Me.lbReferencia.Size = New System.Drawing.Size(132, 20)
        Me.lbReferencia.TabIndex = 16
        Me.lbReferencia.Text = "Referencia"
        Me.lbReferencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebCodigoPostal
        '
        Me.ebCodigoPostal.Location = New System.Drawing.Point(168, 216)
        Me.ebCodigoPostal.MaxLength = 16
        Me.ebCodigoPostal.Name = "ebCodigoPostal"
        Me.ebCodigoPostal.Size = New System.Drawing.Size(184, 20)
        Me.ebCodigoPostal.TabIndex = 15
        Me.ebCodigoPostal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCodigoPostal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbCodigoPostal
        '
        Me.lbCodigoPostal.BackColor = System.Drawing.Color.Transparent
        Me.lbCodigoPostal.Location = New System.Drawing.Point(24, 216)
        Me.lbCodigoPostal.Name = "lbCodigoPostal"
        Me.lbCodigoPostal.Size = New System.Drawing.Size(132, 20)
        Me.lbCodigoPostal.TabIndex = 14
        Me.lbCodigoPostal.Text = "Código Postal"
        Me.lbCodigoPostal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebColonia
        '
        Me.ebColonia.Location = New System.Drawing.Point(168, 184)
        Me.ebColonia.MaxLength = 64
        Me.ebColonia.Name = "ebColonia"
        Me.ebColonia.Size = New System.Drawing.Size(624, 20)
        Me.ebColonia.TabIndex = 13
        Me.ebColonia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebColonia.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbColonia
        '
        Me.lbColonia.BackColor = System.Drawing.Color.Transparent
        Me.lbColonia.Location = New System.Drawing.Point(24, 184)
        Me.lbColonia.Name = "lbColonia"
        Me.lbColonia.Size = New System.Drawing.Size(132, 20)
        Me.lbColonia.TabIndex = 12
        Me.lbColonia.Text = "Colonia"
        Me.lbColonia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebInterior
        '
        Me.ebInterior.Location = New System.Drawing.Point(608, 152)
        Me.ebInterior.MaxLength = 16
        Me.ebInterior.Name = "ebInterior"
        Me.ebInterior.Size = New System.Drawing.Size(184, 20)
        Me.ebInterior.TabIndex = 11
        Me.ebInterior.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebInterior.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbInterior
        '
        Me.lbInterior.BackColor = System.Drawing.Color.Transparent
        Me.lbInterior.Location = New System.Drawing.Point(464, 152)
        Me.lbInterior.Name = "lbInterior"
        Me.lbInterior.Size = New System.Drawing.Size(132, 20)
        Me.lbInterior.TabIndex = 10
        Me.lbInterior.Text = "Interior"
        Me.lbInterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebExterior
        '
        Me.ebExterior.Location = New System.Drawing.Point(168, 152)
        Me.ebExterior.MaxLength = 16
        Me.ebExterior.Name = "ebExterior"
        Me.ebExterior.Size = New System.Drawing.Size(184, 20)
        Me.ebExterior.TabIndex = 9
        Me.ebExterior.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebExterior.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbExterior
        '
        Me.lbExterior.BackColor = System.Drawing.Color.Transparent
        Me.lbExterior.Location = New System.Drawing.Point(24, 152)
        Me.lbExterior.Name = "lbExterior"
        Me.lbExterior.Size = New System.Drawing.Size(132, 20)
        Me.lbExterior.TabIndex = 8
        Me.lbExterior.Text = "Exterior"
        Me.lbExterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebCalle
        '
        Me.ebCalle.Location = New System.Drawing.Point(168, 120)
        Me.ebCalle.MaxLength = 64
        Me.ebCalle.Name = "ebCalle"
        Me.ebCalle.Size = New System.Drawing.Size(624, 20)
        Me.ebCalle.TabIndex = 7
        Me.ebCalle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebCalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbCalle
        '
        Me.lbCalle.BackColor = System.Drawing.Color.Transparent
        Me.lbCalle.Location = New System.Drawing.Point(24, 120)
        Me.lbCalle.Name = "lbCalle"
        Me.lbCalle.Size = New System.Drawing.Size(132, 20)
        Me.lbCalle.TabIndex = 6
        Me.lbCalle.Text = "Calle"
        Me.lbCalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebRFC
        '
        Me.ebRFC.Location = New System.Drawing.Point(168, 88)
        Me.ebRFC.MaxLength = 20
        Me.ebRFC.Name = "ebRFC"
        Me.ebRFC.Size = New System.Drawing.Size(184, 20)
        Me.ebRFC.TabIndex = 5
        Me.ebRFC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebRFC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbRFC
        '
        Me.lbRFC.BackColor = System.Drawing.Color.Transparent
        Me.lbRFC.Location = New System.Drawing.Point(24, 88)
        Me.lbRFC.Name = "lbRFC"
        Me.lbRFC.Size = New System.Drawing.Size(132, 20)
        Me.lbRFC.TabIndex = 4
        Me.lbRFC.Text = "RFC"
        Me.lbRFC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebClienteDatos
        '
        Me.ebClienteDatos.Location = New System.Drawing.Point(168, 56)
        Me.ebClienteDatos.MaxLength = 128
        Me.ebClienteDatos.Name = "ebClienteDatos"
        Me.ebClienteDatos.Size = New System.Drawing.Size(624, 20)
        Me.ebClienteDatos.TabIndex = 3
        Me.ebClienteDatos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebClienteDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebFolioDatos
        '
        Me.ebFolioDatos.Enabled = False
        Me.ebFolioDatos.Location = New System.Drawing.Point(168, 24)
        Me.ebFolioDatos.Name = "ebFolioDatos"
        Me.ebFolioDatos.Size = New System.Drawing.Size(184, 20)
        Me.ebFolioDatos.TabIndex = 1
        Me.ebFolioDatos.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolioDatos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbClienteDatos
        '
        Me.lbClienteDatos.BackColor = System.Drawing.Color.Transparent
        Me.lbClienteDatos.Location = New System.Drawing.Point(24, 56)
        Me.lbClienteDatos.Name = "lbClienteDatos"
        Me.lbClienteDatos.Size = New System.Drawing.Size(132, 20)
        Me.lbClienteDatos.TabIndex = 2
        Me.lbClienteDatos.Text = "Cliente"
        Me.lbClienteDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbFolioDatos
        '
        Me.lbFolioDatos.BackColor = System.Drawing.Color.Transparent
        Me.lbFolioDatos.Location = New System.Drawing.Point(24, 24)
        Me.lbFolioDatos.Name = "lbFolioDatos"
        Me.lbFolioDatos.Size = New System.Drawing.Size(132, 20)
        Me.lbFolioDatos.TabIndex = 0
        Me.lbFolioDatos.Text = "Folio"
        Me.lbFolioDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'epErrores
        '
        Me.epErrores.ContainerControl = Me
        '
        'TabFacturacion
        '
        Me.TabFacturacion.CanReorderTabs = False
        Me.TabFacturacion.Controls.Add(Me.TabControlPanel1)
        Me.TabFacturacion.Controls.Add(Me.TabControlPanel2)
        Me.TabFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabFacturacion.Location = New System.Drawing.Point(8, 8)
        Me.TabFacturacion.Name = "TabFacturacion"
        Me.TabFacturacion.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabFacturacion.SelectedTabIndex = 1
        Me.TabFacturacion.Size = New System.Drawing.Size(824, 549)
        Me.TabFacturacion.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005Document
        Me.TabFacturacion.TabIndex = 4
        Me.TabFacturacion.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabFacturacion.Tabs.Add(Me.TpGenerales)
        Me.TabFacturacion.Tabs.Add(Me.TpDatosFiscales)
        Me.TabFacturacion.Text = "TabControl1"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.grMetodosPago)
        Me.TabControlPanel1.Controls.Add(Me.btMetodoPago)
        Me.TabControlPanel1.Controls.Add(Me.lbMetodoPago)
        Me.TabControlPanel1.Controls.Add(Me.lblRuta)
        Me.TabControlPanel1.Controls.Add(Me.btBuscarRuta)
        Me.TabControlPanel1.Controls.Add(Me.ebRutDescripcion)
        Me.TabControlPanel1.Controls.Add(Me.ebRutClave)
        Me.TabControlPanel1.Controls.Add(Me.chbVentaEsquema)
        Me.TabControlPanel1.Controls.Add(Me.lblCliente)
        Me.TabControlPanel1.Controls.Add(Me.lblEsquema)
        Me.TabControlPanel1.Controls.Add(Me.btBuscarEsquema)
        Me.TabControlPanel1.Controls.Add(Me.ebEsquemaNombre)
        Me.TabControlPanel1.Controls.Add(Me.ebEsquemaClave)
        Me.TabControlPanel1.Controls.Add(Me.ebTelefonoContacto)
        Me.TabControlPanel1.Controls.Add(Me.lbFolio)
        Me.TabControlPanel1.Controls.Add(Me.gbPedidos)
        Me.TabControlPanel1.Controls.Add(Me.cbFolio)
        Me.TabControlPanel1.Controls.Add(Me.ebOrdenCompra)
        Me.TabControlPanel1.Controls.Add(Me.lbFechaFacturacion)
        Me.TabControlPanel1.Controls.Add(Me.lbOrdenCompra)
        Me.TabControlPanel1.Controls.Add(Me.lbFase)
        Me.TabControlPanel1.Controls.Add(Me.btBuscarCliente)
        Me.TabControlPanel1.Controls.Add(Me.cbFase)
        Me.TabControlPanel1.Controls.Add(Me.ebClienteNombre)
        Me.TabControlPanel1.Controls.Add(Me.ebFechaFacturacion)
        Me.TabControlPanel1.Controls.Add(Me.ebClienteClave)
        Me.TabControlPanel1.Controls.Add(Me.lbMoneda)
        Me.TabControlPanel1.Controls.Add(Me.lbFormaPago)
        Me.TabControlPanel1.Controls.Add(Me.cbMoneda)
        Me.TabControlPanel1.Controls.Add(Me.cbFormaPago)
        Me.TabControlPanel1.Controls.Add(Me.chClienteGenerico)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(824, 523)
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.TpGenerales
        '
        'grMetodosPago
        '
        grMetodosPago_DesignTimeLayout.LayoutString = resources.GetString("grMetodosPago_DesignTimeLayout.LayoutString")
        Me.grMetodosPago.DesignTimeLayout = grMetodosPago_DesignTimeLayout
        Me.grMetodosPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grMetodosPago.GroupByBoxVisible = False
        Me.grMetodosPago.Location = New System.Drawing.Point(14, 179)
        Me.grMetodosPago.Name = "grMetodosPago"
        Me.grMetodosPago.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grMetodosPago.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grMetodosPago.Size = New System.Drawing.Size(399, 95)
        Me.grMetodosPago.TabIndex = 19
        Me.grMetodosPago.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        Me.grMetodosPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btMetodoPago
        '
        Me.btMetodoPago.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Ellipsis
        Me.btMetodoPago.Location = New System.Drawing.Point(131, 155)
        Me.btMetodoPago.Name = "btMetodoPago"
        Me.btMetodoPago.Size = New System.Drawing.Size(24, 20)
        Me.btMetodoPago.TabIndex = 18
        Me.btMetodoPago.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'lbMetodoPago
        '
        Me.lbMetodoPago.BackColor = System.Drawing.Color.Transparent
        Me.lbMetodoPago.Location = New System.Drawing.Point(11, 154)
        Me.lbMetodoPago.Name = "lbMetodoPago"
        Me.lbMetodoPago.Size = New System.Drawing.Size(120, 20)
        Me.lbMetodoPago.TabIndex = 35
        Me.lbMetodoPago.Text = "Metodo de Pago"
        Me.lbMetodoPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRuta
        '
        Me.lblRuta.BackColor = System.Drawing.Color.Transparent
        Me.lblRuta.Location = New System.Drawing.Point(11, 34)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(120, 20)
        Me.lblRuta.TabIndex = 31
        Me.lblRuta.Text = "Ruta"
        Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btBuscarRuta
        '
        Me.btBuscarRuta.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Ellipsis
        Me.btBuscarRuta.Location = New System.Drawing.Point(259, 34)
        Me.btBuscarRuta.Name = "btBuscarRuta"
        Me.btBuscarRuta.Size = New System.Drawing.Size(24, 20)
        Me.btBuscarRuta.TabIndex = 6
        Me.btBuscarRuta.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'ebRutDescripcion
        '
        Me.ebRutDescripcion.Enabled = False
        Me.ebRutDescripcion.Location = New System.Drawing.Point(283, 34)
        Me.ebRutDescripcion.Name = "ebRutDescripcion"
        Me.ebRutDescripcion.Size = New System.Drawing.Size(520, 20)
        Me.ebRutDescripcion.TabIndex = 7
        Me.ebRutDescripcion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebRutDescripcion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebRutClave
        '
        Me.ebRutClave.Location = New System.Drawing.Point(131, 34)
        Me.ebRutClave.Name = "ebRutClave"
        Me.ebRutClave.Size = New System.Drawing.Size(128, 20)
        Me.ebRutClave.TabIndex = 5
        Me.ebRutClave.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebRutClave.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'chbVentaEsquema
        '
        Me.chbVentaEsquema.BackColor = System.Drawing.Color.Transparent
        Me.chbVentaEsquema.Location = New System.Drawing.Point(193, 8)
        Me.chbVentaEsquema.Name = "chbVentaEsquema"
        Me.chbVentaEsquema.Size = New System.Drawing.Size(149, 23)
        Me.chbVentaEsquema.TabIndex = 2
        Me.chbVentaEsquema.Text = "Ventas de Esquema"
        Me.chbVentaEsquema.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lblCliente
        '
        Me.lblCliente.BackColor = System.Drawing.Color.Transparent
        Me.lblCliente.Location = New System.Drawing.Point(11, 82)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(120, 20)
        Me.lblCliente.TabIndex = 22
        Me.lblCliente.Text = "Cliente"
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEsquema
        '
        Me.lblEsquema.BackColor = System.Drawing.Color.Transparent
        Me.lblEsquema.Location = New System.Drawing.Point(11, 58)
        Me.lblEsquema.Name = "lblEsquema"
        Me.lblEsquema.Size = New System.Drawing.Size(120, 20)
        Me.lblEsquema.TabIndex = 21
        Me.lblEsquema.Text = "Esquema"
        Me.lblEsquema.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btBuscarEsquema
        '
        Me.btBuscarEsquema.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Ellipsis
        Me.btBuscarEsquema.Location = New System.Drawing.Point(259, 58)
        Me.btBuscarEsquema.Name = "btBuscarEsquema"
        Me.btBuscarEsquema.Size = New System.Drawing.Size(24, 20)
        Me.btBuscarEsquema.TabIndex = 9
        Me.btBuscarEsquema.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'ebEsquemaNombre
        '
        Me.ebEsquemaNombre.Enabled = False
        Me.ebEsquemaNombre.Location = New System.Drawing.Point(283, 58)
        Me.ebEsquemaNombre.Name = "ebEsquemaNombre"
        Me.ebEsquemaNombre.Size = New System.Drawing.Size(520, 20)
        Me.ebEsquemaNombre.TabIndex = 10
        Me.ebEsquemaNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEsquemaNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebEsquemaClave
        '
        Me.ebEsquemaClave.Enabled = False
        Me.ebEsquemaClave.Location = New System.Drawing.Point(131, 58)
        Me.ebEsquemaClave.Name = "ebEsquemaClave"
        Me.ebEsquemaClave.Size = New System.Drawing.Size(128, 20)
        Me.ebEsquemaClave.TabIndex = 8
        Me.ebEsquemaClave.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebEsquemaClave.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbMoneda
        '
        Me.lbMoneda.BackColor = System.Drawing.Color.Transparent
        Me.lbMoneda.Location = New System.Drawing.Point(11, 106)
        Me.lbMoneda.Name = "lbMoneda"
        Me.lbMoneda.Size = New System.Drawing.Size(120, 20)
        Me.lbMoneda.TabIndex = 11
        Me.lbMoneda.Text = "Moneda"
        Me.lbMoneda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbMoneda
        '
        Me.cbMoneda.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbMoneda.Location = New System.Drawing.Point(131, 106)
        Me.cbMoneda.Name = "cbMoneda"
        Me.cbMoneda.Size = New System.Drawing.Size(128, 20)
        Me.cbMoneda.TabIndex = 14
        Me.cbMoneda.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TpGenerales
        '
        Me.TpGenerales.AttachedControl = Me.TabControlPanel1
        Me.TpGenerales.Name = "TpGenerales"
        Me.TpGenerales.Text = "TpGenerales"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.ebPais)
        Me.TabControlPanel2.Controls.Add(Me.lbFolioDatos)
        Me.TabControlPanel2.Controls.Add(Me.lbPais)
        Me.TabControlPanel2.Controls.Add(Me.lbClienteDatos)
        Me.TabControlPanel2.Controls.Add(Me.ebEntidad)
        Me.TabControlPanel2.Controls.Add(Me.ebFolioDatos)
        Me.TabControlPanel2.Controls.Add(Me.lbEntidad)
        Me.TabControlPanel2.Controls.Add(Me.ebClienteDatos)
        Me.TabControlPanel2.Controls.Add(Me.ebMunicipio)
        Me.TabControlPanel2.Controls.Add(Me.lbRFC)
        Me.TabControlPanel2.Controls.Add(Me.lbMunicipio)
        Me.TabControlPanel2.Controls.Add(Me.ebRFC)
        Me.TabControlPanel2.Controls.Add(Me.ebLocalidad)
        Me.TabControlPanel2.Controls.Add(Me.lbCalle)
        Me.TabControlPanel2.Controls.Add(Me.lbLocalidad)
        Me.TabControlPanel2.Controls.Add(Me.ebCalle)
        Me.TabControlPanel2.Controls.Add(Me.ebReferencia)
        Me.TabControlPanel2.Controls.Add(Me.lbExterior)
        Me.TabControlPanel2.Controls.Add(Me.lbReferencia)
        Me.TabControlPanel2.Controls.Add(Me.ebExterior)
        Me.TabControlPanel2.Controls.Add(Me.ebCodigoPostal)
        Me.TabControlPanel2.Controls.Add(Me.lbInterior)
        Me.TabControlPanel2.Controls.Add(Me.lbCodigoPostal)
        Me.TabControlPanel2.Controls.Add(Me.ebInterior)
        Me.TabControlPanel2.Controls.Add(Me.ebColonia)
        Me.TabControlPanel2.Controls.Add(Me.lbColonia)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(824, 523)
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.TpDatosFiscales
        '
        'TpDatosFiscales
        '
        Me.TpDatosFiscales.AttachedControl = Me.TabControlPanel2
        Me.TpDatosFiscales.Name = "TpDatosFiscales"
        Me.TpDatosFiscales.Text = "TpDatosFiscales"
        '
        'MFacturasElectronicas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(840, 598)
        Me.Controls.Add(Me.TabFacturacion)
        Me.Controls.Add(Me.BtAceptar)
        Me.Controls.Add(Me.BtCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MFacturasElectronicas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MFacturasElectronicas"
        CType(Me.gbPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPedidos.ResumeLayout(False)
        Me.gbPedidos.PerformLayout()
        CType(Me.grPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabFacturacion.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        CType(Me.grMetodosPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanel2.ResumeLayout(False)
        Me.TabControlPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Variables "
    Private tModo As eModo
    Private oTransProd As New cTransProd
    Private oTRPDatoFiscal As cTRPDatoFiscal
    Private oAlmacen As New ERMALMLOG.cAlmacen
    Private oProducto As New ERMPROLOG.cProducto
    Private oMensaje As New CMensaje
    Private bHuboCambios As Boolean = False
    Private bCerrar As Boolean = False
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private sComponente As String = "ERMTRPESC"
    Private htCampos As Hashtable = New Hashtable(20)
    Private htElemInterfaz As Hashtable = New Hashtable(10)
    Private bModificarTransProd As Boolean = False
    Private bCargado As Boolean = False
    Private sNombre As String
    Private bModificandoDatos As Boolean = False
    Private oCliente As New ERMCLILOG.cCliente
    Private oConfiguracion As New ERMCONLOG.cConfiguracion
    Private oSubEmpresa As New ERMSEMLOG.cSubEmpresa
    Private oVendedor As New ERMVENLOG.cVendedor
    Private bEditarDatos As Boolean = False
    Private sEsquemaId As String
    Private sIdFiscal As String

    Dim strTerminalClave As String
    Dim strVendedorId As String
    Dim bIniciando As Boolean
    Dim bClienteValido As Boolean
    Dim htActualizarTVA As Hashtable

    'Dim dtCamposSolicitados As DataTable
#End Region

#Region " Métodos y Funciones "


    Public Function CREAR(ByRef prTransProd As cTransProd, ByVal SubEmpresasValidas() As ERMSEMLOG.cSubEmpresa) As Boolean
        Dim oFolio As New ERMFOLLOG.cFolio

        bIniciando = True
        sEsquemaId = String.Empty
        sIdFiscal = String.Empty

        ebRutClave.Enabled = False
        btBuscarRuta.Enabled = False

        'rbtEsquema.Checked = True
        ebClienteClave.Enabled = False
        btBuscarCliente.Enabled = False

        oConfiguracion.Recuperar()
        LlenarCbMonedas()
        cbMoneda.SelectedIndex = 0
        If SubEmpresasValidas.Length > 0 Then
            oSubEmpresa = SubEmpresasValidas.GetValue(0)
        End If

        ObtenerFolio()

        Dim ldtTabla As DataTable = oVendedor.Tabla.Recuperar("USUId='" & lbGeneral.cParametros.UsuarioID & "' AND TipoEstado=1")
        If ldtTabla.Rows.Count > 0 Then
            strTerminalClave = IIf(IsDBNull(ldtTabla.Rows(0)!TerminalClave), "", ldtTabla.Rows(0)!TerminalClave)
            strVendedorId = ldtTabla.Rows(0)!VendedorId
            bEditarDatos = ldtTabla.Rows(0)!EditarDatosFiscal

            Dim loVENRUT As New ERMVERLOG.Amesol.CVenRut
            If loVENRUT.TablaNodo.Recuperar("VendedorId='" & strVendedorId & "' AND TipoEstado=1").Rows.Count > 0 Then
                Throw New LbControlError.cError("E0661")
            End If
        Else
            Throw New LbControlError.cError("E0666")
        End If


        If oSubEmpresa.FoliosTerminal Then
            cbFolio.DataSource = oFolio.ObtenerFolioFiscal(strTerminalClave, Nothing, oSubEmpresa.SubEmpresaID, 1)
        Else
            cbFolio.DataSource = oFolio.ObtenerFolioFiscal(Nothing, strVendedorId, oSubEmpresa.SubEmpresaID, 1)
        End If
        'cbFolio.DataMember = "FolioFiscal"
        cbFolio.ValueMember = "FolioIdFOSId"
        cbFolio.DisplayMember = "Folio"
        cbFolio.SelectedValue = CType(cbFolio.DataSource, DataTable).Rows(0)!FolioIdFOSId
        ebFolioDatos.Text = CType(cbFolio.DataSource, DataTable).Rows(0)!Folio

        tModo = eModo.Crear
        oTransProd = prTransProd

        sNombre = Me.Name
        Me.Text = oMensaje.RecuperarDescripcion(sComponente & "_" & sNombre & "C")
        bIniciando = False
        Return IniciarPantalla()
    End Function

    Private Sub LlenarCbMonedas()
        Dim dtMonedas As DataTable = oConexion.EjecutarConsulta("Select MonedaID, Nombre from Moneda where TipoEstado = 1 ")

        cbMoneda.DataSource = dtMonedas

        cbMoneda.DisplayMember = "Nombre"
        cbMoneda.ValueMember = "MonedaID"
    End Sub

    Public Function CANCELAR(ByRef prTransProd As cTransProd) As Boolean
        tModo = eModo.Cancelar
        oTransProd = prTransProd
        oConfiguracion.Recuperar()

        sNombre = Me.Name
        Me.Text = oMensaje.RecuperarDescripcion(sComponente & "_" & sNombre & "CA")

        oTRPDatoFiscal = New cTRPDatoFiscal(oTransProd)
        LlenarCbMonedas()
        bIniciando = True
        cbMoneda.SelectedValue = oTransProd.MonedaID
        bIniciando = False

        oTRPDatoFiscal.Recuperar(oTransProd.TransProdID)

        Return IniciarPantalla()
    End Function

    Public Function LEER(ByRef prTransProd As cTransProd) As Boolean
        tModo = eModo.Leer
        oTransProd = prTransProd
        oConfiguracion.Recuperar()

        sNombre = Me.Name
        Me.Text = oMensaje.RecuperarDescripcion(sComponente & "_" & sNombre & "L")

        oTRPDatoFiscal = New cTRPDatoFiscal(oTransProd)
        LlenarCbMonedas()
        bIniciando = True
        cbMoneda.SelectedValue = oTransProd.MonedaID
        bIniciando = False
        oTRPDatoFiscal.Recuperar(oTransProd.TransProdID)
        Return IniciarPantalla()
    End Function

    'Private Sub LlenarComplemento(ByVal pvClave As String, ByVal pvFolio As String)

    '    Dim oAddenda As ERMADDLOG.cAddenda = New ERMADDLOG.cAddenda()
    '    Dim sClienteClave As String = oConexion.EjecutarComandoScalar("Select ClienteClave from Cliente where Clave='" & pvClave & "' ")

    '    Dim dtCamposSolicitados As DataTable
    '    If tModo = eModo.Crear Then
    '        dtCamposSolicitados = oAddenda.ObtenerSolicitadosCliente(sClienteClave)
    '    Else
    '        dtCamposSolicitados = oAddenda.ObtenerSolicitadosFactura(oTransProd.TransProdID)
    '    End If

    '    If (dtCamposSolicitados.Rows.Count > 0) Then
    '        Dim dtCapturados As DataTable = oTransProd.AddendaFactura.ToDataTable
    '        Dim icont As Integer = dtCamposSolicitados.Rows.Count
    '        TpComplemento.Visible = True
    '        Dim PosX As Integer = 11
    '        Dim PosY As Integer = 8
    '        Dim drs() As DataRow
    '        For Each dr As DataRow In dtCamposSolicitados.Rows
    '            Dim ctrl As New CtrlCampos(oMensaje)
    '            ctrl.AgregarCampo(dr("Etiqueta"), dr("Valor"), dr("ADDDID"), dr("Requerido"), dr("TipoDato"), dr("LongMin"), dr("LongMax"))
    '            ctrl.TabIndex = icont
    '            drs = dtCapturados.Select("ADDDID='" & dr("ADDDID") & "'")
    '            If drs.Length > 0 Then
    '                ctrl.Valor = drs(0)("Valor")
    '            End If
    '            TabControlPanel3.Controls.Add(ctrl)
    '            ctrl.Dock = DockStyle.Top
    '            ctrl.Enabled = False
    '            icont -= 1
    '        Next
    '    Else
    '        TpComplemento.Visible = False
    '    End If
    '    dtCamposSolicitados.Dispose()
    'End Sub

    Private Function IniciarPantalla() As Boolean
        'oTransProd.Tabla.Campos("MUsuarioId").Tipo = LbDatos.ETipo.Cadena

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        CrearObjetosCamposLogicos()
        CrearObjetosInterfaz()
        ConfigurarInterfaz()

        Me.TpDatosFiscales.Text = oMensaje.RecuperarDescripcion("XDatosFiscales")
        Me.TpGenerales.Text = oMensaje.RecuperarDescripcion("XGenerales")
        Me.lbMoneda.Text = oMensaje.RecuperarDescripcion("XMoneda")
        'Me.TpComplemento.Text = oMensaje.RecuperarDescripcion("XComplemento")

        If tModo = eModo.Crear Then
            ebFechaFacturacion.Text = oConexion.ObtenerFecha.ToShortDateString
            ebFechaFacturacion.Enabled = False
            cbFase.Enabled = False
            cbFormaPago.Enabled = False
            btEliminar.Enabled = False

            ebClienteDatos.Enabled = False
            ebRFC.Enabled = False
            ebCalle.Enabled = False
            ebExterior.Enabled = False
            ebInterior.Enabled = False
            ebColonia.Enabled = False
            ebCodigoPostal.Enabled = False
            ebReferencia.Enabled = False
            ebLocalidad.Enabled = False
            ebMunicipio.Enabled = False
            ebEntidad.Enabled = False
            ebPais.Enabled = False
        ElseIf tModo = eModo.Leer Then
            cbFolio.Enabled = False
            ebFechaFacturacion.Enabled = False
            chClienteGenerico.Enabled = False
            chbVentaEsquema.Enabled = False
            ebRutClave.Enabled = False
            btBuscarRuta.Enabled = False
            btBuscarEsquema.Enabled = False
            ebClienteClave.Enabled = False
            btBuscarCliente.Enabled = False
            cbFase.Enabled = False
            cbFormaPago.Enabled = False
            ebOrdenCompra.Enabled = False
            btBuscar.Enabled = False
            btEliminar.Enabled = False
            btMetodoPago.Enabled = False

            ebClienteDatos.Enabled = False
            ebRFC.Enabled = False
            ebCalle.Enabled = False
            ebExterior.Enabled = False
            ebInterior.Enabled = False
            ebColonia.Enabled = False
            ebCodigoPostal.Enabled = False
            ebReferencia.Enabled = False
            ebLocalidad.Enabled = False
            ebMunicipio.Enabled = False
            ebEntidad.Enabled = False
            ebPais.Enabled = False

            BtAceptar.Visible = False
            BtCancelar.Text = oMensaje.RecuperarDescripcion("BTRegresar")

            cbMoneda.Enabled = False
        ElseIf tModo = eModo.Cancelar Then
            cbFolio.Enabled = False
            ebFechaFacturacion.Enabled = False
            chClienteGenerico.Enabled = False
            chbVentaEsquema.Enabled = False
            ebRutClave.Enabled = False
            btBuscarRuta.Enabled = False
            btBuscarEsquema.Enabled = False
            ebClienteClave.Enabled = False
            btBuscarCliente.Enabled = False
            cbFase.Enabled = False
            cbFormaPago.Enabled = False
            ebOrdenCompra.Enabled = False
            btBuscar.Enabled = False
            btEliminar.Enabled = False
            btMetodoPago.Enabled = False

            ebClienteDatos.Enabled = False
            ebRFC.Enabled = False
            ebCalle.Enabled = False
            ebExterior.Enabled = False
            ebInterior.Enabled = False
            ebColonia.Enabled = False
            ebCodigoPostal.Enabled = False
            ebReferencia.Enabled = False
            ebLocalidad.Enabled = False
            ebMunicipio.Enabled = False
            ebEntidad.Enabled = False
            ebPais.Enabled = False

            cbMoneda.Enabled = False
        End If

        'LlenarComplemento(ebClienteClave.Text, cbFolio.Text)
        bCargado = True
        Me.Cursor = System.Windows.Forms.Cursors.Default
        bHuboCambios = False

        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            oConexion.ConfirmarTran()

            Return True
        Else
            oConexion.DeshacerTran()

            Return False
        End If
    End Function

    Private Sub CrearObjetosCamposLogicos()
        CrearCampoLogico(oTransProd.Mnemonico, "Folio", CType(Me.lbFolio, Control), CType(Me.cbFolio, Control), True, "", True)
        CrearCampoLogico(oTransProd.Mnemonico, "FechaFacturacion", CType(Me.lbFechaFacturacion, Control), CType(Me.ebFechaFacturacion, Control), True)
        CrearCampoLogico(oTransProd.Mnemonico, "TipoFase", CType(Me.lbFase, Control), CType(Me.cbFase, Control), True)
        CrearCampoLogico("X", "Ruta", CType(Me.lblRuta, Control), CType(Me.ebRutClave, Control), True)
        CrearCampoLogico("CLE", "EsquemaID", CType(Me.lblEsquema, Control), CType(Me.ebEsquemaClave, Control), True)
        CrearCampoLogico("CFV", "ClienteClave", CType(Me.lblCliente, Control), CType(Me.ebClienteClave, Control), True)
        CrearCampoLogico(oTransProd.Mnemonico, "CFVTipo", CType(Me.lbFormaPago, Control), CType(Me.cbFormaPago, Control), True)
        CrearCampoLogico("X", "OrdendeCompra", CType(Me.lbOrdenCompra, Control), CType(Me.ebOrdenCompra, Control), False)
        CrearCampoLogico("X", "FacturaClienteGenerico", CType(Me.chClienteGenerico, Control), CType(Me.chClienteGenerico, Control), False)
        CrearCampoLogico("X", "VentaPorEsquema", CType(Me.chbVentaEsquema, Control), CType(Me.chbVentaEsquema, Control), False)

        CrearCampoLogico("TR", "PFolio", CType(Me.lbFolioDatos, Control), CType(Me.ebFolioDatos, Control), True)
        CrearCampoLogico("X", "Cliente", CType(Me.lbClienteDatos, Control), CType(Me.ebClienteDatos, Control), True)
        CrearCampoLogico("CLI", "IdFiscal", CType(Me.lbRFC, Control), CType(Me.ebRFC, Control), True)
        CrearCampoLogico("CLD", "Calle", CType(Me.lbCalle, Control), CType(Me.ebCalle, Control), True)
        CrearCampoLogico("CLD", "Numero", CType(Me.lbExterior, Control), CType(Me.ebExterior, Control))
        CrearCampoLogico("CLD", "NumInt", CType(Me.lbInterior, Control), CType(Me.ebInterior, Control))
        CrearCampoLogico("CLD", "Colonia", CType(Me.lbColonia, Control), CType(Me.ebColonia, Control))
        CrearCampoLogico("CLD", "CodigoPostal", CType(Me.lbCodigoPostal, Control), CType(Me.ebCodigoPostal, Control), True)
        CrearCampoLogico("CLD", "ReferenciaDom", CType(Me.lbReferencia, Control), CType(Me.ebReferencia, Control))
        CrearCampoLogico("CLD", "Localidad", CType(Me.lbLocalidad, Control), CType(Me.ebLocalidad, Control))
        CrearCampoLogico("CLD", "Poblacion", CType(Me.lbMunicipio, Control), CType(Me.ebMunicipio, Control), True)
        CrearCampoLogico("CLD", "Entidad", CType(Me.lbEntidad, Control), CType(Me.ebEntidad, Control), True)
        CrearCampoLogico("CLD", "Pais", CType(Me.lbPais, Control), CType(Me.ebPais, Control), True)

    End Sub

    Private Function CrearCampoLogico(ByVal pvMnemonico As String, ByVal pvCampo As String, ByRef prCtrlEtiqueta As System.Windows.Forms.Control, ByRef prCtrlCaptura As System.Windows.Forms.Control, Optional ByVal pvRequerido As Boolean = False, Optional ByVal pvValorReferencia As String = "", Optional ByVal pvLlave As Boolean = False) As ManejoCampoLogico
        Dim oCL As ManejoCampoLogico
        oCL = New ManejoCampoLogico(pvMnemonico, pvCampo, prCtrlEtiqueta, prCtrlCaptura, pvRequerido, pvValorReferencia, pvLlave)
        htCampos.Add(oCL.Campo, oCL)
        oCL.CtrlCaptura.Tag = oCL
        Return oCL
    End Function

    Private Sub CrearObjetosInterfaz()
        'aqui se agregan los botones, etc
        Dim oEI As ManejoElementoInterfaz


        oEI = New ManejoElementoInterfaz(sComponente & "_" & Me.Name & "_gbP", CType(Me.gbPedidos, Control), True, False)
        htElemInterfaz.Add(oEI.Nombre, oEI)

        oEI = New ManejoElementoInterfaz("BTEliminar", CType(Me.btEliminar, Control))
        htElemInterfaz.Add(oEI.Nombre, oEI)
        oEI = New ManejoElementoInterfaz("BTBuscar", CType(Me.btBuscar, Control))
        htElemInterfaz.Add(oEI.Nombre, oEI)
        oEI = New ManejoElementoInterfaz("XTotalFactura", CType(Me.lbTotalFactura, Control), True, False)
        htElemInterfaz.Add(oEI.Nombre, oEI)
        oEI = New ManejoElementoInterfaz("BTAceptar", CType(Me.BtAceptar, Control))
        htElemInterfaz.Add(oEI.Nombre, oEI)
        oEI = New ManejoElementoInterfaz("BTCancelar", CType(Me.BtCancelar, Control))
        htElemInterfaz.Add(oEI.Nombre, oEI)
        oEI = New ManejoElementoInterfaz("BTVistaPreviaPedido", CType(Me.BTVistaPrevia, Control))
        htElemInterfaz.Add(oEI.Nombre, oEI)

    End Sub

    Private Sub ConfigurarInterfaz()
        Dim oEI As ManejoElementoInterfaz
        Dim oCL As ManejoCampoLogico
        Dim lToolTip As New System.Windows.Forms.ToolTip

        'Titulos Controles
        For Each oCL In htCampos.Values
            oCL.FijarTexto(oMensaje)
            oCL.FijarTooltip(oMensaje, lToolTip)
            oCL.CargarValorReferencia()
        Next
        lToolTip.SetToolTip(ebClienteDatos, "CLIRazonSocial")
        lbFormaPago.Text = oMensaje.RecuperarDescripcion("ABDTipoPago")

        'Titulos Botones
        For Each oEI In htElemInterfaz.Values
            oEI.FijarTexto(oMensaje)
            oEI.FijarTooltip(oMensaje, lToolTip)
        Next
        'lToolTip.SetToolTip(ebOrdenCompra, "")

        lbGeneral.LlenarComboBox(cbFase, "TRPFASE", 1)
        cbFase.SelectedValue = 1
        lbGeneral.LlenarComboBox(cbFormaPago, "FVENTA")

        grPedidos.RootTable.Columns("Folio").Caption = oMensaje.RecuperarDescripcion("TRPFolio")
        grPedidos.RootTable.Columns("Folio").HeaderToolTip = oMensaje.RecuperarDescripcion("TRPFolioT")
        grPedidos.RootTable.Columns("Folio").EditType = Janus.Windows.GridEX.EditType.NoEdit
        grPedidos.RootTable.Columns("FechaHoraAlta").Caption = oMensaje.RecuperarDescripcion("TRPFecha")
        grPedidos.RootTable.Columns("FechaHoraAlta").HeaderToolTip = oMensaje.RecuperarDescripcion("TRPFecha")
        grPedidos.RootTable.Columns("FechaHoraAlta").EditType = Janus.Windows.GridEX.EditType.NoEdit
        grPedidos.RootTable.Columns("Total").Caption = oMensaje.RecuperarDescripcion("TRPTotal")
        grPedidos.RootTable.Columns("Total").HeaderToolTip = oMensaje.RecuperarDescripcion("TRPTotal")
        grPedidos.RootTable.Columns("Total").EditType = Janus.Windows.GridEX.EditType.NoEdit
        grPedidos.RootTable.Columns("NombreCorto").Caption = oMensaje.RecuperarDescripcion("XCliente")
        grPedidos.RootTable.Columns("NombreCorto").HeaderToolTip = oMensaje.RecuperarDescripcion("CLINombreCortoT")
        grPedidos.RootTable.Columns("NombreCorto").EditType = Janus.Windows.GridEX.EditType.NoEdit
        grPedidos.RootTable.Columns("PedidoAdicional").Caption = oMensaje.RecuperarDescripcion("TVAPedidoAdicional")
        grPedidos.RootTable.Columns("PedidoAdicional").HeaderToolTip = oMensaje.RecuperarDescripcion("TVAPedidoAdicionalT")
        If tModo = eModo.Crear Then
            grPedidos.RootTable.Columns("PedidoAdicional").EditType = Janus.Windows.GridEX.EditType.TextBox
        Else
            grPedidos.RootTable.Columns("PedidoAdicional").EditType = Janus.Windows.GridEX.EditType.NoEdit
        End If

        grMetodosPago.RootTable.Columns("Metodo").Caption = oMensaje.RecuperarDescripcion("TDFMetodoPago")
        grMetodosPago.RootTable.Columns("Metodo").HeaderToolTip = oMensaje.RecuperarDescripcion("TDFMetodoPagoT")
        grMetodosPago.RootTable.Columns("Cuenta").Caption = oMensaje.RecuperarDescripcion("TDFNumerosCuenta")
        grMetodosPago.RootTable.Columns("Cuenta").HeaderToolTip = oMensaje.RecuperarDescripcion("TDFNumerosCuentaT")
        grMetodosPago.RootTable.Columns("Banco").Caption = oMensaje.RecuperarDescripcion("TDFBanco")
        grMetodosPago.RootTable.Columns("Banco").HeaderToolTip = oMensaje.RecuperarDescripcion("TDFBancoT")

        'Configurar Grid
        ConfiguraGrid()

        bHuboCambios = False
    End Sub

    Public Sub ConfiguraGrid()
        Select Case tModo
            Case eModo.Crear
                Dim ldt As New DataTable("TransProd")
                ldt.Columns.Add("TransProdId", GetType(String))
                ldt.Columns.Add("Folio", GetType(String))
                ldt.Columns.Add("FechaHoraAlta", GetType(Date))
                ldt.Columns.Add("Total", GetType(Double))
                ldt.Columns.Add("NombreCorto", GetType(String))
                ldt.Columns.Add("PedidoAdicional", GetType(String))
                grPedidos.DataSource = ldt
                grPedidos.DataMember = "TransProd"
            Case eModo.Leer, eModo.Cancelar
                CargarDatos()
        End Select
    End Sub

    Private Sub PonerTitulosGrid(ByVal prGrid As Janus.Windows.GridEX.GridEX, ByVal sNemonico As String)
        With prGrid.RootTable
            For Each lColumna As Janus.Windows.GridEX.GridEXColumn In .Columns
                lColumna.Caption = oMensaje.RecuperarDescripcion(sNemonico & lColumna.Key)
                lColumna.HeaderToolTip = oMensaje.RecuperarDescripcion(sNemonico & lColumna.Key & "T")
            Next
        End With
    End Sub

    Private Sub CargarDatos()
        Dim lsClienteClave As String
        Dim oCliente As New ERMCLILOG.cCliente

        With oTransProd
            lsClienteClave = oConexion.EjecutarConsulta("SELECT ClienteClave FROM Visita WHERE VisitaClave='" & .VisitaClave & "' AND DiaClave='" & .DiaClave & "'").Rows(0)!ClienteClave
            oCliente.Recuperar(lsClienteClave)

            oSubEmpresa.Recuperar(.SubEmpresaId, .FechaHoraAlta)

            sEsquemaId = oCliente.ClienteEsquema.ToDataTable.Select("TipoEstado = 1").GetValue(0)("EsquemaId")
            Dim dtEsq As DataTable = oConexion.EjecutarConsulta("select Clave, Nombre from Esquema where EsquemaId = '" & sEsquemaId & "'")
            If dtEsq.Rows.Count > 0 Then
                Me.ebEsquemaClave.Text = dtEsq.Rows(0)("Clave")
                Me.ebEsquemaNombre.Text = dtEsq.Rows(0)("Nombre")
            End If

            Me.cbFolio.Text = .Folio
            Me.ebFolioDatos.Text = .Folio
            Me.ebFechaFacturacion.Text = .FechaHoraAlta
            Me.cbFase.SelectedValue = .TipoFase
            If oSubEmpresa.ClienteClave = oCliente.ClienteClave Then
                chClienteGenerico.Checked = True
                Dim sRUTClave As String = .ObtenerRutaFactura()
                If sRUTClave <> "" Then
                    Dim oRuta As New ERMRUTLOG.cRuta
                    If oRuta.Existe(sRUTClave) Then
                        oRuta.Recuperar(sRUTClave)
                        ebRutClave.Text = oRuta.RUTClave
                        ebRutDescripcion.Text = oRuta.Descripcion
                    End If
                End If
            End If

            Me.ebClienteClave.Text = oCliente.Clave
            ebClienteNombre.Text = oCliente.RazonSocial
            ebClienteDatos.Text = oCliente.RazonSocial
            ebRFC.Text = oCliente.IdFiscal
            ebTelefonoContacto.Text = oCliente.TelefonoContacto
            Me.ebLocalidad.Text = oCliente.ClienteDomicilio(0).Localidad.ToString

            ebCalle.Text = oTRPDatoFiscal.Calle
            ebExterior.Text = oTRPDatoFiscal.NumExt
            ebInterior.Text = oTRPDatoFiscal.NumInt
            ebColonia.Text = oTRPDatoFiscal.Colonia
            ebEntidad.Text = oTRPDatoFiscal.Entidad
            ebMunicipio.Text = oTRPDatoFiscal.Municipio
            ebPais.Text = oTRPDatoFiscal.Pais
            ebCodigoPostal.Text = oTRPDatoFiscal.CodigoPostal
            ebReferencia.Text = oTRPDatoFiscal.ReferenciaDom
            Me.ebLocalidad.Text = oTRPDatoFiscal.Localidad

            ' Dim CAFLista As System.Collections.Generic.List(Of ERMCAFLOG.cCAFConfiguracion) = ERMCAFLOG.cCAFConfiguracion.ObtenerCliente(oCliente.ClienteClave, " IncluirXML = 1 AND InterfazGrafica = 1 Order by Orden desc ")
            'Dim CAFDLista As System.Collections.Generic.List(Of ERMCAFLOG.cCAFDetalle) = Nothing
            'Select Case tModo
            '    Case eModo.Leer, eModo.Cancelar
            'CAFDLista = ERMCAFLOG.cCAFDetalle.ObtenerCliente(oCliente.ClienteClave, .Folio)
            'End Select

            Me.cbFormaPago.SelectedValue = .CFVTipo
            Me.ebOrdenCompra.Text = .Notas

            If Not IsNothing(oTRPDatoFiscal.MetodoPago) AndAlso oTRPDatoFiscal.MetodoPago.Length > 0 Then
                Dim Metodos As String() = oTRPDatoFiscal.MetodoPago.Split(",")
                Dim Bancos As String()
                If Not IsNothing(oTRPDatoFiscal.Banco) AndAlso oTRPDatoFiscal.Banco.Length > 0 Then
                    Bancos = oTRPDatoFiscal.Banco.Split(",")
                End If
                Dim Cuentas As String()
                If Not IsNothing(oTRPDatoFiscal.NumCtaPago) AndAlso oTRPDatoFiscal.NumCtaPago.Length > 0 Then
                    Cuentas = oTRPDatoFiscal.NumCtaPago.Split(",")
                End If

                Dim aMetodos As New ArrayList
                Dim sBanco As String = String.Empty
                Dim sCuenta As String = String.Empty
                Dim indice As Integer = 0
                For Each sMetodo As String In Metodos
                    sBanco = String.Empty
                    sCuenta = String.Empty
                    If (Not IsNothing(Bancos) AndAlso indice < Bancos.Length) Then
                        sBanco = Bancos(indice)
                    End If
                    If (Not IsNothing(Cuentas) AndAlso indice < Cuentas.Length) Then
                        sCuenta = Cuentas(indice)
                    End If
                    Dim oMetodo As New IMetodosPago.MetodoPago(sMetodo, IIf(sBanco = "*", "", sBanco), IIf(sCuenta = "*", "", sCuenta))
                    aMetodos.Add(oMetodo)
                    indice += 1
                Next
                grMetodosPago.DataSource = aMetodos
            End If

            grPedidos.DataSource = oTransProd.TablaNodo.Recuperar("FacturaId='" & oTransProd.TransProdID & "' and Tipo = 1", "TransProdId, Folio, FechaHoraAlta, Total, (select NombreCorto from Cliente CLI inner join Visita VIS on CLI.ClienteClave = VIS.ClienteClave and VIS.VisitaClave = TransProd.VisitaClave and VIS.DiaClave = TransProd.DiaClave) as NombreCorto, isnull((select PedidoAdicional from TRPVtaAcreditada TVA where TVA.TransProdID = TransProd.TransProdID), '') as PedidoAdicional")
            grPedidos.DataMember = "TransProd"
            For Each ldrRow As DataRow In CType(grPedidos.DataSource, DataTable).Rows
                ebTotalFactura.Value += ldrRow!Total
            Next

        End With
    End Sub

    Private Sub BuscarCliente(ByVal pvClienteClave As String)
        Dim i As Integer = 0

        Call LimpiarDatosCliente()

        Dim sClienteClave As String

        bClienteValido = False

        'If rbtCliente.Checked Then
        sClienteClave = lbGeneral.ValidaFormatoSQLString(pvClienteClave)
        If oCliente.Tabla.Recuperar("Clave='" & sClienteClave & "'").Rows.Count <= 0 Then 'ClienteClave
            Throw New LbControlError.cError("E0027")
        End If

        oCliente.Recuperar(oCliente.Tabla.Recuperar("Clave='" & sClienteClave & "'").Rows(0).Item("ClienteClave"))

        If Not chClienteGenerico.Checked Then
            If oCliente.ClienteEsquema.ToDataTable.Select("EsquemaId = '" & sEsquemaId & "' and TipoEstado = 1").Length = 0 Then
                Throw New LbControlError.cError("E0795")
            End If
        End If

        'Else
        'Dim sConsulta As String
        'sConsulta = "select top 1 CLI.ClienteClave "
        'sConsulta &= "from Cliente CLI "
        'sConsulta &= "inner join ClienteEsquema CLE on CLI.ClienteClave = CLE.ClienteClave and CLE.TipoEstado = 1 "
        'sConsulta &= "inner join ClienteDomicilio CLD on CLI.ClienteClave = CLD.ClienteClave and CLD.Tipo = 1 "
        'sConsulta &= "where CLI.TipoEstado = 1 and CLI.IdFiscal = '" & sIdFiscal & "' and CLE.EsquemaId = '" & sEsquemaId & "' "

        'sClienteClave = oTransProd.Tabla.Conexion.EjecutarComandoScalar(sConsulta)
        'oCliente.Recuperar(sClienteClave)
        'End If

        bClienteValido = True

        'If rbtCliente.Checked Then
        ebClienteClave.Text = oCliente.Clave 'ClienteClave
        ebClienteNombre.Text = oCliente.RazonSocial
        'End If
        ebClienteNombre.Text = oCliente.RazonSocial
        ebClienteDatos.Text = oCliente.RazonSocial
        ebRFC.Text = oCliente.IdFiscal
        ebTelefonoContacto.Text = oCliente.TelefonoContacto
        Me.ebLocalidad.Text = oCliente.ClienteDomicilio(0).Localidad.ToString

        If oCliente.IdFiscal = "" Then
            Throw New LbControlError.cError("E0665")
        End If

        If tModo = eModo.Crear Or tModo = eModo.Modificar Then
            cbFormaPago.DataSource = Nothing
            cbFormaPago.SelectedItem = Nothing
            lbGeneral.LlenarComboBox(cbFormaPago, "FVENTA")

            'If rbtCliente.Checked Then
            While i < cbFormaPago.Items.Count
                If oCliente.CLIFormaVenta(cbFormaPago.Items(i).Value) Is Nothing Then
                    cbFormaPago.Items.Remove(cbFormaPago.Items(i))
                Else
                    i += 1
                End If
            End While
            'End If

            cbFormaPago.Enabled = True
        End If

        Dim lbDomFiscal As Boolean = False
        For i = 0 To oCliente.ClienteDomicilio.Conteo - 1
            With oCliente.ClienteDomicilio(i)
                If .Tipo = 1 Then
                    ebCalle.Text = .Calle
                    ebExterior.Text = .Numero
                    ebInterior.Text = .NumInt
                    ebColonia.Text = .Colonia
                    ebEntidad.Text = .Entidad
                    ebMunicipio.Text = .Poblacion
                    ebPais.Text = .Pais
                    ebCodigoPostal.Text = .CodigoPostal
                    ebReferencia.Text = .ReferenciaDom
                    Me.ebLocalidad.Text = .Localidad
                    lbDomFiscal = True
                    Exit For
                End If
            End With
        Next

        'Dim oAddenda As ERMADDLOG.cAddenda = New ERMADDLOG.cAddenda()
        'Dim dtCamposSolicitados As DataTable = oAddenda.ObtenerSolicitadosCliente(oCliente.ClienteClave)
        'If (dtCamposSolicitados.Rows.Count > 0) Then
        '    Dim icont As Integer = dtCamposSolicitados.Rows.Count
        '    TpComplemento.Visible = True
        '    Dim PosX As Integer = 11
        '    Dim PosY As Integer = 8
        '    For Each dr As DataRow In dtCamposSolicitados.Rows
        '        Dim ctrl As New CtrlCampos(oMensaje)
        '        ctrl.AgregarCampo(dr("Etiqueta"), dr("Valor"), dr("ADDDID"), dr("Requerido"), dr("TipoDato"), dr("LongMin"), dr("LongMax"))
        '        ctrl.TabIndex = icont
        '        TabControlPanel3.Controls.Add(ctrl)
        '        ctrl.Dock = DockStyle.Top
        '        icont -= 1
        '    Next
        'Else
        '    TpComplemento.Visible = False
        'End If
        'dtCamposSolicitados.Dispose()

        If Not lbDomFiscal Then
            Throw New LbControlError.cError("E0664")
        End If

        If tModo = eModo.Crear Or tModo = eModo.Modificar Then
            If bEditarDatos Then
                ebClienteDatos.Enabled = True
                ebRFC.Enabled = True
                ebCalle.Enabled = True
                ebExterior.Enabled = True
                ebInterior.Enabled = True
                ebColonia.Enabled = True
                ebCodigoPostal.Enabled = True
                ebReferencia.Enabled = True
                ebLocalidad.Enabled = True
                ebMunicipio.Enabled = True
                ebEntidad.Enabled = True
                ebPais.Enabled = True
            Else
                ebClienteDatos.Enabled = False
                ebRFC.Enabled = False
                ebCalle.Enabled = False
                ebExterior.Enabled = False
                ebInterior.Enabled = False
                ebColonia.Enabled = False
                ebCodigoPostal.Enabled = False
                ebReferencia.Enabled = False
                ebLocalidad.Enabled = False
                ebMunicipio.Enabled = False
                ebEntidad.Enabled = False
                ebPais.Enabled = False
            End If
        End If
    End Sub

    Private Sub ValidarCliente()
        Dim i As Integer = 0
        Dim sClienteClave As String

        'If rbtCliente.Checked Then
        sClienteClave = lbGeneral.ValidaFormatoSQLString(ebClienteClave.Text)
        If oCliente.Tabla.Recuperar("Clave='" & sClienteClave & "'").Rows.Count <= 0 Then 'ClienteClave
            Throw New LbControlError.cError("E0027")
        End If

        oCliente.Recuperar(oCliente.Tabla.Recuperar("Clave='" & sClienteClave & "'").Rows(0).Item("ClienteClave"))
        'Else
        '    Dim sConsulta As String
        '    sConsulta = "select top 1 CLI.ClienteClave "
        '    sConsulta &= "from Cliente CLI "
        '    sConsulta &= "inner join ClienteEsquema CLE on CLI.ClienteClave = CLE.ClienteClave and CLE.TipoEstado = 1 "
        '    sConsulta &= "inner join ClienteDomicilio CLD on CLI.ClienteClave = CLD.ClienteClave and CLD.Tipo = 1 "
        '    sConsulta &= "where CLI.TipoEstado = 1 and CLI.IdFiscal = '" & sIdFiscal & "' and CLE.EsquemaId = '" & sEsquemaId & "' "

        '    sClienteClave = oTransProd.Tabla.Conexion.EjecutarComandoScalar(sConsulta)
        '    oCliente.Recuperar(sClienteClave)
        'End If

        If oCliente.IdFiscal = "" Then
            Throw New LbControlError.cError("E0665")
        End If

        Dim lbDomFiscal As Boolean = False
        For i = 0 To oCliente.ClienteDomicilio.Conteo - 1
            With oCliente.ClienteDomicilio(i)
                If .Tipo = 1 Then
                    lbDomFiscal = True
                    Exit For
                End If
            End With
        Next

        If Not lbDomFiscal Then
            Throw New LbControlError.cError("E0664")
        End If

    End Sub

    Private Sub ValidarCampo(ByVal pvCampo As String)
        Dim oCL As ManejoCampoLogico = htCampos(pvCampo)

        If oCL.Requerido Or (pvCampo = "OrdendeCompra" And oCliente.ExigirOrdenCompra) Then
            If oCL.CtrlCaptura.GetType Is GetType(Janus.Windows.EditControls.UIComboBox) Then
                With CType(oCL.CtrlCaptura, Janus.Windows.EditControls.UIComboBox)
                    If .SelectedValue Is Nothing Then
                        oCL.CtrlCaptura.Focus()
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(oCL.CtrlEtiqueta.Text)})
                    End If
                End With
            ElseIf oCL.CtrlCaptura.GetType Is GetType(Janus.Windows.GridEX.EditControls.EditBox) Then
                With CType(oCL.CtrlCaptura, Janus.Windows.GridEX.EditControls.EditBox)
                    If .Text = "" Then
                        oCL.CtrlCaptura.Focus()
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(oCL.CtrlEtiqueta.Text)})
                    End If
                    Select Case UCase(.Name).ToString
                        Case UCase("ebRFC").ToString
                            Dim rfcValidar As String = .Text
                            If rfcValidar.Replace("-", "").ToString.Length > 13 Then
                                Throw New LbControlError.cError("E0718", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("RFC", False), New LbControlError.cParametroMSG("14", False)})
                                ebRFC.Focus()
                            End If
                    End Select

                End With
            ElseIf oCL.CtrlCaptura.GetType Is GetType(Janus.Windows.GridEX.EditControls.NumericEditBox) Then
                With CType(oCL.CtrlCaptura, Janus.Windows.GridEX.EditControls.NumericEditBox)
                    If .Value Is Nothing Then
                        oCL.CtrlCaptura.Focus()
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(oCL.CtrlEtiqueta.Text)})
                    End If
                End With
            End If
        End If

    End Sub

    Private Function ObtenerValorQuery(ByVal pvQuery As String) As String
        Dim sQuery, sValor As String

        If pvQuery.Contains("<T>") Then
            sQuery = pvQuery.Replace("<T>", "'" + oTransProd.TransProdID) + "'"
        Else
            sQuery = pvQuery
        End If

        Try
            sValor = oConexion.EjecutarComandoScalar(sQuery).ToString
        Catch ex As Exception
            sValor = "No Valido"
        End Try

        Return sValor
    End Function

    'Public Sub LlenarComplementoTab(ByVal ClienteClave As String)
    '    Me.TabControlPanel3.SuspendLayout()
    '    Dim tAdenda As DataTable
    '    tAdenda = ObtenerAdenda(ClienteClave)
    '    Dim icont As Integer = 0
    '    Dim icont2 As Integer = 0
    '    Dim label1 As System.Windows.Forms.Label
    '    Dim textbox1 As Janus.Windows.GridEX.EditControls.EditBox
    '    Dim combobox1 As Janus.Windows.EditControls.UIComboBox
    '    Dim iPointx As Integer = 30
    '    Dim iPointy As Integer = 30

    '    For Each dr As DataRow In tAdenda.Rows
    '        'label
    '        label1 = New System.Windows.Forms.Label()
    '        label1.BackColor = System.Drawing.Color.Transparent
    '        label1.Location = New System.Drawing.Point(iPointx, iPointy)
    '        If (dr("Etiqueta")).ToString <> "" Then
    '            label1.Name = "lb" + (dr("Etiqueta")).ToString
    '            label1.Text = (dr("Etiqueta")).ToString
    '        Else
    '            label1.Name = "lb" + ObtenerNodo((dr("Nodo")).ToString)
    '            label1.Text = ObtenerNodo((dr("Nodo")).ToString)
    '        End If
    '        label1.Size = New System.Drawing.Size(120, 20)
    '        label1.TabIndex = icont
    '        label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '        Me.TabControlPanel3.Controls.Add(label1)
    '        icont += 1
    '        'combobox
    '        If dr("TipoDato").ToString = "NmToken" Then
    '            combobox1 = New Janus.Windows.EditControls.UIComboBox
    '            combobox1.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
    '            combobox1.Location = New System.Drawing.Point(iPointx + 140, iPointy)
    '            combobox1.Name = "cb" + label1.Text
    '            combobox1.Size = New System.Drawing.Size(128, 20)
    '            combobox1.TabIndex = icont
    '            combobox1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
    '            Call LlenarCombo(combobox1, (dr("Nodo")).ToString)
    '            icont += 1
    '            Me.TabControlPanel3.Controls.Add(combobox1)
    '        Else
    '            'textbox
    '            textbox1 = New Janus.Windows.GridEX.EditControls.EditBox()
    '            textbox1.Location = New System.Drawing.Point(iPointx + 140, iPointy)
    '            textbox1.Name = "eb" + label1.Text
    '            textbox1.Text = ""
    '            textbox1.Size = New System.Drawing.Size(128, 20)
    '            textbox1.TabIndex = icont
    '            textbox1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
    '            textbox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
    '            icont += 1
    '            Me.TabControlPanel3.Controls.Add(textbox1)
    '        End If

    '        If icont2 = 0 Then
    '            iPointx += 348
    '        ElseIf (icont2 Mod 2) = 1 Then
    '            iPointx -= 348
    '            iPointy += 30
    '        Else
    '            iPointx += 348
    '        End If

    '        icont2 += 1
    '    Next
    '    Me.TabControlPanel3.PerformLayout()
    '    Me.TabControlPanel3.ResumeLayout(True)
    '    Me.TpComplemento.Visible = True
    'End Sub

    'Private Function ObtenerAdenda(ByVal ClienteClave As String) As DataTable
    '    Dim tableAdenda As DataTable

    '    Dim cmd As String = "SELECT * FROM CAFConfiguracion WHERE IncluirXML = 1"
    '    cmd += " AND Valor = '' AND InterfazGrafica = 0 ORDER BY Orden"

    '    tableAdenda = Me.oConexion.EjecutarConsulta(cmd)

    '    Return tableAdenda
    'End Function

    'Private Function ObtenerNodo(ByVal NodoPadre As String) As String
    '    Dim sNodo As String

    '    If NodoPadre.Contains(":") Then
    '        sNodo = NodoPadre.Substring(NodoPadre.LastIndexOf(":") + 1)
    '    Else
    '        sNodo = NodoPadre
    '    End If

    '    Return sNodo
    'End Function

    'Private Sub LlenarCombo(ByRef cbtemp As Janus.Windows.EditControls.UIComboBox, ByVal Nodo As String)
    '    Dim cmd As String = "SELECT Valor FROM CACDetalle WHERE Nodo = '" + Nodo + "'"
    '    Dim CAEtable As DataTable

    '    CAEtable = Me.oConexion.EjecutarConsulta(cmd)

    '    For Each dr As DataRow In CAEtable.Rows
    '        cbtemp.Items.Add((dr("Valor")).ToString, dr("Valor"))
    '    Next

    'End Sub
#End Region

#Region " Eventos "

    Private Sub cbFolio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFolio.SelectedIndexChanged
        ebFolioDatos.Text = cbFolio.SelectedItem.Text
    End Sub

    Private Sub ebClienteClave_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebClienteClave.Validated
        'Me.TabControlPanel3.Controls.Clear()

        If ebClienteClave.Text <> "" Then
            If (oCliente.ClienteClave <> Nothing) AndAlso ebClienteClave.Text.ToLower = oCliente.ClienteClave.ToLower Then
                Exit Sub
            End If
            Try
                BuscarCliente(ebClienteClave.Text)
                epErrores.SetError(ebClienteNombre, "")
            Catch ex As LbControlError.cError
                epErrores.SetError(ebClienteNombre, ex.Mensaje)
                oCliente.Limpiar()
            End Try
        Else
            Call LimpiarDatosCliente()
            epErrores.SetError(ebClienteNombre, oMensaje.RecuperarDescripcion("BE0001 ", New String() {oMensaje.RecuperarDescripcion("TRPClienteClave")}))
        End If
        bHuboCambios = True
    End Sub

    Sub LimpiarDatosCliente()
        ebClienteNombre.Text = ""
        ebClienteDatos.Text = ""
        ebRFC.Text = ""
        ebCalle.Text = ""
        ebExterior.Text = ""
        ebInterior.Text = ""
        ebTelefonoContacto.Text = ""
        ebColonia.Text = ""
        ebEntidad.Text = ""
        ebMunicipio.Text = ""
        ebLocalidad.Text = ""
        ebPais.Text = ""
        ebCodigoPostal.Text = ""
        ebReferencia.Text = ""
        ebClienteDatos.Enabled = False
        ebRFC.Enabled = False
        ebCalle.Enabled = False
        ebExterior.Enabled = False
        ebInterior.Enabled = False
        ebColonia.Enabled = False
        ebCodigoPostal.Enabled = False
        ebReferencia.Enabled = False
        ebLocalidad.Enabled = False
        ebMunicipio.Enabled = False
        ebEntidad.Enabled = False
        ebPais.Enabled = False
        'TpComplemento.Visible = False
        epErrores.SetError(cbFormaPago, "")
    End Sub

    Private Sub btBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscarCliente.Click
        Dim oIndice As New ERMCLIESC.IGeneral
        Dim oArray As ArrayList = oIndice.Seleccionar("ClienteClave in (select ClienteClave from ClienteEsquema where EsquemaId = '" & sEsquemaId & "' and TipoEstado = 1) and TipoEstado = 1", False)

        If Not oArray Is Nothing Then
            oCliente = oArray(0)
            Try
                'Me.TabControlPanel3.Controls.Clear()
                'Me.TpComplemento.Visible = False
                BuscarCliente(oCliente.Clave)
                epErrores.SetError(ebClienteNombre, "")

            Catch ex As LbControlError.cError
                epErrores.SetError(ebClienteNombre, ex.Mensaje)
            End Try
        End If
    End Sub

    Private Sub chClienteGenerico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chClienteGenerico.CheckedChanged
        If chClienteGenerico.Checked Then
            Dim oCliente As New ERMCLILOG.cCliente
            oCliente.Recuperar(oSubEmpresa.ClienteClave)
            ebClienteClave.Text = oCliente.Clave
            Call ebClienteClave_Validated(ebClienteClave, New System.EventArgs)
            ebEsquemaClave.Text = ""
            ebEsquemaNombre.Text = ""
            ebRutClave.Text = ""
            ebRutDescripcion.Text = ""
            ebRutClave.Enabled = True
            btBuscarRuta.Enabled = True
            ebClienteClave.Enabled = False
            btBuscarCliente.Enabled = False
            btBuscarEsquema.Enabled = False
            bClienteValido = True
            chbVentaEsquema.Enabled = False
        Else
            bClienteValido = False
            ebClienteClave.Text = ""
            ebClienteNombre.Text = ""
            ebEsquemaClave.Text = ""
            ebEsquemaNombre.Text = ""
            ebRutClave.Text = ""
            ebRutDescripcion.Text = ""
            ebRutClave.Enabled = False
            btBuscarRuta.Enabled = False
            btBuscarEsquema.Enabled = True
            ebClienteClave.Enabled = False
            btBuscarCliente.Enabled = False
            cbFormaPago.Enabled = False
            chbVentaEsquema.Enabled = True
            Call LimpiarDatosCliente()
        End If
        bHuboCambios = True
    End Sub

    Private Sub validarTransprodID()

    End Sub

    Private Sub btBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscar.Click
        Dim loPedidos As New ERMTRPESC.IPedidos
        Dim oArray As New ArrayList

        If IsNothing(cbFormaPago.SelectedValue) Or Not bClienteValido Then
            Exit Sub
        End If

        Dim lsFiltro As String = ""
        If oConfiguracion.CobrarVentas Then
            lsFiltro = "TRP.SubEmpresaID='" & oSubEmpresa.SubEmpresaID & "' AND TRP.MonedaId='" + cbMoneda.SelectedValue + "' AND TRP.Saldo=0 AND TRP.CFVTipo=" & cbFormaPago.SelectedValue
        Else
            lsFiltro = "TRP.SubEmpresaID='" & oSubEmpresa.SubEmpresaID & "' AND TRP.MonedaId='" + cbMoneda.SelectedValue + "' AND TRP.CFVTipo=" & cbFormaPago.SelectedValue
        End If

        If Not chClienteGenerico.Checked Then
            If Not chbVentaEsquema.Checked Then
                lsFiltro &= " AND CLE.EsquemaID = '" & sEsquemaId & "' AND VIS.ClienteClave='" & oCliente.Tabla.Recuperar("Clave='" & lbGeneral.ValidaFormatoSQLString(Me.ebClienteClave.Text) & "'").Rows(0).Item("ClienteClave") & "'"
            Else
                lsFiltro &= " AND CLE.EsquemaID = '" & sEsquemaId & "' "
            End If
        Else
            If Not ebRutClave.Text.Trim = "" Then
                lsFiltro &= " AND VIS.RUTClave = '" & ebRutClave.Text.Trim & "' "
            End If
        End If

        Dim lsPedidos As String = ""
        For Each loItem As Janus.Windows.GridEX.GridEXRow In grPedidos.GetRows
            If lsPedidos = "" Then
                lsPedidos = "'" & loItem.Cells("TransProdId").Value & "'"
            Else
                lsPedidos = lsPedidos & ",'" & loItem.Cells("TransProdId").Value & "'"
            End If
        Next

        If lsPedidos <> "" Then
            lsFiltro = lsFiltro & " AND TRP.TransProdId NOT IN (" & lsPedidos & ")"
        End If

        oArray = loPedidos.Seleccionar(lsFiltro, True)

        If Not oArray Is Nothing Then
            Dim vlDataTable As DataTable
            vlDataTable = grPedidos.DataSource
            grPedidos.DataSource = Nothing
            grPedidos.DataMember = Nothing

            Dim sPedidoAdicional As String

            For Each ldRow As DataRow In oArray

                'If vlDataTable.Select("TransProdId='" + lbGeneral.ValidaFormatoSQLString(ldRow!TransProdId) + "' ").Length = 0 Then
                'nHuboCambios = True
                'Dim loTransProd As New ERMTRPLOG.cTransProd
                'loTransProd.Recuperar(ldRow!TransProdId)
                Dim row As DataRow
                row = vlDataTable.NewRow
                row("TransProdId") = ldRow("TransProdId") 'TransProdId
                row("Folio") = ldRow("Folio") '!Folio
                row("FechaHoraAlta") = ldRow("Fecha") '!FechaEntrega
                row("Total") = ldRow("Total") '!Total
                row("NombreCorto") = ldRow("NombreCorto")

                sPedidoAdicional = oConexion.EjecutarComandoScalar("select isnull(PedidoAdicional, '') from TRPVtaAcreditada where TransProdId = '" & ldRow("TransProdId") & "'")
                If sPedidoAdicional Is Nothing Then sPedidoAdicional = String.Empty
                row("PedidoAdicional") = sPedidoAdicional

                vlDataTable.Rows.Add(row)
                ebTotalFactura.Value = ebTotalFactura.Value + ldRow(3) '!Total
                'grPedidos.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                'grPedidos.MoveToNewRecord()
                'grPedidos.GetRow.Cells("TransProdId").Value = loTransProd.TransProdID
                'grPedidos.GetRow.Cells("Folio").Value = loTransProd.Folio
                'grPedidos.GetRow.Cells("FechaHoraAlta").Value = loTransProd.FechaHoraAlta
                'grPedidos.GetRow.Cells("Total").Value = loTransProd.Total
                'grPedidos.UpdateData()
                'ebTotalFactura.Value = ebTotalFactura.Value + loTransProd.Total
                bHuboCambios = True
                'End If
            Next

            For Each drPed As DataRow In vlDataTable.Rows
                If Not htActualizarTVA Is Nothing Then
                    If htActualizarTVA.Contains(drPed("TransProdId")) Then
                        sPedidoAdicional = htActualizarTVA(drPed("TransProdId"))
                        drPed("PedidoAdicional") = sPedidoAdicional
                    End If
                End If
            Next

            'grPedidos.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
            grPedidos.DataSource = vlDataTable
            grPedidos.DataMember = "TransProd"

            grPedidos.Focus()
            If grPedidos.RowCount > 0 Then
                chClienteGenerico.Enabled = False
                'rbtEsquema.Enabled = False
                chbVentaEsquema.Enabled = False
                btBuscarEsquema.Enabled = False
                'rbtCliente.Enabled = False
                ebClienteClave.Enabled = False
                btBuscarCliente.Enabled = False
                cbFormaPago.Enabled = False
                cbMoneda.Enabled = False
            End If
        End If
    End Sub

    Private Sub btEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEliminar.Click
        If (grPedidos.RowCount = 0) Then
            Exit Sub
        End If

        If (grPedidos.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
            ebTotalFactura.Value = ebTotalFactura.Value - grPedidos.GetValue("Total")
            grPedidos.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
            grPedidos.Delete()
            grPedidos.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
            If grPedidos.RowCount = 0 Then
                chClienteGenerico.Enabled = True
                If Not chClienteGenerico.Checked Then
                    chbVentaEsquema.Enabled = True
                    btBuscarEsquema.Enabled = True
                    ebClienteClave.Enabled = True
                    btBuscarCliente.Enabled = True
                End If
                cbFormaPago.Enabled = True
                cbMoneda.Enabled = True
            End If
            bHuboCambios = True
        End If
    End Sub


    Private Sub grPedidos_CellUpdated(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grPedidos.CellUpdated
        If htActualizarTVA Is Nothing Then htActualizarTVA = New Hashtable
        If htActualizarTVA.Contains(grPedidos.GetValue("TransProdId")) Then
            htActualizarTVA(grPedidos.GetValue("TransProdId")) = grPedidos.GetValue("PedidoAdicional")
        Else
            htActualizarTVA.Add(grPedidos.GetValue("TransProdId"), grPedidos.GetValue("PedidoAdicional"))
        End If
    End Sub


    Private Sub grPedidos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grPedidos.SelectionChanged
        If grPedidos.RowCount > 0 And (tModo = eModo.Crear Or tModo = eModo.Modificar) Then
            If (grPedidos.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                btEliminar.Enabled = False
            Else
                If grPedidos.GetRow.DataRow.Row.RowState = DataRowState.Added Then
                    btEliminar.Enabled = True
                Else
                    btEliminar.Enabled = False
                End If
            End If
        Else
            btEliminar.Enabled = False
        End If
    End Sub

    Private Sub ObtenerFolio()
        If Not bIniciando Then

            Dim oFolio As New ERMFOLLOG.cFolio

            If oSubEmpresa.FoliosTerminal Then
                cbFolio.DataSource = oFolio.ObtenerFolioFiscal(strTerminalClave, Nothing, oSubEmpresa.SubEmpresaID, 1)
            Else
                cbFolio.DataSource = oFolio.ObtenerFolioFiscal(Nothing, strVendedorId, oSubEmpresa.SubEmpresaID, 1)
            End If
            cbFolio.SelectedValue = CType(cbFolio.DataSource, DataTable).Rows(0)!FolioIdFOSId
            ebFolioDatos.Text = CType(cbFolio.DataSource, DataTable).Rows(0)!Folio

            ConfiguraGrid()
            cbMoneda.Enabled = True
            ebOrdenCompra.Clear()

            chClienteGenerico.Enabled = True
            If Not chClienteGenerico.Checked Then
                ebClienteClave.Enabled = True
                btBuscarCliente.Enabled = True
            End If
            cbFormaPago.Enabled = True

        End If
    End Sub

    Private Sub ControlesActivo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbFolio.Validated, ebFechaFacturacion.Validated, cbFase.Validated, cbFormaPago.Validated, ebOrdenCompra.Validated, ebFolioDatos.Validated, ebClienteDatos.Validated, ebRFC.Validated, ebCalle.Validated, ebExterior.Validated, ebInterior.Validated, ebColonia.Validated, ebCodigoPostal.Validated, ebReferencia.Validated, ebLocalidad.Validated, ebMunicipio.Validated, ebEntidad.Validated, ebPais.Validated
        Dim oCL As ManejoCampoLogico
        oCL = CType(sender.tag, ManejoCampoLogico)

        If oCL.Requerido Then
            If sender.GetType Is GetType(Janus.Windows.EditControls.UIComboBox) Then
                With CType(sender, Janus.Windows.EditControls.UIComboBox)
                    If .SelectedValue Is Nothing Then
                        epErrores.SetError(sender, oMensaje.RecuperarDescripcion("BE0001", New String() {oCL.CtrlEtiqueta.Text}))
                        Exit Sub
                    End If
                End With
            ElseIf sender.GetType Is GetType(Janus.Windows.GridEX.EditControls.EditBox) Then
                With CType(sender, Janus.Windows.GridEX.EditControls.EditBox)
                    If .Text = "" Then
                        epErrores.SetError(sender, oMensaje.RecuperarDescripcion("BE0001", New String() {oCL.CtrlEtiqueta.Text}))
                        Exit Sub
                    End If

                    Select Case UCase(.Name).ToString
                        Case UCase("ebRFC").ToString
                            Dim rfcValidar As String = .Text
                            If rfcValidar.Replace("-", "").ToString.Length > 13 Then
                                epErrores.SetError(sender, oMensaje.RecuperarDescripcion("E0718", New String() {"RFC", "14"}))
                                Exit Sub
                            End If
                    End Select

                End With
            ElseIf sender.GetType Is GetType(Janus.Windows.GridEX.EditControls.NumericEditBox) Then
                With CType(sender, Janus.Windows.GridEX.EditControls.NumericEditBox)
                    If .Value Is Nothing Then
                        epErrores.SetError(sender, oMensaje.RecuperarDescripcion("BE0001", New String() {oCL.CtrlEtiqueta.Text}))
                        Exit Sub
                    End If
                End With
            End If
            epErrores.SetError(sender, "")
        End If



        bHuboCambios = True
    End Sub

    Private Function CrearAgendaVendedor(ByVal pvDiaClave As String, ByVal pvVendedorId As String, ByVal pvClienteClave As String) As Boolean
        Dim sCmd As String = "select count(*) from AgendaVendedor where DiaClave = '" + pvDiaClave + "' and VendedorId = '" + pvVendedorId + "' and ClienteClave = '" + pvClienteClave + "'"
        If Convert.ToInt32(oConexion.EjecutarComandoScalar(sCmd)) = 0 Then
            sCmd = "select isnull(MAX(Orden), 0) + 1 as Orden from AgendaVendedor where DiaClave = '" + pvDiaClave + "' and VendedorId = '" + pvVendedorId + "'"
            Dim nOrden As Integer = Convert.ToInt32(oConexion.EjecutarComandoScalar(sCmd))

            sCmd = "select ALM.Clave from VENCentroDistHist VCH "
            sCmd += "inner join Almacen ALM on VCH.AlmacenId = ALM.AlmacenID "
            sCmd += "where VCH.VendedorId = '" + pvVendedorId + "' and GETDATE() between VCH.VCHFechaInicial and VCH.FechaFinal "
            Dim sCEDI As String = Convert.ToString(oConexion.EjecutarComandoScalar(sCmd))

            sCmd = "insert into AgendaVendedor (DiaClave, VendedorId, FrecuenciaClave, RUTClave, Orden, ClienteClave, ClaveCEDI) "
            sCmd += "values ('" + pvDiaClave + "', '" + pvVendedorId + "', 'FRECPV', 'RUTF00', " + nOrden.ToString() + " , '" + pvClienteClave + "', '" + sCEDI + "') "
            Return (Convert.ToInt32(oConexion.EjecutarComando(sCmd)) > 0)
        End If
        Return True
    End Function



    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.None

        Me.Cursor = Cursors.WaitCursor
        Me.BtAceptar.Enabled = False
        Me.BtCancelar.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Try
            Select Case tModo
                Case eModo.Crear
                    oTransProd.Limpiar()

                    'Valida los campos requeridos
                    Dim lsCamposValidar As String()
                    If chClienteGenerico.Checked Then
                        lsCamposValidar = New String() {"Folio", "FechaFacturacion", "TipoFase", "ClienteClave", "CFVTipo", "OrdendeCompra"}
                    Else
                        lsCamposValidar = New String() {"Folio", "FechaFacturacion", "TipoFase", "EsquemaID", "ClienteClave", "CFVTipo", "OrdendeCompra"}
                    End If

                    Try
                        For Each lsCampo As String In lsCamposValidar
                            ValidarCampo(lsCampo)
                        Next
                    Catch ex As LbControlError.cError
                        TabFacturacion.SelectedTab = TpGenerales
                        MsgBox(ex.Mensaje, MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                        Exit Sub
                    End Try

                    'Validar Cliente
                    Try
                        ValidarCliente()
                    Catch ex As LbControlError.cError
                        TabFacturacion.SelectedTab = TpGenerales
                        MsgBox(ex.Mensaje, MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                        Exit Sub
                    End Try

                    lsCamposValidar = New String() {"PFolio", "Cliente", "IdFiscal", "Calle", "Numero", "NumInt", "Colonia", "CodigoPostal", "ReferenciaDom", "Localidad", "Poblacion", "Entidad", "Pais"}
                    Try
                        For Each lsCampo As String In lsCamposValidar
                            ValidarCampo(lsCampo)
                        Next
                    Catch ex As LbControlError.cError
                        TabFacturacion.SelectedTab = TpDatosFiscales
                        MsgBox(ex.Mensaje, MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                        Exit Sub
                    End Try

                    'Valida que tenga pedidos asignados
                    If grPedidos.RowCount <= 0 Then
                        TabFacturacion.SelectedTab = TpGenerales
                        MsgBox(oMensaje.RecuperarDescripcion("E0062"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                        Exit Sub
                    End If

                    'Valida que el Usuario que genera la factura tenga un vendedor asignado y no existan registros en VENRUT
                    Dim ldtTabla As DataTable = oVendedor.Tabla.Recuperar("USUId='" & lbGeneral.cParametros.UsuarioID & "' AND TipoEstado=1")
                    If ldtTabla.Rows.Count <= 0 Then
                        MsgBox(oMensaje.RecuperarDescripcion("E0666"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                        Exit Sub
                    End If

                    Dim lsVendedorId As String = ldtTabla.Rows(0)!VendedorId
                    Dim oVENRUT As New ERMVERLOG.Amesol.CVenRut
                    If oVENRUT.TablaNodo.Recuperar("VendedorId='" & lsVendedorId & "' AND TipoEstado=1").Rows.Count > 0 Then
                        MsgBox(oMensaje.RecuperarDescripcion("E0661"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                        Exit Sub
                    End If

                    'Validar que se haya seleccionado el metodo de pago para las versiones 2.2 y 3.1
                    If oSubEmpresa.VersionCFD = 3 Or oSubEmpresa.VersionCFD = 4 Then
                        If grMetodosPago.RowCount <= 0 Then
                            MsgBox(oMensaje.RecuperarDescripcion("E0867", New String() {lbMetodoPago.Text}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                            Exit Sub
                        End If
                    End If

                    Dim sCmd As String
                    'Validar el dato PedidoAdicional si tiene configurada addenda OXXO y el tipo de localización es Tienda
                    'y si tiene configurada addenda COMERCIAL MEXICANA y el metodo DeliveryNote

                    'sCmd = "select COUNT(*) from ( "
                    'sCmd &= "select ADC.ClienteClave "
                    'sCmd &= "from Addenda [ADD] "
                    'sCmd &= "inner join AddendaCliente ADC on [ADD].ADDID = ADC.ADDId "
                    'sCmd &= "inner join AddendaDetalle ADT on [ADD].ADDID = ADT.ADDID and ADT.Parametro = 35 and ADT.Valor = 'T' "
                    'sCmd &= "where [ADD].Tipo = 2 and [ADD].TipoEstado = 1 and [ADD].Baja = 0 "
                    'sCmd &= "and ADC.ClienteClave = '" & oCliente.ClienteClave & "' "
                    'sCmd &= "union "
                    'sCmd &= "select ADC.ClienteClave "
                    'sCmd &= "from Addenda [ADD] "
                    'sCmd &= "inner join AddendaCliente ADC on [ADD].ADDID = ADC.ADDId "
                    'sCmd &= "inner join AddendaMetodo ADM on ADC.ADDId = ADM.ADDId and ADM.TipoMetodo = 68 "
                    'sCmd &= "where [ADD].Tipo = 5 and [ADD].TipoEstado = 1 and [ADD].Baja = 0 "
                    'sCmd &= "and ADC.ClienteClave = '" & oCliente.ClienteClave & "' "
                    'sCmd &= ") as t"


                    'If oConexion.EjecutarComandoScalar(sCmd) > 0 Then
                    '    Dim dtPed As DataTable = grPedidos.DataSource
                    '    Dim nCont As Integer = 0
                    '    For Each drPed As DataRow In dtPed.Rows
                    '        If drPed("PedidoAdicional").ToString.Trim = String.Empty Then
                    '            MsgBox(oMensaje.RecuperarDescripcion("BE0001", New String() {oMensaje.RecuperarDescripcion("TVAPedidoAdicional")}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                    '            Me.TabFacturacion.SelectedTab = Me.TpGenerales
                    '            grPedidos.Row = nCont
                    '            grPedidos.Focus()
                    '            Exit Sub
                    '        End If
                    '        nCont += 1
                    '    Next
                    'End If

                    'Valida el complemento de la factura electronica
                    'If Me.TpComplemento.Visible Then
                    '    Dim i As Integer

                    '    For i = Me.TabControlPanel3.Controls.Count - 1 To 0 Step -1
                    '        Dim Ctrl As CtrlCampos = Me.TabControlPanel3.Controls.Item(i)
                    '        If Ctrl.Requerido AndAlso Ctrl.Valor = "" Then
                    '            Me.TabFacturacion.SelectedTab = Me.TpComplemento
                    '            Ctrl.Focus()
                    '            Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(Ctrl.Label1.Text)})
                    '        End If
                    '        If Ctrl.TipoDato = CtrlCampos.ETipoDato.Texto AndAlso Ctrl.Valor <> "" Then
                    '            If Ctrl.Valor.Length < Ctrl.LongMin Or Ctrl.Valor.Length > Ctrl.LongMax Then
                    '                Me.TabFacturacion.SelectedTab = Me.TpComplemento
                    '                Ctrl.Focus()
                    '                Throw New LbControlError.cError("E0825", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(Ctrl.LongMin), New LbControlError.cParametroMSG(Ctrl.LongMax)})
                    '            End If
                    '        End If
                    '    Next
                    'End If

                    oCliente.Limpiar()
                    oCliente.Recuperar(oCliente.ObtenerClienteClave(ebClienteClave.Text))

                    Dim bImpuestoGlb As Boolean = False
                    Dim sFiltro As String = ""
                    sFiltro = " TRP.TransProdId in ("
                    For Each lrRow As Janus.Windows.GridEX.GridEXRow In grPedidos.GetRows
                        sFiltro &= "'" & lrRow.Cells("TransProdId").Value & "',"
                    Next
                    sFiltro = sFiltro.Remove(sFiltro.Length - 1, 1)
                    sFiltro &= ") "

                    sCmd = "select isnull(sum(case when TDI.ImpuestoPU is null or TDI.ImpDesGlb is null then 1 else 0 end), 0) as Nulos "
                    sCmd &= "from TransProd TRP "
                    sCmd &= "inner join TPDImpuesto TDI on TRP.TransProdID = TDI.TransProdID "
                    sCmd &= "where " & sFiltro & " and TRP.Tipo = 1 "
                    bImpuestoGlb = (LbConexion.cConexion.Instancia.EjecutarComandoScalar(sCmd) = 0)


                    'Valida que los Impuestos no hayan cambiado y si VigenciaImpuesto es así, los recalcula
                    Dim lnSubTotal As Double = 0
                    Dim lnImpuesto As Double = 0
                    Dim lnTotal As Double = 0
                    Dim lbImpuestosMod As Boolean = False
                    Dim lsTransProdId As String = lbGeneral.cKeyGen.KEYGEN(0)

                    Dim iTipoCambio As Integer = 0
                    For Each lrRow As Janus.Windows.GridEX.GridEXRow In grPedidos.GetRows
                        Dim loTransProd As New ERMTRPLOG.cTransProd
                        loTransProd.Recuperar(lrRow.Cells("TransProdId").Value)
                        If loTransProd.VigenciaImpuesto(oConexion.ObtenerFecha) Then
                            lbImpuestosMod = True
                        End If

                        If bImpuestoGlb Then
                            Dim nSubtotal As Double
                            Dim nImpuesto As Double
                            loTransProd.ObtenerSubtotalEImpuesto(oCliente.ClienteClave, nSubtotal, nImpuesto)
                            lnSubTotal += nSubtotal
                            lnImpuesto += nImpuesto
                        Else
                            lnSubTotal += loTransProd.SubTotal
                            lnImpuesto += loTransProd.Impuesto
                        End If
                        lnTotal += loTransProd.Total

                        'Modificar los Pedidos
                        loTransProd.FacturaID = lsTransProdId
                        loTransProd.TipoFase = 3
                        loTransProd.FechaFacturacion = oConexion.ObtenerFecha
                        iTipoCambio = loTransProd.TipoCambio
                        loTransProd.Grabar()
                    Next

                    If lbImpuestosMod Then
                        MsgBox(oMensaje.RecuperarDescripcion("I0002"), MsgBoxStyle.Information, oMensaje.RecuperarDescripcion("XMensajeI"))
                    End If

                    'Validar Ruta Temporal
                    Dim loRuta As New ERMRUTLOG.cRuta
                    Dim lsRUTClave As String = "RUTF00"
                    If Not loRuta.Existe(lsRUTClave) Then
                        loRuta.RUTClave = lsRUTClave
                        loRuta.Descripcion = "Ruta de Facturación en Escritorio"
                        loRuta.Tipo = 2
                        loRuta.TipoEstado = 1
                        loRuta.Inventario = False
                        loRuta.Insertar()
                        loRuta.Grabar()
                    End If

                    'Valida Dia
                    Dim loDia As New ERMDIALOG.CDiaTrabajo
                    Dim lsDiaClave As String = oConexion.ObtenerFecha.ToString("dd/MM/yyyy")
                    If Not loDia.Existe(oConexion.ObtenerFecha.ToString("dd/MM/yyyy")) Then
                        loDia.DiaClave = lsDiaClave
                        loDia.Referencia = oConexion.ObtenerFecha.ToString("dddd")
                        loDia.Estado = 1
                        loDia.FechaCaptura = oConexion.ObtenerFecha
                        loDia.Insertar()
                        loDia.Grabar()
                    End If

                    'Valida Visita
                    Dim lsVisitaClave As String = lbGeneral.cKeyGen.KEYGEN(0)
                    Dim ldtVisita As DataTable = oConexion.EjecutarConsulta("SELECT * FROM Visita WHERE DiaClave='" & lsDiaClave & "' AND ClienteClave='" & oCliente.ClienteClave & "'")
                    If ldtVisita.Rows.Count <= 0 Then
                        lsVisitaClave = lbGeneral.cKeyGen.KEYGEN(0)
                        oConexion.EjecutarComando("INSERT INTO Visita (VisitaClave, DiaClave, ClienteClave, VendedorId, RUTClave, Numero, FechaHoraInicial, FechaHoraFinal, TipoEstado, FueraFrecuencia, CodigoLeido, MFechaHora, MUsuarioId) Values ('" & lsVisitaClave & "','" & lsDiaClave & "','" & oCliente.ClienteClave & "', '" & lsVendedorId & "', '" & lsRUTClave & "', 1, GETDATE(), GETDATE(), 1, 0, 0, GETDATE(), '" & lbGeneral.cParametros.UsuarioID & "')")
                    Else
                        lsVisitaClave = ldtVisita.Rows(0)!VisitaClave
                    End If

                    'Validar Frecuencia 
                    Dim oFrecuencia As ERMFRELOG.cFrecuencia = New ERMFRELOG.cFrecuencia
                    If Not oFrecuencia.Existe("FRECPV") Then
                        oFrecuencia.FrecuenciaClave = "FRECPV"
                        oFrecuencia.Descripcion = "Frecuencia de ventas en mostrador"
                        oFrecuencia.Tipo = 1
                        oFrecuencia.FechaInicio = oConexion.ObtenerFecha()
                        oFrecuencia.FechaFinal = New System.DateTime(9999, 1, 1)
                        oFrecuencia.UnidadInicio = 1
                        oFrecuencia.Repeticion = 6
                        oFrecuencia.Intervalo = 1
                        oFrecuencia.MUsuarioID = lbGeneral.cParametros.UsuarioID
                        oFrecuencia.Insertar()
                        oFrecuencia.Grabar()
                    End If


                    'Validar AgendaVendedor
                    CrearAgendaVendedor(lsDiaClave, lsVendedorId, oCliente.ClienteClave)

                    'Genera Factura

                    oTransProd.TransProdID = lsTransProdId
                    oTransProd.VisitaClave = lsVisitaClave
                    oTransProd.DiaClave = lsDiaClave
                    oTransProd.Folio = cbFolio.SelectedItem.Text
                    oTransProd.Tipo = 8
                    oTransProd.TipoFase = 1
                    oTransProd.FechaHoraAlta = oConexion.ObtenerFecha
                    oTransProd.FechaCaptura = oConexion.ObtenerFecha.Date
                    oTransProd.FechaFacturacion = oConexion.ObtenerFecha.Date
                    oTransProd.CFVTipo = cbFormaPago.SelectedValue
                    oTransProd.SubTotal = lnSubTotal
                    oTransProd.Impuesto = lnImpuesto
                    oTransProd.Total = lnTotal
                    oTransProd.Saldo = lnTotal
                    oTransProd.Notas = ebOrdenCompra.Text
                    oTransProd.SubEmpresaId = oSubEmpresa.SubEmpresaID
                    oTransProd.MonedaID = Me.cbMoneda.SelectedValue
                    If Not IsDBNull(iTipoCambio) Then
                        oTransProd.TipoCambio = iTipoCambio
                    End If

                    oTransProd.Insertar()
                    oTransProd.Grabar()

                    If Not htActualizarTVA Is Nothing Then
                        For Each sPedido As String In htActualizarTVA.Keys
                            Dim oPED As New ERMTRPLOG.cTransProd
                            oPED.Recuperar(sPedido)
                            Dim oTVA As New ERMTRPLOG.cTRPVtaAcreditada(oPED)
                            If oTVA.Existe(sPedido) Then
                                oTVA.Recuperar(sPedido)
                                oTVA.PedidoAdicional = htActualizarTVA(sPedido)
                                oTVA.Grabar()
                            Else
                                oTVA.PedidoAdicional = htActualizarTVA(sPedido)
                                oTVA.Insertar(New String() {"PedidoAdicional"})
                                oTVA.Grabar()
                            End If
                        Next
                    End If

                    Dim lsFolioId As String = CType(cbFolio.DataSource, DataTable).Select("FolioIdFOSId='" & cbFolio.SelectedValue & "'")(0)!FolioId
                    Dim lsFOSId As String = CType(cbFolio.DataSource, DataTable).Select("FolioIdFOSId='" & cbFolio.SelectedValue & "'")(0)!FOSId
                    Dim lsNumCertificado As String = CType(cbFolio.DataSource, DataTable).Select("FolioIdFOSId='" & cbFolio.SelectedValue & "'")(0)!NumCertificado
                    Dim lsCentroExpID As String = CType(cbFolio.DataSource, DataTable).Select("FolioIdFOSId='" & cbFolio.SelectedValue & "'")(0)!CentroExpID
                    Dim lsSerie As String = CType(cbFolio.DataSource, DataTable).Select("FolioIdFOSId='" & cbFolio.SelectedValue & "'")(0)!Serie
                    Dim lnAprobacion As Integer = CType(cbFolio.DataSource, DataTable).Select("FolioIdFOSId='" & cbFolio.SelectedValue & "'")(0)!Aprobacion
                    Dim lnAnioAprobacion As Integer = CType(cbFolio.DataSource, DataTable).Select("FolioIdFOSId='" & cbFolio.SelectedValue & "'")(0)!AnioAprobacion
                    Dim loCentroExpEm As New ERMCEELOG.CCentroExp
                    Dim loCentroExpEx As New ERMCEELOG.CCentroExp

                    loCentroExpEm.Recuperar(lsCentroExpID)
                    If loCentroExpEm.Tipo = 1 And loCentroExpEm.NumCertificado = lsNumCertificado Then 'Sucursal
                        Dim lsCentroExpPadreId As String = loCentroExpEm.CentroExpPadreID
                        loCentroExpEm.Limpiar()
                        loCentroExpEm.Recuperar(lsCentroExpPadreId)
                        loCentroExpEx.Recuperar(lsCentroExpID)
                    Else 'Matriz
                        loCentroExpEx.Limpiar()
                        loCentroExpEx = loCentroExpEm

                    End If

                    'Graba Folio
                    Dim loFolio As New ERMFOLLOG.cFolio
                    loFolio.Recuperar(lsFolioId)
                    loFolio.Bloquear(lbGeneral.cParametros.UsuarioID)
                    loFolio.FOS(lsFOSId).Usados += 1
                    loFolio.Grabar()

                    'Graba Cliente Y su Domicilio Fiscal
                    oCliente.IdFiscal = ebRFC.Text.Replace("-", "")
                    oCliente.TelefonoContacto = ebTelefonoContacto.Text

                    Dim bSalir As Boolean = False

                    For Each fila As DataRow In oCliente.ClienteDomicilio().Tabla.Recuperar("tipo=1 and clienteclave ='" + oCliente.ClienteClave + "'").Rows
                        Dim dom As ERMCLILOG.cClienteDomicilio = oCliente.ClienteDomicilio(fila("ClienteDomicilioId"))
                        With dom
                            .Pais = ebPais.Text
                            .Calle = ebCalle.Text
                            .Numero = ebExterior.Text
                            .NumInt = ebInterior.Text
                            .Colonia = ebColonia.Text
                            .CodigoPostal = ebCodigoPostal.Text
                            .ReferenciaDom = ebReferencia.Text
                            .Localidad = ebLocalidad.Text
                            .Entidad = ebEntidad.Text
                            .Poblacion = ebMunicipio.Text
                            .Grabar()
                        End With

                    Next
                    oCliente.Grabar()

                    'Graba Dato Fiscal
                    oTRPDatoFiscal = New ERMTRPLOG.cTRPDatoFiscal(oTransProd)
                    oTRPDatoFiscal.FolioId = lsFolioId
                    oTRPDatoFiscal.FOSId = lsFOSId
                    oTRPDatoFiscal.NumCertificado = lsNumCertificado
                    oTRPDatoFiscal.Serie = lsSerie
                    oTRPDatoFiscal.Aprobacion = lnAprobacion
                    oTRPDatoFiscal.AnioAprobacion = lnAnioAprobacion
                    oTRPDatoFiscal.RazonSocial = ebClienteDatos.Text
                    oTRPDatoFiscal.RFC = ebRFC.Text.Replace("-", "")
                    oTRPDatoFiscal.TelefonoContacto = ebTelefonoContacto.Text
                    oTRPDatoFiscal.Calle = ebCalle.Text
                    oTRPDatoFiscal.NumExt = ebExterior.Text
                    oTRPDatoFiscal.NumInt = ebInterior.Text
                    oTRPDatoFiscal.Colonia = ebColonia.Text
                    oTRPDatoFiscal.CodigoPostal = ebCodigoPostal.Text
                    oTRPDatoFiscal.ReferenciaDom = ebReferencia.Text
                    oTRPDatoFiscal.Localidad = ebLocalidad.Text
                    oTRPDatoFiscal.Municipio = ebMunicipio.Text
                    oTRPDatoFiscal.Entidad = ebEntidad.Text
                    oTRPDatoFiscal.Pais = ebPais.Text
                    oTRPDatoFiscal.CadenaOriginal = " "
                    oTRPDatoFiscal.SelloDigital = " "
                    oTRPDatoFiscal.TelefonoEm = oSubEmpresa.Telefono
                    oTRPDatoFiscal.RFCEm = loCentroExpEm.RFC
                    oTRPDatoFiscal.NombreEm = loCentroExpEm.Nombre
                    oTRPDatoFiscal.CalleEm = loCentroExpEm.Calle
                    oTRPDatoFiscal.NumExtEm = loCentroExpEm.NumExt
                    oTRPDatoFiscal.NumIntEm = loCentroExpEm.NumInt
                    oTRPDatoFiscal.ColoniaEm = loCentroExpEm.Colonia
                    oTRPDatoFiscal.LocalidadEm = loCentroExpEm.Localidad
                    oTRPDatoFiscal.ReferenciaDomEm = loCentroExpEm.ReferenciaDom
                    oTRPDatoFiscal.MunicipioEm = loCentroExpEm.Municipio
                    oTRPDatoFiscal.RegionEm = loCentroExpEm.Entidad
                    oTRPDatoFiscal.PaisEm = loCentroExpEm.Pais
                    oTRPDatoFiscal.CodigoPostalEm = loCentroExpEm.CodigoPostal
                    oTRPDatoFiscal.CalleEx = loCentroExpEx.Calle
                    oTRPDatoFiscal.NumExtEx = loCentroExpEx.NumExt
                    oTRPDatoFiscal.NumIntEx = loCentroExpEx.NumInt
                    oTRPDatoFiscal.ColoniaEx = loCentroExpEx.Colonia
                    oTRPDatoFiscal.CodigoPostalEx = loCentroExpEx.CodigoPostal
                    oTRPDatoFiscal.ReferenciaDomEx = loCentroExpEx.ReferenciaDom
                    oTRPDatoFiscal.LocalidadEx = loCentroExpEx.Localidad
                    oTRPDatoFiscal.MunicipioEx = loCentroExpEx.Municipio
                    oTRPDatoFiscal.EntidadEx = loCentroExpEx.Entidad
                    oTRPDatoFiscal.PaisEx = loCentroExpEx.Pais

                    If grMetodosPago.RowCount > 0 Then
                        Dim sMetodos As String = String.Empty
                        Dim sBancos As String = String.Empty
                        Dim sCuentas As String = String.Empty

                        For Each oMetodo As IMetodosPago.MetodoPago In grMetodosPago.DataSource
                            sMetodos += oMetodo.Metodo + ","
                            sBancos += IIf(oMetodo.Banco = "", "*", oMetodo.Banco) + ","
                            sCuentas += IIf(oMetodo.Cuenta = "", "*", oMetodo.Cuenta) + ","
                        Next

                        If sMetodos.Length > 0 Then
                            sMetodos = sMetodos.Substring(0, sMetodos.Length - 1)
                        End If
                        If sBancos.Length > 0 Then
                            sBancos = sBancos.Substring(0, sBancos.Length - 1)
                        End If

                        If sCuentas.Length > 0 Then
                            sCuentas = sCuentas.Substring(0, sCuentas.Length - 1)
                        End If

                        oTRPDatoFiscal.MetodoPago = sMetodos
                        oTRPDatoFiscal.NumCtaPago = sCuentas
                        oTRPDatoFiscal.Banco = sBancos
                    End If

                    oTRPDatoFiscal.LugarExpedicion = IIf(loCentroExpEx.Municipio = "", loCentroExpEm.Municipio & ", " & loCentroExpEm.Entidad, loCentroExpEx.Municipio & ", " & loCentroExpEx.Entidad)
                    oTRPDatoFiscal.CerBase64 = oSubEmpresa.CerBase64
                    oTRPDatoFiscal.FormaDePago = "Pago en una sola exhibicion"

                    Dim lnTipoVersion As String
                    'If (oSubEmpresa.VersionCFD = 1) Then
                    lnTipoVersion = lbGeneral.ClaveDescripcionVARValor("VERFACTE", oSubEmpresa.VersionCFD)
                    'Else
                    '    lnTipoVersion = lbGeneral.ClaveDescripcionVARValor("VERFACTE", 2)
                    'End If


                    oTRPDatoFiscal.TipoVersion = lnTipoVersion
                    oTRPDatoFiscal.Insertar(New String() {"FolioId", "FOSId", "NumCertificado", "Serie", "Aprobacion", "AnioAprobacion", "RazonSocial", "RFC"})
                    oTRPDatoFiscal.Grabar()

                    'Grabar Cadena Original y Sello Digital
                    oTransProd.vgTRPDatoFiscal = oTRPDatoFiscal


                    Dim vlConsulta As New System.Text.StringBuilder
                    vlConsulta.AppendLine("select VAD.Descripcion as Regimen ")
                    vlConsulta.AppendLine("from CEERegimenFiscal CRF ")
                    vlConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'TIPREG' and VAD.VAVClave = CRF.TipoRegimen and VAD.VADTipoLenguaje = '" & lbGeneral.cParametros.Lenguaje & "' ")
                    vlConsulta.AppendLine("where CRF.CentroExpId = '" & loCentroExpEm.CentroExpID & "' ")
                    Dim dtRegimen As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(vlConsulta.ToString)

                    For Each drRegimen As DataRow In dtRegimen.Rows
                        Dim oTRF As New ERMTRPLOG.cTRPRegimenFiscal(oTransProd)
                        oTRF.RegimenID = lbGeneral.cKeyGen.KEYGEN(0)
                        oTRF.Descripcion = drRegimen("Regimen")
                        oTRF.Insertar(New String() {"Descripcion"})
                        oTRF.Grabar()
                    Next

                    Dim lsCadenaOriginal As String = ""

                    If oSubEmpresa.VersionCFD = 1 Or oSubEmpresa.VersionCFD = 3 Then
                        lsCadenaOriginal = oTransProd.CrearCadenaOriginalE(True, bImpuestoGlb)
                    Else
                        lsCadenaOriginal = oTransProd.CrearCadenaOriginalEV3(True, bImpuestoGlb)
                    End If



                    lsCadenaOriginal = lsCadenaOriginal.Replace("&", "&amp;")
                    lsCadenaOriginal = lsCadenaOriginal.Replace("""", "&quot;")
                    lsCadenaOriginal = lsCadenaOriginal.Replace("<", "&lt;")
                    lsCadenaOriginal = lsCadenaOriginal.Replace(">", "&gt;")
                    lsCadenaOriginal = lsCadenaOriginal.Replace("'", "&#36;")
                    Dim lsSelloDigital As String = ""
                    Try
                        lsSelloDigital = oTransProd.CrearSelloDigital(lsCadenaOriginal, oSubEmpresa.SubEmpresaID)
                    Catch ex As LbControlError.cError
                        ex.Mostrar()
                    End Try
                    oTRPDatoFiscal.CadenaOriginal = lsCadenaOriginal
                    oTRPDatoFiscal.SelloDigital = lsSelloDigital
                    oTRPDatoFiscal.Grabar()

                    'Generar Puntos
                    If Not IsNothing(oCliente.CNPId) Then
                        Dim loCNP As New ERMCNPLOG.cConfiguracionPunto
                        Dim loPunto As New ERMPUNLOG.CPuntos

                        loCNP.Recuperar(oCliente.CNPId)
                        If loCNP.Asignar = 1 Then
                            loPunto.Recuperar(oCliente.ClienteClave)
                            loPunto.Venta += 1
                            For Each loCND As ERMCNPLOG.cCNPDetalleVig In loCNP.CNPDetalleVig.ToArrayList
                                If loCND.FechaInicial <= oConexion.ObtenerFecha And loCND.FechaFinal >= oConexion.ObtenerFecha Then
                                    Select Case loCNP.Tipo
                                        Case 1
                                            For Each loCNR As ERMCNPLOG.cCNDRango In loCND.CNDRango.ToArrayList
                                                If loCNR.Rango1 <= lnTotal And loCNR.Rango2 >= lnTotal Then
                                                    loPunto.Saldo += loCNR.Cantidad
                                                End If
                                            Next
                                        Case 2
                                            For Each loCNR As ERMCNPLOG.cCNDRango In loCND.CNDRango.ToArrayList
                                                If loCNR.Rango1 <= loPunto.Venta And loCNR.Rango2 >= loPunto.Venta Then
                                                    loPunto.Saldo += loCNR.Cantidad
                                                End If
                                            Next
                                        Case 3
                                            For Each loPedido As Janus.Windows.GridEX.GridEXRow In grPedidos.GetRows
                                                Dim loTransProd As New ERMTRPLOG.cTransProd
                                                loTransProd.Recuperar(loPedido.Cells("TransProdId").Value)
                                                For Each loTPD As ERMTRPLOG.cTransProdDetalle In loTransProd.TransProdDetalle.ToArrayList
                                                    For Each loCNR As ERMCNPLOG.cCNDRango In loCND.CNDRango.ToArrayList
                                                        'Convertir Cantidad
                                                        Dim loProducto As New ERMPROLOG.cProducto
                                                        loProducto.Recuperar(loTPD.ProductoClave)
                                                        Dim lnCantidad As Double = loProducto.PRU(loTPD.TipoUnidad).PRD(loTPD.ProductoClave).Factor * loTPD.Cantidad
                                                        If loCNR.Rango1 <= lnCantidad And loCNR.Rango2 >= lnCantidad Then
                                                            loPunto.Saldo += lnCantidad
                                                        End If
                                                    Next
                                                Next
                                            Next
                                    End Select
                                End If
                            Next
                            loPunto.Grabar()
                        End If
                    End If

                    'Validad Pagos Automáticos
                    If oConfiguracion.CobrarVentas = False And oConfiguracion.PagoAutomatico = True Then
                        Dim lbGenerarPago As Boolean = True
                        For Each loPedido As Janus.Windows.GridEX.GridEXRow In grPedidos.GetRows
                            Dim loTransProd As New ERMTRPLOG.cTransProd

                            loTransProd.Recuperar(loPedido.Cells("TransProdId").Value)
                            If loTransProd.CFVTipo <> 1 Or loTransProd.ClientePagoID <> 1 Then
                                lbGenerarPago = False
                            End If
                        Next

                        If lbGenerarPago Then
                            Dim lsABNId As String = lbGeneral.cKeyGen.KEYGEN(0)
                            oConexion.EjecutarComando("INSERT INTO Abono (ABNId, Folio, FechaCreacion, VisitaClave, DiaClave, FechaAbono, Total, Saldo, MFechaHora, MUsuarioId) Values('" & lsABNId & "','" & "A" & oTransProd.Folio & "',GETDATE(),'" & lsVisitaClave & "','" & lsDiaClave & "',GETDATE()," & lnTotal & ",0,GETDATE(),'" & lbGeneral.cParametros.UsuarioID & "')")

                            oConexion.EjecutarComando("INSERT INTO ABNDetalle (ABNId, ABDId, TipoPago, Importe, MonedaId, SaldoDeposito, MFechaHora, MUsuarioId) Values('" & lsABNId & "','" & lbGeneral.cKeyGen.KEYGEN(0) & "',1," & lnTotal & ",'" & oConfiguracion.MonedaID & "',0,GETDATE(),'" & lbGeneral.cParametros.UsuarioID & "')")

                            oConexion.EjecutarComando("INSERT INTO ABNTRP (ABNId, TransProdID, FechaHora, Importe, MFechaHora, MUsuarioId) Values('" & lsABNId & "','" & lsTransProdId & "',GETDATE()," & lnTotal & ",GETDATE(),'" & lbGeneral.cParametros.UsuarioID & "')")

                            'Modificar Saldos de Clientes y de TransProd
                            'oCliente.Limpiar()
                            'oCliente.Recuperar(ebClienteClave.Text)
                            oCliente.Bloquear(lbGeneral.cParametros.UsuarioID)
                            oCliente.SaldoEfectivo -= lnTotal
                            oCliente.Grabar()

                            oTransProd.Limpiar()
                            oTransProd.Recuperar(lsTransProdId)
                            oTransProd.Bloquear()
                            oTransProd.Saldo -= lnTotal
                            oTransProd.Grabar()
                        End If
                    End If



                    If (oSubEmpresa.VersionCFD = 1) Then

                        Me.Cursor = Cursors.Default
                        'Imprimir Factura
                        If MsgBox(oMensaje.RecuperarDescripcion("P0118"), MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                            Dim oRep As New RRepFactElectronica
                            oRep.CONSULTAR(oTransProd.TransProdID)
                        End If

                        'Generar XML
                        If MsgBox(oMensaje.RecuperarDescripcion("P0119"), MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                            Dim xml As New PRepXML(oTransProd)
                            xml.ShowDialog()
                        End If
                    ElseIf oSubEmpresa.VersionCFD = 3 Then

                        Try
                            Me.Cursor = Cursors.Default
                            Dim oXML As cTransProd.cXML
                            oTransProd.GenerarSoloXML(oXML, oTransProd, oTransProd.obtenerDirDocXML(oTransProd.SubEmpresaId), False, "", True)
                            If Not oXML Is Nothing Then
                                Dim oRep As New RRepFactElectronica
                                Dim oReporte As CrystalDecisions.CrystalReports.Engine.ReportClass = oRep.CrearReporte(oTransProd.TransProdID)
                                oReporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, System.IO.Path.Combine(oXML.Ruta, System.IO.Path.GetFileNameWithoutExtension(oXML.NombreArchivo) + ".pdf"))
                                oTransProd.EnviarXML(oTransProd, oXML.Ruta, oXML.NombreArchivo, False, "")
                                'Imprimir Factura
                                If MsgBox(oMensaje.RecuperarDescripcion("P0118"), MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                                    oRep.CONSULTAR(oTransProd.TransProdID)
                                End If

                            End If
                        Catch ex As LbControlError.cError
                            ex.Mostrar()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                        'ElseIf oSubEmpresa.VersionCFD = 2 Then
                        '       Dim oCfdi As ERMTRPLOG.CFDi

                        '    Try
                        '    oTransProd.GenerarXMLVersion3(oTransProd, oTransProd.obtenerDirDocXML(oTransProd.SubEmpresaId), False, "", "", oCfdi, False)
                        '    Catch ex As LbControlError.cError
                        '    ex.Mostrar()
                        '    End Try

                        '    If Not oCfdi Is Nothing Then
                        '    oTRPDatoFiscal.NoCertificadoSAT = oCfdi.TimbreFiscal.noCertificadoSAT
                        '    oTRPDatoFiscal.FechaTimbrado = oCfdi.TimbreFiscal.FechaTimbrado
                        '    oCfdi.TimbreFiscal.selloCFD
                        '    oTRPDatoFiscal.SelloSAT = oCfdi.TimbreFiscal.selloSAT
                        '    oTRPDatoFiscal.UUID = oCfdi.TimbreFiscal.UUID
                        '    oTRPDatoFiscal.VersionTFD = oCfdi.TimbreFiscal.version
                        '    oTRPDatoFiscal.CadenaOriginalTFD = oTransProd.CrearCadenaOriginalSello(oCfdi.TimbreFiscal)
                        '    Dim sInutil As String = oTransProd.CrearSelloDigital(oTRPDatoFiscal.CadenaOriginalTFD, oSubEmpresa.SubEmpresaID)
                        '    oTRPDatoFiscal.Grabar()
                        '    oConexion.ConfirmarTran()
                        '    Me.Cursor = Cursors.Default
                        '    If MsgBox(oMensaje.RecuperarDescripcion("P0118"), MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                        '        Dim oRep As New RRepFactElectronica
                        '        oRep.CONSULTAR(oTransProd.TransProdID)
                        '    End If

                        '    Me.DialogResult = Windows.Forms.DialogResult.OK
                        '    bCerrar = True
                        '    Me.Close()
                        '    Else
                        '        oConexion.DeshacerTran()
                        '    End If

                        '    Exit Sub
                        'Else
                        '    Dim oCfdi As ERMTRPLOG.CFDi
                        '    Dim oXML As cTransProd.cXML
                        '    Try
                        '        oTransProd.GenerarSoloXMLVersion3(oXML, oTransProd, oTransProd.obtenerDirDocXML(oTransProd.SubEmpresaId), oCfdi, False, "", False, True)
                        '    Catch ex As LbControlError.cError
                        '        ex.Mostrar()
                        '    End Try

                        '    If Not oCfdi Is Nothing Then
                        '        oTRPDatoFiscal.NoCertificadoSAT = oCfdi.TimbreFiscal.noCertificadoSAT
                        '        oTRPDatoFiscal.FechaTimbrado = oCfdi.TimbreFiscal.FechaTimbrado
                        '        'oCfdi.TimbreFiscal.selloCFD
                        '        oTRPDatoFiscal.SelloSAT = oCfdi.TimbreFiscal.selloSAT
                        '        oTRPDatoFiscal.UUID = oCfdi.TimbreFiscal.UUID
                        '        oTRPDatoFiscal.VersionTFD = oCfdi.TimbreFiscal.version
                        '        oTRPDatoFiscal.CadenaOriginalTFD = oTransProd.CrearCadenaOriginalSello(oCfdi.TimbreFiscal)
                        '        Dim sInutil As String = oTransProd.CrearSelloDigital(oTRPDatoFiscal.CadenaOriginalTFD, oSubEmpresa.SubEmpresaID)
                        '        oTRPDatoFiscal.Grabar()

                        '        Try
                        '            If Not oXML Is Nothing Then
                        '                Dim oRep As New RRepFactElectronica
                        '                Dim oReporte As CrystalDecisions.CrystalReports.Engine.ReportClass = oRep.CrearReporte(oTransProd.TransProdID)
                        '                oReporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, System.IO.Path.Combine(oXML.Ruta, System.IO.Path.GetFileNameWithoutExtension(oXML.NombreArchivo) + ".pdf"))
                        '                oTransProd.EnviarXML(oTransProd, oXML.Ruta, oXML.NombreArchivo, False, "")
                        '            End If
                        '        Catch ex As LbControlError.cError
                        '            ex.Mostrar()
                        '        Catch ex As Exception
                        '            MsgBox(ex.Message)
                        '        End Try

                        '        Me.DialogResult = Windows.Forms.DialogResult.OK
                        '        bCerrar = True
                        '        Me.Close()
                        '    Else
                        '        oConexion.DeshacerTran()
                        '    End If

                        '    Exit Sub
                    End If

                Case eModo.Cancelar
                    oCliente.Limpiar()
                    oCliente.Recuperar(oCliente.ObtenerClienteClave(ebClienteClave.Text))
                    oSubEmpresa.Recuperar(oTransProd.SubEmpresaId, oTransProd.FechaHoraAlta)
                    'Try

                    'If (oSubEmpresa.VersionCFD = 2 Or oSubEmpresa.VersionCFD = 4) Then
                    '    Try
                    '        Dim oSubEmpresaActual As New ERMSEMLOG.cSubEmpresa()
                    '        oSubEmpresaActual.Recuperar(oTransProd.SubEmpresaId, LbConexion.cConexion.Instancia.ObtenerFecha)
                    '        oTransProd.CancelarCFDV3Soap(oTRPDatoFiscal.RFCEm, oTRPDatoFiscal.UUID, oSubEmpresaActual)
                    '    Catch ex As CFDiException
                    '        If (ex.Codigo = 202) Then
                    '            MsgBox(oMensaje.RecuperarDescripcion("E0860").Replace("$0$", oMensaje.RecuperarDescripcion("XFactura")).Replace("$1$", ex.Codigo + " " + ex.Message))
                    '        Else
                    '            MsgBox(oMensaje.RecuperarDescripcion("E0860").Replace("$0$", oMensaje.RecuperarDescripcion("XFactura")).Replace("$1$", ex.Codigo + " " + ex.Message))

                    '            Exit Sub
                    '        End If
                    '    End Try


                    'End If

                    'Catch Ex As System.Web.Services.Protocols.SoapException
                    '    Exit Sub
                    'Catch Ex As Exception
                    '    Exit Sub

                    'End Try

                    oTransProd.TipoFase = 0
                    oTransProd.FechaCancelacion = oConexion.ObtenerFecha
                    oTransProd.Grabar()
                    If (oSubEmpresa.VersionCFD = 2 Or oSubEmpresa.VersionCFD = 4) Then
                        oTRPDatoFiscal.Grabar()
                    End If

                    'Cancelar Pedidos
                    For Each loPedido As Janus.Windows.GridEX.GridEXRow In grPedidos.GetRows
                        Dim loTransProd As New ERMTRPLOG.cTransProd

                        loTransProd.Recuperar(loPedido.Cells("TransProdId").Value)
                        loTransProd.TipoFase = 2
                        loTransProd.FechaFacturacion = CDate("01/01/1900")
                        loTransProd.FacturaID = ""
                        loTransProd.Grabar()
                    Next

                    'Cancelar Pagos
                    If oConfiguracion.CobrarVentas = False Then
                        oCliente.Bloquear(lbGeneral.cParametros.UsuarioID)
                        oCliente.SaldoEfectivo -= oTransProd.Total
                        oCliente.Grabar()

                        If oConfiguracion.PagoAutomatico = True Then
                            Dim lbEliminarPago As Boolean = True
                            For Each loPedido As Janus.Windows.GridEX.GridEXRow In grPedidos.GetRows
                                Dim loTransProd As New ERMTRPLOG.cTransProd

                                loTransProd.Recuperar(loPedido.Cells("TransProdId").Value)
                                If loTransProd.CFVTipo <> 1 Or loTransProd.ClientePagoID <> 1 Then
                                    lbEliminarPago = False
                                End If
                            Next

                            If lbEliminarPago Then
                                Dim ldtABNTRP As DataTable = oConexion.EjecutarConsulta("SELECT * FROM ABNTRP WHERE TransProdId='" & oTransProd.TransProdID & "'")
                                If ldtABNTRP.Rows.Count > 0 Then
                                    Dim lsABNId As String = ldtABNTRP.Rows(0)!ABNId
                                    Dim lnImporte As Double = ldtABNTRP.Rows(0)!Importe
                                    Dim lnTipoPago As Integer = oConexion.EjecutarConsulta("SELECT TipoPago FROM ABNDetalle WHERE ABNId='" & lsABNId & "'").Rows(0)!TipoPago
                                    oConexion.EjecutarComando("DELETE FROM ABNTRP WHERE ABNId='" & lsABNId & "'")
                                    oConexion.EjecutarComando("DELETE FROM ABNDetalle WHERE ABNId='" & lsABNId & "'")
                                    oConexion.EjecutarComando("DELETE FROM Abono WHERE ABNId='" & lsABNId & "'")
                                    Dim cmd As String = "DELETE FROM CAFDetalle WHERE ClienteClave = '" + oCliente.ClienteClave + "' AND Folio = '" + Me.cbFolio.Text + "'"
                                    oConexion.EjecutarComando(cmd)
                                    oCliente.Bloquear(lbGeneral.cParametros.UsuarioID)
                                    oCliente.SaldoEfectivo += oTransProd.Total
                                    oCliente.Grabar()

                                    oTransProd.Bloquear()
                                    oTransProd.Saldo += lnImporte
                                    oTransProd.Grabar()
                                End If
                            End If
                        End If
                    End If

                    'Cancelar Puntos
                    If Not IsNothing(oCliente.CNPId) Then
                        Dim loCNP As New ERMCNPLOG.cConfiguracionPunto
                        Dim loPunto As New ERMPUNLOG.CPuntos

                        loCNP.Recuperar(oCliente.CNPId)
                        If loCNP.Asignar = 1 Then
                            loPunto.Recuperar(oCliente.ClienteClave)

                            For Each loCND As ERMCNPLOG.cCNPDetalleVig In loCNP.CNPDetalleVig.ToArrayList
                                If loCND.FechaInicial <= oConexion.ObtenerFecha And loCND.FechaFinal >= oConexion.ObtenerFecha Then
                                    Select Case loCNP.Tipo
                                        Case 1
                                            For Each loCNR As ERMCNPLOG.cCNDRango In loCND.CNDRango.ToArrayList
                                                If loCNR.Rango1 <= oTransProd.Total And loCNR.Rango2 >= oTransProd.Total Then
                                                    loPunto.Saldo -= loCNR.Cantidad
                                                End If
                                            Next
                                        Case 2
                                            For Each loCNR As ERMCNPLOG.cCNDRango In loCND.CNDRango.ToArrayList
                                                If loCNR.Rango1 <= loPunto.Venta And loCNR.Rango2 >= loPunto.Venta Then
                                                    loPunto.Saldo -= loCNR.Cantidad
                                                End If
                                            Next
                                        Case 3
                                            For Each loPedido As Janus.Windows.GridEX.GridEXRow In grPedidos.GetRows
                                                Dim loTransProd As New ERMTRPLOG.cTransProd
                                                loTransProd.Recuperar(loPedido.Cells("TransProdId").Value)
                                                For Each loTPD As ERMTRPLOG.cTransProdDetalle In loTransProd.TransProdDetalle.ToArrayList
                                                    For Each loCNR As ERMCNPLOG.cCNDRango In loCND.CNDRango.ToArrayList
                                                        'Convertir Cantidad
                                                        Dim loProducto As New ERMPROLOG.cProducto
                                                        loProducto.Recuperar(loTPD.ProductoClave)
                                                        Dim lnCantidad As Double = loProducto.PRU(loTPD.TipoUnidad).PRD(loTPD.ProductoClave).Factor * loTPD.Cantidad
                                                        If loCNR.Rango1 <= lnCantidad And loCNR.Rango2 >= lnCantidad Then
                                                            loPunto.Saldo -= lnCantidad
                                                        End If
                                                    Next
                                                Next
                                            Next
                                    End Select
                                End If
                            Next
                            loPunto.Venta -= 1
                            loPunto.Grabar()
                        End If
                    End If

                    oConexion.ConfirmarTran()
            End Select
        Catch ex As LbControlError.cError
            'If (oSubEmpresa.VersionCFD = 1) Then
            ex.Mostrar()
            Exit Sub
            'Else
            '    If ex.Codigo = "I0212" Then

            '    End If
            'End If

        Catch ExcW As CFDiException
            oConexion.DeshacerTran()

            MsgBox(oMensaje.RecuperarDescripcion("E0842").Replace("$0$", oMensaje.RecuperarDescripcion("XFactura")).Replace("$1$", ExcW.Codigo + " " + ExcW.Message))
            bCerrar = True
            Me.Close()
            Exit Sub
        Catch ExcW As System.Net.WebException
            oConexion.DeshacerTran()

            MsgBox(oMensaje.RecuperarDescripcion("E0843"))

            Exit Sub
        Catch ex As Exception
            oConexion.DeshacerTran()
            MsgBox(ex.Message)
            bCerrar = True
            Me.Close()
            Exit Sub
        Finally
            Me.BtAceptar.Enabled = True
            Me.BtCancelar.Enabled = True
            Me.Cursor = Cursors.Default

        End Try

        Me.DialogResult = Windows.Forms.DialogResult.OK
        bCerrar = True
        Me.Close()
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        Me.Close()
    End Sub

    Private Sub MGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not bCerrar Then
            Me.DialogResult = Windows.Forms.DialogResult.None
            If tModo = eModo.Crear Or tModo = eModo.Modificar Then
                If Not bCerrar And bHuboCambios Then
                    If (MsgBox(oMensaje.RecuperarDescripcion("BP0001"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.No) Then
                        Exit Sub
                    End If
                End If
            End If
            oTransProd.Limpiar()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub
#End Region

    Private Sub MFacturasElectronicas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.TabFacturacion.SelectedTabIndex = 0
    End Sub

    Private Sub LimpiarCliente()
        bClienteValido = False
        ebClienteClave.Enabled = False
        btBuscarCliente.Enabled = False
        ebClienteClave.Text = ""
        ebClienteNombre.Text = ""
    End Sub

    Private Sub btBuscarEsquema_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscarEsquema.Click
        Dim oIndice As New ERMESQESC.IGeneral(False, "Nombre, Abreviatura, Clave", "Tipo = 1")
        oIndice.ShowDialog()
        If oIndice.Seleccion.Count > 0 Then
            Dim drEsquema As DataRow = oIndice.Seleccion(0)
            ebEsquemaClave.Text = drEsquema("Clave")
            ebEsquemaNombre.Text = drEsquema("Nombre")
            If drEsquema("EsquemaId") <> sEsquemaId Then
                LimpiarCliente()
            End If
            sEsquemaId = drEsquema("EsquemaId")
            ebClienteClave.Enabled = True
            btBuscarCliente.Enabled = True
        End If

        'Dim oIndice As New ERMESQESC.IFacturacion()
        'If oIndice.Seleccionar() Then
        '    ebEsquemaClave.Text = oIndice.EsquemaNombre
        '    ebEsquemaNombre.Text = oIndice.IdFiscal & " - " & oIndice.RazonSocial
        '    sEsquemaId = oIndice.EsquemaId
        '    sIdFiscal = oIndice.IdFiscal
        '    Try
        '        Me.TabControlPanel3.Controls.Clear()
        '        Me.TpComplemento.Visible = False
        '        BuscarCliente("")
        '        epErrores.SetError(ebClienteNombre, "")
        '    Catch ex As LbControlError.cError
        '        epErrores.SetError(ebClienteNombre, ex.Mensaje)
        '    End Try
        'End If
    End Sub

    'Private Sub rbtEsquema_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btBuscarEsquema.Enabled = rbtEsquema.Checked
    '    If Not rbtEsquema.Checked Then
    '        ebEsquemaClave.Text = String.Empty
    '        ebEsquemaNombre.Text = String.Empty
    '        sEsquemaId = String.Empty
    '        sIdFiscal = String.Empty
    '        LimpiarDatosCliente()
    '    End If
    '    bClienteValido = False
    '    epErrores.SetError(ebClienteNombre, "")
    'End Sub

    'Private Sub rbtCliente_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btBuscarCliente.Enabled = rbtCliente.Checked
    '    ebClienteClave.Enabled = rbtCliente.Checked
    '    If Not rbtCliente.Checked Then
    '        ebClienteClave.Text = ""
    '        ebClienteNombre.Text = ""
    '        LimpiarDatosCliente()
    '    End If
    '    bClienteValido = False
    '    epErrores.SetError(ebClienteNombre, "")
    'End Sub

    Private Sub BTVistaPrevia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTVistaPrevia.Click
        Dim detalle As New IDetallePedidos()
        Dim Pedidos As New List(Of String)
        For Each lrRow As Janus.Windows.GridEX.GridEXRow In grPedidos.GetRows()
            Pedidos.Add(lrRow.Cells("TransProdId").Value)
        Next
        detalle.ConsultarDetalle(Pedidos)

    End Sub

    Private Sub btBuscarRuta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btBuscarRuta.Click
        Dim oIndice As New ERMRUTESC.IGeneral(False, "RUTClave, Descripcion, Tipo", "TipoEstado = 1")
        oIndice.ShowDialog()
        If oIndice.aSeleccion.Count > 0 Then
            Dim oRuta As ERMRUTLOG.cRuta
            oRuta = oIndice.aSeleccion(0)
            ebRutClave.Text = oRuta.RUTClave
            ebRutDescripcion.Text = oRuta.Descripcion
        End If
    End Sub

    Private Sub ebRutClave_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ebRutClave.Validating
        If ebRutClave.Text.Trim <> "" Then
            Dim oRuta As New ERMRUTLOG.cRuta
            If oRuta.Existe(ebRutClave.Text.Trim) Then
                oRuta.Recuperar(ebRutClave.Text.Trim)
                If oRuta.TipoEstado = 0 Then
                    MsgBox(oMensaje.RecuperarDescripcion("E0096"), MsgBoxStyle.Information Or MsgBoxStyle.Exclamation, oMensaje.RecuperarDescripcion("MensajeE"))
                    ebRutDescripcion.Text = ""
                    e.Cancel = True
                Else
                    ebRutClave.Text = oRuta.RUTClave
                    ebRutDescripcion.Text = oRuta.Descripcion
                End If
            Else
                MsgBox(oMensaje.RecuperarDescripcion("E0096"), MsgBoxStyle.Information Or MsgBoxStyle.Exclamation, oMensaje.RecuperarDescripcion("MensajeE"))
                ebRutDescripcion.Text = ""
                e.Cancel = True
            End If
        Else
            ebRutDescripcion.Text = ""
        End If
    End Sub

    Private Sub btMetodoPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btMetodoPago.Click
        Dim oMetodoPago As New IMetodosPago
        Dim aMetodos As IList(Of IMetodosPago.MetodoPago) = oMetodoPago.SeleccionarMetodosCuentas(oCliente.ClienteClave, IIf(grMetodosPago.RowCount <= 0, Nothing, grMetodosPago.DataSource))
        If Not IsNothing(aMetodos) AndAlso aMetodos.Count > 0 Then
            grMetodosPago.DataSource = aMetodos
        End If
    End Sub

    Private Sub ebClienteNombre_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ebClienteNombre.TextChanged
        If ebClienteNombre.Text.Trim.Equals(String.Empty) Then
            btMetodoPago.Enabled = False
        Else
            btMetodoPago.Enabled = True
        End If
    End Sub
End Class
