VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_MovimientosDetalle 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Registro de Movimientos a Detalle"
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
      Caption         =   "Datos del Movimiento"
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
      TabIndex        =   17
      Top             =   120
      Width           =   12375
      Begin VB.TextBox Text6 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   5640
         Locked          =   -1  'True
         TabIndex        =   29
         Text            =   "Referencia Bancos"
         Top             =   720
         Width           =   1935
      End
      Begin VB.TextBox TxtReferenciaBancos 
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
         Left            =   7680
         Locked          =   -1  'True
         TabIndex        =   28
         Top             =   720
         Width           =   4575
      End
      Begin VB.TextBox Text3 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   2760
         Locked          =   -1  'True
         TabIndex        =   27
         Text            =   "Referencia"
         Top             =   720
         Width           =   975
      End
      Begin VB.TextBox TxtReferencia 
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
         Left            =   3960
         Locked          =   -1  'True
         TabIndex        =   26
         Top             =   720
         Width           =   1455
      End
      Begin VB.TextBox Text2 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   240
         Locked          =   -1  'True
         TabIndex        =   25
         Text            =   "Fecha"
         Top             =   720
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
         Left            =   1080
         Locked          =   -1  'True
         TabIndex        =   24
         Top             =   720
         Width           =   1455
      End
      Begin VB.TextBox TxtDocumentos 
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
         Left            =   5640
         Locked          =   -1  'True
         TabIndex        =   21
         Top             =   360
         Width           =   6615
      End
      Begin VB.TextBox TxtCedis 
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
         TabIndex        =   20
         Top             =   360
         Width           =   3255
      End
      Begin VB.TextBox Text5 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   240
         Locked          =   -1  'True
         TabIndex        =   19
         Text            =   "Cedis"
         Top             =   360
         Width           =   615
      End
      Begin VB.TextBox Txt12 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   4440
         TabIndex        =   18
         Text            =   "Documento"
         Top             =   360
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
      Left            =   2160
      Picture         =   "CC_MovimientosDetalle.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   10
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
      Height          =   5655
      Index           =   2
      Left            =   120
      TabIndex        =   12
      Top             =   1440
      Width           =   12375
      Begin VB.CommandButton btnFacturas 
         BackColor       =   &H00FFFFFF&
         Height          =   495
         Left            =   8040
         Picture         =   "CC_MovimientosDetalle.frx":0710
         Style           =   1  'Graphical
         TabIndex        =   42
         Top             =   240
         Width           =   495
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
         Left            =   360
         Locked          =   -1  'True
         TabIndex        =   41
         Text            =   "Nombre del Cliente"
         Top             =   1560
         Width           =   7455
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
         Picture         =   "CC_MovimientosDetalle.frx":0B24
         Style           =   1  'Graphical
         TabIndex        =   40
         Top             =   960
         Width           =   495
      End
      Begin VB.TextBox Text1 
         Alignment       =   1  'Right Justify
         Enabled         =   0   'False
         Height          =   360
         Left            =   6840
         Locked          =   -1  'True
         TabIndex        =   38
         Text            =   "0.00"
         Top             =   375
         Width           =   855
      End
      Begin VB.TextBox TxtIva 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   10080
         Locked          =   -1  'True
         TabIndex        =   8
         Text            =   "0.00"
         Top             =   1080
         Width           =   1335
      End
      Begin VB.ComboBox CmbSerie 
         Height          =   360
         Left            =   4200
         Style           =   2  'Dropdown List
         TabIndex        =   1
         Top             =   360
         Width           =   1575
      End
      Begin VB.ComboBox CmbTipoDocumento 
         Height          =   360
         Left            =   240
         Style           =   2  'Dropdown List
         TabIndex        =   0
         Top             =   360
         Width           =   3855
      End
      Begin MSComctlLib.ListView LstPartidas 
         Height          =   3750
         Left            =   120
         TabIndex        =   11
         Top             =   1800
         Width           =   12135
         _ExtentX        =   21405
         _ExtentY        =   6615
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
         Left            =   3360
         TabIndex        =   5
         Text            =   "0.00"
         Top             =   1080
         Width           =   1455
      End
      Begin VB.TextBox TxtImporte 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   8400
         TabIndex        =   3
         Top             =   1080
         Width           =   1455
      End
      Begin VB.TextBox TxtFolio 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   240
         MaxLength       =   8
         TabIndex        =   2
         Top             =   1080
         Width           =   1215
      End
      Begin VB.TextBox TxtMonto 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   1680
         Locked          =   -1  'True
         TabIndex        =   4
         Text            =   "0.00"
         Top             =   1080
         Width           =   1455
      End
      Begin VB.TextBox TxtAbonos 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   5040
         Locked          =   -1  'True
         TabIndex        =   6
         Text            =   "0.00"
         Top             =   1080
         Width           =   1455
      End
      Begin VB.TextBox TxtSaldo 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   6720
         Locked          =   -1  'True
         TabIndex        =   7
         Text            =   "0.00"
         Top             =   1080
         Width           =   1455
      End
      Begin VB.Label Label8 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Iva"
         Height          =   255
         Left            =   6120
         TabIndex        =   39
         Top             =   360
         Width           =   495
      End
      Begin VB.Label Label3 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Iva"
         Height          =   255
         Left            =   10440
         TabIndex        =   30
         Top             =   840
         Width           =   855
      End
      Begin VB.Label Label7 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Cargos"
         Height          =   255
         Left            =   3720
         TabIndex        =   23
         Top             =   840
         Width           =   975
      End
      Begin VB.Label Label5 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Importe"
         Height          =   255
         Left            =   8880
         TabIndex        =   22
         Top             =   840
         Width           =   855
      End
      Begin VB.Label Label14 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Abonos"
         Height          =   255
         Left            =   5400
         TabIndex        =   16
         Top             =   840
         Width           =   975
      End
      Begin VB.Label Label13 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Folio"
         Height          =   255
         Left            =   360
         TabIndex        =   15
         Top             =   840
         Width           =   495
      End
      Begin VB.Label Label12 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Monto"
         Height          =   255
         Left            =   2160
         TabIndex        =   14
         Top             =   840
         Width           =   855
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Saldo"
         Height          =   255
         Left            =   7200
         TabIndex        =   13
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
      Picture         =   "CC_MovimientosDetalle.frx":0F49
      Style           =   1  'Graphical
      TabIndex        =   9
      Top             =   7560
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
      Left            =   9360
      TabIndex        =   31
      Top             =   6960
      Width           =   3135
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
         TabIndex        =   37
         Top             =   240
         Width           =   720
      End
      Begin VB.Label Label4 
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
         TabIndex        =   36
         Top             =   600
         Width           =   270
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
         TabIndex        =   35
         Top             =   960
         Width           =   450
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
         TabIndex        =   34
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
         Left            =   1215
         TabIndex        =   33
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
         Left            =   1215
         TabIndex        =   32
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
Dim LstDPartidas, LstDTipoDocumento, LstDSeries, Folio, Serie, IdTipoVenta, Saldo
Public IdCedis, IdMovimiento, Fecha, IdDocumento, CargoAbono, Aplicado As Boolean, Inicio As Boolean

Public Sub MuestraDetalle(Rep As Boolean)
On Error Resume Next
    StrCmd = "execute sel_MovimientosFacturas " & IdCedis & ", " & IdMovimiento & ", '" & IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy")) & "', '" & IdDocumento & "', 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    If Not Rep Then LstDPartidas = GetDataLVL(RsC, LstPartidas, 1, 9, "0|0|1|9|9|9|9|9|0")
End Sub

Public Sub MuestraTotales(Rep As Boolean)
On Error Resume Next
    StrCmd = "execute sel_MovimientosFacturas " & IdCedis & ", " & IdMovimiento & ", '" & IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy")) & "', '" & IdDocumento & "', 2"
    If RsC.State Then RsC.Close
    If Not Rep Then
        RsC.Open StrCmd, Cnn
        LblSubtotal.Caption = FormatCurrency(RsC.Fields(0), 2, vbTrue)
        LblIva.Caption = FormatCurrency(RsC.Fields(1), 2, vbTrue)
        LblTotal.Caption = FormatCurrency(RsC.Fields(2), 2, vbTrue)
    End If
End Sub

Private Sub BtnDelete_Click()
On Error GoTo Err_btnDelete:

    If Aplicado Then
        MsgBox "¡ Documento Aplicado. No se puede modificar !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If MsgBox("¿ Está seguro que deseas Eliminar el Movimiento seleccionado ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    MousePointer = 11
    
    StrCmd = "execute up_MovimientosFacturas " & IdCedis & ", " & CLng(LstDPartidas(11, LstPartidas.SelectedItem.Index - 1)) & ", '" & Trim(LstPartidas.SelectedItem.ListSubItems(1)) & "', " & CLng(LstPartidas.SelectedItem.ListSubItems(2)) & ", " & IdMovimiento & ", '01/01/1900', " & CLng(LstDPartidas(10, LstPartidas.SelectedItem.Index - 1)) & ", '', '', '', '', '', 0, 0, '', '" & Usuario & "', 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    TxtFolio.Text = ""
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
    
    If MsgBox("¿ Está seguro que deseas Eliminar TODOS los Movimientos de Facturas seleccionado ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    MousePointer = 11
    
'    StrCmd = "execute up_MovimientosFacturas " & IdCedis & ", 0, '', 0, " & IdMovimiento & ", '01/01/1900', 0, '', '', '', 0, 0, '', '" & Usuario & "', 6"
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
        .LblTitulo.Caption = "REPORTE DE MOVIMIENTOS A FACTURAS"
        .LblDatos.Caption = "Tipo de Movimiento: " & TxtDocumentos.Text & "     " & Format(Fecha, ctFechaLarga)
        .LblCedis.Caption = TxtCedis.Text
        
        StrCmd = "execute Rep_Movimientos " & IdCedis & ", " & IdMovimiento & ", '01/01/1900', '01/01/1900', 1"
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

Private Sub Form_Activate()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    
    If Inicio Then
        If Aplicado Then
            TxtFolio.Enabled = False
            TxtImporte.Enabled = False
'            btnArchivo.Enabled = False
        End If
        MuestraDetalle False
        MuestraTotales False
        MuestraTipoDocumentos
        MuestraSeries
    End If
    Inicio = True
End Sub

Private Sub Form_Load()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
End Sub

Sub MuestraTipoDocumentos()
On Error Resume Next
    StrCmd = "execute sel_TipoDocumento '" & IdDocumento & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDTipoDocumento = GetDataCBL(Rs, CmbTipoDocumento, "Seleccione un Tipo de Documento", "No hay Tipos de Documentos")
End Sub

Sub MuestraSeries()
On Error Resume Next
    StrCmd = "execute sel_Series " & IdCedis & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDSeries = GetDataCBL(Rs, CmbSerie, "Serie", "No Series")
End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    CC_Movimientos.MuestraMovimientos
End Sub

Private Sub LstPartidas_DblClick()
On Error Resume Next
    If IsEmpty(LstDPartidas) Then Exit Sub
    DetalleDeFactura IdCedis, LstDPartidas(11, LstPartidas.SelectedItem.Index - 1), LstDPartidas(2, LstPartidas.SelectedItem.Index - 1), LstDPartidas(3, LstPartidas.SelectedItem.Index - 1), Me.Top, Me.Left, Me.Width, Me.Height, 0
End Sub

Private Sub TxtFolio_Change()
On Error Resume Next
    TxtMonto.Text = "0.00": TxtCargos.Text = "0.00": TxtAbonos.Text = "0.00"
    TxtSaldo.Text = "0.00": TxtImporte.Text = "": TxtIva.Text = "0.00"
End Sub

Private Sub TxtFolio_GotFocus()
On Error Resume Next
    SelText TxtFolio
End Sub

Private Sub TxtFolio_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        
        If Aplicado Then
            MsgBox "¡ Documento Aplicado. No se puede modificar !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If CmbTipoDocumento.ListIndex = 0 Or CmbSerie.ListIndex = 0 Then
            MsgBox "¡ Seleccione un Tipo de Documento y la Serie de Facturación !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        MousePointer = 11
        
        If Trim(TxtFolio.Text) = "" Then
            Folio = 0
        Else
            Folio = Trim(TxtFolio.Text)
        End If
        
        StrCmd = "execute sel_Ventas " & IdCedis & ", 0, '" & Trim(LstDSeries(0, CmbSerie.ListIndex - 1)) & "', " & Folio & ", 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            MsgBox "¡ La Factura ya está incluida en una factura global !", vbInformation + vbOKOnly, App.Title
            MousePointer = 0
            TxtFolio.Text = ""
            TxtFolio.SetFocus
            Exit Sub
        End If
        
        StrCmd = "execute sel_Ventas " & IdCedis & ", 0, '" & Trim(LstDSeries(0, CmbSerie.ListIndex - 1)) & "', " & Folio & ", 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        If Not Rs.EOF Then
        
            If Month(Rs.Fields(9)) > Month(Fecha) And Year(Rs.Fields(9)) >= Year(Fecha) Then
                MsgBox "¡ Las Facturas deben ser de " & Format(Fecha, "MMMM ""de"" yyyy") & " o anteriores !", vbInformation + vbOKOnly, App.Title
                MousePointer = 0
                TxtFolio.Text = ""
                TxtFolio.SetFocus
                Exit Sub
            End If
            
            If Rs.Fields(7) = 0 And CargoAbono = "A" Then
                MsgBox "¡ La Factura no tiene Saldo pendiente de Aplicar !", vbInformation + vbOKOnly, App.Title
                MousePointer = 0
                TxtFolio.Text = ""
                TxtFolio.SetFocus
                Exit Sub
            End If
            
            IdTipoVenta = Rs.Fields(1)
            TxtMonto.Text = FormatNumber(Rs.Fields(4), 2, vbTrue)
            TxtCargos.Text = FormatNumber(Rs.Fields(5), 2, vbTrue)
            TxtAbonos.Text = FormatNumber(Rs.Fields(6), 2, vbTrue)
            TxtSaldo.Text = FormatNumber(Rs.Fields(7), 2, vbTrue)
            TxtCliente.Text = Rs.Fields(8)
            Saldo = Rs.Fields(7)
            TxtImporte = Saldo
            
            MousePointer = 0
            TxtImporte.SetFocus
            Exit Sub
        Else
            MousePointer = 0
            MsgBox "¡ La Factura no existe !", vbInformation + vbOKOnly, App.Title
            TxtFolio.SetFocus
            Exit Sub
        End If
        
        MousePointer = 0
        TxtFolio.SetFocus
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
        
        If Aplicado Then
            MsgBox "¡ Documento Aplicado. No se puede modificar !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If CmbTipoDocumento.ListIndex = 0 Or CmbSerie.ListIndex = 0 Then
            MsgBox "¡ Seleccione un Tipo de Documento y la Serie de Facturación !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If IdTipoVenta = "0" Or IdTipoVenta = "" Or Folio = "0" Or Folio = "" Then
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
        
        If Importe = 0 Then Exit Sub
        
        If Importe > Saldo And CargoAbono = "A" Then
            MsgBox "¡ Importe del Movimiento es mayor al saldo disponible de la factura !", vbInformation + vbOKOnly, App.Title
            TxtImporte.Text = Saldo
            TxtImporte.SetFocus
            Exit Sub
        End If
        
        MousePointer = 11
        
        Iva = CDbl(TxtIva.Text) / 100
        Importe = Importe - Iva
        StrCmd = "execute up_MovimientosFacturas " & IdCedis & ", " & IdTipoVenta & ", '" & Trim(LstDSeries(0, CmbSerie.ListIndex - 1)) & "', " & Folio & ", " & IdMovimiento & ", '" & IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy")) & "', 0, '" & IdDocumento & "', '" & Trim(LstDTipoDocumento(0, CmbTipoDocumento.ListIndex - 1)) & "', '" & CargoAbono & "', '', '', " & Importe & ", " & Iva & ", 'A', '" & Usuario & "', 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        TxtFolio.Text = ""
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
