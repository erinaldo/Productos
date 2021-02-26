VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} CC_RptVentasAlCobro 
   Caption         =   "Reporte de Ventas Al Cobro"
   ClientHeight    =   11460
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   16935
   Icon            =   "CC_RptVentasAlCobro.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   29871
   _ExtentY        =   20214
   SectionData     =   "CC_RptVentasAlCobro.dsx":08CA
End
Attribute VB_Name = "CC_RptVentasAlCobro"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public DescripcionAgrupacion As String
Dim Pagina

Private Sub ActiveReport_ReportStart()

    Screen.MousePointer = vbDefault
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
    
End Sub

Private Sub GrpHdFecha_Format()

    FldFecha.Text = Format(FldFecha.Text, ctFechaLarga)
    
End Sub

Private Sub PageFooter_Format()

    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
    
End Sub

