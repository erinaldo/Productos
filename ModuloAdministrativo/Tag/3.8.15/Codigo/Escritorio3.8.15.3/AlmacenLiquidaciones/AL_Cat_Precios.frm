VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form AL_Cat_Precios 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   9090
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
   ScaleHeight     =   9090
   ScaleWidth      =   12660
   ShowInTaskbar   =   0   'False
   Begin TabDlg.SSTab SSTab 
      Height          =   8895
      Left            =   120
      TabIndex        =   19
      Top             =   120
      Width           =   12375
      _ExtentX        =   21828
      _ExtentY        =   15690
      _Version        =   393216
      Tab             =   1
      TabHeight       =   520
      BackColor       =   16777215
      TabCaption(0)   =   "Listas de Precios"
      TabPicture(0)   =   "AL_Cat_Precios.frx":0000
      Tab(0).ControlEnabled=   0   'False
      Tab(0).Control(0)=   "FrmOpt(3)"
      Tab(0).Control(1)=   "LblOpt(0)"
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "Precios y Productos"
      TabPicture(1)   =   "AL_Cat_Precios.frx":001C
      Tab(1).ControlEnabled=   -1  'True
      Tab(1).Control(0)=   "LblOpt(1)"
      Tab(1).Control(0).Enabled=   0   'False
      Tab(1).Control(1)=   "FrmOpt(0)"
      Tab(1).Control(1).Enabled=   0   'False
      Tab(1).ControlCount=   2
      TabCaption(2)   =   "Asignación de Listas"
      TabPicture(2)   =   "AL_Cat_Precios.frx":0038
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "FrmOpt(4)"
      Tab(2).Control(1)=   "LblOpt(2)"
      Tab(2).ControlCount=   2
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
         Height          =   8595
         Index           =   3
         Left            =   -75000
         TabIndex        =   28
         Top             =   320
         Width           =   12375
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
            Picture         =   "AL_Cat_Precios.frx":0054
            Style           =   1  'Graphical
            TabIndex        =   16
            Top             =   8040
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
            Picture         =   "AL_Cat_Precios.frx":09EA
            Style           =   1  'Graphical
            TabIndex        =   15
            Top             =   8040
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
            Picture         =   "AL_Cat_Precios.frx":1078
            Style           =   1  'Graphical
            TabIndex        =   18
            Top             =   8040
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
            Left            =   4080
            Picture         =   "AL_Cat_Precios.frx":1793
            Style           =   1  'Graphical
            TabIndex        =   17
            Top             =   8040
            Width           =   1695
         End
         Begin VB.TextBox TxtLista 
            Height          =   375
            Left            =   1200
            TabIndex        =   1
            Top             =   720
            Width           =   5895
         End
         Begin VB.ComboBox CboTipoLista 
            Height          =   360
            Left            =   7200
            Style           =   2  'Dropdown List
            TabIndex        =   2
            Top             =   720
            Width           =   2415
         End
         Begin VB.TextBox TxtIdLista 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   360
            MaxLength       =   5
            TabIndex        =   0
            Top             =   720
            Width           =   735
         End
         Begin MSComctlLib.ListView LstListasPrecio 
            Height          =   6735
            Left            =   360
            TabIndex        =   29
            Top             =   1200
            Width           =   11895
            _ExtentX        =   20981
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
            TabIndex        =   54
            Top             =   8160
            Width           =   810
         End
         Begin VB.Label Label12 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Descripción de la Lista"
            Height          =   255
            Left            =   1200
            TabIndex        =   32
            Top             =   480
            Width           =   3735
         End
         Begin VB.Label Label13 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cve. L"
            Height          =   255
            Left            =   360
            TabIndex        =   31
            Top             =   480
            Width           =   735
         End
         Begin VB.Label Label15 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Tipo de Lista"
            Height          =   255
            Left            =   7200
            TabIndex        =   30
            Top             =   480
            Width           =   1455
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
         Height          =   8595
         Index           =   0
         Left            =   0
         TabIndex        =   22
         Top             =   320
         Width           =   12375
         Begin VB.Frame FrmVendedores 
            BackColor       =   &H00FFFFFF&
            Caption         =   "  Precios y Productos "
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   8055
            Left            =   5280
            TabIndex        =   23
            Top             =   360
            Width           =   6975
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
               Left            =   6240
               Picture         =   "AL_Cat_Precios.frx":1EA3
               Style           =   1  'Graphical
               TabIndex        =   42
               Top             =   360
               Visible         =   0   'False
               Width           =   495
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
               Left            =   5760
               Picture         =   "AL_Cat_Precios.frx":22C8
               Style           =   1  'Graphical
               TabIndex        =   41
               Top             =   360
               Visible         =   0   'False
               Width           =   495
            End
            Begin VB.TextBox TxtIdProd 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   120
               MaxLength       =   10
               TabIndex        =   5
               Top             =   1320
               Width           =   975
            End
            Begin VB.TextBox TxtProducto 
               Enabled         =   0   'False
               Height          =   375
               Left            =   1200
               TabIndex        =   6
               Top             =   1320
               Width           =   4335
            End
            Begin VB.TextBox TxtPrecio 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   5640
               MaxLength       =   12
               TabIndex        =   7
               Top             =   1320
               Width           =   1095
            End
            Begin MSComctlLib.ListView LstPrecProd 
               Height          =   6135
               Left            =   120
               TabIndex        =   24
               Top             =   1800
               Width           =   6615
               _ExtentX        =   11668
               _ExtentY        =   10821
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
            Begin VB.Label LblLista 
               AutoSize        =   -1  'True
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
               Height          =   240
               Left            =   1920
               TabIndex        =   40
               Top             =   720
               Width           =   3540
            End
            Begin VB.Label LblCedi 
               AutoSize        =   -1  'True
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
               Height          =   240
               Left            =   1920
               TabIndex        =   39
               Top             =   360
               Width           =   3540
            End
            Begin VB.Label Label14 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Listas de Precios:"
               Height          =   240
               Left            =   120
               TabIndex        =   38
               Top             =   720
               Width           =   1575
            End
            Begin VB.Label Label2 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Cedis:"
               Height          =   240
               Left            =   1200
               TabIndex        =   37
               Top             =   360
               Width           =   555
            End
            Begin VB.Label LblNombre 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Producto"
               Height          =   255
               Left            =   1200
               TabIndex        =   27
               Top             =   1080
               Width           =   1335
            End
            Begin VB.Label LblIdVendedor 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Clave"
               Height          =   255
               Left            =   120
               TabIndex        =   26
               Top             =   1080
               Width           =   615
            End
            Begin VB.Label LblNomina 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Precio"
               Height          =   255
               Left            =   5640
               TabIndex        =   25
               Top             =   1080
               Width           =   1095
            End
         End
         Begin MSComctlLib.ListView LstCedis 
            Height          =   2655
            Left            =   120
            TabIndex        =   3
            Top             =   600
            Width           =   5055
            _ExtentX        =   8916
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
         Begin MSComctlLib.ListView LstListasCedis 
            Height          =   4815
            Left            =   120
            TabIndex        =   4
            Top             =   3600
            Width           =   5055
            _ExtentX        =   8916
            _ExtentY        =   8493
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
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Listas de Precios"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Left            =   240
            TabIndex        =   36
            Top             =   3360
            Width           =   1605
         End
         Begin VB.Label Label1 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cedis"
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
            Left            =   360
            TabIndex        =   35
            Top             =   360
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
         Height          =   8595
         Index           =   4
         Left            =   -75000
         TabIndex        =   20
         Top             =   320
         Width           =   12375
         Begin VB.OptionButton OptPrecios 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Por Ruta"
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
            Index           =   2
            Left            =   4080
            TabIndex        =   10
            Top             =   240
            Width           =   1335
         End
         Begin VB.OptionButton OptPrecios 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Por Cliente"
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
            Left            =   2160
            TabIndex        =   9
            Top             =   240
            Width           =   1575
         End
         Begin VB.OptionButton OptPrecios 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Por Cedis"
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
            Left            =   480
            TabIndex        =   8
            Top             =   240
            Value           =   -1  'True
            Width           =   1335
         End
         Begin MSComctlLib.ListView LstListasPrecios 
            Height          =   2775
            Left            =   240
            TabIndex        =   14
            Top             =   5760
            Width           =   11895
            _ExtentX        =   20981
            _ExtentY        =   4895
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
         Begin MSComctlLib.ListView LstCedis1 
            Height          =   1695
            Left            =   240
            TabIndex        =   12
            Top             =   3600
            Width           =   5895
            _ExtentX        =   10398
            _ExtentY        =   2990
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
         Begin MSComctlLib.ListView LstLista1 
            Height          =   2415
            Left            =   240
            TabIndex        =   11
            Top             =   840
            Width           =   5895
            _ExtentX        =   10398
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
         Begin MSComctlLib.ListView LstClientesRutas 
            Height          =   4455
            Left            =   6360
            TabIndex        =   13
            Top             =   840
            Width           =   5895
            _ExtentX        =   10398
            _ExtentY        =   7858
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
            Enabled         =   0   'False
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
         Begin VB.Frame FrmOpc 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Tipo de Asignación"
            Height          =   735
            Left            =   120
            TabIndex        =   44
            Top             =   6840
            Visible         =   0   'False
            Width           =   12015
            Begin VB.TextBox TxtCedi 
               Height          =   375
               Left            =   1320
               MaxLength       =   50
               TabIndex        =   50
               Top             =   360
               Visible         =   0   'False
               Width           =   3255
            End
            Begin VB.TextBox TxtListaPrecio 
               Height          =   375
               Left            =   6240
               Locked          =   -1  'True
               TabIndex        =   49
               Top             =   360
               Visible         =   0   'False
               Width           =   3735
            End
            Begin VB.CommandButton BtnNew 
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
               Height          =   855
               Left            =   10080
               Picture         =   "AL_Cat_Precios.frx":26A5
               Style           =   1  'Graphical
               TabIndex        =   48
               Top             =   240
               Visible         =   0   'False
               Width           =   855
            End
            Begin VB.CommandButton BtnDelete 
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
               Height          =   855
               Left            =   10920
               Picture         =   "AL_Cat_Precios.frx":2A66
               Style           =   1  'Graphical
               TabIndex        =   47
               Top             =   240
               Visible         =   0   'False
               Width           =   855
            End
            Begin VB.Label Label8 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Lista de Precios"
               Height          =   255
               Left            =   4680
               TabIndex        =   52
               Top             =   360
               Visible         =   0   'False
               Width           =   1455
            End
            Begin VB.Label LblOpc 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Cliente / Ruta"
               Height          =   255
               Left            =   0
               TabIndex        =   51
               Top             =   480
               Visible         =   0   'False
               Width           =   1095
            End
         End
         Begin VB.Label LblOpcion 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clientes / Rutas"
            Enabled         =   0   'False
            Height          =   255
            Left            =   6480
            TabIndex        =   53
            Top             =   600
            Width           =   1575
         End
         Begin VB.Label Label6 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Lista de Precio"
            Height          =   255
            Left            =   360
            TabIndex        =   46
            Top             =   600
            Width           =   1575
         End
         Begin VB.Label LblCedis 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cedis"
            Height          =   255
            Left            =   480
            TabIndex        =   45
            Top             =   3360
            Width           =   2175
         End
         Begin VB.Label Label9 
            Alignment       =   2  'Center
            BackColor       =   &H00FFFFFF&
            Caption         =   "Asignación de Listas de Precios"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000000&
            Height          =   255
            Left            =   240
            TabIndex        =   43
            Top             =   5400
            Width           =   12015
         End
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Asignación de Listas"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   2
         Left            =   -66755
         TabIndex        =   34
         Top             =   0
         Width           =   4130
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Precios y Productos"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   1
         Left            =   4115
         TabIndex        =   33
         Top             =   0
         Width           =   4150
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Listas de Precios"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   0
         Left            =   -74995
         TabIndex        =   21
         Top             =   0
         Width           =   4150
      End
   End
End
Attribute VB_Name = "AL_Cat_Precios"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Nuevo As Boolean
Dim PCedis, IdLista As Integer, LstDClientesRutas, LstDListasPrecios

Private Sub btnActualizar_Click()
On Error Resume Next

Dim TipoLista As String

If LblEdicion.Caption = "Consultar" Then Exit Sub

    Select Case SSTab.Tab
            Case 0: If Not ValidaModulo("CATPRECCAT", True) Then Exit Sub
            Case 1: If Not ValidaModulo("CATPRECPRC", True) Then Exit Sub
            Case 2: If Not ValidaModulo("CATPRECLISTA", True) Then Exit Sub
    End Select
    
    If Rs.State Then Rs.Close
    Rs.Open "Select IdLista from PreciosLista where IdLista = '" & Trim(TxtIdLista.Text) & "'", Cnn
    If Not Rs.EOF And Nuevo Then
        MsgBox "¡ Esta clave de Listas de Precios ya existe !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    If Nuevo And Trim(TxtIdLista.Text) = "" Or Trim(TxtIdLista.Text) = "0" Then Exit Sub
    
    If Rs.State Then Rs.Close
    Rs.Open "SELECT * FROM TIPOLISTA WHERE TipoLista = '" & Trim(CboTipoLista.Text) & "'", Cnn
    TipoLista = Rs!IdTipoLista
    StrCmd = "execute up_ListasPrecios " & Trim(TxtIdLista.Text) & ", '" & UCase(Trim(TxtLista.Text)) & "', " & TipoLista & ", '" & FormatDate(Date) & "'," & IIf(Nuevo, 1, 2)
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    MuestraLitasPrecios
    
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
    LblEdicion.Caption = "Consultar"
    Nuevo = False
End Sub

Sub MuestraLitasPrecios()

On Error Resume Next

    StrCmd = "execute sel_ListasPrecios "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDListasPrecios = GetDataLVL(Rs, LstListasPrecio, 0, 4, "0|0|0|0|0")
    
End Sub

Sub MuestraLitasPrecios1()

On Error Resume Next

    StrCmd = "execute sel_ListasPrecios "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDListasPrecios = GetDataLVL(Rs, LstLista1, 0, 4, "0|0|0|0|0")
    
End Sub

'Sub MuestraLitasPP()
'    StrCmd = "execute sel_ListasPrecios "
'    If Rs.State Then Rs.Close
'    Rs.Open StrCmd, Cnn
'    lstdlistasprecios = GetDataLVL(Rs, LstListasPP, 0, 1, "1|0|0|0|0")
'End Sub

Sub MuestraCedis()

On Error Resume Next

    StrCmd = "execute sel_Cedis "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDListasPrecios = GetDataLVL(Rs, LstCedis, 0, 2, "1|0|0")
End Sub

Sub MuestraCedis1()

On Error Resume Next

    StrCmd = "execute sel_Cedis "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDListasPrecios = GetDataLVL(Rs, LstCedis1, 0, 2, "1|0|0")
End Sub

Private Sub btnAddC_Click()

On Error Resume Next

    If LblCedi.Caption = "" Or LblLista.Caption = "" Then
        MsgBox (" Ingrese Cedis o Lista de Precios a Modificar "), vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    TxtIdProd.Text = ""
    TxtProducto.Text = ""
    TxtPrecio.Text = ""
    Nuevo = True
    TxtIdProd.SetFocus
End Sub

Private Sub BtnDelete_Click()

On Error Resume Next

Dim Cedis, Lista As Integer
        
        If IsEmpty(LstListasPrecios) Then Exit Sub
        
        If MsgBox("¿ Está seguro de eliminar la Lista de Precios ?", vbQuestion + vbYesNo, App.Title) = vbNo Then
            Exit Sub
        End If
    
        If Rs.State Then Rs.Close
        Rs.Open "SELECT * FROM cedis WHERE cedis = '" & Trim(LstListasPrecios.ListItems(LstListasPrecios.SelectedItem.Index).Text) & "'", Cnn
        Cedis = Rs!IdCedis
        If Rs.State Then Rs.Close
        Rs.Open "SELECT * FROM precioslista WHERE descripcion = '" & Trim(LstListasPrecios.ListItems(LstListasPrecios.SelectedItem.Index).SubItems(1)) & "'", Cnn
        Lista = Rs!IdLista
        
        StrCmd = "execute up_CedisListas " & Cedis & ", " & Lista & ", 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        MsgBox "¡ Lista de Precios Eliminada !", vbInformation + vbOKOnly, App.Title
        'MuestraCedisListas
        TxtCedi.Text = ""
        TxtListaPrecio = ""
        
End Sub

Private Sub btnDeleteC_Click()

On Error Resume Next
    
    If Trim(TxtIdProd.Text) = "" Then
        MsgBox "¡ Seleccione el registro a dar de Baja !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    StrCmd = "execute up_Precios " & IdLista & ", " & TxtIdProd.Text & ", 0, 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    StrCmd = "execute sel_PreciosDetalle  " & PCedis & ", " & IdLista & ""
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDListasPrecios = GetDataLVL(Rs, LstPrecProd, 0, 2, "0|0|10")
    
    TxtIdProd.Text = ""
    TxtProducto.Text = ""
    TxtPrecio.Text = ""
    TxtIdProd.SetFocus
    Nuevo = False
    
End Sub

Private Sub btnEliminar_Click()
On Error GoTo Err_Eliminar:

    Select Case SSTab.Tab
            Case 0: If Not ValidaModulo("CATPRECCAT", True) Then Exit Sub
            Case 1: If Not ValidaModulo("CATPRECPRC", True) Then Exit Sub
            Case 2: If Not ValidaModulo("CATPRECLISTA", True) Then Exit Sub
    End Select
    
    If Trim(TxtIdLista.Text) = "" Or LstListasPrecio.ListItems.Count <= 0 Then
        MsgBox "¡ Seleccione el registro a dar de Baja !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If MsgBox("¿ Estás seguro que deseas dar de Baja la Lista seleccionada ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
        If MsgBox("Toda la Información relacionada con esa Lista de Precios se perderá. " & Chr(13) & Chr(10) & " ¿ Deseas continuar con la Baja de la Lista seleccionada ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    Else
        Exit Sub
    End If
    
    StrCmd = "execute up_ListasPrecios " & TxtIdLista.Text & ", '','', '', 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    MuestraLitasPrecios
    Nuevo = False
    LblEdicion.Caption = "Consultar"
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title

No_Err_Eliminar:
    MousePointer = 0
    Exit Sub

Err_Eliminar:
    MousePointer = 0
    MsgBox "¡ Error al Eliminar la Carga !. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_Eliminar:
End Sub

Private Sub btnImprimir_Click()

On Error Resume Next

    If IsEmpty(LstListasPrecios) Then Exit Sub
    If Trim(TxtIdLista.Text) = "" Then
        MsgBox "¡ Seleccione una Lista de precios !", vbInformation + vbOKOnly
        Exit Sub
    End If
    
    With AL_RptCatListaPrecio
        .Caption = "Listas de Precios"
        .LblTitulo.Caption = "Listas de Precios"
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
        StrCmd = "select l.idlista, l.descripcion, d.idproducto, p.producto, d.precio, p.iva, d.precio * (1+p.iva) as PrecioIva " _
                & " from preciosdetalle d, precioslista l, productos p " _
                & " Where l.IdLista = " & Trim(TxtIdLista.Text) & " And l.IdLista = d.IdLista And p.idproducto = d.idproducto and d.precio <> 0 " _
                & " order by d.idproducto "
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
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub BtnNew_Click()

On Error Resume Next

Dim Cedis, Lista As Integer
            
        If Trim(TxtCedi.Text) = "" Or Trim(TxtListaPrecio.Text) = "" Then
            MsgBox "¡ Ingrese datos para Asignar Lista de Precios !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If

        If Rs.State Then Rs.Close
        Rs.Open "SELECT * FROM cedis WHERE cedis = '" & Trim(TxtCedi.Text) & "'", Cnn
        Cedis = Rs!IdCedis
        If Rs.State Then Rs.Close
        Rs.Open "SELECT * FROM precioslista WHERE descripcion = '" & Trim(TxtListaPrecio.Text) & "'", Cnn
        Lista = Rs!IdLista
        
        If Rs.State Then Rs.Close
        Rs.Open "SELECT * FROM precioslistacedis WHERE IdLista = " & Lista & " and IdCedis = " & Cedis & "", Cnn
        If Rs.EOF Then
            StrCmd = "execute up_CedisListas " & Cedis & ", '" & Lista & "', 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            'MuestraCedisListas
        Else
            MsgBox "¡ Lista de Precios ya fue Asignada a Cedis !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        TxtCedi.Text = ""
        TxtListaPrecio = ""
            
End Sub

Private Sub btnNuevo_Click()
On Error GoTo Err_AltaListaPrecio:

    Select Case SSTab.Tab
            Case 0: If Not ValidaModulo("CATPRECCAT", True) Then Exit Sub
            Case 1: If Not ValidaModulo("CATPRECPRC", True) Then Exit Sub
            Case 2: If Not ValidaModulo("CATPRECLISTA", True) Then Exit Sub
    End Select
        
        TxtIdLista.Text = "": TxtLista.Text = "" ': CboTipoLista.Text = ""
        If Rs.State Then Rs.Close
        Rs.Open "SELECT ISNULL(MAX(IdLista),0)+1 AS MAXI From Precioslista", Cnn
        TxtIdLista.Text = Rs!MAXI
        Nuevo = True
        TxtLista.SetFocus
        
        LblEdicion.Caption = "Nuevo"

No_Err_AltaListaPrecio:
    MousePointer = 0
    Exit Sub

Err_AltaListaPrecio:
    MousePointer = 0
    MsgBox "Error al Agregar nueva lista de precios. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_AltaListaPrecio:
End Sub

Private Sub Form_Activate()
On Error Resume Next
    SSTab.Tab = 0
End Sub

Private Sub Form_Load()
On Error Resume Next
    
    Nuevo = False
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    MuestraLitasPrecios
    LLENA_COMBOS
    IdCedis = "1"
    SSTab.Tab = 0
End Sub

Sub LLENA_COMBOS()

On Error Resume Next
    
    'LLENA LISTAS DE PRECIOS
    CboTipoLista.Clear
    If Rs.State Then Rs.Close
    Rs.Open "SELECT TipoLista FROM tipolista WHERE STATUS = 'A' ORDER BY IdTipoLista", Cnn
    While Not Rs.EOF
        CboTipoLista.AddItem Trim(Rs!TipoLista)
        Rs.MoveNext
    Wend
    Rs.Close
    
End Sub

Private Sub LstCedis_Click()
On Error Resume Next
    LstCedis_DblClick
End Sub

Private Sub LstCedis_DblClick()

On Error Resume Next
    
    If IsEmpty(LstCedis) Then Exit Sub
    PCedis = CLng(LstCedis.SelectedItem)
    StrCmd = "execute sel_LitasCedis  " & PCedis & ""
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDListasPrecios = GetDataLVL(Rs, LstListasCedis, 0, 1, "0|0")
    Inicia_PP
    LblCedi.Caption = LstCedis.ListItems(LstCedis.SelectedItem.Index).SubItems(1)
    
End Sub

Sub Inicia_PP()
On Error Resume Next

    LblLista.Caption = ""
    LblCedi.Caption = ""
    TxtIdProd.Text = ""
    TxtProducto.Text = ""
    TxtPrecio.Text = ""
    LstPrecProd.ListItems.Clear
    LstPrecProd.ColumnHeaders.Clear

End Sub

Private Sub LstCedis_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstCedis_Click
End Sub

Private Sub LstCedis1_DblClick()
On Error Resume Next

Dim Base As Boolean

    If Not ValidaModulo("CATPRECLISTA", True) Then Exit Sub
    
    If LstCedis1.ListItems.Count <= 0 Or LstLista1.ListItems.Count <= 0 Then Exit Sub
    If OptPrecios(0).Value Then
        If MsgBox("Está seguro que deseas Agregar la Lista de Precios " & LstLista1.SelectedItem & " - " & LstLista1.SelectedItem.ListSubItems(1) & " ? ", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        
        Base = IIf(Trim(UCase(LstLista1.SelectedItem.ListSubItems(2))) = "BASE", True, False)
        If Base Then
            StrCmd = "select IdCedis, PreciosListaCedis.IdLista From PreciosListaCedis inner join PreciosLista on PreciosLista.IdLista = PreciosListaCedis.IdLista and upper(TipoLista) = 'BA' where PreciosListaCedis.IdCedis = " & CLng(LstCedis1.SelectedItem)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            
            If Not Rs.EOF Then
                MsgBox "¡ No puedes asignar más de una Lista Base por cada Cedis !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        End If
        
        ' Alta de Lista a Cedis
        StrCmd = "execute up_AsignaListas " & CLng(LstCedis1.SelectedItem) & ", " & CLng(LstLista1.SelectedItem) & ", 0, 0, 0, 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        MuestraListasAsignadas CLng(LstCedis1.SelectedItem), 0, 0, 0
        MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    Else
        FiltraClientesRutas IIf(OptPrecios(1).Value, 1, 2), CLng(LstCedis1.SelectedItem)
    End If
    
End Sub

Private Sub LstCedis1_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    LstListasPrecios.ListItems.Clear
    If LstCedis1.ListItems.Count <= 0 Or LstLista1.ListItems.Count <= 0 Then Exit Sub
    If OptPrecios(0).Value Then
        MuestraListasAsignadas CLng(LstCedis1.SelectedItem), 0, 0, 0
    Else
        FiltraClientesRutas IIf(OptPrecios(1).Value, 1, 2), CLng(LstCedis1.SelectedItem)
    End If
End Sub

Private Sub LstClientesRutas_DblClick()
On Error Resume Next
    If LstClientesRutas.ListItems.Count <= 0 Then Exit Sub
    
    If Not ValidaModulo("CATPRECLISTA", True) Then Exit Sub
    
    If LstListasPrecios.ListItems.Count > 0 Then
        MsgBox "¡ No puedes Asignar más de una lista al Cliente o Ruta !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If MsgBox("Está seguro que deseas Agregar la Lista de Precios " & LstLista1.SelectedItem & " - " & LstLista1.SelectedItem.ListSubItems(1) & " ? ", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    ' Alta de Lista a Cliente o Ruta
    StrCmd = "execute up_AsignaListas " & CLng(LstCedis1.SelectedItem) & ", " & CLng(LstLista1.SelectedItem) & ", " & CLng(LstClientesRutas.SelectedItem) & ", " & CLng(LstClientesRutas.SelectedItem) & ", " & IIf(OptPrecios(1).Value, 1, 2) & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MuestraListasAsignadas CLng(LstCedis1.SelectedItem), CLng(LstLista1.SelectedItem), CLng(LstClientesRutas.SelectedItem), IIf(OptPrecios(1).Value, 1, 2)
    MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title
    Exit Sub
End Sub

Private Sub LstClientesRutas_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    If Not OptPrecios(0).Value Then
        MuestraListasAsignadas CLng(LstCedis1.SelectedItem), CLng(LstClientesRutas.SelectedItem), CLng(LstClientesRutas.SelectedItem), IIf(OptPrecios(1).Value, 1, 2)
    End If
End Sub

Private Sub LstLista1_Click()
On Error Resume Next
    LstLista1_DblClick
End Sub

Private Sub LstLista1_DblClick()
On Error Resume Next

    TxtListaPrecio.Text = ""
    TxtListaPrecio.Text = LstLista1.ListItems(LstLista1.SelectedItem.Index).SubItems(1)
End Sub

Private Sub LstListasCedis_Click()
On Error Resume Next
    LstListasCedis_DblClick
End Sub

Private Sub LstListasCedis_DblClick()
On Error Resume Next

'    LblCedi.Caption = ""
    TxtIdProd.Text = ""
    TxtProducto.Text = ""
    TxtPrecio.Text = ""
    LstPrecProd.ListItems.Clear
    LstPrecProd.ColumnHeaders.Clear
    LblLista.Caption = LstListasCedis.ListItems(LstListasCedis.SelectedItem.Index).SubItems(1)
    
    If IsEmpty(LstListasCedis) Then Exit Sub
    IdLista = CLng(LstListasCedis.SelectedItem)
    StrCmd = "execute sel_PreciosDetalle  " & PCedis & ", " & IdLista & ""
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDListasPrecios = GetDataLVL(Rs, LstPrecProd, 0, 2, "0|0|0")
    
End Sub

Private Sub LstListasCedis_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstListasCedis_Click
End Sub

Private Sub LstListasPrecio_Click()
On Error Resume Next
    
    TxtIdLista.Text = LstListasPrecio.ListItems(LstListasPrecio.SelectedItem.Index).Text
    TxtLista.Text = LstListasPrecio.ListItems(LstListasPrecio.SelectedItem.Index).SubItems(1)
    CboTipoLista.Text = LstListasPrecio.ListItems(LstListasPrecio.SelectedItem.Index).SubItems(2)
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub LstListasPrecio_DblClick()
On Error Resume Next

    LblEdicion.Caption = "Actualizar"
    Nuevo = False
End Sub

Private Sub LstListasPrecio_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstListasPrecio_Click
End Sub

Private Sub LstListasPrecios_DblClick()
On Error Resume Next
Dim Op, Base As Boolean

    If Not ValidaModulo("CATPRECLISTA", True) Then Exit Sub

Base = False
If OptPrecios(0).Value Then Op = 0
If OptPrecios(1).Value Then Op = 1
If OptPrecios(2).Value Then Op = 2

    If LstListasPrecios.ListItems.Count <= 0 Then Exit Sub
    
    If MsgBox("Está seguro que deseas Quitar la Lista de Precios " & LstListasPrecios.SelectedItem.ListSubItems(3) & " - " & LstListasPrecios.SelectedItem.ListSubItems(4) & " ? ", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub

    Base = IIf(Trim(UCase(LstListasPrecios.SelectedItem.ListSubItems(4))) = "BASE" And Op = 0, True, False)
    If Base Then If MsgBox("Estás a punto de Quitar del Cedis la Lista Base. " & Chr(13) & Chr(10) & "La Lista Base es indispensable para el funcionamiento del Sistema. " & Chr(13) & Chr(10) & "¿ Deseas continuar de cualquier forma ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    StrCmd = "execute up_AsignaListas " & CLng(LstCedis1.SelectedItem) & ", " & CLng(LstListasPrecios.SelectedItem.ListSubItems(2)) & ", " & CLng(LstListasPrecios.SelectedItem) & ", " & CLng(LstListasPrecios.SelectedItem) & ", " & Op & ", 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MuestraListasAsignadas CLng(LstCedis1.SelectedItem), 0, 0, Op
    MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title
    Exit Sub
End Sub

Private Sub LstPrecProd_Click()
On Error Resume Next
    LstPrecProd_DblClick
End Sub

Private Sub LstPrecProd_DblClick()
On Error Resume Next

    If LstPrecProd.ListItems.Count <= 0 Then Exit Sub
    TxtIdProd.Text = LstPrecProd.ListItems(LstPrecProd.SelectedItem.Index).Text
    TxtProducto.Text = LstPrecProd.ListItems(LstPrecProd.SelectedItem.Index).SubItems(1)
    TxtPrecio.Text = LstPrecProd.ListItems(LstPrecProd.SelectedItem.Index).SubItems(2)
    Nuevo = False
    TxtPrecio.SetFocus
End Sub

Private Sub LstPrecProd_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstPrecProd_Click
End Sub

Private Sub OptPrecios_Click(Index As Integer)
On Error Resume Next
    
    Select Case Index
        Case 0:
            LstClientesRutas.Enabled = False: LblOpcion.Enabled = False
        Case 1:
            LblOpcion.Caption = "Clientes"
            LstClientesRutas.Enabled = True: LblOpcion.Enabled = True
        Case 2:
            LblOpcion.Caption = "Rutas"
            LstClientesRutas.Enabled = True: LblOpcion.Enabled = True
    End Select
    LstListasPrecios.ListItems.Clear
    LstDListasPrecios = Empty
    LstClientesRutas.ListItems.Clear
    LstDClientesRutas = Empty
End Sub

Private Sub SSTab_Click(PreviousTab As Integer)
On Error Resume Next
    Select Case SSTab.Tab
        Case 0:
            MuestraLitasPrecios
        Case 1:
            MuestraCedis
        Case 2:
            MuestraLitasPrecios1
            MuestraCedis1
    End Select
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub TxtIdLista_Validate(Cancel As Boolean)
On Error Resume Next
    If Rs.State Then Rs.Close
    Rs.Open "Select IdLista from PreciosLista where IdLista = '" & Trim(TxtIdLista.Text) & "'", Cnn
    If Not Rs.EOF Then
        MsgBox "¡ Esta clave de Listas de Precios ya existe !", vbInformation + vbOKOnly, App.Title
        TxtIdLista.SetFocus
        SelText TxtIdLista
        Exit Sub
    End If
End Sub

Private Sub TxtIdProd_GotFocus()
On Error Resume Next
    SelText TxtIdProd
End Sub

Private Sub TxtIdProd_KeyPress(KeyAscii As Integer)

On Error Resume Next

Dim Cedis, Lista As Integer
If KeyAscii = 13 Then
    
    If LblCedi.Caption = "" Or LblLista.Caption = "" Or TxtIdProd.Text = "" Then
        MsgBox (" Ingrese Cedis o Lista de Precios a Modificar "), vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Rs.State Then Rs.Close
    Rs.Open "SELECT * FROM cedis WHERE cedis = '" & Trim(LblCedi.Caption) & "'", Cnn
    Cedis = Rs!IdCedis
    
    If Rs.State Then Rs.Close
    Rs.Open "SELECT * FROM precioslista WHERE descripcion = '" & Trim(LblLista.Caption) & "'", Cnn
    Lista = Rs!IdLista
    
    If Rs.State Then Rs.Close
    Rs.Open "select c.cedis, l.descripcion, d.idproducto, p.producto, d.precio" _
            & " from precioslista l, preciosdetalle d, precioslistacedis u, cedis c, productos p " _
            & " Where c.IdCedis = u.IdCedis And d.idproducto = p.idproducto And u.IdLista = l.IdLista " _
            & " And l.IdLista = d.IdLista and d.idproducto = '" & Trim(TxtIdProd.Text) & "' and l.idlista = " & Lista & " and c.idcedis = " & PCedis & "", Cnn
    If Not Rs.EOF Then
        TxtProducto.Text = Rs!producto
        TxtPrecio.Text = Rs!Precio
        TxtPrecio.SetFocus
        Nuevo = False
    Else
        If Rs.State Then Rs.Close
        Rs.Open "select * from productos where idproducto = '" & Trim(TxtIdProd.Text) & "' ", Cnn
        If Not Rs.EOF Then
            TxtProducto.Text = Rs!producto
            TxtPrecio.Text = ""
            TxtPrecio.SetFocus
            Nuevo = True
        Else
            MsgBox (" Producto no existe en Catalogo "), vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
    End If
    
End If
End Sub

Private Sub TxtLista_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtPrecio_GotFocus()
On Error Resume Next
    SelText TxtPrecio
End Sub

Private Sub TxtPrecio_KeyPress(KeyAscii As Integer)

On Error GoTo Err_Precios:

Dim Lista As Integer
If KeyAscii = 13 Then
    
    If Not ValidaModulo("CATPRECPRC", True) Then Exit Sub
    
    If LblCedi.Caption = "" Or LblLista.Caption = "" Then
        MsgBox (" Ingrese Cedis o Lista de Precios a Modificar "), vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    If TxtIdProd.Text = "" Or TxtPrecio.Text = "" Then
        MsgBox (" Ingrese Producto o Precio a Modificar "), vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    Opc = IIf(Nuevo, 1, 2)
    If CDbl(TxtPrecio.Text) = 0 Then Opc = 3
    
    StrCmd = "execute up_Precios " & Trim(IdLista) & ", " & CDbl(TxtIdProd.Text) & ", " & CDbl(TxtPrecio.Text) & "," & IdCedis & ", " & Opc
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn

    StrCmd = "execute sel_PreciosDetalle  " & PCedis & ", " & IdLista & ""
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDListasPrecios = GetDataLVL(Rs, LstPrecProd, 0, 2, "0|0|10")
    
    TxtIdProd.Text = ""
    TxtProducto.Text = ""
    TxtPrecio.Text = ""
    TxtIdProd.SetFocus
    'If Nuevo Then MsgBox (" Nuevo producto ingresado a Lista de Precios "), vbInformation + vbOKOnly, App.Title
    Nuevo = False
    
End If

No_Err_Precios:
    MousePointer = 0
    Exit Sub

Err_Precios:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_Precios:
End Sub


Sub FiltraClientesRutas(Opc, IdCed)
On Error Resume Next
    If Opc = 1 Then
        StrCmd = "execute sel_Clientes " & IdCed
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        LstDClientesRutas = GetDataLVL(Rs, LstClientesRutas, 0, 2, "0|0|0")
    Else
        StrCmd = "execute sel_RutasPrecios " & IdCed
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        LstDClientesRutas = GetDataLVL(Rs, LstClientesRutas, 1, 2, "0|0")
    End If
End Sub

Sub MuestraListasAsignadas(Cedi, IdCte, IdRut, Opc)

On Error Resume Next

    Select Case Opc
        Case 0:
            StrCmd = "execute sel_CedisLista " & Cedi & ", 0, " & IdCte & ", " & IdRut & ", " & Opc
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            LstDListasPrecios = GetDataLVL(Rs, LstListasPrecios, 1, 5, "0|0|0|0|0")
        Case 1
            StrCmd = "execute sel_CedisLista " & Cedi & ", 0, " & IdCte & ", " & IdRut & ", " & Opc
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            LstDListasPrecios = GetDataLVL(Rs, LstListasPrecios, 1, 5, "0|0|0|0|0")
        Case 2
            StrCmd = "execute sel_CedisLista " & Cedi & ", 0, " & IdCte & ", " & IdRut & ", " & Opc
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            LstDListasPrecios = GetDataLVL(Rs, LstListasPrecios, 1, 5, "0|0|0|0|0")
    End Select
    
End Sub

