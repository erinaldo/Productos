Public Class FormasReportes
    Implements ERM.Dia.Reportes

    Public Function Capturar(ByVal oDia As Dia) As Boolean Implements ERM.Dia.Reportes.Capturar
        Dim oFormReportes As New FormReportes(oDia, "DENTRO")

        If oFormReportes.ShowDialog() = DialogResult.OK Then
            oFormReportes.Dispose()
            oFormReportes = Nothing
            Return True
        End If
        oFormReportes.Dispose()
        oFormReportes = Nothing
        Return False
    End Function

End Class
