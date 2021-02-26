VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptRepModeloOrienteES 
   Caption         =   "Reporte de Entradas y Salidas (Modelo de Oriente)"
   ClientHeight    =   11460
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "AL_RptRepModeloOrienteES.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20214
   SectionData     =   "AL_RptRepModeloOrienteES.dsx":08CA
End
Attribute VB_Name = "AL_RptRepModeloOrienteES"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina

Private Sub ActiveReport_ReportStart()

    Screen.MousePointer = vbDefault
        
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
    
End Sub

Private Sub Detail_Format()
Dim Total As Double

    If IsNumeric(IdProd1.Text) Then
'        IdProd30.Text = FormatNumber(IdProd30.Text, 0)
'        IdProd31.Text = FormatNumber(IdProd31.Text, 0)
'        IdProd32.Text = FormatNumber(IdProd32.Text, 0)
'        IdProd33.Text = FormatNumber(IdProd33.Text, 0)
'        IdProd34.Text = FormatNumber(IdProd34.Text, 0)
'        IdProd35.Text = FormatNumber(IdProd35.Text, 0)
'        IdProd36.Text = FormatNumber(IdProd36.Text, 0)
        
        Total = CDbl(IdProd1.Text) + CDbl(IdProd2.Text) + CDbl(IdProd3.Text) + CDbl(IdProd4.Text) + CDbl(IdProd5.Text) + CDbl(IdProd6.Text) + CDbl(IdProd7.Text) + CDbl(IdProd8.Text) + CDbl(IdProd9.Text)
        Total = Total + CDbl(IdProd10.Text) + CDbl(IdProd11.Text) + CDbl(IdProd12.Text) + CDbl(IdProd13.Text) + CDbl(IdProd14.Text) + CDbl(IdProd15.Text) + CDbl(IdProd16.Text) + CDbl(IdProd17.Text) + CDbl(IdProd18.Text) + CDbl(IdProd19.Text)
        Total = Total + CDbl(IdProd20.Text) + CDbl(IdProd21.Text) + CDbl(IdProd22.Text) + CDbl(IdProd23.Text) + CDbl(IdProd24.Text) + CDbl(IdProd25.Text) + CDbl(IdProd26.Text) + CDbl(IdProd27.Text) + CDbl(IdProd28.Text) + CDbl(IdProd29.Text)
        Total = Total + CDbl(IdProd51.Text) + CDbl(IdProd52.Text) + CDbl(IdProd61.Text)
        LblTotales.Caption = FormatNumber(Total, 0, vbTrue)
    End If
End Sub

Private Sub PageFooter_Format()

    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
    
End Sub

