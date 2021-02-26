VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.2#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form AL_Liquidacion 
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
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   8430
   ScaleWidth      =   12660
   ShowInTaskbar   =   0   'False
   Begin TabDlg.SSTab SSTab 
      Height          =   8175
      Left            =   120
      TabIndex        =   18
      Top             =   120
      Width           =   12375
      _ExtentX        =   21828
      _ExtentY        =   14420
      _Version        =   393216
      Tabs            =   5
      TabsPerRow      =   5
      TabHeight       =   520
      BackColor       =   16777215
      TabCaption(0)   =   "&Cargas de Rutas"
      TabPicture(0)   =   "AL_Liquidacion.frx":0000
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "LblOpt(0)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "FrmOpt(0)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "Carga de &Producto"
      TabPicture(1)   =   "AL_Liquidacion.frx":001C
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "LblOpt(3)"
      Tab(1).Control(1)=   "FrmOpt(3)"
      Tab(1).ControlCount=   2
      TabCaption(2)   =   "&Devoluciones de Producto"
      TabPicture(2)   =   "AL_Liquidacion.frx":0038
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "LblOpt(4)"
      Tab(2).Control(1)=   "FrmOpt(4)"
      Tab(2).ControlCount=   2
      TabCaption(3)   =   "&Ventas"
      TabPicture(3)   =   "AL_Liquidacion.frx":0054
      Tab(3).ControlEnabled=   0   'False
      Tab(3).Control(0)=   "LblOpt(6)"
      Tab(3).Control(1)=   "FrmOpt(2)"
      Tab(3).ControlCount=   2
      TabCaption(4)   =   "&Liquidaciones"
      TabPicture(4)   =   "AL_Liquidacion.frx":0070
      Tab(4).ControlEnabled=   0   'False
      Tab(4).Control(0)=   "FrmOpt(1)"
      Tab(4).Control(1)=   "LblOpt(1)"
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
         Left            =   -75000
         TabIndex        =   52
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
            TabIndex        =   130
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
               Picture         =   "AL_Liquidacion.frx":008C
               Style           =   1  'Graphical
               TabIndex        =   78
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
               TabIndex        =   131
               Top             =   1200
               Width           =   2895
               Begin VB.TextBox TxtFolioC 
                  Alignment       =   1  'Right Justify
                  Height          =   375
                  Left            =   1320
                  Locked          =   -1  'True
                  TabIndex        =   80
                  Text            =   "0"
                  Top             =   480
                  Width           =   1335
               End
               Begin VB.TextBox TxtSerieC 
                  Height          =   375
                  Left            =   600
                  Locked          =   -1  'True
                  TabIndex        =   79
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
                  TabIndex        =   139
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
                  TabIndex        =   138
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
                  TabIndex        =   137
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
                  TabIndex        =   136
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
                  TabIndex        =   135
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
                  TabIndex        =   134
                  Top             =   1680
                  Width           =   1635
               End
               Begin VB.Label Label34 
                  Alignment       =   1  'Right Justify
                  BackColor       =   &H00FFFFFF&
                  Caption         =   "Folio"
                  Height          =   255
                  Left            =   1680
                  TabIndex        =   133
                  Top             =   240
                  Width           =   975
               End
               Begin VB.Label Label33 
                  BackColor       =   &H00FFFFFF&
                  Caption         =   "Serie"
                  Height          =   255
                  Left            =   600
                  TabIndex        =   132
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
               TabIndex        =   140
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
            TabIndex        =   74
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
               Height          =   495
               Index           =   1
               Left            =   4320
               Picture         =   "AL_Liquidacion.frx":03EA
               Style           =   1  'Graphical
               TabIndex        =   76
               Top             =   600
               Visible         =   0   'False
               Width           =   1815
            End
            Begin VB.CommandButton btnIniciarCerrarDia 
               BackColor       =   &H00FFFFFF&
               Height          =   495
               Index           =   0
               Left            =   4320
               Picture         =   "AL_Liquidacion.frx":0B85
               Style           =   1  'Graphical
               TabIndex        =   156
               Top             =   600
               Visible         =   0   'False
               Width           =   1815
            End
            Begin MSComCtl2.DTPicker DTPFechaSel 
               Height          =   375
               Left            =   240
               TabIndex        =   75
               Top             =   720
               Width           =   3855
               _ExtentX        =   6800
               _ExtentY        =   661
               _Version        =   393216
               Format          =   52297728
               CurrentDate     =   39396
            End
            Begin MSComctlLib.ListView LstStatusRutas 
               Height          =   5535
               Left            =   240
               TabIndex        =   77
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
               TabIndex        =   82
               Top             =   480
               Width           =   1440
            End
         End
         Begin MSComCtl2.MonthView MonthV 
            Height          =   2820
            Left            =   480
            TabIndex        =   73
            Top             =   1080
            Width           =   3120
            _ExtentX        =   5503
            _ExtentY        =   4974
            _Version        =   393216
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            MultiSelect     =   -1  'True
            StartOfWeek     =   52297729
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
            TabIndex        =   81
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
         TabIndex        =   25
         Top             =   340
         Width           =   12375
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
            Left            =   120
            Picture         =   "AL_Liquidacion.frx":12EA
            Style           =   1  'Graphical
            TabIndex        =   31
            Top             =   7080
            Width           =   1815
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
            Left            =   120
            Picture         =   "AL_Liquidacion.frx":1A05
            Style           =   1  'Graphical
            TabIndex        =   154
            Top             =   7080
            Visible         =   0   'False
            Width           =   1815
         End
         Begin VB.Frame FrmCambios 
            BackColor       =   &H00FFFFFF&
            BorderStyle     =   0  'None
            Height          =   855
            Left            =   2040
            TabIndex        =   148
            Top             =   6880
            Width           =   2295
            Begin VB.Label Label42 
               Alignment       =   1  'Right Justify
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Ent.Cambio"
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
               Left            =   15
               TabIndex        =   152
               Top             =   120
               Width           =   975
            End
            Begin VB.Label LblECambio 
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
               Left            =   1200
               TabIndex        =   151
               Top             =   120
               Width           =   1035
            End
            Begin VB.Label Label41 
               Alignment       =   1  'Right Justify
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Sal.Cambio"
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
               Left            =   90
               TabIndex        =   150
               Top             =   480
               Width           =   975
            End
            Begin VB.Label LblSCambio 
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
               Left            =   1200
               TabIndex        =   149
               Top             =   480
               Width           =   1035
            End
         End
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
            Left            =   4320
            TabIndex        =   117
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
               Left            =   6510
               TabIndex        =   129
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
               Left            =   5760
               TabIndex        =   128
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
               Left            =   6510
               TabIndex        =   127
               Top             =   480
               Width           =   1275
            End
            Begin VB.Label Label32 
               Alignment       =   1  'Right Justify
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Inv. Final"
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
               Left            =   5625
               TabIndex        =   126
               Top             =   480
               Width           =   720
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
               Left            =   3960
               TabIndex        =   125
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
               Left            =   2880
               TabIndex        =   124
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
               Left            =   3960
               TabIndex        =   123
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
               Left            =   1455
               TabIndex        =   122
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
               Left            =   1455
               TabIndex        =   121
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
               Left            =   3000
               TabIndex        =   120
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
               Left            =   360
               TabIndex        =   119
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
               Left            =   720
               TabIndex        =   118
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
            Picture         =   "AL_Liquidacion.frx":209C
            Style           =   1  'Graphical
            TabIndex        =   114
            Top             =   960
            Visible         =   0   'False
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
            Picture         =   "AL_Liquidacion.frx":2479
            Style           =   1  'Graphical
            TabIndex        =   113
            Top             =   975
            Visible         =   0   'False
            Width           =   495
         End
         Begin VB.TextBox TxtFaltanteD 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   10080
            Locked          =   -1  'True
            MaxLength       =   8
            TabIndex        =   32
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
            TabIndex        =   34
            Text            =   "0"
            Top             =   1080
            Width           =   855
         End
         Begin VB.TextBox TxtObsequiosD 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   9240
            MaxLength       =   8
            TabIndex        =   29
            Text            =   "0"
            Top             =   1080
            Width           =   735
         End
         Begin VB.TextBox TxtMalaD 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   8160
            MaxLength       =   8
            TabIndex        =   28
            Text            =   "0"
            Top             =   1080
            Width           =   975
         End
         Begin VB.TextBox TxtBuenaD 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   7080
            MaxLength       =   8
            TabIndex        =   27
            Text            =   "0"
            Top             =   1080
            Width           =   975
         End
         Begin VB.TextBox TxtIdProdD 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   120
            MaxLength       =   10
            TabIndex        =   26
            Top             =   1080
            Width           =   735
         End
         Begin VB.TextBox TxtDescD 
            Height          =   375
            Left            =   960
            Locked          =   -1  'True
            TabIndex        =   35
            Top             =   1080
            Width           =   4095
         End
         Begin VB.TextBox TxtCargaD 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   5160
            Locked          =   -1  'True
            MaxLength       =   8
            TabIndex        =   33
            Text            =   "0"
            Top             =   1080
            Width           =   855
         End
         Begin MSComctlLib.ListView LstDevoluciones 
            Height          =   5295
            Left            =   120
            TabIndex        =   30
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
            TabIndex        =   70
            Top             =   840
            Width           =   975
         End
         Begin VB.Label Label10 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Venta"
            Height          =   255
            Left            =   6120
            TabIndex        =   69
            Top             =   840
            Width           =   615
         End
         Begin VB.Label Label9 
            Alignment       =   1  'Right Justify
            BackColor       =   &H00FFFFFF&
            Caption         =   "Obseq."
            Height          =   255
            Left            =   9240
            TabIndex        =   68
            Top             =   840
            Width           =   615
         End
         Begin VB.Label Label7 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Dev. Mala"
            Height          =   255
            Left            =   8160
            TabIndex        =   67
            Top             =   840
            Width           =   855
         End
         Begin VB.Label Label6 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Dev. Buena"
            Height          =   255
            Left            =   7080
            TabIndex        =   66
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
            TabIndex        =   65
            Top             =   240
            Width           =   660
         End
         Begin VB.Label Label8 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Descripción del Producto"
            Height          =   255
            Left            =   960
            TabIndex        =   39
            Top             =   840
            Width           =   3135
         End
         Begin VB.Label Label5 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cve. P"
            Height          =   255
            Left            =   120
            TabIndex        =   38
            Top             =   840
            Width           =   615
         End
         Begin VB.Label Label3 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Surtido"
            Height          =   255
            Left            =   5160
            TabIndex        =   37
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
         TabIndex        =   23
         Top             =   345
         Width           =   12375
         Begin VB.CommandButton btnImprimePedido 
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
            Picture         =   "AL_Liquidacion.frx":289E
            Style           =   1  'Graphical
            TabIndex        =   158
            Top             =   3960
            Width           =   1695
         End
         Begin VB.CommandButton btnResumen 
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
            Index           =   0
            Left            =   120
            Picture         =   "AL_Liquidacion.frx":2F21
            Style           =   1  'Graphical
            TabIndex        =   97
            Top             =   3360
            Width           =   1695
         End
         Begin VB.CommandButton btnFacturar 
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
            Picture         =   "AL_Liquidacion.frx":36F8
            Style           =   1  'Graphical
            TabIndex        =   95
            Top             =   2160
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
            Picture         =   "AL_Liquidacion.frx":3DE2
            Style           =   1  'Graphical
            TabIndex        =   93
            Top             =   960
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
            Picture         =   "AL_Liquidacion.frx":4470
            Style           =   1  'Graphical
            TabIndex        =   94
            Top             =   1560
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
            Picture         =   "AL_Liquidacion.frx":4B80
            Style           =   1  'Graphical
            TabIndex        =   96
            Top             =   2760
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
            Picture         =   "AL_Liquidacion.frx":529B
            Style           =   1  'Graphical
            TabIndex        =   155
            Top             =   960
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
            TabIndex        =   103
            Top             =   1680
            Width           =   10215
            Begin VB.TextBox TxtIdCliente 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   120
               TabIndex        =   88
               Top             =   480
               Width           =   975
            End
            Begin VB.TextBox TxtRFC 
               Height          =   375
               Left            =   3600
               TabIndex        =   90
               Top             =   480
               Width           =   1815
            End
            Begin VB.TextBox TxtRazonSocial 
               Height          =   375
               Left            =   1200
               TabIndex        =   89
               Top             =   480
               Width           =   2295
            End
            Begin MSComctlLib.ListView LstClientes 
               Height          =   2055
               Left            =   120
               TabIndex        =   91
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
               TabIndex        =   157
               Top             =   720
               Width           =   4485
            End
            Begin VB.Label Label26 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Cliente Seleccionado"
               Height          =   200
               Left            =   5520
               TabIndex        =   112
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
               TabIndex        =   111
               Top             =   420
               Width           =   4485
            End
            Begin VB.Label Label20 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "No. Cliente"
               Height          =   240
               Left            =   120
               TabIndex        =   106
               Top             =   240
               Width           =   960
            End
            Begin VB.Label Label21 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Razón Social ( Cliente )"
               Height          =   255
               Left            =   1200
               TabIndex        =   105
               Top             =   240
               Width           =   2295
            End
            Begin VB.Label Label22 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Sucursal"
               Height          =   240
               Left            =   3600
               TabIndex        =   104
               Top             =   240
               Width           =   765
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
            Height          =   975
            Left            =   1920
            TabIndex        =   84
            Top             =   720
            Width           =   10215
            Begin VB.TextBox TxtTotal 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   8160
               Locked          =   -1  'True
               TabIndex        =   109
               Text            =   "0"
               Top             =   480
               Width           =   1935
            End
            Begin VB.TextBox TxtIva 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   7080
               Locked          =   -1  'True
               TabIndex        =   99
               Text            =   "0"
               Top             =   480
               Width           =   975
            End
            Begin VB.TextBox TxtSubtotal 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   5400
               Locked          =   -1  'True
               TabIndex        =   98
               Text            =   "0"
               Top             =   480
               Width           =   1575
            End
            Begin VB.TextBox TxtSerie 
               Height          =   375
               Left            =   3000
               Locked          =   -1  'True
               TabIndex        =   86
               Top             =   480
               Width           =   855
            End
            Begin VB.TextBox TxtFolio 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   3960
               Locked          =   -1  'True
               TabIndex        =   87
               Text            =   "0"
               Top             =   480
               Width           =   1335
            End
            Begin VB.ComboBox cmbTipoVenta 
               Height          =   360
               Left            =   120
               Style           =   2  'Dropdown List
               TabIndex        =   85
               Top             =   480
               Width           =   2655
            End
            Begin VB.Label Label25 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Total"
               Height          =   255
               Left            =   9000
               TabIndex        =   110
               Top             =   240
               Width           =   975
            End
            Begin VB.Label Label24 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Iva"
               Height          =   255
               Left            =   6960
               TabIndex        =   108
               Top             =   240
               Width           =   975
            End
            Begin VB.Label Label23 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Subtotal"
               Height          =   255
               Left            =   5880
               TabIndex        =   107
               Top             =   240
               Width           =   975
            End
            Begin VB.Label Label19 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Serie"
               Height          =   255
               Left            =   3000
               TabIndex        =   102
               Top             =   240
               Width           =   615
            End
            Begin VB.Label Label18 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Folio"
               Height          =   255
               Left            =   4200
               TabIndex        =   101
               Top             =   240
               Width           =   975
            End
            Begin VB.Label Label17 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Tipo de Venta"
               Height          =   240
               Left            =   120
               TabIndex        =   100
               Top             =   240
               Width           =   1200
            End
         End
         Begin VB.Frame Frame1 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Ventas"
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
            TabIndex        =   83
            Top             =   4800
            Width           =   12015
            Begin MSComctlLib.ListView LstFacturas 
               Height          =   2415
               Left            =   120
               TabIndex        =   92
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
            TabIndex        =   64
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
         TabIndex        =   21
         Top             =   340
         Width           =   12375
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
            Left            =   2520
            Picture         =   "AL_Liquidacion.frx":5C31
            Style           =   1  'Graphical
            TabIndex        =   45
            Top             =   6960
            Width           =   1815
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
            Left            =   8400
            Picture         =   "AL_Liquidacion.frx":634C
            Style           =   1  'Graphical
            TabIndex        =   153
            Top             =   6975
            Visible         =   0   'False
            Width           =   1935
         End
         Begin VB.CommandButton btnImportar 
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
            Picture         =   "AL_Liquidacion.frx":69E3
            Style           =   1  'Graphical
            TabIndex        =   44
            Top             =   6975
            Width           =   1935
         End
         Begin VB.OptionButton OptImprimir 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Imprimir Carga"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Index           =   1
            Left            =   4440
            TabIndex        =   46
            Top             =   6960
            Value           =   -1  'True
            Width           =   3375
         End
         Begin VB.OptionButton OptImprimir 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Imprimir Surtido ( Carga total )"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Index           =   0
            Left            =   4440
            TabIndex        =   47
            Top             =   7320
            Width           =   3375
         End
         Begin VB.TextBox TxtSurtido 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   8400
            Locked          =   -1  'True
            MaxLength       =   8
            TabIndex        =   142
            Text            =   "0"
            Top             =   1080
            Width           =   975
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
            Left            =   9720
            Picture         =   "AL_Liquidacion.frx":7173
            Style           =   1  'Graphical
            TabIndex        =   116
            Top             =   960
            Visible         =   0   'False
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
            Left            =   10320
            Picture         =   "AL_Liquidacion.frx":7550
            Style           =   1  'Graphical
            TabIndex        =   115
            Top             =   960
            Visible         =   0   'False
            Width           =   495
         End
         Begin VB.TextBox TxtExistencias 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   7320
            Locked          =   -1  'True
            MaxLength       =   8
            TabIndex        =   71
            Text            =   "0"
            Top             =   1080
            Width           =   975
         End
         Begin VB.TextBox TxtCantidadS 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   6240
            MaxLength       =   8
            TabIndex        =   42
            Text            =   "0"
            Top             =   1080
            Width           =   975
         End
         Begin VB.TextBox TxtDescS 
            Height          =   375
            Left            =   1200
            Locked          =   -1  'True
            TabIndex        =   41
            Top             =   1080
            Width           =   4935
         End
         Begin VB.TextBox TxtIdProdS 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   360
            MaxLength       =   10
            TabIndex        =   40
            Top             =   1080
            Width           =   735
         End
         Begin MSComctlLib.ListView LstSurtido 
            Height          =   5055
            Left            =   360
            TabIndex        =   43
            Top             =   1560
            Width           =   11775
            _ExtentX        =   20770
            _ExtentY        =   8916
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
         Begin VB.Label Label38 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Surtido"
            Height          =   255
            Left            =   8520
            TabIndex        =   143
            Top             =   840
            Width           =   735
         End
         Begin VB.Label Label15 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Existencias"
            Height          =   255
            Left            =   7320
            TabIndex        =   72
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
            TabIndex        =   63
            Top             =   240
            Width           =   660
         End
         Begin VB.Label Label14 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Carga"
            Height          =   255
            Left            =   6240
            TabIndex        =   50
            Top             =   840
            Width           =   1095
         End
         Begin VB.Label Label13 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cve. P"
            Height          =   255
            Left            =   360
            TabIndex        =   49
            Top             =   840
            Width           =   615
         End
         Begin VB.Label Label12 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Descripción del Producto"
            Height          =   255
            Left            =   1200
            TabIndex        =   48
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
         Left            =   0
         TabIndex        =   20
         Top             =   340
         Width           =   12375
         Begin VB.CommandButton btnDevolucion 
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
            Picture         =   "AL_Liquidacion.frx":7975
            Style           =   1  'Graphical
            TabIndex        =   159
            Top             =   5520
            Width           =   1695
         End
         Begin VB.CommandButton btnConsignas 
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
            Picture         =   "AL_Liquidacion.frx":8145
            Style           =   1  'Graphical
            TabIndex        =   16
            Top             =   4920
            Width           =   1695
         End
         Begin VB.CommandButton btnResumen 
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
            Index           =   1
            Left            =   120
            Picture         =   "AL_Liquidacion.frx":8935
            Style           =   1  'Graphical
            TabIndex        =   15
            Top             =   4320
            Width           =   1695
         End
         Begin VB.CommandButton btnCargaSugerida 
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
            Picture         =   "AL_Liquidacion.frx":910C
            Style           =   1  'Graphical
            TabIndex        =   14
            Top             =   3720
            Width           =   1695
         End
         Begin VB.CommandButton btnEfectivo 
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
            Picture         =   "AL_Liquidacion.frx":98DA
            Style           =   1  'Graphical
            TabIndex        =   12
            Top             =   2520
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
            Picture         =   "AL_Liquidacion.frx":A14A
            Style           =   1  'Graphical
            TabIndex        =   9
            Top             =   720
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
            Picture         =   "AL_Liquidacion.frx":A7D8
            Style           =   1  'Graphical
            TabIndex        =   10
            Top             =   1320
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
            Picture         =   "AL_Liquidacion.frx":AEE8
            Style           =   1  'Graphical
            TabIndex        =   11
            Top             =   1920
            Width           =   1695
         End
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
            Picture         =   "AL_Liquidacion.frx":B57F
            Style           =   1  'Graphical
            TabIndex        =   13
            Top             =   3120
            Width           =   1695
         End
         Begin VB.Frame frmCargasGral 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Folios de Carga para la Liquidación"
            Height          =   3735
            Left            =   1920
            TabIndex        =   141
            Top             =   3960
            Width           =   4095
            Begin VB.Frame frmCargas 
               BackColor       =   &H00FFFFFF&
               BorderStyle     =   0  'None
               Height          =   3375
               Left            =   120
               TabIndex        =   144
               Top             =   240
               Visible         =   0   'False
               Width           =   3855
               Begin VB.CommandButton btnEliminaCarga 
                  BackColor       =   &H00FFFFFF&
                  Caption         =   "Eliminar"
                  Height          =   375
                  Left            =   2040
                  Style           =   1  'Graphical
                  TabIndex        =   146
                  Top             =   240
                  Width           =   1215
               End
               Begin VB.CommandButton btnNuevaCarga 
                  BackColor       =   &H00FFFFFF&
                  Caption         =   "Nueva"
                  Height          =   375
                  Left            =   480
                  Style           =   1  'Graphical
                  TabIndex        =   145
                  Top             =   240
                  Width           =   1215
               End
               Begin MSComctlLib.ListView LstCargas 
                  Height          =   2655
                  Left            =   0
                  TabIndex        =   147
                  Top             =   720
                  Width           =   3855
                  _ExtentX        =   6800
                  _ExtentY        =   4683
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
         Begin VB.Frame FrmRuta 
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
            Height          =   3375
            Left            =   1920
            TabIndex        =   57
            Top             =   480
            Width           =   4095
            Begin VB.CheckBox ChkBaja 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Mostrar Cargas dadas de Baja"
               Height          =   255
               Left            =   360
               TabIndex        =   17
               Top             =   1080
               Visible         =   0   'False
               Width           =   3135
            End
            Begin VB.TextBox TxtRuta 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   3000
               MaxLength       =   5
               TabIndex        =   1
               Top             =   480
               Width           =   735
            End
            Begin MSComctlLib.ListView LstSurtidos 
               Height          =   1815
               Left            =   120
               TabIndex        =   2
               Top             =   1440
               Width           =   3855
               _ExtentX        =   6800
               _ExtentY        =   3201
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
               Left            =   720
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
               Format          =   52297729
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
               TabIndex        =   60
               Top             =   960
               Visible         =   0   'False
               Width           =   3615
            End
            Begin VB.Label Label1 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Ruta"
               Height          =   255
               Left            =   2400
               TabIndex        =   59
               Top             =   600
               Width           =   615
            End
            Begin VB.Label Label2 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Fecha"
               Height          =   255
               Left            =   120
               TabIndex        =   58
               Top             =   600
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
            TabIndex        =   53
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
               TabIndex        =   62
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
               TabIndex        =   61
               Top             =   360
               Width           =   2850
            End
            Begin VB.Label LblNombre 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Nombre"
               Height          =   255
               Left            =   960
               TabIndex        =   56
               Top             =   2640
               Visible         =   0   'False
               Width           =   1335
            End
            Begin VB.Label LblIdVendedor 
               BackColor       =   &H00FFFFFF&
               Caption         =   "No."
               Height          =   255
               Left            =   120
               TabIndex        =   55
               Top             =   2640
               Visible         =   0   'False
               Width           =   615
            End
            Begin VB.Label LblNomina 
               BackColor       =   &H00FFFFFF&
               Caption         =   "No. Nómina"
               Height          =   255
               Left            =   2640
               TabIndex        =   54
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
         Left            =   -65100
         TabIndex        =   51
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
         TabIndex        =   36
         Top             =   0
         Width           =   2515
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
         TabIndex        =   24
         Top             =   0
         Width           =   2520
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
         TabIndex        =   22
         Top             =   0
         Width           =   2490
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
         Left            =   0
         TabIndex        =   19
         Top             =   0
         Width           =   2490
      End
   End
End
Attribute VB_Name = "AL_Liquidacion"
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
Dim LstDCargas, StatusC, StatusDescC, AccesaSurtido As Boolean
Dim Cancela As Boolean, ContadoGeneral As Boolean

Private Sub btnActualizaVenta_Click()
On Error Resume Next

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
        ContadoGeneral = False
        If MsgBox("¿ Estás seguro que deseas generar la Venta de Contado por Diferencia de Inventario ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
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
             ContadoGeneral = True
        End If
    End If
    
    StrCmd = "execute up_Ventas " & IdCedis & ", " & IdSurtido & ", " & LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) & ", " & _
            TxtFolio.Text & ", '" & TxtSerie.Text & "', '" & FormatDate(Fecha) & "', " & IdCliente & ", '" & IdSucursal & "', " & _
            IIf(LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) = 1 And ContadoGeneral, 4, 1)
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    Dim Mensaje
    If LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) = 1 Then
        ' Valida si hay productos con precio = 0
        StrCmd = "execute sel_VentasDetalle " & IdCedis & ", " & IdSurtido & ", " & LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) & ", " & TxtFolio.Text & ", 4"
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
    
    'Registro Venta para enviar a Route
    
    
    MuestraFacturas
    IdSucursal = 0: IdCliente = 0
        
    With AL_Facturas
        .TxtTipoVenta.Text = LstDTipoVenta(1, cmbTipoVenta.ListIndex - 1)
        .TxtSerie.Text = TxtSerie.Text
        .TxtFolio.Text = TxtFolio.Text

        .TxtCliente.Text = LstDClientes(1, LstClientes.SelectedItem.Index - 1) & " , " & LstDClientes(2, LstClientes.SelectedItem.Index - 1)
        .TxtRFC.Text = LstDClientes(11, LstClientes.SelectedItem.Index - 1)
        .TxtListaPrecios.Text = LstDClientes(8, LstClientes.SelectedItem.Index - 1) & " - " & LstDClientes(9, LstClientes.SelectedItem.Index - 1)
        .TxtSucursal.Text = LstDClientes(10, LstClientes.SelectedItem.Index - 1) & " (CB: " & LstDClientes(3, LstClientes.SelectedItem.Index - 1) & ") " & LstDClientes(4, LstClientes.SelectedItem.Index - 1)
        
        .Left = AL_Liquidacion.Left
        .Top = AL_Liquidacion.Top '(Menu.Height + Liquidacion.Height - .Height) / 2
        .IdTipoVenta = LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1)
        .Folio = TxtFolio.Text
        .IdCliente = LstDClientes(1, LstClientes.SelectedItem.Index - 1)
        .IdSucursal = LstDClientes(10, LstClientes.SelectedItem.Index - 1)
        
        .RFC = LstDClientes(11, LstClientes.SelectedItem.Index - 1)
        .Nombre = LstDClientes(4, LstClientes.SelectedItem.Index - 1)
        .Direccion = LstDClientes(12, LstClientes.SelectedItem.Index - 1)
        .FolioRem = TxtSerie.Text & " " & Format(TxtFolio.Text, "000000")

        .MuestraDetalle False
        .MuestraTotales False
        .TxtIdProd.SetFocus
        .Show
    End With
        
    CancelaVenta
    Cancela = False
    btnEliminarVenta.Picture = LoadPicture(App.Path & "\Imagenes\Botones\btnEliminar.jpg")
    btnNuevaVenta.Visible = True: btnActualizaVenta.Visible = False
    
No_Err_ActualizaFact:
    MousePointer = 0
    Exit Sub
    
Err_ActualizaFact:
    MousePointer = 0
    
    CancelaVenta
    Cancela = False
    btnEliminarVenta.Picture = LoadPicture(App.Path & "\Imagenes\Botones\btnEliminar.jpg")
    btnNuevaVenta.Visible = True: btnActualizaVenta.Visible = False
    
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_ActualizaFact:
End Sub

Private Sub btnAdd_Click()
On Error Resume Next
    TxtMalaD_KeyPress 13
End Sub

Private Sub btnAddC_Click()
On Error Resume Next
    TxtCantidadS_KeyPress 13
End Sub

Private Sub btnAplica_Click()
On Error GoTo Err_AplicaC:

    If Not ValidaDiaySurtido(IdCedis, 0, Fecha) Then Exit Sub
    If Not ValidaModulo("LIQCARGA", True) Then Exit Sub
    
    If Not IsEmpty(LstDSurtidos) Then
        If LstDSurtidos(3, LstSurtidos.SelectedItem.Index - 1) = "C" Then
            MousePointer = 0
            MsgBox "¡ La Liquidación ya está Aplicada !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
    End If
    
    If MsgBox("¿ Está seguro que desea Aplicar la Liquidación " & LstSurtidos.SelectedItem & " ?. " & Chr(13) & Chr(10) & "Una vez Aplicada no podrá modificarla. ", vbQuestion + vbYesNo, App.Title) = vbNo Then
        Exit Sub
    End If
    
    MousePointer = 11
    
    'valida kardex antes de ...
    StrCmd = "exec up_ActualizaKardex " & IdCedis & ", '" & FormatDate(FechaSel) & "', " & IdSurtido & ", 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    StrCmd = "execute sel_Consignas " & IdCedis & ",0," & IdSurtido & ",'''P''',4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        MousePointer = 0
        MsgBox "¡ No puedes Aplicar la Liquidación, porque tienes Consignas en Proceso de Captura !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    StrCmd = "execute sel_Devolucion " & IdCedis & ", " & IdSurtido & ", 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        MousePointer = 0
        MsgBox "¡ No puedes Aplicar la Liquidación, porque tienes Devoluciones en Proceso de Captura !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    StrCmd = "execute sel_SurtidosVendedores " & IdCedis & ", " & IdSurtido
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Rs.EOF Then
        MousePointer = 0
        MsgBox "¡ No puedes Aplicar la Liquidación, porque no tienes Vendedores asigandos a la Ruta !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    StrCmd = "execute sel_ExistenciaValida " & IdCedis & ", " & IdSurtido & ", 0, 0, 0, 0, 0, 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        If Rs.Fields(0) <> 0 Then
            MousePointer = 0
            MsgBox "¡ No puedes Aplicar la Liquidación, porque la ruta todavía tiene existencias !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
    Else
        MousePointer = 0
        MsgBox "¡ No puedes Aplicar la Liquidación, porque la ruta todavía tiene existencias !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    'EJECUTO MOVS DE CONSIGNAS
    StrCmd = "execute sel_Consignas " & IdCedis & ",0," & IdSurtido & ",'''R'',''D''',5"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        While Not Rs.EOF
            ' Aplicar el movimiento de salida de productos por concepto de Entrega de Consigna
            If Rs.Fields("StatusConsigna") = "R" Then
                StrCmd = "execute up_Consignas " & Rs.Fields("IdCedis").Value & "," & Rs.Fields("IdConsigna").Value & _
                        ",0,''," & Rs.Fields("IdRutaEntrega").Value & ",0,'" & FormatDate(Rs.Fields("FechaEntrega").Value) & "',0,0,0,'',0,0,'','','E',3"
            End If
            ' Aplicar el movimiento de entrada de productos por concepto de Devolucion de Consigna
            If Rs.Fields("StatusConsigna") = "D" Then
                StrCmd = "execute up_Consignas " & Rs.Fields("IdCedis").Value & "," & Rs.Fields("IdConsigna").Value & _
                        ",0,'',0,0,'',0," & Rs.Fields("IdRutaDevolucion").Value & ",0,'" & FormatDate(Rs.Fields("FechaDevolucion").Value) & "',0,0,'','','V',3"
            End If
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
            Rs.MoveNext
        Wend
        
        StrCmd = "execute Route.dbo.sp_importConsignacionesADM " & IdCedis & "," & IdSurtido & ",1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
    End If
    
    'EJECUTA MOVIMIENTOS DE DEVOLUCIÓN DE ENVASE
    StrCmd = "execute sel_Devolucion " & IdCedis & ", " & IdSurtido & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        StrCmd = "execute Route.dbo.sp_importDevolucionesADM " & IdCedis & ", " & IdSurtido
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
    End If
    
    'ENVÍA INFORMACIÓN DE VENTAS A ROUTE
    StrCmd = "execute sel_VentasRoute " & IdCedis & ", " & IdSurtido & ", 0, 0, 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    While Not Rs.EOF
        StrCmd = " execute Route.dbo.sp_importVentasADM " & Rs.Fields(0) & ", " & Rs.Fields(1) & ", " & Rs.Fields(2) & ", " & Rs.Fields(3) & ", " & Rs.Fields(4)
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        Rs.MoveNext
    Wend
        
    'ACTUALIZA SALDOS EN LIQUIDACIÓN
    StrCmd = "exec up_VendedoresSaldosEnvaseClientes " & IdCedis & ", " & IdSurtido & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
        
    'APLICA LIQUIDACIÓN
    StrCmd = "execute up_Surtidos " & IdCedis & ", " & IdSurtido & ", '" & FormatDate(Fecha) & "', " & IdRuta & ", 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    BloqueaSurtido 2
    
    MuestraSurtidos IIf(ChkBaja.Value, 1, 2)
    If LstSurtidos.Visible Then LstSurtidos.SetFocus
    LstSurtidos_ItemClick LstSurtidos.SelectedItem
    
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
On Error GoTo Err_AplicaC:

    If MsgBox("¿ Está seguro que desea Aplicar la Carga ?. " & Chr(13) & Chr(10) & "Una vez Aplicada no podrà modificarla", vbQuestion + vbYesNo, App.Title) = vbNo Then
        Exit Sub
    End If
    
    MousePointer = 11
    StrCmd = "execute up_Surtidos " & IdCedis & ", " & IdSurtido & ", '" & FormatDate(Fecha) & "', " & IdRuta & ", 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    DetalleSurtidos False, 1, True
    
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

Private Sub btnCargaSugerida_Click()
On Error Resume Next

    If Not ValidaModulo("LIQCARGAS", True) Then Exit Sub
    If IdRuta = 0 Then
        MsgBox "¡ Elija una ruta para poder calcular la Carga !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    With AL_CargaSugerida
        .Left = AL_Liquidacion.Left + (AL_Liquidacion.Width - AL_CargaSugerida.Width) / 2
        .Top = AL_Liquidacion.Top + (AL_Liquidacion.Height - AL_CargaSugerida.Height) / 2
        .TxtRuta.Text = "RUTA " & IdRuta
        .DTPFecha.Value = IIf(Day(DTPFecha.Value + 1) = 7, DTPFecha.Value + 2, DTPFecha.Value + 1)
        .Show
    End With

End Sub

Private Sub btnConsignas_Click()
On Error Resume Next
    
    If Not ValidaModulo("CONSIG", True) Then Exit Sub
    
    With CSG_ConsignasInicial
        .Left = AL_Liquidacion.Left + (AL_Liquidacion.Width - .Width) / 2
        .Top = AL_Liquidacion.Top + (AL_Liquidacion.Height - .Height) / 2
        .TxtLiquidacion.Text = IdSurtido
        .TxtRuta.Text = TxtRuta.Text
        .TxtFecha = DTPFecha.Value
        .Show
    End With

End Sub

Private Sub BtnDelete_Click()
On Error Resume Next
    MsgBox "¡ No puedes Eliminar partidas de la Carga que ya ha sido Aplicada !", vbInformation + vbOKOnly, App.Title
End Sub

Private Sub btnDeleteC_Click()
On Error Resume Next
    If Not IsEmpty(LstDSurtido) Then
        If MsgBox("¿ Está seguro que desea eliminar la partida seleccionada ?." & Chr(13) & Chr(10) & Trim(LstDSurtido(1, LstSurtido.SelectedItem.Index - 1)) & " - " & Trim(LstDSurtido(2, LstSurtido.SelectedItem.Index - 1)) & " Liquidación: " & LstDSurtido(3, LstSurtido.SelectedItem.Index - 1), vbQuestion + vbYesNo, App.Title) = vbYes Then
            TxtCantidadS_KeyPress 13
            Exit Sub
        End If
    Else
        MsgBox "¡ Selecciona una partida a Eliminar !", vbInformation + vbOKOnly, App.Title
    End If
End Sub

Private Sub btnDevolucion_Click()
On Error Resume Next
    
    If Not ValidaModulo("DEVOL", True) Then Exit Sub
    
    With AL_Devolucion
        .LblPedido(1).Caption = "Liquidación " & Format(IdSurtido, "0000000")
        .Left = AL_Liquidacion.Left + (AL_Liquidacion.Width - .Width) / 2
        .Top = AL_Liquidacion.Top + (AL_Liquidacion.Height - .Height) / 2
        .Show
    End With
End Sub

Private Sub btnEfectivo_Click()
On Error Resume Next
    
    With AL_Efectivo
        .Left = AL_Liquidacion.Left + (AL_Liquidacion.Width - AL_Efectivo.Width) / 2
        .Top = AL_Liquidacion.Top + (AL_Liquidacion.Height - AL_Efectivo.Height) / 2
        .TxtLiquidacion.Text = LstSurtidos.SelectedItem
        .TxtRuta.Text = TxtRuta.Text
        .TxtFecha = DTPFecha.Value
        .Show
    End With
End Sub

Private Sub btnEliminaCarga_Click()
On Error GoTo Err_EliminaCarga:
    
    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    If Not ValidaModulo("LIQCARGA", True) Then Exit Sub

    If ValidaBloqueaSurtido And Not AccesaSurtido Then
        MsgBox "¡ Esta Ruta ya está siendo Liquidada por otro Usuario !. ", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
      If LstCargas.SelectedItem Is Nothing Then
        
    
    MsgBox "¡Tienes Que tener por lo menos una carga!", vbCritical, App.Title
        
    Exit Sub
    End If
    
    If MsgBox("¡ Al Eliminar la Carga, es posible que el Inventario de la Ruta no sea suficiente para cubrir las Devoluciones y las Ventas !" & Chr(13) & Chr(10) & " ¿ Estás seguro que deseas Eliminar la Carga " & Trim(LstCargas.SelectedItem) & " ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    StrCmd = "execute up_Cargas " & IdCedis & ", " & IdSurtido & ", " & IdCarga & ", '" & FormatDate(Fecha) & "', " & IdRuta & ", 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MuestraCargas
    
No_Err_EliminaCarga:
    MousePointer = 0
    Exit Sub
    
Err_EliminaCarga:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_EliminaCarga:

End Sub

Private Sub btnEliminar_Click()
On Error GoTo Err_Eliminar:

    If Not ValidaDiaySurtido(IdCedis, 0, Fecha) Then Exit Sub
    If Not ValidaModulo("LIQCARGA", True) Then Exit Sub

    If IdSurtido = 0 Then
        MsgBox "¡ Seleccione una Liquidación a Eliminar !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    'If Not ValidaDiaySurtido(IdCedis, IdSurtido, IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy"))) Then Exit Sub
    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    
    If MsgBox("¿ Está seguro que desea eliminar la Liquidación " & LstSurtidos.SelectedItem & " ?", vbQuestion + vbYesNo, App.Title) = vbNo Then
        Exit Sub
'    Else
'        If MsgBox("La información se perderá. ¿ Desea continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then
'            Exit Sub
'        End If
    End If

    MousePointer = 11
    StrCmd = "execute up_Surtidos " & IdCedis & ", " & IdSurtido & ", '" & FormatDate(Fecha) & "', " & IdRuta & ", 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    StrCmd = "execute up_ActualizaKardex " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MuestraSurtidos IIf(ChkBaja.Value, 1, 2)
    MuestraCargas
    
    MousePointer = 0
    MsgBox "¡ Liquidación Eliminado !", vbInformation + vbOKOnly, App.Title
    
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

    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    If Not ValidaModulo("LIQVTA", True) Then Exit Sub
    
    If Cancela Then
        CancelaVenta
        btnEliminarVenta.Picture = LoadPicture(App.Path & "\Imagenes\Botones\btnEliminar.jpg")
        Cancela = False
        'btnEliminarVenta.Caption = "&Eliminar"
        btnNuevaVenta.Visible = True: btnActualizaVenta.Visible = False
    Else
        If Not IsEmpty(LstFacturas) Then
            If MsgBox("¿ Está seguro que desea Eliminar la Factura " & LstDFacturas(3, LstFacturas.SelectedItem.Index - 1) & " - " & LstDFacturas(4, LstFacturas.SelectedItem.Index - 1) & " del Cliente " & Chr(13) & Chr(10) & LstDFacturas(7, LstFacturas.SelectedItem.Index - 1) & " por " & FormatCurrency(LstDFacturas(10, LstFacturas.SelectedItem.Index - 1), 2, vbTrue) & " ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
'                If MsgBox("La información se perderá. ¿ Desea continuar ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
            MousePointer = 11
            
                    StrCmd = "execute sel_VentasRoute " & IdCedis & ", " & IdSurtido & ", " & _
                            LstDFacturas(2, LstFacturas.SelectedItem.Index - 1) & ", " & _
                            LstDFacturas(4, LstFacturas.SelectedItem.Index - 1) & ", 2"
                    If Rs.State Then Rs.Close
                    Rs.Open StrCmd, Cnn
                    If Not Rs.EOF Then
                        If Rs.Fields(8) Then
                            MousePointer = 0
                            MsgBox "¡ No puede Eliminar una Venta que se registró por Liquidación de una Consigna !", vbInformation + vbOKOnly, App.Title
                            Exit Sub
                        End If
                    End If
            
                    StrCmd = "execute up_Ventas " & IdCedis & ", " & IdSurtido & ", " & _
                            LstDFacturas(2, LstFacturas.SelectedItem.Index - 1) & ", " & _
                            LstDFacturas(4, LstFacturas.SelectedItem.Index - 1) & ", '" & LstDFacturas(3, LstFacturas.SelectedItem.Index - 1) & "', '" & FormatDate(Fecha) & "', 0, 0, 3"
                    If Rs.State Then Rs.Close
                    Rs.Open StrCmd, Cnn
                    
                    StrCmd = "execute up_SurtidosDenominacion " & IdCedis & ", " & IdSurtido & ", '', '', 0, '', 0, 2"
                    If Rs.State Then Rs.Close
                    Rs.Open StrCmd, Cnn
                    
                    'valida kardex antes de ...
                    StrCmd = "exec up_ActualizaKardex " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 2"
                    If Rs.State Then Rs.Close
                    Rs.Open StrCmd, Cnn
            MousePointer = 0
                    MuestraFacturas
'                    MsgBox "¡ Factura Eliminada !", vbInformation + vbOKOnly, App.Title
'                End If
            End If
        End If
        btnEliminarVenta.Picture = LoadPicture(App.Path & "\Imagenes\Botones\btnEliminar.jpg")
        Cancela = False
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
On Error Resume Next
    If Not TxtFolioC.Locked Then 'Obtiene Folio Siguiente
        StrCmd = "execute sel_Folios " & IdCedis & ", 1, 0, 3"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            TxtSerieC.Text = Rs.Fields(0): TxtFolioC.Text = Rs.Fields(1): TxtFolioC.SetFocus
        End If
    Else 'Imprime Factura Global
        With CC_OpcImpFactura
            .Ventana = False
            .ChkImpresion(3).Enabled = True
            .ChkImpresion(3).Value = 1
            .TxtFolio.Locked = False
            .OptCons = 0
            .strIds = FormatDate(FechaSel)
            .strFolios = Trim(TxtFolioC.Text)
            .OptPiezas(0).Caption = Etiqueta01
            .OptPiezas(1).Caption = Etiqueta02
            .Left = Me.Left + (Me.Width - .Width) / 2
            .Top = Me.Top + (Me.Height - .Height) / 2
            .Show
        End With
'            StrCmd = "execute sel_VentasContado " & IdCedis & ", '" & FormatDate(FechaSel) & "', 2"
'            If RsC.State Then RsC.Close
'            RsC.Open StrCmd, Cnn
            
    End If
End Sub

Private Sub btnFacturar_Click()
On Error Resume Next
    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    If Not ValidaModulo("LIQVTA", True) Then Exit Sub
        
    With AL_Facturar
        .TxtCliente.Text = LstDFacturas(6, LstFacturas.SelectedItem.Index - 1) & " - " & LstDFacturas(7, LstFacturas.SelectedItem.Index - 1)
        .TxtRFC.Text = LstDFacturas(15, LstFacturas.SelectedItem.Index - 1)
        .TxtSucursal.Text = LstDFacturas(13, LstFacturas.SelectedItem.Index - 1) & " (CB: " & LstDFacturas(11, LstFacturas.SelectedItem.Index - 1) & ") " & LstDFacturas(12, LstFacturas.SelectedItem.Index - 1)
        
        .TxtRemision.Text = LstDFacturas(3, LstFacturas.SelectedItem.Index - 1) & " - " & LstDFacturas(4, LstFacturas.SelectedItem.Index - 1) & " | " & FormatCurrency(LstDFacturas(10, LstFacturas.SelectedItem.Index - 1), 2, vbTrue)
        
        .IdTipoVenta = LstDFacturas(2, LstFacturas.SelectedItem.Index - 1)
        .Folio = LstDFacturas(4, LstFacturas.SelectedItem.Index - 1)
        .Serie = LstDFacturas(3, LstFacturas.SelectedItem.Index - 1)
                
        .Left = AL_Liquidacion.Left + ((AL_Liquidacion.Width - .Width) / 2)
        .Top = AL_Liquidacion.Top + ((AL_Liquidacion.Height - .Height) / 2)
        .Show
    End With
End Sub

Private Sub btnImportar_Click()
On Error GoTo Err_ImportaC:

    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) And Not ImportarCargaSugerida Then Exit Sub
    If Not ValidaModulo("LIQCARGAP", True) Then Exit Sub
    
     If LstCargas.ListItems.Count = 0 Then
        MsgBox "¡ No existen cargas para este surtido !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If MsgBox("El sistema creará un nuevo folio de carga con la información de carga calculada" & Chr(13) & Chr(10) & "¿ Estás seguro que deseas continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    MousePointer = 11
    
    StrCmd = "execute up_CargasSugeridasDetalle " & IdCedis & ", " & IdRuta & ", '" & FormatDate(Fecha) & "', '0', 0, '', 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
        
    LstSurtidos_ItemClick LstSurtidos.SelectedItem
    LstCargas.ListItems(LstCargas.ListItems.Count).Selected = True
    LstCargas_ItemClick LstCargas.SelectedItem
    SSTab_Click 0

No_Err_ImportaC:
    MousePointer = 0
    MsgBox "¡ Importación de Carga Sugerida terminada !", vbInformation + vbOKOnly, App.Title
    Exit Sub
    
Err_ImportaC:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_ImportaC:

End Sub

Private Sub btnImprimeC_Click()
On Error GoTo Err_ImpC:

Dim PicturePath As String

    With AL_RptCarga
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
        .LblCedis.Caption = IdCedis & " - " & NomCedis
        .LblDatos.Caption = Format(Fecha, "dd ""de"" MMMM ""de"" yyyy ")
        .LblFolio.Caption = Format(IdSurtido, "0000000")
        .LblStatus.Caption = StatusDesc
        .LblRuta.Caption = IdRuta
        .LblCarga.Caption = Format(IdCarga, "00")
        
        If Route And OptImprimir(1).Value Then
            PicturePath = GeneraStringCB(IdCedis, IdSurtido, IdCarga, IdRuta)
            .ImgBC.Picture = LoadPicture(PicturePath)
        Else
            .ReportFooter.Visible = False
        End If
        
        StrCmd = "execute sel_SurtidosVendedores " & IdCedis & ", " & IdSurtido
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
    
    If FileExists(PicturePath) And Trim(PicturePath) <> "" And Trim(PicturePath) <> "Error.jpg" Then Kill PicturePath
    
    OptImprimir.Item(1).Value = True
    
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

    btnImprimeLiquidacion_Click

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
    
    StrCmd = "exec up_VendedoresSaldosEnvaseClientes " & IdCedis & ", " & IdSurtido & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
        
    StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 0, 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Rs.EOF Then
        MsgBox "¡ No hay productos asigandos a esta Liquidación !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
        

Dim SubEmpresa
        
    StrCmd = "execute sel_SubEmpresas " & IdCedis
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        SubEmpresa = Rs.Fields(0)
    Else
        SubEmpresa = 0
    End If
        
    If SubEmpresa <= 1 Then
        
        If LstConfiguraLiquidacion(6) Then
            If ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then
                StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 0, 13"
                If RsC3.State Then RsC3.Close
                RsC3.Open StrCmd, Cnn
            End If
            
            With AL_RptCreditosCobranza
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                .LblCedis.Caption = IdCedis & " - " & NomCedis
                .LblDatos.Caption = Format(Fecha, "dd ""de"" MMMM ""de"" yyyy ")
                .LblFolio.Caption = Format(IdSurtido, "0000000")
                .LblStatus.Caption = StatusDesc
                .LblRuta.Caption = IdRuta
    
                StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 0, 14"
                If RsC3.State Then RsC3.Close
                RsC3.Open StrCmd, Cnn
    
                If Not Rs.EOF Then
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = RsC3
                Else
                    Exit Sub
                End If
    
                .Printer.Orientation = ddOPortrait
                .Printer.PaperSize = 1
                .Show
            End With
        End If
        
        With AL_RptLiquidacion
            .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
            .LblCedis.Caption = IdCedis & " - " & NomCedis
            .LblDatos.Caption = Format(Fecha, "dd ""de"" MMMM ""de"" yyyy ")
            .LblFolio.Caption = Format(IdSurtido, "0000000")
            .LblStatus.Caption = StatusDesc
            .LblRuta.Caption = IdRuta
    
            StrCmd = "execute sel_Denominacion " & IdCedis & ", " & IdSurtido & ", 0, '', 'MXP', 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            .LblEfectivo.Caption = FormatCurrency(0, 2, vbTrue)
            .LblSaldo.Caption = FormatCurrency(0, 2, vbTrue)
            If Not Rs.EOF Then
                .LblEfectivo.Caption = FormatCurrency(Rs.Fields(1) + Rs.Fields(3), 2, vbTrue)
                .LblSaldo.Caption = FormatCurrency(Rs.Fields(2), 2, vbTrue)
                Select Case Rs.Fields(2)
                    Case 0: .LblSaldoE.Caption = "Saldo"
                    Case Else: .LblSaldoE.Caption = IIf(Rs.Fields(2) < 0, "Faltante", "Sobrante")
                End Select
            End If
            
            StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 0, 4"
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
    Else
    
        If ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then
            StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 0, 13"
            If RsC3.State Then RsC3.Close
            RsC3.Open StrCmd, Cnn
        End If
        
        With AL_RptCreditosCobranza
            .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
            .LblCedis.Caption = IdCedis & " - " & NomCedis
            .LblDatos.Caption = Format(Fecha, "dd ""de"" MMMM ""de"" yyyy ")
            .LblFolio.Caption = Format(IdSurtido, "0000000")
            .LblStatus.Caption = StatusDesc
            .LblRuta.Caption = IdRuta

            StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 0, 14"
            If RsC3.State Then RsC3.Close
            RsC3.Open StrCmd, Cnn

            If Not Rs.EOF Then
                .object.DataSrc.DataSourceName = Cnn
                .object.DataSrc.Recordset = RsC3
            Else
                Exit Sub
            End If

            .Printer.Orientation = ddOPortrait
            .Printer.PaperSize = 1
            .Show
        End With
    
        With AL_RptRepLiquidacionSubEmpresa
            .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
            .LblCedis.Caption = IdCedis & " - " & NomCedis
            .LblDatos.Caption = Format(Fecha, "dd ""de"" MMMM ""de"" yyyy ")
    
            StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 0, 10"
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
    End If
        
'    With AL_RptLiquidacion
'        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
'        .LblCedis.Caption = IdCedis & " - " & NomCedis
'        .LblDatos.Caption = Format(Fecha, "dd ""de"" MMMM ""de"" yyyy ")
'        .LblFolio.Caption = Format(IdSurtido, "0000000")
'        .LblStatus.Caption = StatusDesc
'        .LblRuta.Caption = IdRuta
'
'        StrCmd = "execute sel_Denominacion " & IdCedis & ", " & IdSurtido & ", 0, '', 'MXP', 3"
'        If Rs.State Then Rs.Close
'        Rs.Open StrCmd, Cnn
'        .LblEfectivo.Caption = FormatCurrency(0, 2, vbTrue)
'        .LblSaldo.Caption = FormatCurrency(0, 2, vbTrue)
'        If Not Rs.EOF Then
'            .LblEfectivo.Caption = FormatCurrency(Rs.Fields(1) + Rs.Fields(3), 2, vbTrue)
'            .LblSaldo.Caption = FormatCurrency(Rs.Fields(2), 2, vbTrue)
'            Select Case Rs.Fields(2)
'                Case 0: .LblSaldoE.Caption = "Saldo"
'                Case Else: .LblSaldoE.Caption = IIf(Rs.Fields(2) < 0, "Faltante", "Sobrante")
'            End Select
'        End If
'
'        StrCmd = "execute sel_PreciosRuta " & IdCedis & ", " & IdRuta & ", 1"
'        If Rs.State Then Rs.Close
'        Rs.Open StrCmd, Cnn
'        If Not Rs.EOF Then
'            '*********
'            '.LblLista.Caption = IIf(Trim(Rs.Fields(3)) = "", Trim(Rs.Fields(2)), Trim(Rs.Fields(3)))
'        End If
'
'        StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 0, 4"
'        If Rs.State Then Rs.Close
'        Rs.Open StrCmd, Cnn
'
'        If Not Rs.EOF Then
'            .object.DataSrc.DataSourceName = Cnn
'            .object.DataSrc.Recordset = Rs
'        End If
'
'        .Printer.Orientation = ddOPortrait
'        .Printer.PaperSize = 1
'        .Show
'    End With
    
No_Err_ImpLiq:
    MousePointer = 0
    Exit Sub
    
Err_ImpLiq:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_ImpLiq:
    
End Sub

Private Sub btnImprimePedido_Click()
On Error Resume Next
    
    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    If Not ValidaModulo("PEDID", True) Then Exit Sub
    
    With AL_Pedidos
         .Seleccionar = True
         .Caption = "Captura de Pedidos"
         .Top = MenuAlmacen.Top + MenuAlmacen.Height
         .Left = MenuAlmacen.Left
         .btnSeleccionar.Visible = True
         .Show
         .ZOrder (0)
    End With
End Sub

Private Sub btnImprimirVenta_Click()
On Error GoTo Err_ImpFact:

    If IsEmpty(LstFacturas) Or LstFacturas.ListItems.Count <= 0 Then Exit Sub
    
    Select Case LstConfiguraLiquidacion(8)
        Case "MODELOORIENTE":
            With AL_RptFacturaModelo
                AL_Facturas.IdTipoVenta = LstDFacturas(2, LstFacturas.SelectedItem.Index - 1)
                AL_Facturas.Folio = LstDFacturas(4, LstFacturas.SelectedItem.Index - 1)
                
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                .LblCedis.Caption = IdCedis & " - " & NomCedis
                
                .LblFecha.Caption = Format(CDate(LstDFacturas(IIf(Not LstConfiguraLiquidacion(7), 14, 15), LstFacturas.SelectedItem.Index - 1)), "DD-MMM-YYYY")
                .LblRFC = LstDFacturas(IIf(Not LstConfiguraLiquidacion(7), 15, 16), LstFacturas.SelectedItem.Index - 1)
                .LblNombre = LstDFacturas(IIf(Not LstConfiguraLiquidacion(7), 12, 13), LstFacturas.SelectedItem.Index - 1)
                .LblDireccion = LstDFacturas(IIf(Not LstConfiguraLiquidacion(7), 16, 17), LstFacturas.SelectedItem.Index - 1)
                .LblFolio = LstDFacturas(3, LstFacturas.SelectedItem.Index - 1) & " " & Format(LstDFacturas(4, LstFacturas.SelectedItem.Index - 1), "000000")
                .LblTipoVenta = "Venta de " & IIf(LstDFacturas(2, LstFacturas.SelectedItem.Index - 1) = "1", "Contado", "Crédito")
                
                AL_Facturas.MuestraDetalle True
                If Not RsC.EOF Then
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = RsC
                End If
                
                .Printer.Orientation = ddOPortrait
                .Printer.PaperSize = 1
                .Show
            End With
        
        Case Else
            With AL_RptFactura
                AL_Facturas.IdTipoVenta = LstDFacturas(2, LstFacturas.SelectedItem.Index - 1)
                AL_Facturas.Folio = LstDFacturas(4, LstFacturas.SelectedItem.Index - 1)
                
                .LblFecha.Caption = Format(Fecha, "dd/mm/yyyy")
                .LblRFC.Caption = LstDFacturas(15, LstFacturas.SelectedItem.Index - 1)
                .LblNombre.Caption = LstDFacturas(7, LstFacturas.SelectedItem.Index - 1)
                .LblDireccion.Caption = LstDFacturas(16, LstFacturas.SelectedItem.Index - 1)
                
                AL_Facturas.MuestraDetalle True
                If Not RsC.EOF Then
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = RsC
                End If
                
                .Printer.Orientation = ddOPortrait
                .Printer.PaperSize = 1
                .Show
            End With
        
    End Select
    
    
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
        
If Not ValidaModulo("LIQLIQ", True) Then Exit Sub
       
Dim LstExistenciaDia, LstStatusSurtido
        
    'If FechaSel = "12:00:00 a.m." Then FechaSel = UltimoDia    'Se comenta porque marca error

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

Private Sub btnNuevaCarga_Click()
On Error GoTo Err_NuevaCarga:
    
    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    If Not ValidaModulo("LIQCARGA", True) Then Exit Sub

    If ValidaBloqueaSurtido And Not AccesaSurtido Then
        MsgBox "¡ Esta Ruta ya está siendo Liquidada por otro Usuario !. ", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    StrCmd = "execute up_Cargas " & IdCedis & ", " & IdSurtido & ", " & IdCarga & ", '" & FormatDate(Fecha) & "', " & IdRuta & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MuestraCargas
 
No_Err_NuevaCarga:
    MousePointer = 0
    Exit Sub
    
Err_NuevaCarga:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_NuevaCarga:

End Sub

Private Sub btnNuevaVenta_Click()
On Error GoTo Err_NuevaFact:
    
    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    If Not ValidaModulo("LIQVTA", True) Then Exit Sub
    
    IdSucursal = 0: IdCliente = 0

    StrCmd = "execute sel_Ventas " & IdCedis & ", " & IdSurtido & ", 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    If Not Rs.EOF Then
        If Rs.Fields(0) > 0 Or ObtieneTipoRuta = 4 Then
            CancelaVenta
            Cancela = True
            btnEliminarVenta.Picture = LoadPicture(App.Path & "\Imagenes\Botones\btnCancelar.jpg")
            'btnEliminarVenta.Caption = "&Cancelar"
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
    
    If Not ValidaDiaySurtido(IdCedis, 0, Fecha) And Not ImportarCargaSugerida Then Exit Sub
    If Not ValidaModulo("LIQCARGA", True) Then Exit Sub
        
    If Trim(TxtRuta.Text) = "" Then Exit Sub
    If IdRuta = 0 Then Exit Sub
    
    IdRuta = IIf(Trim(TxtRuta.Text) = "", 0, Trim(TxtRuta.Text))
    If Not ValidaRuta Then
        LblSurtidos.Caption = "La Ruta " & TxtRuta.Text & " no existe"
        LblSurtidos.Visible = True
        LimpiaListas
        MsgBox "¡ La Ruta " & IdRuta & " no existe!.", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
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
    LstSurtidos_ItemClick LstSurtidos.SelectedItem
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

'Dim IPRoute, BDRoute,
Dim LCarga, LCargaDetalle, T1, T2

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

Private Sub btnResumen_Click(Index As Integer)
On Error Resume Next
    
    With AL_Resumen
        .Left = AL_Liquidacion.Left + (AL_Liquidacion.Width - .Width) / 2
        .Top = AL_Liquidacion.Top + (AL_Liquidacion.Height - .Height) / 2
        .TxtLiquidacion.Text = LstSurtidos.SelectedItem
        .TxtRuta.Text = TxtRuta.Text
        .TxtFecha = DTPFecha.Value
        .Show
    End With

End Sub

Private Sub ChkBaja_Click()
On Error Resume Next
    IdSurtido = 0: Status = "": IdCarga = 0: StatusC = ""
    MuestraSurtidos IIf(ChkBaja.Value, 1, 2)
End Sub

Private Sub cmbTipoVenta_Click()
On Error Resume Next
    If Not IsEmpty(LstDTipoVenta) And btnActualizaVenta.Visible And cmbTipoVenta.ListIndex > 0 Then
        StrCmd = "execute sel_Folios " & IdCedis & ", " & LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) & ", 0, 5"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        If LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) = 1 Then
            StrCmd = "execute sel_ClientesFacturas " & IdCedis & ", 0, '', '', 2"
            If Rs2.State Then Rs2.Close
            Rs2.Open StrCmd, Cnn
            If Not Rs2.EOF Then
                TxtIdCliente.Text = Rs2.Fields(0)
                TxtRFC.Text = Trim(Rs2.Fields(2))
                LstClientes_ItemClick LstClientes.SelectedItem
            Else
                TxtIdCliente.Text = "999999": LstClientes_ItemClick LstClientes.SelectedItem
            End If
            'TxtRFC.Locked = False: TxtIdCliente.Locked = True: 'TxtRazonSocial.Locked = True
        Else
            'TxtRFC.Locked = False: TxtIdCliente.Locked = False: 'TxtRazonSocial.Locked = False
        End If
        
        If Not Rs.EOF Then
            TxtSerie.Text = Rs.Fields(0): TxtFolio.Text = Rs.Fields(1): TxtRFC.SetFocus
        End If
    End If
End Sub

Private Sub DTPFecha_Change()
On Error Resume Next
    Dim FechaMaxima As Date
    FechaMaxima = Date + 2 'IIf(Day(Date + 1) = 7, Date + 2, Date + 1)

    LimpiaListas
    IdSurtido = 0: Status = "": IdCarga = 0: StatusC = ""
    If DTPFecha.Value > FechaMaxima Then
        DTPFecha.Value = Date
        Exit Sub
    End If
    'Fecha = IIf(BIdioma = "us_english", Format(DTPFecha.Value, "mm/dd/yyyy"), Format(DTPFecha.Value, "dd/mm/yyyy")): Mes = Month(DTPFecha.Value): Agno = Year(DTPFecha.Value)
    Fecha = DTPFecha.Value: Mes = Month(DTPFecha.Value): Agno = Year(DTPFecha.Value)
End Sub

Private Sub DTPFecha_Validate(Cancel As Boolean)
On Error Resume Next
    'Fecha = IIf(BIdioma = "us_english", Format(DTPFecha.Value, "mm/dd/yyyy"), Format(DTPFecha.Value, "dd/mm/yyyy")): Mes = Month(DTPFecha.Value): Agno = Year(DTPFecha.Value)
    Fecha = DTPFecha.Value: Mes = Month(DTPFecha.Value): Agno = Year(DTPFecha.Value)
End Sub

Private Sub DTPFechaSel_Change()
On Error Resume Next
    DTPFechaSel.Value = MonthV.Value
End Sub

Private Sub Form_Activate()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
End Sub

Private Sub Form_Load()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    AccesaSurtido = False
    SSTab.Tab = 4
    SSTab_Click 4
    DTPFecha.Value = Date
    LlenaCombo
    btnConsignas.Visible = IIf(Not ValidaModulo("CONSIG", False), False, True)
    btnDevolucion.Visible = IIf(Not ValidaModulo("DEVOL", False), False, True)
End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    BloqueaSurtido 2
End Sub

Private Sub FrmOpt_DblClick(Index As Integer)
On Error Resume Next

'    MousePointer = 11
'
'    If Not OpenConn2("192.1.1.189", "Route", userdb, passworddb) Then
'        MousePointer = 0
'        MsgBox "¡ No se pudo establecer conexión con Route !", vbInformation + vbOKOnly, App.Title
'        Exit Sub
'    End If
'    Cnn2.CommandTimeout = 0
'
'    StrCmd = "execute tmpExport "
'    If Rs2.State Then Rs2.Close
'    Rs2.Open StrCmd, Cnn2
'
'    MousePointer = 0
'    'MsgBox "¡ Sp ejecutado !", vbInformation + vbOKOnly, App.Title
End Sub

Private Sub LstCargas_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error GoTo Err_CargaFolios:
    
    If IsEmpty(LstDCargas) Then Exit Sub
    
    IdCarga = CLng(LstCargas.SelectedItem)
    StatusC = LstDCargas(2, LstCargas.SelectedItem.Index - 1)
    StatusDescC = LstDCargas(1, LstCargas.SelectedItem.Index - 1)
    'LstSurtidos_DblClick
    
No_Err_CargaFolios:
    Exit Sub
    
Err_CargaFolios:
    IdCarga = 0
    Status = ""
    GoTo No_Err_CargaFolios:
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

Private Sub LstFacturas_DblClick()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    
    With AL_Facturas
        .TxtTipoVenta.Text = LstDFacturas(5, LstFacturas.SelectedItem.Index - 1)
        .TxtSerie.Text = LstDFacturas(3, LstFacturas.SelectedItem.Index - 1)
        .TxtFolio.Text = LstDFacturas(4, LstFacturas.SelectedItem.Index - 1)
        
        .TxtCliente.Text = LstDFacturas(6, LstFacturas.SelectedItem.Index - 1) & " - " & LstDFacturas(7, LstFacturas.SelectedItem.Index - 1)
        .TxtRFC.Text = LstDFacturas(IIf(Not LstConfiguraLiquidacion(7), 15, 16), LstFacturas.SelectedItem.Index - 1)
        .TxtSucursal.Text = LstDFacturas(IIf(Not LstConfiguraLiquidacion(7), 13, 14), LstFacturas.SelectedItem.Index - 1) & " (CB: " & LstDFacturas(IIf(Not LstConfiguraLiquidacion(7), 11, 12), LstFacturas.SelectedItem.Index - 1) & ") " & LstDFacturas(IIf(Not LstConfiguraLiquidacion(7), 12, 13), LstFacturas.SelectedItem.Index - 1)
        .TxtListaPrecios.Text = LstDFacturas(IIf(Not LstConfiguraLiquidacion(7), 18, 19), LstFacturas.SelectedItem.Index - 1) & " - " & LstDFacturas(IIf(Not LstConfiguraLiquidacion(7), 19, 20), LstFacturas.SelectedItem.Index - 1)
                
        .Left = AL_Liquidacion.Left
        .Top = AL_Liquidacion.Top '(Menu.Height + Liquidacion.Height - .Height) / 2
        .IdTipoVenta = LstDFacturas(2, LstFacturas.SelectedItem.Index - 1)
        .Folio = LstDFacturas(4, LstFacturas.SelectedItem.Index - 1)
        .Serie = LstDFacturas(3, LstFacturas.SelectedItem.Index - 1)
        .IdCliente = LstDFacturas(6, LstFacturas.SelectedItem.Index - 1)
        
        .RFC = LstDFacturas(IIf(Not LstConfiguraLiquidacion(7), 15, 16), LstFacturas.SelectedItem.Index - 1)
        .Nombre = LstDFacturas(IIf(Not LstConfiguraLiquidacion(7), 12, 13), LstFacturas.SelectedItem.Index - 1)
        .Tel = LstDFacturas(IIf(Not LstConfiguraLiquidacion(7), 17, 18), LstFacturas.SelectedItem.Index - 1)
        .Direccion = LstDFacturas(IIf(Not LstConfiguraLiquidacion(7), 16, 17), LstFacturas.SelectedItem.Index - 1)
        .FolioRem = LstDFacturas(3, LstFacturas.SelectedItem.Index - 1) & " " & Format(LstDFacturas(4, LstFacturas.SelectedItem.Index - 1), "000000")
                
        .MuestraDetalle False
        .MuestraTotales False
        .TxtIdProd.SetFocus
        .Show
    End With
End Sub

Private Sub LstFacturas_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    If Not IsEmpty(LstDFacturas) Or LstFacturas.ListItems.Count > 0 Then
        
        If btnActualizaVenta.Visible Then
            Cancela = True
            btnEliminarVenta_Click
        End If
        
        TxtSerie.Text = LstDFacturas(3, LstFacturas.SelectedItem.Index - 1)
        TxtFolio.Text = LstDFacturas(4, LstFacturas.SelectedItem.Index - 1)
        cmbTipoVenta.ListIndex = SearchInList(LstDTipoVenta, LstDFacturas(2, LstFacturas.SelectedItem.Index - 1), 0)
        TxtSubtotal.Text = FormatCurrency(LstDFacturas(IIf(Not LstConfiguraLiquidacion(7), 8, 9), LstFacturas.SelectedItem.Index - 1), 2, vbTrue)
        TxtIva.Text = FormatCurrency(LstDFacturas(IIf(Not LstConfiguraLiquidacion(7), 9, 10), LstFacturas.SelectedItem.Index - 1), 2, vbTrue)
        TxtTotal.Text = FormatCurrency(LstDFacturas(IIf(Not LstConfiguraLiquidacion(7), 10, 11), LstFacturas.SelectedItem.Index - 1), 2, vbTrue)
                
        TxtRFC.Text = LstDFacturas(IIf(Not LstConfiguraLiquidacion(7), 13, 14), LstFacturas.SelectedItem.Index - 1)
        
    End If
End Sub

Private Sub LstSurtidos_DblClick()
On Error Resume Next

    If IsEmpty(LstDSurtidos) Then Exit Sub
    LstSurtidos_ItemClick LstSurtidos.SelectedItem
    
End Sub

Private Sub MuestraCargas()
On Error Resume Next

    StrCmd = "execute sel_SurtidosCargas " & IdCedis & ", " & IdSurtido & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCargas = GetDataLVL(Rs, LstCargas, 1, 2, "6|0")
    
    LstCargas_ItemClick LstCargas.SelectedItem
    
End Sub

Private Sub LstSurtidos_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error GoTo Err_Carga:
    
    If IsEmpty(LstDSurtidos) Then Exit Sub
    
    IdSurtido = CLng(LstSurtidos.SelectedItem)
    Status = LstDSurtidos(3, LstSurtidos.SelectedItem.Index - 1)
    StatusDesc = LstDSurtidos(2, LstSurtidos.SelectedItem.Index - 1)
    'LstSurtidos_DblClick
    
    BloqueaSurtido 1
        
    StrCmd = "execute sel_SurtidosVendedores " & IdCedis & ", " & IdSurtido
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    'habilita búsqueda de vendedores
    HabBusqueda True
    LstDVendedoresAsignados = GetDataLVL(Rs, LstVendedoresAsignados, 3, 5, "0|0|0")
    
    MuestraCargas

No_Err_Carga:
    Exit Sub
    
Err_Carga:
    IdSurtido = 0: Status = "": IdCarga = 0: StatusC = ""
    GoTo No_Err_Carga:
End Sub

Private Sub LstSurtidos_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 Or KeyAscii = 32 Then LstSurtidos_DblClick
End Sub

Private Sub LstVendedores_DblClick()

On Error GoTo Err_AgregaV:
    
    If Not ValidaModulo("LIQCARGA", True) Then Exit Sub
    If IsEmpty(LstDVendedores) Or LstVendedores.ListItems.Count = 0 Then Exit Sub

    If Status <> "P" Then
        MsgBox "¡ La Carga " & LstSurtidos.SelectedItem & " no se puede modificar porque ya está Aplicado o dado de Baja !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If ValidaBloqueaSurtido And Not AccesaSurtido Then
        MsgBox "¡ Esta Ruta ya está siendo Liquidada por otro Usuario !. ", vbInformation + vbOKOnly, App.Title
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
On Error Resume Next
    If KeyAscii = 13 Then LstVendedores_DblClick
End Sub

Private Sub LstVendedoresAsignados_DblClick()

On Error GoTo Err_QuitaV:

    If Not ValidaModulo("LIQCARGA", True) Then Exit Sub
    If IsEmpty(LstDVendedoresAsignados) Or LstVendedoresAsignados.ListItems.Count = 0 Then Exit Sub

    If Status <> "P" Then
        MsgBox "¡ La Carga " & LstSurtidos.SelectedItem & " no se puede modificar porque ya está Aplicado o dado de Baja !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If ValidaBloqueaSurtido And Not AccesaSurtido Then
        MsgBox "¡ Esta Ruta ya está siendo Liquidada por otro Usuario !. ", vbInformation + vbOKOnly, App.Title
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
On Error Resume Next
    
    If (SSTab.Tab >= 1 And SSTab.Tab <= 3 And IdSurtido = 0) Or (SSTab.Tab = 1 And IdCarga = 0) Or (SSTab.Tab = 1 And LstCargas.SelectedItem Is Nothing) Then
        MsgBox "¡ Seleccione una Liquidación y una Carga !", vbInformation + vbOKOnly, App.Title
        SSTab.Tab = 0
        Exit Sub
    End If
    
    If SSTab.Tab >= 1 And SSTab.Tab <= 3 And (IsEmpty(LstVendedoresAsignados) Or LstVendedoresAsignados.ListItems.Count = 0) Then
        MsgBox "¡ Captura un Vendedor para la Liquidación !", vbInformation + vbOKOnly, App.Title
        SSTab.Tab = 0
        Exit Sub
    End If
    
    If SSTab.Tab > 0 And SSTab.Tab <= 3 Then LblSurtido(SSTab.Tab - 1).Caption = "Liquidación " & Format(IdSurtido, "0000000") & " - Ruta " & IdRuta & " - " & Format(Fecha, "DDDD dd ""de"" MMMM ""de"" YYYY") & IIf(SSTab.Tab = 1, " - Carga " & Format(IdCarga, "0000000"), "")
    Select Case SSTab.Tab
        Case 0:
'                If Not ValidaModulo("LIQCARGA", True) Then
'                    SSTab.Tab = 4
'                    Exit Sub
'                End If

                'If FechaSel = "12:00:00 a.m." Then FechaSel = UltimoDia    'Se comenta porque marca error
                If PreviousTab = 4 Then DTPFecha.Value = FechaSel
                TxtRuta.SetFocus
                LlenaCombo
        Case 1:
'                If Not ValidaModulo("LIQCARGAP", True) Then
'                    SSTab.Tab = 4
'                    Exit Sub
'                End If
                'BarCode.Visible = IIf(Route, True, False)
                DetalleSurtidos False, 1, True
                TxtIdProdS.SetFocus
        Case 2:
'                If Not ValidaModulo("LIQDEV", True) Then
'                    SSTab.Tab = 4
'                    Exit Sub
'                End If
                ClasMerma = ClasificaMerma
                
                If ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then
                    StrCmd = "exec up_ActualizaKardex " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 2"
                    If Rs.State Then Rs.Close
                    Rs.Open StrCmd, Cnn
                End If
                
                DetalleSurtidos False, 2, False
                TxtIdProdD.SetFocus
        Case 3:
'                If Not ValidaModulo("LIQVTA", True) Then
'                    SSTab.Tab = 4
'                    Exit Sub
'                End If
                LlenaComboVentas
                MuestraFacturas
        Case 4:
'                If Not ValidaModulo("LIQLIQ", True) Then
'                    Unload Me
'                End If
                DTPFechaSel.Value = Date
                HabilitaMonthV
    End Select
End Sub

Private Sub TxtBuenaD_GotFocus()
On Error Resume Next
    SelText TxtBuenaD
End Sub

Private Sub TxtBuenaD_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 Then
        If Not ValidaModulo("LIQDEV", True) Then Exit Sub
        SplitTxt TxtBuenaD
        If Dec Then
            TxtBuenaD.Text = itFlotante(TxtBuenaD.Text)
            'If Trim(TxtBuenaD.Text) = "0" Then Exit Sub
        End If
        
        If IdFamiliaRejas <> 0 Then
            ActualizaSurtido
            DetalleSurtidos False, 2, False
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
        If KeyAscii <> "42" Then KeyAscii = itDecimal(KeyAscii)
    Else
        If KeyAscii <> "42" Then KeyAscii = itEntero(KeyAscii)
    End If
End Sub

Private Sub TxtBuenaD_Validate(Cancel As Boolean)
On Error Resume Next
    TxtBuenaD_KeyPress 13
End Sub

Private Sub TxtCantidadS_GotFocus()
On Error Resume Next
    SelText TxtCantidadS
End Sub

Private Sub TxtCantidadS_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        If Not ValidaModulo("LIQCARGAP", True) Then Exit Sub
        SplitTxt TxtCantidadS
        ActualizaCarga
        TxtIdProdS.SetFocus
    End If
    
    If Dec Then
        If KeyAscii <> "42" Then KeyAscii = itDecimal(KeyAscii)
    Else
        If KeyAscii <> "42" Then KeyAscii = itEntero(KeyAscii)
    End If
End Sub

Private Sub TxtCantidadS_Validate(Cancel As Boolean)
On Error Resume Next
    If Dec Then
        TxtCantidadS.Text = itFlotante(TxtCantidadS.Text)
        If Trim(TxtCantidadS.Text) = "0" Then Exit Sub
    End If
End Sub

Private Sub TxtFolio_GotFocus()
On Error Resume Next
    SelText TxtFolio
End Sub

Private Sub TxtFolio_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 Then TxtFolio_Validate False
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtFolio_Validate(Cancel As Boolean)
On Error Resume Next
    If Trim(TxtFolio.Text) = "" Or TxtFolio.Text = "0" Then
        MsgBox "¡ Teclea un Folio de Factura Válido !", vbInformation + vbOKOnly, App.Title
        TxtFolio.SetFocus
        Exit Sub
    End If
    
'    StrCmd = "execute sel_Folios " & IdCedis & ", " & LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1) & ", " & TxtFolio.Text & ", 2"
'    If Rs.State Then Rs.Close
'    Rs.Open StrCmd, Cnn
'    If Not Rs.EOF Then
'        If Rs.Fields(0) > CLng(TxtFolio.Text) Then
'            MsgBox "¡ El Folio de Factura debe ser mayor al Folio Inicial " & Rs.Fields(0) & " !", vbInformation + vbOKOnly, App.Title
'            TxtFolio.Text = ""
'            TxtFolio.SetFocus
'            Exit Sub
'        Else
'            If Rs.Fields(1) = 0 Then
'                TxtRazonSocial.SetFocus
'            Else
'                MsgBox "¡ El Folio " & TxtFolio.Text & " ya existe !. Teclee otro Folio.", vbInformation + vbOKOnly, App.Title
'                TxtFolio.Text = ""
'                TxtFolio.SetFocus
'                Exit Sub
'            End If
'        End If
'    Else
'        MsgBox "¡ Teclea un Folio de Factura Válido !", vbInformation + vbOKOnly, App.Title
'        TxtFolio.Text = ""
'        TxtFolio.SetFocus
'    End If
End Sub

Private Sub TxtFolioC_GotFocus()
On Error Resume Next
    SelText TxtFolioC
End Sub

Private Sub TxtFolioC_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If TxtFolioC.Locked Then Exit Sub
    If KeyAscii = 13 Then FolioCValidate
    KeyAscii = itEntero(KeyAscii)
End Sub

Sub FolioCValidate()
On Error Resume Next

    If Not ValidaModulo("LIQLIQ", True) Then Exit Sub

    'If FechaSel = "12:00:00 a.m." Then FechaSel = UltimoDia    'Se comenta porque marca error
    
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
    
    StrCmd = "execute sel_VentasContado " & IdCedis & ", '" & FormatDate(FechaSel) & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        MsgBox "¡ Ya se ha generado la Factura de Contado con anterioridad !", vbInformation + vbOKOnly, App.Title
        TxtSerieC.Text = Rs.Fields(0)
        TxtFolioC.Text = Rs.Fields(1)
        GoTo SalirFacturaContado:
    End If
    
    'Inserta Registro de Factura...
    StrCmd = "execute up_VentasContado " & IdCedis & ", '" & FormatDate(FechaSel) & "', " & TxtFolioC.Text & ", '" & TxtSerieC.Text & "',  '', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
SalirFacturaContado:
    MuestraStatusDia FechaSel
    MsgBox "¡ Factura Registrada !", vbInformation + vbOKOnly, App.Title
    'MsgBox "Inserta Registro de Factura..."
    
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

Private Sub TxtIdProdD_Change()
On Error Resume Next
    TxtDescD.Text = "": TxtVentaD.Text = "0": TxtCargaD.Text = "0": TxtBuenaD.Text = "0"
    TxtObsequiosD.Text = "0": TxtMalaD.Text = "0": TxtFaltanteD.Text = "0"
End Sub

Private Sub TxtIdProdD_GotFocus()
On Error Resume Next
    SelText TxtIdProdD
End Sub

Public Sub TxtIdProdD_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If Trim(TxtIdProdD.Text) = "0" Then
'        Forma = 5: AL_ProductosBusqueda.Show
    End If
    If KeyAscii = 13 Then
        TxtIdProdD_Validate False
        TxtBuenaD.SetFocus
        Exit Sub
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtIdProdD_Validate(Cancel As Boolean)
On Error Resume Next
    ValProdDev
End Sub

Private Sub TxtIdProdS_Change()
On Error Resume Next
    TxtDescS.Text = "": TxtCantidadS.Text = 0: TxtExistencias.Text = 0
End Sub

Private Sub TxtIdProdS_GotFocus()
On Error Resume Next
    SelText TxtIdProdS
End Sub

Public Sub TxtIdProdS_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If Trim(TxtIdProdS.Text) = "0" Then
'        Forma = 4: AL_ProductosBusqueda.Show
    End If
    If KeyAscii = "13" Then
        TxtIdProdS_Validate False
        TxtCantidadS.SetFocus
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtIdProdS_Validate(Cancel As Boolean)
On Error Resume Next
    ValProducto
End Sub

Private Sub TxtIdVendedor_Change()
On Error Resume Next
    BuscaVendedores
End Sub

Private Sub TxtIdVendedor_GotFocus()
On Error Resume Next
    SelText TxtIdVendedor
End Sub

Private Sub TxtIdVendedor_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtMalaD_GotFocus()
On Error Resume Next
    SelText TxtMalaD
End Sub

Public Sub TxtMalaD_KeyPress(KeyAscii As Integer)
On Error Resume Next
           
    If KeyAscii = 13 Then
    
    If Dec Then
        TxtMalaD.Text = itFlotante(TxtMalaD.Text)
    End If
    
    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    If Not ValidaModulo("LIQDEV", True) Then Exit Sub
    SplitTxt TxtMalaD
    
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
                    StrCmd = "execute up_SurtidosMerma " & IdCedis & ", " & IdSurtido & ", " & CLng(AL_Liquidacion.TxtIdProdD.Text) & ", 0, 0, 3"
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
                    .Left = Left + ((Width - .Width) / 2)
                    .Top = Top + ((Height - .Height) / 2)
                    .TxtTotal.Text = TxtMalaD.Text
                    .CalculaFaltante
                    .cmbTipo.SetFocus
                    .Show
                    .ZOrder (0)
                End With
            End If
            Exit Sub
        Else
            Exit Sub
        End If
    End If
    If Dec Then
        If KeyAscii <> "42" Then KeyAscii = itDecimal(KeyAscii)
    Else
        If KeyAscii <> "42" Then KeyAscii = itEntero(KeyAscii)
    End If
End Sub

Private Sub TxtMalaD_Validate(Cancel As Boolean)
On Error Resume Next
    TxtMalaD_KeyPress 13
End Sub

Private Sub TxtNombre_Change()
On Error Resume Next
    BuscaVendedores
End Sub

Private Sub TxtNombre_GotFocus()
On Error Resume Next
    SelText TxtNombre
End Sub

Private Sub TxtNombre_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtNomina_Change()
On Error Resume Next
    BuscaVendedores
End Sub

Private Sub TxtNomina_GotFocus()
On Error Resume Next
    SelText TxtNomina
End Sub

Private Sub TxtNomina_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtObsequiosD_GotFocus()
On Error Resume Next
    SelText TxtObsequiosD
End Sub

Private Sub TxtObsequiosD_KeyPress(KeyAscii As Integer)

On Error Resume Next

    If KeyAscii = 13 Then
        If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
        If Not ValidaModulo("LIQDEV", True) Then Exit Sub
        SplitTxt TxtObsequiosD
        
        If Dec Then
            TxtObsequiosD.Text = itFlotante(TxtObsequiosD.Text)
        End If
        If ValFaltante(TxtObsequiosD) Then
            ActualizaSurtido
            DetalleSurtidos False, 2, False
            TxtIdProdD.Text = ""
            TxtIdProdD.SetFocus
            Exit Sub
        Else
            Exit Sub
        End If
    End If
    If Dec Then
        If KeyAscii <> "42" Then KeyAscii = itDecimal(KeyAscii)
    Else
        If KeyAscii <> "42" Then KeyAscii = itEntero(KeyAscii)
    End If
End Sub

Private Sub TxtObsequiosD_Validate(Cancel As Boolean)
On Error Resume Next
    If Dec Then
        TxtObsequiosD.Text = itFlotante(TxtObsequiosD.Text)
    End If
    If ValFaltante(TxtObsequiosD) Then
        Exit Sub
    End If
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

Private Sub TxtRuta_Change()
On Error Resume Next
    LimpiaListas
    HabBusqueda False
    
    If IdSurtido <> 0 And AccesaSurtido Then BloqueaSurtido 2
    
    IdSurtido = 0: Status = "": IdCarga = 0: StatusC = "": AccesaSurtido = False
    If Trim(TxtRuta.Text) = "" Then
        IdRuta = 0
    Else
        IdRuta = CLng(TxtRuta.Text)
    End If
End Sub

Private Sub TxtRuta_GotFocus()
On Error Resume Next
    SelText TxtRuta
End Sub

Private Sub TxtRuta_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 Then
        TxtRuta_Validate False
        Exit Sub
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtRuta_Validate(Cancel As Boolean)
On Error Resume Next
    IdRuta = IIf(Trim(TxtRuta.Text) = "", 0, Trim(TxtRuta.Text))
    If Not ValidaRuta Then
        LblSurtidos.Caption = "La Ruta " & TxtRuta.Text & " no existe"
        LblSurtidos.Visible = True
        frmCargas.Visible = True
        LimpiaListas
        If IdRuta <> "0" Then
            MsgBox "¡ La Ruta " & IdRuta & " no existe!.", vbInformation + vbOKOnly, App.Title
            LimpiaListas
        End If
        TxtRuta.SetFocus
        Exit Sub
    End If
    AccesaSurtido = True
    
    MuestraSurtidos IIf(ChkBaja.Value, 1, 2)
    If LstSurtidos.Visible Then LstSurtidos.SetFocus
    LstSurtidos_ItemClick LstSurtidos.SelectedItem
    LstCargas_ItemClick LstCargas.SelectedItem
    
    If ValidaBloqueaSurtido And Not AccesaSurtido Then
        MsgBox "¡ Esta Ruta ya está siendo Liquidada por otro Usuario !. ", vbInformation + vbOKOnly, App.Title
        TxtRuta.Text = ""
        TxtRuta.SetFocus
        Exit Sub
    End If
    
End Sub

Sub MuestraSurtidos(Opc As Integer)
On Error Resume Next
    'Fecha = IIf(BIdioma = "us_english", Format(DTPFecha.Value, "mm/dd/yyyy"), Format(DTPFecha.Value, "dd/mm/yyyy"))
    Fecha = DTPFecha.Value
    
    StrCmd = "execute sel_Surtidos " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdRuta & ", " & Opc
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Rs.EOF Then LstDSurtidos = Empty
    
    LblSurtidos.Visible = IIf(Rs.EOF, True, False)
    LblSurtidos.Caption = IIf(Rs.EOF, "No se encontraron Liquidaciones para la Ruta en la Fecha seleccionada", "")
    
    LstSurtidos.Visible = IIf(Rs.EOF, False, True)
    frmCargas.Visible = IIf(Rs.EOF, False, True)
    FrmVendedores.Visible = IIf(Rs.EOF, False, True)
    LstDSurtidos = GetDataLVL(Rs, LstSurtidos, 1, 2, "6|0")
End Sub

Function ValidaRuta() As Boolean
On Error Resume Next
    ValidaRuta = False
    StrCmd = "execute sel_ExisteRuta " & IdCedis & ", " & IdRuta
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    ValidaRuta = IIf(Not Rs.EOF, True, False)
    If Not Rs.EOF Then
        ObtieneTipoRuta = Rs.Fields(3)
    Else
        ObtieneTipoRuta = 0
    End If
End Function

Sub BuscaVendedores()
On Error Resume Next
    StrCmd = "execute sel_SurtidosNotInVendedores " & IdCedis & ", '" & FormatDate(Fecha) & "', '" & Trim(TxtIdVendedor.Text) & "', '" & Trim(TxtNombre.Text) & "', '" & Trim(TxtNomina.Text) & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDVendedores = GetDataLVL(Rs, LstVendedores, 0, 2, "0|0|0")
End Sub

Sub LimpiaListas()
On Error Resume Next
    LstSurtidos.ListItems.Clear
    LstCargas.ListItems.Clear
    LstVendedoresAsignados.ListItems.Clear
    LstVendedores.ListItems.Clear
End Sub

Sub HabBusqueda(Val As Boolean)
On Error Resume Next
    TxtIdVendedor.Visible = Val: TxtNombre.Visible = Val: TxtNomina.Visible = Val: LstVendedores.Visible = Val: frmCargas.Visible = Val
    LblIdVendedor.Visible = Val: LblNombre.Visible = Val: LblNomina.Visible = Val
    LblPerfil.Visible = Val: cmbPerfil.Visible = Val
End Sub

Sub LlenaCombo()
On Error Resume Next
    StrCmd = "execute sel_TipoVendedor "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDPerfil = GetDataCBL(Rs, cmbPerfil, "Seleccione un Perfil", "No existen Perfiles de Vendedor")
End Sub

Private Sub ValProducto()
On Error Resume Next
    CargaAnt = 0
    If Trim(TxtIdProdS.Text) <> "" Then
        StrCmd = "execute sel_SurtidosCargaD " & IdCedis & ", " & IdSurtido & ", " & IdCarga & ", " & TxtIdProdS.Text & ", '" & FormatDate(Fecha) & "', 1"
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
            TxtSurtido.Text = FormatNumber(Rs.Fields(6), 3, vbTrue)
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

Sub DetalleSurtidos(Rep As Boolean, Opc As Integer, VCarga As Boolean)
On Error Resume Next
    
    If Opc = 1 And Not Rep Then
        StrCmd = "execute sel_SurtidosCargaD " & IdCedis & ", " & IdSurtido & ", " & IdCarga & ", 0, '" & FormatDate(Fecha) & "', " & IIf(Opc = 1, 6, 2)
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        LstDSurtido = GetDataLVL(Rs, LstSurtido, 1, 4, "0|0|9|9") '|3|8|3")
    Else
        If Not VCarga Then
            StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 0, " & IIf(Opc = 1, 6, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
        Else
            If OptImprimir(0).Value Then
                StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 0, " & IIf(Opc = 1, 6, 2)
                If Rs.State Then Rs.Close
                Rs.Open StrCmd, Cnn
            Else
                StrCmd = "execute sel_SurtidosCargaD " & IdCedis & ", " & IdSurtido & ", " & IdCarga & ", 0, '" & FormatDate(Fecha) & "', " & IIf(Opc = 1, 6, 2)
                If Rs.State Then Rs.Close
                Rs.Open StrCmd, Cnn
            End If
        End If
    End If
    
    If Opc = 2 And Not Rep Then
        LstDDevoluciones = GetDataLVL(Rs, LstDevoluciones, 1, 8, "0|0|9|9|9|9|9|9")
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
                
            FrmCambios.Visible = IIf(Route, True, False)
            If Route Then
                LblECambio.Caption = FormatNumber(Rs.Fields(6), 3, vbTrue)
                LblSCambio.Caption = FormatNumber(Rs.Fields(7), 3, vbTrue)
            End If
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
    
    If CargaAnt > CDbl(TxtCantidadS.Text) Then
        'valido si la carga ya tiene devoluciones o ventas en ese producto, ya no la puede modificar...
        StrCmd = "execute sel_ExistenciaValida " & IdCedis & ", " & IdSurtido & ", 0, 0, " & TxtIdProdS.Text & ", 0, 0, 6"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            If CDbl(Rs.Fields(2).Value) <> 0 Then
                MsgBox "¡ No puedes Modificar la Carga del Producto porque ya se han registrado Devoluciones y/o Ventas !" & Chr(13) & Chr(10) & "Elimine las Ventas y las Devoluciones de la Liquidación para poder Modificar la Carga.", vbInformation + vbOKOnly, App.Title
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
    End If
    
    StrCmd = "execute up_SurtidosCargas " & IdCedis & ", " & IdSurtido & ", " & IdCarga & ", " & Trim(TxtIdProdS.Text) & ", '" & FormatDate(Fecha) & "', " & Trim(TxtCantidadS.Text) & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
        
    TxtExistencias.Text = FormatNumber((CDbl(TxtExistencias.Text) - CDbl(TxtCantidadS.Text) + CargaAnt), 3, vbFalse)
    TxtSurtido.Text = FormatNumber((CDbl(TxtSurtido.Text) + CDbl(TxtCantidadS.Text) - CargaAnt), 3, vbFalse)
    DetalleSurtidos False, 1, True
    
No_Err_ActCarga:
    MousePointer = 0
    Exit Sub
    
Err_ActCarga:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_ActCarga:
End Sub

Sub ValProdDev()
On Error Resume Next
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
On Error Resume Next
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
On Error Resume Next
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
On Error Resume Next
    StrCmd = "execute up_SurtidosDetalle " & IdCedis & ", " & IdSurtido & ", " & CLng(TxtIdProdD.Text) & ", '" & FormatDate(Fecha) & _
    "', 0 , " & CDbl(TxtBuenaD.Text) & ", " & CDbl(TxtMalaD.Text) & ", " & CDbl(TxtObsequiosD.Text) & ", 0, 0, 2"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
End Sub

Sub HabilitaMonthV()
On Error Resume Next

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
        .TitleBackColor = &HAF845D
        .TitleForeColor = vbWhite
        .MaxSelCount = 31
        .MinDate = FIni
        'FinMes = IIf(BIdioma = "us_english", Format(CDate(Month(FFin) + 1 & "/" & "1/" & Year(FFin)), "mm/dd/yyyy"), Format(CDate("1/" & Month(FFin) + 1 & "/" & Year(FFin)), "dd/mm/yyyy")) 'CDate("1/" & Month(FFin) & "/" & Year(FFin))
        FinMes = CDate("1/" & Month(FFin) + 1 & "/" & Year(FFin))
        FinMes = FinMes - 1
        '.MaxDate = FinMes
        .MaxDate = Date + IIf(Route, 2, 1)
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
On Error Resume Next
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
On Error Resume Next
    StrCmd = "execute sel_StatusRutas " & IdCedis & ", '" & FormatDate(Fec) & "', 0, 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDStatusRutas = GetDataLVL(RsC, LstStatusRutas, 2, 5, "1|0|0|0")
End Sub

Function ObtenStatusDia(Fec As Date) As String
On Error Resume Next
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
On Error Resume Next
    StrCmd = "execute sel_VentasTipo "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDTipoVenta = GetDataCBL(Rs, cmbTipoVenta, "Tipo de Venta", "No existen Tipos de Venta definidos")
End Sub

Sub MuestraFacturas()
On Error Resume Next
    StrCmd = "execute sel_Ventas " & IdCedis & "," & IdSurtido & ", " & IIf(Not LstConfiguraLiquidacion(7), 1, 3)
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    
    LstDFacturas = GetDataLVL(RsC, LstFacturas, 3, IIf(Not LstConfiguraLiquidacion(7), 12, 13), IIf(Not LstConfiguraLiquidacion(7), "0|1|0|1|0|7|7|7|0|0", "0|1|0|1|0|7|7|7|7|0|0"))
End Sub

Sub FiltraClientes(Opc As Integer)
On Error Resume Next
    LblCliente(0).Caption = "": LblCliente(1).Caption = ""
    If Opc = 1 Then
        StrCmd = "execute sel_ClientesFacturas " & IdCedis & ",'" & IIf(Trim(TxtIdCliente.Text) = "", 0, Trim(TxtIdCliente.Text)) & "','" & Trim(TxtRFC.Text) & "','" & Trim(TxtRazonSocial.Text) & "', " & Opc
    Else
        StrCmd = "execute sel_ClientesFacturas " & IdCedis & ",'" & LstDFacturas(6, LstFacturas.SelectedItem.Index - 1) & "','','" & LstDFacturas(13, LstFacturas.SelectedItem.Index - 1) & "', " & Opc
    End If
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
'Debug.Print StrCmd
    LstDClientes = GetDataLVL(RsC, LstClientes, 1, 4, "0|0|0|0")
End Sub

Sub CancelaVenta()
On Error Resume Next
    cmbTipoVenta.ListIndex = 0: TxtSerie.Text = "": TxtFolio.Text = 0
    TxtSubtotal.Text = 0: TxtIva.Text = 0: TxtTotal.Text = 0
    TxtIdCliente.Text = "": TxtRFC.Text = "": TxtRazonSocial.Text = "": LstClientes.ListItems.Clear
End Sub

Sub BloqueaSurtido(OpcB As Integer)
On Error Resume Next
    
    StrCmd = "execute up_StatusSurtido " & IdCedis & ", " & IdSurtido & ", " & OpcB
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
End Sub

Function ValidaBloqueaSurtido() As Boolean
On Error Resume Next
    
    StrCmd = "execute sel_StatusSurtido " & IdCedis & ", " & IdSurtido & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    ValidaBloqueaSurtido = IIf(Rs.EOF, False, True)
    
End Function


Public Function GeneraStringCB(IdCed, IdSurt, IdCar, IdRut) As String

On Error GoTo Err_CB:

Dim RsCB As New ADODB.Recordset
Dim rc2 As Boolean, rc As Boolean
Dim StrBar
Dim strError As String * 1024
Dim strDefaultValue As String * 1024

    StrBar = ""
'    StrCmd = "execute sel_SurtidosVendedores " & IdCed & ", " & IdSurt
'    If RsCB.State Then RsCB.Close
'    RsCB.Open StrCmd, Cnn
'    If Not RsCB.EOF Then
'        StrBar = RsCB.Fields(7) & "|"
'    End If
    
    StrCmd = "execute sel_RouteCargaCB " & IdCed & ", " & IdSurt & ", " & IdCar & ", " & IdRut & ", 1"
    If RsCB.State Then RsCB.Close
    RsCB.Open StrCmd, Cnn
    If Not RsCB.EOF Then
        StrBar = StrBar & RsCB.Fields(0) & "|" & RsCB.Fields(1) & "|" & Format(RsCB.Fields(2), "dd/mm/yyyy") & "|"
    End If
    While Not RsCB.EOF
        StrBar = StrBar & Trim(RsCB.Fields(3)) & "|"
        RsCB.MoveNext
    Wend
    StrBar = Mid(StrBar, 1, Len(StrBar) - 1)
    'strBar = "0236|1|21/04/2009|1,78|2,58|1721,98|1722,60"
    BarCode_Object_Handle = CreateBarcodeObject("Pasteurizadora Aguascalientes SA de CV", "904123C6-5AB0C6AA-99293FB8DL")
            rc = put_Symbology(BarCode_Object_Handle, 40)
            rc = put_Comment(BarCode_Object_Handle, "")
            
            rc = put_Message(BarCode_Object_Handle, StrBar)
            If rc < 0 Then
               rc2 = GetLastBarcodeErrorMessage(BarCode_Object_Handle, strError)
               rc = get_Message(BarCode_Object_Handle, strDefaultValue)
               MsgBox strError
            End If
                        
            rc = mbxExportImage(BarCode_Object_Handle, App.Path & "\ImgBC\BC" & IdCed & IdSurt & IdCar & IdRut & ".jpg", mbxFormatJPG)
            If (rc < 0) Then
                rc = GetLastBarcodeErrorMessage(BarCode_Object_Handle, strError)
                MsgBox strError
            End If
    
    DestroyBarcodeObject BarCode_Object_Handle
    GeneraStringCB = App.Path & "\ImgBC\BC" & IdCed & IdSurt & IdCar & IdRut & ".jpg"
    
No_Err_CB:
    Exit Function
    
Err_CB:
    MsgBox "¡ Error al generar Código de Barras !" & Chr(13) & Chr(10) & Err.Description, vbInformation + vbOKOnly, App.Title
    GeneraStringCB = App.Path & "\ImgBC\Error.jpg"
    GoTo No_Err_CB:
    
End Function
