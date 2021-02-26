VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptPreciosResumen 
   Caption         =   "Resumen de Precios"
   ClientHeight    =   11460
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "AL_RptPreciosResumen.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33655
   _ExtentY        =   20267
   SectionData     =   "AL_RptPreciosResumen.dsx":08CA
End
Attribute VB_Name = "AL_RptPreciosResumen"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina

Private Sub ActiveReport_Activate()
    Set SubRptDetail.object = New AL_RptPreciosResumenDet
End Sub

Private Sub ActiveReport_ReportStart()
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
End Sub

Private Sub Detail_Format()
    Dim Opc As Integer

    Select Case IdTipo.DataValue
        Case "BA": Opc = 1
        Case "CL": Opc = 2
        Case "RU": Opc = 3
    End Select

    StrCmd = "execute sel_PreciosListasRep " & IdCedis & ", " & Opc
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    
    If Not RsC.EOF Then
        SubRptDetail.object.DataSrc.DataSourceName = Cnn
        SubRptDetail.object.DataSrc.Recordset = RsC
    End If

End Sub

Private Sub PageFooter_Format()
    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
End Sub

