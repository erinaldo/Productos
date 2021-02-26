VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_FacturasOxxoDetalle 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Facturación de Oxxo"
   ClientHeight    =   7470
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   10440
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
   ScaleHeight     =   7470
   ScaleWidth      =   10440
   ShowInTaskbar   =   0   'False
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
      Height          =   6015
      Left            =   120
      TabIndex        =   11
      Top             =   0
      Width           =   10215
      Begin VB.CheckBox ChkTodos 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Seleccionar Todas"
         Height          =   255
         Left            =   240
         TabIndex        =   13
         Top             =   240
         Width           =   2295
      End
      Begin MSComctlLib.ListView LstFacturas 
         Height          =   5295
         Left            =   120
         TabIndex        =   12
         Top             =   600
         Width           =   9975
         _ExtentX        =   17595
         _ExtentY        =   9340
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
   Begin VB.CommandButton btnCancelar 
      BackColor       =   &H00FFFFFF&
      Cancel          =   -1  'True
      Height          =   495
      Left            =   4800
      Picture         =   "CC_FacturasOxxoDetalle.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   1
      Top             =   6720
      Width           =   1695
   End
   Begin VB.CommandButton btnSeleccionar 
      BackColor       =   &H00FFFFFF&
      Default         =   -1  'True
      Height          =   495
      Left            =   2760
      Picture         =   "CC_FacturasOxxoDetalle.frx":073B
      Style           =   1  'Graphical
      TabIndex        =   0
      Top             =   6720
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
      Height          =   1455
      Left            =   6960
      TabIndex        =   2
      Top             =   5880
      Width           =   3375
      Begin VB.Label LblTotal 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "$ 0.00"
         ForeColor       =   &H80000008&
         Height          =   345
         Left            =   1335
         TabIndex        =   8
         Top             =   960
         Width           =   1755
      End
      Begin VB.Label LblIva 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "$ 0.00"
         ForeColor       =   &H80000008&
         Height          =   345
         Left            =   1335
         TabIndex        =   7
         Top             =   600
         Width           =   1755
      End
      Begin VB.Label LblSubtotal 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "$ 0.00"
         ForeColor       =   &H80000008&
         Height          =   345
         Left            =   1335
         TabIndex        =   6
         Top             =   240
         Width           =   1755
      End
      Begin VB.Label Label4 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Total:"
         Height          =   240
         Left            =   510
         TabIndex        =   5
         Top             =   960
         Width           =   600
      End
      Begin VB.Label Label5 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Iva:"
         Height          =   240
         Left            =   660
         TabIndex        =   4
         Top             =   600
         Width           =   405
      End
      Begin VB.Label Label6 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Subtotal:"
         Height          =   240
         Left            =   195
         TabIndex        =   3
         Top             =   240
         Width           =   900
      End
   End
   Begin VB.Label LblNoFacturas 
      Alignment       =   1  'Right Justify
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "0"
      ForeColor       =   &H80000008&
      Height          =   345
      Left            =   4455
      TabIndex        =   10
      Top             =   6240
      Width           =   915
   End
   Begin VB.Label Label8 
      Alignment       =   1  'Right Justify
      AutoSize        =   -1  'True
      BackColor       =   &H00FFFFFF&
      Caption         =   "Facturas"
      Height          =   240
      Left            =   3480
      TabIndex        =   9
      Top             =   6240
      Width           =   885
   End
End
Attribute VB_Name = "CC_FacturasOxxoDetalle"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public IdCedisOX, IdTipoVentaOX, FolioOX, SerieOX
'Dim LstDFacturas

Private Sub btnCancelar_Click()
On Error Resume Next
    LstDFacturasSeleccionadas = Empty
    Unload Me
End Sub

Private Sub btnSeleccionar_Click()
On Error Resume Next
Dim Encabezado

    If MsgBox("¿ Estás seguro que deseas generar la factura Global por:" & Chr(13) & Chr(10) & "SubTotal = " & LblSubtotal.Caption & Chr(13) & Chr(10) & "Iva = " & LblIva.Caption & Chr(13) & Chr(10) & "Total = " & LblTotal.Caption & " ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    MousePointer = 11
    
    Encabezado = IdCedisOX & ", " & IdTipoVentaOX & ", '" & SerieOX & "', " & FolioOX
    
    StrCmd = "execute up_FacturasOxxo " & Encabezado & ", 0,0,0,0, '" & Usuario & "', 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    Total = 0: SubTotal = 0: Iva = 0
    For i = 1 To LstFacturas.ListItems.Count
        If LstFacturas.ListItems(i).Checked Then
            StrCmd = "execute up_FacturasOxxo " & Encabezado & ", " & LstDFacturas(0, LstFacturas.ListItems(i).Index - 1) & ", " & LstDFacturas(12, LstFacturas.ListItems(i).Index - 1) & ", '" & LstDFacturas(1, LstFacturas.ListItems(i).Index - 1) & "', " & LstDFacturas(2, LstFacturas.ListItems(i).Index - 1) & ", '" & Usuario & "', 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
        End If
    Next
    
    StrCmd = "execute up_FacturaOxxo " & IdCedisOX & ", " & IdTipoVentaOX & ", '" & SerieOX & "', " & FolioOX & ", '01/01/1900', 0, '" & Usuario & "', 5"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    CC_FacturasOxxo.MuestraFacturas
        
    MousePointer = 0
    Unload Me
End Sub

Private Sub ChkTodos_Click()
On Error Resume Next
If IsEmpty(LstDFacturas) Then Exit Sub
        For i = 1 To LstFacturas.ListItems.Count
            LstFacturas.ListItems(i).Checked = IIf(ChkTodos.Value, True, False)
        Next
        LstFacturas_ItemCheck LstFacturas.ListItems(i - 1)
End Sub

Private Sub LstFacturas_DblClick()
    On Error Resume Next
    DetalleDeFactura LstDFacturas(0, LstFacturas.SelectedItem.Index - 1), LstDFacturas(12, LstFacturas.SelectedItem.Index - 1), LstDFacturas(1, LstFacturas.SelectedItem.Index - 1), LstDFacturas(2, LstFacturas.SelectedItem.Index - 1), Top, Left, Width, Height, 0
End Sub

Private Sub LstFacturas_ItemCheck(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    Dim i, j, k
    Dim Total, SubTotal, Iva
    
    Total = 0: SubTotal = 0: Iva = 0
    For i = 1 To LstFacturas.ListItems.Count
        If LstFacturas.ListItems(i).Checked Then
            SubTotal = SubTotal + CDbl(LstFacturas.ListItems(i).ListSubItems(3))
            Iva = Iva + CDbl(LstFacturas.ListItems(i).ListSubItems(4))
            Total = Total + CDbl(LstFacturas.ListItems(i).ListSubItems(5))
            j = j + 1
        End If
    Next
    LblNoFacturas.Caption = FormatNumber(j, 0, vbTrue)
    LblSubtotal.Caption = FormatNumber(SubTotal, 2, vbTrue)
    LblIva.Caption = FormatNumber(Iva, 2, vbTrue)
    LblTotal.Caption = FormatNumber(Total, 2, vbTrue)
    
    With CC_FacturasOxxo
        .LblNoFacturas.Caption = FormatNumber(j, 0, vbTrue)
        .LblSubtotal.Caption = FormatNumber(SubTotal, 2, vbTrue)
        .LblIva.Caption = FormatNumber(Iva, 2, vbTrue)
        .LblTotal.Caption = FormatNumber(Total, 2, vbTrue)
    End With
End Sub
