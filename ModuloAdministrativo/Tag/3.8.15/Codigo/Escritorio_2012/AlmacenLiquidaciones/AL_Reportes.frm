VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomct2.ocx"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form AL_Reportes 
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
            Left            =   3030
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   14
            Top             =   5100
            Width           =   2715
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
            Left            =   3030
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   15
            Top             =   5460
            Width           =   2715
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
            Left            =   120
            Picture         =   "AL_Reportes.frx":0000
            Style           =   1  'Graphical
            TabIndex        =   16
            Top             =   6210
            Width           =   1815
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
            TabIndex        =   9
            Top             =   5460
            Width           =   2715
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
            Left            =   3030
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   10
            Top             =   3660
            Width           =   2715
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
            Left            =   3030
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   11
            Top             =   4020
            Width           =   2715
         End
         Begin VB.ComboBox CmbCedi 
            Height          =   360
            Left            =   180
            Style           =   2  'Dropdown List
            TabIndex        =   0
            Top             =   540
            Width           =   5625
         End
         Begin VB.ComboBox CmbReporte 
            Height          =   360
            Left            =   150
            Style           =   2  'Dropdown List
            TabIndex        =   3
            Top             =   2760
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
            TabIndex        =   4
            Top             =   3660
            Width           =   2715
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
            TabIndex        =   5
            Top             =   4020
            Width           =   2715
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
            TabIndex        =   6
            Top             =   4380
            Width           =   2715
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
            TabIndex        =   7
            Top             =   4740
            Width           =   2715
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
            Picture         =   "AL_Reportes.frx":0697
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
            Top             =   1380
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
            Format          =   97845251
            CurrentDate     =   38914
         End
         Begin MSComCtl2.DTPicker DTPPeriodo 
            Height          =   345
            Index           =   1
            Left            =   750
            TabIndex        =   2
            Top             =   1890
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
            Format          =   97845251
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
            TabIndex        =   8
            Top             =   5100
            Width           =   2715
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
            Left            =   3030
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   13
            Top             =   4740
            Width           =   2715
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
            Left            =   3030
            MaskColor       =   &H00E0E0E0&
            TabIndex        =   12
            Top             =   4380
            Width           =   2715
         End
         Begin VB.Label LabTitulos 
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "Periodo"
            Height          =   240
            Index           =   1
            Left            =   180
            TabIndex        =   32
            Top             =   1050
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
            Top             =   240
            Width           =   450
         End
         Begin VB.Label Label2 
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "Al"
            Height          =   240
            Left            =   330
            TabIndex        =   28
            Top             =   1950
            Width           =   180
         End
         Begin VB.Label Label5 
            AutoSize        =   -1  'True
            BackStyle       =   0  'Transparent
            Caption         =   "Del"
            Height          =   240
            Left            =   240
            TabIndex        =   27
            Top             =   1440
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
            Top             =   2460
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
            Top             =   3330
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
         Height          =   495
         Left            =   8520
         Picture         =   "AL_Reportes.frx":0F07
         Style           =   1  'Graphical
         TabIndex        =   19
         Top             =   7440
         Width           =   1815
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
         Height          =   495
         Left            =   10440
         Picture         =   "AL_Reportes.frx":1622
         Style           =   1  'Graphical
         TabIndex        =   20
         Top             =   7440
         Width           =   1815
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
         Left            =   240
         TabIndex        =   33
         Top             =   7590
         Width           =   8325
      End
   End
End
Attribute VB_Name = "AL_Reportes"
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

Sub PreparaDatos(TipoLista As String)

    On Error GoTo ErrConexion2
    
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    
    If Rs.State Then Rs.Close
    
    Select Case TipoLista
        
        Case ctCedis
            
            StrCmd = "Gsp_ObtenerCedis 3,'S'"
            Rs.Open StrCmd, Cnn
            ListaDeCedis = GetDataCBL(Rs, CmbCedi, "Seleccione el CEDI", "No se Encontraron Registros de CEDIS")
        
        Case ctReportes
        
            StrCmd = "Gsp_ObtenerReportes 1,0,'S'"
            Rs.Open StrCmd, Cnn
            ListaDeReportes = GetDataCBL(Rs, CmbReporte, "Seleccione el Reporte", "No se Encontraron Registros de Reportes")
        
        Case ctSubReportes
        
            StrCmd = "Gsp_ObtenerReportes 2," & ListaDeReportes(0, CmbReporte.ListIndex - 1) & ",'S'"
            Rs.Open StrCmd, Cnn
            ListaDeSubReportes = GetData(Rs)
        
        Case ctFiltro
            StrCmd = "Gsp_NivelReporte " & IdReporte & "," & TipoReporte & ",'" & IdCedi & "','" & _
                    FormatDate(DTPPeriodo(0).Value) & "','" & FormatDate(DTPPeriodo(1).Value) & _
                    "','', '" & FiltroOrdenamiento & "'"
            Rs.Open StrCmd, Cnn
            
            ListaDeFiltro = GetDataLVLFMT(Rs, LstVDatos(0), CampoInicial, CampoFinal, "")
    
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
On Error Resume Next
    
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
    
    mensaje "OK", ContenidoMensaje
    
    Exit Sub
    
End Sub

Sub ObtenerRegistrosFiltro()

    On Error GoTo Salir

    Screen.MousePointer = vbHourglass

    FechaInicial = DTPPeriodo(0).Value
    FechaFinal = DTPPeriodo(1).Value

    IdReporte = IIf(CmbReporte.ListIndex = 0, 0, ListaDeReportes(0, CmbReporte.ListIndex - 1))

    TipoReporte = OptTipoReporte(SubReporteSeleccionado).Tag
    NivelReporte = OptTipoReporte(SubReporteSeleccionado).Caption
    
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
        GoTo Salir
    End If
    
    If CmbReporte.ListIndex > 0 Then
    
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
    LblTituloReporte(3).Caption = Format(DTPPeriodo(0).Value, "dd "" de"" mmmm "" de "" yyyy")
    LblTituloReporte(4).Caption = Format(DTPPeriodo(1).Value, "dd "" de "" mmmm "" de "" yyyy")

    PreparaDatos ctFiltro
    
Salir:
    
    Screen.MousePointer = vbDefault

End Sub


Sub mensaje(Tipo As String, Texto As String)
On Error Resume Next

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
On Error Resume Next
    For i = 0 To OptTipoReporte.Count - 1
        OptTipoReporte(i).Visible = False
    Next
End Sub

Private Sub ChkSeleccionar_Click()
On Error Resume Next

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
On Error Resume Next

    MensajeSeleccionFiltro

End Sub

Private Sub CmbReporte_Click()
On Error Resume Next

    OcultaOpciones
    
    ChkSeleccionar.Value = 0

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
        Case 1      'caratula de venta
            TituloReporteXLS = "Carátula de Venta ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Caratula"
            
        Case 2      'Kardex
            TituloReporteXLS = "Kardex de Inventario de Productos ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & "-" & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Kardex"
            
        Case 3      'comisiones
            TituloReporteXLS = "Cálculo de Comisiones por Venta de Productos ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Comisiones"
    
        Case 4      'Carga de productos
            TituloReporteXLS = "Carga de Productos ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Cargas"
    
        Case 5      'Hoja de Liquidacion
            TituloReporteXLS = "Hoja de Liquidación ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " HojaLiquidacion"
            
        Case 6      'Corte de Caja
            TituloReporteXLS = "Corte de Caja ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " CorteCaja"
            
       Case 7      'Corte por producto
            TituloReporteXLS = "Corte por Producto ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " CorteProducto"
            
       Case 8      'Resumen de Precios
            TituloReporteXLS = "Resumen de Precios ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " ResumenPrecios"
            
        Case 9      'Saldo de Tarimas y Rejas
            TituloReporteXLS = "Saldo de Tarimas y Rejas ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " SaldoTarimasRejas"
            
        Case 10      'Factura Global de Contado
            TituloReporteXLS = "Factura Global de Contado ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " FacturaGlobalContado"
            
        Case 11      'Ventas de crédito
            TituloReporteXLS = "Ventas de Crédito ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " VentasCredito"
            
        Case 12      'Listas de precios
            TituloReporteXLS = "Listas de Precios ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " ListasPrecios"
            
        Case 13      'Ventas por Cliente
            TituloReporteXLS = "Ventas por Cliente ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " VentasCliente"
            
        Case 14      'Facturas de Contado
            TituloReporteXLS = "Ventas de Contado ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " FacturasContado"
            
        Case 15      'Movimientos de Almacén
            TituloReporteXLS = "Movimientos de Almacén ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " MovimientosAlmacen"
                        
        Case 16      'Ventas por Cliente
            TituloReporteXLS = "Ventas por Cliente ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " VentasCliente"
                        
        Case 17      'Ventas por Sucursal de Cliente
            TituloReporteXLS = "Ventas por Sucursal de Cliente ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " VentasSucursal"
                        
        Case 18      'Existencia en Inventario Físico
            TituloReporteXLS = "Existencia en Inventario Físico ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " InventarioFisico"
        
        Case 19      'Mermas por Ruta y Tipo
            TituloReporteXLS = "Mermas por Ruta y Tipo de Merma ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Mermas por Ruta y Tipo"
        
        Case 20      'Cambiso Físicos
            TituloReporteXLS = "Cambios Físicos ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Cambios Físicos"
    
        Case 21      'Libro de Ruta
            TituloReporteXLS = "Libro de Ruta ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Libro de Ruta"
    
        Case 22      'Saldos del Vendedor
            TituloReporteXLS = "Saldos del Vendedor ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Saldos del Vendedor"
    
        Case 27      'Efectivo y Documentos
            TituloReporteXLS = "Efectivo y Documentos ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Efectivo y Documentos"
    
        Case 28      'Ventas por Marca
            TituloReporteXLS = "Ventas por Marca ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Ventas por Marca "
    
        Case 29      'Ventas por Producto a Precio Base
            TituloReporteXLS = "Ventas por Producto a Precio Base ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Ventas por Producto a Precio Base"
    
        Case 30      'Ventas Acreditadas
            TituloReporteXLS = "Reporte de Ventas Acreditadas ( " & NivelReporte & " )"
            'CedisXLS = IdCedis & " - " & NomCedis
            PeriodoXLS = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                "  al  " & Format(RepFechaFinal, ctFechaLarga)
            Tipo = " Reporte de Ventas Acreditadas"
    
    End Select
        
    NombreArchivoXLS = "CED" & Format(IdCedi, "00") & Tipo & "(" & DescripcionAgrupacion & ") " & Format(RepFechaInicial, "yymmdd") & _
                        " - " & Format(RepFechaInicial, "yymmdd") & "  " & Format(Time, "HHnn")
        
    If MsgBox("Se va a crear el archivo de nombre """ & NombreArchivoXLS & _
        """ (esta operación podría tardar varios minutos), ¿Desea Continuar?", vbYesNo, "Archivo Excel") = vbNo Then Exit Sub
    
    Screen.MousePointer = vbHourglass
    
    Filtro = ""
        
    If ChkSeleccionar.Value = 2 Then
        For i = 1 To LstVDatos(0).ListItems.Count
            If LstVDatos(0).ListItems(i).Checked Then
                
                'construir el filtro
                 If IdReporte = 6 Then
                    Filtro = Filtro & IIf(Filtro = "", "", ",") & "''" & ListaDeFiltro(3, i - 1) & "''"
                Else
                    Filtro = Filtro & IIf(Filtro = "", "", ",") & "''" & ListaDeFiltro(0, i - 1) & "''"
                End If
                
               
                
'                ConteoRegistrosChecados = ConteoRegistrosChecados + 1
                
            End If
        Next
        If IdReporte = 12 Then
            Filtro = IIf(Filtro <> "", CampoFiltro & " in (" & Filtro & ")", "")
        Else
            Filtro = IIf(Filtro <> "", " AND " & CampoFiltro & " in (" & Filtro & ")", "")
        End If
    Else
        
        If ChkSeleccionar.Value = 1 And IdReporte = 12 Then
            For i = 1 To LstVDatos(0).ListItems.Count
                If LstVDatos(0).ListItems(i).Checked Then
                    
                    'construir el filtro
                    Filtro = Filtro & IIf(Filtro = "", "", ",") & "''" & ListaDeFiltro(0, i - 1) & "''"
                    
'                    ConteoRegistrosChecados = ConteoRegistrosChecados + 1
                    
                End If
            Next
            
            Filtro = IIf(Filtro <> "", CampoFiltro & " in (" & Filtro & ")", "")
        End If
        
''        For i = 1 To LstVDatos(0).ListItems.Count
''            If LstVDatos(0).ListItems(i).Checked Then
''
''                'construir el filtro
''                Filtro = Filtro & IIf(Filtro = "", "", ",") & "''" & ListaDeFiltro(0, i - 1) & "''"
''
''                ConteoRegistrosChecados = ConteoRegistrosChecados + 1
''
''            End If
''        Next
''
''        Filtro = IIf(Filtro <> "", " AND " & CampoFiltro & " in (" & Filtro & ")", "")
    
    End If
    
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    
    If Rs.State Then Rs.Close

    StrCmd = "Gsp_NivelReporte " & IdReporte & "," & EjecutaSQLXLS & ",'" & RepIdCedi & "','" & _
            FormatDate(CDate(RepFechaInicial)) & "','" & FormatDate(CDate(RepFechaFinal)) & "', '" & _
            IIf(ChkSeleccionar.Value = 2 Or (ChkSeleccionar.Value = 1 And IdReporte = 12), Filtro, "") & _
            "', '" & FiltroOrdenamiento & "'"
        
    Rs.Open StrCmd, Cnn
    
    If Not Rs.EOF Then
        
        ImpresionExcel NombreArchivoXLS, TituloReporteXLS, PeriodoXLS, Rs, CampoInicialXLS, CampoFinalXLS, RepIdCedi, RepNombreCedi
        
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
        
    If ChkSeleccionar.Value = 2 Then
        
        For i = 1 To LstVDatos(0).ListItems.Count
            If LstVDatos(0).ListItems(i).Checked Then
                
                'construir el filtro
                If IdReporte = 6 Then
                    Filtro = Filtro & IIf(Filtro = "", "", ",") & "''" & ListaDeFiltro(3, i - 1) & "''"
                Else
                    Filtro = Filtro & IIf(Filtro = "", "", ",") & "''" & ListaDeFiltro(0, i - 1) & "''"
                End If
                
                ConteoRegistrosChecados = ConteoRegistrosChecados + 1
                
            End If
        Next
        If IdReporte = 12 Then
            Filtro = IIf(Filtro <> "", CampoFiltro & " in (" & Filtro & ")", "")
        Else
            Filtro = IIf(Filtro <> "", " AND " & CampoFiltro & " in (" & Filtro & ")", "")
        End If
    Else
        
        If ChkSeleccionar.Value = 1 And IdReporte = 12 Then
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
    
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    
    If IdReporte = 25 Then
        If Rs.State Then Rs.Close
        StrCmd = "exec up_ModeloOrienteES '" & RepIdCedi & "','" & FormatDate(CDate(RepFechaInicial)) & "'"
        Rs.Open StrCmd, Cnn
    End If
    
    If IdReporte = 26 Then
        If Rs.State Then Rs.Close
        StrCmd = "exec up_ModeloOrienteEnvase '" & RepIdCedi & "','" & FormatDate(CDate(RepFechaInicial)) & "'"
        Rs.Open StrCmd, Cnn
    End If
    
    If IdReporte = 3 Then
        If Rs.State Then Rs.Close
        StrCmd = "exec up_ComisionesHistorico '" & RepIdCedi & "','" & FormatDate(CDate(RepFechaInicial)) & "','" & FormatDate(CDate(RepFechaFinal)) & "', '', " & IIf(EjecutaSQL = 10 Or EjecutaSQL = 11, 3, 4)
        Rs.Open StrCmd, Cnn
    End If
    
    If Rs.State Then Rs.Close

    StrCmd = "Gsp_NivelReporte " & IdReporte & "," & EjecutaSQL & ",'" & RepIdCedi & "','" & _
            FormatDate(CDate(RepFechaInicial)) & "','" & FormatDate(CDate(RepFechaFinal)) & "', '" & _
            IIf(ChkSeleccionar.Value = 2 Or (ChkSeleccionar.Value = 1 And IdReporte = 12), Filtro, "") & _
            "', '" & FiltroOrdenamiento & "'"
    
    Rs.Open StrCmd, Cnn
    
    If Not Rs.EOF Then
        Select Case IdReporte
            Case 1      'caratula de venta
                With AL_RptRepCaratula
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                    .LblTitulo.Caption = "Carátula de Venta ( " & NivelReporte & " )"
                    .DescripcionAgrupacion = DescripcionAgrupacion
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)

                    .Printer.Orientation = ddOLandscape: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show
                End With
                
            Case 2      'Kardex
                With AL_RptRepKardex
                    '.TipoReporte = IIf(TipoReporte = 3 Or TipoReporte = 4 Or TipoReporte = 7 _
                                    Or TipoReporte = 8 Or TipoReporte = 15 Or TipoReporte = 16, "PESOS", "")
                    .NivelReporte = TipoReporte
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                    .LblTitulo.Caption = "Kardex de Inventario de Productos ( " & NivelReporte & " )"
                    .DescripcionAgrupacion = DescripcionAgrupacion
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    
                    .Printer.Orientation = ddOLandscape: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show
                End With
                
            Case 3      'comisiones
                With AL_RptRepComisiones
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                    .LblTitulo.Caption = "Comisiones de Vendedores ( " & NivelReporte & " )"
                    '.DescripcionAgrupacion = DescripcionAgrupacion
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)

                    .Printer.Orientation = ddOLandscape: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show
                End With
                
            Case 4      'carga de Productos
                                
                With AL_RptRepCarga
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                                        
                    .LblTitulo.Caption = "Carga de Productos ( " & NivelReporte & " )"
                    .IdCedi = RepIdCedi
                    '.DescripcionAgrupacion = DescripcionAgrupacion
                    '.LblCedis.Caption = IdCedis & " - " & NomCedis

                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show
                End With
                
            Case 5      'Hoja de Liquidación
                                
                With AL_RptRepLiquidacion
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    
                    .LblTitulo.Caption = "Hoja de Liquidación ( " & NivelReporte & " )"
                    .IdCedi = RepIdCedi
                    '.DescripcionAgrupacion = DescripcionAgrupacion
                    '.LblCedis.Caption = IdCedis & " - " & NomCedis

                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show
                End With
                
            Case 6      'Corte de Caja
                With AL_RptRepCorteCaja
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                    .LblTitulo.Caption = "Corte de Caja ( " & NivelReporte & " )"
                    '.DescripcionAgrupacion = DescripcionAgrupacion
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)

                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show
                End With
                
            Case 7      'Corte por Producto
                With AL_RptRepCorteProducto
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                    .LblTitulo.Caption = "Corte por Producto ( " & NivelReporte & " )"
                    '.DescripcionAgrupacion = DescripcionAgrupacion
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)

                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show
                End With
            
            Case 8      'Resumen de Precios
                With AL_RptPreciosResumen
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                    .LblTitulo.Caption = "Resumen de Listas de Precios ( " & NivelReporte & " )"
                    '.DescripcionAgrupacion = DescripcionAgrupacion
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show
                End With
        
            Case 9      'Saldo de Tarimas y Rejas
                With AL_RptRepTarimasAcumulado
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                    .LblTitulo.Caption = "Saldos de Tarimas y Rejas Acumulado ( " & NivelReporte & " )"
                    '.DescripcionAgrupacion = DescripcionAgrupacion
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)

                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show
                End With
        
            Case 10      'Factura Global de Contado
                With AL_RptFacturaGlobal
                    .LblFecha.Caption = RepFechaInicial
                    .LblRFC.Caption = RFCCedis: .LblNombre.Caption = RazonSocialCedis: .LblDireccion.Caption = DireccionFiscalCedis
                    
                    If Not Rs.EOF Then
                        .object.DataSrc.DataSourceName = Cnn
                        .object.DataSrc.Recordset = Rs
                    End If
                    
                    .Printer.Orientation = ddOPortrait
                    .Printer.PaperSize = 1
                    .Show
                End With
                
            Case 11, 14:      'Ventas de crédito y Ventas Contado
                With AL_RptRepVentasCredito
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                    .LblTitulo.Caption = "Ventas de " & IIf(IdReporte = 11, "Crédito", "Contado") & " ( " & NivelReporte & " )"
                    '.DescripcionAgrupacion = DescripcionAgrupacion
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                                        
                    .LblSubtotal.Visible = IIf(OptTipoReporte(0).Value, True, False)
                    .LblIva.Visible = IIf(OptTipoReporte(0).Value, True, False)
                    .LblTotal.Visible = IIf(OptTipoReporte(0).Value, True, False)
                    
                    .FldSubtotal.Visible = IIf(OptTipoReporte(0).Value, True, False)
                    .FldIva.Visible = IIf(OptTipoReporte(0).Value, True, False)
                    .FldTotal.Visible = IIf(OptTipoReporte(0).Value, True, False)
                                        
                    .GpFtProds.Visible = IIf(Not OptTipoReporte(0).Value, True, False)
                    .GpHdProds.Visible = IIf(Not OptTipoReporte(0).Value, True, False)
                    .Detail.Visible = IIf(Not OptTipoReporte(0).Value, True, False)
                    
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show
                End With
        
            Case 12      'Listas de precios
                With AL_RptRepPrecios
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                    .LblTitulo.Caption = "Listas de Precios ( " & NivelReporte & " )"
                    '.DescripcionAgrupacion = DescripcionAgrupacion
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    '.LblDatos.Caption = "Periodo del  " & Format(DTPPeriodo(0).Value, ctFechaLarga) & _
                                        "  al  " & Format(DTPPeriodo(1).Value, ctFechaLarga)
                                        
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show
                End With
                
            Case 15      'Movimientos de Almacen
                With AL_RptRepMovimientosAlmacen
                
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                    .LblTitulo.Caption = "Movimientos de Almacén ( " & NivelReporte & " )"
                    .DescripcionAgrupacion = DescripcionAgrupacion
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    .TipoReporte = TipoReporte

                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show
                
                End With
                
            Case 16      'Ventas por Cliente
                With AL_RptRepVentasCliente
                
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                    .LblTitulo.Caption = "Ventas por Cliente ( " & NivelReporte & " )"
                    .DescripcionAgrupacion = DescripcionAgrupacion
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    .TipoReporte = TipoReporte

                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show
                
                End With
                
            Case 17      'Ventas por Sucursales de Cliente
                With AL_RptRepVentasSucursal
                
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                    .LblTitulo.Caption = "Ventas por Sucursal de Cliente ( " & NivelReporte & " )"
                    .DescripcionAgrupacion = DescripcionAgrupacion
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    .TipoReporte = TipoReporte

                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show
                
                End With
        
            Case 18      'Existencia en Inventario Físico
                With AL_RptRepInventarioFisico
                
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                    .LblTitulo.Caption = "Existencia en Inventario Físico ( " & NivelReporte & " )"
                    .DescripcionAgrupacion = DescripcionAgrupacion
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    .TipoReporte = TipoReporte

                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show
                
                End With
        
            Case 19      'Mermas por Ruta y Tipo de Merma
                With AL_RptRepMermasRutaTipoMerma
                
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg"): .ImgLogo.Height = 810: .ImgLogo.Width = 1920
                    .LblTitulo.Caption = "Mermas por Ruta y Tipo de Merma ( " & NivelReporte & " )"
                    '.DescripcionAgrupacion = DescripcionAgrupacion
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    '.TipoReporte = TipoReporte

                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show
                
                End With
                
            Case 20      'Cambios Físicos
                With AL_RptRepCambios
                
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Cambios Físicos ( " & NivelReporte & " )"
                    '.DescripcionAgrupacion = DescripcionAgrupacion
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    '.TipoReporte = TipoReporte

                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show 1
                
                End With
        
            Case 21      'Libros de Ruta
                With AL_RptRepLibrosDeRuta
                
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Libro de Ruta ( " & NivelReporte & " )"
                    .DescripcionAgrupacion = DescripcionAgrupacion
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    .TipoReporte = TipoReporte

                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show 1
                
                End With
        
            Case 22      'Saldos del Vendedor
                With AL_RptRepSaldosVendedor
                
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Saldos del Vendedor ( " & NivelReporte & " )"
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show 1
                
                End With
        
             Case 23      'Póliza Productos Araceli
                With AL_RptRepPolizaAraceli
                
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Póliza Productos Araceli ( " & NivelReporte & " )"
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show 1
                
                End With
        
             Case 24      'Póliza Modelo de Oriente
                With AL_RptRepPolizaModeloOriente
                
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Póliza Modelo de Oriente ( " & NivelReporte & " )"
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show 1
                
                End With
        
             Case 25      'Modelo de Oriente Entradas y Salidas
                With AL_RptRepModeloOrienteES
                
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Reporte de Entradas y Salidas Modelo de Oriente ( " & NivelReporte & " )"
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    .Printer.Orientation = ddOLandscape: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show 1
                
                End With
        
             Case 26      'Modelo de Oriente Envase
                With AL_RptRepModeloOrienteEnvase
                
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Reporte de Envase Modelo de Oriente ( " & NivelReporte & " )"
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show 1
                
                End With
        
             Case 27      'Efectivo y Documentos
                With AL_RptRepEfectivo
                
                    .GrpHdCajero.Visible = IIf(EjecutaSQL = 20, True, False)
                    .GrpFtCajero.Visible = IIf(EjecutaSQL = 20, True, False)
                    
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Reporte de Efectivo y Documentos ( " & NivelReporte & " )"
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show 1
                
                End With
        
             Case 28      'Ventas por Marca
                With AL_RptRepVentasCreditoMarca
                
                    .GpFtProds.Visible = IIf(EjecutaSQL = 20, False, True)
                    .GpHdProds.Visible = IIf(EjecutaSQL = 20, False, True)
                    .Detail.Visible = IIf(EjecutaSQL = 20, False, True)
                
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Reporte de Ventas por Marca ( " & NivelReporte & " )"
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show 1
                
                End With
                                
             Case 29      'Ventas por Producto a Precio Base
                With AL_RptRepVentasProductoMarca
                
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Reporte de Ventas por Producto a Precio Base ( " & NivelReporte & " )"
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show 1
                
                End With
        
             Case 30      'Ventas Acreditadas
                With AL_RptRepVentasAcredita
                
                    .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                    .LblTitulo.Caption = "Reporte de Ventas Acreditadas( " & NivelReporte & " )"
                    .LblCedis.Caption = RepIdCedi & " - " & RepNombreCedi
                    .LblDatos.Caption = "Periodo del  " & Format(RepFechaInicial, ctFechaLarga) & _
                                        "  al  " & Format(RepFechaFinal, ctFechaLarga)
                    .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
                    .LblUsuario.Caption = "Usuario: " & Usuario
                    .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
                    .Show 1
                
                End With
        End Select
    Else
        mensaje "ERR", "No se Encontraron Registros en el periodo seleccionado"
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


Private Sub btnAplica_Click()
On Error Resume Next

    ObtenerRegistrosFiltro

End Sub

Private Sub DTPPeriodo_Change(Index As Integer)
On Error Resume Next
    
    Select Case Index
        Case 0  'caso de primera fecha
            DTPPeriodo(1).MinDate = DTPPeriodo(0).Value
    End Select
    
    MensajeSeleccionFiltro

End Sub

Private Sub Form_Activate()
On Error Resume Next
    
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

Private Sub LstVDatos_ItemCheck(Index As Integer, ByVal Item As MSComctlLib.ListItem)
On Error Resume Next

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

    SubReporteSeleccionado = Index
    
    MensajeSeleccionFiltro
End Sub




