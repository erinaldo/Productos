VERSION 5.00
Begin VB.Form AL_ConfiguraLiquidacion 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Configuración"
   ClientHeight    =   5235
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   6225
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
   ScaleHeight     =   5235
   ScaleWidth      =   6225
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton btnActualizar 
      BackColor       =   &H00FFFFFF&
      Default         =   -1  'True
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
      Left            =   840
      Picture         =   "AL_ConfiguraLiquidacion.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   3
      Top             =   4680
      Width           =   1695
   End
   Begin VB.CommandButton btnSalir 
      BackColor       =   &H00FFFFFF&
      Cancel          =   -1  'True
      Height          =   495
      Left            =   2640
      Picture         =   "AL_ConfiguraLiquidacion.frx":0996
      Style           =   1  'Graphical
      TabIndex        =   0
      Top             =   4680
      Width           =   1455
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
      Height          =   3975
      Index           =   2
      Left            =   120
      TabIndex        =   2
      Top             =   600
      Width           =   6015
      Begin VB.Frame FrmComisiones 
         BackColor       =   &H00FFFFFF&
         Height          =   1815
         Left            =   480
         TabIndex        =   9
         Top             =   2040
         Width           =   4455
         Begin VB.OptionButton OptComisiones 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Por Producto y Familia"
            Height          =   255
            Index           =   3
            Left            =   240
            TabIndex        =   13
            Top             =   1320
            Width           =   2415
         End
         Begin VB.OptionButton OptComisiones 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Por Producto"
            Height          =   255
            Index           =   2
            Left            =   240
            TabIndex        =   12
            Top             =   960
            Width           =   2415
         End
         Begin VB.OptionButton OptComisiones 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Por Familia"
            Height          =   255
            Index           =   1
            Left            =   240
            TabIndex        =   11
            Top             =   600
            Width           =   2415
         End
         Begin VB.OptionButton OptComisiones 
            BackColor       =   &H00FFFFFF&
            Caption         =   "General"
            Height          =   255
            Index           =   0
            Left            =   240
            TabIndex        =   10
            Top             =   240
            Width           =   2415
         End
      End
      Begin VB.CheckBox ChkOpciones 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Mostrar el Detalle de Comisiones de Vendedores"
         Height          =   255
         Index           =   4
         Left            =   360
         TabIndex        =   8
         Top             =   1800
         Width           =   4935
      End
      Begin VB.CheckBox ChkOpciones 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Mostrar Saldos de Clientes de la Ruta"
         Height          =   255
         Index           =   3
         Left            =   360
         TabIndex        =   7
         Top             =   1440
         Width           =   4935
      End
      Begin VB.CheckBox ChkOpciones 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Mostrar Saldos de Envase de la Ruta"
         Height          =   255
         Index           =   2
         Left            =   360
         TabIndex        =   6
         Top             =   1080
         Width           =   4935
      End
      Begin VB.CheckBox ChkOpciones 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Mostrar Saldos de Efectivo del Vendedor"
         Height          =   255
         Index           =   1
         Left            =   360
         TabIndex        =   5
         Top             =   720
         Width           =   4935
      End
      Begin VB.CheckBox ChkOpciones 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Mostrar el Detalle de Efectivo y Documentos entregados"
         Height          =   255
         Index           =   0
         Left            =   360
         TabIndex        =   4
         Top             =   360
         Width           =   5295
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
      TabIndex        =   1
      Top             =   105
      Width           =   2025
   End
End
Attribute VB_Name = "AL_ConfiguraLiquidacion"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False


Private Sub btnActualizar_Click()
On Error Resume Next

    Dim Comisiones
    
    If ChkOpciones(4).Value Then
        If OptComisiones(0).Value Then Comisiones = "G"
        If OptComisiones(1).Value Then Comisiones = "F"
        If OptComisiones(2).Value Then Comisiones = "P"
        If OptComisiones(3).Value Then Comisiones = "A"
    Else
        Comisiones = "N"
    End If
    
    If MsgBox("¿ Estás seguro que deseas cambiar la Configuración de la Hoja de Liquidación ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    StrCmd = "exec up_Configuracion " & IdCedis & ", '" & Comisiones & "', '" & IIf(ChkOpciones(0).Value, "S", "N") & "', '" & IIf(ChkOpciones(1).Value, "S", "N") & "', '" & IIf(ChkOpciones(2).Value, "S", "N") & "', '" & IIf(ChkOpciones(3).Value, "S", "N") & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    StrCmd = "exec sel_Configuracion " & IdCedis & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        ReDim LstConfiguraLiquidacion(4)
        For i = 10 To 14
            LstConfiguraLiquidacion(i - 10) = Rs.Fields(i)
        Next i
    End If
    
    MuestraConfiguracion
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
        
End Sub

Private Sub btnSalir_Click()
    Unload Me
End Sub

Private Sub ChkOpciones_Click(Index As Integer)
    If Index = 4 Then
        FrmComisiones.Enabled = IIf(ChkOpciones(Index).Value, True, False)
        If Not ChkOpciones(Index).Value Then
            For i = 0 To 3
                OptComisiones(i).Value = False
            Next i
        End If
    End If
End Sub

Private Sub Form_Activate()
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
End Sub

Private Sub Form_Load()
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    LblTitulo.Caption = "Configuración de Hoja de Liquidación"
    MuestraConfiguracion
End Sub

Sub MuestraConfiguracion()
    StrCmd = "exec sel_Configuracion " & IdCedis & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        ReDim LstConfiguraLiquidacion(4)
        For i = 10 To 14
            LstConfiguraLiquidacion(i - 10) = Rs.Fields(i)
            Select Case i - 10
                Case 0:
                    If Rs.Fields(i) <> "N" Then ChkOpciones(4).Value = 1
                    ChkOpciones_Click 4
                    Select Case Rs.Fields(i)
                        Case "G": OptComisiones(0).Value = True
                        Case "F": OptComisiones(1).Value = True
                        Case "P": OptComisiones(2).Value = True
                        Case "A": OptComisiones(3).Value = True
                    End Select
                Case 1: If Rs.Fields(i) = "S" Then ChkOpciones(0).Value = 1
                Case 2: If Rs.Fields(i) = "S" Then ChkOpciones(1).Value = 1
                Case 3: If Rs.Fields(i) = "S" Then ChkOpciones(2).Value = 1
                Case 4: If Rs.Fields(i) = "S" Then ChkOpciones(3).Value = 1
                    
            End Select
        Next i
    End If
End Sub
