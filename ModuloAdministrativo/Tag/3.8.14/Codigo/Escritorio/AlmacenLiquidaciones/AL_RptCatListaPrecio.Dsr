VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptCatListaPrecio 
   Caption         =   "Catálogos"
   ClientHeight    =   11460
   ClientLeft      =   120
   ClientTop       =   180
   ClientWidth     =   18960
   Icon            =   "AL_RptCatListaPrecio.dsx":0000
   Palette         =   "AL_RptCatListaPrecio.dsx":08CA
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20214
   SectionData     =   "AL_RptCatListaPrecio.dsx":1E08
End
Attribute VB_Name = "AL_RptCatListaPrecio"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina

Private Sub ActiveReport_ReportStart()
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
End Sub

Private Sub PageFooter_Format()
    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
End Sub

