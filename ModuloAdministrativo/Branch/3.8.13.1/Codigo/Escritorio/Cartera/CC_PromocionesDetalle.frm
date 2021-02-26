VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_PromocionesDetalle 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Detalle de la Aplicación de la Promoción"
   ClientHeight    =   7065
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
   ScaleHeight     =   7065
   ScaleWidth      =   12660
   ShowInTaskbar   =   0   'False
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
      Picture         =   "CC_PromocionesDetalle.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   2
      Top             =   6360
      Width           =   1815
   End
   Begin VB.Frame FrmDatos 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Detalle de la Aplicación del Acuerdo"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   6015
      Left            =   120
      TabIndex        =   1
      Top             =   120
      Width           =   12495
      Begin MSComctlLib.ListView LstDetalle 
         Height          =   5535
         Left            =   120
         TabIndex        =   0
         Top             =   360
         Width           =   12255
         _ExtentX        =   21616
         _ExtentY        =   9763
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
   Begin VB.Label Label2 
      Alignment       =   1  'Right Justify
      BackColor       =   &H00FFFFFF&
      Caption         =   "Número de Facturas Afectadas"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   6480
      TabIndex        =   6
      Top             =   6525
      Width           =   2835
   End
   Begin VB.Label LblFacturas 
      Alignment       =   1  'Right Justify
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "0"
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
      Left            =   9480
      TabIndex        =   5
      Top             =   6480
      Width           =   1035
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
      Left            =   4560
      TabIndex        =   4
      Top             =   6480
      Width           =   1635
   End
   Begin VB.Label LblSMonto 
      Alignment       =   1  'Right Justify
      BackColor       =   &H00FFFFFF&
      Caption         =   "Monto del Acuerdo"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   2280
      TabIndex        =   3
      Top             =   6525
      Width           =   2115
   End
End
Attribute VB_Name = "CC_PromocionesDetalle"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public IdAplicacionD, IdPromocionD
Dim LstDDetalle

Private Sub btnImprimeC_Click()
If IsEmpty(LstDDetalle) Then Exit Sub

On Error GoTo btnImprimeDetallePromocion:
    With CC_RptPromocionesDetalle
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
        .LblTitulo.Caption = "DETALLE DE LA APLICACIÓN DE ACUERDOS"
        .LblDatos.Caption = ""
        .IdPromo = IdPromocionD
        '.LblCedis.Caption = LstDCedis(0, cmbCedis.ListIndex - 1) & " - " & LstDCedis(1, cmbCedis.ListIndex - 1)
        
        StrCmd = "execute sel_PromocionesAplicadasDetalle " & IdAplicacionD & ", " & IdPromocionD & ", 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            .object.DataSrc.DataSourceName = Cnn
            .object.DataSrc.Recordset = Rs
        End If
        .Printer.Orientation = ddOPortrait
        .Printer.PaperSize = 1
        .Show
    End With
    
No_btnImprimeDetallePromocion:
    MousePointer = 0
    Exit Sub
    
btnImprimeDetallePromocion:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_btnImprimeDetallePromocion:

End Sub

Private Sub Form_Load()
On Error Resume Next
    MuestraDetalleAplicacion
End Sub

Sub MuestraDetalleAplicacion()
On Error Resume Next
    
    StrCmd = "execute sel_PromocionesAplicadasDetalle " & IdAplicacionD & ", " & IdPromocionD & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDDetalle = GetDataLVL(Rs, LstDetalle, 1, 12, "0|0|0|0|0|0|0|0|0|3|3|0")
    
    StrCmd = "execute sel_PromocionesAplicadasDetalle " & IdAplicacionD & ", " & IdPromocionD & ", 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        LblMonto.Caption = FormatCurrency(Rs.Fields(0), 2, vbTrue)
        LblFacturas.Caption = FormatNumber(Rs.Fields(1), 0, vbTrue)
    End If
    
End Sub

