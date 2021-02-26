VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form CC_Cat_Usuarios 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   8145
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
   ScaleHeight     =   8145
   ScaleWidth      =   11190
   ShowInTaskbar   =   0   'False
   Begin TabDlg.SSTab SSTab 
      Height          =   7935
      Left            =   120
      TabIndex        =   10
      Top             =   120
      Width           =   10935
      _ExtentX        =   19288
      _ExtentY        =   13996
      _Version        =   393216
      Tabs            =   4
      TabsPerRow      =   4
      TabHeight       =   520
      BackColor       =   16777215
      TabCaption(0)   =   "Usuarios"
      TabPicture(0)   =   "CC_Cat_Usuarios.frx":0000
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "LblOpt(3)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "FrmOpt(2)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "Cedis"
      TabPicture(1)   =   "CC_Cat_Usuarios.frx":001C
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "FrmOpt(0)"
      Tab(1).Control(0).Enabled=   0   'False
      Tab(1).Control(1)=   "LblOpt(1)"
      Tab(1).Control(1).Enabled=   0   'False
      Tab(1).ControlCount=   2
      TabCaption(2)   =   "Modulos"
      TabPicture(2)   =   "CC_Cat_Usuarios.frx":0038
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "FrmOpt(1)"
      Tab(2).Control(0).Enabled=   0   'False
      Tab(2).Control(1)=   "LblOpt(4)"
      Tab(2).Control(1).Enabled=   0   'False
      Tab(2).ControlCount=   2
      TabCaption(3)   =   "Movimientos"
      TabPicture(3)   =   "CC_Cat_Usuarios.frx":0054
      Tab(3).ControlEnabled=   0   'False
      Tab(3).Control(0)=   "FrmOpt(3)"
      Tab(3).Control(0).Enabled=   0   'False
      Tab(3).Control(1)=   "LblOpt(5)"
      Tab(3).Control(1).Enabled=   0   'False
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
         Height          =   7620
         Index           =   3
         Left            =   -75000
         TabIndex        =   50
         Top             =   320
         Width           =   10935
         Begin MSComctlLib.ListView LstMovs 
            Height          =   6015
            Left            =   5640
            TabIndex        =   58
            Top             =   1320
            Width           =   5055
            _ExtentX        =   8916
            _ExtentY        =   10610
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
         Begin MSComctlLib.ListView LstMovsNoAsignados 
            Height          =   6015
            Left            =   240
            TabIndex        =   59
            Top             =   1320
            Width           =   5055
            _ExtentX        =   8916
            _ExtentY        =   10610
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
         Begin VB.Label Label14 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Movimientos Asignados"
            Height          =   240
            Left            =   6120
            TabIndex        =   61
            Top             =   960
            Width           =   2055
         End
         Begin VB.Label Label5 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Movimientos NO Asignados"
            Height          =   240
            Left            =   480
            TabIndex        =   60
            Top             =   960
            Width           =   2400
         End
         Begin VB.Label LblLogin 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Usuario"
            ForeColor       =   &H000000C0&
            Height          =   240
            Index           =   2
            Left            =   360
            TabIndex        =   51
            Top             =   360
            Width           =   660
         End
         Begin VB.Line Line2 
            X1              =   120
            X2              =   10750
            Y1              =   720
            Y2              =   720
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
         TabIndex        =   48
         Top             =   320
         Width           =   10935
         Begin MSComctlLib.ListView LstModulos 
            Height          =   6015
            Left            =   5640
            TabIndex        =   54
            Top             =   1320
            Width           =   5055
            _ExtentX        =   8916
            _ExtentY        =   10610
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
         Begin MSComctlLib.ListView LstModulosNoAsignados 
            Height          =   6015
            Left            =   240
            TabIndex        =   55
            Top             =   1320
            Width           =   5055
            _ExtentX        =   8916
            _ExtentY        =   10610
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
         Begin VB.Label Label4 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Módulos Asignados"
            Height          =   240
            Left            =   6120
            TabIndex        =   57
            Top             =   960
            Width           =   1710
         End
         Begin VB.Label Label3 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Módulos NO Asignados"
            Height          =   240
            Left            =   480
            TabIndex        =   56
            Top             =   960
            Width           =   2055
         End
         Begin VB.Line Line1 
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
            Index           =   1
            Left            =   360
            TabIndex        =   49
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
         Index           =   0
         Left            =   -75000
         TabIndex        =   44
         Top             =   320
         Width           =   10935
         Begin MSComctlLib.ListView LstCedis 
            Height          =   6015
            Left            =   5640
            TabIndex        =   45
            Top             =   1320
            Width           =   5055
            _ExtentX        =   8916
            _ExtentY        =   10610
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
         Begin MSComctlLib.ListView LstCedisNoAsignados 
            Height          =   6015
            Left            =   240
            TabIndex        =   47
            Top             =   1320
            Width           =   5055
            _ExtentX        =   8916
            _ExtentY        =   10610
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
         Begin VB.Label Label2 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cedis NO Asignados"
            Height          =   240
            Left            =   480
            TabIndex        =   53
            Top             =   960
            Width           =   1815
         End
         Begin VB.Label Label1 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cedis Asignados"
            Height          =   240
            Left            =   6120
            TabIndex        =   52
            Top             =   960
            Width           =   1470
         End
         Begin VB.Label LblLogin 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Usuario"
            ForeColor       =   &H000000C0&
            Height          =   240
            Index           =   0
            Left            =   360
            TabIndex        =   46
            Top             =   360
            Width           =   660
         End
         Begin VB.Line Line3 
            X1              =   120
            X2              =   10750
            Y1              =   720
            Y2              =   720
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
         Index           =   2
         Left            =   0
         TabIndex        =   33
         Top             =   320
         Width           =   10935
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
            Left            =   5160
            Picture         =   "CC_Cat_Usuarios.frx":0070
            Style           =   1  'Graphical
            TabIndex        =   8
            Top             =   6960
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
            Left            =   6960
            Picture         =   "CC_Cat_Usuarios.frx":0780
            Style           =   1  'Graphical
            TabIndex        =   9
            Top             =   6960
            Visible         =   0   'False
            Width           =   1575
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
            Picture         =   "CC_Cat_Usuarios.frx":0E9B
            Style           =   1  'Graphical
            TabIndex        =   6
            Top             =   6960
            Width           =   1575
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
            Left            =   2040
            Picture         =   "CC_Cat_Usuarios.frx":1529
            Style           =   1  'Graphical
            TabIndex        =   7
            Top             =   6960
            Width           =   1575
         End
         Begin VB.TextBox TxtLogin 
            Height          =   375
            Left            =   240
            Locked          =   -1  'True
            MaxLength       =   20
            TabIndex        =   0
            Top             =   480
            Width           =   2295
         End
         Begin VB.ComboBox CmbTipoUsuario 
            Height          =   360
            Left            =   8280
            Style           =   2  'Dropdown List
            TabIndex        =   5
            Top             =   1200
            Width           =   2295
         End
         Begin VB.TextBox TxtPassword 
            Height          =   375
            IMEMode         =   3  'DISABLE
            Left            =   2760
            MaxLength       =   10
            PasswordChar    =   "*"
            TabIndex        =   1
            Top             =   480
            Width           =   1215
         End
         Begin VB.TextBox TxtNombre 
            Height          =   375
            Left            =   240
            TabIndex        =   2
            Top             =   1200
            Width           =   3135
         End
         Begin VB.TextBox TxtApPaterno 
            Height          =   375
            Left            =   3480
            TabIndex        =   3
            Top             =   1200
            Width           =   2295
         End
         Begin VB.TextBox TxtApMaterno 
            Height          =   375
            Left            =   5880
            TabIndex        =   4
            Top             =   1200
            Width           =   2295
         End
         Begin MSComctlLib.ListView LstUsuarios 
            Height          =   5055
            Left            =   240
            TabIndex        =   34
            Top             =   1800
            Width           =   10455
            _ExtentX        =   18441
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
         Begin VB.Label LblEdicion 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Consulta"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000080&
            Height          =   255
            Left            =   3840
            TabIndex        =   62
            Top             =   7080
            Width           =   2295
         End
         Begin VB.Label Label8 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Status"
            Height          =   240
            Left            =   8280
            TabIndex        =   40
            Top             =   960
            Width           =   570
         End
         Begin VB.Label Label9 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Contraseña"
            Height          =   255
            Left            =   2760
            TabIndex        =   39
            Top             =   240
            Width           =   1215
         End
         Begin VB.Label Label11 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Nombre de Usuario"
            Height          =   240
            Left            =   240
            TabIndex        =   38
            Top             =   240
            Width           =   1665
         End
         Begin VB.Label Label12 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Nombre"
            Height          =   255
            Left            =   240
            TabIndex        =   37
            Top             =   960
            Width           =   975
         End
         Begin VB.Label Label13 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Ap. Paterno"
            Height          =   240
            Left            =   3480
            TabIndex        =   36
            Top             =   960
            Width           =   1035
         End
         Begin VB.Label Label18 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Ap. Materno"
            Height          =   240
            Left            =   5880
            TabIndex        =   35
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
         TabIndex        =   11
         Top             =   320
         Width           =   12375
         Begin VB.Frame FrmOpc 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Tipo de Asignación"
            Height          =   735
            Left            =   120
            TabIndex        =   15
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
               Picture         =   "CC_Cat_Usuarios.frx":1EBF
               Style           =   1  'Graphical
               TabIndex        =   19
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
               Picture         =   "CC_Cat_Usuarios.frx":21FD
               Style           =   1  'Graphical
               TabIndex        =   18
               Top             =   240
               Visible         =   0   'False
               Width           =   855
            End
            Begin VB.TextBox TxtListaPrecio 
               Height          =   375
               Left            =   6240
               Locked          =   -1  'True
               TabIndex        =   17
               Top             =   360
               Visible         =   0   'False
               Width           =   3735
            End
            Begin VB.TextBox TxtCedi 
               Height          =   375
               Left            =   1320
               MaxLength       =   50
               TabIndex        =   16
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
               TabIndex        =   21
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
               TabIndex        =   20
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
            TabIndex        =   14
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
            TabIndex        =   13
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
            TabIndex        =   12
            Top             =   240
            Width           =   1335
         End
         Begin MSComctlLib.ListView LstListasPrecios 
            Height          =   2775
            Left            =   240
            TabIndex        =   22
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
            TabIndex        =   23
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
            TabIndex        =   24
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
            TabIndex        =   25
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
            TabIndex        =   29
            Top             =   5400
            Width           =   12015
         End
         Begin VB.Label LblCedis 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cedis"
            Height          =   255
            Left            =   480
            TabIndex        =   28
            Top             =   3360
            Width           =   2175
         End
         Begin VB.Label Label7 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Lista de Precio"
            Height          =   255
            Left            =   360
            TabIndex        =   27
            Top             =   600
            Width           =   1575
         End
         Begin VB.Label LblOpcion 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clientes / Rutas"
            Enabled         =   0   'False
            Height          =   255
            Left            =   6480
            TabIndex        =   26
            Top             =   600
            Width           =   1575
         End
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Movimientos"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   5
         Left            =   -66840
         TabIndex        =   43
         Top             =   0
         Width           =   2775
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Módulos"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   4
         Left            =   -69550
         TabIndex        =   42
         Top             =   0
         Width           =   2775
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
         TabIndex        =   41
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
         TabIndex        =   32
         Top             =   0
         Width           =   4130
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Cedis"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   1
         Left            =   -72300
         TabIndex        =   31
         Top             =   0
         Width           =   2770
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
         TabIndex        =   30
         Top             =   0
         Width           =   4110
      End
   End
End
Attribute VB_Name = "CC_Cat_Usuarios"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDUsuarios, LstDTipoUsuario, Opcion, Passw, lstDCedis, LstDCedisNo, Login
Dim LstDModulos, LstDModulosNO, LstDMovs, LstDMovsNO

Private Sub btnActualizar_Click()
On Error Resume Next
    If Trim(TxtLogin.Text) = "" Or Trim(TxtPassword.Text) = "" Or Trim(TxtNombre.Text) = "" Or Trim(TxtApMaterno.Text) = "" Or CmbTipoUsuario.ListIndex = 0 Then
        MsgBox "¡ Capture todos los datos solicitados !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Opcion = 1 Then Passw = ""
    
    If Passw <> Trim(TxtPassword.Text) And Opcion = 2 And Trim(TxtPassword.Text) <> "password" Then
        If MsgBox("Ha decidido cambiar la contraseña del usuario " & TxtLogin.Text & ". ¿ Desea continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    End If
        
    StrCmd = "execute up_Usuarios 999, '" & UCase(TxtLogin.Text) & "', '" & UCase(IIf(Trim(TxtPassword.Text) <> "password", Trim(TxtPassword.Text), Passw)) & "', '" & UCase(TxtNombre.Text) & "', '" & UCase(TxtApPaterno.Text) & "', '" & UCase(TxtApMaterno.Text) & "', '" & IIf(CmbTipoUsuario.ListIndex = 1, "A", "B") & "', " & Opcion
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    
    MuestraUsuarios
    MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title
    LblEdicion.Caption = "Consulta"
    TxtLogin.Locked = True: Opcion = 0
End Sub

Private Sub btnEliminar_Click()
On Error Resume Next

    If MsgBox("¿ Está seguro que desea dar de Baja al usuario " & TxtLogin.Text & " ? ", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub

    StrCmd = "execute up_Usuarios " & IdCedis & ", '" & TxtLogin.Text & "', '', '', '', '', 0, 3 "
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn

    MuestraUsuarios
    MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title
    TxtLogin.Locked = True: Opcion = 0
    TxtLogin.Text = "": TxtPassword.Text = "": TxtNombre.Text = "": TxtApPaterno.Text = "": TxtApMaterno.Text = "": CmbTipoUsuario.ListIndex = 0
End Sub

Private Sub btnImprimir_Click()
On Error Resume Next
    With cc_rptUsuarios
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
        .LblCedis.Caption = Format(IdCedis, "00") & " - " & NomCedis
        
        StrCmd = "execute sel_Usuarios " & IdCedis & ", '', 0"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        
        If Not RsC.EOF Then
            .object.DataSrc.DataSourceName = Cnn
            .object.DataSrc.Recordset = RsC
        End If
        
        .Printer.Orientation = ddOPortrait
        .Printer.PaperSize = 1
        .Show
    End With
End Sub

Private Sub btnNuevo_Click()
On Error Resume Next
    Opcion = 1: LblEdicion.Caption = "Nuevo"
    TxtLogin.Locked = False
    TxtLogin.Text = "": TxtPassword.Text = "": TxtNombre.Text = "": TxtApPaterno.Text = "": TxtApMaterno.Text = "": CmbTipoUsuario.ListIndex = 0
    TxtLogin.SetFocus
End Sub

Private Sub Form_Load()
On Error Resume Next
    Opcion = 0
    SSTab.Tab = 0
    SSTab_Click 0
End Sub

Private Sub LstCedis_DblClick()
On Error Resume Next
    If IsEmpty(lstDCedis) Then Exit Sub
    
    If MsgBox("¿ Está seguro que deseas QUITAR el Cedis " & LstCedis.SelectedItem.ListSubItems(1) & " al usuario ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
        StrCmd = "execute up_UsuariosCedis '" & Login & "', " & CLng(LstCedis.SelectedItem) & ", 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        CedisAsignados 1
        CedisAsignados 3
        'MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title
    End If
End Sub

Private Sub LstCedisNoAsignados_DblClick()
On Error Resume Next
    If IsEmpty(LstDCedisNo) Then Exit Sub

    If MsgBox("¿ Está seguro que deseas AGREGAR el Cedis " & LstCedisNoAsignados.SelectedItem.ListSubItems(1) & " al usuario ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
        StrCmd = "execute up_UsuariosCedis '" & Login & "', " & CLng(LstCedisNoAsignados.SelectedItem) & ", 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        CedisAsignados 1
        CedisAsignados 3
        'MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title
    End If
End Sub

Private Sub LstModulos_DblClick()
On Error Resume Next
    If IsEmpty(LstDModulos) Then Exit Sub
    
    If MsgBox("¿ Está seguro que deseas QUITAR el Módulo " & LstModulos.SelectedItem.ListSubItems(1) & " al usuario ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
        StrCmd = "execute up_UsuariosModulos '" & Login & "', '" & Trim(LstModulos.SelectedItem) & "', 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        ModulosAsignados 1
        ModulosAsignados 2
        'MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title
    End If
End Sub

Private Sub LstModulosNoAsignados_DblClick()
On Error Resume Next
    If IsEmpty(LstDModulosNO) Then Exit Sub

    If MsgBox("¿ Está seguro que deseas AGREGAR el Módulo " & LstModulosNoAsignados.SelectedItem.ListSubItems(1) & " al usuario ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
        StrCmd = "execute up_UsuariosModulos '" & Login & "', '" & Trim(LstModulosNoAsignados.SelectedItem) & "', 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        ModulosAsignados 1
        ModulosAsignados 2
        'MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title
    End If
End Sub

Private Sub LstMovs_DblClick()
On Error Resume Next
    If IsEmpty(LstDMovs) Then Exit Sub
    
    If MsgBox("¿ Está seguro que deseas QUITAR el Movimiento " & LstMovs.SelectedItem.ListSubItems(1) & " al usuario ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
        StrCmd = "execute up_UsuariosDocumentos '" & Login & "', '" & Trim(LstMovs.SelectedItem) & "', '" & LstMovs.SelectedItem.ListSubItems(2) & "', 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        ModulosAsignados 3
        ModulosAsignados 4
        'MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title
    End If
End Sub

Private Sub LstMovsNoAsignados_DblClick()
On Error Resume Next
    If IsEmpty(LstDMovsNO) Then Exit Sub

    If MsgBox("¿ Está seguro que deseas AGREGAR el Movimiento " & LstMovsNoAsignados.SelectedItem.ListSubItems(1) & " al usuario ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
        StrCmd = "execute up_UsuariosDocumentos '" & Login & "', '" & Trim(LstMovsNoAsignados.SelectedItem) & "', '" & LstMovsNoAsignados.SelectedItem.ListSubItems(2) & "',  1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        ModulosAsignados 3
        ModulosAsignados 4
        'MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title
    End If
End Sub

Private Sub LstUsuarios_Click()
On Error Resume Next
    TxtLogin.Locked = True: LblEdicion.Caption = "Consulta"
    TxtLogin.Text = UCase(LstDUsuarios(1, LstUsuarios.SelectedItem.Index - 1))
    TxtPassword.Text = "password": Passw = LstDUsuarios(7, LstUsuarios.SelectedItem.Index - 1)
    TxtNombre.Text = UCase(LstDUsuarios(3, LstUsuarios.SelectedItem.Index - 1))
    TxtApPaterno.Text = UCase(LstDUsuarios(4, LstUsuarios.SelectedItem.Index - 1))
    TxtApMaterno.Text = UCase(LstDUsuarios(5, LstUsuarios.SelectedItem.Index - 1))
    CmbTipoUsuario.ListIndex = IIf(UCase(LstDUsuarios(2, LstUsuarios.SelectedItem.Index - 1)) = "ACTIVO", 1, 2)
    Login = Trim(TxtLogin.Text)
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
            LblLogin(0).Caption = LstUsuarios.SelectedItem & " - " & LstUsuarios.SelectedItem.ListSubItems(2) & " " & LstUsuarios.SelectedItem.ListSubItems(3) & " " & LstUsuarios.SelectedItem.ListSubItems(4)
            LblLogin(2).Caption = LblLogin(0).Caption
            LblLogin(1).Caption = LblLogin(0).Caption
            Login = LstUsuarios.SelectedItem
        End If
    End If
    
    Select Case SSTab.Tab
        Case 0:
            MuestraUsuarios
            LlenaComboUsuarios
        Case 1:
            CedisAsignados 1
            CedisAsignados 3
            
        Case 2:
            ModulosAsignados 1
            ModulosAsignados 2
            
        Case 3:
            ModulosAsignados 3
            ModulosAsignados 4

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
        StrCmd = "execute sel_Usuarios '" & Trim(TxtLogin.Text) & "', 1"
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
    StrCmd = "execute sel_Usuarios '', 0"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDUsuarios = GetDataLVL(RsC, LstUsuarios, 1, 5, "0|0|0|0|0")
End Sub

Sub LlenaComboUsuarios()
On Error Resume Next
    ReDim LstDTipoUsuario(1, 1)
    CmbTipoUsuario.Clear
    
    LstDTipoUsuario(0, 0) = "ACTIVO"
    LstDTipoUsuario(1, 0) = "1"
    LstDTipoUsuario(0, 1) = "BAJA"
    LstDTipoUsuario(1, 1) = "0"

    CmbTipoUsuario.AddItem "<Status>"
    CmbTipoUsuario.ItemData(CmbTipoUsuario.NewIndex) = "0"
    
    CmbTipoUsuario.AddItem LstDTipoUsuario(0, 0)
    CmbTipoUsuario.ItemData(CmbTipoUsuario.NewIndex) = LstDTipoUsuario(1, 0)
    CmbTipoUsuario.AddItem LstDTipoUsuario(0, 1)
    CmbTipoUsuario.ItemData(CmbTipoUsuario.NewIndex) = LstDTipoUsuario(1, 1)
   
    CmbTipoUsuario.ListIndex = 0
End Sub

Sub CedisAsignados(Opc As Integer)
On Error Resume Next
    
    StrCmd = "execute sel_CedisUsuarios '" & Login & "', " & Opc
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Opc = 1 Then
        lstDCedis = GetDataLVL(Rs, LstCedis, 1, 2, "0|0")
    Else
        LstDCedisNo = GetDataLVL(Rs, LstCedisNoAsignados, 1, 2, "0|0")
    End If
    
End Sub

Sub ModulosAsignados(Opc As Integer) ' 1 , 2
On Error Resume Next
    StrCmd = "execute sel_Modulos '" & Login & "', " & Opc
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    Select Case Opc
        Case 1:
            LstDModulos = GetDataLVL(Rs, LstModulos, 0, 1, "0|0")
        Case 2:
            LstDModulosNO = GetDataLVL(Rs, LstModulosNoAsignados, 0, 1, "0|0")
        Case 3:
            LstDMovs = GetDataLVL(Rs, LstMovs, 0, 2, "0|0|0")
        Case 4:
            LstDMovsNO = GetDataLVL(Rs, LstMovsNoAsignados, 0, 2, "0|0|0")
    End Select
End Sub

