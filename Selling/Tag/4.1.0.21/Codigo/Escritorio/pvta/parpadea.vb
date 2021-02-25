Public Class parpadea
    Inherits Timer

    Private Function GetEmbeddedIcon(ByVal strName As String) As Icon
        Return New _
    Icon(System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(strName))
    End Function

    Private imagen As PictureBox
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByVal img As PictureBox)

        If Not img Is Nothing Then
            If img.Image Is Nothing Then
                img.Image = GetEmbeddedIcon("PointOfSale.Warning.ico").ToBitmap()
            End If
        End If
        imagen = img
        Me.Interval = 100
    End Sub

    'Function GetListOfEmbeddedResources() As Array
    '    Return _
    '     System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceNames
    'End Function


    Private Sub parpadea_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Tick
        Static bteContador As Byte = 0

        If bteContador = 5 Then
            Me.Stop()
            Me.Enabled = False

        Else
            bteContador = bteContador + 1

            If Not imagen Is Nothing Then

                If bteContador = 1 AndAlso imagen.Visible = True Then
                    imagen.Visible = False
                End If

                If imagen.Visible Then
                    imagen.Visible = False
                Else
                    imagen.Visible = True
                End If
            End If

        End If

    End Sub
End Class
