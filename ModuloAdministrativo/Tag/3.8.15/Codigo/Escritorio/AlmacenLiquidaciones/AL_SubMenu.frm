VERSION 5.00
Begin VB.Form AL_SubMenu 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   0  'None
   Caption         =   "Form1"
   ClientHeight    =   2655
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   1800
   LinkTopic       =   "Form1"
   MDIChild        =   -1  'True
   Picture         =   "AL_SubMenu.frx":0000
   ScaleHeight     =   2655
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
      Y1              =   2640
      Y2              =   2640
   End
   Begin VB.Line Line2 
      X1              =   1770
      X2              =   1770
      Y1              =   2740
      Y2              =   0
   End
   Begin VB.Line Line1 
      X1              =   0
      X2              =   0
      Y1              =   2740
      Y2              =   0
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   4
      Left            =   0
      Picture         =   "AL_SubMenu.frx":0A2B
      Top             =   120
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   5
      Left            =   0
      Picture         =   "AL_SubMenu.frx":0CF0
      Top             =   480
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   6
      Left            =   0
      Picture         =   "AL_SubMenu.frx":0FF7
      Top             =   840
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   7
      Left            =   0
      Picture         =   "AL_SubMenu.frx":136D
      Top             =   1200
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   8
      Left            =   0
      Picture         =   "AL_SubMenu.frx":1860
      Top             =   1560
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   9
      Left            =   0
      Picture         =   "AL_SubMenu.frx":1B0D
      Top             =   1920
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   10
      Left            =   0
      Picture         =   "AL_SubMenu.frx":1EA3
      Top             =   2280
      Width           =   1770
   End
End
Attribute VB_Name = "AL_SubMenu"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Load()
On Error Resume Next
    IndexAnterior = -1
End Sub

Private Sub Form_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
On Error Resume Next
    PintaBotones False, -1
End Sub

Private Sub ImgeMenu_Click(Index As Integer)
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    Unload Me
    Select Case Index
           Case 4:
                If Not ValidaModulo("CATCTE", False) Then
                    MsgBox "¡ El usuario " & Usuario & " no tiene acceso a esta opción !", vbInformation + vbOKOnly, App.Title
                    Exit Sub
                End If
                With AL_Cat_Clientes
                    '.LblTitulo.Caption = "Control de Catálogos de Clientes"
                    '.Caption = .LblTitulo.Caption
                    .Top = MenuAlmacen.Top + MenuAlmacen.Height
                    .Left = MenuAlmacen.Left
                    .Show
                End With
            Case 5:
                If Not ValidaModulo("CATPROD", False) Then
                    MsgBox "¡ El usuario " & Usuario & " no tiene acceso a esta opción !", vbInformation + vbOKOnly, App.Title
                    Exit Sub
                End If
                With AL_Cat_Productos
                    '.LblTitulo.Caption = "Control de Catálogos de Productos"
                    '.Caption = .LblTitulo.Caption
                    .Top = MenuAlmacen.Top + MenuAlmacen.Height
                    .Left = MenuAlmacen.Left
                    .Show
                End With
            Case 7:
                If Not ValidaModulo("CATRUTA", False) Then
                    MsgBox "¡ El usuario " & Usuario & " no tiene acceso a esta opción !", vbInformation + vbOKOnly, App.Title
                    Exit Sub
                End If
                With AL_Cat_VenRutUni
                    '.LblTitulo.Caption = "Control de Catálogos de Ventas"
                    '.Caption = .LblTitulo.Caption
                    .Top = MenuAlmacen.Top + MenuAlmacen.Height
                    .Left = MenuAlmacen.Left
                    .Show
                End With
            Case 6:
                If Not ValidaModulo("CATPRODOTR", False) Then
                    MsgBox "¡ El usuario " & Usuario & " no tiene acceso a esta opción !", vbInformation + vbOKOnly, App.Title
                    Exit Sub
                End If
                With AL_Cat_TipoProd
                    .LblTitulo.Caption = "Control de Catálogos Tipo de Productos"
                    '.Caption = .LblTitulo.Caption
                    .Top = MenuAlmacen.Top + MenuAlmacen.Height
                    .Left = MenuAlmacen.Left
                    .Show
                End With

            Case 8:
                If Not ValidaModulo("CATPREC", False) Then
                    MsgBox "¡ El usuario " & Usuario & " no tiene acceso a esta opción !", vbInformation + vbOKOnly, App.Title
                    Exit Sub
                End If
                With AL_Cat_Precios
                    .Top = MenuAlmacen.Top + MenuAlmacen.Height
                    .Left = MenuAlmacen.Left
                    .Show
                End With
    
            Case 9:
                If Not ValidaModulo("CATALM", False) Then
                    MsgBox "¡ El usuario " & Usuario & " no tiene acceso a esta opción !", vbInformation + vbOKOnly, App.Title
                    Exit Sub
                End If
                With AL_Cat_Almacen
                    .Top = MenuAlmacen.Top + MenuAlmacen.Height
                    .Left = MenuAlmacen.Left
                    .Show
                End With
            
            Case 10:
                If Not ValidaModulo("TCAMB", False) Then
                    MsgBox "¡ El usuario " & Usuario & " no tiene acceso a esta opción !", vbInformation + vbOKOnly, App.Title
                    Exit Sub
                End If
                With AL_TipoCambio
                    .Top = MenuAlmacen.Top + MenuAlmacen.Height
                    .Left = MenuAlmacen.Left
                    .Show
                End With
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
        ImgeMenu(4).Picture = LoadPicture(App.Path & "\Imagenes\Cat01.gif")
        ImgeMenu(5).Picture = LoadPicture(App.Path & "\Imagenes\Cat02.gif")
        ImgeMenu(6).Picture = LoadPicture(App.Path & "\Imagenes\Cat03.gif")
        ImgeMenu(7).Picture = LoadPicture(App.Path & "\Imagenes\Cat04.gif")
        ImgeMenu(8).Picture = LoadPicture(App.Path & "\Imagenes\Cat05.gif")
        ImgeMenu(9).Picture = LoadPicture(App.Path & "\Imagenes\Cat06.gif")
        ImgeMenu(10).Picture = LoadPicture(App.Path & "\Imagenes\Cat07.gif")
        
        If Opc Then
            Select Case Index
                Case 4: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Cat012.gif")
                Case 5: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Cat022.gif")
                Case 6: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Cat032.gif")
                Case 7: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Cat042.gif")
                Case 8: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Cat052.gif")
                Case 9: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Cat062.gif")
                Case 10: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Cat072.gif")
            End Select
            IndexAnterior = Index
        Else
            IndexAnterior = -1
        End If
    End If
End Sub

