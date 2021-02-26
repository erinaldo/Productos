VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptCargaConsigna 
   Caption         =   "Consignación de Productos"
   ClientHeight    =   11010
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "AL_RptCargaConsigna.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   19420
   SectionData     =   "AL_RptCargaConsigna.dsx":08CA
End
Attribute VB_Name = "AL_RptCargaConsigna"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina

Private Sub ActiveReport_Activate()
    Set SubRptDetail.object = New AL_RptCargaConsignaDet
End Sub

Private Sub ActiveReport_ReportStart()
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
End Sub

Private Sub Detail_Format()

    FldFechaEntrega.Text = Format(FldFechaEntrega.Text, ctFechaLarga)
    FldFechaDevolucion.Text = Format(FldFechaDevolucion.Text, ctFechaLarga)
    
    FldFactura.Text = DataSrc.Recordset.Fields!Serie.Value & " - " & DataSrc.Recordset.Fields!Folio.Value
    
    FldCliente.Text = DataSrc.Recordset.Fields!IdCliente.Value & " - " & DataSrc.Recordset.Fields!NombreCliente.Value
    FldSucursal.Text = DataSrc.Recordset.Fields!IdSucursal.Value & " - " & DataSrc.Recordset.Fields!NombreSucursal.Value

    StrCmd = "execute sel_ConsignasDetalle " & IdCedis & "," & DataSrc.Recordset.Fields!IdConsigna.Value & ", 0, 3"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn

    If Not Rs.EOF Then
        SubRptDetail.object.DataSrc.DataSourceName = Cnn
        SubRptDetail.object.DataSrc.Recordset = RsC
    End If

End Sub

Private Sub PageFooter_Format()
    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
End Sub

