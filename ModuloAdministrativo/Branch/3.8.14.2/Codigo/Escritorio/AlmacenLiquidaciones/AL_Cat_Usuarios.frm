VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form AL_Cat_Usuarios 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   7950
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   11190
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
   ScaleHeight     =   7950
   ScaleWidth      =   11190
   ShowInTaskbar   =   0   'False
   Begin TabDlg.SSTab SSTab 
      Height          =   7695
      Left            =   120
      TabIndex        =   14
      Top             =   120
      Width           =   10935
      _ExtentX        =   19288
      _ExtentY        =   13573
      _Version        =   393216
      TabsPerRow      =   4
      TabHeight       =   520
      BackColor       =   16777215
      TabCaption(0)   =   "Usuarios"
      TabPicture(0)   =   "AL_Cat_Usuarios.frx":0000
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "LblOpt(3)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "FrmOpt(2)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "Almacén, Liquidaciones"
      TabPicture(1)   =   "AL_Cat_Usuarios.frx":001C
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "FrmOpt(1)"
      Tab(1).Control(1)=   "LblOpt(4)"
      Tab(1).ControlCount=   2
      TabCaption(2)   =   "KPI´s Web"
      TabPicture(2)   =   "AL_Cat_Usuarios.frx":0038
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "FrmOpt(3)"
      Tab(2).Control(1)=   "LblOpt(5)"
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
         Height          =   7620
         Index           =   3
         Left            =   -75000
         TabIndex        =   53
         Top             =   320
         Width           =   10935
         Begin VB.CommandButton btnUsuariosCedis 
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
            Picture         =   "AL_Cat_Usuarios.frx":0054
            Style           =   1  'Graphical
            TabIndex        =   59
            Top             =   6480
            Width           =   1695
         End
         Begin MSComctlLib.ListView LstUsuariosCedis 
            Height          =   4815
            Left            =   240
            TabIndex        =   57
            Top             =   1440
            Width           =   7335
            _ExtentX        =   12938
            _ExtentY        =   8493
            View            =   3
            LabelEdit       =   1
            MultiSelect     =   -1  'True
            LabelWrap       =   -1  'True
            HideSelection   =   0   'False
            Checkboxes      =   -1  'True
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
         Begin VB.Label Label2 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cedis Asignados"
            Height          =   240
            Left            =   480
            TabIndex        =   58
            Top             =   1080
            Width           =   1470
         End
         Begin VB.Line Line3 
            X1              =   120
            X2              =   10750
            Y1              =   720
            Y2              =   720
         End
         Begin VB.Label LblLogin 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Usuario"
            ForeColor       =   &H000000C0&
            Height          =   240
            Index           =   2
            Left            =   360
            TabIndex        =   54
            Top             =   360
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
         Height          =   7620
         Index           =   1
         Left            =   -75000
         TabIndex        =   46
         Top             =   320
         Width           =   10935
         Begin VB.CommandButton btnEliminaP 
            BackColor       =   &H00FFFFFF&
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   12
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   330
            Left            =   5880
            Picture         =   "AL_Cat_Usuarios.frx":09EA
            Style           =   1  'Graphical
            TabIndex        =   13
            Top             =   2520
            Width           =   1215
         End
         Begin VB.CommandButton btnAgregaP 
            BackColor       =   &H00FFFFFF&
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   12
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   330
            Left            =   2640
            Picture         =   "AL_Cat_Usuarios.frx":0F85
            Style           =   1  'Graphical
            TabIndex        =   11
            Top             =   2520
            Width           =   1455
         End
         Begin MSComctlLib.ListView LstModulos 
            Height          =   4455
            Left            =   5640
            TabIndex        =   12
            Top             =   2880
            Width           =   5055
            _ExtentX        =   8916
            _ExtentY        =   7858
            View            =   3
            LabelEdit       =   1
            MultiSelect     =   -1  'True
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
         Begin MSComctlLib.ListView LstModulosNoAsignados 
            Height          =   4455
            Left            =   240
            TabIndex        =   10
            Top             =   2880
            Width           =   4935
            _ExtentX        =   8705
            _ExtentY        =   7858
            View            =   3
            LabelEdit       =   1
            MultiSelect     =   -1  'True
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
         Begin MSComctlLib.ListView LstModulosG 
            Height          =   1455
            Left            =   240
            TabIndex        =   9
            Top             =   960
            Width           =   4935
            _ExtentX        =   8705
            _ExtentY        =   2566
            View            =   3
            LabelEdit       =   1
            MultiSelect     =   -1  'True
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
         Begin VB.Label LblLogin 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Usuario"
            ForeColor       =   &H000000C0&
            Height          =   240
            Index           =   1
            Left            =   360
            TabIndex        =   49
            Top             =   360
            Width           =   660
         End
         Begin VB.Line Line1 
            X1              =   120
            X2              =   10750
            Y1              =   720
            Y2              =   720
         End
         Begin VB.Label Label3 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Módulos NO Asignados"
            Height          =   240
            Left            =   480
            TabIndex        =   48
            Top             =   2520
            Width           =   2055
         End
         Begin VB.Label Label4 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Módulos Asignados"
            Height          =   240
            Left            =   7320
            TabIndex        =   47
            Top             =   2520
            Width           =   1710
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
         Height          =   7380
         Index           =   2
         Left            =   0
         TabIndex        =   36
         Top             =   320
         Width           =   10935
         Begin VB.ComboBox cmbCedis 
            Height          =   360
            Left            =   240
            Style           =   2  'Dropdown List
            TabIndex        =   0
            Top             =   480
            Width           =   3135
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
            Left            =   7200
            Picture         =   "AL_Cat_Usuarios.frx":1594
            Style           =   1  'Graphical
            TabIndex        =   52
            Top             =   6720
            Visible         =   0   'False
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
            Left            =   9000
            Picture         =   "AL_Cat_Usuarios.frx":1CA4
            Style           =   1  'Graphical
            TabIndex        =   51
            Top             =   6720
            Visible         =   0   'False
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
            Left            =   360
            Picture         =   "AL_Cat_Usuarios.frx":23BF
            Style           =   1  'Graphical
            TabIndex        =   7
            Top             =   6720
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
            Left            =   2160
            Picture         =   "AL_Cat_Usuarios.frx":2A4D
            Style           =   1  'Graphical
            TabIndex        =   8
            Top             =   6720
            Width           =   1695
         End
         Begin VB.TextBox TxtLogin 
            Height          =   375
            Left            =   3480
            Locked          =   -1  'True
            MaxLength       =   20
            TabIndex        =   1
            Top             =   480
            Width           =   2295
         End
         Begin VB.ComboBox CmbTipoUsuario 
            Height          =   360
            Left            =   8280
            Style           =   2  'Dropdown List
            TabIndex        =   6
            Top             =   1200
            Width           =   2295
         End
         Begin VB.TextBox TxtPassword 
            Height          =   375
            IMEMode         =   3  'DISABLE
            Left            =   6000
            MaxLength       =   10
            PasswordChar    =   "*"
            TabIndex        =   2
            Top             =   480
            Width           =   1215
         End
         Begin VB.TextBox TxtNombre 
            Height          =   375
            Left            =   240
            TabIndex        =   3
            Top             =   1200
            Width           =   3135
         End
         Begin VB.TextBox TxtApPaterno 
            Height          =   375
            Left            =   3480
            TabIndex        =   4
            Top             =   1200
            Width           =   2295
         End
         Begin VB.TextBox TxtApMaterno 
            Height          =   375
            Left            =   5880
            TabIndex        =   5
            Top             =   1200
            Width           =   2295
         End
         Begin MSComctlLib.ListView LstUsuarios 
            Height          =   4695
            Left            =   240
            TabIndex        =   37
            Top             =   1800
            Width           =   10455
            _ExtentX        =   18441
            _ExtentY        =   8281
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
         Begin VB.Label Label1 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cedis"
            Height          =   255
            Left            =   240
            TabIndex        =   56
            Top             =   240
            Width           =   2295
         End
         Begin VB.Label LblEdicion 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Consulta"
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
            Height          =   255
            Left            =   4080
            TabIndex        =   45
            Top             =   6840
            Width           =   2295
         End
         Begin VB.Label Label8 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Status"
            Height          =   240
            Left            =   8280
            TabIndex        =   43
            Top             =   960
            Width           =   570
         End
         Begin VB.Label Label9 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Contraseña"
            Height          =   255
            Left            =   6000
            TabIndex        =   42
            Top             =   240
            Width           =   1215
         End
         Begin VB.Label Label11 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Nombre de Usuario"
            Height          =   240
            Left            =   3480
            TabIndex        =   41
            Top             =   240
            Width           =   1665
         End
         Begin VB.Label Label12 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Nombre"
            Height          =   255
            Left            =   240
            TabIndex        =   40
            Top             =   960
            Width           =   975
         End
         Begin VB.Label Label13 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Ap. Paterno"
            Height          =   240
            Left            =   3480
            TabIndex        =   39
            Top             =   960
            Width           =   1035
         End
         Begin VB.Label Label18 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Ap. Materno"
            Height          =   240
            Left            =   5880
            TabIndex        =   38
            Top             =   960
            Width           =   1065
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
         Begin VB.Frame FrmOpc 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Tipo de Asignación"
            Height          =   735
            Left            =   120
            TabIndex        =   19
            Top             =   6840
            Visible         =   0   'False
            Width           =   12015
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
               Picture         =   "AL_Cat_Usuarios.frx":33E3
               Style           =   1  'Graphical
               TabIndex        =   23
               Top             =   240
               Visible         =   0   'False
               Width           =   855
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
               Picture         =   "AL_Cat_Usuarios.frx":3721
               Style           =   1  'Graphical
               TabIndex        =   22
               Top             =   240
               Visible         =   0   'False
               Width           =   855
            End
            Begin VB.TextBox TxtListaPrecio 
               Height          =   375
               Left            =   6240
               Locked          =   -1  'True
               TabIndex        =   21
               Top             =   360
               Visible         =   0   'False
               Width           =   3735
            End
            Begin VB.TextBox TxtCedi 
               Height          =   375
               Left            =   1320
               MaxLength       =   50
               TabIndex        =   20
               Top             =   360
               Visible         =   0   'False
               Width           =   3255
            End
            Begin VB.Label LblOpc 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Cliente / Ruta"
               Height          =   255
               Left            =   0
               TabIndex        =   25
               Top             =   480
               Visible         =   0   'False
               Width           =   1095
            End
            Begin VB.Label Label6 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Lista de Precios"
               Height          =   255
               Left            =   4680
               TabIndex        =   24
               Top             =   360
               Visible         =   0   'False
               Width           =   1455
            End
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
            TabIndex        =   18
            Top             =   240
            Value           =   -1  'True
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
            TabIndex        =   17
            Top             =   240
            Width           =   1575
         End
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
            TabIndex        =   16
            Top             =   240
            Width           =   1335
         End
         Begin MSComctlLib.ListView LstListasPrecios 
            Height          =   2775
            Left            =   240
            TabIndex        =   26
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
            TabIndex        =   27
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
            TabIndex        =   28
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
            TabIndex        =   29
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
         Begin VB.Label Label10 
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
            TabIndex        =   33
            Top             =   5400
            Width           =   12015
         End
         Begin VB.Label LblCedis 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cedis"
            Height          =   255
            Left            =   480
            TabIndex        =   32
            Top             =   3360
            Width           =   2175
         End
         Begin VB.Label Label7 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Lista de Precio"
            Height          =   255
            Left            =   360
            TabIndex        =   31
            Top             =   600
            Width           =   1575
         End
         Begin VB.Label LblOpcion 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clientes / Rutas"
            Enabled         =   0   'False
            Height          =   255
            Left            =   6480
            TabIndex        =   30
            Top             =   600
            Width           =   1575
         End
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "KPI´s Web"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   5
         Left            =   -69560
         TabIndex        =   55
         Top             =   0
         Width           =   2765
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Almacén, Liquidaciones"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   4
         Left            =   -72290
         TabIndex        =   50
         Top             =   0
         Width           =   2770
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Usuarios"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   3
         Left            =   0
         TabIndex        =   44
         Top             =   0
         Width           =   2770
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
         TabIndex        =   35
         Top             =   0
         Width           =   4130
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
         TabIndex        =   34
         Top             =   0
         Width           =   4110
      End
   End
End
Attribute VB_Name = "AL_Cat_Usuarios"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDUsuarios, LstDTipoUsuario, Opcion, Passw, lstDCedis, LstDCedisNo, Login
Dim LstDModulos, LstDModulosNO, LstDMovs, LstDMovsNO, LstDGrupoM, LstDCmbCedis, IdCedisSel, LstDUsuariosCedis

Private Sub btnActualizar_Click()
On Error GoTo Err_ActPermisos:
    If Trim(TxtLogin.Text) = "" Or Trim(TxtPassword.Text) = "" Or Trim(TxtNombre.Text) = "" Or Trim(TxtApMaterno.Text) = "" Or CmbTipoUsuario.ListIndex = 0 Then
        MsgBox "¡ Capture un Login y un Nombre para el Usuario !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Opcion = 1 Then
        TxtLogin_Validate False
    End If
    
    Passw = TxtPassword.Text
    If Opcion = 2 And Trim(TxtPassword.Text) <> "password" Then
        Passw = ""
        StrCmd = "execute up_Usuarios " & LstDUsuarios(0, LstUsuarios.SelectedItem.Index - 1) & ", '" & UCase(TxtLogin.Text) & "', '" & Trim(TxtPassword.Text) & "', '', '', '', '', 4"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If Not RsC.EOF Then
            Passw = RsC.Fields(0)
        End If
        
        If Passw = 0 Then
            Passw = IIf(MsgBox("Ha decidido cambiar la contraseña del usuario " & TxtLogin.Text & ". ¿ Desea cambiar la contraseña ?", vbQuestion + vbYesNo, App.Title) = vbNo, "", Trim(TxtPassword.Text))
        End If
    End If
        
    StrCmd = "execute up_Usuarios " & LstDUsuarios(0, LstUsuarios.SelectedItem.Index - 1) & ", '" & UCase(TxtLogin.Text) & "', '" & Passw & "', '" & UCase(TxtNombre.Text) & "', '" & UCase(TxtApPaterno.Text) & "', '" & UCase(TxtApMaterno.Text) & "', '" & IIf(CmbTipoUsuario.ListIndex = 1, "A", "B") & "', " & Opcion
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    
    MuestraUsuarios
    MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title
    LblEdicion.Caption = "Consulta"
    TxtLogin.Locked = True: Opcion = 0
    
No_Err_ActPermisos:
    MousePointer = 0
    Exit Sub
    
Err_ActPermisos:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_ActPermisos:
    
End Sub

Private Sub btnAgregaP_Click()
On Error Resume Next
    If IsEmpty(LstDModulosNO) Then Exit Sub
    
    For i = 1 To LstModulosNoAsignados.ListItems.Count
        If LstModulosNoAsignados.ListItems(i).Selected Then
            StrCmd = "execute up_UsuariosModulos " & IdCedisSel & ", '" & Login & "', '" & Trim(LstDModulosNO(0, i - 1)) & "', 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
        End If
    Next i
    
    ModulosAsignados 1
    ModulosAsignados 2
End Sub

Private Sub btnEliminaP_Click()
On Error Resume Next
    If IsEmpty(LstDModulos) Then Exit Sub
    
    For i = 1 To LstModulos.ListItems.Count
        If LstModulos.ListItems(i).Selected Then
            StrCmd = "execute up_UsuariosModulos " & IdCedisSel & ", '" & Login & "', '" & Trim(LstDModulos(0, i - 1)) & "', 2"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
        End If
    Next i
    
    ModulosAsignados 1
    ModulosAsignados 2
End Sub

Private Sub btnNuevo_Click()
On Error Resume Next
    Opcion = 1: LblEdicion.Caption = "Nuevo"
    TxtLogin.Locked = False
    TxtLogin.Text = "": TxtPassword.Text = "": TxtNombre.Text = "": TxtApPaterno.Text = "": TxtApMaterno.Text = "": CmbTipoUsuario.ListIndex = 0
    TxtLogin.SetFocus
End Sub

Private Sub btnUsuariosCedis_Click()
On Error Resume Next
Dim TodosCedis As Boolean
    
    TodosCedis = True
    For i = 1 To LstUsuariosCedis.ListItems.Count
        If Not LstUsuariosCedis.ListItems(i).Checked Then TodosCedis = False
    Next i

    If TodosCedis Then
        StrCmd = "execute up_UsuariosCedis '" & Login & "', 0, 2"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
    Else
        For i = 1 To LstUsuariosCedis.ListItems.Count
            If LstUsuariosCedis.ListItems(i).Checked Then
                StrCmd = "execute up_UsuariosCedis '" & Login & "', " & LstUsuariosCedis.ListItems(i) & ", 1"
                If RsC.State Then RsC.Close
                RsC.Open StrCmd, Cnn
            End If
        Next i
    End If
    
    MuestraUsuariosCedis
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title

End Sub

Private Sub cmbCedis_Click()
On Error Resume Next
    If IdCedisSel <> LstDCmbCedis(0, cmbCedis.ListIndex - 1) Then
        IdCedisSel = LstDCmbCedis(0, cmbCedis.ListIndex - 1)
        SSTab_Click 0
    End If
End Sub

Private Sub Form_Load()
On Error Resume Next
    Opcion = 0
    SSTab.Tab = 0
    IdCedisSel = 0
    LlenaCedis
End Sub

Sub LlenaCedis()
On Error Resume Next
    StrCmd = "execute sel_Cedis "
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    RsC.MoveFirst
    LstDCmbCedis = GetDataCBL(RsC, cmbCedis, "Seleccione un Cedis", "No existen Cedis")
End Sub

Private Sub LstModulosG_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    ModulosAsignados 1
    ModulosAsignados 2

End Sub

Private Sub LstUsuarios_Click()
On Error Resume Next
    TxtLogin.Locked = True: LblEdicion.Caption = "Consulta"
    TxtLogin.Text = UCase(LstDUsuarios(1, LstUsuarios.SelectedItem.Index - 1))
    TxtPassword.Text = "password": Passw = LstDUsuarios(6, LstUsuarios.SelectedItem.Index - 1)
    TxtNombre.Text = UCase(LstDUsuarios(2, LstUsuarios.SelectedItem.Index - 1))
    TxtApPaterno.Text = UCase(LstDUsuarios(3, LstUsuarios.SelectedItem.Index - 1))
    TxtApMaterno.Text = UCase(LstDUsuarios(4, LstUsuarios.SelectedItem.Index - 1))
    CmbTipoUsuario.ListIndex = IIf(UCase(LstDUsuarios(7, LstUsuarios.SelectedItem.Index - 1)) = "ACTIVO", 1, 2)
    Login = Trim(TxtLogin.Text)
    LblLogin(1).Caption = LstDUsuarios(1, LstUsuarios.SelectedItem.Index - 1) & " - " & LstDUsuarios(3, LstUsuarios.SelectedItem.Index - 1) & " " & LstDUsuarios(4, LstUsuarios.SelectedItem.Index - 1) & " " & LstDUsuarios(2, LstUsuarios.SelectedItem.Index - 1)
    LblLogin(2).Caption = LstDUsuarios(1, LstUsuarios.SelectedItem.Index - 1) & " - " & LstDUsuarios(3, LstUsuarios.SelectedItem.Index - 1) & " " & LstDUsuarios(4, LstUsuarios.SelectedItem.Index - 1) & " " & LstDUsuarios(2, LstUsuarios.SelectedItem.Index - 1)
End Sub

Private Sub LstUsuarios_DblClick()
On Error Resume Next
    Opcion = 2: LblEdicion.Caption = "Modificar"
End Sub

Private Sub LstUsuarios_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstUsuarios_Click
End Sub

Private Sub SSTab_Click(PreviousTab As Integer)
On Error Resume Next
    If SSTab.Tab > 0 Then
        If IsEmpty(LstDUsuarios) Then
            SSTab.Tab = 0: SSTab_Click 0
            Exit Sub
        Else
            LblLogin(1).Caption = LstUsuarios.SelectedItem & " - " & LstUsuarios.SelectedItem.ListSubItems(2) & " " & LstUsuarios.SelectedItem.ListSubItems(3) & " " & LstUsuarios.SelectedItem.ListSubItems(4)
            LblLogin(2).Caption = LstUsuarios.SelectedItem & " - " & LstUsuarios.SelectedItem.ListSubItems(2) & " " & LstUsuarios.SelectedItem.ListSubItems(3) & " " & LstUsuarios.SelectedItem.ListSubItems(4)
            Login = LstUsuarios.SelectedItem
        End If
    End If
    
    Select Case SSTab.Tab
        Case 0:
            MuestraUsuarios
            LlenaComboUsuarios
        Case 1:
            MuestraGruposM
        Case 2:
            MuestraUsuariosCedis
                
    End Select
End Sub

Private Sub TxtApMaterno_GotFocus()
On Error Resume Next
    SelText TxtApMaterno
End Sub

Private Sub TxtApMaterno_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtApPaterno_GotFocus()
On Error Resume Next
    SelText TxtApPaterno
End Sub

Private Sub TxtApPaterno_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtLogin_GotFocus()
On Error Resume Next
    SelText TxtLogin
End Sub

Private Sub TxtLogin_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtLogin_Validate(Cancel As Boolean)
On Error Resume Next
    If Opcion = 1 Then
        StrCmd = "execute sel_Usuarios " & IdCedisSel & ", '" & Trim(TxtLogin.Text) & "', 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        
        If Trim(TxtLogin.Text) = "" Then
            MsgBox "¡ Teclee Nombre de Usuario ! ", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If Not RsC.EOF Then
            If RsC.Fields(0) <> "" Then
                MsgBox "¡ El Nombre de Usuario que tecleó ya existe !. Seleccione otro Nombre de Usuario. ", vbInformation + vbOKOnly, App.Title
                TxtLogin.Text = "": TxtLogin.SetFocus
                Exit Sub
            End If
        Else
            Exit Sub
        End If
    End If
End Sub

Private Sub TxtNombre_GotFocus()
On Error Resume Next
    SelText TxtNombre
End Sub

Private Sub TxtNombre_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtPassword_GotFocus()
On Error Resume Next
    SelText TxtPassword
End Sub

Sub MuestraUsuarios()
On Error Resume Next
    StrCmd = "execute sel_Usuarios " & IdCedisSel & ",'', 0"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDUsuarios = GetDataLVL(RsC, LstUsuarios, 1, 4, "0|0|0|0")
End Sub

Sub LlenaComboUsuarios()
On Error Resume Next
    ReDim LstDTipoUsuario(1, 1)
    CmbTipoUsuario.Clear
    
    LstDTipoUsuario(0, 0) = "Activo"
    LstDTipoUsuario(1, 0) = "1"
    LstDTipoUsuario(0, 1) = "Baja"
    LstDTipoUsuario(1, 1) = "0"

    CmbTipoUsuario.AddItem "<Status>"
    CmbTipoUsuario.ItemData(CmbTipoUsuario.NewIndex) = "0"
    
    CmbTipoUsuario.AddItem LstDTipoUsuario(0, 0)
    CmbTipoUsuario.ItemData(CmbTipoUsuario.NewIndex) = LstDTipoUsuario(1, 0)
    CmbTipoUsuario.AddItem LstDTipoUsuario(0, 1)
    CmbTipoUsuario.ItemData(CmbTipoUsuario.NewIndex) = LstDTipoUsuario(1, 1)
   
    CmbTipoUsuario.ListIndex = 0
End Sub

Sub MuestraGruposM()
On Error Resume Next
    
    StrCmd = "execute sel_Modulos " & IdCedisSel & ", '', '', 5"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDGrupoM = GetDataLVL(Rs, LstModulosG, 1, 1, "0|0")
    LstModulosG_ItemClick LstModulosG.ListItems(1)
End Sub

Sub MuestraUsuariosCedis()
On Error Resume Next
Dim TodosCedis As Boolean
    
    StrCmd = "execute sel_UsuariosCedis '" & Login & "', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDUsuariosCedis = GetDataLVL(Rs, LstUsuariosCedis, 0, 2, "0|0|0")
    TodosCedis = True
    For i = 1 To LstUsuariosCedis.ListItems.Count
        LstUsuariosCedis.ListItems(i).Checked = IIf(Trim(LstDUsuariosCedis(3, i - 1)) <> "", True, False)
        If Trim(LstDUsuariosCedis(3, i - 1)) <> "" Then TodosCedis = False
    Next i
    
    If TodosCedis Then
        For i = 1 To LstUsuariosCedis.ListItems.Count
            LstUsuariosCedis.ListItems(i).Checked = True
        Next i
    End If
End Sub

Sub ModulosAsignados(Opc As Integer) ' 1 , 2
On Error Resume Next
    
    StrCmd = "execute sel_Modulos " & IdCedisSel & ", '" & Login & "', '" & LstDGrupoM(0, LstModulosG.SelectedItem.Index - 1) & "', " & IIf(Trim(LstDGrupoM(0, LstModulosG.SelectedItem.Index - 1)) = "", Opc, Opc + 2)
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    Select Case Opc
        Case 1:
            LstDModulos = GetDataLVL(Rs, LstModulos, 1, 1, "0|0")
        Case 2:
            LstDModulosNO = GetDataLVL(Rs, LstModulosNoAsignados, 1, 1, "0|0")
    End Select
End Sub

