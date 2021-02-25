Imports System.Data.SqlServerCe
Public Class TransProdDetalle
    Implements IDisposable

    Public Enum TiposAplicacionDescuentosProductos
        NoDefinido = 0
        PorProducto = 1
        PorEsquema = 2
    End Enum

    Protected sTransProdID As String
    Protected sTransProdDetalleID As String
    Protected sProductoClave As String
    Protected sDescuentoClave As String
    Protected iTipoUnidad As Integer
    Protected iPartida As Integer
    Protected iUnidadCobranza As Integer
    Protected iPromocion As Short
    Protected nCantidad As Decimal
    Protected nCantidad1 As Decimal
    Protected nFactor As Decimal
    Protected nFactor1 As Decimal
    Protected nPrecio As Decimal
    Protected oPrecioSinFactor As Precio
    Protected nDescuentoPor As Decimal
    Protected nDescuentoImp As Decimal
    Protected nSubTotal As Decimal
    Protected nImpuesto As Decimal
    Protected nTotal As Decimal
    Protected sPRGId As String
    Protected sPromocionClave As String
    Protected sCodigoSKU As String
    Protected iTipoMotivo As Integer

    Public Property TransProdID() As String
        Get
            Return sTransProdID
        End Get
        Set(ByVal Value As String)
            sTransProdID = Value
        End Set
    End Property
    Public Property TransProdDetalleID() As String
        Get
            Return sTransProdDetalleID
        End Get
        Set(ByVal Value As String)
            sTransProdDetalleID = Value
        End Set
    End Property
    Public Property ProductoClave() As String
        Get
            Return sProductoClave
        End Get
        Set(ByVal Value As String)
            sProductoClave = Value
        End Set
    End Property
    Public Property DescuentoClave() As String
        Get
            Return sDescuentoClave
        End Get
        Set(ByVal Value As String)
            sDescuentoClave = Value
        End Set
    End Property
    Public Property TipoUnidad() As Integer
        Get
            Return iTipoUnidad
        End Get
        Set(ByVal Value As Integer)
            iTipoUnidad = Value
        End Set
    End Property
    Public Property Partida() As Integer
        Get
            Return iPartida
        End Get
        Set(ByVal Value As Integer)
            iPartida = Value
        End Set
    End Property
    Public Property UnidadCobranza() As Integer
        Get
            Return iUnidadCobranza
        End Get
        Set(ByVal value As Integer)
            iUnidadCobranza = value
        End Set
    End Property
    Public Property Promocion() As Short
        Get
            Return iPromocion
        End Get
        Set(ByVal Value As Short)
            iPromocion = Value
        End Set
    End Property
    Public Property Cantidad() As Decimal
        Get
            Return Decimal.Round(nCantidad, 2)
        End Get
        Set(ByVal Value As Decimal)
            nCantidad = Value
        End Set
    End Property

    Public Property Cantidad1() As Decimal
        Get
            Return Decimal.Round(nCantidad1, 2)
        End Get
        Set(ByVal Value As Decimal)
            nCantidad1 = Value
        End Set
    End Property
    Public Property Factor() As Decimal
        Get
            Return Decimal.Round(nFactor, 4)
        End Get
        Set(ByVal value As Decimal)
            nFactor = value
        End Set
    End Property

    Public Property Factor1() As Decimal
        Get
            Return Decimal.Round(nFactor1, 4)
        End Get
        Set(ByVal value As Decimal)
            nFactor1 = value
        End Set
    End Property

    Public Property Precio() As Decimal
        Get
            Return Decimal.Round(nPrecio, oConHist.Campos("DecimalesImporte"))
        End Get
        Set(ByVal Value As Decimal)
            nPrecio = Value
        End Set
    End Property
    Public Property PrecioSinFactor() As Precio
        Get
            Return oPrecioSinFactor
        End Get
        Set(ByVal Value As Precio)
            oPrecioSinFactor = Value
        End Set
    End Property
    Public Property DescuentoPor() As Decimal
        Get
            Return Decimal.Round(nDescuentoPor, 4)
        End Get
        Set(ByVal Value As Decimal)
            nDescuentoPor = Value
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
    Public Property SubTotal() As Decimal
        Get
            Return RedondeoAritmetico(nSubTotal, 2)
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
    Public Property Total() As Decimal
        Get
            Return RedondeoAritmetico(nTotal, 2)
        End Get
        Set(ByVal Value As Decimal)
            nTotal = Value
        End Set
    End Property
    Public Property PRGId() As String
        Get
            Return sPRGId
        End Get
        Set(ByVal value As String)
            sPRGId = value
        End Set
    End Property
    Public Property PromocionClave() As String
        Get
            Return sPromocionClave
        End Get
        Set(ByVal value As String)
            sPromocionClave = value
        End Set
    End Property
    Public Property CodigoSKU() As String
        Get
            Return sCodigoSKU
        End Get
        Set(ByVal value As String)
            sCodigoSKU = value
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

    Public ReadOnly Property ListaImpuestos() As String
        Get
            Return MobileClient.Impuesto.ObtenerCadenaIDsImpuestos(Me.aImpuestos)
        End Get
    End Property
    Public ReadOnly Property TipoAplicacionDescuentos() As TiposAplicacionDescuentosProductos
        Get
            Return Me.tTipoAplicacionDescuentos
        End Get
    End Property

    Public ReadOnly Property LImpuestos() As ArrayList
        Get
            Return aImpuestos
        End Get
    End Property

    Protected aImpuestos As ArrayList
    Protected oDescuentoProducto As Descuento
    Protected tTipoAplicacionDescuentos As TiposAplicacionDescuentosProductos = TiposAplicacionDescuentosProductos.NoDefinido

    Public Sub New(ByVal parsTransProdID As String, ByVal parsProductoClave As String, ByVal pariPartida As Integer)
        Me.TransProdID = parsTransProdID
        Me.ProductoClave = parsProductoClave
        Me.Partida = pariPartida
    End Sub

    Public Function ObtenerID() As Boolean
        ' Obtener un nuevo folio
        If Me.TransProdDetalleID = "" Then
            Return Folio.ObtenerTransProdDetalleId(Me.TransProdID, Me.TransProdDetalleID)
        End If
        Return True
    End Function

    Public Function ObtenerListaImpuestos(ByRef refparoImpuesto As Impuesto, ByVal pariTipoImpuesto As Integer) As Boolean
        aImpuestos = New ArrayList
        Return refparoImpuesto.Buscar(Me.ProductoClave, pariTipoImpuesto, aImpuestos)
    End Function

    'Huicho (27/07/2006) - Función para eliminar los impuestos que no cumplen con el campo ValidaRFC
    Public Function ValidarImpuestos(ByVal pvCliente As Cliente) As Boolean
        If pvCliente.IdFiscal = Nothing OrElse pvCliente.IdFiscal = String.Empty Then
            For Each loImpuesto As Impuesto In aImpuestos
                If loImpuesto.ValidaRFC Then
                    loImpuesto.ValidaRFC = False
                    'TODO: Truena en el remove, revisar si se puede hacer de otra manera
                    'aImpuestos.Remove(loImpuesto)
                End If
            Next
        End If
    End Function

    Public Function ObtenerTipoAplicacionDescuentos(ByVal parsModuloMovDetClave As String, ByVal parbEsNuevo As Boolean) As Boolean
        oDescuentoProducto = New Descuento
        ' Asignar esta propiedad para restringir la bùsqueda de registros en los descuentos
        oDescuentoProducto.EsNuevo = parbEsNuevo
        ' Si se aplican descuentos por producto en el modulo
        If Descuento.VerificarAplicacion(parsModuloMovDetClave, "AplicaProducto") Then
            ' Si hay descuentos por producto 
            If oDescuentoProducto.BuscarAplicablesAlProductoPorProducto(Me.ProductoClave, Me.TipoUnidad, Me.Cantidad, oDescuentoProducto) Then
                ' Calcular los descuentos por producto
                tTipoAplicacionDescuentos = TiposAplicacionDescuentosProductos.PorProducto
            Else
                ' Si hay descuentos por esquemas al producto
                If oDescuentoProducto.BuscarAplicablesAlProductoPorEsquema(Me.ProductoClave, oDescuentoProducto) Then
                    ' Calcular los descuentos por esquema al producto
                    tTipoAplicacionDescuentos = TiposAplicacionDescuentosProductos.PorEsquema
                End If
            End If
        End If
    End Function

    Public Function ObtenerPrecio(ByRef refparoListaPrecios As ListasPreciosCliente) As Boolean
        'Cuando se quiera usar sera necesario cambiar en las actividades para que busque rangos
        'Return refparoListaPrecios.BuscarPrecio(Me.ProductoClave, Me.TipoUnidad, Me.PrecioSinFactor)
        Return False
        '<\13-Jun-2006>
    End Function
    Public Shared Function ObtenerPrecioRango(ByRef refparoListasPrecios As ListasPreciosCliente, ByVal parsProductoClave As String, ByVal pardCantidad1 As Decimal) As Precio
        Return refparoListasPrecios.BuscarPrecioRango(parsProductoClave, pardCantidad1)
    End Function

    Public Function ObtenerPrecioRango(ByRef refparoListasPrecios As ListasPreciosCliente) As Precio
        Return refparoListasPrecios.BuscarPrecioRango(Me.ProductoClave, Me.Cantidad1)
    End Function

    Public Function ActualizarDec(ByVal parsTransProdDetalleID As String, ByVal partTipoTransProd As ServicesCentral.TiposTransProd, ByRef refparoImpuesto As Impuesto, ByVal pardCantidadActual As Decimal, ByVal pardCantidadAnterior As Decimal, ByVal pariTipoUnidad As Integer, ByVal pariFactor As Integer, ByVal pariTipoMovimiento As ServicesCentral.TiposMovimientos, Optional ByVal parCliente As Cliente = Nothing, Optional ByRef DTProductoPrestamoCli As DataTable = Nothing) As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        Dim nBase As Decimal = 0
        Try
            Me.TransProdDetalleID = parsTransProdDetalleID
            Me.Cantidad = pardCantidadActual
            Me.TipoUnidad = pariTipoUnidad
            ' Si la cantidad es cero
            If Me.Cantidad = 0 Then
                ' Si ya estaba capturado
                If Me.TransProdDetalleID <> "" Then
                    ' Borrar los impuestos 
                    oDBVen.EjecutarComandoSQL("DELETE FROM TPDImpuesto WHERE TransProdId='" & Me.TransProdID & "' AND TransProdDetalleID='" & Me.TransProdDetalleID & "'")
                    oDBVen.EjecutarComandoSQL("DELETE FROM TPDDes WHERE TransProdId='" & Me.TransProdID & "' AND TransProdDetalleID='" & Me.TransProdDetalleID & "'")
                    oDBVen.EjecutarComandoSQL("DELETE FROM TPDDesVendedor WHERE TransProdId='" & Me.TransProdID & "' AND TransProdDetalleID='" & Me.TransProdDetalleID & "'")
                    oDBVen.EjecutarComandoSQL("DELETE FROM TrpPrp WHERE TransProdId='" & Me.TransProdID & "' AND TransProdDetalleID='" & Me.TransProdDetalleID & "'")
                    ' Cancelar el movimiento con la cantidad anterior
                    Dim dPrestamoVendido As Decimal = ProductoPrestamoCli.PrestamoVendido(Me.TransProdID, Me.TransProdDetalleID)
                    Dim iFactor As Integer = ProductoPrestamoCli.Factor(Me.ProductoClave, Me.TipoUnidad)

                    If Not parCliente Is Nothing Then
                        If parCliente.Prestamo Then
                            ProductoPrestamoCli.BorrarProductoPrestamoCliDT(parCliente.ClienteClave, Me.ProductoClave, pardCantidadAnterior, pariTipoUnidad, 2, partTipoTransProd, pariTipoMovimiento, dPrestamoVendido, DTProductoPrestamoCli)
                        End If
                    End If
                    If (pardCantidadAnterior * iFactor) - dPrestamoVendido > 0 Then
                        Dim iUnidadMinima As Integer = ProductoPrestamoCli.PRUTipoUnidadMinima(Me.ProductoClave)
                        Inventario.ActualizarInventarioDec(Me.ProductoClave, iUnidadMinima, (pardCantidadAnterior * iFactor) - dPrestamoVendido, partTipoTransProd, pariTipoMovimiento, oVendedor.AlmacenId, True)
                    End If
                    ' Borrar el detalle
                    Return oDBVen.EjecutarComandoSQL("DELETE FROM TransProdDetalle WHERE TransProdId='" & Me.TransProdID & "' AND TransProdDetalleID='" & Me.TransProdDetalleID & "'")
                End If
            Else
                ' Calcular la base
                If Not IsNothing(Me.PrecioSinFactor) Then
                    Me.Precio = Me.PrecioSinFactor.Precio
                    nBase = (((Me.PrecioSinFactor.Factor * Cantidad) + (Me.PrecioSinFactor.Factor1 * Cantidad1)) * Me.Precio)
                End If

                'Se aplican los descuentos solo si el su
                If nBase > 0 Then
                    Select Case tTipoAplicacionDescuentos
                        Case TiposAplicacionDescuentosProductos.PorProducto
                            oDescuentoProducto.CalcularAplicablesAlProductoPorProducto(oDescuentoProducto, nBase, Me.Cantidad * pariFactor, Me.DescuentoImp)
                        Case TiposAplicacionDescuentosProductos.PorEsquema
                            oDescuentoProducto.CalcularAplicablesAlProductoPorEsquema(oDescuentoProducto, nBase, Me.DescuentoImp)
                    End Select
                End If
                ' Calculo del descuento que corresponde al subtotal
                Me.DescuentoImp = nBase * (Me.DescuentoPor / 100)
                ' Calcular el subtotal
                Me.SubTotal = IIf(nBase - Me.DescuentoImp <= 0, 0, nBase - Me.DescuentoImp)
                'Se guarda el descuento del producto en DescuentoPor
                'Me.DescuentoPor = Me.DescuentoImp
                ' Calcular el importe del impuesto
                Me.Impuesto = refparoImpuesto.Calcular(aImpuestos, Me.SubTotal, Me.Precio)
                ' Calcular el total
                Me.Total = Me.SubTotal + Me.Impuesto
                ' La cantidad es valida, guardarla. Si no estaba capturada
                If Me.TransProdDetalleID = "" Then
                    ' Se guardara el registro
                    Me.ObtenerID()
                    ' Crear la cadena para insertar el valor
                    sComandoSQL.Append("INSERT INTO TransProdDetalle (TransProdID, TransProdDetalleID, ProductoClave,CodigoSKU, DescuentoClave, TipoUnidad, Partida, Unidadcobranza, Promocion, Cantidad, Cantidad1, Factor, Factor1, Precio, DescuentoPor, DescuentoImp, Impuesto, Subtotal, Total,TipoMotivo, Enviado, MFechaHora, MUsuarioID) VALUES (")
                    sComandoSQL.Append("'" & Me.TransProdID & "',")
                    sComandoSQL.Append("'" & Me.TransProdDetalleID & "',")
                    sComandoSQL.Append("'" & Me.ProductoClave & "',")
                    sComandoSQL.Append("'" & Me.CodigoSKU & "',")
                    If Not oDescuentoProducto Is Nothing Then
                        If Not oDescuentoProducto.DescuentoClave Is Nothing Then
                            sComandoSQL.Append("'" & oDescuentoProducto.DescuentoClave & "',") ' DescuentoClave
                        Else
                            sComandoSQL.Append("NULL,") ' DescuentoClave
                        End If
                    Else
                        sComandoSQL.Append("NULL,") ' DescuentoClave
                    End If
                    sComandoSQL.Append(Me.TipoUnidad & ",") ' TipoUnidad
                    sComandoSQL.Append(Me.Partida & ",") ' Partida
                    sComandoSQL.Append(Me.UnidadCobranza & ",") ' UnidadCobranza
                    sComandoSQL.Append(Me.Promocion & ",") ' Promocion
                    sComandoSQL.Append(Me.Cantidad & ",") ' Cantidad
                    sComandoSQL.Append(Me.Cantidad1 & ",") ' Cantidad1
                    sComandoSQL.Append(Me.Factor & ",") ' Factor
                    sComandoSQL.Append(Me.Factor1 & ",") ' Factor1
                    sComandoSQL.Append(Me.Precio & ",") ' Precio (con factor)
                    sComandoSQL.Append(Me.DescuentoPor & ",") ' DescuentoPor
                    sComandoSQL.Append(Me.DescuentoImp & ",") ' DescuentoImp
                    sComandoSQL.Append(Me.Impuesto & ",") ' Impuesto
                    sComandoSQL.Append(Me.SubTotal & ",") ' Subtotal
                    sComandoSQL.Append(Me.Total & ",") ' Total
                    If Me.TipoMotivo = 0 Then
                        sComandoSQL.Append("NULL,") ' TipoMotivo
                    Else
                        sComandoSQL.Append(Me.TipoMotivo & ",") ' TipoMotivo
                    End If
                    sComandoSQL.Append("0,") ' Enviado
                    sComandoSQL.Append(UniFechaSQL(Now) & ",")
                    sComandoSQL.Append("'" & oVendedor.UsuarioId & "')")
                Else
                    ' Actualizar el registro
                    sComandoSQL.Append("UPDATE TransProdDetalle SET ")
                    If Not oDescuentoProducto Is Nothing Then
                        If Not oDescuentoProducto.DescuentoClave Is Nothing Then
                            sComandoSQL.Append("DescuentoClave='" & oDescuentoProducto.DescuentoClave & "',")
                        End If
                    End If
                    sComandoSQL.Append("Promocion=" & Me.Promocion & ",")
                    sComandoSQL.Append("Cantidad=" & Me.Cantidad & ",")
                    sComandoSQL.Append("Cantidad1=" & Me.Cantidad1 & ",")
                    sComandoSQL.Append("Precio=" & Me.Precio & ",")
                    sComandoSQL.Append("DescuentoPor=" & Me.DescuentoPor & ",")
                    sComandoSQL.Append("DescuentoImp=" & Me.DescuentoImp & ",")
                    sComandoSQL.Append("Impuesto=" & Me.Impuesto & ",")
                    sComandoSQL.Append("Subtotal=" & Me.SubTotal & ",")
                    sComandoSQL.Append("Total=" & Me.Total & ",")
                    If Me.TipoMotivo > 0 Then
                        sComandoSQL.Append("TipoMotivo=" & Me.TipoMotivo & ",") ' TipoMotivo
                    Else
                        sComandoSQL.Append("TipoMotivo=NULL,") ' TipoMotivo
                    End If
                    sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",")
                    sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "', ")
                    sComandoSQL.Append("Enviado=0 ")
                    sComandoSQL.Append("WHERE TransProdID='" & Me.TransProdID & "' AND TransProdDetalleID='" & Me.TransProdDetalleID & "'")
                End If
                ' Guardar los productos
                oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
                ' Guardar los impuestos en el detalle
                refparoImpuesto.GuardarDetalle(Me.TransProdID, Me.TransProdDetalleID, aImpuestos)
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Actualizar")
        End Try
        Return False
    End Function

    Public Function CrearDetalleNotaCredito() As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        Try
            ' Crear la cadena para insertar el valor
            sComandoSQL.Append("INSERT INTO TransProdDetalle (TransProdID, TransProdDetalleID,  ProductoClave,CodigoSKU,TipoUnidad, Partida, Cantidad, Cantidad1, Factor, Factor1, Precio, DescuentoPor, DescuentoImp, Subtotal, Impuesto, Total,Enviado, MFechaHora, MUsuarioID) VALUES (")
            sComandoSQL.Append("'" & TransProdID & "',")
            sComandoSQL.Append("'" & TransProdDetalleID & "',")
            sComandoSQL.Append("'" & ProductoClave & "',")
            sComandoSQL.Append("'" & CodigoSKU & "',")
            sComandoSQL.Append(TipoUnidad & ",") ' TipoUnidad
            sComandoSQL.Append(Partida & ",") ' Partida

            sComandoSQL.Append(Cantidad & ",") ' Cantidad
            sComandoSQL.Append(IIf(CodigoSKU = "", Cantidad1, IIf(Cantidad1 = 0, 0, 1)) & ",") ' Cantidad1
            sComandoSQL.Append(Factor & ",") ' Factor
            sComandoSQL.Append(Factor1 & ",") ' Factor
            sComandoSQL.Append(Precio & ",") ' Precio (con factor)
            sComandoSQL.Append(RedondeoAritmetico(DescuentoPor, 4) & ",") ' DescuentoPor
            sComandoSQL.Append(RedondeoAritmetico(DescuentoImp * -1, 2) & ",") ' Descuentoimp
            Dim dSubtotal As Decimal
            'Devolucion Total
            dSubtotal = (((Cantidad * Factor) + (Cantidad1 * Factor1)) * Precio)
            sComandoSQL.Append(RedondeoAritmetico(dSubtotal, 2) & ",") ' Subtotal
            sComandoSQL.Append(RedondeoAritmetico(Impuesto, 2) & ",") ' Impuesto
            sComandoSQL.Append(RedondeoAritmetico(SubTotal + Impuesto, 2) & ",") ' Total
            sComandoSQL.Append("0,") ' Enviado
            sComandoSQL.Append(UniFechaSQL(Now) & ",")
            sComandoSQL.Append("'" & oVendedor.UsuarioId & "')")

            ' Guardar los productos
            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Actualizar")
        End Try
    End Function
    Public Shared Function CrearDetalleBonificacion(ByVal IP_Bonificacion As String, ByVal IP_Detalle As String, ByVal IP_Producto As String, ByVal IP_CodigoSKU As String, ByVal IP_TipoUnidad As Integer, ByVal IP_Cantidad As Decimal, ByVal IP_Cantidad1 As Decimal, ByVal IP_Factor As Decimal, ByVal IP_Factor1 As Decimal, ByVal IP_Precio As Decimal, ByVal IP_DescuentoPor As Decimal, ByVal IP_DescuentoImp As Decimal, ByVal IP_Impuesto As Decimal, ByVal IP_Motivo As Integer, ByVal IP_PorcentajeDescuento As Decimal, ByRef OP_TotalPartida As Decimal, ByVal IP_FacturaId As String) As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        Try
            ' Crear la cadena para insertar el valor
            sComandoSQL.Append("INSERT INTO TransProdDetalle (TransProdID, TransProdDetalleID,  ProductoClave,CodigoSKU, TipoMotivo, Partida,TipoUnidad, Cantidad, Cantidad1, Factor, Factor1, Precio, DescuentoPor, DescuentoImp, Subtotal, Impuesto, Total,Enviado, MFechaHora, MUsuarioID) VALUES (")
            sComandoSQL.Append("'" & IP_Bonificacion & "',")
            sComandoSQL.Append("'" & IP_Detalle & "',")
            sComandoSQL.Append("'" & IP_Producto & "',")
            sComandoSQL.Append("'" & IP_CodigoSKU & "',")
            sComandoSQL.Append(IP_Motivo & ",") ' TipoMotivo
            sComandoSQL.Append(0 & ",") ' Partida
            sComandoSQL.Append(IP_TipoUnidad & ",") ' TipoUnidad
            sComandoSQL.Append(IP_Cantidad & ",") ' Cantidad
            sComandoSQL.Append(IIf(IP_CodigoSKU = "", IP_Cantidad1, IIf(IP_Cantidad1 = 0, 0, 1)) & ",") ' Cantidad1
            sComandoSQL.Append(IP_Factor & ",") ' Factor
            sComandoSQL.Append(IP_Factor1 & ",") ' Factor
            sComandoSQL.Append(IP_Precio & ",") ' Precio (con factor)
            sComandoSQL.Append(RedondeoAritmetico(IP_DescuentoPor, 4) & ",") ' DescuentoPor
            sComandoSQL.Append(RedondeoAritmetico(IP_DescuentoImp * -1, 2) & ",") ' Descuentoimp
            Dim dSubtotal As Decimal
            If (IP_DescuentoPor > 0) Then
                dSubtotal = RedondeoAritmetico(((IP_Cantidad * IP_Precio) - (IP_DescuentoImp * -1)), 2)
                sComandoSQL.Append(dSubtotal & ",") ' Subtotal
                Dim dImpuesto As Decimal = RedondeoAritmetico(IP_Impuesto * (IP_DescuentoPor / 100), 2)
                sComandoSQL.Append(RedondeoAritmetico(dImpuesto, 2) & ",") ' Impuesto
                OP_TotalPartida = RedondeoAritmetico(dSubtotal + dImpuesto, 2)
                sComandoSQL.Append(OP_TotalPartida & ",") ' Total
            ElseIf IP_PorcentajeDescuento > 0 Then
                'PesoReal
                dSubtotal = RedondeoAritmetico(((((IP_Cantidad * IP_Factor) + (IP_Cantidad1 * IP_Factor1)) * IP_Precio)), 2)
                Dim dImpuesto As Decimal = (IP_Impuesto * IP_PorcentajeDescuento)
                sComandoSQL.Append(dSubtotal & ",") ' Subtotal
                sComandoSQL.Append(RedondeoAritmetico(IP_Impuesto - dImpuesto, 2) & ",") ' Subtotal
                OP_TotalPartida = RedondeoAritmetico(dSubtotal + (IP_Impuesto - dImpuesto), 2)
                sComandoSQL.Append(OP_TotalPartida & ",") ' Total
            Else
                'Devolucion Total
                dSubtotal = (((IP_Cantidad * IP_Factor) + (IP_Cantidad1 * IP_Factor1)) * IP_Precio)
                sComandoSQL.Append(RedondeoAritmetico(dSubtotal, 2) & ",") ' Subtotal
                sComandoSQL.Append(RedondeoAritmetico(IP_Impuesto, 2) & ",") ' Impuesto
                sComandoSQL.Append(RedondeoAritmetico(dSubtotal + IP_Impuesto, 2) & ",") ' Total
            End If
            '(<TransProdDetalle.Cantidad x TransProdDetalle.Factor> + <TransProdDetalle.Cantidad1 x TransProdDetalle.Factor1>> x <TransProdDetalle.Precio>) - <TransProdDetalle.DescuentoImp>.
            sComandoSQL.Append("0,") ' Enviado
            sComandoSQL.Append(UniFechaSQL(Now) & ",")
            sComandoSQL.Append("'" & oVendedor.UsuarioId & "')")

            ' Guardar los productos
            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
            ' Guardar los impuestos en el detalle
            'if 
            ' refparoImpuesto.GuardarDetalle(IP_Bonificacion, Me.TransProdDetalleID, aImpuestos)
            sComandoSQL = New Text.StringBuilder
            sComandoSQL.Append("INSERT INTO TPDImpuesto ")
            sComandoSQL.Append("Select '" & IP_Bonificacion & "','" & IP_Detalle & "','" & oApp.KEYGEN(1) & "', ImpuestoClave, ImpuestoPor, ImpuestoImp , ImpuestoPU, ImpDesGlb, getdate(),'" & oVendedor.UsuarioId & "',1 ")
            sComandoSQL.Append("from TPDImpuesto where TransProdID ='" & IP_FacturaId & "' and TransProdDetalleID ='" & IP_Detalle & "'")

            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)

            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Actualizar")
        End Try
        Return False
    End Function

    Public Shared Sub CopiarTRP(ByRef refparoTRP As TransProd, ByVal paroTransProdGenerico As TransProd)
        With refparoTRP
            .ListasPrecios = paroTransProdGenerico.ListasPrecios
            .DiaClave = paroTransProdGenerico.DiaClave
            .VisitaActual = paroTransProdGenerico.VisitaActual
            .DiaClave1 = paroTransProdGenerico.DiaClave1
            .VisitaClave1 = paroTransProdGenerico.VisitaClave1
            .SubEmpresaActual = paroTransProdGenerico.SubEmpresaActual
            .ClienteActual = paroTransProdGenerico.ClienteActual
            .ClienteClave = paroTransProdGenerico.ClienteActual.ClienteClave
            .ModuloMovDetalle = paroTransProdGenerico.ModuloMovDetalle
            .FechaCaptura = paroTransProdGenerico.FechaCaptura
            .FechaEntrega = paroTransProdGenerico.FechaEntrega
            .FechaFacturacion = paroTransProdGenerico.FechaFacturacion
            .FechaCancelacion = paroTransProdGenerico.FechaCancelacion
            .FechaSurtido = paroTransProdGenerico.FechaSurtido
            '.FechaHoraAlta = oTransProdGenerico.FechaHoraAlta
            .EsquemaIdListaPrecios = paroTransProdGenerico.EsquemaIdListaPrecios
            .TipoPedido = paroTransProdGenerico.TipoPedido
            .Tipo = paroTransProdGenerico.Tipo
            .TipoMovimiento = paroTransProdGenerico.TipoMovimiento
            .Notas = paroTransProdGenerico.Notas
            .DiasCredito = paroTransProdGenerico.DiasCredito
            .FechaCobranza = paroTransProdGenerico.FechaCobranza
            .TipoTurno = paroTransProdGenerico.TipoTurno
            .CFVTipo = paroTransProdGenerico.CFVTipo
            .ClientePagoId = paroTransProdGenerico.ClientePagoId
            .TipoFase = paroTransProdGenerico.TipoFase
            .ClienteClave = paroTransProdGenerico.ClienteClave
            .PLIId = paroTransProdGenerico.PLIId
        End With
    End Sub

    Public Shared Function CrearDetallePedido(ByRef paroTransProdGenerico As TransProd, ByVal parsTransprodId As String, ByVal parPartida As Integer, ByVal parCodigoSKU As String, ByVal parProductoClave As String, ByVal parCantidad As Decimal, ByVal parCantidad1 As Decimal, ByVal parTipoUnidad As Integer, ByVal parFactor As Integer, ByVal parImpuesto As Impuesto, ByVal parbSurtir As Boolean, ByVal parbEsNuevo As Boolean, ByVal pariTipoMotivo As Integer, ByRef paraTransProd As Generic.Dictionary(Of String, TransProd), Optional ByVal paroPrecioSinFactor As Precio = Nothing) As Int16
        Select Case paroTransProdGenerico.Tipo
            Case ServicesCentral.TiposTransProd.Pedido And oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion And Not parbSurtir
                Try
                    If parCantidad <= 0 Then
                        Exit Function
                    End If


                    ' Crear un objeto TransProdDetalle
                    Dim oTransProdDetalle As New TransProdDetalle(parsTransprodId, parProductoClave, parPartida)
                    oTransProdDetalle.ObtenerListaImpuestos(parImpuesto, paroTransProdGenerico.ClienteActual.TipoImpuesto)
                    'Validar los impuestos
                    oTransProdDetalle.ValidarImpuestos(paroTransProdGenerico.ClienteActual)

                    ' Actualizar el detalle
                    oTransProdDetalle.TipoUnidad = parTipoUnidad
                    oTransProdDetalle.CodigoSKU = parCodigoSKU
                    oTransProdDetalle.Cantidad = parCantidad
                    oTransProdDetalle.Cantidad1 = parCantidad1
                    If Not IsNothing(paroPrecioSinFactor) Then
                        oTransProdDetalle.PrecioSinFactor = paroPrecioSinFactor
                    Else
                        oTransProdDetalle.PrecioSinFactor = oTransProdDetalle.ObtenerPrecioRango(paroTransProdGenerico.ListasPrecios)
                        If IsNothing(oTransProdDetalle.PrecioSinFactor) Then
                            Return 1
                        End If
                    End If
                    oTransProdDetalle.UnidadCobranza = oTransProdDetalle.PrecioSinFactor.UnidadCobranza
                    oTransProdDetalle.Factor = oTransProdDetalle.PrecioSinFactor.Factor
                    oTransProdDetalle.Factor1 = oTransProdDetalle.PrecioSinFactor.Factor1
                    'TODO: Falta completar
                    If parsTransprodId = "" Then
                        If parbEsNuevo Then
                            If paraTransProd.Count > 0 Then
                                If paraTransProd.ContainsKey(oTransProdDetalle.PrecioSinFactor.MonedaID) Then
                                    oTransProdDetalle.TransProdID = paraTransProd(oTransProdDetalle.PrecioSinFactor.MonedaID).TransProdId
                                Else
                                    Dim oTRP As New TransProd()
                                    Folio.ObtenerTransProdId(oTRP.TransProdId)
                                    Dim sFolios As String() = Folio.ObtenerVarios(paroTransProdGenerico.ModuloMovDetalle.ModuloMovDetalleClave, , paraTransProd.Count + 1)
                                    oTRP.FolioActual = sFolios(paraTransProd.Count)
                                    oTRP.MonedaID = oTransProdDetalle.PrecioSinFactor.MonedaID
                                    CopiarTRP(oTRP, paroTransProdGenerico)
                                    oTRP.Actualizar()
                                    paraTransProd.Add(oTRP.MonedaID, oTRP)
                                    oTransProdDetalle.TransProdID = oTRP.TransProdId
                                End If
                            Else
                                If IsNothing(paroTransProdGenerico.MonedaID) OrElse paroTransProdGenerico.MonedaID = "" Then
                                    paroTransProdGenerico.MonedaID = oTransProdDetalle.PrecioSinFactor.MonedaID
                                    oTransProdDetalle.TransProdID = paroTransProdGenerico.TransProdId
                                    paroTransProdGenerico.Actualizar()
                                ElseIf paroTransProdGenerico.MonedaID = oTransProdDetalle.PrecioSinFactor.MonedaID Then
                                    oTransProdDetalle.TransProdID = paroTransProdGenerico.TransProdId
                                Else
                                    paroTransProdGenerico.ClienteClave = paroTransProdGenerico.ClienteActual.ClienteClave
                                    paraTransProd.Add(paroTransProdGenerico.MonedaID, paroTransProdGenerico)
                                    Dim oTRP As New TransProd()
                                    Folio.ObtenerTransProdId(oTRP.TransProdId)
                                    Dim sFolios As String() = Folio.ObtenerVarios(paroTransProdGenerico.ModuloMovDetalle.ModuloMovDetalleClave, , 2)
                                    oTRP.FolioActual = sFolios(1)
                                    oTRP.MonedaID = oTransProdDetalle.PrecioSinFactor.MonedaID
                                    CopiarTRP(oTRP, paroTransProdGenerico)
                                    oTRP.Actualizar()
                                    paraTransProd.Add(oTRP.MonedaID, oTRP)
                                    oTransProdDetalle.TransProdID = oTRP.TransProdId
                                End If
                            End If
                        Else 'Si es modificacion del pedido
                            If paroTransProdGenerico.MonedaID <> oTransProdDetalle.PrecioSinFactor.MonedaID Then
                                'TODO: Division Pedido
                                MsgBox(gVista.BuscarMensaje("MsgBoxGeneral", "E0781"))
                                Exit Function
                            Else
                                oTransProdDetalle.TransProdID = paroTransProdGenerico.TransProdId
                            End If

                        End If
                    Else
                        If parPartida = 0 Then
                            ' Es una nueva partida, obtener el nuevo Id
                            If Not Folio.ObtenerTransProdPartida(oTransProdDetalle.TransProdID, parProductoClave, parPartida) Then
                                Exit Try
                            End If
                        End If
                        oTransProdDetalle.TransProdID = parsTransprodId
                    End If
                    oTransProdDetalle.TipoMotivo = pariTipoMotivo
                    oTransProdDetalle.ObtenerTipoAplicacionDescuentos(paroTransProdGenerico.ModuloMovDetalle.ModuloMovDetalleClave, parbEsNuevo)
                    oTransProdDetalle.ActualizarDec(oTransProdDetalle.TransProdDetalleID, paroTransProdGenerico.Tipo, parImpuesto, parCantidad, 0, parTipoUnidad, parFactor, ServicesCentral.TiposMovimientos.NoDefinido, paroTransProdGenerico.ClienteActual, )
                    SKUInventario.ActualizarSKU(SKUInventario.SKUMovimiento.Decrementar, oTransProdDetalle.CodigoSKU, oTransProdDetalle.ProductoClave, oTransProdDetalle.TipoUnidad, oTransProdDetalle.Cantidad, oTransProdDetalle.Cantidad1)

                Catch ExcA As SqlCeException
                    MsgBox(ExcA.Message, MsgBoxStyle.Critical, "GuardarDetallePedido")
                Catch ExcB As Exception
                    MsgBox(ExcB.Message, MsgBoxStyle.Critical, "GuardarDetallePedido")
                End Try

        End Select
    End Function

    Public Function ActualizarCargaRepartoDec(ByVal parsTransProdDetalleID As String, ByVal pardCantidadActual As Decimal, ByVal pardCantidadAnterior As Decimal, ByVal pariTipoTransProd As ServicesCentral.TiposTransProd) As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        Dim blnNuevo As Boolean
        Dim iPartida As Integer
        Try
            ' Determinar el numero de partida
            If Me.Partida = 0 Then
                ' Es una nueva partida, obtenerla
                If Not Folio.ObtenerTransProdPartida(Me.TransProdID, Me.ProductoClave, iPartida) Then
                    Exit Try
                End If
                blnNuevo = True
            Else
                blnNuevo = False
            End If
            Dim nPrecio As Single = 0
            Dim dCantidad As Decimal
            Dim nImpuesto As Single = 15
            ' Obtener los productos a actualizar

            dCantidad = pardCantidadActual

            ' La cantidad es valida, guardarla. Si no estaba capturada
            If parsTransProdDetalleID = "" Then
                ' Obtener un nuevo folio
                If Not Folio.ObtenerTransProdDetalleId(Me.TransProdID, parsTransProdDetalleID) Then
                    Return False
                End If
                ' Crear la cadena para insertar el valor
                sComandoSQL.Append("INSERT INTO TransProdDetalle (TransProdID, TransProdDetalleID, ProductoClave, TipoUnidad, Partida, Cantidad,Precio,Subtotal,Total, MFechaHora, MUsuarioID) VALUES (")
                sComandoSQL.Append("'" & Me.TransProdID & "',")
                sComandoSQL.Append("'" & parsTransProdDetalleID & "',")
                sComandoSQL.Append("'" & Me.ProductoClave & "',")
                sComandoSQL.Append(Me.TipoUnidad & ",") ' TipoUnidad
                sComandoSQL.Append(iPartida & ",") ' Partida
                sComandoSQL.Append(dCantidad & ",") ' Cantidad
                sComandoSQL.Append(nPrecio & ",")  ' Precio
                sComandoSQL.Append((dCantidad * nPrecio) & ",")  ' Subtotal
                sComandoSQL.Append(((dCantidad * nPrecio * (1 + (nImpuesto / 100)))) & ",") ' Total
                sComandoSQL.Append(UniFechaSQL(Now) & ",")
                sComandoSQL.Append("'" & oVendedor.UsuarioId & "')")
            Else
                ' Actualizar el registro
                sComandoSQL.Append("UPDATE TransProdDetalle SET ")
                sComandoSQL.Append("Cantidad=Cantidad+" & dCantidad & ",")
                sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",")
                sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "', ")
                sComandoSQL.Append("Enviado=0 ")
                sComandoSQL.Append("WHERE TransProdID='" & Me.TransProdID & "' AND TransProdDetalleID='" & parsTransProdDetalleID & "'")
            End If
            ' Guardar el producto
            Try
                If sComandoSQL.ToString <> "" Then
                    oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, "GuardarProducto")
            End Try

            ' Actualizar el inventario
            Dim dCantidadAnterior As Decimal = 0
            If Not (blnNuevo And dCantidad = 0) Then
                dCantidadAnterior = pardCantidadAnterior
                Inventario.ObtenerCantidadAActualizar(ServicesCentral.TiposMovimientos.Entrada, dCantidad, dCantidadAnterior)
                Inventario.ActualizarInventarioDec(Me.ProductoClave, Me.TipoUnidad, dCantidad, pariTipoTransProd, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId)
            End If

        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarProducto")
        End Try
        Return False
    End Function

    Public Function ActualizarPromocion() As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        Try
            Me.TransProdDetalleID = oApp.KEYGEN(iPartida)
            ' Crear la cadena para insertar el valor
            sComandoSQL.Append("INSERT INTO TransProdDetalle (TransProdID, TransProdDetalleID, PRGId, ProductoClave, TipoUnidad, Partida, ")
            sComandoSQL.Append("Cantidad,Precio,Subtotal,Impuesto,Total,Promocion,PromocionClave,Enviado,MFechaHora,MUsuarioID) VALUES (")
            sComandoSQL.Append("'" & Me.TransProdID & "',")
            sComandoSQL.Append("'" & TransProdDetalleID & "',")
            sComandoSQL.Append("'" & Me.PRGId & "',")
            sComandoSQL.Append("'" & Me.ProductoClave & "',")
            sComandoSQL.Append(Me.TipoUnidad & ",") ' TipoUnidad
            sComandoSQL.Append(Me.Partida & ",") ' Partida
            sComandoSQL.Append(Me.Cantidad & ",") ' Cantidad
            sComandoSQL.Append("0,0,0,0,")  ' Precio, SubTotal, Impuesto, Total
            sComandoSQL.Append("2,")  ' Promocion
            sComandoSQL.Append("'" & Me.PromocionClave & "',") ' PromocionClave
            sComandoSQL.Append("0,") ' Enviado
            sComandoSQL.Append(UniFechaSQL(Now) & ",")
            sComandoSQL.Append("'" & oVendedor.UsuarioId & "')")

            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
            Inventario.ActualizarInventarioDec(Me.ProductoClave, Me.TipoUnidad, Me.Cantidad, ServicesCentral.TiposTransProd.SurtirProductoPromocion, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId)
            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarProducto")
        End Try
        Return False
    End Function

    Public Shared Function Buscar(ByVal parsTransProdID As String, ByVal parsProductoClave As String, ByVal pariTipoUnidad As Integer) As TransProdDetalle
        Try
            Dim ldt As DataTable = oDBVen.RealizarConsultaSQL("Select * from TransProdDetalle where TransProdID='" & parsTransProdID & "' AND ProductoClave='" & parsProductoClave & "' AND TipoUnidad=" & pariTipoUnidad, "TransProdDetalle")
            If ldt.Rows.Count > 0 Then
                Dim oTransProdDetalle As New TransProdDetalle(parsTransProdID, parsProductoClave, ldt.Rows(0)("Partida"))
                With oTransProdDetalle
                    .TransProdDetalleID = ldt.Rows(0)("TransProdDetalleID")
                    .Cantidad = ldt.Rows(0)("Cantidad")
                    .TipoUnidad = ldt.Rows(0)("TipoUnidad")
                End With
                Return oTransProdDetalle
            End If
        Catch ex As Exception
        End Try
        Return Nothing
    End Function

    Public Enum TipoCarga
        CargaReparto = 0
        CargaCanje
    End Enum

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
