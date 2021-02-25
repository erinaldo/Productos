Public Class FormSurtirPromocionDetalle
    Enum ModoApertura
        Crear = 1
        Consultar = 2
        Cancelar = 3
    End Enum

#Region "VARIABLES"
    Private sTransProdId As String = String.Empty
    Private oVista As Vista
    'Private sClienteClave As String = String.Empty
    Private oCliente As Cliente
    Private sVisitaClave As String = String.Empty
    Private oMMDA As Modulos.GrupoModuloMovDetalle
    Private oTransProd As TransProd

    Private bHayCambios As Boolean = False
    Private nSurtirAnterior As Integer
    Private bCargando As Boolean
    Private tModoApertura As ModoApertura
    Private htFase As Hashtable
    Private bEscalado As Boolean = False
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

#Region "METODOS"

    Public Sub Crear()
        Dim nTopInicial As Integer
        tModoApertura = ModoApertura.Crear
        oTransProd = New TransProd
        PanelFecha.Top = PanelConsulta.Top
        nTopInicial = fgPromociones.Top
        PanelConsulta.Visible = False

        Me.ShowDialog()
    End Sub

    Public Sub Consultar()
        tModoApertura = ModoApertura.Consultar
        oTransProd = New TransProd
        ConfigurarForma()
        Me.ShowDialog()
    End Sub

    Public Sub Cancelar()
        tModoApertura = ModoApertura.Cancelar
        oTransProd = New TransProd
        ConfigurarForma()
        Me.ShowDialog()
    End Sub

    Public Sub ConfigurarForma()
        Cursor.Current = Cursors.WaitCursor
        bCargando = True
        If oDBVen.oConexion.State = ConnectionState.Closed Then
            oDBVen.oConexion.Open()
        End If
        Transaccion = oDBVen.oConexion.BeginTransaction
        If Not Vista.Buscar("FormSurtirPromocionDetalle", oVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        oVista.ColocarEtiquetasForma(Me)
        oTransProd.Reiniciar(True)
        oTransProd.ModuloMovDetalle = oMMDA
        htFase = New Hashtable
        Select Case tModoApertura
            Case ModoApertura.Crear
                TextBoxFecha.Text = Today.ToString("dd/MM/yyyy")
                ConfiguraGridCrear()
                PoblarGridCrear()
            Case ModoApertura.Consultar, ModoApertura.Cancelar
                oTransProd.TransProdId = sTransProdId
                oTransProd.Recuperar()
                TextBoxFolio.Text = oTransProd.FolioActual
                TextBoxFase.Text = ValorReferencia.BuscarEquivalente("TRPFASE", oTransProd.TipoFase)
                If oTransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Cancelado Then
                    TextBoxFecha.Text = oTransProd.FechaCancelacion.ToString("dd/MM/yyyy")
                Else
                    TextBoxFecha.Text = oTransProd.FechaSurtido.ToString("dd/MM/yyyy")
                End If
                LabelFase.Text = oVista.BuscarMensaje("MsgBox", "XFase")
                LabelFolio.Text = oVista.BuscarMensaje("MsgBox", "XFolio")
                ConfiguraGridConsultar()
                PoblarGridConsultar()
        End Select
        bCargando = False
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub PoblarGridCrear()
        fgPromociones.Rows.Count = 2
        Dim dt As DataTable
        'PRGId, ProductoClave, Nombre, FolioPedido, PromocionClave, TipoUnidad, Cantidad, Saldo, TipoFasePRP
        dt = RecuperarProductoNegado()
        Dim sPartida As String = ""
        Dim sProducto As String = ""
        Dim nExistencia As Integer = 0
        Dim nExistenciaUnidad As Integer = 0

        fgPromociones.Redraw = False
        Dim r As C1.Win.C1FlexGrid.Row
        For Each dr As DataRow In dt.Rows
            If sPartida <> dr("ProductoClave").ToString & "-" & dr("FolioPedido").ToString & "-" & dr("PromocionClave").ToString Then
                sPartida = dr("ProductoClave").ToString & "-" & dr("FolioPedido").ToString & "-" & dr("PromocionClave").ToString
                If sProducto <> dr("ProductoClave").ToString Then
                    sProducto = dr("ProductoClave").ToString
                    nExistencia = RecuperarExistenciaProducto(sProducto)
                End If
                r = fgPromociones.Rows.Add
                r.IsNode = True
                r.Node.Level = 0
                With fgPromociones
                    .Item(r.Index, 0) = False
                    .Item(r.Index, 1) = dr("ProductoClave")
                    .Item(r.Index, 2) = dr("Nombre")
                    .Item(r.Index, 3) = dr("FolioPedido")
                    .Item(r.Index, 4) = dr("PromocionClave")
                End With
            End If
            Dim r2 As C1.Win.C1FlexGrid.Row = fgPromociones.Rows.Add
            r2.IsNode = True
            r2.Node.Level = 1
            With fgPromociones
                nExistenciaUnidad = nExistencia \ dr("Factor")
                .Item(r2.Index, 0) = False
                .Item(r2.Index, 1) = dr("TipoUnidad").ToString 'ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad"))
                .Item(r2.Index, 2) = dr("Cantidad")
                .Item(r2.Index, 3) = dr("Saldo")
                If nExistenciaUnidad >= dr("Saldo") Then
                    .Item(r2.Index, 4) = dr("Saldo")
                Else
                    .Item(r2.Index, 4) = nExistenciaUnidad
                End If
                .Item(r2.Index, 5) = nExistenciaUnidad
                .Item(r2.Index, 6) = dr("TipoFasePRP").ToString 'ValorReferencia.BuscarEquivalente("PRGFASE", dr("TipoFasePRP"))
                .Item(r2.Index, 7) = dr("PRGId")
                .Item(r2.Index, 8) = dr("PendienteEntrega")
                .Item(r2.Index, 9) = dr("Factor")
                Dim aFase As New ArrayList
                aFase.Add(dr("TipoFasePRP"))
                aFase.Add(False)
                htFase.Add(dr("PRGId").ToString, aFase)
            End With
        Next
        dt.Dispose()
        For nRow As Integer = 2 To fgPromociones.Rows.Count - 2
            If fgPromociones.Rows(nRow).Node.Level = 1 Then
                Dim sValor As String = fgPromociones.GetDataDisplay(nRow, 6)
                fgPromociones.Item(nRow, 6) = Nothing
                fgPromociones.Item(nRow, 6) = sValor
            End If
        Next
        fgPromociones.Redraw = True
    End Sub

    Private Sub ConfiguraGridCrear()
        With fgPromociones
            .Redraw = False
            .AllowEditing = True
            Dim f As Drawing.Font = .Font

            Dim ValoresUnidad As New Hashtable
            Dim aValores As ArrayList = ValorReferencia.RecuperarLista("UNIDADV")
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    ValoresUnidad.Add(refDesc.Id, refDesc.Cadena)
                Next
            End If
            aValores = Nothing

            Dim ValoresFase As New Hashtable
            aValores = ValorReferencia.RecuperarLista("PRGFASE")
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    ValoresFase.Add(refDesc.Id, refDesc.Cadena)
                Next
            End If
            aValores = Nothing

            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 10

            .Cols(0).DataType = System.Type.GetType("System.Boolean")
            .Cols(0).AllowEditing = True
            .Cols(0).Width = 50

            .Cols(1).Caption = oVista.BuscarMensaje("MsgBox", "XClave")
            .Cols(1).DataMap = ValoresUnidad
            .Cols(1).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Cols(1).AllowEditing = False

            .Cols(2).Caption = oVista.BuscarMensaje("MsgBox", "XNombre")
            .Cols(2).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
            .Cols(2).AllowEditing = False

            .Cols(3).Caption = oVista.BuscarMensaje("MsgBox", "XPedido")
            .Cols(3).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
            .Cols(3).AllowEditing = False

            .Cols(4).Caption = oVista.BuscarMensaje("MsgBox", "XPromocion")
            .Cols(4).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
            .Cols(4).AllowEditing = True

            .Cols(5).AllowEditing = False
            .Cols(5).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter

            .Cols(6).DataMap = ValoresFase
            .Cols(6).AllowEditing = oVendedor.MantenerPrm
            .Cols(6).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter

            .Cols(7).Visible = False
            .Cols(8).Visible = False
            .Cols(9).Visible = False

            .Rows.Count = 2
            .Rows.Fixed = 2
            With fgPromociones
                .Item(1, 1) = " - " & oVista.BuscarMensaje("MsgBox", "XUnidad")
                .Item(1, 2) = oVista.BuscarMensaje("MsgBox", "XCantidad")
                .Item(1, 3) = oVista.BuscarMensaje("MsgBox", "XSaldo")
                .Item(1, 4) = oVista.BuscarMensaje("MsgBox", "XSurtir")
                .Item(1, 5) = oVista.BuscarMensaje("MsgBox", "MDBExistencia")
                .Item(1, 6) = oVista.BuscarMensaje("MsgBox", "XFase")
            End With

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

    Private Sub PoblarGridConsultar()
        fgPromociones.Rows.Count = 1
        Dim dt As DataTable
        Dim sPartida As String = ""
        Dim sProducto As String = ""

        dt = RecuperarDetalleSurtido()
        fgPromociones.Redraw = False
        Dim r As C1.Win.C1FlexGrid.Row
        For Each dr As DataRow In dt.Rows
            If sPartida <> dr("FolioPedido").ToString & "-" & dr("PromocionClave").ToString & "-" & dr("ProductoClave").ToString Then
                sPartida = dr("FolioPedido").ToString & "-" & dr("PromocionClave").ToString & "-" & dr("ProductoClave").ToString
                r = fgPromociones.Rows.Add
                r.IsNode = True
                r.Node.Level = 0
                With fgPromociones
                    .Item(r.Index, 0) = dr("FolioPedido")
                    .Item(r.Index, 1) = dr("PromocionClave")
                    .Item(r.Index, 2) = dr("ProductoClave")
                    .Item(r.Index, 3) = dr("Nombre")
                End With
            End If
            Dim r2 As C1.Win.C1FlexGrid.Row = fgPromociones.Rows.Add
            r2.IsNode = True
            r2.Node.Level = 1
            With fgPromociones
                .Item(r2.Index, 0) = ValorReferencia.BuscarEquivalente("UNIDADV", dr("TipoUnidad"))
                .Item(r2.Index, 1) = dr("Cantidad")
            End With
        Next
        dt.Dispose()
        fgPromociones.Redraw = True
    End Sub

    Private Sub ConfiguraGridConsultar()
        With fgPromociones
            .Redraw = False
            .AllowEditing = False
            Dim f As Drawing.Font = .Font

            .Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            .Styles.Normal.Trimming = Drawing.StringTrimming.EllipsisCharacter
            .Cols.Fixed = 0
            .Cols.Count = 4

            .Cols(0).Caption = oVista.BuscarMensaje("MsgBox", "XPedido")
            .Cols(1).Caption = oVista.BuscarMensaje("MsgBox", "XPromocion")
            .Cols(2).Caption = oVista.BuscarMensaje("MsgBox", "XClave")
            .Cols(3).Caption = oVista.BuscarMensaje("MsgBox", "XNombre")

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

    Private Sub SeleccionarHijos(ByVal bSeleccionar As Boolean)
        Dim oNodoHijo As C1.Win.C1FlexGrid.Node
        If fgPromociones.Rows(fgPromociones.Row).Node.Children > 0 Then
            oNodoHijo = fgPromociones.Rows(fgPromociones.Row).Node.GetNode(C1.Win.C1FlexGrid.NodeTypeEnum.FirstChild)
            oNodoHijo.Data = bSeleccionar
            Dim oNodoHermano As C1.Win.C1FlexGrid.Node
            oNodoHermano = oNodoHijo.GetNode(C1.Win.C1FlexGrid.NodeTypeEnum.NextSibling)
            While Not oNodoHermano Is Nothing
                oNodoHijo = oNodoHermano
                oNodoHijo.Data = bSeleccionar
                oNodoHermano = oNodoHijo.GetNode(C1.Win.C1FlexGrid.NodeTypeEnum.NextSibling)
            End While
        End If
    End Sub

    Private Function GuardarSurtido() As Boolean
        Try
            Dim sProductoClave As String
            Dim sPromocionClave As String
            Dim sPRGId As String
            Dim nTipoUnidad As Integer
            Dim dCantidad As Decimal
            Dim dSaldo As Decimal
            Dim dSurtir As Decimal
            Dim nPartida As Integer = 1
            Dim bPendienteEntrega As Boolean
            Dim bTransProdNuevo As Boolean = True
            Dim dExistencia As Decimal
            Dim dExistenciaUnidad As Decimal
            Dim nFactor As Integer
            Dim sMensaje As String = ""
            For nRow As Integer = 2 To fgPromociones.Rows.Count - 1
                If fgPromociones.Rows(nRow).Node.Level = 0 Then
                    sProductoClave = fgPromociones.GetData(nRow, 1)
                    sPromocionClave = fgPromociones.GetData(nRow, 4)
                Else
                    If fgPromociones.GetData(nRow, 0) Then
                        sPRGId = fgPromociones.GetData(nRow, 7)
                        Dim aFase As ArrayList = htFase(sPRGId)

                        dCantidad = fgPromociones.GetData(nRow, 2)
                        dSaldo = fgPromociones.GetData(nRow, 3)
                        nTipoUnidad = fgPromociones.GetData(nRow, 1)
                        dSurtir = fgPromociones.GetData(nRow, 4)
                        nFactor = fgPromociones.GetData(nRow, 9)

                        Inventario.ValidarExistenciaDisponibleDec(sProductoClave, nTipoUnidad, dSurtir, dExistencia, "")
                        dExistenciaUnidad = dExistencia \ nFactor

                        If aFase(0) = 1 And dSurtir > 0 Then
                            If aFase(1) Then 'Se modificó
                                ActualizarFase(sPRGId, aFase(0))
                            End If

                            If dExistenciaUnidad > 0 Then
                                If dExistenciaUnidad < dSurtir Then
                                    dSurtir = dExistenciaUnidad
                                    sMensaje &= "-" & oVista.BuscarMensaje("MsgBox", "E0591").Replace("$0$", dExistenciaUnidad).Replace("$1$", sProductoClave)
                                End If

                                If bTransProdNuevo Then
                                    If Not CrearTransProd() Then
                                        Return False
                                    End If
                                    bTransProdNuevo = False
                                End If

                                If CrearDetalle(sProductoClave, sPromocionClave, sPRGId, nTipoUnidad, dSurtir, nPartida) Then
                                    If Not ActualizarSaldo(sPRGId, -dSurtir) Then
                                        Return False
                                    End If
                                Else
                                    Return False
                                End If
                                nPartida += 1
                            Else
                                sMensaje &= "-" & oVista.BuscarMensaje("MsgBox", "E0029").Replace(".", "") & " " & sProductoClave & vbCr
                            End If

                        ElseIf aFase(1) And dSurtir = 0 Then 'Se modificó y surtir = 0 
                            ActualizarFase(sPRGId, aFase(0))
                            'ElseIf nSurtir = 0 Then
                            '    sMensaje &= "-" & oVista.BuscarMensaje("MsgBox", "E0029").Replace(".", "") & " " & sProductoClave & vbCr
                            'ElseIf nExistenciaUnidad < nSurtir Then
                            '    sMensaje &= "-" & oVista.BuscarMensaje("MsgBox", "E0591").Replace("$0$", nExistenciaUnidad).Replace("$1$", sProductoClave)
                        ElseIf aFase(0) = 1 And fgPromociones.GetData(nRow, 5) = 0 Then
                            bPendienteEntrega = fgPromociones.GetData(nRow, 8)
                            If oVendedor.MantenerPrm And Not bPendienteEntrega Then
                                If dCantidad = dSaldo Then
                                    ActualizarFase(sPRGId, 0) 'Cancelado
                                Else
                                    ActualizarFase(sPRGId, 3) 'Terminado
                                End If
                            End If
                        End If

                    End If
                End If
            Next
            If sMensaje <> String.Empty Then
                MsgBox(sMensaje, MsgBoxStyle.Information)
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Transaccion.Rollback()
            Return False
        End Try
    End Function

    Private Function CrearTransProd() As Boolean
        oTransProd.TransProdId = oApp.KEYGEN(1)
        oTransProd.VisitaActual = sVisitaClave
        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
            oTransProd.VisitaClave1 = sVisitaClave
            oTransProd.DiaClave1 = oDia.DiaActual
        End If
        oTransProd.Tipo = ServicesCentral.TiposTransProd.SurtirProductoPromocion
        oTransProd.FolioActual = Folio.Obtener(, ServicesCentral.TiposModulosMovDet.SurtirProductoPromocion)
        oTransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Surtido
        oTransProd.FechaCaptura = oDia.FechaCaptura
        oTransProd.FechaHoraAlta = Now
        oTransProd.FechaSurtido = Now
        oTransProd.SubTotal = 0
        oTransProd.Impuesto = 0
        oTransProd.Total = 0
        oTransProd.Saldo = 0
        Dim b As Boolean = oTransProd.Actualizar()
        If b Then
            Dim DataTableTrans As DataTable
            DataTableTrans = oDBVen.RealizarConsultaSQL("SELECT TransProdId FROM TransProd WHERE TransProdId='" & sTransProdId & "'", "TransProd")
            If DataTableTrans.Rows.Count = 0 Then
                Folio.Confirmar(, ServicesCentral.TiposModulosMovDet.SurtirProductoPromocion)
            End If
            DataTableTrans.Dispose()
        End If
        Return b
    End Function

    Private Function CrearDetalle(ByVal parsProductoClave As String, ByVal parsPromocionClave As String, ByVal parsPRGId As String, ByVal pariTipoUnidad As Integer, ByVal pariSurtir As Integer, ByVal pariPartida As Integer) As Boolean
        Dim oTPD As New TransProdDetalle(oTransProd.TransProdId, parsProductoClave, pariPartida)
        oTPD.PRGId = parsPRGId
        oTPD.TipoUnidad = pariTipoUnidad
        oTPD.Cantidad = pariSurtir
        oTPD.PromocionClave = parsPromocionClave
        Return oTPD.ActualizarPromocion()
    End Function

    Private Function ActualizarSaldo(ByVal parsPRGId As String, ByVal pariCantidad As Integer) As Boolean
        Dim oPRN As New ProductoNegado
        oPRN.PRGId = parsPRGId
        Return oPRN.ActualizarSaldo(pariCantidad)
    End Function

    Private Function ActualizarFase(ByVal parsPRGId As String, ByVal pariFase As Integer) As Boolean
        Dim oPRN As New ProductoNegado
        oPRN.PRGId = parsPRGId
        oPRN.TipoFasePRP = pariFase
        Return oPRN.ActualizarFase
    End Function

    Private Sub CancelarSurtido()
        Try
            Dim dt As DataTable = oTransProd.RecuperarDetalle
            Dim oPRN As New ProductoNegado

            For Each dr As DataRow In dt.Rows
                Inventario.ActualizarInventarioDec(dr("ProductoClave"), dr("TipoUnidad"), dr("Cantidad"), ServicesCentral.TiposTransProd.SurtirProductoPromocion, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId)
                oPRN.PRGId = dr("PRGId")
                oPRN.ActualizarSaldo(dr("Cantidad"))
            Next
            oTransProd.Eliminar()
            Transaccion.Commit()
        Catch ex As Exception
            MsgBox(ex.Message)
            Transaccion.Rollback()
        End Try
    End Sub

#End Region

#Region "FUNCIONES"
    Private Function RecuperarProductoNegado() As DataTable
        Dim sConsulta As String
        Dim dtProducto As DataTable
        sConsulta = "select PRG.PRGId, PRG.ProductoClave, PRO.Nombre, PRG.FolioPedido, PRG.PromocionClave, PRG.TipoUnidad, PRG.Cantidad, PRG.Saldo, PRG.TipoFasePRP, PRD.Factor, PRG.PendienteEntrega "
        sConsulta &= "from ProductoNegado PRG "
        sConsulta &= "inner join Producto PRO on PRG.ProductoClave = PRO.ProductoClave "
        sConsulta &= "inner join ProductoDetalle PRD on PRG.ProductoClave = PRD.ProductoDetClave and PRD.ProductoClave = PRD.ProductoDetClave and PRG.TipoUnidad = PRD.PRUTipoUnidad "
        sConsulta &= "where PRG.Cliente = '" & oCliente.ClienteClave & "' "
        If oVendedor.MantenerPrm Then
            sConsulta &= " and TipoFasePRP <> 2 "
        Else
            sConsulta &= " and TipoFasePRP = 1 "
        End If
        sConsulta &= "order by PRG.ProductoClave, PRG.FolioPedido, PRG.PromocionClave "
        dtProducto = oDBVen.RealizarConsultaSQL(sConsulta, "ProductoNegado")
        Return dtProducto
    End Function

    Private Function RecuperarExistenciaProducto(ByVal sProductoClave As String) As Double
        Dim nExistencia As Double = 0
        nExistencia = oDBVen.EjecutarCmdScalardblSQL("select sum(Disponible-Apartado-NoDisponible-(case When Producto.venta=0 then Inventario.Contenido  Else 0 END)) as Existencia from inventario inner join producto on producto.ProductoClave = Inventario.ProductoClave Where Inventario.ProductoClave = '" & sProductoClave & "'")
        Return nExistencia
    End Function

    Private Function ObtenerFactor() As Integer

    End Function

    Private Function RecuperarDetalleSurtido()
        Dim sConsulta As String
        Dim dtProducto As DataTable
        sConsulta = "select PRG.FolioPedido, TPD.PromocionClave, TPD.ProductoClave, PRO.Nombre, TPD.TipoUnidad, TPD.Cantidad "
        sConsulta &= "from TransProdDetalle TPD "
        sConsulta &= "inner join ProductoNegado PRG on PRG.PRGId = TPD.PRGId "
        sConsulta &= "inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave "
        sConsulta &= "where TPD.TransProdId = '" & oTransProd.TransProdId & "' "
        sConsulta &= "order by PRG.FolioPedido, TPD.PromocionClave, TPD.ProductoClave "
        dtProducto = oDBVen.RealizarConsultaSQL(sConsulta, "Detalle")
        Return dtProducto
    End Function

    Private Function ActualizarPendienteEntrega()
        If oVendedor.MantenerPrm Then

        End If
    End Function
#End Region

#Region "EVENTOS"
    Private Sub FormSurtirPromocionDetalle_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Not Me.fgPromociones Is Nothing Then
            If oVendedor.motconfiguracion.Secuencia Then
                If Not ctrlSeguimiento.Parent Is Nothing Then
                    RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                    RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                    ctrlSeguimiento.QuitarMenuItem(Me.MainMenuPromo)
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

    Private Sub FormSurtirPromocionDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If bCargando Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        If Not bEscalado Then
            [Global].ObtenerFactores(Me)

            If oVendedor.motconfiguracion.Secuencia Then
                ctrlSeguimiento.AgregarControl(Me)
                Me.Panel1.SendToBack()
                ctrlSeguimiento.CrearMenuItem(Me.MainMenuPromo)
                AddHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                AddHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
            End If

            [Global].EscalarFuente(Me)
            [Global].EscalarForma(Me)
            bEscalado = True
        Else
            If oVendedor.motconfiguracion.Secuencia Then
                ctrlSeguimiento.AgregarControl(Me)
                Me.Panel1.SendToBack()
                ctrlSeguimiento.CrearMenuItem(Me.MainMenuPromo)
                AddHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                AddHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
            End If
        End If
        ConfigurarForma()

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

        Cursor.Current = Cursors.Default
        If tModoApertura = ModoApertura.Crear Then
            fgPromociones.Top = PanelFecha.Top + PanelFecha.Size.Height + 12 '30
            fgPromociones.Height = ButtonTerminar.Top - fgPromociones.Top - 8
            If Me.fgPromociones.Rows.Count <= 2 Then
                MsgBox(oVista.BuscarMensaje("MsgBox", "I0161"), MsgBoxStyle.Information)
                Me.Close()
            End If
        End If
        [Global].HabilitarMenuItem(Me.MainMenuPromo, True)
    End Sub

    Private Sub TerminarVisita()
        MenuItemRegresar_Click(Nothing, Nothing)
    End Sub


    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Select Case MsgBox(oVista.BuscarMensaje("MsgBox", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation)
            Case MsgBoxResult.Yes

                Me.Transaccion.Rollback()
                Me.Transaccion.Dispose()
                Me.Close()
            Case MsgBoxResult.No
                Exit Select
        End Select
    End Sub

    Private Sub ButtonTerminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTerminar.Click
        If tModoApertura = ModoApertura.Crear Then
            Dim guardar As Boolean = GuardarSurtido()
            If guardar And oTransProd.TransProdId <> "" Then
                Transaccion.Commit()
                If Not Transaccion Is Nothing Then
                    Transaccion.Dispose()
                    Transaccion = Nothing
                End If
                HabilitarBotones(False)
                If oVendedor.motconfiguracion.MensajeImpresion Then
                    If MsgBox(oVista.BuscarMensaje("MsgBox", "P0103"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                        ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, oTransProd.TransProdId, ServicesCentral.TiposTransProd.SurtirProductoPromocion, ServicesCentral.TiposTransProd.SurtirProductoPromocion, oCliente, sVisitaClave)
                    End If
                End If
                HabilitarBotones(True)
            ElseIf guardar Then
                Transaccion.Commit()
            Else
                Transaccion.Rollback()
            End If

        ElseIf tModoApertura = ModoApertura.Cancelar Then
            CancelarSurtido()
        End If
        If Not Transaccion Is Nothing Then
            Transaccion.Dispose()
            Transaccion = Nothing
        End If
        Me.Close()
    End Sub

    Private Sub HabilitarBotones(ByVal bHabilitar As Boolean)
        Me.ButtonRegresar.Enabled = bHabilitar
        Me.ButtonTerminar.Enabled = bHabilitar
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Select Case MsgBox(oVista.BuscarMensaje("MsgBox", "BP0002"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation)
            Case MsgBoxResult.Yes
                Me.Transaccion.Rollback()
                Me.Transaccion.Dispose()

                Me.Close()
            Case MsgBoxResult.No
                Exit Select
        End Select
    End Sub

    Private Sub fgPromociones_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fgPromociones.AfterEdit
        If e.Row <= 1 Then Exit Sub
        If e.Col = 0 Then
            If fgPromociones.Rows(e.Row).Node.Level = 0 Then
                SeleccionarHijos(fgPromociones.GetData(e.Row, 0))
            End If
        ElseIf e.Col = 4 And fgPromociones.Rows(e.Row).Node.Level = 1 Then
            Dim nSurtir As Integer
            If IsNumeric(fgPromociones.GetData(e.Row, 4)) Then
                Dim dSurtir As Double = Double.Parse(fgPromociones.GetData(e.Row, 4))
                nSurtir = Integer.Parse(Math.Round(dSurtir, 0))
                If nSurtir < 0 Then
                    fgPromociones.Item(e.Row, 4) = nSurtirAnterior
                    e.Cancel = True
                Else
                    If nSurtir > Integer.Parse(fgPromociones.GetData(e.Row, 3)) Then
                        fgPromociones.Item(e.Row, 4) = nSurtirAnterior
                        MsgBox(oVista.BuscarMensaje("MsgBox", "E0038"), MsgBoxStyle.Information)
                        e.Cancel = True
                    ElseIf nSurtir > Integer.Parse(fgPromociones.GetData(e.Row, 5)) Then
                        fgPromociones.Item(e.Row, 4) = nSurtirAnterior
                        MsgBox(oVista.BuscarMensaje("MsgBox", "E0029"), MsgBoxStyle.Information)
                        e.Cancel = True
                    Else
                        fgPromociones.Item(e.Row, 4) = nSurtir
                    End If
                End If
            Else
                fgPromociones.Item(e.Row, 4) = nSurtirAnterior
                e.Cancel = True
            End If
        ElseIf e.Col = 6 And fgPromociones.Rows(e.Row).Node.Level = 1 Then
            Dim sValor As String = fgPromociones.GetDataDisplay(e.Row, e.Col)
            Dim nValor As Integer = fgPromociones.GetData(e.Row, e.Col)
            Dim sLlave As String = fgPromociones.GetData(e.Row, 7) 'PRGId
            Dim aFase As New ArrayList
            fgPromociones.Item(e.Row, e.Col) = Nothing
            fgPromociones.Item(e.Row, e.Col) = sValor
            aFase.Add(nValor)
            aFase.Add(True)
            If htFase.Contains(sLlave) Then
                htFase(sLlave) = aFase
            Else
                htFase.Add(sLlave, aFase)
            End If
        End If
    End Sub

    Private Sub fgPromociones_BeforeEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fgPromociones.BeforeEdit
        If Not bCargando Then
            If e.Col = 4 And fgPromociones.Rows(e.Row).Node.Level = 1 Then 'Surtir
                nSurtirAnterior = 0
                If IsNothing(fgPromociones.GetData(e.Row, 4)) Then Exit Sub
                nSurtirAnterior = Double.Parse(fgPromociones.GetData(e.Row, 4))
            End If
        End If
    End Sub

    Private Sub fgPromociones_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs) Handles fgPromociones.EnterCell
        If Not bCargando Then
            If fgPromociones.Row <= 1 Then Exit Sub
            Dim bHabilitado As Boolean = False
            If fgPromociones.Col = 4 Or fgPromociones.Col = 6 Then
                bHabilitado = (fgPromociones.Rows(fgPromociones.Row).Node.Level = 1)
                If bHabilitado Then
                    fgPromociones.Cols(4).AllowEditing = bHabilitado And fgPromociones.GetData(fgPromociones.Row, 0)
                    fgPromociones.Cols(6).AllowEditing = (bHabilitado And fgPromociones.GetData(fgPromociones.Row, 0) And oVendedor.MantenerPrm And fgPromociones.GetData(fgPromociones.Row, 4) = 0)
                    If fgPromociones.Col = 6 And fgPromociones.Cols(6).AllowEditing Then
                        Dim ValoresFase As New Hashtable
                        Dim aValores As ArrayList
                        Dim aVAVClave As New ArrayList
                        aVAVClave.Add("1") 'Activo
                        If fgPromociones.GetData(fgPromociones.Row, 2) = fgPromociones.GetData(fgPromociones.Row, 3) Then
                            aVAVClave.Add("0") 'Cancelado
                        Else
                            aVAVClave.Add("3") 'Terminado
                        End If
                        aValores = ValorReferencia.RecuperarLista("PRGFASE", aVAVClave)
                        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                            For Each refDesc As ValorReferencia.Descripcion In aValores
                                ValoresFase.Add(refDesc.Id, refDesc.Cadena)
                            Next
                            fgPromociones.Cols(6).DataMap = ValoresFase
                        End If
                        aValores = Nothing
                    End If
                Else
                    fgPromociones.Cols(4).AllowEditing = bHabilitado
                    fgPromociones.Cols(6).AllowEditing = bHabilitado
                End If
            End If
        End If
    End Sub
#End Region

End Class