VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptLiquidacionSaldos 
   Caption         =   "Liquidación de Rutas"
   ClientHeight    =   11430
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "AL_RptLiquidacionSaldos.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20161
   SectionData     =   "AL_RptLiquidacionSaldos.dsx":08CA
End
Attribute VB_Name = "AL_RptLiquidacionSaldos"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub Detail_Format()
    If DataSrcS.Recordset!IdTipoSaldo.Value = "EF" Then
        LblDebe.Caption = IIf(DataSrcS.Recordset!SaldoFinal.Value < 0, "Debe", "Haber")
    Else
        LblDebe.Caption = ""
    End If
End Sub
