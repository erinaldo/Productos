Public Enum ActualizarInventario
    ActualizaInventario = 0
    ActualizaInventarioCantidadModificada = 1
    NoActualizaInventario = 2
End Enum

Public Class ProductoPrestamoCli

    Public Shared ReadOnly Property PRUTipoUnidadMinima(ByVal pvProductoClave As String) As Integer
        Get
            Return oDBVen.RealizarConsultaSQL("SELECT PRUTipoUnidad FROM ProductoDetalle WHERE ProductoClave='" & pvProductoClave & "' and productodetclave ='" & pvProductoClave & "' order by factor", "PRUTipoUnidad").Rows(0).Item(0)
        End Get
    End Property
    Public Shared ReadOnly Property Factor(ByVal pvProductoClave As String, ByVal pvTipoUnidad As Integer) As Integer
        Get
            Return oDBVen.RealizarConsultaSQL("SELECT factor FROM ProductoDetalle WHERE ProductoClave='" & pvProductoClave & "' and ProductoDetClave ='" & pvProductoClave & "' and PRUTipoUnidad=" & pvTipoUnidad & " ", "ProductoDetalle").Rows(0).Item(0)
        End Get
    End Property
    Public Shared ReadOnly Property Saldo(ByVal pvProductoClave As String, ByVal pvClienteClave As String) As Integer
        Get
            Return oDBVen.EjecutarCmdScalarIntSQL("Select Saldo from ProductoPrestamoCli where ProductoClave='" & pvProductoClave & "' and ClienteClave='" & pvClienteClave & "' ")
        End Get
    End Property
    Public Shared ReadOnly Property PrestamoVendido(ByVal pvTransProdId As String, ByVal pvTransProdDetalleId As String) As Integer
        Get
            Return CType(oDBVen.RealizarConsultaSQL("SELECT case isnull(PrestamoVendido) when 1 then 0 else PrestamoVendido end as PrestamoVendido FROM TransProdDetalle WHERE TransProdId='" & pvTransProdId & "' and TransProdDetalleId='" & pvTransProdDetalleId & "' ", "TransProdDetalle"), DataTable).Rows(0).Item(0)
        End Get
    End Property

    Public Shared Function ObtenerDatosActualizar(ByVal pvPrestamoVendido As Integer, ByVal pvProductoClave As String, ByRef pvTipoUnidad As Integer, ByRef pvDiferenciaCantidad As Integer)

        If pvPrestamoVendido <> 0 Then
            pvTipoUnidad = ProductoPrestamoCli.PRUTipoUnidadMinima(pvProductoClave)
            Dim lFactor As Integer = ProductoPrestamoCli.Factor(pvProductoClave, pvTipoUnidad)
            pvDiferenciaCantidad = ((pvDiferenciaCantidad * lFactor) - pvPrestamoVendido)
            lFactor = Nothing
        End If

    End Function

    Public Shared Function ModificarVentaDT(ByVal pvClienteClave As String, ByVal pvProductoClave As String, ByVal pvCantidad As Integer, _
    ByVal pvTipoUnidad As Integer, ByVal pvVendido As Int16, ByVal pvTransProdTipo As ServicesCentral.TiposTransProd, ByVal pvTipoMotivo As Integer, ByVal pvPrestamoVendido As Integer, ByRef DTProductoPrestamoCli As DataTable) As Boolean
        Dim DtProductoDetalle As DataTable

        Try
            'REPARTO y venta Nueva 
            If (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion And pvTransProdTipo = ServicesCentral.TiposTransProd.Pedido And pvVendido = 0) Or _
                oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta Or oVendedor.TipoModulo = ServicesCentral.TiposModulos.Preventa Then
                DtProductoDetalle = oDBVen.RealizarConsultaSQL("SELECT * FROM ProductoDetalle WHERE ProductoClave='" & pvProductoClave & "' AND PRUTipoUnidad=" & pvTipoUnidad, "ProductoDetalle")

                Dim row As DataRow
                For Each row In DtProductoDetalle.Rows
                    Select Case pvTransProdTipo
                        Case ServicesCentral.TiposTransProd.Pedido And row("Prestamo") = True
                            If Not ExisteDT(row("ProductoDetClave"), DTProductoPrestamoCli) Then
                                CrearPrestamoDT(pvClienteClave, row("ProductoDetClave"), DTProductoPrestamoCli)
                            End If

                            If row("ProductoDetClave") = pvProductoClave Then

                                If pvPrestamoVendido <> 0 Then
                                    'Actualizar el SALDO 
                                    ActualizarPrestamoDT(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, pvPrestamoVendido, 3, pvTipoMotivo, DTProductoPrestamoCli)
                                    'Afectar el saldo VENDIDO 
                                    ActualizarPrestamoDT(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, -1 * pvCantidad, 2, pvTipoMotivo, DTProductoPrestamoCli)
                                    'Afectar el CARGO 
                                    ActualizarPrestamoDT(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, -1 * (pvCantidad - pvPrestamoVendido), 5, pvTipoMotivo, DTProductoPrestamoCli)
                                Else
                                    ActualizarPrestamoDT(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, -1 * (pvCantidad * row("Factor")), 1, pvTipoMotivo, DTProductoPrestamoCli)
                                End If

                            Else
                                ActualizarPrestamoDT(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, -1 * (pvCantidad * row("Factor")), 0, pvTipoMotivo, DTProductoPrestamoCli)
                            End If

                    End Select
                Next

                If Not row Is Nothing Then row = Nothing

            End If

            If Not DtProductoDetalle Is Nothing Then
                DtProductoDetalle.Dispose()
                DtProductoDetalle = Nothing
            End If

            Return True
        Catch ex As Exception
            DtProductoDetalle.Dispose()
            DtProductoDetalle = Nothing
        End Try

        Return False
    End Function

    Public Shared Function ModificarVenta(ByVal pvClienteClave As String, ByVal pvProductoClave As String, ByVal pvCantidad As Integer, ByVal pvTipoUnidad As Integer, ByVal pvVendido As Int16, ByVal pvTransProdTipo As ServicesCentral.TiposTransProd, ByVal pvTipoMotivo As Integer, ByVal pvPrestamoVendido As Integer) As Boolean
        Dim DtProductoDetalle As DataTable

        Try
            'REPARTO y venta Nueva 
            If (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion And pvTransProdTipo = ServicesCentral.TiposTransProd.Pedido And pvTipoMotivo = 3) Or _
                oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta Or oVendedor.TipoModulo = ServicesCentral.TiposModulos.Preventa Then
                DtProductoDetalle = oDBVen.RealizarConsultaSQL("SELECT * FROM ProductoDetalle WHERE ProductoClave='" & pvProductoClave & "' AND PRUTipoUnidad=" & pvTipoUnidad, "ProductoDetalle")

                Dim row As DataRow
                For Each row In DtProductoDetalle.Rows
                    Select Case pvTransProdTipo
                        Case ServicesCentral.TiposTransProd.Pedido And row("Prestamo") = True
                            If Not Existe(pvClienteClave, row("ProductoDetClave")) Then
                                CrearPrestamo(pvClienteClave, row("ProductoDetClave"))
                            End If

                            If row("ProductoDetClave") = pvProductoClave Then

                                If pvPrestamoVendido <> 0 Then
                                    'Actualizar el SALDO 
                                    ActualizarPrestamo(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, pvPrestamoVendido, 3, pvTipoMotivo)
                                    'Afectar el saldo VENDIDO 
                                    ActualizarPrestamo(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, -1 * (pvCantidad * row("Factor")), 2, pvTipoMotivo)
                                    'Afectar el CARGO 
                                    ActualizarPrestamo(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, -1 * ((pvCantidad * row("Factor")) - pvPrestamoVendido), 5, pvTipoMotivo)
                                Else
                                    ActualizarPrestamo(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, -1 * (pvCantidad * row("Factor")), 1, pvTipoMotivo)
                                End If

                            Else
                                ActualizarPrestamo(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, -1 * (pvCantidad * row("Factor")), 0, pvTipoMotivo)
                            End If

                    End Select
                Next
                If Not row Is Nothing Then row = Nothing

            End If

            If Not DtProductoDetalle Is Nothing Then
                DtProductoDetalle.Dispose()
                DtProductoDetalle = Nothing
            End If

            Return True
        Catch ex As Exception

        End Try

        If Not DtProductoDetalle Is Nothing Then
            DtProductoDetalle.Dispose()
            DtProductoDetalle = Nothing
        End If

        Return False
    End Function

    Public Shared Function ActulizarProductoPrestamoCli(ByVal pvClienteClave As String, ByVal pvProductoClave As String, ByVal iCantidad As Integer, _
    ByVal pvTipoUnidad As Integer, ByVal pvVendido As Int16, ByVal pvTransProdTipo As ServicesCentral.TiposTransProd, ByVal pvTipoMotivo As Integer) As Boolean
        Dim DtProductoDetalle As DataTable

        Try
            'REPARTO y venta Nueva 
            If (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion And pvTransProdTipo = ServicesCentral.TiposTransProd.Pedido And pvTipoMotivo = 0) Or _
                oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta Or oVendedor.TipoModulo = ServicesCentral.TiposModulos.Preventa Then
                DtProductoDetalle = oDBVen.RealizarConsultaSQL("SELECT * FROM ProductoDetalle WHERE ProductoClave='" & pvProductoClave & "' AND PRUTipoUnidad=" & pvTipoUnidad, "ProductoDetalle")

                Dim row As DataRow
                For Each row In DtProductoDetalle.Rows
                    Select Case pvTransProdTipo
                        Case ServicesCentral.TiposTransProd.Pedido And row("Prestamo") = True
                            If Not Existe(pvClienteClave, row("ProductoDetClave")) Then
                                CrearPrestamo(pvClienteClave, row("ProductoDetClave"))
                            End If

                            If row("ProductoDetClave") = pvProductoClave Then
                                Dim lNuevaCantidad As Integer
                                Select Case ProductoPrestamoCli.ValidarExistencias(pvClienteClave, pvProductoClave, pvTipoUnidad, iCantidad, pvTransProdTipo, oVendedor.TipoModulo, lNuevaCantidad, row("factor"))
                                    Case ActualizarInventario.ActualizaInventario

                                    Case ActualizarInventario.ActualizaInventarioCantidadModificada
                                        ActualizarPrestamo(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, lNuevaCantidad, 4, pvTipoMotivo)

                                    Case ActualizarInventario.NoActualizaInventario
                                        ActualizarPrestamo(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, -1 * (iCantidad * row("Factor")), 3, pvTipoMotivo)

                                End Select

                                ActualizarPrestamo(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, (iCantidad * row("Factor")), 2, pvTipoMotivo)
                            Else
                                ActualizarPrestamo(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, (iCantidad * row("Factor")), 0, pvTipoMotivo)
                            End If

                        Case ServicesCentral.TiposTransProd.DevolucionesCliente
                            If row("Prestamo") = True Then
                                If Not Existe(pvClienteClave, row("ProductoDetClave")) Then
                                    CrearPrestamo(pvClienteClave, row("ProductoDetClave"))
                                End If
                                ActualizarPrestamo(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, (iCantidad * row("Factor")), pvVendido, pvTipoMotivo)
                            End If

                        Case ServicesCentral.TiposTransProd.VentaConsignacion
                            If row("Prestamo") = True Then
                                'Liquidacion Consignacion, valida si es para venta o saldo y si es el envase el que se esta vendiendo
                                If ((pvVendido = 2 Or pvVendido = 3) And pvTipoMotivo = 1) AndAlso row("ProductoDetClave") <> pvProductoClave Then
                                    Exit Select
                                End If
                                If Not Existe(pvClienteClave, row("ProductoDetClave")) Then
                                    CrearPrestamo(pvClienteClave, row("ProductoDetClave"))
                                End If
                                ActualizarPrestamo(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, (iCantidad * row("Factor")), pvVendido, pvTipoMotivo)
                            End If

                        Case ServicesCentral.TiposTransProd.CambioDeProducto
                            If row("Prestamo") = True Then
                                If Not Existe(pvClienteClave, row("ProductoDetClave")) Then
                                    CrearPrestamo(pvClienteClave, row("ProductoDetClave"))
                                End If
                                ActualizarPrestamo(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, (iCantidad * row("Factor")), pvVendido, pvTipoMotivo)
                            End If

                    End Select
                Next
                If Not row Is Nothing Then row = Nothing

            End If

            If Not DtProductoDetalle Is Nothing Then
                DtProductoDetalle.Dispose()
                DtProductoDetalle = Nothing
            End If

            Return True
        Catch ex As Exception

        End Try

        If Not DtProductoDetalle Is Nothing Then
            DtProductoDetalle.Dispose()
            DtProductoDetalle = Nothing
        End If
        Return False
    End Function

    Public Shared Function ValidarExistencias(ByRef pvClienteClave As String, ByVal pvProductoClave As String, ByVal pvTipoUnidad As Integer, _
    ByVal pvCantidad As Integer, ByVal pvTipoTransProd As ServicesCentral.TiposTransProd, ByVal pvModuloTermTipoIndice As ServicesCentral.TiposModulos, ByRef pvNuevaCantidad As Integer, ByVal pvFactor As Integer) As Int16

        If Not (pvTipoTransProd = ServicesCentral.TiposTransProd.Pedido And (pvModuloTermTipoIndice = ServicesCentral.TiposModulos.Venta Or pvModuloTermTipoIndice = ServicesCentral.TiposModulos.Distribucion)) Then
            Return ActualizarInventario.ActualizaInventario
        End If

        Dim DtProducto As DataTable
        DtProducto = oDBVen.RealizarConsultaSQL("SELECT * FROM Producto WHERE ProductoClave='" & pvProductoClave & "' ", "ProductoDetalle")

        If DtProducto.Rows(0).Item("Contenido") = True And DtProducto.Rows(0).Item("venta") = True Then
            If Not Existe(pvClienteClave, pvProductoClave) Then
                CrearPrestamo(pvClienteClave, pvProductoClave)
            End If

            Dim lSaldo As Integer = Saldo(pvProductoClave, pvClienteClave)

            If lSaldo >= (pvCantidad * pvFactor) Then
                lSaldo = Nothing
                DtProducto.Dispose()
                DtProducto = Nothing

                Return ActualizarInventario.NoActualizaInventario
            End If

            pvNuevaCantidad = (pvCantidad * pvFactor) - lSaldo
            lSaldo = Nothing
            DtProducto.Dispose()
            DtProducto = Nothing
            Return ActualizarInventario.ActualizaInventarioCantidadModificada
        End If

        If Not DtProducto Is Nothing Then
            DtProducto.Dispose()
            DtProducto = Nothing
        End If

        Return ActualizarInventario.ActualizaInventario
    End Function

    Private Shared Function CrearPrestamo(ByVal pvClienteClave As String, ByVal pvProductoClave As String)
        oDBVen.EjecutarComandoSQL("insert into ProductoPrestamoCli values('" & pvClienteClave & "','" & pvProductoClave & "',0,0,0,0,0," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "',0)")
    End Function

    Private Shared Function ActualizarPrestamo(ByVal pvClienteClave As String, ByVal pvProductoClave As String, ByVal pvTransProdTipo As ServicesCentral.TiposTransProd, ByVal pvCantidad As Integer, ByVal pvVendido As Int16, ByVal pvTipoMotivo As Integer)
        Dim vlConsulta As New System.Text.StringBuilder

        Select Case pvTransProdTipo
            Case ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposTransProd.VentaConsignacion
                vlConsulta.Append("update ProductoPrestamoCli set ")

                If pvVendido <> 2 And pvVendido <> 3 And pvVendido <> 6 Then
                    vlConsulta.Append(" cargo = cargo + " & pvCantidad & ", ")
                End If

                Select Case pvVendido
                    Case 1, 2
                        vlConsulta.Append(" venta = venta + " & pvCantidad & ", ")
                    Case 0, 3
                        vlConsulta.Append(" saldo = saldo + " & pvCantidad & ", ")
                    Case 4
                        vlConsulta.Append(" saldo = 0, ")
                    Case 6
                        vlConsulta.Append(" Abono = Abono +  " & pvCantidad & ", ")
                End Select

                vlConsulta.Append(" Enviado=0, MFechaHora=getdate(), MUsuarioID='" & oVendedor.UsuarioId & "' WHERE ProductoClave ='" & pvProductoClave & "' and ClienteClave ='" & pvClienteClave & "' ")
                oDBVen.EjecutarComandoSQL(vlConsulta.ToString)

            Case ServicesCentral.TiposTransProd.DevolucionesCliente
                oDBVen.EjecutarComandoSQL("update ProductoPrestamoCli set Abono = Abono + " & pvCantidad & ", saldo = saldo - " & pvCantidad & ", Enviado=0, MFechaHora=getdate(), MUsuarioID='" & oVendedor.UsuarioId & "' WHERE ProductoClave ='" & pvProductoClave & "' and ClienteClave ='" & pvClienteClave & "' ")

            Case ServicesCentral.TiposTransProd.CambioDeProducto
                Select Case pvTipoMotivo
                    Case 1 'Entrada de inventario
                        oDBVen.EjecutarComandoSQL("update ProductoPrestamoCli set Abono = Abono + " & pvCantidad & ",saldo = saldo - " & pvCantidad & ", Enviado=0, MFechaHora=getdate(), MUsuarioID='" & oVendedor.UsuarioId & "' WHERE ProductoClave ='" & pvProductoClave & "' and ClienteClave ='" & pvClienteClave & "' ")
                    Case 2 'Salida de inventario
                        oDBVen.EjecutarComandoSQL("update ProductoPrestamoCli set Cargo = Cargo + " & pvCantidad & ",saldo = saldo + " & pvCantidad & ", Enviado=0, MFechaHora=getdate(), MUsuarioID='" & oVendedor.UsuarioId & "' WHERE ProductoClave ='" & pvProductoClave & "' and ClienteClave ='" & pvClienteClave & "' ")
                End Select

        End Select
        vlConsulta = Nothing
    End Function

    Public Shared Function Existe(ByVal pvClienteClave As String, ByVal pvProductoClave As String) As Boolean
        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select count(*) from ProductoPrestamoCli where ClienteClave='" & pvClienteClave & "' and ProductoClave ='" & pvProductoClave & "' ", "Query")
        Dim bExiste As Boolean = False

        If Dt.Rows(0).Item(0) > 0 Then bExiste = True
        Dt.Dispose()
        Dt = Nothing

        Return bExiste
    End Function

#Region "VALIDACIONES TEMPORALES"
    Public Shared Function ExisteDT(ByVal pvProductoClave As String, ByVal DTProductoPrestamoCli As DataTable) As Boolean
        Dim row As DataRow() = DTProductoPrestamoCli.Select("ProductoClave ='" & pvProductoClave & "'")

        If row.Length > 0 Then
            row = Nothing
            Return True
        End If
        row = Nothing

        Return False
    End Function

    Private Shared Function CrearPrestamoDT(ByVal pvClienteClave As String, ByVal pvProductoClave As String, ByRef dtProductoPrestamoCli As DataTable)
        Dim row As DataRow
        row = dtProductoPrestamoCli.NewRow
        row.Item("ClienteClave") = pvClienteClave
        row.Item("ProductoClave") = pvProductoClave
        row.Item("Cargo") = 0
        row.Item("Abono") = 0
        row.Item("Venta") = 0
        row.Item("Saldo") = 0
        row.Item("SaldoCarga") = 0
        row.Item("MFechaHora") = Now
        row.Item("MUsuarioId") = oVendedor.UsuarioId
        row.Item("Enviado") = 0

        dtProductoPrestamoCli.Rows.Add(row)
    End Function

    Public Shared Function BorrarProductoPrestamoCliDT(ByVal pvClienteClave As String, ByVal pvProductoClave As String, ByVal pvCantidad As Integer, ByVal pvTipoUnidad As Integer, ByVal pvVendido As Int16, ByVal pvTransProdTipo As ServicesCentral.TiposTransProd, ByVal pvTipoMotivo As Integer, ByVal pvPrestamoVendido As Integer, ByRef DTProductoPrestamoCli As DataTable) As Boolean
        Dim DtProductoDetalle As DataTable

        Try
            'REPARTO y venta Nueva 
            If (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion And pvTransProdTipo = ServicesCentral.TiposTransProd.Pedido And pvTipoMotivo = 0) Or _
                oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta Or oVendedor.TipoModulo = ServicesCentral.TiposModulos.Preventa Then
                DtProductoDetalle = oDBVen.RealizarConsultaSQL("SELECT * FROM ProductoDetalle WHERE ProductoClave='" & pvProductoClave & "' AND PRUTipoUnidad=" & pvTipoUnidad, "ProductoDetalle")

                Dim row As DataRow
                For Each row In DtProductoDetalle.Rows
                    Select Case pvTransProdTipo
                        Case ServicesCentral.TiposTransProd.Pedido And row("Prestamo") = True
                            If Not ExisteDT(row("ProductoDetClave"), DTProductoPrestamoCli) Then
                                CrearPrestamoDT(pvClienteClave, row("ProductoDetClave"), DTProductoPrestamoCli)
                            End If

                            If row("ProductoDetClave") = pvProductoClave Then

                                If pvPrestamoVendido <> 0 Then
                                    'Actualizar el SALDO 
                                    ActualizarPrestamoDT(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, pvPrestamoVendido, 3, pvTipoMotivo, DTProductoPrestamoCli)
                                    'Afectar el saldo VENDIDO 
                                    ActualizarPrestamoDT(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, -1 * (pvCantidad * row("Factor")), 2, pvTipoMotivo, DTProductoPrestamoCli)
                                    'Afectar el CARGO 
                                    ActualizarPrestamoDT(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, -1 * ((pvCantidad * row("Factor")) - pvPrestamoVendido), 5, pvTipoMotivo, DTProductoPrestamoCli)
                                Else
                                    ActualizarPrestamoDT(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, -1 * (pvCantidad * row("Factor")), 1, pvTipoMotivo, DTProductoPrestamoCli)
                                End If

                            Else
                                ActualizarPrestamoDT(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, -1 * (pvCantidad * row("Factor")), 0, pvTipoMotivo, DTProductoPrestamoCli)
                            End If
                    End Select
                Next

                row = Nothing
            End If

            If Not DtProductoDetalle Is Nothing Then
                DtProductoDetalle.Dispose()
                DtProductoDetalle = Nothing
            End If

            Return True
        Catch ex As Exception
           
        End Try

        If Not DtProductoDetalle Is Nothing Then
            DtProductoDetalle.Dispose()
            DtProductoDetalle = Nothing
        End If
        Return False
    End Function

    Public Shared Function ActualizarPrestamoDT(ByVal pvClienteClave As String, ByVal pvProductoClave As String, ByVal pvTransProdTipo As ServicesCentral.TiposTransProd, ByVal pvCantidad As Integer, ByVal pvVendido As Int16, ByVal pvTipoMotivo As Integer, ByRef DTProductoPrestamoCli As DataTable)
        Select Case pvTransProdTipo
            Case ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposTransProd.VentaConsignacion

                Dim row As DataRow() = DTProductoPrestamoCli.Select("productoClave='" & pvProductoClave & "'")
                If row.Length <= 0 Then Exit Function

                If pvVendido <> 2 And pvVendido <> 3 Then
                    row(0)("cargo") = row(0)("cargo") + pvCantidad
                End If

                Select Case pvVendido
                    Case 1, 2
                        row(0)("venta") = row(0)("venta") + pvCantidad
                    Case 0, 3
                        row(0)("saldo") = row(0)("saldo") + pvCantidad
                    Case 4
                        row(0)("saldo") = 0
                End Select

                row(0)("Enviado") = 0
                row(0)("MFechaHora") = Now
                row(0)("MUsuarioID") = oVendedor.UsuarioId

            Case ServicesCentral.TiposTransProd.DevolucionesCliente
                Dim row As DataRow() = DTProductoPrestamoCli.Select("productoClave='" & pvProductoClave & "'")
                If row.Length <= 0 Then Exit Function

                row(0)("Abono") = row(0)("Abono") + pvCantidad
                row(0)("saldo") = row(0)("saldo") - pvCantidad
                row(0)("Enviado") = 0
                row(0)("MFechaHora") = Now
                row(0)("MUsuarioID") = oVendedor.UsuarioId
            
            Case ServicesCentral.TiposTransProd.CambioDeProducto
                Dim row As DataRow() = DTProductoPrestamoCli.Select("productoClave='" & pvProductoClave & "'")
                If row.Length <= 0 Then Exit Function
                Select Case pvTipoMotivo
                    Case 1 'Entrada de inventario
                        row(0)("Abono") = row(0)("Abono") + pvCantidad
                        row(0)("saldo") = row(0)("saldo") - pvCantidad
                    Case 2 'Salida de inventario
                        row(0)("Cargo") = row(0)("Cargo") + pvCantidad
                        row(0)("saldo") = row(0)("saldo") + pvCantidad
                End Select

                row(0)("Enviado") = 0
                row(0)("MFechaHora") = Now
                row(0)("MUsuarioID") = oVendedor.UsuarioId

        End Select
    End Function

    Public Shared Function ValidarExistenciasDT(ByVal pvProductoClave As String, ByVal pvTipoUnidad As Integer, ByVal pvCantidad As Integer, ByVal pvTipoTransProd As ServicesCentral.TiposTransProd, ByVal pvModuloTermTipoIndice As ServicesCentral.TiposModulos, _
    ByRef pvNuevaCantidad As Integer, ByVal pvDtProductoPrestamoCli As DataTable, ByVal pvFactor As Integer) As ActualizarInventario

        If Not (pvTipoTransProd = ServicesCentral.TiposTransProd.Pedido And pvModuloTermTipoIndice = ServicesCentral.TiposModulos.Venta) Or pvDtProductoPrestamoCli Is Nothing Then
            Return ActualizarInventario.ActualizaInventario
        End If

        Dim DtProducto As DataTable
        DtProducto = oDBVen.RealizarConsultaSQL("SELECT * FROM Producto WHERE ProductoClave='" & pvProductoClave & "' ", "ProductoDetalle")

        If DtProducto.Rows(0).Item("Contenido") = True And DtProducto.Rows(0).Item("venta") = True Then
            Dim row As DataRow() = pvDtProductoPrestamoCli.Select("productoclave='" & pvProductoClave & "'")
            Dim lSaldo As Integer = 0

            If row.Length > 0 Then
                lSaldo = row(0)("Saldo")
            End If

            'Dim lFactor As Integer = Factor(pvProductoClave, pvTipoUnidad)
            If lSaldo >= (pvCantidad * pvFactor) Then
                DtProducto.Dispose()
                DtProducto = Nothing
                row = Nothing
                lSaldo = Nothing
                Return ActualizarInventario.NoActualizaInventario
            End If

            pvNuevaCantidad = (pvCantidad * pvFactor) - lSaldo
            DtProducto.Dispose()
            DtProducto = Nothing
            row = Nothing
            lSaldo = Nothing
            Return ActualizarInventario.ActualizaInventarioCantidadModificada
        End If

        If Not DtProducto Is Nothing Then
            DtProducto.Dispose()
            DtProducto = Nothing
        End If
        Return ActualizarInventario.ActualizaInventario
    End Function

    Public Shared Function ActulizarProductoPrestamoCliDT(ByVal pvClienteClave As String, ByVal pvProductoClave As String, ByVal iCantidad As Integer, _
      ByVal pvTipoUnidad As Integer, ByVal pvVendido As Int16, ByVal pvTransProdTipo As ServicesCentral.TiposTransProd, ByVal pvTipoMotivo As Integer, ByRef DTProductoPrestamocli As DataTable, ByVal TipoActualizacion As MobileClient.ActualizarInventario) As Boolean
        Dim DtProductoDetalle As DataTable

        Try
            'REPARTO y venta Nueva 
            If (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion And pvTransProdTipo = ServicesCentral.TiposTransProd.Pedido And pvVendido = 0) Or _
                oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta Or oVendedor.TipoModulo = ServicesCentral.TiposModulos.Preventa Then
                DtProductoDetalle = oDBVen.RealizarConsultaSQL("SELECT * FROM ProductoDetalle WHERE ProductoClave='" & pvProductoClave & "' AND PRUTipoUnidad=" & pvTipoUnidad, "ProductoDetalle")

                Dim row As DataRow
                For Each row In DtProductoDetalle.Rows
                    Select Case pvTransProdTipo
                        Case ServicesCentral.TiposTransProd.Pedido And row("Prestamo") = True
                            Dim drow As DataRow() = DTProductoPrestamocli.Select("productoclave='" & row("ProductoDetClave") & "'")
                            If drow.Length <= 0 Then
                                CrearPrestamoDT(pvClienteClave, row("ProductoDetClave"), DTProductoPrestamocli)
                                drow = DTProductoPrestamocli.Select("productoclave='" & row("ProductoDetClave") & "'")
                            End If

                            If row("ProductoDetClave") = pvProductoClave Then

                                Dim lNuevaCantidad As Integer
                                Select Case TipoActualizacion
                                    Case ActualizarInventario.ActualizaInventario
                                    Case ActualizarInventario.ActualizaInventarioCantidadModificada
                                        ActualizarPrestamoDT(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, (iCantidad * row("Factor")) - drow(0)("Saldo"), 4, pvTipoMotivo, DTProductoPrestamocli)
                                    Case ActualizarInventario.NoActualizaInventario
                                        ActualizarPrestamoDT(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, -1 * (iCantidad * row("Factor")), 3, pvTipoMotivo, DTProductoPrestamocli)
                                End Select

                                ActualizarPrestamoDT(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, (iCantidad * row("Factor")), 2, pvTipoMotivo, DTProductoPrestamocli)
                            Else
                                ActualizarPrestamoDT(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, (iCantidad * row("Factor")), 0, pvTipoMotivo, DTProductoPrestamocli)
                            End If

                        Case ServicesCentral.TiposTransProd.DevolucionesCliente, ServicesCentral.TiposTransProd.VentaConsignacion
                            If row("Prestamo") = True Then
                                If Not Existe(pvClienteClave, row("ProductoDetClave")) Then
                                    CrearPrestamo(pvClienteClave, row("ProductoDetClave"))
                                End If
                                ActualizarPrestamo(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, (iCantidad * row("Factor")), pvVendido, pvTipoMotivo)
                            End If

                        Case ServicesCentral.TiposTransProd.CambioDeProducto
                            If row("Prestamo") = True Then
                                If Not Existe(pvClienteClave, row("ProductoDetClave")) Then
                                    CrearPrestamo(pvClienteClave, row("ProductoDetClave"))
                                End If
                                ActualizarPrestamo(pvClienteClave, row("ProductoDetClave"), pvTransProdTipo, (iCantidad * row("Factor")), pvVendido, pvTipoMotivo)
                            End If

                    End Select
                Next
                row = Nothing

            End If

            If Not DtProductoDetalle Is Nothing Then
                DtProductoDetalle.Dispose()
                DtProductoDetalle = Nothing
            End If

            Return True
        Catch ex As Exception
            
        End Try

        If Not DtProductoDetalle Is Nothing Then
            DtProductoDetalle.Dispose()
            DtProductoDetalle = Nothing
        End If
        Return False
    End Function

#End Region

End Class

