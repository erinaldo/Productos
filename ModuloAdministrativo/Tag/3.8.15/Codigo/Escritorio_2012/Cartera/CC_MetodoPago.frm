VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_MetodoPago 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   2910
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   6645
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2910
   ScaleWidth      =   6645
   ShowInTaskbar   =   0   'False
   Begin VB.Frame Frame1 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Asignación de Métodos de Pago"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2655
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   6375
      Begin VB.CommandButton btnFinaliza 
         BackColor       =   &H00FFFFFF&
         Height          =   495
         Left            =   2400
         Picture         =   "CC_MetodoPago.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   2
         Top             =   2040
         Width           =   1815
      End
      Begin VB.CommandButton btnEnd 
         BackColor       =   &H00FFFFFF&
         Cancel          =   -1  'True
         Height          =   495
         Left            =   4320
         Picture         =   "CC_MetodoPago.frx":0996
         Style           =   1  'Graphical
         TabIndex        =   1
         Top             =   2040
         Width           =   1815
      End
      Begin MSComctlLib.ListView LstMetodosPago 
         Height          =   1575
         Left            =   120
         TabIndex        =   3
         Top             =   360
         Width           =   6015
         _ExtentX        =   10610
         _ExtentY        =   2778
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
      Begin VB.Label lblIDCliente 
         Caption         =   "idcliente"
         Height          =   255
         Left            =   600
         TabIndex        =   4
         Top             =   2160
         Visible         =   0   'False
         Width           =   1335
      End
   End
End
Attribute VB_Name = "CC_MetodoPago"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDClientes


Private Sub btnEnd_Click()
On Error Resume Next
    Facturar = False
    Unload Me
End Sub

Private Sub btnFinaliza_Click()
    metodoPago = SeleccionarMetodos
    Facturar = ValidarMetodos(metodoPago)
    Unload Me
End Sub

Private Sub Form_Activate()
On Error Resume Next
    LlenaMetodosPago
End Sub

Sub LlenaMetodosPago()
On Error Resume Next
        txtMetodosPago.Visible = False
        LstMetodosPago.Visible = True
        'StrCmd = "exec sel_ValorReferencia 'PAGO'"
        'StrCmd = "Select clientepagoid as VAVClave, MetodoPago + ' ' + replace(Banco,'*','') + ' ' + replace(NumCtaPago,'*','') as Descripcion from RouteADM.dbo.clientepago where idcliente = " & lblIDCliente.Caption & " and idcedis = " & IdCedis
        'If Rs.State Then Rs.Close
        'Rs.Open StrCmd, Cnn
        Set Rs = ObtenerMetodosDePago(lblIDCliente.Caption, CStr(IdCedis))
        LstDMetodoPago = GetDataLVL(Rs, LstMetodosPago, 1, 4, "0|0|0|0")
        LstMetodosPago.ColumnHeaders.item(1).Text = "Método de Pago"
        LstMetodosPago.ColumnHeaders(1).Width = 5900
        LstMetodosPago.ColumnHeaders(2).Width = 0
        LstMetodosPago.ColumnHeaders(3).Width = 0
        LstMetodosPago.ColumnHeaders(4).Width = 0
End Sub


Function SeleccionarMetodos() As String
    Dim sMetodos As String, sBancos As String, sNumCta As String
    Dim i As Integer
    banco = ""
    numCta = ""
    For i = 1 To LstMetodosPago.ListItems.Count
        If LstMetodosPago.ListItems(i).Checked Then
            If sMetodos <> "" Then sMetodos = sMetodos + ","
            If sBancos <> "" Then sBancos = sBancos + ","
            If sNumCta <> "" Then sNumCta = sNumCta + ","
            sMetodos = sMetodos + LstMetodosPago.ListItems(i).SubItems(1) 'LstMetodosPago.ListItems(i).Text
            sBancos = sBancos + LstMetodosPago.ListItems(i).SubItems(2)
            sNumCta = sNumCta + LstMetodosPago.ListItems(i).SubItems(3)
        End If
    Next
    SeleccionarMetodos = sMetodos
    banco = sBancos
    numCta = sNumCta
End Function

Function ValidarMetodos(ByVal sMetodos As String) As Boolean
    Dim nVersionCFD As Integer
    StrCmd = "execute sel_VersionCFD "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        nVersionCFD = Rs.Fields(0)
    End If
    If sMetodos = "" And nVersionCFD = 4 Then
        MsgBox "Se debe asignar por lo menos un Método de Pago", vbInformation + vbOKOnly, App.Title
        ValidarMetodos = False
    Else
        ValidarMetodos = True
    End If
End Function

