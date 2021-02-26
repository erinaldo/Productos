VERSION 5.00
Begin VB.Form AcercaDe 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Acerca De"
   ClientHeight    =   3660
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   7155
   Icon            =   "AcercaDe.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3660
   ScaleWidth      =   7155
   StartUpPosition =   2  'CenterScreen
   Begin VB.Label LblDatos 
      BackColor       =   &H00FFFFFF&
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1455
      Left            =   240
      TabIndex        =   1
      Top             =   2040
      Width           =   6735
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      BackColor       =   &H00FFFFFF&
      Caption         =   "Copyright © 2007 ITAnswers S.A. de C.V."
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   240
      TabIndex        =   0
      Top             =   1560
      Width           =   6735
   End
   Begin VB.Line Line1 
      BorderColor     =   &H00C0C0C0&
      BorderWidth     =   2
      X1              =   120
      X2              =   7080
      Y1              =   1320
      Y2              =   1320
   End
   Begin VB.Image Image2 
      Height          =   870
      Left            =   120
      Picture         =   "AcercaDe.frx":0D42
      Top             =   240
      Width           =   2070
   End
End
Attribute VB_Name = "AcercaDe"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Load()
    LblDatos.Caption = "Av. Aguascalientes 734 - 6 " & Chr(13) & Chr(10) & " Valle del Río San Pedro" & Chr(13) & Chr(10) & _
                       "C.P. 20064 " & Chr(13) & Chr(10) & _
                       "Aguascalientes, Ags. México." '& Chr(13) & Chr(10) & _
                       '"Tel. y Fax + 52(449) 1460200 con 4 líneas " & Chr(13) & Chr(10) & _
                       '"www.isaavanzados.com.mx"
End Sub

