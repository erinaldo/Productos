VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form CC_Cat_Documentos 
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
      Picture         =   "CC_Cat_Documentos.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   46
      Top             =   7320
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
      Picture         =   "CC_Cat_Documentos.frx":0996
      Style           =   1  'Graphical
      TabIndex        =   45
      Top             =   7320
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
      Left            =   5760
      Picture         =   "CC_Cat_Documentos.frx":1024
      Style           =   1  'Graphical
      TabIndex        =   44
      Top             =   7320
      Visible         =   0   'False
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
      Left            =   3960
      Picture         =   "CC_Cat_Documentos.frx":173F
      Style           =   1  'Graphical
      TabIndex        =   43
      Top             =   7320
      Visible         =   0   'False
      Width           =   1695
   End
   Begin TabDlg.SSTab SSTab 
      Height          =   6855
      Left            =   120
      TabIndex        =   7
      Top             =   120
      Width           =   10935
      _ExtentX        =   19288
      _ExtentY        =   12091
      _Version        =   393216
      Tabs            =   2
      Tab             =   1
      TabsPerRow      =   2
      TabHeight       =   520
      BackColor       =   16777215
      TabCaption(0)   =   "Documentos"
      TabPicture(0)   =   "CC_Cat_Documentos.frx":1E4F
      Tab(0).ControlEnabled=   0   'False
      Tab(0).Control(0)=   "FrmOpt(2)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "LblOpt(3)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "Tipos de Documentos"
      TabPicture(1)   =   "CC_Cat_Documentos.frx":1E6B
      Tab(1).ControlEnabled=   -1  'True
      Tab(1).Control(0)=   "LblOpt(1)"
      Tab(1).Control(0).Enabled=   0   'False
      Tab(1).Control(1)=   "FrmOpt(0)"
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
         Height          =   6540
         Index           =   0
         Left            =   0
         TabIndex        =   36
         Top             =   320
         Width           =   10935
         Begin VB.TextBox TxtNombreD 
            Height          =   375
            Left            =   1560
            TabIndex        =   5
            Top             =   1200
            Width           =   3615
         End
         Begin VB.ComboBox CmbStatusD 
            Height          =   360
            Left            =   5400
            Style           =   2  'Dropdown List
            TabIndex        =   6
            Top             =   1200
            Width           =   2295
         End
         Begin VB.TextBox TxtIdDocD 
            Height          =   375
            Left            =   360
            Locked          =   -1  'True
            MaxLength       =   5
            TabIndex        =   4
            Top             =   1200
            Width           =   975
         End
         Begin MSComctlLib.ListView LstTipoDoc 
            Height          =   4575
            Left            =   240
            TabIndex        =   38
            Top             =   1800
            Width           =   10455
            _ExtentX        =   18441
            _ExtentY        =   8070
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
            BackColor       =   &H00FFFFFF&
            Caption         =   "Nombre"
            Height          =   255
            Left            =   1560
            TabIndex        =   42
            Top             =   960
            Width           =   855
         End
         Begin VB.Label Label2 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clave"
            Height          =   240
            Left            =   360
            TabIndex        =   41
            Top             =   960
            Width           =   465
         End
         Begin VB.Label Label1 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Status"
            Height          =   240
            Left            =   5400
            TabIndex        =   40
            Top             =   960
            Width           =   570
         End
         Begin VB.Label LblDoc 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Documento"
            ForeColor       =   &H000000C0&
            Height          =   240
            Index           =   0
            Left            =   360
            TabIndex        =   37
            Top             =   360
            Width           =   990
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
         Height          =   6540
         Index           =   2
         Left            =   -75000
         TabIndex        =   30
         Top             =   320
         Width           =   10935
         Begin VB.ComboBox CmbCargoAbono 
            Height          =   360
            Left            =   5280
            Style           =   2  'Dropdown List
            TabIndex        =   2
            Top             =   600
            Width           =   2295
         End
         Begin VB.TextBox TxtIdDoc 
            Height          =   375
            Left            =   240
            Locked          =   -1  'True
            MaxLength       =   5
            TabIndex        =   0
            Top             =   600
            Width           =   975
         End
         Begin VB.ComboBox CmbStatus 
            Height          =   360
            Left            =   7800
            Style           =   2  'Dropdown List
            TabIndex        =   3
            Top             =   600
            Width           =   2295
         End
         Begin VB.TextBox TxtNombre 
            Height          =   375
            Left            =   1440
            TabIndex        =   1
            Top             =   600
            Width           =   3615
         End
         Begin MSComctlLib.ListView LstDocumentos 
            Height          =   5175
            Left            =   240
            TabIndex        =   31
            Top             =   1200
            Width           =   10455
            _ExtentX        =   18441
            _ExtentY        =   9128
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
         Begin VB.Label Label3 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cargo/Abono"
            Height          =   240
            Left            =   5280
            TabIndex        =   39
            Top             =   360
            Width           =   1125
         End
         Begin VB.Label Label8 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Status"
            Height          =   240
            Left            =   7800
            TabIndex        =   34
            Top             =   360
            Width           =   570
         End
         Begin VB.Label Label11 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clave"
            Height          =   240
            Left            =   240
            TabIndex        =   33
            Top             =   360
            Width           =   465
         End
         Begin VB.Label Label12 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Nombre"
            Height          =   255
            Left            =   1440
            TabIndex        =   32
            Top             =   360
            Width           =   855
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
         TabIndex        =   8
         Top             =   320
         Width           =   12375
         Begin VB.Frame FrmOpc 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Tipo de Asignación"
            Height          =   735
            Left            =   120
            TabIndex        =   12
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
               Picture         =   "CC_Cat_Documentos.frx":1E87
               Style           =   1  'Graphical
               TabIndex        =   16
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
               Picture         =   "CC_Cat_Documentos.frx":21C5
               Style           =   1  'Graphical
               TabIndex        =   15
               Top             =   240
               Visible         =   0   'False
               Width           =   855
            End
            Begin VB.TextBox TxtListaPrecio 
               Height          =   375
               Left            =   6240
               Locked          =   -1  'True
               TabIndex        =   14
               Top             =   360
               Visible         =   0   'False
               Width           =   3735
            End
            Begin VB.TextBox TxtCedi 
               Height          =   375
               Left            =   1320
               MaxLength       =   50
               TabIndex        =   13
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
               TabIndex        =   18
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
               TabIndex        =   17
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
            TabIndex        =   11
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
            TabIndex        =   10
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
            TabIndex        =   9
            Top             =   240
            Width           =   1335
         End
         Begin MSComctlLib.ListView LstListasPrecios 
            Height          =   2775
            Left            =   240
            TabIndex        =   19
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
            TabIndex        =   20
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
            TabIndex        =   21
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
            TabIndex        =   22
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
            TabIndex        =   26
            Top             =   5400
            Width           =   12015
         End
         Begin VB.Label LblCedis 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cedis"
            Height          =   255
            Left            =   480
            TabIndex        =   25
            Top             =   3360
            Width           =   2175
         End
         Begin VB.Label Label7 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Lista de Precio"
            Height          =   255
            Left            =   360
            TabIndex        =   24
            Top             =   600
            Width           =   1575
         End
         Begin VB.Label LblOpcion 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clientes / Rutas"
            Enabled         =   0   'False
            Height          =   255
            Left            =   6480
            TabIndex        =   23
            Top             =   600
            Width           =   1575
         End
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Documentos"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   3
         Left            =   -75000
         TabIndex        =   35
         Top             =   0
         Width           =   5535
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
         TabIndex        =   29
         Top             =   0
         Width           =   4130
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Tipos de Documentos"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   1
         Left            =   5400
         TabIndex        =   28
         Top             =   0
         Width           =   5535
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
         TabIndex        =   27
         Top             =   0
         Width           =   4110
      End
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
      Left            =   4200
      TabIndex        =   47
      Top             =   7440
      Width           =   2295
   End
End
Attribute VB_Name = "CC_Cat_Documentos"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDDocs, Opcion, IdDoc, CargoAbono, LstDTipoDoc

Private Sub btnActualizar_Click()
On Error Resume Next
    If Opcion = 1 Or Opcion = 2 Then
        If SSTab.Tab = 0 Then
            If Trim(TxtIdDoc.Text) = "" Or Trim(TxtNombre.Text) = "" Or cmbStatus.ListIndex = 0 Or CmbCargoAbono.ListIndex = 0 Then
                MsgBox "¡ Capture todos los datos !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            StrCmd = "execute up_Documentos '" & Trim(TxtIdDoc.Text) & "', '" & Trim(TxtNombre.Text) & "', '" & IIf(CmbCargoAbono.ListIndex = 1, "C", "A") & "', '" & IIf(cmbStatus.ListIndex = 1, "A", "B") & "', " & Opcion
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
                  
            MuestraDocumentos
            Opcion = 0: LblEdicion.Caption = "Consulta": TxtIdDoc.Locked = True
            MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title
        End If
        
        If SSTab.Tab = 1 Then
            If Trim(TxtIdDocD.Text) = "" Or Trim(TxtNombreD.Text) = "" Or CmbStatusD.ListIndex = 0 Then
                MsgBox "¡ Capture todos los datos !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            StrCmd = "execute up_DocumentosTipo '" & IdDoc & "', '" & Trim(TxtIdDocD.Text) & "', '" & CargoAbono & "', '" & Trim(TxtNombreD.Text) & "', '" & IIf(CmbStatusD.ListIndex = 1, "A", "B") & "', " & Opcion
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
                  
            MuestraTipos
            Opcion = 0: LblEdicion.Caption = "Consulta": TxtIdDocD.Locked = True
            MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title
        End If
        
    End If
End Sub

Private Sub btnNuevo_Click()
On Error Resume Next
    Opcion = 1: LblEdicion.Caption = "Nuevo"
    If SSTab.Tab = 0 Then
        TxtIdDoc.Text = "": TxtNombre.Text = "": cmbStatus.ListIndex = 0: CmbCargoAbono.ListIndex = 0
        TxtIdDoc.Locked = False
    Else
        TxtIdDocD.Text = "": TxtNombreD.Text = "": CmbStatusD.ListIndex = 0
        TxtIdDocD.Locked = False
    End If
End Sub

Private Sub Form_Load()
On Error Resume Next
    SSTab.Tab = 0
    SSTab_Click 0
End Sub

Private Sub LstDocumentos_Click()
On Error Resume Next
    TxtIdDoc.Locked = True: TxtIdDocD.Locked = True
    If IsEmpty(LstDDocs) Then Exit Sub
    
    TxtIdDoc.Text = LstDDocs(0, LstDocumentos.SelectedItem.Index - 1)
    TxtNombre.Text = LstDDocs(1, LstDocumentos.SelectedItem.Index - 1)
    CmbCargoAbono.ListIndex = IIf(UCase(Trim(LstDDocs(2, LstDocumentos.SelectedItem.Index - 1))) = "CARGO", 1, 2)
    cmbStatus.ListIndex = IIf(UCase(Trim(LstDDocs(3, LstDocumentos.SelectedItem.Index - 1))) = "ACTIVO", 1, 2)
End Sub

Private Sub LstDocumentos_DblClick()
On Error Resume Next
    Opcion = 2: LblEdicion.Caption = "Editar": TxtIdDoc.Locked = True
End Sub

Private Sub LstDocumentos_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstDocumentos_Click
End Sub

Private Sub LstTipoDoc_Click()
On Error Resume Next
    Opcion = 0: LblEdicion.Caption = "Consulta"
    
    If IsEmpty(LstDTipoDoc) Then Exit Sub
    
    TxtIdDocD.Text = LstTipoDoc.SelectedItem
    TxtNombreD.Text = LstTipoDoc.SelectedItem.ListSubItems(1)
    CmbStatusD.ListIndex = IIf(UCase(Trim(LstDTipoDoc(3, LstTipoDoc.SelectedItem.Index - 1))) = "ACTIVO", 1, 2)
End Sub

Private Sub LstTipoDoc_DblClick()
On Error Resume Next
    Opcion = 2: LblEdicion.Caption = "Editar"
End Sub

Private Sub LstTipoDoc_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstTipoDoc_Click
End Sub

Private Sub SSTab_Click(PreviousTab As Integer)
On Error Resume Next
    Opcion = 0: LblEdicion.Caption = "Consulta"

    If IsEmpty(LstDDocs) And SSTab.Tab > 0 Then
        SSTab.Tab = 0
        Exit Sub
    Else
        If SSTab.Tab > 0 Then
            IdDoc = LstDDocs(0, LstDocumentos.SelectedItem.Index - 1)
            CargoAbono = Mid(LstDDocs(2, LstDocumentos.SelectedItem.Index - 1), 1, 1)
            LblDoc(0).Caption = LstDDocs(0, LstDocumentos.SelectedItem.Index - 1) & " - " & LstDDocs(1, LstDocumentos.SelectedItem.Index - 1) & " - " & LstDDocs(2, LstDocumentos.SelectedItem.Index - 1)
        End If
    End If

    Select Case SSTab.Tab
        Case 0:
            MuestraDocumentos
            LlenaCombos
        Case 1:
            MuestraTipos
            LlenaStatusD
            TxtIdDocD.Text = "": TxtNombreD.Text = "": CmbStatusD.ListIndex = 0
    End Select
End Sub

Sub MuestraDocumentos()
On Error Resume Next
    StrCmd = "execute sel_Documentos '', 2"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDDocs = GetDataLVL(RsC, LstDocumentos, 0, 3, "0|0|0|0")
End Sub

Sub LlenaCombos()
On Error Resume Next

    cmbStatus.Clear
    cmbStatus.AddItem "<Status>"
    cmbStatus.ItemData(cmbStatus.NewIndex) = "0"
    cmbStatus.AddItem "Activo"
    cmbStatus.ItemData(cmbStatus.NewIndex) = "2"
    cmbStatus.AddItem "Baja"
    cmbStatus.ItemData(cmbStatus.NewIndex) = "1"
    
    cmbStatus.ListIndex = 0
    
    CmbCargoAbono.Clear
    CmbCargoAbono.AddItem "<Cargo/Abono>"
    CmbCargoAbono.ItemData(CmbCargoAbono.NewIndex) = "0"
    CmbCargoAbono.AddItem "Cargo"
    CmbCargoAbono.ItemData(CmbCargoAbono.NewIndex) = "2"
    CmbCargoAbono.AddItem "Abono"
    CmbCargoAbono.ItemData(CmbCargoAbono.NewIndex) = "1"
    CmbCargoAbono.ListIndex = 0
    
End Sub

Sub MuestraTipos()
On Error Resume Next
    StrCmd = "execute sel_DocumentosTipo '" & IdDoc & "', '" & CargoAbono & "', 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDTipoDoc = GetDataLVL(RsC, LstTipoDoc, 1, 3, "0|0|0")
End Sub

Sub LlenaStatusD()
On Error Resume Next

    CmbStatusD.Clear
    CmbStatusD.AddItem "<Status>"
    CmbStatusD.ItemData(CmbStatusD.NewIndex) = "0"
    CmbStatusD.AddItem "Activo"
    CmbStatusD.ItemData(CmbStatusD.NewIndex) = "2"
    CmbStatusD.AddItem "Baja"
    CmbStatusD.ItemData(CmbStatusD.NewIndex) = "1"
    
    CmbStatusD.ListIndex = 0
    
End Sub

Private Sub TxtIdDoc_GotFocus()
On Error Resume Next
    SelText TxtIdDoc
End Sub

Private Sub TxtIdDoc_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtIdDoc_Validate(Cancel As Boolean)
On Error Resume Next
    StrCmd = "execute sel_Documentos '" & Trim(TxtIdDoc.Text) & "', 3"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    If Not RsC.EOF And Opcion = 1 Then
        TxtIdDoc.Text = ""
        MsgBox "¡ La clave del Documento ya existe !. Teclee otra clave.", vbInformation + vbOKOnly, App.Title
        TxtIdDoc.SetFocus
        Exit Sub
    End If
End Sub

Private Sub TxtIdDocD_GotFocus()
On Error Resume Next
    SelText TxtIdDocD
End Sub

Private Sub TxtIdDocD_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtNombre_GotFocus()
On Error Resume Next
    SelText TxtNombre
End Sub

Private Sub TxtNombre_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtNombreD_GotFocus()
On Error Resume Next
    SelText TxtNombreD
End Sub

Private Sub TxtNombreD_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub
