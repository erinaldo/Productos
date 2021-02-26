VERSION 5.00
Begin VB.Form Login 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "AMESOL México - Administración de Cedis"
   ClientHeight    =   2175
   ClientLeft      =   150
   ClientTop       =   540
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
   Icon            =   "Login.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2175
   ScaleWidth      =   6135
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton btnSalir 
      BackColor       =   &H00FFFFFF&
      Cancel          =   -1  'True
      Height          =   375
      Left            =   4200
      Picture         =   "Login.frx":08CA
      Style           =   1  'Graphical
      TabIndex        =   6
      Top             =   1680
      Width           =   1215
   End
   Begin VB.CommandButton btnIngresar 
      BackColor       =   &H00FFFFFF&
      Default         =   -1  'True
      Height          =   375
      Left            =   3000
      Picture         =   "Login.frx":0E2F
      Style           =   1  'Graphical
      TabIndex        =   5
      Top             =   1680
      Width           =   1095
   End
   Begin VB.TextBox TxtPassword 
      Height          =   375
      IMEMode         =   3  'DISABLE
      Left            =   3720
      MaxLength       =   15
      PasswordChar    =   "*"
      TabIndex        =   1
      Top             =   1080
      Width           =   2175
   End
   Begin VB.TextBox TxtLogin 
      Height          =   375
      Left            =   3720
      MaxLength       =   8
      TabIndex        =   0
      Top             =   600
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
      Top             =   2400
      Width           =   5715
   End
   Begin VB.Label Label1 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Contraseña"
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
      Left            =   2400
      TabIndex        =   4
      Top             =   1080
      Width           =   1215
   End
   Begin VB.Label Label13 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Usuario"
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
      Left            =   2400
      TabIndex        =   3
      Top             =   600
      Width           =   1215
   End
   Begin VB.Line LineSep 
      BorderColor     =   &H008A7A61&
      Visible         =   0   'False
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
      Picture         =   "Login.frx":1304
      Top             =   360
      Visible         =   0   'False
      Width           =   1485
   End
   Begin VB.Image ImgLogo 
      Height          =   1740
      Left            =   240
      Picture         =   "Login.frx":1A8A
      Top             =   240
      Width           =   1755
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
    Password = Trim(TxtPassword.Text)
    
    StrCmd = "execute sel_ValidaUsuario 0, '" & Usuario & "', '" & Password & "'"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    If Rs.EOF Then
        MsgBox "¡ Usuario o contraseña no válidos !", vbInformation + vbOKOnly, App.Title
        TxtPassword.Text = ""
        Exit Sub
    Else
        IdCedis = Rs.Fields(0)
        Usuario = Rs.Fields(1): TipoUsuario = Rs.Fields(6): DescTipoUsuario = Rs.Fields(7)
        
        If CFDCedis = "1" Then RutaXML = ObtieneRutaXML
        
        With MenuAlmacen
            StrCmd = "exec sel_Configuracion " & IdCedis & ", 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            If Rs.EOF Then
                .LblData.Item(0).Caption = "No se encontrón un Centro de Distribución que corresponda a la Instalación."
                Etiqueta01 = "": Etiqueta02 = "": ImportarCargaSugerida = False
                RFCCedis = "": RazonSocialCedis = "": DireccionFiscalCedis = ""
            Else
                .LblData.Item(0).Caption = "Cedis:   " & Rs.Fields(0) & " - " & Trim(UCase(Rs.Fields(1)))
                IdCedis = Rs.Fields(0): NomCedis = Trim(UCase(Rs.Fields(1))): Route = Rs.Fields(2)
                ImportarCargaSugerida = IIf(Rs.Fields(3) = "S", True, False)
                Etiqueta01 = Rs.Fields(4): Etiqueta02 = Rs.Fields(5)
                RFCCedis = Rs.Fields(6): RazonSocialCedis = Rs.Fields(7): DireccionFiscalCedis = Rs.Fields(8)
                CPC = IIf(Trim(Rs.Fields(9)) = "S", True, False)
                ReDim LstConfiguraLiquidacion(5)
                For i = 10 To 15
                    LstConfiguraLiquidacion(i - 10) = Rs.Fields(i)
                Next i
            End If
                
            .AccesoValido = False
            StrCmd = "execute sel_UsuariosModulos " & IdCedis & ", '" & Usuario & "'"
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
            If RsC.EOF Then
                MsgBox "¡ El Usuario no tiene accesos al Módulo de Inventarios !", vbInformation + vbOKOnly, App.Title
                .AccesoValido = False
            Else
                .AccesoValido = True
            End If
            If .AccesoValido Then LModulos = RsC.GetRows
            
            .LblData(1).Caption = "Amesol Route Versión del Sistema: " & App.Major & "." & App.Minor & "." & App.Revision
            .LblData(0).Caption = "Cedis " & Format(IdCedis, "00") & " - " & NomCedis
            .LblData(1).Caption = "Usuario: " & Usuario
            .LblData(2).Caption = Format(Date, "DDDD dd ""de"" MMMM ""de"" yyyy")
            .LblData(3).Caption = "Route V. " & App.Major & "." & App.Minor & "." & App.Revision
            .LineSep.BorderColor = &H8A7A61
        End With
        
        Unload Me
        With InicialMDI
            .Show
        End With
    End If
End Sub

Private Sub btnSalir_Click()
On Error Resume Next
    If Cnn.State Then Cnn.Close
    End
End Sub

Private Sub Form_DblClick()
On Error Resume Next

    Exit Sub
    If Not Cnn.State Then OpenConn Server, "RouteADM", UserDB, PasswordDB
    
    MousePointer = 11
    
    Dim i As Date, j As Date, IdPeriodo, IdSemanaNat, IdSemanaLab, IdSemana, DiasMes, Mes
    Dim NatIni As Date, NatFin As Date
    Dim LabIni As Date, LabFin As Date
    
    IdSemanaNat = 3: IdPeriodo = 10: IdSemanaLab = 2: IdSemana = 525
    NatIni = CDate("10/01/2010"): NatFin = CDate("16/01/2010")
    LabIni = CDate("07/01/2010"): LabFin = CDate("13/01/2010")
    DiasMes = 8: Mes = 1
    
    i = CDate("11/01/2010")
    j = CDate("15/03/2010")
    While i < j
        
        IdPeriodo = IdPeriodo + 1
        If Weekday(i) = 1 Then
            NatIni = NatIni + 7: NatFin = NatFin + 7
            IdSemanaNat = IdSemanaNat + 1
            IdSemana = IdSemana + 1
        Else
            DiasMes = DiasMes + 1
        End If
        
        If Weekday(i) = 5 Then
            LabIni = LabIni + 7: LabFin = LabFin + 7
            IdSemanaLab = IdSemanaLab + 1
        End If
        
        If Month(i) <> Mes Then
            StrCmd = "update Periodos set Per_DiasHab = " & DiasMes - 1 & " where month(Per_Fecha)= " & Mes & " and year(Per_Fecha) = " & Year(i - 1)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            
            DiasMes = 0
            Mes = Month(i)
        End If
        
        StrCmd = "insert into Periodos values (" & IdPeriodo & ", '" & FormatDate(i) & "', " & IdSemana & ", " & IdSemanaNat & ", " & _
        IdSemanaLab & ", " & Weekday(i) & ", '" & Format(Weekday(i), "DDDD") & "', " & Month(i) & ", '" & Format(i, "MMMM") & "', " & _
        DiasMes & ", '" & FormatDate(NatIni) & "', '" & FormatDate(NatFin) & "', '" & FormatDate(LabIni) & "', '" & FormatDate(LabFin) & "', '" & IIf(Weekday(i) = 1, "A", "L") & "')"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
'        Debug.Print StrCmd
                
        i = i + 1
    Wend
    MousePointer = 0
    MsgBox "¡ Periodos generads con éxito !", vbInformation, App.Title
End Sub

Private Sub Form_Load()
On Error GoTo Err_Inicio:

    Dim Img As Image
    
'If docXML.Load(App.Path & "\Prueba.xml") Then
'    Me.TxtLogin.Text = docXML.childNodes.Item(1).childNodes(0).Text
'Else
'    MsgBox "Archivo de configuración no encontrado o con formato erroneo"
'    Exit Sub
'End If

    ImgLogo.Picture = LoadPicture(App.Path & "\LogoAmesol.jpg")
    
    Conexion
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    
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
    
    'Licencia
    '********************************** Validacion de Licenciamiento ********************************
    
    Dim FechaServer As Date, FechaPDC As Date
    StrCmd = "SELECT isnull(max(Fecha),getdate()) as UltimaFechaPDC, getdate() as FechaServer From StatusDia"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn

    If Rs.EOF Then
        FechaServer = Date
        FechaPDC = Date
    Else
        FechaServer = Rs!FechaServer.Value
        FechaPDC = Rs!UltimaFechaPDC.Value
    End If
    
    If Not LicenciaValida(FechaPDC, FechaServer) Then End
    
    MousePointer = 11
    LblData(1).Caption = "Amesol Route. Versión del Sistema: " & App.Major & "." & App.Minor & "." & App.Revision
    
No_Err_Inicio:
    MousePointer = 0
    Exit Sub
    
Err_Inicio:
    MousePointer = 0
    MsgBox "Error al iniciar el sistema. Error: " & Err.Description, vbCritical + vbOKOnly, App.Title
    GoTo No_Err_Inicio:
End Sub

Private Sub TxtLogin_GotFocus()
On Error Resume Next
    SelText TxtLogin
End Sub

Private Sub TxtLogin_KeyPress(KeyAscii As Integer)
'    MsgBox KeyAscii
'    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtPassword_GotFocus()
On Error Resume Next
    SelText TxtPassword
End Sub

Private Sub TxtPassword_KeyPress(KeyAscii As Integer)
    'KeyAscii = itString(KeyAscii)
End Sub

