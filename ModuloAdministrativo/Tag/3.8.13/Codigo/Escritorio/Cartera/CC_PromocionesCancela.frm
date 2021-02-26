VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_PromocionesCancela 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Cancelación de la Promoción"
   ClientHeight    =   3960
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   10515
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
   ScaleHeight     =   3960
   ScaleWidth      =   10515
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton btnSalir 
      BackColor       =   &H00FFFFFF&
      Cancel          =   -1  'True
      Height          =   495
      Left            =   2760
      Picture         =   "CC_PromocionesCancela.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   2
      Top             =   3360
      Width           =   1335
   End
   Begin VB.CommandButton btnCancelarPromocion 
      BackColor       =   &H00FFFFFF&
      Height          =   495
      Left            =   360
      Picture         =   "CC_PromocionesCancela.frx":0557
      Style           =   1  'Graphical
      TabIndex        =   1
      Top             =   3360
      Width           =   2295
   End
   Begin VB.Frame FrmDatos 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Movimientos Generados por el Acuerdo"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3135
      Left            =   120
      TabIndex        =   3
      Top             =   120
      Width           =   10215
      Begin MSComctlLib.ListView LstDetalle 
         Height          =   2655
         Left            =   120
         TabIndex        =   0
         Top             =   360
         Width           =   9975
         _ExtentX        =   17595
         _ExtentY        =   4683
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
   End
End
Attribute VB_Name = "CC_PromocionesCancela"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public IdAplicacionC, IdPromocionC, LstDDetalle

Private Sub btnCancelarPromocion_Click()
Dim Cont

On Error GoTo Err_CancelaPromocion:

    If IsEmpty(LstDDetalle) Then Exit Sub
    
    If MsgBox("¡ Al Cancelar el Movimiento se dará de Baja la Promoción para los Cedis seleccionados !. ¿ Desea continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    MousePointer = 11
    Cont = 0
    For i = 1 To LstDetalle.ListItems.Count
        If LstDetalle.ListItems(i).Checked Then
        
            StrCmd = "execute up_PromocionesAplicadas " & IdAplicacionC & ", " & IdPromocionC & ", '" & Usuario & "', '01/01/1900', '01/01/1900', " & CLng(LstDetalle.ListItems(i)) + 100
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
            
            StrCmd = "execute up_Movimientos " & CLng(LstDetalle.ListItems(i)) & ", " & CLng(LstDetalle.ListItems(i).ListSubItems(2)) & ", '" & IIf(BIdioma = "us_english", Format(CDate(LstDetalle.ListItems(i).ListSubItems(3)), "mm/dd/yyyy"), Format(CDate(LstDetalle.ListItems(i).ListSubItems(3)), "dd/mm/yyyy")) & "', '', '', 0, '', '', '', 'B', '" & Usuario & "',  3"
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn

            Cont = Cont + 1
        End If
    Next
    
    MuestraMovimientosPromocion
    
    If Cont = 0 Then
        MousePointer = 0
        MsgBox "¡ Seleccione un Movimiento a Cancelar !", vbInformation + vbOKOnly
    Else
        MousePointer = 0
        MsgBox "¡ Movimientos Cancelados para " & Cont & " Cedis !", vbInformation + vbOKOnly, App.Title
    End If
    
No_Err_CancelaPromocion:
    MousePointer = 0
    Exit Sub
    
Err_CancelaPromocion:
    MousePointer = 0
    MsgBox "¡ Error al tratar de Cancelar la Promoción !", vbInformation + vbOKOnly, App.Title
    GoTo No_Err_CancelaPromocion:
    
End Sub

Private Sub btnSalir_Click()
On Error Resume Next
    Unload Me
End Sub

Private Sub Form_Load()
On Error Resume Next
    MuestraMovimientosPromocion
End Sub

Sub MuestraMovimientosPromocion()
On Error Resume Next
    
    StrCmd = "execute sel_PromocionesMovimientos " & IdAplicacionC & ", " & IdPromocionC & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDDetalle = GetDataLVL(Rs, LstDetalle, 0, 6, "0|0|0|0|0|0|3")

End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    CC_Promociones.MuestraPromocionesAplicadas
End Sub
