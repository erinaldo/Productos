VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form AL_Cat_Productos 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   9075
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
   ScaleHeight     =   9075
   ScaleWidth      =   12660
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
      Picture         =   "AL_Cat_Productos.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   63
      Top             =   8520
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
      Picture         =   "AL_Cat_Productos.frx":0710
      Style           =   1  'Graphical
      TabIndex        =   62
      Top             =   8520
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
      Picture         =   "AL_Cat_Productos.frx":0E2B
      Style           =   1  'Graphical
      TabIndex        =   24
      Top             =   8520
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
      Picture         =   "AL_Cat_Productos.frx":14B9
      Style           =   1  'Graphical
      TabIndex        =   25
      Top             =   8520
      Width           =   1695
   End
   Begin TabDlg.SSTab SSTab 
      Height          =   8295
      Left            =   240
      TabIndex        =   26
      Top             =   120
      Width           =   12255
      _ExtentX        =   21616
      _ExtentY        =   14631
      _Version        =   393216
      Tabs            =   5
      Tab             =   4
      TabsPerRow      =   5
      TabHeight       =   520
      TabCaption(0)   =   "Marcas"
      TabPicture(0)   =   "AL_Cat_Productos.frx":1E4F
      Tab(0).ControlEnabled=   0   'False
      Tab(0).Control(0)=   "LblOpt(0)"
      Tab(0).Control(1)=   "FrmOpt(1)"
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "Grupos de Productos"
      TabPicture(1)   =   "AL_Cat_Productos.frx":1E6B
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "LblOpt(1)"
      Tab(1).Control(1)=   "FrmOpt(0)"
      Tab(1).ControlCount=   2
      TabCaption(2)   =   "Familias"
      TabPicture(2)   =   "AL_Cat_Productos.frx":1E87
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "LblOpt(4)"
      Tab(2).Control(1)=   "FrmOpt(2)"
      Tab(2).ControlCount=   2
      TabCaption(3)   =   "SubFamilias"
      TabPicture(3)   =   "AL_Cat_Productos.frx":1EA3
      Tab(3).ControlEnabled=   0   'False
      Tab(3).Control(0)=   "LblOpt(2)"
      Tab(3).Control(1)=   "FrmOpt(4)"
      Tab(3).ControlCount=   2
      TabCaption(4)   =   "Productos"
      TabPicture(4)   =   "AL_Cat_Productos.frx":1EBF
      Tab(4).ControlEnabled=   -1  'True
      Tab(4).Control(0)=   "LblOpt(3)"
      Tab(4).Control(0).Enabled=   0   'False
      Tab(4).Control(1)=   "FrmOpt(3)"
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
         Height          =   7935
         Index           =   2
         Left            =   -75000
         TabIndex        =   54
         Top             =   360
         Width           =   12255
         Begin VB.ComboBox CboGrupo1 
            Height          =   360
            Left            =   240
            Style           =   2  'Dropdown List
            TabIndex        =   5
            Top             =   480
            Width           =   3015
         End
         Begin VB.TextBox TxtIdFamilia 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   3360
            Locked          =   -1  'True
            MaxLength       =   5
            TabIndex        =   6
            Top             =   480
            Width           =   855
         End
         Begin VB.TextBox TxtFamilia 
            Height          =   375
            Left            =   4320
            TabIndex        =   7
            Top             =   480
            Width           =   5895
         End
         Begin MSComctlLib.ListView LstFamilias 
            Height          =   6855
            Left            =   240
            TabIndex        =   57
            Top             =   960
            Width           =   11775
            _ExtentX        =   20770
            _ExtentY        =   12091
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
         Begin VB.Label Label15 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Grupo"
            Height          =   240
            Left            =   240
            TabIndex        =   66
            Top             =   240
            Width           =   525
         End
         Begin VB.Label Label14 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clave"
            Height          =   255
            Left            =   3360
            TabIndex        =   56
            Top             =   240
            Width           =   855
         End
         Begin VB.Label Label13 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Nombre de la  Familia"
            Height          =   240
            Left            =   4320
            TabIndex        =   55
            Top             =   240
            Width           =   1905
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
         Height          =   7935
         Index           =   4
         Left            =   -75000
         TabIndex        =   50
         Top             =   360
         Width           =   12255
         Begin VB.ComboBox CboFamilia1 
            Height          =   360
            Left            =   240
            Style           =   2  'Dropdown List
            TabIndex        =   8
            Top             =   480
            Width           =   3255
         End
         Begin VB.TextBox TxtIdSubFamilia 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   3600
            Locked          =   -1  'True
            MaxLength       =   5
            TabIndex        =   9
            Top             =   480
            Width           =   855
         End
         Begin VB.TextBox TxtSubFamilia 
            Height          =   375
            Left            =   4560
            TabIndex        =   10
            Top             =   480
            Width           =   6255
         End
         Begin MSComctlLib.ListView LstSubFamilias 
            Height          =   6855
            Left            =   240
            TabIndex        =   51
            Top             =   960
            Width           =   11775
            _ExtentX        =   20770
            _ExtentY        =   12091
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
         Begin VB.Label Label19 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Familia"
            Height          =   240
            Left            =   240
            TabIndex        =   58
            Top             =   240
            Width           =   630
         End
         Begin VB.Label Label16 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clave"
            Height          =   255
            Left            =   3600
            TabIndex        =   53
            Top             =   240
            Width           =   855
         End
         Begin VB.Label Label17 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Nombre de la Subfamilia"
            Height          =   240
            Left            =   4560
            TabIndex        =   52
            Top             =   240
            Width           =   2115
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
         Height          =   7935
         Index           =   3
         Left            =   0
         TabIndex        =   38
         Top             =   360
         Width           =   12255
         Begin VB.Frame Frame1 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Estatus del Producto"
            Height          =   615
            Left            =   8760
            TabIndex        =   61
            Top             =   1680
            Width           =   2655
            Begin VB.OptionButton OptStatus 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Activo"
               Height          =   255
               Index           =   0
               Left            =   360
               TabIndex        =   22
               Top             =   280
               Value           =   -1  'True
               Width           =   975
            End
            Begin VB.OptionButton OptStatus 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Baja"
               Height          =   255
               Index           =   1
               Left            =   1560
               TabIndex        =   23
               Top             =   280
               Width           =   855
            End
         End
         Begin VB.ComboBox CboSubFam 
            Height          =   360
            Left            =   8880
            Style           =   2  'Dropdown List
            TabIndex        =   17
            Top             =   1200
            Width           =   3135
         End
         Begin VB.ComboBox CboPres 
            Height          =   360
            Left            =   240
            Style           =   2  'Dropdown List
            TabIndex        =   18
            Top             =   1800
            Width           =   3135
         End
         Begin VB.CheckBox ChkDec 
            Appearance      =   0  'Flat
            BackColor       =   &H80000005&
            Caption         =   "Maneja Decimales"
            ForeColor       =   &H80000008&
            Height          =   375
            Left            =   6720
            TabIndex        =   21
            Top             =   1800
            Width           =   1935
         End
         Begin VB.TextBox TxtCodBarr 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   2280
            MaxLength       =   30
            TabIndex        =   12
            Top             =   600
            Width           =   2055
         End
         Begin VB.TextBox TxtProd 
            Height          =   375
            Left            =   4440
            MaxLength       =   500
            TabIndex        =   13
            Top             =   600
            Width           =   7575
         End
         Begin VB.ComboBox CboMarca 
            Height          =   360
            Left            =   240
            Style           =   2  'Dropdown List
            TabIndex        =   14
            Top             =   1200
            Width           =   2775
         End
         Begin VB.TextBox TxtClave 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   240
            MaxLength       =   10
            TabIndex        =   11
            Top             =   600
            Width           =   1935
         End
         Begin VB.TextBox TxtIVA 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   3480
            MaxLength       =   8
            TabIndex        =   19
            Top             =   1800
            Width           =   1095
         End
         Begin VB.TextBox TxtConv 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   4680
            MaxLength       =   20
            TabIndex        =   20
            Top             =   1800
            Width           =   1815
         End
         Begin VB.ComboBox CboGrupo3 
            Height          =   360
            Left            =   3120
            Style           =   2  'Dropdown List
            TabIndex        =   15
            Top             =   1200
            Width           =   2775
         End
         Begin VB.ComboBox CboFamilia2 
            Height          =   360
            ItemData        =   "AL_Cat_Productos.frx":1EDB
            Left            =   6000
            List            =   "AL_Cat_Productos.frx":1EDD
            Style           =   2  'Dropdown List
            TabIndex        =   16
            Top             =   1200
            Width           =   2775
         End
         Begin MSComctlLib.ListView LstProd 
            Height          =   5295
            Left            =   240
            TabIndex        =   39
            Top             =   2400
            Width           =   11775
            _ExtentX        =   20770
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
         Begin VB.Label Label21 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Presentación"
            Height          =   240
            Left            =   240
            TabIndex        =   60
            Top             =   1560
            Width           =   1140
         End
         Begin VB.Label Label20 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "SubFamilia"
            Height          =   240
            Left            =   8880
            TabIndex        =   59
            Top             =   960
            Width           =   975
         End
         Begin VB.Label Label6 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Nombre del Producto"
            Height          =   240
            Left            =   4440
            TabIndex        =   47
            Top             =   360
            Width           =   1830
         End
         Begin VB.Label Label7 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Código de Barras"
            Height          =   255
            Left            =   2280
            TabIndex        =   46
            Top             =   360
            Width           =   1815
         End
         Begin VB.Label Label10 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Marca"
            Height          =   240
            Left            =   240
            TabIndex        =   45
            Top             =   960
            Width           =   540
         End
         Begin VB.Label Label1 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clave"
            Height          =   255
            Left            =   240
            TabIndex        =   44
            Top             =   360
            Width           =   615
         End
         Begin VB.Label Label2 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Impuestos"
            Height          =   255
            Left            =   3480
            TabIndex        =   43
            Top             =   1560
            Width           =   1095
         End
         Begin VB.Label Label3 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Conversión"
            Height          =   255
            Left            =   4680
            TabIndex        =   42
            Top             =   1560
            Width           =   975
         End
         Begin VB.Label Label4 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Grupo"
            Height          =   240
            Left            =   3240
            TabIndex        =   41
            Top             =   960
            Width           =   525
         End
         Begin VB.Label Label5 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Familia"
            Height          =   240
            Left            =   6000
            TabIndex        =   40
            Top             =   960
            Width           =   630
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
         Height          =   7935
         Index           =   0
         Left            =   -75000
         TabIndex        =   29
         Top             =   360
         Width           =   12255
         Begin VB.ComboBox cmbMarca1 
            Height          =   360
            Left            =   240
            Style           =   2  'Dropdown List
            TabIndex        =   2
            Top             =   480
            Width           =   3495
         End
         Begin VB.TextBox TxtIdGrupo 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   3840
            Locked          =   -1  'True
            MaxLength       =   5
            TabIndex        =   3
            Top             =   480
            Width           =   855
         End
         Begin VB.TextBox TxtGrupo 
            Height          =   375
            Left            =   4800
            TabIndex        =   4
            Top             =   480
            Width           =   5655
         End
         Begin MSComctlLib.ListView LstGrupos 
            Height          =   6735
            Left            =   240
            TabIndex        =   33
            Top             =   960
            Width           =   11775
            _ExtentX        =   20770
            _ExtentY        =   11880
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
         Begin VB.Label Label22 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Marca"
            Height          =   240
            Left            =   240
            TabIndex        =   65
            Top             =   240
            Width           =   540
         End
         Begin VB.Label Label12 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clave"
            Height          =   255
            Left            =   3840
            TabIndex        =   35
            Top             =   240
            Width           =   855
         End
         Begin VB.Label Label11 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Nombre del Grupo"
            Height          =   240
            Left            =   4800
            TabIndex        =   34
            Top             =   240
            Width           =   1575
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
         Height          =   7935
         Index           =   1
         Left            =   -75000
         TabIndex        =   28
         Top             =   360
         Width           =   12255
         Begin VB.TextBox TxtIdMarca 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   240
            Locked          =   -1  'True
            MaxLength       =   5
            TabIndex        =   0
            Top             =   480
            Width           =   855
         End
         Begin VB.TextBox TxtMarca 
            Height          =   375
            Left            =   1200
            TabIndex        =   1
            Top             =   480
            Width           =   6255
         End
         Begin MSComctlLib.ListView LstMarca 
            Height          =   6735
            Left            =   240
            TabIndex        =   30
            Top             =   960
            Width           =   11775
            _ExtentX        =   20770
            _ExtentY        =   11880
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
         Begin VB.Label Label9 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clave"
            Height          =   255
            Left            =   240
            TabIndex        =   32
            Top             =   240
            Width           =   855
         End
         Begin VB.Label Label8 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Nombre de la Marca"
            Height          =   240
            Left            =   1200
            TabIndex        =   31
            Top             =   240
            Width           =   1755
         End
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Familias"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   4
         Left            =   -70120
         TabIndex        =   49
         Top             =   0
         Width           =   2490
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "SubFamilias"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   2
         Left            =   -67680
         TabIndex        =   48
         Top             =   0
         Width           =   2480
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Productos"
         ForeColor       =   &H80000008&
         Height          =   495
         Index           =   3
         Left            =   9770
         TabIndex        =   37
         Top             =   0
         Width           =   2490
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Grupos de Productos"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   1
         Left            =   -72560
         TabIndex        =   36
         Top             =   0
         Width           =   2470
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Marcas"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   0
         Left            =   -75000
         TabIndex        =   27
         Top             =   0
         Width           =   2465
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
      Left            =   7800
      TabIndex        =   64
      Top             =   8640
      Width           =   810
   End
End
Attribute VB_Name = "AL_Cat_Productos"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDCanales, LstDCadenas, Nuevo As Boolean
Dim ListaDePresentacion, ListaDeSubfamilias, ListaDeFAmilias, ListaDeGrupos, ListaDeMarcas, LstDProductos
Dim LstDMarcas, LstDGrupos, LstDFamilias, LstDSubFamilias

Private Sub btnActualizar_Click()
Dim MARCA, GRUPO, FAMILIA, SUBFAMILIA As Integer
    
On Error GoTo Err_CatProdsG:

If LblEdicion.Caption = "Consultar" Then Exit Sub
    
    Select Case SSTab.Tab
        Case 0: If Not ValidaModulo("CATPRODMAR", True) Then Exit Sub
        Case 1: If Not ValidaModulo("CATPRODGPO", True) Then Exit Sub
        Case 2: If Not ValidaModulo("CATPRODFAM", True) Then Exit Sub
        Case 3: If Not ValidaModulo("CATPRODSUBFAM", True) Then Exit Sub
        Case 4: If Not ValidaModulo("CATPRODPROD", True) Then Exit Sub
    End Select
    
    Select Case SSTab.Tab
        Case 0:
        
            If Trim(TxtIdMarca.Text) = "" Or Trim(TxtMarca.Text) = "" Then
                MsgBox "¡ Teclee los Datos para Actualizar !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        
            StrCmd = "execute up_Marcas " & Trim(TxtIdMarca.Text) & ", '" & UCase(Trim(TxtMarca.Text)) & "', '" & FormatDate(Date) & "'," & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraMarcas
            LLENA_COMBOS
            Nuevo = False
            
        Case 1:
        
            If cmbMarca1.ListIndex = 0 Then
                MsgBox "¡ Selecciona la Marca de Producto !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        
            If Trim(TxtIdGrupo.Text) = "" Or Trim(TxtGrupo.Text) = "" Then
                MsgBox "¡ Teclee los Datos para Actualizar !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        
            StrCmd = "execute up_Grupos " & Trim(TxtIdGrupo.Text) & ", '" & UCase(Trim(TxtGrupo.Text)) & "', '" & FormatDate(Date) & "'," & ListaDeMarcas(0, cmbMarca1.ListIndex - 1) & ", " & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraGrupos
            Nuevo = False
                    
        Case 2:
            If CboGrupo1.ListIndex = 0 Then
                MsgBox "¡ Selecciona el Grupo de Producto !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            If Trim(TxtIdFamilia.Text) = "" Or Trim(TxtFamilia.Text) = "" Or Trim(CboGrupo1.Text) = "" Then
                MsgBox "¡ Teclee los Datos para Actualizar !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If

            StrCmd = "execute up_Familias " & Trim(TxtIdFamilia.Text) & ", '" & UCase(Trim(TxtFamilia.Text)) & "' , " & ListaDeGrupos(0, CboGrupo1.ListIndex - 1) & " , '" & FormatDate(Date) & "'," & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraFamilias
            Nuevo = False
                                        
        Case 3:
            If CboFamilia1.ListIndex = 0 Then
                MsgBox "¡ Selecciona la Familia de Producto !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            If Trim(TxtIdSubFamilia.Text) = "" Or Trim(TxtSubFamilia.Text) = "" Then
                MsgBox "¡ Teclee los Datos para Actualizar !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If

            StrCmd = "execute up_SubFamilias " & Trim(TxtIdSubFamilia.Text) & ", '" & UCase(Trim(TxtSubFamilia.Text)) & "' , 0, " & ListaDeFAmilias(0, CboFamilia1.ListIndex - 1) & " , '" & FormatDate(Date) & "'," & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraSubFamilias
            Nuevo = False
                                    
        Case 4:
            
            If Trim(TxtClave.Text) = "" Or Trim(TxtProd.Text) = "" Or Trim(TxtIVA.Text) = "" Or Trim(TxtConv.Text) = "" Or Trim(CboMarca.Text) = "" Or Trim(CboGrupo3.Text) = "" Or Trim(CboFamilia2.Text) = "" Or Trim(CboSubFam.Text) = "" Then
                MsgBox "¡ Teclee los Datos para Actualizar !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            If Nuevo Then
                If Rs.State Then Rs.Close
                Rs.Open "select IdProducto from Productos where IdProducto = " & CDbl(TxtClave.Text)
                If Not Rs.EOF Then
                    MsgBox "¡ La clave de producto ya existe !. Teclea otra clave. ", vbInformation + vbOKOnly, App.Title
                    TxtClave.SetFocus
                    Exit Sub
                End If
                
                If Trim(TxtCodBarr.Text) <> "" Then
                    If Rs.State Then Rs.Close
                    Rs.Open "select codbarras from Productos where codbarras = '" & Trim(TxtCodBarr.Text) & "'"
                    If Not Rs.EOF Then
                        MsgBox "¡ El código de barras ya existe !. Teclea otra clave. ", vbInformation + vbOKOnly, App.Title
                        TxtCodBarr.SetFocus
                        Exit Sub
                    End If
                End If
            Else
                If Not Nuevo Then
                If Trim(TxtCodBarr.Text) <> "" Then
'                    If Rs.State Then Rs.Close
'                    Rs.Open "select codbarras from Productos where codbarras = '" & Trim(TxtCodBarr.Text) & "'"
'                    If Not Rs.EOF Then
'                        MsgBox "¡ El código de barras ya existe !. Teclea otra clave. ", vbInformation + vbOKOnly, App.Title
'                        TxtCodBarr.SetFocus
'                        Exit Sub
'                    End If
                End If
                End If
            End If
            
            'valida si es baja del producto
            If OptStatus(1) Then
                If MsgBox("¿ Estás seguro que deseas dar de Baja el Producto " & TxtClave.Text & " - " & UCase(Trim(TxtProd.Text)) & " ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
                    
                    StrCmd = "execute up_Productos " & Trim(UCase(TxtClave.Text)) & ", '', '', 0, 0, 0, 0, 0, 0, '', '01/01/1900', 0, 3"
                    If Rs.State Then Rs.Close
                    Rs.Open StrCmd, Cnn
                    MuestraProductos
                    Nuevo = False
                    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
                    Exit Sub
                Else
                    Exit Sub
                End If
            End If
            
            If Rs.State Then Rs.Close
            Rs.Open "SELECT * FROM MARCAS WHERE MARCA = '" & Trim(CboMarca.Text) & "'", Cnn
            If Rs.EOF Then
                MARCA = 0
            Else
                MARCA = Rs!IdMarca
            End If
            
            If Rs.State Then Rs.Close
            Rs.Open "SELECT * FROM GRUPOS WHERE GRUPO = '" & Trim(CboGrupo3.Text) & "'", Cnn
            If Rs.EOF Then
                GRUPO = 0
            Else
                GRUPO = Rs!IdGrupo
            End If
            
            If Rs.State Then Rs.Close
            Rs.Open "SELECT * FROM FAMILIAS WHERE FAMILIA = '" & Trim(CboFamilia2.Text) & "'", Cnn
            If Rs.EOF Then
                FAMILIA = 0
            Else
                FAMILIA = Rs!IdFamilia
            End If
            
            If Rs.State Then Rs.Close
            Rs.Open "SELECT * FROM SUBFAMILIAS WHERE SUBFAMILIA = '" & Trim(CboSubFam.Text) & "'", Cnn
            If Rs.EOF Then
                SUBFAMILIA = 0
            Else
                SUBFAMILIA = Rs!IdSubFamilia
            End If
            
            If Rs.State Then Rs.Close
            Rs.Open "SELECT * FROM presentacion WHERE presentacion = '" & Trim(CboPres.Text) & "'", Cnn
            If Rs.EOF Then
                presentacion = 0
            Else
                presentacion = Rs!idpresentacion
            End If
            
            
            If ChkDec.Value = 1 Then
                NoDec = 1
            Else
                NoDec = 0
            End If

            StrCmd = "execute up_Productos " & UCase(TxtClave.Text) & ", '" & UCase(TxtCodBarr.Text) & "',  " _
                    & " '" & UCase(TxtProd.Text) & "', " & Trim(TxtIVA.Text) & ", " & Trim(TxtConv.Text) & ", " _
                    & " " & MARCA & ", " & GRUPO & ", " & FAMILIA & ", " & SUBFAMILIA & ", '" & presentacion & "', " _
                    & " '" & FormatDate(Date) & "', " & NoDec & "," & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraProductos
            Nuevo = False
            
    End Select
    
No_Err_CatProdsG:
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
    LblEdicion.Caption = "Consultar"
    Exit Sub
        
Err_CatProdsG:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_CatProdsG:

End Sub

Private Sub btnEliminar_Click()
    
On Error GoTo Err_CatProdsE:

    Select Case SSTab.Tab
        Case 0: If Not ValidaModulo("CATPRODMAR", True) Then Exit Sub
        Case 1: If Not ValidaModulo("CATPRODGPO", True) Then Exit Sub
        Case 2: If Not ValidaModulo("CATPRODFAM", True) Then Exit Sub
        Case 3: If Not ValidaModulo("CATPRODSUBFAM", True) Then Exit Sub
        Case 4: If Not ValidaModulo("CATPRODPROD", True) Then Exit Sub
    End Select
    
    Select Case SSTab.Tab
        Case 0:
            
            If Trim(TxtIdMarca.Text) = "" Then
                MsgBox "¡ Seleccione el registro a dar de Baja !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        
            StrCmd = "execute up_Marcas " & TxtIdMarca.Text & ", '','', 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraMarcas
            Nuevo = False
            
            
        Case 1:
            
            If Trim(TxtIdGrupo.Text) = "" Then
                MsgBox "¡ Seleccione el registro a dar de Baja !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        
            StrCmd = "execute up_Grupos " & TxtIdGrupo.Text & ", '','', 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraGrupos
            Nuevo = False
                      
        Case 2:
        
            If Trim(TxtIdFamilia.Text) = "" Then
                MsgBox "¡ Seleccione el registro a dar de Baja !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If

            StrCmd = "execute up_Familias " & TxtIdFamilia.Text & ",'','','',3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraFamilias
            Nuevo = False
                      
        Case 3:
        
            If Trim(TxtIdSubFamilia.Text) = "" Then
                MsgBox "¡ Seleccione el registro a dar de Baja !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If

            StrCmd = "execute up_SubFamilias " & TxtIdSubFamilia.Text & ",'','','','',3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraSubFamilias
            Nuevo = False
            
        Case 4:
        
            If Trim(TxtClave.Text) = "" Then
                MsgBox "¡ Seleccione el registro a dar de Baja !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If

            StrCmd = "execute up_Productos " & TxtClave.Text & ",'','','','','','','','','','','',3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraProductos
            Nuevo = False
            
    End Select
    
No_Err_CatProdsE:
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
    LblEdicion.Caption = "Consultar"
    Exit Sub
        
Err_CatProdsE:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_CatProdsE:

End Sub

Private Sub btnImprimir_Click()

On Error GoTo Err_CatProdsI:

    Select Case SSTab.Tab
        Case 0:
            With AL_RptCatMarcas
                .Caption = "Catálogo de Marcas"
                .LblTitulo.Caption = "Catálogo de Marcas"
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                StrCmd = "select IdMarca, Marca, " _
                        & " Case Status " _
                        & " when 'A' then 'Activo' " _
                        & " Else 'Baja' " _
                        & " end as 'Estatus' from Marcas order by Marca"
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
            With AL_RptCatGrupos
                .Caption = "Catálogo de Grupos"
                .LblTitulo.Caption = "Catálogo de Grupos"
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                StrCmd = "select IdGrupo, Grupo, " _
                        & " Case Status " _
                        & " when 'A' then 'Activo' " _
                        & " Else 'Baja' " _
                        & " end as 'Estatus' from grupos order by grupo"
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
            With AL_RptCatFamilias
                .Caption = "Catálogo de Familias"
                .LblTitulo.Caption = "Catálogo de Familias"
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                StrCmd = "select f.idfamilia, f.familia, g.grupo, " _
                        & " Case f.Status " _
                        & " when 'A' then 'Activo' " _
                        & " Else 'Baja' " _
                        & " end as 'Estatus' " _
                        & " from familias f " _
                        & " left outer join grupos g on g.idgrupo = f.idgrupo " _
                        & " order by f.familia"
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
            With AL_RptCatSubFam
                .Caption = "Catálogo de Subfamilias"
                .LblTitulo.Caption = "Catálogo de Subfamilias"
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                StrCmd = "select s.IdSubfamilia, s.subfamilia, f.familia, g.grupo, " _
                        & " Case s.Status " _
                        & " when 'A' then 'Activo' " _
                        & " Else 'Baja' " _
                        & " end as 'Estatus' " _
                        & " from subfamilias s " _
                        & " left outer join familias f on s.FAMILIA = f.idfamilia " _
                        & " left outer join grupos g on s.GRUPO = g.idgrupo " _
                        & " order by s.subfamilia, f.familia"
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
            
        Case 4:
            With AL_RptCatProd
                .Caption = "Catálogo de Productos"
                .LblTitulo.Caption = "Catálogo de Productos"
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                StrCmd = "select P.IdProducto, P.Producto, P.iva, P.Conversion, G.Grupo, F.Familia, S.SubFamilia, M.Marca,  " _
                    & " Case P.Status " _
                    & " when 'A' then 'Activo' " _
                    & " Else 'Baja' " _
                    & " end as 'Estatus' " _
                    & " from Productos P " _
                    & " left outer join Marcas M on P.IdMarca = M.IdMarca " _
                    & " left outer join Grupos G on P.IdGrupo = G.IdGrupo " _
                    & " left outer join Familias F on P.IdFamilia = F.IdFamilia " _
                    & " left outer join Subfamilias S on P.IdSubFamilia = S.IdSubFamilia " _
                    & " order by G.Grupo, F.Familia, S.SubFamilia,M.Marca "
                    If RsC.State Then RsC.Close
                    RsC.Open StrCmd, Cnn
        
                If Not RsC.EOF Then
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = RsC
                    .Printer.Orientation = ddOPortrait
                    .Printer.PaperSize = 1
                    .Printer.Orientation = ddOLandscape
                    .Show
                End If
            End With
                        
    End Select
      
 
No_Err_CatProdsI:
    LblEdicion.Caption = "Consultar"
    Exit Sub
        
Err_CatProdsI:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_CatProdsI:

End Sub

Private Sub btnNuevo_Click()
On Error GoTo Err_CatProdsN:

    Select Case SSTab.Tab
        Case 0: If Not ValidaModulo("CATPRODMAR", True) Then Exit Sub
        Case 1: If Not ValidaModulo("CATPRODGPO", True) Then Exit Sub
        Case 2: If Not ValidaModulo("CATPRODFAM", True) Then Exit Sub
        Case 3: If Not ValidaModulo("CATPRODSUBFAM", True) Then Exit Sub
        Case 4: If Not ValidaModulo("CATPRODPROD", True) Then Exit Sub
    End Select
    
    Select Case SSTab.Tab
        Case 0:
            TxtIdMarca.Text = "": TxtMarca.Text = ""
            If Rs.State Then Rs.Close
            Rs.Open "SELECT ISNULL(MAX(IdMarca),0)+1 AS MAXI From Marcas", Cnn
            TxtIdMarca.Text = Rs!MAXI
            Nuevo = True
            TxtMarca.SetFocus
            
        Case 1:
            TxtIdGrupo.Text = "": TxtGrupo.Text = ""
            If Rs.State Then Rs.Close
            Rs.Open "SELECT ISNULL(MAX(IdGrupo),0)+1 AS MAXI From Grupos", Cnn
            TxtIdGrupo.Text = Rs!MAXI
            Nuevo = True
            TxtGrupo.SetFocus
            
        Case 2:
            TxtIdFamilia.Text = "": TxtFamilia.Text = "" ': CboGrupo1.Text = ""
            If Rs.State Then Rs.Close
            Rs.Open "SELECT ISNULL(MAX(IdFamilia),0)+1 AS MAXI From Familias", Cnn
            TxtIdFamilia.Text = Rs!MAXI
            Nuevo = True
            TxtFamilia.SetFocus
                
        Case 3:
            TxtIdSubFamilia.Text = "": TxtSubFamilia.Text = "" ': CboGrupo2.Text = "": CboFamilia1.Text = ""
            If Rs.State Then Rs.Close
            Rs.Open "SELECT ISNULL(MAX(IdSubFamilia),0)+1 AS MAXI From SUBFAMILIAS", Cnn
            TxtIdSubFamilia.Text = Rs!MAXI
            Nuevo = True
            TxtSubFamilia.SetFocus
            
        Case 4:
            TxtClave.Text = "": TxtCodBarr.Text = "": TxtProd.Text = "": TxtIVA.Text = "": TxtConv.Text = "": ChkDec.Value = 0
            'CboMarca.Text = "": CboGrupo3.Text = "": CboFamilia2.Text = "": CboSubFamilia.Text = "": CboPrest.Text = ""
            Nuevo = True
            TxtClave.SetFocus
                        
    End Select

No_Err_CatProdsN:
    LblEdicion.Caption = "Nuevo"
    Exit Sub
        
Err_CatProdsN:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_CatProdsN:
End Sub

Private Sub CboFamilia1_Click()
On Error Resume Next
    MuestraSubFamilias
End Sub

Private Sub CboFamilia2_Click()
On Error Resume Next
    If CboFamilia2.ListIndex = 0 Then
        StrCmd = "execute sel_subfamilias 0, 2"
    Else
        StrCmd = "exec sel_subfamilias " & ListaDeSubfamilias(0, CboFamilia2.ListIndex - 1) & ", 2"
    End If
    If Rs.State = 1 Then Rs.Close
    Rs.Open StrCmd, Cnn
    ListaDeSubfamilias = GetDataCBL(Rs, CboSubFam, "Seleccione el SubFamilia", "No se Encontraron Registros de SubFamilias")

End Sub

Private Sub CboGrupo1_Click()
On Error Resume Next
    MuestraFamilias
End Sub

Private Sub CboGrupo3_Click()
On Error Resume Next
    If CboGrupo3.ListIndex = 0 Then
        StrCmd = "execute sel_familias 0, 2"
    Else
        StrCmd = "execute sel_familias " & ListaDeGrupos(0, CboGrupo3.ListIndex - 1) & ", 2"
    End If
    If Rs.State = 1 Then Rs.Close
    Rs.Open StrCmd, Cnn
    ListaDeFAmilias = GetDataCBL(Rs, CboFamilia2, "Seleccione la Familia", "No se Encontraron Registros de Familias")

End Sub

Private Sub CboMarca_Click()
On Error Resume Next
    If CboMarca.ListIndex = 0 Then
        StrCmd = "execute sel_grupos 0, 2"
    Else
        StrCmd = "execute sel_grupos " & ListaDeMarcas(0, CboMarca.ListIndex - 1) & ", 2"
    End If
    If Rs.State = 1 Then Rs.Close
    Rs.Open StrCmd, Cnn
    ListaDeGrupos = GetDataCBL(Rs, CboGrupo3, "Seleccione el Grupo", "No se Encontraron Registros de Grupos")
End Sub

Private Sub cmbMarca1_Click()
On Error Resume Next
    MuestraGrupos
End Sub

Private Sub Form_Load()
On Error Resume Next
    Nuevo = False
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    LLENA_COMBOS
    MuestraProductos
    SSTab.Tab = 4
End Sub

Sub MuestraMarcas()
On Error Resume Next
    StrCmd = "execute sel_Marcas 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDMarcas = GetDataLVL(Rs, LstMarca, 0, 3, "0|0|4|0")
End Sub

Sub MuestraGrupos()
On Error Resume Next
    
    If cmbMarca1.ListIndex = 0 Then
        StrCmd = "execute sel_Grupos 0, 1"
    Else
        StrCmd = "execute sel_Grupos " & ListaDeMarcas(0, cmbMarca1.ListIndex - 1) & ", 2"
    End If
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDGrupos = GetDataLVL(Rs, LstGrupos, 0, 4, "0|0|0|4|0")
End Sub

Sub MuestraFamilias()
On Error Resume Next

    If CboGrupo1.ListIndex = 0 Then
        StrCmd = "execute sel_Familias 0, 1"
    Else
        StrCmd = "execute sel_Familias " & ListaDeGrupos(0, CboGrupo1.ListIndex - 1) & ", 2"
    End If

    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDFamilias = GetDataLVL(Rs, LstFamilias, 0, 4, "0|0|0|4|0")
End Sub

Sub MuestraSubFamilias()
On Error Resume Next
    If CboFamilia1.ListIndex = 0 Then
        StrCmd = "execute sel_SubFamilias 0, 1"
    Else
        StrCmd = "execute sel_SubFamilias " & ListaDeFAmilias(0, CboFamilia1.ListIndex - 1) & ", 2"
    End If
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDSubFamilias = GetDataLVL(Rs, LstSubFamilias, 0, 5, "0|0|0|0|4|0")
End Sub

Sub MuestraProductos()
On Error Resume Next
    StrCmd = "execute sel_Productos "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDProductos = GetDataLVL(Rs, LstProd, 0, 14, "0|0|0|0|10|0|0|0|0|0|0|0|0|0")
End Sub

Sub LLENA_COMBOS()
        
   On Error GoTo ErrConexion2
    
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    If Rs.State Then Rs.Close
             
        StrCmd = "execute sel_Marcas 1"
        If Rs.State = 1 Then Rs.Close
        Rs.Open StrCmd, Cnn
        ListaDeMarcas = GetDataCBL(Rs, CboMarca, "Seleccione la Marca", "No se Encontraron Registros de Marcas")
        StrCmd = "execute sel_Marcas 1"
        If Rs.State = 1 Then Rs.Close
        Rs.Open StrCmd, Cnn
        ListaDeMarcas = GetDataCBL(Rs, cmbMarca1, "Seleccione la Marca", "No se Encontraron Registros de Marcas")
            
        StrCmd = "execute sel_grupos 0, 1"
        If Rs.State = 1 Then Rs.Close
        Rs.Open StrCmd, Cnn
        ListaDeGrupos = GetDataCBL(Rs, CboGrupo1, "Seleccione el Grupo", "No se Encontraron Registros de Grupos")
'        StrCmd = "execute sel_grupos 0, 1"
'        If Rs.State = 1 Then Rs.Close
'        Rs.Open StrCmd, Cnn
'        ListaDeGrupos = GetDataCBL(Rs, CboGrupo3, "Seleccione el Grupo", "No se Encontraron Registros de Grupos")
        
        StrCmd = "execute sel_familias 0, 1"
        If Rs.State = 1 Then Rs.Close
        Rs.Open StrCmd, Cnn
        ListaDeFAmilias = GetDataCBL(Rs, CboFamilia1, "Seleccione la Familia", "No se Encontraron Registros de Familias")
'        StrCmd = "execute sel_familias 0, 1"
'        If Rs.State = 1 Then Rs.Close
'        Rs.Open StrCmd, Cnn
'        ListaDeFAmilias = GetDataCBL(Rs, CboFamilia2, "Seleccione la Familia", "No se Encontraron Registros de Familias")
                
'        StrCmd = "LlenaCombos 4"
'        If Rs.State = 1 Then Rs.Close
'        Rs.Open StrCmd, Cnn
'        ListaDeSubfamilias = GetDataCBL(Rs, CboSubFam, "Seleccione el SubFamilia", "No se Encontraron Registros de SubFamilias")

        StrCmd = "LlenaCombos 5"
        If Rs.State = 1 Then Rs.Close
        Rs.Open StrCmd, Cnn
        ListaDePresentacion = GetDataCBL(Rs, CboPres, "Seleccione el Presentación", "No se Encontraron Registros de Presentaciónes")
                
    Exit Sub
ErrConexion2:
    MsgBox "Error al tratar de conectarse al Servidor. " & Chr(13) & Chr(10) & Err.Description, vbExclamation, "Error de Conexión...."
    
    MousePointer = 0
    Exit Sub
    
    
End Sub

Private Sub LstFamilias_Click()
On Error Resume Next

If LstFamilias.ListItems.Count <= 0 Then Exit Sub
    
    TxtIdFamilia.Text = LstFamilias.ListItems.Item(LstFamilias.SelectedItem.Index).Text
    TxtFamilia.Text = LstFamilias.ListItems.Item(LstFamilias.SelectedItem.Index).SubItems(1)
    Nuevo = False
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub LstFamilias_DblClick()
On Error Resume Next

If LstFamilias.ListItems.Count <= 0 Then Exit Sub
    
    Nuevo = False
    LblEdicion.Caption = "Actualizar"
End Sub

Private Sub LstFamilias_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstFamilias_Click
End Sub

Private Sub LstGrupos_Click()
On Error Resume Next

If LstGrupos.ListItems.Count <= 0 Then Exit Sub
    
    TxtIdGrupo.Text = LstGrupos.ListItems.Item(LstGrupos.SelectedItem.Index).Text
    TxtGrupo.Text = LstGrupos.ListItems.Item(LstGrupos.SelectedItem.Index).SubItems(1)
    Nuevo = False
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub LstGrupos_DblClick()
On Error Resume Next

If LstGrupos.ListItems.Count <= 0 Then Exit Sub
    
    Nuevo = False
    LblEdicion.Caption = "Actualizar"
End Sub

Private Sub LstGrupos_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstGrupos_Click
End Sub

Private Sub LstMarca_Click()
On Error Resume Next

If LstMarca.ListItems.Count <= 0 Then Exit Sub
    
    TxtIdMarca.Text = LstMarca.ListItems.Item(LstMarca.SelectedItem.Index).Text
    TxtMarca.Text = LstMarca.ListItems.Item(LstMarca.SelectedItem.Index).SubItems(1)
    Nuevo = False
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub LstMarca_DblClick()
On Error Resume Next

If LstMarca.ListItems.Count <= 0 Then Exit Sub
    
    Nuevo = False
    LblEdicion.Caption = "Actualizar"
End Sub

Private Sub LstMarca_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstMarca_Click
End Sub

Private Sub LstProd_Click()
On Error Resume Next

If LstProd.ListItems.Count <= 0 Then Exit Sub

    TxtClave.Text = LstProd.ListItems.Item(LstProd.SelectedItem.Index).Text
    TxtCodBarr.Text = LstProd.ListItems.Item(LstProd.SelectedItem.Index).SubItems(1)
    TxtProd.Text = LstProd.ListItems.Item(LstProd.SelectedItem.Index).SubItems(2)
    TxtIVA = LstProd.ListItems.Item(LstProd.SelectedItem.Index).SubItems(3)
    TxtConv = LstProd.ListItems.Item(LstProd.SelectedItem.Index).SubItems(4)
'    CboMarca = LstProd.ListItems.Item(LstProd.SelectedItem.Index).SubItems(5)
'    CboGrupo3 = LstProd.ListItems.Item(LstProd.SelectedItem.Index).SubItems(6)
'    CboFamilia2 = LstProd.ListItems.Item(LstProd.SelectedItem.Index).SubItems(7)
    CboMarca.ListIndex = SearchInList(ListaDeMarcas, LstDProductos(5, LstProd.SelectedItem.Index - 1), 1)
    CboGrupo3.ListIndex = SearchInList(ListaDeGrupos, LstDProductos(6, LstProd.SelectedItem.Index - 1), 1)
    CboFamilia2.ListIndex = SearchInList(ListaDeFAmilias, LstDProductos(7, LstProd.SelectedItem.Index - 1), 1)
    CboSubFam.ListIndex = SearchInList(ListaDeSubfamilias, LstDProductos(8, LstProd.SelectedItem.Index - 1), 1)
    CboPres.ListIndex = SearchInList(ListaDePresentacion, LstDProductos(9, LstProd.SelectedItem.Index - 1), 1)
    
    If Mid(Trim(LstProd.ListItems.Item(LstProd.SelectedItem.Index).SubItems(11)), 1, 1) <> "A" Then
        OptStatus(1).Value = True
    Else
        OptStatus(0).Value = True
    End If
    
    If LstProd.ListItems.Item(LstProd.SelectedItem.Index).SubItems(12) = "Decimales" Then
        ChkDec.Value = 1
    Else
        ChkDec.Value = 0
    End If
    
    Nuevo = False
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub LstProd_DblClick()
On Error Resume Next

If LstProd.ListItems.Count <= 0 Then Exit Sub
    
    Nuevo = False
    LblEdicion.Caption = "Actualizar"
End Sub

Private Sub LstProd_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstProd_Click
End Sub

Private Sub LstSubFamilias_Click()
On Error Resume Next

If LstSubFamilias.ListItems.Count <= 0 Then Exit Sub

    TxtIdSubFamilia.Text = LstSubFamilias.ListItems.Item(LstSubFamilias.SelectedItem.Index).Text
    TxtSubFamilia.Text = LstSubFamilias.ListItems.Item(LstSubFamilias.SelectedItem.Index).SubItems(1)
    Nuevo = False
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub LstSubFamilias_DblClick()
On Error Resume Next

If LstSubFamilias.ListItems.Count <= 0 Then Exit Sub

    Nuevo = False
    LblEdicion.Caption = "Actualizar"
End Sub

Private Sub LstSubFamilias_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstSubFamilias_Click
End Sub

Private Sub SSTab_Click(PreviousTab As Integer)
On Error Resume Next
    LLENA_COMBOS
    Select Case SSTab.Tab
        Case 0:
            MuestraMarcas
        Case 1:
            MuestraGrupos
        Case 2:
            MuestraFamilias
        Case 3:
            MuestraSubFamilias
        Case 4:
            MuestraProductos
    End Select
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub TxtClave_KeyPress(KeyAscii As Integer)
On Error Resume Next
  If IsNumeric(Chr(KeyAscii)) = False And KeyAscii <> 8 And KeyAscii <> 13 Then KeyAscii = 0
End Sub

Private Sub TxtClave_Validate(Cancel As Boolean)
On Error Resume Next
If TxtClave.Text <> "" Then
    If Rs.State Then Rs.Close
    Rs.Open "select Idproducto from productos where Idproducto = " & TxtClave & " "
    If Not Rs.EOF Then
        MsgBox "¡ Clave de producto ya existe !. Teclea otra clave. ", vbInformation + vbOKOnly, App.Title
        TxtClave.SetFocus
        Exit Sub
    Else
        TxtCodBarr.SetFocus
    End If
End If
End Sub

Private Sub TxtCodBarr_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 46 Then KeyAscii = 0
    If IsNumeric(Chr(KeyAscii)) = False And KeyAscii <> 46 And KeyAscii <> 8 And KeyAscii <> 13 Then KeyAscii = 0
End Sub

Private Sub TxtConv_KeyPress(KeyAscii As Integer)
On Error Resume Next
  If IsNumeric(Chr(KeyAscii)) = False And KeyAscii <> 46 And KeyAscii <> 8 And KeyAscii <> 13 Then KeyAscii = 0
  If InStr(1, TxtConv.Text, ".") <> 0 And KeyAscii = 46 Then KeyAscii = 0
End Sub

Private Sub TxtFamilia_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtGrupo_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtIVA_KeyPress(KeyAscii As Integer)
On Error Resume Next
  If IsNumeric(Chr(KeyAscii)) = False And KeyAscii <> 46 And KeyAscii <> 8 And KeyAscii <> 13 Then KeyAscii = 0
  If InStr(1, TxtIVA.Text, ".") <> 0 And KeyAscii = 46 Then KeyAscii = 0
End Sub

Public Function fnCoincidencias(cadena As String, caracter As String) As Integer
On Error Resume Next
Dim X, longitud As Integer
  longitud = Len(cadena)
  For X = 1 To longitud
    If Mid(cadena, X, 1) Like caracter Then fnCoincidencias = fnCoincidencias + 1
  Next X
End Function

Private Sub TxtMarca_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtProd_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtSubFamilia_KeyPress(KeyAscii As Integer)
On Error Resume Next
        KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub
