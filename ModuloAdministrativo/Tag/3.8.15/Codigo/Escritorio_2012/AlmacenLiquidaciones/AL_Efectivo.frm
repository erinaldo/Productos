VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form AL_Efectivo 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Registro de Liquidación"
   ClientHeight    =   8430
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   9330
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
   ScaleWidth      =   9330
   ShowInTaskbar   =   0   'False
   Begin VB.Frame Frame4 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Total del Folio"
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
      TabIndex        =   48
      Top             =   7080
      Width           =   3015
      Begin VB.Label Label16 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Efectivo"
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
         TabIndex        =   52
         Top             =   400
         Width           =   630
      End
      Begin VB.Label Label15 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Documentos"
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
         Left            =   120
         TabIndex        =   51
         Top             =   760
         Width           =   1065
      End
      Begin VB.Label LblDocumentosFolio 
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
         Left            =   1320
         TabIndex        =   50
         Top             =   720
         Width           =   1515
      End
      Begin VB.Label LblEfectivoFolio 
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
         Left            =   1320
         TabIndex        =   49
         Top             =   360
         Width           =   1515
      End
   End
   Begin VB.Frame Frame3 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Selecciona el Folio de Entrega de Efectivo"
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
      Height          =   1575
      Left            =   120
      TabIndex        =   47
      Top             =   960
      Width           =   9135
      Begin VB.CommandButton btnEliminar 
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
         Left            =   7320
         Picture         =   "AL_Efectivo.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   2
         Top             =   840
         Width           =   1695
      End
      Begin VB.CommandButton btnNueva 
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
         Left            =   7320
         Picture         =   "AL_Efectivo.frx":0710
         Style           =   1  'Graphical
         TabIndex        =   1
         Top             =   240
         Width           =   1695
      End
      Begin MSComctlLib.ListView LstFoliosEfectivo 
         Height          =   1215
         Left            =   120
         TabIndex        =   0
         Top             =   240
         Width           =   7095
         _ExtentX        =   12515
         _ExtentY        =   2143
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
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
   Begin VB.Frame Frame2 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Datos de la Liquidación"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   735
      Left            =   120
      TabIndex        =   25
      Top             =   120
      Width           =   7215
      Begin VB.TextBox TxtLiquidacion 
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
         TabIndex        =   31
         Top             =   390
         Width           =   1335
      End
      Begin VB.TextBox TxtRuta 
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
         Left            =   3720
         Locked          =   -1  'True
         TabIndex        =   30
         Top             =   390
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
         Left            =   5160
         Locked          =   -1  'True
         TabIndex        =   29
         Top             =   390
         Width           =   1815
      End
      Begin VB.TextBox Text2 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   105
         Locked          =   -1  'True
         TabIndex        =   28
         Text            =   "No. Liquidación"
         Top             =   360
         Width           =   1400
      End
      Begin VB.TextBox Text3 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   3120
         TabIndex        =   27
         Text            =   "Ruta"
         Top             =   360
         Width           =   555
      End
      Begin VB.TextBox Text4 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   4560
         Locked          =   -1  'True
         TabIndex        =   26
         Text            =   "Fecha"
         Top             =   360
         Width           =   555
      End
   End
   Begin VB.CommandButton btnSalir 
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
      Height          =   425
      Left            =   600
      Picture         =   "AL_Efectivo.frx":0D9E
      Style           =   1  'Graphical
      TabIndex        =   15
      Top             =   8640
      Width           =   1455
   End
   Begin VB.Frame FrmOpt 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Detalle de Efectivo y Documentos"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   4335
      Index           =   2
      Left            =   120
      TabIndex        =   20
      Top             =   2640
      Width           =   9135
      Begin VB.ComboBox CmbMoneda 
         Height          =   360
         Left            =   1200
         Style           =   2  'Dropdown List
         TabIndex        =   3
         Top             =   380
         Width           =   3255
      End
      Begin VB.Frame FrmPago 
         BackColor       =   &H00FFFFFF&
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   735
         Index           =   1
         Left            =   120
         TabIndex        =   38
         Top             =   720
         Visible         =   0   'False
         Width           =   8775
         Begin VB.TextBox TxtImporte 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   7440
            MaxLength       =   8
            TabIndex        =   11
            Text            =   "0"
            Top             =   360
            Width           =   1335
         End
         Begin VB.TextBox TxtReferencia 
            Height          =   375
            Left            =   2520
            MaxLength       =   30
            TabIndex        =   10
            Top             =   360
            Width           =   4815
         End
         Begin VB.ComboBox CmbBanco 
            Height          =   360
            Left            =   120
            Style           =   2  'Dropdown List
            TabIndex        =   9
            Top             =   360
            Width           =   2295
         End
         Begin VB.Label Label8 
            Alignment       =   1  'Right Justify
            BackColor       =   &H00FFFFFF&
            Caption         =   "Importe"
            Height          =   255
            Left            =   7680
            TabIndex        =   41
            Top             =   120
            Width           =   975
         End
         Begin VB.Label Label6 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Referencia"
            Height          =   255
            Left            =   2640
            TabIndex        =   40
            Top             =   120
            Width           =   3135
         End
         Begin VB.Label Label5 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Banco"
            Height          =   255
            Left            =   240
            TabIndex        =   39
            Top             =   120
            Width           =   1095
         End
      End
      Begin VB.Frame FrmPago 
         BackColor       =   &H00FFFFFF&
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   735
         Index           =   0
         Left            =   120
         TabIndex        =   33
         Top             =   720
         Visible         =   0   'False
         Width           =   8775
         Begin VB.TextBox TxtCantidad 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   7440
            MaxLength       =   8
            TabIndex        =   7
            Text            =   "0"
            Top             =   360
            Width           =   1335
         End
         Begin VB.TextBox TxtIdDenom 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   2520
            MaxLength       =   5
            TabIndex        =   6
            Top             =   360
            Width           =   855
         End
         Begin VB.TextBox TxtDenom 
            Height          =   375
            Left            =   3480
            Locked          =   -1  'True
            TabIndex        =   8
            Top             =   360
            Width           =   3855
         End
         Begin VB.ComboBox cmbTipoDenominacion 
            Height          =   360
            Left            =   120
            Style           =   2  'Dropdown List
            TabIndex        =   5
            Top             =   360
            Width           =   2295
         End
         Begin VB.Label Label7 
            Alignment       =   1  'Right Justify
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cantidad"
            Height          =   255
            Left            =   7800
            TabIndex        =   37
            Top             =   120
            Width           =   855
         End
         Begin VB.Label Label13 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cve. P"
            Height          =   255
            Left            =   2520
            TabIndex        =   36
            Top             =   120
            Width           =   495
         End
         Begin VB.Label Label12 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Denominación"
            Height          =   255
            Left            =   3480
            TabIndex        =   35
            Top             =   120
            Width           =   3135
         End
         Begin VB.Label Label1 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Tipo Denom."
            Height          =   255
            Left            =   240
            TabIndex        =   34
            Top             =   120
            Width           =   1095
         End
      End
      Begin VB.ComboBox CmbConcepto 
         Height          =   360
         Left            =   5520
         Style           =   2  'Dropdown List
         TabIndex        =   4
         Top             =   380
         Width           =   2535
      End
      Begin MSComctlLib.ListView LstSurtidosDenominacion 
         Height          =   2670
         Left            =   120
         TabIndex        =   16
         Top             =   1560
         Width           =   8895
         _ExtentX        =   15690
         _ExtentY        =   4710
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
      Begin VB.Label Label9 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Moneda"
         Height          =   255
         Left            =   360
         TabIndex        =   46
         Top             =   360
         Width           =   735
      End
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Concepto"
         Height          =   255
         Left            =   4560
         TabIndex        =   32
         Top             =   360
         Width           =   975
      End
   End
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
      Left            =   240
      Picture         =   "AL_Efectivo.frx":12F5
      Style           =   1  'Graphical
      TabIndex        =   14
      Top             =   4560
      Visible         =   0   'False
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
      Left            =   3240
      TabIndex        =   21
      Top             =   6840
      Width           =   6015
      Begin VB.Label Label11 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Cobranza"
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
         Left            =   480
         TabIndex        =   45
         Top             =   780
         Width           =   795
      End
      Begin VB.Label LblCobranza 
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
         Left            =   1395
         TabIndex        =   44
         Top             =   720
         Width           =   1515
      End
      Begin VB.Label Label10 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Documentos"
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
         Left            =   3060
         TabIndex        =   43
         Top             =   645
         Width           =   1065
      End
      Begin VB.Label LblDocumentos 
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
         Left            =   4275
         TabIndex        =   42
         Top             =   600
         Width           =   1515
      End
      Begin VB.Label LblSaldo 
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
         Left            =   4275
         TabIndex        =   19
         Top             =   960
         Width           =   1515
      End
      Begin VB.Label LblEfectivo 
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
         Left            =   4275
         TabIndex        =   18
         Top             =   240
         Width           =   1515
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
         Left            =   1395
         TabIndex        =   17
         Top             =   360
         Width           =   1515
      End
      Begin VB.Label LblSaldoE 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Faltante"
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
         Left            =   3435
         TabIndex        =   24
         Top             =   975
         Width           =   660
      End
      Begin VB.Label Label3 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Efectivo"
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
         Left            =   3480
         TabIndex        =   23
         Top             =   285
         Width           =   630
      End
      Begin VB.Label Label4 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Total Contado"
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
         Left            =   120
         TabIndex        =   22
         Top             =   420
         Width           =   1155
      End
   End
   Begin VB.OptionButton Opt 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Monedas"
      Height          =   375
      Index           =   1
      Left            =   1560
      TabIndex        =   13
      Top             =   2760
      Width           =   1455
   End
   Begin VB.OptionButton Opt 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Billetes"
      Height          =   255
      Index           =   0
      Left            =   360
      TabIndex        =   12
      Top             =   2760
      Value           =   -1  'True
      Width           =   1095
   End
End
Attribute VB_Name = "AL_Efectivo"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDSurtidosDenominacion, LstDTipoDenominacion, LstDFoliosEfectivo
Dim LstDBancos, LstDTipoPago, LstDSurtidosCheques, LstDMoneda, Folio, Inicial As Boolean

Private Sub btnEliminar_Click()
On Error Resume Next

    If Not ValidaUsuarioEfectivo Then
        MsgBox "¡ El Usuario " & Usuario & " no puede Modificar el registro de Efectivo y Documentos !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If CDbl(LstDFoliosEfectivo(3, LstFoliosEfectivo.SelectedItem.Index - 1)) = 0 Or IsEmpty(LstDFoliosEfectivo) Then Exit Sub
    
    If MsgBox("Los Registros de Efectivo y Documentos se Eliminarán. ¿ Deseas continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    StrCmd = "execute up_SurtidosDenominacionFolio " & IdCedis & ", " & IdSurtido & ", " & Folio & ", '" & Usuario & "', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn

    StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", " & IdSurtido & ", 0, 0, 0, '', " & Folio & ", '" & _
    FormatDate(Fecha) & "', " & IdRuta & ", 0, '', 0, 'Eliminar', 'Entrega Efectivo, Liquidacion " & IdSurtido & ", Folio " & Folio & "', 6"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MuestraFoliosEfectivo

End Sub

Private Sub btnNueva_Click()
On Error Resume Next

'    If Not ValidaUsuarioEfectivo Then
'        MsgBox "¡ El Usuario " & Usuario & " no puede Modificar el registro de Efectivo y Documentos !", vbInformation + vbOKOnly, App.Title
'        Exit Sub
'    End If
    
    StrCmd = "execute up_SurtidosDenominacionFolio " & IdCedis & ", " & IdSurtido & ", " & Folio & ", '" & Usuario & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn

    MuestraFoliosEfectivo

    StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", " & IdSurtido & ", 0, 0, 0, '', " & LstDFoliosEfectivo(3, UBound(LstDFoliosEfectivo, 2)) & ", '" & _
    FormatDate(Fecha) & "', " & IdRuta & ", 0, '', 0, 'Insertar', 'Entrega Efectivo, Liquidacion " & IdSurtido & ", Folio  " & LstDFoliosEfectivo(3, UBound(LstDFoliosEfectivo, 2)) & "', 6"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
End Sub

Private Sub btnSalir_Click()
On Error Resume Next
    Unload Me
End Sub

Private Sub CmbBanco_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 Then TxtReferencia.SetFocus
End Sub

Private Sub CmbConcepto_Click()
On Error Resume Next
    Dim Index
    
    Index = Mid(CmbConcepto.ListIndex, 1, 1)
    
    FrmPago(0).Visible = False: FrmPago(1).Visible = False
    If Index = 1 Then FrmPago(0).Visible = True
    If Index > 1 Then FrmPago(1).Visible = True
    
End Sub

Private Sub CmbConcepto_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 Then
        If FrmPago(1).Visible Then
            CmbBanco.SetFocus
        Else
            cmbTipoDenominacion.SetFocus
        End If
    End If
End Sub

Private Sub cmbMoneda_Click()
On Error Resume Next
    If Val(TxtIdDenom) <> 0 Then TxtIdDenom_KeyPress 13 'Para validar la denominacion cuando se cambia de moneda
    MuestraDenominaciones
End Sub

Private Sub CmbMoneda_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 Then
        If Val(TxtIdDenom) <> 0 Then TxtIdDenom_KeyPress 13 'Para validar la denominacion cuando se cambia de moneda
        CmbConcepto.SetFocus
    End If
End Sub

Private Sub cmbTipoDenominacion_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 Then TxtIdDenom.SetFocus
End Sub

Private Sub Form_Load()
On Error Resume Next
    Folio = 0
    LlenaComboDenominaciones
    Inicial = True
        MuestraFoliosEfectivo
        CmbMoneda.ListIndex = 1
        CmbConcepto.ListIndex = 1
    Inicial = False
End Sub

Private Sub LstFoliosEfectivo_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    Folio = LstDFoliosEfectivo(3, LstFoliosEfectivo.SelectedItem.Index - 1)
    MuestraDenominaciones
End Sub

Private Sub LstSurtidosDenominacion_DblClick()
On Error Resume Next
    If IsEmpty(LstDSurtidosDenominacion) Then Exit Sub
    
    If Not ValidaUsuarioEfectivo Then
        MsgBox "¡ El Usuario " & Usuario & " no puede Modificar el registro de Efectivo y Documentos !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If CDbl(LstDSurtidosDenominacion(10, LstSurtidosDenominacion.SelectedItem.Index - 1)) > 0 Then
        If MsgBox("¿ Deseas Eliminar el Documento " & LstSurtidosDenominacion.SelectedItem.ListSubItems(3).Text & "?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        
        StrCmd = "execute up_SurtidosCheques " & IdCedis & ", " & IdSurtido & ", " & Folio & ", '" & UCase(Trim(Usuario)) & "', '" & LstDMoneda(0, CmbMoneda.ListIndex - 1) & "', " & LstDSurtidosDenominacion(10, LstSurtidosDenominacion.SelectedItem.Index - 1) & ", '', '', 0, 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", " & IdSurtido & ", 0, 0, 0, '', " & Folio & ", '" & _
        FormatDate(Fecha) & "', " & IdRuta & ", 0, '', 1, 'Actualizar', 'Entrega Efectivo, Liquidacion " & IdSurtido & ", Folio  " & Folio & ". ELIMINAR " & CmbConcepto.Text & ": Moneda " & CmbMoneda.Text & ", Banco " & CmbBanco.Text & ", IdDocumento " & LstDSurtidosDenominacion(10, LstSurtidosDenominacion.SelectedItem.Index - 1) & ", Importe " & TxtImporte.Text & "', 6"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        TxtReferencia.Text = "": TxtImporte.Text = ""
        MuestraDenominaciones
        
        CmbBanco.SetFocus
        Exit Sub
    End If
End Sub

Private Sub TxtCantidad_GotFocus()
On Error Resume Next
    SelText TxtCantidad
End Sub

Private Sub TxtCantidad_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 Then
    
        If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
        If Not ValidaModulo("EFECT", True) Then Exit Sub
        
        If Not ValidaUsuarioEfectivo Then
            MsgBox "¡ El Usuario " & Usuario & " no puede Modificar el registro de Efectivo y Documentos !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If CDbl(LstDFoliosEfectivo(3, LstFoliosEfectivo.SelectedItem.Index - 1)) = 0 Or IsEmpty(LstDFoliosEfectivo) Then Exit Sub
        
        If ValidarDenominacion(False) Then
        
            If Mid(cmbTipoDenominacion.Text, 1, 1) = "C" Then TxtCantidad.Text = itFlotante(TxtCantidad.Text)
            
            If CmbMoneda.ListIndex = 0 Or CmbConcepto.ListIndex = 0 Then
                MsgBox "¡ Seleccione la Moneda y el Concepto !", vbInformation + vbOKOnly, App.Title
                CmbMoneda.SetFocus
                Exit Sub
            End If
            
            If Mid(cmbTipoDenominacion.Text, 1, 1) = "<" Or Trim(TxtIdDenom.Text) = "" Then
                MsgBox "¡ Capture una Denominación Válida !", vbInformation + vbOKOnly, App.Title
                TxtIdDenom.Text = "": TxtDenom.Text = "": TxtCantidad.Text = ""
                Exit Sub
            End If
            StrCmd = "execute up_SurtidosDenominacion " & IdCedis & ", " & IdSurtido & ", " & Folio & ", '" & UCase(Trim(Usuario)) & "', '" & LstDMoneda(0, CmbMoneda.ListIndex - 1) & "', " & TxtIdDenom.Text & ", '" & Mid(cmbTipoDenominacion.Text, 1, 1) & "', " & TxtCantidad.Text & ", 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            
            StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", " & IdSurtido & ", 0, 0, 0, '', " & Folio & ", '" & _
            FormatDate(Fecha) & "', " & IdRuta & ", 0, '', 1, 'Actualizar', 'Entrega Efectivo, Liquidacion " & IdSurtido & ", Folio " & Folio & ". Moneda " & CmbMoneda.Text & ", Denominación: " & TxtCantidad.Text & " " & cmbTipoDenominacion.Text & " de " & TxtIdDenom.Text & "', 6"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            
            TxtIdDenom.Text = "": TxtDenom.Text = "": TxtCantidad.Text = ""
            MuestraDenominaciones
            cmbTipoDenominacion.SetFocus
            
        End If
    End If
    If Mid(cmbTipoDenominacion.Text, 1, 1) <> "C" Then
        KeyAscii = itEntero(KeyAscii)
    Else
        KeyAscii = itDecimal(KeyAscii)
    End If
End Sub

Private Sub TxtCantidad_Validate(Cancel As Boolean)
On Error Resume Next
End Sub

Private Sub TxtIdDenom_Change()
On Error Resume Next
    TxtDenom.Text = ""
End Sub

Private Sub TxtIdDenom_GotFocus()
On Error Resume Next
    SelText TxtIdDenom
End Sub

Private Sub TxtIdDenom_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 Then
    
        If CmbMoneda.ListIndex = 0 Or CmbConcepto.ListIndex = 0 Then
            MsgBox "¡ Seleccione la Moneda y el Concepto !", vbInformation + vbOKOnly, App.Title
            CmbMoneda.SetFocus
            Exit Sub
        End If
        
        ValidarDenominacion True
        
        'StrCmd = "execute sel_Denominacion " & IdCedis & ", " & IdSurtido & ", " & TxtIdDenom.Text & ", '" & Mid(cmbTipoDenominacion.Text, 1, 1) & "', '" & LstDMoneda(0, CmbMoneda.ListIndex - 1) & "', 1"
        'If Rs.State Then Rs.Close
        'Rs.Open StrCmd, Cnn
        'If Not Rs.EOF Then
        '    TxtDenom.Text = Rs.Fields(3)
        '    TxtCantidad.Text = Rs.Fields(4)
        '    TxtCantidad.SetFocus
        'Else
        '    TxtDenom.Text = "¡ No existe la Denominación !"
        '    MsgBox "¡ No existe la Denominación !", vbInformation + vbOKOnly, App.Title
        '    TxtIdDenom.SetFocus
        '    TxtIdDenom.Text = ""
        'End If
    End If
    KeyAscii = itDecimal(KeyAscii)
End Sub

Private Function ValidarDenominacion(Actualizar As Boolean) As Boolean
    StrCmd = "execute sel_Denominacion " & IdCedis & ", " & IdSurtido & ", " & TxtIdDenom.Text & ", '" & Mid(cmbTipoDenominacion.Text, 1, 1) & "', '" & LstDMoneda(0, CmbMoneda.ListIndex - 1) & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        If Actualizar Then
            TxtDenom.Text = Rs.Fields(3)
            TxtCantidad.Text = Rs.Fields(4)
            TxtCantidad.SetFocus
        End If
        ValidarDenominacion = True
    Else
        TxtDenom.Text = "¡ No existe la Denominación !"
        MsgBox "¡ No existe la Denominación !", vbInformation + vbOKOnly, App.Title
        TxtIdDenom.SetFocus
        TxtIdDenom.Text = ""
        ValidarDenominacion = False
    End If
End Function

Private Sub TxtIdDenom_Validate(Cancel As Boolean)
On Error Resume Next
    TxtIdDenom.Text = itFlotante(TxtIdDenom)
End Sub

Sub MuestraDenominaciones()
On Error Resume Next

    If ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then
        StrCmd = "execute up_SurtidosDenominacion " & IdCedis & ", " & IdSurtido & ", 0, '', '', 0, '', 0, 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
    End If
    
    StrCmd = "execute sel_DenominacionFolios " & IdCedis & ", " & IdSurtido & ", " & Folio & ", 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDSurtidosDenominacion = GetDataLVL(Rs, LstSurtidosDenominacion, 3, 9, "0|0|1|0|9|9|9")
    
    StrCmd = "execute sel_Denominacion " & IdCedis & ", " & IdSurtido & ", 0, '', '', 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    LblDocumentos.Caption = FormatCurrency(0, 2, vbTrue)
    LblTotal.Caption = FormatCurrency(0, 2, vbTrue)
    LblEfectivo.Caption = FormatCurrency(0, 2, vbTrue)
    LblSaldo.Caption = FormatCurrency(0, 2, vbTrue)
    LblCobranza.Caption = FormatCurrency(0, 2, vbTrue)
    If Not Rs.EOF Then
        LblTotal.Caption = FormatCurrency(Rs.Fields(0), 2, vbTrue)
        LblEfectivo.Caption = FormatCurrency(Rs.Fields(1), 2, vbTrue)
        LblSaldo.Caption = FormatCurrency(Rs.Fields(2), 2, vbTrue)
        LblDocumentos.Caption = FormatCurrency(Rs.Fields(3), 2, vbTrue)
        LblCobranza.Caption = FormatCurrency(Rs.Fields(4), 2, vbTrue)
        Select Case Rs.Fields(2)
            Case 0: LblSaldoE.Caption = "Saldo"
            Case Else: LblSaldoE.Caption = IIf(Rs.Fields(2) < 0, "Faltante", "Sobrante")
        End Select
    End If
    
    StrCmd = "execute sel_DenominacionFolios " & IdCedis & ", " & IdSurtido & ", " & Folio & ", 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LblEfectivoFolio.Caption = FormatCurrency(0, 2, vbTrue)
    LblDocumentosFolio.Caption = FormatCurrency(0, 2, vbTrue)
    If Not Rs.EOF Then
        LblEfectivoFolio.Caption = FormatCurrency(Rs.Fields(0), 2, vbTrue)
        LblDocumentosFolio.Caption = FormatCurrency(Rs.Fields(1), 2, vbTrue)
    End If

End Sub

Sub MuestraFoliosEfectivo()
On Error Resume Next

    StrCmd = "execute sel_DenominacionFolios " & IdCedis & ", " & IdSurtido & ", " & Folio & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDFoliosEfectivo = GetDataLVL(Rs, LstFoliosEfectivo, 3, 5, "6|0|0")
    Folio = 0
    If Not incial Then If Not IsEmpty(LstDFoliosEfectivo) Then LstFoliosEfectivo_ItemClick LstFoliosEfectivo.SelectedItem
End Sub

Sub LlenaComboDenominaciones()
On Error Resume Next
    StrCmd = "execute sel_Monedas '', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDMoneda = GetDataCBL(Rs, CmbMoneda, "Moneda", "No existen Denominaciones")
    
    StrCmd = "execute sel_TipoDenominacion "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDTipoDenominacion = GetDataCBL(Rs, cmbTipoDenominacion, "Denominación", "No existen Denominaciones")

    StrCmd = "execute sel_pagosbancos 1, 0, 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDTipoPago = GetDataCBL(Rs, CmbConcepto, "Concepto", "No existen Conceptos")

    StrCmd = "execute sel_pagosbancos 1, 0, 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDBancos = GetDataCBL(Rs, CmbBanco, "Banco", "No existen Bancos")
End Sub

Private Sub TxtImporte_GotFocus()
On Error Resume Next
    SelText TxtImporte
End Sub

Private Sub TxtImporte_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 Then
        If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
        If Not ValidaModulo("EFECT", True) Then Exit Sub
        
        If Not ValidaUsuarioEfectivo Then
            MsgBox "¡ El Usuario " & Usuario & " no puede Modificar el registro de Efectivo y Documentos !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If CDbl(LstDFoliosEfectivo(3, LstFoliosEfectivo.SelectedItem.Index - 1)) = 0 Or IsEmpty(LstDFoliosEfectivo) Then Exit Sub
    
        If CmbMoneda.ListIndex = 0 Or CmbConcepto.ListIndex = 0 Then
            MsgBox "¡ Seleccione la Moneda y el Concepto !", vbInformation + vbOKOnly, App.Title
            CmbMoneda.SetFocus
            Exit Sub
        End If
        
        If Mid(CmbBanco.Text, 1, 1) = "<" Or Trim(TxtReferencia.Text) = "" Or Trim(TxtImporte.Text) = "" Then
            MsgBox "¡ Capture todos los datos del Documento !", vbInformation + vbOKOnly, App.Title
            TxtReferencia.Text = "": TxtImporte.Text = ""
            Exit Sub
        Else
            If CDbl(TxtImporte.Text) = 0 Then
                MsgBox "¡ El importe del cheque debe ser mayo a cero !", vbInformation + vbOKOnly, App.Title
                TxtReferencia.Text = "": TxtImporte.Text = ""
                Exit Sub
            End If
        End If
        
        StrCmd = "execute up_SurtidosCheques " & IdCedis & ", " & IdSurtido & ", " & Folio & ", '" & UCase(Trim(Usuario)) & "', '" & LstDMoneda(0, CmbMoneda.ListIndex - 1) & "', 0, '" & Mid(CmbBanco.Text, 1, 1) & "', '" & Trim(TxtReferencia.Text) & "', " & TxtImporte.Text & ", 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", " & IdSurtido & ", 0, 0, 0, '', " & Folio & ", '" & _
        FormatDate(Fecha) & "', " & IdRuta & ", 0, '', 1, 'Actualizar', 'Entrega Efectivo, Liquidacion " & IdSurtido & ", Folio  " & Folio & ". " & CmbConcepto.Text & ": Moneda " & CmbMoneda.Text & ", Banco " & CmbBanco.Text & ", Referencia " & Trim(TxtReferencia.Text) & ", Importe " & TxtImporte.Text & "', 6"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        TxtReferencia.Text = "": TxtImporte.Text = ""
        MuestraDenominaciones
        
        CmbBanco.SetFocus
        Exit Sub
    End If
    KeyAscii = itDecimal(KeyAscii)
End Sub

Private Sub TxtImporte_Validate(Cancel As Boolean)
On Error Resume Next
    TxtImporte.Text = itFlotante(TxtImporte.Text)
End Sub

Private Sub TxtReferencia_GotFocus()
On Error Resume Next
    SelText TxtReferencia
End Sub

Private Sub TxtReferencia_KeyPress(KeyAscii As Integer)
On Error Resume Next
    
    If KeyAscii = 13 Then
        TxtImporte.SetFocus
        Exit Sub
    End If
    KeyAscii = itString(KeyAscii)
End Sub

Function ValidaUsuarioEfectivo() As Boolean
On Error Resume Next
ValidaUsuarioEfectivo = False
    If UBound(LstDFoliosEfectivo, 2) >= 1 Then
        If Trim(UCase(LstDFoliosEfectivo(4, LstFoliosEfectivo.SelectedItem.Index - 1))) = Trim(UCase(Usuario)) Then ValidaUsuarioEfectivo = True
    Else
        ValidaUsuarioEfectivo = True
    End If
End Function
