Public Class FormDevolucionClienteDetalle
    Inherits System.Windows.Forms.Form
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal TransProdFolio As String, ByVal TransProdId As String, ByVal parsVisitaClave As String, ByVal oMov As Movimiento, ByVal oMod As Modo, ByVal oMMDA As Modulos.GrupoModuloMovDetalle, ByVal Nuevo As Boolean, ByVal paroCliente As Cliente)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        If g_SO = SO.WindowsCE Then
            Call InTheHand.Windows.Forms.ContextMenuHelper.HookAllControls(Me.Controls)
        End If
        'Add any initialization after the InitializeComponent() call
        Me.oModo = oMod
        Me.oMovimiento = oMov
        Me.oMMD = oMMDA
        Me.sFolio = TransProdFolio
        Me.sTransprodID = TransProdId
        Me.bNuevo = Nuevo
        Me.TextBoxFolio.Text = sFolio
        Me.TextBoxFecha.Text = Format(Now, "dd/MM/yyyy")
        Me.VisitaClave = parsVisitaClave
        oCliente = paroCliente
        fgMovimientos.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemEliminar Is Nothing Then Me.MenuItemEliminar.Dispose()
        If Not Me.MenuItemModificar Is Nothing Then Me.MenuItemModificar.Dispose()
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        If Not Me.fgMovimientos Is Nothing Then
            Me.fgMovimientos.ContextMenu = Nothing
            Me.fgMovimientos.Dispose()
        End If
        Me.fgMovimientos = Nothing
        If Not Me.ContextMenu1 Is Nothing Then Me.ContextMenu1.Dispose()
        If Not Me.ContextMenu2 Is Nothing Then Me.ContextMenu2.Dispose()
#If MOD_TERM <> "PALM" Then
        If Not bScanner Is Nothing Then Me.bScanner.Dispose()
        Me.bScanner = Nothing
#End If
        Me.Producto = Nothing
        Me.oVista = Nothing
        Me.oCliente = Nothing
        Me.oMMD = Nothing
        ContextMenu1 = Nothing
        ContextMenu2 = Nothing
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemEliminar As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBoxCodigo As System.Windows.Forms.TextBox
    Friend WithEvents LabelCodigo As System.Windows.Forms.Label
    Friend WithEvents TextBoxFactura As System.Windows.Forms.TextBox
    Friend WithEvents LabelFactura As System.Windows.Forms.Label
    Friend WithEvents fgMovimientos As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents ComboBoxMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxProducto As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxFecha As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxFolio As System.Windows.Forms.TextBox
    Friend WithEvents LabelMotivo As System.Windows.Forms.Label
    Friend WithEvents LabelProducto As System.Windows.Forms.Label
    Friend WithEvents LabelFecha As System.Windows.Forms.Label
    Friend WithEvents LabelFolio As System.Windows.Forms.Label
    Friend WithEvents ContextMenu2 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemModificar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDevolucionClienteDetalle))
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItemEliminar = New System.Windows.Forms.MenuItem
        Me.MenuItemModificar = New System.Windows.Forms.MenuItem
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TextBoxCodigo = New System.Windows.Forms.TextBox
        Me.LabelCodigo = New System.Windows.Forms.Label
        Me.TextBoxFactura = New System.Windows.Forms.TextBox
        Me.LabelFactura = New System.Windows.Forms.Label
        Me.fgMovimientos = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ContextMenu2 = New System.Windows.Forms.ContextMenu
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ButtonBuscar = New System.Windows.Forms.Button
        Me.ComboBoxMotivo = New System.Windows.Forms.ComboBox
        Me.TextBoxProducto = New System.Windows.Forms.TextBox
        Me.TextBoxFecha = New System.Windows.Forms.TextBox
        Me.TextBoxFolio = New System.Windows.Forms.TextBox
        Me.LabelMotivo = New System.Windows.Forms.Label
        Me.LabelProducto = New System.Windows.Forms.Label
        Me.LabelFecha = New System.Windows.Forms.Label
        Me.LabelFolio = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TextBoxCodigo)
        Me.Panel1.Controls.Add(Me.LabelCodigo)
        Me.Panel1.Controls.Add(Me.TextBoxFactura)
        Me.Panel1.Controls.Add(Me.LabelFactura)
        Me.Panel1.Controls.Add(Me.fgMovimientos)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.ButtonBuscar)
        Me.Panel1.Controls.Add(Me.ComboBoxMotivo)
        Me.Panel1.Controls.Add(Me.TextBoxProducto)
        Me.Panel1.Controls.Add(Me.TextBoxFecha)
        Me.Panel1.Controls.Add(Me.TextBoxFolio)
        Me.Panel1.Controls.Add(Me.LabelMotivo)
        Me.Panel1.Controls.Add(Me.LabelProducto)
        Me.Panel1.Controls.Add(Me.LabelFecha)
        Me.Panel1.Controls.Add(Me.LabelFolio)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'TextBoxCodigo
        '
        Me.TextBoxCodigo.Location = New System.Drawing.Point(91, 109)
        Me.TextBoxCodigo.Name = "TextBoxCodigo"
        Me.TextBoxCodigo.Size = New System.Drawing.Size(144, 23)
        Me.TextBoxCodigo.TabIndex = 20
        '
        'LabelCodigo
        '
        Me.LabelCodigo.Location = New System.Drawing.Point(11, 109)
        Me.LabelCodigo.Name = "LabelCodigo"
        Me.LabelCodigo.Size = New System.Drawing.Size(80, 20)
        Me.LabelCodigo.Text = "LabelCodigo"
        '
        'TextBoxFactura
        '
        Me.TextBoxFactura.Location = New System.Drawing.Point(91, 63)
        Me.TextBoxFactura.Name = "TextBoxFactura"
        Me.TextBoxFactura.Size = New System.Drawing.Size(118, 23)
        Me.TextBoxFactura.TabIndex = 16
        '
        'LabelFactura
        '
        Me.LabelFactura.Location = New System.Drawing.Point(11, 63)
        Me.LabelFactura.Name = "LabelFactura"
        Me.LabelFactura.Size = New System.Drawing.Size(80, 20)
        Me.LabelFactura.Text = "LabelFactura"
        '
        'fgMovimientos
        '
        Me.fgMovimientos.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fgMovimientos.AllowEditing = False
        Me.fgMovimientos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fgMovimientos.AutoResize = True
        Me.fgMovimientos.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor
        Me.fgMovimientos.AutoSearchDelay = 2
        Me.fgMovimientos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.fgMovimientos.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgMovimientos.Clip = ""
        Me.fgMovimientos.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.fgMovimientos.Col = 1
        Me.fgMovimientos.ColSel = 1
        Me.fgMovimientos.ComboList = Nothing
        Me.fgMovimientos.ContextMenu = Me.ContextMenu2
        Me.fgMovimientos.EditMask = Nothing
        Me.fgMovimientos.ExtendLastCol = False
        Me.fgMovimientos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.fgMovimientos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgMovimientos.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgMovimientos.LeftCol = 1
        Me.fgMovimientos.Location = New System.Drawing.Point(6, 157)
        Me.fgMovimientos.Name = "fgMovimientos"
        Me.fgMovimientos.Redraw = True
        Me.fgMovimientos.Row = 1
        Me.fgMovimientos.RowSel = 1
        Me.fgMovimientos.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.fgMovimientos.ScrollTrack = True
        Me.fgMovimientos.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgMovimientos.ShowCursor = False
        Me.fgMovimientos.ShowSort = True
        Me.fgMovimientos.Size = New System.Drawing.Size(229, 104)
        Me.fgMovimientos.StyleInfo = resources.GetString("fgMovimientos.StyleInfo")
        Me.fgMovimientos.SupportInfo = "BgEFAZ0BnQBzAIUB+QBsAI4AigBCAU0BAwFCAUcBngDnACIBtQBUAHwApQCgAF4AOgALAUYAcwA3Ad8Ar" & _
            "wAsAQsB"
        Me.fgMovimientos.TabIndex = 21
        Me.fgMovimientos.TopRow = 1
        '
        'ContextMenu2
        '
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonRegresar.Location = New System.Drawing.Point(84, 264)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 25
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonContinuar.Location = New System.Drawing.Point(6, 264)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 24
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(211, 86)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(24, 20)
        Me.ButtonBuscar.TabIndex = 18
        Me.ButtonBuscar.Text = "..."
        '
        'ComboBoxMotivo
        '
        Me.ComboBoxMotivo.Location = New System.Drawing.Point(91, 132)
        Me.ComboBoxMotivo.Name = "ComboBoxMotivo"
        Me.ComboBoxMotivo.Size = New System.Drawing.Size(144, 23)
        Me.ComboBoxMotivo.TabIndex = 19
        '
        'TextBoxProducto
        '
        Me.TextBoxProducto.Location = New System.Drawing.Point(91, 86)
        Me.TextBoxProducto.Name = "TextBoxProducto"
        Me.TextBoxProducto.Size = New System.Drawing.Size(118, 23)
        Me.TextBoxProducto.TabIndex = 17
        '
        'TextBoxFecha
        '
        Me.TextBoxFecha.Enabled = False
        Me.TextBoxFecha.Location = New System.Drawing.Point(91, 40)
        Me.TextBoxFecha.Name = "TextBoxFecha"
        Me.TextBoxFecha.Size = New System.Drawing.Size(118, 23)
        Me.TextBoxFecha.TabIndex = 15
        '
        'TextBoxFolio
        '
        Me.TextBoxFolio.Enabled = False
        Me.TextBoxFolio.Location = New System.Drawing.Point(91, 17)
        Me.TextBoxFolio.Name = "TextBoxFolio"
        Me.TextBoxFolio.Size = New System.Drawing.Size(118, 23)
        Me.TextBoxFolio.TabIndex = 14
        '
        'LabelMotivo
        '
        Me.LabelMotivo.Location = New System.Drawing.Point(11, 132)
        Me.LabelMotivo.Name = "LabelMotivo"
        Me.LabelMotivo.Size = New System.Drawing.Size(80, 20)
        Me.LabelMotivo.Text = "LabelMotivo"
        '
        'LabelProducto
        '
        Me.LabelProducto.Location = New System.Drawing.Point(11, 86)
        Me.LabelProducto.Name = "LabelProducto"
        Me.LabelProducto.Size = New System.Drawing.Size(80, 20)
        Me.LabelProducto.Text = "LabelProducto"
        '
        'LabelFecha
        '
        Me.LabelFecha.Location = New System.Drawing.Point(11, 40)
        Me.LabelFecha.Name = "LabelFecha"
        Me.LabelFecha.Size = New System.Drawing.Size(80, 20)
        Me.LabelFecha.Text = "LabelFecha"
        '
        'LabelFolio
        '
        Me.LabelFolio.Location = New System.Drawing.Point(11, 17)
        Me.LabelFolio.Name = "LabelFolio"
        Me.LabelFolio.Size = New System.Drawing.Size(72, 24)
        Me.LabelFolio.Text = "LabelFolio"
        '
        'FormDevolucionClienteDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormDevolucionClienteDetalle"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "ENUMS"
    Public Enum Movimiento
        Capturar = 1
        Modificar = 2
        Eliminar = 3
    End Enum

    Public Enum Modo
        Modificable = 1
        SoloLectura = 2
    End Enum
#End Region

#Region "VARIABLES"
    Private Producto As Producto
    Private oMMD As Modulos.GrupoModuloMovDetalle
    Private oVista As Vista
    Private oMovimiento As Movimiento
    Private oModo As Modo
    Private sFolio, sTransprodID As String
    Private bHayCambios As Boolean = False
    Private bNuevo As Boolean
    Private bFin As Boolean = False
    Private ClaveProd, Partida As String
    Private GrupoActual, VisitaClave As String
    Private blnCambiandoGrid As Boolean = False
    Private oCliente As Cliente

#If MOD_TERM <> "PALM" Then
    Private WithEvents bScanner As New HANDHELD.CScanner
#End If

    Private bLector As Boolean = False
    Private bEsConsignacion As Boolean = False

#End Region

#Region "PROPIEDADES"
    Public Property Transaccion() As SqlServerCe.SqlCeTransaction
        Get
            Return oDBVen.Transaccion
        End Get
        Set(ByVal Value As SqlServerCe.SqlCeTransaction)
            oDBVen.Transaccion = Value
        End Set
    End Property
    Public Property EsConsignacion() As Boolean
        Get
            Return bEsConsignacion
        End Get
        Set(ByVal Value As Boolean)
            bEsConsignacion = Value
        End Set
    End Property
#End Region

#Region "MIS METODOS"
    Private Sub EliminaAjuste()
        Try
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select productoclave, tipounidad, cantidad from transproddetalle where transprodid='" & sTransprodID & "'", "Consulta")
            Dim sError As String = ""
            Dim bValidaExistencia As Boolean = True
            Dim bien As Boolean = True
            Dim dExist As Decimal = 0
            For Each Dr As DataRow In Dt.Rows
                If GrupoActual = "Venta" Then
                    If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                        bValidaExistencia = Inventario.ValidarExistenciaDifNoDiponibledec(Dr("productoclave"), Dr("tipounidad"), Dr("cantidad"), dExist, sError)
                    Else
                        bValidaExistencia = Inventario.ValidarExistenciaDisponibleDec(Dr("productoclave"), Dr("tipounidad"), Dr("cantidad"), dExist, sError)
                    End If

                Else
                    bValidaExistencia = Inventario.ValidarExistenciaNoDisponible(Dr("productoclave"), Dr("tipounidad"), Dr("cantidad"), dExist, sError)
                End If
                If (bValidaExistencia) Then 'cant >= Convert.ToDouble(Dr("cantidad"))) Then
                    Inventario.ActualizarInventarioDec(Dr("productoclave"), Dr("tipounidad"), Dr("cantidad"), ServicesCentral.TiposTransProd.DevolucionesCliente, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, , GrupoActual)
                Else
                    bien = False
                    Exit For
                End If

                'Eliminar Saldo de Envases del Cliente
                If oCliente.Prestamo Then
                    ProductoPrestamoCli.ActulizarProductoPrestamoCli(oCliente.ClienteClave, Dr("ProductoClave"), -1 * Dr("Cantidad"), Dr("TipoUnidad"), 0, ServicesCentral.TiposTransProd.DevolucionesCliente, oMMD.TipoMovimiento)
                End If
            Next
            Dt.Dispose()
            If (bien) Then
                oDBVen.EjecutarComandoSQL("delete from transproddetalle where transprodid='" & sTransprodID & "'")
                oDBVen.EjecutarComandoSQL("delete from transprod where transprodid='" & sTransprodID & "'")
                Transaccion.Commit()
            Else
                Transaccion.Rollback()
                Throw New Exception(oVista.BuscarMensaje("Mensajes", "E0029"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function LlenaCombo() As Boolean
        With ComboBoxMotivo
            Dim aGrupo As New ArrayList
            If Not EsConsignacion Then
                aGrupo.Add("No Venta")
                aGrupo.Add("Venta")
            Else
                aGrupo.Add("Consignacion")
            End If
            Dim aValor As ArrayList = ValorReferencia.RecuperaVARVGrupo("TRPMOT", aGrupo)
            If Not aValor Is Nothing AndAlso aValor.Count > 0 Then
                .DataSource = aValor
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                .SelectedIndex = 0
            End If
        End With

        If Not ComboBoxMotivo.SelectedValue Is Nothing Then
            GrupoActual = ValorReferencia.RecuperaGrupo("TRPMOT", ComboBoxMotivo.SelectedValue)
            ComboBoxMotivo.Tag = ComboBoxMotivo.SelectedValue
            Return True
        End If
        Return False
    End Function

    Private Sub HabilitarBotones(ByVal bHabilitar As Boolean)
        Me.ButtonBuscar.Enabled = bHabilitar
        Me.ButtonContinuar.Enabled = bHabilitar
        Me.ButtonRegresar.Enabled = bHabilitar
    End Sub

    Private Sub GuardaMotivo()
        If Not ValidarDatos() Then Exit Sub
        If Not EsConsignacion Then
            oDBVen.EjecutarComandoSQL("update transprod set tipomotivo=" & ComboBoxMotivo.SelectedValue & ", Notas='" & Me.TextBoxFactura.Text & "', mfechahora=" & UniFechaSQL(Now) & ", musuarioid='" & oVendedor.UsuarioId & "',Enviado=0 where transprodid='" & sTransprodID & "'")
        End If
        HabilitarBotones(False)
        If EsConsignacion Then
            Transaccion.Rollback()
        Else
            Transaccion.Commit()
        End If
        If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
        Me.Transaccion = Nothing

        If oVendedor.motconfiguracion.MensajeImpresion Then
            If MsgBox(oVista.BuscarMensaje("Mensajes", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, sTransprodID, ServicesCentral.TiposTransProd.DevolucionesCliente, ServicesCentral.TiposTransProd.DevolucionesCliente, oCliente, VisitaClave)
            End If
        End If
      
    End Sub

    Private Sub AgregarMovimiento()
        If Me.PedirProductoCantidad(0) Then
            Me.bHayCambios = True
            PoblarProductos()
        End If
    End Sub

    Private Sub PoblarProductos()
        blnCambiandoGrid = True
        fgMovimientos.Rows.Count = 1
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim dt As DataTable = oVista.TablaListView(oDBVen, "ListViewProductos", " and TransProdDetalle.TransProdId='" & sTransprodID & "' order by transproddetalle.partida ")
        Dim sPartida As String = ""
        fgMovimientos.Redraw = False
        Dim r As C1.Win.C1FlexGrid.Row
        For Each dr As DataRow In dt.Rows
            If sPartida <> dr("Partida").ToString Then
                sPartida = dr("Partida").ToString
                r = fgMovimientos.Rows.Add
                r.IsNode = True
                r.Node.Level = 0
                With fgMovimientos
                    .Item(r.Index, 0) = dr("Partida")
                    .Item(r.Index, 1) = dr("ProductoClave")
                    .Item(r.Index, 2) = dr("Nombre")
                End With
            End If
            Dim r2 As C1.Win.C1FlexGrid.Row = fgMovimientos.Rows.Add
            r2.IsNode = True
            r2.Node.Level = 1
            With fgMovimientos
                .Item(r2.Index, 0) = ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad"))
                .Item(r2.Index, 1) = dr("Cantidad")
            End With
        Next
        dt.Dispose()
        fgMovimientos.Redraw = True
        blnCambiandoGrid = False
        If fgMovimientos.Rows.Count > 1 Then
            fgMovimientos.Row = 1
            Partida = fgMovimientos.GetData(fgMovimientos.Row, 0)
            ClaveProd = fgMovimientos.GetData(fgMovimientos.Row, 1)
        End If
        Me.PrepararMovimiento()
        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub PrepararMovimiento(Optional ByVal parbBorrarProducto As Boolean = True)
        Dim iProxNumPartida As Integer = 1
        If parbBorrarProducto Then
            TextBoxProducto.Text = ""
            TextBoxCodigo.Text = ""
            If Not TextBoxProducto.Focused Then
                TextBoxProducto.Focus()
            End If
        Else
            'BuscarProductoXId(DataViewBusqProdXId, TextBoxProducto.Text, LabelInfo.Text)
        End If
        ' Quitar cualquier selección de productos
        'If ListViewProductos.Items.Count > 0 Then
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

    Private Sub PoblarGridProductos(ByRef refparoFormPedirProducto As FormPedirProducto, ByVal aListaEsquemas As ArrayList)
        With refparoFormPedirProducto
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            .fgProductos.Redraw = False
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
            ConfiguraGridfgProductos(.fgProductos)
            .fgProductos.Redraw = True
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End With
    End Sub

    Private Sub ConfiguraGridfgProductos(ByRef refparoFlexGrid As C1.Win.C1FlexGrid.C1FlexGrid)
        With refparoFlexGrid
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor
            .Cols.Fixed = 0
            .Cols.Count = 2
            .Cols(0).Caption = oVista.BuscarMensaje("Mensajes", "Producto")
            .Cols(1).Caption = oVista.BuscarMensaje("Mensajes", "Nombre")
            .Cols(0).Width = 100
            .Cols(1).Width = 280
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .AutoResize = True
        End With
    End Sub

    Private Sub GuardarDetalleProductos(ByRef refparoFormPedirProducto As FormPedirProducto)
        Dim sComandoSQL As New System.Text.StringBuilder
        Try
            ' TODO: Verificar si tiene promociones
            ' Determinar el numero de partida
            If refparoFormPedirProducto.Partida = 0 Then
                ' Es una nueva partida, obtenerla
                If Not Folio.ObtenerTransProdPartida(refparoFormPedirProducto.TransProdId, refparoFormPedirProducto.Producto.ProductoClave, refparoFormPedirProducto.Partida) Then
                    Exit Try
                End If
            End If
            Dim refProducto As FormPedirProducto.ItemUnidad
            Dim nPrecio As Single = 0
            Dim dCantidad As Decimal
            Dim nImpuesto As Single = 15
            ' Obtener los productos a actualizar
            Dim dCantidadAnterior As Decimal = 0
            Dim dExistencia As Decimal = 0
            Dim dtInventario As DataTable
            Dim sError As String
            Dim bExistencia As Boolean = True
            Dim sConsulta As String
            sConsulta = "select INV.ProductoClave, INV.Disponible, INV.NoDisponible, INV.Apartado, INV.Contenido "
            sConsulta &= "from ProductoDetalle PRD "
            sConsulta &= "inner join Inventario INV on INV.ProductoClave = PRD.ProductoDetClave and PRD.ProductoClave ='" & refparoFormPedirProducto.Producto.ProductoClave & "' "
            dtInventario = oDBVen.RealizarConsultaSQL(sConsulta, "inventario")
            For Each refProducto In refparoFormPedirProducto.PanelUnidades.Controls
                With refProducto
                    dCantidad = refProducto.NumericCantidad.DecimalValue
                    dCantidadAnterior = refProducto.ValorAnterior
                    Inventario.ObtenerCantidadAActualizar(oMMD.TipoMovimiento, dCantidad, dCantidadAnterior)
                    If (dCantidad < 0) Then
                        If GrupoActual = "Venta" Then
                            If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                                bExistencia = Inventario.ValidarExistenciaDifNoDiponibleDec(refparoFormPedirProducto.Producto.ProductoClave, .TipoUnidad, Math.Abs(dCantidad), dExistencia, dtInventario, sError)
                            Else
                                bExistencia = Inventario.ValidarExistenciaDisponibleDec(refparoFormPedirProducto.Producto.ProductoClave, .TipoUnidad, Math.Abs(dCantidad), dExistencia, dtInventario, sError)
                            End If

                        ElseIf GrupoActual = "No Venta" Then
                            bExistencia = Inventario.ValidarExistenciaNoDisponible(refparoFormPedirProducto.Producto.ProductoClave, .TipoUnidad, Math.Abs(dCantidad), dtInventario)
                        End If
                        If Not bExistencia Then Exit For
                    End If

                End With
            Next
            dtInventario.Dispose()
            If bExistencia Then
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
                                ' La cantidad es valida, guardarla. Si no estaba capturada
                                If .TransProdDetalleID = "" Then
                                    ' Obtener un nuevo folio
                                    If Not Folio.ObtenerTransProdDetalleId(refparoFormPedirProducto.TransProdId, .TransProdDetalleID) Then
                                        Exit For
                                    End If
                                    ' Crear la cadena para insertar el valor
                                    sComandoSQL.Append("INSERT INTO TransProdDetalle (TransProdID, TransProdDetalleID, ProductoClave, TipoUnidad, Partida, Cantidad, Precio, Subtotal, Total, MFechaHora, MUsuarioID) VALUES (")
                                    sComandoSQL.Append("'" & refparoFormPedirProducto.TransProdId & "',")
                                    sComandoSQL.Append("'" & .TransProdDetalleID & "',")
                                    sComandoSQL.Append("'" & refparoFormPedirProducto.Producto.ProductoClave & "',")
                                    sComandoSQL.Append(.TipoUnidad & ",") ' TipoUnidad
                                    sComandoSQL.Append(refparoFormPedirProducto.Partida & ",") ' Partida
                                    sComandoSQL.Append(dCantidad & ",") ' Cantidad
                                    sComandoSQL.Append(nPrecio * .Factor & ",") ' Precio
                                    sComandoSQL.Append((dCantidad * nPrecio) * .Factor & ",") ' Subtotal
                                    sComandoSQL.Append(((dCantidad * nPrecio * (1 + (nImpuesto / 100)))) * .Factor & ",")  ' Total
                                    sComandoSQL.Append(UniFechaSQL(Now) & ",")
                                    sComandoSQL.Append("'" & oVendedor.UsuarioId & "')")
                                Else
                                    ' Actualizar el registro
                                    sComandoSQL.Append("UPDATE TransProdDetalle SET ")
                                    sComandoSQL.Append("DescuentoClave=NULL,")
                                    sComandoSQL.Append("Cantidad=" & dCantidad & ",")
                                    sComandoSQL.Append("Precio=" & (nPrecio * .Factor) & ",")
                                    sComandoSQL.Append("DescuentoPor=" & nImpuesto & ",")
                                    sComandoSQL.Append("DescuentoImp=" & ((dCantidad * nPrecio) * .Factor * (nImpuesto / 100)) & ",")
                                    sComandoSQL.Append("Subtotal=" & (dCantidad * nPrecio) * .Factor & ",")
                                    sComandoSQL.Append("Total=" & ((dCantidad * nPrecio * (1 + (nImpuesto / 100)))) * .Factor & ",")
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
                        Inventario.ObtenerCantidadAActualizar(oMMD.TipoMovimiento, dCantidad, dCantidadAnterior)

                        Inventario.ActualizarInventarioDec(refparoFormPedirProducto.Producto.ProductoClave, .TipoUnidad, dCantidad, oMMD.TipoTransProd, oMMD.TipoMovimiento, oVendedor.AlmacenId, , GrupoActual)

                    End With

                    'Crear Saldo de Envases del Cliente
                    If oCliente.Prestamo Then
                        ProductoPrestamoCli.ActulizarProductoPrestamoCli(oCliente.ClienteClave, refparoFormPedirProducto.Producto.ProductoClave, dCantidad, refProducto.TipoUnidad, 0, oMMD.TipoTransProd, oMMD.TipoMovimiento)
                    End If
                Next
            Else
                MsgBox(oVista.BuscarMensaje("Mensajes", "E0029"), MsgBoxStyle.Information)
            End If
        Catch ExcA As SqlServerCe.SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarProducto")
        End Try
        sComandoSQL = Nothing
    End Sub

    Private Sub LlenaDetalles()
        Try
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select folio, fechacaptura, tipomotivo,notas from transprod where transprodid='" & sTransprodID & "'", "busqueda")
            Dim Dr As DataRow = Dt.Rows(0)
            TextBoxFolio.Text = Dr("folio")
            TextBoxFecha.Text = Format(Dr("fechacaptura"), "dd/MM/yyyy")
            Me.TextBoxFactura.Text = Dr("Notas")
            ComboBoxMotivo.SelectedValue = Dr("tipomotivo").ToString
            ComboBoxMotivo.Tag = Dr("tipomotivo").ToString()
            GrupoActual = ValorReferencia.RecuperaGrupo("TRPMOT", ComboBoxMotivo.SelectedValue)
            Dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function ReversaInventario(ByVal sGrupoActual As String) As Boolean
        Dim resul As Boolean = True
        If sGrupoActual = "No Venta" Then 'Reversa del Caso 3 (Aplico 6 y luego 4)
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select productoclave, tipounidad, cantidad from TransProdDetalle where TransProdId='" & sTransprodID & "' order by Partida, ProductoClave", "No Venta")
            Dim dtInventario As DataTable
            Dim bExistencia As Boolean = True
            Dim pclave As String = ""
            Dim dExistencia As Decimal
            Dim sTemp As String
            For Each Dr As DataRow In Dt.Rows
                If (pclave <> Dr("productoclave").ToString()) Then
                    Dim sConsulta As String
                    sConsulta = "select INV.ProductoClave, INV.Disponible, INV.NoDisponible, INV.Apartado, INV.Contenido "
                    sConsulta &= "from ProductoDetalle PRD "
                    sConsulta &= "inner join Inventario INV on INV.ProductoClave = PRD.ProductoDetClave and "
                    sConsulta &= "PRD.PRUTipoUnidad = " & Convert.ToInt32(Dr("TipoUnidad")) & " and PRD.ProductoClave ='" & Dr("ProductoClave").ToString() & "' "
                    dtInventario = oDBVen.RealizarConsultaSQL(sConsulta, "Inventario")
                    pclave = Dr("productoclave").ToString()
                End If
                If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                    bExistencia = Inventario.ValidarExistenciaDifNoDiponibleDec(Dr("productoclave").ToString(), Convert.ToInt32(Dr("tipounidad")), Math.Abs(Convert.ToDecimal(Dr("cantidad"))), dExistencia, dtInventario, sTemp)
                Else
                    bExistencia = Inventario.ValidarExistenciaDisponibleDec(Dr("productoclave").ToString(), Convert.ToInt32(Dr("tipounidad")), Math.Abs(Convert.ToDecimal(Dr("cantidad"))), dExistencia, dtInventario, sTemp)
                End If

                If Not bExistencia Then Exit For
            Next
            dtInventario.Dispose()
            If bExistencia Then
                For Each Dr As DataRow In Dt.Rows
                    'Aplico Caso 6
                    Inventario.ActualizarInventarioDec(Dr("productoclave"), Dr("tipounidad"), Dr("cantidad"), ServicesCentral.TiposTransProd.DevolucionesCliente, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, , "Venta")
                    'Aplico Caso 4
                    Inventario.ActualizarInventarioDec(Dr("productoclave"), Dr("tipounidad"), Dr("cantidad"), ServicesCentral.TiposTransProd.DevolucionesCliente, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId, , "No Venta")
                Next
            Else
                resul = False
                MsgBox(oVista.BuscarMensaje("Mensajes", "E0029"), MsgBoxStyle.Information)
            End If
            Dt.Dispose()
        ElseIf sGrupoActual = "Venta" Then 'Reversa del Caso 4 (Aplico 5 y luego 3)
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select productoclave, tipounidad, cantidad from TransProdDetalle where TransProdId='" & sTransprodID & "' order by Partida, ProductoClave", "No Venta")
            Dim dtInventario As DataTable
            Dim bExistencia As Boolean = True
            Dim pclave As String = ""
            For Each Dr As DataRow In Dt.Rows
                If (pclave <> Dr("productoclave").ToString()) Then
                    dtInventario = oDBVen.RealizarConsultaSQL("SELECT * FROM Inventario WHERE ProductoClave ='" & Dr("productoclave").ToString() & "'", "inventario")
                    pclave = Dr("productoclave").ToString()
                End If
                bExistencia = Inventario.ValidarExistenciaNoDisponible(Dr("productoclave").ToString(), Convert.ToInt32(Dr("tipounidad")), Math.Abs(Convert.ToInt32(Dr("cantidad"))), dtInventario)
                If Not bExistencia Then Exit For
            Next
            dtInventario.Dispose()
            If bExistencia Then
                For Each Dr As DataRow In Dt.Rows
                    'Aplico Caso 5
                    Inventario.ActualizarInventarioDec(Dr("productoclave"), Dr("tipounidad"), Dr("cantidad"), ServicesCentral.TiposTransProd.DevolucionesCliente, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, , "No Venta")
                    'Aplico Caso 3
                    Inventario.ActualizarInventarioDec(Dr("productoclave"), Dr("tipounidad"), Dr("cantidad"), ServicesCentral.TiposTransProd.DevolucionesCliente, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId, , "Venta")
                Next
            Else
                resul = False
                MsgBox(oVista.BuscarMensaje("Mensajes", "E0029"), MsgBoxStyle.Information)
            End If
            Dt.Dispose()
        End If
        Return resul
    End Function

    Private Sub ConfiguraGrid()
        blnCambiandoGrid = True
        With fgMovimientos
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Rows.Count = 1
            .Cols.Fixed = 0
            .Cols.Count = 3
            .Cols(0).Width = 70
            .Cols(0).Caption = oVista.BuscarMensaje("Mensajes", "Partida")
            .Cols(1).Width = 70
            .Cols(1).Caption = oVista.BuscarMensaje("Mensajes", "Producto")
            .Cols(2).Width = 100
            .Cols(2).Caption = oVista.BuscarMensaje("Mensajes", "Nombre")
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
        blnCambiandoGrid = False
    End Sub
#End Region

#Region "FUNCIONES"
    Private Function PedirProductoCantidad(ByVal pariPartida As Integer, Optional ByVal optparsProductoClave As String = "") As Boolean
        ' Cargar la forma para pedir el producto, cantidad y unidad
        Dim oFormPedirProducto As New FormPedirProducto
        With oFormPedirProducto
            .TransProdId = Me.sTransprodID
            .FolioActual = Me.sFolio
            .TipoTransProd = oMMD.TipoTransProd
            .TipoMovimiento = oMMD.TipoMovimiento
            .ModuloMovDetalle = oMMD
            .Partida = pariPartida
            Me.Producto.ProductoClave = optparsProductoClave
            .Producto = Me.Producto
            '.NombreListViewProductos = "ListViewDevolucionesCliente"
            AddHandler .PoblarListaProductos, AddressOf PoblarGridProductos
            AddHandler .CrearGridProductos, AddressOf ConfiguraGridfgProductos

            AddHandler .GuardarDetalle, AddressOf GuardarDetalleProductos

            If optparsProductoClave <> "" Then
                .PermitirConsultarProductos = False
                '.PermitirCambiarProducto = False
            End If

        End With

        If oFormPedirProducto.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.TextBoxProducto.Focus()
        Else
            Me.TextBoxProducto.Text = String.Empty
            Me.TextBoxCodigo.Text = String.Empty
            Me.TextBoxProducto.Focus()
            oFormPedirProducto.Dispose()
        End If
        Me.TextBoxProducto.Text = String.Empty
        Me.TextBoxCodigo.Text = String.Empty
        Me.TextBoxProducto.Focus()
        oFormPedirProducto.Dispose()
        Return True
    End Function

    Private Function ValidarDatos() As Boolean
        If Me.TextBoxFactura.Text.IndexOf("'") >= 0 Then
            MsgBox(oVista.BuscarMensaje("Mensajes", "E0421").Replace("$0$", "'"), MsgBoxStyle.Information)
            Return False
        End If
        Return True
    End Function
    Private Function GuardarEncabezado() As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        If Not ValidarDatos() Then Exit Function
        Try
            ' Buscar el TransProdId, para ver si ya existia
            Dim DataTableTrans As DataTable
            DataTableTrans = oDBVen.RealizarConsultaSQL("SELECT TransProdId FROM TransProd WHERE TransProdId='" & sTransprodID & "'", "TransProd")
            If DataTableTrans.Rows.Count > 0 Then
                ' Ya existe, actualizar
                sComandoSQL.Append("UPDATE TransProd SET ")
                sComandoSQL.Append("Notas='" & Me.TextBoxFactura.Text & "',")
                sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",")
                sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 ")
                sComandoSQL.Append("WHERE TransProdId='" & sTransprodID & "'")
            Else
                ' No existe, crear
                sComandoSQL.Append("INSERT INTO TransProd (TransProdID, VisitaClave, DiaClave, PCEModuloMovDetClave, Folio, Tipo,  TipoFase, TipoMovimiento, FechaHoraAlta, FechaCaptura, Total, Notas, MFechaHora, MUsuarioID) VALUES (")
                sComandoSQL.Append("'" & sTransprodID & "',")
                sComandoSQL.Append("'" & VisitaClave & "',")
                sComandoSQL.Append("'" & oDia.DiaActual & "',")
                sComandoSQL.Append("'" & oMMD.ModuloMovDetalleClave & "',")
                sComandoSQL.Append("'" & sFolio & "',")
                sComandoSQL.Append(oMMD.TipoTransProd & ",")
                sComandoSQL.Append("1,")
                sComandoSQL.Append(oMMD.TipoMovimiento & ",")
                sComandoSQL.Append(UniFechaSQL(Now) & ",")
                sComandoSQL.Append(UniFechaSQL(PrimeraHora(Now)) & ",")
                sComandoSQL.Append("0,")
                sComandoSQL.Append("'" & Me.TextBoxFactura.Text & "',")
                sComandoSQL.Append(UniFechaSQL(Now) & ",")
                sComandoSQL.Append("'" & oVendedor.UsuarioId & "'")
                sComandoSQL.Append(")")
                Folio.Confirmar(oMMD.ModuloMovDetalleClave)
            End If
            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
            DataTableTrans.Dispose()
            Return True
        Catch ExcA As SqlServerCe.SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        End Try
        sComandoSQL = Nothing
    End Function

    Private Function ExisteProducto(ByVal clave As String) As Boolean
        Try
            Dim Dt As DataTable
            Dt = oDBVen.RealizarConsultaSQL("select count(productoclave) from producto where productoclave='" & clave & "'", "Productos")
            If Dt.Rows(0).Item(0) > 0 Then
                Dt.Dispose()
                Return True
            Else
                Dt.Dispose()
                Return False
            End If
        Catch exsql As SqlServerCe.SqlCeException
            MsgBox("SQL Error: " & exsql.Message, MsgBoxStyle.Information)
            Return False
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Information)
            Return False
        End Try
    End Function

    Private Function ObtienePartida(ByVal clave As String) As Integer
        With fgMovimientos
            Dim i As Integer = 1
            For i = 1 To .Rows.Count - 1
                If .GetData(i, 1).ToString = clave Then
                    Return .GetData(i, 0)
                End If
            Next
            Return -1
        End With
    End Function
#End Region

#Region "FormDevolucionClienteDetalle"

    Private Sub FormDevolucionClienteDetalle_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Not Me.fgMovimientos Is Nothing Then
            If oVendedor.motconfiguracion.Secuencia Then
                If Not ctrlSeguimiento.Parent Is Nothing Then
                    RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                    RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                    ctrlSeguimiento.QuitarMenuItem(Me.MainMenu1)
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

        If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
        Me.Transaccion = Nothing
    End Sub

    Private Sub FormDevolucionClienteDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.AgregarControl(Me)
            Me.Panel1.SendToBack()
            ctrlSeguimiento.CrearMenuItem(Me.MainMenu1)
            AddHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
            AddHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
        End If

        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.Iniciar()
        Else
            Dim lbNombreActividad As New Label
            lbNombreActividad.BackColor = System.Drawing.SystemColors.Control
            lbNombreActividad.Dock = System.Windows.Forms.DockStyle.Top
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

        If oDBVen.oConexion.State = ConnectionState.Closed Then
            oDBVen.oConexion.Open()
        End If
        Transaccion = oDBVen.oConexion.BeginTransaction
        If Not Vista.Buscar("FormDevolucionClienteDetalle", oVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        ConfiguraGrid()
        oVista.ColocarEtiquetasForma(Me)
        oVista.ColocarEtiquetasMenuEmergente(ContextMenu1)
        Application.DoEvents()

        If Not LlenaCombo() Then
            Cursor.Current = Cursors.Default
            MsgBox(oVista.BuscarMensaje("Mensajes", "E0759").Replace("$0$", sNombreActividad), MsgBoxStyle.Exclamation)
            Me.Close()
            Exit Sub
        End If

        Producto = New Producto
        bHayCambios = False
        If oMovimiento = Movimiento.Eliminar OrElse oModo = Modo.SoloLectura Then
            DesactivarScanner()
            TextBoxProducto.Enabled = False
            TextBoxCodigo.Enabled = False
            ButtonBuscar.Enabled = False
            'ListViewProductos.Enabled = False
            ComboBoxMotivo.Enabled = False
            If oModo = Modo.SoloLectura And Not EsConsignacion Then ButtonContinuar.Enabled = False
        End If
        If bNuevo Then
            Me.GuardarEncabezado()
        Else
            LlenaDetalles()
            PoblarProductos()
        End If
        bFin = True
        [Global].HabilitarMenuItem(MainMenu1, True)
        Cursor.Current = Cursors.Default

        Me.TextBoxProducto.Focus()

    End Sub

    Private Sub TerminarVisita()
        MenuItemRegresar_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        BuscarProducto()
    End Sub

    Private Sub BuscarProducto(Optional ByVal sOrigen As String = "")
        If TextBoxProducto.Text <> String.Empty Then
            Dim iTipoClave, iEspacios As Integer
            iTipoClave = oConHist.Campos("TipoClaveProducto")
            iEspacios = oConHist.Campos("DigitoClaveProd")
            'If MobileClient.Producto.VerificarTipoClaveProducto(iTipoClave, iEspacios) Then
            If iTipoClave = 2 Then
                Dim sProdClave As String = Me.TextBoxProducto.Text
                If sProdClave.Length < iEspacios Then
                    sProdClave = sProdClave.PadLeft(iEspacios, "0")
                    Me.TextBoxProducto.Text = sProdClave
                End If
            End If
            'End If
            If Not ExisteProducto(TextBoxProducto.Text) Then
                MsgBox(oVista.BuscarMensaje("Mensajes", "E0005"), MsgBoxStyle.Information)
                Me.TextBoxProducto.SelectionStart = 0
                Me.TextBoxProducto.SelectionLength = Len(Me.TextBoxProducto.Text)
                Me.TextBoxProducto.Focus()
                Exit Sub
            End If
            ClaveProd = TextBoxProducto.Text
            Partida = ObtienePartida(ClaveProd)
            If Partida = -1 Then 'No está en el listview
                If Me.PedirProductoCantidad(0, ClaveProd) Then
                    Me.bHayCambios = True
                    PoblarProductos()
                End If
            Else
                If Me.PedirProductoCantidad(Partida, ClaveProd) Then
                    Me.bHayCambios = True
                    PoblarProductos()
                End If
            End If
        Else
            If sOrigen <> "TextBoxProducto" Then Me.AgregarMovimiento()
        End If
    End Sub
    Private Sub MenuItemEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemEliminar.Click
        Try
            If fgMovimientos.Row < 0 Then Exit Sub
            If Partida = Nothing OrElse ClaveProd = Nothing Then Exit Sub
            Dim i As Integer, s As String
            Dim bExistencia As Boolean = True
            Dim dExistencia As Decimal = 0
            Dim dtInventario As DataTable
            Dim sError As String

            s = "select tipounidad, cantidad from transproddetalle where transprodid='" & sTransprodID & "' and partida=" & Partida & " and productoclave='" & ClaveProd & "'"
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(s, "a")
            Dim sConsulta As String
            sConsulta = "select INV.ProductoClave, INV.Disponible, INV.NoDisponible, INV.Apartado, INV.Contenido "
            sConsulta &= "from ProductoDetalle PRD "
            sConsulta &= "inner join Inventario INV on INV.ProductoClave = PRD.ProductoDetClave and PRD.ProductoClave ='" & ClaveProd & "' "
            dtInventario = oDBVen.RealizarConsultaSQL(sConsulta, "Inventario")

            For Each Dr As DataRow In Dt.Rows
                If GrupoActual = "Venta" Then
                    bExistencia = Inventario.ValidarExistenciaDisponibleDec(ClaveProd, Convert.ToInt32(Dr("tipounidad")), Math.Abs(Convert.ToDecimal(Dr("cantidad"))), dExistencia, dtInventario, sError)
                ElseIf GrupoActual = "No Venta" Then
                    bExistencia = Inventario.ValidarExistenciaNoDisponible(ClaveProd, Convert.ToInt32(Dr("tipounidad")), Math.Abs(Convert.ToDecimal(Dr("cantidad"))), dtInventario)
                End If
                If Not bExistencia Then Exit For
            Next
            dtInventario.Dispose()
            If bExistencia Then
                For Each Dr As DataRow In Dt.Rows
                    Inventario.ActualizarInventarioDec(ClaveProd, Dr("tipounidad"), Dr("cantidad"), ServicesCentral.TiposTransProd.DevolucionesCliente, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, , GrupoActual)

                    'Crear Saldo de Envases del Cliente
                    If oCliente.Prestamo Then
                        ProductoPrestamoCli.ActulizarProductoPrestamoCli(oCliente.ClienteClave, ClaveProd, -1 * Dr("cantidad"), Dr("tipounidad"), 0, oMMD.TipoTransProd, oMMD.TipoMovimiento)
                    End If
                Next
                Dt.Dispose()
                'Borro los registros de la base de datos
                s = "delete from transproddetalle where transprodid='" & sTransprodID & "' and partida=" & Partida & " and productoclave='" & ClaveProd & "'"
                i = oDBVen.EjecutarComandoSQL(s)
                If i = 0 Then
                    MsgBox(oVista.BuscarMensaje("Mensajes", "E0141"), MsgBoxStyle.Information)
                End If
                Me.bHayCambios = True
                Partida = Nothing
                ClaveProd = Nothing
                Me.PoblarProductos()
            Else
                MsgBox(oVista.BuscarMensaje("Mensajes", "E0029"), MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItemModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemModificar.Click
        If fgMovimientos.Row < 0 Then Exit Sub
        If Partida = Nothing OrElse ClaveProd = Nothing Then Exit Sub
        If Me.PedirProductoCantidad(Partida, ClaveProd) Then
            PoblarProductos()
        End If
        Me.bHayCambios = True
        Partida = Nothing
        ClaveProd = Nothing
    End Sub

    Private Sub ContextMenu1_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenu1.Popup
        ContextMenu1.MenuItems.Clear()

        If fgMovimientos.Rows.Count > 0 AndAlso fgMovimientos.Row > 0 Then

            Dim r As C1.Win.C1FlexGrid.Row
            r = fgMovimientos.Rows(fgMovimientos.Row)
            If r.Node.Level = 0 Then
                ContextMenu1.MenuItems.Add(Me.MenuItemEliminar)
                ContextMenu1.MenuItems.Add(Me.MenuItemModificar)
            End If

        End If

        If oMovimiento = Movimiento.Eliminar OrElse oModo = Modo.SoloLectura Then
            For Each MI As MenuItem In ContextMenu1.MenuItems
                MI.Enabled = False
            Next
        End If
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Salir()
    End Sub

    Private Sub Salir()
        If bHayCambios Then
            If MsgBox(oVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.Yes Then
                Transaccion.Rollback()

                Me.Close()
            End If
        Else
            Transaccion.Rollback()
            Me.Close()
        End If
    End Sub
    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        If oMovimiento = Movimiento.Eliminar Then
            Dim res As Object
            res = MsgBox(oVista.BuscarMensaje("Mensajes", "P0001"), MsgBoxStyle.YesNo)
            If res = vbYes Then
                EliminaAjuste()
            End If
        Else
            If fgMovimientos.Rows.Count <= 1 Then
                'Dim Dt As DataTable = ValorReferencia.RecuperarLista("TRPTIPO", "3")
                'Dim sTipo As String = Dt.Rows(0).Item(1)
                MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "E0044"), ValorReferencia.BuscarEquivalente("TRPTIPO", "3")), MsgBoxStyle.Information)
                Exit Sub
            Else
                GuardaMotivo()
            End If
        End If
        Me.Close()
    End Sub

    'Private Sub ListViewProductos_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewProductos.ItemActivate
    '    With ListViewProductos
    '        Partida = .Items(.SelectedIndices(0)).Text
    '        ClaveProd = .Items(.SelectedIndices(0)).SubItems(1).Text
    '    End With
    'End Sub

    Private Sub ComboBoxMotivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxMotivo.SelectedIndexChanged
        If bFin Then
            Dim GrupoTmp As String = ValorReferencia.RecuperaGrupo("TRPMOT", ComboBoxMotivo.SelectedValue)
            If GrupoActual <> GrupoTmp Then
                If fgMovimientos.Rows.Count > 1 Then
                    If (ReversaInventario(GrupoTmp)) Then
                        GrupoActual = GrupoTmp
                        ComboBoxMotivo.Tag = ComboBoxMotivo.SelectedValue
                        Me.bHayCambios = True
                    Else
                        ComboBoxMotivo.SelectedValue = ComboBoxMotivo.Tag.ToString()
                    End If
                Else
                    GrupoActual = GrupoTmp
                    ComboBoxMotivo.Tag = ComboBoxMotivo.SelectedValue
                End If
            End If
        End If
    End Sub
#End Region

    Private Sub TextBoxProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxProducto.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                e.Handled = True
                BuscarProducto()
        End Select
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Salir()
    End Sub

    Private Sub fgMovimientos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fgMovimientos.KeyUp
        Select Case e.KeyCode
            Case Keys.Space
                If fgMovimientos.Rows(fgMovimientos.Row).Node.Collapsed Then
                    fgMovimientos.Rows(fgMovimientos.Row).Node.Collapsed = False
                Else
                    fgMovimientos.Rows(fgMovimientos.Row).Node.Collapsed = True
                End If
        End Select
    End Sub

    Private Sub fgMovimientos_SelChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles fgMovimientos.SelChange
        If blnCambiandoGrid Then Exit Sub
        With Me.fgMovimientos
            If .Rows.Count <= 1 Then Exit Sub
            If .Row > 0 Then
                If .Rows(.Row).Node.Level = 0 Then
                    Partida = .GetData(.Row, 0)
                    ClaveProd = .GetData(.Row, 1)
                Else
                    Partida = .GetData(.Rows(.Row).Node.GetNode(C1.Win.C1FlexGrid.NodeTypeEnum.Parent).Row.Index, 0)
                    ClaveProd = .GetData(.Rows(.Row).Node.GetNode(C1.Win.C1FlexGrid.NodeTypeEnum.Parent).Row.Index, 1)
                End If
            Else
                Partida = Nothing
                ClaveProd = Nothing
            End If
        End With
    End Sub
#Region "Lectura producto"
    Private Sub ActivarScanner()
#If MOD_TERM <> "PALM" Then
        If TextBoxCodigo.Enabled Then
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
        If TextBoxCodigo.Enabled Then
            If bLector Then
                Try
                    bScanner.Terminate_Scanner()
                    bLector = False
                Catch ex As Exception
                    MsgBox("Error while stopping the scanner:" & ex.Message, MsgBoxStyle.Critical)
                End Try
            End If
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
        If Me.TextBoxCodigo.Enabled Then
            Me.TextBoxCodigo.Text = Data
            BuscarCodigoBarras()
        End If
    End Sub
#End If

    Private Sub TextBoxCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxCodigo.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                e.Handled = True
                BuscarCodigoBarras()
        End Select
    End Sub

    Private Sub BuscarCodigoBarras()
        If TextBoxCodigo.Text <> "" Then
            Dim sProductoClave As String = Me.Producto.BuscarCodigoBarras(Me.TextBoxCodigo.Text)
            If sProductoClave <> String.Empty Then
                ClaveProd = sProductoClave
                Partida = ObtienePartida(ClaveProd)
                If Partida = -1 Then 'No está en el listview
                    If Me.PedirProductoCantidad(0, ClaveProd) Then
                        Me.bHayCambios = True
                        PoblarProductos()
                    End If
                Else
                    If Me.PedirProductoCantidad(Partida, ClaveProd) Then
                        Me.bHayCambios = True
                        PoblarProductos()
                    End If
                End If
            Else
                MsgBox(oVista.BuscarMensaje("Mensajes", "E0005"), MsgBoxStyle.Information)
                Me.TextBoxCodigo.SelectionStart = 0
                Me.TextBoxCodigo.SelectionLength = Len(Me.TextBoxCodigo.Text)
                Me.TextBoxCodigo.Focus()
            End If
        End If
    End Sub
#End Region


    Private Sub TextBoxFactura_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxFactura.TextChanged, TextBoxFactura.TextChanged, TextBoxProducto.TextChanged, TextBoxCodigo.TextChanged
        Me.bHayCambios = True
    End Sub

    Private Sub ContextMenu2_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenu2.Popup
        MostrarContext()
    End Sub
    Private Sub MostrarContext()
        DesactivarScanner()
        ContextMenu1.Show(Me, Control.MousePosition)
        ActivarScanner()
    End Sub
End Class
