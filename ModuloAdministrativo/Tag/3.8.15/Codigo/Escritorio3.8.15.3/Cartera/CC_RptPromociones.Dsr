VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} CC_RptPromociones 
   Caption         =   "Acuerdos "
   ClientHeight    =   11460
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "CC_RptPromociones.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33655
   _ExtentY        =   20267
   SectionData     =   "CC_RptPromociones.dsx":08CA
End
Attribute VB_Name = "CC_RptPromociones"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public IdPromo As Long
Dim Pagina

Private Sub ActiveReport_ReportStart()
    LblFechaImpresion.Caption = "Usuario: " & Usuario & ". " & Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
End Sub

Private Sub PageFooter_Format()
    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
End Sub

Private Sub ReportFooter_Format()
    Dim RsCedis As New ADODB.Recordset, RsClientes As New ADODB.Recordset, RsFamilias As New ADODB.Recordset, RsProductos As New ADODB.Recordset
    
    StrCmd = "exec sel_PromocionesCedis " & IdPromo & ", 2"
    If RsCedis.State Then RsCedis.Close
    RsCedis.Open StrCmd, Cnn
    If Not RsCedis.EOF Then
        Set SubRepCedis.object = New CC_RptPromocionesCedis
        SubRepCedis.object.DataSrc.DataSourceName = Cnn
        SubRepCedis.object.DataSrc.Recordset = RsCedis
    End If
    
    StrCmd = "exec sel_promocionesclientes " & IdPromo & ", 0, 2"
    If RsClientes.State Then RsClientes.Close
    RsClientes.Open StrCmd, Cnn
    If Not RsClientes.EOF Then
        Set SubRepClientes.object = New CC_RptPromocionesClientes
        SubRepClientes.object.DataSrc.DataSourceName = Cnn
        SubRepClientes.object.DataSrc.Recordset = RsClientes
    End If

    StrCmd = "exec sel_promocionesproductos " & IdPromo & ", 4"
    If RsFamilias.State Then RsFamilias.Close
    RsFamilias.Open StrCmd, Cnn
    If Not RsFamilias.EOF Then
        Set SubRepFamilias.object = New CC_RptPromocionesFamilias
        SubRepFamilias.object.DataSrc.DataSourceName = Cnn
        SubRepFamilias.object.DataSrc.Recordset = RsFamilias
    End If

    StrCmd = "exec sel_promocionesproductos " & IdPromo & ", 3"
    If RsProductos.State Then RsProductos.Close
    RsProductos.Open StrCmd, Cnn
    If Not RsProductos.EOF Then
        Set SubRepProductos.object = New CC_RptPromocionesProductos
        SubRepProductos.object.DataSrc.DataSourceName = Cnn
        SubRepProductos.object.DataSrc.Recordset = RsProductos
    End If
    
End Sub
