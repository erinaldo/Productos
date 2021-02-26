VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form AL_Cat_Clientes 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Catalogo de Clientes"
   ClientHeight    =   8550
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
   ScaleHeight     =   8550
   ScaleWidth      =   12660
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
      Left            =   2520
      Picture         =   "AL_Cat_Clientes.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   23
      Top             =   7920
      Width           =   1695
   End
   Begin TabDlg.SSTab SSTab 
      Height          =   7575
      Left            =   240
      TabIndex        =   26
      Top             =   240
      Width           =   12255
      _ExtentX        =   21616
      _ExtentY        =   13361
      _Version        =   393216
      Tabs            =   4
      TabsPerRow      =   4
      TabHeight       =   520
      TabCaption(0)   =   "Canales de Distribución"
      TabPicture(0)   =   "AL_Cat_Clientes.frx":0996
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "LblOpt(0)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "FrmOpt(1)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "Cadenas de Clientes"
      TabPicture(1)   =   "AL_Cat_Clientes.frx":09B2
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "FrmOpt(0)"
      Tab(1).Control(1)=   "LblOpt(3)"
      Tab(1).ControlCount=   2
      TabCaption(2)   =   "Grupo de Clientes"
      TabPicture(2)   =   "AL_Cat_Clientes.frx":09CE
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "FrmOpt(3)"
      Tab(2).Control(1)=   "LblOpt(1)"
      Tab(2).ControlCount=   2
      TabCaption(3)   =   "Clientes"
      TabPicture(3)   =   "AL_Cat_Clientes.frx":09EA
      Tab(3).ControlEnabled=   0   'False
      Tab(3).Control(0)=   "FrmOpt(2)"
      Tab(3).Control(1)=   "LblOpt(2)"
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
         Height          =   7260
         Index           =   3
         Left            =   -75000
         TabIndex        =   53
         Top             =   320
         Width           =   12255
         Begin VB.TextBox TxtGrupo 
            Height          =   375
            Left            =   1200
            TabIndex        =   6
            Top             =   480
            Width           =   8415
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
            Left            =   240
            Locked          =   -1  'True
            MaxLength       =   5
            TabIndex        =   5
            Top             =   480
            Width           =   855
         End
         Begin MSComctlLib.ListView LstGrupo 
            Height          =   5895
            Left            =   240
            TabIndex        =   54
            Top             =   960
            Width           =   11775
            _ExtentX        =   20770
            _ExtentY        =   10398
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
            Left            =   1200
            TabIndex        =   56
            Top             =   240
            Width           =   2295
         End
         Begin VB.Label Label10 
            BackColor       =   &H00FFFFFF&
            Caption         =   "No."
            Height          =   375
            Left            =   240
            TabIndex        =   55
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
         Height          =   7215
         Index           =   2
         Left            =   -75000
         TabIndex        =   38
         Top             =   360
         Width           =   12255
         Begin VB.Frame Frame1 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Estatus del Cliente"
            Height          =   615
            Left            =   6240
            TabIndex        =   58
            Top             =   2640
            Width           =   4335
            Begin VB.OptionButton OptStatus 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Baja"
               Height          =   255
               Index           =   2
               Left            =   3240
               TabIndex        =   21
               Top             =   280
               Width           =   855
            End
            Begin VB.OptionButton OptStatus 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Suspendido"
               Height          =   255
               Index           =   1
               Left            =   1560
               TabIndex        =   20
               Top             =   280
               Width           =   1575
            End
            Begin VB.OptionButton OptStatus 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Activo"
               Height          =   255
               Index           =   0
               Left            =   360
               TabIndex        =   19
               Top             =   280
               Value           =   -1  'True
               Width           =   1215
            End
         End
         Begin VB.ComboBox CboGrupo 
            Height          =   360
            Left            =   9360
            Style           =   2  'Dropdown List
            TabIndex        =   17
            Top             =   2280
            Width           =   2655
         End
         Begin VB.TextBox TxtNom 
            Height          =   375
            Left            =   2040
            MaxLength       =   500
            TabIndex        =   8
            Top             =   480
            Width           =   7095
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
            Left            =   240
            MaxLength       =   8
            TabIndex        =   7
            Top             =   480
            Width           =   1695
         End
         Begin VB.ComboBox CboCanal2 
            Height          =   360
            Left            =   9360
            Style           =   2  'Dropdown List
            TabIndex        =   12
            Top             =   1080
            Width           =   2655
         End
         Begin VB.TextBox TxtRFC 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   9360
            MaxLength       =   13
            TabIndex        =   9
            Top             =   480
            Width           =   2655
         End
         Begin VB.TextBox TxtTel 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   240
            MaxLength       =   100
            TabIndex        =   10
            Top             =   1080
            Width           =   1695
         End
         Begin VB.TextBox TxtDom1 
            Height          =   375
            Left            =   2040
            MaxLength       =   500
            TabIndex        =   11
            Top             =   1080
            Width           =   7215
         End
         Begin VB.ComboBox CboCadena2 
            CausesValidation=   0   'False
            Height          =   360
            ItemData        =   "AL_Cat_Clientes.frx":0A06
            Left            =   9360
            List            =   "AL_Cat_Clientes.frx":0A08
            Style           =   2  'Dropdown List
            TabIndex        =   15
            Top             =   1680
            Width           =   2655
         End
         Begin VB.TextBox TxtContacto 
            Height          =   375
            Left            =   240
            MaxLength       =   300
            TabIndex        =   13
            Top             =   1680
            Width           =   5655
         End
         Begin VB.TextBox TxtCorreo 
            Height          =   375
            Left            =   6000
            MaxLength       =   100
            TabIndex        =   14
            Top             =   1680
            Width           =   3255
         End
         Begin VB.TextBox TxtWeb 
            Height          =   375
            Left            =   240
            MaxLength       =   200
            TabIndex        =   18
            Top             =   2880
            Width           =   5895
         End
         Begin VB.TextBox TxtDom2 
            Height          =   375
            Left            =   240
            MaxLength       =   1000
            TabIndex        =   16
            Top             =   2280
            Width           =   9015
         End
         Begin MSComctlLib.ListView LstCliente 
            Height          =   3615
            Left            =   240
            TabIndex        =   39
            Top             =   3360
            Width           =   11775
            _ExtentX        =   20770
            _ExtentY        =   6376
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
            Left            =   9360
            TabIndex        =   57
            Top             =   2040
            Width           =   1560
         End
         Begin VB.Label Label7 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clave"
            Height          =   375
            Left            =   240
            TabIndex        =   50
            Top             =   240
            Width           =   615
         End
         Begin VB.Label Label8 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Canal al que Pertenece"
            Height          =   240
            Left            =   9360
            TabIndex        =   49
            Top             =   840
            Width           =   2025
         End
         Begin VB.Label Label9 
            BackColor       =   &H00FFFFFF&
            Caption         =   "RFC"
            Height          =   255
            Left            =   9360
            TabIndex        =   48
            Top             =   240
            Width           =   375
         End
         Begin VB.Label Label11 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Razón Social"
            Height          =   240
            Left            =   2040
            TabIndex        =   47
            Top             =   240
            Width           =   1155
         End
         Begin VB.Label Label12 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Teléfono"
            Height          =   255
            Left            =   240
            TabIndex        =   46
            Top             =   840
            Width           =   975
         End
         Begin VB.Label Label13 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Domicilio"
            Height          =   240
            Left            =   2040
            TabIndex        =   45
            Top             =   840
            Width           =   795
         End
         Begin VB.Label Label14 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cadena"
            Height          =   240
            Left            =   9360
            TabIndex        =   44
            Top             =   1440
            Width           =   660
         End
         Begin VB.Label Label15 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Contacto"
            Height          =   240
            Left            =   240
            TabIndex        =   43
            Top             =   1440
            Width           =   780
         End
         Begin VB.Label Label16 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Correo Electrónico"
            Height          =   240
            Left            =   6000
            TabIndex        =   42
            Top             =   1440
            Width           =   1605
         End
         Begin VB.Label Label17 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Página Web"
            Height          =   240
            Left            =   240
            TabIndex        =   41
            Top             =   2640
            Width           =   1065
         End
         Begin VB.Label Label18 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Domicilio de Entrega"
            Height          =   240
            Left            =   240
            TabIndex        =   40
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
         Height          =   7260
         Index           =   0
         Left            =   -75000
         TabIndex        =   29
         Top             =   320
         Width           =   12255
         Begin VB.ComboBox CboCanal1 
            Height          =   360
            Left            =   9360
            TabIndex        =   4
            Top             =   480
            Width           =   2655
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
            Left            =   240
            Locked          =   -1  'True
            MaxLength       =   5
            TabIndex        =   2
            Top             =   480
            Width           =   855
         End
         Begin VB.TextBox TxtCadena 
            Height          =   375
            Left            =   1200
            TabIndex        =   3
            Top             =   480
            Width           =   7935
         End
         Begin MSComctlLib.ListView LstCadena 
            Height          =   5895
            Left            =   240
            TabIndex        =   33
            Top             =   960
            Width           =   11775
            _ExtentX        =   20770
            _ExtentY        =   10398
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
            Left            =   9360
            TabIndex        =   36
            Top             =   240
            Width           =   2025
         End
         Begin VB.Label Label2 
            BackColor       =   &H00FFFFFF&
            Caption         =   "No."
            Height          =   375
            Left            =   240
            TabIndex        =   35
            Top             =   240
            Width           =   615
         End
         Begin VB.Label Label1 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Nombre de la  Cadena de Cliente"
            Height          =   240
            Left            =   1200
            TabIndex        =   34
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
         Height          =   7260
         Index           =   1
         Left            =   0
         TabIndex        =   28
         Top             =   320
         Width           =   12255
         Begin VB.TextBox TxtNombreCanal 
            Height          =   375
            Left            =   1200
            TabIndex        =   1
            Top             =   480
            Width           =   8055
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
            Left            =   240
            Locked          =   -1  'True
            MaxLength       =   5
            TabIndex        =   0
            Top             =   480
            Width           =   855
         End
         Begin MSComctlLib.ListView LstCanal 
            Height          =   5895
            Left            =   240
            TabIndex        =   30
            Top             =   960
            Width           =   10935
            _ExtentX        =   19288
            _ExtentY        =   10398
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
            Left            =   1440
            TabIndex        =   32
            Top             =   240
            Width           =   2895
         End
         Begin VB.Label Label4 
            BackColor       =   &H00FFFFFF&
            Caption         =   "No."
            Height          =   255
            Left            =   240
            TabIndex        =   31
            Top             =   240
            Width           =   855
         End
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
         Left            =   -71925
         TabIndex        =   52
         Top             =   0
         Width           =   3045
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
         Left            =   -68880
         TabIndex        =   51
         Top             =   0
         Width           =   3060
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
         Left            =   -65800
         TabIndex        =   37
         Top             =   0
         Width           =   3045
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
         Left            =   0
         TabIndex        =   27
         Top             =   0
         Width           =   3080
      End
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
      Left            =   720
      Picture         =   "AL_Cat_Clientes.frx":0A0A
      Style           =   1  'Graphical
      TabIndex        =   22
      Top             =   7920
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
      Left            =   6120
      Picture         =   "AL_Cat_Clientes.frx":1098
      Style           =   1  'Graphical
      TabIndex        =   25
      Top             =   7920
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
      Left            =   4320
      Picture         =   "AL_Cat_Clientes.frx":17B3
      Style           =   1  'Graphical
      TabIndex        =   24
      Top             =   7920
      Width           =   1695
   End
End
Attribute VB_Name = "AL_Cat_Clientes"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDCanales, LstDCadenas, Nuevo As Boolean

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
            
    End Select
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
End Sub

Private Sub btnImprimir_Click()
   Select Case SSTab.Tab
        Case 0:
            With AL_RptCatCanal
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
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
                .Show
            End With
            
        Case 1:
            With AL_RptCatCadena
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
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
                .Show
            End With
            
        Case 2:
            With AL_RptCatGrupoClientes
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
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
                .Show
            End With
                
        Case 3:
            With AL_RptCatClientes
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
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
                .Show
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
            
    End Select
End Sub

Private Sub Form_Load()
    Nuevo = False
    If Not Cnn.State Then OpenConn Server, Db, "AdminRoute", "Route2103"
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
        CboGrupo.AddItem Trim(Rs!GRUPOCLIENTE)
        Rs.MoveNext
    Wend
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
End Sub

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

