Public Class Foto
    Inherits System.Windows.Forms.PictureBox

    'Atributos de la estructura
    Public PROClave As String
     Public IMGClave As String
    Public NombreImagen As String
    Public indice As Integer
    Public Estado As Integer
    Public Nuevo As Boolean
  
    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Clave As String)
        IMGClave = Clave
        Me.Estado = 1
    End Sub

End Class
