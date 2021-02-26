VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptCarga 
   Caption         =   "Carga de Rutas"
   ClientHeight    =   11490
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   19080
   Icon            =   "AL_RptCarga.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33655
   _ExtentY        =   20267
   SectionData     =   "AL_RptCarga.dsx":08CA
End
Attribute VB_Name = "AL_RptCarga"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina

Private Sub ActiveReport_Activate()
    Set SubRptDetail.object = New AL_RptCargaDet
    Set SubRptDevMala.object = New AL_RptTipoMerma
End Sub

Private Sub ActiveReport_ReportStart()
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
End Sub

Private Sub GroupFooter1_Format()
    AL_Liquidacion.DetalleSurtidos True, 1, True
    If Not Rs.EOF Then
        SubRptDetail.object.DataSrc.DataSourceName = Cnn
        SubRptDetail.object.DataSrc.Recordset = Rs
    End If
    
    StrCmd = "execute sel_TipoMerma 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    If Not RsC.EOF Then
        SubRptDevMala.object.DataSrc.DataSourceName = Cnn
        SubRptDevMala.object.DataSrc.Recordset = RsC
    End If
End Sub

Private Sub PageFooter_Format()
    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
End Sub

