VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} CC_RptBalanzaDetallada 
   Caption         =   "Reporte de Balanza de Clientes Detallada"
   ClientHeight    =   11460
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "CC_RptBalanzaDetallada.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33655
   _ExtentY        =   20267
   SectionData     =   "CC_RptBalanzaDetallada.dsx":08CA
End
Attribute VB_Name = "CC_RptBalanzaDetallada"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina, Saldo, TSaldo, Inicial, TInicial

Private Sub ActiveReport_Activate()
    Saldo = 0: TSaldo = 0: Inicial = 0: TInicial = 0
End Sub

Private Sub ActiveReport_ReportStart()
    LblFechaImpresion.Caption = "Usuario: " & Usuario & ". " & Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
End Sub

Private Sub Detail_Format()
    Saldo = Saldo + DataSrc.Recordset!Cargos - DataSrc.Recordset!Abonos
    LblSaldo.Caption = FormatNumber(Saldo, 2, vbTrue)
'    TSaldo = TSaldo + DataSrc.Recordset!Inicial + DataSrc.Recordset!Cargos - DataSrc.Recordset!Abonos
End Sub

Private Sub GroupFooter1_Format()
    LblSubInicial.Caption = FormatNumber(Inicial, 2, vbTrue)
    LblSubSaldo.Caption = FormatNumber(Saldo, 2, vbTrue)
    TSaldo = TSaldo + Saldo
    Inicial = 0: Saldo = 0
End Sub

Private Sub GroupHeader1_Format()
    Inicial = DataSrc.Recordset!Inicial
    TInicial = TInicial + DataSrc.Recordset!Inicial
    Saldo = Inicial
End Sub

Private Sub PageFooter_Format()
    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
End Sub

Private Sub ReportFooter_Format()
    LblTotInicial.Caption = FormatNumber(TInicial, 2, vbTrue)
    LblTSaldo.Caption = FormatNumber(TSaldo, 2, vbTrue)
End Sub
