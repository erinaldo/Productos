Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing.Printing

Namespace LabelPrinting
    Class LabelSheetSettings
        Inherits System.Drawing.Printing.PageSettings
        Public LabelWidth As Integer
        ' Label width hundredths of an inch
        Public LabelHeight As Integer
        ' Label height hundredths of an inch
        Public LabelColumns As Integer
        ' Number of label columns
        Public LabelColumnSpacing As Integer
        ' Label column spacing hundredths of an inch
        Public LabelRows As Integer
        ' Number of label rows
        Public LabelRowSpacing As Integer
        ' Label row spacing hundredths of an inch
        Public LabelsPerSheet As Integer
        ' No. of labels on a sheet
        Public LabelMargins As Margins
        ' Label margin hundredths of an inch


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
            MyBase.New()
            ConfigureSettings(tipoPapel, vertical, anchoEtiqueta, altoEtiqueta, noColumnas, espacioColumnas, noFilas, espacioFilas, izqHoja, derHoja, arribaHoja, abajoHoja, izqEtiqueta, derEtiqueta, arribaEtiqueta, abajoEtiqueta)
        End Sub


        Private Sub ConfigureSettings( _
                     ByVal tipoPapel As PaperSize, _
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

            Me.PaperSize = tipoPapel
            Me.Landscape = vertical
            Me.LabelWidth = anchoEtiqueta
            Me.LabelHeight = altoEtiqueta
            Me.LabelColumns = noColumnas
            Me.LabelColumnSpacing = espacioColumnas
            Me.LabelRows = noFilas
            Me.LabelRowSpacing = espacioFilas
            Me.Margins = New Margins(izqHoja, derHoja, arribaHoja, abajoHoja)
            Me.LabelMargins = New Margins(izqEtiqueta, derEtiqueta, arribaEtiqueta, abajoEtiqueta)
            Me.LabelsPerSheet = Me.LabelColumns * Me.LabelRows
        End Sub

    End Class
End Namespace

