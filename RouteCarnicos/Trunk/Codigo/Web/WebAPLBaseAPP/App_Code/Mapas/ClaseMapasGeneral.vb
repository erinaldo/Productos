Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Collections.Generic
Public Class ClaseMapasGeneral
    Public Shared Function obtenercolores() As List(Of Color)
        Dim listaDeColores As New List(Of Color)

        Try
            Dim colores As String() = ConfigurationManager.AppSettings("colorMaps").Split(";")
            For Each COLOR As String In colores
                listaDeColores.Add(System.Drawing.Color.FromArgb(COLOR.Split(",")(0), COLOR.Split(",")(1), COLOR.Split(",")(2)))
            Next

        Catch ex As Exception
            listaDeColores.Add(Color.Blue)
            listaDeColores.Add(Color.Red)
            listaDeColores.Add(Color.Aquamarine)
            listaDeColores.Add(Color.Green)
            listaDeColores.Add(Color.Gray)
        End Try

        Return listaDeColores

    End Function
End Class
