VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptPedido 
   Caption         =   "Imprimir Pedido"
   ClientHeight    =   11460
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "AL_RptPedido.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20214
   SectionData     =   "AL_RptPedido.dsx":08CA
End
Attribute VB_Name = "AL_RptPedido"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina, STotal, CReg, Total

Private Sub ActiveReport_ReportStart()
    Printer.RenderMode = 1
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
    STotal = 0
End Sub

Private Sub Detail_Format()
    STotal = STotal + DataSrc.Recordset.Fields(19).Value
End Sub

Private Sub GroupFooter1_Format()
Dim StrCantidad As Long, Str As Long

    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
    
    StrCmd = "select .dbo.fn_NumeroLetra(" & CDbl(STotal) & ")"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    If Not RsC.EOF Then
        LblCantidadConLetra.Caption = RsC.Fields(0)
    End If
    LblCantidadConLetra.Visible = True
    LblLetraPago.Caption = FormatNumber(Total, 2) & " PAGO EN UNA SOLA EXHIBICIÓN."
End Sub

