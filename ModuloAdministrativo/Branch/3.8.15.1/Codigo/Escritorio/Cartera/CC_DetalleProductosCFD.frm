VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "Mscomctl.ocx"
Begin VB.Form CC_DetalleProductosCFD 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   6480
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   10995
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
   ScaleHeight     =   6480
   ScaleWidth      =   10995
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
      Height          =   6390
      Index           =   3
      Left            =   120
      TabIndex        =   2
      Top             =   0
      Width           =   10815
      Begin VB.Frame Frame1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Importe del Movimiento"
         Enabled         =   0   'False
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   700
         Left            =   3960
         TabIndex        =   28
         Top             =   1560
         Width           =   6735
         Begin VB.Label Label2 
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
            Left            =   4845
            TabIndex        =   32
            Top             =   240
            Width           =   1635
         End
         Begin VB.Label Label1 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Total Aplicado"
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
            Left            =   3585
            TabIndex        =   31
            Top             =   240
            Width           =   1155
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
            Left            =   1725
            TabIndex        =   30
            Top             =   240
            Width           =   1635
         End
         Begin VB.Label Label19 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Total Movimiento"
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
            TabIndex        =   29
            Top             =   240
            Width           =   1380
         End
      End
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
         Height          =   3975
         Index           =   0
         Left            =   120
         TabIndex        =   3
         Top             =   2280
         Width           =   10575
         Begin VB.TextBox TxtDesc 
            Height          =   375
            Left            =   1200
            TabIndex        =   1
            Top             =   480
            Width           =   5295
         End
         Begin VB.TextBox TxtIdProdD 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   120
            MaxLength       =   8
            TabIndex        =   0
            Top             =   480
            Width           =   975
         End
         Begin VB.TextBox TxtCantidad 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   6600
            MaxLength       =   8
            TabIndex        =   5
            Text            =   "1"
            Top             =   480
            Visible         =   0   'False
            Width           =   975
         End
         Begin VB.TextBox TxtDevolucion 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   7680
            Locked          =   -1  'True
            MaxLength       =   8
            TabIndex        =   4
            Text            =   "0"
            Top             =   480
            Visible         =   0   'False
            Width           =   975
         End
         Begin MSComctlLib.ListView LstPartidas 
            Height          =   2910
            Left            =   120
            TabIndex        =   6
            Top             =   960
            Width           =   10215
            _ExtentX        =   18018
            _ExtentY        =   5133
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
         Begin VB.Label Label12 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Descripción"
            Height          =   255
            Left            =   1320
            TabIndex        =   10
            Top             =   240
            Width           =   3735
         End
         Begin VB.Label Label14 
            Alignment       =   1  'Right Justify
            BackColor       =   &H00FFFFFF&
            Caption         =   "Venta"
            Height          =   255
            Left            =   6480
            TabIndex        =   9
            Top             =   240
            Visible         =   0   'False
            Width           =   975
         End
         Begin VB.Label Label6 
            Alignment       =   1  'Right Justify
            BackColor       =   &H00FFFFFF&
            Caption         =   "Devolución"
            Height          =   255
            Left            =   7680
            TabIndex        =   8
            Top             =   240
            Visible         =   0   'False
            Width           =   975
         End
         Begin VB.Label Label7 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cve."
            Height          =   255
            Left            =   240
            TabIndex        =   7
            Top             =   240
            Width           =   735
         End
      End
      Begin VB.Frame FrmTipo 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Importe del Movimiento"
         Enabled         =   0   'False
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   700
         Left            =   120
         TabIndex        =   25
         Top             =   1560
         Width           =   3735
         Begin VB.OptionButton OptTipo 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Por Producto"
            ForeColor       =   &H00000000&
            Height          =   255
            Index           =   0
            Left            =   2040
            MaskColor       =   &H00FFFFFF&
            TabIndex        =   27
            Top             =   240
            Visible         =   0   'False
            Width           =   1455
         End
         Begin VB.OptionButton OptTipo 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Por Porcentaje"
            ForeColor       =   &H00000000&
            Height          =   255
            Index           =   1
            Left            =   240
            MaskColor       =   &H00FFFFFF&
            TabIndex        =   26
            Top             =   240
            Value           =   -1  'True
            Width           =   1695
         End
      End
      Begin VB.Frame Frame2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Datos de la Venta"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   1215
         Left            =   120
         TabIndex        =   16
         Top             =   240
         Width           =   3975
         Begin VB.TextBox Text4 
            Appearance      =   0  'Flat
            BorderStyle     =   0  'None
            ForeColor       =   &H00000000&
            Height          =   255
            Left            =   1920
            Locked          =   -1  'True
            TabIndex        =   24
            Text            =   "Folio"
            Top             =   580
            Width           =   555
         End
         Begin VB.TextBox Text3 
            Appearance      =   0  'Flat
            BorderStyle     =   0  'None
            ForeColor       =   &H00000000&
            Height          =   255
            Left            =   240
            TabIndex        =   23
            Text            =   "Serie"
            Top             =   580
            Width           =   555
         End
         Begin VB.TextBox Text2 
            Appearance      =   0  'Flat
            BorderStyle     =   0  'None
            ForeColor       =   &H00000000&
            Height          =   255
            Left            =   225
            Locked          =   -1  'True
            TabIndex        =   22
            Text            =   "Tipo de Venta"
            Top             =   300
            Width           =   1275
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
            TabIndex        =   21
            Top             =   580
            Width           =   1215
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
            TabIndex        =   20
            Top             =   580
            Width           =   615
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
            TabIndex        =   19
            Top             =   300
            Width           =   2175
         End
         Begin VB.TextBox Text6 
            Appearance      =   0  'Flat
            BorderStyle     =   0  'None
            ForeColor       =   &H00000000&
            Height          =   255
            Left            =   240
            TabIndex        =   18
            Text            =   "Fecha"
            Top             =   840
            Width           =   555
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
            Left            =   960
            Locked          =   -1  'True
            TabIndex        =   17
            Top             =   840
            Width           =   1935
         End
      End
      Begin VB.Frame Frame3 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Datos del Cliente"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   1215
         Left            =   4200
         TabIndex        =   11
         Top             =   240
         Width           =   6495
         Begin VB.TextBox Txt12 
            Appearance      =   0  'Flat
            BorderStyle     =   0  'None
            ForeColor       =   &H00000000&
            Height          =   255
            Left            =   120
            TabIndex        =   15
            Text            =   "Sucursal"
            Top             =   720
            Width           =   855
         End
         Begin VB.TextBox Text5 
            Appearance      =   0  'Flat
            BorderStyle     =   0  'None
            ForeColor       =   &H00000000&
            Height          =   255
            Left            =   120
            Locked          =   -1  'True
            TabIndex        =   14
            Text            =   "Cliente"
            Top             =   360
            Width           =   735
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
            TabIndex        =   13
            Top             =   360
            Width           =   5175
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
            Left            =   1080
            Locked          =   -1  'True
            TabIndex        =   12
            Top             =   720
            Width           =   5295
         End
      End
   End
End
Attribute VB_Name = "CC_DetalleProductosCFD"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub TxtDesc_Change()
On Error Resume Next
    If KeyAscii = "13" Then
        MsgBox "guarda cambios ¡¡¡"
        Exit Sub
    End If
    
End Sub

Private Sub TxtDesc_GotFocus()
On Error Resume Next
    SelText TxtDesc
End Sub

Private Sub TxtIdProdD_GotFocus()
On Error Resume Next
    SelText TxtIdProdD
End Sub

Private Sub TxtIdProdD_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        TxtDesc.SetFocus
        Exit Sub
    End If

    KeyAscii = itString(KeyAscii)
End Sub
