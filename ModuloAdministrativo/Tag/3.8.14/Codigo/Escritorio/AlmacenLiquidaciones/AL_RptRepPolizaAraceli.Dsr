VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptRepPolizaAraceli 
   Caption         =   "Póliza"
   ClientHeight    =   11430
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "AL_RptRepPolizaAraceli.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20161
   SectionData     =   "AL_RptRepPolizaAraceli.dsx":08CA
End
Attribute VB_Name = "AL_RptRepPolizaAraceli"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina

Private Sub ActiveReport_Activate()
    Set SubRptGeneral.object = New AL_RptRepPolizaAraceliGeneral
    Set SubRptVentaPG.object = New AL_RptRepPolizaAraceliVentaPG
    Set SubRptSaldosV.object = New AL_RptRepPolizaAraceliSaldosVendedores
    Set SubRptVentasCredito.object = New AL_RptRepPolizaAraceliVentaCredito
End Sub

Private Sub ActiveReport_ReportStart()

    Screen.MousePointer = vbDefault
        
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
    
End Sub

Private Sub GrpFtFecha_Format()
On Error Resume Next

    StrCmd = "execute sel_PolizaAraceli " & IdCedis & ", '" & FormatDate(FldFechaPoliza.Text) & "',  '" & FormatDate(FldFechaPoliza.Text) & "', 1"
    If Rs2.State Then Rs2.Close
    Rs2.Open StrCmd, Cnn
    If Not Rs2.EOF Then
        SubRptGeneral.Visible = True
        SubRptGeneral.object.DataSrc.DataSourceName = Cnn
        SubRptGeneral.object.DataSrc.Recordset = Rs2
    Else
        SubRptGeneral.Visible = False
    End If

    StrCmd = "execute sel_PolizaAraceli " & IdCedis & ", '" & FormatDate(FldFechaPoliza.Text) & "',  '" & FormatDate(FldFechaPoliza.Text) & "', 2"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    If Not RsC.EOF Then
        SubRptVentaPG.Visible = True
        SubRptVentaPG.object.DataSrc.DataSourceName = Cnn
        SubRptVentaPG.object.DataSrc.Recordset = RsC
    Else
        SubRptVentaPG.Visible = False
    End If

    StrCmd = "execute sel_PolizaAraceli " & IdCedis & ", '" & FormatDate(FldFechaPoliza.Text) & "',  '" & FormatDate(FldFechaPoliza.Text) & "', 3"
    If RsC2.State Then RsC2.Close
    RsC2.Open StrCmd, Cnn
    If Not RsC2.EOF Then
        SubRptSaldosV.Visible = True
        SubRptSaldosV.object.DataSrc.DataSourceName = Cnn
        SubRptSaldosV.object.DataSrc.Recordset = RsC2
    Else
        SubRptSaldosV.Visible = False
    End If

    StrCmd = "execute sel_PolizaAraceli " & IdCedis & ", '" & FormatDate(FldFechaPoliza.Text) & "',  '" & FormatDate(FldFechaPoliza.Text) & "', 4"
    If Rs3.State Then Rs3.Close
    Rs3.Open StrCmd, Cnn
    If Not Rs3.EOF Then
        SubRptVentasCredito.Visible = True
        SubRptVentasCredito.object.DataSrc.DataSourceName = Cnn
        SubRptVentasCredito.object.DataSrc.Recordset = Rs3
    Else
        SubRptVentasCredito.Visible = False
    End If

End Sub

Private Sub GrpHdFecha_Format()

    FldFecha.Text = Format(FldFecha.Text, ctFechaLarga)

End Sub

Private Sub PageFooter_Format()

    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
    
End Sub

