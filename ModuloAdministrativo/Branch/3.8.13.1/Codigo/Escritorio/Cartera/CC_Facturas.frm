VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomctl.ocx"
Begin VB.Form CC_Facturas 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Registro de Ventas"
   ClientHeight    =   7785
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   10800
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
   ScaleHeight     =   7785
   ScaleWidth      =   10800
   ShowInTaskbar   =   0   'False
   Begin VB.Frame Frame4 
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
      Height          =   615
      Left            =   120
      TabIndex        =   41
      Top             =   1320
      Width           =   10575
      Begin VB.OptionButton Opt 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Movimientos de la Factura"
         Height          =   255
         Index           =   1
         Left            =   2880
         TabIndex        =   43
         Top             =   240
         Width           =   2775
      End
      Begin VB.OptionButton Opt 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Detalle de la Factura"
         Height          =   255
         Index           =   0
         Left            =   240
         TabIndex        =   42
         Top             =   240
         Value           =   -1  'True
         Width           =   2295
      End
   End
   Begin VB.Frame Frame3 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Datos del Cliente"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1215
      Left            =   4200
      TabIndex        =   31
      Top             =   120
      Width           =   6495
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
         Left            =   1080
         Locked          =   -1  'True
         TabIndex        =   35
         Top             =   720
         Width           =   5295
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
         Height          =   255
         Left            =   1080
         Locked          =   -1  'True
         TabIndex        =   34
         Top             =   360
         Width           =   1575
      End
      Begin VB.TextBox Text5 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   240
         Locked          =   -1  'True
         TabIndex        =   33
         Text            =   "R.F.C."
         Top             =   360
         Width           =   615
      End
      Begin VB.TextBox Txt12 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   240
         TabIndex        =   32
         Text            =   "Cliente"
         Top             =   720
         Width           =   735
      End
   End
   Begin VB.Frame Frame2 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Datos de la Factura"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1215
      Left            =   120
      TabIndex        =   24
      Top             =   120
      Width           =   3975
      Begin VB.TextBox TxtFecha 
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
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   47
         Top             =   840
         Width           =   1935
      End
      Begin VB.TextBox Text6 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   240
         TabIndex        =   46
         Text            =   "Fecha"
         Top             =   840
         Width           =   555
      End
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
         TabIndex        =   30
         Top             =   300
         Width           =   2175
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
         TabIndex        =   29
         Top             =   580
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
         TabIndex        =   28
         Top             =   580
         Width           =   1215
      End
      Begin VB.TextBox Text2 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   225
         Locked          =   -1  'True
         TabIndex        =   27
         Text            =   "Tipo de Venta"
         Top             =   300
         Width           =   1275
      End
      Begin VB.TextBox Text3 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   240
         TabIndex        =   26
         Text            =   "Serie"
         Top             =   580
         Width           =   555
      End
      Begin VB.TextBox Text4 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   1920
         Locked          =   -1  'True
         TabIndex        =   25
         Text            =   "Folio"
         Top             =   580
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
      Left            =   2040
      Picture         =   "CC_Facturas.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   5
      Top             =   6840
      Visible         =   0   'False
      Width           =   1575
   End
   Begin VB.Frame FrmDatos 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Detalle de la Factura"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   4335
      Left            =   120
      TabIndex        =   13
      Top             =   2040
      Width           =   10575
      Begin MSComctlLib.ListView LstPartidas 
         Height          =   3870
         Left            =   120
         TabIndex        =   9
         Top             =   360
         Width           =   10335
         _ExtentX        =   18230
         _ExtentY        =   6826
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
      Begin VB.TextBox TxtExistencia 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   5160
         MaxLength       =   8
         TabIndex        =   7
         Text            =   "0"
         Top             =   600
         Visible         =   0   'False
         Width           =   855
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
         Left            =   11640
         Picture         =   "CC_Facturas.frx":0710
         Style           =   1  'Graphical
         TabIndex        =   3
         Top             =   480
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
         Left            =   11040
         Picture         =   "CC_Facturas.frx":0B35
         Style           =   1  'Graphical
         TabIndex        =   2
         Top             =   480
         Visible         =   0   'False
         Width           =   495
      End
      Begin VB.TextBox TxtTotal 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   10080
         Locked          =   -1  'True
         MaxLength       =   8
         TabIndex        =   38
         Text            =   "0"
         Top             =   600
         Visible         =   0   'False
         Width           =   975
      End
      Begin VB.TextBox TxtSubTotal 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   8280
         Locked          =   -1  'True
         MaxLength       =   8
         TabIndex        =   36
         Text            =   "0"
         Top             =   600
         Visible         =   0   'False
         Width           =   975
      End
      Begin VB.TextBox TxtIdProd 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   240
         MaxLength       =   5
         TabIndex        =   0
         Top             =   600
         Visible         =   0   'False
         Width           =   615
      End
      Begin VB.TextBox TxtDesc 
         Height          =   375
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   8
         Top             =   600
         Visible         =   0   'False
         Width           =   4095
      End
      Begin VB.TextBox TxtCantidad 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   6120
         MaxLength       =   8
         TabIndex        =   1
         Text            =   "0"
         Top             =   600
         Visible         =   0   'False
         Width           =   975
      End
      Begin VB.TextBox TxtIva 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   9360
         Locked          =   -1  'True
         MaxLength       =   8
         TabIndex        =   14
         Text            =   "0"
         Top             =   600
         Visible         =   0   'False
         Width           =   615
      End
      Begin VB.TextBox TxtPrecio 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   7200
         Locked          =   -1  'True
         MaxLength       =   8
         TabIndex        =   6
         Text            =   "0"
         Top             =   600
         Visible         =   0   'False
         Width           =   975
      End
      Begin VB.Label Label7 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Existencia"
         Height          =   255
         Left            =   5040
         TabIndex        =   40
         Top             =   360
         Visible         =   0   'False
         Width           =   975
      End
      Begin VB.Label Label6 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Total"
         Height          =   255
         Left            =   10080
         TabIndex        =   39
         Top             =   360
         Visible         =   0   'False
         Width           =   855
      End
      Begin VB.Label Label5 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "SubTotal"
         Height          =   255
         Left            =   8280
         TabIndex        =   37
         Top             =   360
         Visible         =   0   'False
         Width           =   855
      End
      Begin VB.Label Label14 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Cantidad"
         Height          =   255
         Left            =   6000
         TabIndex        =   19
         Top             =   360
         Visible         =   0   'False
         Width           =   975
      End
      Begin VB.Label Label13 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Cve. P"
         Height          =   255
         Left            =   240
         TabIndex        =   18
         Top             =   360
         Visible         =   0   'False
         Width           =   495
      End
      Begin VB.Label Label12 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Descripción del Producto"
         Height          =   255
         Left            =   960
         TabIndex        =   17
         Top             =   360
         Visible         =   0   'False
         Width           =   3735
      End
      Begin VB.Label Label15 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Iva"
         Height          =   255
         Left            =   9360
         TabIndex        =   16
         Top             =   360
         Visible         =   0   'False
         Width           =   495
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Precio"
         Height          =   255
         Left            =   7200
         TabIndex        =   15
         Top             =   360
         Visible         =   0   'False
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
      Left            =   360
      Picture         =   "CC_Facturas.frx":0F12
      Style           =   1  'Graphical
      TabIndex        =   4
      Top             =   6840
      Width           =   1575
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
      Height          =   1455
      Left            =   7560
      TabIndex        =   20
      Top             =   6240
      Width           =   3135
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
         Left            =   1215
         TabIndex        =   12
         Top             =   960
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
         Left            =   1215
         TabIndex        =   11
         Top             =   600
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
         Left            =   1215
         TabIndex        =   10
         Top             =   240
         Width           =   1635
      End
      Begin VB.Label LblSTotal 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Total"
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
         Left            =   105
         TabIndex        =   23
         Top             =   960
         Width           =   1005
      End
      Begin VB.Label LblSIva 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Iva"
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
         Left            =   240
         TabIndex        =   22
         Top             =   600
         Width           =   825
      End
      Begin VB.Label LblSSubtotal 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Subtotal"
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
         Left            =   180
         TabIndex        =   21
         Top             =   240
         Width           =   915
      End
   End
   Begin VB.Label LblSMonto 
      Alignment       =   1  'Right Justify
      BackColor       =   &H00FFFFFF&
      Caption         =   "Monto de la Factura"
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
      Left            =   5760
      TabIndex        =   45
      Top             =   6600
      Visible         =   0   'False
      Width           =   1635
   End
   Begin VB.Label LblMonto 
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
      Left            =   5760
      TabIndex        =   44
      Top             =   6960
      Visible         =   0   'False
      Width           =   1635
   End
End
Attribute VB_Name = "CC_Facturas"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim RFC, Nombre, Direccion, Tel, IdCliente, LstDPartidas
Public IdCedis, IdTipoVenta, Serie, Folio, FechaFact, Base As Integer, StrCedis

Public Sub MuestraDetalle(Rep As Boolean)
On Error Resume Next

Dim Opc
    Opc = IIf(Opt(0).Value, 0, 1)
    FrmDatos.Caption = IIf(Opc = 0, "Detalle de la Factura", "Movimientos de la Factura")
    
    If IdCedis = "" Or IdTipoVenta = "" Or Serie = "" Or Folio = "" Then Exit Sub
    If Base = 0 Then
        StrCmd = "execute " & IIf(Opc = 0, " sel_VentasDetalle ", " sel_MovimientosFacturasDetalle ") & IdCedis & ", " & IdTipoVenta & ", '" & Serie & "', " & Folio & ", 1"
    Else
        StrCmd = "execute sel_VentasDetalleCxC " & IdCedis & ", " & IdTipoVenta & ", '" & Serie & "', " & Folio & ", 1"
    End If
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    If Not RsC.EOF And Opc = 0 Then
        TxtTipoVenta.Text = RsC.Fields(16)
        TxtSerie.Text = Serie
        TxtFolio.Text = Folio
        TxtFecha.Text = FechaFact
        RFC = RsC.Fields(12)
        TxtRFC.Text = RsC.Fields(12)
        Nombre = RsC.Fields(13)
        TxtCliente.Text = RsC.Fields(13)
    End If
    If Not Rep Then LstDPartidas = GetDataLVL(RsC, LstPartidas, IIf(Opc = 0, 4, 8), IIf(Opc = 0, 10, 16), IIf(Opc = 0, "1|0|9|7|7|7|7", "1|0|0|0|7|7|7|0|0"))
End Sub

Sub MuestraTotales(Rep As Boolean)
On Error Resume Next

Dim Opc
    Opc = IIf(Opt(0).Value, 0, 1)
    FrmDatos.Caption = IIf(Opc = 0, "Detalle de la Factura", "Movimientos de la Factura")
    LblSSubtotal.Caption = IIf(Opc = 0, "Subtotal", "Cargos")
    LblSIva.Caption = IIf(Opc = 0, "Iva", "Abonos")
    LblSTotal.Caption = IIf(Opc = 0, "Total", "Saldo")
    
    LblSMonto.Visible = IIf(Opc = 0, False, True): LblMonto.Visible = IIf(Opc = 0, False, True)
    
    If IdCedis = "" Or IdTipoVenta = "" Or Serie = "" Or Folio = "" Then Exit Sub
    If Base = 0 Then
        StrCmd = "execute " & IIf(Opc = 0, " sel_VentasDetalle ", " sel_MovimientosFacturasDetalle ") & IdCedis & ", " & IdTipoVenta & ", '" & Serie & "', " & Folio & ", 2"
    Else
        StrCmd = "execute  sel_VentasDetalleCxC  " & IdCedis & ", " & IdTipoVenta & ", '" & Serie & "', " & Folio & ", 2"
    End If
    If RsC.State Then RsC.Close
    If Not Rep Then RsC.Open StrCmd, Cnn
    If Not Rep Then
        LblSubtotal.Caption = FormatCurrency(RsC.Fields(0), 2, vbTrue)
        LblIva.Caption = FormatCurrency(RsC.Fields(1), 2, vbTrue)
        LblTotal.Caption = FormatCurrency(RsC.Fields(2), 2, vbTrue)
        If Opc = 1 Then
            LblMonto.Caption = FormatCurrency(RsC.Fields(3), 2, vbTrue)
        End If
    End If
End Sub


Private Sub btnImprimeC_Click()
On Error GoTo ImpFact:
If Opt(0).Value Then
    With CC_RptFactura
        .LblFecha.Caption = Format(FechaFact, "dd/mm/yyyy")
        .LblRFC.Caption = RFC
        .LblNombre.Caption = Nombre
        .LblDireccion.Caption = Direccion
'        .LblSubtotal.Caption = FormatCurrency(LblSubtotal, 2, vbTrue)
'        .LblIva.Caption = FormatCurrency(LblIva, 2, vbTrue)
'        .LblTotal.Caption = FormatCurrency(LblTotal, 2, vbTrue)
        
        MuestraDetalle True
        If Not RsC.EOF Then
            .object.DataSrc.DataSourceName = Cnn
            .object.DataSrc.Recordset = RsC
        End If
        
        .Printer.Orientation = ddOPortrait
        .Printer.PaperSize = 1
        .Show
    End With
Else
    
    If IsEmpty(LstDPartidas) Then
        MsgBox "¡ No existen Movimientos en la Factura !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    Dim strIds, strFolios
    strIds = ""
    For i = 1 To LstPartidas.ListItems.Count
        strIds = strIds & CDbl(LstPartidas.ListItems(i)) & ", "
    Next
    strIds = " and Movimientos.IdMovimiento in ( " & Mid(strIds, 1, Len(strIds) - 2) & " )"
    strFolios = " and Ventas.Folio = " & Folio & " and Ventas.IdTipoVenta = " & IdTipoVenta & " and Ventas.Serie = ''" & Serie & "'' "
    
    With CC_RptMovimiento
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
        .LblTitulo.Caption = "REPORTE DE MOVIMIENTOS A FACTURAS"
        .LblDatos.Caption = "Tipo de Movimiento: Varios.      " '& Format(LstMovimientos.SelectedItem.ListSubItems(1), ctFechaLarga)
        .LblCedis.Caption = ""
                
        StrCmd = "execute Rep_Movimientos2 " & IdCedis & ", '" & strIds & "', '" & strFolios & "', 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If Not RsC.EOF Then
            .object.DataSrc.DataSourceName = Cnn
            .object.DataSrc.Recordset = RsC
        End If
        
        .Printer.Orientation = ddOPortrait
        .Printer.PaperSize = 1
        .Show
    End With
End If
    
No_ImpFact:
    MousePointer = 0
    Exit Sub
    
ImpFact:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_ImpFact:
End Sub

Private Sub Form_Activate()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, IIf(Base = 0, Db, "PDC San Marcos"), UserDB, PasswordDB
    MuestraDetalle False
    MuestraTotales False
End Sub

Private Sub Form_Load()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, IIf(Base = 0, Db, "PDC San Marcos"), UserDB, PasswordDB
End Sub

Private Sub Opt_Click(Index As Integer)
On Error Resume Next
    MuestraDetalle False
    MuestraTotales False
End Sub
