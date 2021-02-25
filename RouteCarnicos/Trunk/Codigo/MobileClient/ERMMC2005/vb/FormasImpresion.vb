Public Class FormasImpresion
    Implements ERM.Dia.Agenda.Visita.Impresion

    Public Function ImprimirConVisita(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean Implements ERM.Dia.Agenda.Visita.Impresion.ImprimirConVisita
        Dim oFIT As New FormImpresionTickets(FormImpresionTickets.ModoImpresion.ConVisita, paroCliente, parsVisitaClave)
        oFIT.ShowDialog()
        oFIT.Dispose()
    End Function

    Public Sub ImprimirSinVisita()
        Dim oFIT As New FormImpresionTickets(FormImpresionTickets.ModoImpresion.SinVisita)
        oFIT.ShowDialog()
        oFIT.Dispose()
    End Sub
End Class
