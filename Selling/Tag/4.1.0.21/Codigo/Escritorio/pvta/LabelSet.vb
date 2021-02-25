Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO

Namespace LabelPrinting
    Public Class LabelSet
        Inherits PrintDocument
        Public LabelFont As Font
        Public LabelCodeFont As Font
        Public LabelPaperSize As PaperSize


        Private LabelCodes As New Collection(Of LabelCode)()
        Private lssLabelSheetSettings As LabelSheetSettings
        Private NextLabel As Integer
        Private NextPage As Integer
        Private LastPage As Integer

        Public Sub New(ByVal tipoPapel As PaperSize, _
                     ByVal vertical As Boolean, _
                     ByVal anchoEtiqueta As Integer, _
                     ByVal altoEtiqueta As Integer, _
                     ByVal noColumnas As Integer, _
                     ByVal espacioColumnas As Integer, _
                     ByVal noFilas As Integer, _
                     ByVal espacioFilas As Integer, _
                     ByVal izqHoja As Integer, _
                     ByVal derHoja As Integer, _
                     ByVal arribaHoja As Integer, _
                     ByVal abajoHoja As Integer, _
                     ByVal izqEtiqueta As Integer, _
                     ByVal derEtiqueta As Integer, _
                     ByVal arribaEtiqueta As Integer, _
                     ByVal abajoEtiqueta As Integer)

            lssLabelSheetSettings = New LabelSheetSettings(tipoPapel, vertical, anchoEtiqueta, altoEtiqueta, noColumnas, espacioColumnas, noFilas, espacioFilas, izqHoja, derHoja, arribaHoja, abajoHoja, izqEtiqueta, derEtiqueta, arribaEtiqueta, abajoEtiqueta)

            Me.DefaultPageSettings = DirectCast(lssLabelSheetSettings, PageSettings)
        End Sub

        Public Sub AddLabelCode(ByVal NewLabel As LabelCode)
            LabelCodes.Add(NewLabel)
        End Sub

        Public Function GetLabels() As Collection(Of LabelCode)
            Return LabelCodes
        End Function

        ' OnBeginPrint - called when printing starts 
        Protected Overloads Overrides Sub OnBeginPrint(ByVal e As PrintEventArgs)
            MyBase.OnBeginPrint(e)
            MyBase.OnBeginPrint(e)
            NextPage = Me.PrinterSettings.FromPage
            NextPage = IIf((NextPage < 1), 1, NextPage)
            LastPage = Me.PrinterSettings.ToPage
            NextLabel = (NextPage - 1) * Me.lssLabelSheetSettings.LabelsPerSheet
        End Sub

        ' OnPrintPage - called when printing needs to be done... 
        Protected Overloads Overrides Sub OnPrintPage(ByVal e As PrintPageEventArgs)
            MyBase.OnPrintPage(e)
            Dim x As Single = 0
            Dim y As Single = 0
            Dim w As Single = 0
            Dim h As Single = 0
            Dim LastLabel As Integer = LabelCodes.Count
            Dim CurrentColumn As Integer
            Dim CurrentRow As Integer

            Dim rectLabel As RectangleF
            Dim lblLabel As LabelCode

            w = lssLabelSheetSettings.LabelWidth - (lssLabelSheetSettings.LabelMargins.Left + lssLabelSheetSettings.LabelMargins.Right)
            h = lssLabelSheetSettings.LabelHeight - (lssLabelSheetSettings.LabelMargins.Top + lssLabelSheetSettings.LabelMargins.Bottom)

            For CurrentRow = 0 To lssLabelSheetSettings.LabelRows - 1
                For CurrentColumn = 0 To lssLabelSheetSettings.LabelColumns - 1
                    If NextLabel < LastLabel Then
                        lblLabel = LabelCodes(NextLabel)

                        x = lssLabelSheetSettings.Margins.Left
                        ' 1/100in
                        y = lssLabelSheetSettings.Margins.Top
                        ' 1/100in
                        x = x + (CurrentColumn * (lssLabelSheetSettings.LabelWidth + lssLabelSheetSettings.LabelColumnSpacing)) + lssLabelSheetSettings.LabelMargins.Left
                        y = y + (CurrentRow * (lssLabelSheetSettings.LabelHeight + lssLabelSheetSettings.LabelRowSpacing)) + lssLabelSheetSettings.LabelMargins.Top

                        rectLabel = New RectangleF(New PointF(x, y), New SizeF(w, h))

                        lblLabel.DrawLabelCode(e.Graphics, LabelFont, LabelCodeFont, Brushes.Black, rectLabel)

                        NextLabel = NextLabel + 1
                    End If
                Next
            Next
            NextPage += 1
            e.HasMorePages = IIf((LastPage = 0), (NextLabel < LabelCodes.Count), (NextPage <= LastPage))
        End Sub
    End Class
End Namespace
