VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptCargaSugeridaCP 
   Caption         =   "Carga Sugerida de Rutas"
   ClientHeight    =   11430
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "AL_RptCargaSugeridaCP.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20161
   SectionData     =   "AL_RptCargaSugeridaCP.dsx":08CA
End
Attribute VB_Name = "AL_RptCargaSugeridaCP"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina

Private Sub ActiveReport_ReportStart()
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
    EtqV01.Caption = "Cajas": EtqV02.Caption = "Piezas"
    EtqC01.Caption = "Cajas": EtqC02.Caption = "Piezas"
    EtqCa01.Caption = "Cajas": EtqCa02.Caption = "Piezas"
    
'    Set SubRptDetail.object = New AL_RptLiquidacionDet
End Sub

Private Sub Detail_Format()
    FldCambios.Visible = IIf(CDbl(DataSrc.Recordset!Cambios.Value) = CDbl(DataSrc.Recordset.Fields(5)), False, True)
    FldCambiosK.Visible = IIf(CDbl(DataSrc.Recordset!CambiosK.Value) = CDbl(DataSrc.Recordset.Fields(8)), False, True)
End Sub

Private Sub GroupFooter1_Format()
'    StrCmd = "execute sel_SurtidosVendedores " & IdCedis & ", " & IdSurtido
'    If Rs.State Then Rs.Close
'    Rs.Open StrCmd, Cnn
'
'    If Not Rs.EOF Then
'        SubRptDetail.object.DataSrc.DataSourceName = Cnn
'        SubRptDetail.object.DataSrc.Recordset = Rs
'    End If
End Sub

Private Sub PageFooter_Format()
    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
End Sub

