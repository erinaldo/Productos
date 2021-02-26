VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "Mscomctl.ocx"
Begin VB.Form CC_Cat_Ejecutivo 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   8430
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   12660
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
   ScaleHeight     =   8430
   ScaleWidth      =   12660
   ShowInTaskbar   =   0   'False
   Begin VB.Frame FrmOpt 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Asignación de Clientes a  Ejecutivos"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   8220
      Index           =   2
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   12495
      Begin VB.CommandButton btnAgregaP 
         BackColor       =   &H00FFFFFF&
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   12
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   330
         Left            =   3360
         Picture         =   "CC_Cat_Ejecutivo.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   11
         Top             =   2610
         Width           =   1455
      End
      Begin VB.CommandButton btnEliminaP 
         BackColor       =   &H00FFFFFF&
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   12
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   330
         Left            =   360
         Picture         =   "CC_Cat_Ejecutivo.frx":060F
         Style           =   1  'Graphical
         TabIndex        =   10
         Top             =   5610
         Width           =   1215
      End
      Begin VB.TextBox TxtIdCliente 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   7320
         TabIndex        =   5
         Top             =   1560
         Visible         =   0   'False
         Width           =   975
      End
      Begin VB.TextBox TxtRFC 
         Height          =   375
         Left            =   8400
         TabIndex        =   4
         Top             =   1560
         Visible         =   0   'False
         Width           =   1575
      End
      Begin VB.TextBox TxtRazonSocial 
         Height          =   375
         Left            =   10080
         TabIndex        =   3
         Top             =   1560
         Visible         =   0   'False
         Width           =   2295
      End
      Begin MSComctlLib.ListView LstClientesNo 
         Height          =   2430
         Left            =   120
         TabIndex        =   1
         Top             =   3000
         Width           =   12255
         _ExtentX        =   21616
         _ExtentY        =   4286
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
      Begin MSComctlLib.ListView LstUsuarios 
         Height          =   1935
         Left            =   120
         TabIndex        =   2
         Top             =   600
         Width           =   6975
         _ExtentX        =   12303
         _ExtentY        =   3413
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
      Begin MSComctlLib.ListView LstClientes 
         Height          =   2175
         Left            =   120
         TabIndex        =   14
         Top             =   6000
         Width           =   12255
         _ExtentX        =   21616
         _ExtentY        =   3836
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
      Begin VB.Label Label4 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Clientes Asignados"
         Height          =   240
         Left            =   1800
         TabIndex        =   13
         Top             =   5640
         Width           =   1680
      End
      Begin VB.Label Label3 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Clientes NO Asignados"
         Height          =   240
         Left            =   1200
         TabIndex        =   12
         Top             =   2640
         Width           =   2025
      End
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Selecciona un Usuario"
         Height          =   255
         Left            =   360
         TabIndex        =   9
         Top             =   360
         Width           =   2055
      End
      Begin VB.Label Label20 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "No. Cliente"
         Height          =   240
         Left            =   7320
         TabIndex        =   8
         Top             =   1320
         Visible         =   0   'False
         Width           =   960
      End
      Begin VB.Label Label21 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Razón Social"
         Height          =   255
         Left            =   10080
         TabIndex        =   7
         Top             =   1320
         Visible         =   0   'False
         Width           =   1695
      End
      Begin VB.Label Label22 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "R.F.C."
         Height          =   240
         Left            =   8400
         TabIndex        =   6
         Top             =   1320
         Visible         =   0   'False
         Width           =   570
      End
   End
End
Attribute VB_Name = "CC_Cat_Ejecutivo"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDUsuarios, LstDClientesNo, LstDClientes

Private Sub btnAgregaP_Click()
On Error Resume Next
    If IsEmpty(LstDClientesNo) Then Exit Sub
    
    For i = 1 To LstClientesNo.ListItems.Count
        If LstClientesNo.ListItems(i).Selected Then
            StrCmd = "execute up_UsuariosClientes '" & LstUsuarios.SelectedItem & "', " & LstDClientesNo(1, i - 1) & ", '" & Trim(LstDClientesNo(3, i - 1)) & "', 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
        End If
    Next i
    
    ClientesAsignados 1
    ClientesAsignados 2
End Sub

Private Sub btnEliminaP_Click()
On Error Resume Next
    If IsEmpty(LstDClientes) Then Exit Sub
    
    For i = 1 To LstClientes.ListItems.Count
        If LstClientes.ListItems(i).Selected Then
            StrCmd = "execute up_UsuariosClientes '" & LstUsuarios.SelectedItem & "', " & LstDClientes(1, i - 1) & ", '" & Trim(LstDClientes(3, i - 1)) & "', 2"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
        End If
    Next i
    
    ClientesAsignados 1
    ClientesAsignados 2
End Sub

Private Sub Form_Load()
On Error Resume Next
    MuestraUsuarios
End Sub

Private Sub LstUsuarios_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    ClientesAsignados 1
    ClientesAsignados 2
End Sub

Private Sub MuestraUsuarios()
On Error Resume Next
    
    StrCmd = "execute sel_Usuarios '', 0"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDUsuarios = GetDataLVL(Rs, LstUsuarios, 1, 5, "0|0|0|0|0")

End Sub

Sub ClientesAsignados(Opc As Integer) ' 1 , 2
On Error Resume Next

    StrCmd = "execute sel_UsuariosClientes 0, '" & LstDUsuarios(1, LstUsuarios.SelectedItem.Index - 1) & "', " & IIf(Opc = 1, Opc, Opc + 1)
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    Select Case Opc
        Case 1:
            LstClientes.ListItems.Clear
            LstDClientes = GetDataLVL(Rs, LstClientes, 1, 4, "0|0|0|0")
        Case 2:
            LstClientesNo.ListItems.Clear
            LstDClientesNo = GetDataLVL(Rs, LstClientesNo, 1, 4, "0|0|0|0")
    End Select
End Sub

