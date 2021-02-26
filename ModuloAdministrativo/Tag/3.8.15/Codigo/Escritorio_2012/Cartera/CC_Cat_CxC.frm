VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_Cat_CxC 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Mantenimiento de Cuentas por Cobrar"
   ClientHeight    =   8685
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
   MinButton       =   0   'False
   ScaleHeight     =   8685
   ScaleWidth      =   12660
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton btnAcreditar 
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
      Picture         =   "CC_Cat_CxC.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   17
      Top             =   4560
      Width           =   1695
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
      Height          =   8655
      Index           =   0
      Left            =   120
      TabIndex        =   19
      Top             =   0
      Width           =   12495
      Begin VB.CommandButton btnFacturar 
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
         Left            =   8760
         Picture         =   "CC_Cat_CxC.frx":0758
         Style           =   1  'Graphical
         TabIndex        =   18
         Top             =   4560
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
         Left            =   5160
         Picture         =   "CC_Cat_CxC.frx":0E42
         Style           =   1  'Graphical
         TabIndex        =   15
         Top             =   8040
         Width           =   1575
      End
      Begin VB.Frame Frame3 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Datos del Cliente"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   3015
         Left            =   120
         TabIndex        =   25
         Top             =   1560
         Width           =   12255
         Begin VB.TextBox TxtIdCliente 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   1800
            TabIndex        =   6
            Top             =   480
            Width           =   975
         End
         Begin VB.TextBox TxtRFC 
            Height          =   375
            Left            =   120
            TabIndex        =   5
            Top             =   480
            Width           =   1575
         End
         Begin VB.TextBox TxtRazonSocial 
            Height          =   375
            Left            =   2880
            TabIndex        =   7
            Top             =   480
            Width           =   2295
         End
         Begin MSComctlLib.ListView LstClientes 
            Height          =   2055
            Left            =   120
            TabIndex        =   10
            Top             =   915
            Width           =   12015
            _ExtentX        =   21193
            _ExtentY        =   3625
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
         Begin VB.Label Label26 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cliente Seleccionado"
            Height          =   240
            Left            =   5280
            TabIndex        =   30
            Top             =   240
            Width           =   1830
         End
         Begin VB.Label LblCliente 
            BackColor       =   &H00FFFFFF&
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   450
            Left            =   5400
            TabIndex        =   29
            Top             =   480
            Width           =   5205
         End
         Begin VB.Label Label20 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Id Sucursal"
            Height          =   240
            Left            =   1800
            TabIndex        =   28
            Top             =   240
            Width           =   975
         End
         Begin VB.Label Label21 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Sucursal"
            Height          =   255
            Left            =   2880
            TabIndex        =   27
            Top             =   240
            Width           =   1695
         End
         Begin VB.Label Label22 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cliente"
            Height          =   240
            Left            =   120
            TabIndex        =   26
            Top             =   240
            Width           =   600
         End
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
         Left            =   3480
         Picture         =   "CC_Cat_CxC.frx":14D9
         Style           =   1  'Graphical
         TabIndex        =   14
         Top             =   8040
         Width           =   1575
      End
      Begin VB.Frame FrmDatos 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Datos de la Cuenta por Cobrar"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   1335
         Left            =   120
         TabIndex        =   20
         Top             =   240
         Width           =   12255
         Begin VB.CheckBox ChkFolio 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Filtrar por Serie y Folio"
            Height          =   255
            Left            =   8280
            TabIndex        =   4
            Top             =   435
            Width           =   2415
         End
         Begin VB.TextBox TxtSerie 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   7560
            MaxLength       =   5
            TabIndex        =   2
            Top             =   840
            Width           =   1095
         End
         Begin VB.ComboBox cmbCedis 
            Height          =   360
            Left            =   3000
            Style           =   2  'Dropdown List
            TabIndex        =   1
            Top             =   840
            Width           =   3855
         End
         Begin VB.TextBox TxtFolio 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   9480
            MaxLength       =   8
            TabIndex        =   3
            Top             =   840
            Width           =   1095
         End
         Begin MSComCtl2.DTPicker DTPFecha 
            Height          =   375
            Left            =   840
            TabIndex        =   0
            Top             =   840
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
            Format          =   52101121
            CurrentDate     =   39376
         End
         Begin MSComCtl2.DTPicker DTPPeriodo 
            Height          =   375
            Left            =   2040
            TabIndex        =   32
            Top             =   360
            Width           =   2295
            _ExtentX        =   4048
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
            CustomFormat    =   "MMMM yyyy"
            Format          =   52101123
            CurrentDate     =   39448
            MaxDate         =   73050
            MinDate         =   39448
         End
         Begin VB.Label Label2 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Seleccione el mes"
            Height          =   255
            Left            =   240
            TabIndex        =   34
            Top             =   360
            Width           =   1695
         End
         Begin VB.Label LblPeriodo 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Estatus del Periodo"
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
            Height          =   255
            Left            =   4560
            TabIndex        =   33
            Top             =   480
            Width           =   5655
         End
         Begin VB.Label Label1 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Serie"
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
            Left            =   6960
            TabIndex        =   31
            Top             =   840
            Width           =   435
         End
         Begin VB.Label Label4 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cedis"
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
            Left            =   2400
            TabIndex        =   24
            Top             =   840
            Width           =   615
         End
         Begin VB.Label Label7 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Folio"
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
            Left            =   8880
            TabIndex        =   22
            Top             =   840
            Width           =   405
         End
         Begin VB.Label Label5 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Fecha"
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
            TabIndex        =   21
            Top             =   840
            Width           =   510
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
         Left            =   120
         Picture         =   "CC_Cat_CxC.frx":1E6F
         Style           =   1  'Graphical
         TabIndex        =   12
         Top             =   8040
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
         Left            =   1800
         Picture         =   "CC_Cat_CxC.frx":24FD
         Style           =   1  'Graphical
         TabIndex        =   13
         Top             =   8040
         Width           =   1575
      End
      Begin VB.CommandButton btnImprimeFactura 
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
         Left            =   6840
         Picture         =   "CC_Cat_CxC.frx":2C0D
         Style           =   1  'Graphical
         TabIndex        =   16
         Top             =   8040
         Width           =   1575
      End
      Begin MSComctlLib.ListView LstVentas 
         Height          =   2895
         Left            =   120
         TabIndex        =   11
         Top             =   5040
         Width           =   12255
         _ExtentX        =   21616
         _ExtentY        =   5106
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
      Begin MSComCtl2.DTPicker DTPFechaInicial 
         Height          =   375
         Left            =   960
         TabIndex        =   8
         Top             =   4640
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
         Format          =   52101121
         CurrentDate     =   39376
      End
      Begin MSComCtl2.DTPicker DTPFechaFinal 
         Height          =   375
         Left            =   2880
         TabIndex        =   9
         Top             =   4640
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
         Format          =   52101121
         CurrentDate     =   39376
      End
      Begin VB.Label Label6 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Al"
         Height          =   255
         Left            =   2520
         TabIndex        =   36
         Top             =   4680
         Width           =   375
      End
      Begin VB.Label Label3 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Del"
         Height          =   255
         Left            =   480
         TabIndex        =   35
         Top             =   4680
         Width           =   375
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
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   8640
         TabIndex        =   23
         Top             =   8160
         Width           =   1095
      End
   End
End
Attribute VB_Name = "CC_Cat_CxC"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public Seleccionar As Boolean
Dim LstDCedis, LstDVentas, LstDClientes
Public Folio, Fecha As Date, Mes, IdCedis, Serie
Public RFC, Nombre, Direccion, Tel, IdCliente, IdSucursal, StatusVenta

Sub MuestraCedis()
    StrCmd = "execute sel_CedisUsuarios '" & Usuario & "', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCedis = GetDataCBL(Rs, cmbCedis, "Seleccione un Cedis", "No hay Cedis asigandos")
End Sub

Private Sub btnAcreditar_Click()
On Error Resume Next

    If Trim(UCase(LstDVentas(21, LstVentas.SelectedItem.Index - 1))) <> UCase(Usuario) Then
        MousePointer = 0
        MsgBox "¡ La cuenta por cobrar solo puede ser modificada por el Usuario """ & LstDVentas(21, LstVentas.SelectedItem.Index - 1) & """ !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    With CC_Acreditar
        .TxtTipoVenta.Text = IIf(LstDVentas(2, LstVentas.SelectedItem.Index - 1) = "2", "2 - Crédito", "1 - Contado")
        .TxtSerie.Text = LstDVentas(4, LstVentas.SelectedItem.Index - 1)
        .TxtFolio.Text = LstDVentas(5, LstVentas.SelectedItem.Index - 1)
        
        .TxtCliente.Text = LstDVentas(14, LstVentas.SelectedItem.Index - 1) & " - " & LstDVentas(15, LstVentas.SelectedItem.Index - 1)
        .TxtSucursal.Text = LstDVentas(16, LstVentas.SelectedItem.Index - 1) & " - " & LstDVentas(17, LstVentas.SelectedItem.Index - 1)
                
        .IdCedis = LstDVentas(0, LstVentas.SelectedItem.Index - 1)
        .IdTipoVenta = LstDVentas(2, LstVentas.SelectedItem.Index - 1)
        .Folio = LstDVentas(5, LstVentas.SelectedItem.Index - 1)
        .Serie = LstDVentas(4, LstVentas.SelectedItem.Index - 1)
        .IdCliente = LstDVentas(14, LstVentas.SelectedItem.Index - 1)
        .Nombre = LstDVentas(15, LstVentas.SelectedItem.Index - 1)
        .StatusVenta = Trim(LstDVentas(20, LstVentas.SelectedItem.Index - 1))
        .Fecha = CDate(LstDVentas(3, LstVentas.SelectedItem.Index - 1))
                
        .Top = Me.Top + ((Me.Height - .Height) / 2)
        .Left = Me.Left + ((Me.Width - .Width) / 2)

'        .IdTipoVenta = LstDFacturas(2, LstFacturas.SelectedItem.Index - 1)
'        .Folio = LstDFacturas(4, LstFacturas.SelectedItem.Index - 1)
'        .Serie = LstDFacturas(3, LstFacturas.SelectedItem.Index - 1)
'
'        .TxtTipoVenta.Text = LstDFacturas(5, LstFacturas.SelectedItem.Index - 1)
'        .TxtSerie.Text = LstDFacturas(3, LstFacturas.SelectedItem.Index - 1)
'        .TxtFolio.Text = LstDFacturas(4, LstFacturas.SelectedItem.Index - 1)
'
'        .TxtCliente.Text = LstDFacturas(6, LstFacturas.SelectedItem.Index - 1) & " - " & LstDFacturas(7, LstFacturas.SelectedItem.Index - 1)
'        .TxtRFC.Text = LstDFacturas(16, LstFacturas.SelectedItem.Index - 1)
'        .TxtSucursal.Text = LstDFacturas(14, LstFacturas.SelectedItem.Index - 1) & " (CB: " & LstDFacturas(12, LstFacturas.SelectedItem.Index - 1) & ") " & LstDFacturas(13, LstFacturas.SelectedItem.Index - 1)
'        .TxtListaPrecios.Text = LstDFacturas(19, LstFacturas.SelectedItem.Index - 1) & " - " & LstDFacturas(20, LstFacturas.SelectedItem.Index - 1)
        
        .TxtUsuario.Text = Usuario
        .Show vbModal
    End With

End Sub

Private Sub btnActualizar_Click()
On Error GoTo Err_NuevoAnt:
    
    If LblEdicion.Caption <> "Consulta" Then
    
        If Not ValidaModulo("MCXC", True) Then Exit Sub
        
        Fecha = DTPFecha.Value
        Folio = Trim(TxtFolio.Text)
        Serie = Trim(TxtSerie.Text)
        
        If cmbCedis.ListIndex = 0 Then
            MsgBox "¡ Selecciona un Cedis !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If IdCliente = "0" Or IdSucursal = "" Then
            MsgBox "¡ Selecciona un Cliente !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
    
        If Folio = "0" Or Folio = "" Then
            MsgBox "¡ Teclea un Folio para la Cuenta por Cobrar !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
    
        If Serie = "" Then
            MsgBox "¡ Teclea una Serie para la Cuenta por Cobrar !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If Not ValidaFolioVenta Then Exit Sub
    
        If Not ValidaPeriodo(IdCedis, Year(Fecha), Month(Fecha), "C", "A", 1) Then
            MsgBox "¡ " & strPeriodo & " !", vbInformation + vbOKOnly, App.Title
            TxtFolio.Text = "": TxtSerie.Text = "": LblCliente.Caption = ""
            MousePointer = 0
            Exit Sub
        End If
    
        MousePointer = 11
        ChkFolio.Value = 1
        ' inserta el Venta...
        StrCmd = "execute up_Ventas " & IdCedis & ", 2, '" & Serie & "', " & Folio & ", '" & FormatDate(Fecha) & "', '" & IdCliente & "', '" & IdSucursal & "', '" & Usuario & "', 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
            
        DTPFechaInicial.Value = Fecha: DTPFechaFinal.Value = Fecha
        MuestraVentas
        LblEdicion.Caption = "Consulta"
    End If
    
No_Err_NuevoAnt:
    MousePointer = 0
    Exit Sub
    
Err_NuevoAnt:
    MousePointer = 0
    If Err.Number = -2147217873 Then
        MsgBox "¡ El Folio ya ha sido asignado a otro Usuario !", vbInformation + vbOKOnly, App.Title
        TxtFolio.Text = ""
    Else
        MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    End If
    GoTo No_Err_NuevoAnt:
    
End Sub

Private Sub btnAplica_Click()
On Error GoTo Err_AplicaAnt:
    
    If IsEmpty(LstDVentas) Then Exit Sub

    If Not ValidaModulo("MCXC", True) Then Exit Sub
    
    If Trim(UCase(LstDVentas(21, LstVentas.SelectedItem.Index - 1))) <> UCase(Usuario) Then
        MousePointer = 0
        MsgBox "¡ La cuenta por cobrar solo puede ser modificada por el Usuario """ & LstDVentas(21, LstVentas.SelectedItem.Index - 1) & """ !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Trim(LstDVentas(20, LstVentas.SelectedItem.Index - 1)) = "A" Or Trim(LstDVentas(20, LstVentas.SelectedItem.Index - 1)) = "" Then
        MousePointer = 0
        MsgBox "¡ La cuenta por cobrar no puede ser Aplicada !. ", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Not ValidaPeriodo(IdCedis, Year(Fecha), Month(Fecha), "C", "A", 1) Then
        MsgBox "¡ " & strPeriodo & " !", vbInformation + vbOKOnly, App.Title
        MousePointer = 0
        Exit Sub
    End If
    
    If MsgBox("Una vez Aplicado la cuenta por cobrar  ya NO podrá modificarse. ¿Desea continuar?", vbQuestion + vbYesNo, App.Title) = vbNo Then
        MousePointer = 0
        Exit Sub
    End If

    MousePointer = 11
    
    StrCmd = "execute up_Ventas " & IdCedis & ", 2, '" & Serie & "', " & Folio & ", '19000101', '0', '', '" & Usuario & "', 2"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    
    MuestraVentas
    MsgBox "¡ Cuenta por cobrar Aplicada !", vbInformation + vbOKOnly, App.Title

No_Err_AplicaAnt:
    MousePointer = 0
    Exit Sub
    
Err_AplicaAnt:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_AplicaAnt:

End Sub

Private Sub btnEliminar_Click()
On Error GoTo Err_EliminarAnt:

    If LblEdicion.Caption = "Nuevo" Then
        Exit Sub
    Else

        If IsEmpty(LstDVentas) Then Exit Sub
    
        If Not ValidaModulo("MCXC", True) Then Exit Sub
        
        If Trim(UCase(LstDVentas(21, LstVentas.SelectedItem.Index - 1))) <> UCase(Usuario) Then
            MousePointer = 0
            MsgBox "¡ La cuenta por cobrar solo puede ser modificada por el Usuario """ & LstDVentas(21, LstVentas.SelectedItem.Index - 1) & """ !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If Trim(LstDVentas(20, LstVentas.SelectedItem.Index - 1)) <> "P" Then
            MousePointer = 0
            MsgBox "¡ La cuenta por cobrar no puede ser Eliminada !. ", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If Not ValidaPeriodo(IdCedis, Year(Fecha), Month(Fecha), "C", "A", 1) Then
            MsgBox "¡ " & strPeriodo & " !", vbInformation + vbOKOnly, App.Title
            MousePointer = 0
            Exit Sub
        End If
        
        If MsgBox("¿ Deseas Eliminar la cuenta por cobrar seleccionada ?", vbQuestion + vbYesNo, App.Title) = vbNo Then
            MousePointer = 0
            Exit Sub
        End If
            
        MousePointer = 11
        
    If Not IsNull(LstDVentas(24, LstVentas.SelectedItem.Index - 1)) And LstDVentas(24, LstVentas.SelectedItem.Index - 1) <> "" Then
    
                                 Set ClaseCFDADM = New LbCFDADM.LbCFDADM
                    MensajeCFD = ClaseCFDADM.LlamarCFDADM(PathRouteDesktop, TransProdIDFactura, RutaXML, 4)
                    
                    If StringStartsWith(MensajeCFD, "202", vbTextCompare) Then
                   
                    MsgBox MensajeCFD
                     GoTo Continua:
                    End If
                    
                    If Trim(MensajeCFD) <> "" Then
                  
                    GoTo Err_CancelacionCFDI:
                    End If

    
    End If
    
Continua:
        
        StrCmd = "execute up_Ventas " & LstDVentas(0, LstVentas.SelectedItem.Index - 1) & ", 2, '" & LstDVentas(4, LstVentas.SelectedItem.Index - 1) & "', " & LstDVentas(5, LstVentas.SelectedItem.Index - 1) & ", '19000101', '0', '', '" & Usuario & "', 3"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        
        MuestraVentas
        MsgBox "¡ Cuenta por cobrar Eliminada !", vbInformation + vbOKOnly, App.Title

    End If

No_Err_EliminarAnt:
    MousePointer = 0
    Exit Sub

Err_EliminarAnt:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_EliminarAnt:

Err_CancelacionCFDI:
    MousePointer = 0
    MsgBox "Error: " & MensajeCFD, vbInformation + vbOKOnly, App.Title
GoTo No_Err_EliminarAnt:
End Sub

Private Sub btnFacturar_Click()
On Error Resume Next

    If IsEmpty(LstDVentas) Then Exit Sub
    
    If Trim(UCase(LstDVentas(21, LstVentas.SelectedItem.Index - 1))) <> UCase(Usuario) Then
        MousePointer = 0
        MsgBox "¡ La cuenta por cobrar solo puede ser modificada por el Usuario """ & LstDVentas(21, LstVentas.SelectedItem.Index - 1) & """ !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    CC_Facturar.TxtDatos.Text = "Datos de la Remisión"
    
    With CC_Facturar
        .TxtCliente.Text = LstDVentas(14, LstVentas.SelectedItem.Index - 1) & " - " & LstDVentas(15, LstVentas.SelectedItem.Index - 1)
        .TxtRFC.Text = LstDVentas(22, LstVentas.SelectedItem.Index - 1)
        .TxtSucursal.Text = LstDVentas(16, LstVentas.SelectedItem.Index - 1) & " - " & LstDVentas(17, LstVentas.SelectedItem.Index - 1)
        
        .TxtRemision.Text = LstDVentas(4, LstVentas.SelectedItem.Index - 1) & " - " & LstDVentas(5, LstVentas.SelectedItem.Index - 1) & " | " & FormatCurrency(LstDVentas(10, LstVentas.SelectedItem.Index - 1), 2, vbTrue)
        
        .Actividad = 1
        .IdCedis = LstDVentas(0, LstVentas.SelectedItem.Index - 1)
        .IdTipoVenta = LstDVentas(2, LstVentas.SelectedItem.Index - 1)
        .Folio = LstDVentas(5, LstVentas.SelectedItem.Index - 1)
        .Serie = LstDVentas(4, LstVentas.SelectedItem.Index - 1)
                
        .Left = CC_Cat_CxC.Left + ((CC_Cat_CxC.Width - .Width) / 2)
        .Top = CC_Cat_CxC.Top + ((CC_Cat_CxC.Height - .Height) / 2)
        .Show vbModal
    End With

End Sub

Private Sub btnImprimeFactura_Click()
   
On Error GoTo ImpFact:

    MensajeCFD = ""

    If CFDCedis = "1" Then
        StrCmd = "execute sel_VentasFacturaCFD " & LstDVentas(0, LstVentas.SelectedItem.Index - 1) & ", 0, " & LstDVentas(2, LstVentas.SelectedItem.Index - 1) & ", '" & LstDVentas(4, LstVentas.SelectedItem.Index - 1) & "', " & LstDVentas(5, LstVentas.SelectedItem.Index - 1) & ", 1, 2"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If Not RsC.EOF Then
            TransProdIDFactura = RsC.Fields(6)
        Else
            TransProdIDFactura = ""
            GoTo ImpFactTrad:
        End If
    
        Set ClaseCFDADM = New LbCFDADM.LbCFDADM
        MensajeCFD = ClaseCFDADM.LlamarCFDADM(PathRouteDesktop, TransProdIDFactura, RutaXML, 3)
        If Trim(MensajeCFD) <> "" Then GoTo ImpFact:

    Else
ImpFactTrad:
        With CC_RptFactura
            
            StrCmd = "execute sel_VentasDetalle " & LstDVentas(0, LstVentas.SelectedItem.Index - 1) & ", " & LstDVentas(2, LstVentas.SelectedItem.Index - 1) & ", '" & LstDVentas(4, LstVentas.SelectedItem.Index - 1) & "', " & LstDVentas(5, LstVentas.SelectedItem.Index - 1) & ", 4"
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
            
            If Not RsC.EOF Then
                .LblControl.Caption = "Ced" & LstDVentas(0, LstVentas.SelectedItem.Index - 1) & "Dcto" & LstDVentas(4, LstVentas.SelectedItem.Index - 1) & "-" & LstDVentas(5, LstVentas.SelectedItem.Index - 1)
                .object.DataSrc.DataSourceName = Cnn
                .object.DataSrc.Recordset = RsC
                .Printer.Orientation = ddOPortrait
                .Printer.PaperSize = 1
                .Show vbModal
            End If
        End With
    End If
    
No_ImpFact:
    MousePointer = 0
    Exit Sub
    
ImpFact:
    MousePointer = 0
    If Trim(MensajeCFD) = "" Then
        MsgBox "Error al crear " & IIf(CFDCedis = "1", " el CFDI", "la Factura") & " : " & Err.Description, vbInformation + vbOKOnly, App.Title
    Else
        MsgBox MensajeCFD, vbInformation + vbOKOnly, App.Title
    End If
    GoTo No_ImpFact:
    
End Sub

'Private Sub btnImprimeFactura_Click()
'
'    If IsEmpty(LstDVentas) Then Exit Sub
'
'    If Trim(UCase(LstVentas.SelectedItem.ListSubItems(9))) = "BAJA" Then
'        MousePointer = 0
'        MsgBox "¡ El Venta " & LstVentas.SelectedItem & " tiene Status """ & LstVentas.SelectedItem.ListSubItems(9) & """ !. No puede ejecutar esta acción. ", vbInformation + vbOKOnly, App.Title
'        Exit Sub
'    End If
'
'    With CC_RptMovimientoAnt
'        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
'        .LblTitulo.Caption = "REPORTE DE MOVIMIENTOS DEL Venta"
'
'        StrCmd = "execute Rep_Movimientos " & Folio & ", '01/01/1900', '01/01/1900', 2"
'        If RsC.State Then RsC.Close
'        RsC.Open StrCmd, Cnn
'        If Not RsC.EOF Then
'            .object.DataSrc.DataSourceName = Cnn
'            .object.DataSrc.Recordset = RsC
'        End If
'
'        .Printer.Orientation = ddOPortrait
'        .Printer.PaperSize = 1
'        .Show vbModal
'    End With
'
'End Sub

Private Sub btnNuevo_Click()
On Error Resume Next
    
    If Not ValidaModulo("MCXC", True) Then Exit Sub
    
    If Not ValidaPeriodo(LstDCedis(0, cmbCedis.ListIndex - 1), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1) Then
        MsgBox "¡ " & strPeriodo & " !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    TxtFolio.Text = "": TxtSerie.Text = "": LblCliente.Caption = ""
    LblEdicion.Caption = "Nuevo"
End Sub

Private Sub cmbCedis_Click()
On Error Resume Next
    If cmbCedis.ListIndex = 0 Then
        IdCedis = 0
        Exit Sub
    Else
        IdCedis = LstDCedis(0, cmbCedis.ListIndex - 1)
    End If
    Val_PeriodoVenta
    IdCliente = 0: IdSucursal = ""
    LblCliente.Caption = ""
    LstClientes.ListItems.Clear
End Sub

Private Sub DTPFecha_Change()
On Error Resume Next
    Fecha = DTPFecha.Value
    DTPFechaInicial.Value = Fecha: DTPFechaFinal.Value = Fecha
    DTPFechaFinal_Validate False
End Sub

Private Sub DTPFechaFinal_Validate(Cancel As Boolean)
On Error Resume Next
    MuestraVentas
End Sub

Private Sub DTPPeriodo_Change()
On Error Resume Next
    Val_PeriodoVenta
    MuestraVentas
End Sub

Private Sub Form_Activate()
'On Error Resume Next
'    DTPPeriodo.Value = Date
'    DTPFecha.Value = Date
'    DTPFechaInicial.Value = Date: DTPFechaFinal.Value = Date
'    MuestraCedis
'    cmbCedis.ListIndex = 1
'    MuestraVentas
End Sub

Private Sub Form_Load()
On Error Resume Next
    DTPPeriodo.Value = Date
    DTPFecha.Value = Date
    DTPFechaInicial.Value = Date: DTPFechaFinal.Value = Date
    MuestraCedis
    cmbCedis.ListIndex = 1
    MuestraVentas
End Sub

Private Sub LstVentas_DblClick()
On Error Resume Next

    If Not IsEmpty(LstDVentas) Then
        With CC_Cat_CxCDetalle
            .TxtTipoVenta.Text = IIf(LstDVentas(2, LstVentas.SelectedItem.Index - 1) = "2", "2 - Crédito", "1 - Contado")
            .TxtSerie.Text = LstDVentas(4, LstVentas.SelectedItem.Index - 1)
            .TxtFolio.Text = LstDVentas(5, LstVentas.SelectedItem.Index - 1)
            
            .TxtCliente.Text = LstDVentas(14, LstVentas.SelectedItem.Index - 1) & " - " & LstDVentas(15, LstVentas.SelectedItem.Index - 1)
            .TxtSucursal.Text = LstDVentas(16, LstVentas.SelectedItem.Index - 1) & " - " & LstDVentas(17, LstVentas.SelectedItem.Index - 1)
            '.TxtListaPrecios.Text = LstDVentas(19, LstVentas.SelectedItem.Index - 1) & " - " & LstDVentas(20, LstVentas.SelectedItem.Index - 1)
                    
            .IdCedis = LstDVentas(0, LstVentas.SelectedItem.Index - 1)
            .IdTipoVenta = LstDVentas(2, LstVentas.SelectedItem.Index - 1)
            .Folio = LstDVentas(5, LstVentas.SelectedItem.Index - 1)
            .Serie = LstDVentas(4, LstVentas.SelectedItem.Index - 1)
            .IdCliente = LstDVentas(14, LstVentas.SelectedItem.Index - 1)
            .Nombre = LstDVentas(15, LstVentas.SelectedItem.Index - 1)
            .StatusVenta = Trim(LstDVentas(20, LstVentas.SelectedItem.Index - 1))
            .Fecha = CDate(LstDVentas(3, LstVentas.SelectedItem.Index - 1))
                    
            .Top = Me.Top + ((Me.Height - .Height) / 2)
            .Left = Me.Left + ((Me.Width - .Width) / 2)
            
            .MuestraDetalle False
            .MuestraTotales False
            .Show vbModal
        End With
    End If
End Sub

Private Sub LstClientes_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    If IsEmpty(LstDClientes) Then
        IdCliente = 0: IdSucursal = "": LblCliente.Caption = ""
    End If
    
    IdCliente = LstDClientes(2, LstClientes.SelectedItem.Index - 1)
    IdSucursal = LstDClientes(4, LstClientes.SelectedItem.Index - 1)
    LblCliente.Caption = LstDClientes(2, LstClientes.SelectedItem.Index - 1) & " - " & LstDClientes(3, LstClientes.SelectedItem.Index - 1) & Chr(13) & Chr(10) & LstDClientes(4, LstClientes.SelectedItem.Index - 1) & " - " & LstDClientes(5, LstClientes.SelectedItem.Index - 1)
End Sub

Private Sub LstVentas_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    LblEdicion.Caption = "Consulta"
    
    TxtFolio.Text = LstDVentas(5, LstVentas.SelectedItem.Index - 1)
    TxtSerie.Text = LstDVentas(4, LstVentas.SelectedItem.Index - 1)
    Folio = LstDVentas(5, LstVentas.SelectedItem.Index - 1)
    Serie = LstDVentas(4, LstVentas.SelectedItem.Index - 1)
    DTPFecha.Value = LstDVentas(3, LstVentas.SelectedItem.Index - 1)
    Fecha = LstDVentas(3, LstVentas.SelectedItem.Index - 1)
    IdCedis = LstDVentas(0, LstVentas.SelectedItem.Index - 1)
    cmbCedis.ListIndex = SearchInList(LstDCedis, CStr(LstDVentas(0, LstVentas.SelectedItem.Index - 1)), 0)
'    TxtRFC.Text = LstDVentas(4, LstVentas.SelectedItem.Index - 1): TxtRazonSocial.Text = LstDVentas(6, LstVentas.SelectedItem.Index - 1)

End Sub

Private Sub TxtFolio_GotFocus()
On Error Resume Next
    SelText TxtFolio
End Sub

Private Sub TxtFolio_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtFolio_Validate(Cancel As Boolean)
On Error Resume Next
    If LblEdicion.Caption <> "Consulta" And Trim(TxtSerie.Text) <> "" And Trim(TxtFolio.Text) <> "" Then ValidaFolioVenta
End Sub

Private Sub TxtIdCliente_Change()
On Error Resume Next
    FiltraClientes
End Sub

Private Sub TxtIdCliente_GotFocus()
On Error Resume Next
    SelText TxtIdCliente
End Sub

Private Sub TxtIdCliente_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtRazonSocial_Change()
On Error Resume Next
    TxtIdCliente.Text = ""
    FiltraClientes
End Sub

Private Sub TxtRazonSocial_GotFocus()
On Error Resume Next
    SelText TxtRazonSocial
End Sub

Private Sub TxtRazonSocial_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtRFC_Change()
On Error Resume Next
    FiltraClientes
End Sub

Private Sub TxtRFC_GotFocus()
On Error Resume Next
    SelText TxtRFC
End Sub

Private Sub TxtRFC_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Sub FiltraClientes()
On Error Resume Next
    If IsEmpty(LstDCedis) Then Exit Sub
    
    LstVentas.ListItems.Clear: LstDVentas = Empty
    LblCliente.Caption = ""
    
    If cmbCedis.ListIndex = 0 Then
        MsgBox "¡ Selecciona un Cedis !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Trim(TxtIdCliente.Text) = "" And Trim(TxtRFC.Text) = "" And Trim(TxtRazonSocial.Text) = "" Then Exit Sub
    
    StrCmd = "execute sel_ClientesFacturas " & CLng(LstDCedis(0, cmbCedis.ListIndex - 1)) & ",'" & Trim(TxtIdCliente.Text) & "','" & Trim(TxtRFC.Text) & "','" & Trim(TxtRazonSocial.Text) & "', 6"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDClientes = GetDataLVL(RsC, LstClientes, 0, 5, "0|0|0|0|0|0")
End Sub

Public Sub MuestraVentas()
On Error Resume Next
        
MousePointer = 11
        
    StrCmd = "execute sel_Ventas2 " & IdCedis & ", '" & FormatDate(DTPFechaInicial.Value) & "', '" & FormatDate(DTPFechaFinal.Value) & "', '" & IIf(ChkFolio.Value, Trim(TxtSerie.Text), "") & "', '" & IIf(ChkFolio.Value, Trim(TxtFolio.Text), "") & "', '" & Usuario & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDVentas = GetDataLVL(Rs, LstVentas, 1, 17, "0|0|0|0|0|0|0|0|0|0|9|9|9|9|0|0|0|0|0|0")
    'LstVentas_ItemClick LstVentas.SelectedItem
MousePointer = 0
End Sub

Sub Val_PeriodoVenta()
On Error Resume Next
    ValidaPeriodo IdCedis, Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1
    LblPeriodo.Caption = strPeriodo
    DTPFecha.MinDate = CDate("01/" & Month(DTPPeriodo.Value) & "/" & Year(DTPPeriodo.Value))
    DTPFecha.MaxDate = CDate("01/" & Month(DTPPeriodo.Value) + 1 & "/" & Year(DTPPeriodo.Value)) - 1
    DTPFecha.Value = DTPPeriodo.Value
    Mes = Month(DTPPeriodo.Value)
End Sub

Private Sub TxtSerie_GotFocus()
On Error Resume Next
    SelText TxtSerie
End Sub

Private Sub TxtSerie_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Function ValidaFolioVenta() As Boolean
On Error Resume Next
    MousePointer = 11
    StrCmd = "execute sel_Ventas " & IdCedis & ", 1, '" & Trim(TxtSerie.Text) & "', '" & Trim(TxtFolio.Text) & "', '" & Usuario & "', 5"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        MousePointer = 0
        MsgBox "¡ Ya existe una Cuenta por Cobrar con la Serie " & TxtSerie.Text & " y el Folio " & TxtFolio.Text & " !", vbInformation + vbOKOnly, App.Title
'        TxtSerie.Text = "": TxtFolio.Text = ""
        TxtSerie.SetFocus
        ValidaFolioVenta = False
        Exit Function
    End If
    ValidaFolioVenta = True
    MousePointer = 0
End Function

Private Sub TxtSerie_Validate(Cancel As Boolean)
On Error Resume Next
    If LblEdicion.Caption <> "Consulta" And Trim(TxtSerie.Text) <> "" And Trim(TxtFolio.Text) <> "" Then ValidaFolioVenta
End Sub
