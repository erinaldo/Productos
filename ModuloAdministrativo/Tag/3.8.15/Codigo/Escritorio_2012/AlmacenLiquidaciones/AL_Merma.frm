VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.2#0"; "MSCOMCTL.OCX"
Begin VB.Form AL_Merma 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   5355
   ClientLeft      =   150
   ClientTop       =   420
   ClientWidth     =   5445
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   9.75
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "AL_Merma.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   5355
   ScaleWidth      =   5445
   ShowInTaskbar   =   0   'False
   Begin VB.Frame Frame 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Clasifica la Devolución Mala"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   5295
      Left            =   0
      TabIndex        =   7
      Top             =   0
      Width           =   5415
      Begin VB.CommandButton btnEnd 
         BackColor       =   &H00FFFFFF&
         Caption         =   "&Cancelar"
         Height          =   375
         Left            =   2880
         Style           =   1  'Graphical
         TabIndex        =   5
         Top             =   4800
         Width           =   1215
      End
      Begin VB.CommandButton btnFinaliza 
         BackColor       =   &H00FFFFFF&
         Caption         =   "&Finalizar"
         Height          =   375
         Left            =   1440
         Style           =   1  'Graphical
         TabIndex        =   4
         Top             =   4800
         Width           =   1215
      End
      Begin VB.TextBox TxtCantidad 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   3480
         TabIndex        =   1
         Text            =   "0"
         Top             =   1080
         Width           =   735
      End
      Begin VB.TextBox TxtFaltante 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   4560
         Locked          =   -1  'True
         TabIndex        =   2
         Top             =   1080
         Width           =   735
      End
      Begin VB.ComboBox cmbTipo 
         Height          =   360
         Left            =   120
         Style           =   2  'Dropdown List
         TabIndex        =   0
         Top             =   1080
         Width           =   3135
      End
      Begin VB.TextBox TxtTotal 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   3120
         Locked          =   -1  'True
         TabIndex        =   6
         Top             =   360
         Width           =   735
      End
      Begin MSComctlLib.ListView LstMermas 
         Height          =   3135
         Left            =   120
         TabIndex        =   3
         Top             =   1560
         Width           =   5175
         _ExtentX        =   9128
         _ExtentY        =   5530
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
      Begin VB.Label Label2 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Faltante"
         Height          =   240
         Left            =   4560
         TabIndex        =   11
         Top             =   840
         Width           =   705
      End
      Begin VB.Label Label1 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Cantidad"
         Height          =   240
         Left            =   3480
         TabIndex        =   10
         Top             =   840
         Width           =   765
      End
      Begin VB.Label LblCombo 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Tipo de Devolución Mala"
         Height          =   255
         Left            =   120
         TabIndex        =   9
         Top             =   840
         Width           =   2295
      End
      Begin VB.Label LblDevolucion 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Total de Devolución Mala"
         Height          =   255
         Left            =   840
         TabIndex        =   8
         Top             =   360
         Width           =   2295
      End
   End
End
Attribute VB_Name = "AL_Merma"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDTipo, LstDMermas, Inicio As Boolean
Public TipoDev As Integer

Private Sub btnEnd_Click()
On Error Resume Next
'    CalculaFaltante
    If CDbl(TxtFaltante.Text) = "0" Then
        Unload Me
        Exit Sub
    End If
    If CDbl(TxtFaltante.Text) <> 0 Then
        If MsgBox("¿ Deseas Cancelar la clasificación de la Devolución " & IIf(TipoDev = 1, "", "Mala") & " ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
            
            StrCmd = "execute up_Surtidos" & IIf(TipoDev = 1, "Devolucion ", "Merma ") & IdCedis & ", " & IdSurtido & ", " & CLng(AL_Liquidacion.TxtIdProdD.Text) & ", 0, 0, 3"
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
            
            If TipoDev = 1 Then
                AL_Liquidacion.TxtBuenaD.Text = "0"
            Else
                AL_Liquidacion.TxtMalaD.Text = "0"
            End If
'            a = AL_Liquidacion.ValFaltante(AL_Liquidacion.TxtMalaD)
            Unload Me
        Else
            Exit Sub
        End If
    End If
End Sub

Private Sub btnFinaliza_Click()
On Error Resume Next
    If CDbl(TxtFaltante.Text) <> 0 Then
        MsgBox "¡ Debe Clasificar toda la Devolución " & IIf(TipoDev = 1, "", "Mala") & " !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    Else
        Unload Me
    End If
End Sub


Private Sub cmbTipo_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 Then
        TxtCantidad.SetFocus
    End If
End Sub

Private Sub Form_Activate()
On Error Resume Next
    LlenaComboMerma
    MuestraDevMala
    cmbTipo.SetFocus
    Frame.Caption = IIf(TipoDev = 1, "Clasifica la Devolución", "Clasifica la Devolución Mala")
    LblDevolucion.Caption = IIf(TipoDev = 1, "Total de Devolución", "Total de Devolución Mala")
    LblCombo.Caption = IIf(TipoDev = 1, "Tipo de Devolución", "Tipo de Devolución Mala")
End Sub

Private Sub Form_Load()
On Error Resume Next
    Inicio = True
End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    StrCmd = "execute sel_Surtidos" & IIf(TipoDev = 1, "Devolucion ", "Merma ") & IdCedis & ", " & IdSurtido & ", " & CLng(AL_Liquidacion.TxtIdProdD.Text) & ", 2"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    If TipoDev = 1 Then
        AL_Liquidacion.TxtBuenaC.Text = "0"
        AL_Liquidacion.TxtBuenaD.Text = RsC.Fields(0)
        AL_Liquidacion.TxtMalaD.SetFocus
    Else
        AL_Liquidacion.TxtMalaD.Text = RsC.Fields(0)
        AL_Liquidacion.TxtObsequiosD.SetFocus
    End If
    
End Sub

Private Sub LstMermas_DblClick()
On Error Resume Next
    If Not ValidaModulo("LIQDEV", True) Then Exit Sub
    If MsgBox("¿ Deseas Eliminar el elemento seleccionado ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
        StrCmd = "execute up_Surtidos" & IIf(TipoDev = 1, "Devolucion ", "Merma ") & IdCedis & ", " & IdSurtido & ", " & CLng(AL_Liquidacion.TxtIdProdD.Text) & ", " & CLng(LstMermas.SelectedItem) & ", 0, 2"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        CalculaFaltante
        MuestraDevMala
    End If
End Sub

Private Sub TxtCantidad_GotFocus()
On Error Resume Next
    SelText TxtCantidad
End Sub

Private Sub TxtCantidad_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 Then
        If Not ValidaModulo("LIQDEV", True) Then Exit Sub
        SplitTxt TxtCantidad
        TxtCantidad_Validate False
        cmbTipo.SetFocus
        Exit Sub
    End If
    If Dec Then
        If KeyAscii <> "42" Then KeyAscii = itDecimal(KeyAscii)
    Else
        If KeyAscii <> "42" Then KeyAscii = itEntero(KeyAscii)
    End If
End Sub

Private Sub TxtCantidad_Validate(Cancel As Boolean)
On Error Resume Next
    If (Trim(TxtCantidad.Text) = "" Or TxtCantidad.Text = "0") Or cmbTipo.ListIndex = 0 Then
    'If cmbTipo.ListIndex = 0 Then
        CalculaFaltante
        If CDbl(TxtFaltante.Text) <> 0 Then
            MsgBox "¡ Debe Clasificar toda la Devolución " & IIf(TipoDev = 1, "", "Mala") & " !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        Me.Hide
        If TipoDev = 1 Then
            AL_Liquidacion.TxtMalaD.SetFocus
        Else
            AL_Liquidacion.TxtObsequiosD.SetFocus
        End If
        Exit Sub
    End If
    
    If Trim(TxtCantidad.Text) = "" Or TxtCantidad.Text = "0" Then
        MsgBox "¡ Teclee una Cantidad !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If LstDTipo(4, cmbTipo.ListIndex - 1) Then
        If CDbl(TxtCantidad.Text) > CDbl(TxtFaltante.Text) Or CDbl(TxtFaltante.Text) = 0 Then
            MsgBox "¡ Teclee una Cantidad menor al Faltante por Clasificar !", vbInformation + vbOKOnly, App.Title
            TxtCantidad.SetFocus
            Exit Sub
        End If
    End If
    
    StrCmd = "execute up_Surtidos" & IIf(TipoDev = 1, "Devolucion ", "Merma ") & IdCedis & ", " & IdSurtido & ", " & CDbl(AL_Liquidacion.TxtIdProdD.Text) & ", " & cmbTipo.ItemData(cmbTipo.ListIndex) & ", " & CDbl(TxtCantidad.Text) & ", 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    CalculaFaltante
    
    If CDbl(TxtFaltante.Text) = 0 Then
        Me.Hide
        If TipoDev = 1 Then
            AL_Liquidacion.TxtMalaD.SetFocus
        Else
            AL_Liquidacion.TxtObsequiosD.SetFocus
        End If
        Exit Sub
    End If
    
    MuestraDevMala
End Sub

Sub CalculaFaltante() '(Total As Long)
On Error Resume Next
    StrCmd = "execute sel_Surtidos" & IIf(TipoDev = 1, "Devolucion ", "Merma ") & IdCedis & ", " & IdSurtido & ", " & CDbl(AL_Liquidacion.TxtIdProdD.Text) & ", 2"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    TxtFaltante.Text = CDbl(TxtTotal.Text) - RsC.Fields(0)
End Sub

Sub MuestraDevMala()
On Error Resume Next

    StrCmd = "execute sel_Surtidos" & IIf(TipoDev = 1, "Devolucion ", "Merma ") & IdCedis & ", " & IdSurtido & ", " & CLng(AL_Liquidacion.TxtIdProdD.Text) & ", 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDMermas = GetDataLVL(RsC, LstMermas, 1, 3, "1|0|9")
End Sub

Sub LlenaComboMerma()
On Error Resume Next
    
    If TipoDev = 1 Then
        StrCmd = "execute sel_TipoDevolucion 3"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        LstDTipo = GetDataCBL(RsC, cmbTipo, "Seleccione un Tipo de Devolución", "No existen Tipos de Devolución")
    Else
        StrCmd = "execute sel_TipoMerma 3"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        LstDTipo = GetDataCBL(RsC, cmbTipo, "Seleccione un Tipo de Devolución Mala", "No existen Tipos de Devolución Mala")
    End If
End Sub
