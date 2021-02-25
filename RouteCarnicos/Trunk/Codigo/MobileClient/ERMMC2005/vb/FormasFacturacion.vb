Public Class FormasFacturacion
    Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasFacturacion

    Private Function ExistenMovimientos(ByVal paroCliente As Cliente) As Boolean
        Dim sConsulta As String
        Dim nMovs As Integer
        sConsulta = "select count(*) from TransProd "
        sConsulta &= "inner join Visita on TransProd.VisitaClave=Visita.VisitaClave "
        sConsulta &= "where TransProd.Tipo=8 and Visita.DiaClave=TransProd.DiaClave "
        sConsulta &= "and Visita.ClienteClave='" & paroCliente.ClienteClave & "' "
        sConsulta &= "and Visita.DiaClave='" & oDia.DiaActual & "'"
        nMovs = oDBVen.RealizarScalarSQL(sConsulta)
        Return (nMovs > 0)
    End Function

    Public Function Mostrar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasFacturacion.Mostrar
        If ExistenMovimientos(paroCliente) Then
            Dim oFormFacturacion As New FormFacturacion(paroCliente, parsVisitaClave, paroModuloMovDetActual)
            If oFormFacturacion.ShowDialog() = DialogResult.OK Then
                oFormFacturacion.Dispose()
                Return True
            End If
            oFormFacturacion.Dispose()
            Return False
        Else
            Dim sFolio As String = String.Empty
            If oVendedor.CapturaFolioFac = False Then
                sFolio = Folio.Obtener(, ServicesCentral.TiposModulosMovDet.Facturacion)
                If sFolio = "" Then Return False
            End If
            Return MostrarDetalle(paroCliente, parsVisitaClave, sFolio, FormFacturaDetalle.Modo.Crear, paroModuloMovDetActual, "")
        End If
    End Function



    Public Function MostrarDetalle(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByVal parFacturaID As String, ByVal parModo As FormFacturaDetalle.Modo, ByVal parGrupo As Modulos.GrupoModuloMovDetalle, ByVal parTransProdID As String, Optional ByVal parFecha As String = "", Optional ByVal parTotal As Double = 0) As Boolean Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasFacturacion.MostrarDetalle
        Dim oFormFactDetalle As New FormFacturaDetalle(paroCliente, parsVisitaClave, parFacturaID, parModo, parGrupo, parTransProdID, parFecha, parTotal)

        If oFormFactDetalle.ShowDialog() = DialogResult.OK Then
            oFormFactDetalle.Dispose()
            Return True
        End If
        oFormFactDetalle.Dispose()
        Return False
    End Function



End Class

