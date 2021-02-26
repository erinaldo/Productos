VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "Mscomctl.ocx"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form AL_Pedidos 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Captura de Pedidos"
   ClientHeight    =   8400
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
   ScaleHeight     =   8400
   ScaleWidth      =   12660
   ShowInTaskbar   =   0   'False
   Begin TabDlg.SSTab SSTab 
      Height          =   8175
      Left            =   120
      TabIndex        =   23
      Top             =   120
      Width           =   12375
      _ExtentX        =   21828
      _ExtentY        =   14420
      _Version        =   393216
      Tabs            =   2
      TabsPerRow      =   2
      TabHeight       =   520
      BackColor       =   16777215
      TabCaption(0)   =   "&Captura de Pedidos"
      TabPicture(0)   =   "AL_Pedidos.frx":0000
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "LblOpt(6)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "FrmOpt(2)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "&Detalle del Pedido"
      TabPicture(1)   =   "AL_Pedidos.frx":001C
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
         Height          =   7830
         Index           =   3
         Left            =   -75000
         TabIndex        =   41
         Top             =   345
         Width           =   12375
         Begin VB.TextBox Text14 
            Appearance      =   0  'Flat
            BorderStyle     =   0  'None
            ForeColor       =   &H00000000&
            Height          =   240
            Left            =   8040
            Locked          =   -1  'True
            TabIndex        =   63
            Text            =   "Lista de Precios"
            Top             =   720
            Width           =   1455
         End
         Begin VB.TextBox Txt12 
            Appearance      =   0  'Flat
            BorderStyle     =   0  'None
            ForeColor       =   &H00000000&
            Height          =   255
            Left            =   2280
            TabIndex        =   62
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
            TabIndex        =   61
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
            TabIndex        =   60
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
            TabIndex        =   59
            Top             =   720
            Width           =   4575
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
            Height          =   210
            Left            =   8160
            Locked          =   -1  'True
            TabIndex        =   58
            Top             =   1080
            Width           =   3975
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
            TabIndex        =   57
            Top             =   1005
            Width           =   6495
         End
         Begin VB.TextBox Text6 
            Appearance      =   0  'Flat
            BorderStyle     =   0  'None
            ForeColor       =   &H00000000&
            Height          =   255
            Left            =   240
            TabIndex        =   56
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
            Picture         =   "AL_Pedidos.frx":0038
            Style           =   1  'Graphical
            TabIndex        =   46
            Top             =   6720
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
            Height          =   4815
            Index           =   0
            Left            =   120
            TabIndex        =   45
            Top             =   1320
            Width           =   12135
            Begin VB.TextBox TxtDesc 
               Height          =   375
               Left            =   1200
               TabIndex        =   12
               Top             =   480
               Width           =   6135
            End
            Begin VB.TextBox TxtEntregado 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   7440
               Locked          =   -1  'True
               MaxLength       =   8
               TabIndex        =   15
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
               TabIndex        =   18
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
               TabIndex        =   17
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
               TabIndex        =   13
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
               TabIndex        =   11
               Top             =   480
               Width           =   975
            End
            Begin VB.TextBox TxtCantidad 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   7440
               MaxLength       =   8
               TabIndex        =   14
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
               TabIndex        =   16
               Text            =   "0"
               Top             =   480
               Width           =   975
            End
            Begin MSComctlLib.ListView LstPartidas 
               Height          =   3750
               Left            =   120
               TabIndex        =   64
               Top             =   960
               Width           =   11895
               _ExtentX        =   20981
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
            Begin VB.Label Label10 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Entregado"
               Height          =   255
               Left            =   7440
               TabIndex        =   72
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
               TabIndex        =   71
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
               TabIndex        =   70
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
               TabIndex        =   69
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
               TabIndex        =   68
               Top             =   240
               Width           =   975
            End
            Begin VB.Label Label13 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Cve. P"
               Height          =   255
               Left            =   240
               TabIndex        =   67
               Top             =   240
               Width           =   495
            End
            Begin VB.Label Label12 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Descripción del Producto"
               Height          =   255
               Left            =   1320
               TabIndex        =   66
               Top             =   240
               Width           =   3735
            End
            Begin VB.Label Label11 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Precio"
               Height          =   255
               Left            =   8520
               TabIndex        =   65
               Top             =   240
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
            Picture         =   "AL_Pedidos.frx":0753
            Style           =   1  'Graphical
            TabIndex        =   44
            Top             =   6720
            Visible         =   0   'False
            Width           =   1695
         End
         Begin VB.Frame Frame5 
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
            Height          =   1470
            Left            =   9120
            TabIndex        =   47
            Top             =   6000
            Width           =   3135
            Begin VB.Label Label28 
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
               TabIndex        =   55
               Top             =   240
               Width           =   720
            End
            Begin VB.Label Label27 
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
               Left            =   795
               TabIndex        =   54
               Top             =   600
               Width           =   270
            End
            Begin VB.Label Label19 
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
               TabIndex        =   53
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
               Left            =   1335
               TabIndex        =   52
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
               Left            =   1335
               TabIndex        =   51
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
               Left            =   1335
               TabIndex        =   50
               Top             =   960
               Width           =   1635
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
               TabIndex        =   49
               Top             =   240
               Visible         =   0   'False
               Width           =   1635
            End
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
               TabIndex        =   48
               Top             =   240
               Visible         =   0   'False
               Width           =   945
            End
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
            TabIndex        =   42
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
         Height          =   7830
         Index           =   2
         Left            =   0
         TabIndex        =   25
         Top             =   345
         Width           =   12375
         Begin VB.OptionButton OptCons 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Pedidos Pendientes"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   0
            Left            =   1800
            TabIndex        =   76
            Top             =   4800
            Value           =   -1  'True
            Width           =   2055
         End
         Begin VB.OptionButton OptCons 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Pedidos con Venta"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   1
            Left            =   3960
            TabIndex        =   75
            Top             =   4800
            Width           =   2055
         End
         Begin VB.OptionButton OptCons 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Todos los Pedidos"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   2
            Left            =   6120
            TabIndex        =   74
            Top             =   4800
            Width           =   2055
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
            Picture         =   "AL_Pedidos.frx":0E63
            Style           =   1  'Graphical
            TabIndex        =   73
            Top             =   2520
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
            Picture         =   "AL_Pedidos.frx":15B5
            Style           =   1  'Graphical
            TabIndex        =   0
            Top             =   720
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
            Picture         =   "AL_Pedidos.frx":1C43
            Style           =   1  'Graphical
            TabIndex        =   21
            Top             =   1320
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
            Picture         =   "AL_Pedidos.frx":2353
            Style           =   1  'Graphical
            TabIndex        =   22
            Top             =   1920
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
            Picture         =   "AL_Pedidos.frx":2A6E
            Style           =   1  'Graphical
            TabIndex        =   7
            Top             =   720
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
            Height          =   3015
            Left            =   1920
            TabIndex        =   30
            Top             =   1680
            Width           =   10215
            Begin VB.TextBox TxtIdCliente 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   120
               TabIndex        =   8
               Top             =   480
               Width           =   975
            End
            Begin VB.TextBox TxtRFC 
               Height          =   375
               Left            =   3600
               TabIndex        =   10
               Top             =   480
               Width           =   1815
            End
            Begin VB.TextBox TxtRazonSocial 
               Height          =   375
               Left            =   1200
               TabIndex        =   9
               Top             =   480
               Width           =   2295
            End
            Begin MSComctlLib.ListView LstClientes 
               Height          =   1935
               Left            =   120
               TabIndex        =   19
               Top             =   960
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
               TabIndex        =   36
               Top             =   720
               Width           =   4485
            End
            Begin VB.Label Label26 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Cliente Seleccionado"
               Height          =   200
               Left            =   5520
               TabIndex        =   35
               Top             =   180
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
               TabIndex        =   34
               Top             =   420
               Width           =   4485
            End
            Begin VB.Label Label20 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "No. Cliente"
               Height          =   240
               Left            =   120
               TabIndex        =   33
               Top             =   240
               Width           =   960
            End
            Begin VB.Label Label21 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Razón Social ( Cliente )"
               Height          =   255
               Left            =   1200
               TabIndex        =   32
               Top             =   240
               Width           =   2295
            End
            Begin VB.Label Label22 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Sucursal"
               Height          =   240
               Left            =   3600
               TabIndex        =   31
               Top             =   240
               Width           =   765
            End
         End
         Begin VB.Frame Frame2 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Datos del Pedido"
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
            Left            =   1920
            TabIndex        =   27
            Top             =   240
            Width           =   10215
            Begin VB.TextBox TxtRutaE 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   9000
               MaxLength       =   5
               TabIndex        =   6
               Top             =   840
               Width           =   975
            End
            Begin VB.TextBox TxtRutaP 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   3840
               MaxLength       =   5
               TabIndex        =   4
               Top             =   840
               Width           =   975
            End
            Begin VB.TextBox TxtFolio 
               Alignment       =   1  'Right Justify
               Height          =   360
               Left            =   720
               Locked          =   -1  'True
               TabIndex        =   1
               Text            =   "0"
               Top             =   360
               Width           =   1335
            End
            Begin VB.ComboBox cmbTipoVenta 
               Height          =   360
               Left            =   3600
               Style           =   2  'Dropdown List
               TabIndex        =   2
               Top             =   360
               Width           =   2655
            End
            Begin MSComCtl2.DTPicker DTPFechaP 
               Height          =   375
               Left            =   1080
               TabIndex        =   3
               Top             =   840
               Width           =   1455
               _ExtentX        =   2566
               _ExtentY        =   661
               _Version        =   393216
               BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                  Name            =   "Arial"
                  Size            =   9.75
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Format          =   74973185
               CurrentDate     =   39376
            End
            Begin MSComCtl2.DTPicker DTPFechaE 
               Height          =   375
               Left            =   6120
               TabIndex        =   5
               Top             =   840
               Width           =   1455
               _ExtentX        =   2566
               _ExtentY        =   661
               _Version        =   393216
               BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
                  Name            =   "Arial"
                  Size            =   9.75
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Format          =   74973185
               CurrentDate     =   39376
            End
            Begin VB.Label LblFactura 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Factura"
               BeginProperty Font 
                  Name            =   "Arial"
                  Size            =   9
                  Charset         =   0
                  Weight          =   700
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               ForeColor       =   &H00000080&
               Height          =   225
               Left            =   6600
               TabIndex        =   78
               Top             =   360
               Width           =   645
            End
            Begin VB.Label Label4 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Ruta Entrega"
               Height          =   255
               Left            =   7680
               TabIndex        =   40
               Top             =   960
               Width           =   1215
            End
            Begin VB.Label Label3 
               BackColor       =   &H00FFFFFF&
               Caption         =   "F. Entrega"
               Height          =   255
               Left            =   5040
               TabIndex        =   39
               Top             =   960
               Width           =   975
            End
            Begin VB.Label Label2 
               BackColor       =   &H00FFFFFF&
               Caption         =   "F. Pedido"
               Height          =   255
               Left            =   120
               TabIndex        =   38
               Top             =   960
               Width           =   855
            End
            Begin VB.Label Label1 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Ruta Pedido"
               Height          =   255
               Left            =   2640
               TabIndex        =   37
               Top             =   960
               Width           =   1095
            End
            Begin VB.Label Label18 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Folio"
               Height          =   255
               Left            =   120
               TabIndex        =   29
               Top             =   360
               Width           =   495
            End
            Begin VB.Label Label17 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Tipo de Venta"
               Height          =   240
               Left            =   2280
               TabIndex        =   28
               Top             =   360
               Width           =   1200
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
            Height          =   2895
            Left            =   120
            TabIndex        =   26
            Top             =   4800
            Width           =   12015
            Begin VB.CheckBox ChkRuta 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Por Ruta"
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
               Left            =   360
               TabIndex        =   77
               Top             =   0
               Value           =   1  'Checked
               Width           =   1095
            End
            Begin MSComctlLib.ListView LstPedidos 
               Height          =   2415
               Left            =   120
               TabIndex        =   20
               Top             =   360
               Width           =   11775
               _ExtentX        =   20770
               _ExtentY        =   4260
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
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FFFFFF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Detalle del Pedido"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   0
         Left            =   -68835
         TabIndex        =   43
         Top             =   0
         Width           =   6210
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FFFFFF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Captura de Pedidos"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   6
         Left            =   0
         TabIndex        =   24
         Top             =   0
         Width           =   6200
      End
   End
End
Attribute VB_Name = "AL_Pedidos"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDPedidos, LstDTipoVenta, LstDPartidas, LstDClientes, Cancela As Boolean, IdPedido, IdCliente, IdSucursal
Dim IdTipoVenta, Precio As Double, IdLista As Long, Iva As Double, Dec As Boolean, IdRutaPedido As Long
Public Seleccionar As Boolean

Private Sub btnActualizaVenta_Click()
On Error GoTo Err_ActualizaPed

    'adelante con la factura
    If Not ValidaRutaPedido(TxtRutaP) Then Exit Sub
    If Not ValidaRutaPedido(TxtRutaE) Then Exit Sub
        
    If Trim(TxtRutaP.Text) = "" Or Trim(TxtRutaE.Text) = "" Or TxtRutaP.Text = "0" Or TxtRutaE.Text = "0" Then
        MsgBox "¡ Teclea las Rutas de Pedido y Entrega !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If IdCliente = 0 Or IdSucursal = 0 Then
        MsgBox "¡ Seleccione un Cliente y una Sucursal a quien se le va a asignar el Pedido !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If cmbTipoVenta.ListIndex = 0 Then
        MsgBox "¡ Selecciona un Tipo de Venta !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    StrCmd = "execute up_Pedidos " & IdCedis & ", " & IdPedido & ", " & LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) & ", '" & _
            FormatDate(DTPFechaP.Value) & "', '" & TxtRutaP.Text & "', '" & _
            FormatDate(DTPFechaE.Value) & "', '" & TxtRutaE.Text & "', " & IdCliente & ", '" & IdSucursal & "', 0, '', 0, '" & Usuario & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    MuestraPedidos
    
'    StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", 0, 0, 0, " & LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) & ", '', " & LstDPedidos(1, UBound(LstDPedidos, 2)) & ", '" & _
'    FormatDate(DTPFechaP.Value) & "', " & TxtRutaP.Text & ", " & IdCliente & ", '" & IdSucursal & "', 0, 'Insertar', 'Pedido " & IdPedido & ", Fecha Pedido " & DTPFechaP.Value & _
'    " Ruta Pedido " & TxtRutaP.Text & ", Fecha Entrega " & DTPFechaE.Value & " Ruta Entrega " & TxtRutaE.Text & "', 8"
'    If Rs.State Then Rs.Close
'    Rs.Open StrCmd, Cnn
    
    IdSucursal = 0: IdCliente = 0
        
    CancelaVenta
    Cancela = False
    btnEliminarVenta.Picture = LoadPicture(App.Path & "\Imagenes\Botones\btnEliminar.jpg")
    btnNuevaVenta.Visible = True: btnActualizaVenta.Visible = False
    
No_Err_ActualizaPed:
    MousePointer = 0
    Exit Sub
    
Err_ActualizaPed:
    MousePointer = 0
    
    CancelaVenta
    Cancela = False
    btnEliminarVenta.Picture = LoadPicture(App.Path & "\Imagenes\Botones\btnEliminar.jpg")
    btnNuevaVenta.Visible = True: btnActualizaVenta.Visible = False
    
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_ActualizaPed:
End Sub

Private Sub btnEliminarVenta_Click()
On Error GoTo Err_DelPed:

    If Not ValidaModulo("PEDID", True) Then Exit Sub

    If Cancela Then
        CancelaVenta
        btnEliminarVenta.Picture = LoadPicture(App.Path & "\Imagenes\Botones\btnEliminar.jpg")
        Cancela = False
        'btnEliminarVenta.Caption = "&Eliminar"
        btnNuevaVenta.Visible = True: btnActualizaVenta.Visible = False
    Else
        If Not IsEmpty(LstPedidos) Then
            If LstDPedidos(23, LstPedidos.SelectedItem.Index - 1) <> 0 Then
                MsgBox "¡ No puedes Eliminar un Pedido que ya está asignado a una Venta !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            If MsgBox("¿ Está seguro que desea Eliminar el Pedido " & LstDPedidos(3, LstPedidos.SelectedItem.Index - 1) & " - " & LstDPedidos(4, LstPedidos.SelectedItem.Index - 1) & " del Cliente " & _
            Chr(13) & Chr(10) & LstDPedidos(10, LstPedidos.SelectedItem.Index - 1) & " por " & _
            FormatCurrency(LstDPedidos(14, LstPedidos.SelectedItem.Index - 1), 2, vbTrue) & " ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
'                If MsgBox("La información se perderá. ¿ Desea continuar ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
                MousePointer = 11
                StrCmd = "execute up_Pedidos " & IdCedis & ", " & IdPedido & ", 0, '19000101', 0, '19000101', 0, 0, '', 0, '', 0, '" & Usuario & "', 2"
                If Rs.State Then Rs.Close
                Rs.Open StrCmd, Cnn
    
'                StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", 0, 0, 0, " & IdTipoVenta & ", '', " & IdPedido & ", '" & _
'                FormatDate(DTPFechaP.Value) & "', " & TxtRutaP.Text & ", " & IdCliente & ", '" & IdSucursal & "', 0, 'Eliminar', 'Pedido " & IdPedido & ", Fecha Pedido " & DTPFechaP.Value & _
'                " Ruta Pedido " & TxtRutaP.Text & ", Fecha Entrega " & DTPFechaE.Value & " Ruta Entrega " & TxtRutaE.Text & "', 8"
'                If Rs.State Then Rs.Close
'                Rs.Open StrCmd, Cnn
                
                MousePointer = 0
                MuestraPedidos
            End If
        End If
        btnEliminarVenta.Picture = LoadPicture(App.Path & "\Imagenes\Botones\btnEliminar.jpg")
        Cancela = False
    End If

No_Err_DelPed:
    MousePointer = 0
    Exit Sub

Err_DelPed:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_DelPed:

End Sub

Private Sub btnImprimeC_Click()
On Error GoTo ImpPedido:
    
    btnImprimirVenta_Click
    
No_ImpPedido:
    MousePointer = 0
    Exit Sub
    
ImpPedido:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_ImpPedido:

End Sub

Private Sub btnImprimirVenta_Click()
On Error GoTo ImpPedido:
        
    If IsEmpty(LstDPedidos) Then Exit Sub
        
    With CC_OpcImpFactura
        .ChkImpresion(3).Enabled = IIf(LstDPedidos(23, LstPedidos.SelectedItem.Index - 1) <> 0, False, True)
        .ChkImpresion(3).Value = IIf(LstDPedidos(23, LstPedidos.SelectedItem.Index - 1) <> 0, 0, 1)
        .TxtFolio.Locked = IIf(LstDPedidos(23, LstPedidos.SelectedItem.Index - 1) <> 0, True, False)
        .IdPedido = IdPedido
        .OptCons = 5
        .strIds = " ( Pedidos.IdCedis = " & IdCedis & " and Pedidos.IdPedido = " & IdPedido & " ) "
        .strFolios = "Ced" & IdCedis & "IdPed" & Format(IdPedido, "0000") & " "
        .OptPiezas(0).Caption = Etiqueta01
        .OptPiezas(1).Caption = Etiqueta02
        .Left = Me.Left + (Me.Width - .Width) / 2
        .Top = Me.Top + (Me.Height - .Height) / 2
        .Show
    End With
    
'    With AL_RptPedido
'
'        If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
'        StrCmd = "execute sel_PedidosDetalle " & IdCedis & ", " & LstDPedidos(4, LstPedidos.SelectedItem.Index - 1) & ", 0, 4"
'        If RsC.State Then RsC.Close
'        RsC.Open StrCmd, Cnn
'
'        If Not RsC.EOF Then
'            .LblControl.Caption = "Ced" & IdCedis & "IdPed" & LstDPedidos(4, LstPedidos.SelectedItem.Index - 1) & "FPed" & Format(CDate(LstDPedidos(6, LstPedidos.SelectedItem.Index - 1)), "ddMMMyy") & "Dist" & IdRuta
'            .object.DataSrc.DataSourceName = Cnn
'            .object.DataSrc.Recordset = RsC
'            .Printer.Orientation = ddOPortrait
'            .Printer.PaperSize = 1
'            .Show
'        End If
'    End With
    
No_ImpPedido:
    MousePointer = 0
    Exit Sub
    
ImpPedido:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_ImpPedido:
End Sub

Private Sub btnNuevaVenta_Click()
On Error GoTo Err_NuevaPed:
    
    If Not ValidaModulo("PEDID", True) Then Exit Sub
    
    IdSucursal = 0: IdCliente = 0

    StrCmd = "execute sel_Pedidos " & IdCedis & ", '19000101', '', '', 2"
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
    cmbTipoVenta.SetFocus
    
No_Err_NuevaPed:
    MousePointer = 0
    Exit Sub
    
Err_NuevaPed:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_NuevaPed:
    
End Sub

Private Sub btnSeleccionar_Click()
On Error GoTo Err_ImportaPedido:

    If LstDPedidos(23, LstPedidos.SelectedItem.Index - 1) <> 0 Then
        MsgBox "¡ El pedido ya ha sido Facturado !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    If MsgBox("Una vez que el Pedido se haya convertido en Venta ya no podrá modificarse" & Chr(13) & Chr(10) & "¿ Estás seguro que deseas continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        
    StrCmd = "execute up_Pedidos " & IdCedis & ", " & IdPedido & ", " & LstDPedidos(2, LstPedidos.SelectedItem.Index - 1) & ", '" & _
            FormatDate(CDate(LstDPedidos(6, LstPedidos.SelectedItem.Index - 1))) & "', '" & LstDPedidos(5, LstPedidos.SelectedItem.Index - 1) & "', '" & _
            FormatDate(CDate(LstDPedidos(8, LstPedidos.SelectedItem.Index - 1))) & "', '" & LstDPedidos(7, LstPedidos.SelectedItem.Index - 1) & "', " & IdCliente & ", '" & IdSucursal & "', " & IdSurtido & ", '', 0, '" & Usuario & "', 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
'    StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", 0, 0, 0, " & LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) & ", '', " & IdPedido & ", '" & _
'    FormatDate(Fecha) & "', " & TxtRutaP.Text & ", " & IdCliente & ", '" & IdSucursal & "', 0, 'Seleccionar', 'Pedido " & IdPedido & ", Fecha Pedido " & DTPFechaP.Value & _
'    " Ruta Pedido " & TxtRutaP.Text & ", Fecha Entrega " & DTPFechaE.Value & " Ruta Entrega " & TxtRutaE.Text & "', 8"
'    If Rs.State Then Rs.Close
'    Rs.Open StrCmd, Cnn
    
    MuestraPedidos
    AL_Liquidacion.MuestraFacturas
    AL_Pedidos.Hide
        
No_Err_ImportaPedido:
    MousePointer = 0
    Exit Sub
    
Err_ImportaPedido:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_ImportaPedido:
End Sub

Private Sub ChkRuta_Click()
On Error Resume Next
    MuestraPedidos
End Sub

Private Sub cmbTipoVenta_Click()
On Error Resume Next
    If Not IsEmpty(LstDTipoVenta) And btnActualizaVenta.Visible And cmbTipoVenta.ListIndex > 0 Then
        DTPFechaP.SetFocus
    End If
End Sub

Private Sub DTPFechaE_Change()
On Error Resume Next
'    TxtRutaE.SetFocus
End Sub

Private Sub DTPFechaP_Change()
On Error Resume Next
    DTPFechaE.MinDate = DTPFechaP.Value
    MuestraPedidos
'    TxtRutaP.SetFocus
End Sub

Private Sub DTPFechaP_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then TxtRutaP.SetFocus
End Sub

Private Sub Form_Activate()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    MuestraPedidos
End Sub

Private Sub Form_Load()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB

    DTPFechaP.Value = Date
    DTPFechaE.MinDate = DTPFechaP.Value
    DTPFechaE.Value = Date + 1
    SSTab.Tab = 0
    SSTab_Click 0
    IdPedido = 0

    If Seleccionar Then DTPFechaP.Value = FechaSel
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

Private Sub LstPedidos_DblClick()
    
'    If Not IsEmpty(LstDPedidos) Or LstPedidos.ListItems.Count > 0 Then
'        TxtFolio.Text = LstDPedidos(1, LstPedidos.SelectedItem.Index - 1)
'        cmbTipoVenta.ListIndex = SearchInList(LstDTipoVenta, LstDPedidos(2, LstPedidos.SelectedItem.Index - 1), 0)
'        TxtRutaP.Text = LstDPedidos(5, LstPedidos.SelectedItem.Index - 1)
'        TxtRutaE.Text = LstDPedidos(7, LstPedidos.SelectedItem.Index - 1)
'        DTPFechaP.Value = LstDPedidos(6, LstPedidos.SelectedItem.Index - 1)
'        DTPFechaE.Value = LstDPedidos(8, LstPedidos.SelectedItem.Index - 1)
'
'        TxtCliente.Text = LstDPedidos(9, LstPedidos.SelectedItem.Index - 1) & " - " & LstDPedidos(10, LstPedidos.SelectedItem.Index - 1)
'        TxtRFC2.Text = LstDPedidos(18, LstPedidos.SelectedItem.Index - 1)
'        TxtSucursal.Text = LstDPedidos(16, LstPedidos.SelectedItem.Index - 1) & " (CB: " & LstDPedidos(14, LstPedidos.SelectedItem.Index - 1) & ") " & LstDPedidos(15, LstPedidos.SelectedItem.Index - 1)
'        TxtListaPrecios.Text = LstDPedidos(21, LstPedidos.SelectedItem.Index - 1) & " - " & LstDPedidos(22, LstPedidos.SelectedItem.Index - 1)
'
'        TxtRFC.Text = LstDPedidos(16, LstPedidos.SelectedItem.Index - 1)
'        LstClientes_ItemClick LstClientes.SelectedItem
'
'    End If
End Sub

Private Sub LstPedidos_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    If Not IsEmpty(LstDPedidos) Or LstPedidos.ListItems.Count > 0 Then
        
        If btnActualizaVenta.Visible Then
            Cancela = True
            'btnEliminarVenta_Click
        End If
        
        IdPedido = LstDPedidos(1, LstPedidos.SelectedItem.Index - 1)
        TxtFolio.Text = LstDPedidos(1, LstPedidos.SelectedItem.Index - 1)
        cmbTipoVenta.ListIndex = SearchInList(LstDTipoVenta, LstDPedidos(2, LstPedidos.SelectedItem.Index - 1), 0)
        TxtRutaP.Text = LstDPedidos(5, LstPedidos.SelectedItem.Index - 1)
        TxtRutaE.Text = LstDPedidos(7, LstPedidos.SelectedItem.Index - 1)
        DTPFechaP.Value = LstDPedidos(6, LstPedidos.SelectedItem.Index - 1)
        DTPFechaE.Value = LstDPedidos(8, LstPedidos.SelectedItem.Index - 1)
        
        IdCliente = LstDPedidos(9, LstPedidos.SelectedItem.Index - 1)
        IdSucursal = LstDPedidos(16, LstPedidos.SelectedItem.Index - 1)
        IdTipoVenta = LstDPedidos(2, LstPedidos.SelectedItem.Index - 1)
        
        TxtCliente.Text = LstDPedidos(9, LstPedidos.SelectedItem.Index - 1) & " - " & LstDPedidos(10, LstPedidos.SelectedItem.Index - 1)
        TxtRFC2.Text = LstDPedidos(18, LstPedidos.SelectedItem.Index - 1)
        TxtSucursal.Text = LstDPedidos(16, LstPedidos.SelectedItem.Index - 1) & " (CB: " & LstDPedidos(14, LstPedidos.SelectedItem.Index - 1) & ") " & LstDPedidos(15, LstPedidos.SelectedItem.Index - 1)
        TxtListaPrecios.Text = LstDPedidos(22, LstPedidos.SelectedItem.Index - 1) & " - " & LstDPedidos(23, LstPedidos.SelectedItem.Index - 1)
        
        LblPedido(0).Caption = "Pedido " & Format(IdPedido, "000000") & " - Ruta " & LstDPedidos(5, LstPedidos.SelectedItem.Index - 1) & " " & Format(LstDPedidos(6, LstPedidos.SelectedItem.Index - 1), ctFechaLarga)
        LblFactura.Caption = IIf(Trim(LstDPedidos(26, LstPedidos.SelectedItem.Index - 1)) = "", "", "Factura " & Format(LstDPedidos(26, LstPedidos.SelectedItem.Index - 1), "0000000"))
        
        FiltraClientes 3
    Else
        LblFactura.Caption = ""
    End If

End Sub

Private Sub OptCons_Click(Index As Integer)
On Error Resume Next
    MuestraPedidos
End Sub

Private Sub SSTab_Click(PreviousTab As Integer)
On Error Resume Next
    If IsEmpty(IdPedido) Then IdPedido = 0
    If SSTab.Tab >= 1 And (IsEmpty(LstDPedidos) Or IdPedido = 0) Then
        MsgBox "¡ Selecciona un Pedido !", vbInformation + vbOKOnly, App.Title
        SSTab.Tab = 0
        Exit Sub
    End If
    
    Select Case SSTab.Tab
        Case 0:
            LlenaComboVentas
            MuestraPedidos
        Case 1:
            MuestraDetalleP False
            MuestraTotalesP False
            TxtIdProd.SetFocus
    End Select
End Sub

Private Sub TxtFolio_GotFocus()
On Error Resume Next
    SelText TxtFolio
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

Sub LlenaComboVentas()
On Error Resume Next
    StrCmd = "execute sel_VentasTipo "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDTipoVenta = GetDataCBL(Rs, cmbTipoVenta, "Tipo de Venta", "No existen Tipos de Venta definidos")
End Sub

Sub MuestraPedidos()
On Error Resume Next
Dim Opc

    For i = 0 To OptCons.Count
        If OptCons(i).Value Then
            Opc = i
            Exit For
        End If
    Next
    
    If Seleccionar And IdRutaPedido = 0 Then IdRutaPedido = IdRuta
     
    StrCmd = "execute sel_Pedidos " & IdCedis & ", '" & FormatDate(DTPFechaP.Value) & "', '" & Opc & "', '" & IIf(ChkRuta.Value, IdRutaPedido, "") & "', 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDPedidos = GetDataLVL(RsC, LstPedidos, 3, 16, "0|0|0|4|0|4|0|0|7|7|7|0|0|0")
    LstPedidos_ItemClick LstPedidos.SelectedItem
End Sub

Sub FiltraClientes(Opc As Integer)
On Error Resume Next
    LblCliente(0).Caption = "": LblCliente(1).Caption = ""
    If Opc = 1 Then
        StrCmd = "execute sel_ClientesFacturas " & IdCedis & ",'" & IIf(Trim(TxtIdCliente.Text) = "", 0, Trim(TxtIdCliente.Text)) & "','" & Trim(TxtRFC.Text) & "','" & Trim(TxtRazonSocial.Text) & "', " & Opc
    Else
        StrCmd = "execute sel_ClientesFacturas " & IdCedis & ",'" & LstDPedidos(9, LstPedidos.SelectedItem.Index - 1) & "','','" & LstDPedidos(17, LstPedidos.SelectedItem.Index - 1) & "', " & Opc
    End If
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
'Debug.Print StrCmd
    LstDClientes = GetDataLVL(RsC, LstClientes, 1, 4, "0|0|0|0")
End Sub

Sub CancelaVenta()
On Error Resume Next
    cmbTipoVenta.ListIndex = 0
    TxtIdCliente.Text = "": TxtRFC.Text = "": TxtRazonSocial.Text = "": LstClientes.ListItems.Clear
End Sub

Private Sub TxtRutaE_Change()
On Error Resume Next
    IdRutaPedido = TxtRutaE.Text
    If ChkRuta.Value Then MuestraPedidos
End Sub

Private Sub TxtRutaE_GotFocus()
On Error Resume Next
    SelText TxtRutaE
End Sub

Private Sub TxtRutaE_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        TxtRFC.SetFocus
        Exit Sub
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtRutaE_Validate(Cancel As Boolean)
'On Error Resume Next
'    ValidaRutaPedido TxtRutaE
End Sub

Private Sub TxtRutaP_Change()
On Error Resume Next
    IdRutaPedido = TxtRutaP.Text
    If ChkRuta.Value Then MuestraPedidos
End Sub

Private Sub TxtRutaP_GotFocus()
On Error Resume Next
    SelText TxtRutaP
End Sub

Private Sub TxtRutaP_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        DTPFechaE.SetFocus
        Exit Sub
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtRutaP_Validate(Cancel As Boolean)
'On Error Resume Next
'    ValidaRutaPedido TxtRutaP
End Sub

Function ValidaRutaPedido(Txt As TextBox) As Boolean
    If Trim(Txt.Text) = "" Then Txt.Text = "0"
    StrCmd = "execute sel_ExisteRuta " & IdCedis & ", " & Txt.Text
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Rs.EOF Then
        MsgBox "¡ La Ruta " & Txt.Text & " no existe !", vbInformation + vbOKOnly, App.Title
        Txt.Text = ""
        Txt.SetFocus
        ValidaRutaPedido = False
        Exit Function
    End If
    ValidaRutaPedido = True
End Function

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

Dim Existencias, Descuento, DctoCapturado

    If KeyAscii = 13 Then
        If Not ValidaModulo("PEDID", True) Then Exit Sub
        
        If LstDPedidos(23, LstPedidos.SelectedItem.Index - 1) <> 0 Then
            MsgBox "¡ El pedido ya se ha convertido en Venta y NO puede ser Modificado !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If

        SplitTxt TxtCantidad
        
        TxtDctoPorc.Text = itFlotante(TxtDctoPorc.Text)
        
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
            MsgBox "¡ Teclee la Cantidad de producto para el Pedido !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If Trim(TxtCantidad.Text) = "0" Then
            If MsgBox("¿ Está seguro que desea Eliminar la partida seleccionada ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        End If
        
        
        StrCmd = "execute up_PedidosDetalle " & IdCedis & ", " & IdPedido & ", " & IdTipoVenta & ", " & TxtIdProd.Text & _
            ", " & TxtCantidad.Text & ", " & Precio & ", " & Iva & ", 0, 0, " & TxtCantidad.Text & ", 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        MuestraDetalleP False
        MuestraTotalesP False
        
        TxtCantidad.Text = 0: TxtPrecio.Text = 0: TxtDctoPorc.Text = 0: TxtDctoImp.Text = 0: TxtEntregado.Text = 0
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
        If Not ValidaModulo("PEDID", True) Then Exit Sub
        
        If LstDPedidos(24, LstPedidos.SelectedItem.Index - 1) <> 0 Then
            MsgBox "¡ El pedido ya ha sido Facturado y NO puede ser Modificado !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If

        SplitTxt TxtDctoPorc
        
        TxtDctoPorc.Text = itFlotante(TxtDctoPorc.Text)
        
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
            MsgBox "¡ Teclee la Cantidad de producto para el Pedido !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If Trim(TxtCantidad.Text) = "0" Then
            If MsgBox("¿ Está seguro que desea Eliminar la partida seleccionada ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        End If
        
        
        StrCmd = "execute up_PedidosDetalle " & IdCedis & ", " & IdPedido & ", " & IdTipoVenta & ", " & TxtIdProd.Text & _
            ", " & TxtCantidad.Text & ", " & Precio & ", " & Iva & ", " & CDbl(TxtDctoPorc.Text) / 100 & ", " & TxtDctoImp.Text & ", " & TxtEntregado.Text & ", 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
'        StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", 0, 0, 0, " & IdTipoVenta & ", '', " & IdPedido & ", '" & _
'        FormatDate(Fecha) & "', " & TxtRutaP.Text & ", " & IdCliente & ", '" & IdSucursal & "', " & TxtIdProd.Text & ", 'Actualizar', 'Pedido " & IdPedido & ". Producto " & TxtIdProd.Text & ", Cantidad " & CDbl(TxtCantidad.Text) & ", Precio " & Precio & ", Iva" & Iva & ", Dcto. Porc. " & CDbl(TxtDctoPorc.Text) / 100 & "%, Dcto. Importe " & CDbl(TxtDctoImp.Text) & ", Entregado " & TxtEntregado.Text & "', 8"
'        If Rs.State Then Rs.Close
'        Rs.Open StrCmd, Cnn
        
        MuestraDetalleP False
        MuestraTotalesP False
        
        TxtCantidad.Text = 0: TxtPrecio.Text = 0: TxtDctoPorc.Text = 0: TxtDctoImp.Text = 0: TxtEntregado.Text = 0
        TxtIdProd.Text = "": TxtIdProd.SetFocus: TxtDesc.Text = ""
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
End Sub

Private Sub TxtIdProd_Change()
On Error Resume Next
    TxtDesc.Text = "¡ Producto no econtrado !": TxtCantidad.Text = 0: TxtPrecio.Text = 0: TxtSubtotal.Text = 0: TxtIva.Text = 0: TxtTotal.Text = 0: TxtExistencia.Text = 0
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
        
        ' saco el producto tiene precio y el cedis tiene lista de contado...
        Precio = 0: IdLista = 0
        StrCmd = "execute sel_Precios " & IdCedis & ", " & IdCliente & ", " & TxtRutaP.Text & ", " & TxtIdProd.Text & ", 0, 0, 0"
'        MsgBox "execute sel_Precios " & IdCedis & ", " & IdCliente & ", " & TxtRutaP.Text & ", " & TxtIdProd.Text & ", 0, 0, 0", vbInformation + vbOKOnly, App.Title
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            Precio = Rs.Fields(1): IdLista = Rs.Fields(0)
            If Rs.Fields(0) = 0 Then
                MsgBox "¡ El Cedis " & IdCedis & " - " & NomCedis & " no tiene asignada una Lista de Precios Base !", vbInformation + vbOKOnly, App.Title
                TxtCantidad.Text = 0: TxtPrecio.Text = 0: TxtEntregado.Text = 0: TxtDctoPorc.Text = 0: TxtDctoImp.Text = 0
                Exit Sub
            End If
            If Rs.Fields(1) = 0 Then
                MsgBox "¡ El Producto " & TxtIdProd.Text & " no tiene precio !", vbInformation + vbOKOnly, App.Title
                TxtCantidad.Text = 0: TxtPrecio.Text = 0: TxtEntregado.Text = 0: TxtDctoPorc.Text = 0: TxtDctoImp.Text = 0
                Exit Sub
            End If
            TxtPrecio.Text = FormatCurrency(Rs.Fields(1), 2, vbTrue)
        End If
        
        ' valido si el producto ya está registrado en la Venta y obtiene nuevos datos
        StrCmd = "execute sel_PedidosDetalle " & IdCedis & ", " & IdPedido & ", " & TxtIdProd.Text & ", 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            TxtDesc.Text = Rs.Fields(1)
            TxtCantidad.Text = Rs.Fields(2): TxtPrecio.Text = FormatCurrency(Precio, 3, vbTrue):
            TxtDctoPorc.Text = FormatNumber(CDbl(Rs.Fields(4)) * 100, 2): TxtDctoImp.Text = FormatCurrency(Rs.Fields(5), 3, vbTrue)
            TxtEntregado.Text = FormatNumber(Rs.Fields(3), 3)
            Iva = Rs.Fields(6)
            Dec = IIf(Rs.Fields(7) = 1, True, False)
        Else
            TxtDesc.Text = "¡ Producto no Encontado !"
            TxtCantidad.Text = 0: TxtDctoPorc.Text = 0: TxtDctoImp.Text = 0
            TxtIdProd.Text = ""
            TxtIdProd.SetFocus
            Iva = 0
            Dec = False
        End If
    Else
        TxtDesc.Text = "": TxtCantidad.Text = 0: TxtPrecio.Text = 0
        TxtDctoPorc.Text = 0: TxtDctoImp.Text = 0: TxtEntregado.Text = 0
    End If
    TxtCantidad.SetFocus
End Sub

Sub MuestraDetalleP(Rep As Boolean)
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    StrCmd = "execute sel_PedidosDetalle " & IdCedis & ", " & IdPedido & ", " & IdTipoVenta & ", 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    If Not Rep Then LstDPartidas = GetDataLVL(RsC, LstPartidas, 3, 9, "0|0|9|7|7|8|7")
End Sub

Sub MuestraTotalesP(Rep As Boolean)
On Error Resume Next
    StrCmd = "execute sel_PedidosDetalle " & IdCedis & ", " & IdPedido & ", " & IdTipoVenta & ", 3"
    If RsC.State Then RsC.Close
    If Not Rep Then RsC.Open StrCmd, Cnn
    If Not Rep Then
        LblSubtotal.Caption = FormatCurrency(RsC.Fields(0), 2, vbTrue)
        LblIva.Caption = FormatCurrency(RsC.Fields(1), 2, vbTrue)
        LblTotal.Caption = FormatCurrency(RsC.Fields(2), 2, vbTrue)
        LblDescuento.Caption = FormatCurrency(RsC.Fields(3), 2, vbTrue)
    End If
End Sub

