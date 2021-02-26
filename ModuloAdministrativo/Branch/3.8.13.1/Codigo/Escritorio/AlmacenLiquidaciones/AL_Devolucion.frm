VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form AL_Devolucion 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Registro de Devoluciones"
   ClientHeight    =   7335
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
   ScaleHeight     =   7335
   ScaleWidth      =   12660
   ShowInTaskbar   =   0   'False
   Begin TabDlg.SSTab SSTab 
      Height          =   7095
      Left            =   120
      TabIndex        =   17
      Top             =   120
      Width           =   12375
      _ExtentX        =   21828
      _ExtentY        =   12515
      _Version        =   393216
      Tabs            =   2
      TabsPerRow      =   2
      TabHeight       =   520
      BackColor       =   16777215
      TabCaption(0)   =   "&Captura de Devoluciones"
      TabPicture(0)   =   "AL_Devolucion.frx":0000
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "LblOpt(6)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "FrmOpt(2)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "&Detalle de la Devolución"
      TabPicture(1)   =   "AL_Devolucion.frx":001C
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "FrmOpt(3)"
      Tab(1).Control(1)=   "LblOpt(0)"
      Tab(1).ControlCount=   2
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
         Height          =   6750
         Index           =   3
         Left            =   -75000
         TabIndex        =   28
         Top             =   345
         Width           =   12375
         Begin VB.TextBox Txt12 
            Appearance      =   0  'Flat
            BorderStyle     =   0  'None
            ForeColor       =   &H00000000&
            Height          =   255
            Left            =   2280
            TabIndex        =   39
            Text            =   "Cliente"
            Top             =   720
            Width           =   735
         End
         Begin VB.TextBox Text5 
            Appearance      =   0  'Flat
            BorderStyle     =   0  'None
            ForeColor       =   &H00000000&
            Height          =   255
            Left            =   240
            Locked          =   -1  'True
            TabIndex        =   38
            Text            =   "R.F.C."
            Top             =   720
            Width           =   615
         End
         Begin VB.TextBox TxtRFC2 
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
            Left            =   960
            Locked          =   -1  'True
            TabIndex        =   37
            Top             =   720
            Width           =   1215
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
            Left            =   3120
            Locked          =   -1  'True
            TabIndex        =   36
            Top             =   720
            Width           =   4575
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
            Left            =   1200
            Locked          =   -1  'True
            TabIndex        =   35
            Top             =   1005
            Width           =   6495
         End
         Begin VB.TextBox Text6 
            Appearance      =   0  'Flat
            BorderStyle     =   0  'None
            ForeColor       =   &H00000000&
            Height          =   255
            Left            =   240
            TabIndex        =   34
            Text            =   "Sucursal"
            Top             =   1005
            Width           =   855
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
            Left            =   600
            Picture         =   "AL_Devolucion.frx":0038
            Style           =   1  'Graphical
            TabIndex        =   33
            Top             =   6120
            Visible         =   0   'False
            Width           =   1695
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
            Height          =   4695
            Index           =   0
            Left            =   120
            TabIndex        =   32
            Top             =   1320
            Width           =   12135
            Begin VB.TextBox TxtDesc 
               Height          =   375
               Left            =   1200
               TabIndex        =   6
               Top             =   480
               Width           =   6135
            End
            Begin VB.TextBox TxtEntregado 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   7440
               Locked          =   -1  'True
               MaxLength       =   8
               TabIndex        =   9
               Text            =   "0"
               Top             =   1080
               Visible         =   0   'False
               Width           =   975
            End
            Begin VB.TextBox TxtDctoImp 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   10680
               Locked          =   -1  'True
               MaxLength       =   8
               TabIndex        =   12
               Text            =   "0"
               Top             =   480
               Visible         =   0   'False
               Width           =   1095
            End
            Begin VB.TextBox TxtDctoPorc 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   9600
               Locked          =   -1  'True
               MaxLength       =   8
               TabIndex        =   11
               Text            =   "0"
               Top             =   480
               Visible         =   0   'False
               Width           =   975
            End
            Begin VB.TextBox TxtExistencia 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   5160
               MaxLength       =   8
               TabIndex        =   7
               Text            =   "0"
               Top             =   480
               Visible         =   0   'False
               Width           =   1095
            End
            Begin VB.TextBox TxtIdProd 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   120
               MaxLength       =   10
               TabIndex        =   5
               Top             =   480
               Width           =   975
            End
            Begin VB.TextBox TxtCantidad 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   7440
               MaxLength       =   8
               TabIndex        =   8
               Text            =   "0"
               Top             =   480
               Width           =   975
            End
            Begin VB.TextBox TxtPrecio 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   8520
               Locked          =   -1  'True
               MaxLength       =   8
               TabIndex        =   10
               Text            =   "0"
               Top             =   480
               Visible         =   0   'False
               Width           =   975
            End
            Begin MSComctlLib.ListView LstPartidas 
               Height          =   3630
               Left            =   120
               TabIndex        =   40
               Top             =   960
               Width           =   11895
               _ExtentX        =   20981
               _ExtentY        =   6403
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
            Begin VB.Label Label10 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Entregado"
               Height          =   255
               Left            =   7440
               TabIndex        =   48
               Top             =   840
               Visible         =   0   'False
               Width           =   975
            End
            Begin VB.Label Label9 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Dcto Importe"
               Height          =   255
               Left            =   10560
               TabIndex        =   47
               Top             =   240
               Visible         =   0   'False
               Width           =   1215
            End
            Begin VB.Label Label8 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Dcto %"
               Height          =   255
               Left            =   9480
               TabIndex        =   46
               Top             =   240
               Visible         =   0   'False
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
               Visible         =   0   'False
               Width           =   975
            End
            Begin VB.Label Label14 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Cantidad"
               Height          =   255
               Left            =   7320
               TabIndex        =   44
               Top             =   240
               Width           =   975
            End
            Begin VB.Label Label13 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Cve. P"
               Height          =   255
               Left            =   240
               TabIndex        =   43
               Top             =   240
               Width           =   495
            End
            Begin VB.Label Label12 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Descripción del Producto"
               Height          =   255
               Left            =   1320
               TabIndex        =   42
               Top             =   240
               Width           =   3735
            End
            Begin VB.Label Label11 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Precio"
               Height          =   255
               Left            =   8520
               TabIndex        =   41
               Top             =   240
               Visible         =   0   'False
               Width           =   855
            End
         End
         Begin VB.CommandButton Command1 
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
            Left            =   2400
            Picture         =   "AL_Devolucion.frx":0753
            Style           =   1  'Graphical
            TabIndex        =   31
            Top             =   6120
            Visible         =   0   'False
            Width           =   1695
         End
         Begin VB.Label LblPedido 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Pedido"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   12
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000080&
            Height          =   270
            Index           =   0
            Left            =   360
            TabIndex        =   29
            Top             =   240
            Width           =   765
         End
         Begin VB.Line Line1 
            X1              =   120
            X2              =   12255
            Y1              =   600
            Y2              =   600
         End
      End
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
         Height          =   6750
         Index           =   2
         Left            =   0
         TabIndex        =   19
         Top             =   345
         Width           =   12375
         Begin VB.CommandButton btnAplica 
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
            Left            =   120
            Picture         =   "AL_Devolucion.frx":0E63
            Style           =   1  'Graphical
            TabIndex        =   52
            Top             =   1680
            Width           =   1695
         End
         Begin VB.TextBox TxtFolio 
            Alignment       =   1  'Right Justify
            Height          =   360
            Left            =   2760
            Locked          =   -1  'True
            TabIndex        =   50
            Text            =   "0"
            Top             =   300
            Width           =   1335
         End
         Begin VB.CommandButton btnSeleccionar 
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
            Left            =   120
            Picture         =   "AL_Devolucion.frx":14FA
            Style           =   1  'Graphical
            TabIndex        =   49
            Top             =   2880
            Visible         =   0   'False
            Width           =   1695
         End
         Begin VB.CommandButton btnNuevaVenta 
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
            Left            =   120
            Picture         =   "AL_Devolucion.frx":1C4C
            Style           =   1  'Graphical
            TabIndex        =   0
            Top             =   480
            Width           =   1695
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
            Left            =   120
            Picture         =   "AL_Devolucion.frx":22DA
            Style           =   1  'Graphical
            TabIndex        =   15
            Top             =   1080
            Width           =   1695
         End
         Begin VB.CommandButton btnImprimirVenta 
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
            Left            =   120
            Picture         =   "AL_Devolucion.frx":29EA
            Style           =   1  'Graphical
            TabIndex        =   16
            Top             =   2280
            Width           =   1695
         End
         Begin VB.CommandButton btnActualizaVenta 
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
            Left            =   120
            Picture         =   "AL_Devolucion.frx":3105
            Style           =   1  'Graphical
            TabIndex        =   1
            Top             =   480
            Visible         =   0   'False
            Width           =   1695
         End
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
            Height          =   3135
            Left            =   1920
            TabIndex        =   21
            Top             =   840
            Width           =   10215
            Begin VB.TextBox TxtIdCliente 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   120
               TabIndex        =   2
               Top             =   600
               Width           =   975
            End
            Begin VB.TextBox TxtRFC 
               Height          =   375
               Left            =   3600
               TabIndex        =   4
               Top             =   600
               Width           =   1815
            End
            Begin VB.TextBox TxtRazonSocial 
               Height          =   375
               Left            =   1200
               TabIndex        =   3
               Top             =   600
               Width           =   2295
            End
            Begin MSComctlLib.ListView LstClientes 
               Height          =   1935
               Left            =   120
               TabIndex        =   13
               Top             =   1080
               Width           =   9975
               _ExtentX        =   17595
               _ExtentY        =   3413
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
            Begin VB.Label LblCliente 
               BackColor       =   &H00FFFFFF&
               BeginProperty Font 
                  Name            =   "Arial"
                  Size            =   8.25
                  Charset         =   0
                  Weight          =   700
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   210
               Index           =   1
               Left            =   5520
               TabIndex        =   27
               Top             =   840
               Width           =   4485
            End
            Begin VB.Label Label26 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Cliente Seleccionado"
               Height          =   195
               Left            =   5520
               TabIndex        =   26
               Top             =   300
               Width           =   1830
            End
            Begin VB.Label LblCliente 
               BackColor       =   &H00FFFFFF&
               BeginProperty Font 
                  Name            =   "Arial"
                  Size            =   8.25
                  Charset         =   0
                  Weight          =   700
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   210
               Index           =   0
               Left            =   5520
               TabIndex        =   25
               Top             =   540
               Width           =   4485
            End
            Begin VB.Label Label20 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "No. Cliente"
               Height          =   240
               Left            =   120
               TabIndex        =   24
               Top             =   360
               Width           =   960
            End
            Begin VB.Label Label21 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Razón Social ( Cliente )"
               Height          =   255
               Left            =   1200
               TabIndex        =   23
               Top             =   360
               Width           =   2295
            End
            Begin VB.Label Label22 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Sucursal"
               Height          =   240
               Left            =   3600
               TabIndex        =   22
               Top             =   360
               Width           =   765
            End
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
            Height          =   2535
            Left            =   120
            TabIndex        =   20
            Top             =   4080
            Width           =   12015
            Begin MSComctlLib.ListView LstDevolucion 
               Height          =   2175
               Left            =   120
               TabIndex        =   14
               Top             =   240
               Width           =   11775
               _ExtentX        =   20770
               _ExtentY        =   3836
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
         Begin VB.Line Line2 
            X1              =   2040
            X2              =   12135
            Y1              =   720
            Y2              =   720
         End
         Begin VB.Label LblPedido 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Pedido"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   12
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000080&
            Height          =   270
            Index           =   1
            Left            =   4560
            TabIndex        =   53
            Top             =   360
            Width           =   765
         End
         Begin VB.Label Label18 
            Alignment       =   1  'Right Justify
            BackColor       =   &H00FFFFFF&
            Caption         =   "Folio"
            Height          =   255
            Left            =   2160
            TabIndex        =   51
            Top             =   360
            Width           =   495
         End
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FFFFFF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Detalle de la Devolución"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   0
         Left            =   -68835
         TabIndex        =   30
         Top             =   0
         Width           =   6210
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FFFFFF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Captura de Devoluciones"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   6
         Left            =   0
         TabIndex        =   18
         Top             =   0
         Width           =   6200
      End
   End
End
Attribute VB_Name = "AL_Devolucion"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDDevolucion, LstDPartidas, LstDClientes, Cancela As Boolean, IdDevolucion, IdCliente, IdSucursal, Dec As Boolean

Private Sub btnActualizaVenta_Click()
On Error GoTo Err_ActualizaDev

    If IdCliente = 0 Or IdSucursal = 0 Then
        MsgBox "¡ Seleccione un Cliente y una Sucursal a quien se le va a asignar la Devolución !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    StrCmd = "execute up_Devolucion " & IdCedis & ", " & IdSurtido & ", " & IdDevolucion & ", " & IdCliente & ", '" & IdSucursal & "', 'A', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    MuestraDevolucion
    
    IdSucursal = 0: IdCliente = 0
        
    CancelaVenta
    Cancela = False
    btnEliminarVenta.Picture = LoadPicture(App.Path & "\Imagenes\Botones\btnEliminar.jpg")
    btnNuevaVenta.Visible = True: btnActualizaVenta.Visible = False
    
No_Err_ActualizaDev:
    MousePointer = 0
    Exit Sub
    
Err_ActualizaDev:
    MousePointer = 0
    
    CancelaVenta
    Cancela = False
    btnEliminarVenta.Picture = LoadPicture(App.Path & "\Imagenes\Botones\btnEliminar.jpg")
    btnNuevaVenta.Visible = True: btnActualizaVenta.Visible = False
    
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_ActualizaDev:
End Sub

Private Sub btnAplica_Click()
On Error Resume Next

    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    If Not ValidaModulo("DEVOL", True) Then Exit Sub
    
    If Not IsEmpty(LstDDevolucion) Then
        
        If Mid(LstDDevolucion(3, LstDevolucion.SelectedItem.Index - 1), 1, 1) = "A" Then Exit Sub
        
        If MsgBox("¿ Está seguro que desea Aplicar la Devolución " & Format(LstDDevolucion(2, LstDevolucion.SelectedItem.Index - 1), "0000000") & " del Cliente " & _
        Chr(13) & Chr(10) & LstDDevolucion(8, LstDevolucion.SelectedItem.Index - 1) & " ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
            MousePointer = 11
            StrCmd = "execute up_Devolucion " & IdCedis & ", " & IdSurtido & ", " & IdDevolucion & ", 0, '', 'A', 2"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn

            MousePointer = 0
            MuestraDevolucion
        End If
    End If

End Sub

Private Sub btnEliminarVenta_Click()
On Error GoTo Err_DelDev:

    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    If Not ValidaModulo("DEVOL", True) Then Exit Sub
    
    If Mid(LstDDevolucion(3, LstDevolucion.SelectedItem.Index - 1), 1, 1) = "A" Then
        MsgBox "¡ No puedes Eliminar una Devolución que está Aplicada !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Cancela Then
        CancelaVenta
        btnEliminarVenta.Picture = LoadPicture(App.Path & "\Imagenes\Botones\btnEliminar.jpg")
        Cancela = False
        btnNuevaVenta.Visible = True: btnActualizaVenta.Visible = False
    Else
        If Not IsEmpty(LstDDevolucion) Then
            If MsgBox("¿ Está seguro que desea Eliminar la Devolución " & Format(LstDDevolucion(2, LstDevolucion.SelectedItem.Index - 1), "0000000") & " del Cliente " & _
            Chr(13) & Chr(10) & LstDDevolucion(8, LstDevolucion.SelectedItem.Index - 1) & " ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
'                If MsgBox("La información se perderá. ¿ Desea continuar ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
                MousePointer = 11
                StrCmd = "execute up_Devolucion " & IdCedis & ", " & IdSurtido & ", " & IdDevolucion & ", 0, '', 'B', 3"
                If Rs.State Then Rs.Close
                Rs.Open StrCmd, Cnn
    
                MousePointer = 0
                MuestraDevolucion
            End If
        End If
        btnEliminarVenta.Picture = LoadPicture(App.Path & "\Imagenes\Botones\btnEliminar.jpg")
        Cancela = False
    End If

No_Err_DelDev:
    MousePointer = 0
    Exit Sub

Err_DelDev:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_DelDev:

End Sub

Private Sub btnImprimeC_Click()
On Error GoTo ImpDevolucion:
    
    btnImprimirVenta_Click
    
No_ImpDevolucion:
    MousePointer = 0
    Exit Sub
    
ImpDevolucion:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_ImpDevolucion:

End Sub

Private Sub btnImprimirVenta_Click()
On Error GoTo ImpDevolucion:
        
    If IsEmpty(LstDDevolucion) Then Exit Sub
    
    With AL_RptDevolucion
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
        .LblTitulo.Caption = "Devolución de Producto"
        .LblCedis.Caption = IdCedis & " - " & NomCedis
        
        .LblFecha.Caption = Format(CDate(LstDDevolucion(11, LstDevolucion.SelectedItem.Index - 1)), "DD-MMM-YYYY")
        .LblRFC = LstDDevolucion(10, LstDevolucion.SelectedItem.Index - 1)
        .LblNombre = LstDDevolucion(7, LstDevolucion.SelectedItem.Index - 1)
        .LblDireccion = LstDDevolucion(9, LstDevolucion.SelectedItem.Index - 1)
        .LblFolio = Format(IdDevolucion, "000000")
        
        StrCmd = "execute sel_DevolucionDetalle " & IdCedis & ", " & IdSurtido & ", " & IdDevolucion & ", 0, 1"
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
    
No_ImpDevolucion:
    MousePointer = 0
    Exit Sub
    
ImpDevolucion:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_ImpDevolucion:
End Sub

Private Sub btnNuevaVenta_Click()
On Error GoTo Err_NuevaDev:
    
    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    If Not ValidaModulo("DEVOL", True) Then Exit Sub
    
    IdSucursal = 0: IdCliente = 0

    StrCmd = "execute sel_Devolucion " & IdCedis & ", " & IdSurtido & ", 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        TxtFolio.Text = Format(Rs.Fields(0), "000000")
    Else
        TxtFolio.Text = Format(1, "000000")
    End If

    CancelaVenta
    Cancela = True
    btnEliminarVenta.Picture = LoadPicture(App.Path & "\Imagenes\Botones\btnCancelar.jpg")
    btnNuevaVenta.Visible = False: btnActualizaVenta.Visible = True
    
No_Err_NuevaDev:
    MousePointer = 0
    Exit Sub
    
Err_NuevaDev:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_NuevaDev:
    
End Sub

Private Sub Form_Activate()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    MuestraDevolucion
End Sub

Private Sub Form_Load()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB

    SSTab.Tab = 0
    SSTab_Click 0
    IdDevolucion = 0
End Sub

Private Sub LstClientes_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    If Not IsEmpty(LstDClientes) And LstClientes.ListItems.Count > 0 Then
        IdCliente = Trim(LstClientes.SelectedItem)
        IdSucursal = LstDClientes(10, LstClientes.SelectedItem.Index - 1)
        LblCliente(0).Caption = Trim(LstClientes.SelectedItem) & " , " & Trim(LstClientes.SelectedItem.ListSubItems(1).Text)
        LblCliente(1).Caption = Trim(LstDClientes(10, LstClientes.SelectedItem.Index - 1)) & " - " & Trim(LstClientes.SelectedItem.ListSubItems(2).Text) & ", " & Trim(LstClientes.SelectedItem.ListSubItems(3).Text)
    End If
End Sub

Private Sub LstDevolucion_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    If Not IsEmpty(LstDDevolucion) Or LstDevolucion.ListItems.Count > 0 Then
        
        If btnActualizaVenta.Visible Then
            Cancela = True
            'btnEliminarVenta_Click
        End If
        
        IdDevolucion = LstDDevolucion(2, LstDevolucion.SelectedItem.Index - 1)
        IdCliente = LstDDevolucion(4, LstDevolucion.SelectedItem.Index - 1)
        IdSucursal = LstDDevolucion(8, LstDevolucion.SelectedItem.Index - 1)
        
        LblPedido(0).Caption = "Devolución " & Format(IdDevolucion, "000000")
    
        TxtFolio.Text = LstDDevolucion(2, LstDevolucion.SelectedItem.Index - 1)
        TxtCliente.Text = LstDDevolucion(4, LstDevolucion.SelectedItem.Index - 1) & " - " & LstDDevolucion(5, LstDevolucion.SelectedItem.Index - 1)
        TxtRFC2.Text = LstDDevolucion(8, LstDevolucion.SelectedItem.Index - 1)
        TxtSucursal.Text = LstDDevolucion(6, LstDevolucion.SelectedItem.Index - 1) & " (CB: " & LstDDevolucion(7, LstDevolucion.SelectedItem.Index - 1) & ") " & LstDDevolucion(8, LstDevolucion.SelectedItem.Index - 1)
        
        TxtRFC.Text = LstDDevolucion(8, LstDevolucion.SelectedItem.Index - 1)
        LstClientes_ItemClick LstClientes.SelectedItem
    End If

End Sub

Private Sub SSTab_Click(PreviousTab As Integer)
On Error Resume Next
    If IsEmpty(IdDevolucion) Then IdDevolucion = 0
    If SSTab.Tab >= 1 And (IsEmpty(LstDDevolucion) Or IdDevolucion = 0) Then
        MsgBox "¡ Selecciona una Devolución !", vbInformation + vbOKOnly, App.Title
        SSTab.Tab = 0
        Exit Sub
    End If
    
    Select Case SSTab.Tab
        Case 0:
            MuestraDevolucion
        Case 1:
            MuestraDetalleDev False
            TxtIdProd.SetFocus
    End Select
End Sub

Private Sub TxtIdCliente_Change()
On Error Resume Next
    FiltraClientes 1
End Sub

Private Sub TxtIdCliente_GotFocus()
On Error Resume Next
    SelText TxtIdCliente
End Sub

Private Sub TxtIdCliente_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtRazonSocial_Change()
On Error Resume Next
    TxtIdCliente.Text = ""
    FiltraClientes 1
End Sub

Private Sub TxtRazonSocial_GotFocus()
On Error Resume Next
    SelText TxtRazonSocial
End Sub

Private Sub TxtRazonSocial_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtRFC_Change()
On Error Resume Next
    TxtIdCliente.Text = ""
    FiltraClientes 1
End Sub

Private Sub TxtRFC_GotFocus()
On Error Resume Next
    SelText TxtRFC
End Sub

Private Sub TxtRFC_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Sub MuestraDevolucion()
On Error Resume Next
    StrCmd = "execute sel_Devolucion " & IdCedis & ", " & IdSurtido & ", 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDDevolucion = GetDataLVL(RsC, LstDevolucion, 2, 8, "6|0|0|0|0|0|0")
    LstDevolucion_ItemClick LstDevolucion.SelectedItem
End Sub

Sub FiltraClientes(Opc As Integer)
On Error Resume Next
    LblCliente(0).Caption = "": LblCliente(1).Caption = ""
    If Opc = 1 Then
        StrCmd = "execute sel_ClientesFacturas " & IdCedis & ",'" & IIf(Trim(TxtIdCliente.Text) = "", 0, Trim(TxtIdCliente.Text)) & "','" & Trim(TxtRFC.Text) & "','" & Trim(TxtRazonSocial.Text) & "', " & Opc
    Else
        StrCmd = "execute sel_ClientesFacturas " & IdCedis & ",'" & LstDDevolucion(9, LstDevolucion.SelectedItem.Index - 1) & "','','" & LstDDevolucion(17, LstDevolucion.SelectedItem.Index - 1) & "', " & Opc
    End If
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
'Debug.Print StrCmd
    LstDClientes = GetDataLVL(RsC, LstClientes, 1, 4, "0|0|0|0")
End Sub

Sub CancelaVenta()
On Error Resume Next
    TxtIdCliente.Text = "": TxtRFC.Text = "": TxtRazonSocial.Text = "": LstClientes.ListItems.Clear
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
        If Not ValidaModulo("DEVOL", True) Then Exit Sub
        
        If Mid(LstDDevolucion(3, LstDevolucion.SelectedItem.Index - 1), 1, 1) = "A" Then
            MsgBox "¡ No puedes Modificar una Devolución que está Aplicada !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        SplitTxt TxtCantidad
        
        If TxtIdProd.Text = "" Or TxtIdProd.Text = "0" Then
            MsgBox "¡ Seleccione un Producto Válido !", vbInformation + vbOKOnly, App.Title
            TxtIdProd.SetFocus
            Exit Sub
        End If
        
        If Dec Then
            TxtCantidad.Text = itFlotante(TxtCantidad.Text)
        End If
        
        If Trim(TxtCantidad.Text) = "" Then
            MsgBox "¡ Teclee la Cantidad de producto para la Devolución !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If Trim(TxtCantidad.Text) = "0" Then
            If MsgBox("¿ Está seguro que desea Eliminar la partida seleccionada ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        End If
        
        
        StrCmd = "execute up_DevolucionDetalle " & IdCedis & ", " & IdSurtido & ", " & IdDevolucion & ", " & TxtIdProd.Text & ", " & TxtCantidad.Text & ", 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        MuestraDetalleDev False
        
        TxtCantidad.Text = 0
        TxtIdProd.Text = "": TxtIdProd.SetFocus: TxtDesc.Text = ""
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

Private Sub TxtIdProd_Change()
On Error Resume Next
    TxtDesc.Text = "¡ Producto no econtrado !": TxtCantidad.Text = 0
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
            .Opc = 8
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
        
        ' valido si el producto ya está registrado en la Venta y obtiene nuevos datos
        StrCmd = "execute sel_DevolucionDetalle " & IdCedis & ", " & IdSurtido & ", " & IdDevolucion & ", " & TxtIdProd.Text & ", 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            If Rs.Fields(4) Then
                TxtDesc.Text = Rs.Fields(1)
                TxtCantidad.Text = FormatNumber(Rs.Fields(2), 3)
                Dec = IIf(Rs.Fields(3) = 1, True, False)
            Else
                MsgBox "¡ Sólo puede registrar una Devolución de Producto Contenido (Envase) !", vbInformation + vbOKOnly, App.Title
                TxtDesc.Text = "¡ Sólo puede registrar una Devolución de Producto Contenido (Envase) !"
                TxtCantidad.Text = 0: TxtIdProd.Text = "": TxtIdProd.SetFocus
                Dec = False
                Exit Sub
            End If
        Else
            TxtDesc.Text = "¡ Producto no Encontado !"
            TxtCantidad.Text = 0: TxtIdProd.Text = "": TxtIdProd.SetFocus
            Dec = False
            Exit Sub
        End If
    Else
        TxtDesc.Text = "": TxtCantidad.Text = 0
    End If
    TxtCantidad.SetFocus
End Sub

Sub MuestraDetalleDev(Rep As Boolean)
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    StrCmd = "execute sel_DevolucionDetalle " & IdCedis & ", " & IdSurtido & ", " & IdDevolucion & ", 0, 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    If Not Rep Then LstDPartidas = GetDataLVL(RsC, LstPartidas, 3, 5, "0|0|9")
End Sub

