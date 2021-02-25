Imports System.Data.SqlServerCe

Public Class ListasPreciosCliente
    Implements IDisposable

    Private _ListasPrecios As Generic.SortedList(Of Integer, ListaPrecios)

    Public Property ListasPrecios() As Generic.SortedList(Of Integer, ListaPrecios)
        Get
            Return _ListasPrecios
        End Get
        Set(ByVal Value As Generic.SortedList(Of Integer, ListaPrecios))
            _ListasPrecios = Value
        End Set
    End Property

    Public Function Recuperar(ByVal paroCliente As Cliente, ByVal paroModuloMovDet As Modulos.GrupoModuloMovDetalle) As Boolean
        Try
            Dim DataViewEsquemas As DataView
            Dim DataTableEsquemasCliente As DataTable
            paroCliente.RecuperarEsquemas(DataViewEsquemas, DataTableEsquemasCliente)

            Dim sEsquemasCliente As String = String.Empty

            For Each dr As DataRow In DataTableEsquemasCliente.Rows
                sEsquemasCliente &= "'" & dr("EsquemaID") & "',"
                oAgenda.ClienteActual.RecuperarEsquemasCliente(DataViewEsquemas, sEsquemasCliente, dr("EsquemaID"))
            Next
            If sEsquemasCliente.Length > 0 Then
                sEsquemasCliente = Left(sEsquemasCliente, sEsquemasCliente.Length - 1)
            End If

            If sEsquemasCliente.Length <= 0 Then
                MsgBox(gVista.BuscarMensaje("MsgBoxGeneral", "E0756"), MsgBoxStyle.Exclamation)
                If Not IsNothing(DataViewEsquemas) Then
                    DataViewEsquemas.Dispose()
                End If

                If Not IsNothing(DataTableEsquemasCliente) Then
                    DataTableEsquemasCliente.Dispose()
                End If
                Return False
            End If

            Dim dtPrecios As DataTable = oDBVen.RealizarConsultaSQL("Select distinct PRE.PrecioClave, PRE.Jerarquia, PRE.Nombre from Precio PRE inner join PrecioClienteEsquema PCE on PRE.PrecioClave = PCE.PrecioClave where PRE.TipoEstado = 1 and PCE.ModuloMovDetalleClave='" & paroModuloMovDet.ModuloMovDetalleClave & "' and PCE.EsquemaID in(" & sEsquemasCliente & ") order by PRE.Jerarquia", "Precios")
            For Each dr As DataRow In dtPrecios.Rows
                If Not _ListasPrecios.ContainsKey(dr("Jerarquia")) Then
                    _ListasPrecios.Add(dr("Jerarquia"), New ListaPrecios(dr("PrecioClave"), dr("Jerarquia"), dr("Nombre")))
                End If
            Next

            If Not IsNothing(DataViewEsquemas) Then
                DataViewEsquemas.Dispose()
            End If

            If Not IsNothing(DataTableEsquemasCliente) Then
                DataTableEsquemasCliente.Dispose()
            End If

            If _ListasPrecios.Count <= 0 Then
                MsgBox(gVista.BuscarMensaje("MsgBoxGeneral", "E0757"), MsgBoxStyle.Exclamation)
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return False
    End Function

    Public Sub New()
        _ListasPrecios = New Generic.SortedList(Of Integer, ListaPrecios)
    End Sub


    Public Function BuscarPrecio(ByVal parsProducto As String, ByVal pariTipoUnidad As Short, ByRef refparnPrecio As Decimal) As Boolean
        For Each olista As ListaPrecios In ListasPrecios.Values
            If olista.BuscarPrecio(parsProducto, pariTipoUnidad, refparnPrecio) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function BuscarPrecioRango(ByVal parsProductoClave As String, ByVal pvCantidad1 As Decimal) As Precio
        Dim oPrecio As Precio
        For Each olista As ListaPrecios In ListasPrecios.Values
            oPrecio = olista.BuscarPrecioRango(parsProductoClave, pvCantidad1)
            If Not IsNothing(oPrecio) Then
                Return oPrecio
            End If
        Next
        Return Nothing
    End Function

    Public Function ObtenerPrecioProd(ByVal parsProductoClave As String) As DataTable
        Dim dtResultado As DataTable
        For Each olista As ListaPrecios In ListasPrecios.Values
            Dim sConsultaSQL As New Text.StringBuilder
            sConsultaSQL.Append("SELECT UnidadCobranza,Precio, MonedaID, minimo,maximo FROM PrecioProductoVig INNER JOIN Precio ON PrecioProductoVig.PrecioClave = Precio.PrecioClave  ")
            sConsultaSQL.Append("WHERE PrecioProductoVig.PrecioClave = '" & olista.PrecioClave & "' AND convert(nvarchar(10), getdate(), 112) between convert(nvarchar(10),PPVFechaInicio,112) and convert(nvarchar(10),Fechafin,112) ")
            sConsultaSQL.Append(" AND Precio.TipoEstado= 1 AND PrecioProductoVig.ProductoClave = '" & parsProductoClave & "' ORDER BY PrecioProductoVig.ProductoClave, Minimo ")

            dtResultado = oDBVen.RealizarConsultaSQL(sConsultaSQL.ToString, "Precios")
            If dtResultado.Rows.Count > 0 Then
                Return dtResultado
            End If
            dtResultado.Dispose()
        Next
        Return dtResultado
    End Function

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free managed resources when explicitly called
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

Public Class ListaPrecios
    Implements IDisposable

    Protected iPrecioClave As String
    Protected iJerarquia As Integer
    Protected sNombre As String

    Public Property PrecioClave() As String
        Get
            Return iPrecioClave
        End Get
        Set(ByVal Value As String)
            iPrecioClave = Value
        End Set
    End Property
    Public Property Jerarquia() As Integer
        Get
            Return iJerarquia
        End Get
        Set(ByVal Value As Integer)
            iJerarquia = Value
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

    Public Sub New()

    End Sub

    Public Sub New(ByVal parsPrecioClave As String, ByVal pariJerarquia As Integer, ByVal parsNombre As String)
        Me.PrecioClave = parsPrecioClave
        Me.Jerarquia = pariJerarquia
        Me.Nombre = parsNombre
    End Sub

    Private Function Recuperar() As Boolean
        Try
            Dim DataTablePrecio As DataTable
            ' Esquemas a los que pertenece el cliente
            '<15-Jun-2006>
            DataTablePrecio = oDBVen.RealizarConsultaSQL("SELECT * FROM Precio WHERE PrecioClave='" & Me.PrecioClave & "' AND TipoEstado = 1 ", "Precio")
            '<\15-Jun-2006>
            If DataTablePrecio.Rows.Count > 0 Then
                With DataTablePrecio.Rows(0)
                    Me.PrecioClave = .Item("PrecioClave")
                    Me.Nombre = .Item("Nombre")
                    Me.Jerarquia = .Item("Jerarquia")
                End With
                DataTablePrecio.Dispose()
                Return True
            End If
            DataTablePrecio.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Private Function BuscarGrupo(ByRef refparDataViewEsquemas As DataView, ByRef refparDataViewPreciosClientesEsquemas As DataView, ByVal refparsNodo As String) As String
        Dim sLista As String = ""
        Try
            ' Buscar el padre del nodo
            Dim iEsq As Integer = refparDataViewEsquemas.Find(refparsNodo)
            ' Si se encuentra
            If iEsq <> -1 Then
                ' Verificar que el padre no sea Nulo
                If Not refparDataViewEsquemas.Item(iEsq).Row.IsNull("EsquemaIdPadre") Then
                    ' Recuperar el nodo padre
                    Dim oEsquema As Object
                    oEsquema = refparDataViewEsquemas.Item(iEsq).Item("EsquemaIdPadre")
                    ' Buscar el nodo en los precios por esquemas de clientes
                    iEsq = refparDataViewPreciosClientesEsquemas.Find(oEsquema)
                    ' Si se encontró
                    If iEsq <> -1 Then
                        ' Agregar la lista al grupo de listas para determinar la de mayor jerarquía, y regresar
                        sLista = refparDataViewPreciosClientesEsquemas.Item(iEsq).Item("PrecioClave")
                    Else
                        ' No se encontró, seguir buscando en el árbol hacia arriba
                        sLista = Me.BuscarGrupo(refparDataViewEsquemas, refparDataViewPreciosClientesEsquemas, oEsquema)
                    End If
                End If
            End If
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "BuscarGrupo")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "BuscarGrupo")
        End Try
        Return sLista
    End Function
    Public Function BuscarPrecio(ByVal parsProductoClave As String, ByVal pariPRUTipoUnidad As Short, ByRef refparnPrecio As Decimal) As Boolean
        refparnPrecio = 0
        Try

            Dim sConsultaSQL As New System.Text.StringBuilder
            sConsultaSQL.Append("SELECT Precio FROM PrecioProductoVig INNER JOIN Precio ON PrecioProductoVig.PrecioClave = Precio.PrecioClave  ")
            sConsultaSQL.Append(" WHERE PrecioProductoVig.PrecioClave = '" & Me.PrecioClave & "' AND " & UniFechaSQL(UltimaHora(Now)) & ">=PPVFechaInicio AND " & UniFechaSQL(PrimeraHora(Now)) & "<=FechaFin  AND Precio.TipoEstado= 1 AND PrecioProductoVig.ProductoClave = '" & parsProductoClave & "' and PrecioProductoVig.PRUTipoUnidad = " & pariPRUTipoUnidad)
            sConsultaSQL.Append(" ORDER BY PrecioProductoVig.ProductoClave ")

            If Not oDBVen.EjecutarCmdScalardblSQL(sConsultaSQL.ToString, refparnPrecio) Then
                Return False
            End If
            sConsultaSQL = Nothing
            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "BuscarPrecio")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "BuscarPrecio")
        End Try
        Return False
    End Function

    Public Function BuscarPrecioRango(ByVal parsProductoClave As String, ByVal pvCantidad1 As Decimal) As Precio
        Try

            Dim sConsultaSQL As New System.Text.StringBuilder
            sConsultaSQL.Append("SELECT UnidadCobranza, Precio, MonedaID, Minimo, Maximo  FROM PrecioProductoVig INNER JOIN Precio ON PrecioProductoVig.PrecioClave = Precio.PrecioClave  ")
            sConsultaSQL.Append(" WHERE PrecioProductoVig.PrecioClave = '" & Me.PrecioClave & "' AND " & UniFechaSQL(UltimaHora(Now)) & ">=PPVFechaInicio AND ")
            sConsultaSQL.Append(UniFechaSQL(PrimeraHora(Now)) & "<=FechaFin  AND Precio.TipoEstado= 1 ")
            sConsultaSQL.Append(" AND PrecioProductoVig.ProductoClave = '" & parsProductoClave & "' ") 'and PrecioProductoVig.PRUTipoUnidad = " & pariPRUTipoUnidad)
            'sConsultaSQL.Append(" AND " & pvCantidad1 & " >= minimo AND " & pvCantidad1 & " <= maximo ")
            sConsultaSQL.Append(" ORDER BY PrecioProductoVig.Maximo desc")

            Dim dtRes As DataTable = oDBVen.RealizarConsultaSQL(sConsultaSQL.ToString, "Rangos")
            If dtRes.Rows.Count > 0 Then
                Dim sMonedaID As String = dtRes.Rows(0)("MonedaID")
                Dim iUnidadCobranza As Integer = dtRes.Rows(0)("UnidadCobranza")
                Dim dtUC As DataTable = oDBVen.RealizarConsultaSQL("Select Contenido, UnidadBase  from UnidadCobranza where ProductoClave='" & parsProductoClave & "' and UnidadCobranza = " & iUnidadCobranza & " UNION Select Contenido, UnidadBase  from UnidadCobranza where ProductoClave is null and UnidadCobranza = " & iUnidadCobranza, "UC")
                If dtUC.Rows.Count > 0 Then
                    If dtUC.Rows(0)("UnidadBase") = 1 Then
                        pvCantidad1 = pvCantidad1 * dtUC.Rows(0)("Contenido")
                    End If
                    Dim drRangos As DataRow() = dtRes.Select(pvCantidad1 & ">= Minimo and " & pvCantidad1 & "<=Maximo ")
                    If drRangos.Length > 0 Then
                        Dim oPrecio As Precio = New Precio(iUnidadCobranza, drRangos(0)("Precio"), sMonedaID, IIf(dtUC.Rows(0)("UnidadBase") = 1, 0, dtUC.Rows(0)("Contenido")), IIf(dtUC.Rows(0)("UnidadBase") = 1, dtUC.Rows(0)("Contenido"), 0))
                        dtRes.Dispose()
                        dtUC.Dispose()
                        Return oPrecio
                    Else
                        'Probar si el order by de la tabla me respeta el ultimo rango como el primero
                        Dim drMaximoRango As DataRow = dtRes.Select("", "Maximo DESC")(0)
                        Dim oPrecio As Precio = New Precio(iUnidadCobranza, drMaximoRango("Precio"), sMonedaID, IIf(dtUC.Rows(0)("UnidadBase") = 1, 0, dtUC.Rows(0)("Contenido")), IIf(dtUC.Rows(0)("UnidadBase") = 1, dtUC.Rows(0)("Contenido"), 0))
                        dtRes.Dispose()
                        dtUC.Dispose()
                        Return oPrecio
                    End If
                End If
                dtRes.Dispose()
                dtUC.Dispose()
                Return Nothing
            End If

            dtRes.Dispose()
            sConsultaSQL = Nothing
            Return Nothing

        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "BuscarPrecio")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "BuscarPrecio")
        End Try
        Return Nothing
    End Function

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

Public Class Precio
    Implements IDisposable

    Protected iUnidadCobranza As Integer
    Protected dPrecio As Decimal
    Protected sMonedaID As String
    Protected dFactor As Decimal
    Protected dFactor1 As Decimal

    Public Property UnidadCobranza() As Integer
        Get
            Return iUnidadCobranza
        End Get
        Set(ByVal value As Integer)
            iUnidadCobranza = value
        End Set
    End Property

    Public Property Precio() As Decimal
        Get
            Return Decimal.Round(dPrecio, oConHist.Campos("DecimalesImporte"))
        End Get
        Set(ByVal value As Decimal)
            dPrecio = value
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
    Public Property Factor() As Decimal
        Get
            Return Decimal.Round(dFactor, 4)
        End Get
        Set(ByVal value As Decimal)
            dFactor = value
        End Set
    End Property

    Public Property Factor1() As Decimal
        Get
            Return Decimal.Round(dFactor1, 4)
        End Get
        Set(ByVal value As Decimal)
            dFactor1 = value
        End Set
    End Property

    Public Sub New(ByVal pariUnidadCobranza As Integer, ByVal pardPrecio As Decimal, ByVal parsMonedaID As String, ByVal pardFactor As Decimal, ByVal pardFactor1 As Decimal)
        iUnidadCobranza = pariUnidadCobranza
        dPrecio = pardPrecio
        sMonedaID = parsMonedaID
        dFactor = pardFactor
        dFactor1 = pardFactor1
    End Sub

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free managed resources when explicitly called
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