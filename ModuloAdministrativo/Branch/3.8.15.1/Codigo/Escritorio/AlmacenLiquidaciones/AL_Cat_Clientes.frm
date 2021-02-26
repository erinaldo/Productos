VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form AL_Cat_Clientes 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   8430
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   11325
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
   ScaleWidth      =   11325
   ShowInTaskbar   =   0   'False
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
      Picture         =   "AL_Cat_Clientes.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   61
      Top             =   7800
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
      Left            =   240
      Picture         =   "AL_Cat_Clientes.frx":0996
      Style           =   1  'Graphical
      TabIndex        =   60
      Top             =   7800
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
      Left            =   5640
      Picture         =   "AL_Cat_Clientes.frx":1024
      Style           =   1  'Graphical
      TabIndex        =   63
      Top             =   7800
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
      Left            =   3840
      Picture         =   "AL_Cat_Clientes.frx":173F
      Style           =   1  'Graphical
      TabIndex        =   62
      Top             =   7800
      Width           =   1695
   End
   Begin TabDlg.SSTab SSTab 
      Height          =   7485
      Left            =   120
      TabIndex        =   68
      Top             =   120
      Width           =   11145
      _ExtentX        =   19659
      _ExtentY        =   13203
      _Version        =   393216
      Tabs            =   5
      Tab             =   4
      TabsPerRow      =   5
      TabHeight       =   520
      TabCaption(0)   =   "Canales de Distribución"
      TabPicture(0)   =   "AL_Cat_Clientes.frx":1E4F
      Tab(0).ControlEnabled=   0   'False
      Tab(0).Control(0)=   "FrmOpt(1)"
      Tab(0).Control(1)=   "LblOpt(0)"
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "Cadenas de Clientes"
      TabPicture(1)   =   "AL_Cat_Clientes.frx":1E6B
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "FrmOpt(0)"
      Tab(1).Control(1)=   "LblOpt(3)"
      Tab(1).ControlCount=   2
      TabCaption(2)   =   "Grupo de Clientes"
      TabPicture(2)   =   "AL_Cat_Clientes.frx":1E87
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "FrmOpt(3)"
      Tab(2).Control(1)=   "LblOpt(1)"
      Tab(2).ControlCount=   2
      TabCaption(3)   =   "Clientes"
      TabPicture(3)   =   "AL_Cat_Clientes.frx":1EA3
      Tab(3).ControlEnabled=   0   'False
      Tab(3).Control(0)=   "FrmOpt(2)"
      Tab(3).Control(1)=   "LblOpt(2)"
      Tab(3).ControlCount=   2
      TabCaption(4)   =   "Sucursales"
      TabPicture(4)   =   "AL_Cat_Clientes.frx":1EBF
      Tab(4).ControlEnabled=   -1  'True
      Tab(4).Control(0)=   "LblOpt(4)"
      Tab(4).Control(0).Enabled=   0   'False
      Tab(4).Control(1)=   "FrmOpt(4)"
      Tab(4).Control(1).Enabled=   0   'False
      Tab(4).Control(2)=   "OptDomicilio(1)"
      Tab(4).Control(2).Enabled=   0   'False
      Tab(4).Control(3)=   "OptDomicilio(0)"
      Tab(4).Control(3).Enabled=   0   'False
      Tab(4).ControlCount=   4
      Begin VB.OptionButton OptDomicilio 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Domicilio Fiscal"
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
         Left            =   2640
         TabIndex        =   135
         Top             =   5160
         Width           =   1815
      End
      Begin VB.OptionButton OptDomicilio 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Domicilio de Entrega"
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
         Left            =   240
         TabIndex        =   134
         Top             =   5160
         Value           =   -1  'True
         Width           =   2295
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
         Height          =   7170
         Index           =   4
         Left            =   0
         TabIndex        =   94
         Top             =   315
         Width           =   11145
         Begin VB.TextBox TxtFIdSucursal 
            Height          =   360
            Left            =   240
            TabIndex        =   144
            Top             =   960
            Width           =   1215
         End
         Begin VB.TextBox TxtFNombreSucursal 
            Height          =   360
            Left            =   3840
            TabIndex        =   143
            Top             =   960
            Width           =   3135
         End
         Begin VB.TextBox TxtFRFC 
            Height          =   360
            Left            =   1680
            TabIndex        =   142
            Top             =   960
            Width           =   1935
         End
         Begin VB.TextBox TxtFCalle 
            Height          =   360
            Left            =   7170
            TabIndex        =   141
            Top             =   960
            Width           =   3135
         End
         Begin VB.Frame FrmDomicilio 
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
            Height          =   2175
            Index           =   1
            Left            =   120
            TabIndex        =   114
            Top             =   4920
            Width           =   10935
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
               Index           =   30
               Left            =   1320
               MaxLength       =   5
               TabIndex        =   35
               Top             =   480
               Width           =   945
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
               Index           =   3
               Left            =   120
               MaxLength       =   13
               TabIndex        =   34
               Top             =   480
               Width           =   1155
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
               Index           =   18
               Left            =   3840
               MaxLength       =   100
               TabIndex        =   43
               Top             =   1740
               Width           =   2475
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
               Index           =   26
               Left            =   2280
               MaxLength       =   250
               TabIndex        =   36
               Top             =   480
               Width           =   6675
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
               Index           =   25
               Left            =   9000
               MaxLength       =   20
               TabIndex        =   37
               Top             =   480
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
               Index           =   24
               Left            =   10050
               MaxLength       =   20
               TabIndex        =   38
               Top             =   480
               Width           =   795
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
               Index           =   23
               Left            =   120
               MaxLength       =   100
               TabIndex        =   39
               Top             =   1110
               Width           =   3555
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
               Index           =   22
               Left            =   9540
               MaxLength       =   5
               TabIndex        =   45
               Top             =   1710
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
               Index           =   21
               Left            =   7260
               MaxLength       =   50
               TabIndex        =   41
               Top             =   1080
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
               Index           =   20
               Left            =   120
               MaxLength       =   50
               TabIndex        =   42
               Top             =   1740
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
               Index           =   19
               Left            =   6480
               MaxLength       =   100
               TabIndex        =   44
               Top             =   1740
               Width           =   2955
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
               Index           =   16
               Left            =   3810
               MaxLength       =   100
               TabIndex        =   40
               Top             =   1080
               Width           =   3315
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "CRTienda"
               Height          =   240
               Index           =   21
               Left            =   1350
               TabIndex        =   140
               Top             =   240
               Width           =   840
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "TDA/GLN"
               Height          =   240
               Index           =   26
               Left            =   150
               TabIndex        =   139
               Top             =   240
               Width           =   825
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Pais *"
               Height          =   240
               Index           =   9
               Left            =   3840
               TabIndex        =   131
               Top             =   1500
               Width           =   525
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Calle *"
               Height          =   240
               Index           =   17
               Left            =   2310
               TabIndex        =   123
               Top             =   240
               Width           =   570
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "# Exterior *"
               Height          =   240
               Index           =   16
               Left            =   9030
               TabIndex        =   122
               Top             =   240
               Width           =   975
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "# Interior"
               Height          =   240
               Index           =   15
               Left            =   10080
               TabIndex        =   121
               Top             =   240
               Width           =   750
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Colonia *"
               Height          =   240
               Index           =   14
               Left            =   150
               TabIndex        =   120
               Top             =   870
               Width           =   780
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Código Postal*"
               Height          =   240
               Index           =   13
               Left            =   9450
               TabIndex        =   119
               Top             =   1470
               Width           =   1290
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Población *"
               Height          =   240
               Index           =   12
               Left            =   7290
               TabIndex        =   118
               Top             =   840
               Width           =   990
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Entidad *"
               Height          =   240
               Index           =   11
               Left            =   150
               TabIndex        =   117
               Top             =   1500
               Width           =   795
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Teléfonos"
               Height          =   240
               Index           =   10
               Left            =   6540
               TabIndex        =   116
               Top             =   1500
               Width           =   825
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Localidad"
               Height          =   240
               Index           =   7
               Left            =   3840
               TabIndex        =   115
               Top             =   840
               Width           =   825
            End
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
            Index           =   29
            Left            =   8640
            MaxLength       =   20
            TabIndex        =   30
            Text            =   "0"
            Top             =   4410
            Width           =   1035
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
            Index           =   28
            Left            =   7680
            MaxLength       =   20
            TabIndex        =   29
            Text            =   "0"
            Top             =   4410
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
            Index           =   27
            Left            =   8640
            MaxLength       =   250
            TabIndex        =   25
            Top             =   3690
            Width           =   2355
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
            Index           =   5
            Left            =   4320
            MaxLength       =   13
            TabIndex        =   23
            Top             =   3690
            Width           =   1305
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
            Index           =   14
            Left            =   5730
            MaxLength       =   250
            TabIndex        =   24
            Top             =   3690
            Width           =   2835
         End
         Begin VB.Frame FrmDomicilio 
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
            Height          =   2175
            Index           =   0
            Left            =   120
            TabIndex        =   104
            Top             =   4920
            Visible         =   0   'False
            Width           =   10935
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
               Index           =   17
               Left            =   3840
               MaxLength       =   100
               TabIndex        =   53
               Top             =   1740
               Width           =   2475
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
               Index           =   15
               Left            =   3840
               MaxLength       =   100
               TabIndex        =   50
               Top             =   1080
               Width           =   3315
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
               Left            =   6480
               MaxLength       =   100
               TabIndex        =   54
               Top             =   1740
               Width           =   2955
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
               Left            =   120
               MaxLength       =   50
               TabIndex        =   52
               Top             =   1740
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
               Index           =   11
               Left            =   7260
               MaxLength       =   50
               TabIndex        =   51
               Top             =   1080
               Width           =   3585
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
               Left            =   9480
               MaxLength       =   5
               TabIndex        =   55
               Top             =   1740
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
               Index           =   9
               Left            =   120
               MaxLength       =   100
               TabIndex        =   49
               Top             =   1110
               Width           =   3555
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
               Left            =   10050
               MaxLength       =   20
               TabIndex        =   48
               Top             =   480
               Width           =   795
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
               Left            =   9000
               MaxLength       =   20
               TabIndex        =   47
               Top             =   480
               Width           =   945
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
               Left            =   120
               MaxLength       =   250
               TabIndex        =   46
               Top             =   480
               Width           =   8715
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Pais *"
               Height          =   240
               Index           =   8
               Left            =   3840
               TabIndex        =   130
               Top             =   1500
               Width           =   525
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Localidad"
               Height          =   240
               Index           =   6
               Left            =   3840
               TabIndex        =   113
               Top             =   840
               Width           =   825
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Teléfonos"
               Height          =   240
               Index           =   35
               Left            =   6540
               TabIndex        =   112
               Top             =   1500
               Width           =   825
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Entidad *"
               Height          =   240
               Index           =   34
               Left            =   150
               TabIndex        =   111
               Top             =   1500
               Width           =   795
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Población *"
               Height          =   240
               Index           =   33
               Left            =   7290
               TabIndex        =   110
               Top             =   840
               Width           =   990
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Código Postal*"
               Height          =   240
               Index           =   32
               Left            =   9450
               TabIndex        =   109
               Top             =   1470
               Width           =   1290
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Colonia *"
               Height          =   240
               Index           =   31
               Left            =   150
               TabIndex        =   108
               Top             =   870
               Width           =   780
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "# Interior"
               Height          =   240
               Index           =   30
               Left            =   10080
               TabIndex        =   107
               Top             =   240
               Width           =   750
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "# Exterior *"
               Height          =   240
               Index           =   29
               Left            =   9030
               TabIndex        =   106
               Top             =   240
               Width           =   975
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Calle (Domicilio Fiscal) *"
               Height          =   240
               Index           =   28
               Left            =   150
               TabIndex        =   105
               Top             =   240
               Width           =   2130
            End
         End
         Begin VB.ComboBox Combo3 
            Height          =   360
            Left            =   8160
            Style           =   2  'Dropdown List
            TabIndex        =   129
            Top             =   4920
            Visible         =   0   'False
            Width           =   2625
         End
         Begin VB.ComboBox Combo2 
            Height          =   360
            Left            =   7200
            Style           =   2  'Dropdown List
            TabIndex        =   128
            Top             =   4920
            Visible         =   0   'False
            Width           =   2625
         End
         Begin VB.ComboBox Combo1 
            CausesValidation=   0   'False
            Height          =   360
            ItemData        =   "AL_Cat_Clientes.frx":1EDB
            Left            =   6600
            List            =   "AL_Cat_Clientes.frx":1EDD
            Style           =   2  'Dropdown List
            TabIndex        =   127
            Top             =   4920
            Visible         =   0   'False
            Width           =   2625
         End
         Begin VB.OptionButton OptDatos 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Suspendido"
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
            Index           =   2
            Left            =   9720
            TabIndex        =   33
            Top             =   4620
            Width           =   1365
         End
         Begin VB.CommandButton btnSeleccionaCte 
            BackColor       =   &H00FFFFFF&
            Caption         =   "..."
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   300
            Left            =   120
            Style           =   1  'Graphical
            TabIndex        =   17
            Top             =   285
            Width           =   375
         End
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
            Height          =   225
            Index           =   1
            Left            =   9720
            TabIndex        =   32
            Top             =   4380
            Width           =   765
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
            Height          =   225
            Index           =   0
            Left            =   9720
            TabIndex        =   31
            Top             =   4120
            Width           =   765
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
            Left            =   4020
            MaxLength       =   64
            TabIndex        =   27
            Top             =   4410
            Width           =   1725
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
            Left            =   5850
            Style           =   2  'Dropdown List
            TabIndex        =   28
            Top             =   4410
            Width           =   1725
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
            Locked          =   -1  'True
            Style           =   2  'Dropdown List
            TabIndex        =   21
            Top             =   3690
            Width           =   1785
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
            TabIndex        =   20
            Top             =   3690
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
            Left            =   3120
            MaxLength       =   10
            TabIndex        =   22
            Top             =   3690
            Width           =   1155
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
            MaxLength       =   32
            TabIndex        =   26
            Top             =   4410
            Width           =   3705
         End
         Begin MSComctlLib.ListView LstVDatos 
            Height          =   315
            Index           =   0
            Left            =   630
            TabIndex        =   18
            Top             =   285
            Visible         =   0   'False
            Width           =   10335
            _ExtentX        =   18230
            _ExtentY        =   556
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
            Height          =   1905
            Index           =   1
            Left            =   150
            TabIndex        =   19
            Top             =   1350
            Width           =   10815
            _ExtentX        =   19076
            _ExtentY        =   3360
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
            Caption         =   "ID Sucursal"
            Height          =   240
            Index           =   38
            Left            =   150
            TabIndex        =   148
            Top             =   720
            Width           =   1005
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Nombre de la Sucursal "
            Height          =   240
            Index           =   37
            Left            =   3750
            TabIndex        =   147
            Top             =   720
            Width           =   2040
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "RFC"
            Height          =   240
            Index           =   23
            Left            =   1560
            TabIndex        =   146
            Top             =   720
            Width           =   390
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Calle "
            Height          =   240
            Index           =   24
            Left            =   7080
            TabIndex        =   145
            Top             =   720
            Width           =   495
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Crédito"
            Height          =   240
            Index           =   20
            Left            =   9000
            TabIndex        =   138
            Top             =   4200
            Width           =   615
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Días Cred."
            Height          =   240
            Index           =   19
            Left            =   7680
            TabIndex        =   137
            Top             =   4200
            Width           =   915
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Contacto *"
            Height          =   240
            Index           =   18
            Left            =   8670
            TabIndex        =   136
            Top             =   3450
            Width           =   915
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "RFC *"
            Height          =   240
            Index           =   36
            Left            =   4350
            TabIndex        =   133
            Top             =   3450
            Width           =   525
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Razón Social *"
            Height          =   240
            Index           =   5
            Left            =   5760
            TabIndex        =   132
            Top             =   3450
            Width           =   1290
         End
         Begin VB.Label LblTitulos 
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "< Selecciona un cliente >"
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
            Index           =   4
            Left            =   720
            TabIndex        =   103
            Top             =   360
            Width           =   10215
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Status"
            Height          =   240
            Index           =   3
            Left            =   10440
            TabIndex        =   101
            Top             =   4320
            Visible         =   0   'False
            Width           =   570
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "C. de Barras *"
            Height          =   240
            Index           =   2
            Left            =   4050
            TabIndex        =   100
            Top             =   4170
            Width           =   1230
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Tipo de Venta"
            Height          =   240
            Index           =   1
            Left            =   5880
            TabIndex        =   99
            Top             =   4170
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
            TabIndex        =   98
            Top             =   3450
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
            TabIndex        =   97
            Top             =   3450
            Width           =   840
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "ID Sucursal"
            Height          =   240
            Index           =   25
            Left            =   3150
            TabIndex        =   96
            Top             =   3450
            Width           =   1005
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Nombre de la Sucursal *"
            Height          =   240
            Index           =   27
            Left            =   180
            TabIndex        =   95
            Top             =   4170
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
         Height          =   7170
         Index           =   3
         Left            =   -75000
         TabIndex        =   90
         Top             =   320
         Width           =   11145
         Begin VB.TextBox TxtGrupo 
            Height          =   375
            Left            =   1710
            TabIndex        =   6
            Top             =   480
            Width           =   9285
         End
         Begin VB.TextBox TxtIdGrupo 
            Alignment       =   2  'Center
            Enabled         =   0   'False
            Height          =   375
            Left            =   150
            Locked          =   -1  'True
            MaxLength       =   5
            TabIndex        =   5
            Top             =   480
            Width           =   1425
         End
         Begin MSComctlLib.ListView LstGrupo 
            Height          =   6165
            Left            =   150
            TabIndex        =   67
            Top             =   960
            Width           =   10815
            _ExtentX        =   19076
            _ExtentY        =   10874
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
            Caption         =   "Grupo de Clientes"
            Height          =   240
            Left            =   1710
            TabIndex        =   92
            Top             =   240
            Width           =   1560
         End
         Begin VB.Label Label10 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clave"
            Height          =   375
            Left            =   210
            TabIndex        =   91
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
         Height          =   7170
         Index           =   2
         Left            =   -75000
         TabIndex        =   78
         Top             =   315
         Width           =   11145
         Begin VB.OptionButton OptStatus 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Activo"
            Height          =   255
            Index           =   0
            Left            =   8760
            TabIndex        =   15
            Top             =   1800
            Value           =   -1  'True
            Width           =   855
         End
         Begin VB.OptionButton OptStatus 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Baja"
            Height          =   255
            Index           =   1
            Left            =   9720
            TabIndex        =   16
            Top             =   1800
            Width           =   735
         End
         Begin VB.ComboBox CboCadena2 
            CausesValidation=   0   'False
            Height          =   360
            ItemData        =   "AL_Cat_Clientes.frx":1EDF
            Left            =   2880
            List            =   "AL_Cat_Clientes.frx":1EE1
            Style           =   2  'Dropdown List
            TabIndex        =   13
            Top             =   1800
            Width           =   2625
         End
         Begin VB.ComboBox CboCanal2 
            Height          =   360
            Left            =   120
            Style           =   2  'Dropdown List
            TabIndex        =   12
            Top             =   1800
            Width           =   2625
         End
         Begin VB.ComboBox CboGrupo 
            Height          =   360
            Left            =   5640
            Style           =   2  'Dropdown List
            TabIndex        =   14
            Top             =   1800
            Width           =   2625
         End
         Begin VB.TextBox TxtNom 
            Height          =   375
            Left            =   4800
            MaxLength       =   500
            TabIndex        =   9
            Top             =   480
            Width           =   6135
         End
         Begin VB.TextBox TxtIdCliente 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   150
            MaxLength       =   8
            TabIndex        =   7
            Top             =   480
            Width           =   1695
         End
         Begin VB.TextBox TxtRFC 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   2010
            MaxLength       =   13
            TabIndex        =   8
            Top             =   480
            Width           =   2625
         End
         Begin VB.TextBox TxtTel 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   8310
            MaxLength       =   100
            TabIndex        =   11
            Top             =   1080
            Width           =   2655
         End
         Begin VB.TextBox TxtDom1 
            Height          =   375
            Left            =   120
            MaxLength       =   500
            TabIndex        =   10
            Top             =   1080
            Width           =   8055
         End
         Begin VB.TextBox TxtContacto 
            Height          =   375
            Left            =   750
            MaxLength       =   300
            TabIndex        =   56
            Top             =   3960
            Visible         =   0   'False
            Width           =   4575
         End
         Begin VB.TextBox TxtCorreo 
            Height          =   375
            Left            =   5610
            MaxLength       =   100
            TabIndex        =   57
            Top             =   3960
            Visible         =   0   'False
            Width           =   3255
         End
         Begin VB.TextBox TxtWeb 
            Height          =   375
            Left            =   750
            MaxLength       =   200
            TabIndex        =   59
            Top             =   5160
            Visible         =   0   'False
            Width           =   4815
         End
         Begin VB.TextBox TxtDom2 
            Height          =   375
            Left            =   750
            MaxLength       =   1000
            TabIndex        =   58
            Top             =   4560
            Visible         =   0   'False
            Width           =   7935
         End
         Begin MSComctlLib.ListView LstCliente 
            Height          =   4605
            Left            =   150
            TabIndex        =   64
            Top             =   2400
            Width           =   10815
            _ExtentX        =   19076
            _ExtentY        =   8123
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
         Begin VB.Label Label14 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cadena"
            Height          =   240
            Left            =   2880
            TabIndex        =   126
            Top             =   1560
            Width           =   660
         End
         Begin VB.Label Label8 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Canal"
            Height          =   240
            Left            =   120
            TabIndex        =   125
            Top             =   1560
            Width           =   495
         End
         Begin VB.Label Label20 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Grupo de Clientes"
            Height          =   240
            Left            =   5640
            TabIndex        =   124
            Top             =   1560
            Width           =   1560
         End
         Begin VB.Label Label7 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clave"
            Height          =   375
            Left            =   150
            TabIndex        =   87
            Top             =   240
            Width           =   615
         End
         Begin VB.Label Label9 
            BackColor       =   &H00FFFFFF&
            Caption         =   "RFC"
            Height          =   255
            Left            =   2010
            TabIndex        =   86
            Top             =   240
            Width           =   375
         End
         Begin VB.Label Label11 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Razón Social"
            Height          =   240
            Left            =   4800
            TabIndex        =   85
            Top             =   240
            Width           =   1155
         End
         Begin VB.Label Label12 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Teléfono"
            Height          =   255
            Left            =   8310
            TabIndex        =   84
            Top             =   840
            Width           =   975
         End
         Begin VB.Label Label13 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Domicilio"
            Height          =   240
            Left            =   120
            TabIndex        =   83
            Top             =   840
            Width           =   795
         End
         Begin VB.Label Label15 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Contacto"
            Height          =   240
            Left            =   750
            TabIndex        =   82
            Top             =   3720
            Visible         =   0   'False
            Width           =   780
         End
         Begin VB.Label Label16 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Correo Electrónico"
            Height          =   240
            Left            =   5610
            TabIndex        =   81
            Top             =   3720
            Visible         =   0   'False
            Width           =   1605
         End
         Begin VB.Label Label17 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Página Web"
            Height          =   240
            Left            =   750
            TabIndex        =   80
            Top             =   4920
            Visible         =   0   'False
            Width           =   1065
         End
         Begin VB.Label Label18 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Domicilio de Entrega"
            Height          =   240
            Left            =   750
            TabIndex        =   79
            Top             =   4320
            Visible         =   0   'False
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
         Height          =   7170
         Index           =   0
         Left            =   -75000
         TabIndex        =   71
         Top             =   320
         Width           =   11145
         Begin VB.ComboBox CboCanal1 
            Height          =   360
            Left            =   8280
            Style           =   2  'Dropdown List
            TabIndex        =   4
            Top             =   480
            Width           =   2715
         End
         Begin VB.TextBox TxtIdCadena 
            Alignment       =   2  'Center
            Enabled         =   0   'False
            Height          =   375
            Left            =   150
            Locked          =   -1  'True
            MaxLength       =   5
            TabIndex        =   2
            Top             =   480
            Width           =   945
         End
         Begin VB.TextBox TxtCadena 
            Height          =   375
            Left            =   1230
            TabIndex        =   3
            Top             =   480
            Width           =   6915
         End
         Begin MSComctlLib.ListView LstCadena 
            Height          =   6135
            Left            =   150
            TabIndex        =   66
            Top             =   960
            Width           =   10815
            _ExtentX        =   19076
            _ExtentY        =   10821
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
            TabIndex        =   76
            Top             =   240
            Width           =   2025
         End
         Begin VB.Label Label2 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clave"
            Height          =   375
            Left            =   210
            TabIndex        =   75
            Top             =   240
            Width           =   615
         End
         Begin VB.Label Label1 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cadena de Clientes"
            Height          =   240
            Left            =   1260
            TabIndex        =   74
            Top             =   240
            Width           =   1695
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
         Height          =   7170
         Index           =   1
         Left            =   -75000
         TabIndex        =   70
         Top             =   320
         Width           =   11145
         Begin VB.TextBox TxtIdCanal 
            Height          =   375
            Left            =   120
            TabIndex        =   0
            Top             =   480
            Width           =   1545
         End
         Begin VB.TextBox TxtNombreCanal 
            Height          =   375
            Left            =   1770
            TabIndex        =   1
            Top             =   480
            Width           =   7785
         End
         Begin MSComctlLib.ListView LstCanal 
            Height          =   6135
            Left            =   150
            TabIndex        =   65
            Top             =   960
            Width           =   10815
            _ExtentX        =   19076
            _ExtentY        =   10821
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
            Caption         =   "Canal de Distribución"
            Height          =   240
            Left            =   1920
            TabIndex        =   73
            Top             =   240
            Width           =   1845
         End
         Begin VB.Label Label4 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clave"
            Height          =   255
            Left            =   210
            TabIndex        =   72
            Top             =   240
            Width           =   1095
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
         TabIndex        =   93
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
         TabIndex        =   89
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
         TabIndex        =   88
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
         TabIndex        =   77
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
         TabIndex        =   69
         Top             =   0
         Width           =   2235
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
      Left            =   7440
      TabIndex        =   102
      Top             =   7920
      Width           =   810
   End
End
Attribute VB_Name = "AL_Cat_Clientes"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDCanales, LstDCadenas, Nuevo As Boolean

Dim ListaDeSucursales, ListaDeClientes, ListaDeRutas, ListaDeFormasVenta
Dim IdRuta As Integer, IdCliente As Long, RazonSocialCliente As String, IdSucursal As String, Sucursal As String, IdFormaVenta As String

Private Sub btnActualizar_Click()
Dim CANAL, cadena, GRUPOCADENA As Integer
On Error GoTo Err_CatCteG:
    
If LblEdicion.Caption = "Consultar" Then Exit Sub

    Select Case SSTab.Tab
            Case 0: If Not ValidaModulo("CATCTECAN", True) Then Exit Sub
            Case 1: If Not ValidaModulo("CATCTECAD", True) Then Exit Sub
            Case 2: If Not ValidaModulo("CATCTEGPO", True) Then Exit Sub
            Case 3: If Not ValidaModulo("CATCTECTE", True) Then Exit Sub
            Case 4: If Not ValidaModulo("CATCTESUC", True) Then Exit Sub
    End Select
    
    Select Case SSTab.Tab
        Case 0:
        
            If Trim(TxtIdCanal.Text) = "" Or Trim(TxtNombreCanal.Text) = "" Then
                MsgBox "¡ Teclee los Datos para Actualizar !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        
            StrCmd = "execute up_Canales " & Trim(TxtIdCanal.Text) & ", '" & UCase(Trim(TxtNombreCanal.Text)) & "', '" & FormatDate(Date) & "'," & IIf(Nuevo, 1, 2)
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
            StrCmd = "execute up_Cadenas " & Trim(TxtIdCadena.Text) & ", " & CANAL & ", '" & UCase(Trim(TxtCadena.Text)) & "', '" & FormatDate(Date) & "'," & IIf(Nuevo, 1, 2)
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
            
            StrCmd = "execute up_GrupoClientes " & Trim(TxtIdGrupo.Text) & ", '" & UCase(Trim(TxtGrupo.Text)) & "', '" & FormatDate(Date) & "'," & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraGrupoClientes
            LLENA_COMBOS
            Nuevo = False
                          
        Case 3:
            
            If Trim(TxtIdCliente.Text) = "" Or Trim(TxtNom.Text) = "" Then ' Or Trim(CboCanal2.Text) = "" Or Trim(CboCadena2.Text) = "" Or Trim(CboGrupo.Text) = "" Then
                MsgBox "¡ Teclee los Datos para Actualizar !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            If Rs.State Then Rs.Close
            Rs.Open "SELECT * FROM CANALES WHERE CANAL = '" & Trim(CboCanal2.Text) & "'", Cnn
            If Not Rs.EOF Then
                CANAL = Rs!idcanal
            Else
                CANAL = "0"
            End If
            If Rs.State Then Rs.Close
            Rs.Open "SELECT * FROM CADENAS WHERE CADENA = '" & Trim(CboCadena2.Text) & "'", Cnn
            If Not Rs.EOF Then
                cadena = Rs!idcadena
            Else
                cadena = "0"
            End If
            If Rs.State Then Rs.Close
            Rs.Open "SELECT * FROM GRUPOCLIENTES WHERE GRUPOCLIENTE = '" & Trim(CboGrupo.Text) & "'", Cnn
            If Not Rs.EOF Then
                GRUPOCADENA = Rs!idgrupocliente
            Else
                GRUPOCADENA = "0"
            End If
            
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
            
            Dim status
            For i = 0 To OptStatus.Count
                If OptStatus(i).Value Then
                    status = UCase(Mid(Trim(OptStatus(i).Caption), 1, 1))
                    Exit For
                End If
            Next
            
            StrCmd = "execute up_Clientes " & IdCedis & ", " & UCase(TxtIdCliente.Text) & ", '" & UCase(TxtRFC.Text) & "',  " _
                    & " '" & UCase(TxtNom.Text) & "', '" & UCase(TxtDom1.Text) & "', '" & Trim(TxtTel.Text) & "', " _
                    & " '" & UCase(TxtContacto.Text) & "', '" & Trim(TxtCorreo.Text) & "', '" & Trim(TxtWeb.Text) & "', " _
                    & " " & CANAL & ", " & cadena & ", " & GRUPOCADENA & ", '" & UCase(TxtDom2.Text) & "', '" & FormatDate(Date) & "', '" & status & "', " & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraClientes
            Nuevo = False
            
        Case 4
        
            IdSucursal = TxtDatos(1).Text
    
            If Nuevo Then
                StrCmd = "select IdSucursal from ClienteSucursal where IdSucursal = '" & TxtDatos(1).Text & "'"
                If Rs.State Then Rs.Close
                Rs.Open StrCmd, Cnn
                If Not Rs.EOF Then
                    MsgBox "¡ La Sucursal de Cliente con clave " & TxtDatos(1).Text & " ya existe !" & Chr(13) & Chr(10) & "Teclea otra Clave de Sucursal", vbInformation, App.Title
                    TxtDatos(1).SetFocus
                    TxtDatos(1).Text = ""
                    Exit Sub
                End If
            End If
    
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
    
'            If Nuevo Or (Nuevo = False And Len(TxtDatos(1).Text) = 8 And TxtDatos(0).Text <> TxtDatos(1).Text) Then
'                If CmbDatos(0).ListIndex <= 0 Then
'                    MsgBox "¡ No se ha seleccionado la Ruta !", vbInformation + vbOKOnly, App.Title
'                    CmbDatos(0).SetFocus
'                    Exit Sub
'                End If
'            End If
'
'            If CmbDatos(0).ListIndex = 0 Then
'                MsgBox "¡ No se ha seleccionado la Ruta !", vbInformation + vbOKOnly, App.Title
'                TxtDatos(2).SetFocus
'                Exit Sub
'            End If

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

            For i = 0 To TxtDatos.Count - 1
                Select Case i
                    Case 3, 8, 15, 13, 10, 24, 16, 19, 22:
                    Case Else:
                        If Trim(TxtDatos(i).Text) = "" Then
                            MsgBox "¡ Teclee todos los datos requeridos !. Los campos marcados con * son requeridos", vbInformation + vbOKOnly, App.Title
                            Exit Sub
                        End If
                End Select
            Next i

            Dim Stat
            For i = 0 To OptDatos.Count - 1
                If OptDatos(i).Value Then
                    Select Case i
                        Case 0: Stat = "A"
                        Case 1: Stat = "B"
                        Case 2: Stat = "S"
                    End Select
                End If
            Next i
'
            StrCmd = "up_Sucursales " & IdCedis & ", " & IdRuta & ", " & IdCliente & ", '" & IdSucursal & "', '" & _
                    UCase(Trim(TxtDatos(3).Text)) & "', '" & UCase(Trim(TxtDatos(4).Text)) & "', '" & _
                    UCase(Trim(TxtDatos(26).Text)) & "', '" & UCase(Trim(TxtDatos(25).Text)) & "', '" & _
                    UCase(Trim(TxtDatos(24).Text)) & "', '" & UCase(Trim(TxtDatos(23).Text)) & "', '" & _
                    UCase(Trim(TxtDatos(16).Text)) & "', '" & UCase(Trim(TxtDatos(21).Text)) & "', '" & _
                    UCase(Trim(TxtDatos(20).Text)) & "', '" & UCase(Trim(TxtDatos(18).Text)) & "', '" & _
                    UCase(Trim(TxtDatos(19).Text)) & "', '" & UCase(Trim(TxtDatos(22).Text)) & "', '" & _
                    UCase(Trim(TxtDatos(5).Text)) & "', '" & UCase(Trim(TxtDatos(14).Text)) & "', '" & _
                    UCase(Trim(TxtDatos(6).Text)) & "', '" & UCase(Trim(TxtDatos(7).Text)) & "', '" & _
                    UCase(Trim(TxtDatos(8).Text)) & "', '" & UCase(Trim(TxtDatos(9).Text)) & "', '" & _
                    UCase(Trim(TxtDatos(15).Text)) & "', '" & UCase(Trim(TxtDatos(11).Text)) & "', '" & _
                    UCase(Trim(TxtDatos(12).Text)) & "', '" & UCase(Trim(TxtDatos(17).Text)) & "', '" & _
                    UCase(Trim(TxtDatos(13).Text)) & "', '" & UCase(Trim(TxtDatos(10).Text)) & "', '" & _
                    UCase(Trim(TxtDatos(2).Text)) & "', '" & IdFormaVenta & "', '" & _
                    Stat & "',0, '" & UCase(Trim(TxtDatos(27).Text)) & "', '" & UCase(Trim(TxtDatos(28).Text)) & _
                    "', '" & UCase(Trim(TxtDatos(29).Text)) & "', '" & UCase(Trim(TxtDatos(30).Text)) & "', " & IIf(Nuevo, 1, 2)
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

No_Err_CatCteG:
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
    LblEdicion.Caption = "Consultar"
    Exit Sub
        
Err_CatCteG:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_CatCteG:

End Sub

Private Sub btnEliminar_Click()
On Error GoTo Err_CatCteE:

    Select Case SSTab.Tab
            Case 0: If Not ValidaModulo("CATCTECAN", True) Then Exit Sub
            Case 1: If Not ValidaModulo("CATCTECAD", True) Then Exit Sub
            Case 2: If Not ValidaModulo("CATCTEGPO", True) Then Exit Sub
            Case 3: If Not ValidaModulo("CATCTECTE", True) Then Exit Sub
            Case 4: If Not ValidaModulo("CATCTESUC", True) Then Exit Sub
    End Select
    
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
                    "', '', '', '', '', '', '', '', '', '', '', '', '', '', '',0 , 0,0, '', 3"
                        
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

No_Err_CatCteE:
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
    LblEdicion.Caption = "Consultar"
    Exit Sub
        
Err_CatCteE:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_CatCteE:

End Sub

Private Sub btnImprimir_Click()
On Error GoTo Err_CatCteI:
   
   Select Case SSTab.Tab
        Case 0:
            With AL_RptCatCanal
                .Caption = "Catálogo de Canales de Clientes"
                .LblTitulo.Caption = "Catálogo de Canales de Clientes"
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
                    .Printer.PaperSize = 1
                    .Printer.Orientation = ddOPortrait
                    .Show 1
                End If
            End With
            
        Case 1:
            With AL_RptCatCadena
                .Caption = "Catálogo de Cadenas de Clientes"
                .LblTitulo.Caption = "Catálogo de Cadenas de Clientes"
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
                    .Printer.PaperSize = 1
                    .Printer.Orientation = ddOPortrait
                    .Show 1
                End If
            End With
            
        Case 2:
            With AL_RptCatGrupoClientes
                .Caption = "Catálogo de Grupos de Clientes"
                .LblTitulo.Caption = "Catálogo de Grupos de Clientes"
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
                    .Printer.PaperSize = 1
                    .Printer.Orientation = ddOPortrait
                    .Show 1
                End If
            End With
                
        Case 3:
            With AL_RptCatClientes
                .Caption = "Catálogo de Clientes"
                .LblTitulo.Caption = "Catálogo de Clientes"
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                StrCmd = "select d.cedis, c.idcliente, c.rfc, c.razonsocial, c.domicilio, c.telefono, isnull( a.canal, '(Sin Canal)'), isnull( e.cadena, '(Sin Cadena)'), isnull( g.grupocliente, '(Sin Grupo)')," _
                        & " Case c.Status " _
                        & " when 'A' then 'Activo' " _
                        & " Else 'Baja' " _
                        & " end as 'Estatus' " _
                        & " from clientes c" _
                        & " left outer join canales a on a.idcanal = c.idcanal " _
                        & " left outer join cadenas e on c.idcadena = e.idcadena  " _
                        & " left outer join grupoclientes g on c.idgrupocadena = g.idgrupocliente " _
                        & " inner join cedis d on c.IdCedis = d.IdCedis " _
                        & " where c.IdCedis = " & IdCedis _
                        & " order by d.cedis,  c.razonsocial "
                    If RsC.State Then RsC.Close
                    RsC.Open StrCmd, Cnn
        
                If Not RsC.EOF Then
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = RsC
                    .Printer.PaperSize = 1
                    .Printer.Orientation = ddOLandscape
                    .Show 1
                End If
            End With
                        
        Case 4:
            With AL_RptCatSucursales
                .Caption = "Catálogo de Sucursales de Clientes"
                .LblTitulo.Caption = "Catálogo de Sucursales de Clientes"
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                StrCmd = "execute sel_Sucursales " & IdCedis & "," & IdCliente & ",'',0,'','','',2"
                If RsC.State Then RsC.Close
                RsC.Open StrCmd, Cnn
        
                If Not RsC.EOF Then
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = RsC
                    .Printer.PaperSize = 1
                    .Printer.Orientation = ddOPortrait
                    .Show 1
                End If
            End With
    End Select

No_Err_CatCteI:
    LblEdicion.Caption = "Consultar"
    Exit Sub
        
Err_CatCteI:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_CatCteI:

End Sub

Private Sub btnNuevo_Click()
On Error GoTo Err_CatCteN:
    
    Select Case SSTab.Tab
            Case 0: If Not ValidaModulo("CATCTECAN", True) Then Exit Sub
            Case 1: If Not ValidaModulo("CATCTECAD", True) Then Exit Sub
            Case 2: If Not ValidaModulo("CATCTEGPO", True) Then Exit Sub
            Case 3: If Not ValidaModulo("CATCTECTE", True) Then Exit Sub
            Case 4: If Not ValidaModulo("CATCTESUC", True) Then Exit Sub
    End Select
    
    Select Case SSTab.Tab
        Case 0:
            TxtIdCanal.Text = "": TxtNombreCanal.Text = ""
            If Rs.State Then Rs.Close
            Rs.Open "SELECT ISNULL(MAX(IdCanal),0)+1 AS MAXI From Canales", Cnn
            TxtIdCanal.Text = Rs!MAXI
            Nuevo = True
            TxtNombreCanal.SetFocus
            
        Case 1:
            TxtIdCadena.Text = "": TxtCadena.Text = ""
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
            TxtDatos(28).Text = 0: TxtDatos(29).Text = 0

            Nuevo = True
            CmbDatos(0).Locked = False
            CmbDatos(0).ListIndex = 0
            CmbDatos(0).SetFocus
            CmbDatos(1).ListIndex = 0
            OptDatos(0).Value = True
            TxtDatos(1).Locked = False
            
    End Select

No_Err_CatCteN:
    LblEdicion.Caption = "Nuevo"
    Exit Sub
        
Err_CatCteN:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_CatCteN:
    
End Sub

Private Sub btnSeleccionaCte_Click()
    On Error Resume Next
    
    With LstVDatos(0)
        .Visible = True
        .Height = 3000
        .ZOrder (0)
        .SetFocus
    End With
End Sub

Private Sub CmbDatos_Click(Index As Integer)
On Error Resume Next

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
            If Nuevo Then
                TxtDatos(1).Text = ObtieneClaveSucursal(CInt(IdCedis), CLng(IdRuta), IdCliente)
                TxtDatos(2).Text = TxtDatos(1).Text
                TxtDatos(1).SetFocus
            End If
        Case 1
            IdFormaVenta = ListaDeFormasVenta(0, ElementoSeleccionado)
        
    End Select

End Sub

Private Sub Form_Load()
On Error Resume Next
    Nuevo = False
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    MuestraClientes
    LLENA_COMBOS
    SSTab.Tab = 3
End Sub

Sub LLENA_COMBOS()
On Error Resume Next
    
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
    ListaDeFormasVenta = GetDataCBL(Rs, CmbDatos(1), "Condiciones de Venta", "No se Encontraron Registros de Tipos de Venta")
    Rs.Close

End Sub

Sub MuestraCanales()
On Error Resume Next
    StrCmd = "execute sel_Canales "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCanales = GetDataLVL(Rs, LstCanal, 0, 2, "0|0|0")
End Sub

Sub MuestraCadenas()
On Error Resume Next
    StrCmd = "execute sel_Cadenas "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCadena = GetDataLVL(Rs, LstCadena, 0, 3, "0|0|0|0")
End Sub

Sub MuestraGrupoClientes()
On Error Resume Next
    StrCmd = "execute sel_GrupoClientes "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCadena = GetDataLVL(Rs, LstGrupo, 0, 4, "0|0|0|0")
End Sub

Sub MuestraClientes()
On Error Resume Next
    StrCmd = "execute sel_Clientes " & IdCedis & ""
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDClientes = GetDataLVL(Rs, LstCliente, 0, 5, "0|0|0|0|0|0|0|0|0|0|0|0|0|0")
    Rs.MoveFirst
    ListaDeClientes = GetDataLVL(Rs, LstVDatos(0), 0, 5, "0|0|0|0|0|0|0|0|0|0|0|0|0|0")
    
    If Not IsEmpty(ListaDeClientes) Then LstVDatos_ItemClick 0, LstVDatos(0).SelectedItem

End Sub

Sub MuestraSucursales()
On Error Resume Next
    StrCmd = "execute sel_Sucursales " & IdCedis & "," & IdCliente & ",'" & Trim(TxtFIdSucursal.Text) & "',0,'" & Trim(TxtFRFC.Text) & "','" & Trim(TxtFNombreSucursal.Text) & "','" & Trim(TxtFCalle.Text) & "',1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    ListaDeSucursales = GetDataLVL(Rs, LstVDatos(1), 2, 20, "0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0|0")
End Sub

Function ObtieneClaveSucursal(IdCedis As Integer, IdRuta As Long, IdCliente As Long) As String
On Error Resume Next
    Dim IdSucursal As Integer

    ObtieneClaveSucursal = ""
        
    'obtener el siguiente consecutivo para la ruta
    StrCmd = "execute sel_Sucursales " & IdCedis & "," & IdCliente & ",''," & IdRuta & ",'','','',3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    If Not Rs.EOF Then
        ObtieneClaveSucursal = Rs.Fields(0)
    End If
'    ObtieneClaveSucursal = Format(IdCedis, "00") & Format(IdRuta, "000") & Format(IdSucursal, "000")
End Function

Private Sub LstCadena_Click()
On Error Resume Next
    TxtIdCadena.Text = LstCadena.ListItems(LstCadena.SelectedItem.Index).Text
    TxtCadena.Text = LstCadena.ListItems(LstCadena.SelectedItem.Index).SubItems(1)
    CboCanal1.Text = LstCadena.ListItems(LstCadena.SelectedItem.Index).SubItems(2)
    Nuevo = False
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub LstCadena_DblClick()
On Error Resume Next
    Nuevo = False
    LblEdicion.Caption = "Actualizar"
End Sub

Private Sub LstCadena_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstCadena_Click
End Sub

Private Sub LstCanal_Click()
On Error Resume Next
    TxtIdCanal.Text = LstCanal.ListItems.Item(LstCanal.SelectedItem.Index).Text
    TxtNombreCanal.Text = LstCanal.ListItems.Item(LstCanal.SelectedItem.Index).SubItems(1)
    Nuevo = False
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub LstCanal_DblClick()
On Error Resume Next
    Nuevo = False
    LblEdicion.Caption = "Actualizar"
End Sub

Private Sub LstCanal_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstCanal_Click
End Sub

Private Sub LstCliente_Click()
    On Error Resume Next
    If LstCliente.ListItems.Count <= 0 Then Exit Sub
    
    TxtIdCliente.Text = LstCliente.ListItems.Item(LstCliente.SelectedItem.Index).Text
    TxtNom.Text = LstCliente.ListItems(LstCliente.SelectedItem.Index).SubItems(2)
    TxtRFC.Text = LstCliente.ListItems(LstCliente.SelectedItem.Index).SubItems(1)
    TxtTel.Text = LstCliente.ListItems(LstCliente.SelectedItem.Index).SubItems(4)
    TxtDom1.Text = LstCliente.ListItems(LstCliente.SelectedItem.Index).SubItems(3)
    CboCanal2.Text = ListaDeClientes(6, LstCliente.SelectedItem.Index - 1)
    CboCadena2.Text = ListaDeClientes(7, LstCliente.SelectedItem.Index - 1)
    CboGrupo.Text = ListaDeClientes(8, LstCliente.SelectedItem.Index - 1)
    Select Case Mid(UCase(Trim(LstCliente.ListItems(LstCliente.SelectedItem.Index).SubItems(5))), 1, 1)
        Case "A": OptStatus(0).Value = True
        Case "B": OptStatus(1).Value = True
    End Select
    
    Nuevo = False
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub LstCliente_DblClick()
    On Error Resume Next
    If LstCliente.ListItems.Count <= 0 Then Exit Sub
    
    Nuevo = False
    LblEdicion.Caption = "Actualizar"
End Sub

Private Sub LstCliente_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstCliente_Click
End Sub

Private Sub LstGrupo_Click()
On Error Resume Next
    TxtIdGrupo.Text = LstGrupo.ListItems(LstGrupo.SelectedItem.Index).Text
    TxtGrupo.Text = LstGrupo.ListItems(LstGrupo.SelectedItem.Index).SubItems(1)
    Nuevo = False
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub LstGrupo_DblClick()
On Error Resume Next
    Nuevo = False
    LblEdicion.Caption = "Actualizar"
End Sub

Private Sub LstGrupo_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstGrupo_Click
End Sub

Private Sub LstVDatos_DblClick(Index As Integer)
On Error Resume Next

    Select Case Index
        
        Case 0
            ItemSeleccionado = LstVDatos(Index).SelectedItem.Index
            CmbDatos(0).Locked = True
            
            For i = 0 To TxtDatos.Count - 1: TxtDatos(i).Text = "": Next i
            TxtDatos(28).Text = 0: TxtDatos(29).Text = 0
            
            CmbDatos(0).ListIndex = 0
            CmbDatos(1).ListIndex = 0
            
            IdCliente = ListaDeClientes(0, ItemSeleccionado - 1)
            RazonSocialCliente = ListaDeClientes(2, ItemSeleccionado - 1)
            
            If IdCliente = "0" Then
                LstVDatos(0).Visible = False
                CmbDatos(0).Locked = True
                CmbDatos(0).SetFocus
                TxtDatos(0).Text = IdCliente
                Exit Sub
            Else
                LblTitulos(4).Caption = IdCliente & " - " & RazonSocialCliente
                TxtDatos(0).Text = IdCliente
            End If
            
            MuestraSucursales
            
            OptDatos(0).Value = False: OptDatos(1).Value = False
            LstVDatos(Index).Visible = False
            CmbDatos(0).Locked = False
            CmbDatos(0).SetFocus
            
            LstVDatos_ItemClick 1, LstVDatos(1).ListItems(1)
        
        Case 1      'para reasignacion de cliente
            Nuevo = False
            TxtDatos(1).Locked = True
            LblEdicion.Caption = "Actualizar"
            
    End Select

End Sub

Private Sub LstVDatos_ItemClick(Index As Integer, ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
Dim ItemSeleccionado As Integer

    Nuevo = False
    
    Select Case Index
            
        Case 1
            ItemSeleccionado = Item.Index
            CmbDatos(0).Locked = True
                        
            For i = 0 To 12: TxtDatos(i).Text = "": Next i

            IdSucursal = ListaDeSucursales(3, ItemSeleccionado - 1)
            Sucursal = ListaDeSucursales(5, ItemSeleccionado - 1)
            TxtDatos(1).Locked = True
            
            TxtDatos(0).Text = ListaDeSucursales(2, ItemSeleccionado - 1)        'IdCliente
            TxtDatos(1).Text = ListaDeSucursales(3, ItemSeleccionado - 1)        'IdSucursal
            TxtDatos(2).Text = ListaDeSucursales(8, ItemSeleccionado - 1)        'Codigo de Barras
            TxtDatos(3).Text = ListaDeSucursales(4, ItemSeleccionado - 1)        'TDA-GLN
            TxtDatos(4).Text = ListaDeSucursales(5, ItemSeleccionado - 1)        'Sucursal
            TxtDatos(5).Text = ListaDeSucursales(19, ItemSeleccionado - 1)       'RFCSucursal
            TxtDatos(6).Text = ListaDeSucursales(21, ItemSeleccionado - 1)        'CalleF
            TxtDatos(7).Text = ListaDeSucursales(22, ItemSeleccionado - 1)        'No. ExteriorF
            TxtDatos(8).Text = ListaDeSucursales(23, ItemSeleccionado - 1)        'No. InteriorF
            TxtDatos(9).Text = ListaDeSucursales(24, ItemSeleccionado - 1)       'ColoniaF
            TxtDatos(10).Text = ListaDeSucursales(30, ItemSeleccionado - 1)       'CPF
            TxtDatos(11).Text = ListaDeSucursales(26, ItemSeleccionado - 1)      'poblacion F
            TxtDatos(12).Text = ListaDeSucursales(27, ItemSeleccionado - 1)      'EntidadF
            TxtDatos(13).Text = ListaDeSucursales(29, ItemSeleccionado - 1)      'TelefonosF
            TxtDatos(14).Text = ListaDeSucursales(20, ItemSeleccionado - 1)       'razon social
            TxtDatos(15).Text = ListaDeSucursales(25, ItemSeleccionado - 1)       'localidadF
            TxtDatos(16).Text = ListaDeSucursales(13, ItemSeleccionado - 1)      'localidad
            TxtDatos(17).Text = ListaDeSucursales(28, ItemSeleccionado - 1)      'pais f
            TxtDatos(18).Text = ListaDeSucursales(16, ItemSeleccionado - 1)      'pais
            TxtDatos(19).Text = ListaDeSucursales(17, ItemSeleccionado - 1)      'tel
            TxtDatos(20).Text = ListaDeSucursales(15, ItemSeleccionado - 1)      'entidad
            TxtDatos(21).Text = ListaDeSucursales(14, ItemSeleccionado - 1)      'poblacion
            TxtDatos(22).Text = ListaDeSucursales(18, ItemSeleccionado - 1)       'cp
            TxtDatos(23).Text = ListaDeSucursales(12, ItemSeleccionado - 1)       'colonia
            TxtDatos(24).Text = ListaDeSucursales(11, ItemSeleccionado - 1)      'no int
            TxtDatos(25).Text = ListaDeSucursales(10, ItemSeleccionado - 1)      'no ext
            TxtDatos(26).Text = ListaDeSucursales(9, ItemSeleccionado - 1)      'calle
            TxtDatos(27).Text = ListaDeSucursales(31, ItemSeleccionado - 1)      'contacto
            TxtDatos(28).Text = ListaDeSucursales(32, ItemSeleccionado - 1)      'dias credito
            TxtDatos(29).Text = ListaDeSucursales(33, ItemSeleccionado - 1)      'limite credito
            TxtDatos(30).Text = ListaDeSucursales(34, ItemSeleccionado - 1)      'CRTienda
            
            
            Select Case ListaDeSucursales(6, ItemSeleccionado - 1)
                Case "A": OptDatos(0).Value = True
                Case "B": OptDatos(1).Value = True
                Case "S": OptDatos(2).Value = True
            End Select
            
            CmbDatos(0).ListIndex = 0: CmbDatos(1).ListIndex = 0
            
            'busca el dato en el combo de Ruta
            If Len(ListaDeSucursales(3, ItemSeleccionado - 1)) = 9 And _
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

            LblEdicion.Caption = "Consultar"
    End Select

End Sub

Private Sub LstVDatos_LostFocus(Index As Integer)
On Error Resume Next
    If Index = 0 Then
        LstVDatos(Index).Visible = False
        LstVDatos(1).SetFocus
        Exit Sub
    End If
End Sub

Private Sub OptDomicilio_Click(Index As Integer)
On Error Resume Next
    If OptDomicilio(0).Value Then
        FrmDomicilio(0).Visible = True: FrmDomicilio(1).Visible = False
    Else
        FrmDomicilio(1).Visible = True: FrmDomicilio(0).Visible = False
    End If
End Sub

Private Sub SSTab_Click(PreviousTab As Integer)
On Error Resume Next
    Select Case SSTab.Tab
        Case 0:
'            If Not ValidaModulo("CATCTECAN", True) Then
'                SSTab.Tab = 3
'                Exit Sub
'            End If
            MuestraCanales
        Case 1:
'            If Not ValidaModulo("CATCTECAD", True) Then
'                SSTab.Tab = 3
'                Exit Sub
'            End If
            MuestraCadenas
        Case 2:
'            If Not ValidaModulo("CATCTEGPO", True) Then
'                SSTab.Tab = 3
'                Exit Sub
'            End If
            MuestraGrupoClientes
        Case 3:
'            If Not ValidaModulo("CATCTECTE", True) Then
'                Unload Me
'            End If
            MuestraClientes
        Case 4:
'            If Not ValidaModulo("CATCTESUC", True) Then
'                AL_Cat_Clientes.Hide
'            End If
            
    End Select
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub TxtCadena_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtContacto_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtDatos_DblClick(Index As Integer)
On Error Resume Next

If Index = 0 Then
    With AL_Cat_Clientes_Reasignacion
        .IdClienteAnterior = IdCliente
        .ClienteAnterior = RazonSocialCliente
        .IdSucursal = IdSucursal
        .Sucursal = Sucursal
        .Left = AL_Cat_Clientes.Left + ((AL_Cat_Clientes.Width - AL_Cat_Clientes_Reasignacion.Width) / 2)
        .Top = AL_Cat_Clientes.Top + ((AL_Cat_Clientes.Height - AL_Cat_Clientes_Reasignacion.Height) / 2)
        .Show
    End With
End If
End Sub

Private Sub TxtDatos_KeyPress(Index As Integer, KeyAscii As Integer)
On Error Resume Next
    Select Case Index
        Case 0, 2: KeyAscii = itEntero(KeyAscii)
        Case Else: KeyAscii = itString(KeyAscii)
    End Select
End Sub

Private Sub TxtDatos_Validate(Index As Integer, Cancel As Boolean)
On Error Resume Next
    If Index = 1 Then
        If Not TxtDatos(Index).Locked Then
            TxtDatos(Index).Text = Trim(TxtDatos(Index))
            StrCmd = "select IdSucursal from ClienteSucursal where IdSucursal = '" & TxtDatos(Index).Text & "'"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            If Not Rs.EOF Then
                MsgBox "¡ La Sucursal de Cliente con clave " & TxtDatos(Index).Text & " ya existe !" & Chr(13) & Chr(10) & "Teclea otra Clave de Sucursal", vbInformation, App.Title
                TxtDatos(Index).SetFocus
                TxtDatos(Index).Text = ""
                Exit Sub
            End If
        End If
    End If
End Sub

Private Sub TxtDom1_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtDom2_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtFCalle_KeyDown(KeyCode As Integer, Shift As Integer)
    If KeyCode = 13 Then
        FiltrarSucursales
    End If
End Sub

Private Sub TxtFIdSucursal_KeyDown(KeyCode As Integer, Shift As Integer)
    If KeyCode = 13 Then
        FiltrarSucursales
    End If
End Sub

Private Sub TxtFNombreSucursal_KeyDown(KeyCode As Integer, Shift As Integer)
    If KeyCode = 13 Then
        FiltrarSucursales
    End If
End Sub

Private Sub TxtFRFC_KeyDown(KeyCode As Integer, Shift As Integer)
    If KeyCode = 13 Then
        FiltrarSucursales
    End If
End Sub

Private Sub FiltrarSucursales()
    MuestraSucursales
            
    If LstVDatos(1).ListItems.Count > 0 Then
        OptDatos(0).Value = False: OptDatos(1).Value = False
        LstVDatos(Index).Visible = False
        CmbDatos(0).Locked = False
        CmbDatos(0).SetFocus
        
        LstVDatos_ItemClick 1, LstVDatos(1).ListItems(1)
    Else
        LimpiarDatosSucursal
    End If
End Sub

Private Sub LimpiarDatosSucursal()
    CmbDatos(0).Locked = True
    CmbDatos(1).Locked = True
                        
    For i = 0 To TxtDatos.Count - 1
        TxtDatos(i).Text = ""
        TxtDatos(i).Locked = True
    Next i
   
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub TxtGrupo_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtIdCliente_KeyPress(KeyAscii As Integer)
On Error Resume Next
  If IsNumeric(Chr(KeyAscii)) = False And KeyAscii <> 8 And KeyAscii <> 13 Then KeyAscii = 0
End Sub

Private Sub TxtIdCliente_Validate(Cancel As Boolean)
On Error Resume Next
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
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtNombreCanal_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtRFC_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

