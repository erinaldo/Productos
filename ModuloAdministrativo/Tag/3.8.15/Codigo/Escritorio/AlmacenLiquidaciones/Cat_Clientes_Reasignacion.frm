VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form Cat_Clientes_Reasignacion 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Reasignación de Sucursales"
   ClientHeight    =   8430
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
   MinButton       =   0   'False
   ScaleHeight     =   8430
   ScaleWidth      =   9705
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
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
      Height          =   8310
      Index           =   4
      Left            =   90
      TabIndex        =   0
      Top             =   30
      Width           =   9525
      Begin VB.CommandButton btnActualizar 
         BackColor       =   &H00FFFFFF&
         Caption         =   "&Actualizar"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   1065
         Left            =   8160
         Picture         =   "Cat_Clientes_Reasignacion.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   3
         Top             =   510
         Width           =   1185
      End
      Begin MSComctlLib.ListView LstVDatos 
         Height          =   6105
         Index           =   0
         Left            =   150
         TabIndex        =   1
         Top             =   2040
         Width           =   9195
         _ExtentX        =   16219
         _ExtentY        =   10769
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
         ForeColor       =   &H00008000&
         Height          =   255
         Index           =   2
         Left            =   1890
         TabIndex        =   9
         Top             =   1320
         Width           =   5925
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
         ForeColor       =   &H00C00000&
         Height          =   255
         Index           =   1
         Left            =   1440
         TabIndex        =   8
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
         ForeColor       =   &H00C00000&
         Height          =   255
         Index           =   0
         Left            =   1440
         TabIndex        =   7
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
         TabIndex        =   6
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
         TabIndex        =   5
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
         TabIndex        =   4
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
Attribute VB_Name = "Cat_Clientes_Reasignacion"
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

            If IdClienteNuevo = IdClienteAnterior Then Exit Sub

            If IdClienteNuevo = 0 Then
                MsgBox "¡ No se ha Seleccionado el Cliente a Asignar !", vbInformation + vbOKOnly, App.Title
                LstVDatos(0).SetFocus
                Exit Sub
            End If
    
            If MsgBox("¡Se va a Reasignar la Sucursal al Nuevo Cliente! ¿Desea Continuar con la Reasignación?", vbYesNo, App.Title) = vbNo Then
                Exit Sub
            End If

            '@IdCedis as bigint, @IdRuta as int, @IdCliente as bigint, @IdSucursal as bigint,
            '@TDA_GLN as varchar(20), @NombreSucursal as varchar(75),
            '@Calle as varchar(250), @NumExterior as varchar(20),
            '@NumInterior as varchar(20), @Colonia as varchar(100),
            '@CP as varchar(5), @Ciudad as varchar(50),
            '@Estado as varchar(50), @Telefonos as varchar(100),
            '@RFCSucursal as varchar(20), @RazonSocial as varchar(200),
            '@CodigoBarras as varchar(50), @FormaVenta as varchar(1),
            '@Status as varchar(1), @Opc as int
            
            'reasignacion de la sucursal
            StrCmd = "up_Sucursales " & IdCedis & ", 0, " & IdClienteAnterior & ", '" & IdSucursal & "', '', '" & _
                    "', '', '', '', '', '', '', '', '', '', '', '', '', '', " & IdClienteNuevo & ",4"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            
            MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
            
            LblDatos(0).Caption = IdClienteNuevo & " - " & ClienteNuevo
            IdClienteAnterior = IdClienteNuevo
            ClienteAnterior = ClienteNuevo
            
End Sub

Private Sub Form_Load()
    
    If Not Cnn.State Then OpenConn Server, Db, "ITAPDC", "itapdc"
    
    IdClienteNuevo = 0
    
    MuestraClientes
    
    LblDatos(0).Caption = IdClienteAnterior & " - " & ClienteAnterior
    LblDatos(1).Caption = IdSucursal & " - " & Sucursal

End Sub

Sub MuestraClientes()
    StrCmd = "execute sel_Clientes " & IdCedis & ""
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    ListaDeClientes = GetDataLVL(Rs, LstVDatos(0), 0, 13, "0|0|0|0|0|0|0|0|0|0|0|0|0|0")
    If Not IsEmpty(ListaDeClientes) Then LstVDatos_ItemClick 0, LstVDatos(0).SelectedItem

End Sub

Private Sub LstVDatos_ItemClick(Index As Integer, ByVal Item As MSComctlLib.ListItem)
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

