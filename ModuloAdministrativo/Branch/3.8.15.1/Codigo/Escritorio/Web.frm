VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form Web 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Indicadores Web"
   ClientHeight    =   9735
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   12660
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   9735
   ScaleWidth      =   12660
   ShowInTaskbar   =   0   'False
   Begin MSComctlLib.ProgressBar ProgressBar 
      Height          =   255
      Left            =   0
      TabIndex        =   1
      Top             =   9480
      Width           =   12615
      _ExtentX        =   22251
      _ExtentY        =   450
      _Version        =   393216
      Appearance      =   1
   End
   Begin VB.PictureBox WebBw 
      Height          =   9255
      Left            =   120
      ScaleHeight     =   9195
      ScaleWidth      =   12315
      TabIndex        =   0
      Top             =   120
      Width           =   12375
   End
End
Attribute VB_Name = "Web"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Load()
On Error Resume Next
Dim Url As String
    
    If Not Cnn.State Then OpenConn Server, "ITAnswerSeguridad", "ITAPDC", "itapdc"
    StrCmd = "Select url from Configuracion"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd
    If Rs.EOF Then
        MsgBox "¡ No hay una dirección definida para los indicadores Web !", vbInformation + vbOKOnly, App.Title
        Unload Me
    Else
        If Trim(Rs.Fields(0)) = "" Then
            MsgBox "¡ No hay una dirección definida para los indicadores Web !", vbInformation + vbOKOnly, App.Title
            Unload Me
        Else
            Url = Trim(Rs.Fields(0))
        End If
    End If
    WebBw.Navigate (Url)
    WebBw.StatusBar = True
End Sub

Private Sub WebBw_ProgressChange(ByVal Progress As Long, ByVal ProgressMax As Long)
On Error Resume Next
    ProgressBar.Value = Progress
    ProgressBar.Max = ProgressMax
    ProgressBar.Refresh
End Sub

