VERSION 5.00
Begin VB.Form CSG_ConsignaTipoEdicion 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   2880
   ClientLeft      =   150
   ClientTop       =   420
   ClientWidth     =   6390
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   9.75
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "CSG_ConsigaTipoEdicion.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2880
   ScaleWidth      =   6390
   ShowInTaskbar   =   0   'False
   Begin VB.Frame Frame1 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Elige la acción a ejecutar"
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
      Width           =   6135
      Begin VB.OptionButton OptTipoMovimiento 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Cambiar el Cliente de la Consigna"
         Height          =   315
         Index           =   3
         Left            =   300
         TabIndex        =   5
         Top             =   1920
         Width           =   3465
      End
      Begin VB.CommandButton btnAceptar 
         BackColor       =   &H00FFFFFF&
         Default         =   -1  'True
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Left            =   4050
         Picture         =   "CSG_ConsigaTipoEdicion.frx":16B2
         Style           =   1  'Graphical
         TabIndex        =   4
         Top             =   1950
         Width           =   1815
      End
      Begin VB.OptionButton OptTipoMovimiento 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Modificar los Prodcutos de la Consigna"
         Height          =   315
         Index           =   2
         Left            =   300
         TabIndex        =   3
         Top             =   1500
         Width           =   4425
      End
      Begin VB.OptionButton OptTipoMovimiento 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Registrar Ventas de la Consigna"
         Height          =   315
         Index           =   0
         Left            =   300
         TabIndex        =   2
         Top             =   630
         Width           =   3465
      End
      Begin VB.OptionButton OptTipoMovimiento 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Consulta Detalles de la Consigna"
         Height          =   315
         Index           =   1
         Left            =   300
         TabIndex        =   1
         Top             =   1080
         Width           =   3465
      End
   End
End
Attribute VB_Name = "CSG_ConsignaTipoEdicion"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public StatusConsigna As String

Private Sub btnAceptar_Click()
    
    CSG_Consignas.vCancel = False
    Unload Me
    
End Sub

Private Sub cmdCerrarVentana_Click()

    'cancela el movimiento de edicion
    CSG_Consignas.vCancel = True
    Unload Me

End Sub

Private Sub Form_Load()
    
    Select Case StatusConsigna
        Case "E"        'caso de Pendiente por Registrar Devolucion
    
            OptTipoMovimiento(2).Enabled = False
            OptTipoMovimiento(3).Enabled = False
'''            OptTipoMovimiento(4).Enabled = False
    
            OptTipoMovimiento(0).Value = True
    
        Case "P"
            OptTipoMovimiento(0).Enabled = False
            OptTipoMovimiento(1).Value = True
            
    End Select
    
    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then
        OptTipoMovimiento(0).Enabled = False
        OptTipoMovimiento(2).Enabled = False
        OptTipoMovimiento(3).Enabled = False
    End If

End Sub

Private Sub Form_Unload(Cancel As Integer)
    
    CSG_Consignas.ControlFormas = False
    'CSG_Consignas.ZOrder (0)

End Sub

Private Sub OptTipoMovimiento_Click(Index As Integer)

    CSG_Consignas.vTipoEdicionConsigna = Index
    '0 - caso de registro de ventas
    '1 - caso de solo mostrar los detalles de la consigna
    '2 - caso de cambios en el surtido de la consigna
    '3 - caso de cambios en los datos de cliente
    '4 - caso de cambios en datos de cliente y surtido de la consigna
    
End Sub
