VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Begin VB.Form AL_Mantenimiento 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Mantenimiento"
   ClientHeight    =   4860
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   7935
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
   ScaleHeight     =   4860
   ScaleWidth      =   7935
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton btnIngresar 
      BackColor       =   &H00FFFFFF&
      Default         =   -1  'True
      Height          =   450
      Left            =   240
      Picture         =   "AL_Mantenimiento.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   5
      Top             =   4200
      Width           =   1695
   End
   Begin VB.CommandButton btnSalir 
      BackColor       =   &H00FFFFFF&
      Cancel          =   -1  'True
      Height          =   450
      Left            =   2040
      Picture         =   "AL_Mantenimiento.frx":06A8
      Style           =   1  'Graphical
      TabIndex        =   6
      Top             =   4200
      Width           =   1215
   End
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
      Height          =   3495
      Index           =   2
      Left            =   120
      TabIndex        =   8
      Top             =   600
      Width           =   7695
      Begin VB.OptionButton OptMnto 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Configuración de Hoja de Liquidación"
         Height          =   495
         Index           =   4
         Left            =   360
         TabIndex        =   10
         Top             =   2400
         Width           =   4215
      End
      Begin VB.OptionButton OptMnto 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Abre Movimientos de Almacén"
         Height          =   255
         Index           =   3
         Left            =   360
         TabIndex        =   4
         Top             =   2160
         Width           =   3015
      End
      Begin VB.OptionButton OptMnto 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Revisión de Kardex"
         Height          =   255
         Index           =   2
         Left            =   360
         TabIndex        =   3
         Top             =   1800
         Width           =   2055
      End
      Begin VB.OptionButton OptMnto 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Cierra Día"
         Height          =   255
         Index           =   1
         Left            =   360
         TabIndex        =   2
         Top             =   1440
         Width           =   2055
      End
      Begin VB.OptionButton OptMnto 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Abre Día"
         Height          =   375
         Index           =   0
         Left            =   360
         TabIndex        =   1
         Top             =   1080
         Width           =   2055
      End
      Begin MSComCtl2.DTPicker DTPFecha 
         Height          =   375
         Left            =   1200
         TabIndex        =   0
         Top             =   360
         Width           =   4215
         _ExtentX        =   7435
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
         Format          =   114098176
         CurrentDate     =   39376
      End
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Fecha"
         Height          =   255
         Left            =   360
         TabIndex        =   9
         Top             =   360
         Width           =   615
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
      TabIndex        =   7
      Top             =   105
      Width           =   2025
   End
End
Attribute VB_Name = "AL_Mantenimiento"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub btnIngresar_Click()
Dim i, Index As Integer
On Error GoTo Err_Herr:

    Index = -1
    For i = 0 To OptMnto.Count - 1
        If OptMnto(i).Value Then
            Index = i
            Exit For
        End If
    Next
    
    If Index = -1 Then
        MsgBox "Seleccione una Rutina", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Index < 4 Then
        If MsgBox("¿ Está seguro que desea Ejecutar la Rutina " & OptMnto(Index).Caption & " ?. " & Chr(13) & Chr(10) & "Una vez Ejecutada no podrá modificarla. ", vbQuestion + vbYesNo, App.Title) = vbNo Then
            Exit Sub
        Else
            If MsgBox("¿ Está seguro que desea Ejecutar la Rutina " & OptMnto(Index).Caption & " ?. ", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        End If
    End If
    MousePointer = 11
    
    If Index = 1 Then
        'If Not ValidaCierre(IdCedis, IIf(BIdioma = "us_english", Format(DTPFecha.Value, "mm/dd/yyyy"), Format(DTPFecha.Value, "dd/mm/yyyy"))) Then Exit Sub
        If Not ValidaCierre(IdCedis, DTPFecha.Value) Then Exit Sub
    End If
    
    If Index = 4 Then
        With AL_ConfiguraLiquidacion
            .Left = Me.Left + 1000
            .Top = Me.Top + 1000
            .Show
        End With
        Exit Sub
    End If
    
    'valida kardex antes de ...
    StrCmd = "exec H_Sistema " & IdCedis & ", '" & FormatDate(DTPFecha.Value) & "', " & Index
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MousePointer = 0
    MsgBox "La Rutina " & OptMnto(Index).Caption & " se ejecutó correctamente.", vbInformation + vbOKOnly, App.Title

No_Err_Herr:
    MousePointer = 0
    Exit Sub
        
Err_Herr:
    MousePointer = 0
    MsgBox "Error al ejecutar la Rutina. Error: " & Err.Description, vbCritical + vbOKOnly, App.Title
    GoTo No_Err_Herr:
    
End Sub

Private Sub btnSalir_Click()
    Unload Me
End Sub

Private Sub Form_Activate()
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
End Sub

Private Sub Form_Load()
    DTPFecha.Value = Date
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
End Sub

