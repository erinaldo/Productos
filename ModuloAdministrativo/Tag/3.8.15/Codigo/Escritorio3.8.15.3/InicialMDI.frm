VERSION 5.00
Begin VB.MDIForm InicialMDI 
   BackColor       =   &H00FFFFFF&
   Caption         =   "AMESOL México - Administración de Cedis"
   ClientHeight    =   9645
   ClientLeft      =   165
   ClientTop       =   555
   ClientWidth     =   12345
   Icon            =   "InicialMDI.frx":0000
   LinkTopic       =   "MDIForm1"
   Picture         =   "InicialMDI.frx":08CA
   ScrollBars      =   0   'False
   StartUpPosition =   3  'Windows Default
   WindowState     =   2  'Maximized
End
Attribute VB_Name = "InicialMDI"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public FrmInicial As Inicial

Private Sub MDIForm_Load()
On Error Resume Next
    Set FrmInicial = New Inicial
    With FrmInicial
        .Height = Me.Height + 1000
        .imgLateral.Height = Me.Height + 1000
        .Show
    End With
End Sub

Private Sub MDIForm_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
On Error Resume Next
    Unload CC_SubMenu
    Unload AL_SubMenu
End Sub

Private Sub MDIForm_Unload(Cancel As Integer)
On Error Resume Next
    End
End Sub

