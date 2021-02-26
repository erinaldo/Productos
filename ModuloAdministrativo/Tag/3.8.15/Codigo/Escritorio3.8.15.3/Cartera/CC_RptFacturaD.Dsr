VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} CC_RptFacturaD 
   Caption         =   "Imprimir Venta"
   ClientHeight    =   11460
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "CC_RptFacturaD.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20214
   SectionData     =   "CC_RptFacturaD.dsx":08CA
End
Attribute VB_Name = "CC_RptFacturaD"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina, STotal, CReg, Total

Private Sub ActiveReport_ReportStart()
    Printer.RenderMode = 1
    STotal = 0
End Sub

Private Sub Detail_Format()
    STotal = STotal + DataSrc.Recordset.Fields(6).Value
End Sub

Private Sub GroupFooter1_Format()
Dim StrCantidad As Long, Str As Long

    Pagina = Pagina + 1
    
    StrCmd = "select RouteADM.dbo.fn_NumeroLetra(" & CDbl(STotal) & ")"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    If Not RsC.EOF Then
        LblCantidadConLetra.Caption = RsC.Fields(0)
    End If
    LblCantidadConLetra.Visible = True
End Sub

Private Sub PageFooter_Format()
    LblLetraPago.Caption = FormatNumber(STotal, 2) & " PAGO EN UNA SOLA EXHIBICIÓN."
End Sub

