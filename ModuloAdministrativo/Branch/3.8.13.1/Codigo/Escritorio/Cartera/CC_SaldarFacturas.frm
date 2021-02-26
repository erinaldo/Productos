VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_SaldarFacturas 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Saldar Facturas en automático"
   ClientHeight    =   7920
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   12585
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   7920
   ScaleWidth      =   12585
   ShowInTaskbar   =   0   'False
   Begin VB.Frame FrmOpt 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Detalles del Movimiento"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   6855
      Index           =   2
      Left            =   120
      TabIndex        =   14
      Top             =   960
      Width           =   12375
      Begin VB.CheckBox ChkSeleccionar 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Seleccionar Todos los registros encontrados"
         Height          =   240
         Left            =   3360
         MaskColor       =   &H00E0E0E0&
         TabIndex        =   30
         Top             =   240
         Width           =   4845
      End
      Begin VB.TextBox TxtMontoFinal 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   1800
         MaxLength       =   8
         TabIndex        =   3
         Text            =   "0.00"
         Top             =   1320
         Width           =   975
      End
      Begin VB.Frame Frame2 
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
         Height          =   3375
         Left            =   120
         TabIndex        =   24
         Top             =   2760
         Width           =   12135
         Begin MSComctlLib.ListView LstPartidas 
            Height          =   3015
            Left            =   120
            TabIndex        =   5
            Top             =   240
            Width           =   11895
            _ExtentX        =   20981
            _ExtentY        =   5318
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
      End
      Begin VB.TextBox TxtCliente 
         BorderStyle     =   0  'None
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
         Left            =   360
         Locked          =   -1  'True
         TabIndex        =   16
         Text            =   "Pagos Cargados correctamente"
         Top             =   2520
         Width           =   2655
      End
      Begin VB.TextBox TxtMontoInicial 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   1800
         MaxLength       =   8
         TabIndex        =   2
         Text            =   "0.00"
         Top             =   600
         Width           =   975
      End
      Begin VB.CommandButton btnDelete 
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
         Left            =   11640
         Picture         =   "CC_SaldarFacturas.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   6
         Top             =   2280
         Width           =   495
      End
      Begin VB.CommandButton btnSaldar 
         BackColor       =   &H00FFFFFF&
         Height          =   375
         Left            =   600
         Picture         =   "CC_SaldarFacturas.frx":0425
         Style           =   1  'Graphical
         TabIndex        =   4
         Top             =   1920
         Width           =   1935
      End
      Begin VB.Frame Frame1 
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
         Height          =   735
         Left            =   4320
         TabIndex        =   17
         Top             =   6000
         Width           =   7935
         Begin VB.Label LblTotal 
            Alignment       =   1  'Right Justify
            Appearance      =   0  'Flat
            BackColor       =   &H80000005&
            BorderStyle     =   1  'Fixed Single
            Caption         =   "$ 0.00"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H80000008&
            Height          =   345
            Left            =   6015
            TabIndex        =   23
            Top             =   240
            Width           =   1635
         End
         Begin VB.Label LblIva 
            Alignment       =   1  'Right Justify
            Appearance      =   0  'Flat
            BackColor       =   &H80000005&
            BorderStyle     =   1  'Fixed Single
            Caption         =   "$ 0.00"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H80000008&
            Height          =   345
            Left            =   3495
            TabIndex        =   22
            Top             =   240
            Width           =   1635
         End
         Begin VB.Label LblSubtotal 
            Alignment       =   1  'Right Justify
            Appearance      =   0  'Flat
            BackColor       =   &H80000005&
            BorderStyle     =   1  'Fixed Single
            Caption         =   "$ 0.00"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H80000008&
            Height          =   345
            Left            =   1095
            TabIndex        =   21
            Top             =   240
            Width           =   1635
         End
         Begin VB.Label Label2 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Total:"
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
            Left            =   5460
            TabIndex        =   20
            Top             =   240
            Width           =   450
         End
         Begin VB.Label Label4 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Iva:"
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
            Left            =   3075
            TabIndex        =   19
            Top             =   240
            Width           =   270
         End
         Begin VB.Label Label6 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subtotal:"
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
            Left            =   255
            TabIndex        =   18
            Top             =   240
            Width           =   720
         End
      End
      Begin MSComCtl2.DTPicker DTPFechaInicial 
         Height          =   375
         Left            =   240
         TabIndex        =   0
         Top             =   600
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
         Format          =   125501441
         CurrentDate     =   39376
      End
      Begin MSComCtl2.DTPicker DTPFechaFinal 
         Height          =   375
         Left            =   240
         TabIndex        =   1
         Top             =   1320
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
         Format          =   125501441
         CurrentDate     =   39376
      End
      Begin MSComctlLib.ListView LstClientes 
         Height          =   2295
         Left            =   3120
         TabIndex        =   29
         Top             =   480
         Width           =   8415
         _ExtentX        =   14843
         _ExtentY        =   4048
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
      Begin VB.Label Label5 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Al"
         Height          =   255
         Left            =   240
         TabIndex        =   28
         Top             =   1080
         Width           =   375
      End
      Begin VB.Label Label3 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Del"
         Height          =   255
         Left            =   240
         TabIndex        =   27
         Top             =   360
         Width           =   375
      End
      Begin VB.Label Label1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "a"
         Height          =   255
         Left            =   1800
         TabIndex        =   25
         Top             =   1080
         Width           =   255
      End
      Begin VB.Label Label13 
         BackColor       =   &H00FFFFFF&
         Caption         =   "De"
         Height          =   255
         Left            =   1800
         TabIndex        =   15
         Top             =   360
         Width           =   375
      End
   End
   Begin VB.Frame Frame3 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Datos del Movimiento"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   735
      Left            =   120
      TabIndex        =   7
      Top             =   120
      Width           =   12375
      Begin VB.TextBox TxtTipoDocumento 
         BorderStyle     =   0  'None
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
         Left            =   9480
         Locked          =   -1  'True
         TabIndex        =   26
         Text            =   "Tipo de Pago"
         Top             =   360
         Visible         =   0   'False
         Width           =   2655
      End
      Begin VB.TextBox Txt12 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   3600
         TabIndex        =   13
         Text            =   "Documento"
         Top             =   360
         Width           =   855
      End
      Begin VB.TextBox Text5 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   240
         Locked          =   -1  'True
         TabIndex        =   12
         Text            =   "Cedis"
         Top             =   360
         Width           =   615
      End
      Begin VB.TextBox TxtCedis 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   840
         Locked          =   -1  'True
         TabIndex        =   11
         Top             =   360
         Width           =   2655
      End
      Begin VB.TextBox TxtDocumentos 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   4560
         Locked          =   -1  'True
         TabIndex        =   10
         Top             =   360
         Width           =   2775
      End
      Begin VB.TextBox TxtFecha 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   8040
         Locked          =   -1  'True
         TabIndex        =   9
         Top             =   360
         Width           =   1095
      End
      Begin VB.TextBox Text2 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   7440
         Locked          =   -1  'True
         TabIndex        =   8
         Text            =   "Fecha"
         Top             =   360
         Width           =   495
      End
   End
End
Attribute VB_Name = "CC_SaldarFacturas"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public IdCedis, IdMovimiento, IdDocumento, IdTipoDocumento, CargoAbono, Fecha, Aplicado As Boolean
Dim LstDPartidas, LstDClientes, StrIdClientes

Sub MuestraDetalleSaldos()
On Error Resume Next
    StrCmd = "execute sel_MovimientosFacturas " & IdCedis & ", " & IdMovimiento & ", '" & IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy")) & "', '" & IdDocumento & "', 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    If Not Rep Then LstDPartidas = GetDataLVL(RsC, LstPartidas, 1, 9, "0|0|1|3|3|3|3|3|0")
End Sub

Sub MuestraTotalesSaldos()
On Error Resume Next
    StrCmd = "execute sel_MovimientosFacturas " & IdCedis & ", " & IdMovimiento & ", '" & IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy")) & "', '" & IdDocumento & "', 2"
    If RsC.State Then RsC.Close
    If Not Rep Then
        RsC.Open StrCmd, Cnn
        LblSubtotal.Caption = FormatCurrency(RsC.Fields(0), 2, vbTrue)
        LblIva.Caption = FormatCurrency(RsC.Fields(1), 2, vbTrue)
        LblTotal.Caption = FormatCurrency(RsC.Fields(2), 2, vbTrue)
    End If
End Sub

Private Sub BtnDelete_Click()
On Error GoTo Err_btnDelete:
    
    If MsgBox("¿ Está seguro que deseas Eliminar el Movimiento seleccionado ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    MousePointer = 11
    
    StrCmd = "execute up_MovimientosFacturas " & IdCedis & ", " & CLng(LstDPartidas(11, LstPartidas.SelectedItem.Index - 1)) & ", '" & Trim(LstPartidas.SelectedItem.ListSubItems(1)) & "', " & CLng(LstPartidas.SelectedItem.ListSubItems(2)) & ", " & IdMovimiento & ", '01/01/1900', " & CLng(LstDPartidas(10, LstPartidas.SelectedItem.Index - 1)) & ", '', '', '', 0, 0, '', '" & Usuario & "', 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MuestraDetalleSaldos
    MuestraTotalesSaldos
    
No_Err_btnDelete:
    MousePointer = 0
    Exit Sub
    
Err_btnDelete:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_btnDelete:
End Sub

Private Sub btnSaldar_Click()
On Error GoTo Err_btnSaldar_Click:

Dim ConteoRegistrosChecados

ConteoRegistrosChecados = 0: StrIdClientes = ""

    If Aplicado Then
        MsgBox "¡ Documento Aplicado. No se puede modificar !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    If MsgBox("Una vez iniciado el proceso, las Notas de Crédito se aplicarán en automático. ¿ Estás seguro que deseas continuar ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
        If MsgBox("No habrá forma de cancelar las Notas de Crédito. ¿ Estás seguro que deseas continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    End If
    
    For i = 1 To LstClientes.ListItems.Count
        If LstClientes.ListItems(i).Checked Then
            ConteoRegistrosChecados = ConteoRegistrosChecados + 1
            StrIdClientes = StrIdClientes & LstClientes.ListItems(i) & ", "
        End If
    Next

    If ConteoRegistrosChecados = 0 Then
        MsgBox "¡ Seleccione los clientes que desea saldar !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    Else
        StrIdClientes = " and Ventas.IdCliente in ( " & Mid(StrIdClientes, 1, Len(StrIdClientes) - 2) & " ) "
    End If
    
    If Trim(TxtMontoInicial.Text) = "" Or Trim(TxtMontoFinal.Text) = "" Then
        MsgBox "¡ Teclee los montos de las facturas a saldar !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If (CDbl(TxtMontoInicial.Text) > CDbl(TxtMontoFinal.Text)) Or CDbl(TxtMontoFinal.Text) = 0 Then
        MsgBox "¡ El monto inicial debe ser menor que el monto final !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    StrCmd = "execute up_SaldaFacturas " & IdCedis & ", " & IdMovimiento & ", '" & IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy")) & "', '" & IdDocumento & "', '" & IdTipoDocumento & "', 'A', '" & DTPFechaInicial.Value & "', '" & DTPFechaFinal.Value & "', " & TxtMontoInicial.Text & ", " & TxtMontoFinal.Text & ", '" & StrIdClientes & "', '" & Usuario & "'"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn

    Aplicado = True
    MuestraDetalleSaldos
    MuestraTotalesSaldos
    
No_Err_btnSaldar_Click:
    MousePointer = 0
    MsgBox "¡ Proceso terminado !", vbInformation + vbOKOnly, App.Title
    Exit Sub
    
Err_btnSaldar_Click:
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_btnSaldar_Click:

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

Private Sub Form_Activate()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    MuestraDetalleSaldos
    MuestraTotalesSaldos
    BuscaClientes
End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    CC_Movimientos.MuestraMovimientos
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

Private Sub LstPartidas_DblClick()
On Error Resume Next
    If IsEmpty(LstDPartidas) Then Exit Sub
    DetalleDeFactura IdCedis, LstDPartidas(11, LstPartidas.SelectedItem.Index - 1), LstDPartidas(2, LstPartidas.SelectedItem.Index - 1), LstDPartidas(3, LstPartidas.SelectedItem.Index - 1), Me.Top, Me.Left, Me.Width, Me.Height, 0
End Sub

Private Sub TxtMontoFinal_GotFocus()
On Error Resume Next
    SelText TxtMontoFinal
End Sub

Private Sub TxtMontoFinal_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itDecimal(KeyAscii)
End Sub

Private Sub TxtMontoFinal_Validate(Cancel As Boolean)
On Error Resume Next
    TxtMontoFinal.Text = itFlotante(Trim(TxtMontoFinal.Text))
End Sub

Private Sub TxtMontoInicial_GotFocus()
On Error Resume Next
    SelText TxtMontoInicial
End Sub

Private Sub TxtMontoInicial_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itDecimal(KeyAscii)
End Sub

Private Sub TxtMontoInicial_Validate(Cancel As Boolean)
On Error Resume Next
    TxtMontoInicial.Text = itFlotante(Trim(TxtMontoInicial.Text))
End Sub

Private Sub BuscaClientes()
On Error Resume Next
    StrCmd = "execute sel_ClientesFacturas " & IdCedis & ", 0, '', '', 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDClientes = GetDataLVL(RsC, LstClientes, 1, 3, "0|0|0")
End Sub
