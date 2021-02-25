Public Class FormAjustesDetalle
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal TransProdFolio As String, ByVal TransProdId As String, ByVal Mov As Movimiento, ByVal mModo As Modo, ByVal Nuevo As Boolean)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        If g_SO = SO.WindowsCE Then
            Call InTheHand.Windows.Forms.ContextMenuHelper.HookAllControls(Me.Controls)
        End If

        'Add any initialization after the InitializeComponent() call
        Me.sFolio = TransProdFolio
        Me.TransprodID = TransProdId
        Me.TextBoxFolio.Text = sFolio
        Me.TextBoxFecha.Text = Format(Now, "dd/MM/yyyy")
        Me.oMov = Mov
        Me.bNuevo = Nuevo
        Me.oModo = mModo

        fgDetalles.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not IsNothing(Me.fgDetalles) Then
            Me.fgDetalles.ContextMenu = Nothing
            Me.fgDetalles.Dispose()
            Me.fgDetalles = Nothing
        End If
        If Not IsNothing(Me.MenuItemRegresar) Then MenuItemRegresar.Dispose()
        If Not IsNothing(Me.MenuItemModificar) Then MenuItemModificar.Dispose()
        If Not IsNothing(Me.MenuItemEliminar) Then MenuItemEliminar.Dispose()
        If Not IsNothing(Me.MainMenu1) Then MainMenu1.Dispose()
        If Not IsNothing(Me.ContextMenu1) Then
            ContextMenu1.Dispose()
            ContextMenu1 = Nothing
        End If
        If Not IsNothing(Me.ContextMenu2) Then
            ContextMenu2.Dispose()
            ContextMenu2 = Nothing
        End If
#If MOD_TERM <> "PALM" Then
        If Not IsNothing(Me.bScanner) Then
            bScanner.Dispose()
            bScanner = Nothing
        End If
#End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemEliminar As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
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
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents fgDetalles As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TextBoxCodigo As System.Windows.Forms.TextBox
    Friend WithEvents LabelCodigo As System.Windows.Forms.Label
    Friend WithEvents ContextMenu2 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemModificar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAjustesDetalle))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItemEliminar = New System.Windows.Forms.MenuItem
        Me.MenuItemModificar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TextBoxCodigo = New System.Windows.Forms.TextBox
        Me.LabelCodigo = New System.Windows.Forms.Label
        Me.fgDetalles = New C1.Win.C1FlexGrid.C1FlexGrid
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
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TextBoxCodigo)
        Me.Panel1.Controls.Add(Me.LabelCodigo)
        Me.Panel1.Controls.Add(Me.fgDetalles)
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
        Me.TextBoxCodigo.AcceptsReturn = True
        Me.TextBoxCodigo.Location = New System.Drawing.Point(88, 89)
        Me.TextBoxCodigo.Name = "TextBoxCodigo"
        Me.TextBoxCodigo.Size = New System.Drawing.Size(144, 21)
        Me.TextBoxCodigo.TabIndex = 4
        '
        'LabelCodigo
        '
        Me.LabelCodigo.Location = New System.Drawing.Point(8, 89)
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
        Me.fgDetalles.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fgDetalles.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgDetalles.Location = New System.Drawing.Point(8, 140)
        Me.fgDetalles.Name = "fgDetalles"
        Me.fgDetalles.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgDetalles.Size = New System.Drawing.Size(224, 121)
        Me.fgDetalles.StyleInfo = resources.GetString("fgDetalles.StyleInfo")
        Me.fgDetalles.SupportInfo = "5ABUAQMBEQEMAa0BlADRAN4A4gCQAJwAJgFbAfIAyQAqAU0AJQFvAJgAQABVAO0AFwHhAGsAgAAIAREB"
        Me.fgDetalles.TabIndex = 6
        '
        'ContextMenu2
        '
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(88, 264)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 8
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(8, 264)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 7
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(208, 65)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(24, 21)
        Me.ButtonBuscar.TabIndex = 3
        Me.ButtonBuscar.Text = "..."
        '
        'ComboBoxMotivo
        '
        Me.ComboBoxMotivo.Location = New System.Drawing.Point(88, 113)
        Me.ComboBoxMotivo.Name = "ComboBoxMotivo"
        Me.ComboBoxMotivo.Size = New System.Drawing.Size(144, 22)
        Me.ComboBoxMotivo.TabIndex = 5
        '
        'TextBoxProducto
        '
        Me.TextBoxProducto.Location = New System.Drawing.Point(88, 65)
        Me.TextBoxProducto.Name = "TextBoxProducto"
        Me.TextBoxProducto.Size = New System.Drawing.Size(118, 21)
        Me.TextBoxProducto.TabIndex = 2
        '
        'TextBoxFecha
        '
        Me.TextBoxFecha.Enabled = False
        Me.TextBoxFecha.Location = New System.Drawing.Point(88, 41)
        Me.TextBoxFecha.Name = "TextBoxFecha"
        Me.TextBoxFecha.Size = New System.Drawing.Size(118, 21)
        Me.TextBoxFecha.TabIndex = 1
        '
        'TextBoxFolio
        '
        Me.TextBoxFolio.Enabled = False
        Me.TextBoxFolio.Location = New System.Drawing.Point(88, 17)
        Me.TextBoxFolio.Name = "TextBoxFolio"
        Me.TextBoxFolio.Size = New System.Drawing.Size(118, 21)
        Me.TextBoxFolio.TabIndex = 0
        '
        'LabelMotivo
        '
        Me.LabelMotivo.Location = New System.Drawing.Point(8, 113)
        Me.LabelMotivo.Name = "LabelMotivo"
        Me.LabelMotivo.Size = New System.Drawing.Size(80, 20)
        Me.LabelMotivo.Text = "LabelMotivo"
        '
        'LabelProducto
        '
        Me.LabelProducto.Location = New System.Drawing.Point(8, 65)
        Me.LabelProducto.Name = "LabelProducto"
        Me.LabelProducto.Size = New System.Drawing.Size(80, 20)
        Me.LabelProducto.Text = "LabelProducto"
        '
        'LabelFecha
        '
        Me.LabelFecha.Location = New System.Drawing.Point(8, 41)
        Me.LabelFecha.Name = "LabelFecha"
        Me.LabelFecha.Size = New System.Drawing.Size(80, 20)
        Me.LabelFecha.Text = "LabelFecha"
        '
        'LabelFolio
        '
        Me.LabelFolio.Location = New System.Drawing.Point(8, 17)
        Me.LabelFolio.Name = "LabelFolio"
        Me.LabelFolio.Size = New System.Drawing.Size(72, 24)
        Me.LabelFolio.Text = "LabelFolio"
        '
        'FormAjustesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormAjustesDetalle"
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
#If MOD_TERM <> "PALM" Then
    Private WithEvents bScanner As New HANDHELD.CScanner
#End If
    Private Producto As Producto
    Private oMMD As Modulos.GrupoModuloMovDetalle
    Private oVista As Vista
    Private oMov As Movimiento
    Private oModo As Modo
    Private sFolio, TransprodID As String
    Private Cambios As Boolean = False
    Private bNuevo As Boolean
    Private ClaveProd, Partida As String
    Private bFin As Boolean = False
    Private bLector As Boolean = False
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
#End Region

#Region "MIS METODOS"

    Private Sub EliminaAjuste()
        Try



            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select productoclave, tipounidad, cantidad, enviado from transproddetalle where transprodid='" & TransprodID & "'", "Consulta")
            For Each Dr As DataRow In Dt.Rows
                Inventario.ActualizarInventarioDec(Dr("productoclave"), Dr("tipounidad"), Dr("cantidad"), ServicesCentral.TiposTransProd.Ajustes, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId)
            Next
            Dt.Dispose()
            oDBVen.EjecutarComandoSQL("delete from transproddetalle where transprodid='" & TransprodID & "'")
            oDBVen.EjecutarComandoSQL("delete from transprod where transprodid='" & TransprodID & "'")
            Transaccion.Commit()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function LlenaCombo() As Boolean
        With ComboBoxMotivo
            Dim aGrupo As New ArrayList()
            aGrupo.Add("Ajuste")
            .DataSource = ValorReferencia.RecuperaVARVGrupo("TRPMOT", aGrupo)

            If .Items.Count > 0 Then
                .DisplayMember = "Cadena"
                .ValueMember = "Id"
                .SelectedIndex = 0
                Return True
            Else
                MsgBox(oVista.BuscarMensaje("Mensajes", "E0539"))
            End If
            Return False
        End With
    End Function

    Private Sub GuardaMotivo()
        oDBVen.EjecutarComandoSQL("update transprod set tipomotivo=" & ComboBoxMotivo.SelectedValue & ", mfechahora=" & UniFechaSQL(Now) & ", musuarioid='" & oVendedor.UsuarioId & "',Enviado=0 where transprodid='" & TransprodID & "'")
        HabilitarBotones(False)
        Transaccion.Commit()
        If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
        Me.Transaccion = Nothing
        If oVendedor.motconfiguracion.MensajeImpresion Then
            If MsgBox(oVista.BuscarMensaje("Mensajes", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                ImprimirTicketSinForma(ModoImpresion.SinVisita, TransprodID, ServicesCentral.TiposTransProd.Ajustes, ServicesCentral.TiposTransProd.Ajustes)
            End If
        End If
        HabilitarBotones(True)

    End Sub

    Private Sub AgregarMovimiento()
        'If Me.PedirProductoCantidad(0) Then
        '    PoblarProductos(False)
        'End If
        Me.PedirProductoCantidad(0)
        PoblarProductos(False)
    End Sub

    Private Sub PoblarProductos(Optional ByVal parbPrimeraVez As Boolean = False)
        'oVista.PoblarListViewDinamico(ListViewProductos, oDBVen, "ListViewProductos", " and TransProdDetalle.TransProdId='" & TransprodID & "' order by transproddetalle.partida")
        PoblarGridMovimientos()
        Me.PrepararMovimiento()
    End Sub

#Region "Con Arbolito"
    Private Sub PoblarGridMovimientos()
        fgDetalles.Rows.Count = 1
        Dim dt As DataTable = oDBVen.RealizarConsultaSQL("select transproddetalle.Partida, transproddetalle.productoclave, producto.Nombre, cantidad, tipounidad from transproddetalle, producto where transproddetalle.productoclave=producto.productoclave and TransProdDetalle.TransProdId='" & TransprodID & "' order by transproddetalle.partida", "Ajustes")
        Dim sPartida As String = ""
        fgDetalles.Redraw = False
        Dim r As C1.Win.C1FlexGrid.Row
        For Each dr As DataRow In dt.Rows
            If sPartida <> dr("Partida").ToString Then
                sPartida = dr("Partida").ToString
                r = fgDetalles.Rows.Add
                r.IsNode = True
                r.Node.Level = 0
                With fgDetalles
                    .Item(r.Index, 0) = dr("Partida")
                    .Item(r.Index, 1) = dr("ProductoClave")
                    .Item(r.Index, 2) = dr("Nombre")
                End With
            End If
            Dim r2 As C1.Win.C1FlexGrid.Row = fgDetalles.Rows.Add
            r2.IsNode = True
            r2.Node.Level = 1
            With fgDetalles
                .Item(r2.Index, 0) = ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad"))
                .Item(r2.Index, 1) = dr("Cantidad")
            End With
        Next
        dt.Dispose()
        fgDetalles.Redraw = True
    End Sub
    Private Sub ConfiguraGrid()
        With fgDetalles
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 3
            .Cols(0).Caption = oVista.BuscarMensaje("Mensajes", "Numero")
            .Cols(1).Caption = oVista.BuscarMensaje("Mensajes", "Clave")
            .Cols(2).Caption = oVista.BuscarMensaje("Mensajes", "Nombre Corto")
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

    Private Sub PrepararMovimiento(Optional ByVal parbBorrarProducto As Boolean = True)
        Dim iProxNumPartida As Integer = 1
        If parbBorrarProducto Then
            TextBoxProducto.Text = ""
            Me.TextBoxCodigo.Text = String.Empty
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

    Private Sub PoblarListViewProductos(ByRef refparoFormPedirProducto As FormPedirProducto, ByVal aListaEsquemas As ArrayList)
        With refparoFormPedirProducto
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            .fgProductos.Redraw = False
            Dim dtProductos As DataTable = oDBVen.RealizarConsultaSQL("SELECT DISTINCT Producto.ProductoClave, Producto.Nombre FROM Producto INNER JOIN Inventario ON Producto.ProductoClave = Inventario.ProductoClave WHERE (Inventario.AlmacenID='" & oVendedor.AlmacenId & "') AND (Disponible-Apartado-NoDisponible-(case When Producto.venta=0 then Inventario.Contenido  Else 0 END))>0 " & IIf(.FiltroProductosIncluyeTabla = "", "", " AND " & .FiltroProductosIncluyeTabla), "ProdAjustes")
            .fgProductos.DataSource = dtProductos
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
            .Cols(0).Caption = oVista.BuscarMensaje("Mensajes", "Clave")
            .Cols(1).Caption = oVista.BuscarMensaje("Mensajes", "Nombre Corto")
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
                                sComandoSQL.Append(((dCantidad * nPrecio * (1 + (nImpuesto / 100)))) * .Factor & ",") ' Total
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
            Dim dCantidadAnterior As Decimal = 0
            For Each refProducto In refparoFormPedirProducto.PanelUnidades.Controls
                With refProducto
                    dCantidad = refProducto.NumericCantidad.DecimalValue
                    dCantidadAnterior = refProducto.ValorAnterior
                    Inventario.ObtenerCantidadAActualizar(refparoFormPedirProducto.TipoMovimiento, dCantidad, dCantidadAnterior)
                    If dCantidad > 0 Then
                        Inventario.ActualizarInventarioDec(refparoFormPedirProducto.Producto.ProductoClave, .TipoUnidad, dCantidad, refparoFormPedirProducto.TipoTransProd, refparoFormPedirProducto.TipoMovimiento, oVendedor.AlmacenId)
                    End If
                End With
            Next
        Catch ExcA As SqlServerCe.SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarProducto")
        End Try
    End Sub

    Private Sub LlenaDetalles()
        Try
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select folio, fechacaptura, tipomotivo from transprod where transprodid='" & TransprodID & "'", "busqueda")
            Dim Dr As DataRow = Dt.Rows(0)
            TextBoxFolio.Text = Dr("folio")
            TextBoxFecha.Text = Format(Dr("fechacaptura"), "dd/MM/yyyy")
            ComboBoxMotivo.SelectedValue = Dr("tipomotivo").ToString
            Dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "FUNCIONES"
    Private Function PedirProductoCantidad(ByVal pariPartida As Integer, Optional ByVal optparsProductoClave As String = "") As Boolean
        ' Cargar la forma para pedir el producto, cantidad y unidad
        Dim oFormPedirProducto As New FormPedirProducto
        With oFormPedirProducto
            .TransProdId = Me.TransprodID
            .FolioActual = Me.sFolio
            .TipoTransProd = oMMD.TipoTransProd
            .TipoMovimiento = oMMD.TipoMovimiento
            .ModuloMovDetalle = oMMD
            .Partida = pariPartida
            Me.Producto.ProductoClave = optparsProductoClave
            .Producto = Me.Producto
            AddHandler .PoblarListaProductos, AddressOf PoblarListViewProductos
            AddHandler .GuardarDetalle, AddressOf GuardarDetalleProductos

            If optparsProductoClave <> "" Then
                .PermitirConsultarProductos = False
                '.PermitirCambiarProducto = False
            End If

            .MostrarExistencia = True

        End With
        If oFormPedirProducto.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.TextBoxProducto.Focus()
        Else
            RemoveHandler oFormPedirProducto.PoblarListaProductos, AddressOf PoblarListViewProductos
            RemoveHandler oFormPedirProducto.GuardarDetalle, AddressOf GuardarDetalleProductos
            oFormPedirProducto.Dispose()
            oFormPedirProducto = Nothing
            Return False
        End If
        RemoveHandler oFormPedirProducto.PoblarListaProductos, AddressOf PoblarListViewProductos
        RemoveHandler oFormPedirProducto.GuardarDetalle, AddressOf GuardarDetalleProductos
        oFormPedirProducto.Dispose()
        oFormPedirProducto = Nothing
        Return True
    End Function

    Private Function GuardarEncabezado() As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        Try
            ' Buscar el TransProdId, para ver si ya existia
            Dim DataTableTrans As DataTable
            DataTableTrans = oDBVen.RealizarConsultaSQL("SELECT TransProdId FROM TransProd WHERE TransProdId='" & TransprodID & "'", "TransProd")
            If DataTableTrans.Rows.Count > 0 Then
                ' Ya existe, actualizar
                sComandoSQL.Append("UPDATE TransProd SET ")
                sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",")
                sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 ")
                sComandoSQL.Append("WHERE TransProdId='" & TransprodID & "'")
            Else
                ' No existe, crear
                sComandoSQL.Append("INSERT INTO TransProd (TransProdID, DiaClave, PCEModuloMovDetClave, Folio, Tipo,  TipoFase, TipoMovimiento, FechaHoraAlta, FechaCaptura, Total, Notas, MFechaHora, MUsuarioID) VALUES (")
                sComandoSQL.Append("'" & TransprodID & "',")
                sComandoSQL.Append("'" & oDia.DiaActual & "',")
                sComandoSQL.Append("'" & oMMD.ModuloMovDetalleClave & "',")
                sComandoSQL.Append("'" & sFolio & "',")
                sComandoSQL.Append(oMMD.TipoTransProd & ",")
                sComandoSQL.Append("1,")
                sComandoSQL.Append(oMMD.TipoMovimiento & ",")
                sComandoSQL.Append(UniFechaSQL(Now) & ",")
                sComandoSQL.Append(UniFechaSQL(PrimeraHora(Now)) & ",")
                sComandoSQL.Append("0,")
                sComandoSQL.Append("'',")
                sComandoSQL.Append(UniFechaSQL(Now) & ",")
                sComandoSQL.Append("'" & oVendedor.UsuarioId & "'")
                sComandoSQL.Append(")")
                Folio.Confirmar(, ServicesCentral.TiposModulosMovDet.Ajustes)
            End If
            DataTableTrans.Dispose()
            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
            Return True
        Catch ExcA As SqlServerCe.SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        End Try
        sComandoSQL = Nothing
    End Function

    Private Function ObtienePartida(ByVal clave As String) As Integer
        'With ListViewProductos
        With fgDetalles
            Dim n As Integer = .Rows.Count
            If n = 0 Then Return -1
            Dim i As Integer
            For i = 1 To n - 1
                If .GetData(i, 1).ToString = clave Then
                    If .Rows(i).IsNode AndAlso .Rows(i).Node.Level = 0 Then
                        Return .GetData(i, 0)
                    End If
                End If
            Next
            Return -1
            'For i = 0 To n - 1
            '    If .Items(i).SubItems(1).Text = clave Then
            '        Return .Items(i).Text
            '    End If
            'Next
            'Return -1
        End With
    End Function

    Private Sub HabilitarBotones(ByVal bHabilitar As Boolean)
        Me.ButtonContinuar.Enabled = bHabilitar
        Me.ButtonRegresar.Enabled = bHabilitar
    End Sub

#End Region

#Region "FormAjustesDetalle"

    Private Sub FormAjustesDetalle_close(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Not IsNothing(Me.MenuItemRegresar) Then
            'If oVendedor.motconfiguracion.Secuencia Then
            '    If Not ctrlSeguimiento.Parent Is Nothing Then
            '        RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
            '        RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
            '        ctrlSeguimiento.QuitarMenuItem(Me.MainMenu1)
            '        Me.Controls.Remove(ctrlSeguimiento)
            '    End If
            'Else
            For Each ctrl As Control In Me.Controls
                If ctrl.Name = "lbNombreActividad" Then
                    Me.Controls.Remove(ctrl)
                    ctrl.Dispose()
                    ctrl = Nothing
                    Exit For
                End If
            Next
            'End If
        End If

        If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
        Me.Transaccion = Nothing
    End Sub

    Private Sub FormAjustesDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)

        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)

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

        'ListViewProductos.Activation = oApp.TipoSeleccion
        If Not Vista.Buscar("FormAjustesDetalle", oVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        If Not LlenaCombo() Then
            Cursor.Current = Cursors.Default
            Me.DialogResult = Windows.Forms.DialogResult.Abort
            Exit Sub
        End If

        If oDBVen.oConexion.State = ConnectionState.Closed Then
            oDBVen.oConexion.Open()
        End If
        Transaccion = oDBVen.oConexion.BeginTransaction
        ConfiguraGrid()
        PoblarProductos(False)
        oVista.ColocarEtiquetasForma(Me)
        oVista.ColocarEtiquetasMenuEmergente(ContextMenu1)
        Application.DoEvents()
        LlenaCombo()
        Producto = New Producto
        oMMD = New Modulos.GrupoModuloMovDetalle
        oMMD.Recuperar(ServicesCentral.TiposModulosMovDet.Ajustes)
        Cambios = False
        If oMov = Movimiento.Eliminar OrElse oModo = Modo.SoloLectura Then
            DesactivarScanner()
            TextBoxProducto.Enabled = False
            TextBoxCodigo.Enabled = False
            ButtonBuscar.Enabled = False
            'ListViewProductos.Enabled = False
            ComboBoxMotivo.Enabled = False
            If oModo = Modo.SoloLectura Then ButtonContinuar.Enabled = False
        End If
        If bNuevo Then
            Me.GuardarEncabezado()
        Else
            LlenaDetalles()
            PoblarProductos()
        End If
        'ConfiguraGrid()
        bFin = True
        Cursor.Current = Cursors.Default

        TextBoxProducto.Focus()

    End Sub

    Private Sub TerminarVisita()
        MenuItemRegresar_Click(Nothing, Nothing)
    End Sub


    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        BuscarProducto()
    End Sub

    Private Sub BuscarProducto()
        'Se quitan los espacios porque generaba problemas al no encontrar el producto
        TextBoxProducto.Text = TextBoxProducto.Text.Trim()
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
            If Not MobileClient.Producto.ExisteProducto(TextBoxProducto.Text) Then
                MsgBox(oVista.BuscarMensaje("Mensajes", "E0005"), MsgBoxStyle.Information)
                Me.TextBoxProducto.SelectionStart = 0
                Me.TextBoxProducto.SelectionLength = Len(Me.TextBoxProducto.Text)
                Me.TextBoxProducto.Focus()
                Exit Sub
            End If
            ClaveProd = TextBoxProducto.Text
            Partida = ObtienePartida(ClaveProd)
            If Partida = -1 Then
                'If Me.PedirProductoCantidad(0, ClaveProd) Then
                '    PoblarProductos(False)
                'End If
                Me.PedirProductoCantidad(0, ClaveProd)
                PoblarProductos(False)
            Else
                'If Me.PedirProductoCantidad(Partida, ClaveProd) Then
                '    PoblarProductos(False)
                'End If
                Me.PedirProductoCantidad(Partida, ClaveProd)
                PoblarProductos(False)
            End If
        Else
            Me.AgregarMovimiento()
        End If
    End Sub

    Private Sub MenuItemEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemEliminar.Click
        Try
            'If ListViewProductos.Items.Count = 0 Then Exit Sub
            If fgDetalles.Rows.Count <= 1 Then Exit Sub
            If fgDetalles.Rows(fgDetalles.Row).Node.Level > 0 Then Exit Sub
            Partida = fgDetalles.GetData(fgDetalles.Row, 0)
            ClaveProd = fgDetalles.GetData(fgDetalles.Row, 1)

            'If Partida = Nothing OrElse ClaveProd = Nothing Then Exit Sub
            Dim i As Integer, s As String
            s = "select tipounidad, cantidad from transproddetalle where transprodid='" & TransprodID & "' and partida=" & Partida & " and productoclave='" & ClaveProd & "'"
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(s, "a")
            For Each Dr As DataRow In Dt.Rows
                Inventario.ActualizarInventarioDec(ClaveProd, Dr("tipounidad"), Dr("cantidad"), ServicesCentral.TiposTransProd.Ajustes, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId)
            Next
            Dt.Dispose()
            'Borro los registros de la base de datos
            s = "delete from transproddetalle where transprodid='" & TransprodID & "' and partida=" & Partida & " and productoclave='" & ClaveProd & "'"
            i = oDBVen.EjecutarComandoSQL(s)
            If i = 0 Then
                MsgBox("La partida no se pudo eliminar", MsgBoxStyle.Information)
            End If
            Partida = Nothing
            ClaveProd = Nothing
            Me.PoblarProductos(False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItemModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemModificar.Click
        'If ListViewProductos.Items.Count = 0 Then Exit Sub
        If fgDetalles.Rows.Count <= 1 Then Exit Sub
        If fgDetalles.Rows(fgDetalles.Row).Node.Level > 0 Then Exit Sub
        Partida = fgDetalles.GetData(fgDetalles.Row, 0)
        ClaveProd = fgDetalles.GetData(fgDetalles.Row, 1)

        If Partida = Nothing OrElse ClaveProd = Nothing Then Exit Sub

        If Me.PedirProductoCantidad(Partida, ClaveProd) Then
            PoblarProductos(False)
        End If
        Partida = Nothing
        ClaveProd = Nothing
    End Sub

    Private Sub ContextMenu1_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenu1.Popup
        Me.ContextMenu1.MenuItems.Clear()
        If oMov = Movimiento.Eliminar OrElse oModo = Modo.SoloLectura OrElse fgDetalles.Rows.Count <= 1 OrElse fgDetalles.Rows(fgDetalles.Row).Node.Level > 0 Then
            'ContextMenu1.MenuItems.Clear()
            Exit Sub
        End If

        If Me.fgDetalles.Rows.Count > 0 AndAlso Me.fgDetalles.Row > 0 Then
            Dim r As C1.Win.C1FlexGrid.Row
            r = Me.fgDetalles.Rows(Me.fgDetalles.Row)

            If r.Node.Level = 0 Then
                Me.ContextMenu1.MenuItems.Add(Me.MenuItemModificar)
                Me.ContextMenu1.MenuItems.Add(Me.MenuItemEliminar)
            End If

        End If
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        'Try
        '    Transaccion.Rollback()
        'Catch ex As Exception
        'End Try
        'Me.Close()
        If Cambios Then
            Dim res As Object
            res = MsgBox(oVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Amesol Route")
            If res = vbYes Then
                Transaccion.Rollback()
                Me.Close()
            End If
        Else
            Transaccion.Rollback()
            Me.Close()
        End If
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        If oMov = Movimiento.Eliminar Then
            Dim res As Object
            res = MsgBox(oVista.BuscarMensaje("Mensajes", "P0001"), MsgBoxStyle.YesNo)
            If res = vbYes Then
                EliminaAjuste()
            End If
        Else
            'If ListViewProductos.Items.Count = 0 Then
            If fgDetalles.Rows.Count <= 1 Then 'Exit Sub
                'Dim Dt As DataTable = ValorReferencia.RecuperarLista("TRPTIPO", "6")
                'Dim sTipo As String = Dt.Rows(0).Item(1)
                MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "E0044"), oVista.BuscarMensaje("Mensajes", "XAjuste")), MsgBoxStyle.Information)
                Exit Sub
            Else
                GuardaMotivo()
            End If
        End If
        Me.Close()
    End Sub

#End Region

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        ButtonRegresar_Click(Nothing, Nothing)
    End Sub

    Private Sub fgDetalles_SelChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If fgDetalles.Row <= 0 Then Exit Sub
        Partida = fgDetalles.GetData(fgDetalles.Row, 0)
        ClaveProd = fgDetalles.GetData(fgDetalles.Row, 1)
    End Sub

    Private Sub TextBoxProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxProducto.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                e.Handled = True
                BuscarProducto()
        End Select
        Cambios = True
    End Sub

    Private Sub fgDetalles_GridChanged(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.GridChangedEventArgs) Handles fgDetalles.GridChanged
        Cambios = True
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
        If TextBoxCodigo.Enabled Then
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
        Cambios = True
    End Sub
    Private Sub BuscarCodigoBarras()
        If TextBoxCodigo.Text.Trim <> String.Empty Then
            Dim sProductoClave As String = Me.Producto.BuscarCodigoBarras(Me.TextBoxCodigo.Text)
            If sProductoClave <> String.Empty Then
                If Me.PedirProductoCantidad(0, sProductoClave) Then
                    Me.PoblarProductos(False)
                End If
            Else
                MsgBox(Me.oVista.BuscarMensaje("Mensajes", "E0005"), MsgBoxStyle.Exclamation)
                Me.TextBoxCodigo.SelectionStart = 0
                Me.TextBoxCodigo.SelectionLength = Len(Me.TextBoxCodigo.Text)
                Me.TextBoxCodigo.Focus()
            End If
        End If
        Me.TextBoxCodigo.Text = String.Empty
    End Sub
#End Region

    Private Sub ContextMenu2_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenu2.Popup
        MostrarContext()
    End Sub
    Private Sub MostrarContext()
        DesactivarScanner()
        ContextMenu1.Show(Me, Control.MousePosition)
        ActivarScanner()
    End Sub
End Class
