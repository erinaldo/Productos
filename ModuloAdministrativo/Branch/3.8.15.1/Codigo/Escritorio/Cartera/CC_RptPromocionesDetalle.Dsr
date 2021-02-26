VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} CC_RptPromocionesDetalle 
   Caption         =   "Reporte de Detalle de la Aplicación de Acuerdos"
   ClientHeight    =   11460
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "CC_RptPromocionesDetalle.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20214
   SectionData     =   "CC_RptPromocionesDetalle.dsx":08CA
End
Attribute VB_Name = "CC_RptPromocionesDetalle"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina
Public IdPromo

Private Sub ActiveReport_ReportStart()
    LblFechaImpresion.Caption = "Usuario: " & Usuario & ". " & Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
End Sub

Private Sub PageFooter_Format()
    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
End Sub

Private Sub ReportHeader_Format()
    Dim RsGeneral As New ADODB.Recordset
    
    StrCmd = "execute sel_PromocionesRep " & IdPromo & ", 1"
    If RsGeneral.State Then RsGeneral.Close
    RsGeneral.Open StrCmd, Cnn
    If Not RsGeneral.EOF Then
        Set SubRepGeneral.object = New CC_RptPromocionesGeneral
        SubRepGeneral.object.DataSrc.DataSourceName = Cnn
        SubRepGeneral.object.DataSrc.Recordset = RsGeneral
    End If
End Sub
