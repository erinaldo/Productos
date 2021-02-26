VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} CC_RptFacturaAraceli 
   Caption         =   "Factura"
   ClientHeight    =   11010
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   15240
   Icon            =   "CC_RptFacturaAraceli.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   26882
   _ExtentY        =   19420
   SectionData     =   "CC_RptFacturaAraceli.dsx":08CA
End
Attribute VB_Name = "CC_RptFacturaAraceli"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina, STotal, CReg

Private Sub ActiveReport_ReportStart()
    Printer.RenderMode = 1
    STotal = 0
End Sub

Private Sub Detail_Format()
    STotal = STotal + DataSrc.Recordset.Fields(6).Value
End Sub

Private Sub PageFooter_Format()
Dim StrCantidad As Long, Str As Long

    Pagina = Pagina + 1
 
    StrCmd = "select .dbo.fn_NumeroLetra(" & CDbl(STotal) & ")"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    If Not RsC.EOF Then
        LblCantidadConLetra.Caption = RsC.Fields(0)
    End If
End Sub

Private Sub ReportFooter_Format()
    LblCantidadConLetra.Visible = True
End Sub

