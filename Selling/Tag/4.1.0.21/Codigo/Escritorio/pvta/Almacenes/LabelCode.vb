Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Printing

Namespace LabelPrinting

    Public Class LabelCode
        Private Tipo As Integer
        Private Clave As String
        Private Texto As String
        Private Codigo As String

        Public Sub New()
        End Sub


        Public Sub DrawLabelCode(ByVal gGraphics As Graphics, ByVal fntLabelFont As Font, ByVal fntCodeFont As Font, ByVal brshLabelBrush As Brush, ByVal rectLabel As RectangleF)
            Dim strTextoaImprimir As String = ""
            Dim strCodigoaImprimir As String = ""
            Dim strClaveaImprimir As String = ""

            Dim RectClave As New RectangleF(rectLabel.Location.X, rectLabel.Location.Y + fntCodeFont.Size + 2, rectLabel.Width, rectLabel.Height)
            Dim RectTexto As New RectangleF(RectClave.Location.X, RectClave.Location.Y + fntLabelFont.Size + 2, rectLabel.Width, rectLabel.Height)


            Dim Formato As New StringFormat
            Formato.Alignment = StringAlignment.Center


            strCodigoaImprimir = Codigo & vbLf
            gGraphics.DrawString(strCodigoaImprimir, fntCodeFont, brshLabelBrush, rectLabel, Formato)

            strClaveaImprimir = Clave & vbLf
            gGraphics.DrawString(strClaveaImprimir, fntLabelFont, brshLabelBrush, RectClave, Formato)

            strTextoaImprimir = Texto & vbLf
            gGraphics.DrawString(strTextoaImprimir, fntLabelFont, brshLabelBrush, RectTexto, Formato)

           

        End Sub

        Public Sub AddTexto(ByVal Linea As [String])
            Texto = Linea
        End Sub

        Public Sub AddClave(ByVal Linea As [String])
            Clave = Linea
        End Sub

        Public Sub AddCodigo(ByVal Linea As [String])
            Codigo = Linea
        End Sub

        Public Function GetClave() As String
            Return (Clave)
        End Function

        Public Function GetTexto() As String
            Return (Texto)
        End Function

        Public Function GetCodigo() As String
            Return (Codigo)
        End Function

    End Class

End Namespace
