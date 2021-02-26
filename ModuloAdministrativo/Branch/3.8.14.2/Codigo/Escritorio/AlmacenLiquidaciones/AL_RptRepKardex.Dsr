VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptRepKardex 
   Caption         =   "Kardex de Inventario de Productos"
   ClientHeight    =   11430
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "AL_RptRepKardex.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20161
   SectionData     =   "AL_RptRepKardex.dsx":08CA
End
Attribute VB_Name = "AL_RptRepKardex"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public DescripcionAgrupacion As String
Public TipoReporte As String
Public NivelReporte As Integer

Dim Pagina

Private Sub ActiveReport_ReportStart()

    Screen.MousePointer = vbDefault
        
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
    
    If NivelReporte = 5 Or NivelReporte = 6 Or NivelReporte = 7 Or NivelReporte = 8 _
        Or NivelReporte = 13 Or NivelReporte = 14 Or NivelReporte = 15 Or NivelReporte = 16 Then
        GrpHdFecha.Visible = False
        GrpFtFecha.Visible = False
    End If
    
End Sub

Private Sub GrpFtRuta_Format()

    LabSubtotalAgrupacion.Caption = "Subtotales por " & DescripcionAgrupacion
    
End Sub

Private Sub GrpHdFecha_Format()

    FldFecha.Text = Format(FldFecha.Text, ctFechaLarga)
    
End Sub

Private Sub GrpHdRuta_Format()

    On Error Resume Next

    FldRuta.Text = DataSrc.Recordset!IdAgrupa.Value & " - " & DataSrc.Recordset!DescripcionAgrupa.Value
    
    LabAgrupacion.Caption = DescripcionAgrupacion & ":"
    
End Sub

Private Sub PageFooter_Format()

    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
    
End Sub

