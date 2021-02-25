Imports System.Data.SqlServerCe

Public Class TransProd
    Implements IDisposable

    Protected sTransProdId As String
    Protected sVisitaActual As String
    Protected sVisitaClave1 As String
    Protected sDiaClave1 As String
    Protected sDiaClave As String
    Protected sFolioActual As String
    Protected oCliente As Cliente
    Protected oModuloMovDetalle As Modulos.GrupoModuloMovDetalle
    Protected dFechaCaptura As Date
    Protected dFechaEntrega As Date
    Protected dFechaFacturacion As Date
    Protected dFechaCancelacion As Date
    Protected dFechaSurtido As Date
    Protected dFechaHoraAlta As Date
    Protected dFechaCobranza As Date
    Protected oListasPrecios As ListasPreciosCliente
    Protected oProducto As Producto
    Protected sEsquemaIdListaPrecios As String
    Protected sFacturaId As String
    Protected sClienteClave As String
    Protected sClientePagoId As String
    Protected tTipoPedido As ServicesCentral.TiposPedidos
    Protected tTipoFase As ServicesCentral.TiposFasesPedidos
    Protected tTipo As ServicesCentral.TiposTransProd
    Protected tTipoMovimiento As ServicesCentral.TiposMovimientos
    Protected iTipoMotivo As Integer
    Protected iCFVTipo As Integer
    Protected iDiasCredito As Integer
    Protected nSubTDetalle As Decimal
    Protected nDescVendPor As Decimal
    Protected nDescuentoVendedor As Decimal
    Protected nDescuentoImp As Decimal
    Protected nDescuentoImpuestoCliente As Decimal
    Protected nDescuentoImpuestoVendedor As Decimal
    Protected nTotal As Decimal
    Protected nSaldo As Decimal
    Protected nSubTotal As Decimal
    Protected nImpuesto As Decimal
    Protected bPromocion As Short
    Protected bDescuento As Short
    Protected sMonedaID As String
    Protected dTipoCambio As Decimal
    Protected bTipoTurno As Short
    Protected sNotas As String
    Protected sPLIId As String
    Protected iTipoDoc As Integer
    Protected bEnviado As Boolean
    Protected oSubEmpresaActual As SubEmpresa.DatosEmpresa


    Private Const amp = "&amp;" '&
    Private Const quot = "&quot;" '"
    Private Const lt = "&lt;" '<
    Private Const gt = "&gt;" '>
    Private Const apos = "&#36;" ''

    Public Property TransProdId() As String
        Get
            Return sTransProdId
        End Get
        Set(ByVal Value As String)
            sTransProdId = Value
        End Set
    End Property
    Public Property VisitaActual() As String
        Get
            Return sVisitaActual
        End Get
        Set(ByVal Value As String)
            sVisitaActual = Value
        End Set
    End Property
    Public Property VisitaClave1() As String
        Get
            Return sVisitaClave1
        End Get
        Set(ByVal Value As String)
            sVisitaClave1 = Value
        End Set
    End Property
    Public Property DiaClave1() As String
        Get
            Return sDiaClave1
        End Get
        Set(ByVal Value As String)
            sDiaClave1 = Value
        End Set
    End Property
    Public Property DiaClave() As String
        Get
            Return sDiaClave
        End Get
        Set(ByVal Value As String)
            sDiaClave = Value
        End Set
    End Property
    Public Property FolioActual() As String
        Get
            Return sFolioActual
        End Get
        Set(ByVal Value As String)
            sFolioActual = Value
        End Set
    End Property
    Public Property ClienteActual() As Cliente
        Get
            Return oCliente
        End Get
        Set(ByVal Value As Cliente)
            oCliente = Value
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
    Public Property FechaCaptura() As Date
        Get
            Return dFechaCaptura
        End Get
        Set(ByVal Value As Date)
            dFechaCaptura = Value
        End Set
    End Property
    Public Property FechaEntrega() As Date
        Get
            Return dFechaEntrega
        End Get
        Set(ByVal Value As Date)
            dFechaEntrega = Value
        End Set
    End Property
    Public Property FechaFacturacion() As Date
        Get
            Return dFechaFacturacion
        End Get
        Set(ByVal Value As Date)
            dFechaFacturacion = Value
        End Set
    End Property
    Public Property FechaCancelacion() As Date
        Get
            Return dFechaCancelacion
        End Get
        Set(ByVal Value As Date)
            dFechaCancelacion = Value
        End Set
    End Property
    Public Property FechaSurtido() As Date
        Get
            Return dFechaSurtido
        End Get
        Set(ByVal Value As Date)
            dFechaSurtido = Value
        End Set
    End Property
    Public Property FechaHoraAlta() As Date
        Get
            Return dFechaHoraAlta
        End Get
        Set(ByVal Value As Date)
            dFechaHoraAlta = Value
        End Set
    End Property
    'Public Property ListaPrecios() As ListaPrecios
    '    Get
    '        Return oListaPrecios
    '    End Get
    '    Set(ByVal Value As ListaPrecios)
    '        oListaPrecios = Value
    '    End Set
    'End Property

    Public Property ListasPrecios() As ListasPreciosCliente
        Get
            Return oListasPrecios
        End Get
        Set(ByVal Value As ListasPreciosCliente)
            oListasPrecios = Value
        End Set
    End Property
    Public Property EsquemaIdListaPrecios() As String
        Get
            Return sEsquemaIdListaPrecios
        End Get
        Set(ByVal Value As String)
            sEsquemaIdListaPrecios = Value
        End Set
    End Property
    Public Property SubEmpresaActual() As SubEmpresa.DatosEmpresa
        Get
            Return oSubEmpresaActual
        End Get
        Set(ByVal value As SubEmpresa.DatosEmpresa)
            oSubEmpresaActual = value
        End Set
    End Property
    Public Property FacturaId() As String
        Get
            Return sFacturaId
        End Get
        Set(ByVal Value As String)
            sFacturaId = Value
        End Set
    End Property
    Public Property TipoPedido() As ServicesCentral.TiposPedidos
        Get
            Return tTipoPedido
        End Get
        Set(ByVal Value As ServicesCentral.TiposPedidos)
            tTipoPedido = Value
        End Set
    End Property
    Public Property TipoFase() As ServicesCentral.TiposFasesPedidos
        Get
            Return tTipoFase
        End Get
        Set(ByVal Value As ServicesCentral.TiposFasesPedidos)
            tTipoFase = Value
        End Set
    End Property
    Public Property Tipo() As ServicesCentral.TiposTransProd
        Get
            Return tTipo
        End Get
        Set(ByVal Value As ServicesCentral.TiposTransProd)
            tTipo = Value
        End Set
    End Property
    Public Property TipoMovimiento() As ServicesCentral.TiposMovimientos
        Get
            Return tTipoMovimiento
        End Get
        Set(ByVal Value As ServicesCentral.TiposMovimientos)
            tTipoMovimiento = Value
        End Set
    End Property
    Public Property TipoMotivo() As Integer
        Get
            Return iTipoMotivo
        End Get
        Set(ByVal Value As Integer)
            iTipoMotivo = Value
        End Set
    End Property
    Public Property SubTDetalle() As Decimal
        Get
            Return Decimal.Round(nSubTDetalle, 2)
        End Get
        Set(ByVal Value As Decimal)
            nSubTDetalle = Value
        End Set
    End Property
    Public Property DescVendPor() As Decimal
        Get
            Return nDescVendPor
        End Get
        Set(ByVal Value As Decimal)
            nDescVendPor = Value
        End Set
    End Property
    Public Property DescuentoVendedor() As Decimal
        Get
            Return Decimal.Round(nDescuentoVendedor, 2)
        End Get
        Set(ByVal Value As Decimal)
            nDescuentoVendedor = Value
        End Set
    End Property
    Public Property DescuentoImp() As Decimal
        Get
            Return Decimal.Round(nDescuentoImp, 2)
        End Get
        Set(ByVal Value As Decimal)
            nDescuentoImp = Value
        End Set
    End Property
    Public Property DescuentoImpuestoCliente() As Decimal
        Get
            Return RedondeoAritmetico(nDescuentoImpuestoCliente, 2)
        End Get
        Set(ByVal Value As Decimal)
            nDescuentoImpuestoCliente = Value
        End Set
    End Property
    Public Property DescuentoImpuestoVendedor() As Decimal
        Get
            Return RedondeoAritmetico(nDescuentoImpuestoVendedor, 2)
        End Get
        Set(ByVal Value As Decimal)
            nDescuentoImpuestoVendedor = Value
        End Set
    End Property

    Public Property Total() As Decimal
        Get
            Return Decimal.Round(nTotal, 2)
        End Get
        Set(ByVal Value As Decimal)
            nTotal = Value
        End Set
    End Property
    Public Property Saldo() As Decimal
        Get
            Return Decimal.Round(nSaldo, 2)
        End Get
        Set(ByVal Value As Decimal)
            nSaldo = Value
        End Set
    End Property
    Public Property SubTotal() As Decimal
        Get
            Return Decimal.Round(nSubTotal, 2)
        End Get
        Set(ByVal Value As Decimal)
            nSubTotal = Value
        End Set
    End Property
    Public Property Impuesto() As Decimal
        Get
            Return RedondeoAritmetico(nImpuesto, 2)
        End Get
        Set(ByVal Value As Decimal)
            nImpuesto = Value
        End Set
    End Property
    Public Property Promocion() As Short
        Get
            Return bPromocion
        End Get
        Set(ByVal Value As Short)
            bPromocion = Value
        End Set
    End Property
    Public Property Descuento() As Short
        Get
            Return Me.bDescuento Or Me.DescuentoImp <> 0 Or Me.DescuentoVendedor <> 0
        End Get
        Set(ByVal Value As Short)
            bDescuento = Value
        End Set
    End Property
    Public Property Notas() As String
        Get
            Return sNotas
        End Get
        Set(ByVal Value As String)
            sNotas = Value
        End Set
    End Property
    Public Property DiasCredito() As Integer
        Get
            Return iDiasCredito
        End Get
        Set(ByVal Value As Integer)
            iDiasCredito = Value
        End Set
    End Property
    Public Property FechaCobranza() As Date
        Get
            Return dFechaCobranza
        End Get
        Set(ByVal Value As Date)
            dFechaCobranza = Value
        End Set
    End Property
    Public Property MonedaID() As String
        Get
            Return sMonedaID
        End Get
        Set(ByVal value As String)
            sMonedaID = value
        End Set
    End Property
    Public Property TipoCambio() As Decimal
        Get
            Return dTipoCambio
        End Get
        Set(ByVal value As Decimal)
            dTipoCambio = value
        End Set
    End Property
    Public Property TipoTurno() As Short
        Get
            Return bTipoTurno
        End Get
        Set(ByVal Value As Short)
            bTipoTurno = Value
        End Set
    End Property
    Public Property CFVTipo() As Integer
        Get
            Return iCFVTipo
        End Get
        Set(ByVal Value As Integer)
            iCFVTipo = Value
        End Set
    End Property
    Public Property ClientePagoId() As String
        Get
            Return sClientePagoId
        End Get
        Set(ByVal Value As String)
            sClientePagoId = Value
        End Set
    End Property
    Public Property ClienteClave() As String
        Get
            Return sClienteClave
        End Get
        Set(ByVal Value As String)
            sClienteClave = Value
        End Set
    End Property
    Public Property PLIId() As String
        Get
            Return sPLIId
        End Get
        Set(ByVal value As String)
            sPLIId = value
        End Set
    End Property
    Public Property TipoDoc() As Integer
        Get
            Return iTipoDoc
        End Get
        Set(ByVal Value As Integer)
            iTipoDoc = Value
        End Set
    End Property
    Public Property Enviado() As Boolean
        Get
            Return bEnviado
        End Get
        Set(ByVal value As Boolean)
            bEnviado = value
        End Set
    End Property

    Public Sub New()

    End Sub


#Region "Metodos Facturacion"
    Public Function CrearFacturaElectronica(ByVal SubEmpresaID As String) As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        Try
            If oDBVen.EjecutarCmdScalarIntSQL("Select count(*) from TransProd  where TransProdID ='" & Me.TransProdId & "'") > 0 Then Exit Function
            sComandoSQL.Append("INSERT INTO TransProd (TransProdID, VisitaClave, DiaClave,  PCEModuloMovDetClave, SubEmpresaID, Folio, Tipo, TipoFase, FechaHoraAlta, FechaCaptura, FechaFacturacion, Subtotal, Impuesto, Total, Saldo,  Notas, CFVTipo, FechaCobranza, MonedaID, TipoCambio, Enviado,MFechaHora, MUsuarioID) VALUES (")
            sComandoSQL.Append("'" & Me.TransProdId & "',")
            If Not Me.VisitaActual Is Nothing Then
                sComandoSQL.Append("'" & Me.VisitaActual & "',")
            Else
                sComandoSQL.Append(" null ,")
            End If
            If Not IsNothing(oDia) Then
                sComandoSQL.Append("'" & oDia.DiaActual & "',")
            Else
                sComandoSQL.Append("null,")
            End If
            If Not IsNothing(ModuloMovDetalle) Then
                sComandoSQL.Append("'" & Me.ModuloMovDetalle.ModuloMovDetalleClave & "',")
            Else
                sComandoSQL.Append("'',")
            End If

            sComandoSQL.Append(IIf(SubEmpresaID Is Nothing Or SubEmpresaID = "", " null ", "'" & SubEmpresaID & "'") & ",")
            sComandoSQL.Append("'" & Me.FolioActual & "',")
            sComandoSQL.Append(Me.Tipo & ",")
            sComandoSQL.Append(Me.TipoFase & ",")
            sComandoSQL.Append(UniFechaSQL(Me.FechaHoraAlta) & ",")
            sComandoSQL.Append(UniFechaSQL(Me.FechaCaptura) & ",")
            sComandoSQL.Append(UniFechaSQL(Now) & ",") 'FechaFacturacion
            sComandoSQL.Append(Me.SubTotal & ",")
            sComandoSQL.Append(IIf((Me.Impuesto - Me.DescuentoImpuestoCliente - Me.DescuentoImpuestoVendedor) < 0, 0, Me.Impuesto - Me.DescuentoImpuestoCliente - Me.DescuentoImpuestoVendedor) & ",")
            sComandoSQL.Append(Me.Total & ",")
            sComandoSQL.Append(Me.Saldo & ",")
            sComandoSQL.Append("'" & Me.Notas & "',")
            sComandoSQL.Append(IIf(Me.CFVTipo = 0, " null ", Me.CFVTipo) & ",")
            sComandoSQL.Append(IIf(Me.FechaCobranza.Year <= 1900, " null ", UniFechaSQL(Me.FechaCobranza)) & ",")
            If Me.MonedaID = "" Then
                sComandoSQL.Append(" Null,")
                sComandoSQL.Append(" Null,")
                Me.TipoCambio = 0
            Else
                sComandoSQL.Append("'" & Me.MonedaID & "',")
                If Me.MonedaID = oConHist.Campos("MonedaID") Then
                    sComandoSQL.Append("1,")
                    Me.TipoCambio = 1
                Else
                    Dim dTipoCambio As Decimal = oDBVen.EjecutarCmdScalardblSQL("Select CASE WHEN TipoCambio is null THEN 0 ELSE TipoCambio END as TipoCambio from TCMoneda where MonIni='" & Me.MonedaID & "' and MonFin='" & oConHist.Campos("MonedaID") & "'")
                    sComandoSQL.Append(dTipoCambio & ",")
                    Me.TipoCambio = dTipoCambio
                End If
            End If
            sComandoSQL.Append("0,")
            sComandoSQL.Append(UniFechaSQL(Now) & ",")
            sComandoSQL.Append("'" & oVendedor.UsuarioId & "'")
            sComandoSQL.Append(")")
            Return oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        End Try
    End Function

    Public Function CrearNotaCredito() As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        Try
            If oDBVen.EjecutarCmdScalarIntSQL("Select count(*) from TransProd  where TransProdID ='" & Me.TransProdId & "'") > 0 Then Exit Function
            sComandoSQL.Append("INSERT INTO TransProd (TransProdID, VisitaClave, DiaClave,SubEmpresaID, FacturaID, Folio, Tipo, TipoFase, FechaHoraAlta, FechaCaptura, FechaFacturacion, Subtotal, Impuesto, Total, Saldo,  Notas, MonedaID, TipoCambio, Enviado,MFechaHora, MUsuarioID) VALUES (")
            sComandoSQL.Append("'" & Me.TransProdId & "',")
            If Not Me.VisitaActual Is Nothing Then
                sComandoSQL.Append("'" & Me.VisitaActual & "',")
            Else
                sComandoSQL.Append(" null ,")
            End If
            If Not IsNothing(oDia) Then
                sComandoSQL.Append("'" & oDia.DiaActual & "',")
            Else
                sComandoSQL.Append("null,")
            End If
            sComandoSQL.Append(IIf(Me.SubEmpresaActual.SubEmpresaId Is Nothing OrElse Me.SubEmpresaActual.SubEmpresaId = "", " null ", "'" & Me.SubEmpresaActual.SubEmpresaId & "'") & ",")
            sComandoSQL.Append("'" & Me.FacturaId & "',")
            sComandoSQL.Append("'" & Me.FolioActual & "',")
            sComandoSQL.Append(Me.Tipo & ",")
            sComandoSQL.Append(Me.TipoFase & ",")
            sComandoSQL.Append(UniFechaSQL(Me.FechaHoraAlta) & ",")
            sComandoSQL.Append(UniFechaSQL(Me.FechaCaptura) & ",")
            sComandoSQL.Append(UniFechaSQL(Now) & ",") 'FechaFacturacion
            sComandoSQL.Append(Me.SubTotal & ",")
            sComandoSQL.Append(IIf((Me.Impuesto - Me.DescuentoImpuestoCliente - Me.DescuentoImpuestoVendedor) < 0, 0, Me.Impuesto - Me.DescuentoImpuestoCliente - Me.DescuentoImpuestoVendedor) & ",")
            sComandoSQL.Append(Me.Total & ",")
            sComandoSQL.Append(Me.Saldo & ",")
            sComandoSQL.Append("'" & Me.Notas & "',")
            'sComandoSQL.Append(IIf(Me.FechaCobranza.Year <= 1900, " null ", UniFechaSQL(Me.FechaCobranza)) & ",")
            If Me.MonedaID = "" Then
                sComandoSQL.Append(" Null,")
                sComandoSQL.Append(" Null,")
                Me.TipoCambio = 0
            Else
                sComandoSQL.Append("'" & Me.MonedaID & "',")
                If Me.MonedaID = oConHist.Campos("MonedaID") Then
                    sComandoSQL.Append("1,")
                    Me.TipoCambio = 1
                Else
                    Dim dTipoCambio As Decimal = oDBVen.EjecutarCmdScalardblSQL("Select CASE WHEN TipoCambio is null THEN 0 ELSE TipoCambio END as TipoCambio from TCMoneda where MonIni='" & Me.MonedaID & "' and MonFin='" & oConHist.Campos("MonedaID") & "'")
                    sComandoSQL.Append(dTipoCambio & ",")
                    Me.TipoCambio = dTipoCambio
                End If
            End If
            sComandoSQL.Append("0,")
            sComandoSQL.Append(UniFechaSQL(Now) & ",")
            sComandoSQL.Append("'" & oVendedor.UsuarioId & "'")
            sComandoSQL.Append(")")
            Return oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        End Try
    End Function
#End Region

    Public Function Actualizar(Optional ByVal bSurtir As Boolean = False) As Boolean
        'Public Function Actualizar(ByVal bSurtir As Boolean) As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        Try
            ' Buscar el TransProdId, para ver si ya existia
            Dim DataTableTrans As DataTable
            DataTableTrans = oDBVen.RealizarConsultaSQL("SELECT TransProdId FROM TransProd WHERE TransProdId='" & Me.TransProdId & "'", "TransProd")
            If DataTableTrans.Rows.Count > 0 Then
                ' Ya existe, actualizar
                sComandoSQL.Append("UPDATE TransProd SET ")
                If Not (Me.VisitaClave1 Is Nothing OrElse Me.VisitaClave1 = String.Empty) Then
                    sComandoSQL.Append("VisitaClave1='" & Me.VisitaClave1 & "',")
                End If
                If Not (Me.DiaClave1 Is Nothing OrElse Me.DiaClave1 = String.Empty) Then
                    sComandoSQL.Append("DiaClave1='" & Me.sDiaClave1 & "',")
                End If
                If Not Me.ListasPrecios Is Nothing AndAlso Me.ListasPrecios.ListasPrecios.Count > 0 Then
                    sComandoSQL.Append("PCEPrecioClave='" & Me.ListasPrecios.ListasPrecios.Values(0).PrecioClave & "',")
                End If
                If Not Me.ClienteClave Is Nothing AndAlso Me.ClienteClave <> "" Then
                    sComandoSQL.Append("ClienteClave='" & Me.sClienteClave & "',")
                End If

                If Not IsNothing(Me.MonedaID) AndAlso Me.MonedaID = "1" Then
                    Me.ClientePagoId = 1
                ElseIf Not IsNothing(Me.MonedaID) AndAlso Me.MonedaID = "2" Then
                    Me.ClientePagoId = 5
                End If

                If Not Me.ClientePagoId Is Nothing AndAlso Me.ClientePagoId <> "" Then
                    sComandoSQL.Append("ClientePagoId='" & Me.sClientePagoId & "',")
                End If
                sComandoSQL.Append("TipoTurno='" & Me.bTipoTurno & "',")
                sComandoSQL.Append("CFVTipo=" & IIf(Me.iCFVTipo = 0, "Null", Me.iCFVTipo) & ",")
                sComandoSQL.Append("DiasCredito=" & Me.iDiasCredito & ",")
                If Not Me.ModuloMovDetalle Is Nothing Then
                    sComandoSQL.Append("PCEModuloMovDetClave='" & Me.ModuloMovDetalle.ModuloMovDetalleClave & "',")
                End If
                sComandoSQL.Append("PCEEsquemaID=" & IIf(Me.EsquemaIdListaPrecios = "", "Null", "'" & Me.EsquemaIdListaPrecios & "'") & ",")
                sComandoSQL.Append("FacturaID=" & IIf(Me.FacturaId = "", "Null", "'" & Me.FacturaId & "'") & ",")
                sComandoSQL.Append("PLIId=" & IIf(Me.PLIId = "", "Null", "'" & Me.PLIId & "'") & ",")
                sComandoSQL.Append("Folio='" & Me.FolioActual & "',")
                sComandoSQL.Append("Tipo=" & Me.Tipo & ",")
                sComandoSQL.Append("TipoPedido=" & Me.TipoPedido & ",")
                sComandoSQL.Append("TipoFase=" & Me.TipoFase & ",")
                sComandoSQL.Append("TipoMovimiento=" & Me.TipoMovimiento & ",")
                If Not IsNothing(oDia) Then
                    If Me.TipoPedido = ServicesCentral.TiposPedidos.Consignacion OrElse Me.TipoPedido = ServicesCentral.TiposPedidos.Posfechado Then
                        sComandoSQL.Append("FechaEntrega=" & UniFechaSQL(Me.FechaEntrega) & ",")
                    Else
                        sComandoSQL.Append("FechaEntrega=" & UniFechaSQL(PrimeraHora(Now).AddDays([Global].ObtenerDiasSurtido)) & ",")
                    End If
                End If
                If Me.FechaFacturacion.Year > 1900 Then
                    sComandoSQL.Append("FechaFacturacion=" & UniFechaSQL(Me.FechaFacturacion) & ",")
                End If
                If Me.FechaSurtido.Year > 1900 Then
                    sComandoSQL.Append("FechaSurtido=" & UniFechaSQL(Me.FechaSurtido) & ",")
                End If
                If Me.FechaCancelacion.Year > 1900 Then
                    sComandoSQL.Append("FechaCancelacion=" & UniFechaSQL(Me.FechaCancelacion) & ",")
                End If
                If Me.FechaCobranza.Year > 1900 Then
                    sComandoSQL.Append("FechaCobranza=" & UniFechaSQL(Me.FechaCobranza) & ",")
                End If
                If Me.MonedaID = "" Then
                    sComandoSQL.Append("MonedaID=Null,")
                    sComandoSQL.Append("TipoCambio=Null,")
                    Me.TipoCambio = 0
                Else
                    sComandoSQL.Append("MonedaID='" & Me.MonedaID & "',")
                    If Me.MonedaID = oConHist.Campos("MonedaID") Then
                        If TipoCambio = 0 Then
                            sComandoSQL.Append("TipoCambio=1,")
                            Me.TipoCambio = 1
                        End If
                    Else
                        If TipoCambio = 0 Then
                            Dim dTipoCambio As Decimal = oDBVen.EjecutarCmdScalardblSQL("Select CASE WHEN TipoCambio is null THEN 0 ELSE TipoCambio END as TipoCambio from TCMoneda where MonIni='" & Me.MonedaID & "' and MonFin='" & oConHist.Campos("MonedaID") & "'")
                            sComandoSQL.Append("TipoCambio=" & dTipoCambio & ",")
                            Me.TipoCambio = dTipoCambio
                        End If
                    End If
                End If
                sComandoSQL.Append("TipoMotivo=" & Me.TipoMotivo & ",")
                sComandoSQL.Append("SubTDetalle=" & Me.SubTDetalle & ",")
                sComandoSQL.Append("DescVendPor=" & Me.DescVendPor & ",")
                sComandoSQL.Append("DescuentoVendedor=" & Me.DescuentoVendedor & ",")
                sComandoSQL.Append("DescuentoImp=" & Me.DescuentoImp & ",")
                sComandoSQL.Append("Subtotal=" & Me.SubTotal & ",")
                If Not bSurtir Then
                    sComandoSQL.Append("Impuesto=" & IIf((Me.Impuesto - Me.DescuentoImpuestoCliente - Me.DescuentoImpuestoVendedor) < 0, 0, (Me.Impuesto - Me.DescuentoImpuestoCliente - Me.DescuentoImpuestoVendedor)) & ",")
                End If
                sComandoSQL.Append("Total=" & Me.Total & ",")
                sComandoSQL.Append("Saldo=" & Me.Saldo & ",")
                sComandoSQL.Append("Promocion=" & Me.Promocion & ",")
                sComandoSQL.Append("Descuento=" & Me.Descuento & ",")
                sComandoSQL.Append("Notas='" & Me.Notas & "',")
                sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",")
                sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "', ")
                sComandoSQL.Append("Enviado=0 ")
                sComandoSQL.Append("WHERE TransProdId='" & Me.TransProdId & "'")
            Else
                ' No existe, crear
                sComandoSQL.Append("INSERT INTO TransProd (TransProdID, VisitaClave, DiaClave, PCEPrecioClave, PCEModuloMovDetClave, PCEEsquemaID, SubEmpresaID, FacturaID, PLIId, Folio, Tipo, TipoPedido, TipoFase, TipoMovimiento, FechaHoraAlta, FechaCaptura, FechaEntrega, FechaFacturacion, FechaSurtido, FechaCancelacion, TipoMotivo, SubTDetalle, DescVendPor, DescuentoVendedor, DescuentoImp, Subtotal, Impuesto, Total, Saldo, Promocion, Descuento, Notas, ClienteClave, ClientePagoId, CFVTipo, TipoTurno, FechaCobranza, MonedaID, TipoCambio, DiasCredito,TipoDoc, Enviado,MFechaHora, MUsuarioID) VALUES (")
                sComandoSQL.Append("'" & Me.TransProdId & "',")
                If Not Me.VisitaActual Is Nothing Then
                    sComandoSQL.Append("'" & Me.VisitaActual & "',")
                Else
                    sComandoSQL.Append(" null ,")
                End If
                If Not IsNothing(oDia) Then
                    sComandoSQL.Append("'" & oDia.DiaActual & "',")
                Else
                    sComandoSQL.Append("null,")
                End If

                If Me.ListasPrecios Is Nothing OrElse Me.ListasPrecios.ListasPrecios.Count <= 0 Then
                    sComandoSQL.Append(" null,")
                Else
                    sComandoSQL.Append("'" & Me.ListasPrecios.ListasPrecios.Values(0).PrecioClave & "',")
                End If

                If Not IsNothing(ModuloMovDetalle) Then
                    sComandoSQL.Append("'" & Me.ModuloMovDetalle.ModuloMovDetalleClave & "',")
                Else
                    sComandoSQL.Append("'',")
                End If
                sComandoSQL.Append(IIf(Me.EsquemaIdListaPrecios Is Nothing Or Me.EsquemaIdListaPrecios = "", " null ", "'" & Me.EsquemaIdListaPrecios & "'") & ",")
                If Not IsNothing(SubEmpresaActual) Then
                    sComandoSQL.Append("'" & Me.SubEmpresaActual.SubEmpresaId & "',")
                Else
                    sComandoSQL.Append("null,")
                End If
                sComandoSQL.Append(IIf(Me.FacturaId Is Nothing Or Me.FacturaId = "", " null ", "'" & Me.FacturaId & "'") & ",")
                sComandoSQL.Append(IIf(Me.PLIId Is Nothing Or Me.PLIId = "", " null ", "'" & Me.PLIId & "'") & ",")
                sComandoSQL.Append("'" & Me.FolioActual & "',")
                sComandoSQL.Append(Me.Tipo & ",")
                sComandoSQL.Append(IIf(IsNothing(Me.TipoPedido), " null ", Me.TipoPedido) & ",")
                sComandoSQL.Append(Me.TipoFase & ",")
                sComandoSQL.Append(Me.TipoMovimiento & ",")
                sComandoSQL.Append(UniFechaSQL(Now) & ",")
                sComandoSQL.Append(UniFechaSQL(Me.FechaCaptura) & ",")
                'sComandoSQL.Append(IIf(Me.FechaEntrega.Year <= 1900, "null ", UniFechaSQL(Me.FechaEntrega.AddDays(ObtenerDiasSurtido))) & ",")
                'sComandoSQL.Append(IIf(Me.FechaFacturacion.Year <= 1900, "null ", UniFechaSQL(Me.FechaFacturacion)) & ",")
                'sComandoSQL.Append(IIf(Me.FechaSurtido.Year <= 1900, " null ", UniFechaSQL(Me.FechaSurtido)) & ",")
                'sComandoSQL.Append(IIf(Me.FechaCancelacion.Year <= 1900, " null ", UniFechaSQL(Me.FechaCancelacion)) & ",")
                If Not IsNothing(oDia) Then
                    If Me.TipoPedido = ServicesCentral.TiposPedidos.Posfechado OrElse Me.TipoPedido = ServicesCentral.TiposPedidos.Consignacion Then
                        sComandoSQL.Append(UniFechaSQL(PrimeraHora(Now)) & ",")
                    Else
                        sComandoSQL.Append(UniFechaSQL(PrimeraHora(Now).AddDays([Global].ObtenerDiasSurtido)) & ",")
                    End If
                Else
                    sComandoSQL.Append(UniFechaSQL(Me.FechaEntrega) & ",")
                End If
                'sComandoSQL.Append(IIf(Me.FechaFacturacion.Year <= 1900, UniFechaSQL(Me.FechaFacturacion), UniFechaSQL(Me.FechaFacturacion)) & ",")
                'sComandoSQL.Append(IIf(Me.FechaSurtido.Year <= 1900, UniFechaSQL(Me.FechaSurtido), UniFechaSQL(Me.FechaSurtido)) & ",")
                'sComandoSQL.Append(IIf(Me.FechaCancelacion.Year <= 1900, UniFechaSQL(Me.FechaCancelacion), UniFechaSQL(Me.FechaCancelacion)) & ",")
                sComandoSQL.Append(UniFechaSQL(Me.FechaFacturacion) & ",")
                sComandoSQL.Append(UniFechaSQL(Me.FechaSurtido) & ",")
                sComandoSQL.Append(UniFechaSQL(Me.FechaCancelacion) & ",")
                sComandoSQL.Append(Me.TipoMotivo & ",")
                sComandoSQL.Append(Me.SubTDetalle & ",")
                sComandoSQL.Append(Me.DescVendPor & ",")
                sComandoSQL.Append(Me.DescuentoVendedor & ",")
                sComandoSQL.Append(Me.DescuentoImp & ",")
                sComandoSQL.Append(Me.SubTotal & ",")
                sComandoSQL.Append(IIf((Me.Impuesto - Me.DescuentoImpuestoCliente - Me.DescuentoImpuestoVendedor) < 0, 0, Me.Impuesto - Me.DescuentoImpuestoCliente - Me.DescuentoImpuestoVendedor) & ",")
                sComandoSQL.Append(Me.Total & ",")
                sComandoSQL.Append(Me.Saldo & ",")
                sComandoSQL.Append(Me.Promocion & ",")
                sComandoSQL.Append(Me.Descuento & ",")
                sComandoSQL.Append("'" & Me.Notas & "',")
                sComandoSQL.Append(IIf(Me.ClienteClave Is Nothing Or Me.ClienteClave = "", " null ", "'" & Me.ClienteClave & "'") & ",")
                sComandoSQL.Append(IIf(Me.ClientePagoId Is Nothing Or Me.ClientePagoId = "", " null ", "'" & Me.ClientePagoId & "'") & ",")
                sComandoSQL.Append(IIf(Me.CFVTipo = 0, " null ", Me.CFVTipo) & ",")
                sComandoSQL.Append(Me.TipoTurno & ",")
                sComandoSQL.Append(IIf(Me.FechaCobranza.Year <= 1900, " null ", UniFechaSQL(Me.FechaCobranza)) & ",")
                If Me.MonedaID = "" Then
                    sComandoSQL.Append(" Null,")
                    sComandoSQL.Append(" Null,")
                    Me.TipoCambio = 0
                Else
                    sComandoSQL.Append("'" & Me.MonedaID & "',")
                    If Me.MonedaID = oConHist.Campos("MonedaID") Then
                        sComandoSQL.Append("1,")
                        Me.TipoCambio = 1
                    Else
                        Dim dTipoCambio As Decimal = oDBVen.EjecutarCmdScalardblSQL("Select CASE WHEN TipoCambio is null THEN 0 ELSE TipoCambio END as TipoCambio from TCMoneda where MonIni='" & Me.MonedaID & "' and MonFin='" & oConHist.Campos("MonedaID") & "'")
                        sComandoSQL.Append(dTipoCambio & ",")
                        Me.TipoCambio = dTipoCambio
                    End If
                End If
                sComandoSQL.Append(Me.DiasCredito & ",0,")
                sComandoSQL.Append(IIf(IsNothing(Me.TipoDoc) OrElse IsDBNull(Me.TipoDoc), " 0 ", Me.TipoDoc) & ",")
                sComandoSQL.Append(UniFechaSQL(Now) & ",")
                sComandoSQL.Append("'" & oVendedor.UsuarioId & "'")
                sComandoSQL.Append(")")
            End If

            Return oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        End Try
    End Function

    Public Sub RecalcularTotales()
        ' Hasta aqui el descuento del cliente ya esta calculado y aplicado, tambien al Impuesto
        ' Calcular el importe del descuento del subtotal
        Me.DescuentoVendedor = (Me.SubTDetalle - Me.DescuentoImp) * (Me.DescVendPor / 100)
        ' Calcular el importe del descuento del impuesto
        Me.DescuentoImpuestoVendedor = (Me.Impuesto - Me.DescuentoImpuestoCliente) * (Me.DescVendPor / 100)
        Me.SubTotal = Me.SubTDetalle - Me.DescuentoImp - Me.DescuentoVendedor
        If Me.SubTotal < 0 Then Me.SubTotal = 0
        Me.Total = Me.SubTotal + (Me.Impuesto - Me.DescuentoImpuestoCliente - Me.DescuentoImpuestoVendedor)
        If Me.Total < 0 Then Me.Total = 0
    End Sub

    Public Sub ObtenerDescuentoVendedor()
        Dim sComando As String = ""
        oDBVen.EjecutarComandoSQL("DELETE FROM TpdDesVendedor WHERE TransProdId = '" & Me.TransProdId & "'")

        sComando = "insert into TPDDesVendedor "
        sComando &= "select TPD.TransProdId, TPD.TransProdDetalleId, avg(TRP.DescVendPor), "
        sComando &= "(avg(TPD.SubTotal) - case isnull(sum(TDD.DesImporte)) when 0 then sum(TDD.DesImporte) else 0 end) * avg(TRP.DescVendPor)/100 as DesImporte, "
        sComando &= "(avg(TPD.Impuesto) - case isnull(sum(TDD.DesImpuesto)) when 0 then sum(TDD.DesImpuesto) else 0 end) * avg(TRP.DescVendPor)/100 as DesImpuesto,  "
        sComando &= "getdate(), '" & oVendedor.UsuarioId & "', 0 "
        sComando &= "from TransProdDetalle TPD "
        sComando &= "inner join TransProd TRP on TPD.TransProdId = TRP.TransProdId "
        sComando &= "left join TpdDes TDD on TDD.TransProdId = TPD.TransProdId and TDD.TransProdDetalleId = TPD.TransProdDetalleId "
        sComando &= "where TPD.TransProdId = '" & Me.TransProdId & "'  group by TPD.TransProdId, TPD.TransProdDetalleId "

        oDBVen.EjecutarComandoSQL(sComando)
    End Sub

    Public Sub EliminarDescuentosVendedor()
        Dim sComando As String
        sComando = "delete TpdDesVendedor where TransProdId = '" & Me.TransProdId & "' "
        oDBVen.EjecutarComandoSQL(sComando)
    End Sub

    Public Function Recuperar() As Boolean
        Try
            ' Reiniciar las variables en ceros
            Me.Reiniciar(False)
            ' Buscar el TransProdId, para ver si ya existia
            Dim DataTableTrans As DataTable
            DataTableTrans = oDBVen.RealizarConsultaSQL("SELECT * FROM TransProd WHERE TransProdId='" & Me.TransProdId & "'", "TransProd")
            If DataTableTrans.Rows.Count > 0 Then
                With DataTableTrans.Rows(0)
                    Me.VisitaActual = .Item("VisitaClave")
                    If Not IsDBNull(.Item("DiaClave")) Then
                        Me.DiaClave = .Item("DiaClave")
                    End If
                    If Not IsDBNull(.Item("VisitaClave1")) Then
                        Me.VisitaClave1 = .Item("VisitaClave1")
                    Else
                        Me.VisitaClave1 = String.Empty
                    End If
                    If Not IsDBNull(.Item("DiaClave1")) Then
                        Me.DiaClave1 = .Item("DiaClave1")
                    Else
                        Me.DiaClave1 = String.Empty
                    End If
                    Me.FolioActual = .Item("Folio")
                    If Not Me.ModuloMovDetalle Is Nothing AndAlso IsDBNull(.Item("PCEModuloMovDetClave")) = False Then
                        Me.ModuloMovDetalle.ModuloMovDetalleClave = .Item("PCEModuloMovDetClave")
                    End If
                    Me.FechaCaptura = .Item("FechaCaptura")
                    If Not IsDBNull(.Item("FechaEntrega")) Then
                        Me.FechaEntrega = .Item("FechaEntrega")
                    End If
                    If Not IsDBNull(.Item("FechaFacturacion")) Then
                        Me.FechaFacturacion = .Item("FechaFacturacion")
                    End If
                    If Not IsDBNull(.Item("FechaSurtido")) Then
                        Me.FechaSurtido = .Item("FechaSurtido")
                    End If
                    If Not IsDBNull(.Item("FechaCancelacion")) Then
                        Me.FechaCancelacion = .Item("FechaCancelacion")
                    End If
                    If Not IsDBNull(.Item("FechaCobranza")) Then
                        Me.FechaCobranza = .Item("FechaCobranza")
                    End If
                    If Not IsDBNull(.Item("MonedaID")) Then
                        Me.MonedaID = .Item("MonedaID")
                    End If
                    If Not IsDBNull(.Item("TipoCambio")) Then
                        Me.TipoCambio = .Item("TipoCambio")
                    End If
                    If Not Me.ListasPrecios Is Nothing AndAlso Me.ListasPrecios.ListasPrecios.Count > 0 Then
                        Me.ListasPrecios.ListasPrecios.Values(0).PrecioClave = IIf(IsDBNull(.Item("PCEPrecioClave")), "", .Item("PCEPrecioClave"))
                    End If
                    Me.EsquemaIdListaPrecios = IIf(IsDBNull(.Item("PCEEsquemaID")), "", .Item("PCEEsquemaID"))
                    Me.FacturaId = IIf(IsDBNull(.Item("FacturaID")), "", .Item("FacturaID"))
                    Me.PLIId = IIf(IsDBNull(.Item("PLIId")), "", .Item("PLIId"))
                    Me.TipoPedido = IIf(IsDBNull(.Item("TipoPedido")), ServicesCentral.TiposPedidos.NoDefinido, .Item("TipoPedido"))
                    Me.TipoFase = IIf(IsDBNull(.Item("TipoFase")), 0, .Item("TipoFase"))

                    Me.ClienteClave = IIf(IsDBNull(.Item("ClienteClave")), "", .Item("ClienteClave"))
                    Me.ClientePagoId = IIf(IsDBNull(.Item("ClientePagoId")), "", .Item("ClientePagoId"))
                    Me.TipoTurno = IIf(IsDBNull(.Item("TipoTurno")), 0, .Item("TipoTurno"))
                    Me.DiasCredito = IIf(IsDBNull(.Item("DiasCredito")), 0, .Item("DiasCredito"))

                    If Not IsDBNull(.Item("CFVTipo")) Then
                        Me.CFVTipo = .Item("CFVTipo")
                    End If
                    If Not IsDBNull(.Item("Tipo")) Then
                        Me.Tipo = .Item("Tipo")
                    End If
                    If Not IsDBNull(.Item("TipoMovimiento")) Then
                        Me.TipoMovimiento = .Item("TipoMovimiento")
                    End If
                    If Not IsDBNull(.Item("TipoMotivo")) Then
                        Me.TipoMotivo = .Item("TipoMotivo")
                    End If
                    If Not IsDBNull(.Item("SubTDetalle")) Then
                        Me.SubTDetalle = .Item("SubTDetalle")
                    End If
                    If Not IsDBNull(.Item("DescVendPor")) Then
                        Me.DescVendPor = .Item("DescVendPor")
                    End If
                    If Not IsDBNull(.Item("DescuentoVendedor")) Then
                        Me.DescuentoVendedor = .Item("DescuentoVendedor")
                    End If
                    If Not IsDBNull(.Item("DescuentoImp")) Then
                        Me.DescuentoImp = .Item("DescuentoImp")
                    End If
                    Me.Total = .Item("Total")
                    Me.Saldo = .Item("Saldo")
                    Me.SubTotal = .Item("Subtotal")
                    Me.Impuesto = .Item("Impuesto")
                    Me.Promocion = IIf(.IsNull("Promocion"), False, .Item("Promocion"))
                    Me.Descuento = IIf(.IsNull("Descuento"), False, .Item("Descuento"))
                    If Not IsDBNull(.Item("Notas")) Then
                        Me.Notas = .Item("Notas")
                    End If
                    If Not IsDBNull(.Item("TipoDoc")) Then
                        Me.TipoDoc = .Item("TipoDoc")
                    End If
                    If Not IsDBNull(.Item("Enviado")) Then
                        Me.Enviado = .Item("Enviado")
                    Else
                        Me.Enviado = False
                    End If
                End With
                Return True
            End If
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "Recuperar")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "Recuperar")
        End Try
        Return False
    End Function

    Public Shared Function RecuperarTipoFasePedido(ByVal parsTransProdID As String) As ServicesCentral.TiposFasesPedidos
        Dim tTipoFasePedido As ServicesCentral.TiposFasesPedidos
        Try
            ' Buscar el TransProdId, para ver si ya existia
            Dim DataTableTrans As DataTable
            DataTableTrans = oDBVen.RealizarConsultaSQL("SELECT TipoFase FROM TransProd WHERE TransProdId='" & parsTransProdID & "' AND Tipo=" & ServicesCentral.TiposTransProd.Pedido, "TransProd")
            If DataTableTrans.Rows.Count > 0 Then
                tTipoFasePedido = DataTableTrans.Rows(0).Item("TipoFase")
            End If
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "RecuperarTipoFasePedido")
        End Try
        Return tTipoFasePedido
    End Function

    Public Function RecuperarUnidadesProductosDetalle(ByVal parsProductoClave As String, ByRef refparsListaTiposUnidades As String) As Boolean
        Try
            Dim DataTableResultado As DataTable = oDBVen.RealizarConsultaSQL("SELECT DISTINCT TipoUnidad FROM TransProdDetalle WHERE TransProdID='" & Me.TransProdId & "' AND ProductoClave='" & parsProductoClave & "'", "Detalle")
            refparsListaTiposUnidades = ""
            For Each refDataRow As DataRow In DataTableResultado.Rows
                If refparsListaTiposUnidades <> "" Then
                    refparsListaTiposUnidades &= ", "
                End If
                refparsListaTiposUnidades &= refDataRow("TipoUnidad")
            Next
            Return (parsProductoClave <> "")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Public Function RecuperarDetalle() As DataTable
        Dim DataTableResultado As DataTable
        DataTableResultado = oDBVen.RealizarConsultaSQL("SELECT * FROM TransProdDetalle WHERE TransProdID='" & Me.TransProdId & "'", "Detalle")
        Return DataTableResultado
    End Function

    Public Function Eliminar() As Boolean
        Try
            Dim sComando As String
            sComando = "delete TransProdDetalle where TransProdId = '" & Me.TransProdId & "'"
            oDBVen.EjecutarComandoSQL(sComando)
            sComando = "delete TransProd where TransProdId = '" & Me.TransProdId & "'"
            oDBVen.EjecutarComandoSQL(sComando)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Reiniciar(Optional ByVal optparbTodo As Boolean = True) As Boolean
        If optparbTodo Then
            Me.FolioActual = ""
            Me.TransProdId = ""
        End If
        Me.FechaCaptura = PrimeraHora(Now)
        Me.FechaEntrega = New Date(1900, 1, 1)
        Me.FechaFacturacion = New Date(1900, 1, 1)
        Me.FechaSurtido = New Date(1900, 1, 1)
        Me.FechaCancelacion = New Date(1900, 1, 1)
        Me.FechaCobranza = PrimeraHora(Now)
        Me.ClienteClave = ""
        Me.ClientePagoId = ""
        Me.CFVTipo = 0
        Me.TipoTurno = 0
        Me.DiasCredito = 0
        Me.EsquemaIdListaPrecios = ""
        Me.FacturaId = ""
        Me.PLIId = ""
        Me.MonedaID = ""
        Me.TipoPedido = ServicesCentral.TiposPedidos.NoDefinido
        Me.SubTDetalle = 0
        Me.DescVendPor = 0
        Me.DescuentoVendedor = 0
        Me.DescuentoImp = 0
        Me.DescuentoImpuestoCliente = 0
        Me.DescuentoImpuestoVendedor = 0
        Me.Total = 0
        Me.Saldo = 0
        Me.SubTotal = 0
        Me.Impuesto = 0
        Me.Promocion = 0
        Me.Descuento = 0
        Me.Notas = ""
        Me.TipoMotivo = 0
        Me.TipoCambio = 0
        Me.DiasCredito = 0
        Me.TipoDoc = 0
    End Function
    Public Shared Function DevolucionTotal(ByVal paroTransProd As TransProd, ByVal pvCliente As Cliente, ByVal parsVisitaClave As String) As Boolean
        Try
            Dim DataTableDetalle As DataTable = oDBVen.RealizarConsultaSQL("SELECT Partida,ProductoClave,TipoUnidad,Cantidad,Cantidad1,case isnull(PrestamoVendido) when 1 then 0 else PrestamoVendido end as PrestamoVendido,CodigoSKU, TransProdDetalleID, Factor, Factor1, Precio, Impuesto,SubTotal,Total FROM TransProdDetalle WHERE TransProdID='" & paroTransProd.TransProdId & "' ORDER BY Partida", "Detalle")
            Dim sProductoClave As String
            Dim iTipoUnidad As Integer
            Dim dCantidad As Decimal
            Dim dCantidad1 As Decimal
            Dim dPrestamoVendido As Decimal
            Dim tipoFaseOrig As ServicesCentral.TiposFasesPedidos

            tipoFaseOrig = paroTransProd.TipoFase
            paroTransProd.TipoFase = ServicesCentral.TiposFasesPedidos.Surtido
            paroTransProd.VisitaClave1 = parsVisitaClave
            paroTransProd.DiaClave1 = oDia.DiaActual
            paroTransProd.Actualizar()

            Dim bVentaABordo As Boolean = False
            'Insertar Devolucion 
            Dim sComandoSQL As New System.Text.StringBuilder
            Dim oTransProdDevolucion As TransProd = New TransProd
            With oTransProdDevolucion
                .TransProdId = oApp.KEYGEN(1)
                .VisitaActual = parsVisitaClave
                .DiaClave = oDia.DiaActual
                .ModuloMovDetalle = paroTransProd.ModuloMovDetalle
                .ClienteClave = paroTransProd.ClienteActual.ClienteClave
                .Tipo = ServicesCentral.TiposTransProd.BonificacionPorDetalle
                .FolioActual = paroTransProd.FolioActual
                .TipoPedido = ServicesCentral.TiposPedidos.NoDefinido
                .TipoFase = ServicesCentral.TiposFasesPedidos.Captura
                .TipoMovimiento = ServicesCentral.TiposMovimientos.Entrada
                .FacturaId = paroTransProd.TransProdId
                .Actualizar(True)
            End With

            'Si esta facturado, crear nota de crédito
            Dim oTransProdNota As TransProd
            Dim oFolioFiscal As FolioFiscal

            Dim sFacturaId As String = String.Empty
            Dim bFacturaVirtual As Boolean = False
            If Not IsDBNull(paroTransProd.FacturaId) AndAlso paroTransProd.FacturaId <> "" Then
                sFacturaId = paroTransProd.FacturaId
            Else
                sFacturaId = oApp.KEYGEN(1)
                Dim oTransProdFactura As TransProd = New TransProd()
                oTransProdFactura.TransProdId = sFacturaId
                oTransProdFactura.VisitaActual = parsVisitaClave
                oTransProdFactura.ModuloMovDetalle = paroTransProd.ModuloMovDetalle
                oTransProdFactura.FolioActual = paroTransProd.FolioActual
                oTransProdFactura.Tipo = ServicesCentral.TiposTransProd.Factura
                oTransProdFactura.TipoFase = ServicesCentral.TiposFasesPedidos.Captura
                oTransProdFactura.FechaHoraAlta = Now
                oTransProdFactura.SubTotal = paroTransProd.SubTotal
                oTransProdFactura.Impuesto = paroTransProd.Impuesto
                oTransProdFactura.Total = paroTransProd.Total
                oTransProdFactura.Saldo = 0
                oTransProdFactura.CFVTipo = paroTransProd.CFVTipo
                oTransProdFactura.MonedaID = paroTransProd.MonedaID
                oTransProdFactura.TipoCambio = paroTransProd.TipoCambio
                oTransProdFactura.CrearFacturaElectronica(paroTransProd.SubEmpresaActual.SubEmpresaId)

                oDBVen.EjecutarComandoSQL("UPDATE TransProd SET FacturaID ='" & oTransProdFactura.TransProdId & "', MFechaHora=getdate(), MUsuarioID='" & oVendedor.UsuarioId & "' where TransProdID='" & paroTransProd.TransProdId & "'")

                bFacturaVirtual = True
            End If

            'If Not IsNothing(paroTransProd.FacturaId) AndAlso Not IsDBNull(paroTransProd.FacturaId) AndAlso paroTransProd.FacturaId <> "" Then
            Dim FolioF As New FolioFiscal
            Dim LFolios As New System.Collections.Generic.List(Of FolioFiscal)
            Dim Mensajes As String = ""
            oFolioFiscal = FolioF.ObtenerFolioFiscal(paroTransProd.SubEmpresaActual.SubEmpresaId, 2, Mensajes)

            If Mensajes <> "" Then
                If Mensajes = "E0855" Then
                    MsgBox("No existen folios para la nota de crédito")
                Else
                    MsgBox(Mensajes)
                End If
            Else
                oTransProdNota = New TransProd()
                oTransProdNota.TransProdId = oApp.KEYGEN(1)
                oTransProdNota.VisitaActual = oTransProdDevolucion.VisitaActual
                oTransProdNota.FolioActual = oFolioFiscal.Formato
                oTransProdNota.Tipo = 10
                oTransProdNota.TipoFase = ServicesCentral.TiposFasesPedidos.Captura
                oTransProdNota.TipoPedido = ServicesCentral.TiposPedidos.NoDefinido
                oTransProdNota.TipoMovimiento = ServicesCentral.TiposMovimientos.NoDefinido
                oTransProdNota.FechaHoraAlta = Now
                oTransProdNota.SubTotal = paroTransProd.SubTotal
                oTransProdNota.Impuesto = paroTransProd.Impuesto
                oTransProdNota.Total = paroTransProd.Total
                oTransProdNota.Saldo = 0
                oTransProdNota.SubEmpresaActual = paroTransProd.SubEmpresaActual
                oTransProdNota.MonedaID = paroTransProd.MonedaID
                oTransProdNota.TipoCambio = paroTransProd.TipoCambio
                oTransProdNota.FacturaId = sFacturaId
                oTransProdNota.CrearNotaCredito()
            End If

            'Regresar el inventario y llenar el detalle de la devolucion y de la nota de credito
            For Each refDataRow As DataRow In DataTableDetalle.Rows
                Dim bVenta As Boolean = False

                sProductoClave = refDataRow("ProductoClave")
                iTipoUnidad = refDataRow("TipoUnidad")
                dCantidad = refDataRow("Cantidad")
                dCantidad1 = refDataRow("Cantidad1")
                dPrestamoVendido = refDataRow("PrestamoVendido")

                'inventario
                If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion And tipoFaseOrig = ServicesCentral.TiposFasesPedidos.Captura And paroTransProd.VisitaActual <> parsVisitaClave Then
                    SKUInventario.ActualizarSKU(SKUInventario.SKUMovimiento.Apartar, refDataRow("CodigoSKU").ToString, sProductoClave, iTipoUnidad, (-1) * dCantidad, (-1) * dCantidad1)
                ElseIf oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion And paroTransProd.VisitaActual = parsVisitaClave Then
                    bVentaABordo = True
                    SKUInventario.ActualizarSKU(SKUInventario.SKUMovimiento.Incrementar, refDataRow("CodigoSKU").ToString, sProductoClave, iTipoUnidad, dCantidad, dCantidad1)
                End If

                'detalle de la devolucion
                TransProdDetalle.CrearDetalleBonificacion(oTransProdDevolucion.TransProdId, refDataRow("TransProdDetalleID"), refDataRow("ProductoClave"), refDataRow("CodigoSKU"), refDataRow("TipoUnidad"), refDataRow("Cantidad"), refDataRow("Cantidad1"), refDataRow("Factor"), refDataRow("Factor1"), refDataRow("Precio"), 0, 0, refDataRow("Impuesto"), 0, 0, refDataRow("Total"), oTransProdDevolucion.FacturaId)

                'detalle de la nota
                If Not IsNothing(oTransProdNota) Then
                    Dim oTransProdDetalle As TransProdDetalle = New TransProdDetalle(oTransProdNota.TransProdId, refDataRow("ProductoClave"), refDataRow("Partida"))
                    With oTransProdDetalle
                        .TransProdDetalleID = refDataRow("TransProdDetalleID")
                        .CodigoSKU = refDataRow("CodigoSKU")
                        .TipoUnidad = refDataRow("TipoUnidad")
                        .Cantidad = refDataRow("Cantidad")
                        .Cantidad1 = refDataRow("Cantidad1")
                        .Factor = refDataRow("Factor")
                        .Factor1 = refDataRow("Factor1")
                        .Precio = refDataRow("Precio")
                        .SubTotal = refDataRow("SubTotal")
                        .Impuesto = refDataRow("Impuesto")
                        .Total = refDataRow("Total")
                        oTransProdDetalle.CrearDetalleNotaCredito()
                    End With
                End If
            Next

            'Impuestos de la devolucion
            oDBVen.EjecutarComandoSQL("Insert into TPDImpuesto Select '" & oTransProdDevolucion.TransProdId & "', TransProdDetalleId, TPDImpuestoID, ImpuestoClave, ImpuestoPor, ImpuestoImp, ImpuestoPU,ImpDesGlb, getdate() as MFechaHora,'" & oVendedor.UsuarioId & "', 0 as Enviado from TPDImpuesto where TransProdID='" & paroTransProd.TransProdId & "'")

            If Not IsNothing(oTransProdNota) Then
                'Insertar los impuestos
                oDBVen.EjecutarComandoSQL("Insert into TPDImpuesto Select '" & oTransProdNota.TransProdId & "', TransProdDetalleId, TPDImpuestoID, ImpuestoClave, ImpuestoPor, ImpuestoImp, ImpuestoPU,ImpDesGlb, getdate() as MFechaHora,'" & oVendedor.UsuarioId & "', 0 as Enviado from TPDImpuesto where TransProdID='" & paroTransProd.TransProdId & "'")

                Dim dtCentroExpedicion As DataTable = oDBVen.RealizarConsultaSQL("select ce.* from centroexpedicion ce inner join foliofiscal ff on ff.centroexpid=ce.centroexpid where ff.folioid = '" & oFolioFiscal.FolioID & "' and ff.fosid='" & oFolioFiscal.FosID & "' and ce.SubEmpresaID='" & oTransProdNota.SubEmpresaActual.SubEmpresaId & "' ", "CentroExpedicion")
                Dim dtCentroExpedicionPadre As DataTable
                If dtCentroExpedicion.Rows(0)("Tipo") = 1 Then
                    dtCentroExpedicionPadre = oDBVen.RealizarConsultaSQL("select * from centroexpedicion where centroexpid='" & dtCentroExpedicion.Rows(0)("CentroExpPadreID") & "' and tipo=0", "CentroExpedicion")
                Else
                    dtCentroExpedicionPadre = dtCentroExpedicion.Copy
                End If

                'Dim dtTRPDatoFiscal As DataTable = oDBVen.RealizarConsultaSQL("Select * from TRPDatoFiscal where TransProdID='" & oTransProdNota.FacturaId & "'", "TRPDatoFiscal")

                'If dtTRPDatoFiscal.Rows.Count > 0 Then
                Dim iTipoVersion As Integer = CType(SubEmpresa.aSubEmpresa(0), SubEmpresa.DatosEmpresa).VersionCFD
                Dim sVersionCFD As String = ValorReferencia.BuscarEquivalente("VERFACTE", iTipoVersion)

                Dim oTRPDatoFiscal As New TRPDatoFiscal
                With oTRPDatoFiscal
                    .TransProdID = oTransProdNota.TransProdId
                    .FolioID = oFolioFiscal.FolioID
                    .FOSId = oFolioFiscal.FosID
                    .NumCertificado = oFolioFiscal.NumCertificado
                    .Serie = oFolioFiscal.Serie
                    .Aprobacion = oFolioFiscal.Aprobacion
                    .AnioAprobacion = oFolioFiscal.AnioAprobacion
                    .TipoVersion = sVersionCFD
                    If bFacturaVirtual Then
                        Dim dtClienteDom As DataTable = oDBVen.RealizarConsultaSQL("Select * from ClienteDomicilio Where tipo=1 and ClienteClave='" & paroTransProd.ClienteActual.ClienteClave & "'", "Domiclio")
                        .RazonSocial = paroTransProd.ClienteActual.RazonSocial
                        .RFC = paroTransProd.ClienteActual.IdFiscal
                        .TelefonoContacto = paroTransProd.ClienteActual.TelefonoContacto
                        If dtClienteDom.Rows.Count > 0 Then
                            .Calle = dtClienteDom.Rows(0)("Calle")
                            .NumExt = dtClienteDom.Rows(0)("Numero")
                            .NumInt = dtClienteDom.Rows(0)("NumInt")
                            .Colonia = dtClienteDom.Rows(0)("Colonia")
                            .Localidad = dtClienteDom.Rows(0)("Localidad")
                            .Municipio = dtClienteDom.Rows(0)("Poblacion")
                            .Entidad = dtClienteDom.Rows(0)("Entidad")
                            .Pais = dtClienteDom.Rows(0)("Pais")
                            .CodigoPostal = dtClienteDom.Rows(0)("CodigoPostal")
                            .ReferenciaDom = dtClienteDom.Rows(0)("ReferenciaDom")
                        End If
                    Else
                        Dim dtTRPDatoFiscal As DataTable = oDBVen.RealizarConsultaSQL("Select * from TRPDatoFiscal where TransProdID='" & oTransProdNota.FacturaId & "'", "TRPDatoFiscal")

                        If dtTRPDatoFiscal.Rows.Count > 0 Then
                            .RazonSocial = dtTRPDatoFiscal.Rows(0)("RazonSocial").ToString
                            .RFC = dtTRPDatoFiscal.Rows(0)("RFC").ToString
                            .TelefonoContacto = dtTRPDatoFiscal.Rows(0)("TelefonoContacto").ToString
                            .Calle = dtTRPDatoFiscal.Rows(0)("Calle").ToString
                            .NumExt = dtTRPDatoFiscal.Rows(0)("NumExt").ToString
                            .NumInt = dtTRPDatoFiscal.Rows(0)("NumInt").ToString
                            .Colonia = dtTRPDatoFiscal.Rows(0)("Colonia").ToString
                            .CodigoPostal = dtTRPDatoFiscal.Rows(0)("CodigoPostal").ToString
                            .ReferenciaDom = dtTRPDatoFiscal.Rows(0)("ReferenciaDom").ToString
                            .Localidad = dtTRPDatoFiscal.Rows(0)("Localidad").ToString
                            .Municipio = dtTRPDatoFiscal.Rows(0)("Municipio").ToString
                            .Entidad = dtTRPDatoFiscal.Rows(0)("Entidad").ToString
                            .Pais = dtTRPDatoFiscal.Rows(0)("Pais").ToString
                        End If
                    End If

                    .TelefonoEm = oTransProdNota.SubEmpresaActual.Telefono
                    .RFCEm = dtCentroExpedicionPadre.Rows(0)("RFC").ToString
                    .NombreEm = dtCentroExpedicionPadre.Rows(0)("Nombre").ToString
                    .CalleEm = dtCentroExpedicionPadre.Rows(0)("Calle")
                    .NumExtEm = dtCentroExpedicionPadre.Rows(0)("NumExt")
                    .NumIntEm = dtCentroExpedicionPadre.Rows(0)("NumInt")
                    .ColoniaEm = dtCentroExpedicionPadre.Rows(0)("Colonia")
                    .LocalidadEm = dtCentroExpedicionPadre.Rows(0)("Localidad")
                    .ReferenciaDomEm = dtCentroExpedicionPadre.Rows(0)("ReferenciaDom")
                    .MunicipioEm = dtCentroExpedicionPadre.Rows(0)("Municipio")
                    .RegionEm = dtCentroExpedicionPadre.Rows(0)("Entidad")
                    .PaisEm = dtCentroExpedicionPadre.Rows(0)("Pais")
                    .CodigoPostalEm = dtCentroExpedicionPadre.Rows(0)("CodigoPostal")

                    .CalleEx = dtCentroExpedicion.Rows(0)("Calle")
                    .NumExtEx = dtCentroExpedicion.Rows(0)("NumExt")
                    .NumIntEx = dtCentroExpedicion.Rows(0)("NumInt")
                    .ColoniaEx = dtCentroExpedicion.Rows(0)("Colonia")
                    .CodigoPostalEx = dtCentroExpedicion.Rows(0)("CodigoPostal")
                    .ReferenciaDomEx = dtCentroExpedicion.Rows(0)("ReferenciaDom")
                    .LocalidadEx = dtCentroExpedicion.Rows(0)("Localidad")
                    .MunicipioEx = dtCentroExpedicion.Rows(0)("Municipio")
                    .EntidadEx = dtCentroExpedicion.Rows(0)("Entidad")
                    .PaisEx = dtCentroExpedicion.Rows(0)("Pais")
                    .TipoNotaCredito = 2
                    .LugarExpedicion = IIf(dtCentroExpedicion.Rows(0)("Municipio").ToString = "", dtCentroExpedicionPadre.Rows(0)("Municipio").ToString & ", " & dtCentroExpedicionPadre.Rows(0)("Entidad").ToString, dtCentroExpedicion.Rows(0)("Municipio").ToString & ", " & dtCentroExpedicion.Rows(0)("Entidad").ToString)
                    .FormaDePago = "Pago en una sola exhibición"
                    .CerBase64 = oTransProdNota.SubEmpresaActual.CerBase64

                    Dim dtRegimenFiscal As DataTable
                    If bFacturaVirtual Then
                        dtRegimenFiscal = oDBVen.RealizarConsultaSQL("select TipoRegimen as Descripcion from CEERegimenFiscal where CentroExpId = '" & dtCentroExpedicionPadre.Rows(0)("CentroExpID") & "'", "CEERegimenFiscal")
                    Else
                        dtRegimenFiscal = oDBVen.RealizarConsultaSQL("select Descripcion from TRPRegimenFiscal where TransProdID = '" & oTransProdNota.FacturaId & "'", "TRPRegimenFiscal")
                    End If
                    For Each dr As DataRow In dtRegimenFiscal.Rows
                        Dim oTRPRegimenFiscal As TRPRegimenFiscal = New TRPRegimenFiscal
                        oTRPRegimenFiscal.TransProdID = oTRPDatoFiscal.TransProdID
                        oTRPRegimenFiscal.RegimenFiscalID = oApp.KEYGEN(1)
                        oTRPRegimenFiscal.Descripcion = dr("Descripcion")
                        .TRPRegimenFiscal.Add(oTRPRegimenFiscal.Descripcion, oTRPRegimenFiscal)
                    Next

                    Dim nTipoNoIdent As Integer = 0
                    Dim aGrupo As New ArrayList
                    aGrupo.Add("NI")
                    Dim aValor As ArrayList = ValorReferencia.RecuperaVARVGrupo("PAGO", aGrupo)
                    If aValor.Count > 0 Then
                        nTipoNoIdent = CType(aValor(0), ValorReferencia.Descripcion).Id
                    End If

                    .MetodoPago = ValorReferencia.BuscarEquivalente("PAGO", nTipoNoIdent)
                    .MetodoPagoFinal = .MetodoPago

                    'Cambiar la factura a fase de devolucion Total
                    oDBVen.EjecutarComandoSQL("UPDATE TransProd set TipoFase='" & ServicesCentral.TiposFasesPedidos.DevolucionTotal & "', FechaCancelacion = getdate(), MFechaHora=getdate(), MUsuarioID='" & oVendedor.UsuarioId & "' where TransProdID ='" & paroTransProd.FacturaId & "'")

                    Dim sCadenaOriginal As String = .CrearCadenaOriginalM(oTransProdNota, oTransProdNota.TransProdId, paroTransProd.ClienteActual.ClienteClave, False)
                    sCadenaOriginal = sCadenaOriginal.Replace("&", amp)
                    sCadenaOriginal = sCadenaOriginal.Replace("<", lt)
                    sCadenaOriginal = sCadenaOriginal.Replace(">", gt)
                    sCadenaOriginal = sCadenaOriginal.Replace("'", apos)
                    sCadenaOriginal = sCadenaOriginal.Replace("""", quot)
                    .CadenaOriginal = sCadenaOriginal
                    .Insertar()

                    Dim strError As String
                    FolioFiscal.ActualizarFolioFiscal(.FolioID, .FOSId, strError)
                End With
            End If
            'End If
            DataTableDetalle.Dispose()

            If oVendedor.motconfiguracion.MensajeImpresion Then
                If MsgBox("[P0103] ¿ Desea imprimir el ticket ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                    If Not IsNothing(oTransProdNota) AndAlso Not IsDBNull(oTransProdNota) Then
                        ImprimirTicketSinForma(FormImpresionTickets.ModoImpresion.ConVisita, oTransProdNota.TransProdId, 10, 30, pvCliente, oTransProdNota.VisitaActual)
                    End If
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function
    Public Shared Function CancelarPedido(ByVal parsTransProdID As String, ByVal partModuloMovDetalle As ServicesCentral.TiposModulosMovDet, ByVal pvCliente As Cliente, Optional ByVal parsVisitaActual As String = "") As Boolean
        Try
            Dim DataTableDetalle As DataTable = oDBVen.RealizarConsultaSQL("SELECT ProductoClave,TipoUnidad,Cantidad,Cantidad1,case isnull(PrestamoVendido) when 1 then 0 else PrestamoVendido end as PrestamoVendido,CodigoSKU FROM TransProdDetalle WHERE TransProdID='" & parsTransProdID & "' ORDER BY Partida", "Detalle")
            Dim sProductoClave As String
            Dim iTipoUnidad As Integer
            Dim dCantidad As Decimal
            Dim dCantidad1 As Decimal
            Dim dPrestamoVendido As Decimal
            'Dim iFactor As Integer
            Dim TempTransprod As New TransProd()
            TempTransprod.TransProdId = parsTransProdID
            TempTransprod.Recuperar()

            'Regresar el inventario solo si no es movimiento sin inventario en visita
            If partModuloMovDetalle <> ServicesCentral.TiposModulosMovDet.MovSinInvConVis Then
                For Each refDataRow As DataRow In DataTableDetalle.Rows
                    Dim bVenta As Boolean = False
                    With refDataRow
                        sProductoClave = .Item("ProductoClave")
                        iTipoUnidad = .Item("TipoUnidad")
                        dCantidad = .Item("Cantidad")
                        dCantidad1 = .Item("Cantidad1")
                        dPrestamoVendido = .Item("PrestamoVendido")

                        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion And TempTransprod.TipoFase = ServicesCentral.TiposFasesPedidos.Captura And TempTransprod.VisitaActual <> parsVisitaActual Then
                            SKUInventario.ActualizarSKU(SKUInventario.SKUMovimiento.Apartar, .Item("CodigoSKU").ToString, sProductoClave, iTipoUnidad, (-1) * dCantidad, (-1) * dCantidad1)
                        ElseIf oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion And TempTransprod.VisitaActual = parsVisitaActual Then
                            SKUInventario.ActualizarSKU(SKUInventario.SKUMovimiento.Incrementar, .Item("CodigoSKU").ToString, sProductoClave, iTipoUnidad, dCantidad, dCantidad1)
                        End If

                    End With


                Next
            End If

            Dim sComandoSQL As New System.Text.StringBuilder
            sComandoSQL.Append("UPDATE TransProd SET ")
            If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion And parsVisitaActual <> "" Then
                sComandoSQL.Append("VisitaClave1='" & parsVisitaActual & "',")
                sComandoSQL.Append("DiaClave1='" & oDia.DiaActual & "',")
            End If
            sComandoSQL.Append("FechaCancelacion=" & UniFechaSQL(Now) & ",")
            sComandoSQL.Append("TipoFase=" & ServicesCentral.TiposFasesPedidos.Cancelado & ", ")
            sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ", ")
            sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "', ")
            sComandoSQL.Append("Enviado=0 ")
            sComandoSQL.Append("WHERE TransProdID='" & parsTransProdID & "'")
            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
            DataTableDetalle.Dispose()

            'Borrar pedido de Fondo Cristal
            Dim dtFondoCristal As DataTable = oDBVen.RealizarConsultaSQL("SELECT TransProd.TransProdID,ProductoClave,TipoUnidad, Cantidad FROM TransProdDetalle inner join TransProd on TransProd.TransProdID = TransProdDetalle.TransProdID WHERE FacturaID='" & parsTransProdID & "' and Tipo = " & ServicesCentral.TiposTransProd.FondoCristal, "Detalle")

            Dim sTransProdIdFC As String = String.Empty
            For Each refDataRow As DataRow In dtFondoCristal.Rows
                With refDataRow
                    If sTransProdIdFC = String.Empty Then
                        sTransProdIdFC = .Item("TransProdID")
                    End If
                    If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Preventa AndAlso oAgenda.RutaActual.Inventario Then
                        Inventario.ActualizarInventarioDec(.Item("ProductoClave"), .Item("TipoUnidad"), -1 * .Item("Cantidad"), ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId, True)
                    ElseIf oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta Then
                        Inventario.ActualizarInventarioDec(.Item("ProductoClave"), .Item("TipoUnidad"), .Item("Cantidad"), ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId, True)
                    Else
                        Inventario.ActualizarInventarioDec(.Item("ProductoClave"), .Item("TipoUnidad"), .Item("Cantidad"), ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.NoDefinido, oVendedor.AlmacenId, True)
                    End If
                End With
            Next
            ' Borrar los registros creados con los productos de Fondo Cristal
            'oDBVen.EjecutarComandoSQL("DELETE FROM TPDImpuesto where TransProdDetalleID in(Select TransProdDetalle.TransProdDetalleID from TransProdDetalle WHERE TransProdDetalle.TransProdID='" & parsTransProdID & "' AND TransProdDetalle.Promocion=1 AND TransProdDetalle.Total=0) ")
            If sTransProdIdFC <> String.Empty Then
                oDBVen.EjecutarComandoSQL("DELETE FROM TransProdDetalle WHERE TransProdID='" & sTransProdIdFC & "' ")
                oDBVen.EjecutarComandoSQL("DELETE FROM TransProd WHERE FacturaID='" & parsTransProdID & "' ")
            End If

            Return oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Public Shared Function SurtirPedido(ByVal parsTransProdID As String, Optional ByVal pvClienteActual As Cliente = Nothing) As Boolean
        Try
            ' Actualizar el inventario
            'Dim DataTableDetalle As DataTable = oDBVen.RealizarConsultaSQL("SELECT ProductoClave,TipoUnidad,Cantidad,case isnull(PrestamoVendido) when 1 then 0 else PrestamoVendido end as PrestamoVendido FROM TransProdDetalle WHERE TransProdID='" & parsTransProdID & "' ORDER BY Partida", "Detalle")
            Dim sProductoClave As String
            Dim iTipoUnidad As Integer
            Dim dCantidad As Decimal
            'Dim iPrestamoVendido As Integer

            'For Each refDataRow As DataRow In DataTableDetalle.Rows
            '    With refDataRow

            '        sProductoClave = .Item("ProductoClave")
            '        iTipoUnidad = .Item("TipoUnidad")
            '        dCantidad = .Item("Cantidad")
            '        iPrestamoVendido = .Item("PrestamoVendido")

            '        If Not pvClienteActual Is Nothing AndAlso pvClienteActual.Prestamo Then
            '            Inventario.ActualizarInventarioDec(sProductoClave, iTipoUnidad, dCantidad, ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, , , , pvClienteActual.ClienteClave)
            '        Else
            '            Inventario.ActualizarInventarioDec(sProductoClave, iTipoUnidad, dCantidad, ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId)
            '        End If

            '        'Crear Saldo de Envases del Cliente
            '        If Not pvClienteActual Is Nothing AndAlso pvClienteActual.Prestamo Then
            '            If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
            '                ProductoPrestamoCli.ActulizarProductoPrestamoCli(pvClienteActual.ClienteClave, sProductoClave, dCantidad, iTipoUnidad, 2, ServicesCentral.TiposTransProd.Pedido, 0)
            '            Else
            '                ProductoPrestamoCli.ActulizarProductoPrestamoCli(pvClienteActual.ClienteClave, sProductoClave, dCantidad, iTipoUnidad, 2, ServicesCentral.TiposTransProd.Pedido, 1)
            '            End If
            '        End If

            '    End With
            'Next
            Dim sComandoSQL As New System.Text.StringBuilder
            sComandoSQL.Append("UPDATE TransProd SET ")
            sComandoSQL.Append("FechaSurtido=" & UniFechaSQL(PrimeraHora(Now)) & ",")
            sComandoSQL.Append("TipoMovimiento=" & ServicesCentral.TiposMovimientos.Salida & ",")
            sComandoSQL.Append("TipoFase=" & ServicesCentral.TiposFasesPedidos.Surtido & ", ")
            If oConHist.Campos("CobrarVentas") Then
                sComandoSQL.Append("Saldo=Total, ")
            End If
            sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ", ")
            sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "', ")
            sComandoSQL.Append("Enviado=0 ")
            sComandoSQL.Append("WHERE TransProdID='" & parsTransProdID & "'")
            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
            'DataTableDetalle.Dispose()

            'Actualizar Inventario Fondo Cristal
            Dim DataTableFondoCristal As DataTable = oDBVen.RealizarConsultaSQL("SELECT TransProd.TransProdID,ProductoClave,TipoUnidad, Cantidad FROM TransProdDetalle inner join TransProd on TransProd.TransProdID = TransProdDetalle.TransProdID WHERE FacturaID='" & parsTransProdID & "' and Tipo = " & ServicesCentral.TiposTransProd.FondoCristal, "Detalle")
            If DataTableFondoCristal.Rows.Count > 0 Then
                Dim sTransProdIDFondoCristal As String = String.Empty
                For Each refDataRow As DataRow In DataTableFondoCristal.Rows
                    With refDataRow
                        If sTransProdIDFondoCristal = String.Empty Then
                            sTransProdIDFondoCristal = .Item("TransProdID")
                        End If
                        sProductoClave = .Item("ProductoClave")
                        iTipoUnidad = .Item("TipoUnidad")
                        dCantidad = .Item("Cantidad")
                        Inventario.ActualizarInventarioDec(sProductoClave, iTipoUnidad, dCantidad, ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId)
                    End With
                Next
                sComandoSQL = New System.Text.StringBuilder
                sComandoSQL.Append("UPDATE TransProd SET ")
                sComandoSQL.Append("FechaSurtido=" & UniFechaSQL(PrimeraHora(Now)) & ",")
                sComandoSQL.Append("TipoMovimiento=" & ServicesCentral.TiposMovimientos.Salida & ",")
                sComandoSQL.Append("TipoFase=" & ServicesCentral.TiposFasesPedidos.Surtido & ", ")
                sComandoSQL.Append("Saldo=Total, ")
                sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ", ")
                sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "', ")
                sComandoSQL.Append("Enviado=0 ")
                sComandoSQL.Append("WHERE TransProdID='" & sTransProdIDFondoCristal & "'")
                oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
            End If
            DataTableFondoCristal.Dispose()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Public Function VentaCobrada() As Boolean
        Dim iAbonos As Integer = oDBVen.EjecutarCmdScalarIntSQL("Select count(*) from AbnTrp where TransProdID='" & Me.TransProdId & "'")
        If iAbonos > 0 Then
            Return True
        End If
        Return False
    End Function


    Public Sub ActualizarSaldo(ByVal pardImporte As Double)
        Dim strSQLTransProd As New System.Text.StringBuilder

        With strSQLTransProd
            .Append("Update TransProd set Saldo=Round((Saldo)+(")
            .Append(pardImporte & "),2)")
            .Append(",MfechaHora=getdate(),MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 Where TransProdID='" & Me.TransProdId & "'")
        End With


        oDBVen.EjecutarComandoSQL(strSQLTransProd.ToString)
    End Sub

    Public Sub ActualizarPLIId()
        Dim strSQLTransProd As New System.Text.StringBuilder
        With strSQLTransProd
            .Append("Update TransProd set PLIId = " & IIf(Me.PLIId Is Nothing Or Me.PLIId = "", " null ", "'" & Me.PLIId & "'") & ", ")
            .Append("MfechaHora = getdate(), MUsuarioID = '" & oVendedor.UsuarioId & "', Enviado = 0 Where TransProdID = '" & Me.TransProdId & "'")
        End With
        oDBVen.EjecutarComandoSQL(strSQLTransProd.ToString)
    End Sub

    Public Function PendientesSurtidos() As Boolean
        Dim sConsulta As String
        sConsulta = "select count(*) as Total from ProductoNegado where not PromocionClave is null and TipoFasePrp > 1 and TransProdId = '" & Me.TransProdId & "'"
        Return oDBVen.RealizarScalarSQL(sConsulta) > 0
    End Function

#Region "ImpuestosConDesc"
    Public Function PermiteCascada(ByVal pvCondicion As String) As Boolean
        Dim vlconsulta As New System.Text.StringBuilder
        vlconsulta.Append("select permitecascada from descuento where descuentoclave in " & _
        "(select DescuentoClave from descliente where clienteclave in " & _
        "(select Clienteclave from transprod trp " & pvCondicion & ") )")
        Dim ldt As DataTable = oDBVen.RealizarConsultaSQL(vlconsulta.ToString, "tpdimpuesto")
        If ldt Is Nothing Then
            ldt = Nothing
            Return False
        End If

        If ldt.Rows.Count <= 0 Then
            ldt = Nothing
            Return False
        End If
        For Each row As DataRow In ldt.Rows
            If row("permitecascada") = 1 Then
                ldt = Nothing
                Return True
            End If
        Next

        Return False
    End Function
    Public Shared Sub ImpuestosConDesc(ByVal sFacturaId As String, ByVal sClienteClave As String, ByRef OP_Impuesto As ArrayList, ByRef OP_Tasa As ArrayList, ByRef OP_Importe As ArrayList)
        Dim dt As DataTable = oDBVen.RealizarConsultaSQL("SELECT TransProdId FROM TransProd WHERE FacturaId = '" + sFacturaId + "'", "TransProd")

        Dim lTrp As New ArrayList()
        For Each fila As DataRow In dt.Rows
            lTrp.Add(fila(0).ToString())
        Next
        ImpuestosConDesc(lTrp, sClienteClave, OP_Impuesto, OP_Tasa, OP_Importe)
    End Sub

    Public Shared Sub ImpuestosConDesc(ByVal IP_TransProdID As ArrayList, ByVal IP_ClienteClave As String, ByRef OP_Impuesto As ArrayList, ByRef OP_Tasa As ArrayList, ByRef OP_Importe As ArrayList)
        'Dim vlCondicion As New System.Text.StringBuilder
        Dim vlConsulta As New System.Text.StringBuilder
        Dim vldt As DataTable

        OP_Impuesto = New ArrayList
        OP_Tasa = New ArrayList
        OP_Importe = New ArrayList

        Dim sFiltro As String
        sFiltro = " TRP.TransProdId in ("
        For i As Integer = 0 To IP_TransProdID.Count - 1
            sFiltro &= "'" & IP_TransProdID.Item(i) & "',"
        Next
        sFiltro = sFiltro.Remove(sFiltro.Length - 1, 1)
        sFiltro &= ") "

        vlConsulta.Append("select IMP.ImpuestoClave, IMP.Abreviatura, TDI.ImpuestoPor, sum(TDI.ImpDesGlb) as ImpDesGlb ")
        vlConsulta.Append("from TPDImpuesto TDI ")
        vlConsulta.Append("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ")
        vlConsulta.Append("inner join Impuesto IMP on TDI.ImpuestoClave = IMP.ImpuestoClave ")
        vlConsulta.Append("where " & sFiltro & "  ")
        vlConsulta.Append("and TDI.ImpuestoClave not in ( ")
        vlConsulta.Append("select ImpuestoClave ")
        vlConsulta.Append("from CLINoDesImp ")
        vlConsulta.Append("where ClienteClave = '" & IP_ClienteClave & "' and getdate() between FechaInicio and FechaFin ) ")
        vlConsulta.Append("group by IMP.ImpuestoClave, IMP.Abreviatura, TDI.ImpuestoPor, IMP.Jerarquia ")
        vlConsulta.Append("order by IMP.Jerarquia ")
        vldt = oDBVen.RealizarConsultaSQL(vlConsulta.ToString, "TPDImpuesto")

        For Each row As DataRow In vldt.Rows
            OP_Impuesto.Add(row("Abreviatura"))
            OP_Tasa.Add(row("ImpuestoPor"))
            OP_Importe.Add(row("ImpDesGlb"))
        Next
        vldt.Dispose()
        vldt = Nothing

    End Sub
#End Region

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
