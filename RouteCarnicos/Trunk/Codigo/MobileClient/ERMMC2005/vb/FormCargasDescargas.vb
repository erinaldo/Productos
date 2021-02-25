Imports System.Data.SqlServerCe
Imports MobileClient.FormasCargasDescargas
Public Class FormCargasDescargas
    Inherits System.Windows.Forms.Form

    Enum TipoBorrado
        SKU = 1
        ProductoClave = 2
        ProductoUnidad = 3
    End Enum

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        If g_SO = SO.WindowsCE Then
            Call InTheHand.Windows.Forms.ContextMenuHelper.HookAllControls(Me.Controls)
        End If

        'Add any initialization after the InitializeComponent() call
        ModuloMovDetalle = paroModuloMovDetActual

        'If oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then
#If MOD_TERM <> "PALM" Then
        bScanner = New HANDHELD.CScanner
#End If
        'Else
        'bScanner = Nothing
        'End If
        With ListViewCargasDescargas
            .Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
            .Activation = oApp.TipoSeleccion
            .CheckBoxes = True
        End With

        fgDetalles.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.fgDetalles Is Nothing Then
            Me.fgDetalles.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.None
            Me.fgDetalles.Clear(C1.Win.C1FlexGrid.ClearFlags.All)
            Me.fgDetalles.DataSource = Nothing
            Me.fgDetalles.ContextMenu = Nothing
            Me.fgDetalles.Dispose()
            Me.fgDetalles = Nothing
        End If
        If Not Me.MenuItemEliminar Is Nothing Then Me.MenuItemEliminar.Dispose()
        If Not Me.MenuItemModificar Is Nothing Then Me.MenuItemModificar.Dispose()
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenuCargas Is Nothing Then Me.MainMenuCargas.Dispose()
        If Not Me.ContextMenu1 Is Nothing Then Me.ContextMenu1.Dispose()
        If Not Me.ContextMenu2 Is Nothing Then Me.ContextMenu2.Dispose()
        If Me.ListViewCargasDescargas.Columns.Count > 0 Then
            Me.ListViewCargasDescargas.Columns.Clear()
            Me.ListViewCargasDescargas.Dispose()
        End If
        Me.LabelCodigo.Dispose()
        Me.CheckBoxProducto.Dispose()
        Me.LabelTransProdID.Dispose()
        Me.ButtonBuscarProducto.Dispose()
        Me.ButtonContinuarDet.Dispose()
        Me.ButtonContinuarLista.Dispose()
        Me.ButtonRegresarDet.Dispose()
        Me.ButtonRegresarLista.Dispose()
        oProducto = Nothing
        refaVista = Nothing
        oModuloMovDetalle = Nothing
        ContextMenu2 = Nothing
        ContextMenu1 = Nothing
#If MOD_TERM <> "PALM" Then
        If Not bScanner Is Nothing Then bScanner.Dispose()
        bScanner = Nothing
#End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents PanelLista As System.Windows.Forms.Panel
    Friend WithEvents ButtonContinuarLista As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresarLista As System.Windows.Forms.Button
    Friend WithEvents TextBoxProducto As System.Windows.Forms.TextBox
    Friend WithEvents ButtonBuscarProducto As System.Windows.Forms.Button
    Friend WithEvents MainMenuCargas As System.Windows.Forms.MainMenu
    Friend WithEvents PanelDetalle As System.Windows.Forms.Panel
    Friend WithEvents ButtonRegresarDet As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuarDet As System.Windows.Forms.Button
    Friend WithEvents fgDetalles As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemEliminar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemModificar As System.Windows.Forms.MenuItem
    Friend WithEvents TextBoxCodigo As System.Windows.Forms.TextBox
    Friend WithEvents LabelCodigo As System.Windows.Forms.Label
    Friend WithEvents ContextMenu2 As System.Windows.Forms.ContextMenu
    Friend WithEvents TextBoxCodigoBarras As System.Windows.Forms.TextBox
    Friend WithEvents LabelTransProdID As System.Windows.Forms.Label
    Friend WithEvents CheckBoxProducto As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonEliminarLista As System.Windows.Forms.Button
    Friend WithEvents ListViewCargasDescargas As System.Windows.Forms.ListView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCargasDescargas))
        Me.TextBoxCodigo = New System.Windows.Forms.TextBox
        Me.LabelCodigo = New System.Windows.Forms.Label
        Me.fgDetalles = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ContextMenu2 = New System.Windows.Forms.ContextMenu
        Me.TextBoxProducto = New System.Windows.Forms.TextBox
        Me.ButtonBuscarProducto = New System.Windows.Forms.Button
        Me.LabelTransProdID = New System.Windows.Forms.Label
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItemEliminar = New System.Windows.Forms.MenuItem
        Me.MenuItemModificar = New System.Windows.Forms.MenuItem
        Me.MainMenuCargas = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.PanelLista = New System.Windows.Forms.Panel
        Me.ButtonEliminarLista = New System.Windows.Forms.Button
        Me.TextBoxCodigoBarras = New System.Windows.Forms.TextBox
        Me.ListViewCargasDescargas = New System.Windows.Forms.ListView
        Me.ButtonContinuarLista = New System.Windows.Forms.Button
        Me.ButtonRegresarLista = New System.Windows.Forms.Button
        Me.ButtonRegresarDet = New System.Windows.Forms.Button
        Me.ButtonContinuarDet = New System.Windows.Forms.Button
        Me.PanelDetalle = New System.Windows.Forms.Panel
        Me.CheckBoxProducto = New System.Windows.Forms.CheckBox
        Me.PanelLista.SuspendLayout()
        Me.PanelDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxCodigo
        '
        Me.TextBoxCodigo.AcceptsReturn = True
        Me.TextBoxCodigo.Location = New System.Drawing.Point(87, 48)
        Me.TextBoxCodigo.Name = "TextBoxCodigo"
        Me.TextBoxCodigo.Size = New System.Drawing.Size(144, 23)
        Me.TextBoxCodigo.TabIndex = 2
        '
        'LabelCodigo
        '
        Me.LabelCodigo.Location = New System.Drawing.Point(7, 48)
        Me.LabelCodigo.Name = "LabelCodigo"
        Me.LabelCodigo.Size = New System.Drawing.Size(80, 16)
        Me.LabelCodigo.Text = "LabelCodigo"
        '
        'fgDetalles
        '
        Me.fgDetalles.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fgDetalles.AllowEditing = False
        Me.fgDetalles.AutoSearchDelay = 2
        Me.fgDetalles.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fgDetalles.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgDetalles.ContextMenu = Me.ContextMenu2
        Me.fgDetalles.Font = New System.Drawing.Font("Tahoma", 9.0!, Drawing.FontStyle.Regular)
        Me.fgDetalles.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgDetalles.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgDetalles.Location = New System.Drawing.Point(8, 74)
        Me.fgDetalles.Name = "fgDetalles"
        Me.fgDetalles.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgDetalles.Size = New System.Drawing.Size(226, 183)
        Me.fgDetalles.StyleInfo = resources.GetString("fgDetalles.StyleInfo")
        Me.fgDetalles.SupportInfo = "EQFVAQYB8QDyAGQBfQA2AfwAggD1ACEB/gC3AJAAUwEjAUcAqQAlAQ0BYQAzAE8A4ACdAHQAUACjAA=="
        Me.fgDetalles.TabIndex = 27
        '
        'ContextMenu2
        '
        '
        'TextBoxProducto
        '
        Me.TextBoxProducto.Location = New System.Drawing.Point(87, 23)
        Me.TextBoxProducto.Name = "TextBoxProducto"
        Me.TextBoxProducto.Size = New System.Drawing.Size(118, 23)
        Me.TextBoxProducto.TabIndex = 0
        '
        'ButtonBuscarProducto
        '
        Me.ButtonBuscarProducto.Location = New System.Drawing.Point(207, 23)
        Me.ButtonBuscarProducto.Name = "ButtonBuscarProducto"
        Me.ButtonBuscarProducto.Size = New System.Drawing.Size(24, 21)
        Me.ButtonBuscarProducto.TabIndex = 1
        Me.ButtonBuscarProducto.Text = "..."
        '
        'LabelTransProdID
        '
        Me.LabelTransProdID.Location = New System.Drawing.Point(28, 78)
        Me.LabelTransProdID.Name = "LabelTransProdID"
        Me.LabelTransProdID.Size = New System.Drawing.Size(160, 20)
        Me.LabelTransProdID.Visible = False
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.Add(Me.MenuItemEliminar)
        Me.ContextMenu1.MenuItems.Add(Me.MenuItemModificar)
        '
        'MenuItemEliminar
        '
        Me.MenuItemEliminar.Text = "MenuItemEliminar"
        '
        'MenuItemModificar
        '
        Me.MenuItemModificar.Text = "MenuItemModificar"
        '
        'MainMenuCargas
        '
        Me.MainMenuCargas.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'PanelLista
        '
        Me.PanelLista.Controls.Add(Me.ButtonEliminarLista)
        Me.PanelLista.Controls.Add(Me.TextBoxCodigoBarras)
        Me.PanelLista.Controls.Add(Me.ListViewCargasDescargas)
        Me.PanelLista.Controls.Add(Me.ButtonContinuarLista)
        Me.PanelLista.Controls.Add(Me.ButtonRegresarLista)
        Me.PanelLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelLista.Location = New System.Drawing.Point(0, 0)
        Me.PanelLista.Name = "PanelLista"
        Me.PanelLista.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonEliminarLista
        '
        Me.ButtonEliminarLista.Location = New System.Drawing.Point(161, 266)
        Me.ButtonEliminarLista.Name = "ButtonEliminarLista"
        Me.ButtonEliminarLista.Size = New System.Drawing.Size(74, 24)
        Me.ButtonEliminarLista.TabIndex = 4
        Me.ButtonEliminarLista.Text = "ButtonEliminarLista"
        '
        'TextBoxCodigoBarras
        '
        Me.TextBoxCodigoBarras.Location = New System.Drawing.Point(8, 239)
        Me.TextBoxCodigoBarras.Name = "TextBoxCodigoBarras"
        Me.TextBoxCodigoBarras.Size = New System.Drawing.Size(224, 23)
        Me.TextBoxCodigoBarras.TabIndex = 3
        Me.TextBoxCodigoBarras.Visible = False
        '
        'ListViewCargasDescargas
        '
        Me.ListViewCargasDescargas.CheckBoxes = True
        Me.ListViewCargasDescargas.FullRowSelect = True
        Me.ListViewCargasDescargas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewCargasDescargas.Location = New System.Drawing.Point(7, 24)
        Me.ListViewCargasDescargas.Name = "ListViewCargasDescargas"
        Me.ListViewCargasDescargas.Size = New System.Drawing.Size(228, 232)
        Me.ListViewCargasDescargas.TabIndex = 0
        Me.ListViewCargasDescargas.View = System.Windows.Forms.View.Details
        '
        'ButtonContinuarLista
        '
        Me.ButtonContinuarLista.Location = New System.Drawing.Point(8, 266)
        Me.ButtonContinuarLista.Name = "ButtonContinuarLista"
        Me.ButtonContinuarLista.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarLista.TabIndex = 1
        Me.ButtonContinuarLista.Text = "ButtonContinuarLista"
        '
        'ButtonRegresarLista
        '
        Me.ButtonRegresarLista.Location = New System.Drawing.Point(85, 266)
        Me.ButtonRegresarLista.Name = "ButtonRegresarLista"
        Me.ButtonRegresarLista.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresarLista.TabIndex = 2
        Me.ButtonRegresarLista.Text = "ButtonRegresarLista"
        '
        'ButtonRegresarDet
        '
        Me.ButtonRegresarDet.Location = New System.Drawing.Point(81, 262)
        Me.ButtonRegresarDet.Name = "ButtonRegresarDet"
        Me.ButtonRegresarDet.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresarDet.TabIndex = 1
        Me.ButtonRegresarDet.Text = "ButtonRegresarDet"
        '
        'ButtonContinuarDet
        '
        Me.ButtonContinuarDet.Location = New System.Drawing.Point(2, 262)
        Me.ButtonContinuarDet.Name = "ButtonContinuarDet"
        Me.ButtonContinuarDet.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuarDet.TabIndex = 2
        Me.ButtonContinuarDet.Text = "ButtonContinuarDet"
        '
        'PanelDetalle
        '
        Me.PanelDetalle.Controls.Add(Me.CheckBoxProducto)
        Me.PanelDetalle.Controls.Add(Me.TextBoxCodigo)
        Me.PanelDetalle.Controls.Add(Me.LabelCodigo)
        Me.PanelDetalle.Controls.Add(Me.ButtonRegresarDet)
        Me.PanelDetalle.Controls.Add(Me.fgDetalles)
        Me.PanelDetalle.Controls.Add(Me.TextBoxProducto)
        Me.PanelDetalle.Controls.Add(Me.ButtonContinuarDet)
        Me.PanelDetalle.Controls.Add(Me.ButtonBuscarProducto)
        Me.PanelDetalle.Controls.Add(Me.LabelTransProdID)
        Me.PanelDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDetalle.Location = New System.Drawing.Point(0, 0)
        Me.PanelDetalle.Name = "PanelDetalle"
        Me.PanelDetalle.Size = New System.Drawing.Size(242, 295)
        '
        'CheckBoxProducto
        '
        Me.CheckBoxProducto.Location = New System.Drawing.Point(4, 25)
        Me.CheckBoxProducto.Name = "CheckBoxProducto"
        Me.CheckBoxProducto.Size = New System.Drawing.Size(78, 20)
        Me.CheckBoxProducto.TabIndex = 29
        Me.CheckBoxProducto.Text = "LabelProducto"
        '
        'FormCargasDescargas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelLista)
        Me.Controls.Add(Me.PanelDetalle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuCargas
        Me.MinimizeBox = False
        Me.Name = "FormCargasDescargas"
        Me.Text = "Amesol Route"
        Me.PanelLista.ResumeLayout(False)
        Me.PanelDetalle.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private PosTransProdID As Integer
    Private PosPartida As Integer
    Private PosProductoClave As Integer

    Private refaVista As Vista
    'Private eTipoMovimientos As FormasCargasDescargas.TipoMovimiento
    Private eEstado As TipoEstado
    Private blnSeleccionManual As Boolean = False

    Private oProducto As Producto
    Private oModuloMovDetalle As New Modulos.GrupoModuloMovDetalle
#If MOD_TERM <> "PALM" Then
    Private WithEvents bScanner As HANDHELD.CScanner
#End If
    Private bLector As Boolean = False
    Dim bHuboCambios As Boolean = False
    Private sFolio As String

#Region "Propiedades"
    Public Property Producto() As Producto
        Get
            Return oProducto
        End Get
        Set(ByVal Value As Producto)
            oProducto = Value
        End Set
    End Property
    Public Property ModuloMovDetalle() As Modulos.GrupoModuloMovDetalle
        Get
            Return oModuloMovDetalle
        End Get
        Set(ByVal Value As Modulos.GrupoModuloMovDetalle)
            oModuloMovDetalle = Value
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

#Region "Forma"

    Private Sub FormCargasDescargas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If eEstado = TipoEstado.Creando Or eEstado = TipoEstado.Modificando Then
            Me.ActivarScanner()
        End If
    End Sub

    Private Sub FormCargasDescargas_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        If eEstado = TipoEstado.Creando Or eEstado.Modificando Then
            Me.DesactivarScanner()
        End If
    End Sub

    Private Sub FormCargasDescargas_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
        Me.Transaccion = Nothing
        'Me.ListViewCamiones.Dispose()
        'Me.ListViewCargasDescargas.Dispose()
        'Me.fgDetalles.Dispose()
    End Sub

    Private Sub FormCargas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'blnSeleccionManual = True
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)

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

        ListViewCargasDescargas.Activation = oApp.TipoSeleccion
        ' Recuperar los demás componentes de la forma
        If Not MobileClient.Vista.Buscar("FormCargasDescargas", refaVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If

        If oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then
            PosTransProdID = 3
            PosPartida = 0
            PosProductoClave = 1
            refaVista.CrearListView(ListViewCargasDescargas, "ListViewCargas")
        Else
            PosTransProdID = 3
            PosPartida = 0
            PosProductoClave = 1
            'Me.TextBoxCodigo.Visible = False
            'Me.LabelCodigo.Visible = False
            'Me.fgDetalles.Size = New Drawing.Size(224, 200)
            'Me.fgDetalles.Location = New Drawing.Point(8, 8)
            refaVista.CrearListView(ListViewCargasDescargas, "ListViewDescargas")
        End If



        Application.DoEvents()
        ConfiguraGrid()

        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        refaVista.ColocarEtiquetasMenuEmergente(ContextMenu1)
        'ConfigurarGrid()
        'blnSeleccionManual = False
        ' Crear el objeto Producto
        Me.Producto = New Producto
        eEstado = TipoEstado.Navegando
        Vista()
        If fgDetalles.Rows.Count > 1 Then
            fgDetalles.Rows(0).Selected = True
            fgDetalles.Focus()
        ElseIf oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Descargas And ListViewCargasDescargas.Items.Count < 1 Then
            eEstado = TipoEstado.Creando
            Vista()
        End If

        If oApp.ModeloTerminal = "SymbolMC35" And oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then
            Me.TextBoxCodigoBarras.Focus()
            Me.TextBoxCodigoBarras.Visible = True
            ListViewCargasDescargas.Height = 220
        End If
        Me.bHuboCambios = False
        Cursor.Current = Cursors.Default
    End Sub

#End Region

#Region "Eventos de controles"
    Private Sub ButtonContinuarLista_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuarLista.Click
        Cursor.Current = Cursors.WaitCursor
        If ListViewCargasDescargas.SelectedIndices.Count <= 0 Then
            eEstado = TipoEstado.Creando
        Else
            If ValidarEnviado() Then
                eEstado = TipoEstado.Modificando
            Else
                If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0213"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    eEstado = TipoEstado.Consultando
                End If
            End If
        End If
        Vista()
        Cursor.Current = Cursors.Default
        Me.bHuboCambios = False
    End Sub
    Private Sub ListViewCargasDescargas_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewCargasDescargas.ItemCheck
        If blnSeleccionManual Then Exit Sub
        blnSeleccionManual = True
        MarcarElemento(ListViewCargasDescargas, e.NewValue, e.Index)
        blnSeleccionManual = False
        If ListViewCargasDescargas.SelectedIndices.Count <= 0 Then Exit Sub
        If e.NewValue = CheckState.Unchecked Then
            blnSeleccionManual = True
            ListViewCargasDescargas.Items(ListViewCargasDescargas.SelectedIndices(0)).Selected = False
            blnSeleccionManual = False
        End If
    End Sub
    Private Sub ListViewCargasDescargas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewCargasDescargas.SelectedIndexChanged
        If blnSeleccionManual Then Exit Sub
        If ListViewCargasDescargas.SelectedIndices.Count <= 0 Then Exit Sub
        blnSeleccionManual = True
        MarcarElemento(ListViewCargasDescargas, CheckState.Checked, ListViewCargasDescargas.SelectedIndices(0))
        blnSeleccionManual = False
    End Sub

    'Private Sub SalirPlantillaCaptura()
    '    If MsgBox(refaVista.BuscarMensaje("MsgBox", "TerminarCaptura"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '        Me.TabControlMovProducto.SelectedIndex = ConstPosTabPageTotales
    '        Me.TabControlMovProducto.Refresh()
    '    End If
    'End Sub

    Private Sub ButtonBuscarProducto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonBuscarProducto.Click
        SeleccionarProducto()
    End Sub

    Private Sub SeleccionarProducto()
        ' Llamar la forma para pedir las cantidades por unidad, ademas de buscar
        bHuboCambios = True
        'Se quitan los espacios porque generaba problemas al no encontrar el producto
        Me.TextBoxProducto.Text = Me.TextBoxProducto.Text.Trim()
        ' Llamar la forma para pedir las cantidades por unidad, ademas de buscar
        If Me.TextBoxProducto.Text.Trim = String.Empty Then
            Me.AgregarMovimiento()
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
                Me.ModificarMovimiento(0, Me.Producto.ProductoClave)
            Else
                MsgBox(Me.refaVista.BuscarMensaje("MsgBox", "E0005"), MsgBoxStyle.Exclamation)
                Me.TextBoxProducto.SelectionStart = 0
                Me.TextBoxProducto.SelectionLength = Len(Me.TextBoxProducto.Text)
                Me.TextBoxProducto.Focus()
            End If
        End If
    End Sub

    Private Sub HabilitarBotones(ByVal bHabilitar As Boolean)
        Me.ButtonBuscarProducto.Enabled = bHabilitar
        Me.ButtonContinuarDet.Enabled = bHabilitar
        Me.ButtonContinuarLista.Enabled = bHabilitar
        Me.ButtonRegresarDet.Enabled = bHabilitar
        Me.ButtonRegresarLista.Enabled = bHabilitar
    End Sub

    Private Sub ButtonContinuarDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuarDet.Click
        Try
            If Validar() Then
                If GuardarEncabezado() Then
                    HabilitarBotones(False)
                    Me.Transaccion.Commit()
                    Me.Transaccion.Dispose()
                    Me.Transaccion = Nothing

                    If oVendedor.motconfiguracion.MensajeImpresion Then
                        If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                            If oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then
                                ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.SinVisita, Me.LabelTransProdID.Text, ServicesCentral.TiposTransProd.Cargas, ServicesCentral.TiposTransProd.Cargas)
                            Else
                                ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.SinVisita, Me.LabelTransProdID.Text, ServicesCentral.TiposTransProd.Descargas, ServicesCentral.TiposTransProd.Descargas)
                            End If
                        End If
                    End If
                    HabilitarBotones(True)
                    Me.Close()
                    'eEstado = TipoEstado.Navegando
                    'Vista()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ButtonRegresarDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresarDet.Click
        If eEstado = TipoEstado.Creando Or eEstado = TipoEstado.Modificando Then
            If bHuboCambios = True Then
                If MsgBox(refaVista.BuscarMensaje("MsgBox", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        End If
        Try
            Me.Transaccion.Rollback()
            Me.Transaccion.Dispose()
            Me.Transaccion = Nothing

            'eEstado = TipoEstado.Navegando
            'Vista()
            'If ListViewCargasDescargas.Items.Count = 0 Then
            Me.Close()
            'End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub ListViewProductos_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.fgDetalles.SelectedIndices.Count = 0 Then
    '        Exit Sub
    '    End If
    '    Dim refListViewItem As ListViewItem = ListViewProductos.Items(ListViewProductos.SelectedIndices(0))
    '    Me.ModificarMovimiento(IIf(refListViewItem.SubItems(Me.PosPartida).Text = "", 0, refListViewItem.SubItems(Me.PosPartida).Text), refListViewItem.SubItems(Me.PosProductoClave).Text)
    'End Sub
    Private Sub ButtonRegresarLista_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresarLista.Click
        Me.Close()
    End Sub
    'Private Sub ListViewProductos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If ListViewProductos.SelectedIndices.Count = 0 Then
    '            Exit Sub
    '        End If
    '        Dim refListViewItem As ListViewItem = ListViewProductos.Items(ListViewProductos.SelectedIndices(0))
    '    Catch ExcA As Exception
    '        MsgBox(ExcA.Message, MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub
    Private Sub MenuItemRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        If Me.PanelLista.Visible Then
            ButtonRegresarLista_Click(Nothing, Nothing)
        Else
            ButtonRegresarDet_Click(Nothing, Nothing)
        End If
    End Sub
#End Region

#Region "Eventos FormPedirProducto"
    Private Sub PoblarListViewProductos(ByRef refparoFormPedirProducto As FormPedirProducto, ByVal aListaEsquemas As ArrayList)
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
            .Cols(0).Caption = refaVista.BuscarMensaje("MsgBox", "PROProductoClave")
            .Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "PRONombre")
            .Cols(0).Width = 100
            .Cols(1).Width = 280
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
        End With
    End Sub


    Private Function BorrarMovimientoSKU(ByVal parsTransProdId As String, ByVal parTipoBorrado As TipoBorrado, ByVal parsCodigoSKU As String, ByVal parsProductoClave As String) As Boolean
        Try
            bHuboCambios = True
            ' Obtener los TransProdDetalleID del numero de partida que se va a borrar
            Dim DataTableIDs As DataTable
            Select Case parTipoBorrado
                Case TipoBorrado.SKU
                    DataTableIDs = oDBVen.RealizarConsultaSQL("SELECT TransProdDetalleID,ProductoClave,TipoUnidad,Cantidad,Cantidad1,CodigoSKU FROM TransProdDetalle WHERE TransProdId='" & parsTransProdId & "' AND CodigoSKU = '" & parsCodigoSKU & "'", "IDs")
                Case TipoBorrado.ProductoClave
                    DataTableIDs = oDBVen.RealizarConsultaSQL("SELECT TransProdDetalleID,ProductoClave,TipoUnidad,Cantidad,Cantidad1,CodigoSKU FROM TransProdDetalle WHERE TransProdId='" & parsTransProdId & "' and PRoductoClave ='" & parsProductoClave & "'", "IDs")
                Case TipoBorrado.ProductoUnidad
                    DataTableIDs = oDBVen.RealizarConsultaSQL("SELECT TransProdDetalleID,ProductoClave,TipoUnidad,Cantidad,Cantidad1,CodigoSKU FROM TransProdDetalle WHERE TransProdId='" & parsTransProdId & "' and PRoductoClave ='" & parsProductoClave & "' and codigosku ='' ", "IDs")
            End Select

            If DataTableIDs.Rows.Count > 0 Then
                Dim sIds As New System.Text.StringBuilder

                For Each refDataRow As DataRow In DataTableIDs.Rows
                    If sIds.ToString <> "" Then
                        sIds.Append(",")
                    End If
                    sIds.Append("'" & refDataRow("TransProdDetalleID") & "'")
                    SKUInventario.ActualizarSKU(SKUInventario.SKUMovimiento.Incrementar, refDataRow("CodigoSKU"), refDataRow("ProductoClave"), refDataRow("TipoUnidad"), refDataRow("Cantidad"), refDataRow("Cantidad1"))
                Next

                Return oDBVen.EjecutarComandoSQL("DELETE FROM TransProdDetalle WHERE TransProdId='" & parsTransProdId & "' AND TransProdDetalleID IN (" & sIds.ToString & ")")

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "BorrarMovimiento")
        End Try
        Return False
    End Function

    Private Sub GuardarDetalleProductos(ByRef refparoFormPedirProducto As FormPedirProducto)
        Try
            BorrarMovimientoSKU(LabelTransProdID.Text.Trim, TipoBorrado.ProductoUnidad, "", refparoFormPedirProducto.Producto.ProductoClave)
            For Each refProducto As FormPedirProducto.ItemUnidad In refparoFormPedirProducto.PanelUnidades.Controls
                With refProducto
                    If IsNumeric(.NumericCantidad.DecimalValue) Then
                        .TransProdDetalleID = ""
                    End If
                End With
            Next
            Dim iPartida As Integer = 0
            If Not Folio.ObtenerTransProdPartida(refparoFormPedirProducto.TransProdId, refparoFormPedirProducto.Producto.ProductoClave, iPartida) Then
                Exit Try
            End If

            ' Actualizar el detalle
            For Each refProducto As FormPedirProducto.ItemUnidad In refparoFormPedirProducto.PanelUnidades.Controls
                With refProducto
                    If IsNumeric(.NumericCantidad.DecimalValue) AndAlso .NumericCantidad.DecimalValue > 0 Then
                        Dim oSKU As New SKUInventario
                        oSKU.CodigoSKU = ""
                        oSKU.ProductoClave = refparoFormPedirProducto.Producto.ProductoClave
                        oSKU.TipoUnidad = .TipoUnidad
                        oSKU.Disponible = .NumericCantidad.DecimalValue
                        oSKU.Cantidad = .NumericCantidad1.DecimalValue
                        InsertarDetalleSKU(LabelTransProdID.Text.Trim, iPartida, oSKU, "")
                        oSKU = Nothing
                    End If
                End With
            Next
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "GuardarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "GuardarProducto")
        End Try
    End Sub

    Private Sub InsertarDetalleSKU(ByVal sTransProdId As String, ByRef nPartida As Integer, ByVal oSKU As SKUInventario, ByRef sTransProdDetalleId As String)
        Dim sComandoSQL As String
        Dim blnNuevo As Boolean
        Try
            ' Es una nueva partida, obtenerla
            If nPartida = 0 Then
                If Not Folio.ObtenerTransProdPartida(sTransProdId, oSKU.ProductoClave, nPartida) Then
                    Exit Try
                End If
            End If

            sComandoSQL = Me.ComandoActualizarDetalle(sTransProdId, sTransProdDetalleId, oSKU.ProductoClave, oSKU.CodigoSKU, oSKU.TipoUnidad, oSKU.Disponible, oSKU.Cantidad, nPartida, 1, 0.0, 0.0, 1)
            oDBVen.EjecutarComandoSQL(sComandoSQL)

            SKUInventario.ActualizarSKU(SKUInventario.SKUMovimiento.Decrementar, oSKU.CodigoSKU, oSKU.ProductoClave, oSKU.TipoUnidad, oSKU.Disponible, oSKU.Cantidad)
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "InsertarDetalleSKU")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "InsertarDetalleSKU")
        End Try
        sComandoSQL = Nothing
    End Sub
#End Region

#Region "Metodos"
    Private Sub Vista()
        sFolio = String.Empty
        If eEstado = TipoEstado.Navegando Then
            PanelLista.Visible = True
            PanelDetalle.Visible = False
            If oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then
                refaVista.PoblarListView(ListViewCargasDescargas, oDBVen, "ListViewCargas", " and DiaClave='" & oDia.DiaActual & "' ")
            Else
                refaVista.PoblarListView(ListViewCargasDescargas, oDBVen, "ListViewDescargas", " and DiaClave='" & oDia.DiaActual & "' ")
            End If
        Else
            If eEstado = TipoEstado.Modificando Then
                If oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then

                    Dim oListViewItemSel As ListViewItem = ListViewCargasDescargas.Items(ListViewCargasDescargas.SelectedIndices(0))
                    oListViewItemSel.Checked = True

                    Dim blnEscritorio As Boolean = CType(IIf(oListViewItemSel.SubItems(4).Text = "", False, oListViewItemSel.SubItems(4).Text), Boolean)
                    If blnEscritorio Then
                        eEstado = TipoEstado.Navegando
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "I0126"), MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If ExistenVisitas() Then
                        eEstado = TipoEstado.Navegando
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0079"), MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If
            ElseIf eEstado = TipoEstado.Creando Then
                sFolio = Folio.Obtener(ModuloMovDetalle.ModuloMovDetalleClave)
                If sFolio = "" Then
                    eEstado = TipoEstado.Navegando
                    Exit Sub
                End If
            End If
            PanelLista.Visible = False
            PanelDetalle.Visible = True
            CheckBoxProducto.Visible = True '(oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas)
            TextBoxProducto.Visible = True '(oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas)
            ButtonBuscarProducto.Visible = True '(oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas)
        End If
        If eEstado = TipoEstado.Creando Or eEstado = TipoEstado.Modificando Then
            Me.ActivarScanner()
        End If
        Application.DoEvents()
        Select Case eEstado
            'Case TipoEstado.Navegando

            Case TipoEstado.Creando
                If oDBVen.oConexion.State = ConnectionState.Closed Then
                    oDBVen.oConexion.Open()
                End If
                Me.Transaccion = oDBVen.oConexion.BeginTransaction()
                LimpiarCampos()
                If Me.LabelTransProdID.Text = "" Then
                    Folio.ObtenerTransProdId(Me.LabelTransProdID.Text)
                    Me.GuardarEncabezado()
                End If

                PoblarProductos(True)
                HabilitarBotones(True)
            Case TipoEstado.Modificando
                If oDBVen.oConexion.State = ConnectionState.Closed Then
                    oDBVen.oConexion.Open()
                End If
                Me.Transaccion = oDBVen.oConexion.BeginTransaction()
                MostrarDetalles()
                HabilitarControles(True)

            Case TipoEstado.Consultando
                If oDBVen.oConexion.State = ConnectionState.Closed Then
                    oDBVen.oConexion.Open()
                End If
                Me.Transaccion = oDBVen.oConexion.BeginTransaction()
                MostrarDetalles()
                HabilitarControles(False)

            Case TipoEstado.Cancelando

        End Select
    End Sub

    Private Function ValidarEnviado() As Boolean
        Dim refListViewItemSel As ListViewItem = ListViewCargasDescargas.Items(ListViewCargasDescargas.SelectedIndices(0))
        refListViewItemSel.Checked = True

        Dim sConsulta As String = "select Enviado from TransProd where TransProdId = '" & refListViewItemSel.SubItems(PosTransProdID).Text & "'"
        Return oDBVen.EjecutarCmdScalarIntSQL(sConsulta) = 0
    End Function

    Private Sub LimpiarCampos()
        Me.LabelTransProdID.Text = ""
        Me.fgDetalles.Rows.Count = 1
    End Sub

    Private Sub HabilitarControles(ByVal bHabilitar As Boolean)
        CheckBoxProducto.Enabled = bHabilitar
        TextBoxProducto.Enabled = bHabilitar
        TextBoxCodigo.Enabled = bHabilitar
        ButtonBuscarProducto.Enabled = bHabilitar
        ButtonContinuarDet.Enabled = bHabilitar
    End Sub

    Private Sub MostrarDetalles()
        Dim refListViewItemSel As ListViewItem = ListViewCargasDescargas.Items(ListViewCargasDescargas.SelectedIndices(0))
        refListViewItemSel.Checked = True

        Dim dsTransProd As DataSet = RecuperarTransProd(refListViewItemSel.SubItems(PosTransProdID).Text)
        If dsTransProd.Tables("TransProd").Rows.Count <= 0 Then
            If Not Me.Transaccion Is Nothing Then
                Me.Transaccion.Rollback()
                Me.Transaccion.Dispose()
                Me.Transaccion = Nothing
            End If
            eEstado = TipoEstado.Navegando
            Vista()
            Exit Sub
        End If

        With dsTransProd.Tables("TransProd")
            Me.LabelTransProdID.Text = .Rows(0)("TransProdID")
            sFolio = .Rows(0)("Folio")
            oModuloMovDetalle.TipoTransProd = .Rows(0)("Tipo")

            Dim oAlmacen As New Almacen
            oAlmacen.AlmacenID = oVendedor.AlmacenId
            oAlmacen.Recuperar()

            PoblarProductos(True)
            oAlmacen = Nothing
        End With

    End Sub
    Private Function GuardarEncabezado() As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        Try
            ' Buscar el TransProdId, para ver si ya existia
            Dim DataTableTrans As DataTable
            DataTableTrans = oDBVen.RealizarConsultaSQL("SELECT TransProdId FROM TransProd WHERE TransProdId='" & Me.LabelTransProdID.Text & "'", "TransProd")
            If DataTableTrans.Rows.Count > 0 Then
                ' Ya existe, actualizar
                sComandoSQL.Append("UPDATE TransProd SET ")
                sComandoSQL.Append("Folio='" & sFolio & "',")
                sComandoSQL.Append("PCEModuloMovDetClave='" & Me.ModuloMovDetalle.ModuloMovDetalleClave & "',")
                sComandoSQL.Append("TipoFase=" & ServicesCentral.TiposFasesPedidos.Captura & ",")
                sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",")
                sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 ")
                sComandoSQL.Append("WHERE TransProdId='" & Me.LabelTransProdID.Text & "'")
            Else
                ' No existe, crear
                sComandoSQL.Append("INSERT INTO TransProd (TransProdID,DiaClave,PCEModuloMovDetClave, Folio, Tipo,  TipoFase, TipoMovimiento, FechaCaptura, FechaHoraAlta,Total, MFechaHora, MUsuarioID,Enviado,Escritorio) VALUES (")
                sComandoSQL.Append("'" & Me.LabelTransProdID.Text & "',")
                sComandoSQL.Append("'" & oDia.DiaActual & "',")
                sComandoSQL.Append("'" & Me.ModuloMovDetalle.ModuloMovDetalleClave & "',")
                sComandoSQL.Append("'" & sFolio & "',")
                sComandoSQL.Append(oModuloMovDetalle.TipoTransProd & ",")
                sComandoSQL.Append(ServicesCentral.TiposFasesPedidos.Captura & ",")
                sComandoSQL.Append(oModuloMovDetalle.TipoMovimiento & ",")
                sComandoSQL.Append(UniFechaSQL(PrimeraHora(Now)) & ",")
                sComandoSQL.Append(UniFechaSQL(Now) & ",")
                sComandoSQL.Append("0,")
                sComandoSQL.Append(UniFechaSQL(Now) & ",")
                sComandoSQL.Append("'" & oVendedor.UsuarioId & "',")
                sComandoSQL.Append("0,0)")
                Folio.Confirmar(oModuloMovDetalle.ModuloMovDetalleClave)
            End If
            DataTableTrans.Dispose()
            DataTableTrans = Nothing
            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
            sComandoSQL = Nothing
            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        End Try
    End Function

    Private Sub AgregarMovimiento()
        'Se quitan los espacios porque generaba problemas al no encontrar el producto
        TextBoxProducto.Text = TextBoxProducto.Text.Trim()
        If Me.PedirProductoCantidad(0, Me.TextBoxProducto.Text) Then
            PoblarProductos(False)
        End If
    End Sub
    Private Sub ModificarMovimiento(ByVal pariPartida As Integer, Optional ByVal parsProductoClave As String = "")
        If Me.PedirProductoCantidad(pariPartida, parsProductoClave) Then
            PoblarProductos(False)
        End If
    End Sub
    Private Sub PoblarProductos(Optional ByVal parbPrimeraVez As Boolean = False)
        'If oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then
        ' PoblarGrid()
        ' Me.PrepararMovimiento()
        ' Else
        PoblarGrid()
        Me.PrepararMovimiento()
        'End If
    End Sub
    Private Sub PrepararMovimiento(Optional ByVal parbBorrarProducto As Boolean = True)
        Dim iProxNumPartida As Integer = 1
        If parbBorrarProducto Then
            TextBoxProducto.Text = ""
            If Not TextBoxProducto.Focused Then
                TextBoxProducto.Focus()
            End If
        Else
            'BuscarProductoXId(DataViewBusqProdXId, TextBoxProducto.Text, LabelInfo.Text)
        End If
        ' bEnProceso = True
        ' Quitar cualquier selección de productos
        'If fgDetalles.Rows.Count > 1 Then
        '    If ListViewProductos.SelectedIndices.Count <> 0 Then
        '        Dim refListViewItem As ListViewItem
        '        For Each refListViewItem In ListViewProductos.Items
        '            If refListViewItem.Selected Then
        '                refListViewItem.Selected = False
        '            End If
        '        Next
        '    End If
        'End If

        'bEnProceso = False
    End Sub
    ' Guardar el detalle del pedido
    Private Function PedirProductoCantidad(ByVal pariPartida As Integer, Optional ByVal optparsProductoClave As String = "") As Boolean
        ' Cargar la forma para pedir el producto, cantidad y unidad
        Dim oFormPedirProducto As New FormPedirProducto
        With oFormPedirProducto
            .TransProdId = Me.LabelTransProdID.Text
            .FolioActual = sFolio
            .TipoTransProd = oModuloMovDetalle.TipoTransProd
            .TipoMovimiento = oModuloMovDetalle.TipoMovimiento
            .MostrarExistencia = False
            If oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Descargas Then
                '.PermitirConsultarProductos = False
                '.PermitirCambiarProducto = False
                '.PermitirLecturaCodigo = False
                .MostrarExistencia = True
                .TipoVerificacionInventario = Inventario.TiposVerificacionInventario.ValidarExistenciaDisponible
            ElseIf pariPartida > 0 Then
                .TipoVerificacionInventario = Inventario.TiposVerificacionInventario.ValidarExistenciaCarga
            End If
            .ModuloMovDetalle = ModuloMovDetalle

            .Partida = pariPartida

            Me.Producto.ProductoClave = optparsProductoClave
            .Producto = Me.Producto

            '.NombreListViewProductos = "ListViewCargas"
            AddHandler .PoblarListaProductos, AddressOf PoblarListViewProductos
            AddHandler .GuardarDetalle, AddressOf GuardarDetalleProductos
            AddHandler .GuardarSKU, AddressOf GuardarSKU

            If optparsProductoClave <> "" Then
                .PermitirConsultarProductos = False
            End If

        End With
        'Me.DesactivarScanner()
        If oFormPedirProducto.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.TextBoxProducto.Focus()
        End If

        With oFormPedirProducto
            RemoveHandler .GuardarDetalle, AddressOf GuardarDetalleProductos
            RemoveHandler .PoblarListaProductos, AddressOf PoblarListViewProductos
            RemoveHandler .GuardarSKU, AddressOf GuardarSKU
            .Dispose()
            '.DetailViewUnidades.Dispose()
            oFormPedirProducto = Nothing
        End With

        'Me.ActivarScanner()
        Return True
    End Function
    Private Function Validar() As Boolean
        If Me.fgDetalles.Rows.Count <= 1 Then
            If oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0044").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "XCarga")), MsgBoxStyle.Critical)
            Else 'Descargas
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0044").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "XDescarga")), MsgBoxStyle.Critical)
            End If
            Return False
        End If

        If oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Descargas Then
            Dim oRow As C1.Win.C1FlexGrid.Row
            For i As Integer = 1 To Me.fgDetalles.Rows.Count - 1
                oRow = Me.fgDetalles.Rows(i)
                If oRow.Node.Children > 0 Then
                    Return True
                End If
            Next
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0044").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "XDescarga")), MsgBoxStyle.Critical)
            Return False
        ElseIf oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then
            Return True
        End If
    End Function
    Private Sub PoblarGrid()
        fgDetalles.Rows.Count = 1
        Dim dt As DataTable
        'If oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then
        Dim sConsulta As String = ""
        sConsulta = "SELECT TPD.Partida, TPD.TransProdDetalleId, PRO.ProductoClave, PRO.Nombre, TPD.Cantidad, TPD.Cantidad1, TPD.TipoUnidad, TPD.CodigoSKU "
        sConsulta &= "FROM TransProdDetalle TPD "
        sConsulta &= "INNER JOIN Producto PRO ON TPD.ProductoClave = PRO.ProductoClave "
        sConsulta &= "WHERE TPD.TransProdId = '" & Me.LabelTransProdID.Text & "' "
        sConsulta &= "ORDER BY PRO.ProductoClave "
        dt = oDBVen.RealizarConsultaSQL(sConsulta, "Cargas")
        Dim sProductoClave As String = ""
        fgDetalles.Redraw = False
        Dim r As C1.Win.C1FlexGrid.Row
        For Each dr As DataRow In dt.Rows
            If sProductoClave <> dr("ProductoClave").ToString Then
                sProductoClave = dr("ProductoClave").ToString
                r = fgDetalles.Rows.Add
                r.IsNode = True
                r.Node.Level = 0
                With fgDetalles
                    .Item(r.Index, 0) = dr("ProductoClave")
                    .Item(r.Index, 1) = dr("Nombre")
                    .Item(r.Index, 3) = dr("Partida")
                End With
            End If
            Dim r2 As C1.Win.C1FlexGrid.Row = fgDetalles.Rows.Add
            r2.IsNode = True
            r2.Node.Level = 1
            With fgDetalles
                .Item(r2.Index, 0) = ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad"))
                .Item(r2.Index, 1) = dr("Cantidad")
                .Item(r2.Index, 2) = dr("Cantidad1")
                .Item(r2.Index, 3) = dr("TransProdDetalleId")
                .Item(r2.Index, 4) = dr("CodigoSKU")
            End With
        Next
        'Else
        '    dt = oDBVen.RealizarConsultaSQL("Select TransProdDetalle.Partida,Producto.ProductoClave, Producto.Nombre, TransProdDetalle.Cantidad, TransProdDetalle.TipoUnidad, (Producto.ProductoClave + str(case When TransProdDetalle.Partida is null then 0 else TransProdDetalle.Partida End)) as Pivote from inventario inner join Producto on Producto.ProductoClave = Inventario.ProductoClave left join (TransProdDetalle inner join TransProd on TransProd.TransProdID=TransProdDetalle.TransProdID and TransProd.Tipo=7 AND (TransProd.TransProdId='" & Me.LabelTransProdID.Text & "')) on Inventario.ProductoClave = TransProdDetalle.ProductoClave where ((Disponible-Apartado-NoDisponible-(case  When Producto.venta=0 then Inventario.Contenido  Else 0 END))>0)  or (not TransProdDetalle.Cantidad is null) ORDER BY Pivote ", "Descarga")
        '    Dim sPivote As String = ""
        '    fgDetalles.Redraw = False
        '    Dim r As C1.Win.C1FlexGrid.Row
        '    For Each dr As DataRow In dt.Rows
        '        If sPivote <> dr("Pivote").ToString Then
        '            sPivote = dr("Pivote").ToString
        '            r = fgDetalles.Rows.Add
        '            r.IsNode = True
        '            r.Node.Level = 0
        '            With fgDetalles
        '                If Not IsDBNull(dr("Partida")) Then
        '                    .Item(r.Index, 0) = dr("Partida")
        '                End If
        '                .Item(r.Index, 1) = dr("ProductoClave")
        '                .Item(r.Index, 2) = dr("Nombre")
        '            End With
        '        End If
        '        If Not IsDBNull(dr("Partida")) Then

        '            Dim r2 As C1.Win.C1FlexGrid.Row = fgDetalles.Rows.Add
        '            r2.IsNode = True
        '            r2.Node.Level = 1
        '            With fgDetalles
        '                If Not IsDBNull(dr("TipoUnidad")) Then
        '                    .Item(r2.Index, 0) = ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad"))
        '                End If
        '                If Not IsDBNull(dr("Cantidad")) Then
        '                    .Item(r2.Index, 1) = dr("Cantidad")
        '                End If
        '            End With
        '        End If
        '    Next
        'End If
        dt.Dispose()
        dt = Nothing
        fgDetalles.Redraw = True
        Me.bHuboCambios = True
    End Sub
    Private Sub ConfiguraGrid()
        With fgDetalles
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 5
            .Cols(0).Caption = refaVista.BuscarMensaje("MsgBox", "PROProductoClave")
            .Cols(1).Caption = refaVista.BuscarMensaje("MsgBox", "PRONombre")
            .Cols(3).Visible = False
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
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            .AutoResize = False
            .Cols(0).Width = 200
            .Cols(1).Width = 240
            .Cols(2).Visible = False
            .Cols(3).Visible = False
            .Cols(4).Visible = False

#End If
        End With
    End Sub
#End Region

    Private Enum TipoEstado
        Navegando = 1
        Creando
        Modificando
        Cancelando
        Consultando
    End Enum

    Private Sub TextBoxProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxProducto.KeyPress
        bHuboCambios = True
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                e.Handled = True
                BuscarProducto()
        End Select
    End Sub

    Private Sub BuscarProducto()
        'Se quitan los espacios porque generaba problemas al no encontrar el producto
        TextBoxProducto.Text = TextBoxProducto.Text.Trim()
        If TextBoxProducto.Text <> "" Then
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
                    Me.ModificarMovimiento(0, Me.Producto.ProductoClave)
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
        Else
            SeleccionarProducto()
        End If
    End Sub

    Private Function ObtienePartida(ByVal clave As String) As Integer
        With fgDetalles
            Dim n As Integer = .Rows.Count
            If n = 1 Then Return -1
            Dim i As Integer
            For i = 1 To n - 1
                If .Rows(i).IsNode AndAlso .Rows(i).Node.Level = 0 Then
                    If .GetData(i, 1).ToString = clave Then
                        Return .GetData(i, 0)
                    End If
                End If
            Next
            Return -1
        End With
    End Function

    Private Sub ContextMenu1_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenu1.Popup
        If eEstado = TipoEstado.Consultando Then Exit Sub
        Try
            If oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then
                'If fgDetalles.Rows.Count <= 1 OrElse fgDetalles.Rows(fgDetalles.Row).Node.Level > 0 Then
                '    ContextMenu1.MenuItems.Clear()
                'Else
                '    Dim bBloquearMenu As Boolean = RegistroEnviado(Me.LabelTransProdID.Text, fgDetalles.GetData(fgDetalles.Row, 0), fgDetalles.GetData(fgDetalles.Row, 1))
                '    If bBloquearMenu Then
                '        Me.MenuItemEliminar.Enabled = False
                '        Me.MenuItemModificar.Enabled = False
                '    Else
                '        Me.MenuItemEliminar.Enabled = True
                '        Me.MenuItemModificar.Enabled = True
                '    End If

                '    If Not ContextMenu1.MenuItems.Contains(Me.MenuItemModificar) Then ContextMenu1.MenuItems.Add(Me.MenuItemModificar)
                '    If Not ContextMenu1.MenuItems.Contains(Me.MenuItemEliminar) Then ContextMenu1.MenuItems.Add(Me.MenuItemEliminar)
                'End If
            ElseIf oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Descargas Then
                ContextMenu1.MenuItems.Clear()
                If fgDetalles.Rows.Count > 1 Then
                    If fgDetalles.Rows(fgDetalles.Row).Node.Level = 0 Then
                        Me.MenuItemEliminar.Enabled = True
                        Dim sConsulta As String = "select count(*) from TransProdDetalle where TransProdId = '" & LabelTransProdID.Text.Trim & "' and ProductoClave = '" & fgDetalles.GetData(fgDetalles.Row, 0) & "' and CodigoSKU = ''"
                        If oDBVen.EjecutarCmdScalarIntSQL(sConsulta) > 0 Then
                            Me.MenuItemModificar.Enabled = True
                            If Not ContextMenu1.MenuItems.Contains(Me.MenuItemModificar) Then ContextMenu1.MenuItems.Add(Me.MenuItemModificar)
                        End If
                    Else
                        Me.MenuItemEliminar.Enabled = True
                    End If

                    'If Me.fgDetalles.Rows(fgDetalles.Row).Node.Children > 0 Then
                    If Not ContextMenu1.MenuItems.Contains(Me.MenuItemEliminar) Then ContextMenu1.MenuItems.Add(Me.MenuItemEliminar)
                    'End If
                End If
            End If

        Catch ex As Exception
            ContextMenu1.MenuItems.Clear()
        End Try
    End Sub

    Private Sub MenuItemModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemModificar.Click
        If fgDetalles.Rows.Count <= 1 Then Exit Sub
        If fgDetalles.Rows(fgDetalles.Row).Node.Level > 0 Then Exit Sub
        If Me.PedirProductoCantidad(fgDetalles.GetData(fgDetalles.Row, 3), fgDetalles.GetData(fgDetalles.Row, 0)) Then
            PoblarProductos(False)
        End If
    End Sub

    Private Sub MenuItemEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemEliminar.Click
        Try
            If fgDetalles.Rows.Count <= 1 Then Exit Sub
            Dim i As Integer
            Dim sConsulta As String
            'Aumento al inventario del camion los productos eliminados
            Dim sFiltro As String

            If fgDetalles.Rows(fgDetalles.Row).Node.Level = 0 Then
                If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0210"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                sFiltro = " and ProductoClave = '" & fgDetalles.GetData(fgDetalles.Row, 0) & "' "
            Else
                If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0211"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                sFiltro = " and TransProdDetalleId = '" & fgDetalles.GetData(fgDetalles.Row, 3) & "' "
            End If

            sConsulta = "select CodigoSKU, ProductoClave, TipoUnidad, Cantidad, Cantidad1 from TransProdDetalle where TransProdId='" & Me.LabelTransProdID.Text & "'" & sFiltro
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(sConsulta, "TransProdDetalle")

            If Me.ModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then
                'Dim productoclave As String = fgDetalles.GetData(fgDetalles.Row, 1)
                'Dim dtInventario As DataTable = oDBVen.RealizarConsultaSQL("select distinct Inventario.ProductoClave, inventario.apartado, inventario.disponible, inventario.nodisponible, inventario.contenido,inventario.Pedido from productodetalle inner join inventario on ProductoDetalle.ProductoClave= Inventario.ProductoClave or ProductoDetalle.ProductoDetClave= Inventario.ProductoClave where productodetalle.productoclave= '" & productoclave & "'", "Inventario")
                'Dim dExistencia As Decimal
                'Dim refMensaje As String
                'Dim resInv As Boolean = True
                'For Each Dr As DataRow In Dt.Rows
                '    If (Not Inventario.ValidarExistenciaDisponibleDec(productoclave, Dr("tipounidad"), Dr("cantidad"), dExistencia, dtInventario, refMensaje, oModuloMovDetalle.TipoTransProd)) Then
                '        resInv = False
                '        Exit For
                '    End If
                'Next
                'If (Not resInv) Then
                '    MsgBox(refaVista.BuscarMensaje("MsgBox", "MsgBoxNoExistencia"))
                '    Exit Sub
                'End If
                'For Each Dr As DataRow In Dt.Rows
                '    Inventario.ActualizarInventarioDec(fgDetalles.GetData(fgDetalles.Row, 1), Dr("tipounidad"), -1 * Dr("cantidad"), ServicesCentral.TiposTransProd.Cargas, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId)
                'Next
            Else
                For Each Dr As DataRow In Dt.Rows
                    SKUInventario.ActualizarSKU(SKUInventario.SKUMovimiento.Incrementar, Dr("CodigoSKU"), Dr("ProductoClave"), Dr("TipoUnidad"), Dr("Cantidad"), Dr("Cantidad1"))
                Next
            End If

            Dt.Dispose()
            Dt = Nothing
            'Borro los registros de la base de datos
            sConsulta = "delete from TransProdDetalle where TransProdId='" & Me.LabelTransProdID.Text & "' " & sFiltro
            oDBVen.EjecutarComandoSQL(sConsulta)
            Me.PoblarProductos(False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub ActualizarInventarioInversa(ByVal TransprodId As String)
    '    Dim s As String
    '    s = "select distinct ProductoClave, partida  from transproddetalle where transprodid='" & TransprodId & "'"
    '    Dim productos As DataTable = oDBVen.RealizarConsultaSQL(s, "a")
    '    For Each filaP As DataRow In productos.Rows
    '        s = "select tipounidad, cantidad  from transproddetalle where transprodid='" & TransprodId & "' and partida=" & filaP("partida").ToString() & " and productoclave='" & filaP("ProductoClave").ToString() & "'"
    '        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(s, "a")
    '        Dim productoclave As String = filaP("ProductoClave").ToString()
    '        If Me.ModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then
    '            Dim dtInventario As DataTable = oDBVen.RealizarConsultaSQL("select distinct Inventario.ProductoClave, inventario.apartado, inventario.disponible, inventario.nodisponible, inventario.contenido from productodetalle inner join inventario on ProductoDetalle.ProductoClave= Inventario.ProductoClave or ProductoDetalle.ProductoDetClave= Inventario.ProductoClave where productodetalle.productoclave= '" & productoclave & "'", "Inventario")
    '            Dim dExistencia As Decimal
    '            Dim refMensaje As String
    '            Dim resInv As Boolean = True
    '            For Each Dr As DataRow In Dt.Rows
    '                If (Not Inventario.ValidarExistenciaDisponibleDec(productoclave, Dr("tipounidad"), Dr("cantidad"), dExistencia, dtInventario, refMensaje)) Then
    '                    resInv = False
    '                    Exit For
    '                End If
    '            Next
    '            If (Not resInv) Then
    '                MsgBox(refaVista.BuscarMensaje("MsgBox", "MsgBoxNoExistencia"))
    '                Exit Sub
    '            End If
    '            For Each Dr As DataRow In Dt.Rows
    '                Inventario.ActualizarInventarioDec(productoclave, Dr("tipounidad"), -1 * Dr("cantidad"), ServicesCentral.TiposTransProd.Cargas, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId)
    '            Next
    '        Else
    '            For Each Dr As DataRow In Dt.Rows
    '                Inventario.ActualizarInventarioDec(productoclave, Dr("tipounidad"), -1 * Dr("cantidad"), ServicesCentral.TiposTransProd.Descargas, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId)
    '            Next
    '        End If
    '        Dt.Dispose()
    '        Dt = Nothing
    '    Next
    '    productos.Dispose()
    '    productos = Nothing
    '    s = "delete from transproddetalle where transprodid='" & TransprodId & "'"
    '    Dim i As Integer = oDBVen.EjecutarComandoSQL(s)
    '    If i = 0 Then
    '        MsgBox("La partida no se pudo eliminar", MsgBoxStyle.Information)
    '    End If

    'End Sub

#Region "Lectura producto"
    Private Sub ActivarScanner()
        'If oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then
#If MOD_TERM <> "PALM" Then
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
#End If
        'End If
    End Sub

    Private Sub DesactivarScanner()
        'If oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then
#If MOD_TERM <> "PALM" Then
        Try
            bScanner.Terminate_Scanner()
            bLector = False
        Catch ex As Exception
            MsgBox("Error while stopping the scanner:" & ex.Message, MsgBoxStyle.Critical)
        End Try
#End If
        'End If
    End Sub

#If MOD_TERM <> "PALM" Then
    Private Sub bScanner_Data_Scanned(ByVal Data As String) Handles bScanner.Data_Scanned

        If PanelDetalle.Visible Then
            Me.TextBoxCodigo.Text = Data
            BuscarCodigo()
            'Else
            '    CargarPorCB(Data.Trim())
        End If
    End Sub
#End If

    'Private Sub CargarPorCB(ByVal datos As String)
    '    If oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then
    '        If datos.Length > 0 Then
    '            Cursor.Current = Cursors.WaitCursor
    '            Application.DoEvents()
    '            Dim tdInsertar As New System.Collections.Generic.Dictionary(Of String, TransProdDetalle)()

    '            If oDBVen.oConexion.State = ConnectionState.Closed Then
    '                oDBVen.oConexion.Open()
    '            End If
    '            Me.Transaccion = oDBVen.oConexion.BeginTransaction()

    '            Dim validado = False

    '            Try
    '                Folio.ObtenerTransProdId(Me.LabelTransProdID.Text)
    '                Dim res As String = ValidarCargaPorCB(datos, tdInsertar)
    '                If (res.Length = 0) And (tdInsertar.Count <= 0) Then
    '                    res = Me.refaVista.BuscarMensaje("MsgBox", "E0671")
    '                End If

    '                If (res.Length = 0) Or (res.IndexOf("$C$") > -1) Then
    '                    res = res.Replace("$C$", "")
    '                    res &= vbCrLf & Me.refaVista.BuscarMensaje("MsgBox", "I0181")
    '                    Me.GenerarEncabezadoConFolio(LabelFolio.Text)
    '                    Dim i = 0
    '                    For Each tpd As TransProdDetalle In tdInsertar.Values
    '                        i += 1
    '                        'tpd.Actualizar(tpd.TransProdDetalleID, ServicesCentral.TiposTransProd.Cargas, New Impuesto(), tpd.Cantidad, 0, tpd.TipoUnidad, 0, ServicesCentral.TiposMovimientos.Entrada)                       
    '                        oDBVen.EjecutarComandoSQL(CrearComandoInsertarProducto(tpd.Cantidad, "", Me.LabelTransProdID.Text, tpd.ProductoClave, tpd.TipoUnidad, tpd.Partida, 1, 0, 0, i))
    '                        Inventario.ActualizarInventarioDec(tpd.ProductoClave, tpd.TipoUnidad, tpd.Cantidad, oModuloMovDetalle.TipoTransProd, oModuloMovDetalle.TipoMovimiento, oVendedor.AlmacenId)
    '                    Next
    '                    validado = True
    '                End If
    '                If res = "$F$" Then
    '                    res = ""
    '                End If
    '                If res.Length > 0 Then
    '                    MessageBox.Show(res)
    '                End If
    '            Catch ex As Exception
    '                MessageBox.Show(ex.Message)
    '            End Try

    '            If validado Then
    '                Me.Transaccion.Commit()
    '            Else
    '                Me.Transaccion.Rollback()
    '            End If
    '            Me.Transaccion.Dispose()
    '            Me.Transaccion = Nothing

    '            If oModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Cargas Then
    '                refaVista.PoblarListView(ListViewCargasDescargas, oDBVen, "ListViewCargas", " and DiaClave='" & oDia.DiaActual & "' ")
    '            Else
    '                refaVista.PoblarListView(ListViewCargasDescargas, oDBVen, "ListViewDescargas", " and DiaClave='" & oDia.DiaActual & "' ")
    '            End If
    '            TextBoxCodigoBarras.Text = ""
    '            Cursor.Current = Cursors.Default
    '        End If
    '    End If
    'End Sub

    Private Function ComandoActualizarDetalle(ByVal refparsTransProdId As String, ByRef refparsTransProdDetalleId As String, ByVal refparsProductoClave As String, ByVal refparsCodigoSKU As String, ByVal refpariTipoUnidad As Integer, ByVal refpariCantidad As Decimal, ByVal refpariCantidad1 As Decimal, ByVal refpariPartida As Integer, ByVal refpariFactor As Integer, ByVal refparfPrecio As Decimal, ByVal refparfImpuesto As Decimal, ByVal refpariConsecutivo As Integer) As String
        Dim sComandoSQL As New System.Text.StringBuilder
        If refpariCantidad = 0 Then
            ' Si ya estaba capturado
            If refparsTransProdDetalleId <> "" Then
                ' Borrarlo
                sComandoSQL.Append("DELETE FROM TransProdDetalle WHERE TransProdId='" & refparsTransProdId & "' AND TransProdDetalleID='" & refparsTransProdDetalleId & "'")
            End If
        Else
            ' La cantidad es valida, guardarla. Si no estaba capturada
            If refparsTransProdDetalleId = "" Then
                ' Obtener un nuevo folio
                refparsTransProdDetalleId = oApp.KEYGEN(refpariConsecutivo)
                ' Crear la cadena para insertar el valor
                sComandoSQL.Append("INSERT INTO TransProdDetalle (TransProdID, TransProdDetalleID, ProductoClave, CodigoSKU, TipoUnidad, Partida, Cantidad, Cantidad1, Precio, Subtotal, Total, MFechaHora, MUsuarioID, Enviado) VALUES (")
                sComandoSQL.Append("'" & refparsTransProdId & "',")
                sComandoSQL.Append("'" & refparsTransProdDetalleId & "',")
                sComandoSQL.Append("'" & refparsProductoClave & "',")
                sComandoSQL.Append("'" & refparsCodigoSKU & "',")
                sComandoSQL.Append(refpariTipoUnidad & ",") ' TipoUnidad
                sComandoSQL.Append(refpariPartida & ",") ' Partida
                sComandoSQL.Append(refpariCantidad & ",") ' Cantidad
                sComandoSQL.Append(refpariCantidad1 & ",") ' Cantidad1
                sComandoSQL.Append(refparfPrecio * refpariFactor & ",") ' Precio
                sComandoSQL.Append((refpariCantidad * refparfPrecio) * refpariFactor & ",") ' Subtotal
                sComandoSQL.Append(((refpariCantidad * refparfPrecio * (1 + (refparfImpuesto / 100)))) * refpariFactor & ",")   ' Total
                sComandoSQL.Append(UniFechaSQL(Now) & ",")
                sComandoSQL.Append("'" & oVendedor.UsuarioId & "',")
                sComandoSQL.Append("0)")
            Else
                ' Actualizar el registro
                sComandoSQL.Append("UPDATE TransProdDetalle SET ")
                sComandoSQL.Append("DescuentoClave=NULL,")
                sComandoSQL.Append("Cantidad=" & refpariCantidad & ",")
                sComandoSQL.Append("Cantidad1=" & refpariCantidad1 & ",")
                sComandoSQL.Append("Precio=" & (refparfPrecio * refpariFactor) & ",")
                sComandoSQL.Append("DescuentoPor=" & refparfImpuesto & ",")
                sComandoSQL.Append("DescuentoImp=" & ((refpariCantidad * refparfPrecio) * refpariFactor * (refparfImpuesto / 100)) & ",")
                sComandoSQL.Append("Subtotal=" & (refpariCantidad * refparfPrecio) * refpariFactor & ",")
                sComandoSQL.Append("Total=" & ((refpariCantidad * refparfPrecio * (1 + (refparfImpuesto / 100)))) * refpariFactor & ",")
                sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",")
                sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 ")
                sComandoSQL.Append("WHERE TransProdID='" & refparsTransProdId & "' AND TransProdDetalleID='" & refparsTransProdDetalleId & "'")
            End If
        End If
        Return sComandoSQL.ToString()
    End Function

    Private Sub GenerarEncabezadoConFolio(ByVal sFolio As String)
        Dim sComandoSQL As New System.Text.StringBuilder
        ' Buscar el TransProdId, para ver si ya existia
        Dim conteo As Integer = Convert.ToInt32(oDBVen.RealizarScalarSQL("SELECT COUNT(*) FROM TransProd WHERE TransProdId='" & Me.LabelTransProdID.Text & "'"))

        If conteo > 0 Then
            ' Ya existe, actualizar
            sComandoSQL.Append("UPDATE TransProd SET ")
            sComandoSQL.Append("Folio='" & sFolio & "',")
            sComandoSQL.Append("PCEModuloMovDetClave='" & Me.ModuloMovDetalle.ModuloMovDetalleClave & "',")
            sComandoSQL.Append("TipoFase=" & ServicesCentral.TiposFasesPedidos.Captura & ",")
            sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",")
            sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 ")
            sComandoSQL.Append("WHERE TransProdId='" & Me.LabelTransProdID.Text & "'")
        Else
            ' No existe, crear
            sComandoSQL.Append("INSERT INTO TransProd (TransProdID,DiaClave,PCEModuloMovDetClave, Folio, Tipo,  TipoFase, TipoMovimiento, FechaCaptura, FechaHoraAlta,Total, MFechaHora, MUsuarioID,Enviado,Escritorio) VALUES (")
            sComandoSQL.Append("'" & Me.LabelTransProdID.Text & "',")
            sComandoSQL.Append("'" & oDia.DiaActual & "',")
            sComandoSQL.Append("'" & Me.ModuloMovDetalle.ModuloMovDetalleClave & "',")
            sComandoSQL.Append("'" & sFolio & "',")
            sComandoSQL.Append(oModuloMovDetalle.TipoTransProd & ",")
            sComandoSQL.Append(ServicesCentral.TiposFasesPedidos.Captura & ",")
            sComandoSQL.Append(oModuloMovDetalle.TipoMovimiento & ",")
            sComandoSQL.Append(UniFechaSQL(PrimeraHora(Now)) & ",")
            sComandoSQL.Append(UniFechaSQL(Now) & ",")
            sComandoSQL.Append("0,")
            sComandoSQL.Append(UniFechaSQL(Now) & ",")
            sComandoSQL.Append("'" & oVendedor.UsuarioId & "',")
            sComandoSQL.Append("0,1)")
        End If
        oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
        sComandoSQL = Nothing
        Return
    End Sub

    'Private Function ValidarCargaPorCB(ByVal Codigo As String, ByRef tdInsert As System.Collections.Generic.Dictionary(Of String, TransProdDetalle)) As String
    '    Dim res As String = ""
    '    Dim bloques As String() = Codigo.Split(New Char() {Chr(13)})
    '    Dim indice As Integer = 0
    '    If bloques.Length > 1 Then
    '        Do While bloques(indice).ToUpper().IndexOf("DEMO") >= 0
    '            indice += 1
    '        Loop
    '    End If
    '    If indice >= bloques.Length Then
    '        indice = bloques.Length - 1
    '    End If
    '    bloques = bloques(indice).Split(New Char() {"|"c})
    '    If bloques.Length >= 4 Then
    '        Dim vendedor As String = bloques(0).Trim()
    '        If oVendedor.Clave.ToUpper() = vendedor.ToUpper() Then
    '            Dim bTmp As Boolean = False
    '            Dim dFecha As DateTime = Date.Now
    '            Try
    '                Dim elementos As String() = bloques(2).Split(New Char() {"/"c})
    '                Dim anio As Integer = Convert.ToInt32(elementos(2).Trim())
    '                Dim mes As Integer = Convert.ToInt32(elementos(1).Trim())
    '                Dim dia As Integer = Convert.ToInt32(elementos(0).Trim())
    '                dFecha = New Date(anio, mes, dia)
    '                If dFecha = oDia.FechaCaptura Then
    '                    bTmp = True
    '                Else
    '                    res = Me.refaVista.BuscarMensaje("MsgBox", "E0670")
    '                End If
    '            Catch ex As Exception
    '                res = Me.refaVista.BuscarMensaje("MsgBox", "E0623").Replace("$0$", "Día").Replace("$1$", "dd/mm/yyyy")
    '            End Try
    '            If bTmp Then
    '                Dim sFolio As String = bloques(1).Trim()
    '                If sFolio.Length > 0 Then
    '                    sFolio = sFolio.Replace("'", "''")
    '                    Dim iTmp = Convert.ToInt32(oDBVen.RealizarScalarSQL("SELECT COUNT(*) FROM TransProd WHERE Folio = '" & sFolio & "'"))
    '                    If iTmp > 0 Then
    '                        If ExistenVisitas() Then
    '                            res = Me.refaVista.BuscarMensaje("MsgBox", "E0079")
    '                            bTmp = False
    '                        Else
    '                            If MessageBox.Show(Me.refaVista.BuscarMensaje("MsgBox", "P0200"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
    '                                bTmp = False
    '                                res = "$F$"
    '                            Else
    '                                Application.DoEvents()
    '                                Dim transprodidT As String = oDBVen.RealizarScalarSQL("SELECT TransProdId FROM TransProd WHERE Folio = '" & sFolio & "'").ToString()
    '                                LabelTransProdID.Text = transprodidT
    '                                ActualizarInventarioInversa(transprodidT)
    '                            End If
    '                        End If
    '                    End If
    '                    If bTmp Then
    '                        Dim malformato As String = ""
    '                        Dim productoIn As String = ""
    '                        For i As Integer = 3 To bloques.Length - 1
    '                            If bloques(i).Trim().Length > 0 Then
    '                                Dim elemento As String() = bloques(i).Split(New Char() {","c})
    '                                If elemento.Length = 2 Then
    '                                    Dim productoclave As String = elemento(0).Trim()
    '                                    Dim cantidad As Integer = 0
    '                                    bTmp = False
    '                                    Try
    '                                        cantidad = Convert.ToInt32(elemento(1))
    '                                        bTmp = True
    '                                    Catch ex As Exception

    '                                    End Try
    '                                    If productoclave.Length = 0 Or cantidad <= 0 Then
    '                                        bTmp = False
    '                                    End If
    '                                    If bTmp Then
    '                                        productoclave = productoclave.Replace("'", "''")
    '                                        If (Producto.ExisteProducto(productoclave)) Then
    '                                            If Not tdInsert.ContainsKey(productoclave) Then
    '                                                Dim tpdTmp As New TransProdDetalle(LabelTransProdID.Text, productoclave, i - 2)
    '                                                tpdTmp.TransProdDetalleID = (i - 2).ToString()
    '                                                tpdTmp.Cantidad = cantidad
    '                                                tpdTmp.TipoUnidad = Producto.RecuperarUnidadBasica(productoclave)
    '                                                tdInsert.Add(productoclave, tpdTmp)
    '                                            Else
    '                                                tdInsert(productoclave).Cantidad += cantidad
    '                                            End If
    '                                        Else
    '                                            productoIn &= productoclave & ","
    '                                        End If
    '                                    Else
    '                                        malformato &= bloques(i) & ","
    '                                    End If
    '                                Else
    '                                    malformato &= bloques(i) & ","
    '                                End If
    '                            End If
    '                        Next

    '                        If malformato.Length > 0 Then
    '                            malformato = malformato.Substring(0, malformato.Length - 1)
    '                            res = Me.refaVista.BuscarMensaje("MsgBox", "E0668").Replace("$0$", malformato)
    '                        End If
    '                        If productoIn.Length > 0 Then
    '                            productoIn = productoIn.Substring(0, productoIn.Length - 1)
    '                            res &= Me.refaVista.BuscarMensaje("MsgBox", "BE0003").Replace("$0$", productoIn)
    '                        End If

    '                        If res.Length > 0 And tdInsert.Count > 0 Then
    '                            res &= "$C$" 'Cadena que indica que se debe continuar la operacion a pesar de los errores
    '                        End If
    '                    End If
    '                Else
    '                    res = Me.refaVista.BuscarMensaje("MsgBox", "E0608").Replace("$0$", Me.refaVista.BuscarMensaje("MsgBox", "XFolio"))
    '                End If
    '            End If
    '        Else
    '            res = Me.refaVista.BuscarMensaje("MsgBox", "E0667")
    '        End If
    '    Else
    '        res = Me.refaVista.BuscarMensaje("MsgBox", "E0671")
    '    End If
    '    Return res
    'End Function

    Private Sub AgregarSKU(ByVal oSKU As SKUInventario)
        Try
            Dim r2 As C1.Win.C1FlexGrid.Row
            Dim sTransProdId As String = ""
            For Each dr As C1.Win.C1FlexGrid.Row In fgDetalles.Rows
                If dr.IsNode Then
                    If dr.Node.Level = 0 Then
                        If fgDetalles.GetData(dr.Index, 0) = oSKU.ProductoClave Then
                            r2 = fgDetalles.Rows.Insert(dr.Index + 1)
                            r2.IsNode = True
                            r2.Node.Level = 1
                            With fgDetalles
                                InsertarDetalleSKU(Me.LabelTransProdID.Text, fgDetalles.GetData(dr.Index, 3), oSKU, sTransProdId)
                                .Item(r2.Index, 0) = ValorReferencia.BuscarEquivalente("UNIDADV", oSKU.TipoUnidad)
                                .Item(r2.Index, 1) = oSKU.Disponible
                                .Item(r2.Index, 2) = oSKU.Cantidad
                                .Item(r2.Index, 3) = sTransProdId
                                .Item(r2.Index, 4) = oSKU.CodigoSKU

                            End With
                            Exit Sub
                        End If
                    End If
                End If
            Next

            'Es un producto nuevo
            Dim nPartida As Integer = 0
            InsertarDetalleSKU(Me.LabelTransProdID.Text, nPartida, oSKU, sTransProdId)

            Dim r As C1.Win.C1FlexGrid.Row = fgDetalles.Rows.Add
            r.IsNode = True
            r.Node.Level = 0
            With fgDetalles
                .Item(r.Index, 0) = oSKU.ProductoClave
                Dim sNombre As String = oDBVen.EjecutarCmdScalarStrSQL("select Nombre from Producto where ProductoClave = '" & oSKU.ProductoClave & "'")
                .Item(r.Index, 1) = sNombre
                .Item(r.Index, 3) = nPartida
            End With

            r2 = fgDetalles.Rows.Add
            r2.IsNode = True
            r2.Node.Level = 1
            With fgDetalles
                .Item(r2.Index, 0) = ValorReferencia.BuscarEquivalente("UNIDADV", oSKU.TipoUnidad)
                .Item(r2.Index, 1) = oSKU.Disponible
                .Item(r2.Index, 2) = oSKU.Cantidad
                .Item(r2.Index, 3) = sTransProdId
                .Item(r2.Index, 4) = oSKU.CodigoSKU
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBoxCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxCodigo.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                e.Handled = True
                BuscarCodigo()
        End Select
        bHuboCambios = True
    End Sub

    Private Sub GuardarSKU(ByVal sSKU As String)
        Dim oSKU As SKUInventario
        oSKU = SKUInventario.Recuperar(sSKU)
        If oSKU.Apartado = 0 Then
            AgregarSKU(oSKU)
        End If
    End Sub

    Private Sub BuscarCodigo()
        If TextBoxCodigo.Text.Trim = String.Empty Then Exit Sub
        Dim bExisteSKU As Boolean
        Dim oSKU As SKUInventario
        If Not BuscarSKU(oSKU) Then
            If oSKU Is Nothing Then
                BuscarCodigoBarras()
            End If
        Else
            AgregarSKU(oSKU)
        End If
        Me.TextBoxCodigo.Text = ""
        Me.TextBoxCodigo.Focus()
    End Sub

    Private Function BuscarSKU(ByRef oSKU As SKUInventario) As Boolean
        oSKU = Nothing
        If SKUInventario.ExisteSKU(TextBoxCodigo.Text.Trim) Then
            oSKU = SKUInventario.Recuperar(TextBoxCodigo.Text.Trim)
            If oSKU.Disponible = 0 Or oSKU.Apartado > 0 Or oSKU.Cantidad = 0 Or oSKU.Apartado1 > 0 Then
                'TODO: Recuperar mensaje
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0741"), MsgBoxStyle.Exclamation)
                Return False
            Else
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub BuscarCodigoBarras()
        If TextBoxCodigo.Text.Trim <> String.Empty Then
            Dim sProductoClave As String = Me.Producto.BuscarCodigoBarras(Me.TextBoxCodigo.Text)
            If sProductoClave <> String.Empty Then
                If Me.PedirProductoCantidad(0, sProductoClave) Then
                    Me.PoblarProductos(False)
                End If
            Else
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0273").Replace("$0$", refaVista.BuscarMensaje("MsgBox", "XProducto")), MsgBoxStyle.Exclamation)
                Me.TextBoxCodigo.SelectionStart = 0
                Me.TextBoxCodigo.SelectionLength = Len(Me.TextBoxCodigo.Text)
                Me.TextBoxCodigo.Focus()
            End If
        End If
        Me.TextBoxCodigo.Text = String.Empty
    End Sub
#End Region

    Private Sub fgDetalles_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fgDetalles.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                If fgDetalles.Rows.Count <= 1 Then Exit Sub
                If fgDetalles.Rows(fgDetalles.Row).Node.Level > 0 Then Exit Sub
                If Me.PedirProductoCantidad(fgDetalles.GetData(fgDetalles.Row, 0), fgDetalles.GetData(fgDetalles.Row, 1)) Then
                    PoblarProductos(False)
                End If
        End Select
    End Sub

    Private Sub ContextMenu2_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenu2.Popup
        MostrarContext()
    End Sub

    Private Sub MostrarContext()
        If eEstado = TipoEstado.Consultando Then Exit Sub
        If eEstado = TipoEstado.Creando Or eEstado = TipoEstado.Modificando Then
            DesactivarScanner()
        End If

        ContextMenu1.Show(Me, Control.MousePosition)
        If eEstado = TipoEstado.Creando Or eEstado = TipoEstado.Modificando Then
            ActivarScanner()
        End If
    End Sub

    'Private Sub TextBoxCodigoBarras_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxCodigoBarras.KeyPress
    '    Select Case e.KeyChar
    '        Case Microsoft.VisualBasic.ChrW(Keys.Enter)
    '            CargarPorCB(TextBoxCodigoBarras.Text.Trim())
    '    End Select
    '    bHuboCambios = True
    'End Sub

    Private Sub TextBoxNotas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        bHuboCambios = True
    End Sub

    Private Sub TextBoxCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxCodigo.TextChanged

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

    Private Sub ButtonEliminarLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminarLista.Click
        If ListViewCargasDescargas.SelectedIndices.Count <= 0 Then Exit Sub
        If Not ValidarEnviado() Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0596"), MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0001"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            EliminarMovimiento()
        End If
    End Sub

    Private Sub EliminarMovimiento()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim refListViewItemSel As ListViewItem = ListViewCargasDescargas.Items(ListViewCargasDescargas.SelectedIndices(0))
            Dim sTransProdId As String = refListViewItemSel.SubItems(PosTransProdID).Text
            Dim sConsulta As String = "select TransProdDetalleId, CodigoSKU, ProductoClave, TipoUnidad, Cantidad, Cantidad1 from TransProdDetalle where TransProdId = '" & sTransProdId & "'"
            Dim dtDetalle As DataTable = oDBVen.RealizarConsultaSQL(sConsulta, "TransProdDetalle")

            If dtDetalle.Rows.Count > 0 Then
                For Each refDataRow As DataRow In dtDetalle.Rows
                    SKUInventario.ActualizarSKU(SKUInventario.SKUMovimiento.Incrementar, refDataRow("CodigoSKU"), refDataRow("ProductoClave"), refDataRow("TipoUnidad"), refDataRow("Cantidad"), refDataRow("Cantidad1"))
                Next
            End If

            oDBVen.EjecutarComandoSQL("DELETE FROM TransProdDetalle WHERE TransProdId='" & sTransProdId & "'")
            oDBVen.EjecutarComandoSQL("DELETE FROM TransProd WHERE TransProdId='" & sTransProdId & "'")
            refaVista.PoblarListView(ListViewCargasDescargas, oDBVen, "ListViewDescargas", " and DiaClave='" & oDia.DiaActual & "' ")
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
