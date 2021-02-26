VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_ListaDiasCobranza 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   4260
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
   Icon            =   "CC_ListaDiasCobranza.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   4260
   ScaleWidth      =   8130
   ShowInTaskbar   =   0   'False
   Begin VB.Frame Frame1 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Selecciona una Fecha"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   4095
      Left            =   120
      TabIndex        =   3
      Top             =   120
      Width           =   7935
      Begin MSComctlLib.ListView LstFecha 
         Height          =   3030
         Left            =   120
         TabIndex        =   0
         Top             =   360
         Width           =   7695
         _ExtentX        =   13573
         _ExtentY        =   5345
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
         Left            =   5880
         Picture         =   "CC_ListaDiasCobranza.frx":16B2
         Style           =   1  'Graphical
         TabIndex        =   2
         Top             =   3480
         Width           =   1815
      End
      Begin VB.CommandButton btnFinaliza 
         BackColor       =   &H00FFFFFF&
         Height          =   495
         Left            =   3960
         Picture         =   "CC_ListaDiasCobranza.frx":1DED
         Style           =   1  'Graphical
         TabIndex        =   1
         Top             =   3480
         Width           =   1815
      End
   End
End
Attribute VB_Name = "CC_ListaDiasCobranza"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public IdCed
Dim LstDFecha, Opc


Private Sub btnEnd_Click()
On Error Resume Next
    Me.Hide
End Sub

Private Sub btnFinaliza_Click()
On Error Resume Next

    If MsgBox("¿ Estás seguro que deseas Importar la Cobranza del día " & LstFecha.SelectedItem.ListSubItems(1) & " ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub

    StrCmd = "execute up_CobranzaTerminal " & IdCed & ", '" & FormatDate(LstFecha.SelectedItem.ListSubItems(1)) & "', '" & Usuario & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    CC_Movimientos.MuestraMovimientos
    Me.Hide
    
End Sub

Private Sub Form_Activate()
    MuestraFechasAnteriores
End Sub

Private Sub Form_Load()
    MuestraFechasAnteriores
End Sub

Sub MuestraFechasAnteriores()
On Error Resume Next

    StrCmd = "execute sel_DiasCerrados " & IdCed & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDFecha = GetDataLVL(Rs, LstFecha, 0, 1, "0|0")
End Sub

Private Sub LstCargas_DblClick()
On Error Resume Next
    btnFinaliza_Click
End Sub
