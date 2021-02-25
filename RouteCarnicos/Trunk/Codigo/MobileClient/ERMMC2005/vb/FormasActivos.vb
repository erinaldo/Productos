Public Class FormasActivos
    Implements ERM.Dia.Agenda.Visita.ModuloMov.Activos

    Public Function Capturar(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean Implements ERM.Dia.Agenda.Visita.ModuloMov.Activos.Capturar
        Dim oFormActivos As New FormActivos(paroCliente, parsVisitaClave)
        If oFormActivos.ShowDialog = DialogResult.OK Then
            oFormActivos.Dispose()
            Return True
        End If
        oFormActivos.Dispose()
        Return False
    End Function
End Class
