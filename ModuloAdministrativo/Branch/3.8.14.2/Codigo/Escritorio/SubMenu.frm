VERSION 5.00
Begin VB.Form SubMenu 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   0  'None
   Caption         =   "Form1"
   ClientHeight    =   3300
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   2025
   LinkTopic       =   "Form1"
   ScaleHeight     =   3300
   ScaleWidth      =   2025
   ShowInTaskbar   =   0   'False
   Begin VB.Frame FrmCatalogos 
      BackColor       =   &H00FFFFFF&
      Height          =   3135
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   1815
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
         Left            =   120
         Style           =   1  'Graphical
         TabIndex        =   5
         Top             =   2520
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
         Left            =   120
         Style           =   1  'Graphical
         TabIndex        =   4
         Top             =   1680
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
         Left            =   120
         Style           =   1  'Graphical
         TabIndex        =   3
         Top             =   1200
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
         Left            =   120
         Style           =   1  'Graphical
         TabIndex        =   2
         Top             =   720
         Width           =   1575
      End
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
         Left            =   120
         Style           =   1  'Graphical
         TabIndex        =   1
         Top             =   240
         Width           =   1575
      End
   End
End
Attribute VB_Name = "SubMenu"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub MenuXPB_Click(Index As Integer)
    If Not Cnn.State Then OpenConn Server, Db, "ITAPDC", "itapdc"
    Unload Me
    Select Case Index
           Case 4:
                If TipoUsuario <> 0 Then
                    MsgBox "¡ El usuario " & Usuario & " no tiene acceso a esta opción !", vbInformation + vbOKOnly, App.Title
                    Exit Sub
                End If
                With Cat_Clientes
                    '.LblTitulo.Caption = "Control de Catálogos de Clientes"
                    '.Caption = .LblTitulo.Caption
                    .Top = Menu.Top + Menu.Height
                    .Left = Menu.Left
                    .Show vbModal
                End With
            Case 5:
                If TipoUsuario <> 0 Then
                    MsgBox "¡ El usuario " & Usuario & " no tiene acceso a esta opción !", vbInformation + vbOKOnly, App.Title
                    Exit Sub
                End If
                With Cat_Productos
                    '.LblTitulo.Caption = "Control de Catálogos de Productos"
                    '.Caption = .LblTitulo.Caption
                    .Top = Menu.Top + Menu.Height
                    .Left = Menu.Left
                    .Show vbModal
                End With
            Case 7:
                If TipoUsuario > 1 Then
                    MsgBox "¡ El usuario " & Usuario & " no tiene acceso a esta opción !", vbInformation + vbOKOnly, App.Title
                    Exit Sub
                End If
                With Cat_VenRutUni
                    '.LblTitulo.Caption = "Control de Catálogos de Ventas"
                    '.Caption = .LblTitulo.Caption
                    .Top = Menu.Top + Menu.Height
                    .Left = Menu.Left
                    .Show vbModal
                End With
            Case 6:
                If TipoUsuario <> 0 Then
                    MsgBox "¡ El usuario " & Usuario & " no tiene acceso a esta opción !", vbInformation + vbOKOnly, App.Title
                    Exit Sub
                End If
                With Cat_TipoProd
                    .LblTitulo.Caption = "Control de Catálogos Tipo de Productos"
                    .Caption = .LblTitulo.Caption
                    .Top = Menu.Top + Menu.Height
                    .Left = Menu.Left
                    .Show vbModal
                End With

            Case 8:
                If TipoUsuario <> 0 Then
                    MsgBox "¡ El usuario " & Usuario & " no tiene acceso a esta opción !", vbInformation + vbOKOnly, App.Title
                    Exit Sub
                End If
                With Cat_Precios
                    .LblTitulo.Caption = "Control de Listas de Precios"
                    .Caption = .LblTitulo.Caption
                    .Top = Menu.Top + Menu.Height
                    .Left = Menu.Left
                    .Show vbModal
                End With
    End Select
End Sub

Private Sub MenuXPB_MouseMove(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    For i = 0 To MenuXPB.Count - 1
        MenuXPB.Item(i + 4).BackColor = IIf(Index = i + 4, &HEEEEEE, vbWhite)
    Next
End Sub
