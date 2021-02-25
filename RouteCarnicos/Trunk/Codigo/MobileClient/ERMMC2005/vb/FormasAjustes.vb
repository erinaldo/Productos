Public Class FormasAjustes
    Implements ERM.Dia.Ajustes

    Public Function Capturar() As Boolean Implements ERM.Dia.Ajustes.Capturar
        Dim oFormAjustes As New FormAjustes
        If oFormAjustes.ShowDialog = DialogResult.OK Then
            oFormAjustes.Dispose()
            Return True
        End If
        oFormAjustes.Dispose()
        Return False
    End Function
End Class
