Public Class MovProducto
    Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto

    Protected oTransProd As TransProd
    Protected sVisitaActual As String
    Protected tTipoAccionDocumento As FormMenuMovProducto.TiposAccionesDocumentos

    Private OrigenAdelante As Boolean = True
    Private TerminarMovProducto As Boolean = False

    Private Property TransProd() As TransProd Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.TransProd
        Get
            Return oTransProd
        End Get
        Set(ByVal Value As TransProd)
            oTransProd = Value
        End Set
    End Property
    Public Property TipoAccionDocumento() As FormMenuMovProducto.TiposAccionesDocumentos
        Get
            Return tTipoAccionDocumento
        End Get
        Set(ByVal Value As FormMenuMovProducto.TiposAccionesDocumentos)
            tTipoAccionDocumento = Value
        End Set
    End Property

    Private Property VisitaActual() As String
        Get
            Return sVisitaActual
        End Get
        Set(ByVal Value As String)
            sVisitaActual = Value
        End Set
    End Property

    Public Sub New()
        TransProd = New TransProd
        Me.TipoAccionDocumento = FormMenuMovProducto.TiposAccionesDocumentos.Ninguna
    End Sub

    Public Function Capturar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.Capturar
        'Try
        Dim sModuloMovDetOriginal As New Modulos.GrupoModuloMovDetalle()
        Dim stipoMovimientos As MobileClient.ServicesCentral.TiposMovimientos
        stipoMovimientos = paroModuloMovDetActual.TipoMovimiento
        sModuloMovDetOriginal.ModuloMovDetalleClave = paroModuloMovDetActual.ModuloMovDetalleClave

        sModuloMovDetOriginal.Recuperar()

        sVisitaActual = parsVisitaClave
        With Me.TransProd
            .TransProdId = ""
            .SubEmpresaActual = SubEmpresa.aSubEmpresa(0)
            .VisitaActual = parsVisitaClave
            .ClienteActual = paroCliente
            .ModuloMovDetalle = paroModuloMovDetActual
            .Tipo = paroModuloMovDetActual.TipoTransProd
            .TipoMovimiento = paroModuloMovDetActual.TipoMovimiento
        End With

        TransProd.ListasPrecios = New ListasPreciosCliente()

        Dim bPrimeraVez As Boolean = True

        While Me.TipoAccionDocumento <> FormMenuMovProducto.TiposAccionesDocumentos.Terminar
            If Me.MostrarFolios(bPrimeraVez) <> FormMenuMovProducto.TiposAccionesDocumentos.Terminar Then
                Select Case Me.TipoAccionDocumento
                    Case FormMenuMovProducto.TiposAccionesDocumentos.Crear, FormMenuMovProducto.TiposAccionesDocumentos.Modificar
                        Me.TransProd.ClienteActual.Recuperar()
                        Me.TransProd.VisitaActual = parsVisitaClave
                        Me.TransProd.DiaClave1 = Nothing
                        Me.TransProd.VisitaClave1 = Nothing
                        Me.TransProd.ModuloMovDetalle.ModuloMovDetalleClave = sModuloMovDetOriginal.ModuloMovDetalleClave
                        Me.TransProd.TipoMovimiento = stipoMovimientos
                        Me.EditarDocumento()

                        'If Not ExistenMovimientos() Then
                        Me.TipoAccionDocumento = FormMenuMovProducto.TiposAccionesDocumentos.Terminar
                        'End If
                    Case FormMenuMovProducto.TiposAccionesDocumentos.SurtirPedido
                        Me.ConsultarDocumento()
                        If oVendedor.motconfiguracion.Secuencia AndAlso (ctrlSeguimiento.TerminarVisita Or ctrlSeguimiento.MasInfo) Then
                            Me.TipoAccionDocumento = FormMenuMovProducto.TiposAccionesDocumentos.Terminar
                        End If
                    Case FormMenuMovProducto.TiposAccionesDocumentos.CancelarPedido
                        If (oDBVen.oConexion.State = ConnectionState.Closed) Then
                            oDBVen.oConexion.Open()
                            oDBVen.Transaccion = oDBVen.oConexion.BeginTransaction()
                        End If
                        Try
                            Me.TransProd.EliminarDescuentosVendedor()
                            Me.TransProd.Actualizar()

                            MovProducto.RestarPuntos(Me.TransProd, 2)
                            Cuotas.RestarCuotasXProducto(oTransProd)
                            Cuotas.CalcularCuotasxEfectivo(oTransProd, True)

                            If Me.oTransProd.TipoDoc <> 3 Then
                                MobileClient.TransProd.CancelarPedido(Me.TransProd.TransProdId, paroModuloMovDetActual.TipoModuloMovDetalle, Me.TransProd.ClienteActual, parsVisitaClave)
                                If Not IsNothing(Me.TransProd.FacturaId) AndAlso Not IsDBNull(Me.TransProd.FacturaId) AndAlso Me.TransProd.FacturaId <> "" Then
                                    oDBVen.EjecutarComandoSQL("Update TransProd set TipoFase = 0, FechaCancelacion = getdate(), MFechaHora = getdate(), MUsuarioID='" & oVendedor.UsuarioId & "' where TransProdId='" & Me.TransProd.FacturaId & "'")
                                End If
                            Else
                                MobileClient.TransProd.DevolucionTotal(Me.TransProd, Me.TransProd.ClienteActual, parsVisitaClave)
                            End If

                            oDBVen.EjecutarComandoSQL("Update TRPPedimento set Cancelado = 1, Enviado = 0  ,MFechaHora = getdate(), MUsuarioID ='" & oVendedor.UsuarioId & "' where TransProdID ='" & Me.TransProd.TransProdId & "'")

                            If Me.oTransProd.ModuloMovDetalle.TipoModuloMovDetalle <> ServicesCentral.TiposModulosMovDet.MovSinInvConVis Then
                                If oConHist.Campos("CobrarVentas") And Me.TransProd.TipoFase <> ServicesCentral.TiposFasesPedidos.Captura Then
                                    Me.TransProd.RecalcularTotales()
                                    Me.TransProd.ClienteActual.ActualizarSaldo(-(Me.TransProd.Total * Me.TransProd.TipoCambio))
                                ElseIf oConHist.Campos("CobrarVentas") AndAlso Me.TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Captura AndAlso (Me.TransProd.VisitaActual <> Me.VisitaActual And Me.TransProd.DiaClave <> oDia.DiaActual) Then
                                    Me.TransProd.RecalcularTotales()
                                    Me.TransProd.ClienteActual.ActualizarSaldo(-(Me.TransProd.Total * Me.TransProd.TipoCambio))
                                End If
                            End If
                            If (oDBVen.oConexion.State <> ConnectionState.Closed) Then
                                Try
                                    oDBVen.Transaccion.Commit()
                                    If Not oDBVen.Transaccion Is Nothing Then oDBVen.Transaccion.Dispose()
                                    oDBVen.Transaccion = Nothing
                                Catch ex As Exception
                                End Try
                                oDBVen.oConexion.Close()
                            End If

                        Catch ex As Exception
                            If (oDBVen.oConexion.State <> ConnectionState.Closed) Then
                                Try
                                    oDBVen.Transaccion.Rollback()
                                    If Not oDBVen.Transaccion Is Nothing Then oDBVen.Transaccion.Dispose()
                                    oDBVen.Transaccion = Nothing
                                Catch ex2 As Exception

                                End Try
                                oDBVen.oConexion.Close()
                            End If
                        End Try
                End Select
            End If

            Me.TransProd.VisitaActual = parsVisitaClave
            Me.TransProd.DiaClave1 = Nothing
            Me.TransProd.VisitaClave1 = Nothing
            Me.TransProd.ModuloMovDetalle.ModuloMovDetalleClave = sModuloMovDetOriginal.ModuloMovDetalleClave
        End While

        sModuloMovDetOriginal = Nothing

        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical)
        'End Try
    End Function

    Private Function ExistenMovimientos() As Boolean
        Dim sConsulta As String
        Dim nMovs As Integer
        sConsulta = "select count(*) as Movs from TransProd "
        sConsulta &= "where DiaClave='" & oDia.DiaActual & "' and VisitaClave='" & Me.TransProd.VisitaActual & "' "
        sConsulta &= "and PCEModuloMovDetClave='" & Me.TransProd.ModuloMovDetalle.ModuloMovDetalleClave & "' and Tipo=" & Me.TransProd.Tipo
        nMovs = oDBVen.RealizarScalarSQL(sConsulta)
        Return (nMovs > 0)
    End Function

    Private Function ExistenMovimientosRepartoXSurtir() As Boolean
        Dim sConsulta As String
        Dim nMovs As Integer
        sConsulta = "select count(*) as Movs from TransProd t "
        sConsulta &= "inner join visita v on v.visitaclave=t.visitaclave and v.diaclave=t.diaclave "
        sConsulta &= "where v.clienteclave ='" & Me.TransProd.ClienteActual.ClienteClave & "' and tipo=1 and tipofase =1"

        nMovs = oDBVen.RealizarScalarSQL(sConsulta)
        Return (nMovs > 0)
    End Function
    Private Function ExistenMovimientosReparto() As Boolean
        Dim sConsulta As String
        Dim nMovs As Integer
        sConsulta = "select count(*) as Movs from TransProd t "
        sConsulta &= "inner join visita v on v.visitaclave=t.visitaclave and v.diaclave=t.diaclave "
        sConsulta &= "where v.clienteclave ='" & Me.TransProd.ClienteActual.ClienteClave & "' and tipo=1 and tipofase<>2"
        nMovs = oDBVen.RealizarScalarSQL(sConsulta)

        sConsulta = "select count(*) as Movs from TransProd t "
        sConsulta &= "inner join visita v on v.visitaclave=t.visitaclave and v.diaclave=t.diaclave "
        sConsulta &= "where v.clienteclave ='" & Me.TransProd.ClienteActual.ClienteClave & "' and  tipofase=1 and  tipo=1 and visitaclave1='" & Me.TransProd.VisitaActual & "' and diaclave1='" & oDia.DiaActual & "'"

        nMovs += oDBVen.RealizarScalarSQL(sConsulta)

        Return (nMovs > 0)
    End Function

    Private Function MostrarFolios(ByRef bPrimeraVez As Boolean) As FormMenuMovProducto.TiposAccionesDocumentos
        Try
            If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                If ExistenMovimientosRepartoXSurtir() Then
                    bPrimeraVez = False
                    Dim FormMenuMovProducto As New FormMenuMovProducto(Me.TransProd, VisitaActual)
                    FormMenuMovProducto.OrigenAdelante = Me.OrigenAdelante
                    If FormMenuMovProducto.ExistenMovimientos Then
                        FormMenuMovProducto.ShowDialog()
                    End If
                    If Not Me.TerminarMovProducto Then
                        Me.TipoAccionDocumento = FormMenuMovProducto.TipoAccion
                    End If
                    With FormMenuMovProducto
                        .Dispose()
                        FormMenuMovProducto = Nothing
                    End With
                    Return Me.TipoAccionDocumento
                Else
                    If bPrimeraVez Then
                        bPrimeraVez = False
                        If CrearDocumento() Then
                            If MsgBox(gVista.BuscarMensaje("MsgBoxGeneral", "P0086"), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                'If MsgBox("[P0086] No existen pedidos para Reparto ¿Desea generar una venta? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                If ExistenMovimientosReparto() Then
                                    Dim FormMenuMovProducto As New FormMenuMovProducto(Me.TransProd, VisitaActual)
                                    FormMenuMovProducto.OrigenAdelante = Me.OrigenAdelante
                                    If FormMenuMovProducto.ExistenMovimientos Then
                                        FormMenuMovProducto.ShowDialog()
                                    End If
                                    If Not Me.TerminarMovProducto Then
                                        Me.TipoAccionDocumento = FormMenuMovProducto.TipoAccion
                                    End If
                                    With FormMenuMovProducto
                                        .Dispose()
                                        FormMenuMovProducto = Nothing
                                    End With
                                    Return Me.TipoAccionDocumento
                                Else
                                    Dim FormMenuMovProducto As New FormMenuMovProducto(Me.TransProd, VisitaActual)
                                    FormMenuMovProducto.OrigenAdelante = Me.OrigenAdelante
                                    If FormMenuMovProducto.ExistenMovimientos Then
                                        FormMenuMovProducto.ShowDialog()
                                    End If
                                    If Not Me.TerminarMovProducto Then
                                        Me.TipoAccionDocumento = FormMenuMovProducto.TipoAccion
                                    End If
                                    With FormMenuMovProducto
                                        .Dispose()
                                        FormMenuMovProducto = Nothing
                                    End With
                                    Return Me.TipoAccionDocumento
                                End If
                            Else
                                Me.TipoAccionDocumento = FormMenuMovProducto.TiposAccionesDocumentos.Terminar
                                Return Me.TipoAccionDocumento
                            End If

                        End If
                    Else
                        Me.TipoAccionDocumento = FormMenuMovProducto.TiposAccionesDocumentos.Terminar
                        Return Me.TipoAccionDocumento
                    End If
                End If
            Else
                If ExistenMovimientos() Then
                    Dim FormMenuMovProducto As New FormMenuMovProducto(Me.TransProd, VisitaActual)
                    FormMenuMovProducto.OrigenAdelante = Me.OrigenAdelante
                    If FormMenuMovProducto.ExistenMovimientos Then
                        FormMenuMovProducto.ShowDialog()
                    End If
                    If Not Me.TerminarMovProducto Then
                        Me.TipoAccionDocumento = FormMenuMovProducto.TipoAccion
                    End If
                    With FormMenuMovProducto
                        .Dispose()
                        FormMenuMovProducto = Nothing
                    End With
                    Return Me.TipoAccionDocumento
                Else
                    If CrearDocumento() Then
                        Return Me.TipoAccionDocumento
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Private Function CrearDocumento() As Boolean
        Try
            If Not oTransProd.ClienteActual.ExisteFormaVenta Then
                MsgBox(gVista.BuscarMensaje("MsgBoxGeneral", "E0358"), MsgBoxStyle.Information Or MsgBoxStyle.SystemModal, "CrearDocumento")
                Return False
            End If
            ' Nuevo movimiento
            Me.TransProd.Reiniciar(True)
            Select Case Me.TransProd.Tipo
                Case ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposTransProd.MovSinInvEV
                    Me.TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Captura
                    Me.TransProd.TipoPedido = ServicesCentral.TiposPedidos.Normal
            End Select
            FormProcesando.PubSubTitulo(oVendedor.NombreModulo)
            FormProcesando.PubSubInformar(gVista.BuscarMensaje("Procesando", "Creando"), Me.TransProd.ModuloMovDetalle.Nombre)
            Me.TipoAccionDocumento = FormMenuMovProducto.TiposAccionesDocumentos.Crear
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function

    Private Function EditarDocumento() As Boolean
        Try
            If ValidacionVencimientoVenta() Then
                Me.TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Captura
                Dim FormMovProducto As New FormMovProducto(Me.TransProd)
                With FormMovProducto
                    .ShowDialog()
                    TerminarMovProducto = .Terminar
                    If .Terminar Then
                        Me.TipoAccionDocumento = FormMenuMovProducto.TiposAccionesDocumentos.Terminar
                    End If
                    Me.OrigenAdelante = .OrigenAdelante
                    If Not FormMovProducto Is Nothing Then
                        .Dispose()
                        FormMovProducto = Nothing
                    End If
                End With
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Private Function ConsultarDocumento() As Boolean
        Dim FormMovProducto As FormMovProducto
        Try

            Dim blnSurtir As Boolean = True
            If Me.TransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Surtido AndAlso Me.TransProd.VisitaClave1 = "" Then
                blnSurtir = False
            End If
            FormMovProducto = New FormMovProducto(Me.TransProd, blnSurtir, Me.VisitaActual)
            With FormMovProducto
                .ShowDialog()
                TerminarMovProducto = .Terminar
                If .Terminar Then
                    Me.TipoAccionDocumento = FormMenuMovProducto.TiposAccionesDocumentos.Terminar
                End If
                Me.OrigenAdelante = .OrigenAdelante
                If Not FormMovProducto Is Nothing Then
                    .Dispose()
                    FormMovProducto = Nothing
                End If
            End With
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            If Not FormMovProducto Is Nothing Then
                FormMovProducto.Dispose()
                FormMovProducto = Nothing
            End If
        End Try
        Return False
    End Function


    Private Function ValidacionVencimientoVenta() As Boolean
        Dim res As Boolean = True
        If (oConHist.Campos("TipoLimiteCredito") = 2) Then

            If oTransProd.ModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Pedido Then
                If oTransProd.ClienteActual.VencimientoVenta Then
                    Dim valor As Double = 0
                    Dim tipoMov As String = IIf(CBool(oConHist.Campos("CobrarVentas")), "1", "8")
                    Dim strSQL As String = "select case when sum(saldo) is null then 0 else sum(saldo) end From transprod tr "
                    strSQL &= "inner join visita v on v.visitaclave = TR.visitaclave and v.diaClave = TR.Diaclave "
                    strSQL &= "where tr.FechaCobranza < dateadd(day,(- " & oTransProd.ClienteActual.DiasVencimiento.ToString() & "),getdate()) and "
                    strSQL &= "v.clienteclave = '" & oTransProd.ClienteActual.ClienteClave & "' and "
                    strSQL &= "(tr.tipo =" & tipoMov & ") and tr.VisitaClave <> '" & oTransProd.VisitaActual & "' and tr.TipoFase <>0 "
                    valor = oDBVen.EjecutarCmdScalarObjSQL(strSQL)
                    'TODO: Probar Cambio TipoPago
                    If (Not oTransProd.ClienteActual.ActualizaSaldoCheque) Then
                        Dim aGrupo As New ArrayList()
                        aGrupo.Add("EB")
                        Dim sVarCodigos As String = ValorReferencia.RecuperaVARVGrupoIds("PAGO", aGrupo)
                        If sVarCodigos.Length > 0 Then
                            strSQL = "SELECT case when sum(ad.importe) is null then 0 else sum(ad.importe) end FROM Abntrp at "
                            strSQL &= "inner join abndetalle ad on ad.abnid = at.abnid "
                            strSQL &= "where ad.tipopago in(" & sVarCodigos & ") and at.transprodid in"
                            strSQL &= "(select tr.transprodid From transprod tr "
                            strSQL &= "inner join visita v on v.visitaclave = tr.visitaclave and v.diaclave = tr.diaclave "
                            strSQL &= "where tr.FechaCobranza < dateadd(day,(- " & oTransProd.ClienteActual.DiasVencimiento.ToString() & "),getdate()) and "
                            strSQL &= "v.clienteclave = '" & oTransProd.ClienteActual.ClienteClave & "' "
                            strSQL &= "and  (tr.tipo = " & tipoMov & ") and tr.VisitaClave <> '" & oTransProd.VisitaActual & "' and tr.TipoFase <>0 )"
                            valor += oDBVen.EjecutarCmdScalarObjSQL(strSQL)
                        End If
                    End If

                    If (valor > 0) Then
                        MsgBox(gVista.BuscarMensaje("MsgBoxGeneral", "E0631"), MsgBoxStyle.Information)
                        res = False
                    ElseIf (Not CBool(oConHist.Campos("CobrarVentas"))) Then
                        strSQL = "SELECT count(*) FechaFactura FROM Cliente WHERE ClienteClave = '" & oTransProd.ClienteActual.ClienteClave & "' AND FechaFactura < dateadd(day,(- " & oTransProd.ClienteActual.DiasVencimiento.ToString() & "),getdate())"
                        valor = oDBVen.EjecutarCmdScalarObjSQL(strSQL)
                        If (valor > 0) Then
                            MsgBox(gVista.BuscarMensaje("MsgBoxGeneral", "E0631"), MsgBoxStyle.Information)
                            res = False
                        End If
                    End If
                End If
            End If
        End If
        Return res
    End Function

#Region "Puntos"
    Public Shared Sub AcumularPuntos(ByVal paroTransProd As TransProd, ByVal pariAsignar As Integer)
        If Not paroTransProd.ClienteActual.ConfiguracionPuntos Then Exit Sub
        Dim dtCNP As DataTable = oDBVen.RealizarConsultaSQL("Select * from ConfiguracionPunto inner join CNPDetalleVig on CNPDetalleVig.CNPId = ConfiguracionPunto.CNPId WHERE ConfiguracionPunto.CNPId='" & paroTransProd.ClienteActual.CNPId & "' and (FechaInicial<=" & UniFechaSQL(UltimaHora(Now)) & " and FechaFinal>=" & UniFechaSQL(PrimeraHora(Now)) & ")", "ConfiguracionPuntos")

        If dtCNP.Rows.Count > 0 Then
            If dtCNP.Rows(0)("Asignar") = pariAsignar Then
                Dim nNumVentas As Integer = 1
                If pariAsignar = 1 Then 'Si es facturacion
                    nNumVentas = oDBVen.EjecutarCmdScalarIntSQL("Select count(*) from TransProd where FacturaID='" & paroTransProd.TransProdId & "'")
                End If
                oDBVen.EjecutarComandoSQL("UPDATE Punto Set Venta = Venta+" & nNumVentas & ",Enviado=0,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' where ClienteClave = '" & paroTransProd.ClienteActual.ClienteClave & "'")
                Select Case dtCNP.Rows(0)("Tipo")
                    Case 1
                        Dim dtCNR As DataTable = oDBVen.RealizarConsultaSQL("select CNDRango.* from CNDRango inner join CNPDetalleVig on CNPDetalleVig.CNPId = CNDRango.CNPId and CNPDetalleVig.FechaInicial = CNDRango.FechaInicial where CNDRango.CNPId='" & paroTransProd.ClienteActual.CNPId & "' and  (CNPDetalleVig.FechaInicial<=" & UniFechaSQL(UltimaHora(Now)) & " and CNPDetalleVig.FechaFinal>=" & UniFechaSQL(PrimeraHora(Now)) & ") and (Rango1<=" & paroTransProd.Total & " and Rango2>=" & paroTransProd.Total & ")", "CNDRango")
                        If (dtCNR.Rows.Count > 0) Then
                            oDBVen.EjecutarComandoSQL("Update punto set saldo = saldo + " & dtCNR.Rows(0)("Cantidad") & ",Enviado=0,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' Where ClienteClave ='" & paroTransProd.ClienteActual.ClienteClave & "'")
                        End If
                        dtCNR.Dispose()
                    Case 2
                        Dim nVentas As Integer = PuntosVentasCliente(paroTransProd.ClienteActual.ClienteClave)
                        Dim dtCNR As DataTable = oDBVen.RealizarConsultaSQL("select CNDRango.* from CNDRango inner join CNPDetalleVig on CNPDetalleVig.CNPId = CNDRango.CNPId and CNPDetalleVig.FechaInicial = CNDRango.FechaInicial where CNDRango.CNPId='" & paroTransProd.ClienteActual.CNPId & "' and (CNPDetalleVig.FechaInicial<=" & UniFechaSQL(UltimaHora(Now)) & " and CNPDetalleVig.FechaFinal>=" & UniFechaSQL(PrimeraHora(Now)) & ") and (Rango1<=" & nVentas & " and Rango2>=" & nVentas & ")", "CNDRango")
                        If (dtCNR.Rows.Count > 0) Then
                            oDBVen.EjecutarComandoSQL("Update punto set saldo = saldo + " & dtCNR.Rows(0)("Cantidad") & ", Enviado=0,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' Where ClienteClave ='" & paroTransProd.ClienteActual.ClienteClave & "'")
                        End If
                        dtCNR.Dispose()
                    Case 3
                        Dim ProdCantidad As Integer
                        If pariAsignar = 1 Then
                            ProdCantidad = oDBVen.EjecutarCmdScalarIntSQL("select sum(Cantidad * ProductoDetalle.Factor) from TransProdDetalle inner join TransProd on TransProd.TransProdID = TransProdDetalle.TransProdID inner join ProductoDetalle on ProductoDetalle.ProductoClave = TransProdDetalle.ProductoClave and ProductoDetalle.PRUTipoUnidad = TransProdDetalle.TipoUnidad AND ProductoDetalle.ProductoDetClave = TransProdDetalle.ProductoClave where FacturaID='" & paroTransProd.TransProdId & "' and TransProdDetalle.Promocion=0 ")
                        Else
                            ProdCantidad = oDBVen.EjecutarCmdScalarIntSQL("Select sum(Cantidad * ProductoDetalle.Factor) from TransProdDEtalle inner join ProductoDetalle on ProductoDetalle.ProductoClave = TransProdDetalle.ProductoClave and ProductoDetalle.PRUTipoUnidad = TransProdDetalle.TipoUnidad AND ProductoDetalle.ProductoDetClave = TransProdDetalle.ProductoClave where TransProdId = '" & paroTransProd.TransProdId & "' and TransProdDetalle.Promocion=0 ")
                        End If
                        Dim dtCNR As DataTable = oDBVen.RealizarConsultaSQL("select CNDRango.* from CNDRango inner join CNPDetalleVig on CNPDetalleVig.CNPId = CNDRango.CNPId and CNPDetalleVig.FechaInicial = CNDRango.FechaInicial where CNDRango.CNPId='" & paroTransProd.ClienteActual.CNPId & "' and (CNPDetalleVig.FechaInicial<=" & UniFechaSQL(UltimaHora(Now)) & " and CNPDetalleVig.FechaFinal>=" & UniFechaSQL(PrimeraHora(Now)) & ") and (Rango1<=" & ProdCantidad & " and Rango2>=" & ProdCantidad & ")", "CNDRango")
                        If (dtCNR.Rows.Count > 0) Then
                            oDBVen.EjecutarComandoSQL("Update punto set saldo = saldo + " & dtCNR.Rows(0)("Cantidad") & ",Enviado=0,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' Where ClienteClave ='" & paroTransProd.ClienteActual.ClienteClave & "'")
                        End If
                        dtCNR.Dispose()
                End Select
            End If
        End If
        dtCNP.Dispose()
    End Sub

    Public Shared Sub RestarPuntos(ByVal paroTransProd As TransProd, ByVal pariAsignar As Integer)
        If Not paroTransProd.ClienteActual.ConfiguracionPuntos Then Exit Sub
        Dim dtCNP As DataTable = oDBVen.RealizarConsultaSQL("Select * from ConfiguracionPunto inner join CNPDetalleVig on CNPDetalleVig.CNPId = ConfiguracionPunto.CNPId WHERE ConfiguracionPunto.CNPId='" & paroTransProd.ClienteActual.CNPId & "' and (FechaInicial<=" & UniFechaSQL(UltimaHora(Now)) & " and FechaFinal>=" & UniFechaSQL(PrimeraHora(Now)) & ")", "ConfiguracionPuntos")

        If dtCNP.Rows.Count > 0 Then
            If dtCNP.Rows(0)("Asignar") = pariAsignar Then
                Dim nNumVentas As Integer = 1
                If pariAsignar = 1 Then 'Si es facturacion
                    nNumVentas = oDBVen.EjecutarCmdScalarIntSQL("Select count(*) from TransProd where FacturaID='" & paroTransProd.TransProdId & "'")
                End If
                oDBVen.EjecutarComandoSQL("UPDATE Punto Set Venta = Venta-" & nNumVentas & ",Enviado=0 ,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' where ClienteClave = '" & paroTransProd.ClienteActual.ClienteClave & "'")
                Select Case dtCNP.Rows(0)("Tipo")
                    Case 1
                        Dim dtCNR As DataTable = oDBVen.RealizarConsultaSQL("select CNDRango.* from CNDRango inner join CNPDetalleVig on CNPDetalleVig.CNPId = CNDRango.CNPId and CNPDetalleVig.FechaInicial = CNDRango.FechaInicial where CNDRango.CNPId='" & paroTransProd.ClienteActual.CNPId & "' and (CNPDetalleVig.FechaInicial<=" & UniFechaSQL(UltimaHora(Now)) & " and CNPDetalleVig.FechaFinal>=" & UniFechaSQL(PrimeraHora(Now)) & ") and (Rango1<=" & paroTransProd.Total & " and Rango2>=" & paroTransProd.Total & ")", "CNDRango")
                        If (dtCNR.Rows.Count > 0) Then
                            oDBVen.EjecutarComandoSQL("Update punto set saldo = saldo - " & dtCNR.Rows(0)("Cantidad") & ",Enviado=0,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' Where ClienteClave ='" & paroTransProd.ClienteActual.ClienteClave & "'")
                        End If
                        dtCNR.Dispose()
                    Case 2
                        Dim nVentas As Integer = PuntosVentasCliente(paroTransProd.ClienteActual.ClienteClave)
                        Dim dtCNR As DataTable = oDBVen.RealizarConsultaSQL("select CNDRango.* from CNDRango inner join CNPDetalleVig on CNPDetalleVig.CNPId = CNDRango.CNPId and CNPDetalleVig.FechaInicial = CNDRango.FechaInicial where CNDRango.CNPId='" & paroTransProd.ClienteActual.CNPId & "' and  (CNPDetalleVig.FechaInicial<=" & UniFechaSQL(UltimaHora(Now)) & " and CNPDetalleVig.FechaFinal>=" & UniFechaSQL(PrimeraHora(Now)) & ") and (Rango1<=" & nVentas & " and Rango2>=" & nVentas & ")", "CNDRango")
                        If (dtCNR.Rows.Count > 0) Then
                            oDBVen.EjecutarComandoSQL("Update punto set saldo = saldo - " & dtCNR.Rows(0)("Cantidad") & ",Enviado = 0,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' Where ClienteClave ='" & paroTransProd.ClienteActual.ClienteClave & "'")
                        End If
                        dtCNR.Dispose()
                    Case 3
                        Dim ProdCantidad As Integer
                        If pariAsignar = 1 Then
                            ProdCantidad = oDBVen.EjecutarCmdScalarIntSQL("select sum(Cantidad) from TransProdDetalle inner join TransProd on TransProd.TransProdID = TransProdDetalle.TransProdID where FacturaID='" & paroTransProd.TransProdId & "' and TransProdDetalle.Promocion=0 ")
                        Else
                            ProdCantidad = oDBVen.EjecutarCmdScalarIntSQL("Select sum(Cantidad) from TransProdDEtalle where TransProdId = '" & paroTransProd.TransProdId & "' and TransProdDetalle.Promocion=0")
                        End If
                        Dim dtCNR As DataTable = oDBVen.RealizarConsultaSQL("select CNDRango.* from CNDRango inner join CNPDetalleVig on CNPDetalleVig.CNPId = CNDRango.CNPId and CNPDetalleVig.FechaInicial = CNDRango.FechaInicial where CNDRango.CNPId='" & paroTransProd.ClienteActual.CNPId & "' and (CNPDetalleVig.FechaInicial<=" & UniFechaSQL(UltimaHora(Now)) & " and CNPDetalleVig.FechaFinal>=" & UniFechaSQL(PrimeraHora(Now)) & ") and (Rango1<=" & ProdCantidad & " and Rango2>=" & ProdCantidad & ")", "CNDRango")
                        If (dtCNR.Rows.Count > 0) Then
                            oDBVen.EjecutarComandoSQL("Update punto set saldo = saldo - " & dtCNR.Rows(0)("Cantidad") & ", Enviado = 0,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' Where ClienteClave ='" & paroTransProd.ClienteActual.ClienteClave & "'")
                        End If
                        dtCNR.Dispose()
                End Select
            End If
        End If
        dtCNP.Dispose()
    End Sub

    Public Shared Function PuntosVentasCliente(ByVal parsClienteClave As String)
        Dim nPuntos As Integer = 0

        nPuntos = oDBVen.EjecutarCmdScalarIntSQL("Select Venta from Punto where ClienteClave='" & parsClienteClave & "'")

        Return nPuntos
    End Function
#End Region
End Class
