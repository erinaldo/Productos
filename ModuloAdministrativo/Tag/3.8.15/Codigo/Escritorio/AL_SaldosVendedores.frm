VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form AL_SaldosVendedores 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Administración de Saldos de Vendedores"
   ClientHeight    =   7185
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   11040
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
   ScaleHeight     =   7185
   ScaleWidth      =   11040
   ShowInTaskbar   =   0   'False
   Begin VB.Frame Frame2 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Búsqueda de Vendedores y Saldos"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3855
      Left            =   120
      TabIndex        =   16
      Top             =   120
      Width           =   10815
      Begin VB.OptionButton OptCons 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Financiamiento"
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
         Left            =   8040
         TabIndex        =   5
         Top             =   600
         Width           =   2055
      End
      Begin VB.OptionButton OptCons 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Saldo del Vendedor"
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
         Index           =   0
         Left            =   8040
         TabIndex        =   4
         Top             =   360
         Value           =   -1  'True
         Width           =   2175
      End
      Begin VB.CommandButton btnValidar 
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
         Left            =   6240
         Picture         =   "AL_SaldosVendedores.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   3
         Top             =   360
         Width           =   1695
      End
      Begin VB.TextBox TxtSaldoAnterior 
         Alignment       =   1  'Right Justify
         Height          =   360
         Left            =   240
         Locked          =   -1  'True
         TabIndex        =   21
         Top             =   3360
         Width           =   1815
      End
      Begin VB.TextBox TxtSaldoActual 
         Alignment       =   1  'Right Justify
         Height          =   360
         Left            =   2160
         Locked          =   -1  'True
         TabIndex        =   20
         Top             =   3360
         Width           =   1815
      End
      Begin VB.TextBox TxtSaldoFinal 
         Alignment       =   1  'Right Justify
         Height          =   360
         Left            =   4080
         Locked          =   -1  'True
         TabIndex        =   19
         Top             =   3360
         Width           =   1815
      End
      Begin VB.TextBox TxtOtros 
         Alignment       =   1  'Right Justify
         Height          =   360
         Left            =   6000
         Locked          =   -1  'True
         TabIndex        =   18
         Top             =   3360
         Width           =   1815
      End
      Begin VB.TextBox TxtIdVendedor 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   240
         MaxLength       =   5
         TabIndex        =   0
         Top             =   600
         Width           =   735
      End
      Begin VB.TextBox TxtNombre 
         Height          =   375
         Left            =   1080
         TabIndex        =   1
         Top             =   600
         Width           =   2895
      End
      Begin VB.TextBox TxtNomina 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   4080
         MaxLength       =   8
         TabIndex        =   2
         Top             =   600
         Width           =   1095
      End
      Begin MSComctlLib.ListView LstVendedores 
         Height          =   1935
         Left            =   120
         TabIndex        =   11
         Top             =   1080
         Width           =   5175
         _ExtentX        =   9128
         _ExtentY        =   3413
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
      Begin MSComctlLib.ListView LstSaldos 
         Height          =   1935
         Left            =   5400
         TabIndex        =   12
         Top             =   1080
         Width           =   5295
         _ExtentX        =   9340
         _ExtentY        =   3413
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
      Begin VB.Label Label3 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Saldo Anterior"
         Height          =   255
         Left            =   360
         TabIndex        =   28
         Top             =   3120
         Width           =   1455
      End
      Begin VB.Label Label4 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Saldo Actual"
         Height          =   255
         Left            =   2280
         TabIndex        =   27
         Top             =   3120
         Width           =   1455
      End
      Begin VB.Label Label5 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Saldo Final"
         Height          =   255
         Left            =   4200
         TabIndex        =   26
         Top             =   3120
         Width           =   1455
      End
      Begin VB.Label Label8 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Otros"
         Height          =   255
         Left            =   6120
         TabIndex        =   25
         Top             =   3120
         Width           =   1455
      End
      Begin VB.Label LblNombre 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Nombre"
         Height          =   255
         Left            =   1080
         TabIndex        =   24
         Top             =   360
         Width           =   1335
      End
      Begin VB.Label LblIdVendedor 
         BackColor       =   &H00FFFFFF&
         Caption         =   "No."
         Height          =   255
         Left            =   240
         TabIndex        =   23
         Top             =   360
         Width           =   615
      End
      Begin VB.Label LblNomina 
         BackColor       =   &H00FFFFFF&
         Caption         =   "No. Nómina"
         Height          =   255
         Left            =   4080
         TabIndex        =   22
         Top             =   360
         Width           =   1095
      End
   End
   Begin VB.Frame Frame1 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Cargos y/o Abonos"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3135
      Left            =   120
      TabIndex        =   13
      Top             =   3960
      Width           =   10815
      Begin VB.ComboBox CmbCargoAbono 
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
         ItemData        =   "AL_SaldosVendedores.frx":0730
         Left            =   3000
         List            =   "AL_SaldosVendedores.frx":073A
         Style           =   2  'Dropdown List
         TabIndex        =   7
         Top             =   480
         Width           =   1455
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
         Left            =   9000
         Picture         =   "AL_SaldosVendedores.frx":074C
         Style           =   1  'Graphical
         TabIndex        =   10
         Top             =   360
         Width           =   1695
      End
      Begin VB.TextBox TxtImporte 
         Alignment       =   1  'Right Justify
         Height          =   360
         Left            =   4560
         TabIndex        =   8
         Top             =   480
         Width           =   1095
      End
      Begin VB.TextBox TxtObservaciones 
         Height          =   360
         Left            =   5760
         TabIndex        =   9
         Top             =   480
         Width           =   3135
      End
      Begin MSComctlLib.ListView LstCargosAbonos 
         Height          =   2070
         Left            =   120
         TabIndex        =   17
         Top             =   960
         Width           =   10575
         _ExtentX        =   18653
         _ExtentY        =   3651
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
      Begin MSComCtl2.DTPicker DTPFecha 
         Height          =   375
         Left            =   120
         TabIndex        =   6
         Top             =   480
         Width           =   2775
         _ExtentX        =   4895
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
         CustomFormat    =   "dddd dd MMM yyyy"
         Format          =   49938435
         CurrentDate     =   39376
      End
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Tipo"
         Height          =   255
         Left            =   3120
         TabIndex        =   30
         Top             =   240
         Width           =   855
      End
      Begin VB.Label Label1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Fecha"
         Height          =   255
         Left            =   240
         TabIndex        =   29
         Top             =   240
         Width           =   615
      End
      Begin VB.Label Label6 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Importe"
         Height          =   255
         Left            =   4680
         TabIndex        =   15
         Top             =   240
         Width           =   855
      End
      Begin VB.Label Label7 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Observaciones"
         Height          =   255
         Left            =   5880
         TabIndex        =   14
         Top             =   240
         Width           =   1335
      End
   End
End
Attribute VB_Name = "AL_SaldosVendedores"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDVendedores, LstDSaldos, LstDCargosAbonos

Private Sub btnImprimir_Click()
On Error Resume Next
    With AL_RptSaldosRecibo
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
        .LblCedis.Caption = IdCedis & " - " & NomCedis
        .LblUsuario.Caption = "Usuario: " & Usuario

        StrCmd = "execute sel_VendedoresSaldos2 " & IdCedis & ", " & LstVendedores.SelectedItem & ", '" & FormatDate(DTPFecha.Value) & "', 'EF', 5"
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

Private Sub btnValidar_Click()
On Error Resume Next
    
If IsEmpty(LstDSaldos) Then Exit Sub

If LstDSaldos(6, LstSaldos.SelectedItem.Index - 1) >= 0 And OptCons(1).Value Then
    MsgBox "¡ Sólo se pueden Financiar los Saldos Deudores del Vendedor !", vbInformation + vbOKOnly, App.Title
    Exit Sub
End If
    
If OptCons(0).Value Then

    If Not ValidaModulo("VENSALVAL", True) Then Exit Sub
    
    With AL_ValidaCarga
        .Left = AL_Liquidacion.Left + (AL_Liquidacion.Width - .Width) / 2
        .Top = AL_Liquidacion.Top + (AL_Liquidacion.Height - .Height) / 2
        .TxtLiquidacion.Text = LstDSaldos(7, LstSaldos.SelectedItem.Index - 1)
        .TxtVendedor.Text = LstVendedores.SelectedItem.ListSubItems(1).Text
        .TxtFecha = LstDSaldos(2, LstSaldos.SelectedItem.Index - 1)
                
        .IdSurtidoVC = LstDSaldos(7, 0)
        .IdSurtidoC = LstDSaldos(7, LstSaldos.SelectedItem.Index - 1)
        .FechaC = LstDSaldos(2, LstSaldos.SelectedItem.Index - 1)
        .IdVendedor = LstVendedores.SelectedItem
        .Show vbModal
    End With
Else
    With AL_Financiamiento
        .Left = AL_Liquidacion.Left + (AL_Liquidacion.Width - .Width) / 2
        .Top = AL_Liquidacion.Top + (AL_Liquidacion.Height - .Height) / 2
        .TxtLiquidacion.Text = LstDSaldos(7, LstSaldos.SelectedItem.Index - 1)
        .TxtVendedor.Text = LstVendedores.SelectedItem.ListSubItems(1).Text
        .TxtFecha = LstDSaldos(2, LstSaldos.SelectedItem.Index - 1)
        
        .IdVendedor = LstVendedores.SelectedItem
        .IdSurtidoC = LstDSaldos(7, LstSaldos.SelectedItem.Index - 1)
        .FechaC = LstDSaldos(2, LstSaldos.SelectedItem.Index - 1)
        .Show vbModal
    End With
End If

End Sub

Private Sub DTPFecha_Change()
On Error Resume Next

    StrCmd = "execute sel_VendedoresSaldos2 " & IdCedis & ", " & LstVendedores.SelectedItem & ", '" & FormatDate(DTPFecha.Value) & "', 'EF', 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCargosAbonos = GetDataLVL(Rs, LstCargosAbonos, 1, 3, "0|9|0")
End Sub

Private Sub Form_Load()
On Error Resume Next

    If ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then
        StrCmd = "execute up_SurtidosDenominacion " & IdCedis & ", " & IdSurtido & ", 0, '', '', 0, '', 0, 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
    End If

    DTPFecha.Value = Date
    CmbCargoAbono.Text = "Abono"
End Sub

Private Sub LstCargosAbonos_DblClick()
On Error Resume Next

    If Not ValidaModulo("VENSALCA", True) Then Exit Sub
    
    If IsEmpty(LstDCargosAbonos) Then Exit Sub
    
    If LstSaldos.SelectedItem.Index > 1 Then
        If MsgBox("¿ Estás seguro que deseas Actualizar el Saldo del Vendedor de Liquidaciones Anteriores ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    End If
    
    If MsgBox("¿ Deseas Eliminar el Movimiento del Saldo del Vendedor seleccionado ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    StrCmd = "execute up_VendedoresSaldos2 " & IdCedis & ", " & LstDCargosAbonos(0, LstCargosAbonos.SelectedItem.Index - 1) & ", " & LstVendedores.SelectedItem & ", '" & FormatDate(DTPFecha.Value) & "', 'EF', 0, '', " & LstDCargosAbonos(4, LstCargosAbonos.SelectedItem.Index - 1) & ", 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", " & IdSurtido & ", 0, 0, 0, '', " & LstDCargosAbonos(0, LstCargosAbonos.SelectedItem.Index - 1) & ", '" & _
    FormatDate(Fecha) & "', " & IdRuta & ", 0, '', 0, 'EliminarC/A', 'Ajuste de Saldos del Vendedor, IdVendedor " & LstVendedores.SelectedItem & ", Fecha " & LstDCargosAbonos(1, LstCargosAbonos.SelectedItem.Index - 1) & ", Cargo/Abono " & LstDCargosAbonos(2, LstCargosAbonos.SelectedItem.Index - 1) & "', 7"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    TxtImporte.Text = "": TxtObservaciones.Text = ""
    LstVendedores_ItemClick LstVendedores.SelectedItem
    
End Sub

Private Sub LstSaldos_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next

    TxtSaldoAnterior.Text = FormatCurrency(LstDSaldos(3, LstSaldos.SelectedItem.Index - 1), 2, vbTrue)
    TxtSaldoActual.Text = FormatCurrency(LstDSaldos(4, LstSaldos.SelectedItem.Index - 1), 2, vbTrue)
    TxtOtros.Text = FormatCurrency(LstDSaldos(5, LstSaldos.SelectedItem.Index - 1), 2, vbTrue)
    TxtSaldoFinal.Text = FormatCurrency(LstDSaldos(6, LstSaldos.SelectedItem.Index - 1), 2, vbTrue)
    DTPFecha.Value = CDate(LstDSaldos(2, LstSaldos.SelectedItem.Index - 1))
    DTPFecha_Change
End Sub

Private Sub LstVendedores_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next

    StrCmd = "execute sel_VendedoresSaldos2 " & IdCedis & ", " & LstVendedores.SelectedItem & ", '19000101', 'EF', 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    LstDSaldos = GetDataLVL(Rs, LstSaldos, 2, 6, "0|0|9|9|9")
    LstSaldos_ItemClick LstSaldos.SelectedItem
    TxtImporte.Text = "": TxtObservaciones.Text = ""
        
End Sub

Private Sub TxtImporte_GotFocus()
On Error Resume Next
    SelText TxtImporte
End Sub

Private Sub TxtImporte_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itDecimal(KeyAscii)
End Sub

Private Sub TxtImporte_Validate(Cancel As Boolean)
On Error Resume Next
    TxtImporte = itFlotante(TxtImporte.Text)
End Sub

Private Sub TxtObservaciones_GotFocus()
On Error Resume Next
    SelText TxtObservaciones
End Sub

Private Sub TxtObservaciones_KeyPress(KeyAscii As Integer)
On Error Resume Next

Dim Importe, IdSur

    If KeyAscii = 13 Then
    
        If Not ValidaModulo("VENSALCA", True) Then Exit Sub
    
        If IsEmpty(LstDSaldos) Then Exit Sub
        
        If CDbl(TxtImporte.Text) = 0 Then
            MsgBox "¡ Teclea el Importe y las Observaciones !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
    
        If Trim(TxtImporte.Text) = "" Or Trim(TxtObservaciones.Text) = "" Then
            MsgBox "¡ Teclea el Importe y las Observaciones !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
'        StrCmd = "execute sel_VendedoresSaldos2 " & IdCedis & ", " & LstVendedores.SelectedItem & ", '19000101', 'EF', 1"
'        If Rs.State Then Rs.Close
'        Rs.Open StrCmd, Cnn
'        If Not Rs.EOF Then
            If LstSaldos.SelectedItem.Index > 1 Then
                If MsgBox("¿ Estás seguro que deseas Actualizar el Saldo del Vendedor de Liquidaciones Anteriores ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
            End If
            
            Importe = IIf(Mid(CmbCargoAbono.Text, 1, 1) = "A", Abs(CDbl(TxtImporte.Text)), Abs(CDbl(TxtImporte.Text)) * -1)
            StrCmd = "execute up_VendedoresSaldos2 " & IdCedis & ", 0, " & LstVendedores.SelectedItem & ", '" & FormatDate(DTPFecha.Value) & "', 'EF', " & IIf(Mid(CmbCargoAbono.Text, 1, 1) = "A", Abs(CDbl(TxtImporte.Text)), Abs(CDbl(TxtImporte.Text)) * -1) & ", '" & Trim(TxtObservaciones.Text) & "', " & IIf(DTPFecha.Value > CDate(LstDSaldos(2, LstSaldos.SelectedItem.Index - 1)), 0, LstDSaldos(7, LstSaldos.SelectedItem.Index - 1)) & ", 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            LstVendedores_ItemClick LstVendedores.SelectedItem
            TxtImporte.Text = "": TxtObservaciones.Text = ""
            
            StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", 0, 0, 0, 0, '', " & LstDCargosAbonos(0, UBound(LstDCargosAbonos, 2)) & ", '" & _
            FormatDate(Fecha) & "', " & IdRuta & ", 0, '', 0, 'InsertarC/A', 'Ajuste de Saldos del Vendedor, IdVendedor " & LstVendedores.SelectedItem & ", Fecha " & DTPFecha.Value & ", Cargo/Abono " & Importe & ", Observaciones: " & Trim(TxtObservaciones.Text) & "', 7"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
'            End If
        End If
'    End If

    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtIdVendedor_Change()
On Error Resume Next
    BuscaVendedores
End Sub

Private Sub TxtIdVendedor_GotFocus()
On Error Resume Next
    SelText TxtIdVendedor
End Sub

Private Sub TxtIdVendedor_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtNombre_Change()
On Error Resume Next
    BuscaVendedores
End Sub

Private Sub TxtNombre_GotFocus()
On Error Resume Next
    SelText TxtNombre
End Sub

Private Sub TxtNombre_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtNomina_Change()
On Error Resume Next
    BuscaVendedores
End Sub

Private Sub TxtNomina_GotFocus()
On Error Resume Next
    SelText TxtNomina
End Sub

Private Sub TxtNomina_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Sub BuscaVendedores()
On Error Resume Next
    StrCmd = "execute sel_SurtidosNotInVendedores " & IdCedis & ", '" & FormatDate(Fecha) & "', '" & Trim(TxtIdVendedor.Text) & "', '" & Trim(TxtNombre.Text) & "', '" & Trim(TxtNomina.Text) & "', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDVendedores = GetDataLVL(Rs, LstVendedores, 0, 2, "0|0|0")
End Sub

