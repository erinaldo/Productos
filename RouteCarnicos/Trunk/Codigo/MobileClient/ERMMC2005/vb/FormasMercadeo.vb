Public Class FormasMercadeo
    Implements ERM.Dia.Agenda.Visita.ModuloMov.Mercadeo

    Public Function Capturar(ByVal paroCliente As Cliente, ByVal parsVisita As String) As Boolean Implements ERM.Dia.Agenda.Visita.ModuloMov.Mercadeo.Capturar
        Dim oFormMercadeo As New FormMercadeo
        oFormMercadeo.sVisitaClave = parsVisita
        oFormMercadeo.sCte = paroCliente.ClienteClave

        If oFormMercadeo.ShowDialog() = DialogResult.OK Then
            oFormMercadeo.Dispose()
            Return True
        End If
        oFormMercadeo.Dispose()
        Return False
    End Function

End Class
