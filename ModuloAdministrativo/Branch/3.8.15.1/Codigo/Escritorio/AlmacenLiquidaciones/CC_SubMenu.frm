VERSION 5.00
Begin VB.Form CC_SubMenu 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   0  'None
   Caption         =   "Form1"
   ClientHeight    =   1980
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   1800
   LinkTopic       =   "Form1"
   MDIChild        =   -1  'True
   Picture         =   "CC_SubMenu.frx":0000
   ScaleHeight     =   1980
   ScaleWidth      =   1800
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton MenuXPB 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      Caption         =   "Clientes"
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
      Left            =   2400
      Style           =   1  'Graphical
      TabIndex        =   4
      Top             =   480
      Width           =   1575
   End
   Begin VB.CommandButton MenuXPB 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      Caption         =   "Productos"
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
      Left            =   2400
      Style           =   1  'Graphical
      TabIndex        =   3
      Top             =   960
      Width           =   1575
   End
   Begin VB.CommandButton MenuXPB 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      Caption         =   "Tipo Productos"
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
      Left            =   2400
      Style           =   1  'Graphical
      TabIndex        =   2
      Top             =   1440
      Width           =   1575
   End
   Begin VB.CommandButton MenuXPB 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      Caption         =   "Rutas, Vendedores y Unidades"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   735
      Index           =   7
      Left            =   2400
      Style           =   1  'Graphical
      TabIndex        =   1
      Top             =   1920
      Width           =   1575
   End
   Begin VB.CommandButton MenuXPB 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      Caption         =   "Precios"
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
      Index           =   8
      Left            =   2400
      Style           =   1  'Graphical
      TabIndex        =   0
      Top             =   2760
      Width           =   1575
   End
   Begin VB.Line Line3 
      X1              =   0
      X2              =   1800
      Y1              =   1920
      Y2              =   1920
   End
   Begin VB.Line Line1 
      X1              =   0
      X2              =   0
      Y1              =   1920
      Y2              =   0
   End
   Begin VB.Line Line2 
      X1              =   1770
      X2              =   1770
      Y1              =   1920
      Y2              =   0
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   5
      Left            =   0
      Picture         =   "CC_SubMenu.frx":0A2B
      Top             =   120
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   6
      Left            =   0
      Picture         =   "CC_SubMenu.frx":0D83
      Top             =   480
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   7
      Left            =   0
      Picture         =   "CC_SubMenu.frx":1263
      Top             =   840
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   8
      Left            =   0
      Picture         =   "CC_SubMenu.frx":153A
      Top             =   1200
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   9
      Left            =   0
      Picture         =   "CC_SubMenu.frx":1922
      Top             =   1560
      Width           =   1770
   End
End
Attribute VB_Name = "CC_SubMenu"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False


Private Sub Form_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
On Error Resume Next
    PintaBotones False, 0
End Sub

Private Sub ImgeMenu_Click(Index As Integer)
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    Unload Me
    Select Case Index
        Case 5:
            With CC_Cat_Documentos
                .Caption = "Control de Documentos y Tipos de Documento"
                .Top = MenuCartera.Top + MenuCartera.Height
                .Left = MenuCartera.Left
                .Show
            End With

        Case 7:
            With CC_Cat_Periodos
                .Caption = "Control de Periodos para Cartera"
                .Top = MenuCartera.Top + MenuCartera.Height
                .Left = MenuCartera.Left
                .Show
            End With

        Case 8:
            With CC_Cat_Clientes
                .Caption = "Clasificación de Clientes para Cartera"
                .Top = MenuCartera.Top + MenuCartera.Height
                .Left = MenuCartera.Left
                .Show
            End With
            
        Case 9:
            With CC_Cat_Ejecutivo
                .Caption = "Ejecutivos de Cuenta"
                .Top = MenuCartera.Top + MenuCartera.Height
                .Left = MenuCartera.Left
                .Show
            End With
            
        Case Else:
            MsgBox "¡ Módulo en construcción !", vbInformation + vbOKOnly, App.Title
    End Select
End Sub

Private Sub ImgeMenu_MouseMove(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
On Error Resume Next
    PintaBotones True, Index
End Sub

Private Sub MenuXPB_MouseMove(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
On Error Resume Next
    For i = 0 To MenuXPB.Count - 1
        MenuXPB.Item(i + 4).BackColor = IIf(Index = i + 4, &HEEEEEE, vbWhite)
    Next
End Sub

Private Sub PintaBotones(Opc As Boolean, Index As Integer)
On Error Resume Next
    If Index <> IndexAnterior Then
       '    ImgeMenu(4).Picture = LoadPicture(App.Path & "\Imagenes\Cat01.jpg")
       ImgeMenu(5).Picture = LoadPicture(App.Path & "\Imagenes\CCat01.jpg")
       ImgeMenu(6).Picture = LoadPicture(App.Path & "\Imagenes\CCat02.jpg")
       ImgeMenu(7).Picture = LoadPicture(App.Path & "\Imagenes\CCat03.jpg")
       ImgeMenu(8).Picture = LoadPicture(App.Path & "\Imagenes\CCat04.jpg")
       'ImgeMenu(5).Picture = LoadPicture(App.Path & "\Imagenes\Herramientas.jpg")
       
       If Opc Then
           Select Case Index
    '           Case 4: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Cat012.jpg")
               Case 5: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\CCat012.jpg")
               Case 6: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\CCat022.jpg")
               Case 7: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\CCat032.jpg")
               Case 8: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\CCat042.jpg")
               'Case 5: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Herramientas2.jpg")
           End Select
            IndexAnterior = Index
        Else
            IndexAnterior = -1
        End If
    End If
End Sub

