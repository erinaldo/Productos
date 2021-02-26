VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptCargaSugerida 
   Caption         =   "Carga Sugerida de Rutas"
   ClientHeight    =   11490
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   19080
   Icon            =   "AL_RptCargaSugerida.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33655
   _ExtentY        =   20267
   SectionData     =   "AL_RptCargaSugerida.dsx":08CA
End
Attribute VB_Name = "AL_RptCargaSugerida"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina

Private Sub ActiveReport_ReportStart()
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
    EtqV01.Caption = Etiqueta01: EtqV02.Caption = Etiqueta02
    EtqC01.Caption = Etiqueta01: EtqC02.Caption = Etiqueta02
    EtqCa01.Caption = Etiqueta01: EtqCa02.Caption = Etiqueta02
    
'    Set SubRptDetail.object = New AL_RptLiquidacionDet
End Sub

Private Sub Detail_Format()
    FldCambios.Visible = IIf(DataSrc.Recordset!Cambios.Value = 0, False, True)
    FldCambiosK.Visible = IIf(DataSrc.Recordset!CambiosK.Value = 0, False, True)
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

