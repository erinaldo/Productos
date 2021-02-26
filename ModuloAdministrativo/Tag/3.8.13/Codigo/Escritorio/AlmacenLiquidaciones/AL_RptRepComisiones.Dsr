VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptRepComisiones 
   Caption         =   "Cálculo de Comisiones"
   ClientHeight    =   11430
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "AL_RptRepComisiones.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20161
   SectionData     =   "AL_RptRepComisiones.dsx":08CA
End
Attribute VB_Name = "AL_RptRepComisiones"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public DescripcionAgrupacion As String

Dim Pagina

Dim SubTotalContadoKlts, TotalContadoRutaKlts, TotalContadoKlts
Dim SubTotalCreditoKlts, TotalCreditoRutaKlts, TotalCreditoKlts

Private Sub ActiveReport_ReportStart()

    Screen.MousePointer = vbDefault
         
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
    
    SubTotalContadoKlts = 0
    SubTotalCreditoKlts = 0
    
    TotalContadoRutaKlts = 0
    TotalCreditoRutaKlts = 0

    TotalContadoKlts = 0
    TotalCreditoKlts = 0

End Sub

Private Sub Detail_Format()

    FldContadoKlts.Text = Format(FldContado.Text * DataSrc.Recordset.Fields(3).Value, "#,##0.00")
    FldCreditoKlts.Text = Format(FldCredito.Text * DataSrc.Recordset.Fields(3).Value, "#,##0.00")

    SubTotalContadoKlts = SubTotalContadoKlts + (FldContado.Text * DataSrc.Recordset.Fields(3).Value)
    SubTotalCreditoKlts = SubTotalCreditoKlts + (FldCredito.Text * DataSrc.Recordset.Fields(3).Value)

End Sub

Private Sub GrpFtFamilia_Format()

    FldSubtotalContadoKlts.Text = Format(SubTotalContadoKlts, "#,##0.00")
    FldSubtotalCreditoKlts.Text = Format(SubTotalCreditoKlts, "#,##0.00")

    TotalContadoRutaKlts = TotalContadoRutaKlts + SubTotalContadoKlts
    TotalCreditoRutaKlts = TotalCreditoRutaKlts + SubTotalCreditoKlts

    SubTotalContadoKlts = 0
    SubTotalCreditoKlts = 0

End Sub

Private Sub GrpFtRuta_Format()

    LabSubtotalAgrupacion.Caption = "Subtotales por " & DescripcionAgrupacion

    FldTotalContadoRutaKlts.Text = Format(TotalContadoRutaKlts, "#,###,##0.00")
    FldTotalCreditoRutaKlts.Text = Format(TotalCreditoRutaKlts, "#,###,##0.00")
    
    TotalContadoKlts = TotalContadoKlts + TotalContadoRutaKlts
    TotalCreditoKlts = TotalCreditoKlts + TotalCreditoRutaKlts
    
    TotalContadoRutaKlts = 0
    TotalCreditoRutaKlts = 0
    
End Sub

Private Sub GrpHdRuta_Format()

    On Error Resume Next

    FldRuta.Text = DataSrc.Recordset.Fields(1).Value & " - " & DataSrc.Recordset.Fields(2).Value
    
    LabAgrupacion.Caption = DescripcionAgrupacion & ":"
    
End Sub

Private Sub PageFooter_Format()

    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
    
End Sub

Private Sub ReportFooter_Format()

    FldTotalContadoKlts.Text = Format(TotalContadoKlts, "#,###,##0.00")
    FldTotalCreditoKlts.Text = Format(TotalCreditoKlts, "#,###,##0.00")

End Sub

