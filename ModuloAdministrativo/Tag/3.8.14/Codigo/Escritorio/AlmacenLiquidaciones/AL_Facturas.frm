VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form AL_Facturas 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Registro de Ventas"
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
   MDIChild        =   -1  'True
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
      TabIndex        =   31
      Top             =   120
      Width           =   7815
      Begin VB.TextBox Text6 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         TabIndex        =   44
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
         TabIndex        =   43
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
         TabIndex        =   37
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
         TabIndex        =   36
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
         TabIndex        =   35
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
         TabIndex        =   34
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
         TabIndex        =   33
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
         TabIndex        =   32
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
      TabIndex        =   24
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
         TabIndex        =   30
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
         TabIndex        =   29
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
         TabIndex        =   28
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
         TabIndex        =   27
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
         TabIndex        =   26
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
         TabIndex        =   25
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
      Picture         =   "AL_Facturas.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   6
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
      Height          =   5655
      Index           =   2
      Left            =   120
      TabIndex        =   13
      Top             =   1440
      Width           =   12375
      Begin VB.TextBox TxtExistencia 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   5160
         MaxLength       =   8
         TabIndex        =   8
         Text            =   "0"
         Top             =   600
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
         Left            =   11760
         Picture         =   "AL_Facturas.frx":0710
         Style           =   1  'Graphical
         TabIndex        =   4
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
         Left            =   11160
         Picture         =   "AL_Facturas.frx":0B35
         Style           =   1  'Graphical
         TabIndex        =   3
         Top             =   480
         Visible         =   0   'False
         Width           =   495
      End
      Begin VB.TextBox TxtTotal 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   10320
         Locked          =   -1  'True
         MaxLength       =   8
         TabIndex        =   40
         Text            =   "0"
         Top             =   600
         Width           =   975
      End
      Begin VB.TextBox TxtSubTotal 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   8520
         Locked          =   -1  'True
         MaxLength       =   8
         TabIndex        =   38
         Text            =   "0"
         Top             =   600
         Width           =   975
      End
      Begin VB.TextBox TxtIdProd 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   240
         MaxLength       =   10
         TabIndex        =   0
         Top             =   600
         Width           =   855
      End
      Begin VB.TextBox TxtDesc 
         Height          =   375
         Left            =   1200
         TabIndex        =   1
         Top             =   600
         Width           =   3855
      End
      Begin VB.TextBox TxtCantidad 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   6360
         MaxLength       =   8
         TabIndex        =   2
         Text            =   "0"
         Top             =   600
         Width           =   975
      End
      Begin VB.TextBox TxtIva 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   9600
         Locked          =   -1  'True
         MaxLength       =   8
         TabIndex        =   14
         Text            =   "0"
         Top             =   600
         Width           =   615
      End
      Begin VB.TextBox TxtPrecio 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   7440
         Locked          =   -1  'True
         MaxLength       =   8
         TabIndex        =   7
         Text            =   "0"
         Top             =   600
         Width           =   975
      End
      Begin MSComctlLib.ListView LstPartidas 
         Height          =   4470
         Left            =   240
         TabIndex        =   9
         Top             =   1080
         Width           =   11895
         _ExtentX        =   20981
         _ExtentY        =   7885
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
      Begin VB.Label Label7 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Existencia"
         Height          =   255
         Left            =   5160
         TabIndex        =   42
         Top             =   360
         Width           =   975
      End
      Begin VB.Label Label6 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Total"
         Height          =   255
         Left            =   10320
         TabIndex        =   41
         Top             =   360
         Width           =   855
      End
      Begin VB.Label Label5 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "SubTotal"
         Height          =   255
         Left            =   8520
         TabIndex        =   39
         Top             =   360
         Width           =   855
      End
      Begin VB.Label Label14 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Cantidad"
         Height          =   255
         Left            =   6240
         TabIndex        =   19
         Top             =   360
         Width           =   975
      End
      Begin VB.Label Label13 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Cve. P"
         Height          =   255
         Left            =   240
         TabIndex        =   18
         Top             =   360
         Width           =   495
      End
      Begin VB.Label Label12 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Descripción del Producto"
         Height          =   255
         Left            =   1200
         TabIndex        =   17
         Top             =   360
         Width           =   3735
      End
      Begin VB.Label Label15 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Iva"
         Height          =   255
         Left            =   9600
         TabIndex        =   16
         Top             =   360
         Width           =   495
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Precio"
         Height          =   255
         Left            =   7440
         TabIndex        =   15
         Top             =   360
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
      Picture         =   "AL_Facturas.frx":0F12
      Style           =   1  'Graphical
      TabIndex        =   5
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
      Height          =   1455
      Left            =   9360
      TabIndex        =   20
      Top             =   6960
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
         Left            =   540
         TabIndex        =   23
         Top             =   960
         Width           =   450
      End
      Begin VB.Label Label3 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Iva:"
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
         Left            =   675
         TabIndex        =   22
         Top             =   600
         Width           =   270
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
         Left            =   255
         TabIndex        =   21
         Top             =   240
         Width           =   720
      End
   End
End
Attribute VB_Name = "AL_Facturas"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public IdTipoVenta, Folio, RFC, Nombre, Direccion, Tel, IdCliente, IdSucursal
Dim LstDPartidas, Precio As Double, IdLista As Long, Iva As Double, VtaAnterior

Public Sub MuestraDetalle(Rep As Boolean)
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    StrCmd = "execute sel_VentasDetalle " & IdCedis & ", " & IdSurtido & ", " & IdTipoVenta & ", " & Folio & ", 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    If Not Rep Then LstDPartidas = GetDataLVL(RsC, LstPartidas, 4, 10, "0|0|9|7|7|7|7")
End Sub

Sub MuestraTotales(Rep As Boolean)
On Error Resume Next
    StrCmd = "execute sel_VentasDetalle " & IdCedis & ", " & IdSurtido & ", " & IdTipoVenta & ", " & Folio & ", 2"
    If RsC.State Then RsC.Close
    If Not Rep Then RsC.Open StrCmd, Cnn
    If Not Rep Then
        LblSubtotal.Caption = FormatCurrency(RsC.Fields(0), 2, vbTrue)
        LblIva.Caption = FormatCurrency(RsC.Fields(1), 2, vbTrue)
        LblTotal.Caption = FormatCurrency(RsC.Fields(2), 2, vbTrue)
    End If
End Sub

Private Sub btnEliminarVenta_Click()
On Error GoTo Err_EliminarFact:
    
    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    If Not ValidaModulo("LIQVTA", True) Then Exit Sub

    If MsgBox("¿ Está seguro que desea Eliminar la Factura " & Format(Folio, "0000000") & " del Cliente " & Chr(13) & Chr(10) & Nombre & " por " & LblTotal.Caption & " ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
        If MsgBox("La información se perderá. ¿ Desea continuar ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
        
        MousePointer = 11
            StrCmd = "execute up_Ventas " & IdCedis & ", " & IdSurtido & ", " & IdTipoVenta & ", " & Folio & ", '', '" & FormatDate(Fecha) & "', 0, 0, 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            
            StrCmd = "execute up_SurtidosDenominacion " & IdCedis & ", " & IdSurtido & ", '', '', 0, '', 0, 2"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            
            'valida kardex antes de ...
            StrCmd = "exec up_ActualizaKardex " & IdCedis & ", '" & FormatDate(FechaSel) & "', " & IdSurtido & ", 2"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
        MousePointer = 0
            MsgBox "¡ Factura Eliminada !", vbInformation + vbOKOnly, App.Title
            Unload Me
            AL_Liquidacion.MuestraFacturas
        End If
    End If

No_Err_EliminarFact:
    MousePointer = 0
    Exit Sub
    
Err_EliminarFact:
    MousePointer = 0
    MsgBox "¡ Error al Eliminar la Carga !. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_EliminarFact:

End Sub

Private Sub btnImprimeC_Click()
On Error GoTo ImpFact:
    With AL_RptFactura
        .LblFecha.Caption = Format(Fecha, "dd/mm/yyyy")
        .LblRFC.Caption = RFC
        .LblNombre.Caption = Nombre
        .LblDireccion.Caption = Direccion
        .LblSubtotal.Caption = FormatCurrency(LblSubtotal, 2, vbTrue)
        .LblIva.Caption = FormatCurrency(LblIva, 2, vbTrue)
        .LblTotal.Caption = FormatCurrency(LblTotal, 2, vbTrue)
        
        MuestraDetalle True
        If Not RsC.EOF Then
            .object.DataSrc.DataSourceName = Cnn
            .object.DataSrc.Recordset = RsC
        End If
        
        .Printer.Orientation = ddOPortrait
        .Printer.PaperSize = 1
        .Show
    End With
    
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
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    AL_al_ProductosBusqueda.Hide
End Sub

Private Sub Form_Load()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    'valida kardex antes de ...
    If ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then
        StrCmd = "exec up_ActualizaKardex " & IdCedis & ", '" & FormatDate(FechaSel) & "', " & IdSurtido & ", 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
    
        StrCmd = "execute up_SurtidosDenominacion " & IdCedis & ", " & IdSurtido & ", '', '', 0, '', 0, 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
    End If
    
    AL_Liquidacion.MuestraFacturas
End Sub

Private Sub TxtCantidad_GotFocus()
On Error Resume Next
    SelText TxtCantidad
End Sub

Private Sub TxtCantidad_KeyPress(KeyAscii As Integer)

On Error GoTo Err_Facturas:

Dim Existencias, Descuento, DctoCapturado

    If KeyAscii = 13 Then
       
        If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
        If Not ValidaModulo("LIQVTA", True) Then Exit Sub
        SplitTxt TxtCantidad
        
        If Dec Then
            TxtCantidad.Text = itFlotante(TxtCantidad.Text)
            'If Trim(TxtCantidad.Text) = "0" Then Exit Sub
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
        
        
        If ObtieneTipoRuta = 4 Then  'Existencias para Ruta mostrador
            
            If IsEmpty(LstDPartidas) Then
                Existencias = CDbl(TxtExistencia.Text)
            Else
                Existencias = VtaAnterior + CDbl(TxtExistencia.Text)
            End If
            
            If Existencias < CDbl(TxtCantidad.Text) Then
                MsgBox "¡ Existencias insuficientes !. Existencias en Almacén = " & FormatNumber(Existencias, 3, vbTrue), vbInformation + vbOKOnly, App.Title
                TxtCantidad.Text = Existencias
                TxtCantidad.SetFocus
                Exit Sub
            End If
        
        Else 'Existencias para Ruta Tradicional
            
            StrCmd = "execute sel_ExistenciaValida " & IdCedis & ", " & IdSurtido & ", " & IdTipoVenta & ", " & Folio & ", " & TxtIdProd.Text & ", " & TxtCantidad.Text & ", 0, 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            If Not Rs.EOF Then
                If FormatNumber(Rs.Fields(1), 4, 0) < 0 Then
                    MsgBox "¡ No hay Existencias suficientes para cubrir la cantidad solicitada !. Existencias = " & FormatNumber(Rs.Fields(2), 3, vbTrue), vbInformation + vbOKOnly, App.Title
                    TxtCantidad.Text = Rs.Fields(2)
                    Exit Sub
                End If
            End If
        End If
        
        
        StrCmd = "execute sel_ObtieneDescuento " & IdCedis & ", " & IdRuta & ", 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            Descuento = Rs.Fields(0)
        Else
            Descuento = 0
        End If
        
        If Descuento > 0 Then
Et_Dcto:
            DctoCapturado = InputBox("Descuento a Aplicar: ", "Descuento", Descuento)
            If Not IsNumeric(DctoCapturado) Then
                MsgBox ("¡ Teclea un descuento entre 0 y " & Descuento)
                GoTo Et_Dcto:
            End If
            
            If CDbl(DctoCapturado) > CDbl(Descuento) Then
                MsgBox ("¡ Teclea un descuento entre 0 y " & Descuento)
                GoTo Et_Dcto:
            End If
        End If
        
        Descuento = DctoCapturado
        Precio = Precio * (1 - (Descuento / 100))
        
        StrCmd = "execute up_VentasDetalle " & IdCedis & ", " & IdSurtido & ", " & IdTipoVenta & ", " & Folio & ", '" & Trim(TxtSerie.Text) & "', '" & FormatDate(Fecha) & "', " & TxtIdProd.Text & ", " & TxtCantidad.Text & ", " & Precio & ", " & Iva & ", 0, 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        If ObtieneTipoRuta = 4 Then
            StrCmd = "execute up_SurtidosCargas " & IdCedis & ", " & IdSurtido & ", " & IdCarga & ", " & Trim(TxtIdProd.Text) & ", '" & FormatDate(Fecha) & "', " & Trim(TxtCantidad.Text) & ", 2"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
        End If
        
        MuestraDetalle False
        MuestraTotales False
        
        TxtCantidad.Text = 0: TxtPrecio.Text = 0: TxtSubTotal.Text = 0: TxtIva.Text = 0: TxtTotal.Text = 0
        TxtIdProd.Text = "": TxtIdProd.SetFocus: TxtDesc.Text = "": TxtExistencia.Text = 0
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
        If Trim(TxtCantidad.Text) = "0" Then Exit Sub
    End If
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
        ValidaProductoVenta
        Exit Sub
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Sub ValidaProductoVenta()
On Error Resume Next
    If Trim(TxtIdProd.Text) <> "" Then
        ' valido q el producto esté en la Carga
        If ObtieneTipoRuta <> 4 Then
            StrCmd = "execute sel_ExistenciaValida " & IdCedis & ", " & IdSurtido & ", 0, 0, " & TxtIdProd.Text & ", 0, 0, 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
        
            If Not Rs.EOF Then
                TxtDesc.Text = UCase(Rs.Fields(1))
                TxtExistencia.Text = FormatNumber(Rs.Fields(2), 4, 0)
                Iva = Rs.Fields(3)
                Dec = IIf(Rs.Fields(4) = 1, True, False)
            Else
                MsgBox "¡ El Producto " & TxtIdProd.Text & " no está registrado en la Carga !", vbInformation + vbOKOnly, App.Title
                TxtDesc.Text = "¡ Producto no econtrado !": TxtCantidad.Text = 0: TxtPrecio.Text = 0: TxtSubTotal.Text = 0: TxtIva.Text = 0: TxtTotal.Text = 0: TxtExistencia.Text = 0
                TxtIdProd.SetFocus
                Exit Sub
            End If
        Else
            StrCmd = "execute sel_SurtidosCargaD " & IdCedis & ", " & IdSurtido & ", " & IdCarga & ", " & TxtIdProd.Text & ", '" & FormatDate(Fecha) & "', 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
        
            If Not Rs.EOF Then
                If Trim(UCase(Rs.Fields(5))) <> "A" Then
                    MsgBox "¡ El Producto " & TxtIdProd.Text & " está dado de Baja !", vbInformation + vbOKOnly, App.Title
                    TxtDesc.Text = "¡ Producto dado de Baja !": TxtCantidad.Text = 0: TxtExistencia.Text = 0
                    TxtIdProd.SetFocus
                    Exit Sub
                End If
                TxtExistencia.Text = Rs.Fields(3)
                TxtDesc.Text = UCase(Rs.Fields(1))
                TxtCantidad.Text = "0"
                Dec = IIf(Rs.Fields(4) = 1, True, False)
            Else
                MsgBox "¡ El Producto " & TxtIdProd.Text & " no existe !", vbInformation + vbOKOnly, App.Title
                TxtDesc.Text = "¡ Producto no econtrado !": TxtCantidad.Text = 0: TxtExistencia.Text = 0
            End If
        End If
        
        
        ' saco el producto tiene precio y el cedis tiene lista de contado...
        Precio = 0: IdLista = 0
        StrCmd = "execute sel_Precios " & IdCedis & ", " & IdCliente & ", " & IdRuta & ", " & TxtIdProd.Text & ", 0, 0, 0"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            Precio = Rs.Fields(1): IdLista = Rs.Fields(0)
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
        StrCmd = "execute sel_ExistenciaValida " & IdCedis & ", " & IdSurtido & ", " & IdTipoVenta & ", " & Folio & ", " & TxtIdProd.Text & ", 0, 0, 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            TxtCantidad.Text = Rs.Fields(1): TxtPrecio.Text = FormatCurrency(Rs.Fields(2), 2, vbTrue):
            TxtSubTotal.Text = FormatCurrency(Rs.Fields(3), 2, vbTrue): TxtIva.Text = FormatCurrency(Rs.Fields(4), 2, vbTrue): TxtTotal.Text = FormatCurrency(Rs.Fields(5), 2, vbTrue)
        Else
            TxtCantidad.Text = 0
        End If
    Else
        TxtDesc.Text = "": TxtCantidad.Text = 0: TxtPrecio.Text = 0: TxtSubTotal.Text = 0: TxtIva.Text = 0: TxtTotal.Text = 0: TxtExistencia.Text = 0
    End If
    VtaAnterior = CDbl(TxtCantidad.Text)
    TxtCantidad.SetFocus
    
    
End Sub

