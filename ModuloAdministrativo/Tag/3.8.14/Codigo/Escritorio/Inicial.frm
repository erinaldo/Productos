VERSION 5.00
Begin VB.Form Inicial 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   0  'None
   Caption         =   "Amesol Route"
   ClientHeight    =   9930
   ClientLeft      =   255
   ClientTop       =   45
   ClientWidth     =   11175
   ClipControls    =   0   'False
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   9
      Charset         =   0
      Weight          =   700
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "Inicial.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   9930
   ScaleWidth      =   11175
   ShowInTaskbar   =   0   'False
   Begin VB.Image ImgLogoADM 
      Height          =   2310
      Left            =   2520
      Picture         =   "Inicial.frx":000C
      Top             =   0
      Width           =   7620
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
      Index           =   0
      Left            =   120
      TabIndex        =   1
      Top             =   120
      Width           =   2235
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
      Left            =   120
      TabIndex        =   0
      Top             =   480
      Width           =   2235
   End
   Begin VB.Image imgLateral 
      Height          =   9015
      Left            =   2380
      Picture         =   "Inicial.frx":47ED
      Stretch         =   -1  'True
      Top             =   0
      Width           =   100
   End
   Begin VB.Image ImgLogo 
      Height          =   870
      Left            =   120
      Picture         =   "Inicial.frx":48F9
      Top             =   1080
      Width           =   2070
   End
   Begin VB.Image ImgeMenu 
      Height          =   795
      Index           =   5
      Left            =   60
      Picture         =   "Inicial.frx":5923
      Top             =   6120
      Width           =   2175
   End
   Begin VB.Image ImgeMenu 
      Height          =   360
      Index           =   4
      Left            =   60
      Picture         =   "Inicial.frx":615B
      Top             =   7080
      Visible         =   0   'False
      Width           =   2010
   End
   Begin VB.Image ImgeMenu 
      Height          =   795
      Index           =   3
      Left            =   60
      Picture         =   "Inicial.frx":67BF
      Top             =   5160
      Width           =   2175
   End
   Begin VB.Image ImgeMenu 
      Height          =   795
      Index           =   2
      Left            =   60
      Picture         =   "Inicial.frx":71E9
      Top             =   4200
      Width           =   2175
   End
   Begin VB.Image ImgeMenu 
      Height          =   795
      Index           =   1
      Left            =   60
      Picture         =   "Inicial.frx":7AAA
      Top             =   3240
      Width           =   2175
   End
   Begin VB.Image ImgeMenu 
      Height          =   795
      Index           =   0
      Left            =   60
      Picture         =   "Inicial.frx":843F
      Top             =   2280
      Width           =   2175
   End
   Begin VB.Image Image3 
      Height          =   405
      Left            =   0
      Picture         =   "Inicial.frx":8C3E
      Stretch         =   -1  'True
      Top             =   360
      Width           =   2520
   End
   Begin VB.Image Image1 
      Height          =   360
      Left            =   0
      Picture         =   "Inicial.frx":8F68
      Stretch         =   -1  'True
      Top             =   0
      Width           =   2520
   End
End
Attribute VB_Name = "Inicial"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub btnExit_Click()
On Error Resume Next
    Unload Me
End Sub

Private Sub Form_Activate()
On Error Resume Next
    If UCase(Db) = "ROUTEADM" Then MenuAlmacen.ZOrder 0
    If UCase(Db) = "ROUTECPC" Then MenuCartera.ZOrder 0
End Sub

Private Sub Form_Load()
On Error Resume Next
    ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
    PintaBotones False, 0
    LblData(1).Caption = Usuario
End Sub

Private Sub Form_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
On Error Resume Next
    PintaBotones False, 0
End Sub

Private Sub Form_Resize()
On Error Resume Next
    Width = InicialMDI.Width
    ImgLogoADM.Left = ((InicialMDI.Width - ImgLogoADM.Width) / 2)
    ImgLogoADM.Top = ((InicialMDI.Height - ImgLogoADM.Height) / 2)

End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    If Cnn.State Then Cnn.Close
    If Cnn2.State Then Cnn2.Close
    End
End Sub

Private Sub ImgeLogo_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
On Error Resume Next
    PintaBotones False, 0
End Sub

Private Sub ImgeMenu_Click(Index As Integer)
On Error Resume Next
    ImgeMenu_DblClick Index
End Sub

Private Sub ImgeMenu_DblClick(Index As Integer)
On Error Resume Next
    
'    Select Case Index
'        Case 0, 1:
'            Unload MenuCartera
'
'            Db = DbADM
'            If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
'            StrCmd = "execute sel_ValidaUsuario 0, '" & Usuario & "', '" & Password & "'"
'            If Rs.State Then Rs.Close
'            Rs.Open StrCmd, Cnn
'
'            If Rs.EOF Then
'                MsgBox "¡ Usuario o contraseña no válidos !", vbInformation + vbOKOnly, App.Title
'                TxtPassword.Text = ""
'                Exit Sub
'            Else
'                IdCedis = Rs.Fields(0)
'                Usuario = Rs.Fields(1): TipoUsuario = Rs.Fields(6): DescTipoUsuario = Rs.Fields(7)
'
'                StrCmd = "exec sel_Configuracion " & IdCedis & ", 1"
'                If Rs.State Then Rs.Close
'                Rs.Open StrCmd, Cnn
'                If Not Rs.EOF Then
'                    IdCedis = Rs.Fields(0): NomCedis = Trim(UCase(Rs.Fields(1))): Route = Rs.Fields(2)
'                    ImportarCargaSugerida = IIf(Rs.Fields(3) = "S", True, False)
'                    Etiqueta01 = Rs.Fields(4): Etiqueta02 = Rs.Fields(5)
'                    RFCCedis = Rs.Fields(6): RazonSocialCedis = Rs.Fields(7): DireccionFiscalCedis = Rs.Fields(8)
'                    CPC = IIf(Trim(Rs.Fields(9)) = "S", True, False)
'                    ReDim LstConfiguraLiquidacion(4)
'                    For i = 10 To 14
'                        LstConfiguraLiquidacion(i - 10) = Rs.Fields(i)
'                    Next i
'                End If
'            End If
'    End Select
    
    Select Case Index
        Case 0:
            Db = DbCxC: MenuCartera.Hide
            Db = DbADM: MenuAlmacen.Show
            If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
            If Not ValidaModulo("ALM", True) Then Exit Sub
            With MenuAlmacen
                .Caption = "Administración del Almacén General"
'                If .AccesoValido Then
                    With AL_Almacen
                        .Caption = "Almacén General"
                        .Top = MenuAlmacen.Top + MenuAlmacen.Height
                        .Left = MenuAlmacen.Left
                        .Show
                        .ZOrder 0
                    End With
 '               End If
            End With
        Case 1:
            Db = DbCxC: MenuCartera.Hide
            Db = DbADM: MenuAlmacen.Show
            If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
            If Not ValidaModulo("LIQ", True) Then Exit Sub
            With MenuAlmacen
                .Caption = "Liquidación de Rutas de Distribución"
'                If .AccesoValido Then
                    With AL_Liquidacion
                        .Caption = "Liquidación de Rutas de Distribución"
                        .Top = MenuAlmacen.Top + MenuAlmacen.Height
                        .Left = MenuAlmacen.Left
                        .Show
                        .ZOrder 0
                    End With
'                End If
            End With
         Case 2:
            Db = DbADM: MenuAlmacen.Show
            Db = DbCxC: MenuCartera.Hide
            If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
            If Not ValidaModulo("COM", True) Then Exit Sub
            With COM_AsignaComisiones
                .Top = 760
                .Left = 2500
                .Caption = "Asignación de Comisiones"
                .Show
                .ZOrder 0
            End With
            
        Case 3:
            
            If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
            
            Db = DbADM: MenuAlmacen.Hide
            Db = DbCxC: MenuCartera.Show
            If CPC Then
                With MenuCartera
                    .Caption = "Cartera de Clientes"
                    .Show
                    .ZOrder 0
                End With
            Else
                MsgBox "¡ El módulo Cuentas por Cobrar no está habilitado !", vbInformation + vbOKOnly, App.Title
            End If
        
        Case 4:
            If Trim(URL) = "" Then
                MsgBox "¡ No hay una URL asignada para los indicadores Web !", vbInformation + vbOKOnly, App.Title
            Else
                Shell "C:\WINDOWS\ie7\iexplore.exe """ & URL & """", vbMaximizedFocus
            End If
        Case 5:
            Db = DbADM
            If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
            If Not ValidaModulo("USU", True) Then Exit Sub
            With AL_Cat_Usuarios
                .Top = 760
                .Left = 2500
                .Caption = "Control de Usuarios"
                .Show
                .ZOrder 0
            End With
                    
    End Select
End Sub

Private Sub ImgeMenu_MouseMove(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
On Error Resume Next
    PintaBotones True, Index
End Sub

Private Sub PintaBotones(Opc As Boolean, Index As Integer)
On Error Resume Next
    ImgeMenu(0).Picture = LoadPicture(App.Path & "\Imagenes\btnInventarios.jpg")
    ImgeMenu(1).Picture = LoadPicture(App.Path & "\Imagenes\btnLiquidacion.jpg")
    ImgeMenu(2).Picture = LoadPicture(App.Path & "\Imagenes\btnComisiones.jpg")
    ImgeMenu(3).Picture = LoadPicture(App.Path & "\Imagenes\btnCartera.jpg")
'    ImgeMenu(4).Picture = LoadPicture(App.Path & "\Imagenes\btnWeb.jpg")
    ImgeMenu(5).Picture = LoadPicture(App.Path & "\Imagenes\btnUsuarios.jpg")
    
    If Opc Then
        Select Case Index
            Case 0: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\btnInventarios2.jpg")
            Case 1: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\btnLiquidacion2.jpg")
            Case 2: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\btnComisiones2.jpg")
            Case 3: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\btnCartera2.jpg")
'            Case 4: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\btnWeb2.jpg")
            Case 5: ImgeMenu(Index).Picture = LoadPicture(App.Path & "\Imagenes\btnUsuarios2.jpg")
        End Select
    End If
End Sub

Private Sub LblMenu_Click(Index As Integer)
    ImgeMenu_Click Index
End Sub
