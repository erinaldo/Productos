VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_Reportes 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Reportes Generales"
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
      Height          =   8220
      Index           =   0
      Left            =   120
      TabIndex        =   21
      Top             =   90
      Width           =   12435
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
         Left            =   360
         Picture         =   "CC_Reportes.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   6
         Top             =   7440
         Width           =   1575
      End
      Begin VB.Frame FrmVendedores 
         BackColor       =   &H00FFFFFF&
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   6840
         Left            =   6270
         TabIndex        =   23
         Top             =   300
         Width           =   6015
         Begin VB.CheckBox ChkSeleccionar 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Seleccionar Todos los registros encontrados"
            Height          =   240
            Left            =   210
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   18
            Top             =   6360
            Width           =   4845
         End
         Begin MSComctlLib.ListView LstVDatos 
            Height          =   4005
            Index           =   0
            Left            =   150
            TabIndex        =   17
            Top             =   2280
            Width           =   5715
            _ExtentX        =   10081
            _ExtentY        =   7064
            View            =   3
            LabelEdit       =   1
            LabelWrap       =   -1  'True
            HideSelection   =   0   'False
            Checkboxes      =   -1  'True
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
         Begin VB.Label LabTitulos 
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "Al día:"
            Height          =   240
            Index           =   9
            Left            =   120
            TabIndex        =   43
            Top             =   1650
            Width           =   555
         End
         Begin VB.Label LabTitulos 
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "Del día:"
            Height          =   240
            Index           =   8
            Left            =   120
            TabIndex        =   42
            Top             =   1380
            Width           =   660
         End
         Begin VB.Label LabTitulos 
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "Nivel de Inf.:"
            Height          =   240
            Index           =   7
            Left            =   120
            TabIndex        =   41
            Top             =   1110
            Width           =   1050
         End
         Begin VB.Label LabTitulos 
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "Reporte:"
            Height          =   240
            Index           =   6
            Left            =   120
            TabIndex        =   40
            Top             =   840
            Width           =   735
         End
         Begin VB.Label LabTitulos 
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "CEDI:"
            Height          =   240
            Index           =   5
            Left            =   120
            TabIndex        =   39
            Top             =   570
            Width           =   510
         End
         Begin VB.Label LabTitulos 
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "Resumen del Reporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   -1  'True
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   4
            Left            =   270
            TabIndex        =   38
            Top             =   270
            Width           =   1875
         End
         Begin VB.Label LblTituloReporte 
            BackColor       =   &H00D6D0CB&
            BackStyle       =   0  'Transparent
            Caption         =   "Datos del Reporte a Visualizar Datos del Reporte a Visualizar Datos del Reporte a Visualizar Datos del Reporte a Visualizar"
            ForeColor       =   &H00800000&
            Height          =   240
            Index           =   4
            Left            =   1590
            TabIndex        =   37
            Top             =   1650
            Width           =   4305
         End
         Begin VB.Label LblTituloReporte 
            BackColor       =   &H00D6D0CB&
            BackStyle       =   0  'Transparent
            Caption         =   "Datos del Reporte a Visualizar Datos del Reporte a Visualizar Datos del Reporte a Visualizar Datos del Reporte a Visualizar"
            ForeColor       =   &H00800000&
            Height          =   240
            Index           =   3
            Left            =   1590
            TabIndex        =   36
            Top             =   1380
            Width           =   4305
         End
         Begin VB.Label LblTituloReporte 
            BackColor       =   &H00D6D0CB&
            BackStyle       =   0  'Transparent
            Caption         =   "Datos del Reporte a Visualizar Datos del Reporte a Visualizar Datos del Reporte a Visualizar Datos del Reporte a Visualizar"
            ForeColor       =   &H00800000&
            Height          =   240
            Index           =   2
            Left            =   1590
            TabIndex        =   35
            Top             =   1110
            Width           =   4305
         End
         Begin VB.Label LblTituloReporte 
            BackColor       =   &H00D6D0CB&
            BackStyle       =   0  'Transparent
            Caption         =   "Datos del Reporte a Visualizar Datos del Reporte a Visualizar Datos del Reporte a Visualizar Datos del Reporte a Visualizar"
            ForeColor       =   &H00800000&
            Height          =   240
            Index           =   1
            Left            =   1590
            TabIndex        =   34
            Top             =   840
            Width           =   4305
         End
         Begin VB.Label LblNumeroRegistros 
            BackStyle       =   0  'Transparent
            Caption         =   "Numero de Registros Encontrados"
            ForeColor       =   &H00000000&
            Height          =   285
            Left            =   150
            TabIndex        =   31
            Top             =   1980
            Width           =   5685
         End
         Begin VB.Label LblTituloReporte 
            BackColor       =   &H00D6D0CB&
            BackStyle       =   0  'Transparent
            Caption         =   "Datos del Reporte a Visualizar Datos del Reporte a Visualizar Datos del Reporte a Visualizar Datos del Reporte a Visualizar"
            ForeColor       =   &H00800000&
            Height          =   240
            Index           =   0
            Left            =   1590
            TabIndex        =   30
            Top             =   570
            Width           =   4305
         End
      End
      Begin VB.Frame FrmRuta 
         BackColor       =   &H00FFFFFF&
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   6840
         Left            =   180
         TabIndex        =   22
         Top             =   300
         Width           =   5985
         Begin VB.CheckBox ChkSelecciona 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Seleccionar Todos"
            Height          =   240
            Left            =   3360
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   4
            Top             =   3540
            Width           =   1965
         End
         Begin MSComctlLib.ListView LstSubRep 
            Height          =   2895
            Left            =   120
            TabIndex        =   5
            Top             =   3840
            Width           =   5655
            _ExtentX        =   9975
            _ExtentY        =   5106
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
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   23
            Left            =   4080
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   57
            Top             =   6240
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   22
            Left            =   4080
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   56
            Top             =   6120
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   21
            Left            =   4080
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   55
            Top             =   5760
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   20
            Left            =   4080
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   54
            Top             =   5400
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   19
            Left            =   4080
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   53
            Top             =   5040
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   18
            Left            =   4080
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   52
            Top             =   4680
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   17
            Left            =   4080
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   51
            Top             =   4320
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   16
            Left            =   4080
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   50
            Top             =   3960
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   15
            Left            =   1920
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   49
            Top             =   6000
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   14
            Left            =   1920
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   48
            Top             =   5640
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   13
            Left            =   1920
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   47
            Top             =   5280
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   12
            Left            =   1920
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   46
            Top             =   4920
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   11
            Left            =   1935
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   45
            Top             =   4800
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   10
            Left            =   1935
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   44
            Top             =   4560
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   5
            Left            =   150
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   12
            Top             =   5160
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   6
            Left            =   150
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   13
            Top             =   5400
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   7
            Left            =   150
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   14
            Top             =   5640
            Width           =   1800
         End
         Begin VB.ComboBox CmbCedi 
            Height          =   360
            Left            =   180
            Style           =   2  'Dropdown List
            TabIndex        =   0
            Top             =   630
            Width           =   5625
         End
         Begin VB.ComboBox CmbReporte 
            Height          =   360
            Left            =   120
            Style           =   2  'Dropdown List
            TabIndex        =   3
            Top             =   3000
            Width           =   5655
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   0
            Left            =   150
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   7
            Top             =   3990
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   1
            Left            =   150
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   8
            Top             =   4230
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   2
            Left            =   150
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   9
            Top             =   4440
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   3
            Left            =   150
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   10
            Top             =   4680
            Width           =   1800
         End
         Begin VB.CommandButton CmdMostrar 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Mostrar Filtrado"
            BeginProperty Font 
               Name            =   "Tahoma"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   1155
            Left            =   7710
            Picture         =   "CC_Reportes.frx":0697
            Style           =   1  'Graphical
            TabIndex        =   24
            Top             =   3450
            Width           =   945
         End
         Begin MSComCtl2.DTPicker DTPPeriodo 
            Height          =   345
            Index           =   0
            Left            =   750
            TabIndex        =   1
            Top             =   1560
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
            Format          =   104988675
            CurrentDate     =   38914
         End
         Begin MSComCtl2.DTPicker DTPPeriodo 
            Height          =   345
            Index           =   1
            Left            =   750
            TabIndex        =   2
            Top             =   2130
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
            Format          =   104988675
            CurrentDate     =   38914
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   4
            Left            =   150
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   11
            Top             =   4920
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   8
            Left            =   150
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   16
            Top             =   5880
            Width           =   1800
         End
         Begin VB.OptionButton OptTipoReporte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subreporte"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   9
            Left            =   1935
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   15
            Top             =   4320
            Width           =   1800
         End
         Begin VB.Label LabTitulos 
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "Periodo"
            Height          =   240
            Index           =   1
            Left            =   180
            TabIndex        =   32
            Top             =   1200
            Width           =   660
         End
         Begin VB.Label LabTitulos 
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "CEDI"
            Height          =   240
            Index           =   0
            Left            =   180
            TabIndex        =   29
            Top             =   330
            Width           =   450
         End
         Begin VB.Label Label2 
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "Al"
            Height          =   240
            Left            =   330
            TabIndex        =   28
            Top             =   2190
            Width           =   180
         End
         Begin VB.Label Label5 
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "Del"
            Height          =   240
            Left            =   240
            TabIndex        =   27
            Top             =   1620
            Width           =   285
         End
         Begin VB.Label LabTitulos 
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "Reporte"
            Height          =   240
            Index           =   2
            Left            =   150
            TabIndex        =   26
            Top             =   2700
            Width           =   675
         End
         Begin VB.Label LabTitulos 
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "Nivel de Información"
            Height          =   240
            Index           =   3
            Left            =   150
            TabIndex        =   25
            Top             =   3540
            Width           =   1725
         End
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
         Height          =   615
         Left            =   8640
         Picture         =   "CC_Reportes.frx":0F07
         Style           =   1  'Graphical
         TabIndex        =   19
         Top             =   7320
         Width           =   1695
      End
      Begin VB.CommandButton btnExcel 
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
         Left            =   10440
         Picture         =   "CC_Reportes.frx":1622
         Style           =   1  'Graphical
         TabIndex        =   20
         Top             =   7320
         Width           =   1695
      End
      Begin VB.Label LabEstatus 
         BackStyle       =   0  'Transparent
         Caption         =   "Barra de Estado"
         BeginProperty Font 
            Name            =   "Tahoma"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   210
         Left            =   2040
         TabIndex        =   33
         Top             =   7560
         Width           =   7005
      End
   End
End
Attribute VB_Name = "CC_Reportes"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim ListaDeCedis As Variant
Dim ListaDeReportes As Variant
Dim ListaDeSubReportes As Variant

Dim ListaDeFiltro As Variant

Dim IdCedi As String
Dim FechaInicial As String
Dim FechaFinal As String

Dim IdReporte As Integer
Dim TipoReporte As Integer
Dim NivelReporte As String
Dim SeleccionFiltro As Boolean
Dim FiltroOrdenamiento As String
Dim Filtro As String
Dim SubReporteSeleccionado As Integer
Dim CampoFiltro As String
Dim EjecutaSQL As Integer

Const ctCedis = "LISTACEDIS"
Const ctReportes = "LISTAREPORTES"
Const ctSubReportes = "LISTASUBREPORTES"

Const ctFiltro = "LISTAFILTRO"

Const ctNivelRuta = "NIVELVENTA"
Const ctNivelVendedor = "NIVELVENDEDOR"

Dim CampoInicial As Integer
Dim CampoFinal As Integer
Dim ReporteImpresora As String
Dim ReporteExcel As String
Dim DescripcionAgrupacion As String
Dim EjecutaSQLXLS As Integer
Dim CampoInicialXLS As Integer
Dim CampoFinalXLS As Integer
Dim NombreArchivoXLS As String
Dim TituloReporteXLS As String
Dim PeriodoXLS As String

Dim RepIdCedi As Integer
Dim RepNombreCedi As String
Dim RepNombreReporte As String
Dim RepNivelReporte
Dim RepFechaInicial
Dim RepFechaFinal
Dim LstDSubRep

Sub PreparaDatos(TipoLista As String)

    On Error GoTo ErrConexion2
    
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    
    If Rs.State Then Rs.Close
    
    Select Case TipoLista
        
        Case ctCedis
            
            StrCmd = "sel_CedisUsuarios '" & Usuario & "', 2"
            Rs.Open StrCmd, Cnn
            ListaDeCedis = GetDataCBL(Rs, CmbCedi, "Seleccione el CEDI", "No se Encontraron Registros de CEDIS")
        
        Case ctReportes
        
            StrCmd = "Gsp_ObtenerReportes 1,0,'S'"
            Rs.Open StrCmd, Cnn
            ListaDeReportes = GetDataCBL(Rs, CmbReporte, "Seleccione el Reporte", "No se Encontraron Registros de Reportes")
        
        Case ctSubReportes
        
'            StrCmd = "Gsp_ObtenerReportes 2," & ListaDeReportes(0, CmbReporte.ListIndex - 1) & ",'S'"
'            Rs.Open StrCmd, Cnn
'            ListaDeSubReportes = GetData(Rs)
            
            If Rs.State Then Rs.Close
            StrCmd = "Gsp_ObtenerReportes 2," & ListaDeReportes(0, CmbReporte.ListIndex - 1) & ",'S'"
            Rs.Open StrCmd, Cnn
            ListaDeSubReportes = GetDataLVL(Rs, LstSubRep, 3, 3, "0|")
       
        Case ctFiltro
            Dim Check As Integer, IdTipoDoc As String, Data
            Filtro = "": Check = 0
            
            If (IdReporte >= 1 And IdReporte <= 5) Or (IdReporte >= 10 And IdReporte <= 15) Then
                
                For i = 1 To LstSubRep.ListItems.Count
                    If LstSubRep.ListItems(i).Checked Then
                        Data = Split(LstSubRep.ListItems(i), "-")
                        IdTipoDoc = Trim(Data(0))
                        If Check = 0 Then Filtro = " and MovimientosFacturas.IdTipoDocumento in ("
                        Filtro = Filtro & "''" & IdTipoDoc & "'', "
                        Check = Check + 1
                    End If
                Next
                
                If Check > 0 Then
                    Filtro = Mid(Filtro, 1, Len(Filtro) - 2) & " )"
                Else
                    Data = Split(LstSubRep.SelectedItem, "-")
                    IdTipoDoc = Trim(Data(0))
                    Filtro = " and MovimientosFacturas.IdTipoDocumento in (''" & IdTipoDoc & "'')"
                    MsgBox "¡ Seleccione por lo menos un elemento en la lista de Nivel de Información !", vbInformation + vbOKOnly, App.Title
                End If
            End If
            
            StrCmd = "Gsp_NivelReporte " & IdReporte & "," & TipoReporte & ",'" & IdCedi & "','" & _
                    FormatDate(DTPPeriodo(0).Value) & "','" & FormatDate(DTPPeriodo(1).Value) & _
                    "','" & Filtro & "', '" & IIf((IdReporte >= 1 And idreporote <= 5) Or (IdReporte >= 10 And idreporote <= 15), "0", FiltroOrdenamiento) & "'"
            Rs.Open StrCmd, Cnn
           
            If Rs.State Then
                ListaDeFiltro = GetDataLVLFMT(Rs, LstVDatos(0), CampoInicial, CampoFinal, "")
            Else
                ListaDeFiltro = Empty
            End If
            If Not IsEmpty(ListaDeFiltro) Then
                LblNumeroRegistros.Caption = "Se encontraron " & UBound(ListaDeFiltro, 2) + 1 & " registros en el periodo seleccionado"
            End If
    
    End Select
    
    Exit Sub
ErrConexion2:
    MsgBox "Error al tratar de conectarse al Servidor. " & Chr(13) & Chr(10) & Err.Description, vbExclamation, "Error de Conexión...."
    
    MousePointer = 0
    Exit Sub
End Sub

Sub MensajeSeleccionFiltro()
    
    Dim ContenidoMensaje As String

    ContenidoMensaje = "Seleccione CEDI "
    SeleccionFiltro = False
            
    If CmbCedi.ListIndex <= 0 Then
        GoTo EscribeMensaje
    Else
        ContenidoMensaje = "Seleccione Reporte"
    End If
    
    If CmbReporte.ListIndex <= 0 Then
        GoTo EscribeMensaje
    Else
        ContenidoMensaje = "Seleccione Elementos de la lista y Aplique para Mostrar la Información"
    End If
    
    SeleccionFiltro = True
    
EscribeMensaje:
    
    Mensaje "OK", ContenidoMensaje
    
    Exit Sub
    
End Sub

Sub ObtenerRegistrosFiltro()

    On Error GoTo Salir

    Screen.MousePointer = vbHourglass

    FechaInicial = DTPPeriodo(0).Value
    FechaFinal = DTPPeriodo(1).Value

    IdReporte = IIf(CmbReporte.ListIndex = 0, 0, ListaDeReportes(0, CmbReporte.ListIndex - 1))

'    TipoReporte = OptTipoReporte(SubReporteSeleccionado).Tag
'    NivelReporte = OptTipoReporte(SubReporteSeleccionado).Caption
    
    TipoReporte = ListaDeSubReportes(1, SubReporteSeleccionado)
    NivelReporte = ListaDeSubReportes(3, SubReporteSeleccionado)
    
    EjecutaSQL = ListaDeSubReportes(4, SubReporteSeleccionado)
    CampoInicial = ListaDeSubReportes(5, SubReporteSeleccionado)
    CampoFinal = ListaDeSubReportes(6, SubReporteSeleccionado)
    CampoFiltro = ListaDeSubReportes(7, SubReporteSeleccionado)
    
    ReporteImpresora = ListaDeSubReportes(8, SubReporteSeleccionado)
    ReporteExcel = ListaDeSubReportes(9, SubReporteSeleccionado)
    
    DescripcionAgrupacion = ListaDeSubReportes(10, SubReporteSeleccionado)
    
    EjecutaSQLXLS = ListaDeSubReportes(11, SubReporteSeleccionado)
    CampoInicialXLS = ListaDeSubReportes(12, SubReporteSeleccionado)
    CampoFinalXLS = ListaDeSubReportes(13, SubReporteSeleccionado)
    
    LstVDatos(0).ColumnHeaders.Clear
    LstVDatos(0).ListItems.Clear
    
    For i = 0 To LblTituloReporte.Count - 1
        LblTituloReporte(i).Caption = ""
    Next

    LblNumeroRegistros.Caption = ""
    
    ChkSeleccionar.Value = 0

    If CmbCedi.ListIndex > 0 Then
        IdCedi = Format(ListaDeCedis(0, CmbCedi.ListIndex - 1), "00")
    Else
        IdCedi = 0
        'GoTo Salir
    End If
    
    If CmbReporte.ListIndex > 0 Then
        If IdReporte >= 100 Then
            If Not ValidaModulo("CONT", True) Or IdCedi <> 0 Then
                MousePointer = 0
                Exit Sub
            End If
        End If
    Else
        GoTo Salir
        Exit Sub
    End If

    RepIdCedi = IdCedi
    RepNombreCedi = CmbCedi.Text
    RepNombreReporte = CmbReporte.Text
    RepNivelReporte = NivelReporte
    RepFechaInicial = DTPPeriodo(0).Value
    RepFechaFinal = DTPPeriodo(1).Value

    LblTituloReporte(0).Caption = CmbCedi.Text
    LblTituloReporte(1).Caption = CmbReporte.Text
    LblTituloReporte(2).Caption = NivelReporte
    LblTituloReporte(3).Caption = Format(DTPPeriodo(0).Value, "dd "" de "" mmmm "" de "" yyyy")
    LblTituloReporte(4).Caption = Format(DTPPeriodo(1).Value, "dd "" de "" mmmm "" de "" yyyy")

    PreparaDatos ctFiltro
    
Salir:
    
    Screen.MousePointer = vbDefault

End Sub


Sub Mensaje(Tipo As String, Texto As String)

    Dim Color As ColorConstants
    
    Select Case Tipo
        Case "OK"
            Color = &H800000
        
        Case "ERR"
            Color = &HC0&
            
        Case "PR"   'case proceso
            Color = &H8080&
            
    End Select
    
    LabEstatus.Caption = Texto
    LabEstatus.ForeColor = Color

End Sub

Sub OcultaOpciones()
    For i = 0 To OptTipoReporte.Count - 1
        OptTipoReporte(i).Visible = False
    Next
End Sub

Private Sub ChkSelecciona_Click()
    Select Case ChkSelecciona.Value
        Case 0, 1     'caso de no seleccionar o seleccionar todo
            For i = 1 To LstSubRep.ListItems.Count
                LstSubRep.ListItems(i).Checked = ChkSelecciona.Value
            Next
    End Select
    LstSubRep_Click
End Sub

Private Sub ChkSeleccionar_Click()

    Select Case ChkSeleccionar.Value
    
        Case 0, 1     'caso de no seleccionar o seleccionar todo
            
            For i = 1 To LstVDatos(0).ListItems.Count
                LstVDatos(0).ListItems(i).Checked = ChkSeleccionar.Value
            Next
            
            btnImprimir.Enabled = IIf(ChkSeleccionar.Value > 0 And (LstVDatos(0).ListItems.Count) > 0 And _
                                    ReporteImpresora = "S", True, False)
            btnExcel.Enabled = IIf(ChkSeleccionar.Value > 0 And (LstVDatos(0).ListItems.Count) > 0 And _
                                    ReporteExcel = "S", True, False)
    End Select

End Sub

Private Sub CmbCedi_Click()

    MensajeSeleccionFiltro

End Sub

Private Sub CmbReporte_Click()

    OcultaOpciones
    
    ChkSeleccionar.Value = 0
    ChkSelecciona.Value = 0

    MensajeSeleccionFiltro
    
    If CmbReporte.ListIndex > 0 Then
        MensajeSeleccionFiltro
        
        'traer los subreportes
        PreparaDatos ctSubReportes
        
        If Not IsEmpty(ListaDeSubReportes) Then
        
            For i = 0 To UBound(ListaDeSubReportes, 2)
                OptTipoReporte(i).Visible = True
                OptTipoReporte(i).Caption = ListaDeSubReportes(3, i)
                OptTipoReporte(i).Tag = ListaDeSubReportes(1, i)
            Next
            
            If OptTipoReporte(0).Visible Then
                If OptTipoReporte(0).Value Then
                    OptTipoReporte_Click 0
                    MensajeSeleccionFiltro
                Else
                    OptTipoReporte(0).Value = True
                End If
            End If
        End If
    End If
    

End Sub

Private Sub btnExcel_Click()

    On Error GoTo ErrConexion2
    
    Select Case IdReporte
        Case 1 To 5, 10 To 15 ' Movimientos Facturas
            TituloReporteXLS = "Movimientos a Facturas ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Movimientos"
            
        Case 6      'Antiguedad
            TituloReporteXLS = "Antiguedad de Saldos ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & "-" & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Antiguedad"
            
        Case 7      'Antiguedad Detallada
            TituloReporteXLS = "Antiguedad de Saldos Detallada ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & "-" & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Antiguedad Detalle"
            
        Case 8      'Balanza
            TituloReporteXLS = "Balanza de Clientes ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Balanza"
    
        Case 18      'Balanza detallada
            TituloReporteXLS = "Balanza de Clientes Detallada ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Balanza Detallada"
    
        Case 9      'Ventas por Cliente
            TituloReporteXLS = "Ventas por Cliente ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Ventas por Cliente"

        Case 16      'Conciliación Bancaria
            TituloReporteXLS = "Conciliación Bancaria ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Conciliación Bancaria"
            
        Case 17      'Despósitos por Cliente y Banco
            TituloReporteXLS = "Despósitos por Cliente y Banco ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Despósitos por Cliente y Banco"

        Case 100      'POLIZA DIARIO DE VENTAS
            TituloReporteXLS = "Póliza Diario de Ventas ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Póliza Diario de Ventas"
    
        Case 101      'POLIZA LIBRO DE VENTAS
            TituloReporteXLS = "Póliza Libro de Ventas ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Póliza Libro de Ventas"
            
        Case 102      'RESUMEN DE MOVIMIENTOS
            TituloReporteXLS = "Póliza Resumen de Movimientos ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Póliza Resumen de Movimientos"
                       
        Case 103      'IVA POR PAGAR COBRADO
            TituloReporteXLS = "Póliza de Iva por Pagar Cobrado ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Póliza de Iva por Pagar Cobrado"
    
        Case 104      'IETU
            TituloReporteXLS = "Póliza de IETU ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Póliza de IETU "
        
        Case 105      'MERMAS Y OBSEQUIOS
            TituloReporteXLS = "Póliza de Mermas y Obsequios ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Póliza de Mermas y Obsequios"
                
    End Select
        
    NombreArchivoXLS = "CED" & Format(IdCedi, "00") & Tipo & "(" & DescripcionAgrupacion & ") " & Format(RepFechaInicial, "yymmdd") & _
                        " - " & Format(RepFechaInicial, "yymmdd") & "  " & Format(Time, "HHnn")
        
    If MsgBox("Se va a crear el archivo de nombre """ & NombreArchivoXLS & _
        """ (esta operación podría tardar varios minutos), ¿Desea Continuar?", vbYesNo, "Archivo Excel") = vbNo Then Exit Sub
    
    Screen.MousePointer = vbHourglass
    
    Filtro = ""
        
    If ChkSeleccionar.Value = 2 Or IdReporte <= 5 Then
        
        For i = 1 To LstVDatos(0).ListItems.Count
            If LstVDatos(0).ListItems(i).Checked Then
                
                'construir el filtro
                Filtro = Filtro & IIf(Filtro = "", "", ",") & "''" & ListaDeFiltro(0, i - 1) & "''"
                
                ConteoRegistrosChecados = ConteoRegistrosChecados + 1
                
            End If
        Next
        
        Filtro = IIf(Filtro <> "", " AND " & CampoFiltro & " in (" & Filtro & ")", "")
    
    End If
    
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    
    If Rs.State Then Rs.Close

    StrCmd = "Gsp_NivelReporte " & IdReporte & "," & EjecutaSQLXLS & ",'" & RepIdCedi & "','" & _
            FormatDate(CDate(RepFechaInicial)) & "','" & FormatDate(CDate(RepFechaFinal)) & "', '" & _
            IIf(ChkSeleccionar.Value = 2 Or ((IdReporte >= 1 And idreporote <= 5) Or (IdReporte >= 10 And idreporote <= 15)), Filtro, "") & _
            "', '" & IIf((IdReporte >= 1 And idreporote <= 5) Or (IdReporte >= 10 And idreporote <= 15), "1", FiltroOrdenamiento) & "'"
        
    Rs.Open StrCmd, Cnn
    
    If Not Rs.EOF Then
        
        ImpresionExcelCC NombreArchivoXLS, TituloReporteXLS, PeriodoXLS, Rs, CampoInicialXLS, CampoFinalXLS, RepIdCedi, RepNombreCedi, IdReporte
        
    End If
    
    Screen.MousePointer = vbDefault

    'CloseConn
    Exit Sub
    
ErrConexion2:
    
    Screen.MousePointer = vbDefault
        
    MsgBox "Error al tratar de conectarse al Servidor. " & Chr(13) & Chr(10) & Err.Description, vbExclamation, "Error de Conexión...."
    
    MousePointer = 0
    Exit Sub

End Sub

Private Sub btnImprimir_Click()
    On Error GoTo ErrConexion2
        
    Screen.MousePointer = vbHourglass
    
    Filtro = ""
        
    If ChkSeleccionar.Value = 2 Or ((IdReporte >= 1 And idreporote <= 5) Or (IdReporte >= 10 And idreporote <= 15)) Then
        
        For i = 1 To LstVDatos(0).ListItems.Count
            If LstVDatos(0).ListItems(i).Checked Then
                
                'construir el filtro
                Filtro = Filtro & IIf(Filtro = "", "", ",") & "''" & ListaDeFiltro(0, i - 1) & "''"
                
                ConteoRegistrosChecados = ConteoRegistrosChecados + 1
                
            End If
        Next
'        If IdReporte = 12 Then
'            Filtro = IIf(Filtro <> "", CampoFiltro & " in (" & Filtro & ")", "")
'        Else
            Filtro = IIf(Filtro <> "", " AND " & CampoFiltro & " in (" & Filtro & ")", "")
'        End If
    Else
        
        If ChkSeleccionar.Value = 1 Then
            For i = 1 To LstVDatos(0).ListItems.Count
                If LstVDatos(0).ListItems(i).Checked Then
                    
                    'construir el filtro
                    Filtro = Filtro & IIf(Filtro = "", "", ",") & "''" & ListaDeFiltro(0, i - 1) & "''"
                    
                    ConteoRegistrosChecados = ConteoRegistrosChecados + 1
                    
                End If
            Next
            
            Filtro = IIf(Filtro <> "", CampoFiltro & " in (" & Filtro & ")", "")
        End If
    
    End If
    
'                    .Printer.PaperSize = vbPRPSUser
'                    .Printer.PaperHeight = 15840 / 2
'                    .Printer.PaperWidth = 12240
    
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    If Rs.State Then Rs.Close
    
    Filtro = IIf(ChkSeleccionar.Value = 2 Or ((IdReporte >= 1 And IdReporte <= 5) Or (IdReporte >= 10 And IdReporte <= 15)), Filtro, "")
    If IdReporte = 20 Then Filtro = ""
    
    Dim StrMarca
    If (IdReporte = 6 Or IdReporte = 7 Or IdReporte = 8 Or IdReporte = 18) And EjecutaSQL = 30 Then
        FiltroOrdenamiento = ""
        For i = 1 To LstVDatos(0).ListItems.Count
            If LstVDatos(0).ListItems(i).Checked Then
                
                'construir el filtro
                FiltroOrdenamiento = FiltroOrdenamiento & IIf(FiltroOrdenamiento = "", "", ",") & "''" & ListaDeFiltro(0, i - 1) & "''"
                StrMarca = ListaDeFiltro(1, i - 1)
                Exit For
                ConteoRegistrosChecados = ConteoRegistrosChecados + 1
                
            End If
        Next
                
        If IdReporte <> 18 Then FiltroOrdenamiento = IIf(FiltroOrdenamiento <> "", " Marcas.IdMarca in (" & FiltroOrdenamiento & ")", "")
        
    End If
    
    StrCmd = "Gsp_NivelReporte " & IdReporte & "," & EjecutaSQL & ",'" & RepIdCedi & "','" & _
            FormatDate(CDate(RepFechaInicial)) & "','" & FormatDate(CDate(RepFechaFinal)) & "', '" & Filtro & _
            "', '" & IIf((IdReporte >= 1 And IdReporte <= 5) Or (IdReporte >= 10 And IdReporte <= 15), "1", FiltroOrdenamiento) & "'"
    Rs.Open StrCmd, Cnn
    
    If Not Rs.EOF Then
        Select Case IdReporte
            Case 1 To 5, 10 To 15      'Movimientos
                With CC_RptMovimiento
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Movimientos de Facturas ( " & NivelReporte & " )"
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    Screen.MousePointer = 0
                    .Show
                End With
                
            Case 6      'Antiguedad
                With CC_RptAntiguedad
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Antiguedad de Saldos ( " & NivelReporte & " )"
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    Screen.MousePointer = 0
                    .Show
                End With
        
            Case 7      'Antiguedad Detallada
                With CC_RptAntiguedadDetalle
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Antiguedad de Saldos Detallada ( " & NivelReporte & " )"
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    Screen.MousePointer = 0
                    .Show
                End With
        
            Case 8      'Balanza
                With CC_RptBalanza
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Balanza de Clientes ( " & NivelReporte & " )"
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                                        
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    Screen.MousePointer = 0
                    .Show
                End With
        
            Case 18      'Balanza Detallada
                With CC_RptBalanzaDetallada
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Balanza de Clientes Detallada ( " & NivelReporte & " )"
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    Screen.MousePointer = 0
                    .Show
                End With
        
            Case 9      'Ventas por Cliente
                With CC_RptVentasCliente
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Ventas por Cliente ( " & NivelReporte & " )"
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    Screen.MousePointer = 0
                    .Show
                End With
        
            Case 16      'Conciliación Bancaria
                With CC_RptConciliacion
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Conciliación Bancaria ( " & NivelReporte & " )"
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    Screen.MousePointer = 0
                    .Show
                End With
        
            Case 17      'Despósitos de Clientes por Banco
                With CC_RptClientesBancos
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Despósitos por Cliente y Banco ( " & NivelReporte & " )"
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    Screen.MousePointer = 0
                    .Show
                End With
        
            Case 20      'Cobranza Terminales
                With CC_RptCobranzaTerminales
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Cobranza Terminales ( " & NivelReporte & " )"
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    Screen.MousePointer = 0
                    .Show
                End With
            
            Case 100      'POLIZA DIARIO DE VENTAS
                With CC_RptDiarioVentas
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Póliza Diario de Ventas ( " & NivelReporte & " )"
                    .LblCedis.Caption = IIf(RepIdCedi = 0, "TODOS LOS CEDIS", RepIdCedi & " - " & RepNombreCedi)
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    Screen.MousePointer = 0
                    .Show
                End With
        
            Case 101      'POLIZA LIBRO DE VENTAS
                With CC_RptLibroVentas
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Póliza Libro de Ventas ( " & NivelReporte & " )"
                    .LblCedis.Caption = IIf(RepIdCedi = 0, "TODOS LOS CEDIS", RepIdCedi & " - " & RepNombreCedi)
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    
                    .Printer.Orientation = ddOLandscape: .Printer.PaperSize = 1
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    Screen.MousePointer = 0
                    .Show
                End With
        
            Case 102      'RESUMEN DE MOVIMIENTOS
                With CC_RptResumenMovimientos
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Póliza Resumen de Movimientos ( " & NivelReporte & " )"
                    .LblCedis.Caption = IIf(RepIdCedi = 0, "TODOS LOS CEDIS", RepIdCedi & " - " & RepNombreCedi)
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    Screen.MousePointer = 0
                    .Show
                End With
                            
            Case 103      'IVA POR PAGAR COBRADO
                With CC_RptIvaPorPagarCobrado
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Póliza de Iva por Pagar Cobrado ( " & NivelReporte & " )"
                    .LblCedis.Caption = IIf(RepIdCedi = 0, "TODOS LOS CEDIS", RepIdCedi & " - " & RepNombreCedi)
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                                        
                    .LblFechaCargo.Caption = "Mes " & Format(Month(RepFechaInicial), "00") & " de año " & Year(RepFechaInicial)
                    .LblFechaAbono.Caption = "Mes " & Format(Month(RepFechaInicial), "00") & " de año " & Year(RepFechaInicial)
                    
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    Screen.MousePointer = 0
                    .Show
                End With
        
            Case 104      'IETU
                With CC_RptIETU
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Póliza de IETU ( " & NivelReporte & " )"
                    .LblCedis.Caption = IIf(RepIdCedi = 0, "TODOS LOS CEDIS", RepIdCedi & " - " & RepNombreCedi)
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                                        
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    Screen.MousePointer = 0
                    .Show
                End With
        
            Case 105      'MERMAS Y OBSEQUIOS
                With CC_RptMermasObsequios
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Póliza de Mermas y Obsequios ( " & NivelReporte & " )"
                    .LblCedis.Caption = IIf(RepIdCedi = 0, "TODOS LOS CEDIS", RepIdCedi & " - " & RepNombreCedi)
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                                        
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    Screen.MousePointer = 0
                    .Show
                End With
        
        End Select
    Else
        Mensaje "ERR", "No se Encontraron Registros en el periodo seleccionado"
    End If

    Screen.MousePointer = 0

    'CloseConn
    Exit Sub
    
ErrConexion2:
    
    Screen.MousePointer = 0
        
    MsgBox "Error al tratar de conectarse al Servidor. " & Chr(13) & Chr(10) & Err.Description, vbExclamation, "Error de Conexión...."
    
    MousePointer = 0
    Exit Sub


End Sub


Private Sub btnAplica_Click()

    ObtenerRegistrosFiltro

End Sub

Private Sub DTPPeriodo_Change(Index As Integer)
    
    Select Case Index
        Case 0  'caso de primera fecha
            DTPPeriodo(1).MinDate = DTPPeriodo(0).Value
    End Select
    
    MensajeSeleccionFiltro

End Sub

Private Sub Form_Activate()
    
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    Screen.MousePointer = vbDefault
    
End Sub

Private Sub Form_Load()
    
    Dim Fecha
    
    On Error GoTo ErrorHandler
    
    RutaApl = IIf(Right(App.Path, 1) = "\", App.Path, App.Path & "\")
    
    DirectorioReportesXLS = "ReportesXLS\"
    
    DTPPeriodo(0).Value = Date: DTPPeriodo(0).MaxDate = Date
    DTPPeriodo(1).Value = Date: DTPPeriodo(1).MaxDate = Date
    DTPPeriodo(1).MinDate = DTPPeriodo(0).Value
    
    FechaInicial = DTPPeriodo(0).Value
    FechaFinal = DTPPeriodo(1).Value
    
    LstVDatos(0).ColumnHeaders.Clear
    LstVDatos(0).ListItems.Clear
    
    For i = 0 To LblTituloReporte.Count - 1
        LblTituloReporte(i).Caption = ""
    Next

    LblNumeroRegistros.Caption = ""
    
    ChkSeleccionar.Value = 0
    
    PreparaDatos ctCedis
    PreparaDatos ctReportes
    
    ChkSeleccionar_Click
    
    btnAplica_Click
    
    Exit Sub
    
ErrorHandler:

    MsgBox "Error al abrir el módulo de Reportes", vbCritical, "Error...."

    Exit Sub
   
End Sub

Private Sub LstSubRep_Click()
    On Error Resume Next
    
    If IsEmpty(ListaDeSubReportes) Then Exit Sub

    SubReporteSeleccionado = LstSubRep.SelectedItem.Index - 1
    MensajeSeleccionFiltro
End Sub

Private Sub LstSubRep_ItemCheck(ByVal Item As MSComctlLib.ListItem)
    Dim ConteoRegistrosChecados As Integer
    
    ConteoRegistrosChecados = 0
    
    For i = 1 To LstSubRep.ListItems.Count
        If LstSubRep.ListItems(i).Checked Then
            ConteoRegistrosChecados = ConteoRegistrosChecados + 1
        End If
    Next
    
    Select Case ConteoRegistrosChecados
        Case Is = 0
            ChkSelecciona.Value = 0
        
        Case Is = LstSubRep.ListItems.Count
            ChkSelecciona.Value = 1
        
        Case Is < LstSubRep.ListItems.Count
            ChkSelecciona.Value = 2
    
    End Select

End Sub

Private Sub LstSubRep_KeyDown(KeyCode As Integer, Shift As Integer)
    LstSubRep_Click
End Sub

Private Sub LstVDatos_ItemCheck(Index As Integer, ByVal Item As MSComctlLib.ListItem)

    Dim ConteoRegistrosChecados As Integer
    
    ConteoRegistrosChecados = 0
    
    For i = 1 To LstVDatos(0).ListItems.Count
        If LstVDatos(0).ListItems(i).Checked Then
            
            ConteoRegistrosChecados = ConteoRegistrosChecados + 1
        End If
    Next
    
    Select Case ConteoRegistrosChecados
        Case Is = 0
            ChkSeleccionar.Value = 0
        
        Case Is = LstVDatos(0).ListItems.Count
            ChkSeleccionar.Value = 1
        
        Case Is < LstVDatos(0).ListItems.Count
            ChkSeleccionar.Value = 2
    
    End Select
    
    btnImprimir.Enabled = IIf(ConteoRegistrosChecados > 0 And ReporteImpresora = "S", True, False)
    btnExcel.Enabled = IIf(ConteoRegistrosChecados > 0 And ReporteExcel = "S", True, False)

End Sub

Private Sub OptTipoReporte_Click(Index As Integer)

    On Error Resume Next

    'SubReporteSeleccionado = Index
    
    SubReporteSeleccionado = LstSubRep.SelectedItem.Index
    MensajeSeleccionFiltro
End Sub




