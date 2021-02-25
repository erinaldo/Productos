Public Class FormasHistoricoVtas
    Implements ERM.Dia.Agenda.Visita.ModuloMov.HistoricoVentas

    Public Function Capturar(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean Implements ERM.Dia.Agenda.Visita.ModuloMov.HistoricoVentas.Capturar
        Dim oFormHistoricoVtas As New FormHistoricoVtas(paroCliente, parsVisitaClave)
        If oFormHistoricoVtas.ShowDialog = DialogResult.OK Then
            oFormHistoricoVtas.Dispose()
            Return True
        End If
        oFormHistoricoVtas.Dispose()
        Return False
    End Function
End Class
