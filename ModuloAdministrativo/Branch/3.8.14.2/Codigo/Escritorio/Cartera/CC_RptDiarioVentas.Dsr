VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} CC_RptDiarioVentas 
   Caption         =   "Póliza de Diario de Ventas"
   ClientHeight    =   11490
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   19080
   Icon            =   "CC_RptDiarioVentas.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33655
   _ExtentY        =   20267
   SectionData     =   "CC_RptDiarioVentas.dsx":08CA
End
Attribute VB_Name = "CC_RptDiarioVentas"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina

Private Sub ActiveReport_ReportStart()
    LblFechaImpresion.Caption = "Usuario: " & Usuario & ". " & Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
End Sub

Private Sub Detail_Format()
    LblNomCuenta.Caption = IIf(Trim(DataSrc.Recordset.Fields(4).Value) <> "", DataSrc.Recordset.Fields(4).Value, DataSrc.Recordset.Fields(5).Value)
End Sub

Private Sub PageFooter_Format()
    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
End Sub

