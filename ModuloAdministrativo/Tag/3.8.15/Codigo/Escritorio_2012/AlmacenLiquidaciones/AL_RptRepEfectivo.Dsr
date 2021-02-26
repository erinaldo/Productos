VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptRepEfectivo 
   Caption         =   "Efectivo y Documentos"
   ClientHeight    =   11430
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "AL_RptRepEfectivo.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20161
   SectionData     =   "AL_RptRepEfectivo.dsx":08CA
End
Attribute VB_Name = "AL_RptRepEfectivo"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public DescripcionAgrupacion As String
Public TipoReporte As Integer

Dim Pagina

Private Sub ActiveReport_ReportStart()

    Screen.MousePointer = vbDefault
           
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
    
    If TipoReporte = 3 Then
        GrpHdFamilia.Visible = False
        GrpFtFamilia.Visible = False
    End If
    
    If TipoReporte = 1 Then
        GrpFtAgrupacion.Visible = False
    End If
    
    
End Sub

Private Sub GrpFtAgrupacion_Format()

    'LabSubtotalAgrupacion.Caption = "Totales por " & DescripcionAgrupacion
    
    If TipoReporte = 3 Then
        FldFtAgrupacion.Text = DescripcionAgrupacion
    End If
    
End Sub

Private Sub GrpHdAgrupacion_Format()

    On Error Resume Next

    FldRuta.Text = DataSrc.Recordset.Fields(1).Value & " - " & DataSrc.Recordset.Fields(2).Value
    
    LabAgrupacion.Caption = DescripcionAgrupacion & ":"
    
End Sub

Private Sub PageFooter_Format()

    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
    
End Sub

Private Sub PageHeader_Format()
On Error Resume Next
    EtqC01.Caption = Etiqueta01: EtqC02.Caption = Etiqueta02
End Sub
