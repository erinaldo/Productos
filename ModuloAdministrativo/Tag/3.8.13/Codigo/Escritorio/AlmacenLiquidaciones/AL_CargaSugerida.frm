VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.1#0"; "MSCOMCTL.OCX"
Begin VB.Form AL_CargaSugerida 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Cálculo de Carga Sugerida"
   ClientHeight    =   8280
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   12255
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
   ScaleHeight     =   8280
   ScaleWidth      =   12255
   ShowInTaskbar   =   0   'False
   Begin VB.Frame Frame1 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Selecciona la Fecha de la Carga y el Tipo de Cálculo"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   1095
      Left            =   120
      TabIndex        =   30
      Top             =   120
      Width           =   9735
      Begin VB.OptionButton OptTipoCarga 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Solicitud vía dispositivo Móvil"
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
         Index           =   2
         Left            =   6000
         TabIndex        =   40
         Top             =   765
         Width           =   3375
      End
      Begin VB.TextBox TxtRuta 
         BorderStyle     =   0  'None
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
         Height          =   240
         Left            =   240
         Locked          =   -1  'True
         TabIndex        =   32
         Top             =   375
         Width           =   1215
      End
      Begin VB.OptionButton OptTipoCarga 
         BackColor       =   &H00FFFFFF&
         Caption         =   "En Base a Históricos de Ventas"
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
         Index           =   1
         Left            =   2520
         TabIndex        =   2
         Top             =   765
         Width           =   3255
      End
      Begin VB.OptionButton OptTipoCarga 
         BackColor       =   &H00FFFFFF&
         Caption         =   "En Base a Preventa"
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
         Index           =   0
         Left            =   120
         TabIndex        =   1
         Top             =   765
         Width           =   2175
      End
      Begin MSComCtl2.DTPicker DTPFecha 
         BeginProperty DataFormat 
            Type            =   0
            Format          =   "dddd dd ""de"" mmm ""de"" yy"
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   2058
            SubFormatType   =   0
         EndProperty
         Height          =   375
         Left            =   4200
         TabIndex        =   0
         Top             =   350
         Width           =   3615
         _ExtentX        =   6376
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
         CustomFormat    =   "dddd dd  'de' MMM 'de' yyyy"
         Format          =   51052547
         CurrentDate     =   39376
      End
      Begin VB.Label Label6 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Fecha de Carga Sugerida"
         Height          =   255
         Left            =   1800
         TabIndex        =   34
         Top             =   375
         Width           =   2295
      End
   End
   Begin VB.Frame FrmOpt 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Detalle de Carga"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3975
      Index           =   2
      Left            =   120
      TabIndex        =   20
      Top             =   4200
      Visible         =   0   'False
      Width           =   12015
      Begin VB.TextBox TxtCambios 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   7680
         MaxLength       =   8
         TabIndex        =   14
         Text            =   "0"
         Top             =   480
         Width           =   975
      End
      Begin VB.TextBox TxtCalculo 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   6480
         Locked          =   -1  'True
         MaxLength       =   8
         TabIndex        =   13
         Text            =   "0"
         Top             =   480
         Width           =   1095
      End
      Begin VB.TextBox TxtIdProducto 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   120
         MaxLength       =   10
         TabIndex        =   12
         Top             =   480
         Width           =   855
      End
      Begin VB.TextBox TxtProducto 
         Height          =   375
         Left            =   1080
         Locked          =   -1  'True
         TabIndex        =   16
         Top             =   480
         Width           =   5295
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
         Left            =   9840
         Picture         =   "AL_CargaSugerida.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   15
         Top             =   360
         Width           =   1695
      End
      Begin MSComctlLib.ListView LstDetalleProductos 
         Height          =   2895
         Left            =   120
         TabIndex        =   21
         Top             =   960
         Width           =   11775
         _ExtentX        =   20770
         _ExtentY        =   5106
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
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Definitiva"
         Height          =   255
         Left            =   7680
         TabIndex        =   25
         Top             =   240
         Width           =   975
      End
      Begin VB.Label Label3 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Cálculo"
         Height          =   255
         Left            =   6720
         TabIndex        =   24
         Top             =   240
         Width           =   855
      End
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Cve. P"
         Height          =   255
         Left            =   120
         TabIndex        =   23
         Top             =   240
         Width           =   495
      End
      Begin VB.Label Label1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Producto"
         Height          =   255
         Left            =   1080
         TabIndex        =   22
         Top             =   240
         Width           =   3735
      End
   End
   Begin VB.Frame FrmOpt 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Definir parámetros"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   2895
      Index           =   0
      Left            =   120
      TabIndex        =   31
      Top             =   1320
      Visible         =   0   'False
      Width           =   10815
      Begin VB.CommandButton btnCalculaC 
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
         Left            =   9240
         Picture         =   "AL_CargaSugerida.frx":071B
         Style           =   1  'Graphical
         TabIndex        =   38
         Top             =   240
         Width           =   1455
      End
      Begin MSComCtl2.DTPicker DTPInicial 
         BeginProperty DataFormat 
            Type            =   0
            Format          =   "dddd dd ""de"" mmm ""de"" yy"
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   2058
            SubFormatType   =   0
         EndProperty
         Height          =   375
         Left            =   1800
         TabIndex        =   35
         Top             =   360
         Width           =   3615
         _ExtentX        =   6376
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
         CustomFormat    =   "dddd dd  'de' MMM 'de' yyyy"
         Format          =   51052547
         CurrentDate     =   39376
      End
      Begin MSComCtl2.DTPicker DTPFinal 
         BeginProperty DataFormat 
            Type            =   0
            Format          =   "dddd dd ""de"" mmm ""de"" yy"
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   2058
            SubFormatType   =   0
         EndProperty
         Height          =   375
         Left            =   5520
         TabIndex        =   37
         Top             =   360
         Width           =   3615
         _ExtentX        =   6376
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
         CustomFormat    =   "dddd dd  'de' MMM 'de' yyyy"
         Format          =   51052547
         CurrentDate     =   39376
      End
      Begin MSComctlLib.ListView LstRutas 
         Height          =   1935
         Left            =   120
         TabIndex        =   39
         Top             =   840
         Width           =   10575
         _ExtentX        =   18653
         _ExtentY        =   3413
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   -1  'True
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
      Begin VB.Label Label10 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Rango de Fechas"
         Height          =   255
         Left            =   120
         TabIndex        =   36
         Top             =   390
         Width           =   1575
      End
   End
   Begin VB.Frame FrmOpt 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Definir parámetros "
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2895
      Index           =   1
      Left            =   120
      TabIndex        =   17
      Top             =   1320
      Visible         =   0   'False
      Width           =   10815
      Begin VB.OptionButton Opt 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Por Producto"
         Height          =   255
         Index           =   1
         Left            =   3240
         TabIndex        =   4
         Top             =   280
         Width           =   1455
      End
      Begin VB.OptionButton Opt 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Por Familia de Producto"
         Height          =   240
         Index           =   0
         Left            =   600
         TabIndex        =   3
         Top             =   280
         Value           =   -1  'True
         Width           =   2415
      End
      Begin VB.CommandButton btnCalcular 
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
         Left            =   9120
         Picture         =   "AL_CargaSugerida.frx":0C85
         Style           =   1  'Graphical
         TabIndex        =   11
         Top             =   720
         Width           =   1455
      End
      Begin VB.TextBox TxtSemanas 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   6960
         MaxLength       =   5
         TabIndex        =   8
         Text            =   "0"
         Top             =   840
         Width           =   855
      End
      Begin VB.TextBox TxtPorcentaje 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   8040
         MaxLength       =   8
         TabIndex        =   9
         Text            =   "0"
         Top             =   840
         Width           =   855
      End
      Begin MSComctlLib.ListView LstParametros 
         Height          =   1455
         Left            =   120
         TabIndex        =   10
         Top             =   1320
         Width           =   10575
         _ExtentX        =   18653
         _ExtentY        =   2566
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
      Begin VB.Frame Frm 
         BackColor       =   &H00FFFFFF&
         BorderStyle     =   0  'None
         Height          =   855
         Index           =   1
         Left            =   120
         TabIndex        =   27
         Top             =   480
         Visible         =   0   'False
         Width           =   6735
         Begin VB.TextBox TxtIdProducto1 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   120
            MaxLength       =   5
            TabIndex        =   5
            Top             =   360
            Width           =   855
         End
         Begin VB.TextBox TxtProducto1 
            Height          =   375
            Left            =   1080
            Locked          =   -1  'True
            TabIndex        =   6
            Top             =   360
            Width           =   5655
         End
         Begin VB.Label Label9 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cve. P"
            Height          =   255
            Left            =   120
            TabIndex        =   29
            Top             =   120
            Width           =   495
         End
         Begin VB.Label Label8 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Producto"
            Height          =   255
            Left            =   1200
            TabIndex        =   28
            Top             =   120
            Width           =   3735
         End
      End
      Begin VB.Frame Frm 
         BackColor       =   &H00FFFFFF&
         BorderStyle     =   0  'None
         Height          =   615
         Index           =   0
         Left            =   120
         TabIndex        =   26
         Top             =   600
         Width           =   6615
         Begin VB.ComboBox CmbFamilia 
            Height          =   360
            Left            =   0
            Style           =   2  'Dropdown List
            TabIndex        =   7
            Top             =   240
            Width           =   6615
         End
         Begin VB.Label Label5 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Familia de Producto"
            Height          =   255
            Left            =   120
            TabIndex        =   33
            Top             =   0
            Width           =   3735
         End
      End
      Begin VB.Label Label13 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Semanas"
         Height          =   255
         Left            =   6960
         TabIndex        =   19
         Top             =   600
         Width           =   975
      End
      Begin VB.Label Label7 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Porcentaje"
         Height          =   255
         Left            =   7920
         TabIndex        =   18
         Top             =   600
         Width           =   975
      End
   End
End
Attribute VB_Name = "AL_CargaSugerida"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDFamilias, LstDParametros, LstDProductos, LstDRutas
'Public FechaSugerida As Date

Private Sub btnCalculaC_Click()
Dim Filtro As String

On Error GoTo Err_CalculoCargaC:

MousePointer = 11

    Filtro = ""
    For i = 1 To LstRutas.ListItems.Count
        If LstRutas.ListItems(i).Checked Then
            Filtro = Filtro & "''" & IdCedis & Format(LstRutas.ListItems(i), "0000") & "'', "
        End If
    Next i
    If Len(Trim(Filtro)) > 0 Then Filtro = Mid(Filtro, 1, Len(Filtro) - 2)
    
    If Trim(Filtro) = "" Then
        MsgBox "¡ Define los parámetros para el cálculo !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If MsgBox("Los cálculos hechos anteriormente se borrarán. ¿ Deseas continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    StrCmd = "execute up_CargasSugeridasDetalle " & IdCedis & ", " & IdRuta & ", '" & FormatDate(DTPFecha.Value) & "', '', 0, '0', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    StrCmd = "execute up_CargasSugeridasRutas " & IdCedis & ", " & IdRuta & ", '" & FormatDate(DTPFecha.Value) & "', '" & FormatDate(DTPInicial.Value) & "', '" & FormatDate(DTPFinal.Value) & "', 0, 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    For i = 1 To LstRutas.ListItems.Count
        If LstRutas.ListItems(i).Checked Then
            StrCmd = "execute up_CargasSugeridasRutas " & IdCedis & ", " & IdRuta & ", '" & FormatDate(DTPFecha.Value) & "', '" & FormatDate(DTPInicial.Value) & "', '" & FormatDate(DTPFinal.Value) & "', " & LstRutas.ListItems(i) & ", 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
        End If
    Next i
    
    StrCmd = "execute up_CargasSugeridasDetalle2 " & IdCedis & ", " & IdRuta & ", '" & FormatDate(DTPFecha.Value) & "', '" & Format(DTPInicial.Value, "yyyymmdd") & "', '" & Format(DTPFinal.Value, "yyyymmdd") & "', '" & Filtro & "', '0', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MuestraCargaDetalle

No_Err_CalculoCargaC:
    MousePointer = 0
    MsgBox "¡ Cálculo de Carga Terminado !", vbInformation + vbOKOnly, App.Title
    Exit Sub
    
Err_CalculoCargaC:
    MousePointer = 0
    MsgBox "Error al calcular la Carga. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_CalculoCargaC:

End Sub

Private Sub btnCalcular_Click()
Dim Max As Integer, FechaCalculo As Date

On Error GoTo Err_CalculoCarga:

If Not ValidaUltimoDiaCerrado(IdCedis, FormatDate(DTPFecha.Value)) Then Exit Sub

MousePointer = 11

    If IsEmpty(LstDParametros) Then
        MsgBox "¡ Define los parámetros para el cálculo !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If MsgBox("Los cálculos hechos anteriormente se borrarán. ¿ Deseas continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    StrCmd = "execute up_CargasSugeridasDetalle " & IdCedis & ", " & IdRuta & ", '" & FormatDate(DTPFecha.Value) & "', '', 0, '1', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    StrCmd = "execute sel_CargasSugeridasParametros " & IdCedis & ", " & IdRuta & ", '" & FormatDate(DTPFecha.Value) & "', 0, 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    Max = 0
    If Not Rs.EOF Then
        Max = Rs.Fields(0)
    End If
    
    Filtro = ""
    If Max > 0 Then
        For i = 1 To Max
            Filtro = Filtro & IIf(i > 1, ", ", "") & "''" & FormatDate(DTPFecha.Value - (7 * i)) & "''"
            StrCmd = "execute up_CargasSugeridasDetalle " & IdCedis & ", " & IdRuta & ", '" & FormatDate(DTPFecha.Value) & "', '" & Filtro & "', " & i & ", '1', 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
        Next
    End If
    MuestraCargaDetalle
    
No_Err_CalculoCarga:
    MousePointer = 0
    MsgBox "¡ Cálculo de Carga Terminado !", vbInformation + vbOKOnly, App.Title
    Exit Sub
    
Err_CalculoCarga:
    MousePointer = 0
    MsgBox "Error al calcular la Carga. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_CalculoCarga:

End Sub

Private Sub btnImprimir_Click()
On Error Resume Next

Dim Opc
    For i = 0 To OptTipoCarga.Count - 1
        If OptTipoCarga(i).Value Then
            Opc = i + 3
            Exit For
        End If
    Next

    Filtro = ""
    For i = 1 To LstRutas.ListItems.Count
        If LstRutas.ListItems(i).Checked Then
            Filtro = Filtro & "" & LstRutas.ListItems(i) & ", "
        End If
    Next i
    If Len(Trim(Filtro)) > 0 Then Filtro = Mid(Filtro, 1, Len(Filtro) - 2)
    
    With AL_RptCargaSugerida
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
        .LblCedis.Caption = IdCedis & " - " & NomCedis
        .LblRuta.Caption = IdRuta
        .LblRutaP.Caption = Filtro
        .LblDatos.Caption = Format(Fecha, "dd ""de"" MMMM ""de"" yyyy ")
        .LblFechaCarga.Caption = Format(DTPFecha.Value, "dd ""de"" MMMM ""de"" yyyy ")
        
        Select Case Opc - 3
            Case 0
                .Etq01.Caption = "Pedidos"
                .Etq02.Caption = "Pedidos + Porc."
                .Etq03.Caption = "Modifiaciones"
            Case 1
                .Etq01.Caption = "Venta"
                .Etq02.Caption = "Vta + Porc."
                .Etq03.Caption = "Modifiaciones"
            Case 2
                .Etq01.Caption = "-----------"
                .Etq02.Caption = "Pedido Terminal"
                .Etq03.Caption = "Modifiaciones"
        End Select
        
        StrCmd = "execute sel_CargasSugeridas " & IdCedis & ", " & IdRuta & ", '" & FormatDate(DTPFecha.Value) & "', 0, " & Opc
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        If Not Rs.EOF Then
            .object.DataSrc.DataSourceName = Cnn
            .object.DataSrc.Recordset = Rs
        End If
        
        .Printer.Orientation = ddOPortrait
        .Printer.PaperSize = 1
        .Show
    End With
End Sub

Private Sub CmbFamilia_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        TxtSemanas.SetFocus
    End If
End Sub

Private Sub DTPFecha_Validate(Cancel As Boolean)
On Error Resume Next
    If OptTipoCarga(0).Value Or OptTipoCarga(1).Value Or OptTipoCarga(2).Value Then
        If OptTipoCarga(0).Value Then
            DTPInicial.Value = DTPFecha.Value - 1
            DTPFinal.Value = DTPFecha.Value - 1
        End If
        MuestraParametros
        MuestraCargaDetalle
    End If
End Sub

Private Sub DTPFinal_Validate(Cancel As Boolean)
On Error Resume Next
    If DTPInicial.Value > DTPFinal.Value Then DTPFinal.Value = DTPInicial.Value
End Sub

Private Sub DTPInicial_Validate(Cancel As Boolean)
On Error Resume Next
    If DTPInicial.Value > DTPFinal.Value Then DTPInicial.Value = DTPFinal.Value
End Sub

Private Sub Form_Activate()
On Error Resume Next
    If OptTipoCarga(0).Value Or OptTipoCarga(1).Value Or OptTipoCarga(2).Value Then
        MuestraParametros
        MuestraCargaDetalle
    End If
End Sub

Private Sub Form_Load()
On Error Resume Next
    LlenaComboFamilias
End Sub

Private Sub Opt_Click(Index As Integer)
On Error Resume Next
    Frm(0).Visible = IIf(Opt(0).Value, True, False)
    Frm(1).Visible = IIf(Opt(1).Value, True, False)
End Sub

Sub LlenaComboFamilias()
On Error Resume Next
    StrCmd = "select IdFamilia, Familia from Familias where status = 'A' order by Familia asc "
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDFamilias = GetDataCBL(RsC, CmbFamilia, "Seleccione una Familia", "No existen Familias")
End Sub

Private Sub OptTipoCarga_Click(Index As Integer)
On Error Resume Next
Dim IndexSel
    
    FrmOpt(0).Visible = False: FrmOpt(1).Visible = False: FrmOpt(2).Visible = False
    
    For i = 0 To OptTipoCarga.Count - 1
        If OptTipoCarga(i).Value Then
            IndexSel = i
            Exit For
        End If
    Next
    
    Select Case IndexSel
        Case 0:
            FrmOpt(0).Visible = True: FrmOpt(2).Visible = True
            FrmOpt(2).Top = 4200: FrmOpt(2).Height = 3975: LstDetalleProductos.Height = 2895
        Case 1:
            FrmOpt(1).Visible = True: FrmOpt(2).Visible = True
            FrmOpt(2).Top = 4200: FrmOpt(2).Height = 3975: LstDetalleProductos.Height = 2895
        Case 2:
            FrmOpt(0).Visible = False: FrmOpt(1).Visible = False: FrmOpt(2).Visible = True
            FrmOpt(2).Top = 1320: FrmOpt(2).Height = 6855: LstDetalleProductos.Height = 5775
    End Select
    DTPFecha_Validate False
End Sub

Private Sub TxtCambios_GotFocus()
On Error Resume Next
    SelText TxtCambios
End Sub

Private Sub TxtCambios_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        SplitTxt TxtCambios
        ActualizaCargaSugerida
        TxtIdProducto.SetFocus
    End If
    If Dec Then
        If KeyAscii <> "42" Then KeyAscii = itDecimal(KeyAscii)
    Else
        If KeyAscii <> "42" Then KeyAscii = itEntero(KeyAscii)
    End If
End Sub

Private Sub TxtCambios_Validate(Cancel As Boolean)
On Error Resume Next
    TxtCambios.Text = itFlotante(TxtCambios.Text)
End Sub

Private Sub TxtIdProducto_Change()
On Error Resume Next
    TxtProducto1.Text = ""
End Sub

Private Sub TxtIdProducto_GotFocus()
On Error Resume Next
    SelText TxtIdProducto
End Sub

Private Sub TxtIdProducto_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        BuscaProdCargaS 2
        TxtCambios.SetFocus
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtIdProducto1_Change()
On Error Resume Next
    TxtProducto1.Text = ""
End Sub

Private Sub TxtIdProducto1_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        BuscaProdCargaS 1
        TxtSemanas.SetFocus
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtPorcentaje_GotFocus()
On Error Resume Next
    SelText TxtPorcentaje
End Sub

Private Sub TxtPorcentaje_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        ActualizaParametros IIf(Opt(0).Value, 2, 1)
        If Opt(0).Value Then
            CmbFamilia.SetFocus
        Else
            TxtIdProducto1.SetFocus
        End If
        Exit Sub
    End If
    KeyAscii = itDecimal(KeyAscii)
End Sub

Private Sub TxtPorcentaje_Validate(Cancel As Boolean)
On Error Resume Next
    TxtPorcentaje.Text = itFlotante(TxtPorcentaje.Text)
End Sub

Private Sub TxtSemanas_GotFocus()
On Error Resume Next
    SelText TxtSemanas
End Sub

Private Sub TxtSemanas_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        TxtPorcentaje.SetFocus
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Sub BuscaProdCargaS(Opc As Integer)
On Error Resume Next

    If Opc = 1 Then
        StrCmd = "execute sel_CargasSugeridas " & IdCedis & ", " & IdRuta & ", '" & FormatDate(DTPFecha.Value) & "', " & TxtIdProducto1.Text & ", " & Opc
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            TxtProducto1.Text = Rs.Fields(1)
        Else
            TxtProducto1.Text = "¡ El Producto no existe !": TxtSemanas.Text = "0": TxtPorcentaje.Text = "0"
        End If
    End If
    
    If Opc = 2 Then
        StrCmd = "execute sel_CargasSugeridas " & IdCedis & ", " & IdRuta & ", '" & FormatDate(DTPFecha.Value) & "', " & TxtIdProducto.Text & ", " & Opc
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            TxtProducto.Text = Rs.Fields(1)
            TxtCalculo.Text = Rs.Fields(2)
            TxtCambios.Text = Rs.Fields(3)
            Dec = Rs.Fields(4)
        Else
            TxtProducto.Text = "¡ El Producto no existe !": TxtCalculo.Text = "0": TxtCambios.Text = "0"
        End If
    End If

End Sub

Sub ActualizaParametros(Opc As Integer)
On Error Resume Next
    
    If Not ValidaUltimoDiaCerrado(IdCedis, FormatDate(DTPFecha.Value)) Then Exit Sub
    
    If Not IsEmpty(LstDProductos) Then
        If MsgBox("¡ Ya se ha calculado una Carga con los parámtros actuales !" & Chr(13) & Chr(10) & "Al cambiar parámetros actuales, la Carga calculada puede no coincidir con los nuevos criterios." & Chr(13) & Chr(10) & "¿ Deseas continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    End If
    
    If (TxtSemanas.Text = "" Or TxtSemanas.Text = "0") Then
        If MsgBox("¿ Estás seguro que quieres borrar el parámetro seleccionado ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    End If

    Dim Filtro2 As String
    If Opc = 1 Then
    Filtro2 = TxtIdProducto1.Text
    Else
    Filtro2 = LstDFamilias(0, CmbFamilia.ListIndex - 1)
    End If

    'StrCmd = "execute up_CargasSugeridasParametros " & IdCedis & ", " & IdRuta & ", '" & FormatDate(DTPFecha.Value) & "', " & IIf(Opc = 1, TxtIdProducto1.Text, LstDFamilias(0, CmbFamilia.ListIndex - 1)) & ", " & TxtSemanas.Text & ", " & CDbl(TxtPorcentaje.Text) / 100 & ", " & Opc
    StrCmd = "execute up_CargasSugeridasParametros " & IdCedis & ", " & IdRuta & ", '" & FormatDate(DTPFecha.Value) & "', " & Filtro2 & ", " & TxtSemanas.Text & ", " & CDbl(TxtPorcentaje.Text) / 100 & ", " & Opc
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    TxtSemanas.Text = "0": TxtPorcentaje.Text = "0": TxtIdProducto1.Text = "": TxtProducto1.Text = ""
    
    MuestraParametros
End Sub

Sub MuestraParametros()
On Error Resume Next
    If OptTipoCarga(0).Value Then
        StrCmd = "execute sel_CargasSugeridasParametros " & IdCedis & ", " & IdRuta & ", '" & FormatDate(DTPFecha.Value) & "', 0, 3"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            DTPInicial.Value = Rs.Fields(4): DTPFinal.Value = Rs.Fields(5)
        End If
        LstDRutas = GetDataLVL(Rs, LstRutas, 1, 3, "0|0|0")
        For i = 0 To UBound(LstDRutas, 2)
            If CInt(LstDRutas(6, i)) > 0 Then
                LstRutas.ListItems(i + 1).Checked = True
            End If
        Next i
    Else
        StrCmd = "execute sel_CargasSugeridasParametros " & IdCedis & ", " & IdRuta & ", '" & FormatDate(DTPFecha.Value) & "', 0, 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        LstDParametros = GetDataLVL(Rs, LstParametros, 1, 5, "0|0|0|1|8")
    End If
End Sub

Sub MuestraCargaDetalle()
On Error Resume Next
Dim Opc
    For i = 0 To OptTipoCarga.Count - 1
        If OptTipoCarga(i).Value Then
            Opc = i + 3
            Exit For
        End If
    Next
    
    If Opc = 5 Then
        StrCmd = "execute sel_CargasSugeridas " & IdCedis & ", " & IdRuta & ", '" & FormatDate(AL_Liquidacion.DTPFecha.Value) & "', 0, 6"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
    End If
    
    StrCmd = "execute sel_CargasSugeridas " & IdCedis & ", " & IdRuta & ", '" & FormatDate(DTPFecha.Value) & "', 0, " & Opc
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDProductos = GetDataLVL(Rs, LstDetalleProductos, 2, 6, "0|0|9|9|9")
    If IsEmpty(LstDProductos) Then
        DTPInicial.Value = DTPFecha.Value - 1
        DTPFinal.Value = DTPFecha.Value - 1
    End If
End Sub

Sub ActualizaCargaSugerida()
On Error Resume Next
Dim Opc
    
'    If Not ValidaUltimoDiaCerrado(IdCedis, FormatDate(DTPFecha.Value)) Then Exit Sub
    
    For i = 0 To OptTipoCarga.Count - 1
        If OptTipoCarga(i).Value Then
            Opc = i
            Exit For
        End If
    Next
    
    StrCmd = "exec sel_CargasSugeridasE " & IdCedis & ", '" & FormatDate(AL_Liquidacion.DTPFecha.Value) & "', '" & FormatDate(DTPFecha.Value) & "', " & IdRuta & ", " & TxtIdProducto.Text & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If CDbl(Rs.Fields(2)) + CDbl(Rs.Fields(3)) - CDbl(TxtCambios.Text) < 0 Then
        MsgBox "¡ No hay existencias suficientes para realizar la carga. Existencias = " & FormatNumber(CDbl(Rs.Fields(2)) + CDbl(Rs.Fields(3)), 2, vbTrue) & "!", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
       
    StrCmd = "execute up_CargasSugeridasDetalle " & IdCedis & ", " & IdRuta & ", '" & FormatDate(DTPFecha.Value) & "', '" & TxtIdProducto.Text & "', " & TxtCambios.Text & ", " & Opc & ", 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    MuestraCargaDetalle
End Sub
