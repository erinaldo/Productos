VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form CC_Promociones 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
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
      Height          =   8295
      Left            =   120
      TabIndex        =   38
      Top             =   120
      Width           =   12495
      _ExtentX        =   22040
      _ExtentY        =   14631
      _Version        =   393216
      Tabs            =   4
      TabsPerRow      =   4
      TabHeight       =   520
      BackColor       =   16777215
      TabCaption(0)   =   "Alta de Acuerdos PostVenta"
      TabPicture(0)   =   "CC_Promociones.frx":0000
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "LblOpt(3)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "FrmOpt(2)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "Cedis y Clientes"
      TabPicture(1)   =   "CC_Promociones.frx":001C
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "FrmOpt(0)"
      Tab(1).Control(1)=   "LblOpt(1)"
      Tab(1).ControlCount=   2
      TabCaption(2)   =   "Familias y Productos"
      TabPicture(2)   =   "CC_Promociones.frx":0038
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "FrmOpt(1)"
      Tab(2).Control(1)=   "LblOpt(4)"
      Tab(2).ControlCount=   2
      TabCaption(3)   =   "Aplicar Acuerdos PostVenta"
      TabPicture(3)   =   "CC_Promociones.frx":0054
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
         Height          =   7980
         Index           =   3
         Left            =   -75000
         TabIndex        =   74
         Top             =   320
         Width           =   12495
         Begin VB.Frame Frame2 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Periodo para buscar Facturas y Aplicar Acuerdo"
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
            Left            =   7320
            TabIndex        =   97
            Top             =   240
            Width           =   4695
            Begin VB.CommandButton btnArchivo 
               BackColor       =   &H00FFFFFF&
               Height          =   495
               Left            =   480
               Picture         =   "CC_Promociones.frx":0070
               Style           =   1  'Graphical
               TabIndex        =   104
               Top             =   2520
               Width           =   1815
            End
            Begin VB.CommandButton btnCancelarPromocion 
               BackColor       =   &H00FFFFFF&
               Height          =   495
               Left            =   2400
               Picture         =   "CC_Promociones.frx":0707
               Style           =   1  'Graphical
               TabIndex        =   103
               Top             =   2520
               Width           =   1815
            End
            Begin MSComCtl2.DTPicker DTPPeriodo 
               Height          =   345
               Index           =   2
               Left            =   240
               TabIndex        =   41
               Top             =   600
               Width           =   4260
               _ExtentX        =   7514
               _ExtentY        =   609
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
               CustomFormat    =   "dddd, dd 'de' MMMM 'de' yyyy"
               Format          =   125501443
               CurrentDate     =   38914
            End
            Begin MSComCtl2.DTPicker DTPPeriodo 
               Height          =   345
               Index           =   3
               Left            =   240
               TabIndex        =   42
               Top             =   1320
               Width           =   4260
               _ExtentX        =   7514
               _ExtentY        =   609
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
               CustomFormat    =   "dddd, dd 'de' MMMM 'de' yyyy"
               Format          =   125501443
               CurrentDate     =   38914
            End
            Begin MSComCtl2.DTPicker DTPPeriodo 
               Height          =   345
               Index           =   4
               Left            =   240
               TabIndex        =   43
               Top             =   2040
               Width           =   4260
               _ExtentX        =   7514
               _ExtentY        =   609
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
               CustomFormat    =   "dddd, dd 'de' MMMM 'de' yyyy"
               Format          =   125501443
               CurrentDate     =   38914
            End
            Begin VB.Label Label25 
               AutoSize        =   -1  'True
               BackStyle       =   0  'Transparent
               Caption         =   "Fecha de los Movimientos"
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
               Left            =   360
               TabIndex        =   102
               Top             =   1800
               Width           =   2475
            End
            Begin VB.Label Label22 
               AutoSize        =   -1  'True
               BackStyle       =   0  'Transparent
               Caption         =   "Del"
               Height          =   240
               Left            =   360
               TabIndex        =   99
               Top             =   360
               Width           =   285
            End
            Begin VB.Label Label23 
               AutoSize        =   -1  'True
               BackStyle       =   0  'Transparent
               Caption         =   "Al"
               Height          =   240
               Left            =   360
               TabIndex        =   98
               Top             =   1080
               Width           =   180
            End
         End
         Begin MSComctlLib.ListView LstPromocionesAplicadas 
            Height          =   4335
            Left            =   120
            TabIndex        =   44
            Top             =   3480
            Width           =   12255
            _ExtentX        =   21616
            _ExtentY        =   7646
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
         Begin MSComctlLib.ListView LstPromocionesVigentes 
            Height          =   2295
            Left            =   120
            TabIndex        =   40
            Top             =   720
            Width           =   6975
            _ExtentX        =   12303
            _ExtentY        =   4048
            View            =   3
            LabelEdit       =   1
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
         Begin VB.Label Label5 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Acuerdos Vigentes"
            Height          =   240
            Left            =   480
            TabIndex        =   88
            Top             =   360
            Width           =   1650
         End
         Begin VB.Label Label14 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Acuerdos Aplicados"
            Height          =   240
            Left            =   360
            TabIndex        =   79
            Top             =   3120
            Width           =   1740
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
         Height          =   7980
         Index           =   1
         Left            =   -75000
         TabIndex        =   72
         Top             =   320
         Width           =   12495
         Begin VB.CheckBox ChkDelFamilias 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Todos"
            Height          =   360
            Left            =   8160
            TabIndex        =   29
            Top             =   960
            Width           =   855
         End
         Begin VB.CommandButton btnDelFamilias 
            BackColor       =   &H00FFFFFF&
            Caption         =   "<<-"
            Height          =   375
            Left            =   7200
            Style           =   1  'Graphical
            TabIndex        =   28
            Top             =   960
            Width           =   735
         End
         Begin VB.CommandButton btnDelProductos 
            BackColor       =   &H00FFFFFF&
            Caption         =   "<<-"
            Height          =   375
            Left            =   7320
            Style           =   1  'Graphical
            TabIndex        =   35
            Top             =   3480
            Width           =   735
         End
         Begin VB.CheckBox ChkDelProductos 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Todos"
            Height          =   360
            Left            =   8280
            TabIndex        =   36
            Top             =   3480
            Width           =   855
         End
         Begin VB.CommandButton btnAddProductos 
            BackColor       =   &H00FFFFFF&
            Caption         =   "->>"
            Height          =   375
            Left            =   5520
            Style           =   1  'Graphical
            TabIndex        =   33
            Top             =   3480
            Width           =   735
         End
         Begin VB.CheckBox ChkAddProductos 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Todos"
            Height          =   360
            Left            =   4560
            TabIndex        =   32
            Top             =   3480
            Width           =   855
         End
         Begin VB.CommandButton btnAddFamilias 
            BackColor       =   &H00FFFFFF&
            Caption         =   "->>"
            Height          =   375
            Left            =   5520
            Style           =   1  'Graphical
            TabIndex        =   26
            Top             =   960
            Width           =   735
         End
         Begin VB.CheckBox ChkAddFamilias 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Todos"
            Height          =   360
            Left            =   4560
            TabIndex        =   25
            Top             =   960
            Width           =   855
         End
         Begin VB.TextBox TxtPorcP 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   3600
            MaxLength       =   20
            TabIndex        =   31
            Text            =   "0.00"
            Top             =   3360
            Width           =   615
         End
         Begin VB.TextBox TxtPorcF 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   3600
            MaxLength       =   20
            TabIndex        =   24
            Text            =   "0.00"
            Top             =   840
            Width           =   615
         End
         Begin MSComctlLib.ListView LstProductos 
            Height          =   3975
            Left            =   6480
            TabIndex        =   37
            Top             =   3840
            Width           =   5775
            _ExtentX        =   10186
            _ExtentY        =   7011
            View            =   3
            LabelEdit       =   1
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
         Begin MSComctlLib.ListView LstFamiliasNo 
            Height          =   1935
            Left            =   120
            TabIndex        =   27
            Top             =   1320
            Width           =   6255
            _ExtentX        =   11033
            _ExtentY        =   3413
            View            =   3
            LabelEdit       =   1
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
         Begin MSComctlLib.ListView LstProductosNo 
            Height          =   3975
            Left            =   120
            TabIndex        =   34
            Top             =   3840
            Width           =   6255
            _ExtentX        =   11033
            _ExtentY        =   7011
            View            =   3
            LabelEdit       =   1
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
         Begin MSComctlLib.ListView LstFamilias 
            Height          =   1935
            Left            =   6480
            TabIndex        =   30
            Top             =   1320
            Width           =   5775
            _ExtentX        =   10186
            _ExtentY        =   3413
            View            =   3
            LabelEdit       =   1
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
         Begin VB.Label Label8 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Familias Asignadas"
            Height          =   240
            Left            =   9720
            TabIndex        =   101
            Top             =   960
            Width           =   1710
         End
         Begin VB.Label Label24 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Porc."
            Height          =   240
            Left            =   3000
            TabIndex        =   100
            Top             =   960
            Width           =   465
         End
         Begin VB.Label Label26 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Porc."
            Height          =   240
            Left            =   3000
            TabIndex        =   96
            Top             =   3480
            Width           =   465
         End
         Begin VB.Label Label19 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Productos NO Asignados"
            Height          =   240
            Left            =   480
            TabIndex        =   83
            Top             =   3480
            Width           =   2205
         End
         Begin VB.Label Label4 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Productos Asignados"
            Height          =   240
            Left            =   9840
            TabIndex        =   78
            Top             =   3480
            Width           =   1860
         End
         Begin VB.Label Label3 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Familias NO Asignadas"
            Height          =   240
            Left            =   360
            TabIndex        =   77
            Top             =   960
            Width           =   2055
         End
         Begin VB.Line Line1 
            X1              =   120
            X2              =   12360
            Y1              =   720
            Y2              =   720
         End
         Begin VB.Label LblPromo 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Promocion"
            ForeColor       =   &H000000C0&
            Height          =   240
            Index           =   1
            Left            =   360
            TabIndex        =   73
            Top             =   360
            Width           =   930
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
         Height          =   7980
         Index           =   0
         Left            =   -75000
         TabIndex        =   70
         Top             =   320
         Width           =   12495
         Begin MSComctlLib.ListView LstClientesNo 
            Height          =   3855
            Left            =   120
            TabIndex        =   17
            Top             =   3960
            Width           =   6135
            _ExtentX        =   10821
            _ExtentY        =   6800
            View            =   3
            LabelEdit       =   1
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
         Begin VB.CommandButton btnDelClientes 
            BackColor       =   &H00FFFFFF&
            Caption         =   "<<-"
            Height          =   375
            Left            =   7320
            Style           =   1  'Graphical
            TabIndex        =   21
            Top             =   3600
            Width           =   735
         End
         Begin VB.CheckBox ChkDelClientes 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Todos"
            Height          =   360
            Left            =   8280
            TabIndex        =   22
            Top             =   3600
            Width           =   855
         End
         Begin VB.CommandButton btnAddClientes 
            BackColor       =   &H00FFFFFF&
            Caption         =   "->>"
            Height          =   375
            Left            =   4920
            Style           =   1  'Graphical
            TabIndex        =   16
            Top             =   3600
            Width           =   735
         End
         Begin VB.CheckBox ChkAddClientes 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Todos"
            Height          =   360
            Left            =   3960
            TabIndex        =   15
            Top             =   3600
            Width           =   855
         End
         Begin VB.CommandButton btnDelCedis 
            BackColor       =   &H00FFFFFF&
            Caption         =   "<<-"
            Height          =   375
            Left            =   7200
            Style           =   1  'Graphical
            TabIndex        =   18
            Top             =   960
            Width           =   735
         End
         Begin VB.CheckBox ChkDelCedis 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Todos"
            Height          =   360
            Left            =   8160
            TabIndex        =   19
            Top             =   960
            Width           =   855
         End
         Begin VB.CommandButton btnAddCedis 
            BackColor       =   &H00FFFFFF&
            Caption         =   "->>"
            Height          =   375
            Left            =   3600
            Style           =   1  'Graphical
            TabIndex        =   13
            Top             =   960
            Width           =   735
         End
         Begin VB.CheckBox ChkAddCedis 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Todos"
            Height          =   360
            Left            =   2640
            TabIndex        =   12
            Top             =   960
            Width           =   855
         End
         Begin VB.TextBox TxtIdCliente 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   240
            TabIndex        =   85
            Top             =   4080
            Visible         =   0   'False
            Width           =   975
         End
         Begin VB.TextBox TxtRazonSocial 
            Height          =   375
            Left            =   1320
            TabIndex        =   84
            Top             =   4080
            Visible         =   0   'False
            Width           =   2295
         End
         Begin MSComctlLib.ListView LstCedis 
            Height          =   2175
            Left            =   6480
            TabIndex        =   20
            Top             =   1320
            Width           =   5775
            _ExtentX        =   10186
            _ExtentY        =   3836
            View            =   3
            LabelEdit       =   1
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
         Begin MSComctlLib.ListView LstCedisNo 
            Height          =   2175
            Left            =   120
            TabIndex        =   14
            Top             =   1320
            Width           =   6135
            _ExtentX        =   10821
            _ExtentY        =   3836
            View            =   3
            LabelEdit       =   1
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
         Begin MSComctlLib.ListView LstClientes 
            Height          =   3855
            Left            =   6480
            TabIndex        =   23
            Top             =   3960
            Width           =   5775
            _ExtentX        =   10186
            _ExtentY        =   6800
            View            =   3
            LabelEdit       =   1
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
         Begin VB.Label Label20 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "No. Cliente"
            Height          =   240
            Left            =   240
            TabIndex        =   87
            Top             =   3960
            Visible         =   0   'False
            Width           =   960
         End
         Begin VB.Label Label21 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Razón Social"
            Height          =   255
            Left            =   1320
            TabIndex        =   86
            Top             =   3960
            Visible         =   0   'False
            Width           =   1695
         End
         Begin VB.Label Label18 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clientes Asignados"
            Height          =   240
            Left            =   9960
            TabIndex        =   82
            Top             =   3600
            Width           =   1680
         End
         Begin VB.Label Label17 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clientes NO Asignados"
            Height          =   240
            Left            =   480
            TabIndex        =   81
            Top             =   3600
            Width           =   2025
         End
         Begin VB.Label Label2 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cedis NO Asignados"
            Height          =   240
            Left            =   480
            TabIndex        =   76
            Top             =   960
            Width           =   1815
         End
         Begin VB.Label Label1 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cedis Asignados"
            Height          =   240
            Left            =   10080
            TabIndex        =   75
            Top             =   960
            Width           =   1470
         End
         Begin VB.Label LblPromo 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Promocion"
            ForeColor       =   &H000000C0&
            Height          =   240
            Index           =   0
            Left            =   360
            TabIndex        =   71
            Top             =   360
            Width           =   930
         End
         Begin VB.Line Line3 
            X1              =   120
            X2              =   12360
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
         Height          =   7980
         Index           =   2
         Left            =   0
         TabIndex        =   66
         Top             =   320
         Width           =   12495
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
            Left            =   1920
            Picture         =   "CC_Promociones.frx":0E42
            Style           =   1  'Graphical
            TabIndex        =   109
            Top             =   7080
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
            Left            =   240
            Picture         =   "CC_Promociones.frx":17D8
            Style           =   1  'Graphical
            TabIndex        =   108
            Top             =   7080
            Width           =   1575
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
            Picture         =   "CC_Promociones.frx":1E66
            Style           =   1  'Graphical
            TabIndex        =   107
            Top             =   7080
            Width           =   1575
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
            Left            =   5280
            Picture         =   "CC_Promociones.frx":2581
            Style           =   1  'Graphical
            TabIndex        =   106
            Top             =   7080
            Width           =   1575
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
            Left            =   3600
            Picture         =   "CC_Promociones.frx":2C91
            Style           =   1  'Graphical
            TabIndex        =   105
            Top             =   7080
            Width           =   1575
         End
         Begin VB.OptionButton OptConsulta 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Acuerdos en el Periodo seleccionado"
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
            Index           =   2
            Left            =   5520
            TabIndex        =   10
            Top             =   2760
            Visible         =   0   'False
            Width           =   3975
         End
         Begin VB.OptionButton OptConsulta 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Acuerdos Vigentes"
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
            Index           =   1
            Left            =   2880
            TabIndex        =   9
            Top             =   2760
            Width           =   2295
         End
         Begin VB.OptionButton OptConsulta 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Todos los Acuerdos"
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
            Index           =   0
            Left            =   240
            TabIndex        =   8
            Top             =   2760
            Value           =   -1  'True
            Width           =   2535
         End
         Begin VB.Frame Frame1 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Datos Generales del Acuerdo"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   2415
            Left            =   120
            TabIndex        =   89
            Top             =   240
            Width           =   12255
            Begin VB.CheckBox ChkFechaFinal 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Fecha Final"
               Height          =   255
               Left            =   4680
               TabIndex        =   4
               Top             =   960
               Value           =   1  'Checked
               Width           =   2055
            End
            Begin VB.TextBox TxtObservaciones 
               Height          =   375
               Left            =   5520
               TabIndex        =   2
               Top             =   480
               Width           =   6495
            End
            Begin VB.TextBox TxtNombre 
               Height          =   375
               Left            =   1320
               TabIndex        =   1
               Top             =   480
               Width           =   4095
            End
            Begin VB.TextBox TxtId 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   120
               Locked          =   -1  'True
               MaxLength       =   20
               TabIndex        =   0
               Top             =   480
               Width           =   1095
            End
            Begin VB.ComboBox CmbDocumento 
               Height          =   360
               Left            =   120
               Style           =   2  'Dropdown List
               TabIndex        =   6
               Top             =   1920
               Width           =   4335
            End
            Begin VB.ComboBox CmbTipoDocumento 
               Height          =   360
               Left            =   4680
               Style           =   2  'Dropdown List
               TabIndex        =   7
               Top             =   1920
               Width           =   4335
            End
            Begin MSComCtl2.DTPicker DTPPeriodo 
               Height          =   345
               Index           =   0
               Left            =   120
               TabIndex        =   3
               Top             =   1200
               Width           =   4260
               _ExtentX        =   7514
               _ExtentY        =   609
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
               CustomFormat    =   "dddd, dd 'de' MMMM 'de' yyyy"
               Format          =   125501443
               CurrentDate     =   38914
            End
            Begin MSComCtl2.DTPicker DTPPeriodo 
               Height          =   345
               Index           =   1
               Left            =   4680
               TabIndex        =   5
               Top             =   1200
               Width           =   4260
               _ExtentX        =   7514
               _ExtentY        =   609
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
               CustomFormat    =   "dddd, dd 'de' MMMM 'de' yyyy"
               Format          =   125501443
               CurrentDate     =   38914
            End
            Begin VB.Label Label13 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Observaciones"
               Height          =   240
               Left            =   5640
               TabIndex        =   95
               Top             =   240
               Width           =   1275
            End
            Begin VB.Label Label12 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Nombre"
               Height          =   255
               Left            =   1440
               TabIndex        =   94
               Top             =   240
               Width           =   975
            End
            Begin VB.Label Label11 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Clave"
               Height          =   240
               Left            =   240
               TabIndex        =   93
               Top             =   240
               Width           =   465
            End
            Begin VB.Label Label9 
               AutoSize        =   -1  'True
               BackStyle       =   0  'Transparent
               Caption         =   "Fecha Inicial"
               Height          =   240
               Left            =   240
               TabIndex        =   92
               Top             =   960
               Width           =   1095
            End
            Begin VB.Label Label15 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Documento"
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
               TabIndex        =   91
               Top             =   1680
               Width           =   960
            End
            Begin VB.Label Label16 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Tipo de Documento"
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
               Left            =   4800
               TabIndex        =   90
               Top             =   1680
               Width           =   1620
            End
         End
         Begin MSComctlLib.ListView LstPromociones 
            Height          =   3735
            Left            =   120
            TabIndex        =   11
            Top             =   3120
            Width           =   12255
            _ExtentX        =   21616
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
            ForeColor       =   &H000000C0&
            Height          =   255
            Left            =   8880
            TabIndex        =   80
            Top             =   7200
            Width           =   2295
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
         TabIndex        =   39
         Top             =   320
         Width           =   12375
         Begin VB.Frame FrmOpc 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Tipo de Asignación"
            Height          =   735
            Left            =   120
            TabIndex        =   48
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
               Picture         =   "CC_Promociones.frx":3328
               Style           =   1  'Graphical
               TabIndex        =   52
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
               Picture         =   "CC_Promociones.frx":3666
               Style           =   1  'Graphical
               TabIndex        =   51
               Top             =   240
               Visible         =   0   'False
               Width           =   855
            End
            Begin VB.TextBox TxtListaPrecio 
               Height          =   375
               Left            =   6240
               Locked          =   -1  'True
               TabIndex        =   50
               Top             =   360
               Visible         =   0   'False
               Width           =   3735
            End
            Begin VB.TextBox TxtCedi 
               Height          =   375
               Left            =   1320
               MaxLength       =   50
               TabIndex        =   49
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
               TabIndex        =   54
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
               TabIndex        =   53
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
            TabIndex        =   47
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
            TabIndex        =   46
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
            TabIndex        =   45
            Top             =   240
            Width           =   1335
         End
         Begin MSComctlLib.ListView LstListasPrecios 
            Height          =   2775
            Left            =   240
            TabIndex        =   55
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
            TabIndex        =   56
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
            TabIndex        =   57
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
            TabIndex        =   58
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
            TabIndex        =   62
            Top             =   5400
            Width           =   12015
         End
         Begin VB.Label LblCedis 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cedis"
            Height          =   255
            Left            =   480
            TabIndex        =   61
            Top             =   3360
            Width           =   2175
         End
         Begin VB.Label Label7 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Lista de Precio"
            Height          =   255
            Left            =   360
            TabIndex        =   60
            Top             =   600
            Width           =   1575
         End
         Begin VB.Label LblOpcion 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clientes / Rutas"
            Enabled         =   0   'False
            Height          =   255
            Left            =   6480
            TabIndex        =   59
            Top             =   600
            Width           =   1575
         End
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Aplicar Acuerdos PostVenta"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   5
         Left            =   -65640
         TabIndex        =   69
         Top             =   0
         Width           =   3135
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Familias y Productos"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   4
         Left            =   -68835
         TabIndex        =   68
         Top             =   0
         Width           =   3255
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Alta de Acuerdos PostVenta"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   3
         Left            =   0
         TabIndex        =   67
         Top             =   0
         Width           =   3135
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
         TabIndex        =   65
         Top             =   0
         Width           =   4130
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Cedis y Clientes"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   1
         Left            =   -71940
         TabIndex        =   64
         Top             =   0
         Width           =   3255
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
         TabIndex        =   63
         Top             =   0
         Width           =   4110
      End
   End
End
Attribute VB_Name = "CC_Promociones"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDDocumento, lstDCedis, LstDPromociones, LstDTipoDocumento, LstDCedisNo, LstDClientesNo, LstDClientes
Dim LstDProductos, LstDProductosNo, LstDFamilias, LstDFamiliasNo, LstDPromocionesAplicadas, LstDPromocionesVigentes
Dim IdPromocion, Baja As Boolean, StrCedis, strClientes, strFamilias, strProductos, IdAplicacion, FechaPromo As Date

Private Sub btnActualizar_Click()
    On Error GoTo Err_Promo:
    
    If Trim(TxtNombre.Text) = "" Then
        MsgBox "¡ Teclea un Nombre para la Promoción !", vbInformation + vbOKOnly, App.Title
        MousePointer = 0
        Exit Sub
    End If
    
    If DTPPeriodo(0).Value > DTPPeriodo(1).Value And DTPPeriodo(1).Value <> "01/01/1900" Then
        MsgBox "¡ La Fecha Inicial debe ser menor o igual a la Fecha Final de la Promoción !", vbInformation + vbOKOnly, App.Title
        MousePointer = 0
        Exit Sub
    End If
            
    If IsEmpty(LstDDocumento) Or CmbDocumento.ListIndex = 0 Or IsEmpty(LstDTipoDocumento) Or CmbTipoDocumento.ListIndex = 0 Then
        MsgBox "¡ Seleccione un Documento y un Tipo de Documento para la Promoción !", vbInformation + vbOKOnly, App.Title
        MousePointer = 0
        Exit Sub
    End If
            
    MousePointer = 11
    
    If LblEdicion.Caption <> "Consulta" Then
        ' Obtiene el Nuevo Folio de Promoción
        StrCmd = " select isnull( max(IdPromocion)+ 1, 1) from Promociones "
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If RsC.EOF Then
            MousePointer = 0
            MsgBox "¡ No se encontró un nuevo Folio de Promoción !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        Else
            IdPromocion = RsC.Fields(0)
        End If
        
        ' inserta el movimiento...
        StrCmd = "execute up_Promociones " & IdPromocion & ", '" & Trim(UCase(TxtNombre.Text)) & "', '" & Trim(UCase(TxtObservaciones.Text)) & "', '" & IIf(BIdioma = "us_english", Format(DTPPeriodo(0).Value, "mm/dd/yyyy"), Format(DTPPeriodo(0).Value, "dd/mm/yyyy")) & "', '" & IIf(BIdioma = "us_english", Format(DTPPeriodo(1).Value, "mm/dd/yyyy"), Format(DTPPeriodo(1).Value, "dd/mm/yyyy")) & "', '" & Trim(LstDDocumento(0, CmbDocumento.ListIndex - 1)) & "', '" & Trim(LstDTipoDocumento(2, CmbTipoDocumento.ListIndex - 1)) & "', 'A', 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
    Else

        If UCase(Mid(LstPromociones.SelectedItem.ListSubItems(4), 1, 1)) = "B" Then
            MousePointer = 0
            MsgBox "¡ No se puede modificar una Promoción dada de Baja o Aplicada !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        ' actualiza datos
        StrCmd = "execute up_Promociones " & IdPromocion & ", '" & Trim(UCase(TxtNombre.Text)) & "', '" & Trim(UCase(TxtObservaciones.Text)) & "', '01/01/1900', '" & IIf(BIdioma = "us_english", Format(DTPPeriodo(1).Value, "mm/dd/yyyy"), Format(DTPPeriodo(1).Value, "dd/mm/yyyy")) & "', '', '', 'A', 2"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        
    End If
    
    MuestraPromociones
    MousePointer = 0
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title

    
No_Err_Promo:
    MousePointer = 0
    LblEdicion.Caption = "Consulta"
    Exit Sub
    
Err_Promo:
    MousePointer = 0
    MsgBox "Error al tratar de actualizar. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_Promo:
End Sub

Private Sub btnAddCedis_Click()
    On Error Resume Next
        
    If Baja Then
        MsgBox "¡ No puedes modificar una Promoción dada de Baja o Aplicada !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
        
    StrCedis = strIds(LstCedisNo, 0)
    StrCmd = "execute up_PromocionesCedis " & IdPromocion & ", '" & StrCedis & "', 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    MuestraCedis
    
End Sub

Private Sub btnAddClientes_Click()
    On Error Resume Next
        
    If Baja Then
        MsgBox "¡ No puedes modificar una Promoción dada de Baja o Aplicada !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
        
    strClientes = strIdsCompuesto(LstClientesNo, 0, 1, " IdCedis ", " IdCliente ")
    StrCmd = "execute up_PromocionesClientes " & IdPromocion & ", '" & strClientes & "', 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    MuestraClientes

End Sub

Private Sub btnAddFamilias_Click()
    On Error Resume Next
        
    If Baja Then
        MsgBox "¡ No puedes modificar una Promoción dada de Baja o Aplicada !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    If CDbl(TxtPorcF.Text) = 0 Then
        MsgBox "¡ Debes teclear un Porcentaje a Aplicar !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
        
    strFamilias = strIds(LstFamiliasNo, 0)
    StrCmd = "execute up_PromocionesProductos " & IdPromocion & ", '" & strFamilias & "', '', " & CDbl(TxtPorcF.Text) / 100 & ", 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    MuestraProductos

End Sub

Private Sub btnAddProductos_Click()
    On Error Resume Next
        
    If Baja Then
        MsgBox "¡ No puedes modificar una Promoción dada de Baja o Aplicada !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    If CDbl(TxtPorcP.Text) = 0 Then
        MsgBox "¡ Debes teclear un Porcentaje a Aplicar !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
        
    strProductos = strIds(LstProductosNo, 2)
    StrCmd = "execute up_PromocionesProductos " & IdPromocion & ", '', '" & strProductos & "', " & CDbl(TxtPorcP.Text) / 100 & ", 2"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    MuestraProductos

End Sub

Private Sub btnAplica_Click()
    On Error GoTo Err_AplicaPromo:
        
    If UCase(Mid(LstPromociones.SelectedItem.ListSubItems(4), 1, 1)) <> "A" Then
        MousePointer = 0
        MsgBox "¡ No se puede modificar una Promoción dada de Baja o Aplicada !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    'VALIDAR QUE NO FALTEN DATOS COMO CEDIS, CLIENTES, Y PRODUCTOS
    StrCmd = "execute sel_PromocionesValida " & IdPromocion & ", 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    If Not RsC.EOF Then
        If RsC.Fields(0) = 0 Then
            MousePointer = 0
            MsgBox "¡ Capture los Cedis, los Clientes y los Productos de la Promoción !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
    Else
        MousePointer = 0
        MsgBox "¡ Capture los Cedis, los Clientes y los Productos de la Promoción !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
        
    If MsgBox("¿ Estás seguro que deseas Aplicar la Promoción ?. " & Chr(13) & Chr(10) & "Al Aplicar la Promoción, ya no se podrán hacer cambios sobre la misma.", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        
    ' actualiza datos
    StrCmd = "execute up_Promociones " & IdPromocion & ", '', '', '01/01/1900', '01/01/1900', '', '', 'G', 3"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
        
    MuestraPromociones
    MousePointer = 0
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title

    
No_Err_AplicaPromo:
    MousePointer = 0
    LblEdicion.Caption = "Consulta"
    Exit Sub
    
Err_AplicaPromo:
    MousePointer = 0
    MsgBox "Error al tratar de actualizar. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_AplicaPromo:


End Sub

Private Sub btnArchivo_Click()
Dim strPromociones, DPromociones, Insertado As Boolean, Mensj, CargoA, LstIdMovs, IdDocumento, IdTipoDocumento, LstCedisPromo

On Error GoTo Err_AplicaPromocion:

    If MsgBox("¡ Al Aplicar una Promoción, se afectan Facturas de varios Cedis !. ¿ Desea continuar con el Proceso ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub

    strPromociones = strIds(LstPromocionesVigentes, 0)
   
    If Trim(strPromociones) = "" Then
        MsgBox "¡ Seleccione las Promociones a Aplicar !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    MousePointer = 11
    DPromociones = Split(strPromociones, ",")
    For i = 0 To UBound(DPromociones)
        Insertado = True
    
        'Nuevo Id de Aplciación de Promoción
        StrCmd = " select isnull( max(IdAplicacion)+ 1, 1) from PromocionesAplicadas where IdPromocion = " & DPromociones(i)
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If RsC.EOF Then
            MousePointer = 0
            MsgBox "¡ No se encontró un nuevo Folio de Aplicación de Promoción !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        Else
            IdAplicacion = RsC.Fields(0)
        End If
        
        'Inserto Registro de Aplicación
        StrCmd = "execute up_PromocionesAplicadas " & IdAplicacion & ", " & DPromociones(i) & ", '" & Usuario & "',  '" & IIf(BIdioma = "us_english", Format(DTPPeriodo(2).Value, "mm/dd/yyyy"), Format(DTPPeriodo(2).Value, "dd/mm/yyyy")) & "', '" & IIf(BIdioma = "us_english", Format(DTPPeriodo(3).Value, "mm/dd/yyyy"), Format(DTPPeriodo(3).Value, "dd/mm/yyyy")) & "', 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        
        'Obtengo Facturas a Aplicar y Lleno PromocionesAplicadasDetalle
        StrCmd = "execute up_PromocionesAplicadas " & IdAplicacion & ", " & DPromociones(i) & ", '" & Usuario & "',  '" & IIf(BIdioma = "us_english", Format(DTPPeriodo(2).Value, "mm/dd/yyyy"), Format(DTPPeriodo(2).Value, "dd/mm/yyyy")) & "', '" & IIf(BIdioma = "us_english", Format(DTPPeriodo(3).Value, "mm/dd/yyyy"), Format(DTPPeriodo(3).Value, "dd/mm/yyyy")) & "', 2"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
                        
        'validar iddoc, idtipodoc existan
        StrCmd = " select IdDocumento, CargoAbono from Documentos where Status = 'A' and IdDocumento in ( select IdDocumento from Promociones where IdPromocion = " & DPromociones(i) & ")"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If RsC.EOF Then
            Insertado = False
            Mensj = " Clave de Documento no válida ": GoTo ValidacionPTerminada:
        Else
            IdDocumento = Trim(RsC.Fields(0))
            CargoA = Trim(RsC.Fields(1))
        End If
        
        StrCmd = " select IdTipoDocumento from DocumentosTipo where Status = 'A' and IdDocumento in ( select IdDocumento from Promociones where IdPromocion = " & DPromociones(i) & ") and IdTipoDocumento in ( select IdTipoDocumento from Promociones where IdPromocion = " & DPromociones(i) & ") "
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If RsC.EOF Then
            Insertado = False
            Mensj = " Clave de Tipo de Documento no válida ": GoTo ValidacionPTerminada:
        Else
            IdTipoDocumento = Trim(RsC.Fields(0))
        End If
        
        ' Obtiene el Nuevo Documento para Asignar los Movimientos
        StrCmd = " select IdCedis from PromocionesAplicadasDetalle where IdAplicacion = " & IdAplicacion & " and IdPromocion = " & DPromociones(i) & " group by IdCedis order by IdCedis "
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        LstCedisPromo = RsC.GetRows
           
        ' marca folios con promociones anteriores...
        StrCmd = "execute up_PromocionesFoliosAplicadosAnteriormente " & IdAplicacion & ", " & DPromociones(i) & ",  1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        
        'actualiza saldo y monto -- , iddoc, idtipodoc
        StrCmd = "execute up_PromocionesAplicadas " & IdAplicacion & ", " & DPromociones(i) & ", '" & Usuario & "', '" & IIf(BIdioma = "us_english", Format(DTPPeriodo(2).Value, "mm/dd/yyyy"), Format(DTPPeriodo(2).Value, "dd/mm/yyyy")) & "', '" & IIf(BIdioma = "us_english", Format(DTPPeriodo(3).Value, "mm/dd/yyyy"), Format(DTPPeriodo(3).Value, "dd/mm/yyyy")) & "', 3"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn

        'verifico que saldo > monto promocion
        StrCmd = "execute up_PromocionesAplicadas " & IdAplicacion & ", " & DPromociones(i) & ", '" & Usuario & "', '" & IIf(BIdioma = "us_english", Format(DTPPeriodo(2).Value, "mm/dd/yyyy"), Format(DTPPeriodo(2).Value, "dd/mm/yyyy")) & "', '" & IIf(BIdioma = "us_english", Format(DTPPeriodo(3).Value, "mm/dd/yyyy"), Format(DTPPeriodo(3).Value, "dd/mm/yyyy")) & "', 4"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
           
        ' for para todos los cedis...
        ReDim LstIdMovs(1, UBound(LstCedisPromo, 2))
        For j = 0 To UBound(LstCedisPromo, 2)
            'valido periodo
            If Not ValidaPeriodo(LstCedisPromo(0, j), Year(DTPPeriodo(4).Value), Month(DTPPeriodo(4).Value), "C", "", 1) Then
                MsgBox "¡ " & StrPeriodo & " !", vbInformation + vbOKOnly, App.Title
                GoTo ValidacionPTerminada:
            End If
            
            ' obtengo nuevo id
            StrCmd = " select isnull( max(IdMovimiento)+ 1, 1) from Movimientos where IdCedis = " & LstCedisPromo(0, j)
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
            LstIdMovs(0, j) = LstCedisPromo(0, j): LstIdMovs(1, j) = RsC.Fields(0)
            
            ' inserta el movimiento...
            StrCmd = "execute up_Movimientos " & LstCedisPromo(0, j) & ", " & LstIdMovs(1, j) & ", '" & IIf(BIdioma = "us_english", Format(DTPPeriodo(4).Value, "mm/dd/yyyy"), Format(DTPPeriodo(4).Value, "dd/mm/yyyy")) & "', '" & IdDocumento & "', '" & CargoA & "', 0, '', '', 'Promoción " & DPromociones(i) & " , " & Trim(LstPromocionesVigentes.SelectedItem.ListSubItems(1)) & "', '', '" & Usuario & "', 1"
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
            
ValidacionPTerminada:
            If Insertado Then
                
                'afecta facturas q no se hayan afectado anteriormente...
                StrCmd = "execute up_PromocionesGeneraMovimientosFacturas " & IdAplicacion & ", " & DPromociones(i) & ", " & LstIdMovs(0, j) & ", '" & IIf(BIdioma = "us_english", Format(DTPPeriodo(4).Value, "mm/dd/yyyy"), Format(DTPPeriodo(4).Value, "dd/mm/yyyy")) & "', " & LstIdMovs(1, j) & ", '" & IdDocumento & "', '" & IdTipoDocumento & "', '" & CargoA & "', '" & Usuario & "', 1"
                If RsC.State Then RsC.Close
                RsC.Open StrCmd, Cnn
                
                'elimina movimiento si total =0
                StrCmd = "update Movimientos set Status = 'B' where IdMovimiento = " & LstIdMovs(1, j) & " and Monto = 0 "
                If RsC.State Then RsC.Close
                RsC.Open StrCmd, Cnn
                
            Else
                MousePointer = 0
                MsgBox "¡ No se puede Aplicar la Promoción. Mensaje:  !" & Mensj, vbInformation + vbOKCancel, App.Title
                GoTo PSiguiente:
            End If
PSiguiente:
            Next
        'cambiar status = A de promocionesaplicadas
        StrCmd = "execute up_PromocionesAplicadas " & IdAplicacion & ", " & DPromociones(i) & ", '" & Usuario & "', '01/01/1900', '01/01/1900', 5"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
     Next
     
     MousePointer = 0
     MuestraPromocionesAplicadas
     MsgBox "¡ Promociones Aplicadas !", vbInformation + vbOKOnly, App.Title

No_Err_AplicaPromocion:
    MousePointer = 0
    Exit Sub
     
Err_AplicaPromocion:
    MousePointer = 0
    MsgBox "¡ Error al tratar de Aplicar la promoción !. Error: " & Err.Description, vbInformation + vbOKCancel, App.Title
    GoTo No_Err_AplicaPromocion:
     
End Sub

Private Sub btnCancelarPromocion_Click()
On Error Resume Next
    If IsEmpty(LstDPromocionesAplicadas) Then Exit Sub
    With CC_PromocionesCancela
        .IdAplicacionC = CLng(LstPromocionesAplicadas.SelectedItem)
        .IdPromocionC = CLng(LstPromocionesAplicadas.SelectedItem.ListSubItems(1))
        .Left = Menu.Left + ((Promociones.Width - .Width) / 2)
        .Top = Menu.Height + ((Promociones.Height - .Height) / 2)
        .Show
    End With
End Sub

Private Sub btnDelCedis_Click()
    On Error Resume Next
    
    If Baja Then
        MsgBox "¡ No puedes modificar una Promoción dada de Baja o Aplicada !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    StrCedis = strIds(LstCedis, 0)
    StrCmd = "execute up_PromocionesCedis " & IdPromocion & ", '" & StrCedis & "', 2"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    MuestraCedis

End Sub

Private Sub btnDelClientes_Click()
    On Error Resume Next
        
    If Baja Then
        MsgBox "¡ No puedes modificar una Promoción dada de Baja o Aplicada !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
        
    strClientes = strIdsCompuesto(LstClientes, 0, 1, " IdCedis ", " IdCliente ")
    StrCmd = "execute up_PromocionesClientes " & IdPromocion & ", '" & strClientes & "', 2"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    MuestraClientes
    On Error GoTo Err_BajaPromo:
        
'    If MsgBox("¿ Estás seguro que deseas dar de Baja la Promoción ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
'
'    ' actualiza datos
'    StrCmd = "execute up_Promociones " & IdPromocion & ", '', '', '01/01/1900', '01/01/1900', '', '', 'B', 3"
'    If RsC.State Then RsC.Close
'    RsC.Open StrCmd, Cnn
        
    MuestraPromociones
    MousePointer = 0
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title

    
No_Err_BajaPromo:
    MousePointer = 0
    LblEdicion.Caption = "Consulta"
    Exit Sub
    
Err_BajaPromo:
    MousePointer = 0
    MsgBox "Error al tratar de actualizar. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_BajaPromo:


End Sub

Private Sub btnDelFamilias_Click()
    On Error Resume Next
    
    If Baja Then
        MsgBox "¡ No puedes modificar una Promoción dada de Baja o Aplicada !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    strFamilias = strIds(LstFamilias, 0)
    StrCmd = "execute up_PromocionesProductos " & IdPromocion & ", '" & strFamilias & "', '', 0, 4"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    MuestraProductos
End Sub

Private Sub btnDelProductos_Click()
    On Error Resume Next
    
    If Baja Then
        MsgBox "¡ No puedes modificar una Promoción dada de Baja o Aplicada !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    strProductos = strIds(LstProductos, 2)
    StrCmd = "execute up_PromocionesProductos " & IdPromocion & ", '', '" & strProductos & "', 0, 3"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    MuestraProductos

End Sub

Private Sub btnEliminar_Click()
    On Error GoTo Err_BajaPromo:
        
    If UCase(Mid(LstPromociones.SelectedItem.ListSubItems(4), 1, 1)) <> "A" Then
        MousePointer = 0
        MsgBox "¡ No se puede modificar una Promoción dada de Baja o Aplicada !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
        
    If MsgBox("¿ Estás seguro que deseas dar de Baja la Promoción ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        
    ' actualiza datos
    StrCmd = "execute up_Promociones " & IdPromocion & ", '', '', '01/01/1900', '01/01/1900', '', '', 'B', 3"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
        
    MuestraPromociones
    MousePointer = 0
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title

    
No_Err_BajaPromo:
    MousePointer = 0
    LblEdicion.Caption = "Consulta"
    Exit Sub
    
Err_BajaPromo:
    MousePointer = 0
    MsgBox "Error al tratar de actualizar. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_BajaPromo:

End Sub

Private Sub btnImprimir_Click()
If IsEmpty(LstDPromociones) Then Exit Sub

On Error GoTo btnImprimePromocion:
    With CC_RptPromociones
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
        .LblTitulo.Caption = "REPORTE DE PROMOCIONES"
        .LblDatos.Caption = ""
        
        StrCmd = "execute sel_PromocionesRep " & CLng(LstPromociones.SelectedItem) & ", 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If Not RsC.EOF Then
            .object.DataSrc.DataSourceName = Cnn
            .object.DataSrc.Recordset = RsC
        End If
        .IdPromo = CLng(LstPromociones.SelectedItem)
        .Printer.Orientation = ddOPortrait
        .Printer.PaperSize = 1
        .Show
    End With
    
No_btnImprimePromocion:
    MousePointer = 0
    Exit Sub
    
btnImprimePromocion:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_btnImprimePromocion:
End Sub

Private Sub btnNuevo_Click()
On Error Resume Next
    LblEdicion.Caption = "Nuevo"
    TxtId.Text = "000000": TxtNombre.Text = "": TxtObservaciones.Text = ""
    DTPPeriodo(0).Value = Date: DTPPeriodo(1).Value = Date: ChkFechaFinal.Value = 1
    CmbDocumento.ListIndex = 0
End Sub

Private Sub ChkAddCedis_Click()
On Error Resume Next
    Select Case ChkAddCedis.Value
        Case 0, 1     'caso de no seleccionar o seleccionar todo
            For i = 1 To LstCedisNo.ListItems.Count
                LstCedisNo.ListItems(i).Checked = ChkAddCedis.Value
            Next
    End Select
End Sub

Private Sub ChkAddClientes_Click()
On Error Resume Next
    Select Case ChkAddClientes.Value
        Case 0, 1     'caso de no seleccionar o seleccionar todo
            For i = 1 To LstClientesNo.ListItems.Count
                LstClientesNo.ListItems(i).Checked = ChkAddClientes.Value
            Next
    End Select
End Sub

Private Sub ChkAddFamilias_Click()
On Error Resume Next
    Select Case ChkAddFamilias.Value
        Case 0, 1     'caso de no seleccionar o seleccionar todo
            For i = 1 To LstFamiliasNo.ListItems.Count
                LstFamiliasNo.ListItems(i).Checked = ChkAddFamilias.Value
            Next
    End Select
End Sub

Private Sub ChkAddProductos_Click()
On Error Resume Next
    Select Case ChkAddProductos.Value
        Case 0, 1     'caso de no seleccionar o seleccionar todo
            For i = 1 To LstProductosNo.ListItems.Count
                LstProductosNo.ListItems(i).Checked = ChkAddProductos.Value
            Next
    End Select
End Sub

Private Sub ChkDelCedis_Click()
On Error Resume Next
    Select Case ChkDelCedis.Value
        Case 0, 1     'caso de no seleccionar o seleccionar todo
            For i = 1 To LstCedis.ListItems.Count
                LstCedis.ListItems(i).Checked = ChkDelCedis.Value
            Next
    End Select
End Sub

Private Sub ChkDelClientes_Click()
On Error Resume Next
    Select Case ChkDelClientes.Value
        Case 0, 1     'caso de no seleccionar o seleccionar todo
            For i = 1 To LstClientes.ListItems.Count
                LstClientes.ListItems(i).Checked = ChkDelClientes.Value
            Next
    End Select
End Sub

Private Sub ChkDelFamilias_Click()
On Error Resume Next
    Select Case ChkDelFamilias.Value
        Case 0, 1     'caso de no seleccionar o seleccionar todo
            For i = 1 To LstFamilias.ListItems.Count
                LstFamilias.ListItems(i).Checked = ChkDelFamilias.Value
            Next
    End Select
End Sub

Private Sub ChkDelProductos_Click()
On Error Resume Next
    Select Case ChkDelProductos.Value
        Case 0, 1     'caso de no seleccionar o seleccionar todo
            For i = 1 To LstProductos.ListItems.Count
                LstProductos.ListItems(i).Checked = ChkDelProductos.Value
            Next
    End Select
End Sub

Private Sub ChkFechaFinal_Click()
On Error Resume Next
    DTPPeriodo(1).Enabled = IIf(ChkFechaFinal.Value = 0, False, True)
    DTPPeriodo(1).Value = IIf(ChkFechaFinal.Value = 0, CDate("01/01/1900"), Date)
End Sub

Private Sub CmbDocumento_Click()
On Error Resume Next
    MuestraTipoDocumentos
End Sub

Private Sub DTPPeriodo_Change(Index As Integer)
On Error Resume Next
    If Index > 1 And Index < 4 Then MuestraPromocionesAplicadas
End Sub

Private Sub Form_Load()
On Error Resume Next
    DTPPeriodo(0).Value = Date: DTPPeriodo(1).Value = Date
    DTPPeriodo(2).Value = Date: DTPPeriodo(3).Value = Date
    DTPPeriodo(4).Value = Date
    SSTab.Tab = 0
    SSTab_Click 0
    IdPromocion = 0
End Sub

Private Sub LstCedis_Click()
    On Error Resume Next
    If IsEmpty(lstDCedis) Then Exit Sub
    
    MuestraClientes
End Sub

Private Sub LstCedis_KeyUp(KeyCode As Integer, Shift As Integer)
    On Error Resume Next
    If IsEmpty(lstDCedis) Then Exit Sub
    
    MuestraClientes

End Sub


Private Sub LstPromociones_Click()
On Error Resume Next

    If IsEmpty(LstDPromociones) Then Exit Sub

    IdPromocion = CLng(LstPromociones.SelectedItem)
    Baja = IIf(UCase(Mid(LstPromociones.SelectedItem.ListSubItems(4), 1, 1)) <> "A", True, False)

    TxtId.Text = LstPromociones.SelectedItem
    TxtNombre.Text = LstPromociones.SelectedItem.ListSubItems(1).Text
    TxtObservaciones.Text = LstPromociones.SelectedItem.ListSubItems(5).Text
    DTPPeriodo(0).Value = CDate(LstPromociones.SelectedItem.ListSubItems(2).Text)
    DTPPeriodo(1).Value = CDate(LstPromociones.SelectedItem.ListSubItems(3).Text)
    
    DTPPeriodo(1).Enabled = IIf(CDate(LstPromociones.SelectedItem.ListSubItems(3).Text) = "01/01/1900", False, True)
    ChkFechaFinal.Value = IIf(CDate(LstPromociones.SelectedItem.ListSubItems(3).Text) = "01/01/1900", 0, 1)
    
    CmbDocumento.ListIndex = SearchInList(LstDDocumento, LstDPromociones(7, LstPromociones.SelectedItem.Index - 1), 0)
    CmbTipoDocumento.ListIndex = SearchInList(LstDTipoDocumento, LstDPromociones(8, LstPromociones.SelectedItem.Index - 1), 2)
    
    LblPromo(0).Caption = Trim(LstPromociones.SelectedItem.ListSubItems(1).Text)
    LblPromo(1).Caption = Trim(LstPromociones.SelectedItem.ListSubItems(1).Text)
    
    LblEdicion.Caption = "Consulta"
End Sub

Private Sub LstPromociones_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstPromociones_Click
End Sub

Private Sub LstPromocionesAplicadas_DblClick()
On Error Resume Next
    If IsEmpty(LstDPromocionesAplicadas) Then Exit Sub
    With CC_PromocionesDetalle
        .IdAplicacionD = CLng(LstPromocionesAplicadas.SelectedItem)
        .IdPromocionD = CLng(LstPromocionesAplicadas.SelectedItem.ListSubItems(1))
        .Left = MenuCartera.Left
        .Top = MenuCartera.Height + ((CC_Promociones.Height - .Height) / 2)
        .Show
    End With
    
End Sub

Private Sub OptConsulta_Click(Index As Integer)
On Error Resume Next
    MuestraPromociones
End Sub

Private Sub SSTab_Click(PreviousTab As Integer)
On Error Resume Next
    Select Case SSTab.Tab
        Case 0:
            MuestraDocumentos
            MuestraPromociones
        Case 1:
            If IdPromocion = 0 Or IsEmpty(LstDPromociones) Then
                MsgBox "¡ Seleccione una Promoción !", vbInformation + vbOKOnly, App.Title
                SSTab.Tab = 0: Exit Sub
            End If
            MuestraCedis
            MuestraClientes
        Case 2:
            If IdPromocion = 0 Or IsEmpty(LstDPromociones) Then
                MsgBox "¡ Seleccione una Promoción !", vbInformation + vbOKOnly, App.Title
                SSTab.Tab = 0: Exit Sub
            End If
            MuestraProductos
        Case 3:
            MuestraPromocionesAplicadas
    End Select
End Sub

Private Sub MuestraDocumentos()
On Error Resume Next

    StrCmd = "execute sel_Documentos '" & Usuario & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDDocumento = GetDataCBL(Rs, CmbDocumento, "Seleccione un Documento", "No hay Documentos")
    CmbTipoDocumento.Clear
End Sub

Private Sub MuestraTipoDocumentos()
 On Error Resume Next
    
    CmbTipoDocumento.Clear
    If IsEmpty(LstDDocumento) Then Exit Sub
        
    StrCmd = "execute sel_DocumentosTipo '" & LstDDocumento(0, CmbDocumento.ListIndex - 1) & "', '" & LstDDocumento(2, CmbDocumento.ListIndex - 1) & "', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDTipoDocumento = GetDataCBL(Rs, CmbTipoDocumento, "Seleccione un Tipo de Documento", "No hay Tipos de Documentos")
End Sub

Private Sub MuestraPromociones()
On Error Resume Next

Dim Opc
    For i = 0 To OptConsulta.Count - 1
        If OptConsulta(i).Value Then
            Opc = i + 1
            Exit For
        End If
    Next i

    StrCmd = "execute sel_Promociones '" & DTPPeriodo(0).Value & "', '" & DTPPeriodo(1).Value & "', " & Opc
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDPromociones = GetDataLVL(Rs, LstPromociones, 1, 6, "6|0|0|0|0|0")
    LstPromociones_Click
End Sub

Private Sub MuestraCedis()
On Error Resume Next

    StrCmd = "execute sel_PromocionesCedis '" & IdPromocion & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCedisNo = GetDataLVL(Rs, LstCedisNo, 1, 2, "0|0")

    StrCmd = "execute sel_PromocionesCedis '" & IdPromocion & "', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    lstDCedis = GetDataLVL(Rs, LstCedis, 1, 2, "0|0")
    
    ChkAddCedis.Value = 0: ChkDelCedis.Value = 0
End Sub

Private Sub MuestraClientes()
On Error Resume Next

    If IsEmpty(lstDCedis) Then Exit Sub
    
    StrCmd = "execute sel_PromocionesClientes '" & IdPromocion & "', '" & CLng(LstCedis.SelectedItem) & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDClientesNo = GetDataLVL(Rs, LstClientesNo, 1, 3, "0|0|0")

    StrCmd = "execute sel_PromocionesClientes '" & IdPromocion & "', '" & CLng(LstCedis.SelectedItem) & "', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDClientes = GetDataLVL(Rs, LstClientes, 1, 3, "0|0|0")
    
    ChkAddClientes.Value = 0: ChkDelClientes.Value = 0

End Sub

Private Sub MuestraProductos()
On Error Resume Next

    StrCmd = "execute sel_PromocionesProductos '" & IdPromocion & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDFamiliasNo = GetDataLVL(Rs, LstFamiliasNo, 1, 2, "0|0|0")
    
    StrCmd = "execute sel_PromocionesProductos '" & IdPromocion & "', 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDFamilias = GetDataLVL(Rs, LstFamilias, 1, 3, "0|0|0|8")
    
    StrCmd = "execute sel_PromocionesProductos '" & IdPromocion & "', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDProductosNo = GetDataLVL(Rs, LstProductosNo, 1, 4, "0|0|0|0")

    StrCmd = "execute sel_PromocionesProductos '" & IdPromocion & "', 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDClientes = GetDataLVL(Rs, LstProductos, 1, 5, "0|0|0|0|8")
    
    ChkAddFamilias.Value = 0: ChkAddProductos.Value = 0: ChkDelProductos.Value = 0

End Sub

Public Sub MuestraPromocionesAplicadas()
On Error Resume Next

    StrCmd = "execute sel_Promociones '" & DTPPeriodo(2).Value & "', '" & DTPPeriodo(3).Value & "', 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDPromocionesVigentes = GetDataLVL(Rs, LstPromocionesVigentes, 1, 4, "0|0|0|0")

    StrCmd = "execute sel_PromocionesAplicadas 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDPromocionesAplicadas = GetDataLVL(Rs, LstPromocionesAplicadas, 1, 7, "0|0|0|0|0|0|0")
    
End Sub

Private Sub TxtNombre_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtObservaciones_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtPorcF_GotFocus()
On Error Resume Next
    SelText TxtPorcF
End Sub

Private Sub TxtPorcF_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itDecimal(KeyAscii)
End Sub

Private Sub TxtPorcF_Validate(Cancel As Boolean)
On Error Resume Next
    TxtPorcF = itFlotante(TxtPorcF.Text)
End Sub

Private Sub TxtPorcP_GotFocus()
On Error Resume Next
    SelText TxtPorcP
End Sub

Private Sub TxtPorcP_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itDecimal(KeyAscii)
End Sub

Private Sub TxtPorcP_Validate(Cancel As Boolean)
On Error Resume Next
    TxtPorcP.Text = itFlotante(TxtPorcP.Text)
End Sub


