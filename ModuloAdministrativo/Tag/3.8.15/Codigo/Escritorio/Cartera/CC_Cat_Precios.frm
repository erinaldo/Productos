VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.ocx"
Begin VB.Form Cat_Precios 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "      Creación y Asignación de Listas Precios"
   ClientHeight    =   9090
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   12855
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
   ScaleHeight     =   9090
   ScaleWidth      =   12855
   ShowInTaskbar   =   0   'False
   Begin TabDlg.SSTab SSTab 
      Height          =   8895
      Left            =   240
      TabIndex        =   14
      Top             =   120
      Width           =   12375
      _ExtentX        =   21828
      _ExtentY        =   15690
      _Version        =   393216
      Tab             =   1
      TabHeight       =   520
      BackColor       =   16777215
      TabCaption(0)   =   "Listas de Precios"
      TabPicture(0)   =   "CC_Cat_Precios.frx":0000
      Tab(0).ControlEnabled=   0   'False
      Tab(0).Control(0)=   "FrmOpt(3)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "LblOpt(0)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "Precios y Productos"
      TabPicture(1)   =   "CC_Cat_Precios.frx":001C
      Tab(1).ControlEnabled=   -1  'True
      Tab(1).Control(0)=   "LblOpt(1)"
      Tab(1).Control(0).Enabled=   0   'False
      Tab(1).Control(1)=   "FrmOpt(0)"
      Tab(1).Control(1).Enabled=   0   'False
      Tab(1).ControlCount=   2
      TabCaption(2)   =   "Asignacion de Listas"
      TabPicture(2)   =   "CC_Cat_Precios.frx":0038
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "LblOpt(2)"
      Tab(2).Control(1)=   "FrmOpt(4)"
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
         TabIndex        =   26
         Top             =   320
         Width           =   12375
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
            Height          =   1095
            Left            =   10920
            Picture         =   "CC_Cat_Precios.frx":0054
            Style           =   1  'Graphical
            TabIndex        =   4
            Top             =   2760
            Width           =   1215
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
            Height          =   1215
            Left            =   10920
            Picture         =   "CC_Cat_Precios.frx":03E0
            Style           =   1  'Graphical
            TabIndex        =   3
            Top             =   1560
            Width           =   1215
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
            Height          =   1095
            Left            =   10920
            Picture         =   "CC_Cat_Precios.frx":07A1
            Style           =   1  'Graphical
            TabIndex        =   6
            Top             =   4920
            Width           =   1215
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
            Height          =   1095
            Left            =   10920
            Picture         =   "CC_Cat_Precios.frx":0A6B
            Style           =   1  'Graphical
            TabIndex        =   5
            Top             =   3840
            Width           =   1215
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
            Height          =   7215
            Left            =   360
            TabIndex        =   27
            Top             =   1200
            Width           =   10455
            _ExtentX        =   18441
            _ExtentY        =   12726
            View            =   3
            LabelEdit       =   1
            LabelWrap       =   -1  'True
            HideSelection   =   -1  'True
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
            NumItems        =   1
            BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
               Object.Width           =   2540
            EndProperty
         End
         Begin VB.Label LblTitulo 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Titulo de la Pantalla"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   12
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000000C0&
            Height          =   285
            Left            =   120
            TabIndex        =   54
            Top             =   -120
            Visible         =   0   'False
            Width           =   2220
         End
         Begin VB.Image Image2 
            Height          =   285
            Left            =   9960
            Picture         =   "CC_Cat_Precios.frx":0DA9
            Top             =   -105
            Visible         =   0   'False
            Width           =   3315
         End
         Begin VB.Label Label12 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Descripción de la Lista"
            Height          =   255
            Left            =   1200
            TabIndex        =   30
            Top             =   480
            Width           =   3735
         End
         Begin VB.Label Label13 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cve. L"
            Height          =   255
            Left            =   360
            TabIndex        =   29
            Top             =   480
            Width           =   735
         End
         Begin VB.Label Label15 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Tipo de Lista"
            Height          =   255
            Left            =   7200
            TabIndex        =   28
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
         TabIndex        =   17
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
            TabIndex        =   18
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
               Picture         =   "CC_Cat_Precios.frx":19ED
               Style           =   1  'Graphical
               TabIndex        =   42
               Top             =   360
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
               Picture         =   "CC_Cat_Precios.frx":1E12
               Style           =   1  'Graphical
               TabIndex        =   41
               Top             =   360
               Width           =   495
            End
            Begin VB.TextBox TxtIdProd 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   120
               MaxLength       =   5
               TabIndex        =   19
               Top             =   1320
               Width           =   975
            End
            Begin VB.TextBox TxtProducto 
               Enabled         =   0   'False
               Height          =   375
               Left            =   1200
               TabIndex        =   22
               Top             =   1320
               Width           =   4335
            End
            Begin VB.TextBox TxtPrecio 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   5640
               MaxLength       =   8
               TabIndex        =   20
               Top             =   1320
               Width           =   1095
            End
            Begin MSComctlLib.ListView LstPrecProd 
               Height          =   6135
               Left            =   120
               TabIndex        =   21
               Top             =   1800
               Width           =   6615
               _ExtentX        =   11668
               _ExtentY        =   10821
               View            =   3
               LabelEdit       =   1
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
               TabIndex        =   25
               Top             =   1080
               Width           =   1335
            End
            Begin VB.Label LblIdVendedor 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Clave"
               Height          =   255
               Left            =   120
               TabIndex        =   24
               Top             =   1080
               Width           =   615
            End
            Begin VB.Label LblNomina 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Precio"
               Height          =   255
               Left            =   5640
               TabIndex        =   23
               Top             =   1080
               Width           =   1095
            End
         End
         Begin MSComctlLib.ListView LstCedis 
            Height          =   2655
            Left            =   120
            TabIndex        =   33
            Top             =   600
            Width           =   5055
            _ExtentX        =   8916
            _ExtentY        =   4683
            View            =   3
            LabelEdit       =   1
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
            NumItems        =   1
            BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
               Object.Width           =   2540
            EndProperty
         End
         Begin MSComctlLib.ListView LstListasCedis 
            Height          =   4815
            Left            =   120
            TabIndex        =   35
            Top             =   3600
            Width           =   5055
            _ExtentX        =   8916
            _ExtentY        =   8493
            View            =   3
            LabelEdit       =   1
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
            TabIndex        =   34
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
         TabIndex        =   15
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
            TabIndex        =   9
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
            TabIndex        =   8
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
            TabIndex        =   7
            Top             =   240
            Value           =   -1  'True
            Width           =   1335
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
               Picture         =   "CC_Cat_Precios.frx":21EF
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
               Picture         =   "CC_Cat_Precios.frx":25B0
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
         Begin MSComctlLib.ListView LstListasPrecios 
            Height          =   2775
            Left            =   240
            TabIndex        =   13
            Top             =   5760
            Width           =   11895
            _ExtentX        =   20981
            _ExtentY        =   4895
            View            =   3
            LabelEdit       =   1
            LabelWrap       =   -1  'True
            HideSelection   =   -1  'True
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
            NumItems        =   1
            BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
               Object.Width           =   2540
            EndProperty
         End
         Begin MSComctlLib.ListView LstCedis1 
            Height          =   1695
            Left            =   240
            TabIndex        =   11
            Top             =   3600
            Width           =   5895
            _ExtentX        =   10398
            _ExtentY        =   2990
            View            =   3
            LabelEdit       =   1
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
            NumItems        =   1
            BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
               Object.Width           =   2540
            EndProperty
         End
         Begin MSComctlLib.ListView LstLista1 
            Height          =   2415
            Left            =   240
            TabIndex        =   10
            Top             =   840
            Width           =   5895
            _ExtentX        =   10398
            _ExtentY        =   4260
            View            =   3
            LabelEdit       =   1
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
            NumItems        =   1
            BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
               Object.Width           =   2540
            EndProperty
         End
         Begin MSComctlLib.ListView LstClientesRutas 
            Height          =   4455
            Left            =   6360
            TabIndex        =   12
            Top             =   840
            Width           =   5895
            _ExtentX        =   10398
            _ExtentY        =   7858
            View            =   3
            LabelEdit       =   1
            LabelWrap       =   -1  'True
            HideSelection   =   0   'False
            FullRowSelect   =   -1  'True
            GridLines       =   -1  'True
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
         Caption         =   "Asignación / Impresión de Listas"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   2
         Left            =   -66735
         TabIndex        =   32
         Top             =   0
         Width           =   4110
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
         Left            =   4140
         TabIndex        =   31
         Top             =   240
         Width           =   4110
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
         TabIndex        =   16
         Top             =   0
         Width           =   4130
      End
   End
End
Attribute VB_Name = "Cat_Precios"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Nuevo As Boolean
Dim PCedis, IdLista As Integer, LstDClientesRutas

Private Sub btnActualizar_Click()

On Error Resume Next

Dim TipoLista As String

    If Rs.State Then Rs.Close
    Rs.Open "Select IdLista from PreciosLista where IdLista = '" & Trim(TxtIdLista.Text) & "'", Cnn
    If Not Rs.EOF Then
        Exit Sub
        MsgBox "¡ Esta clave de Listas de Precios ya existe !", vbInformation + vbOKOnly, App.Title
    End If

    If Nuevo And Trim(TxtIdLista.Text) = "" Or Trim(TxtIdLista.Text) = "0" Then Exit Sub
    
    If Rs.State Then Rs.Close
    Rs.Open "SELECT * FROM TIPOLISTA WHERE TipoLista = '" & Trim(CboTipoLista.Text) & "'", Cnn
    TipoLista = Rs!IdTipoLista
    StrCmd = "execute up_ListasPrecios " & Trim(TxtIdLista.Text) & ", '" & UCase(Trim(TxtLista.Text)) & "', " & TipoLista & ", '" & Format(Date & " " & Time, "DD/MM/YYYY HH:MM:SS") & "'," & IIf(Nuevo, 1, 2)
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    MuestraLitasPrecios
    
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
'    LLENA_LISTAS
    Nuevo = False
End Sub

Sub MuestraLitasPrecios()

On Error Resume Next

    StrCmd = "execute sel_ListasPrecios "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCadena = GetDataLVL(Rs, LstListasPrecio, 0, 4, "1|0|0|0|0")
    
End Sub

Sub MuestraLitasPrecios1()

On Error Resume Next

    StrCmd = "execute sel_ListasPrecios "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCadena = GetDataLVL(Rs, LstLista1, 0, 4, "1|0|0|0|0")
    
End Sub

'Sub MuestraLitasPP()
'    StrCmd = "execute sel_ListasPrecios "
'    If Rs.State Then Rs.Close
'    Rs.Open StrCmd, Cnn
'    LstDCadena = GetDataLVL(Rs, LstListasPP, 0, 1, "1|0|0|0|0")
'End Sub

Sub MuestraCedis()

On Error Resume Next

    StrCmd = "execute sel_Cedis "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCadena = GetDataLVL(Rs, LstCedis, 0, 2, "1|0|0")
End Sub

Sub MuestraCedis1()

On Error Resume Next

    StrCmd = "execute sel_Cedis "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCadena = GetDataLVL(Rs, LstCedis1, 0, 2, "1|0|0")
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
    LstDCadena = GetDataLVL(Rs, LstPrecProd, 0, 2, "1|0|0")
    
    TxtIdProd.Text = ""
    TxtProducto.Text = ""
    TxtPrecio.Text = ""
    TxtIdProd.SetFocus
    Nuevo = False
    
End Sub

Private Sub btnEliminar_Click()
On Error GoTo Err_Eliminar:

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
    With RptCatListaPrecio
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
        StrCmd = "select l.idlista, l.descripcion, d.idproducto, p.producto, d.precio, p.iva, d.precio * (1+p.iva) as PrecioIva " _
                & " from preciosdetalle d, precioslista l, productos p " _
                & " Where l.IdLista = " & Trim(TxtIdLista.Text) & " And l.IdLista = d.IdLista And p.idproducto = d.idproducto " _
                & " order by p.producto"
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn

        If Not RsC.EOF Then
            .object.DataSrc.DataSourceName = Cnn
            .object.DataSrc.Recordset = RsC
        End If
        
        .Printer.Orientation = ddOPortrait
        .Printer.PaperSize = 1
        .Printer.Orientation = ddOPortrait
        .Show 1
    End With
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

        TxtIdLista.Text = "": TxtLista.Text = "" ': CboTipoLista.Text = ""
        If Rs.State Then Rs.Close
        Rs.Open "SELECT ISNULL(MAX(IdLista),0)+1 AS MAXI From Precioslista", Cnn
        TxtIdLista.Text = Rs!MAXI
        Nuevo = True
        TxtLista.SetFocus

No_Err_AltaListaPrecio:
    MousePointer = 0
    Exit Sub

Err_AltaListaPrecio:
    MousePointer = 0
    MsgBox "Error al Agregar nueva lista de precios. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_AltaListaPrecio:
End Sub

Private Sub Command2_Click()

End Sub

Private Sub Form_Load()
    
    Nuevo = False
    If Not Cnn.State Then OpenConn Server, Db, "ITAPDC", "itapdc"
    MuestraLitasPrecios
    MuestraCedis
    MuestraLitasPrecios1
    MuestraCedis1
    'MuestraCedisListas
    LLENA_COMBOS
    IdCedis = "1"
    
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
    LstCedis_DblClick
End Sub

Private Sub LstCedis_DblClick()

On Error Resume Next
    
    If IsEmpty(LstCedis) Then Exit Sub
    PCedis = CLng(LstCedis.SelectedItem)
    StrCmd = "execute sel_LitasCedis  " & PCedis & ""
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCadena = GetDataLVL(Rs, LstListasCedis, 0, 1, "1|0")
    Inicia_PP
    LblCedi.Caption = LstCedis.ListItems(LstCedis.SelectedItem.Index).SubItems(1)
    
End Sub

Sub Inicia_PP()

    LblLista.Caption = ""
    LblCedi.Caption = ""
    TxtIdProd.Text = ""
    TxtProducto.Text = ""
    TxtPrecio.Text = ""
    LstPrecProd.ListItems.Clear
    LstPrecProd.ColumnHeaders.Clear

End Sub

Private Sub LstCedis1_Click()

On Error Resume Next

    If LstCedis1.ListItems.Count <= 0 Or LstLista1.ListItems.Count <= 0 Then Exit Sub
    If OptPrecios(0).Value Then
        MuestraListasAsignadas CLng(LstCedis1.SelectedItem), 0, 0, 0
    Else
        FiltraClientesRutas IIf(OptPrecios(1).Value, 1, 2), CLng(LstCedis1.SelectedItem)
    End If
End Sub

Private Sub LstCedis1_DblClick()
On Error Resume Next

Dim Base As Boolean

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

Private Sub LstCedis1_KeyDown(KeyCode As Integer, Shift As Integer)
    LstCedis1_Click
End Sub

Private Sub LstCedis1_KeyPress(KeyAscii As Integer)
    LstCedis1_Click
End Sub

Private Sub LstCedis1_KeyUp(KeyCode As Integer, Shift As Integer)
    LstCedis1_Click
End Sub

Private Sub LstClientesRutas_Click()
    If LstCedis1.ListItems.Count <= 0 Or LstLista1.ListItems.Count <= 0 Or LstClientesRutas.ListItems.Count <= 0 Then Exit Sub
    If Not OptPrecios(0).Value Then
        MuestraListasAsignadas CLng(LstCedis1.SelectedItem), CLng(LstClientesRutas.SelectedItem), CLng(LstClientesRutas.SelectedItem), IIf(OptPrecios(1).Value, 1, 2)
    End If

End Sub

Private Sub LstClientesRutas_DblClick()
    If LstClientesRutas.ListItems.Count <= 0 Then Exit Sub
    If MsgBox("Está seguro que deseas Agregar la Lista de Precios " & LstLista1.SelectedItem & " - " & LstLista1.SelectedItem.ListSubItems(1) & " ? ", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    If LstListasPrecios.ListItems.Count > 0 Then
        MsgBox "¡ No puedes Asignar más de una lista al Cliente o Ruta !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    ' Alta de Lista a Cliente o Ruta
    StrCmd = "execute up_AsignaListas " & CLng(LstCedis1.SelectedItem) & ", " & CLng(LstLista1.SelectedItem) & ", " & CLng(LstClientesRutas.SelectedItem) & ", " & CLng(LstClientesRutas.SelectedItem) & ", " & IIf(OptPrecios(1).Value, 1, 2) & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MuestraListasAsignadas CLng(LstCedis1.SelectedItem), CLng(LstLista1.SelectedItem), CLng(LstClientesRutas.SelectedItem), IIf(OptPrecios(1).Value, 1, 2)
    MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title
    Exit Sub
End Sub

Private Sub LstClientesRutas_KeyDown(KeyCode As Integer, Shift As Integer)
    LstClientesRutas_Click
End Sub

Private Sub LstClientesRutas_KeyPress(KeyAscii As Integer)
    LstClientesRutas_Click
End Sub

Private Sub LstClientesRutas_KeyUp(KeyCode As Integer, Shift As Integer)
    LstClientesRutas_Click
End Sub

Private Sub LstLista1_Click()
    LstLista1_DblClick
End Sub

Private Sub LstLista1_DblClick()
On Error Resume Next

    TxtListaPrecio.Text = ""
    TxtListaPrecio.Text = LstLista1.ListItems(LstLista1.SelectedItem.Index).SubItems(1)
End Sub

Private Sub LstListasCedis_Click()
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
    LstDCadena = GetDataLVL(Rs, LstPrecProd, 0, 2, "1|0|0")
    
End Sub

Private Sub LstListasPrecio_Click()
    LstListasPrecio_DblClick
End Sub

Private Sub LstListasPrecio_DblClick()

On Error Resume Next

    TxtIdLista.Text = LstListasPrecio.ListItems(LstListasPrecio.SelectedItem.Index).Text
    TxtLista.Text = LstListasPrecio.ListItems(LstListasPrecio.SelectedItem.Index).SubItems(1)
    CboTipoLista.Text = LstListasPrecio.ListItems(LstListasPrecio.SelectedItem.Index).SubItems(2)
    Nuevo = False
End Sub

Private Sub LstListasPrecios_DblClick()
Dim Op, Base As Boolean

Base = False
If OptPrecios(0).Value Then Op = 0
If OptPrecios(1).Value Then Op = 1
If OptPrecios(2).Value Then Op = 2

On Error Resume Next
    
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

Private Sub OptPrecios_Click(Index As Integer)
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
    LstClientesRutas.ListItems.Clear
    LstDClientesRutas = Empty
End Sub

Private Sub TxtIdLista_Validate(Cancel As Boolean)
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
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtPrecio_GotFocus()
    SelText TxtPrecio
End Sub

Private Sub TxtPrecio_KeyPress(KeyAscii As Integer)

On Error GoTo Err_Precios:

Dim Lista As Integer
If KeyAscii = 13 Then
    
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
    
    StrCmd = "execute up_Precios " & Trim(IdLista) & ", " & CLng(TxtIdProd.Text) & ", " & CDbl(TxtPrecio.Text) & "," & Opc
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn

    StrCmd = "execute sel_PreciosDetalle  " & PCedis & ", " & IdLista & ""
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCadena = GetDataLVL(Rs, LstPrecProd, 0, 2, "1|0|0")
    
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
    If Opc = 1 Then
        StrCmd = "execute sel_Clientes " & IdCed
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        LstDClientesRutas = GetDataLVL(Rs, LstClientesRutas, 0, 2, "0|0|0")
    Else
        StrCmd = "execute sel_Rutas " & IdCed
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
            LstDCadena = GetDataLVL(Rs, LstListasPrecios, 1, 5, "0|0|0|0|0")
        Case 1
            StrCmd = "execute sel_CedisLista " & Cedi & ", 0, " & IdCte & ", " & IdRut & ", " & Opc
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            LstDCadena = GetDataLVL(Rs, LstListasPrecios, 1, 5, "0|0|0|0|0")
        Case 2
            StrCmd = "execute sel_CedisLista " & Cedi & ", 0, " & IdCte & ", " & IdRut & ", " & Opc
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            LstDCadena = GetDataLVL(Rs, LstListasPrecios, 1, 5, "0|0|0|0|0")
    End Select
    
End Sub

