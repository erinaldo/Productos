Public Class FormasPagosProgramados
    Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasPagosProgramados

    Private Function ExistenMovimientos(ByVal paroCliente As Cliente) As Boolean
        Dim sConsulta As String
        Dim nMovs As Integer
        sConsulta = "select count(*) from AbonoProgramado "
        sConsulta &= "inner join Visita on AbonoProgramado.VisitaClave=Visita.VisitaClave and AbonoProgramado.DiaClave=Visita.DiaClave "
        sConsulta &= "and Visita.ClienteClave='" & paroCliente.ClienteClave & "' and Visita.VendedorId='" & oVendedor.VendedorId & "' "
        nMovs = oDBVen.RealizarScalarSQL(sConsulta)
        Return (nMovs > 0)
    End Function

    Public Function Mostrar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasPagosProgramados.Mostrar
        If ExistenMovimientos(paroCliente) Then
            Dim oForma As New FormAbonoProgramado(parsVisitaClave, paroCliente.ClienteClave)
            oForma.ShowDialog()
            oForma.Dispose()
            oForma = Nothing
        Else
            Dim oForma As New FormAbonoProgramadoDetalle(parsVisitaClave, FormAbonoProgramadoDetalle.eModo.Nuevo)
            oForma.ShowDialog()
            oForma.Dispose()
            oForma = Nothing
        End If
    End Function

End Class
