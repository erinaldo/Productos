Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO

Namespace PickingPrinting
    Public Class PickingSet
        Inherits PrintDocument
        Public PickingFont As Font
        Public PickingFontBold As Font
        'Public LabelCodeFont As Font
        'Public PickingPaperSize As PaperSize


        Private PickingSheets As New Collection(Of PickingSheet)()
        Private lssPickingSheetSettings As PickingSheetSettings
        Private NextSheet As Integer
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

            lssPickingSheetSettings = New PickingSheetSettings(tipoPapel, vertical, anchoEtiqueta, altoEtiqueta, noColumnas, espacioColumnas, noFilas, espacioFilas, izqHoja, derHoja, arribaHoja, abajoHoja, izqEtiqueta, derEtiqueta, arribaEtiqueta, abajoEtiqueta)

            Me.DefaultPageSettings = DirectCast(lssPickingSheetSettings, PageSettings)
        End Sub

        Public Sub AddPickingSheet(ByVal NewSheet As PickingSheet)
            PickingSheets.Add(NewSheet)
        End Sub

        Public Function GetSheets() As Collection(Of PickingSheet)
            Return PickingSheets
        End Function

        ' OnBeginPrint - called when printing starts 
        Protected Overloads Overrides Sub OnBeginPrint(ByVal e As PrintEventArgs)
            MyBase.OnBeginPrint(e)
            MyBase.OnBeginPrint(e)
            NextPage = Me.PrinterSettings.FromPage
            NextPage = IIf((NextPage < 1), 1, NextPage)
            LastPage = Me.PrinterSettings.ToPage
            NextSheet = (NextPage - 1) * Me.lssPickingSheetSettings.LabelsPerSheet
        End Sub

        ' OnPrintPage - called when printing needs to be done... 
        Protected Overloads Overrides Sub OnPrintPage(ByVal e As PrintPageEventArgs)
            MyBase.OnPrintPage(e)
            Dim x As Single = 0
            Dim y As Single = 0
            Dim w As Single = 0
            Dim h As Single = 0
            Dim LastSheet As Integer = PickingSheets.Count
            Dim CurrentColumn As Integer
            Dim CurrentRow As Integer

            Dim rectPicking As RectangleF
            Dim HojaPicking As PickingSheet

            w = lssPickingSheetSettings.LabelWidth - (lssPickingSheetSettings.LabelMargins.Left + lssPickingSheetSettings.LabelMargins.Right)
            h = lssPickingSheetSettings.LabelHeight - (lssPickingSheetSettings.LabelMargins.Top + lssPickingSheetSettings.LabelMargins.Bottom)

            For CurrentRow = 0 To lssPickingSheetSettings.LabelRows - 1
                For CurrentColumn = 0 To lssPickingSheetSettings.LabelColumns - 1
                    If NextSheet < LastSheet Then
                        HojaPicking = PickingSheets(NextSheet)

                        x = lssPickingSheetSettings.Margins.Left
                        ' 1/100in
                        y = lssPickingSheetSettings.Margins.Top
                        ' 1/100in
                        x = x + (CurrentColumn * (lssPickingSheetSettings.LabelWidth + lssPickingSheetSettings.LabelColumnSpacing)) + lssPickingSheetSettings.LabelMargins.Left
                        y = y + (CurrentRow * (lssPickingSheetSettings.LabelHeight + lssPickingSheetSettings.LabelRowSpacing)) + lssPickingSheetSettings.LabelMargins.Top

                        rectPicking = New RectangleF(New PointF(x, y), New SizeF(w, h))

                        HojaPicking.DrawPickingSheet(e.Graphics, PickingFont, PickingFontBold, Brushes.Black, rectPicking)

                        NextSheet = NextSheet + 1
                    End If
                Next
            Next
            NextPage += 1
            e.HasMorePages = IIf((LastPage = 0), (NextSheet < PickingSheets.Count), (NextPage <= LastPage))
        End Sub
    End Class
End Namespace
