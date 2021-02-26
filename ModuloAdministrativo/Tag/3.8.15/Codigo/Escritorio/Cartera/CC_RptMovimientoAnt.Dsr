VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} CC_RptMovimientoAnt 
   Caption         =   "Reporte de Movimientos del Anticipo"
   ClientHeight    =   11460
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "CC_RptMovimientoAnt.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20214
   SectionData     =   "CC_RptMovimientoAnt.dsx":08CA
End
Attribute VB_Name = "CC_RptMovimientoAnt"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina, EtqCA

Private Sub ActiveReport_ReportStart()
    LblFechaImpresion.Caption = "Usuario: " & Usuario & ". " & Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
End Sub

Private Sub GroupFooter5_Format()
    LblSubTotal.Caption = "Total " & EtqCA
End Sub

Private Sub GroupHeader5_Format()
    EtqCA = DataSrc.Recordset!CargoAbono
End Sub

Private Sub PageFooter_Format()
    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
End Sub

