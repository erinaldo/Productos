#If MOD_TERM <> "PALM" Then
Public Class CTerminal

    Public Shared ReadOnly Property NumeroSerie() As String
        Get
#If MOD_TERM = "HHP" Then
            Return HHP.PDTDevice.UtilMethods.GetSerialNumber
#ElseIf MOD_TERM = "HHPWM6" Then
            Return HandHeldProducts.Embedded.Utility.UtilMethods.GetSerialNumber
#End If
        End Get
    End Property

End Class
#End If

