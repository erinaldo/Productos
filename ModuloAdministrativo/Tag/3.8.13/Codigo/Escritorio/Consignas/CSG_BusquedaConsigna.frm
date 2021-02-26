VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CSG_BusquedaConsigna 
   Appearance      =   0  'Flat
   BackColor       =   &H80000005&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   5520
   ClientLeft      =   150
   ClientTop       =   420
   ClientWidth     =   10770
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   9.75
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "CSG_BusquedaConsigna.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5520
   ScaleWidth      =   10770
   ShowInTaskbar   =   0   'False
   Begin VB.Frame Frame1 
      BackColor       =   &H00FFFFFF&
      Height          =   5415
      Left            =   120
      TabIndex        =   0
      Top             =   0
      Width           =   10575
      Begin VB.CommandButton btnIngresar 
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
         Height          =   495
         Left            =   360
         Picture         =   "CSG_BusquedaConsigna.frx":16B2
         Style           =   1  'Graphical
         TabIndex        =   1
         Top             =   4770
         Width           =   1695
      End
      Begin MSComctlLib.ListView LstVConsignasPorDevolver 
         Height          =   4035
         Left            =   120
         TabIndex        =   2
         Top             =   720
         Width           =   10245
         _ExtentX        =   18071
         _ExtentY        =   7117
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
      Begin VB.Label Label4 
         BackColor       =   &H00FFFFFF&
         BackStyle       =   0  'Transparent
         Caption         =   "Consignas Pendientes por Devolver"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   390
         TabIndex        =   3
         Top             =   240
         Width           =   3615
      End
   End
End
Attribute VB_Name = "CSG_BusquedaConsigna"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDConsignasPorDevolver
Dim IdConsignaSeleccionada

Private Sub btnIngresar_Click()

    If IdConsignaSeleccionada <> 0 Then
    
        With CSG_ConsignasInicial
            .IdConsigna = IdConsignaSeleccionada
            .CancelaDevolverConsigna = False
        End With
        
    End If

    Unload Me

End Sub

Private Sub cmdCerrarVentana_Click()
    
    'cancela el movimiento de edicion
    Liquidacion.CancelaDevolverConsigna = True
    Unload Me

End Sub

Private Sub Form_Load()

    'cargar la informacion de consignas con estatus de Pendientes por Devolver
    
    StrCmd = "execute sel_Consignas " & IdCedis & ",0," & IdSurtido & ",3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    IdConsignaSeleccionada = 0
    
    LstDConsignasPorDevolver = GetDataLVL(Rs, LstVConsignasPorDevolver, 0, 5, "1|0|0|0|0|0")
    
    If Not IsEmpty(LstDConsignasPorDevolver) Then LstVConsignasPorDevolver_ItemClick LstVConsignasPorDevolver.SelectedItem

End Sub

Private Sub LstVConsignasPorDevolver_Click()

    If LstVConsignasPorDevolver.ListItems.Count > 0 Then

        IdConsignaSeleccionada = LstDConsignasPorDevolver(0, LstVConsignasPorDevolver.SelectedItem.Index - 1)

    End If

End Sub

Private Sub LstVConsignasPorDevolver_ItemClick(ByVal Item As MSComctlLib.ListItem)

    LstVConsignasPorDevolver_Click

End Sub
