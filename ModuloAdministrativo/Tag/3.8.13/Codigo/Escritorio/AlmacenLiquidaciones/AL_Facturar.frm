VERSION 5.00
Begin VB.Form AL_Facturar 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   2475
   ClientLeft      =   150
   ClientTop       =   420
   ClientWidth     =   8130
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   9.75
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "AL_Facturar.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   2475
   ScaleWidth      =   8130
   ShowInTaskbar   =   0   'False
   Begin VB.Frame Frame1 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Asignación de Serie y Folio"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2295
      Left            =   120
      TabIndex        =   4
      Top             =   120
      Width           =   7935
      Begin VB.TextBox Text2 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         TabIndex        =   14
         Text            =   "Datos de la Remisión"
         Top             =   960
         Width           =   1935
      End
      Begin VB.TextBox TxtRemision 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   2160
         Locked          =   -1  'True
         TabIndex        =   13
         Top             =   960
         Width           =   5535
      End
      Begin VB.TextBox Text6 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         TabIndex        =   12
         Text            =   "Sucursal"
         Top             =   645
         Width           =   855
      End
      Begin VB.TextBox TxtSucursal 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   1080
         Locked          =   -1  'True
         TabIndex        =   11
         Top             =   645
         Width           =   6495
      End
      Begin VB.TextBox TxtCliente 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   3000
         Locked          =   -1  'True
         TabIndex        =   10
         Top             =   360
         Width           =   4575
      End
      Begin VB.TextBox TxtRFC 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   210
         Left            =   840
         Locked          =   -1  'True
         TabIndex        =   9
         Top             =   360
         Width           =   1215
      End
      Begin VB.TextBox Text5 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         Locked          =   -1  'True
         TabIndex        =   8
         Text            =   "R.F.C."
         Top             =   360
         Width           =   615
      End
      Begin VB.TextBox Txt12 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   2160
         TabIndex        =   7
         Text            =   "Cliente"
         Top             =   360
         Width           =   735
      End
      Begin VB.CommandButton btnEnd 
         BackColor       =   &H00FFFFFF&
         Cancel          =   -1  'True
         Height          =   495
         Left            =   5880
         Picture         =   "AL_Facturar.frx":16B2
         Style           =   1  'Graphical
         TabIndex        =   3
         Top             =   1740
         Width           =   1815
      End
      Begin VB.CommandButton btnFinaliza 
         BackColor       =   &H00FFFFFF&
         Height          =   495
         Left            =   3960
         Picture         =   "AL_Facturar.frx":1DED
         Style           =   1  'Graphical
         TabIndex        =   2
         Top             =   1740
         Width           =   1815
      End
      Begin VB.TextBox TxtFolio 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   2400
         TabIndex        =   1
         Top             =   1800
         Width           =   1335
      End
      Begin VB.ComboBox CmbSeries 
         Height          =   360
         Left            =   240
         Style           =   2  'Dropdown List
         TabIndex        =   0
         Top             =   1800
         Width           =   2055
      End
      Begin VB.Label Label1 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Folio"
         Height          =   240
         Left            =   2400
         TabIndex        =   6
         Top             =   1560
         Width           =   420
      End
      Begin VB.Label Label6 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Serie"
         Height          =   255
         Left            =   240
         TabIndex        =   5
         Top             =   1560
         Width           =   2295
      End
   End
End
Attribute VB_Name = "AL_Facturar"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public IdTipoVenta, Serie, Folio, LstDSeries

Private Sub btnEnd_Click()
    Unload Me
End Sub

Private Sub btnFinaliza_Click()
On Error Resume Next
    
    If CmbSeries.ListIndex = 0 Then
        MsgBox "¡ Selecciona una Serie de Facturación !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    TxtFolio_Validate False
    
    If Trim(TxtFolio.Text) = "0" Or Trim(TxtFolio.Text) = "" Then
        MsgBox "¡ Teclea un Folio de Factura !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    StrCmd = "execute up_VentasFactura " & IdCedis & ", " & IdSurtido & ", " & IdTipoVenta & ", " & Folio & ", '" & Serie & "', " & Trim(TxtFolio.Text) & ", '" & CmbSeries.Text & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    AL_Liquidacion.MuestraFacturas
    Unload Me

End Sub

Private Sub CmbSeries_Click()
On Error Resume Next
    
    StrCmd = "execute sel_Folios " & IdCedis & ", " & IIf(IdTipoVenta = "", 0, IdTipoVenta) & ", 0, 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    If Not Rs.EOF Then
        TxtFolio.Text = Rs.Fields(1)
    Else
        TxtFolio.Text = "0"
    End If
    
End Sub

Private Sub Form_Activate()
On Error Resume Next
    LlenaSeries
    TxtFolio.SetFocus
End Sub

Sub LlenaSeries()
On Error Resume Next
    StrCmd = "execute sel_Folios " & IdCedis & ", " & IIf(IdTipoVenta = "", 0, IdTipoVenta) & ", 0, 6"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDSeries = GetDataCBL(Rs, CmbSeries, "Serie", "No existen Series")
    CmbSeries.ListIndex = 1
End Sub

Private Sub TxtFolio_GotFocus()
On Error Resume Next
    SelText TxtFolio
End Sub

Private Sub TxtFolio_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtFolio_Validate(Cancel As Boolean)
On Error Resume Next

    StrCmd = "execute sel_Folios " & IdCedis & ", " & IdTipoVenta & ", " & TxtFolio.Text & ", 7"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        If Rs.Fields(0) > CLng(TxtFolio.Text) Then
            MsgBox "¡ El Folio de Factura debe ser mayor al Folio Inicial " & Rs.Fields(0) & " !", vbInformation + vbOKOnly, App.Title
            TxtFolio.Text = ""
            TxtFolio.SetFocus
            Exit Sub
        Else
            If Rs.Fields(1) <> 0 Then
                MsgBox "¡ El Folio " & TxtFolio.Text & " ya existe !. Teclee otro Folio.", vbInformation + vbOKOnly, App.Title
                TxtFolio.Text = ""
                TxtFolio.SetFocus
                Exit Sub
            End If
        End If
    Else
        MsgBox "¡ Teclea un Folio de Factura Válido !", vbInformation + vbOKOnly, App.Title
        TxtFolio.Text = ""
        TxtFolio.SetFocus
    End If

End Sub
