Imports System.Data.SqlServerCe
Public Class FormVentaConsignacion

#Region "Enumeraciones"
    Public Enum Navegacion
        MostrarNavegacion = 0
        IrACrear = 1
    End Enum
    Private Enum TipoEstado
        Navegando = 1
        Creando
        Modificando
        Eliminar
        Liquidar
    End Enum
#End Region

#Region "Propiedades y Variables"
    Private _transProd As TransProd
    Private _navegacion As Navegacion
    Private oVista As Vista
    Private blnSeleccionManual As Boolean
    Private eEstado As TipoEstado
    Private usoTransProd As TransProd
    Private oImpuesto As Impuesto
    Private bHuboCambio As Boolean = False
    Private _visita As String
    Private bCrear As Boolean = False
    Private DTProductoPrestamoCli As DataTable

    Public Property oNavegacion() As Navegacion
        Get
            Return _navegacion
        End Get
        Set(ByVal value As Navegacion)
            _navegacion = value
        End Set
    End Property
    Public Property oTransProd() As TransProd
        Get
            Return _transProd
        End Get
        Set(ByVal value As TransProd)
            _transProd = value
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
    Private oProducto As Producto
#End Region

#Region "Eventos"

    Private Sub FormVentaConsignacion_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
        Me.Transaccion = Nothing
    End Sub

    Private Sub FormVentaConsignacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.AgregarControl(Me)
            Me.Panel1.SendToBack()
            ctrlSeguimiento.Dock = DockStyle.Top
            ctrlSeguimiento.CrearMenuItem(Me.MainMenuCargas)
            AddHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
            AddHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
        End If

        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.Iniciar()
            Me.lbNombreActividad.Visible = False
        Else
            Me.lbNombreActividad.Dock = DockStyle.Top
            Me.lbNombreActividad.Text = sNombreActividad
            Me.lbNombreActividad.BringToFront()
        End If

        If Not Vista.Buscar("FormVentaConsignacion", oVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        oVista.ColocarEtiquetasForma(Me)
        Application.DoEvents()
        oVista.CrearListView(ListViewConsignacion, "ListViewConsignacion")
        oVista.ColocarEtiquetasMenuEmergente(ContextMenuNavegacion)
        oVista.ColocarEtiquetasMenuEmergente(ContextMenu2)
        ConfiguraGrid()
        ConfiguraGridLiquida()
        oProducto = New Producto()
        oImpuesto = New Impuesto()

        Select Case _navegacion
            Case Navegacion.MostrarNavegacion
                MostrarNavegacion()
            Case Navegacion.IrACrear
                MostrarDetalle()
        End Select
        DTProductoPrestamoCli = oDBVen.RealizarConsultaSQL("Select * from ProductoPrestamoCli where ClienteClave='" & Me.oTransProd.ClienteActual.ClienteClave & "'", "ProductoPrestamoCli")
        [Global].HabilitarMenuItem(Me.MainMenuCargas, True)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub TerminarVisita()
        Cerrar()
    End Sub

    Private Sub ButtonRegresarLista_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresarLista.Click
        Cerrar()
    End Sub
    Private Sub ButtonRegresarDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresarDet.Click, ButtonLRegresar.Click
        Regresar()
    End Sub
    Private Sub ButtonContinuarLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuarLista.Click
        Dim iValor As Integer = PermiteEliminacion()
        Select Case iValor
            Case 0, 3
                MostrarDetalle()
            Case 1
                eEstado = TipoEstado.Modificando
                MostrarLiquidacion()
            Case 2
                MessageBox.Show(oVista.BuscarMensaje("MsgBox", "E0688").Replace("$0$", oVista.BuscarMensaje("MsgBox", "XConsignacion")))
        End Select
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        If PanelLista.Visible = True Then
            Cerrar()
        End If
        If PanelLista.Visible = False And (PanelDetalle.Visible = True Or PanelLiquidacion.Visible = True) Then
            Regresar()
        End If
    End Sub
    Private Sub ButtonBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProducto.Click
        'Se quitan los espacios porque generaba problemas al no encontrar el producto
        Me.TextBoxProducto.Text = Me.TextBoxProducto.Text.Trim()
        ' Llamar la forma para pedir las cantidades por unidad, ademas de buscar
        If TextBoxProducto.Text.Trim = String.Empty Then
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
            If oProducto.Buscar(Me.TextBoxProducto.Text, CheckBoxProducto.Checked) Then
                Me.ModificarMovimiento(0, oProducto.ProductoClave)
            Else
                If Me.CheckBoxProducto.Visible And CheckBoxProducto.Checked Then
                    MsgBox(oVista.BuscarMensaje("MsgBox", "NoExisteProducto"), MsgBoxStyle.Exclamation)
                Else
                    MsgBox(oVista.BuscarMensaje("MsgBox", "NoExisteProd"), MsgBoxStyle.Exclamation)
                End If

                Me.TextBoxProducto.SelectionStart = 0
                Me.TextBoxProducto.SelectionLength = Len(Me.TextBoxProducto.Text)
                Me.TextBoxProducto.Focus()
        End If
        End If
    End Sub
    Private Sub ListViewConsignacion_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewConsignacion.ItemCheck
        If blnSeleccionManual Then Exit Sub
        blnSeleccionManual = True
        MarcarElemento(ListViewConsignacion, e.NewValue, e.Index)
        blnSeleccionManual = False
        If ListViewConsignacion.SelectedIndices.Count <= 0 Then Exit Sub
        If e.NewValue = CheckState.Unchecked Then
            blnSeleccionManual = True
            ListViewConsignacion.Items(ListViewConsignacion.SelectedIndices(0)).Selected = False
            blnSeleccionManual = False
        End If
    End Sub
    Private Sub TabVentaConsignacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabVentaConsignacion.SelectedIndexChanged
        If TabVentaConsignacion.SelectedIndex = 1 Then
            If fgDetalles.Rows.Count > 1 Then
                CalcularGeneral()
            Else
                TabVentaConsignacion.SelectedIndex = 0
                MessageBox.Show(oVista.BuscarMensaje("MsgBox", "E0044").Replace("$0$", oVista.BuscarMensaje("MsgBox", "XConsignacion")), usoTransProd.ModuloMovDetalle.Nombre)
            End If
        End If
    End Sub
    Private Sub ButtonContinuarDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuarDet.Click
        TabVentaConsignacion.SelectedIndex = 1
    End Sub
    Private Sub ButtonGTerminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGTerminar.Click
        ButtonGTerminar.Enabled = False
        ButtonGRegresar.Enabled = False
        Application.DoEvents()
        TerminarConsignacion()
        ButtonGTerminar.Enabled = True
        ButtonGRegresar.Enabled = True
    End Sub

    Private Sub ButtonGRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGRegresar.Click
        TabVentaConsignacion.SelectedIndex = 0
    End Sub

    Private Sub TextBoxProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxProducto.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                e.Handled = True
                'Se quitan los espacios porque generaba problemas al no encontrar el producto
                Me.TextBoxProducto.Text = Me.TextBoxProducto.Text.Trim()

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
                    If oProducto.Buscar(Me.TextBoxProducto.Text, CheckBoxProducto.Checked) Then
                        Me.ModificarMovimiento(0, oProducto.ProductoClave)
                    Else
                        If Me.CheckBoxProducto.Visible And CheckBoxProducto.Checked Then
                            MsgBox(oVista.BuscarMensaje("MsgBox", "NoExisteProducto"), MsgBoxStyle.Exclamation)
                        Else
                            MsgBox(oVista.BuscarMensaje("MsgBox", "NoExisteProd"), MsgBoxStyle.Exclamation)
                        End If
                        Me.TextBoxProducto.SelectionStart = 0
                        Me.TextBoxProducto.SelectionLength = Len(Me.TextBoxProducto.Text)
                        Me.TextBoxProducto.Focus()
                    End If
                End If
        End Select
    End Sub

    Private Sub CheckBoxProducto_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxProducto.CheckStateChanged
        If IsNothing(oVista) Then
            Return
        End If
        If CheckBoxProducto.Checked Then
            CheckBoxProducto.Text = "LabelProductoId"
        Else
            CheckBoxProducto.Text = "LabelProducto"
        End If
        oVista.ColocarEtiquetasControl(CheckBoxProducto)
    End Sub
    Private Sub MenuItemModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemModificar.Click
        If fgDetalles.Rows.Count = 0 OrElse Not fgDetalles.Rows(fgDetalles.Row).IsNode OrElse (fgDetalles.Rows(fgDetalles.Row).Node.Level = 1) Then
            Exit Sub
        End If
        Me.ModificarMovimiento(fgDetalles.GetData(fgDetalles.Row, 6), fgDetalles.GetData(fgDetalles.Row, 0))
    End Sub

#End Region

#Region "Metodos"
    Private Sub Cerrar()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub Regresar()
        Dim drRes As DialogResult = Windows.Forms.DialogResult.Yes
        If bHuboCambio Then
            drRes = MessageBox.Show(oVista.BuscarMensaje("MsgBox", "BP0002"), oTransProd.ModuloMovDetalle.Nombre, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        End If
        If drRes = Windows.Forms.DialogResult.Yes Then
            If eEstado = TipoEstado.Modificando Or eEstado = TipoEstado.Eliminar Then
                usoTransProd.ClienteActual.ActualizarSaldo(usoTransProd.Total)
            End If
            MostrarNavegacion()
        End If
    End Sub
    Private Sub PoblarNavegacion()
        oVista.PoblarListView(ListViewConsignacion, oDBVen, "ListViewConsignacion", " AND ClienteClave = '" + oTransProd.ClienteActual.ClienteClave + "'") 'VisitaClave = '" + oTransProd.VisitaActual + "' AND "' AND DiaClave = '" + oDia.DiaActual + 
        Dim total As Double = 0
        For i As Integer = 0 To ListViewConsignacion.Items.Count - 1
            Try
                total += Convert.ToDouble(ListViewConsignacion.Items(i).SubItems(2).Text)
            Catch ex As Exception
            End Try
        Next
        LabelTotalSaldoNF.Text = Format(total, oApp.FormatoDinero)
    End Sub

    Private Sub MostrarNavegacion()

        If Not Me.Transaccion Is Nothing Then
            Try
                Me.Transaccion.Rollback()
                Me.Transaccion.Dispose()
                Me.Transaccion = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
        eEstado = TipoEstado.Navegando
        PoblarNavegacion()

        PanelLista.Visible = True
        PanelDetalle.Visible = False
        DesactivarScanner()
        blnScannerActivo = False

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.Dock = DockStyle.Top
        Else
            Me.lbNombreActividad.Dock = DockStyle.Top
        End If

        'Cerrar en caso de que sea al dar click al boton de regresar
        If Not PanelLista.Visible AndAlso ListViewConsignacion.Items.Count = 0 Then
            Cerrar()
        End If

    End Sub
    Private Sub MostrarDetalle()
        Cursor.Current = Cursors.WaitCursor
        bHuboCambio = False
        If Not usoTransProd Is Nothing Then
            usoTransProd.Dispose()
            usoTransProd = Nothing
        End If
        usoTransProd = New TransProd
        usoTransProd.Reiniciar()
        usoTransProd.ListasPrecios = New ListasPreciosCliente
        If ListViewConsignacion.SelectedIndices.Count <= 0 Then
            With Me.usoTransProd
                .TransProdId = ""
                .VisitaActual = oTransProd.VisitaActual
                .ClienteActual = oTransProd.ClienteActual
                .ClienteClave = oTransProd.ClienteClave
                .ModuloMovDetalle = oTransProd.ModuloMovDetalle
                .Tipo = oTransProd.ModuloMovDetalle.TipoTransProd
                .TipoMovimiento = oTransProd.ModuloMovDetalle.TipoMovimiento
                .TipoFase = ServicesCentral.TiposFasesPedidos.Surtido
                .FechaSurtido = Now
                .FechaCaptura = oDia.FechaCaptura
                .FechaHoraAlta = Now
                If Not .ListasPrecios.Recuperar(usoTransProd.ClienteActual, usoTransProd.ModuloMovDetalle) Then
                    Cursor.Current = Cursors.Default
                    Exit Sub
                End If
            End With
            eEstado = TipoEstado.Creando
        Else
            Dim refListViewItemSel As ListViewItem = ListViewConsignacion.Items(ListViewConsignacion.SelectedIndices(0))
            usoTransProd.TransProdId = refListViewItemSel.SubItems(5).Text
            usoTransProd.Recuperar()
            usoTransProd.ClienteActual = oTransProd.ClienteActual
            usoTransProd.ModuloMovDetalle = oTransProd.ModuloMovDetalle
            If eEstado <> TipoEstado.Eliminar Then
                eEstado = TipoEstado.Modificando
            End If
        End If
        If usoTransProd.ListasPrecios.ListasPrecios.Count > 0 Then
            LabelListaPrecios.Text = usoTransProd.ListasPrecios.ListasPrecios.Values(0).PrecioClave + " - " + usoTransProd.ListasPrecios.ListasPrecios.Values(0).Nombre
        End If
        cVista()
        Cursor.Current = Cursors.Default
        If eEstado <> TipoEstado.Navegando Then
            If eEstado <> TipoEstado.Eliminar Then
                blnScannerActivo = True
                ActivarScanner()
            End If
            TabVentaConsignacion.SelectedIndex = 0
            PanelDetalle.Visible = True
            PanelLista.Visible = False

            If [Global].PosicionarControl() Then
                If oVendedor.motconfiguracion.Secuencia Then
                    ctrlSeguimiento.Dock = DockStyle.None
                    ctrlSeguimiento.Size = New System.Drawing.Size((Me.TabVentaConsignacion.Size.Width * nFactorW), ctrlSeguimiento.Size.Height * nFactorH)
                    ctrlSeguimiento.Location = New System.Drawing.Point(1, (Me.PanelDetalle.Location.Y + 25) * nFactorH)
                    ctrlSeguimiento.RefrescaEscribe()
                Else
                    Me.lbNombreActividad.Dock = DockStyle.None
                    Me.lbNombreActividad.Size = New System.Drawing.Size((Me.TabVentaConsignacion.Size.Width * nFactorW), Me.lbNombreActividad.Size.Height * nFactorH)
                    'ctrlSeguimiento.Size = New System.Drawing.Size((Me.TabVentaConsignacion.Size.Width * nFactorW), Me.lbNombreActividad.Size.Height * nFactorH)
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
    End Sub
 
    Private Sub MostrarLiquidacion()
        Cursor.Current = Cursors.WaitCursor
        bHuboCambio = False
        Dim refListViewItemSel As ListViewItem = ListViewConsignacion.Items(ListViewConsignacion.SelectedIndices(0))
        LabelLFolio.Tag = refListViewItemSel.SubItems(5).Text
        If Not usoTransProd Is Nothing Then
            usoTransProd.Dispose()
            usoTransProd = Nothing
        End If
        usoTransProd = New TransProd
        usoTransProd.Reiniciar()
        usoTransProd.ListasPrecios = New ListasPreciosCliente
        usoTransProd.TransProdId = refListViewItemSel.SubItems(5).Text
        If Not usoTransProd.Recuperar() Then
            MessageBox.Show("No Movimiento")
        Else
            LabelLFolio.Text = usoTransProd.FolioActual

            PoblarGridLiquida()
            ButtonLTerminar.Enabled = True
            fgLiquida.Cols(3).AllowEditing = True
            If eEstado = TipoEstado.Modificando Then
                Dim oTmp As Generic.Dictionary(Of String, Object) = oDBVen.RealizarReaderSQLconCampos("select min(fechaCaptura) as ini , max(fechaCaptura) as fin from dia where FueraFrecuencia =0")
                Dim dIni As DateTime = oTmp("ini")
                Dim dFin As DateTime = oTmp("fin")

                If Not (usoTransProd.FechaFacturacion >= dIni And usoTransProd.FechaFacturacion < dFin.AddDays(1)) OrElse usoTransProd.Enviado Then
                    ButtonLTerminar.Enabled = False
                    fgLiquida.Cols(3).AllowEditing = False
                End If
            End If

            eEstado = TipoEstado.Liquidar

            PanelLiquidacion.Visible = True
            PanelLista.Visible = False
            PanelDetalle.Visible = False
            If oVendedor.motconfiguracion.Secuencia Then
                ctrlSeguimiento.Dock = DockStyle.Top
            Else
                Me.lbNombreActividad.Dock = DockStyle.Top
            End If

        End If
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub cVista()
        If eEstado = TipoEstado.Creando OrElse eEstado = TipoEstado.Modificando OrElse eEstado = TipoEstado.Eliminar Then
            If oDBVen.oConexion.State = ConnectionState.Closed Then
                oDBVen.oConexion.Open()
            End If
            Me.Transaccion = oDBVen.oConexion.BeginTransaction()
        End If
        Dim bHabilitar As Boolean = True
        Select Case eEstado
            Case TipoEstado.Creando
                Dim sFolio As String = String.Empty
                sFolio = Folio.Obtener(oTransProd.ModuloMovDetalle.ModuloMovDetalleClave)
                If sFolio = "" Then
                    eEstado = TipoEstado.Navegando
                    Exit Sub
                End If
                usoTransProd.FolioActual = sFolio
                LimpiarCampos()

                Folio.ObtenerTransProdId(usoTransProd.TransProdId)
                usoTransProd.Actualizar()
            Case TipoEstado.Modificando
                TextBoxGComentarios.Text = usoTransProd.Notas
                PoblarGrid()
                Dim oDt As DataTable = oDBVen.RealizarConsultaSQL("Select TransProdDetalleId, ProductoClave, TipoUnidad, Cantidad From TransProdDetalle where TransProdId='" & usoTransProd.TransProdId & "'", "Detalle")
                For Each oDr As DataRow In oDt.Rows
                    Inventario.ActualizarInventarioDec(oDr("ProductoClave"), oDr("TipoUnidad"), oDr("Cantidad"), ServicesCentral.TiposTransProd.VentaConsignacion, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId)
                Next
                usoTransProd.ClienteActual.ActualizarSaldo(-usoTransProd.Total)
            Case TipoEstado.Eliminar
                bHabilitar = False
                TextBoxGComentarios.Text = usoTransProd.Notas
                PoblarGrid()
                Dim oDt As DataTable = oDBVen.RealizarConsultaSQL("Select TransProdDetalleId, ProductoClave, TipoUnidad, Cantidad From TransProdDetalle where TransProdId='" & usoTransProd.TransProdId & "'", "Detalle")
                For Each oDr As DataRow In oDt.Rows
                    Inventario.ActualizarInventarioDec(oDr("ProductoClave"), oDr("TipoUnidad"), oDr("Cantidad"), ServicesCentral.TiposTransProd.VentaConsignacion, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId, True)

                    'Crear Saldo de Envases del Cliente
                    If usoTransProd.ClienteActual.Prestamo Then
                        ProductoPrestamoCli.ActulizarProductoPrestamoCli(usoTransProd.ClienteActual.ClienteClave, oDr("ProductoClave"), -1 * oDr("Cantidad"), oDr("TipoUnidad"), 0, usoTransProd.Tipo, usoTransProd.TipoMotivo)
                    End If
                Next
                usoTransProd.ClienteActual.ActualizarSaldo(-usoTransProd.Total)
        End Select
        ButtonBuscarProducto.Enabled = bHabilitar
        TextBoxGComentarios.ReadOnly = Not bHabilitar
        TextBoxCodigo.ReadOnly = Not bHabilitar
        TextBoxProducto.ReadOnly = Not bHabilitar
        CheckBoxProducto.Enabled = bHabilitar
    End Sub
    Private Sub LimpiarCampos()
        TextBoxProducto.Text = ""
        TextBoxCodigo.Text = ""
        TextBoxGComentarios.Text = ""
        PoblarGrid()
    End Sub
    Private Sub ConfiguraGrid()
        With fgDetalles
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 7
            .Cols(0).Caption = oVista.BuscarMensaje("MsgBox", "PROProductoClave")
            .Cols(1).Caption = oVista.BuscarMensaje("MsgBox", "PRONombre")
            .Cols(2).Caption = oVista.BuscarMensaje("MsgBox", "Subtotal")
            .Cols(3).Caption = oVista.BuscarMensaje("MsgBox", "Impuesto")
            .Cols(4).Caption = oVista.BuscarMensaje("MsgBox", "Total")
            .Cols(5).Visible = False
            .Cols(6).Visible = False
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

    Private Sub PoblarGrid()
        fgDetalles.Rows.Count = 1
        If usoTransProd.TransProdId <> "" Then
            fgDetalles.Rows.Count = 1
            Dim dt As DataTable = oVista.TablaListView(oDBVen, "ListViewMovimientos", "WHERE TransProdDetalle.TransProdId='" & usoTransProd.TransProdId & "'")
            Dim sPartida As String = ""
            fgDetalles.Redraw = False
            Dim r As C1.Win.C1FlexGrid.Row
            Dim dSubTotal As Double = 0
            Dim iProductos As New Generic.List(Of String)
            For Each dr As DataRow In dt.Rows
                If sPartida <> dr("Partida").ToString Then
                    sPartida = dr("Partida").ToString
                    r = fgDetalles.Rows.Add
                    r.IsNode = True
                    r.Node.Level = 0
                    With fgDetalles
                        .Item(r.Index, 0) = dr("ProductoClave")
                        .Item(r.Index, 1) = dr("Nombre")
                        .Item(r.Index, 2) = Format(dr("SubTotal"), "#,##0.00")
                        .Item(r.Index, 3) = Format(dr("Impuesto"), "#,##0.00")
                        .Item(r.Index, 4) = Format(dr("Total"), "#,##0.00")
                        .Item(r.Index, 5) = dr("Promocion")
                        .Item(r.Index, 6) = dr("Partida")
                    End With
                Else
                    With fgDetalles
                        .Item(r.Index, 2) = Format(CDbl(.Item(r.Index, 2)) + dr("SubTotal"), "#,##0.00")
                        .Item(r.Index, 3) = Format(CDbl(.Item(r.Index, 3)) + dr("Impuesto"), "#,##0.00")
                        .Item(r.Index, 4) = Format(CDbl(.Item(r.Index, 4)) + dr("Total"), "#,##0.00")
                    End With
                End If
                dSubTotal += Convert.ToDouble(dr("Total"))
                If Not iProductos.Contains(dr("ProductoClave")) Then
                    iProductos.Add(dr("ProductoClave"))
                End If
                Dim r2 As C1.Win.C1FlexGrid.Row = fgDetalles.Rows.Add
                r2.IsNode = True
                r2.Node.Level = 1
                With fgDetalles
                    .Item(r2.Index, 0) = ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad"))
                    .Item(r2.Index, 1) = dr("Cantidad")
                    .Item(r2.Index, 6) = dr("Partida")
                End With
            Next
            LabelTotalImporteF.Text = String.Format("{0:" + oApp.FormatoDinero + "}", dSubTotal)
            LabelTotalProductosF.Text = iProductos.Count.ToString()
            For i As Integer = 1 To fgDetalles.Rows.Count - 1
                fgDetalles.Rows(i).Node.Collapsed = True
            Next
        Else
            LabelTotalImporteF.Text = String.Format("{0:" + oApp.FormatoDinero + "}", 0)
            LabelTotalProductosF.Text = "0"
        End If

        fgDetalles.Redraw = True
    End Sub

    Private Sub ConfiguraGridLiquida()
        With fgLiquida
            .Redraw = False
            .AllowEditing = True
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 9
            .Cols(0).Caption = "" 'oVista.BuscarMensaje("MsgBox", "PROProductoClave")
            .Cols(0).AllowEditing = False
            .Cols(0).Width = 50
            .Cols(1).Caption = oVista.BuscarMensaje("MsgBox", "XUnidad")
            .Cols(1).AllowEditing = False
            .Cols(2).Caption = oVista.BuscarMensaje("MsgBox", "Cantidad")
            .Cols(2).AllowEditing = False
            .Cols(3).Caption = oVista.BuscarMensaje("MsgBox", "Devolucion")
            .Cols(3).DataType = GetType(Double)
            .Cols(4).Caption = oVista.BuscarMensaje("MsgBox", "XLiquidar")
            .Cols(4).AllowEditing = False
            .Cols(5).Visible = False
            .Cols(5).AllowEditing = False
            .Cols(6).Visible = False
            .Cols(6).AllowEditing = False
            .Cols(7).Visible = False
            .Cols(7).AllowEditing = False
            .Cols(8).Visible = False
            .Cols(8).AllowEditing = False
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
    Private Sub PoblarGridLiquida()
        fgLiquida.Rows.Count = 1
        fgLiquida.Col = 0
        If Not LabelLFolio.Tag Is Nothing And LabelLFolio.Tag.ToString() <> "" Then
            fgLiquida.Rows.Count = 1
            Dim dt As DataTable = oVista.TablaListView(oDBVen, "ListViewLiquida", "WHERE TransProdDetalle.TransProdId='" & LabelLFolio.Tag.ToString() & "'")
            Dim sPartida As String = ""
            fgLiquida.Redraw = False
            Dim r As C1.Win.C1FlexGrid.Row
            Dim iProductos As New Generic.List(Of String)
            For Each dr As DataRow In dt.Rows
                If sPartida <> dr("Partida").ToString Then
                    sPartida = dr("Partida").ToString
                    r = fgLiquida.Rows.Add
                    r.IsNode = True
                    r.Node.Level = 0
                    With fgLiquida
                        .Item(r.Index, 0) = dr("ProductoClave")
                        .Item(r.Index, 1) = dr("Nombre")
                        .Item(r.Index, 2) = Format(dr("Total"), oApp.FormatoDinero)
                        .Item(r.Index, 6) = dr("Partida")
                    End With
                Else
                    With fgLiquida
                        .Item(r.Index, 2) = Format(CDbl(.Item(r.Index, 2)) + dr("Total"), oApp.FormatoDinero)
                    End With
                End If
                If Not iProductos.Contains(dr("ProductoClave")) Then
                    iProductos.Add(dr("ProductoClave"))
                End If
                Dim r2 As C1.Win.C1FlexGrid.Row = fgLiquida.Rows.Add
                r2.IsNode = True
                r2.Node.Level = 1

                With fgLiquida
                    .Item(r2.Index, 1) = ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad"))
                    .Item(r2.Index, 2) = dr("Cantidad")
                    .Item(r2.Index, 3) = dr("Devolucion")
                    .Item(r2.Index, 4) = Convert.ToDouble(dr("Cantidad")) - Convert.ToDouble(dr("Devolucion"))
                    .Item(r2.Index, 5) = dr("TransProdDetalleId")
                    .Item(r2.Index, 6) = dr("TipoUnidad")
                    .Item(r2.Index, 7) = dr("Precio")
                    .Item(r2.Index, 8) = dr("Devolucion")
                End With
            Next
            For i As Integer = 1 To fgLiquida.Rows.Count - 1
                fgLiquida.Rows(i).Node.Collapsed = True
            Next

        End If
        CalcularTotalLiquidacion()
        fgLiquida.Redraw = True
    End Sub

    Private Sub CalcularTotalLiquidacion()
        Dim dSubTotal As Decimal = 0
        Dim dDevolucion As Decimal = 0
        Dim dDevolucionDif As Decimal = 0
        Dim sProducto As String = ""
        Dim dSaldo As Decimal = usoTransProd.Saldo

        For Each fila As C1.Win.C1FlexGrid.Row In fgLiquida.Rows
            If fila.IsNode AndAlso fila.Node.Level = 1 Then
                dSubTotal += CalcularTotalPrecio(sProducto, fgLiquida.Item(fila.Index, 4) * fgLiquida.Item(fila.Index, 7))
                dDevolucion += CalcularTotalPrecio(sProducto, (fgLiquida.Item(fila.Index, 3)) * fgLiquida.Item(fila.Index, 7))
                dDevolucionDif += CalcularTotalPrecio(sProducto, (fgLiquida.Item(fila.Index, 8)) * fgLiquida.Item(fila.Index, 7))
            Else
                sProducto = fgLiquida.Item(fila.Index, 0)
            End If
        Next
        dSaldo += dDevolucionDif
        LabelLGTotalF.Text = Format(dSubTotal, oApp.FormatoDinero)
        LabelLTotDevF.Text = Format(Math.Abs(dDevolucion), oApp.FormatoDinero)
        LabelLSaldoF.Text = Format((dSaldo - dDevolucion), oApp.FormatoDinero)
        LabelLSaldoF.Tag = (dSaldo - dDevolucion)
    End Sub
    Private Function CalcularTotalPrecio(ByVal parsProducto As String, ByVal pardSubTotal As Double) As Double
        If pardSubTotal <> 0 Then
            Dim aImpuestos As New ArrayList
            Dim resp As Double = 0
            Dim negativo As Boolean = False
            If pardSubTotal < 0 Then
                pardSubTotal = pardSubTotal * -1
                negativo = True
            End If
            oImpuesto.Buscar(parsProducto, oTransProd.ClienteActual.TipoImpuesto, aImpuestos)
            Dim dImpuesto As Decimal = RedondeoAritmetico(oImpuesto.Calcular(aImpuestos, pardSubTotal), 2)
            resp = pardSubTotal + dImpuesto
            If negativo Then
                resp = resp * -1
            End If
            Return resp
        End If
        Return 0
    End Function


    Private Sub AgregarMovimiento()
        'Se quitan los espacios porque generaba problemas al no encontrar el producto
        TextBoxProducto.Text = TextBoxProducto.Text.Trim()
        If Me.PedirProductoCantidad(0, Me.TextBoxProducto.Text) Then
            bHuboCambio = True
            PoblarProductos()
        End If
    End Sub
    Private Sub ModificarMovimiento(ByVal pariPartida As Integer, Optional ByVal parsProductoClave As String = "")
        If Me.PedirProductoCantidad(pariPartida, parsProductoClave) Then
            bHuboCambio = True
            PoblarProductos()
        End If
    End Sub


    Private Function BorrarMovimiento(ByVal parsiPartida As Integer) As Boolean
        Try
            ' Obtener los TransProdDetalleID del numero de partida que se va a borrar
            Dim DataTableIDs As DataTable = oDBVen.RealizarConsultaSQL("SELECT TransProdDetalleID,ProductoClave,TipoUnidad,Cantidad FROM TransProdDetalle WHERE TransProdId='" & usoTransProd.TransProdId & "' AND Partida=" & parsiPartida, "IDs")
            If DataTableIDs.Rows.Count > 0 Then
                Dim sIds As String = ""
                Dim sProductoClave As String
                For Each refDataRow As DataRow In DataTableIDs.Rows
                    sProductoClave = refDataRow("ProductoClave")
                    Dim iFactor As Integer = 1
                    iFactor = oDBVen.EjecutarCmdScalarIntSQL("select Factor from productodetalle where ProductoClave = '" & refDataRow("ProductoClave") & "' and ProductoDetClave = '" & refDataRow("ProductoClave") & "' and PRUTipoUnidad=" & refDataRow("TipoUnidad"))
                    Dim dCantidadUnitaria As Decimal = refDataRow("Cantidad") * iFactor
                    Cuotas.VerificarCuotas(oVendedor.VendedorId, oTransProd.ClienteActual.ClienteClave, refDataRow("ProductoClave"), -1 * dCantidadUnitaria, 1)
                    If sIds <> "" Then
                        sIds &= ","
                    End If
                    sIds &= "'" & refDataRow("TransProdDetalleID") & "'"
                    Inventario.ActualizarInventarioDec(sProductoClave, refDataRow("TipoUnidad"), refDataRow("Cantidad"), usoTransProd.Tipo, ServicesCentral.TiposMovimientos.NoDefinido, oVendedor.AlmacenId, True)
                Next
                oDBVen.EjecutarComandoSQL("DELETE FROM TPDImpuesto WHERE TransProdId='" & usoTransProd.TransProdId & "' AND TransProdDetalleID IN (" & sIds & ")")
                oDBVen.EjecutarComandoSQL("DELETE FROM TRPPRP WHERE TransProdId='" & usoTransProd.TransProdId & "' AND TransProdDetalleID IN (" & sIds & ")")
                oDBVen.EjecutarComandoSQL("DELETE FROM TPDDes WHERE TransProdId='" & usoTransProd.TransProdId & "' AND TransProdDetalleID IN (" & sIds & ")")
                oDBVen.EjecutarComandoSQL("DELETE FROM TPDDesVendedor WHERE TransProdId='" & usoTransProd.TransProdId & "' AND TransProdDetalleID IN (" & sIds & ")")
                Return oDBVen.EjecutarComandoSQL("DELETE FROM TransProdDetalle WHERE TransProdId='" & usoTransProd.TransProdId & "' AND TransProdDetalleID IN (" & sIds & ")")
                bHuboCambio = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "BorrarMovimiento")
        End Try
        Return False
    End Function
    Private Sub PoblarProductos()
        PoblarGrid()
    End Sub
    Private Function PedirProductoCantidad(ByVal pariPartida As Integer, Optional ByVal optparsProductoClave As String = "") As Boolean
        ' Cargar la forma para pedir el producto, cantidad y unidad
        Try

            ' Cargar la forma para pedir el producto, cantidad y unidad
            Dim oFormPedirProducto As New FormPedirProducto
            With oFormPedirProducto
                .TransProdId = usoTransProd.TransProdId
                .FolioActual = usoTransProd.FolioActual
                .ClienteActual = usoTransProd.ClienteActual
                .VisitaActual = usoTransProd.VisitaActual
                .ListasPrecios = usoTransProd.ListasPrecios
                .TipoTransProd = usoTransProd.Tipo
                .TipoMovimiento = usoTransProd.TipoMovimiento
                .ModuloMovDetalle = usoTransProd.ModuloMovDetalle
                .TipoIndice = oVendedor.TipoModulo
                .Partida = pariPartida
                .dtProductoPrestamoCli = Me.DTProductoPrestamoCli
                oProducto.ProductoClave = optparsProductoClave

                .Producto = oProducto
                If optparsProductoClave <> "" Then
                    .PermitirConsultarProductos = False
                    '.PermitirCambiarProducto = False
                End If

                If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta OrElse (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Preventa AndAlso oAgenda.RutaActual.Inventario) Then
                    .MostrarExistencia = True
                    .TipoMovimiento = usoTransProd.TipoMovimiento
                ElseIf oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                    .MostrarExistencia = True
                End If
                '*******************************

                AddHandler .PoblarListaProductos, AddressOf PoblarListViewProductos
                'AddHandler .CrearGridProductos, AddressOf ConfiguraGridfgProductos

                'AddHandler .PoblarProductosEquivalentes, AddressOf PoblarGridProductosEquivalentes
                AddHandler .GuardarDetalle, AddressOf GuardarDetalleProductos
            End With
            If oFormPedirProducto.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.TextBoxProducto.Focus()
            End If
            Me.TextBoxProducto.Text = ""
            Me.TextBoxCodigo.Text = ""
            Me.TextBoxProducto.Focus()
            With oFormPedirProducto
                RemoveHandler .GuardarDetalle, AddressOf GuardarDetalleProductos
                RemoveHandler .PoblarListaProductos, AddressOf PoblarListViewProductos
                'RemoveHandler .CrearGridProductos, AddressOf ConfiguraGridfgProductos
                'RemoveHandler .PoblarProductosEquivalentes, AddressOf PoblarGridProductosEquivalentes
                .Dispose()
                oFormPedirProducto = Nothing
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        Return True
    End Function
    Private Sub PoblarListViewProductos(ByRef refparoFormPedirProducto As FormPedirProducto, ByVal aListaEsquemas As ArrayList)
        With refparoFormPedirProducto
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Application.DoEvents()
            .fgProductos.Redraw = False
            .fgProductos.AutoResize = False

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
    Private Sub ConfiguraGridfgProductos(ByRef refparFlexGrid As C1.Win.C1FlexGrid.C1FlexGrid)
        With refparFlexGrid
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor
            .Cols.Fixed = 0
            .Cols.Count = 2
            .Cols(0).Caption = oVista.BuscarMensaje("MsgBox", "PROProductoClave")
            .Cols(1).Caption = oVista.BuscarMensaje("MsgBox", "PRONombre")
            .Cols(0).Width = 100
            .Cols(1).Width = 280
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
        End With
    End Sub
    Private Sub GuardarDetalleProductos(ByRef refparoFormPedirProducto As FormPedirProducto)
        'Try
        '    Me.DTProductoPrestamoCli = refparoFormPedirProducto.DTProductoPrestamoCli
        '    ' Determinar el numero de partida
        '    If refparoFormPedirProducto.Partida = 0 Then
        '        ' Es una nueva partida, obtener el nuevo Id
        '        If Not Folio.ObtenerTransProdPartida(refparoFormPedirProducto.TransProdId, refparoFormPedirProducto.Producto.ProductoClave, refparoFormPedirProducto.Partida) Then
        '            Exit Try
        '        End If
        '    End If

        '    ' Crear un objeto TransProdDetalle
        '    Dim oTransProdDetalle As New TransProdDetalle(usoTransProd.TransProdId, refparoFormPedirProducto.Producto.ProductoClave, refparoFormPedirProducto.Partida)

        '    ' Verificar si tiene Impuestos
        '    oTransProdDetalle.ObtenerListaImpuestos(oImpuesto, usoTransProd.ClienteActual.TipoImpuesto)
        '    'Validar los impuestos
        '    oTransProdDetalle.ValidarImpuestos(usoTransProd.ClienteActual)


        '    ' Actualizar el detalle
        '    Dim dCantidad As Decimal
        '    Dim dCantidadAnterior As Decimal
        '    For Each refProducto As FormPedirProducto.RescoItemNumeric In refparoFormPedirProducto.DetailViewUnidades.Items
        '        With refProducto
        '            If IsNumeric(.Value) Then
        '                ' Buscar el precio del producto
        '                oTransProdDetalle.TipoUnidad = .TipoUnidad
        '                If refProducto.Value <> 0 Then
        '                    If Not oTransProdDetalle.ObtenerPrecio(refparoFormPedirProducto.ListaPrecios) Then
        '                        MsgBox(refparoFormPedirProducto.refaVista.BuscarMensaje("MsgBoxVarios", "MsgBoxNoExistePrecio"), MsgBoxStyle.Information)
        '                        Exit Try
        '                    End If
        '                End If
        '                oTransProdDetalle.Cantidad = .Value
        '                If oTransProdDetalle.ActualizarDec(.TransProdDetalleID, usoTransProd.Tipo, oImpuesto, .Value, .ValorAnterior, .TipoUnidad, .Factor, ServicesCentral.TiposMovimientos.NoDefinido, Me.oTransProd.ClienteActual, Me.DTProductoPrestamoCli) Then
        '                    dCantidad = refProducto.Value
        '                    dCantidadAnterior = refProducto.ValorAnterior
        '                    'Actualizar las cuotas del Vendedor
        '                    If dCantidad <> 0 Then
        '                        Dim dCantidadUnitaria As Decimal = dCantidad * .Factor
        '                        Dim dCantidadUnitariaAnt As Decimal = dCantidadAnterior * .Factor
        '                        Cuotas.VerificarCuotas(oVendedor.VendedorId, oTransProd.ClienteActual.ClienteClave, refparoFormPedirProducto.Producto.ProductoClave, dCantidadUnitaria - dCantidadUnitariaAnt, 1)
        '                        ' Actualizar el inventario
        '                        Inventario.ObtenerCantidadAActualizar(ServicesCentral.TiposMovimientos.NoDefinido, dCantidad, dCantidadAnterior)
        '                        Inventario.ActualizarInventarioDec(refparoFormPedirProducto.Producto.ProductoClave, .TipoUnidad, dCantidad, refparoFormPedirProducto.TipoTransProd, ServicesCentral.TiposMovimientos.NoDefinido, oVendedor.AlmacenId)

        '                        'Crear Saldo de Envases del Cliente
        '                        If Me.oTransProd.ClienteActual.Prestamo Then
        '                            ProductoPrestamoCli.ActulizarProductoPrestamoCli(Me.oTransProd.ClienteActual.ClienteClave, refparoFormPedirProducto.Producto.ProductoClave, dCantidad, .TipoUnidad, 0, Me.oTransProd.Tipo, oTransProd.TipoMotivo)
        '                        End If

        '                    End If
        '                End If
        '            End If
        '        End With
        '    Next
        'Catch ExcA As SqlCeException
        '    MsgBox(ExcA.Message, MsgBoxStyle.Critical, "GuardarDetallePedido")
        'Catch ExcB As Exception
        '    MsgBox(ExcB.Message, MsgBoxStyle.Critical, "GuardarDetallePedido")
        'End Try
    End Sub
    Private Sub CalcularGeneral()

        Dim tbl As DataTable = usoTransProd.RecuperarDetalle()
        Dim oTmp As Object = tbl.Compute("SUM(SubTotal)", "")
        If Not oTmp Is DBNull.Value Then
            usoTransProd.SubTDetalle = Convert.ToDecimal(oTmp)
        Else
            usoTransProd.SubTDetalle = 0
        End If
        usoTransProd.SubTotal = usoTransProd.SubTDetalle
        oTmp = tbl.Compute("SUM(Impuesto)", "")
        If Not oTmp Is DBNull.Value Then
            usoTransProd.Impuesto = Convert.ToDecimal(oTmp)
        Else
            usoTransProd.Impuesto = 0
        End If
        oTmp = tbl.Compute("SUM(Total)", "")
        If Not oTmp Is DBNull.Value Then
            usoTransProd.Total = Convert.ToDecimal(oTmp)
        Else
            usoTransProd.Total = 0
        End If
        tbl.Clear()
        tbl.Dispose()
        tbl = Nothing

        TextBoxGFolio.Text = usoTransProd.FolioActual
        TextBoxGFase.Text = ValorReferencia.BuscarEquivalente("TRPFASE", usoTransProd.TipoFase)
        TextBoxGFecha.Text = Format(usoTransProd.FechaCaptura, oApp.FormatoFecha)
        If usoTransProd.ListasPrecios.ListasPrecios.Count > 0 Then
            TextBoxGListaPrecio.Text = usoTransProd.ListasPrecios.ListasPrecios.Values(0).PrecioClave
        End If
        TextBoxGSubTotal.Text = Format(usoTransProd.SubTotal, oApp.FormatoDinero)
        TextBoxGImpuesto.Text = Format(usoTransProd.Impuesto, oApp.FormatoDinero)
        TextBoxGTotal.Text = Format(usoTransProd.Total, oApp.FormatoDinero)

    End Sub
    Private Sub TerminarConsignacion()
        Dim fallo As Boolean = False
        Try
            Select Case eEstado
                Case TipoEstado.Creando, TipoEstado.Modificando
                    Dim DataTableDetalle As DataTable = oDBVen.RealizarConsultaSQL("SELECT ProductoClave,TipoUnidad,Cantidad FROM TransProdDetalle WHERE TransProdID='" & usoTransProd.TransProdId & "' ORDER BY Partida", "Detalle")
                    Dim sProductoClave As String
                    Dim iTipoUnidad As Integer
                    Dim dCantidad As Decimal
                    For Each refDataRow As DataRow In DataTableDetalle.Rows
                        With refDataRow
                            sProductoClave = .Item("ProductoClave")
                            iTipoUnidad = .Item("TipoUnidad")
                            dCantidad = .Item("Cantidad")
                            Inventario.ActualizarInventarioDec(sProductoClave, iTipoUnidad, dCantidad, ServicesCentral.TiposTransProd.VentaConsignacion, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, , , , usoTransProd.ClienteActual.ClienteClave)
                        End With
                    Next
                    usoTransProd.Notas = TextBoxGComentarios.Text
                    usoTransProd.Saldo = usoTransProd.Total
                    usoTransProd.Actualizar()
                    usoTransProd.ClienteActual.ActualizarSaldo(usoTransProd.Total)
                    Folio.Confirmar(usoTransProd.ModuloMovDetalle.ModuloMovDetalleClave)
                    If Not fallo Then
                        Transaccion.Commit()
                    End If
                    Transaccion.Dispose()
                    Transaccion = Nothing
                    If oVendedor.motconfiguracion.MensajeImpresion Then
                        If MsgBox(oVista.BuscarMensaje("MsgBox", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                            ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, usoTransProd.TransProdId, usoTransProd.Tipo, 25, oTransProd.ClienteActual, usoTransProd.VisitaActual)
                        End If
                    End If
                Case TipoEstado.Eliminar
                    oDBVen.EjecutarComandoSQL("DELETE FROM TPDImpuesto WHERE TransProdId='" & usoTransProd.TransProdId & "'")
                    oDBVen.EjecutarComandoSQL("DELETE FROM TRPPRP WHERE TransProdId='" & usoTransProd.TransProdId & "'")
                    oDBVen.EjecutarComandoSQL("DELETE FROM TPDDes WHERE TransProdId='" & usoTransProd.TransProdId & "'")
                    oDBVen.EjecutarComandoSQL("DELETE FROM TPDDesVendedor WHERE TransProdId='" & usoTransProd.TransProdId & "'")
                    usoTransProd.EliminarDescuentosVendedor()
                    usoTransProd.Eliminar()
                    If Not fallo Then
                        Transaccion.Commit()
                    End If
                    Transaccion.Dispose()
                    Transaccion = Nothing
            End Select
           
        Catch ex As Exception
            Transaccion.Rollback()
            MessageBox.Show(ex.Message)
            fallo = True
        End Try
       
        MostrarNavegacion()
    End Sub
#End Region

#Region "Lectura de Codigo"
    Private bLector As Boolean = False
    Private blnScannerActivo As Boolean = False
#If MOD_TERM <> "PALM" Then
    Private WithEvents bScanner As New HANDHELD.CScanner
#End If

    Private Sub ActivarScanner()
#If MOD_TERM <> "PALM" Then
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

    Private Sub FormVentaConsignacion_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        ActivarScanner()
    End Sub

    Private Sub FormVentaConsignacion_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        DesactivarScanner()
    End Sub

#If MOD_TERM <> "PALM" Then
    Private Sub bScanner_Data_Scanned(ByVal Data As String) Handles bScanner.Data_Scanned
        Me.TextBoxCodigo.Text = Data
        BuscarCodigoBarras()
    End Sub
#End If

    Private Sub BuscarCodigoBarras()
        If TextBoxCodigo.Text.Trim <> String.Empty Then
            Dim sProductoClave As String = oProducto.BuscarCodigoBarras(Me.TextBoxCodigo.Text)
            If sProductoClave <> String.Empty Then
                ModificarMovimiento(0, sProductoClave)
            Else
                MsgBox(oVista.BuscarMensaje("MsgBox", "NoExisteProducto"), MsgBoxStyle.Exclamation)
                TextBoxCodigo.SelectionStart = 0
                TextBoxCodigo.SelectionLength = Len(Me.TextBoxCodigo.Text)
                TextBoxCodigo.Focus()
            End If
        End If
        Me.TextBoxCodigo.Text = String.Empty
    End Sub
    Private Sub TextBoxCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxCodigo.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                e.Handled = True
                BuscarCodigoBarras()
        End Select
    End Sub

#End Region


    Private Sub MostrarContext()
        DesactivarScanner()

        ContextMenu2.Show(Me, Control.MousePosition)
        ActivarScanner()
    End Sub


    Private Function PermiteEliminacion() As Integer
        Dim hab As Integer = 0
        If ListViewConsignacion.SelectedIndices.Count > 0 Then
            Dim refListViewItemSel As ListViewItem = ListViewConsignacion.Items(ListViewConsignacion.SelectedIndices(0))
            Dim oTipoFase As Object = oDBVen.EjecutarCmdScalarObjSQL("SELECT TipoFase FROM Transprod WHERE TransprodId ='" + refListViewItemSel.SubItems(5).Text + "'")
            Dim TieneAbonos As Boolean = (oDBVen.EjecutarCmdScalarIntSQL("SELECT COUNT(*) FROM AbnTrp WHERE TransprodId ='" + refListViewItemSel.SubItems(5).Text + "'") > 0)
            Dim bVisitaActual As Boolean = oDBVen.EjecutarCmdScalarStrSQL("SELECT visitaclave  FROM Transprod WHERE TransprodId ='" + refListViewItemSel.SubItems(5).Text + "'") = _visita

            If oTipoFase <> ServicesCentral.TiposFasesPedidos.Surtido Then
                hab = 1
            ElseIf TieneAbonos Then
                hab = 2
            ElseIf Not bVisitaActual Then
                hab = 3
            End If
        End If

        Return hab
    End Function
    'Private Function EstaLiquidado() As Boolean
    '    Try
    '        If ListViewConsignacion.SelectedIndices.Count >= 0 Then
    '            Dim refListViewItemSel As ListViewItem = ListViewConsignacion.Items(ListViewConsignacion.SelectedIndices(0))
    '            Dim oTipoFase As Object = oDBVen.EjecutarCmdScalarObjSQL("SELECT TipoFase FROM Transprod WHERE TransprodId ='" + refListViewItemSel.SubItems(4).Text + "'")
    '            If oTipoFase <> ServicesCentral.TiposFasesPedidos.Surtido Then
    '                Return True
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try

    '    Return False
    'End Function

    Private Sub MenuItemModificarN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemModificarN.Click
        MostrarDetalle()
    End Sub

    Private Sub MenuItemDetallesN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemDetallesN.Click
        MostrarDetalle()
    End Sub

    Public Sub New(ByVal vVisita As String)
        MyBase.New()
        InitializeComponent()
        _visita = vVisita
        If g_SO = SO.WindowsCE Then
            Call InTheHand.Windows.Forms.ContextMenuHelper.HookAllControls(Me.Controls)
        End If

        ListViewConsignacion.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        ListViewConsignacion.Activation = oApp.TipoSeleccion
    End Sub

    Private Sub ContextMenu1_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenu1.Popup
        If eEstado <> TipoEstado.Eliminar Then
            If fgDetalles.Rows.Count > 1 AndAlso (fgDetalles.Rows(fgDetalles.Row).IsNode AndAlso fgDetalles.Rows(fgDetalles.Row).Node.Level <> 1) Then
                MostrarContext()
            End If
        End If
    End Sub


    Private Sub MenuItemBorrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemBorrar.Click
        If fgDetalles.Rows.Count = 1 Then
            Exit Sub
        End If
        If BorrarMovimiento(fgDetalles.GetData(fgDetalles.Row, 6)) Then
            PoblarProductos()
        End If
    End Sub

    Private Sub MenuItemAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemAgregar.Click
        Me.AgregarMovimiento()
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        Dim iValor As Integer = PermiteEliminacion()
        Select Case iValor
            Case 0
                eEstado = TipoEstado.Eliminar
                MostrarDetalle()
            Case 1
                MessageBox.Show(oVista.BuscarMensaje("MsgBox", "E0689").Replace("$0$", oVista.BuscarMensaje("MsgBox", "XEliminar")))
            Case 2
                MessageBox.Show(oVista.BuscarMensaje("MsgBox", "E0688").Replace("$0$", oVista.BuscarMensaje("MsgBox", "XConsignacion")))
            Case 3
                MessageBox.Show(oVista.BuscarMensaje("MsgBox", "E0731").Replace("$0$", oVista.BuscarMensaje("MsgBox", "XConsignacion")))

        End Select
    End Sub

    Private Sub ListViewConsignacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewConsignacion.SelectedIndexChanged
        Dim bHab As Boolean = False
        If ListViewConsignacion.SelectedIndices().Count > 0 Then
            bHab = True
        End If
        ButtonEliminar.Enabled = bHab
        ButtonLiquidar.Enabled = bHab
        If PermiteEliminacion() = 3 Then
            ButtonContinuarLista.Enabled = False
        Else
            ButtonContinuarLista.Enabled = True
        End If
    End Sub

    Private Sub ButtonLiquidar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonLiquidar.Click
        Dim iValor As Integer = PermiteEliminacion()
        If iValor <> 1 Then
            eEstado = TipoEstado.Creando
            MostrarLiquidacion()
        Else
            MessageBox.Show(oVista.BuscarMensaje("MsgBox", "E0689").Replace("$0$", oVista.BuscarMensaje("MsgBox", "XLiquidar")))
        End If

    End Sub

    Private Sub fgLiquida_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fgLiquida.AfterEdit
        Dim fila As C1.Win.C1FlexGrid.Row = fgLiquida.Rows(e.Row)

        If Not fila.IsNode OrElse fila.Node.Level <> 1 Then
            e.Cancel = True
        Else
            Dim bCancelar As Boolean = False
            Dim dCantidad As Double = Convert.ToDouble(fgLiquida.Item(e.Row, 2))
            Dim dDevolucion As Double = Convert.ToDouble(fgLiquida.Item(e.Row, 3))
            Dim dLiquidar As Double = Convert.ToDouble(fgLiquida.Item(e.Row, 4))
            Dim dDiferencia As Double = (dCantidad - dDevolucion)
            If dDiferencia < 0 Then
                MessageBox.Show(oVista.BuscarMensaje("MsgBox", "E0216").Replace("$0$", "0").Replace("$1$", dCantidad.ToString()))
                bCancelar = True
            Else
                If dDevolucion < 0 Then
                    MessageBox.Show(oVista.BuscarMensaje("MsgBox", "E0216").Replace("$0$", "0").Replace("$1$", dCantidad.ToString()))
                    bCancelar = True
                Else
                    fgLiquida.Item(e.Row, 4) = dDiferencia
                End If
            End If
            If bCancelar Then
                fgLiquida.Item(e.Row, 3) = dCantidad - dLiquidar
                e.Cancel = True
            Else
                bHuboCambio = True
            End If
        End If
        CalcularTotalLiquidacion()
    End Sub

    Private Sub fgLiquida_BeforeEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fgLiquida.BeforeEdit
        Dim fila As C1.Win.C1FlexGrid.Row = fgLiquida.Rows(e.Row)
        If Not fila.IsNode OrElse fila.Node.Level <> 1 Then
            e.Cancel = True
        End If
    End Sub

    'Private Sub ButtonLRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLRegresar.Click

    'End Sub

    Private Sub ButtonLTerminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLTerminar.Click
        If Not IsNothing(LabelLSaldoF.Tag) AndAlso LabelLSaldoF.Tag < 0 Then

            MessageBox.Show(oVista.BuscarMensaje("MsgBox", "E0697"))
            Exit Sub
        End If
        ButtonLTerminar.Enabled = False
        ButtonLRegresar.Enabled = False
        Application.DoEvents()

        TerminarLiquidar()
        ButtonLTerminar.Enabled = True
        ButtonLRegresar.Enabled = True
    End Sub
    Private Sub TerminarLiquidar()
        Dim fallo As Boolean = False
        If eEstado = TipoEstado.Liquidar Then
            If oDBVen.oConexion.State = ConnectionState.Closed Then
                oDBVen.oConexion.Open()
            End If
            Me.Transaccion = oDBVen.oConexion.BeginTransaction()
        End If
        Try
            Dim trDevolucion As New TransProd()
            Dim almenosUno As Boolean = False
            If IniciarLiquidar(trDevolucion) Then
                Dim sProducto As String = ""
                Dim iPartida As Integer
                Dim aImpuestos As New ArrayList
                For Each fila As C1.Win.C1FlexGrid.Row In fgLiquida.Rows
                    Dim indice As Integer = fila.Index
                    If indice >= 0 Then

                        If fila.IsNode AndAlso fila.Node.Level = 1 Then
                            If fgLiquida.Item(indice, 3) > 0 Then
                                almenosUno = True
                                iPartida = 0
                                Folio.ObtenerTransProdPartida(trDevolucion.TransProdId, sProducto, iPartida)
                                Dim oTPD As New TransProdDetalle(trDevolucion.TransProdId, sProducto, iPartida)
                                aImpuestos.Clear()
                                oImpuesto.Buscar(sProducto, oTransProd.ClienteActual.TipoImpuesto, aImpuestos)
                                oTPD.TipoUnidad = fgLiquida.Item(indice, 6)
                                oTPD.Cantidad = fgLiquida.Item(indice, 3)
                                oTPD.Precio = fgLiquida.Item(indice, 7)
                                oTPD.SubTotal = oTPD.Cantidad * oTPD.Precio
                                oTPD.Impuesto = oImpuesto.Calcular(aImpuestos, oTPD.SubTotal)
                                oTPD.Total = oTPD.SubTotal + oTPD.Impuesto
                                usoTransProd.Saldo -= oTPD.Total
                                If InsertarDetalle(oTPD) Then
                                    Dim ttTrpTpd As New TrpTpd()
                                    ttTrpTpd.Cantidad = oTPD.Cantidad
                                    ttTrpTpd.Impuesto = oTPD.Impuesto
                                    ttTrpTpd.Precio = oTPD.Precio
                                    ttTrpTpd.SubTotal = oTPD.SubTotal
                                    ttTrpTpd.Total = oTPD.Total
                                    ttTrpTpd.TransProdDetalleID = fgLiquida.Item(indice, 5)
                                    ttTrpTpd.TransProdID = trDevolucion.TransProdId
                                    ttTrpTpd.TransProdID1 = usoTransProd.TransProdId
                                    ttTrpTpd.Crear()
                                    Inventario.ActualizarInventarioDec(oTPD.ProductoClave, oTPD.TipoUnidad, oTPD.Cantidad, ServicesCentral.TiposTransProd.DevolucionesCliente, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId, , "Venta")
                                    ProductoPrestamoCli.ActulizarProductoPrestamoCli(Me.oTransProd.ClienteActual.ClienteClave, oTPD.ProductoClave, oTPD.Cantidad, oTPD.TipoUnidad, 6, ServicesCentral.TiposTransProd.VentaConsignacion, 0) 'ABONO
                                    ProductoPrestamoCli.ActulizarProductoPrestamoCli(Me.oTransProd.ClienteActual.ClienteClave, oTPD.ProductoClave, -1 * oTPD.Cantidad, oTPD.TipoUnidad, 3, ServicesCentral.TiposTransProd.VentaConsignacion, 0) 'SALDO De ABONO
                                    ProductoPrestamoCli.ActulizarProductoPrestamoCli(Me.oTransProd.ClienteActual.ClienteClave, oTPD.ProductoClave, fgLiquida.Item(indice, 4), oTPD.TipoUnidad, 2, ServicesCentral.TiposTransProd.VentaConsignacion, 1) 'VENTA
                                    ProductoPrestamoCli.ActulizarProductoPrestamoCli(Me.oTransProd.ClienteActual.ClienteClave, oTPD.ProductoClave, -1 * fgLiquida.Item(indice, 4), oTPD.TipoUnidad, 3, ServicesCentral.TiposTransProd.VentaConsignacion, 1) 'SALDO De VENTA
                                    oTransProd.ClienteActual.ActualizarSaldo(-oTPD.Total)
                                End If
                            Else
                                ProductoPrestamoCli.ActulizarProductoPrestamoCli(Me.oTransProd.ClienteActual.ClienteClave, sProducto, fgLiquida.Item(indice, 4), fgLiquida.Item(indice, 6), 2, ServicesCentral.TiposTransProd.VentaConsignacion, 1) 'VENTA
                                ProductoPrestamoCli.ActulizarProductoPrestamoCli(Me.oTransProd.ClienteActual.ClienteClave, sProducto, -1 * fgLiquida.Item(indice, 4), fgLiquida.Item(indice, 6), 3, ServicesCentral.TiposTransProd.VentaConsignacion, 1) 'SALDO
                            End If
                            
                        Else
                            sProducto = fgLiquida.Item(indice, 0)
                        End If
                    End If
                Next
                If almenosUno Then
                    trDevolucion.Actualizar()
                    If bCrear Then
                        Folio.Confirmar(, ServicesCentral.TiposModulosMovDet.DevolucionClientes)
                    End If
                Else
                    trDevolucion.Eliminar()
                End If

                usoTransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Liquidado
                usoTransProd.FechaFacturacion = DateTime.Now
                usoTransProd.VisitaClave1 = oTransProd.VisitaActual
                usoTransProd.DiaClave1 = oDia.DiaActual
                usoTransProd.Actualizar()
                If oVendedor.motconfiguracion.MensajeImpresion Then
                    If MsgBox(oVista.BuscarMensaje("MsgBox", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                        ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, usoTransProd.TransProdId, usoTransProd.Tipo, 26, oTransProd.ClienteActual, usoTransProd.VisitaActual)
                    End If
                End If
            End If
        Catch ex As Exception
            Transaccion.Rollback()
            MessageBox.Show(ex.Message)
            fallo = True
        End Try
        If Not fallo Then
            Transaccion.Commit()
        End If
        Transaccion.Dispose()
        Transaccion = Nothing
        MostrarNavegacion()
    End Sub
    Private Function InsertarDetalle(ByVal oTPD As TransProdDetalle) As Boolean
        If Not Folio.ObtenerTransProdDetalleId(oTPD.TransProdID, oTPD.TransProdDetalleID) Then
            Return False
        End If
        ' Crear la cadena para insertar el valor
        Dim sComandoSQL As New System.Text.StringBuilder()
        sComandoSQL.Append("INSERT INTO TransProdDetalle (TransProdID, TransProdDetalleID, ProductoClave, TipoUnidad, Partida, Cantidad, Precio, Subtotal, Impuesto, Total, MFechaHora, MUsuarioID) VALUES (")
        sComandoSQL.Append("'" & oTPD.TransProdID & "',")
        sComandoSQL.Append("'" & oTPD.TransProdDetalleID & "',")
        sComandoSQL.Append("'" & oTPD.ProductoClave & "',")
        sComandoSQL.Append(oTPD.TipoUnidad & ",") ' TipoUnidad
        sComandoSQL.Append(oTPD.Partida & ",") ' Partida
        sComandoSQL.Append(oTPD.Cantidad & ",") ' Cantidad
        sComandoSQL.Append(oTPD.Precio & ",") ' Precio
        sComandoSQL.Append(oTPD.SubTotal & ",") ' Subtotal
        sComandoSQL.Append(oTPD.Impuesto & ",") ' Impuesto
        sComandoSQL.Append(oTPD.Total & ",")  ' Total
        sComandoSQL.Append(UniFechaSQL(Now) & ",")
        sComandoSQL.Append("'" & oVendedor.UsuarioId & "')")
        Try
            If sComandoSQL.ToString <> "" Then
                oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "InsertarDetalle")
            Return False
        End Try
        Return True
    End Function
    Private Function IniciarLiquidar(ByVal trDevolucion As TransProd) As Boolean
        bCrear = True
        Dim oTransProdId As Object = oDBVen.RealizarScalarSQL("SELECT TransProdId FROM TrpTpd WHERE TransProdID1 = '" + usoTransProd.TransProdId + "'")
        If (Not IsNothing(oTransProdId) AndAlso Not IsDBNull(oTransProdId)) Then
            trDevolucion.TransProdId = oTransProdId
            oDBVen.RealizarScalarSQL("DELETE FROM TrpTpd WHERE TransProdID1 = '" + usoTransProd.TransProdId + "'")
            If (trDevolucion.Recuperar()) Then
                Dim oDt As DataTable = oDBVen.RealizarConsultaSQL("Select TransProdDetalleId, ProductoClave, TipoUnidad, Cantidad, Precio,Total From TransProdDetalle where TransProdId='" & trDevolucion.TransProdId & "'", "Detalle")
                For Each oDr As DataRow In oDt.Rows
                    Inventario.ActualizarInventarioDec(oDr("ProductoClave"), oDr("TipoUnidad"), oDr("Cantidad"), ServicesCentral.TiposTransProd.DevolucionesCliente, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, , "Venta")
                    oTransProd.ClienteActual.ActualizarSaldo(oDr("Total"))
                    usoTransProd.Saldo += oDr("Total")
                Next
                oDBVen.EjecutarComandoSQL("DELETE FROM TPDImpuesto WHERE TransProdId='" & trDevolucion.TransProdId & "'")
                oDBVen.EjecutarComandoSQL("DELETE FROM TRPPRP WHERE TransProdId='" & trDevolucion.TransProdId & "'")
                oDBVen.EjecutarComandoSQL("DELETE FROM TPDDes WHERE TransProdId='" & trDevolucion.TransProdId & "'")
                trDevolucion.EliminarDescuentosVendedor()
                oDBVen.EjecutarComandoSQL("DELETE TransProdDetalle where TransProdId = '" & trDevolucion.TransProdId & "'")
                With trDevolucion
                    .FechaCaptura = oDia.FechaCaptura
                    .FechaSurtido = Now
                    .FechaHoraAlta = Now
                End With
                bCrear = False
            End If
        End If
        If bCrear Then
            trDevolucion.FolioActual = Folio.Obtener(, ServicesCentral.TiposModulosMovDet.DevolucionClientes)
            If trDevolucion.FolioActual = "" Then
                Return False
            Else
                Folio.ObtenerTransProdId(trDevolucion.TransProdId)
                With trDevolucion
                    .VisitaActual = oTransProd.VisitaActual
                    .ClienteActual = oTransProd.ClienteActual
                    .ClienteClave = oTransProd.ClienteClave
                    .Tipo = ServicesCentral.TiposTransProd.DevolucionesCliente
                    .TipoMovimiento = ServicesCentral.TiposMovimientos.Entrada
                    .TipoPedido = ServicesCentral.TiposPedidos.NoDefinido
                    .TipoFase = ServicesCentral.TiposFasesPedidos.Captura
                    .TipoMotivo = 12
                    .ModuloMovDetalle = oTransProd.ModuloMovDetalle
                    .FechaCaptura = oDia.FechaCaptura
                    .FechaSurtido = Now
                    .FechaHoraAlta = Now
                End With
            End If
        End If
        Return trDevolucion.Actualizar()
    End Function

    Private Sub MenuItemEliminarN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemEliminarN.Click

    End Sub
End Class