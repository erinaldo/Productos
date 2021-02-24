Imports System.IO

Namespace GMConnect
    Public Class BitacoraLog
        Dim RutaArchivo As String

        Public Sub New(pRutaArchivo As String, pNombreArchivo As String, pDescripcionError As String)
            RutaArchivo = System.IO.Path.Combine(pRutaArchivo, pNombreArchivo)

            If (Not System.IO.File.Exists(RutaArchivo)) Then

                Dim fileName As String = pNombreArchivo
                Dim stream As FileStream = New FileStream(RutaArchivo, FileMode.OpenOrCreate, FileAccess.Write)
                Dim writer As StreamWriter = New StreamWriter(stream)

                writer.WriteLine(pDescripcionError)
                writer.Close()

            End If
        End Sub

        Public Sub New(pRutaArchivo As String, pNombreArchivo As String)
            RutaArchivo = System.IO.Path.Combine(pRutaArchivo, pNombreArchivo)

            If (Not System.IO.File.Exists(RutaArchivo)) Then
                Dim fs As FileStream = System.IO.File.Create(RutaArchivo)
                fs.Close()
            End If
        End Sub


        Public Sub EscribirEnBitacora(pDescripcionError As String)
            Try
                Dim writer As StreamWriter = File.AppendText(RutaArchivo)
                writer.WriteLine(pDescripcionError)
                writer.Close()

            Catch ex As Exception

            End Try

        End Sub

    End Class
End Namespace

