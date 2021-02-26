VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptRepSaldosVendedor 
   Caption         =   "Saldos del Vendedor"
   ClientHeight    =   11430
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "AL_RptRepSaldosVendedor.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20161
   SectionData     =   "AL_RptRepSaldosVendedor.dsx":08CA
End
Attribute VB_Name = "AL_RptRepSaldosVendedor"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
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

Private Sub ReportFooter_Format()
    'LblGranTotal.Caption = FormatCurrency(CDbl(FldTCredito.Text) + CDbl(FldTContado.Text), 2, vbTrue)
End Sub
