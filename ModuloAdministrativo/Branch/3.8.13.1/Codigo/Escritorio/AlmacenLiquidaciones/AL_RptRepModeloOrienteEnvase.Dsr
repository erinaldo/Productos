VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptRepModeloOrienteEnvase 
   Caption         =   "Reporte de Envase (Modelo de Oriente)"
   ClientHeight    =   11430
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "AL_RptRepModeloOrienteEnvase.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20161
   SectionData     =   "AL_RptRepModeloOrienteEnvase.dsx":08CA
End
Attribute VB_Name = "AL_RptRepModeloOrienteEnvase"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina, STotal

Private Sub ActiveReport_ReportStart()

    Screen.MousePointer = vbDefault
        
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
    
End Sub

Private Sub Detail_Format()
    If IsNumeric(IdProd30.Text) Then
        STotal = 0
        IdProd30.Text = FormatNumber(IdProd30.Text, 0)
        IdProd31.Text = FormatNumber(IdProd31.Text, 0)
        IdProd32.Text = FormatNumber(IdProd32.Text, 0)
        IdProd33.Text = FormatNumber(IdProd33.Text, 0)
        IdProd34.Text = FormatNumber(IdProd34.Text, 0)
        IdProd35.Text = FormatNumber(IdProd35.Text, 0)
        IdProd36.Text = FormatNumber(IdProd36.Text, 0)
        STotal = STotal + DataSrc.Recordset.Fields(7).Value + DataSrc.Recordset.Fields(8).Value + DataSrc.Recordset.Fields(9).Value
        STotal = STotal + DataSrc.Recordset.Fields(10).Value + DataSrc.Recordset.Fields(11).Value + DataSrc.Recordset.Fields(12).Value
        STotal = STotal + DataSrc.Recordset.Fields(13).Value '+ DataSrc.Recordset.Fields(9).Value '+ DataSrc.Recordset.Fields(4).Value
        Totales.Text = FormatNumber(STotal, 0)
    Else
        Totales.Text = "TOTALES"
    End If
    
End Sub

Private Sub PageFooter_Format()

    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
    
End Sub

