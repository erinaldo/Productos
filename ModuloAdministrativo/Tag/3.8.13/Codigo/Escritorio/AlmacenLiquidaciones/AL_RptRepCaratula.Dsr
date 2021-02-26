VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptRepCaratula 
   Caption         =   "Carátula de Venta"
   ClientHeight    =   11430
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "AL_RptRepCaratula.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20161
   SectionData     =   "AL_RptRepCaratula.dsx":08CA
End
Attribute VB_Name = "AL_RptRepCaratula"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public DescripcionAgrupacion As String

Dim Pagina

Private Sub ActiveReport_ReportStart()
On Error Resume Next
    Screen.MousePointer = vbDefault
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
    EtqC01.Caption = Etiqueta01: EtqC02.Caption = Etiqueta02
    EtqDB01.Caption = Etiqueta01: EtqDB02.Caption = Etiqueta02
    EtqDM01.Caption = Etiqueta01: EtqDM02.Caption = Etiqueta02
    EtqO01.Caption = Etiqueta01: EtqO02.Caption = Etiqueta02
    EtqV01.Caption = Etiqueta01: EtqV02.Caption = Etiqueta02
    EtqVC01.Caption = Etiqueta01: EtqVC02.Caption = Etiqueta02
    EtqVT01.Caption = Etiqueta01: EtqVT02.Caption = Etiqueta02
End Sub

Private Sub GrpFtRuta_Format()

    LabSubtotalAgrupacion.Caption = "Subtotales por " & DescripcionAgrupacion

End Sub

Private Sub GrpHdRuta_Format()

    On Error Resume Next

    FldRuta.Text = DataSrc.Recordset.Fields(1).Value & " - " & DataSrc.Recordset.Fields(2).Value
    
    LabAgrupacion.Caption = DescripcionAgrupacion & ":"
    
End Sub

Private Sub PageFooter_Format()

    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
    
End Sub
