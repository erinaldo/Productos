Public Class Improductivo
    Implements ERM.Dia.Agenda.Visita.ModuloMov.Improductivo

    Public Function Capturar(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean Implements ERM.Dia.Agenda.Visita.ModuloMov.Improductivo.Capturar
        Dim oFormImprod As New FormImprod(paroCliente, parsVisitaClave)
        If oFormImprod.ShowDialog = DialogResult.OK Then
            oFormImprod.Dispose()
            Return True
        Else
            oFormImprod.Dispose()
            Return False
        End If
    End Function

End Class
