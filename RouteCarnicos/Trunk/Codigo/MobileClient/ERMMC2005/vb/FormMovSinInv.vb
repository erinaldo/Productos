Imports System.Data.SqlServerCe

Public Class FormMovSinInv

    Private Enum TipoEstado
        Navegando = 1
        Creando
        Modificando
        Cancelando
    End Enum

    Private Enum TipoMovSinInv
        SinVisita = 1
        EnVisita
    End Enum

    Private oModul As Modulos.GrupoModuloMovDetalle
    Private _vista As Vista
    Private _visita As Visita
    'Private TransProdId As String
    Private _transProd As TransProd
    Private numFolio As String
    Private blnSeleccionManual As Boolean = False
    Private _cliente As Cliente
    Private eEstado As TipoEstado
    Private bHuboCambios As Boolean = False

    Private bLector As Boolean = False
#If MOD_TERM <> "PALM" Then
    Private WithEvents bScanner As New HANDHELD.CScanner
#End If

    Private TipMSI As TipoMovSinInv

#Region "Lectura producto"

    Private Sub ActivarScanner()
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
        If bLector Then

            Try
                bLector = False
                bScanner.Terminate_Scanner()
            Catch ex As Exception
                bLector = True
                MsgBox("Error while stopping the scanner:" & ex.Message, MsgBoxStyle.Critical)
            End Try

        End If
#End If
    End Sub
    Private Sub TextBoxCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxCodigo.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                e.Handled = True
                BuscarCodigoBarras()
            Case Microsoft.VisualBasic.ChrW(Keys.Escape)
                e.Handled = True
                Deshacer()
        End Select
        Me.bHuboCambios = True
    End Sub
    'Private Sub FormActivos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    '    ActivarScanner()
    'End Sub

    'Private Sub FormActivos_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
    '    DesactivarScanner()
    'End Sub

#If MOD_TERM <> "PALM" Then
    Private Sub bScanner_Data_Scanned(ByVal Data As String) Handles bScanner.Data_Scanned
        Me.TextBoxCodigo.Text = Data
        BuscarCodigoBarras()
    End Sub
#End If

    Private Sub BuscarCodigoBarras()
        If TextBoxCodigo.Text.Trim <> String.Empty Then
            Dim oProducto As New Producto()
            Dim sProductoClave As String = oProducto.BuscarCodigoBarras(Me.TextBoxCodigo.Text)
            oProducto = Nothing
            If sProductoClave <> String.Empty Then
                PedirProductoCantidad(0, sProductoClave)
                PoblarGrid()
            Else
                MsgBox(_vista.BuscarMensaje("MsgBox", "MDB042301"), MsgBoxStyle.Exclamation)
                Me.TextBoxCodigo.SelectionStart = 0
                Me.TextBoxCodigo.SelectionLength = Len(Me.TextBoxCodigo.Text)
                Me.TextBoxCodigo.Focus()
            End If
        End If
        Me.TextBoxCodigo.Text = String.Empty
    End Sub

#End Region


    Public Property Transaccion() As SqlCeTransaction
        Get
            Return oDBVen.Transaccion
        End Get
        Set(ByVal Value As SqlCeTransaction)
            oDBVen.Transaccion = Value
        End Set
    End Property

    Private Sub ButtonRegresar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ButtonCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Public Sub Captura(ByVal modulo As Modulos.GrupoModuloMovDetalle)
        oModul = modulo

        Me.ShowDialog()
    End Sub

    Private Sub ButtonContinuar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        If (ListViewMovSinInv.SelectedIndices.Count > 0) Then
            eEstado = TipoEstado.Modificando
        Else
            eEstado = TipoEstado.Creando
        End If
        Cargar()
        Me.TextBoxProducto.Focus()
        Me.bHuboCambios = False
    End Sub

    Private Sub Cargar()
        Dim transProdId As String = ""
        If (oDBVen.oConexion.State = ConnectionState.Closed) Then
            oDBVen.oConexion.Open()
            oDBVen.Transaccion = oDBVen.oConexion.BeginTransaction()
        ElseIf oDBVen.Transaccion Is Nothing Then
            oDBVen.Transaccion = oDBVen.oConexion.BeginTransaction()

        End If
        _transProd = New TransProd()
        If (eEstado = TipoEstado.Creando) Then
            Folio.ObtenerTransProdId(transProdId)
            numFolio = Folio.Obtener(oModul.ModuloMovDetalleClave)
            If numFolio = "" Then
                If oDBVen.oConexion.State <> ConnectionState.Closed Then
                    Try
                        oDBVen.Transaccion.Rollback()
                    Catch ex As Exception
                    End Try
                    oDBVen.oConexion.Close()
                End If
                Exit Sub
            End If
            _transProd.TransProdId = transProdId
            Me.GuardarEncabezado()
        Else
            transProdId = ListViewMovSinInv.Items(ListViewMovSinInv.SelectedIndices(0)).SubItems(3).Text
            numFolio = oDBVen.EjecutarCmdScalarStrSQL("SELECT Folio from TransProd Where transProdId = '" + transProdId + "'")
            _transProd.TransProdId = transProdId
        End If

        _transProd.ModuloMovDetalle = oModul
        If TipMSI = TipoMovSinInv.EnVisita Then
            _transProd.ClienteActual = _cliente
            _transProd.ListasPrecios = New ListasPreciosCliente
            If Not _transProd.ListasPrecios.Recuperar(_cliente, oModul) Then
                Exit Sub
            End If
        End If
        PoblarGrid()
        If (eEstado <> TipoEstado.Cancelando) Then
            ActivarScanner()
            ButtonBuscarProducto.Enabled = True
            TextBoxCodigo.Enabled = True
            TextBoxProducto.Enabled = True

        Else
            ButtonBuscarProducto.Enabled = False
            TextBoxCodigo.Enabled = False
            TextBoxProducto.Enabled = False
        End If
        PanelLista.Visible = False
        PanelDetalle.Visible = True
        Me.TextBoxCodigo.Text = ""
        Me.TextBoxProducto.Text = ""
    End Sub

    Private Function GuardarEncabezado() As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        Try
            ' Buscar el TransProdId, para ver si ya existia
            Dim DataTableTrans As DataTable
            DataTableTrans = oDBVen.RealizarConsultaSQL("SELECT TransProdId FROM TransProd WHERE TransProdId='" & _transProd.TransProdId & "'", "TransProd")
            If DataTableTrans.Rows.Count > 0 Then
                ' Ya existe, actualizar

                Dim totaltmp As Single = 0
                Dim impTmp As Single = 0
                Dim subttmp As Single = 0
                If (TipMSI = TipoMovSinInv.EnVisita) Then
                    'dim aFila as System.Collections.Generic.Dictionary
                    Dim aObj As Object = oDBVen.EjecutarCmdScalarObjSQL("SELECT sum(total) from TransProdDetalle where transprodid = '" & _transProd.TransProdId & "'")
                    If ((Not IsNothing(aObj)) And (Not IsDBNull(aObj))) Then
                        totaltmp = Convert.ToSingle(aObj)
                    End If
                    aObj = oDBVen.EjecutarCmdScalarObjSQL("SELECT sum(impuesto) from TransProdDetalle where transprodid = '" & _transProd.TransProdId & "'")
                    If ((Not IsNothing(aObj)) And (Not IsDBNull(aObj))) Then
                        impTmp = Convert.ToSingle(aObj)
                    End If
                    aObj = oDBVen.EjecutarCmdScalarObjSQL("SELECT sum(subtotal) from TransProdDetalle where transprodid = '" & _transProd.TransProdId & "'")
                    If ((Not IsNothing(aObj)) And (Not IsDBNull(aObj))) Then
                        subttmp = Convert.ToSingle(aObj)
                    End If
                End If
                sComandoSQL.Append("UPDATE TransProd SET ")
                sComandoSQL.Append("Folio='" & numFolio & "',")
                sComandoSQL.Append("PCEModuloMovDetClave='" & oModul.ModuloMovDetalleClave & "',")
                If (TipMSI = TipoMovSinInv.EnVisita) Then
                    If _transProd.ListasPrecios.ListasPrecios.Count > 0 Then
                        sComandoSQL.Append("PCEPrecioClave='" & _transProd.ListasPrecios.ListasPrecios.Values(0).PrecioClave & "',")
                    End If
                    'sComandoSQL.Append("PCEEsquemaID='" & _transProd.EsquemaIdListaPrecios & "',")
                    sComandoSQL.Append("subtotal=" & subttmp.ToString() & ",")
                    sComandoSQL.Append("impuesto=" & impTmp.ToString() & ",")
                    sComandoSQL.Append("Total=" & totaltmp.ToString() & ",")
                    sComandoSQL.Append("ClienteClave='" & _cliente.ClienteClave & "',")
                End If
                sComandoSQL.Append("TipoFase=" & ServicesCentral.TiposFasesPedidos.Captura & ",")
                sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",")
                sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 ")
                sComandoSQL.Append("WHERE TransProdId='" & _transProd.TransProdId & "'")
            Else
                ' No existe, crear
                sComandoSQL.Append("INSERT INTO TransProd (TransProdID,VisitaClave,DiaClave,VisitaClave1,DiaClave1,PCEModuloMovDetClave, Folio, Tipo,  TipoFase, TipoMovimiento, FechaCaptura, FechaHoraAlta,Total, Notas, MFechaHora, MUsuarioID) VALUES (")
                sComandoSQL.Append("'" & _transProd.TransProdId & "',")
                If (TipMSI = TipoMovSinInv.EnVisita) Then
                    sComandoSQL.Append("'" & _visita.VisitaClave & "',")
                Else
                    sComandoSQL.Append("null,")
                End If
                sComandoSQL.Append("'" & oDia.DiaActual & "',")
                If ((TipMSI = TipoMovSinInv.EnVisita) And (oModul.TipoModulo = ServicesCentral.TiposModulos.Distribucion)) Then
                    sComandoSQL.Append("'" & _visita.VisitaClave & "',")
                    sComandoSQL.Append("'" & oDia.DiaActual & "',")
                Else
                    sComandoSQL.Append("null,")
                    sComandoSQL.Append("null,")
                End If
                sComandoSQL.Append("'" & oModul.ModuloMovDetalleClave & "',")
                sComandoSQL.Append("'" & numFolio & "',")
                sComandoSQL.Append(oModul.TipoTransProd & ",")
                sComandoSQL.Append(ServicesCentral.TiposFasesPedidos.Captura & ",")
                sComandoSQL.Append(oModul.TipoMovimiento & ",")
                sComandoSQL.Append(UniFechaSQL(PrimeraHora(Now)) & ",")
                sComandoSQL.Append(UniFechaSQL(Now) & ",")
                sComandoSQL.Append("0,")
                sComandoSQL.Append("'',")
                sComandoSQL.Append(UniFechaSQL(Now) & ",")
                sComandoSQL.Append("'" & oVendedor.UsuarioId & "'")
                sComandoSQL.Append(")")
                Folio.Confirmar(oModul.ModuloMovDetalleClave)
            End If
            DataTableTrans.Dispose()
            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        End Try
    End Function

    Private Sub GuardarDetallePP(ByRef refparoFormPedirProducto As FormPedirProducto)
        Dim sComandoSQL As New System.Text.StringBuilder
        Dim blnNuevo As Boolean
        Try
            If refparoFormPedirProducto.Partida = 0 Then
                ' Es una nueva partida, obtenerla
                If Not Folio.ObtenerTransProdPartida(refparoFormPedirProducto.TransProdId, refparoFormPedirProducto.Producto.ProductoClave, refparoFormPedirProducto.Partida) Then
                    Exit Try
                End If
                blnNuevo = True
            Else
                blnNuevo = False
            End If
            Dim refProducto As FormPedirProducto.ItemUnidad
            Dim nPrecio As Single = 0
            Dim dCantidad As Decimal
            Dim nImpuesto As Single = 0
            Dim nSubTotal As Single = 0
            Dim nTotal As Single = 0
            ' Obtener los productos a actualizar

            _transProd.EsquemaIdListaPrecios = refparoFormPedirProducto.EsquemasID
            Dim oTransProdDetalle As New TransProdDetalle(_transProd.TransProdId, refparoFormPedirProducto.Producto.ProductoClave, refparoFormPedirProducto.Partida)
            Dim impuest As New Impuesto()
            If (TipMSI = TipoMovSinInv.EnVisita) Then
                oTransProdDetalle.ObtenerListaImpuestos(impuest, _cliente.TipoImpuesto)

            End If

            Dim i As Int16 = 0
            For Each refProducto In refparoFormPedirProducto.PanelUnidades.Controls
                With refProducto
                    i += 1
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
                            If (TipMSI = TipoMovSinInv.EnVisita) Then
                                oTransProdDetalle.TipoUnidad = .TipoUnidad
                                If (oTransProdDetalle.ObtenerPrecio(refparoFormPedirProducto.ListasPrecios)) Then
                                    If Not IsNothing(oTransProdDetalle.PrecioSinFactor) Then
                                        oTransProdDetalle.Precio = oTransProdDetalle.PrecioSinFactor.Precio
                                        'No funciona porque hay que adaptarlo a recibir Cantidad1
                                        'nSubTotal = (((oTransProdDetalle.PrecioSinFactor.Factor * dCantidad) + (oTransProdDetalle.PrecioSinFactor.Factor1 * Cantidad1)) * oTransProdDetalle.Precio)
                                    End If

                                    nImpuesto = impuest.Calcular(oTransProdDetalle.LImpuestos, nSubTotal, oTransProdDetalle.Precio)
                                    nTotal = nSubTotal + nImpuesto
                                Else
                                    MsgBox(_vista.BuscarMensaje("MsgBox", "MDB042302"), MsgBoxStyle.Information)
                                    Exit For
                                End If
                            End If

                            If .TransProdDetalleID = "" Then
                                ' Obtener un nuevo folio
                                .TransProdDetalleID = oApp.KEYGEN(i)
                                ' Crear la cadena para insertar el valor
                                sComandoSQL.Append("INSERT INTO TransProdDetalle (TransProdID, TransProdDetalleID, ProductoClave, TipoUnidad, Partida, Cantidad, Precio, Impuesto, Subtotal, Total, MFechaHora, MUsuarioID) VALUES (")
                                sComandoSQL.Append("'" & refparoFormPedirProducto.TransProdId & "',")
                                sComandoSQL.Append("'" & .TransProdDetalleID & "',")
                                sComandoSQL.Append("'" & refparoFormPedirProducto.Producto.ProductoClave & "',")
                                sComandoSQL.Append(.TipoUnidad & ",") ' TipoUnidad
                                sComandoSQL.Append(refparoFormPedirProducto.Partida & ",") ' Partida
                                sComandoSQL.Append(dCantidad & ",") ' Cantidad
                                sComandoSQL.Append(nPrecio & ",") ' Precio
                                sComandoSQL.Append(nImpuesto & ",") ' Impuesto
                                sComandoSQL.Append(nSubTotal & ",") ' Subtotal
                                sComandoSQL.Append(nTotal & ",")   ' Total
                                sComandoSQL.Append(UniFechaSQL(Now) & ",")
                                sComandoSQL.Append("'" & oVendedor.UsuarioId & "')")
                            Else
                                ' Actualizar el registro
                                sComandoSQL.Append("UPDATE TransProdDetalle SET ")
                                sComandoSQL.Append("DescuentoClave=NULL,")
                                sComandoSQL.Append("Cantidad=" & dCantidad & ",")
                                sComandoSQL.Append("Precio=" & nPrecio & ",")
                                sComandoSQL.Append("Impuesto = " & nImpuesto & ",")
                                sComandoSQL.Append("Subtotal=" & nSubTotal & ",")
                                sComandoSQL.Append("Total=" & nTotal & ",")
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
                        If (TipMSI = TipoMovSinInv.EnVisita) Then
                            impuest.GuardarDetalle(refparoFormPedirProducto.TransProdId, refProducto.TransProdDetalleID, oTransProdDetalle.LImpuestos)
                        End If
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Information, "GuardarProducto")
                End Try
            Next
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarProducto")
        End Try
        sComandoSQL = Nothing
    End Sub

    Private Sub PoblarListViewProductos(ByRef refparoFormPedirProducto As FormPedirProducto, ByVal aListaEsquemas As ArrayList)
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
            .Cols(0).Caption = _vista.BuscarMensaje("MsgBox", "MDBClave")
            .Cols(1).Caption = _vista.BuscarMensaje("MsgBox", "MDBNombre")
            .Cols(0).Width = 100
            .Cols(1).Width = 280
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .ExtendLastCol = True
            .Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .AutoResize = True
        End With
    End Sub

    Private Sub ButtonBuscarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBuscarProducto.Click
        If TextBoxProducto.Text <> "" Then
            Dim iTipoClave, iEspacios As Integer
            iTipoClave = oConHist.Campos("TipoClaveProducto")
            iEspacios = oConHist.Campos("DigitoClaveProd")
            'If MobileClient.Producto.VerificarTipoClaveProducto(iTipoClave, iEspacios) Then
            If iTipoClave = 2 Then
                Dim sProdClave As String = TextBoxProducto.Text
                If sProdClave.Length < iEspacios Then
                    sProdClave = sProdClave.PadLeft(iEspacios, "0")
                    TextBoxProducto.Text = sProdClave
                End If
            End If
            'End If
            If MobileClient.Producto.ExisteProducto(TextBoxProducto.Text) Then
                PedirProductoCantidad(0, TextBoxProducto.Text)
                PoblarGrid()
            Else
                MsgBox(_vista.BuscarMensaje("MsgBox", "E0005"), MsgBoxStyle.Exclamation)
                TextBoxProducto.SelectionStart = 0
                TextBoxProducto.SelectionLength = Len(TextBoxProducto.Text)
                TextBoxProducto.Focus()
            End If
        Else
            PedirProductoCantidad(0, TextBoxProducto.Text)
            PoblarGrid()
        End If
    End Sub

    Private Sub PedirProductoCantidad(ByVal partida As Integer, ByVal productoclave As String)
        Using frmProd As New FormPedirProducto

            With frmProd
                .TransProdId = _transProd.TransProdId
                .FolioActual = numFolio
                .TipoTransProd = oModul.TipoTransProd
                .TipoMovimiento = oModul.TipoMovimiento
                .TipoIndice = oModul.TipoModuloMovDetalle

                If TipMSI = TipoMovSinInv.EnVisita Then
                    .ClienteActual = _cliente
                    .VisitaActual = _visita.VisitaClave
                    .TipoMovimiento = ServicesCentral.TiposMovimientos.Salida
                    .ListasPrecios = _transProd.ListasPrecios
                End If

                .ModuloMovDetalle = oModul

                .Partida = partida

                AddHandler .GuardarDetalle, AddressOf GuardarDetallePP
                AddHandler .PoblarListaProductos, AddressOf PoblarListViewProductos

                Dim producto As New Producto()
                producto.ProductoClave = productoclave
                .Producto = producto

                If productoclave <> "" Then
                    .PermitirConsultarProductos = False
                End If

                .MostrarExistencia = False

            End With

            DesactivarScanner()
            frmProd.ShowDialog()
            TextBoxProducto.Text = ""
            ActivarScanner()
        End Using
    End Sub

    Private Sub PoblarGrid()
        fgDetalles.Rows.Count = 1
        Dim strSQL As String = ""
        strSQL += "SELECT TransProdDetalle.Partida,Producto.ProductoClave, "
        strSQL += "Producto.Nombre,TransProdDetalle.Cantidad,TransProdDetalle.TipoUnidad,"
        strSQL += "TransProdDetalle.SubTotal,TransProdDetalle.Impuesto,TransProdDetalle.Total "
        strSQL += "FROM TransProdDetalle "
        strSQL += "INNER JOIN Producto ON TransProdDetalle.ProductoClave = Producto.ProductoClave "
        strSQL += "INNER JOIN Transprod ON TransProd.TransProdId = TransProdDetalle.TransProdId "
        strSQL += "WHERE TransProdDetalle.TransProdId='" & _transProd.TransProdId & "' "
        'If (TipMSI = TipoMovSinInv.EnVisita) Then
        '    strSQL += " AND TransProd.VisitaClave ='" & _visita.VisitaClave & "' "
        'Else
        '    strSQL += " AND TransProd.DiaClave ='" & _visita.DiaClave & "' "
        '    strSQL += " AND TransProd.VisitaClave is null "
        'End If
        strSQL += "ORDER BY TransProdDetalle.Partida, Producto.ProductoClave "
        Using dt As DataTable = oDBVen.RealizarConsultaSQL(strSQL, "Cargas")
            ' If oModul.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.MovSinInvSinVis Then
            'dt = oDBVen.RealizarConsultaSQL("SELECT TransProdDetalle.Partida,Producto.ProductoClave, Producto.Nombre,TransProdDetalle.Cantidad,TransProdDetalle.TipoUnidad FROM TransProdDetalle INNER JOIN Producto ON TransProdDetalle.ProductoClave = Producto.ProductoClave WHERE TransProdDetalle.TransProdId='" & TransProdId & "' ORDER BY TransProdDetalle.Partida, Producto.ProductoClave ", "Cargas")
            Dim sPartida As String = ""
            fgDetalles.Redraw = False
            Dim r As C1.Win.C1FlexGrid.Row
            Dim sumSubtotal As Decimal
            Dim sumImpuesto As Decimal
            Dim sumTotal As Decimal
            Dim sumGTotal As Decimal = 0
            Dim contPartes As Integer = 0
            For Each dr As DataRow In dt.Rows
                If sPartida <> dr("Partida").ToString Then
                    sPartida = dr("Partida").ToString
                    r = fgDetalles.Rows.Add()
                    r.IsNode = True
                    r.Node.Level = 0
                    With fgDetalles
                        .Item(r.Index, 0) = dr("Partida")
                        .Item(r.Index, 1) = dr("ProductoClave")
                        .Item(r.Index, 2) = dr("Nombre")

                    End With
                    sumGTotal += sumTotal
                    sumSubtotal = 0
                    sumImpuesto = 0
                    sumTotal = 0
                    contPartes += 1
                End If
                Dim r2 As C1.Win.C1FlexGrid.Row = fgDetalles.Rows.Add()
                r2.IsNode = True
                r2.Node.Level = 1
                With fgDetalles
                    .Item(r2.Index, 0) = ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad"))
                    .Item(r2.Index, 1) = dr("Cantidad")
                End With
                If (TipMSI = TipoMovSinInv.EnVisita) Then
                    sumSubtotal += dr("SubTotal")
                    sumImpuesto += dr("Impuesto")
                    sumTotal += dr("Total")
                    fgDetalles.Item(r.Index, 3) = Format(sumSubtotal, oApp.FormatoDinero)
                    fgDetalles.Item(r.Index, 4) = Format(sumImpuesto, oApp.FormatoDinero)
                    fgDetalles.Item(r.Index, 5) = Format(sumTotal, oApp.FormatoDinero)
                End If

            Next
            sumGTotal += sumTotal
            'End If
            If (TipMSI = TipoMovSinInv.EnVisita) Then
                LabelTotalProductos.Text = contPartes.ToString() & " " & _vista.BuscarMensaje("MsgBox", "MDBProductos")
                LabelTotal.Text = Format(sumGTotal, oApp.FormatoDinero)
                If _transProd.ListasPrecios.ListasPrecios.Count > 0 Then
                    Me.LabelListaPrecios.Text = _transProd.ListasPrecios.ListasPrecios.Values(0).PrecioClave & " - " & _transProd.ListasPrecios.ListasPrecios.Values(0).Nombre
                End If
            End If
        End Using
        strSQL = Nothing
        fgDetalles.Redraw = True
        bHuboCambios = True
    End Sub

    Private Sub ButtonRegDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegDet.Click
        If (eEstado = TipoEstado.Cancelando) Then
            PanelLista.Visible = True
            PanelDetalle.Visible = False
        Else
            Deshacer()
        End If
        If PanelLista.Visible Then
            If ListViewMovSinInv.Items.Count = 0 Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub HabilitarBotones(ByVal bHabilitar As Boolean)
        Me.ButtonContDet.Enabled = bHabilitar
        Me.ButtonRegDet.Enabled = bHabilitar
    End Sub

    Private Sub AceptarCambios()
        If Validar() Then
            If (GuardarEncabezado()) Then
                HabilitarBotones(False)

                If (oDBVen.oConexion.State <> ConnectionState.Closed) Then
                    Try
                        oDBVen.Transaccion.Commit()
                        If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
                        Me.Transaccion = Nothing
                    Catch ex As Exception
                    End Try
                    oDBVen.oConexion.Close()
                End If

                If oVendedor.motconfiguracion.MensajeImpresion Then
                    If MsgBox(_vista.BuscarMensaje("MsgBox", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                        If (TipMSI = TipoMovSinInv.EnVisita) Then
                            ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, _transProd.TransProdId, ServicesCentral.TiposTransProd.MovSinInvEV, ServicesCentral.TiposTransProd.MovSinInvEV, _cliente, _visita.VisitaClave)
                        Else
                            ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.SinVisita, _transProd.TransProdId, ServicesCentral.TiposTransProd.MovSinInvSV, ServicesCentral.TiposTransProd.MovSinInvSV)
                        End If
                    End If
                End If

                HabilitarBotones(True)

                PanelLista.Visible = True
                PanelDetalle.Visible = False
                DesactivarScanner()
                Vista()
            End If
        End If
    End Sub

    Private Function Validar() As Boolean
        If (fgDetalles.Rows.Count > 1) Then
            Return True
        Else
            MsgBox(_vista.BuscarMensaje("MsgBox", "MDBAsignarProducto"), MsgBoxStyle.Information)
        End If
        Return False
    End Function

    Private Sub Deshacer()
        If bHuboCambios = True Then
            If MsgBox(_vista.BuscarMensaje("MsgBox", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation) = MsgBoxResult.No Then
                Exit Sub




            End If
        End If

        If oDBVen.oConexion.State <> ConnectionState.Closed Then
            Try
                oDBVen.Transaccion.Rollback()
            Catch ex As Exception
            End Try
            oDBVen.oConexion.Close()
        End If
        DesactivarScanner()
        PanelLista.Visible = True
        PanelDetalle.Visible = False

    End Sub


    Private Sub ButtonContDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContDet.Click
        If (eEstado = TipoEstado.Cancelando) Then
            Try

                oDBVen.EjecutarComandoSQL("DELETE FROM transProdDetalle where transProdid = '" + _transProd.TransProdId + "'")
                oDBVen.EjecutarComandoSQL("DELETE FROM TPDImpuesto where transProdid = '" + _transProd.TransProdId + "'")
                oDBVen.EjecutarComandoSQL("DELETE FROM transProd where transProdid = '" + _transProd.TransProdId + "'")
                Vista()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "BorrarMovimiento")
            End Try
            If MsgBox(_vista.BuscarMensaje("MsgBox", "P0001"), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If (oDBVen.oConexion.State <> ConnectionState.Closed) Then
                    Try
                        oDBVen.Transaccion.Commit()
                        If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
                        Me.Transaccion = Nothing
                    Catch ex As Exception
                    End Try
                    oDBVen.oConexion.Close()
                End If
                PanelLista.Visible = True
                PanelDetalle.Visible = False
                Vista()
            End If
            If ListViewMovSinInv.Items.Count = 0 Then
                Me.Close()
            End If
        Else
            AceptarCambios()
        End If

    End Sub

    Private Sub FormCargasDescargas_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
        Me.Transaccion = Nothing
    End Sub

    Private Sub FormMovSinInv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not MobileClient.Vista.Buscar("FormMovSinInv", _vista) Then
            Exit Sub
        End If

        PanelLista.Visible = True
        PanelDetalle.Visible = False
        _vista.CrearListView(ListViewMovSinInv, "ListViewMovSinInv")
        _vista.ColocarEtiquetasForma(Me)
        _vista.ColocarEtiquetasMenuEmergente(Me.ContextMenu1)
        ConfiguraGrid()
        Vista()
        If ListViewMovSinInv.Items.Count = 0 Then
            eEstado = TipoEstado.Creando
            Cargar()
        End If
        Me.TextBoxProducto.Focus()
        Me.bHuboCambios = False
    End Sub

    Private Sub Vista()
        If (TipMSI = TipoMovSinInv.SinVisita) Then
            _vista.PoblarListView(ListViewMovSinInv, oDBVen, "ListViewMovSinInv", " AND DiaClave = '" + oDia.DiaActual + "' AND VisitaClave is null")
        Else
            _vista.PoblarListView(ListViewMovSinInv, oDBVen, "ListViewMovSinInv", " AND VisitaClave = '" + _visita.VisitaClave + "' ")
        End If

    End Sub

    Private Sub ConfiguraGrid()
        With fgDetalles
            .Redraw = False
            Dim f As Drawing.Font = .Font
            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = IIf(TipMSI = TipoMovSinInv.EnVisita, 6, 3)
            .Cols(0).Caption = _vista.BuscarMensaje("MsgBox", "Partida")
            .Cols(1).Caption = _vista.BuscarMensaje("MsgBox", "PROProductoClave")
            .Cols(2).Caption = _vista.BuscarMensaje("MsgBox", "PRONombre")
            If (TipMSI = TipoMovSinInv.EnVisita) Then
                .Cols(3).Caption = _vista.BuscarMensaje("MsgBox", "TRPSubTotal")
                .Cols(4).Caption = _vista.BuscarMensaje("MsgBox", "TRPImpuesto")
                .Cols(5).Caption = _vista.BuscarMensaje("MsgBox", "TRPTotal")
            End If
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

    Private Sub ListViewCargasDescargas_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs)

    End Sub

    Private Sub ListViewCargasDescargas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ListViewMovSinInv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewMovSinInv.SelectedIndexChanged
        If blnSeleccionManual Then Exit Sub
        If ListViewMovSinInv.SelectedIndices.Count <= 0 Then Exit Sub
        blnSeleccionManual = True
        MarcarElemento(ListViewMovSinInv, CheckState.Checked, ListViewMovSinInv.SelectedIndices(0))
        blnSeleccionManual = False
    End Sub

    Private Sub LimpiarChecks()
        If ListViewMovSinInv.Items.Count > 0 Then

            For i As Integer = 0 To ListViewMovSinInv.Items.Count - 1
                ListViewMovSinInv.Items(i).Selected = False
                ListViewMovSinInv.Items(i).Checked = False
            Next
        End If
    End Sub

    Private Sub ListViewMovSinInv_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewMovSinInv.ItemCheck
        If blnSeleccionManual Then Exit Sub
        blnSeleccionManual = True
        MarcarElemento(ListViewMovSinInv, e.NewValue, e.Index)
        blnSeleccionManual = False
        If ListViewMovSinInv.SelectedIndices.Count <= 0 Then Exit Sub
        If e.NewValue = CheckState.Unchecked Then
            blnSeleccionManual = True
            ListViewMovSinInv.Items(ListViewMovSinInv.SelectedIndices(0)).Selected = False
            blnSeleccionManual = False
        End If

    End Sub

    Private Sub ContextMenu1_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MenuItemModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MenuItemEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ContextMenu1_Popup_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenu1.Popup
        'If fgDetalles.Rows.Count <= 1 OrElse fgDetalles.Rows(fgDetalles.Row).Node.Level > 0 Then
        '    ContextMenu1.MenuItems.Clear()
        'Else
        '    If (eEstado <> TipoEstado.Cancelando) Then
        '        If Not ContextMenu1.MenuItems.Contains(Me.MenuItemModificar) Then ContextMenu1.MenuItems.Add(Me.MenuItemModificar)
        '        If Not ContextMenu1.MenuItems.Contains(Me.MenuItemEliminar) Then ContextMenu1.MenuItems.Add(Me.MenuItemEliminar)
        '    Else
        '        ContextMenu1.MenuItems.Clear()
        '    End If
        'End If
        Me.ContextMenu1.MenuItems.Clear()
        If fgDetalles.Rows.Count <= 1 OrElse fgDetalles.Rows(fgDetalles.Row).Node.Level > 0 OrElse (eEstado = TipoEstado.Cancelando) Then
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

    Private Sub MenuItemEliminar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemEliminar.Click
        Try
            If fgDetalles.Rows.Count <= 1 Then Exit Sub
            If fgDetalles.Rows(fgDetalles.Row).Node.Level > 0 Then Exit Sub
            Dim i As Integer, s As String, tpd As String
            s = "SELECT TransProdDetalleId FROM TransprodDetalle WHERE TransProdId='" & _transProd.TransProdId & "' and partida=" & fgDetalles.GetData(fgDetalles.Row, 0) & " and productoclave='" & fgDetalles.GetData(fgDetalles.Row, 1) & "'"
            tpd = oDBVen.EjecutarCmdScalarStrSQL(s)
            i = 0
            If (tpd <> "") Then

                's = "DELETE FROM transproddetalle where transprodid='" & _transProd.TransProdId & "' and partida=" & fgDetalles.GetData(fgDetalles.Row, 0) & " and productoclave='" & fgDetalles.GetData(fgDetalles.Row, 1) & "'"
                'i = oDBVen.EjecutarComandoSQL(s)
                's = "DELETE FROM TPDImpuesto where transprodid='" & _transProd.TransProdId & "' and partida=" & fgDetalles.GetData(fgDetalles.Row, 0) & " and productoclave='" & fgDetalles.GetData(fgDetalles.Row, 1) & "'"
                'i = oDBVen.EjecutarComandoSQL(s)
                s = "DELETE FROM transproddetalle WHERE TransProdDetalleId='" & tpd & "' AND TransProdId='" & _transProd.TransProdId & "'"
                i = oDBVen.EjecutarComandoSQL(s)
                s = "DELETE FROM TPDImpuesto WHERE TransProdDetalleId='" & tpd & "' AND TransProdId='" & _transProd.TransProdId & "'"
                i = oDBVen.EjecutarComandoSQL(s)
            End If
            PoblarGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MenuItemModificar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemModificar.Click
        If fgDetalles.Rows.Count <= 1 Then Exit Sub
        If fgDetalles.Rows(fgDetalles.Row).Node.Level > 0 Then Exit Sub
        PedirProductoCantidad(fgDetalles.GetData(fgDetalles.Row, 0), fgDetalles.GetData(fgDetalles.Row, 1))
        PoblarGrid()
    End Sub

    Public Sub New(ByVal vis As Visita)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        If IsNothing(vis) Then
            TipMSI = TipoMovSinInv.SinVisita
        Else
            _cliente = vis.ClienteActual
            _visita = vis
            TipMSI = TipoMovSinInv.EnVisita
        End If

        If g_SO = SO.WindowsCE Then
            Call InTheHand.Windows.Forms.ContextMenuHelper.HookAllControls(Me.Controls)
        End If
    End Sub

    Private Sub ButtonEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEliminar.Click
        With ListViewMovSinInv

            If (.SelectedIndices.Count > 0) Then
                Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select enviado from transprod where transprodid='" & ListViewMovSinInv.Items(ListViewMovSinInv.SelectedIndices(0)).SubItems(3).Text & "'", "Consulta")
                If Not IsDBNull(Dt.Rows(0)("enviado")) AndAlso Dt.Rows(0)("enviado") Then
                    MsgBox(_vista.BuscarMensaje("MsgBox", "E0596"), MsgBoxStyle.Information)
                Else

                    If (.Items(.SelectedIndices(0)).Checked) Then
                        eEstado = TipoEstado.Cancelando
                        Cargar()

                    End If


                End If
                Dt.Dispose()
            Else
                MsgBox(_vista.BuscarMensaje("MsgBox", "E0046"), MsgBoxStyle.Information)
            End If

        End With

    End Sub

    Private Sub fgDetalles_KeyDown_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles fgDetalles.KeyDown
        Select Case e.KeyCode
            Case Keys.Return
                If fgDetalles.Rows.Count <= 1 Then Exit Sub
                If fgDetalles.Rows(fgDetalles.Row).Node.Level > 0 Then Exit Sub
                PedirProductoCantidad(fgDetalles.GetData(fgDetalles.Row, 0), fgDetalles.GetData(fgDetalles.Row, 1))
                PoblarGrid()
        End Select
    End Sub

    Private Sub TextBoxProducto_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxProducto.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Enter)
                If TextBoxProducto.Text <> "" Then
                    Dim iTipoClave, iEspacios As Integer
                    iTipoClave = oConHist.Campos("TipoClaveProducto")
                    iEspacios = oConHist.Campos("DigitoClaveProd")
                    'If MobileClient.Producto.VerificarTipoClaveProducto(iTipoClave, iEspacios) Then
                    If iTipoClave = 2 Then
                        Dim sProdClave As String = TextBoxProducto.Text
                        If sProdClave.Length < iEspacios Then
                            sProdClave = sProdClave.PadLeft(iEspacios, "0")
                            TextBoxProducto.Text = sProdClave
                        End If
                    End If
                    'End If
                    If MobileClient.Producto.ExisteProducto(TextBoxProducto.Text) Then
                        PedirProductoCantidad(0, TextBoxProducto.Text)
                        PoblarGrid()
                    Else
                        MsgBox(_vista.BuscarMensaje("MsgBox", "E0005"), MsgBoxStyle.Exclamation)
                        TextBoxProducto.SelectionStart = 0
                        TextBoxProducto.SelectionLength = Len(TextBoxProducto.Text)
                        TextBoxProducto.Focus()
                    End If
                Else
                    PedirProductoCantidad(0, TextBoxProducto.Text)
                    PoblarGrid()
                End If
        End Select
        Me.TextBoxProducto.Focus()
        Me.bHuboCambios = True
    End Sub

    Private Sub MenuItemRegresar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        If (PanelDetalle.Visible) Then
            If (eEstado = TipoEstado.Cancelando) Then
                PanelLista.Visible = True
                PanelDetalle.Visible = False
            Else
                Deshacer()
            End If
            If ListViewMovSinInv.Items.Count = 0 Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub ContextMenu2_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenu2.Popup
        MostrarContext()

    End Sub
    Private Sub MostrarContext()
        DesactivarScanner()
        ContextMenu1.Show(Me, Control.MousePosition)
        ActivarScanner()
    End Sub

End Class