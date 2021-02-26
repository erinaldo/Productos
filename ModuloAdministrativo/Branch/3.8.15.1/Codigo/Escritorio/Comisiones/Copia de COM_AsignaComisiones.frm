VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form COM_AsignaComisiones 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Asignación de Comisiones"
   ClientHeight    =   9795
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
   ScaleHeight     =   9795
   ScaleWidth      =   12660
   ShowInTaskbar   =   0   'False
   Begin TabDlg.SSTab SSTab 
      Height          =   9585
      Left            =   90
      TabIndex        =   20
      Top             =   90
      Width           =   12495
      _ExtentX        =   22040
      _ExtentY        =   16907
      _Version        =   393216
      Tabs            =   1
      TabsPerRow      =   1
      TabHeight       =   520
      BackColor       =   16777215
      TabCaption(0)   =   "Comisiones"
      TabPicture(0)   =   "COM_AsignaComisiones.frx":0000
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "LblOpt(1)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "FrmOpt(0)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).ControlCount=   2
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
         Height          =   9270
         Index           =   0
         Left            =   0
         TabIndex        =   22
         Top             =   330
         Width           =   12495
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
            Left            =   5640
            Style           =   2  'Dropdown List
            TabIndex        =   1
            Top             =   360
            Width           =   2205
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
            Left            =   840
            Style           =   2  'Dropdown List
            TabIndex        =   0
            Top             =   360
            Width           =   3285
         End
         Begin VB.Frame FrmCategoria 
            BackColor       =   &H00FFFFFF&
            Height          =   2265
            Left            =   10380
            TabIndex        =   36
            Top             =   2880
            Width           =   2025
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
               Left            =   150
               Picture         =   "COM_AsignaComisiones.frx":001C
               Style           =   1  'Graphical
               TabIndex        =   9
               Top             =   960
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
               Index           =   4
               Left            =   150
               Picture         =   "COM_AsignaComisiones.frx":09B2
               Style           =   1  'Graphical
               TabIndex        =   10
               Top             =   1590
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
               MaxLength       =   5
               TabIndex        =   8
               Top             =   510
               Width           =   1665
            End
            Begin VB.Label LblTitulos 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Categoría"
               Height          =   240
               Index           =   7
               Left            =   180
               TabIndex        =   37
               Top             =   210
               Width           =   825
            End
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
            Left            =   10530
            Style           =   2  'Dropdown List
            TabIndex        =   4
            Top             =   600
            Width           =   1725
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
            Index           =   8
            Left            =   10590
            Picture         =   "COM_AsignaComisiones.frx":10ED
            Style           =   1  'Graphical
            TabIndex        =   19
            Top             =   8040
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
            Index           =   7
            Left            =   10560
            Picture         =   "COM_AsignaComisiones.frx":17FD
            Style           =   1  'Graphical
            TabIndex        =   18
            Top             =   7380
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
            Index           =   6
            Left            =   10560
            Picture         =   "COM_AsignaComisiones.frx":1F38
            Style           =   1  'Graphical
            TabIndex        =   17
            Top             =   6720
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
            Index           =   5
            Left            =   10560
            Picture         =   "COM_AsignaComisiones.frx":28CE
            Style           =   1  'Graphical
            TabIndex        =   16
            Top             =   6060
            Width           =   1695
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
            Index           =   3
            Left            =   8610
            MaxLength       =   8
            TabIndex        =   15
            Top             =   8070
            Width           =   1695
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
            Index           =   2
            Left            =   8610
            MaxLength       =   8
            TabIndex        =   14
            Top             =   7410
            Width           =   1695
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
            Index           =   1
            Left            =   8610
            MaxLength       =   8
            TabIndex        =   13
            Top             =   6750
            Width           =   1695
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
            Index           =   0
            Left            =   8610
            MaxLength       =   8
            TabIndex        =   12
            Top             =   6090
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
            Index           =   2
            Left            =   10530
            Picture         =   "COM_AsignaComisiones.frx":2F5C
            Style           =   1  'Graphical
            TabIndex        =   7
            Top             =   2340
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
            Index           =   0
            Left            =   10530
            Picture         =   "COM_AsignaComisiones.frx":3739
            Style           =   1  'Graphical
            TabIndex        =   5
            Top             =   1110
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
            Index           =   1
            Left            =   10530
            Picture         =   "COM_AsignaComisiones.frx":3E3C
            Style           =   1  'Graphical
            TabIndex        =   6
            Top             =   1710
            Width           =   1695
         End
         Begin VB.CheckBox ChkSeleccionar 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Mostrar todos las Familias y Tipos de Ruta"
            Height          =   240
            Left            =   180
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   3
            Top             =   5250
            Width           =   4845
         End
         Begin MSComctlLib.ListView LstVDatos 
            Height          =   4095
            Index           =   0
            Left            =   180
            TabIndex        =   2
            Top             =   1080
            Width           =   10125
            _ExtentX        =   17859
            _ExtentY        =   7223
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
            Height          =   2625
            Index           =   1
            Left            =   2160
            TabIndex        =   11
            Top             =   6090
            Width           =   6315
            _ExtentX        =   11139
            _ExtentY        =   4630
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
            Caption         =   "Tipo de Ruta"
            Height          =   240
            Index           =   9
            Left            =   4440
            TabIndex        =   39
            Top             =   360
            Width           =   1095
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Cedis"
            Height          =   240
            Index           =   8
            Left            =   240
            TabIndex        =   38
            Top             =   360
            Width           =   495
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Categorías"
            Height          =   240
            Index           =   6
            Left            =   10560
            TabIndex        =   35
            Top             =   330
            Width           =   930
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Factor Ayudante"
            Height          =   240
            Index           =   5
            Left            =   8610
            TabIndex        =   34
            Top             =   7830
            Width           =   1440
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Factor Vendedor"
            Height          =   240
            Index           =   4
            Left            =   8610
            TabIndex        =   33
            Top             =   7170
            Width           =   1440
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "a"
            Height          =   240
            Index           =   3
            Left            =   8610
            TabIndex        =   32
            Top             =   6510
            Width           =   105
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "De"
            Height          =   240
            Index           =   2
            Left            =   8610
            TabIndex        =   31
            Top             =   5850
            Width           =   240
         End
         Begin VB.Label LblCategoria 
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Categorías Asignadas a las Familias de Productos y Tipos de Rutas"
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
            Height          =   450
            Index           =   3
            Left            =   150
            TabIndex        =   30
            Top             =   7950
            Width           =   1905
         End
         Begin VB.Label LblCategoria 
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Categorías Asignadas a las Familias de Productos y Tipos de Rutas"
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
            Height          =   450
            Index           =   2
            Left            =   150
            TabIndex        =   29
            Top             =   7320
            Width           =   1905
         End
         Begin VB.Label LblCategoria 
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Categorías Asignadas a las Familias de Productos y Tipos de Rutas"
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
            Height          =   450
            Index           =   1
            Left            =   150
            TabIndex        =   28
            Top             =   6690
            Width           =   1905
         End
         Begin VB.Label LblCategoria 
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Categorías Asignadas a las Familias de Productos y Tipos de Rutas"
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
            Height          =   450
            Index           =   0
            Left            =   150
            TabIndex        =   27
            Top             =   6060
            Width           =   1905
         End
         Begin VB.Label LblNumeroRangos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Categorías Asignadas a las Familias de Productos y Tipos de Rutas"
            Height          =   240
            Left            =   2160
            TabIndex        =   26
            Top             =   8730
            Width           =   5925
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Categorías Asignadas a las Familias de Productos y Tipos de Rutas"
            Height          =   240
            Index           =   1
            Left            =   2160
            TabIndex        =   25
            Top             =   5790
            Width           =   5925
         End
         Begin VB.Label LblTitulos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            BackStyle       =   0  'Transparent
            Caption         =   "Categorías Asignadas a las Familias de Productos y Tipos de Rutas"
            Height          =   240
            Index           =   0
            Left            =   240
            TabIndex        =   24
            Top             =   780
            Width           =   5925
         End
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Comisiones"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   1
         Left            =   0
         TabIndex        =   23
         Top             =   0
         Width           =   12495
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
Dim ListaDeCategorias As Variant
Dim ListaDeCategoriasAsignadas As Variant
Dim ListaDeRangos As Variant
Dim ListaDeCedis As Variant
Dim ListaDeTipoRuta As Variant

Dim FechaInicial As String
Dim FechaFinal As String

Const ctColorBloqueado = &HE0E0E0
Const ctColorDesbloqueado = &HFFFFFF

Const ctCategorias = "CATEGORIAS"
    Const ctConsultaCategoria = "ConsultaCategoria"
    Const ctAgregaCategoria = "AgregaCategoria"
    Const ctEditaCategoria = "EditaCategoria"
    Const ctCancelaCategoria = "CancelaCategoria"
    Const ctAsignaCategoria = "AsignaCategoria"
    
Const ctCategoriasAsignadas = "CATEGORIASASIGNADAS"
    
Const ctRangos = "RANGOS"
    Const ctConsultaRango = "ConsultaRango"
    Const ctAgregaRango = "AgregaRango"
    Const ctEditaRango = "EditaRango"
    Const ctCancelaRango = "CancelaRango"

Dim AccionCategoria As String
Dim AccionRango As String
Dim OpcionTrabajo As String

Dim IdTipoRuta
Dim IdCategoria, IdCategoriaCambio
Dim IdFamilia
Dim IdCalculoBase

Dim DescTipoRuta
Dim DescFamilia
Dim DescCategoria
Dim DescCalculoBase

Dim RangoDe, RangoDeCambio
Dim RangoA
Dim FactorVendedor
Dim FactorAyudante
            
Sub PreparaDatos(TipoLista As String)

    On Error GoTo ErrConexion2
    
    If Not Cnn.State Then OpenConn Server, Db, "AdminRoute", "Route2103"
    If Rs.State Then Rs.Close
    
    Select Case TipoLista
    
        Case ctCategorias
            StrCmd = "sel_AsignaComisiones 10,0,0,0,''"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            ListaDeCategorias = GetDataCBL(Rs, CmbDatos(0), "Seleccione Categoría", "No se Encontraron Categorías")
            
            StrCmd = "sel_Cedis "
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            ListaDeCedis = GetDataCBL(Rs, CmbDatos(1), "Seleccione un Cedis", "No se Encontraron Cedis")
            CmbDatos(1).ListIndex = SearchInList(ListaDeCedis, IdCedis, 0)
        
            StrCmd = "sel_TipoRuta "
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            ListaDeTipoRuta = GetDataCBL(Rs, CmbDatos(2), "Seleccione el Tipo de Ruta", "No se Encontraron Tipos de Ruta")
        
        Case ctCategoriasAsignadas
            
            StrCmd = "sel_AsignaComisiones " & IIf(ChkSeleccionar.Value = 1, 1, 2) & ", " & ListaDeCedis(0, CmbDatos(1).ListIndex - 1) & ",0,0,''"
            Rs.Open StrCmd, Cnn
            ListaDeCategoriasAsignadas = GetDataLVLFMT(Rs, LstVDatos(0), 5, 8, "")
        
            On Error Resume Next
            LstVDatos_ItemClick 0, LstVDatos(0).SelectedItem
        
        Case ctRangos
        
            StrCmd = "sel_AsignaComisiones 3, " & IdCedis & "," & IdTipoRuta & "," & IdFamilia & ",'" & IdCategoria & "'"
            Rs.Open StrCmd, Cnn
            ListaDeRangos = GetDataLVLFMT(Rs, LstVDatos(1), 7, 10, "")
    
            If Not IsEmpty(ListaDeRangos) Then
                LblNumeroRangos.Caption = "Se encontraron " & UBound(ListaDeRangos, 2) + 1 & " rangos en la categoría seleccionada."
            Else
                LblNumeroRangos.Caption = "No se encontraron rangos en la categoría Seleccionada."
            End If
    
            On Error Resume Next
            LstVDatos_ItemClick 1, LstVDatos(1).SelectedItem
    
    End Select
    
    Exit Sub
ErrConexion2:
    MsgBox "Error al Preparar los Datos de Inicio del Módulo. " & Chr(13) & Chr(10) & Err.Description, vbExclamation, "Error del Módulo...."
    
    MousePointer = 0
    Exit Sub
End Sub

Sub HabilitaObjetos(Opcion As String, Accion As String)
    
    On Error Resume Next
    
    'Bloquea Todos los objetos de la seccion de Socio

    'LstVDatos(1).Enabled = False
    For i = 0 To 1: LstVDatos(i).Enabled = False: Next
    For i = 0 To 4: TxtDatos(i).Locked = True: Next
    For i = 0 To 4: TxtDatos(i).BackColor = ctColorBloqueado: Next
    For i = 0 To 8: CmdAccion(i).Enabled = False: Next
    For i = 0 To 0: CmbDatos(i).Locked = True: Next
    For i = 0 To 0: CmbDatos(i).BackColor = ctColorBloqueado: Next
    ChkSeleccionar.Enabled = False
    
    Select Case Opcion
        
        Case ctCategorias
    
            Select Case Accion
                Case ctConsultaCategoria
                    For i = 0 To 1: LstVDatos(i).Enabled = True: Next
                    
                    'Desbloquea botones de Asignar, Quitar o Agregar categoria
                    CmdAccion(0).Enabled = True
                    CmdAccion(1).Enabled = True
                    CmdAccion(2).Enabled = True
                    
                    'Desbloquea botones de Agregar y Eliminar rango
                    CmdAccion(5).Enabled = True
                    CmdAccion(8).Enabled = True

                    For i = 0 To 0: CmbDatos(i).Locked = False: Next
                    For i = 0 To 0: CmbDatos(i).BackColor = ctColorDesbloqueado: Next
                    
                    ChkSeleccionar.Enabled = True
                    
                Case ctAgregaCategoria, ctEditaCategoria
                    
                    'Desbloquea botones de Guardar y cancelar Categoria
                    CmdAccion(3).Enabled = True
                    CmdAccion(4).Enabled = True

                    For i = 4 To 4: TxtDatos(i).Locked = False: Next
                    For i = 4 To 4: TxtDatos(i).BackColor = ctColorDesbloqueado: Next
                    
                    ChkSeleccionar.Enabled = True
                    
                Case ctAsignaCategoria
            
            End Select
            
        Case ctRangos
                    
            Select Case Accion

                
                Case ctConsultaRango
                    'Desbloquea la lista de Socio
                    LstVDatos(1).Enabled = True
                                       
                    'Desbloquea botones de Agregar y Eliminar Rango
                    CmdAccion(5).Enabled = True
                    CmdAccion(8).Enabled = True
                    
                Case ctAgregaRango, ctEditaRango
                    
                    'Desbloquea botones de Guardar y cancelar Rango
                    CmdAccion(6).Enabled = True
                    CmdAccion(7).Enabled = True
                    
                    'Desbloquea Objetos para captura de Rango
                    For i = 0 To 3: TxtDatos(i).Locked = False: Next
                    For i = 0 To 3: TxtDatos(i).BackColor = ctColorDesbloqueado: Next
                    
            End Select
                
    End Select
        
End Sub

Private Sub btnNuevo_Click()



End Sub

Private Sub ChkSeleccionar_Click()

    Select Case ChkSeleccionar.Value
    
        Case 0, 1     'caso de no seleccionar o seleccionar todo
    
            LblNumeroRangos.Caption = ""
            LblCategoria(0).Caption = ""
            LblCategoria(1).Caption = ""
            LblCategoria(2).Caption = ""
            LblCategoria(3).Caption = ""
            
            LstVDatos(1).ColumnHeaders.Clear
            LstVDatos(1).ListItems.Clear
            PreparaDatos ctCategoriasAsignadas
            
    End Select

End Sub


Private Sub CmbDatos_Click(Index As Integer)

    Select Case Index
        Case 0
            On Error Resume Next
            IdCategoriaCambio = ListaDeCategorias(0, CmbDatos(0).ListIndex - 1)
    End Select
    
End Sub

Private Sub CmbDatos_Validate(Index As Integer, Cancel As Boolean)
On Error Resume Next
    PreparaDatos ctCategoriasAsignadas
End Sub

Private Sub CmdAccion_Click(Index As Integer)

    Select Case Index
    
        Case 0          'asignar categoria
            
            If IsEmpty(ListaDeCategoriasAsignadas) Then Exit Sub
            
            If CmbDatos(0).ListIndex <= 0 Then
                MsgBox "Seleccione la categoría a asignar.", vbOKOnly, "Asignación de Categorías"
                CmbDatos(0).SetFocus
                Exit Sub
            End If
            
            'cuestionar sobre la asignacion de la categoria
            If IdCategoria <> "SA" Then
                If IdCategoria <> IdCategoriaCambio Then
                    If MsgBox("Se va a cambiar la categoría para la Familia y Tipo de Ruta Seleccionada, " & _
                    "¿Desea Continuar?", vbYesNo + vbDefaultButton2, "Asignación de Categorías") = vbNo Then
                        Exit Sub
                    End If
                End If
            Else
                    If MsgBox("Se va a asignar la categoría " & IdCategoriaCambio & " para la Familia y Tipo de Ruta Seleccionada, " & _
                    "¿Desea Continuar?", vbYesNo, "Asignación de Categorías") = vbNo Then
                        Exit Sub
                    End If
            End If
            
            'Asignar categoría a la familia, cedis y tipo de ruta seleccionada
            StrCmd = "up_CategoriasComisiones " & IIf(IdCategoria = "SA", 10, 11) & "," & _
                    IdCedis & "," & IdTipoRuta & "," & IdFamilia & ",'" & IdCategoria & "','" & _
                    IdCategoriaCambio & "','',0,0,0,0,0"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
                
            'actualizar la lista de Categorias asignadas
            ChkSeleccionar_Click
        
        Case 1          'quitar categoría
        
            If IsEmpty(ListaDeCategoriasAsignadas) Then Exit Sub
        
                'Quitar asignacion de categoria
            If MsgBox("Se va a Quitar la categoría " & IdCategoria & " para la Familia y Tipo de Ruta Seleccionada, " & _
            "¿Desea Continuar?", vbYesNo + vbDefaultButton2, "Asignación de Categorías") = vbNo Then
                Exit Sub
            End If
            
            StrCmd = "up_CategoriasComisiones 12," & _
                    IdCedis & "," & IdTipoRuta & "," & IdFamilia & ",'" & IdCategoria & "','','',0,0,0,0,0"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn

            'regresa a estado de consulta de rango
            OpcionTrabajo = ctCategorias
            AccionCategoria = ctAgregaCategoria
            HabilitaObjetos ctCategorias, ctConsultaCategoria
            
            'actualizar la lista de Categorias asignadas
            ChkSeleccionar_Click
                
        Case 2          'agrega categoria
        
            'Inicia estado de Insercion de categoria
            OpcionTrabajo = ctCategorias
            AccionCategoria = ctAgregaCategoria
            
            For i = 4 To 4: TxtDatos(i).Text = "": Next
                            
            HabilitaObjetos ctCategorias, ctAgregaCategoria
            
            TxtDatos(4).SetFocus
        
        Case 3          'Guarda cambios en insercion o edicion de categoria
        
            'Guarda Datos de la categoria
            If MsgBox("Se va a agregar la categoría " & TxtDatos(4).Text & ", " & _
            "¿Desea Continuar?", vbYesNo + vbDefaultButton2, "Alta de Categorías") = vbNo Then
                Exit Sub
            End If
            
            On Error Resume Next
            StrCmd = "up_CategoriasComisiones 1,0,0,0,'" & TxtDatos(4).Text & "','','" & _
                    "Categoría: " & Trim(TxtDatos(4).Text) & "',0,0,0,0,0"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn

            'Actualizar la lista de Categorias
            PreparaDatos ctCategorias
            
            'regresa a estado de consulta de categoria
            OpcionTrabajo = ctCategorias
            AccionCategoria = ctConsultaCategoria
            For i = 4 To 4: TxtDatos(i).Text = "": Next
            HabilitaObjetos ctCategorias, ctConsultaCategoria
                            
        Case 4          'cancela operación de insercion o edicion de categoria
    
            'regresa a estado de consulta de rango
            OpcionTrabajo = ctCategorias
            AccionCategoria = ctConsultaCategoria
            For i = 4 To 4: TxtDatos(i).Text = "": Next
            HabilitaObjetos ctCategorias, ctConsultaCategoria
        
        Case 5          'agrega rango
        
            If IsEmpty(ListaDeCategoriasAsignadas) Then Exit Sub
        
            'Inicia estado de Insercion de rango
            OpcionTrabajo = ctRangos
            AccionRango = ctAgregaRango
            
            For i = 0 To 3: TxtDatos(i).Text = "": Next
                            
            HabilitaObjetos ctRangos, ctAgregaRango
            
            TxtDatos(0).SetFocus
        
        Case 6          'Guarda cambios en insercion o edicion de rango
                
            If Trim(TxtDatos(0).Text) = "" Or Trim(TxtDatos(1).Text) = "" Or _
                Trim(TxtDatos(2).Text) = "" Or Trim(TxtDatos(3).Text) = "" Then
                MsgBox "Debe ingresar todos los valores para un rango.", vbOKOnly, "Rangos para Categorías"
                TxtDatos(0).SetFocus
                Exit Sub
            End If
            
                'Guarda Datos de Rango
            If MsgBox("Se van a guardar los datos del rango, " & _
            "¿Desea Continuar?", vbYesNo, "Rangos para Categorías") = vbNo Then
                Exit Sub
            End If

            On Error Resume Next
            StrCmd = "up_CategoriasComisiones " & IIf(AccionRango = ctAgregaRango, 20, 21) & ",0," & _
                    IdTipoRuta & "," & IdFamilia & ",'" & IdCategoria & "','',''," & RangoDe & "," & TxtDatos(0).Text & "," & _
                    TxtDatos(1).Text & "," & TxtDatos(2).Text & "," & TxtDatos(3).Text
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
                
            'regresa a estado de consulta de rago
            OpcionTrabajo = ctRangos
            AccionRango = ctConsultaRango
            For i = 0 To 3: TxtDatos(i).Text = "": Next
            HabilitaObjetos ctCategorias, ctConsultaCategoria
            
            'Actualizar la lista de Rangos
            'Valor predeterminado
            On Error Resume Next
            LstVDatos_ItemClick 0, LstVDatos(0).SelectedItem

                
        Case 7          'cancela operación de insercion o edicion de rango
        
            'regresa a estado de consulta de rango
            OpcionTrabajo = ctRangos
            AccionRango = ctConsultaRango
            For i = 0 To 3: TxtDatos(i).Text = "": Next
            HabilitaObjetos ctCategorias, ctConsultaCategoria
    
            'Valor predeterminado
            On Error Resume Next
            LstVDatos_ItemClick 1, LstVDatos(1).SelectedItem
        
        Case 8          'Elimina rango
                
            If IsEmpty(ListaDeCategoriasAsignadas) Then Exit Sub
            If IsEmpty(ListaDeRangos) Then Exit Sub
                
            'Elimina datos del rango
            
            If MsgBox("Se va a eliminar el rango seleccionado, " & _
            "¿Desea Continuar?", vbYesNo + vbDefaultButton2, "Rangos para Categorías") = vbNo Then
                Exit Sub
            End If
        
            StrCmd = "up_CategoriasComisiones 22,0," & _
                    IdTipoRuta & "," & IdFamilia & ",'" & IdCategoria & "','',''," & RangoDe & ",0,0,0,0"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
    
            'regresa a estado de consulta de rango
            OpcionTrabajo = ctRangos
            AccionRango = ctConsultaRango
            For i = 0 To 3: TxtDatos(i).Text = "": Next
            HabilitaObjetos ctCategorias, ctConsultaCategoria
            
            'Actualizar la lista de Rangos
            
            'Valor predeterminado
            On Error Resume Next
            LstVDatos_ItemClick 0, LstVDatos(0).SelectedItem
                
    End Select

End Sub

Private Sub Form_Activate()
    
    If Not Cnn.State Then OpenConn Server, Db, "AdminRoute", "Route2103"
    Screen.MousePointer = vbDefault
    
End Sub

Private Sub Form_Load()
    
   Dim Fecha
    
    On Error GoTo ErrorHandler
    
    LblNumeroRangos.Caption = ""
    LblCategoria(0).Caption = ""
    LblCategoria(1).Caption = ""
    LblCategoria(2).Caption = ""
    LblCategoria(3).Caption = ""
    
    LstVDatos(0).ColumnHeaders.Clear
    LstVDatos(0).ListItems.Clear
    
    LstVDatos(1).ColumnHeaders.Clear
    LstVDatos(1).ListItems.Clear
    
    PreparaDatos ctCategorias
    
    ChkSeleccionar_Click
    
    HabilitaObjetos ctCategorias, ctConsultaCategoria
    
    Exit Sub
    
ErrorHandler:

    MsgBox "Error al abrir el módulo de Comisiones", vbCritical, "Error...."

    Exit Sub
   
End Sub

Private Sub LstVDatos_DblClick(Index As Integer)

    LstVDatos_KeyPress Index, &HD

End Sub

Private Sub LstVDatos_ItemClick(Index As Integer, ByVal Item As MSComctlLib.ListItem)

Dim ItemSeleccionado As Integer

    Select Case Index
        Case 0
            ItemSeleccionado = Item.Index
            
            IdTipoRuta = ListaDeCategoriasAsignadas(1, ItemSeleccionado - 1)
            CmbDatos(2).ListIndex = SearchInList(ListaDeTipoRuta, IdTipoRuta, 0)
            IdFamilia = ListaDeCategoriasAsignadas(2, ItemSeleccionado - 1)
            IdCategoria = ListaDeCategoriasAsignadas(3, ItemSeleccionado - 1)
            IdCalculoBase = ListaDeCategoriasAsignadas(4, ItemSeleccionado - 1)
            
            DescTipoRuta = ListaDeCategoriasAsignadas(5, ItemSeleccionado - 1)
            DescFamilia = ListaDeCategoriasAsignadas(6, ItemSeleccionado - 1)
            DescCategoria = ListaDeCategoriasAsignadas(7, ItemSeleccionado - 1)
            DescCalculoBase = ListaDeCategoriasAsignadas(8, ItemSeleccionado - 1)
            
            LblCategoria(0).Caption = DescTipoRuta
            LblCategoria(1).Caption = "Familia: " & DescFamilia
            LblCategoria(2).Caption = DescCategoria
            LblCategoria(3).Caption = "Cálculo en base a: " & DescCalculoBase
            
            'regresa a estado de consulta de rango
            For i = 0 To 4: TxtDatos(i).Text = "": Next
            
            If IdCategoria = "SA" Then
                CmbDatos(0).ListIndex = 0
                
                LstVDatos(1).Enabled = False
                CmdAccion(1).Enabled = False
                CmdAccion(5).Enabled = False
                CmdAccion(8).Enabled = False

            Else
                SearchInCombo CmbDatos(0), CStr(DescCategoria), Len(DescCategoria)
                
                LstVDatos(1).Enabled = False
                CmdAccion(1).Enabled = True
                CmdAccion(5).Enabled = True
                CmdAccion(8).Enabled = True
                
            End If
                        
            PreparaDatos ctRangos
                        
        Case 1
            ItemSeleccionado = Item.Index
            
            '0 IdCedis, 1 IdTipoRuta, 2 IdFamilia, 3 IdCategoria, 4 [Tipo de Ruta],
            '5 Familia, 6 Categoría, 7 De, 8 A, 9 [Fac.Vendedor], 10 [Fac.Ayudante]

            RangoDe = ListaDeRangos(7, ItemSeleccionado - 1)
            RangoA = ListaDeRangos(8, ItemSeleccionado - 1)
            FactorVendedor = ListaDeRangos(9, ItemSeleccionado - 1)
            FactorAyudante = ListaDeRangos(10, ItemSeleccionado - 1)
                        
            TxtDatos(0).Text = RangoDe
            TxtDatos(1).Text = RangoA
            TxtDatos(2).Text = FactorVendedor
            TxtDatos(3).Text = FactorAyudante
            
    End Select


End Sub

Private Sub LstVDatos_KeyPress(Index As Integer, KeyAscii As Integer)

    If KeyAscii = &HD Then
        Select Case Index
            
            Case 0
            
                On Error Resume Next
                LstVDatos(1).SetFocus
                
            Case 1
            
                If IsEmpty(ListaDeRangos) Then Exit Sub
                'Inicia estado de edicion de
                OpcionTrabajo = ctRangos
                AccionRango = ctEditaRango
                'LimpiaObjetos OpcionTrabajo, AccionSocio
                HabilitaObjetos ctRangos, ctEditaRango
            
        End Select
    
    End If

End Sub

Private Sub TxtDatos_GotFocus(Index As Integer)
    
    TxtDatos(Index).SelStart = 0: TxtDatos(Index).SelLength = Len(TxtDatos(Index).Text)

End Sub

Private Sub TxtDatos_KeyPress(Index As Integer, KeyAscii As Integer)

    If KeyAscii = 13 Then
        SendKeys "{tab}"
        KeyAscii = 0
    End If
    
    Select Case Index
    
        Case 0 To 3
            KeyAscii = itDecimal(KeyAscii)
        
        Case 4
            'KeyAscii = itString(KeyAscii)
            
            KeyAscii = Asc(UCase(Chr(KeyAscii)))
            
            Select Case KeyAscii
                Case vbKeySpace, vbKeyBack
               Case 65 To 90, 209
               Case Else
                  'Beep
                  'MsgBox " Solo Mayusculas ", , ""
                  KeyAscii = 0
            End Select

    End Select

End Sub
