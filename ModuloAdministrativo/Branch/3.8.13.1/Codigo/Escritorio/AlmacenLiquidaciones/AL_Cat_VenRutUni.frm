VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form AL_Cat_VenRutUni 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   8295
   ClientLeft      =   180
   ClientTop       =   450
   ClientWidth     =   11280
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   8295
   ScaleWidth      =   11280
   ShowInTaskbar   =   0   'False
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
      Left            =   4080
      Picture         =   "AL_Cat_VenRutUni.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   20
      Top             =   7680
      Width           =   1695
   End
   Begin VB.CommandButton btnImprimir 
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
      Left            =   5880
      Picture         =   "AL_Cat_VenRutUni.frx":0710
      Style           =   1  'Graphical
      TabIndex        =   21
      Top             =   7680
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
      Left            =   480
      Picture         =   "AL_Cat_VenRutUni.frx":0E2B
      Style           =   1  'Graphical
      TabIndex        =   18
      Top             =   7680
      Width           =   1695
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
      Left            =   2280
      Picture         =   "AL_Cat_VenRutUni.frx":14B9
      Style           =   1  'Graphical
      TabIndex        =   19
      Top             =   7680
      Width           =   1695
   End
   Begin TabDlg.SSTab SSTab 
      Height          =   7455
      Left            =   120
      TabIndex        =   23
      Top             =   135
      Width           =   10935
      _ExtentX        =   19288
      _ExtentY        =   13150
      _Version        =   393216
      Tabs            =   4
      Tab             =   1
      TabsPerRow      =   4
      TabHeight       =   520
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      TabCaption(0)   =   "Tipo de Vendedor"
      TabPicture(0)   =   "AL_Cat_VenRutUni.frx":1E4F
      Tab(0).ControlEnabled=   0   'False
      Tab(0).Control(0)=   "FrmOpt(1)"
      Tab(0).Control(1)=   "LblOpt(0)"
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "Vendedor"
      TabPicture(1)   =   "AL_Cat_VenRutUni.frx":1E6B
      Tab(1).ControlEnabled=   -1  'True
      Tab(1).Control(0)=   "LblOpt(1)"
      Tab(1).Control(0).Enabled=   0   'False
      Tab(1).Control(1)=   "FrmOpt(0)"
      Tab(1).Control(1).Enabled=   0   'False
      Tab(1).ControlCount=   2
      TabCaption(2)   =   "Ruta"
      TabPicture(2)   =   "AL_Cat_VenRutUni.frx":1E87
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "FrmOpt(2)"
      Tab(2).Control(1)=   "LblOpt(2)"
      Tab(2).ControlCount=   2
      TabCaption(3)   =   "Unidades"
      TabPicture(3)   =   "AL_Cat_VenRutUni.frx":1EA3
      Tab(3).ControlEnabled=   0   'False
      Tab(3).Control(0)=   "LblOpt(3)"
      Tab(3).Control(1)=   "FrmOpt(3)"
      Tab(3).ControlCount=   2
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
         Height          =   7155
         Index           =   1
         Left            =   -75000
         TabIndex        =   40
         Top             =   320
         Width           =   10935
         Begin VB.TextBox TxtTipoVend 
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   1560
            MaxLength       =   20
            TabIndex        =   1
            Top             =   480
            Width           =   7695
         End
         Begin VB.TextBox TxtIdTipoVen 
            Alignment       =   1  'Right Justify
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   240
            Locked          =   -1  'True
            MaxLength       =   5
            TabIndex        =   0
            Top             =   480
            Width           =   1215
         End
         Begin MSComctlLib.ListView LsTTipoVen 
            Height          =   6015
            Left            =   240
            TabIndex        =   24
            Top             =   960
            Width           =   10455
            _ExtentX        =   18441
            _ExtentY        =   10610
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
         Begin VB.Label Label8 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Tipo de Vendedor"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Left            =   1560
            TabIndex        =   42
            Top             =   240
            Width           =   1515
         End
         Begin VB.Label Label9 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clave"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   240
            TabIndex        =   41
            Top             =   240
            Width           =   1215
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
         Height          =   7155
         Index           =   0
         Left            =   0
         TabIndex        =   37
         Top             =   320
         Width           =   10935
         Begin VB.CommandButton btnSaldos 
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
            Left            =   5400
            Picture         =   "AL_Cat_VenRutUni.frx":1EBF
            Style           =   1  'Graphical
            TabIndex        =   22
            Top             =   480
            Width           =   1695
         End
         Begin VB.TextBox TxtUsuario 
            Alignment       =   1  'Right Justify
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   3120
            MaxLength       =   8
            TabIndex        =   4
            Top             =   600
            Width           =   1815
         End
         Begin VB.TextBox TxtApMat 
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   2760
            MaxLength       =   200
            TabIndex        =   6
            Top             =   1320
            Width           =   2655
         End
         Begin VB.TextBox TxtApPat 
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   240
            MaxLength       =   200
            TabIndex        =   5
            Top             =   1320
            Width           =   2415
         End
         Begin VB.ComboBox CboTipoVen 
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   345
            Left            =   8400
            Style           =   2  'Dropdown List
            TabIndex        =   8
            Top             =   1320
            Width           =   2295
         End
         Begin VB.TextBox TxtNomina 
            Alignment       =   1  'Right Justify
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   1200
            MaxLength       =   20
            TabIndex        =   3
            Top             =   600
            Width           =   1815
         End
         Begin VB.TextBox TxtNombre 
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   5520
            MaxLength       =   200
            TabIndex        =   7
            Top             =   1320
            Width           =   2775
         End
         Begin VB.TextBox TxtIdVendedor 
            Alignment       =   1  'Right Justify
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   240
            MaxLength       =   8
            TabIndex        =   2
            Top             =   600
            Width           =   855
         End
         Begin MSComctlLib.ListView LstVendedor 
            Height          =   5295
            Left            =   240
            TabIndex        =   25
            Top             =   1800
            Width           =   10455
            _ExtentX        =   18441
            _ExtentY        =   9340
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
         Begin VB.Label Label4 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Usuario Terminal"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   3120
            TabIndex        =   54
            Top             =   360
            Width           =   1455
         End
         Begin VB.Label Label19 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Ap Materno"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Left            =   2760
            TabIndex        =   50
            Top             =   1080
            Width           =   1005
         End
         Begin VB.Label Label18 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Ap Paterno"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Left            =   240
            TabIndex        =   49
            Top             =   1080
            Width           =   975
         End
         Begin VB.Label Label17 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Tipo de Vendedor"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Left            =   8400
            TabIndex        =   48
            Top             =   1080
            Width           =   1515
         End
         Begin VB.Label Label16 
            BackColor       =   &H00FFFFFF&
            Caption         =   "No Nomina"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   1200
            TabIndex        =   47
            Top             =   360
            Width           =   1455
         End
         Begin VB.Label Label11 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Nombre"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Left            =   5520
            TabIndex        =   39
            Top             =   1080
            Width           =   675
         End
         Begin VB.Label Label12 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clave"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   240
            TabIndex        =   38
            Top             =   360
            Width           =   975
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
         Height          =   7155
         Index           =   2
         Left            =   -75000
         TabIndex        =   34
         Top             =   320
         Width           =   10935
         Begin VB.ComboBox cmbModelo 
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   345
            ItemData        =   "AL_Cat_VenRutUni.frx":2580
            Left            =   8760
            List            =   "AL_Cat_VenRutUni.frx":258D
            Style           =   2  'Dropdown List
            TabIndex        =   12
            Top             =   600
            Width           =   2055
         End
         Begin VB.ComboBox CboTipo 
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   345
            ItemData        =   "AL_Cat_VenRutUni.frx":25AB
            Left            =   6000
            List            =   "AL_Cat_VenRutUni.frx":25AD
            Style           =   2  'Dropdown List
            TabIndex        =   11
            Top             =   600
            Width           =   2655
         End
         Begin VB.TextBox TxtRuta 
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   1200
            TabIndex        =   10
            Top             =   600
            Width           =   4695
         End
         Begin VB.TextBox TxtIdRuta 
            Alignment       =   1  'Right Justify
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   240
            Locked          =   -1  'True
            MaxLength       =   5
            TabIndex        =   9
            Top             =   600
            Width           =   855
         End
         Begin MSComctlLib.ListView LstRuta 
            Height          =   5895
            Left            =   240
            TabIndex        =   26
            Top             =   1080
            Width           =   10575
            _ExtentX        =   18653
            _ExtentY        =   10398
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
         Begin VB.Label Label3 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Modelo de Venta"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Left            =   8760
            TabIndex        =   53
            Top             =   360
            Width           =   1470
         End
         Begin VB.Label Label15 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Especialización"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Left            =   6000
            TabIndex        =   51
            Top             =   360
            Width           =   1365
         End
         Begin VB.Label Label13 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Ruta"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Left            =   1200
            TabIndex        =   36
            Top             =   360
            Width           =   405
         End
         Begin VB.Label Label14 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clave"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   240
            TabIndex        =   35
            Top             =   360
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
         Height          =   7155
         Index           =   3
         Left            =   -75000
         TabIndex        =   28
         Top             =   320
         Width           =   10935
         Begin VB.TextBox TxtNoSerie 
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   3600
            MaxLength       =   15
            TabIndex        =   15
            Top             =   720
            Width           =   2415
         End
         Begin VB.TextBox TxtNoEcon 
            Alignment       =   1  'Right Justify
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   1560
            MaxLength       =   8
            TabIndex        =   14
            Top             =   720
            Width           =   1935
         End
         Begin VB.ComboBox CboModelo 
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   345
            Left            =   6120
            Style           =   2  'Dropdown List
            TabIndex        =   16
            Top             =   720
            Width           =   1335
         End
         Begin VB.TextBox TxtIdUnidad 
            Alignment       =   1  'Right Justify
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   240
            Locked          =   -1  'True
            MaxLength       =   5
            TabIndex        =   13
            Top             =   720
            Width           =   1215
         End
         Begin VB.TextBox TxtMarca 
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   7560
            MaxLength       =   30
            TabIndex        =   17
            Top             =   720
            Width           =   2655
         End
         Begin MSComctlLib.ListView LstUnidades 
            Height          =   5775
            Left            =   240
            TabIndex        =   27
            Top             =   1320
            Width           =   10455
            _ExtentX        =   18441
            _ExtentY        =   10186
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
         Begin VB.Label Label6 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "No Serie"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Left            =   3600
            TabIndex        =   33
            Top             =   480
            Width           =   750
         End
         Begin VB.Label Label7 
            BackColor       =   &H00FFFFFF&
            Caption         =   "No Económico"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   1560
            TabIndex        =   32
            Top             =   480
            Width           =   1815
         End
         Begin VB.Label Label10 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Marca"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Left            =   7680
            TabIndex        =   31
            Top             =   480
            Width           =   540
         End
         Begin VB.Label Label1 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clave"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   240
            TabIndex        =   30
            Top             =   480
            Width           =   735
         End
         Begin VB.Label Label2 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Modelo"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   6120
            TabIndex        =   29
            Top             =   480
            Width           =   855
         End
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Tipo de Vendedor"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   0
         Left            =   -75000
         TabIndex        =   46
         Top             =   0
         Width           =   2745
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Vendedor"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   495
         Index           =   1
         Left            =   2640
         TabIndex        =   45
         Top             =   0
         Width           =   2865
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Ruta"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   2
         Left            =   -69600
         TabIndex        =   44
         Top             =   0
         Width           =   2865
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Unidades"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   3
         Left            =   -66915
         TabIndex        =   43
         Top             =   0
         Width           =   2850
      End
   End
   Begin VB.Label LblEdicion 
      AutoSize        =   -1  'True
      BackColor       =   &H00FFFFFF&
      Caption         =   "Consultar"
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
      Height          =   210
      Left            =   7680
      TabIndex        =   52
      Top             =   7800
      Width           =   810
   End
End
Attribute VB_Name = "AL_Cat_VenRutUni"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDCanales, LstDCadenas, Nuevo As Boolean, LstDVendedor

Private Sub btnActualizar_Click()

On Error GoTo Err_CatRutasG:

Dim TIPOVENDEDOR As Integer
    
If LblEdicion.Caption = "Consultar" Then Exit Sub

    Select Case SSTab.Tab
        Case 0: If Not ValidaModulo("CATRUTATVEND", True) Then Exit Sub
        Case 1: If Not ValidaModulo("CATRUTAVEND", True) Then Exit Sub
        Case 2: If Not ValidaModulo("CATRUTARUTA", True) Then Exit Sub
        Case 3: If Not ValidaModulo("CATRUTAUNID", True) Then Exit Sub
    End Select
    
    Select Case SSTab.Tab
        Case 0:
        
            If Trim(TxtIdTipoVen.Text) = "" Or Trim(TxtTipoVend.Text) = "" Then
                MsgBox "¡ Teclee los Datos para Actualizar !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        
            StrCmd = "execute up_TipoVendedores " & Trim(TxtIdTipoVen.Text) & ", '" & UCase(Trim(TxtTipoVend.Text)) & "', '" & FormatDate(Date) & "'," & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraTipoVendedor
            LLENA_COMBOS
            Nuevo = False
            
        Case 1:
            If Trim(TxtIdVendedor.Text) = "" Or Trim(TxtNomina.Text) = "" Or Trim(TxtApPat.Text) = "" Or Trim(TxtNombre.Text) = "" Or Trim(CboTipoVen.Text) = "" Then
                MsgBox "¡ Teclee los Datos para Actualizar !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
                                   
            If Nuevo And ValidaUsuarioTerminal(False) Then
                Exit Sub
            End If
                                   
            If Nuevo Then
                If Rs.State Then Rs.Close
                Rs.Open "select nomina from vendedores where nomina = '" & Trim(TxtNomina.Text) & "' and IdCedis = " & IdCedis
                If Not Rs.EOF Then
                    MsgBox "¡ El número de Nómina ya existe !. Teclea otra clave. ", vbInformation + vbOKOnly, App.Title
                    TxtIdVendedor.SetFocus
                    Exit Sub
                End If
                If Rs.EOF Then Rs.Close
                Rs.Open "select idvendedor from vendedores where idvendedor = " & Trim(TxtIdVendedor.Text) & " and IdCedis = " & IdCedis
                If Not Rs.EOF Then
                    MsgBox "¡ El Id de Vendedor ya existe !. Teclea otra clave. ", vbInformation + vbOKOnly, App.Title
                    TxtIdVendedor.SetFocus
                    Exit Sub
                End If
            End If
                      
            If Rs.State Then Rs.Close
            Rs.Open "SELECT * FROM TIPOVENDEDOR WHERE TIPOVENDEDOR = '" & Trim(CboTipoVen.Text) & "'", Cnn
            TIPOVENDEDOR = Rs!IDTIPOVENDEDOR
            StrCmd = "execute up_Vendedores " & IdCedis & ", " & Trim(TxtIdVendedor.Text) & ", '" & UCase(Trim(TxtNombre.Text)) & "', '" & UCase(Trim(TxtApPat.Text)) & "', '" & UCase(Trim(TxtApMat.Text)) & "', '" & Trim(TxtNomina.Text) & "', " & TIPOVENDEDOR & ", '" & FormatDate(Date) & "', '" & UCase(Trim(TxtUsuario.Text)) & "', " & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraVendedor
            Nuevo = False
                                    
        Case 2:
            If Trim(TxtIdRuta.Text) = "" Or Trim(TxtRuta.Text) = "" Or Trim(CboTipo.Text) = "" Then
                MsgBox "¡ Teclee los Datos para Actualizar !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If

            If Rs.State Then Rs.Close
            Rs.Open "SELECT * FROM TIPORUTA WHERE TIPORUTA = '" & Trim(CboTipo.Text) & "'", Cnn
            tiporuta = Rs!IdTipoRuta
            StrCmd = "execute up_Rutas " & IdCedis & ", " & Trim(TxtIdRuta.Text) & ", '" & UCase(Trim(TxtRuta.Text)) & "', " & tiporuta & ", '" & Trim(cmbModelo.Text) & "', '" & FormatDate(Date) & "'," & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraRutas
            Nuevo = False
                          
        Case 3:
            If Trim(TxtIdUnidad.Text) = "" Or Trim(TxtNoEcon.Text) = "" Or Trim(TxtNoSerie.Text) = "" Or Trim(CboModelo.Text) = "" Or Trim(TxtMarca.Text) = "" Then
                MsgBox "¡ Teclee los Datos para Actualizar !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If

            StrCmd = "execute up_Unidades " & IdCedis & ", " & UCase(TxtIdUnidad.Text) & ", " & UCase(TxtNoEcon.Text) & ", '" & UCase(TxtNoSerie.Text) & "',  " _
                    & " " & UCase(CboModelo.Text) & ", '" & UCase(TxtMarca.Text) & "', '" & FormatDate(Date) & "', " & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraUnidades
            Nuevo = False
            
    End Select

No_Err_CatRutasG:
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
    LblEdicion.Caption = "Consultar"
    Exit Sub
        
Err_CatRutasG:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_CatRutasG:

End Sub

Private Sub btnEliminar_Click()

On Error GoTo Err_CatRutasE:

    Select Case SSTab.Tab
        Case 0: If Not ValidaModulo("CATRUTATVEND", True) Then Exit Sub
        Case 1: If Not ValidaModulo("CATRUTAVEND", True) Then Exit Sub
        Case 2: If Not ValidaModulo("CATRUTARUTA", True) Then Exit Sub
        Case 3: If Not ValidaModulo("CATRUTAUNID", True) Then Exit Sub
    End Select
    
    Select Case SSTab.Tab
        
        Case 0:
            If Trim(TxtIdTipoVen.Text) = "" Then
                MsgBox "¡ Seleccione el registro a dar de Baja !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        
            StrCmd = "execute up_TipoVendedores " & TxtIdTipoVen.Text & ", '','', 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraTipoVendedor
            LLENA_COMBOS
            Nuevo = False
        
        Case 1:
            If Trim(TxtIdVendedor.Text) = "" Then
                MsgBox "¡ Seleccione el registro a dar de Baja !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If

            StrCmd = "execute up_Vendedores " & IdCedis & "," & TxtIdVendedor.Text & ",'','','','','','19000101','',3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraVendedor
            Nuevo = False
                    
        Case 2:
        
            If Trim(TxtIdRuta.Text) = "" Then
                MsgBox "¡ Seleccione el registro a dar de Baja !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If

            StrCmd = "execute up_Rutas " & IdCedis & "," & TxtIdRuta.Text & ", '','','', '19000101', 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraRutas
            Nuevo = False
                         
        Case 3:
            If Trim(TxtIdUnidad.Text) = "" Then
                MsgBox "¡ Seleccione el registro a dar de Baja !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If

            StrCmd = "execute up_Unidades  " & IdCedis & "," & TxtIdUnidad.Text & ",'','','','','',3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraUnidades
            Nuevo = False
            
    End Select
    
No_Err_CatRutasE:
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
    LblEdicion.Caption = "Consultar"
    Exit Sub
        
Err_CatRutasE:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_CatRutasE:
    
End Sub

Private Sub btnImprimir_Click()

On Error GoTo Err_CatRutasI:

   Select Case SSTab.Tab
        Case 0:
            With AL_RptCatTipoVend
                .Caption = "Catálogo de Tipo de Vendedor"
                .LblTitulo.Caption = "Catálogo de Tipo de Vendedor"
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                StrCmd = "select IdTipoVendedor, TipoVendedor, " _
                        & " Case Status " _
                        & " when 'A' then 'Activo' " _
                        & " Else 'Baja' " _
                        & " end as 'Estatus' from TipoVendedor order by TipoVendedor"
                    If RsC.State Then RsC.Close
                    RsC.Open StrCmd, Cnn
        
                If Not RsC.EOF Then
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = RsC
                    .Printer.Orientation = ddOPortrait
                    .Printer.PaperSize = 1
                    .Printer.Orientation = ddOPortrait
                    .Show
                End If
            End With
            
        Case 1:
            With AL_RptCatVendedor
                .Caption = "Catálogo de Vendedores"
                .LblTitulo.Caption = "Catálogo de Vendedores"
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                StrCmd = "select C.Cedis, V.IdVendedor, V.Nombre, V.ApPaterno, V.ApMaterno, V.Nomina, T.TipoVendedor, " _
                        & " Case V.Status " _
                        & " when 'A' then 'Activo' " _
                        & " Else 'Baja' " _
                        & " end as 'Estatus' " _
                        & " from Vendedores V, Cedis C, tipovendedor T " _
                        & " where v.idcedis = c.idcedis and v.idtipovendedor = t.idtipovendedor " _
                        & " and v.idcedis = " & IdCedis _
                        & " order by C.Cedis, V.nombre"
                    If RsC.State Then RsC.Close
                    RsC.Open StrCmd, Cnn
        
                If Not RsC.EOF Then
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = RsC
                    .Printer.Orientation = ddOPortrait
                    .Printer.PaperSize = 1
                    .Printer.Orientation = ddOPortrait
                    .Show
                End If
            End With
            
        Case 2:
            With AL_RptCatRutas
                .Caption = "Catálogo de Rutas"
                .LblTitulo.Caption = "Catálogo de Rutas"
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                StrCmd = "select c.cedis, r.idruta, r.ruta, t.tiporuta," _
                        & " Case r.Status " _
                        & " when 'A' then 'Activo' " _
                        & " Else 'Baja' " _
                        & " end as 'Estatus', r.tipoventa as 'Tipo Venta' " _
                        & " from cedis c, rutas r, tiporuta t" _
                        & " Where r.tiporuta = t.idtiporuta And r.IdCedis = c.IdCedis  and r.idcedis = " & IdCedis _
                        & " order by c.cedis, r.idruta"
                    If RsC.State Then RsC.Close
                    RsC.Open StrCmd, Cnn
        
                If Not RsC.EOF Then
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = RsC
                    .Printer.Orientation = ddOPortrait
                    .Printer.PaperSize = 1
                    .Printer.Orientation = ddOPortrait
                    .Show
                End If
            End With
                
        Case 3:
            With AL_RptCatUnidades
                .Caption = "Catálogo de Unidades de Transporte"
                .LblTitulo.Caption = "Catálogo de Unidades de Transporte"
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                StrCmd = "select c.cedis, u.idunidad, u.noeconomico, u.noserie, u.modelo, u.marca, " _
                        & " Case u.Status " _
                        & " when 'A' then 'Activo' " _
                        & " Else 'Baja' " _
                        & " end as 'Estatus' " _
                        & " from cedis c, unidades u " _
                        & " Where c.IdCedis = u.IdCedis and u.idcedis = " & IdCedis _
                        & " order by c.cedis, u.noeconomico"
                    If RsC.State Then RsC.Close
                    RsC.Open StrCmd, Cnn
        
                If Not RsC.EOF Then
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = RsC
                    .Printer.Orientation = ddOPortrait
                    .Printer.PaperSize = 1
                    .Printer.Orientation = ddOPortrait
                    .Show
                End If
            End With
                        
    End Select
      
No_Err_CatRutasI:
    LblEdicion.Caption = "Consultar"
    Exit Sub
        
Err_CatRutasI:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_CatRutasI:
      
End Sub

Private Sub btnNuevo_Click()

On Error GoTo Err_CatRutasN:

    Select Case SSTab.Tab
        Case 0: If Not ValidaModulo("CATRUTATVEND", True) Then Exit Sub
        Case 1: If Not ValidaModulo("CATRUTAVEND", True) Then Exit Sub
        Case 2: If Not ValidaModulo("CATRUTARUTA", True) Then Exit Sub
        Case 3: If Not ValidaModulo("CATRUTAUNID", True) Then Exit Sub
    End Select

    Select Case SSTab.Tab
        Case 0:
            TxtIdTipoVen.Text = "": TxtTipoVend.Text = ""
            If Rs.State Then Rs.Close
            Rs.Open "SELECT ISNULL(MAX(IdTipoVendedor),0)+1 AS MAXI From TIPOVENDEDOR", Cnn
            TxtIdTipoVen.Text = Rs!MAXI
            Nuevo = True
            TxtTipoVend.SetFocus
            
        Case 1:
            TxtIdVendedor.Text = "": TxtNomina.Text = "": TxtApPat.Text = "": TxtApMat.Text = "": TxtNombre.Text = ""
            If Rs.State Then Rs.Close
            Rs.Open "SELECT ISNULL(MAX(IdVendedor),0)+1 AS MAXI From VENDEDORES where idcedis = " & IdCedis & "", Cnn
            TxtIdVendedor.Text = Rs!MAXI
            Nuevo = True
            TxtNomina.SetFocus
            
        Case 2:
            TxtIdRuta.Text = "": TxtRuta.Text = ""
            If Rs.State Then Rs.Close
            Rs.Open "SELECT ISNULL(MAX(IdRuta),0)+1 AS MAXI From RUTAS where idcedis = " & IdCedis & " ", Cnn
            TxtIdRuta.Text = Rs!MAXI
            Nuevo = True
            TxtRuta.SetFocus
           
        Case 3:
            TxtIdUnidad.Text = "": TxtNoEcon.Text = "": TxtNoSerie.Text = "": TxtMarca.Text = ""
            If Rs.State Then Rs.Close
            Rs.Open "SELECT ISNULL(MAX(IdUNIDAD),0)+1 AS MAXI From UNIDADES where idcedis = " & IdCedis & "", Cnn
            TxtIdUnidad.Text = Rs!MAXI
            Nuevo = True
            TxtNoEcon.SetFocus
            
    End Select
    
No_Err_CatRutasN:
    LblEdicion.Caption = "Nuevo"
    Exit Sub
        
Err_CatRutasN:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_CatRutasN:

End Sub

Sub MuestraTipoVendedor()
On Error Resume Next
    StrCmd = "execute sel_TipoVendedor "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCanales = GetDataLVL(Rs, LsTTipoVen, 0, 3, "1|0|0|0")
End Sub

Sub MuestraVendedor()
On Error Resume Next
    StrCmd = "execute sel_Vendedor " & IdCedis & " "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDVendedor = GetDataLVL(Rs, LstVendedor, 0, 5, "0|0|0|0|0|0")
End Sub

Sub MuestraRutas()
On Error Resume Next
    StrCmd = "execute sel_Rutas " & IdCedis & " "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCanales = GetDataLVL(Rs, LstRuta, 0, 6, "0|0|0|0|0|0")
End Sub

Sub MuestraUnidades()
On Error Resume Next
    StrCmd = "execute sel_Unidades " & IdCedis & " "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCanales = GetDataLVL(Rs, LstUnidades, 0, 6, "1|0|0|0|0|0|0")
End Sub

Private Sub btnSaldos_Click()
On Error Resume Next
    With AL_SaldosVendedores
        .Left = AL_Cat_VenRutUni.Left + (AL_Cat_VenRutUni.Width - .Width) / 2
        .Top = AL_Cat_VenRutUni.Top + (AL_Cat_VenRutUni.Height - .Height) / 2
        .Show
    End With

End Sub

Private Sub Form_Load()
On Error Resume Next
    Nuevo = False
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    MuestraUnidades
    SSTab.Tab = 3
    LLENA_COMBOS
End Sub

Sub LLENA_COMBOS()
On Error Resume Next

    'LLENA TIPO VENDEDOR (VENDEDORES)
    CboTipoVen.Clear
    If Rs.State Then Rs.Close
    Rs.Open "SELECT TIPOVENDEDOR FROM TIPOVENDEDOR WHERE STATUS = 'A' ORDER BY TIPOVENDEDOR", Cnn
    While Not Rs.EOF
        CboTipoVen.AddItem Trim(Rs!TIPOVENDEDOR)
        Rs.MoveNext
    Wend
    Rs.Close
    
    'LLENA TIPO RUTA (RUTAS)
    CboTipo.Clear
    If Rs.State Then Rs.Close
    Rs.Open "SELECT TIPORUTA FROM TIPORUTA WHERE STATUS = 'A' ORDER BY TIPORUTA", Cnn
    While Not Rs.EOF
        CboTipo.AddItem Trim(Rs!tiporuta)
        Rs.MoveNext
    Wend
    Rs.Close
    
    'LLENA TIPO RUTA (RUTAS)
    CboModelo.Clear
    If Rs.State Then Rs.Close
    For i = 2000 To 2015
        CboModelo.AddItem i
    Next i

End Sub

Private Sub LstRuta_Click()
On Error Resume Next
If LstRuta.ListItems.Count <= 0 Then Exit Sub

    TxtIdRuta.Text = LstRuta.SelectedItem
    TxtRuta.Text = LstRuta.SelectedItem.ListSubItems(1)
    CboTipo.Text = LstRuta.SelectedItem.ListSubItems(2)
    Select Case LstRuta.SelectedItem.ListSubItems(3).Text
        Case "Venta": cmbModelo.ListIndex = 0
        Case "Preventa": cmbModelo.ListIndex = 1
        Case "Reparto": cmbModelo.ListIndex = 2
    End Select
    LblEdicion.Caption = "Consultar"
    Nuevo = False
End Sub

Private Sub LstRuta_DblClick()
On Error Resume Next

    LblEdicion.Caption = "Actualizar"
    Nuevo = False
End Sub

Private Sub LstRuta_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstRuta_Click
End Sub

Private Sub LsTTipoVen_Click()
On Error Resume Next
If LsTTipoVen.ListItems.Count <= 0 Then Exit Sub

    TxtIdTipoVen.Text = LsTTipoVen.ListItems(LsTTipoVen.SelectedItem.Index).Text
    TxtTipoVend.Text = LsTTipoVen.ListItems(LsTTipoVen.SelectedItem.Index).SubItems(1)
    LblEdicion.Caption = "Consultar"
    Nuevo = False
End Sub

Private Sub LsTTipoVen_DblClick()
On Error Resume Next

    LblEdicion.Caption = "Actualizar"
    Nuevo = False
End Sub

Private Sub LsTTipoVen_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LsTTipoVen_DblClick
End Sub

Private Sub LstUnidades_Click()
On Error Resume Next
If LstUnidades.ListItems.Count <= 0 Then Exit Sub

    If IsEmpty(LstUnidades) Then Exit Sub
    TxtIdUnidad.Text = LstUnidades.ListItems(LstUnidades.SelectedItem.Index).Text
    TxtNoEcon.Text = LstUnidades.ListItems(LstUnidades.SelectedItem.Index).SubItems(1)
    TxtNoSerie.Text = LstUnidades.ListItems(LstUnidades.SelectedItem.Index).SubItems(2)
    CboModelo.Text = LstUnidades.ListItems(LstUnidades.SelectedItem.Index).SubItems(3)
    TxtMarca.Text = LstUnidades.ListItems(LstUnidades.SelectedItem.Index).SubItems(4)
    LblEdicion.Caption = "Consultar"
    Nuevo = False
End Sub

Private Sub LstUnidades_DblClick()
On Error Resume Next

    LblEdicion.Caption = "Actualizar"
    Nuevo = False
End Sub

Private Sub LstUnidades_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstUnidades_DblClick
End Sub

Private Sub LstVendedor_Click()
On Error Resume Next
If LstVendedor.ListItems.Count <= 0 Then Exit Sub

    TxtIdVendedor.Text = LstVendedor.ListItems(LstVendedor.SelectedItem.Index).Text
    TxtNomina.Text = LstDVendedor(1, LstVendedor.SelectedItem.Index - 1)
    TxtUsuario.Text = LstDVendedor(2, LstVendedor.SelectedItem.Index - 1)
    TxtApPat.Text = LstDVendedor(8, LstVendedor.SelectedItem.Index - 1)
    TxtApMat.Text = LstDVendedor(9, LstVendedor.SelectedItem.Index - 1)
    TxtNombre.Text = LstDVendedor(7, LstVendedor.SelectedItem.Index - 1)
    CboTipoVen.Text = LstDVendedor(5, LstVendedor.SelectedItem.Index - 1)
    LblEdicion.Caption = "Consultar"
    Nuevo = False
End Sub

Private Sub LstVendedor_DblClick()
On Error Resume Next

    LblEdicion.Caption = "Actualizar"
    Nuevo = False
End Sub

Private Sub LstVendedor_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub LstVendedor_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstVendedor_Click
End Sub

Private Sub SSTab_Click(PreviousTab As Integer)
On Error Resume Next
    Select Case SSTab.Tab
        Case 0:
            MuestraTipoVendedor
        Case 1:
            MuestraVendedor
        Case 2:
            MuestraRutas
        Case 3:
            MuestraUnidades
    End Select
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub TxtApMat_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtApPat_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtCadena_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtIdVendedor_Validate(Cancel As Boolean)
On Error Resume Next

If Trim(TxtIdVendedor.Text) = "" Then
    MsgBox "¡ Teclee un Id de Vendedor !", vbInformation + vbOKOnly, App.Title
    TxtIdVendedor.Text = "": TxtIdVendedor.SetFocus
    Exit Sub
End If
    
    If Rs.State Then Rs.Close
    Rs.Open "select idvendedor from vendedores where idvendedor = " & Trim(TxtIdVendedor.Text) & " and IdCedis = " & IdCedis
    If Not Rs.EOF Then
        MsgBox "¡ El Id de Vendedor ya existe !. Teclea otra clave. ", vbInformation + vbOKOnly, App.Title
        TxtIdVendedor.Text = "": TxtIdVendedor.SetFocus
        Exit Sub
    End If
End Sub

Private Sub TxtMarca_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtNoEcon_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtNombre_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtNomina_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtNoSerie_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtRuta_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtTipoVend_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtUsuario_GotFocus()
On Error Resume Next
       SelText TxtUsuario
End Sub

Private Sub TxtUsuario_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtUsuario_Validate(Cancel As Boolean)
On Error Resume Next
    If Nuevo Then ValidaUsuarioTerminal (True)
End Sub

Private Function ValidaUsuarioTerminal(Mensaje As Boolean) As Boolean
On Error Resume Next
    
    If Rs.State Then Rs.Close
    Rs.Open "exec up_vendedores 0, 0, '', '', '', '', 0, '19000101', '" & Trim(TxtUsuario.Text) & "', 4"
    If Not Rs.EOF Then
        ValidaUsuarioTerminal = True
        If Mensaje Then
            MsgBox "¡ El Usuario de Terminal ya existe !. Teclea otro usuario ", vbInformation + vbOKOnly, App.Title
            TxtUsuario.Text = "": TxtUsuario.SetFocus
        End If
        Exit Function
    Else
        ValidaUsuarioTerminal = False
    End If
End Function
