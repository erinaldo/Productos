VERSION 5.00
Begin VB.Form Menu 
   BackColor       =   &H00FFFFFF&
   Caption         =   "ITAnswers - Cuentas por Cobrar"
   ClientHeight    =   1815
   ClientLeft      =   165
   ClientTop       =   555
   ClientWidth     =   12600
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   9.75
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "Menu.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   1815
   ScaleWidth      =   12600
   Begin VB.CommandButton MenuXPB 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      Caption         =   "Acerca &De"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Index           =   6
      Left            =   11280
      Style           =   1  'Graphical
      TabIndex        =   11
      Top             =   550
      Width           =   1095
   End
   Begin VB.CommandButton MenuXPB 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      Caption         =   "&Herramientas"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Index           =   5
      Left            =   9720
      Style           =   1  'Graphical
      TabIndex        =   10
      Top             =   550
      Width           =   1455
   End
   Begin VB.CommandButton MenuXPB 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      Caption         =   "&Promociones"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Index           =   4
      Left            =   5760
      Style           =   1  'Graphical
      TabIndex        =   8
      Top             =   550
      Width           =   1335
   End
   Begin VB.CommandButton MenuXPB 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      Caption         =   "&Catálogos"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Index           =   3
      Left            =   8400
      Style           =   1  'Graphical
      TabIndex        =   7
      Top             =   550
      Width           =   1215
   End
   Begin VB.CommandButton MenuXPB 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      Caption         =   "&Reportes"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Index           =   2
      Left            =   7200
      Style           =   1  'Graphical
      TabIndex        =   6
      Top             =   550
      Width           =   1095
   End
   Begin VB.CommandButton MenuXPB 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      Caption         =   "&Movimientos"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Index           =   1
      Left            =   4320
      Style           =   1  'Graphical
      TabIndex        =   5
      Top             =   550
      Width           =   1335
   End
   Begin VB.CommandButton MenuXPB 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      Caption         =   "&Facturación Global"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Index           =   0
      Left            =   2400
      Style           =   1  'Graphical
      TabIndex        =   4
      Top             =   550
      Width           =   1815
   End
   Begin VB.Frame frmData 
      BackColor       =   &H00FFFFFF&
      Height          =   400
      Left            =   10
      TabIndex        =   0
      Top             =   1335
      Width           =   11710
      Begin VB.Line Line2 
         X1              =   7800
         X2              =   7800
         Y1              =   120
         Y2              =   370
      End
      Begin VB.Line Line1 
         X1              =   4800
         X2              =   4800
         Y1              =   120
         Y2              =   370
      End
   End
   Begin VB.Label LblData 
      Alignment       =   1  'Right Justify
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "V. 0.0.0"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Index           =   3
      Left            =   11400
      TabIndex        =   9
      Top             =   1080
      Width           =   1035
   End
   Begin VB.Line LineSup 
      BorderColor     =   &H008A7A61&
      X1              =   2400
      X2              =   4440
      Y1              =   480
      Y2              =   480
   End
   Begin VB.Line LineSep 
      BorderColor     =   &H008A7A61&
      X1              =   0
      X2              =   2040
      Y1              =   1035
      Y2              =   1035
   End
   Begin VB.Label LblData 
      Alignment       =   2  'Center
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Datos del Cedis"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Index           =   0
      Left            =   0
      TabIndex        =   3
      Top             =   1080
      Width           =   4035
   End
   Begin VB.Label LblData 
      Alignment       =   2  'Center
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Usuario"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Index           =   1
      Left            =   4320
      TabIndex        =   2
      Top             =   1080
      Width           =   3435
   End
   Begin VB.Label LblData 
      Alignment       =   1  'Right Justify
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Fecha"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Index           =   2
      Left            =   7800
      TabIndex        =   1
      Top             =   1080
      Width           =   2835
   End
   Begin VB.Image Image4 
      Height          =   300
      Left            =   2400
      Picture         =   "Menu.frx":0ECA
      Top             =   120
      Width           =   1485
   End
   Begin VB.Image Image2 
      Height          =   285
      Left            =   8880
      Picture         =   "Menu.frx":1650
      Top             =   120
      Visible         =   0   'False
      Width           =   3360
   End
   Begin VB.Image ImgLogo 
      Height          =   810
      Left            =   120
      Picture         =   "Menu.frx":224E
      Stretch         =   -1  'True
      Top             =   120
      Width           =   1680
   End
End
Attribute VB_Name = "Menu"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Load()
    
    ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
    
    IdSistema = 1
    
    'Llena Barra de estado
    LblData(0).Caption = "Cedis " & Format(IdCedis, "00") & " - " & NomCedis
    LblData(1).Caption = DescTipoUsuario & ": " & Usuario
    LblData(2).Caption = Format(Date, "DDDD dd ""de"" MMMM ""de"" yyyy")
    LblData(3).Caption = "CxC V. " & App.Major & "." & App.Minor & "." & App.Revision
    LineSep.BorderColor = &H8A7A61
        
    If Not Cnn.State Then OpenConn Server, Db, "ITAPDC", "itapdc"
End Sub

Private Sub Form_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
On Error GoTo Err_SubMenu
    For i = 0 To MenuXPB.Count - 1
        MenuXPB.Item(i).BackColor = vbWhite
    Next
    Unload SubMenu
Err_SubMenu:
    Exit Sub
End Sub

Private Sub Form_Resize()
On Error GoTo Err_Resize
    
    Height = 1890: Width = 12780: frmData.Width = Width - 130 ': SMenu.Width = Width - 3000
    LineSep.X1 = 0: LineSep.X2 = Width: LineSup.X2 = Width

Err_Resize:
    Exit Sub
End Sub

Private Sub FrmOpc_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    For i = 0 To btnMenu.Count - 1
        btnMenu(i).BackColor = vbWhite
    Next i
End Sub

Private Sub Form_Unload(Cancel As Integer)
    If Rs.State Then Rs.Close
    End
End Sub

Private Sub MenuXPB_MouseMove(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    For i = 0 To MenuXPB.Count - 1
        MenuXPB.Item(i).BackColor = IIf(Index = i, &HEEEEEE, vbWhite)
    Next
End Sub

Private Sub MenuXPB_Click(Index As Integer)
    If Not Cnn.State Then OpenConn Server, Db, "ITAPDC", "itapdc"
    StrPeriodo = ""
    Select Case Index
        Case 0:
            If Not ValidaModulo("OXXO", True) Then Exit Sub
            With FacturasOxxo
                .Caption = "Facturación de Oxxo"
                .Top = Menu.Top + Menu.Height
                .Left = Menu.Left
                .Show 0, Me
            End With
       
        Case 1:
            If Not ValidaModulo("MOVS", True) Then Exit Sub
            With Movimientos
                .Caption = "Aplicación de Movimientos a Facturas"
                .Top = Menu.Top + Menu.Height
                .Left = Menu.Left
                .Show 0, Me
            End With
       
        Case 2:
            If Not ValidaModulo("REPS", True) Then Exit Sub
            With Reportes
                .Top = Menu.Top + Menu.Height
                .Left = Menu.Left
                .Show 0, Me
            End With
            
        Case 3:
            If Not ValidaModulo("CAT", True) Then Exit Sub
            With SubMenu
                .Left = MenuXPB.Item(Index).Left + 150
                .Top = 1420 'Menu.Top + MenuXPB.Item(Index).Top + MenuXPB.Item(Index).Height
                .Show 0, Me
            End With
                
        Case 4:
            If Not ValidaModulo("PROMO", True) Then Exit Sub
            With Promociones
                .Left = Menu.Left
                .Top = Menu.Top + Menu.Height
                .Show 0, Me
            End With
        
        Case 5:
            If Not ValidaModulo("HERR", True) Then Exit Sub
            With Mantenimiento
                .LblTitulo.Caption = "Herramientas del Sistema"
                .Left = Menu.Left
                .Top = Menu.Top + Menu.Height
                .Show 0, Me
            End With
                
        Case 6:
            AcercaDe.Show vbModal
            
        Case Else:
            MsgBox "¡ Módulo en construcción !", vbInformation + vbOKOnly, App.Title
                        
    End Select
End Sub

