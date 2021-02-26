VERSION 5.00
Begin VB.Form MenuCartera 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   0  'None
   Caption         =   "ITAnswers - Cuentas por Cobrar"
   ClientHeight    =   765
   ClientLeft      =   2580
   ClientTop       =   45
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
   Icon            =   "MenuCartera.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   765
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
      Left            =   11280
      Style           =   1  'Graphical
      TabIndex        =   11
      Top             =   1995
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
      Top             =   1995
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
      Top             =   1995
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
      Top             =   1995
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
      Top             =   1995
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
      Top             =   1995
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
      Top             =   1995
      Width           =   1815
   End
   Begin VB.Frame frmData 
      BackColor       =   &H00FFFFFF&
      Height          =   400
      Left            =   10
      TabIndex        =   0
      Top             =   2775
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
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   6
      Left            =   0
      Picture         =   "MenuCartera.frx":0ECA
      Top             =   0
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   5
      Left            =   10800
      Picture         =   "MenuCartera.frx":1439
      Top             =   0
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   360
      Index           =   0
      Left            =   1800
      Picture         =   "MenuCartera.frx":19DD
      Stretch         =   -1  'True
      Top             =   0
      Width           =   1785
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   1
      Left            =   3600
      Picture         =   "MenuCartera.frx":2059
      Top             =   0
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   2
      Left            =   5400
      Picture         =   "MenuCartera.frx":25F0
      Top             =   0
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   3
      Left            =   7200
      Picture         =   "MenuCartera.frx":2CC8
      Top             =   0
      Width           =   1770
   End
   Begin VB.Image ImgeMenu 
      Height          =   345
      Index           =   4
      Left            =   9000
      Picture         =   "MenuCartera.frx":31E9
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
      ForeColor       =   &H00000000&
      Height          =   255
      Index           =   3
      Left            =   10320
      TabIndex        =   9
      Top             =   480
      Width           =   1395
   End
   Begin VB.Line LineSup 
      BorderColor     =   &H008A7A61&
      Visible         =   0   'False
      X1              =   2400
      X2              =   4440
      Y1              =   2040
      Y2              =   2040
   End
   Begin VB.Line LineSep 
      BorderColor     =   &H008A7A61&
      Visible         =   0   'False
      X1              =   480
      X2              =   2520
      Y1              =   1680
      Y2              =   1680
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
      ForeColor       =   &H00000000&
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   3
      Top             =   480
      Width           =   3915
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
      ForeColor       =   &H00000000&
      Height          =   255
      Index           =   1
      Left            =   4200
      TabIndex        =   2
      Top             =   480
      Width           =   3315
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
      ForeColor       =   &H00000000&
      Height          =   255
      Index           =   2
      Left            =   7800
      TabIndex        =   1
      Top             =   480
      Width           =   2235
   End
   Begin VB.Image Image4 
      Height          =   300
      Left            =   2400
      Picture         =   "MenuCartera.frx":374D
      Top             =   1680
      Visible         =   0   'False
      Width           =   1485
   End
   Begin VB.Image Image2 
      Height          =   285
      Left            =   8880
      Picture         =   "MenuCartera.frx":3ED3
      Top             =   1680
      Visible         =   0   'False
      Width           =   3360
   End
   Begin VB.Image ImgLogo 
      Height          =   810
      Left            =   120
      Picture         =   "MenuCartera.frx":4AD1
      Stretch         =   -1  'True
      Top             =   1560
      Visible         =   0   'False
      Width           =   1680
   End
   Begin VB.Image Image1 
      Height          =   360
      Left            =   -120
      Picture         =   "MenuCartera.frx":76D3
      Stretch         =   -1  'True
      Top             =   0
      Width           =   22200
   End
   Begin VB.Image Image3 
      Height          =   405
      Left            =   -120
      Picture         =   "MenuCartera.frx":7C10
      Stretch         =   -1  'True
      Top             =   360
      Width           =   22200
   End
End
Attribute VB_Name = "MenuCartera"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Activate()
On Error Resume Next
    IndexAnterior = -1
End Sub

Private Sub Form_Load()

On Error Resume Next
    
    ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
    AccesoCPC = True
    
    IndexAnterior = -1
    'Llena Barra de estado
    LblData(0).Caption = "Cedis " & Format(IdCedis, "00") & " - " & NomCedis
    LblData(1).Caption = DescTipoUsuario & ": " & Usuario
    LblData(2).Caption = Format(Date, "DDDD dd ""de"" MMMM ""de"" yyyy")
    LblData(3).Caption = "Route V. " & App.Major & "." & App.Minor & "." & App.Revision
    LineSep.BorderColor = &H8A7A61
        
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    
    StrCmd = "execute sel_ValidaUsuario '" & Usuario & "', '" & Password & "'"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn

    If Rs.EOF Then
        MsgBox "¡ Usuario o contraseña no válidos para el Módulo de Cuentas por Cobrar !", vbInformation + vbOKOnly, App.Title
        MenuCartera.Hide
        MenuCartera.Hide
        Unload MenuCartera
        Exit Sub
    Else
        IdCedis = Rs.Fields(0)
        Usuario = Rs.Fields(1): TipoUsuario = Rs.Fields(6): DescTipoUsuario = Rs.Fields(7)
    
        StrCmd = "execute sel_UsuariosModulos '" & Usuario & "'"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If RsC.EOF Then
'            MsgBox "¡ El Usuario no tiene accesos al Módulo de Cuentas por Cobrar !", vbInformation + vbOKOnly, App.Title
'            TxtPassword.Text = ""
            Exit Sub
        End If
        
        LModulosCPC = RsC.GetRows
    End If
    
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
    Db = DbCxC
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    
    If IsEmpty(LModulosCPC) Then
        StrCmd = "execute sel_usuariosmodulos '" & Usuario & "'"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            LModulosCPC = Rs.GetRows
        Else
            LModulosCPC = Empty
        End If
    End If
    
    If IsEmpty(LModulosCPC) Then
        MsgBox "¡ El usuario " & Usuario & " no tiene acceso a este módulo !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    StrPeriodo = ""
    Select Case Index
        Case 0:
            If Not ValidaModulo("OXXO", True) Then Exit Sub
            With CC_FacturasOxxo
                .Caption = "Facturación Global"
                .Top = MenuCartera.Top + MenuCartera.Height
                .Left = MenuCartera.Left
                .Show
                .ZOrder (0)
            End With
       
        Case 1:
            If Not ValidaModulo("MOVS", True) Then Exit Sub
            With CC_Movimientos
                .Caption = "Aplicación de Movimientos a Facturas"
                .Top = MenuCartera.Top + MenuCartera.Height
                .Left = MenuCartera.Left
                .Show
                .ZOrder (0)
            End With
       
        Case 3:
            If Not ValidaModulo("REPS", True) Then Exit Sub
            With CC_Reportes
                .Top = MenuCartera.Top + MenuCartera.Height
                .Left = MenuCartera.Left
                .Show
                .ZOrder (0)
            End With
            
        Case 4:
            If Not ValidaModulo("CAT", True) Then Exit Sub
            With CC_SubMenu
                .Left = 9830 + 1670
                .Top = 350
                .Show
                .ZOrder (0)
            End With
                
        Case 2:
            If Not ValidaModulo("PROMO", True) Then Exit Sub
            With CC_Promociones
                .Left = MenuCartera.Left
                .Top = MenuCartera.Top + MenuCartera.Height
                .Show
                .ZOrder (0)
            End With
        
        Case 5:
            If Not ValidaModulo("HERR", True) Then Exit Sub
            With CC_Mantenimiento
                .LblTitulo.Caption = "Herramientas del Sistema"
                .Left = MenuCartera.Left
                .Top = MenuCartera.Top + MenuCartera.Height
                .Show
                .ZOrder (0)
            End With
                
        Case 6:
            If Not ValidaModulo("FACT", True) Then Exit Sub
            With CC_FacturasBusqueda
                .Caption = "Impresión de Facturas"
                .Left = MenuCartera.Left
                .Top = MenuCartera.Top + MenuCartera.Height
                .Show
                .ZOrder (0)
            End With
            
        Case Else:
            MsgBox "¡ Módulo en construcción !", vbInformation + vbOKOnly, App.Title
                        
    End Select
End Sub

Private Sub ImgeMenu_DblClick(Index As Integer)
On Error Resume Next
    ImgeMenu_Click Index
End Sub

Private Sub ImgeMenu_MouseMove(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
On Error Resume Next
    If Index <> 4 Then Unload CC_SubMenu
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
    StrPeriodo = ""
    Select Case Index
        Case 0:
            If Not ValidaModulo("OXXO", True) Then Exit Sub
            With CC_FacturasOxxo
                .Caption = "Facturación Global"
                .Top = MenuCartera.Top + MenuCartera.Height
                .Left = MenuCartera.Left
                .Show 0, Me
            End With
       
        Case 1:
            If Not ValidaModulo("MOVS", True) Then Exit Sub
            With CC_Movimientos
                .Caption = "Aplicación de Movimientos a Facturas"
                .Top = MenuCartera.Top + MenuCartera.Height
                .Left = MenuCartera.Left
                .Show 0, Me
            End With
       
        Case 2:
            If Not ValidaModulo("REPS", True) Then Exit Sub
            With CC_Reportes
                .Top = MenuCartera.Top + MenuCartera.Height
                .Left = MenuCartera.Left
                .Show 0, Me
            End With
            
        Case 3:
            If Not ValidaModulo("CAT", True) Then Exit Sub
            With SubMenuCartera
                .Left = MenuCarteraXPB.Item(Index).Left + 150
                .Top = 1420 'MenuCartera.Top + MenuCarteraXPB.Item(Index).Top + MenuCarteraXPB.Item(Index).Height
                .Show 0, Me
            End With
                
        Case 4:
            If Not ValidaModulo("PROMO", True) Then Exit Sub
            With CC_Promociones
                .Left = MenuCartera.Left
                .Top = MenuCartera.Top + MenuCartera.Height
                .Show 0, Me
            End With
        
        Case 5:
            If Not ValidaModulo("HERR", True) Then Exit Sub
            With CC_Mantenimiento
                .LblTitulo.Caption = "Herramientas del Sistema"
                .Left = MenuCartera.Left
                .Top = MenuCartera.Top + MenuCartera.Height
                .Show 0, Me
            End With
                
        Case 6:
            AcercaDe.Show
            
        Case Else:
            MsgBox "¡ Módulo en construcción !", vbInformation + vbOKOnly, App.Title
                        
    End Select
End Sub

Private Sub PintaBotones(Opc As Boolean, Index As Integer)
On Error Resume Next

    If Index <> IndexAnterior Then
        ImgeMenu(0).Picture = LoadPicture(App.Path & "\Imagenes\Facturacion.gif")
        ImgeMenu(1).Picture = LoadPicture(App.Path & "\Imagenes\Movimientos.gif")
        ImgeMenu(2).Picture = LoadPicture(App.Path & "\Imagenes\Promociones.gif")
        ImgeMenu(3).Picture = LoadPicture(App.Path & "\Imagenes\Reportes.gif")
        ImgeMenu(4).Picture = LoadPicture(App.Path & "\Imagenes\Catalogos.gif")
        ImgeMenu(5).Picture = LoadPicture(App.Path & "\Imagenes\Herramientas.gif")
        ImgeMenu(6).Picture = LoadPicture(App.Path & "\Imagenes\FacturaImpresion.gif")
    
        If Opc Then
            Select Case Index
                Case 0: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Facturacion2.gif")
                Case 1: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Movimientos2.gif")
                Case 2: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Promociones2.gif")
                Case 3: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Reportes2.gif")
                Case 4: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Catalogos2.gif")
                Case 5: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\Herramientas2.gif")
                Case 6: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\FacturaImpresion2.gif")
            End Select
            IndexAnterior = Index
        Else
            IndexAnterior = -1
        End If
    End If

End Sub

