Public Class FormasDevolucionesPrestamos
    Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasDevolucionesPrestamos

    Private Function ExistenMovimientos(ByVal paroCliente As Cliente) As Boolean
        Dim sConsulta As String
        Dim nMovs As Integer
        sConsulta = "select count(*) from TransProd as T "
        sConsulta &= "inner join Visita as V on T.VisitaClave=V.VisitaClave and T.DiaClave=V.DiaClave "
        sConsulta &= "where T.Tipo=15 and V.ClienteClave='" & paroCliente.ClienteClave & "'"
        nMovs = oDBVen.RealizarScalarSQL(sConsulta)
        Return (nMovs > 0)
    End Function

    Public Function Capturar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasDevolucionesPrestamos.Capturar
        If ExistenMovimientos(paroCliente) Then
            Dim oFormDevolucionPrestamos As New FormDevolucionPrestamos(paroModuloMovDetActual, paroCliente, parsVisitaClave)
            If oFormDevolucionPrestamos.ShowDialog() = DialogResult.OK Then
                oFormDevolucionPrestamos.Dispose()
                Return True
            End If
            oFormDevolucionPrestamos.Dispose()
            Return False
        Else
            Dim sTransProdId As String = oApp.KEYGEN(0)
            Dim sFolio As String = Folio.Obtener(, ServicesCentral.TiposModulosMovDet.DevolucionPrestamos)
            If sFolio <> "" Then
                Dim oFormDetalle As New FormDevolucionPrestamosDetalle(sTransProdId, Nothing, paroCliente, parsVisitaClave, sFolio, eModo.Nuevo)
                oFormDetalle.ShowDialog()
                oFormDetalle.Dispose()
                Return True
            End If
            Return False
        End If
    End Function
End Class
