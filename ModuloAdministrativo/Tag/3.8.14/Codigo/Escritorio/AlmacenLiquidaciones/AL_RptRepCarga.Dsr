VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptRepCarga 
   Caption         =   "Carga de Producto"
   ClientHeight    =   11430
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "AL_RptRepCarga.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20161
   SectionData     =   "AL_RptRepCarga.dsx":08CA
End
Attribute VB_Name = "AL_RptRepCarga"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public IdCedi As Integer

Dim Pagina
Dim RsDetail As New ADODB.Recordset
Dim RsC As New ADODB.Recordset

Private Sub ActiveReport_Activate()
    
    Screen.MousePointer = vbDefault
    
    Set SubRptDetail.object = New AL_RptCargaDet
    Set SubRptDevMala.object = New AL_RptTipoMerma
    
End Sub

Private Sub ActiveReport_ReportStart()
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
End Sub

Private Sub Detail_Format()

    On Error Resume Next

    StrCmd = "execute sel_SurtidosDetalle " & IdCedi & ", '" & _
            DataSrc.Recordset.Fields!Fecha.Value & "', " & _
            DataSrc.Recordset.Fields!IdSurtido.Value & ", 0, 2"
    
    'Debug.Print DataSrc.Recordset.Fields!IdRuta.Value & ", " & DataSrc.Recordset.Fields!IdSurtido.Value & _
                ", " & StrCmd
    
    Set RsDetail = New ADODB.Recordset
    If RsDetail.State Then RsDetail.Close
    RsDetail.Open StrCmd, Cnn

'    Liquidacion.DetalleSurtidos True, 1
    If Not RsDetail.EOF Then
        SubRptDetail.object.DataSrc.DataSourceName = Cnn
        SubRptDetail.object.DataSrc.Recordset = RsDetail
    End If
    
    StrCmd = "execute sel_TipoMerma 1"
    
    Set RsC = New ADODB.Recordset
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    If Not RsC.EOF Then
        SubRptDevMala.object.DataSrc.DataSourceName = Cnn
        SubRptDevMala.object.DataSrc.Recordset = RsC
    End If
    
End Sub

Private Sub GrpHdFecha_Format()

    FldFecha.Text = Format(FldFecha.Text, ctFechaLarga)

End Sub

Private Sub PageFooter_Format()
    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
End Sub
