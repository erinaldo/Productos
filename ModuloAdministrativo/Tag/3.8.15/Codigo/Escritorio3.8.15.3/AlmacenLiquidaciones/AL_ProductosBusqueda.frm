VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form AL_ProductosBusqueda 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Búsqueda de Productos"
   ClientHeight    =   3030
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   7530
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
   ScaleHeight     =   3030
   ScaleWidth      =   7530
   ShowInTaskbar   =   0   'False
   Begin VB.Frame FrmOpt 
      BackColor       =   &H00FFFFFF&
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3015
      Index           =   2
      Left            =   40
      TabIndex        =   2
      Top             =   0
      Width           =   7455
      Begin VB.TextBox TxtProducto 
         Height          =   375
         Left            =   120
         TabIndex        =   0
         Top             =   240
         Width           =   3495
      End
      Begin MSComctlLib.ListView LstProductos 
         Height          =   2190
         Left            =   120
         TabIndex        =   1
         Top             =   720
         Width           =   7215
         _ExtentX        =   12726
         _ExtentY        =   3863
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   -1  'True
         FullRowSelect   =   -1  'True
         _Version        =   393217
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         NumItems        =   1
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Object.Width           =   2540
         EndProperty
      End
   End
   Begin VB.CommandButton btnSalir 
      BackColor       =   &H00FFFFFF&
      Cancel          =   -1  'True
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   285
      Left            =   360
      Picture         =   "AL_ProductosBusqueda.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   3
      Top             =   240
      Width           =   1095
   End
End
Attribute VB_Name = "AL_ProductosBusqueda"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public Opc As Integer
Dim LstDProductos

Public Sub FiltraProductos(strDesc As String)
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    StrCmd = "execute sel_ProductosDescripcion 0, '" & strDesc & "', 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDProductos = GetDataLVL(RsC, LstProductos, 0, 1, "0|0")
End Sub

Private Sub btnSalir_Click()
    Me.Hide
End Sub

Private Sub Form_Load()
On Error Resume Next
    TxtProducto.SetFocus
End Sub

Private Sub LstProductos_DblClick()
    On Error Resume Next
    If IsEmpty(LstDProductos) Then Exit Sub
    Select Case Opc
        Case 1:
            AL_Liquidacion.TxtIdProdS.Text = Trim(LstProductos.SelectedItem)
        Case 2:
            AL_Liquidacion.TxtIdProdD.Text = Trim(LstProductos.SelectedItem)
        Case 3:
            AL_Facturas.TxtIdProd.Text = Trim(LstProductos.SelectedItem)
        Case 4:
            AL_Almacen.TxtIdProdES.Text = Trim(LstProductos.SelectedItem)
        Case 5:
            AL_Almacen.TxtIdProdF.Text = Trim(LstProductos.SelectedItem)
        Case 6:
            AL_Almacen.TxtIdProd.Text = Trim(LstProductos.SelectedItem)
        Case 7:
            AL_CargaSugerida.TxtIdProducto.Text = Trim(LstProductos.SelectedItem)
        Case 8:
            AL_Pedidos.TxtIdProd.Text = Trim(LstProductos.SelectedItem)
    End Select
    Unload Me
    
    Select Case Opc
        Case 1:
            AL_Liquidacion.TxtIdProdS_KeyPress 13
        Case 2:
            AL_Liquidacion.TxtIdProdD_KeyPress 13
        Case 3:
            AL_Facturas.TxtIdProd_KeyPress 13
        Case 4:
            AL_Almacen.TxtIdProdES_KeyPress 13
        Case 5:
            AL_Almacen.TxtIdProdF_KeyPress 13
        Case 6:
            AL_Almacen.TxtIdProd_KeyPress 13
        Case 7:
            AL_CargaSugerida.TxtIdProducto_KeyPress 13
        Case 8:
            AL_Pedidos.TxtIdProd_KeyPress 13
    End Select
End Sub

Private Sub LstProductos_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 Then
        If IsEmpty(LstDProductos) Then Exit Sub
        LstProductos_DblClick
    End If
End Sub

Private Sub TxtProducto_Change()
On Error Resume Next
    FiltraProductos TxtProducto.Text
End Sub

Private Sub TxtProducto_GotFocus()
On Error Resume Next
    SelText TxtProducto
End Sub

Private Sub TxtProducto_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub
