Public Class Deposito
    Implements ERM.Dia.Depositos

    Public Function Capturar() As Boolean Implements ERM.Dia.Depositos.Capturar
        Dim oFormaDevolucion As New FormDepositos
        If oFormaDevolucion.ShowDialog = DialogResult.OK Then
            oFormaDevolucion.Dispose()
            Return True
        End If
        oFormaDevolucion.Dispose()
        Return False
    End Function

End Class
