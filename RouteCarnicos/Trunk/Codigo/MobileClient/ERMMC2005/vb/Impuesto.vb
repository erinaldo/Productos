Imports System.Data.SqlServerCe

Public Class Impuesto

    Protected sImpuestoClave As String
    'Protected sNombre As String
    Protected sAbreviatura As String
    Protected iJerarquia As Integer
    Protected tTipoAplicacion As ServicesCentral.TiposAplicacionImpuestos
    Protected tTipoValor As ServicesCentral.TiposValoresAplicacionImpuestos
    Protected nValor As Decimal
    Protected nImporte As Decimal
    Protected nImportePU As Decimal
    Protected bValidaRFC As Boolean

    Public Property ImpuestoClave() As String
        Get
            Return sImpuestoClave
        End Get
        Set(ByVal Value As String)
            sImpuestoClave = Value
        End Set
    End Property
    'Public Property Nombre() As String
    '    Get
    '        Return sNombre
    '    End Get
    '    Set(ByVal Value As String)
    '        sNombre = Value
    '    End Set
    'End Property
    Public Property Abreviatura() As String
        Get
            Return sAbreviatura
        End Get
        Set(ByVal Value As String)
            sAbreviatura = Value
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
    Public Property TipoAplicacion() As ServicesCentral.TiposAplicacionImpuestos
        Get
            Return tTipoAplicacion
        End Get
        Set(ByVal Value As ServicesCentral.TiposAplicacionImpuestos)
            tTipoAplicacion = Value
        End Set
    End Property
    Public Property TipoValor() As ServicesCentral.TiposValoresAplicacionImpuestos
        Get
            Return tTipoValor
        End Get
        Set(ByVal Value As ServicesCentral.TiposValoresAplicacionImpuestos)
            tTipoValor = Value
        End Set
    End Property
    Public Property Valor() As Decimal
        Get
            Return nValor
        End Get
        Set(ByVal Value As Decimal)
            nValor = Value
        End Set
    End Property
    Public Property Importe() As Decimal
        Get
            Return RedondeoAritmetico(nImporte, 2)
        End Get
        Set(ByVal Value As Decimal)
            nImporte = Value
        End Set
    End Property
    Public Property ImportePU() As Decimal
        Get
            'Return RedondeoAritmetico(nImportePU, 2)
            Return nImportePU
        End Get
        Set(ByVal Value As Decimal)
            nImportePU = Value
        End Set
    End Property
    Public Property ValidaRFC() As Boolean
        Get
            Return bValidaRFC
        End Get
        Set(ByVal Value As Boolean)
            bValidaRFC = Value
        End Set
    End Property

    Private DataTableImpuestos As DataTable
    Private DataTableEsquemas As DataTable
    Private DataViewEsquemas As DataView
    Private DataTableImpEsq As DataTable
    Private DataViewImpEsq As DataView

    Public Function Buscar(ByVal parsProductoClave As String, ByVal pariTipoImpuesto As Integer, ByRef refparaImpuestos As ArrayList) As Boolean
        If Me.BuscarPorProducto(parsProductoClave, pariTipoImpuesto, refparaImpuestos) Then
            Return True
            'Else
            '    'Se quitaron los impuestos por esquema porque no funcionaban y marcaban un error porque no existia las listas de busqueda...
            '    'Cuando se vuelvan a usar se tendran que descomentar estas lineas
            '    If Me.BuscarPorEsquema(parsProductoClave, refparaImpuestos) Then
            '        ' Tiene impuestos por esquemas
            '        Return True
            '    End If
        End If
        ' No tiene impuestos de ningun tipo
        Return False
    End Function

    Public Function Buscar(ByVal parsProductoClave As String, ByVal pariTipoImpuesto As Integer, ByRef refparaImpuestos As ArrayList, ByVal Fecha As Date) As Boolean
        If Me.BuscarPorProducto(parsProductoClave, pariTipoImpuesto, refparaImpuestos, Fecha) Then
            Return True
            'Else
            '    'Se quitaron los impuestos por esquema porque no funcionaban y marcaban un error porque no existia las listas de busqueda...
            '    'Cuando se vuelvan a usar se tendran que descomentar estas lineas
            '    If Me.BuscarPorEsquema(parsProductoClave, refparaImpuestos) Then
            '        ' Tiene impuestos por esquemas
            '        Return True
            '    End If
        End If
        ' No tiene impuestos de ningun tipo
        Return False
    End Function

    ''TODO: Impuestos
    Public Function Calcular(ByRef refparaImpuestos As ArrayList, ByVal parnBase As Decimal, ByVal parnPU As Decimal) As Decimal
        Dim nTotalImpuesto As Decimal = 0
        Dim nTotalImpuestoPU As Decimal = 0
        For Each refImpuesto As Impuesto In refparaImpuestos
            With refImpuesto
                Select Case .TipoValor
                    Case ServicesCentral.TiposValoresAplicacionImpuestos.Porcentaje
                        Select Case .TipoAplicacion
                            Case ServicesCentral.TiposAplicacionImpuestos.SubtotalConImpuestos
                                .Importe = (parnBase + nTotalImpuesto) * (.Valor / 100)
                                .ImportePU = (parnPU + nTotalImpuestoPU) * (.Valor / 100)
                            Case ServicesCentral.TiposAplicacionImpuestos.SubtotalSinImpuestos
                                .Importe = (parnBase * (.Valor / 100))
                                .ImportePU = (parnPU * (.Valor / 100))
                        End Select
                    Case ServicesCentral.TiposValoresAplicacionImpuestos.Importe
                        .Importe = .Valor
                        .ImportePU = .Valor
                End Select
                nTotalImpuesto += .Importe
                nTotalImpuestoPU += .ImportePU
            End With
        Next
        Return nTotalImpuesto
    End Function

    Public Function ObtenerNoDesglosablesPU(ByVal sClienteClave As String, ByVal sTransProdId As String, ByVal sTransProdDetalleId As String) As Decimal
        Dim nTotalImpuesto As Decimal = 0
        Dim sConsulta As New System.Text.StringBuilder

        sConsulta.Append("select case when sum(ImpuestoPU) is null then 0 else sum(ImpuestoPU) end as ImpuestoPU ")
        sConsulta.Append("from TpdImpuesto ")
        sConsulta.Append("where TransProdID = '" & sTransProdId & "' and TransProdDetalleId = '" & sTransProdDetalleId & "' and ImpuestoClave in ( ")
        sConsulta.Append("select ImpuestoClave ")
        sConsulta.Append("from CLINoDesImp ")
        sConsulta.Append("where ClienteClave = '" & sClienteClave & "' and getdate() between FechaInicio and FechaFin) ")

        nTotalImpuesto = oDBVen.EjecutarCmdScalardblSQL(sConsulta.ToString)
        Return nTotalImpuesto
    End Function

    Public Sub CrearListasBusqueda(ByVal pariTipoImpuesto As Integer)
        Try
            Dim sConsultaSQL As New System.Text.StringBuilder
            Dim dFechaHoraActual As New Date(Now.Year, Now.Month, Now.Day, Now.Hour, Now.Minute, Now.Second)
            'sConsultaSQL.Append("SELECT Impuesto.ImpuestoClave, Impuesto.Nombre, Impuesto.Abreviatura, Impuesto.Jerarquia, Impuesto.TipoAplicacion, Impuesto.TipoValor, ImpuestoVig.Valor FROM ImpuestoVig ")
            sConsultaSQL.Append("SELECT Impuesto.ImpuestoClave, Impuesto.Abreviatura, Impuesto.Jerarquia, Impuesto.TipoAplicacion, Impuesto.TipoValor, ImpuestoVig.Valor, Impuesto.ValidaRFC FROM ImpuestoVig ")
            sConsultaSQL.Append("INNER JOIN Impuesto ON ImpuestoVig.ImpuestoClave = Impuesto.ImpuestoClave ")
            sConsultaSQL.Append("WHERE ImpuestoVig.TipoImpuesto=" & pariTipoImpuesto & " ")
            sConsultaSQL.Append("AND " & UniFechaSQL(dFechaHoraActual) & ">=ImpuestoVig.FechaInicial AND " & UniFechaSQL(dFechaHoraActual) & "<=ImpuestoVig.FechaFinal ")
            sConsultaSQL.Append("ORDER BY Impuesto.Jerarquia")
            Me.DataTableImpuestos = odbVen.RealizarConsultaSQL(sConsultaSQL.ToString, "Impuestos")
            Me.DataTableEsquemas = odbVen.RealizarConsultaSQL("SELECT EsquemaID,EsquemaIDPadre FROM Esquema WHERE Tipo=" & ServicesCentral.TiposEsquemas.Productos, "Esquemas")
            Me.DataTableImpEsq = odbVen.RealizarConsultaSQL("SELECT ImpuestoClave, EsquemaID FROM ImpuestoEsquema", "ImpEsq")
            Me.DataViewEsquemas = New DataView(Me.DataTableEsquemas, "", "EsquemaID", DataViewRowState.CurrentRows)
            Me.DataViewImpEsq = New DataView(Me.DataTableImpEsq, "", "ImpuestoClave,EsquemaID", DataViewRowState.CurrentRows)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Function BuscarPorProducto(ByVal parsProductoClave As String, ByVal pariTipoImpuesto As Integer, ByRef refparaImpuestos As ArrayList) As Boolean
        Dim dFechaHoraActual As New Date(Now.Year, Now.Month, Now.Day, Now.Hour, Now.Minute, Now.Second)
        Return BuscarPorProducto(parsProductoClave, pariTipoImpuesto, refparaImpuestos, dFechaHoraActual)
    End Function
    Private Function BuscarPorProducto(ByVal parsProductoClave As String, ByVal pariTipoImpuesto As Integer, ByRef refparaImpuestos As ArrayList, ByVal Fecha As Date) As Boolean
        Try
            Dim DataTableImpProd As DataTable
            Dim sConsultaSQL As New System.Text.StringBuilder

            'sConsultaSQL.Append("SELECT Impuesto.ImpuestoClave, Impuesto.Nombre, Impuesto.Abreviatura, Impuesto.Jerarquia, Impuesto.TipoAplicacion, Impuesto.TipoValor, ImpuestoVig.Valor FROM ProductoImpuesto ")
            sConsultaSQL.Append("SELECT Impuesto.ImpuestoClave, Impuesto.Abreviatura, Impuesto.Jerarquia, Impuesto.TipoAplicacion, Impuesto.TipoValor, ImpuestoVig.Valor, Impuesto.ValidaRFC FROM ProductoImpuesto ")
            sConsultaSQL.Append("INNER JOIN Impuesto ON ProductoImpuesto.ImpuestoClave = Impuesto.ImpuestoClave ")
            sConsultaSQL.Append("INNER JOIN ImpuestoVig ON Impuesto.ImpuestoClave = ImpuestoVig.ImpuestoClave ")
            sConsultaSQL.Append("WHERE ProductoImpuesto.ProductoClave = '" & parsProductoClave & "' ")
            sConsultaSQL.Append("AND " & UniFechaSQL(Fecha) & ">=ImpuestoVig.FechaInicial AND " & UniFechaSQL(Fecha) & "<=ImpuestoVig.FechaFinal ")
            sConsultaSQL.Append("AND ImpuestoVig.TipoImpuesto=" & pariTipoImpuesto & " ")
            sConsultaSQL.Append("ORDER BY Impuesto.Jerarquia")
            DataTableImpProd = oDBVen.RealizarConsultaSQL(sConsultaSQL.ToString, "ProductoImpuesto")
            If DataTableImpProd.Rows.Count = 0 Then
                ' El producto no tiene asignados impuestos
                DataTableImpProd.Dispose()
                Return False
            End If
            ' Recuperar todos los impuestos para este producto
            For Each refDataRow As DataRow In DataTableImpProd.Rows
                Dim oImpuesto As New Impuesto
                ' Tomar las propiedades del impuesto
                With refDataRow
                    oImpuesto.ImpuestoClave = .Item("ImpuestoClave")
                    'oImpuesto.Nombre = .Item("Nombre")
                    oImpuesto.Abreviatura = .Item("Abreviatura")
                    oImpuesto.Jerarquia = .Item("Jerarquia")
                    oImpuesto.TipoValor = .Item("TipoValor")
                    oImpuesto.TipoAplicacion = .Item("TipoAplicacion")
                    oImpuesto.Valor = .Item("Valor")
                    'oImpuesto.ValidaRFC = IIf(.Item("ValidaRFC") = 1, True, False)
                    oImpuesto.ValidaRFC = .Item("ValidaRFC")
                End With
                ' Agregarlo a la lista de impuestos a aplicar
                refparaImpuestos.Add(oImpuesto)
            Next
            DataTableImpProd.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return refparaImpuestos.Count <> 0
    End Function

    Private Function BuscarPorEsquema(ByVal parsProductoClave As String, ByRef refparaImpuestos As ArrayList) As Boolean
        Try
            Dim DataTableProd As DataTable
            DataTableProd = odbVen.RealizarConsultaSQL("SELECT EsquemaID FROM ProductoEsquema WHERE ProductoClave='" & parsProductoClave & "'", "ProductoEsquema")
            If DataTableProd.Rows.Count = 0 Then
                ' El producto no pertenece al menos a un esquema de productos
                DataTableProd.Dispose()
                Return False
            End If
            If Me.DataTableImpuestos.Rows.Count = 0 Then
                ' No hay impuestos definidos
                DataTableImpuestos.Dispose()
                Return False
            End If
            If Me.DataTableEsquemas.Rows.Count = 0 Then
                ' No hay esquemas de productos definidos
                DataTableEsquemas.Dispose()
                Return False
            End If
            If Me.DataTableImpEsq.Rows.Count = 0 Then
                ' No hay impuestos asociados a esquemas
                DataTableImpEsq.Dispose()
                Return False
            End If
            Dim iImp As Integer
            Dim sImpuestoClave As String
            ' Verificar si aplica cada uno de los impuestos que aplican para el tipo de impuesto
            For Each refDataRowImp As DataRow In Me.DataTableImpuestos.Rows
                ' Para cada uno de los esquemas a los que pertenece el producto
                For Each refDataRowProd As DataRow In DataTableProd.Rows
                    ' Formar la llave de busqueda en ImpuestoEsquema (ImpuestoClave + EsquemaID)
                    Dim oEsquema(1) As Object
                    sImpuestoClave = refDataRowImp("ImpuestoClave")
                    oEsquema(0) = sImpuestoClave
                    oEsquema(1) = refDataRowProd("EsquemaID")
                    ' Buscar el ImpuestoClave + EsquemaID en ImpuestoEsquema (para Productos)
                    iImp = Me.DataViewImpEsq.Find(oEsquema)
                    ' Si no lo encontro
                    If iImp = -1 Then
                        ' Buscar en los Esquemas ascendentes
                        iImp = Me.BuscarGrupo(Me.DataViewEsquemas, Me.DataViewImpEsq, oEsquema(1), sImpuestoClave)
                    End If
                    ' Si encontro algun esquema con este impuesto
                    If iImp <> -1 Then
                        ' Crear un objeto de tipo Impuesto para agregarlo a la lista de impuestos que se aplican
                        Dim oImpuesto As New Impuesto
                        ' Tomar las propiedades del impuesto
                        With refDataRowImp
                            oImpuesto.ImpuestoClave = sImpuestoClave
                            'oImpuesto.Nombre = .Item("Nombre")
                            oImpuesto.Abreviatura = .Item("Abreviatura")
                            oImpuesto.Jerarquia = .Item("Jerarquia")
                            oImpuesto.TipoValor = .Item("TipoValor")
                            oImpuesto.TipoAplicacion = .Item("TipoAplicacion")
                            oImpuesto.Valor = .Item("Valor")
                            'oImpuesto.ValidaRFC = IIf(.Item("ValidaRFC") = 1, True, False)
                            oImpuesto.ValidaRFC = .Item("ValidaRFC")
                        End With
                        ' Agregarlo a la lista de impuestos a aplicar
                        refparaImpuestos.Add(oImpuesto)
                    End If
                Next
            Next
            DataTableImpuestos.Dispose()
            DataTableProd.Dispose()
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "VerificarPorEsquema")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "VerificarPorEsquema")
        End Try
        Return refparaImpuestos.Count <> 0
    End Function

    Private Function BuscarGrupo(ByRef refparDataViewEsquemas As DataView, ByRef refparDataViewImpEsq As DataView, ByVal refparsNodo As String, ByVal parsImpuestoClave As String) As Integer
        Try
            ' Buscar el padre del nodo
            Dim iEsq As Integer = refparDataViewEsquemas.Find(refparsNodo)
            ' Si se encuentra
            If iEsq <> -1 Then
                If Not refparDataViewEsquemas.Item(iEsq).Row.IsNull("EsquemaIDPadre") Then
                    ' Recuperar el padre del nodo encontrado
                    Dim oEsquema(1) As Object
                    oEsquema(0) = parsImpuestoClave
                    ' Conformar el elemento a buscar en el dataview de ImpuestoEsquema, considerando la clave de impuesto
                    oEsquema(1) = refparDataViewEsquemas.Item(iEsq).Item("EsquemaIDPadre")
                    ' Buscar el nodo en los impuestos por esquemas por productos
                    iEsq = refparDataViewImpEsq.Find(oEsquema)
                    ' Si se encontro
                    If iEsq <> -1 Then
                        Return iEsq
                    Else
                        ' No se encontro, seguir buscando en el arbol hacia arriba
                        Return BuscarGrupo(refparDataViewEsquemas, refparDataViewImpEsq, oEsquema(1), parsImpuestoClave)
                    End If
                End If
            End If
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "BuscarGrupo")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "BuscarGrupo")
        End Try
        Return -1
    End Function
    'TODO: Corregir Impuestos
    Public Function GuardarDetalle(ByVal parsTransProdId As String, ByVal parsTransProdDetalleId As String, ByRef refparaImpuestos As ArrayList) As Boolean
        Try
            Dim sTPDImpuestoId As String = ""
            ' Borrar los impuestos anteriores
            oDBVen.EjecutarComandoSQL("DELETE FROM TPDImpuesto WHERE TransProdId='" & parsTransProdId & "' AND TransProdDetalleID='" & parsTransProdDetalleId & "'")
            For Each refImpuesto As Impuesto In refparaImpuestos
                ' Obtener el proximo ID de TPDimpuesto
                If Folio.ObtenerTransProdDetalleImpuestoId(parsTransProdId, parsTransProdDetalleId, sTPDImpuestoId) Then
                    Dim sComandoSQL As New System.Text.StringBuilder
                    sComandoSQL.Append("INSERT INTO TPDImpuesto (TransProdID, TransProdDetalleID, TPDImpuestoID, ImpuestoClave, ImpuestoPor, ImpuestoImp, ImpuestoPU, ImpDesGlb, MFechaHora, MUsuarioID) VALUES (")
                    With refImpuesto
                        sComandoSQL.Append("'" & parsTransProdId & "',")
                        sComandoSQL.Append("'" & parsTransProdDetalleId & "',")
                        sComandoSQL.Append("'" & sTPDImpuestoId & "',")
                        sComandoSQL.Append("'" & .ImpuestoClave & "',")
                        sComandoSQL.Append(.Valor & ",")
                        sComandoSQL.Append(.Importe & ",")
                        sComandoSQL.Append(.ImportePU & ",")
                        sComandoSQL.Append(.Importe & ",") 'ImpDesGlb, para el caso de las ventas se actualiza en ActualizaImpDesGlb considerando los descuentos de cliente y vendedor
                        sComandoSQL.Append(UniFechaSQL(Now) & ",")
                        sComandoSQL.Append("'" & oVendedor.UsuarioId & "')")
                    End With
                    oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
                End If
            Next
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Public Function ActualizaImpDesGlb(ByVal parsTransProdId As String, ByVal parsTransProdDetalleId As String, ByVal parsTPDImpuestoId As String, ByVal pardImpDesGlb As Decimal) As Boolean
        Try

            Dim sComandoSQL As New System.Text.StringBuilder
            sComandoSQL.Append("UPDATE TPDImpuesto SET ")
            'sComandoSQL.Append("ImpuestoPU = " & pardImpuestoPU & ", ")
            sComandoSQL.Append("ImpDesGlb = " & pardImpDesGlb & " ")
            sComandoSQL.Append("WHERE TransProdId='" & parsTransProdId & "' AND TransProdDetalleID='" & parsTransProdDetalleId & "' and TPDImpuestoId = '" & parsTPDImpuestoId & "'")
            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)

            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Public Shared Function ObtenerCadenaIDsImpuestos(ByRef refparaArrayList As ArrayList) As String
        If refparaArrayList.Count = 0 Then
            Return "<Ningun elemento>"
        End If
        Dim sRetorno As String = ""
        For Each refImpuesto As Impuesto In refparaArrayList
            If sRetorno <> "" Then
                sRetorno &= ", "
            End If
            sRetorno &= refImpuesto.ImpuestoClave & " (" & refImpuesto.Abreviatura & ")"
        Next
        Return sRetorno
    End Function

    Public Sub RecalcularGlobal(ByVal oTransProd As TransProd)
        Dim sQuery As New System.Text.StringBuilder
        Dim oDt As DataTable

        'Impuestos del producto (descuento de producto y promociones)
        Dim oArrImpClave As New ArrayList
        'Dim oArrImpCant As New ArrayList
        Dim oArrImpTipoValor As New ArrayList

        sQuery.Append("SELECT Distinct Imp.ImpuestoClave, Jerarquia, TipoValor from TPDImpuesto TPDI INNER JOIN Impuesto as Imp ON TPDI.ImpuestoClave=Imp.ImpuestoClave WHERE TPDI.transprodid = '" & oTransProd.TransProdId & "' ORDER BY Jerarquia")
        oDt = oDBVen.RealizarConsultaSQL(sQuery.ToString, "Impuestos")

        For Each oDr As DataRow In oDt.Rows
            oArrImpClave.Add(oDr("ImpuestoClave"))
            'oArrImpCant.Add(0)
            oArrImpTipoValor.Add(oDr("TipoValor"))
        Next
        oDt.Dispose()

        'Descuentos por cliente
        Dim oArrDescuentos As New ArrayList

        sQuery = New System.Text.StringBuilder
        sQuery.Append("SELECT DesPor,Jerarquia,TipoCascada FROM TpdDes WHERE TransProdId = '" & oTransProd.TransProdId & "' group by DescuentoClave,DesPor,Jerarquia,TipoCascada ORDER BY Jerarquia ASC")
        oDt = oDBVen.RealizarConsultaSQL(sQuery.ToString, "TpdDes")

        For Each oDr As DataRow In oDt.Rows
            oArrDescuentos.Add(oDr)
        Next
        oDt.Dispose()

        'Para cada TransProdDetalle recalcular impuestos contemplando descuentos de cliente y de vendedor
        sQuery = New System.Text.StringBuilder
        sQuery.Append("SELECT TransProdID, TransProdDetalleID FROM TransProdDetalle WHERE TransProdId = '" & oTransProd.TransProdId & "'")
        oDt = oDBVen.RealizarConsultaSQL(sQuery.ToString, "TransProdDetalle")

        For Each oDrTPD As DataRow In oDt.Rows
            For i As Integer = 0 To oArrImpClave.Count - 1
                Dim dtImp As DataTable = oDBVen.RealizarConsultaSQL("SELECT ImpuestoImp, TPDImpuestoId FROM TPDImpuesto WHERE TransProdId ='" & oDrTPD("TransProdID") & "' AND TransProdDetalleId='" & oDrTPD("TransProdDetalleId") & "' AND ImpuestoClave='" & oArrImpClave(i) & "'", "TPDImpuesto")
                Dim sTPDImpuestoId As String = ""
                Dim dTotImp As Double = 0

                If dtImp.Rows.Count > 0 Then
                    sTPDImpuestoId = dtImp.Rows(0)("TPDImpuestoId")
                    dTotImp = dtImp.Rows(0)("ImpuestoImp")
                End If

                Dim dImpActual As Double = dTotImp
                'Dim dImpPU As Double

                'Descuentos del cliente
                If dTotImp > 0 Then
                    If (oArrImpTipoValor(i) = 1) Then
                        For j As Integer = 0 To oArrDescuentos.Count - 1
                            If CType(oArrDescuentos(j), DataRow)("TipoCascada") Then
                                'dImpActual -= RedondeoAritmetico(dImpActual * CType(oArrDescuentos(j), DataRow)("DesPor") / 100, 2)
                                dImpActual -= dImpActual * CType(oArrDescuentos(j), DataRow)("DesPor") / 100
                            Else
                                'dImpActual -= RedondeoAritmetico(dTotImp * CType(oArrDescuentos(j), DataRow)("DesPor") / 100, 2)
                                dImpActual -= dTotImp * CType(oArrDescuentos(j), DataRow)("DesPor") / 100
                            End If
                        Next

                        'Descuento del vendedor
                        'dImpActual -= RedondeoAritmetico(dImpActual * oTransProd.DescVendPor / 100, 2)
                        dImpActual -= dImpActual * oTransProd.DescVendPor / 100
                    End If

                    'Actualizar TPDImpuesto.ImpDesGlb con el valor dImpActual
                    'Me.ActualizaImpDesGlb(oDrTPD("TransProdID"), oDrTPD("TransProdDetalleID"), sTPDImpuestoId, RedondeoAritmetico(dImpActual, 2))
                    Me.ActualizaImpDesGlb(oDrTPD("TransProdID"), oDrTPD("TransProdDetalleID"), sTPDImpuestoId, dImpActual)
                    'oArrImpCant(i) += dImpActual
                End If
            Next
        Next
    End Sub

End Class
