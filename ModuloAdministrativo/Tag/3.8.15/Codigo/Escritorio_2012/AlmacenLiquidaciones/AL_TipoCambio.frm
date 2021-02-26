VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form AL_TipoCambio 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Registro de Tipo de Cambio"
   ClientHeight    =   4680
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   9105
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
   ScaleHeight     =   4680
   ScaleWidth      =   9105
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
      Height          =   3975
      Index           =   2
      Left            =   120
      TabIndex        =   4
      Top             =   600
      Width           =   8895
      Begin VB.TextBox TxtTipoDeCambio 
         Alignment       =   1  'Right Justify
         Height          =   360
         Left            =   4680
         TabIndex        =   2
         Top             =   600
         Width           =   1455
      End
      Begin VB.ComboBox cmbMoneda 
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   345
         Left            =   2280
         Style           =   2  'Dropdown List
         TabIndex        =   1
         Top             =   600
         Width           =   2295
      End
      Begin MSComctlLib.ListView LstTipoDeCambio 
         Height          =   2670
         Left            =   120
         TabIndex        =   8
         Top             =   1200
         Width           =   8655
         _ExtentX        =   15266
         _ExtentY        =   4710
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
      Begin MSComCtl2.DTPicker DTPFecha 
         Height          =   375
         Left            =   240
         TabIndex        =   0
         Top             =   600
         Width           =   1935
         _ExtentX        =   3413
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
         Format          =   113573889
         CurrentDate     =   39376
      End
      Begin VB.Label Label2 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Fecha"
         Height          =   240
         Left            =   360
         TabIndex        =   9
         Top             =   360
         Width           =   540
      End
      Begin VB.Label LblMonedaBase 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Moneda Base"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   6360
         TabIndex        =   7
         Top             =   720
         Width           =   2295
      End
      Begin VB.Label Label1 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Tipo de Cambio"
         Height          =   240
         Left            =   4680
         TabIndex        =   6
         Top             =   360
         Width           =   1350
      End
      Begin VB.Label Label17 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Moneda"
         Height          =   240
         Left            =   2400
         TabIndex        =   5
         Top             =   360
         Width           =   690
      End
   End
   Begin VB.Label LblTitulo 
      AutoSize        =   -1  'True
      BackColor       =   &H00FFFFFF&
      Caption         =   "Titulo de la Pantalla"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000C0&
      Height          =   270
      Left            =   360
      TabIndex        =   3
      Top             =   105
      Width           =   2025
   End
End
Attribute VB_Name = "AL_TipoCambio"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDTipoDeCambio, LstDMonedas, IdMonedaBase

Private Sub cmbMoneda_Click()
On Error Resume Next
    MuestraTipoDeCambio
End Sub

Private Sub DTPFecha_Change()
On Error Resume Next
    MuestraTipoDeCambio
End Sub

Private Sub Form_Load()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    
    StrCmd = "exec sel_TipoDeCambio " & IdCedis & ", '19000101', '', '', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        If CDbl(Rs.Fields(1)) = 0 Then
            MsgBox "¡ No hay Monedas para Definir un Tipo de Cambio !", vbInformation + vbOKOnly, App.Title
            AL_TipoCambio.Hide
            Exit Sub
        End If
    End If
    
    LblTitulo.Caption = "Registro de Tipo de Cambio"
    DTPFecha.Value = Date
    
    StrCmd = "exec sel_TipoDeCambio " & IdCedis & ", '" & FormatDate(Fecha) & "', '', '', 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        IdMonedaBase = Rs.Fields(0)
        LblMonedaBase.Caption = Rs.Fields(0) & " - " & Rs.Fields(1)
    End If
    LlenaMonedas
End Sub

Sub MuestraTipoDeCambio()
On Error Resume Next
    StrCmd = "exec sel_TipoDeCambio " & IdCedis & ", '" & FormatDate(DTPFecha.Value) & "', '', '', 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDTipoDeCambio = GetDataLVL(Rs, LstTipoDeCambio, 0, 5, "5|0|0|0|0|7")

    StrCmd = "exec sel_TipoDeCambio " & IdCedis & ", '" & FormatDate(DTPFecha.Value) & "', '', '" & LstDMonedas(0, CmbMoneda.ListIndex - 1) & "', 5"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        TxtTipoDeCambio.Text = Rs.Fields(2)
    End If
End Sub

Sub LlenaMonedas()
On Error Resume Next
    StrCmd = "exec sel_TipoDeCambio " & IdCedis & ", '" & FormatDate(Fecha) & "', '', '', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDMonedas = GetDataCBL(Rs, CmbMoneda, "Moneda", "No existen Monedas")
End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    StrCmd = "exec sel_TipoDeCambio " & IdCedis & ", '" & FormatDate(DTPFecha.Value) & "', '', '', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        If CDbl(Rs.Fields(2)) > 0 Then MsgBox "¡ Hay Monedas sin Tipo de Cambio definido para el " & Format(DTPFecha.Value, ctFechaLarga) & " !", vbInformation + vbOKOnly, App.Title
    End If
End Sub

Private Sub TxtTipoDeCambio_GotFocus()
On Error Resume Next
    SelText TxtTipoDeCambio
End Sub

Private Sub TxtTipoDeCambio_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 Then
        StrCmd = "exec up_TipoDeCambio " & IdCedis & ", '" & FormatDate(DTPFecha.Value) & "', '" & IdMonedaBase & "', '" & LstDMonedas(0, CmbMoneda.ListIndex - 1) & "', " & CDbl(TxtTipoDeCambio.Text) & ", 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        MuestraTipoDeCambio
        Exit Sub
    End If
    
    KeyAscii = itDecimal(KeyAscii)
End Sub

Private Sub TxtTipoDeCambio_Validate(Cancel As Boolean)
On Error Resume Next
    TxtTipoDeCambio.Text = itFlotante(TxtTipoDeCambio.Text)
End Sub
