Imports System.Data.SqlServerCe
Public Class FormCambioProductos

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCambioProductos))
        Me.ContextMenuModificarSal = New System.Windows.Forms.ContextMenu
        Me.MenuItemModificarSal = New System.Windows.Forms.MenuItem
        Me.MenuItemEliminarSal = New System.Windows.Forms.MenuItem
        Me.MainMenuPagos = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.ContextMenuModificarEnt = New System.Windows.Forms.ContextMenu
        Me.MenuItemModificarEnt = New System.Windows.Forms.MenuItem
        Me.MenuItemEliminarEnt = New System.Windows.Forms.MenuItem
        Me.PanelDetalle = New System.Windows.Forms.Panel
        Me.TabControlCambios = New System.Windows.Forms.TabControl
        Me.TabPageProducto = New System.Windows.Forms.TabPage
        Me.TextBoxTotalP = New System.Windows.Forms.TextBox
        Me.LabelTotalProducto = New System.Windows.Forms.Label
        Me.TextBoxCodigoEntrada = New System.Windows.Forms.TextBox
        Me.LabelCodigoEntrada = New System.Windows.Forms.Label
        Me.fgProdEntrada = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ContextMenuRelEnt = New System.Windows.Forms.ContextMenu
        Me.ComboBoxMotivo = New System.Windows.Forms.ComboBox
        Me.LabelMotivo = New System.Windows.Forms.Label
        Me.ButtonBuscarProdEntrada = New System.Windows.Forms.Button
        Me.TextBoxProdEntrada = New System.Windows.Forms.TextBox
        Me.LabelProdEntrada = New System.Windows.Forms.Label
        Me.TextBoxFecha = New System.Windows.Forms.TextBox
        Me.LabelFecha = New System.Windows.Forms.Label
        Me.LabelFolio = New System.Windows.Forms.Label
        Me.TextBoxFolio = New System.Windows.Forms.TextBox
        Me.TabPageCambiarPor = New System.Windows.Forms.TabPage
        Me.TextBoxTotalC = New System.Windows.Forms.TextBox
        Me.LabelTotalCambio = New System.Windows.Forms.Label
        Me.TextBoxCodigoSalida = New System.Windows.Forms.TextBox
        Me.LabelCodigoSalida = New System.Windows.Forms.Label
        Me.fgProdSalida = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ContextMenuRelSal = New System.Windows.Forms.ContextMenu
        Me.ButtonBuscarProdSalida = New System.Windows.Forms.Button
        Me.TextBoxProdSalida = New System.Windows.Forms.TextBox
        Me.LabelProdSalida = New System.Windows.Forms.Label
        Me.ButtonContinuarDet = New System.Windows.Forms.Button
        Me.ButtonRegresarDet = New System.Windows.Forms.Button
        Me.PanelLista = New System.Windows.Forms.Panel
        Me.ButtonEliminar = New System.Windows.Forms.Button
        Me.ListViewCambios = New System.Windows.Forms.ListView
        Me.ButtonContinuarLista = New System.Windows.Forms.Button
        Me.ButtonRegresarLista = New System.Windows.Forms.Button
        Me.lbNombreActividad = New System.Windows.Forms.Label
        Me.PanelDetalle.SuspendLayout()
        Me.TabControlCambios.SuspendLayout()
        Me.TabPageProducto.SuspendLayout()
        Me.TabPageCambiarPor.SuspendLayout()
        Me.PanelLista.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuModificarSal
        '
        Me.ContextMenuModificarSal.MenuItems.Add(Me.MenuItemModificarSal)
        Me.ContextMenuModificarSal.MenuItems.Add(Me.MenuItemEliminarSal)
        '
        'MenuItemModificarSal
        '
        Me.MenuItemModificarSal.Text = "MenuItemModificarSal"
        '
        'MenuItemEliminarSal
        '
        Me.MenuItemEliminarSal.Text = "MenuItemEliminarSal"
        '
        'MainMenuPagos
        '
        Me.MainMenuPagos.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'ContextMenuModificarEnt
        '
        Me.ContextMenuModificarEnt.MenuItems.Add(Me.MenuItemModificarEnt)
        Me.ContextMenuModificarEnt.MenuItems.Add(Me.MenuItemEliminarEnt)
        '
        'MenuItemModificarEnt
        '
        Me.MenuItemModificarEnt.Text = "MenuItemModificarEnt"
        '
        'MenuItemEliminarEnt
        '
        Me.MenuItemEliminarEnt.Text = "MenuItemEliminarEnt"
        '
        'PanelDetalle
        '
        Me.PanelDetalle.Controls.Add(Me.TabControlCambios)
        Me.PanelDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDetalle.Location = New System.Drawing.Point(0, 0)
        Me.PanelDetalle.Name = "PanelDetalle"
        Me.PanelDetalle.Size = New System.Drawing.Size(242, 295)
        '
        'TabControlCambios
        '
        Me.TabControlCambios.Controls.Add(Me.TabPageProducto)
        Me.TabControlCambios.Controls.Add(Me.TabPageCambiarPor)
        Me.TabControlCambios.Location = New System.Drawing.Point(0, 0)
        Me.TabControlCambios.Name = "TabControlCambios"
        Me.TabControlCambios.SelectedIndex = 0
        Me.TabControlCambios.Size = New System.Drawing.Size(242, 295)
        Me.TabControlCambios.TabIndex = 0
        '
        'TabPageProducto
        '
        Me.TabPageProducto.Controls.Add(Me.TextBoxTotalP)
        Me.TabPageProducto.Controls.Add(Me.LabelTotalProducto)
        Me.TabPageProducto.Controls.Add(Me.TextBoxCodigoEntrada)
        Me.TabPageProducto.Controls.Add(Me.LabelCodigoEntrada)
        Me.TabPageProducto.Controls.Add(Me.fgProdEntrada)
        Me.TabPageProducto.Controls.Add(Me.ComboBoxMotivo)
        Me.TabPageProducto.Controls.Add(Me.LabelMotivo)
        Me.TabPageProducto.Controls.Add(Me.ButtonBuscarProdEntrada)
        Me.TabPageProducto.Controls.Add(Me.TextBoxProdEntrada)
        Me.TabPageProducto.Controls.Add(Me.LabelProdEntrada)
        Me.TabPageProducto.Controls.Add(Me.TextBoxFecha)
        Me.TabPageProducto.Controls.Add(Me.LabelFecha)
        Me.TabPageProducto.Controls.Add(Me.LabelFolio)
        Me.TabPageProducto.Controls.Add(Me.TextBoxFolio)
        Me.TabPageProducto.Location = New System.Drawing.Point(4, 25)
        Me.TabPageProducto.Name = "TabPageProducto"
        Me.TabPageProducto.Size = New System.Drawing.Size(234, 266)
        Me.TabPageProducto.Text = "TabPageProducto"
        '
        'TextBoxTotalP
        '
        Me.TextBoxTotalP.AcceptsReturn = True
        Me.TextBoxTotalP.Enabled = False
        Me.TextBoxTotalP.Location = New System.Drawing.Point(133, 245)
        Me.TextBoxTotalP.Name = "TextBoxTotalP"
        Me.TextBoxTotalP.Size = New System.Drawing.Size(96, 23)
        Me.TextBoxTotalP.TabIndex = 16
        '
        'LabelTotalProducto
        '
        Me.LabelTotalProducto.Location = New System.Drawing.Point(69, 246)
        Me.LabelTotalProducto.Name = "LabelTotalProducto"
        Me.LabelTotalProducto.Size = New System.Drawing.Size(64, 20)
        Me.LabelTotalProducto.Text = "LabelTotalProducto"
        '
        'TextBoxCodigoEntrada
        '
        Me.TextBoxCodigoEntrada.AcceptsReturn = True
        Me.TextBoxCodigoEntrada.Location = New System.Drawing.Point(69, 119)
        Me.TextBoxCodigoEntrada.Name = "TextBoxCodigoEntrada"
        Me.TextBoxCodigoEntrada.Size = New System.Drawing.Size(160, 23)
        Me.TextBoxCodigoEntrada.TabIndex = 6
        '
        'LabelCodigoEntrada
        '
        Me.LabelCodigoEntrada.Location = New System.Drawing.Point(5, 123)
        Me.LabelCodigoEntrada.Name = "LabelCodigoEntrada"
        Me.LabelCodigoEntrada.Size = New System.Drawing.Size(80, 16)
        Me.LabelCodigoEntrada.Text = "LabelCodigoEntrada"
        '
        'fgProdEntrada
        '
        Me.fgProdEntrada.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fgProdEntrada.AllowEditing = False
        Me.fgProdEntrada.AutoSearchDelay = 2
        Me.fgProdEntrada.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fgProdEntrada.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgProdEntrada.ContextMenu = Me.ContextMenuRelEnt
        Me.fgProdEntrada.Font = New System.Drawing.Font("Tahoma", 9.0!, Drawing.FontStyle.Regular)
        Me.fgProdEntrada.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgProdEntrada.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgProdEntrada.Location = New System.Drawing.Point(6, 142)
        Me.fgProdEntrada.Name = "fgProdEntrada"
        Me.fgProdEntrada.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgProdEntrada.Size = New System.Drawing.Size(223, 100)
        Me.fgProdEntrada.StyleInfo = resources.GetString("fgProdEntrada.StyleInfo")
        Me.fgProdEntrada.SupportInfo = "RADvAD8B3QDqAHEBcgBGAaQAegCaAKAA4ACcALAA2wCGAFEBbAB/AO8AsgBTAFAANwAHAV0AigAaAQgBB" & _
            "gG/AAwB"
        Me.fgProdEntrada.TabIndex = 7
        '
        'ContextMenuRelEnt
        '
        '
        'ComboBoxMotivo
        '
        Me.ComboBoxMotivo.Location = New System.Drawing.Point(69, 66)
        Me.ComboBoxMotivo.Name = "ComboBoxMotivo"
        Me.ComboBoxMotivo.Size = New System.Drawing.Size(160, 23)
        Me.ComboBoxMotivo.TabIndex = 3
        '
        'LabelMotivo
        '
        Me.LabelMotivo.Location = New System.Drawing.Point(5, 66)
        Me.LabelMotivo.Name = "LabelMotivo"
        Me.LabelMotivo.Size = New System.Drawing.Size(64, 20)
        Me.LabelMotivo.Text = "LabelMotivo"
        '
        'ButtonBuscarProdEntrada
        '
        Me.ButtonBuscarProdEntrada.Location = New System.Drawing.Point(205, 95)
        Me.ButtonBuscarProdEntrada.Name = "ButtonBuscarProdEntrada"
        Me.ButtonBuscarProdEntrada.Size = New System.Drawing.Size(24, 21)
        Me.ButtonBuscarProdEntrada.TabIndex = 5
        Me.ButtonBuscarProdEntrada.Text = "..."
        '
        'TextBoxProdEntrada
        '
        Me.TextBoxProdEntrada.Location = New System.Drawing.Point(69, 95)
        Me.TextBoxProdEntrada.Name = "TextBoxProdEntrada"
        Me.TextBoxProdEntrada.Size = New System.Drawing.Size(134, 23)
        Me.TextBoxProdEntrada.TabIndex = 4
        '
        'LabelProdEntrada
        '
        Me.LabelProdEntrada.Location = New System.Drawing.Point(5, 95)
        Me.LabelProdEntrada.Name = "LabelProdEntrada"
        Me.LabelProdEntrada.Size = New System.Drawing.Size(64, 20)
        Me.LabelProdEntrada.Text = "LabelProdEntrada"
        '
        'TextBoxFecha
        '
        Me.TextBoxFecha.Enabled = False
        Me.TextBoxFecha.Location = New System.Drawing.Point(69, 42)
        Me.TextBoxFecha.Name = "TextBoxFecha"
        Me.TextBoxFecha.Size = New System.Drawing.Size(160, 23)
        Me.TextBoxFecha.TabIndex = 2
        '
        'LabelFecha
        '
        Me.LabelFecha.Location = New System.Drawing.Point(5, 42)
        Me.LabelFecha.Name = "LabelFecha"
        Me.LabelFecha.Size = New System.Drawing.Size(64, 20)
        Me.LabelFecha.Text = "LabelFecha"
        '
        'LabelFolio
        '
        Me.LabelFolio.Location = New System.Drawing.Point(5, 17)
        Me.LabelFolio.Name = "LabelFolio"
        Me.LabelFolio.Size = New System.Drawing.Size(64, 20)
        Me.LabelFolio.Text = "LabelFolio"
        '
        'TextBoxFolio
        '
        Me.TextBoxFolio.Enabled = False
        Me.TextBoxFolio.Location = New System.Drawing.Point(69, 18)
        Me.TextBoxFolio.Name = "TextBoxFolio"
        Me.TextBoxFolio.Size = New System.Drawing.Size(160, 23)
        Me.TextBoxFolio.TabIndex = 1
        '
        'TabPageCambiarPor
        '
        Me.TabPageCambiarPor.Controls.Add(Me.TextBoxTotalC)
        Me.TabPageCambiarPor.Controls.Add(Me.LabelTotalCambio)
        Me.TabPageCambiarPor.Controls.Add(Me.TextBoxCodigoSalida)
        Me.TabPageCambiarPor.Controls.Add(Me.LabelCodigoSalida)
        Me.TabPageCambiarPor.Controls.Add(Me.fgProdSalida)
        Me.TabPageCambiarPor.Controls.Add(Me.ButtonBuscarProdSalida)
        Me.TabPageCambiarPor.Controls.Add(Me.TextBoxProdSalida)
        Me.TabPageCambiarPor.Controls.Add(Me.LabelProdSalida)
        Me.TabPageCambiarPor.Controls.Add(Me.ButtonContinuarDet)
        Me.TabPageCambiarPor.Controls.Add(Me.ButtonRegresarDet)
        Me.TabPageCambiarPor.Location = New System.Drawing.Point(4, 25)
        Me.TabPageCambiarPor.Name = "TabPageCambiarPor"
        Me.TabPageCambiarPor.Size = New System.Drawing.Size(234, 266)
        Me.TabPageCambiarPor.Text = "TabPageCambiarPor"
        '
        'TextBoxTotalC
        '
        Me.TextBoxTotalC.AcceptsReturn = True
        Me.TextBoxTotalC.Enabled = False
        Me.TextBoxTotalC.Location = New System.Drawing.Point(136, 215)
        Me.TextBoxTotalC.Name = "TextBoxTotalC"
        Me.TextBoxTotalC.Size = New System.Drawing.Size(96, 23)
        Me.TextBoxTotalC.TabIndex = 18
        '
        'LabelTotalCambio
        '
        Me.LabelTotalCambio.Location = New System.Drawing.Point(69, 216)
        Me.LabelTotalCambio.Name = "LabelTotalCambio"
        Me.LabelTotalCambio.Size = New System.Drawing.Size(64, 20)
        Me.LabelTotalCambio.Text = "LabelTotalCambio"
        '
        'TextBoxCodigoSalida
        '
        Me.TextBoxCodigoSalida.AcceptsReturn = True
        Me.TextBoxCodigoSalida.Location = New System.Drawing.Point(90, 42)
        Me.TextBoxCodigoSalida.Name = "TextBoxCodigoSalida"
        Me.TextBoxCodigoSalida.Size = New System.Drawing.Size(144, 23)
        Me.TextBoxCodigoSalida.TabIndex = 3
        '
        'LabelCodigoSalida
        '
        Me.LabelCodigoSalida.Location = New System.Drawing.Point(5, 47)
        Me.LabelCodigoSalida.Name = "LabelCodigoSalida"
        Me.LabelCodigoSalida.Size = New System.Drawing.Size(80, 16)
        Me.LabelCodigoSalida.Text = "LabelCodigoSalida"
        '
        'fgProdSalida
        '
        Me.fgProdSalida.AllowEditing = False
        Me.fgProdSalida.AutoSearchDelay = 2
        Me.fgProdSalida.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fgProdSalida.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgProdSalida.ContextMenu = Me.ContextMenuRelSal
        Me.fgProdSalida.Font = New System.Drawing.Font("Tahoma", 9.0!, Drawing.FontStyle.Regular)
        Me.fgProdSalida.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgProdSalida.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgProdSalida.Location = New System.Drawing.Point(6, 66)
        Me.fgProdSalida.Name = "fgProdSalida"
        Me.fgProdSalida.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgProdSalida.Size = New System.Drawing.Size(226, 142)
        Me.fgProdSalida.StyleInfo = resources.GetString("fgProdSalida.StyleInfo")
        Me.fgProdSalida.SupportInfo = "mwDsACUBTgHGAKAB+QBrADcB9ABVAVwBfwCAACAB0ACiAGAB1wC+AEsA8gBaABwBjwAHAbQADQEbAYQAP" & _
            "wA="
        Me.fgProdSalida.TabIndex = 4
        '
        'ContextMenuRelSal
        '
        '
        'ButtonBuscarProdSalida
        '
        Me.ButtonBuscarProdSalida.Location = New System.Drawing.Point(209, 19)
        Me.ButtonBuscarProdSalida.Name = "ButtonBuscarProdSalida"
        Me.ButtonBuscarProdSalida.Size = New System.Drawing.Size(24, 21)
        Me.ButtonBuscarProdSalida.TabIndex = 2
        Me.ButtonBuscarProdSalida.Text = "..."
        '
        'TextBoxProdSalida
        '
        Me.TextBoxProdSalida.Location = New System.Drawing.Point(90, 19)
        Me.TextBoxProdSalida.Name = "TextBoxProdSalida"
        Me.TextBoxProdSalida.Size = New System.Drawing.Size(116, 23)
        Me.TextBoxProdSalida.TabIndex = 1
        '
        'LabelProdSalida
        '
        Me.LabelProdSalida.Location = New System.Drawing.Point(5, 19)
        Me.LabelProdSalida.Name = "LabelProdSalida"
        Me.LabelProdSalida.Size = New System.Drawing.Size(80, 20)
        Me.LabelProdSalida.Text = "LabelProdSalida"
        '
        'ButtonContinuarDet
        '
        Me.ButtonContinuarDet.Location = New System.Drawing.Point(4, 240)
        Me.ButtonContinuarDet.Name = "ButtonContinuarDet"
        Me.ButtonContinuarDet.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarDet.TabIndex = 5
        Me.ButtonContinuarDet.Text = "ButtonContinuarDet"
        '
        'ButtonRegresarDet
        '
        Me.ButtonRegresarDet.Location = New System.Drawing.Point(85, 240)
        Me.ButtonRegresarDet.Name = "ButtonRegresarDet"
        Me.ButtonRegresarDet.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresarDet.TabIndex = 6
        Me.ButtonRegresarDet.Text = "ButtonRegresarDet"
        '
        'PanelLista
        '
        Me.PanelLista.Controls.Add(Me.ButtonEliminar)
        Me.PanelLista.Controls.Add(Me.ListViewCambios)
        Me.PanelLista.Controls.Add(Me.ButtonContinuarLista)
        Me.PanelLista.Controls.Add(Me.ButtonRegresarLista)
        Me.PanelLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelLista.Location = New System.Drawing.Point(0, 0)
        Me.PanelLista.Name = "PanelLista"
        Me.PanelLista.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonEliminar
        '
        Me.ButtonEliminar.Location = New System.Drawing.Point(159, 262)
        Me.ButtonEliminar.Name = "ButtonEliminar"
        Me.ButtonEliminar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonEliminar.TabIndex = 0
        Me.ButtonEliminar.Text = "ButtonEliminar"
        '
        'ListViewCambios
        '
        Me.ListViewCambios.CheckBoxes = True
        Me.ListViewCambios.FullRowSelect = True
        Me.ListViewCambios.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewCambios.Location = New System.Drawing.Point(5, 17)
        Me.ListViewCambios.Name = "ListViewCambios"
        Me.ListViewCambios.Size = New System.Drawing.Size(228, 240)
        Me.ListViewCambios.TabIndex = 1
        Me.ListViewCambios.View = System.Windows.Forms.View.Details
        '
        'ButtonContinuarLista
        '
        Me.ButtonContinuarLista.Location = New System.Drawing.Point(5, 262)
        Me.ButtonContinuarLista.Name = "ButtonContinuarLista"
        Me.ButtonContinuarLista.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarLista.TabIndex = 2
        Me.ButtonContinuarLista.Text = "ButtonContinuarLista"
        '
        'ButtonRegresarLista
        '
        Me.ButtonRegresarLista.Location = New System.Drawing.Point(82, 262)
        Me.ButtonRegresarLista.Name = "ButtonRegresarLista"
        Me.ButtonRegresarLista.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresarLista.TabIndex = 3
        Me.ButtonRegresarLista.Text = "ButtonRegresarLista"
        '
        'lbNombreActividad
        '
        Me.lbNombreActividad.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lbNombreActividad.Location = New System.Drawing.Point(46, 0)
        Me.lbNombreActividad.Name = "lbNombreActividad"
        Me.lbNombreActividad.Size = New System.Drawing.Size(100, 17)
        Me.lbNombreActividad.Text = "Pagos"
        Me.lbNombreActividad.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FormCambioProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbNombreActividad)
        Me.Controls.Add(Me.PanelDetalle)
        Me.Controls.Add(Me.PanelLista)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuPagos
        Me.MinimizeBox = False
        Me.Name = "FormCambioProductos"
        Me.PanelDetalle.ResumeLayout(False)
        Me.TabControlCambios.ResumeLayout(False)
        Me.TabPageProducto.ResumeLayout(False)
        Me.TabPageCambiarPor.ResumeLayout(False)
        Me.PanelLista.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Public Sub New(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        If g_SO = SO.WindowsCE Then
            Call InTheHand.Windows.Forms.ContextMenuHelper.HookAllControls(Me.Controls)
        End If
        'Add any initialization after the InitializeComponent() call
        sVisitaClave = parsVisitaClave
        oModuloMovDetalle = paroModuloMovDetActual
        oCliente = paroCliente

        With ListViewCambios
            .Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
            .Activation = oApp.TipoSeleccion
            .CheckBoxes = True
        End With
        fgProdEntrada.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        fgProdSalida.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
    End Sub

#Region "VARIABLES"
    Private PosTransProdID As Integer = 3
    Private PosPartida As Integer = 0
    Private PosProductoClave As Integer = 1

    Private refaVista As Vista
    Private blnSeleccionManual As Boolean
    Private sVisitaClave As String
    Private sGrupoActual As String
    Private eEstado As TipoEstado
    Private eTipoMovimiento As TipoMovimiento
    'Private oProductoEnt As Producto
    'Private oProductoSal As Producto

    Private sTransProdId As String = ""
    Private oCliente As Cliente
    Private oModuloMovDetalle As Modulos.GrupoModuloMovDetalle
    Private oTransProdEntrada As TransProd
    Private oTransProdSalida As TransProd
    Private oModulo As New Modulos.GrupoModulo
    Private oImpuesto As New Impuesto
    Private bCambioProducto, bHayCambio As Boolean

#If MOD_TERM <> "PALM" Then
    Private WithEvents bScanner As New HANDHELD.CScanner
#End If
    Private oProducto As New Producto

    Private nTotalProducto As Double
    Private nTotalCambios As Double
    Private bLector As Boolean = False

    Dim sMotivoActual As String = String.Empty
#End Region

#Region "PROPIEDADES"
    Public Property Transaccion() As SqlCeTransaction
        Get
            Return oDBVen.Transaccion
        End Get
        Set(ByVal Value As SqlServerCe.SqlCeTransaction)
            oDBVen.Transaccion = Value
        End Set
    End Property
#End Region
#Region "EVENTOS FORMA"
    Private Sub FormCambios_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Not Me.ContextMenuModificarSal Is Nothing Then
            If oVendedor.motconfiguracion.Secuencia Then
                If Not ctrlSeguimiento.Parent Is Nothing Then
                    RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                    RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                    ctrlSeguimiento.QuitarMenuItem(Me.MainMenuPagos)
                    Me.Controls.Remove(ctrlSeguimiento)
                End If
            Else
                If Not Me.lbNombreActividad Is Nothing Then
                    Me.lbNombreActividad.Dispose()
                    Me.lbNombreActividad = Nothing
                End If
            End If
        End If

        If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
        Me.Transaccion = Nothing
    End Sub

    Private Sub FormCambios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        Me.MainMenuPagos.MenuItems(0).Enabled = False
        blnSeleccionManual = True
        [Global].ObtenerFactores(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.AgregarControl(Me)
            Me.PanelLista.SendToBack()
            Me.PanelDetalle.SendToBack()
            ctrlSeguimiento.CrearMenuItem(Me.MainMenuPagos)
            AddHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
            AddHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita

        End If

        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.Iniciar()
            Me.lbNombreActividad.Visible = False
        Else
            Me.lbNombreActividad.Text = sNombreActividad
            Me.lbNombreActividad.BringToFront()
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            lbNombreActividad.Size = New System.Drawing.Size((Me.Width * nFactorW) - 5, 32 * nFactorH)
#End If
        End If

        ListViewCambios.Activation = oApp.TipoSeleccion
        ' Recuperar los demás componentes de la forma
        If Not MobileClient.Vista.Buscar("FormCambios", refaVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        Me.ConfiguraGridfgMovimientos(fgProdEntrada)
        Me.ConfiguraGridfgMovimientos(fgProdSalida)
        refaVista.CrearListView(ListViewCambios, "ListViewCambios")
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        refaVista.ColocarEtiquetasMenuEmergente(Me.ContextMenuModificarEnt)
        refaVista.ColocarEtiquetasMenuEmergente(Me.ContextMenuModificarSal)
        MenuItemEliminarEnt.Text = MenuItemEliminarSal.Text

        'oProductoEnt = New Producto

        'oProductoSal = New Producto

        Me.bCambioProducto = oConHist.Campos("CambioProducto") 'oDBVen.RealizarConsultaSQL("Select CambioProducto From ConHist", "Tabla").Rows(0)(0)
        If Not Me.bCambioProducto Then
            Me.LabelTotalProducto.Visible = False
            Me.TextBoxTotalP.Visible = False
            Me.fgProdEntrada.Height = fgProdEntrada.Height + TextBoxTotalP.Height
            Me.LabelTotalCambio.Visible = False
            Me.TextBoxTotalC.Visible = False
            Me.fgProdSalida.Height = fgProdSalida.Height + TextBoxTotalC.Height + 4
        End If

        If Not LlenaCombos() Then
            Cursor.Current = Cursors.Default
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0759").Replace("$0$", sNombreActividad), MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If
        blnSeleccionManual = False
        eEstado = TipoEstado.Navegando
        'Application.DoEvents()
        Vista()
        If ListViewCambios.Items.Count > 0 Then
            TextBoxFolio.Focus()
        Else
            ContinuarLista()
        End If
        bHayCambio = False
        [Global].HabilitarMenuItem(MainMenuPagos, True)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub TerminarVisita()
        MenuItemRegresar_Click(Nothing, Nothing)
    End Sub

#End Region
#Region "METODOS"
   
    Private Function LlenaCombos() As Boolean
        With ComboBoxMotivo
            Dim aGrupos As New ArrayList
            aGrupos.Add("No Venta")
            aGrupos.Add("Venta")
            Dim aValor As ArrayList = ValorReferencia.RecuperaVARVGrupo("TRPMOT", aGrupos)
            If Not aValor Is Nothing AndAlso aValor.Count > 0 Then
                .DataSource = aValor
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                .SelectedIndex = 0
            End If
        End With

        If Not ComboBoxMotivo.SelectedValue Is Nothing Then
            sMotivoActual = ComboBoxMotivo.SelectedValue
            sGrupoActual = ValorReferencia.RecuperaGrupo("TRPMOT", ComboBoxMotivo.SelectedValue)
            Return True
        End If
        Return False
    End Function

    Private Sub Vista()
        If eEstado = TipoEstado.Navegando Then

            sTransProdId = ""
            PanelLista.Visible = True
            PanelDetalle.Visible = False
            refaVista.PoblarListView(ListViewCambios, oDBVen, "ListViewCambios", " and VisitaClave = '" & sVisitaClave & "' and DiaClave='" & oDia.DiaActual & "' ")
            DesactivarScanner()
            If oVendedor.motconfiguracion.Secuencia Then
                ctrlSeguimiento.Dock = DockStyle.Top
            Else
                Me.lbNombreActividad.Dock = DockStyle.Top
            End If
        Else
            If eEstado = TipoEstado.Creando Then
                Dim iNumFolio As Integer = Folio.ObtenerNumeroDisponibles(, ServicesCentral.TiposModulosMovDet.Cambios)
                If iNumFolio < 2 Then
                    MsgBox(gVista.BuscarMensaje("MsgBoxFolios", "NoHayFolios"), MsgBoxStyle.Exclamation)
                    eEstado = TipoEstado.Navegando
                    Exit Sub
                End If
            End If

            TabControlCambios.SelectedIndex = 0
            PanelLista.Visible = False
            PanelDetalle.Visible = True
            ButtonBuscarProdEntrada.Enabled = True
            ButtonBuscarProdSalida.Enabled = True
            ComboBoxMotivo.Enabled = True
            fgProdEntrada.Enabled = True
            fgProdSalida.Enabled = True
            If [Global].PosicionarControl() Then
                If oVendedor.motconfiguracion.Secuencia Then
                    ctrlSeguimiento.Dock = DockStyle.None
                    ctrlSeguimiento.Size = New System.Drawing.Size((Me.TabControlCambios.Size.Width * nFactorW), ctrlSeguimiento.Size.Height * nFactorH)
                    ctrlSeguimiento.Location = New System.Drawing.Point(1, (Me.PanelDetalle.Location.Y + 25) * nFactorH)
                    ctrlSeguimiento.RefrescaEscribe()
                Else
                    Me.lbNombreActividad.Dock = DockStyle.None
                    Me.lbNombreActividad.Size = New System.Drawing.Size((Me.TabControlCambios.Size.Width * nFactorW), Me.lbNombreActividad.Size.Height * nFactorH)
                    'ctrlSeguimiento.Size = New System.Drawing.Size((Me.TabControlCambios.Size.Width * nFactorW), Me.lbNombreActividad.Size.Height * nFactorH)
                    Me.lbNombreActividad.Location = New System.Drawing.Point(1, (Me.PanelDetalle.Location.Y + 25) * nFactorH)
                End If
            Else
                If oVendedor.motconfiguracion.Secuencia Then
                    ctrlSeguimiento.Dock = DockStyle.Top
                Else
                    Me.lbNombreActividad.Dock = DockStyle.Top
                End If
            End If
        End If
        Application.DoEvents()
        Select Case eEstado
            Case TipoEstado.Creando
                If oDBVen.oConexion.State = ConnectionState.Closed Then
                    oDBVen.oConexion.Open()
                End If
                Transaccion = oDBVen.oConexion.BeginTransaction()
                LimpiarCampos()
                Me.TextBoxFolio.Text = Folio.Obtener(, ServicesCentral.TiposModulosMovDet.Cambios)
                Folio.ObtenerTransProdId(sTransProdId)
                Me.GuardarEncabezado()
                Me.TextBoxFecha.Text = Format(Now, "dd/MM/yyyy")

                PoblarProductosEnt(True)
                PoblarProductosSal(True)
                ActivarScanner()
            Case TipoEstado.Modificando
                If oDBVen.oConexion.State = ConnectionState.Closed Then
                    oDBVen.oConexion.Open()
                End If
                Transaccion = oDBVen.oConexion.BeginTransaction()
                MostrarDetalles()
                ActivarScanner()
            Case TipoEstado.Eliminando
                If oDBVen.oConexion.State = ConnectionState.Closed Then
                    oDBVen.oConexion.Open()
                End If
                Transaccion = oDBVen.oConexion.BeginTransaction()
                MostrarDetalles()
                DesactivarScanner()
                ButtonBuscarProdEntrada.Enabled = False
                ButtonBuscarProdSalida.Enabled = False
                ComboBoxMotivo.Enabled = False
                fgProdEntrada.Enabled = False
                fgProdSalida.Enabled = False
                TextBoxProdEntrada.Enabled = False
                TextBoxProdSalida.Enabled = False
                TextBoxCodigoEntrada.Enabled = False
                TextBoxCodigoSalida.Enabled = False
        End Select
        Application.DoEvents()
    End Sub
    Private Function GuardarEncabezado() As Boolean
        Try
            If eEstado = TipoEstado.Creando Then
                Dim sFolioSalida As String
                Dim sTransProdIDSalida As String = ""

                Folio.Confirmar(, ServicesCentral.TiposModulosMovDet.Cambios)

                System.Threading.Thread.Sleep(1001)
                sFolioSalida = Folio.Obtener(, ServicesCentral.TiposModulosMovDet.Cambios)
                Folio.ObtenerTransProdId(sTransProdIDSalida)

                oTransProdEntrada = New TransProd
                oTransProdEntrada.Reiniciar(True)
                With oTransProdEntrada
                    .ListasPrecios = New ListasPreciosCliente()
                    .ListasPrecios.Recuperar(oCliente, oModuloMovDetalle)
                    .TransProdId = sTransProdId
                    .FacturaId = sTransProdIDSalida
                    .VisitaActual = sVisitaClave
                    .FolioActual = Me.TextBoxFolio.Text
                    .ModuloMovDetalle = oModuloMovDetalle
                    .Tipo = oModuloMovDetalle.TipoTransProd
                    .TipoMovimiento = ServicesCentral.TiposMovimientos.Entrada
                    .TipoFase = ServicesCentral.TiposFasesPedidos.Captura
                    .FechaCaptura = PrimeraHora(Now)
                    .Actualizar()
                End With

                oTransProdSalida = New TransProd
                oTransProdSalida.Reiniciar(True)
                With oTransProdSalida
                    .TransProdId = sTransProdIDSalida
                    .ListasPrecios = New ListasPreciosCliente()
                    .ListasPrecios.Recuperar(oCliente, oModuloMovDetalle)
                    .VisitaActual = sVisitaClave
                    .FolioActual = sFolioSalida
                    .ModuloMovDetalle = oModuloMovDetalle
                    .Tipo = oModuloMovDetalle.TipoTransProd
                    .TipoMovimiento = ServicesCentral.TiposMovimientos.Salida
                    .TipoFase = ServicesCentral.TiposFasesPedidos.Captura
                    .FechaCaptura = PrimeraHora(Now)
                    .Actualizar()
                    Folio.Confirmar(, ServicesCentral.TiposModulosMovDet.Cambios)
                End With
            End If
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": ", MsgBoxStyle.Critical, "AgregarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": ", MsgBoxStyle.Critical, "AgregarProducto")
        End Try
    End Function
    Private Sub MostrarDetalles()

        Dim refListViewItemSel As ListViewItem = ListViewCambios.Items(ListViewCambios.SelectedIndices(0))
        refListViewItemSel.Checked = True

        oTransProdEntrada = New TransProd
        With oTransProdEntrada
            .TransProdId = refListViewItemSel.SubItems(PosTransProdID).Text
            .ModuloMovDetalle = oModuloMovDetalle
            .ListasPrecios = New ListasPreciosCliente()
            .ListasPrecios.Recuperar(oCliente, oModuloMovDetalle)
            .Recuperar()
        End With

        If oTransProdEntrada.FolioActual = "" Then
            If Not Transaccion.Connection Is Nothing Then
                Transaccion.Rollback()
                Transaccion.Dispose()
                Transaccion = Nothing
            End If
            eEstado = TipoEstado.Navegando
            Vista()
            Exit Sub
        End If

        Me.TextBoxFolio.Text = oTransProdEntrada.FolioActual
        Me.TextBoxFecha.Text = Format(oTransProdEntrada.FechaCaptura, "dd/MM/yyyy")
        ComboBoxMotivo.SelectedValue = oTransProdEntrada.TipoMotivo.ToString
        sMotivoActual = ComboBoxMotivo.SelectedValue
        sGrupoActual = ValorReferencia.RecuperaGrupo("TRPMOT", ComboBoxMotivo.SelectedValue)

        oTransProdSalida = New TransProd
        With oTransProdSalida
            .TransProdId = oTransProdEntrada.FacturaId
            .ModuloMovDetalle = oModuloMovDetalle
            .Recuperar()
            .ListasPrecios = New ListasPreciosCliente()
            .ListasPrecios.Recuperar(oCliente, oModuloMovDetalle)
        End With

        PoblarProductosEnt(True)
        PoblarProductosSal(True)
    End Sub

    Private Sub PoblarProductosEnt(Optional ByVal parbPrimeraVez As Boolean = False)
        fgProdEntrada.Rows.Count = 1
        nTotalProducto = 0
        Dim dtEnt As DataTable = oDBVen.RealizarConsultaSQL("SELECT TransProdDetalle.Partida, TransProdDetalle.ProductoClave ,Producto.Nombre, TransProdDetalle.Cantidad,TransProdDetalle.TipoUnidad,TransProdDetalle.Total FROM TransProdDetalle INNER JOIN Producto ON TransProdDetalle.ProductoClave = Producto.ProductoClave WHERE TransProdDetalle.TransProdId='" & oTransProdEntrada.TransProdId & "' ORDER BY  Partida,Producto.ProductoClave", "Tabla")
        Dim sPartida As String = ""
        fgProdEntrada.Redraw = False
        Dim r As C1.Win.C1FlexGrid.Row
        For Each dr As DataRow In dtEnt.Rows
            If sPartida <> dr("Partida").ToString Then
                sPartida = dr("Partida").ToString
                r = fgProdEntrada.Rows.Add
                r.IsNode = True
                r.Node.Level = 0
                With fgProdEntrada
                    .Item(r.Index, 0) = dr("ProductoClave")
                    .Item(r.Index, 1) = dr("Nombre")
                    .Item(r.Index, 2) = dr("Total")
                    .Item(r.Index, 3) = dr("Partida")
                    .Item(r.Index, 4) = dr("ProductoClave")
                End With
            Else
                With fgProdEntrada
                    .Item(r.Index, 2) = Format(CDbl(.Item(r.Index, 2)) + dr("Total"), "#,##0.00")
                End With
            End If
            Dim r2 As C1.Win.C1FlexGrid.Row = fgProdEntrada.Rows.Add
            r2.IsNode = True
            r2.Node.Level = 1
            With fgProdEntrada
                .Item(r2.Index, 0) = ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad"))
                .Item(r2.Index, 1) = dr("Cantidad")
                .Item(r2.Index, 2) = dr("Total")
                .Item(r2.Index, 3) = dr("Partida")
                .Item(r2.Index, 4) = dr("ProductoClave")
            End With
            nTotalProducto += CDbl(dr("Total"))
        Next
        dtEnt.Dispose()
        For i As Integer = 1 To fgProdEntrada.Rows.Count - 1
            fgProdEntrada.Rows(i).Node.Collapsed = True
        Next
        If Me.bCambioProducto Then
            TextBoxTotalP.Text = nTotalProducto.ToString("#,##0.00")
        End If
        fgProdEntrada.Redraw = True
        ' bHayCambio = True
    End Sub
    Private Sub PoblarProductosSal(Optional ByVal parbPrimeraVez As Boolean = False)
        fgProdSalida.Rows.Count = 1
        nTotalCambios = 0
        Dim dtSal As DataTable = oDBVen.RealizarConsultaSQL("SELECT TransProdDetalle.ProductoClave, Producto.Nombre, TransProdDetalle.Partida,TransProdDetalle.Cantidad,TransProdDetalle.TipoUnidad,TransProdDetalle.Total FROM TransProdDetalle INNER JOIN Producto ON TransProdDetalle.ProductoClave = Producto.ProductoClave WHERE TransProdDetalle.TransProdId='" & oTransProdSalida.TransProdId & "' ORDER BY  Partida,Producto.ProductoClave ", "Tabla")
        Dim sPartida As String = ""
        fgProdSalida.Redraw = False
        Dim r As C1.Win.C1FlexGrid.Row
        For Each dr As DataRow In dtSal.Rows
            If sPartida <> dr("Partida").ToString Then
                sPartida = dr("Partida").ToString
                r = fgProdSalida.Rows.Add
                r.IsNode = True
                r.Node.Level = 0
                With fgProdSalida
                    .Item(r.Index, 0) = dr("ProductoClave")
                    .Item(r.Index, 1) = dr("Nombre")
                    .Item(r.Index, 2) = dr("Total")
                    .Item(r.Index, 3) = dr("Partida")
                    .Item(r.Index, 4) = dr("ProductoClave")
                End With
            Else
                With fgProdSalida
                    .Item(r.Index, 2) = Format(CDbl(.Item(r.Index, 2)) + dr("Total"), "#,##0.00")
                End With
            End If
            Dim r2 As C1.Win.C1FlexGrid.Row = fgProdSalida.Rows.Add
            r2.IsNode = True
            r2.Node.Level = 1
            With fgProdSalida
                .Item(r2.Index, 0) = ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad"))
                .Item(r2.Index, 1) = dr("Cantidad")
                .Item(r2.Index, 2) = dr("Total")
                .Item(r2.Index, 3) = dr("Partida")
                .Item(r2.Index, 4) = dr("ProductoClave")
            End With
            nTotalCambios += CDbl(dr("Total"))
        Next
        dtSal.Dispose()
        For i As Integer = 1 To fgProdSalida.Rows.Count - 1
            fgProdSalida.Rows(i).Node.Collapsed = True
        Next
        If Me.bCambioProducto Then
            TextBoxTotalC.Text = nTotalCambios.ToString("#,##0.00")
        End If
        fgProdSalida.Redraw = True
        ' bHayCambio = True
    End Sub

    'Private Sub PrepararMovimiento(Optional ByVal parbBorrarProducto As Boolean = True)
    '    ' Quitar cualquier selección de productos
    '    'If ListViewProdEntrada.Items.Count > 0 Then
    '    '    If ListViewProdEntrada.SelectedIndices.Count <> 0 Then
    '    '        Dim refListViewItem As ListViewItem
    '    '        For Each refListViewItem In ListViewProdEntrada.Items
    '    '            If refListViewItem.Selected Then
    '    '                refListViewItem.Selected = False
    '    '            End If
    '    '        Next
    '    '    End If
    '    'End If

    '    'bEnProceso = False
    'End Sub
    Private Sub AgregarMovimiento()
        Dim iTipoClave, iEspacios As Integer
        iTipoClave = oConHist.Campos("TipoClaveProducto")
        iEspacios = oConHist.Campos("DigitoClaveProd")
        'If MobileClient.Producto.VerificarTipoClaveProducto(iTipoClave, iEspacios) Then
        'Se quitan los espacios porque generaba problemas al no encontrar el producto
        TextBoxProdEntrada.Text = TextBoxProdEntrada.Text.Trim()
        TextBoxProdSalida.Text = TextBoxProdSalida.Text.Trim()
        If iTipoClave = 2 Then
            Dim sProdClave As String = IIf(eTipoMovimiento = TipoMovimiento.Entrada, Me.TextBoxProdEntrada.Text, Me.TextBoxProdSalida.Text)
            If (sProdClave.Length < iEspacios) And (sProdClave.Length > 0) Then
                sProdClave = sProdClave.PadLeft(iEspacios, "0")
                If eTipoMovimiento = TipoMovimiento.Entrada Then
                    Me.TextBoxProdEntrada.Text = sProdClave
                Else
                    Me.TextBoxProdSalida.Text = sProdClave
                End If
            End If
        End If
        'End If
        Dim sProd As String = IIf(eTipoMovimiento = TipoMovimiento.Entrada, Me.TextBoxProdEntrada.Text, Me.TextBoxProdSalida.Text)
        If MobileClient.Producto.ExisteProducto(sProd) Or sProd.Length = 0 Then
            If Me.PedirProductoCantidad(0, eTipoMovimiento, sProd) Then
                If eTipoMovimiento = TipoMovimiento.Entrada Then
                    PoblarProductosEnt(False)
                Else
                    PoblarProductosSal(False)
                End If

            End If
        Else
            MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0005"), MsgBoxStyle.Exclamation)
            If eTipoMovimiento = TipoMovimiento.Entrada Then
                Me.TextBoxProdEntrada.SelectionStart = 0
                Me.TextBoxProdEntrada.SelectionLength = Len(Me.TextBoxProdEntrada.Text)
                Me.TextBoxProdEntrada.Focus()
            Else
                Me.TextBoxProdSalida.SelectionStart = 0
                Me.TextBoxProdSalida.SelectionLength = Len(Me.TextBoxProdSalida.Text)
                Me.TextBoxProdSalida.Focus()
            End If
        End If


    End Sub

    Private Sub ModificarMovimiento(ByVal pariPartida As Integer, Optional ByVal parsProductoClave As String = "")

        If Me.PedirProductoCantidad(pariPartida, eTipoMovimiento, parsProductoClave) Then
            If eTipoMovimiento = TipoMovimiento.Entrada Then
                PoblarProductosEnt(False)
            Else
                PoblarProductosSal(False)
            End If
        End If
    End Sub

    Private Sub PoblarListViewProductos(ByRef refparoFormPedirProducto As FormPedirProducto, ByVal aListaEsquemas As ArrayList)
        With refparoFormPedirProducto
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            .fgProductos.Redraw = False
            If eTipoMovimiento = TipoMovimiento.Entrada Then
                If .FiltroProductos <> "" Then
                    Dim drProductos() As DataRow
                    drProductos = g_dtProductos.Select(.FiltroProductos)
                    .fgProductos.DataSource = drProductos
                    Dim dtTemp As DataTable
                    dtTemp = g_dtProductos.Clone
                    For Each drInd As DataRow In drProductos
                        dtTemp.ImportRow(drInd)
                    Next
                    .fgProductos.DataSource = dtTemp
                Else
                    .fgProductos.DataSource = g_dtProductos
                End If
            Else
                'If Me.bCambioProducto Then
                '    .fgProductos.DataSource = oDBVen.RealizarConsultaSQL("SELECT DISTINCT Producto.ProductoClave, Producto.Nombre FROM Producto INNER JOIN Inventario ON Producto.ProductoClave = Inventario.ProductoClave  INNER JOIN ProductoEsquema ON Producto.ProductoClave = ProductoEsquema.ProductoClave WHERE AlmacenID='" & oVendedor.AlmacenId & "' and EsquemaID in(" & .EsquemasID & ") AND Disponible-Apartado-NoDisponible-(case  When Producto.venta=0 then Inventario.Contenido  Else 0 END)>0 " & IIf(.FiltroProductosIncluyeTabla = "", "", " AND " & .FiltroProductosIncluyeTabla), "ProdSalida")
                'Else
                .fgProductos.DataSource = oDBVen.RealizarConsultaSQL("SELECT DISTINCT Producto.ProductoClave, Producto.Nombre FROM Producto INNER JOIN Inventario ON Producto.ProductoClave = Inventario.ProductoClave WHERE AlmacenID='" & oVendedor.AlmacenId & "' AND Disponible-Apartado-NoDisponible-(case  When Producto.venta=0 then Inventario.Contenido  Else 0 END)>0 " & IIf(.FiltroProductosIncluyeTabla = "", "", " AND " & .FiltroProductosIncluyeTabla), "ProdSalida")
                'End If
            End If
            ConfiguraGridfgProductos(refparoFormPedirProducto)
            .fgProductos.Redraw = True
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End With
    End Sub
    Private Sub ConfiguraGridfgProductos(ByRef refparoFormPedirProducto As FormPedirProducto)
        With refparoFormPedirProducto.fgProductos
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor
            .Cols.Fixed = 0
            .Cols.Count = 2
            '.Cols(0).Caption = 
            '.Cols(1).Caption = 
            .Cols(0).Width = 100
            .Cols(1).Width = 280
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .AutoResize = True
        End With
    End Sub

    Private Sub ConfiguraGridfgMovimientos(ByVal refparfgMovimientos As C1.Win.C1FlexGrid.C1FlexGrid)
        With refparfgMovimientos
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 5
            .Cols(0).Caption = refaVista.BuscarMensaje("MsgBox", "ProductoClave")
            .Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "Nombre")
            .Cols(2).Caption = refaVista.BuscarMensaje("MsgBox", "Total")
            .Cols(3).Name = "Partida"
            .Cols(3).Visible = False
            .Cols(4).Name = "ProductoClave"
            .Cols(4).Visible = False
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
    Private Function PedirProductoCantidad(ByVal pariPartida As Integer, ByVal partTipoMovimiento As TipoMovimiento, Optional ByVal optparsProductoClave As String = "") As Boolean
        ' Cargar la forma para pedir el producto, cantidad y unidad
        Dim oFormPedirProducto As New FormPedirProducto
        With oFormPedirProducto
            If partTipoMovimiento = TipoMovimiento.Entrada Then
                .TransProdId = oTransProdEntrada.TransProdId
                .FolioActual = oTransProdEntrada.FolioActual
                .TipoMovimiento = oModuloMovDetalle.TipoMovimiento
                Dim oProducto As New Producto
                oProducto.ProductoClave = optparsProductoClave
                .Producto = oProducto
                .ListasPrecios = oTransProdEntrada.ListasPrecios
                'If pariPartida = 0 And Me.TextBoxProdSalida.Text <> "" Then
                '    .EsquemasID = oProductoSal.RecuperarProductoEsquema
                'End If
                .MostrarExistencia = False
            Else
                .TransProdId = oTransProdSalida.TransProdId
                .FolioActual = oTransProdSalida.FolioActual
                .TipoMovimiento = ServicesCentral.TiposMovimientos.Salida
                Dim oProducto As New Producto
                oProducto.ProductoClave = optparsProductoClave
                .Producto = oProducto
                .ListasPrecios = oTransProdSalida.ListasPrecios
                'If pariPartida = 0 And Me.TextBoxProdEntrada.Text <> "" And Me.bCambioProducto Then
                '    .EsquemasID = oProductoEnt.RecuperarProductoEsquema
                'End If
                .MostrarExistencia = True
            End If
            .TipoTransProd = oModuloMovDetalle.TipoTransProd
            .ModuloMovDetalle = oModuloMovDetalle
            .Partida = pariPartida

            'If eEstado = TipoEstado.Modificando And optparsProductoClave <> "" Then
            '    .PermitirCambiarProducto = False
            '    .PermitirConsultarProductos = False
            'End If


            AddHandler .PoblarListaProductos, AddressOf PoblarListViewProductos
            AddHandler .GuardarDetalle, AddressOf GuardarDetalleProductos

            If optparsProductoClave <> "" Then
                .PermitirConsultarProductos = False
            End If
        End With
        If oFormPedirProducto.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If partTipoMovimiento = TipoMovimiento.Entrada Then
                Me.TextBoxProdEntrada.Focus()
            Else
                Me.TextBoxProdSalida.Focus()
            End If
        End If
        Me.TextBoxProdEntrada.Text = String.Empty
        Me.TextBoxProdSalida.Text = String.Empty
        Me.TextBoxCodigoEntrada.Text = String.Empty
        Me.TextBoxCodigoSalida.Text = String.Empty

        With oFormPedirProducto
            RemoveHandler .GuardarDetalle, AddressOf GuardarDetalleProductos
            RemoveHandler .PoblarListaProductos, AddressOf PoblarListViewProductos
            .Dispose()
            '.DetailViewUnidades.Dispose()
            oFormPedirProducto = Nothing
        End With
        Return True
    End Function

    Private Sub GuardarDetalleProductos(ByRef refparoFormPedirProducto As FormPedirProducto)
        Dim sComandoSQL As New System.Text.StringBuilder
        Try
            ' TODO: Verificar si tiene promociones
            ' Determinar el numero de partida
            If refparoFormPedirProducto.Partida = 0 Then
                '    ' Es una nueva partida, obtenerla
                If Not Folio.ObtenerTransProdPartida(refparoFormPedirProducto.TransProdId, refparoFormPedirProducto.Producto.ProductoClave, refparoFormPedirProducto.Partida) Then
                    Exit Try
                End If
            End If
            Dim refProducto As FormPedirProducto.ItemUnidad
            Dim nPrecio As Single = 0
            Dim dCantidad As Decimal
            Dim nImpuesto As Single = 15
            Dim nImpuestoPorcentaje As Single = 15
            'Dim nImpuestoImporte As Decimal = 0
            Dim nSubTotal As Decimal = 0

            Dim dCantidadAnterior As Decimal = 0

            'Validar que exista inventario suficiente en caso de que quieras modificar la cantidad que entro a una menor
            If refparoFormPedirProducto.TipoMovimiento = ServicesCentral.TiposMovimientos.Entrada Then
                Dim dExistencia As Decimal = 0
                Dim sError As String = String.Empty
                Dim dtInventario As DataTable = oDBVen.RealizarConsultaSQL("select distinct Inventario.ProductoClave, inventario.apartado, inventario.disponible, inventario.nodisponible, inventario.contenido from productodetalle inner join inventario on ProductoDetalle.ProductoClave= Inventario.ProductoClave or ProductoDetalle.ProductoDetClave= Inventario.ProductoClave where productodetalle.productoclave= '" & refparoFormPedirProducto.Producto.ProductoClave & "'", "Inventario")
                For Each refProducto In refparoFormPedirProducto.PanelUnidades.Controls
                    With refProducto
                        dCantidad = refProducto.NumericCantidad.DecimalValue
                        dCantidadAnterior = refProducto.ValorAnterior
                        Inventario.ObtenerCantidadAActualizar(refparoFormPedirProducto.TipoMovimiento, dCantidad, dCantidadAnterior)
                        If dCantidad < 0 Then
                            Dim sGrupo As String = ValorReferencia.RecuperaGrupo("TRPMOT", Me.ComboBoxMotivo.SelectedValue)
                            If sGrupo = "Venta" Then
                                If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                                    If Not Inventario.ValidarExistenciaDifNoDiponibleDec(refparoFormPedirProducto.Producto.ProductoClave, .TipoUnidad, Math.Abs(dCantidad), dExistencia, dtInventario, sError) Then
                                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0029"))
                                        Exit Sub
                                    End If
                                Else
                                    If Not Inventario.ValidarExistenciaDisponibleDec(refparoFormPedirProducto.Producto.ProductoClave, .TipoUnidad, Math.Abs(dCantidad), dExistencia, dtInventario, sError) Then
                                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0029"))
                                        Exit Sub
                                    End If
                                End If

                            ElseIf sGrupo = "No Venta" Then
                                If Not Inventario.ValidarExistenciaNoDisponible(refparoFormPedirProducto.Producto.ProductoClave, .TipoUnidad, Math.Abs(dCantidad), dtInventario) Then
                                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0029"))
                                    Exit Sub
                                End If
                            End If
                        End If
                    End With
                Next
                dtInventario.Dispose()
            End If

            ' Obtener los productos a actualizar
            For Each refProducto In refparoFormPedirProducto.PanelUnidades.Controls
                With refProducto
                    sComandoSQL = New System.Text.StringBuilder
                    If IsNumeric(.Text) Then
                        dCantidad = refProducto.NumericCantidad.DecimalValue
                        ' Si la cantidad es cero
                        If dCantidad = 0 Then
                            ' Si ya estaba capturado
                            If .TransProdDetalleID <> "" Then
                                ' Borrarlo
                                sComandoSQL.Append("DELETE FROM TransProdDetalle WHERE TransProdId='" & refparoFormPedirProducto.TransProdId & "' AND TransProdDetalleID='" & .TransProdDetalleID & "'")
                            End If
                        Else
                            '<13-Jun-2006> Comentar
                            ' Buscar el precio del producto asociado
                            If Not refparoFormPedirProducto.ListasPrecios.BuscarPrecio(refparoFormPedirProducto.Producto.ProductoClave, refProducto.TipoUnidad, nPrecio) Then
                                MsgBox(refparoFormPedirProducto.refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistePrecio"), MsgBoxStyle.Information)
                                Exit Try
                            End If

                            nSubTotal = (dCantidad * nPrecio) '* .Factor
                            '<\13-Jun-2006>
                            ' La cantidad es valida, guardarla. Si no estaba capturada
                            If .TransProdDetalleID = "" Then
                                ' Obtener un nuevo folio
                                If Not Folio.ObtenerTransProdDetalleId(refparoFormPedirProducto.TransProdId, .TransProdDetalleID) Then
                                    Exit For
                                End If
                                ' Crear la cadena para insertar el valor
                                sComandoSQL.Append("INSERT INTO TransProdDetalle (TransProdID, TransProdDetalleID, ProductoClave, TipoUnidad, Partida, Cantidad, Precio, Subtotal, Total, Enviado,MFechaHora, MUsuarioID) VALUES (")
                                sComandoSQL.Append("'" & refparoFormPedirProducto.TransProdId & "',")
                                sComandoSQL.Append("'" & .TransProdDetalleID & "',")
                                sComandoSQL.Append("'" & refparoFormPedirProducto.Producto.ProductoClave & "',")
                                sComandoSQL.Append(.TipoUnidad & ",") ' TipoUnidad
                                sComandoSQL.Append(refparoFormPedirProducto.Partida & ",") ' Partida
                                sComandoSQL.Append(dCantidad & ",") ' Cantidad
                                sComandoSQL.Append(nPrecio & ",") ' Precio
                                sComandoSQL.Append((dCantidad * nPrecio) & ",") ' Subtotal
                                sComandoSQL.Append(dCantidad * nPrecio + Me.ObtenerImpuestos(refparoFormPedirProducto.Producto.ProductoClave, .TipoUnidad, nPrecio, dCantidad) & ",0,") ' Total
                                sComandoSQL.Append(UniFechaSQL(Now) & ",")
                                sComandoSQL.Append("'" & oVendedor.UsuarioId & "')")
                            Else
                                ' Actualizar el registro
                                sComandoSQL.Append("UPDATE TransProdDetalle SET ")
                                sComandoSQL.Append("DescuentoClave=NULL,")
                                sComandoSQL.Append("Cantidad=" & dCantidad & ",")
                                sComandoSQL.Append("Precio=" & (nPrecio) & ",")
                                sComandoSQL.Append("Subtotal=" & (dCantidad * nPrecio) & ",")
                                sComandoSQL.Append("Total=" & (dCantidad * nPrecio + Me.ObtenerImpuestos(refparoFormPedirProducto.Producto.ProductoClave, .TipoUnidad, nPrecio, dCantidad)) & ",")
                                sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",")
                                sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 ")
                                sComandoSQL.Append("WHERE TransProdID='" & refparoFormPedirProducto.TransProdId & "' AND TransProdDetalleID='" & .TransProdDetalleID & "'")
                            End If
                        End If
                    End If
                End With
                ' Guardar los productos
                Try
                    If sComandoSQL.ToString <> "" Then
                        oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Information, "GuardarProducto")
                End Try
            Next
            ' Actualizar el inventario
            dCantidadAnterior = 0
            For Each refProducto In refparoFormPedirProducto.PanelUnidades.Controls
                With refProducto
                    dCantidad = refProducto.NumericCantidad.DecimalValue
                    dCantidadAnterior = refProducto.ValorAnterior
                    Inventario.ObtenerCantidadAActualizar(refparoFormPedirProducto.TipoMovimiento, dCantidad, dCantidadAnterior)
                    If refparoFormPedirProducto.TipoMovimiento = ServicesCentral.TiposMovimientos.Entrada Then
                        Dim sGrupo As String = ValorReferencia.RecuperaGrupo("TRPMOT", Me.ComboBoxMotivo.SelectedValue)
                        Inventario.ActualizarInventarioDec(refparoFormPedirProducto.Producto.ProductoClave, .TipoUnidad, dCantidad, oModuloMovDetalle.TipoTransProd, refparoFormPedirProducto.TipoMovimiento, oVendedor.AlmacenId, , sGrupo)
                    Else
                        Inventario.ActualizarInventarioDec(refparoFormPedirProducto.Producto.ProductoClave, .TipoUnidad, dCantidad, oModuloMovDetalle.TipoTransProd, refparoFormPedirProducto.TipoMovimiento, oVendedor.AlmacenId)
                    End If
                End With

                'Crear Saldo de Envases del Cliente
                If oCliente.Prestamo Then
                    ProductoPrestamoCli.ActulizarProductoPrestamoCli(oCliente.ClienteClave, refparoFormPedirProducto.Producto.ProductoClave, dCantidad, refProducto.TipoUnidad, 0, oModuloMovDetalle.TipoTransProd, refparoFormPedirProducto.TipoMovimiento)
                End If

            Next
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarProducto")
        End Try
        sComandoSQL = Nothing
    End Sub
    Private Sub LimpiarCampos()
        sTransProdId = ""
        Me.TextBoxFolio.Text = ""
        Me.TextBoxFecha.Text = ""
        Me.TextBoxProdEntrada.Text = ""
        Me.TextBoxProdEntrada.Tag = ""
        Me.TextBoxProdSalida.Text = ""
        Me.ComboBoxMotivo.SelectedIndex = 0

    End Sub

    Private Function Validar() As Boolean

        If Me.fgProdEntrada.Rows.Count <= 1 Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0506").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "XEntrada")))
            Me.TabControlCambios.SelectedIndex = 0
            Me.TextBoxProdEntrada.Focus()
            Return False
        End If

        If Me.fgProdSalida.Rows.Count <= 1 Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0506").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "XSalida")))
            Me.TextBoxProdSalida.Focus()
            Return False
        End If

        If Me.bCambioProducto Then
            If Math.Round(Me.nTotalProducto, 2) <> Math.Round(Me.nTotalCambios, 2) Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0045"))
                Me.TabControlCambios.SelectedIndex = 0
                Me.TextBoxProdEntrada.Focus()
                Return False
            End If
        End If

        Return True
    End Function
    Private Function Eliminar() As Boolean
        Try
            Dim dtEliminarEntrada As DataTable = oDBVen.RealizarConsultaSQL("Select TransProdDetalle.TransProdID, TransProd.FacturaID,TransProd.TipoMotivo, ProductoClave,TipoUnidad,SUM(Cantidad) as Cantidad from TransProdDetalle  inner join TransProd on TransProdDetalle.TransProdID = TransProd.TransProdID  where TransProdDetalle.TransProdID='" & oTransProdEntrada.TransProdId & "' GROUP BY  TransProdDetalle.TransProdID, TransProd.FacturaID, TransProd.TipoMotivo, ProductoClave,TipoUnidad ", "Eliminar")
            Dim dExistencia As Decimal = 0
            Dim sMsgError As String = String.Empty

            sGrupoActual = ValorReferencia.RecuperaGrupo("TRPMOT", dtEliminarEntrada.Rows(0)("TipoMotivo"))

            For Each dr As DataRow In dtEliminarEntrada.Rows
                If sGrupoActual = "Venta" Then  'Reversa del Caso 3 (Aplico 6)
                    'Aplico Caso 6
                    If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                        If Inventario.ValidarExistenciaDifNoDiponibleDec(dr("productoclave"), dr("tipounidad"), dr("cantidad"), dExistencia, sMsgError) Then
                            Inventario.ActualizarInventarioDec(dr("productoclave"), dr("tipounidad"), dr("cantidad"), ServicesCentral.TiposTransProd.CambioDeProducto, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, , sGrupoActual)
                        Else
                            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0029"), MsgBoxStyle.Information)
                            dtEliminarEntrada.Dispose()
                            Return False
                        End If
                    Else
                        If Inventario.ValidarExistenciaDisponibleDec(dr("productoclave"), dr("tipounidad"), dr("cantidad"), dExistencia, sMsgError) Then
                            Inventario.ActualizarInventarioDec(dr("productoclave"), dr("tipounidad"), dr("cantidad"), ServicesCentral.TiposTransProd.CambioDeProducto, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, , sGrupoActual)
                        Else
                            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0029"), MsgBoxStyle.Information)
                            dtEliminarEntrada.Dispose()
                            Return False
                        End If
                    End If
                    
                ElseIf sGrupoActual = "No Venta" Then 'Reversa del Caso 4 (Aplico 5)
                    'Aplico Caso 5
                    If Inventario.ValidarExistenciaNoDisponible(dr("productoclave"), dr("tipounidad"), dr("cantidad"), dExistencia, sMsgError) Then
                        Inventario.ActualizarInventarioDec(dr("productoclave"), dr("tipounidad"), dr("cantidad"), ServicesCentral.TiposTransProd.CambioDeProducto, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, , sGrupoActual)
                    Else
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0029"), MsgBoxStyle.Information)
                        dtEliminarEntrada.Dispose()
                        Return False
                    End If
                End If

                'Eliminar Saldo de Envases del Cliente
                If oCliente.Prestamo Then
                    ProductoPrestamoCli.ActulizarProductoPrestamoCli(oCliente.ClienteClave, dr("ProductoClave"), -1 * dr("Cantidad"), dr("TipoUnidad"), 0, ServicesCentral.TiposTransProd.CambioDeProducto, TipoMovimiento.Entrada)
                End If
            Next

            dtEliminarEntrada.Dispose()

            Dim dtEliminarSalida As DataTable = oDBVen.RealizarConsultaSQL("Select TransProdDetalle.TransProdID, ProductoClave,TipoUnidad,Cantidad from TransProdDetalle  inner join TransProd on TransProdDetalle.TransProdID = TransProd.TransProdID  where TransProdDetalle.TransProdID='" & oTransProdSalida.TransProdId & "'", "Eliminar")
            For Each dr As DataRow In dtEliminarSalida.Rows
                Inventario.ActualizarInventarioDec(dr("productoclave"), dr("tipounidad"), dr("cantidad"), ServicesCentral.TiposTransProd.CambioDeProducto, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId)

                'Eliminar Saldo de Envases del Cliente
                If oCliente.Prestamo Then
                    ProductoPrestamoCli.ActulizarProductoPrestamoCli(oCliente.ClienteClave, dr("ProductoClave"), -1 * dr("Cantidad"), dr("TipoUnidad"), 0, ServicesCentral.TiposTransProd.CambioDeProducto, TipoMovimiento.Salida)
                End If
            Next
            dtEliminarSalida.Dispose()

            'End If
            oDBVen.EjecutarComandoSQL("DELETE FROM TransProdDetalle where TransProdID='" & oTransProdSalida.TransProdId & "'")
            oDBVen.EjecutarComandoSQL("DELETE FROM TransProd where TransProdID='" & oTransProdSalida.TransProdId & "'")

            oDBVen.EjecutarComandoSQL("DELETE FROM TransProdDetalle where TransProdID='" & oTransProdEntrada.TransProdId & "'")
            oDBVen.EjecutarComandoSQL("DELETE FROM TransProd where TransProdID='" & oTransProdEntrada.TransProdId & "'")
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
        Return False
    End Function

    Private Function CambiarGrupo(ByVal parsGrupoActual As String) As Boolean
        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select ProductoClave,TipoUnidad,Cantidad from TransProdDetalle where TransProdId='" & oTransProdEntrada.TransProdId & "' order by Partida, ProductoClave", "No Venta")
        Dim dtInventario As DataTable = oDBVen.RealizarConsultaSQL("select distinct Inventario.ProductoClave, inventario.apartado, inventario.disponible, inventario.nodisponible, inventario.contenido from productodetalle inner join inventario on ProductoDetalle.ProductoDetClave= Inventario.ProductoClave where productodetalle.productoclave in(select ProductoClave from TransProdDetalle where TransProdId='" & oTransProdEntrada.TransProdId & "') ", "Inventario")
        If parsGrupoActual = "No Venta" Then 'Reversa del Caso 3 (Aplico 6 y luego 4)
            Dim dExistencia As Decimal = 0
            Dim sMsgError As String = String.Empty
            'Validar que se pueda quitar la cantidad de la venta
            For Each Dr As DataRow In Dt.Rows
                If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                    If Not Inventario.ValidarExistenciaDifNoDiponibleDec(Dr("productoclave"), Dr("tipounidad"), Dr("cantidad"), dExistencia, dtInventario, sMsgError) Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0029"), MsgBoxStyle.Information)
                        Return False
                    End If
                Else
                    If Not Inventario.ValidarExistenciaDisponibleDec(Dr("productoclave"), Dr("tipounidad"), Dr("cantidad"), dExistencia, dtInventario, sMsgError) Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0029"), MsgBoxStyle.Information)
                        Return False
                    End If
                End If
                
            Next
            For Each Dr As DataRow In Dt.Rows
                'Aplico Caso 6
                Inventario.ActualizarInventarioDec(Dr("productoclave"), Dr("tipounidad"), Dr("cantidad"), ServicesCentral.TiposTransProd.DevolucionesCliente, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, , "Venta")
                'Aplico Caso 4
                Inventario.ActualizarInventarioDec(Dr("productoclave"), Dr("tipounidad"), Dr("cantidad"), ServicesCentral.TiposTransProd.DevolucionesCliente, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId, , "No Venta")
            Next
        ElseIf parsGrupoActual = "Venta" Then 'Reversa del Caso 4 (Aplico 5 y luego 3)
            'Validar que se pueda quitar la cantidad de la No Venta
            For Each Dr As DataRow In Dt.Rows
                If Not Inventario.ValidarExistenciaNoDisponible(Dr("productoclave"), Dr("tipounidad"), Dr("cantidad"), dtInventario) Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0029"), MsgBoxStyle.Information)
                    Return False
                End If
            Next
            For Each Dr As DataRow In Dt.Rows
                'Aplico Caso 5
                Inventario.ActualizarInventarioDec(Dr("productoclave"), Dr("tipounidad"), Dr("cantidad"), ServicesCentral.TiposTransProd.DevolucionesCliente, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, , "No Venta")
                'Aplico Caso 3
                Inventario.ActualizarInventarioDec(Dr("productoclave"), Dr("tipounidad"), Dr("cantidad"), ServicesCentral.TiposTransProd.DevolucionesCliente, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId, , "Venta")
            Next

        End If
        dtInventario.Dispose()
        Dt.Dispose()
        Return True
    End Function


    Private Sub ContinuarLista()
        Cursor.Current = Cursors.WaitCursor
        If ListViewCambios.SelectedIndices.Count <= 0 Then
            eEstado = TipoEstado.Creando
        Else
            eEstado = TipoEstado.Modificando
        End If
        Vista()
        Cursor.Current = Cursors.Default
    End Sub
#End Region
#Region "Eventos"
    Private Sub ButtonBuscarProdEntrada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProdEntrada.Click
        eTipoMovimiento = TipoMovimiento.Entrada
        Me.AgregarMovimiento()
    End Sub

    Private Sub MenuItemModificarEnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemModificarEnt.Click
        If Me.fgProdEntrada.Rows.Count <= 0 Then Exit Sub
        eTipoMovimiento = TipoMovimiento.Entrada
        Me.ModificarMovimiento(fgProdEntrada.GetData(fgProdEntrada.Row, "Partida"), fgProdEntrada.GetData(fgProdEntrada.Row, "ProductoClave"))
    End Sub

    Private Sub ButtonBuscarProdSalida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProdSalida.Click
        eTipoMovimiento = TipoMovimiento.Salida
        AgregarMovimiento()
    End Sub

    Private Sub MenuItemModificarSal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemModificarSal.Click
        If Me.fgProdSalida.Rows.Count <= 0 Then Exit Sub
        eTipoMovimiento = TipoMovimiento.Salida
        Me.ModificarMovimiento(fgProdSalida.GetData(fgProdSalida.Row, "Partida"), fgProdSalida.GetData(fgProdSalida.Row, "ProductoClave"))
    End Sub

    Private Sub ButtonContinuarLista_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuarLista.Click
        ContinuarLista()
    End Sub

    Private Sub ButtonRegresarLista_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresarLista.Click
        Me.Close()
    End Sub

    Private Sub HabilitarBotones(ByVal bHabilitar As Boolean)
        Me.ButtonBuscarProdSalida.Enabled = bHabilitar
        Me.ButtonContinuarDet.Enabled = bHabilitar
        Me.ButtonRegresarDet.Enabled = bHabilitar
    End Sub

    Private Sub ButtonContinuarDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuarDet.Click
        Try
            If eEstado = TipoEstado.Modificando Or eEstado = TipoEstado.Creando Then
                oTransProdEntrada.TipoMotivo = ComboBoxMotivo.SelectedValue
                sMotivoActual = ComboBoxMotivo.SelectedValue
                oTransProdEntrada.Actualizar()
                If Not Validar() Then
                    Exit Sub
                End If
                HabilitarBotones(False)
                Transaccion.Commit()
                Transaccion.Dispose()
                Transaccion = Nothing
                If oVendedor.motconfiguracion.MensajeImpresion Then
                    While MsgBox(refaVista.BuscarMensaje("MsgBox", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes
                        ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, oTransProdEntrada.TransProdId, ServicesCentral.TiposTransProd.CambioDeProducto, ServicesCentral.TiposTransProd.CambioDeProducto, oCliente, sVisitaClave, False)
                        ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, oTransProdSalida.TransProdId, ServicesCentral.TiposTransProd.CambioDeProducto, ServicesCentral.TiposTransProd.CambioDeProducto, oCliente, sVisitaClave, False)
                    End While
                End If
                HabilitarBotones(True)
            ElseIf eEstado = TipoEstado.Eliminando Then
                If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0001"), MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
                If Not Eliminar() Then
                    Transaccion.Rollback()
                    Transaccion.Dispose()
                    Transaccion = Nothing
                    Me.Close()
                Else
                    Transaccion.Commit()
                    Transaccion.Dispose()
                    Transaccion = Nothing
                End If
            End If

          
            Me.Close()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ButtonRegresarDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresarDet.Click
        If eEstado = TipoEstado.Creando Or eEstado = TipoEstado.Modificando Then
            If bHayCambio Then
                If MsgBox(refaVista.BuscarMensaje("MsgBox", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            
        End If
        Try
            Transaccion.Rollback()
            Transaccion.Dispose()
            Transaccion = Nothing
            'eEstado = TipoEstado.Navegando
            'Vista()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ListViewCambios_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewCambios.ItemCheck
        If blnSeleccionManual Then Exit Sub
        blnSeleccionManual = True
        MarcarElemento(ListViewCambios, e.NewValue, e.Index)
        blnSeleccionManual = False
        If ListViewCambios.SelectedIndices.Count <= 0 Then Exit Sub
        If e.NewValue = CheckState.Unchecked Then
            blnSeleccionManual = True
            ListViewCambios.Items(ListViewCambios.SelectedIndices(0)).Selected = False
            blnSeleccionManual = False
        End If
    End Sub
    Private Sub ListViewCambios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewCambios.SelectedIndexChanged
        If blnSeleccionManual Then Exit Sub
        If ListViewCambios.SelectedIndices.Count <= 0 Then Exit Sub
        blnSeleccionManual = True
        MarcarElemento(ListViewCambios, CheckState.Checked, ListViewCambios.SelectedIndices(0))
        blnSeleccionManual = False
    End Sub
    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        If Not RevisarElementoMarcado(ListViewCambios) Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0046"), MsgBoxStyle.Information)
            Exit Sub
        End If
        eEstado = TipoEstado.Eliminando
        Vista()
    End Sub


    Private Sub MenuItemEliminarEnt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemEliminarEnt.Click
        If Me.fgProdEntrada.Rows.Count <= 0 Then Exit Sub
        If Me.fgProdEntrada.Row <= 0 Then Exit Sub

        Dim r As C1.Win.C1FlexGrid.Row
        r = fgProdEntrada.Rows(fgProdEntrada.Row)
        If r.Node.Level = 0 Then
            If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0001"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If Me.BorrarMovimiento(oTransProdEntrada.TransProdId, fgProdEntrada.GetData(fgProdEntrada.Row, "Partida"), True) Then
                    PoblarProductosEnt(False)
                End If
            End If
        End If
    End Sub

    Private Sub MenuItemEliminarSal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemEliminarSal.Click
        If Me.fgProdSalida.Rows.Count <= 0 Then Exit Sub
        If Me.fgProdSalida.Row <= 0 Then Exit Sub

        Dim r As C1.Win.C1FlexGrid.Row
        r = fgProdSalida.Rows(fgProdSalida.Row)
        If r.Node.Level = 0 Then
            If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0001"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If Me.BorrarMovimiento(oTransProdSalida.TransProdId, fgProdSalida.GetData(fgProdSalida.Row, "Partida"), False) Then
                    PoblarProductosSal(False)
                    
                End If
            End If
        End If
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        If Me.PanelLista.Visible Then
            ButtonRegresarLista_Click(Nothing, Nothing)
        Else
            ButtonRegresarDet_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub ComboBoxMotivo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxMotivo.SelectedValueChanged
        If blnSeleccionManual Then Exit Sub

        Dim GrupoTmp As String = ValorReferencia.RecuperaGrupo("TRPMOT", ComboBoxMotivo.SelectedValue)
        If sGrupoActual <> GrupoTmp Then
            If Not CambiarGrupo(GrupoTmp) Then
                blnSeleccionManual = True
                ComboBoxMotivo.SelectedValue = sMotivoActual
                blnSeleccionManual = False
            Else
                sMotivoActual = ComboBoxMotivo.SelectedValue
                sGrupoActual = GrupoTmp
            End If
        End If
    End Sub
#End Region
#Region "Enum"
    Private Enum TipoEstado
        Navegando = 1
        Creando
        Modificando
        Eliminando
    End Enum

    Private Enum TipoMovimiento
        Entrada = 1
        Salida
    End Enum
#End Region
    Private Function BorrarMovimiento(ByVal parsTransProdID As String, ByVal parsiPartida As Integer, ByVal parbEntrada As Boolean) As Boolean
        Try
            ' Obtener los TransProdDetalleID del numero de partida que se va a borrar
            Dim DataTableIDs As DataTable = oDBVen.RealizarConsultaSQL("SELECT TransProdDetalleID,ProductoClave,TipoUnidad,Cantidad FROM TransProdDetalle WHERE TransProdId='" & parsTransProdID & "' AND Partida=" & parsiPartida, "IDs")
            If DataTableIDs.Rows.Count > 0 Then
                Dim sIds As String = ""
                Dim sProductoClave As String
                Dim dExistencia As Decimal = 0
                Dim sMsgError As String = String.Empty

                'Validar que exista inventario suficiente para hacer el rollback las n unidades que se manejan
                If parbEntrada Then
                    Dim dtInventario As DataTable = oDBVen.RealizarConsultaSQL("select distinct Inventario.ProductoClave, inventario.apartado, inventario.disponible, inventario.nodisponible, inventario.contenido from productodetalle inner join inventario on ProductoDetalle.ProductoDetClave= Inventario.ProductoClave where productodetalle.productoclave= '" & DataTableIDs.Rows(0)("productoclave") & "'", "Inventario")
                    If sGrupoActual = "Venta" Then  'Reversa del Caso 3 (Aplico 6)
                        For Each refDataRow As DataRow In DataTableIDs.Rows
                            dExistencia = 0
                            sMsgError = String.Empty
                            'Aplico Caso 6
                            If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                                If Not Inventario.ValidarExistenciaDifNoDiponibleDec(refDataRow("productoclave"), refDataRow("tipounidad"), refDataRow("cantidad"), dExistencia, dtInventario, sMsgError) Then
                                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0029"), MsgBoxStyle.Information)
                                    DataTableIDs.Dispose()
                                    dtInventario.Dispose()
                                    Return False
                                End If
                            Else
                                If Not Inventario.ValidarExistenciaDisponibleDec(refDataRow("productoclave"), refDataRow("tipounidad"), refDataRow("cantidad"), dExistencia, dtInventario, sMsgError) Then
                                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0029"), MsgBoxStyle.Information)
                                    DataTableIDs.Dispose()
                                    dtInventario.Dispose()
                                    Return False
                                End If
                            End If

                        Next
                        dtInventario.Dispose()
                    ElseIf sGrupoActual = "No Venta" Then 'Reversa del Caso 4 (Aplico 5)
                        For Each refDataRow As DataRow In DataTableIDs.Rows
                            'Aplico Caso 5
                            If Not Inventario.ValidarExistenciaNoDisponible(refDataRow("productoclave"), refDataRow("tipounidad"), refDataRow("cantidad"), dtInventario) Then
                                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0029"), MsgBoxStyle.Information)
                                DataTableIDs.Dispose()
                                dtInventario.Dispose()
                                Return False
                            End If
                        Next
                    End If
                    dtInventario.Dispose()
                End If

                For Each refDataRow As DataRow In DataTableIDs.Rows
                    sProductoClave = refDataRow("ProductoClave")
                    If parbEntrada Then
                        If sGrupoActual = "Venta" Then  'Reversa del Caso 3 (Aplico 6)
                            'Aplico Caso 6
                            Inventario.ActualizarInventarioDec(refDataRow("productoclave"), refDataRow("tipounidad"), refDataRow("cantidad"), ServicesCentral.TiposTransProd.CambioDeProducto, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, , sGrupoActual)
                        ElseIf sGrupoActual = "No Venta" Then 'Reversa del Caso 4 (Aplico 5)
                            'Aplico Caso 5
                            Inventario.ActualizarInventarioDec(refDataRow("productoclave"), refDataRow("tipounidad"), refDataRow("cantidad"), ServicesCentral.TiposTransProd.CambioDeProducto, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, , sGrupoActual)
                        End If

                        'Eliminar Saldo de Envases del Cliente
                        If oCliente.Prestamo Then
                            ProductoPrestamoCli.ActulizarProductoPrestamoCli(oCliente.ClienteClave, refDataRow("ProductoClave"), -1 * refDataRow("Cantidad"), refDataRow("TipoUnidad"), 0, ServicesCentral.TiposTransProd.CambioDeProducto, TipoMovimiento.Entrada)
                        End If
                    Else
                        Inventario.ActualizarInventarioDec(refDataRow("ProductoClave"), refDataRow("TipoUnidad"), refDataRow("Cantidad"), ServicesCentral.TiposTransProd.CambioDeProducto, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId)

                        'Eliminar Saldo de Envases del Cliente
                        If oCliente.Prestamo Then
                            ProductoPrestamoCli.ActulizarProductoPrestamoCli(oCliente.ClienteClave, refDataRow("ProductoClave"), -1 * refDataRow("Cantidad"), refDataRow("TipoUnidad"), 0, ServicesCentral.TiposTransProd.CambioDeProducto, TipoMovimiento.Salida)
                        End If
                    End If

                Next
                DataTableIDs.Dispose()
                Return oDBVen.EjecutarComandoSQL("DELETE FROM TransProdDetalle WHERE TransProdId='" & parsTransProdID & "' AND Partida =" & parsiPartida)
            End If
            DataTableIDs.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "BorrarMovimiento")
        End Try
        Return False
    End Function


    Private Function ObtenerImpuestos(ByVal pvProductoClave As String, ByVal pvTipoUnidad As Integer, ByVal pvPrecio As Decimal, ByVal pvCantidad As Decimal) As Decimal
        Try
            If Not oImpuesto Is Nothing Then
                Dim oArrImpuestos As New ArrayList
                oImpuesto.Buscar(pvProductoClave, oCliente.TipoImpuesto, oArrImpuestos)
                Dim iFactor As Integer = oDBVen.EjecutarCmdScalarIntSQL("select Factor from productodetalle where ProductoClave = '" & pvProductoClave & "' and ProductoDetClave = '" & pvProductoClave & "' and PRUTipoUnidad=" & pvTipoUnidad)
                Return oImpuesto.Calcular(oArrImpuestos, pvPrecio * pvCantidad, pvPrecio)
            Else
                Return 0
            End If
            'Dim sQuery As New System.Text.StringBuilder
            'Dim dSumaImpuestos As Double = 0
            ''Obtengo los impuestos que hay que aplicar
            'sQuery.Append("select distinct impuestoclave,jerarquia from impuesto where impuestoclave in(select impuestoclave from productoimpuesto where productoclave='" & pvProductoClave & "') order by jerarquia")
            'Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery.ToString, "Impuestos")
            'For Each oDr As DataRow In oDt.Rows
            'Next
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function

#Region "Lectura producto"
    Private Sub ActivarScanner()
#If MOD_TERM <> "PALM" Then
        If TextBoxCodigoEntrada.Enabled And TextBoxCodigoSalida.Enabled Then
            If Not bLector Then
                Select Case oApp.ModeloTerminal
                    Case "Generico"

                    Case "SymbolC9090", "SymbolMC50", "SymbolMC70"
                        Try
                            bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolPCMC50)
                            bLector = True
                        Catch ex As Exception
                            MsgBox("Error while starting the scanner:" & ex.Message, MsgBoxStyle.Critical)
                        End Try
                    Case "HHP7600"
                        bScanner.Inicialize_Scanner(HANDHELD.SO.HHP7600)
                        bLector = True
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
        End If
#End If
    End Sub

    Private Sub DesactivarScanner()
#If MOD_TERM <> "PALM" Then
        If bScanner Is Nothing Then Exit Sub
        If TextBoxCodigoEntrada.Enabled And TextBoxCodigoSalida.Enabled Then
            Try
                bScanner.Terminate_Scanner()
                bLector = False
            Catch ex As Exception
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
        DesactivarScanner()
        If Me.TabControlCambios.SelectedIndex = 0 Then 'Entrada
            Me.TextBoxCodigoEntrada.Text = Data
            eTipoMovimiento = TipoMovimiento.Entrada
            BuscarCodigoBarras(eTipoMovimiento)
        ElseIf Me.TabControlCambios.SelectedIndex = 1 AndAlso Me.ButtonBuscarProdSalida.Enabled Then 'Salida
            Me.TextBoxCodigoSalida.Text = Data
            eTipoMovimiento = TipoMovimiento.Salida
            BuscarCodigoBarras(eTipoMovimiento)
        End If
        ActivarScanner()
    End Sub
#End If

    Private Sub TextBoxCodigoEntrada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxCodigoEntrada.KeyPress, TextBoxCodigoSalida.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                e.Handled = True
                If Me.TabControlCambios.SelectedIndex = 0 Then 'Entrada
                    eTipoMovimiento = TipoMovimiento.Entrada
                    BuscarCodigoBarras(eTipoMovimiento)
                ElseIf Me.TabControlCambios.SelectedIndex = 1 AndAlso Me.ButtonBuscarProdSalida.Enabled Then 'Salida
                    eTipoMovimiento = TipoMovimiento.Salida
                    BuscarCodigoBarras(eTipoMovimiento)
                End If
        End Select
    End Sub
    Private Sub BuscarCodigoBarras(ByVal pvTipoMovimiento As TipoMovimiento)
        If pvTipoMovimiento = TipoMovimiento.Entrada Then
            If TextBoxCodigoEntrada.Text.Trim <> String.Empty Then
                Dim sProductoClave As String = Me.oProducto.BuscarCodigoBarras(Me.TextBoxCodigoEntrada.Text)
                If sProductoClave <> String.Empty Then
                    If Me.PedirProductoCantidad(0, TipoMovimiento.Entrada, sProductoClave) Then
                        Me.PoblarProductosEnt(False)
                    End If
                Else
                    MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "NoExiste"), MsgBoxStyle.Exclamation)
                    Me.TextBoxCodigoEntrada.SelectionStart = 0
                    Me.TextBoxCodigoEntrada.SelectionLength = Len(Me.TextBoxCodigoEntrada.Text)
                    Me.TextBoxCodigoEntrada.Focus()
                End If
            End If
            Me.TextBoxCodigoEntrada.Text = String.Empty
        ElseIf pvTipoMovimiento = TipoMovimiento.Salida Then
            If TextBoxCodigoSalida.Text.Trim <> String.Empty Then
                Dim sProductoClave As String = Me.oProducto.BuscarCodigoBarras(Me.TextBoxCodigoSalida.Text)
                If sProductoClave <> String.Empty Then
                    If Me.PedirProductoCantidad(0, TipoMovimiento.Salida, sProductoClave) Then
                        Me.PoblarProductosSal(False)
                    End If
                Else
                    MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "NoExiste"), MsgBoxStyle.Exclamation)
                    Me.TextBoxCodigoSalida.SelectionStart = 0
                    Me.TextBoxCodigoSalida.SelectionLength = Len(Me.TextBoxCodigoSalida.Text)
                    Me.TextBoxCodigoSalida.Focus()
                End If
            End If
            Me.TextBoxCodigoSalida.Text = String.Empty
        End If
    End Sub
#End Region

    Private Function CompararEsquemas(ByVal pvProdClaveEnt As String, ByVal pvProdClaveSal As String) As Boolean
        Try
            Dim sEsquemaEnt, sEsquemaSal As String
            sEsquemaEnt = oDBVen.RealizarConsultaSQL("Select EsquemaId From ProductoEsquema Where ProductoClave='" & pvProdClaveEnt & "'", "EsquemaEnt").Rows(0)(0)
            sEsquemaSal = oDBVen.RealizarConsultaSQL("Select EsquemaId From ProductoEsquema Where ProductoClave='" & pvProdClaveSal & "'", "EsquemaSal").Rows(0)(0)
            Return (sEsquemaEnt = sEsquemaSal)
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub TextBoxProdEntrada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxProdEntrada.KeyPress
        eTipoMovimiento = TipoMovimiento.Entrada
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                e.Handled = True
                'Se quitan los espacios porque generaba problemas al no encontrar el producto
                TextBoxProdEntrada.Text = TextBoxProdEntrada.Text.Trim()
                If TextBoxProdEntrada.Text <> "" Then
                    Dim iTipoClave, iEspacios As Integer
                    iTipoClave = oConHist.Campos("TipoClaveProducto")
                    iEspacios = oConHist.Campos("DigitoClaveProd")
                    'If MobileClient.Producto.VerificarTipoClaveProducto(iTipoClave, iEspacios) Then
                    If iTipoClave = 2 Then
                        Dim sProdClave As String = Me.TextBoxProdEntrada.Text
                        If sProdClave.Length < iEspacios Then
                            sProdClave = sProdClave.PadLeft(iEspacios, "0")
                            Me.TextBoxProdEntrada.Text = sProdClave
                        End If
                    End If
                    'End If
                    If MobileClient.Producto.ExisteProducto(Me.TextBoxProdEntrada.Text) Then
                        Me.ModificarMovimiento(0, Me.TextBoxProdEntrada.Text)
                    Else
                        MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0005"), MsgBoxStyle.Exclamation)
                        Me.TextBoxProdEntrada.SelectionStart = 0
                        Me.TextBoxProdEntrada.SelectionLength = Len(Me.TextBoxProdEntrada.Text)
                        Me.TextBoxProdEntrada.Focus()
                    End If
                End If
        End Select
    End Sub

    Private Sub TextBoxProdSalida_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxProdSalida.KeyPress
        eTipoMovimiento = TipoMovimiento.Salida
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                e.Handled = True
                'Se quitan los espacios porque generaba problemas al no encontrar el producto
                TextBoxProdSalida.Text = TextBoxProdSalida.Text.Trim()
                If TextBoxProdSalida.Text <> "" Then
                    Dim iTipoClave, iEspacios As Integer
                    iTipoClave = oConHist.Campos("TipoClaveProducto")
                    iEspacios = oConHist.Campos("DigitoClaveProd")
                    'If MobileClient.Producto.VerificarTipoClaveProducto(iTipoClave, iEspacios) Then
                    If iTipoClave = 2 Then
                        Dim sProdClave As String = Me.TextBoxProdSalida.Text
                        If sProdClave.Length < iEspacios Then
                            sProdClave = sProdClave.PadLeft(iEspacios, "0")
                            Me.TextBoxProdSalida.Text = sProdClave
                        End If
                    End If
                    'End If
                    If MobileClient.Producto.ExisteProducto(Me.TextBoxProdSalida.Text) Then
                        Me.ModificarMovimiento(0, Me.TextBoxProdSalida.Text)
                    Else
                        MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0005"), MsgBoxStyle.Exclamation)
                        Me.TextBoxProdSalida.SelectionStart = 0
                        Me.TextBoxProdSalida.SelectionLength = Len(Me.TextBoxProdSalida.Text)
                        Me.TextBoxProdSalida.Focus()
                    End If
                End If
        End Select
    End Sub


    Private Sub TabControlCambios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControlCambios.SelectedIndexChanged
        If TabControlCambios.SelectedIndex = 0 Then
            Me.TextBoxProdEntrada.Focus()
        Else
            Me.TextBoxProdSalida.Focus()
        End If

    End Sub

    Private Sub ComboBoxMotivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxMotivo.SelectedIndexChanged
        Me.bHayCambio = True
    End Sub

    Private Sub TextBoxProdEntrada_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TextBoxProdEntrada.TextChanged, TextBoxCodigoEntrada.TextChanged, TextBoxProdSalida.TextChanged, TextBoxCodigoSalida.TextChanged
        Me.bHayCambio = True
    End Sub

    Private Sub ContextMenuModificarEnt_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuModificarEnt.Popup
        Me.ContextMenuModificarEnt.MenuItems.Clear()

        If Me.fgProdEntrada.Rows.Count > 0 AndAlso Me.fgProdEntrada.Row > 0 Then

            Dim r As C1.Win.C1FlexGrid.Row
            r = Me.fgProdEntrada.Rows(Me.fgProdEntrada.Row)
            If r.Node.Level = 0 Then
                Me.ContextMenuModificarEnt.MenuItems.Add(Me.MenuItemModificarEnt)
                Me.ContextMenuModificarEnt.MenuItems.Add(Me.MenuItemEliminarEnt)
            End If

        End If
    End Sub

    Private Sub ContextMenuModificarSal_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuModificarSal.Popup
        Me.ContextMenuModificarSal.MenuItems.Clear()

        If Me.fgProdSalida.Rows.Count > 0 AndAlso Me.fgProdSalida.Row > 0 Then

            Dim r As C1.Win.C1FlexGrid.Row
            r = Me.fgProdSalida.Rows(Me.fgProdSalida.Row)
            If r.Node.Level = 0 Then
                Me.ContextMenuModificarSal.MenuItems.Add(Me.MenuItemModificarSal)
                Me.ContextMenuModificarSal.MenuItems.Add(Me.MenuItemEliminarSal)
            End If

        End If
    End Sub

    Private Sub ContextMenuRelEnt_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuRelEnt.Popup
        MostrarContextEnt()
    End Sub
    Private Sub MostrarContextEnt()
        DesactivarScanner()
        ContextMenuModificarEnt.Show(Me, Control.MousePosition)
        ActivarScanner()
    End Sub

    Private Sub ContextMenuRelSal_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuRelSal.Popup
        MostrarContextSal()
    End Sub
    Private Sub MostrarContextSal()
        DesactivarScanner()
        ContextMenuModificarSal.Show(Me, Control.MousePosition)
        ActivarScanner()
    End Sub
End Class