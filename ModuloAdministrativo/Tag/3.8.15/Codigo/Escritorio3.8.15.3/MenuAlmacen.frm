VERSION 5.00
Begin VB.Form MenuAlmacen 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   0  'None
   Caption         =   "ITAnswers - Control de Almacén"
   ClientHeight    =   1050
   ClientLeft      =   2580
   ClientTop       =   45
   ClientWidth     =   12660
   ClipControls    =   0   'False
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   9.75
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "MenuAlmacen.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   1050
   ScaleWidth      =   12660
   ShowInTaskbar   =   0   'False
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
      Left            =   7320
      Style           =   1  'Graphical
      TabIndex        =   11
      Top             =   3480
      Visible         =   0   'False
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
      Left            =   6000
      Style           =   1  'Graphical
      TabIndex        =   10
      Top             =   3435
      Width           =   1455
   End
   Begin VB.CommandButton MenuXPB 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      Caption         =   "&Usuarios"
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
      Left            =   4680
      Style           =   1  'Graphical
      TabIndex        =   8
      Top             =   3435
      Width           =   1215
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
      Left            =   3240
      Style           =   1  'Graphical
      TabIndex        =   7
      Top             =   3435
      Width           =   1335
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
      Left            =   1800
      Style           =   1  'Graphical
      TabIndex        =   6
      Top             =   3435
      Width           =   1335
   End
   Begin VB.CommandButton MenuXPB 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      Caption         =   "&Almacén"
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
      Left            =   120
      Style           =   1  'Graphical
      TabIndex        =   5
      Top             =   3435
      Width           =   1575
   End
   Begin VB.CommandButton MenuXPB 
      Appearance      =   0  'Flat
      BackColor       =   &H00FFFFFF&
      Caption         =   "&Liquidaciones"
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
      Left            =   120
      Style           =   1  'Graphical
      TabIndex        =   4
      Top             =   3435
      Visible         =   0   'False
      Width           =   1575
   End
   Begin VB.Frame frmData 
      BackColor       =   &H00FFFFFF&
      Height          =   400
      Left            =   10
      TabIndex        =   0
      Top             =   1815
      Width           =   10035
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
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   6
      Left            =   3720
      Picture         =   "MenuAlmacen.frx":16B2
      Top             =   0
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   5
      Left            =   9120
      Picture         =   "MenuAlmacen.frx":197C
      Top             =   0
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   3
      Left            =   7320
      Picture         =   "MenuAlmacen.frx":1F20
      Top             =   0
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   2
      Left            =   5520
      Picture         =   "MenuAlmacen.frx":2484
      Top             =   0
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   1
      Left            =   1920
      Picture         =   "MenuAlmacen.frx":29A5
      Top             =   0
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   0
      Left            =   120
      Picture         =   "MenuAlmacen.frx":2E99
      Top             =   0
      Width           =   1770
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
      Left            =   10320
      TabIndex        =   9
      Top             =   480
      Width           =   1635
   End
   Begin VB.Line LineSup 
      BorderColor     =   &H008A7A61&
      Visible         =   0   'False
      X1              =   120
      X2              =   2160
      Y1              =   960
      Y2              =   960
   End
   Begin VB.Line LineSep 
      BorderColor     =   &H008A7A61&
      X1              =   0
      X2              =   2040
      Y1              =   1440
      Y2              =   1440
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
      Left            =   480
      TabIndex        =   3
      Top             =   480
      Width           =   3315
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
      Left            =   3480
      TabIndex        =   2
      Top             =   480
      Width           =   3075
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
      Left            =   6840
      TabIndex        =   1
      Top             =   480
      Width           =   3075
   End
   Begin VB.Image Image4 
      Height          =   300
      Left            =   3240
      Picture         =   "MenuAlmacen.frx":345E
      Top             =   2280
      Visible         =   0   'False
      Width           =   1485
   End
   Begin VB.Image Image2 
      Height          =   285
      Left            =   6720
      Picture         =   "MenuAlmacen.frx":3BE4
      Top             =   2280
      Visible         =   0   'False
      Width           =   3360
   End
   Begin VB.Image ImgLogo 
      Height          =   810
      Left            =   240
      Picture         =   "MenuAlmacen.frx":47E2
      Stretch         =   -1  'True
      Top             =   2280
      Width           =   1920
   End
   Begin VB.Image Image3 
      Height          =   405
      Left            =   0
      Picture         =   "MenuAlmacen.frx":6E56
      Stretch         =   -1  'True
      Top             =   360
      Width           =   22200
   End
   Begin VB.Image Image1 
      Height          =   360
      Left            =   0
      Picture         =   "MenuAlmacen.frx":7180
      Stretch         =   -1  'True
      Top             =   0
      Width           =   22200
   End
   Begin VB.Image ImgeMenu 
      Height          =   360
      Index           =   4
      Left            =   10080
      Picture         =   "MenuAlmacen.frx":76BD
      Top             =   480
      Visible         =   0   'False
      Width           =   1785
   End
End
Attribute VB_Name = "MenuAlmacen"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public AccesoValido As Boolean

Private Sub Form_Activate()
On Error Resume Next
    IndexAnterior = -1
End Sub

Private Sub Form_Load()
On Error Resume Next
    IndexAnterior = -1
End Sub

Private Sub Form_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
On Error GoTo Err_SubMenu
    
    PintaBotones False, -1
    
    Unload SubMenu
Err_SubMenu:
    Exit Sub
End Sub

Private Sub Form_Resize()
On Error GoTo Err_Resize
    
    Height = 765: Width = InicialMDI.Width: Left = 2500: Top = 0
    LineSep.X1 = 0: LineSep.X2 = Width - 40: LineSup.X2 = Width - 40

Err_Resize:
    Exit Sub
End Sub

Private Sub FrmOpc_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
On Error Resume Next
    For i = 0 To btnMenu.Count - 1
        btnMenu(i).BackColor = vbWhite
    Next i
End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    If Rs.State Then Rs.Close
End Sub

Private Sub ImgeMenu_Click(Index As Integer)
On Error Resume Next
    
    Db = DbADM
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    Select Case Index
        Case 0:
            If Not ValidaModulo("LIQ", True) Then Exit Sub
            With AL_Liquidacion
                .Caption = "Liquidación de Rutas de Distribución"
                .Top = MenuAlmacen.Top + MenuAlmacen.Height
                .Left = MenuAlmacen.Left
                .Show
                .ZOrder (0)
            End With
        Case 1:
            If Not ValidaModulo("ALM", True) Then Exit Sub
            With AL_Almacen
                .Caption = "Almacén General"
                .Top = MenuAlmacen.Top + MenuAlmacen.Height
                .Left = MenuAlmacen.Left
                .Show
                .ZOrder (0)
            End With
        
        Case 2:
            If Not ValidaModulo("REP", True) Then Exit Sub
            With AL_Reportes
                .Top = MenuAlmacen.Top + MenuAlmacen.Height
                .Left = MenuAlmacen.Left
                .Show
                .ZOrder (0)
            End With
        Case 3:
            If Not ValidaModulo("CAT", True) Then Exit Sub
            With AL_SubMenu
                .Left = 8030 + 1800
                .Top = 350 'Menu.Top + MenuXPB.Item(Index).Top + MenuXPB.Item(Index).Height
                .Show
                .ZOrder (0)
            End With
        Case 4:
            If Not ValidaModulo("USU", True) Then Exit Sub
             With AL_Cat_Usuarios
                 .Caption = "Control de Catálogos de Usuarios"
                 .Top = MenuAlmacen.Top + MenuAlmacen.Height
                 .Left = MenuAlmacen.Left
                 .Show
                 .ZOrder (0)
             End With
        
        Case 5:
            If Not ValidaModulo("HERR", True) Then Exit Sub
            With AL_Mantenimiento
                 .LblTitulo.Caption = "Herramientas del Sistema"
                 .Caption = .LblTitulo.Caption
                 .Top = MenuAlmacen.Top + MenuAlmacen.Height
                 .Left = MenuAlmacen.Left
                 .Show
                 .ZOrder (0)
            End With
        
        Case 6:
            If Not ValidaModulo("PEDID", True) Then Exit Sub
            With AL_Pedidos
                 .Caption = "Captura de Pedidos"
                 .Top = MenuAlmacen.Top + MenuAlmacen.Height
                 .Left = MenuAlmacen.Left
                 .Show
                 .ZOrder (0)
            End With
    End Select
End Sub

Private Sub ImgeMenu_DblClick(Index As Integer)
On Error Resume Next
    ImgeMenu_Click Index
End Sub

Private Sub ImgeMenu_MouseMove(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
On Error Resume Next
    If Index <> 3 Then Unload AL_SubMenu
    PintaBotones True, Index
End Sub

Private Sub MenuXPB_MouseMove(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
On Error Resume Next
    For i = 0 To MenuXPB.Count - 1
        MenuXPB.Item(i).BackColor = IIf(Index = i, &HEEEEEE, vbWhite)
    Next
End Sub

Private Sub MenuXPB_Click(Index As Integer)
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    Select Case Index
        Case 0:
            If Not ValidaModulo("LIQ", True) Then Exit Sub
'            If TipoUsuario = 2 Then
'                MsgBox "¡ El usuario " & Usuario & " no tiene acceso a esta opción !", vbInformation + vbOKOnly, App.Title
'                Exit Sub
'            End If
            With AL_Liquidacion
                .Caption = "Liquidación de Rutas de Distribución"
                .Top = MenuAlmacen.Top + MenuAlmacen.Height
                .Left = MenuAlmacen.Left
                .Show 0, Me
            End With
        Case 1:
            If Not ValidaModulo("ALM", True) Then Exit Sub
'            If TipoUsuario = 2 Then
'                MsgBox "¡ El usuario " & Usuario & " no tiene acceso a esta opción !", vbInformation + vbOKOnly, App.Title
'                Exit Sub
'            End If
            With AL_Almacen
                .Caption = "Almacén del Centro de Distribución"
                .Top = MenuAlmacen.Top + MenuAlmacen.Height
                .Left = MenuAlmacen.Left
                .Show 0, Me
            End With
        
        Case 2:
            If Not ValidaModulo("REP", True) Then Exit Sub
            With AL_Reportes
                .Top = MenuAlmacen.Top + MenuAlmacen.Height
                .Left = MenuAlmacen.Left
                .Show 0, Me
            End With
        Case 3:
            If Not ValidaModulo("CAT", True) Then Exit Sub
            With AL_SubMenu
                .Left = MenuXPB.Item(Index).Left + 150
                .Top = 1420 'Menu.Top + MenuXPB.Item(Index).Top + MenuXPB.Item(Index).Height
                .Show 0, Me
            End With
        Case 4:
            If Not ValidaModulo("USU", True) Then Exit Sub
'             If TipoUsuario <> 0 Then
'                 MsgBox "¡ El usuario " & Usuario & " no tiene acceso a esta opción !", vbInformation + vbOKOnly, App.Title
'                 Exit Sub
'             End If
             With AL_Cat_Usuarios
                 '.LblTitulo.Caption = "Control de Catálogos de Usuarios"
                 .Caption = "Control de Catálogos de Usuarios"
                 .Top = MenuAlmacen.Top + MenuAlmacen.Height
                 .Left = MenuAlmacen.Left
                 .Show
             End With
        
        Case 5:
            If Not ValidaModulo("HERR", True) Then Exit Sub
'            If TipoUsuario <> 0 Then
'                MsgBox "¡ El usuario " & Usuario & " no tiene acceso a esta opción !", vbInformation + vbOKOnly, App.Title
'                Exit Sub
'            End If
            With AL_Mantenimiento
                 .LblTitulo.Caption = "Herramientas del Sistema"
                 .Caption = .LblTitulo.Caption
                 .Top = MenuAlmacen.Top + MenuAlmacen.Height
                 .Left = MenuAlmacen.Left
                 .Show
            End With
        
        Case 6:
            AcercaDe.Show
                        
    End Select
End Sub

Private Sub PintaBotones(Opc As Boolean, Index As Integer)
On Error Resume Next

    If Index <> IndexAnterior Then
        ImgeMenu(0).Picture = LoadPicture(App.Path & "\Imagenes\Liquidaciones.gif")
        ImgeMenu(1).Picture = LoadPicture(App.Path & "\Imagenes\Almacen.gif")
        ImgeMenu(2).Picture = LoadPicture(App.Path & "\Imagenes\Reportes.gif")
        ImgeMenu(3).Picture = LoadPicture(App.Path & "\Imagenes\Catalogos.gif")
        ImgeMenu(4).Picture = LoadPicture(App.Path & "\Imagenes\Usuarios.gif")
        ImgeMenu(5).Picture = LoadPicture(App.Path & "\Imagenes\Herramientas.gif")
        ImgeMenu(6).Picture = LoadPicture(App.Path & "\Imagenes\Pedidos.gif")
        
        If Opc Then
            Select Case Index
                Case 0: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Liquidaciones2.gif")
                Case 1: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Almacen2.gif")
                Case 2: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Reportes2.gif")
                Case 3: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Catalogos2.gif")
                Case 4: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Usuarios2.gif")
                Case 5: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Herramientas2.gif")
                Case 6: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Pedidos2.gif")
            End Select
            IndexAnterior = Index
        Else
            IndexAnterior = -1
        End If
    End If
End Sub

