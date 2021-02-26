VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptCatVendedor 
   Caption         =   "Catálogos"
   ClientHeight    =   11490
   ClientLeft      =   120
   ClientTop       =   180
   ClientWidth     =   19080
   Icon            =   "AL_RptCatVendedor.dsx":0000
   Palette         =   "AL_RptCatVendedor.dsx":08CA
   WindowState     =   2  'Maximized
   _ExtentX        =   33655
   _ExtentY        =   20267
   SectionData     =   "AL_RptCatVendedor.dsx":1E08
End
Attribute VB_Name = "AL_RptCatVendedor"
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

