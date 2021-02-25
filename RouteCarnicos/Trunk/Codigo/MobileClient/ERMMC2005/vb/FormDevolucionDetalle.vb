Public Class FormDevolucionDetalle
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal TransProdFolio As String, ByVal TransProdId As String, ByVal TransProdModo As Modo, ByVal Fase As Fase, ByVal Nuevo As Boolean)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        If g_SO = SO.WindowsCE Then
            Call InTheHand.Windows.Forms.ContextMenuHelper.HookAllControls(Me.Controls)
        End If
        'Add any initialization after the InitializeComponent() call
        sFolio = TransProdFolio
        Me.TransprodID = TransProdId
        oModo = TransProdModo
        oFase = Fase
        TextBoxFolio.Text = sFolio
        TextBoxFecha.Text = Format(Now, "dd/MM/yyyy")
        bNuevo = Nuevo
        fgDetalles.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItem1 Is Nothing Then Me.MenuItem1.Dispose()
        If Not Me.MenuItemEliminar Is Nothing Then Me.MenuItemEliminar.Dispose()
        If Not Me.MenuItemModificar Is Nothing Then Me.MenuItemModificar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        If Not Me.fgDetalles Is Nothing Then
            Me.fgDetalles.ContextMenu = Nothing
            Me.fgDetalles.Dispose()
        End If
        If Not Me.ContextMenu1 Is Nothing Then Me.ContextMenu1.Dispose()
        If Not Me.ContextMenu2 Is Nothing Then Me.ContextMenu2.Dispose()
        ContextMenu1 = Nothing
        ContextMenu2 = Nothing
        Me.fgDetalles = Nothing
#If MOD_TERM <> "PALM" Then
        Me.bScanner = Nothing
#End If
        Me.Producto = Nothing
        Me.oVista = Nothing
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemEliminar As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonBuscar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents TextBoxProducto As System.Windows.Forms.TextBox
    Friend WithEvents LabelProducto As System.Windows.Forms.Label
    Friend WithEvents TextBoxFecha As System.Windows.Forms.TextBox
    Friend WithEvents LabelFecha As System.Windows.Forms.Label
    Friend WithEvents TextBoxFolio As System.Windows.Forms.TextBox
    Friend WithEvents LabelFolio As System.Windows.Forms.Label
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents fgDetalles As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TextBoxCodigo As System.Windows.Forms.TextBox
    Friend WithEvents LabelCodigo As System.Windows.Forms.Label
    Friend WithEvents ContextMenu2 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemModificar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDevolucionDetalle))
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItemEliminar = New System.Windows.Forms.MenuItem
        Me.MenuItemModificar = New System.Windows.Forms.MenuItem
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TextBoxCodigo = New System.Windows.Forms.TextBox
        Me.LabelCodigo = New System.Windows.Forms.Label
        Me.fgDetalles = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ContextMenu2 = New System.Windows.Forms.ContextMenu
        Me.ButtonBuscar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.TextBoxProducto = New System.Windows.Forms.TextBox
        Me.LabelProducto = New System.Windows.Forms.Label
        Me.TextBoxFecha = New System.Windows.Forms.TextBox
        Me.LabelFecha = New System.Windows.Forms.Label
        Me.TextBoxFolio = New System.Windows.Forms.TextBox
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
        Me.MainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TextBoxCodigo)
        Me.Panel1.Controls.Add(Me.LabelCodigo)
        Me.Panel1.Controls.Add(Me.fgDetalles)
        Me.Panel1.Controls.Add(Me.ButtonBuscar)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.TextBoxProducto)
        Me.Panel1.Controls.Add(Me.LabelProducto)
        Me.Panel1.Controls.Add(Me.TextBoxFecha)
        Me.Panel1.Controls.Add(Me.LabelFecha)
        Me.Panel1.Controls.Add(Me.TextBoxFolio)
        Me.Panel1.Controls.Add(Me.LabelFolio)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'TextBoxCodigo
        '
        Me.TextBoxCodigo.AcceptsReturn = True
        Me.TextBoxCodigo.Location = New System.Drawing.Point(88, 92)
        Me.TextBoxCodigo.Name = "TextBoxCodigo"
        Me.TextBoxCodigo.Size = New System.Drawing.Size(143, 21)
        Me.TextBoxCodigo.TabIndex = 5
        '
        'LabelCodigo
        '
        Me.LabelCodigo.Location = New System.Drawing.Point(8, 98)
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
        Me.fgDetalles.Location = New System.Drawing.Point(8, 118)
        Me.fgDetalles.Name = "fgDetalles"
        Me.fgDetalles.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgDetalles.Size = New System.Drawing.Size(223, 143)
        Me.fgDetalles.StyleInfo = resources.GetString("fgDetalles.StyleInfo")
        Me.fgDetalles.SupportInfo = "cgBPAS8BuQDSAOQATwHGABMBiQCqAPgADgFGAWoALQGWANUAIQFkAO4AuQAiAVgAygBqAGoADQHWAD8A"
        Me.fgDetalles.TabIndex = 6
        '
        'ContextMenu2
        '
        '
        'ButtonBuscar
        '
        Me.ButtonBuscar.Location = New System.Drawing.Point(207, 67)
        Me.ButtonBuscar.Name = "ButtonBuscar"
        Me.ButtonBuscar.Size = New System.Drawing.Size(24, 21)
        Me.ButtonBuscar.TabIndex = 4
        Me.ButtonBuscar.Text = "..."
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonRegresar.Location = New System.Drawing.Point(88, 264)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 8
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonContinuar.Location = New System.Drawing.Point(8, 264)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 7
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'TextBoxProducto
        '
        Me.TextBoxProducto.Location = New System.Drawing.Point(88, 67)
        Me.TextBoxProducto.Name = "TextBoxProducto"
        Me.TextBoxProducto.Size = New System.Drawing.Size(113, 21)
        Me.TextBoxProducto.TabIndex = 3
        '
        'LabelProducto
        '
        Me.LabelProducto.Location = New System.Drawing.Point(8, 67)
        Me.LabelProducto.Name = "LabelProducto"
        Me.LabelProducto.Size = New System.Drawing.Size(72, 20)
        Me.LabelProducto.Text = "LabelProducto"
        '
        'TextBoxFecha
        '
        Me.TextBoxFecha.Enabled = False
        Me.TextBoxFecha.Location = New System.Drawing.Point(88, 42)
        Me.TextBoxFecha.Name = "TextBoxFecha"
        Me.TextBoxFecha.Size = New System.Drawing.Size(113, 21)
        Me.TextBoxFecha.TabIndex = 2
        '
        'LabelFecha
        '
        Me.LabelFecha.Location = New System.Drawing.Point(8, 42)
        Me.LabelFecha.Name = "LabelFecha"
        Me.LabelFecha.Size = New System.Drawing.Size(72, 20)
        Me.LabelFecha.Text = "LabelFecha"
        '
        'TextBoxFolio
        '
        Me.TextBoxFolio.Enabled = False
        Me.TextBoxFolio.Location = New System.Drawing.Point(88, 17)
        Me.TextBoxFolio.Name = "TextBoxFolio"
        Me.TextBoxFolio.Size = New System.Drawing.Size(113, 21)
        Me.TextBoxFolio.TabIndex = 1
        '
        'LabelFolio
        '
        Me.LabelFolio.Location = New System.Drawing.Point(8, 18)
        Me.LabelFolio.Name = "LabelFolio"
        Me.LabelFolio.Size = New System.Drawing.Size(72, 20)
        Me.LabelFolio.Text = "LabelFolio"
        '
        'FormDevolucionDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormDevolucionDetalle"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "VARIABLES"
    Private Producto As Producto
#If MOD_TERM <> "PALM" Then
    Private WithEvents bScanner As New HANDHELD.CScanner
#End If
    Private oMMD As Modulos.GrupoModuloMovDetalle
    Private oVista As Vista
    Private oFase As Fase
    Private oModo As Modo
    Private sFolio, TransprodID As String
    Private Cambios As Boolean = False
    Private bNuevo As Boolean
    Private ClaveProd, Partida As String
    Private bFin As Boolean = False
    'Private Antes(5, 5) As String
    Private bLector As Boolean = False
#End Region

#Region "ENUMS"
    Public Enum Modo
        Capturar = 1
        Modificar = 2
        Cancelar = 3
    End Enum

    Public Enum Fase
        Cancelado = 1
        Captura = 2
        Surtido = 3
        Facturado = 4
    End Enum

    Private Enum Movimiento
        AumentaInventarioCamion = 1
        DisminuyeInventarioCamion = 2
    End Enum
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

#Region "FormDevolucionDetalle"
    Private Sub FormDevolucionDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        If oDBVen.oConexion.State = ConnectionState.Closed Then
            oDBVen.oConexion.Open()
        End If
        Transaccion = oDBVen.oConexion.BeginTransaction
        If Not Vista.Buscar("FormDevolucionDetalle", oVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        ConfiguraGrid()
        PoblarProductos(False)
        oVista.ColocarEtiquetasForma(Me)
        oVista.ColocarEtiquetasMenuEmergente(ContextMenu1)
        Application.DoEvents()
        Producto = New Producto
        oMMD = New Modulos.GrupoModuloMovDetalle
        oMMD.Recuperar(ServicesCentral.TiposModulosMovDet.DevolucionAlmacen)
        If oModo = Modo.Cancelar OrElse oFase <> Fase.Captura Then
            DesactivarScanner()
            TextBoxProducto.Enabled = False
            TextBoxCodigo.Enabled = False
            ButtonBuscar.Enabled = False
        End If
        If bNuevo Then
            Me.GuardarEncabezado()
        End If
        bFin = True
        Cursor.Current = Cursors.Default

        Me.TextBoxProducto.Focus()
        Cambios = False

    End Sub

    Private Sub TerminarVisita()
        ButtonRegresar_Click(Nothing, Nothing)
    End Sub


    Private Sub FormDevolucionDetalle_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
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

        If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
        Me.Transaccion = Nothing
    End Sub
    'Private Sub FormDevolucionDetalle_Dispose(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
    '    If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
    '    Me.Transaccion = Nothing
    'End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
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

    Private Sub ButtonBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscar.Click
        BuscaProducto()
    End Sub

    Private Sub BuscaProducto()
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
            If Partida = -1 Then 'No está en el listview
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

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        If oFase = Fase.Cancelado Then
            Me.Close()
            Exit Sub
        End If
        If oModo = Modo.Cancelar Then
            Dim f As Integer
            If EstaActivo(TransprodID, f) Then
                oDBVen.EjecutarComandoSQL("update transprod set tipofase=0, fechacancelacion=" & UniFechaSQL(Now) & ", mfechahora=" & UniFechaSQL(Now) & ", musuarioid='" & oVendedor.UsuarioId & "',Enviado=0 where transprodid='" & TransprodID & "'")
                AfectaInventario(Movimiento.AumentaInventarioCamion)
            Else
                MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "E0037"), f), MsgBoxStyle.Information)
            End If
        ElseIf oModo = Modo.Capturar Then
            If Not HayProductosEnLV() Then
                MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "E0044"), ValorReferencia.BuscarEquivalente("TRECIBO", "4")), MsgBoxStyle.Information)
                'MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "E0044"), ValorReferencia.RecuperarLista("TRECIBO", 4).Rows(0).Item(1)), MsgBoxStyle.Information)
                Exit Sub
            End If
        ElseIf oModo = Modo.Modificar Then
            If Not HayProductosEnLV() Then
                MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "E0044"), ValorReferencia.BuscarEquivalente("TRECIBO", "4")), MsgBoxStyle.Information)
                'MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "E0044"), ValorReferencia.RecuperarLista("TRECIBO", 4).Rows(0).Item(1)), MsgBoxStyle.Information)
                Exit Sub
            End If
        End If
        Transaccion.Commit()
        If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
        Me.Transaccion = Nothing

        If oModo <> Modo.Cancelar Then
            HabilitarBotones(False)
            If oVendedor.motconfiguracion.MensajeImpresion Then
                If MsgBox(oVista.BuscarMensaje("Mensajes", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                    ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.SinVisita, TransprodID, ServicesCentral.TiposTransProd.DevolucionesAlmacen, ServicesCentral.TiposTransProd.DevolucionesAlmacen)
                End If
            End If
            HabilitarBotones(True)
        End If

        Me.Close()
    End Sub

    Private Sub HabilitarBotones(ByVal bHabilitar As Boolean)
        Me.ButtonBuscar.Enabled = bHabilitar
        Me.ButtonContinuar.Enabled = bHabilitar
        Me.ButtonRegresar.Enabled = bHabilitar
    End Sub


    Private Function HayProductosEnLV() As Boolean
        If fgDetalles.Rows.Count > 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub MenuItemEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemEliminar.Click
        Try
            If fgDetalles.Rows.Count <= 1 Then Exit Sub
            If fgDetalles.Rows(fgDetalles.Row).Node.Level > 0 Then Exit Sub
            Partida = fgDetalles.GetData(fgDetalles.Row, 0)
            ClaveProd = fgDetalles.GetData(fgDetalles.Row, 1)
            Dim i As Integer, s As String
            'Aumento al inventario del camion los productos eliminados
            s = "select tipounidad, cantidad from transproddetalle where transprodid='" & TransprodID & "' and partida=" & Partida & " and productoclave='" & ClaveProd & "'"
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(s, "a")
            For Each Dr As DataRow In Dt.Rows
                Inventario.ActualizarInventarioDec(ClaveProd, Dr("tipounidad"), Dr("cantidad"), ServicesCentral.TiposTransProd.DevolucionesAlmacen, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId)
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
        If fgDetalles.Rows.Count <= 1 Then Exit Sub
        If fgDetalles.Rows(fgDetalles.Row).Node.Level > 0 Then Exit Sub
        Partida = fgDetalles.GetData(fgDetalles.Row, 0)
        ClaveProd = fgDetalles.GetData(fgDetalles.Row, 1)
        'If Partida = Nothing OrElse ClaveProd = Nothing Then Exit Sub
        If Me.PedirProductoCantidad(Partida, ClaveProd) Then
            PoblarProductos(False)
        End If
        Partida = Nothing
        ClaveProd = Nothing
    End Sub

    Private Sub ContextMenu1_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenu1.Popup
        Me.ContextMenu1.MenuItems.Clear()
        If oModo = Modo.Cancelar OrElse oFase <> Fase.Captura OrElse fgDetalles.Rows.Count <= 1 OrElse fgDetalles.Rows(fgDetalles.Row).Node.Level > 0 Then
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

    Private Sub fgDetalles_GridChanged(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.GridChangedEventArgs) Handles fgDetalles.GridChanged
        Cambios = True
    End Sub

    'Private Sub ListViewProductos_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs)
    '    With ListViewProductos
    '        Partida = .Items(.SelectedIndices(0)).Text
    '        ClaveProd = .Items(.SelectedIndices(0)).SubItems(1).Text
    '    End With
    'End Sub
    Private Sub fgDetalles_SelChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles fgDetalles.SelChange
        If fgDetalles.Row <= 0 Then Exit Sub
        Partida = fgDetalles.GetData(fgDetalles.Row, 0)
        ClaveProd = fgDetalles.GetData(fgDetalles.Row, 1)
    End Sub
#End Region

#Region "MIS METODOS"

    Private Sub AfectaInventario(ByVal Mov As Movimiento)
        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select productoclave, tipounidad, cantidad from transproddetalle where transprodid='" & TransprodID & "'", "tabla")
        If Mov = Movimiento.AumentaInventarioCamion Then
            For Each Dr As DataRow In Dt.Rows
                Inventario.ActualizarInventarioDec(Dr("productoclave").ToString, Dr("tipounidad"), Dr("cantidad"), ServicesCentral.TiposTransProd.DevolucionesAlmacen, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId, True)
            Next
        ElseIf Mov = Movimiento.DisminuyeInventarioCamion Then
            For Each Dr As DataRow In Dt.Rows
                Inventario.ActualizarInventarioDec(Dr("productoclave").ToString, Dr("tipounidad"), Dr("cantidad"), ServicesCentral.TiposTransProd.DevolucionesAlmacen, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, True)
            Next
        End If
        Dt.Dispose()
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
        Dim dt As DataTable = oDBVen.RealizarConsultaSQL("select transproddetalle.Partida, transproddetalle.productoclave, producto.Nombre, cantidad, tipounidad from transproddetalle, producto where transproddetalle.productoclave=producto.productoclave and TransProdDetalle.TransProdId='" & TransprodID & "' order by transproddetalle.partida", "Devoluciones")
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
            .Rows.Count = 1
            .Cols(0).Caption = oVista.BuscarMensaje("Mensajes", "Numero")
            .Cols(1).Caption = oVista.BuscarMensaje("Mensajes", "PROProductoClave")
            .Cols(2).Caption = oVista.BuscarMensaje("Mensajes", "PRONombre")
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
        'If fgDetalles.Rows.Count > 0 Then
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
            Dim dtProductos As DataTable = oDBVen.RealizarConsultaSQL("SELECT DISTINCT Producto.ProductoClave, Producto.Nombre FROM Producto INNER JOIN Inventario ON Producto.ProductoClave = Inventario.ProductoClave WHERE (Inventario.AlmacenID='" & oVendedor.AlmacenId & "') AND Inventario.NoDisponible >0 " & IIf(.FiltroProductosIncluyeTabla = "", "", " AND " & .FiltroProductosIncluyeTabla), "ProdDevolucion")
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
            .Cols(0).Caption = oVista.BuscarMensaje("Mensajes", "PROProductoClave")
            .Cols(1).Caption = oVista.BuscarMensaje("Mensajes", "PRONombre")
            .Cols(0).Width = 100
            .Cols(1).Width = 280
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .AutoResize = True
        End With
    End Sub
    ' Guardar el detalle del pedido
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
                    Inventario.ObtenerCantidadAActualizar(oMMD.TipoMovimiento, dCantidad, dCantidadAnterior)
                    Inventario.ActualizarInventarioDec(refparoFormPedirProducto.Producto.ProductoClave, .TipoUnidad, dCantidad, oMMD.TipoTransProd, oMMD.TipoMovimiento, oVendedor.AlmacenId)
                End With
            Next
        Catch ExcA As SqlServerCe.SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarProducto")
        End Try
        sComandoSQL = Nothing
    End Sub
#End Region

#Region "FUNCIONES"
    Private Function PedirProductoCantidad(ByVal pariPartida As Integer, Optional ByVal optparsProductoClave As String = "") As Boolean
        ' Cargar la forma para pedir el producto, cantidad y unidad
        Dim oFormPedirProducto As New FormPedirProducto
        Dim bResp As Boolean
        With oFormPedirProducto
            .TransProdId = Me.TransprodID
            .FolioActual = Me.sFolio
            .TipoTransProd = oMMD.TipoTransProd
            .TipoMovimiento = oMMD.TipoMovimiento
            .ModuloMovDetalle = oMMD
            .Partida = pariPartida
            Me.Producto.ProductoClave = optparsProductoClave
            .Producto = Me.Producto
            '.NombreListViewProductos = "ListViewDevoluciones"
            AddHandler .PoblarListaProductos, AddressOf PoblarListViewProductos
            AddHandler .GuardarDetalle, AddressOf GuardarDetalleProductos

            If optparsProductoClave <> "" Then
                .PermitirConsultarProductos = False
            End If

            .MostrarExistencia = True
        End With

        If oFormPedirProducto.ShowDialog() = Windows.Forms.DialogResult.OK Then
            bResp = True
            Me.TextBoxProducto.Focus()
        Else
            bResp = False
        End If
        With oFormPedirProducto
            RemoveHandler .GuardarDetalle, AddressOf GuardarDetalleProductos
            RemoveHandler .PoblarListaProductos, AddressOf PoblarListViewProductos
            .Dispose()
            '.DetailViewUnidades.Dispose()
            oFormPedirProducto = Nothing
        End With
        Return bResp
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
                sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "',Enviado = 0 ")
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
                Folio.Confirmar(, ServicesCentral.TiposModulosMovDet.DevolucionAlmacen)
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

    Private Function ObtienePartida(ByVal clave As String) As Integer
        With fgDetalles
            Dim n As Integer = .Rows.Count
            If n = 1 Then Return -1
            Dim i As Integer
            For i = 1 To n - 1
                If .GetData(i, 1).ToString = clave Then
                    Return .GetData(i, 0)
                End If
            Next
            Return -1
        End With
    End Function

    Private Function EstaActivo(ByVal clave As String, ByRef Fase As Integer) As Boolean
        Try
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select tipofase from transprod where transprodid='" & TransprodID & "'", "consulta")
            Dim Dr As DataRow = Dt.Rows(0)
            If Dr(0) = 1 Then
                Dt.Dispose()
                Return True
            Else
                Fase = Dr(0)
                Dt.Dispose()
                Return False
            End If
        Catch ex As Exception

        End Try
    End Function

#End Region

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        ButtonRegresar_Click(Nothing, Nothing)
    End Sub


    Private Sub TextBoxProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxProducto.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                e.Handled = True
                BuscaProducto()
        End Select
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