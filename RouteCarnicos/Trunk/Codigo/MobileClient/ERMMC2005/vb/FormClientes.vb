Imports System.Data.SqlServerCe
#If SO_WCE = 0 Then
Imports Microsoft.WindowsMobile.Samples.Location
#End If

Public Class FormClientes
    Inherits System.Windows.Forms.Form
#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        'TODO: Se quito el codigo del menu contextual porque el Eliminar estaba incorrecto
        'If g_SO = SO.WindowsCE Then
        '    Call InTheHand.Windows.Forms.ContextMenuHelper.HookAllControls(Me.Controls)
        'End If

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        FlexGridClientes.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)

        Me.ClienteActual = New Cliente

        Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not IsNothing(FlexGridClientes) Then
            FlexGridClientes.Dispose()
            FlexGridClientes = Nothing
        End If

        ClienteActual = Nothing

        If Not IsNothing(Me.MenuItemCuotas) Then MenuItemCuotas.Dispose()
        If Not IsNothing(Me.MenuItemPromocion) Then MenuItemPromocion.Dispose()
        If Not IsNothing(Me.MenuItemListasPrecios) Then MenuItemListasPrecios.Dispose()
        If Not IsNothing(Me.MenuItemMasInfo) Then MenuItemMasInfo.Dispose()
        If Not IsNothing(Me.MenuItemEliminar) Then MenuItemEliminar.Dispose()
        If Not IsNothing(Me.MenuItemRegresar) Then MenuItemRegresar.Dispose()
        If Not IsNothing(Me.MenuItemVerFueraFrecuencia) Then MenuItemVerFueraFrecuencia.Dispose()
        If Not IsNothing(Me.MenuItemVerNoVisitados) Then MenuItemVerNoVisitados.Dispose()
        If Not IsNothing(Me.MenuItemVerTodos) Then MenuItemVerTodos.Dispose()
        If Not IsNothing(Me.MenuItemVerVisitados) Then MenuItemVerVisitados.Dispose()
        If Not IsNothing(Me.MenuItemVer) Then MenuItemVer.Dispose()
        If Not IsNothing(Me.MainMenuAgenda) Then MainMenuAgenda.Dispose()
        If Not IsNothing(Me.ContextMenuClientes) Then ContextMenuClientes.Dispose()
        If Not IsNothing(Me.ContextMenu1) Then ContextMenu1.Dispose()
        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
            If Not IsNothing(Me.MenuItemVerPorSurtir) Then
                RemoveHandler MenuItemVerPorSurtir.Click, AddressOf MenuItemVerPorSurtir_Click
                MenuItemVerPorSurtir.Dispose()
            End If
        End If
#If MOD_TERM <> "PALM" Then
        If Not bScanner Is Nothing Then bScanner.Dispose()
        bScanner = Nothing
#End If
#If SO_WCE = 0 Then
        If Not IsNothing(Me.oGPS) Then oGPS = Nothing
#End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents MainMenuAgenda As System.Windows.Forms.MainMenu
    Friend WithEvents InputPanelAgenda As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemVer As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemVerVisitados As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemVerNoVisitados As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemVerTodos As System.Windows.Forms.MenuItem
    Friend WithEvents ContextMenuClientes As System.Windows.Forms.ContextMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PanelContrasena As System.Windows.Forms.Panel
    Friend WithEvents LabelContrasena As System.Windows.Forms.Label
    Friend WithEvents ButtonCancelarContrasena As System.Windows.Forms.Button
    Friend WithEvents ButtonAceptarContrasena As System.Windows.Forms.Button
    Friend WithEvents textContrasena As System.Windows.Forms.TextBox
    Friend WithEvents txtPatron As System.Windows.Forms.TextBox
    Friend WithEvents pbBateria As System.Windows.Forms.PictureBox
    Friend WithEvents LabelBateria As System.Windows.Forms.Label
    Friend WithEvents txtNoCliente As System.Windows.Forms.TextBox
    Friend WithEvents PanelTitulo As System.Windows.Forms.Panel
    Friend WithEvents LabelEstadoAgenda As System.Windows.Forms.Label
    Friend WithEvents LabelNombreAgenda As System.Windows.Forms.Label
    Friend WithEvents LabelAgenda As System.Windows.Forms.Label
    Friend WithEvents LabelReferencia As System.Windows.Forms.Label
    Friend WithEvents ButtonAgendaNuevo As System.Windows.Forms.Button
    Friend WithEvents ButtonAgendaContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonAgendaRegresar As System.Windows.Forms.Button
    Friend WithEvents FlexGridClientes As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LabelTiempo As System.Windows.Forms.Label
    Friend WithEvents MenuItemMasInfo As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemCuotas As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemPromocion As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemListasPrecios As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemVerFueraFrecuencia As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemEnvio As System.Windows.Forms.MenuItem
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents TimerGPS As System.Windows.Forms.Timer
    Friend WithEvents ButtonFiltrarClientes As System.Windows.Forms.Button
    Friend WithEvents PanelBusquedaCli As System.Windows.Forms.Panel
    Friend WithEvents TextBoxReferenciaDom As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxReferenciaDom As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxReferenciaDom As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonContinuarBusqueda As System.Windows.Forms.Button
    Friend WithEvents TextBoxCalle As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxCalle As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxCalle As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxContacto As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxContacto As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxContacto As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxRazonSocial As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxRazonSocial As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxIdActivo As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxIdActivo As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxIdActivo As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonGPS As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents CheckBoxColonia As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxInterior As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBoxColonia As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxExterior As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBoxInterior As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxExterior As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxColonia As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxInterior As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxExterior As System.Windows.Forms.TextBox
    Friend WithEvents MenuItemVerFiltro As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemEliminar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormClientes))
        Me.ContextMenuClientes = New System.Windows.Forms.ContextMenu
        Me.MenuItemEliminar = New System.Windows.Forms.MenuItem
        Me.MainMenuAgenda = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.MenuItemVer = New System.Windows.Forms.MenuItem
        Me.MenuItemVerVisitados = New System.Windows.Forms.MenuItem
        Me.MenuItemVerNoVisitados = New System.Windows.Forms.MenuItem
        Me.MenuItemVerFueraFrecuencia = New System.Windows.Forms.MenuItem
        Me.MenuItemVerTodos = New System.Windows.Forms.MenuItem
        Me.MenuItemVerFiltro = New System.Windows.Forms.MenuItem
        Me.MenuItemMasInfo = New System.Windows.Forms.MenuItem
        Me.MenuItemCuotas = New System.Windows.Forms.MenuItem
        Me.MenuItemPromocion = New System.Windows.Forms.MenuItem
        Me.MenuItemListasPrecios = New System.Windows.Forms.MenuItem
        Me.MenuItemEnvio = New System.Windows.Forms.MenuItem
        Me.InputPanelAgenda = New Microsoft.WindowsCE.Forms.InputPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonGPS = New System.Windows.Forms.Button
        Me.ButtonFiltrarClientes = New System.Windows.Forms.Button
        Me.PanelTitulo = New System.Windows.Forms.Panel
        Me.LabelEstadoAgenda = New System.Windows.Forms.Label
        Me.LabelNombreAgenda = New System.Windows.Forms.Label
        Me.txtPatron = New System.Windows.Forms.TextBox
        Me.pbBateria = New System.Windows.Forms.PictureBox
        Me.LabelBateria = New System.Windows.Forms.Label
        Me.txtNoCliente = New System.Windows.Forms.TextBox
        Me.LabelAgenda = New System.Windows.Forms.Label
        Me.LabelReferencia = New System.Windows.Forms.Label
        Me.ButtonAgendaNuevo = New System.Windows.Forms.Button
        Me.ButtonAgendaContinuar = New System.Windows.Forms.Button
        Me.ButtonAgendaRegresar = New System.Windows.Forms.Button
        Me.FlexGridClientes = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.LabelTiempo = New System.Windows.Forms.Label
        Me.PanelContrasena = New System.Windows.Forms.Panel
        Me.ButtonCancelarContrasena = New System.Windows.Forms.Button
        Me.ButtonAceptarContrasena = New System.Windows.Forms.Button
        Me.textContrasena = New System.Windows.Forms.TextBox
        Me.LabelContrasena = New System.Windows.Forms.Label
        Me.TimerGPS = New System.Windows.Forms.Timer
        Me.PanelBusquedaCli = New System.Windows.Forms.Panel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.ComboBoxRazonSocial = New System.Windows.Forms.ComboBox
        Me.CheckBoxColonia = New System.Windows.Forms.CheckBox
        Me.ComboBoxColonia = New System.Windows.Forms.ComboBox
        Me.TextBoxColonia = New System.Windows.Forms.TextBox
        Me.CheckBoxExterior = New System.Windows.Forms.CheckBox
        Me.ComboBoxExterior = New System.Windows.Forms.ComboBox
        Me.TextBoxExterior = New System.Windows.Forms.TextBox
        Me.CheckBoxCalle = New System.Windows.Forms.CheckBox
        Me.ComboBoxCalle = New System.Windows.Forms.ComboBox
        Me.TextBoxCalle = New System.Windows.Forms.TextBox
        Me.TextBoxIdActivo = New System.Windows.Forms.TextBox
        Me.CheckBoxIdActivo = New System.Windows.Forms.CheckBox
        Me.ComboBoxIdActivo = New System.Windows.Forms.ComboBox
        Me.CheckBoxRazonSocial = New System.Windows.Forms.CheckBox
        Me.TextBoxRazonSocial = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.CheckBoxContacto = New System.Windows.Forms.CheckBox
        Me.ComboBoxContacto = New System.Windows.Forms.ComboBox
        Me.TextBoxContacto = New System.Windows.Forms.TextBox
        Me.CheckBoxInterior = New System.Windows.Forms.CheckBox
        Me.ComboBoxInterior = New System.Windows.Forms.ComboBox
        Me.TextBoxReferenciaDom = New System.Windows.Forms.TextBox
        Me.TextBoxInterior = New System.Windows.Forms.TextBox
        Me.ComboBoxReferenciaDom = New System.Windows.Forms.ComboBox
        Me.CheckBoxReferenciaDom = New System.Windows.Forms.CheckBox
        Me.ButtonContinuarBusqueda = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.PanelTitulo.SuspendLayout()
        Me.PanelContrasena.SuspendLayout()
        Me.PanelBusquedaCli.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuClientes
        '
        Me.ContextMenuClientes.MenuItems.Add(Me.MenuItemEliminar)
        '
        'MenuItemEliminar
        '
        Me.MenuItemEliminar.Text = "MenuItemEliminar"
        '
        'MainMenuAgenda
        '
        Me.MainMenuAgenda.MenuItems.Add(Me.MenuItemRegresar)
        Me.MainMenuAgenda.MenuItems.Add(Me.MenuItemVer)
        Me.MainMenuAgenda.MenuItems.Add(Me.MenuItemMasInfo)
        Me.MainMenuAgenda.MenuItems.Add(Me.MenuItemEnvio)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'MenuItemVer
        '
        Me.MenuItemVer.MenuItems.Add(Me.MenuItemVerVisitados)
        Me.MenuItemVer.MenuItems.Add(Me.MenuItemVerNoVisitados)
        Me.MenuItemVer.MenuItems.Add(Me.MenuItemVerFueraFrecuencia)
        Me.MenuItemVer.MenuItems.Add(Me.MenuItemVerTodos)
        Me.MenuItemVer.MenuItems.Add(Me.MenuItemVerFiltro)
        Me.MenuItemVer.Text = "MenuItemVer"
        '
        'MenuItemVerVisitados
        '
        Me.MenuItemVerVisitados.Text = "MenuItemVerVisitados"
        '
        'MenuItemVerNoVisitados
        '
        Me.MenuItemVerNoVisitados.Text = "MenuItemVerNoVisitados"
        '
        'MenuItemVerFueraFrecuencia
        '
        Me.MenuItemVerFueraFrecuencia.Text = "MenuItemVerFueraFrecuencia"
        '
        'MenuItemVerTodos
        '
        Me.MenuItemVerTodos.Text = "MenuItemVerTodos"
        '
        'MenuItemVerFiltro
        '
        Me.MenuItemVerFiltro.Text = "MenuItemVerFiltro"
        '
        'MenuItemMasInfo
        '
        Me.MenuItemMasInfo.MenuItems.Add(Me.MenuItemCuotas)
        Me.MenuItemMasInfo.MenuItems.Add(Me.MenuItemPromocion)
        Me.MenuItemMasInfo.MenuItems.Add(Me.MenuItemListasPrecios)
        Me.MenuItemMasInfo.Text = "MenuItemMasInfo"
        '
        'MenuItemCuotas
        '
        Me.MenuItemCuotas.Text = "MenuItemCuotas"
        '
        'MenuItemPromocion
        '
        Me.MenuItemPromocion.Text = "MenuItemPromocion"
        '
        'MenuItemListasPrecios
        '
        Me.MenuItemListasPrecios.Text = "MenuItemListasPrecios"
        '
        'MenuItemEnvio
        '
        Me.MenuItemEnvio.Text = "MenuItemEnvio"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonGPS)
        Me.Panel1.Controls.Add(Me.ButtonFiltrarClientes)
        Me.Panel1.Controls.Add(Me.PanelTitulo)
        Me.Panel1.Controls.Add(Me.txtPatron)
        Me.Panel1.Controls.Add(Me.pbBateria)
        Me.Panel1.Controls.Add(Me.LabelBateria)
        Me.Panel1.Controls.Add(Me.txtNoCliente)
        Me.Panel1.Controls.Add(Me.LabelAgenda)
        Me.Panel1.Controls.Add(Me.LabelReferencia)
        Me.Panel1.Controls.Add(Me.ButtonAgendaNuevo)
        Me.Panel1.Controls.Add(Me.ButtonAgendaContinuar)
        Me.Panel1.Controls.Add(Me.ButtonAgendaRegresar)
        Me.Panel1.Controls.Add(Me.FlexGridClientes)
        Me.Panel1.Controls.Add(Me.LabelTiempo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonGPS
        '
        Me.ButtonGPS.Location = New System.Drawing.Point(202, 54)
        Me.ButtonGPS.Name = "ButtonGPS"
        Me.ButtonGPS.Size = New System.Drawing.Size(31, 24)
        Me.ButtonGPS.TabIndex = 38
        Me.ButtonGPS.Text = "ButtonGPS"
        '
        'ButtonFiltrarClientes
        '
        Me.ButtonFiltrarClientes.Location = New System.Drawing.Point(202, 239)
        Me.ButtonFiltrarClientes.Name = "ButtonFiltrarClientes"
        Me.ButtonFiltrarClientes.Size = New System.Drawing.Size(31, 24)
        Me.ButtonFiltrarClientes.TabIndex = 31
        Me.ButtonFiltrarClientes.Text = "..."
        '
        'PanelTitulo
        '
        Me.PanelTitulo.BackColor = System.Drawing.Color.DarkBlue
        Me.PanelTitulo.Controls.Add(Me.LabelEstadoAgenda)
        Me.PanelTitulo.Controls.Add(Me.LabelNombreAgenda)
        Me.PanelTitulo.Location = New System.Drawing.Point(5, 4)
        Me.PanelTitulo.Name = "PanelTitulo"
        Me.PanelTitulo.Size = New System.Drawing.Size(232, 18)
        '
        'LabelEstadoAgenda
        '
        Me.LabelEstadoAgenda.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Regular)
        Me.LabelEstadoAgenda.ForeColor = System.Drawing.Color.White
        Me.LabelEstadoAgenda.Location = New System.Drawing.Point(108, 0)
        Me.LabelEstadoAgenda.Name = "LabelEstadoAgenda"
        Me.LabelEstadoAgenda.Size = New System.Drawing.Size(120, 18)
        Me.LabelEstadoAgenda.Text = "LabelEstadoAgenda"
        Me.LabelEstadoAgenda.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelNombreAgenda
        '
        Me.LabelNombreAgenda.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelNombreAgenda.ForeColor = System.Drawing.Color.White
        Me.LabelNombreAgenda.Location = New System.Drawing.Point(0, 0)
        Me.LabelNombreAgenda.Name = "LabelNombreAgenda"
        Me.LabelNombreAgenda.Size = New System.Drawing.Size(104, 16)
        Me.LabelNombreAgenda.Text = "Preventa"
        '
        'txtPatron
        '
        Me.txtPatron.Enabled = False
        Me.txtPatron.Location = New System.Drawing.Point(4, 55)
        Me.txtPatron.Name = "txtPatron"
        Me.txtPatron.Size = New System.Drawing.Size(196, 23)
        Me.txtPatron.TabIndex = 25
        '
        'pbBateria
        '
        Me.pbBateria.Image = CType(resources.GetObject("pbBateria.Image"), System.Drawing.Image)
        Me.pbBateria.Location = New System.Drawing.Point(186, 37)
        Me.pbBateria.Name = "pbBateria"
        Me.pbBateria.Size = New System.Drawing.Size(18, 17)
        Me.pbBateria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'LabelBateria
        '
        Me.LabelBateria.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.LabelBateria.Location = New System.Drawing.Point(202, 38)
        Me.LabelBateria.Name = "LabelBateria"
        Me.LabelBateria.Size = New System.Drawing.Size(33, 16)
        Me.LabelBateria.Text = "100%"
        Me.LabelBateria.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtNoCliente
        '
        Me.txtNoCliente.AcceptsReturn = True
        Me.txtNoCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoCliente.Location = New System.Drawing.Point(4, 239)
        Me.txtNoCliente.Name = "txtNoCliente"
        Me.txtNoCliente.Size = New System.Drawing.Size(196, 23)
        Me.txtNoCliente.TabIndex = 24
        Me.txtNoCliente.TabStop = False
        '
        'LabelAgenda
        '
        Me.LabelAgenda.Location = New System.Drawing.Point(4, 38)
        Me.LabelAgenda.Name = "LabelAgenda"
        Me.LabelAgenda.Size = New System.Drawing.Size(177, 16)
        Me.LabelAgenda.Text = "LabelAgenda"
        '
        'LabelReferencia
        '
        Me.LabelReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelReferencia.ForeColor = System.Drawing.Color.Blue
        Me.LabelReferencia.Location = New System.Drawing.Point(4, 22)
        Me.LabelReferencia.Name = "LabelReferencia"
        Me.LabelReferencia.Size = New System.Drawing.Size(116, 16)
        Me.LabelReferencia.Text = "Pedidos del Martes"
        '
        'ButtonAgendaNuevo
        '
        Me.ButtonAgendaNuevo.Enabled = False
        Me.ButtonAgendaNuevo.Location = New System.Drawing.Point(160, 264)
        Me.ButtonAgendaNuevo.Name = "ButtonAgendaNuevo"
        Me.ButtonAgendaNuevo.Size = New System.Drawing.Size(72, 24)
        Me.ButtonAgendaNuevo.TabIndex = 22
        Me.ButtonAgendaNuevo.Text = "ButtonAgendaNuevo"
        '
        'ButtonAgendaContinuar
        '
        Me.ButtonAgendaContinuar.Enabled = False
        Me.ButtonAgendaContinuar.Location = New System.Drawing.Point(4, 264)
        Me.ButtonAgendaContinuar.Name = "ButtonAgendaContinuar"
        Me.ButtonAgendaContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonAgendaContinuar.TabIndex = 20
        Me.ButtonAgendaContinuar.Text = "ButtonAgendaContinuar"
        '
        'ButtonAgendaRegresar
        '
        Me.ButtonAgendaRegresar.Enabled = False
        Me.ButtonAgendaRegresar.Location = New System.Drawing.Point(82, 264)
        Me.ButtonAgendaRegresar.Name = "ButtonAgendaRegresar"
        Me.ButtonAgendaRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonAgendaRegresar.TabIndex = 21
        Me.ButtonAgendaRegresar.Text = "ButtonAgendaRegresar"
        '
        'FlexGridClientes
        '
        Me.FlexGridClientes.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FlexGridClientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlexGridClientes.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor
        Me.FlexGridClientes.AutoSearchDelay = 2
        Me.FlexGridClientes.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FlexGridClientes.ContextMenu = Me.ContextMenu1
        Me.FlexGridClientes.Font = New System.Drawing.Font("Tahoma", 9.0!, Drawing.FontStyle.Regular)
        Me.FlexGridClientes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.FlexGridClientes.Location = New System.Drawing.Point(4, 77)
        Me.FlexGridClientes.Name = "FlexGridClientes"
        Me.FlexGridClientes.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FlexGridClientes.Size = New System.Drawing.Size(227, 160)
        Me.FlexGridClientes.StyleInfo = resources.GetString("FlexGridClientes.StyleInfo")
        Me.FlexGridClientes.SupportInfo = "2QDZADcBsABfACYB2QCEAEYBlABJAFEBpwDjAJQAIgHiAB8BQwGPADwBzgBeAM4A0gBaAOoAQABMAB4BZ" & _
            "wANAVgASQCQAA=="
        Me.FlexGridClientes.TabIndex = 23
        '
        'LabelTiempo
        '
        Me.LabelTiempo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.LabelTiempo.ForeColor = System.Drawing.Color.Blue
        Me.LabelTiempo.Location = New System.Drawing.Point(123, 22)
        Me.LabelTiempo.Name = "LabelTiempo"
        Me.LabelTiempo.Size = New System.Drawing.Size(112, 16)
        Me.LabelTiempo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PanelContrasena
        '
        Me.PanelContrasena.Controls.Add(Me.ButtonCancelarContrasena)
        Me.PanelContrasena.Controls.Add(Me.ButtonAceptarContrasena)
        Me.PanelContrasena.Controls.Add(Me.textContrasena)
        Me.PanelContrasena.Controls.Add(Me.LabelContrasena)
        Me.PanelContrasena.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContrasena.Location = New System.Drawing.Point(0, 0)
        Me.PanelContrasena.Name = "PanelContrasena"
        Me.PanelContrasena.Size = New System.Drawing.Size(242, 295)
        Me.PanelContrasena.Visible = False
        '
        'ButtonCancelarContrasena
        '
        Me.ButtonCancelarContrasena.Location = New System.Drawing.Point(86, 224)
        Me.ButtonCancelarContrasena.Name = "ButtonCancelarContrasena"
        Me.ButtonCancelarContrasena.Size = New System.Drawing.Size(72, 24)
        Me.ButtonCancelarContrasena.TabIndex = 3
        Me.ButtonCancelarContrasena.Text = "ButtonCancelarContrasena"
        '
        'ButtonAceptarContrasena
        '
        Me.ButtonAceptarContrasena.Location = New System.Drawing.Point(8, 224)
        Me.ButtonAceptarContrasena.Name = "ButtonAceptarContrasena"
        Me.ButtonAceptarContrasena.Size = New System.Drawing.Size(72, 24)
        Me.ButtonAceptarContrasena.TabIndex = 2
        Me.ButtonAceptarContrasena.Text = "ButtonAceptarContrasena"
        '
        'textContrasena
        '
        Me.textContrasena.Location = New System.Drawing.Point(8, 45)
        Me.textContrasena.MaxLength = 40
        Me.textContrasena.Name = "textContrasena"
        Me.textContrasena.Size = New System.Drawing.Size(223, 23)
        Me.textContrasena.TabIndex = 1
        '
        'LabelContrasena
        '
        Me.LabelContrasena.Location = New System.Drawing.Point(8, 12)
        Me.LabelContrasena.Name = "LabelContrasena"
        Me.LabelContrasena.Size = New System.Drawing.Size(223, 20)
        Me.LabelContrasena.Text = "LabelContrasena"
        Me.LabelContrasena.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TimerGPS
        '
        '
        'PanelBusquedaCli
        '
        Me.PanelBusquedaCli.Controls.Add(Me.TabControl1)
        Me.PanelBusquedaCli.Controls.Add(Me.ButtonContinuarBusqueda)
        Me.PanelBusquedaCli.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBusquedaCli.Location = New System.Drawing.Point(0, 0)
        Me.PanelBusquedaCli.Name = "PanelBusquedaCli"
        Me.PanelBusquedaCli.Size = New System.Drawing.Size(242, 295)
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(242, 261)
        Me.TabControl1.TabIndex = 16
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.Controls.Add(Me.ComboBoxRazonSocial)
        Me.TabPage1.Controls.Add(Me.CheckBoxColonia)
        Me.TabPage1.Controls.Add(Me.ComboBoxColonia)
        Me.TabPage1.Controls.Add(Me.TextBoxColonia)
        Me.TabPage1.Controls.Add(Me.CheckBoxExterior)
        Me.TabPage1.Controls.Add(Me.ComboBoxExterior)
        Me.TabPage1.Controls.Add(Me.TextBoxExterior)
        Me.TabPage1.Controls.Add(Me.CheckBoxCalle)
        Me.TabPage1.Controls.Add(Me.ComboBoxCalle)
        Me.TabPage1.Controls.Add(Me.TextBoxCalle)
        Me.TabPage1.Controls.Add(Me.TextBoxIdActivo)
        Me.TabPage1.Controls.Add(Me.CheckBoxIdActivo)
        Me.TabPage1.Controls.Add(Me.ComboBoxIdActivo)
        Me.TabPage1.Controls.Add(Me.CheckBoxRazonSocial)
        Me.TabPage1.Controls.Add(Me.TextBoxRazonSocial)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(234, 232)
        Me.TabPage1.Text = "TabPage1"
        '
        'ComboBoxRazonSocial
        '
        Me.ComboBoxRazonSocial.Enabled = False
        Me.ComboBoxRazonSocial.Location = New System.Drawing.Point(102, 60)
        Me.ComboBoxRazonSocial.Name = "ComboBoxRazonSocial"
        Me.ComboBoxRazonSocial.Size = New System.Drawing.Size(84, 23)
        Me.ComboBoxRazonSocial.TabIndex = 4
        '
        'CheckBoxColonia
        '
        Me.CheckBoxColonia.Location = New System.Drawing.Point(4, 216)
        Me.CheckBoxColonia.Name = "CheckBoxColonia"
        Me.CheckBoxColonia.Size = New System.Drawing.Size(90, 20)
        Me.CheckBoxColonia.TabIndex = 20
        Me.CheckBoxColonia.Text = "CheckBoxColonia"
        '
        'ComboBoxColonia
        '
        Me.ComboBoxColonia.Enabled = False
        Me.ComboBoxColonia.Location = New System.Drawing.Point(101, 216)
        Me.ComboBoxColonia.Name = "ComboBoxColonia"
        Me.ComboBoxColonia.Size = New System.Drawing.Size(88, 23)
        Me.ComboBoxColonia.TabIndex = 19
        '
        'TextBoxColonia
        '
        Me.TextBoxColonia.Location = New System.Drawing.Point(101, 241)
        Me.TextBoxColonia.Name = "TextBoxColonia"
        Me.TextBoxColonia.Size = New System.Drawing.Size(115, 23)
        Me.TextBoxColonia.TabIndex = 18
        '
        'CheckBoxExterior
        '
        Me.CheckBoxExterior.Location = New System.Drawing.Point(4, 164)
        Me.CheckBoxExterior.Name = "CheckBoxExterior"
        Me.CheckBoxExterior.Size = New System.Drawing.Size(90, 20)
        Me.CheckBoxExterior.TabIndex = 17
        Me.CheckBoxExterior.Text = "CheckBoxExterior"
        '
        'ComboBoxExterior
        '
        Me.ComboBoxExterior.Enabled = False
        Me.ComboBoxExterior.Location = New System.Drawing.Point(102, 164)
        Me.ComboBoxExterior.Name = "ComboBoxExterior"
        Me.ComboBoxExterior.Size = New System.Drawing.Size(88, 23)
        Me.ComboBoxExterior.TabIndex = 16
        '
        'TextBoxExterior
        '
        Me.TextBoxExterior.Location = New System.Drawing.Point(102, 189)
        Me.TextBoxExterior.Name = "TextBoxExterior"
        Me.TextBoxExterior.Size = New System.Drawing.Size(115, 23)
        Me.TextBoxExterior.TabIndex = 15
        '
        'CheckBoxCalle
        '
        Me.CheckBoxCalle.Location = New System.Drawing.Point(4, 112)
        Me.CheckBoxCalle.Name = "CheckBoxCalle"
        Me.CheckBoxCalle.Size = New System.Drawing.Size(90, 20)
        Me.CheckBoxCalle.TabIndex = 14
        Me.CheckBoxCalle.Text = "CheckBoxCalle"
        '
        'ComboBoxCalle
        '
        Me.ComboBoxCalle.Enabled = False
        Me.ComboBoxCalle.Location = New System.Drawing.Point(102, 112)
        Me.ComboBoxCalle.Name = "ComboBoxCalle"
        Me.ComboBoxCalle.Size = New System.Drawing.Size(88, 23)
        Me.ComboBoxCalle.TabIndex = 13
        '
        'TextBoxCalle
        '
        Me.TextBoxCalle.Location = New System.Drawing.Point(102, 137)
        Me.TextBoxCalle.Name = "TextBoxCalle"
        Me.TextBoxCalle.Size = New System.Drawing.Size(115, 23)
        Me.TextBoxCalle.TabIndex = 12
        '
        'TextBoxIdActivo
        '
        Me.TextBoxIdActivo.Enabled = False
        Me.TextBoxIdActivo.Location = New System.Drawing.Point(102, 32)
        Me.TextBoxIdActivo.Name = "TextBoxIdActivo"
        Me.TextBoxIdActivo.Size = New System.Drawing.Size(115, 23)
        Me.TextBoxIdActivo.TabIndex = 6
        '
        'CheckBoxIdActivo
        '
        Me.CheckBoxIdActivo.Location = New System.Drawing.Point(4, 7)
        Me.CheckBoxIdActivo.Name = "CheckBoxIdActivo"
        Me.CheckBoxIdActivo.Size = New System.Drawing.Size(90, 20)
        Me.CheckBoxIdActivo.TabIndex = 8
        Me.CheckBoxIdActivo.Text = "CheckBoxIdActivo"
        '
        'ComboBoxIdActivo
        '
        Me.ComboBoxIdActivo.Enabled = False
        Me.ComboBoxIdActivo.Location = New System.Drawing.Point(102, 7)
        Me.ComboBoxIdActivo.Name = "ComboBoxIdActivo"
        Me.ComboBoxIdActivo.Size = New System.Drawing.Size(84, 23)
        Me.ComboBoxIdActivo.TabIndex = 7
        '
        'CheckBoxRazonSocial
        '
        Me.CheckBoxRazonSocial.Location = New System.Drawing.Point(4, 60)
        Me.CheckBoxRazonSocial.Name = "CheckBoxRazonSocial"
        Me.CheckBoxRazonSocial.Size = New System.Drawing.Size(112, 20)
        Me.CheckBoxRazonSocial.TabIndex = 5
        Me.CheckBoxRazonSocial.Text = "Razon Social"
        '
        'TextBoxRazonSocial
        '
        Me.TextBoxRazonSocial.Enabled = False
        Me.TextBoxRazonSocial.Location = New System.Drawing.Point(102, 85)
        Me.TextBoxRazonSocial.Name = "TextBoxRazonSocial"
        Me.TextBoxRazonSocial.Size = New System.Drawing.Size(115, 23)
        Me.TextBoxRazonSocial.TabIndex = 3
        '
        'TabPage2
        '
        Me.TabPage2.AutoScroll = True
        Me.TabPage2.Controls.Add(Me.CheckBoxContacto)
        Me.TabPage2.Controls.Add(Me.ComboBoxContacto)
        Me.TabPage2.Controls.Add(Me.TextBoxContacto)
        Me.TabPage2.Controls.Add(Me.CheckBoxInterior)
        Me.TabPage2.Controls.Add(Me.ComboBoxInterior)
        Me.TabPage2.Controls.Add(Me.TextBoxReferenciaDom)
        Me.TabPage2.Controls.Add(Me.TextBoxInterior)
        Me.TabPage2.Controls.Add(Me.ComboBoxReferenciaDom)
        Me.TabPage2.Controls.Add(Me.CheckBoxReferenciaDom)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(234, 232)
        Me.TabPage2.Text = "TabPage2"
        '
        'CheckBoxContacto
        '
        Me.CheckBoxContacto.Location = New System.Drawing.Point(3, 116)
        Me.CheckBoxContacto.Name = "CheckBoxContacto"
        Me.CheckBoxContacto.Size = New System.Drawing.Size(90, 20)
        Me.CheckBoxContacto.TabIndex = 18
        Me.CheckBoxContacto.Text = "CheckBoxContacto"
        '
        'ComboBoxContacto
        '
        Me.ComboBoxContacto.Enabled = False
        Me.ComboBoxContacto.Location = New System.Drawing.Point(96, 116)
        Me.ComboBoxContacto.Name = "ComboBoxContacto"
        Me.ComboBoxContacto.Size = New System.Drawing.Size(84, 23)
        Me.ComboBoxContacto.TabIndex = 17
        '
        'TextBoxContacto
        '
        Me.TextBoxContacto.Location = New System.Drawing.Point(96, 141)
        Me.TextBoxContacto.Name = "TextBoxContacto"
        Me.TextBoxContacto.Size = New System.Drawing.Size(121, 23)
        Me.TextBoxContacto.TabIndex = 16
        '
        'CheckBoxInterior
        '
        Me.CheckBoxInterior.Location = New System.Drawing.Point(3, 12)
        Me.CheckBoxInterior.Name = "CheckBoxInterior"
        Me.CheckBoxInterior.Size = New System.Drawing.Size(90, 20)
        Me.CheckBoxInterior.TabIndex = 11
        Me.CheckBoxInterior.Text = "CheckBoxInterior"
        '
        'ComboBoxInterior
        '
        Me.ComboBoxInterior.Enabled = False
        Me.ComboBoxInterior.Location = New System.Drawing.Point(96, 12)
        Me.ComboBoxInterior.Name = "ComboBoxInterior"
        Me.ComboBoxInterior.Size = New System.Drawing.Size(88, 23)
        Me.ComboBoxInterior.TabIndex = 10
        '
        'TextBoxReferenciaDom
        '
        Me.TextBoxReferenciaDom.Location = New System.Drawing.Point(96, 89)
        Me.TextBoxReferenciaDom.Name = "TextBoxReferenciaDom"
        Me.TextBoxReferenciaDom.Size = New System.Drawing.Size(121, 23)
        Me.TextBoxReferenciaDom.TabIndex = 13
        '
        'TextBoxInterior
        '
        Me.TextBoxInterior.Location = New System.Drawing.Point(96, 37)
        Me.TextBoxInterior.Name = "TextBoxInterior"
        Me.TextBoxInterior.Size = New System.Drawing.Size(121, 23)
        Me.TextBoxInterior.TabIndex = 9
        '
        'ComboBoxReferenciaDom
        '
        Me.ComboBoxReferenciaDom.Enabled = False
        Me.ComboBoxReferenciaDom.Location = New System.Drawing.Point(96, 64)
        Me.ComboBoxReferenciaDom.Name = "ComboBoxReferenciaDom"
        Me.ComboBoxReferenciaDom.Size = New System.Drawing.Size(88, 23)
        Me.ComboBoxReferenciaDom.TabIndex = 14
        '
        'CheckBoxReferenciaDom
        '
        Me.CheckBoxReferenciaDom.Location = New System.Drawing.Point(3, 64)
        Me.CheckBoxReferenciaDom.Name = "CheckBoxReferenciaDom"
        Me.CheckBoxReferenciaDom.Size = New System.Drawing.Size(90, 20)
        Me.CheckBoxReferenciaDom.TabIndex = 15
        Me.CheckBoxReferenciaDom.Text = "CheckBoxReferenciaDom"
        '
        'ButtonContinuarBusqueda
        '
        Me.ButtonContinuarBusqueda.Location = New System.Drawing.Point(6, 265)
        Me.ButtonContinuarBusqueda.Name = "ButtonContinuarBusqueda"
        Me.ButtonContinuarBusqueda.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarBusqueda.TabIndex = 12
        Me.ButtonContinuarBusqueda.Text = "ButtonContinuarBusqueda"
        '
        'FormClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelBusquedaCli)
        Me.Controls.Add(Me.PanelContrasena)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuAgenda
        Me.MinimizeBox = False
        Me.Name = "FormClientes"
        Me.Panel1.ResumeLayout(False)
        Me.PanelTitulo.ResumeLayout(False)
        Me.PanelContrasena.ResumeLayout(False)
        Me.PanelBusquedaCli.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Event VerificarLecturaGPS()
    Public Event AlmacenarLecturaGPS()
    'Public Event EventoDesconectarGPS()

#Region "PROPIEDADES"
    Dim sClienteClave As String
    Public Property RutaActual() As Ruta
        Get
            Return oRutaActual
        End Get
        Set(ByVal Value As Ruta)
            oRutaActual = Value
        End Set
    End Property

    Public Property ClienteActual() As Cliente
        Get
            Return oClienteActual
        End Get
        Set(ByVal Value As Cliente)
            oClienteActual = Value
        End Set
    End Property

    Public Property FueraFrecuencia() As Boolean
        Get
            Return bFueraFrecuencia
        End Get
        Set(ByVal value As Boolean)
            bFueraFrecuencia = value
        End Set
    End Property
#End Region

#Region "VARIABLES Y CONSTANTES"
    Private Const ConstMenuRegresar = 0
    Private Const ConstMenuVerClientes = 1

    Private oRutaActual As Ruta
    Private oClienteActual As Cliente

    Private bCambioManual As Boolean = False
    Private bHuboCambios As Boolean = False
    Private MenuItemVerPorSurtir As System.Windows.Forms.MenuItem

#If MOD_TERM <> "PALM" Then
    Private WithEvents bScanner As New HANDHELD.CScanner
#End If

    Private eVistaAgenda As ServicesCentral.TiposVistasAgendas = ServicesCentral.TiposVistasAgendas.ClientesNoVisitados
    Private refaVista As Vista
    Private bIniciando As Boolean = True
    Private bLlenando As Boolean = True
    Private iSegundos As Integer
    Private dFechaReferencia As DateTime = Now
    Private bLeerCodigoCliente As Boolean = False
    Private bLeerContrasenaCliente As Boolean = False
    Friend bCodigoLeido As Boolean = False
    Private bFueraFrecuencia As Boolean = False
    Private nTipoIniciarVisita As Integer
    Private nLatitudGPS As Double
    Private nLongitudGPS As Double
    Private nLatitudCliente As Double
    Private nLongitudCliente As Double
#If SO_WCE = 0 Then
    Private updateDataHandler As EventHandler
    Private device As GpsDeviceState = Nothing
    Private position As GpsPosition = Nothing
    Private WithEvents oGPS As Microsoft.WindowsMobile.Samples.Location.Gps
#End If
    Friend bGPSLeido As Boolean = False
    Private bLatitudLeido As Boolean = False
    Private bLongitudLeido As Boolean = False
    Private bIniciarVisita As Boolean = True
    Private bTieneCoordenadas As Boolean
    Private bValidando As Boolean = True
    Private bDesconectando As Boolean = False
    Private nContador As Decimal
    Friend nDistanciaGPS As Decimal
    Private bCargandoCombo As Boolean
    Private sFiltroClientes As String
    Private bEnFiltros As Boolean = False
    Private bLectorActivo As Boolean = False
    Private bPuntoGPS As Boolean = False
#End Region

#Region " Eventos generales de la forma "

    Private Sub FormAgenda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor

        TimerGPS.Interval = oApp.TimeOutGPS * 1000
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        'AgregarLogging("ConsultaCliente", "FormAgenda_Load", AMESOLLogging.AMESOLLog.TipoLog.Funciones)
        AddHandler VerificarLecturaGPS, AddressOf VerificarLectura
        'AddHandler AlmacenarLecturaGPS, AddressOf AlmacenaLectura
        'AddHandler EventoDesconectarGPS, AddressOf DesconectarGps
        Me.CargarAgenda()
        'Application.DoEvents()
        If Not oConHist.Campos("EnvioParcial") Then
            Me.Menu.MenuItems.Remove(MenuItemEnvio)
        End If
        refaVista.ColocarEtiquetasMenuEmergente(ContextMenuClientes)
        If Me.ContextMenuClientes.MenuItems.Contains(MenuItemEliminar) Then
            Me.ContextMenuClientes.MenuItems.Remove(MenuItemEliminar)
        End If
        RefrescarStatusBateria()
        'Dim oDr As DataRow = oDBVen.RealizarConsultaSQL("select CodigoBarrasCliente,ContrasenaCliente from conhist ", "TAbla").Rows(0)
        Me.bLeerCodigoCliente = oConHist.Campos("CodigoBarrasCliente") 'oDr("CodigoBarrasCliente")
        Me.bLeerContrasenaCliente = oConHist.Campos("ContrasenaCliente") 'oDr("ContrasenaCliente")
        Me.nTipoIniciarVisita = oConHist.Campos("TipoIniciarVisita")

        If (nTipoIniciarVisita = 1 Or Me.nTipoIniciarVisita = 3) And Me.bLeerCodigoCliente Then
            ActivarInactivarLector(True)
        End If
        LabelTiempo.Text = Format(PrimeraHora(Now), oApp.FormatoFecha)
        Me.PonerFocusAColumna("RazonSocial")
        bIniciando = False
        Me.txtNoCliente.Focus()
        Me.MenuItemCuotas.Enabled = oVendedor.MostrarCuota
        Application.DoEvents()
        If Not oVendedor.GPS Then
            Me.ButtonGPS.Visible = False
            Me.txtPatron.Width = FlexGridClientes.Width
        Else
#If SO_WCE = 0 Then
            If oGPS Is Nothing Then
                oGPS = New Microsoft.WindowsMobile.Samples.Location.Gps()
            End If
#End If
            ConectarGps()
        End If
        DeshabilitarFiltros()
        ButtonAgendaRegresar.Enabled = True
        ButtonAgendaNuevo.Enabled = True
        ButtonAgendaContinuar.Enabled = True
        If Not oApp.ClienteNuevo Then
            Me.ButtonAgendaNuevo.Visible = False
        End If
        Cursor.Current = Cursors.Default
        'MemoriaTexto("FormAgenda")
    End Sub

    Private Sub DeshabilitarFiltros()
        ComboBoxIdActivo.Enabled = False
        TextBoxIdActivo.Enabled = False
        ComboBoxRazonSocial.Enabled = False
        TextBoxRazonSocial.Enabled = False
        ComboBoxContacto.Enabled = False
        TextBoxContacto.Enabled = False
        ComboBoxCalle.Enabled = False
        TextBoxCalle.Enabled = False
        ComboBoxExterior.Enabled = False
        TextBoxExterior.Enabled = False
        ComboBoxInterior.Enabled = False
        TextBoxInterior.Enabled = False
        ComboBoxColonia.Enabled = False
        TextBoxColonia.Enabled = False
        ComboBoxReferenciaDom.Enabled = False
        TextBoxReferenciaDom.Enabled = False
    End Sub

    Private Sub ActivarInactivarLector(ByVal parbActivar As Boolean)
#If MOD_TERM <> "PALM" Then
        If parbActivar Then
            If Not bLectorActivo Then
                If Me.bLeerCodigoCliente Or bEnFiltros Then
                    Select Case oApp.ModeloTerminal
                        Case "Generico"
                        Case "SymbolC9090", "SymbolMC50", "SymbolMC70"
                            Try
                                bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolPCMC50)
                                bLectorActivo = True
                            Catch ex As Exception
                                MsgBox("Error while starting the scanner:" & ex.Message, MsgBoxStyle.Critical)
                            End Try
                        Case "HHP7600"
                            bScanner.Inicialize_Scanner(HANDHELD.SO.HHP7600)
                            bLectorActivo = True
                        Case "HHP7900"
                            bScanner.Inicialize_Scanner(HANDHELD.SO.HHP7900)
                            bLectorActivo = True
                        Case "HHPWM6"
                            bScanner.Inicialize_Scanner(HANDHELD.SO.HHPWM6)
                            bLectorActivo = True
                        Case "SymbolMC35"
                            bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolMC35)
                            bLectorActivo = True
                        Case "IntermecCN3"
                            bScanner.Inicialize_Scanner(HANDHELD.SO.IntermecCN3)
                            bLectorActivo = True
                        Case "SymbolMC55"
                            bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolMC55)
                            bLectorActivo = True
                    End Select
                End If
            End If
        Else
            Try
                bScanner.Terminate_Scanner()
                bLectorActivo = False
            Catch ex As Exception
                MsgBox("Error while starting the scanner:" & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
#End If
    End Sub
    Private Sub RefrescarStatusBateria()
        Dim status As New Bateria.SYSTEM_POWER_STATUS_EX
        If Convert.ToInt32(Bateria.SYSTEM_POWER_STATUS_EX.GetSystemPowerStatusEx(status, False)) = 1 Then
            Me.LabelBateria.Text = String.Format("{0}%", status.BatteryLifePercent)
        End If
    End Sub

    Private Sub MostrarClienteActual()
        If Me.ClienteActual.ClienteClave Is Nothing Then
            If Me.FlexGridClientes.Rows.Count > 1 Then
                Me.FlexGridClientes.Row = 1
            End If
        Else
            Dim i As Integer = Me.EncontrarElemento(Me.ClienteActual.ClienteClave, Me.FlexGridClientes.Cols("ClienteClave").Index)
            If i <> -1 Then
                Me.FlexGridClientes.Row = i
            End If
        End If
    End Sub

#End Region

#Region " Eventos y procedimientos del manejo de la Agenda "

    Private Sub ButtonAgendaContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgendaContinuar.Click
        bPuntoGPS = False
        If Me.txtNoCliente.Text.Trim <> String.Empty Then
            'Buscarlo x codigo
            CodigoBarras(Me.txtNoCliente.Text)
            Exit Sub
            'If Not ClienteAutomatico(Me.txtNoCliente.Text, False) Then
            '    Me.txtNoCliente.Text = String.Empty
            '    Exit Sub
            'End If

        End If

        Dim indiceCliente As Integer = Me.FlexGridClientes.Row
        If indiceCliente <> -1 Then
            If oApp.ExigirSecuenciaClientes Then
                Dim odtOrden As DataTable = oDBVen.RealizarConsultaSQL("Select Orden from agenda where DiaClave='" & oDia.DiaActual & "' And RUTClave='" & oRutaActual.RUTClave & "' AND ClienteClave='" & Me.FlexGridClientes.GetData(indiceCliente, "ClienteClave") & "' and Visitado = 2", "OrdenCliente")
                If odtOrden.Rows.Count > 0 Then
                    Dim odtOrdenMenor As DataTable = oDBVen.RealizarConsultaSQL("Select Cliente.clave, Orden from agenda inner join Cliente on Cliente.CLienteClave = Agenda.ClienteCLave where DiaClave='" & oDia.DiaActual & "' And RUTClave='" & oRutaActual.RUTClave & "' AND Agenda.ClienteClave<>'" & Me.FlexGridClientes.GetData(indiceCliente, "ClienteClave") & "' and Visitado = 2 and orden <=" & odtOrden.Rows(0)(0), "OrdenCliente")
                    If odtOrdenMenor.Rows.Count > 0 Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0431").Replace("$0$", Me.FlexGridClientes.GetData(indiceCliente, "Clave")).Replace("$1$", odtOrdenMenor.Rows(0)(0)), MsgBoxStyle.Information)
                        Me.FlexGridClientes.Focus()
                        Exit Sub
                    End If
                    odtOrdenMenor.Dispose()
                End If
                odtOrden.Dispose()
            End If

            If Not oApp.AseguramientoVisita Then
                MostrarDetalleCliente()
            Else
                bTieneCoordenadas = ObtenerCoordenadasCliente(Me.FlexGridClientes.Item(indiceCliente, "ClienteClave"))

                If (Me.nTipoIniciarVisita = 1 Or Me.nTipoIniciarVisita = 3) AndAlso Me.bLeerCodigoCliente AndAlso Not Me.bCodigoLeido AndAlso Me.bLeerContrasenaCliente Then
                    Me.MostrarPanelContrasena(True)
                Else
                    AsegurarVisitaGPS()
                    'bGPSLeido = True
                    'MostrarDetalleCliente()
                End If
            End If

        Else
            MsgBox(refaVista.BuscarMensaje("MsgBox", "Elegir"), MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub

    Private Sub ButtonAgendaRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgendaRegresar.Click
        Me.Close()
        CTEActual = String.Empty
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        If bEnFiltros Then
            Me.PanelBusquedaCli.SendToBack()
            Me.PanelBusquedaCli.Visible = False
            Me.Panel1.BringToFront()
            Me.Panel1.Visible = True
            Me.MenuItemMasInfo.Enabled = True
            Me.MenuItemVer.Enabled = True
            If oConHist.Campos("EnvioParcial") Then Me.MenuItemEnvio.Enabled = True
            bEnFiltros = False
#If MOD_TERM <> "PALM" Then
            If Not ((nTipoIniciarVisita = 1 Or Me.nTipoIniciarVisita = 3) And Me.bLeerCodigoCliente) Then
                ActivarInactivarLector(False)
            End If
#End If
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub MenuItemVerVisitados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemVerVisitados.Click
        MostrarClientes(ServicesCentral.TiposVistasAgendas.ClientesVisitados)
    End Sub

    Private Sub MenuItemVerNoVisitados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemVerNoVisitados.Click
        MostrarClientes(ServicesCentral.TiposVistasAgendas.ClientesNoVisitados)
    End Sub

    Private Sub MenuItemVerPorSurtir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MostrarClientes(ServicesCentral.TiposVistasAgendas.PorSurtir)
    End Sub


    Private Sub MenuItemVerTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemVerTodos.Click
        MostrarClientes(ServicesCentral.TiposVistasAgendas.TodosClientes)
    End Sub

    Private Sub MenuItemVerFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemVerFiltro.Click
        MostrarClientes(5)
    End Sub

    Private Sub MostrarClientes(ByVal refpareVistaAgenda As ServicesCentral.TiposVistasAgendas)
        bLlenando = True
        Me.BorrarPatron()
        Me.BorraNoCliente()
        eVistaAgenda = refpareVistaAgenda
        ActualizarMarcadoresFiltros()
        Dim sCondicion As String = String.Empty
        Dim dvClientes As DataView
        Select Case refpareVistaAgenda
            Case ServicesCentral.TiposVistasAgendas.TodosClientes
                sCondicion = "WHERE DiaClave='" & oDia.DiaActual & "' AND Agenda.RUTClave='" & Me.RutaActual.RUTClave & "'"
            Case ServicesCentral.TiposVistasAgendas.ClientesVisitados
                sCondicion = "WHERE Visitado=" & Cliente.TiposEstadosClientes.ClienteVisitado & " AND DiaClave='" & oDia.DiaActual & "'" & " AND Agenda.RUTClave='" & Me.RutaActual.RUTClave & "'"
            Case ServicesCentral.TiposVistasAgendas.ClientesNoVisitados
                sCondicion = "WHERE Visitado=" & Cliente.TiposEstadosClientes.ClienteNoVisitado & " AND DiaClave='" & oDia.DiaActual & "'" & " AND Agenda.RUTClave='" & Me.RutaActual.RUTClave & "'"
            Case ServicesCentral.TiposVistasAgendas.PorSurtir
                sCondicion = "WHERE DiaClave='" & oDia.DiaActual & "'" & " AND Agenda.RUTClave='" & Me.RutaActual.RUTClave & "' and cliente.clienteclave  in( select v.clienteclave from transprod t inner join visita v on t.visitaclave=v.visitaclave and t.diaclave=v.diaclave where t.tipofase =1 and Tipo = 1 ) "
            Case 5
                If sFiltroClientes <> "" Then
                    sCondicion = "WHERE " + sFiltroClientes + " AND DiaClave='" & oDia.DiaActual & "'" & " AND Agenda.RUTClave='" & Me.RutaActual.RUTClave & "'"
                Else
                    sCondicion = "WHERE DiaClave='" & oDia.DiaActual & "'" & " AND Agenda.RUTClave='" & Me.RutaActual.RUTClave & "'"
                End If
        End Select
        Dim sQuery As String = refaVista.RecuperarConsultaSQL(oDBVen, "ListViewAgenda", sCondicion, ServicesCentral.TiposContenido.Consulta)
        Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery, "ObtenerDatos")
        dvClientes = New DataView(oDt)
        'dvClientes.RowFilter = sFiltroClientes
        Try
            With Me.FlexGridClientes
                .Redraw = False
                .DataSource = Nothing
                .AutoResize = False
                .DataSource = dvClientes
                .Cols.Fixed = 0
                .Cols(0).Visible = False
                .Cols(1).Caption = refaVista.BuscarMensaje("FlexGrid", "Clave")
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then

                .Cols(1).Width = 160
#Else
                 .Cols(1).Width = 80
#End If
                .Cols(1).AllowEditing = False
                .Cols(2).Caption = refaVista.BuscarMensaje("FlexGrid", "RazonSocial")
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then

                .Cols(2).Width = 320
#Else
                 .Cols(2).Width = 160
#End If
                .Cols(2).AllowEditing = False
                .Cols(3).Caption = refaVista.BuscarMensaje("FlexGrid", "Contacto")
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then

                .Cols(3).Width = 320
#Else
                 .Cols(3).Width =160
#End If
                .Cols(3).AllowEditing = False
                .Cols(4).Visible = False 'Calle
                .Cols(5).Visible = False 'ReferenciaDom
                .Cols(6).Visible = False 'NombreCorto
                .Cols(7).Visible = False 'IdElectronico
                .Cols(8).Visible = False 'numero exterior
                .Cols(9).Visible = False 'numint interior
                .Cols(10).Visible = False 'colonia
                .Cols(11).Visible = False 'Enviado
                .KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
                .KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.None
                .Redraw = True
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            oDt.Dispose()
        End Try
        FlexGridClientes.Redraw = True
        SeleccionarClienteActual()
        Me.PonerFocusAColumna("RazonSocial")
        'End If
        bLlenando = False
    End Sub

    Private Function MostrarClientesScaneado(ByVal pvIdElectronico As String) As Boolean
        bLlenando = True
        Me.BorrarPatron()
        Me.BorraNoCliente()

        Dim iSQLResult As Integer

        Dim strSQL As String = String.Format("Select Visitado FROM Agenda INNER JOIN Cliente ON Agenda.ClienteClave = Cliente.ClienteClave {0} ORDER BY Agenda.Orden", "WHERE DiaClave='" & oDia.DiaActual & "' AND Agenda.RUTClave='" & Me.RutaActual.RUTClave & "' And Cliente.IdElectronico='" & pvIdElectronico & "'")

        iSQLResult = oDBVen.EjecutarCmdScalarIntSQL(strSQL)

        If iSQLResult = 1 Then
            eVistaAgenda = ServicesCentral.TiposVistasAgendas.ClientesVisitados
        ElseIf iSQLResult = 2 Then
            eVistaAgenda = ServicesCentral.TiposVistasAgendas.ClientesNoVisitados
        Else
            bLlenando = False
            Return False
        End If

        Dim sCondicion As String = String.Empty
        Select Case eVistaAgenda
            Case ServicesCentral.TiposVistasAgendas.TodosClientes
                sCondicion = "WHERE DiaClave='" & oDia.DiaActual & "' AND Agenda.RUTClave='" & Me.RutaActual.RUTClave & "'"
            Case ServicesCentral.TiposVistasAgendas.ClientesVisitados
                sCondicion = "WHERE Visitado=" & Cliente.TiposEstadosClientes.ClienteVisitado & " AND DiaClave='" & oDia.DiaActual & "'" & " AND Agenda.RUTClave='" & Me.RutaActual.RUTClave & "'"
            Case ServicesCentral.TiposVistasAgendas.ClientesNoVisitados
                sCondicion = "WHERE Visitado=" & Cliente.TiposEstadosClientes.ClienteNoVisitado & " AND DiaClave='" & oDia.DiaActual & "'" & " AND Agenda.RUTClave='" & Me.RutaActual.RUTClave & "'"
        End Select
        Dim sQuery As String = refaVista.RecuperarConsultaSQL(oDBVen, "ListViewAgenda", sCondicion, ServicesCentral.TiposContenido.Consulta)
        Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery, "ObtenerDatos")
        Try
            With Me.FlexGridClientes
                .Redraw = False
                .DataSource = Nothing
                .DataSource = oDt
                .Cols.Fixed = 0
                .Cols(0).Visible = False
                .Cols(1).Caption = refaVista.BuscarMensaje("FlexGrid", "Clave")
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then

                .Cols(1).Width = 160
#Else
                 .Cols(1).Width = 80
#End If

                .Cols(1).AllowEditing = False
                .Cols(2).Caption = refaVista.BuscarMensaje("FlexGrid", "RazonSocial")
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then

                .Cols(2).Width = 320
#Else
                 .Cols(2).Width = 160
#End If
                .Cols(2).AllowEditing = False
                .Cols(3).Caption = refaVista.BuscarMensaje("FlexGrid", "Contacto")
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then

                .Cols(3).Width = 320
#Else
                 .Cols(3).Width =160
#End If
                .Cols(3).AllowEditing = False
                .Cols(4).Visible = False 'Calle
                .Cols(5).Visible = False 'ReferenciaDom
                .Cols(6).Visible = False 'NombreCorto
                .Cols(7).Visible = False 'IdElectronico
                .Cols(8).Visible = False 'Enviado
                .Redraw = True
            End With
        Catch ex As Exception
            oDt.Dispose()
            'MsgBox(ex.Message)
        End Try
        SeleccionarClienteActual()
        'End If

        ActualizarMarcadoresFiltros()
        Me.PonerFocusAColumna("RazonSocial")
        bLlenando = False
        Return True
    End Function

    Public Sub FuncionEventoClickMenuAgendas(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim refMenuItem As MenuItem = sender
        oVendedor.NombreModulo = refMenuItem.Text
        MostrarClientes(eVistaAgenda)
    End Sub

    Private Sub ActualizarMarcadoresFiltros()
        Dim refMenuItem As MenuItem
        LabelNombreAgenda.Text = oVendedor.NombreModulo

        ' El filtro de clientes que está siendo mostrado
        DesmarcarTodosMenus(MainMenuAgenda.MenuItems(ConstMenuVerClientes))
        Select Case eVistaAgenda
            Case ServicesCentral.TiposVistasAgendas.ClientesNoVisitados
                refMenuItem = MenuItemVerNoVisitados
            Case ServicesCentral.TiposVistasAgendas.ClientesVisitados
                refMenuItem = MenuItemVerVisitados
            Case ServicesCentral.TiposVistasAgendas.PorSurtir
                refMenuItem = MenuItemVerPorSurtir
            Case 5
                refMenuItem = MenuItemVerFiltro
            Case Else
                refMenuItem = MenuItemVerTodos
        End Select
        refMenuItem.Checked = True
        LabelEstadoAgenda.Text = refMenuItem.Text
    End Sub

    Private Sub AgregarHandlerMenus(ByRef refparMenuItem As MenuItem)
        Dim refMenuItem As MenuItem
        For Each refMenuItem In refparMenuItem.MenuItems
            AddHandler refMenuItem.Click, AddressOf FuncionEventoClickMenuAgendas
        Next
    End Sub

#End Region

#Region " Eventos y procedimientos del manejo del Detalle del Cliente "

    Private Sub MostrarDetalleCliente()
        Dim i As Integer = Me.FlexGridClientes.Row
        If i = -1 Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "Elegir"), MsgBoxStyle.Information)
            Exit Sub
        End If
        Me.ClienteActual.ClienteClave = Me.FlexGridClientes.Item(i, "ClienteClave")
        Me.ClienteActual.Recuperar()
        FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("ProcesandoAgenda", "Titulo"))
        FormProcesando.PubSubInformar(refaVista.BuscarMensaje("ProcesandoAgenda", "Buscando"))
        FlexGridClientes.AutoSearchDelay = 10000
        FlexGridClientes.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Public Sub CrearClienteVacio()
        Dim sQuery As String = String.Empty
        sClienteClave = oApp.KEYGEN(1)
        sQuery = "INSERT INTO Cliente VALUES('" & sClienteClave & "',NULL,'NUEVO" & Me.ObtenerConsecutivoNuevo & "','','','',1,1,'',''," & UniFechaSQL(Now) & ",null,0,'',1,0,0,0,0,null,0,0,1,0,0," & UniFechaSQL(New Date(9999, 12, 31)) & ",0,0,1," & UniFechaSQL(Now) & ", '" & oVendedor.UsuarioId & "',0,0,0,0)"
        oDBVen.EjecutarComandoSQL(sQuery)
        sQuery = "INSERT INTO ClienteDomicilio VALUES('" & sClienteClave & "','" & oApp.KEYGEN(0) & "',2,'','','','','','',null,'','','',null,null, " & UniFechaSQL(Now) & ", '" & oVendedor.UsuarioId & "',0)"
        oDBVen.EjecutarComandoSQL(sQuery)
        sQuery = "INSERT INTO ClienteEsquema VALUES('" & sClienteClave & "','" & Me.ObtenerEsquemaNuevo & "'," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "',0,0)"
        oDBVen.EjecutarComandoSQL(sQuery)
        sQuery = "INSERT INTO CLIFormaVenta VALUES('" & sClienteClave & "',1,0,0,0,0,0,1,1," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "',0)"
        oDBVen.EjecutarComandoSQL(sQuery)
        sQuery = "INSERT INTO CFVHist VALUES('" & sClienteClave & "',1," & UniFechaSQL(Now) & ",0,0,0,0,1," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "',0)"
        oDBVen.EjecutarComandoSQL(sQuery)
        sQuery = "INSERT INTO CenCli Select CENClave,'" & sClienteClave & "',Puntos,IniAplicacion, FinAplicacion, getdate(),'" & oVendedor.UsuarioId & "',0 from CENClienteNuevo "
        oDBVen.EjecutarComandoSQL(sQuery)
        Dim sFrecuenciaClave As String = oDBVen.EjecutarCmdScalarStrSQL("Select FrecuenciaClave from Agenda where RUTClave='" & oAgenda.RutaActual.RUTClave & "'")
        sQuery = "INSERT INTO Agenda Values('" & oDia.DiaActual & "','" & oVendedor.VendedorId & "','" & sFrecuenciaClave & "','" & oAgenda.RutaActual.RUTClave & "',0,'" & sClienteClave & "',0," & ServicesCentral.TiposVistasAgendas.ClientesNoVisitados & ")"
        oDBVen.EjecutarComandoSQL(sQuery)
    End Sub
    Private Function ObtenerConsecutivoNuevo() As String
        Dim sQuery As String = "select max(clave) from cliente where clave like 'NUEVO%'"
        Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery, "Nuevo")
        If IsDBNull(oDt.Rows(0)(0)) Then
            oDt.Dispose()
            Return "001"
        Else
            Dim sNuevo As String = oDt.Rows(0)(0)
            sNuevo = sNuevo.Replace("NUEVO", "")
            Dim iLong As Integer = sNuevo.Length
            sNuevo = CInt(sNuevo) + 1
            sNuevo = sNuevo.PadLeft(iLong, "0")
            oDt.Dispose()
            Return sNuevo
        End If
    End Function
#End Region

#Region " Funciones privadas de la forma "

    Private Sub DesmarcarTodosMenus(ByVal refparMenuItem As MenuItem)
        Dim refMenuItem As MenuItem
        For Each refMenuItem In refparMenuItem.MenuItems
            refMenuItem.Checked = False
        Next
    End Sub

    'Private Sub ListViewAgenda_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewAgenda.ItemActivate
    '    If Not bIniciando Then
    '        If ListViewAgenda.SelectedIndices.Count = 0 Then
    '            Exit Sub
    '        End If
    '        Me.MarcarClienteSeleccionado()
    '        oStatus = eStatus.Existente
    '        SubEjecutarSeleccionCliente()
    '    End If
    'End Sub


    Private Sub SeleccionarClienteActual()
        If Me.ClienteActual.ClienteClave = String.Empty Then
            Exit Sub
        End If

        Dim i As Integer = Me.EncontrarElemento(Me.ClienteActual.ClienteClave, Me.FlexGridClientes.Cols("ClienteClave").Index)
        If i <> -1 Then
            CTEActual = Me.ClienteActual.ClienteClave
            Me.FlexGridClientes.Row = i
        End If
    End Sub

    Private Function PoblarMenuAgendas(ByRef refparMenuItem As MenuItem, ByRef refparaVista As Vista, ByVal parsClaveElemento As String) As Boolean
        Try
            Dim DataTableModulos As DataTable
            DataTableModulos = oDBVen.RealizarConsultaSQL("SELECT ModuloClave FROM ModuloTerm WHERE Tipo=" & ServicesCentral.TiposAmbitosModulos.Visitas, "Agenda")
            If DataTableModulos.Rows.Count = 0 Then
                Exit Try
            End If
            Dim refDataRow As DataRow
            Dim aModulos As New ArrayList
            For Each refDataRow In DataTableModulos.Rows
                aModulos.Add(refDataRow("ModuloClave"))
            Next
            DataTableModulos.Dispose()
            Return refparaVista.CrearMenuFiltro(refparMenuItem, oDBVen, parsClaveElemento, aModulos, "ModuloClave", "Nombre")
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "PoblarMenuAgendas")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "PoblarMenuAgendas")
        End Try
        Return False
    End Function

#End Region

#Region "Funciones LGutierrez Jul/06"

#Region "METODOS"

    Private Sub CargarAgenda()
        If Not Vista.Buscar("FormClientes", refaVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
            MenuItemVerPorSurtir = New System.Windows.Forms.MenuItem
            MenuItemVerPorSurtir.Text = "MenuItemVerPorSurtir"
            Me.MenuItemVer.MenuItems.Add(Me.MenuItemVerPorSurtir)
            AddHandler MenuItemVerPorSurtir.Click, AddressOf MenuItemVerPorSurtir_Click
        End If

        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        LlenaCombos()

        LabelReferencia.Text = oDia.FechaCaptura & "-" & Me.RutaActual.RUTClave
        ' Poblar el menú de clientes
        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
            MostrarClientes(ServicesCentral.TiposVistasAgendas.PorSurtir)
        ElseIf oConHist.Campos("ClientesVisitados") Then
            MostrarClientes(ServicesCentral.TiposVistasAgendas.ClientesVisitados)
        Else
            MostrarClientes(ServicesCentral.TiposVistasAgendas.ClientesNoVisitados)
        End If

        MostrarClienteActual()

        Me.PanelBusquedaCli.SendToBack()
        Me.PanelBusquedaCli.Visible = False
    End Sub

    Private Function ObtenerEsquemaNuevo() As String
        Return oDBVen.RealizarConsultaSQL("SELECT EsquemaId FROM Esquema WHERE Clave='NVO001'", "ObtenerEsquemaNuevo").Rows(0)(0)
    End Function

    Private Sub LlenaCombos()
        bCargandoCombo = True
        With ComboBoxIdActivo
            .DataSource = ValorReferencia.RecuperarLista("BFSTRING")
            If .Items.Count > 0 Then
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                .SelectedIndex = 0
            End If
        End With

        With ComboBoxRazonSocial
            .DataSource = ValorReferencia.RecuperarLista("BFSTRING")
            If .Items.Count > 0 Then
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                .SelectedIndex = 0
            End If
        End With

        With ComboBoxContacto
            .DataSource = ValorReferencia.RecuperarLista("BFSTRING")
            If .Items.Count > 0 Then
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                .SelectedIndex = 0
            End If
        End With

        With ComboBoxCalle
            .DataSource = ValorReferencia.RecuperarLista("BFSTRING")
            If .Items.Count > 0 Then
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                .SelectedIndex = 0
            End If
        End With

        With ComboBoxColonia
            .DataSource = ValorReferencia.RecuperarLista("BFSTRING")
            If .Items.Count > 0 Then
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                .SelectedIndex = 0
            End If
        End With

        With ComboBoxExterior
            .DataSource = ValorReferencia.RecuperarLista("BFSTRING")
            If .Items.Count > 0 Then
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                .SelectedIndex = 0
            End If
        End With

        With ComboBoxInterior
            .DataSource = ValorReferencia.RecuperarLista("BFSTRING")
            If .Items.Count > 0 Then
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                .SelectedIndex = 0
            End If
        End With

        With ComboBoxReferenciaDom
            .DataSource = ValorReferencia.RecuperarLista("BFSTRING")
            If .Items.Count > 0 Then
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                .SelectedIndex = 0
            End If
        End With
        bCargandoCombo = False
    End Sub
#End Region

#Region "EVENTOS"
    Private Sub ButtonAgendaPromociones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAgendaNuevo.Click
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        If oConHist.Campos("DatosCteNuevo") Then
            ActivarInactivarLector(False)
            Dim oFormClienteDetalle As New FormClienteDetalle(FormClienteDetalle.eStatus.Nuevo)
            oFormClienteDetalle.ShowDialog()
            oFormClienteDetalle.Dispose()
            oFormClienteDetalle = Nothing
            ActivarInactivarLector(True)
            Me.MostrarClientes(eVistaAgenda)
        Else
            CrearClienteVacio()
            Me.ClienteActual.ClienteClave = sClienteClave
            Me.ClienteActual.Recuperar()
            FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("ProcesandoAgenda", "Titulo"))
            FormProcesando.PubSubInformar(refaVista.BuscarMensaje("ProcesandoAgenda", "Buscando"))
            FlexGridClientes.AutoSearchDelay = 10000
            FlexGridClientes.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub ContextMenuClientes_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuClientes.Popup
        If Me.ContextMenuClientes.MenuItems.Contains(MenuItemEliminar) Then
            Me.ContextMenuClientes.MenuItems.Remove(MenuItemEliminar)
        End If
        With Me.FlexGridClientes
            If .MouseRow > 0 AndAlso .MouseCol >= 0 AndAlso .Row > 0 Then
                If (.Rows.Count > 1) AndAlso (eVistaAgenda <> ServicesCentral.TiposVistasAgendas.ClientesVisitados) Then
                    If .Item(.RowSel, "Clave").ToString.StartsWith("NUEVO") Then
                        If .Item(.RowSel, "Enviado") = 0 Then
                            If Not Me.ContextMenuClientes.MenuItems.Contains(MenuItemEliminar) Then
                                Me.ContextMenuClientes.MenuItems.Add(MenuItemEliminar)
                            End If
                        End If
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub MenuItemEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemEliminar.Click
        'Dim sClienteClave As String = Me.ListViewAgenda.Items(Me.ListViewAgenda.SelectedIndices(0)).Text
        Dim sClienteClave As String = Me.FlexGridClientes.Item(Me.FlexGridClientes.RowSel, "ClienteClave")
        Dim sQuery As String = "DELETE FROM Agenda WHERE ClienteClave='" & sClienteClave & "'"
        oDBVen.EjecutarComandoSQL(sQuery)
        sQuery = "DELETE FROM ClienteDomicilio WHERE ClienteClave='" & sClienteClave & "'"
        oDBVen.EjecutarComandoSQL(sQuery)
        sQuery = "DELETE FROM CENCli WHERE ClienteClave='" & sClienteClave & "'"
        oDBVen.EjecutarComandoSQL(sQuery)
        sQuery = "DELETE FROM Cliente WHERE ClienteClave='" & sClienteClave & "'"
        oDBVen.EjecutarComandoSQL(sQuery)
        Me.MostrarClientes(ServicesCentral.TiposVistasAgendas.ClientesNoVisitados)
    End Sub

#End Region

#End Region

#Region "GPS"

    Private Sub AsegurarVisitaGPS()
        If bTieneCoordenadas Then
            ObtenerDatosGPS()
        Else
            MostrarDetalleCliente()
        End If
    End Sub

    Private Sub VerificarLectura()
        bValidando = True
        If bGPSLeido Then
            ValidarDatosGPS()
        End If
        If bIniciarVisita Then
            'System.Threading.Thread.Sleep(2000)
            nDistanciaGPS = 0
            MostrarDetalleCliente()
        ElseIf bGPSLeido Then
            If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0207"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, refaVista.BuscarMensaje("MsgBox", "XAseguraVisita")) = MsgBoxResult.Yes Then
                AsegurarVisitaGPS()
            Else
                MostrarDetalleCliente()
            End If
        End If
    End Sub

    'Private Sub AlmacenaLectura()
    '    Try
    '        bValidando = True
    '        Dim sComando As String = ""
    '        Dim sPuntoGPSId As String = ""
    '        If bGPSLeido Then
    '            sPuntoGPSId = oApp.KEYGEN(1)
    '            sComando = String.Format("insert into PuntoGPS (PuntoGPSId, CoordenadaX, CoordenadaY, RUTClave, DiaClave, MFechaHora, MUsuarioId, Enviado) values('{0}',{1},{2},'{3}','{4}',{5},'{6}',{7})", sPuntoGPSId, nLongitudGPS, nLatitudGPS, oRutaActual.RUTClave, oDia.DiaActual, UniFechaSQL(Now), oVendedor.UsuarioId, 0)
    '            oDBVen.EjecutarComandoSQL(sComando)
    '            FormProcesando.PubSubInformar()
    '            DesconectarGps()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly)
    '    End Try
    'End Sub

    Private Sub ObtenerDatosGPS()
        'Falta agregar validacion de Vendedor.GPS
        If ((nTipoIniciarVisita = 2 Or nTipoIniciarVisita = 3) And oVendedor.GPS) Or bPuntoGPS Then
            'Cursor.Current = Cursors.WaitCursor 
            bLatitudLeido = False
            bLongitudLeido = False
            If bPuntoGPS Then
                FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("MsgBox", "XPuntoGPS"))
            Else
                FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("MsgBox", "XAseguraVisita"))
            End If
            FormProcesando.PubSubInformar(refaVista.BuscarMensaje("MsgBox", "XConectando"), refaVista.BuscarMensaje("MsgBox", "XObtenerDatosGPS"))
            TimerGPS.Enabled = True
            bValidando = False
            nContador = 0
            '#If SO_WCE = 0 Then
            '            If oGPS Is Nothing Then
            '                oGPS = New Gps
            '                updateDataHandler = New EventHandler(AddressOf UpdateData)
            '            End If
            '#End If
            '            ConectarGps()
            'Cursor.Current = Cursors.Default
#If SO_WCE = 0 Then
            If updateDataHandler Is Nothing Then
                updateDataHandler = New EventHandler(AddressOf UpdateData)
            End If
            AddHandler oGPS.LocationChanged, AddressOf oGPS_LocationChanged
#End If
        Else
            MostrarDetalleCliente()
        End If
    End Sub

    Private Sub ConectarGps()
        Try
#If SO_WCE = 0 Then
            bDesconectando = False
            If Not oGPS.Opened Then
                oGPS.Open()
                If bPuntoGPS Then
                    FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("MsgBox", "XPuntoGPS"))
                Else
                    FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("MsgBox", "XAseguraVisita"))
                End If
                FormProcesando.PubSubInformar(refaVista.BuscarMensaje("MsgBox", "XConectado"), refaVista.BuscarMensaje("MsgBox", "XObtenerDatosGPS"))
            End If
#End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Public Sub DesconectarGps()
        Try
#If SO_WCE = 0 Then
            bDesconectando = True
            Application.DoEvents()
            If Not oGPS Is Nothing Then
                If oGPS.Opened Then
                    Application.DoEvents()
                    oGPS.Close()
                    If bPuntoGPS Then
                        FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("MsgBox", "XPuntoGPS"))
                    Else
                        FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("MsgBox", "XAseguraVisita"))
                    End If
                    FormProcesando.PubSubInformar(refaVista.BuscarMensaje("MsgBox", "XDesconectado"), refaVista.BuscarMensaje("MsgBox", "XObtenerDatosGPS"))
                End If
            End If
#End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#If SO_WCE = 0 Then
    Private Sub UpdateData(ByVal sender As Object, ByVal args As System.EventArgs)
        If bValidando Or bDesconectando Then Exit Sub
        If (oGPS.Opened) Then
            Dim status As String = ""
            Dim datastr As String = ""
            If (Not IsNothing(device)) Then
                'status = device.FriendlyName & " " & device.ServiceState & ", " & device.DeviceState
            End If

            If (Not IsNothing(position)) Then
                If (position.LatitudeValid) Then
                    nLatitudGPS = position.Latitude
                    bLatitudLeido = True
                    datastr = refaVista.BuscarMensaje("MsgBox", "CRGLatitud") & nLatitudGPS & vbCrLf
                End If

                If (position.LongitudeValid) Then
                    nLongitudGPS = position.Longitude
                    bLongitudLeido = True
                    datastr &= refaVista.BuscarMensaje("MsgBox", "CRGLongitud") & nLongitudGPS & vbCrLf
                End If

                If (position.SatellitesInSolutionValid And position.SatellitesInViewValid And position.SatelliteCountValid) Then
                    datastr &= refaVista.BuscarMensaje("MsgBox", "XSatelites") & position.GetSatellitesInSolution().Length & "/" & position.GetSatellitesInView().Length & " (" & position.SatelliteCount & ")" & vbCrLf
                End If

                If (position.TimeValid) Then
                    datastr &= position.Time.ToString("dd/MM/yyyy hh:mm:ss")
                End If
                If bPuntoGPS Then
                    FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("MsgBox", "XPuntoGPS"))
                Else
                    FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("MsgBox", "XAseguraVisita"))
                End If
                FormProcesando.PubSubInformar(datastr, refaVista.BuscarMensaje("MsgBox", "XObtenerDatosGPS"))

                bGPSLeido = bLatitudLeido And bLongitudLeido
                If bGPSLeido Then nContador += 1
                If bGPSLeido And nContador = 10 Then
                    nContador = 0
                    TimerGPS.Enabled = False
                    RemoveHandler oGPS.LocationChanged, AddressOf oGPS_LocationChanged
                    FormProcesando.PubSubInformar()
                    If bPuntoGPS Then
                        RaiseEvent AlmacenarLecturaGPS()
                    Else
                        RaiseEvent VerificarLecturaGPS()
                    End If
                End If
            End If
        End If
    End Sub
#End If

#If SO_WCE = 0 Then
    'Private Sub GPSDeviceStateChanged(ByVal sender As Object, ByVal args As Microsoft.WindowsMobile.Samples.Location.DeviceStateChangedEventArgs)
    '    If bDesconectando Then Exit Sub
    '    device = args.DeviceState

    '    ' call the UpdateData method via the updateDataHandler so that we
    '    ' update the UI on the UI thread
    '    Invoke(updateDataHandler)
    'End Sub

    Private Sub oGPS_LocationChanged(ByVal sender As Object, ByVal args As Microsoft.WindowsMobile.Samples.Location.LocationChangedEventArgs)
        If bDesconectando Then Exit Sub
        position = args.Position

        ' call the UpdateData method via the updateDataHandler so that we
        ' update the UI on the UI thread
        Invoke(updateDataHandler)
    End Sub
#End If

    Private Sub TimerGPS_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerGPS.Tick
        'If Not bGPSLeido Then
        '    DesconectarGps()
        'End If
#If SO_WCE = 0 Then
        RemoveHandler oGPS.LocationChanged, AddressOf oGPS_LocationChanged
#End If
        bValidando = True
        TimerGPS.Enabled = False
        'Cursor.Current = Cursors.Default
        FormProcesando.PubSubInformar()
        If Not bGPSLeido Then
            If bPuntoGPS Then
                If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0206"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, refaVista.BuscarMensaje("MsgBox", "XPuntoGPS")) = MsgBoxResult.Yes Then
                    ObtenerDatosGPS()
                End If
            Else
                If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0206"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, refaVista.BuscarMensaje("MsgBox", "XAseguraVisita")) = MsgBoxResult.Yes Then
                    AsegurarVisitaGPS()
                Else
                    bIniciarVisita = True
                    RaiseEvent VerificarLecturaGPS()
                End If
            End If
        End If
    End Sub

    Private Function ObtenerCoordenadasCliente(ByVal sClienteClave As String) As Boolean
        'Falta agregar validacion de Vendedor.GPS
        If (nTipoIniciarVisita = 2 Or nTipoIniciarVisita = 3) And oVendedor.GPS Then
            Dim sConsulta As String
            Dim dtResult As DataTable
            Dim bResult As Boolean = False
            sConsulta = "select CoordenadaX, CoordenadaY from ClienteDomicilio where ClienteClave = '" & sClienteClave & "' and Tipo = 2"
            dtResult = oDBVen.RealizarConsultaSQL(sConsulta, "ClienteDomicilio")
            If dtResult.Rows.Count > 0 Then
                If Not IsDBNull(dtResult.Rows(0)("CoordenadaX")) Then
                    nLongitudCliente = dtResult.Rows(0)("CoordenadaX")
                    bResult = True
                End If
                If Not IsDBNull(dtResult.Rows(0)("CoordenadaY")) Then
                    nLatitudCliente = dtResult.Rows(0)("CoordenadaY")
                    bResult = bResult And True
                End If
            End If
            Return bResult
        Else
            Return True
        End If
    End Function

    Private Function ValidarDatosGPS() As Boolean
        'Dim nDistancia As Decimal
        nDistanciaGPS = DistanciaAB(nLatitudCliente, nLongitudCliente, nLatitudGPS, nLongitudGPS)
        bIniciarVisita = nDistanciaGPS <= IIf(IsDBNull(oConHist.Campos("LimiteGPS")), 0, oConHist.Campos("LimiteGPS"))
    End Function

    Private Function DistanciaAB(ByVal nLatitudA As Decimal, ByVal nLongitudA As Decimal, ByVal nLatitudB As Decimal, ByVal nLongitudB As Decimal) As Decimal
        Try
            Dim dist As Decimal
            dist = Math.Acos(Math.Sin((nLongitudA * Math.PI) / 180) * Math.Sin((nLongitudB * Math.PI) / 180) + Math.Cos((nLongitudA * Math.PI) / 180) * Math.Cos((nLongitudB * Math.PI) / 180) * Math.Cos(((nLatitudA * Math.PI) / 180) - ((nLatitudB * Math.PI) / 180))) * 6378 * 1000
            'dist = Math.Acos(Math.Sin((nLatitudA * Math.PI) / 180) * Math.Sin((nLatitudB * Math.PI) / 180) + Math.Cos((nLatitudA * Math.PI) / 180) * Math.Cos((nLatitudB * Math.PI) / 180) * Math.Cos(((nLongitudA * Math.PI) / 180) - ((nLongitudB * Math.PI) / 180))) * 6378 * 1000
            Return dist
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

#End Region

#If MOD_TERM <> "PALM" Then
    Private Sub bScanner_Data_Scanned(ByVal Data As String) Handles bScanner.Data_Scanned
        If bEnFiltros Then
            LecturaIdActivo(Data)
        Else
            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()
            CodigoBarras(Data)
            Cursor.Current = Cursors.Default
        End If
    End Sub
#End If

    Private Sub LecturaIdActivo(ByVal parsCodigo As String)
        If CheckBoxIdActivo.Checked Then
            TextBoxIdActivo.Text = parsCodigo
        End If
    End Sub

    Private Sub CodigoBarras(ByVal parsCodigo As String)
        If parsCodigo = "" Then Exit Sub
        bCodigoLeido = True
        Dim dtCliente As DataTable = oDBVen.RealizarConsultaSQL("Select CLI.ClienteClave,AGN.DiaClave from Cliente CLI inner join Agenda AGN on CLI.ClienteClave = AGN.ClienteClave where IDElectronico ='" & parsCodigo & "' and AGN.RUTClave='" & oRutaActual.RUTClave & "'", "Cliente")
        If dtCliente.Rows.Count > 0 Then
            If dtCliente.Select("DiaClave='" & oDia.DiaActual & "'").Length <= 0 Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "I0159"), MsgBoxStyle.Information)
                Me.FueraFrecuencia = True
            End If
            Me.ClienteActual.ClienteClave = dtCliente.Rows(0)("ClienteClave")
            Me.ClienteActual.Recuperar()
            FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("ProcesandoAgenda", "Titulo"))
            FormProcesando.PubSubInformar(refaVista.BuscarMensaje("ProcesandoAgenda", "Buscando"))
            FlexGridClientes.AutoSearchDelay = 10000
            FlexGridClientes.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.None
            Me.DialogResult = Windows.Forms.DialogResult.OK
            dtCliente.Dispose()
            Me.txtNoCliente.Focus()
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            ActivarInactivarLector(False)
            If MsgBox(refaVista.BuscarMensaje("Mensajes", "E0355"), MsgBoxStyle.Critical) = MsgBoxResult.Ok Then
                ActivarInactivarLector(True)
            End If
            bCodigoLeido = False
            Me.txtNoCliente.Text = String.Empty
            dtCliente.Dispose()
            Exit Sub
        End If
    End Sub
    Public Function ClienteAutomatico(ByVal ClienteClave As String, ByVal bLLamarBotonContinuar As Boolean) As Boolean
        'Dim bEncontrado As Boolean

        If ClienteClave = String.Empty Then
            ActivarInactivarLector(False)
            If MsgBox(refaVista.BuscarMensaje("Mensajes", "E0355"), MsgBoxStyle.Critical) = MsgBoxResult.Ok Then
                ActivarInactivarLector(True)
            End If
            Return False
        End If

        Me.txtNoCliente.Text = ClienteClave

        If Not MostrarClientesScaneado(ClienteClave) Then
            ActivarInactivarLector(False)
            If MsgBox(refaVista.BuscarMensaje("Mensajes", "E0355"), MsgBoxStyle.Critical) = MsgBoxResult.Ok Then
                ActivarInactivarLector(True)
            End If
            Return False
        End If

        Dim i As Integer = Me.EncontrarElemento(ClienteClave, Me.FlexGridClientes.Cols("IdElectronico").Index)
        If i <> -1 Then
            Me.ClienteActual.ClienteClave = Me.FlexGridClientes.Item(i, "ClienteClave")
            CTEActual = Me.ClienteActual.ClienteClave
            Me.FlexGridClientes.Row = i
            If bLLamarBotonContinuar Then
                ButtonAgendaContinuar_Click(Me, Nothing)
                Me.txtNoCliente.Text = String.Empty
            End If
            'ButtonClienteContinuar_Click(Me, Nothing)
            'bEncontrado = True
            Return True
        End If
        ActivarInactivarLector(False)
        If MsgBox(refaVista.BuscarMensaje("Mensajes", "E0355"), MsgBoxStyle.Critical) = MsgBoxResult.Ok Then
            ActivarInactivarLector(True)
        End If
        Return False

    End Function

    Private Sub FormClientes_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        RemoveHandler VerificarLecturaGPS, AddressOf VerificarLectura
        DesconectarGps()
        ActivarInactivarLector(False)
    End Sub

    Private Function EncontrarElemento(ByVal pvObjetoBuscado As Object, ByVal iColumna As Integer, Optional ByVal iFilaInicio As Integer = 1, Optional ByVal pvWrap As Boolean = True) As Integer
        Return Me.FlexGridClientes.FindRow(pvObjetoBuscado, iFilaInicio, iColumna, pvWrap)
    End Function


    'Private Sub FlexGridClientes_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.SortColEventArgs) Handles FlexGridClientes.AfterSort
    '    'Me.FlexGridClientes.Row = -1
    '    Me.FlexGridClientes.Row = Me.FlexGridClientes.FindRow(True, 1, 0, False)
    'End Sub

    Private Sub FlexGridClientes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FlexGridClientes.KeyPress
        If DateDiff(DateInterval.Second, dFechaReferencia, Now) > Me.FlexGridClientes.AutoSearchDelay Then
            Me.BorraNoCliente()
            Me.BorrarPatron()
        End If
        dFechaReferencia = Now
        If Me.FlexGridClientes.ColSel <> 0 AndAlso (Char.IsLetterOrDigit(e.KeyChar) OrElse Asc(e.KeyChar) = 32) Then
            Me.txtPatron.Text &= e.KeyChar
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If FlexGridClientes.Col = 0 Then Exit Sub
            If FlexGridClientes.Row > 0 Then
                Me.ClienteActual.ClienteClave = Me.FlexGridClientes.Item(Me.FlexGridClientes.Row, "ClienteClave")
                CTEActual = Me.ClienteActual.ClienteClave
                Me.bCodigoLeido = False
                ButtonAgendaContinuar_Click(Nothing, Nothing)
            End If
        End If
    End Sub


    Private Sub txtNoCliente_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoCliente.GotFocus
        Me.FlexGridClientes.Row = -1
        Me.BorrarPatron()
    End Sub


    Private Sub txtNoCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoCliente.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                Cursor.Current = Cursors.WaitCursor
                Application.DoEvents()
                CodigoBarras(Me.txtNoCliente.Text)
                Cursor.Current = Cursors.Default
        End Select
    End Sub

    Private Sub BorrarPatron()
        Me.txtPatron.Text = String.Empty
    End Sub

    Private Sub BorraNoCliente()
        Me.txtNoCliente.Text = String.Empty
    End Sub

    Private Sub PonerFocusAColumna(ByVal pvIndiceColumna As Integer)
        Try
            Me.FlexGridClientes.Focus()
            Me.FlexGridClientes.Col = pvIndiceColumna
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PonerFocusAColumna(ByVal pvNombreColumna As String)
        Try
            Me.FlexGridClientes.Focus()
            Me.FlexGridClientes.Col = Me.FlexGridClientes.Cols(pvNombreColumna).Index
        Catch ex As Exception

        End Try
    End Sub


    Private Sub MenuItemCuotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCuotas.Click
        ActivarInactivarLector(False)
        Dim oFormCuotas As New FormCuotas(oVendedor.VendedorId)
        oFormCuotas.ShowDialog()
        oFormCuotas.Dispose()
        ActivarInactivarLector(True)
    End Sub

    Private Function ContrasenaCorrecta(ByVal pvContrasena As String, ByVal pvClienteClave As String) As Boolean
        Dim sContrasena As String = Trim(Format(oDia.FechaCaptura, "ddMMyyyy") & pvClienteClave.ToUpper & Me.RutaActual.RUTClave.ToUpper)
        Return (Trim(pvContrasena.ToUpper) = sContrasena.Replace("-", ""))
    End Function

    Private Sub MostrarPanelContrasena(ByVal pvMostrar As Boolean)
        With Me.PanelContrasena
            If pvMostrar Then
                ActivarInactivarLector(False)
                Me.Panel1.Visible = False
                Me.MenuItemVer.Enabled = False
                .Visible = True
                Me.textContrasena.Text = String.Empty
                Me.textContrasena.Focus()
            Else
                ActivarInactivarLector(True)
                Me.Panel1.Visible = True
                .Visible = False
                Me.MenuItemVer.Enabled = True
            End If
        End With
    End Sub

    Private Sub ButtonAceptarContrasena_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAceptarContrasena.Click
        If AceptarContrasena() Then
            AsegurarVisitaGPS()
            'MostrarDetalleCliente()
        End If
    End Sub

    Private Sub ButtonCancelarContrasena_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancelarContrasena.Click
        Me.MostrarPanelContrasena(False)
    End Sub

    Private Sub textContrasena_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles textContrasena.KeyDown
        If e.KeyCode = Keys.Enter Then
            If AceptarContrasena() Then
                AsegurarVisitaGPS()
                'MostrarDetalleCliente()
            End If
        End If
    End Sub

    Private Function AceptarContrasena() As Boolean
        Dim indiceCliente As Integer = Me.FlexGridClientes.Row
        If Not Me.ContrasenaCorrecta(Me.textContrasena.Text, Me.FlexGridClientes.GetData(indiceCliente, "Clave").ToString) Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0210"), MsgBoxStyle.Critical, "Amesol Route")
            Me.MostrarPanelContrasena(False)
            Return False
        End If
        Me.MostrarPanelContrasena(False)
        Return True
    End Function

    Private Sub pbBateria_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbBateria.Click
        RefrescarStatusBateria()
    End Sub

    Private Sub MenuItemPromocion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemPromocion.Click
        ActivarInactivarLector(False)
        Dim indiceCliente As Integer = Me.FlexGridClientes.Row
        If indiceCliente <> -1 Then
            Dim oReportePromociones As New FormResumenPromociones(Me.FlexGridClientes.GetData(indiceCliente, "ClienteClave").ToString)
            oReportePromociones.ShowDialog()
            oReportePromociones.Dispose()
        Else
            Dim oReportePromociones As New FormResumenPromociones(String.Empty)
            oReportePromociones.ShowDialog()
            oReportePromociones.Dispose()
        End If
        ActivarInactivarLector(True)
    End Sub

    Private Sub MenuItemListasPrecios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemListasPrecios.Click
        ActivarInactivarLector(False)
        Dim indiceCliente As Integer = Me.FlexGridClientes.Row
        If indiceCliente <> -1 Then
            Dim oFormListasPrecios As New FormListasPrecios(Me.FlexGridClientes.GetData(indiceCliente, "ClienteClave").ToString)
            oFormListasPrecios.ShowDialog()
            oFormListasPrecios.Dispose()
        Else
            Dim oFormListasPrecios As New FormListasPrecios
            oFormListasPrecios.ShowDialog()
            oFormListasPrecios.Dispose()
        End If
        ActivarInactivarLector(True)
    End Sub

    Private Sub MenuItemVerFueraFrecuencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemVerFueraFrecuencia.Click
        ActivarInactivarLector(False)
        Dim oFormFiltroClientes As New FormFiltroClientesFueraFrecuencia(oRutaActual)
        If oFormFiltroClientes.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.ClienteActual = oFormFiltroClientes.ClienteActual
            Me.FueraFrecuencia = True
            FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("ProcesandoAgenda", "Titulo"))
            FormProcesando.PubSubInformar(refaVista.BuscarMensaje("ProcesandoAgenda", "Buscando"))
            oFormFiltroClientes.Dispose()
            oFormFiltroClientes = Nothing
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
            Exit Sub
        Else
            ActivarInactivarLector(True)
        End If
        oFormFiltroClientes.Dispose()
        oFormFiltroClientes = Nothing
    End Sub


    Private Sub MenuItemEnvio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemEnvio.Click
        'FormProcesando.PubSubTitulo(Me.refaVista.BuscarMensaje("Procesando", "Titulo"))
        Dim sMensaje As String = String.Empty
        Dim oFormComunicacion As New FormComunicacion
        Try
            FormProcesando.PubSubInformar("Conectando", "Checking Connection")
            MenuItemEnvio.Enabled = False
            If Not oFormComunicacion.ProbarConexion() Then
                oFormComunicacion.Dispose()
                MenuItemEnvio.Enabled = True
                Exit Sub
            End If
            FormProcesando.PubSubTitulo("")
            oFormComunicacion.EnviarCaptura(sMensaje, True, refaVista)
            oApp.DesactivarWiFi()
            oApp.desconectarRAS()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try

        If sMensaje <> "" Then
            MsgBox(sMensaje, MsgBoxStyle.Exclamation)
        End If
        FormProcesando.PubSubTitulo("")
        oFormComunicacion.Dispose()
        MenuItemEnvio.Enabled = True
    End Sub

    'Se quito el codigo del menu contextual porque el Eliminar estaba incorrecto
    'Private Sub ContextMenu1_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenu1.Popup
    '    MostrarContext()
    'End Sub
    'Private Sub MostrarContext()
    '    ActivarInactivarLector(False)

    '    ContextMenuClientes.Show(Me, Control.MousePosition)
    '    ActivarInactivarLector(True)
    'End Sub

    Private Sub ButtonFiltrarClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFiltrarClientes.Click
        bEnFiltros = True
#If MOD_TERM <> "PALM" Then
        If Not Me.bLectorActivo Then
            ActivarInactivarLector(True)
        End If
#End If
        Me.Panel1.SendToBack()
        Me.Panel1.Visible = False
        Me.PanelBusquedaCli.BringToFront()
        Me.PanelBusquedaCli.Visible = True
        Me.MenuItemMasInfo.Enabled = False
        Me.MenuItemVer.Enabled = False
        If oConHist.Campos("EnvioParcial") Then Me.MenuItemEnvio.Enabled = False
    End Sub

    Private Sub ButtonContinuarBusqueda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuarBusqueda.Click
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        If ValidaCampos() Then
            CreaCondiciones()
            'FiltrarClientes()
            MostrarClientes(5)
            Me.PanelBusquedaCli.SendToBack()
            Me.PanelBusquedaCli.Visible = False
            Me.Panel1.BringToFront()
            Me.Panel1.Visible = True
            Me.MenuItemMasInfo.Enabled = True
            Me.MenuItemVer.Enabled = True
            If oConHist.Campos("EnvioParcial") Then Me.MenuItemEnvio.Enabled = True
            bEnFiltros = False
#If MOD_TERM <> "PALM" Then
            If Not ((nTipoIniciarVisita = 1 Or Me.nTipoIniciarVisita = 3) And Me.bLeerCodigoCliente) Then
                ActivarInactivarLector(False)
            End If
#End If
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub CheckBoxIdActivo_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxIdActivo.CheckStateChanged
        ComboBoxIdActivo.Enabled = CheckBoxIdActivo.Checked
        TextBoxIdActivo.Enabled = CheckBoxIdActivo.Checked
    End Sub

    Private Sub CheckBoxRazonSocial_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxRazonSocial.CheckStateChanged
        ComboBoxRazonSocial.Enabled = CheckBoxRazonSocial.Checked
        TextBoxRazonSocial.Enabled = CheckBoxRazonSocial.Checked
    End Sub

    Private Sub CheckBoxContacto_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxContacto.CheckStateChanged
        ComboBoxContacto.Enabled = CheckBoxContacto.Checked
        TextBoxContacto.Enabled = CheckBoxContacto.Checked
    End Sub

    Private Sub CheckBoxCalle_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxCalle.CheckStateChanged
        ComboBoxCalle.Enabled = CheckBoxCalle.Checked
        TextBoxCalle.Enabled = CheckBoxCalle.Checked
    End Sub

    Private Sub CheckBoxReferenciaDom_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxReferenciaDom.CheckStateChanged
        ComboBoxReferenciaDom.Enabled = CheckBoxReferenciaDom.Checked
        TextBoxReferenciaDom.Enabled = CheckBoxReferenciaDom.Checked
    End Sub

    Private Sub CheckBoxExterior_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxExterior.CheckStateChanged
        ComboBoxExterior.Enabled = CheckBoxExterior.Checked
        TextBoxExterior.Enabled = CheckBoxExterior.Checked
    End Sub

    Private Sub CheckBoxInterior_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxInterior.CheckStateChanged
        ComboBoxInterior.Enabled = CheckBoxInterior.Checked
        TextBoxInterior.Enabled = CheckBoxInterior.Checked
    End Sub

    Private Sub CheckBoxColonia_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxColonia.CheckStateChanged
        ComboBoxColonia.Enabled = CheckBoxColonia.Checked
        TextBoxColonia.Enabled = CheckBoxColonia.Checked
    End Sub

    Private Function ValidaCampos() As Boolean
        If CheckBoxIdActivo.Checked Then
            If IsNothing(ComboBoxIdActivo.SelectedValue) Or TextBoxIdActivo.Text = "" Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.CheckBoxIdActivo.Text))
                If IsNothing(ComboBoxIdActivo.SelectedValue) Then
                    ComboBoxIdActivo.Focus()
                Else
                    TextBoxIdActivo.Focus()
                End If
                Return False
            End If
        End If

        If CheckBoxRazonSocial.Checked Then
            If IsNothing(ComboBoxRazonSocial.SelectedValue) Or TextBoxRazonSocial.Text = "" Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.CheckBoxRazonSocial.Text))
                If IsNothing(ComboBoxRazonSocial.SelectedValue) Then
                    ComboBoxRazonSocial.Focus()
                Else
                    TextBoxRazonSocial.Focus()
                End If
                Return False
            End If
        End If

        If CheckBoxContacto.Checked Then
            If IsNothing(ComboBoxContacto.SelectedValue) Or TextBoxContacto.Text = "" Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.CheckBoxContacto.Text))
                If IsNothing(ComboBoxContacto.SelectedValue) Then
                    ComboBoxContacto.Focus()
                Else
                    TextBoxContacto.Focus()
                End If
                Return False
            End If
        End If

        If CheckBoxCalle.Checked Then
            If IsNothing(ComboBoxCalle.SelectedValue) Or TextBoxCalle.Text = "" Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.CheckBoxCalle.Text))
                If IsNothing(ComboBoxCalle.SelectedValue) Then
                    ComboBoxCalle.Focus()
                Else
                    TextBoxCalle.Focus()
                End If
                Return False
            End If
        End If

        If CheckBoxExterior.Checked Then
            If IsNothing(ComboBoxExterior.SelectedValue) Or TextBoxExterior.Text = "" Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.CheckBoxExterior.Text))
                If IsNothing(ComboBoxExterior.SelectedValue) Then
                    ComboBoxExterior.Focus()
                Else
                    TextBoxExterior.Focus()
                End If
                Return False
            End If
        End If

        If CheckBoxInterior.Checked Then
            If IsNothing(ComboBoxInterior.SelectedValue) Or TextBoxInterior.Text = "" Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.CheckBoxInterior.Text))
                If IsNothing(ComboBoxInterior.SelectedValue) Then
                    ComboBoxInterior.Focus()
                Else
                    TextBoxInterior.Focus()
                End If
                Return False
            End If
        End If

        If CheckBoxColonia.Checked Then
            If IsNothing(ComboBoxColonia.SelectedValue) Or TextBoxColonia.Text = "" Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.CheckBoxColonia.Text))
                If IsNothing(ComboBoxColonia.SelectedValue) Then
                    ComboBoxColonia.Focus()
                Else
                    TextBoxColonia.Focus()
                End If
                Return False
            End If
        End If

        If CheckBoxReferenciaDom.Checked Then
            If IsNothing(ComboBoxReferenciaDom.SelectedValue) Or TextBoxReferenciaDom.Text = "" Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.CheckBoxReferenciaDom.Text))
                If IsNothing(ComboBoxReferenciaDom.SelectedValue) Then
                    ComboBoxReferenciaDom.Focus()
                Else
                    TextBoxReferenciaDom.Focus()
                End If
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub CreaCondiciones()
        sFiltroClientes = ""
        If CheckBoxIdActivo.Checked Then
            sFiltroClientes = " Clave " & Operador(ComboBoxIdActivo.SelectedValue, Me.TextBoxIdActivo.Text)
        End If

        If CheckBoxRazonSocial.Checked Then
            If sFiltroClientes <> "" Then
                sFiltroClientes &= " AND "
            End If
            sFiltroClientes &= " RazonSocial " & Operador(ComboBoxRazonSocial.SelectedValue, Me.TextBoxRazonSocial.Text)
        End If

        If CheckBoxContacto.Checked Then
            If sFiltroClientes <> "" Then
                sFiltroClientes &= " AND "
            End If
            sFiltroClientes &= " NombreContacto " & Operador(ComboBoxContacto.SelectedValue, Me.TextBoxContacto.Text)
        End If

        If CheckBoxCalle.Checked Then
            If sFiltroClientes <> "" Then
                sFiltroClientes &= " AND "
            End If
            sFiltroClientes &= " Calle " & Operador(ComboBoxCalle.SelectedValue, Me.TextBoxCalle.Text)
        End If

        If CheckBoxExterior.Checked Then
            If sFiltroClientes <> "" Then
                sFiltroClientes &= " AND "
            End If
            sFiltroClientes &= " Numero " & Operador(ComboBoxExterior.SelectedValue, Me.TextBoxExterior.Text)
        End If

        If CheckBoxInterior.Checked Then
            If sFiltroClientes <> "" Then
                sFiltroClientes &= " AND "
            End If
            sFiltroClientes &= " NumInt " & Operador(ComboBoxInterior.SelectedValue, Me.TextBoxInterior.Text)
        End If

        If CheckBoxColonia.Checked Then
            If sFiltroClientes <> "" Then
                sFiltroClientes &= " AND "
            End If
            sFiltroClientes &= " Colonia " & Operador(ComboBoxColonia.SelectedValue, Me.TextBoxColonia.Text)
        End If

        If CheckBoxReferenciaDom.Checked Then
            If sFiltroClientes <> "" Then
                sFiltroClientes &= " AND "
            End If
            sFiltroClientes &= " ReferenciaDom " & Operador(ComboBoxReferenciaDom.SelectedValue, Me.TextBoxReferenciaDom.Text)
        End If
    End Sub

    Private Function Operador(ByVal VAVClave As Integer, ByVal sValor1 As String, Optional ByVal sValor2 As String = "") As String
        Select Case VAVClave
            Case 1 'Igual
                Return " = '" & sValor1 & "'"
            Case 2 'Diferente
                Return " <> '" & sValor1 & "'"
            Case 3 'Empiece con
                Return " like '" & sValor1 & "%'"
            Case 4 'Termine con
                Return " like '%" & sValor1 & "'"
            Case 5 'Contenga
                Return " like '%" & sValor1 & "%" & sValor2 & "%'"
            Case 6 'No contenga
                Return " not like '%" & sValor1 & "%'"
        End Select
        Return String.Empty
    End Function

    Private Sub FiltrarClientes()
        CType(FlexGridClientes.DataSource, DataView).RowFilter = sFiltroClientes
    End Sub

    Private Sub ButtonGPS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGPS.Click
        Dim oFormPuntoGPS As New FormPuntoGPS()
        oFormPuntoGPS.RutaActual = Me.RutaActual
#If SO_WCE = 0 Then
        oFormPuntoGPS.oGPS = oGPS
#End If
        oFormPuntoGPS.ShowDialog()
        oFormPuntoGPS.Dispose()
        oFormPuntoGPS = Nothing
    End Sub



End Class
