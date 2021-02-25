<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormClienteDetalle
    Inherits System.Windows.Forms.Form

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents MainMenuAgenda As System.Windows.Forms.MainMenu
    Friend WithEvents InputPanelAgenda As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        If Not IsNothing(DetailViewCliente) Then DetailViewCliente.Dispose()
        If Not IsNothing(DetailViewDomPuntoE) Then DetailViewDomPuntoE.Dispose()
        If Not IsNothing(DetailViewDomFiscal) Then DetailViewDomFiscal.Dispose()

        If Not IsNothing(Me.MenuItemRegresar) Then MenuItemRegresar.Dispose()
        If Not IsNothing(Me.MainMenuAgenda) Then MainMenuAgenda.Dispose()

        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MainMenuAgenda = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.InputPanelAgenda = New Microsoft.WindowsCE.Forms.InputPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControlDetalles = New System.Windows.Forms.TabControl
        Me.TabPageGeneral = New System.Windows.Forms.TabPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.CheckBoxDesglose = New System.Windows.Forms.CheckBox
        Me.txtTelefono = New System.Windows.Forms.TextBox
        Me.txtContacto = New System.Windows.Forms.TextBox
        Me.dtpFechaNac = New System.Windows.Forms.DateTimePicker
        Me.dtpFechaRegistro = New System.Windows.Forms.DateTimePicker
        Me.txtRFC = New System.Windows.Forms.TextBox
        Me.txtCodigoBarras = New System.Windows.Forms.TextBox
        Me.txtNombreCorto = New System.Windows.Forms.TextBox
        Me.txtRazonSocial = New System.Windows.Forms.TextBox
        Me.txtClave = New System.Windows.Forms.TextBox
        Me.lbTelefono = New System.Windows.Forms.Label
        Me.lbContacto = New System.Windows.Forms.Label
        Me.lbFechaNac = New System.Windows.Forms.Label
        Me.lbFechaRegistro = New System.Windows.Forms.Label
        Me.lbRFC = New System.Windows.Forms.Label
        Me.lbCodigoBarras = New System.Windows.Forms.Label
        Me.lbNombreCorto = New System.Windows.Forms.Label
        Me.lbRazonSocial = New System.Windows.Forms.Label
        Me.lbClave = New System.Windows.Forms.Label
        Me.DetailViewCliente = New Resco.Controls.DetailView.DetailView
        Me.LabelCliente = New System.Windows.Forms.Label
        Me.TabPageDomicilios = New System.Windows.Forms.TabPage
        Me.TabControlDomicilios = New System.Windows.Forms.TabControl
        Me.TabPagePuntoE = New System.Windows.Forms.TabPage
        Me.DetailViewDomPuntoE = New Resco.Controls.DetailView.DetailView
        Me.PanelDomPuntoE = New System.Windows.Forms.Panel
        Me.txtPaisPE = New System.Windows.Forms.TextBox
        Me.txtEntidadPE = New System.Windows.Forms.TextBox
        Me.txtPoblacionPE = New System.Windows.Forms.TextBox
        Me.txtReferenciaPE = New System.Windows.Forms.TextBox
        Me.txtCodigoPostalPE = New System.Windows.Forms.TextBox
        Me.txtColoniaPE = New System.Windows.Forms.TextBox
        Me.txtInteriorPE = New System.Windows.Forms.TextBox
        Me.txtNumeroPE = New System.Windows.Forms.TextBox
        Me.txtCallePE = New System.Windows.Forms.TextBox
        Me.lbPais = New System.Windows.Forms.Label
        Me.lbEntidad = New System.Windows.Forms.Label
        Me.lbReferencia = New System.Windows.Forms.Label
        Me.lbPoblacion = New System.Windows.Forms.Label
        Me.lbCodigoPostal = New System.Windows.Forms.Label
        Me.lbColonia = New System.Windows.Forms.Label
        Me.lbInterior = New System.Windows.Forms.Label
        Me.lbNumero = New System.Windows.Forms.Label
        Me.lbCalle = New System.Windows.Forms.Label
        Me.TabPageFiscal = New System.Windows.Forms.TabPage
        Me.PanelDomFiscal = New System.Windows.Forms.Panel
        Me.txtPaisFiscal = New System.Windows.Forms.TextBox
        Me.txtEntidadFiscal = New System.Windows.Forms.TextBox
        Me.txtPoblacionFiscal = New System.Windows.Forms.TextBox
        Me.txtReferenciaFiscal = New System.Windows.Forms.TextBox
        Me.txtCodigoPostalFiscal = New System.Windows.Forms.TextBox
        Me.txtColoniaFiscal = New System.Windows.Forms.TextBox
        Me.txtInteriorFiscal = New System.Windows.Forms.TextBox
        Me.txtNumeroFiscal = New System.Windows.Forms.TextBox
        Me.txtCalleFiscal = New System.Windows.Forms.TextBox
        Me.lbPais2 = New System.Windows.Forms.Label
        Me.lbEntidad2 = New System.Windows.Forms.Label
        Me.lbReferencia2 = New System.Windows.Forms.Label
        Me.lbPoblacion2 = New System.Windows.Forms.Label
        Me.lbCodigoPostal2 = New System.Windows.Forms.Label
        Me.lbColonia2 = New System.Windows.Forms.Label
        Me.lbInterior2 = New System.Windows.Forms.Label
        Me.lbNumero2 = New System.Windows.Forms.Label
        Me.LbCalle2 = New System.Windows.Forms.Label
        Me.DetailViewDomFiscal = New Resco.Controls.DetailView.DetailView
        Me.TabPageConfiguracion = New System.Windows.Forms.TabPage
        Me.CheckBoxPrestamoEnvases = New System.Windows.Forms.CheckBox
        Me.dtVig = New System.Windows.Forms.DateTimePicker
        Me.CheckBoxExclusividad = New System.Windows.Forms.CheckBox
        Me.LabelVigExclusividad = New System.Windows.Forms.Label
        Me.btEsquemas = New System.Windows.Forms.Button
        Me.btCompra = New System.Windows.Forms.Button
        Me.btEnvase = New System.Windows.Forms.Button
        Me.btActivos = New System.Windows.Forms.Button
        Me.lbEsquemas = New System.Windows.Forms.Label
        Me.lbCompra = New System.Windows.Forms.Label
        Me.lbEnvase = New System.Windows.Forms.Label
        Me.lbActivos = New System.Windows.Forms.Label
        Me.TabPageCredito = New System.Windows.Forms.TabPage
        Me.txtFechaFactura = New System.Windows.Forms.TextBox
        Me.txtSaldoCliente = New System.Windows.Forms.TextBox
        Me.txtImporte = New System.Windows.Forms.TextBox
        Me.txtCantidad = New System.Windows.Forms.TextBox
        Me.lbFechaFactura = New System.Windows.Forms.Label
        Me.lbSaldoCliente = New System.Windows.Forms.Label
        Me.lbCreditosPendientes = New System.Windows.Forms.Label
        Me.ButtonClienteContinuar = New System.Windows.Forms.Button
        Me.ButtonClienteRegresar = New System.Windows.Forms.Button
        Me.ButtonClienteEditar = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.TabControlDetalles.SuspendLayout()
        Me.TabPageGeneral.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabPageDomicilios.SuspendLayout()
        Me.TabControlDomicilios.SuspendLayout()
        Me.TabPagePuntoE.SuspendLayout()
        Me.PanelDomPuntoE.SuspendLayout()
        Me.TabPageFiscal.SuspendLayout()
        Me.PanelDomFiscal.SuspendLayout()
        Me.TabPageConfiguracion.SuspendLayout()
        Me.TabPageCredito.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuAgenda
        '
        Me.MainMenuAgenda.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControlDetalles)
        Me.Panel1.Controls.Add(Me.ButtonClienteContinuar)
        Me.Panel1.Controls.Add(Me.ButtonClienteRegresar)
        Me.Panel1.Controls.Add(Me.ButtonClienteEditar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(240, 295)
        '
        'TabControlDetalles
        '
        Me.TabControlDetalles.Controls.Add(Me.TabPageGeneral)
        Me.TabControlDetalles.Controls.Add(Me.TabPageDomicilios)
        Me.TabControlDetalles.Controls.Add(Me.TabPageConfiguracion)
        Me.TabControlDetalles.Controls.Add(Me.TabPageCredito)
        Me.TabControlDetalles.Location = New System.Drawing.Point(0, 0)
        Me.TabControlDetalles.Name = "TabControlDetalles"
        Me.TabControlDetalles.SelectedIndex = 0
        Me.TabControlDetalles.Size = New System.Drawing.Size(240, 256)
        Me.TabControlDetalles.TabIndex = 4
        '
        'TabPageGeneral
        '
        Me.TabPageGeneral.Controls.Add(Me.Panel2)
        Me.TabPageGeneral.Controls.Add(Me.DetailViewCliente)
        Me.TabPageGeneral.Controls.Add(Me.LabelCliente)
        Me.TabPageGeneral.Location = New System.Drawing.Point(4, 25)
        Me.TabPageGeneral.Name = "TabPageGeneral"
        Me.TabPageGeneral.Size = New System.Drawing.Size(232, 227)
        Me.TabPageGeneral.Text = "TabPageGeneral"
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.CheckBoxDesglose)
        Me.Panel2.Controls.Add(Me.txtTelefono)
        Me.Panel2.Controls.Add(Me.txtContacto)
        Me.Panel2.Controls.Add(Me.dtpFechaNac)
        Me.Panel2.Controls.Add(Me.dtpFechaRegistro)
        Me.Panel2.Controls.Add(Me.txtRFC)
        Me.Panel2.Controls.Add(Me.txtCodigoBarras)
        Me.Panel2.Controls.Add(Me.txtNombreCorto)
        Me.Panel2.Controls.Add(Me.txtRazonSocial)
        Me.Panel2.Controls.Add(Me.txtClave)
        Me.Panel2.Controls.Add(Me.lbTelefono)
        Me.Panel2.Controls.Add(Me.lbContacto)
        Me.Panel2.Controls.Add(Me.lbFechaNac)
        Me.Panel2.Controls.Add(Me.lbFechaRegistro)
        Me.Panel2.Controls.Add(Me.lbRFC)
        Me.Panel2.Controls.Add(Me.lbCodigoBarras)
        Me.Panel2.Controls.Add(Me.lbNombreCorto)
        Me.Panel2.Controls.Add(Me.lbRazonSocial)
        Me.Panel2.Controls.Add(Me.lbClave)
        Me.Panel2.Location = New System.Drawing.Point(4, 19)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(229, 211)
        '
        'CheckBoxDesglose
        '
        Me.CheckBoxDesglose.Location = New System.Drawing.Point(109, 187)
        Me.CheckBoxDesglose.Name = "CheckBoxDesglose"
        Me.CheckBoxDesglose.Size = New System.Drawing.Size(100, 20)
        Me.CheckBoxDesglose.TabIndex = 10
        Me.CheckBoxDesglose.Text = "Desglose"
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(109, 165)
        Me.txtTelefono.MaxLength = 64
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(100, 23)
        Me.txtTelefono.TabIndex = 9
        '
        'txtContacto
        '
        Me.txtContacto.Location = New System.Drawing.Point(109, 146)
        Me.txtContacto.MaxLength = 64
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.Size = New System.Drawing.Size(100, 23)
        Me.txtContacto.TabIndex = 8
        '
        'dtpFechaNac
        '
        Me.dtpFechaNac.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaNac.Location = New System.Drawing.Point(109, 124)
        Me.dtpFechaNac.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFechaNac.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaNac.Name = "dtpFechaNac"
        Me.dtpFechaNac.Size = New System.Drawing.Size(100, 24)
        Me.dtpFechaNac.TabIndex = 7
        Me.dtpFechaNac.Value = New Date(2007, 1, 30, 0, 0, 0, 0)
        '
        'dtpFechaRegistro
        '
        Me.dtpFechaRegistro.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaRegistro.Location = New System.Drawing.Point(109, 101)
        Me.dtpFechaRegistro.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFechaRegistro.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaRegistro.Name = "dtpFechaRegistro"
        Me.dtpFechaRegistro.Size = New System.Drawing.Size(100, 24)
        Me.dtpFechaRegistro.TabIndex = 6
        Me.dtpFechaRegistro.Value = New Date(2007, 1, 30, 0, 0, 0, 0)
        '
        'txtRFC
        '
        Me.txtRFC.Location = New System.Drawing.Point(109, 82)
        Me.txtRFC.MaxLength = 64
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(100, 23)
        Me.txtRFC.TabIndex = 5
        '
        'txtCodigoBarras
        '
        Me.txtCodigoBarras.Location = New System.Drawing.Point(109, 62)
        Me.txtCodigoBarras.MaxLength = 64
        Me.txtCodigoBarras.Name = "txtCodigoBarras"
        Me.txtCodigoBarras.Size = New System.Drawing.Size(100, 23)
        Me.txtCodigoBarras.TabIndex = 4
        '
        'txtNombreCorto
        '
        Me.txtNombreCorto.Location = New System.Drawing.Point(109, 42)
        Me.txtNombreCorto.MaxLength = 32
        Me.txtNombreCorto.Name = "txtNombreCorto"
        Me.txtNombreCorto.Size = New System.Drawing.Size(100, 23)
        Me.txtNombreCorto.TabIndex = 3
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.Location = New System.Drawing.Point(109, 22)
        Me.txtRazonSocial.MaxLength = 128
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(100, 23)
        Me.txtRazonSocial.TabIndex = 2
        '
        'txtClave
        '
        Me.txtClave.Enabled = False
        Me.txtClave.Location = New System.Drawing.Point(109, 2)
        Me.txtClave.MaxLength = 16
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(100, 23)
        Me.txtClave.TabIndex = 1
        '
        'lbTelefono
        '
        Me.lbTelefono.Location = New System.Drawing.Point(3, 169)
        Me.lbTelefono.Name = "lbTelefono"
        Me.lbTelefono.Size = New System.Drawing.Size(100, 20)
        Me.lbTelefono.Text = "lbTelefono"
        '
        'lbContacto
        '
        Me.lbContacto.Location = New System.Drawing.Point(3, 149)
        Me.lbContacto.Name = "lbContacto"
        Me.lbContacto.Size = New System.Drawing.Size(100, 20)
        Me.lbContacto.Text = "lbContacto"
        '
        'lbFechaNac
        '
        Me.lbFechaNac.Location = New System.Drawing.Point(3, 129)
        Me.lbFechaNac.Name = "lbFechaNac"
        Me.lbFechaNac.Size = New System.Drawing.Size(100, 20)
        Me.lbFechaNac.Text = "lbFechaNac"
        '
        'lbFechaRegistro
        '
        Me.lbFechaRegistro.Location = New System.Drawing.Point(3, 109)
        Me.lbFechaRegistro.Name = "lbFechaRegistro"
        Me.lbFechaRegistro.Size = New System.Drawing.Size(100, 20)
        Me.lbFechaRegistro.Text = "lbFechaRegistro"
        '
        'lbRFC
        '
        Me.lbRFC.Location = New System.Drawing.Point(3, 89)
        Me.lbRFC.Name = "lbRFC"
        Me.lbRFC.Size = New System.Drawing.Size(100, 20)
        Me.lbRFC.Text = "lbRFC"
        '
        'lbCodigoBarras
        '
        Me.lbCodigoBarras.Location = New System.Drawing.Point(3, 69)
        Me.lbCodigoBarras.Name = "lbCodigoBarras"
        Me.lbCodigoBarras.Size = New System.Drawing.Size(100, 20)
        Me.lbCodigoBarras.Text = "lbCodigoBarras"
        '
        'lbNombreCorto
        '
        Me.lbNombreCorto.Location = New System.Drawing.Point(3, 49)
        Me.lbNombreCorto.Name = "lbNombreCorto"
        Me.lbNombreCorto.Size = New System.Drawing.Size(100, 20)
        Me.lbNombreCorto.Text = "lbNombreCorto"
        '
        'lbRazonSocial
        '
        Me.lbRazonSocial.Location = New System.Drawing.Point(3, 29)
        Me.lbRazonSocial.Name = "lbRazonSocial"
        Me.lbRazonSocial.Size = New System.Drawing.Size(100, 20)
        Me.lbRazonSocial.Text = "lbRazonSocial"
        '
        'lbClave
        '
        Me.lbClave.Location = New System.Drawing.Point(3, 9)
        Me.lbClave.Name = "lbClave"
        Me.lbClave.Size = New System.Drawing.Size(100, 20)
        Me.lbClave.Text = "lbClave"
        '
        'DetailViewCliente
        '
        Me.DetailViewCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DetailViewCliente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetailViewCliente.LabelWidth = 110
        Me.DetailViewCliente.Location = New System.Drawing.Point(4, 16)
        Me.DetailViewCliente.Name = "DetailViewCliente"
        Me.DetailViewCliente.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.TabStrip
        Me.DetailViewCliente.SeparatorWidth = 4
        Me.DetailViewCliente.Size = New System.Drawing.Size(228, 186)
        Me.DetailViewCliente.TabIndex = 19
        Me.DetailViewCliente.Visible = False
        '
        'LabelCliente
        '
        Me.LabelCliente.Location = New System.Drawing.Point(4, 0)
        Me.LabelCliente.Name = "LabelCliente"
        Me.LabelCliente.Size = New System.Drawing.Size(232, 16)
        Me.LabelCliente.Text = "LabelCliente"
        '
        'TabPageDomicilios
        '
        Me.TabPageDomicilios.Controls.Add(Me.TabControlDomicilios)
        Me.TabPageDomicilios.Location = New System.Drawing.Point(4, 25)
        Me.TabPageDomicilios.Name = "TabPageDomicilios"
        Me.TabPageDomicilios.Size = New System.Drawing.Size(232, 227)
        Me.TabPageDomicilios.Text = "TabPageDomicilios"
        '
        'TabControlDomicilios
        '
        Me.TabControlDomicilios.Controls.Add(Me.TabPagePuntoE)
        Me.TabControlDomicilios.Controls.Add(Me.TabPageFiscal)
        Me.TabControlDomicilios.Location = New System.Drawing.Point(0, 0)
        Me.TabControlDomicilios.Name = "TabControlDomicilios"
        Me.TabControlDomicilios.SelectedIndex = 0
        Me.TabControlDomicilios.Size = New System.Drawing.Size(232, 227)
        Me.TabControlDomicilios.TabIndex = 0
        '
        'TabPagePuntoE
        '
        Me.TabPagePuntoE.Controls.Add(Me.DetailViewDomPuntoE)
        Me.TabPagePuntoE.Controls.Add(Me.PanelDomPuntoE)
        Me.TabPagePuntoE.Location = New System.Drawing.Point(4, 25)
        Me.TabPagePuntoE.Name = "TabPagePuntoE"
        Me.TabPagePuntoE.Size = New System.Drawing.Size(224, 198)
        Me.TabPagePuntoE.Text = "TabPagePuntoE"
        '
        'DetailViewDomPuntoE
        '
        Me.DetailViewDomPuntoE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DetailViewDomPuntoE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetailViewDomPuntoE.LabelWidth = 110
        Me.DetailViewDomPuntoE.Location = New System.Drawing.Point(0, 0)
        Me.DetailViewDomPuntoE.Name = "DetailViewDomicilios"
        Me.DetailViewDomPuntoE.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.TabStrip
        Me.DetailViewDomPuntoE.SeparatorWidth = 4
        Me.DetailViewDomPuntoE.Size = New System.Drawing.Size(228, 186)
        Me.DetailViewDomPuntoE.TabIndex = 14
        Me.DetailViewDomPuntoE.Visible = False
        '
        'PanelDomPuntoE
        '
        Me.PanelDomPuntoE.AutoScroll = True
        Me.PanelDomPuntoE.Controls.Add(Me.txtPaisPE)
        Me.PanelDomPuntoE.Controls.Add(Me.txtEntidadPE)
        Me.PanelDomPuntoE.Controls.Add(Me.txtPoblacionPE)
        Me.PanelDomPuntoE.Controls.Add(Me.txtReferenciaPE)
        Me.PanelDomPuntoE.Controls.Add(Me.txtCodigoPostalPE)
        Me.PanelDomPuntoE.Controls.Add(Me.txtColoniaPE)
        Me.PanelDomPuntoE.Controls.Add(Me.txtInteriorPE)
        Me.PanelDomPuntoE.Controls.Add(Me.txtNumeroPE)
        Me.PanelDomPuntoE.Controls.Add(Me.txtCallePE)
        Me.PanelDomPuntoE.Controls.Add(Me.lbPais)
        Me.PanelDomPuntoE.Controls.Add(Me.lbEntidad)
        Me.PanelDomPuntoE.Controls.Add(Me.lbReferencia)
        Me.PanelDomPuntoE.Controls.Add(Me.lbPoblacion)
        Me.PanelDomPuntoE.Controls.Add(Me.lbCodigoPostal)
        Me.PanelDomPuntoE.Controls.Add(Me.lbColonia)
        Me.PanelDomPuntoE.Controls.Add(Me.lbInterior)
        Me.PanelDomPuntoE.Controls.Add(Me.lbNumero)
        Me.PanelDomPuntoE.Controls.Add(Me.lbCalle)
        Me.PanelDomPuntoE.Location = New System.Drawing.Point(0, 0)
        Me.PanelDomPuntoE.Name = "PanelDomPuntoE"
        Me.PanelDomPuntoE.Size = New System.Drawing.Size(225, 202)
        '
        'txtPaisPE
        '
        Me.txtPaisPE.Location = New System.Drawing.Point(95, 175)
        Me.txtPaisPE.MaxLength = 32
        Me.txtPaisPE.Name = "txtPaisPE"
        Me.txtPaisPE.Size = New System.Drawing.Size(121, 23)
        Me.txtPaisPE.TabIndex = 19
        '
        'txtEntidadPE
        '
        Me.txtEntidadPE.Location = New System.Drawing.Point(95, 153)
        Me.txtEntidadPE.MaxLength = 32
        Me.txtEntidadPE.Name = "txtEntidadPE"
        Me.txtEntidadPE.Size = New System.Drawing.Size(121, 23)
        Me.txtEntidadPE.TabIndex = 18
        '
        'txtPoblacionPE
        '
        Me.txtPoblacionPE.Location = New System.Drawing.Point(95, 131)
        Me.txtPoblacionPE.MaxLength = 64
        Me.txtPoblacionPE.Name = "txtPoblacionPE"
        Me.txtPoblacionPE.Size = New System.Drawing.Size(121, 23)
        Me.txtPoblacionPE.TabIndex = 14
        '
        'txtReferenciaPE
        '
        Me.txtReferenciaPE.Location = New System.Drawing.Point(95, 109)
        Me.txtReferenciaPE.MaxLength = 64
        Me.txtReferenciaPE.Name = "txtReferenciaPE"
        Me.txtReferenciaPE.Size = New System.Drawing.Size(121, 23)
        Me.txtReferenciaPE.TabIndex = 16
        '
        'txtCodigoPostalPE
        '
        Me.txtCodigoPostalPE.Location = New System.Drawing.Point(95, 88)
        Me.txtCodigoPostalPE.MaxLength = 64
        Me.txtCodigoPostalPE.Name = "txtCodigoPostalPE"
        Me.txtCodigoPostalPE.Size = New System.Drawing.Size(121, 23)
        Me.txtCodigoPostalPE.TabIndex = 15
        '
        'txtColoniaPE
        '
        Me.txtColoniaPE.Location = New System.Drawing.Point(95, 67)
        Me.txtColoniaPE.MaxLength = 16
        Me.txtColoniaPE.Name = "txtColoniaPE"
        Me.txtColoniaPE.Size = New System.Drawing.Size(121, 23)
        Me.txtColoniaPE.TabIndex = 14
        '
        'txtInteriorPE
        '
        Me.txtInteriorPE.Location = New System.Drawing.Point(95, 45)
        Me.txtInteriorPE.MaxLength = 16
        Me.txtInteriorPE.Name = "txtInteriorPE"
        Me.txtInteriorPE.Size = New System.Drawing.Size(121, 23)
        Me.txtInteriorPE.TabIndex = 13
        '
        'txtNumeroPE
        '
        Me.txtNumeroPE.Location = New System.Drawing.Point(95, 26)
        Me.txtNumeroPE.MaxLength = 16
        Me.txtNumeroPE.Name = "txtNumeroPE"
        Me.txtNumeroPE.Size = New System.Drawing.Size(121, 23)
        Me.txtNumeroPE.TabIndex = 12
        '
        'txtCallePE
        '
        Me.txtCallePE.Location = New System.Drawing.Point(95, 6)
        Me.txtCallePE.MaxLength = 64
        Me.txtCallePE.Name = "txtCallePE"
        Me.txtCallePE.Size = New System.Drawing.Size(121, 23)
        Me.txtCallePE.TabIndex = 11
        '
        'lbPais
        '
        Me.lbPais.Location = New System.Drawing.Point(3, 173)
        Me.lbPais.Name = "lbPais"
        Me.lbPais.Size = New System.Drawing.Size(100, 20)
        Me.lbPais.Text = "lbPais"
        '
        'lbEntidad
        '
        Me.lbEntidad.Location = New System.Drawing.Point(3, 153)
        Me.lbEntidad.Name = "lbEntidad"
        Me.lbEntidad.Size = New System.Drawing.Size(100, 20)
        Me.lbEntidad.Text = "lbEntidad"
        '
        'lbReferencia
        '
        Me.lbReferencia.Location = New System.Drawing.Point(3, 109)
        Me.lbReferencia.Name = "lbReferencia"
        Me.lbReferencia.Size = New System.Drawing.Size(100, 20)
        Me.lbReferencia.Text = "lbReferencia"
        '
        'lbPoblacion
        '
        Me.lbPoblacion.Location = New System.Drawing.Point(3, 131)
        Me.lbPoblacion.Name = "lbPoblacion"
        Me.lbPoblacion.Size = New System.Drawing.Size(100, 20)
        Me.lbPoblacion.Text = "lbPoblacion"
        '
        'lbCodigoPostal
        '
        Me.lbCodigoPostal.Location = New System.Drawing.Point(3, 88)
        Me.lbCodigoPostal.Name = "lbCodigoPostal"
        Me.lbCodigoPostal.Size = New System.Drawing.Size(100, 20)
        Me.lbCodigoPostal.Text = "lbCodigoPostal"
        '
        'lbColonia
        '
        Me.lbColonia.Location = New System.Drawing.Point(3, 67)
        Me.lbColonia.Name = "lbColonia"
        Me.lbColonia.Size = New System.Drawing.Size(100, 20)
        Me.lbColonia.Text = "lbColonia"
        '
        'lbInterior
        '
        Me.lbInterior.Location = New System.Drawing.Point(3, 45)
        Me.lbInterior.Name = "lbInterior"
        Me.lbInterior.Size = New System.Drawing.Size(100, 20)
        Me.lbInterior.Text = "lbInterior"
        '
        'lbNumero
        '
        Me.lbNumero.Location = New System.Drawing.Point(3, 26)
        Me.lbNumero.Name = "lbNumero"
        Me.lbNumero.Size = New System.Drawing.Size(100, 20)
        Me.lbNumero.Text = "lbNumero"
        '
        'lbCalle
        '
        Me.lbCalle.Location = New System.Drawing.Point(3, 6)
        Me.lbCalle.Name = "lbCalle"
        Me.lbCalle.Size = New System.Drawing.Size(100, 20)
        Me.lbCalle.Text = "lbCalle"
        '
        'TabPageFiscal
        '
        Me.TabPageFiscal.Controls.Add(Me.PanelDomFiscal)
        Me.TabPageFiscal.Controls.Add(Me.DetailViewDomFiscal)
        Me.TabPageFiscal.Location = New System.Drawing.Point(4, 25)
        Me.TabPageFiscal.Name = "TabPageFiscal"
        Me.TabPageFiscal.Size = New System.Drawing.Size(224, 198)
        Me.TabPageFiscal.Text = "TabPageFiscal"
        '
        'PanelDomFiscal
        '
        Me.PanelDomFiscal.AutoScroll = True
        Me.PanelDomFiscal.Controls.Add(Me.txtPaisFiscal)
        Me.PanelDomFiscal.Controls.Add(Me.txtEntidadFiscal)
        Me.PanelDomFiscal.Controls.Add(Me.txtPoblacionFiscal)
        Me.PanelDomFiscal.Controls.Add(Me.txtReferenciaFiscal)
        Me.PanelDomFiscal.Controls.Add(Me.txtCodigoPostalFiscal)
        Me.PanelDomFiscal.Controls.Add(Me.txtColoniaFiscal)
        Me.PanelDomFiscal.Controls.Add(Me.txtInteriorFiscal)
        Me.PanelDomFiscal.Controls.Add(Me.txtNumeroFiscal)
        Me.PanelDomFiscal.Controls.Add(Me.txtCalleFiscal)
        Me.PanelDomFiscal.Controls.Add(Me.lbPais2)
        Me.PanelDomFiscal.Controls.Add(Me.lbEntidad2)
        Me.PanelDomFiscal.Controls.Add(Me.lbReferencia2)
        Me.PanelDomFiscal.Controls.Add(Me.lbPoblacion2)
        Me.PanelDomFiscal.Controls.Add(Me.lbCodigoPostal2)
        Me.PanelDomFiscal.Controls.Add(Me.lbColonia2)
        Me.PanelDomFiscal.Controls.Add(Me.lbInterior2)
        Me.PanelDomFiscal.Controls.Add(Me.lbNumero2)
        Me.PanelDomFiscal.Controls.Add(Me.LbCalle2)
        Me.PanelDomFiscal.Location = New System.Drawing.Point(0, 0)
        Me.PanelDomFiscal.Name = "PanelDomFiscal"
        Me.PanelDomFiscal.Size = New System.Drawing.Size(225, 202)
        '
        'txtPaisFiscal
        '
        Me.txtPaisFiscal.Location = New System.Drawing.Point(95, 175)
        Me.txtPaisFiscal.MaxLength = 32
        Me.txtPaisFiscal.Name = "txtPaisFiscal"
        Me.txtPaisFiscal.Size = New System.Drawing.Size(121, 23)
        Me.txtPaisFiscal.TabIndex = 28
        '
        'txtEntidadFiscal
        '
        Me.txtEntidadFiscal.Location = New System.Drawing.Point(95, 153)
        Me.txtEntidadFiscal.MaxLength = 32
        Me.txtEntidadFiscal.Name = "txtEntidadFiscal"
        Me.txtEntidadFiscal.Size = New System.Drawing.Size(121, 23)
        Me.txtEntidadFiscal.TabIndex = 27
        '
        'txtPoblacionFiscal
        '
        Me.txtPoblacionFiscal.Location = New System.Drawing.Point(95, 131)
        Me.txtPoblacionFiscal.MaxLength = 64
        Me.txtPoblacionFiscal.Name = "txtPoblacionFiscal"
        Me.txtPoblacionFiscal.Size = New System.Drawing.Size(121, 23)
        Me.txtPoblacionFiscal.TabIndex = 26
        '
        'txtReferenciaFiscal
        '
        Me.txtReferenciaFiscal.Location = New System.Drawing.Point(95, 109)
        Me.txtReferenciaFiscal.MaxLength = 64
        Me.txtReferenciaFiscal.Name = "txtReferenciaFiscal"
        Me.txtReferenciaFiscal.Size = New System.Drawing.Size(121, 23)
        Me.txtReferenciaFiscal.TabIndex = 25
        '
        'txtCodigoPostalFiscal
        '
        Me.txtCodigoPostalFiscal.Location = New System.Drawing.Point(95, 88)
        Me.txtCodigoPostalFiscal.MaxLength = 64
        Me.txtCodigoPostalFiscal.Name = "txtCodigoPostalFiscal"
        Me.txtCodigoPostalFiscal.Size = New System.Drawing.Size(121, 23)
        Me.txtCodigoPostalFiscal.TabIndex = 24
        '
        'txtColoniaFiscal
        '
        Me.txtColoniaFiscal.Location = New System.Drawing.Point(95, 67)
        Me.txtColoniaFiscal.MaxLength = 16
        Me.txtColoniaFiscal.Name = "txtColoniaFiscal"
        Me.txtColoniaFiscal.Size = New System.Drawing.Size(121, 23)
        Me.txtColoniaFiscal.TabIndex = 23
        '
        'txtInteriorFiscal
        '
        Me.txtInteriorFiscal.Location = New System.Drawing.Point(95, 45)
        Me.txtInteriorFiscal.MaxLength = 16
        Me.txtInteriorFiscal.Name = "txtInteriorFiscal"
        Me.txtInteriorFiscal.Size = New System.Drawing.Size(121, 23)
        Me.txtInteriorFiscal.TabIndex = 22
        '
        'txtNumeroFiscal
        '
        Me.txtNumeroFiscal.Location = New System.Drawing.Point(95, 26)
        Me.txtNumeroFiscal.MaxLength = 16
        Me.txtNumeroFiscal.Name = "txtNumeroFiscal"
        Me.txtNumeroFiscal.Size = New System.Drawing.Size(121, 23)
        Me.txtNumeroFiscal.TabIndex = 21
        '
        'txtCalleFiscal
        '
        Me.txtCalleFiscal.Location = New System.Drawing.Point(95, 6)
        Me.txtCalleFiscal.MaxLength = 64
        Me.txtCalleFiscal.Name = "txtCalleFiscal"
        Me.txtCalleFiscal.Size = New System.Drawing.Size(121, 23)
        Me.txtCalleFiscal.TabIndex = 20
        '
        'lbPais2
        '
        Me.lbPais2.Location = New System.Drawing.Point(3, 173)
        Me.lbPais2.Name = "lbPais2"
        Me.lbPais2.Size = New System.Drawing.Size(100, 20)
        Me.lbPais2.Text = "lbPais2"
        '
        'lbEntidad2
        '
        Me.lbEntidad2.Location = New System.Drawing.Point(3, 153)
        Me.lbEntidad2.Name = "lbEntidad2"
        Me.lbEntidad2.Size = New System.Drawing.Size(100, 20)
        Me.lbEntidad2.Text = "lbEntidad2"
        '
        'lbReferencia2
        '
        Me.lbReferencia2.Location = New System.Drawing.Point(3, 109)
        Me.lbReferencia2.Name = "lbReferencia2"
        Me.lbReferencia2.Size = New System.Drawing.Size(100, 20)
        Me.lbReferencia2.Text = "lbReferencia2"
        '
        'lbPoblacion2
        '
        Me.lbPoblacion2.Location = New System.Drawing.Point(3, 131)
        Me.lbPoblacion2.Name = "lbPoblacion2"
        Me.lbPoblacion2.Size = New System.Drawing.Size(100, 20)
        Me.lbPoblacion2.Text = "lbPoblacion2"
        '
        'lbCodigoPostal2
        '
        Me.lbCodigoPostal2.Location = New System.Drawing.Point(3, 88)
        Me.lbCodigoPostal2.Name = "lbCodigoPostal2"
        Me.lbCodigoPostal2.Size = New System.Drawing.Size(100, 20)
        Me.lbCodigoPostal2.Text = "lbCodigoPostal2"
        '
        'lbColonia2
        '
        Me.lbColonia2.Location = New System.Drawing.Point(3, 67)
        Me.lbColonia2.Name = "lbColonia2"
        Me.lbColonia2.Size = New System.Drawing.Size(100, 20)
        Me.lbColonia2.Text = "lbColonia2"
        '
        'lbInterior2
        '
        Me.lbInterior2.Location = New System.Drawing.Point(3, 45)
        Me.lbInterior2.Name = "lbInterior2"
        Me.lbInterior2.Size = New System.Drawing.Size(100, 20)
        Me.lbInterior2.Text = "lbInterior2"
        '
        'lbNumero2
        '
        Me.lbNumero2.Location = New System.Drawing.Point(3, 26)
        Me.lbNumero2.Name = "lbNumero2"
        Me.lbNumero2.Size = New System.Drawing.Size(100, 20)
        Me.lbNumero2.Text = "lbNumero2"
        '
        'LbCalle2
        '
        Me.LbCalle2.Location = New System.Drawing.Point(3, 6)
        Me.LbCalle2.Name = "LbCalle2"
        Me.LbCalle2.Size = New System.Drawing.Size(100, 20)
        Me.LbCalle2.Text = "LbCalle2"
        '
        'DetailViewDomFiscal
        '
        Me.DetailViewDomFiscal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DetailViewDomFiscal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetailViewDomFiscal.LabelWidth = 110
        Me.DetailViewDomFiscal.Location = New System.Drawing.Point(0, 0)
        Me.DetailViewDomFiscal.Name = "DetailViewDomicilios"
        Me.DetailViewDomFiscal.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.TabStrip
        Me.DetailViewDomFiscal.SeparatorWidth = 4
        Me.DetailViewDomFiscal.Size = New System.Drawing.Size(228, 186)
        Me.DetailViewDomFiscal.TabIndex = 14
        Me.DetailViewDomFiscal.Visible = False
        '
        'TabPageConfiguracion
        '
        Me.TabPageConfiguracion.Controls.Add(Me.CheckBoxPrestamoEnvases)
        Me.TabPageConfiguracion.Controls.Add(Me.dtVig)
        Me.TabPageConfiguracion.Controls.Add(Me.CheckBoxExclusividad)
        Me.TabPageConfiguracion.Controls.Add(Me.LabelVigExclusividad)
        Me.TabPageConfiguracion.Controls.Add(Me.btEsquemas)
        Me.TabPageConfiguracion.Controls.Add(Me.btCompra)
        Me.TabPageConfiguracion.Controls.Add(Me.btEnvase)
        Me.TabPageConfiguracion.Controls.Add(Me.btActivos)
        Me.TabPageConfiguracion.Controls.Add(Me.lbEsquemas)
        Me.TabPageConfiguracion.Controls.Add(Me.lbCompra)
        Me.TabPageConfiguracion.Controls.Add(Me.lbEnvase)
        Me.TabPageConfiguracion.Controls.Add(Me.lbActivos)
        Me.TabPageConfiguracion.Location = New System.Drawing.Point(4, 25)
        Me.TabPageConfiguracion.Name = "TabPageConfiguracion"
        Me.TabPageConfiguracion.Size = New System.Drawing.Size(232, 227)
        Me.TabPageConfiguracion.Text = "TabPageConfiguracion"
        '
        'CheckBoxPrestamoEnvases
        '
        Me.CheckBoxPrestamoEnvases.Enabled = False
        Me.CheckBoxPrestamoEnvases.Location = New System.Drawing.Point(8, 6)
        Me.CheckBoxPrestamoEnvases.Name = "CheckBoxPrestamoEnvases"
        Me.CheckBoxPrestamoEnvases.Size = New System.Drawing.Size(169, 20)
        Me.CheckBoxPrestamoEnvases.TabIndex = 29
        Me.CheckBoxPrestamoEnvases.Text = "CheckBoxPrestamoEnvases"
        '
        'dtVig
        '
        Me.dtVig.CustomFormat = "dd/MM/yyyy"
        Me.dtVig.Enabled = False
        Me.dtVig.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtVig.Location = New System.Drawing.Point(136, 53)
        Me.dtVig.Name = "dtVig"
        Me.dtVig.Size = New System.Drawing.Size(93, 24)
        Me.dtVig.TabIndex = 23
        '
        'CheckBoxExclusividad
        '
        Me.CheckBoxExclusividad.Location = New System.Drawing.Point(8, 28)
        Me.CheckBoxExclusividad.Name = "CheckBoxExclusividad"
        Me.CheckBoxExclusividad.Size = New System.Drawing.Size(120, 20)
        Me.CheckBoxExclusividad.TabIndex = 20
        Me.CheckBoxExclusividad.Text = "CheckBoxExclusividad"
        '
        'LabelVigExclusividad
        '
        Me.LabelVigExclusividad.Location = New System.Drawing.Point(10, 54)
        Me.LabelVigExclusividad.Name = "LabelVigExclusividad"
        Me.LabelVigExclusividad.Size = New System.Drawing.Size(120, 21)
        Me.LabelVigExclusividad.Text = "LabelVigExclusividad"
        '
        'btEsquemas
        '
        Me.btEsquemas.Location = New System.Drawing.Point(156, 177)
        Me.btEsquemas.Name = "btEsquemas"
        Me.btEsquemas.Size = New System.Drawing.Size(72, 24)
        Me.btEsquemas.TabIndex = 10
        Me.btEsquemas.Text = "btEsquemas"
        '
        'btCompra
        '
        Me.btCompra.Location = New System.Drawing.Point(156, 146)
        Me.btCompra.Name = "btCompra"
        Me.btCompra.Size = New System.Drawing.Size(72, 24)
        Me.btCompra.TabIndex = 9
        Me.btCompra.Text = "btCompra"
        '
        'btEnvase
        '
        Me.btEnvase.Location = New System.Drawing.Point(156, 115)
        Me.btEnvase.Name = "btEnvase"
        Me.btEnvase.Size = New System.Drawing.Size(72, 24)
        Me.btEnvase.TabIndex = 8
        Me.btEnvase.Text = "btEnvase"
        '
        'btActivos
        '
        Me.btActivos.Location = New System.Drawing.Point(156, 84)
        Me.btActivos.Name = "btActivos"
        Me.btActivos.Size = New System.Drawing.Size(72, 24)
        Me.btActivos.TabIndex = 7
        Me.btActivos.Text = "btActivos"
        '
        'lbEsquemas
        '
        Me.lbEsquemas.Location = New System.Drawing.Point(10, 178)
        Me.lbEsquemas.Name = "lbEsquemas"
        Me.lbEsquemas.Size = New System.Drawing.Size(149, 20)
        Me.lbEsquemas.Text = "lbEsquemas"
        '
        'lbCompra
        '
        Me.lbCompra.Location = New System.Drawing.Point(10, 147)
        Me.lbCompra.Name = "lbCompra"
        Me.lbCompra.Size = New System.Drawing.Size(149, 20)
        Me.lbCompra.Text = "lbCompra"
        '
        'lbEnvase
        '
        Me.lbEnvase.Location = New System.Drawing.Point(10, 115)
        Me.lbEnvase.Name = "lbEnvase"
        Me.lbEnvase.Size = New System.Drawing.Size(149, 20)
        Me.lbEnvase.Text = "lbEnvase"
        '
        'lbActivos
        '
        Me.lbActivos.Location = New System.Drawing.Point(10, 84)
        Me.lbActivos.Name = "lbActivos"
        Me.lbActivos.Size = New System.Drawing.Size(149, 20)
        Me.lbActivos.Text = "lbActivos"
        '
        'TabPageCredito
        '
        Me.TabPageCredito.Controls.Add(Me.txtFechaFactura)
        Me.TabPageCredito.Controls.Add(Me.txtSaldoCliente)
        Me.TabPageCredito.Controls.Add(Me.txtImporte)
        Me.TabPageCredito.Controls.Add(Me.txtCantidad)
        Me.TabPageCredito.Controls.Add(Me.lbFechaFactura)
        Me.TabPageCredito.Controls.Add(Me.lbSaldoCliente)
        Me.TabPageCredito.Controls.Add(Me.lbCreditosPendientes)
        Me.TabPageCredito.Location = New System.Drawing.Point(4, 25)
        Me.TabPageCredito.Name = "TabPageCredito"
        Me.TabPageCredito.Size = New System.Drawing.Size(232, 227)
        Me.TabPageCredito.Text = "TabPageCredito"
        '
        'txtFechaFactura
        '
        Me.txtFechaFactura.Enabled = False
        Me.txtFechaFactura.Location = New System.Drawing.Point(123, 76)
        Me.txtFechaFactura.Name = "txtFechaFactura"
        Me.txtFechaFactura.Size = New System.Drawing.Size(106, 23)
        Me.txtFechaFactura.TabIndex = 9
        '
        'txtSaldoCliente
        '
        Me.txtSaldoCliente.Enabled = False
        Me.txtSaldoCliente.Location = New System.Drawing.Point(123, 45)
        Me.txtSaldoCliente.Name = "txtSaldoCliente"
        Me.txtSaldoCliente.Size = New System.Drawing.Size(106, 23)
        Me.txtSaldoCliente.TabIndex = 9
        '
        'txtImporte
        '
        Me.txtImporte.Enabled = False
        Me.txtImporte.Location = New System.Drawing.Point(157, 15)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(72, 23)
        Me.txtImporte.TabIndex = 9
        '
        'txtCantidad
        '
        Me.txtCantidad.Enabled = False
        Me.txtCantidad.Location = New System.Drawing.Point(123, 15)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(25, 23)
        Me.txtCantidad.TabIndex = 8
        '
        'lbFechaFactura
        '
        Me.lbFechaFactura.Location = New System.Drawing.Point(3, 76)
        Me.lbFechaFactura.Name = "lbFechaFactura"
        Me.lbFechaFactura.Size = New System.Drawing.Size(120, 13)
        Me.lbFechaFactura.Text = "lbFechaFactura"
        '
        'lbSaldoCliente
        '
        Me.lbSaldoCliente.Location = New System.Drawing.Point(3, 45)
        Me.lbSaldoCliente.Name = "lbSaldoCliente"
        Me.lbSaldoCliente.Size = New System.Drawing.Size(120, 13)
        Me.lbSaldoCliente.Text = "lbSaldoCliente"
        '
        'lbCreditosPendientes
        '
        Me.lbCreditosPendientes.Location = New System.Drawing.Point(3, 17)
        Me.lbCreditosPendientes.Name = "lbCreditosPendientes"
        Me.lbCreditosPendientes.Size = New System.Drawing.Size(120, 13)
        Me.lbCreditosPendientes.Text = "lbCreditosPendientes"
        '
        'ButtonClienteContinuar
        '
        Me.ButtonClienteContinuar.Location = New System.Drawing.Point(2, 262)
        Me.ButtonClienteContinuar.Name = "ButtonClienteContinuar"
        Me.ButtonClienteContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonClienteContinuar.TabIndex = 6
        Me.ButtonClienteContinuar.Text = "ButtonClienteContinuar"
        '
        'ButtonClienteRegresar
        '
        Me.ButtonClienteRegresar.Location = New System.Drawing.Point(80, 262)
        Me.ButtonClienteRegresar.Name = "ButtonClienteRegresar"
        Me.ButtonClienteRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonClienteRegresar.TabIndex = 7
        Me.ButtonClienteRegresar.Text = "ButtonClienteRegresar"
        '
        'ButtonClienteEditar
        '
        Me.ButtonClienteEditar.Location = New System.Drawing.Point(80, 262)
        Me.ButtonClienteEditar.Name = "ButtonClienteEditar"
        Me.ButtonClienteEditar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonClienteEditar.TabIndex = 5
        Me.ButtonClienteEditar.Text = "ButtonClienteEditar"
        '
        'FormClienteDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(240, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuAgenda
        Me.MinimizeBox = False
        Me.Name = "FormClienteDetalle"
        Me.Panel1.ResumeLayout(False)
        Me.TabControlDetalles.ResumeLayout(False)
        Me.TabPageGeneral.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TabPageDomicilios.ResumeLayout(False)
        Me.TabControlDomicilios.ResumeLayout(False)
        Me.TabPagePuntoE.ResumeLayout(False)
        Me.PanelDomPuntoE.ResumeLayout(False)
        Me.TabPageFiscal.ResumeLayout(False)
        Me.PanelDomFiscal.ResumeLayout(False)
        Me.TabPageConfiguracion.ResumeLayout(False)
        Me.TabPageCredito.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControlDetalles As System.Windows.Forms.TabControl
    Friend WithEvents TabPageGeneral As System.Windows.Forms.TabPage
    Friend WithEvents LabelCliente As System.Windows.Forms.Label
    Friend WithEvents TabPageDomicilios As System.Windows.Forms.TabPage
    Friend WithEvents TabPageConfiguracion As System.Windows.Forms.TabPage
    Friend WithEvents dtVig As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBoxExclusividad As System.Windows.Forms.CheckBox
    Friend WithEvents LabelVigExclusividad As System.Windows.Forms.Label
    Friend WithEvents btEsquemas As System.Windows.Forms.Button
    Friend WithEvents btCompra As System.Windows.Forms.Button
    Friend WithEvents btEnvase As System.Windows.Forms.Button
    Friend WithEvents btActivos As System.Windows.Forms.Button
    Friend WithEvents lbEsquemas As System.Windows.Forms.Label
    Friend WithEvents lbCompra As System.Windows.Forms.Label
    Friend WithEvents lbEnvase As System.Windows.Forms.Label
    Friend WithEvents lbActivos As System.Windows.Forms.Label
    Friend WithEvents ButtonClienteEditar As System.Windows.Forms.Button
    Friend WithEvents ButtonClienteContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonClienteRegresar As System.Windows.Forms.Button
    Friend WithEvents TabPageCredito As System.Windows.Forms.TabPage
    Private WithEvents DetailViewCliente As Resco.Controls.DetailView.DetailView
    Private WithEvents DetailViewDomPuntoE As Resco.Controls.DetailView.DetailView
    Friend WithEvents txtFechaFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldoCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtImporte As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents lbFechaFactura As System.Windows.Forms.Label
    Friend WithEvents lbSaldoCliente As System.Windows.Forms.Label
    Friend WithEvents lbCreditosPendientes As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CheckBoxDesglose As System.Windows.Forms.CheckBox
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents txtContacto As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaNac As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaRegistro As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRFC As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoBarras As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreCorto As System.Windows.Forms.TextBox
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents lbTelefono As System.Windows.Forms.Label
    Friend WithEvents lbContacto As System.Windows.Forms.Label
    Friend WithEvents lbFechaNac As System.Windows.Forms.Label
    Friend WithEvents lbFechaRegistro As System.Windows.Forms.Label
    Friend WithEvents lbRFC As System.Windows.Forms.Label
    Friend WithEvents lbCodigoBarras As System.Windows.Forms.Label
    Friend WithEvents lbNombreCorto As System.Windows.Forms.Label
    Friend WithEvents lbRazonSocial As System.Windows.Forms.Label
    Friend WithEvents lbClave As System.Windows.Forms.Label
    Friend WithEvents PanelDomPuntoE As System.Windows.Forms.Panel
    Friend WithEvents txtPaisPE As System.Windows.Forms.TextBox
    Friend WithEvents txtEntidadPE As System.Windows.Forms.TextBox
    Friend WithEvents txtPoblacionPE As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoPostalPE As System.Windows.Forms.TextBox
    Friend WithEvents txtColoniaPE As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroPE As System.Windows.Forms.TextBox
    Friend WithEvents txtCallePE As System.Windows.Forms.TextBox
    Friend WithEvents lbPais As System.Windows.Forms.Label
    Friend WithEvents lbEntidad As System.Windows.Forms.Label
    Friend WithEvents lbPoblacion As System.Windows.Forms.Label
    Friend WithEvents lbCodigoPostal As System.Windows.Forms.Label
    Friend WithEvents lbColonia As System.Windows.Forms.Label
    Friend WithEvents lbNumero As System.Windows.Forms.Label
    Friend WithEvents lbCalle As System.Windows.Forms.Label
    Friend WithEvents txtInteriorPE As System.Windows.Forms.TextBox
    Friend WithEvents lbInterior As System.Windows.Forms.Label
    Friend WithEvents txtReferenciaPE As System.Windows.Forms.TextBox
    Friend WithEvents lbReferencia As System.Windows.Forms.Label
    Friend WithEvents CheckBoxPrestamoEnvases As System.Windows.Forms.CheckBox
    Friend WithEvents TabControlDomicilios As System.Windows.Forms.TabControl
    Friend WithEvents TabPagePuntoE As System.Windows.Forms.TabPage
    Friend WithEvents TabPageFiscal As System.Windows.Forms.TabPage
    Private WithEvents DetailViewDomFiscal As Resco.Controls.DetailView.DetailView
    Friend WithEvents PanelDomFiscal As System.Windows.Forms.Panel
    Friend WithEvents txtPaisFiscal As System.Windows.Forms.TextBox
    Friend WithEvents txtEntidadFiscal As System.Windows.Forms.TextBox
    Friend WithEvents txtPoblacionFiscal As System.Windows.Forms.TextBox
    Friend WithEvents txtReferenciaFiscal As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoPostalFiscal As System.Windows.Forms.TextBox
    Friend WithEvents txtColoniaFiscal As System.Windows.Forms.TextBox
    Friend WithEvents txtInteriorFiscal As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroFiscal As System.Windows.Forms.TextBox
    Friend WithEvents txtCalleFiscal As System.Windows.Forms.TextBox
    Friend WithEvents lbPais2 As System.Windows.Forms.Label
    Friend WithEvents lbEntidad2 As System.Windows.Forms.Label
    Friend WithEvents lbReferencia2 As System.Windows.Forms.Label
    Friend WithEvents lbPoblacion2 As System.Windows.Forms.Label
    Friend WithEvents lbCodigoPostal2 As System.Windows.Forms.Label
    Friend WithEvents lbColonia2 As System.Windows.Forms.Label
    Friend WithEvents lbInterior2 As System.Windows.Forms.Label
    Friend WithEvents lbNumero2 As System.Windows.Forms.Label
    Friend WithEvents LbCalle2 As System.Windows.Forms.Label
End Class
