Imports System.Data.SqlServerCe

Public Class Producto

    Protected sProductoClave As String
    Protected sNombre As String

    Public Property ProductoClave() As String
        Get
            Return sProductoClave
        End Get
        Set(ByVal Value As String)
            sProductoClave = Value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return sNombre
        End Get
        Set(ByVal Value As String)
            sNombre = Value
        End Set
    End Property

    Public Class Unidad
        Protected iTipoUnidad As Integer
        Protected iFactor As Integer
        Protected nPrecio As Decimal

        Public Sub New(ByVal pariTipoUnidad As Integer, ByVal pariFactor As Integer, ByVal parnPrecio As Decimal)
            Me.TipoUnidad = pariTipoUnidad
            Me.Factor = pariFactor
            Me.Precio = parnPrecio
        End Sub

        Public Property TipoUnidad() As Integer
            Get
                Return iTipoUnidad
            End Get
            Set(ByVal Value As Integer)
                iTipoUnidad = Value
            End Set
        End Property
        Public Property Factor() As Integer
            Get
                Return iFactor
            End Get
            Set(ByVal Value As Integer)
                iFactor = Value
            End Set
        End Property
        Public Property Precio() As Decimal
            Get
                Return Decimal.Round(nPrecio, oConHist.Campos("DecimalesImporte"))
            End Get
            Set(ByVal Value As Decimal)
                nprecio = Value
            End Set
        End Property
    End Class

    ''' <summary>
    ''' Busca un producto por la Clave o por el Id
    ''' </summary>
    ''' <param name="optparsClaveProducto">clave o Id del producto</param>
    ''' <param name="optparbNoEsClave">diferencia entre Clave o Id</param>
    ''' <returns>regresa Verdadero si encuentra el producto de lo contrario regresa Falso</returns>
    ''' <remarks>el campo optparbEsClave si es verdadero es porque se buscara por el id del producto, de lo contrario es por la Clave del producto </remarks>
    Public Function Buscar(Optional ByVal optparsClaveProducto As String = "", Optional ByVal optparbNoEsClave As Boolean = False) As Boolean
        If optparsClaveProducto = "" Then
            optparsClaveProducto = Me.ProductoClave
        End If
        Try
            Dim drFila As DataRow()
            If optparbNoEsClave Then
                drFila = g_dtProductos.Select("Id ='" & optparsClaveProducto & "'")
            Else
                drFila = g_dtProductos.Select("ProductoClave ='" & optparsClaveProducto & "'")
            End If
            If drFila.Length > 0 Then
                Me.ProductoClave = drFila(0)("ProductoClave").ToString()
                Return True
            End If
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "Buscar")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "Buscar")
        End Try
        Return False
    End Function
    Public Function BuscarCodigoBarras(ByVal parsCodigoBarras As String) As String
        Try
            Dim dt As DataTable = oDBVen.RealizarConsultaSQL("SELECT ProductoClave FROM Producto WHERE CodigoBarras='" & parsCodigoBarras & "'", "Producto")
            If dt.Rows.Count > 0 Then
                Me.ProductoClave = dt.Rows(0)("ProductoClave")
                dt.Dispose()
                dt = Nothing
                Return Me.ProductoClave
            End If
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "Buscar")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "Buscar")
        End Try
        Return String.Empty
    End Function

    Public Function Recuperar() As Boolean
        Try
            Me.Nombre = g_dtProductos.Select("ProductoClave='" & Me.ProductoClave & "'")(0)("Nombre")
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Public Shared Function ExisteProducto(ByVal parsProductoClave As String) As Boolean
        Dim iProducto As Integer = 0
        iProducto = g_dtProductos.Select("ProductoCLave ='" & parsProductoClave & "'").Length
        Return iProducto > 0
    End Function
    Public Function RecuperarProductoEsquema() As String
        Dim sEsquemas As String = ""

        Dim dt As DataTable
        dt = odbVen.RealizarConsultaSQL("Select * from ProductoEsquema where ProductoClave='" & Me.ProductoClave & "'", "ProductoEsquema")
        Dim r As DataRow

        For Each r In dt.Rows
            sEsquemas = "'" & r("EsquemaID") & "',"
        Next

        If sEsquemas <> "" Then
            sEsquemas = Left(sEsquemas, Len(sEsquemas) - 1)
        End If

        Return sEsquemas
    End Function

    Public Shared Function RecuperarUnidadesPrecio(ByVal parsProductoClave As String, ByVal parsListaTiposUnidades As String, ByRef refparoListaUnidades As ArrayList, ByVal parsListaPrecioClave As String) As Boolean
        Try
            Dim sConsultaSQL As New System.Text.StringBuilder
            sConsultaSQL.Append("SELECT ProductoDetalle.PRUTipoUnidad, ProductoDetalle.Factor, PrecioProductoVig.Precio  FROM ProductoDetalle ")
            sConsultaSQL.Append("INNER JOIN PrecioProductoVig ON ProductoDetalle.ProductoClave = PrecioProductoVig.ProductoClave and ProductoDetalle.ProductoClave = ProductoDetalle.ProductoDetClave  and ProductoDetalle.PRUTipoUnidad = PrecioProductoVig.PRUTipoUnidad ")
            sConsultaSQL.Append("WHERE  ProductoDetalle.ProductoClave = '" & parsProductoClave & "' AND PrecioProductoVig.PrecioClave = '" & parsListaPrecioClave & "' ")
            sConsultaSQL.Append("AND ProductoDetalle.PRUTipoUnidad IN (" & parsListaTiposUnidades & ") ")
            sConsultaSQL.Append("AND " & UniFechaSQL(UltimaHora(Now)) & ">=PrecioProductoVig.PPVFechaInicio AND " & UniFechaSQL(PrimeraHora(Now)) & "<=PrecioProductoVig.FechaFin ")
            sConsultaSQL.Append("ORDER BY ProductoDetalle.PRUTipoUnidad")
            Dim DataTableProdUdes As DataTable = odbVen.RealizarConsultaSQL(sConsultaSQL.ToString, "Unidades")
            For Each refDataRow As DataRow In DataTableProdUdes.Rows
                With refDataRow
                    refparoListaUnidades.Add(New Producto.Unidad(.Item("PRUTipoUnidad"), .Item("Factor"), .Item("Precio")))
                End With
            Next
            DataTableProdUdes.Dispose()
            DataTableProdUdes = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return (refparoListaUnidades.Count <> 0)
    End Function

    Public Shared Function RecuperarUnidadBasica(ByVal parsProductoClave As String) As Integer
        Dim iUnidad As Integer = 0
        Try
            Dim sConsultaSQL As New System.Text.StringBuilder
            sConsultaSQL.Append("SELECT PRUTipoUnidad, Factor FROM ProductoDetalle ")
            sConsultaSQL.Append("WHERE  ProductoClave = '" & parsProductoClave & "' ")
            sConsultaSQL.Append("AND ProductoDetClave = '" & parsProductoClave & "' ")
            Dim DataTableProdUdes As DataTable = oDBVen.RealizarConsultaSQL(sConsultaSQL.ToString, "Unidades")
            Dim factor As Integer = Integer.MaxValue
            For Each refDataRow As DataRow In DataTableProdUdes.Rows
                With refDataRow
                    If factor > Convert.ToInt32(.Item("Factor")) Then
                        iUnidad = Convert.ToInt32(.Item("PRUTipoUnidad"))
                        factor = Convert.ToInt32(.Item("Factor"))
                    End If
                End With
            Next
            DataTableProdUdes.Dispose()
            DataTableProdUdes = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return iUnidad
    End Function
    'Public Shared Function VerificarTipoClaveProducto(ByRef pvTipoClave As Integer, ByRef pvEspacios As Integer) As Boolean
    '    pvTipoClave = oConHist.Campos("TipoClaveProducto")
    '    pvEspacios = oConHist.Campos("DigitoClaveProd")
    '    Return True
    '    'AgregarLogging("Inicia verificar el tipo de clave de producto", "Producto.VerificarTipoClaveProducto", AMESOLLogging.AMESOLLog.TipoLog.Funciones)
    '    'Dim sQuery As String = "SELECT TipoClaveProducto, DigitoClaveProd FROM CONHist ORDER BY CONHistFechaInicio DESC"
    '    'Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery, "VTCP")
    '    'If oDt.Rows.Count > 0 Then
    '    '    pvTipoClave = oDt.Rows(0)("TipoClaveProducto")
    '    '    pvEspacios = oDt.Rows(0)("DigitoClaveProd")
    '    '    AgregarLogging("Termina verificar el tipo de clave de producto", "Producto.VerificarTipoClaveProducto", AMESOLLogging.AMESOLLog.TipoLog.Funciones)
    '    '    Return True
    '    'End If
    '    'AgregarLogging("Termina verificar el tipo de clave de producto", "Producto.VerificarTipoClaveProducto", AMESOLLogging.AMESOLLog.TipoLog.Funciones)
    '    'Return False
    'End Function

End Class

Public Class ProductoNegado
    Private sPRGId As String
    Private sTRPId As String
    Private sProductoClave As String
    Private sPromocionClave As String
    Private sProductoClave1 As String
    Private iTipoUnidad As Integer
    Private dCantidad As Double
    Private iSaldo As Double
    Private iTipoFasePRP As Integer
    Private dFechaFase As Date
    Private sCliente As String
    Private sFolioPedido As String
    Private bPendienteEntrega As Boolean
    Private dMFechaHora As Date
    Private sMUsuarioID As String

    Public Property PRGId() As String
        Get
            Return sPRGId
        End Get
        Set(ByVal Value As String)
            sPRGId = Value
        End Set
    End Property
    Public Property TransProdId() As String
        Get
            Return sTRPId
        End Get
        Set(ByVal Value As String)
            sTRPId = Value
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
    Public Property PromocionClave() As String
        Get
            Return sPromocionClave
        End Get
        Set(ByVal value As String)
            sPromocionClave = value
        End Set
    End Property
    Public Property ProductoClave1() As String
        Get
            Return sProductoClave1
        End Get
        Set(ByVal value As String)
            sProductoClave1 = value
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
    Public Property Cantidad() As Double
        Get
            Return dCantidad
        End Get
        Set(ByVal Value As Double)
            dCantidad = Value
        End Set
    End Property
    Public Property Saldo() As Double
        Get
            Return iSaldo
        End Get
        Set(ByVal value As Double)
            iSaldo = value
        End Set
    End Property
    Public Property TipoFasePRP() As Integer
        Get
            Return iTipoFasePRP
        End Get
        Set(ByVal value As Integer)
            iTipoFasePRP = value
        End Set
    End Property
    Public Property FechaFase() As Date
        Get
            Return dFechaFase
        End Get
        Set(ByVal value As Date)
            dFechaFase = value
        End Set
    End Property
    Public Property Cliente() As String
        Get
            Return sCliente
        End Get
        Set(ByVal value As String)
            sCliente = value
        End Set
    End Property
    Public Property FolioPedido() As String
        Get
            Return sFolioPedido
        End Get
        Set(ByVal value As String)
            sFolioPedido = value
        End Set
    End Property
    Public Property PendienteEntrega() As Boolean
        Get
            Return bPendienteEntrega
        End Get
        Set(ByVal value As Boolean)
            bPendienteEntrega = value
        End Set
    End Property
    Public ReadOnly Property MFechaHora() As Date
        Get
            Return dMFechaHora
        End Get
    End Property
    Public ReadOnly Property MUsuarioID() As String
        Get
            Return sMUsuarioID
        End Get
    End Property

    Public Sub New()

    End Sub
    Public Function Insertar() As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        Try
            sPRGId = oApp.KEYGEN(1)
            sComandoSQL.Append("INSERT INTO ProductoNegado (PRGId,TransProdId,ProductoClave,TipoUnidad,Cantidad,MFechaHora, MUsuarioID) VALUES (")
            sComandoSQL.Append("'" & Me.PRGId & "',")
            sComandoSQL.Append("'" & Me.TransProdId & "',")
            sComandoSQL.Append("'" & Me.ProductoClave & "',")
            sComandoSQL.Append(Me.TipoUnidad & ",")
            sComandoSQL.Append(Me.Cantidad & ",")
            sComandoSQL.Append(UniFechaSQL(Now) & ",")
            sComandoSQL.Append("'" & oVendedor.UsuarioId & "'")
            sComandoSQL.Append(")")

            Return odbVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        End Try
    End Function

    Public Shared Function Insertar(ByVal parsTransProdID As String, ByVal parsProductoClave As String, ByVal parsPromocionClave As String, ByVal parsProductoClave1 As String, ByVal pariTipoUnidad As Integer, ByVal pardCantidad As Double, ByVal pariTipoFase As Integer, ByVal parsClienteClave As String, ByVal parsFolioPedido As String) As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        Try
            sComandoSQL.Append("INSERT INTO ProductoNegado (PRGId,TransProdId,ProductoClave,PromocionClave, ProductoClave1,TipoUnidad,Cantidad,Saldo, TipoFasePRP, FechaFase, Cliente, FolioPedido,PendienteEntrega,MFechaHora, MUsuarioID) VALUES (")
            sComandoSQL.Append("'" & oApp.KEYGEN(1) & "',")
            sComandoSQL.Append("'" & parsTransProdID & "',")
            sComandoSQL.Append("'" & parsProductoClave & "',")
            sComandoSQL.Append("'" & parsPromocionClave & "',")
            sComandoSQL.Append("'" & parsProductoClave1 & "',")
            sComandoSQL.Append(pariTipoUnidad & ",")
            sComandoSQL.Append(pardCantidad & ",") 'Cantidad
            sComandoSQL.Append(pardCantidad & ",") 'Saldo
            sComandoSQL.Append(pariTipoFase & ",") 'TipoFase
            sComandoSQL.Append("getdate(),") 'FechaFase
            sComandoSQL.Append("'" & parsClienteClave & "',") 'ClienteClave
            sComandoSQL.Append("'" & parsFolioPedido & "',") 'FolioPedido
            sComandoSQL.Append("1,") 'PendienteEntrega
            sComandoSQL.Append("getdate(),") 'MFechaHora
            sComandoSQL.Append("'" & oVendedor.UsuarioId & "'")
            sComandoSQL.Append(")")

            Return oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "AgregarProducto")
        End Try
    End Function

    Public Function ActualizarSaldo(ByVal pardCantidad As Decimal) As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        Try
            sComandoSQL.Append("UPDATE ProductoNegado set ")
            sComandoSQL.Append("Saldo = saldo + " & pardCantidad & ", ")
            sComandoSQL.Append("TipoFasePRP = (case when Saldo + " & pardCantidad & " = 0 then 2 else 1 end), ")
            sComandoSQL.Append("FechaFase = " & UniFechaSQL(Now) & ", ")
            sComandoSQL.Append("MFechaHora = " & UniFechaSQL(Now) & ", ")
            sComandoSQL.Append("MUsuarioId = '" & oVendedor.UsuarioId & "', ")
            sComandoSQL.Append("Enviado = 0 ")
            sComandoSQL.Append("where PRGId = '" & Me.PRGId & "'")

            Return oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "ActualizarSaldo")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "ActualizarSaldo")
        End Try
    End Function

    Public Function ActualizarFase() As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        Try
            sComandoSQL.Append("UPDATE ProductoNegado set ")
            sComandoSQL.Append("TipoFasePRP = " & Me.TipoFasePRP & ", ")
            sComandoSQL.Append("FechaFase = " & UniFechaSQL(Now) & ", ")
            sComandoSQL.Append("MFechaHora = " & UniFechaSQL(Now) & ", ")
            sComandoSQL.Append("MUsuarioId = '" & oVendedor.UsuarioId & "', ")
            sComandoSQL.Append("Enviado = 0 ")
            sComandoSQL.Append("where PRGId = '" & Me.PRGId & "'")

            Return oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "ActualizFase")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "ActualizFase")
        End Try
    End Function

End Class

Public Class ProductoUnidadCobranza
    Protected sProductoClave As String
    Protected dCantidad As Decimal
    Protected iUnidadCobranza As Integer
    Protected dSubtotal As Decimal
    Protected sMonedaNombre As String

    Public Property ProductoClave() As String
        Get
            Return sProductoClave
        End Get
        Set(ByVal Value As String)
            sProductoClave = Value
        End Set
    End Property

    Public Property UnidadCobranza() As Integer
        Get
            Return iUnidadCobranza
        End Get
        Set(ByVal Value As Integer)
            iUnidadCobranza = Value
        End Set
    End Property

    Public Property Cantidad() As Decimal
        Get
            Return dCantidad
        End Get
        Set(ByVal Value As Decimal)
            dCantidad = Value
        End Set
    End Property
 
    Public Property Subtotal() As Decimal
        Get
            Return dSubtotal
        End Get
        Set(ByVal Value As Decimal)
            dSubtotal = Value
        End Set
    End Property

    Public Property MonedaNombre() As String
        Get
            Return sMonedaNombre
        End Get
        Set(ByVal value As String)
            sMonedaNombre = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal parsProductoClave As String, ByVal pariUnidadCobranza As Integer, ByVal pardCantidad As Decimal, ByVal pardSubtotal As Decimal, ByVal parsMonedaNombre As String)
        ProductoClave = parsProductoClave
        UnidadCobranza = pariUnidadCobranza
        Cantidad = pardCantidad
        Subtotal = pardSubtotal
        MonedaNombre = parsMonedaNombre
    End Sub
End Class

Public Class ProductoUnidadCantidadSubtotal
    Protected sProductoClave As String
    Protected dCantidad As Decimal
    Protected dCantidad1 As Decimal
    Protected iPRUTipoUnidad As Integer
    Protected dSubtotal As Decimal
    Public Property ProductoClave() As String
        Get
            Return sProductoClave
        End Get
        Set(ByVal Value As String)
            sProductoClave = Value
        End Set
    End Property

    Public Property PRUTipoUnidad() As Integer
        Get
            Return iPRUTipoUnidad
        End Get
        Set(ByVal Value As Integer)
            iPRUTipoUnidad = Value
        End Set
    End Property

    Public Property Cantidad() As Decimal
        Get
            Return dCantidad
        End Get
        Set(ByVal Value As Decimal)
            dCantidad = Value
        End Set
    End Property
    Public Property Cantidad1() As Decimal
        Get
            Return dCantidad1
        End Get
        Set(ByVal Value As Decimal)
            dCantidad1 = Value
        End Set
    End Property

    Public Property Subtotal() As Decimal
        Get
            Return dSubtotal
        End Get
        Set(ByVal Value As Decimal)
            dSubtotal = Value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal parsProductoClave As String, ByVal pariPRUTipoUnidad As Integer, ByVal pardCantidad As Decimal, ByVal pardSubtotal As Decimal, ByVal pardCantidad1 As Decimal)
        ProductoClave = parsProductoClave
        PRUTipoUnidad = pariPRUTipoUnidad
        Cantidad = pardCantidad
        Cantidad1 = pardCantidad1
        Subtotal = pardSubtotal
    End Sub
End Class