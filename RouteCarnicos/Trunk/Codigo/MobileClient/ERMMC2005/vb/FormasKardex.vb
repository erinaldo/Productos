Public Class FormasKardex
    Implements ERM.Dia.Kardex

    Public Function Capturar(ByVal odia As Dia) As Boolean Implements ERM.Dia.Kardex.Capturar
        Dim oFormKardex As New FormKardex

        If oFormKardex.ShowDialog() = DialogResult.OK Then
            oFormKardex.Dispose()
            Return True
        End If
        oFormKardex.Dispose()
        Return False
    End Function
End Class
