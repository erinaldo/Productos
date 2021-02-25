Imports BASMENLOG
Imports ERMVENLOG
Imports BASUSULOG
Imports ERMMOTLOG
Imports ERMTERLOG
Public Enum eModo
    Crear = 1
    Modificar
    Eliminar
    Leer
End Enum

Public Class MGeneral
    Inherits FormasBase.Mantenimiento01
    Dim Elimina As Boolean = False
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
    Friend WithEvents lbEstado As System.Windows.Forms.Label
    Friend WithEvents cbEstado As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbNombre As System.Windows.Forms.Label
    Friend WithEvents lbModulo As System.Windows.Forms.Label
    Friend WithEvents lbCaptura As System.Windows.Forms.Label
    Friend WithEvents lbNivelExp As System.Windows.Forms.Label
    Friend WithEvents lbLimiteDesc As System.Windows.Forms.Label
    Friend WithEvents lbUsuario As System.Windows.Forms.Label
    Friend WithEvents lbTerminal As System.Windows.Forms.Label
    Friend WithEvents ebNombre As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebUsuario As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebUsuarioDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebTerminal As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebTerminalDesc As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents cbCaptura As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents cbNivelExp As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents chBaja As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents btUsuario As Janus.Windows.EditControls.UIButton
    Friend WithEvents btTerminal As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebLimiteDesc As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents epErrores As System.Windows.Forms.ErrorProvider
    Friend WithEvents grVendedorDescuento As Janus.Windows.GridEX.GridEX
    Friend WithEvents btVEDCrear As Janus.Windows.EditControls.UIButton
    Friend WithEvents btVEDEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebUsuarioId As System.Windows.Forms.TextBox
    Friend WithEvents lbAlmacen As System.Windows.Forms.Label
    Friend WithEvents cbAlmacenId As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents grVendedorEsquema As Janus.Windows.GridEX.GridEX
    Friend WithEvents btVEECrear As Janus.Windows.EditControls.UIButton
    Friend WithEvents btVEEEliminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btVEEBuscar As Janus.Windows.EditControls.UIButton
    Friend WithEvents chCapturar As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chActualizar As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents buscacarpetas As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtruta As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chbMostrarEsquema As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chbJornadaTrabajo As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents grJornadas As Janus.Windows.GridEX.GridEX
    Friend WithEvents chbCapturaFolioFac As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents btHistorico As Janus.Windows.EditControls.UIButton
    Friend WithEvents lbVCHFechaInicial As System.Windows.Forms.Label
    Friend WithEvents lbRuta As System.Windows.Forms.Label
    Friend WithEvents btRuta As Janus.Windows.EditControls.UIButton
    Friend WithEvents gbCentroDist As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents cbVCHFechaInicial As Janus.Windows.CalendarCombo.CalendarCombo
    Friend WithEvents lbVCHALMNombre As System.Windows.Forms.Label
    Friend WithEvents cbVCHAlmacenId As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents chMostrarCuota As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents chMantenerPrm As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents cbTipoModImp As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbTipoModImp As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tabGeneral As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tabDescuentos As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tabEsquemas As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel4 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tabJornadas As DevComponents.DotNetBar.TabItem
    Friend WithEvents btConfiguracion As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebConfiguracion As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents chKilometraje As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents lbTipo As System.Windows.Forms.Label
    Friend WithEvents cbTipo As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents chbDatosFiscales As Janus.Windows.EditControls.UICheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MGeneral))
        Dim grVendedorDescuento_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grVendedorEsquema_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim grJornadas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.lbEstado = New System.Windows.Forms.Label
        Me.cbEstado = New Janus.Windows.EditControls.UIComboBox
        Me.lbNombre = New System.Windows.Forms.Label
        Me.lbModulo = New System.Windows.Forms.Label
        Me.lbCaptura = New System.Windows.Forms.Label
        Me.lbNivelExp = New System.Windows.Forms.Label
        Me.lbLimiteDesc = New System.Windows.Forms.Label
        Me.lbUsuario = New System.Windows.Forms.Label
        Me.lbTerminal = New System.Windows.Forms.Label
        Me.ebNombre = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebUsuario = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebUsuarioDesc = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebTerminal = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebTerminalDesc = New Janus.Windows.GridEX.EditControls.EditBox
        Me.cbCaptura = New Janus.Windows.EditControls.UIComboBox
        Me.cbNivelExp = New Janus.Windows.EditControls.UIComboBox
        Me.chBaja = New Janus.Windows.EditControls.UICheckBox
        Me.btUsuario = New Janus.Windows.EditControls.UIButton
        Me.btTerminal = New Janus.Windows.EditControls.UIButton
        Me.ebLimiteDesc = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.epErrores = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.chbDatosFiscales = New Janus.Windows.EditControls.UICheckBox
        Me.cbTipoModImp = New Janus.Windows.EditControls.UIComboBox
        Me.lbTipoModImp = New System.Windows.Forms.Label
        Me.chMantenerPrm = New Janus.Windows.EditControls.UICheckBox
        Me.gbCentroDist = New Janus.Windows.EditControls.UIGroupBox
        Me.lbVCHALMNombre = New System.Windows.Forms.Label
        Me.cbVCHFechaInicial = New Janus.Windows.CalendarCombo.CalendarCombo
        Me.cbVCHAlmacenId = New Janus.Windows.EditControls.UIComboBox
        Me.btHistorico = New Janus.Windows.EditControls.UIButton
        Me.lbVCHFechaInicial = New System.Windows.Forms.Label
        Me.chbCapturaFolioFac = New Janus.Windows.EditControls.UICheckBox
        Me.chbJornadaTrabajo = New Janus.Windows.EditControls.UICheckBox
        Me.chbMostrarEsquema = New Janus.Windows.EditControls.UICheckBox
        Me.txtruta = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbRuta = New System.Windows.Forms.Label
        Me.chActualizar = New Janus.Windows.EditControls.UICheckBox
        Me.chCapturar = New Janus.Windows.EditControls.UICheckBox
        Me.cbAlmacenId = New Janus.Windows.EditControls.UIComboBox
        Me.lbAlmacen = New System.Windows.Forms.Label
        Me.ebUsuarioId = New System.Windows.Forms.TextBox
        Me.btRuta = New Janus.Windows.EditControls.UIButton
        Me.chMostrarCuota = New Janus.Windows.EditControls.UICheckBox
        Me.btVEDCrear = New Janus.Windows.EditControls.UIButton
        Me.btVEDEliminar = New Janus.Windows.EditControls.UIButton
        Me.grVendedorDescuento = New Janus.Windows.GridEX.GridEX
        Me.grVendedorEsquema = New Janus.Windows.GridEX.GridEX
        Me.btVEECrear = New Janus.Windows.EditControls.UIButton
        Me.btVEEEliminar = New Janus.Windows.EditControls.UIButton
        Me.btVEEBuscar = New Janus.Windows.EditControls.UIButton
        Me.grJornadas = New Janus.Windows.GridEX.GridEX
        Me.buscacarpetas = New System.Windows.Forms.FolderBrowserDialog
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.lbTipo = New System.Windows.Forms.Label
        Me.cbTipo = New Janus.Windows.EditControls.UIComboBox
        Me.chKilometraje = New Janus.Windows.EditControls.UICheckBox
        Me.btConfiguracion = New Janus.Windows.EditControls.UIButton
        Me.ebConfiguracion = New Janus.Windows.GridEX.EditControls.EditBox
        Me.tabGeneral = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel
        Me.tabJornadas = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel
        Me.tabEsquemas = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel
        Me.tabDescuentos = New DevComponents.DotNetBar.TabItem(Me.components)
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbCentroDist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCentroDist.SuspendLayout()
        CType(Me.grVendedorDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grVendedorEsquema, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grJornadas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.TabControlPanel4.SuspendLayout()
        Me.TabControlPanel3.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'EbClave
        '
        Me.EbClave.Enabled = False
        Me.EbClave.Location = New System.Drawing.Point(604, 2)
        Me.EbClave.Size = New System.Drawing.Size(8, 20)
        Me.EbClave.TabIndex = 3
        Me.EbClave.TabStop = False
        Me.EbClave.Visible = False
        '
        'lbClave
        '
        Me.lbClave.Location = New System.Drawing.Point(588, 2)
        Me.lbClave.Size = New System.Drawing.Size(12, 20)
        Me.lbClave.TabIndex = 4
        Me.lbClave.Visible = False
        '
        'BtAceptar
        '
        Me.BtAceptar.Location = New System.Drawing.Point(457, 434)
        Me.BtAceptar.TabIndex = 31
        '
        'BtCancelar
        '
        Me.BtCancelar.Location = New System.Drawing.Point(567, 434)
        Me.BtCancelar.TabIndex = 32
        '
        'lbLinea
        '
        Me.lbLinea.Location = New System.Drawing.Point(8, 304)
        Me.lbLinea.Size = New System.Drawing.Size(12, 3)
        Me.lbLinea.TabIndex = 3
        Me.lbLinea.Visible = False
        '
        'lbEstado
        '
        Me.lbEstado.BackColor = System.Drawing.Color.Transparent
        Me.lbEstado.Location = New System.Drawing.Point(338, 4)
        Me.lbEstado.Name = "lbEstado"
        Me.lbEstado.Size = New System.Drawing.Size(132, 20)
        Me.lbEstado.TabIndex = 3
        Me.lbEstado.Text = "Estado"
        Me.lbEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbEstado
        '
        Me.cbEstado.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbEstado.Location = New System.Drawing.Point(474, 4)
        Me.cbEstado.Name = "cbEstado"
        Me.cbEstado.Size = New System.Drawing.Size(172, 20)
        Me.cbEstado.TabIndex = 30
        Me.cbEstado.TabStop = False
        Me.cbEstado.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbNombre
        '
        Me.lbNombre.BackColor = System.Drawing.Color.Transparent
        Me.lbNombre.Location = New System.Drawing.Point(14, 28)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(132, 20)
        Me.lbNombre.TabIndex = 1
        Me.lbNombre.Text = "Nombre"
        Me.lbNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbModulo
        '
        Me.lbModulo.BackColor = System.Drawing.Color.Transparent
        Me.lbModulo.Location = New System.Drawing.Point(338, 56)
        Me.lbModulo.Name = "lbModulo"
        Me.lbModulo.Size = New System.Drawing.Size(132, 20)
        Me.lbModulo.TabIndex = 5
        Me.lbModulo.Text = "Configuracion Módulo"
        Me.lbModulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbCaptura
        '
        Me.lbCaptura.BackColor = System.Drawing.Color.Transparent
        Me.lbCaptura.Location = New System.Drawing.Point(66, 184)
        Me.lbCaptura.Name = "lbCaptura"
        Me.lbCaptura.Size = New System.Drawing.Size(8, 20)
        Me.lbCaptura.TabIndex = 7
        Me.lbCaptura.Text = "Captura de productos"
        Me.lbCaptura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbCaptura.Visible = False
        '
        'lbNivelExp
        '
        Me.lbNivelExp.BackColor = System.Drawing.Color.Transparent
        Me.lbNivelExp.Location = New System.Drawing.Point(14, 80)
        Me.lbNivelExp.Name = "lbNivelExp"
        Me.lbNivelExp.Size = New System.Drawing.Size(132, 20)
        Me.lbNivelExp.TabIndex = 7
        Me.lbNivelExp.Text = "Nivel de experiencia"
        Me.lbNivelExp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLimiteDesc
        '
        Me.lbLimiteDesc.BackColor = System.Drawing.Color.Transparent
        Me.lbLimiteDesc.Location = New System.Drawing.Point(338, 80)
        Me.lbLimiteDesc.Name = "lbLimiteDesc"
        Me.lbLimiteDesc.Size = New System.Drawing.Size(132, 20)
        Me.lbLimiteDesc.TabIndex = 9
        Me.lbLimiteDesc.Text = "Límite de descuentos"
        Me.lbLimiteDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbUsuario
        '
        Me.lbUsuario.BackColor = System.Drawing.Color.Transparent
        Me.lbUsuario.Location = New System.Drawing.Point(14, 106)
        Me.lbUsuario.Name = "lbUsuario"
        Me.lbUsuario.Size = New System.Drawing.Size(132, 20)
        Me.lbUsuario.TabIndex = 14
        Me.lbUsuario.Text = "Usuario"
        Me.lbUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbTerminal
        '
        Me.lbTerminal.BackColor = System.Drawing.Color.Transparent
        Me.lbTerminal.Location = New System.Drawing.Point(14, 132)
        Me.lbTerminal.Name = "lbTerminal"
        Me.lbTerminal.Size = New System.Drawing.Size(132, 20)
        Me.lbTerminal.TabIndex = 15
        Me.lbTerminal.Text = "Terminal"
        Me.lbTerminal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebNombre
        '
        Me.ebNombre.Location = New System.Drawing.Point(150, 28)
        Me.ebNombre.MaxLength = 64
        Me.ebNombre.Name = "ebNombre"
        Me.ebNombre.Size = New System.Drawing.Size(496, 20)
        Me.ebNombre.TabIndex = 1
        Me.ebNombre.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebNombre.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebUsuario
        '
        Me.ebUsuario.Location = New System.Drawing.Point(150, 106)
        Me.ebUsuario.Name = "ebUsuario"
        Me.ebUsuario.Size = New System.Drawing.Size(148, 20)
        Me.ebUsuario.TabIndex = 7
        Me.ebUsuario.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUsuario.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebUsuarioDesc
        '
        Me.ebUsuarioDesc.Enabled = False
        Me.ebUsuarioDesc.Location = New System.Drawing.Point(322, 106)
        Me.ebUsuarioDesc.Name = "ebUsuarioDesc"
        Me.ebUsuarioDesc.Size = New System.Drawing.Size(324, 20)
        Me.ebUsuarioDesc.TabIndex = 9
        Me.ebUsuarioDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUsuarioDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebTerminal
        '
        Me.ebTerminal.Location = New System.Drawing.Point(150, 132)
        Me.ebTerminal.Name = "ebTerminal"
        Me.ebTerminal.Size = New System.Drawing.Size(148, 20)
        Me.ebTerminal.TabIndex = 10
        Me.ebTerminal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTerminal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebTerminalDesc
        '
        Me.ebTerminalDesc.Enabled = False
        Me.ebTerminalDesc.Location = New System.Drawing.Point(322, 132)
        Me.ebTerminalDesc.Name = "ebTerminalDesc"
        Me.ebTerminalDesc.Size = New System.Drawing.Size(324, 20)
        Me.ebTerminalDesc.TabIndex = 12
        Me.ebTerminalDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebTerminalDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbCaptura
        '
        Me.cbCaptura.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbCaptura.Location = New System.Drawing.Point(78, 184)
        Me.cbCaptura.Name = "cbCaptura"
        Me.cbCaptura.Size = New System.Drawing.Size(4, 20)
        Me.cbCaptura.TabIndex = 8
        Me.cbCaptura.Visible = False
        Me.cbCaptura.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cbNivelExp
        '
        Me.cbNivelExp.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbNivelExp.Location = New System.Drawing.Point(150, 80)
        Me.cbNivelExp.Name = "cbNivelExp"
        Me.cbNivelExp.Size = New System.Drawing.Size(172, 20)
        Me.cbNivelExp.TabIndex = 5
        Me.cbNivelExp.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chBaja
        '
        Me.chBaja.BackColor = System.Drawing.Color.Transparent
        Me.chBaja.Enabled = False
        Me.chBaja.Location = New System.Drawing.Point(514, 228)
        Me.chBaja.Name = "chBaja"
        Me.chBaja.Size = New System.Drawing.Size(132, 16)
        Me.chBaja.TabIndex = 20
        Me.chBaja.Text = "Baja"
        Me.chBaja.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btUsuario
        '
        Me.btUsuario.Location = New System.Drawing.Point(298, 106)
        Me.btUsuario.Name = "btUsuario"
        Me.btUsuario.Size = New System.Drawing.Size(24, 20)
        Me.btUsuario.TabIndex = 8
        Me.btUsuario.Text = "..."
        Me.btUsuario.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btTerminal
        '
        Me.btTerminal.Location = New System.Drawing.Point(298, 132)
        Me.btTerminal.Name = "btTerminal"
        Me.btTerminal.Size = New System.Drawing.Size(24, 20)
        Me.btTerminal.TabIndex = 11
        Me.btTerminal.Text = "..."
        Me.btTerminal.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'ebLimiteDesc
        '
        Me.ebLimiteDesc.Location = New System.Drawing.Point(474, 80)
        Me.ebLimiteDesc.Name = "ebLimiteDesc"
        Me.ebLimiteDesc.Size = New System.Drawing.Size(172, 20)
        Me.ebLimiteDesc.TabIndex = 6
        Me.ebLimiteDesc.Text = "0.00"
        Me.ebLimiteDesc.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.ebLimiteDesc.Value = 0
        Me.ebLimiteDesc.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        Me.ebLimiteDesc.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'epErrores
        '
        Me.epErrores.ContainerControl = Me
        '
        'chbDatosFiscales
        '
        Me.chbDatosFiscales.BackColor = System.Drawing.Color.Transparent
        Me.chbDatosFiscales.Location = New System.Drawing.Point(14, 276)
        Me.chbDatosFiscales.Name = "chbDatosFiscales"
        Me.chbDatosFiscales.Size = New System.Drawing.Size(132, 16)
        Me.chbDatosFiscales.TabIndex = 25
        Me.chbDatosFiscales.Text = "Editar datos fiscales"
        Me.chbDatosFiscales.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cbTipoModImp
        '
        Me.cbTipoModImp.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipoModImp.Location = New System.Drawing.Point(474, 158)
        Me.cbTipoModImp.Name = "cbTipoModImp"
        Me.cbTipoModImp.Size = New System.Drawing.Size(172, 20)
        Me.cbTipoModImp.TabIndex = 14
        Me.cbTipoModImp.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbTipoModImp
        '
        Me.lbTipoModImp.BackColor = System.Drawing.Color.Transparent
        Me.lbTipoModImp.Location = New System.Drawing.Point(338, 158)
        Me.lbTipoModImp.Name = "lbTipoModImp"
        Me.lbTipoModImp.Size = New System.Drawing.Size(132, 20)
        Me.lbTipoModImp.TabIndex = 32
        Me.lbTipoModImp.Text = "Impresora"
        Me.lbTipoModImp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chMantenerPrm
        '
        Me.chMantenerPrm.BackColor = System.Drawing.Color.Transparent
        Me.chMantenerPrm.Location = New System.Drawing.Point(514, 252)
        Me.chMantenerPrm.Name = "chMantenerPrm"
        Me.chMantenerPrm.Size = New System.Drawing.Size(132, 16)
        Me.chMantenerPrm.TabIndex = 24
        Me.chMantenerPrm.Text = "chMantenerPrm"
        Me.chMantenerPrm.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'gbCentroDist
        '
        Me.gbCentroDist.BackColor = System.Drawing.Color.Transparent
        Me.gbCentroDist.Controls.Add(Me.lbVCHALMNombre)
        Me.gbCentroDist.Controls.Add(Me.cbVCHFechaInicial)
        Me.gbCentroDist.Controls.Add(Me.cbVCHAlmacenId)
        Me.gbCentroDist.Controls.Add(Me.btHistorico)
        Me.gbCentroDist.Controls.Add(Me.lbVCHFechaInicial)
        Me.gbCentroDist.Location = New System.Drawing.Point(10, 304)
        Me.gbCentroDist.Name = "gbCentroDist"
        Me.gbCentroDist.Size = New System.Drawing.Size(636, 88)
        Me.gbCentroDist.TabIndex = 27
        Me.gbCentroDist.Text = "Centro de Distribución"
        Me.gbCentroDist.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lbVCHALMNombre
        '
        Me.lbVCHALMNombre.BackColor = System.Drawing.Color.Transparent
        Me.lbVCHALMNombre.Location = New System.Drawing.Point(8, 50)
        Me.lbVCHALMNombre.Name = "lbVCHALMNombre"
        Me.lbVCHALMNombre.Size = New System.Drawing.Size(132, 20)
        Me.lbVCHALMNombre.TabIndex = 3
        Me.lbVCHALMNombre.Text = "Nombre"
        Me.lbVCHALMNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbVCHFechaInicial
        '
        '
        '
        '
        Me.cbVCHFechaInicial.DropDownCalendar.FirstMonth = New Date(2007, 7, 1, 0, 0, 0, 0)
        Me.cbVCHFechaInicial.DropDownCalendar.Name = ""
        Me.cbVCHFechaInicial.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        Me.cbVCHFechaInicial.Enabled = False
        Me.cbVCHFechaInicial.Location = New System.Drawing.Point(144, 24)
        Me.cbVCHFechaInicial.Name = "cbVCHFechaInicial"
        Me.cbVCHFechaInicial.ReadOnly = True
        Me.cbVCHFechaInicial.Size = New System.Drawing.Size(132, 20)
        Me.cbVCHFechaInicial.TabIndex = 28
        Me.cbVCHFechaInicial.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        '
        'cbVCHAlmacenId
        '
        Me.cbVCHAlmacenId.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbVCHAlmacenId.Location = New System.Drawing.Point(144, 50)
        Me.cbVCHAlmacenId.Name = "cbVCHAlmacenId"
        Me.cbVCHAlmacenId.Size = New System.Drawing.Size(368, 20)
        Me.cbVCHAlmacenId.TabIndex = 30
        Me.cbVCHAlmacenId.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btHistorico
        '
        Me.btHistorico.CausesValidation = False
        Me.btHistorico.Icon = CType(resources.GetObject("btHistorico.Icon"), System.Drawing.Icon)
        Me.btHistorico.Location = New System.Drawing.Point(536, 24)
        Me.btHistorico.Name = "btHistorico"
        Me.btHistorico.Size = New System.Drawing.Size(80, 24)
        Me.btHistorico.TabIndex = 29
        Me.btHistorico.Text = "Histórico"
        Me.btHistorico.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'lbVCHFechaInicial
        '
        Me.lbVCHFechaInicial.BackColor = System.Drawing.Color.Transparent
        Me.lbVCHFechaInicial.Location = New System.Drawing.Point(8, 24)
        Me.lbVCHFechaInicial.Name = "lbVCHFechaInicial"
        Me.lbVCHFechaInicial.Size = New System.Drawing.Size(132, 20)
        Me.lbVCHFechaInicial.TabIndex = 0
        Me.lbVCHFechaInicial.Text = "Fecha Inicial"
        Me.lbVCHFechaInicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chbCapturaFolioFac
        '
        Me.chbCapturaFolioFac.BackColor = System.Drawing.Color.Transparent
        Me.chbCapturaFolioFac.Location = New System.Drawing.Point(182, 252)
        Me.chbCapturaFolioFac.Name = "chbCapturaFolioFac"
        Me.chbCapturaFolioFac.Size = New System.Drawing.Size(132, 16)
        Me.chbCapturaFolioFac.TabIndex = 22
        Me.chbCapturaFolioFac.Text = "CapturaFolioFac"
        Me.chbCapturaFolioFac.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chbJornadaTrabajo
        '
        Me.chbJornadaTrabajo.BackColor = System.Drawing.Color.Transparent
        Me.chbJornadaTrabajo.Location = New System.Drawing.Point(14, 252)
        Me.chbJornadaTrabajo.Name = "chbJornadaTrabajo"
        Me.chbJornadaTrabajo.Size = New System.Drawing.Size(132, 16)
        Me.chbJornadaTrabajo.TabIndex = 21
        Me.chbJornadaTrabajo.Text = "Jornada de Trabajo"
        Me.chbJornadaTrabajo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chbMostrarEsquema
        '
        Me.chbMostrarEsquema.BackColor = System.Drawing.Color.Transparent
        Me.chbMostrarEsquema.Location = New System.Drawing.Point(346, 228)
        Me.chbMostrarEsquema.Name = "chbMostrarEsquema"
        Me.chbMostrarEsquema.Size = New System.Drawing.Size(132, 16)
        Me.chbMostrarEsquema.TabIndex = 19
        Me.chbMostrarEsquema.Text = "chbMostrarEsquema"
        Me.chbMostrarEsquema.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtruta
        '
        Me.txtruta.Location = New System.Drawing.Point(150, 188)
        Me.txtruta.Name = "txtruta"
        Me.txtruta.Size = New System.Drawing.Size(472, 20)
        Me.txtruta.TabIndex = 15
        Me.txtruta.Text = "c:\"
        Me.txtruta.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.txtruta.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbRuta
        '
        Me.lbRuta.BackColor = System.Drawing.Color.Transparent
        Me.lbRuta.Location = New System.Drawing.Point(14, 184)
        Me.lbRuta.Name = "lbRuta"
        Me.lbRuta.Size = New System.Drawing.Size(132, 28)
        Me.lbRuta.TabIndex = 21
        Me.lbRuta.Text = "Directorio Interfaces de Salida"
        '
        'chActualizar
        '
        Me.chActualizar.BackColor = System.Drawing.Color.Transparent
        Me.chActualizar.Location = New System.Drawing.Point(14, 228)
        Me.chActualizar.Name = "chActualizar"
        Me.chActualizar.Size = New System.Drawing.Size(132, 16)
        Me.chActualizar.TabIndex = 17
        Me.chActualizar.Text = "chActualizar"
        Me.chActualizar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chCapturar
        '
        Me.chCapturar.BackColor = System.Drawing.Color.Transparent
        Me.chCapturar.Location = New System.Drawing.Point(182, 228)
        Me.chCapturar.Name = "chCapturar"
        Me.chCapturar.Size = New System.Drawing.Size(132, 16)
        Me.chCapturar.TabIndex = 18
        Me.chCapturar.Text = "chCapturar"
        Me.chCapturar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cbAlmacenId
        '
        Me.cbAlmacenId.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbAlmacenId.Location = New System.Drawing.Point(150, 158)
        Me.cbAlmacenId.Name = "cbAlmacenId"
        Me.cbAlmacenId.Size = New System.Drawing.Size(172, 20)
        Me.cbAlmacenId.TabIndex = 13
        Me.cbAlmacenId.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbAlmacen
        '
        Me.lbAlmacen.BackColor = System.Drawing.Color.Transparent
        Me.lbAlmacen.Location = New System.Drawing.Point(14, 158)
        Me.lbAlmacen.Name = "lbAlmacen"
        Me.lbAlmacen.Size = New System.Drawing.Size(132, 20)
        Me.lbAlmacen.TabIndex = 19
        Me.lbAlmacen.Text = "Almacen"
        Me.lbAlmacen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebUsuarioId
        '
        Me.ebUsuarioId.Location = New System.Drawing.Point(146, 104)
        Me.ebUsuarioId.Name = "ebUsuarioId"
        Me.ebUsuarioId.Size = New System.Drawing.Size(4, 20)
        Me.ebUsuarioId.TabIndex = 22
        Me.ebUsuarioId.Visible = False
        '
        'btRuta
        '
        Me.btRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btRuta.Location = New System.Drawing.Point(622, 188)
        Me.btRuta.Name = "btRuta"
        Me.btRuta.Size = New System.Drawing.Size(24, 20)
        Me.btRuta.TabIndex = 16
        Me.btRuta.Text = "..."
        Me.btRuta.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'chMostrarCuota
        '
        Me.chMostrarCuota.BackColor = System.Drawing.Color.Transparent
        Me.chMostrarCuota.Location = New System.Drawing.Point(346, 252)
        Me.chMostrarCuota.Name = "chMostrarCuota"
        Me.chMostrarCuota.Size = New System.Drawing.Size(132, 16)
        Me.chMostrarCuota.TabIndex = 23
        Me.chMostrarCuota.Text = "chMostrarCuota"
        Me.chMostrarCuota.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btVEDCrear
        '
        Me.btVEDCrear.Icon = CType(resources.GetObject("btVEDCrear.Icon"), System.Drawing.Icon)
        Me.btVEDCrear.Location = New System.Drawing.Point(570, 8)
        Me.btVEDCrear.Name = "btVEDCrear"
        Me.btVEDCrear.Size = New System.Drawing.Size(80, 24)
        Me.btVEDCrear.TabIndex = 1
        Me.btVEDCrear.Text = "Crear"
        Me.btVEDCrear.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btVEDEliminar
        '
        Me.btVEDEliminar.CausesValidation = False
        Me.btVEDEliminar.Icon = CType(resources.GetObject("btVEDEliminar.Icon"), System.Drawing.Icon)
        Me.btVEDEliminar.Location = New System.Drawing.Point(570, 40)
        Me.btVEDEliminar.Name = "btVEDEliminar"
        Me.btVEDEliminar.Size = New System.Drawing.Size(80, 24)
        Me.btVEDEliminar.TabIndex = 2
        Me.btVEDEliminar.Text = "Eliminar"
        Me.btVEDEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'grVendedorDescuento
        '
        grVendedorDescuento_DesignTimeLayout.LayoutString = resources.GetString("grVendedorDescuento_DesignTimeLayout.LayoutString")
        Me.grVendedorDescuento.DesignTimeLayout = grVendedorDescuento_DesignTimeLayout
        Me.grVendedorDescuento.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grVendedorDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grVendedorDescuento.GroupByBoxVisible = False
        Me.grVendedorDescuento.Location = New System.Drawing.Point(10, 4)
        Me.grVendedorDescuento.Name = "grVendedorDescuento"
        Me.grVendedorDescuento.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grVendedorDescuento.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grVendedorDescuento.Size = New System.Drawing.Size(552, 360)
        Me.grVendedorDescuento.TabIndex = 0
        Me.grVendedorDescuento.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        Me.grVendedorDescuento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'grVendedorEsquema
        '
        grVendedorEsquema_DesignTimeLayout.LayoutString = resources.GetString("grVendedorEsquema_DesignTimeLayout.LayoutString")
        Me.grVendedorEsquema.DesignTimeLayout = grVendedorEsquema_DesignTimeLayout
        Me.grVendedorEsquema.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grVendedorEsquema.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grVendedorEsquema.GroupByBoxVisible = False
        Me.grVendedorEsquema.Location = New System.Drawing.Point(10, 4)
        Me.grVendedorEsquema.Name = "grVendedorEsquema"
        Me.grVendedorEsquema.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grVendedorEsquema.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grVendedorEsquema.Size = New System.Drawing.Size(552, 360)
        Me.grVendedorEsquema.TabIndex = 0
        Me.grVendedorEsquema.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        Me.grVendedorEsquema.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btVEECrear
        '
        Me.btVEECrear.Icon = CType(resources.GetObject("btVEECrear.Icon"), System.Drawing.Icon)
        Me.btVEECrear.Location = New System.Drawing.Point(570, 8)
        Me.btVEECrear.Name = "btVEECrear"
        Me.btVEECrear.Size = New System.Drawing.Size(80, 24)
        Me.btVEECrear.TabIndex = 1
        Me.btVEECrear.Text = "Crear"
        Me.btVEECrear.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btVEEEliminar
        '
        Me.btVEEEliminar.CausesValidation = False
        Me.btVEEEliminar.Icon = CType(resources.GetObject("btVEEEliminar.Icon"), System.Drawing.Icon)
        Me.btVEEEliminar.Location = New System.Drawing.Point(570, 40)
        Me.btVEEEliminar.Name = "btVEEEliminar"
        Me.btVEEEliminar.Size = New System.Drawing.Size(80, 24)
        Me.btVEEEliminar.TabIndex = 2
        Me.btVEEEliminar.Text = "Eliminar"
        Me.btVEEEliminar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btVEEBuscar
        '
        Me.btVEEBuscar.Icon = CType(resources.GetObject("btVEEBuscar.Icon"), System.Drawing.Icon)
        Me.btVEEBuscar.Location = New System.Drawing.Point(570, 72)
        Me.btVEEBuscar.Name = "btVEEBuscar"
        Me.btVEEBuscar.Size = New System.Drawing.Size(80, 24)
        Me.btVEEBuscar.TabIndex = 3
        Me.btVEEBuscar.Text = "Buscar"
        Me.btVEEBuscar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'grJornadas
        '
        Me.grJornadas.AllowColumnDrag = False
        grJornadas_DesignTimeLayout.LayoutString = resources.GetString("grJornadas_DesignTimeLayout.LayoutString")
        Me.grJornadas.DesignTimeLayout = grJornadas_DesignTimeLayout
        Me.grJornadas.DynamicFiltering = True
        Me.grJornadas.GroupByBoxVisible = False
        Me.grJornadas.Location = New System.Drawing.Point(10, 4)
        Me.grJornadas.Name = "grJornadas"
        Me.grJornadas.Size = New System.Drawing.Size(640, 360)
        Me.grJornadas.TabIndex = 0
        Me.grJornadas.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'TabControl1
        '
        Me.TabControl1.CanReorderTabs = False
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Controls.Add(Me.TabControlPanel4)
        Me.TabControl1.Controls.Add(Me.TabControlPanel3)
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 6)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(659, 422)
        Me.TabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005Document
        Me.TabControl1.TabIndex = 0
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.tabGeneral)
        Me.TabControl1.Tabs.Add(Me.tabDescuentos)
        Me.TabControl1.Tabs.Add(Me.tabEsquemas)
        Me.TabControl1.Tabs.Add(Me.tabJornadas)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.lbTipo)
        Me.TabControlPanel1.Controls.Add(Me.cbTipo)
        Me.TabControlPanel1.Controls.Add(Me.chKilometraje)
        Me.TabControlPanel1.Controls.Add(Me.btConfiguracion)
        Me.TabControlPanel1.Controls.Add(Me.ebConfiguracion)
        Me.TabControlPanel1.Controls.Add(Me.chbDatosFiscales)
        Me.TabControlPanel1.Controls.Add(Me.lbNombre)
        Me.TabControlPanel1.Controls.Add(Me.cbTipoModImp)
        Me.TabControlPanel1.Controls.Add(Me.chMostrarCuota)
        Me.TabControlPanel1.Controls.Add(Me.lbTipoModImp)
        Me.TabControlPanel1.Controls.Add(Me.btRuta)
        Me.TabControlPanel1.Controls.Add(Me.chMantenerPrm)
        Me.TabControlPanel1.Controls.Add(Me.cbCaptura)
        Me.TabControlPanel1.Controls.Add(Me.gbCentroDist)
        Me.TabControlPanel1.Controls.Add(Me.ebTerminalDesc)
        Me.TabControlPanel1.Controls.Add(Me.chbCapturaFolioFac)
        Me.TabControlPanel1.Controls.Add(Me.ebTerminal)
        Me.TabControlPanel1.Controls.Add(Me.chbJornadaTrabajo)
        Me.TabControlPanel1.Controls.Add(Me.lbEstado)
        Me.TabControlPanel1.Controls.Add(Me.chbMostrarEsquema)
        Me.TabControlPanel1.Controls.Add(Me.ebUsuario)
        Me.TabControlPanel1.Controls.Add(Me.txtruta)
        Me.TabControlPanel1.Controls.Add(Me.ebNombre)
        Me.TabControlPanel1.Controls.Add(Me.lbRuta)
        Me.TabControlPanel1.Controls.Add(Me.lbTerminal)
        Me.TabControlPanel1.Controls.Add(Me.chActualizar)
        Me.TabControlPanel1.Controls.Add(Me.ebUsuarioDesc)
        Me.TabControlPanel1.Controls.Add(Me.chCapturar)
        Me.TabControlPanel1.Controls.Add(Me.lbModulo)
        Me.TabControlPanel1.Controls.Add(Me.cbAlmacenId)
        Me.TabControlPanel1.Controls.Add(Me.lbNivelExp)
        Me.TabControlPanel1.Controls.Add(Me.lbAlmacen)
        Me.TabControlPanel1.Controls.Add(Me.ebUsuarioId)
        Me.TabControlPanel1.Controls.Add(Me.lbUsuario)
        Me.TabControlPanel1.Controls.Add(Me.cbNivelExp)
        Me.TabControlPanel1.Controls.Add(Me.lbCaptura)
        Me.TabControlPanel1.Controls.Add(Me.cbEstado)
        Me.TabControlPanel1.Controls.Add(Me.ebLimiteDesc)
        Me.TabControlPanel1.Controls.Add(Me.chBaja)
        Me.TabControlPanel1.Controls.Add(Me.btTerminal)
        Me.TabControlPanel1.Controls.Add(Me.btUsuario)
        Me.TabControlPanel1.Controls.Add(Me.lbLimiteDesc)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(659, 396)
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.tabGeneral
        '
        'lbTipo
        '
        Me.lbTipo.BackColor = System.Drawing.Color.Transparent
        Me.lbTipo.Location = New System.Drawing.Point(14, 54)
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(132, 20)
        Me.lbTipo.TabIndex = 34
        Me.lbTipo.Text = "lbTipo"
        Me.lbTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbTipo
        '
        Me.cbTipo.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbTipo.Location = New System.Drawing.Point(150, 54)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(172, 20)
        Me.cbTipo.TabIndex = 2
        Me.cbTipo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'chKilometraje
        '
        Me.chKilometraje.BackColor = System.Drawing.Color.Transparent
        Me.chKilometraje.Location = New System.Drawing.Point(182, 276)
        Me.chKilometraje.Name = "chKilometraje"
        Me.chKilometraje.Size = New System.Drawing.Size(132, 16)
        Me.chKilometraje.TabIndex = 26
        Me.chKilometraje.Text = "chKilometraje"
        Me.chKilometraje.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btConfiguracion
        '
        Me.btConfiguracion.Location = New System.Drawing.Point(622, 54)
        Me.btConfiguracion.Name = "btConfiguracion"
        Me.btConfiguracion.Size = New System.Drawing.Size(24, 20)
        Me.btConfiguracion.TabIndex = 4
        Me.btConfiguracion.Text = "..."
        Me.btConfiguracion.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'ebConfiguracion
        '
        Me.ebConfiguracion.Location = New System.Drawing.Point(474, 54)
        Me.ebConfiguracion.Name = "ebConfiguracion"
        Me.ebConfiguracion.Size = New System.Drawing.Size(148, 20)
        Me.ebConfiguracion.TabIndex = 3
        Me.ebConfiguracion.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebConfiguracion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'tabGeneral
        '
        Me.tabGeneral.AttachedControl = Me.TabControlPanel1
        Me.tabGeneral.Name = "tabGeneral"
        Me.tabGeneral.Text = "tabGeneral"
        '
        'TabControlPanel4
        '
        Me.TabControlPanel4.Controls.Add(Me.grJornadas)
        Me.TabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel4.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel4.Name = "TabControlPanel4"
        Me.TabControlPanel4.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel4.Size = New System.Drawing.Size(659, 396)
        Me.TabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel4.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel4.Style.GradientAngle = 90
        Me.TabControlPanel4.TabIndex = 4
        Me.TabControlPanel4.TabItem = Me.tabJornadas
        '
        'tabJornadas
        '
        Me.tabJornadas.AttachedControl = Me.TabControlPanel4
        Me.tabJornadas.Name = "tabJornadas"
        Me.tabJornadas.Text = "tabJornadas"
        '
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.grVendedorEsquema)
        Me.TabControlPanel3.Controls.Add(Me.btVEECrear)
        Me.TabControlPanel3.Controls.Add(Me.btVEEBuscar)
        Me.TabControlPanel3.Controls.Add(Me.btVEEEliminar)
        Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel3.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel3.Name = "TabControlPanel3"
        Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel3.Size = New System.Drawing.Size(659, 396)
        Me.TabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel3.Style.GradientAngle = 90
        Me.TabControlPanel3.TabIndex = 3
        Me.TabControlPanel3.TabItem = Me.tabEsquemas
        '
        'tabEsquemas
        '
        Me.tabEsquemas.AttachedControl = Me.TabControlPanel3
        Me.tabEsquemas.Name = "tabEsquemas"
        Me.tabEsquemas.Text = "tabEsquemas"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.btVEDCrear)
        Me.TabControlPanel2.Controls.Add(Me.grVendedorDescuento)
        Me.TabControlPanel2.Controls.Add(Me.btVEDEliminar)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(659, 396)
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.tabDescuentos
        '
        'tabDescuentos
        '
        Me.tabDescuentos.AttachedControl = Me.TabControlPanel2
        Me.tabDescuentos.Name = "tabDescuentos"
        Me.tabDescuentos.Text = "tabDescuentos"
        '
        'MGeneral
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(683, 470)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "MGeneral"
        Me.Text = "Modificar"
        Me.Controls.SetChildIndex(Me.BtAceptar, 0)
        Me.Controls.SetChildIndex(Me.BtCancelar, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.EbClave, 0)
        Me.Controls.SetChildIndex(Me.lbClave, 0)
        Me.Controls.SetChildIndex(Me.lbLinea, 0)
        CType(Me.epErrores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbCentroDist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCentroDist.ResumeLayout(False)
        Me.gbCentroDist.PerformLayout()
        CType(Me.grVendedorDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grVendedorEsquema, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grJornadas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        Me.TabControlPanel4.ResumeLayout(False)
        Me.TabControlPanel3.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Variables de Clase"
    Private vcAcceso As LbAcceso.cAcceso
    Private vcModo As eModo
    Private vcVendedor As cVendedor
    Private vcUsuario As New cUsuario
    'Private vcUsuario As cUsuario
    Private vcUsuarioID As String
    Private vcCerrar As Boolean = False
    Private vcMensaje As New CMensaje
    Private vcHuboCambios As Boolean = False
    Private vcTerminalClaveAnt As String
    Private vcEsquema As New ERMESQLOG.CEsquema
    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vcModuloMovDetalleClave As String
    Private vcAlmacen As New ERMALMLOG.cAlmacen
    Private vcEsquemaId As String
    Private vcCargando As Boolean = False
    Private vcTipoEstadoOriginal As Integer
    Private vcConfiguracion As New ERMCONLOG.cConfiguracion

#End Region

#Region "Funciones Generales"
    Private Sub LlenarValoresIniciales()
        Dim vlDs As New DataSet
        Dim vlDt As New DataTable
        Dim vlModulo As New cModuloTerm
        Dim vlSubModulo As New cModuloMov
        Dim vlSubModuloDetalle As New cModuloMovDetalle
        Dim vlItems1 As New Janus.Windows.EditControls.UIComboBox
        Dim vlItems2 As New Janus.Windows.EditControls.UIComboBox
        'Dim vlDSModulo As DataSet
        Dim vlDescuento As New ERMDESLOG.cDescuento

        tabGeneral.Text = vcMensaje.RecuperarDescripcion("ERMVENESC_MGeneral_tpGeneral")
        tabDescuentos.Text = vcMensaje.RecuperarDescripcion("ERMVENESC_MGeneral_tpDescuentos")
        tabEsquemas.Text = vcMensaje.RecuperarDescripcion("ERMVENESC_MGeneral_tpEsquemas")
        tabJornadas.Text = vcMensaje.RecuperarDescripcion("ERMVENESC_MGeneral_tpJornadas")

        gbCentroDist.Text = vcMensaje.RecuperarDescripcion("ERMVENESC_MGeneral_gbCentroDist")

        lbGeneral.LlenarComboBox(cbEstado, "EDOREG")
        lbGeneral.LlenarComboBox(cbTipo, "TVEND")

        'vlDSModulo = vlModulo.Tabla.RecuperarDataSet(, "ModuloClave, Nombre")
        'cbModulo.DataSource = vlDSModulo.Tables("ModuloTerm")
        'cbModulo.ValueMember = "ModuloClave"
        'cbModulo.DisplayMember = "Nombre"

        lbGeneral.LlenarComboBox(cbCaptura, "VENCPR")
        lbGeneral.LlenarComboBox(cbNivelExp, "VENEXP")

        vcConfiguracion.Recuperar()
        If vcConfiguracion.MostrarLogo Then
            lbGeneral.LlenarComboBoxConGrupo(cbTipoModImp, "TPAPEL", "Termica")
        Else
            lbGeneral.LlenarComboBox(cbTipoModImp, "TPAPEL")
        End If

        vlDs.Tables.Add(vlSubModuloDetalle.Tabla.Recuperar())
        grVendedorDescuento.DropDowns("ddModuloMovDetalle").SetDataBinding(vlDs, "ModuloMovDetalle")

        vlDs = New DataSet
        vlDs.Tables.Add(vlDescuento.Tabla.Recuperar(""))
        grVendedorDescuento.DropDowns("ddDescuento").SetDataBinding(vlDs, "Descuento")

        vlDt = New DataTable
        vlDt = vlModulo.Tabla.Recuperar("")
        For Each vlDataRow As DataRow In vlDt.Rows
            Dim vlItem As New Janus.Windows.GridEX.GridEXValueListItem
            vlItem.Value = vlDataRow("ModuloClave")
            vlItem.Text = vlDataRow("Nombre")
            grVendedorDescuento.DropDowns("ddModuloMovDetalle").Columns("ModuloClave").ValueList().Add(vlItem)
        Next

        vlDt = New DataTable
        vlDt = vlSubModulo.Tabla.Recuperar()
        For Each vlDataRow As DataRow In vlDt.Rows
            Dim vlItem As New Janus.Windows.GridEX.GridEXValueListItem
            vlItem.Value = vlDataRow("ModuloMovClave")
            vlItem.Text = vlDataRow("Nombre")
            grVendedorDescuento.DropDowns("ddModuloMovDetalle").Columns("ModuloMovClave").ValueList().Add(vlItem)
        Next
        grVendedorDescuento.DropDowns("ddModuloMovDetalle").Refresh()

        vlDt = New DataTable
        vlDt = vcAlmacen.Tabla.Recuperar("Tipo=2 AND TipoEstado=1")
        vlItems1.Items.Clear()
        For Each vlDataRow As DataRow In vlDt.Rows
            Dim vlItem As New Janus.Windows.EditControls.UIComboBoxItem
            vlItem.Value = vlDataRow!AlmacenID
            vlItem.Text = vlDataRow!Nombre
            vlItems1.Items.Add(vlItem)
        Next
        cbAlmacenId.DataSource = vlItems1.Items
        cbAlmacenId.ValueMember = "Value"
        cbAlmacenId.DisplayMember = "Text"

        vlDt = New DataTable
        vlDt = vcAlmacen.Tabla.Recuperar("Tipo=1 AND TipoEstado=1")
        vlItems2.Items.Clear()
        For Each vlDataRow As DataRow In vlDt.Rows
            Dim vlItem As New Janus.Windows.EditControls.UIComboBoxItem
            vlItem.Value = vlDataRow!AlmacenID
            vlItem.Text = vlDataRow!Nombre
            vlItems2.Items.Add(vlItem)
        Next

        If vcModo <> eModo.Crear And vcVendedor.VENCentroDistHist.Conteo > 0 Then
            If vlDt.Select("AlmacenId='" & vcVendedor.VENCentroDistHist(vcVendedor.VENCentroDistHist.Conteo - 1).AlmacenId & "'").Length = 0 Then
                vlDt = New DataTable
                vlDt = vcAlmacen.Tabla.Recuperar("AlmacenId='" & vcVendedor.VENCentroDistHist(vcVendedor.VENCentroDistHist.Conteo - 1).AlmacenId & "'")
                For Each vlDataRow As DataRow In vlDt.Rows
                    Dim vlItem As New Janus.Windows.EditControls.UIComboBoxItem
                    vlItem.Value = vlDataRow!AlmacenID
                    vlItem.Text = vlDataRow!Nombre
                    vlItems2.Items.Add(vlItem)
                Next
            End If
        End If
        cbVCHAlmacenId.DataSource = vlItems2.Items
        cbVCHAlmacenId.ValueMember = "Value"
        cbVCHAlmacenId.DisplayMember = "Text"

        lbGeneral.LlenarColumna(grVendedorDescuento.RootTable.Columns("TipoEstado"), "EDOREG")
        lbGeneral.LlenarColumna(grVendedorEsquema.RootTable.Columns("TipoEstado"), "EDOREG")
    End Sub

    Private Sub LlenarCampos()
        Dim vlTerminal As New cTerminal
        Dim vlDataTable As DataTable


        If vcModo = eModo.Crear Then
            vcCargando = True
            Me.EbClave.Text = lbGeneral.cKeyGen.KEYGEN(1)
            cbCaptura.SelectedValue = 1
            cbEstado.SelectedValue = 1
            cbTipo.SelectedValue = 1
            chBaja.Checked = False
            chCapturar.Checked = False
            chActualizar.Checked = False
            chbMostrarEsquema.Checked = False
            chMostrarCuota.Checked = True
            Me.chMantenerPrm.Checked = True
            'cbTipoModImp.SelectedValue = 0
            chbJornadaTrabajo.Checked = True
            Me.chbCapturaFolioFac.Checked = True
            chbDatosFiscales.Checked = False
            chKilometraje.Checked = False
            cbVCHFechaInicial.Value = vcConexion.ObtenerFecha.Date

            vcCargando = False
        Else
            vcCargando = True
            EbClave.Text = vcVendedor.VendedorID
            cbEstado.SelectedValue = vcVendedor.TipoEstado
            Me.cbTipo.SelectedValue = vcVendedor.tipo
            vcTipoEstadoOriginal = vcVendedor.TipoEstado
            ebNombre.Text = vcVendedor.Nombre
            ebConfiguracion.Text = vcVendedor.MCNClave
            cbCaptura.SelectedValue = vcVendedor.TipoCapturaProductos
            cbNivelExp.SelectedValue = vcVendedor.Nivel
            ebLimiteDesc.Value = vcVendedor.LimiteDescuento
            txtruta.Text = vcVendedor.DirInterfazSalida

            ebUsuarioId.Text = vcVendedor.USUId
            If ebUsuarioId.Text <> "" Then
                If vcUsuario.Recuperar(ebUsuarioId.Text) Then
                    ebUsuario.Text = vcUsuario.Clave
                    ebUsuarioDesc.Text = vcUsuario.Nombre
                End If
            End If

            ebTerminal.Text = vcVendedor.TerminalClave
            If ebTerminal.Text <> "" Then
                If vlTerminal.Recuperar(vcVendedor.TerminalClave) Then
                    ebTerminalDesc.Text = vlTerminal.Descripcion
                End If
            End If

            chBaja.Checked = vcVendedor.Baja
            cbAlmacenId.SelectedValue = vcVendedor.AlmacenId
            If vcVendedor.TipoModImp > 0 Then
                cbTipoModImp.SelectedValue = vcVendedor.TipoModImp
            End If
            chActualizar.Checked = vcVendedor.ActualizaEsquema
            chCapturar.Checked = vcVendedor.CapturaPrecio
            chbMostrarEsquema.Checked = vcVendedor.MostrarEsquema
            chMostrarCuota.Checked = vcVendedor.MostrarCuota
            Me.chMantenerPrm.Checked = vcVendedor.MantenerPrm
            chbJornadaTrabajo.Checked = vcVendedor.JornadaTrabajo
            Me.chbCapturaFolioFac.Checked = vcVendedor.CapturaFolioFac
            Me.chbDatosFiscales.Checked = vcVendedor.EditarDatosFiscal
            chKilometraje.Checked = vcVendedor.Kilometraje
            If vcVendedor.VENCentroDistHist.Conteo > 0 Then
                cbVCHFechaInicial.Value = vcVendedor.VENCentroDistHist(vcVendedor.VENCentroDistHist.Conteo - 1).VCHFechaInicial
                cbVCHAlmacenId.SelectedValue = vcVendedor.VENCentroDistHist(vcVendedor.VENCentroDistHist.Conteo - 1).AlmacenId
            End If
            vcCargando = False
        End If

        vlDataTable = vcVendedor.VendedorDescuento.ToDataTable()
        grVendedorDescuento.DataSource = vlDataTable
        grVendedorDescuento.DataMember = "VendedorDescuento"
        If vlDataTable.Rows.Count = 0 Then
            btVEDEliminar.Enabled = False
        End If

        vlDataTable = vcVendedor.VendedorEsquema.ToDataTable
        vlDataTable.Columns.Add("Clave", GetType(String))
        vlDataTable.Columns.Add("Nombre", GetType(String))
        For Each vlDataRow As DataRow In vlDataTable.Rows
            vcEsquema.Recuperar(vlDataRow!EsquemaID)
            vlDataRow!Clave = vcEsquema.Clave
            vlDataRow!Nombre = vcEsquema.Nombre
        Next
        grVendedorEsquema.DataSource = vlDataTable
        grVendedorEsquema.DataMember = "DESDetalle"
        If vlDataTable.Rows.Count = 0 Then
            btVEEEliminar.Enabled = False
        End If
        'Vendedor Jornada
        'vlDataTable = vcVendedor.VendedorJornada.ToDataTable
        vlDataTable = vcConexion.EjecutarConsulta("SELECT VJ.VendedorId, Dia.FechaCaptura, VJ.VEJFechaInicial, VJ.FechaFinal FROM VendedorJornada VJ Left JOIN Dia ON VJ.DiaClave=Dia.DiaClave WHERE VJ.VendedorId = '" + vcVendedor.VendedorID + "'")
        grJornadas.DataSource = vlDataTable
        'grJornadas.DataMember = "VendedorId"

        vcHuboCambios = False

        txtruta.Text = vcVendedor.DirInterfazSalida
    End Sub

    Private Sub DeshabilitaCampos()
        EbClave.Enabled = False
        cbEstado.Enabled = False
        cbTipo.Enabled = False
        ebNombre.Enabled = False
        ebConfiguracion.Enabled = False
        cbCaptura.Enabled = False
        cbNivelExp.Enabled = False
        ebLimiteDesc.Enabled = False
        ebUsuario.Enabled = False
        btUsuario.Enabled = False
        ebTerminal.Enabled = False
        btTerminal.Enabled = False
        cbAlmacenId.Enabled = False
        cbTipoModImp.Enabled = False
        txtruta.Enabled = False
        chbMostrarEsquema.Enabled = False
        chMostrarCuota.Enabled = False
        grVendedorDescuento.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
        grVendedorDescuento.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
        btVEDCrear.Enabled = False
        btVEDEliminar.Enabled = False
        grVendedorEsquema.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
        grVendedorEsquema.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
        btVEECrear.Enabled = False
        btVEEEliminar.Enabled = False
        btVEEBuscar.Enabled = False
        Me.chActualizar.Enabled = False
        Me.chCapturar.Enabled = False
        Me.chbMostrarEsquema.Enabled = False
        Me.chbJornadaTrabajo.Enabled = False
        Me.chbCapturaFolioFac.Enabled = False
        Me.cbVCHAlmacenId.Enabled = False
        Me.chMantenerPrm.Enabled = False
        Me.chbDatosFiscales.Enabled = False
        Me.chKilometraje.Enabled = False
        btRuta.Enabled = False
        Me.btConfiguracion.Enabled = False
    End Sub

    Private Sub HabilitaCampos()
        EbClave.Enabled = True
        cbEstado.Enabled = True
        cbTipo.Enabled = True
        ebNombre.Enabled = True
        ebConfiguracion.Enabled = True
        cbCaptura.Enabled = True
        cbNivelExp.Enabled = True
        chbMostrarEsquema.Enabled = True
        chMostrarCuota.Enabled = True
        ebLimiteDesc.Enabled = True
        ebUsuario.Enabled = True
        btUsuario.Enabled = True
        ebTerminal.Enabled = True
        btTerminal.Enabled = True
        txtruta.Enabled = True
        cbAlmacenId.Enabled = True
        cbTipoModImp.Enabled = True
        grVendedorDescuento.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
        grVendedorDescuento.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
        btVEDCrear.Enabled = True
        btVEDEliminar.Enabled = True
        grVendedorEsquema.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
        grVendedorEsquema.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
        btVEECrear.Enabled = True
        btVEEEliminar.Enabled = True
        btVEEBuscar.Enabled = True
        Me.chCapturar.Enabled = True
        Me.chActualizar.Enabled = True
        Me.chbMostrarEsquema.Enabled = True
        Me.chbJornadaTrabajo.Enabled = True
        Me.chbCapturaFolioFac.Enabled = True
        Me.cbVCHAlmacenId.Enabled = True
        Me.chMantenerPrm.Enabled = True
        Me.chbDatosFiscales.Enabled = True
        Me.chKilometraje.Enabled = True

    End Sub

    Private Sub ConfigurarTitulos()
        Me.lbClave.Text = vcMensaje.RecuperarDescripcion("VENVendedorID")
        Me.lbEstado.Text = vcMensaje.RecuperarDescripcion("VENTipoEstado")
        Me.lbNombre.Text = vcMensaje.RecuperarDescripcion("VENNombre")
        Me.lbTipo.Text = vcMensaje.RecuperarDescripcion("VENTipo")
        Me.lbModulo.Text = vcMensaje.RecuperarDescripcion("VENMCNClave")
        Me.lbCaptura.Text = vcMensaje.RecuperarDescripcion("VENTipoCapturaProductos")
        Me.lbNivelExp.Text = vcMensaje.RecuperarDescripcion("VENNivel")
        Me.lbLimiteDesc.Text = vcMensaje.RecuperarDescripcion("VENLimiteDescuento")
        Me.lbUsuario.Text = vcMensaje.RecuperarDescripcion("VENUsuarioClave")
        Me.lbTerminal.Text = vcMensaje.RecuperarDescripcion("VENTerminalClave")
        Me.chBaja.Text = vcMensaje.RecuperarDescripcion("VENBaja")
        Me.lbRuta.Text = vcMensaje.RecuperarDescripcion("VENDirInterfazSalida")
        Me.lbAlmacen.Text = vcMensaje.RecuperarDescripcion("VENAlmacenId")
        Me.lbTipoModImp.Text = vcMensaje.RecuperarDescripcion("VENTipoModImp")
        Me.chActualizar.Text = vcMensaje.RecuperarDescripcion("VENActualizaEsquema")
        Me.chCapturar.Text = vcMensaje.RecuperarDescripcion("VENCapturaPrecio")
        Me.chbMostrarEsquema.Text = vcMensaje.RecuperarDescripcion("VENMostrarEsquema")
        Me.chMostrarCuota.Text = vcMensaje.RecuperarDescripcion("VENMostrarCuota")
        Me.chMantenerPrm.Text = vcMensaje.RecuperarDescripcion("VENMantenerPrm")
        Me.chbDatosFiscales.Text = vcMensaje.RecuperarDescripcion("VENEditarDatosFiscal")
        Me.chKilometraje.Text = vcMensaje.RecuperarDescripcion("VENKilometraje")

        Me.chbJornadaTrabajo.Text = vcMensaje.RecuperarDescripcion("VENJornadaTrabajo")
        Me.chbCapturaFolioFac.Text = vcMensaje.RecuperarDescripcion("VENCapturaFolioFac")
        Me.lbVCHFechaInicial.Text = vcMensaje.RecuperarDescripcion("VCHVCHFechaInicial")
        Me.lbVCHALMNombre.Text = vcMensaje.RecuperarDescripcion("VCHAlmacenId")
        Me.btHistorico.Text = vcMensaje.RecuperarDescripcion("btHistorico")

        'Poner en el Tag el Nombre del Campo en la BD
        Me.EbClave.Tag = "TerminalClave"
        Me.cbEstado.Tag = "TipoEstado"
        Me.cbTipo.Tag = "Tipo"
        Me.ebNombre.Tag = "Nombre"
        txtruta.Tag = "Ruta"
        Me.ebConfiguracion.Tag = "MCNClave"
        Me.cbCaptura.Tag = "TipoCapturaProductos"
        Me.cbNivelExp.Tag = "Nivel"
        Me.ebLimiteDesc.Tag = "LimiteDescuento"
        Me.ebUsuario.Tag = "USUId"
        Me.ebTerminal.Tag = "TerminalClave"
        Me.chBaja.Tag = "Baja"
        Me.cbAlmacenId.Tag = "AlmacenId"
        Me.cbTipoModImp.Tag = "TipoModImp"
        Me.chbMostrarEsquema.Tag = "MostrarEsquema"
        Me.chbJornadaTrabajo.Tag = "JornadaTrabajo"
        Me.chbCapturaFolioFac.Tag = "CapturaFolioFac"
        Me.chbDatosFiscales.Tag = "EditarDatosFiscal"
        Me.chKilometraje.Tag = "Kilometraje"
        Dim vlToolTip As New ToolTip

        With vlToolTip
            .ShowAlways = True
            .SetToolTip(Me.EbClave, vcMensaje.RecuperarDescripcion("VENVendedorIDT"))
            .SetToolTip(Me.cbEstado, vcMensaje.RecuperarDescripcion("VENTipoEstadoT"))
            .SetToolTip(Me.cbTipo, vcMensaje.RecuperarDescripcion("VENTipoT"))
            .SetToolTip(Me.ebNombre, vcMensaje.RecuperarDescripcion("VENNombreT"))
            .SetToolTip(Me.ebConfiguracion, vcMensaje.RecuperarDescripcion("VENMCNClaveT"))
            .SetToolTip(Me.cbCaptura, vcMensaje.RecuperarDescripcion("VENTipoCapturaProductosT"))
            .SetToolTip(Me.cbNivelExp, vcMensaje.RecuperarDescripcion("VENNivelT"))
            .SetToolTip(Me.ebLimiteDesc, vcMensaje.RecuperarDescripcion("VENLimiteDescuentoT"))
            .SetToolTip(Me.ebUsuario, vcMensaje.RecuperarDescripcion("VENUsuarioClaveT"))
            .SetToolTip(Me.ebUsuarioDesc, vcMensaje.RecuperarDescripcion("USUUsuarioNombreT"))
            .SetToolTip(Me.ebTerminal, vcMensaje.RecuperarDescripcion("VENTerminalClaveT"))
            .SetToolTip(Me.ebTerminalDesc, vcMensaje.RecuperarDescripcion("TERTerminalDescripcionT"))
            .SetToolTip(Me.chBaja, vcMensaje.RecuperarDescripcion("VENBajaT"))
            .SetToolTip(Me.cbAlmacenId, vcMensaje.RecuperarDescripcion("VENAlmacenIdT"))
            .SetToolTip(Me.cbTipoModImp, vcMensaje.RecuperarDescripcion("VENTipoModImpT"))
            .SetToolTip(Me.chActualizar, vcMensaje.RecuperarDescripcion("VENActualizaEsquemaT"))
            .SetToolTip(Me.chCapturar, vcMensaje.RecuperarDescripcion("VENCapturaPrecioT"))
            .SetToolTip(txtruta, vcMensaje.RecuperarDescripcion("VENDirInterfazSalida"))
            .SetToolTip(Me.chbMostrarEsquema, vcMensaje.RecuperarDescripcion("VENMostrarEsquemaT"))
            .SetToolTip(Me.chMostrarCuota, vcMensaje.RecuperarDescripcion("VENMostrarCuotaT"))
            .SetToolTip(Me.chbJornadaTrabajo, vcMensaje.RecuperarDescripcion("VENJornadaTrabajoT"))
            .SetToolTip(Me.chbCapturaFolioFac, vcMensaje.RecuperarDescripcion("VENCapturaFolioFacT"))
            .SetToolTip(Me.cbVCHAlmacenId, vcMensaje.RecuperarDescripcion("VCHAlmacenIdT"))
            .SetToolTip(Me.btHistorico, vcMensaje.RecuperarDescripcion("btHistoricoT"))
            .SetToolTip(Me.chMantenerPrm, vcMensaje.RecuperarDescripcion("VENMantenerPrmT"))
            .SetToolTip(Me.chbDatosFiscales, vcMensaje.RecuperarDescripcion("VENEditarDatosFiscalT"))
            .SetToolTip(Me.chKilometraje, vcMensaje.RecuperarDescripcion("VENKilometrajeT"))

            .SetToolTip(btVEDCrear, vcMensaje.RecuperarDescripcion("btCrearT"))
            .SetToolTip(btVEDEliminar, vcMensaje.RecuperarDescripcion("btEliminarT"))

            .SetToolTip(btVEECrear, vcMensaje.RecuperarDescripcion("btCrearT"))
            .SetToolTip(btVEEEliminar, vcMensaje.RecuperarDescripcion("btEliminarT"))
            .SetToolTip(btVEEBuscar, vcMensaje.RecuperarDescripcion("btBuscarT"))

            .SetToolTip(Me.BtAceptar, vcMensaje.RecuperarDescripcion("BTAceptarT"))
            If vcModo = eModo.Leer Then
                .SetToolTip(Me.BtCancelar, vcMensaje.RecuperarDescripcion("BTRegresar"))
                BtCancelar.Focus()
            Else
                .SetToolTip(Me.BtCancelar, vcMensaje.RecuperarDescripcion("BTCancelarT"))
            End If

        End With


        With grVendedorDescuento.RootTable
            .Columns("ModuloMovDetalleClave").Caption = vcMensaje.RecuperarDescripcion("VEDModuloMovDetalleClave")
            .Columns("ModuloMovDetalleClave").HeaderToolTip = vcMensaje.RecuperarDescripcion("VEDModuloMovDetalleClaveT")
            .Columns("AplicaVendedor").Caption = vcMensaje.RecuperarDescripcion("VEDAplicaVendedor")
            .Columns("AplicaVendedor").HeaderToolTip = vcMensaje.RecuperarDescripcion("VEDAplicaVendedorT")
            .Columns("AplicaCliente").Caption = vcMensaje.RecuperarDescripcion("VEDAplicaCliente")
            .Columns("AplicaCliente").HeaderToolTip = vcMensaje.RecuperarDescripcion("VEDAplicaClienteT")
            .Columns("AplicaProducto").Caption = vcMensaje.RecuperarDescripcion("VEDAplicaProducto")
            .Columns("AplicaProducto").HeaderToolTip = vcMensaje.RecuperarDescripcion("VEDAplicaProductoT")
            .Columns("TipoEstado").Caption = vcMensaje.RecuperarDescripcion("VEDTipoEstado")
            .Columns("TipoEstado").HeaderToolTip = vcMensaje.RecuperarDescripcion("VEDTipoEstadoT")
        End With

        btVEDCrear.Text = vcMensaje.RecuperarDescripcion("btCrear")
        btVEDEliminar.Text = vcMensaje.RecuperarDescripcion("btEliminar")

        With grVendedorEsquema.RootTable
            .Columns("Clave").Caption = vcMensaje.RecuperarDescripcion("ESQClave")
            .Columns("Clave").HeaderToolTip = vcMensaje.RecuperarDescripcion("ESQClaveT")
            .Columns("Nombre").Caption = vcMensaje.RecuperarDescripcion("ESQNombre")
            .Columns("Nombre").HeaderToolTip = vcMensaje.RecuperarDescripcion("ESQNombreT")
            .Columns("TipoEstado").Caption = vcMensaje.RecuperarDescripcion("VEETipoEstado")
            .Columns("TipoEstado").HeaderToolTip = vcMensaje.RecuperarDescripcion("VEETipoEstadoT")
        End With

        With grJornadas.RootTable
            .Columns("VEJFechaInicial").Caption = vcMensaje.RecuperarDescripcion("VEJFechaInicial")
            .Columns("VEJFechaInicial").HeaderToolTip = vcMensaje.RecuperarDescripcion("VEJFechaInicialT")
            .Columns("FechaCaptura").Caption = vcMensaje.RecuperarDescripcion("DIAFechaCaptura")
            .Columns("FechaCaptura").HeaderToolTip = vcMensaje.RecuperarDescripcion("DIAFechaCapturaT")
            .Columns("FechaFinal").Caption = vcMensaje.RecuperarDescripcion("VEJFechaFinal")
            .Columns("FechaFinal").HeaderToolTip = vcMensaje.RecuperarDescripcion("VEJFechaFinalT")

        End With

        btVEECrear.Text = vcMensaje.RecuperarDescripcion("btCrear")
        btVEEEliminar.Text = vcMensaje.RecuperarDescripcion("btEliminar")
        btVEEBuscar.Text = vcMensaje.RecuperarDescripcion("btBuscar")

        Me.BtAceptar.Text = vcMensaje.RecuperarDescripcion("BTAceptar")
        Me.BtCancelar.Text = vcMensaje.RecuperarDescripcion("BTCancelar")

    End Sub

    Function CREAR(ByRef prVendedor As cVendedor, ByVal pvUsuarioID As String) As Boolean
        vcModo = eModo.Crear
        vcVendedor = prVendedor
        vcUsuarioID = pvUsuarioID

        Call ConfigurarTitulos()
        Call LlenarValoresIniciales()
        Call LlenarCampos()
        cbEstado.Enabled = False

        Me.Text = vcMensaje.RecuperarDescripcion("ERMVENESC_MGeneralC")

        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                vcVendedor.Grabar()
            Catch ex As LbControlError.cError
                ex.Mostrar()
                Exit Function
            End Try
            vcConexion.ConfirmarTran()
            Return True
        Else
            vcConexion.DeshacerTran()
            Return False
        End If
    End Function

    Function MODIFICAR(ByRef prVendedor As cVendedor, ByVal pvUsuarioID As String) As Boolean

        vcModo = eModo.Modificar
        vcVendedor = prVendedor
        vcUsuarioID = pvUsuarioID

        ConfigurarTitulos()
        Call LlenarValoresIniciales()
        LlenarCampos()
        'If vcVendedor.TipoEstado = 0 Then
        'Call DeshabilitaCampos()
        'cbEstado.Enabled = True
        'vcTerminalClaveAnt = ""
        'Else
        vcTerminalClaveAnt = ebTerminal.Text
        ' End If

        Me.Text = vcMensaje.RecuperarDescripcion("ERMVENESC_MGeneralM")

        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                vcVendedor.Grabar()
            Catch ex As LbControlError.cError
                ex.Mostrar()
                Exit Function
            End Try
            vcConexion.ConfirmarTran()
            Return True
        Else
            vcConexion.DeshacerTran()
            Return False
        End If
    End Function

    Function ELIMINAR(ByRef prVendedor As cVendedor, ByVal pvUsuarioID As String) As Boolean
        vcModo = eModo.Eliminar
        vcVendedor = prVendedor
        vcUsuarioID = pvUsuarioID
        ELIMINAR = True
        Call ConfigurarTitulos()
        Call LlenarValoresIniciales()
        Call LlenarCampos()
        Call DeshabilitaCampos()

        Me.Text = vcMensaje.RecuperarDescripcion("ERMVENESC_MGeneralE")

        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                vcVendedor.Grabar()
            Catch ex As LbControlError.cError
                ex.Mostrar()
                Exit Function
            End Try
            vcConexion.ConfirmarTran()
            Return True
        Else
            vcConexion.DeshacerTran()
            Return False
        End If
    End Function

    Function LEER(ByRef prVendedor As cVendedor, ByVal pvUsuarioID As String) As Boolean
        vcModo = eModo.Leer
        vcVendedor = prVendedor
        vcUsuarioID = pvUsuarioID

        Call ConfigurarTitulos()
        Call LlenarValoresIniciales()
        Call LlenarCampos()
        Call DeshabilitaCampos()

        Me.Text = vcMensaje.RecuperarDescripcion("xConsultar") + " " + vcMensaje.RecuperarDescripcion("ERMVENESC_NGeneral")
        BtAceptar.Visible = False
        BtCancelar.Text = vcMensaje.RecuperarDescripcion("BTRegresar")
        BtCancelar.Icon = BtAceptar.Icon
        BtCancelar.Focus()

        If Me.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub DeshabilitaCrear(ByRef peGridEx As Janus.Windows.GridEX.GridEX)
        If peGridEx.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True Then
            If (peGridEx.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Or peGridEx.DataChanged = False) Then
                peGridEx.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False

                Select Case (peGridEx.Name)
                    Case "grVendedorEsquema"
                        grVendedorEsquema.RootTable.Columns("Clave").EditType = Janus.Windows.GridEX.EditType.NoEdit
                End Select

                If (peGridEx.Row = 0) Then
                    peGridEx.MoveLast()
                End If
            End If
        End If
    End Sub

    Private Sub LlenarNulos(ByRef prGrid As Janus.Windows.GridEX.GridEX)
        For Each vlCelda As Janus.Windows.GridEX.GridEXCell In prGrid.GetRow.Cells
            If IsDBNull(vlCelda.Value) Or IsNothing(vlCelda.Value) Then
                Select Case prGrid.Name
                    Case "grVendedorEsquema"
                        Select Case vlCelda.Column.Key
                            Case "Clave"
                                vlCelda.Value = ""
                            Case "TipoEstado"
                                vlCelda.Value = 1
                        End Select
                    Case "grVendedorDescuento"
                        Select Case vlCelda.Column.Key
                            Case "ModuloMovDetalleClave"
                                vlCelda.Value = ""
                            Case "AplicaProducto"
                                vlCelda.Value = False
                            Case "AplicaCliente"
                                vlCelda.Value = False
                            Case "AplicaVendedor"
                                vlCelda.Value = False
                            Case "TipoEstado"
                                vlCelda.Value = 1
                        End Select
                End Select
            End If
        Next
    End Sub

    Friend Function CargasPorTransferir(ByRef prVendedor As ERMVENLOG.cVendedor, Optional ByVal pvAlmacenId As String = "") As Boolean
        Dim oTransProd As New ERMTRPLOG.cTransProd
        Dim ldt As DataTable

        'ldt = oTransProd.TablaNodo.Recuperar("Tipo=2 AND TipoFase=5 AND Convert(DateTime,DiaClave, 103)>=" & vcConexion.UniFechaSQL(vcConexion.ObtenerFecha.Date) & " AND MUsuarioId='" & prVendedor.USUId & "'")
        ldt = oTransProd.TablaNodo.Recuperar("Tipo=2 AND TipoFase=5 AND MUsuarioId='" & prVendedor.USUId & "'")

        If pvAlmacenId = "" And ldt.Rows.Count > 0 Then
            Return True
        ElseIf pvAlmacenId <> "" And ldt.Rows.Count > 0 Then
            Dim oAlmacen As New ERMALMLOG.cAlmacen
            oAlmacen.Recuperar(pvAlmacenId)
            If ldt.Rows(0)!Notas.ToString.ToUpper = oAlmacen.Clave.ToUpper Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function
#End Region

#Region "Tab 1 Generales"
    Private Sub PonerFoco(ByVal pvNombreCampo As String)
        Select Case pvNombreCampo
            Case "VendedorID"
                Me.EbClave.Focus()
            Case "Nombre"
                Me.ebNombre.Focus()
            Case "MCNClave"
                Me.ebConfiguracion.Focus()
            Case "TipoCapturaProductos"
                Me.cbCaptura.Focus()
            Case "Nivel"
                Me.cbNivelExp.Focus()
            Case "LimiteDescuento"
                Me.ebLimiteDesc.Focus()
            Case "TipoEstado"
                Me.cbEstado.Focus()
            Case "USUId"
                Me.ebUsuario.Focus()
            Case "TerminalClave"
                Me.ebTerminal.Focus()
            Case "Baja"
                Me.chBaja.Focus()
            Case "AlmacenId"
                Me.cbAlmacenId.Focus()
            Case "TipoModImp"
                Me.cbTipoModImp.Focus()
            Case "txtruta"
                Me.txtruta.Focus()
            Case "MostrarEsquema"
                Me.chbMostrarEsquema.Focus()
            Case "JornadaTrabajo"
                Me.chbJornadaTrabajo.Focus()
            Case "CapturaFolioFac"
                Me.chbCapturaFolioFac.Focus()
            Case "EditarDatosFiscal"
                Me.chbDatosFiscales.Focus()
            Case "Kilometraje"
                Me.chKilometraje.Focus()
        End Select
    End Sub

    Private Sub ValidarCampos(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EbClave.Validated, ebNombre.Validated, cbCaptura.Validated, cbNivelExp.Validated, ebLimiteDesc.Validated, cbEstado.Validated, ebUsuario.Validated, ebTerminal.Validated, cbAlmacenId.Validated, cbTipoModImp.Validated, ebConfiguracion.Validated
        Call ValidarCampos(sender)
    End Sub

    Private Sub ValidarCampos(ByVal pvSender As System.Object)
        Dim vlCampo As String = String.Empty

        Select Case CType(pvSender.name, String)
            Case "EbClave"
                vcVendedor.VendedorID = EbClave.Text
                vlCampo = "VendedorID"
            Case "ebNombre"
                vcVendedor.Nombre = ebNombre.Text
                vlCampo = "Nombre"
            Case "ebConfiguracion"
                vcVendedor.MCNClave = ebConfiguracion.Text.Trim()
                vlCampo = "MCNClave"
                Try
                    ValidaConfiguracion()
                Catch ex As LbControlError.cError
                    epErrores.SetError(ebConfiguracion, ex.Mensaje)
                    Exit Sub
                End Try
            Case "cbCaptura"
                vcVendedor.TipoCapturaProductos = cbCaptura.SelectedValue
                vlCampo = "TipoCapturaProductos"
            Case "cbNivelExp"
                vcVendedor.Nivel = cbNivelExp.SelectedValue
                vlCampo = "Nivel"
            Case "ebLimiteDesc"
                vcVendedor.LimiteDescuento = ebLimiteDesc.Value
                vlCampo = "LimiteDescuento"
            Case "cbEstado"
                If vcTipoEstadoOriginal = 0 And cbEstado.SelectedValue = 1 Then
                    'Validar que el centro de distribución asignado se encuentre activo
                    Dim loAlmacen As New ERMALMLOG.cAlmacen
                    Dim ldt As DataTable
                    ldt = loAlmacen.Tabla.Recuperar("AlmacenId='" & cbVCHAlmacenId.SelectedValue & "' AND TipoEstado=1")
                    If ldt.Rows.Count = 0 Then
                        epErrores.SetError(pvSender, vcMensaje.RecuperarDescripcion("E0501"))
                        Exit Sub
                    End If
                ElseIf vcTipoEstadoOriginal = 1 And cbEstado.SelectedValue = 0 Then
                    'Validar que no tenga cargas activas asignadas
                    If CargasPorTransferir(vcVendedor) Then
                        epErrores.SetError(pvSender, vcMensaje.RecuperarDescripcion("E0527", New String() {lbEstado.Text}))
                        Exit Sub
                    End If
                End If
                vcVendedor.TipoEstado = cbEstado.SelectedValue
                vlCampo = "TipoEstado"
            Case "ebUsuario"
                vlCampo = "USUId"
                Me.ebUsuarioId.Text = ""
                Me.ebUsuarioDesc.Text = ""
                vcVendedor.USUId = ""
                Try
                    Call ValidaUsuario()
                Catch ex As LbControlError.cError
                    epErrores.SetError(ebUsuarioDesc, ex.Mensaje)
                    Exit Sub
                End Try
            Case "ebTerminal"
                vcVendedor.TerminalClave = ebTerminal.Text
                vlCampo = "TerminalClave"
                Try
                    Call ValidaTerminal()
                Catch ex As LbControlError.cError
                    epErrores.SetError(ebTerminalDesc, ex.Mensaje)
                    Exit Sub
                End Try
            Case "chBaja"
                vcVendedor.Baja = chBaja.Checked
                vlCampo = "Baja"
            Case "cbAlmacenId"
                vcVendedor.AlmacenId = cbAlmacenId.SelectedValue
                vlCampo = "AlmacenId"
            Case "cbTipoModImp"
                If Not IsNothing(cbTipoModImp.SelectedValue) Then
                    vcVendedor.TipoModImp = cbTipoModImp.SelectedValue
                End If
                vlCampo = "TipoModImp"
        End Select

        Try
            vcVendedor.ValidarCampos(New String() {vlCampo})
        Catch ex As LbControlError.cError
            If vlCampo = "USUId" Then
                epErrores.SetError(ebUsuarioDesc, ex.Mensaje)
                '*************************************************************
                '*************************************************************
                'MessageBox.Show(vcmensaje1.RecuperarDescripcion("[E0172]"))
                'MessageBox.Show(vcMensaje.RecuperarDescripcion("[E0172]"))
            ElseIf vlCampo = "TerminalClave" Then
                epErrores.SetError(ebTerminalDesc, ex.Mensaje)
            Else
                epErrores.SetError(pvSender, ex.Mensaje)
            End If
            Exit Sub
        End Try
        If vlCampo = "USUId" Then
            epErrores.SetError(ebUsuarioDesc, "")
        ElseIf vlCampo = "TerminalClave" Then
            epErrores.SetError(ebTerminalDesc, "")
        Else
            epErrores.SetError(pvSender, "")
        End If
    End Sub
    Private Sub ValidaConfiguracion()
        If ebConfiguracion.Text.Trim().Length > 0 Then
            Dim vlMOTConfig As New ERMMOTLOG.cMOTConfiguracion()
            Dim dt As DataTable = vlMOTConfig.Tabla.RecuperarTabla("MCNClave = '" + ebConfiguracion.Text + "'")
            If dt.Rows.Count = 0 Then
                Throw New LbControlError.cError("E0710")
            End If

            Dim vlModuloTerminal As New cModuloTerm
            vlModuloTerminal.Clave = dt.Rows(0)("ModuloClave")
            vlModuloTerminal.Recuperar()
            If Not IsNothing(vlModuloTerminal) Then
                If vlModuloTerminal.TipoEstado = 0 Or vlModuloTerminal.Baja Then
                    Throw New LbControlError.cError("E0710")
                End If
            End If
        End If
    End Sub
    Private Sub ValidaUsuario()
        If (ebUsuario.Text <> "") Then
            Dim vlDT As DataTable = vcUsuario.Tabla.Recuperar("Clave='" + ebUsuario.Text + "'")
            If vlDT.Rows.Count = 1 Then
                Dim svlVendedor As String
                Dim vlVendedor As New cVendedor
                svlVendedor = vlVendedor.ExisteUsuarioAsignado(EbClave.Text, vlDT.Rows(0)("USUId"))

                If svlVendedor = "" Then
                    ebUsuarioId.Text = vlDT.Rows(0)("USUId")
                    vcVendedor.USUId = vlDT.Rows(0)("USUId")
                    ebUsuario.Text = vlDT.Rows(0)("Clave")
                    ebUsuarioDesc.Text = vlDT.Rows(0)("Nombre")
                Else
                    If (svlVendedor <> vcVendedor.Nombre) Then
                        Throw New LbControlError.cError("E0172", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(svlVendedor, False)})
                    Else
                        ebUsuarioId.Text = vlDT.Rows(0)("USUId")
                        vcVendedor.USUId = vlDT.Rows(0)("USUId")
                        ebUsuario.Text = vlDT.Rows(0)("Clave")
                        ebUsuarioDesc.Text = vlDT.Rows(0)("Nombre")
                    End If
                End If
            Else
                Throw New LbControlError.cError("BE0003", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("VEN" + ebUsuario.Tag, True)})
            End If
        Else
            ebUsuarioId.Text = ""
            vcVendedor.USUId = ""
            ebUsuarioDesc.Text = ""
        End If
    End Sub
    Private Sub ValidaTerminal()
        Dim vcTerminal As New cTerminal

        If vcTerminalClaveAnt = ebTerminal.Text Then
            Exit Sub
        End If

        If vcTerminalClaveAnt <> "" Then
            If vcTerminal.Recuperar(vcTerminalClaveAnt) Then
                Dim vlAsignada As Boolean = vcVendedor.Tabla.Recuperar("TerminalClave='" & vcTerminal.TerminalClave & "' AND TipoEstado=1 AND Baja=0 AND VendedorId<>'" & vcVendedor.VendedorID & "'").Rows.Count > 0
                If vlAsignada And vcTerminal.TipoFase = 1 Then 'Activo
                    vcTerminal.TipoFase = 3
                    vcTerminal.Grabar()
                ElseIf Not vlAsignada And vcTerminal.TipoFase = 3 Then 'Asignado
                    vcTerminal.TipoFase = 1
                    vcTerminal.Grabar()
                End If
            End If
        End If

        vcTerminalClaveAnt = ""
        If (ebTerminal.Text <> "") Then
            vcTerminal = New cTerminal
            If vcTerminal.Recuperar(ebTerminal.Text) Then
                If cbEstado.SelectedValue = 1 Then 'Activo
                    If vcTerminal.TipoFase = 1 Then 'Activo
                        Me.ebTerminalDesc.Text = vcTerminal.Descripcion
                        vcTerminal.TipoFase = 3
                        vcTerminal.Grabar()
                        vcTerminalClaveAnt = ebTerminal.Text
                    ElseIf vcTerminal.TipoFase = 3 Then 'Asignado
                        'Me.ebTerminalDesc.Text = ""
                        Throw New LbControlError.cError("I0061")
                    Else
                        Throw New LbControlError.cError("BE0003", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("VENTerminalClave", True)})
                    End If
                Else
                    Dim vlAsignada As Boolean = vcVendedor.Tabla.Recuperar("TerminalClave='" & vcTerminal.TerminalClave & "' AND TipoEstado=1 AND Baja=0 AND VendedorId<>'" & vcVendedor.VendedorID & "'").Rows.Count > 0
                    If vlAsignada And vcTerminal.TipoFase = 1 Then 'Activo
                        vcTerminal.TipoFase = 3
                        vcTerminal.Grabar()
                    ElseIf Not vlAsignada And vcTerminal.TipoFase = 3 Then 'Asignado
                        vcTerminal.TipoFase = 1
                        vcTerminal.Grabar()
                    End If
                    Me.ebTerminalDesc.Text = vcTerminal.Descripcion
                    vcTerminalClaveAnt = ebTerminal.Text
                End If
            Else
                Me.ebTerminalDesc.Text = ""
                Throw New LbControlError.cError("BE0003", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("VENTerminalClave", True)})
            End If
        Else
            Me.ebTerminalDesc.Text = ""
        End If
    End Sub

    Private Sub Controles_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EbClave.TextChanged, cbEstado.SelectedValueChanged, ebNombre.TextChanged, cbCaptura.SelectedValueChanged, cbNivelExp.SelectedValueChanged, ebLimiteDesc.ValueChanged, ebUsuario.TextChanged, ebTerminal.TextChanged, chBaja.CheckedChanged, cbAlmacenId.SelectedValueChanged, cbTipoModImp.SelectedValueChanged, ebConfiguracion.TextChanged, chKilometraje.CheckedChanged, cbTipo.SelectedValueChanged
        Select Case CType(sender.Name, String)
            Case "cbEstado"
                If vcCargando Then Exit Sub

                vcVendedor.TipoEstado = cbEstado.SelectedValue
                Call ValidarCampos(ebUsuario)

                Try
                    vcTerminalClaveAnt = ""
                    Call ValidaTerminal()
                    epErrores.SetError(ebTerminalDesc, "")
                Catch ex As LbControlError.cError
                    epErrores.SetError(ebTerminalDesc, ex.Mensaje)
                End Try
            Case "cbTipo"
                'Habilitar si es vendedor de tipo Terminal
                ebConfiguracion.Enabled = (cbTipo.SelectedValue = 1)
                btConfiguracion.Enabled = (cbTipo.SelectedValue = 1)
                ebTerminal.Enabled = (cbTipo.SelectedValue = 1)
                btTerminal.Enabled = (cbTipo.SelectedValue = 1)
                cbNivelExp.Enabled = (cbTipo.SelectedValue = 1)
                'ebLimiteDesc.Enabled = (cbTipo.SelectedValue = 1)
                cbTipoModImp.Enabled = (cbTipo.SelectedValue = 1)

                chActualizar.Enabled = (cbTipo.SelectedValue = 1)
                chCapturar.Enabled = (cbTipo.SelectedValue = 1)
                chbMostrarEsquema.Enabled = (cbTipo.SelectedValue = 1)
                chbJornadaTrabajo.Enabled = (cbTipo.SelectedValue = 1)
                chbJornadaTrabajo.Checked = (cbTipo.SelectedValue = 1)
                chbCapturaFolioFac.Enabled = (cbTipo.SelectedValue = 1)
                chbCapturaFolioFac.Checked = (cbTipo.SelectedValue = 1)
                chMostrarCuota.Enabled = (cbTipo.SelectedValue = 1)
                chMostrarCuota.Checked = (cbTipo.SelectedValue = 1)
                chMantenerPrm.Enabled = (cbTipo.SelectedValue = 1)
                chMantenerPrm.Checked = (cbTipo.SelectedValue = 1)
                chbDatosFiscales.Enabled = (cbTipo.SelectedValue = 1)
                chKilometraje.Enabled = (cbTipo.SelectedValue = 1)

                If cbTipo.SelectedValue = 2 Then ' Mostrador
                    chActualizar.Checked = False
                    chCapturar.Checked = False
                    chbMostrarEsquema.Checked = False
                    chbDatosFiscales.Checked = False
                    chKilometraje.Checked = False
                    If Me.vcModo = eModo.Crear Then cbNivelExp.SelectedValue = 1

                End If

        End Select

        vcHuboCambios = True
    End Sub

    Private Sub Controles_ValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grVendedorDescuento.CellValueChanged, grVendedorEsquema.CellValueChanged
        vcHuboCambios = True
    End Sub

    Private Sub btTerminal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTerminal.Click
        Dim vlTerminal As New ERMTERESC.IGeneral
        Dim vlSeleccion As ArrayList

        If cbEstado.SelectedValue = 1 Then
            vlSeleccion = vlTerminal.Seleccionar("TipoFase = 1", False)
        Else
            vlSeleccion = vlTerminal.Seleccionar("", False)
        End If

        If Not vlSeleccion Is Nothing Then
            Me.ebTerminal.Text = vlSeleccion(0).TerminalClave
            epErrores.SetError(Me.ebTerminalDesc, "")
            Try
                ValidaTerminal()
            Catch ex As LbControlError.cError
                ex.Mostrar()
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub btUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUsuario.Click
        Dim vlUsuario As New BASUSUESC.IGeneral
        Dim vlSeleccion As ArrayList

        vlSeleccion = vlUsuario.Seleccionar("USUId not in(Select USUId from vendedor where VendedorID<>'" & vcVendedor.VendedorID & "' and TipoEstado = 1 and Baja=0)", False)


        If Not vlSeleccion Is Nothing Then
            Me.ebUsuario.Text = vlSeleccion(0).Clave
            epErrores.SetError(Me.ebUsuarioDesc, "")
            ValidaUsuario()
        End If
    End Sub

#End Region

#Region "Tab 2 Descuentos"
    Private Sub btVEDCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btVEDCrear.Click
        grVendedorDescuento.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
        grVendedorDescuento.MoveToNewRecord()
        grVendedorDescuento.Col = 0
        grVendedorDescuento.Focus()
    End Sub

    Private Sub btVEDEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btVEDEliminar.Click
        If (grVendedorDescuento.RowCount = 0) Then
            Exit Sub
        End If

        If (grVendedorDescuento.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
            grVendedorDescuento.CancelCurrentEdit()
            Call DeshabilitaCrear(grVendedorDescuento)
        ElseIf (grVendedorDescuento.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
            Dim aObj As Object = grVendedorDescuento.GetValue("ModuloMovDetalleClave")
            If Not vcVendedor.VendedorDescuento(aObj) Is Nothing Then
                vcVendedor.VendedorDescuento(aObj).Eliminar()
                'grVendedorDescuento.Delete()
                CType(grVendedorDescuento.DataSource, DataTable).Rows.RemoveAt(grVendedorDescuento.SelectedItems(0).Position)
            End If
        End If
    End Sub

    Private Sub grVendedorDescuento_AddingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grVendedorDescuento.AddingRecord
        Call LlenarNulos(grVendedorDescuento)

        For Each vlDataRow As Janus.Windows.GridEX.GridEXRow In grVendedorDescuento.GetRows
            If Not (vlDataRow Is grVendedorDescuento.GetRow) Then
                If LCase(vlDataRow.Cells("ModuloMovDetalleClave").Value) = LCase(grVendedorDescuento.GetValue("ModuloMovDetalleClave")) Then
                    Me.TabControl1.SelectedTabIndex = 1
                    grVendedorDescuento.Col = 0
                    MsgBox(vcMensaje.RecuperarDescripcion("BE0002"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Next

        vcVendedor.VendedorDescuento.ModuloMovDetalleClave = lbGeneral.ChkDbNull(grVendedorDescuento.GetValue("ModuloMovDetalleClave"))
        vcVendedor.VendedorDescuento.AplicaProducto = grVendedorDescuento.GetValue("AplicaProducto")
        vcVendedor.VendedorDescuento.AplicaCliente = grVendedorDescuento.GetValue("AplicaCliente")
        vcVendedor.VendedorDescuento.AplicaVendedor = grVendedorDescuento.GetValue("AplicaVendedor")
        vcVendedor.VendedorDescuento.TipoEstado = grVendedorDescuento.GetValue("TipoEstado")
        vcVendedor.VendedorDescuento.MUsuarioID = vcUsuarioID
        Try
            vcVendedor.VendedorDescuento.Insertar(New String() {"ModuloMovDetalleClave", "AplicaProducto", "AplicaCliente", "AplicaVendedor", "TipoEstado", "MUsuarioId"})
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Me.TabControl1.SelectedTabIndex = 1
            grVendedorDescuento.Col = 0
            grVendedorDescuento.EditMode = Janus.Windows.GridEX.EditMode.EditOn
            e.Cancel = True
        End Try
        vcModuloMovDetalleClave = lbGeneral.ChkDbNull(grVendedorDescuento.GetValue("ModuloMovDetalleClave"))
    End Sub

    Private Sub grVendedorDescuento_FirstChange(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles grVendedorDescuento.FirstChange
        vcHuboCambios = True
        If (grVendedorDescuento.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
            btVEDEliminar.Enabled = True
            btVEDCrear.Enabled = True
            If IsNothing(grVendedorDescuento.CurrentColumn) = False Then
                If grVendedorDescuento.CurrentColumn.Key <> "TipoEstado" Then
                    grVendedorDescuento.GetRow.Cells("TipoEstado").Value = 1
                End If
            End If
        End If
    End Sub

    Private Sub grVendedorDescuento_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles grVendedorDescuento.Leave
        Call DeshabilitaCrear(grVendedorDescuento)
    End Sub

    Private Sub grVendedorDescuento_RecordAdded(ByVal sender As Object, ByVal e As System.EventArgs) Handles grVendedorDescuento.RecordAdded
        If (grVendedorDescuento.Focused = False) Then
            Call DeshabilitaCrear(grVendedorDescuento)
        End If
    End Sub

    Private Sub grVendedorDescuento_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grVendedorDescuento.SelectionChanged
        With grVendedorDescuento
            Select Case (vcModo)
                Case eModo.Crear
                    .RootTable.Columns("ModuloMovDetalleClave").EditType = Janus.Windows.GridEX.EditType.MultiColumnDropDown
                Case eModo.Modificar
                    If Not (.GetRow Is Nothing) Then
                        If (.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                            .RootTable.Columns("ModuloMovDetalleClave").EditType = Janus.Windows.GridEX.EditType.MultiColumnDropDown
                        Else
                            If .GetRow.DataRow.Row.RowState = DataRowState.Added Then
                                .RootTable.Columns("ModuloMovDetalleClave").EditType = Janus.Windows.GridEX.EditType.MultiColumnDropDown
                            Else
                                .RootTable.Columns("ModuloMovDetalleClave").EditType = Janus.Windows.GridEX.EditType.NoEdit
                            End If
                        End If
                    End If
            End Select

            If .RowCount > 0 Then
                If Not .GetRow Is Nothing Then
                    If (.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                        btVEDEliminar.Enabled = False
                    Else
                        If .GetRow.DataRow.Row.RowState = DataRowState.Added And cbEstado.SelectedValue = 1 Then
                            btVEDEliminar.Enabled = True
                        Else
                            btVEDEliminar.Enabled = False
                        End If
                    End If
                Else
                    btVEDEliminar.Enabled = False
                End If
            End If
        End With
        vcModuloMovDetalleClave = lbGeneral.ChkDbNull(grVendedorDescuento.GetValue("ModuloMovDetalleClave"))
    End Sub

    Private Sub grVendedorDescuento_UpdatingRecord(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grVendedorDescuento.UpdatingRecord
        If grVendedorDescuento.GetRow Is Nothing Then
            Exit Sub
        End If
        Call LlenarNulos(grVendedorDescuento)
        If grVendedorDescuento.GetValue("ModuloMovDetalleClave") = "" Then
            Me.TabControl1.SelectedTabIndex = 1
            grVendedorDescuento.Col = 0
            MsgBox(vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion("VEDModuloMovDetalleClave")}), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
            e.Cancel = True
            Exit Sub
        End If

        For Each vlDataRow As Janus.Windows.GridEX.GridEXRow In grVendedorDescuento.GetRows
            If Not (vlDataRow Is grVendedorDescuento.GetRow) Then
                If LCase(vlDataRow.Cells("ModuloMovDetalleClave").Value) = LCase(grVendedorDescuento.GetValue("ModuloMovDetalleClave")) Then
                    Me.TabControl1.SelectedTabIndex = 1
                    grVendedorDescuento.Col = 0
                    MsgBox(vcMensaje.RecuperarDescripcion("BE0002"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Next

        vcVendedor.VendedorDescuento(vcModuloMovDetalleClave).ModuloMovDetalleClave = grVendedorDescuento.GetValue("ModuloMovDetalleClave")
        vcVendedor.VendedorDescuento(grVendedorDescuento.GetValue("ModuloMovDetalleClave")).AplicaProducto = grVendedorDescuento.GetValue("AplicaProducto")
        vcVendedor.VendedorDescuento(grVendedorDescuento.GetValue("ModuloMovDetalleClave")).AplicaCliente = grVendedorDescuento.GetValue("AplicaCliente")
        vcVendedor.VendedorDescuento(grVendedorDescuento.GetValue("ModuloMovDetalleClave")).AplicaVendedor = grVendedorDescuento.GetValue("AplicaVendedor")
        vcVendedor.VendedorDescuento(grVendedorDescuento.GetValue("ModuloMovDetalleClave")).TipoEstado = grVendedorDescuento.GetValue("TipoEstado")
        vcVendedor.VendedorDescuento(grVendedorDescuento.GetValue("ModuloMovDetalleClave")).MUsuarioID = vcUsuarioID
        Try
            vcVendedor.VendedorDescuento(grVendedorDescuento.GetValue("ModuloMovDetalleClave")).ValidarCampos(New String() {"AplicaProducto", "AplicaCliente", "AplicaVendedor", "TipoEstado", "MUsuarioId"})
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Me.TabControl1.SelectedTabIndex = 1
            grVendedorDescuento.Col = 1
            e.Cancel = True
        End Try
        vcModuloMovDetalleClave = lbGeneral.ChkDbNull(grVendedorDescuento.GetValue("ModuloMovDetalleClave"))
    End Sub

    Private Sub grVendedorDescuento_CancelingRowEdit(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionCancelEventArgs) Handles grVendedorDescuento.CancelingRowEdit
        e.Cancel = True
    End Sub

#End Region

#Region "Tab 3 Esquemas"
    Private Sub btVEECrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btVEECrear.Click
        grVendedorEsquema.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
        grVendedorEsquema.Col = 1
        grVendedorEsquema.MoveToNewRecord()
        grVendedorEsquema.RootTable.Columns("Clave").EditType = Janus.Windows.GridEX.EditType.TextBox
        grVendedorEsquema.Focus()
    End Sub

    Private Sub btVEEEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btVEEEliminar.Click
        If (grVendedorEsquema.RowCount = 0) Then
            Exit Sub
        End If

        If (grVendedorEsquema.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
            grVendedorEsquema.CancelCurrentEdit()
            Call DeshabilitaCrear(grVendedorEsquema)
        ElseIf (grVendedorEsquema.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
            vcVendedor.VendedorEsquema(grVendedorEsquema.GetValue("EsquemaId")).Eliminar()
            grVendedorEsquema.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
            grVendedorEsquema.Delete()
            grVendedorEsquema.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
        End If
    End Sub

    Private Sub btVEEBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btVEEBuscar.Click
        Dim vlEsquemaIndex As New ERMESQESC.IGeneral(True, , "Tipo=1 AND TipoEstado=1 AND Baja=0")
        Dim vlArrayList As ArrayList
        Dim vlDataTable As DataTable
        vcHuboCambios = True
        vlEsquemaIndex.ShowDialog()
        vlArrayList = vlEsquemaIndex.Seleccion
        If IsNothing(vlArrayList) = False Then
            vlDataTable = grVendedorEsquema.DataSource
            For Each vlEsquema As DataRow In vlArrayList
                If vlDataTable.Select("EsquemaID='" + vlEsquema!EsquemaID + "'").Length = 0 Then
                    grVendedorEsquema.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                    grVendedorEsquema.MoveToNewRecord()
                    grVendedorEsquema.GetRow.Cells("Clave").Value = vlEsquema!Clave
                    ObtenerEsquema(vlEsquema!Clave)
                    grVendedorEsquema.GetRow.Cells("TipoEstado").Value = 1
                    grVendedorEsquema.UpdateData()
                End If
            Next
            grVendedorEsquema.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
            grVendedorEsquema.Focus()
        End If

    End Sub

    Private Sub grVendedorEsquema_AddingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grVendedorEsquema.AddingRecord
        Call LlenarNulos(grVendedorEsquema)
        vcVendedor.VendedorEsquema.EsquemaId = lbGeneral.ChkDbNull(grVendedorEsquema.GetValue("EsquemaId"))
        vcVendedor.VendedorEsquema.TipoEstado = grVendedorEsquema.GetValue("TipoEstado")
        vcVendedor.VendedorEsquema.MUsuarioID = vcUsuarioID
        Try
            vcVendedor.VendedorEsquema.Insertar(New String() {"EsquemaId", "TipoEstado", "MUsuarioId"})
        Catch ex As LbControlError.cError
            ex.Mostrar()
            grVendedorEsquema.Col = 1
            e.Cancel = True
        End Try
        vcEsquemaId = lbGeneral.ChkDbNull(grVendedorEsquema.GetValue("EsquemaId"))
    End Sub

    Private Sub grVendedorEsquema_FirstChange(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles grVendedorEsquema.FirstChange
        vcHuboCambios = True
        If (grVendedorEsquema.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
            btVEEEliminar.Enabled = True
            btVEECrear.Enabled = True
            If IsNothing(grVendedorEsquema.CurrentColumn) = False Then
                If grVendedorEsquema.CurrentColumn.Key <> "TipoEstado" Then
                    grVendedorEsquema.GetRow.Cells("TipoEstado").Value = 1
                End If
            End If
        End If
    End Sub

    Private Sub grVendedorEsquema_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grVendedorEsquema.Leave
        Call DeshabilitaCrear(grVendedorEsquema)
    End Sub

    Private Sub grVendedorEsquema_RecordAdded(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grVendedorEsquema.RecordAdded
        If (grVendedorEsquema.Focused = False) Then
            Call DeshabilitaCrear(grVendedorEsquema)
        End If
    End Sub

    Private Sub grVendedorEsquema_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grVendedorEsquema.SelectionChanged
        With grVendedorEsquema
            Select Case (vcModo)
                Case eModo.Crear
                    .RootTable.Columns("Clave").EditType = Janus.Windows.GridEX.EditType.TextBox
                Case eModo.Modificar
                    If Not (.GetRow Is Nothing) Then
                        If (.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                            .RootTable.Columns("Clave").EditType = Janus.Windows.GridEX.EditType.TextBox
                        Else
                            If .GetRow.DataRow.Row.RowState = DataRowState.Added Then
                                .RootTable.Columns("Clave").EditType = Janus.Windows.GridEX.EditType.TextBox
                            Else
                                .RootTable.Columns("Clave").EditType = Janus.Windows.GridEX.EditType.NoEdit
                            End If
                        End If
                    End If
            End Select
        End With

        If grVendedorEsquema.RowCount > 0 AndAlso Not grVendedorEsquema.GetRow Is Nothing AndAlso (vcModo = eModo.Crear Or vcModo = eModo.Modificar) Then
            If (grVendedorEsquema.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                btVEEEliminar.Enabled = False
            Else
                If grVendedorEsquema.GetRow.DataRow.Row.RowState = DataRowState.Added And cbEstado.SelectedValue = 1 Then
                    btVEEEliminar.Enabled = True
                Else
                    btVEEEliminar.Enabled = False
                End If
            End If
        Else
            btVEEEliminar.Enabled = False
        End If
        vcEsquemaId = lbGeneral.ChkDbNull(grVendedorEsquema.GetValue("EsquemaId"))
    End Sub

    Private Sub ObtenerEsquema(ByVal pvClave As String)
        Dim vlDataTable As New DataTable

        If IsNothing(pvClave) = True Then
            grVendedorEsquema.GetRow.Cells("EsquemaId").Value = ""
            grVendedorEsquema.GetRow.Cells("Nombre").Value = ""
            Exit Sub
        End If

        vlDataTable = vcEsquema.Tabla.RecuperarTabla("Clave='" + pvClave.Replace("'", "''") + "' AND Tipo=1")
        If vlDataTable.Rows.Count = 0 Then
            Throw New LbControlError.cError("E0013")
        End If
        If vlDataTable.Rows(0)!TipoEstado = 0 Or vlDataTable.Rows(0)!baja = 1 Then
            Throw New LbControlError.cError("E0367", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("XEsquema", True)})
        End If
        grVendedorEsquema.GetRow.Cells("EsquemaId").Value = vlDataTable.Rows(0)!EsquemaId
        grVendedorEsquema.GetRow.Cells("Nombre").Value = vlDataTable.Rows(0)!Nombre
    End Sub

    Private Sub grVendedorEsquema_UpdatingCell(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs) Handles grVendedorEsquema.UpdatingCell
        If e.Column.Key = "Clave" Then
            If IsNothing(e.Value) Or IsDBNull(e.Value) Then
                e.Value = ""
            End If
            If e.Value = "" Then
                grVendedorEsquema.GetRow.Cells("EsquemaId").Value = ""
                grVendedorEsquema.GetRow.Cells("Nombre").Value = ""
                Exit Sub
            End If
            If IsNothing(e.InitialValue) = False Then
                If LCase(e.Value) = LCase(e.InitialValue) Then
                    Exit Sub
                End If
            End If
            For Each vlDataRow As Janus.Windows.GridEX.GridEXRow In grVendedorEsquema.GetRows
                If LCase(vlDataRow.Cells("Clave").Value) = LCase(e.Value) Then
                    MsgBox(vcMensaje.RecuperarDescripcion("BE0002"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                    e.Cancel = True
                    e.Value = e.InitialValue
                    Exit Sub
                End If
            Next
            Try
                ObtenerEsquema(e.Value)
            Catch ex As LbControlError.cError
                ex.Mostrar()
                e.Cancel = True
                e.Value = e.InitialValue
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub grVendedorEsquema_UpdatingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grVendedorEsquema.UpdatingRecord
        Call LlenarNulos(grVendedorEsquema)

        If grVendedorEsquema.GetValue("EsquemaId") = "" Then
            MsgBox(vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion("ESQClave")}), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
            e.Cancel = True
            Exit Sub
        End If
        vcVendedor.VendedorEsquema(vcEsquemaId).EsquemaId = grVendedorEsquema.GetValue("EsquemaId")
        vcVendedor.VendedorEsquema(grVendedorEsquema.GetValue("EsquemaId")).TipoEstado = grVendedorEsquema.GetValue("TipoEstado")
        vcVendedor.VendedorEsquema(grVendedorEsquema.GetValue("EsquemaId")).MUsuarioID = vcUsuarioID
        Try
            vcVendedor.VendedorEsquema(grVendedorEsquema.GetValue("EsquemaId")).ValidarCampos(New String() {"EsquemaId", "TipoEstado", "MUsuarioId"})
        Catch ex As LbControlError.cError
            ex.Mostrar()
            grVendedorEsquema.Col = 0
            e.Cancel = True
        End Try
        vcEsquemaId = lbGeneral.ChkDbNull(grVendedorEsquema.GetValue("EsquemaId"))
    End Sub

    Private Sub grVendedorEsquema_CancelingRowEdit(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionCancelEventArgs) Handles grVendedorEsquema.CancelingRowEdit
        e.Cancel = True
    End Sub

#End Region

#Region "Aceptar y Cancelar"
    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click

        If vcModo = eModo.Crear Or vcModo = eModo.Modificar Then

            '--Fix primero validar que tenga interfases de tipo TXT
            Dim oTieneInterfaz As Boolean = vcConexion.EjecutarComandoScalar("select Top 1 InterfazTXT from CONHIST Order by MFechaHora desc")

            If (oTieneInterfaz Or txtruta.Text.Length > 0) Then

                Try

                    If IO.Directory.Exists(txtruta.Text) = True Then
                    Else

                        Throw New LbControlError.cError("E0428")
                    End If

                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    Exit Sub
                End Try

            End If

            Me.DialogResult = Windows.Forms.DialogResult.None

            If Me.cbTipo.SelectedValue = 1 Then 'Vendedor Tipo terminal
                Try
                    If Me.ebConfiguracion.Text = "" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(Me.lbModulo.Text)}, "MCNClave")
                    End If
                    If Me.ebTerminal.Text = "" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(Me.lbTerminal.Text)}, "TerminalClave")
                    End If
                    If cbAlmacenId.SelectedValue = "" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(Me.lbAlmacen.Text)}, "AlmacenId")
                    End If
                    If Me.cbTipoModImp.SelectedValue = "" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(Me.lbTipoModImp.Text)}, "TipoModImp")
                    End If
                Catch ex As LbControlError.cError
                    PonerFoco(ex.Source)
                    ex.Mostrar()
                    Exit Sub
                End Try
            End If

            Try
                Call ValidaUsuario()
            Catch ex As LbControlError.cError
                ebUsuario.Focus()
                ex.Mostrar()
                Exit Sub
            End Try

            Try
                Call ValidaTerminal()
            Catch ex As LbControlError.cError
                ebTerminal.Focus()
                ex.Mostrar()
                Exit Sub
            End Try

            Try
                Call ValidaConfiguracion()
            Catch ex As LbControlError.cError
                ebConfiguracion.Focus()
                ex.Mostrar()
                Exit Sub
            End Try

            Select Case vcModo
                Case eModo.Crear
                    Try
                        vcVendedor.Insertar(Me.EbClave.Text, Me.ebNombre.Text, ebConfiguracion.Text, Me.cbAlmacenId.SelectedValue, Me.cbCaptura.SelectedValue, Me.cbNivelExp.SelectedValue, Me.ebLimiteDesc.Value, Me.cbEstado.SelectedValue, Me.ebUsuarioId.Text, Me.ebTerminal.Text, Me.chBaja.Checked, vcUsuarioID, Me.chActualizar.Checked, Me.chCapturar.Checked, txtruta.Text, chbMostrarEsquema.Checked, Me.chbJornadaTrabajo.Checked, Me.chbCapturaFolioFac.Checked, Me.chMostrarCuota.Checked, Me.chMantenerPrm.Checked, Me.cbTipoModImp.SelectedValue, Me.chbDatosFiscales.Checked, chKilometraje.Checked, Me.cbTipo.SelectedValue)
                    Catch ex As LbControlError.cError
                        ex.Mostrar()
                        PonerFoco(ex.Source)
                        Exit Sub
                    End Try

                    If Not cbVCHAlmacenId.SelectedValue Is Nothing Then
                        'MsgBox(vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion("VCHAlmacenId")}), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                        'cbVCHAlmacenId.Focus()
                        'Exit Sub
                        vcVendedor.VENCentroDistHist.Insertar(cbVCHAlmacenId.SelectedValue, vcConexion.ObtenerFecha.Date, vcConexion.ObtenerFecha.Date.AddYears(7000), New String() {"AlmacenId", "VCHFechaInicial", "FechaFinal"})
                    End If

                Case eModo.Modificar
                    '*************************************
                    'Dim vcVendedorActual As New cVendedor
                    'vcVendedorActual.Recuperar(vcVendedor.VendedorID)
                    'If vcVendedor.TipoEstado = 0 And vcVendedorActual.TipoEstado = 1 Then
                    'Dim vcTerminal As New cTerminal
                    'vcTerminal.Recuperar(vcVendedor.TerminalClave)
                    'vcterminal.TipoFase = 1
                    'vcterminal.Grabar()
                    'End If
                    '***************************************
                    Try
                        If vcTipoEstadoOriginal = 0 And cbEstado.SelectedValue = 1 Then
                            'Validar que el centro de distribución asignado se encuentre activo
                            Dim loAlmacen As New ERMALMLOG.cAlmacen
                            Dim ldt As DataTable
                            ldt = loAlmacen.Tabla.Recuperar("AlmacenId='" & cbVCHAlmacenId.SelectedValue & "' AND TipoEstado=1")
                            If ldt.Rows.Count = 0 Then
                                MsgBox(vcMensaje.RecuperarDescripcion("E0501"), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                                Exit Sub
                            End If
                        ElseIf vcTipoEstadoOriginal = 1 And cbEstado.SelectedValue = 0 Then
                            'Validar que no tenga cargas activas asignadas
                            If CargasPorTransferir(vcVendedor) Then
                                MsgBox(vcMensaje.RecuperarDescripcion("E0527", New String() {lbEstado.Text}), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                                cbEstado.Focus()
                                Exit Sub
                            End If
                        End If

                        If CargasPorTransferir(vcVendedor, cbVCHAlmacenId.SelectedValue) Then
                            MsgBox(vcMensaje.RecuperarDescripcion("E0527", New String() {lbVCHALMNombre.Text}), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                            cbAlmacenId.Focus()
                            Exit Sub
                        End If

                        With vcVendedor
                            .TipoEstado = cbEstado.SelectedValue
                            .Nombre = ebNombre.Text
                            .tipo = cbTipo.SelectedValue
                            .MCNClave = ebConfiguracion.Text
                            .TipoCapturaProductos = cbCaptura.SelectedValue
                            .Nivel = cbNivelExp.SelectedValue
                            .LimiteDescuento = ebLimiteDesc.Value
                            .USUId = ebUsuarioId.Text
                            .TerminalClave = ebTerminal.Text
                            .Baja = chBaja.Checked
                            .ActualizaEsquema = chActualizar.Checked
                            .CapturaPrecio = chCapturar.Checked
                            .AlmacenId = cbAlmacenId.SelectedValue
                            .TipoModImp = cbTipoModImp.SelectedValue
                            .DirInterfazSalida = txtruta.Text
                            .MostrarEsquema = Me.chbMostrarEsquema.Checked
                            .MostrarCuota = Me.chMostrarCuota.Checked
                            .JornadaTrabajo = Me.chbJornadaTrabajo.Checked
                            .CapturaFolioFac = Me.chbCapturaFolioFac.Checked
                            .MantenerPrm = Me.chMantenerPrm.Checked
                            .EditarDatosFiscal = Me.chbDatosFiscales.Checked
                            .Kilometraje = Me.chKilometraje.Checked
                        End With
                        vcVendedor.MUsuarioID = vcUsuarioID
                        vcVendedor.ValidarCampos()
                    Catch ex As LbControlError.cError
                        ex.Mostrar()
                        PonerFoco(ex.Source)
                        Exit Sub
                    End Try

                    If vcVendedor.VENCentroDistHist.Conteo > 0 Then
                        If vcVendedor.VENCentroDistHist(vcVendedor.VENCentroDistHist.Conteo - 1).VCHFechaInicial = cbVCHFechaInicial.Value And vcVendedor.VENCentroDistHist(vcVendedor.VENCentroDistHist.Conteo - 1).AlmacenId <> cbVCHAlmacenId.SelectedValue Then
                            vcVendedor.VENCentroDistHist(vcVendedor.VENCentroDistHist.Conteo - 1).Eliminar()
                            vcVendedor.VENCentroDistHist.Insertar(cbVCHAlmacenId.SelectedValue, vcConexion.ObtenerFecha.Date, New Date(9999, 12, 31), New String() {"AlmacenId", "VCHFechaInicial", "FechaFinal"})
                        ElseIf vcVendedor.VENCentroDistHist(vcVendedor.VENCentroDistHist.Conteo - 1).VCHFechaInicial <> cbVCHFechaInicial.Value And vcVendedor.VENCentroDistHist(vcVendedor.VENCentroDistHist.Conteo - 1).AlmacenId <> cbVCHAlmacenId.SelectedValue Then
                            vcVendedor.VENCentroDistHist(vcVendedor.VENCentroDistHist.Conteo - 1).FechaFinal = vcConexion.ObtenerFecha.Date.AddDays(-1)
                            vcVendedor.VENCentroDistHist.Insertar(cbVCHAlmacenId.SelectedValue, vcConexion.ObtenerFecha.Date, New Date(9999, 12, 31), New String() {"AlmacenId", "VCHFechaInicial", "FechaFinal"})
                        End If
                    Else
                        If Not cbVCHAlmacenId.SelectedValue Is Nothing Then
                            'MsgBox(vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion("VCHAlmacenId")}), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("XMensajeE"))
                            'cbVCHAlmacenId.Focus()
                            'Exit Sub
                            vcVendedor.VENCentroDistHist.Insertar(cbVCHAlmacenId.SelectedValue, vcConexion.ObtenerFecha.Date, New Date(9999, 12, 31), New String() {"AlmacenId", "VCHFechaInicial", "FechaFinal"})
                        End If
                    End If
            End Select
        ElseIf vcModo = eModo.Eliminar Then
            Dim vcTerminal As New cTerminal
            If vcVendedor.TieneFoliosAsignados Then
                MsgBox(vcMensaje.RecuperarDescripcion("I0171"), MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, vcMensaje.RecuperarDescripcion("XMensajeI"))
            End If
            If vcTerminal.Recuperar(ebTerminal.Text) Then
                If vcTerminal.TipoFase = 3 Then 'Activo
                    vcTerminal.TipoFase = 1
                    vcTerminal.Grabar()
                End If
            End If
            vcVendedor.Baja = True
            Me.cbEstado.SelectedIndex = 0
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        vcCerrar = True
        Me.Close()
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        Me.Close()
    End Sub

    Private Sub MGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not vcCerrar And vcHuboCambios And vcModo <> eModo.Leer Then

            Me.DialogResult = Windows.Forms.DialogResult.None

            If MsgBox(vcMensaje.RecuperarDescripcion("BP0001"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, vcMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Else
                e.Cancel = False
            End If
        End If
    End Sub

#End Region

    Private Sub btRuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRuta.Click
        If buscacarpetas.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If buscacarpetas.SelectedPath.Length > 199 Then
                MsgBox(vcMensaje.RecuperarDescripcion("E0632"), MsgBoxStyle.Critical)
                Exit Sub
            End If
            If IO.Directory.Exists(buscacarpetas.SelectedPath) = True Then
                txtruta.Text = buscacarpetas.SelectedPath
            Else
                Try
                    Throw New LbControlError.cError("E0428")
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                End Try
            End If
        End If
    End Sub

    Private Sub cbVCHAlmacenId_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVCHAlmacenId.SelectedValueChanged
        If vcCargando Then Exit Sub
        If vcModo = eModo.Modificar And vcVendedor.VENCentroDistHist.Conteo > 0 Then
            If vcVendedor.VENCentroDistHist(vcVendedor.VENCentroDistHist.Conteo - 1).VCHFechaInicial = vcConexion.ObtenerFecha.Date And vcVendedor.VENCentroDistHist(vcVendedor.VENCentroDistHist.Conteo - 1).AlmacenId <> cbVCHAlmacenId.SelectedValue Then
                vcAlmacen.Recuperar(vcVendedor.VENCentroDistHist(vcVendedor.VENCentroDistHist.Conteo - 1).AlmacenId)
                If MsgBox(vcMensaje.RecuperarDescripcion("P0072", New String() {vcAlmacen.Nombre}), MsgBoxStyle.Question + MsgBoxStyle.YesNo, vcMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.No Then
                    cbVCHAlmacenId.SelectedValue = vcVendedor.VENCentroDistHist(vcVendedor.VENCentroDistHist.Conteo - 1).AlmacenId
                End If
            End If
            Call ValidarCampos(cbEstado, New System.EventArgs)
        End If
        cbVCHFechaInicial.Value = vcConexion.ObtenerFecha.Date
    End Sub

    Private Sub cbVCHAlmacenId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVCHAlmacenId.Validated
        If cbVCHAlmacenId.SelectedValue = Nothing Then
            epErrores.SetError(cbVCHAlmacenId, vcMensaje.RecuperarDescripcion("BE0001", New String() {vcMensaje.RecuperarDescripcion("VCHAlmacenId")}))
        Else
            'Validar que no tenga cargas activas asignadas
            If CargasPorTransferir(vcVendedor, cbVCHAlmacenId.SelectedValue) Then
                epErrores.SetError(cbVCHAlmacenId, vcMensaje.RecuperarDescripcion("E0527", New String() {lbVCHALMNombre.Text}))
                Exit Sub
            End If
            epErrores.SetError(cbVCHAlmacenId, "")
        End If
    End Sub

    Private Sub btHistorico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btHistorico.Click
        Dim oHistorico As New DHistorico
        oHistorico.CONSULTAR(vcVendedor)
    End Sub

    Private Sub tpGeneral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub MGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabControl1.SelectedTab = tabGeneral
    End Sub

    Private Sub txtruta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtruta.Click

    End Sub

    Private Sub cbEstado_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cbEstado.Validating
        If vcModo = eModo.Modificar And cbEstado.SelectedValue = 0 Then
            If vcVendedor.TieneFoliosAsignados Then
                If MsgBox(vcMensaje.RecuperarDescripcion("P0114"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, vcMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                    MsgBox(vcMensaje.RecuperarDescripcion("I0171"), MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, vcMensaje.RecuperarDescripcion("XMensajeI"))
                Else
                    e.Cancel = True
                End If
            End If
        End If

    End Sub

    Private Sub MGeneral_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If vcModo = eModo.Leer Then
            BtCancelar.Focus()

        End If
    End Sub

    Private Sub TabControl1_SelectedTabChanging(ByVal sender As System.Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControl1.SelectedTabChanging
        'If grVendedorDescuento.EditMode = Janus.Windows.GridEX.EditMode.EditOn OrElse 
        If grVendedorEsquema.EditMode = Janus.Windows.GridEX.EditMode.EditOn _
        OrElse grJornadas.EditMode = Janus.Windows.GridEX.EditMode.EditOn Then
            e.Cancel = True
        End If
    End Sub

    Private Sub btConfiguracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btConfiguracion.Click
        Using frmBusca As New ERMMOTESC.IConfiguracion(False)
            If frmBusca.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If frmBusca.Seleccion.Count > 0 Then
                    ebConfiguracion.Text = frmBusca.Seleccion(0).MCNClave
                End If
            End If
        End Using
    End Sub
End Class
