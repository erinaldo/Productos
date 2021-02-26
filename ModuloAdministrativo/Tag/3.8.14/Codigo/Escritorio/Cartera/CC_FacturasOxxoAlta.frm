VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_FacturasOxxoAlta 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Alta de Factura Global"
   ClientHeight    =   5460
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   7110
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   5460
   ScaleWidth      =   7110
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton btnNueva 
      BackColor       =   &H00FFFFFF&
      Default         =   -1  'True
      Height          =   495
      Left            =   1680
      Picture         =   "CC_FacturasOxxoAlta.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   3
      Top             =   4920
      Width           =   1695
   End
   Begin VB.CommandButton btnCancelar 
      BackColor       =   &H00FFFFFF&
      Cancel          =   -1  'True
      Height          =   495
      Left            =   3480
      Picture         =   "CC_FacturasOxxoAlta.frx":068E
      Style           =   1  'Graphical
      TabIndex        =   4
      Top             =   4920
      Width           =   1455
   End
   Begin VB.Frame Frame2 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Datos de la Factura"
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
      Left            =   120
      TabIndex        =   10
      Top             =   120
      Width           =   6855
      Begin VB.TextBox TxtDiasCredito 
         Alignment       =   1  'Right Justify
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   360
         Left            =   5520
         MaxLength       =   2
         TabIndex        =   1
         Text            =   "0"
         Top             =   1040
         Width           =   615
      End
      Begin VB.TextBox Text6 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   3480
         Locked          =   -1  'True
         TabIndex        =   19
         Text            =   "Días de Vencimiento"
         Top             =   1080
         Width           =   1875
      End
      Begin VB.TextBox TxtCedis 
         Alignment       =   2  'Center
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   240
         Locked          =   -1  'True
         TabIndex        =   18
         Text            =   "CEDIS"
         Top             =   360
         Width           =   6255
      End
      Begin VB.TextBox Text1 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   3600
         Locked          =   -1  'True
         TabIndex        =   17
         Text            =   "Fecha Factura"
         Top             =   720
         Width           =   1275
      End
      Begin VB.TextBox Text4 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   1680
         Locked          =   -1  'True
         TabIndex        =   16
         Text            =   "Folio"
         Top             =   1080
         Width           =   555
      End
      Begin VB.TextBox Text3 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         TabIndex        =   15
         Text            =   "Serie"
         Top             =   1080
         Width           =   555
      End
      Begin VB.TextBox Text2 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   105
         Locked          =   -1  'True
         TabIndex        =   14
         Text            =   "Tipo de Venta"
         Top             =   720
         Width           =   1275
      End
      Begin VB.TextBox TxtFolio 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   2280
         Locked          =   -1  'True
         TabIndex        =   13
         Top             =   1080
         Width           =   975
      End
      Begin VB.TextBox TxtSerie 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
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
         TabIndex        =   12
         Top             =   1080
         Width           =   615
      End
      Begin VB.TextBox TxtTipoVenta 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   1680
         Locked          =   -1  'True
         TabIndex        =   11
         Text            =   "2 - Crédito"
         Top             =   720
         Width           =   1815
      End
      Begin MSComCtl2.DTPicker DTPFecha 
         Height          =   350
         Left            =   5040
         TabIndex        =   0
         Top             =   650
         Width           =   1575
         _ExtentX        =   2778
         _ExtentY        =   609
         _Version        =   393216
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Format          =   114098177
         CurrentDate     =   39376
      End
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
      Height          =   3135
      Left            =   120
      TabIndex        =   5
      Top             =   1680
      Width           =   6855
      Begin VB.TextBox Txt12 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   240
         TabIndex        =   9
         Text            =   "Cliente"
         Top             =   720
         Width           =   735
      End
      Begin VB.TextBox Text5 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   240
         Locked          =   -1  'True
         TabIndex        =   8
         Text            =   "R.F.C."
         Top             =   360
         Width           =   615
      End
      Begin VB.TextBox TxtRFC 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   1080
         Locked          =   -1  'True
         TabIndex        =   7
         Top             =   360
         Width           =   1575
      End
      Begin VB.TextBox TxtCliente 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   1080
         Locked          =   -1  'True
         TabIndex        =   6
         Top             =   720
         Width           =   5295
      End
      Begin MSComctlLib.ListView LstClientes 
         Height          =   1935
         Left            =   120
         TabIndex        =   2
         Top             =   1080
         Width           =   6615
         _ExtentX        =   11668
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
   End
End
Attribute VB_Name = "CC_FacturasOxxoAlta"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public IdCedis, IdCadenaOxxo, SerieOxxo
Dim LstDClientes

Private Sub btnCancelar_Click()
On Error Resume Next
    Me.Hide
End Sub

Private Sub btnNueva_Click()
    On Error GoTo Err_AltaFOxxo:
    
    If MsgBox("¿ Deseas dar de Alta la Factura del cedis " & TxtCedis.Text & " ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        
    If IsEmpty(LstDClientes) Or Trim(TxtSerie.Text) = "" Then
        MsgBox "¡ Datos incompletos, verifique !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    MousePointer = 11
    StrCmd = "execute up_FacturaOxxo " & IdCedis & ", 2, '" & TxtSerie.Text & "', 0, '" & IIf(BIdioma = "us_english", Format(DTPFecha.Value, "mm/dd/yyyy"), Format(DTPFecha.Value, "dd/mm/yyyy")) & "', " & CLng(LstClientes.SelectedItem) & ", " & TxtDiasCredito.Text & ", '" & Usuario & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    CC_FacturasOxxo.MuestraFacturas
    MousePointer = 0
        
    MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title
    Me.Hide
    
No_Err_AltaFOxxo:
    MousePointer = 0
    Exit Sub
    
Err_AltaFOxxo:
    MousePointer = 0
    MsgBox "¡ Error !. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_AltaFOxxo:
        
    
End Sub

Private Sub Form_Activate()
On Error Resume Next
    MuestraClientes
End Sub

Sub MuestraClientes()
On Error Resume Next
    StrCmd = "execute sel_Clientes " & IdCedis & ", 0, '', '" & IdCadenaOxxo & "', '" & SerieOxxo & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        TxtSerie.Text = Rs.Fields(4)
        TxtFolio.Text = Rs.Fields(5)
    End If
    LstDClientes = GetDataLVL(Rs, LstClientes, 1, 3, "0|0|0")
End Sub

Private Sub LstClientes_Click()
    On Error Resume Next
    TxtRFC.Text = LstClientes.SelectedItem.ListSubItems(1)
    TxtCliente.Text = LstClientes.SelectedItem & " - " & LstClientes.SelectedItem.ListSubItems(2)
End Sub

Private Sub TxtDiasCredito_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itEntero(KeyAscii)
End Sub
