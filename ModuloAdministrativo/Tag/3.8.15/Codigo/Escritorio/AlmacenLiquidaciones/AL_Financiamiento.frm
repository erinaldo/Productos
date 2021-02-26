VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "Mscomctl.ocx"
Begin VB.Form AL_Financiamiento 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Financiamiento de Saldos"
   ClientHeight    =   7845
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   9780
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
   ScaleHeight     =   7845
   ScaleWidth      =   9780
   ShowInTaskbar   =   0   'False
   Begin VB.Frame Frame3 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Selecciona un Folio"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   6495
      Left            =   120
      TabIndex        =   16
      Top             =   1320
      Width           =   9615
      Begin VB.CommandButton btnImprimirVenta 
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
         Left            =   7800
         Picture         =   "AL_Financiamiento.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   2
         Top             =   1680
         Width           =   1695
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
         Height          =   3495
         Left            =   120
         TabIndex        =   18
         Top             =   2880
         Width           =   9375
         Begin VB.TextBox TxtNoVencido 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   1680
            Locked          =   -1  'True
            TabIndex        =   32
            Top             =   480
            Width           =   1455
         End
         Begin VB.TextBox TxtSaldoActual 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   120
            Locked          =   -1  'True
            TabIndex        =   30
            Top             =   480
            Width           =   1455
         End
         Begin VB.CommandButton btnActualizaVenta 
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
            Left            =   6960
            Picture         =   "AL_Financiamiento.frx":071B
            Style           =   1  'Graphical
            TabIndex        =   9
            Top             =   2880
            Width           =   1695
         End
         Begin VB.TextBox TxtAutoriza 
            Height          =   375
            Left            =   120
            TabIndex        =   8
            Top             =   3000
            Width           =   6615
         End
         Begin VB.TextBox TxtConcepto 
            Height          =   375
            Left            =   120
            TabIndex        =   7
            Top             =   2280
            Width           =   8655
         End
         Begin VB.TextBox TxtFrecuencia 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   3240
            TabIndex        =   5
            Top             =   1200
            Width           =   1095
         End
         Begin VB.TextBox TxtPagos 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   1920
            TabIndex        =   4
            Top             =   1200
            Width           =   1215
         End
         Begin VB.TextBox TxtMonto 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   120
            TabIndex        =   3
            Top             =   1200
            Width           =   1695
         End
         Begin VB.TextBox TxtSaldo 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   3240
            Locked          =   -1  'True
            TabIndex        =   19
            Top             =   480
            Width           =   1815
         End
         Begin MSComCtl2.DTPicker DTPFecha 
            Height          =   375
            Left            =   4440
            TabIndex        =   6
            Top             =   1200
            Width           =   3735
            _ExtentX        =   6588
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
            Format          =   108265472
            CurrentDate     =   39376
         End
         Begin VB.Label Label7 
            BackColor       =   &H00FFFFFF&
            Caption         =   "No Vencido"
            Height          =   255
            Left            =   1680
            TabIndex        =   33
            Top             =   240
            Width           =   1095
         End
         Begin VB.Label Label6 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Saldo Actual"
            Height          =   255
            Left            =   120
            TabIndex        =   31
            Top             =   240
            Width           =   1215
         End
         Begin VB.Label LblPagos 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Pagos"
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
            Height          =   240
            Left            =   240
            TabIndex        =   29
            Top             =   1680
            Width           =   585
         End
         Begin VB.Label Label5 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Concepto"
            Height          =   255
            Left            =   120
            TabIndex        =   26
            Top             =   2040
            Width           =   855
         End
         Begin VB.Label Label4 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Autoriza"
            Height          =   255
            Left            =   120
            TabIndex        =   25
            Top             =   2760
            Width           =   855
         End
         Begin VB.Label Label3 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Fecha"
            Height          =   255
            Left            =   4560
            TabIndex        =   24
            Top             =   960
            Width           =   615
         End
         Begin VB.Label Label2 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Frecuencia"
            Height          =   255
            Left            =   3360
            TabIndex        =   23
            Top             =   960
            Width           =   975
         End
         Begin VB.Label Label1 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Pago"
            Height          =   255
            Left            =   2040
            TabIndex        =   22
            Top             =   960
            Width           =   1095
         End
         Begin VB.Label Label12 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Monto Financiado"
            Height          =   255
            Left            =   120
            TabIndex        =   21
            Top             =   960
            Width           =   1575
         End
         Begin VB.Label Label13 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Saldo para Financiar"
            Height          =   255
            Left            =   3240
            TabIndex        =   20
            Top             =   240
            Width           =   1815
         End
      End
      Begin VB.CommandButton btnNueva 
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
         Left            =   7800
         Picture         =   "AL_Financiamiento.frx":10B1
         Style           =   1  'Graphical
         TabIndex        =   0
         Top             =   480
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
         Left            =   7800
         Picture         =   "AL_Financiamiento.frx":173F
         Style           =   1  'Graphical
         TabIndex        =   1
         Top             =   1080
         Width           =   1695
      End
      Begin MSComctlLib.ListView LstFoliosCortos 
         Height          =   2535
         Left            =   120
         TabIndex        =   17
         Top             =   360
         Width           =   7575
         _ExtentX        =   13361
         _ExtentY        =   4471
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
   End
   Begin VB.Frame Frame2 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Datos de la Liquidación"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1095
      Left            =   120
      TabIndex        =   11
      Top             =   120
      Width           =   7335
      Begin VB.TextBox Text9 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         Locked          =   -1  'True
         TabIndex        =   28
         Text            =   "Vendedor"
         Top             =   720
         Width           =   915
      End
      Begin VB.TextBox TxtVendedor 
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
         Left            =   1095
         Locked          =   -1  'True
         TabIndex        =   27
         Top             =   750
         Width           =   6015
      End
      Begin VB.TextBox TxtLiquidacion 
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
         Left            =   1560
         Locked          =   -1  'True
         TabIndex        =   15
         Top             =   390
         Width           =   1335
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
         Left            =   3840
         Locked          =   -1  'True
         TabIndex        =   14
         Top             =   390
         Width           =   1815
      End
      Begin VB.TextBox Text2 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   105
         Locked          =   -1  'True
         TabIndex        =   13
         Text            =   "No. Liquidación"
         Top             =   360
         Width           =   1400
      End
      Begin VB.TextBox Text4 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   3120
         Locked          =   -1  'True
         TabIndex        =   12
         Text            =   "Fecha"
         Top             =   360
         Width           =   555
      End
   End
   Begin VB.CommandButton btnSalir 
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
      Height          =   425
      Left            =   600
      Picture         =   "AL_Financiamiento.frx":1E4F
      Style           =   1  'Graphical
      TabIndex        =   10
      Top             =   8640
      Width           =   1455
   End
End
Attribute VB_Name = "AL_Financiamiento"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public IdSurtidoC As Long, IdVendedor, LstDFoliosCorto, FechaC As Date
Dim IdCorto As Long, LimiteFinanciar, Actualizar As Boolean

Private Sub btnActualizaVenta_Click()
On Error Resume Next
    
    If Not ValidaModulo("VENSALFINA", True) Then Exit Sub
    
'    StrCmd = "execute sel_VendedoresSaldos2 " & IdCedis & ", " & IdVendedor & ", '19000101', 'EF', 1"
'    If Rs.State Then Rs.Close
'    Rs.Open StrCmd, Cnn
'    If Not Rs.EOF Then
'        If CDate(FechaC) < CDate(Rs.Fields(2)) Then
'            MsgBox "¡ Sólo se puede Aplicar un Financiamiento sobre el último Saldo registrado !", vbInformation + vbOKOnly, App.Title
'            Exit Sub
'        End If
'    End If
    
    If Trim(TxtPagos.Text) = "" Or Trim(TxtFrecuencia.Text) = "" Or Trim(TxtConcepto.Text) = "" Or Trim(TxtAutoriza.Text) = "" Or Trim(TxtMonto.Text) = "" Then
        MsgBox "¡ Debes teclear todos los datos del Financiamiento !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If CDbl(TxtPagos.Text) = "0" Or CDbl(TxtFrecuencia.Text) = "0" Or CDbl(TxtMonto.Text) = "0" Then
        MsgBox "¡ Debes teclear el importe a Financiar, el número de Pagos y la Frecuencia de los mismos !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    StrCmd = "execute up_VendedoresSaldosFinancia " & IdCedis & ", " & IdCorto & ", " & IdSurtidoC & ", " & IdVendedor & ", " & TxtMonto.Text & ", " & TxtPagos.Text & ", " & TxtFrecuencia.Text & ", '" & FormatDate(DTPFecha.Value) & "', '" & Trim(TxtAutoriza.Text) & "', '" & Trim(TxtConcepto.Text) & "', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    StrCmd = "execute up_VendedoresSaldosFinancia " & IdCedis & ", " & IdCorto & ", " & IdSurtidoC & ", " & IdVendedor & ", 0, 0, 0, '19000101', '', '', 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    Dim i As Date, j As Integer
    
    i = CDate(DTPFecha.Value)
    
    Dim Restante, Pagos

    If CDbl(TxtPagos.Text) > 0 And CDbl(TxtMonto.Text) > 0 Then
        Pagos = 0: Restante = CDbl(TxtMonto.Text): j = 0
        While Restante > CDbl(TxtPagos.Text)
            Pagos = Pagos + 1
            Restante = Restante - CDbl(TxtPagos.Text)
            j = j + 1
            StrCmd = "execute up_VendedoresSaldosFinancia " & IdCedis & ", " & IdCorto & ", " & IdSurtidoC & ", " & IdVendedor & ", " & CDbl(TxtPagos.Text) & ", " & j & ", 0, '" & FormatDate(i) & "', '', '', 5"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            i = i + (CDbl(TxtFrecuencia.Text))
        Wend
        If Restante > 0 Then
            j = j + 1
            StrCmd = "execute up_VendedoresSaldosFinancia " & IdCedis & ", " & IdCorto & ", " & IdSurtidoC & ", " & IdVendedor & ", " & CDbl(Restante) & ", " & j & ", 0, '" & FormatDate(i) & "', '', '', 5"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
        End If
    End If
    
    StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", " & IdSurtidoC & ", 0, 0, 0, '', " & LstDFoliosCorto(4, LstFoliosCortos.SelectedItem.Index - 1) & ", '" & _
    FormatDate(Fecha) & "', " & IdRuta & ", 0, '', 0, 'ActualizarFIN', 'Financiamiento de Saldo, Liquidación " & IdSurtidoC & ". IdVendedor " & IdVendedor & ", Folio " & LstDFoliosCorto(4, LstFoliosCortos.SelectedItem.Index - 1) & ", Monto a Financiar " & TxtMonto.Text & ", Pagos " & TxtPagos.Text & ", Frecuencia " & TxtFrecuencia.Text & ", Fecha " & FormatDate(DTPFecha.Value) & ", Autoriza " & Trim(TxtAutoriza.Text) & ", Concepto " & Trim(TxtConcepto.Text) & "', 7"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MuestraFoliosCorto

    MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title
'    MuestraFoliosCorto

End Sub

Private Sub btnEliminar_Click()
On Error Resume Next

    If Not ValidaModulo("VENSALFINE", True) Then Exit Sub
    If IsEmpty(LstDFoliosCorto) Then Exit Sub

    If MsgBox("¿ Estás seguro que deseas Eliminar el registro seleccionado ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    StrCmd = "execute up_VendedoresSaldosFinancia " & IdCedis & ", " & IdCorto & ", " & IdSurtidoC & ", " & IdVendedor & ", 0, 0, 0, '19000101', '', '', 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn

    StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", " & IdSurtidoC & ", 0, 0, 0, '', " & LstDFoliosCorto(4, LstFoliosCortos.SelectedItem.Index - 1) & ", '" & _
    FormatDate(Fecha) & "', " & IdRuta & ", 0, '', 0, 'EliminarFIN', 'Financiamiento de Saldo, Liquidación " & IdSurtidoC & ". IdVendedor " & IdVendedor & ", Folio " & LstDFoliosCorto(4, LstFoliosCortos.SelectedItem.Index - 1) & "', 7"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MuestraFoliosCorto
End Sub

Private Sub btnImprimirVenta_Click()
On Error Resume Next
    
    If IsEmpty(LstDFoliosCorto) Then Exit Sub
    
    StrCmd = "execute sel_VendedoresSaldosFinancia " & IdCedis & ", " & IdCorto & ", " & IdVendedor & ", 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        With AL_RptSaldosFinancia
            .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
            .LblCedis.Caption = IdCedis & " - " & NomCedis
            .LblUsuario.Caption = "Usuario: " & Usuario
            .object.DataSrc.DataSourceName = Cnn
            .object.DataSrc.Recordset = Rs
            .Printer.Orientation = ddOPortrait
            .Printer.PaperSize = 1
            .Show vbModal
        End With
    End If
End Sub

Private Sub btnNueva_Click()
On Error Resume Next
Dim IdSurtidoSeleccionado
    
    If Not ValidaModulo("VENSALFINA", True) Then Exit Sub
    
    If LimiteFinanciar = 0 Then
        MsgBox "¡ No hay Saldo disponible para Financiar !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    IdSurtidoSeleccionado = 0
    IdSurtidoSeleccionado = LstDFoliosCorto(1, LstFoliosCortos.SelectedItem.Index - 1)
'    If IdSurtidoC = IdSurtidoSeleccionado Then
'        MsgBox "¡ Sólo puedes dar de alta un Financiamiento por cada Folio de Liquidación !", vbInformation + vbOKOnly, App.Title
'        Exit Sub
'    End If
'
'    StrCmd = "execute sel_VendedoresSaldos2 " & IdCedis & ", " & IdVendedor & ", '19000101', 'EF', 1"
'    If Rs.State Then Rs.Close
'    Rs.Open StrCmd, Cnn
'    If Not Rs.EOF Then
'        If CDate(FechaC) < CDate(Rs.Fields(2)) Then
'            MsgBox "¡ Sólo se puede Aplicar un Financiamiento sobre el último Saldo registrado !", vbInformation + vbOKOnly, App.Title
'            Exit Sub
'        End If
'    End If

    StrCmd = "execute up_VendedoresSaldosFinancia " & IdCedis & ", " & IdCorto & ", " & IdSurtidoC & ", " & IdVendedor & ", 0, 0, 0, '19000101', '', '', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn

    MuestraFoliosCorto

    StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", " & IdSurtidoC & ", 0, 0, 0, '', " & LstDFoliosCorto(4, UBound(LstDFoliosCorto, 2)) & ", '" & _
    FormatDate(Fecha) & "', " & IdRuta & ", 0, '', 0, 'InsertarFIN', 'Financiamiento de Saldo, Liquidación " & IdSurtidoC & ". IdVendedor " & IdVendedor & ", Fecha " & FechaC & ", Folio " & LstDFoliosCorto(4, LstFoliosCortos.SelectedItem.Index - 1) & "', 7"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn

End Sub

Private Sub Form_Activate()
On Error Resume Next
    MuestraFoliosCorto
End Sub

Private Sub Form_Load()
    IdCorto = 0
End Sub

Sub MuestraFoliosCorto()
On Error Resume Next
    StrCmd = "execute sel_VendedoresSaldosFinancia " & IdCedis & ", " & IdCorto & ", " & IdVendedor & ", 1 "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDFoliosCorto = GetDataLVL(Rs, LstFoliosCortos, 4, 9, "6|0|0|0|0|0")
    If Not IsEmpty(LstDFoliosCorto) Then LstFoliosCortos_ItemClick LstFoliosCortos.SelectedItem
    
    StrCmd = "execute sel_VendedoresSaldosFinancia " & IdCedis & ", 0, " & IdVendedor & ", 6"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        LimiteFinanciar = FormatNumber(Abs(Rs.Fields(2)), 2, vbTrue)
        TxtSaldoActual.Text = FormatNumber(Abs(Rs.Fields(0)), 2, vbTrue)
        TxtNoVencido.Text = FormatNumber(Abs(Rs.Fields(1)), 2, vbTrue)
        TxtSaldo.Text = FormatNumber(Abs(Rs.Fields(2)), 2, vbTrue)
    Else
        LimiteFinanciar = 0
        TxtSaldoActual.Text = "0.00"
        TxtNoVencido.Text = "0.00"
        TxtSaldo.Text = "0.00"
    End If
End Sub

Private Sub LstFoliosCortos_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    IdCorto = LstDFoliosCorto(4, LstFoliosCortos.SelectedItem.Index - 1)
'    TxtSaldoActual.Text = Abs(LstDFoliosCorto(7, LstFoliosCortos.SelectedItem.Index - 1))
'    TxtNoVencido.Text = Abs(LstDFoliosCorto(8, LstFoliosCortos.SelectedItem.Index - 1))
'    TxtSaldo.Text = IIf(Abs(LstDFoliosCorto(8, LstFoliosCortos.SelectedItem.Index - 1)) > Abs(LstDFoliosCorto(7, LstFoliosCortos.SelectedItem.Index - 1)), "0.00", Abs(LstDFoliosCorto(9, LstFoliosCortos.SelectedItem.Index - 1)))
'    If Abs(LstDFoliosCorto(8, LstFoliosCortos.SelectedItem.Index - 1)) > Abs(LstDFoliosCorto(7, LstFoliosCortos.SelectedItem.Index - 1)) Then
'        TxtMonto.Text = IIf(CDbl(LstDFoliosCorto(10, LstFoliosCortos.SelectedItem.Index - 1)) = 0, Abs(LstDFoliosCorto(9, LstFoliosCortos.SelectedItem.Index - 1)), Abs(LstDFoliosCorto(10, LstFoliosCortos.SelectedItem.Index - 1)))
'        LimiteFinanciar = 0
'    Else
'        TxtMonto.Text = IIf(CDbl(LstDFoliosCorto(10, LstFoliosCortos.SelectedItem.Index - 1)) = 0, Abs(LstDFoliosCorto(9, LstFoliosCortos.SelectedItem.Index - 1)), Abs(LstDFoliosCorto(10, LstFoliosCortos.SelectedItem.Index - 1)))
'        LimiteFinanciar = Abs(LstDFoliosCorto(9, LstFoliosCortos.SelectedItem.Index - 1))
'    End If
    TxtMonto.Text = IIf(CDbl(LstDFoliosCorto(7, LstFoliosCortos.SelectedItem.Index - 1)) = 0, LimiteFinanciar, LstDFoliosCorto(7, LstFoliosCortos.SelectedItem.Index - 1))
    TxtPagos.Text = LstDFoliosCorto(8, LstFoliosCortos.SelectedItem.Index - 1)
    TxtFrecuencia.Text = LstDFoliosCorto(9, LstFoliosCortos.SelectedItem.Index - 1)
    TxtAutoriza.Text = LstDFoliosCorto(11, LstFoliosCortos.SelectedItem.Index - 1)
    TxtConcepto.Text = LstDFoliosCorto(6, LstFoliosCortos.SelectedItem.Index - 1)
    If CDbl(LstDFoliosCorto(7, LstFoliosCortos.SelectedItem.Index - 1)) = 0 Then
        DTPFecha.Value = Date
    Else
        DTPFecha.Value = LstDFoliosCorto(10, LstFoliosCortos.SelectedItem.Index - 1)
    End If
    TxtMonto.SetFocus
    Actualizar = True
End Sub

Private Sub TxtAutoriza_GotFocus()
On Error Resume Next
    SelText TxtAutoriza
End Sub

Private Sub TxtAutoriza_KeyPress(KeyAscii As Integer)
On Error Resume Next
    
    If KeyAscii = "13" Then
        btnActualizaVenta_Click
        Exit Sub
    End If

    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtConcepto_GotFocus()
On Error Resume Next
    SelText TxtConcepto
End Sub

Private Sub TxtConcepto_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtFrecuencia_Change()
On Error Resume Next
    CalculaPagos
End Sub

Private Sub TxtFrecuencia_GotFocus()
On Error Resume Next
    SelText TxtFrecuencia
End Sub

Private Sub TxtFrecuencia_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtMonto_Change()
On Error Resume Next
    CalculaPagos
End Sub

Private Sub TxtMonto_GotFocus()
On Error Resume Next
    SelText TxtMonto
End Sub

Private Sub TxtMonto_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itDecimal(KeyAscii)
End Sub

Private Sub TxtMonto_Validate(Cancel As Boolean)
On Error Resume Next
    TxtMonto.Text = itFlotante(TxtMonto.Text)
    If Abs(CDbl(TxtMonto.Text)) > LimiteFinanciar Then TxtMonto.Text = LimiteFinanciar
End Sub

Private Sub TxtPagos_Change()
On Error Resume Next
    CalculaPagos
End Sub

Private Sub TxtPagos_GotFocus()
On Error Resume Next
    SelText TxtPagos
End Sub

Private Sub TxtPagos_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itDecimal(KeyAscii)
End Sub

Private Sub TxtPagos_Validate(Cancel As Boolean)
On Error Resume Next
    TxtPagos.Text = itFlotante(TxtPagos.Text)
End Sub

Sub CalculaPagos()
On Error Resume Next
Dim Restante, Pagos

If Trim(TxtPagos.Text) <> "" And Trim(TxtMonto.Text) <> "" Then
    If CDbl(TxtPagos.Text) > 0 And CDbl(TxtMonto.Text) > 0 Then
        Pagos = 0: Restante = CDbl(TxtMonto.Text)
        While Restante > CDbl(TxtPagos.Text)
            Pagos = Pagos + 1
            Restante = Restante - CDbl(TxtPagos.Text)
        Wend
        LblPagos.Caption = Pagos & " Pagos de " & CDbl(TxtPagos.Text) & IIf(Restante > 0, " y 1 Pago de " & FormatNumber(Restante, 2, vbTrue), "") & " cada " & TxtFrecuencia.Text & " días"
    Else
        LblPagos.Caption = "Debes teclear el Importe a Financiar, el Pago y la Frecuencia"
    End If
End If
End Sub
