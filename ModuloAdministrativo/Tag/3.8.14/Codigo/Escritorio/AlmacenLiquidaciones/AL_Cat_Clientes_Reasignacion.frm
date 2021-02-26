VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form AL_Cat_Clientes_Reasignacion 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   6615
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   9705
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
   ScaleHeight     =   6615
   ScaleWidth      =   9705
   ShowInTaskbar   =   0   'False
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
      Height          =   6510
      Index           =   4
      Left            =   90
      TabIndex        =   0
      Top             =   30
      Width           =   9525
      Begin VB.CommandButton btnActualizar 
         BackColor       =   &H00FFFFFF&
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
         Left            =   7680
         Picture         =   "AL_Cat_Clientes_Reasignacion.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   9
         Top             =   1440
         Width           =   1695
      End
      Begin MSComctlLib.ListView LstVDatos 
         Height          =   4425
         Index           =   0
         Left            =   150
         TabIndex        =   1
         Top             =   2040
         Width           =   9195
         _ExtentX        =   16219
         _ExtentY        =   7805
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         FullRowSelect   =   -1  'True
         _Version        =   393217
         ForeColor       =   0
         BackColor       =   16777215
         Appearance      =   1
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "Tahoma"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         NumItems        =   0
      End
      Begin VB.Label LblDatos 
         BackStyle       =   0  'Transparent
         Caption         =   "Nombre del Cliente Nuevo"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   255
         Index           =   2
         Left            =   1890
         TabIndex        =   8
         Top             =   1320
         Width           =   5445
      End
      Begin VB.Label LblDatos 
         BackStyle       =   0  'Transparent
         Caption         =   "Nombre de la Sucursal"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   255
         Index           =   1
         Left            =   1440
         TabIndex        =   7
         Top             =   660
         Width           =   6375
      End
      Begin VB.Label LblDatos 
         BackStyle       =   0  'Transparent
         Caption         =   "Nombre del Cliente"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   255
         Index           =   0
         Left            =   1440
         TabIndex        =   6
         Top             =   270
         Width           =   6375
      End
      Begin VB.Label LblTitulos 
         BackStyle       =   0  'Transparent
         Caption         =   "Cliente Nuevo: "
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   2
         Left            =   270
         TabIndex        =   5
         Top             =   1320
         Width           =   1425
      End
      Begin VB.Label LblTitulos 
         BackStyle       =   0  'Transparent
         Caption         =   "Sucursal:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   1
         Left            =   270
         TabIndex        =   4
         Top             =   660
         Width           =   1035
      End
      Begin VB.Label LblTitulos 
         BackStyle       =   0  'Transparent
         Caption         =   "Cliente:"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   0
         Left            =   270
         TabIndex        =   3
         Top             =   270
         Width           =   1035
      End
      Begin VB.Label LblTitulos 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         BackStyle       =   0  'Transparent
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
         Height          =   225
         Index           =   23
         Left            =   180
         TabIndex        =   2
         Top             =   1770
         Width           =   690
      End
   End
End
Attribute VB_Name = "AL_Cat_Clientes_Reasignacion"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public IdSucursal As String
Public Sucursal As String
Public IdClienteAnterior As Long
Public ClienteAnterior As String

Dim ListaDeClientes
Dim IdClienteNuevo As Long, ClienteNuevo As String

Private Sub btnActualizar_Click()
On Error Resume Next

    If IdClienteNuevo = IdClienteAnterior Then
        MsgBox "¡ Selecciona el nuevo cliente al que pertenece la sucursal !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If IdClienteNuevo = 0 Then
        MsgBox "¡ No se ha Seleccionado el Cliente a Asignar !", vbInformation + vbOKOnly, App.Title
        LstVDatos(0).SetFocus
        Exit Sub
    End If

    If MsgBox("¡Se va a Reasignar la Sucursal al Nuevo Cliente! ¿Desea Continuar con la Reasignación?", vbYesNo, App.Title) = vbNo Then
        Exit Sub
    End If

    'reasignacion de la sucursal
    StrCmd = "exec up_Sucursales " & IdCedis & ", 0, " & IdClienteAnterior & ", '" & IdSucursal & "', '', '" & _
            "', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', " & IdClienteNuevo & ", '', 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
    
    LblDatos(0).Caption = IdClienteNuevo & " - " & ClienteNuevo
    IdClienteAnterior = IdClienteNuevo
    ClienteAnterior = ClienteNuevo
            
End Sub

Private Sub Form_Load()
On Error Resume Next
    
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    
    IdClienteNuevo = 0
    
    MuestraClientes
    
    LblDatos(0).Caption = IdClienteAnterior & " - " & ClienteAnterior
    LblDatos(1).Caption = IdSucursal & " - " & Sucursal

End Sub

Sub MuestraClientes()
On Error Resume Next
    StrCmd = "execute sel_Clientes " & IdCedis & ""
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    ListaDeClientes = GetDataLVL(Rs, LstVDatos(0), 0, 13, "0|0|0|0|0|0|0|0|0|0|0|0|0|0")
    If Not IsEmpty(ListaDeClientes) Then LstVDatos_ItemClick 0, LstVDatos(0).SelectedItem

End Sub

Private Sub LstVDatos_ItemClick(Index As Integer, ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
Dim ItemSeleccionado As Integer

    Nuevo = False
    
    Select Case Index
        Case 0
            ItemSeleccionado = Item.Index
            
            On Error Resume Next
            
            '0 idcliente, 1 rfc, 2 razonsocial, 3 domicilio, 4 telefono, 5 contacto,
            '6 email, 7 sitioweb, 8 canal, 9 cadena, 10 grupocliente, 11 domicilioentrega,
            '12 fechaalta, 13 Estatus
                
            IdClienteNuevo = ListaDeClientes(0, ItemSeleccionado - 1)
            ClienteNuevo = ListaDeClientes(2, ItemSeleccionado - 1)
            
            LblDatos(2).Caption = IdClienteNuevo & " - " & ClienteNuevo
                        
    End Select

End Sub

