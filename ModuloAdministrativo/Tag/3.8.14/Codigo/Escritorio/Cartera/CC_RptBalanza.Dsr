VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} CC_RptBalanza 
   Caption         =   "Reporte de Balanza de Clientes"
   ClientHeight    =   11490
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   19080
   Icon            =   "CC_RptBalanza.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33655
   _ExtentY        =   20267
   SectionData     =   "CC_RptBalanza.dsx":08CA
End
Attribute VB_Name = "CC_RptBalanza"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina, Saldo, TSaldo

Private Sub ActiveReport_Activate()
    Saldo = 0: TSaldo = 0
End Sub

Private Sub ActiveReport_ReportStart()
    LblFechaImpresion.Caption = "Usuario: " & Usuario & ". " & Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
End Sub

Private Sub Detail_Format()
'    LblSaldo.Caption = FormatNumber(DataSrc.Recordset!Inicial + DataSrc.Recordset!Cargos - DataSrc.Recordset!Abonos, 2, vbTrue)
'    TSaldo = TSaldo + DataSrc.Recordset!Inicial + DataSrc.Recordset!Cargos - DataSrc.Recordset!Abonos
End Sub

Private Sub PageFooter_Format()
    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
End Sub

Private Sub ReportFooter_Format()
'    LblTSaldo.Caption = FormatNumber(TSaldo, 2, vbTrue)
End Sub
