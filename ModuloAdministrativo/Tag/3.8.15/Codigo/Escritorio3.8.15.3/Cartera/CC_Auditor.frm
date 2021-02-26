VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_Auditor 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Auditor de Información"
   ClientHeight    =   8490
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
   ScaleHeight     =   8490
   ScaleWidth      =   12660
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
      Height          =   8415
      Index           =   0
      Left            =   120
      TabIndex        =   3
      Top             =   0
      Width           =   12375
      Begin MSComctlLib.ListView LstCedisDia 
         Height          =   1935
         Left            =   240
         TabIndex        =   2
         Top             =   6360
         Width           =   11895
         _ExtentX        =   20981
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
      Begin MSComctlLib.ListView LstCedis 
         Height          =   3615
         Left            =   240
         TabIndex        =   1
         Top             =   2280
         Width           =   11895
         _ExtentX        =   20981
         _ExtentY        =   6376
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
      Begin MSComctlLib.ListView LstCedisNoCerrados 
         Height          =   1335
         Left            =   5880
         TabIndex        =   0
         Top             =   600
         Width           =   6255
         _ExtentX        =   11033
         _ExtentY        =   2355
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
      Begin VB.Label LblPeriodo 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         Caption         =   "Periodo"
         ForeColor       =   &H00000080&
         Height          =   1065
         Left            =   360
         TabIndex        =   7
         Top             =   600
         Width           =   5235
      End
      Begin VB.Label Label3 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Cedis que no están al día en las liquidaciones "
         Height          =   255
         Left            =   6120
         TabIndex        =   6
         Top             =   360
         Width           =   4335
      End
      Begin VB.Label Label1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Diferencias por Día"
         Height          =   255
         Left            =   480
         TabIndex        =   5
         Top             =   6120
         Width           =   2775
      End
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Montos en PDC y CxC"
         Height          =   255
         Left            =   480
         TabIndex        =   4
         Top             =   2040
         Width           =   2775
      End
   End
End
Attribute VB_Name = "CC_Auditor"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim lstDCedis, LstDCedisDia, FechaInicial, FechaFinal, LstDCedisNOCerrados

Private Sub Form_Activate()
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
End Sub

Private Sub Form_Load()
    MousePointer = 0
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    FechaInicial = "01/" & Month(CC_Mantenimiento.DTPFecha.Value) & "/" & Year(CC_Mantenimiento.DTPFecha.Value)
    FechaFinal = CC_Mantenimiento.DTPFecha.Value
    LblPeriodo.Caption = Chr(13) & Chr(10) & "Periodo de Comparación del " & Format(FechaInicial, ctFechaLarga) & " al " & Format(FechaFinal, ctFechaLarga)
    MuestraCedis
End Sub

Private Sub MuestraCedis()
    
    StrCmd = "execute VentasAlDia "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCedisNOCerrados = GetDataLVL(Rs, LstCedisNoCerrados, 0, 2, "0|0|0")
    
    StrCmd = "execute sel_verificasaldos '" & FechaInicial & "', '" & FechaFinal & "'"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    lstDCedis = GetDataLVL(Rs, LstCedis, 1, 5, "0|0|3|3|3")

    StrCmd = "execute sel_verificasaldosDia '" & FechaInicial & "', '" & FechaFinal & "'"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCedisDia = GetDataLVL(Rs, LstCedisDia, 1, 6, "0|0|0|3|3|3")

End Sub

