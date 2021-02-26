VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptCargaConsignaDet 
   Caption         =   "Carga de Rutas"
   ClientHeight    =   11010
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "AL_RptCargaConsignaDet.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   19420
   SectionData     =   "AL_RptCargaConsignaDet.dsx":08CA
End
Attribute VB_Name = "AL_RptCargaConsignaDet"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim SubtotalC, IvaC, TotalC

Private Sub Detail_Format()
    TotalC = TotalC + (DataSrc.Recordset!Surtido.Value * (DataSrc.Recordset!Precio.Value * (1 + DataSrc.Recordset!Iva.Value)))
    SubtotalC = SubtotalC + (DataSrc.Recordset!Surtido.Value * DataSrc.Recordset!Precio.Value)
    IvaC = IvaC + (DataSrc.Recordset!Surtido.Value * DataSrc.Recordset!Precio.Value * DataSrc.Recordset!Iva.Value)
End Sub

Private Sub GroupFooter1_Format()
    FldSubtotalC.Caption = FormatCurrency(SubtotalC, 2, vbTrue)
    FldIvaC.Caption = FormatCurrency(IvaC, 2, vbTrue)
    FldTotalC.Caption = FormatCurrency(TotalC, 2, vbTrue)
End Sub

