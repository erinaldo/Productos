VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_FacturasBusqueda 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Búsqueda de Facturas"
   ClientHeight    =   8490
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
   ScaleHeight     =   8490
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
      Height          =   8415
      Index           =   0
      Left            =   120
      TabIndex        =   14
      Top             =   0
      Width           =   12375
      Begin VB.CheckBox ChkSeleccionarFact 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Seleccionar Todos"
         Height          =   240
         Left            =   360
         MaskColor       =   &H00E0E0E0&
         TabIndex        =   36
         Top             =   5040
         Width           =   2325
      End
      Begin VB.OptionButton OptConsulta 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Pedido"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Index           =   2
         Left            =   9480
         TabIndex        =   3
         Top             =   600
         Width           =   1095
      End
      Begin VB.OptionButton OptConsulta 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Venta"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Index           =   1
         Left            =   8400
         TabIndex        =   2
         Top             =   600
         Value           =   -1  'True
         Width           =   975
      End
      Begin VB.Frame Frame1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Monto de la Factura"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   2295
         Left            =   8160
         TabIndex        =   26
         Top             =   2280
         Width           =   3975
         Begin VB.CommandButton btnImprimir 
            BackColor       =   &H00FFFFFF&
            Height          =   495
            Left            =   1080
            Picture         =   "CC_FacturasBusqueda.frx":0000
            Style           =   1  'Graphical
            TabIndex        =   13
            Top             =   1680
            Width           =   1815
         End
         Begin VB.Label LblTotal 
            Alignment       =   1  'Right Justify
            Appearance      =   0  'Flat
            BackColor       =   &H80000005&
            BorderStyle     =   1  'Fixed Single
            Caption         =   "$ 0.00"
            ForeColor       =   &H80000008&
            Height          =   345
            Left            =   2175
            TabIndex        =   34
            Top             =   1200
            Width           =   1635
         End
         Begin VB.Label LblIva 
            Alignment       =   1  'Right Justify
            Appearance      =   0  'Flat
            BackColor       =   &H80000005&
            BorderStyle     =   1  'Fixed Single
            Caption         =   "$ 0.00"
            ForeColor       =   &H80000008&
            Height          =   345
            Left            =   2175
            TabIndex        =   33
            Top             =   840
            Width           =   1635
         End
         Begin VB.Label LblSubtotal 
            Alignment       =   1  'Right Justify
            Appearance      =   0  'Flat
            BackColor       =   &H80000005&
            BorderStyle     =   1  'Fixed Single
            Caption         =   "$ 0.00"
            ForeColor       =   &H80000008&
            Height          =   345
            Left            =   2175
            TabIndex        =   32
            Top             =   480
            Width           =   1635
         End
         Begin VB.Label Label9 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Total:"
            Height          =   240
            Left            =   1590
            TabIndex        =   31
            Top             =   1200
            Width           =   480
         End
         Begin VB.Label Label7 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Iva:"
            Height          =   240
            Left            =   1740
            TabIndex        =   30
            Top             =   840
            Width           =   285
         End
         Begin VB.Label Label6 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subtotal:"
            Height          =   240
            Left            =   1275
            TabIndex        =   29
            Top             =   480
            Width           =   780
         End
         Begin VB.Label LblNoFacturas 
            Alignment       =   1  'Right Justify
            Appearance      =   0  'Flat
            BackColor       =   &H80000005&
            BorderStyle     =   1  'Fixed Single
            Caption         =   "0"
            ForeColor       =   &H80000008&
            Height          =   345
            Left            =   120
            TabIndex        =   28
            Top             =   840
            Width           =   915
         End
         Begin VB.Label Label8 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Ventas"
            Height          =   240
            Left            =   270
            TabIndex        =   27
            Top             =   480
            Width           =   615
         End
      End
      Begin VB.TextBox TxtFolio 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   9000
         MaxLength       =   9
         TabIndex        =   6
         Top             =   1680
         Width           =   1095
      End
      Begin VB.CommandButton btnArchivo 
         BackColor       =   &H00FFFFFF&
         Default         =   -1  'True
         Height          =   495
         Left            =   10440
         Picture         =   "CC_FacturasBusqueda.frx":071B
         Style           =   1  'Graphical
         TabIndex        =   11
         Top             =   1560
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
         Height          =   2895
         Left            =   120
         TabIndex        =   16
         Top             =   2040
         Width           =   7815
         Begin VB.CheckBox ChkSeleccionar 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Seleccionar Todos"
            Height          =   255
            Left            =   5400
            TabIndex        =   35
            Top             =   600
            Width           =   2175
         End
         Begin VB.TextBox TxtRazonSocial 
            Height          =   375
            Left            =   2880
            TabIndex        =   9
            Top             =   480
            Width           =   2295
         End
         Begin VB.TextBox TxtRFC 
            Height          =   375
            Left            =   120
            TabIndex        =   7
            Top             =   480
            Width           =   1575
         End
         Begin VB.TextBox TxtIdCliente 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   1800
            TabIndex        =   8
            Top             =   480
            Width           =   975
         End
         Begin MSComctlLib.ListView LstClientes 
            Height          =   1935
            Left            =   120
            TabIndex        =   10
            Top             =   915
            Width           =   7455
            _ExtentX        =   13150
            _ExtentY        =   3413
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
         Begin VB.Label Label22 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cliente"
            Height          =   240
            Left            =   120
            TabIndex        =   21
            Top             =   240
            Width           =   600
         End
         Begin VB.Label Label21 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Sucursal"
            Height          =   255
            Left            =   2880
            TabIndex        =   20
            Top             =   240
            Width           =   1695
         End
         Begin VB.Label Label20 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Id Sucursal"
            Height          =   240
            Left            =   1800
            TabIndex        =   19
            Top             =   240
            Width           =   975
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
            Height          =   210
            Left            =   5280
            TabIndex        =   18
            Top             =   600
            Visible         =   0   'False
            Width           =   2325
         End
         Begin VB.Label Label26 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cliente Seleccionado"
            Height          =   240
            Left            =   5280
            TabIndex        =   17
            Top             =   240
            Visible         =   0   'False
            Width           =   1830
         End
      End
      Begin MSComctlLib.ListView LstFacturas 
         Height          =   2895
         Left            =   120
         TabIndex        =   12
         Top             =   5400
         Width           =   12015
         _ExtentX        =   21193
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
      Begin MSComctlLib.ListView LstCedis 
         Height          =   1575
         Left            =   240
         TabIndex        =   0
         Top             =   480
         Width           =   3735
         _ExtentX        =   6588
         _ExtentY        =   2778
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
      Begin MSComctlLib.ListView LstRutas 
         Height          =   1575
         Left            =   4080
         TabIndex        =   1
         Top             =   480
         Width           =   4095
         _ExtentX        =   7223
         _ExtentY        =   2778
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
      Begin MSComCtl2.DTPicker DTPFechaInicial 
         Height          =   375
         Left            =   8760
         TabIndex        =   4
         Top             =   1080
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
         Format          =   87162881
         CurrentDate     =   39376
      End
      Begin MSComCtl2.DTPicker DTPFechaFinal 
         Height          =   375
         Left            =   10680
         TabIndex        =   5
         Top             =   1080
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
         Format          =   87162881
         CurrentDate     =   39376
      End
      Begin VB.Label Label1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Del"
         Height          =   255
         Left            =   8280
         TabIndex        =   25
         Top             =   1080
         Width           =   375
      End
      Begin VB.Label Label3 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Al"
         Height          =   255
         Left            =   10320
         TabIndex        =   24
         Top             =   1080
         Width           =   375
      End
      Begin VB.Label Label4 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Folio"
         Height          =   240
         Left            =   8280
         TabIndex        =   23
         Top             =   1680
         Width           =   420
      End
      Begin VB.Label Label5 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Ruta"
         Height          =   255
         Left            =   4200
         TabIndex        =   22
         Top             =   240
         Width           =   2895
      End
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Cedis"
         Height          =   255
         Left            =   360
         TabIndex        =   15
         Top             =   240
         Width           =   2775
      End
   End
End
Attribute VB_Name = "CC_FacturasBusqueda"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim lstDCedis, LstDClientes, LstDFacturas, Base As Integer
Dim strIds, strFolios, Param, Asc As Boolean, AscV As Boolean, ParamV, Orden

Public Sub btnArchivo_Click()
Dim Opc, IdCte, Folio, StrRutas

On Error GoTo Err_btnArchivo:

    MousePointer = 11

    If IsEmpty(lstDCedis) Then Exit Sub
    
    If Trim(TxtFolio.Text) = "" Then
        Folio = ""
    Else
        Folio = Trim(TxtFolio.Text)
    End If
    
    IdCte = ""
    For i = 1 To LstClientes.ListItems.Count
        If LstClientes.ListItems(i).Checked Then
            IdCte = IdCte & "''" & LstClientes.ListItems(i).ListSubItems(2) & "'', "
        End If
    Next
    If Len(IdCte) > 0 Then IdCte = Mid(IdCte, 1, Len(IdCte) - 2)
    
    StrRutas = ""
    For i = 1 To LstRutas.ListItems.Count
        If LstRutas.ListItems(i).Checked Then
            If OptConsulta(1).Value Then
                StrRutas = StrRutas & LstRutas.ListItems(i) & ", "
            Else
                StrRutas = StrRutas & "''" & LstRutas.ListItems(i) & "'', "
            End If
        End If
    Next
    If Len(StrRutas) > 0 Then StrRutas = Mid(StrRutas, 1, Len(StrRutas) - 2)
    
    Opc = IIf(OptConsulta(1).Value, 1, 2)
        
    OpenConn Server, "RouteADM", UserDB, PasswordDB
    StrCmd = "execute sel_FacturasBusqueda " & CLng(LstCedis.SelectedItem) & ", '" & IdCte & "', '" & StrRutas & "', '" & Folio & "', '" & FormatDate(DTPFechaInicial.Value) & "', '" & FormatDate(DTPFechaFinal.Value) & "', '" & Orden & "', " & Opc
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Rs.EOF Then MsgBox "¡ Ventas no encontradas con los criterios seleccionados !", vbInformation + vbOKOnly, App.Title
    LstDFacturas = GetDataLVL(Rs, LstFacturas, 2, 14, "0|4|0|0|0|4|0|0|0|0|3|3|3")
    OpenConn Server, Db, UserDB, PasswordDB
    
    
No_Err_btnArchivo:
    MousePointer = 0
    Exit Sub
        
Err_btnArchivo:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_btnArchivo:
End Sub

Private Sub btnImprimir_Click()
On Error Resume Next

    strIds = "": strFolios = ""
    For i = 1 To LstFacturas.ListItems.Count
        If LstFacturas.ListItems(i).Checked Then
            If OptConsulta(1).Value Then
                strIds = strIds & " ( Ventas.IdCedis = " & LstDFacturas(0, i - 1) & " and Ventas.IdSurtido = " & LstDFacturas(15, i - 1) & " and Ventas.IdTipoVenta = " & LstDFacturas(1, i - 1) & " and Ventas.Serie = ''" & LstDFacturas(5, i - 1) & "'' and Ventas.Folio = " & LstDFacturas(6, i - 1) & ") or "
                strFolios = strFolios & "Ced" & IdCedis & LstDFacturas(5, i - 1) & "-" & LstDFacturas(6, i - 1) & ", "
            Else
                strIds = strIds & "''" & LstDFacturas(15, i - 1) & "'', "
                strFolios = strFolios & "Ced" & IdCedis & "PedT" & LstDFacturas(15, i - 1) & ", "
            End If
        End If
    Next
    If Len(strIds) > 0 Then
        strIds = IIf(Not OptConsulta(1).Value, "t.transprodid in (", "") & Mid(strIds, 1, Len(strIds) - IIf(OptConsulta(1).Value, 3, 2)) & IIf(Not OptConsulta(1).Value, ")", "")
        strFolios = Mid(strFolios, 1, Len(strFolios) - 2)
    Else
        MsgBox "¡ Selecciona los Documentos a Imprimir !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
        
    With CC_OpcImpFactura
        .Ventana = True
        .ChkImpresion(3).Enabled = True
        .ChkImpresion(3).Value = 1
        .TxtFolio.Locked = False
        .OptCons = IIf(OptConsulta(1).Value, 1, 2)
        .strIds = strIds
        .strFolios = strFolios
        .OptPiezas(0).Caption = Etiqueta01
        .OptPiezas(1).Caption = Etiqueta02
        .Left = Me.Left + (Me.Width - .Width) / 2
        .Top = Me.Top + (Me.Height - .Height) / 2
        .Show
    End With
    
End Sub

Private Sub ChkSeleccionar_Click()
On Error Resume Next

    Select Case ChkSeleccionar.Value
        Case 0, 1     'caso de no seleccionar o seleccionar todo
            For i = 1 To LstClientes.ListItems.Count
                LstClientes.ListItems(i).Checked = ChkSeleccionar.Value
            Next
    End Select
End Sub

Private Sub ChkSeleccionarFact_Click()
On Error Resume Next
Dim UltimoSeleccionado

    Select Case ChkSeleccionarFact.Value
        Case 0, 1     'caso de no seleccionar o seleccionar todo
            For i = 1 To LstFacturas.ListItems.Count
                LstFacturas.ListItems(i).Checked = ChkSeleccionarFact.Value
            Next
            LstFacturas_ItemCheck LstFacturas.SelectedItem
    End Select
End Sub

Private Sub Form_Activate()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    Param = 3: Asc = True
    Orden = 1: AscV = True: ParamV = 8
End Sub

Private Sub Form_Load()
On Error Resume Next
    DTPFechaInicial.Value = Date: DTPFechaFinal.Value = Date
    Base = 0
    Param = 3: Asc = True
    Orden = 1: AscV = True: ParamV = 8
    MuestraCedis
End Sub

Private Sub MuestraCedis()
On Error Resume Next
    
    StrCmd = "execute sel_CedisUsuarios '" & Usuario & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    lstDCedis = GetDataLVL(Rs, LstCedis, 1, 2, "0|0")
    LstCedis_ItemClick LstCedis.SelectedItem
End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    CC_MovimientosDetalle.Inicio = False
End Sub

Private Sub LstCedis_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    
    StrCmd = "execute sel_Rutas '" & LstCedis.SelectedItem & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDRutas = GetDataLVL(Rs, LstRutas, 0, 1, "0|0")
    
End Sub

Private Sub LstClientes_Click()
On Error Resume Next
    If IsEmpty(LstDClientes) Then Exit Sub
    LblCliente.Caption = Trim(LstClientes.SelectedItem) & " - " & Trim(LstClientes.SelectedItem.ListSubItems(2))
End Sub

Private Sub LstClientes_ColumnClick(ByVal ColumnHeader As MSComctlLib.ColumnHeader)
On Error Resume Next

Select Case ColumnHeader.Index
    Case 1, 2, 3, 4:
        If Param = ColumnHeader.Index And Asc Then
            Asc = Not Asc
            Param = ColumnHeader.Index
            FiltraClientes Param + 7
        Else
            Asc = True
            Param = ColumnHeader.Index
            FiltraClientes Param + 3
        End If
End Select

End Sub

Private Sub LstClientes_ItemCheck(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next

    Dim ConteoRegistrosChecados As Integer
    ConteoRegistrosChecados = 0
    
    For i = 1 To LstClientes.ListItems.Count
        If LstClientes.ListItems(i).Checked Then
            ConteoRegistrosChecados = ConteoRegistrosChecados + 1
        End If
    Next
    
    Select Case ConteoRegistrosChecados
        Case Is = 0
            ChkSeleccionar.Value = 0
        Case Is = LstClientes.ListItems.Count
            ChkSeleccionar.Value = 1
        
        Case Is < LstClientes.ListItems.Count
            ChkSeleccionar.Value = 2
    End Select

End Sub

Private Sub LstFacturas_ColumnClick(ByVal ColumnHeader As MSComctlLib.ColumnHeader)
On Error Resume Next

MousePointer = 11
Select Case ColumnHeader.Index
    Case 8, 9, 10:
        If ParamV = ColumnHeader.Index And AscV Then
            AscV = Not AscV
            ParamV = ColumnHeader.Index
            Orden = ParamV - 4
            btnArchivo_Click
        Else
            AscV = True
            ParamV = ColumnHeader.Index
            Orden = ParamV - 7
            btnArchivo_Click
        End If
End Select
MousePointer = 0
End Sub

Private Sub LstFacturas_DblClick()
On Error Resume Next
    If IsEmpty(LstDFacturas) Then Exit Sub
    DetalleDeFactura LstDFacturas(0, LstFacturas.SelectedItem.Index - 1), LstDFacturas(1, LstFacturas.SelectedItem.Index - 1), LstDFacturas(2, LstFacturas.SelectedItem.Index - 1), LstDFacturas(3, LstFacturas.SelectedItem.Index - 1), Me.Top, Me.Left, Me.Width, Me.Height, Base
End Sub

Private Sub LstFacturas_ItemCheck(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    Dim i, j, k
    Dim Total, SubTotal, Iva
    Dim ConteoRegistrosChecados As Integer
    
    ConteoRegistrosChecados = 0
    Total = 0: SubTotal = 0: Iva = 0
    
    For i = 1 To LstFacturas.ListItems.Count
        If LstFacturas.ListItems(i).Checked Then
            SubTotal = SubTotal + CDbl(LstDFacturas(12, LstFacturas.ListItems(i).Index - 1))
            Iva = Iva + CDbl(LstDFacturas(13, LstFacturas.ListItems(i).Index - 1))
            Total = Total + CDbl(LstDFacturas(14, LstFacturas.ListItems(i).Index - 1))
            j = j + 1
        End If
        If LstFacturas.ListItems(i).Checked Then
            ConteoRegistrosChecados = ConteoRegistrosChecados + 1
        End If
    Next
    LblNoFacturas.Caption = FormatNumber(j, 0, vbTrue)
    LblSubtotal.Caption = FormatNumber(SubTotal, 2, vbTrue)
    LblIva.Caption = FormatNumber(Iva, 2, vbTrue)
    LblTotal.Caption = FormatNumber(Total, 2, vbTrue)
    
    Select Case ConteoRegistrosChecados
        Case Is = 0
            ChkSeleccionarFact.Value = 0
        Case Is = LstFacturas.ListItems.Count
            ChkSeleccionarFact.Value = 1
        
        Case Is < LstFacturas.ListItems.Count
            ChkSeleccionarFact.Value = 2
    End Select
    
End Sub

Private Sub TxtFolio_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtIdCliente_Change()
On Error Resume Next
    Param = 3: FiltraClientes Param
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
    Param = 3: FiltraClientes Param
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
    Param = 3: FiltraClientes Param
End Sub

Private Sub TxtRFC_GotFocus()
On Error Resume Next
    SelText TxtRFC
End Sub

Private Sub TxtRFC_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Sub FiltraClientes(Param)
On Error Resume Next
    If IsEmpty(lstDCedis) Then Exit Sub
    
    LstFacturas.ListItems.Clear: LstDFacturas = Empty
    LblCliente.Caption = ""
    
    If Trim(TxtIdCliente.Text) = "" And Trim(TxtRFC.Text) = "" And Trim(TxtRazonSocial.Text) = "" Then Exit Sub
    
    StrCmd = "execute sel_ClientesFacturas " & CLng(LstCedis.SelectedItem) & ",'" & Trim(TxtIdCliente.Text) & "','" & Trim(TxtRFC.Text) & "','" & Trim(TxtRazonSocial.Text) & "', " & Param
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDClientes = GetDataLVL(RsC, LstClientes, 1, 4, "0|0|0|0")
End Sub

