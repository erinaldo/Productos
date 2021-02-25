Imports System.Data.SqlServerCe

Public Class FormMovProducto
    Inherits System.Windows.Forms.Form

    Protected oTransProdGenerico As TransProd
    Protected aTransProd As Generic.Dictionary(Of String, TransProd)
    Protected aTransProdFactura As Generic.Dictionary(Of String, TransProd)
    Protected aTRPDatoFiscal As Generic.Dictionary(Of String, TRPDatoFiscal)
    Protected aDetailViewTotales As Generic.Dictionary(Of String, Resco.Controls.DetailView.DetailView)
    Protected aControlesFactura As Generic.Dictionary(Of String, Generic.Dictionary(Of String, Control))
    Protected oTransProdDevolucion As TransProd
    Protected oTransProdNota As TransProd
    Protected oProducto As Producto
    Protected oImpuesto As Impuesto
    Protected oDescuentoCliente As Descuento
    Protected oPromocion As Promocion
    Protected aTipoCodigoMonedas As New Generic.Dictionary(Of String, Integer)
    'Protected oTransProd As TransProd
    Private bSurtir As Boolean = False
    Private sVisitaActual As String = ""
    Private bGuardado As Boolean = False
    Private bHuboCambios As Boolean = False
    Private blnEditandoDescuento As Boolean = False
    Private bFinalizando As Boolean = False
    Private sNota As String = ""
    Private bMetodoConfig As Boolean
    Private nTipoNoIdent As Int16
    Private bCapturaGrid As Boolean
    Private bEfectivoSel As Boolean
    Private bNoIdentificadoSel As Boolean
    Private aEfectivo As ArrayList

    Private Const amp = "&amp;" '&
    Private Const quot = "&quot;" '"
    Private Const lt = "&lt;" '<
    Private Const gt = "&gt;" '>
    Private Const apos = "&#36;" ''

#Region "Propiedades"
    Public ReadOnly Property ArrayTransProd() As Generic.Dictionary(Of String, TransProd)
        Get
            Return aTransProd
        End Get
    End Property
    'Public Property TransProd() As TransProd
    '    Get
    '        Return oTransProd
    '    End Get
    '    Set(ByVal value As TransProd)
    '        oTransProd = value
    '    End Set
    'End Property

    Public Property TransProdDevolucion() As TransProd
        Get
            Return oTransProdDevolucion
        End Get
        Set(ByVal Value As TransProd)
            oTransProdDevolucion = Value
        End Set
    End Property
    Public Property Producto() As Producto
        Get
            Return oProducto
        End Get
        Set(ByVal Value As Producto)
            oProducto = Value
        End Set
    End Property
    Public Property Impuesto() As Impuesto
        Get
            Return oImpuesto
        End Get
        Set(ByVal Value As Impuesto)
            oImpuesto = Value
        End Set
    End Property
    Public Property DescuentoCliente() As Descuento
        Get
            Return oDescuentoCliente
        End Get
        Set(ByVal Value As Descuento)
            oDescuentoCliente = Value
        End Set
    End Property
    Public Property Promocion() As Promocion
        Get
            Return oPromocion
        End Get
        Set(ByVal Value As Promocion)
            oPromocion = Value
        End Set
    End Property

    Public Property Transaccion() As SqlCeTransaction
        Get
            Return oDBVen.Transaccion
        End Get
        Set(ByVal Value As SqlCeTransaction)
            oDBVen.Transaccion = Value
        End Set
    End Property

#End Region

#Region "Variables"
    Private Const ConstPosTabPageMovimientos = 0
    Private Const ConstPosTabPageTotales = 1
    Private Const ConstPosTabPageProductoNegado = 2
    Private Const ConstPosTabPageNoEntregados = 3

    Private Const ConstPosProductoClave = 0

    Private Const ConstIndiceCodigoSKU = 3
    Private Const ConstIndiceTransProdDetalleID = 7
    Private Const ConstIndiceTipoBonificacion = 8


    Private bRecalcularTotales As Boolean = True

    Public OrigenAdelante As Boolean = True

    Private bEnProceso As Boolean
    Private bIniciando As Boolean = True
    Private _BModFeC As Boolean = False
    Private bEsNuevo As Boolean
    Private bYaSePoblo As Boolean = False
    Private bLector As Boolean = False
    Private bAceptarPromociones As Boolean = False
    Private aDescuentosCliente As New ArrayList
    Private refaVista As Vista
#If MOD_TERM <> "PALM" Then
    Private WithEvents bScanner As New HANDHELD.CScanner
#End If
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabControlMovProducto As System.Windows.Forms.TabControl
    Friend WithEvents TabPageMovimientos As System.Windows.Forms.TabPage
    Friend WithEvents TextBoxCodigo As System.Windows.Forms.TextBox
    Friend WithEvents LabelCodigo As System.Windows.Forms.Label
    Friend WithEvents fgMovimientos As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TextBoxProducto As System.Windows.Forms.TextBox
    Friend WithEvents ButtonVer As System.Windows.Forms.Button
    Friend WithEvents LabelProducto As System.Windows.Forms.Label
    Friend WithEvents TabPageTotales As System.Windows.Forms.TabPage
    Friend WithEvents ButtonImpuestos As System.Windows.Forms.Button
    Friend WithEvents ButtonDetalleContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonDetalleRegresar As System.Windows.Forms.Button
    Friend WithEvents TabPageProductoNegado As System.Windows.Forms.TabPage
    Friend WithEvents fgProductoNegado As C1.Win.C1FlexGrid.C1FlexGrid

    Dim WaitAnyEvents As Threading.AutoResetEvent
    Friend WithEvents PanelFondoCristal As System.Windows.Forms.Panel
    Friend WithEvents ButtonContinuarFondoCristal As System.Windows.Forms.Button
    Friend WithEvents fgFondoCristal As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents LabelFondoCristal As System.Windows.Forms.Label
    Friend WithEvents TextBoxTotalFondoCristal As System.Windows.Forms.TextBox
    Friend WithEvents LabelTotalFondoCristal As System.Windows.Forms.Label

    Dim dTotalFondoCristal As Double = 0
    Dim blnScannerActivo As Boolean = True
    Public Terminar As Boolean
    Friend WithEvents TabPageNoEntregados As System.Windows.Forms.TabPage
    Friend WithEvents fgNoEntregados As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Private nTotalInicial As Double
    Friend WithEvents CheckBoxProducto As System.Windows.Forms.CheckBox
    Friend WithEvents MenuItemDevolucion As System.Windows.Forms.MenuItem
    Private dTotalInicialCredito As Double
    Private nCFVTipoInicial As Integer
    Friend WithEvents TabControlTotalesMoneda As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DetailViewTotalesMoneda As Resco.Controls.DetailView.DetailView
    Friend WithEvents DetailViewGeneral As Resco.Controls.DetailView.DetailView
    Friend WithEvents DetailViewGranTotal As Resco.Controls.DetailView.DetailView
    Friend WithEvents DetailViewPie As Resco.Controls.DetailView.DetailView
    Friend WithEvents PanelDatosFacturacion As System.Windows.Forms.Panel
    Friend WithEvents ButtonContinuarDatFac As System.Windows.Forms.Button
    Friend WithEvents DetailViewDatosFiscales As Resco.Controls.DetailView.DetailView
    Friend WithEvents PanelFacturas As System.Windows.Forms.Panel
    Friend WithEvents TabControlFacturas As System.Windows.Forms.TabControl
    Friend WithEvents TabPageFactura As System.Windows.Forms.TabPage
    Friend WithEvents btnContinuarFacturas As System.Windows.Forms.Button
    Friend WithEvents txtFolioFac As System.Windows.Forms.TextBox
    Friend WithEvents lbFolioFac As System.Windows.Forms.Label
    Friend WithEvents txtFechaFac As System.Windows.Forms.TextBox
    Friend WithEvents lbFechaFac As System.Windows.Forms.Label
    Friend WithEvents txtFormaPagoFac As System.Windows.Forms.TextBox
    Friend WithEvents lbFormaPagoFac As System.Windows.Forms.Label
    Friend WithEvents ListViewMetodosPago As System.Windows.Forms.ListView
    Friend WithEvents grdMetodoPago As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtOrdenCompra As System.Windows.Forms.TextBox
    Friend WithEvents lbOrdenCompra As System.Windows.Forms.Label
    Friend WithEvents ContextMenuMetodo As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemEliminarMet As System.Windows.Forms.MenuItem
    Private sClientePagoIdInicial As String
#End Region

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByRef refparoTransProd As TransProd, Optional ByRef refbSurtir As Boolean = False, Optional ByRef refsVisitaClave As String = "")
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        If g_SO = SO.WindowsCE Then
            Call InTheHand.Windows.Forms.ContextMenuHelper.HookAllControls(Me.Controls)
        End If

        oTransProdGenerico = refparoTransProd

        aTransProd = New Generic.Dictionary(Of String, TransProd)
        aTransProdFactura = New Generic.Dictionary(Of String, TransProd)
        aTRPDatoFiscal = New Generic.Dictionary(Of String, TRPDatoFiscal)

        aDetailViewTotales = New Generic.Dictionary(Of String, Resco.Controls.DetailView.DetailView)

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        fgMovimientos.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)

        fgProductoNegado.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)

        fgNoEntregados.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        bSurtir = refbSurtir
        sVisitaActual = refsVisitaClave
        Me.Producto = New Producto
        Me.Impuesto = New Impuesto
        Me.oDescuentoCliente = New Descuento
        Me.Promocion = New Promocion
    End Sub

    Private Sub QuitarControlSeguimiento()
        If Not IsNothing(fgMovimientos) Then
            If oVendedor.motconfiguracion.Secuencia Then
                If ctrlSeguimiento.Incluido And Not ctrlSeguimiento.Parent Is Nothing Then
                    RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                    RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                    ctrlSeguimiento.QuitarMenuItem(MainMenuMovProducto)
                    Me.Controls.Remove(ctrlSeguimiento)
                End If
            Else
                For Each ctrl As Control In Me.Controls
                    If ctrl.Name = "lbNombreActividad" Then
                        Me.Controls.Remove(ctrl)
                        ctrl.Dispose()
                        ctrl = Nothing
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        bFinalizando = True
        QuitarControlSeguimiento()

        If Not IsNothing(fgMovimientos) Then
            fgMovimientos.ContextMenu = Nothing
            fgMovimientos.Dispose()
        End If

        fgMovimientos = Nothing
        If Not IsNothing(fgProductoNegado) Then fgProductoNegado.Dispose()
        fgProductoNegado = Nothing
        If Not IsNothing(fgFondoCristal) Then fgFondoCristal.Dispose()
        fgFondoCristal = Nothing
        If Not IsNothing(fgNoEntregados) Then fgNoEntregados.Dispose()
        fgNoEntregados = Nothing
        If Not IsNothing(DetailViewTotalesMoneda) Then DetailViewTotalesMoneda.Dispose()
        DetailViewTotalesMoneda = Nothing
        If Not IsNothing(Me.DetailViewPie) Then Me.DetailViewPie.Dispose()
        DetailViewPie = Nothing
        If Not IsNothing(Me.TextBoxProducto) Then TextBoxProducto.Dispose()
        If Not IsNothing(Me.TextBoxCodigo) Then TextBoxCodigo.Dispose()
        If Not IsNothing(Me.TextBoxTotalFondoCristal) Then TextBoxTotalFondoCristal.Dispose()
        If Not IsNothing(Me.LabelProducto) Then LabelProducto.Dispose()
        If Not IsNothing(Me.LabelCodigo) Then LabelCodigo.Dispose()
        If Not IsNothing(Me.LabelFondoCristal) Then LabelFondoCristal.Dispose()
        If Not IsNothing(Me.LabelTotalFondoCristal) Then LabelTotalFondoCristal.Dispose()
        If Not IsNothing(TabPageMovimientos) Then TabPageMovimientos.Dispose()
        If Not IsNothing(TabPageNoEntregados) Then TabPageNoEntregados.Dispose()
        If Not IsNothing(TabPageProductoNegado) Then TabPageProductoNegado.Dispose()
        If Not IsNothing(TabPageTotales) Then TabPageProductoNegado.Dispose()
        If Not IsNothing(TabControlMovProducto) Then TabControlMovProducto.Dispose()

        If Not IsNothing(MenuItemAgregar) Then MenuItemAgregar.Dispose()
        If Not IsNothing(MenuItemBorrar) Then MenuItemBorrar.Dispose()
        If Not IsNothing(MenuItemGeneral) Then MenuItemGeneral.Dispose()
        If Not IsNothing(MenuItemModificar) Then MenuItemModificar.Dispose()
        If Not IsNothing(MenuItemRegresar) Then MenuItemRegresar.Dispose()
        If Not IsNothing(MainMenuMovProducto) Then MainMenuMovProducto.Dispose()
        If Not IsNothing(ContextMenuMovimientos) Then ContextMenuMovimientos.Dispose()
        If Not IsNothing(ContextMenu1) Then ContextMenu1.Dispose()

        Impuesto = Nothing
        Producto = Nothing
        oTransProdGenerico = Nothing
        DescuentoCliente = Nothing
        Promocion = Nothing
        ContextMenuMovimientos = Nothing
        ContextMenu1 = Nothing
        sNota = Nothing
#If MOD_TERM <> "PALM" Then
        If Not IsNothing(bScanner) Then bScanner.Dispose()
        bScanner = Nothing
#End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents MainMenuMovProducto As System.Windows.Forms.MainMenu
    Friend WithEvents InputPanelMovProducto As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemGeneral As System.Windows.Forms.MenuItem
    Friend WithEvents ContextMenuMovimientos As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemBorrar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemAgregar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemModificar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMovProducto))
        Dim Item1 As Resco.Controls.DetailView.Item = New Resco.Controls.DetailView.Item
        Dim Item2 As Resco.Controls.DetailView.Item = New Resco.Controls.DetailView.Item
        Dim Item3 As Resco.Controls.DetailView.Item = New Resco.Controls.DetailView.Item
        Dim Item4 As Resco.Controls.DetailView.Item = New Resco.Controls.DetailView.Item
        Dim Item5 As Resco.Controls.DetailView.Item = New Resco.Controls.DetailView.Item
        Dim Item6 As Resco.Controls.DetailView.Item = New Resco.Controls.DetailView.Item
        Dim Item7 As Resco.Controls.DetailView.Item = New Resco.Controls.DetailView.Item
        Dim ItemComboBox1 As Resco.Controls.DetailView.ItemComboBox = New Resco.Controls.DetailView.ItemComboBox
        Dim ItemTextBox1 As Resco.Controls.DetailView.ItemTextBox = New Resco.Controls.DetailView.ItemTextBox
        Me.ContextMenuMovimientos = New System.Windows.Forms.ContextMenu
        Me.MenuItemAgregar = New System.Windows.Forms.MenuItem
        Me.MenuItemBorrar = New System.Windows.Forms.MenuItem
        Me.MenuItemModificar = New System.Windows.Forms.MenuItem
        Me.MenuItemDevolucion = New System.Windows.Forms.MenuItem
        Me.MainMenuMovProducto = New System.Windows.Forms.MainMenu
        Me.MenuItemGeneral = New System.Windows.Forms.MenuItem
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.InputPanelMovProducto = New Microsoft.WindowsCE.Forms.InputPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControlMovProducto = New System.Windows.Forms.TabControl
        Me.TabPageMovimientos = New System.Windows.Forms.TabPage
        Me.CheckBoxProducto = New System.Windows.Forms.CheckBox
        Me.TextBoxCodigo = New System.Windows.Forms.TextBox
        Me.LabelCodigo = New System.Windows.Forms.Label
        Me.fgMovimientos = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.DetailViewPie = New Resco.Controls.DetailView.DetailView
        Me.TextBoxProducto = New System.Windows.Forms.TextBox
        Me.ButtonVer = New System.Windows.Forms.Button
        Me.LabelProducto = New System.Windows.Forms.Label
        Me.TabPageTotales = New System.Windows.Forms.TabPage
        Me.TabControlTotalesMoneda = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.DetailViewTotalesMoneda = New Resco.Controls.DetailView.DetailView
        Me.ButtonImpuestos = New System.Windows.Forms.Button
        Me.ButtonDetalleContinuar = New System.Windows.Forms.Button
        Me.ButtonDetalleRegresar = New System.Windows.Forms.Button
        Me.DetailViewGeneral = New Resco.Controls.DetailView.DetailView
        Me.DetailViewGranTotal = New Resco.Controls.DetailView.DetailView
        Me.TabPageProductoNegado = New System.Windows.Forms.TabPage
        Me.fgProductoNegado = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.TabPageNoEntregados = New System.Windows.Forms.TabPage
        Me.fgNoEntregados = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.PanelFondoCristal = New System.Windows.Forms.Panel
        Me.TextBoxTotalFondoCristal = New System.Windows.Forms.TextBox
        Me.LabelTotalFondoCristal = New System.Windows.Forms.Label
        Me.LabelFondoCristal = New System.Windows.Forms.Label
        Me.ButtonContinuarFondoCristal = New System.Windows.Forms.Button
        Me.fgFondoCristal = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.PanelDatosFacturacion = New System.Windows.Forms.Panel
        Me.ButtonContinuarDatFac = New System.Windows.Forms.Button
        Me.DetailViewDatosFiscales = New Resco.Controls.DetailView.DetailView
        Me.PanelFacturas = New System.Windows.Forms.Panel
        Me.btnContinuarFacturas = New System.Windows.Forms.Button
        Me.TabControlFacturas = New System.Windows.Forms.TabControl
        Me.TabPageFactura = New System.Windows.Forms.TabPage
        Me.txtOrdenCompra = New System.Windows.Forms.TextBox
        Me.lbOrdenCompra = New System.Windows.Forms.Label
        Me.ListViewMetodosPago = New System.Windows.Forms.ListView
        Me.txtFormaPagoFac = New System.Windows.Forms.TextBox
        Me.lbFormaPagoFac = New System.Windows.Forms.Label
        Me.txtFechaFac = New System.Windows.Forms.TextBox
        Me.lbFechaFac = New System.Windows.Forms.Label
        Me.txtFolioFac = New System.Windows.Forms.TextBox
        Me.lbFolioFac = New System.Windows.Forms.Label
        Me.grdMetodoPago = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ContextMenuMetodo = New System.Windows.Forms.ContextMenu
        Me.MenuItemEliminarMet = New System.Windows.Forms.MenuItem
        Me.Panel1.SuspendLayout()
        Me.TabControlMovProducto.SuspendLayout()
        Me.TabPageMovimientos.SuspendLayout()
        Me.TabPageTotales.SuspendLayout()
        Me.TabControlTotalesMoneda.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPageProductoNegado.SuspendLayout()
        Me.TabPageNoEntregados.SuspendLayout()
        Me.PanelFondoCristal.SuspendLayout()
        Me.PanelDatosFacturacion.SuspendLayout()
        Me.PanelFacturas.SuspendLayout()
        Me.TabControlFacturas.SuspendLayout()
        Me.TabPageFactura.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuMovimientos
        '
        Me.ContextMenuMovimientos.MenuItems.Add(Me.MenuItemAgregar)
        Me.ContextMenuMovimientos.MenuItems.Add(Me.MenuItemBorrar)
        Me.ContextMenuMovimientos.MenuItems.Add(Me.MenuItemModificar)
        Me.ContextMenuMovimientos.MenuItems.Add(Me.MenuItemDevolucion)
        '
        'MenuItemAgregar
        '
        Me.MenuItemAgregar.Text = "MenuItemAgregar"
        '
        'MenuItemBorrar
        '
        Me.MenuItemBorrar.Text = "MenuItemBorrar"
        '
        'MenuItemModificar
        '
        Me.MenuItemModificar.Text = "MenuItemModificar"
        '
        'MenuItemDevolucion
        '
        Me.MenuItemDevolucion.Text = "MenuItemDevolver"
        '
        'MainMenuMovProducto
        '
        Me.MainMenuMovProducto.MenuItems.Add(Me.MenuItemGeneral)
        '
        'MenuItemGeneral
        '
        Me.MenuItemGeneral.MenuItems.Add(Me.MenuItemRegresar)
        Me.MenuItemGeneral.Text = "MenuItemGeneral"
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControlMovProducto)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'TabControlMovProducto
        '
        Me.TabControlMovProducto.Controls.Add(Me.TabPageMovimientos)
        Me.TabControlMovProducto.Controls.Add(Me.TabPageTotales)
        Me.TabControlMovProducto.Controls.Add(Me.TabPageProductoNegado)
        Me.TabControlMovProducto.Controls.Add(Me.TabPageNoEntregados)
        Me.TabControlMovProducto.Dock = System.Windows.Forms.DockStyle.None
        Me.TabControlMovProducto.Location = New System.Drawing.Point(0, 0)
        Me.TabControlMovProducto.Name = "TabControlMovProducto"
        Me.TabControlMovProducto.SelectedIndex = 0
        Me.TabControlMovProducto.Size = New System.Drawing.Size(242, 295)
        Me.TabControlMovProducto.TabIndex = 1
        '
        'TabPageMovimientos
        '
        Me.TabPageMovimientos.Controls.Add(Me.CheckBoxProducto)
        Me.TabPageMovimientos.Controls.Add(Me.TextBoxCodigo)
        Me.TabPageMovimientos.Controls.Add(Me.LabelCodigo)
        Me.TabPageMovimientos.Controls.Add(Me.fgMovimientos)
        Me.TabPageMovimientos.Controls.Add(Me.DetailViewPie)
        Me.TabPageMovimientos.Controls.Add(Me.TextBoxProducto)
        Me.TabPageMovimientos.Controls.Add(Me.ButtonVer)
        Me.TabPageMovimientos.Controls.Add(Me.LabelProducto)
        Me.TabPageMovimientos.Location = New System.Drawing.Point(0, 0)
        Me.TabPageMovimientos.Name = "TabPageMovimientos"
        Me.TabPageMovimientos.Size = New System.Drawing.Size(242, 272)
        Me.TabPageMovimientos.Text = "TabPageMovimientos"
        '
        'CheckBoxProducto
        '
        Me.CheckBoxProducto.Location = New System.Drawing.Point(2, 29)
        Me.CheckBoxProducto.Name = "CheckBoxProducto"
        Me.CheckBoxProducto.Size = New System.Drawing.Size(78, 20)
        Me.CheckBoxProducto.TabIndex = 26
        Me.CheckBoxProducto.Text = "LabelProducto"
        '
        'TextBoxCodigo
        '
        Me.TextBoxCodigo.AcceptsReturn = True
        Me.TextBoxCodigo.Location = New System.Drawing.Point(84, 50)
        Me.TextBoxCodigo.Name = "TextBoxCodigo"
        Me.TextBoxCodigo.Size = New System.Drawing.Size(146, 21)
        Me.TextBoxCodigo.TabIndex = 21
        '
        'LabelCodigo
        '
        Me.LabelCodigo.Location = New System.Drawing.Point(0, 54)
        Me.LabelCodigo.Name = "LabelCodigo"
        Me.LabelCodigo.Size = New System.Drawing.Size(80, 16)
        Me.LabelCodigo.Text = "LabelCodigo"
        '
        'fgMovimientos
        '
        Me.fgMovimientos.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fgMovimientos.AllowEditing = False
        Me.fgMovimientos.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor
        Me.fgMovimientos.AutoSearchDelay = 2
        Me.fgMovimientos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fgMovimientos.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgMovimientos.ContextMenu = Me.ContextMenu1
        Me.fgMovimientos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgMovimientos.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgMovimientos.Location = New System.Drawing.Point(2, 73)
        Me.fgMovimientos.Name = "fgMovimientos"
        Me.fgMovimientos.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgMovimientos.Size = New System.Drawing.Size(228, 153)
        Me.fgMovimientos.StyleInfo = resources.GetString("fgMovimientos.StyleInfo")
        Me.fgMovimientos.TabIndex = 14
        '
        'ContextMenu1
        '
        '
        'DetailViewPie
        '
        Me.DetailViewPie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DetailViewPie.BackColor = System.Drawing.Color.DarkBlue
        Me.DetailViewPie.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetailViewPie.LabelWidth = 110
        Me.DetailViewPie.Location = New System.Drawing.Point(3, 229)
        Me.DetailViewPie.Name = "DetailViewPie"
        Me.DetailViewPie.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.TabStrip
        Me.DetailViewPie.SeparatorWidth = 4
        Me.DetailViewPie.Size = New System.Drawing.Size(234, 37)
        Me.DetailViewPie.TabIndex = 4
        '
        'TextBoxProducto
        '
        Me.TextBoxProducto.AcceptsReturn = True
        Me.TextBoxProducto.Location = New System.Drawing.Point(84, 27)
        Me.TextBoxProducto.Name = "TextBoxProducto"
        Me.TextBoxProducto.Size = New System.Drawing.Size(118, 21)
        Me.TextBoxProducto.TabIndex = 3
        '
        'ButtonVer
        '
        Me.ButtonVer.Location = New System.Drawing.Point(206, 27)
        Me.ButtonVer.Name = "ButtonVer"
        Me.ButtonVer.Size = New System.Drawing.Size(24, 21)
        Me.ButtonVer.TabIndex = 4
        Me.ButtonVer.Text = "..."
        '
        'LabelProducto
        '
        Me.LabelProducto.Location = New System.Drawing.Point(2, 30)
        Me.LabelProducto.Name = "LabelProducto"
        Me.LabelProducto.Size = New System.Drawing.Size(80, 16)
        Me.LabelProducto.Text = "LabelProducto"
        '
        'TabPageTotales
        '
        Me.TabPageTotales.Controls.Add(Me.TabControlTotalesMoneda)
        Me.TabPageTotales.Controls.Add(Me.ButtonImpuestos)
        Me.TabPageTotales.Controls.Add(Me.ButtonDetalleContinuar)
        Me.TabPageTotales.Controls.Add(Me.ButtonDetalleRegresar)
        Me.TabPageTotales.Controls.Add(Me.DetailViewGeneral)
        Me.TabPageTotales.Controls.Add(Me.DetailViewGranTotal)
        Me.TabPageTotales.Location = New System.Drawing.Point(0, 0)
        Me.TabPageTotales.Name = "TabPageTotales"
        Me.TabPageTotales.Size = New System.Drawing.Size(234, 269)
        Me.TabPageTotales.Text = "TabPageTotales"
        '
        'TabControlTotalesMoneda
        '
        Me.TabControlTotalesMoneda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlTotalesMoneda.Controls.Add(Me.TabPage1)
        Me.TabControlTotalesMoneda.Dock = System.Windows.Forms.DockStyle.None
        Me.TabControlTotalesMoneda.Location = New System.Drawing.Point(3, 69)
        Me.TabControlTotalesMoneda.Name = "TabControlTotalesMoneda"
        Me.TabControlTotalesMoneda.SelectedIndex = 0
        Me.TabControlTotalesMoneda.Size = New System.Drawing.Size(227, 120)
        Me.TabControlTotalesMoneda.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DetailViewTotalesMoneda)
        Me.TabPage1.Location = New System.Drawing.Point(0, 0)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(227, 97)
        Me.TabPage1.Text = "TabPage1"
        '
        'DetailViewTotalesMoneda
        '
        Me.DetailViewTotalesMoneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DetailViewTotalesMoneda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DetailViewTotalesMoneda.ForeColor = System.Drawing.SystemColors.ControlText
        Item1.Enabled = False
        Item1.Label = "Folio"
        Item1.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Item1.LabelForeColor = System.Drawing.Color.DarkBlue
        Item1.LabelWidth = 90
        Item1.Name = "Folio"
        Item2.DataMember = "Subtotal"
        Item2.Enabled = False
        Item2.Label = "Subtotal"
        Item2.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Item2.LabelForeColor = System.Drawing.Color.DarkBlue
        Item2.LabelWidth = 90
        Item2.Name = "Subtotal"
        Item3.DataMember = "Impuesto"
        Item3.Enabled = False
        Item3.Label = "Impuesto"
        Item3.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Item3.LabelForeColor = System.Drawing.Color.DarkBlue
        Item3.LabelWidth = 90
        Item3.Name = "Impuesto"
        Item4.DataMember = "Total"
        Item4.Enabled = False
        Item4.Label = "Total"
        Item4.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Item4.LabelForeColor = System.Drawing.Color.DarkBlue
        Item4.LabelWidth = 90
        Item4.Name = "Total"
        Item5.DataMember = "Bonificaciones"
        Item5.Enabled = False
        Item5.Label = "Bonificaciones"
        Item5.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Item5.LabelForeColor = System.Drawing.Color.DarkBlue
        Item5.LabelWidth = 90
        Item5.Name = "Bonificaciones"
        Item6.Enabled = False
        Item6.Label = "MontoReal"
        Item6.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Item6.LabelForeColor = System.Drawing.Color.DarkBlue
        Item6.LabelWidth = 90
        Item6.Name = "MontoReal"
        Me.DetailViewTotalesMoneda.Items.Add(Item1)
        Me.DetailViewTotalesMoneda.Items.Add(Item2)
        Me.DetailViewTotalesMoneda.Items.Add(Item3)
        Me.DetailViewTotalesMoneda.Items.Add(Item4)
        Me.DetailViewTotalesMoneda.Items.Add(Item5)
        Me.DetailViewTotalesMoneda.Items.Add(Item6)
        Me.DetailViewTotalesMoneda.LabelWidth = 80
        Me.DetailViewTotalesMoneda.Location = New System.Drawing.Point(0, 0)
        Me.DetailViewTotalesMoneda.Name = "DetailViewTotalesMoneda"
        Me.DetailViewTotalesMoneda.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.TabStrip
        Me.DetailViewTotalesMoneda.ScrollbarWidth = 15
        Me.DetailViewTotalesMoneda.SeparatorWidth = 4
        Me.DetailViewTotalesMoneda.Size = New System.Drawing.Size(227, 97)
        Me.DetailViewTotalesMoneda.TabIndex = 4
        '
        'ButtonImpuestos
        '
        Me.ButtonImpuestos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonImpuestos.Location = New System.Drawing.Point(160, 242)
        Me.ButtonImpuestos.Name = "ButtonImpuestos"
        Me.ButtonImpuestos.Size = New System.Drawing.Size(72, 24)
        Me.ButtonImpuestos.TabIndex = 0
        Me.ButtonImpuestos.Text = "ButtonImpuestos"
        Me.ButtonImpuestos.Visible = False
        '
        'ButtonDetalleContinuar
        '
        Me.ButtonDetalleContinuar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonDetalleContinuar.Location = New System.Drawing.Point(4, 242)
        Me.ButtonDetalleContinuar.Name = "ButtonDetalleContinuar"
        Me.ButtonDetalleContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonDetalleContinuar.TabIndex = 1
        Me.ButtonDetalleContinuar.Text = "ButtonDetalleContinuar"
        '
        'ButtonDetalleRegresar
        '
        Me.ButtonDetalleRegresar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonDetalleRegresar.Location = New System.Drawing.Point(83, 242)
        Me.ButtonDetalleRegresar.Name = "ButtonDetalleRegresar"
        Me.ButtonDetalleRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonDetalleRegresar.TabIndex = 2
        Me.ButtonDetalleRegresar.Text = "ButtonDetalleRegresar"
        '
        'DetailViewGeneral
        '
        Me.DetailViewGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DetailViewGeneral.BackColor = System.Drawing.SystemColors.Window
        Me.DetailViewGeneral.ForeColor = System.Drawing.SystemColors.ControlText
        Item7.Enabled = False
        Item7.Label = "TipoFase"
        Item7.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Item7.LabelForeColor = System.Drawing.Color.DarkBlue
        Item7.LabelWidth = 90
        Item7.Name = "TipoFase"
        ItemComboBox1.DropDownStyle = Resco.Controls.DetailView.RescoComboBoxStyle.DropDownList
        ItemComboBox1.Height = 18
        ItemComboBox1.Label = "FormaVenta"
        ItemComboBox1.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        ItemComboBox1.LabelForeColor = System.Drawing.Color.DarkBlue
        ItemComboBox1.LabelWidth = 90
        ItemComboBox1.Name = "FormaVenta"
        ItemComboBox1.StringData = Nothing
        ItemComboBox1.TextBackColor = System.Drawing.Color.Aqua
        Me.DetailViewGeneral.Items.Add(Item7)
        Me.DetailViewGeneral.Items.Add(ItemComboBox1)
        Me.DetailViewGeneral.LabelWidth = 90
        Me.DetailViewGeneral.Location = New System.Drawing.Point(4, 25)
        Me.DetailViewGeneral.Name = "DetailViewGeneral"
        Me.DetailViewGeneral.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.TabStrip
        Me.DetailViewGeneral.SeparatorWidth = 4
        Me.DetailViewGeneral.Size = New System.Drawing.Size(220, 55)
        Me.DetailViewGeneral.TabIndex = 4
        '
        'DetailViewGranTotal
        '
        Me.DetailViewGranTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DetailViewGranTotal.BackColor = System.Drawing.SystemColors.Window
        Me.DetailViewGranTotal.ForeColor = System.Drawing.SystemColors.ControlText
        ItemTextBox1.Label = "Notas"
        ItemTextBox1.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        ItemTextBox1.LabelForeColor = System.Drawing.Color.DarkBlue
        ItemTextBox1.LabelWidth = 90
        ItemTextBox1.Name = "Notas"
        ItemTextBox1.TextBackColor = System.Drawing.Color.Aqua
        Me.DetailViewGranTotal.Items.Add(ItemTextBox1)
        Me.DetailViewGranTotal.LabelWidth = 90
        Me.DetailViewGranTotal.Location = New System.Drawing.Point(4, 194)
        Me.DetailViewGranTotal.Name = "DetailViewGranTotal"
        Me.DetailViewGranTotal.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.TabStrip
        Me.DetailViewGranTotal.SeparatorWidth = 4
        Me.DetailViewGranTotal.Size = New System.Drawing.Size(220, 39)
        Me.DetailViewGranTotal.TabIndex = 4
        '
        'TabPageProductoNegado
        '
        Me.TabPageProductoNegado.Controls.Add(Me.fgProductoNegado)
        Me.TabPageProductoNegado.Location = New System.Drawing.Point(0, 0)
        Me.TabPageProductoNegado.Name = "TabPageProductoNegado"
        Me.TabPageProductoNegado.Size = New System.Drawing.Size(234, 269)
        Me.TabPageProductoNegado.Text = "TabPageProductoNegado"
        '
        'fgProductoNegado
        '
        Me.fgProductoNegado.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fgProductoNegado.AllowEditing = False
        Me.fgProductoNegado.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor
        Me.fgProductoNegado.AutoSearchDelay = 2
        Me.fgProductoNegado.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fgProductoNegado.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgProductoNegado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgProductoNegado.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgProductoNegado.Location = New System.Drawing.Point(4, 16)
        Me.fgProductoNegado.Name = "fgProductoNegado"
        Me.fgProductoNegado.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgProductoNegado.Size = New System.Drawing.Size(228, 244)
        Me.fgProductoNegado.StyleInfo = resources.GetString("fgProductoNegado.StyleInfo")
        Me.fgProductoNegado.TabIndex = 15
        '
        'TabPageNoEntregados
        '
        Me.TabPageNoEntregados.Controls.Add(Me.fgNoEntregados)
        Me.TabPageNoEntregados.Location = New System.Drawing.Point(0, 0)
        Me.TabPageNoEntregados.Name = "TabPageNoEntregados"
        Me.TabPageNoEntregados.Size = New System.Drawing.Size(234, 269)
        Me.TabPageNoEntregados.Text = "TabPageNoEntregados"
        '
        'fgNoEntregados
        '
        Me.fgNoEntregados.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fgNoEntregados.AllowEditing = False
        Me.fgNoEntregados.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor
        Me.fgNoEntregados.AutoSearchDelay = 2
        Me.fgNoEntregados.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fgNoEntregados.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgNoEntregados.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgNoEntregados.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgNoEntregados.Location = New System.Drawing.Point(4, 16)
        Me.fgNoEntregados.Name = "fgNoEntregados"
        Me.fgNoEntregados.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgNoEntregados.Size = New System.Drawing.Size(228, 244)
        Me.fgNoEntregados.StyleInfo = resources.GetString("fgNoEntregados.StyleInfo")
        Me.fgNoEntregados.TabIndex = 16
        '
        'PanelFondoCristal
        '
        Me.PanelFondoCristal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelFondoCristal.Controls.Add(Me.TextBoxTotalFondoCristal)
        Me.PanelFondoCristal.Controls.Add(Me.LabelTotalFondoCristal)
        Me.PanelFondoCristal.Controls.Add(Me.LabelFondoCristal)
        Me.PanelFondoCristal.Controls.Add(Me.ButtonContinuarFondoCristal)
        Me.PanelFondoCristal.Controls.Add(Me.fgFondoCristal)
        Me.PanelFondoCristal.Location = New System.Drawing.Point(-121, 0)
        Me.PanelFondoCristal.Name = "PanelFondoCristal"
        Me.PanelFondoCristal.Size = New System.Drawing.Size(242, 295)
        '
        'TextBoxTotalFondoCristal
        '
        Me.TextBoxTotalFondoCristal.AcceptsReturn = True
        Me.TextBoxTotalFondoCristal.Enabled = False
        Me.TextBoxTotalFondoCristal.Location = New System.Drawing.Point(168, 226)
        Me.TextBoxTotalFondoCristal.Name = "TextBoxTotalFondoCristal"
        Me.TextBoxTotalFondoCristal.Size = New System.Drawing.Size(66, 21)
        Me.TextBoxTotalFondoCristal.TabIndex = 18
        '
        'LabelTotalFondoCristal
        '
        Me.LabelTotalFondoCristal.Location = New System.Drawing.Point(87, 230)
        Me.LabelTotalFondoCristal.Name = "LabelTotalFondoCristal"
        Me.LabelTotalFondoCristal.Size = New System.Drawing.Size(80, 16)
        Me.LabelTotalFondoCristal.Text = "LabelTotalFondoCristal"
        '
        'LabelFondoCristal
        '
        Me.LabelFondoCristal.Location = New System.Drawing.Point(6, 16)
        Me.LabelFondoCristal.Name = "LabelFondoCristal"
        Me.LabelFondoCristal.Size = New System.Drawing.Size(228, 20)
        Me.LabelFondoCristal.Text = "LabelFondoCristal"
        '
        'ButtonContinuarFondoCristal
        '
        Me.ButtonContinuarFondoCristal.Location = New System.Drawing.Point(6, 262)
        Me.ButtonContinuarFondoCristal.Name = "ButtonContinuarFondoCristal"
        Me.ButtonContinuarFondoCristal.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuarFondoCristal.TabIndex = 16
        Me.ButtonContinuarFondoCristal.Text = "ButtonContinuarFondoCristal"
        '
        'fgFondoCristal
        '
        Me.fgFondoCristal.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fgFondoCristal.AllowEditing = False
        Me.fgFondoCristal.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor
        Me.fgFondoCristal.AutoSearchDelay = 2
        Me.fgFondoCristal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fgFondoCristal.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgFondoCristal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgFondoCristal.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgFondoCristal.Location = New System.Drawing.Point(6, 39)
        Me.fgFondoCristal.Name = "fgFondoCristal"
        Me.fgFondoCristal.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgFondoCristal.Size = New System.Drawing.Size(228, 180)
        Me.fgFondoCristal.StyleInfo = resources.GetString("fgFondoCristal.StyleInfo")
        Me.fgFondoCristal.TabIndex = 15
        '
        'PanelDatosFacturacion
        '
        Me.PanelDatosFacturacion.Controls.Add(Me.ButtonContinuarDatFac)
        Me.PanelDatosFacturacion.Controls.Add(Me.DetailViewDatosFiscales)
        Me.PanelDatosFacturacion.Location = New System.Drawing.Point(0, 0)
        Me.PanelDatosFacturacion.Name = "PanelDatosFacturacion"
        Me.PanelDatosFacturacion.Size = New System.Drawing.Size(242, 295)
        Me.PanelDatosFacturacion.Visible = False
        '
        'ButtonContinuarDatFac
        '
        Me.ButtonContinuarDatFac.Location = New System.Drawing.Point(7, 262)
        Me.ButtonContinuarDatFac.Name = "ButtonContinuarDatFac"
        Me.ButtonContinuarDatFac.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarDatFac.TabIndex = 7
        Me.ButtonContinuarDatFac.Text = "ButtonContinuar1"
        '
        'DetailViewDatosFiscales
        '
        Me.DetailViewDatosFiscales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DetailViewDatosFiscales.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetailViewDatosFiscales.LabelWidth = 110
        Me.DetailViewDatosFiscales.Location = New System.Drawing.Point(4, 31)
        Me.DetailViewDatosFiscales.Name = "DetailViewDatosFiscales"
        Me.DetailViewDatosFiscales.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.TabStrip
        Me.DetailViewDatosFiscales.SeparatorWidth = 4
        Me.DetailViewDatosFiscales.Size = New System.Drawing.Size(228, 220)
        Me.DetailViewDatosFiscales.TabIndex = 1
        '
        'PanelFacturas
        '
        Me.PanelFacturas.Controls.Add(Me.btnContinuarFacturas)
        Me.PanelFacturas.Controls.Add(Me.TabControlFacturas)
        Me.PanelFacturas.Location = New System.Drawing.Point(0, 0)
        Me.PanelFacturas.Name = "PanelFacturas"
        Me.PanelFacturas.Size = New System.Drawing.Size(242, 295)
        Me.PanelFacturas.Visible = False
        '
        'btnContinuarFacturas
        '
        Me.btnContinuarFacturas.Location = New System.Drawing.Point(4, 268)
        Me.btnContinuarFacturas.Name = "btnContinuarFacturas"
        Me.btnContinuarFacturas.Size = New System.Drawing.Size(72, 24)
        Me.btnContinuarFacturas.TabIndex = 7
        Me.btnContinuarFacturas.Text = "btnContinuarFacturas"
        '
        'TabControlFacturas
        '
        Me.TabControlFacturas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlFacturas.Controls.Add(Me.TabPageFactura)
        Me.TabControlFacturas.Dock = System.Windows.Forms.DockStyle.None
        Me.TabControlFacturas.Location = New System.Drawing.Point(4, 16)
        Me.TabControlFacturas.Name = "TabControlFacturas"
        Me.TabControlFacturas.SelectedIndex = 0
        Me.TabControlFacturas.Size = New System.Drawing.Size(235, 246)
        Me.TabControlFacturas.TabIndex = 6
        '
        'TabPageFactura
        '
        Me.TabPageFactura.Controls.Add(Me.txtOrdenCompra)
        Me.TabPageFactura.Controls.Add(Me.lbOrdenCompra)
        Me.TabPageFactura.Controls.Add(Me.ListViewMetodosPago)
        Me.TabPageFactura.Controls.Add(Me.txtFormaPagoFac)
        Me.TabPageFactura.Controls.Add(Me.lbFormaPagoFac)
        Me.TabPageFactura.Controls.Add(Me.txtFechaFac)
        Me.TabPageFactura.Controls.Add(Me.lbFechaFac)
        Me.TabPageFactura.Controls.Add(Me.txtFolioFac)
        Me.TabPageFactura.Controls.Add(Me.lbFolioFac)
        Me.TabPageFactura.Controls.Add(Me.grdMetodoPago)
        Me.TabPageFactura.Location = New System.Drawing.Point(0, 0)
        Me.TabPageFactura.Name = "TabPageFactura"
        Me.TabPageFactura.Size = New System.Drawing.Size(235, 223)
        Me.TabPageFactura.Text = "TabPage2"
        '
        'txtOrdenCompra
        '
        Me.txtOrdenCompra.AcceptsReturn = True
        Me.txtOrdenCompra.Location = New System.Drawing.Point(96, 79)
        Me.txtOrdenCompra.Name = "txtOrdenCompra"
        Me.txtOrdenCompra.Size = New System.Drawing.Size(134, 21)
        Me.txtOrdenCompra.TabIndex = 60
        '
        'lbOrdenCompra
        '
        Me.lbOrdenCompra.Location = New System.Drawing.Point(4, 83)
        Me.lbOrdenCompra.Name = "lbOrdenCompra"
        Me.lbOrdenCompra.Size = New System.Drawing.Size(95, 16)
        Me.lbOrdenCompra.Text = "lbOrdenCompra"
        '
        'ListViewMetodosPago
        '
        Me.ListViewMetodosPago.CheckBoxes = True
        Me.ListViewMetodosPago.FullRowSelect = True
        Me.ListViewMetodosPago.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewMetodosPago.Location = New System.Drawing.Point(3, 106)
        Me.ListViewMetodosPago.Name = "ListViewMetodosPago"
        Me.ListViewMetodosPago.Size = New System.Drawing.Size(228, 112)
        Me.ListViewMetodosPago.TabIndex = 47
        Me.ListViewMetodosPago.View = System.Windows.Forms.View.Details
        '
        'txtFormaPagoFac
        '
        Me.txtFormaPagoFac.AcceptsReturn = True
        Me.txtFormaPagoFac.Enabled = False
        Me.txtFormaPagoFac.Location = New System.Drawing.Point(96, 54)
        Me.txtFormaPagoFac.Name = "txtFormaPagoFac"
        Me.txtFormaPagoFac.Size = New System.Drawing.Size(134, 21)
        Me.txtFormaPagoFac.TabIndex = 30
        '
        'lbFormaPagoFac
        '
        Me.lbFormaPagoFac.Location = New System.Drawing.Point(3, 58)
        Me.lbFormaPagoFac.Name = "lbFormaPagoFac"
        Me.lbFormaPagoFac.Size = New System.Drawing.Size(95, 16)
        Me.lbFormaPagoFac.Text = "lbFormaPagoFac"
        '
        'txtFechaFac
        '
        Me.txtFechaFac.AcceptsReturn = True
        Me.txtFechaFac.Enabled = False
        Me.txtFechaFac.Location = New System.Drawing.Point(96, 28)
        Me.txtFechaFac.Name = "txtFechaFac"
        Me.txtFechaFac.Size = New System.Drawing.Size(134, 21)
        Me.txtFechaFac.TabIndex = 26
        '
        'lbFechaFac
        '
        Me.lbFechaFac.Location = New System.Drawing.Point(3, 32)
        Me.lbFechaFac.Name = "lbFechaFac"
        Me.lbFechaFac.Size = New System.Drawing.Size(95, 16)
        Me.lbFechaFac.Text = "lbFechaFac"
        '
        'txtFolioFac
        '
        Me.txtFolioFac.AcceptsReturn = True
        Me.txtFolioFac.Enabled = False
        Me.txtFolioFac.Location = New System.Drawing.Point(96, 3)
        Me.txtFolioFac.Name = "txtFolioFac"
        Me.txtFolioFac.Size = New System.Drawing.Size(134, 21)
        Me.txtFolioFac.TabIndex = 23
        '
        'lbFolioFac
        '
        Me.lbFolioFac.Location = New System.Drawing.Point(3, 7)
        Me.lbFolioFac.Name = "lbFolioFac"
        Me.lbFolioFac.Size = New System.Drawing.Size(95, 16)
        Me.lbFolioFac.Text = "lbFolioFac"
        '
        'grdMetodoPago
        '
        Me.grdMetodoPago.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.grdMetodoPago.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grdMetodoPago.ContextMenu = Me.ContextMenuMetodo
        Me.grdMetodoPago.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grdMetodoPago.Location = New System.Drawing.Point(3, 105)
        Me.grdMetodoPago.Name = "grdMetodoPago"
        Me.grdMetodoPago.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.grdMetodoPago.Size = New System.Drawing.Size(228, 113)
        Me.grdMetodoPago.StyleInfo = resources.GetString("grdMetodoPago.StyleInfo")
        Me.grdMetodoPago.TabIndex = 58
        '
        'ContextMenuMetodo
        '
        Me.ContextMenuMetodo.MenuItems.Add(Me.MenuItemEliminarMet)
        '
        'MenuItemEliminarMet
        '
        Me.MenuItemEliminarMet.Text = "MenuItemEliminarMet"
        '
        'FormMovProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelFacturas)
        Me.Controls.Add(Me.PanelFondoCristal)
        Me.Controls.Add(Me.PanelDatosFacturacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuMovProducto
        Me.MinimizeBox = False
        Me.Name = "FormMovProducto"
        Me.Panel1.ResumeLayout(False)
        Me.TabControlMovProducto.ResumeLayout(False)
        Me.TabPageMovimientos.ResumeLayout(False)
        Me.TabPageTotales.ResumeLayout(False)
        Me.TabControlTotalesMoneda.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPageProductoNegado.ResumeLayout(False)
        Me.TabPageNoEntregados.ResumeLayout(False)
        Me.PanelFondoCristal.ResumeLayout(False)
        Me.PanelDatosFacturacion.ResumeLayout(False)
        Me.PanelFacturas.ResumeLayout(False)
        Me.TabControlFacturas.ResumeLayout(False)
        Me.TabPageFactura.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Funciones y eventos generales de la forma "

    Private Sub FormMovProducto_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        refaVista = Nothing
        If Not IsNothing(aTransProd) AndAlso aTransProd.Count > 0 Then
            aTransProd.Clear()
        End If
        aTransProd = Nothing
        oTransProdGenerico = Nothing
        oProducto = Nothing
        oImpuesto = Nothing
        oDescuentoCliente = Nothing
        oPromocion = Nothing
        Me.Transaccion = Nothing
        If oDBVen.oConexion.State = ConnectionState.Open Then
            oDBVen.oConexion.Close()
        End If
    End Sub

    Private Sub FormMovProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.AgregarControl(Me)
            ctrlSeguimiento.CrearMenuItem(MainMenuMovProducto)
            AddHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
            AddHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
        End If
        Me.Panel1.SendToBack()

        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.Iniciar()
        Else
            Dim lbNombreActividad As New Label
            lbNombreActividad.BackColor = System.Drawing.SystemColors.Control
            Dim tam As Single = 10 * nFactorH
            lbNombreActividad.Font = New System.Drawing.Font("Tahoma", tam!, System.Drawing.FontStyle.Bold)
            UbicarTitulo(lbNombreActividad, Me.Controls)
            lbNombreActividad.Name = "lbNombreActividad"
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            lbNombreActividad.Size = New System.Drawing.Size((Me.Width * nFactorW) - 5, 32 * nFactorH)
#Else
            lbNombreActividad.Size = New System.Drawing.Size((Me.Width * nFactorW) - 5, 16 * nFactorH)
#End If
            lbNombreActividad.Text = sNombreActividad
            lbNombreActividad.TextAlign = System.Drawing.ContentAlignment.TopCenter
            Me.Controls.Add(lbNombreActividad)
            lbNombreActividad.BringToFront()
            tam = Nothing
        End If

        Me.TabControlMovProducto.Visible = False
        If Not Vista.Buscar("FormMovProducto", refaVista) Then
            Exit Sub
        End If
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        refaVista.ColocarEtiquetasMenuEmergente(ContextMenuMovimientos)
        Me.ButtonContinuarDatFac.Text = Me.ButtonContinuarFondoCristal.Text
        Me.btnContinuarFacturas.Text = Me.ButtonContinuarDatFac.Text

        Me.Promocion.MensajeObligatoria = refaVista.BuscarMensaje("MsgBox", "P0104")
        Me.LabelTotalFondoCristal.Text = refaVista.BuscarMensaje("MsgBox", "Total")
        Me.PanelFondoCristal.Visible = False
        Me.Panel1.Visible = True
        ' Crear el ListView que contiene los productos capturados
        ConfiguraGrid()
        'Detailview para consultar el productoNegado

        If Me.TabControlMovProducto.TabPages.Contains(Me.TabPageNoEntregados) Then
            Me.TabControlMovProducto.TabPages.RemoveAt(ConstPosTabPageNoEntregados)
        End If
        If Me.TabControlMovProducto.TabPages.Contains(Me.TabPageProductoNegado) Then
            Me.TabControlMovProducto.TabPages.RemoveAt(ConstPosTabPageProductoNegado)
        End If
        Me.TabControlMovProducto.SelectedIndex = 0
        ConfiguraTotales()
        'refaVista.CrearDetailView(Me.DetailViewTotalesMachote, "DetailViewTotales")
        'If bSurtir Then

        '    For Each ViewItem As Resco.Controls.DetailView.Item In DetailViewTotalesMachote.Items
        '        ViewItem.Enabled = False
        '    Next
        'End If
        'If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta AndAlso oTransProdGenerico.ModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Pedido AndAlso oConHist.Campos("PagoAutomatico") AndAlso oConHist.Campos("CobrarVentas") Then
        '    LlenarComboMonedas()
        'Else
        '    Dim oItem As Resco.Controls.DetailView.ItemComboBox
        '    oItem = DetailViewTotalesMachote.Items("MonedaId")
        '    oItem.Visible = False
        'End If

        If bSurtir Then
            DetailViewGeneral.Items("FormaVenta").Enabled = False
            DetailViewGeneral.Items("FormaVenta").TextBackColor = Drawing.Color.White
            DetailViewGranTotal.Items("Notas").Enabled = False
            DetailViewGranTotal.Items("Notas").TextBackColor = Drawing.Color.White

            Dim dif As Double = 0
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            dif = fgMovimientos.Location.Y - 32
            fgMovimientos.Location = New System.Drawing.Point(2, 32)
#Else
            dif = fgMovimientos.Location.Y - 16
            fgMovimientos.Location = New System.Drawing.Point(2, 16)
#End If

            fgMovimientos.Height += dif
            TextBoxProducto.Visible = False
            CheckBoxProducto.Visible = False
            ButtonVer.Visible = False
            LabelCodigo.Visible = False
            TextBoxCodigo.Visible = False
            Me.LabelProducto.Visible = True

            If oTransProdGenerico.TipoFase = ServicesCentral.TiposFasesPedidos.Surtido Then
                Dim sTransProdID As String = oDBVen.EjecutarCmdScalarStrSQL("Select TransProdID from TransProd where FacturaID='" & oTransProdGenerico.TransProdId & "'")
                If sTransProdID <> "" Then
                    Me.TransProdDevolucion = New TransProd
                    Me.TransProdDevolucion.TransProdId = sTransProdID
                    Me.TransProdDevolucion.Recuperar()
                End If
            End If
        Else
            Me.LabelProducto.Visible = False
        End If

        Me.DetailViewGeneral.KeyNavigation = False
        Me.DetailViewTotalesMoneda.KeyNavigation = False
        Me.DetailViewGranTotal.KeyNavigation = False

        If Not bSurtir Then
            If Not oTransProdGenerico.ListasPrecios.Recuperar(oTransProdGenerico.ClienteActual, oTransProdGenerico.ModuloMovDetalle) Then
                Me.Terminar = True
                QuitarControlSeguimiento()
                Me.Close()
                'Me.Dispose()Se quito el dispose por el folio 3158
                Exit Sub
            End If
        End If
        'Inicializar el total para la preliquidacion
        nTotalInicial = 0
        dTotalInicialCredito = 0
        nCFVTipoInicial = oTransProdGenerico.CFVTipo
        sClientePagoIdInicial = oTransProdGenerico.ClientePagoId
        If Not bSurtir Then
            If Not IsNothing(oTransProdGenerico.ClientePagoId) AndAlso IsNumeric(oTransProdGenerico.ClientePagoId) Then
                If oTransProdGenerico.TransProdId <> "" And ValorReferencia.RecuperaGrupo("PAGO", oTransProdGenerico.ClientePagoId).ToUpper = "E" And oTransProdGenerico.CFVTipo = "1" Then
                    Me.nTotalInicial = oTransProdGenerico.Total
                ElseIf oTransProdGenerico.TransProdId <> "" And ValorReferencia.RecuperaGrupo("PAGO", oTransProdGenerico.ClientePagoId).ToUpper = "E" And oTransProdGenerico.CFVTipo = "2" Then
                    dTotalInicialCredito = (oTransProdGenerico.Total * oTransProdGenerico.TipoCambio)
                End If
            End If
        End If

        '' Establecer el limite del descuento por vendedor
        'If Not bSurtir Then
        '    Me.EstablecerLimiteDescuentoVendedor()
        'End If
        ' Recuperar el nombre de la lista de precios
        'If oTransProdGenerico.ListasPrecios.ListasPrecios.Count > 0 Then
        '    Me.LabelListaPrecios.Text = oTransProdGenerico.ListasPrecios.ListasPrecios.Values(0).PrecioClave & " - " & oTransProdGenerico.ListasPrecios.ListasPrecios.Values(0).Nombre
        'End If
        ' Preparar el objeto de busqueda de impuestos
        'Me.Impuesto.CrearListasBusqueda(Me.TransProd.ClienteActual.TipoImpuesto)

        ' Cambios 05 Mayo 2006
        ' Indicar que es un documento nuevo, para que las funciones BuscarAplicablesAlClientePorCliente lo consideren en el filtro
        Me.DescuentoCliente.EsNuevo = (oTransProdGenerico.TransProdId = "")
        ' /Cambios 05 Mayo 2006

        ' Obtener la lista de descuentos del cliente a aplicar
        If Not bSurtir Then
            If Descuento.VerificarAplicacion(oTransProdGenerico.ModuloMovDetalle.ModuloMovDetalleClave, "AplicaCliente") Then
                If Not Me.DescuentoCliente.BuscarAplicablesAlClientePorCliente(oTransProdGenerico.ClienteActual.ClienteClave, Me.aDescuentosCliente) Then
                    Me.DescuentoCliente.BuscarAplicablesAlClientePorEsquema(oTransProdGenerico.ClienteActual.ClienteClave, Me.aDescuentosCliente)
                End If
            End If
        End If

        ' Iniciar la transaccion
        If oDBVen.oConexion.State = ConnectionState.Closed Then
            oDBVen.oConexion.Open()
        End If
        Me.Transaccion = oDBVen.oConexion.BeginTransaction()
        ' Verificar si se esta modificando un documento
        If oTransProdGenerico.TransProdId = "" Then
            Folio.ObtenerTransProdId(oTransProdGenerico.TransProdId)
            bEsNuevo = True
            oTransProdGenerico.FolioActual = Folio.Obtener(oTransProdGenerico.ModuloMovDetalle.ModuloMovDetalleClave)
            ' Cambios 23 Abril
            If oTransProdGenerico.FolioActual = "" Then
                Me.Terminar = True
                Me.Close()
                Exit Sub
            End If

            ' /Cambios 23 Abril
            oTransProdGenerico.Actualizar(bSurtir)

        Else
            ' Se esta modificando un documento, recuperarlo
            bEsNuevo = False
            Me.PoblarMovimientos()
            'Resta los puntos acumulados
            MovProducto.RestarPuntos(oTransProdGenerico, 2)

            'Borra las Cuotas
            Cuotas.CalcularCuotasxEfectivo(oTransProdGenerico, True)
            If (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta Or oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion) AndAlso oTransProdGenerico.ModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Pedido Then
                If Not bSurtir Then

                    'Borrar los pedimentos relacionados
                    oDBVen.EjecutarComandoSQL("Delete from TRPPedimento where TransProdID ='" & oTransProdGenerico.TransProdId & "'")

                    If oConHist.Campos("CobrarVentas") Then
                        oTransProdGenerico.RecalcularTotales()
                        oTransProdGenerico.ClienteActual.ActualizarSaldo(-(oTransProdGenerico.Total * oTransProdGenerico.TipoCambio))
                        'bSaldoActualizado = True
                    End If
                End If
            End If
        End If

        If Not bSurtir Then
            Me.ObtenerTotalesDetalle(oTransProdGenerico)
        End If

        ' Poblar el ListView para consultar el inventario
        ' Poner el foco en el textbox
        Me.TextBoxProducto.Focus()
        If bSurtir Then
            Me.LabelProducto.Visible = False
            Me.TextBoxProducto.Visible = False
            Me.ButtonVer.Visible = False
        End If

        bIniciando = False

        Cursor.Current = Cursors.Default
        Me.Show()
        Me.TabControlMovProducto.Visible = True
        Me.TextBoxProducto.Focus()
        [Global].HabilitarMenuItem(MainMenuMovProducto, True)
        bHuboCambios = False
    End Sub

    Private Sub TerminarVisita()
        MenuItemRegresar_Click(Nothing, Nothing)
    End Sub

    Private Sub ConfiguraTotales()

        With DetailViewGeneral
            If g_SO = SO.WindowsCE Then
                .BackColor = System.Drawing.SystemColors.Control
            Else
                .BackColor = System.Drawing.SystemColors.Window
            End If

            .BorderStyle = BorderStyle.None
            .Items("TipoFase").LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
            .Items("TipoFase").TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
            .Items("TipoFase").TextAlign = HorizontalAlignment.Left
            .Items("TipoFase").Label = refaVista.BuscarMensaje("MsgBox", "XFase")
            .Items("FormaVenta").LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
            .Items("FormaVenta").TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
            .Items("FormaVenta").TextAlign = HorizontalAlignment.Left
            .Items("FormaVenta").Label = refaVista.BuscarMensaje("MsgBox", "XFormaVenta")

        End With
        With DetailViewGranTotal
            If g_SO = SO.WindowsCE Then
                .BackColor = System.Drawing.SystemColors.Control
            Else
                .BackColor = System.Drawing.SystemColors.Window
            End If
            .BorderStyle = BorderStyle.None
            .Items("Notas").LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
            .Items("Notas").TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
            .Items("Notas").TextAlign = HorizontalAlignment.Left
            .Items("Notas").Label = refaVista.BuscarMensaje("MsgBox", "TRPNotas")
        End With
        With DetailViewTotalesMoneda
            '.BorderStyle = BorderStyle.None
            .Items("Folio").LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
            .Items("Folio").TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
            .Items("Folio").TextAlign = HorizontalAlignment.Right
            .Items("Folio").Label = refaVista.BuscarMensaje("MsgBox", "XFolio")
            .Items("Subtotal").LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
            .Items("Subtotal").TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
            .Items("Subtotal").TextAlign = HorizontalAlignment.Right
            .Items("Subtotal").Label = refaVista.BuscarMensaje("MsgBox", "XSubTotal")
            .Items("Impuesto").LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
            .Items("Impuesto").TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
            .Items("Impuesto").TextAlign = HorizontalAlignment.Right
            .Items("Impuesto").Label = refaVista.BuscarMensaje("MsgBox", "XImpuesto")
            .Items("Total").LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
            .Items("Total").TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
            .Items("Total").TextAlign = HorizontalAlignment.Right
            .Items("Total").Label = refaVista.BuscarMensaje("MsgBox", "TRPTotal")
            .Items("Bonificaciones").LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
            .Items("Bonificaciones").TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
            .Items("Bonificaciones").TextAlign = HorizontalAlignment.Right
            .Items("Bonificaciones").Label = refaVista.BuscarMensaje("MsgBox", "XBonificacion")
            .Items("MontoReal").LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
            .Items("MontoReal").TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
            .Items("MontoReal").TextAlign = HorizontalAlignment.Right
            .Items("MontoReal").Label = refaVista.BuscarMensaje("MsgBox", "XMontoReal")
        End With

    End Sub


#Region "Con Arbolito"
    Private Sub PoblarGridFondoCristal()
        fgFondoCristal.Rows.Count = 1
        Dim dt As DataTable = oDBVen.RealizarConsultaSQL("SELECT Producto.ProductoClave, Producto.Nombre, TipoUnidad, Cantidad,TransProdDetalle.Total,TransProdDetalle.Precio,TransProdDetalle.TransProdDetalleID FROM TransProdDetalle inner join TransProd on TransProd.TransProdID = TransProdDetalle.TransProdID inner join Producto on Producto.ProductoClave =TransProdDetalle.ProductoClave WHERE FacturaID in (" & RegresaTransProdActual() & ") and TransProd.Tipo = " & ServicesCentral.TiposTransProd.FondoCristal & " order by Producto.ProductoClave ", "Fondo Cristal")
        Dim sProducto As String = ""
        fgFondoCristal.Redraw = False

        Dim r As C1.Win.C1FlexGrid.Row
        For Each dr As DataRow In dt.Rows
            If sProducto <> dr("ProductoClave").ToString Then
                sProducto = dr("ProductoClave").ToString
                r = fgFondoCristal.Rows.Add
                r.AllowEditing = False
                r.IsNode = True
                r.Node.Level = 0
                With fgFondoCristal
                    .Item(r.Index, 0) = dr("ProductoClave")
                    .Item(r.Index, 1) = dr("Nombre")
                    .Item(r.Index, 3) = Format(dr("Total"), "#,##0.00")
                    dTotalFondoCristal += Format(dr("Total"), "#,##0.00")
                End With
            Else
                With fgFondoCristal
                    .Item(r.Index, 3) = Format(CDbl(.Item(r.Index, 3)) + dr("Total"), "#,##0.00")
                    dTotalFondoCristal += Format(dr("Total"), "#,##0.00")
                End With
            End If
            Dim r2 As C1.Win.C1FlexGrid.Row = fgFondoCristal.Rows.Add
            r2.AllowEditing = True
            r2.IsNode = True
            r2.Node.Level = 1
            With fgFondoCristal
                .Item(r2.Index, 0) = ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad"))
                .Item(r2.Index, 1) = dr("Cantidad")
                .Item(r2.Index, 2) = Format(dr("Precio"), "#,##0.00")
                .Item(r2.Index, 3) = Format(dr("Total"), "#,##0.00")
                .Item(r2.Index, 4) = dr("Cantidad")
                .Item(r2.Index, 5) = dr("TransProdDetalleID")
                .Item(r2.Index, 6) = dr("TipoUnidad")
                .Item(r2.Index, 7) = Format(dr("Total"), "#,##0.00")
            End With
        Next

        For i As Integer = 1 To fgFondoCristal.Rows.Count - 1
            fgFondoCristal.Rows(i).Node.Collapsed = True
        Next
        TextBoxTotalFondoCristal.Text = Format(dTotalFondoCristal, "#,##0.00")
        fgFondoCristal.Redraw = True
    End Sub

    Private Sub PoblarGridMovimientos()
        fgMovimientos.Rows.Count = 1
        Dim dt As DataTable = oDBVen.RealizarConsultaSQL("SELECT TransProdDetalle.TransProdID,TransProdDetalle.Partida, MON.TipoCodigo,Producto.ProductoClave, Producto.Nombre, TransProdDetalle.Cantidad, TransProdDetalle.Cantidad1, TransProdDetalle.UnidadCobranza, CASE WHEN FACTOR=0 THEN FACTOR1 ELSE FACTOR END as Factor, TransProdDetalle.SubTotal, TransProdDetalle.DescuentoImp , TransProdDetalle.Impuesto , TransProdDetalle.Total, TransProdDetalle.CodigoSKU, TransProdDetalle.TransProdDetalleID,TransProdDetalle.TipoMotivo  FROM TransProdDetalle INNER JOIN Producto ON TransProdDetalle.ProductoClave = Producto.ProductoClave INNER JOIN TransProd TRP ON TRP.TransProdID = TransProdDetalle.TransProdID INNER JOIN Moneda MON on MON.MonedaID = TRP.MonedaID WHERE TransProdDetalle.TransProdId in(" & RegresaTransProdActual() & ") ORDER BY Producto.ProductoClave, TransProdDetalle.UnidadCobranza,TransProdDetalle.Partida ", "Detalles")
        fgMovimientos.Redraw = False
        Dim r As C1.Win.C1FlexGrid.Row
        Dim tmpArrProductoClave As New ArrayList
        Dim bHayBonificaciones As Boolean = False

        Dim dtBon As DataTable
        If bSurtir Then
            If Not IsNothing(Me.TransProdDevolucion) AndAlso Me.TransProdDevolucion.TransProdId <> "" Then
                dtBon = oDBVen.RealizarConsultaSQL("SELECT TransProdDetalle.TransProdDetalleID, TransProdDetalle.Cantidad, TransProdDetalle.Cantidad1, TransProdDetalle.DescuentoPor,TransProdDetalle.DescuentoImp, TransProdDetalle.Total, TransProdDetalle.TipoMotivo FROM TransProdDetalle WHERE TransProdDetalle.TransProdId='" & Me.TransProdDevolucion.TransProdId & "' ORDER BY TransProdDetalle.TransProdDetalleID ", "Bonificaciones")
                If dtBon.Rows.Count > 0 Then
                    bHayBonificaciones = True
                End If
            End If
        End If

        For Each dr As DataRow In dt.Rows
            If Not tmpArrProductoClave.Contains(dr("ProductoClave")) Then
                tmpArrProductoClave.Add(dr("ProductoClave"))
                r = fgMovimientos.Rows.Add
                r.IsNode = True
                r.Node.Level = 0
                With fgMovimientos
                    .Item(r.Index, 0) = dr("ProductoClave")
                    .Item(r.Index, 1) = dr("Nombre")
                    .Item(r.Index, 2) = ValorReferencia.BuscarEquivalente("CDGOMON", dr("TipoCodigo"))
                    .Item(r.Index, 3) = Format(dr("SubTotal"), "#,##0.00") '5
                    .Item(r.Index, 4) = Format(dr("DescuentoImp"), "#,##0.00")
                    .Item(r.Index, 5) = Format(dr("Impuesto"), "#,##0.00")
                    .Item(r.Index, 6) = Format(dr("Total"), "#,##0.00")
                    .Item(r.Index, "Partida") = dr("Partida")
                    .Item(r.Index, "TransProdID") = dr("TransProdID")
                End With
            Else
                With fgMovimientos
                    .Item(r.Index, 3) = Format(CDbl(.Item(r.Index, 3)) + dr("SubTotal"), "#,##0.00")
                    .Item(r.Index, 4) = Format(CDbl(.Item(r.Index, 4)) + dr("DescuentoImp"), "#,##0.00")
                    .Item(r.Index, 5) = Format(CDbl(.Item(r.Index, 5)) + dr("Impuesto"), "#,##0.00")
                    .Item(r.Index, 6) = Format(CDbl(.Item(r.Index, 6)) + dr("Total"), "#,##0.00")
                End With
            End If

            Dim r2 As C1.Win.C1FlexGrid.Row = fgMovimientos.Rows.Add
            r2.IsNode = True
            r2.Node.Level = 1
            With fgMovimientos
                .Item(r2.Index, 0) = ValorReferencia.BuscarEquivalente("UCOBRA", dr("UnidadCobranza")) & "(" & dr("Factor") & ")"
                .Item(r2.Index, 1) = dr("Cantidad")
                .Item(r2.Index, 2) = dr("Cantidad1")
                .Item(r2.Index, ConstIndiceCodigoSKU) = dr("CodigoSKU")
                .Item(r2.Index, "Partida") = dr("Partida")
                .Item(r2.Index, ConstIndiceTransProdDetalleID) = dr("TransProdDetalleID")
                .Item(r2.Index, "TransProdID") = dr("TransProdID")
                If Not IsDBNull(dr("TipoMotivo")) Then
                    If dr("DescuentoImp") > 0 Then
                        .Item(r2.Index, ConstIndiceTipoBonificacion) = TipoBonificacion.BonificacionImporte
                    Else
                        .Item(r2.Index, ConstIndiceTipoBonificacion) = TipoBonificacion.PesoReal
                    End If
                End If
            End With

            If bHayBonificaciones Then
                Dim drBon As DataRow() = dtBon.Select("TransProdDetalleID = '" & dr("TransProdDetalleID") & "'")
                If Not IsNothing(drBon) AndAlso drBon.Length > 0 Then
                    Dim r3 As C1.Win.C1FlexGrid.Row = fgMovimientos.Rows.Add
                    r3.IsNode = True
                    r3.Node.Level = 2
                    With fgMovimientos
                        If Math.Round(CDec(drBon(0)("Cantidad")), 2) = Decimal.Round(CDec(dr("Cantidad")), 2) AndAlso Math.Round(CDec(drBon(0)("Cantidad1")), 2) = Math.Round(CDec(dr("Cantidad1")), 2) Then
                            .Item(r3.Index, 0) = refaVista.BuscarMensaje("MsgBox", "XDevolucion")
                            .Item(r3.Index, 1) = ValorReferencia.BuscarEquivalente("TPDMOT", drBon(0)("TipoMotivo"))
                            .Item(r3.Index, ConstIndiceTransProdDetalleID) = drBon(0)("TransProdDetalleID")
                            .Item(r3.Index, ConstIndiceTipoBonificacion) = TipoBonificacion.Devolucion
                            .Item(r2.Index, ConstIndiceTipoBonificacion) = TipoBonificacion.Devolucion
                        ElseIf Math.Round(CDec(drBon(0)("Cantidad")), 2) > 0 And (Math.Round(CDec(drBon(0)("Cantidad")), 2) < Math.Round(CDec(dr("Cantidad")), 2) OrElse Math.Round(CDec(drBon(0)("Cantidad1")), 2) < Math.Round(CDec(dr("Cantidad1")), 2)) Then
                            .Item(r3.Index, 0) = refaVista.BuscarMensaje("MsgBox", "XPesoReal")
                            .Item(r3.Index, 1) = Format(dr("Cantidad") - drBon(0)("Cantidad"), "##0.00")
                            .Item(r3.Index, 2) = Format(dr("Cantidad1") - drBon(0)("Cantidad1"), "0.##")
                            .Item(r3.Index, 3) = ValorReferencia.BuscarEquivalente("TPDMOT", drBon(0)("TipoMotivo"))
                            .Item(r3.Index, ConstIndiceTipoBonificacion) = TipoBonificacion.PesoReal
                            .Item(r3.Index, ConstIndiceTransProdDetalleID) = drBon(0)("TransProdDetalleID")
                            .Item(r2.Index, ConstIndiceTipoBonificacion) = TipoBonificacion.PesoReal
                        ElseIf CDec(drBon(0)("Cantidad")) = 0 Then
                            .Item(r3.Index, 0) = refaVista.BuscarMensaje("MsgBox", "XBonificacion")
                            .Item(r3.Index, 1) = Format(drBon(0)("DescuentoPor"), "##0.00") & "%"
                            .Item(r3.Index, 2) = Format(drBon(0)("Total") * -1, "#,##0.00")
                            .Item(r3.Index, 3) = ValorReferencia.BuscarEquivalente("TPDMOT", drBon(0)("TipoMotivo"))
                            .Item(r3.Index, ConstIndiceTipoBonificacion) = TipoBonificacion.BonificacionImporte
                            .Item(r3.Index, ConstIndiceTransProdDetalleID) = drBon(0)("TransProdDetalleID")
                            .Item(r2.Index, ConstIndiceTipoBonificacion) = TipoBonificacion.BonificacionImporte
                        End If
                    End With
                End If
            End If
        Next
        If Not IsNothing(dtBon) Then
            dtBon.Dispose()
        End If

        If Not bSurtir Then
            For i As Integer = 1 To fgMovimientos.Rows.Count - 1
                fgMovimientos.Rows(i).Node.Collapsed = True
            Next
        End If

        tmpArrProductoClave = Nothing
        fgMovimientos.Redraw = True
    End Sub

    Private Sub ConfiguraGrid()
        With fgMovimientos
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 11
            .Cols(0).Caption = refaVista.BuscarMensaje("MsgBox", "ProductoClave")
            .Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "Nombre")
            .Cols(2).Caption = refaVista.BuscarMensaje("MsgBox", "ABDMoneda")
            .Cols(3).Caption = refaVista.BuscarMensaje("MsgBox", "Subtotal")
            .Cols(4).Caption = refaVista.BuscarMensaje("MsgBox", "Descuento")
            .Cols(5).Caption = refaVista.BuscarMensaje("MsgBox", "Impuesto")
            .Cols(6).Caption = refaVista.BuscarMensaje("MsgBox", "Total")
            .Cols(7).Visible = False
            .Cols(8).Visible = False
            .Cols(9).Visible = False
            .Cols(9).Name = "TransProdID"
            .Cols(10).Visible = False
            .Cols(10).Name = "Partida"
            .Rows.Count = 1
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            ' initialize outline tree
            .Tree.Column = 0
            .Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf
            .AutoResize = True
            .Redraw = True
        End With
    End Sub
#End Region

    Private Sub MostrarTabPageMovimientos()
        Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageMovimientos
        Me.TabControlMovProducto.Refresh()
    End Sub

    Private Sub MostrarTabPageTotales()
        Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageTotales
        Me.TabControlMovProducto.Refresh()
    End Sub

    Private Sub TabControlMovProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControlMovProducto.SelectedIndexChanged
        If Not bIniciando And Not Me.bFinalizando Then
            Cursor.Current = Cursors.WaitCursor
            Dim iTabPage As Integer = TabControlMovProducto.SelectedIndex
            Select Case Me.TabControlMovProducto.SelectedIndex
                Case ConstPosTabPageMovimientos
                    bRecalcularTotales = True
                    ' Cambios 05 Mayo 2006
                    ' Pasar como parámetro si el documento es nuevo o no, para considerarlos en el filtro del detalle
                    'Me.Promocion.Preparar(Me.TransProd.TransProdId, Me.TransProd.ModuloMovDetalle.ModuloMovDetalleClave, Me.TransProd.Tipo, Me.TransProd.ListaPrecios, Me.Impuesto, Me.TransProd.ClienteActual.TipoImpuesto)
                    'TODO: Precios Volumen
                    'If aTransProd.Count > 0 Then
                    '    For Each oTRP As TransProd In aTransProd.Values
                    '        If Not bSurtir Then
                    '            Me.Promocion.Preparar(oTRP.TransProdId, oTRP.ModuloMovDetalle.ModuloMovDetalleClave, oTRP.Tipo, oTRP.ListasPrecios, Me.Impuesto, oTRP.ClienteActual.TipoImpuesto, Me.bEsNuevo, oVendedor.TipoModulo, False, False)
                    '        End If
                    '        Me.ObtenerTotalesDetalle(oTRP)
                    '    Next
                    'Else
                    '    If Not bSurtir Then
                    '        Me.Promocion.Preparar(oTransProdGenerico.TransProdId, oTransProdGenerico.ModuloMovDetalle.ModuloMovDetalleClave, oTransProdGenerico.Tipo, oTransProdGenerico.ListasPrecios, Me.Impuesto, oTransProdGenerico.ClienteActual.TipoImpuesto, Me.bEsNuevo, oVendedor.TipoModulo, False, False)
                    '    End If
                    '    Me.ObtenerTotalesDetalle(oTransProdGenerico)
                    'End If
                    ' /Cambios 05 Mayo 2006
                    Me.TextBoxProducto.Focus()

                    If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta And oTransProdGenerico.Tipo <> ServicesCentral.TiposTransProd.MovSinInvEV Then
                        If Me.TabControlMovProducto.TabPages.Contains(Me.TabPageNoEntregados) Then
                            Me.TabControlMovProducto.TabPages.RemoveAt(ConstPosTabPageNoEntregados)
                            bIniciando = True
                            Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageMovimientos
                            bIniciando = False
                        End If
                    End If

                    blnScannerActivo = True
                    ActivarScanner()

                Case ConstPosTabPageTotales
                    If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion And bSurtir And oTransProdGenerico.TipoFase = ServicesCentral.TiposFasesPedidos.Captura Then

                        If Not ValidarInventarioSurtir() Then
                            Exit Sub
                        End If

                        If bSurtir Then


                            If Not IsNothing(Me.TransProdDevolucion) AndAlso Me.TransProdDevolucion.TransProdId <> "" Then
                                If (oTransProdGenerico.Total - Me.TransProdDevolucion.Total) <= 0 Then
                                    MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "AsignarProductos"), MsgBoxStyle.Information)
                                    Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageMovimientos
                                    Me.TabControlMovProducto.Refresh()
                                    Exit Sub
                                End If

                            End If
                        End If

                    End If

                    If Not bSurtir Then
                        'Me.EstablecerLimiteDescuentoVendedor()
                        If aDetailViewTotales.Count > 0 Then
                            For Each oDetailView As Resco.Controls.DetailView.DetailView In aDetailViewTotales.Values
                                oDetailView.Items("Bonificaciones").Visible = False
                                oDetailView.Items("MontoReal").Visible = False
                            Next
                        Else
                            DetailViewTotalesMoneda.Items("Bonificaciones").Visible = False
                            DetailViewTotalesMoneda.Items("MontoReal").Visible = False
                        End If
                    Else
                        DetailViewTotalesMoneda.Items("Bonificaciones").Visible = True
                        DetailViewTotalesMoneda.Items("MontoReal").Visible = True
                    End If


                    If Not bRecalcularTotales Then
                        Cursor.Current = Cursors.Default
                        Exit Sub
                    End If
                    DesactivarScanner()
                    blnScannerActivo = False
                    ' Cambios 28 Abril 2006
                    If Me.fgMovimientos.Rows.Count <= 1 Then
                        MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "AsignarProductos"), MsgBoxStyle.Information)
                        Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageMovimientos
                        Me.TabControlMovProducto.Refresh()
                        Exit Sub
                    End If
                    ' /Cambios 28 Abril 2006
                    Dim aEliminados As New ArrayList
                    If aTransProd.Count > 0 Then
                        For Each otrp As TransProd In aTransProd.Values
                            Me.AplicarTotales(otrp, aEliminados)
                        Next
                        For Each sMonedaID As String In aEliminados
                            If aTransProd.ContainsKey(sMonedaID) Then
                                aTransProd.Remove(sMonedaID)
                            End If
                        Next

                        If aTransProd.Count <= 0 Then
                            oTransProdGenerico.MonedaID = ""
                            oTransProdGenerico.Actualizar(bSurtir)
                        End If
                        If Not IsNothing(aEliminados) AndAlso aEliminados.Count > 0 Then
                            ReacomodarFolios()
                            'ReacomodarTabs
                            For Each oDetailView As Resco.Controls.DetailView.DetailView In aDetailViewTotales.Values
                                If Not oDetailView.Equals(Me.DetailViewTotalesMoneda) Then
                                    oDetailView.Parent.Dispose()
                                    oDetailView.Dispose()
                                End If
                            Next
                            aDetailViewTotales.Clear()
                        End If
                        aEliminados = Nothing
                    Else
                        Me.AplicarTotales(oTransProdGenerico, Nothing)
                    End If

                    'Dim iFormaPago As Integer = 0
                    Dim iFormaVenta As Integer = 0
                    If bYaSePoblo Then
                        'iFormaPago = CType(Me.DetailViewTotalesMachote.Items("FormaPago"), Resco.Controls.DetailView.ItemComboBox).SelectedIndex
                        iFormaVenta = CType(Me.DetailViewGeneral.Items("FormaVenta"), Resco.Controls.DetailView.ItemComboBox).SelectedIndex
                    End If
                    PoblarTabTotales()
                    'SeleccionaMoneda()
                    If Not bYaSePoblo Then
                        'Dim refFormaPago As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewTotalesMachote.Items("FormaPago")
                        'refFormaPago.SelectedIndex = 0
                        Me.EliminaElementosCombos()
                        Me.SeleccionaElementosCombos()
                        bYaSePoblo = True
                    Else
                        'Dim refFormaPago As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewTotalesMachote.Items("FormaPago")
                        'If refFormaPago.SelectedIndex < 0 Then
                        '    refFormaPago.SelectedIndex = iFormaPago
                        'End If
                        Dim refFormaVenta As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewGeneral.Items("FormaVenta")
                        If refFormaVenta.SelectedIndex < 0 Then
                            refFormaVenta.SelectedIndex = iFormaVenta
                        End If
                    End If

                    If bSurtir Then
                        If Not IsNothing(Me.TransProdDevolucion) AndAlso Me.TransProdDevolucion.TransProdId <> "" Then
                            Me.DetailViewTotalesMoneda.Items("Bonificaciones").Text = Format(Me.TransProdDevolucion.Total, "#,##0.00")
                            Me.DetailViewTotalesMoneda.Items("MontoReal").Text = Format(CDec(DetailViewTotalesMoneda.Items("Total").Value) - Me.TransProdDevolucion.Total, "#,##0.00")
                        Else
                            Me.DetailViewTotalesMoneda.Items("Bonificaciones").Text = Format(0, "#,##0.00")
                            Me.DetailViewTotalesMoneda.Items("MontoReal").Text = Format(CDec(DetailViewTotalesMoneda.Items("Total").Value), "#,##0.00")
                        End If
                    End If

                    'Me.VerificarFechaEntrega(oTransProdGenerico.TipoPedido)

                    If oTransProdGenerico.TipoFase = ServicesCentral.TiposFasesPedidos.Surtido Then
                        ButtonDetalleContinuar.Enabled = False
                    End If

                    'With DetailViewTotalesMachote
                    '    If .Items.Count > 0 Then
                    '        .Items(1).SetFocus()
                    '    End If
                    '    DetailViewTotalesMachote.Focus()
                    'End With
                    Me.DetailViewGranTotal.Items("Notas").Value = Me.sNota

                    If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta And oTransProdGenerico.Tipo <> ServicesCentral.TiposTransProd.MovSinInvEV Then
                        If Not Me.TabControlMovProducto.TabPages.Contains(Me.TabPageNoEntregados) Then
                            Me.TabControlMovProducto.TabPages.Add(Me.TabPageNoEntregados)
                        End If
                    End If
                    bRecalcularTotales = False
                    blnScannerActivo = True
                    ActivarScanner()
                Case ConstPosTabPageProductoNegado
                    DesactivarScanner()
                    blnScannerActivo = False
                    PoblarGridProductoNegado()
                    With fgProductoNegado
                        If .Rows.Count > 1 Then
                            .Rows(1).Selected = True
                            .Focus()
                        End If
                    End With

                Case ConstPosTabPageNoEntregados
                    bRecalcularTotales = False
                    DesactivarScanner()
                    blnScannerActivo = False
                    PoblarGridNoEntregados()
                    With fgNoEntregados
                        If .Rows.Count > 1 Then
                            .Rows(1).Selected = True
                            .Focus()
                        End If
                    End With
            End Select
            Cursor.Current = Cursors.Default
        End If
    End Sub
    Private Sub PoblarTabTotales()
        Dim dtTotales As DataTable = oDBVen.RealizarConsultaSQL("Select TRP.TransProdID,TRP.TipoFase, TRP.TipoCambio,TRP.CFVTipo, MON.Tipocodigo, MON.Nombre, MON.MonedaID, TRP.Subtotal,TRP.Impuesto, TRP.Total, TRP.Notas from TransProd TRP inner join Moneda MON ON TRP.MonedaID = MON.MonedaID where TRP.TransProdID in(" & RegresaTransProdActual() & ")", "Totales")
        If dtTotales.Rows.Count > 0 Then
            DetailViewGeneral.Items("TipoFase").Text = ValorReferencia.BuscarEquivalente("TRPFASE", dtTotales.Rows(0)("TipoFase"))
            Vista.LlenarElementosCombo(DetailViewGeneral.Items("FormaVenta"), "FVENTA")
            DetailViewGeneral.Items("FormaVenta").Value = dtTotales.Rows(0)("CFVTipo")
            Dim sFormato As String = "#,##0.00"
            Dim oitemNotas As Resco.Controls.DetailView.Item = DetailViewGranTotal.Items("Notas").Clone
            DetailViewGranTotal.Items.Clear()
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            DetailViewGranTotal.Height += 15
#End If
            aTipoCodigoMonedas.Clear()
            If aTransProd.Count > 0 Then
                Dim aGranTotal As New Generic.Dictionary(Of String, Resco.Controls.DetailView.Item)

                For Each oTRP As TransProd In aTransProd.Values
                    Dim drDetalle As DataRow() = dtTotales.Select("TransProdID='" & oTRP.TransProdId & "'")
                    If aDetailViewTotales.ContainsKey(oTRP.MonedaID) Then
                        With aDetailViewTotales(oTRP.MonedaID)
                            .Items("Folio").Text = oTRP.FolioActual
                            .Items("Subtotal").Text = Format(drDetalle(0)("SubTotal"), sFormato)
                            .Items("Impuesto").Text = Format(drDetalle(0)("Impuesto"), sFormato)
                            .Items("Total").Text = Format(drDetalle(0)("Total"), sFormato)
                        End With
                    Else
                        If aDetailViewTotales.Count <= 0 Then
                            aTipoCodigoMonedas.Add(oTRP.MonedaID, drDetalle(0)("TipoCodigo"))
                            TabPage1.Text = ValorReferencia.BuscarEquivalente("CDGOMON", drDetalle(0)("TipoCodigo"))
                            With DetailViewTotalesMoneda
                                .Items("Folio").Text = oTRP.FolioActual
                                .Items("Subtotal").Text = Format(drDetalle(0)("SubTotal"), sFormato)
                                .Items("Impuesto").Text = Format(drDetalle(0)("Impuesto"), sFormato)
                                .Items("Total").Text = Format(drDetalle(0)("Total"), sFormato)
                            End With
                            aDetailViewTotales.Add(oTRP.MonedaID, DetailViewTotalesMoneda)
                        Else
                            aTipoCodigoMonedas.Add(oTRP.MonedaID, drDetalle(0)("TipoCodigo"))
                            aDetailViewTotales.Add(oTRP.MonedaID, New Resco.Controls.DetailView.DetailView)
                            Dim tp As TabPage = New TabPage()
                            tp.Text = ValorReferencia.BuscarEquivalente("CDGOMON", drDetalle(0)("TipoCodigo"))
                            TabControlTotalesMoneda.TabPages.Add(tp)
                            aDetailViewTotales(oTRP.MonedaID).BorderStyle = BorderStyle.FixedSingle
                            For Each dvItem As Resco.Controls.DetailView.Item In DetailViewTotalesMoneda.Items
                                aDetailViewTotales(oTRP.MonedaID).Items.Add(dvItem.Clone)
                            Next
                            tp.Controls.Add(aDetailViewTotales(oTRP.MonedaID))
                            With aDetailViewTotales(oTRP.MonedaID)
                                .Width = DetailViewTotalesMoneda.Width
                                .Height = DetailViewTotalesMoneda.Height
                                .Items("Folio").Text = oTRP.FolioActual
                                .Items("Subtotal").Text = Format(drDetalle(0)("SubTotal"), sFormato)
                                .Items("Impuesto").Text = Format(drDetalle(0)("Impuesto"), sFormato)
                                .Items("Total").Text = Format(drDetalle(0)("Total"), sFormato)
                                .Items("Bonificaciones").Visible = DetailViewTotalesMoneda.Items("Bonificaciones").Visible
                                .Items("MontoReal").Visible = DetailViewTotalesMoneda.Items("MontoReal").Visible
                            End With
                        End If
                    End If
                    If aTransProd.Count > 1 Then
                        Dim oitem As New Resco.Controls.DetailView.Item()
                        oitem.Enabled = False
                        oitem.Label = refaVista.BuscarMensaje("MsgBox", "TRPTotal").ToUpper & " " & drDetalle(0)("Nombre")
                        oitem.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
                        oitem.LabelForeColor = System.Drawing.Color.DarkBlue
                        oitem.LabelWidth = 90
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
                        oitem.LabelWidth = 240
                        oitem.Height = 32
#End If
                        oitem.Name = oTRP.MonedaID
                        oitem.TextAlign = HorizontalAlignment.Right
                        oitem.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                        oitem.TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                        aGranTotal.Add(oTRP.MonedaID, oitem)
                    End If
                Next
                For Each sMonedaID As String In aGranTotal.Keys
                    If sMonedaID = oConHist.Campos("MonedaID") Then
                        Dim dTotalMon As Decimal = 0
                        For Each dr As DataRow In dtTotales.Rows
                            dTotalMon += dr("Total") * dr("TipoCambio")
                        Next
                        aGranTotal(sMonedaID).Text = Format(dTotalMon, sFormato)
                    Else
                        Dim dTotalMon As Decimal = dtTotales.Select("MonedaID= '" & sMonedaID & "'")(0)("Total")
                        'SOLO FUNCIONA DE MONEDA BASE A OTRA MONEDA SI ES DE MNEXTRANJERA A MNEXTRANJERA FALLA
                        For Each dr As DataRow In dtTotales.Select("MonedaID <>'" & sMonedaID & "'")
                            Dim dTipoCambio As Decimal = oDBVen.EjecutarCmdScalardblSQL("Select TipoCambio from TCMoneda where MonIni='" & sMonedaID & "' and MonFin='" & dr("MonedaID") & "'")
                            dTotalMon += dr("Total") / IIf(dTipoCambio = 0, 1, dTipoCambio)
                        Next
                        aGranTotal(sMonedaID).Text = Format(dTotalMon, sFormato)
                    End If
                    DetailViewGranTotal.Items.Insert(0, aGranTotal(sMonedaID))
                Next
                DetailViewGranTotal.Items.Add(oitemNotas)
            Else
                aTipoCodigoMonedas.Add(oTransProdGenerico.MonedaID, dtTotales.Rows(0)("TipoCodigo"))
                TabPage1.Text = ValorReferencia.BuscarEquivalente("CDGOMON", dtTotales.Rows(0)("TipoCodigo"))
                With DetailViewTotalesMoneda
                    .Items("Folio").Text = oTransProdGenerico.FolioActual
                    .Items("Subtotal").Text = Format(dtTotales.Rows(0)("SubTotal"), sFormato)
                    .Items("Impuesto").Text = Format(dtTotales.Rows(0)("Impuesto"), sFormato)
                    .Items("Total").Text = Format(dtTotales.Rows(0)("Total"), sFormato)
                End With
                DetailViewGranTotal.Items.Add(oitemNotas)
            End If
            DetailViewGranTotal.Items("Notas").Text = dtTotales.Rows(0)("Notas")
        End If

        dtTotales.Dispose()
    End Sub
    Private Sub ReacomodarFolios()
        If aTransProd.Count > 0 Then
            Dim sFolios As String() = Folio.ObtenerVarios(oTransProdGenerico.ModuloMovDetalle.ModuloMovDetalleClave, , aTransProd.Count)
            Dim i As Integer = 0
            For Each oTrp As TransProd In aTransProd.Values
                oTrp.FolioActual = sFolios(i)
                i += 1
            Next
        End If
    End Sub
    Private Sub PoblarGridNoEntregados()
        fgNoEntregados.Rows.Count = 1
        Dim dt As DataTable = oDBVen.RealizarConsultaSQL("Select PRM.Nombre as PromocionNombre,Producto.ProductoClave, Producto.Nombre,  sum(Cantidad) as Cantidad, TipoUnidad from ProductoNegado inner join Producto on ProductoNegado.ProductoClave =  Producto.ProductoClave inner join Promocion PRM on PRM.PromocionClave  = ProductoNegado.PromocionClave WHERE TransProdId in(" & RegresaTransProdActual() & ") GROUP BY PRM.Nombre, Producto.ProductoClave, Producto.Nombre, TipoUnidad order by Producto.ProductoClave, PRM.Nombre ", "NoEntregados")
        Dim sProductoPromocion As String = String.Empty
        fgNoEntregados.Redraw = False
        Dim r As C1.Win.C1FlexGrid.Row
        For Each dr As DataRow In dt.Rows
            If sProductoPromocion <> (dr("ProductoClave").ToString & dr("PromocionNombre").ToString) Then
                sProductoPromocion = dr("ProductoClave").ToString & dr("PromocionNombre").ToString
                r = fgNoEntregados.Rows.Add
                r.IsNode = True
                r.Node.Level = 0
                With fgNoEntregados
                    .Item(r.Index, 0) = dr("ProductoClave")
                    .Item(r.Index, 1) = dr("Nombre")
                    .Item(r.Index, 2) = dr("PromocionNombre")
                End With
            End If
            Dim r2 As C1.Win.C1FlexGrid.Row = fgNoEntregados.Rows.Add
            r2.IsNode = True
            r2.Node.Level = 1
            With fgNoEntregados
                .Item(r2.Index, 0) = ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad"))
                .Item(r2.Index, 1) = dr("Cantidad")
            End With
        Next
        dt.Dispose()
        fgNoEntregados.Redraw = True
    End Sub

    Private Sub ConfiguraGridNoEntregados()
        With fgNoEntregados
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 3
            .Rows.Count = 1
            .Cols(0).Caption = refaVista.BuscarMensaje("MsgBox", "ProductoClave")
            .Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "Nombre")
            .Cols(2).Caption = refaVista.BuscarMensaje("MsgBox", "Nombre")
            .Cols(0).Width = 80
            .Cols(1).Width = 150
            .Cols(2).Width = 200
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            ' initialize outline tree
            .Tree.Column = 0
            .Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf
            .AutoResize = True
            .Redraw = True
        End With
    End Sub

    Private Sub PoblarGridProductoNegado()
        fgProductoNegado.Rows.Count = 1
        Dim dt As DataTable = oDBVen.RealizarConsultaSQL("Select Producto.ProductoClave, Producto.Nombre,  sum(Cantidad) as Cantidad, TipoUnidad from ProductoNegado inner join Producto on ProductoNegado.ProductoClave =  Producto.ProductoClave WHERE TransProdId in(" & RegresaTransProdActual() & ") and ProductoNegado.PromocionClave is null GROUP BY Producto.ProductoClave, Producto.Nombre, TipoUnidad order by Producto.ProductoClave ", "ProductoNegado")
        Dim sProductoClave As String = ""
        fgProductoNegado.Redraw = False
        Dim r As C1.Win.C1FlexGrid.Row
        For Each dr As DataRow In dt.Rows
            If sProductoClave <> dr("ProductoClave").ToString Then
                sProductoClave = dr("ProductoClave").ToString
                r = fgProductoNegado.Rows.Add
                r.IsNode = True
                r.Node.Level = 0
                With fgProductoNegado
                    .Item(r.Index, 0) = dr("ProductoClave")
                    .Item(r.Index, 1) = dr("Nombre")
                End With
            End If
            Dim r2 As C1.Win.C1FlexGrid.Row = fgProductoNegado.Rows.Add
            r2.IsNode = True
            r2.Node.Level = 1
            With fgProductoNegado
                .Item(r2.Index, 0) = ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad"))
                .Item(r2.Index, 1) = dr("Cantidad")
            End With
        Next
        dt.Dispose()
        fgProductoNegado.Redraw = True
    End Sub

    Private Sub ConfiguraGridProductoNegado()
        With fgProductoNegado
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 2
            .Rows.Count = 1
            .Cols(0).Caption = refaVista.BuscarMensaje("MsgBox", "ProductoClave")
            .Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "Nombre")
            .Cols(0).Width = 100
            .Cols(1).Width = 280
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            ' initialize outline tree
            .Tree.Column = 0
            .Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf
            .AutoResize = True
            .Redraw = True
        End With
    End Sub

    'Private Sub EstablecerLimiteDescuentoVendedor()
    '    Dim refNumeric As Resco.Controls.DetailView.ItemNumeric = Me.DetailViewTotales.Items("DescuentoVendedor")
    '    Dim refnumericImporte As Resco.Controls.DetailView.ItemNumeric = Me.DetailViewTotales.Items("DescuentoVendedorImp")
    '    refNumeric.Enabled = Descuento.VerificarAplicacion(Me.TransProd.ModuloMovDetalle.ModuloMovDetalleClave, "AplicaVendedor")
    '    refnumericImporte.Enabled = refNumeric.Enabled
    '    If refNumeric.Enabled Then
    '        If Not refNumeric Is Nothing Then
    '            refNumeric.DecimalPlaces = 4
    '            refNumeric.Minimum = 0
    '            refNumeric.Maximum = oVendedor.LimiteDescuento
    '        End If
    '        If Not refnumericImporte Is Nothing Then
    '            refnumericImporte.DecimalPlaces = 2
    '            refnumericImporte.Minimum = 0
    '            refnumericImporte.Maximum = ((Me.TransProd.SubTDetalle - Me.TransProd.DescuentoImp) * IIf(oVendedor.LimiteDescuento <= 0, 0, (oVendedor.LimiteDescuento / 100)))
    '        End If
    '    End If
    'End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        If Me.PanelFacturas.Visible And Not IsNothing(sender) Then
            If Me.oTransProdGenerico.ClienteActual.CapturaDatosFacturacion Then
                Me.PanelDatosFacturacion.Visible = True
                Me.DetailViewDatosFiscales.Visible = True
                Me.MenuItemRegresar.Enabled = False
                LlenarClienteDomicilio(oTransProdGenerico.ClienteActual.ClienteClave)
                Me.Panel1.Visible = False
                Me.TabControlMovProducto.Visible = False
                Me.PanelFacturas.Visible = False
            Else
                If bHuboCambios = True Then
                    If Not Me.bSurtir Or oTransProdGenerico.TipoFase <> ServicesCentral.TiposFasesPedidos.Surtido Then
                        If MsgBox(refaVista.BuscarMensaje("MsgBox", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If
                End If
                Me.Transaccion.Rollback()
                Me.Transaccion.Dispose()
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.OrigenAdelante = False

            End If
        Else
            If bHuboCambios = True Then
                If Not Me.bSurtir Or oTransProdGenerico.TipoFase <> ServicesCentral.TiposFasesPedidos.Surtido Then
                    If MsgBox(refaVista.BuscarMensaje("MsgBox", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            End If

            ' Salir sin guardar
            'MovProducto.AcumularPuntos(oTransProd, 2)
            If Not bSurtir Then
                If oConHist.Campos("CobrarVentas") AndAlso oTransProdGenerico.Tipo = ServicesCentral.TiposTransProd.Pedido Then
                    If oTransProdGenerico.TransProdId <> "" AndAlso oTransProdGenerico.ClientePagoId <> "" AndAlso ValorReferencia.RecuperaGrupo("PAGO", oTransProdGenerico.ClientePagoId).ToUpper = "E" And oTransProdGenerico.CFVTipo = "1" Then
                        oTransProdGenerico.ClienteActual.ActualizarSaldo(nTotalInicial * oTransProdGenerico.TipoCambio)
                    ElseIf oTransProdGenerico.TransProdId <> "" AndAlso oTransProdGenerico.ClientePagoId <> "" AndAlso ValorReferencia.RecuperaGrupo("PAGO", oTransProdGenerico.ClientePagoId).ToUpper = "E" And oTransProdGenerico.CFVTipo = "2" Then
                        oTransProdGenerico.ClienteActual.ActualizarSaldo(dTotalInicialCredito)
                    End If
                End If
            End If

            Me.Transaccion.Rollback()
            Me.Transaccion.Dispose()
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.OrigenAdelante = False
            'Select Case MsgBox(refaVista.BuscarMensaje("MsgBox", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation)
            '    Case MsgBoxResult.Yes
            '        ' Salir sin guardar
            '        'MovProducto.AcumularPuntos(oTransProd, 2)
            '        Me.Transaccion.Rollback()
            '        Me.Transaccion.Dispose()
            '        Me.DialogResult = Windows.Forms.DialogResult.Cancel
            '        Me.OrigenAdelante = False
            '    Case MsgBoxResult.No
            '        Exit Select
            'End Select
        End If
    End Sub

    Private Sub AceptarTransaccion(ByVal bPedido As Boolean)
        Me.Transaccion.Commit()
        Me.Transaccion = Nothing

        If Not bPedido Then Exit Sub
        ' Si es un nuevo

        If Me.bEsNuevo Then
            ' Si tiene movimientos
            If aTransProd.Count > 0 Then
                Dim bTieneMovimientos As Boolean = False
                For Each oTRP As TransProd In aTransProd.Values
                    bTieneMovimientos = Me.ObtenerNumeroMovimientos(oTRP.TransProdId) > 0
                    If bTieneMovimientos Then
                        ' Confirmar el folio
                        Folio.Confirmar(oTRP.ModuloMovDetalle.ModuloMovDetalleClave)
                    Else
                        ' Borrarlo
                        Me.BorrarPedido(oTRP.TransProdId)
                    End If
                Next
            Else
                Dim bTieneMovimientos As Boolean = Me.ObtenerNumeroMovimientos(oTransProdGenerico.TransProdId) > 0
                If bTieneMovimientos Then
                    ' Confirmar el folio
                    Folio.Confirmar(oTransProdGenerico.ModuloMovDetalle.ModuloMovDetalleClave)
                Else
                    ' Borrarlo
                    Me.BorrarPedido(oTransProdGenerico.TransProdId)
                End If
            End If

        Else
            ' No es nuevo, dejarlo asi
        End If
    End Sub

    Private Sub SalirPlantillaCaptura()
        If MsgBox(refaVista.BuscarMensaje("MsgBox", "TerminarCaptura"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageTotales
            Me.TabControlMovProducto.Refresh()
        End If
    End Sub

    Private Sub FormMovProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.D4 AndAlso e.Modifiers = Keys.Control) OrElse e.KeyCode = Keys.F4 Then
            Dim oFormListasPrecios As New FormListasPrecios
            oFormListasPrecios.ShowDialog()
            oFormListasPrecios.Dispose()
        ElseIf (e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Shift) OrElse e.KeyCode = Keys.F3 Then
            If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then Exit Sub
            BorrarMovimiento()
        End If
    End Sub
    'No hay pago automatico en suKarne
    'Private Function AplicarPagoAutomatico(ByRef refparoTransProd As TransProd, Optional ByVal bReparto As Boolean = False) As Boolean
    '    Try
    '        If oConHist.Campos("PagoAutomatico") And oConHist.Campos("CobrarVentas") Then
    '            Dim dtAbono As DataTable
    '            Dim sABNId As String = ""
    '            Dim dFechaHora As DateTime
    '            dtAbono = oDBVen.RealizarConsultaSQL("SELECT ABNId, FechaHora FROM AbnTrp WHERE TransProdId = '" & refparoTransProd.TransProdId & "'", "AbnTrp")
    '            'Forma de venta contado, forma de pago efectivo
    '            'TODO: Probar Cambio TipoPago
    '            If refparoTransProd.CFVTipo = 1 And (refparoTransProd.ClientePagoId <> "" AndAlso ValorReferencia.RecuperaGrupo("PAGO", refparoTransProd.ClientePagoId).ToUpper = "E") Then
    '                'Dim bExistePago As Boolean
    '                Dim sFolio As String
    '                Dim refMoneda As Resco.Controls.DetailView.ItemComboBox = DetailViewTotales.Items("MonedaId")
    '                Dim sMonedaId As String = refMoneda.Value
    '                If dtAbono.Rows.Count > 0 Then
    '                    Dim sABDId As String
    '                    sABNId = dtAbono.Rows(0)("ABNId")
    '                    dFechaHora = DateTime.Parse(dtAbono.Rows(0)("FechaHora"))
    '                    sABDId = oDBVen.RealizarScalarSQL("SELECT ABDId FROM ABNDetalle WHERE ABNId = '" & sABNId & "'")
    '                    sFolio = oDBVen.RealizarScalarSQL("SELECT Folio FROM Abono WHERE ABNId = '" & sABNId & "'")
    '                    If FormasPago.ModificarAbono(sABNId, refparoTransProd.Total, 0) Then
    '                        If FormasPago.ModificarABNDetalle(sABNId, sABDId, refparoTransProd.ClientePagoId, refparoTransProd.Total, 0, -1, "", False, sMonedaId) Then
    '                            FormasPago.ModificarABNTrp(sABNId, refparoTransProd.TransProdId, dFechaHora, refparoTransProd.Total, "", "")
    '                        End If
    '                    End If
    '                Else
    '                    sFolio = Folio.Obtener(, ServicesCentral.TiposModulosMovDet.Pagos)
    '                    If sFolio = "" Then
    '                        dtAbono.Dispose()
    '                        Return False
    '                    End If
    '                    If bReparto Then
    '                        sABNId = FormasPago.GuardarAbono(0, sFolio, refparoTransProd.VisitaClave1, oDia.DiaActual, Now.Date, refparoTransProd.Total, 0, ServicesCentral.TiposModulosMovDet.Pagos)
    '                    Else
    '                        sABNId = FormasPago.GuardarAbono(0, sFolio, refparoTransProd.VisitaActual, oDia.DiaActual, Now.Date, refparoTransProd.Total, 0, ServicesCentral.TiposModulosMovDet.Pagos)
    '                    End If
    '                    If sABNId <> "" Then
    '                        If FormasPago.GuardarABNDetalle(sABNId, oApp.KEYGEN(1), refparoTransProd.ClientePagoId, refparoTransProd.Total, 0, -1, "", sMonedaId) Then
    '                            FormasPago.GuardarABNTrp(sABNId, refparoTransProd.TransProdId, refparoTransProd.Total, "", "")
    '                        End If
    '                    End If
    '                End If

    '                refparoTransProd.ClienteActual.ActualizarSaldo(Decimal.Negate(refparoTransProd.Total - nTotalInicial))
    '                refparoTransProd.ActualizarSaldo(Decimal.Negate(refparoTransProd.Total))
    '            Else
    '                If dtAbono.Rows.Count > 0 Then
    '                    sABNId = dtAbono.Rows(0)("ABNId")
    '                    dFechaHora = DateTime.Parse(dtAbono.Rows(0)("FechaHora"))
    '                    FormasPago.EliminarABNTrp(sABNId, refparoTransProd.TransProdId, dFechaHora)
    '                    Dim sABDId As String
    '                    sABDId = oDBVen.RealizarScalarSQL("SELECT ABDId FROM ABNDetalle WHERE ABNId = '" & sABNId & "'")
    '                    FormasPago.EliminarABNDetalle(sABNId, sABDId, False)
    '                    FormasPago.EliminarAbono(sABNId)
    '                End If
    '                refparoTransProd.ClienteActual.ActualizarSaldo(nTotalInicial)
    '            End If
    '        End If
    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        Return False
    '    End Try
    'End Function
    'No hay pago automatico en suKarne
    'Private Sub ActualizarPreliquidacion(ByRef refparoTransProd As TransProd, Optional ByVal bReparto As Boolean = False)
    '    Try
    '        If oConHist.Campos("PagoAutomatico") And oConHist.Campos("CobrarVentas") And oConHist.Campos("Preliquidacion") Then
    '            Dim oDT As DataTable = oDBVen.RealizarConsultaSQL("SELECT PLIId, MontoTotal FROM PreLiquidacion where Enviado = 0", "Preliq")
    '            Dim bExistePreliquidacion As Boolean = oDT.Rows.Count > 0
    '            Dim sPLIId As String = ""
    '            Dim nMontoTotal As Double = 0
    '            Dim sComando As String
    '            If bExistePreliquidacion Then
    '                sPLIId = oDT.Rows(0)("PLIId")
    '                nMontoTotal = oDT.Rows(0)("MontoTotal")
    '            End If
    '            'TODO: Probar Cambio TipoPago
    '            If refparoTransProd.CFVTipo = 1 And ValorReferencia.RecuperaGrupo("PAGO", refparoTransProd.ClientePagoId).ToUpper = "E" Then
    '                If bReparto Then
    '                    nMontoTotal += refparoTransProd.Total
    '                Else
    '                    nMontoTotal += refparoTransProd.Total - nTotalInicial
    '                End If

    '                If bExistePreliquidacion Then
    '                    sComando = "update PreLiquidacion set MontoTotal = " & nMontoTotal & " where PLIId = '" & sPLIId & "'"
    '                Else
    '                    sPLIId = oApp.KEYGEN(1)
    '                    sComando = "insert into PreLiquidacion (PLIId, FechaPreLiquidacion, MontoTotal, Enviado) values ('" & sPLIId & "', " & UniFechaSQL(Now) & ", " & nMontoTotal & ", 0)"
    '                End If
    '                oDBVen.EjecutarComandoSQL(sComando)
    '                'Relacionar TransProd con Preliquidación
    '                refparoTransProd.PLIId = sPLIId
    '                refparoTransProd.ActualizarPLIId()
    '            Else
    '                If Not bEsNuevo And (nCFVTipoInicial <> refparoTransProd.CFVTipo Or (sClientePagoIdInicial <> oTransProd.ClientePagoId And ValorReferencia.RecuperaGrupo("PAGO", oTransProd.ClientePagoId).ToUpper <> "E")) Then
    '                    If bReparto Then
    '                        nMontoTotal -= oTransProd.Total
    '                    Else
    '                        nMontoTotal -= nTotalInicial
    '                    End If
    '                    If bExistePreliquidacion Then
    '                        sComando = "update PreLiquidacion set MontoTotal = " & nMontoTotal & " where PLIId = '" & sPLIId & "'"
    '                        oDBVen.EjecutarComandoSQL(sComando)
    '                    End If
    '                    'Quitar relacion de TransProd con Preliquidación
    '                    oTransProd.PLIId = ""
    '                    oTransProd.ActualizarPLIId()
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub

#End Region

#Region " TabPage Movimientos "

    Enum TipoBorrado
        SKU = 1
        ProductoClave = 2
        ProductoUnidad = 3
    End Enum

#Region " Menu contextual "

    Private Sub BorrarMovimiento()
        If Me.fgMovimientos.Rows.Count <= 0 Then Exit Sub

        Dim r As C1.Win.C1FlexGrid.Row = fgMovimientos.Rows(fgMovimientos.Row)

        If r.Node.Level = 0 Then
            If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0210"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If Me.BorrarMovimientoSKU(TipoBorrado.ProductoClave, "", fgMovimientos.GetData(fgMovimientos.Row, 0), fgMovimientos.GetData(fgMovimientos.Row, "TransProdID")) Then
                    Me.PoblarMovimientos()
                End If
            End If
        ElseIf r.Node.Level = 1 Then
            If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0211"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If Me.BorrarMovimientoSKU(TipoBorrado.SKU, fgMovimientos.GetData(fgMovimientos.Row, 3), "", fgMovimientos.GetData(fgMovimientos.Row, "TransProdID")) Then
                    Me.PoblarMovimientos()
                End If
            End If
        ElseIf r.Node.Level = 2 Then
            If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0211"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If Me.BorrarBonificacion(fgMovimientos.GetData(fgMovimientos.Row, ConstIndiceTransProdDetalleID)) Then
                    Me.PoblarMovimientos()
                End If
            End If
        End If

    End Sub
    'Private Function TieneSKU(ByVal parPartida As Integer) As Boolean
    '    If oDBVen.EjecutarCmdScalarIntSQL("Select count(*) from transproddetalle where transprodid='" & Me.TransProd.TransProdId & "' and partida=" & parPartida & " and codigosku<>'' ") > 0 Then Return True
    '    Return False
    'End Function
    Private Sub ContextMenuMovimientos_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuMovimientos.Popup

        ContextMenuMovimientos.MenuItems.Clear()
        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion AndAlso bSurtir Then
            If oTransProdGenerico.TipoFase = ServicesCentral.TiposFasesPedidos.Surtido Then Exit Sub

            Dim r As C1.Win.C1FlexGrid.Row
            r = fgMovimientos.Rows(fgMovimientos.Row)

            If r.Node.Level = 1 Then
                If IsNothing(fgMovimientos.Item(r.Index, ConstIndiceTipoBonificacion)) OrElse fgMovimientos.Item(r.Index, ConstIndiceTipoBonificacion).ToString = "" Then
                    ContextMenuMovimientos.MenuItems.Add(Me.MenuItemDevolucion)
                    'ContextMenuMovimientos.MenuItems.Add(Me.MenuItemBonificacion)
                    'ContextMenuMovimientos.MenuItems.Add(Me.MenuItemPesoReal)
                End If
            ElseIf r.Node.Level = 2 Then
                ContextMenuMovimientos.MenuItems.Add(Me.MenuItemBorrar)
            End If
            Exit Sub
        End If


        If fgMovimientos.Rows.Count > 0 AndAlso fgMovimientos.Row > 0 Then
            Dim r As C1.Win.C1FlexGrid.Row
            r = fgMovimientos.Rows(fgMovimientos.Row)

            'ContextMenuMovimientos.MenuItems.Add(Me.MenuItemAgregar)
            ContextMenuMovimientos.MenuItems.Add(Me.MenuItemBorrar)

            If r.Node.Level = 0 Then
                If SKUInventario.SoloSKU(fgMovimientos.GetData(fgMovimientos.Row, 0), fgMovimientos.GetData(fgMovimientos.Row, "TransProdID")) Then
                    Exit Sub
                End If
                'ElseIf r.Node.Level = 1 Then
                '    If (IsNothing(fgMovimientos.GetData(fgMovimientos.Row, ConstIndiceTipoBonificacion))) OrElse (CType(fgMovimientos.GetData(fgMovimientos.Row, ConstIndiceTipoBonificacion), TipoBonificacion) = TipoBonificacion.BonificacionImporte) Then
                '        ContextMenuMovimientos.MenuItems.Add(Me.MenuItemBonificacion)
                '    End If
                '    If fgMovimientos.GetData(fgMovimientos.Row, ConstIndiceCodigoSKU) <> "" Then
                '        If (IsNothing(fgMovimientos.GetData(fgMovimientos.Row, ConstIndiceTipoBonificacion))) OrElse (CType(fgMovimientos.GetData(fgMovimientos.Row, ConstIndiceTipoBonificacion), TipoBonificacion) = TipoBonificacion.PesoReal) Then
                '            ContextMenuMovimientos.MenuItems.Add(Me.MenuItemPesoReal)
                '        End If
                '    End If
                '    Exit Sub
            End If

            ContextMenuMovimientos.MenuItems.Add(Me.MenuItemModificar)
            'End If

        End If
    End Sub

    Private Sub MenuItemAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemAgregar.Click
        Me.AgregarMovimiento()
    End Sub

    Private Sub MenuItemBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemBorrar.Click
        If fgMovimientos.Rows.Count = 0 Then
            Exit Sub
        End If

        BorrarMovimiento()
    End Sub

    Private Sub MenuItemModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemModificar.Click
        If fgMovimientos.Rows.Count = 0 Then
            Exit Sub
        End If
        Me.ModificarMovimientoDet(fgMovimientos.GetData(fgMovimientos.Row, "Partida"), fgMovimientos.GetData(fgMovimientos.Row, ConstPosProductoClave), fgMovimientos.GetData(fgMovimientos.Row, "TransProdID"))
    End Sub

#End Region

#Region " Pedir Producto "

    Private Sub ButtonVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonVer.Click
        'Se quitan los espacios porque generaba problemas al no encontrar el producto
        Me.TextBoxProducto.Text = Me.TextBoxProducto.Text.Trim()
        ' Llamar la forma para pedir las cantidades por unidad, ademas de buscar
        If Me.TextBoxProducto.Text.Trim = String.Empty Then
            Me.AgregarMovimiento()
        Else
            If TextBoxProducto.Text = String.Empty Then
                Me.SalirPlantillaCaptura()
            Else
                Dim iTipoClave, iEspacios As Integer
                iTipoClave = oConHist.Campos("TipoClaveProducto")
                iEspacios = oConHist.Campos("DigitoClaveProd")
                'If MobileClient.Producto.VerificarTipoClaveProducto(iTipoClave, iEspacios) Then
                If iTipoClave = 2 And Not CheckBoxProducto.Checked Then
                    Dim sProdClave As String = Me.TextBoxProducto.Text
                    If sProdClave.Length < iEspacios Then
                        sProdClave = sProdClave.PadLeft(iEspacios, "0")
                        Me.TextBoxProducto.Text = sProdClave
                    End If
                End If
                'End If
                If Me.Producto.Buscar(Me.TextBoxProducto.Text, CheckBoxProducto.Checked) Then
                    If SKUInventario.ExistenciaDisponible(Producto.ProductoClave) = True Then
                        Me.ModificarMovimientoDet(0, Me.Producto.ProductoClave)
                    Else
                        MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0741"), MsgBoxStyle.Exclamation)
                        Me.TextBoxCodigo.SelectionStart = 0
                        Me.TextBoxCodigo.SelectionLength = Len(Me.TextBoxCodigo.Text)
                        Me.TextBoxCodigo.Focus()
                    End If
                Else
                    MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0005"), MsgBoxStyle.Exclamation)
                    Me.TextBoxProducto.SelectionStart = 0
                    Me.TextBoxProducto.SelectionLength = Len(Me.TextBoxProducto.Text)
                    Me.TextBoxProducto.Focus()
                End If
            End If
        End If
    End Sub
    'No se va a usar para SuKarne
    'Private Function ValidarTotalPreliquidacion() As Boolean
    '    'TODO: Probar Cambio TipoPago
    '    If oTransProd.CFVTipo = 1 And ValorReferencia.RecuperaGrupo("PAGO", Me.TransProd.ClientePagoId).ToUpper = "E" Then
    '        If oConHist.Campos("PagoAutomatico") And oConHist.Campos("CobrarVentas") And oConHist.Campos("Preliquidacion") Then
    '            If nTotalInicial > oTransProd.Total Then
    '                Dim nMontoTotal As Double = oDBVen.RealizarScalarSQL("SELECT MontoTotal FROM PreLiquidacion where Enviado = 0")
    '                If (nTotalInicial - oTransProd.Total) > nMontoTotal Then
    '                    Return False
    '                End If
    '            End If
    '        End If
    '    End If
    '    Return True
    'End Function
    'TODO: Probar Cambio TipoPago
    Private Function ValidarLimiteCredito() As Boolean
        Dim res As Boolean = True

        If (oConHist.Campos("TipoLimiteCredito") = 2) Then
            If oTransProdGenerico.CFVTipo = 2 Then
                Dim dtCFV As DataTable = oDBVen.RealizarConsultaSQL("SELECT ValidaLimite, LimiteCredito FROM CLIFormaVenta WHERE CFVTipo = 2 AND ClienteClave = '" + oTransProdGenerico.ClienteActual.ClienteClave + "'", "CLIFormaVenta")
                If (dtCFV.Rows.Count > 0) Then

                    Dim filaCFV As DataRow = dtCFV.Rows(0)
                    Dim limiteC As Double = Convert.ToDouble(filaCFV("LimiteCredito"))
                    If CBool(filaCFV("ValidaLimite")) Then
                        Dim dTotalTransProd As Decimal
                        If aTransProd.Count > 0 Then
                            For Each oTRP As TransProd In aTransProd.Values
                                dTotalTransProd += oTRP.Total * oTRP.TipoCambio
                            Next
                        Else
                            dTotalTransProd = oTransProdGenerico.Total * oTransProdGenerico.TipoCambio
                        End If

                        Dim strSQL = ""
                        Dim valor As Double
                        If oTransProdGenerico.ClienteActual.CriterioCredito <> 0 Then
                            If (CBool(oConHist.Campos("CobrarVentas"))) Then
                                valor = oDBVen.RealizarScalarSQL("SELECT case when sum(saldo * TipoCambio) is null then 0 else sum(saldo * TipoCambio) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oTransProdGenerico.ClienteClave + "' AND Tipo = 1 AND CFVTipo = 2 AND TipoFase > 0")
                                valor = valor + dTotalTransProd - dTotalInicialCredito

                                'Else
                                '    valor = Convert.ToDouble(oDBVen.RealizarScalarSQL("SELECT case when sum(saldo) is null then 0 else sum(saldo) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oTransProdGenerico.ClienteClave + "' AND Tipo = 8 AND CFVTipo = 2 AND TipoFase > 0"))
                                '    valor += Convert.ToDouble(oDBVen.RealizarScalarSQL("SELECT case when sum(saldo) is null then 0 else sum(saldo) end FROM Transprod TRP inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave WHERE v.ClienteClave = '" + oTransProdGenerico.ClienteClave + "' AND Tipo = 1 AND CFVTipo = 2 AND TipoFase > 0 AND FacturaId is null"))
                                '    valor = valor + dTotalTransProd - nTotalInicialCredito
                            End If
                            If Not oTransProdGenerico.ClienteActual.ActualizaSaldoCheque Then
                                Dim aGrupo As New ArrayList()
                                aGrupo.Add("EB")
                                Dim sVarCodigos As String = ValorReferencia.RecuperaVARVGrupoIds("PAGO", aGrupo)
                                If sVarCodigos.Length > 0 Then
                                    strSQL = "select case when sum(ad.importe * TRP.TipoCambio) is null then 0 else sum(ad.importe * TRP.TipoCambio) end  from  abndetalle AD "
                                    strSQL &= "inner join abntrp A on A.abnId = AD.ABNId "
                                    strSQL &= "inner join transprod TRP on TRP.TransProdId = A.TransProdId "
                                    strSQL &= "inner join visita v on v.visitaclave = TRP.visitaclave and v.diaclave = TRP.diaclave "
                                    strSQL &= "WHERE AD.TipoPago in(" & sVarCodigos & ") AND v.ClienteClave = '" + oTransProdGenerico.ClienteClave
                                    strSQL &= "' and TRP.CFVTipo = 2 and TRP.tipo = " & IIf(CBool(oConHist.Campos("CobrarVentas")), "1", "8")
                                    strSQL &= " and TRP.tipofase >0"
                                    valor += oDBVen.RealizarScalarSQL(strSQL)

                                    strSQL = "select case when sum(abn.saldo * TRP.TipoCambio) is null then 0 else sum(abn.saldo * TRP.TipoCambio) end  from  abono ABN "
                                    strSQL &= "inner join visita v on v.visitaclave = ABN.visitaclave and v.diaclave = ABN.diaclave inner join AbnTrp ABT on ABT.ABNId = ABN.ABNId inner join TransProd TRP on TRP.TransProdID = ABT.TransProdID "
                                    strSQL &= "WHERE v.ClienteClave = '" & oTransProdGenerico.ClienteClave & "' AND ABN.ABNid not in("
                                    strSQL &= "SELECT distinct abn1.abnid FROM abono abn1 "
                                    strSQL &= "inner join abndetalle ad1 on abn1.abnid = ad1.abnid "
                                    strSQL &= "inner join visita v1 on v1.visitaclave = ABN1.visitaclave and v1.diaclave = ABN1.diaclave "
                                    strSQL &= "where v.ClienteClave = '" & oTransProdGenerico.ClienteClave & "' and ad1.TipoPago in(" & sVarCodigos & ")) "
                                    valor -= oDBVen.RealizarScalarSQL(strSQL)
                                End If
                            Else
                                strSQL = "select case when sum(abn.saldo * TRP.TipoCambio) is null then 0 else sum(abn.saldo * TRP.TipoCambio) end  from  abono ABN "
                                strSQL &= "inner join visita v on v.visitaclave = ABN.visitaclave and v.diaclave = ABN.diaclave inner join AbnTrp ABT on ABT.ABNId = ABN.ABNId inner join TransProd TRP on TRP.TransProdID = ABT.TransProdID "
                                strSQL &= "WHERE v.ClienteClave = '" & oTransProdGenerico.ClienteClave & "'"
                                valor -= oDBVen.RealizarScalarSQL(strSQL)
                            End If
                        ElseIf oTransProdGenerico.ClienteActual.CriterioCredito = 0 Then
                            If (CBool(oConHist.Campos("CobrarVentas"))) Then
                                valor += oDBVen.RealizarScalarSQL("SELECT saldoefectivo FROM Cliente WHERE ClienteClave = '" + oTransProdGenerico.ClienteClave + "';")
                                valor += (dTotalTransProd - dTotalInicialCredito)
                            End If
                        End If

                        valor = limiteC - valor
                        If (valor < 0) Then
                            Dim porcentajeRiesgo As Double = Convert.ToDouble(oConHist.Campos("PorcentajeRiesgo"))
                            Dim Riesgo As Double = (limiteC * porcentajeRiesgo) / 100
                            If (Math.Abs(valor) > Riesgo) Then
                                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0599").Replace("$0$", Math.Abs(valor).ToString()), MsgBoxStyle.Exclamation)
                                res = False
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Return res
    End Function
    Public Function ValidarInventarioSurtir() As Boolean
        Dim slTransProd As String = RegresaTransProdActual()
        Dim DataTableDetalle As DataTable = oDBVen.RealizarConsultaSQL("SELECT ProductoClave,TipoUnidad,Cantidad,codigosku FROM TransProdDetalle WHERE TransProdID in(" & slTransProd & ") ORDER BY Partida", "Detalle")
        Dim bCondicion As Boolean = True

        For Each refDataRow As DataRow In DataTableDetalle.Rows
            With refDataRow

                If Not SKUInventario.ValidarExistenciaDisponibleASurtir(.Item("CodigoSKU").ToString, .Item("ProductoClave"), .Item("TipoUnidad"), .Item("Cantidad")) Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0714").Replace("$0$", .Item("ProductoClave")), MsgBoxStyle.Information)
                    Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageMovimientos
                    bCondicion = False
                    Exit For
                End If

            End With
        Next

        DataTableDetalle.Dispose()
        DataTableDetalle = Nothing
        Return bCondicion
    End Function
    Private Sub ButtonDetalleContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDetalleContinuar.Click

        If bSurtir Then
            'Promocion.InsertarPromociones()
            'If Not ValidarInventarioSurtir() Then
            '    Exit Sub
            'End If
            HabilitarBotones(False)
            oTransProdGenerico.VisitaClave1 = sVisitaActual
            oTransProdGenerico.DiaClave1 = oDia.DiaActual

            Me.AsignarValoresCapturados()
            oTransProdGenerico.Actualizar(bSurtir)
            Dim scadena As String = ""
            ' Actualizar el inventario
            If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion And oTransProdGenerico.TipoFase = ServicesCentral.TiposFasesPedidos.Captura Then

                Dim DataTableDetalle As DataTable = oDBVen.RealizarConsultaSQL("SELECT ProductoClave,TipoUnidad,Cantidad,Cantidad1,CodigoSKU FROM TransProdDetalle WHERE TransProdID='" & oTransProdGenerico.TransProdId & "' ORDER BY Partida", "Detalle")
                For Each refDataRow As DataRow In DataTableDetalle.Rows
                    With refDataRow
                        SKUInventario.ActualizarSKU(SKUInventario.SKUMovimiento.Apartar, .Item("CodigoSKU").ToString, .Item("ProductoClave"), .Item("TipoUnidad"), CDbl(.Item("Cantidad")) * (-1), CDbl(.Item("Cantidad1")) * (-1), scadena)
                        SKUInventario.ActualizarSKU(SKUInventario.SKUMovimiento.Incrementar, .Item("CodigoSKU").ToString, .Item("ProductoClave"), .Item("TipoUnidad"), CDbl(.Item("Cantidad")) * (-1), CDbl(.Item("Cantidad1")) * (-1), scadena)
                    End With
                Next
                Application.DoEvents()
            End If

            If Not IsNothing(Me.TransProdDevolucion) AndAlso Me.TransProdDevolucion.TransProdId <> "" Then
                If Me.TransProdDevolucion.Total <= 0 Then
                    Me.TransProdDevolucion.Eliminar()
                Else
                    Me.TransProdDevolucion.Actualizar(bSurtir)
                    CrearNotaCredito(Me.TransProdDevolucion)
                End If
            End If

            oTransProdGenerico.SurtirPedido(oTransProdGenerico.TransProdId)

            If Not IsNothing(Me.TransProdDevolucion) AndAlso Me.TransProdDevolucion.TransProdId <> "" Then
                Dim dtDevueltos As DataTable = oDBVen.RealizarConsultaSQL("Select CodigoSKU,ProductoClave, TipoUnidad, Cantidad, Cantidad1 from TransProdDetalle where TransProdID='" & Me.TransProdDevolucion.TransProdId & "' and round(Cantidad,2)>0 and round(Cantidad1,2) >0 ", "Devoluciones")
                For Each dr As DataRow In dtDevueltos.Rows
                    SKUInventario.ActualizarSKU(SKUInventario.SKUMovimiento.Incrementar, dr("CodigoSKU"), dr("ProductoClave"), dr("TipoUnidad"), dr("Cantidad"), dr("Cantidad1"), scadena)
                    If Not IsDBNull(dr("CodigoSKU")) AndAlso dr("CodigoSKU") <> "" Then
                        oDBVen.EjecutarComandoSQL("Update TRPPedimento set Cancelado = 1, Enviado = 0, MfechaHora = getdate() where TransProdID='" & Me.TransProdDevolucion.FacturaId & "' and ProductoClave='" & dr("ProductoClave") & "' and CodigoSKU='" & dr("CodigoSKU") & "' ")
                    Else
                        oDBVen.EjecutarComandoSQL("Update TRPPedimento set Cancelado = 1, Enviado = 0, MfechaHora = getdate() where TransProdID='" & Me.TransProdDevolucion.FacturaId & "' and ProductoClave='" & dr("ProductoClave") & "' and CodigoSKU is null")
                    End If
                Next
                dtDevueltos.Dispose()
                If oConHist.Campos("CobrarVentas") Then
                    oTransProdGenerico.ActualizarSaldo(Decimal.Negate(Me.TransProdDevolucion.Total))
                End If
            End If

            'If oTransProdGenerico.Tipo = ServicesCentral.TiposTransProd.Pedido AndAlso (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta Or oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion) AndAlso oTransProdGenerico.ModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Pedido Then
            'If Me.AplicarPagoAutomatico(oTransProdGenerico, True) Then
            '    Me.ActualizarPreliquidacion(oTransProdGenerico, True)
            'Else
            'HabilitarBotones(True)
            'Exit Sub
            'End If
            'End If

            DesactivarScanner()
            blnScannerActivo = False

            If oConHist.Campos("CobrarVentas") Then
                If Not IsNothing(Me.TransProdDevolucion) AndAlso Me.TransProdDevolucion.TransProdId <> "" Then
                    oTransProdGenerico.ClienteActual.ActualizarSaldo((Me.TransProdDevolucion.Total * -1) * oTransProdGenerico.TipoCambio)
                    'Else
                    '        oTransProdGenerico.ClienteActual.ActualizarSaldo(oTransProdGenerico.Total * oTransProdGenerico.TipoCambio)
                End If
            End If
            Me.AceptarTransaccion(True)

            If oTransProdGenerico.TipoDoc = 1 Then
                If oVendedor.motconfiguracion.MensajeImpresion Then
                    If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                        ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, oTransProdGenerico.TransProdId, oTransProdGenerico.Tipo, 28, oTransProdGenerico.ClienteActual, oTransProdGenerico.VisitaActual)
                    End If
                End If
            ElseIf oTransProdGenerico.TipoDoc = 2 Then
                If IsNothing(oTransProdGenerico.FacturaId) OrElse IsDBNull(oTransProdGenerico.FacturaId) OrElse oTransProdGenerico.FacturaId = "" Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0886"))
                End If

                If oVendedor.motconfiguracion.MensajeImpresion Then
                    If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                        If IsNothing(oTransProdGenerico.FacturaId) OrElse IsDBNull(oTransProdGenerico.FacturaId) OrElse oTransProdGenerico.FacturaId = "" Then
                            ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, oTransProdGenerico.TransProdId, oTransProdGenerico.Tipo, 28, oTransProdGenerico.ClienteActual, oTransProdGenerico.VisitaActual)
                        Else
                            If Not IsNothing(oTransProdNota) AndAlso Not IsDBNull(oTransProdNota) Then
                                ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, New String() {oTransProdGenerico.FacturaId, oTransProdNota.TransProdId}, -1, 0, oTransProdGenerico.ClienteActual, oTransProdGenerico.VisitaActual)
                            Else
                                ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, oTransProdGenerico.FacturaId, 8, 0, oTransProdGenerico.ClienteActual, oTransProdGenerico.VisitaActual)
                            End If
                        End If
                    End If
                End If
            ElseIf oTransProdGenerico.TipoDoc = 3 AndAlso Not IsNothing(oTransProdGenerico.FacturaId) AndAlso Not IsDBNull(oTransProdGenerico.FacturaId) AndAlso oTransProdGenerico.FacturaId <> "" Then
                If oVendedor.motconfiguracion.MensajeImpresion Then
                    If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                        If Not IsNothing(oTransProdNota) AndAlso Not IsDBNull(oTransProdNota) Then
                            ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, New String() {oTransProdGenerico.FacturaId, oTransProdNota.TransProdId}, -1, 0, oTransProdGenerico.ClienteActual, oTransProdGenerico.VisitaActual)
                        Else
                            ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, oTransProdGenerico.FacturaId, 8, 0, oTransProdGenerico.ClienteActual, oTransProdGenerico.VisitaActual)
                        End If
                    End If
                End If
            ElseIf oTransProdGenerico.TipoDoc = 3 AndAlso Not IsNothing(oTransProdNota) AndAlso Not IsDBNull(oTransProdNota) Then
                ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, oTransProdNota.TransProdId, 10, 30, oTransProdGenerico.ClienteActual, oTransProdNota.VisitaActual)
            End If

            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else

            ' Actualizar TransProd (por si se cambiaron los porcentajes de descuento del Vendedor)
            HabilitarBotones(False)
            If Not Me.ValidarCamposRequeridos Then
                HabilitarBotones(True)
                Exit Sub
            End If
            Me.AsignarValoresCapturados()
            'If oTransProdGenerico.Tipo = ServicesCentral.TiposTransProd.Pedido AndAlso oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta AndAlso oTransProdGenerico.ModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Pedido Then
            '    If Not ValidarTotalPreliquidacion() Then
            '        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0590"), MsgBoxStyle.Exclamation)
            '        HabilitarBotones(True)
            '        Exit Sub
            '    End If
            'End If
            If oTransProdGenerico.Tipo = ServicesCentral.TiposTransProd.Pedido AndAlso oTransProdGenerico.ModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Pedido Then
                If Not ValidarLimiteCredito() Then
                    HabilitarBotones(True)
                    Exit Sub
                End If
            End If

            'Si se esta manejando mas de una moneda
            If aTransProd.Count > 0 Then
                For Each oTRP As TransProd In aTransProd.Values

                    oTRP.Actualizar(bSurtir)
                    oTRP.ObtenerDescuentoVendedor()

                    MovProducto.AcumularPuntos(oTRP, 2)
                    Cuotas.CalcularCuotasxEfectivo(oTRP, False)

                    If oTRP.Tipo = ServicesCentral.TiposTransProd.Pedido AndAlso (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta Or oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion) AndAlso oTRP.ModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Pedido Then

                        MobileClient.TransProd.SurtirPedido(oTRP.TransProdId, oTRP.ClienteActual)
                        If oConHist.Campos("CobrarVentas") Then
                            oTRP.ClienteActual.ActualizarSaldo(oTRP.Total * oTRP.TipoCambio)
                        End If

                        GuardarPedimentos(oTRP.TransProdId)
                        'If Me.AplicarPagoAutomatico(oTRP) Then
                        '    Me.ActualizarPreliquidacion(oTRP)
                        'Else
                        'HabilitarBotones(True)
                        'Exit Sub
                        'End If
                    End If
                    bGuardado = True
                Next
                Me.AceptarTransaccion(True)
                If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
                Me.Transaccion = Nothing

                HabilitarBotones(False)

                'Validar si hay folios
                If Not FolioFiscal.ValidaExistencia(1) Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0659"))
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Exit Sub
                End If

                'Dim dtSubEmpresa As DataTable = oDBVen.RealizarConsultaSQL("Select SEM.SubEmpresaID, SEM.NombreEmpresa from SubEmpresa SEM inner join SEMHist SEH on SEM.SubEmpresaID = SEH.SubEmpresaID where SEH.ComprobanteDig=1 and (not ArchivoPEM like '' and not ArchivoPEM is null) ", "SubEmpresas")

                If SubEmpresa.aSubEmpresa.Count <= 0 Then
                    'MsgBox(refaVista.BuscarMensaje("MsgBox", "E0659"))
                    MsgBox("No existe subEmpresa disponible para facturar")
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Exit Sub
                End If

                ' Iniciar la transaccion Factura
                If oDBVen.oConexion.State = ConnectionState.Closed Then
                    oDBVen.oConexion.Open()
                End If
                Me.Transaccion = oDBVen.oConexion.BeginTransaction()

                For Each oTRP As TransProd In aTransProd.Values
                    CrearFactura(oTRP)
                Next

                If oTransProdGenerico.ClienteActual.CapturaDatosFacturacion Then
                    Me.PanelFacturas.Visible = False
                    Me.PanelDatosFacturacion.Visible = True
                    Me.DetailViewDatosFiscales.Visible = True
                    Me.MenuItemRegresar.Enabled = False
                    LlenarClienteDomicilio(oTransProdGenerico.ClienteActual.ClienteClave)
                    Me.Panel1.Visible = False
                    Me.TabControlMovProducto.Visible = False
                Else
                    MostrarFacturas()
                End If
                'If oTransProdGenerico.Tipo = ServicesCentral.TiposTransProd.Pedido Or oTransProdGenerico.Tipo = ServicesCentral.TiposTransProd.MovSinInvEV Then
                '    HabilitarBotones(False)
                '    If oVendedor.motconfiguracion.MensajeImpresion Then
                '        If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                '            If oTransProdGenerico.Tipo = ServicesCentral.TiposTransProd.Pedido Then
                '                Select Case oVendedor.TipoModulo
                '                    Case ServicesCentral.TiposModulos.Venta
                '                        'For Each oTRP As TransProd In aTransProd.Values
                '                        ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, RegresaArregloTransProds, oTransProdGenerico.Tipo, 1, oTransProdGenerico.ClienteActual, oTransProdGenerico.VisitaActual)
                '                        'Next
                '                    Case ServicesCentral.TiposModulos.Preventa
                '                        'For Each oTRP As TransProd In aTransProd.Values
                '                        ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, RegresaArregloTransProds, oTransProdGenerico.Tipo, 27, oTransProdGenerico.ClienteActual, oTransProdGenerico.VisitaActual)
                '                        'Next
                '                    Case ServicesCentral.TiposModulos.Distribucion
                '                        'For Each oTRP As TransProd In aTransProd.Values
                '                        ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, RegresaArregloTransProds, oTransProdGenerico.Tipo, 28, oTransProdGenerico.ClienteActual, oTransProdGenerico.VisitaActual)
                '                        'Next
                '                End Select
                '            Else
                '                For Each oTRP As TransProd In aTransProd.Values
                '                    ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, oTransProdGenerico.TransProdId, oTransProdGenerico.Tipo, oTransProdGenerico.Tipo, oTransProdGenerico.ClienteActual, oTransProdGenerico.VisitaActual)
                '                Next
                '            End If
                '        End If
                '    End If
                '    HabilitarBotones(True)
                'End If
                DesactivarScanner()
                blnScannerActivo = False

                'Me.Close()
                'Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                'If oTransProdGenerico.DescuentoVendedor <> 0 And Trim(oTransProdGenerico.Notas) = "" Then
                '    MsgBox(Replace(refaVista.BuscarMensaje("MsgBox", "BE0001"), "$0$", DetailViewTotalesMachote.Items("Notas").Label), MsgBoxStyle.Exclamation)
                '    HabilitarBotones(True)
                '    Exit Sub
                'End If

                oTransProdGenerico.Actualizar(bSurtir)
                oTransProdGenerico.ObtenerDescuentoVendedor()

                MovProducto.AcumularPuntos(oTransProdGenerico, 2)
                Cuotas.CalcularCuotasxEfectivo(oTransProdGenerico, False)
                If oTransProdGenerico.Tipo = ServicesCentral.TiposTransProd.Pedido AndAlso (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta Or oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion) AndAlso oTransProdGenerico.ModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Pedido Then

                    MobileClient.TransProd.SurtirPedido(oTransProdGenerico.TransProdId, oTransProdGenerico.ClienteActual)
                    If oConHist.Campos("CobrarVentas") Then
                        oTransProdGenerico.ClienteActual.ActualizarSaldo(oTransProdGenerico.Total * oTransProdGenerico.TipoCambio)
                    End If

                    GuardarPedimentos(oTransProdGenerico.TransProdId)
                    'If Me.AplicarPagoAutomatico(oTransProdGenerico) Then
                    '    Me.ActualizarPreliquidacion(oTransProdGenerico)
                    'Else
                    'HabilitarBotones(True)
                    'Exit Sub
                    'End If
                End If
                bGuardado = True

                Me.AceptarTransaccion(True)
                If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
                Me.Transaccion = Nothing

                If oTransProdGenerico.Tipo = ServicesCentral.TiposTransProd.Pedido Or oTransProdGenerico.Tipo = ServicesCentral.TiposTransProd.MovSinInvEV Then
                    HabilitarBotones(False)

                    'Validar si hay folios
                    If Not FolioFiscal.ValidaExistencia(1) Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0659"))
                        Me.DialogResult = Windows.Forms.DialogResult.Cancel
                        Exit Sub
                    End If

                    'Dim dtSubEmpresa As DataTable = oDBVen.RealizarConsultaSQL("Select SEM.SubEmpresaID, SEM.NombreEmpresa from SubEmpresa SEM inner join SEMHist SEH on SEM.SubEmpresaID = SEH.SubEmpresaID where SEH.ComprobanteDig=1 and (not ArchivoPEM like '' and not ArchivoPEM is null) ", "SubEmpresas")

                    If SubEmpresa.aSubEmpresa.Count <= 0 Then
                        'MsgBox(refaVista.BuscarMensaje("MsgBox", "E0659"))
                        MsgBox("No existe subEmpresa disponible para facturar")
                        Me.DialogResult = Windows.Forms.DialogResult.Cancel
                        Exit Sub
                    End If

                    ' Iniciar la transaccion Factura
                    If oDBVen.oConexion.State = ConnectionState.Closed Then
                        oDBVen.oConexion.Open()
                    End If
                    Me.Transaccion = oDBVen.oConexion.BeginTransaction()

                    CrearFactura(oTransProdGenerico)

                    If oTransProdGenerico.ClienteActual.CapturaDatosFacturacion Then
                        Me.PanelFacturas.Visible = False
                        Me.PanelDatosFacturacion.Visible = True
                        Me.DetailViewDatosFiscales.Visible = True
                        Me.MenuItemRegresar.Enabled = False
                        LlenarClienteDomicilio(oTransProdGenerico.ClienteActual.ClienteClave)
                        Me.Panel1.Visible = False
                        Me.TabControlMovProducto.Visible = False
                    Else
                        MostrarFacturas()
                    End If
                    ''Terminar Transaccion Factura
                    'Me.AceptarTransaccion()
                    'If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
                    'Me.Transaccion = Nothing

                    'If oVendedor.motconfiguracion.MensajeImpresion Then
                    '    If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                    '        If oTransProdGenerico.Tipo = ServicesCentral.TiposTransProd.Pedido Then
                    '            Select Case oVendedor.TipoModulo
                    '                Case ServicesCentral.TiposModulos.Venta
                    '                    ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, oTransProdGenerico.TransProdId, oTransProdGenerico.Tipo, 1, oTransProdGenerico.ClienteActual, oTransProdGenerico.VisitaActual)
                    '                Case ServicesCentral.TiposModulos.Preventa
                    '                    ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, oTransProdGenerico.TransProdId, oTransProdGenerico.Tipo, 27, oTransProdGenerico.ClienteActual, oTransProdGenerico.VisitaActual)
                    '                Case ServicesCentral.TiposModulos.Distribucion
                    '                    ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, oTransProdGenerico.TransProdId, oTransProdGenerico.Tipo, 28, oTransProdGenerico.ClienteActual, oTransProdGenerico.VisitaActual)
                    '            End Select
                    '        Else
                    '            ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, oTransProdGenerico.TransProdId, oTransProdGenerico.Tipo, oTransProdGenerico.Tipo, oTransProdGenerico.ClienteActual, oTransProdGenerico.VisitaActual)
                    '        End If
                    '    End If
                    'End If
                    'HabilitarBotones(True)
                End If
                DesactivarScanner()
                blnScannerActivo = False

                'Me.Close()
                'Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
        End If
    End Sub


    Private Function CrearFacturaVirtual() As String
        Dim oTransProdFactura As TransProd = New TransProd()
        oTransProdFactura.TransProdId = oApp.KEYGEN(1)
        oTransProdFactura.VisitaActual = sVisitaActual
        oTransProdFactura.ModuloMovDetalle = oTransProdGenerico.ModuloMovDetalle
        oTransProdFactura.FolioActual = oTransProdGenerico.FolioActual
        oTransProdFactura.Tipo = ServicesCentral.TiposTransProd.Factura
        oTransProdFactura.TipoFase = ServicesCentral.TiposFasesPedidos.Captura
        oTransProdFactura.FechaHoraAlta = Now
        oTransProdFactura.SubTotal = oTransProdGenerico.SubTotal
        oTransProdFactura.Impuesto = oTransProdGenerico.Impuesto
        oTransProdFactura.Total = oTransProdGenerico.Total
        oTransProdFactura.Saldo = 0
        oTransProdFactura.CFVTipo = oTransProdGenerico.CFVTipo
        oTransProdFactura.MonedaID = oTransProdGenerico.MonedaID
        oTransProdFactura.TipoCambio = oTransProdGenerico.TipoCambio
        oTransProdFactura.CrearFacturaElectronica(oTransProdGenerico.SubEmpresaActual.SubEmpresaId)

        oDBVen.EjecutarComandoSQL("UPDATE TransProd SET FacturaID ='" & oTransProdFactura.TransProdId & "', MFechaHora=getdate(), MUsuarioID='" & oVendedor.UsuarioId & "' where TransProdID='" & oTransProdGenerico.TransProdId & "'")

        Return oTransProdFactura.TransProdId

    End Function

    Private Sub CrearFactura(ByRef oTransProd As TransProd)
        Dim FolioF As New FolioFiscal
        Dim LFolios As New System.Collections.Generic.List(Of FolioFiscal)
        Dim Mensajes As String = ""
        Dim oFolioFiscal As FolioFiscal
        oFolioFiscal = FolioF.ObtenerFolioFiscal(oTransProd.SubEmpresaActual.SubEmpresaId, 1, Mensajes)

        If Mensajes <> "" Then
            If Mensajes = "E0855" Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0855"))
            Else
                MsgBox(Mensajes)
            End If
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Exit Sub
        End If

        Dim oTransProdFactura As TransProd = New TransProd()
        oTransProdFactura.TransProdId = oApp.KEYGEN(1)
        oTransProdFactura.VisitaActual = oTransProd.VisitaActual
        oTransProdFactura.ModuloMovDetalle = oTransProd.ModuloMovDetalle
        oTransProdFactura.FolioActual = oFolioFiscal.Formato
        oTransProdFactura.Tipo = ServicesCentral.TiposTransProd.Factura
        oTransProdFactura.TipoFase = ServicesCentral.TiposFasesPedidos.Captura
        oTransProdFactura.FechaHoraAlta = Now
        oTransProdFactura.SubTotal = oTransProd.SubTotal
        oTransProdFactura.Impuesto = oTransProd.Impuesto
        oTransProdFactura.Total = oTransProd.Total
        oTransProdFactura.Saldo = 0
        oTransProdFactura.CFVTipo = oTransProd.CFVTipo
        oTransProdFactura.MonedaID = oTransProd.MonedaID
        oTransProdFactura.TipoCambio = oTransProd.TipoCambio
        oTransProdFactura.CrearFacturaElectronica(oTransProd.SubEmpresaActual.SubEmpresaId)
        aTransProdFactura.Add(oTransProd.MonedaID, oTransProdFactura)

        oDBVen.EjecutarComandoSQL("UPDATE TransProd SET FacturaID ='" & oTransProdFactura.TransProdId & "' where TransProdID='" & oTransProd.TransProdId & "'")

        Dim dtClienteDom As DataTable = oDBVen.RealizarConsultaSQL("Select * from ClienteDomicilio Where tipo=1 and ClienteClave='" & oTransProd.ClienteActual.ClienteClave & "'", "Domiclio")

        Dim dtCentroExpedicion As DataTable = oDBVen.RealizarConsultaSQL("select ce.* from centroexpedicion ce inner join foliofiscal ff on ff.centroexpid=ce.centroexpid where ff.folioid = '" & oFolioFiscal.FolioID & "' and ff.fosid='" & oFolioFiscal.FosID & "' and ce.SubEmpresaID='" & oTransProd.SubEmpresaActual.SubEmpresaId & "' ", "CentroExpedicion")
        Dim dtCentroExpedicionPadre As DataTable
        If dtCentroExpedicion.Rows(0)("Tipo") = 1 Then
            dtCentroExpedicionPadre = oDBVen.RealizarConsultaSQL("select * from centroexpedicion where centroexpid='" & dtCentroExpedicion.Rows(0)("CentroExpPadreID") & "' and tipo=0", "CentroExpedicion")
        Else
            dtCentroExpedicionPadre = dtCentroExpedicion.Copy
        End If

        Dim oTRPDatoFiscal As New TRPDatoFiscal
        oTRPDatoFiscal.TransProdID = oTransProdFactura.TransProdId
        oTRPDatoFiscal.FolioID = oFolioFiscal.FolioID
        oTRPDatoFiscal.FOSId = oFolioFiscal.FosID
        oTRPDatoFiscal.NumCertificado = oFolioFiscal.NumCertificado
        oTRPDatoFiscal.Serie = oFolioFiscal.Serie
        oTRPDatoFiscal.Aprobacion = oFolioFiscal.Aprobacion
        oTRPDatoFiscal.AnioAprobacion = oFolioFiscal.AnioAprobacion
        oTRPDatoFiscal.RazonSocial = oTransProd.ClienteActual.RazonSocial
        oTRPDatoFiscal.RFC = oTransProd.ClienteActual.IdFiscal
        oTRPDatoFiscal.TelefonoContacto = oTransProd.ClienteActual.TelefonoContacto
        If dtClienteDom.Rows.Count > 0 Then
            oTRPDatoFiscal.Calle = dtClienteDom.Rows(0)("Calle")
            oTRPDatoFiscal.NumExt = dtClienteDom.Rows(0)("Numero")
            oTRPDatoFiscal.NumInt = dtClienteDom.Rows(0)("NumInt")
            oTRPDatoFiscal.Colonia = dtClienteDom.Rows(0)("Colonia")
            oTRPDatoFiscal.Localidad = dtClienteDom.Rows(0)("Localidad")
            oTRPDatoFiscal.Municipio = dtClienteDom.Rows(0)("Poblacion")
            oTRPDatoFiscal.Entidad = dtClienteDom.Rows(0)("Entidad")
            oTRPDatoFiscal.Pais = dtClienteDom.Rows(0)("Pais")
            oTRPDatoFiscal.CodigoPostal = dtClienteDom.Rows(0)("CodigoPostal")
            oTRPDatoFiscal.ReferenciaDom = dtClienteDom.Rows(0)("ReferenciaDom")
        End If
        oTRPDatoFiscal.TelefonoEm = oTransProd.SubEmpresaActual.Telefono
        oTRPDatoFiscal.RFCEm = dtCentroExpedicionPadre.Rows(0)("RFC")
        oTRPDatoFiscal.NombreEm = dtCentroExpedicionPadre.Rows(0)("Nombre")
        oTRPDatoFiscal.CalleEm = dtCentroExpedicionPadre.Rows(0)("Calle")
        oTRPDatoFiscal.NumExtEm = dtCentroExpedicionPadre.Rows(0)("NumExt")
        oTRPDatoFiscal.NumIntEm = dtCentroExpedicionPadre.Rows(0)("NumInt")
        oTRPDatoFiscal.ColoniaEm = dtCentroExpedicionPadre.Rows(0)("Colonia")
        oTRPDatoFiscal.LocalidadEm = dtCentroExpedicionPadre.Rows(0)("Localidad")
        oTRPDatoFiscal.ReferenciaDomEm = dtCentroExpedicionPadre.Rows(0)("ReferenciaDom")
        oTRPDatoFiscal.MunicipioEm = dtCentroExpedicionPadre.Rows(0)("Municipio")
        oTRPDatoFiscal.RegionEm = dtCentroExpedicionPadre.Rows(0)("Entidad")
        oTRPDatoFiscal.PaisEm = dtCentroExpedicionPadre.Rows(0)("Pais")
        oTRPDatoFiscal.CodigoPostalEm = dtCentroExpedicionPadre.Rows(0)("CodigoPostal")
        oTRPDatoFiscal.CalleEx = dtCentroExpedicion.Rows(0)("Calle")
        oTRPDatoFiscal.NumExtEx = dtCentroExpedicion.Rows(0)("NumExt")
        oTRPDatoFiscal.NumIntEx = dtCentroExpedicion.Rows(0)("NumInt")
        oTRPDatoFiscal.ColoniaEx = dtCentroExpedicion.Rows(0)("Colonia")
        oTRPDatoFiscal.CodigoPostalEx = dtCentroExpedicion.Rows(0)("CodigoPostal")
        oTRPDatoFiscal.ReferenciaDomEx = dtCentroExpedicion.Rows(0)("ReferenciaDom")
        oTRPDatoFiscal.LocalidadEx = dtCentroExpedicion.Rows(0)("Localidad")
        oTRPDatoFiscal.MunicipioEx = dtCentroExpedicion.Rows(0)("Municipio")
        oTRPDatoFiscal.EntidadEx = dtCentroExpedicion.Rows(0)("Entidad")
        oTRPDatoFiscal.PaisEx = dtCentroExpedicion.Rows(0)("Pais")
        oTRPDatoFiscal.LugarExpedicion = IIf(dtCentroExpedicion.Rows(0)("Municipio").ToString = "", dtCentroExpedicionPadre.Rows(0)("Municipio").ToString & ", " & dtCentroExpedicionPadre.Rows(0)("Entidad").ToString, dtCentroExpedicion.Rows(0)("Municipio").ToString & ", " & dtCentroExpedicion.Rows(0)("Entidad").ToString)
        oTRPDatoFiscal.FormaDePago = "Pago en una sola exhibición"
        oTRPDatoFiscal.CerBase64 = oTransProd.SubEmpresaActual.CerBase64
        oTRPDatoFiscal.TipoNotaCredito = 0
        aTRPDatoFiscal.Add(oTransProdFactura.TransProdId, oTRPDatoFiscal)

        Dim dtRegimenFiscal As DataTable = oDBVen.RealizarConsultaSQL("select TipoRegimen from CEERegimenFiscal where CentroExpId = '" & dtCentroExpedicionPadre.Rows(0)("CentroExpID") & "'", "CEERegimenFiscal")
        For Each dr As DataRow In dtRegimenFiscal.Rows
            Dim oTRPRegimenFiscal As TRPRegimenFiscal = New TRPRegimenFiscal
            oTRPRegimenFiscal.TransProdID = oTRPDatoFiscal.TransProdID
            oTRPRegimenFiscal.RegimenFiscalID = oApp.KEYGEN(1)
            oTRPRegimenFiscal.Descripcion = ValorReferencia.BuscarEquivalente("TIPREG", dr("TipoRegimen"))
            oTRPDatoFiscal.TRPRegimenFiscal.Add(oTRPRegimenFiscal.Descripcion, oTRPRegimenFiscal)
        Next

        Dim strError As String
        FolioFiscal.ActualizarFolioFiscal(oTRPDatoFiscal.FolioID, oTRPDatoFiscal.FOSId, strError)

        dtCentroExpedicion.Dispose()
        dtCentroExpedicionPadre.Dispose()
        dtClienteDom.Dispose()

    End Sub

    Private Sub CrearNotaCredito(ByVal paroTransProdDev As TransProd)
        Dim sFacturaId As String = String.Empty
        Dim bFacturaVirtual As Boolean = False
        If Not IsDBNull(oTransProdGenerico.FacturaId) AndAlso oTransProdGenerico.FacturaId <> "" Then
            sFacturaId = oTransProdGenerico.FacturaId
        Else
            sFacturaId = CrearFacturaVirtual()
            bFacturaVirtual = True
        End If

        Dim dtDetalle As DataTable = oDBVen.RealizarConsultaSQL("Select * from transprodDetalle where TransProdID='" & paroTransProdDev.TransProdId & "'", "DetalleDev")

        If dtDetalle.Rows.Count <= 0 Then Exit Sub
        Dim FolioF As New FolioFiscal
        Dim LFolios As New System.Collections.Generic.List(Of FolioFiscal)
        Dim Mensajes As String = ""
        Dim oFolioFiscal As FolioFiscal
        oFolioFiscal = FolioF.ObtenerFolioFiscal(oTransProdGenerico.SubEmpresaActual.SubEmpresaId, 2, Mensajes)

        If Mensajes <> "" Then
            If Mensajes = "E0855" Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0855"))
            Else
                MsgBox(Mensajes)
            End If
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Exit Sub
        End If


        oTransProdNota = New TransProd()
        oTransProdNota.TransProdId = oApp.KEYGEN(1)
        oTransProdNota.VisitaActual = paroTransProdDev.VisitaActual
        oTransProdNota.FolioActual = oFolioFiscal.Formato
        oTransProdNota.Tipo = 10
        oTransProdNota.TipoFase = ServicesCentral.TiposFasesPedidos.Captura
        oTransProdNota.TipoPedido = ServicesCentral.TiposPedidos.NoDefinido
        oTransProdNota.TipoMovimiento = ServicesCentral.TiposMovimientos.NoDefinido
        oTransProdNota.FechaHoraAlta = Now
        Dim dSubtotal As Decimal = dtDetalle.Compute("sum(SubTotal)", "")
        oTransProdNota.SubTDetalle = dSubtotal
        oTransProdNota.SubTotal = dSubtotal
        oTransProdNota.Impuesto = paroTransProdDev.Impuesto
        oTransProdNota.Total = paroTransProdDev.Total
        oTransProdNota.Saldo = 0
        oTransProdNota.SubEmpresaActual = oTransProdGenerico.SubEmpresaActual
        oTransProdNota.MonedaID = oTransProdGenerico.MonedaID
        oTransProdNota.TipoCambio = oTransProdGenerico.TipoCambio
        oTransProdNota.FacturaId = sFacturaId
        oTransProdNota.CrearNotaCredito()


        Dim oTransProdDetalle As TransProdDetalle
        For Each dr As DataRow In dtDetalle.Rows
            oTransProdDetalle = New TransProdDetalle(oTransProdNota.TransProdId, dr("ProductoClave"), dr("Partida"))
            With oTransProdDetalle
                .TransProdDetalleID = dr("TransProdDetalleID")
                .CodigoSKU = dr("CodigoSKU")
                .TipoUnidad = dr("TipoUnidad")
                .Cantidad = dr("Cantidad")
                .Cantidad1 = dr("Cantidad1")
                .Factor = dr("Factor")
                .Factor1 = dr("Factor1")
                .Precio = dr("Precio")
                .SubTotal = dr("SubTotal")
                .Impuesto = dr("Impuesto")
                .Total = dr("Total")
                oTransProdDetalle.CrearDetalleNotaCredito()
            End With
        Next

        dtDetalle.Dispose()

        'Insertar los impuestos
        oDBVen.EjecutarComandoSQL("Insert into TPDImpuesto Select '" & oTransProdNota.TransProdId & "', TransProdDetalleId, TPDImpuestoID, ImpuestoClave, ImpuestoPor, ImpuestoImp, ImpuestoPU,ImpDesGlb, getdate() as MFechaHora,'" & oVendedor.UsuarioId & "', 0 as Enviado from TPDImpuesto where TransProdID='" & paroTransProdDev.TransProdId & "'")

        Dim dtCentroExpedicion As DataTable = oDBVen.RealizarConsultaSQL("select ce.* from centroexpedicion ce inner join foliofiscal ff on ff.centroexpid=ce.centroexpid where ff.folioid = '" & oFolioFiscal.FolioID & "' and ff.fosid='" & oFolioFiscal.FosID & "' and ce.SubEmpresaID='" & oTransProdNota.SubEmpresaActual.SubEmpresaId & "' ", "CentroExpedicion")
        Dim dtCentroExpedicionPadre As DataTable
        If dtCentroExpedicion.Rows(0)("Tipo") = 1 Then
            dtCentroExpedicionPadre = oDBVen.RealizarConsultaSQL("select * from centroexpedicion where centroexpid='" & dtCentroExpedicion.Rows(0)("CentroExpPadreID") & "' and tipo=0", "CentroExpedicion")
        Else
            dtCentroExpedicionPadre = dtCentroExpedicion.Copy
        End If

        Dim iTipoVersion As Integer = CType(SubEmpresa.aSubEmpresa(0), SubEmpresa.DatosEmpresa).VersionCFD
        Dim sVersionCFD As String = ValorReferencia.BuscarEquivalente("VERFACTE", iTipoVersion)

        Dim oTRPDatoFiscal As New TRPDatoFiscal
        With oTRPDatoFiscal
            .TransProdID = oTransProdNota.TransProdId
            .FolioID = oFolioFiscal.FolioID
            .FOSId = oFolioFiscal.FosID
            .NumCertificado = oFolioFiscal.NumCertificado
            .Serie = oFolioFiscal.Serie
            .Aprobacion = oFolioFiscal.Aprobacion
            .AnioAprobacion = oFolioFiscal.AnioAprobacion
            .TipoVersion = sVersionCFD

            If bFacturaVirtual Then
                Dim dtClienteDom As DataTable = oDBVen.RealizarConsultaSQL("Select * from ClienteDomicilio Where tipo=1 and ClienteClave='" & oTransProdGenerico.ClienteActual.ClienteClave & "'", "Domiclio")
                .RazonSocial = oTransProdGenerico.ClienteActual.RazonSocial
                .RFC = oTransProdGenerico.ClienteActual.IdFiscal
                .TelefonoContacto = oTransProdGenerico.ClienteActual.TelefonoContacto
                If dtClienteDom.Rows.Count > 0 Then
                    .Calle = dtClienteDom.Rows(0)("Calle")
                    .NumExt = dtClienteDom.Rows(0)("Numero")
                    .NumInt = dtClienteDom.Rows(0)("NumInt")
                    .Colonia = dtClienteDom.Rows(0)("Colonia")
                    .Localidad = dtClienteDom.Rows(0)("Localidad")
                    .Municipio = dtClienteDom.Rows(0)("Poblacion")
                    .Entidad = dtClienteDom.Rows(0)("Entidad")
                    .Pais = dtClienteDom.Rows(0)("Pais")
                    .CodigoPostal = dtClienteDom.Rows(0)("CodigoPostal")
                    .ReferenciaDom = dtClienteDom.Rows(0)("ReferenciaDom")
                End If
            Else
                Dim dtTRPDatoFiscal As DataTable = oDBVen.RealizarConsultaSQL("Select * from TRPDatoFiscal where TransProdID='" & oTransProdNota.FacturaId & "'", "TRPDatoFiscal")

                If dtTRPDatoFiscal.Rows.Count > 0 Then
                    .RazonSocial = dtTRPDatoFiscal.Rows(0)("RazonSocial").ToString
                    .RFC = dtTRPDatoFiscal.Rows(0)("RFC").ToString
                    .TelefonoContacto = dtTRPDatoFiscal.Rows(0)("TelefonoContacto").ToString
                    .Calle = dtTRPDatoFiscal.Rows(0)("Calle").ToString
                    .NumExt = dtTRPDatoFiscal.Rows(0)("NumExt").ToString
                    .NumInt = dtTRPDatoFiscal.Rows(0)("NumInt").ToString
                    .Colonia = dtTRPDatoFiscal.Rows(0)("Colonia").ToString
                    .CodigoPostal = dtTRPDatoFiscal.Rows(0)("CodigoPostal").ToString
                    .ReferenciaDom = dtTRPDatoFiscal.Rows(0)("ReferenciaDom").ToString
                    .Localidad = dtTRPDatoFiscal.Rows(0)("Localidad").ToString
                    .Municipio = dtTRPDatoFiscal.Rows(0)("Municipio").ToString
                    .Entidad = dtTRPDatoFiscal.Rows(0)("Entidad").ToString
                    .Pais = dtTRPDatoFiscal.Rows(0)("Pais").ToString
                End If
            End If

            .TelefonoEm = oTransProdNota.SubEmpresaActual.Telefono
            .RFCEm = dtCentroExpedicionPadre.Rows(0)("RFC").ToString
            .NombreEm = dtCentroExpedicionPadre.Rows(0)("Nombre").ToString
            .CalleEm = dtCentroExpedicionPadre.Rows(0)("Calle")
            .NumExtEm = dtCentroExpedicionPadre.Rows(0)("NumExt")
            .NumIntEm = dtCentroExpedicionPadre.Rows(0)("NumInt")
            .ColoniaEm = dtCentroExpedicionPadre.Rows(0)("Colonia")
            .LocalidadEm = dtCentroExpedicionPadre.Rows(0)("Localidad")
            .ReferenciaDomEm = dtCentroExpedicionPadre.Rows(0)("ReferenciaDom")
            .MunicipioEm = dtCentroExpedicionPadre.Rows(0)("Municipio")
            .RegionEm = dtCentroExpedicionPadre.Rows(0)("Entidad")
            .PaisEm = dtCentroExpedicionPadre.Rows(0)("Pais")
            .CodigoPostalEm = dtCentroExpedicionPadre.Rows(0)("CodigoPostal")

            .CalleEx = dtCentroExpedicion.Rows(0)("Calle")
            .NumExtEx = dtCentroExpedicion.Rows(0)("NumExt")
            .NumIntEx = dtCentroExpedicion.Rows(0)("NumInt")
            .ColoniaEx = dtCentroExpedicion.Rows(0)("Colonia")
            .CodigoPostalEx = dtCentroExpedicion.Rows(0)("CodigoPostal")
            .ReferenciaDomEx = dtCentroExpedicion.Rows(0)("ReferenciaDom")
            .LocalidadEx = dtCentroExpedicion.Rows(0)("Localidad")
            .MunicipioEx = dtCentroExpedicion.Rows(0)("Municipio")
            .EntidadEx = dtCentroExpedicion.Rows(0)("Entidad")
            .PaisEx = dtCentroExpedicion.Rows(0)("Pais")
            .TipoNotaCredito = 2
            .LugarExpedicion = IIf(dtCentroExpedicion.Rows(0)("Municipio").ToString = "", dtCentroExpedicionPadre.Rows(0)("Municipio").ToString & ", " & dtCentroExpedicionPadre.Rows(0)("Entidad").ToString, dtCentroExpedicion.Rows(0)("Municipio").ToString & ", " & dtCentroExpedicion.Rows(0)("Entidad").ToString)
            .FormaDePago = "Pago en una sola exhibición"
            .CerBase64 = oTransProdNota.SubEmpresaActual.CerBase64

            Dim dtRegimenFiscal As DataTable
            If bFacturaVirtual Then
                dtRegimenFiscal = oDBVen.RealizarConsultaSQL("select TipoRegimen as Descripcion from CEERegimenFiscal where CentroExpId = '" & dtCentroExpedicionPadre.Rows(0)("CentroExpID") & "'", "CEERegimenFiscal")
            Else
                dtRegimenFiscal = oDBVen.RealizarConsultaSQL("select Descripcion from TRPRegimenFiscal where TransProdID = '" & oTransProdNota.FacturaId & "'", "TRPRegimenFiscal")
            End If
            For Each dr As DataRow In dtRegimenFiscal.Rows
                Dim oTRPRegimenFiscal As TRPRegimenFiscal = New TRPRegimenFiscal
                oTRPRegimenFiscal.TransProdID = oTRPDatoFiscal.TransProdID
                oTRPRegimenFiscal.RegimenFiscalID = oApp.KEYGEN(1)
                oTRPRegimenFiscal.Descripcion = dr("Descripcion")
                .TRPRegimenFiscal.Add(oTRPRegimenFiscal.Descripcion, oTRPRegimenFiscal)
            Next

            Dim aGrupo As New ArrayList
            aGrupo.Add("NI")
            Dim aValor As ArrayList = ValorReferencia.RecuperaVARVGrupo("PAGO", aGrupo)
            If aValor.Count > 0 Then
                nTipoNoIdent = CType(aValor(0), ValorReferencia.Descripcion).Id
            End If

            .MetodoPago = ValorReferencia.BuscarEquivalente("PAGO", nTipoNoIdent)
            .MetodoPagoFinal = .MetodoPago


            Dim sCadenaOriginal As String = .CrearCadenaOriginalM(oTransProdNota, oTransProdNota.TransProdId, oTransProdGenerico.ClienteActual.ClienteClave, False)
            sCadenaOriginal = sCadenaOriginal.Replace("&", amp)
            sCadenaOriginal = sCadenaOriginal.Replace("<", lt)
            sCadenaOriginal = sCadenaOriginal.Replace(">", gt)
            sCadenaOriginal = sCadenaOriginal.Replace("'", apos)
            sCadenaOriginal = sCadenaOriginal.Replace("""", quot)
            .CadenaOriginal = sCadenaOriginal
            .Insertar()

            Dim strError As String
            FolioFiscal.ActualizarFolioFiscal(.FolioID, .FOSId, strError)
        End With
    End Sub

    Private Sub LlenarClienteDomicilio(ByVal ClienteClave As String)
        refaVista.CrearDetailView(DetailViewDatosFiscales, "DetailViewDomicilio")
        refaVista.PoblarDetailView(DetailViewDatosFiscales, oDBVen, "DetailViewDomicilio", "WHERE Cliente.ClienteClave='" & ClienteClave & "'")
    End Sub
    Private Sub HabilitarBotones(ByVal bHabilitar As Boolean)
        Me.ButtonDetalleContinuar.Enabled = bHabilitar
        Me.ButtonDetalleRegresar.Enabled = bHabilitar
        Me.ButtonImpuestos.Enabled = bHabilitar
        ' Me.btnContinuarFacturas.Enabled = bHabilitar
    End Sub

    Private Sub TextBoxProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxProducto.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                e.Handled = True
                'Se quitan los espacios porque generaba problemas al no encontrar el producto
                Me.TextBoxProducto.Text = Me.TextBoxProducto.Text.Trim()

                If TextBoxProducto.Text = "" Then
                    Me.ModificarMovimientoDet(0, "")
                Else
                    Dim iTipoClave, iEspacios As Integer
                    iTipoClave = oConHist.Campos("TipoClaveProducto")
                    iEspacios = oConHist.Campos("DigitoClaveProd")
                    'If MobileClient.Producto.VerificarTipoClaveProducto(iTipoClave, iEspacios) Then
                    If iTipoClave = 2 And Not CheckBoxProducto.Checked Then
                        Dim sProdClave As String = Me.TextBoxProducto.Text
                        If sProdClave.Length < iEspacios Then
                            sProdClave = sProdClave.PadLeft(iEspacios, "0")
                            Me.TextBoxProducto.Text = sProdClave
                        End If
                    End If
                    'End If
                    If Me.Producto.Buscar(Me.TextBoxProducto.Text, CheckBoxProducto.Checked) Then

                        If SKUInventario.ExistenciaDisponible(Producto.ProductoClave) = True Then
                            Me.ModificarMovimientoDet(0, Me.Producto.ProductoClave)
                        Else
                            MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0741"), MsgBoxStyle.Exclamation)
                            Me.TextBoxProducto.SelectionStart = 0
                            Me.TextBoxProducto.SelectionLength = Len(Me.TextBoxCodigo.Text)
                            Me.TextBoxProducto.Focus()
                        End If

                    Else

                        MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0005"), MsgBoxStyle.Exclamation)
                        Me.TextBoxProducto.SelectionStart = 0
                        Me.TextBoxProducto.SelectionLength = Len(Me.TextBoxProducto.Text)
                        Me.TextBoxProducto.Focus()

                    End If
                End If
            Case Microsoft.VisualBasic.ChrW(Keys.Escape)
                e.Handled = True
                Me.SalirPlantillaCaptura()
        End Select
        bHuboCambios = True
    End Sub

    Private Function PedirProductoCantidad(ByVal pariPartida As Integer, Optional ByVal optparsProductoClave As String = "", Optional ByVal parsTransProdID As String = "") As Boolean
        Try

            ' Cargar la forma para pedir el producto, cantidad y unidad
            Dim oFormPedirProducto As New FormPedirProducto

            With oFormPedirProducto
                .TransProdId = parsTransProdID
                If parsTransProdID = "" Then
                    .TransProdIds = RegresaTransProdActual()
                End If
                '.FolioActual = Me.TransProd.FolioActual
                .ClienteActual = oTransProdGenerico.ClienteActual
                .VisitaActual = oTransProdGenerico.VisitaActual
                .ListasPrecios = oTransProdGenerico.ListasPrecios
                .TipoTransProd = oTransProdGenerico.Tipo
                .TipoMovimiento = oTransProdGenerico.TipoMovimiento
                .ModuloMovDetalle = oTransProdGenerico.ModuloMovDetalle
                .TipoIndice = oVendedor.TipoModulo
                .Partida = pariPartida
                .Impuestos = Me.Impuesto
                Me.Producto.ProductoClave = optparsProductoClave

                .Producto = Me.Producto
                If optparsProductoClave <> "" Then
                    .PermitirConsultarProductos = False
                    '.PermitirCambiarProducto = False
                End If


                If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta OrElse (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Preventa AndAlso oAgenda.RutaActual.Inventario) Then
                    .MostrarExistencia = True
                    If (oTransProdGenerico.Tipo = ServicesCentral.TiposTransProd.MovSinInvEV) Then
                        .MostrarExistencia = False
                    End If
                    .TipoMovimiento = ServicesCentral.TiposMovimientos.Salida
                ElseIf oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                    .MostrarExistencia = True
                End If
                '*******************************

                AddHandler .PoblarListaProductos, AddressOf PoblarProductosPedido
                AddHandler .CrearGridProductos, AddressOf ConfiguraGridfgProductos

                'AddHandler .PoblarProductosEquivalentes, AddressOf PoblarGridProductosEquivalentes

                Select Case oTransProdGenerico.Tipo
                    Case ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposTransProd.MovSinInvEV
                        '.NombreListViewProductos = "ListViewPedidos"
                        AddHandler .GuardarDetalle, AddressOf GuardarDetallePedido
                        AddHandler .GuardarSKU, AddressOf GuardarSKU
                End Select
            End With
            oFormPedirProducto.fParent = Me
            If oFormPedirProducto.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.TextBoxProducto.Focus()
            End If
            Me.TextBoxProducto.Text = ""
            Me.TextBoxCodigo.Text = ""
            Me.TextBoxProducto.Focus()
            With oFormPedirProducto
                oFormPedirProducto.fParent = Nothing
                RemoveHandler .GuardarDetalle, AddressOf GuardarDetallePedido
                RemoveHandler .PoblarListaProductos, AddressOf PoblarProductosPedido
                RemoveHandler .CrearGridProductos, AddressOf ConfiguraGridfgProductos
                RemoveHandler .GuardarSKU, AddressOf GuardarSKU
                'RemoveHandler .PoblarProductosEquivalentes, AddressOf PoblarGridProductosEquivalentes
                .Dispose()
                oFormPedirProducto = Nothing
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        Return True
    End Function

    Private Sub PoblarProductosPedido(ByRef refparoFormPedirProducto As FormPedirProducto, ByVal aListaEsquemas As ArrayList)
        With refparoFormPedirProducto
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            .fgProductos.Redraw = False
            .fgProductos.AutoResize = False

            Dim dtProductos As DataTable
            dtProductos = oDBVen.RealizarConsultaSQL("Select PRO.ProductoClave, PRO.Nombre from SKUInventario SKI inner join Producto PRO on PRO.ProductoClave = SKI.ProductoClave where Round((Disponible - Apartado),2) >0 and Round((Cantidad - Apartado1),2) >0 " & .FiltroProductosIncluyeTabla & " group by PRO.ProductoClave, PRO.Nombre", "ProductosDisponibles")
            .fgProductos.DataSource = dtProductos
            ConfiguraGridfgProductos(.fgProductos)
            .fgProductos.Redraw = True
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End With
    End Sub


    Private Sub ConfiguraGridfgProductos(ByRef refparFlexGrid As C1.Win.C1FlexGrid.C1FlexGrid)
        With refparFlexGrid
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor
            .Cols.Fixed = 0
            .Cols.Count = 2
            .Cols(0).Caption = refaVista.BuscarMensaje("MsgBox", "ProductoClave")
            .Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "Nombre")
            .Cols(0).Width = 100
            .Cols(1).Width = 280
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
        End With
    End Sub

    Private Sub ConfiguraGridfgFondoCristal()
        With fgFondoCristal
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 8
            .AllowEditing = True
            .Cols(0).Caption = refaVista.BuscarMensaje("MsgBox", "ProductoClave")
            .Cols(0).Width = 70
            .Cols(0).AllowEditing = False
            .Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "Nombre")
            .Cols(1).Width = 115
            .Cols(1).AllowEditing = True
            .Cols(2).Caption = refaVista.BuscarMensaje("MsgBox", "Precio")
            .Cols(2).Name = "Precio"
            .Cols(2).Width = 60
            .Cols(2).AllowEditing = False
            .Cols(3).Caption = refaVista.BuscarMensaje("MsgBox", "Total")
            .Cols(3).Name = "Total"
            .Cols(3).Width = 60
            .Cols(3).AllowEditing = False
            .Cols(4).Name = "CantidadMaxima"
            .Cols(4).Visible = False
            .Cols(5).Name = "TransProdDetalleID"
            .Cols(5).Visible = False
            .Cols(6).Name = "TipoUnidad"
            .Cols(6).Visible = False
            .Cols(7).Name = "TotalAnt"
            .Cols(7).Visible = False
            .Rows.Count = 1
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            ' initialize outline tree
            .Tree.Column = 0
            .Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf
            .AutoResize = True
            .Redraw = True
        End With
    End Sub

    Private Sub GuardarDetallePedido(ByRef refparoFormPedirProducto As FormPedirProducto)
        Try
            Dim parsTransProdID As String = String.Empty
            Dim iPartida As Integer = 0
            If Not Folio.ObtenerTransProdPartida(refparoFormPedirProducto.TransProdId, refparoFormPedirProducto.Producto.ProductoClave, iPartida) Then
                Exit Try
            End If

            If refparoFormPedirProducto.TransProdId <> "" Then
                BorrarMovimientoSKU(TipoBorrado.ProductoUnidad, "", refparoFormPedirProducto.Producto.ProductoClave, refparoFormPedirProducto.TransProdId)
                For Each refProducto As FormPedirProducto.ItemUnidad In refparoFormPedirProducto.PanelUnidades.Controls
                    With refProducto
                        If IsNumeric(.NumericCantidad.DecimalValue) Then
                            .TransProdDetalleID = ""
                        End If
                    End With
                Next
                parsTransProdID = refparoFormPedirProducto.TransProdId
            End If


            ' Actualizar el detalle
            For Each refProducto As FormPedirProducto.ItemUnidad In refparoFormPedirProducto.PanelUnidades.Controls
                With refProducto
                    If IsNumeric(.NumericCantidad.DecimalValue) AndAlso .NumericCantidad.DecimalValue > 0 Then
                        If TransProdDetalle.CrearDetallePedido(oTransProdGenerico, parsTransProdID, iPartida, "", refparoFormPedirProducto.Producto.ProductoClave, .NumericCantidad.DecimalValue, .NumericCantidad1.DecimalValue, .TipoUnidad, 1, Me.Impuesto, Me.bSurtir, Me.bEsNuevo, 0, aTransProd) = 1 Then
                            MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0779").Replace("$0$", refparoFormPedirProducto.Producto.ProductoClave), MsgBoxStyle.Exclamation)
                        End If
                    End If
                End With
            Next
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "GuardarDetallePedido")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "GuardarDetallePedido")
        End Try
    End Sub
    Public Function validarInventarioPedidoReparto(ByRef p As FormPedirProducto) As Boolean
        Return True
    End Function
    Public Function GuardarDetallePedidoReparto(ByRef p As FormPedirProducto) As Boolean
        Return True
    End Function

#End Region

#Region " Movimientos "

    Private Sub PoblarMovimientos()
        bEnProceso = True
        PoblarGridMovimientos()

        Dim totalParcial As DataTable = oDBVen.RealizarConsultaSQL("SELECT MON.Nombre, MON.Simbolo, sum(TPD.total) AS Total FROM TransProdDetalle TPD inner join TransProd TRP on TRP.TransProdID =  TPD.TransProdID inner join Moneda MON on TRP.MonedaID = MON.MonedaID WHERE TPD.TransProdId in(" & RegresaTransProdActual() & ") GROUP BY MON.Nombre, MON.Simbolo", "Total")
        'Dim sTotal As Object = 0
        'If totalParcial.Rows.Count = 1 Then
        '    sTotal = totalParcial.Rows(0)(0)
        'End If    
        DetailViewPie.Items.Clear()
        For Each dr As DataRow In totalParcial.Rows
            Dim oitem As New Resco.Controls.DetailView.Item
            oitem.Label = refaVista.BuscarMensaje("MsgBox", "TRPTotal") & " " & dr("Nombre")
            oitem.LabelAlignment = HorizontalAlignment.Left
            oitem.LabelWidth = 120
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            oitem.LabelWidth = 240
            oitem.Height = 32
#End If
            oitem.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
            oitem.LabelForeColor = Drawing.Color.White
            oitem.TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
            oitem.TextForeColor = Drawing.Color.White
            oitem.TextAlign = HorizontalAlignment.Right
            oitem.Text = dr("Simbolo") & Format(dr("Total"), "#,##0.00")
            DetailViewPie.Items.Add(oitem)
        Next
        'LabelTotalPreviol.Text = refaVista.BuscarMensaje("ProcesandoRotulos", "TotalPrevio")
        'If (IsNothing(sTotal) OrElse IsDBNull(sTotal)) Then
        '    sTotal = 0
        'End If
        'LabelTotalPreviof.Text = Format(sTotal, oApp.FormatoDinero)
        'LabelTotalProductosl.Text = refaVista.BuscarMensaje("ProcesandoRotulos", "NombreProductos")
        'LabelTotalProductosf.Text = ObtenerNumeroPartidas()
        If Not bSurtir Then
            If aTransProd.Count > 0 Then
                For Each oTrp As TransProd In aTransProd.Values
                    Me.ObtenerTotalesDetalle(oTrp)
                Next
            Else
                Me.ObtenerTotalesDetalle(oTransProdGenerico)
            End If
        End If
        bEnProceso = False
        bHuboCambios = True
    End Sub

    Private Sub AgregarMovimiento()
        If Me.PedirProductoCantidad(0) Then
            PoblarMovimientos()
        End If
    End Sub

    Private Function BorrarMovimientoSKU(ByVal parTipoBorrado As TipoBorrado, ByVal parsCodigoSKU As String, ByVal parsProductoClave As String, ByVal parsTransProdId As String) As Boolean
        Try
            bHuboCambios = True
            ' Obtener los TransProdDetalleID del numero de partida que se va a borrar
            Dim DataTableIDs As DataTable
            Select Case parTipoBorrado
                Case TipoBorrado.SKU
                    DataTableIDs = oDBVen.RealizarConsultaSQL("SELECT TransProdDetalleID,ProductoClave,TipoUnidad,Cantidad,Cantidad1,case isnull(PrestamoVendido) when 1 then 0 else PrestamoVendido end as PrestamoVendido, CodigoSKU FROM TransProdDetalle WHERE TransProdId='" & parsTransProdId & "' AND CodigoSKU = '" & parsCodigoSKU & "'", "IDs")
                Case TipoBorrado.ProductoClave
                    DataTableIDs = oDBVen.RealizarConsultaSQL("SELECT TransProdDetalleID,ProductoClave,TipoUnidad,Cantidad,Cantidad1,case isnull(PrestamoVendido) when 1 then 0 else PrestamoVendido end as PrestamoVendido, CodigoSKU FROM TransProdDetalle WHERE TransProdId='" & parsTransProdId & "' and PRoductoClave ='" & parsProductoClave & "'", "IDs")
                Case TipoBorrado.ProductoUnidad
                    DataTableIDs = oDBVen.RealizarConsultaSQL("SELECT TransProdDetalleID,ProductoClave,TipoUnidad,Cantidad,Cantidad1,case isnull(PrestamoVendido) when 1 then 0 else PrestamoVendido end as PrestamoVendido, CodigoSKU FROM TransProdDetalle WHERE TransProdId='" & parsTransProdId & "' and PRoductoClave ='" & parsProductoClave & "' and codigosku ='' ", "IDs")
            End Select

            If DataTableIDs.Rows.Count > 0 Then
                Dim sIds As New System.Text.StringBuilder

                For Each refDataRow As DataRow In DataTableIDs.Rows

                    Cuotas.VerificarCuotas(oVendedor.VendedorId, oTransProdGenerico.ClienteActual.ClienteClave, refDataRow("ProductoClave"), -1 * CDec(refDataRow("Cantidad")), 1)
                    If sIds.ToString <> "" Then
                        sIds.Append(",")
                    End If
                    sIds.Append("'" & refDataRow("TransProdDetalleID") & "'")

                    If (oTransProdGenerico.Tipo <> ServicesCentral.TiposTransProd.MovSinInvEV) Then
                        SKUInventario.ActualizarSKU(SKUInventario.SKUMovimiento.Incrementar, refDataRow("CodigoSKU"), refDataRow("ProductoClave"), refDataRow("TipoUnidad"), refDataRow("Cantidad"), refDataRow("Cantidad1"))
                    End If

                Next

                oDBVen.EjecutarComandoSQL("DELETE FROM TPDImpuesto WHERE TransProdId='" & parsTransProdId & "' AND TransProdDetalleID IN (" & sIds.ToString & ")")
                oDBVen.EjecutarComandoSQL("DELETE FROM TRPPRP WHERE TransProdId='" & parsTransProdId & "' AND TransProdDetalleID IN (" & sIds.ToString & ")")
                oDBVen.EjecutarComandoSQL("DELETE FROM TPDDes WHERE TransProdId='" & parsTransProdId & "' AND TransProdDetalleID IN (" & sIds.ToString & ")")
                oDBVen.EjecutarComandoSQL("DELETE FROM TPDDesVendedor WHERE TransProdId='" & parsTransProdId & "' AND TransProdDetalleID IN (" & sIds.ToString & ")")
                Return oDBVen.EjecutarComandoSQL("DELETE FROM TransProdDetalle WHERE TransProdId='" & parsTransProdId & "' AND TransProdDetalleID IN (" & sIds.ToString & ")")

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "BorrarMovimiento")
        End Try
        Return False
    End Function


    Private Function BorrarBonificacion(ByVal parsTransProdDetalleID As String) As Boolean
        Try
            bHuboCambios = True
            If Not IsNothing(Me.TransProdDevolucion) AndAlso Me.TransProdDevolucion.TransProdId <> "" Then
                Me.TransProdDevolucion.Total = Math.Round(Me.TransProdDevolucion.Total - oDBVen.EjecutarCmdScalardblSQL("Select abs(Total) from TransProdDetalle WHERE TransProdId='" & Me.TransProdDevolucion.TransProdId & "' AND TransProdDetalleID ='" & parsTransProdDetalleID & "'"), 2)
                oDBVen.EjecutarComandoSQL("DELETE FROM TransProdDetalle WHERE TransProdId='" & Me.TransProdDevolucion.TransProdId & "' AND TransProdDetalleID ='" & parsTransProdDetalleID & "'")
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "BorrarMovimiento")
        End Try
        Return False
    End Function
    'TODO: Mandarle el transprodID en la modificacion
    Private Sub ModificarMovimientoDet(ByVal pariPartida As Integer, Optional ByVal parsProductoClave As String = "", Optional ByVal parsTransProdID As String = "")
        If Me.PedirProductoCantidad(pariPartida, parsProductoClave, parsTransProdID) Then
            PoblarMovimientos()
        End If
    End Sub

    Private Function ObtenerNumeroMovimientos(ByVal parsTransProdID As String) As Short
        Dim iNumMovs As Short = 0
        Try
            Dim DataTablePartidas As DataTable
            DataTablePartidas = oDBVen.RealizarConsultaSQL("SELECT COUNT(TransProdDetalleID) AS ""TotalPartidas"" FROM TransProdDetalle WHERE TransProdId='" & parsTransProdID & "'", "Partidas")
            If DataTablePartidas.Rows.Count = 1 Then
                Dim refDataRow As DataRow = DataTablePartidas.Rows(0)
                ' Indicar que se ha obtenido el folio, reducir el número de disponibles
                iNumMovs = refDataRow("TotalPartidas")
            End If
            DataTablePartidas.Dispose()
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "ObtenerNumeroMovimientos")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "ObtenerNumeroMovimientos")
        End Try
        Return iNumMovs
    End Function

    Private Function ObtenerNumeroPartidas() As Short
        Dim iNumMovs As Short = 0
        Try
            Dim DataTablePartidas As DataTable
            DataTablePartidas = oDBVen.RealizarConsultaSQL("SELECT distinct ProductoClave FROM TransProdDetalle WHERE TransProdId in(" & RegresaTransProdActual() & ")", "Partidas")
            If DataTablePartidas.Rows.Count > 0 Then
                ' Indicar que se ha obtenido el folio, reducir el número de disponibles
                iNumMovs = DataTablePartidas.Rows.Count
            End If
            DataTablePartidas.Dispose()
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "ObtenerNumeroMovimientos")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "ObtenerNumeroMovimientos")
        End Try
        Return iNumMovs
    End Function

#End Region

#End Region

#Region " TabPage Totales "

    Private Sub ButtonDetalleRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDetalleRegresar.Click
        Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageMovimientos
        Me.TabControlMovProducto.Refresh()
    End Sub

    Public Function ObtenerTotalesDetalle(ByRef oTRP As TransProd) As Boolean
        Try
            oTRP.SubTDetalle = 0
            oTRP.Impuesto = 0
            oTRP.Total = 0

            Dim DataTableTotales As DataTable
            DataTableTotales = oDBVen.RealizarConsultaSQL("SELECT SUM(SubTotal) AS ""SubTDetalle"", SUM(Impuesto) AS ""Impuesto"", SUM(Total) AS ""Total"" FROM TransProdDetalle WHERE TransProdId='" & oTRP.TransProdId & "'", "Totales")
            If DataTableTotales.Rows.Count = 1 Then
                Dim refDataRow As DataRow = DataTableTotales.Rows(0)
                If Not refDataRow.IsNull("SubTDetalle") Then
                    oTRP.SubTDetalle = refDataRow("SubTDetalle")
                End If
                If Not refDataRow.IsNull("Impuesto") Then
                    oTRP.Impuesto = refDataRow("Impuesto")
                End If
                If Not refDataRow.IsNull("Total") Then
                    oTRP.Total = refDataRow("Total")
                End If
                'Me.LabelTotal.Text = Format(Me.TransProd.Total, oApp.FormatoDinero)
                DataTableTotales.Dispose()
                Return True
            End If
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "ObtenerTotalMovto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "ObtenerTotalMovto")
        End Try
        Return False
    End Function

    Private Sub DetailViewGranTotal_ItemChanged(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ItemEventArgs) Handles DetailViewGranTotal.ItemChanged
        Try
            bHuboCambios = True
            'Select Case e.item.GetType.ToString()
            'Case GetType(Resco.Controls.DetailView.ItemNumeric).ToString
            If bIniciando Then Exit Sub
            Select Case e.item.Name
                'Case "FormaPago"
                '    HabilitarMoneda()
                'If Not refPago.SelectedItem Is Nothing Then
                '        Dim oDRV As ValorReferencia.Descripcion = refCombo.SelectedItem
                '        Dim iTmp As Integer = CInt(oDRV.Id)
                '        If iTmp = 1 Then
                '            Me.DetailViewTotales.Items("DiasCredito").Visible = False
                '            Me.DetailViewTotales.Items("FechaCobranza").Visible = False
                '        Else
                '            Me.DetailViewTotales.Items("DiasCredito").Visible = True
                '            Me.DetailViewTotales.Items("FechaCobranza").Visible = True
                '        End If
                'End If
                'Case "FormaVenta"
                '    Dim refCombo As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewTotales.Items("FormaVenta")
                '    If Not refCombo.SelectedItem Is Nothing Then
                '        Dim oDRV As ValorReferencia.Descripcion = refCombo.SelectedItem
                '        Dim iTmp As Integer = CInt(oDRV.Id)
                '        If iTmp = 1 Then
                '            Me.DetailViewTotales.Items("DiasCredito").Visible = False
                '            Me.DetailViewTotales.Items("DiasCredito").Value = 0
                '            Me.DetailViewTotales.Items("FechaCobranza").Visible = False
                '        Else
                '            Dim cliVenta As System.Collections.Generic.Dictionary(Of String, Object) = oDBVen.RealizarReaderSQLconCampos("SELECT * FROM cliformaventa WHERE clienteclave = '" & oTransProd.ClienteActual.ClienteClave & "' AND CFVtipo = '" & iTmp.ToString() & "'")
                '            Me.DetailViewTotales.Items("DiasCredito").Visible = True
                '            Me.DetailViewTotales.Items("FechaCobranza").Visible = True
                '            Me.DetailViewTotales.Items("DiasCredito").Value = cliVenta("DiasCredito")
                '            If Not IsDBNull(Convert.ToInt32(cliVenta("CapturaDias"))) And Convert.ToInt32(cliVenta("CapturaDias")) = 1 Then
                '                Me.DetailViewTotales.Items("DiasCredito").Enabled = True
                '                Me.DetailViewTotales.Items("FechaCobranza").Enabled = True
                '            Else
                '                Me.DetailViewTotales.Items("DiasCredito").Enabled = False
                '                Me.DetailViewTotales.Items("FechaCobranza").Enabled = False
                '            End If
                '        End If
                '    End If
                '    HabilitarMoneda()
                'Case "TipoPedido"
                '    Dim refComboBox As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewTotales.Items("TipoPedido")
                '    If Not refComboBox.SelectedItem Is Nothing Then
                '        If refComboBox.SelectedIndex >= 0 Then
                '            Dim tTipoPedido As ServicesCentral.TiposPedidos = refComboBox.SelectedIndex
                '            VerificarFechaEntrega(tTipoPedido)
                '        End If
                '    End If
                'Case "DescuentoVendedor"
                '    If blnEditandoDescuento Then Exit Sub
                '    If e.item.Value < 0 Then
                '        e.item.Value = 0
                '    ElseIf e.item.Value > 100 Then
                '        e.item.Value = 100
                '    Else
                '        Try
                '            blnEditandoDescuento = True
                '            Dim refNumeric As Resco.Controls.DetailView.ItemNumeric = e.item
                '            Me.TransProd.DescVendPor = refNumeric.NumericValue
                '            If Not bSurtir Then
                '                Me.TransProd.RecalcularTotales()
                '            End If
                '            Dim refNumericDescuento As Resco.Controls.DetailView.ItemNumeric = Me.DetailViewTotales.Items("DescuentoVendedorImp")
                '            refNumericDescuento.Value = RedondeoAritmetico(Me.TransProd.DescuentoVendedor, 2)
                '            Dim refTextBox As Resco.Controls.DetailView.ItemTextBox
                '            refTextBox = Me.DetailViewTotales.Items("Total")
                '            refTextBox.Text = Format(Me.TransProd.Total, oApp.FormatoDinero)
                '            refTextBox = Me.DetailViewTotales.Items("Impuesto")
                '            refTextBox.Text = Format(IIf((Me.TransProd.Impuesto - Me.TransProd.DescuentoImpuestoCliente - Me.TransProd.DescuentoImpuestoVendedor) < 0, 0, Me.TransProd.Impuesto - Me.TransProd.DescuentoImpuestoCliente - Me.TransProd.DescuentoImpuestoVendedor), oApp.FormatoDinero)
                '            refTextBox = Me.DetailViewTotales.Items("SubTotal")
                '            refTextBox.Text = Format(Me.TransProd.SubTotal, oApp.FormatoDinero)
                '        Catch ex As Exception
                '            MsgBox(ex.Message)
                '        End Try
                '        blnEditandoDescuento = False
                '    End If
                'Case "DescuentoVendedorImp"
                '    If blnEditandoDescuento Then Exit Sub
                '    If e.item.Value < 0 Then
                '        e.item.Value = 0
                '    ElseIf e.item.Value > 0 Then
                '        Try
                '            blnEditandoDescuento = True
                '            Dim refNumeric As Resco.Controls.DetailView.ItemNumeric = e.item
                '            Me.TransProd.DescVendPor = ((refNumeric.NumericValue) * 100) / (Me.TransProd.SubTDetalle - Me.TransProd.DescuentoImp)
                '            If Not bSurtir Then
                '                Me.TransProd.RecalcularTotales()
                '            End If

                '            Dim refNumericDescuento As Resco.Controls.DetailView.ItemNumeric = Me.DetailViewTotales.Items("DescuentoVendedor")
                '            refNumericDescuento.Value = RedondeoAritmetico(Me.TransProd.DescVendPor, 4)
                '            Dim refTextBox As Resco.Controls.DetailView.ItemTextBox
                '            refTextBox = Me.DetailViewTotales.Items("Total")
                '            refTextBox.Text = Format(Me.TransProd.Total, oApp.FormatoDinero)
                '            refTextBox = Me.DetailViewTotales.Items("Impuesto")
                '            refTextBox.Text = Format(IIf((Me.TransProd.Impuesto - Me.TransProd.DescuentoImpuestoCliente - Me.TransProd.DescuentoImpuestoVendedor) < 0, 0, Me.TransProd.Impuesto - Me.TransProd.DescuentoImpuestoCliente - Me.TransProd.DescuentoImpuestoVendedor), oApp.FormatoDinero)
                '            refTextBox = Me.DetailViewTotales.Items("SubTotal")
                '            refTextBox.Text = Format(Me.TransProd.SubTotal, oApp.FormatoDinero)
                '        Catch ex As Exception
                '            MsgBox(ex.Message)
                '        End Try
                '        blnEditandoDescuento = False
                '    End If
                'Case "DiasCredito"
                '    If Not _BModFeC Then
                '        Dim refCombo As Resco.Controls.DetailView.ItemDateTime = Me.DetailViewTotales.Items("FechaCobranza")
                '        _BModFeC = True
                '        refCombo.DateTime = Me.TransProd.FechaCaptura.AddDays(e.item.Value)
                '        _BModFeC = False
                '    End If
                'Case "FechaCobranza"
                '    If Not _BModFeC Then
                '        _BModFeC = True
                '        Dim refCombo As Resco.Controls.DetailView.ItemDateTime = Me.DetailViewTotales.Items("FechaCobranza")
                '        If (refCombo.DateTime.Date >= Convert.ToDateTime(Me.DetailViewTotales.Items("FechaEntrega").Value).Date) Then
                '            If (refCombo.DateTime.Date >= oDia.FechaCaptura.Date) Then
                '                Me.DetailViewTotales.Items("DiasCredito").Value = refCombo.DateTime.Date.Subtract(oDia.FechaCaptura.Date).Days
                '            Else
                '                If Not bSurtir Then
                '                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0388"), MsgBoxStyle.Information)
                '                    refCombo.DateTime = oDia.FechaCaptura
                '                End If
                '            End If
                '        Else
                '            If Not bSurtir Then
                '                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0254"), MsgBoxStyle.Information)
                '                refCombo.DateTime = oDia.FechaCaptura
                '            End If
                '        End If
                '        'Me.TransProd.FechaCobranza = refCombo.DateTime
                '        _BModFeC = False
                '    End If
                Case "Notas"
                    If Not e.item.Value Is Nothing Then
                        sNota = e.item.Value
                    End If

            End Select
            'End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub DetailViewTotales_ItemGotFocus(ByVal sender As Object, ByVal e As Resco.Controls.DetailView.ItemEventArgs)
    '    Try
    '        If e.item.GetType.Name <> "ItemTextBox" And e.item.GetType.Name <> "ItemDateTime" Then
    '            Me.DetailViewTotalesMachote.Focus()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub DetailViewTotales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    Try
    '        If e.Shift And e.KeyCode = Keys.Space Then
    '            e.Handled = True
    '            If IsNothing(Me.DetailViewTotalesMachote.SelectedItem) Then
    '                Exit Sub
    '            End If
    '            Dim i As Integer = Me.DetailViewTotalesMachote.SelectedItem.Index
    '            For i = Me.DetailViewTotalesMachote.SelectedItem.Index To 2 Step -1
    '                If Me.DetailViewTotalesMachote.Items(i - 1).Enabled And Me.DetailViewTotalesMachote.Items(i - 1).Visible Then
    '                    Me.DetailViewTotalesMachote.SelectedItem = Me.DetailViewTotalesMachote.Items(i - 1)

    '                    Exit For
    '                End If
    '            Next
    '        ElseIf e.KeyCode = Keys.Space Then
    '            e.Handled = True
    '            If IsNothing(Me.DetailViewTotalesMachote.SelectedItem) Then
    '                Exit Sub
    '            End If
    '            Dim i As Integer = Me.DetailViewTotalesMachote.SelectedItem.Index
    '            For i = Me.DetailViewTotalesMachote.SelectedItem.Index To Me.DetailViewTotalesMachote.Items.Count - 2
    '                If Me.DetailViewTotalesMachote.Items(i + 1).Enabled And Me.DetailViewTotalesMachote.Items(i + 1).Visible Then
    '                    Me.DetailViewTotalesMachote.SelectedItem = Me.DetailViewTotalesMachote.Items(i + 1)
    '                    Exit For
    '                End If
    '            Next
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub DetailViewTotales_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    Try
    '        Select Case e.KeyChar
    '            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
    '                If Not IsNothing(Me.DetailViewTotalesMachote.SelectedItem) Then
    '                    If Me.DetailViewTotalesMachote.SelectedItem.GetType.Name = "ItemTextBox" Or Me.DetailViewTotalesMachote.SelectedItem.GetType.Name = "ItemNumeric" Then
    '                        e.Handled = False
    '                        If Me.DetailViewTotalesMachote.SelectedItem.Index = Me.DetailViewTotalesMachote.Items.Count - 1 Then
    '                            If Not bGuardado Then
    '                                ButtonDetalleContinuar_Click(Nothing, Nothing)
    '                            End If
    '                        Else
    '                            DetailViewTotales_KeyDown(DetailViewTotalesMachote, New KeyEventArgs(Keys.Space))
    '                        End If
    '                    End If
    '                End If
    '        End Select
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Function AplicarTotales(ByRef paroTrp As TransProd, ByRef parsMonedasEliminadas As ArrayList) As Boolean
        Try
            ' Recalcular los totales (incluye el calculo del descuento del cliente, y que a su vez tambien incluye los descuentos por producto)
            If Not bSurtir Then
                paroTrp.DescuentoImp = 0
                paroTrp.DescuentoImpuestoCliente = 0
                paroTrp.DescuentoImpuestoVendedor = 0
                paroTrp.Descuento = 0

                Me.ObtenerTotalesDetalle(paroTrp)
            End If

            Dim bTieneMovs As Boolean = ObtenerNumeroMovimientos(paroTrp.TransProdId) <> 0
            ' Si el movimiento tiene registros
            If Not (bTieneMovs Or bSurtir) Then
                paroTrp.DescVendPor = 0
            End If
            ' Preparar el detalle para aplicar las promociones (quitar las que ya hubieran sido aplicadas)
            ' Cambios 05 Mayo 2006
            ' Pasar el parámetro bEsNuevo para indicar que el documento es nuevo o no
            'If Me.Promocion.Preparar(Me.TransProd.TransProdId, Me.TransProd.ModuloMovDetalle.ModuloMovDetalleClave, Me.TransProd.Tipo, Me.TransProd.ListaPrecios, Me.Impuesto, Me.TransProd.ClienteActual.TipoImpuesto) Then
            If Not bSurtir Then
                Dim blnRecalcularTotales As Boolean = False
                Dim dtSKUs As DataTable = oDBVen.RealizarConsultaSQL("Select TransProdDetalleID,ProductoClave, CodigoSKU, UnidadCobranza, Cantidad, Cantidad1,Factor, Factor1, Precio,DescuentoImp,DescuentoPor,Total from Transproddetalle where TransProdID ='" & paroTrp.TransProdId & "' and CodigoSKU<>'' order by ProductoClave", "SKUs")
                Dim dtProductos As DataTable = dtSKUs.DefaultView.ToTable(True, "ProductoClave")
                For Each drProducto As DataRow In dtProductos.Rows
                    Dim oRes As Object = dtSKUs.Compute("sum(Cantidad1)", "ProductoClave='" & drProducto("ProductoClave") & "'")
                    If Not IsNothing(oRes) Then
                        Dim oPrecio As Precio = TransProdDetalle.ObtenerPrecioRango(oTransProdGenerico.ListasPrecios, drProducto("ProductoClave"), CType(oRes, Decimal))
                        Dim drPreciosDif As DataRow
                        Dim drProductosPrecioDif() As DataRow = dtSKUs.Select("ProductoClave = '" & drProducto("ProductoClave") & "'")
                        Dim aImpuestos As New ArrayList
                        Me.Impuesto.Buscar(drProducto("ProductoClave"), Me.oTransProdGenerico.ClienteActual.TipoImpuesto, aImpuestos)
                        For Each drPreciosDif In drProductosPrecioDif
                            If Decimal.Round(drPreciosDif("Precio"), oConHist.Campos("DecimalesImporte")) <> oPrecio.Precio Then
                                Dim sComandoSQL As New System.Text.StringBuilder
                                sComandoSQL.Append("UPDATE TransProdDetalle SET ")
                                ' Asignar el nuevo precio 
                                sComandoSQL.Append("Precio = " & oPrecio.Precio & ", ")
                                Dim dSubtotalSinDescuento As Decimal = RedondeoAritmetico(((drPreciosDif("Cantidad") * drPreciosDif("Factor")) + (drPreciosDif("Cantidad1") * drPreciosDif("Factor1"))) * oPrecio.Precio, 2)
                                Dim dTotalOriginal As Decimal = RedondeoAritmetico((drPreciosDif("Total") * 100) / (100 - drPreciosDif("DescuentoPor")), 2)
                                Dim dDescuentoInicial As Decimal = RedondeoAritmetico(dTotalOriginal * (drPreciosDif("DescuentoPor") / 100), 2)

                                'Obtener el subtotal nuevo sin descuentos para aplicar el descuento imp
                                ' y obtener el nuevo descuentoPor
                                Dim dDescuentoPor As Decimal = 0
                                If dDescuentoInicial > 0 Then
                                    Dim dImpuestoSinDescuento As Decimal = RedondeoAritmetico(Me.Impuesto.Calcular(aImpuestos, RedondeoAritmetico(dSubtotalSinDescuento, 2), oPrecio.Precio), 2)
                                    dDescuentoPor = RedondeoAritmetico((dDescuentoInicial * 100) / (dSubtotalSinDescuento + dImpuestoSinDescuento), 4)
                                End If

                                sComandoSQL.Append("DescuentoPor= " & dDescuentoPor & ", ")
                                Dim dDescuentoImp As Decimal = RedondeoAritmetico((dSubtotalSinDescuento * (dDescuentoPor / 100)), 2)
                                sComandoSQL.Append("DescuentoImp= " & dDescuentoImp & ", ")
                                Dim dSubtotalConDescuento As Decimal = RedondeoAritmetico(dSubtotalSinDescuento - dDescuentoImp, 2)
                                sComandoSQL.Append("SubTotal = " & dSubtotalConDescuento & ", ")

                                Dim dImpuesto As Decimal = RedondeoAritmetico(Me.Impuesto.Calcular(aImpuestos, RedondeoAritmetico(dSubtotalConDescuento, 2), oPrecio.Precio), 2)
                                sComandoSQL.Append("Impuesto= " & dImpuesto & ", ")

                                sComandoSQL.Append("Total= " & RedondeoAritmetico(dSubtotalConDescuento + dImpuesto, 2) & ", ")
                                sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 ")
                                sComandoSQL.Append("WHERE TransProdId='" & paroTrp.TransProdId & "' AND ProductoClave='" & drPreciosDif("ProductoClave") & "' ")
                                sComandoSQL.Append("AND TransProdDetalleID='" & drPreciosDif("TransProdDetalleID") & "' ")
                                oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
                                sComandoSQL = Nothing
                                blnRecalcularTotales = True
                            End If
                        Next
                        If bRecalcularTotales Then Me.ObtenerTotalesDetalle(paroTrp)
                        oPrecio = Nothing
                    End If
                Next
                dtSKUs.Dispose()
                dtProductos.Dispose()
                'If Me.Promocion.Preparar(paroTrp.TransProdId, paroTrp.ModuloMovDetalle.ModuloMovDetalleClave, paroTrp.Tipo, paroTrp.ListasPrecios, Me.Impuesto, paroTrp.ClienteActual.TipoImpuesto, Me.bEsNuevo, oVendedor.TipoModulo, False, False) Then
                '    ' /Cambios 05 Mayo 2006
                '    ' Calcular las promociones
                '    If Me.Promocion.Aplicar(paroTrp, Me.Impuesto, paroTrp.ListasPrecios.ListasPrecios.Values(0).PrecioClave) Then
                '        ' Indicar que hay promociones en este detalle
                '        paroTrp.Promocion = 1
                '    Else
                '        ' Indicar que ya no hay promociones en este detalle
                '        paroTrp.Promocion = 0
                '    End If
                '    ' Volver a calcular los totales
                '    Me.ObtenerTotalesDetalle(paroTrp)
                'End If

                ' Aqui se calcula el descuento del Cliente
                paroTrp.DescuentoImp = 0
                ' Aqui se guarda el importe del descuento del impuesto por el descuento al cliente
                paroTrp.DescuentoImpuestoCliente = 0
                ' Calcular los descuentos del Cliente
                If Me.aDescuentosCliente.Count > 0 Then
                    ' Actualizar SubTDetalle (acumular en Me.TransProd.DescuentoImp el importe del descuento del cliente)
                    If Me.DescuentoCliente.CalcularAplicablesAlCliente(Me.aDescuentosCliente, paroTrp.SubTDetalle, paroTrp.Impuesto, paroTrp.TransProdId) Then
                        ' Guardar el detalle de los descuentos del cliente
                        Dim dtDescuentos As DataTable = oDBVen.RealizarConsultaSQL("Select sum(DesImporte) as DesImporte,sum(DesImpuesto) as DesImpuesto from TpdDes where TransProdID='" & paroTrp.TransProdId & "' ", "Descuentos")
                        If dtDescuentos.Rows.Count > 0 Then
                            paroTrp.DescuentoImp = dtDescuentos.Rows(0)("DesImporte")
                            paroTrp.DescuentoImpuestoCliente = dtDescuentos.Rows(0)("DesImpuesto")
                        End If
                        dtDescuentos.Dispose()
                        paroTrp.Descuento = IIf(bTieneMovs, 1, 0)
                        'Me.DescuentoCliente.GuardarDetalle(Me.TransProd.TransProdId, Me.aDescuentosCliente)
                    End If
                End If

                ' Recalcular el total
                paroTrp.RecalcularTotales()
            End If

            ' Actualizar el encabezado de Transprod
            paroTrp.Actualizar(bSurtir)
            If Not bTieneMovs Then
                BorrarPedido(paroTrp.TransProdId)
                If aTransProd.Count > 0 Then
                    If aTransProd.ContainsKey(paroTrp.MonedaID) Then
                        If Not IsNothing(parsMonedasEliminadas) Then
                            parsMonedasEliminadas.Add(paroTrp.MonedaID)
                        End If
                    End If
                End If
            End If
            Return True
        Catch ExcA As Exception
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "AplicarTotales")
        End Try
        Return False
    End Function

    Private Function BorrarPedido(ByVal parsTransProdID As String) As Boolean
        Try
            ' Borrar todo lo del pedido
            oDBVen.EjecutarComandoSQL("DELETE FROM TrpPrp WHERE TransProdID='" & parsTransProdID & "'")
            oDBVen.EjecutarComandoSQL("DELETE FROM TPDImpuesto WHERE TransProdID='" & parsTransProdID & "'")
            oDBVen.EjecutarComandoSQL("DELETE FROM TpdDes WHERE TransProdID='" & parsTransProdID & "'")
            oDBVen.EjecutarComandoSQL("DELETE FROM TpdDesVendedor WHERE TransProdID='" & parsTransProdID & "'")
            oDBVen.EjecutarComandoSQL("DELETE FROM TransProdDetalle WHERE TransProdID='" & parsTransProdID & "'")
            oDBVen.EjecutarComandoSQL("DELETE FROM ProductoNegado WHERE TransProdId='" & parsTransProdID & "'")
            oDBVen.EjecutarComandoSQL("DELETE FROM TransProd WHERE TransProdID='" & parsTransProdID & "'")
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    'Private Sub LlenarComboMonedas()
    '    Dim oItem As Resco.Controls.DetailView.ItemComboBox
    '    Dim dtMonedas As DataTable
    '    Dim sTipoCodigo As String
    '    Dim aMonedas As New ArrayList
    '    dtMonedas = oDBVen.RealizarConsultaSQL("select MonedaId, Nombre, TipoCodigo from Moneda", "Moneda")
    '    For Each drMoneda As DataRow In dtMonedas.Rows
    '        sTipoCodigo = ValorReferencia.BuscarEquivalente("CDGOMON", drMoneda("TipoCodigo").ToString)
    '        Dim oMoneda As New ValorReferencia.Valor(drMoneda("MonedaId"))
    '        oMoneda.Cadena = drMoneda("Nombre") & " " & sTipoCodigo
    '        aMonedas.Add(oMoneda)
    '    Next
    '    If aMonedas.Count > 0 Then
    '        oItem = DetailViewTotalesMachote.Items("MonedaId")
    '        oItem.ValueMember = "Id"
    '        oItem.DisplayMember = "Cadena"
    '        oItem.DataSource = aMonedas
    '        oItem.Visible = True
    '    End If
    '    dtMonedas.Dispose()
    'End Sub

    'Private Sub SeleccionaMoneda()
    '    Dim sConsulta As String = "select ABD.MonedaId from ABNDetalle ABD inner join AbnTrp ABT on ABD.ABNId = ABT.ABNId and ABT.TransProdId = '" & Me.TransProd.TransProdId & "'"
    '    Dim oItem As Resco.Controls.DetailView.ItemComboBox
    '    Dim dtAbonos As DataTable
    '    dtAbonos = oDBVen.RealizarConsultaSQL(sConsulta, "Abono")
    '    oItem = DetailViewTotales.Items("MonedaId")
    '    If dtAbonos.Rows.Count > 0 Then
    '        If IsDBNull(dtAbonos.Rows(0)("MonedaId")) Then
    '            oItem.Value = oConHist.Campos("MonedaID").ToString
    '        Else
    '            oItem.Value = dtAbonos.Rows(0)("MonedaId").ToString
    '        End If
    '    Else
    '        oItem.Value = oConHist.Campos("MonedaID").ToString
    '    End If
    '    dtAbonos.Dispose()
    'End Sub

    'Private Sub HabilitarMoneda()
    '    Dim refMoneda As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewTotales.Items("MonedaId")
    '    refMoneda.Enabled = False
    '    If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta AndAlso Me.TransProd.ModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Pedido AndAlso oConHist.Campos("PagoAutomatico") AndAlso oConHist.Campos("CobrarVentas") Then
    '        Dim refVenta As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewTotales.Items("FormaVenta")
    '        Dim refPago As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewTotales.Items("FormaPago")
    '        If Not refVenta.SelectedItem Is Nothing AndAlso Not refPago.SelectedItem Is Nothing Then
    '            Dim oDRVenta As ValorReferencia.Descripcion = refVenta.SelectedItem
    '            Dim nVenta As Integer = CInt(oDRVenta.Id)
    '            Dim oDRPago As ValorReferencia.Descripcion = refPago.SelectedItem
    '            Dim nPago As Integer = CInt(oDRPago.Id)
    '            'TODO: Probar Cambio TipoPago
    '            refMoneda.Enabled = (nVenta = 1 And ValorReferencia.RecuperaGrupo("PAGO", nPago) = "E")
    '            If Not refMoneda.Enabled Then
    '                SeleccionaMoneda()
    '            End If
    '        End If
    '    End If
    'End Sub

#End Region

    'Private Sub MenuItemPromociones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemPromociones.Click
    '    Dim sProdClave As String = Me.fgMovimientos.GetData(fgMovimientos.Row, ConstPosProductoClave)
    '    Dim oForma As New FormPromocionProducto(TransProd.ClienteActual, refaVista, sProdClave)
    '    oForma.ShowDialog()
    '    oForma.Dispose()
    '    oForma = Nothing
    'End Sub

    'Private Sub MenuItemGeneral_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemGeneral.Popup
    '    If Me.fgMovimientos.Row < 0 Then
    '        'Me.MenuItemPromociones.Enabled = False
    '    Else
    '        Dim r As C1.Win.C1FlexGrid.Row
    '        r = fgMovimientos.Rows(fgMovimientos.Row)
    '        If r.Node.Level = 0 Then
    '            'Me.MenuItemPromociones.Enabled = True
    '        Else
    '            'Me.MenuItemPromociones.Enabled = False
    '        End If

    '    End If
    'End Sub

    Private Sub ButtonImpuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImpuestos.Click
        'Dim oFormImpuestosDetalle As New FormImpuestosDetalle(oTransProd.TransProdId, CDbl(Me.DetailViewTotales.Items("DescuentoVendedor").Text))
        'oFormImpuestosDetalle.ShowDialog()
        'oFormImpuestosDetalle.Dispose()
    End Sub

    Private Sub EliminaElementosCombos()
        Try
            Dim oArrFormasVentaCliente As New ArrayList
            Dim oDt As DataTable = oDBVen.RealizarConsultaSQL("SELECT DISTINCT CFVTipo FROM CLIFormaVenta WHERE ClienteClave='" & oTransProdGenerico.ClienteActual.ClienteClave & "' AND Estado=1", "EliminaElementosCombos")

            For Each oDr As DataRow In oDt.Rows
                oArrFormasVentaCliente.Add(oDr("CFVTipo").ToString)
            Next
            oDt.Dispose()
            Dim oDescripcion As ValorReferencia.Descripcion
            Dim refComboBox As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewGeneral.Items("FormaVenta")
            'FormaVenta
            Dim loArrFormasVenta As ArrayList = refComboBox.DataSource

            If oArrFormasVentaCliente.Count > 0 Then
                For i As Integer = 0 To loArrFormasVenta.Count - 1
                    If i >= loArrFormasVenta.Count Then
                        Exit For
                    End If
                    oDescripcion = loArrFormasVenta(i)
                    If Not oArrFormasVentaCliente.Contains(oDescripcion.Id) Then
                        loArrFormasVenta.RemoveAt(i)
                        If i >= loArrFormasVenta.Count Then
                            Exit For
                        End If
                        i = i - 1
                    End If
                Next
            Else
                loArrFormasVenta.Clear()
            End If
            refComboBox.DataSource = loArrFormasVenta

            'FormaPago
            'oArr = New ArrayList
            'refComboBox = Me.DetailViewTotales.Items("FormaPago")

            oArrFormasVentaCliente.Clear()
            oArrFormasVentaCliente = Nothing

            'TODO: Cambio FormaPago
            'Dim oArrFormasPagoCliente As New ArrayList
            'oDt = oDBVen.RealizarConsultaSQL("SELECT DISTINCT Tipo FROM ClientePago WHERE ClienteClave='" & Me.TransProd.ClienteActual.ClienteClave & "'", "EliminaElementosCombos")
            'If oDt.Rows.Count > 0 Then
            '    For Each oDr As DataRow In oDt.Rows
            '        oArrFormasPagoCliente.Add(oDr("Tipo").ToString)
            '    Next

            '    Dim loArrFormasPago As ArrayList = refComboBox.DataSource
            '    If oArrFormasPagoCliente.Count > 0 Then
            '        For i As Integer = 0 To loArrFormasPago.Count - 1
            '            If i >= loArrFormasPago.Count Then
            '                Exit For
            '            End If
            '            oDescripcion = loArrFormasPago(i)
            '            If Not oArrFormasPagoCliente.Contains(oDescripcion.Id) Then
            '                loArrFormasPago.RemoveAt(i)
            '                If i >= loArrFormasPago.Count Then
            '                    Exit For
            '                End If
            '                i = i - 1
            '            End If
            '        Next
            '    Else
            '        loArrFormasPago.Clear()
            '    End If
            '    refComboBox.DataSource = loArrFormasPago
            '    oArrFormasPagoCliente.Clear()
            '    oArrFormasPagoCliente = Nothing
            'End If
            oDt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "EliminaElementosCombos")
        End Try
    End Sub

    Private Sub SeleccionaElementosCombos()
        Dim sQuery As String = "SELECT CFVTipo FROM TransProd WHERE TransProdId='" & oTransProdGenerico.TransProdId & "'"
        Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery, "SEC")
        Dim refComboBox As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewGeneral.Items("FormaVenta")
        Dim loArrFormaVenta As ArrayList = refComboBox.DataSource
        refComboBox.SelectedIndex = 0
        If oDt.Rows.Count <= 0 Then Exit Sub
        If Not IsDBNull(oDt.Rows(0)("CFVTipo")) Then
            For Each oDescripcion As ValorReferencia.Descripcion In loArrFormaVenta
                If oDescripcion.Id = oDt.Rows(0)("CFVTipo") Then
                    'refComboBox.SelectedIndex = oDescripcion.Id
                    refComboBox.Value = oDescripcion.Id
                    Exit For
                End If
            Next
        Else
            Dim iCFVTipo As Integer = oDBVen.EjecutarCmdScalarIntSQL("Select CFVTipo from CliFormaVenta where ClienteClave = '" & oTransProdGenerico.ClienteActual.ClienteClave & "' and Inicial = 1 ")
            If iCFVTipo > 0 Then
                refComboBox.Value = iCFVTipo.ToString
            End If
        End If

        'refComboBox = Me.DetailViewTotales.Items("FormaPago")

        'refComboBox.SelectedIndex = 0
        'If (Not IsDBNull(oDt.Rows(0)("ClientePagoId"))) AndAlso oDt.Rows(0)("ClientePagoId") <> String.Empty Then
        '    Dim loArrFormaPago As ArrayList = refComboBox.DataSource
        '    Dim iTipoPago As Integer
        '    iTipoPago = oDt.Rows(0)("ClientePagoId")
        '    For Each oDescripcion As ValorReferencia.Descripcion In loArrFormaPago
        '        If oDescripcion.Id = iTipoPago Then

        '            refComboBox.Value = oDescripcion.Id
        '            Exit For
        '        End If
        '    Next
        'End If
    End Sub

    Private Function ValidarCamposRequeridos() As Boolean
        'CFVTipo - FormaVenta
        Dim refComboBox As Resco.Controls.DetailView.ItemComboBox = Me.DetailViewGeneral.Items("FormaVenta")
        If refComboBox.SelectedItem Is Nothing OrElse Not refComboBox.SelectedIndex >= 0 Then
            MsgBox(SustituyeCampo(Me.refaVista.BuscarMensaje("MsgBox", "BE0001"), refComboBox.Label), MsgBoxStyle.Exclamation)
            refComboBox.SetFocus()
            Return False
        End If
        If Not (oTransProdGenerico.Tipo = ServicesCentral.TiposTransProd.MovSinInvEV) Then 'Si es movSinInv no se valida la fecha

            ''Fecha de Cobranza
            'Dim refDateTime As Resco.Controls.DetailView.ItemDateTime = Me.DetailViewTotalesMachote.Items("FechaCobranza")
            'If Not refDateTime Is Nothing Then
            '    'Dim dFecha As Date = refDateTime.DateTime
            '    If refDateTime.DateTime < PrimeraHora(Now) Then
            '        MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "FechaInvalida"), MsgBoxStyle.Exclamation)
            '        refDateTime.DateTime = PrimeraHora(Now)
            '        Return False
            '    End If

            '    Dim oDRV As ValorReferencia.Descripcion = refComboBox.SelectedItem
            '    If CInt(oDRV.Id) <> 1 AndAlso refDateTime.DateTime < Me.DetailViewTotalesMachote.Items("FechaEntrega").Value Then
            '        MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0254"), MsgBoxStyle.Exclamation)
            '        refDateTime.DateTime = Me.DetailViewTotalesMachote.Items("FechaEntrega").Value
            '        Return False
            '    End If
            'End If

            'Fecha de entrega
            'refComboBox = Me.DetailViewTotales.Items("TipoPedido")
            'If Not refComboBox.SelectedItem Is Nothing Then
            '    Dim oDRV As ValorReferencia.Descripcion = refComboBox.SelectedItem
            '    If CInt(oDRV.Id) = 2 OrElse CInt(oDRV.Id) = 4 Then
            '        refDateTime = Me.DetailViewTotales.Items("FechaEntrega")
            '        If Not refDateTime Is Nothing Then
            '            Dim dFecha As Date = refDateTime.DateTime
            '            If refDateTime.DateTime < PrimeraHora(Now) Then
            '                MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "FechaInvalida"), MsgBoxStyle.Exclamation)
            '                refDateTime.DateTime = PrimeraHora(Now)
            '                Return False
            '            End If
            '        End If
            '    End If
            'End If

        End If

        Return True
    End Function

    'Private Function VerificarTipoClaveProducto(ByRef pvTipoClave As Integer, ByRef pvEspacios As Integer) As Boolean
    '    Dim sQuery As String = "SELECT TipoClaveProducto, DigitoClaveProd FROM CONHist ORDER BY CONHistFechaInicio DESC"
    '    Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery, "VTCP")
    '    If oDt.Rows.Count > 0 Then
    '        pvTipoClave = oDt.Rows(0)("TipoClaveProducto")
    '        pvEspacios = oDt.Rows(0)("DigitoClaveProd")
    '        Return True
    '    End If
    '    Return False
    'End Function

    Private Sub AsignarValoresCapturados()
        Try
            Dim refCombo As Resco.Controls.DetailView.ItemComboBox = DetailViewGeneral.Items("FormaVenta")
            If Not refCombo.SelectedItem Is Nothing Then
                Dim oDRV As ValorReferencia.Descripcion = refCombo.SelectedItem
                oTransProdGenerico.CFVTipo = CInt(oDRV.Id)
                For Each oTrp As TransProd In aTransProd.Values
                    oTrp.CFVTipo = CInt(oDRV.Id)
                Next
            End If

            oTransProdGenerico.Notas = DetailViewGranTotal.Items("Notas").Text
            For Each oTrp As TransProd In aTransProd.Values
                oTrp.Notas = DetailViewGranTotal.Items("Notas").Text
            Next
            oTransProdGenerico.ClienteClave = oTransProdGenerico.ClienteActual.ClienteClave
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    'Private Sub VerificarFechaEntrega(ByVal partTipoPedido As ServicesCentral.TiposPedidos)
    '    Dim refDateTime As Resco.Controls.DetailView.ItemDateTime = Me.DetailViewTotalesMachote.Items("FechaEntrega")
    '    If Not refDateTime Is Nothing Then
    '        refDateTime.Visible = oTransProdGenerico.Tipo = ServicesCentral.TiposTransProd.Pedido AndAlso oTransProdGenerico.TipoFase = ServicesCentral.TiposFasesPedidos.Captura AndAlso (partTipoPedido = ServicesCentral.TiposPedidos.Posfechado OrElse partTipoPedido = ServicesCentral.TiposPedidos.Consignacion)
    '        If refDateTime.Visible Then
    '            Me.DetailViewTotalesMachote.Refresh()
    '            'refDateTime.SetFocus()
    '        End If
    '    End If
    'End Sub



    Private Sub fgMovimientos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fgMovimientos.KeyDown
        If (e.KeyCode = Keys.D4 AndAlso e.Modifiers = Keys.Control) OrElse e.KeyCode = Keys.F4 Then
            Dim oFormListasPrecios As New FormListasPrecios
            oFormListasPrecios.ShowDialog()
            oFormListasPrecios.Dispose()
        ElseIf (e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Shift) OrElse e.KeyCode = Keys.F3 Then
            If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then Exit Sub
            Me.BorrarMovimiento()
        End If
    End Sub

    Private Sub fgMovimientos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fgMovimientos.KeyUp
        Select Case e.KeyCode
            Case Keys.Space
                If fgMovimientos.Rows(fgMovimientos.Row).Node.Collapsed Then
                    fgMovimientos.Rows(fgMovimientos.Row).Node.Collapsed = False
                Else
                    fgMovimientos.Rows(fgMovimientos.Row).Node.Collapsed = True
                End If
        End Select
    End Sub

#Region "Lectura producto"

    Private Sub ActivarScanner()
#If MOD_TERM <> "PALM" Then
        If bSurtir Then Exit Sub
        If Not blnScannerActivo Then Exit Sub
        If Not bLector Then
            Select Case oApp.ModeloTerminal
                Case "Generico"

                Case "SymbolC9090", "SymbolMC50", "SymbolMC70"
                    Try
                        bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolPCMC50)
                        bLector = True
                    Catch ex As Exception
                        MsgBox("Error while starting the scanner:" & ex.Message, MsgBoxStyle.Critical)
                        bLector = False
                    End Try
                Case "HHP7600"
                    Try
                        bScanner.Inicialize_Scanner(HANDHELD.SO.HHP7600)
                        bLector = True
                    Catch ex As Exception
                        bLector = False
                    End Try
                Case "HHP7900"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.HHP7900)
                    bLector = True
                Case "HHPWM6"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.HHPWM6)
                    bLector = True
                Case "IntermecCN3"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.IntermecCN3)
                    bLector = True
                Case "SymbolMC55"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolMC55)
                    bLector = True
            End Select
        End If
#End If
    End Sub

    Private Sub DesactivarScanner()
#If MOD_TERM <> "PALM" Then
        If bSurtir Then Exit Sub
        If Not blnScannerActivo Then Exit Sub
        If bLector Then
            Try
                bScanner.Terminate_Scanner()
                bLector = False
            Catch ex As Exception
                bLector = True
                MsgBox("Error while stopping the scanner:" & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
#End If
    End Sub

    Private Sub FormActivos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        ActivarScanner()
    End Sub

    Private Sub FormActivos_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        DesactivarScanner()
    End Sub

#If MOD_TERM <> "PALM" Then
    Private Sub bScanner_Data_Scanned(ByVal Data As String) Handles bScanner.Data_Scanned
        If Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageMovimientos Then
            Me.TextBoxCodigo.Text = Data
            BuscarCodigoBarras()
        ElseIf Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageTotales Then
            If IsDBNull(Me.DetailViewGranTotal.Items("Notas").Text) OrElse Me.DetailViewGranTotal.Items("Notas").Text = "" Then
                Me.DetailViewGranTotal.Items("Notas").Text = Data
                Me.DetailViewGranTotal.Items("Notas").SetFocus()
            End If
        End If
    End Sub
#End If

    Private Sub TextBoxCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxCodigo.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                e.Handled = True
                BuscarCodigoBarras()
            Case Microsoft.VisualBasic.ChrW(Keys.Escape)
                e.Handled = True
                Me.SalirPlantillaCaptura()
        End Select
        bHuboCambios = True
    End Sub

    Private Sub GuardarSKU(ByVal parsSKU As String)
        Dim dt As DataTable = oDBVen.RealizarConsultaSQL("Select * from SKUInventario where CodigoSKU='" & parsSKU & "'", "SKUInvetario")

        If TransProdDetalle.CrearDetallePedido(oTransProdGenerico, "", 0, parsSKU, dt.Rows(0).Item("ProductoClave"), dt.Rows(0).Item("Disponible"), 1, dt.Rows(0).Item("TipoUnidad"), 1, Me.Impuesto, Me.bSurtir, Me.bEsNuevo, 0, aTransProd) = 1 Then
            MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0779").Replace("$0$", dt.Rows(0).Item("ProductoClave")), MsgBoxStyle.Exclamation)
        End If
        PoblarMovimientos()

        dt.Dispose()
        dt = Nothing
    End Sub

    Private Sub BuscarCodigoBarras()
        If TextBoxCodigo.Text.Trim <> String.Empty Then
            ContextMenuMovimientos.Dispose()

            If SKUInventario.ExisteSKU(Me.TextBoxCodigo.Text) Then
                Dim oSKU As SKUInventario
                oSKU = SKUInventario.Recuperar(TextBoxCodigo.Text.Trim)
                If oSKU.Disponible = 0 Or oSKU.Apartado > 0 Or oSKU.Cantidad = 0 Or oSKU.Apartado1 > 0 Then
                    MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0029"), MsgBoxStyle.Exclamation)
                    Me.TextBoxCodigo.SelectionStart = 0
                    Me.TextBoxCodigo.SelectionLength = Len(Me.TextBoxCodigo.Text)
                    Me.TextBoxCodigo.Focus()
                Else
                    If TransProdDetalle.CrearDetallePedido(oTransProdGenerico, "", 0, TextBoxCodigo.Text, oSKU.ProductoClave, oSKU.Disponible, 1, oSKU.TipoUnidad, 1, Me.Impuesto, Me.bSurtir, Me.bEsNuevo, 0, aTransProd) = 1 Then
                        MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0779").Replace("$0$", oSKU.ProductoClave), MsgBoxStyle.Exclamation)
                    End If
                    PoblarMovimientos()

                End If

            Else
                'Se valida si lo que se leyo es un codigo de barras 
                Dim sProductoClave As String = Me.Producto.BuscarCodigoBarras(Me.TextBoxCodigo.Text)
                If sProductoClave <> String.Empty Then
                    'Se valida si lo que se leyo tiene disponibilidad
                    If SKUInventario.ExistenciaDisponible(sProductoClave) = True Then
                        Me.ModificarMovimientoDet(0, sProductoClave)
                    Else
                        MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0741"), MsgBoxStyle.Exclamation)
                        Me.TextBoxCodigo.SelectionStart = 0
                        Me.TextBoxCodigo.SelectionLength = Len(Me.TextBoxCodigo.Text)
                        Me.TextBoxCodigo.Focus()
                    End If

                Else
                    MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0273").Replace("$0$", "Producto"), MsgBoxStyle.Exclamation)
                    Me.TextBoxCodigo.SelectionStart = 0
                    Me.TextBoxCodigo.SelectionLength = Len(Me.TextBoxCodigo.Text)
                    Me.TextBoxCodigo.Focus()
                End If

            End If

            Me.TextBoxCodigo.Text = String.Empty
        End If
    End Sub

#End Region

#Region "Fondo Cristal"
    Private Sub ButtonContinuarFondo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuarFondoCristal.Click
        Try
            Dim i As Integer = 0
            Dim sEliminados As String = String.Empty
            Dim aProductosPromocion As New ArrayList
            Dim dCantidad As Double = 0
            For i = 1 To fgFondoCristal.Rows.Count - 1
                If fgFondoCristal.Rows(i).Node.Level = 1 Then
                    If IsDBNull(fgFondoCristal.GetData(i, 1)) OrElse Not IsNumeric(fgFondoCristal.GetData(i, 1)) Then
                        fgFondoCristal.SetData(i, 1, 0)
                    End If
                    dCantidad = CDbl(fgFondoCristal.GetData(i, 1))
                    If dCantidad < 0 Or dCantidad > fgFondoCristal.GetData(i, "CantidadMaxima") Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0216").Replace("$0$", "0").Replace("$1$", fgFondoCristal.GetData(i, "CantidadMaxima").ToString), MsgBoxStyle.Information)
                        fgFondoCristal.Row = i
                        fgFondoCristal.Col = 1
                        fgFondoCristal.Focus()
                        Exit Sub
                    ElseIf fgFondoCristal.GetData(i, 1) = 0 Then
                        sEliminados &= "'" & fgFondoCristal.GetData(i, "TransProdDetalleID") & "',"
                    Else
                        Dim oProductoPromocion As New Promocion.Producto
                        oProductoPromocion.ProductoClave = fgFondoCristal.GetData(fgFondoCristal.Rows(i).Node.GetNode(C1.Win.C1FlexGrid.NodeTypeEnum.Parent).Row.Index, 0)
                        oProductoPromocion.PRUTipoUnidad = fgFondoCristal.GetData(i, "TipoUnidad")
                        oProductoPromocion.Cantidad = fgFondoCristal.GetData(i, 1)
                        aProductosPromocion.Add(oProductoPromocion)

                        If fgFondoCristal.GetData(i, 1) <> fgFondoCristal.GetData(i, "CantidadMaxima") Then
                            oDBVen.EjecutarComandoSQL("Update TransProdDetalle set Cantidad=" & oProductoPromocion.Cantidad & ", Total=" & oProductoPromocion.Cantidad & " * Precio  where TransProdID='" & oPromocion.TransProdIDFondoCristal & "' and TransProdDetalleID='" & fgFondoCristal.GetData(i, 5) & "' ")
                        End If
                    End If
                End If
            Next

            If sEliminados.Length > 0 Then
                sEliminados &= Microsoft.VisualBasic.Left(sEliminados, sEliminados.Length - 1)
                oDBVen.EjecutarComandoSQL("DELETE from TransProdDetalle where TransProdID='" & oPromocion.TransProdIDFondoCristal & "' and TransProdDetalleID in (" & sEliminados & ") ")
            End If

            If aProductosPromocion.Count > 0 Then
                Dim oProductoProm As Promocion.Producto
                For Each oProductoProm In aProductosPromocion
                    If oTransProdGenerico.ModuloMovDetalle.TipoModulo = ServicesCentral.TiposModulos.Preventa And oAgenda.RutaActual.Inventario = True Then
                        Inventario.ActualizarInventarioDec(oProductoProm.ProductoClave, oProductoProm.PRUTipoUnidad, oProductoProm.Cantidad, ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, False)
                    Else
                        Inventario.ActualizarInventarioDec(oProductoProm.ProductoClave, oProductoProm.PRUTipoUnidad, oProductoProm.Cantidad, ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.NoDefinido, oVendedor.AlmacenId, False)
                    End If
                Next
            Else
                oDBVen.EjecutarComandoSQL("DELETE from TransProd where TransProdID='" & oPromocion.TransProdIDFondoCristal & "'")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try

        Me.PanelFondoCristal.Visible = False
        Me.Panel1.Visible = True
        Me.DetailViewPie.Visible = True

        If oTransProdGenerico.Tipo = ServicesCentral.TiposTransProd.Pedido AndAlso oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta AndAlso oTransProdGenerico.ModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Pedido Then
            If aTransProd.Count > 0 Then
                For Each oTrp As TransProd In aTransProd.Values
                    MobileClient.TransProd.SurtirPedido(oTrp.TransProdId)
                Next
            Else
                MobileClient.TransProd.SurtirPedido(oTransProdGenerico.TransProdId)
            End If
        End If

        Me.AceptarTransaccion(true)
        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        'Me.Dispose()Se quito el dispose por el folio 3158
    End Sub

    Private Sub fgFondoCristal_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fgFondoCristal.AfterEdit
        If bIniciando Then Exit Sub
        If e.Col = 1 Then
            If fgFondoCristal.Rows(e.Row).Node.Level = 1 Then
                If IsDBNull(fgFondoCristal.GetData(e.Row, 1)) OrElse Not IsNumeric(fgFondoCristal.GetData(e.Row, 1)) Then
                    fgFondoCristal.SetData(e.Row, 1, 0)
                End If

                If fgFondoCristal.GetData(e.Row, 1) < 0 Then
                    e.Cancel = True
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0012"), MsgBoxStyle.Information)
                    Exit Sub
                End If
                Dim dDiferencia As Double = ((fgFondoCristal.GetData(e.Row, 1) * fgFondoCristal.GetData(e.Row, "Precio")) - fgFondoCristal.GetData(e.Row, "TotalAnt"))
                dTotalFondoCristal = dTotalFondoCristal + dDiferencia
                Dim iIndicePadre As Integer = fgFondoCristal.Rows(e.Row).Node.GetNode(C1.Win.C1FlexGrid.NodeTypeEnum.Parent).Row.Index
                fgFondoCristal.SetData(iIndicePadre, 3, fgFondoCristal.GetData(iIndicePadre, 3) + dDiferencia)
                Me.TextBoxTotalFondoCristal.Text = Format(dTotalFondoCristal, "#,##0.00")
                bIniciando = True
                fgFondoCristal.SetData(e.Row, 3, fgFondoCristal.GetData(e.Row, 1) * fgFondoCristal.GetData(e.Row, "Precio"))
                fgFondoCristal.SetData(e.Row, 7, fgFondoCristal.GetData(e.Row, 1) * fgFondoCristal.GetData(e.Row, "Precio"))
                bIniciando = False
            End If
        End If
    End Sub
#End Region

    Private Sub ContextMenu1_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenu1.Popup
        MostrarContext()
    End Sub
    Private Sub MostrarContext()
        DesactivarScanner()

        ContextMenuMovimientos.Show(Me, Control.MousePosition)
        ActivarScanner()
    End Sub
    Private Sub CheckBoxProducto_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxProducto.CheckStateChanged
        If IsNothing(refaVista) Then
            Return
        End If
        If CheckBoxProducto.Checked Then
            CheckBoxProducto.Text = "LabelProductoId"
        Else
            CheckBoxProducto.Text = "LabelProducto"
        End If
        refaVista.ColocarEtiquetasControl(CheckBoxProducto)
        bHuboCambios = True
    End Sub


    Private Sub MenuItemPesoReal_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.fgMovimientos.Rows.Count <= 0 Then Exit Sub

        Dim r As C1.Win.C1FlexGrid.Row = fgMovimientos.Rows(fgMovimientos.Row)

        If r.Node.Level = 1 Then
            CapturarBonificaciones(TipoBonificacion.PesoReal, fgMovimientos.GetData(fgMovimientos.Row, ConstIndiceTransProdDetalleID), fgMovimientos.GetData(fgMovimientos.Row, "TransProdID"))
        End If
    End Sub

    Private Sub MenuItemBonificacion_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If Me.fgMovimientos.Rows.Count <= 0 Then Exit Sub

        Dim r As C1.Win.C1FlexGrid.Row = fgMovimientos.Rows(fgMovimientos.Row)

        If r.Node.Level = 1 Then
            CapturarBonificaciones(TipoBonificacion.BonificacionImporte, fgMovimientos.GetData(fgMovimientos.Row, ConstIndiceTransProdDetalleID), fgMovimientos.GetData(fgMovimientos.Row, "TransProdID"))
        End If

    End Sub

    Private Sub MenuItemDevolucion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemDevolucion.Click
        If Me.fgMovimientos.Rows.Count <= 0 Then Exit Sub

        Dim r As C1.Win.C1FlexGrid.Row = fgMovimientos.Rows(fgMovimientos.Row)
        If r.Node.Level = 0 Then

        ElseIf r.Node.Level = 1 Then
            CapturarBonificaciones(TipoBonificacion.Devolucion, fgMovimientos.GetData(fgMovimientos.Row, ConstIndiceTransProdDetalleID), fgMovimientos.GetData(fgMovimientos.Row, "TransProdID"))
        End If
    End Sub

    Public Sub GuardarDetalleBonificacionReparto(ByRef refparoFormBonificaciones As FormBonificaciones)
        If IsNothing(Me.TransProdDevolucion) Then
            Me.TransProdDevolucion = New TransProd
            With TransProdDevolucion
                .TransProdId = oApp.KEYGEN(1)
                .VisitaActual = sVisitaActual
                .DiaClave = oDia.DiaActual
                .ModuloMovDetalle = oTransProdGenerico.ModuloMovDetalle
                .ClienteClave = oTransProdGenerico.ClienteActual.ClienteClave
                .Tipo = ServicesCentral.TiposTransProd.BonificacionPorDetalle
                .FolioActual = oTransProdGenerico.FolioActual
                .TipoPedido = ServicesCentral.TiposPedidos.NoDefinido
                .TipoFase = ServicesCentral.TiposFasesPedidos.Captura
                .TipoMovimiento = ServicesCentral.TiposMovimientos.Entrada
                .FacturaId = oTransProdGenerico.TransProdId
                .Actualizar(bSurtir)
            End With
        End If
        Dim dTotalPartida As Decimal = 0
        Select Case refparoFormBonificaciones.TipoBonificacion
            Case TipoBonificacion.Devolucion
                If TransProdDetalle.CrearDetalleBonificacion(Me.TransProdDevolucion.TransProdId, refparoFormBonificaciones.TransProdDetalleIDPedido, refparoFormBonificaciones.ProductoClave, refparoFormBonificaciones.CodigoSKU, refparoFormBonificaciones.TipoUnidad, refparoFormBonificaciones.CantidadPedido, refparoFormBonificaciones.Cantidad1Pedido, refparoFormBonificaciones.FactorPedido, refparoFormBonificaciones.Factor1Pedido, refparoFormBonificaciones.Precio, 0, 0, refparoFormBonificaciones.ImpuestoPedido, refparoFormBonificaciones.ComboBoxMotivo.SelectedValue, 0, dTotalPartida, TransProdDevolucion.FacturaId) = True Then
                    TransProdDevolucion.Total = TransProdDevolucion.Total + refparoFormBonificaciones.TotalPedido
                    PoblarGridMovimientos()
                End If

                'Case TipoBonificacion.PesoReal
                '    Dim dPorc As Decimal = (((refparoFormBonificaciones.txtCantidad.DecimalValue * refparoFormBonificaciones.FactorPedido) + (refparoFormBonificaciones.txtCantidad1.DecimalValue * refparoFormBonificaciones.Factor1Pedido)) * 100) / ((refparoFormBonificaciones.CantidadPedido * refparoFormBonificaciones.FactorPedido) + (refparoFormBonificaciones.Cantidad1Pedido * refparoFormBonificaciones.Factor1Pedido))
                '    dPorc = dPorc / 100
                '    Dim dCantidadDev As Decimal = refparoFormBonificaciones.CantidadPedido - refparoFormBonificaciones.txtCantidad.DecimalValue
                '    If TransProdDetalle.CrearDetalleBonificacion(Me.TransProdDevolucion.TransProdId, refparoFormBonificaciones.TransProdDetalleIDPedido, refparoFormBonificaciones.ProductoClave, refparoFormBonificaciones.CodigoSKU, refparoFormBonificaciones.TipoUnidad, dCantidadDev, Math.Round(refparoFormBonificaciones.Cantidad1Pedido - refparoFormBonificaciones.txtCantidad1.DecimalValue, 2), refparoFormBonificaciones.FactorPedido, refparoFormBonificaciones.Factor1Pedido, refparoFormBonificaciones.Precio, 0, 0, refparoFormBonificaciones.ImpuestoPedido, refparoFormBonificaciones.ComboBoxMotivo.SelectedValue, dPorc, dTotalPartida) = True Then
                '        TransProdDevolucion.Total = TransProdDevolucion.Total + dTotalPartida
                '        PoblarGridMovimientos()
                '    End If

                'Case TipoBonificacion.BonificacionImporte
                '    Dim dDescuentoImp As Decimal = (((refparoFormBonificaciones.CantidadPedido * refparoFormBonificaciones.FactorPedido) + (refparoFormBonificaciones.Cantidad1Pedido * refparoFormBonificaciones.Factor1Pedido)) * refparoFormBonificaciones.Precio) * (refparoFormBonificaciones.txtDescuentoPor.DecimalValue / 100)
                '    If TransProdDetalle.CrearDetalleBonificacion(Me.TransProdDevolucion.TransProdId, refparoFormBonificaciones.TransProdDetalleIDPedido, refparoFormBonificaciones.ProductoClave, refparoFormBonificaciones.CodigoSKU, refparoFormBonificaciones.TipoUnidad, 0, 0, refparoFormBonificaciones.FactorPedido, refparoFormBonificaciones.Factor1Pedido, refparoFormBonificaciones.Precio, refparoFormBonificaciones.txtDescuentoPor.DecimalValue, dDescuentoImp, refparoFormBonificaciones.ImpuestoPedido, refparoFormBonificaciones.ComboBoxMotivo.SelectedValue, 0, dTotalPartida) = True Then
                '        TransProdDevolucion.Total = TransProdDevolucion.Total + dTotalPartida
                '        PoblarGridMovimientos()
                '    End If
        End Select

    End Sub
    Public Sub GuardarDetalleBonificacionVenta(ByRef refparoFormBonificaciones As FormBonificaciones)
        Select Case refparoFormBonificaciones.TipoBonificacion
            Case TipoBonificacion.PesoReal
                If refparoFormBonificaciones.CodigoSKU = "" Then Exit Sub
                Dim iTipoMotivo As Integer = 0
                If refparoFormBonificaciones.txtCantidad.DecimalValue <> refparoFormBonificaciones.CantidadPedido + refparoFormBonificaciones.Merma Then
                    iTipoMotivo = refparoFormBonificaciones.ComboBoxMotivo.SelectedValue
                End If

                BorrarMovimientoSKU(TipoBorrado.SKU, refparoFormBonificaciones.CodigoSKU, refparoFormBonificaciones.ProductoClave, refparoFormBonificaciones.TransProdIDPedido)

                Dim oPrecio As New Precio(refparoFormBonificaciones.UnidadCobranza, refparoFormBonificaciones.Precio, refparoFormBonificaciones.MonedaID, refparoFormBonificaciones.FactorPedido, refparoFormBonificaciones.Factor1Pedido)
                If TransProdDetalle.CrearDetallePedido(oTransProdGenerico, refparoFormBonificaciones.TransProdIDPedido, 0, refparoFormBonificaciones.CodigoSKU, refparoFormBonificaciones.ProductoClave, refparoFormBonificaciones.txtCantidad.DecimalValue, 1, refparoFormBonificaciones.TipoUnidad, 1, Me.Impuesto, Me.bSurtir, Me.bEsNuevo, iTipoMotivo, aTransProd, oPrecio) = 1 Then
                    MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0779").Replace("$0$", refparoFormBonificaciones.ProductoClave), MsgBoxStyle.Exclamation)
                End If
            Case TipoBonificacion.BonificacionImporte
                Try
                    ' Determinar el numero de partida
                    'TODO: Division
                    Dim oTransProdDetalle As New TransProdDetalle(refparoFormBonificaciones.TransProdIDPedido, refparoFormBonificaciones.ProductoClave, 0)
                    oTransProdDetalle.ObtenerListaImpuestos(Me.Impuesto, oTransProdGenerico.ClienteActual.TipoImpuesto)
                    'Validar los impuestos
                    oTransProdDetalle.ValidarImpuestos(oTransProdGenerico.ClienteActual)

                    ' Actualizar el detalle
                    oTransProdDetalle.TransProdDetalleID = refparoFormBonificaciones.TransProdDetalleIDPedido
                    oTransProdDetalle.TipoUnidad = refparoFormBonificaciones.TipoUnidad
                    oTransProdDetalle.CodigoSKU = refparoFormBonificaciones.CodigoSKU

                    Dim iTipoMotivo As Integer = 0
                    If refparoFormBonificaciones.txtDescuentoImp.DecimalValue > 0 Then
                        iTipoMotivo = refparoFormBonificaciones.ComboBoxMotivo.SelectedValue
                    End If

                    oTransProdDetalle.TipoMotivo = iTipoMotivo
                    oTransProdDetalle.Cantidad = refparoFormBonificaciones.CantidadPedido
                    oTransProdDetalle.Cantidad1 = refparoFormBonificaciones.Cantidad1Pedido
                    oTransProdDetalle.Factor = refparoFormBonificaciones.FactorPedido
                    oTransProdDetalle.Factor1 = refparoFormBonificaciones.Factor1Pedido
                    'TODO: Division
                    oTransProdDetalle.PrecioSinFactor = New Precio(refparoFormBonificaciones.UnidadCobranza, refparoFormBonificaciones.Precio, refparoFormBonificaciones.MonedaID, refparoFormBonificaciones.FactorPedido, refparoFormBonificaciones.Factor1Pedido) 'oTransProdDetalle.ObtenerPrecioRango(oTransProdGenerico.ListasPrecios)
                    If IsNothing(oTransProdDetalle.PrecioSinFactor) Then
                        Exit Sub
                    End If
                    oTransProdDetalle.DescuentoPor = refparoFormBonificaciones.txtDescuentoPor.DecimalValue
                    oTransProdDetalle.ObtenerTipoAplicacionDescuentos(oTransProdGenerico.ModuloMovDetalle.ModuloMovDetalleClave, Me.bEsNuevo)
                    oTransProdDetalle.ActualizarDec(oTransProdDetalle.TransProdDetalleID, oTransProdGenerico.Tipo, Me.Impuesto, oTransProdDetalle.Cantidad, oTransProdDetalle.Cantidad, oTransProdDetalle.TipoUnidad, 1, ServicesCentral.TiposMovimientos.NoDefinido, oTransProdGenerico.ClienteActual, )

                Catch ExcA As SqlCeException
                    MsgBox(ExcA.Message, MsgBoxStyle.Critical, "GuardarDetallePedido")
                Catch ExcB As Exception
                    MsgBox(ExcB.Message, MsgBoxStyle.Critical, "GuardarDetallePedido")
                End Try

        End Select

        PoblarMovimientos()
    End Sub
    Private Sub CapturarBonificaciones(ByVal partBonificacion As TipoBonificacion, ByVal parsTransProdDetalleID As String, ByVal parsTransprodID As String)

        Dim oFormBonificaciones As New FormBonificaciones(partBonificacion)
        oFormBonificaciones.TransProdDetalleIDPedido = parsTransProdDetalleID
        oFormBonificaciones.TransProdIDPedido = parsTransprodID
        If bSurtir Then
            oFormBonificaciones.TipoPedido = TipoPedido.Reparto
            AddHandler oFormBonificaciones.GuardarDetalleBonificacion, AddressOf GuardarDetalleBonificacionReparto
        Else
            oFormBonificaciones.TipoPedido = TipoPedido.VentaDirecta
            AddHandler oFormBonificaciones.GuardarDetalleBonificacion, AddressOf GuardarDetalleBonificacionVenta
        End If

        oFormBonificaciones.ShowDialog()

        If bSurtir Then
            RemoveHandler oFormBonificaciones.GuardarDetalleBonificacion, AddressOf GuardarDetalleBonificacionReparto
        Else
            RemoveHandler oFormBonificaciones.GuardarDetalleBonificacion, AddressOf GuardarDetalleBonificacionVenta
        End If

        oFormBonificaciones.Dispose()
        oFormBonificaciones = Nothing
    End Sub

    Function RegresaTransProdActual() As String
        Dim sTransProd As String = String.Empty
        If aTransProd.Count > 0 Then
            For Each oTrp As TransProd In aTransProd.Values
                sTransProd &= "'" & oTrp.TransProdId & "',"
            Next
            sTransProd = Microsoft.VisualBasic.Left(sTransProd, sTransProd.Length - 1)
        Else
            sTransProd = "'" & oTransProdGenerico.TransProdId & "'"
        End If
        Return sTransProd
    End Function

    Function RegresaArregloFacturas() As String()
        Dim iDimension As Integer = IIf(aTransProdFactura.Count <= 0, 1, aTransProdFactura.Count)
        Dim sTransProd(iDimension - 1) As String
        'Dim sTransProd(0) As String

        If aTransProdFactura.Count > 0 Then
            Dim i As Integer = 0
            For Each oTrp As TransProd In aTransProdFactura.Values
                sTransProd(i) = oTrp.TransProdId
                i += 1
            Next
        Else
            sTransProd(0) = "'" & oTransProdGenerico.FacturaId & "'"
        End If
        Return sTransProd
    End Function


    Private Sub ButtonContinuarDatFac_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuarDatFac.Click
        If aTRPDatoFiscal.Count <= 0 Then
            Exit Sub
        End If
        Dim oTRPDatoFiscal As TRPDatoFiscal
        For Each oTRPDatoFiscal In aTRPDatoFiscal.Values
            Exit For
        Next
        Dim blnHuboCambios As Boolean = False

        If (IsNothing(Me.DetailViewDatosFiscales.Items("RazonSocial").Value) OrElse Me.DetailViewDatosFiscales.Items("RazonSocial").Value = "") Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.DetailViewDatosFiscales.Items("RazonSocial").Label))
            DetailViewDatosFiscales.Items("RazonSocial").SetFocus()
            Cursor.Current = Cursors.Default
            Exit Sub
        ElseIf (oTRPDatoFiscal.RazonSocial <> Me.DetailViewDatosFiscales.Items("RazonSocial").Value) Then
            blnHuboCambios = True
        End If

        If (IsNothing(Me.DetailViewDatosFiscales.Items("IdFiscal").Value) OrElse Me.DetailViewDatosFiscales.Items("IdFiscal").Value = "") Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.DetailViewDatosFiscales.Items("IdFiscal").Label))
            DetailViewDatosFiscales.Items("IdFiscal").SetFocus()
            Cursor.Current = Cursors.Default
            Exit Sub
        ElseIf (oTRPDatoFiscal.RFC <> Me.DetailViewDatosFiscales.Items("IdFiscal").Value) Then
            blnHuboCambios = True
        End If
        If (IsNothing(Me.DetailViewDatosFiscales.Items("Calle").Value) OrElse Me.DetailViewDatosFiscales.Items("Calle").Value = "") Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.DetailViewDatosFiscales.Items("Calle").Label))
            DetailViewDatosFiscales.Items("Calle").SetFocus()
            Cursor.Current = Cursors.Default
            Exit Sub
        ElseIf (oTRPDatoFiscal.Calle <> Me.DetailViewDatosFiscales.Items("Calle").Value) Then
            blnHuboCambios = True
        End If
        If (IsNothing(Me.DetailViewDatosFiscales.Items("Numero").Value) OrElse Me.DetailViewDatosFiscales.Items("Numero").Value = "") Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.DetailViewDatosFiscales.Items("Numero").Label))
            DetailViewDatosFiscales.Items("Numero").SetFocus()
            Cursor.Current = Cursors.Default
            Exit Sub
        ElseIf (oTRPDatoFiscal.NumExt <> Me.DetailViewDatosFiscales.Items("Numero").Value) Then
            blnHuboCambios = True
        End If
        If (IsNothing(Me.DetailViewDatosFiscales.Items("Colonia").Value) OrElse Me.DetailViewDatosFiscales.Items("Colonia").Value = "") Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.DetailViewDatosFiscales.Items("Colonia").Label))
            DetailViewDatosFiscales.Items("Colonia").SetFocus()
            Cursor.Current = Cursors.Default
            Exit Sub
        ElseIf (oTRPDatoFiscal.Colonia <> Me.DetailViewDatosFiscales.Items("Colonia").Value) Then
            blnHuboCambios = True
        End If
        If (IsNothing(Me.DetailViewDatosFiscales.Items("Entidad").Value) OrElse Me.DetailViewDatosFiscales.Items("Entidad").Value = "") Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.DetailViewDatosFiscales.Items("Entidad").Label))
            DetailViewDatosFiscales.Items("Entidad").SetFocus()
            Cursor.Current = Cursors.Default
            Exit Sub
        ElseIf (oTRPDatoFiscal.Entidad <> Me.DetailViewDatosFiscales.Items("Entidad").Value) Then
            blnHuboCambios = True
        End If
        If (IsNothing(Me.DetailViewDatosFiscales.Items("Poblacion").Value) OrElse Me.DetailViewDatosFiscales.Items("Poblacion").Value = "") Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.DetailViewDatosFiscales.Items("Poblacion").Label))
            DetailViewDatosFiscales.Items("Poblacion").SetFocus()
            Cursor.Current = Cursors.Default
            Exit Sub
        ElseIf (oTRPDatoFiscal.Municipio <> Me.DetailViewDatosFiscales.Items("Poblacion").Value) Then
            blnHuboCambios = True
        End If

        If (IsNothing(Me.DetailViewDatosFiscales.Items("Pais").Value) OrElse Me.DetailViewDatosFiscales.Items("Pais").Value = "") Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.DetailViewDatosFiscales.Items("Pais").Label))
            DetailViewDatosFiscales.Items("Pais").SetFocus()
            Cursor.Current = Cursors.Default
            Exit Sub
        ElseIf (oTRPDatoFiscal.Pais <> Me.DetailViewDatosFiscales.Items("Pais").Value) Then
            blnHuboCambios = True
        End If
        If (IsNothing(Me.DetailViewDatosFiscales.Items("CodigoPostal").Value) OrElse Me.DetailViewDatosFiscales.Items("CodigoPostal").Value = "") Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", Me.DetailViewDatosFiscales.Items("CodigoPostal").Label))
            DetailViewDatosFiscales.Items("CodigoPostal").SetFocus()
            Cursor.Current = Cursors.Default
            Exit Sub
        ElseIf (oTRPDatoFiscal.CodigoPostal <> Me.DetailViewDatosFiscales.Items("CodigoPostal").Value) Then
            blnHuboCambios = True
        End If

        If Not IsNothing(Me.DetailViewDatosFiscales.Items("NumInt").Value) Then
            If (oTRPDatoFiscal.NumInt <> Me.DetailViewDatosFiscales.Items("NumInt").Value) Then
                blnHuboCambios = True
            End If
        End If

        If Not IsNothing(Me.DetailViewDatosFiscales.Items("Localidad").Value) Then
            If (oTRPDatoFiscal.Localidad <> Me.DetailViewDatosFiscales.Items("Localidad").Value) Then
                blnHuboCambios = True
            End If
        End If

        If Not IsNothing(Me.DetailViewDatosFiscales.Items("ReferenciaDom").Value) Then
            If (oTRPDatoFiscal.ReferenciaDom <> Me.DetailViewDatosFiscales.Items("ReferenciaDom").Value) Then
                blnHuboCambios = True
            End If
        End If

        If blnHuboCambios Then
            For Each oTRPDatoFiscal In aTRPDatoFiscal.Values
                With oTRPDatoFiscal
                    .RazonSocial = DetailViewDatosFiscales.Items("RazonSocial").Value
                    .RFC = DetailViewDatosFiscales.Items("IdFiscal").Value
                    .Calle = DetailViewDatosFiscales.Items("Calle").Value
                    .NumExt = DetailViewDatosFiscales.Items("Numero").Value
                    .NumInt = DetailViewDatosFiscales.Items("NumInt").Value
                    .Colonia = DetailViewDatosFiscales.Items("Colonia").Value
                    .Localidad = DetailViewDatosFiscales.Items("Localidad").Value
                    .Municipio = DetailViewDatosFiscales.Items("Poblacion").Value
                    .Entidad = DetailViewDatosFiscales.Items("Entidad").Value
                    .Pais = DetailViewDatosFiscales.Items("Pais").Value
                    .CodigoPostal = DetailViewDatosFiscales.Items("CodigoPostal").Value
                    .ReferenciaDom = DetailViewDatosFiscales.Items("ReferenciaDom").Value
                    .DatFacturaEditados = True
                End With
            Next
        End If

        Me.PanelDatosFacturacion.Visible = False
        Me.Panel1.Visible = False
        Me.TabControlMovProducto.Visible = False
        MostrarFacturas()
    End Sub

    Private Sub MostrarFacturas()
        Me.PanelFacturas.Visible = True
        If oTransProdGenerico.ClienteActual.CapturaDatosFacturacion Then
            Me.MenuItemRegresar.Enabled = True
        Else
            Me.MenuItemRegresar.Enabled = False
        End If
        If Not IsNothing(aControlesFactura) AndAlso aControlesFactura.Count > 0 Then Exit Sub

        aControlesFactura = New Generic.Dictionary(Of String, Generic.Dictionary(Of String, Control))()
        Dim indiceTab As Int16 = 0
        For Each oTransProdFactura As TransProd In aTransProdFactura.Values
            If aControlesFactura.Count <= 0 Then
                Dim aCtl As New Generic.Dictionary(Of String, Control)
                TabPageFactura.Text = ValorReferencia.BuscarEquivalente("CDGOMON", IIf(IsNothing(aTipoCodigoMonedas(oTransProdFactura.MonedaID)), 0, aTipoCodigoMonedas(oTransProdFactura.MonedaID)))
                TabPageFactura.Tag = indiceTab
                indiceTab += 1
                txtFolioFac.Text = oTransProdFactura.FolioActual
                txtFechaFac.Text = oTransProdFactura.FechaHoraAlta.ToString("dd/MM/yyyy")
                txtFormaPagoFac.Text = ValorReferencia.BuscarEquivalente("FVENTA", oTransProdFactura.CFVTipo)
                txtOrdenCompra.Text = oTransProdFactura.Notas
                aCtl.Add("OrdenCompra", txtOrdenCompra)
                aCtl.Add("grdMetodoPago", grdMetodoPago)
                aCtl.Add("ListViewMetodosPago", ListViewMetodosPago)
                aControlesFactura.Add(oTransProdFactura.MonedaID, aCtl)
                LlenarMetodoPago(aCtl)
            Else
                Dim aCtl As New Generic.Dictionary(Of String, Control)
                Dim tp As TabPage = New TabPage()
                'aTabPages.Add(oTransProdFactura.MonedaID, tp)
                tp.Text = ValorReferencia.BuscarEquivalente("CDGOMON", IIf(IsNothing(aTipoCodigoMonedas(oTransProdFactura.MonedaID)), 0, aTipoCodigoMonedas(oTransProdFactura.MonedaID)))
                Dim Controles() As Control
                ReDim Controles(TabPageFactura.Controls.Count)
                TabPageFactura.Controls.CopyTo(Controles, 0)
                Dim ctNew As Control
                For i As Integer = 0 To Controles.GetUpperBound(0)
                    If IsNothing(Controles(i)) Then Exit For
                    ctNew = CloneControl(Controles(i))
                    If ctNew.GetType.ToString = "System.Windows.Forms.TextBox" Then
                        tp.Controls.Add(ctNew)
                        If Controles(i).Name.ToUpper = "TXTFOLIOFAC" Then
                            ctNew.Text = oTransProdFactura.FolioActual
                        ElseIf Controles(i).Name.ToUpper = "TXTFECHAFAC" Then
                            ctNew.Text = oTransProdFactura.FechaHoraAlta.ToString("dd/MM/yyyy")
                        ElseIf Controles(i).Name.ToUpper = "TXTFORMAPAGO" Then
                            ctNew.Text = ValorReferencia.BuscarEquivalente("FVENTA", oTransProdFactura.CFVTipo)
                        ElseIf Controles(i).Name.ToUpper = "TXTORDENCOMPRA" Then
                            ctNew.Text = oTransProdFactura.Notas
                            aCtl.Add("OrdenCompra", ctNew)
                        End If
                    ElseIf ctNew.GetType.ToString = "C1.Win.C1FlexGrid.C1FlexGrid" Then
                        Dim gr As C1.Win.C1FlexGrid.C1FlexGrid = ctNew
                        AddHandler gr.AfterEdit, AddressOf grdMetodoPago_AfterEdit
                        AddHandler gr.BeforeEdit, AddressOf grdMetodoPago_BeforeEdit
                        AddHandler gr.EnterCell, AddressOf grdMetodoPago_EnterCell
                        gr.ContextMenu = Me.ContextMenuMetodo
                        aCtl.Add("grdMetodoPago", ctNew)
                    ElseIf ctNew.GetType.ToString = "System.Windows.Forms.ListView" Then
                        aCtl.Add("ListViewMetodosPago", ctNew)
                    End If
                    tp.Controls.Add(ctNew)
                Next
                tp.Tag = indiceTab
                TabControlFacturas.TabPages.Add(tp)
                indiceTab += 1
                aControlesFactura.Add(oTransProdFactura.MonedaID, aCtl)
                LlenarMetodoPago(aCtl)
            End If
        Next
    End Sub

#Region "Metodo de Pago"
    Private Sub LlenarMetodoPago(ByRef oComponentes As Generic.Dictionary(Of String, Control))
        bCapturaGrid = False
        Dim dtMetodosConfig As DataTable = oDBVen.RealizarConsultaSQL("select Tipo as TipoMetodo, case when isnull(TipoBanco) = 1 then '' else TipoBanco end as TipoBanco, case when isnull(Cuenta) = 1 then '' else Cuenta end as Cuenta from ClientePago where ClienteClave = '" & oTransProdGenerico.ClienteActual.ClienteClave & "' and TipoEstado = 1", "Metodo")
        Dim aGrupo As New ArrayList
        aGrupo.Add("NI")
        Dim aValor As ArrayList = ValorReferencia.RecuperaVARVGrupo("PAGO", aGrupo)
        If aValor.Count > 0 Then
            nTipoNoIdent = CType(aValor(0), ValorReferencia.Descripcion).Id
        End If

        aGrupo.Clear()
        aGrupo.Add("E")
        aEfectivo = ValorReferencia.RecuperaVARVGrupo("PAGO", aGrupo)
        For Each oValor As ValorReferencia.Descripcion In ValorReferencia.RecuperaVARVGrupo("PAGO", aGrupo)
            aEfectivo.Add(oValor.Id)
        Next

        If dtMetodosConfig.Rows.Count > 0 Then
            ConfiguraListaMetodos(dtMetodosConfig, oComponentes("ListViewMetodosPago"))
            bMetodoConfig = True
        Else
            ConfiguraGridMetodos(oComponentes("grdMetodoPago"))
            CrearNuevaFila(oComponentes("grdMetodoPago"))
            bMetodoConfig = False
            bCapturaGrid = True
        End If
    End Sub


    Private Sub ConfiguraGridMetodos(ByRef grMetodos As C1.Win.C1FlexGrid.C1FlexGrid)
        With grMetodos
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 3

            Dim htValoresMetodo As New Hashtable
            Dim htValoresBanco As New Hashtable
            Dim aValores As ArrayList

            'TipoMetodo
            .Cols(0).Name = "TipoMetodo"
            .Cols("TipoMetodo").Width = 110
            aValores = ValorReferencia.RecuperarLista("PAGO")
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    If refDesc.Id <> 0 Then
                        htValoresMetodo.Add(refDesc.Id, refDesc.Cadena)
                    End If
                Next
                .Cols("TipoMetodo").DataMap = htValoresMetodo
            End If
            aValores = Nothing
            .Cols("TipoMetodo").Caption = refaVista.BuscarMensaje("MsgBox", "TDFMetodoPago")

            'NumCtaBanco
            .Cols(1).Name = "Cuenta"
            .Cols("Cuenta").Width = 110
            .Cols("Cuenta").Caption = refaVista.BuscarMensaje("MsgBox", "TDFNumerosCuenta")

            'Banco
            .Cols(2).Name = "TipoBanco"
            .Cols("TipoBanco").Width = 110
            aValores = ValorReferencia.RecuperarLista("TBANCO")
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    If refDesc.Id <> 0 Then
                        htValoresBanco.Add(refDesc.Id, refDesc.Cadena)
                    End If
                Next
                .Cols("TipoBanco").DataMap = htValoresBanco
            End If
            aValores = Nothing
            .Cols("TipoBanco").Caption = refaVista.BuscarMensaje("MsgBox", "XBanco")

            .Rows.Count = 1
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Redraw = True

            .BringToFront()
        End With
    End Sub

    Private Sub ConfiguraListaMetodos(ByVal dtMetodosConfig As DataTable, ByRef oListView As ListView)
        Dim dtMetodos As New DataTable("MetodoPago")
        Dim aPago As ArrayList
        aPago = ValorReferencia.RecuperarLista("PAGO")

        Dim aBanco As ArrayList
        aBanco = ValorReferencia.RecuperarLista("TBANCO")
        'Dim aValorBanco As ValorReferencia.Descripcion

        dtMetodos.Columns.Add("TipoMetodo", System.Type.GetType("System.String"))
        dtMetodos.Columns.Add("Cuenta", System.Type.GetType("System.String"))
        dtMetodos.Columns.Add("TipoBanco", System.Type.GetType("System.String"))


        Dim drMetodos() As DataRow
        Dim bTieneNI As Boolean
        Dim drMetodo As DataRow
        For Each aValor As ValorReferencia.Descripcion In aPago

            drMetodos = dtMetodosConfig.Select("TipoMetodo = '" & aValor.Id & "'")
            If drMetodos.Length > 0 Then
                bTieneNI = False
                For Each drMet As DataRow In drMetodos
                    drMetodo = dtMetodos.NewRow
                    drMetodo("TipoMetodo") = aValor.Cadena
                    If drMet("Cuenta").ToString.Trim <> "" Then
                        drMetodo("Cuenta") = drMet("Cuenta").ToString.Trim
                        If drMet("Cuenta").ToString.Trim.ToUpper = gVista.BuscarMensaje("MsgBoxGeneral", "XNoIdentificado").Trim.ToUpper Then
                            bTieneNI = True
                        End If
                    ElseIf (Not aEfectivo.Contains(aValor.Id) And aValor.Id <> nTipoNoIdent) Then
                        drMetodo("Cuenta") = gVista.BuscarMensaje("MsgBoxGeneral", "XNoIdentificado").Trim
                        bTieneNI = True
                    Else
                        drMetodo("Cuenta") = ""
                    End If

                    If drMet("TipoBanco").ToString <> "0" And drMet("TipoBanco").ToString <> "" Then
                        drMetodo("TipoBanco") = ValorReferencia.BuscarEquivalente("TBANCO", drMet("TipoBanco"))
                    Else
                        drMetodo("TipoBanco") = ""
                    End If
                    dtMetodos.Rows.Add(drMetodo)
                Next
                If Not bTieneNI And Not aEfectivo.Contains(aValor.Id) And aValor.Id <> nTipoNoIdent Then
                    drMetodo = dtMetodos.NewRow
                    drMetodo("TipoMetodo") = aValor.Cadena
                    drMetodo("Cuenta") = gVista.BuscarMensaje("MsgBoxGeneral", "XNoIdentificado").Trim
                    drMetodo("TipoBanco") = ""
                    dtMetodos.Rows.Add(drMetodo)
                End If

            ElseIf (Not aEfectivo.Contains(aValor.Id) And aValor.Id <> nTipoNoIdent) Then
                drMetodo = dtMetodos.NewRow
                drMetodo("TipoMetodo") = aValor.Cadena
                drMetodo("Cuenta") = gVista.BuscarMensaje("MsgBoxGeneral", "XNoIdentificado").Trim
                drMetodo("TipoBanco") = ""
                dtMetodos.Rows.Add(drMetodo)
            Else
                drMetodo = dtMetodos.NewRow
                drMetodo("TipoMetodo") = aValor.Cadena
                drMetodo("Cuenta") = ""
                drMetodo("TipoBanco") = ""
                dtMetodos.Rows.Add(drMetodo)
            End If
        Next


        Me.refaVista.CrearListView(oListView, "ListViewMetodosPagoConfig")
        Me.refaVista.LlenarListViewConsultaSQL(oListView, dtMetodos)
        oListView.Visible = True
        oListView.CheckBoxes = True
        oListView.BringToFront()
    End Sub

    Private Sub CrearNuevaFila(ByRef grMetodo As C1.Win.C1FlexGrid.C1FlexGrid)
        grMetodo.Rows.Count = grMetodo.Rows.Count + 1
        grMetodo.Row = grMetodo.Rows.Count - 1
        grMetodo.Col = 0
    End Sub

    Private Function ValidarMetodoCapturado(ByVal grMetodo As C1.Win.C1FlexGrid.C1FlexGrid) As Boolean
        For nRow As Integer = 1 To grMetodo.Rows.Count - 1
            If Not (IsNothing(grMetodo.GetData(nRow, 0)) OrElse grMetodo.GetData(nRow, 0).ToString = "") Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function ValidarNumeroCuenta(ByVal grMetodo As C1.Win.C1FlexGrid.C1FlexGrid) As Boolean
        For nRow As Integer = 1 To grMetodo.Rows.Count - 1
            If Not (IsNothing(grMetodo.GetData(nRow, "TipoMetodo")) OrElse grMetodo.GetData(nRow, "TipoMetodo").ToString = "") Then
                If Not aEfectivo.Contains(grMetodo.GetData(nRow, "TipoMetodo")) And grMetodo.GetData(nRow, "TipoMetodo") <> nTipoNoIdent Then
                    If grMetodo.GetData(nRow, "Cuenta") Is Nothing OrElse grMetodo.GetData(nRow, "Cuenta").ToString.Trim = "" Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", grMetodo.Cols("Cuenta").Caption))
                        Return False
                    End If
                End If
            End If
        Next
        Return True
    End Function

    Private Sub ObtenerMetodosPago(ByRef sMetodoPago As String, ByRef sBanco As String, ByRef sNumCuenta As String, ByRef sMetodoFin As String, ByRef sCuentaFin As String, ByVal aControles As Generic.Dictionary(Of String, Control))

        If bMetodoConfig Then
            Dim listaMetodos As ListView = aControles("ListViewMetodosPago")
            For i As Integer = 0 To listaMetodos.Items.Count - 1
                If listaMetodos.Items(i).Checked Then
                    sMetodoPago += CType(listaMetodos.Items(i).Text, String) & ","

                    If CType(listaMetodos.Items(i).SubItems(1).Text, String) <> "" Then
                        sNumCuenta += CType(listaMetodos.Items(i).SubItems(1).Text, String) & ","
                    Else
                        sNumCuenta += "*,"
                    End If

                    If CType(listaMetodos.Items(i).SubItems(2).Text, String) <> "" Then
                        sBanco += CType(listaMetodos.Items(i).SubItems(2).Text, String) & ","
                    Else
                        sBanco += "*,"
                    End If
                End If
            Next
        Else
            Dim grid As C1.Win.C1FlexGrid.C1FlexGrid = aControles("grdMetodoPago")
            For nRow As Integer = 1 To grid.Rows.Count - 1
                If Not (IsNothing(grid.GetData(nRow, 0)) OrElse grid.GetData(nRow, 0).ToString = "") Then
                    sMetodoPago += grid.GetDataDisplay(nRow, 0) & ","

                    If Not (IsNothing(grid.GetData(nRow, 1)) OrElse grid.GetData(nRow, 1).ToString = "") Then
                        sNumCuenta += grid.GetDataDisplay(nRow, 1) & ","
                    Else
                        sNumCuenta += "*,"
                    End If

                    If Not (IsNothing(grid.GetData(nRow, 2)) OrElse grid.GetData(nRow, 2).ToString = "") Then
                        sBanco += grid.GetDataDisplay(nRow, 2) & ","
                    Else
                        sBanco += "*,"
                    End If
                End If
            Next
        End If

        If sMetodoPago <> "" Then sMetodoPago = sMetodoPago.Remove(sMetodoPago.Length - 1, 1)
        If sBanco <> "" Then sBanco = sBanco.Remove(sBanco.Length - 1, 1)
        If sNumCuenta <> "" Then sNumCuenta = sNumCuenta.Remove(sNumCuenta.Length - 1, 1)

        FormatoMetodoPago(sMetodoPago, sBanco, sNumCuenta, sMetodoFin, sCuentaFin)
    End Sub

    Private Sub grdMetodoPago_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grdMetodoPago.AfterEdit
        Try
            If e.Row <= 0 Then Exit Sub
            Dim grid As C1.Win.C1FlexGrid.C1FlexGrid = sender
            If e.Col = 0 Then
                If Not IsNothing(grid.GetData(e.Row, "TipoMetodo")) AndAlso grid.GetData(e.Row, "TipoMetodo") <> "" Then
                    If aEfectivo.Contains(grid.GetData(e.Row, "TipoMetodo")) Or grid.GetData(e.Row, "TipoMetodo") = nTipoNoIdent Then
                        'If (aEfectivo.Contains(grid.GetData(e.Row, "TipoMetodo")) And bEfectivoSel) Or (grid.GetData(e.Row, "TipoMetodo") = nTipoNoIdent And bNoIdentificadoSel) Then
                        '    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0002"))
                        '    grid.SetData(e.Row, e.Col, Nothing)
                        '    e.Cancel = True
                        '    Exit Sub
                        'End If
                        grid.SetData(e.Row, grid.Cols("Cuenta").Index, "")
                        grid.SetData(e.Row, grid.Cols("TipoBanco").Index, "")

                        If Not ((IsDBNull(grid.GetData(e.Row, "TipoMetodo")) OrElse grid.GetData(e.Row, "TipoMetodo") = "") AndAlso (IsDBNull(grid.GetData(e.Row, "Cuenta")) OrElse grid.GetData(e.Row, "Cuenta") = "") AndAlso (IsDBNull(grid.GetData(e.Row, "TipoBanco")) OrElse grid.GetData(e.Row, "TipoBanco") = "")) Then
                            For Each renglon As C1.Win.C1FlexGrid.Row In grid.Rows
                                If ((IsDBNull(grid.GetData(renglon.Index, "TipoMetodo")) OrElse grid.GetData(renglon.Index, "TipoMetodo") = "") AndAlso (IsDBNull(grid.GetData(renglon.Index, "Cuenta")) OrElse grid.GetData(renglon.Index, "Cuenta") = "") AndAlso (IsDBNull(grid.GetData(renglon.Index, "TipoBanco")) OrElse grid.GetData(renglon.Index, "TipoBanco") = "")) Then Continue For
                                If renglon.Index <> e.Row AndAlso IIf(IsDBNull(grid.GetData(renglon.Index, "TipoMetodo")), "", grid.GetData(renglon.Index, "TipoMetodo")) = IIf(IsDBNull(grid.GetData(e.Row, "TipoMetodo")), "", grid.GetData(e.Row, "TipoMetodo")) AndAlso IIf(IsDBNull(grid.GetData(renglon.Index, "Cuenta")), "", grid.GetData(renglon.Index, "Cuenta")) = IIf(IsDBNull(grid.GetData(e.Row, "Cuenta")), "", grid.GetData(e.Row, "Cuenta")) AndAlso IIf(IsDBNull(grid.GetData(renglon.Index, "TipoBanco")), "", grid.GetData(renglon.Index, "TipoBanco")) = IIf(IsDBNull(grid.GetData(e.Row, "TipoBanco")), "", grid.GetData(e.Row, "TipoBanco")) Then
                                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0002"))
                                    grid.SetData(e.Row, grid.Cols("TipoMetodo").Index, "")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            Next
                        End If

                        If e.Row = grid.Rows.Count - 1 Then
                            CrearNuevaFila(grid)
                        End If
                    End If
                End If
            ElseIf e.Col = 1 Then
                'Validar que en el numero de cuenta solo puedan capturar numeros o no identificado
                If Not IsNothing(grid.GetData(e.Row, "Cuenta")) AndAlso grid.GetData(e.Row, "Cuenta") <> "" Then
                    Dim sCuenta As String = grid.GetData(e.Row, "Cuenta")
                    If Not (EsNumerico(sCuenta) Or sCuenta.ToUpper.Trim = "NO IDENTIFICADO") Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0884"), MsgBoxStyle.Information)
                        grid.SetData(e.Row, e.Col, "")
                        e.Cancel = True
                    ElseIf sCuenta.ToUpper.Trim <> "" Then
                        If Not ((IsDBNull(grid.GetData(e.Row, "TipoMetodo")) OrElse grid.GetData(e.Row, "TipoMetodo") = "") AndAlso (IsDBNull(grid.GetData(e.Row, "Cuenta")) OrElse grid.GetData(e.Row, "Cuenta") = "") AndAlso (IsDBNull(grid.GetData(e.Row, "TipoBanco")) OrElse grid.GetData(e.Row, "TipoBanco") = "")) Then
                            For Each renglon As C1.Win.C1FlexGrid.Row In grid.Rows
                                If ((IsDBNull(grid.GetData(renglon.Index, "TipoMetodo")) OrElse grid.GetData(renglon.Index, "TipoMetodo") = "") AndAlso (IsDBNull(grid.GetData(renglon.Index, "Cuenta")) OrElse grid.GetData(renglon.Index, "Cuenta") = "") AndAlso (IsDBNull(grid.GetData(renglon.Index, "TipoBanco")) OrElse grid.GetData(renglon.Index, "TipoBanco") = "")) Then Continue For
                                If renglon.Index <> e.Row AndAlso IIf(IsDBNull(grid.GetData(renglon.Index, "TipoMetodo")), "", grid.GetData(renglon.Index, "TipoMetodo")) = IIf(IsDBNull(grid.GetData(e.Row, "TipoMetodo")), "", grid.GetData(e.Row, "TipoMetodo")) AndAlso IIf(IsDBNull(grid.GetData(renglon.Index, "Cuenta")), "", grid.GetData(renglon.Index, "Cuenta")) = IIf(IsDBNull(grid.GetData(e.Row, "Cuenta")), "", grid.GetData(e.Row, "Cuenta")) AndAlso IIf(IsDBNull(grid.GetData(renglon.Index, "TipoBanco")), "", grid.GetData(renglon.Index, "TipoBanco")) = IIf(IsDBNull(grid.GetData(e.Row, "TipoBanco")), "", grid.GetData(e.Row, "TipoBanco")) Then
                                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0002"))
                                    grid.SetData(e.Row, grid.Cols("Cuenta").Index, "")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            Next
                        End If

                        If e.Row = grid.Rows.Count - 1 Then
                            CrearNuevaFila(grid)
                        End If
                    End If
                End If
            ElseIf e.Col = 2 Then
                'nRowActualizar = e.Row
                If Not ((IsDBNull(grid.GetData(e.Row, "TipoMetodo")) OrElse grid.GetData(e.Row, "TipoMetodo") = "") AndAlso (IsDBNull(grid.GetData(e.Row, "Cuenta")) OrElse grid.GetData(e.Row, "Cuenta") = "") AndAlso (IsDBNull(grid.GetData(e.Row, "TipoBanco")) OrElse grid.GetData(e.Row, "TipoBanco") = "")) Then
                    For Each renglon As C1.Win.C1FlexGrid.Row In grid.Rows
                        If ((IsDBNull(grid.GetData(renglon.Index, "TipoMetodo")) OrElse grid.GetData(renglon.Index, "TipoMetodo") = "") AndAlso (IsDBNull(grid.GetData(renglon.Index, "Cuenta")) OrElse grid.GetData(renglon.Index, "Cuenta") = "") AndAlso (IsDBNull(grid.GetData(renglon.Index, "TipoBanco")) OrElse grid.GetData(renglon.Index, "TipoBanco") = "")) Then Continue For
                        If renglon.Index <> e.Row AndAlso IIf(IsDBNull(grid.GetData(renglon.Index, "TipoMetodo")), "", grid.GetData(renglon.Index, "TipoMetodo")) = IIf(IsDBNull(grid.GetData(e.Row, "TipoMetodo")), "", grid.GetData(e.Row, "TipoMetodo")) AndAlso IIf(IsDBNull(grid.GetData(renglon.Index, "Cuenta")), "", grid.GetData(renglon.Index, "Cuenta")) = IIf(IsDBNull(grid.GetData(e.Row, "Cuenta")), "", grid.GetData(e.Row, "Cuenta")) AndAlso IIf(IsDBNull(grid.GetData(renglon.Index, "TipoBanco")), "", grid.GetData(renglon.Index, "TipoBanco")) = IIf(IsDBNull(grid.GetData(e.Row, "TipoBanco")), "", grid.GetData(e.Row, "TipoBanco")) Then
                            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0002"))
                            grid.SetData(e.Row, grid.Cols("TipoBanco").Index, "")
                            e.Cancel = True
                            Exit Sub
                        End If
                    Next
                End If

                If e.Row = grid.Rows.Count - 1 Then
                    CrearNuevaFila(grid)
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub grdMetodoPago_BeforeEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grdMetodoPago.BeforeEdit
        If Not bCapturaGrid Then Exit Sub
        Dim grid As C1.Win.C1FlexGrid.C1FlexGrid = sender
        Dim iCol As Integer = grid.Col
        Dim iRow As Integer = grid.Row

        If iCol = 1 Or iCol = 2 Then
            If IsNothing(grid.Item(iRow, "TipoMetodo")) OrElse grid.GetData(e.Row, "TipoMetodo") = "" Then
                e.Cancel = True
                Exit Sub
            End If
            If aEfectivo.Contains(grid.GetData(iRow, "TipoMetodo")) Or grid.GetData(iRow, "TipoMetodo") = nTipoNoIdent Then
                e.Cancel = True
                Exit Sub
            End If

            If iCol = 2 Then
                If IsNothing(grid.Item(iRow, "Cuenta")) OrElse grid.GetData(e.Row, "Cuenta") = "" Then
                    e.Cancel = True
                    Exit Sub
                End If
                If grid.GetData(iRow, "Cuenta").ToString = "" Or grid.GetData(iRow, "Cuenta").ToString.ToUpper = "NO IDENTIFICADO" Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub grdMetodoPago_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMetodoPago.EnterCell
        Dim grid As C1.Win.C1FlexGrid.C1FlexGrid = sender
        If grid.Cols(0).Name <> "TipoMetodo" Or grid.Row <= 0 Then Exit Sub

        'Dim iCol As Integer = grid.Col
        'Dim iRow As Integer = grid.Row
        'If iCol = 0 Then
        '    If Not IsNothing(grid.Item(iRow, "TipoMetodo")) AndAlso grid.Item(iRow, "TipoMetodo") <> "" Then
        '        If (aEfectivo.Contains(grid.Item(iRow, "TipoMetodo"))) Then bEfectivoSel = False
        '        If (grid.Item(iRow, "TipoMetodo") = nTipoNoIdent) Then bNoIdentificadoSel = False
        '    End If
        'End If
    End Sub


    Private Sub EliminarMetodo(ByRef grid As C1.Win.C1FlexGrid.C1FlexGrid)
        Try
            Dim idxFila As Integer

            'Efectivo
            If grid.Row > 0 Then
                idxFila = grid.Row
                grid.Col = 0
                grid.Rows.Remove(idxFila)

            End If

            If grid.Rows.Count <= 1 Then
                CrearNuevaFila(grid)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FormatoMetodoPago(ByVal sMetodo As String, ByVal sBanco As String, ByVal sCuenta As String, ByRef sMetodoSal As String, ByRef sCuentaSal As String)
        Dim sMetodos As String() = sMetodo.Split(",")
        Dim sBancos As String() = sBanco.Split(",")
        Dim sCuentas As String() = sCuenta.Split(",")

        sMetodoSal = ""
        sCuentaSal = ""
        Dim i As Integer
        For i = 0 To sMetodos.Length - 1
            sMetodoSal += sMetodos(i) + IIf(sBancos(i) = "*", ",", " " + sBancos(i) + ",")
            sCuentaSal += IIf(sCuentas(i) = "*", "", sCuentas(i) + ",")
        Next

        If sMetodoSal.Length > 0 Then
            If sMetodoSal.EndsWith(",") Then
                sMetodoSal = sMetodoSal.Remove(sMetodoSal.Length - 1, 1)
            End If
        End If

        If sCuentaSal.Length > 0 Then
            If sCuentaSal.EndsWith(",") Then
                sCuentaSal = sCuentaSal.Remove(sCuentaSal.Length - 1, 1)
            End If
        End If
    End Sub

#End Region


    Private Sub btnContinuarFacturas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinuarFacturas.Click

        Try
            Dim iTipoVersion As Integer = CType(SubEmpresa.aSubEmpresa(0), SubEmpresa.DatosEmpresa).VersionCFD
            Dim sVersionCFD As String = ValorReferencia.BuscarEquivalente("VERFACTE", iTipoVersion)
            'Validad TRPDatoFiscal
            For Each oTRP As TransProd In aTransProdFactura.Values
                If oTransProdGenerico.ClienteActual.ExigirOrdenCompra And aControlesFactura(oTRP.MonedaID)("OrdenCompra").Text = String.Empty Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", lbOrdenCompra.Text))
                    Cursor.Current = Cursors.Default
                    TabControlFacturas.SelectedIndex = CType(CType(aControlesFactura(oTRP.MonedaID)("OrdenCompra").Parent, TabPage).Tag, Int16)
                    aControlesFactura(oTRP.MonedaID)("OrdenCompra").Focus()
                    Exit Sub
                End If

                'Valida metodo de pago y numero de cuenta
                Dim bMetodo As Boolean
                If iTipoVersion = 3 Or iTipoVersion = 4 Then
                    If bMetodoConfig Then
                        bMetodo = RevisarElementoMarcado2(aControlesFactura(oTRP.MonedaID)("ListViewMetodosPago"))
                    Else
                        bMetodo = ValidarMetodoCapturado(aControlesFactura(oTRP.MonedaID)("grdMetodoPago"))
                    End If
                    If Not bMetodo Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0867").Replace("$0$", "MetodoPago"))
                        Cursor.Current = Cursors.Default
                        TabControlFacturas.SelectedIndex = CType(CType(aControlesFactura(oTRP.MonedaID)("ListViewMetodosPago").Parent, TabPage).Tag, Int16)
                        aControlesFactura(oTRP.MonedaID)("ListViewMetodosPago").Focus()
                        Exit Sub
                    Else
                        If Not bMetodoConfig Then
                            If Not ValidarNumeroCuenta(aControlesFactura(oTRP.MonedaID)("grdMetodoPago")) Then
                                Cursor.Current = Cursors.Default
                                TabControlFacturas.SelectedIndex = CType(CType(aControlesFactura(oTRP.MonedaID)("grdMetodoPago").Parent, TabPage).Tag, Int16)
                                aControlesFactura(oTRP.MonedaID)("grdMetodoPago").Focus()
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            Next

            'Grabar trpdatofiscal
            For Each oTRP As TransProd In aTransProdFactura.Values

                Dim sMetodoPago As String = ""
                Dim sBanco As String = ""
                Dim sNumCuenta As String = ""

                Dim sMetodoFin As String = ""
                Dim sCuentaFin As String = ""
                ObtenerMetodosPago(sMetodoPago, sBanco, sNumCuenta, sMetodoFin, sCuentaFin, aControlesFactura(oTRP.MonedaID))

                Dim sTransProdId As String = String.Empty
                If aTransProd.Count > 0 Then
                    sTransProdId = aTransProd(oTRP.MonedaID).TransProdId
                Else
                    sTransProdId = oTransProdGenerico.TransProdId
                End If
                'Marcar los numeros de pedimentos que se imprimiran en la factura
                Dim dtPedimentos As DataTable = oDBVen.RealizarConsultaSQL("Select TRPPedimentoID, ProductoClave, CodigoSKU from TRPPedimento where TransProdID ='" & sTransProdId & "' order by ProductoClave, CodigoSKU", "Pedimentos")

                Dim sProductoClave As String = String.Empty
                Dim sCodigoSKU As String = String.Empty
                Dim iContador As Integer = 0

                For Each dr As DataRow In dtPedimentos.Rows
                    If dr("ProductoClave") <> sProductoClave Then
                        iContador = 0
                        sProductoClave = dr("ProductoClave")
                        sCodigoSKU = dr("CodigoSKU")
                    End If
                    If iContador < 2 Then
                        oDBVen.EjecutarComandoSQL("UPDATE TRPPedimento set Facturado = 1, Enviado = 0, MFechaHora = getdate() where TransProdID ='" & sTransProdId & "' and TRPPedimentoID='" & dr("TRPPedimentoID") & "' and ProductoClave ='" & sProductoClave & "' ")
                    End If
                    iContador += 1
                Next
                dtPedimentos.Dispose()

                With aTRPDatoFiscal(oTRP.TransProdId)
                    .TipoVersion = sVersionCFD
                    .MetodoPago = sMetodoPago
                    .Banco = sBanco
                    .NumCtaPago = sNumCuenta
                    .MetodoPagoFinal = sMetodoFin
                    .NumCtaPagoFinal = sCuentaFin
                    Dim sCadenaOriginal As String = .CrearCadenaOriginalM(oTRP, sTransProdId, oTransProdGenerico.ClienteActual.ClienteClave, True)
                    sCadenaOriginal = sCadenaOriginal.Replace("&", amp)
                    sCadenaOriginal = sCadenaOriginal.Replace("<", lt)
                    sCadenaOriginal = sCadenaOriginal.Replace(">", gt)
                    sCadenaOriginal = sCadenaOriginal.Replace("'", apos)
                    sCadenaOriginal = sCadenaOriginal.Replace("""", quot)
                    .CadenaOriginal = sCadenaOriginal
                    .Insertar()
                End With
            Next

            Me.AceptarTransaccion(False)
            If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
            Me.Transaccion = Nothing

            If oTransProdGenerico.Tipo = ServicesCentral.TiposTransProd.Pedido Or oTransProdGenerico.Tipo = ServicesCentral.TiposTransProd.MovSinInvEV Then
                HabilitarBotones(False)
                If oVendedor.motconfiguracion.MensajeImpresion Then
                    If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                        If oTransProdGenerico.Tipo = ServicesCentral.TiposTransProd.Pedido Then
                            Select Case oVendedor.TipoModulo
                                Case ServicesCentral.TiposModulos.Distribucion
                                    'For Each oTRP As TransProd In aTransProd.Values
                                    ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, RegresaArregloFacturas, 8, 0, oTransProdGenerico.ClienteActual, oTransProdGenerico.VisitaActual)
                                    'Next
                            End Select
                        Else
                            For Each oTRP As TransProd In aTransProd.Values
                                ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, oTransProdGenerico.TransProdId, oTransProdGenerico.Tipo, oTransProdGenerico.Tipo, oTransProdGenerico.ClienteActual, oTransProdGenerico.VisitaActual)
                            Next
                        End If
                    End If
                End If
                HabilitarBotones(True)
            End If

        Catch ex As Exception
            If (oDBVen.oConexion.State <> ConnectionState.Closed) Then
                oDBVen.Transaccion.Rollback()
                If Not oDBVen.Transaccion Is Nothing Then oDBVen.Transaccion.Dispose()
                oDBVen.Transaccion = Nothing
                oDBVen.oConexion.Close()
            End If
        End Try

        Me.Close()
    End Sub

    Private Sub MenuItemEliminarMet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemEliminarMet.Click
        EliminarMetodo(CType(CType(sender, MenuItem).Parent, ContextMenu).SourceControl)
    End Sub
    Private Sub GuardarPedimentos(ByVal sTransProdID As String)
        Dim dtPedimentos As DataTable = oDBVen.RealizarConsultaSQL("Select distinct TPP.ProductoClave, TPP.CodigoSKU, TPP.NumPedimento, TPP.Aduana, TPP.FechaIngreso from TransProdDetalle TPD  inner join  TRPPedimento TPP on TPD.ProductoClave = TPP.ProductoClave and (TPD.CodigoSKU = TPP.CodigoSKU OR TPD.CodigoSKU is null) where TPP.Cancelado = 1 and TPD.TransProdID='" & sTransProdID & "'", "Pedimentos")

        Dim sComandoSQL As Text.StringBuilder
        For Each dr As DataRow In dtPedimentos.Rows
            sComandoSQL = New Text.StringBuilder
            sComandoSQL.Append("INSERT INTO TRPPedimento (TransProdID, TRPPedimentoID, ProductoClave, CodigoSKU, NumPedimento, Aduana, FechaIngreso, Facturado, Cancelado, MFechaHora, MUsuarioID, Enviado) VALUES (")
            sComandoSQL.Append("'" & sTransProdID & "',")
            sComandoSQL.Append("'" & oApp.KEYGEN(1) & "',")
            sComandoSQL.Append("'" & dr("ProductoClave") & "',")
            If Not IsDBNull(dr("CodigoSKU")) AndAlso Not IsDBNull(dr("CodigoSKU")) Then
                sComandoSQL.Append("'" & dr("CodigoSKU") & "',")
            Else
                sComandoSQL.Append("null,")
            End If
            sComandoSQL.Append("'" & dr("NumPedimento") & "',")
            sComandoSQL.Append("'" & dr("Aduana") & "',")
            sComandoSQL.Append(UniFechaSQL(dr("FechaIngreso")) & ",")
            sComandoSQL.Append("0,0,")
            sComandoSQL.Append(UniFechaSQL(Now) & ",")
            sComandoSQL.Append("'" & oVendedor.UsuarioId & "', 0)")

            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
        Next
        dtPedimentos.Dispose()
        sComandoSQL = New Text.StringBuilder
    End Sub

End Class
