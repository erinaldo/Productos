Public Class FormCobranzaBackus
    Inherits System.Windows.Forms.Form
    'se agregaron los paramentros al new.
    Public Sub New(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String)
        Dim cnhist As CONHist = New CONHist()
        _Moneda = cnhist.Campos("MonedaID").ToString()
        cnhist.Campos.Clear()
        cnhist.Dispose()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        If g_SO = SO.WindowsCE Then
            Call InTheHand.Windows.Forms.ContextMenuHelper.HookAllControls(Me.Controls)
        End If
        ' Add any initialization after the InitializeComponent() call.
        oCliente = paroCliente
        sVisitaClave = parsVisitaClave


    End Sub

#Region "VARIABLES"
    Private oVista As Vista
    Private eEstado As Estado
    Private bFin As Boolean = False
    Private sVisitaClave As String = String.Empty
    Private sVisitaClaveDeAbono As String = String.Empty
    Private oCliente As Cliente
    Private sABPId As String = String.Empty
    Private bIniciando As Boolean = False
    Private bMarcando As Boolean = False
    Dim sTransprodid As String
    Dim SaldoFactura As String
    Dim FechaFactura As String
    Dim Folios As String
    Private dtClientePagos As DataTable
    Private blnClientePagos As Boolean
    Private blnSeleccionManual As Boolean = False
    Private bAceptarSugerencia As Boolean
    Private aEliminados As New ArrayList
    Private sFolio As String = String.Empty
    Dim dSaldoActualMonedaVenta As Decimal
    Dim dSaldoClienteActualMonedaVenta As Decimal
    Dim dPagosEfectivoOriginalMonedaVenta As Decimal
    Dim DicMonedaPagoEfectivoOriginal As New System.Collections.Generic.Dictionary(Of String, Decimal)
    Dim sABNIdActual As String
    Dim EliminarCargo As Boolean = False
    Dim MonedaIdVenta As String
    Dim TipoCambioVenta As Decimal
    Dim sTipoCodigoVenta As String

    'Variables de configuracion
    Dim blnCobrarVentas As Boolean = False
    'Dim blnLimiteCreditoCheque As Boolean = True
    Dim bHuboCambios As Boolean = False
    Dim blnAbonosProgramados As Boolean
    Private _Moneda As String
#End Region

#Region "Propiedades"
    Public Property Transaccion() As SqlServerCe.SqlCeTransaction
        Get
            Return oDBVen.Transaccion
        End Get
        Set(ByVal Value As SqlServerCe.SqlCeTransaction)
            oDBVen.Transaccion = Value
        End Set
    End Property
#End Region

#Region "Enum"
    Private Enum Estado
        Crear
        Eliminar
        Modificar
        Navegar
    End Enum
#End Region

#Region "FUNCIONES"
    Private Function HaySeleccion(ByVal LV As ListView) As Boolean
        If LV.Items.Count > 0 Then
            Dim i As Integer
            For i = 0 To LV.Items.Count - 1
                If LV.Items(i).Checked Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function
#End Region

#Region "METODOS"
    Private Sub LlenarLV()
        Me.PanelCobranza.Visible = True
        Me.PanelCobranzaDetalles.Visible = False
        If blnCobrarVentas Then
            oVista.PoblarListView(Me.ListViewCobranza, oDBVen, "ListViewCobranzaPedidos", " AND v.ClienteClave='" & oCliente.ClienteClave & "' ")
        Else
            oVista.PoblarListView(Me.ListViewCobranza, oDBVen, "ListViewCobranza", " AND Visita.ClienteClave='" & oCliente.ClienteClave & "' ")
        End If

        sABPId = String.Empty
    End Sub
    Private Sub ConfigurarGrid()

        With C1FlexGridCobranzaPagos
            .Cols.Count = 8
            .Cols.Fixed = 0
            .Rows.Count = 1

            .Cols(0).Name = "TipoPago"
            .Cols("TipoPago").Width = 90
            .Cols("TipoPago").Caption = oVista.BuscarMensaje("GridCobranzaPagos", "Forma de Pago")

            'Tipos de Pago
            'Dim sTiposPago As String = ""
            Dim aTiposPago As ArrayList
            'Dim sBancos As String = ""
            Dim aBancos As ArrayList

            dtClientePagos = oCliente.RecuperarTipoPago
            If dtClientePagos.Rows.Count > 0 Then

                For Each dr As DataRow In dtClientePagos.Rows
                    If aTiposPago Is Nothing Then
                        aTiposPago = New ArrayList
                    End If
                    aTiposPago.Add(dr("Tipo").ToString)
                    'sTiposPago &= dr("Tipo") & ","
                Next
                'If sTiposPago <> "" Then
                '    sTiposPago = sTiposPago.Substring(0, sTiposPago.Length - 1)
                'End If

                'For Each dr As DataRow In dtClientePagos.Rows
                '    If Not IsDBNull(dr("TipoBanco")) Then
                '        If aBancos Is Nothing Then
                '            aBancos = New ArrayList
                '        End If
                '        aBancos.Add(dr("TipoBanco").ToString)
                '        'sBancos &= dr("TipoBanco") & ","
                '    End If
                'Next
                'If aBancos Is Nothing Then
                '    aBancos = New ArrayList
                '    aBancos.Add("'*'")
                'End If
                'If sBancos <> "" Then
                '    sBancos = sBancos.Substring(0, sBancos.Length - 1)
                'Else
                '    sBancos = "'*'"
                'End If

                blnClientePagos = True
            Else
                blnClientePagos = False
            End If
            Dim ValoresTipoPago As New Hashtable
            Dim aValores As ArrayList = ValorReferencia.RecuperarLista("PAGO", aTiposPago)
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    If refDesc.Grupo <> "" Then
                        ValoresTipoPago.Add(refDesc.Id, refDesc.Cadena)
                    End If
                Next
                .Cols("TipoPago").DataMap = ValoresTipoPago
            End If
            .Cols(1).Name = "Moneda"
            .Cols("Moneda").Width = 65
            .Cols("Moneda").AllowEditing = False
            .Cols("Moneda").Caption = oVista.BuscarMensaje("GridCobranzaPagos", "Moneda")
            Dim ValoresMoneda As New Hashtable
            Dim dt As DataTable = oDBVen.RealizarConsultaSQL("select MonedaId, substring(Nombre,1,8) as Nombre, TipoCodigo from Moneda", "Moneda")
            Dim sTipoCodigo As String = ""
            For Each fila As DataRow In dt.Rows
                sTipoCodigo = ValorReferencia.BuscarEquivalente("CDGOMON", fila("TipoCodigo").ToString)
                ValoresMoneda.Add(fila("MonedaId"), fila("Nombre").ToString() & " " & sTipoCodigo)
            Next
            .Cols("Moneda").DataMap = ValoresMoneda

            .Cols(2).Name = "Importe"
            .Cols("Importe").Width = 80
            .Cols("Importe").Caption = oVista.BuscarMensaje("GridCobranzaPagos", "Importe")
            .Cols("Importe").AllowEditing = False
            .Cols("Importe").DataType = GetType(Decimal)
            .Cols("Importe").Format = "c"

            .Cols(3).Name = "TipoBanco"
            .Cols("TipoBanco").Width = 60
            Dim ValoresTipoBanco As New Hashtable
            aValores = ValorReferencia.RecuperarLista("TBANCO", aBancos)
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    ValoresTipoBanco.Add(refDesc.Id, refDesc.Cadena)
                Next
                .Cols("TipoBanco").DataMap = ValoresTipoBanco
            End If
            .Cols("TipoBanco").Caption = oVista.BuscarMensaje("GridCobranzaPagos", "Banco")

            .Cols(4).Name = "Referencia"
            .Cols("Referencia").Width = 80
            .Cols("Referencia").Caption = oVista.BuscarMensaje("GridCobranzaPagos", "Referencia")


            .Cols(5).Visible = False
            .Cols(5).Name = "ABNId"

            .Cols(6).Visible = False
            .Cols(6).Name = "ABDId"
            aValores = Nothing

            .Cols(7).Visible = False
            .Cols(7).Name = "TipoCambio"

#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            For Each col As C1.Win.C1FlexGrid.Column In .Cols
                col.Width = col.Width * 2
            Next
#End If

        End With


    End Sub
    Private Sub ConfigurarGridSaldos()

        With C1FlexGridMonedaSaldo
            .Cols.Count = 3
            .Cols.Fixed = 1
            .Rows.Count = 1

            .Cols(0).Name = "Moneda"
            .Cols("Moneda").Width = 83
            .Cols("Moneda").AllowEditing = False
            .Cols("Moneda").Caption = oVista.BuscarMensaje("GridCobranzaPagos", "Moneda")
            Dim ValoresMoneda As New Hashtable
            Dim dt As DataTable = oDBVen.RealizarConsultaSQL("Select MonedaId,Nombre+'(' + LTRIM(TipoCambio) + ')' as Nombre From MOneda M inner join TCMoneda T on T.Monini='" & MonedaIdVenta & "' and T.MonFin=M.MonedaID where monedaID<>'" & MonedaIdVenta & "' union Select MonedaId,Nombre From Moneda where MonedaID='" & MonedaIdVenta & "'", "Moneda")
            Dim sTipoCodigo As String = ""
            For Each fila As DataRow In dt.Rows

                ValoresMoneda.Add(fila("MonedaId"), fila("Nombre").ToString())
            Next
            .Cols("Moneda").DataMap = ValoresMoneda


            .Cols(1).Name = "Cargo"
            .Cols("Cargo").Width = 71
            .Cols("Cargo").Caption = oVista.BuscarMensaje("C1FlexGridMonedaSaldo", "XSaldoTotal")
            .Cols("Cargo").AllowEditing = False
            .Cols("Cargo").DataType = GetType(Decimal)
            .Cols("Cargo").Format = "c"

            .Cols(2).Name = "Abono"
            .Cols("Abono").Width = 71
            .Cols("Abono").Caption = oVista.BuscarMensaje("C1FlexGridMonedaSaldo", "XTotalAbonos")
            .Cols("Abono").AllowEditing = False
            .Cols("Abono").DataType = GetType(Decimal)
            .Cols("Abono").Format = "c"


#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            For Each col As C1.Win.C1FlexGrid.Column In .Cols
                col.Width = col.Width * 2
            Next
#End If

        End With


    End Sub

    Private Sub LlenarGrid()

        Dim PromesaPago As DataTable = oDBVen.RealizarConsultaSQL("SELECT abonoprogramado.abpid,abonoprogramado.fechapromesa from abonoprogramado inner join transprod on Transprod.Transprodid=AbonoProgramado.TransprodId where(abonoprogramado.fechapromesa = " & UniFechaSQL(PrimeraHora(Now)) & ") and transprod.transprodid='" & sTransprodid & "'", "LlenarGrid")

        If PromesaPago.Rows.Count > 0 Then

            Dim SumaImporte As DataTable = oDBVen.RealizarConsultaSQL("select sum(abonoprogramado.importe)from abonoprogramado inner join transprod on Transprod.Transprodid=AbonoProgramado.TransprodId where abonoprogramado.fechapromesa =" & UniFechaSQL(PrimeraHora(Now)) & " and transprod.transprodid='" & sTransprodid & "'", "LlenarGrid")
            Dim GRIDIMPORTE As DataTable = oDBVen.RealizarConsultaSQL("select TipoPago,Importe,TipoBanco,Referencia from abndetalle", "LlenarGrid")

            Me.C1FlexGridCobranzaPagos.Redraw = False
            Dim Importe As String = SumaImporte.Rows(0)(0).ToString()

            Dim pariTipoPago As Integer = 0
            For Each oDesc As ValorReferencia.Descripcion In ValorReferencia.RecuperarListaArraySoloConGrupo("Pago")
                If oDesc.Grupo.ToUpper = "E" Then
                    pariTipoPago = oDesc.Id
                    Exit For
                End If
            Next
            'TODO: Probar Cambio TipoPago
            For Each oDr As DataRow In GRIDIMPORTE.Rows
                Me.C1FlexGridCobranzaPagos.AddItem((pariTipoPago).ToString + vbTab + Importe + vbTab + oDr("TipoBanco").ToString + vbTab + oDr("Referencia").ToString)
            Next

            If GRIDIMPORTE.Rows.Count > 0 Then
                If ValorReferencia.RecuperaGrupo("PAGO", GRIDIMPORTE.Rows(0)(0)).ToUpper = "E" Then
                    C1FlexGridCobranzaPagos.Cols("TipoBanco").AllowEditing = False
                    C1FlexGridCobranzaPagos.Cols("Referencia").AllowEditing = False
                Else
                    C1FlexGridCobranzaPagos.Cols("TipoBanco").AllowEditing = True
                    C1FlexGridCobranzaPagos.Cols("Referencia").AllowEditing = True
                End If
            End If

            Me.C1FlexGridCobranzaPagos.Redraw = True

            '*********************************************************************************************************************************
            SumaImporte.Dispose()
            GRIDIMPORTE.Dispose()

        Else
            ActualizarTotal()
            C1FlexGridCobranzaPagos.Cols("TipoBanco").AllowEditing = True
            C1FlexGridCobranzaPagos.Cols("Referencia").AllowEditing = True
            C1FlexGridCobranzaPagos.Rows.Add()

        End If

        PromesaPago.Dispose()

    End Sub


    Private Sub LlenarGridSaldos()


        Dim dtMoneda As DataTable = oDBVen.RealizarConsultaSQL(" Select MonedaId From Moneda where monedaid<>'" & MonedaIdVenta & "' ", "LlenarGrid")

        Me.C1FlexGridMonedaSaldo.AddItem(MonedaIdVenta + vbTab + "0" + vbTab + "0")
        For Each oDr As DataRow In dtMoneda.Rows
            Me.C1FlexGridMonedaSaldo.AddItem(oDr("MonedaId").ToString() + vbTab + "0" + vbTab + "0")
        Next

        dtMoneda.Dispose()

    End Sub


#End Region

#Region "LOAD"

    Private Sub FormCobranzaBackus_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Not IsNothing(Me.mainMenu1) Then
            If oVendedor.motconfiguracion.Secuencia Then
                If Not ctrlSeguimiento.Parent Is Nothing Then
                    RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                    RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                    ctrlSeguimiento.QuitarMenuItem(Me.mainMenu1)
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

        Me.Transaccion = Nothing
        If oDBVen.oConexion.State = ConnectionState.Open Then
            oDBVen.oConexion.Close()
        End If
    End Sub
    Private Sub FormCobranzaBackus_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ListViewCobranza.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ListViewCobranza.Activation = oApp.TipoSeleccion
        'Me.DateTimePickerFechaPromesa.Format = DateTimePickerFormat.Custom
        'Me.DateTimePickerFechaPromesa.CustomFormat = oApp.FormatoFecha

        [Global].ObtenerFactores(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.AgregarControl(Me)
            Me.PanelCobranza.SendToBack()
            Me.PanelCobranzaDetalles.SendToBack()
            ctrlSeguimiento.CrearMenuItem(Me.mainMenu1)
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

        If Not Vista.Buscar("FormCobranza", oVista) Then
            Exit Sub
        End If
        oVista.ColocarEtiquetasForma(Me)

        blnCobrarVentas = oConHist.Campos("CobrarVentas")
        'blnLimiteCreditoCheque = oCONHist.Campos("LimiteCreditoCheque")
        blnAbonosProgramados = oConHist.Campos("AbonoProgramado")

        If blnCobrarVentas Then
            oVista.CrearListView(Me.ListViewCobranza, "ListViewCobranzaPedidos")
        Else
            oVista.CrearListView(Me.ListViewCobranza, "ListViewCobranza")
        End If

        LlenarLV()

        If ListViewCobranza.Items.Count > 0 Then
            ListViewCobranza.Items(0).Selected = True
            ListViewCobranza.Focus()
        Else
            If blnCobrarVentas Then
                MsgBox(Replace(oVista.BuscarMensaje("MsgBox", "E0558"), "$0$", oVista.BuscarMensaje("MsgBox", "XVenta")), MsgBoxStyle.Information)
            Else
                MsgBox(Replace(oVista.BuscarMensaje("MsgBox", "E0558"), "$0$", oVista.BuscarMensaje("MsgBox", "XFactura")), MsgBoxStyle.Information)
            End If
            'Me.ButtonContinuar.Focus()
            Me.Close()
        End If
        [Global].HabilitarMenuItem(mainMenu1, True)
        bFin = True
        Me.bHuboCambios = False
    End Sub

    Private Sub TerminarVisita()
        If Me.RegresarDetalle() Then
            ButtonRegresar_Click(Nothing, Nothing)
        End If
    End Sub

#End Region

#Region "FORM COBRANZA"

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        If Me.PanelCobranza.Visible Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            If Me.RegresarDetalle() Then
                Me.DialogResult = Windows.Forms.DialogResult.Retry
                Me.Close()
                'Me.PanelCobranza.Visible = True
                'Me.PanelCobranzaDetalles.Visible = False
            End If
        End If
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        bIniciando = True
        If Not Me.HaySeleccion(Me.ListViewCobranza) Then 'RevisarElementoMarcado(ListViewCobranza) Then
            MsgBox(oVista.BuscarMensaje("MsgBox", "E0039"), MsgBoxStyle.Information)
            'Exit Sub
        Else
            LabelCargo.Text += "  " + ValorReferencia.BuscarEquivalente("CDGOMON", sTipoCodigoVenta)
            dSaldoActualMonedaVenta = 0
            EliminarCargo = False
            Me.ConfigurarGrid()
            Me.ConfigurarGridSaldos()
            Me.CargosAplicados()
            Me.LlenarGrid()
            Me.LlenarGridSaldos()
            ActualizarTotal()
        End If

        bIniciando = False
        bHuboCambios = False
    End Sub


#End Region

#Region "VALIDAR SELECCION"

    Private Sub ListViewDias_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewCobranza.ItemCheck
        If bMarcando = True Then
            Exit Sub
        End If
        bMarcando = True
        MarcarElemento(ListViewCobranza, e.NewValue, e.Index)
        bMarcando = False
        'dame valor del transprodid seleccionado
        Folios = ListViewCobranza.Items(e.Index.ToString).SubItems(0).Text
        sTransprodid = ListViewCobranza.Items(e.Index.ToString).SubItems(5).Text


        Dim rowTemp As DataRow = oDBVen.RealizarConsultaSQL("select T.monedaid,TipoCambio,TipoCodigo from transprod t inner join Moneda M on M.monedaId=T.monedaid where transprodid='" + sTransprodid + "'", "var").Rows(0)

        MonedaIdVenta = rowTemp("monedaid")
        TipoCambioVenta = rowTemp("TipoCambio")
        sTipoCodigoVenta = rowTemp("TipoCodigo")

        'TextBoxMoneda.Text = ValorReferencia.BuscarEquivalente("CDGOMON", sTipoCodigo)

        TextBoxSaldoFactura.TextAlign = HorizontalAlignment.Right
        If oDBVen.EjecutarCmdScalarIntSQL("select count(*) from abntrp abn where  abn.enviado=1 and ABN.transprodid = '" + sTransprodid + "'") > 0 Then
            ButtonEliminar.Enabled = False
        Else
            ButtonEliminar.Enabled = True
        End If

        'dame valor del saldo seleccionado
        SaldoFactura = ListViewCobranza.Items(e.Index.ToString).SubItems(4).Text
        FechaFactura = ListViewCobranza.Items(e.Index.ToString).SubItems(2).Text

    End Sub

    Private Sub ListViewCobranza_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewCobranza.ItemActivate
        'Elegir()
        DesmarcarItems()
        If Me.ListViewCobranza.SelectedIndices.Count <= 0 Then Exit Sub

        Me.ListViewCobranza.Items(Me.ListViewCobranza.SelectedIndices.Item(0)).Checked = True
    End Sub

    Private Sub DesmarcarItems()
        For Each refListViewItem As ListViewItem In Me.ListViewCobranza.Items
            refListViewItem.Checked = False
        Next
    End Sub

    Private Sub Elegir()
        If Not RevisarElementoMarcado(ListViewCobranza) Then
            MsgBox(oVista.BuscarMensaje("MsgBox", "Elegir"), MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim refListViewItemSel As ListViewItem = ListViewCobranza.Items(ListViewCobranza.SelectedIndices(0))
        refListViewItemSel.Checked = True

        'oDia.Nombre = refListViewItemSel.Text
        'If Not oDia.Recuperar() Then
        '    MsgBox(oVista.BuscarMensaje("MsgBox", "ErrorAbrir"), MsgBoxStyle.Exclamation)
        '    Exit Sub
        'End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

#End Region

#Region "VALIDACION DE NUMEROS"
    Private Sub TextBoxMontoProgramado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
            Exit Sub
        End If
        Me.bHuboCambios = True
    End Sub

    Function SoloNumeros(ByVal KeyAscii As Integer) As Integer

        If InStr("0123456789.", Chr(KeyAscii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = KeyAscii
        End If

        If KeyAscii = 8 Then SoloNumeros = KeyAscii ' Backspace

        If KeyAscii = 13 Then SoloNumeros = KeyAscii ' Enter

        If InStr("abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZº·<>$%&/()=?¿Ç\|@#}-_:,;*+ ", Chr(KeyAscii)) = 0 Then
            SoloNumeros = KeyAscii
        Else
            SoloNumeros = 0
            MsgBox(oVista.BuscarMensaje("MsgBox", "E0464"), MsgBoxStyle.Information)
            'Me.TextBoxMontoProgramado.Focus()
        End If

    End Function
#End Region

#Region "FELXGRID"

    Private Sub C1FlexGridCobranzaPagos_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1FlexGridCobranzaPagos.EnterCell

        If blnSeleccionManual Then Exit Sub
        Dim iCol As Integer = C1FlexGridCobranzaPagos.Col
        Dim iRow As Integer = C1FlexGridCobranzaPagos.Row

        If iRow <= 0 Or iCol <= 0 Then Exit Sub

        'If IsDBNull(C1FlexGridCobranzaPagos.Item(iRow, "TipoPago")) Then Exit Sub
        If iRow > 1 Or iCol > 1 Then

            With C1FlexGridCobranzaPagos

                .Rows(iRow).AllowEditing = True
                If IsNumeric(.Item(iRow, "TipoPago")) AndAlso ValorReferencia.RecuperaGrupo("PAGO", .Item(iRow, "TipoPago")).ToUpper = "E" Then
                    .Item(iRow, "TipoBanco") = Nothing
                    .Item(iRow, "Referencia") = Nothing
                    .Cols("TipoBanco").AllowEditing = False
                    .Cols("Referencia").AllowEditing = False
                Else
                    If .Item(iRow, "TipoPago") = Nothing Then
                        .Item(iRow, "TipoBanco") = Nothing
                        .Item(iRow, "Referencia") = Nothing
                        .Cols("TipoBanco").AllowEditing = False
                        .Cols("Referencia").AllowEditing = False
                    ElseIf .Rows(iRow).AllowEditing Then
                        .Cols("TipoBanco").AllowEditing = True
                        .Cols("Referencia").AllowEditing = True
                    End If
                End If


                If IsNumeric(C1FlexGridCobranzaPagos.Item(iRow, "TipoPago")) = Nothing Then
                    C1FlexGridCobranzaPagos.Cols("Importe").AllowEditing = False
                Else
                    If C1FlexGridCobranzaPagos.Rows(iRow).AllowEditing Then
                        C1FlexGridCobranzaPagos.Cols("Importe").AllowEditing = True
                        C1FlexGridCobranzaPagos.Item(iRow, "Moneda") = oDBVen.EjecutarCmdScalarStrSQL("select MonedaId from formapagomoneda where tipopago='" & C1FlexGridCobranzaPagos.Item(iRow, "TipoPago") & "'")
                    End If
                End If






                'ActualizarTotal()

            End With
        Else
            If iRow <= 0 Or iCol <= 0 Then Exit Sub
        End If

    End Sub

    Private Sub C1FlexGridCobranzaPagos_ValidateEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.ValidateEditEventArgs) Handles C1FlexGridCobranzaPagos.ValidateEdit

        If e.Col = 0 Or e.Col = 1 Or e.Col = 3 Then Exit Sub

        If C1FlexGridCobranzaPagos.Item(e.Row, 0) <> "" AndAlso ValorReferencia.RecuperaGrupo("PAGO", C1FlexGridCobranzaPagos.Item(e.Row, 0)).ToUpper = "E" Then
            If C1FlexGridCobranzaPagos.Cols(e.Col).Name = "Importe" Then
                If e.Row = C1FlexGridCobranzaPagos.Rows.Count - 1 Then
                    C1FlexGridCobranzaPagos.Rows.Add()

                End If
            End If
        Else
            If C1FlexGridCobranzaPagos.Cols(e.Col).Name = "Referencia" Then
                If e.Row = C1FlexGridCobranzaPagos.Rows.Count - 1 And Not Me.RenglonVacio(e.Row) Then
                    C1FlexGridCobranzaPagos.Rows.Add()

                End If
            End If
        End If

        ActualizarTotal()

    End Sub

    Private Sub ActualizarTotal()
        Dim i As Integer
        Dim iTotal As Decimal = 0
        Dim tipoCambio As Decimal = 0
        For i = 1 To C1FlexGridCobranzaPagos.Rows.Count - 1
            Dim iImp As Decimal = 0
            If Not C1FlexGridCobranzaPagos.Item(i, "Importe") Is Nothing Then
                If IsNumeric(C1FlexGridCobranzaPagos.Item(i, "Importe")) Then
                    If C1FlexGridCobranzaPagos.Item(i, "Moneda") = MonedaIdVenta Then
                        iImp = C1FlexGridCobranzaPagos.Item(i, "Importe")

                        C1FlexGridCobranzaPagos.Item(i, 7) = 1


                    ElseIf oConHist.Campos("MonedaID") = MonedaIdVenta Then

                        tipoCambio = oDBVen.EjecutarCmdScalardblSQL("select tipoCambio from tcmoneda where monini='" + MonedaIdVenta + "' and monfin ='" + C1FlexGridCobranzaPagos.Item(i, "Moneda") + "'")
                        iImp = C1FlexGridCobranzaPagos.Item(i, "Importe") * tipoCambio
                        C1FlexGridCobranzaPagos.Item(i, 7) = tipoCambio

                    ElseIf oConHist.Campos("MonedaID") <> MonedaIdVenta Then


                        'Validar la 3ra moneda pq solo esta hecho para dos monedas
                        tipoCambio = oDBVen.EjecutarCmdScalardblSQL("select tipoCambio from tcmoneda where monini='" + MonedaIdVenta + "' and monfin ='" + C1FlexGridCobranzaPagos.Item(i, "Moneda") + "'")
                        iImp = C1FlexGridCobranzaPagos.Item(i, "Importe") / IIf(tipoCambio = 0, 1, tipoCambio)
                        C1FlexGridCobranzaPagos.Item(i, 7) = tipoCambio




                    End If


                End If
            End If
            iTotal = iTotal + iImp
        Next
        Me.TextBoxTotal.Text = Decimal.Round(iTotal, 2).ToString("#,##0.00")
        If C1FlexGridMonedaSaldo.Rows.Count > 1 Then
            C1FlexGridMonedaSaldo.Item(1, 2) = Decimal.Round(iTotal, 2)
            C1FlexGridMonedaSaldo.Item(1, 1) = Decimal.Round(((SaldoFactura + dSaldoActualMonedaVenta) - iTotal), 2)
            For i = 2 To C1FlexGridMonedaSaldo.Rows.Count - 1

                tipoCambio = oDBVen.EjecutarCmdScalardblSQL("select tipoCambio from tcmoneda where monini='" + MonedaIdVenta + "' and monfin ='" + C1FlexGridMonedaSaldo.Item(i, "Moneda") + "'")
                If oConHist.Campos("MonedaID") = MonedaIdVenta Then
                    C1FlexGridMonedaSaldo.Item(i, 2) = Decimal.Round(iTotal / tipoCambio, 2)
                    C1FlexGridMonedaSaldo.Item(i, 1) = Decimal.Round(((SaldoFactura + dSaldoActualMonedaVenta) - iTotal) / tipoCambio, 2)
                Else
                    C1FlexGridMonedaSaldo.Item(i, 2) = Decimal.Round(iTotal * tipoCambio, 2)
                    C1FlexGridMonedaSaldo.Item(i, 1) = Decimal.Round(((SaldoFactura + dSaldoActualMonedaVenta) - iTotal) * tipoCambio, 2)
                End If

            Next
        End If
    End Sub



    Private Sub C1FlexGridCobranzaPagos_CellChanged(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGridCobranzaPagos.CellChanged
        If e.Row <= 0 Then Exit Sub
        If blnSeleccionManual Then Exit Sub
        Try

            Select Case C1FlexGridCobranzaPagos.Cols(e.Col).Name
                Case "TipoPago"
                    If C1FlexGridCobranzaPagos.Item(e.Row, "TipoPago") = "" Then Exit Sub
                    If IsNumeric(C1FlexGridCobranzaPagos.Item(e.Row, "TipoPago")) AndAlso ValorReferencia.RecuperaGrupo("PAGO", C1FlexGridCobranzaPagos.Item(e.Row, "TipoPago")) = "E" Then
                        blnSeleccionManual = True
                        C1FlexGridCobranzaPagos.Item(e.Row, "TipoBanco") = Nothing
                        C1FlexGridCobranzaPagos.Item(e.Row, "Referencia") = Nothing

                        blnSeleccionManual = False
                        C1FlexGridCobranzaPagos.Cols("TipoBanco").AllowEditing = False
                        C1FlexGridCobranzaPagos.Cols("Referencia").AllowEditing = False

                    Else
                        C1FlexGridCobranzaPagos.Cols("TipoBanco").AllowEditing = True
                        C1FlexGridCobranzaPagos.Cols("Referencia").AllowEditing = True


                    End If

                    If IsNumeric(C1FlexGridCobranzaPagos.Item(e.Row, "TipoPago")) = Nothing Then
                        C1FlexGridCobranzaPagos.Cols("Importe").AllowEditing = False
                    Else
                        If C1FlexGridCobranzaPagos.Rows(e.Row).AllowEditing Then
                            C1FlexGridCobranzaPagos.Cols("Importe").AllowEditing = True
                            C1FlexGridCobranzaPagos.Item(e.Row, "Moneda") = oDBVen.EjecutarCmdScalarStrSQL("select MonedaId from formapagomoneda where tipopago='" & C1FlexGridCobranzaPagos.Item(e.Row, "TipoPago") & "'")
                        End If
                    End If

                    ActualizarTotal()
                    bHuboCambios = True
                Case "Importe"

                    ActualizarTotal()
                    If C1FlexGridCobranzaPagos.Item(e.Row, "Importe") <> "" Then
                        bHuboCambios = True
                    End If
                Case "TipoBanco"
                    If C1FlexGridCobranzaPagos.Item(e.Row, "TipoBanco") <> "" Then
                        bHuboCambios = True
                    End If
                Case "Referencia"
                    If C1FlexGridCobranzaPagos.Item(e.Row, "Referencia") <> "" Then
                        bHuboCambios = True
                    End If
         
            End Select
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "MENUITEM"
    Private Sub MenuItemCrear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCrear.Click
        If C1FlexGridCobranzaPagos.Rows.Count < 1 Then
            C1FlexGridCobranzaPagos.Rows.Add()
            ActualizarTotal()
            Exit Sub
        End If

        If Not RenglonVacio(C1FlexGridCobranzaPagos.Rows.Count - 1) Then
            C1FlexGridCobranzaPagos.Cols("TipoBanco").AllowEditing = True
            C1FlexGridCobranzaPagos.Cols("Referencia").AllowEditing = True
            C1FlexGridCobranzaPagos.Rows.Add()
            ActualizarTotal()
            Exit Sub
        End If

    End Sub

    Private Sub MenuItemBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemBorrar.Click
        If C1FlexGridCobranzaPagos.RowSel <= 0 Then Exit Sub

        Dim blnEliminar As Boolean = False
        If C1FlexGridCobranzaPagos.Rows.Count > 1 AndAlso C1FlexGridCobranzaPagos.Row > 0 AndAlso C1FlexGridCobranzaPagos.Item(C1FlexGridCobranzaPagos.Row, "ABDId") Is Nothing Then
            blnEliminar = True
        End If

        If Not (sVisitaClaveDeAbono = sVisitaClave Or blnEliminar) Then
            Exit Sub
        End If

        Dim iRow As Integer

        With C1FlexGridCobranzaPagos
            iRow = .RowSel

            aEliminados.Add(.Item(iRow, "ABDId"))

            .RemoveItem(iRow)
            ActualizarTotal()
        End With
    End Sub
#End Region


    Private Sub validacionesgenerales()

        If blnAbonosProgramados Then
            'Me.TextBoxMontoProgramado.Enabled = True
            'Me.DateTimePickerFechaPromesa.Enabled = True
            'Me.TextBoxMontoProgramado.Focus()

            Dim QryAbonoProgramadoImporte As String = String.Empty
            QryAbonoProgramadoImporte = "select Importe,FechaPromesa from abonoprogramado inner join transprod on Transprod.Transprodid=AbonoProgramado.TransprodId where transprod.transprodid='" & sTransprodid & "'"
            Dim AbonoProgImporte As DataTable = oDBVen.RealizarConsultaSQL(QryAbonoProgramadoImporte, "AbonoProgramado")

            If AbonoProgImporte.Rows.Count > 0 Then
                Dim Importe As String = AbonoProgImporte.Rows(0)(0).ToString
                'Me.TextBoxMontoProgramado.Text = Importe
                Dim FechaPromesa As Date = AbonoProgImporte.Rows(0)(1).ToString
                'Me.DateTimePickerFechaPromesa.Value = FechaPromesa
            Else
                'Me.TextBoxMontoProgramado.Text = ""
                'Me.DateTimePickerFechaPromesa.Value = Now
            End If

            Dim QryAbntrpSerCor As String = ""
            QryAbntrpSerCor = "select ABNId,Serie,Corecibo from abntrp inner join transprod on Transprod.Transprodid=abntrp.TransprodId where transprod.transprodid='" & sTransprodid & "'"
            Dim AbntrpSerCor As DataTable = oDBVen.RealizarConsultaSQL(QryAbntrpSerCor, "AbonoProgramado")

            If AbntrpSerCor.Rows.Count > 0 Then
                Dim Ser As String = AbntrpSerCor.Rows(0)("Serie").ToString
                'Me.TextBoxSer.Text = Ser
                Dim Cor As String = AbntrpSerCor.Rows(0)("Corecibo").ToString
                'Me.TextBoxCor.Text = Cor
                MostrarABNdetalle(AbntrpSerCor.Rows(0)("ABNId"))
            Else
                'Me.TextBoxCor.Text = ""
                'Me.TextBoxSer.Text = ""
            End If

            AbonoProgImporte.Dispose()
            AbntrpSerCor.Dispose()
        Else
            'Me.TextBoxMontoProgramado.Enabled = False
            'Me.DateTimePickerFechaPromesa.Enabled = False

            Dim QryAbonoProgramadoImporte As String = ""
            QryAbonoProgramadoImporte = "select Importe,FechaPromesa from abonoprogramado inner join transprod on Transprod.Transprodid=AbonoProgramado.TransprodId where transprod.transprodid='" & sTransprodid & "'"
            Dim AbonoProgImporte As DataTable = oDBVen.RealizarConsultaSQL(QryAbonoProgramadoImporte, "AbonoProgramado")

            If AbonoProgImporte.Rows.Count > 0 Then
                'Dim Importe As String = AbonoProgImporte.Rows(0)(0).ToString
                'Me.TextBoxMontoProgramado.Text = Importe
                Dim FechaPromesa As Date = AbonoProgImporte.Rows(0)(1).ToString
                'Me.DateTimePickerFechaPromesa.Value = FechaPromesa
            Else
                'Me.TextBoxMontoProgramado.Text = ""
            End If

            Dim QryAbntrpSerCor As String = ""
            QryAbntrpSerCor = "select ABNId,Serie,Corecibo from abntrp inner join transprod on Transprod.Transprodid=abntrp.TransprodId where transprod.transprodid='" & sTransprodid & "'"
            Dim AbntrpSerCor As DataTable = oDBVen.RealizarConsultaSQL(QryAbntrpSerCor, "AbonoProgramado")

            If AbntrpSerCor.Rows.Count > 0 Then
                Dim Ser As String = AbntrpSerCor.Rows(0)("Serie").ToString
                'Me.TextBoxSer.Text = Ser
                Dim Cor As String = AbntrpSerCor.Rows(0)("Corecibo").ToString
                'Me.TextBoxCor.Text = Cor
                blnSeleccionManual = True
                MostrarABNdetalle(AbntrpSerCor.Rows(0)("ABNId"))
                blnSeleccionManual = False
                ActualizarTotal()
            Else
                'Me.TextBoxCor.Text = ""
                'Me.TextBoxSer.Text = ""
            End If

            AbonoProgImporte.Dispose()
            AbntrpSerCor.Dispose()
        End If

    End Sub
    Private Sub MostrarABNdetalle(ByVal parsABNId As String)
        Dim dsAbono As DataSet
        dsAbono = FormasPago.RecuperarAbono(parsABNId)

        If Not dsAbono Is Nothing Then
            sVisitaClaveDeAbono = dsAbono.Tables("Abono").Rows(0)("VisitaClave")
            sABNIdActual = dsAbono.Tables("Abono").Rows(0)("ABNId")
            dSaldoActualMonedaVenta = Decimal.Round(dsAbono.Tables("Abono").Rows(0)("Total"), 2)
            dSaldoClienteActualMonedaVenta = dSaldoActualMonedaVenta

            'dtpFecha.Value = dsAbono.Tables("Abono").Rows(0)("FechaAbono")
            Me.TextBoxTotal.Text = dsAbono.Tables("Abono").Rows(0)("Total")
            'Dim dImporte As Decimal = 0
            For Each dr As DataRow In dsAbono.Tables("ABNDetalle").Rows
                Dim r As C1.Win.C1FlexGrid.Row = C1FlexGridCobranzaPagos.Rows.Add
                With C1FlexGridCobranzaPagos
                    .Item(r.Index, "ABNId") = dr("ABNId")
                    .Item(r.Index, "ABDId") = dr("ABDId")
                    .Item(r.Index, "TipoPago") = dr("TipoPago").ToString
                    .Item(r.Index, "Moneda") = dr("MonedaId")
                    .Item(r.Index, "Importe") = dr("Importe")
                    'dImporte += dr("Importe")
                    .Item(r.Index, "TipoBanco") = IIf(IsDBNull(dr("TipoBanco")), dr("TipoBanco"), dr("TipoBanco").ToString)
                    .Item(r.Index, "Referencia") = dr("Referencia")
                    .Item(r.Index, "TipoCambio") = dr("TipoCambio")

                    'If CType(dr("TipoPago"), Integer) = 2 Then
                    'If Not blnLimiteCreditoCheque Then
                    'dSaldoClienteActualMonedaVenta -= Math.Round(CType(dr("Importe"), Decimal), 2)
                    'End If
                    'End If
                    Dim dtipoCambio As Decimal
                    Dim sGrupo As String = ValorReferencia.RecuperaGrupo("PAGO", CType(dr("TipoPago"), Integer)).ToUpper
                    If sGrupo = "EB" Then
                        If Not oCliente.ActualizaSaldoCheque Then
                            If C1FlexGridCobranzaPagos.Item(r.Index, "Moneda") = MonedaIdVenta Then


                                dSaldoClienteActualMonedaVenta -= C1FlexGridCobranzaPagos.Item(r.Index, "Importe")


                            ElseIf oConHist.Campos("MonedaID") = MonedaIdVenta Then

                                dtipoCambio = oDBVen.EjecutarCmdScalardblSQL("select tipoCambio from tcmoneda where monini='" + MonedaIdVenta + "' and monfin ='" + C1FlexGridCobranzaPagos.Item(r.Index, "Moneda") + "'")
                                dSaldoClienteActualMonedaVenta -= C1FlexGridCobranzaPagos.Item(r.Index, "Importe") * IIf(dtipoCambio = 0, 1, dtipoCambio)



                            ElseIf oConHist.Campos("MonedaID") <> MonedaIdVenta Then


                                'Validar la 3ra moneda pq solo esta hecho para dos monedas
                                dtipoCambio = oDBVen.EjecutarCmdScalardblSQL("select tipoCambio from tcmoneda where monini='" + MonedaIdVenta + "' and monfin ='" + C1FlexGridCobranzaPagos.Item(r.Index, "Moneda") + "'")
                                dSaldoClienteActualMonedaVenta -= C1FlexGridCobranzaPagos.Item(r.Index, "Importe") / IIf(dtipoCambio = 0, 1, dtipoCambio)
                            End If

                            'dSaldoClienteActualMonedaVenta -= Math.Round(CType(dr("Importe"), Decimal), 2) 
                        End If
                    End If
                    If sGrupo = "E" Then
                        If oCliente.ActualizaSaldoCheque OrElse oConHist.Campos("Preliquidacion") Then

                            If DicMonedaPagoEfectivoOriginal.ContainsKey(C1FlexGridCobranzaPagos.Item(r.Index, "Moneda")) Then
                                DicMonedaPagoEfectivoOriginal.Item(C1FlexGridCobranzaPagos.Item(r.Index, "Moneda")) = DicMonedaPagoEfectivoOriginal.Item(C1FlexGridCobranzaPagos.Item(r.Index, "Moneda")) + C1FlexGridCobranzaPagos.Item(r.Index, "Importe")
                            Else
                                DicMonedaPagoEfectivoOriginal.Add(C1FlexGridCobranzaPagos.Item(r.Index, "Moneda"), C1FlexGridCobranzaPagos.Item(r.Index, "Importe"))
                            End If

                            If C1FlexGridCobranzaPagos.Item(r.Index, "Moneda") = MonedaIdVenta Then
                                dPagosEfectivoOriginalMonedaVenta += C1FlexGridCobranzaPagos.Item(r.Index, "Importe")




                            ElseIf oConHist.Campos("MonedaID") = MonedaIdVenta Then

                                dtipoCambio = oDBVen.EjecutarCmdScalardblSQL("select tipoCambio from tcmoneda where monini='" + MonedaIdVenta + "' and monfin ='" + C1FlexGridCobranzaPagos.Item(r.Index, "Moneda") + "'")
                                dPagosEfectivoOriginalMonedaVenta += C1FlexGridCobranzaPagos.Item(r.Index, "Importe") * dtipoCambio


                            ElseIf oConHist.Campos("MonedaID") <> MonedaIdVenta Then


                                'Validar la 3ra moneda pq solo esta hecho para dos monedas
                                dtipoCambio = oDBVen.EjecutarCmdScalardblSQL("select tipoCambio from tcmoneda where monini='" + MonedaIdVenta + "' and monfin ='" + C1FlexGridCobranzaPagos.Item(r.Index, "Moneda") + "'")
                                dPagosEfectivoOriginalMonedaVenta += C1FlexGridCobranzaPagos.Item(r.Index, "Importe") / IIf(dtipoCambio = 0, 1, dtipoCambio)

                            End If

                            'dPagosEfectivoOriginalMonedaVenta += Math.Round(CType(dr("Importe"), Decimal), 2)
                        End If




                    End If
                End With
            Next
            'Me.TextBoxTotal.Text = dImporte
        End If
    End Sub

#Region "VALIDAR CREAR O MODIFICAR"
    Public Sub CargosAplicados()

        Dim Qry As String = ""
        If blnCobrarVentas Then
            'Qry = "SELECT Distinct Folio,FechaSurtido,Total,Saldo,Transprodid FROM Transprod inner join Visita on TransProd.VisitaClave =  Visita.VisitaClave WHERE exists(select * from abntrp where Transprod.transprodid=abntrp.transprodid)and (Transprod.Tipo=1 AND Transprod.TipoFase=2 AND Visita.ClienteClave='" & oCliente.ClienteClave & "' AND Visita.VendedorId='" & oVendedor.VendedorId & "' and Transprodid='" & sTransprodid & "')"
            Qry = "SELECT Distinct Folio,FechaSurtido,FechaCobranza,Total,Saldo,Transprodid FROM Transprod inner join Visita on TransProd.VisitaClave =  Visita.VisitaClave WHERE exists(select * from abntrp where Transprod.transprodid=abntrp.transprodid)and (((Transprod.Tipo=1 AND Transprod.TipoFase<>0) or TransProd.Tipo = 24) AND Visita.ClienteClave='" & oCliente.ClienteClave & "' and Transprodid='" & sTransprodid & "')"
        Else
            'Qry = "SELECT Distinct Folio,FechaFacturacion,Total,Saldo,Transprodid FROM Transprod inner join Visita on TransProd.VisitaClave =  Visita.VisitaClave WHERE exists(select * from abntrp where Transprod.transprodid=abntrp.transprodid)and (Transprod.Tipo=8 AND Transprod.TipoFase=1 AND Visita.ClienteClave='" & oCliente.ClienteClave & "' AND Visita.VendedorId='" & oVendedor.VendedorId & "' and Transprodid='" & sTransprodid & "')"
            Qry = "SELECT Distinct Folio,FechaFacturacion,FechaCobranza,Total,Saldo,Transprodid FROM Transprod inner join Visita on TransProd.VisitaClave =  Visita.VisitaClave WHERE exists(select * from abntrp where Transprod.transprodid=abntrp.transprodid)and (Transprod.Tipo=8 AND Transprod.TipoFase=1 AND Visita.ClienteClave='" & oCliente.ClienteClave & "' and Transprodid='" & sTransprodid & "')"
        End If

        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(Qry, "AbnTrp")
        If Dt.Rows.Count > 0 Then
            eEstado = Estado.Modificar
            Qry = "select sum(case when abndetalle.Importe=  abndetalle.SaldoDeposito then 0 else 1 end ) as Igual "
            Qry += "from abndetalle "
            Qry += "inner join abntrp on abntrp.abnid = abndetalle.abnid "
            Qry += "where transprodid = '" + sTransprodid + "'"
            If (oDBVen.EjecutarCmdScalarIntSQL(Qry) <> 0) Then
                If (EliminarCargo) Then
                    MsgBox(oVista.BuscarMensaje("MsgBox", "E0547"), MsgBoxStyle.Information)
                    Exit Sub
                Else
                    MsgBox(oVista.BuscarMensaje("MsgBox", "E0548"), MsgBoxStyle.Information)
                    eEstado = Estado.Navegar
                End If

            End If

            If (EliminarCargo) Then
                If oCliente.VencimientoVenta Then
                    Dim dFechaAbono As Date = oDBVen.EjecutarCmdScalarObjSQL("Select ABN.FechaAbono from Abono ABN inner join ABNTrp ABT on ABN.ABNId = ABT.ABNId where ABT.TransProdID='" & sTransprodid & "' ")
                    If blnCobrarVentas Then
                        If Dt.Rows(0)("FechaCobranza") < DateAdd(DateInterval.Day, (oCliente.DiasVencimiento * -1), Now) AndAlso (oDBVen.EjecutarCmdScalarIntSQL("Select count(*) from TransProd where Tipo = 1 and TipoFase = 2 and FechaHoraAlta>= " & UniFechaSQL(dFechaAbono))) > 0 Then
                            MsgBox(oVista.BuscarMensaje("MsgBox", "E0752").Replace("$0$", oVista.BuscarMensaje("MsgBox", "XVenta")), MsgBoxStyle.Information)
                            Exit Sub
                        End If
                    Else
                        If Dt.Rows(0)("FechaCobranza") < DateAdd(DateInterval.Day, (oCliente.DiasVencimiento * -1), Now) AndAlso (oDBVen.EjecutarCmdScalarIntSQL("Select count(*) from TransProd where Tipo = 8 and TipoFase <> 0 and FechaHoraAlta>= " & UniFechaSQL(dFechaAbono))) > 0 Then
                            MsgBox(oVista.BuscarMensaje("MsgBox", "E0752").Replace("$0$", oVista.BuscarMensaje("MsgBox", "XFactura")), MsgBoxStyle.Information)
                            Exit Sub
                        End If
                    End If
                End If
            End If

            Me.TextBoxFolio.Text = Folios
            Me.TextBoxFechaFactura.Text = FechaFactura

            Me.PanelCobranza.Visible = False
            Me.PanelCobranzaDetalles.Visible = True

            Me.validacionesgenerales()
            Me.TextBoxSaldoFactura.Text = Decimal.Round(SaldoFactura + dSaldoActualMonedaVenta, 2).ToString("#,##0.00")
        Else
            If (EliminarCargo) Then
                MsgBox(oVista.BuscarMensaje("MsgBox", "E0547"), MsgBoxStyle.Information)
                Exit Sub
            End If
            eEstado = Estado.Crear
            Me.TextBoxFolio.Text = Folios
            Me.TextBoxSaldoFactura.Text = Decimal.Round(SaldoFactura, 2).ToString("#,##0.00")
            Me.TextBoxFechaFactura.Text = FechaFactura

            Me.PanelCobranza.Visible = False
            Me.PanelCobranzaDetalles.Visible = True

            Me.validacionesgenerales()
        End If
        ButtonContinuarDetalles.Enabled = True
        If (EliminarCargo) Or (eEstado = Estado.Navegar) Then
            If (eEstado <> Estado.Navegar) Then
                eEstado = Estado.Eliminar
            Else
                ButtonContinuarDetalles.Enabled = False
            End If
            'TextBoxCor.Enabled = False
            'TextBoxMontoProgramado.Enabled = False
            'TextBoxSer.Enabled = False
            'DateTimePickerFechaPromesa.Enabled = False
            C1FlexGridCobranzaPagos.Enabled = False
        Else
            'TextBoxCor.Enabled = True
            'TextBoxMontoProgramado.Enabled = True
            'TextBoxSer.Enabled = True
            'DateTimePickerFechaPromesa.Enabled = True
            C1FlexGridCobranzaPagos.Enabled = True
        End If


        Dt.Dispose()
    End Sub
#End Region

    Private Sub ButtonRegresarDetalles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresarDetalles.Click
        If Me.RegresarDetalle() Then
            Me.DialogResult = Windows.Forms.DialogResult.Retry
            Me.Close()
            'Me.PanelCobranza.Visible = True
            'Me.PanelCobranzaDetalles.Visible = False
        End If
    End Sub

    Private Sub ButtonContinuarDetalles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuarDetalles.Click
        Cursor.Current = Cursors.WaitCursor
        Me.Enabled = False
        Dim DicMonedaPagoEfectivo As New System.Collections.Generic.Dictionary(Of String, Decimal)
        Dim dtipoCambio As Decimal = 0
        Dim bSaldarla As Boolean = False
        If (eEstado <> Estado.Eliminar) Then
            ActualizarTotal()
            If Not Validar() Then
                Cursor.Current = Cursors.Default
                Me.Enabled = True
                Exit Sub
            End If

            'If Me.TextBoxMontoProgramado.Enabled Then
            '    If Me.TextBoxMontoProgramado.Text = "" Or Not IsNumeric(Me.TextBoxMontoProgramado.Text) Then
            '        Me.TextBoxMontoProgramado.Text = 0
            '    End If
            '    If Me.TextBoxMontoProgramado.Text > 0 Then
            '        If Me.DateTimePickerFechaPromesa.Value <= UltimaHora(Now) Then
            '            MsgBox(oVista.BuscarMensaje("MsgBox", "E0352").Replace("$0$", Now.Date), MsgBoxStyle.Information)
            '            Me.DateTimePickerFechaPromesa.Focus()
            '            Cursor.Current = Cursors.Default
            '            Me.Enabled = True
            '            Exit Sub
            '        End If
            '    End If
            'End If
            Dim dSaldo As Decimal = IIf(Me.TextBoxSaldoFactura.Text = "", 0, Me.TextBoxSaldoFactura.Text)
            'Dim dImporte As Decimal = IIf(Me.TextBoxMontoProgramado.Text = "", 0, Me.TextBoxMontoProgramado.Text)
            Dim dTotal As Decimal = IIf(Me.TextBoxTotal.Text = "", 0, Me.TextBoxTotal.Text)

            If CType(C1FlexGridMonedaSaldo.Item(1, 1), Decimal) < 0 AndAlso CType(C1FlexGridMonedaSaldo.Item(2, 1), Decimal) < 0 Then
                'If (Decimal.Round((dTotal + dImporte), 2) > Decimal.Round(dSaldo, 2)) Then
                MsgBox(oVista.BuscarMensaje("MsgBox", "E0038"), MsgBoxStyle.Information)
                Me.C1FlexGridCobranzaPagos.Focus()
                Cursor.Current = Cursors.Default
                Me.Enabled = True
                Exit Sub

            End If

            If CType(C1FlexGridMonedaSaldo.Item(1, 1), Decimal) = 0 OrElse CType(C1FlexGridMonedaSaldo.Item(2, 1), Decimal) = 0 Then
                bSaldarla = True
            End If

            '******************************************************************************************
            Try
                If oDBVen.oConexion.State = ConnectionState.Closed Then
                    oDBVen.oConexion.Open()
                End If
                Me.Transaccion = oDBVen.oConexion.BeginTransaction()

                Select Case eEstado
                    Case Estado.Crear
                        'If Not Validar() Then
                        '    Exit Sub
                        'End If

                        sFolio = Folio.Obtener(, ServicesCentral.TiposModulosMovDet.Cobranza)
                        Dim sABNId As String = ""
                        'If Me.TextBoxMontoProgramado.Enabled Then
                        '    If Me.TextBoxMontoProgramado.Text > 0 Then
                        '        GuardaAbonoProgramado(Me.DateTimePickerFechaPromesa.Value, dImporte)
                        '    End If
                        'End If

                        sABNId = FormasPago.GuardarAbono(Me.ListViewCobranza.Items.Count, sFolio, sVisitaClave, oDia.DiaActual, DateTime.Today, Me.TextBoxTotal.Text, 0, ServicesCentral.TiposModulosMovDet.Cobranza)
                        If sABNId <> "" Then
                            Dim i As Integer
                            Dim dPagoCheque As Decimal = 0
                            Dim dPagoEfectivo As Decimal = 0



                            For i = 1 To C1FlexGridCobranzaPagos.Rows.Count - 1
                                Dim iTipoBanco As Integer = -1
                                If Not IsDBNull(C1FlexGridCobranzaPagos.Item(i, "TipoBanco")) Then
                                    If IsNumeric(C1FlexGridCobranzaPagos.Item(i, "TipoBanco")) Then
                                        iTipoBanco = C1FlexGridCobranzaPagos.Item(i, "TipoBanco")
                                    End If
                                End If

                                If Not RenglonVacio(i) Then
                                    'If CType(C1FlexGridCobranzaPagos.Item(i, "TipoPago"), Integer) = 2 Then
                                    'If Not blnLimiteCreditoCheque Then
                                    'dPagoCheque += CType(C1FlexGridCobranzaPagos.Item(i, "Importe"), Decimal)
                                    'End If
                                    'End If


                                    If IsNumeric(C1FlexGridCobranzaPagos.Item(i, "TipoPago")) AndAlso ValorReferencia.RecuperaGrupo("PAGO", CType(C1FlexGridCobranzaPagos.Item(i, "TipoPago"), Integer)).ToUpper = "EB" Then
                                        If Not oCliente.ActualizaSaldoCheque Then

                                            If C1FlexGridCobranzaPagos.Item(i, "Moneda") = MonedaIdVenta Then
                                                dPagoCheque += C1FlexGridCobranzaPagos.Item(i, "Importe")




                                            ElseIf oConHist.Campos("MonedaID") = MonedaIdVenta Then

                                                dtipoCambio = oDBVen.EjecutarCmdScalardblSQL("select tipoCambio from tcmoneda where monini='" + MonedaIdVenta + "' and monfin ='" + C1FlexGridCobranzaPagos.Item(i, "Moneda") + "'")
                                                dPagoCheque += C1FlexGridCobranzaPagos.Item(i, "Importe") * dtipoCambio


                                            ElseIf oConHist.Campos("MonedaID") <> MonedaIdVenta Then


                                                'Validar la 3ra moneda pq solo esta hecho para dos monedas
                                                dtipoCambio = oDBVen.EjecutarCmdScalardblSQL("select tipoCambio from tcmoneda where monini='" + MonedaIdVenta + "' and monfin ='" + C1FlexGridCobranzaPagos.Item(i, "Moneda") + "'")
                                                dPagoCheque += C1FlexGridCobranzaPagos.Item(i, "Importe") / IIf(dtipoCambio = 0, 1, dtipoCambio)

                                            End If


                                            'dPagoCheque += CType(C1FlexGridCobranzaPagos.Item(i, "Importe"), Decimal)


                                        End If

                                    End If
                                    FormasPago.GuardarABNDetalle(sABNId, oApp.KEYGEN(i), C1FlexGridCobranzaPagos.Item(i, "TipoPago"), C1FlexGridCobranzaPagos.Item(i, "Importe"), C1FlexGridCobranzaPagos.Item(i, "Importe"), iTipoBanco, C1FlexGridCobranzaPagos.Item(i, "Referencia"), C1FlexGridCobranzaPagos.Item(i, "Moneda"), C1FlexGridCobranzaPagos.Item(i, "TipoCambio"))

                                    'y los de credito apa?
                                    If IsNumeric(C1FlexGridCobranzaPagos.Item(i, "TipoPago")) AndAlso ValorReferencia.RecuperaGrupo("PAGO", C1FlexGridCobranzaPagos.Item(i, "TipoPago")).ToUpper = "E" Then

                                        If DicMonedaPagoEfectivo.ContainsKey(C1FlexGridCobranzaPagos.Item(i, "Moneda")) Then
                                            DicMonedaPagoEfectivo.Item(C1FlexGridCobranzaPagos.Item(i, "Moneda")) = DicMonedaPagoEfectivo.Item(C1FlexGridCobranzaPagos.Item(i, "Moneda")) + C1FlexGridCobranzaPagos.Item(i, "Importe")
                                        Else
                                            DicMonedaPagoEfectivo.Add(C1FlexGridCobranzaPagos.Item(i, "Moneda"), C1FlexGridCobranzaPagos.Item(i, "Importe"))
                                        End If

                                        If C1FlexGridCobranzaPagos.Item(i, "Moneda") = MonedaIdVenta Then
                                            dPagoEfectivo += C1FlexGridCobranzaPagos.Item(i, "Importe")




                                        ElseIf oConHist.Campos("MonedaID") = MonedaIdVenta Then

                                            dtipoCambio = oDBVen.EjecutarCmdScalardblSQL("select tipoCambio from tcmoneda where monini='" + MonedaIdVenta + "' and monfin ='" + C1FlexGridCobranzaPagos.Item(i, "Moneda") + "'")
                                            dPagoEfectivo += C1FlexGridCobranzaPagos.Item(i, "Importe") * dtipoCambio


                                        ElseIf oConHist.Campos("MonedaID") <> MonedaIdVenta Then


                                            'Validar la 3ra moneda pq solo esta hecho para dos monedas
                                            dtipoCambio = oDBVen.EjecutarCmdScalardblSQL("select tipoCambio from tcmoneda where monini='" + MonedaIdVenta + "' and monfin ='" + C1FlexGridCobranzaPagos.Item(i, "Moneda") + "'")
                                            dPagoEfectivo += C1FlexGridCobranzaPagos.Item(i, "Importe") / IIf(dtipoCambio = 0, 1, dtipoCambio)

                                        End If

                                        'dPagoEfectivo += CType(C1FlexGridCobranzaPagos.Item(i, "Importe"), Decimal)
                                    End If
                                End If
                            Next

                            oCliente.ActualizarSaldo(Decimal.Round((Decimal.Negate(CType(Me.TextBoxTotal.Text, Decimal) - dPagoCheque)) * TipoCambioVenta, 2))

                            GuardarAbnTrp(sABNId, dTotal)

                            If bSaldarla Then
                                SaldarTransProd()
                            Else
                                ActualizarSaldoTransProd(dTotal)
                            End If

                            If oConHist.Campos("Preliquidacion") Then
                                For Each llave As String In DicMonedaPagoEfectivo.Keys
                                    GuardaPreliquidacion(DicMonedaPagoEfectivo(llave), llave, False)
                                Next

                            End If
                            Me.Transaccion.Commit()
                            Me.Transaccion.Dispose()
                            Me.Transaccion = Nothing
                            If oVendedor.motconfiguracion.MensajeImpresion Then
                                If MsgBox(oVista.BuscarMensaje("MsgBox", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                                    ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, sABNId, 0, 10, oCliente, sVisitaClave) 'Tipo movimiento Tipo recibo
                                End If
                            End If
                        End If
                    Case Estado.Modificar
                        'If Me.TextBoxMontoProgramado.Enabled Then
                        '    GuardaAbonoProgramado(Me.DateTimePickerFechaPromesa.Value, dImporte)
                        'End If

                        Dim dPagoCheque As Decimal = 0
                        Dim dPagoEfectivo As Decimal = 0
                        If FormasPago.ModificarAbono(sABNIdActual, Me.TextBoxTotal.Text, 0) Then
                            'Se suma el saldo anterior
                            Dim i As Integer
                            'Guardar Modificados y nuevos
                            For i = 1 To C1FlexGridCobranzaPagos.Rows.Count - 1
                                If Not RenglonVacio(i) Then
                                    Dim iTipoBanco As Integer = -1
                                    If Not IsDBNull(C1FlexGridCobranzaPagos.Item(i, "TipoBanco")) Then
                                        If IsNumeric(C1FlexGridCobranzaPagos.Item(i, "TipoBanco")) Then
                                            iTipoBanco = C1FlexGridCobranzaPagos.Item(i, "TipoBanco")
                                        End If
                                    End If
                                    'If CType(C1FlexGridCobranzaPagos.Item(i, "TipoPago"), Integer) = 2 Then
                                    'If Not blnLimiteCreditoCheque Then
                                    'dPagoCheque += CType(C1FlexGridCobranzaPagos.Item(i, "Importe"), Decimal)
                                    'End If
                                    'End If
                                    Dim sGrupo As String = ValorReferencia.RecuperaGrupo("PAGO", CType(C1FlexGridCobranzaPagos.Item(i, "TipoPago"), Integer)).ToUpper
                                    If sGrupo = "EB" Then
                                        If Not oCliente.ActualizaSaldoCheque Then

                                            If C1FlexGridCobranzaPagos.Item(i, "Moneda") = MonedaIdVenta Then
                                                dPagoCheque += C1FlexGridCobranzaPagos.Item(i, "Importe")




                                            ElseIf oConHist.Campos("MonedaID") = MonedaIdVenta Then

                                                dtipoCambio = oDBVen.EjecutarCmdScalardblSQL("select tipoCambio from tcmoneda where monini='" + MonedaIdVenta + "' and monfin ='" + C1FlexGridCobranzaPagos.Item(i, "Moneda") + "'")
                                                dPagoCheque += C1FlexGridCobranzaPagos.Item(i, "Importe") * dtipoCambio


                                            ElseIf oConHist.Campos("MonedaID") <> MonedaIdVenta Then


                                                'Validar la 3ra moneda pq solo esta hecho para dos monedas
                                                dtipoCambio = oDBVen.EjecutarCmdScalardblSQL("select tipoCambio from tcmoneda where monini='" + MonedaIdVenta + "' and monfin ='" + C1FlexGridCobranzaPagos.Item(i, "Moneda") + "'")
                                                dPagoCheque += C1FlexGridCobranzaPagos.Item(i, "Importe") / IIf(dtipoCambio = 0, 1, dtipoCambio)

                                            End If


                                            'dPagoCheque += CType(C1FlexGridCobranzaPagos.Item(i, "Importe"), Decimal)


                                        End If


                                    End If

                                    If sGrupo = "E" Then
                                        If DicMonedaPagoEfectivo.ContainsKey(C1FlexGridCobranzaPagos.Item(i, "Moneda")) Then
                                            DicMonedaPagoEfectivo.Item(C1FlexGridCobranzaPagos.Item(i, "Moneda")) = DicMonedaPagoEfectivo.Item(C1FlexGridCobranzaPagos.Item(i, "Moneda")) + C1FlexGridCobranzaPagos.Item(i, "Importe")
                                        Else
                                            DicMonedaPagoEfectivo.Add(C1FlexGridCobranzaPagos.Item(i, "Moneda"), C1FlexGridCobranzaPagos.Item(i, "Importe"))
                                        End If

                                        If C1FlexGridCobranzaPagos.Item(i, "Moneda") = MonedaIdVenta Then
                                            dPagoEfectivo += C1FlexGridCobranzaPagos.Item(i, "Importe")




                                        ElseIf oConHist.Campos("MonedaID") = MonedaIdVenta Then

                                            dtipoCambio = oDBVen.EjecutarCmdScalardblSQL("select tipoCambio from tcmoneda where monini='" + MonedaIdVenta + "' and monfin ='" + C1FlexGridCobranzaPagos.Item(i, "Moneda") + "'")
                                            dPagoEfectivo += C1FlexGridCobranzaPagos.Item(i, "Importe") * dtipoCambio


                                        ElseIf oConHist.Campos("MonedaID") <> MonedaIdVenta Then


                                            'Validar la 3ra moneda pq solo esta hecho para dos monedas
                                            dtipoCambio = oDBVen.EjecutarCmdScalardblSQL("select tipoCambio from tcmoneda where monini='" + MonedaIdVenta + "' and monfin ='" + C1FlexGridCobranzaPagos.Item(i, "Moneda") + "'")
                                            dPagoEfectivo += C1FlexGridCobranzaPagos.Item(i, "Importe") / IIf(dtipoCambio = 0, 1, dtipoCambio)

                                        End If
                                    End If

                                    If (Not C1FlexGridCobranzaPagos.Item(i, "ABNId") Is Nothing) And (Not C1FlexGridCobranzaPagos.Item(i, "ABDId") Is Nothing) Then

                                        FormasPago.ModificarABNDetalle(C1FlexGridCobranzaPagos.Item(i, "ABNId"), C1FlexGridCobranzaPagos.Item(i, "ABDId"), CInt(C1FlexGridCobranzaPagos.Item(i, "TipoPago")), CDec(C1FlexGridCobranzaPagos.Item(i, "Importe")), CDec(C1FlexGridCobranzaPagos.Item(i, "Importe")), iTipoBanco, C1FlexGridCobranzaPagos.Item(i, "Referencia"), C1FlexGridCobranzaPagos.Item(i, "Moneda"), C1FlexGridCobranzaPagos.Item(i, "TipoCambio"), )


                                    Else

                                        FormasPago.GuardarABNDetalle(sABNIdActual, oApp.KEYGEN(i), CInt(C1FlexGridCobranzaPagos.Item(i, "TipoPago")), CDec(C1FlexGridCobranzaPagos.Item(i, "Importe")), CDec(C1FlexGridCobranzaPagos.Item(i, "Importe")), iTipoBanco, C1FlexGridCobranzaPagos.Item(i, "Referencia"), C1FlexGridCobranzaPagos.Item(i, "Moneda"), C1FlexGridCobranzaPagos.Item(i, "TipoCambio"))



                                    End If

                                End If
                            Next
                        End If

                        'Validar que haya existencia suficiente en Preliquidacion
                        If oConHist.Campos("Preliquidacion") Then
                            For Each llave As String In DicMonedaPagoEfectivoOriginal.Keys
                                Dim oDT As DataTable = oDBVen.RealizarConsultaSQL("SELECT PLIId, MontoTotal FROM PreLiquidacion where Enviado = 0 and monedaid='" & llave & "'", "Preliq")
                                If oDT.Rows.Count > 0 Then
                                    If DicMonedaPagoEfectivo.ContainsKey(llave) Then
                                        If CType(oDT.Rows(0)("MontoTotal"), Decimal) < (DicMonedaPagoEfectivoOriginal(llave) - DicMonedaPagoEfectivo(llave)) Then
                                            MsgBox(oVista.BuscarMensaje("MsgBox", "E0590"), MsgBoxStyle.Critical)
                                            Cursor.Current = Cursors.Default
                                            Me.Transaccion.Rollback()
                                            Me.Transaccion.Dispose()
                                            Me.Transaccion = Nothing
                                            Me.Enabled = True
                                            Exit Sub
                                        End If
                                    Else
                                        If CType(oDT.Rows(0)("MontoTotal"), Decimal) < (DicMonedaPagoEfectivoOriginal(llave)) Then
                                            MsgBox(oVista.BuscarMensaje("MsgBox", "E0590"), MsgBoxStyle.Critical)
                                            Cursor.Current = Cursors.Default
                                            Me.Transaccion.Rollback()
                                            Me.Transaccion.Dispose()
                                            Me.Transaccion = Nothing
                                            Me.Enabled = True
                                            Exit Sub
                                        End If
                                    End If

                                End If

                            Next
                            For Each llave As String In DicMonedaPagoEfectivo.Keys
                                Dim oDT As DataTable = oDBVen.RealizarConsultaSQL("SELECT PLIId, MontoTotal FROM PreLiquidacion where Enviado = 0 and monedaid='" & llave & "'", "Preliq")
                                If oDT.Rows.Count > 0 Then
                                    If Not DicMonedaPagoEfectivoOriginal.ContainsKey(llave) Then
                                        If CType(oDT.Rows(0)("MontoTotal"), Decimal) < (-DicMonedaPagoEfectivo(llave)) Then
                                            MsgBox(oVista.BuscarMensaje("MsgBox", "E0590"), MsgBoxStyle.Critical)
                                            Cursor.Current = Cursors.Default
                                            Me.Transaccion.Rollback()
                                            Me.Transaccion.Dispose()
                                            Me.Transaccion = Nothing
                                            Me.Enabled = True
                                            Exit Sub
                                        End If
                                    End If

                                End If

                            Next
                            'Dim oDT As DataTable = oDBVen.RealizarConsultaSQL("SELECT PLIId, MontoTotal FROM PreLiquidacion where Enviado = 0", "Preliq")
                            'If oDT.Rows.Count > 0 Then
                            '    If CType(oDT.Rows(0)("MontoTotal"), Decimal) < (dPagosEfectivoOriginalMonedaVenta - dPagoEfectivo) Then
                            '        MsgBox(oVista.BuscarMensaje("MsgBox", "E0590"), MsgBoxStyle.Critical)
                            '        Cursor.Current = Cursors.Default
                            '        Me.Transaccion.Rollback()
                            '        Me.Transaccion.Dispose()
                            '        Me.Transaccion = Nothing
                            '        Exit Sub
                            '    End If
                            'End If
                        End If

                        'Guardar Eliminados
                        For Each sABDId As String In aEliminados
                            FormasPago.EliminarABNDetalle(sABNIdActual, sABDId)
                        Next

                        oCliente.ActualizarSaldo((dSaldoClienteActualMonedaVenta - (CType(Me.TextBoxTotal.Text, Decimal) - dPagoCheque)) * TipoCambioVenta)

                        GuardarAbnTrp(sABNIdActual, dTotal)


                        If bSaldarla Then
                            SaldarTransProd()
                        Else
                            ActualizarSaldoTransProd(dTotal - dSaldoActualMonedaVenta)
                        End If



                        If oConHist.Campos("Preliquidacion") Then
                            For Each llave As String In DicMonedaPagoEfectivoOriginal.Keys
                                If DicMonedaPagoEfectivo.ContainsKey(llave) Then
                                    GuardaPreliquidacion(DicMonedaPagoEfectivo(llave) - DicMonedaPagoEfectivoOriginal(llave), llave, False)
                                Else
                                    GuardaPreliquidacion(DicMonedaPagoEfectivoOriginal(llave), llave, True)
                                End If

                            Next

                            For Each llave As String In DicMonedaPagoEfectivo.Keys
                                If Not DicMonedaPagoEfectivoOriginal.ContainsKey(llave) Then

                                    GuardaPreliquidacion(DicMonedaPagoEfectivo(llave), llave, False)

                                End If
                            Next
                            'GuardaPreliquidacion(dPagoEfectivo - dPagosEfectivoOriginalMonedaVenta, False)
                        End If
                        Me.Transaccion.Commit()
                        Me.Transaccion.Dispose()
                        Me.Transaccion = Nothing
                        If oVendedor.motconfiguracion.MensajeImpresion Then
                            If MsgBox(oVista.BuscarMensaje("MsgBox", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                                ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, sABNIdActual, 0, 10, oCliente, sVisitaClave) 'Tipo movimiento Tipo recibo
                            End If
                        End If
                End Select

                Cursor.Current = Cursors.Default
                'LlenarLV()
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Enabled = True
                Me.Close()
            Catch ex As Exception
                Cursor.Current = Cursors.Default
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Me.Enabled = True
                Me.Transaccion.Rollback()
                Me.Transaccion.Dispose()
                Me.Transaccion = Nothing
            End Try
        Else
            Try
                If oConHist.Campos("Preliquidacion") Then

                    For Each llave As String In DicMonedaPagoEfectivoOriginal.Keys
                        Dim oDT As DataTable = oDBVen.RealizarConsultaSQL("SELECT PLIId, MontoTotal FROM PreLiquidacion where Enviado = 0 and monedaid='" & llave & "'", "Preliq")
                        If oDT.Rows.Count > 0 Then

                            If CType(oDT.Rows(0)("MontoTotal"), Decimal) < (DicMonedaPagoEfectivoOriginal(llave)) Then
                                MsgBox(oVista.BuscarMensaje("MsgBox", "E0590"), MsgBoxStyle.Critical)
                                Cursor.Current = Cursors.Default

                                Me.Enabled = True
                                Exit Sub
                            End If


                        End If

                    Next


                    'Dim oDT As DataTable = oDBVen.RealizarConsultaSQL("SELECT PLIId, MontoTotal FROM PreLiquidacion where Enviado = 0", "Preliq")
                    'If oDT.Rows.Count > 0 Then
                    '    If CType(oDT.Rows(0)("MontoTotal"), Decimal) < dPagosEfectivoOriginalMonedaVenta Then
                    '        MsgBox(oVista.BuscarMensaje("MsgBox", "E0590"), MsgBoxStyle.Critical)
                    '        Cursor.Current = Cursors.Default
                    '        Exit Sub
                    '    End If

                    'End If
                End If

                Dim dPagoCheque As Decimal = 0
                Dim dPagoEfectivo As Decimal = 0



                For i As Integer = 1 To C1FlexGridCobranzaPagos.Rows.Count - 1
                    Dim iTipoBanco As Integer = -1
                    If Not IsDBNull(C1FlexGridCobranzaPagos.Item(i, "TipoBanco")) Then
                        If IsNumeric(C1FlexGridCobranzaPagos.Item(i, "TipoBanco")) Then
                            iTipoBanco = C1FlexGridCobranzaPagos.Item(i, "TipoBanco")
                        End If
                    End If

                    If Not RenglonVacio(i) Then
                        'If CType(C1FlexGridCobranzaPagos.Item(i, "TipoPago"), Integer) = 2 Then
                        'If Not blnLimiteCreditoCheque Then
                        'dPagoCheque += CType(C1FlexGridCobranzaPagos.Item(i, "Importe"), Decimal)
                        'End If
                        'End If


                        If IsNumeric(C1FlexGridCobranzaPagos.Item(i, "TipoPago")) AndAlso ValorReferencia.RecuperaGrupo("PAGO", CType(C1FlexGridCobranzaPagos.Item(i, "TipoPago"), Integer)).ToUpper = "EB" Then
                            If Not oCliente.ActualizaSaldoCheque Then

                                If C1FlexGridCobranzaPagos.Item(i, "Moneda") = MonedaIdVenta Then
                                    dPagoCheque += C1FlexGridCobranzaPagos.Item(i, "Importe")




                                ElseIf oConHist.Campos("MonedaID") = MonedaIdVenta Then

                                    dtipoCambio = oDBVen.EjecutarCmdScalardblSQL("select tipoCambio from tcmoneda where monini='" + MonedaIdVenta + "' and monfin ='" + C1FlexGridCobranzaPagos.Item(i, "Moneda") + "'")
                                    dPagoCheque += C1FlexGridCobranzaPagos.Item(i, "Importe") * dtipoCambio

                                ElseIf oConHist.Campos("MonedaID") <> MonedaIdVenta Then
                                    'Validar la 3ra moneda pq solo esta hecho para dos monedas
                                    dtipoCambio = oDBVen.EjecutarCmdScalardblSQL("select tipoCambio from tcmoneda where monini='" + MonedaIdVenta + "' and monfin ='" + C1FlexGridCobranzaPagos.Item(i, "Moneda") + "'")
                                    dPagoCheque += C1FlexGridCobranzaPagos.Item(i, "Importe") / IIf(dtipoCambio = 0, 1, dtipoCambio)
                                End If
                                'dPagoCheque += CType(C1FlexGridCobranzaPagos.Item(i, "Importe"), Decimal)
                            End If
                        End If
                    End If
                Next

                If oDBVen.oConexion.State = ConnectionState.Closed Then
                    oDBVen.oConexion.Open()
                End If
                Me.Transaccion = oDBVen.oConexion.BeginTransaction()
                oDBVen.EjecutarComandoSQL("DELETE FROM AbonoProgramado WHERE TransProdId = '" + sTransprodid + "'")
                Dim ABOid As String = oDBVen.EjecutarCmdScalarStrSQL("select ABNid from abntrp WHERE transprodid = '" + sTransprodid + "'")
                Dim aboTot As Decimal = oDBVen.EjecutarCmdScalardblSQL("select Total from abono WHERE abnid = '" & ABOid & "'")
                ActualizarSaldoTransProd((-1 * aboTot))
                oCliente.ActualizarSaldo((aboTot - dPagoCheque) * TipoCambioVenta)


                oDBVen.EjecutarComandoSQL("DELETE FROM AbnTrp WHERE transprodid = '" + sTransprodid + "'")
                oDBVen.EjecutarComandoSQL("DELETE FROM ABNDetalle WHERE abnid = '" + ABOid + "'")
                oDBVen.EjecutarComandoSQL("DELETE FROM abono WHERE abnid = '" + ABOid + "'")

                If oConHist.Campos("Preliquidacion") Then
                    For Each llave As String In DicMonedaPagoEfectivoOriginal.Keys
                        GuardaPreliquidacion(DicMonedaPagoEfectivoOriginal(llave), llave, True)
                    Next
                    'GuardaPreliquidacion(dPagosEfectivoOriginalMonedaVenta, True)
                End If

                Me.Transaccion.Commit()
                Me.Transaccion.Dispose()
                Me.Transaccion = Nothing
                Cursor.Current = Cursors.Default
                LlenarLV()
            Catch ex As Exception
                Cursor.Current = Cursors.Default
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Me.Enabled = True
                Me.Transaccion.Rollback()
                Me.Transaccion.Dispose()
                Me.Transaccion = Nothing
            End Try
        End If
        Cursor.Current = Cursors.Default
        Me.Enabled = True
    End Sub

    Private Sub GuardaPreliquidacion(ByVal parsImporte As Decimal, ByVal parsMonedaId As String, ByVal bEliminar As Boolean)
        Dim oDT As DataTable = oDBVen.RealizarConsultaSQL("SELECT PLIId, MontoTotal FROM PreLiquidacion where Enviado = 0 and MonedaID='" + parsMonedaId + "' ", "Preliq")
        Dim bExistePreliquidacion As Boolean = oDT.Rows.Count > 0
        Dim sPLIId As String = ""
        Dim nMontoTotal As Decimal = 0
        Dim sComando As String
        If bExistePreliquidacion Then
            sPLIId = oDT.Rows(0)("PLIId")
            nMontoTotal = oDT.Rows(0)("MontoTotal")
        End If

        If Not bEliminar Then
            nMontoTotal += parsImporte
            If bExistePreliquidacion Then
                sComando = "update PreLiquidacion set MontoTotal = " & nMontoTotal & " where PLIId = '" & sPLIId & "'"
            Else
                sPLIId = oApp.KEYGEN(1)
                sComando = "insert into PreLiquidacion (PLIId, FechaPreLiquidacion,MonedaID  ,MontoTotal, Enviado) values ('" & sPLIId & "', " & UniFechaSQL(Now) & ",'" & parsMonedaId & "', " & nMontoTotal & ", 0)"
            End If
        Else
            nMontoTotal -= parsImporte
            If nMontoTotal <> 0 Then
                sComando = "update PreLiquidacion set MontoTotal = " & nMontoTotal & " where PLIId = '" & sPLIId & "'"
            Else
                Dim bBorrar As Boolean
                bBorrar = (oDBVen.RealizarScalarSQL("select count(*) from PLBPLE where PLIId = '" & sPLIId & "'") = 0)
                bBorrar = bBorrar And (oDBVen.RealizarScalarSQL("select count(*) from TransProd where PLIId = '" & sPLIId & "'") = 0)
                If bBorrar Then
                    sComando = "delete Preliquidacion where PLIId = '" & sPLIId & "'"
                Else
                    sComando = "update PreLiquidacion set MontoTotal = " & nMontoTotal & " where PLIId = '" & sPLIId & "'"
                End If
            End If
        End If

        oDBVen.EjecutarComandoSQL(sComando)

    End Sub
    Private Sub ActualizarSaldoTransProd(ByVal pardImporte As Decimal)
        Dim strSQLTransProd As New System.Text.StringBuilder

        With strSQLTransProd
            .Append("Update TransProd set Saldo=Round((Saldo)-(")
            .Append(pardImporte & "),2)")
            .Append(",MfechaHora=getdate(),MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 Where TransProdID='" & sTransprodid & "'")
        End With

        oDBVen.EjecutarComandoSQL(strSQLTransProd.ToString)
    End Sub

    Private Sub SaldarTransProd()
        Dim strSQLTransProd As New System.Text.StringBuilder

        With strSQLTransProd
            .Append("Update TransProd set Saldo=0")
            .Append(",MfechaHora=getdate(),MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 Where TransProdID='" & sTransprodid & "'")
        End With

        oDBVen.EjecutarComandoSQL(strSQLTransProd.ToString)
    End Sub


    Private Sub GuardarAbnTrp(ByVal parsABNId As String, ByVal pardImporte As Decimal)
        Dim strSQL1 As New System.Text.StringBuilder
        If eEstado = Estado.Crear Then
            With strSQL1
                .Append("Insert into AbnTrp (ABNID,TransProdID, FechaHora,Importe,Serie, Corecibo,MFechaHora, MUsuarioID,Enviado)")
                .Append(" Values('")
                .Append(parsABNId & "','")
                .Append(sTransprodid & "',")
                .Append("getdate(),")
                .Append(Decimal.Round(pardImporte, 2) & ",")
                .Append("'" & "" & "',")
                .Append("'" & "" & "',")
                .Append("getdate(),")
                .Append("'" & oVendedor.UsuarioId & "',0)")

            End With
        Else
            With strSQL1
                .Append("UPDATE AbnTrp set ")
                .Append("FechaHora= getdate(),")
                .Append("Importe=" & Decimal.Round(pardImporte, 2) & ",")
                .Append("Serie='" & "" & "',")
                .Append("Corecibo='" & "" & "',")
                .Append("MFechaHora=getdate(),")
                .Append("MUsuarioID='" & oVendedor.UsuarioId & "',Enviado = 0 ")
                .Append("where ABNId='" & sABNIdActual & "' and TransProdId='" & sTransprodid & "'")
            End With
        End If

        oDBVen.EjecutarComandoSQL(strSQL1.ToString)
    End Sub

    'Private Function GuardaAbonoProgramado(ByVal pvFechaPromesa As Date, ByVal pvImporte As Decimal)
    '    Dim sQuery As String = String.Empty
    '    Dim dtAbonoProgramado As DataTable = oDBVen.RealizarConsultaSQL("Select * from AbonoProgramado where TransProdId='" & sTransprodid & "'", "AbonoProgramado")
    '    If dtAbonoProgramado.Rows.Count <= 0 Then
    '        If pvImporte > 0 Then
    '            sQuery = "INSERT INTO AbonoProgramado VALUES('" & oApp.KEYGEN(1) & "','" & sVisitaClave & "','" & oDia.DiaActual & "','" & sTransprodid & "'," & UniFechaSQL(PrimeraHora(pvFechaPromesa)) & "," & Decimal.Round(pvImporte, 2) & ",getdate(),'" & oVendedor.UsuarioId & "',0,0)"
    '        Else
    '            Return True
    '        End If
    '    Else
    '        If dtAbonoProgramado.Rows(0)("FechaPromesa") <> Me.DateTimePickerFechaPromesa.Value Or dtAbonoProgramado.Rows(0)("Importe") <> Me.TextBoxMontoProgramado.Text Then
    '            sQuery = "UPDATE AbonoProgramado SET Importe=" & Decimal.Round(pvImporte, 2) & ",FechaPromesa=" & UniFechaSQL(PrimeraHora(pvFechaPromesa)) & ",MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioId='" & oVendedor.VendedorId & "',Enviado=0 WHERE ABPId='" & dtAbonoProgramado.Rows(0)("ABPId") & "'"
    '        Else
    '            Return True
    '        End If
    '    End If
    '    oDBVen.EjecutarComandoSQL(sQuery)
    '    dtAbonoProgramado.Dispose()
    '    Return True
    'End Function

    Private Function RenglonVacio(ByVal iRow As Integer) As Boolean
        Try
            With C1FlexGridCobranzaPagos

                If (.Item(iRow, "TipoPago") Is Nothing OrElse .Item(iRow, "TipoPago").ToString = String.Empty) And (.Item(iRow, "Importe") Is Nothing OrElse .Item(iRow, "Importe").ToString = String.Empty) And (.Item(iRow, "TipoBanco") Is Nothing OrElse .Item(iRow, "TipoBanco").ToString = String.Empty) And (.Item(iRow, "Referencia") Is Nothing OrElse .Item(iRow, "Referencia").ToString = String.Empty) Then
                    Return True
                End If
            End With

        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Private Sub ContextMenuAgregarPago_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenuAgregarPago.Popup
        If eEstado = Estado.Eliminar Then
            MenuItemBorrar.Enabled = False
            MenuItemCrear.Enabled = False
        Else
            Dim blnEliminar As Boolean = False
            If C1FlexGridCobranzaPagos.Rows.Count > 1 AndAlso C1FlexGridCobranzaPagos.Row > 0 AndAlso C1FlexGridCobranzaPagos.Item(C1FlexGridCobranzaPagos.Row, "ABDId") Is Nothing Then
                blnEliminar = True
            End If

            If sVisitaClaveDeAbono = sVisitaClave Or blnEliminar Then
                MenuItemBorrar.Enabled = True
            Else
                MenuItemBorrar.Enabled = False
            End If
            MenuItemCrear.Enabled = True
        End If
    End Sub

    Private Function RegresarDetalle() As Boolean
        If eEstado = Estado.Crear Or eEstado = Estado.Modificar Then
            If bHuboCambios = True Then
                If MsgBox(oVista.BuscarMensaje("MsgBox", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                    Return False
                End If
            End If
        End If
        'blnSeleccionManual = True
        'eEstado = Estado.Navegar
        'If blnCobrarVentas Then
        '    oVista.PoblarListView(Me.ListViewCobranza, oDBVen, "ListViewCobranzaPedidos", " AND Visita.ClienteClave='" & oCliente.ClienteClave & "' ")
        'Else
        '    oVista.PoblarListView(Me.ListViewCobranza, oDBVen, "ListViewCobranza", " AND Visita.ClienteClave='" & oCliente.ClienteClave & "' ")
        'End If

        'blnSeleccionManual = False
        Return True
    End Function

    Private Function Validar() As Boolean
        Try
            Dim i As Integer
            With C1FlexGridCobranzaPagos
                For i = 1 To .Rows.Count - 1
                    If Not RenglonVacio(i) Then
                        If .Item(i, "TipoPago") Is Nothing Then
                            MsgBox(oVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", .Cols("TipoPago").Caption))
                            .Row = i
                            .Col = .Cols("TipoPago").Index
                            Return False
                        End If

                        If .Item(i, "TipoPago") = "" Then
                            MsgBox(oVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", .Cols("TipoPago").Caption))
                            .Row = i
                            .Col = .Cols("TipoPago").Index
                            Return False
                        End If

                        If .Item(i, "Importe") Is Nothing Then
                            MsgBox(oVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", .Cols("Importe").Caption))
                            Return False
                        End If

                        If Not IsNumeric(.Item(i, "Importe")) Then
                            MsgBox(oVista.BuscarMensaje("MsgBox", "E0041"))
                            Return False
                        End If

                        If .Item(i, "Importe") <= 0 Then
                            MsgBox(oVista.BuscarMensaje("MsgBox", "E0041"))
                            Return False
                        End If

                        If IsNumeric(.Item(i, "TipoPago")) AndAlso ValorReferencia.RecuperaGrupo("PAGO", .Item(i, "TipoPago")).ToUpper <> "E" Then
                            If .Item(i, "TipoBanco") Is Nothing OrElse IsDBNull(.Item(i, "TipoBanco")) OrElse .Item(i, "TipoBanco") = "" Then
                                .Row = i
                                .Col = .Cols("TipoBanco").Index
                                MsgBox(oVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", .Cols("TipoBanco").Caption))
                                Return False
                            End If
                            If .Item(i, "Referencia") = "" Then
                                .Row = i
                                .Col = .Cols("Referencia").Index
                                MsgBox(oVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", .Cols("Referencia").Caption))
                                Return False
                            End If
                        Else
                            .Item(i, "TipoBanco") = Nothing
                            .Item(i, "Referencia") = Nothing

                        End If

                        If blnClientePagos Then
                            'If IsNumeric(.Item(i, "TipoPago")) AndAlso ValorReferencia.RecuperaGrupo("PAGO", .Item(i, "TipoPago")).ToUpper <> "E" Then
                            '    If dtClientePagos.Select("Tipo=" & .Item(i, "TipoPago") & " AND TipoBanco=" & .Item(i, "TipoBanco")).Length <= 0 Then
                            '        MsgBox(oVista.BuscarMensaje("MsgBox", "E0060"))
                            '        Return False
                            '    End If
                            'End If
                        End If
                    End If
                Next
            End With

            'Validar que este dado de alta al menos 1 detalle

            Dim iCant As Integer = 0
            For i = 1 To C1FlexGridCobranzaPagos.Rows.Count - 1
                If Not RenglonVacio(i) Then
                    iCant += 1
                End If
            Next

            If iCant <= 0 Then
                MsgBox(oVista.BuscarMensaje("MsgBox", "E0053"))
                Return False
            End If

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Enum eStatusAbono
        Nuevo = 1
        Existente = 2
    End Enum

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        bIniciando = True
        If Not Me.HaySeleccion(Me.ListViewCobranza) Then
            MsgBox(oVista.BuscarMensaje("MsgBox", "E0039"), MsgBoxStyle.Information)
        Else
            EliminarCargo = True
            Me.ConfigurarGrid()
            Me.ConfigurarGridSaldos()
            Me.CargosAplicados()
            Me.LlenarGrid()

        End If

        bIniciando = False

    End Sub

    Private Sub TextBoxCor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles TextBoxFechaFactura.KeyPress, TextBoxFolio.KeyPress, TextBoxSaldoFactura.KeyPress
        bHuboCambios = True
    End Sub

    Private Sub DateTimePickerFechaPromesa_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        bHuboCambios = True
    End Sub

    Private Sub C1FlexGridCobranzaPagos_SetupEditor(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles C1FlexGridCobranzaPagos.SetupEditor
        With C1FlexGridCobranzaPagos
            If e.Col = 4 AndAlso TypeOf .Editor Is TextBox Then
                Dim tb As TextBox = .Editor
                tb.MaxLength = 30
            End If
        End With

    End Sub
End Class