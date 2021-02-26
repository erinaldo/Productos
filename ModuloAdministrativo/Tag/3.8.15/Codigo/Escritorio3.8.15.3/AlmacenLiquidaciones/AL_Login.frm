VERSION 5.00
Begin VB.Form Login 
   BackColor       =   &H00FFFFFF&
   Caption         =   "ITAnswers - Product Distribution Control"
   ClientHeight    =   2550
   ClientLeft      =   165
   ClientTop       =   555
   ClientWidth     =   6135
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   9.75
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "AL_Login.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   2550
   ScaleWidth      =   6135
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton btnSalir 
      BackColor       =   &H00FFFFFF&
      Cancel          =   -1  'True
      Caption         =   "&Salir"
      Height          =   375
      Left            =   4200
      Style           =   1  'Graphical
      TabIndex        =   6
      Top             =   1680
      Width           =   1095
   End
   Begin VB.CommandButton btnIngresar 
      BackColor       =   &H00FFFFFF&
      Caption         =   "&Entrar"
      Default         =   -1  'True
      Height          =   375
      Left            =   4200
      Style           =   1  'Graphical
      TabIndex        =   5
      Top             =   1200
      Width           =   1095
   End
   Begin VB.TextBox TxtPassword 
      Height          =   375
      IMEMode         =   3  'DISABLE
      Left            =   1800
      MaxLength       =   15
      PasswordChar    =   "*"
      TabIndex        =   1
      Top             =   1680
      Width           =   2175
   End
   Begin VB.TextBox TxtLogin 
      Height          =   375
      Left            =   1800
      MaxLength       =   15
      TabIndex        =   0
      Top             =   1200
      Width           =   2175
   End
   Begin VB.Label LblData 
      Alignment       =   2  'Center
      BackColor       =   &H00FFFFFF&
      BackStyle       =   0  'Transparent
      Caption         =   "Versión del Sistema"
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
      Left            =   240
      TabIndex        =   7
      Top             =   2280
      Width           =   5715
   End
   Begin VB.Label Label1 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Contraseña"
      Height          =   255
      Left            =   360
      TabIndex        =   4
      Top             =   1680
      Width           =   1215
   End
   Begin VB.Label Label13 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Usuario"
      Height          =   255
      Left            =   360
      TabIndex        =   3
      Top             =   1200
      Width           =   1215
   End
   Begin VB.Line LineSep 
      BorderColor     =   &H008A7A61&
      X1              =   0
      X2              =   6120
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
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   2
      Top             =   1200
      Visible         =   0   'False
      Width           =   5715
   End
   Begin VB.Image Image4 
      Height          =   300
      Left            =   4200
      Picture         =   "AL_Login.frx":16B2
      Top             =   360
      Width           =   1485
   End
   Begin VB.Image ImgLogo 
      Height          =   810
      Left            =   240
      Picture         =   "AL_Login.frx":1E38
      Stretch         =   -1  'True
      Top             =   120
      Width           =   1800
   End
End
Attribute VB_Name = "Login"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub btnIngresar_Click()
    If Trim(TxtLogin.Text) = "" Or Trim(TxtPassword.Text) = "" Then
        MsgBox "¡ Teclee su Usuario y Contraseña !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    Usuario = Trim(UCase(TxtLogin.Text))
    Password = Trim(UCase(TxtPassword.Text))
    
    StrCmd = "execute sel_ValidaUsuario '" & Trim(UCase(TxtLogin.Text)) & "', '" & Trim(UCase(TxtPassword.Text)) & "'"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    If Rs.EOF Then
        MsgBox "¡ Usuario o contraseña no válidos !", vbInformation + vbOKOnly, App.Title
        TxtPassword.Text = ""
        Exit Sub
    Else
        Unload Me
        With Inicial
            .LblUsuario.Caption = UCase(Rs.Fields(0))
            .Show vbModal
        End With
    End If
End Sub

Private Sub btnSalir_Click()
    If Cnn.State Then Cnn.Close
    End
End Sub

Private Sub Form_Load()
''on error GoTo Err_Inicio:

    Dim Img As Image
    
    ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
    
    Conexion
    If Not Cnn.State Then OpenConn Server, Db, "ITAPDC", "itapdc"
    
    ' valida versión
    StrCmd = "select Mayor, Menor, Revision from Version "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Rs.EOF Then
        MousePointer = 0
        MsgBox "¡ No hay una versión de sistema registrada !." & Chr(13) & Chr(10) & "La versión que debe tener es la: " & Rs.Fields(0) & "." & Rs.Fields(1) & "." & Rs.Fields(2) & ". Actualice.", vbCritical + vbOKOnly, App.Title
        End
    Else
        If CInt(App.Major) <> CInt(Rs.Fields(0)) Then
            MousePointer = 0
            MsgBox "La versión del sistema con la que está trabajando está obsoleta, favor de actualizar." & Chr(13) & Chr(10) & "La versión que debe tener es la: " & Rs.Fields(0) & "." & Rs.Fields(1) & "." & Rs.Fields(2) & ". Actualice.", vbCritical + vbOKOnly, App.Title
            End
        Else
            If CInt(App.Minor) <> CInt(Rs.Fields(1)) Then
                MousePointer = 0
                MsgBox "La versión del sistema con la que está trabajando está obsoleta, favor de actualizar." & Chr(13) & Chr(10) & "La versión que debe tener es la: " & Rs.Fields(0) & "." & Rs.Fields(1) & "." & Rs.Fields(2) & ". Actualice.", vbCritical + vbOKOnly, App.Title
                End
            Else
                If CInt(App.Revision) <> CInt(Rs.Fields(2)) Then
                    MousePointer = 0
                    MsgBox "La versión del sistema con la que está trabajando está obsoleta, favor de actualizar." & Chr(13) & Chr(10) & "La versión que debe tener es la: " & Rs.Fields(0) & "." & Rs.Fields(1) & "." & Rs.Fields(2) & ". Actualice.", vbCritical + vbOKOnly, App.Title
                    End
                End If
            End If
        End If
    End If
    
    
    MousePointer = 11
    LblData(1).Caption = "ITAnswers Versión del Sistema: " & App.Major & "." & App.Minor & "." & App.Revision
    
No_Err_Inicio:
    MousePointer = 0
    Exit Sub
    
Err_Inicio:
    MousePointer = 0
    MsgBox "Error al iniciar el sistema. Error: " & Err.Description, vbCritical + vbOKOnly, App.Title
    GoTo No_Err_Inicio:
End Sub

Private Sub TxtLogin_GotFocus()
    SelText TxtLogin
End Sub

Private Sub TxtLogin_KeyPress(KeyAscii As Integer)
        'MsgBox KeyAscii
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtPassword_GotFocus()
    SelText TxtPassword
End Sub

Private Sub TxtPassword_KeyPress(KeyAscii As Integer)
    KeyAscii = itString(KeyAscii)
End Sub

