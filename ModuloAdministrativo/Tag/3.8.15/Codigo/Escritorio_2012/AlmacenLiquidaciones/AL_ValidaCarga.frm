VERSION 5.00
Begin VB.Form AL_ValidaCarga 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Validación de Saldo"
   ClientHeight    =   6480
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   6930
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
   ScaleHeight     =   6480
   ScaleWidth      =   6930
   ShowInTaskbar   =   0   'False
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
      Height          =   5055
      Left            =   120
      TabIndex        =   18
      Top             =   1320
      Width           =   6735
      Begin VB.CommandButton btnCalcularSaldo 
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
         Left            =   3840
         Picture         =   "AL_ValidaCarga.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   29
         Top             =   360
         Width           =   495
      End
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
         Left            =   4800
         Picture         =   "AL_ValidaCarga.frx":02CC
         Style           =   1  'Graphical
         TabIndex        =   9
         Top             =   4440
         Width           =   1695
      End
      Begin VB.TextBox TxtObservaciones 
         Height          =   735
         Left            =   120
         TabIndex        =   7
         Top             =   4080
         Width           =   4575
      End
      Begin VB.TextBox TxtResultado 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   2280
         Locked          =   -1  'True
         TabIndex        =   6
         Top             =   3240
         Width           =   1400
      End
      Begin VB.TextBox TxtSaldo 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   2280
         Locked          =   -1  'True
         TabIndex        =   0
         Top             =   360
         Width           =   1400
      End
      Begin VB.TextBox TxtFinanciado 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   2280
         Locked          =   -1  'True
         TabIndex        =   1
         Top             =   840
         Width           =   1400
      End
      Begin VB.TextBox TxtVencido 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   2280
         Locked          =   -1  'True
         TabIndex        =   2
         Top             =   1320
         Width           =   1400
      End
      Begin VB.TextBox TxtCreditos 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   2280
         TabIndex        =   3
         Top             =   1800
         Width           =   1400
      End
      Begin VB.TextBox TxtBolsa 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   2280
         TabIndex        =   4
         Top             =   2280
         Width           =   1400
      End
      Begin VB.TextBox TxtAjuste 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   2280
         TabIndex        =   5
         Top             =   2760
         Width           =   1400
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
         Left            =   4800
         Picture         =   "AL_ValidaCarga.frx":09E7
         Style           =   1  'Graphical
         TabIndex        =   8
         Top             =   3840
         Width           =   1695
      End
      Begin VB.Label Label6 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Observaciones"
         Height          =   255
         Left            =   240
         TabIndex        =   27
         Top             =   3840
         Width           =   1335
      End
      Begin VB.Label Label3 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Resultado"
         Height          =   255
         Left            =   240
         TabIndex        =   26
         Top             =   3360
         Width           =   1815
      End
      Begin VB.Label Label13 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Saldo"
         Height          =   255
         Left            =   240
         TabIndex        =   25
         Top             =   480
         Width           =   1815
      End
      Begin VB.Label Label12 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Financiamiento"
         Height          =   255
         Left            =   240
         TabIndex        =   24
         Top             =   960
         Width           =   1815
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Saldo Vencido"
         Height          =   255
         Left            =   240
         TabIndex        =   23
         Top             =   1440
         Width           =   1815
      End
      Begin VB.Label Label2 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Créditos Informales"
         Height          =   255
         Left            =   240
         TabIndex        =   22
         Top             =   1920
         Width           =   1815
      End
      Begin VB.Label Label4 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Ajuste"
         Height          =   255
         Left            =   240
         TabIndex        =   21
         Top             =   2880
         Width           =   1815
      End
      Begin VB.Label Label5 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00FFFFFF&
         Caption         =   "Bolsa"
         Height          =   255
         Left            =   240
         TabIndex        =   20
         Top             =   2400
         Width           =   1815
      End
      Begin VB.Label LblCarga 
         AutoSize        =   -1  'True
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
         ForeColor       =   &H00000080&
         Height          =   225
         Left            =   3840
         TabIndex        =   19
         Top             =   3240
         Width           =   45
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
      Width           =   6735
      Begin VB.TextBox Text9 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         Locked          =   -1  'True
         TabIndex        =   17
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
         Left            =   1215
         Locked          =   -1  'True
         TabIndex        =   16
         Top             =   750
         Width           =   3840
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
      Begin VB.Label LblUsuario 
         AutoSize        =   -1  'True
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
         ForeColor       =   &H00000080&
         Height          =   210
         Left            =   5160
         TabIndex        =   28
         Top             =   750
         Width           =   1005
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
      Picture         =   "AL_ValidaCarga.frx":137D
      Style           =   1  'Graphical
      TabIndex        =   10
      Top             =   8640
      Width           =   1455
   End
End
Attribute VB_Name = "AL_ValidaCarga"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public IdSurtidoC As Long, IdVendedor, FechaC As Date, IdSurtidoVC
Dim SaldoVencido, Resultado

Private Sub btnActualizaVenta_Click()
On Error Resume Next
    
    If IdSurtidoVC <> IdSurtidoC Then
        MsgBox "¡ No puedes Modificar una Validación de Saldo ya ha sido Registrada !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
'    StrCmd = "execute sel_VendedoresSaldosFinancia " & IdCedis & ", " & IdSurtidoC & ", " & IdVendedor & ", 5"
'    If Rs.State Then Rs.Close
'    Rs.Open StrCmd, Cnn
'    If Rs.EOF Then
'        MsgBox "¡ No puedes Validar el Saldo del Vendedor porque no se han registrado Ventas en su Liquidación !", vbInformation + vbOKOnly, App.Title
'        Exit Sub
'    End If
    
    If Trim(TxtCreditos.Text) = "" Or Trim(TxtBolsa.Text) = "" Or Trim(TxtAjuste.Text) = "" Then
        MsgBox "¡ Debes teclear todos los datos !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    StrCmd = "execute up_VendedoresSaldosValida " & IdCedis & ", " & IdSurtidoC & ", " & IdVendedor & ", '" & FormatDate(Fecha) & "', " & CDbl(TxtCreditos.Text) & ", " & CDbl(TxtBolsa.Text) & ", " & CDbl(TxtAjuste.Text) & ", " & CDbl(TxtResultado.Text) & ", '" & Trim(TxtObservaciones.Text) & "', '" & Usuario & "', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MuestraDatosValidaCarga

    StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", " & IdSurtidoC & ", 0, 0, 0, '', " & IdSurtidoC & ", '" & _
    FormatDate(Fecha) & "', " & IdRuta & ", 0, '', 0, 'Actualizar', 'Validación de Carga, Liquidación " & IdSurtidoC & ". IdVendedor " & IdVendedor & ", Fecha " & Fecha & ", Créditos " & TxtCreditos.Text & ", Bolsa " & Trim(TxtAjuste.Text) & ", Resultado " & TxtResultado.Text & ", Observaciones " & Trim(TxtObservaciones.Text) & "', 7"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn

    MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title

End Sub

Private Sub btnCalcularSaldo_Click()
On Error Resume Next

If IdSurtidoVC <> IdSurtidoC Then
    If MsgBox("¿ Estás seguro que deseas Modificar una Validación de Saldo que ya ha sido Registrada ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
End If

If MsgBox("¿ Deseas recuperar el Saldo Actual del Vendedor ?. ¡ El resultado de la Validación puede Cambiar !", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub

StrCmd = "execute up_VendedoresSaldosValida " & IdCedis & ", " & IdSurtidoC & ", " & IdVendedor & ", '" & FormatDate(Fecha) & "', 0,0,0,0, '', '" & Usuario & "', 3"
If Rs.State Then Rs.Close
Rs.Open StrCmd, Cnn

MuestraDatosValidaCarga

StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", " & IdSurtidoC & ", 0, 0, 0, '', " & IdSurtidoC & ", '" & _
FormatDate(Fecha) & "', " & IdRuta & ", 0, '', 0, 'Actualizar', 'Validación de Carga. Actualizando Saldos, Liquidación " & IdSurtidoC & ". IdVendedor " & IdVendedor & ", Fecha " & Fecha & ", Créditos " & TxtCreditos.Text & ", Bolsa " & Trim(TxtAjuste.Text) & ", Resultado " & TxtResultado.Text & ", Observaciones " & Trim(TxtObservaciones.Text) & "', 7"
If Rs.State Then Rs.Close
Rs.Open StrCmd, Cnn

MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title

End Sub

Private Sub btnImprimirVenta_Click()
On Error Resume Next
    
'    StrCmd = "execute sel_VendedoresSaldosFinancia " & IdCedis & ", " & IdSurtidoC & ", " & IdVendedor & ", 5"
'    If Rs.State Then Rs.Close
'    Rs.Open StrCmd, Cnn
'    If Rs.EOF Then
'        MsgBox "¡ No puedes Imprimir una Validación del Saldo del Vendedor porque no se han registrado Ventas en su Liquidación !", vbInformation + vbOKOnly, App.Title
'        Exit Sub
'    End If
    
    StrCmd = "execute sel_VendedoresSaldosFinancia " & IdCedis & ", " & IdSurtidoC & ", " & IdVendedor & ", 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        With AL_RptSaldosValida
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

Private Sub Form_Activate()
On Error Resume Next
    MuestraDatosValidaCarga
End Sub

Sub MuestraDatosValidaCarga()
On Error Resume Next

    StrCmd = "execute sel_VendedoresSaldosFinancia " & IdCedis & ", " & IdSurtidoC & ", " & IdVendedor & ", 2 "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Rs.EOF Then
        If IdSurtidoVC <> IdSurtidoC Then
            If MsgBox("¿ Estás seguro que deseas Modificar una Validación de Saldo que ya ha sido Registrada ?", vbQuestion + vbYesNo, App.Title) = vbYes Then GoTo Actualiza_Validacion:
        Else
Actualiza_Validacion:
            StrCmd = "execute up_VendedoresSaldosValida " & IdCedis & ", " & IdSurtidoC & ", " & IdVendedor & ", '" & FormatDate(Fecha) & "', 0,0,0,0, '', '" & Usuario & "', 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
        End If
    End If
    
    StrCmd = "execute sel_VendedoresSaldosFinancia " & IdCedis & ", " & IdSurtidoC & ", " & IdVendedor & ", 2 "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        TxtSaldo.Text = FormatNumber(Rs.Fields(3), 2, vbTrue)
        TxtFinanciado.Text = FormatNumber(Rs.Fields(4), 2, vbTrue)
        TxtVencido.Text = FormatNumber(Rs.Fields(5), 2, vbTrue)
        SaldoVencido = FormatNumber(Rs.Fields(5), 2, vbTrue)
        TxtCreditos.Text = FormatNumber(Rs.Fields(6), 2, vbTrue)
        TxtBolsa.Text = FormatNumber(Rs.Fields(7), 2, vbTrue)
        TxtAjuste.Text = FormatNumber(Rs.Fields(8), 2, vbTrue)
        TxtResultado.Text = FormatNumber(Rs.Fields(9), 2, vbTrue)
        TxtObservaciones.Text = Rs.Fields(10)
        LblUsuario.Caption = "Usuario: " & Rs.Fields(11)
        CalculaResultado
    End If
    
    TxtCreditos.SetFocus
End Sub

Private Sub TxtAjuste_Change()
On Error Resume Next
    CalculaResultado
End Sub

Private Sub TxtAjuste_GotFocus()
On Error Resume Next
    SelText TxtAjuste
End Sub

Private Sub TxtAjuste_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itDecimal(KeyAscii)
End Sub

Private Sub TxtAjuste_Validate(Cancel As Boolean)
On Error Resume Next
    TxtAjuste.Text = itFlotante(TxtAjuste.Text)
End Sub

Private Sub TxtBolsa_Change()
On Error Resume Next
    CalculaResultado
End Sub

Private Sub TxtBolsa_GotFocus()
On Error Resume Next
    SelText TxtBolsa
End Sub

Private Sub TxtBolsa_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itDecimal(KeyAscii)
End Sub

Private Sub TxtBolsa_Validate(Cancel As Boolean)
On Error Resume Next
    TxtBolsa.Text = itFlotante(TxtBolsa.Text)
End Sub

Private Sub TxtCreditos_Change()
On Error Resume Next
    CalculaResultado
End Sub

Private Sub TxtCreditos_GotFocus()
On Error Resume Next
    SelText TxtCreditos
End Sub

Private Sub TxtCreditos_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itDecimal(KeyAscii)
End Sub

Private Sub TxtCreditos_Validate(Cancel As Boolean)
On Error Resume Next
    TxtCreditos.Text = itFlotante(TxtCreditos.Text)
End Sub

Sub CalculaResultado()
On Error Resume Next
    Resultado = SaldoVencido + CDbl(TxtCreditos.Text) + CDbl(TxtBolsa.Text) + CDbl(TxtAjuste.Text)
    TxtResultado.Text = FormatNumber(Resultado, 2, vbTrue)
    LblCarga.Caption = IIf(Round(Resultado, 2) >= 0, "SI CARGA", "NO CARGA")
End Sub

Private Sub TxtObservaciones_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        btnActualizaVenta_Click
        Exit Sub
    End If
    KeyAscii = itString(KeyAscii)
End Sub

