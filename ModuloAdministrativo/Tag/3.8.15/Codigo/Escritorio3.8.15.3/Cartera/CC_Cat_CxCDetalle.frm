VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_Cat_CxCDetalle 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Registro de Porducto en CxC"
   ClientHeight    =   8430
   ClientLeft      =   45
   ClientTop       =   315
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
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   8430
   ScaleWidth      =   12660
   ShowInTaskbar   =   0   'False
   Begin VB.Frame Frame3 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Datos del Cliente"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1215
      Left            =   4680
      TabIndex        =   34
      Top             =   120
      Width           =   7815
      Begin VB.TextBox Text6 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         TabIndex        =   47
         Text            =   "Sucursal"
         Top             =   530
         Width           =   855
      End
      Begin VB.TextBox TxtSucursal 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   1080
         Locked          =   -1  'True
         TabIndex        =   46
         Top             =   530
         Width           =   6495
      End
      Begin VB.TextBox TxtListaPrecios 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   1680
         Locked          =   -1  'True
         TabIndex        =   40
         Top             =   840
         Width           =   5535
      End
      Begin VB.TextBox TxtCliente 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   3000
         Locked          =   -1  'True
         TabIndex        =   39
         Top             =   240
         Width           =   4575
      End
      Begin VB.TextBox TxtRFC 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   210
         Left            =   840
         Locked          =   -1  'True
         TabIndex        =   38
         Top             =   240
         Width           =   1215
      End
      Begin VB.TextBox Text5 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         Locked          =   -1  'True
         TabIndex        =   37
         Text            =   "R.F.C."
         Top             =   240
         Width           =   615
      End
      Begin VB.TextBox Txt12 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   2160
         TabIndex        =   36
         Text            =   "Cliente"
         Top             =   240
         Width           =   735
      End
      Begin VB.TextBox Text14 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         Locked          =   -1  'True
         TabIndex        =   35
         Text            =   "Lista de Precios"
         Top             =   840
         Width           =   1455
      End
   End
   Begin VB.Frame Frame2 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Datos de la Venta"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1215
      Left            =   120
      TabIndex        =   27
      Top             =   120
      Width           =   4455
      Begin VB.TextBox TxtTipoVenta 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   1560
         Locked          =   -1  'True
         TabIndex        =   33
         Top             =   360
         Width           =   2655
      End
      Begin VB.TextBox TxtSerie 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   840
         Locked          =   -1  'True
         TabIndex        =   32
         Top             =   720
         Width           =   615
      End
      Begin VB.TextBox TxtFolio 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   2520
         Locked          =   -1  'True
         TabIndex        =   31
         Top             =   720
         Width           =   1215
      End
      Begin VB.TextBox Text2 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   225
         Locked          =   -1  'True
         TabIndex        =   30
         Text            =   "Tipo de Venta"
         Top             =   360
         Width           =   1400
      End
      Begin VB.TextBox Text3 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   240
         TabIndex        =   29
         Text            =   "Serie"
         Top             =   720
         Width           =   555
      End
      Begin VB.TextBox Text4 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   1920
         Locked          =   -1  'True
         TabIndex        =   28
         Text            =   "Folio"
         Top             =   720
         Width           =   555
      End
   End
   Begin VB.CommandButton btnEliminarVenta 
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
      Left            =   2280
      Picture         =   "CC_Cat_CxCDetalle.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   9
      Top             =   7320
      Width           =   1695
   End
   Begin VB.Frame FrmOpt 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Detalle de la Venta"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   5295
      Index           =   2
      Left            =   120
      TabIndex        =   16
      Top             =   1440
      Width           =   12375
      Begin MSComctlLib.ListView LstPartidas 
         Height          =   4230
         Left            =   120
         TabIndex        =   12
         Top             =   960
         Width           =   12135
         _ExtentX        =   21405
         _ExtentY        =   7461
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
      Begin VB.TextBox TxtEntregado 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   7440
         MaxLength       =   8
         TabIndex        =   3
         Text            =   "0"
         Top             =   480
         Width           =   975
      End
      Begin VB.TextBox TxtDctoImp 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   10680
         Locked          =   -1  'True
         MaxLength       =   8
         TabIndex        =   5
         Text            =   "0"
         Top             =   480
         Width           =   1095
      End
      Begin VB.TextBox TxtDctoPorc 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   9600
         MaxLength       =   8
         TabIndex        =   4
         Text            =   "0"
         Top             =   480
         Width           =   975
      End
      Begin VB.TextBox TxtExistencia 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   5160
         MaxLength       =   8
         TabIndex        =   11
         Text            =   "0"
         Top             =   480
         Width           =   1095
      End
      Begin VB.CommandButton btnDelete 
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
         Left            =   11520
         Picture         =   "CC_Cat_CxCDetalle.frx":0710
         Style           =   1  'Graphical
         TabIndex        =   7
         Top             =   1560
         Visible         =   0   'False
         Width           =   495
      End
      Begin VB.CommandButton btnAdd 
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
         Left            =   10920
         Picture         =   "CC_Cat_CxCDetalle.frx":0B35
         Style           =   1  'Graphical
         TabIndex        =   6
         Top             =   1560
         Visible         =   0   'False
         Width           =   495
      End
      Begin VB.TextBox TxtTotal 
         Alignment       =   1  'Right Justify
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   325
         Left            =   10680
         Locked          =   -1  'True
         MaxLength       =   8
         TabIndex        =   43
         Text            =   "0"
         Top             =   960
         Width           =   975
      End
      Begin VB.TextBox TxtSubTotal 
         Alignment       =   1  'Right Justify
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   325
         Left            =   7920
         Locked          =   -1  'True
         MaxLength       =   8
         TabIndex        =   41
         Text            =   "0"
         Top             =   960
         Width           =   975
      End
      Begin VB.TextBox TxtIdProd 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   240
         MaxLength       =   10
         TabIndex        =   0
         Top             =   480
         Width           =   855
      End
      Begin VB.TextBox TxtDesc 
         Height          =   375
         Left            =   1200
         TabIndex        =   1
         Top             =   480
         Width           =   3855
      End
      Begin VB.TextBox TxtCantidad 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   6360
         MaxLength       =   8
         TabIndex        =   2
         Text            =   "0"
         Top             =   480
         Width           =   975
      End
      Begin VB.TextBox TxtIva 
         Alignment       =   1  'Right Justify
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   325
         Left            =   9360
         Locked          =   -1  'True
         MaxLength       =   8
         TabIndex        =   17
         Text            =   "0"
         Top             =   960
         Width           =   615
      End
      Begin VB.TextBox TxtPrecio 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   8520
         MaxLength       =   8
         TabIndex        =   10
         Text            =   "0"
         Top             =   480
         Width           =   975
      End
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Entregado"
         Height          =   255
         Left            =   7440
         TabIndex        =   50
         Top             =   240
         Width           =   975
      End
      Begin VB.Label Label9 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Dcto Importe"
         Height          =   255
         Left            =   10560
         TabIndex        =   49
         Top             =   240
         Width           =   1215
      End
      Begin VB.Label Label8 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Dcto %"
         Height          =   255
         Left            =   9480
         TabIndex        =   48
         Top             =   240
         Width           =   975
      End
      Begin VB.Label Label7 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Existencia"
         Height          =   255
         Left            =   5160
         TabIndex        =   45
         Top             =   240
         Width           =   975
      End
      Begin VB.Label Label6 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Total"
         Height          =   255
         Left            =   10080
         TabIndex        =   44
         Top             =   960
         Width           =   495
      End
      Begin VB.Label Label5 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "SubTotal"
         Height          =   255
         Left            =   6960
         TabIndex        =   42
         Top             =   960
         Width           =   855
      End
      Begin VB.Label Label14 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Cantidad"
         Height          =   255
         Left            =   6240
         TabIndex        =   22
         Top             =   240
         Width           =   975
      End
      Begin VB.Label Label13 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Cve. P"
         Height          =   255
         Left            =   360
         TabIndex        =   21
         Top             =   240
         Width           =   495
      End
      Begin VB.Label Label12 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Descripción del Producto"
         Height          =   255
         Left            =   1320
         TabIndex        =   20
         Top             =   240
         Width           =   3735
      End
      Begin VB.Label Label15 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Iva"
         Height          =   255
         Left            =   9000
         TabIndex        =   19
         Top             =   960
         Width           =   255
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Precio"
         Height          =   255
         Left            =   8520
         TabIndex        =   18
         Top             =   240
         Width           =   855
      End
   End
   Begin VB.CommandButton btnImprimeC 
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
      Left            =   480
      Picture         =   "CC_Cat_CxCDetalle.frx":0F12
      Style           =   1  'Graphical
      TabIndex        =   8
      Top             =   7320
      Width           =   1695
   End
   Begin VB.Frame Frame1 
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
      Height          =   1815
      Left            =   9360
      TabIndex        =   23
      Top             =   6600
      Width           =   3135
      Begin VB.Label Label16 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Descuento:"
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
         Left            =   155
         TabIndex        =   52
         Top             =   240
         Width           =   945
      End
      Begin VB.Label LblDescuento 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "$ 0.00"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   345
         Left            =   1335
         TabIndex        =   51
         Top             =   240
         Width           =   1635
      End
      Begin VB.Label LblTotal 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "$ 0.00"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   345
         Left            =   1335
         TabIndex        =   15
         Top             =   1320
         Width           =   1635
      End
      Begin VB.Label LblIva 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "$ 0.00"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   345
         Left            =   1335
         TabIndex        =   14
         Top             =   960
         Width           =   1635
      End
      Begin VB.Label LblSubtotal 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "$ 0.00"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   345
         Left            =   1335
         TabIndex        =   13
         Top             =   600
         Width           =   1635
      End
      Begin VB.Label Label2 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Total:"
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
         Left            =   660
         TabIndex        =   26
         Top             =   1320
         Width           =   450
      End
      Begin VB.Label Label3 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Impuestos:"
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
         Left            =   135
         TabIndex        =   25
         Top             =   960
         Width           =   930
      End
      Begin VB.Label Label4 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Subtotal:"
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
         Left            =   375
         TabIndex        =   24
         Top             =   600
         Width           =   720
      End
   End
End
Attribute VB_Name = "CC_Cat_CxCDetalle"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public IdCedis, IdTipoVenta, Folio, RFC, Nombre, Direccion, Tel, IdCliente, IdSucursal, Serie, StatusVenta, Fecha As Date
Dim LstDPartidas, Precio As Double, IdLista As Long, Iva As Double, VtaAnterior

Public Sub MuestraDetalle(Rep As Boolean)
On Error Resume Next
    StrCmd = "execute sel_VentasDetalle " & IdCedis & ", " & IdTipoVenta & ", '" & Serie & "', " & Folio & ", 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDPartidas = GetDataLVL(RsC, LstPartidas, 4, 11, "0|0|9|9|7|7|7|7")
End Sub

Sub MuestraTotales(Rep As Boolean)
On Error Resume Next
    StrCmd = "execute sel_VentasDetalle " & IdCedis & ", " & IdTipoVenta & ", '" & Serie & "', " & Folio & ", 2"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    If Not RsC.EOF Then
        LblSubtotal.Caption = FormatCurrency(RsC.Fields(0), 2, vbTrue)
        LblIva.Caption = FormatCurrency(RsC.Fields(1), 2, vbTrue)
        LblTotal.Caption = FormatCurrency(RsC.Fields(2), 2, vbTrue)
        LblDescuento.Caption = FormatCurrency(RsC.Fields(3), 2, vbTrue)
    End If
End Sub

Private Sub btnEliminarVenta_Click()
On Error GoTo Err_EliminarFact:
    
    If Not ValidaModulo("MCXC", True) Then Exit Sub
    
    If StatusVenta <> "P" Then
        MsgBox "¡ No se puede Eliminar la cuenta por cobrar !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    If MsgBox("¿ Está seguro que desea Eliminar la Venta " & Format(Folio, "0000000") & " del Cliente " & Chr(13) & Chr(10) & Nombre & " por " & LblTotal.Caption & " ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
        If MsgBox("La información se perderá. ¿ Desea continuar ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
        
        MousePointer = 11
            StrCmd = "execute up_Ventas " & IdCedis & ", " & IdSurtido & ", " & IdTipoVenta & ", " & Folio & ", '', '" & FormatDate(Fecha) & "', 0, 0, 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            
        MousePointer = 0
            MsgBox "¡ Venta Eliminada !", vbInformation + vbOKOnly, App.Title
            Unload Me
        End If
    End If

No_Err_EliminarFact:
    MousePointer = 0
    Exit Sub
    
Err_EliminarFact:
    MousePointer = 0
    MsgBox "¡ Error al Eliminar la cuenta por cobrar !. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_EliminarFact:

End Sub

Private Sub btnImprimeC_Click()
On Error GoTo ImpFact:

    MensajeCFD = ""

    If CFDCedis = "1" Then
        StrCmd = "execute sel_VentasFacturaCFD " & IdCedis & ", 0, " & IdTipoVenta & ", '" & Serie & "', " & Folio & ", 1, 2"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If Not RsC.EOF Then
            TransProdIDFactura = RsC.Fields(6)
        Else
            TransProdIDFactura = ""
            GoTo ImpFactTrad:
        End If
    
        Set ClaseCFDADM = New LbCFDADM.LbCFDADM
        MensajeCFD = ClaseCFDADM.LlamarCFDADM(PathRouteDesktop, TransProdIDFactura, RutaXML, 3)
        If Trim(MensajeCFD) <> "" Then GoTo ImpFact:

    Else
ImpFactTrad:
        With CC_RptFactura
            
            StrCmd = "execute sel_VentasDetalle " & IdCedis & ", " & IdTipoVenta & ", '" & Serie & "', " & Folio & ", 4"
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
            
            If Not RsC.EOF Then
                .LblControl.Caption = "Ced" & IdCedis & "Dcto" & Serie & "-" & Folio
                .object.DataSrc.DataSourceName = Cnn
                .object.DataSrc.Recordset = RsC
                .Printer.Orientation = ddOPortrait
                .Printer.PaperSize = 1
                .Show vbModal
            End If
        End With
    End If
    
No_ImpFact:
    MousePointer = 0
    Exit Sub
    
ImpFact:
    MousePointer = 0
    If Trim(MensajeCFD) = "" Then
        MsgBox "Error al crear " & IIf(CFDCedis = "1", " el CFDI", "la Factura") & " : " & Err.Description, vbInformation + vbOKOnly, App.Title
    Else
        MsgBox MensajeCFD, vbInformation + vbOKOnly, App.Title
    End If
    GoTo No_ImpFact:
End Sub

Private Sub Form_Load()
On Error Resume Next
    If CFDCedis = "1" Then ValidaVenta
End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    CC_Cat_CxC.MuestraVentas
End Sub

Private Sub TxtCantidad_Change()
On Error Resume Next
    TxtEntregado.Text = TxtCantidad.Text
End Sub

Private Sub TxtCantidad_GotFocus()
On Error Resume Next
    SelText TxtCantidad
End Sub

Private Sub TxtCantidad_KeyPress(KeyAscii As Integer)

On Error GoTo Err_Facturas:

    If KeyAscii = 13 Then
        TxtCantidad_Validate False
        TxtEntregado.SetFocus
        Exit Sub
    End If
    
    If Dec Then
        If KeyAscii <> "42" Then KeyAscii = itDecimal(KeyAscii)
    Else
        If KeyAscii <> "42" Then KeyAscii = itEntero(KeyAscii)
    End If
    
No_Err_Facturas:
    MousePointer = 0
    Exit Sub
    
Err_Facturas:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_Facturas:

End Sub

Private Sub TxtCantidad_Validate(Cancel As Boolean)
On Error Resume Next
    If Dec Then
        TxtCantidad.Text = itFlotante(TxtCantidad.Text)
        TxtEntregado.Text = TxtCantidad.Text
        If Trim(TxtCantidad.Text) = "0" Then Exit Sub
    End If
End Sub

Private Sub TxtDctoPorc_Change()
On Error Resume Next
    TxtDctoImp.Text = FormatCurrency((CDbl(TxtCantidad.Text) * CDbl(TxtPrecio.Text) * CDbl((TxtDctoPorc.Text) / 100)), 3, vbTrue)
End Sub

Private Sub TxtDctoPorc_GotFocus()
On Error Resume Next
    SelText TxtDctoPorc
End Sub

Private Sub TxtDctoPorc_KeyPress(KeyAscii As Integer)
On Error GoTo Err_Dcto:

Dim Existencias, Descuento, DctoCapturado

    If KeyAscii = 13 Then
                
        If Not ValidaModulo("MCXC", True) Then Exit Sub
                
        If StatusVenta <> "P" Then
            MsgBox "¡ No se puede modificar la cuenta por cobrar !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
           
        If CFDCedis = "1" And Facturada Then
            MsgBox "¡ No se puede modificar la cuenta por cobrar porque ya ha sido Facturada !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If

        SplitTxt TxtDctoPorc
        
        TxtDctoPorc.Text = itFlotante(TxtDctoPorc.Text)
        
        If CDbl(TxtDctoPorc.Text) > 100 Then
            MsgBox "¡ Sólo puedes Aplicar un Descuento Máximo de 100% !", vbin + vbOKOnly, App.Title
            TxtDctoPorc.Text = 0
            GoTo No_Err_Dcto:
        End If
        
        If Dec Then
            TxtCantidad.Text = itFlotante(TxtCantidad.Text)
        End If
        
        If IdLista = 0 Then
            MsgBox "¡ El Cedis " & IdCedis & " - " & NomCedis & " no tiene asignada una Lista de Precios Base !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        If Precio = 0 Then
            MsgBox "¡ El Producto " & TxtIdProd.Text & " no tiene precio !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If Trim(TxtCantidad.Text) = "" Then
            MsgBox "¡ Teclee la Cantidad de producto a Facturar !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If Trim(TxtCantidad.Text) = "0" Then
            If MsgBox("¿ Está seguro que desea Eliminar la partida seleccionada ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        End If
        
        StrCmd = "execute up_VentasDetalle " & IdCedis & ", " & IdTipoVenta & ", '" & Serie & "', " & Folio & ", '" & FormatDate(Fecha) & "', " & TxtIdProd.Text & _
            ", " & CDbl(TxtCantidad.Text) & ", " & Precio & ", " & Iva & ", 0, " & CDbl(TxtDctoPorc.Text) / 100 & ", " & CDbl(TxtDctoImp.Text) & ", " & TxtEntregado.Text & ", 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        MuestraDetalle False
        MuestraTotales False
        
        TxtCantidad.Text = 0: TxtPrecio.Text = 0: TxtSubTotal.Text = 0: TxtIva.Text = 0: TxtTotal.Text = 0: TxtDctoPorc.Text = 0: TxtDctoImp.Text = 0: TxtEntregado.Text = 0
        TxtIdProd.Text = "": TxtIdProd.SetFocus: TxtDesc.Text = "": TxtExistencia.Text = 0
        Exit Sub
    End If
    
    KeyAscii = itDecimal(KeyAscii)
    
No_Err_Dcto:
    MousePointer = 0
    Exit Sub
    
Err_Dcto:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_Dcto:

End Sub

Private Sub TxtDesc_Change()
On Error Resume Next
    AL_al_ProductosBusqueda.Hide
End Sub

Private Sub TxtDesc_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 And Trim(TxtDesc.Text) <> "" Then
        With AL_al_ProductosBusqueda
            .Opc = 3: .Left = 3500: .Top = 3700
            .FiltraProductos CStr(Trim(TxtDesc.Text))
            If Not .Visible Then .Show 0
        End With
    Else
        KeyAscii = itString(KeyAscii)
    End If
End Sub

Private Sub TxtDesc_Validate(Cancel As Boolean)
On Error Resume Next
    AL_al_ProductosBusqueda.Hide
End Sub

Private Sub TxtEntregado_GotFocus()
On Error Resume Next
    SelText TxtEntregado
End Sub

Private Sub TxtEntregado_KeyPress(KeyAscii As Integer)
On Error Resume Next

    If KeyAscii = 13 Then
        If CDbl(TxtCantidad.Text) < CDbl(TxtEntregado.Text) Then
            TxtEntregado.Text = TxtCantidad.Text
            MsgBox "¡ La Cantidad de Producto Entregado no puede ser mayor a la Cantidad de Producto Vendido !"
            TxtEntregado.SetFocus
            Exit Sub
        End If
        
        TxtDctoPorc.SetFocus
        Exit Sub
    End If
    
    If Dec Then
        If KeyAscii <> "42" Then KeyAscii = itDecimal(KeyAscii)
    Else
        If KeyAscii <> "42" Then KeyAscii = itEntero(KeyAscii)
    End If

End Sub

Private Sub TxtEntregado_Validate(Cancel As Boolean)
On Error Resume Next
    If Dec Then
        TxtEntregado.Text = itFlotante(TxtEntregado.Text)
        If Trim(TxtEntregado.Text) = "0" Then Exit Sub
    End If
    If CDbl(TxtCantidad.Text) < CDbl(TxtEntregado.Text) Then
        TxtEntregado.Text = TxtCantidad.Text
        MsgBox "¡ La Cantidad de Producto Entregado no puede ser mayor a la Cantidad de Producto Vendido !"
        Exit Sub
    End If
End Sub

Private Sub TxtIdProd_Change()
On Error Resume Next
    TxtDesc.Text = "¡ Producto no econtrado !": TxtCantidad.Text = 0: TxtPrecio.Text = 0: TxtSubTotal.Text = 0: TxtIva.Text = 0: TxtTotal.Text = 0: TxtExistencia.Text = 0
End Sub

Private Sub TxtIdProd_GotFocus()
On Error Resume Next
    SelText TxtIdProd
End Sub

Public Sub TxtIdProd_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If Trim(TxtIdProd.Text) = "0" Then
        With AL_ProductosBusqueda
            .Left = Me.Left + 500
            .Top = Me.Top + 500
            .Opc = 3
            .Show
        End With
        Exit Sub
    End If
    If KeyAscii = 13 Then
        If StatusVenta <> "P" Then
            MsgBox "¡ No se puede modificar la cuenta por cobrar !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        Else
            ValidaProductoVenta
        End If
        Exit Sub
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Sub ValidaProductoVenta()
On Error Resume Next

    If Not ValidaModulo("MCXC", True) Then Exit Sub

    If Trim(TxtIdProd.Text) <> "" Then
        ' saco el producto tiene precio y el cedis tiene lista de contado...
        Precio = 0: IdLista = 0
        StrCmd = "execute sel_Precios " & IdCedis & ", " & IdCliente & ", 0, " & TxtIdProd.Text & ", 0, 0, 0"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            Precio = Rs.Fields(1): IdLista = Rs.Fields(0)
            TxtDesc.Text = Rs.Fields(3)
            If Rs.Fields(0) = 0 Then
                MsgBox "¡ El Cedis " & IdCedis & " - " & NomCedis & " no tiene asignada una Lista de Precios Base !", vbInformation + vbOKOnly, App.Title
                TxtCantidad.Text = 0: TxtPrecio.Text = 0: TxtSubTotal.Text = 0: TxtIva.Text = 0: TxtTotal.Text = 0
                Exit Sub
            End If
            If Rs.Fields(1) = 0 Then
                MsgBox "¡ El Producto " & TxtIdProd.Text & " no tiene precio !", vbInformation + vbOKOnly, App.Title
                TxtCantidad.Text = 0: TxtPrecio.Text = 0: TxtSubTotal.Text = 0: TxtIva.Text = 0: TxtTotal.Text = 0
                Exit Sub
            End If
            TxtPrecio.Text = FormatCurrency(Rs.Fields(1), 2, vbTrue)
        End If
        
        ' valido si el producto ya está registrado en la Venta y obtiene nuevos datos
        StrCmd = "execute sel_ExistenciaValida " & IdCedis & ", " & IdTipoVenta & ", '" & Serie & "', " & Folio & ", " & TxtIdProd.Text & ", 0, 0, 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            TxtCantidad.Text = FormatNumber(Rs.Fields(1), 3): TxtPrecio.Text = FormatCurrency(Rs.Fields(2), 3, vbTrue):
            TxtDctoPorc.Text = FormatNumber(CDbl(Rs.Fields(6)) * 100, 2): TxtDctoImp.Text = FormatCurrency(Rs.Fields(7), 3, vbTrue)
            TxtEntregado.Text = FormatNumber(Rs.Fields(8), 3)
            TxtSubTotal.Text = FormatCurrency(Rs.Fields(3), 2, vbTrue): TxtIva.Text = FormatCurrency(Rs.Fields(4), 2, vbTrue): TxtTotal.Text = FormatCurrency(Rs.Fields(5), 2, vbTrue)
        Else
            TxtCantidad.Text = 0
        End If
    Else
        TxtDesc.Text = "": TxtCantidad.Text = 0: TxtPrecio.Text = 0: TxtSubTotal.Text = 0: TxtIva.Text = 0: TxtTotal.Text = 0: TxtExistencia.Text = 0
        TxtDctoPorc.Text = 0: TxtDctoImp.Text = 0: TxtEntregado.Text = 0
    End If
    VtaAnterior = CDbl(TxtCantidad.Text)
    TxtCantidad.SetFocus
    
    
End Sub

Sub ValidaVenta()
    StrCmd = "execute RouteADM.dbo.sel_SeriesCFD 1, 0, 1, 1, 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        Facturada = IIf(Folio <= Rs.Fields(4) And Folio > 0 And Serie = Rs.Fields(0), True, False)
    End If
End Sub
