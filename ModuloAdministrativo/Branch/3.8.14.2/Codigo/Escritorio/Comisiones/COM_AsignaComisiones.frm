VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form COM_AsignaComisiones 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Define Esquemas para Pago de Comisiones"
   ClientHeight    =   8535
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
   ScaleHeight     =   8535
   ScaleWidth      =   12660
   ShowInTaskbar   =   0   'False
   Begin TabDlg.SSTab SSTab 
      Height          =   8385
      Left            =   90
      TabIndex        =   19
      Top             =   90
      Width           =   12495
      _ExtentX        =   22040
      _ExtentY        =   14790
      _Version        =   393216
      Tabs            =   2
      Tab             =   1
      TabsPerRow      =   4
      TabHeight       =   520
      BackColor       =   16777215
      TabCaption(0)   =   "Esquemas de Comisiones"
      TabPicture(0)   =   "COM_AsignaComisiones.frx":0000
      Tab(0).ControlEnabled=   0   'False
      Tab(0).Control(0)=   "FrmOpt(0)"
      Tab(0).Control(1)=   "LblOpt(1)"
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "Definición de Pagos"
      TabPicture(1)   =   "COM_AsignaComisiones.frx":001C
      Tab(1).ControlEnabled=   -1  'True
      Tab(1).Control(0)=   "LblOpt(2)"
      Tab(1).Control(0).Enabled=   0   'False
      Tab(1).Control(1)=   "FrmOpt(1)"
      Tab(1).Control(1).Enabled=   0   'False
      Tab(1).ControlCount=   2
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
         Height          =   8070
         Index           =   1
         Left            =   0
         TabIndex        =   27
         Top             =   330
         Width           =   12495
         Begin VB.Frame Frame2 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Define Pagos"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   2295
            Left            =   240
            TabIndex        =   46
            Top             =   5640
            Width           =   11535
            Begin VB.CommandButton btnAccion 
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
               Height          =   375
               Index           =   4
               Left            =   5880
               Picture         =   "COM_AsignaComisiones.frx":0038
               Style           =   1  'Graphical
               TabIndex        =   49
               Top             =   360
               Width           =   1335
            End
            Begin VB.TextBox TxtDatos 
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
               Height          =   330
               Index           =   7
               Left            =   4320
               MaxLength       =   8
               TabIndex        =   48
               Top             =   360
               Width           =   1455
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
               Left            =   1560
               Style           =   2  'Dropdown List
               TabIndex        =   47
               Top             =   360
               Width           =   1965
            End
            Begin MSComctlLib.ListView LstVDatos 
               Height          =   1335
               Index           =   3
               Left            =   120
               TabIndex        =   50
               Top             =   840
               Width           =   11205
               _ExtentX        =   19764
               _ExtentY        =   2355
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
               Caption         =   "Pago"
               Height          =   240
               Index           =   15
               Left            =   3720
               TabIndex        =   52
               Top             =   360
               Width           =   450
            End
            Begin VB.Label LblCombo 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Tipo Vendedor"
               Height          =   240
               Index           =   0
               Left            =   240
               TabIndex        =   51
               Top             =   360
               Width           =   1245
            End
         End
         Begin VB.Frame Frame1 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Define Rangos"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   4665
            Left            =   240
            TabIndex        =   34
            Top             =   840
            Width           =   11985
            Begin VB.Frame Frm 
               BackColor       =   &H00FFFFFF&
               BorderStyle     =   0  'None
               Height          =   855
               Index           =   1
               Left            =   2280
               TabIndex        =   35
               Top             =   600
               Visible         =   0   'False
               Width           =   5415
               Begin VB.TextBox TxtProducto1 
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
                  Left            =   1080
                  Locked          =   -1  'True
                  TabIndex        =   12
                  Top             =   360
                  Width           =   4215
               End
               Begin VB.TextBox TxtIdProducto1 
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
                  Height          =   345
                  Left            =   120
                  MaxLength       =   10
                  TabIndex        =   11
                  Top             =   360
                  Width           =   855
               End
               Begin VB.Label Label8 
                  BackColor       =   &H00FFFFFF&
                  Caption         =   "Producto"
                  Height          =   255
                  Left            =   1200
                  TabIndex        =   37
                  Top             =   120
                  Width           =   3735
               End
               Begin VB.Label Label9 
                  BackColor       =   &H00FFFFFF&
                  Caption         =   "Cve. P"
                  Height          =   255
                  Left            =   120
                  TabIndex        =   36
                  Top             =   120
                  Width           =   495
               End
            End
            Begin VB.OptionButton OptAsigna 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Por Familia de Producto"
               BeginProperty Font 
                  Name            =   "Arial"
                  Size            =   9
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   255
               Index           =   2
               Left            =   480
               TabIndex        =   45
               Top             =   360
               Value           =   -1  'True
               Width           =   2415
            End
            Begin VB.OptionButton OptAsigna 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Por Producto"
               BeginProperty Font 
                  Name            =   "Arial"
                  Size            =   9
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   255
               Index           =   3
               Left            =   3000
               TabIndex        =   44
               Top             =   360
               Width           =   2295
            End
            Begin VB.CheckBox ChkMostrarTodo 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Mostrar todos los Productos"
               Enabled         =   0   'False
               Height          =   375
               Left            =   1800
               TabIndex        =   18
               Top             =   1440
               Value           =   1  'Checked
               Width           =   2895
            End
            Begin VB.CommandButton btnAccion 
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
               Height          =   375
               Index           =   3
               Left            =   10440
               Picture         =   "COM_AsignaComisiones.frx":0647
               Style           =   1  'Graphical
               TabIndex        =   16
               Top             =   960
               Width           =   1335
            End
            Begin VB.CommandButton btnAccion 
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
               Height          =   375
               Index           =   2
               Left            =   480
               Picture         =   "COM_AsignaComisiones.frx":0C56
               Style           =   1  'Graphical
               TabIndex        =   17
               Top             =   1440
               Width           =   1215
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
               Index           =   2
               Left            =   240
               Style           =   2  'Dropdown List
               TabIndex        =   10
               Top             =   960
               Width           =   1965
            End
            Begin VB.TextBox TxtDatos 
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
               Height          =   345
               Index           =   8
               Left            =   9120
               MaxLength       =   8
               TabIndex        =   15
               Top             =   960
               Width           =   1215
            End
            Begin VB.TextBox TxtDatos 
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
               Height          =   345
               Index           =   9
               Left            =   7800
               MaxLength       =   8
               TabIndex        =   14
               Top             =   960
               Width           =   1215
            End
            Begin VB.Frame Frm 
               BackColor       =   &H00FFFFFF&
               BorderStyle     =   0  'None
               Height          =   615
               Index           =   0
               Left            =   2400
               TabIndex        =   38
               Top             =   720
               Width           =   5295
               Begin VB.ComboBox CmbDatos 
                  Height          =   360
                  Index           =   3
                  Left            =   0
                  Style           =   2  'Dropdown List
                  TabIndex        =   13
                  Top             =   240
                  Width           =   5295
               End
               Begin VB.Label Label5 
                  BackColor       =   &H00FFFFFF&
                  Caption         =   "Familia de Producto"
                  Height          =   255
                  Left            =   120
                  TabIndex        =   39
                  Top             =   0
                  Width           =   3735
               End
            End
            Begin MSComctlLib.ListView LstVDatos 
               Height          =   2415
               Index           =   2
               Left            =   120
               TabIndex        =   20
               Top             =   2160
               Width           =   11685
               _ExtentX        =   20611
               _ExtentY        =   4260
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
            Begin VB.Label LblMensaje 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Mensaje"
               BeginProperty Font 
                  Name            =   "Arial"
                  Size            =   8.25
                  Charset         =   0
                  Weight          =   700
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               ForeColor       =   &H000000C0&
               Height          =   210
               Left            =   240
               TabIndex        =   53
               Top             =   1920
               Width           =   11385
            End
            Begin VB.Label LblCombo 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Pago en base a"
               Height          =   240
               Index           =   1
               Left            =   240
               TabIndex        =   42
               Top             =   720
               Width           =   1365
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Hasta"
               Height          =   240
               Index           =   16
               Left            =   9120
               TabIndex        =   41
               Top             =   720
               Width           =   510
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "De"
               Height          =   240
               Index           =   17
               Left            =   7800
               TabIndex        =   40
               Top             =   720
               Width           =   240
            End
         End
         Begin VB.Label LblEsquema 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Esquema"
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
            TabIndex        =   33
            Top             =   360
            Width           =   1005
         End
         Begin VB.Line Line3 
            X1              =   120
            X2              =   12255
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
         Height          =   8070
         Index           =   0
         Left            =   -75000
         TabIndex        =   22
         Top             =   320
         Width           =   12495
         Begin VB.OptionButton OptAsigna 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Rutas a las que aplica el Esquema "
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
            Left            =   3840
            TabIndex        =   5
            Top             =   4320
            Width           =   3255
         End
         Begin VB.OptionButton OptAsigna 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cedis a los que aplica el Esquema"
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
            Left            =   480
            TabIndex        =   4
            Top             =   4320
            Value           =   -1  'True
            Width           =   3255
         End
         Begin VB.Frame frmCedis 
            BackColor       =   &H00FFFFFF&
            Height          =   3375
            Left            =   240
            TabIndex        =   30
            Top             =   4560
            Width           =   10335
            Begin VB.CommandButton btnAccion 
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
               Height          =   375
               Index           =   1
               Left            =   4800
               Picture         =   "COM_AsignaComisiones.frx":11F1
               Style           =   1  'Graphical
               TabIndex        =   8
               Top             =   600
               Width           =   1335
            End
            Begin VB.CommandButton btnAccion 
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
               Height          =   375
               Index           =   0
               Left            =   3480
               Picture         =   "COM_AsignaComisiones.frx":178C
               Style           =   1  'Graphical
               TabIndex        =   7
               Top             =   600
               Width           =   1215
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
               ItemData        =   "COM_AsignaComisiones.frx":1D9B
               Left            =   120
               List            =   "COM_AsignaComisiones.frx":1D9D
               Style           =   2  'Dropdown List
               TabIndex        =   6
               Top             =   600
               Width           =   3285
            End
            Begin MSComctlLib.ListView LstVDatos 
               Height          =   2145
               Index           =   1
               Left            =   120
               TabIndex        =   9
               Top             =   1080
               Width           =   10035
               _ExtentX        =   17701
               _ExtentY        =   3784
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
               Caption         =   "Cedis"
               Height          =   240
               Index           =   8
               Left            =   240
               TabIndex        =   31
               Top             =   360
               Width           =   495
            End
         End
         Begin VB.Frame FrmCategoria 
            BackColor       =   &H00FFFFFF&
            Height          =   3585
            Left            =   240
            TabIndex        =   25
            Top             =   600
            Width           =   12105
            Begin VB.ComboBox cmbStatus 
               Height          =   360
               ItemData        =   "COM_AsignaComisiones.frx":1D9F
               Left            =   6000
               List            =   "COM_AsignaComisiones.frx":1DA9
               Style           =   2  'Dropdown List
               TabIndex        =   1
               Top             =   480
               Width           =   1455
            End
            Begin VB.CommandButton CmdAccion 
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
               Index           =   2
               Left            =   7560
               Picture         =   "COM_AsignaComisiones.frx":1DBB
               Style           =   1  'Graphical
               TabIndex        =   2
               Top             =   360
               Width           =   1695
            End
            Begin VB.CommandButton CmdAccion 
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
               Index           =   3
               Left            =   9360
               Picture         =   "COM_AsignaComisiones.frx":2449
               Style           =   1  'Graphical
               TabIndex        =   3
               Top             =   360
               Width           =   1695
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
               Left            =   180
               MaxLength       =   100
               TabIndex        =   0
               Top             =   510
               Width           =   5745
            End
            Begin MSComctlLib.ListView LstVDatos 
               Height          =   2535
               Index           =   0
               Left            =   120
               TabIndex        =   32
               Top             =   960
               Width           =   11805
               _ExtentX        =   20823
               _ExtentY        =   4471
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
            Begin VB.Label LblEdicion 
               Alignment       =   1  'Right Justify
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
               Left            =   9765
               TabIndex        =   43
               Top             =   0
               Width           =   810
            End
            Begin VB.Label Label6 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Status"
               Height          =   255
               Left            =   6000
               TabIndex        =   29
               Top             =   240
               Width           =   1215
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Esquema"
               Height          =   240
               Index           =   7
               Left            =   180
               TabIndex        =   26
               Top             =   210
               Width           =   825
            End
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Esquemas de Pago de Comisiones"
            Height          =   240
            Index           =   0
            Left            =   360
            TabIndex        =   24
            Top             =   300
            Width           =   3060
         End
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Definición de Pagos"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   2
         Left            =   3110
         TabIndex        =   28
         Top             =   0
         Width           =   3155
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Esquemas de Comisiones"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   1
         Left            =   -75000
         TabIndex        =   23
         Top             =   0
         Width           =   3135
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Comisiones"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   0
         Left            =   5
         TabIndex        =   21
         Top             =   -600
         Width           =   4130
      End
   End
End
Attribute VB_Name = "COM_AsignaComisiones"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDEsquemas, IdComEsquema, LstDEsquemasCedis, LstDEsquemasRutas, LstDTipoVendedor, LstDConceptoPago
Dim lstDCedis, LstDRutas, LstDFamilias, LstDEsquemaFamilia, LstDEsquemaProducto, IdFamilia, StatusEsquema
Dim LstDPagos
Dim Inicial, Final

Private Sub btnAccion_Click(Index As Integer)
On Error Resume Next
Dim IdCedisTipoRuta
    
    If StatusEsquema = "B" Then
        MsgBox "¡ No puedes modificar un Esquema que está dado de Baja !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    Select Case Index
        Case 0, 1:
            If IsEmpty(LstDEsquemasCedis) And Index = 1 And OptAsigna(0).Value Then Exit Sub
            If IsEmpty(LstDEsquemasRutas) And Index = 1 And OptAsigna(1).Value Then Exit Sub
            
            If CmbDatos(1).ListIndex <= 0 And Index = 0 Then
                MsgBox "¡ Selecciona un elemento de la lista !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            If Index = 0 Then
                If OptAsigna(0).Value Then
                    IdCedisTipoRuta = lstDCedis(0, CmbDatos(1).ListIndex - 1)
                Else
                    IdCedisTipoRuta = LstDRutas(0, CmbDatos(1).ListIndex - 1)
                End If
            Else
                IdCedisTipoRuta = LstVDatos(1).SelectedItem
            End If
            
            StrCmd = "execute up_ComEsquema" & IIf(OptAsigna(0).Value, "Cedis", "TipoRuta") & " " & IdComEsquema & ", " & IdCedisTipoRuta & ", '" & IIf(Index = 0, "A", "B") & "', '" & Usuario & "', 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraCedisRutas
            'MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
        
        Case 2: 'quita rango de pago
            If LstVDatos(2).ListItems.Count <= 0 Then Exit Sub
            If MsgBox("¿ Deseas dar de baja el Rango de Pago seleccionado ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
            
            If OptAsigna(2).Value Then
                StrCmd = "execute up_ComEsquemaRangos " & IdComEsquema & ", " & LstVDatos(2).SelectedItem & ", 0, " & LstDEsquemaFamilia(9, LstVDatos(2).SelectedItem.Index - 1) & ", " & LstDEsquemaFamilia(3, LstVDatos(2).SelectedItem.Index - 1) & ", " & LstDEsquemaFamilia(4, LstVDatos(2).SelectedItem.Index - 1) & ", 'B', '" & Usuario & "', 2"
            Else
                StrCmd = "execute up_ComEsquemaRangos " & IdComEsquema & ", 0, " & LstVDatos(2).SelectedItem & ", " & LstDEsquemaProducto(9, LstVDatos(2).SelectedItem.Index - 1) & ", " & LstDEsquemaProducto(3, LstVDatos(2).SelectedItem.Index - 1) & ", " & LstDEsquemaProducto(4, LstVDatos(2).SelectedItem.Index - 1) & ", 'B', '" & Usuario & "', 2"
            End If
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraCombosAsigna 1

            
        Case 3: 'asigna rango de pago
        
            If CmbDatos(2).ListIndex = 0 Then
                MsgBox "¡ Selecciona un Concepto de pago !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            If OptAsigna(2).Value And CmbDatos(3).ListIndex = 0 Then
                MsgBox "¡ Selecciona una Familia de Producto !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            If OptAsigna(3).Value And TxtIdProducto1.Text = "" Then
                MsgBox "¡ Selecciona un Producto !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            If CDbl(TxtDatos(9).Text) >= CDbl(TxtDatos(8).Text) Then
                MsgBox "¡ El valor Inicial del Rango de Pago debe ser menor que el valor Final !", vbInformation + vbOKOnly, App.Title
                TxtDatos(8).Text = ""
                TxtDatos(8).SetFocus
                Exit Sub
            End If
            
            If OptAsigna(2).Value Then
                StrCmd = "execute up_ComEsquemaRangos " & IdComEsquema & ", " & LstDFamilias(0, CmbDatos(3).ListIndex - 1) & ", 0, " & LstDConceptoPago(0, CmbDatos(2).ListIndex - 1) & ", " & TxtDatos(9).Text & ", " & TxtDatos(8).Text & ", 'A', '" & Usuario & "', 1"
            Else
                StrCmd = "execute up_ComEsquemaRangos " & IdComEsquema & ", 0, " & TxtIdProducto1.Text & ", " & LstDConceptoPago(0, CmbDatos(2).ListIndex - 1) & ", " & TxtDatos(9).Text & ", " & TxtDatos(8).Text & ", 'A', '" & Usuario & "', 1"
            End If
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            TxtDatos(9).Text = "": TxtDatos(8).Text = ""
            MuestraCombosAsigna 1
    
        Case 4: 'asigna rango de pago
        
            If CmbDatos(0).ListIndex = 0 Then
                MsgBox "¡ Selecciona un Tipo de Vendedor !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            If TxtDatos(7).Text = "" Then
                MsgBox "¡ Teclea el importe del Pago !", vbInformation + vbOKOnly, App.Title
                TxtDatos(7).Text = ""
                TxtDatos(7).SetFocus
                Exit Sub
            End If
            
            If OptAsigna(2).Value Then
                StrCmd = "execute up_ComEsquemaPagos " & IdComEsquema & ", " & LstVDatos(2).SelectedItem & ", 0, " & LstDEsquemaFamilia(9, LstVDatos(2).SelectedItem.Index - 1) & ", " & LstDEsquemaFamilia(3, LstVDatos(2).SelectedItem.Index - 1) & ", " & LstDEsquemaFamilia(4, LstVDatos(2).SelectedItem.Index - 1) & ", " & LstDTipoVendedor(0, CmbDatos(0).ListIndex - 1) & ", " & TxtDatos(7).Text & ", 'A', '" & Usuario & "', 1"
            Else
                StrCmd = "execute up_ComEsquemaPagos " & IdComEsquema & ", 0, " & LstVDatos(2).SelectedItem & ", " & LstDEsquemaProducto(9, LstVDatos(2).SelectedItem.Index - 1) & ", " & LstDEsquemaProducto(3, LstVDatos(2).SelectedItem.Index - 1) & ", " & LstDEsquemaProducto(4, LstVDatos(2).SelectedItem.Index - 1) & ", " & LstDTipoVendedor(0, CmbDatos(0).ListIndex - 1) & ", " & TxtDatos(7).Text & ", 'A', '" & Usuario & "', 1"
            End If
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            TxtDatos(7).Text = ""
            MuestraPagos
    End Select
End Sub

Private Sub ChkMostrarTodo_Click()
On Error Resume Next
    OptAsigna_Click 3
End Sub

Private Sub CmbDatos_Click(Index As Integer)
On Error Resume Next
    Select Case Index
        Case 3:
            If Not IsEmpty(LstDFamilias) Then
                If CStr(IdFamilia) <> LstDFamilias(0, CmbDatos(Index).ListIndex - 1) Then
                    MuestraCombosAsigna 1
                    IdFamilia = LstDFamilias(0, CmbDatos(Index).ListIndex - 1)
                End If
            End If
        Case 0:
            'MuestraCombosAsigna 1
        Case 2:
            MuestraCombosAsigna 1
    End Select
End Sub

Private Sub CmdAccion_Click(Index As Integer)
On Error Resume Next
    Select Case Index
        Case 2:
            TxtDatos(4).Text = ""
            LblEdicion.Caption = "Nuevo"
        Case 3:
            If LblEdicion.Caption = "Consultar" Then Exit Sub
            If Trim(TxtDatos(4).Text) = "" Then
                MsgBox "¡ Teclee los datos del Esquema de Pago !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            StrCmd = "execute up_ComEsquema " & IdComEsquema & ", '" & Trim(TxtDatos(4).Text) & "', '" & Mid(cmbStatus.Text, 1, 1) & "', '" & Usuario & "', " & IIf(LblEdicion.Caption = "Nuevo", 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraEsquemas
            'MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
    End Select
End Sub

Private Sub Form_Load()
On Error Resume Next
    SSTab.Tab = 0
    IdComEsquema = 0: IdFamilia = 0
    SSTab_Click 0
End Sub

Sub MuestraEsquemas()
On Error Resume Next
    StrCmd = "execute sel_ComEsquema 0, 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDEsquemas = GetDataLVL(Rs, LstVDatos(0), 0, 4, "0|0|0|0|0")
    LstVDatos_ItemClick 0, LstVDatos(0).ListItems(1)
End Sub

Sub MuestraCedisRutas()
On Error Resume Next

    LblTitulos(8).Caption = IIf(OptAsigna(0).Value, "Cedis", "Especialización de la Ruta")
    If OptAsigna(0).Value Then
        StrCmd = "execute sel_ComEsquemaCedis " & IdComEsquema & ", 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        lstDCedis = GetDataCBL(Rs, CmbDatos(1), "Selecciona un elemento", "No existen elementos")
        
        StrCmd = "execute sel_ComEsquemaCedis " & IdComEsquema & ", 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        LstDEsquemasCedis = GetDataLVL(Rs, LstVDatos(1), 0, 3, "0|0|0|0")
    End If
    If OptAsigna(1).Value Then
        StrCmd = "execute sel_ComEsquemaTipoRuta " & IdComEsquema & ", 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        LstDRutas = GetDataCBL(Rs, CmbDatos(1), "Selecciona un elemento", "No existen elementos")
        
        StrCmd = "execute sel_ComEsquemaTipoRuta " & IdComEsquema & ", 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        LstDEsquemasRutas = GetDataLVL(Rs, LstVDatos(1), 0, 3, "0|0|0|0")
    End If
End Sub

Private Sub LstVDatos_DblClick(Index As Integer)
On Error Resume Next
    Select Case Index
        Case 0: LblEdicion.Caption = "Actualizar"
    End Select
End Sub

Private Sub LstVDatos_ItemClick(Index As Integer, ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    
    Select Case Index
        Case 0:
            IdComEsquema = LstVDatos(0).SelectedItem
            StatusEsquema = Mid(LstVDatos(0).SelectedItem.ListSubItems(2), 1, 1)
            TxtDatos(4).Text = LstVDatos(0).SelectedItem.ListSubItems(1).Text
            cmbStatus.ListIndex = IIf(Mid(LstVDatos(0).SelectedItem.ListSubItems(2), 1, 1) = "A", 0, 1)
            LblEsquema(0).Caption = "Esquema: " & LstVDatos(0).SelectedItem.ListSubItems(1).Text
            LblEdicion.Caption = "Consultar"
            MuestraCedisRutas
        Case 2:
            MuestraPagos
    End Select
End Sub

Sub MuestraPagos()
On Error Resume Next
    If OptAsigna(2).Value Then
        StrCmd = "execute sel_ComEsquemaPagos " & IdComEsquema & ", " & LstVDatos(2).SelectedItem & ", 0, " & LstDEsquemaFamilia(9, LstVDatos(2).SelectedItem.Index - 1) & ", " & LstDEsquemaFamilia(3, LstVDatos(2).SelectedItem.Index - 1) & ", " & LstDEsquemaFamilia(4, LstVDatos(2).SelectedItem.Index - 1) & ", 1"
    Else
        StrCmd = "execute sel_ComEsquemaPagos " & IdComEsquema & ", 0, " & LstVDatos(2).SelectedItem & ", " & LstDEsquemaProducto(9, LstVDatos(2).SelectedItem.Index - 1) & ", " & LstDEsquemaProducto(3, LstVDatos(2).SelectedItem.Index - 1) & ", " & LstDEsquemaProducto(4, LstVDatos(2).SelectedItem.Index - 1) & ", 1"
    End If
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDPagos = GetDataLVL(Rs, LstVDatos(3), 0, 6, "0|9|9|9|0|0|0")
End Sub

Private Sub OptAsigna_Click(Index As Integer)
On Error Resume Next
    Select Case Index
        Case 0, 1: MuestraCedisRutas
        Case 2, 3:
            Frm(0).Visible = IIf(Index = 2, True, False)
            Frm(1).Visible = IIf(Index = 3, True, False)
            MuestraCombosAsigna 1
            ChkMostrarTodo.Enabled = IIf(Index = 3, True, False)
    End Select
End Sub

Private Sub SSTab_Click(PreviousTab As Integer)
On Error Resume Next

    Select Case SSTab.Tab
        Case 0:
            MuestraEsquemas
        Case 1:
            If IdComEsquema = 0 Then
                MsgBox "¡ Selecciona un Esquema !", vbInformation + vbOKOnly, App.Title
                SSTab.Tab = 0
                Exit Sub
            End If
            If Not ValidaCedisRutas Then
                MsgBox "¡ Debes Asignar al menos un Cedis y un Tipo de Ruta para el que aplica el Esquema de Pago !", vbInformation + vbOKOnly, App.Title
                SSTab.Tab = 0
                Exit Sub
            End If
            MuestraCombosDatos
'            MuestraCombosAsigna 0
    End Select
End Sub

Function ValidaCedisRutas() As Boolean
On Error Resume Next
    Dim LstDValida
    ValidaCedisRutas = True
    
    StrCmd = "execute sel_ComEsquemaFamilia " & IdCedis & ", " & IdComEsquema & ", '0', '0', '0', 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Rs.EOF Then ValidaCedisRutas = False
    If Not Rs.EOF Then
        LstDValida = Rs.GetRows
        If UBound(LstDValida, 2) < 1 Then ValidaCedisRutas = False
    End If
End Function

Sub MuestraCombosAsigna(Opc As Integer)
On Error Resume Next

Dim IdFam, IdConP, IdTipoV, IdProd

    LstVDatos(3).ListItems.Clear

    If CmbDatos(2).ListIndex <= 0 Then
        IdConP = "0"
    Else
        IdConP = LstDConceptoPago(0, CmbDatos(2).ListIndex - 1)
    End If
    If CmbDatos(0).ListIndex <= 0 Then
        IdTipoV = "0"
    Else
        IdTipoV = LstDTipoVendedor(0, CmbDatos(0).ListIndex - 1)
    End If
    
    If OptAsigna(2).Value Then
        If IsEmpty(LstDFamilias) Then
            StrCmd = "execute sel_ComEsquemaFamilia " & IdCedis & ", " & IdComEsquema & ", '0', '0', '0', 2"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            LstDFamilias = GetDataCBL(Rs, CmbDatos(3), "Selecciona un elemento", "No existen elementos")
        End If
        
        If Not IsEmpty(LstDFamilias) Then
            StrCmd = "execute sel_ComEsquemaFamilia " & IdCedis & ", " & IdComEsquema & ", '0', '0', '0', 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            If Not Rs.EOF Then
                CmbDatos(2).Locked = True
                For i = 1 To CmbDatos(2).ListCount
                    If CStr(LstDConceptoPago(0, i - 1)) = CStr(Rs.Fields(0)) Then
                        CmbDatos(2).ListIndex = i
                        Exit For
                    End If
                Next i
            Else
                CmbDatos(2).Locked = False
            End If
        End If
        
        If CmbDatos(3).ListIndex <= 0 Then
            IdFam = "0"
        Else
            IdFam = LstDFamilias(0, CmbDatos(3).ListIndex - 1)
        End If
        
        StrCmd = "execute sel_ComEsquemaFamilia " & IdCedis & ", " & IdComEsquema & ", '" & IdFam & "', '', '" & IdConP & "', 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        LstDEsquemaFamilia = GetDataLVL(Rs, LstVDatos(2), 0, 7, "0|0|0|9|9|0|0|0")
    
        StrCmd = "execute up_ComEsquemaRangos " & IdComEsquema & ", '" & IdFam & "', '0', '" & IdConP & "', 0, 0, '', '', 3"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then LblMensaje.Caption = Rs.Fields(0)
    End If
    If OptAsigna(3).Value Then
        
        IdProd = IIf(Trim(TxtIdProducto1.Text) = "" Or ChkMostrarTodo.Value, "0", Trim(TxtIdProducto1.Text))
            
        StrCmd = "execute sel_ComEsquemaFamilia " & IdCedis & ", " & IdComEsquema & ", '0', '0', '0', 3"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            CmbDatos(2).Locked = True
            For i = 1 To CmbDatos(2).ListCount
                If CStr(LstDConceptoPago(0, i - 1)) = CStr(Rs.Fields(0)) Then
                    CmbDatos(2).ListIndex = i
                    Exit For
                End If
            Next i
        Else
            CmbDatos(2).Locked = False
        End If
        
        StrCmd = "execute sel_ComEsquemaProducto " & IdCedis & ", " & IdComEsquema & ", '" & IdProd & "', '', '" & IdConP & "', 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        LstDEsquemaProducto = GetDataLVL(Rs, LstVDatos(2), 0, 7, "0|0|0|9|9|0|0|0")
    
        StrCmd = "execute up_ComEsquemaRangos " & IdComEsquema & ", 0, '" & IdProd & "', '" & IdConP & "', 0, 0, '', '', 3"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then LblMensaje.Caption = Rs.Fields(0)
    End If
    LstVDatos_ItemClick 2, LstVDatos(2).SelectedItem
End Sub

Sub MuestraCombosDatos()
On Error Resume Next

    StrCmd = "execute sel_TipoVendedor "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDTipoVendedor = GetDataCBL(Rs, CmbDatos(0), "Selecciona un Tipo de Vendedor", "No existen elementos")
        
    StrCmd = "execute sel_ConceptoPago " & IdCedis & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDConceptoPago = GetDataCBL(Rs, CmbDatos(2), "Selecciona un Concepto de Pago", "No existen elementos")
        
End Sub

Private Sub TxtDatos_Change(Index As Integer)
On Error Resume Next
'    Select Case Index
'        Case 9, 8, 7: SelText TxtDatos(Index)
'    End Select
End Sub

Private Sub TxtDatos_GotFocus(Index As Integer)
On Error Resume Next
    Select Case Index
        Case 7, 8, 9: SelText TxtDatos(Index)
    End Select
End Sub

Private Sub TxtDatos_KeyPress(Index As Integer, KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        Select Case Index
            Case 7: btnAccion_Click 4
            Case 8: btnAccion_Click 3
            Case 9: TxtDatos(8).SetFocus
        End Select
    End If
    
    Select Case Index
        Case 4: KeyAscii = itString(KeyAscii)
        Case 7, 8, 9: KeyAscii = itDecimal(KeyAscii)
    End Select
End Sub

Private Sub TxtDatos_Validate(Index As Integer, Cancel As Boolean)
On Error Resume Next
    Select Case Index
        Case 7, 8, 9: TxtDatos(Index) = itFlotante(TxtDatos(Index))
    End Select
End Sub

Private Sub TxtIdProducto1_GotFocus()
On Error Resume Next
    SelText TxtIdProducto1
End Sub

Private Sub TxtIdProducto1_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        BuscaProdCom 1
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Sub BuscaProdCom(Opc As Integer)
On Error Resume Next

    If Opc = 1 Then
        StrCmd = "execute sel_ComEsquemaProducto " & IdCedis & ", " & IdComEsquema & ", '" & TxtIdProducto1.Text & "', '', '', 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            TxtProducto1.Text = Rs.Fields(1): TxtDatos(9).SetFocus
        Else
            TxtProducto1.Text = "¡ El Producto no existe !": TxtIdProducto1.SetFocus
        End If
    End If

End Sub

