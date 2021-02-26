VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_Cat_Clientes 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   8145
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   11190
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
   ScaleHeight     =   8145
   ScaleWidth      =   11190
   ShowInTaskbar   =   0   'False
   Begin VB.Frame FrmOpt 
      BackColor       =   &H00FFFFFF&
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   11.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   8100
      Index           =   2
      Left            =   120
      TabIndex        =   0
      Top             =   0
      Width           =   10935
      Begin VB.Frame Frame1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Tipo de Cliente"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   735
         Left            =   5880
         TabIndex        =   9
         Top             =   3000
         Width           =   4815
         Begin VB.OptionButton Opt 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Autoservicio"
            Height          =   375
            Index           =   1
            Left            =   1320
            TabIndex        =   12
            Top             =   240
            Width           =   1455
         End
         Begin VB.OptionButton Opt 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Local"
            Height          =   375
            Index           =   0
            Left            =   360
            TabIndex        =   11
            Top             =   240
            Value           =   -1  'True
            Width           =   975
         End
         Begin VB.CommandButton btnActualiza 
            BackColor       =   &H00FFFFFF&
            Default         =   -1  'True
            Height          =   495
            Left            =   2880
            Picture         =   "CC_Cat_Clientes.frx":0000
            Style           =   1  'Graphical
            TabIndex        =   10
            Top             =   170
            Width           =   1815
         End
      End
      Begin VB.TextBox TxtIdCliente 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   240
         TabIndex        =   5
         Top             =   3360
         Width           =   975
      End
      Begin VB.TextBox TxtRFC 
         Height          =   375
         Left            =   1320
         TabIndex        =   4
         Top             =   3360
         Width           =   1575
      End
      Begin VB.TextBox TxtRazonSocial 
         Height          =   375
         Left            =   3000
         TabIndex        =   3
         Top             =   3360
         Width           =   2295
      End
      Begin MSComctlLib.ListView LstClientes 
         Height          =   4215
         Left            =   120
         TabIndex        =   1
         Top             =   3840
         Width           =   10695
         _ExtentX        =   18865
         _ExtentY        =   7435
         View            =   3
         LabelEdit       =   1
         MultiSelect     =   -1  'True
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
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
      Begin MSComctlLib.ListView LstCedis 
         Height          =   2175
         Left            =   240
         TabIndex        =   2
         Top             =   720
         Width           =   5655
         _ExtentX        =   9975
         _ExtentY        =   3836
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
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
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Selecciona un Cedis"
         Height          =   255
         Left            =   360
         TabIndex        =   13
         Top             =   360
         Width           =   2775
      End
      Begin VB.Label Label20 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "No. Cliente"
         Height          =   240
         Left            =   240
         TabIndex        =   8
         Top             =   3120
         Width           =   960
      End
      Begin VB.Label Label21 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Razón Social"
         Height          =   255
         Left            =   3000
         TabIndex        =   7
         Top             =   3120
         Width           =   1695
      End
      Begin VB.Label Label22 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "R.F.C."
         Height          =   240
         Left            =   1320
         TabIndex        =   6
         Top             =   3120
         Width           =   570
      End
   End
End
Attribute VB_Name = "CC_Cat_Clientes"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim lstDCedis, LstDClientes

Private Sub btnActualiza_Click()
Dim StrIdCliente
    On Error Resume Next
    
    StrIdCliente = ""
    For i = 1 To LstClientes.ListItems.Count
        If LstClientes.ListItems(i).Selected Then
            StrIdCliente = StrIdCliente & LstClientes.ListItems(i) & ", "
        End If
    Next
    If Trim(StrIdCliente) <> "" Then
        StrIdCliente = Mid(StrIdCliente, 1, Len(StrIdCliente) - 2)
    Else
        MsgBox "¡ Seleccione un Cliente a Modificar !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    StrCmd = "execute up_ClientesTipo " & CLng(LstCedis.SelectedItem) & ", '" & StrIdCliente & "', '" & IIf(Opt(0).Value, "L", "A") & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
    FiltraClientesTipo
End Sub

Private Sub Form_Load()
On Error Resume Next
    MuestraCedis
    FiltraClientesTipo
End Sub

Private Sub LstCedis_Click()
On Error Resume Next
    FiltraClientesTipo
End Sub

Private Sub LstCedis_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstCedis_Click
End Sub

Private Sub TxtIdCliente_Change()
On Error Resume Next
    FiltraClientesTipo
End Sub

Private Sub TxtIdCliente_GotFocus()
On Error Resume Next
    SelText TxtIdCliente
End Sub

Private Sub TxtIdCliente_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtRazonSocial_Change()
On Error Resume Next
    TxtIdCliente.Text = ""
    FiltraClientesTipo
End Sub

Private Sub TxtRazonSocial_GotFocus()
On Error Resume Next
    SelText TxtRazonSocial
End Sub

Private Sub TxtRazonSocial_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtRFC_Change()
On Error Resume Next
    FiltraClientesTipo
End Sub

Private Sub TxtRFC_GotFocus()
On Error Resume Next
    SelText TxtRFC
End Sub

Private Sub TxtRFC_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Sub FiltraClientesTipo()
On Error Resume Next
    
    If IsEmpty(lstDCedis) Then Exit Sub
'    If Trim(TxtIdCliente.Text) = "" And Trim(TxtRFC.Text) = "" And Trim(TxtRazonSocial.Text) = "" Then Exit Sub
    
    StrCmd = "execute sel_ClientesFacturas " & CLng(LstCedis.SelectedItem) & ",'" & IIf(Trim(TxtIdCliente.Text) = "", 0, Trim(TxtIdCliente.Text)) & "','" & Trim(TxtRFC.Text) & "','" & Trim(TxtRazonSocial.Text) & "', 2"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDClientes = GetDataLVL(RsC, LstClientes, 1, 4, "0|0|0|0")
End Sub

Private Sub MuestraCedis()
On Error Resume Next
    
    StrCmd = "execute sel_CedisUsuarios '', 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    lstDCedis = GetDataLVL(Rs, LstCedis, 1, 2, "0|0")

End Sub

