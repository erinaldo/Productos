VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} CC_RptAntiguedadDetalle 
   Caption         =   "Antiguedad de Saldos"
   ClientHeight    =   11460
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "CC_RptAntiguedadDetalle.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20214
   SectionData     =   "CC_RptAntiguedadDetalle.dsx":08CA
End
Attribute VB_Name = "CC_RptAntiguedadDetalle"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina, Saldo, GSaldo, Saldo0, Saldo30, Saldo45, Saldo60, Saldo120, Saldo999, TSaldo0, TSaldo30, TSaldo45, TSaldo60, TSaldo120, TSaldo999

Private Sub ActiveReport_ReportStart()
    LblFechaImpresion.Caption = "Usuario: " & Usuario & ". " & Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
    Saldo = 0: GSaldo = 0: Saldo0 = 0: Saldo30 = 0: Saldo45 = 0: Saldo60 = 0: Saldo120 = 0: Saldo999 = 0
End Sub

Private Sub Detail_Format()
Dim Periodo As Integer
    Periodo = 0
    InhabCampos
    FldFechaFact.Visible = True: FldFactura.Visible = True: ' fldfechavenc.Visible = True
    
    Select Case DataSrc.Recordset.Fields(10).Value
        
        Case -999999 To 0:
            Periodo = 0: Fld0.Visible = True
            If Not IsNull(DataSrc.Recordset.Fields(9).Value) Then
                Saldo0 = Saldo0 + CDbl(DataSrc.Recordset.Fields(9).Value)
                TSaldo0 = TSaldo0 + CDbl(DataSrc.Recordset.Fields(9).Value)
            End If
            Fld0.Text = FormatNumber(DataSrc.Recordset.Fields(9).Value, 2, vbTrue)
        
        Case 1 To 7:
            Periodo = 30: Fld30.Visible = True
            If Not IsNull(DataSrc.Recordset.Fields(9).Value) Then
                Saldo30 = Saldo30 + CDbl(DataSrc.Recordset.Fields(9).Value)
                TSaldo30 = TSaldo30 + CDbl(DataSrc.Recordset.Fields(9).Value)
            End If
            Fld30.Text = FormatNumber(DataSrc.Recordset.Fields(9).Value, 2, vbTrue)
        Case 8 To 15:
            Periodo = 45: Fld45.Visible = True
            If Not IsNull(DataSrc.Recordset.Fields(9).Value) Then
                Saldo45 = Saldo45 + CDbl(DataSrc.Recordset.Fields(9).Value)
                TSaldo45 = TSaldo45 + CDbl(DataSrc.Recordset.Fields(9).Value)
            End If
            Fld45.Text = FormatNumber(DataSrc.Recordset.Fields(9).Value, 2, vbTrue)
        Case 15 To 30:
            Periodo = 60: Fld60.Visible = True
            If Not IsNull(DataSrc.Recordset.Fields(9).Value) Then
                Saldo60 = Saldo60 + CDbl(DataSrc.Recordset.Fields(9).Value)
                TSaldo60 = TSaldo60 + CDbl(DataSrc.Recordset.Fields(9).Value)
            End If
            Fld60.Text = FormatNumber(DataSrc.Recordset.Fields(9).Value, 2, vbTrue)
        Case 30 To 60:
            Periodo = 120: Fld120.Visible = True
            If Not IsNull(DataSrc.Recordset.Fields(9).Value) Then
                Saldo120 = Saldo120 + CDbl(DataSrc.Recordset.Fields(9).Value)
                TSaldo120 = TSaldo120 + CDbl(DataSrc.Recordset.Fields(9).Value)
            End If
            Fld120.Text = FormatNumber(DataSrc.Recordset.Fields(9).Value, 2, vbTrue)
        Case Else
            Periodo = 999: Fld999.Visible = True
            If Not IsNull(DataSrc.Recordset.Fields(9).Value) Then
                Saldo999 = Saldo999 + CDbl(DataSrc.Recordset.Fields(9).Value)
                TSaldo999 = TSaldo999 + CDbl(DataSrc.Recordset.Fields(9).Value)
            End If
            Fld999.Text = FormatNumber(DataSrc.Recordset.Fields(9).Value, 2, vbTrue)
    End Select
    
    If Not IsNull(DataSrc.Recordset.Fields(9).Value) Then
        FldTotal.Text = FormatNumber(DataSrc.Recordset.Fields(9).Value, 2, vbTrue)
        Saldo = Saldo + DataSrc.Recordset.Fields(9).Value
        GSaldo = GSaldo + DataSrc.Recordset.Fields(9).Value
    End If
End Sub

Private Sub GroupFooter1_Format()
    FldSTotal.Text = FormatNumber(Saldo, 2, vbTrue)
    FldT0 = FormatNumber(Saldo0, 2, vbTrue)
    FldT30 = FormatNumber(Saldo30, 2, vbTrue): FldT45 = FormatNumber(Saldo45, 2, vbTrue)
    FldT60 = FormatNumber(Saldo60, 2, vbTrue): FldT120 = FormatNumber(Saldo120, 2, vbTrue)
    FldT999 = FormatNumber(Saldo999, 2, vbTrue)
    Saldo = 0: Saldo0 = 0: Saldo30 = 0: Saldo45 = 0: Saldo60 = 0: Saldo120 = 0: Saldo999 = 0
End Sub

Private Sub GroupHeader1_Format()
'    If DataSrc.Recordset.Fields(8).Value = 0 Then
'        Detail.Visible = False
'    Else
'        Detail.Visible = True
'    End If
End Sub

Private Sub PageFooter_Format()
    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
End Sub

Sub InhabCampos()
    Fld0.Visible = False
    Fld30.Visible = False: Fld45.Visible = False
    Fld60.Visible = False: Fld120.Visible = False: Fld999.Visible = False
    FldFechaFact.Visible = False: FldFactura.Visible = False: ' fldfechavenc.Visible = False
End Sub

Private Sub ReportFooter_Format()
    FldGTotal.Text = FormatNumber(GSaldo, 2, vbTrue)
    FldGT0.Text = FormatNumber(TSaldo0, 2, vbTrue)
    FldGT30.Text = FormatNumber(TSaldo30, 2, vbTrue)
    FldGT45.Text = FormatNumber(TSaldo45, 2, vbTrue)
    FldGT60.Text = FormatNumber(TSaldo60, 2, vbTrue)
    FldGT120.Text = FormatNumber(TSaldo120, 2, vbTrue)
    FldGT999.Text = FormatNumber(TSaldo999, 2, vbTrue)
End Sub
