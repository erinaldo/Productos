Public Class FormasSolicitudes
    Implements ERM.Dia.Agenda.Visita.ModuloMov.Solicitudes

    Public Function Capturar(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean Implements ERM.Dia.Agenda.Visita.ModuloMov.Solicitudes.Capturar
        Dim oFSolicitud As New FormSolicitudes(paroCliente, parsVisitaClave)
        If oFSolicitud.ShowDialog = DialogResult.OK Then
            oFSolicitud.Dispose()
            Return True
        End If
        oFSolicitud.Dispose()
        Return False
    End Function
End Class
