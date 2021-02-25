Public Class ListItem
    Public Text As String
    Public Value As Integer

    Sub New(ByVal sText As String, ByVal iValue As Integer)
        Me.Text = sText
        Me.Value = iValue
    End Sub

    Overrides Function ToString() As String
        Return Text
    End Function
End Class


