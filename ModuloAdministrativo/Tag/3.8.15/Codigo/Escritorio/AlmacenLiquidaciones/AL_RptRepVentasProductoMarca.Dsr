VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptRepVentasProductoMarca 
   Caption         =   "Reporte de Ventas por Producto a Precio Base"
   ClientHeight    =   11430
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "AL_RptRepVentasProductoMarca.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20161
   SectionData     =   "AL_RptRepVentasProductoMarca.dsx":08CA
End
Attribute VB_Name = "AL_RptRepVentasProductoMarca"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public DescripcionAgrupacion As String
Dim Pagina

Private Sub ActiveReport_Activate()
    Set SubRptCuentaComprobada.object = New AL_RptRepCuentaComprobada
End Sub

Private Sub ActiveReport_ReportStart()

    Screen.MousePointer = vbDefault
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
    
End Sub

Private Sub GrpFtFecha_Format()
        
    StrCmd = "execute sel_CuentaComprobada " & IdCedis & ", '" & FormatDate(FldFecha2.Text) & "', '" & FormatDate(FldFecha2.Text) & "', 2"
    If RsC2.State Then RsC2.Close
    RsC2.Open StrCmd, Cnn
    If Not RsC2.EOF Then
        SubRptCuentaComprobada.Visible = True
        SubRptCuentaComprobada.object.DataSrc.DataSourceName = Cnn
        SubRptCuentaComprobada.object.DataSrc.Recordset = RsC2
    Else
        SubRptCuentaComprobada.Visible = False
    End If

End Sub

Private Sub GrpHdFecha_Format()

    FldFecha.Text = Format(FldFecha.Text, ctFechaLarga)
    
End Sub

Private Sub PageFooter_Format()

    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
    
End Sub

