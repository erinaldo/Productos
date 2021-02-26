VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Begin VB.Form AL_Acreditar 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Acreditación de Facturas"
   ClientHeight    =   5700
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   8010
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   9.75
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   5700
   ScaleWidth      =   8010
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton btnSalir 
      BackColor       =   &H00FFFFFF&
      Cancel          =   -1  'True
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   425
      Left            =   9840
      Picture         =   "AL_Acreditar.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   32
      Top             =   480
      Visible         =   0   'False
      Width           =   1455
   End
   Begin VB.Frame Frame2 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Datos de la Venta"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1215
      Left            =   120
      TabIndex        =   20
      Top             =   120
      Width           =   3735
      Begin VB.TextBox Text4 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   1920
         Locked          =   -1  'True
         TabIndex        =   26
         Text            =   "Folio"
         Top             =   720
         Width           =   555
      End
      Begin VB.TextBox Text3 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   240
         TabIndex        =   25
         Text            =   "Serie"
         Top             =   720
         Width           =   555
      End
      Begin VB.TextBox Text2 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   225
         Locked          =   -1  'True
         TabIndex        =   24
         Text            =   "Tipo de Venta"
         Top             =   360
         Width           =   1275
      End
      Begin VB.TextBox TxtFolio 
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
         Left            =   2520
         Locked          =   -1  'True
         TabIndex        =   23
         Top             =   720
         Width           =   975
      End
      Begin VB.TextBox TxtSerie 
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
         Left            =   840
         Locked          =   -1  'True
         TabIndex        =   22
         Top             =   720
         Width           =   615
      End
      Begin VB.TextBox TxtTipoVenta 
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
         Left            =   1680
         Locked          =   -1  'True
         TabIndex        =   21
         Top             =   360
         Width           =   1815
      End
   End
   Begin VB.Frame Frame3 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Datos del Cliente"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1215
      Left            =   120
      TabIndex        =   11
      Top             =   1440
      Width           =   7815
      Begin VB.TextBox Text14 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         Locked          =   -1  'True
         TabIndex        =   19
         Text            =   "Lista de Precios"
         Top             =   840
         Width           =   1455
      End
      Begin VB.TextBox Txt12 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   2160
         TabIndex        =   18
         Text            =   "Cliente"
         Top             =   240
         Width           =   735
      End
      Begin VB.TextBox Text5 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         Locked          =   -1  'True
         TabIndex        =   17
         Text            =   "R.F.C."
         Top             =   240
         Width           =   615
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
         TabIndex        =   16
         Top             =   240
         Width           =   1215
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
         TabIndex        =   15
         Top             =   240
         Width           =   4575
      End
      Begin VB.TextBox TxtListaPrecios 
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
         Left            =   1680
         Locked          =   -1  'True
         TabIndex        =   14
         Top             =   840
         Width           =   5535
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
         TabIndex        =   13
         Top             =   530
         Width           =   6495
      End
      Begin VB.TextBox Text6 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         TabIndex        =   12
         Text            =   "Sucursal"
         Top             =   530
         Width           =   855
      End
   End
   Begin VB.Frame FrmOpt 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Detalle de la Acreditación"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2895
      Index           =   2
      Left            =   120
      TabIndex        =   10
      Top             =   2760
      Width           =   7815
      Begin VB.ComboBox cmbStatus 
         Height          =   360
         ItemData        =   "AL_Acreditar.frx":0557
         Left            =   3840
         List            =   "AL_Acreditar.frx":0564
         Style           =   2  'Dropdown List
         TabIndex        =   1
         Top             =   600
         Width           =   2055
      End
      Begin VB.TextBox TxtFolioCliente 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   1800
         TabIndex        =   4
         Top             =   1320
         Width           =   1335
      End
      Begin VB.TextBox TxtFactura 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   4920
         TabIndex        =   6
         Top             =   1320
         Width           =   1335
      End
      Begin VB.TextBox TxtRemision 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   3360
         TabIndex        =   5
         Top             =   1320
         Width           =   1335
      End
      Begin VB.CommandButton btnActualizar 
         BackColor       =   &H00FFFFFF&
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Left            =   5760
         Picture         =   "AL_Acreditar.frx":05A1
         Style           =   1  'Graphical
         TabIndex        =   8
         Top             =   2200
         Width           =   1695
      End
      Begin VB.TextBox TxtFolioE 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   240
         TabIndex        =   3
         Top             =   1320
         Width           =   1335
      End
      Begin VB.TextBox TxtUsuario 
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
         Left            =   360
         Locked          =   -1  'True
         TabIndex        =   9
         Text            =   "-"
         Top             =   645
         Width           =   1095
      End
      Begin VB.TextBox TxtObservaciones 
         Height          =   600
         Left            =   240
         MaxLength       =   30
         TabIndex        =   7
         Top             =   2160
         Width           =   5295
      End
      Begin MSComCtl2.DTPicker DTPFechaA 
         Height          =   375
         Left            =   2040
         TabIndex        =   0
         Top             =   600
         Width           =   1695
         _ExtentX        =   2990
         _ExtentY        =   661
         _Version        =   393216
         Enabled         =   0   'False
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Format          =   90898433
         CurrentDate     =   39376
      End
      Begin MSComCtl2.DTPicker DTPFechaE 
         Height          =   375
         Left            =   6000
         TabIndex        =   2
         Top             =   600
         Width           =   1695
         _ExtentX        =   2990
         _ExtentY        =   661
         _Version        =   393216
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Format          =   90898433
         CurrentDate     =   39376
      End
      Begin VB.Label Label9 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Status"
         Height          =   255
         Left            =   3960
         TabIndex        =   37
         Top             =   360
         Width           =   1335
      End
      Begin VB.Label Label8 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Fol. Cliente"
         Height          =   255
         Left            =   1920
         TabIndex        =   36
         Top             =   1080
         Width           =   1215
      End
      Begin VB.Label Label7 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Factura"
         Height          =   255
         Left            =   5040
         TabIndex        =   35
         Top             =   1080
         Width           =   1095
      End
      Begin VB.Label Label5 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Remisión"
         Height          =   255
         Left            =   3480
         TabIndex        =   34
         Top             =   1080
         Width           =   1095
      End
      Begin VB.Label Label4 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Fol. Entrega"
         Height          =   255
         Left            =   360
         TabIndex        =   31
         Top             =   1080
         Width           =   1215
      End
      Begin VB.Label Label1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "F. Entrega"
         Height          =   255
         Left            =   6120
         TabIndex        =   30
         Top             =   360
         Width           =   1215
      End
      Begin VB.Label Label6 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Observaciones"
         Height          =   255
         Left            =   360
         TabIndex        =   29
         Top             =   1920
         Width           =   3135
      End
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "F. Acreditación"
         Height          =   255
         Left            =   2160
         TabIndex        =   28
         Top             =   360
         Width           =   1335
      End
      Begin VB.Label Label3 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Usuario"
         Height          =   255
         Left            =   480
         TabIndex        =   27
         Top             =   360
         Width           =   975
      End
   End
   Begin VB.Label LblAcredita 
      Alignment       =   2  'Center
      BackColor       =   &H00FFFFFF&
      Caption         =   "FACTURA ACREDITADA"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000080&
      Height          =   525
      Index           =   0
      Left            =   4440
      TabIndex        =   33
      Top             =   480
      Width           =   2580
   End
End
Attribute VB_Name = "AL_Acreditar"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public IdTipoVenta, Folio, Serie, VentanaFacturas As Boolean

Private Sub btnActualizar_Click()
On Error Resume Next
    Dim StatusAcredita

    If MsgBox("¿ Estás seguro que deseas Acreditar la Venta ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    If Trim(cmbStatus.Text) = "" Then
        MsgBox "¡ Selecciona el Status de la Acreditación !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
'    If Trim(TxtFolioE.Text) = "" And Mid(cmbStatus.Text, 1, 1) = "1" Then
'        MsgBox "¡ Teclea un Folio de Entrega !", vbInformation + vbOKOnly, App.Title
'        Exit Sub
'    End If

    If Not ValidaDatosAcreditacion Then Exit Sub
    
    If Mid(LblAcredita(0).Caption, 1, 1) <> Mid(cmbStatus.Text, 1, 1) And IsNumeric(Mid(LblAcredita(0).Caption, 1, 1)) Then
        If MsgBox("¿ Estás seguro que deseas cambiar el Status de la Acreditación de la Venta ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    End If
    
    Select Case Mid(cmbStatus.Text, 1, 1)
        Case "1": StatusAcredita = "A"
        Case "2": StatusAcredita = "N"
        Case "3": StatusAcredita = "P"
    End Select
    
    StrCmd = "execute up_VentasAcredita " & IdCedis & ", " & IdSurtido & ", " & IdTipoVenta & _
    ", '" & Folio & "', '" & Serie & "', '" & FormatDate(DTPFechaA.Value) & "', '" & Usuario & _
    "', '" & FormatDate(DTPFechaE.Value) & "', '" & Trim(TxtFolioE.Text) & "', '" & Trim(TxtObservaciones.Text) & _
    "', '" & Trim(TxtFolioCliente.Text) & "', '" & Trim(TxtRemision.Text) & "', '" & Trim(TxtFactura.Text) & _
    "', '" & StatusAcredita & "', 0, 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", " & IdSurtido & ", 0, 0, " & IdTipoVenta & ", '" & Serie & "', " & Folio & ", '" & _
    FormatDate(Fecha) & "', " & IdRuta & ", 0, '', 0, 'Acreditar', 'Liquidación " & IdSurtido & ". Fecha Acreditación " & FormatDate(DTPFechaA.Value) & ", Fecha Entrega " & FormatDate(DTPFechaE.Value) & ", Folio Recepción " & Trim(TxtFolioE.Text) & "', 5"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    Me.Hide
    
End Sub

Private Sub btnSalir_Click()
On Error Resume Next
    Me.Hide
End Sub

Private Sub cmbStatus_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then DTPFechaE.SetFocus
End Sub

Private Sub DTPFechaE_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then TxtFolioE.SetFocus
End Sub

Private Sub Form_Activate()
On Error Resume Next
    MuestraDatosAcreditacion
    cmbStatus.SetFocus
End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    If VentanaFacturas Then
        AL_Facturas.Show
        AL_Facturas.ZOrder (0)
    End If
    VentanaFacturas = False
End Sub

Private Sub TxtFactura_GotFocus()
On Error Resume Next
    SelText TxtFactura
End Sub

Private Sub TxtFactura_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        TxtObservaciones.SetFocus
        Exit Sub
    End If
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtFolioCliente_GotFocus()
On Error Resume Next
    SelText TxtFolioCliente
End Sub

Private Sub TxtFolioCliente_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        TxtRemision.SetFocus
        Exit Sub
    End If
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtFolioE_GotFocus()
On Error Resume Next
    SelText TxtFolioE
End Sub

Private Sub TxtFolioE_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        TxtFolioCliente.SetFocus
        Exit Sub
    End If
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtObservaciones_GotFocus()
On Error Resume Next
    SelText TxtObservaciones
End Sub

Private Sub TxtObservaciones_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        btnActualizar.SetFocus
        Exit Sub
    End If
    
    KeyAscii = itString(KeyAscii)
End Sub

Sub MuestraDatosAcreditacion()
On Error Resume Next

    StrCmd = "execute sel_VentasAcredita " & IdCedis & ", " & IdSurtido & ", " & IdTipoVenta & ", '" & Serie & "', '" & Folio & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
'        btnActualizar.Visible = False
        TxtUsuario.Text = Rs.Fields(3)
        DTPFechaE.Value = Rs.Fields(4)
        DTPFechaA.Value = Rs.Fields(2)
        TxtFolioE.Text = Rs.Fields(5)
        TxtObservaciones.Text = Rs.Fields(6)
        TxtFolioCliente.Text = Rs.Fields(7)
        TxtRemision.Text = Rs.Fields(8)
        TxtFactura.Text = Rs.Fields(9)
        LblAcredita(0).Visible = True
        Select Case Rs.Fields(10)
            Case "A":
                LblAcredita(0).Caption = "1. Acreditada"
                cmbStatus.ListIndex = 0
            Case "P":
                LblAcredita(0).Caption = "3. Pendiente Acreditar"
                cmbStatus.ListIndex = 2
            Case "N":
                LblAcredita(0).Caption = "2. NO Acreditada"
                cmbStatus.ListIndex = 1
        End Select
    Else
'        btnActualizar.Visible = True
        DTPFechaA.Value = Date
        TxtUsuario.Text = Usuario
        DTPFechaE.Value = Date
        TxtFolioE.Text = ""
        TxtObservaciones.Text = ""
        TxtFolioCliente.Text = ""
        TxtRemision.Text = ""
        TxtFactura.Text = ""
        LblAcredita(0).Visible = True
        LblAcredita(0).Caption = "Sin Registro de Acreditación"
        cmbStatus.ListIndex = 0
    End If
    
End Sub

Private Sub TxtRemision_GotFocus()
On Error Resume Next
    SelText TxtRemision
End Sub

Private Sub TxtRemision_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        TxtFactura.SetFocus
        Exit Sub
    End If
    KeyAscii = itString(KeyAscii)
End Sub

Function ValidaDatosAcreditacion() As Boolean
    ValidaDatosAcreditacion = False

    StrCmd = "execute sel_VentasAcreditaValida " & IdCedis & ", " & IdSurtido & ", " & IdTipoVenta & ", '" & Serie & "', '" & Folio & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        If Trim(Rs.Fields(1)) <> "" And Trim(TxtFolioE.Text) = "" Then
            MsgBox "¡ El dato capturado en ""Folio de Entrega"" no es válido para la Addenda del Cliente !", vbInformation + vbOKOnly
            Exit Function
        End If
        If Trim(Rs.Fields(2)) <> "" And Trim(TxtObservaciones.Text) = "" Then
            MsgBox "¡ El dato capturado en ""Observaciones"" no es válido para la Addenda del Cliente !", vbInformation + vbOKOnly
            Exit Function
        End If
        If Trim(Rs.Fields(3)) <> "" And Trim(TxtFolioCliente.Text) = "" Then
            MsgBox "¡ El dato capturado en ""Folio Cliente"" no es válido para la Addenda del Cliente !", vbInformation + vbOKOnly
            Exit Function
        End If
        If Trim(Rs.Fields(4)) <> "" And Trim(TxtRemision.Text) = "" Then
            MsgBox "¡ El dato capturado en ""Remisión"" no es válido para la Addenda del Cliente !", vbInformation + vbOKOnly
            Exit Function
        End If
        If Trim(Rs.Fields(5)) <> "" And Trim(TxtFactura.Text) = "" Then
            MsgBox "¡ El dato capturado en ""Factura"" no es válido para la Addenda del Cliente !", vbInformation + vbOKOnly
            Exit Function
        End If
    Else
        ValidaDatosAcreditacion = True
    End If
    ValidaDatosAcreditacion = True
End Function

