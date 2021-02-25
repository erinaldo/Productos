Public Class Inventario

    Public Enum TiposVerificacionInventario
        NoVerificar = 0
        ValidarExistencia = 1
        ValidarExistenciaDisponible = 2
        ValidarExistenciaNoDisponible = 3
        ValidarExistenciaCarga = 4
        ValidarExistenciaDescarga = 5
        ValidarExistenciaDisponibleDifNoDisponible =6
    End Enum
    'Recibe una tabla con el inventario para decrementarlo, usar cuando se va a verificar mas de una unidad del producto
    Public Shared Function ValidarExistenciaDisponibleDec(ByVal pariProductoClave As String, ByVal pariTipoUnidad As Integer, ByVal pardCantidad As Decimal, ByRef refpardExistencia As Decimal, ByRef refparDataTableInventario As DataTable, ByRef refparsMensajeError As String, Optional ByVal partTipoTransProd As ServicesCentral.TiposTransProd = Nothing) As Boolean
        Try
            If pardCantidad = 0 Then Return True
            Dim bRes As Boolean = False
            If refparDataTableInventario.Rows.Count <= 0 Then Return False
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select distinct productodetalle.factor, producto.Venta, productodetalle.productoclave, productodetalle.productodetclave, Contenido from productodetalle inner join Producto on Producto.ProductoClave = ProductoDetalle.ProductoClave where productodetalle.productoclave='" & pariProductoClave & "' and productodetalle.prutipounidad=" & pariTipoUnidad, "2_1_1")
            Dim Disponible As Decimal = 0
            For Each Dr As DataRow In Dt.Rows
                Dim Cantidad As Decimal
                Cantidad = pardCantidad * Dr("factor")

                Dim Contenido As Decimal = 0
                Dim drInventario As DataRow() = refparDataTableInventario.Select("ProductoClave ='" & Dr("productodetclave") & "'")
                If IsNothing(drInventario) OrElse drInventario.Length <= 0 Then Return False
                If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                    Dim Venta As Boolean = Dr("Venta")
                    If drInventario(0)("Contenido") = False Then
                        Disponible = drInventario(0)("Disponible") - drInventario(0)("NoDisponible") - drInventario(0)("Apartado")
                    Else
                        Disponible = drInventario(0)("Disponible") - drInventario(0)("NoDisponible") - drInventario(0)("Apartado") - drInventario(0)("Contenido")
                    End If

                    drInventario(0)("Apartado") = drInventario(0)("Apartado") + Cantidad
                    If Not partTipoTransProd = Nothing AndAlso partTipoTransProd = ServicesCentral.TiposTransProd.Cargas Then
                        Disponible += +drInventario(0)("Pedido")
                        drInventario(0)("Apartado") -= drInventario(0)("Pedido")
                    End If
                ElseIf CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                    If Cantidad <= drInventario(0)("Contenido") Then
                        Contenido = 1
                    End If
                End If
                If (Cantidad <= Disponible And CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper) Or (Contenido = 1) Then
                    refpardExistencia = Disponible / Dr("Factor")
                    bRes = True
                ElseIf (Cantidad > Disponible And CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper) Or (Contenido = 0) Then
                    If Disponible > Cantidad Then
                        refpardExistencia = Cantidad / Dr("Factor")
                    Else
                        refpardExistencia = Disponible / Dr("Factor")
                    End If
                    Dt.Dispose()
                    refparDataTableInventario.RejectChanges()
                    Return False
                End If
                'End If
            Next

            Dt.Dispose()
            If Disponible <= 0 Then
                refparDataTableInventario.RejectChanges()
                Return False
            Else
                refparDataTableInventario.AcceptChanges()
                Return bRes
            End If
        Catch ex As SqlServerCe.SqlCeException
            refparsMensajeError = ex.Message
            Return False
        Catch ex As Exception
            refparsMensajeError = ex.Message
            Return False
        End Try
    End Function

    Public Shared Function ValidarExistenciaDifNoDiponibleDec(ByVal pariProductoClave As String, ByVal pariTipoUnidad As Integer, ByVal pardCantidad As Decimal, ByRef refpardExistencia As Decimal, ByRef refparDataTableInventario As DataTable, ByRef refparsMensajeError As String) As Boolean
        Try
            If pardCantidad = 0 Then Return True
            Dim bRes As Boolean = False
            If refparDataTableInventario.Rows.Count <= 0 Then Return False
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select distinct productodetalle.factor, producto.Venta, productodetalle.productoclave, productodetalle.productodetclave from productodetalle inner join Producto on Producto.ProductoClave = ProductoDetalle.ProductoClave where productodetalle.productoclave='" & pariProductoClave & "' and productodetalle.prutipounidad=" & pariTipoUnidad, "2_1_1")
            Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQLSinTransaction("select inventario.Pedido from productodetalle, inventario where inventario.almacenid='" & oVendedor.AlmacenId & "' and '" & pariProductoClave & "'=inventario.productoclave and inventario.productoclave=productodetalle.productoclave and inventario.productoclave=productodetalle.productodetclave and productodetalle.prutipounidad=" & pariTipoUnidad, "Query")

            Dim Disponible As Decimal = 0
            For Each Dr As DataRow In Dt.Rows
                Dim Cantidad As Decimal = pardCantidad * Dr("factor")
                Dim Contenido As Decimal = 0
                Dim drInventario As DataRow() = refparDataTableInventario.Select("ProductoClave ='" & Dr("productodetclave") & "'")
                Dim DiferenciaApartado As Double = 0

                Try

                    DiferenciaApartado = drInventario(0)("Pedido") - Dt2.Rows(0)(0)
                Catch ex As Exception

                End Try


                If IsNothing(drInventario) OrElse drInventario.Length <= 0 Then Return False
                If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                    Dim Venta As Boolean = Dr("Venta")
                    If Venta Then
                        Disponible = drInventario(0)("Disponible") - drInventario(0)("NoDisponible") - DiferenciaApartado
                    Else
                        Disponible = drInventario(0)("Disponible") - drInventario(0)("NoDisponible") - drInventario(0)("Contenido") - DiferenciaApartado
                    End If
                    drInventario(0)("Disponible") = drInventario(0)("Disponible") - Cantidad
                ElseIf CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                    If Cantidad <= drInventario(0)("Contenido") Then
                        Contenido = 1
                    End If
                End If
                If (Cantidad <= Disponible And CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper) Or (Contenido = 1) Then
                    refpardExistencia = Fix(Disponible / Dr("Factor"))
                    bRes = True
                ElseIf (Cantidad > Disponible And CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper) Or (Contenido = 0) Then
                    If Disponible > Cantidad Then
                        refpardExistencia = Fix(Cantidad / Dr("Factor"))
                    Else
                        refpardExistencia = Fix(Disponible / Dr("Factor"))
                    End If
                    Dt.Dispose()
                    refparDataTableInventario.RejectChanges()
                    Return False
                End If
            Next
            Dt.Dispose()
            If Disponible <= 0 Then
                refparDataTableInventario.RejectChanges()
                Return False
            Else
                refparDataTableInventario.AcceptChanges()
                Return bRes
            End If
        Catch ex As SqlServerCe.SqlCeException
            refparsMensajeError = ex.Message
            Return False
        Catch ex As Exception
            refparsMensajeError = ex.Message
            Return False
        End Try
    End Function

    Public Shared Function ValidarExistenciaDisponibleDec(ByVal pariProductoClave As String, ByVal pariTipoUnidad As Integer, ByVal pardCantidad As Decimal, ByRef refpardExistencia As Decimal, ByRef refparsMensajeError As String) As Boolean
        Try
            If pardCantidad = 0 Then Return True
            Dim bRes As Boolean = False
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select distinct productodetalle.factor, producto.Venta, productodetalle.productoclave, productodetalle.productodetclave, inventario.apartado, inventario.disponible, inventario.nodisponible, inventario.contenido from productodetalle inner join inventario on (ProductoDetalle.ProductoClave= Inventario.ProductoClave and ProductoDetalle.ProductoClave= ProductoDetalle.ProductoDetClave) or (ProductoDetalle.ProductoDetClave= Inventario.ProductoClave and ProductoDetalle.ProductoClave<> ProductoDetalle.ProductoDetClave) inner join Producto on Inventario.ProductoClave = Producto.ProductoClave where inventario.almacenid='" & oVendedor.AlmacenId & "' and productodetalle.productoclave='" & pariProductoClave & "' and productodetalle.prutipounidad=" & pariTipoUnidad, "2_1_1")
            Dim Disponible As Decimal = 0
            For Each Dr As DataRow In Dt.Rows
                Dim Cantidad As Decimal = pardCantidad * Dr("factor")
                Dim Contenido As Decimal = 0
                If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                    Dim Venta As Boolean = Dr("Venta")
                    If Venta Then
                        Disponible = Dr("Disponible") - Dr("NoDisponible") - Dr("Apartado")
                    Else
                        Disponible = Dr("Disponible") - Dr("NoDisponible") - Dr("Apartado") - Dr("Contenido")
                    End If
                ElseIf CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                    If Cantidad <= Dr("Contenido") Then
                        Contenido = 1
                    End If
                End If
                If (Cantidad <= Disponible And CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper) Or (Contenido = 1) Then
                    refpardExistencia = Disponible
                    bRes = True
                ElseIf (Cantidad > Disponible And CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper) Or (Contenido = 0) Then
                    If Disponible > Cantidad Then
                        refpardExistencia = Cantidad
                    Else
                        refpardExistencia = Disponible
                    End If
                    Dt.Dispose()
                    Return False
                End If
            Next
            Dt.Dispose()
            Return IIf(Disponible <= 0, False, bRes)
        Catch ex As SqlServerCe.SqlCeException
            refparsMensajeError = ex.Message
            Return False
        Catch ex As Exception
            refparsMensajeError = ex.Message
            Return False
        End Try
    End Function

    Public Shared Function ValidarExistenciaNoDisponible(ByVal pariProductoClave As String, ByVal pariTipoUnidad As Integer, ByVal pardCantidad As Decimal, ByRef refpardExistencia As Decimal, ByRef refparsMensajeError As String) As Boolean
        Try
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select productodetalle.factor, inventario.nodisponible from productodetalle, inventario where inventario.almacenid='" & oVendedor.AlmacenId & "' and inventario.productoclave='" & pariProductoClave & "' and productodetalle.productoclave='" & pariProductoClave & "' and productodetalle.productoclave=productodetalle.productodetclave and productodetalle.prutipounidad=" & pariTipoUnidad, "Query")
            If Dt.Rows.Count > 0 Then
                Dim Dr As DataRow = Dt.Rows(0)
                Dim Cantidad As Decimal = pardCantidad * Dr("factor")
                Dim NoDisponible As Integer = Dr("nodisponible")
                If Cantidad <= Dr("nodisponible") Then
                    refpardExistencia = 1
                    Dt.Dispose()
                    Return True
                Else
                    refpardExistencia = 0
                    Dt.Dispose()
                    Return False
                End If
            Else
                refpardExistencia = 0
                Dt.Dispose()
                Return False
            End If
        Catch ex As SqlServerCe.SqlCeException
            refparsMensajeError = ex.Message
            Return False
        Catch ex As Exception
            refparsMensajeError = ex.Message
            Return False
        End Try
    End Function

    Public Shared Function ValidarExistenciaNoDisponible(ByVal parsProductoClave As String, ByVal pariTipoUnidad As Integer, ByVal pardCantidad As Decimal, ByRef refdtInventario As DataTable, Optional ByRef refpardExistencia As Decimal = 0) As Boolean
        Try
            If refdtInventario.Rows.Count <= 0 Then Return False
            Dim ifactor As Integer = oDBVen.EjecutarCmdScalarIntSQL("select productodetalle.factor from productodetalle where ProductoDetalle.productoclave='" & parsProductoClave & "' and ProductoDetalle.PRUTipoUnidad=" & pariTipoUnidad & " and ProductoDetalle.ProductoDetClave ='" & parsProductoClave & "' ")
            If refdtInventario.Rows.Count > 0 Then
                Dim Cantidad As Decimal = pardCantidad * ifactor
                Dim drInventario As DataRow() = refdtInventario.Select("ProductoClave ='" & parsProductoClave & "'")
                If Cantidad <= drInventario(0)("nodisponible") Then
                    drInventario(0)("NoDisponible") = drInventario(0)("NoDisponible") - Cantidad
                    refdtInventario.AcceptChanges()
                    Return True
                Else
                    refpardExistencia = drInventario(0)("nodisponible") / ifactor
                    refdtInventario.RejectChanges()
                    Return False
                End If
            Else
                refpardExistencia = 0
                refdtInventario.RejectChanges()
                Return False
            End If
        Catch ex As SqlServerCe.SqlCeException
            MsgBox(ex.Message)
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    'Función creada para poder sumar al datatable temporal del inventario en las cargas cuando se incrementa la cantidad. Basada en caso 3 de ActualizaInventario
    Public Shared Sub SumaDisponibleCargasTemporal(ByVal parsProductoClave As String, ByVal pariTipoUnidad As Integer, ByVal pardCantidad As Decimal, ByRef refdtInventario As DataTable)
        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select productoclave, productodetclave, factor from productodetalle where productoclave='" & parsProductoClave & "' and PRUTipoUnidad=" & pariTipoUnidad, "3")
        For Each Dr As DataRow In Dt.Rows
            Dim DrInventario() As DataRow = refdtInventario.Select("ProductoClave='" & Dr("productodetclave") & "'")
            Dim FCantidad As Decimal = Dr("factor") * pardCantidad
            If Not IsNothing(DrInventario) AndAlso DrInventario.Length > 0 Then
                Dim Dr2 As DataRow = DrInventario(0)
                '3.1.2.1.2
                If CStr(Dr("productoclave")).ToUpper = parsProductoClave.ToUpper AndAlso parsProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                    Dr2("disponible") = Dr2("disponible") + FCantidad
                End If
                '3.1.2.1.3
                If CStr(Dr("productoclave")).ToUpper = parsProductoClave.ToUpper AndAlso parsProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                    Dr2("disponible") = Dr2("disponible") + FCantidad
                    Dr2("contenido") = Dr2("contenido") + FCantidad
                End If
            Else '3.1.2.2
                '3.1.2.2.1.3
                Dim drNuevo As DataRow = refdtInventario.NewRow()
                If CStr(Dr("productoclave")).ToUpper = parsProductoClave.ToUpper AndAlso parsProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                    drNuevo.Item("ProductoClave") = Dr("productodetclave")
                    drNuevo.Item("Apartado") = 0
                    drNuevo.Item("Disponible") = FCantidad
                    drNuevo.Item("NoDisponible") = 0
                    drNuevo.Item("Contenido") = 0
                    refdtInventario.Rows.Add(drNuevo)
                End If
                '3.1.2.2.1.4
                If CStr(Dr("productoclave")).ToUpper = parsProductoClave.ToUpper AndAlso parsProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                    drNuevo.Item("ProductoClave") = Dr("productodetclave")
                    drNuevo.Item("Apartado") = 0
                    drNuevo.Item("Disponible") = FCantidad
                    drNuevo.Item("NoDisponible") = 0
                    drNuevo.Item("Contenido") = FCantidad
                    refdtInventario.Rows.Add(drNuevo)
                End If
            End If
            refdtInventario.AcceptChanges()
        Next
        Dt.Dispose()
    End Sub
    'Función creada para poder restar al datatable temporal del inventario en las descargas cuando se decrementa la cantidad. Basada en caso 3 de ActualizaInventario
    Public Shared Sub RestaDisponibleDescargasTemporal(ByVal parsProductoClave As String, ByVal pariTipoUnidad As Integer, ByVal pardCantidad As Decimal, ByRef refdtInventario As DataTable)
        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select ProductoDetalle.ProductoClave, ProductoDetalle.factor, productodetalle.productodetclave from productodetalle where '" & parsProductoClave & "'=productodetalle.productoclave and productodetalle.prutipounidad=" & pariTipoUnidad, "6")
        Dim FCantidad As Decimal
        For Each Dr As DataRow In Dt.Rows
            Dim DrInventario() As DataRow = refdtInventario.Select("ProductoClave='" & Dr("productodetclave") & "'")
            If Not IsNothing(DrInventario) AndAlso DrInventario.Length > 0 Then
                Dim Dr2 As DataRow = DrInventario(0)
                FCantidad = Dr("factor") * pardCantidad
                '6.1.2.1.2
                If CStr(Dr("productoclave")).ToUpper = parsProductoClave.ToUpper AndAlso parsProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                    Dr2("disponible") = Dr2("disponible") - FCantidad
                    Dr2("contenido") = Dr2("contenido") - FCantidad

                    If Dr2("Disponible") < Dr2("Contenido") Then
                        Dr2("Contenido") = Dr2("Disponible")
                    End If

                Else '6.1.2.1.3
                    Dr2("disponible") = Dr2("disponible") - FCantidad
                End If
            End If
            refdtInventario.AcceptChanges()
        Next
        Dt.Dispose()
    End Sub
    Public Shared Function ActualizarInventarioDec(ByVal pariProductoClave As String, ByVal pariTipoUnidad As Integer, ByVal pardCantidad As Decimal, ByVal partTipoTransProd As ServicesCentral.TiposTransProd, ByVal partTipoMovimiento As ServicesCentral.TiposMovimientos, ByVal parsAlmacenId As String, Optional ByVal parbCancelacion As Boolean = False, Optional ByVal parsGrupoMotivo As String = "", Optional ByVal DTProductoPrestamoCli As DataTable = Nothing, Optional ByVal parClienteClave As String = "", Optional ByVal pardPrestamoVendido As Decimal = 0) As Boolean
        Dim Dt As DataTable

        '1
        If (partTipoTransProd = ServicesCentral.TiposTransProd.Pedido AndAlso partTipoMovimiento = ServicesCentral.TiposMovimientos.NoDefinido AndAlso oVendedor.TipoModulo <> ServicesCentral.TiposModulos.Distribucion) OrElse ((partTipoTransProd = ServicesCentral.TiposTransProd.VentaConsignacion AndAlso partTipoMovimiento = ServicesCentral.TiposMovimientos.NoDefinido)) Then
            ' Este caso es para cuando se captura el pedido
            Dt = oDBVen.RealizarConsultaSQL("SELECT Factor FROM ProductoDetalle WHERE ProductoClave='" & pariProductoClave & "' AND ProductoDetClave='" & pariProductoClave & "' AND PRUTipoUnidad=" & pariTipoUnidad, "ProductoDetalle")
            If Dt.Rows.Count = 1 Then
                If oVendedor.TipoModulo <> ServicesCentral.TiposModulos.Distribucion Then
                    Dim dCantidad As Decimal
                    dCantidad = Dt.Rows(0).Item("Factor") * pardCantidad

                    If parbCancelacion Then
                        dCantidad *= -1
                    End If
                    Dim dt3 As DataTable = oDBVen.RealizarConsultaSQL("select Disponible, Apartado from inventario where productoclave='" & pariProductoClave & "' and almacenid='" & parsAlmacenId & "'", "6_1_2")
                    oDBVen.EjecutarComandoSQL("UPDATE Inventario SET Apartado=Apartado+(" & dCantidad & "),MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' WHERE ProductoClave='" & pariProductoClave & "' AND Almacenid='" & parsAlmacenId & "'")

                End If
                Dt.Dispose()
                Return True
            End If
        End If
        '2
        If (((partTipoTransProd = ServicesCentral.TiposTransProd.Pedido And oVendedor.TipoModulo <> ServicesCentral.TiposModulos.Preventa) _
        Or (partTipoTransProd = ServicesCentral.TiposTransProd.VentaConsignacion And oVendedor.TipoModulo <> ServicesCentral.TiposModulos.Preventa) _
        Or (partTipoTransProd = ServicesCentral.TiposTransProd.CargaPorCanje And oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion) _
        Or (partTipoTransProd = ServicesCentral.TiposTransProd.Pedido And oVendedor.TipoModulo <> ServicesCentral.TiposModulos.Distribucion) _
        Or (partTipoTransProd = ServicesCentral.TiposTransProd.CargaPorCanje And oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion) _
        Or (partTipoTransProd = ServicesCentral.TiposTransProd.Pedido And oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion)) _
        AndAlso (partTipoMovimiento = ServicesCentral.TiposMovimientos.Salida)) Then


            ' Este caso es para cuando se surte el pedido 
            Dim sConsultaSQL As New System.Text.StringBuilder
            sConsultaSQL.Append("SELECT ProductoDetClave, Factor FROM ProductoDetalle ")
            sConsultaSQL.Append("WHERE (ProductoClave = '" & pariProductoClave & "') AND (PRUTipoUnidad = " & pariTipoUnidad & ") ")
            sConsultaSQL.Append("ORDER BY ProductoClave, ProductoDetClave")
            Dt = oDBVen.RealizarConsultaSQL(sConsultaSQL.ToString, "Caso 2_1_1")
            Dim dCantidad As Decimal
            For Each refDataRow As DataRow In Dt.Rows
                dCantidad = refDataRow("Factor") * pardCantidad
                If pariProductoClave.ToUpper = CType(refDataRow("ProductoDetClave"), String).ToUpper Then

                    Dim lNuevaCantidad As Decimal
                    Dim lValidarExistencia As MobileClient.ActualizarInventario = MobileClient.ActualizarInventario.ActualizaInventario
                    If Not (parClienteClave Is Nothing OrElse parClienteClave = String.Empty) Then
                        lValidarExistencia = ProductoPrestamoCli.ValidarExistencias(parClienteClave, refDataRow("ProductoDetClave"), pariTipoUnidad, pardCantidad, partTipoTransProd, oVendedor.TipoModulo, lNuevaCantidad, refDataRow("Factor"))
                    End If

                    If lValidarExistencia = MobileClient.ActualizarInventario.ActualizaInventario Or lValidarExistencia = MobileClient.ActualizarInventario.ActualizaInventarioCantidadModificada Then
                        If lValidarExistencia = MobileClient.ActualizarInventario.ActualizaInventarioCantidadModificada Then
                            dCantidad = lNuevaCantidad
                        End If

                        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                            oDBVen.EjecutarComandoSQL("UPDATE Inventario SET Pedido = Pedido - " & dCantidad & ", Apartado = Apartado - " & dCantidad & ", Disponible = Disponible - " & dCantidad & ", MFechaHora = " & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' WHERE ProductoClave='" & pariProductoClave & "' AND AlmacenId = '" & parsAlmacenId & "'")
                        Else

                            oDBVen.EjecutarComandoSQL("UPDATE Inventario SET Apartado = Apartado - " & dCantidad & ", Disponible = Disponible - " & dCantidad & ", MFechaHora = " & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' WHERE ProductoClave='" & pariProductoClave & "' AND AlmacenId = '" & parsAlmacenId & "'")
                        End If
                    End If

                    Dim dt3 As DataTable = oDBVen.RealizarConsultaSQL("select Pedido, Apartado from inventario where productoclave='" & refDataRow("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "6_1_2")
                    If dt3.Rows.Count > 0 Then
                        Dim dr3 As DataRow = dt3.Rows(0)

                        If dr3("Apartado") < 0 Then
                            oDBVen.EjecutarComandoSQL("update inventario set Apartado=0,MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & refDataRow("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                        End If

                        If dr3("Pedido") < 0 Then
                            oDBVen.EjecutarComandoSQL("update inventario set Pedido=0,MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & refDataRow("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                        End If
                    End If

                    dt3.Dispose()

                Else
                    oDBVen.EjecutarComandoSQL("UPDATE Inventario SET Contenido = Contenido - " & dCantidad & ", Disponible = Disponible - " & dCantidad & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' WHERE ProductoClave='" & refDataRow("ProductoDetClave") & "' AND AlmacenId='" & parsAlmacenId & "'")

                    Dim dt3 As DataTable = oDBVen.RealizarConsultaSQL("select disponible, contenido from inventario where productoclave='" & refDataRow("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "6_1_2")
                    If dt3.Rows.Count > 0 Then
                        Dim dr3 As DataRow = dt3.Rows(0)
                        If dr3("Disponible") < dr3("Contenido") Then
                            oDBVen.EjecutarComandoSQL("update inventario set contenido=disponible,MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & refDataRow("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                        End If
                    End If
                    dt3.Dispose()
                End If
            Next
            Dt.Dispose()
            Return True
        End If
        '3

        If (partTipoMovimiento = ServicesCentral.TiposMovimientos.Entrada AndAlso ((partTipoTransProd = ServicesCentral.TiposTransProd.Cargas AndAlso oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta) _
         OrElse (partTipoTransProd = ServicesCentral.TiposTransProd.CargaPorCanje AndAlso oVendedor.TipoModulo <> ServicesCentral.TiposModulos.Distribucion) _
         OrElse (partTipoTransProd = ServicesCentral.TiposTransProd.DevolucionesCliente AndAlso parsGrupoMotivo = "Venta" AndAlso oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta) _
         OrElse (partTipoTransProd = ServicesCentral.TiposTransProd.CambioDeProducto AndAlso (parsGrupoMotivo = "Venta" OrElse parsGrupoMotivo = "") AndAlso oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta))) _
         OrElse (partTipoMovimiento = ServicesCentral.TiposMovimientos.Entrada AndAlso partTipoTransProd = ServicesCentral.TiposTransProd.Pedido AndAlso oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta) _
         OrElse (partTipoMovimiento = ServicesCentral.TiposMovimientos.Entrada AndAlso partTipoTransProd = ServicesCentral.TiposTransProd.VentaConsignacion AndAlso oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta) _
         OrElse (partTipoTransProd = ServicesCentral.TiposTransProd.InventarioABordo) _
         OrElse (partTipoMovimiento = ServicesCentral.TiposMovimientos.Entrada AndAlso partTipoTransProd = ServicesCentral.TiposTransProd.SurtirProductoPromocion AndAlso (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta)) Then

            Dt = oDBVen.RealizarConsultaSQL("select productoclave, productodetclave, factor from productodetalle where productoclave='" & pariProductoClave & "' and PRUTipoUnidad=" & pariTipoUnidad, "3")
            For Each Dr As DataRow In Dt.Rows
                '3.1.2.1
                Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL("select disponible, apartado, contenido from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "3_1_2_1")
                Dim FCantidad As Decimal = Dr("factor") * pardCantidad
                If Dt2.Rows.Count > 0 Then
                    Dim Dr2 As DataRow = Dt2.Rows(0)
                    '3.1.2.1.2
                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta AndAlso (partTipoTransProd = ServicesCentral.TiposTransProd.Pedido OrElse partTipoTransProd = ServicesCentral.TiposTransProd.VentaConsignacion) AndAlso partTipoMovimiento = ServicesCentral.TiposMovimientos.Entrada AndAlso Not parbCancelacion Then
                            If FCantidad - pardPrestamoVendido > 0 Then
                                oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") + (FCantidad - pardPrestamoVendido) & ", Apartado = Apartado + " & (FCantidad - pardPrestamoVendido) & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productoclave") & "'")
                            End If
                        Else
                            If FCantidad - pardPrestamoVendido > 0 Then
                                oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") + (FCantidad - pardPrestamoVendido) & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productoclave") & "'")
                            End If
                        End If
                    End If
                    '3.1.2.1.3
                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                        oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") + FCantidad & ", contenido=" & Dr2("contenido") + FCantidad & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productodetclave") & "'")
                    End If
                Else '3.1.2.2
                    '3.1.2.2.1.3
                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                        oDBVen.EjecutarComandoSQL("insert into inventario values('" & Dr("productodetclave") & "','" & parsAlmacenId & "'," & FCantidad & ",0,0,0,0," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "')")
                    End If
                    '3.1.2.2.1.4
                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                        oDBVen.EjecutarComandoSQL("insert into inventario values('" & Dr("productodetclave") & "','" & parsAlmacenId & "'," & FCantidad & ",0,0," & FCantidad & ",0," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "')")
                    End If
                End If
                Dt2.Dispose()
            Next
            Dt.Dispose()
            Return True
        End If
        '4
        If (partTipoTransProd = ServicesCentral.TiposTransProd.DevolucionesCliente AndAlso partTipoMovimiento = ServicesCentral.TiposMovimientos.Entrada AndAlso parsGrupoMotivo = "No Venta") OrElse (partTipoTransProd = ServicesCentral.TiposTransProd.CambioDeProducto AndAlso partTipoMovimiento = ServicesCentral.TiposMovimientos.Entrada AndAlso parsGrupoMotivo = "No Venta") OrElse (partTipoTransProd = ServicesCentral.TiposTransProd.DevolucionesAlmacen AndAlso partTipoMovimiento = ServicesCentral.TiposMovimientos.Entrada) Then
            Dt = oDBVen.RealizarConsultaSQL("select productodetalle.factor,Productodetalle.productoclave, productodetalle.productodetclave from productodetalle where '" & pariProductoClave & "'=productodetalle.productoclave and productodetalle.prutipounidad=" & pariTipoUnidad, "4")
            Dim FCantidad As Decimal
            '4.1.2
            For Each Dr As DataRow In Dt.Rows
                Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL("select disponible, nodisponible,Contenido from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "4_1_2")
                FCantidad = Dr("factor") * pardCantidad
                '4.1.2.1
                If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                    If Dt2.Rows.Count > 0 Then
                        Dim Dr2 As DataRow = Dt2.Rows(0)
                        oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") + FCantidad & ", nodisponible=" & Dr2("nodisponible") + FCantidad & " ,MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                        Dr2 = Nothing
                    Else '4.1.2.2
                        oDBVen.EjecutarComandoSQL("insert into inventario values('" & Dr("productodetclave") & "','" & parsAlmacenId & "'," & FCantidad & "," & FCantidad & ",0,0,0," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "')")
                    End If
                End If

                If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                    If Dt2.Rows.Count > 0 Then
                        Dim Dr2 As DataRow = Dt2.Rows(0)
                        oDBVen.EjecutarComandoSQL("update inventario set Contenido=" & Dr2("Contenido") + FCantidad & ",Disponible=" & Dr2("Disponible") + FCantidad & " ,MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                        Dr2 = Nothing
                    Else
                        oDBVen.EjecutarComandoSQL("insert into inventario values('" & Dr("productodetclave") & "','" & parsAlmacenId & "'," & FCantidad & "," & FCantidad & ",0,0,0," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "')")
                    End If

                End If
                Dt2.Dispose()
            Next
            Dt.Dispose()
            Return True
        End If
        '5
        If (partTipoTransProd = ServicesCentral.TiposTransProd.DevolucionesAlmacen AndAlso partTipoMovimiento = ServicesCentral.TiposMovimientos.Salida) OrElse ((partTipoTransProd = ServicesCentral.TiposTransProd.DevolucionesCliente Or partTipoTransProd = ServicesCentral.TiposTransProd.CambioDeProducto) AndAlso partTipoMovimiento = ServicesCentral.TiposMovimientos.Salida AndAlso parsGrupoMotivo = "No Venta") Then
            Dim s As String = "select productodetalle.factor,productodetalle.productoclave, productodetalle.productodetclave from productodetalle where '" & pariProductoClave & "'=productodetalle.productoclave and productodetalle.prutipounidad=" & pariTipoUnidad
            Dt = oDBVen.RealizarConsultaSQL(s, "5")
            Dim FCantidad As Decimal
            For Each Dr As DataRow In Dt.Rows
                Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL("select disponible, nodisponible,Contenido from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "5_1")

                If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                    If Dt2.Rows.Count > 0 Then
                        Dim Dr2 As DataRow = Dt2.Rows(0)
                        FCantidad = Dr("factor") * pardCantidad
                        oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") - FCantidad & ", nodisponible=" & Dr2("nodisponible") - FCantidad & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                    End If
                End If

                If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                    If Dt2.Rows.Count > 0 Then
                        Dim Dr2 As DataRow = Dt2.Rows(0)
                        FCantidad = Dr("factor") * pardCantidad
                        oDBVen.EjecutarComandoSQL("update inventario set Contenido=" & Dr2("Contenido") - FCantidad & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")

                        Dim dt3 As DataTable = oDBVen.RealizarConsultaSQL("select disponible, contenido from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "6_1_2")
                        Dim dr3 As DataRow = dt3.Rows(0)
                        If dr3("Disponible") < dr3("Contenido") Then
                            oDBVen.EjecutarComandoSQL("update inventario set Disponible=" & dr3("Contenido") & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                        Else
                            oDBVen.EjecutarComandoSQL("update inventario set Disponible=" & Dr2("Disponible") - FCantidad & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                        End If

                    End If
                End If
                Dt2.Dispose()
            Next
            Dt.Dispose()
            Return True
        End If
        '6
        If ((partTipoTransProd = ServicesCentral.TiposTransProd.CargaPorCanje Or (partTipoTransProd = ServicesCentral.TiposTransProd.Descargas AndAlso oVendedor.TipoModulo <> ServicesCentral.TiposModulos.Distribucion)) AndAlso partTipoMovimiento = ServicesCentral.TiposMovimientos.Salida) OrElse (partTipoTransProd = ServicesCentral.TiposTransProd.DevolucionesCliente AndAlso partTipoMovimiento = ServicesCentral.TiposMovimientos.Salida AndAlso parsGrupoMotivo = "Venta" AndAlso oVendedor.TipoModulo <> ServicesCentral.TiposModulos.Distribucion) OrElse (partTipoTransProd = ServicesCentral.TiposTransProd.CambioDeProducto AndAlso partTipoMovimiento = ServicesCentral.TiposMovimientos.Salida AndAlso (parsGrupoMotivo = "Venta" Or parsGrupoMotivo = "") AndAlso oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta) _
        OrElse (partTipoTransProd = ServicesCentral.TiposTransProd.SurtirProductoPromocion And partTipoMovimiento = ServicesCentral.TiposMovimientos.Salida) Then
            Dt = oDBVen.RealizarConsultaSQL("select ProductoDetalle.ProductoClave, ProductoDetalle.factor, productodetalle.productodetclave from productodetalle where '" & pariProductoClave & "'=productodetalle.productoclave and productodetalle.prutipounidad=" & pariTipoUnidad, "6")
            Dim FCantidad As Decimal
            For Each Dr As DataRow In Dt.Rows
                Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL("select disponible, contenido from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "6_1_2")
                If Dt2.Rows.Count > 0 Then
                    Dim Dr2 As DataRow = Dt2.Rows(0)
                    FCantidad = Dr("factor") * pardCantidad
                    '6.1.2.1.2
                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                        oDBVen.EjecutarComandoSQL("update inventario set contenido=" & Dr2("contenido") - FCantidad & ", disponible=" & Dr2("disponible") - FCantidad & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")

                        Dim dt3 As DataTable = oDBVen.RealizarConsultaSQL("select disponible, contenido from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "6_1_2")
                        Dim dr3 As DataRow = dt3.Rows(0)
                        If dr3("Disponible") < dr3("Contenido") Then
                            oDBVen.EjecutarComandoSQL("update inventario set contenido=disponible,MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                        End If
                        dt3.Dispose()
                    Else '6.1.2.1.3
                        oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") - FCantidad & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                    End If


                End If
                Dt2.Dispose()
            Next
            Dt.Dispose()
            Return True
        End If
        '7
        If (partTipoTransProd = ServicesCentral.TiposTransProd.Ajustes OrElse (partTipoTransProd = ServicesCentral.TiposTransProd.CambioDeProducto AndAlso oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta)) AndAlso partTipoMovimiento = ServicesCentral.TiposMovimientos.Salida Then
            Dim s As String = "select productodetalle.factor, productodetalle.productodetclave,productoclave from productodetalle where '" & pariProductoClave & "'=productodetalle.productoclave and productodetalle.prutipounidad=" & pariTipoUnidad
            Dt = oDBVen.RealizarConsultaSQL(s, "7")
            Dim FCantidad As Decimal
            For Each Dr As DataRow In Dt.Rows
                Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL("select disponible,Contenido from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "7_1_2_1")
                For Each Dr2 As DataRow In Dt2.Rows
                    FCantidad = Dr("factor") * pardCantidad
                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                        oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") - FCantidad & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                    Else
                        oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") - FCantidad & ",Contenido=" & Dr2("Contenido") - FCantidad & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                    End If
                Next
                Dt2.Dispose()
            Next
            Dt.Dispose()
            Return True
        End If
        '8
        If partTipoTransProd = ServicesCentral.TiposTransProd.Ajustes AndAlso partTipoMovimiento = ServicesCentral.TiposMovimientos.Entrada Then
            Dt = oDBVen.RealizarConsultaSQL("select productodetalle.factor, productodetalle.productodetclave,productodetalle.productoclave from productodetalle where '" & pariProductoClave & "'=productodetalle.productoclave and productodetalle.prutipounidad=" & pariTipoUnidad, "8")
            Dim FCantidad As Decimal
            For Each Dr As DataRow In Dt.Rows
                Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL("select disponible,Contenido from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "8_1_2_1")
                For Each Dr2 As DataRow In Dt2.Rows
                    FCantidad = Dr("factor") * pardCantidad
                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                        oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") + FCantidad & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                    Else
                        oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") + FCantidad & ",Contenido=" & Dr2("Contenido") + FCantidad & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                    End If
                Next
                Dt2.Dispose()
            Next
            Dt.Dispose()
            Return True
        End If
        '9
        'If (partTipoTransProd = ServicesCentral.TiposTransProd.CargaPorReparto Or (partTipoTransProd = ServicesCentral.TiposTransProd.CargaPorCanje AndAlso oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion)) AndAlso partTipoMovimiento = ServicesCentral.TiposMovimientos.Entrada Then
        If ((partTipoTransProd = ServicesCentral.TiposTransProd.CargaPorCanje AndAlso oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion)) AndAlso partTipoMovimiento = ServicesCentral.TiposMovimientos.Entrada Then
            '9.1
            Dt = oDBVen.RealizarConsultaSQL("select productoclave, productodetclave, factor from productodetalle where productoclave='" & pariProductoClave & "' and PRUTipoUnidad=" & pariTipoUnidad, "3")
            '9.2
            For Each Dr As DataRow In Dt.Rows
                '9.2.1
                Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL("select disponible, apartado, contenido from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "3_1_2_1")
                '9.2.1.2
                Dim FCantidad As Decimal = Dr("factor") * pardCantidad
                If Dt2.Rows.Count > 0 Then
                    Dim Dr2 As DataRow = Dt2.Rows(0)
                    '9.2.1.2
                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                        '9.2.1.2.1 , 9.2.1.2.2
                        oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") + FCantidad & ", apartado=" & Dr2("apartado") + FCantidad & " ,MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productoclave") & "'")
                    End If
                    '9.2.1.3
                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                        '9.2.1.3.1 , '9.2.1.3.2 ,'9.2.1.3.3
                        oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") + FCantidad & ", contenido=" & Dr2("contenido") + FCantidad & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productodetclave") & "'")
                        'odbVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") + fcantidad & ", apartado=" & Dr2("apartado") + fcantidad & ", contenido=" & Dr2("contenido") + fcantidad & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & dr("productodetclave") & "'")
                    End If
                Else '9.2.2
                    '9.2.2.1.3
                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                        oDBVen.EjecutarComandoSQL("insert into inventario values('" & Dr("productodetclave") & "','" & parsAlmacenId & "'," & FCantidad & ",0," & FCantidad & ",0,0," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "')")
                    End If
                    '9.2.2.1.4
                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                        oDBVen.EjecutarComandoSQL("insert into inventario values('" & Dr("productodetclave") & "','" & parsAlmacenId & "'," & FCantidad & ",0,0," & FCantidad & ",0," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "')")
                        'odbVen.EjecutarComandoSQL("insert into inventario values('" & dr("productodetclave") & "','" & parsAlmacenId & "'," & fcantidad & ",0," & fcantidad & "," & fcantidad & "," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "')")
                    End If
                End If
                Dt2.Dispose()
            Next
            Dt.Dispose()
            Return True
        End If
        '10
        If (partTipoTransProd = ServicesCentral.TiposTransProd.Descargas AndAlso partTipoMovimiento = ServicesCentral.TiposMovimientos.Salida AndAlso oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion) Then
            Dt = oDBVen.RealizarConsultaSQL("select productoclave, productodetclave, factor from productodetalle where productoclave='" & pariProductoClave & "' and PRUTipoUnidad=" & pariTipoUnidad, "3")
            For Each Dr As DataRow In Dt.Rows

                Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL("select pedido,disponible, apartado, contenido from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "12_1")
                Dim FCantidad As Decimal = Dr("factor") * pardCantidad '12.1
                If parbCancelacion Then FCantidad = FCantidad * -1 '12.1.1

                If Dt2.Rows.Count > 0 Then
                    Dim Dr2 As DataRow = Dt2.Rows(0)

                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                        If Dr2("pedido") > 0 Then
                            If (Dr2("disponible") - FCantidad) >= Dr2("pedido") Then
                                oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") - FCantidad & ", Apartado =  " & Dr2("pedido") & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productoclave") & "'")
                            Else
                                oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") - FCantidad & ", Apartado =  " & Dr2("disponible") - FCantidad & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productoclave") & "'")
                            End If


                        Else
                            oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") - FCantidad & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productoclave") & "'")
                        End If


                    End If

                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                        oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") - FCantidad & ", contenido=" & Dr2("contenido") - FCantidad & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productodetclave") & "'")

                        Dim dt3 As DataTable = oDBVen.RealizarConsultaSQL("select disponible, contenido from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "6_1_2")
                        Dim dr3 As DataRow = dt3.Rows(0)
                        If dr3("Disponible") < dr3("Contenido") Then
                            oDBVen.EjecutarComandoSQL("update inventario set contenido=disponible,MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                        End If
                        dt3.Dispose()

                    End If

                End If
                Dt2.Dispose()
            Next
            Dt.Dispose()
            Return True
        End If
        '11
        If (partTipoTransProd = ServicesCentral.TiposTransProd.Pedido And oVendedor.TipoModulo = ServicesCentral.TiposModulos.Preventa AndAlso oAgenda.RutaActual.Inventario And partTipoMovimiento = ServicesCentral.TiposMovimientos.Salida) _
        OrElse (partTipoTransProd = ServicesCentral.TiposTransProd.Pedido And oVendedor.TipoModulo = ServicesCentral.TiposModulos.Preventa AndAlso oAgenda.RutaActual.Inventario And partTipoMovimiento = ServicesCentral.TiposMovimientos.Entrada And parbCancelacion) Then
            Dt = oDBVen.RealizarConsultaSQL("select ProductoDetalle.ProductoClave, ProductoDetalle.factor, productodetalle.productodetclave from productodetalle where '" & pariProductoClave & "'=productodetalle.productoclave and productodetalle.prutipounidad=" & pariTipoUnidad, "6")
            Dim FCantidad As Decimal
            For Each Dr As DataRow In Dt.Rows
                Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL("select disponible, contenido from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "6_1_2")
                If Dt2.Rows.Count > 0 Then
                    Dim Dr2 As DataRow = Dt2.Rows(0)
                    FCantidad = Dr("factor") * pardCantidad
                    '11.1.2.1.2
                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                        oDBVen.EjecutarComandoSQL("update inventario set contenido=" & Dr2("contenido") - FCantidad & ", disponible=" & Dr2("disponible") - FCantidad & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                    Else '11.1.2.1.3
                        oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") - FCantidad & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                    End If
                End If
                Dt2.Dispose()
            Next
            Dt.Dispose()
            Return True
        End If

        '12
        If (partTipoMovimiento = ServicesCentral.TiposMovimientos.Entrada AndAlso _
        (partTipoTransProd = ServicesCentral.TiposTransProd.Cargas Or (partTipoTransProd = ServicesCentral.TiposTransProd.DevolucionesCliente AndAlso parsGrupoMotivo = "Venta") Or partTipoTransProd = ServicesCentral.TiposTransProd.InventarioABordo Or (partTipoTransProd = ServicesCentral.TiposTransProd.CambioDeProducto AndAlso (parsGrupoMotivo = "Venta" OrElse parsGrupoMotivo = ""))) _
        AndAlso oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion) Then

            Dt = oDBVen.RealizarConsultaSQL("select productoclave, productodetclave, factor from productodetalle where productoclave='" & pariProductoClave & "' and PRUTipoUnidad=" & pariTipoUnidad, "3")
            For Each Dr As DataRow In Dt.Rows


                Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL("select Pedido,disponible, apartado, contenido from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "12_1")
                Dim FCantidad As Decimal = Dr("factor") * pardCantidad '12.1
                If parbCancelacion Then FCantidad = FCantidad * -1 '12.1.1

                If Dt2.Rows.Count > 0 Then
                    Dim Dr2 As DataRow = Dt2.Rows(0)
                    'Ya en inventario No Contenido
                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then

                        If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                            If FCantidad + Dr2("Disponible") >= Dr2("Pedido") Then
                                oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") + FCantidad & ", Apartado =  " & Dr2("Pedido") & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productoclave") & "'")
                            Else
                                oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") + FCantidad & ", Apartado = " & Dr2("disponible") + FCantidad & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productoclave") & "'")
                            End If

                        End If

                    End If
                    'Ya en inventario Contenido
                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                        oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") + FCantidad & ", contenido=" & Dr2("contenido") + FCantidad & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productodetclave") & "'")

                        Dim dt3 As DataTable = oDBVen.RealizarConsultaSQL("select disponible, contenido from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "6_1_2")
                        Dim dr3 As DataRow = dt3.Rows(0)
                        If dr3("Disponible") < dr3("Contenido") Then
                            oDBVen.EjecutarComandoSQL("update inventario set contenido=disponible,MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                        End If
                        dt3.Dispose()

                    End If
                Else
                    'No En Inventario No Contenido
                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                        oDBVen.EjecutarComandoSQL("insert into inventario values('" & Dr("productodetclave") & "','" & parsAlmacenId & "'," & FCantidad & ",0,0,0,0," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "')")
                    End If

                    'No En Inventario Contenido
                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                        oDBVen.EjecutarComandoSQL("insert into inventario values('" & Dr("productodetclave") & "','" & parsAlmacenId & "'," & FCantidad & ",0,0," & FCantidad & ",0," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "')")
                    End If
                End If
                Dt2.Dispose()
            Next
            Dt.Dispose()
            Return True
        End If

        '13
        If (partTipoMovimiento = ServicesCentral.TiposMovimientos.Pedido AndAlso partTipoTransProd = ServicesCentral.TiposTransProd.Pedido AndAlso oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion) Then
            Dt = oDBVen.RealizarConsultaSQL("select productoclave, productodetclave, factor from productodetalle where productoclave='" & pariProductoClave & "' and PRUTipoUnidad=" & pariTipoUnidad, "13")
            For Each Dr As DataRow In Dt.Rows


                Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL("select Pedido from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "13_1")
                Dim FCantidad As Decimal = Dr("factor") * pardCantidad


                If Dt2.Rows.Count > 0 Then
                    Dim Dr2 As DataRow = Dt2.Rows(0)

                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                        oDBVen.EjecutarComandoSQL("update inventario set Pedido=" & Dr2("Pedido") + FCantidad & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productoclave") & "'")
                    End If

                    'Sin Contenido
                    'If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                    '    oDBVen.EjecutarComandoSQL("update inventario set disponible=" & Dr2("disponible") + FCantidad & ", contenido=" & Dr2("contenido") + FCantidad & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productodetclave") & "'")
                    'End If
                Else

                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                        oDBVen.EjecutarComandoSQL("insert into inventario values('" & Dr("productodetclave") & "','" & parsAlmacenId & "',0,0,0,0," & FCantidad & "," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "')")
                    End If

                    'Sin Contenido
                    'If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                    '    oDBVen.EjecutarComandoSQL("insert into inventario values('" & Dr("productodetclave") & "','" & parsAlmacenId & "'," & FCantidad & ",0,0," & FCantidad & ",0," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "')")
                    'End If
                End If
                Dt2.Dispose()
            Next
            Dt.Dispose()
            Return True
        End If

        '14
        If (partTipoMovimiento = ServicesCentral.TiposMovimientos.Entrada AndAlso partTipoTransProd = ServicesCentral.TiposTransProd.Pedido AndAlso oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion AndAlso parbCancelacion = False) Then
            Dt = oDBVen.RealizarConsultaSQL("select productoclave, productodetclave, factor from productodetalle where productoclave='" & pariProductoClave & "' and PRUTipoUnidad=" & pariTipoUnidad, "13")
            For Each Dr As DataRow In Dt.Rows


                Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL("select Pedido,Apartado from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "13_1")
                Dim FCantidad As Decimal = Dr("factor") * pardCantidad

                Dim dExistente As Decimal = 0
                Dim sError As String = ""
                ValidarExistenciaDisponibleDec(pariProductoClave, pariTipoUnidad, pardCantidad, dExistente, sError)


                If Dt2.Rows.Count > 0 Then
                    Dim Dr2 As DataRow = Dt2.Rows(0)

                    If FCantidad - pardPrestamoVendido > 0 Then
                        If dExistente > 0 And FCantidad > 0 Then
                            If dExistente > FCantidad Then
                                oDBVen.EjecutarComandoSQL("update inventario set Pedido=" & Dr2("Pedido") + (FCantidad - pardPrestamoVendido) & ",Apartado=" & Dr2("Apartado") + (FCantidad - pardPrestamoVendido) & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productoclave") & "'")
                            Else
                                oDBVen.EjecutarComandoSQL("update inventario set Pedido=" & Dr2("Pedido") + (FCantidad - pardPrestamoVendido) & ",Apartado=" & Dr2("Apartado") + dExistente & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productoclave") & "'")
                            End If
                        Else
                            oDBVen.EjecutarComandoSQL("update inventario set Pedido=" & Dr2("Pedido") + (FCantidad - pardPrestamoVendido) & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productoclave") & "'")
                        End If
                    End If

                    Dim Dt3 As DataTable = oDBVen.RealizarConsultaSQL("select Pedido,Apartado from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "13_1")
                    If Dt3.Rows.Count > 0 Then
                        Dim Dr3 As DataRow = Dt3.Rows(0)
                        If Dr3("Apartado") > Dr3("Pedido") Then
                            oDBVen.EjecutarComandoSQL("update inventario set Apartado=" & Dr3("Pedido") & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productoclave") & "'")
                        End If
                    End If

                    Dt3.Dispose()

                    'End If



                End If
                Dt2.Dispose()

            Next
            Dt.Dispose()
            Return True
        End If

        '15
        If partTipoMovimiento = ServicesCentral.TiposMovimientos.Salida AndAlso oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion AndAlso _
        partTipoTransProd = ServicesCentral.TiposTransProd.Cargas _
        Or (partTipoTransProd = ServicesCentral.TiposTransProd.DevolucionesCliente AndAlso parsGrupoMotivo = "Venta") _
        Or (partTipoTransProd = ServicesCentral.TiposTransProd.CambioDeProducto AndAlso (parsGrupoMotivo = "Venta" Or parsGrupoMotivo = "")) Then



            Dt = oDBVen.RealizarConsultaSQL("select productoclave, productodetclave, factor from productodetalle where productoclave='" & pariProductoClave & "' and PRUTipoUnidad=" & pariTipoUnidad, "13")
            For Each Dr As DataRow In Dt.Rows


                Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL("select Pedido,Apartado,Disponible,Contenido from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "13_1")
                Dim FCantidad As Decimal = Dr("factor") * pardCantidad

                Dim dDiferencia As Decimal = 0
                Dim dDisponible As Decimal = 0
                Dim sError As String = ""
                ValidarExistenciaDisponibleDec(pariProductoClave, pariTipoUnidad, pardCantidad, dDisponible, sError)
                dDiferencia = dDisponible - FCantidad

                'No Contenido
                If Dt2.Rows.Count > 0 Then

                    Dim Dr2 As DataRow = Dt2.Rows(0)

                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper = CStr(Dr("productodetclave")).ToUpper Then
                        If dDiferencia < 0 Then
                            oDBVen.EjecutarComandoSQL("update inventario set Apartado=" & Dr2("Apartado") - Math.Abs(dDiferencia) & ",Disponible=" & Dr2("Disponible") - FCantidad & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productoclave") & "'")
                        Else
                            oDBVen.EjecutarComandoSQL("update inventario set Disponible=" & Dr2("Disponible") - FCantidad & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productoclave") & "'")
                        End If

                    End If

                    'CONTENIDO
                    If CStr(Dr("productoclave")).ToUpper = pariProductoClave.ToUpper AndAlso pariProductoClave.ToUpper <> CStr(Dr("productodetclave")).ToUpper Then
                        oDBVen.EjecutarComandoSQL("update inventario set Contenido=" & Dr2("Contenido") - FCantidad & ",Disponible=" & Dr2("Disponible") - FCantidad & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where almacenid='" & parsAlmacenId & "' and productoclave='" & Dr("productoclave") & "'")
                    End If
                    Dim dt3 As DataTable = oDBVen.RealizarConsultaSQL("select disponible, contenido from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "6_1_2")
                    Dim dr3 As DataRow = dt3.Rows(0)
                    If dr3("Disponible") < dr3("Contenido") Then
                        oDBVen.EjecutarComandoSQL("update inventario set contenido=disponible,MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                    End If

                    dt3.Dispose()

                End If
                Dt2.Dispose()

            Next
            Dt.Dispose()
            Return True
        End If

        '16
        If partTipoMovimiento = ServicesCentral.TiposMovimientos.Entrada AndAlso oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion AndAlso partTipoTransProd = ServicesCentral.TiposTransProd.Pedido AndAlso parbCancelacion Then



            Dt = oDBVen.RealizarConsultaSQL("select productoclave, productodetclave, factor from productodetalle where productoclave='" & pariProductoClave & "' and PRUTipoUnidad=" & pariTipoUnidad, "13")
            For Each Dr As DataRow In Dt.Rows


                Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL("select Disponible,Apartado,(Pedido-Apartado)as XApartar,Contenido from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "13_1")
                Dim FCantidad As Decimal = Dr("factor") * pardCantidad

                If pariProductoClave.ToUpper = CType(Dr("ProductoDetClave"), String).ToUpper Then
                    If Dt2.Rows.Count > 0 Then
                        Dim Dr2 As DataRow = Dt2.Rows(0)
                        If FCantidad - pardPrestamoVendido > 0 Then
                            If Dr2("XApartar") >= FCantidad Then
                                oDBVen.EjecutarComandoSQL("update inventario set Disponible=" & Dr2("Disponible") + (FCantidad - pardPrestamoVendido) & ", apartado=" & Dr2("Apartado") + (FCantidad - pardPrestamoVendido) & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                            Else
                                oDBVen.EjecutarComandoSQL("update inventario set Disponible=" & Dr2("Disponible") + (FCantidad - pardPrestamoVendido) & ", apartado=" & Dr2("Apartado") + (Dr2("XApartar") - pardPrestamoVendido) & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                            End If
                        End If

                    End If
                Else
                    If Dt2.Rows.Count > 0 Then
                        Dim Dr2 As DataRow = Dt2.Rows(0)
                        If Dr2("XApartar") >= FCantidad Then
                            oDBVen.EjecutarComandoSQL("update inventario set Contenido=" & Dr2("Contenido") + FCantidad & ",Disponible=" & Dr2("Disponible") + FCantidad & ", apartado=" & Dr2("Apartado") + FCantidad & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                        Else
                            oDBVen.EjecutarComandoSQL("update inventario set Contenido=" & Dr2("Contenido") + FCantidad & ",Disponible=" & Dr2("Disponible") + FCantidad & ",apartado=" & Dr2("Apartado") + Dr2("XApartar") & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                        End If
                    End If
                End If




                Dt2.Dispose()

            Next
            Dt.Dispose()
            Return True
        End If

        '17
        If partTipoMovimiento = ServicesCentral.TiposMovimientos.NoDefinido AndAlso oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion AndAlso partTipoTransProd = ServicesCentral.TiposTransProd.Pedido AndAlso parbCancelacion Then


            Dt = oDBVen.RealizarConsultaSQL("select productoclave, productodetclave, factor from productodetalle where productoclave='" & pariProductoClave & "' and PRUTipoUnidad=" & pariTipoUnidad, "13")
            For Each Dr As DataRow In Dt.Rows


                Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQL("select Pedido,Apartado,Disponible from inventario where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'", "13_1")
                Dim FCantidad As Decimal = Dr("factor") * pardCantidad
                If pariProductoClave.ToUpper = CType(Dr("productodetclave"), String).ToUpper Then


                    If Dt2.Rows.Count > 0 Then
                        Dim Dr2 As DataRow = Dt2.Rows(0)
                        Dim Pedido As Double = 0
                        Pedido = Dr2("Pedido") - FCantidad
                        If Pedido < 0 Then Pedido = 0
                        Dim Apartado As Double = 0
                        If Pedido <= Dr2("Disponible") Then
                            Apartado = Pedido
                        Else
                            Apartado = Dr2("Disponible")
                        End If

                        'Dim Apartado As Double = 0

                        oDBVen.EjecutarComandoSQL("update inventario set Apartado = " & Apartado & ",Pedido=" & Pedido & ",MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID = '" & oVendedor.UsuarioId & "' where productoclave='" & Dr("productodetclave") & "' and almacenid='" & parsAlmacenId & "'")
                    End If
                End If




                Dt2.Dispose()

            Next
            Dt.Dispose()
            Return True
        End If

        Return False
    End Function




    Public Shared Function ValidarExistencia(ByVal pariProductoClave As String, ByVal pariTipoUnidad As Integer, ByVal pardCantidad As Integer, ByRef refpardExistencia As Integer, ByRef refparsMensajeError As String) As Boolean
        Try
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select productodetalle.factor, inventario.disponible from productodetalle, inventario where inventario.almacenid='" & oVendedor.AlmacenId & "' and '" & pariProductoClave & "'=inventario.productoclave and inventario.productoclave=productodetalle.productoclave and inventario.productoclave=productodetalle.productodetclave and productodetalle.prutipounidad=" & pariTipoUnidad, "Query")
            If Dt.Rows.Count > 0 Then
                Dim Dr As DataRow = Dt.Rows(0)
                Dim Cantidad As Decimal = pardCantidad * Dr(0)
                If Cantidad <= Dr(1) Then
                    refpardExistencia = 1
                    Dt.Dispose()
                    Return True
                Else
                    refpardExistencia = 0
                    Dt.Dispose()
                    Return False
                End If
            Else
                refpardExistencia = 0
                Dt.Dispose()
                Return False
            End If
        Catch ex As SqlServerCe.SqlCeException
            refparsMensajeError = ex.Message
            Return False
        Catch ex As Exception
            refparsMensajeError = ex.Message
            Return False
        End Try
    End Function

    Public Shared Function ValidarExistenciaDifNoDiponibleDec(ByVal pariProductoClave As String, ByVal pariTipoUnidad As Integer, ByVal pardCantidad As Decimal, ByRef refpardExistencia As Decimal, ByRef refparsMensajeError As String) As Boolean
        Try
            Dim DiferenciaApartado As Double = 0
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL("select productodetalle.factor, (inventario.Disponible - inventario.NoDisponible - inventario.Contenido) as Inventario,inventario.Pedido from productodetalle, inventario where inventario.almacenid='" & oVendedor.AlmacenId & "' and '" & pariProductoClave & "'=inventario.productoclave and inventario.productoclave=productodetalle.productoclave and inventario.productoclave=productodetalle.productodetclave and productodetalle.prutipounidad=" & pariTipoUnidad, "Query")
            Dim Dt2 As DataTable = oDBVen.RealizarConsultaSQLSinTransaction("select inventario.Pedido from productodetalle, inventario where inventario.almacenid='" & oVendedor.AlmacenId & "' and '" & pariProductoClave & "'=inventario.productoclave and inventario.productoclave=productodetalle.productoclave and inventario.productoclave=productodetalle.productodetclave and productodetalle.prutipounidad=" & pariTipoUnidad, "Query")
            If Dt.Rows.Count > 0 Then
                DiferenciaApartado = Dt.Rows(0)(2) - Dt2.Rows(0)(0)
                Dim Dr As DataRow = Dt.Rows(0)
                Dim Cantidad As Decimal = pardCantidad * Dr(0)
                If Cantidad <= Dr(1) - DiferenciaApartado Then
                    refpardExistencia = 1
                    Dt.Dispose()
                    Return True
                Else
                    refpardExistencia = 0
                    Dt.Dispose()
                    Return False
                End If
            Else
                refpardExistencia = 0
                Dt.Dispose()
                Return False
            End If
        Catch ex As SqlServerCe.SqlCeException
            refparsMensajeError = ex.Message
            Return False
        Catch ex As Exception
            refparsMensajeError = ex.Message
            Return False
        End Try
    End Function


    Public Shared Function DeterminarValidacionInventario(ByVal partTipoMovimiento As ServicesCentral.TiposMovimientos, ByVal partTipoTransProd As ServicesCentral.TiposTransProd) As TiposVerificacionInventario
        ' Verificar inventario
        If partTipoMovimiento = ServicesCentral.TiposMovimientos.Entrada Or (partTipoMovimiento = ServicesCentral.TiposMovimientos.NoDefinido And partTipoTransProd = ServicesCentral.TiposTransProd.Pedido) Then
            ' No verificar existencia
            Return TiposVerificacionInventario.NoVerificar
        Else
            ' Verificar existencia
            If (partTipoMovimiento = ServicesCentral.TiposMovimientos.Salida And _
           (partTipoTransProd = ServicesCentral.TiposTransProd.CambioDeProducto)) Or _
            (partTipoTransProd = ServicesCentral.TiposTransProd.Pedido) Or _
            (partTipoTransProd = ServicesCentral.TiposTransProd.VentaConsignacion) Then
                Return TiposVerificacionInventario.ValidarExistenciaDisponible
            End If
            If (partTipoMovimiento = ServicesCentral.TiposMovimientos.Salida And (partTipoTransProd = ServicesCentral.TiposTransProd.Descargas Or partTipoTransProd = ServicesCentral.TiposTransProd.Ajustes)) Then
                Return TiposVerificacionInventario.ValidarExistenciaDescarga
            End If
            If (partTipoMovimiento = ServicesCentral.TiposMovimientos.Salida And partTipoTransProd = ServicesCentral.TiposTransProd.DevolucionesAlmacen) Then
                Return TiposVerificacionInventario.ValidarExistenciaNoDisponible
            End If
        End If
        Return TiposVerificacionInventario.NoVerificar
    End Function

    Public Shared Sub ObtenerCantidadAActualizar(ByVal partTipoMovimiento As ServicesCentral.TiposMovimientos, ByRef refpardCantidadSolicitada As Decimal, ByVal pardCantidadCapturada As Decimal)
        ' Verificar si existe cantidad capturada previamente
        Select Case partTipoMovimiento
            Case ServicesCentral.TiposMovimientos.Salida, ServicesCentral.TiposMovimientos.NoDefinido
                If pardCantidadCapturada <> 0 Then
                    refpardCantidadSolicitada = refpardCantidadSolicitada - pardCantidadCapturada
                End If
            Case ServicesCentral.TiposMovimientos.Entrada
                If pardCantidadCapturada <> 0 Then
                    refpardCantidadSolicitada = refpardCantidadSolicitada - pardCantidadCapturada
                End If
        End Select
    End Sub

    'Public Shared Sub CrearMovimientoInventarioABordo()
    '    Dim dtRangoAgenda As DataTable = oDBVen.RealizarConsultaSQL("select min(FechaCaptura) as FechaMinima, max(FechaCaptura) as FechaMaxima from dia where FueraFrecuencia = 0", "RangoAgenda")
    '    Dim sTransProdID As String = String.Empty
    '    Dim dFechaCaptura As DateTime
    '    Dim lista As New System.Collections.Generic.Dictionary(Of String, Object)()
    '    If dtRangoAgenda.Rows.Count > 0 AndAlso (Not IsDBNull(dtRangoAgenda.Rows(0)("FechaMinima"))) AndAlso (Not IsDBNull(dtRangoAgenda.Rows(0)("FechaMaxima"))) Then
    '        sTransProdID = oDBVen.EjecutarCmdScalarStrSQL("Select TransProdID from TransProd where Tipo = 23 and FechaCaptura between " & UniFechaSQL(PrimeraHora(dtRangoAgenda.Rows(0)("FechaMinima"))) & " and " & UniFechaSQL(UltimaHora(dtRangoAgenda.Rows(0)("FechaMaxima"))))
    '    End If
    '    dtRangoAgenda.Dispose()
    '    Dim sDiaClave As String = ""
    '    lista = oDBVen.RealizarReaderSQLconCampos("select DiaClave, FechaCaptura from dia where FueraFrecuencia = 0 order by FechaCaptura asc")
    '    If (lista.Count > 0) Then
    '        sDiaClave = lista("DiaClave").ToString()
    '        dFechaCaptura = Convert.ToDateTime(lista("FechaCaptura"))
    '    Else
    '        MessageBox.Show("No Existe Dia seleccionado")
    '    End If
    '    Dim blnNuevo As Boolean = False

    '    Dim sComandoSQL As New System.Text.StringBuilder

    '    If IsNothing(sTransProdID) OrElse sTransProdID = String.Empty Then
    '        sComandoSQL.Append("INSERT INTO TransProd (TransProdID,DiaClave, Folio, Tipo,  TipoFase, TipoMovimiento, FechaCaptura, FechaHoraAlta,Total, Notas, MFechaHora, MUsuarioID,Enviado) VALUES (")
    '        sTransProdID = oApp.KEYGEN(1)
    '        sComandoSQL.Append("'" & sTransProdID & "',") 'TransProdID
    '        sComandoSQL.Append("'" & sDiaClave & "',") 'DiaClave
    '        sComandoSQL.Append("'" & 0 & "',") 'Folio
    '        sComandoSQL.Append(ServicesCentral.TiposTransProd.InventarioABordo & ",") 'Tipo
    '        sComandoSQL.Append(ServicesCentral.TiposFasesPedidos.Captura & ",") 'TipoFase
    '        sComandoSQL.Append(ServicesCentral.TiposMovimientos.Entrada & ",") 'TipoMovimiento
    '        sComandoSQL.Append(UniFechaSQL(PrimeraHora(dFechaCaptura)) & ",") 'FechaCaptura
    '        sComandoSQL.Append(UniFechaSQL(Now) & ",") 'FechaHoraAlta
    '        sComandoSQL.Append("0,")  'Total
    '        sComandoSQL.Append("'" & oVendedor.ClaveCEDI & "',") 'Notas
    '        sComandoSQL.Append(UniFechaSQL(Now) & ",")
    '        sComandoSQL.Append("'" & oVendedor.UsuarioId & "',")
    '        sComandoSQL.Append("0)")
    '        blnNuevo = True
    '    Else
    '        sComandoSQL.Append("UPDATE TransProd SET ")
    '        sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",")
    '        sComandoSQL.Append("Enviado=0 ")
    '        sComandoSQL.Append("WHERE TransProdId='" & sTransProdID & "'")
    '        blnNuevo = False
    '    End If

    '    oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)

    '    Dim dtInventario As DataTable
    '    dtInventario = oDBVen.RealizarConsultaSQL("Select ProductoClave, AlmacenID, Disponible-Contenido-NoDisponible as Disponible from Inventario ", "Inventario")

    '    Dim sTransProdDetalleID As String = String.Empty
    '    Dim iPartida As Integer = 1
    '    If blnNuevo Then
    '        For Each dr As DataRow In dtInventario.Rows
    '            Dim dtUnidades As DataTable
    '            dtUnidades = oDBVen.RealizarConsultaSQL("Select PRUTipoUnidad, Factor from ProductoDetalle where ProductoClave = '" & dr("ProductoClave") & "' and ProductoDetClave='" & dr("ProductoClave") & "' order by Factor asc", "Factor")
    '            If dtUnidades.Rows.Count > 0 Then
    '                If dr("Disponible") > 0 Then
    '                    sComandoSQL = New System.Text.StringBuilder
    '                    sComandoSQL.Append("INSERT INTO TransProdDetalle (TransProdID,TransProdDetalleID, Partida, ProductoClave, TipoUnidad,  Cantidad, Precio, Subtotal, Total, MFechaHora, MUsuarioID,Enviado) VALUES (")
    '                    sComandoSQL.Append("'" & sTransProdID & "',") 'TransProdID
    '                    sComandoSQL.Append("'" & oApp.KEYGEN(iPartida) & "',") 'TransProdDetalleID
    '                    sComandoSQL.Append("'" & iPartida & "',") 'Partida
    '                    sComandoSQL.Append("'" & dr("ProductoClave") & "',") 'ProductoClave
    '                    sComandoSQL.Append(dtUnidades.Rows(0)("PRUTipoUnidad") & ",") 'TipoUnidad
    '                    sComandoSQL.Append(dr("Disponible") / dtUnidades.Rows(0)("Factor") & ",") 'Cantidad
    '                    sComandoSQL.Append("0,") 'Precio
    '                    sComandoSQL.Append("0,")  'Subtotal
    '                    sComandoSQL.Append("0,")  'Total
    '                    sComandoSQL.Append(UniFechaSQL(Now) & ",") 'MFechaHora
    '                    sComandoSQL.Append("'" & oVendedor.UsuarioId & "',") 'MUsuarioID
    '                    sComandoSQL.Append("0)") 'Enviado
    '                    oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
    '                End If
    '            End If
    '            dtUnidades.Dispose()
    '            iPartida += 1
    '        Next
    '    Else
    '        For Each dr As DataRow In dtInventario.Rows
    '            Dim dtUnidades As DataTable
    '            dtUnidades = oDBVen.RealizarConsultaSQL("Select PRUTipoUnidad, Factor from ProductoDetalle where ProductoClave = '" & dr("ProductoClave") & "' and ProductoDetClave='" & dr("ProductoClave") & "' order by Factor asc", "Factor")
    '            If dtUnidades.Rows.Count > 0 Then
    '                sTransProdDetalleID = oDBVen.EjecutarCmdScalarStrSQL("Select TransProdDetalleID from TransProdDetalle where TransProdID= '" & sTransProdID & "' and ProductoClave ='" & dr("ProductoClave") & "'")
    '                If IsNothing(sTransProdDetalleID) OrElse sTransProdDetalleID = String.Empty Then
    '                    iPartida = oDBVen.EjecutarCmdScalarIntSQL("Select  Max(Partida) + 1 from TransProdDetalle where TransProdID= '" & sTransProdID & "'")
    '                    If IsNothing(iPartida) OrElse iPartida <= 0 Then
    '                        iPartida = 1
    '                    End If
    '                    If dr("Disponible") > 0 Then
    '                        sComandoSQL = New System.Text.StringBuilder
    '                        sComandoSQL.Append("INSERT INTO TransProdDetalle (TransProdID,TransProdDetalleID, Partida, ProductoClave, TipoUnidad,  Cantidad, Precio, Subtotal, Total, MFechaHora, MUsuarioID,Enviado) VALUES (")
    '                        sComandoSQL.Append("'" & sTransProdID & "',") 'TransProdID
    '                        sComandoSQL.Append("'" & oApp.KEYGEN(iPartida) & "',") 'TransProdDetalleID
    '                        sComandoSQL.Append("'" & iPartida & "',") 'Partida
    '                        sComandoSQL.Append("'" & dr("ProductoClave") & "',") 'ProductoClave
    '                        sComandoSQL.Append(dtUnidades.Rows(0)("PRUTipoUnidad") & ",") 'TipoUnidad
    '                        sComandoSQL.Append(dr("Disponible") / dtUnidades.Rows(0)("Factor") & ",") 'Cantidad
    '                        sComandoSQL.Append("0,") 'Precio
    '                        sComandoSQL.Append("0,")  'Subtotal
    '                        sComandoSQL.Append("0,")  'Total
    '                        sComandoSQL.Append(UniFechaSQL(Now) & ",") 'MFechaHora
    '                        sComandoSQL.Append("'" & oVendedor.UsuarioId & "',") 'MUsuarioID
    '                        sComandoSQL.Append("0)") 'Enviado
    '                        oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
    '                    End If
    '                Else
    '                    sComandoSQL = New System.Text.StringBuilder
    '                    sComandoSQL.Append("UPDATE TransProdDetalle set ")
    '                    sComandoSQL.Append("Cantidad=" & dr("Disponible") / dtUnidades.Rows(0)("Factor") & ",") 'Cantidad
    '                    sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",") 'MFechaHora
    '                    sComandoSQL.Append("Enviado = 0") 'Enviado
    '                    sComandoSQL.Append("Where TransProdID ='" & sTransProdID & "' and TransProdDetalleID='" & sTransProdDetalleID & "'")
    '                    oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
    '                End If
    '            End If
    '            dtUnidades.Dispose()
    '        Next
    '    End If
    '    dtInventario.Dispose()

    'End Sub

    'Public Shared Function CargarInventarioABordo(ByVal pvdtMovimientos As DataTable)
    '    Try


    '        If pvdtMovimientos.Rows.Count > 0 Then
    '            Dim sTransProdId As String = String.Empty
    '            For Each oDr As DataRow In pvdtMovimientos.Rows
    '                Inventario.ActualizarInventarioDec(oDr("ProductoClave"), oDr("TipoUnidad"), oDr("Cantidad"), ServicesCentral.TiposTransProd.InventarioABordo, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId)
    '            Next
    '        End If





    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '        Return False
    '    End Try
    '    Return True
    'End Function
    'Public Shared Sub CargarInventarioPedido()
    '    Try


    '        oVendedor.RecuperarParametros(True)
    '        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
    '            Dim ldtTransProdDetalle As DataTable = oDBVen.RealizarConsultaSQL("Select td.* from TransProdDetalle td inner join transprod t on t.transprodid=td.transprodid  where Tipo=1 and TipoFase=1", "PEDIDO")
    '            For Each ldr As DataRow In ldtTransProdDetalle.Rows
    '                Inventario.ActualizarInventarioDec(ldr("ProductoClave"), ldr("TipoUnidad"), ldr("Cantidad"), ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Pedido, oVendedor.AlmacenId)
    '            Next
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try

    'End Sub


    Public Shared Function ValidarInventarioABordo() As Boolean
        Dim sConsulta As String
        sConsulta = "select count(*) as Cant from Inventario where Disponible > 0 or NoDisponible > 0 "
        Return oDBVen.EjecutarCmdScalarIntSQL(sConsulta) > 0
    End Function

End Class
