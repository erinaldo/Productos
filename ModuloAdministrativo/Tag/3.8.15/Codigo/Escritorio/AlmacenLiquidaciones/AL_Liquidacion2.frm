VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form AL_Liquidacion2 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Liquidación de Rutas de Distribución"
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
   Begin TabDlg.SSTab SSTab 
      Height          =   8175
      Left            =   120
      TabIndex        =   10
      Top             =   120
      Width           =   12375
      _ExtentX        =   21828
      _ExtentY        =   14420
      _Version        =   393216
      Tabs            =   5
      Tab             =   4
      TabsPerRow      =   5
      TabHeight       =   520
      BackColor       =   16777215
      TabCaption(0)   =   "&Cargas de Rutas"
      TabPicture(0)   =   "AL_Liquidacion2.frx":0000
      Tab(0).ControlEnabled=   0   'False
      Tab(0).Control(0)=   "LblOpt(0)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "FrmOpt(0)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "Carga de &Producto"
      TabPicture(1)   =   "AL_Liquidacion2.frx":001C
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "LblOpt(3)"
      Tab(1).Control(0).Enabled=   0   'False
      Tab(1).Control(1)=   "FrmOpt(3)"
      Tab(1).Control(1).Enabled=   0   'False
      Tab(1).ControlCount=   2
      TabCaption(2)   =   "&Devoluciones de Producto"
      TabPicture(2)   =   "AL_Liquidacion2.frx":0038
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "LblOpt(4)"
      Tab(2).Control(0).Enabled=   0   'False
      Tab(2).Control(1)=   "FrmOpt(4)"
      Tab(2).Control(1).Enabled=   0   'False
      Tab(2).ControlCount=   2
      TabCaption(3)   =   "&Ventas"
      TabPicture(3)   =   "AL_Liquidacion2.frx":0054
      Tab(3).ControlEnabled=   0   'False
      Tab(3).Control(0)=   "LblOpt(6)"
      Tab(3).Control(0).Enabled=   0   'False
      Tab(3).Control(1)=   "FrmOpt(2)"
      Tab(3).Control(1).Enabled=   0   'False
      Tab(3).ControlCount=   2
      TabCaption(4)   =   "&Liquidaciones"
      TabPicture(4)   =   "AL_Liquidacion2.frx":0070
      Tab(4).ControlEnabled=   -1  'True
      Tab(4).Control(0)=   "LblOpt(1)"
      Tab(4).Control(0).Enabled=   0   'False
      Tab(4).Control(1)=   "FrmOpt(1)"
      Tab(4).Control(1).Enabled=   0   'False
      Tab(4).ControlCount=   2
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
         Index           =   1
         Left            =   0
         TabIndex        =   39
         Top             =   360
         Width           =   12375
         Begin VB.Frame frmContado 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Factura de Contado"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   3375
            Left            =   480
            TabIndex        =   123
            Top             =   4200
            Width           =   3135
            Begin VB.CommandButton btnFactura 
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
               Height          =   735
               Left            =   120
               Picture         =   "AL_Liquidacion2.frx":008C
               Style           =   1  'Graphical
               TabIndex        =   136
               Top             =   360
               Width           =   735
            End
            Begin VB.Frame frmDatosC 
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
               Height          =   2055
               Left            =   120
               TabIndex        =   124
               Top             =   1200
               Width           =   2895
               Begin VB.TextBox TxtFolioC 
                  Alignment       =   1  'Right Justify
                  Height          =   375
                  Left            =   1320
                  Locked          =   -1  'True
                  TabIndex        =   126
                  Text            =   "0"
                  Top             =   480
                  Width           =   1335
               End
               Begin VB.TextBox TxtSerieC 
                  Height          =   375
                  Left            =   600
                  Locked          =   -1  'True
                  TabIndex        =   125
                  Top             =   480
                  Width           =   615
               End
               Begin VB.Label Label37 
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
                  Left            =   120
                  TabIndex        =   134
                  Top             =   960
                  Width           =   720
               End
               Begin VB.Label Label36 
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
                  Left            =   540
                  TabIndex        =   133
                  Top             =   1320
                  Width           =   270
               End
               Begin VB.Label Label35 
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
                  Left            =   405
                  TabIndex        =   132
                  Top             =   1680
                  Width           =   450
               End
               Begin VB.Label LblSubtotal 
                  Alignment       =   1  'Right Justify
                  Appearance      =   0  'Flat
                  BackColor       =   &H80000005&
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
                  Left            =   1080
                  TabIndex        =   131
                  Top             =   960
                  Width           =   1635
               End
               Begin VB.Label LblIva 
                  Alignment       =   1  'Right Justify
                  Appearance      =   0  'Flat
                  BackColor       =   &H80000005&
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
                  Left            =   1080
                  TabIndex        =   130
                  Top             =   1320
                  Width           =   1635
               End
               Begin VB.Label LblTotal 
                  Alignment       =   1  'Right Justify
                  Appearance      =   0  'Flat
                  BackColor       =   &H80000005&
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
                  Left            =   1080
                  TabIndex        =   129
                  Top             =   1680
                  Width           =   1635
               End
               Begin VB.Label Label34 
                  Alignment       =   1  'Right Justify
                  BackColor       =   &H00FFFFFF&
                  Caption         =   "Folio"
                  Height          =   255
                  Left            =   1680
                  TabIndex        =   128
                  Top             =   240
                  Width           =   975
               End
               Begin VB.Label Label33 
                  BackColor       =   &H00FFFFFF&
                  Caption         =   "Serie"
                  Height          =   255
                  Left            =   600
                  TabIndex        =   127
                  Top             =   240
                  Width           =   615
               End
            End
            Begin VB.Label LblContado 
               Alignment       =   2  'Center
               BackColor       =   &H00FFFFFF&
               Caption         =   "Factura de Contado del Día"
               Height          =   495
               Left            =   960
               TabIndex        =   135
               Top             =   480
               Width           =   1935
            End
         End
         Begin VB.Frame FrmStatus 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Estatus de Liquidación de Rutas"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   7095
            Left            =   4080
            TabIndex        =   68
            Top             =   480
            Width           =   7695
            Begin VB.CommandButton btnIniciarCerrarDia 
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
               Height          =   615
               Index           =   1
               Left            =   4200
               Picture         =   "AL_Liquidacion2.frx":03EA
               Style           =   1  'Graphical
               TabIndex        =   71
               Top             =   480
               Visible         =   0   'False
               Width           =   1815
            End
            Begin VB.CommandButton btnIniciarCerrarDia 
               BackColor       =   &H00FFFFFF&
               Height          =   615
               Index           =   0
               Left            =   4200
               Picture         =   "AL_Liquidacion2.frx":0B85
               Style           =   1  'Graphical
               TabIndex        =   72
               Top             =   480
               Visible         =   0   'False
               Width           =   1815
            End
            Begin MSComCtl2.DTPicker DTPFechaSel 
               Height          =   375
               Left            =   240
               TabIndex        =   69
               Top             =   720
               Width           =   3855
               _ExtentX        =   6800
               _ExtentY        =   661
               _Version        =   393216
               Format          =   64749568
               CurrentDate     =   39396
            End
            Begin MSComctlLib.ListView LstStatusRutas 
               Height          =   5535
               Left            =   240
               TabIndex        =   70
               Top             =   1440
               Width           =   7215
               _ExtentX        =   12726
               _ExtentY        =   9763
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
            Begin VB.Label LblStatusDia 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Estatus del día."
               BeginProperty Font 
                  Name            =   "Arial"
                  Size            =   9.75
                  Charset         =   0
                  Weight          =   700
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               ForeColor       =   &H000000C0&
               Height          =   240
               Left            =   360
               TabIndex        =   74
               Top             =   480
               Width           =   1440
            End
         End
         Begin MSComCtl2.MonthView MonthV 
            Height          =   2820
            Left            =   480
            TabIndex        =   67
            Top             =   1080
            Width           =   3120
            _ExtentX        =   5503
            _ExtentY        =   4974
            _Version        =   393216
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            MultiSelect     =   -1  'True
            StartOfWeek     =   64749569
            CurrentDate     =   39396
         End
         Begin VB.Label Label16 
            Alignment       =   2  'Center
            BackColor       =   &H00FFFFFF&
            Caption         =   "Avance en cierre de días durante el mes."
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
            TabIndex        =   73
            Top             =   480
            Visible         =   0   'False
            Width           =   3135
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
         Index           =   4
         Left            =   -75000
         TabIndex        =   17
         Top             =   340
         Width           =   12375
         Begin VB.Frame Frame4 
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
            Height          =   855
            Left            =   4200
            TabIndex        =   109
            Top             =   6880
            Width           =   7935
            Begin VB.Label LblVentas 
               Alignment       =   1  'Right Justify
               Appearance      =   0  'Flat
               BackColor       =   &H80000005&
               BorderStyle     =   1  'Fixed Single
               Caption         =   "0.00"
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
               Left            =   6390
               TabIndex        =   121
               Top             =   120
               Width           =   1275
            End
            Begin VB.Label Label31 
               Alignment       =   1  'Right Justify
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Ventas"
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
               Left            =   5640
               TabIndex        =   120
               Top             =   120
               Width           =   570
            End
            Begin VB.Label LblExistencias 
               Alignment       =   1  'Right Justify
               Appearance      =   0  'Flat
               BackColor       =   &H80000005&
               BorderStyle     =   1  'Fixed Single
               Caption         =   "0.00"
               BeginProperty Font 
                  Name            =   "Arial"
                  Size            =   9
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               ForeColor       =   &H000000C0&
               Height          =   345
               Left            =   6390
               TabIndex        =   119
               Top             =   480
               Width           =   1275
            End
            Begin VB.Label Label32 
               Alignment       =   1  'Right Justify
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Existencias"
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
               Left            =   5280
               TabIndex        =   118
               Top             =   480
               Width           =   945
            End
            Begin VB.Label LblObsequios 
               Alignment       =   1  'Right Justify
               Appearance      =   0  'Flat
               BackColor       =   &H80000005&
               BorderStyle     =   1  'Fixed Single
               Caption         =   "0.00"
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
               Left            =   3840
               TabIndex        =   117
               Top             =   480
               Width           =   1275
            End
            Begin VB.Label Label30 
               Alignment       =   1  'Right Justify
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Obsequios"
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
               Left            =   2760
               TabIndex        =   116
               Top             =   480
               Width           =   915
            End
            Begin VB.Label LblDevMala 
               Alignment       =   1  'Right Justify
               Appearance      =   0  'Flat
               BackColor       =   &H80000005&
               BorderStyle     =   1  'Fixed Single
               Caption         =   "0.00"
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
               Left            =   3840
               TabIndex        =   115
               Top             =   120
               Width           =   1275
            End
            Begin VB.Label LblDevBuena 
               Alignment       =   1  'Right Justify
               Appearance      =   0  'Flat
               BackColor       =   &H80000005&
               BorderStyle     =   1  'Fixed Single
               Caption         =   "0.00"
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
               TabIndex        =   114
               Top             =   480
               Width           =   1275
            End
            Begin VB.Label LblCarga 
               Alignment       =   1  'Right Justify
               Appearance      =   0  'Flat
               BackColor       =   &H80000005&
               BorderStyle     =   1  'Fixed Single
               Caption         =   "0.00"
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
               TabIndex        =   113
               Top             =   120
               Width           =   1275
            End
            Begin VB.Label Label27 
               Alignment       =   1  'Right Justify
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Dev. Mala"
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
               Left            =   2880
               TabIndex        =   112
               Top             =   120
               Width           =   795
            End
            Begin VB.Label Label28 
               Alignment       =   1  'Right Justify
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Dev. Buena"
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
               TabIndex        =   111
               Top             =   480
               Width           =   945
            End
            Begin VB.Label Label29 
               Alignment       =   1  'Right Justify
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Carga"
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
               Left            =   600
               TabIndex        =   110
               Top             =   120
               Width           =   510
            End
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
            Picture         =   "AL_Liquidacion2.frx":12EA
            Style           =   1  'Graphical
            TabIndex        =   106
            Top             =   960
            Width           =   495
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
            Picture         =   "AL_Liquidacion2.frx":16C7
            Style           =   1  'Graphical
            TabIndex        =   105
            Top             =   975
            Width           =   495
         End
         Begin VB.CommandButton Command2 
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
            Picture         =   "AL_Liquidacion2.frx":1AEC
            Style           =   1  'Graphical
            TabIndex        =   103
            Top             =   7080
            Visible         =   0   'False
            Width           =   1815
         End
         Begin VB.CommandButton btnImprimeDev 
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
            Picture         =   "AL_Liquidacion2.frx":2183
            Style           =   1  'Graphical
            TabIndex        =   64
            Top             =   7080
            Width           =   1815
         End
         Begin VB.TextBox TxtFaltanteD 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   10080
            Locked          =   -1  'True
            MaxLength       =   8
            TabIndex        =   23
            Text            =   "0"
            Top             =   1080
            Width           =   855
         End
         Begin VB.TextBox TxtVentaD 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   6120
            Locked          =   -1  'True
            MaxLength       =   8
            TabIndex        =   25
            Text            =   "0"
            Top             =   1080
            Width           =   855
         End
         Begin VB.TextBox TxtObsequiosD 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   9240
            MaxLength       =   8
            TabIndex        =   22
            Text            =   "0"
            Top             =   1080
            Width           =   735
         End
         Begin VB.TextBox TxtMalaD 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   8160
            MaxLength       =   8
            TabIndex        =   21
            Text            =   "0"
            Top             =   1080
            Width           =   975
         End
         Begin VB.TextBox TxtBuenaD 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   7080
            MaxLength       =   8
            TabIndex        =   20
            Text            =   "0"
            Top             =   1080
            Width           =   975
         End
         Begin VB.TextBox TxtIdProdD 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   120
            MaxLength       =   5
            TabIndex        =   18
            Top             =   1080
            Width           =   735
         End
         Begin VB.TextBox TxtDescD 
            Height          =   375
            Left            =   960
            TabIndex        =   19
            Top             =   1080
            Width           =   4095
         End
         Begin VB.TextBox TxtCargaD 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   5160
            Locked          =   -1  'True
            MaxLength       =   8
            TabIndex        =   24
            Text            =   "0"
            Top             =   1080
            Width           =   855
         End
         Begin MSComctlLib.ListView LstDevoluciones 
            Height          =   5295
            Left            =   120
            TabIndex        =   28
            Top             =   1560
            Width           =   12015
            _ExtentX        =   21193
            _ExtentY        =   9340
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
         Begin VB.Label Label11 
            Alignment       =   1  'Right Justify
            BackColor       =   &H00FFFFFF&
            Caption         =   "Existencia"
            Height          =   255
            Left            =   9960
            TabIndex        =   63
            Top             =   840
            Width           =   975
         End
         Begin VB.Label Label10 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Venta"
            Height          =   255
            Left            =   6120
            TabIndex        =   62
            Top             =   840
            Width           =   615
         End
         Begin VB.Label Label9 
            Alignment       =   1  'Right Justify
            BackColor       =   &H00FFFFFF&
            Caption         =   "Obseq."
            Height          =   255
            Left            =   9240
            TabIndex        =   61
            Top             =   840
            Width           =   615
         End
         Begin VB.Label Label7 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Dev. Mala"
            Height          =   255
            Left            =   8160
            TabIndex        =   60
            Top             =   840
            Width           =   855
         End
         Begin VB.Label Label6 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Dev. Buena"
            Height          =   255
            Left            =   7080
            TabIndex        =   59
            Top             =   840
            Width           =   1095
         End
         Begin VB.Line Line2 
            X1              =   120
            X2              =   12255
            Y1              =   600
            Y2              =   600
         End
         Begin VB.Label LblSurtido 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Carga"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   12
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000000C0&
            Height          =   270
            Index           =   1
            Left            =   360
            TabIndex        =   55
            Top             =   240
            Width           =   660
         End
         Begin VB.Label Label8 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Descripción del Producto"
            Height          =   255
            Left            =   960
            TabIndex        =   30
            Top             =   840
            Width           =   3135
         End
         Begin VB.Label Label5 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cve. P"
            Height          =   255
            Left            =   120
            TabIndex        =   29
            Top             =   840
            Width           =   615
         End
         Begin VB.Label Label3 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Surtido"
            Height          =   255
            Left            =   5160
            TabIndex        =   27
            Top             =   840
            Width           =   855
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
         Left            =   -75000
         TabIndex        =   15
         Top             =   345
         Width           =   12375
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
            Picture         =   "AL_Liquidacion2.frx":289E
            Style           =   1  'Graphical
            TabIndex        =   77
            Top             =   960
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
            Picture         =   "AL_Liquidacion2.frx":2F2C
            Style           =   1  'Graphical
            TabIndex        =   104
            Top             =   1200
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
            TabIndex        =   91
            Top             =   1680
            Width           =   10215
            Begin VB.TextBox TxtIdCliente 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   120
               TabIndex        =   83
               Top             =   480
               Width           =   975
            End
            Begin VB.TextBox TxtRFC 
               Height          =   375
               Left            =   1200
               TabIndex        =   84
               Top             =   480
               Width           =   1815
            End
            Begin VB.TextBox TxtRazonSocial 
               Height          =   375
               Left            =   3120
               TabIndex        =   85
               Top             =   480
               Width           =   2295
            End
            Begin MSComctlLib.ListView LstClientes 
               Height          =   2055
               Left            =   120
               TabIndex        =   86
               Top             =   960
               Width           =   9975
               _ExtentX        =   17595
               _ExtentY        =   3625
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
            Begin VB.Label Label26 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Cliente Seleccionado"
               Height          =   200
               Left            =   5520
               TabIndex        =   102
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
               Height          =   450
               Left            =   5520
               TabIndex        =   101
               Top             =   420
               Width           =   4485
            End
            Begin VB.Label Label20 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "No. Cliente"
               Height          =   240
               Left            =   120
               TabIndex        =   94
               Top             =   240
               Width           =   960
            End
            Begin VB.Label Label21 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Razón Social ( Cliente )"
               Height          =   255
               Left            =   3120
               TabIndex        =   93
               Top             =   240
               Width           =   2295
            End
            Begin VB.Label Label22 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Sucursal"
               Height          =   240
               Left            =   1200
               TabIndex        =   92
               Top             =   240
               Width           =   765
            End
         End
         Begin VB.Frame Frame2 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Datos de la Factura"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   975
            Left            =   1920
            TabIndex        =   79
            Top             =   720
            Width           =   10215
            Begin VB.TextBox TxtTotal 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   8400
               Locked          =   -1  'True
               TabIndex        =   99
               Text            =   "0"
               Top             =   480
               Width           =   1695
            End
            Begin VB.TextBox TxtIva 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   7200
               Locked          =   -1  'True
               TabIndex        =   97
               Text            =   "0"
               Top             =   480
               Width           =   975
            End
            Begin VB.TextBox TxtSubtotal 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   5400
               Locked          =   -1  'True
               TabIndex        =   95
               Text            =   "0"
               Top             =   480
               Width           =   1575
            End
            Begin VB.TextBox TxtSerie 
               Height          =   375
               Left            =   3000
               Locked          =   -1  'True
               TabIndex        =   81
               Top             =   480
               Width           =   615
            End
            Begin VB.TextBox TxtFolio 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   3840
               TabIndex        =   82
               Text            =   "0"
               Top             =   480
               Width           =   1335
            End
            Begin VB.ComboBox cmbTipoVenta 
               Height          =   360
               Left            =   120
               Style           =   2  'Dropdown List
               TabIndex        =   80
               Top             =   480
               Width           =   2655
            End
            Begin VB.Label Label25 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Total"
               Height          =   255
               Left            =   9000
               TabIndex        =   100
               Top             =   240
               Width           =   975
            End
            Begin VB.Label Label24 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Iva"
               Height          =   255
               Left            =   7080
               TabIndex        =   98
               Top             =   240
               Width           =   975
            End
            Begin VB.Label Label23 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Subtotal"
               Height          =   255
               Left            =   5880
               TabIndex        =   96
               Top             =   240
               Width           =   975
            End
            Begin VB.Label Label19 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Serie"
               Height          =   255
               Left            =   3000
               TabIndex        =   90
               Top             =   240
               Width           =   615
            End
            Begin VB.Label Label18 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Folio"
               Height          =   255
               Left            =   4200
               TabIndex        =   89
               Top             =   240
               Width           =   975
            End
            Begin VB.Label Label17 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Tipo de Venta"
               Height          =   240
               Left            =   120
               TabIndex        =   87
               Top             =   240
               Width           =   1200
            End
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
            Picture         =   "AL_Liquidacion2.frx":38C2
            Style           =   1  'Graphical
            TabIndex        =   78
            Top             =   2400
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
            Picture         =   "AL_Liquidacion2.frx":3FDD
            Style           =   1  'Graphical
            TabIndex        =   76
            Top             =   1800
            Width           =   1695
         End
         Begin VB.Frame Frame1 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Facturas"
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
            TabIndex        =   75
            Top             =   4800
            Width           =   12015
            Begin MSComctlLib.ListView LstFacturas 
               Height          =   2415
               Left            =   120
               TabIndex        =   88
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
         Begin VB.Line Line3 
            X1              =   120
            X2              =   12255
            Y1              =   600
            Y2              =   600
         End
         Begin VB.Label LblSurtido 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Carga"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   12
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000000C0&
            Height          =   270
            Index           =   2
            Left            =   360
            TabIndex        =   54
            Top             =   240
            Width           =   660
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
         Index           =   3
         Left            =   -75000
         TabIndex        =   13
         Top             =   340
         Width           =   12375
         Begin VB.CommandButton btnRoute 
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
            Picture         =   "AL_Liquidacion2.frx":46ED
            Style           =   1  'Graphical
            TabIndex        =   57
            Top             =   7080
            Visible         =   0   'False
            Width           =   1935
         End
         Begin VB.CommandButton btnAddC 
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
            Left            =   8640
            Picture         =   "AL_Liquidacion2.frx":4ED7
            Style           =   1  'Graphical
            TabIndex        =   108
            Top             =   960
            Width           =   495
         End
         Begin VB.CommandButton btnDeleteC 
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
            Left            =   9240
            Picture         =   "AL_Liquidacion2.frx":52B4
            Style           =   1  'Graphical
            TabIndex        =   107
            Top             =   960
            Width           =   495
         End
         Begin VB.TextBox TxtExistencias 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   7320
            Locked          =   -1  'True
            MaxLength       =   8
            TabIndex        =   65
            Text            =   "0"
            Top             =   1080
            Width           =   975
         End
         Begin VB.CommandButton btnAplicaC 
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
            Left            =   4320
            Picture         =   "AL_Liquidacion2.frx":56D9
            Style           =   1  'Graphical
            TabIndex        =   58
            Top             =   7080
            Visible         =   0   'False
            Width           =   1935
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
            Picture         =   "AL_Liquidacion2.frx":5D70
            Style           =   1  'Graphical
            TabIndex        =   56
            Top             =   7080
            Width           =   1815
         End
         Begin VB.TextBox TxtCantidadS 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   6240
            MaxLength       =   8
            TabIndex        =   33
            Text            =   "0"
            Top             =   1080
            Width           =   975
         End
         Begin VB.TextBox TxtDescS 
            Height          =   375
            Left            =   1200
            TabIndex        =   32
            Top             =   1080
            Width           =   4935
         End
         Begin VB.TextBox TxtIdProdS 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   360
            MaxLength       =   5
            TabIndex        =   31
            Top             =   1080
            Width           =   735
         End
         Begin MSComctlLib.ListView LstSurtido 
            Height          =   5415
            Left            =   360
            TabIndex        =   34
            Top             =   1560
            Width           =   11775
            _ExtentX        =   20770
            _ExtentY        =   9551
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
         Begin VB.Label Label15 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Existencias"
            Height          =   255
            Left            =   7320
            TabIndex        =   66
            Top             =   840
            Width           =   1095
         End
         Begin VB.Line Line1 
            X1              =   120
            X2              =   12255
            Y1              =   600
            Y2              =   600
         End
         Begin VB.Label LblSurtido 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Carga"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   12
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000000C0&
            Height          =   270
            Index           =   0
            Left            =   360
            TabIndex        =   53
            Top             =   240
            Width           =   660
         End
         Begin VB.Label Label14 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Carga"
            Height          =   255
            Left            =   6240
            TabIndex        =   37
            Top             =   840
            Width           =   1095
         End
         Begin VB.Label Label13 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cve. P"
            Height          =   255
            Left            =   360
            TabIndex        =   36
            Top             =   840
            Width           =   615
         End
         Begin VB.Label Label12 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Descripción del Producto"
            Height          =   255
            Left            =   1200
            TabIndex        =   35
            Top             =   840
            Width           =   3735
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
         Index           =   0
         Left            =   -75000
         TabIndex        =   12
         Top             =   340
         Width           =   12375
         Begin VB.CommandButton btnImprimeLiquidacion 
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
            Picture         =   "AL_Liquidacion2.frx":648B
            Style           =   1  'Graphical
            TabIndex        =   122
            Top             =   2520
            Width           =   1695
         End
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
            Picture         =   "AL_Liquidacion2.frx":6BA6
            Style           =   1  'Graphical
            TabIndex        =   48
            Top             =   1920
            Width           =   1695
         End
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
            Left            =   120
            Picture         =   "AL_Liquidacion2.frx":723D
            Style           =   1  'Graphical
            TabIndex        =   47
            Top             =   1320
            Width           =   1695
         End
         Begin VB.CommandButton btnNuevo 
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
            Picture         =   "AL_Liquidacion2.frx":794D
            Style           =   1  'Graphical
            TabIndex        =   46
            Top             =   720
            Width           =   1695
         End
         Begin VB.Frame FrmRuta 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Datos de las Cargas"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   6390
            Left            =   1920
            TabIndex        =   44
            Top             =   480
            Width           =   4095
            Begin VB.CheckBox ChkBaja 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Mostrar Cargas dadas de Baja"
               Height          =   255
               Left            =   360
               TabIndex        =   9
               Top             =   2160
               Width           =   3135
            End
            Begin VB.TextBox TxtRuta 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   1200
               MaxLength       =   5
               TabIndex        =   1
               Top             =   960
               Width           =   735
            End
            Begin MSComctlLib.ListView LstSurtidos 
               Height          =   3615
               Left            =   120
               TabIndex        =   2
               Top             =   2520
               Width           =   3855
               _ExtentX        =   6800
               _ExtentY        =   6376
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
            Begin MSComCtl2.DTPicker DTPFecha 
               Height          =   375
               Left            =   1200
               TabIndex        =   0
               Top             =   480
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
               Format          =   64749569
               CurrentDate     =   39376
            End
            Begin VB.Label LblSurtidos 
               Alignment       =   2  'Center
               BackColor       =   &H00FFFFFF&
               Caption         =   "No se encontraron Surtidos para la Ruta en la Fecha seleccionada"
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
               TabIndex        =   50
               Top             =   1440
               Visible         =   0   'False
               Width           =   3615
            End
            Begin VB.Label Label1 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Ruta"
               Height          =   255
               Left            =   360
               TabIndex        =   49
               Top             =   960
               Width           =   615
            End
            Begin VB.Label Label2 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Fecha"
               Height          =   255
               Left            =   360
               TabIndex        =   45
               Top             =   480
               Width           =   615
            End
         End
         Begin VB.Frame FrmVendedores 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Asignación de Vendedores a Ruta"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   7215
            Left            =   6120
            TabIndex        =   40
            Top             =   480
            Visible         =   0   'False
            Width           =   6015
            Begin VB.ComboBox cmbPerfil 
               Height          =   360
               Left            =   3840
               Style           =   2  'Dropdown List
               TabIndex        =   7
               Top             =   2880
               Visible         =   0   'False
               Width           =   2055
            End
            Begin VB.TextBox TxtIdVendedor 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   120
               MaxLength       =   5
               TabIndex        =   4
               Top             =   2880
               Visible         =   0   'False
               Width           =   735
            End
            Begin VB.TextBox TxtNombre 
               Height          =   375
               Left            =   960
               TabIndex        =   5
               Top             =   2880
               Visible         =   0   'False
               Width           =   1575
            End
            Begin VB.TextBox TxtNomina 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   2640
               MaxLength       =   8
               TabIndex        =   6
               Top             =   2880
               Visible         =   0   'False
               Width           =   1095
            End
            Begin MSComctlLib.ListView LstVendedores 
               Height          =   3735
               Left            =   120
               TabIndex        =   8
               Top             =   3360
               Visible         =   0   'False
               Width           =   5775
               _ExtentX        =   10186
               _ExtentY        =   6588
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
            Begin MSComctlLib.ListView LstVendedoresAsignados 
               Height          =   1935
               Left            =   120
               TabIndex        =   3
               Top             =   600
               Width           =   5775
               _ExtentX        =   10186
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
            Begin VB.Label LblPerfil 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Perfil"
               Height          =   255
               Left            =   3840
               TabIndex        =   52
               Top             =   2640
               Visible         =   0   'False
               Width           =   615
            End
            Begin VB.Label Label4 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Vendedores Asignados a la Ruta"
               Height          =   240
               Left            =   360
               TabIndex        =   51
               Top             =   360
               Width           =   2850
            End
            Begin VB.Label LblNombre 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Nombre"
               Height          =   255
               Left            =   960
               TabIndex        =   43
               Top             =   2640
               Visible         =   0   'False
               Width           =   1335
            End
            Begin VB.Label LblIdVendedor 
               BackColor       =   &H00FFFFFF&
               Caption         =   "No."
               Height          =   255
               Left            =   120
               TabIndex        =   42
               Top             =   2640
               Visible         =   0   'False
               Width           =   615
            End
            Begin VB.Label LblNomina 
               BackColor       =   &H00FFFFFF&
               Caption         =   "No. Nómina"
               Height          =   255
               Left            =   2640
               TabIndex        =   41
               Top             =   2640
               Visible         =   0   'False
               Width           =   1095
            End
         End
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FFFFFF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Liquidaciones"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   1
         Left            =   9900
         TabIndex        =   38
         Top             =   0
         Width           =   2475
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Devoluciones de Producto"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   4
         Left            =   -70070
         TabIndex        =   26
         Top             =   0
         Width           =   2495
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FFFFFF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Ventas"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   6
         Left            =   -67600
         TabIndex        =   16
         Top             =   0
         Width           =   2500
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Carga de Producto"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   3
         Left            =   -72525
         TabIndex        =   14
         Top             =   0
         Width           =   2470
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Cargas de Rutas"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   0
         Left            =   -75000
         TabIndex        =   11
         Top             =   0
         Width           =   2490
      End
   End
End
Attribute VB_Name = "AL_Liquidacion2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDSurtidos, LstDSurtido, LstDVendedores, LstDVendedoresAsignados
Dim LstDPerfil, LstDDevoluciones, LstDStatusRutas, LstDTipoVenta, LstDFacturas
Dim LstDClientes, IdSucursal, IdCliente
Dim SurtidosPendientes As Boolean, ClasMerma As Long, LstStatusDias
Dim FIni As Date, FFin As Date, UltimoDia As Date, CargaAnt As Double
Dim IdFamiliaRejas As Integer ' , T1, T2

Private Sub btnActualizaVenta_Click()

'On Error GoTo Err_ActualizaFact:

    'valida folio
    If Trim(TxtFolio.Text) = "" Or TxtFolio.Text = "0" Then
        MsgBox "¡ Teclea un Folio de Factura Válido !", vbInformation + vbOKOnly, App.Title
        TxtFolio.SetFocus
        Exit Sub
    End If
    
    StrCmd = "execute sel_Folios " & IdCedis & ", " & LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) & ", " & TxtFolio.Text & ", 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        If Rs.Fields(0) > CLng(TxtFolio.Text) Then
            MsgBox "¡ El Folio de Factura debe ser mayor al Folio Inicial " & Rs.Fields(0) & " !", vbInformation + vbOKOnly, App.Title
            TxtFolio.Text = ""
            TxtFolio.SetFocus
            Exit Sub
        Else
            If Rs.Fields(1) = 0 Then
                TxtRazonSocial.SetFocus
            Else
                MsgBox "¡ El Folio " & TxtFolio.Text & " ya existe !. Teclee otro Folio.", vbInformation + vbOKOnly, App.Title
                TxtFolio.Text = ""
                TxtFolio.SetFocus
                Exit Sub
            End If
        End If
    Else
        MsgBox "¡ Teclea un Folio de Factura Válido !", vbInformation + vbOKOnly, App.Title
        TxtFolio.Text = ""
        TxtFolio.SetFocus
    End If

    'adelante con la factura
    If Trim(TxtSerie.Text) = "" Or Trim(TxtFolio.Text) = "" Or TxtFolio.Text = "0" Then
        MsgBox "¡ Teclee un Folio de Factura válido !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    If IdCliente = 0 Or IdSucursal = 0 Then
        MsgBox "¡ Seleccione un Cliente y una Sucursal a quien se le va a asignar la Factura !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) = 1 Then
        If MsgBox("¿ Estás seguro que deseas generar la Venta de Contado por Diferencia de Inventario ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
       ' verifica q exista el cliente de contado
        StrCmd = "exec sel_ClientesFacturas " & IdCedis & ", 0, '', '', 2"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        
        If RsC.EOF Then
            MsgBox "¡ No se encontró el Cliente de Contado !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        Else
            If RsC.Fields(1) = -1 Then
                MsgBox "¡ No se encontró el Cliente de Contado !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        End If
    End If
    
    StrCmd = "execute up_Ventas " & IdCedis & ", " & IdSurtido & ", " & LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) & ", " & _
            TxtFolio.Text & ", '" & TxtSerie.Text & "', '" & FormatDate(Fecha) & "', " & IdCliente & ", " & IdSucursal & ", " & _
            IIf(LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) = 1, 4, 1)
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    Dim Mensaje
    If LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) = 1 Then
        ' Valida si hay productos con precio = 0
        StrCmd = "execute sel_VentasDetalle " & IdCedis & ", " & IdSurtido & ", " & LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) & ", " & TxtFolio.Text & ", 3"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        Mensaje = ""
        If Rs.State Then
            If Not Rs.EOF Then
                Mensaje = "No se facturaron los siguientes productos porque no tenían precio asignado: " & Chr(13) & Chr(10)
                While Not Rs.EOF
                    Mensaje = Mensaje & Rs.Fields(0) & " - " & Rs.Fields(1) & Chr(13) & Chr(10)
                    Rs.MoveNext
                Wend
            End If
        End If
        
        ' Elimina productos con precio = 0
        StrCmd = "execute up_Ventas " & IdCedis & ", " & IdSurtido & ", " & LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) & ", " & TxtFolio.Text & ", '" & TxtSerie.Text & "', '" & FormatDate(Fecha) & "', " & IdCliente & ", " & IdSucursal & ", 5"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        If Mensaje <> "" Then MsgBox Mensaje, vbInformation + vbOKOnly, App.Title
    End If
    
    'valida kardex antes de ...
'    StrCmd = "exec up_ActualizaKardex " & IdCedis & ", '" & FormatDate(FechaSel) & "', " & IdSurtido & ", 2"
'    If Rs.State Then Rs.Close
'    Rs.Open StrCmd, Cnn
    
    MuestraFacturas
    IdSucursal = 0: IdCliente = 0
        
    With AL_Facturas
        .TxtTipoVenta.Text = LstDTipoVenta(1, cmbTipoVenta.ListIndex - 1)
        .TxtSerie.Text = TxtSerie.Text
        .TxtFolio.Text = TxtFolio.Text

        .TxtCliente.Text = LstDClientes(1, LstClientes.SelectedItem.Index - 1) & " , " & LstDClientes(2, LstClientes.SelectedItem.Index - 1)
        .TxtRFC.Text = LstDClientes(5, LstClientes.SelectedItem.Index - 1)
        .TxtListaPrecios.Text = LstDClientes(8, LstClientes.SelectedItem.Index - 1) & " - " & LstDClientes(9, LstClientes.SelectedItem.Index - 1)
        .TxtSucursal.Text = LstDClientes(3, LstClientes.SelectedItem.Index - 1) & " , " & LstDClientes(4, LstClientes.SelectedItem.Index - 1)
        
        .Left = MenuAlmacen.Left
        .Top = AL_Liquidacion.Top '(al_menu.Height + Liquidacion.Height - .Height) / 2
        .IdTipoVenta = LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1)
        .Folio = TxtFolio.Text
        .IdCliente = LstDClientes(1, LstClientes.SelectedItem.Index - 1)
        .IdSucursal = LstDClientes(10, LstClientes.SelectedItem.Index - 1)
        .RFC = TxtRFC.Text
        .Nombre = LstDClientes(2, LstClientes.SelectedItem.Index - 1)
        .Tel = LstDClientes(6, LstClientes.SelectedItem.Index - 1)
        .Direccion = LstDClientes(7, LstClientes.SelectedItem.Index - 1)

        .MuestraDetalle False
        .MuestraTotales False
        .Show vbModal
    End With
        
        
    CancelaVenta
    btnEliminarVenta.Caption = "&Eliminar"
    btnNuevaVenta.Visible = True: btnActualizaVenta.Visible = False
    
No_Err_ActualizaFact:
    MousePointer = 0
    Exit Sub
    
Err_ActualizaFact:
    MousePointer = 0
    
    CancelaVenta
    btnEliminarVenta.Caption = "&Eliminar"
    btnNuevaVenta.Visible = True: btnActualizaVenta.Visible = False
    
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_ActualizaFact:
End Sub

Private Sub btnAdd_Click()
    TxtMalaD_KeyPress 13
End Sub

Private Sub btnAddC_Click()
    TxtCantidadS_KeyPress 13
End Sub

Private Sub btnAplica_Click()
On Error GoTo Err_AplicaC:

    'If Not ValidaDiaySurtido(IdCedis, 0, IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy"))) Then Exit Sub
    If Not ValidaDiaySurtido(IdCedis, 0, Fecha) Then Exit Sub

    If MsgBox("¿ Está seguro que desea Aplicar la Liquidación del Surtido " & LstSurtidos.SelectedItem & " ?. " & Chr(13) & Chr(10) & "Una vez Aplicada no podrá modificarla. ", vbQuestion + vbYesNo, App.Title) = vbNo Then
        Exit Sub
    End If
    
    MousePointer = 11
    
    'valida kardex antes de ...
    StrCmd = "exec up_ActualizaKardex " & IdCedis & ", '" & FormatDate(FechaSel) & "', " & IdSurtido & ", 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    StrCmd = "execute sel_SurtidosVendedores " & IdCedis & ", " & IdSurtido
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Rs.EOF Then
        MousePointer = 0
        MsgBox "¡ No puedes Aplicar la Liquidación de la Carga, porque no tienes Vendedores asigandos a la Ruta !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    StrCmd = "execute sel_ExistenciaValida " & IdCedis & ", " & IdSurtido & ", 0, 0, 0, 0, 0, 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        If Rs.Fields(0) <> 0 Then
            MousePointer = 0
            MsgBox "¡ No puedes Aplicar la Liquidación de la Carga, porque la ruta todavía tiene existencias !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
    Else
        MousePointer = 0
        MsgBox "¡ No puedes Aplicar la Liquidación de la Carga, porque la ruta todavía tiene existencias !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    StrCmd = "execute up_Surtidos " & IdCedis & ", " & IdSurtido & ", '" & FormatDate(Fecha) & "', " & IdRuta & ", 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MuestraSurtidos IIf(ChkBaja.Value, 1, 2)
    If LstSurtidos.Visible Then LstSurtidos.SetFocus
    LstSurtidos_Click
    
    'DetalleSurtidos False, 1
    
    Status = "C"
    StatusDesc = "Carga Aplicada"

    MousePointer = 0
    MsgBox "¡ Carga Aplicada !", vbInformation + vbOKOnly, App.Title
    
No_Err_AplicaC:
    MousePointer = 0
    Exit Sub
    
Err_AplicaC:
    MousePointer = 0
    MsgBox "¡ Error al AplicaC la Carga !. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_AplicaC:
End Sub

Private Sub btnAplicaC_Click()
''on error GoTo Err_AplicaC:

    If MsgBox("¿ Está seguro que desea Aplicar la Carga ?. " & Chr(13) & Chr(10) & "Una vez Aplicada no podrà modificarla", vbQuestion + vbYesNo, App.Title) = vbNo Then
        Exit Sub
    End If
    
    MousePointer = 11
    StrCmd = "execute up_Surtidos " & IdCedis & ", " & IdSurtido & ", '" & FormatDate(Fecha) & "', " & IdRuta & ", 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    DetalleSurtidos False, 1
    
    Status = "C"
    StatusDesc = "Carga Aplicada"

    MousePointer = 0
    MsgBox "¡ Carga Aplicada !", vbInformation + vbOKOnly, App.Title
    
No_Err_AplicaC:
    MousePointer = 0
    Exit Sub
    
Err_AplicaC:
    MousePointer = 0
    MsgBox "¡ Error al AplicaC la Carga !. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_AplicaC:
End Sub

Private Sub BtnDelete_Click()
    MsgBox "¡ No puedes Eliminar partidas de la Carga que ya ha sido Aplicada !", vbInformation + vbOKOnly, App.Title
End Sub

Private Sub btnDeleteC_Click()
    If Not IsEmpty(LstDSurtido) Then
        If MsgBox("¿ Está seguro que desea eliminar la partida seleccionada ?." & Chr(13) & Chr(10) & Trim(LstDSurtido(1, LstSurtido.SelectedItem.Index - 1)) & " - " & Trim(LstDSurtido(2, LstSurtido.SelectedItem.Index - 1)) & " Surtido: " & LstDSurtido(3, LstSurtido.SelectedItem.Index - 1), vbQuestion + vbYesNo, App.Title) = vbYes Then
            TxtCantidadS_KeyPress 13
            Exit Sub
        End If
    Else
        MsgBox "¡ Selecciona una partida a Eliminar !", vbInformation + vbOKOnly, App.Title
    End If
End Sub

Private Sub btnEliminar_Click()
On Error GoTo Err_Eliminar:

'If Not ValidaDiaySurtido(IdCedis, 0, IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy"))) Then Exit Sub
If Not ValidaDiaySurtido(IdCedis, 0, Fecha) Then Exit Sub

    If IdSurtido = 0 Then
        MsgBox "¡ Seleccione un Carga a Eliminar !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    'If Not ValidaDiaySurtido(IdCedis, IdSurtido, IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy"))) Then Exit Sub
    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    
    If MsgBox("¿ Está seguro que desea eliminar la Carga " & LstSurtidos.SelectedItem & " ?", vbQuestion + vbYesNo, App.Title) = vbNo Then
        Exit Sub
    Else
        If MsgBox("La información se perderá. ¿ Desea continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then
            Exit Sub
        End If
    End If

    MousePointer = 11
    StrCmd = "execute up_Surtidos " & IdCedis & ", " & IdSurtido & ", '" & FormatDate(Fecha) & "', " & IdRuta & ", 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    StrCmd = "execute up_ActualizaKardex " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MuestraSurtidos IIf(ChkBaja.Value, 1, 2)
    MousePointer = 0
    MsgBox "¡ Carga Eliminado !", vbInformation + vbOKOnly, App.Title
    
No_Err_Eliminar:
    MousePointer = 0
    Exit Sub
    
Err_Eliminar:
    MousePointer = 0
    MsgBox "¡ Error al Eliminar la Carga !. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_Eliminar:
End Sub

Private Sub btnEliminarVenta_Click()
On Error GoTo Err_DelFact:

    'If Not ValidaDiaySurtido(IdCedis, IdSurtido, IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy"))) Then Exit Sub
    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub

    If btnEliminarVenta.Caption = "&Cancelar" Then
        CancelaVenta
        btnEliminarVenta.Caption = "&Eliminar"
        btnNuevaVenta.Visible = True: btnActualizaVenta.Visible = False
    Else
        If Not IsEmpty(LstFacturas) Then
            If MsgBox("¿ Está seguro que desea Eliminar la Factura " & LstDFacturas(3, LstFacturas.SelectedItem.Index - 1) & " - " & LstDFacturas(4, LstFacturas.SelectedItem.Index - 1) & " del Cliente " & Chr(13) & Chr(10) & LstDFacturas(7, LstFacturas.SelectedItem.Index - 1) & " por " & FormatCurrency(LstDFacturas(10, LstFacturas.SelectedItem.Index - 1), 2, vbTrue) & " ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
                If MsgBox("La información se perderá. ¿ Desea continuar ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
            MousePointer = 11
                    StrCmd = "execute up_Ventas " & IdCedis & ", " & IdSurtido & ", " & _
                            LstDFacturas(2, LstFacturas.SelectedItem.Index - 1) & ", " & _
                            LstDFacturas(4, LstFacturas.SelectedItem.Index - 1) & ", '', '" & FormatDate(Fecha) & "', 0, 0, 3"
                    If Rs.State Then Rs.Close
                    Rs.Open StrCmd, Cnn
                    
                    'valida kardex antes de ...
                    StrCmd = "exec up_ActualizaKardex " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 2"
                    If Rs.State Then Rs.Close
                    Rs.Open StrCmd, Cnn
            MousePointer = 0
                    MuestraFacturas
                    MsgBox "¡ Factura Eliminada !", vbInformation + vbOKOnly, App.Title
                End If
            End If
        End If
    End If
    
No_Err_DelFact:
    MousePointer = 0
    Exit Sub
    
Err_DelFact:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_DelFact:
    
End Sub

Private Sub btnFactura_Click()
    If Not TxtFolioC.Locked Then 'Obtiene Folio Siguiente
        StrCmd = "execute sel_Folios " & IdCedis & ", 1, 0, 3"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            TxtSerieC.Text = Rs.Fields(0): TxtFolioC.Text = Rs.Fields(1): TxtFolioC.SetFocus
        End If
    Else 'Imprime Factura Global
        With AL_RptFacturaGlobal
            
            If FechaSel = "12:00:00 a.m." Then FechaSel = UltimoDia
            
            .LblFecha.Caption = FechaSel: .LblRFC.Caption = "PAG 840101 GL9"
            .LblNombre.Caption = "VENTAS DE CONTADO": .LblDireccion.Caption = "BLVD. NORTE A ZACATECAS KM 537.8, COL. TROJES DE ALONSO"
            
            StrCmd = "execute sel_VentasContado " & IdCedis & ", '" & FormatDate(FechaSel) & "', 2"
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
            
            If Not RsC.EOF Then
                .object.DataSrc.DataSourceName = Cnn
                .object.DataSrc.Recordset = RsC
            End If
            
            .Printer.Orientation = ddOPortrait
            .Printer.PaperSize = 1
            .Show 1
        End With
    End If
End Sub

Private Sub btnImprimeC_Click()

On Error GoTo Err_ImpC:

    With AL_RptCarga
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
        .LblCedis.Caption = IdCedis & " - " & NomCedis
        .LblDatos.Caption = Format(Fecha, "dd ""de"" MMMM ""de"" yyyy ")
        .LblFolio.Caption = Format(IdSurtido, "0000000")
        .LblStatus.Caption = StatusDesc
        .LblRuta.Caption = IdRuta

        
        StrCmd = "execute sel_SurtidosVendedores " & IdCedis & ", " & IdSurtido
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        If Not Rs.EOF Then
            .object.DataSrc.DataSourceName = Cnn
            .object.DataSrc.Recordset = Rs
        End If
        
        .Printer.Orientation = ddOPortrait
        .Printer.PaperSize = 1
        .Show 1
    End With
    
No_Err_ImpC:
    MousePointer = 0
    Exit Sub
    
Err_ImpC:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_ImpC:
    
End Sub

Private Sub btnImprimeDev_Click()

On Error GoTo Err_ImpDev:

    With AL_RptLiquidacion
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
        .LblCedis.Caption = IdCedis & " - " & NomCedis
        .LblDatos.Caption = Format(Fecha, "dd ""de"" MMMM ""de"" yyyy ")
        .LblFolio.Caption = Format(IdSurtido, "0000000")
        .LblStatus.Caption = StatusDesc
        .LblRuta.Caption = IdRuta

        
        StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 0, 4"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        If Not Rs.EOF Then
            .object.DataSrc.DataSourceName = Cnn
            .object.DataSrc.Recordset = Rs
        End If
        
        .Printer.Orientation = ddOPortrait
        .Printer.PaperSize = 1
        .Show 1
    End With
    
No_Err_ImpDev:
    MousePointer = 0
    Exit Sub
    
Err_ImpDev:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_ImpDev:
    
End Sub

Private Sub btnImprimeLiquidacion_Click()
On Error GoTo Err_ImpLiq:
    
    If IdSurtido = 0 Then
        MsgBox "¡ Seleccione un Carga !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If IsEmpty(LstVendedoresAsignados) Or LstVendedoresAsignados.ListItems.Count = 0 Then
        MsgBox "¡ Captura un Vendedor para la Carga !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
        
    StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 0, 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Rs.EOF Then
        MsgBox "¡ No hay productos asigandos a esta Liquidación !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
        
    With AL_RptLiquidacion
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
        .LblCedis.Caption = IdCedis & " - " & NomCedis
        .LblDatos.Caption = Format(Fecha, "dd ""de"" MMMM ""de"" yyyy ")
        .LblFolio.Caption = Format(IdSurtido, "0000000")
        .LblStatus.Caption = StatusDesc
        .LblRuta.Caption = IdRuta

        
        StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 0, 4"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        If Not Rs.EOF Then
            .object.DataSrc.DataSourceName = Cnn
            .object.DataSrc.Recordset = Rs
        End If
        
        .Printer.Orientation = ddOPortrait
        .Printer.PaperSize = 1
        .Show 1
    End With
    
No_Err_ImpLiq:
    MousePointer = 0
    Exit Sub
    
Err_ImpLiq:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_ImpLiq:
    
End Sub

Private Sub btnImprimirVenta_Click()
    
On Error GoTo Err_ImpFact:

    If IsEmpty(LstFacturas) Or LstFacturas.ListItems.Count <= 0 Then Exit Sub
    
    With AL_RptFactura
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
        AL_Facturas.IdTipoVenta = LstDFacturas(2, LstFacturas.SelectedItem.Index - 1)
        AL_Facturas.Folio = LstDFacturas(4, LstFacturas.SelectedItem.Index - 1)
        
        .LblFolio.Caption = LstDFacturas(4, LstFacturas.SelectedItem.Index - 1)
        .LblFecha.Caption = Format(Fecha, "dd/mm/yyyy")
        .LblRFC.Caption = LstDFacturas(12, LstFacturas.SelectedItem.Index - 1)
        .LblNombre.Caption = LstDFacturas(7, LstFacturas.SelectedItem.Index - 1)
        .LblTel.Caption = LstDFacturas(14, LstFacturas.SelectedItem.Index - 1)
        .LblDireccion.Caption = LstDFacturas(13, LstFacturas.SelectedItem.Index - 1)
        
        .LblSubtotal.Caption = FormatCurrency(LstDFacturas(8, LstFacturas.SelectedItem.Index - 1), 2, vbTrue)
        .LblIva.Caption = FormatCurrency(LstDFacturas(9, LstFacturas.SelectedItem.Index - 1), 2, vbTrue)
        .LblTotal.Caption = FormatCurrency(LstDFacturas(10, LstFacturas.SelectedItem.Index - 1), 2, vbTrue)
        
        AL_Facturas.MuestraDetalle True
        If Not RsC.EOF Then
            .object.DataSrc.DataSourceName = Cnn
            .object.DataSrc.Recordset = RsC
        End If
        
        .Printer.Orientation = ddOPortrait
        .Printer.PaperSize = 1
        .Show 1
    End With
    
No_Err_ImpFact:
    MousePointer = 0
    Exit Sub
    
Err_ImpFact:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_ImpFact:
    
End Sub

Private Sub btnIniciarCerrarDia_Click(Index As Integer)

On Error GoTo Err_ADia:

Dim LstExistenciaDia, LstStatusSurtido
    
    If FechaSel = "12:00:00 a.m." Then FechaSel = UltimoDia
    
    If Index = 0 Then 'ABRE DIA
        
        'valido si el último día está pendiente de cerrar...
        StrCmd = "execute sel_StatusDias " & IdCedis & ", '" & FormatDate(UltimoDia) & "', 3"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If Trim(RsC.Fields(1)) <> "C" Then
            MsgBox "Termine la captura del día " & UltimoDia & " que aún no se ha cerrado.", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
    
        ' Valido si no hay dìas pendientes de capturar...
        If FechaSel - UltimoDia > 1 Then
            If MsgBox("Existen " & FechaSel - UltimoDia - 1 & " días sin trabajar. ¿ Desea continuar ?. " & Chr(13) & Chr(10) & " ¡ Si continúa ya no podrá trabajar con los días anteriores !", vbQuestion + vbYesNo, App.Title) = vbNo Then
                MsgBox "Cierre los días anteriores antes de continuar.", vbInformation + vbOKOnly, App.Title
                Exit Sub
            Else
                If MsgBox("Ya no podrá trabajar con los días anteriores al " & FechaSel & ". ¿ Desea continuar de cualquier manera ?. ", vbQuestion + vbYesNo, App.Title) = vbNo Then
                    MsgBox "Cierre los días anteriores antes de continuar.", vbInformation + vbOKOnly, App.Title
                    Exit Sub
                Else
                    For i = 1 To FechaSel - UltimoDia - 1
                        StrCmd = "execute up_StatusDia " & IdCedis & ", '" & FormatDate(UltimoDia + i) & "', 'C', 'Día Cerrado', '01/01/1900', 3"
                        If Rs.State Then Rs.Close
                        Rs.Open StrCmd, Cnn
                    Next
                End If
            End If
        End If
        
        If MsgBox("Está a punto de abrir el día " & FechaSel & " para la captura. ¿ Desea continuar de cualquier manera ?. ", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        
        ' status del día
        StrCmd = "execute up_StatusDia " & IdCedis & ", '" & FormatDate(FechaSel) & "', '', '', '" & FormatDate(UltimoDia) & "', 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        ' genera status de las rutas
        StrCmd = "execute up_StatusRutas " & IdCedis & ", '" & FormatDate(FechaSel) & "', 0, '', '', 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        HabilitaMonthV
        
    Else
    
        If Not ValidaCierre(IdCedis, FechaSel) Then Exit Sub
        MuestraStatusDia FechaSel
    End If

No_Err_ADia:
    MousePointer = 0
    Exit Sub
    
Err_ADia:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_ADia:

End Sub

Private Sub btnNuevaVenta_Click()

On Error GoTo Err_NuevaFact:
    
    'If Not ValidaDiaySurtido(IdCedis, IdSurtido, IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy"))) Then Exit Sub
    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    IdSucursal = 0: IdCliente = 0

    StrCmd = "execute sel_Ventas " & IdCedis & ", " & IdSurtido & ", 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    If Not Rs.EOF Then
        If Rs.Fields(0) > 0 Then
            CancelaVenta
            btnEliminarVenta.Caption = "&Cancelar"
            btnNuevaVenta.Visible = False: btnActualizaVenta.Visible = True
        Else
            MsgBox "¡ No hay Producto disponible para registrar mas Ventas. Existencias en la Ruta = 0 !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
    End If
    
No_Err_NuevaFact:
    MousePointer = 0
    Exit Sub
    
Err_NuevaFact:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_NuevaFact:
    
End Sub

Private Sub btnNuevo_Click()
On Error GoTo Err_NuevoSurtido:

    'If Not ValidaDiaySurtido(IdCedis, 0, IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy"))) Then Exit Sub
    If Not ValidaDiaySurtido(IdCedis, 0, Fecha) Then Exit Sub
    
    If Trim(TxtRuta.Text) = "" Then Exit Sub
    If IdRuta = 0 Then Exit Sub
    
    MousePointer = 11
    
    StrCmd = "execute sel_SurtidosPendientes " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdRuta
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        MousePointer = 0
        MsgBox "¡ No puedes dar de Alta una Carga Nueva porque la Ruta " & IdRuta & " tiene " & Chr(13) & Chr(10) & " Cargas pendientes en el día " & Format(Fecha, "DDDD dd ""de"" MMMM ""de"" YYYY") & " !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    StrCmd = "execute up_Surtidos " & IdCedis & ", 0, '" & FormatDate(Fecha) & "', " & IdRuta & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    MuestraSurtidos IIf(ChkBaja.Value, 1, 2)
    LstSurtidos_Click
    MousePointer = 0
    
No_Err_NuevoSurtido:
    MousePointer = 0
    Exit Sub
    
Err_NuevoSurtido:
    MousePointer = 0
    MsgBox "Error al Agregar al Vendedor de la Lista. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_NuevoSurtido:

End Sub

Private Sub btnRoute_Click()
On Error GoTo Err_Route:

Dim IPRoute, BDRoute, LCarga, LCargaDetalle, T1, T2

    MousePointer = 11
    StrCmd = "execute up_RouteCarga " & IdCedis & ", " & IdSurtido & ", " & IdRuta & ", 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    If Rs.EOF Then
        MousePointer = 0
        MsgBox "¡ Su Cedis no está configurado para Route !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    Else
        If Rs.Fields(0) <= 0 Then
            MousePointer = 0
            MsgBox "¡ Su Cedis no está configurado para Route !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        Else
            IPRoute = Trim(Rs.Fields(1)): BDRoute = Trim(Rs.Fields(2))
        End If
    End If
    
    If MsgBox("¿ Desea transferir la Carga a Route ?", vbQuestion + vbYesNo, App.Title) = vbNo Then
        MousePointer = 0
        Exit Sub
    End If
    
    StrCmd = "execute up_RouteCarga " & IdCedis & ", " & IdSurtido & ", " & IdRuta & ", 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    If Rs.State Then
        If Not Rs.EOF Then
            MousePointer = 0
            Dim FolioRoute, Cedi
            Cedi = Trim(Rs.Fields(3)): FolioRoute = Trim(Rs.Fields(4))
            
            MsgBox "¡ La Carga " & IdSurtido & " de la Ruta " & IdRuta & " del día " & Fecha & " ya existe en Route !", vbInformation + vbOKOnly, App.Title
            
            If MsgBox("¿ Desea cancelar la Carga que ya se había traspasado a Route de esta ruta en este día ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
                If MsgBox("¿ Está seguro que desea continuar con la cancelación de la Carga ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
                
                    MousePointer = 11
                    T1 = Timer
                    'da de baja en route
                    If Not OpenConn2(IPRoute, BDRoute, "sa", "") Then
                        MousePointer = 0
                        MsgBox "¡ No se pudo establecer conexión con Route !", vbInformation + vbOKOnly, App.Title
                        Exit Sub
                    End If
                    Cnn2.CommandTimeout = 0
                    
                    StrCmd = "execute PDC_Carga '" & Cedi & "', '" & FolioRoute & "', '', '', 0, 0, 0, '', '', '', 3"
                    If Rs2.State Then Rs2.Close
                    Rs2.Open StrCmd, Cnn2
                    
                    'da de baja en PDC
                    StrCmd = "execute up_RouteCarga " & IdCedis & ", " & IdSurtido & ", " & IdRuta & ", 3"
                    If Rs.State Then Rs.Close
                    Rs.Open StrCmd, Cnn
                    
                    T2 = Timer
                    MousePointer = 0
                    MsgBox "¡ La Carga se canceló en Route !. Para volver a Cargar, intente transferir nuevamente a Route. " & Chr(13) & Chr(10) & "Tiempo de ejecución: " & FormatNumber(T2 - T1, 2, vbTrue) & " segundos.", vbInformation + vbOKOnly, App.Title
                    Exit Sub
                Else
                    MousePointer = 0
                    Exit Sub
                End If
            Else
                MousePointer = 0
                Exit Sub
            End If
        End If
    Else
        MousePointer = 0
        MsgBox "¡ No se pudo establecer conexión con Route !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    T1 = Timer
    
    'inserto datos en temporales de PDC
    StrCmd = "execute up_RouteCarga " & IdCedis & ", " & IdSurtido & ", " & IdRuta & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    'Lectura de datos insertados
    LCarga = Empty: LCargaDetalle = Empty
    
    StrCmd = "execute up_RouteCarga " & IdCedis & ", " & IdSurtido & ", " & IdRuta & ", 5"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then LCarga = Rs.GetRows
    
    StrCmd = "execute up_RouteCarga " & IdCedis & ", " & IdSurtido & ", " & IdRuta & ", 6"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then LCargaDetalle = Rs.GetRows
    
    'Conexion a route y transferencia de datos
    If Not OpenConn2(IPRoute, BDRoute, "sa", "") Then
        MousePointer = 0
        MsgBox "¡ No se pudo establecer conexión con Route !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    Cnn2.CommandTimeout = 0
    
    Dim StrIns
    StrIns = ""
    
    For i = 0 To UBound(LCargaDetalle, 2)
        StrIns = StrIns & "insert into tmp_CargaDetalle values (''"
        For j = 4 To UBound(LCargaDetalle, 1)
            StrIns = StrIns & Trim(LCargaDetalle(j, i)) & "'', ''"
        Next
        StrIns = Mid(StrIns, 1, Len(StrIns) - 4) & "); " '& Chr(13) & Chr(10)
    Next
    
    StrCmd = "execute PDC_Carga '" & Trim(LCarga(4, 0)) & "', '" & Trim(LCarga(5, 0)) & "', '" & Trim(LCarga(6, 0)) & "', '" & _
    Trim(LCarga(7, 0)) & "', '" & Trim(LCarga(8, 0)) & "', '" & Trim(LCarga(9, 0)) & "', '" & _
    Trim(LCarga(10, 0)) & "', '" & Trim(LCarga(11, 0)) & "', '" & Trim(LCarga(12, 0)) & "', '" & StrIns & "', 1"
    If Rs2.State Then Rs2.Close
    Rs2.Open StrCmd, Cnn2
    Cnn2.Close
     
    'Actualizo campo de transferido
    StrCmd = "update RouteSurtidos set Transferido = 0 where IdCedis = " & IdCedis & " and IdSurtido = " & IdSurtido & " and IdRuta = " & IdRuta & " and FolioRoute = " & Trim(LCarga(3, 0))
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    T2 = Timer
    MsgBox "¡ La Carga " & IdSurtido & " de la Ruta " & IdRuta & " del día " & Fecha & " se ha traspasdo a Route correctamente !" & Chr(13) & Chr(10) & "Tiempo de ejecución: " & FormatNumber(T2 - T1, 2, vbTrue) & " segundos.", vbInformation + vbOKOnly, App.Title
    
No_Err_Route:
    MousePointer = 0
    Exit Sub

Err_Route:
    MousePointer = 0
    MsgBox "Error al conectar con Route. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_Route:
    
End Sub

Private Sub ChkBaja_Click()
    IdSurtido = 0: Status = ""
    MuestraSurtidos IIf(ChkBaja.Value, 1, 2)
End Sub

Private Sub cmbTipoVenta_Click()
    If Not IsEmpty(LstDTipoVenta) And btnActualizaVenta.Visible And cmbTipoVenta.ListIndex > 0 Then
        StrCmd = "execute sel_Folios " & IdCedis & ", " & LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) & ", 0, 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        If LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) = 1 Then
            StrCmd = "execute sel_ClientesFacturas " & IdCedis & ", 0, '', '', 2"
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
            If Not RsC.EOF Then
                TxtIdCliente.Text = RsC.Fields(0): LstClientes_Click
            Else
                TxtIdCliente.Text = "9999": LstClientes_Click
            End If
            TxtRFC.Locked = True: TxtIdCliente.Locked = True: TxtRazonSocial.Locked = True
        Else
            TxtRFC.Locked = False: TxtIdCliente.Locked = False: TxtRazonSocial.Locked = False
        End If
        
        If Not Rs.EOF Then
            TxtSerie.Text = Rs.Fields(0): TxtFolio.Text = Rs.Fields(1): TxtFolio.SetFocus
        End If
    End If
End Sub

Private Sub Command1_Click()
    
    StrCmd = "execute sel_ComisionesLiquidacion " & IdCedis & ", " & IdSurtido & ", '" & FormatDate(Fecha) & "', '" & FormatDate(Fecha) & "'"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn

    With AL_RptComisionesLiquidacion
        .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
        .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
        .Show 1
    End With

End Sub

Private Sub DTPFecha_Change()
    IdSurtido = 0: Status = ""
    If DTPFecha.Value > Date Then
        DTPFecha.Value = Date
        Exit Sub
    End If
    'Fecha = IIf(BIdioma = "us_english", Format(DTPFecha.Value, "mm/dd/yyyy"), Format(DTPFecha.Value, "dd/mm/yyyy")): Mes = Month(DTPFecha.Value): Agno = Year(DTPFecha.Value)
    Fecha = DTPFecha.Value: Mes = Month(DTPFecha.Value): Agno = Year(DTPFecha.Value)
End Sub

Private Sub DTPFecha_Validate(Cancel As Boolean)
    'Fecha = IIf(BIdioma = "us_english", Format(DTPFecha.Value, "mm/dd/yyyy"), Format(DTPFecha.Value, "dd/mm/yyyy")): Mes = Month(DTPFecha.Value): Agno = Year(DTPFecha.Value)
    Fecha = DTPFecha.Value: Mes = Month(DTPFecha.Value): Agno = Year(DTPFecha.Value)
End Sub

Private Sub DTPFechaSel_Change()
    DTPFechaSel.Value = MonthV.Value
End Sub

Private Sub Form_Activate()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, "ITAPDC", "itapdc"
    AL_ProductosBusqueda.Hide
End Sub

Private Sub Form_Load()
    If Not Cnn.State Then OpenConn Server, Db, "ITAPDC", "itapdc"
    SSTab.Tab = 4
    SSTab_Click 4
    DTPFecha.Value = Date
    LlenaCombo
End Sub

Private Sub LstClientes_Click()
On Error Resume Next
    If Not IsEmpty(LstDClientes) And LstClientes.ListItems.Count > 0 Then
    
        'TxtIdCliente.Text = Trim(LstClientes.SelectedItem)
        IdCliente = Trim(LstClientes.SelectedItem)
        IdSucursal = LstDClientes(10, LstClientes.SelectedItem.Index - 1)
        LblCliente.Caption = LstClientes.SelectedItem & " , " & LstClientes.SelectedItem.ListSubItems(1).Text & Chr(13) & Chr(10) & LstClientes.SelectedItem.ListSubItems(2).Text & " , " & LstClientes.SelectedItem.ListSubItems(3).Text
    End If
End Sub

Private Sub LstFacturas_Click()
On Error Resume Next
    If Not IsEmpty(LstDFacturas) Or LstFacturas.ListItems.Count > 0 Then
        If btnActualizaVenta.Visible = True Then btnActualizaVenta.Visible = False: btnNuevaVenta.Visible = True: btnEliminarVenta.Caption = "&Eliminar": CancelaVenta
        
        TxtSerie.Text = LstDFacturas(3, LstFacturas.SelectedItem.Index - 1)
        TxtFolio.Text = LstDFacturas(4, LstFacturas.SelectedItem.Index - 1)
        cmbTipoVenta.ListIndex = SearchInList(LstDTipoVenta, LstDFacturas(2, LstFacturas.SelectedItem.Index - 1), 0)
        TxtSubtotal.Text = FormatCurrency(LstDFacturas(8, LstFacturas.SelectedItem.Index - 1), 2, vbTrue)
        TxtIva.Text = FormatCurrency(LstDFacturas(9, LstFacturas.SelectedItem.Index - 1), 2, vbTrue)
        TxtTotal.Text = FormatCurrency(LstDFacturas(10, LstFacturas.SelectedItem.Index - 1), 2, vbTrue)
        
        TxtIdCliente.Text = LstDFacturas(6, LstFacturas.SelectedItem.Index - 1): TxtRFC.Text = "": TxtRazonSocial.Text = ""
        TxtRFC.Text = Trim(LstDFacturas(12, LstFacturas.SelectedItem.Index - 1))
        LblCliente.Caption = LstDFacturas(6, LstFacturas.SelectedItem.Index - 1) & " , " & LstDFacturas(7, LstFacturas.SelectedItem.Index - 1) & Chr(13) & Chr(10) & LstDFacturas(11, LstFacturas.SelectedItem.Index - 1) & " , " & LstDFacturas(12, LstFacturas.SelectedItem.Index - 1)
    End If
End Sub

Private Sub LstFacturas_DblClick()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, "ITAPDC", "itapdc"
    
    With AL_Facturas
        .TxtTipoVenta.Text = LstDFacturas(5, LstFacturas.SelectedItem.Index - 1)
        .TxtSerie.Text = LstDFacturas(3, LstFacturas.SelectedItem.Index - 1)
        .TxtFolio.Text = LstDFacturas(4, LstFacturas.SelectedItem.Index - 1)
        
        .TxtCliente.Text = LstDFacturas(6, LstFacturas.SelectedItem.Index - 1) & " - " & LstDFacturas(7, LstFacturas.SelectedItem.Index - 1)
        .TxtRFC.Text = LstDFacturas(12, LstFacturas.SelectedItem.Index - 1)
        .TxtListaPrecios.Text = LstDFacturas(15, LstFacturas.SelectedItem.Index - 1) & " - " & LstDFacturas(16, LstFacturas.SelectedItem.Index - 1)
        
        .Left = MenuAlmacen.Left
        .Top = AL_Liquidacion.Top
        .IdTipoVenta = LstDFacturas(2, LstFacturas.SelectedItem.Index - 1)
        .Folio = LstDFacturas(4, LstFacturas.SelectedItem.Index - 1)
        .IdCliente = LstDClientes(1, LstClientes.SelectedItem.Index - 1)
        .RFC = LstDFacturas(12, LstFacturas.SelectedItem.Index - 1)
        .Nombre = LstDFacturas(7, LstFacturas.SelectedItem.Index - 1)
        .Tel = LstDFacturas(14, LstFacturas.SelectedItem.Index - 1)
        .Direccion = LstDFacturas(13, LstFacturas.SelectedItem.Index - 1)
        
        .MuestraDetalle False
        .MuestraTotales False
        .Show vbModal
    End With
End Sub

Private Sub LstFacturas_KeyDown(KeyCode As Integer, Shift As Integer)
    LstFacturas_Click
End Sub

Private Sub LstFacturas_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 Then
        LstFacturas_DblClick
    End If
End Sub

Private Sub LstFacturas_KeyUp(KeyCode As Integer, Shift As Integer)
    LstFacturas_Click
End Sub

Private Sub LstSurtidos_Click()
On Error GoTo Err_Carga:
    
    If IsEmpty(LstDSurtidos) Then Exit Sub
    
    IdSurtido = CLng(LstSurtidos.SelectedItem)
    Status = LstDSurtidos(3, LstSurtidos.SelectedItem.Index - 1)
    StatusDesc = LstDSurtidos(2, LstSurtidos.SelectedItem.Index - 1)
    LstSurtidos_DblClick
    
No_Err_Carga:
    Exit Sub
    
Err_Carga:
    IdSurtido = 0
    Status = ""
    GoTo No_Err_Carga:
End Sub

Private Sub LstSurtidos_DblClick()

    If IsEmpty(LstDSurtidos) Then Exit Sub
    
    IdSurtido = CLng(LstSurtidos.SelectedItem)
    Status = LstDSurtidos(3, LstSurtidos.SelectedItem.Index - 1)
    StatusDesc = LstDSurtidos(2, LstSurtidos.SelectedItem.Index - 1)
    
    StrCmd = "execute sel_SurtidosVendedores " & IdCedis & ", " & IdSurtido
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    'habilita búsqueda de vendedores
    HabBusqueda True
    LstDVendedoresAsignados = GetDataLVL(Rs, LstVendedoresAsignados, 3, 5, "0|0|0")
End Sub

Private Sub LstSurtidos_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 Or KeyAscii = 32 Then LstSurtidos_DblClick
End Sub

Private Sub LstVendedores_DblClick()

On Error GoTo Err_AgregaV:
    If IsEmpty(LstDVendedores) Or LstVendedores.ListItems.Count = 0 Then Exit Sub

    If Status <> "P" Then
        MsgBox "¡ La Carga " & LstSurtidos.SelectedItem & " no se puede modificar porque ya está Aplicado o dado de Baja !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If MsgBox("¿ Desea Agregar al Vendedor " & LstVendedores.SelectedItem.ListSubItems(1) & " de la Ruta " & IdRuta & " ?", vbQuestion + vbYesNo, App.Title) = vbNo Then
        Exit Sub
    End If
    If cmbPerfil.ListIndex = 0 Then
        MsgBox "¡ Seleccione un Perfil o Rol del Vendedor !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    MousePointer = 11
    StrCmd = "execute up_SurtidosVendedores " & IdCedis & ", " & IdSurtido & ", '" & FormatDate(Fecha) & "', " & CLng(LstVendedores.SelectedItem) & ", " & cmbPerfil.ItemData(cmbPerfil.ListIndex) & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstSurtidos_DblClick
    BuscaVendedores
    MousePointer = 0
    
No_Err_AgregaV:
    MousePointer = 0
    Exit Sub

Err_AgregaV:
    MousePointer = 0
    MsgBox "Error al Agregar al Vendedor de la Lista. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_AgregaV:
    
End Sub

Private Sub LstVendedores_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 Then LstVendedores_DblClick
End Sub

Private Sub LstVendedoresAsignados_DblClick()

On Error GoTo Err_QuitaV:

    If IsEmpty(LstDVendedoresAsignados) Or LstVendedoresAsignados.ListItems.Count = 0 Then Exit Sub

    If Status <> "P" Then
        MsgBox "¡ La Carga " & LstSurtidos.SelectedItem & " no se puede modificar porque ya está Aplicado o dado de Baja !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    If MsgBox("¿ Desea Quitar al Vendedor " & LstVendedoresAsignados.SelectedItem.ListSubItems(2) & " de la Ruta " & IdRuta & " ?", vbQuestion + vbYesNo, App.Title) = vbNo Then
        Exit Sub
    End If

    MousePointer = 11
    StrCmd = "execute up_SurtidosVendedores " & IdCedis & ", " & IdSurtido & ", '" & FormatDate(Fecha) & "', " & CLng(LstVendedoresAsignados.SelectedItem.ListSubItems(1)) & ", " & cmbPerfil.ItemData(cmbPerfil.ListIndex) & ", 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstSurtidos_DblClick
    BuscaVendedores
    MousePointer = 0
    
No_Err_QuitaV:
    MousePointer = 0
    Exit Sub

Err_QuitaV:
    MousePointer = 0
    MsgBox "Error al Quitar al Vendedor de la Lista. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_QuitaV:
    
End Sub

Private Sub SSTab_Click(PreviousTab As Integer)
    
    If SSTab.Tab >= 1 And SSTab.Tab <= 3 And IdSurtido = 0 Then
        MsgBox "¡ Seleccione un Carga !", vbInformation + vbOKOnly, App.Title
        SSTab.Tab = 0
        Exit Sub
    End If
    
    If SSTab.Tab >= 1 And SSTab.Tab <= 3 And (IsEmpty(LstVendedoresAsignados) Or LstVendedoresAsignados.ListItems.Count = 0) Then
        MsgBox "¡ Captura un Vendedor para la Carga !", vbInformation + vbOKOnly, App.Title
        SSTab.Tab = 0
        Exit Sub
    End If
    
    If SSTab.Tab > 0 And SSTab.Tab <= 3 Then LblSurtido(SSTab.Tab - 1).Caption = "Carga " & Format(IdSurtido, "0000000") & " - Ruta " & IdRuta & " - " & Format(Fecha, "DDDD dd ""de"" MMMM ""de"" YYYY")
    Select Case SSTab.Tab
        Case 0:
                If Not ValidaModulo("LIQCARGA", True) Then
                    SSTab.Tab = 4
                    Exit Sub
                End If
                If FechaSel = "12:00:00 a.m." Then FechaSel = UltimoDia
                If PreviousTab = 4 Then DTPFecha.Value = FechaSel
                TxtRuta.SetFocus
                LlenaCombo
        Case 1:
                If Not ValidaModulo("LIQCARGAP", True) Then
                    SSTab.Tab = 4
                    Exit Sub
                End If
                DetalleSurtidos False, 1
                TxtIdProdS.SetFocus
        Case 2:
                If Not ValidaModulo("LIQDEV", True) Then
                    SSTab.Tab = 4
                    Exit Sub
                End If
                ClasMerma = ClasificaMerma
                DetalleSurtidos False, 2
                TxtIdProdD.SetFocus
        Case 3:
                If Not ValidaModulo("LIQVTA", True) Then
                    SSTab.Tab = 4
                    Exit Sub
                End If
                LlenaComboVentas
                MuestraFacturas
        Case 4:
                If Not ValidaModulo("LIQLIQ", True) Then
                    Unload Me
                End If
                DTPFechaSel.Value = Date
                HabilitaMonthV
    End Select
End Sub

Private Sub TxtBuenaD_GotFocus()
    SelText TxtBuenaD
End Sub

Private Sub TxtBuenaD_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 Then
        If Dec Then
            TxtBuenaD.Text = itFlotante(TxtBuenaD.Text)
            'If Trim(TxtBuenaD.Text) = "0" Then Exit Sub
        End If
        
        If IdFamiliaRejas <> 0 Then
            ActualizaSurtido
            DetalleSurtidos False, 2
            TxtIdProdD.Text = ""
            TxtIdProdD.SetFocus
            Exit Sub
        End If
        
        If ValFaltante(TxtBuenaD) Then
            TxtMalaD.SetFocus
            Exit Sub
        Else
            Exit Sub
        End If
    End If
    If Dec Then
        KeyAscii = itDecimal(KeyAscii)
    Else
        KeyAscii = itEntero(KeyAscii)
    End If
End Sub

Private Sub TxtBuenaD_Validate(Cancel As Boolean)
    TxtBuenaD_KeyPress 13
End Sub

Private Sub TxtCantidadS_GotFocus()
    SelText TxtCantidadS
End Sub

Private Sub TxtCantidadS_KeyPress(KeyAscii As Integer)
    If KeyAscii = "13" Then
'        If Status <> "P" Then
'            MsgBox "¡ La Carga ha sido Aplicada. Ya no se puede modificar !", vbInformation + vbOKOnly, App.Title
'            Exit Sub
'        End If
        ActualizaCarga
        TxtIdProdS.SetFocus
    End If
    If Dec Then
        KeyAscii = itDecimal(KeyAscii)
    Else
        KeyAscii = itEntero(KeyAscii)
    End If
End Sub

Private Sub TxtCantidadS_Validate(Cancel As Boolean)
    If Dec Then
        TxtCantidadS.Text = itFlotante(TxtCantidadS.Text)
        If Trim(TxtCantidadS.Text) = "0" Then Exit Sub
    End If
End Sub

Private Sub TxtDescD_Change()
On Error Resume Next
    AL_ProductosBusqueda.Hide
End Sub

Private Sub TxtDescD_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 And Trim(TxtDescD.Text) <> "" Then
        With AL_ProductosBusqueda
            .Opc = 2: .Left = 3500: .Top = 3700
            .FiltraProductos CStr(Trim(TxtDescD.Text))
            If Not .Visible Then .Show 0
        End With
    Else
        KeyAscii = itString(KeyAscii)
    End If
End Sub

Private Sub TxtDescD_Validate(Cancel As Boolean)
On Error Resume Next
    AL_ProductosBusqueda.Hide
End Sub

Private Sub TxtDescS_Change()
On Error Resume Next
    AL_ProductosBusqueda.Hide
End Sub

Private Sub TxtDescS_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 And Trim(TxtDescS.Text) <> "" Then
        With AL_ProductosBusqueda
            .Opc = 1: .Left = 4000: .Top = 3700
            .FiltraProductos CStr(Trim(TxtDescS.Text))
            If Not .Visible Then .Show 0
        End With
    Else
        KeyAscii = itString(KeyAscii)
    End If
End Sub

Private Sub TxtDescS_Validate(Cancel As Boolean)
On Error Resume Next
    AL_ProductosBusqueda.Hide
End Sub

Private Sub TxtFolio_GotFocus()
    SelText TxtFolio
End Sub

Private Sub TxtFolio_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 Then TxtFolio_Validate False
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtFolio_Validate(Cancel As Boolean)
    If Trim(TxtFolio.Text) = "" Or TxtFolio.Text = "0" Then
        MsgBox "¡ Teclea un Folio de Factura Válido !", vbInformation + vbOKOnly, App.Title
        TxtFolio.SetFocus
        Exit Sub
    End If
    
    StrCmd = "execute sel_Folios " & IdCedis & ", " & LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) & ", " & TxtFolio.Text & ", 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        If Rs.Fields(0) > CLng(TxtFolio.Text) Then
            MsgBox "¡ El Folio de Factura debe ser mayor al Folio Inicial " & Rs.Fields(0) & " !", vbInformation + vbOKOnly, App.Title
            TxtFolio.Text = ""
            TxtFolio.SetFocus
            Exit Sub
        Else
            If Rs.Fields(1) = 0 Then
                TxtRazonSocial.SetFocus
            Else
                MsgBox "¡ El Folio " & TxtFolio.Text & " ya existe !. Teclee otro Folio.", vbInformation + vbOKOnly, App.Title
                TxtFolio.Text = ""
                TxtFolio.SetFocus
                Exit Sub
            End If
        End If
    Else
        MsgBox "¡ Teclea un Folio de Factura Válido !", vbInformation + vbOKOnly, App.Title
        TxtFolio.Text = ""
        TxtFolio.SetFocus
    End If
End Sub

Private Sub TxtFolioC_GotFocus()
    SelText TxtFolioC
End Sub

Private Sub TxtFolioC_KeyPress(KeyAscii As Integer)
    If TxtFolioC.Locked Then Exit Sub
    If KeyAscii = 13 Then FolioCValidate
    KeyAscii = itEntero(KeyAscii)
End Sub

Sub FolioCValidate()

    If FechaSel = "12:00:00 a.m." Then FechaSel = UltimoDia
    
    If MsgBox("¿ Está seguro que desea generar la Factura de Contado del Día " & FechaSel & " ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
        If MsgBox("Una vez generada la Factura, ya no podrá modificar el Folio. ¿ Desea continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    Else
        Exit Sub
    End If

    If Trim(TxtFolioC.Text) = "" Or TxtFolioC.Text = "0" Then
        MsgBox "¡ Teclea un Folio de Factura Válido !", vbInformation + vbOKOnly, App.Title
        TxtFolioC.SetFocus
        Exit Sub
    End If
    
    StrCmd = "execute sel_Folios " & IdCedis & ", 1, " & TxtFolioC.Text & ", 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        If Rs.Fields(0) > CLng(TxtFolioC.Text) Then
            MsgBox "¡ El Folio de Factura debe ser mayor al Folio Inicial " & Rs.Fields(0) & " !", vbInformation + vbOKOnly, App.Title
            TxtFolioC.SetFocus
            Exit Sub
        Else
            If Rs.Fields(1) = 0 Then
                TxtRazonSocial.SetFocus
            Else
                MsgBox "¡ El Folio " & TxtFolioC.Text & " ya existe !. Teclee otro Folio.", vbInformation + vbOKOnly, App.Title
                TxtFolioC.SetFocus
                Exit Sub
            End If
        End If
    Else
        MsgBox "¡ Teclea un Folio de Factura Válido !", vbInformation + vbOKOnly, App.Title
        TxtFolioC.SetFocus
    End If
    
    'Inserta Registro de Factura...
    StrCmd = "execute up_VentasContado " & IdCedis & ", '" & FormatDate(FechaSel) & "', " & TxtFolioC.Text & ", '" & TxtSerieC.Text & "',  '', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MuestraStatusDia FechaSel
    MsgBox "¡ Factura Registrada !", vbInformation + vbOKOnly, App.Title
    'MsgBox "Inserta Registro de Factura..."
End Sub

Private Sub TxtIdCliente_Change()
    FiltraClientes
End Sub

Private Sub TxtIdCliente_GotFocus()
    SelText TxtIdCliente
End Sub

Private Sub TxtIdCliente_KeyPress(KeyAscii As Integer)
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtIdProdD_Change()
    TxtDescD.Text = "": TxtVentaD.Text = "0": TxtCargaD.Text = "0": TxtBuenaD.Text = "0"
    TxtObsequiosD.Text = "0": TxtMalaD.Text = "0": TxtFaltanteD.Text = "0"
End Sub

Private Sub TxtIdProdD_GotFocus()
    SelText TxtIdProdD
End Sub

Public Sub TxtIdProdD_KeyPress(KeyAscii As Integer)
    If Trim(TxtIdProdD.Text) = "0" Then
        Forma = 5: ProductosBusqueda.Show vbModal
    End If
    If KeyAscii = 13 Then
        TxtIdProdD_Validate False
        TxtBuenaD.SetFocus
        Exit Sub
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtIdProdD_Validate(Cancel As Boolean)
    ValProdDev
End Sub

Private Sub TxtIdProdS_Change()
    TxtDescS.Text = "": TxtCantidadS.Text = 0: TxtExistencias.Text = 0
End Sub

Private Sub TxtIdProdS_GotFocus()
    SelText TxtIdProdS
End Sub

Public Sub TxtIdProdS_KeyPress(KeyAscii As Integer)
    If Trim(TxtIdProdS.Text) = "0" Then
        Forma = 4: ProductosBusqueda.Show vbModal
    End If
    If KeyAscii = "13" Then
        TxtIdProdS_Validate False
        TxtCantidadS.SetFocus
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtIdProdS_Validate(Cancel As Boolean)
    ValProducto
End Sub

Private Sub TxtIdVendedor_Change()
    BuscaVendedores
End Sub

Private Sub TxtIdVendedor_GotFocus()
    SelText TxtIdVendedor
End Sub

Private Sub TxtIdVendedor_KeyPress(KeyAscii As Integer)
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtMalaD_GotFocus()
    SelText TxtMalaD
End Sub

Public Sub TxtMalaD_KeyPress(KeyAscii As Integer)
On Error Resume Next
           
    If KeyAscii = 13 Then
    If Dec Then
        TxtMalaD.Text = itFlotante(TxtMalaD.Text)
    End If
    
'    If Not ValidaDiaySurtido(IdCedis, IdSurtido, IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy"))) Then Exit Sub
    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    
    If Trim(TxtIdProdD.Text) = "" Or TxtIdProdD.Text = "0" Then
        TxtIdProdD.SetFocus
        Exit Sub
    End If
        
        If TxtMalaD.Text = "0" Then
            StrCmd = "execute sel_SurtidosMerma " & IdCedis & ", " & IdSurtido & ", " & CLng(TxtIdProdD.Text) & ", 2"
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
            If RsC.Fields(0) > 0 Then
                If MsgBox("Ya existe una Devolución Mala registrada. ¿ Desea Eliminarla ?.", vbQuestion + vbYesNo, App.Title) = vbYes Then
                    StrCmd = "execute up_SurtidosMerma " & IdCedis & ", " & IdSurtido & ", " & CLng(Liquidacion.TxtIdProdD.Text) & ", 0, 0, 3"
                    If RsC.State Then RsC.Close
                    RsC.Open StrCmd, Cnn
                Else
                    TxtMalaD.Text = RsC.Fields(0)
                End If
            End If
            
            TxtObsequiosD.SetFocus
            TxtObsequiosD.SetFocus
            Exit Sub
        End If
    
        If ValFaltante(TxtMalaD) Then
            If ClasMerma > 1 Then
                With AL_Merma
                    .TxtTotal.Text = TxtMalaD.Text
                    .CalculaFaltante
                    .Show vbModal
                End With
            End If
            TxtObsequiosD.SetFocus
            Exit Sub
        Else
            Exit Sub
        End If
    End If
    If Dec Then
        KeyAscii = itDecimal(KeyAscii)
    Else
        KeyAscii = itEntero(KeyAscii)
    End If
End Sub

Private Sub TxtMalaD_Validate(Cancel As Boolean)
    TxtMalaD_KeyPress 13
End Sub

Private Sub TxtNombre_Change()
    BuscaVendedores
End Sub

Private Sub TxtNombre_GotFocus()
    SelText TxtNombre
End Sub

Private Sub TxtNombre_KeyPress(KeyAscii As Integer)
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtNomina_Change()
    BuscaVendedores
End Sub

Private Sub TxtNomina_GotFocus()
    SelText TxtNomina
End Sub

Private Sub TxtNomina_KeyPress(KeyAscii As Integer)
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtObsequiosD_GotFocus()
    SelText TxtObsequiosD
End Sub

Private Sub TxtObsequiosD_KeyPress(KeyAscii As Integer)

On Error Resume Next

    If KeyAscii = 13 Then
        'If Not ValidaDiaySurtido(IdCedis, IdSurtido, IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy"))) Then Exit Sub
        If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
        
        If Dec Then
            TxtObsequiosD.Text = itFlotante(TxtObsequiosD.Text)
        End If
        If ValFaltante(TxtObsequiosD) Then
            ActualizaSurtido
            DetalleSurtidos False, 2
            TxtIdProdD.Text = ""
            TxtIdProdD.SetFocus
            Exit Sub
        Else
            Exit Sub
        End If
    End If
    If Dec Then
        KeyAscii = itDecimal(KeyAscii)
    Else
        KeyAscii = itEntero(KeyAscii)
    End If
End Sub

Private Sub TxtObsequiosD_Validate(Cancel As Boolean)
    If Dec Then
        TxtObsequiosD.Text = itFlotante(TxtObsequiosD.Text)
    End If
    If ValFaltante(TxtObsequiosD) Then
        Exit Sub
    End If
End Sub

Private Sub TxtRazonSocial_Change()
    TxtIdCliente.Text = ""
    FiltraClientes
End Sub

Private Sub TxtRazonSocial_GotFocus()
    SelText TxtRazonSocial
End Sub

Private Sub TxtRazonSocial_KeyPress(KeyAscii As Integer)
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtRFC_Change()
    FiltraClientes
End Sub

Private Sub TxtRFC_GotFocus()
    SelText TxtRFC
End Sub

Private Sub TxtRFC_KeyPress(KeyAscii As Integer)
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtRuta_Change()
    LimpiaListas
    HabBusqueda False
    IdSurtido = 0: Status = ""
    If Trim(TxtRuta.Text) = "" Then
        IdRuta = 0
    Else
        IdRuta = CLng(TxtRuta.Text)
    End If
End Sub

Private Sub TxtRuta_GotFocus()
    SelText TxtRuta
End Sub

Private Sub TxtRuta_KeyPress(KeyAscii As Integer)
    If KeyAscii = 13 Then
        TxtRuta_Validate False
        Exit Sub
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtRuta_Validate(Cancel As Boolean)
    IdRuta = IIf(Trim(TxtRuta.Text) = "", 0, Trim(TxtRuta.Text))
    If Not ValidaRuta Then
        LblSurtidos.Caption = "La Ruta " & TxtRuta.Text & " no existe"
        LblSurtidos.Visible = True
        LimpiaListas
        MsgBox "¡ La Ruta " & IdRuta & " no existe!.", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    MuestraSurtidos IIf(ChkBaja.Value, 1, 2)
    If LstSurtidos.Visible Then LstSurtidos.SetFocus
    LstSurtidos_Click
End Sub

Sub MuestraSurtidos(Opc As Integer)
    'Fecha = IIf(BIdioma = "us_english", Format(DTPFecha.Value, "mm/dd/yyyy"), Format(DTPFecha.Value, "dd/mm/yyyy"))
    Fecha = DTPFecha.Value
    
    StrCmd = "execute sel_Surtidos " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdRuta & ", " & Opc
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Rs.EOF Then LstDSurtidos = Empty
    
    LblSurtidos.Visible = IIf(Rs.EOF, True, False)
    LblSurtidos.Caption = IIf(Rs.EOF, "No se encontraron Cargas para la Ruta en la Fecha seleccionada", "")
    
    LstSurtidos.Visible = IIf(Rs.EOF, False, True)
    FrmVendedores.Visible = IIf(Rs.EOF, False, True)
    LstDSurtidos = GetDataLVL(Rs, LstSurtidos, 1, 2, "6|0")
End Sub

Function ValidaRuta() As Boolean
    ValidaRuta = False
    StrCmd = "execute sel_ExisteRuta " & IdCedis & ", " & IdRuta
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    ValidaRuta = IIf(Not Rs.EOF, True, False)
End Function

Sub BuscaVendedores()
    StrCmd = "execute sel_SurtidosNotInVendedores " & IdCedis & ", '" & FormatDate(Fecha) & "', '" & Trim(TxtIdVendedor.Text) & "', '" & Trim(TxtNombre.Text) & "', '" & Trim(TxtNomina.Text) & "'"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDVendedores = GetDataLVL(Rs, LstVendedores, 0, 2, "0|0|0")
End Sub

Sub LimpiaListas()
    LstSurtidos.ListItems.Clear
    'LstSurtidos.Visible = False: FrmVendedores.Visible = False
    LstVendedoresAsignados.ListItems.Clear
    LstVendedores.ListItems.Clear
End Sub

Sub HabBusqueda(Val As Boolean)
    TxtIdVendedor.Visible = Val: TxtNombre.Visible = Val: TxtNomina.Visible = Val: LstVendedores.Visible = Val
    LblIdVendedor.Visible = Val: LblNombre.Visible = Val: LblNomina.Visible = Val
    LblPerfil.Visible = Val: cmbPerfil.Visible = Val
End Sub

Sub LlenaCombo()
    StrCmd = "execute sel_TipoVendedor "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDPerfil = GetDataCBL(Rs, cmbPerfil, "Seleccione un Perfil", "No existen Perfiles de Vendedor")
End Sub

Private Sub ValProducto()
    CargaAnt = 0
    If Trim(TxtIdProdS.Text) <> "" Then
        StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", " & TxtIdProdS.Text & ", 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
       
        If Not Rs.EOF Then
            'valida el status del producto
            If Trim(UCase(Rs.Fields(5))) <> "A" Then
                MsgBox "¡ El Producto " & TxtIdProdS.Text & " está dado de Baja !", vbInformation + vbOKOnly, App.Title
                TxtDescS.Text = "¡ Producto dado de Baja !": TxtCantidadS.Text = 0: TxtExistencias.Text = 0
                TxtCantidadS.SetFocus
                Exit Sub
            End If
        
            TxtDescS.Text = UCase(Rs.Fields(1))
            TxtCantidadS.Text = Rs.Fields(2)
            CargaAnt = Rs.Fields(2)
            TxtExistencias.Text = FormatNumber(Rs.Fields(3), 3, vbTrue)
            Dec = IIf(Rs.Fields(4) = 1, True, False)
        Else
            MsgBox "¡ El Producto " & TxtIdProdS.Text & " no existe !", vbInformation + vbOKOnly, App.Title
            TxtDescS.Text = "¡ Producto no econtrado !": TxtCantidadS.Text = 0: TxtExistencias.Text = 0
        End If
    Else
        TxtDescS.Text = "": TxtCantidadS.Text = 0: TxtExistencias.Text = 0
    End If
    TxtCantidadS.SetFocus
End Sub

Sub DetalleSurtidos(Rep As Boolean, Opc As Integer)
    StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 0, " & IIf(Opc = 1, 6, 2)
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    If Opc = 1 And Not Rep Then LstDSurtido = GetDataLVL(Rs, LstSurtido, 1, 4, "1|0|9|3") '|3|8|3")
    If Opc = 2 And Not Rep Then
        LstDDevoluciones = GetDataLVL(Rs, LstDevoluciones, 1, 8, "1|0|9|9|9|9|9|9")
        StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 0, 7"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            LblCarga.Caption = FormatNumber(Rs.Fields(0), 3, vbTrue)
            LblDevBuena.Caption = FormatNumber(Rs.Fields(1), 3, vbTrue)
            LblDevMala.Caption = FormatNumber(Rs.Fields(2), 3, vbTrue)
            LblObsequios.Caption = FormatNumber(Rs.Fields(3), 3, vbTrue)
            LblVentas.Caption = FormatNumber(Rs.Fields(4), 3, vbTrue)
            LblExistencias.Caption = FormatNumber(Rs.Fields(5), 3, vbTrue)
        End If
    End If
End Sub

Sub ActualizaCarga()

On Error GoTo Err_ActCarga:
   
    If Dec Then
        TxtCantidadS.Text = itFlotante(TxtCantidadS.Text)
        If Trim(TxtCantidadS.Text) = "0" Then Exit Sub
    End If
    
    'If Not ValidaDiaySurtido(IdCedis, IdSurtido, IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy"))) Then Exit Sub
    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    
    StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", " & TxtIdProdS.Text & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        TxtExistencias.Text = FormatNumber(Rs.Fields(3), 3, vbTrue)
    Else
        TxtExistencias.Text = "0"
    End If
    
    If CDbl(TxtExistencias.Text) + CargaAnt < CDbl(TxtCantidadS.Text) Then 'Or TxtExistencias.Text = "0" Or TxtExistencias.Text = "" Then
        MsgBox "¡ Existencias insuficientes !. La cantidad de producto a Cargar debe ser menor o igual a las Existencias.", vbInformation + vbOKOnly, App.Title
        TxtCantidadS.SetFocus
        Exit Sub
    End If
    
    'valido si la carga ya tiene devoluciones o ventas en ese producto, ya no la puede modificar...
    StrCmd = "execute sel_ExistenciaValida " & IdCedis & ", " & IdSurtido & ", 0, 0, " & TxtIdProdS.Text & ", 0, 0, 6"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        If CDbl(Rs.Fields(2).Value) <> 0 Then
            MsgBox "¡ No puedes Modificar la Carga del Producto porque ya se han registrado Devoluciones y/o Ventas !" & Chr(13) & Chr(10) & "Elimine las Ventas y las Devoluciones del Surtido para poder Modificar la Carga.", vbInformation + vbOKOnly, App.Title
            TxtIdProdS.SetFocus
            Exit Sub
        End If
    End If
    
    ' valido si el producto ya tiene una venta registrada...
    StrCmd = "execute sel_ExistenciaValida " & IdCedis & ", " & IdSurtido & ", 0, 0, " & TxtIdProdS.Text & ", 0, 0, 5"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF And CDbl(TxtCantidadS.Text) = 0 Then
        MsgBox "¡ No puedes Eliminar el Producto de la Carga, ya que tiene Ventas registradas !. ", vbInformation + vbOKOnly, App.Title
        TxtIdProdS.SetFocus
        Exit Sub
    End If
    
    StrCmd = "execute up_SurtidosDetalle " & IdCedis & ", " & IdSurtido & ", " & Trim(TxtIdProdS.Text) & ", '" & FormatDate(Fecha) & "', " & Trim(TxtCantidadS.Text) & ", 0, 0, 0, 0, 0, 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    TxtExistencias.Text = CDbl(TxtExistencias.Text) + CargaAnt - CDbl(TxtCantidadS.Text)
    DetalleSurtidos False, 1
    
No_Err_ActCarga:
    MousePointer = 0
    Exit Sub
    
Err_ActCarga:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_ActCarga:
End Sub

Sub ValProdDev()
    If Trim(TxtIdProdD.Text) = "" Or TxtIdProdD.Text = "0" Then
        TxtIdProdD.Text = ""
        Exit Sub
    End If
    StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", " & TxtIdProdD.Text & ", 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Rs.EOF Then
        MsgBox "¡ El producto " & TxtIdProdD.Text & " no fue registrado en la carga de la Ruta !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    Else
        TxtDescD.Text = Rs.Fields(2): TxtCargaD.Text = FormatNumber(Rs.Fields(3), 3, vbTrue): TxtVentaD.Text = FormatNumber(Rs.Fields(4), 3, vbTrue)
        TxtBuenaD.Text = Rs.Fields(5): TxtMalaD.Text = Rs.Fields(6): TxtObsequiosD.Text = Rs.Fields(7): TxtFaltanteD.Text = FormatNumber(Rs.Fields(8), 3, vbTrue)
        Dec = IIf(Rs.Fields(13) = 1, True, False)
        
        IdFamiliaRejas = CDbl(Rs.Fields(14))
        TxtMalaD.Enabled = IIf(CDbl(Rs.Fields(14)) = 0, True, False)
        TxtObsequiosD.Enabled = IIf(CDbl(Rs.Fields(14)) = 0, True, False)
    End If
End Sub

Function ValFaltante(Txt As TextBox) As Boolean
    Dim Faltante As Double
    ValFaltante = False
    
    If TxtCargaD.Text <> "" And TxtVentaD.Text <> "" And TxtObsequiosD.Text <> "" And TxtBuenaD.Text <> "" And TxtMalaD.Text <> "" Then
        Faltante = CDbl(TxtCargaD.Text) - CDbl(TxtVentaD.Text) - CDbl(TxtObsequiosD.Text) - CDbl(TxtBuenaD.Text) - CDbl(TxtMalaD.Text)
        If FormatNumber(Faltante, 4, 0) < 0 Then
            ValFaltante = False
            MsgBox "¡ Existencias insuficientes !. " & Chr(13) & Chr(10) & "La Carga debe ser menor igual a la suma de las Ventas + Devoluciones + Obsequios.", vbInformation + vbOKOnly, App.Title
            Txt.Text = "0"
            Faltante = CDbl(TxtCargaD.Text) - CDbl(TxtVentaD.Text) - CDbl(TxtObsequiosD.Text) - CDbl(TxtBuenaD.Text) - CDbl(TxtMalaD.Text)
            TxtFaltanteD.Text = Faltante
            Txt.SetFocus
        Else
            ValFaltante = True
            TxtFaltanteD.Text = FormatNumber(Faltante, 4, 0)
        End If
    End If
End Function

Function ClasificaMerma() As Long
    ClasificaMerma = 0
    StrCmd = "execute sel_TipoMerma 2"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    ClasificaMerma = RsC.Fields(0)
    If ClasificaMerma = 1 Then
        StrCmd = "execute sel_TipoMerma 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        ClasificaMerma = RsC.Fields(0)
    End If
End Function

Sub ActualizaSurtido()
    StrCmd = "execute up_SurtidosDetalle " & IdCedis & ", " & IdSurtido & ", " & CLng(TxtIdProdD.Text) & ", '" & FormatDate(Fecha) & _
    "', 0 , " & CDbl(TxtBuenaD.Text) & ", " & CDbl(TxtMalaD.Text) & ", " & CDbl(TxtObsequiosD.Text) & ", 0, 0, 2"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
End Sub

Sub HabilitaMonthV()

    Dim FinMes As Date
        
    StrCmd = "execute sel_StatusDias " & IdCedis & ", '" & FormatDate(Date) & "', 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    
    If RsC.EOF Then
        FFin = Date
        FIni = CDate("1/" & Month(FFin) & "/" & Year(FFin))
    Else
        If Month(Date) > Month(RsC.Fields(0)) Then
            If RsC.Fields(1) = "A" Then
                FFin = CDate(RsC.Fields(0))
                FIni = CDate("1/" & Month(RsC.Fields(0)) & "/" & Year(RsC.Fields(0))) 'CDate("1/" & Month(FFin) & "/" & Year(FFin))
            Else
                FFin = Date
                FIni = CDate("1/" & Month(FFin) & "/" & Year(FFin))
            End If
        Else
            FFin = CDate(RsC.Fields(0))
            FIni = CDate("1/" & Month(RsC.Fields(0)) & "/" & Year(RsC.Fields(0))) 'CDate("1/" & Month(FFin) & "/" & Year(FFin))
        End If
    End If
    
    'If Date > RsC.Fields(0) And Month(Date) = Month(RsC.Fields(0)) Then
    '    'FFin = IIf(BIdioma = "us_english", Format(Date, "mm/dd/yyyy"), Format(Date, "dd/mm/yyyy"))
    '    FFin = Date
    'Else
''        FFin = CDate(RsC.Fields(0))
    'End If
''    FIni = CDate("1/" & Month(RsC.Fields(0)) & "/" & Year(RsC.Fields(0))) 'CDate("1/" & Month(FFin) & "/" & Year(FFin))
        
    With MonthV
        .Value = FFin 'IIf(BIdioma = "us_english", Format(Date, "mm/dd/yyyy"), Format(Date, "dd/mm/yyyy"))
        .TitleBackColor = &H8A7A61
        .TitleForeColor = vbWhite
        .MaxSelCount = 31
        .MinDate = FIni
        'FinMes = IIf(BIdioma = "us_english", Format(CDate(Month(FFin) + 1 & "/" & "1/" & Year(FFin)), "mm/dd/yyyy"), Format(CDate("1/" & Month(FFin) + 1 & "/" & Year(FFin)), "dd/mm/yyyy")) 'CDate("1/" & Month(FFin) & "/" & Year(FFin))
        FinMes = CDate("1/" & Month(FFin) + 1 & "/" & Year(FFin))
        FinMes = FinMes - 1
        '.MaxDate = FinMes
        .MaxDate = Date
        .SelStart = FIni
        .SelEnd = FFin
    End With
    
    DTPFechaSel.Value = FFin
    
    MonthV_DateClick FFin
    
    StrCmd = "execute sel_StatusDias " & IdCedis & ", '" & FormatDate(FFin) & "', 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    
    If Not RsC.EOF Then
        'UltimoDia = IIf(BIdioma = "us_english", Format(RsC.Fields(0), "mm/dd/yyyy"), Format(RsC.Fields(0), "dd/mm/yyyy"))
        UltimoDia = RsC.Fields(0)
    End If
    
    'MuestraStatusDia IIf(BIdioma = "us_english", Format(FFin, "mm/dd/yyyy"), Format(FFin, "dd/mm/yyyy"))
    MuestraStatusDia FFin
End Sub

Sub MuestraStatusDia(Dia As Date)
Dim StatDia
    
    StrCmd = "execute sel_StatusDias " & IdCedis & ", '" & FormatDate(Dia) & "', 3"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    
    If RsC.EOF Then
        If Dia > UltimoDia Then
            LblStatusDia.Caption = "No hay información registrada."
            btnIniciarCerrarDia(0).Visible = True: btnIniciarCerrarDia(1).Visible = False
        Else
            LblStatusDia.Caption = "No hay información registrada."
            btnIniciarCerrarDia(0).Visible = False: btnIniciarCerrarDia(1).Visible = False
        End If
    Else
        StatDia = Trim(RsC.Fields(1))
        If Trim(RsC.Fields(1)) = "A" Then
            LblStatusDia.Caption = "Día en proceso de captura."
            btnIniciarCerrarDia(0).Visible = False: btnIniciarCerrarDia(1).Visible = True
        Else
            LblStatusDia.Caption = "Día Cerrado"
            btnIniciarCerrarDia(0).Visible = False: btnIniciarCerrarDia(1).Visible = False
        End If
    End If
        
    frmContado.Visible = IIf(StatDia <> "A" And StatDia <> "C", False, True)
        
    'Factura Global del Día...
    StrCmd = "execute sel_VentasContado " & IdCedis & ", '" & FormatDate(Dia) & "', 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    
    If RsC.EOF Then
        'frmDatosC.Visible = False
        LblContado.Caption = "Crear Factura de Contado del Día"
        
        TxtSerieC.Text = ""
        TxtFolioC.Locked = False: TxtFolioC.Text = ""
        LblSubtotal.Caption = FormatCurrency(0, 2, vbTrue)
        LblIva.Caption = FormatCurrency(0, 2, vbTrue)
        LblTotal.Caption = FormatCurrency(0, 2, vbTrue)
    Else
        TxtSerieC.Text = RsC.Fields(0)
        TxtFolioC.Locked = True: TxtFolioC.Text = RsC.Fields(1)
        LblSubtotal.Caption = FormatCurrency(RsC.Fields(2), 2, vbTrue)
        LblIva.Caption = FormatCurrency(RsC.Fields(3), 2, vbTrue)
        LblTotal.Caption = FormatCurrency(RsC.Fields(4), 2, vbTrue)
        'frmDatosC.Visible = True
        LblContado.Caption = "Imprimir Factura de Contado del Día"
    End If
    
    
    MuestraRutas Dia

End Sub

Private Sub MonthV_DateClick(ByVal DateClicked As Date)
    On Error Resume Next
    'FechaSel = IIf(BIdioma = "us_english", Format(DateClicked, "mm/dd/yyyy"), Format(DateClicked, "dd/mm/yyyy"))
    FechaSel = DateClicked
    
    DTPFechaSel.Value = FechaSel
    MonthV.SelStart = FIni
    MonthV.SelEnd = FFin
    'FrmStatus.Enabled = IIf(DateClicked >= FFin + 1, True, False)
    MuestraStatusDia FechaSel
End Sub

Sub MuestraRutas(Fec As Date)
    StrCmd = "execute sel_StatusRutas " & IdCedis & ", '" & FormatDate(Fec) & "', 0, 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDStatusRutas = GetDataLVL(RsC, LstStatusRutas, 2, 5, "1|0|0|0")
End Sub

Function ObtenStatusDia(Fec As Date) As String
    StrCmd = "execute sel_StatusDias " & IdCedis & ", " & FormatDate(Fec) & ", 3"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    If Not RsC.EOF Then
        ObtenStatusDia = RsC.Fields(1)
    Else
        ObtenStatusDia = ""
    End If
End Function

Sub LlenaComboVentas()
    StrCmd = "execute sel_VentasTipo "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDTipoVenta = GetDataCBL(Rs, cmbTipoVenta, "Tipo de Venta", "No existen Tipos de Venta definidos")
End Sub

Sub MuestraFacturas()
    StrCmd = "execute sel_Ventas " & IdCedis & "," & IdSurtido & ", 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDFacturas = GetDataLVL(RsC, LstFacturas, 3, 12, "0|1|0|1|0|7|7|7|0|0")
End Sub

Sub FiltraClientes()
    LblCliente.Caption = ""
    StrCmd = "execute sel_ClientesFacturas " & IdCedis & ",'" & IIf(Trim(TxtIdCliente.Text) = "", 0, Trim(TxtIdCliente.Text)) & "','" & Trim(TxtRFC.Text) & "','" & Trim(TxtRazonSocial.Text) & "', 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDClientes = GetDataLVL(RsC, LstClientes, 1, 4, "0|0|0|0")
End Sub

Sub CancelaVenta()
    cmbTipoVenta.ListIndex = 0: TxtSerie.Text = "": TxtFolio.Text = 0
    TxtSubtotal.Text = 0: TxtIva.Text = 0: TxtTotal.Text = 0
    TxtIdCliente.Text = "": TxtRFC.Text = "": TxtRazonSocial.Text = "": LstClientes.ListItems.Clear
End Sub

