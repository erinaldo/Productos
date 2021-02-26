VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "Mscomctl.ocx"
Begin VB.Form CC_MovimientosDetalle 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Registro de Movimientos"
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
   Begin VB.CommandButton btnCxC 
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
      Left            =   2160
      Picture         =   "CC_MovimientosDetalle.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   49
      Top             =   7560
      Width           =   1695
   End
   Begin VB.Frame FrmAnticipo 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Datos del Anticipo"
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
      Left            =   6600
      TabIndex        =   41
      Top             =   240
      Visible         =   0   'False
      Width           =   6015
      Begin VB.TextBox TxtSaldoAnt 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   4440
         Locked          =   -1  'True
         TabIndex        =   48
         Top             =   360
         Width           =   1455
      End
      Begin VB.TextBox TxtAnticipo 
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
         Top             =   360
         Width           =   3495
      End
      Begin VB.TextBox Text7 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         Locked          =   -1  'True
         TabIndex        =   46
         Text            =   "Anticipo"
         Top             =   360
         Width           =   735
      End
      Begin VB.TextBox Text4 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         TabIndex        =   45
         Text            =   "Sucursal"
         Top             =   1080
         Width           =   855
      End
      Begin VB.TextBox Text5 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         Locked          =   -1  'True
         TabIndex        =   44
         Text            =   "Cliente"
         Top             =   720
         Width           =   735
      End
      Begin VB.TextBox TxtClienteAnt 
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
         Top             =   720
         Width           =   4815
      End
      Begin VB.TextBox TxtSucursalAnt 
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
         TabIndex        =   42
         Top             =   1080
         Width           =   4815
      End
   End
   Begin VB.CommandButton btnCobranzaHH 
      BackColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   3960
      Picture         =   "CC_MovimientosDetalle.frx":05D3
      Style           =   1  'Graphical
      TabIndex        =   14
      Top             =   7560
      Visible         =   0   'False
      Width           =   1695
   End
   Begin VB.Frame Frame3 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Datos del Folio"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1695
      Left            =   120
      TabIndex        =   22
      Top             =   120
      Width           =   6375
      Begin VB.ComboBox CmbDocumento 
         Height          =   360
         Left            =   1200
         Style           =   2  'Dropdown List
         TabIndex        =   0
         Top             =   720
         Width           =   3975
      End
      Begin VB.TextBox Text6 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   2760
         Locked          =   -1  'True
         TabIndex        =   29
         Text            =   "Referencia Bancos"
         Top             =   1200
         Width           =   1695
      End
      Begin VB.TextBox TxtReferenciaBancos 
         ForeColor       =   &H00000000&
         Height          =   375
         Left            =   4560
         Locked          =   -1  'True
         TabIndex        =   2
         Top             =   1200
         Width           =   1695
      End
      Begin VB.TextBox Text3 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         Locked          =   -1  'True
         TabIndex        =   28
         Text            =   "Referencia"
         Top             =   1200
         Width           =   975
      End
      Begin VB.TextBox TxtReferencia 
         ForeColor       =   &H00000000&
         Height          =   375
         Left            =   1200
         Locked          =   -1  'True
         TabIndex        =   1
         Top             =   1200
         Width           =   1455
      End
      Begin VB.TextBox Text2 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         Locked          =   -1  'True
         TabIndex        =   27
         Text            =   "Folio"
         Top             =   360
         Width           =   615
      End
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
         Left            =   840
         Locked          =   -1  'True
         TabIndex        =   26
         Top             =   360
         Width           =   5295
      End
      Begin VB.TextBox Txt12 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         TabIndex        =   23
         Text            =   "Documento"
         Top             =   720
         Width           =   1095
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
      Left            =   3960
      Picture         =   "CC_MovimientosDetalle.frx":0CF2
      Style           =   1  'Graphical
      TabIndex        =   15
      Top             =   7560
      Visible         =   0   'False
      Width           =   1695
   End
   Begin VB.Frame FrmOpt 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Detalles del Movimiento"
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
      TabIndex        =   17
      Top             =   1800
      Width           =   12495
      Begin VB.TextBox TxtIdTipoVenta 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   3960
         Locked          =   -1  'True
         TabIndex        =   40
         Text            =   "Tipo de Venta"
         Top             =   1560
         Width           =   2895
      End
      Begin VB.TextBox TxtCedis 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   240
         Locked          =   -1  'True
         TabIndex        =   39
         Text            =   "Cedis"
         Top             =   1560
         Width           =   3495
      End
      Begin VB.TextBox TxtSerie 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   240
         MaxLength       =   15
         TabIndex        =   4
         Top             =   1080
         Width           =   1215
      End
      Begin VB.ComboBox CmbTipoDocumento 
         Height          =   360
         Left            =   240
         Style           =   2  'Dropdown List
         TabIndex        =   3
         Top             =   360
         Width           =   3855
      End
      Begin VB.CommandButton btnFacturas 
         BackColor       =   &H00FFFFFF&
         Height          =   495
         Left            =   11520
         Picture         =   "CC_MovimientosDetalle.frx":1402
         Style           =   1  'Graphical
         TabIndex        =   12
         Top             =   960
         Visible         =   0   'False
         Width           =   615
      End
      Begin VB.TextBox TxtCliente 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   360
         Locked          =   -1  'True
         TabIndex        =   37
         Text            =   "Nombre del Cliente"
         Top             =   1800
         Width           =   11775
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
         Left            =   10680
         Picture         =   "CC_MovimientosDetalle.frx":17DA
         Style           =   1  'Graphical
         TabIndex        =   11
         Top             =   960
         Width           =   495
      End
      Begin MSComctlLib.ListView LstPartidas 
         Height          =   3150
         Left            =   120
         TabIndex        =   16
         Top             =   2040
         Width           =   12255
         _ExtentX        =   21616
         _ExtentY        =   5556
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
      Begin VB.TextBox TxtCargos 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   4440
         TabIndex        =   8
         Text            =   "0.00"
         Top             =   1080
         Width           =   1455
      End
      Begin VB.TextBox TxtImporte 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   9120
         TabIndex        =   6
         Top             =   1080
         Width           =   1455
      End
      Begin VB.TextBox TxtFolio 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   1560
         MaxLength       =   15
         TabIndex        =   5
         Top             =   1080
         Width           =   1215
      End
      Begin VB.TextBox TxtMonto 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   2880
         Locked          =   -1  'True
         TabIndex        =   7
         Text            =   "0.00"
         Top             =   1080
         Width           =   1455
      End
      Begin VB.TextBox TxtAbonos 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   6000
         Locked          =   -1  'True
         TabIndex        =   9
         Text            =   "0.00"
         Top             =   1080
         Width           =   1455
      End
      Begin VB.TextBox TxtSaldo 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   7560
         Locked          =   -1  'True
         TabIndex        =   10
         Text            =   "0.00"
         Top             =   1080
         Width           =   1455
      End
      Begin VB.Label Label3 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Serie"
         Height          =   255
         Left            =   360
         TabIndex        =   38
         Top             =   840
         Width           =   735
      End
      Begin VB.Label Label7 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Cargos"
         Height          =   255
         Left            =   4800
         TabIndex        =   25
         Top             =   840
         Width           =   975
      End
      Begin VB.Label Label5 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Importe"
         Height          =   255
         Left            =   9600
         TabIndex        =   24
         Top             =   840
         Width           =   855
      End
      Begin VB.Label Label14 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Abonos"
         Height          =   255
         Left            =   6360
         TabIndex        =   21
         Top             =   840
         Width           =   975
      End
      Begin VB.Label Label13 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Folio"
         Height          =   255
         Left            =   1680
         TabIndex        =   20
         Top             =   840
         Width           =   735
      End
      Begin VB.Label Label12 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Monto"
         Height          =   255
         Left            =   3360
         TabIndex        =   19
         Top             =   840
         Width           =   855
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Saldo"
         Height          =   255
         Left            =   8040
         TabIndex        =   18
         Top             =   840
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
      Picture         =   "CC_MovimientosDetalle.frx":1C79
      Style           =   1  'Graphical
      TabIndex        =   13
      Top             =   7560
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
      Left            =   9240
      TabIndex        =   30
      Top             =   6960
      Width           =   3375
      Begin VB.Label Label6 
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
         TabIndex        =   36
         Top             =   240
         Width           =   1200
      End
      Begin VB.Label Label4 
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
         Left            =   495
         TabIndex        =   35
         Top             =   600
         Width           =   930
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
         TabIndex        =   34
         Top             =   960
         Width           =   930
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
         Left            =   1575
         TabIndex        =   33
         Top             =   240
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
         Left            =   1575
         TabIndex        =   32
         Top             =   600
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
         Left            =   1575
         TabIndex        =   31
         Top             =   960
         Width           =   1635
      End
   End
End
Attribute VB_Name = "CC_MovimientosDetalle"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDPartidas, LstDTipoDocumento, LstDSeries, Saldo
Dim LstDCedis, LstDDocumento ', LstDVentas
Dim IdDocSaldar, IdTipoDocSaldar, TipoDocSaldar
Public IdDocumentoAnticipo, IdTipoDocumentoAnticipo, FolioAnticipo, SaldoAnticipo, CFD As Boolean
Public IdCedis, Folio, Fecha As Date, IdDocumento, CargoAbono, IdTipoVenta, FolioVenta, Serie, Aplicado As Boolean, Inicio As Boolean

Public Sub MuestraDetalle(Rep As Boolean)
On Error Resume Next
    StrCmd = "execute sel_MovimientosFacturas 0, " & Folio & ", '" & FormatDate(Fecha) & "', '" & IdDocumento & "', 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    If Not Rep Then
        LstDPartidas = GetDataLVL(RsC, LstPartidas, 1, 15, "0|0|0|1|9|9|9|9|9|0|0|0|0|0|0|0")
        LstPartidas_ItemClick LstPartidas.SelectedItem
    End If
End Sub

Public Sub MuestraTotales(Rep As Boolean)
On Error Resume Next
    StrCmd = "execute sel_MovimientosFacturas 0, " & Folio & ", '" & FormatDate(Fecha) & "', '" & IdDocumento & "', 2"
    If RsC.State Then RsC.Close
    If Not Rep Then
        RsC.Open StrCmd, Cnn
        LblSubtotal.Caption = FormatCurrency(RsC.Fields(0), 2, vbTrue)
        LblIva.Caption = FormatCurrency(RsC.Fields(1), 2, vbTrue)
        LblTotal.Caption = FormatCurrency(RsC.Fields(2), 2, vbTrue)
    End If
End Sub

Private Sub btnCxC_Click()
On Error Resume Next
    With CC_Cat_CxC
        .Top = Me.Top + ((Me.Height - .Height) / 2)
        .Left = Me.Left + ((Me.Width - .Width) / 2)
        .Show vbModal
    End With
End Sub

Private Sub BtnDelete_Click()
On Error GoTo Err_btnDelete:

    If Trim(UCase(CC_Movimientos.LstFolios.SelectedItem.ListSubItems(5))) <> UCase(Usuario) Then
        MousePointer = 0
        MsgBox "¡ El Movimiento " & CC_Movimientos.LstFolios.SelectedItem & " solo puede ser modificado por el Usuario """ & CC_Movimientos.LstFolios.SelectedItem.ListSubItems(5) & """ !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Aplicado Then
        MsgBox "¡ Documento Aplicado. No se puede modificar !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Not ValidaPeriodo(LstDPartidas(10, LstPartidas.SelectedItem.Index - 1), Year(Fecha), Month(Fecha), "C", "A", 1) Then
        MsgBox "¡ " & strPeriodo & " !", vbInformation + vbOKOnly, App.Title
        MousePointer = 0
        Exit Sub
    End If
    
    If MsgBox("¿ Está seguro que deseas Eliminar el Movimiento seleccionado ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    MousePointer = 11
    
    StrCmd = "execute up_MovimientosFacturas " & Folio & ", " & LstDPartidas(10, LstPartidas.SelectedItem.Index - 1) & ", " & LstDPartidas(17, LstPartidas.SelectedItem.Index - 1) & ", '" & LstDPartidas(3, LstPartidas.SelectedItem.Index - 1) & "', " & LstDPartidas(4, LstPartidas.SelectedItem.Index - 1) & ", " & LstDPartidas(18, LstPartidas.SelectedItem.Index - 1) & ", '01/01/1900', " & CLng(LstDPartidas(16, LstPartidas.SelectedItem.Index - 1)) & ", '', '', '', '', '', 0, 0, '', '" & Usuario & "', 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    If FolioAnticipo <> 0 Then
        StrCmd = "execute sel_Anticipos " & FolioAnticipo & ", '" & Usuario & "', 3"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            FolioAnticipo = CLng(Rs.Fields(1)): SaldoAnticipo = CDbl(Rs.Fields(4))
            TxtAnticipo.Text = Rs.Fields(1) & " - " & Rs.Fields(2) & " || Monto: " & FormatNumber(Rs.Fields(3), 2, vbTrue)
            TxtSaldoAnt.Text = "Saldo: " & FormatNumber(Rs.Fields(4), 2, vbTrue)
            TxtClienteAnt.Text = Rs.Fields(5) & " - " & Rs.Fields(6)
            TxtSucursalAnt.Text = Rs.Fields(7) & " - " & Rs.Fields(8)
        End If
    End If
    
    TxtFolio.Text = "": TxtSerie.Text = ""
    MuestraDetalle False
    MuestraTotales False
    
No_Err_btnDelete:
    MousePointer = 0
    TxtFolio.SetFocus
    Exit Sub
    
Err_btnDelete:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_btnDelete:
End Sub

Private Sub btnEliminarVenta_Click()
On Error GoTo Err_btnEliminarVenta:
    
    If MsgBox("¿ Está seguro que deseas Eliminar TODOS los Movimientos de Ventas de este Folio ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    MousePointer = 11
    
'    StrCmd = "execute up_MovimientosVentas " & IdCedis & ", 0, '', 0, " & Folio & ", '01/01/1900', 0, '', '', '', 0, 0, '', '" & Usuario & "', 6"
'    If Rs.State Then Rs.Close
'    Rs.Open StrCmd, Cnn
        
    MousePointer = 0
    Unload Me
        
No_Err_btnEliminarVenta:
    MousePointer = 0
    Exit Sub
    
Err_btnEliminarVenta:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_btnEliminarVenta:
    
End Sub

Private Sub btnFacturas_Click()
On Error Resume Next
    BusquedaDeFactura Top, Left, Width, Height
End Sub

Private Sub btnImprimeC_Click()
On Error GoTo ImprimeC:
    With CC_RptMovimiento
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
        .LblTitulo.Caption = "REPORTE DE MOVIMIENTOS A VENTAS"
        
        StrCmd = "execute Rep_Movimientos " & Folio & ", '01/01/1900', '01/01/1900', 1"
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
    
No_ImprimeC:
    MousePointer = 0
    Exit Sub
    
ImprimeC:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_ImprimeC:
End Sub

Private Sub CmbTipoDocumento_Click()
On Error Resume Next
    If CmbTipoDocumento.ListIndex > 0 Then
        If LstDTipoDocumento(3, CmbTipoDocumento.ListIndex - 1) <> "" And LstDTipoDocumento(4, CmbTipoDocumento.ListIndex - 1) <> "" Then
            With CC_Anticipos
                .Top = Me.Top + ((Me.Height - .Height) / 2)
                .Left = Me.Left + ((Me.Width - .Width) / 2)
                .Seleccionar = True
                .btnNuevo.Visible = False: .btnActualizar.Visible = False: .btnEliminar.Visible = False:
                .btnImprimeFactura.Visible = False: .btnAplica.Visible = False
                .btnSeleccionar.Visible = True
                .Show vbModal
            End With
            
            If FolioAnticipo = 0 Then
                MsgBox "¡ Debes seleccionar un Anticipo para poder Aplicar un Abono con Anticipo !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        Else
            FolioAnticipo = 0: IdDocumentoAnticipo = "": IdTipoDocumentoAnticipo = ""
        End If
        
        CFD = IIf(LstDTipoDocumento(5, CmbTipoDocumento.ListIndex - 1) = "N", False, True)
    Else
        FolioAnticipo = 0: IdDocumentoAnticipo = "": IdTipoDocumentoAnticipo = ""
        FrmAnticipo.Visible = False
        CFD = False
    End If
    FrmAnticipo.Visible = IIf(LstDTipoDocumento(3, CmbTipoDocumento.ListIndex - 1) <> "" And LstDTipoDocumento(4, CmbTipoDocumento.ListIndex - 1) <> "", True, False)
    FrmTipo.Enabled = IIf(LstDTipoDocumento(5, CmbTipoDocumento.ListIndex - 1) = "S", True, False)
End Sub

Sub MuestraTipoDocumentos()
On Error Resume Next
    StrCmd = "execute sel_TipoDocumento '" & LstDDocumento(0, CmbDocumento.ListIndex - 1) & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDTipoDocumento = GetDataCBL(Rs, CmbTipoDocumento, "Seleccione un Tipo de Documento", "No hay Tipos de Documentos")
End Sub

Private Sub Form_Activate()
On Error Resume Next
    
    If Inicio Then
        If Aplicado Then
            TxtFolioVenta.Enabled = False
            TxtImporte.Enabled = False
'            btnArchivo.Enabled = False
        End If
        
        MuestraDocumentos
        MuestraTipoDocumentos
        MuestraDetalle False
        MuestraTotales False
    End If
    Inicio = True

End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    CC_Movimientos.MuestraMovimientos
End Sub

Private Sub LstPartidas_DblClick()
On Error Resume Next
    If IsEmpty(LstDPartidas) Then Exit Sub
    DetalleDeFactura LstDPartidas(10, LstPartidas.SelectedItem.Index - 1), LstDPartidas(17, LstPartidas.SelectedItem.Index - 1), LstDPartidas(3, LstPartidas.SelectedItem.Index - 1), LstDPartidas(4, LstPartidas.SelectedItem.Index - 1), Me.Top, Me.Left, Me.Width, Me.Height, 0
End Sub

Private Sub LstPartidas_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    TxtCedis.Text = LstDPartidas(10, LstPartidas.SelectedItem.Index - 1) & " - " & LstDPartidas(11, LstPartidas.SelectedItem.Index - 1)
    TxtIdTipoVenta.Text = LstDPartidas(17, LstPartidas.SelectedItem.Index - 1) & " - " & IIf(LstDPartidas(17, LstPartidas.SelectedItem.Index - 1) = 1, "Venta de Contado", "Venta de Crédito")
    TxtCliente.Text = LstDPartidas(12, LstPartidas.SelectedItem.Index - 1) & " - " & LstDPartidas(13, LstPartidas.SelectedItem.Index - 1) & ". Sucursal: " & LstDPartidas(14, LstPartidas.SelectedItem.Index - 1) & " - " & LstDPartidas(15, LstPartidas.SelectedItem.Index - 1)
End Sub

Private Sub TxtFolio_Change()
On Error Resume Next
    TxtMonto.Text = "0.00": TxtCargos.Text = "0.00": TxtAbonos.Text = "0.00"
    TxtSaldo.Text = "0.00": TxtImporte.Text = ""
    IdTipoVenta = "": TxtIdTipoVenta.Text = ""
    IdCedis = "": TxtCedis.Text = ""
    FolioVenta = Trim(TxtFolio.Text)
End Sub

Private Sub TxtFolio_GotFocus()
On Error Resume Next
    SelText TxtFolio
End Sub

Private Sub TxtFolio_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        
        If CmbTipoDocumento.ListIndex > 0 Then
            If LstDTipoDocumento(3, CmbTipoDocumento.ListIndex - 1) <> "" And LstDTipoDocumento(4, CmbTipoDocumento.ListIndex - 1) <> "" Then
                If FolioAnticipo = 0 Then
                    MsgBox "¡ Debes seleccionar un Anticipo para poder Aplicar un Abono con Anticipo !", vbInformation + vbOKOnly, App.Title
                    Exit Sub
                End If
            End If
        End If
        
        If Trim(UCase(CC_Movimientos.LstFolios.SelectedItem.ListSubItems(5))) <> UCase(Usuario) Then
            MousePointer = 0
            MsgBox "¡ El Movimiento " & CC_Movimientos.LstFolios.SelectedItem & " solo puede ser modificado por el Usuario """ & CC_Movimientos.LstFolios.SelectedItem.ListSubItems(5) & """ !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If Aplicado Then
            MsgBox "¡ Documento Aplicado. No se puede modificar !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If CmbTipoDocumento.ListIndex = 0 Or CmbDocumento.ListIndex = 0 Then
            MsgBox "¡ Seleccione un Documento y Tipo de Documento !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        MousePointer = 11
        
        If FolioVenta = "" Then
            MousePointer = 0
            With CC_ListaVentas
                .LstDVentas = Empty
                .LstVentas.ListItems.Clear
                .TxtFolio.Text = "": .TxtSerie.Text = ""
                .TxtFolioCliente.Text = "": .TxtFolioEntrega.Text = ""
                .TxtFactura.Text = "": .TxtRemision.Text = ""
                .Top = Me.Top + ((Me.Height - .Height) / 2)
                .Left = Me.Left + ((Me.Width - .Width) / 2)
                .Tag = ""
                .Show vbModal
            End With
        Else
            StrCmd = "execute sel_Ventas 0, 0, '" & Serie & "', '" & FolioVenta & "', '" & Usuario & "', 1 "
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            CC_ListaVentas.LstDVentas = GetDataLVL(Rs, CC_ListaVentas.LstVentas, 0, 17, "0|0|0|0|0|0|0|0|0|0|9|9|9|9|0|0|0|0")
            If Not IsEmpty(CC_ListaVentas.LstDVentas) Then
                With CC_ListaVentas
                    .TxtFolio.Text = TxtFolio.Text: .TxtSerie.Text = TxtSerie.Text
                    .TxtFolioCliente.Text = "": .TxtFolioEntrega.Text = ""
                    .TxtFactura.Text = "": .TxtRemision.Text = ""
                    .Top = Me.Top + ((Me.Height - .Height) / 2)
                    .Left = Me.Left + ((Me.Width - .Width) / 2)
                    .Tag = ""
                    .Show vbModal
                End With
            Else
                TxtSerie.Text = "": TxtFolio.Text = ""
                MsgBox "¡ No se encontraron Ventas con la Serie y Folio seleccionados !", vbInformation + vbOKOnly, App.Title
                MousePointer = 0
                Exit Sub
            End If
        End If
        
        If FolioVenta = "" Or IdCedis = "" Or IdTipoVenta = "" Or Serie = "" Then
            MsgBox "¡ Debe seleccionar una Venta !", vbInformation + vbOKOnly, App.Title
            MousePointer = 0
            Exit Sub
        End If
        
        If Not ValidaPeriodo(IdCedis, Year(Fecha), Month(Fecha), "C", "A", 1) Then
            MsgBox "¡ " & strPeriodo & " !", vbInformation + vbOKOnly, App.Title
            TxtFolio.Text = "": TxtSerie.Text = ""
            MousePointer = 0
            Exit Sub
        End If
        
        StrCmd = "execute sel_Ventas " & IdCedis & ", " & IdTipoVenta & ", '" & Serie & "', '" & FolioVenta & "', '" & Usuario & "', 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            MsgBox "¡ La Venta ya está incluida en una Factura Global que aún no se ha Aplicado !", vbInformation + vbOKOnly, App.Title
            MousePointer = 0
            TxtFolio.Text = "": TxtSerie.Text = ""
            TxtFolio.SetFocus
            Exit Sub
        End If
        
        StrCmd = "execute sel_Ventas " & IdCedis & ", " & IdTipoVenta & ", '" & Serie & "', '" & FolioVenta & "', '" & Usuario & "', 3"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        If Not Rs.EOF Then
        
            If Month(Rs.Fields(2)) > Month(Fecha) And Year(Rs.Fields(2)) >= Year(Fecha) Then
                MsgBox "¡ Las Ventas deben ser de " & Format(Fecha, "MMMM ""de"" yyyy") & " o anteriores !", vbInformation + vbOKOnly, App.Title
                MousePointer = 0
                TxtFolioVenta.Text = ""
                TxtFolioVenta.SetFocus
                Exit Sub
            End If
            
            If CDbl(Rs.Fields(8)) <= 0 And CargoAbono = "A" Then
                MsgBox "¡ La Venta no tiene Saldo pendiente !", vbInformation + vbOKOnly, App.Title
                MousePointer = 0
                TxtSerie.Text = ""
                TxtFolio.Text = ""
                TxtFolio.SetFocus
                Exit Sub
            End If
            
            TxtMonto.Text = FormatNumber(Rs.Fields(5), 2, vbTrue)
            TxtCargos.Text = FormatNumber(Rs.Fields(6), 2, vbTrue)
            TxtAbonos.Text = FormatNumber(Rs.Fields(7), 2, vbTrue)
            TxtSaldo.Text = FormatNumber(Rs.Fields(8), 2, vbTrue)
            TxtCliente.Text = Rs.Fields(9) & " - " & Rs.Fields(10) & ". Sucursal: " & Rs.Fields(11) & " - " & Rs.Fields(12)
            Saldo = Rs.Fields(8)
            TxtImporte = Saldo
            
            MousePointer = 0
            TxtImporte.SetFocus
            Exit Sub
        Else
            MousePointer = 0
            MsgBox "¡ La Venta no existe !", vbInformation + vbOKOnly, App.Title
            TxtFolioVenta.SetFocus
            Exit Sub
        End If
        
        MousePointer = 0
        TxtFolioVenta.SetFocus
        Exit Sub
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtImporte_GotFocus()
On Error Resume Next
    SelText TxtImporte
End Sub

Private Sub TxtImporte_KeyPress(KeyAscii As Integer)

On Error GoTo Err_TxtImporte:

Dim Importe As Double, Iva As Double
    If KeyAscii = "13" Then
        
        If Trim(UCase(CC_Movimientos.LstFolios.SelectedItem.ListSubItems(5))) <> UCase(Usuario) Then
            MousePointer = 0
            MsgBox "¡ El Movimiento " & CC_Movimientos.LstFolios.SelectedItem & " solo puede ser modificado por el Usuario """ & CC_Movimientos.LstFolios.SelectedItem.ListSubItems(5) & """ !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If Aplicado Then
            MsgBox "¡ Documento Aplicado. No se puede modificar !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If CmbTipoDocumento.ListIndex = 0 Or CmbDocumento.ListIndex = 0 Then
            MsgBox "¡ Seleccione un Documento y Tipo de Documento !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If IdCedis = "" Or IdTipoVenta = "" Or FolioVenta = "" Or Serie = "" Then
            MsgBox "¡ Seleccione una Venta !", vbInformation + vbOKOnly, App.Title
            MousePointer = 0
            Exit Sub
        End If
        
        If Trim(TxtImporte.Text) = "" Then
            Importe = 0
            MousePointer = 0
            Exit Sub
        Else
            Importe = Trim(TxtImporte.Text)
        End If
        
        If Importe = 0 Then
            MsgBox "¡ Teclee el Importe del Movimiento !", vbInformation + vbOKOnly, App.Title
            TxtImporte.Text = Saldo
            TxtImporte.SetFocus
            Exit Sub
        End If
        
        If Importe > Saldo And CargoAbono = "A" Then
            MsgBox "¡ El Importe del Movimiento es mayor al Saldo disponible de la Venta !", vbInformation + vbOKOnly, App.Title
            TxtImporte.Text = Saldo
            TxtImporte.SetFocus
            Exit Sub
        End If
        
        If Importe > SaldoAnticipo And CargoAbono = "A" And FolioAnticipo <> 0 Then
            MsgBox "¡ El Importe del Movimiento es mayor al Saldo disponible del Anticipo !", vbInformation + vbOKOnly, App.Title
            TxtImporte.Text = SaldoAnticipo
            TxtImporte.SetFocus
            Exit Sub
        End If
        
        MousePointer = 11
        
        If FolioAnticipo = 0 Then
            StrCmd = "execute up_MovimientosFacturas " & Folio & ", " & IdCedis & ", " & IdTipoVenta & ", '" & Serie & "', " & FolioVenta & ", 0, '" & FormatDate(Fecha) & "', 0, '" & IdDocumento & "', '" & Trim(LstDTipoDocumento(0, CmbTipoDocumento.ListIndex - 1)) & "', '" & CargoAbono & "', '" & Trim(TxtReferencia.Text) & "', '" & Trim(TxtReferenciaBancos.Text) & "', " & Importe & ", 0, 'A', '" & Usuario & "', 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
        Else
            StrCmd = "execute up_MovimientosFacturasAnt " & Folio & ", " & IdCedis & ", " & IdTipoVenta & ", '" & Serie & "', " & FolioVenta & ", 0, '" & FormatDate(Fecha) & "', 0, '" & IdDocumento & "', '" & Trim(LstDTipoDocumento(0, CmbTipoDocumento.ListIndex - 1)) & "', '" & CargoAbono & "', '" & Trim(TxtReferencia.Text) & "', '" & Trim(TxtReferenciaBancos.Text) & "', " & Importe & ", 0, " & FolioAnticipo & ", 'A', '" & Usuario & "', 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
        
            StrCmd = "execute sel_Anticipos " & FolioAnticipo & ", '" & Usuario & "', 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            If Not Rs.EOF Then
                FolioAnticipo = CLng(Rs.Fields(1)): SaldoAnticipo = CDbl(Rs.Fields(4))
                TxtAnticipo.Text = Rs.Fields(1) & " - " & Rs.Fields(2) & " || Monto: " & FormatNumber(Rs.Fields(3), 2, vbTrue)
                TxtSaldoAnt.Text = "Saldo: " & FormatNumber(Rs.Fields(4), 2, vbTrue)
                TxtClienteAnt.Text = Rs.Fields(5) & " - " & Rs.Fields(6)
                TxtSucursalAnt.Text = Rs.Fields(7) & " - " & Rs.Fields(8)
            End If
        End If
        
        TxtFolio.Text = "": TxtSerie.Text = ""
        MuestraDetalle False
        MuestraTotales False
        
        MousePointer = 0
        TxtFolio.SetFocus
        Exit Sub
    End If
    KeyAscii = itDecimal(KeyAscii)
    
No_Err_TxtImporte:
    MousePointer = 0
    Exit Sub
    
Err_TxtImporte:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_TxtImporte:
End Sub

Private Sub TxtImporte_Validate(Cancel As Boolean)
On Error Resume Next
    TxtImporte.Text = itFlotante(Trim(TxtImporte.Text))
End Sub

Private Sub TxtReferenciaBancos_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtReferenciaBancos_Validate(Cancel As Boolean)
On Error Resume Next
    If Not Aplicado Then ValidaReferencia 2
End Sub

Private Sub TxtReferencia_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtReferencia_Validate(Cancel As Boolean)
On Error Resume Next
    If Not Aplicado Then ValidaReferencia 1
End Sub

Function ValidaReferencia(Opc As Integer) As Boolean
On Error Resume Next

'    If Opc = 1 And Trim(TxtReferencia.Text) = "" Then Exit Function
'    If Opc = 2 And Trim(TxtReferenciaBancos.Text) = "" Then Exit Function
'
'    StrCmd = "execute sel_Referencia 0, '" & IIf(Opc = 1, Trim(TxtReferencia.Text), Trim(TxtReferenciaBancos.Text)) & "', " & Opc
'    If Rs.State Then Rs.Close
'    Rs.Open StrCmd, Cnn
'    If Not Rs.EOF Then MsgBox "¡ La " & IIf(Opc = 1, "Referencia " & Trim(TxtReferencia.Text), "Referencia Bancos " & Trim(TxtReferenciaBancos.Text)) & " ya existe !", vbInformation + vbOKOnly, App.Title

End Function

'''Sub DocumentoSaldarFacturas()
'''On Error Resume Next
'''    StrCmd = "select isnull(Configuracion.IdDocumentoSaldar, ''), isnull(Configuracion.IdTipoDocumentoSaldar, ''), isnull(TipoDocumento, '') from Configuracion inner join DocumentosTipo on Configuracion.IdTipoDocumentoSaldar = DocumentosTipo.IdTipoDocumento and Configuracion.IdDocumentoSaldar = DocumentosTipo.IdDocumento "
'''    If Rs.State Then Rs.Close
'''    Rs.Open StrCmd, Cnn
'''    If Not Rs.EOF Then
'''        IdDocSaldar = Rs.Fields(0)
'''        IdTipoDocSaldar = Rs.Fields(1)
'''        TipoDocSaldar = Rs.Fields(2)
'''    End If
'''End Sub

Sub MuestraDocumentos()
On Error Resume Next
    StrCmd = "execute sel_Documentos '" & Usuario & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDDocumento = GetDataCBL(Rs, CmbDocumento, "Seleccione un Documento", "No hay Documentos")
End Sub

Private Sub CmbDocumento_Click()
On Error Resume Next
    If IsEmpty(LstDDocumento) Then Exit Sub
    If CmbDocumento.ListIndex = 0 Then
        'MsgBox "¡ Seleccione un Documento !", vbInformation + vbOKOnly, App.Title
        IdDocumento = ""
        MuestraTipoDocumentos
        btnCobranzaHH.Visible = False: TxtReferencia.Locked = True: TxtReferenciaBancos.Locked = True
    Else
        CargoAbono = Trim(LstDDocumento(2, CmbDocumento.ListIndex - 1))
        IdDocumento = Trim(LstDDocumento(0, CmbDocumento.ListIndex - 1))
        btnCobranzaHH.Visible = IIf(LstDDocumento(0, CmbDocumento.ListIndex - 1) = "CT", True, False)
        TxtReferencia.Locked = IIf(LstDDocumento(2, CmbDocumento.ListIndex - 1) = "A", False, True)
        TxtReferenciaBancos.Locked = IIf(LstDDocumento(2, CmbDocumento.ListIndex - 1) = "A", False, True)
        MuestraTipoDocumentos
    End If
    MuestraDetalle False
    MuestraTotales False
End Sub

Private Sub btnCobranzaHH_Click()
On Error Resume Next

    If MsgBox("¿ Está seguro que desea Importar la Cobranza de Vendedores ?", vbQuestion + vbYesNo) = vbNo Then Exit Sub
    
    With CC_ListaDiasCobranza
        .IdCed = LstDCedis(0, cmbCedis.ListIndex - 1)
        .Left = Me.Left + ((Me.Width - .Width) / 2)
        .Top = Me.Top + ((Me.Height - .Height) / 2)
        .Show
    End With
  
End Sub

Private Sub TxtSerie_Change()
On Error Resume Next
    Serie = Trim(TxtSerie.Text)
    TxtMonto.Text = "0.00": TxtCargos.Text = "0.00": TxtAbonos.Text = "0.00"
    TxtSaldo.Text = "0.00": TxtImporte.Text = ""
    IdTipoVenta = "": TxtIdTipoVenta.Text = ""
    IdCedis = "": TxtCedis.Text = ""
End Sub

Private Sub TxtSerie_GotFocus()
On Error Resume Next
    SelText TxtSerie
End Sub

Private Sub TxtSerie_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub
