VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "Mscomctl.ocx"
Begin VB.Form CC_ListaVentas 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   5520
   ClientLeft      =   150
   ClientTop       =   420
   ClientWidth     =   11910
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   9.75
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "CC_ListaVentas.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5520
   ScaleWidth      =   11910
   ShowInTaskbar   =   0   'False
   Begin VB.Frame Frame1 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Selecciona una Venta"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   5295
      Left            =   120
      TabIndex        =   9
      Top             =   120
      Width           =   11655
      Begin VB.TextBox TxtFactura 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   7920
         MaxLength       =   15
         TabIndex        =   5
         Top             =   600
         Width           =   1575
      End
      Begin VB.TextBox TxtRemision 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   6240
         MaxLength       =   15
         TabIndex        =   4
         Top             =   600
         Width           =   1575
      End
      Begin VB.TextBox TxtFolioCliente 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   4560
         MaxLength       =   15
         TabIndex        =   3
         Top             =   600
         Width           =   1575
      End
      Begin VB.TextBox TxtFolioEntrega 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   2880
         MaxLength       =   15
         TabIndex        =   2
         Top             =   600
         Width           =   1575
      End
      Begin VB.TextBox TxtFolio 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   1560
         MaxLength       =   15
         TabIndex        =   1
         Top             =   600
         Width           =   1215
      End
      Begin VB.TextBox TxtSerie 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   240
         MaxLength       =   15
         TabIndex        =   0
         Top             =   600
         Width           =   1215
      End
      Begin MSComctlLib.ListView LstVentas 
         Height          =   3510
         Left            =   120
         TabIndex        =   6
         Top             =   1080
         Width           =   11415
         _ExtentX        =   20135
         _ExtentY        =   6191
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   -1  'True
         FullRowSelect   =   -1  'True
         _Version        =   393217
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         NumItems        =   1
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Object.Width           =   2540
         EndProperty
      End
      Begin VB.CommandButton btnEnd 
         BackColor       =   &H00FFFFFF&
         Cancel          =   -1  'True
         Height          =   495
         Left            =   9720
         Picture         =   "CC_ListaVentas.frx":16B2
         Style           =   1  'Graphical
         TabIndex        =   8
         Top             =   4680
         Width           =   1695
      End
      Begin VB.CommandButton btnFinaliza 
         BackColor       =   &H00FFFFFF&
         Height          =   495
         Left            =   7680
         Picture         =   "CC_ListaVentas.frx":1CB0
         Style           =   1  'Graphical
         TabIndex        =   7
         Top             =   4680
         Width           =   1935
      End
      Begin VB.Label Label5 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Factura"
         Height          =   255
         Left            =   8040
         TabIndex        =   15
         Top             =   360
         Width           =   1215
      End
      Begin VB.Label Label4 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Remisión"
         Height          =   255
         Left            =   6360
         TabIndex        =   14
         Top             =   360
         Width           =   1215
      End
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Folio Cliente"
         Height          =   255
         Left            =   4680
         TabIndex        =   13
         Top             =   360
         Width           =   1215
      End
      Begin VB.Label Label1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Folio Entrega"
         Height          =   255
         Left            =   3000
         TabIndex        =   12
         Top             =   360
         Width           =   1215
      End
      Begin VB.Label Label13 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Folio"
         Height          =   255
         Left            =   1680
         TabIndex        =   11
         Top             =   360
         Width           =   735
      End
      Begin VB.Label Label3 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Serie"
         Height          =   255
         Left            =   360
         TabIndex        =   10
         Top             =   360
         Width           =   735
      End
   End
End
Attribute VB_Name = "CC_ListaVentas"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public LstDVentas

Private Sub btnEnd_Click()
    With CC_MovimientosDetalle
        .Serie = "": .TxtSerie.Text = ""
        .FolioVenta = "": .TxtFolio = ""
        .IdTipoVenta = "": .TxtIdTipoVenta = ""
        .IdCedis = "": .TxtCedis.Text = ""
    End With
    Unload Me
End Sub

Private Sub btnFinaliza_Click()
    LstVentas_DblClick
End Sub

Private Sub LstVentas_DblClick()
On Error Resume Next

    If Tag = "1" Then
        DetalleDeFactura LstDVentas(0, LstVentas.SelectedItem.Index - 1), LstDVentas(2, LstVentas.SelectedItem.Index - 1), LstDVentas(4, LstVentas.SelectedItem.Index - 1), LstDVentas(5, LstVentas.SelectedItem.Index - 1), Me.Top, Me.Left, Me.Width, Me.Height, 0
    Else
        If Trim(LstDVentas(18, LstVentas.SelectedItem.Index - 1)) <> "" Then
            MsgBox "¡ No puedes seleccionar esta venta porque está incluida en la Factura Global " & LstDVentas(18, LstVentas.SelectedItem.Index - 1) & " - " & LstDVentas(19, LstVentas.SelectedItem.Index - 1) & " !"
            Exit Sub
        End If
    
        If Trim(LstDVentas(20, LstVentas.SelectedItem.Index - 1)) = "P" Then
            MsgBox "¡ No puedes seleccionar esta Factura Global porque aún se encuentra en proceso de captura !"
            Exit Sub
        End If
    
        With CC_MovimientosDetalle
            .Serie = LstDVentas(4, LstVentas.SelectedItem.Index - 1): .TxtSerie.Text = LstDVentas(4, LstVentas.SelectedItem.Index - 1)
            .FolioVenta = LstDVentas(5, LstVentas.SelectedItem.Index - 1): .TxtFolio = LstDVentas(5, LstVentas.SelectedItem.Index - 1)
            .IdTipoVenta = LstDVentas(2, LstVentas.SelectedItem.Index - 1): .TxtIdTipoVenta = LstDVentas(0, LstVentas.SelectedItem.Index - 1) & " - " & IIf(LstDVentas(0, LstVentas.SelectedItem.Index - 1) = 1, "Venta de Contado", "Venta de Crédito")
            .IdCedis = LstDVentas(0, LstVentas.SelectedItem.Index - 1): .TxtCedis.Text = LstDVentas(0, LstVentas.SelectedItem.Index - 1) & " - " & LstDVentas(1, LstVentas.SelectedItem.Index - 1)
        End With
        Unload Me
    End If
End Sub

Private Sub LstVentas_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then LstVentas_DblClick
End Sub

Private Sub TxtFactura_GotFocus()
On Error Resume Next
    SelText TxtFactura
End Sub

Private Sub TxtFactura_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then BuscaVentasN
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtFolio_GotFocus()
On Error Resume Next
    SelText TxtFolio
End Sub

Private Sub TxtFolio_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then BuscaVentasN
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtFolioCliente_GotFocus()
On Error Resume Next
    SelText TxtFolioCliente
End Sub

Private Sub TxtFolioCliente_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then BuscaVentasN
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtFolioEntrega_GotFocus()
On Error Resume Next
    SelText TxtFolioEntrega
End Sub

Private Sub TxtFolioEntrega_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then BuscaVentasN
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtRemision_GotFocus()
On Error Resume Next
    SelText TxtRemision
End Sub

Private Sub TxtRemision_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then BuscaVentasN
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtSerie_GotFocus()
On Error Resume Next
    SelText TxtSerie
End Sub

Private Sub TxtSerie_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then BuscaVentasN
    KeyAscii = itString(KeyAscii)
End Sub

Sub BuscaVentasN()
On Error Resume Next
Dim Filtro

    If Trim(TxtSerie.Text) = "" And Trim(TxtFolio.Text) = "" And Trim(TxtFolioCliente.Text) = "" And Trim(TxtFolioEntrega.Text) = "" And Trim(TxtFactura.Text) = "" And Trim(TxtRemision.Text) = "" Then
        MsgBox "¡ Telcea los Criterios de búsqueda !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    Filtro = ""
    If Trim(TxtSerie.Text) <> "" Then Filtro = Filtro & " and Ventas.Serie like ''%" & TxtSerie.Text & "%''"
    If Trim(TxtFolio.Text) <> "" Then Filtro = Filtro & " and Ventas.Folio like ''%" & TxtFolio.Text & "%''"
    If Trim(TxtFolioCliente.Text) <> "" Then Filtro = Filtro & " and VentasAcredita.FolioCliente like ''%" & TxtFolioCliente.Text & "%''"
    If Trim(TxtFolioEntrega.Text) <> "" Then Filtro = Filtro & " and VentasAcredita.FolioEntrega like ''%" & TxtFolioEntrega.Text & "%''"
    If Trim(TxtFactura.Text) <> "" Then Filtro = Filtro & " and VentasAcredita.Factura like ''%" & TxtFactura.Text & "%''"
    If Trim(TxtRemision.Text) <> "" Then Filtro = Filtro & " and VentasAcredita.Remision like ''%" & TxtRemision.Text & "%''"
        
    StrCmd = "execute sel_Ventas 0, 0, '" & Filtro & "', '" & FolioVenta & "', '" & Usuario & "', 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        LstDVentas = GetDataLVL(Rs, LstVentas, 0, 17, "0|0|0|0|0|0|0|0|0|0|9|9|9|9|0|0|0|0")
    Else
        LstDVentas = Empty: LstVentas.ListItems.Clear
        MsgBox "¡ No existen Ventas con los criterios seleccionados !", vbInformation + vbOKOnly, App.Title
    End If
End Sub
