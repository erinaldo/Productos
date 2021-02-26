VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptRepCargaConsigna 
   Caption         =   "Consignación de Productos"
   ClientHeight    =   11010
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "AL_RptRepCargaConsigna.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   19420
   SectionData     =   "AL_RptRepCargaConsigna.dsx":08CA
End
Attribute VB_Name = "AL_RptRepCargaConsigna"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public DescripcionAgrupacion As String

Dim Pagina

Private Sub ActiveReport_Activate()
    Set SubRptDetail.object = New AL_RptCargaConsignaDet
End Sub

Private Sub ActiveReport_ReportStart()
    Screen.MousePointer = vbDefault
           
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
End Sub

Private Sub Detail_Format()

    FldFechaEntrega.Text = Format(FldFechaEntrega.Text, ctFechaLarga)
    FldFechaDevolucion.Text = Format(FldFechaDevolucion.Text, ctFechaLarga)
    
    FldFactura.Text = DataSrc.Recordset.Fields!Serie.Value & " - " & DataSrc.Recordset.Fields!Folio.Value
    
    FldCliente.Text = DataSrc.Recordset.Fields!IdCliente.Value & " - " & DataSrc.Recordset.Fields!Cliente.Value
    FldSucursal.Text = DataSrc.Recordset.Fields!IdSucursal.Value & " - " & DataSrc.Recordset.Fields!Sucursal.Value

    StrCmd = "execute sel_ConsignasDetalle " & IdCedis & "," & DataSrc.Recordset.Fields!IdConsigna.Value & ", 0, 3"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn

    If Not Rs.EOF Then
        SubRptDetail.object.DataSrc.DataSourceName = Cnn
        SubRptDetail.object.DataSrc.Recordset = RsC
    End If

End Sub

Private Sub GroupHeader1_Format()
    On Error Resume Next

    FldAgrupacion.Text = DataSrc.Recordset.Fields(0).Value & " - " & DataSrc.Recordset.Fields(1).Value
    
    LabAgrupacion.Caption = DescripcionAgrupacion & ":"

End Sub

Private Sub PageFooter_Format()
    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
End Sub

