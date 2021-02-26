VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form AL_Almacen 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Almacén del Centro de Distribución"
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
      Left            =   7080
      Picture         =   "AL_Almacen.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   19
      Top             =   7680
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
      Left            =   10680
      Picture         =   "AL_Almacen.frx":0710
      Style           =   1  'Graphical
      TabIndex        =   18
      Top             =   7680
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
      Left            =   3480
      Picture         =   "AL_Almacen.frx":0E2B
      Style           =   1  'Graphical
      TabIndex        =   17
      Top             =   7680
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
      Left            =   5280
      Picture         =   "AL_Almacen.frx":14B9
      Style           =   1  'Graphical
      TabIndex        =   16
      Top             =   7680
      Width           =   1695
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
      Left            =   8880
      Picture         =   "AL_Almacen.frx":1E4F
      Style           =   1  'Graphical
      TabIndex        =   15
      Top             =   7680
      Width           =   1695
   End
   Begin TabDlg.SSTab SSTab 
      Height          =   6615
      Left            =   120
      TabIndex        =   9
      Top             =   720
      Width           =   12375
      _ExtentX        =   21828
      _ExtentY        =   11668
      _Version        =   393216
      TabHeight       =   520
      BackColor       =   16777215
      TabCaption(0)   =   "&Entradas/Salidas"
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "LblOpt(0)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "FrmOpt(0)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "Inventario &Físico"
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "FrmOpt(3)"
      Tab(1).Control(1)=   "LblOpt(3)"
      Tab(1).ControlCount=   2
      TabCaption(2)   =   "Inventario &Inicial"
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "LblOpt(4)"
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
         Height          =   6270
         Index           =   4
         Left            =   -75000
         TabIndex        =   22
         Top             =   350
         Width           =   12375
         Begin VB.TextBox TxtIdProd 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   360
            MaxLength       =   5
            TabIndex        =   25
            Top             =   600
            Width           =   735
         End
         Begin VB.TextBox TxtDesc 
            Height          =   375
            Left            =   1200
            TabIndex        =   24
            Top             =   600
            Width           =   5535
         End
         Begin VB.TextBox TxtCantidad 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   6840
            MaxLength       =   8
            TabIndex        =   23
            Top             =   600
            Width           =   1095
         End
         Begin MSComctlLib.ListView LstInvInicial 
            Height          =   5055
            Left            =   360
            TabIndex        =   26
            Top             =   1080
            Width           =   11535
            _ExtentX        =   20346
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
         Begin VB.Label Label8 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Descripción del Producto"
            Height          =   255
            Left            =   1200
            TabIndex        =   30
            Top             =   360
            Width           =   3735
         End
         Begin VB.Label Label5 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cve. P"
            Height          =   255
            Left            =   360
            TabIndex        =   29
            Top             =   360
            Width           =   615
         End
         Begin VB.Label Label3 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cantidad"
            Height          =   255
            Left            =   6840
            TabIndex        =   28
            Top             =   360
            Width           =   1095
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
         Height          =   6270
         Index           =   3
         Left            =   -75000
         TabIndex        =   20
         Top             =   350
         Width           =   12375
         Begin VB.TextBox TxtCantidadF 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   6840
            MaxLength       =   8
            TabIndex        =   42
            Top             =   600
            Width           =   1095
         End
         Begin VB.TextBox TxtDescF 
            Height          =   375
            Left            =   1200
            TabIndex        =   41
            Top             =   600
            Width           =   5535
         End
         Begin VB.TextBox TxtIdProdF 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   360
            MaxLength       =   10
            TabIndex        =   40
            Top             =   600
            Width           =   735
         End
         Begin MSComctlLib.ListView LstInvFisico 
            Height          =   5055
            Left            =   360
            TabIndex        =   43
            Top             =   1080
            Width           =   11535
            _ExtentX        =   20346
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
         Begin VB.Label Label14 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cantidad"
            Height          =   255
            Left            =   6840
            TabIndex        =   46
            Top             =   360
            Width           =   1095
         End
         Begin VB.Label Label13 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cve. P"
            Height          =   255
            Left            =   360
            TabIndex        =   45
            Top             =   360
            Width           =   615
         End
         Begin VB.Label Label12 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Descripción del Producto"
            Height          =   255
            Left            =   1200
            TabIndex        =   44
            Top             =   360
            Width           =   3735
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
         Height          =   6270
         Index           =   0
         Left            =   0
         TabIndex        =   11
         Top             =   350
         Width           =   12375
         Begin VB.Frame FrmDetES 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Productos Registrados en la Entrada/Salida"
            Enabled         =   0   'False
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   5910
            Left            =   6240
            TabIndex        =   36
            Top             =   240
            Width           =   6015
            Begin VB.TextBox TxtCantidadES 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   4680
               MaxLength       =   8
               TabIndex        =   7
               Top             =   720
               Width           =   1095
            End
            Begin VB.TextBox TxtDescES 
               Height          =   375
               Left            =   960
               TabIndex        =   6
               Top             =   720
               Width           =   3615
            End
            Begin VB.TextBox TxtIdProdES 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   120
               MaxLength       =   10
               TabIndex        =   5
               Top             =   720
               Width           =   735
            End
            Begin MSComctlLib.ListView LstEntradasProds 
               Height          =   4575
               Left            =   120
               TabIndex        =   8
               Top             =   1200
               Width           =   5775
               _ExtentX        =   10186
               _ExtentY        =   8070
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
            Begin VB.Label Label11 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Cantidad"
               Height          =   255
               Left            =   4680
               TabIndex        =   39
               Top             =   480
               Width           =   1095
            End
            Begin VB.Label Label10 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Cve. P"
               Height          =   255
               Left            =   120
               TabIndex        =   38
               Top             =   480
               Width           =   615
            End
            Begin VB.Label Label9 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Descripción del Producto"
               Height          =   255
               Left            =   1080
               TabIndex        =   37
               Top             =   480
               Width           =   3375
            End
         End
         Begin VB.Frame FrmES 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Datos de la Entrada/Salida"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   5910
            Left            =   120
            TabIndex        =   31
            Top             =   240
            Width           =   6015
            Begin VB.ComboBox cmbTipo 
               Height          =   360
               Left            =   1080
               Locked          =   -1  'True
               Style           =   2  'Dropdown List
               TabIndex        =   1
               Top             =   600
               Width           =   4815
            End
            Begin VB.TextBox TxtObs 
               Height          =   1080
               Left            =   1680
               MaxLength       =   5000
               MultiLine       =   -1  'True
               ScrollBars      =   2  'Vertical
               TabIndex        =   3
               Top             =   1320
               Width           =   4215
            End
            Begin VB.TextBox TxtFolio 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   120
               Locked          =   -1  'True
               TabIndex        =   0
               Top             =   600
               Width           =   855
            End
            Begin VB.TextBox TxtFolioT 
               Height          =   375
               Left            =   120
               MaxLength       =   10
               TabIndex        =   2
               Top             =   1320
               Width           =   1455
            End
            Begin MSComctlLib.ListView LstEntradas 
               Height          =   3255
               Left            =   120
               TabIndex        =   4
               Top             =   2520
               Width           =   5775
               _ExtentX        =   10186
               _ExtentY        =   5741
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
            Begin VB.Label Label7 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Observaciones"
               Height          =   255
               Left            =   1680
               TabIndex        =   35
               Top             =   1080
               Width           =   1695
            End
            Begin VB.Label Label6 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Tipo de Entrada/Salida"
               Height          =   255
               Left            =   1080
               TabIndex        =   34
               Top             =   360
               Width           =   2295
            End
            Begin VB.Label Label4 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Folio"
               Height          =   255
               Left            =   120
               TabIndex        =   33
               Top             =   360
               Width           =   615
            End
            Begin VB.Label Label1 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Folio Transporte"
               Height          =   255
               Left            =   120
               TabIndex        =   32
               Top             =   1080
               Width           =   1455
            End
         End
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Inv. Inicial"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   4
         Left            =   -66795
         TabIndex        =   27
         Top             =   0
         Width           =   4170
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Inv. Físico"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   3
         Left            =   -70920
         TabIndex        =   21
         Top             =   0
         Width           =   4215
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Entradas/Salidas"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   0
         Left            =   0
         TabIndex        =   10
         Top             =   0
         Width           =   4170
      End
   End
   Begin MSComCtl2.DTPicker DTPFecha 
      Height          =   375
      Left            =   1080
      TabIndex        =   12
      Top             =   240
      Width           =   1455
      _ExtentX        =   2566
      _ExtentY        =   661
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
      Format          =   103612417
      CurrentDate     =   39376
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
      Left            =   2520
      TabIndex        =   47
      Top             =   7800
      Width           =   810
   End
   Begin VB.Label LblStatus 
      AutoSize        =   -1  'True
      BackColor       =   &H00FFFFFF&
      Caption         =   "Estatus del Movimiento"
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
      Height          =   240
      Left            =   2640
      TabIndex        =   14
      Top             =   240
      Width           =   2190
   End
   Begin VB.Label Label2 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Fecha"
      Height          =   255
      Left            =   240
      TabIndex        =   13
      Top             =   240
      Width           =   615
   End
End
Attribute VB_Name = "AL_Almacen"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public LstDEntradas
Dim Nuevo As Boolean, LstDTipo, LstDEntradasProds, LstDInvFisico, LstDInvInicial

Private Sub ActInvInicialFisico(Opc As Integer)
On Error Resume Next
If Opc = 1 Then
    If Dec Then
        TxtCantidadF.Text = CStr(itFlotante(TxtCantidadF.Text))
        If Trim(TxtCantidadF.Text) = "0" Then Exit Sub
    End If
Else
    If Dec Then
        TxtCantidad.Text = CStr(itFlotante(TxtCantidad.Text))
        If Trim(TxtCantidad.Text) = "0" Then Exit Sub
    End If
End If

MousePointer = 11
On Error GoTo Err_ActInvInicialFisico:

    If Opc = 1 Then
        StrCmd = "execute up_InvFisico " & IdCedis & ", '" & FormatDate(Fecha) & "', " & Trim(TxtIdProdF.Text) & ", " & Trim(TxtCantidadF.Text)
    Else
        StrCmd = "execute up_InvInicial " & IdCedis & ", " & Agno & ", " & Mes & ", " & Trim(TxtIdProd.Text) & ", " & Trim(TxtCantidad.Text)
    End If
    
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    CargaInventarioInicialFisico False, Opc

No_Err_ActInvInicialFisico:
    MousePointer = 0
    Exit Sub
    
Err_ActInvInicialFisico:
    MousePointer = 0
    MsgBox "¡ Error al Aplicar el Inventario !. Error: " & Err.Description, vbCritical + vbOKOnly, App.Title
    GoTo No_Err_ActInvInicialFisico:
    
End Sub

Private Sub btnActualizar_Click()
On Error GoTo Err_NuevoDcto:

Dim Tipo, Selected
    
If Not ValidaDiaySurtido(IdCedis, 0, Fecha) Then Exit Sub
Select Case SSTab.Tab
    Case 0: If Not ValidaModulo("ALMES", True) Then Exit Sub
    Case 1: If Not ValidaModulo("ALMFIS", True) Then Exit Sub
    Case 2: If Not ValidaModulo("ALMINI", True) Then Exit Sub
End Select

MousePointer = 11
    
    Select Case SSTab.Tab
        Case 0:
            If (IsEmpty(LstDEntradas) Or LstEntradas.ListItems.Count = 0) And Not Nuevo Then Exit Sub
            If Not Nuevo Then
                DocumentoAplicado = IIf(LstEntradas.SelectedItem.SubItems(1) = "Pendiente", False, True)
                If DocumentoAplicado Then
                    MousePointer = 0
                    MsgBox "¡ No puedes Actualizar un movimiento de Entrada o Salida que ya ha sido Aplicado !", vbInformation + vbOKOnly, App.Title
                    Exit Sub
                End If
            End If
            
            If Trim(TxtFolio.Text) = "" And Nuevo = False Then
                MousePointer = 0
                MsgBox "¡ Seleccione un movimiento de Entrada o Salida !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            If cmbTipo.ListIndex = 0 Then
                MousePointer = 0
                MsgBox "¡ Seleccione un Tipo de Movimiento de Entrada o Salida !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            Dim IdEntrada As Long
            If IsEmpty(LstDEntradas) Then
                Selected = 0
                IdEntrada = 0
'            Else
'                Tipo = Split(LstDTipo(0, cmbTipo.ListIndex - 1), "|")
'                Selected = Tipo(0)
'                If Not IsEmpty(LstDEntradas) Then IdEntrada = CLng(LstEntradas.SelectedItem)
            End If
            Tipo = IIf(cmbTipo.ListIndex = 0, 0, Split(LstDTipo(0, cmbTipo.ListIndex - 1), "|"))
'            If IsEmpty(IdEntrada) Then
'                IdEntrada = 0
'            Else
'
'            End If
            
            StrCmd = "execute up_Movimientos " & IdCedis & ", " & IdEntrada & ", '" & FormatDate(Fecha) & "', " & Tipo(0) & ", '" & UCase(Trim(TxtObs.Text)) & "', '" & UCase(Trim(TxtFolioT.Text)) & "', 'P', " & IIf(Nuevo, 1, 2) & ""
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraEntradasSalidas
            
            If Not Nuevo Then
                LstEntradas.ListItems.Item(Selected).Selected = True
                LstEntradas_DblClick
            End If
            MousePointer = 0
            MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
    End Select


No_Err_NuevoDcto:
    Nuevo = False: cmbTipo.Locked = True
    MousePointer = 0
    LblEdicion.Caption = "Consultar"
    Exit Sub
    
Err_NuevoDcto:
    MousePointer = 0
    MsgBox "¡ Error al actualizar los Datos del Documento !. Error: " & Err.Description, vbCritical + vbOKOnly, App.Title
    GoTo No_Err_NuevoDcto:
End Sub

Private Sub btnAplica_Click()
On Error GoTo Err_AplicaInvInicial:

Dim Mensaje

If Not ValidaDiaySurtido(IdCedis, 0, Fecha) Then Exit Sub
Select Case SSTab.Tab
    Case 0: If Not ValidaModulo("ALMES", True) Then Exit Sub
    Case 1: If Not ValidaModulo("ALMFIS", True) Then Exit Sub
    Case 2: If Not ValidaModulo("ALMINI", True) Then Exit Sub
End Select

MousePointer = 11
    
    If MsgBox("¿ Está seguro de Aplicar el Documento seleccionado ?." & Chr(13) & Chr(10) & "Una vez Aplicado no podrá hacer cambios. ¿ Desea continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then
        MousePointer = 0
        Exit Sub
    End If
    
    Select Case SSTab.Tab
        Case 0:
            If IsEmpty(LstDEntradas) Or LstEntradas.ListItems.Count = 0 Then Exit Sub
            If Trim(TxtFolio.Text) = "" Then
                MousePointer = 0
                MsgBox "¡ Seleccione un movimiento de Entrada o Salida !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            DocumentoAplicado = IIf(LstEntradas.SelectedItem.SubItems(1) = "Pendiente", False, True)
            If DocumentoAplicado Then
                MousePointer = 0
                MsgBox "¡ No puedes Aplicar un movimiento de Entrada o Salida que ya ha sido Aplicado !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            Mensaje = "¡ El Documento: " & LstDEntradas(3, LstEntradas.SelectedItem.Index - 1) & " (" & IIf(LstDEntradas(8, LstEntradas.SelectedItem.Index - 1) = "S", "Salida", "Entrada") & ") ha sido Aplicado !"
            
            StrCmd = "execute up_Movimientos " & IdCedis & ", " & CLng(LstEntradas.SelectedItem) & ", '" & FormatDate(Fecha) & "', " & LstDEntradas(7, LstEntradas.SelectedItem.Index - 1) & ", '', '', 'A', 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraEntradasSalidas
            
            'valida kardex antes de ...
            StrCmd = "exec up_ActualizaKardex " & IdCedis & ", '" & FormatDate(FechaSel) & "', 0, 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn

            MousePointer = 0
            MsgBox Mensaje, vbInformation + vbOKOnly, App.Title
        
        Case 1:
            If DocumentoAplicado Then
                MousePointer = 0
                MsgBox "¡ No puedes Aplicar un Inventario Físico que ya ha sido Aplicado !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            StrCmd = "execute up_InvFisico " & IdCedis & ", '" & FormatDate(Fecha) & "', 0, 0"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            CargaInventarioInicialFisico False, 1
            
            'valida kardex antes de ...
            StrCmd = "exec up_ActualizaKardex " & IdCedis & ", '" & FormatDate(FechaSel) & "', 0, 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            
            MousePointer = 0
            MsgBox "¡ El Inventario Físico del " & Format(Fecha, "DDDD dd ""de"" MMMM ""de"" yyyy") & " ha sido Aplicado !", vbInformation + vbOKOnly, App.Title
        
        Case 2:
            If DocumentoAplicado Then
                MousePointer = 0
                MsgBox "¡ No puedes Aplicar un Inventario Inicial que ya ha sido Aplicado !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            StrCmd = "execute up_InvInicial " & IdCedis & ", " & Agno & ", " & Mes & ", 0, 0"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            CargaInventarioInicialFisico False, 2
            MousePointer = 0
            MsgBox "¡ El Inventario Inicial de " & Format(Fecha, "MMMM") & " ha sido Aplicado !", vbInformation + vbOKOnly, App.Title
    
    End Select
    
No_Err_AplicaInvInicial:
    MousePointer = 0
    LblEdicion.Caption = "Consultar"
    Exit Sub
    
Err_AplicaInvInicial:
    MousePointer = 0
    MsgBox "¡ Error al Aplicar el Documento !. Error: " & Err.Description, vbCritical + vbOKOnly, App.Title
    GoTo No_Err_AplicaInvInicial:
    
End Sub

Private Sub btnEliminar_Click()
On Error GoTo Err_EliminaAlmacen:

If Not ValidaDiaySurtido(IdCedis, 0, Fecha) Then Exit Sub
Select Case SSTab.Tab
    Case 0: If Not ValidaModulo("ALMES", True) Then Exit Sub
    Case 1: If Not ValidaModulo("ALMFIS", True) Then Exit Sub
    Case 2: If Not ValidaModulo("ALMINI", True) Then Exit Sub
End Select

MousePointer = 11

    If MsgBox("¿ Está seguro de Eliminar el Documento seleccionado ?", vbQuestion + vbYesNo, App.Title) = vbNo Then
        MousePointer = 0
        Exit Sub
    End If
    
    Select Case SSTab.Tab
        Case 0:
            If IsEmpty(LstDEntradas) Or LstEntradas.ListItems.Count = 0 Then Exit Sub
            If Trim(TxtFolio.Text) = "" Then
                MousePointer = 0
                MsgBox "¡ Seleccione un movimiento de Entrada o Salida !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            DocumentoAplicado = IIf(LstEntradas.SelectedItem.SubItems(1) = "Aplicado", True, False)
            If DocumentoAplicado Then
                MousePointer = 0
                MsgBox "¡ No puedes Eliminar un movimiento de Entrada o Salida que ya ha sido Aplicado !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            ' Elimina movimientos
            StrCmd = "execute up_Movimientos " & IdCedis & ", " & CLng(LstEntradas.SelectedItem) & ", '01/01/1900', 0, '', '', 'B', 4"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            
            'Actualiza Kardex
            StrCmd = "execute up_ActualizaKardex " & IdCedis & ", '" & FormatDate(Fecha) & "', 0, 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            
            MuestraEntradasSalidas
            MousePointer = 0
            MsgBox "¡ El Documento se ha Eliminado !", vbInformation + vbOKOnly, App.Title
        
        Case 1:
            If DocumentoAplicado Then
                MousePointer = 0
                MsgBox "¡ No puedes Eliminar un Inventario Físico que ya ha sido Aplicado !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        
            StrCmd = "execute up_InvFisico " & IdCedis & ", '" & FormatDate(Fecha) & "', -1, 0"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            CargaInventarioInicialFisico False, 1
            MousePointer = 0
            MsgBox "¡ El Inventario Físico del " & Format(Fecha, "dddd dd ""de"" MMMM ""de"" yyyy") & " ha sido Eliminado !", vbInformation + vbOKOnly, App.Title
            TxtIdProdF.SetFocus
        
        Case 2:
            If DocumentoAplicado Then
                MousePointer = 0
                MsgBox "¡ No puedes Eliminar un Inventario Inicial que ya ha sido Aplicado !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        
            StrCmd = "execute up_InvInicial " & IdCedis & ", " & Agno & ", " & Mes & ", -1, 0"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            CargaInventarioInicialFisico False, 2
            MousePointer = 0
            MsgBox "¡ El Inventario Inicial de " & Format(Fecha, "MMMM") & " ha sido Eliminado !", vbInformation + vbOKOnly, App.Title
            TxtIdProd.SetFocus
    End Select

No_Err_EliminaAlmacen:
    LblEdicion.Caption = "Consultar"
    Exit Sub
    
Err_EliminaAlmacen:
    MousePointer = 0
    MsgBox "¡ Error al Eliminar el Documento !. Error: " & Err.Description, vbCritical + vbOKOnly, App.Title
    GoTo No_Err_EliminaAlmacen:

End Sub

Private Sub btnImprimir_Click()
On Error GoTo Err_ImpAlmacen:
    AL_RptAlmacenDocumentos.ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): AL_RptAlmacenDocumentos.ImgLogo.Height = 810: AL_RptAlmacenDocumentos.ImgLogo.Width = 1920
    Select Case Me.SSTab.Tab
        Case 0:
            If IsEmpty(LstDEntradas) Or LstEntradas.ListItems.Count = 0 Then Exit Sub
            If Trim(TxtFolio.Text) = "" Then
                MsgBox "¡ Selecciona un Documento de Entrada o Salida a Imprimir !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            'Entradas o Salidas
            MuestraDetalleEntradasSalidas CLng(LstDEntradas(1, LstEntradas.SelectedItem.Index - 1)), True
            AL_RptAlmacenDocumentos.LblTitulo.Caption = "REPORTE DE " & IIf(LstDEntradas(8, LstEntradas.SelectedItem.Index - 1) = "E", "ENTRADA", "SALIDA") & "  A ALMACÉN"
            AL_RptAlmacenDocumentos.LblCedis.Caption = "Centro de Distribución: " & IdCedis & " - " & NomCedis
            AL_RptAlmacenDocumentos.LblDatos.Caption = "Fecha del Documento: " & Format(Fecha, "dddd dd ""de"" MMMM ""de"" yyyy ")
            AL_RptAlmacenDocumentos.LblTipo.Caption = "FOLIO: " & Format(CLng(LstDEntradas(1, LstEntradas.SelectedItem.Index - 1)), "0000000") & "  " & _
            LstDEntradas(3, LstEntradas.SelectedItem.Index - 1) & " (" & IIf(LstDEntradas(8, LstEntradas.SelectedItem.Index - 1) = "E", "Entrada)", "Salida)")
            AL_RptAlmacenDocumentos.LblStatus.Caption = "Estatus: " & LstDEntradas(2, LstEntradas.SelectedItem.Index - 1)
            AL_RptAlmacenDocumentos.LblObs.Caption = "Folio Trans. " & TxtFolioT.Text & ". Observaciones: " & TxtObs.Text
        Case 1, 2:
            'CargaInventarioInicialFisico
            CargaInventarioInicialFisico True, SSTab.Tab
            AL_RptAlmacenDocumentos.Line6.Y1 = AL_RptAlmacenDocumentos.Line6.Y1 - 200: AL_RptAlmacenDocumentos.Line6.Y2 = AL_RptAlmacenDocumentos.Line6.Y2 - 200
            AL_RptAlmacenDocumentos.ReportHeader.Height = AL_RptAlmacenDocumentos.ReportHeader.Height - 700
            AL_RptAlmacenDocumentos.LblTitulo.Caption = IIf(SSTab.Tab = 1, "INVENTARIO FÍSICO", "INVENTARIO INICIAL")
            AL_RptAlmacenDocumentos.LblCedis.Caption = "Centro de Distribución: " & IdCedis & " - " & NomCedis
            If SSTab.Tab = 1 Then
                AL_RptAlmacenDocumentos.LblTipo.Caption = "Inventario Físico del " & Format(Fecha, "DDDD dd ""de"" MMMM ""de"" yyyy")
            Else
                AL_RptAlmacenDocumentos.LblTipo.Caption = "Inventario Inicial del mes de " & Format(Fecha, "MMMM") & " de " & Year(Fecha)
            End If
            AL_RptAlmacenDocumentos.LblDatos.Caption = ""
            AL_RptAlmacenDocumentos.LblStatus.Caption = "Estatus: " & IIf(DocumentoAplicado, "Aplicado", "Sin Aplicar")
    End Select
    
    If Not Rs.EOF Then
        AL_RptAlmacenDocumentos.object.DataSrc.DataSourceName = Cnn
        AL_RptAlmacenDocumentos.object.DataSrc.Recordset = Rs
    End If
    
    AL_RptAlmacenDocumentos.Printer.Orientation = ddOPortrait
    AL_RptAlmacenDocumentos.Printer.PaperSize = 1
    AL_RptAlmacenDocumentos.Show
    
No_Err_ImpAlmacen:
    MousePointer = 0
    Exit Sub
    
Err_ImpAlmacen:
    MousePointer = 0
    MsgBox "Error. " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_ImpAlmacen:

End Sub

Private Sub btnNuevo_Click()
On Error Resume Next
    If Not ValidaDiaySurtido(IdCedis, 0, Fecha) Then Exit Sub
    
    Select Case SSTab.Tab
        Case 0: If Not ValidaModulo("ALMES", True) Then Exit Sub
        Case 1: If Not ValidaModulo("ALMFIS", True) Then Exit Sub
        Case 2: If Not ValidaModulo("ALMINI", True) Then Exit Sub
    End Select
    
    LblEdicion.Caption = "Nuevo"
    Nuevo = True: cmbTipo.Locked = False
    TxtFolioT.Text = "": cmbTipo.ListIndex = 0: TxtObs.Text = ""
End Sub

Private Sub cmbTipo_Click()
On Error Resume Next
    'MsgBox cmbTipo.ListIndex
    'MsgBox LstDTipo(0, cmbTipo.ListIndex - 1) 'LstDEntradas(0, LstEntradas.SelectedItem - 1)
End Sub

Private Sub DTPFecha_Change()
On Error Resume Next
    If DTPFecha.Value > Date Then
        DTPFecha.Value = Date
        Exit Sub
    End If
    
    'Fecha = IIf(BIdioma = "us_english", Format(DTPFecha.Value, "mm/dd/yyyy"), Format(DTPFecha.Value, "dd/mm/yyyy")): Mes = Month(DTPFecha.Value): Agno = Year(DTPFecha.Value)
    Fecha = DTPFecha.Value: Mes = Month(DTPFecha.Value): Agno = Year(DTPFecha.Value)
    
    Select Case SSTab.Tab
        Case 0: SSTab_Click 0
        Case 1: SSTab_Click 0
        Case 2: SSTab_Click 0
    End Select
End Sub

Private Sub DTPFecha_Validate(Cancel As Boolean)
On Error Resume Next
    
'    Fecha = IIf(BIdioma = "us_english", Format(DTPFecha.Value, "mm/dd/yyyy"), Format(DTPFecha.Value, "dd/mm/yyyy")): Mes = Month(DTPFecha.Value): Agno = Year(DTPFecha.Value)
    Fecha = DTPFecha.Value: Mes = Month(DTPFecha.Value): Agno = Year(DTPFecha.Value)
    
    Select Case SSTab.Tab
        Case 0: SSTab_Click 0
        Case 2: SSTab_Click 0
    End Select
End Sub

Private Sub Form_Activate()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    AL_al_ProductosBusqueda.Hide
End Sub

Private Sub Form_Load()
On Error Resume Next
    DTPFecha.Value = Date
    
'    Fecha = IIf(BIdioma = "us_english", Format(DTPFecha.Value, "mm/dd/yyyy"), Format(DTPFecha.Value, "dd/mm/yyyy")): Mes = Month(DTPFecha.Value): Agno = Year(DTPFecha.Value)
    Fecha = DTPFecha.Value: Mes = Month(DTPFecha.Value): Agno = Year(DTPFecha.Value)
    
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    Nuevo = False
    
    'tab opción 0
    SSTab.Tab = 0
    SSTab_Click 0
End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    If Cnn.State Then Cnn.Close
    If Rs.State Then Rs.Close
End Sub

Private Sub LstEntradas_Click()
On Error Resume Next
    LstEntradas_DblClick
End Sub

Private Sub LstEntradas_DblClick()
On Error Resume Next
    
    If IsEmpty(LstDEntradas) Or LstEntradas.ListItems.Count = 0 Then Exit Sub
    
    Nuevo = False: cmbTipo.Locked = True
    TxtIdProdES.Text = "": TxtDescES.Text = "": TxtCantidadES.Text = ""
    DocumentoAplicado = IIf(LstEntradas.SelectedItem.SubItems(1) = "Pendiente", False, True)
    
    TxtFolio.Text = Format(LstDEntradas(1, LstEntradas.SelectedItem.Index - 1), "0000000")
    cmbTipo.ListIndex = SearchInList(LstDTipo, LstDEntradas(7, LstEntradas.SelectedItem.Index - 1) & "|" & LstDEntradas(8, LstEntradas.SelectedItem.Index - 1), 0)
    TxtFolioT.Text = LstDEntradas(5, LstEntradas.SelectedItem.Index - 1)
    TxtObs.Text = LstDEntradas(4, LstEntradas.SelectedItem.Index - 1)
    
    MuestraDetalleEntradasSalidas CLng(LstDEntradas(1, LstEntradas.SelectedItem.Index - 1)), False
    LblEdicion.Caption = IIf(LstEntradas.SelectedItem.SubItems(1) = "Pendiente", "Actualizar", "Consultar")
End Sub

Private Sub LstEntradas_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    LstEntradas_DblClick
End Sub

Private Sub LstInvFisico_DblClick()
On Error Resume Next

    If IsEmpty(LstDInvFisico) Then
        If MsgBox("¿ Deseas obtener el Inventario Físico a partir del Inventario Teórico ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
            
            StrCmd = "execute up_InvFisico " & IdCedis & ", '" & FormatDate(Fecha) & "', -2, 0"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            CargaInventarioInicialFisico False, 1
            
        End If
    End If
End Sub

Private Sub SSTab_Click(PreviousTab As Integer)
On Error Resume Next
    Select Case SSTab.Tab
        Case 0:
'            If Not ValidaModulo("ALMES", True) Then
'                Unload Me
'            End If
            LlenaComboTipo
            MuestraEntradasSalidas
            InhabBotonesEdit True, True
        
        Case 1:
'            If Not ValidaModulo("ALMFIS", True) Then
'                SSTab.Tab = 0
'                Exit Sub
'            End If
            InhabBotonesEdit False, True
            CargaInventarioInicialFisico False, 1
            TxtIdProdF.SetFocus
            
        Case 2:
'            If Not ValidaModulo("ALMINI", True) Then
'                SSTab.Tab = 0
'                Exit Sub
'            End If
            InhabBotonesEdit False, True
            CargaInventarioInicialFisico False, 2
            TxtIdProd.SetFocus
    
    End Select
End Sub

Private Sub TxtCantidad_GotFocus()
On Error Resume Next
    SelText TxtCantidad
End Sub

Private Sub TxtCantidad_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If Not ValidaModulo("ALMINI", True) Then Exit Sub
    If KeyAscii = "13" Then
        SplitTxt TxtCantidad
        If Not DocumentoAplicado Then ActInvInicialFisico 2
        TxtIdProd.SetFocus
    End If
    If Dec Then
        If KeyAscii <> "42" Then KeyAscii = itDecimal(KeyAscii)
    Else
        If KeyAscii <> "42" Then KeyAscii = itEntero(KeyAscii)
    End If
End Sub

Private Sub TxtCantidad_Validate(Cancel As Boolean)
On Error Resume Next
    If Dec Then
        TxtCantidad.Text = CStr(itFlotante(TxtCantidad.Text))
        If Trim(TxtCantidad.Text) = "0" Then Exit Sub
    End If
End Sub

Private Sub TxtCantidadES_GotFocus()
On Error Resume Next
    SelText TxtCantidadES
End Sub

Private Sub TxtCantidadES_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        
        If Not ValidaDiaySurtido(IdCedis, 0, Fecha) Then Exit Sub
        If Not ValidaModulo("ALMES", True) Then Exit Sub
        SplitTxt TxtCantidadES
        'Valida familia de producto válida para le movimiento
        StrCmd = "execute sel_MovimientosFamilias " & IdCedis & ", " & AL_Almacen.LstDEntradas(7, AL_Almacen.LstEntradas.SelectedItem.Index - 1) & ", " & TxtIdProdES.Text & ", 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If RsC.EOF Then
            MsgBox "¡ El Producto " & TxtIdProdES.Text & " no se puede registrar dentro de este Tipo de Movimiento de Almacén !", vbInformation + vbOKOnly, App.Title
            TxtDescES.Text = "¡ Producto no válido para este Tipo de Movimiento !": TxtCantidadES.Text = 0
            TxtIdProdES.SetFocus
            Exit Sub
        End If
        
        If Not DocumentoAplicado Then ActEntradasSalidas
        TxtIdProdES.SetFocus
    End If
    If Dec Then
        If KeyAscii <> "42" Then KeyAscii = itDecimal(KeyAscii)
    Else
        If KeyAscii <> "42" Then KeyAscii = itEntero(KeyAscii)
    End If
End Sub

Private Sub TxtCantidadES_Validate(Cancel As Boolean)
On Error Resume Next
    If Dec Then
        TxtCantidadES.Text = CStr(itFlotante(TxtCantidadES.Text))
        If Trim(TxtCantidadES.Text) = "0" Then Exit Sub
    End If
End Sub

Private Sub TxtCantidadF_GotFocus()
On Error Resume Next
    SelText TxtCantidadF
End Sub

Private Sub TxtCantidadF_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        
        If Not ValidaDiaySurtido(IdCedis, 0, Fecha) Then Exit Sub
        If Not ValidaModulo("ALMFIS", True) Then Exit Sub
        SplitTxt TxtCantidadF
        If Not DocumentoAplicado Then ActInvInicialFisico 1
        TxtIdProdF.SetFocus
    End If
    If Dec Then
        If KeyAscii <> "42" Then KeyAscii = itDecimal(KeyAscii)
    Else
        If KeyAscii <> "42" Then KeyAscii = itEntero(KeyAscii)
    End If
End Sub

Private Sub TxtCantidadF_Validate(Cancel As Boolean)
On Error Resume Next
    If Dec Then
        TxtCantidadF.Text = CStr(itFlotante(TxtCantidadF.Text))
        If Trim(TxtCantidadF.Text) = "0" Then Exit Sub
    End If
End Sub

Private Sub TxtDesc_Change()
On Error Resume Next
    AL_al_ProductosBusqueda.Hide
End Sub

Private Sub TxtDesc_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 And Trim(TxtDesc.Text) <> "" Then
        With AL_al_ProductosBusqueda
            .Opc = 6: .Left = 4000: .Top = 3700
            .FiltraProductos CStr(Trim(TxtDesc.Text))
            If Not .Visible Then .Show 0
        End With
    Else
        KeyAscii = itString(KeyAscii)
    End If
End Sub

Private Sub TxtDesc_Validate(Cancel As Boolean)
On Error Resume Next
    AL_al_ProductosBusqueda.Hide
End Sub

Private Sub TxtDescES_Change()
On Error Resume Next
    AL_al_ProductosBusqueda.Hide
End Sub

Private Sub TxtDescES_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 And Trim(TxtDescES.Text) <> "" Then
        With AL_al_ProductosBusqueda
            .Opc = 4: .Left = 9900: .Top = 4100
            .FiltraProductos CStr(Trim(TxtDescES.Text))
            If Not .Visible Then .Show 0
        End With
    Else
        KeyAscii = itString(KeyAscii)
    End If
End Sub

Private Sub TxtDescES_Validate(Cancel As Boolean)
On Error Resume Next
    AL_al_ProductosBusqueda.Hide
End Sub

Private Sub TxtDescF_Change()
On Error Resume Next
    AL_al_ProductosBusqueda.Hide
End Sub

Private Sub TxtDescF_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 And Trim(TxtDescF.Text) <> "" Then
        With AL_al_ProductosBusqueda
            .Opc = 5: .Left = 4000: .Top = 3700
            .FiltraProductos CStr(Trim(TxtDescF.Text))
            If Not .Visible Then .Show 0
        End With
    Else
        KeyAscii = itString(KeyAscii)
    End If
End Sub

Private Sub TxtDescF_Validate(Cancel As Boolean)
On Error Resume Next
    AL_al_ProductosBusqueda.Hide
End Sub

Private Sub TxtFolio_Change()
On Error Resume Next
    FrmDetES.Enabled = IIf(TxtFolio.Text = "", False, True)
End Sub

Private Sub TxtFolioT_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtIdProd_Change()
On Error Resume Next
    TxtDesc.Text = "": TxtCantidad.Text = 0
End Sub

Private Sub TxtIdProd_GotFocus()
On Error Resume Next
    SelText TxtIdProd
End Sub

Public Sub TxtIdProd_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If Trim(TxtIdProd.Text) = "0" Then
'        Forma = 3: AL_ProductosBusqueda.Show
    End If
    If KeyAscii = "13" Then
        TxtIdProd_Validate False
        TxtCantidad.SetFocus
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtIdProd_Validate(Cancel As Boolean)
On Error Resume Next
    Val_TxtId TxtIdProd, TxtDesc, TxtCantidad, 3
End Sub

Sub InhabBotonesEdit(Val As Boolean, Eliminar As Boolean)
On Error Resume Next
    LblStatus.Visible = Not Val
    btnNuevo.Visible = Val: btnActualizar.Visible = Val
    btnEliminar.Visible = Eliminar
End Sub

Sub LlenaComboTipo()
On Error Resume Next
    StrCmd = "execute sel_TipoMovimiento " & IdCedis
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDTipo = GetDataCBL(Rs, cmbTipo, "Seleccione un Tipo de Entrada/Salida", "No existen Tipos de Entrada/Salida")
End Sub

Sub MuestraEntradasSalidas()
On Error Resume Next
    'limpia controles
    TxtFolio.Text = "": TxtFolioT.Text = "": TxtObs.Text = ""
    TxtIdProdES.Text = "": TxtDescES.Text = "": TxtCantidadES.Text = "": LstEntradasProds.ListItems.Clear
        
    StrCmd = "execute sel_Movimientos " & IdCedis & ", '" & FormatDate(Fecha) & "'"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDEntradas = GetDataLVL(Rs, LstEntradas, 1, 5, "0|0|0|0|0|0")
End Sub

Sub MuestraDetalleEntradasSalidas(IdMov As Long, Rep As Boolean)
On Error Resume Next
    StrCmd = "execute sel_MovimientosDetalle " & IdCedis & ", '" & IdMov & "'"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rep Then LstDEntradasProds = GetDataLVL(Rs, LstEntradasProds, 2, 4, "0|0|9")
    TxtIdProdES.Locked = IIf(LstEntradas.SelectedItem.SubItems(1) = "Pendiente", False, True)
    TxtCantidadES.Locked = IIf(LstEntradas.SelectedItem.SubItems(1) = "Pendiente", False, True)
    TxtDescES.Locked = IIf(LstEntradas.SelectedItem.SubItems(1) = "Pendiente", False, True)
End Sub

Sub CargaInventarioInicialFisico(Rep As Boolean, Opc As Integer)
On Error Resume Next
    Dim Ap As Boolean, Pend As Boolean
    Ap = False: Pend = False
    
    If Opc = 1 Then
        StrCmd = "execute sel_InvFisico " & IdCedis & ", '" & FormatDate(Fecha) & "'"
    Else
        StrCmd = "execute sel_InvInicial " & IdCedis & ", " & Agno & ", " & Mes
    End If
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    If Rs.EOF Then
        If Opc = 1 Then
            LblStatus.Caption = "No existe un Inventario Físico para el " & Format(Fecha, "dddd dd ""de"" MMMM ""de"" yyyy")
            DocumentoAplicado = False
        Else
            LblStatus.Caption = "No existe un Inventario Inicial para el mes de " & Format(DTPFecha.Value, "MMMM") & " del año " & Agno
            DocumentoAplicado = False
        End If
    Else
        If Opc = 1 Then
            StrCmd = "execute sel_InvFisicoStatus " & IdCedis & ", '" & FormatDate(Fecha) & "'"
        Else
            StrCmd = "execute sel_InvInicialStatus " & IdCedis & ", " & Agno & ", " & Mes
        End If
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        While Not RsC.EOF
            Select Case RsC.Fields(3)
                Case "P": Pend = True
                Case "A": Ap = True
            End Select
            RsC.MoveNext
        Wend
        DocumentoAplicado = False
        If Pend And Not Ap Then LblStatus.Caption = "El Inventario " & IIf(Opc = 1, "Físico", "Inicial") & " NO está Aplicado."
        If Not Pend And Ap Then
            LblStatus.Caption = "El Inventario " & IIf(Opc = 1, "Físico", "Inicial") & " está Aplicado."
            DocumentoAplicado = True
        End If
        If Pend And Ap Then LblStatus.Caption = "El Inventario " & IIf(Opc = 1, "Físico", "Inicial") & " tiene Productos pendientes de Aplicar."
    End If
    
    If Opc = 1 Then
        If Not Rep Then LstDInvFisico = GetDataLVL(Rs, LstInvFisico, 2, 5, "0|0|9|0")
    Else
        If Not Rep Then LstDInvInicial = GetDataLVL(Rs, LstInvInicial, 1, 6, "0|1|1|0|9|0")
    End If
    
    LblEdicion.Caption = IIf(DocumentoAplicado, "Consultar", "Actualizar")

End Sub

Private Sub TxtIdProdES_Change()
On Error Resume Next
    TxtDescES.Text = "": TxtCantidadES.Text = 0
End Sub

Private Sub TxtIdProdES_GotFocus()
On Error Resume Next
    SelText TxtIdProdES
End Sub

Public Sub TxtIdProdES_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If Trim(TxtIdProdES.Text) = "0" Then
'        Forma = 1: AL_ProductosBusqueda.Show
    End If
    If KeyAscii = "13" Then
        TxtIdProdES_Validate False
        TxtCantidadES.SetFocus
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtIdProdES_Validate(Cancel As Boolean)
On Error Resume Next
    Val_TxtId TxtIdProdES, TxtDescES, TxtCantidadES, 1
End Sub

Sub ActEntradasSalidas()
On Error GoTo Err_ActES:

Dim Existencias, TipoMov

If Dec Then
    TxtCantidadES.Text = itFlotante(TxtCantidadES.Text)
    If Trim(TxtCantidadES.Text) = "0" Then Exit Sub
End If

MousePointer = 11

    Existencias = 0
    
    StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(DTPFecha.Value) & "', 0, " & Trim(TxtIdProdES.Text) & ", 9"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then Existencias = Rs.Fields(3)
    
    TipoMov = ""
    StrCmd = "execute sel_TipoMovimiento2 " & IdCedis & ", " & CLng(LstEntradas.SelectedItem) & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then TipoMov = Rs.Fields(1)
    
    If TipoMov = "S" And Existencias < CDbl(Trim(TxtCantidadES.Text)) Then
        MousePointer = 0
        MsgBox "¡ La Cantidad debe ser menor a las Existencias del producto. Existencias = " & Existencias & " !", vbInformation + vbOKOnly, App.Title
        TxtCantidadES.Text = Existencias
        Exit Sub
    End If
        
    StrCmd = "execute up_MovimientosDetalle " & IdCedis & ", " & LstEntradas.SelectedItem & ", " & Trim(TxtIdProdES.Text) & ", " & Trim(TxtCantidadES.Text)
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    MuestraDetalleEntradasSalidas LstEntradas.SelectedItem, False

No_Err_ActES:
    MousePointer = 0
    Exit Sub
    
Err_ActES:
    MousePointer = 0
    MsgBox "¡ Error al Actualizar el Movimiento de Almacén !. Error: " & Err.Description, vbCritical + vbOKOnly, App.Title
    GoTo No_Err_ActES:

End Sub

Private Sub TxtIdProdF_Change()
On Error Resume Next
    TxtDescF.Text = "": TxtCantidadF.Text = 0
End Sub

Private Sub TxtIdProdF_GotFocus()
On Error Resume Next
    SelText TxtIdProdF
End Sub

Public Sub TxtIdProdF_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If Trim(TxtIdProdF.Text) = "0" Then
'        Forma = 2: AL_ProductosBusqueda.Show
    End If
    If KeyAscii = "13" Then
        TxtIdProdF_Validate False
        TxtCantidadF.SetFocus
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtIdProdF_Validate(Cancel As Boolean)
On Error Resume Next
    Val_TxtId TxtIdProdF, TxtDescF, TxtCantidadF, 2
End Sub

Private Sub TxtObs_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub
