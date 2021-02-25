Imports System.Data.SqlServerCe

Public Class Descuento

    Protected sDescuentoClave As String
    Protected sNombre As String
    Protected tTipo As ServicesCentral.TiposDescuentos
    Protected iPermitirCascada As Boolean
    Protected tTipoAplicacion As ServicesCentral.TiposAplicacionDescuentos
    Protected nValorAplicacion As Decimal
    Protected tTipoValor As ServicesCentral.TiposValoresDescuentos
    Protected iJerarquia As Integer
    Protected nImporteCalculado As Decimal
    Protected nPorcentajeCalculado As Decimal
    Protected tTipoInspeccion As ServicesCentral.TiposInspeccionDescuentos
    Protected bEsNuevo As Boolean

    Public Property DescuentoClave() As String
        Get
            Return sDescuentoClave
        End Get
        Set(ByVal Value As String)
            sDescuentoClave = Value
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
    Public Property Tipo() As ServicesCentral.TiposDescuentos
        Get
            Return tTipo
        End Get
        Set(ByVal Value As ServicesCentral.TiposDescuentos)
            tTipo = Value
        End Set
    End Property
    Public Property PermitirCascada() As Boolean
        Get
            Return iPermitirCascada
        End Get
        Set(ByVal Value As Boolean)
            iPermitirCascada = Value
        End Set
    End Property
    Public Property TipoAplicacion() As ServicesCentral.TiposAplicacionDescuentos
        Get
            Return tTipoAplicacion
        End Get
        Set(ByVal Value As ServicesCentral.TiposAplicacionDescuentos)
            tTipoAplicacion = Value
        End Set
    End Property
    Public Property ValorAplicacion() As Decimal
        Get
            Return nValorAplicacion
        End Get
        Set(ByVal Value As Decimal)
            nValorAplicacion = Value
        End Set
    End Property
    Public Property TipoValor() As ServicesCentral.TiposValoresDescuentos
        Get
            Return tTipoValor
        End Get
        Set(ByVal Value As ServicesCentral.TiposValoresDescuentos)
            tTipoValor = Value
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
    Public Property ImporteCalculado() As Decimal
        Get
            Return nImporteCalculado
        End Get
        Set(ByVal Value As Decimal)
            nImporteCalculado = Value
        End Set
    End Property
    Public Property PorcentajeCalculado() As Decimal
        Get
            Return nPorcentajeCalculado
        End Get
        Set(ByVal Value As Decimal)
            nPorcentajeCalculado = Value
        End Set
    End Property

    Public Property EsNuevo() As Boolean
        Get
            Return bEsNuevo
        End Get
        Set(ByVal Value As Boolean)
            bEsNuevo = Value
        End Set
    End Property
    Private DataTableDesctosProd As DataTable
    Private DataViewDesctosProd As DataView

    Public Shared Function VerificarAplicacion(ByVal parsModuloMovDetClave As String, ByVal parsNombreCampoAplicacion As String) As Boolean
        Try
            ' Primero verificar si se pueden aplicar descuentos por cliente en este modulo
            Dim DataTableVend As DataTable = oDBVen.RealizarConsultaSQL("SELECT " & parsNombreCampoAplicacion & " FROM VendedorDescuento WHERE VendedorID='" & oVendedor.VendedorId & "' AND ModuloMovDetalleClave='" & parsModuloMovDetClave & "' AND TipoEstado=1 ", "VendedorDescuento")
            If DataTableVend.Rows.Count = 0 Then
                ' No estan especificadas las opciones de descuentos por modulo
                DataTableVend.Dispose()
                Return False
            End If
            If DataTableVend.Rows(0).IsNull(parsNombreCampoAplicacion) Then
                ' No se ha indicado que los descuentos aplican por cliente para el modulo
                DataTableVend.Dispose()
                Return False
            End If
            If Not DataTableVend.Rows(0).Item(parsNombreCampoAplicacion) Then
                ' No aplican descuentos por cliente para el modulo
                DataTableVend.Dispose()
                Return False
            End If
            DataTableVend.Dispose()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Public Function BuscarAplicablesAlClientePorCliente(ByVal parsClienteClave As String, ByRef refparaDescuentos As ArrayList) As Boolean
        Try
            ' Verificar si existen descuentos para el cliente, considerando el modulo
            Dim sConsultaSQL As New System.Text.StringBuilder
            sConsultaSQL.Append("SELECT Descuento.DescuentoClave, Descuento.Nombre, Descuento.Tipo, Descuento.PermiteCascada, Descuento.TipoAplicacion, Descuento.ValorAplicacion, ")
            sConsultaSQL.Append("Descuento.TipoValor, DESCliente.Jerarquia FROM Descuento INNER JOIN DESCliente ON Descuento.DescuentoClave = DESCliente.DescuentoClave ")
            sConsultaSQL.Append("WHERE DESCliente.ClienteClave='" & parsClienteClave & "' ")
            ' Cambios 05 Mayo 2006
            ' Si es un registro nuevo, solo considerar los registros activos
            If Me.EsNuevo Then
                ' Cambios 05 Mayo 2006 (B)
                sConsultaSQL.Append("AND Descuento.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
                sConsultaSQL.Append("AND DESCliente.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
                ' / Cambios 05 Mayo 2006 (B)
                ' Cambios 10 Mayo 2006
                sConsultaSQL.Append("AND Descuento.Baja<>1 ")
                ' / Cambios 10 Mayo 2006
            Else
                ' De lo contrario, considerar todos los registros
            End If
            ' /Cambios 05 Mayo 2006
            sConsultaSQL.Append("ORDER BY DESCliente.Jerarquia")
            Dim DataTableDesc As DataTable = odbVen.RealizarConsultaSQL(sConsultaSQL.ToString, "Descuentos")
            If DataTableDesc.Rows.Count > 0 Then
                For Each refDataRow As DataRow In DataTableDesc.Rows
                    Dim oDescuento As New Descuento
                    With refDataRow
                        oDescuento.DescuentoClave = .Item("DescuentoClave")
                        oDescuento.Nombre = .Item("Nombre")
                        oDescuento.Tipo = .Item("Tipo")
                        oDescuento.PermitirCascada = .Item("PermiteCascada")
                        oDescuento.TipoAplicacion = .Item("TipoAplicacion")
                        oDescuento.ValorAplicacion = .Item("ValorAplicacion")
                        oDescuento.TipoValor = .Item("TipoValor")
                        oDescuento.Jerarquia = .Item("Jerarquia")
                    End With
                    refparaDescuentos.Add(oDescuento)
                Next
            End If
            DataTableDesc.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return refparaDescuentos.Count <> 0
    End Function

    Public Function BuscarAplicablesAlClientePorEsquema(ByVal parsClienteClave As String, ByRef refparaDescuentos As ArrayList) As Boolean
        Try
            ' Recuperar la lista de descuentos que apliquen por cliente, para el modulo seleccionado
            Dim sEsquemasCliente As String = String.Empty

            Dim DataTableEsquemas As DataTable
            Dim DataViewEsquemas As DataView
            oAgenda.ClienteActual.RecuperarEsquemas(DataViewEsquemas, DataTableEsquemas)

            For Each dr As DataRow In DataTableEsquemas.Rows
                sEsquemasCliente &= "'" & dr("EsquemaID") & "',"
                oAgenda.ClienteActual.RecuperarEsquemasCliente(DataViewEsquemas, sEsquemasCliente, dr("EsquemaID"))
            Next
            If sEsquemasCliente.Length > 0 Then
                sEsquemasCliente = Left(sEsquemasCliente, sEsquemasCliente.Length - 1)
            End If

            DataTableEsquemas.Dispose()
            DataViewEsquemas.Dispose()
            ' DataTable de Esquemas (para buscar ascendentemente)
            Dim sConsultaSQL As New System.Text.StringBuilder
            sConsultaSQL.Append("SELECT Descuento.DescuentoClave, Descuento.Nombre, Descuento.Tipo, Descuento.PermiteCascada, Descuento.TipoAplicacion, Descuento.ValorAplicacion, ")
            sConsultaSQL.Append("Descuento.TipoValor, DESDetalle.Jerarquia, DESDetalle.EsquemaID ")
            sConsultaSQL.Append("FROM Descuento INNER JOIN DESDetalle ON Descuento.DescuentoClave = DESDetalle.DescuentoClave ")
            ' Cambios 05 Mayo 2006
            ' Si es un registro nuevo, solo considerar los registros activos
            If Me.EsNuevo Then
                sConsultaSQL.Append("WHERE Descuento.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
                ' Cambios 05 Mayo 2006 (B)
                sConsultaSQL.Append("AND DESDetalle.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
                ' / Cambios 05 Mayo 2006 (B)
                ' Cambios 10 Mayo 2006
                sConsultaSQL.Append("AND Descuento.Baja<>1 ")
                sConsultaSQL.Append("AND DESDetalle.EsquemaID in (" & sEsquemasCliente & ")")
                ' / Cambios 10 Mayo 2006
            Else
                ' De lo contrario, considerar todos los registros
                sConsultaSQL.Append("WHERE DESDetalle.EsquemaID in (" & sEsquemasCliente & ") ")
            End If
            ' /Cambios 05 Mayo 2006
            sConsultaSQL.Append("ORDER BY DESDetalle.Jerarquia")
            Dim DataTableDesctos As DataTable = odbVen.RealizarConsultaSQL(sConsultaSQL.ToString, "Descuentos")
            ' Si no tiene descuentos
            If DataTableDesctos.Rows.Count = 0 Then
                ' No hay descuentos por esquema de clientes
                DataTableDesctos.Dispose()
                Return False
            End If
            Dim oArrClavesDescuentos As New ArrayList
            'Recorrer todos los descuentos que pertenecen a un esquema del cliente
            If DataTableDesctos.Rows.Count > 0 Then
                For Each refDataRow As DataRow In DataTableDesctos.Rows
                    With refDataRow
                        If Not oArrClavesDescuentos.Contains(refDataRow("DescuentoClave")) Then
                            Dim oDescuento As New Descuento
                            oDescuento.DescuentoClave = .Item("DescuentoClave")
                            oDescuento.Nombre = .Item("Nombre")
                            oDescuento.Tipo = .Item("Tipo")
                            oDescuento.PermitirCascada = .Item("PermiteCascada")
                            oDescuento.TipoAplicacion = .Item("TipoAplicacion")
                            oDescuento.ValorAplicacion = .Item("ValorAplicacion")
                            oDescuento.TipoValor = .Item("TipoValor")
                            oDescuento.Jerarquia = .Item("Jerarquia")

                            oArrClavesDescuentos.Add(.Item("DescuentoClave"))
                            refparaDescuentos.Add(oDescuento)
                        End If
                    End With

                Next
            End If
            DataTableDesctos.Dispose()

            ' DataView para recorrer los esquemas a los que aplica el descuento
            'Dim DataViewDesctos As New DataView(DataTableDesctos, "", "EsquemaID", DataViewRowState.CurrentRows)
            'DataTableDesctos.Dispose()

            'Dim refDataRowViewRows() As DataRowView
            '' Para cada esquema al que pertenece el cliente
            'For Each refDataRow As DataRow In DataTableCliente.Rows
            '    ' Formar la llave de busqueda en DescuentoEsquema (DescuentoClave + EsquemaID)
            '    Dim oEsquema As Object
            '    oEsquema = refDataRow("EsquemaID")
            '    ' Buscar el DescuentoClave + EsquemaID en DataViewDescEsq
            '    refDataRowViewRows = DataViewDesctos.FindRows(oEsquema)
            '    ' Se encontraron varios esquemas que aplican
            '    If refDataRowViewRows.Length = 0 Then
            '        refDataRowViewRows = Me.BuscarGrupo(DataViewEsquemas, DataViewDesctos, oEsquema)
            '    End If
            '    ' Considerar cada descuento
            '    If Not refDataRowViewRows Is Nothing Then
            '        For Each refDataRowView As DataRowView In refDataRowViewRows
            '            Dim oDescuento As New Descuento
            '            With refDataRowView
            '                oDescuento.DescuentoClave = .Item("DescuentoClave")
            '                oDescuento.Nombre = .Item("Nombre")
            '                oDescuento.Tipo = .Item("Tipo")
            '                oDescuento.PermitirCascada = .Item("PermiteCascada")
            '                oDescuento.TipoAplicacion = .Item("TipoAplicacion")
            '                oDescuento.ValorAplicacion = .Item("ValorAplicacion")
            '                oDescuento.TipoValor = .Item("TipoValor")
            '                oDescuento.Jerarquia = .Item("Jerarquia")
            '            End With
            '            refparaDescuentos.Add(oDescuento)
            '        Next
            '    End If
            'Next
            'DataTableCliente.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return refparaDescuentos.Count <> 0
    End Function

    Public Function BuscarAplicablesAlProductoPorProducto(ByVal parsProductoClave As String, ByVal parsTipoUnidad As Integer, ByVal parsCantidad As Integer, ByRef refparaDescuento As Descuento) As Boolean
        Try
            Dim sConsultaSQL As New System.Text.StringBuilder
            sConsultaSQL.Append("SELECT Descuento.DescuentoClave, Descuento.Nombre, Descuento.Tipo, Descuento.PermiteCascada, Descuento.TipoAplicacion, Descuento.ValorAplicacion, ")
            sConsultaSQL.Append("Descuento.TipoValor FROM Descuento ")
            sConsultaSQL.Append("INNER JOIN DESRegla ON Descuento.DescuentoClave = DESRegla.DescuentoClave ")
            ' Cambios 05 Mayo 2006
            sConsultaSQL.Append("WHERE DESRegla.ProductoClave='" & parsProductoClave & "' ")
            ' Si es un registro nuevo, solo considerar los registros activos
            'If Me.EsNuevo Then
            ' Cambios 05 Mayo 2006 (B)
            sConsultaSQL.Append("AND Descuento.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            sConsultaSQL.Append("AND DESRegla.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            ' / Cambios 05 Mayo 2006 (B)
            ' Cambios 10 Mayo 2006
            sConsultaSQL.Append("AND Descuento.Baja<>1 ")
            ' / Cambios 10 Mayo 2006
            'Else
            ' De lo contrario, considerar todos los registros
            'End If
            ' /Cambios 05 Mayo 2006
            Dim DataTableDesc As DataTable = oDBVen.RealizarConsultaSQL(sConsultaSQL.ToString, "Descuentos")
            If DataTableDesc.Rows.Count > 0 Then
                Dim refDataRow As DataRow = DataTableDesc.Rows(0)
                refparaDescuento = New Descuento
                With refDataRow
                    refparaDescuento.DescuentoClave = .Item("DescuentoClave")
                    refparaDescuento.Nombre = .Item("Nombre")
                    refparaDescuento.Tipo = .Item("Tipo")
                    refparaDescuento.PermitirCascada = .Item("PermiteCascada")
                    refparaDescuento.TipoAplicacion = .Item("TipoAplicacion")
                    refparaDescuento.ValorAplicacion = .Item("ValorAplicacion")
                    refparaDescuento.TipoValor = .Item("TipoValor")
                    refparaDescuento.Jerarquia = 0
                End With
                DataTableDesc.Dispose()
                Return True
            End If
            DataTableDesc.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Public Function BuscarAplicablesAlProductoPorEsquema(ByVal parsProductoClave As String, ByRef refparoDescuento As Descuento) As Boolean
        Try
            Dim sConsultaSQL As New System.Text.StringBuilder
            sConsultaSQL.Append("SELECT Descuento.DescuentoClave, Descuento.Nombre, Descuento.Tipo, Descuento.PermiteCascada, Descuento.TipoAplicacion, Descuento.ValorAplicacion, ")
            sConsultaSQL.Append("Descuento.TipoValor, DESDetalle.Jerarquia, DESDetalle.EsquemaID FROM Descuento ")
            sConsultaSQL.Append("INNER JOIN DESDetalle ON Descuento.DescuentoClave = DESDetalle.DescuentoClave ")
            ' Cambios 05 Mayo 2006
            ' Si es un registro nuevo, solo considerar los registros activos
            If Me.EsNuevo Then
                sConsultaSQL.Append("WHERE Descuento.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
                ' Cambios 05 Mayo 2006 (B)
                sConsultaSQL.Append("AND DESDetalle.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
                ' / Cambios 05 Mayo 2006 (B)
                ' Cambios 10 Mayo 2006
                sConsultaSQL.Append("AND Descuento.Baja<>1 ")
                ' / Cambios 10 Mayo 2006
            Else
                ' De lo contrario, considerar todos los registros
            End If
            ' /Cambios 05 Mayo 2006
            sConsultaSQL.Append("ORDER BY DESDetalle.Jerarquia")
            Dim DataTableDesctos As DataTable = odbVen.RealizarConsultaSQL(sConsultaSQL.ToString, "Descuentos")
            If DataTableDesctos.Rows.Count = 0 Then
                DataTableDesctos.Dispose()
                Return False
            End If
            ' DataView para recorrer los esquemas a los que aplica el descuento
            Dim DataViewDesctos As New DataView(DataTableDesctos, "", "EsquemaID", DataViewRowState.CurrentRows)
            DataTableDesctos.Dispose()
            ' Crear los DataTables y DataViews para buscar los productos
            Dim DataTableProducto As DataTable
            DataTableProducto = oDBVen.RealizarConsultaSQL("SELECT EsquemaID FROM ProductoEsquema WHERE ProductoClave='" & parsProductoClave & "'", "ProductoEsquema")
            If DataTableProducto.Rows.Count = 0 Then
                ' El Producto no pertenece al menos a un esquema de productos
                DataTableProducto.Dispose()
                Return False
            End If
            ' DataTable de Esquemas (para buscar ascendentemente)
            Dim DataTableEsquemas As DataTable = oDBVen.RealizarConsultaSQL("SELECT EsquemaID,EsquemaIDPadre FROM Esquema WHERE Tipo=" & ServicesCentral.TiposEsquemas.Productos, "Esquema")
            If DataTableEsquemas.Rows.Count = 0 Then
                ' No hay esquemas de clientes definidos
                DataTableProducto.Dispose()
                DataTableEsquemas.Dispose()
                Return False
            End If
            Dim DataViewEsquemas As New DataView(DataTableEsquemas, "", "EsquemaID", DataViewRowState.CurrentRows)
            DataTableEsquemas.Dispose()
            Dim refDataRowViewRows() As DataRowView
            ' Para cada esquema al que pertenece el producto
            For Each refDataRow As DataRow In DataTableProducto.Rows
                ' Formar la llave de busqueda en DescuentoEsquema 
                Dim oEsquema As Object
                oEsquema = refDataRow("EsquemaID")
                refDataRowViewRows = DataViewDesctos.FindRows(oEsquema)
                ' Se encontraron varios esquemas que aplican
                If refDataRowViewRows.Length = 0 Then
                    refDataRowViewRows = Me.BuscarGrupo(DataViewEsquemas, DataViewDesctos, oEsquema)
                End If
                ' Considerar solo el primero descuento
                If Not refDataRowViewRows Is Nothing Then
                    If refDataRowViewRows.Length > 0 Then
                        Dim refDataRowView As DataRowView = refDataRowViewRows(0)
                        refparoDescuento = New Descuento
                        With refDataRowView
                            refparoDescuento.DescuentoClave = .Item("DescuentoClave")
                            refparoDescuento.Nombre = .Item("Nombre")
                            refparoDescuento.Tipo = .Item("Tipo")
                            refparoDescuento.PermitirCascada = .Item("PermiteCascada")
                            refparoDescuento.TipoAplicacion = .Item("TipoAplicacion")
                            refparoDescuento.ValorAplicacion = .Item("ValorAplicacion")
                            refparoDescuento.TipoValor = .Item("TipoValor")
                            refparoDescuento.Jerarquia = .Item("Jerarquia")
                        End With
                        DataTableProducto.Dispose()
                        Return True
                    End If
                End If
            Next
            DataTableProducto.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Private Function BuscarGrupo(ByRef refparDataViewEsquemas As DataView, ByRef refparDataViewDesctos As DataView, ByVal refparsNodo As String) As DataRowView()
        Dim refDataRowViewRows() As DataRowView
        Try
            ' Buscar el padre del nodo
            Dim iEsq As Integer = refparDataViewEsquemas.Find(refparsNodo)
            ' Si se encuentra
            If iEsq <> -1 Then
                If Not refparDataViewEsquemas.Item(iEsq).Row.IsNull("EsquemaIDPadre") Then
                    ' Recuperar el padre del nodo encontrado
                    Dim oEsquema As Object
                    ' Conformar el elemento a buscar en el dataview de ImpuestoEsquema, considerando la clave de impuesto
                    oEsquema = refparDataViewEsquemas.Item(iEsq).Item("EsquemaIDPadre")
                    refDataRowViewRows = refparDataViewDesctos.FindRows(oEsquema)
                    ' Si se encontro
                    If refDataRowViewRows.Length <> 0 Then
                        ' Regresar true indicando que este descuento se aplica
                        Return refDataRowViewRows
                    Else
                        ' No se encontro, seguir buscando en el arbol hacia arriba
                        Return BuscarGrupo(refparDataViewEsquemas, refparDataViewDesctos, oEsquema)
                    End If
                End If
            End If
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "BuscarGrupo")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "BuscarGrupo")
        End Try
        Return refDataRowViewRows
    End Function

    Public Function CalcularAplicablesAlCliente(ByRef refparaDescuentos As ArrayList, ByVal parnSubTotal As Decimal, ByVal parnImpuesto As Decimal, ByVal parsTransProdID As String) As Boolean
        Try
            ' Cambios 28 Abril 2006
            ' Si la lista esta vacia o si el subtotal es cero
            If refparaDescuentos.Count = 0 Or parnSubTotal <= 0 Then
                Return False
            End If
            ' /Cambios 28 Abril 2006

            Dim nBase As Decimal = parnSubTotal
            Dim nBaseImpuesto As Decimal = parnImpuesto
            ' El descuento de mayor jerarquia permite cascada, calcular el descuento
            oDBVen.EjecutarComandoSQL("DELETE FROM TpdDes WHERE TransProdId='" & parsTransProdID & "'")
            oDBVen.EjecutarComandoSQL("Update TransProdDetalle set DesImporteT = 0 , DesImpuestoT = 0 WHERE TransProdId='" & parsTransProdID & "'")

            For Each refDescuento As Descuento In refparaDescuentos
                If refDescuento.Tipo = ServicesCentral.TiposDescuentos.Inmediato Then
                    Select Case refDescuento.TipoValor
                        Case ServicesCentral.TiposValoresDescuentos.Importe
                            ' Calcular los descuentos del cliente sobre el subtotal
                            Dim nPorcentaje As Double
                            nPorcentaje = (refDescuento.ValorAplicacion * 100) / parnSubTotal
                            oDBVen.EjecutarComandoSQL("INSERT INTO TpdDes select TPD.TransProdID, TPD.TransProdDetalleID,'" & refDescuento.DescuentoClave & "'," & nPorcentaje & ", TPD.Subtotal  * " & (nPorcentaje / 100) & ", TPD.Impuesto * " & (nPorcentaje / 100) & "," & refDescuento.Jerarquia & " , 0, getdate(),'" & oVendedor.UsuarioId & "',0 from TransProdDetalle TPD where TPD.TransProdID ='" & parsTransProdID & "' and TPD.Subtotal>0 ")

                            oDBVen.EjecutarComandoSQL("UPDATE TransProdDetalle set DesImporteT = DesImporteT + (Subtotal  * " & (nPorcentaje / 100) & "), DesImpuestoT = DesImpuestoT + (Impuesto  * " & (nPorcentaje / 100) & ") where TransProdID ='" & parsTransProdID & "' and Subtotal>0 ")
                        Case ServicesCentral.TiposValoresDescuentos.Porcentaje
                            If Not refDescuento.PermitirCascada Then
                                oDBVen.EjecutarComandoSQL("INSERT INTO TpdDes select TPD.TransProdID, TPD.TransProdDetalleID,'" & refDescuento.DescuentoClave & "'," & refDescuento.ValorAplicacion & ", TPD.Subtotal  * " & (refDescuento.ValorAplicacion / 100) & ", TPD.Impuesto * " & (refDescuento.ValorAplicacion / 100) & "," & refDescuento.Jerarquia & " , 0, getdate(),'" & oVendedor.UsuarioId & "',0 from TransProdDetalle TPD where TransProdID ='" & parsTransProdID & "' and Subtotal>0")
                                oDBVen.EjecutarComandoSQL("UPDATE TransProdDetalle set DesImporteT = DesImporteT + (Subtotal  * " & (refDescuento.ValorAplicacion / 100) & "), DesImpuestoT = DesImpuestoT + (Impuesto  * " & (refDescuento.ValorAplicacion / 100) & ") where TransProdID ='" & parsTransProdID & "' and Subtotal>0")
                            Else
                                oDBVen.EjecutarComandoSQL("INSERT INTO TpdDes select TPD.TransProdID, TPD.TransProdDetalleID,'" & refDescuento.DescuentoClave & "'," & refDescuento.ValorAplicacion & ", (TPD.Subtotal - TPD.DesImporteT) * " & (refDescuento.ValorAplicacion / 100) & ", (TPD.Impuesto - TPD.DesImpuestoT) * " & (refDescuento.ValorAplicacion / 100) & " ," & refDescuento.Jerarquia & " ,1,getdate(),'" & oVendedor.UsuarioId & "',0 from TransProdDetalle TPD where TransProdID ='" & parsTransProdID & "' and Subtotal>0")
                                oDBVen.EjecutarComandoSQL("UPDATE TransProdDetalle set DesImporteT = DesImporteT + ((Subtotal - DesImporteT) * " & (refDescuento.ValorAplicacion / 100) & "), DesImpuestoT = DesImpuestoT + ((Impuesto - DesImpuestoT) * " & (refDescuento.ValorAplicacion / 100) & ") where TransProdID ='" & parsTransProdID & "' and Subtotal>0")
                            End If
                    End Select
                Else
                    ' No esta definido
                End If
            Next

            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        Return False
    End Function

    Public Function CalcularAplicablesAlProductoPorProducto(ByRef refparoDescuento As Descuento, ByVal parnSubTotal As Decimal, ByVal pariCantidad As Integer, ByRef refparImporteDescuento As Decimal) As Boolean
        Try
            ' Si la lista esta vacia
            refparImporteDescuento = 0
            If refparoDescuento Is Nothing Then
                Return False
            End If
            Dim nBase As Decimal = parnSubTotal
            ' Aplicar solo el primer descuento
            Select Case refparoDescuento.TipoValor
                Case ServicesCentral.TiposValoresDescuentos.Importe
                    refparoDescuento.PorcentajeCalculado = 0
                    refparoDescuento.ImporteCalculado = refparoDescuento.ValorAplicacion
                Case ServicesCentral.TiposValoresDescuentos.Porcentaje
                    refparoDescuento.PorcentajeCalculado = refparoDescuento.ValorAplicacion
                    refparoDescuento.ImporteCalculado = nBase * (refparoDescuento.ValorAplicacion / 100)
            End Select
            refparImporteDescuento = refparoDescuento.ImporteCalculado
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        Return False
    End Function

    Public Function CalcularAplicablesAlProductoPorEsquema(ByRef refparoDescuento As Descuento, ByVal parnSubTotal As Decimal, ByRef refparImporteDescuento As Decimal) As Boolean
        Try
            ' Si la lista esta vacia
            refparImporteDescuento = 0
            If refparoDescuento Is Nothing Then
                Return False
            End If
            Dim nBase As Decimal = parnSubTotal
            ' Aplicar solo el primer descuento
            Select Case refparoDescuento.Tipo
                Case ServicesCentral.TiposDescuentos.Inmediato
                    Select Case refparoDescuento.TipoValor
                        Case ServicesCentral.TiposValoresDescuentos.Importe
                            refparoDescuento.PorcentajeCalculado = 0
                            refparoDescuento.ImporteCalculado = refparoDescuento.ValorAplicacion
                        Case ServicesCentral.TiposValoresDescuentos.Porcentaje
                            refparoDescuento.PorcentajeCalculado = refparoDescuento.ValorAplicacion
                            refparoDescuento.ImporteCalculado = nBase * (refparoDescuento.ValorAplicacion / 100)
                    End Select
                    refparImporteDescuento = refparoDescuento.ImporteCalculado
                Case ServicesCentral.TiposDescuentos.Programado
                    ' No esta definido
            End Select
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
        Return False
    End Function


End Class
