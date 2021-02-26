VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form Cat_Clientes 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Catalogo de Clientes"
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
   Begin VB.CommandButton btnActualizar 
      BackColor       =   &H00FFFFFF&
      Caption         =   "&Actualizar"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1065
      Left            =   11370
      Picture         =   "Cat_Clientes.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   45
      Top             =   5100
      Width           =   1185
   End
   Begin TabDlg.SSTab SSTab 
      Height          =   8205
      Left            =   120
      TabIndex        =   48
      Top             =   120
      Width           =   11145
      _ExtentX        =   19659
      _ExtentY        =   14473
      _Version        =   393216
      Tabs            =   5
      Tab             =   4
      TabsPerRow      =   5
      TabHeight       =   520
      TabCaption(0)   =   "Canales de Distribución"
      TabPicture(0)   =   "Cat_Clientes.frx":038C
      Tab(0).ControlEnabled=   0   'False
      Tab(0).Control(0)=   "LblOpt(0)"
      Tab(0).Control(1)=   "FrmOpt(1)"
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "Cadenas de Clientes"
      TabPicture(1)   =   "Cat_Clientes.frx":03A8
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "LblOpt(3)"
      Tab(1).Control(1)=   "FrmOpt(0)"
      Tab(1).ControlCount=   2
      TabCaption(2)   =   "Grupo de Clientes"
      TabPicture(2)   =   "Cat_Clientes.frx":03C4
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "LblOpt(1)"
      Tab(2).Control(1)=   "FrmOpt(3)"
      Tab(2).ControlCount=   2
      TabCaption(3)   =   "Clientes"
      TabPicture(3)   =   "Cat_Clientes.frx":03E0
      Tab(3).ControlEnabled=   0   'False
      Tab(3).Control(0)=   "FrmOpt(2)"
      Tab(3).Control(1)=   "LblOpt(2)"
      Tab(3).ControlCount=   2
      TabCaption(4)   =   "Sucursales"
      TabPicture(4)   =   "Cat_Clientes.frx":03FC
      Tab(4).ControlEnabled=   -1  'True
      Tab(4).Control(0)=   "LblOpt(4)"
      Tab(4).Control(0).Enabled=   0   'False
      Tab(4).Control(1)=   "FrmOpt(4)"
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
         Height          =   7890
         Index           =   4
         Left            =   0
         TabIndex        =   78
         Top             =   315
         Width           =   11145
         Begin VB.OptionButton OptDatos 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Baja"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   315
            Index           =   1
            Left            =   9480
            TabIndex        =   99
            Top             =   4620
            Width           =   1485
         End
         Begin VB.OptionButton OptDatos 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Activo"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   315
            Index           =   0
            Left            =   7890
            TabIndex        =   98
            Top             =   4620
            Value           =   -1  'True
            Width           =   1485
         End
         Begin VB.TextBox TxtDatos 
            Alignment       =   2  'Center
            BackColor       =   &H00FFFFFF&
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   330
            Index           =   2
            Left            =   5580
            MaxLength       =   20
            TabIndex        =   30
            Top             =   2730
            Width           =   1605
         End
         Begin VB.ComboBox CmbDatos 
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
            Index           =   1
            Left            =   7290
            Style           =   2  'Dropdown List
            TabIndex        =   31
            Top             =   2730
            Width           =   2685
         End
         Begin VB.ComboBox CmbDatos 
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
            Index           =   0
            Left            =   1260
            Style           =   2  'Dropdown List
            TabIndex        =   28
            Top             =   2730
            Width           =   2985
         End
         Begin VB.TextBox TxtDatos 
            Alignment       =   2  'Center
            BackColor       =   &H00E0E0E0&
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   330
            Index           =   0
            Left            =   150
            Locked          =   -1  'True
            TabIndex        =   27
            Top             =   2730
            Width           =   1005
         End
         Begin VB.TextBox TxtDatos 
            Alignment       =   2  'Center
            BackColor       =   &H00E0E0E0&
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   330
            Index           =   1
            Left            =   4320
            Locked          =   -1  'True
            TabIndex        =   29
            Top             =   2730
            Width           =   1155
         End
         Begin VB.TextBox TxtDatos 
            Alignment       =   2  'Center
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   330
            Index           =   3
            Left            =   10080
            MaxLength       =   20
            TabIndex        =   32
            Top             =   2730
            Width           =   915
         End
         Begin VB.TextBox TxtDatos 
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   330
            Index           =   4
            Left            =   150
            MaxLength       =   75
            TabIndex        =   33
            Top             =   3360
            Width           =   3585
         End
         Begin VB.TextBox TxtDatos 
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   330
            Index           =   6
            Left            =   5250
            MaxLength       =   250
            TabIndex        =   35
            Top             =   3360
            Width           =   3675
         End
         Begin VB.TextBox TxtDatos 
            Alignment       =   2  'Center
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   330
            Index           =   7
            Left            =   9030
            MaxLength       =   20
            TabIndex        =   36
            Top             =   3360
            Width           =   945
         End
         Begin VB.TextBox TxtDatos 
            Alignment       =   2  'Center
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   330
            Index           =   8
            Left            =   10080
            MaxLength       =   20
            TabIndex        =   37
            Top             =   3360
            Width           =   915
         End
         Begin VB.TextBox TxtDatos 
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   330
            Index           =   9
            Left            =   150
            MaxLength       =   100
            TabIndex        =   38
            Top             =   3990
            Width           =   4995
         End
         Begin VB.TextBox TxtDatos 
            Alignment       =   2  'Center
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   330
            Index           =   10
            Left            =   5250
            MaxLength       =   5
            TabIndex        =   39
            Top             =   3990
            Width           =   1335
         End
         Begin VB.TextBox TxtDatos 
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   330
            Index           =   11
            Left            =   6690
            MaxLength       =   50
            TabIndex        =   40
            Top             =   3990
            Width           =   4305
         End
         Begin VB.TextBox TxtDatos 
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   330
            Index           =   12
            Left            =   180
            MaxLength       =   50
            TabIndex        =   41
            Top             =   4620
            Width           =   3585
         End
         Begin VB.TextBox TxtDatos 
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   330
            Index           =   13
            Left            =   3870
            MaxLength       =   100
            TabIndex        =   42
            Top             =   4620
            Width           =   3675
         End
         Begin VB.TextBox TxtDatos 
            Alignment       =   2  'Center
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   330
            Index           =   5
            Left            =   3840
            MaxLength       =   8
            TabIndex        =   34
            Top             =   3360
            Width           =   1305
         End
         Begin MSComctlLib.ListView LstVDatos 
            Height          =   1965
            Index           =   0
            Left            =   150
            TabIndex        =   26
            Top             =   480
            Width           =   10815
            _ExtentX        =   19076
            _ExtentY        =   3466
            View            =   3
            LabelEdit       =   1
            LabelWrap       =   -1  'True
            HideSelection   =   0   'False
            FullRowSelect   =   -1  'True
            _Version        =   393217
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
               Name            =   "Tahoma"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            NumItems        =   0
         End
         Begin MSComctlLib.ListView LstVDatos 
            Height          =   2385
            Index           =   1
            Left            =   150
            TabIndex        =   43
            Top             =   5310
            Width           =   10815
            _ExtentX        =   19076
            _ExtentY        =   4207
            View            =   3
            LabelEdit       =   1
            LabelWrap       =   -1  'True
            HideSelection   =   0   'False
            FullRowSelect   =   -1  'True
            _Version        =   393217
            ForeColor       =   0
            BackColor       =   16777215
            Appearance      =   1
            BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
               Name            =   "Tahoma"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            NumItems        =   0
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Status"
            Height          =   240
            Index           =   3
            Left            =   9060
            TabIndex        =   97
            Top             =   4380
            Width           =   570
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Codigo de Barras"
            Height          =   240
            Index           =   2
            Left            =   5610
            TabIndex        =   96
            Top             =   2490
            Width           =   1500
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Tipo de Venta"
            Height          =   240
            Index           =   1
            Left            =   7320
            TabIndex        =   95
            Top             =   2490
            Width           =   1200
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Ruta"
            Height          =   240
            Index           =   0
            Left            =   1290
            TabIndex        =   94
            Top             =   2490
            Width           =   405
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "ID Cliente"
            Height          =   240
            Index           =   22
            Left            =   180
            TabIndex        =   93
            Top             =   2490
            Width           =   840
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Clientes"
            Height          =   240
            Index           =   23
            Left            =   150
            TabIndex        =   92
            Top             =   240
            Width           =   705
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Sucursales"
            Height          =   240
            Index           =   24
            Left            =   180
            TabIndex        =   91
            Top             =   5070
            Width           =   975
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "ID Sucursal"
            Height          =   240
            Index           =   25
            Left            =   4350
            TabIndex        =   90
            Top             =   2490
            Width           =   1005
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "TDA/GLN"
            Height          =   240
            Index           =   26
            Left            =   10110
            TabIndex        =   89
            Top             =   2490
            Width           =   825
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Nombre de la Sucursal"
            Height          =   240
            Index           =   27
            Left            =   180
            TabIndex        =   88
            Top             =   3120
            Width           =   1980
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Calle"
            Height          =   240
            Index           =   28
            Left            =   5280
            TabIndex        =   87
            Top             =   3120
            Width           =   435
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "# Exterior"
            Height          =   240
            Index           =   29
            Left            =   9060
            TabIndex        =   86
            Top             =   3120
            Width           =   840
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "# Interior"
            Height          =   240
            Index           =   30
            Left            =   10110
            TabIndex        =   85
            Top             =   3120
            Width           =   750
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Colonia"
            Height          =   240
            Index           =   31
            Left            =   180
            TabIndex        =   84
            Top             =   3750
            Width           =   645
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Código Postal"
            Height          =   240
            Index           =   32
            Left            =   5280
            TabIndex        =   83
            Top             =   3750
            Width           =   1215
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Ciudad"
            Height          =   240
            Index           =   33
            Left            =   6720
            TabIndex        =   82
            Top             =   3750
            Width           =   600
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Estado"
            Height          =   240
            Index           =   34
            Left            =   180
            TabIndex        =   81
            Top             =   4380
            Width           =   615
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Teléfonos"
            Height          =   240
            Index           =   35
            Left            =   3930
            TabIndex        =   80
            Top             =   4380
            Width           =   825
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "RFC Sucursal"
            Height          =   240
            Index           =   36
            Left            =   3870
            TabIndex        =   79
            Top             =   3120
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
         Height          =   7890
         Index           =   3
         Left            =   -75000
         TabIndex        =   72
         Top             =   320
         Width           =   11145
         Begin VB.TextBox TxtGrupo 
            Height          =   375
            Left            =   1710
            TabIndex        =   24
            Top             =   480
            Width           =   9285
         End
         Begin VB.TextBox TxtIdGrupo 
            Alignment       =   2  'Center
            Enabled         =   0   'False
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   150
            Locked          =   -1  'True
            MaxLength       =   5
            TabIndex        =   23
            Top             =   480
            Width           =   1425
         End
         Begin MSComctlLib.ListView LstGrupo 
            Height          =   6765
            Left            =   150
            TabIndex        =   25
            Top             =   960
            Width           =   10815
            _ExtentX        =   19076
            _ExtentY        =   11933
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
            Caption         =   "Nombre Grupo de Clientes"
            Height          =   240
            Left            =   1710
            TabIndex        =   74
            Top             =   240
            Width           =   2295
         End
         Begin VB.Label Label10 
            BackColor       =   &H00FFFFFF&
            Caption         =   "No."
            Height          =   375
            Left            =   210
            TabIndex        =   73
            Top             =   240
            Width           =   615
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
         Height          =   7890
         Index           =   2
         Left            =   -75000
         TabIndex        =   58
         Top             =   315
         Width           =   11145
         Begin VB.Frame Frame1 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Estatus del Cliente"
            Height          =   615
            Left            =   6240
            TabIndex        =   76
            Top             =   2640
            Width           =   4335
            Begin VB.OptionButton OptStatus 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Baja"
               Height          =   255
               Index           =   2
               Left            =   3240
               TabIndex        =   14
               Top             =   280
               Width           =   855
            End
            Begin VB.OptionButton OptStatus 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Suspendido"
               Height          =   255
               Index           =   1
               Left            =   1560
               TabIndex        =   13
               Top             =   280
               Width           =   1575
            End
            Begin VB.OptionButton OptStatus 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Activo"
               Height          =   255
               Index           =   0
               Left            =   360
               TabIndex        =   12
               Top             =   280
               Value           =   -1  'True
               Width           =   1215
            End
         End
         Begin VB.ComboBox CboGrupo 
            Height          =   360
            Left            =   8370
            Style           =   2  'Dropdown List
            TabIndex        =   10
            Top             =   2280
            Width           =   2625
         End
         Begin VB.TextBox TxtNom 
            Height          =   375
            Left            =   2040
            MaxLength       =   500
            TabIndex        =   2
            Top             =   480
            Width           =   6015
         End
         Begin VB.TextBox TxtIdCliente 
            Alignment       =   1  'Right Justify
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   150
            MaxLength       =   8
            TabIndex        =   0
            Top             =   480
            Width           =   1695
         End
         Begin VB.ComboBox CboCanal2 
            Height          =   360
            Left            =   8370
            Style           =   2  'Dropdown List
            TabIndex        =   5
            Top             =   1080
            Width           =   2625
         End
         Begin VB.TextBox TxtRFC 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   8370
            MaxLength       =   13
            TabIndex        =   1
            Top             =   480
            Width           =   2625
         End
         Begin VB.TextBox TxtTel 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   150
            MaxLength       =   100
            TabIndex        =   3
            Top             =   1080
            Width           =   1695
         End
         Begin VB.TextBox TxtDom1 
            Height          =   375
            Left            =   2040
            MaxLength       =   500
            TabIndex        =   4
            Top             =   1080
            Width           =   6135
         End
         Begin VB.ComboBox CboCadena2 
            CausesValidation=   0   'False
            Height          =   360
            ItemData        =   "Cat_Clientes.frx":0418
            Left            =   8370
            List            =   "Cat_Clientes.frx":041A
            Style           =   2  'Dropdown List
            TabIndex        =   8
            Top             =   1680
            Width           =   2625
         End
         Begin VB.TextBox TxtContacto 
            Height          =   375
            Left            =   150
            MaxLength       =   300
            TabIndex        =   6
            Top             =   1680
            Width           =   4575
         End
         Begin VB.TextBox TxtCorreo 
            Height          =   375
            Left            =   5010
            MaxLength       =   100
            TabIndex        =   7
            Top             =   1680
            Width           =   3255
         End
         Begin VB.TextBox TxtWeb 
            Height          =   375
            Left            =   150
            MaxLength       =   200
            TabIndex        =   11
            Top             =   2880
            Width           =   4815
         End
         Begin VB.TextBox TxtDom2 
            Height          =   375
            Left            =   150
            MaxLength       =   1000
            TabIndex        =   9
            Top             =   2280
            Width           =   7935
         End
         Begin MSComctlLib.ListView LstCliente 
            Height          =   4365
            Left            =   150
            TabIndex        =   15
            Top             =   3360
            Width           =   10815
            _ExtentX        =   19076
            _ExtentY        =   7699
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
         Begin VB.Label Label20 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Grupo de Clientes"
            Height          =   240
            Left            =   8370
            TabIndex        =   75
            Top             =   2040
            Width           =   1560
         End
         Begin VB.Label Label7 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clave"
            Height          =   375
            Left            =   150
            TabIndex        =   69
            Top             =   240
            Width           =   615
         End
         Begin VB.Label Label8 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Canal al que Pertenece"
            Height          =   240
            Left            =   8370
            TabIndex        =   68
            Top             =   840
            Width           =   2025
         End
         Begin VB.Label Label9 
            BackColor       =   &H00FFFFFF&
            Caption         =   "RFC"
            Height          =   255
            Left            =   8370
            TabIndex        =   67
            Top             =   240
            Width           =   375
         End
         Begin VB.Label Label11 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Razón Social"
            Height          =   240
            Left            =   2040
            TabIndex        =   66
            Top             =   240
            Width           =   1155
         End
         Begin VB.Label Label12 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Teléfono"
            Height          =   255
            Left            =   150
            TabIndex        =   65
            Top             =   840
            Width           =   975
         End
         Begin VB.Label Label13 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Domicilio"
            Height          =   240
            Left            =   2040
            TabIndex        =   64
            Top             =   840
            Width           =   795
         End
         Begin VB.Label Label14 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cadena"
            Height          =   240
            Left            =   8370
            TabIndex        =   63
            Top             =   1440
            Width           =   660
         End
         Begin VB.Label Label15 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Contacto"
            Height          =   240
            Left            =   150
            TabIndex        =   62
            Top             =   1440
            Width           =   780
         End
         Begin VB.Label Label16 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Correo Electrónico"
            Height          =   240
            Left            =   5010
            TabIndex        =   61
            Top             =   1440
            Width           =   1605
         End
         Begin VB.Label Label17 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Página Web"
            Height          =   240
            Left            =   150
            TabIndex        =   60
            Top             =   2640
            Width           =   1065
         End
         Begin VB.Label Label18 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Domicilio de Entrega"
            Height          =   240
            Left            =   150
            TabIndex        =   59
            Top             =   2040
            Width           =   1800
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
         Height          =   7890
         Index           =   0
         Left            =   -75000
         TabIndex        =   51
         Top             =   320
         Width           =   11145
         Begin VB.ComboBox CboCanal1 
            Height          =   360
            Left            =   8280
            TabIndex        =   21
            Top             =   480
            Width           =   2715
         End
         Begin VB.TextBox TxtIdCadena 
            Alignment       =   2  'Center
            Enabled         =   0   'False
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   150
            Locked          =   -1  'True
            MaxLength       =   5
            TabIndex        =   19
            Top             =   480
            Width           =   945
         End
         Begin VB.TextBox TxtCadena 
            Height          =   375
            Left            =   1230
            TabIndex        =   20
            Top             =   480
            Width           =   6915
         End
         Begin MSComctlLib.ListView LstCadena 
            Height          =   6735
            Left            =   150
            TabIndex        =   22
            Top             =   960
            Width           =   10815
            _ExtentX        =   19076
            _ExtentY        =   11880
            View            =   3
            LabelEdit       =   1
            Sorted          =   -1  'True
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
            Caption         =   "Canal al que Pertenece"
            Height          =   240
            Left            =   8310
            TabIndex        =   56
            Top             =   240
            Width           =   2025
         End
         Begin VB.Label Label2 
            BackColor       =   &H00FFFFFF&
            Caption         =   "No."
            Height          =   375
            Left            =   210
            TabIndex        =   55
            Top             =   240
            Width           =   615
         End
         Begin VB.Label Label1 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Nombre de la  Cadena de Cliente"
            Height          =   240
            Left            =   1260
            TabIndex        =   54
            Top             =   240
            Width           =   2865
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
         Height          =   7890
         Index           =   1
         Left            =   -75000
         TabIndex        =   50
         Top             =   320
         Width           =   11145
         Begin VB.TextBox TxtNombreCanal 
            Height          =   375
            Left            =   1650
            TabIndex        =   17
            Top             =   480
            Width           =   9345
         End
         Begin VB.TextBox TxtIdCanal 
            Alignment       =   2  'Center
            Enabled         =   0   'False
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   150
            Locked          =   -1  'True
            MaxLength       =   5
            TabIndex        =   16
            Top             =   480
            Width           =   1365
         End
         Begin MSComctlLib.ListView LstCanal 
            Height          =   6735
            Left            =   150
            TabIndex        =   18
            Top             =   960
            Width           =   10815
            _ExtentX        =   19076
            _ExtentY        =   11880
            View            =   3
            LabelEdit       =   1
            Sorted          =   -1  'True
            LabelWrap       =   -1  'True
            HideSelection   =   0   'False
            FullRowSelect   =   -1  'True
            GridLines       =   -1  'True
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
            NumItems        =   2
            BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
               Object.Width           =   2540
            EndProperty
            BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
               SubItemIndex    =   1
               Object.Width           =   2540
            EndProperty
         End
         Begin VB.Label Label5 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Nombre del Canal de Distribución"
            Height          =   240
            Left            =   1710
            TabIndex        =   53
            Top             =   240
            Width           =   2895
         End
         Begin VB.Label Label4 
            BackColor       =   &H00FFFFFF&
            Caption         =   "No."
            Height          =   255
            Left            =   210
            TabIndex        =   52
            Top             =   240
            Width           =   855
         End
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Sucursales"
         ForeColor       =   &H80000008&
         Height          =   390
         Index           =   4
         Left            =   8880
         TabIndex        =   77
         Top             =   0
         Width           =   2265
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Cadena de Clientes"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   3
         Left            =   -72795
         TabIndex        =   71
         Top             =   0
         Width           =   2265
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Grupo de Clientes"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   1
         Left            =   -70590
         TabIndex        =   70
         Top             =   0
         Width           =   2280
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Clientes"
         ForeColor       =   &H80000008&
         Height          =   390
         Index           =   2
         Left            =   -68355
         TabIndex        =   57
         Top             =   0
         Width           =   2265
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Canales de Distribución"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   0
         Left            =   -75000
         TabIndex        =   49
         Top             =   0
         Width           =   2235
      End
   End
   Begin VB.CommandButton btnNuevo 
      BackColor       =   &H00FFFFFF&
      Caption         =   "&Nuevo"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1185
      Left            =   11370
      Picture         =   "Cat_Clientes.frx":041C
      Style           =   1  'Graphical
      TabIndex        =   44
      Top             =   3900
      Width           =   1185
   End
   Begin VB.CommandButton btnImprimir 
      BackColor       =   &H00FFFFFF&
      Caption         =   "&Imprimir"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1065
      Left            =   11370
      Picture         =   "Cat_Clientes.frx":07DD
      Style           =   1  'Graphical
      TabIndex        =   47
      Top             =   7260
      Width           =   1185
   End
   Begin VB.CommandButton btnEliminar 
      BackColor       =   &H00FFFFFF&
      Caption         =   "&Eliminar"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1065
      Left            =   11370
      Picture         =   "Cat_Clientes.frx":0AA7
      Style           =   1  'Graphical
      TabIndex        =   46
      Top             =   6180
      Width           =   1185
   End
End
Attribute VB_Name = "Cat_Clientes"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDCanales, LstDCadenas, Nuevo As Boolean

Dim ListaDeSucursales, ListaDeClientes, ListaDeRutas, ListaDeFormasVenta
Dim IdRuta As Integer, IdCliente As Long, RazonSocialCliente As String, IdSucursal As String, Sucursal As String, IdFormaVenta As String

Private Sub btnActualizar_Click()
Dim CANAL, cadena, GRUPOCADENA As Integer
    
    Select Case SSTab.Tab
        Case 0:
        
            If Trim(TxtIdCanal.Text) = "" Or Trim(TxtNombreCanal.Text) = "" Then
                MsgBox "¡ Teclee los Datos para Actualizar !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        
            StrCmd = "execute up_Canales " & Trim(TxtIdCanal.Text) & ", '" & UCase(Trim(TxtNombreCanal.Text)) & "', '" & Format(Date & " " & Time, "DD/MM/YYYY HH:MM:SS") & "'," & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraCanales
            LLENA_COMBOS
            Nuevo = False
            
        Case 1:
            
            If Trim(TxtIdCadena.Text) = "" Or Trim(TxtCadena.Text) = "" Or Trim(CboCanal1.Text) = "" Then
                MsgBox "¡ Teclee los Datos para Actualizar !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            If Rs.State Then Rs.Close
            Rs.Open "SELECT * FROM CANALES WHERE CANAL = '" & Trim(CboCanal1.Text) & "'", Cnn
            CANAL = Rs!idcanal
            StrCmd = "execute up_Cadenas " & Trim(TxtIdCadena.Text) & ", " & CANAL & ", '" & UCase(Trim(TxtCadena.Text)) & "', '" & Format(Date & " " & Time, "DD/MM/YYYY HH:MM:SS") & "'," & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraCadenas
            LLENA_COMBOS
            Nuevo = False
                                    
        Case 2:
        
            If Trim(TxtIdGrupo.Text) = "" Or Trim(TxtGrupo.Text) = "" Then
                MsgBox "¡ Teclee los Datos para Actualizar !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            StrCmd = "execute up_GrupoClientes " & Trim(TxtIdGrupo.Text) & ", '" & UCase(Trim(TxtGrupo.Text)) & "', '" & Format(Date & " " & Time, "DD/MM/YYYY HH:MM:SS") & "'," & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraGrupoClientes
            LLENA_COMBOS
            Nuevo = False
                          
        Case 3:
            
            If Trim(TxtIdCliente.Text) = "" Or Trim(TxtNom.Text) = "" Or Trim(CboCanal2.Text) = "" Or Trim(CboCadena2.Text) = "" Or Trim(CboGrupo.Text) = "" Then
                MsgBox "¡ Teclee los Datos para Actualizar !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            If Rs.State Then Rs.Close
            Rs.Open "SELECT * FROM CANALES WHERE CANAL = '" & Trim(CboCanal2.Text) & "'", Cnn
            CANAL = Rs!idcanal
            If Rs.State Then Rs.Close
            Rs.Open "SELECT * FROM CADENAS WHERE CADENA = '" & Trim(CboCadena2.Text) & "'", Cnn
            cadena = Rs!idcadena
            If Rs.State Then Rs.Close
            Rs.Open "SELECT * FROM GRUPOCLIENTES WHERE GRUPOCLIENTE = '" & Trim(CboGrupo.Text) & "'", Cnn
            GRUPOCADENA = Rs!idgrupocliente
            
            If Nuevo Then
                If Rs.State Then Rs.Close
                Rs.Open "select IdCliente from Clientes where IdCedis = " & IdCedis & " and IdCliente = " & CLng(TxtIdCliente.Text)
                If Not Rs.EOF Then
                    MsgBox "¡ La clave de cliente ya existe !. Teclea otra clave. ", vbInformation + vbOKOnly, App.Title
                    TxtIdCliente.SetFocus
                    Exit Sub
                End If
            Else
                If Rs.State Then Rs.Close
                Rs.Open "select IdCliente from Clientes where IdCedis = " & IdCedis & " and IdCliente = " & CLng(TxtIdCliente.Text)
                If Rs.EOF Then
                    MsgBox "¡ No existe clave para actualizar !. Teclea otra clave. ", vbInformation + vbOKOnly, App.Title
                    TxtIdCliente.SetFocus
                    Exit Sub
                End If
            End If
            
            Dim Status
            For i = 0 To OptStatus.Count
                If OptStatus(i).Value Then
                    Status = UCase(Mid(Trim(OptStatus(i).Caption), 1, 1))
                    Exit For
                End If
            Next
            
            StrCmd = "execute up_Clientes " & IdCedis & ", " & UCase(TxtIdCliente.Text) & ", '" & UCase(TxtRFC.Text) & "',  " _
                    & " '" & UCase(TxtNom.Text) & "', '" & UCase(TxtDom1.Text) & "', '" & Trim(TxtTel.Text) & "', " _
                    & " '" & UCase(TxtContacto.Text) & "', '" & Trim(TxtCorreo.Text) & "', '" & Trim(TxtWeb.Text) & "', " _
                    & " " & CANAL & ", " & cadena & ", " & GRUPOCADENA & ", '" & UCase(TxtDom2.Text) & "', '" & Format(Date & " " & Time, "DD/MM/YYYY HH:MM:SS") & "', '" & Status & "', " & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraClientes
            Nuevo = False
            
        Case 4
    
            If Not Nuevo And IdSucursal = "" Then
                MsgBox "¡ No se ha seleccionado la Sucursal !", vbInformation + vbOKOnly, App.Title
                LstVDatos(1).SetFocus
                Exit Sub
            End If
    
            If Trim(TxtDatos(0).Text) = "" Then
                MsgBox "¡ No se ha seleccionado el Cliente !", vbInformation + vbOKOnly, App.Title
                LstVDatos(0).SetFocus
                Exit Sub
            End If
    
            If Nuevo Or (Nuevo = False And Len(TxtDatos(1).Text) = 8 And TxtDatos(0).Text <> TxtDatos(1).Text) Then
                If CmbDatos(0).ListIndex <= 0 Then
                    MsgBox "¡ No se ha seleccionado la Ruta !", vbInformation + vbOKOnly, App.Title
                    CmbDatos(0).SetFocus
                    Exit Sub
                End If
            Else
                
            End If
            
            If Len(Trim(TxtDatos(2).Text)) <> 20 Then
                MsgBox "¡ No se ha seleccionado la Ruta !", vbInformation + vbOKOnly, App.Title
                TxtDatos(2).SetFocus
                Exit Sub
            End If

            If CmbDatos(1).ListIndex <= 0 Then
                MsgBox "¡ No se ha seleccionado la Forma de Venta !", vbInformation + vbOKOnly, App.Title
                CmbDatos(1).SetFocus
                Exit Sub
            End If
    
            If Trim(TxtDatos(4).Text) = "" Then
                MsgBox "¡ No ha Escrito el Nombre de la Sucursal !", vbInformation + vbOKOnly, App.Title
                TxtDatos(4).SetFocus
                Exit Sub
            End If

            '@IdCedis as bigint, @IdRuta as int, @IdCliente as bigint, @IdSucursal as bigint,
            '@TDA_GLN as varchar(20), @NombreSucursal as varchar(75),
            '@Calle as varchar(250), @NumExterior as varchar(20),
            '@NumInterior as varchar(20), @Colonia as varchar(100),
            '@CP as varchar(5), @Ciudad as varchar(50),
            '@Estado as varchar(50), @Telefonos as varchar(100),
            '@RFCSucursal as varchar(20), @RazonSocial as varchar(200),
            '@CodigoBarras as varchar(50), @FormaVenta as varchar(1),
            '@Status as varchar(1), @Opc as int
            
            StrCmd = "up_Sucursales " & IdCedis & ", " & IdRuta & ", " & IdCliente & ", '" & IdSucursal & "', '" & _
                    UCase(Trim(TxtDatos(3).Text)) & "', '" & UCase(Trim(TxtDatos(4).Text)) & "', '" & _
                    UCase(Trim(TxtDatos(6).Text)) & "', '" & UCase(Trim(TxtDatos(7).Text)) & "', '" & _
                    UCase(Trim(TxtDatos(8).Text)) & "', '" & UCase(Trim(TxtDatos(9).Text)) & "', '" & _
                    UCase(Trim(TxtDatos(10).Text)) & "', '" & UCase(Trim(TxtDatos(11).Text)) & "', '" & _
                    UCase(Trim(TxtDatos(12).Text)) & "', '" & UCase(Trim(TxtDatos(13).Text)) & "', '" & _
                    UCase(Trim(TxtDatos(5).Text)) & "', '" & UCase(RazonSocialCliente) & "', '" & _
                    UCase(Trim(TxtDatos(2).Text)) & "', '" & IdFormaVenta & "', '" & _
                    IIf(OptDatos(0).Value, "A", "B") & "',0," & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            
            MuestraSucursales
            Nuevo = False
            CmbDatos(0).Locked = True
            
            For i = 1 To TxtDatos.Count - 1: TxtDatos(i).Text = "": Next i
            
            CmbDatos(0).ListIndex = 0
            CmbDatos(1).ListIndex = 0
            OptDatos(0).Value = True
                        
    End Select
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
End Sub

Private Sub btnEliminar_Click()
    Select Case SSTab.Tab
        
        Case 0:
            If Trim(TxtIdCanal.Text) = "" Then
                MsgBox "¡ Seleccione el registro a dar de Baja !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        
            StrCmd = "execute up_Canales " & TxtIdCanal.Text & ", '','', 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraCanales
            Nuevo = False
        
        Case 1:
            If Trim(TxtIdCadena.Text) = "" Then
                MsgBox "¡ Seleccione el registro a dar de Baja !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        
            StrCmd = "execute up_Cadenas " & TxtIdCadena.Text & ", '','', '', 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraCadenas
            Nuevo = False
                    
        Case 2:
        
            If Trim(TxtIdGrupo.Text) = "" Then
                MsgBox "¡ Seleccione el registro a dar de Baja !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        
            StrCmd = "execute up_GrupoClientes " & TxtIdGrupo.Text & ", '','', 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraGrupoClientes
            Nuevo = False
                         
        Case 3:
            If Trim(TxtIdCliente.Text) = "" Then
                MsgBox "¡ Seleccione el registro a dar de Baja !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        
            StrCmd = "execute up_Clientes  " & IdCedis & ", " & TxtIdCliente.Text & ",'','','','','','','','','','','','', '', 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraClientes
            Nuevo = False
            
        Case 4
            If Trim(TxtDatos(0).Text) = "" Or Trim(TxtDatos(1).Text) = "" Then
                MsgBox "¡ Seleccione el registro a dar de Baja !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        
            StrCmd = "up_Sucursales " & IdCedis & ", 0, " & IdCliente & ", '" & IdSucursal & "', '" & _
                    "', '', '', '', '', '', '', '', '', '', '', '', '', '', '',0 ,3"
                        
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraSucursales
            Nuevo = False
            CmbDatos(0).Locked = True
            For i = 1 To TxtDatos.Count - 1: TxtDatos(i).Text = "": Next i
            
            CmbDatos(0).ListIndex = 0
            CmbDatos(1).ListIndex = 0
            OptDatos(0).Value = True

    End Select
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
End Sub

Private Sub btnImprimir_Click()
   Select Case SSTab.Tab
        Case 0:
            With RptCatCanal
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                StrCmd = "select IdCanal, Canal," _
                        & " Case Status " _
                        & " when 'A' then 'Activo' " _
                        & " Else 'Baja' " _
                        & " end as 'Estatus' " _
                        & " from canales order by Canal"
                    If RsC.State Then RsC.Close
                    RsC.Open StrCmd, Cnn
        
                If Not RsC.EOF Then
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = RsC
                End If
                
                .Printer.PaperSize = 1
                .Printer.Orientation = ddOPortrait
                .Show 1
            End With
            
        Case 1:
            With RptCatCadena
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                StrCmd = "select c.IdCadena, c.cadena, a.canal, " _
                        & " Case c.Status " _
                        & " when 'A' then 'Activo'" _
                        & " Else 'Baja' " _
                        & " end as 'Estatus' " _
                        & " from cadenas c, canales a " _
                        & " where c.idcanal = a.idcanal order by c.cadena"
                    If RsC.State Then RsC.Close
                    RsC.Open StrCmd, Cnn
        
                If Not RsC.EOF Then
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = RsC
                End If
                
                .Printer.PaperSize = 1
                .Printer.Orientation = ddOPortrait
                .Show 1
            End With
            
        Case 2:
            With RptCatGrupoClientes
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                StrCmd = "select IdGrupoCliente, GrupoCliente," _
                        & " Case Status " _
                        & " when 'A' then 'Activo' " _
                        & " Else 'Baja' " _
                        & " end as 'Estatus' " _
                        & " from grupoclientes order by GrupoCliente "
                    If RsC.State Then RsC.Close
                    RsC.Open StrCmd, Cnn
        
                If Not RsC.EOF Then
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = RsC
                End If
                
                .Printer.PaperSize = 1
                .Printer.Orientation = ddOPortrait
                .Show 1
            End With
                
        Case 3:
            With RptCatClientes
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                StrCmd = "select d.cedis, c.idcliente, c.rfc, c.razonsocial, c.domicilio, c.telefono, a.canal, e.cadena, g.grupocliente," _
                        & " Case c.Status " _
                        & " when 'A' then 'Activo' " _
                        & " Else 'Baja' " _
                        & " end as 'Estatus' " _
                        & " from clientes c, canales a, cadenas e, grupoclientes g, cedis d " _
                        & " Where a.idcanal = c.idcanal And c.idcadena = e.idcadena " _
                        & " And c.idgrupocadena = g.idgrupocliente And c.IdCedis = d.IdCedis " _
                        & " order by d.cedis,  c.razonsocial "
                    If RsC.State Then RsC.Close
                    RsC.Open StrCmd, Cnn
        
                If Not RsC.EOF Then
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = RsC
                End If
                
                .Printer.PaperSize = 1
                .Printer.Orientation = ddOLandscape
                .Show 1
            End With
                        
    End Select
End Sub

Private Sub btnNuevo_Click()
    Select Case SSTab.Tab
        Case 0:
            TxtIdCanal.Text = "": TxtNombreCanal.Text = ""
            If Rs.State Then Rs.Close
            Rs.Open "SELECT ISNULL(MAX(IdCanal),0)+1 AS MAXI From Canales", Cnn
            TxtIdCanal.Text = Rs!MAXI
            Nuevo = True
            TxtNombreCanal.SetFocus
            
        Case 1:
            TxtIdCadena.Text = "": TxtCadena.Text = "": CboCanal1.Text = ""
            If Rs.State Then Rs.Close
            Rs.Open "SELECT ISNULL(MAX(IdCadena),0)+1 AS MAXI From CADENAS", Cnn
            TxtIdCadena.Text = Rs!MAXI
            Nuevo = True
            TxtCadena.SetFocus
            
        Case 2:
            TxtIdGrupo.Text = "": TxtGrupo.Text = ""
            If Rs.State Then Rs.Close
            Rs.Open "SELECT ISNULL(MAX(IdGrupoCliente),0)+1 AS MAXI From GRUPOCLIENTES", Cnn
            TxtIdGrupo.Text = Rs!MAXI
            Nuevo = True
            TxtGrupo.SetFocus
           
        Case 3:
            TxtIdCliente.Text = "": TxtNom.Text = "": TxtTel.Text = "": TxtDom1.Text = ""
            TxtContacto.Text = "": TxtCorreo.Text = "": TxtDom2.Text = "": TxtWeb.Text = ""
            TxtRFC.Text = "" ': CboCanal2.Text = "": CboCadena2.Text = "": CboGrupo.Text = ""
            Nuevo = True
            TxtIdCliente.SetFocus
            
        Case 4:
            For i = 1 To TxtDatos.Count - 1: TxtDatos(i).Text = "": Next i
            
            Nuevo = True
            CmbDatos(0).Locked = False
            CmbDatos(0).ListIndex = 0
            CmbDatos(0).SetFocus
            CmbDatos(1).ListIndex = 0
            OptDatos(0).Value = True
            
    End Select
End Sub

Private Sub CmbDatos_Click(Index As Integer)
    
    Dim ElementoSeleccionado As Integer

    ElementoSeleccionado = CmbDatos(Index).ListIndex - 1
    'TxtDatos(1).Text = ""
    
    If ElementoSeleccionado < 0 Then
        IdRuta = 0
        IdFormaVenta = 0
        Exit Sub
    End If
    
    Select Case Index
        Case 0
            IdRuta = ListaDeRutas(0, ElementoSeleccionado)
            
''            If Nuevo Then
''                TxtDatos(1).Text = ObtieneClaveSucursal(CInt(IdCedis), CLng(IdRuta), IdCliente)
''            End If
        Case 1
            IdFormaVenta = ListaDeFormasVenta(0, ElementoSeleccionado)
        
    End Select

End Sub

Private Sub Form_Load()
    Nuevo = False
    If Not Cnn.State Then OpenConn Server, Db, "ITAPDC", "itapdc"
    MuestraCanales
    MuestraCadenas
    MuestraClientes
    MuestraGrupoClientes
    LLENA_COMBOS
    SSTab.Tab = 3
End Sub

Sub LLENA_COMBOS()
    
    'LLENA CANAL(CADENAS)
    CboCanal1.Clear
    CboCanal2.Clear
    If Rs.State Then Rs.Close
    Rs.Open "SELECT CANAL FROM CANALES WHERE STATUS = 'A' ORDER BY CANAL", Cnn
    While Not Rs.EOF
        CboCanal1.AddItem Trim(Rs!CANAL)
        CboCanal2.AddItem Trim(Rs!CANAL)
        Rs.MoveNext
    Wend
    Rs.Close
    
    'LLENA CADENA(GRUPOS, CLIENTES)
    CboCadena2.Clear
    If Rs.State Then Rs.Close
    Rs.Open "SELECT CADENA FROM CADENAS WHERE STATUS = 'A' ORDER BY CADENA", Cnn
    While Not Rs.EOF
        CboCadena2.AddItem Trim(Rs!cadena)
        Rs.MoveNext
    Wend
    Rs.Close
    
    'LLENA GRUPOS(CLIENTES)
    CboGrupo.Clear
    If Rs.State Then Rs.Close
    Rs.Open "SELECT GRUPOCLIENTE FROM GRUPOCLIENTES WHERE STATUS = 'A' ORDER BY GRUPOCLIENTE", Cnn
    While Not Rs.EOF
        CboGrupo.AddItem Trim(Rs!grupocliente)
        Rs.MoveNext
    Wend
    Rs.Close

    'LLENA RUTAS()
    CmbDatos(0).Clear
    
    If Rs.State Then Rs.Close
    Rs.Open "sel_Rutas " & IdCedis, Cnn
    ListaDeRutas = GetDataCBL(Rs, CmbDatos(0), "Seleccione una Ruta", "No se Encontraron Registros de Rutas")
    Rs.Close
    
    'LLENA FORMA VENTA
    CmbDatos(1).Clear
    
    If Rs.State Then Rs.Close
    Rs.Open "sel_TipoVenta ", Cnn
    ListaDeFormasVenta = GetDataCBL(Rs, CmbDatos(1), "Seleccione Tipo de Venta", "No se Encontraron Registros de Tipos de Venta")
    Rs.Close

End Sub

Sub MuestraCanales()
    StrCmd = "execute sel_Canales "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCanales = GetDataLVL(Rs, LstCanal, 0, 2, "0|0|0")
End Sub

Sub MuestraCadenas()
    StrCmd = "execute sel_Cadenas "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCadena = GetDataLVL(Rs, LstCadena, 0, 3, "0|0|0|0")
End Sub

Sub MuestraGrupoClientes()
    StrCmd = "execute sel_GrupoClientes "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCadena = GetDataLVL(Rs, LstGrupo, 0, 4, "0|0|0|0")
End Sub

Sub MuestraClientes()
    StrCmd = "execute sel_Clientes " & IdCedis & ""
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDClientes = GetDataLVL(Rs, LstCliente, 0, 13, "0|0|0|0|0|0|0|0|0|0|0|0|0|0")
    Rs.MoveFirst
    ListaDeClientes = GetDataLVL(Rs, LstVDatos(0), 0, 13, "0|0|0|0|0|0|0|0|0|0|0|0|0|0")
    
    If Not IsEmpty(ListaDeClientes) Then LstVDatos_ItemClick 0, LstVDatos(0).SelectedItem

End Sub

Sub MuestraSucursales()
    StrCmd = "execute sel_Sucursales " & IdCedis & "," & IdCliente & ",'',0,1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    ListaDeSucursales = GetDataLVL(Rs, LstVDatos(1), 2, 18, "0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0")
End Sub

Function ObtieneClaveSucursal(IdCedis As Integer, IdRuta As Long, IdCliente As Long) As String
    Dim IdSucursal As Integer

    ObtieneClaveSucursal = ""
        
    'obtener el siguiente consecutivo para la ruta
    StrCmd = "execute sel_Sucursales " & IdCedis & "," & IdCliente & ",''," & IdRuta & ",2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    If Not Rs.EOF Then
        IdSucursal = Rs!MaxSucursalxRuta.Value
    Else
        IdSucursal = 1
    End If

    ObtieneClaveSucursal = Format(IdCedis, "00") & Format(IdRuta, "000") & Format(IdSucursal, "000")

End Function

Private Sub LstCadena_Click()
    Nuevo = False
    TxtIdCadena.Text = LstCadena.ListItems(LstCadena.SelectedItem.Index).Text
    TxtCadena.Text = LstCadena.ListItems(LstCadena.SelectedItem.Index).SubItems(1)
    CboCanal1.Text = LstCadena.ListItems(LstCadena.SelectedItem.Index).SubItems(2)
    Nuevo = False
End Sub

Private Sub LstCadena_KeyUp(KeyCode As Integer, Shift As Integer)
    LstCadena_Click
End Sub

Private Sub LstCanal_Click()
    Nuevo = False
    TxtIdCanal.Text = LstCanal.ListItems.Item(LstCanal.SelectedItem.Index).Text
    TxtNombreCanal.Text = LstCanal.ListItems.Item(LstCanal.SelectedItem.Index).SubItems(1)
    Nuevo = False
End Sub

Private Sub LstCanal_KeyUp(KeyCode As Integer, Shift As Integer)
    LstCanal_Click
End Sub

Private Sub LstCliente_Click()
    On Error Resume Next
    Nuevo = False
    If LstCliente.ListItems.Count <= 0 Then Exit Sub
    
    TxtIdCliente.Text = LstCliente.ListItems.Item(LstCliente.SelectedItem.Index).Text
    TxtNom.Text = LstCliente.ListItems(LstCliente.SelectedItem.Index).SubItems(2)
    TxtRFC.Text = LstCliente.ListItems(LstCliente.SelectedItem.Index).SubItems(1)
    TxtTel.Text = LstCliente.ListItems(LstCliente.SelectedItem.Index).SubItems(4)
    TxtDom1.Text = LstCliente.ListItems(LstCliente.SelectedItem.Index).SubItems(3)
    CboCanal2.Text = LstCliente.ListItems(LstCliente.SelectedItem.Index).SubItems(8)
    TxtContacto.Text = LstCliente.ListItems(LstCliente.SelectedItem.Index).SubItems(5)
    TxtCorreo.Text = LstCliente.ListItems(LstCliente.SelectedItem.Index).SubItems(6)
    CboCadena2.Text = LstCliente.ListItems(LstCliente.SelectedItem.Index).SubItems(9)
    CboGrupo = LstCliente.ListItems(LstCliente.SelectedItem.Index).SubItems(10)
    TxtDom2.Text = LstCliente.ListItems(LstCliente.SelectedItem.Index).SubItems(11)
    TxtWeb.Text = LstCliente.ListItems(LstCliente.SelectedItem.Index).SubItems(7)
    
    Select Case Mid(UCase(Trim(LstCliente.ListItems(LstCliente.SelectedItem.Index).SubItems(13))), 1, 1)
        Case "A": OptStatus(0).Value = True
        Case "S": OptStatus(1).Value = True
        Case "B": OptStatus(2).Value = True
    End Select
    
    Nuevo = False
    
End Sub

Private Sub LstCliente_KeyUp(KeyCode As Integer, Shift As Integer)
    LstCliente_Click
End Sub

Private Sub LstGrupo_Click()
    TxtIdGrupo.Text = LstGrupo.ListItems(LstGrupo.SelectedItem.Index).Text
    TxtGrupo.Text = LstGrupo.ListItems(LstGrupo.SelectedItem.Index).SubItems(1)
    Nuevo = False
End Sub

Private Sub LstGrupo_KeyUp(KeyCode As Integer, Shift As Integer)
    LstGrupo_Click
End Sub

Private Sub LstVDatos_DblClick(Index As Integer)

    Select Case Index
        
        Case 1      'para reasignacion de cliente
            
            Cat_Clientes_Reasignacion.IdClienteAnterior = IdCliente
            Cat_Clientes_Reasignacion.ClienteAnterior = RazonSocialCliente
            Cat_Clientes_Reasignacion.IdSucursal = IdSucursal
            Cat_Clientes_Reasignacion.Sucursal = Sucursal
            Cat_Clientes_Reasignacion.Show vbModal

            LstVDatos_ItemClick 0, LstVDatos(0).SelectedItem
            
    End Select

End Sub

Private Sub LstVDatos_ItemClick(Index As Integer, ByVal Item As MSComctlLib.ListItem)
Dim ItemSeleccionado As Integer

    Nuevo = False
    
    Select Case Index
        Case 0
            ItemSeleccionado = Item.Index
            CmbDatos(0).Locked = True
            
            For i = 0 To 12: TxtDatos(i).Text = "": Next i
            
            On Error Resume Next
            CmbDatos(0).ListIndex = 0
            CmbDatos(1).ListIndex = 0
            
            '0 idcliente, 1 rfc, 2 razonsocial, 3 domicilio, 4 telefono, 5 contacto,
            '6 email, 7 sitioweb, 8 canal, 9 cadena, 10 grupocliente, 11 domicilioentrega,
            '12 fechaalta, 13 Estatus
                
            IdCliente = ListaDeClientes(0, ItemSeleccionado - 1)
            RazonSocialCliente = ListaDeClientes(2, ItemSeleccionado - 1)

            MuestraSucursales
            
            TxtDatos(0).Text = ListaDeClientes(0, ItemSeleccionado - 1)        'IdCliente
            
            TxtDatos(1).Text = ""
            IdSucursal = ""
            OptDatos(0).Value = False: OptDatos(1).Value = False
            
        Case 1
            ItemSeleccionado = Item.Index
            CmbDatos(0).Locked = True
                        
            For i = 0 To 12: TxtDatos(i).Text = "": Next i

            '0 IdCedis, 1 cliente, 2 IdCliente, 3 IdSucursal, 4 [TDA/GLN], 5 Sucursal,
            '6 SUC.Status, 7 [Forma de Venta], 8 [Código de Barras], 9 Calle, 10 [No. Ext],
            '11 [No. Int], 12 Colonia, 13 CP, 14 Ciudad, 15 Estado, 16 Teléfonos,
            '17 [RFC Sucursal], 18 [Razón Social]
            
            '1 IdCedis, CTE.RazonSocial AS cliente, SUC.IdCliente, SUC.IdSucursal, SUC.TDA_GLN AS [TDA/GLN], SUC.NombreSucursal AS Sucursal,
            'SUC.Status, SUC.FormaVenta as [Forma de Venta], SUC.CodigoBarras as [Código de Barras], SUC.Calle, SUC.NumExterior AS [No. Ext],
            'SUC.NumInterior AS [No. Int], SUC.Colonia, SUC.CP, SUC.Ciudad, SUC.Estado, SUC.Telefonos AS Teléfonos,
            'SUC.RFCSuc AS [RFC Sucursal], SUC.RazonSocialSuc AS [Razón Social]
            
            IdSucursal = ListaDeSucursales(3, ItemSeleccionado - 1)
            Sucursal = ListaDeSucursales(5, ItemSeleccionado - 1)

            TxtDatos(0).Text = ListaDeSucursales(2, ItemSeleccionado - 1)        'IdCliente
            TxtDatos(1).Text = ListaDeSucursales(3, ItemSeleccionado - 1)        'IdSucursal
            TxtDatos(2).Text = ListaDeSucursales(8, ItemSeleccionado - 1)        'Codigo de Barras
            TxtDatos(3).Text = ListaDeSucursales(4, ItemSeleccionado - 1)        'TDA-GLN
            TxtDatos(4).Text = ListaDeSucursales(5, ItemSeleccionado - 1)        'Sucursal
            TxtDatos(5).Text = ListaDeSucursales(17, ItemSeleccionado - 1)       'RFCSucursal
            TxtDatos(6).Text = ListaDeSucursales(9, ItemSeleccionado - 1)        'Calle
            TxtDatos(7).Text = ListaDeSucursales(10, ItemSeleccionado - 1)        'No. Exterior
            TxtDatos(8).Text = ListaDeSucursales(11, ItemSeleccionado - 1)        'No. Interior
            TxtDatos(9).Text = ListaDeSucursales(12, ItemSeleccionado - 1)       'Colonia
            TxtDatos(10).Text = ListaDeSucursales(13, ItemSeleccionado - 1)       'CP
            TxtDatos(11).Text = ListaDeSucursales(14, ItemSeleccionado - 1)      'Ciudad
            TxtDatos(12).Text = ListaDeSucursales(15, ItemSeleccionado - 1)      'Estado
            TxtDatos(13).Text = ListaDeSucursales(16, ItemSeleccionado - 1)      'Telefonos
            'TxtDatos(14).Text = IIf(ListaDeSucursales(6, ItemSeleccionado - 1) = "A", "Activo", "Baja")
            OptDatos(IIf(ListaDeSucursales(6, ItemSeleccionado - 1) = "A", 0, 1)).Value = True      'Status
            CmbDatos(0).ListIndex = 0
            CmbDatos(1).ListIndex = 0
            
            'busca el dato en el combo de Ruta
            If Len(ListaDeSucursales(3, ItemSeleccionado - 1)) = 8 And _
                ListaDeSucursales(3, ItemSeleccionado - 1) <> ListaDeSucursales(2, ItemSeleccionado - 1) Then
            
                IdRutaBusca = CInt(Mid(ListaDeSucursales(3, ItemSeleccionado - 1), 3, 3))
                
                For i = 0 To CmbDatos(0).ListCount - 2
                    If ListaDeRutas(0, i) = IdRutaBusca Then
                        CmbDatos(0).ListIndex = i + 1
                        Exit For
                    End If
                Next i
                
            End If
            
            'busca el dato en el combo de Forma de Venta
            IdFormaVentaBusca = ListaDeSucursales(7, ItemSeleccionado - 1)
            
            For i = 0 To CmbDatos(1).ListCount - 2
                If CStr(ListaDeFormasVenta(0, i)) = CStr(IdFormaVentaBusca) Then
                    CmbDatos(1).ListIndex = i + 1
                    Exit For
                End If
            Next i

            
    End Select

End Sub

Private Sub SSTab_Click(PreviousTab As Integer)
    Select Case SSTab.Tab
        Case 0:
            If Not ValidaModulo("CATCTECAN", True) Then
                SSTab.Tab = 3
                Exit Sub
            End If
        Case 1:
            If Not ValidaModulo("CATCTECAD", True) Then
                SSTab.Tab = 3
                Exit Sub
            End If
        Case 2:
            If Not ValidaModulo("CATCTEGPO", True) Then
                SSTab.Tab = 3
                Exit Sub
            End If
        Case 3:
            If Not ValidaModulo("CATCTECTE", True) Then
                Unload Me
            End If
    End Select
End Sub

Private Sub TxtCadena_KeyPress(KeyAscii As Integer)
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtContacto_KeyPress(KeyAscii As Integer)
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtDom1_KeyPress(KeyAscii As Integer)
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtDom2_KeyPress(KeyAscii As Integer)
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtGrupo_KeyPress(KeyAscii As Integer)
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtIdCliente_KeyPress(KeyAscii As Integer)
  If IsNumeric(Chr(KeyAscii)) = False And KeyAscii <> 8 And KeyAscii <> 13 Then KeyAscii = 0
End Sub

Private Sub TxtIdCliente_Validate(Cancel As Boolean)
If TxtIdCliente.Text <> "" Then
    If Rs.State Then Rs.Close
    Rs.Open "select IdCliente from Clientes where IdCedis = " & IdCedis & " and IdCliente = " & CLng(TxtIdCliente.Text)
    If Not Rs.EOF Then
        MsgBox "¡ La clave de cliente ya existe !. Teclea otra clave. ", vbInformation + vbOKOnly, App.Title
        TxtIdCliente.SetFocus
        Exit Sub
    Else
        TxtNom.SetFocus
    End If
End If
End Sub

Private Sub TxtNom_KeyPress(KeyAscii As Integer)
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtNombreCanal_KeyPress(KeyAscii As Integer)
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtRFC_KeyPress(KeyAscii As Integer)
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

