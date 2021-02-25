Module Cuotas

    Public Function VendedorTieneCuotas(ByRef prArray As ArrayList, ByVal pvVendedorId As String) As Boolean
        Dim oDt As DataTable = oDBVen.RealizarConsultaSQL("Select CUOClave FROM CUOVEN Where VendedorId='" & pvVendedorId & "'", "VendedorTieneCuotas")
        If oDt.Rows.Count = 0 Then Return False
        prArray = New ArrayList
        For Each oDr As DataRow In oDt.Rows
            prArray.Add(oDr("CUOClave"))
        Next
        oDt.Dispose()
        Return True
    End Function

    Public Sub VerificarCuotas(ByVal pvVendedorId As String, ByVal pvClienteClave As String, ByVal pvProductoClave As String, ByVal pvCantidad As Decimal, ByVal pvTipoCuota As Integer)
        Dim oDt As DataTable = oDBVen.RealizarConsultaSQL("Select Cuota.CUOClave FROM Cuota INNER JOIN CuoVen CV ON Cuota.CuoClave=CV.CuoClave AND CV.VendedorId='" & oVendedor.VendedorId & "' AND " & UniFechaSQL(PrimeraHora(Now)) & " BETWEEN Cuota.FechaInicio AND Cuota.FechaFin ", "VerifCuotas")
        For Each oDr As DataRow In oDt.Rows
            'CuotaCumplida
            Dim dtRes As DataTable
            dtRes = oDBVen.RealizarConsultaSQL("Select CuotaCumplida.CUOClave From CuotaCumplida inner join CUOVen on CUOVen.CUOClave=CuotaCumplida.CUOClave and CUOVen.VendedorID=CuotaCumplida.VendedorID WHERE CuotaCumplida.CuoClave='" & oDr("CuoClave") & "' AND CuotaCumplida.VendedorId='" & pvVendedorId & "' AND CUOVen.Tipo=" & pvTipoCuota, "CuotaCumplida")
            For Each oDrCC As DataRow In dtRes.Rows
                oDBVen.EjecutarComandoSQL("Update CuotaCumplida Set Cantidad= Cantidad + " & pvCantidad & ",MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 WHERE CUOClave='" & oDrCC("CUOClave") & "' AND VendedorId='" & pvVendedorId & "'")
            Next
            'Esquemas
            dtRes = oDBVen.RealizarConsultaSQL("select distinct CUOEsquema.EsquemaID from CUOEsquema inner join Esquema on CUOEsquema.EsquemaID=Esquema.EsquemaID or CUOEsquema.EsquemaID=Esquema.EsquemaIDPadre inner join ProductoEsquema on Esquema.EsquemaID=ProductoEsquema.EsquemaID where CuoEsquema.CuoClave='" & oDr("CuoClave") & "' and ProductoClave='" & pvProductoClave & "' and CUOEsquema.Tipo =" & pvTipoCuota, "CUOEsquema")
            For Each oDrCC As DataRow In dtRes.Rows
                oDBVen.EjecutarComandoSQL("Update CueCcu Set Cantidad= Round(Cantidad + " & pvCantidad & ",2),MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 WHERE CUOClave='" & oDr("CUOClave") & "' AND VendedorId='" & pvVendedorId & "' and EsquemaID='" & oDrCC("EsquemaID") & "' ")
            Next
            'Producto
            dtRes = oDBVen.RealizarConsultaSQL("select CUOClave from CUOProducto where CUOProducto.CuoClave='" & oDr("CuoClave") & "' and ProductoClave='" & pvProductoClave & "' and CUOProducto.Tipo =" & pvTipoCuota, "CUOProducto")
            For Each oDrCC As DataRow In dtRes.Rows
                oDBVen.EjecutarComandoSQL("Update CupCcu Set Cantidad= Round(Cantidad + " & pvCantidad & ",2),MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 WHERE CUOClave='" & oDr("CUOClave") & "' AND VendedorId='" & pvVendedorId & "' and ProductoClave='" & pvProductoClave & "' ")
            Next
            'Cliente
            dtRes = oDBVen.RealizarConsultaSQL("select CUOClave from CUOCliente where CUOCliente.CuoClave='" & oDr("CuoClave") & "' and ClienteClave='" & pvClienteClave & "' and CUOCliente.Tipo =" & pvTipoCuota, "CUOCliente")
            For Each oDrCC As DataRow In dtRes.Rows
                oDBVen.EjecutarComandoSQL("Update CucCcu Set Cantidad= Round(Cantidad + " & pvCantidad & ",2),MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 WHERE CUOClave='" & oDr("CUOClave") & "' AND VendedorId='" & pvVendedorId & "' and ClienteClave='" & pvClienteClave & "' ")
            Next
            dtRes.Dispose()
        Next
        oDt.Dispose()
    End Sub
    Public Sub RestarCuotasXProducto(ByVal oTransProd As TransProd)
        Dim dt As DataTable = oDBVen.RealizarConsultaSQL("select transproddetalle.ProductoClave,transproddetalle.TipoUnidad,transproddetalle.Cantidad * ProductoDetalle.Factor as CantidadUnitaria from transproddetalle inner join ProductoDetalle on ProductoDetalle.ProductoClave=TransProdDetalle.ProductoClave and ProductoDetalle.PRUTipoUnidad=TransProdDetalle.TipoUnidad and ProductoDetalle.ProductoDetClave=TransProdDetalle.ProductoClave where TransProdID='" & oTransProd.TransProdId & "'", "TransProdDetalle")
        Dim dr As DataRow
        For Each dr In dt.Rows
            VerificarCuotas(oVendedor.VendedorId, oTransProd.ClienteActual.ClienteClave, dr("ProductoClave"), -1 * dr("CantidadUnitaria"), 1)
        Next
        dt.Dispose()
    End Sub
    Public Sub CalcularCuotasxEfectivo(ByVal oTransProd As TransProd, ByVal parbRestar As Boolean)

        Dim dt As DataTable = oDBVen.RealizarConsultaSQL("Select TransProdDetalleID,ProductoClave,Subtotal from TransProdDetalle where TransProdID='" & oTransProd.TransProdId & "' AND Subtotal>0", "TransProdDetalle")
        Dim dr As DataRow
        Dim iFactor As Integer = 1
        Dim nSTCD As Double = 0
        Dim nCantidad As Double = 0
        Dim dtDC As DataTable = oDBVen.RealizarConsultaSQL("Select TransProdDetalleID, sum(DesImporte) as DescuentoCliente from TpdDes where TransProdID='" & oTransProd.TransProdId & "' group by TransProdDetalleID", "DescuentoCliente")

        For Each dr In dt.Rows

            nSTCD = 0
            iFactor = 1
            'Descuentos del cliente
            nSTCD = dr("Subtotal")
            If dtDC.Rows.Count > 0 Then
                If dtDC.Select("TransProdDetalleID='" & dr("TransProdDetalleID") & "'").Length > 0 Then
                    nSTCD -= dtDC.Select("TransProdDetalleID='" & dr("TransProdDetalleID") & "'")(0)("DescuentoCliente")
                End If
            End If

            'Descuento del vendedor
            nSTCD -= nSTCD * (oTransProd.DescVendPor / 100)
            'SubTotal con Descuentos

            If parbRestar Then
                nCantidad = -1 * (nSTCD)
            Else
                nCantidad = nSTCD
            End If

            VerificarCuotas(oVendedor.VendedorId, oTransProd.ClienteActual.ClienteClave, dr("ProductoClave"), nCantidad, 2)
        Next
        dt.Dispose()
        dtDC.Dispose()

    End Sub

End Module

