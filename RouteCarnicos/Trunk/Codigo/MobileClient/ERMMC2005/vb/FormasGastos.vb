Public Class FormasGastos
    Implements ERM.Dia.Gastos

    Public Function Capturar() As Boolean Implements ERM.Dia.Gastos.Capturar
        Dim oFormGastos As New FormGastos
        If oFormGastos.ShowDialog = DialogResult.OK Then
            oFormGastos.Dispose()
            Return True
        End If
        oFormGastos.Dispose()
        Return False
    End Function

End Class
