VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form AL_Cat_Almacen 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   8130
   ClientLeft      =   2205
   ClientTop       =   1890
   ClientWidth     =   12480
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   8130
   ScaleWidth      =   12480
   ShowInTaskbar   =   0   'False
   Visible         =   0   'False
   Begin VB.CommandButton btnActualizar 
      BackColor       =   &H00FFFFFF&
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   2160
      Picture         =   "AL_Cat_Almacen.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   5
      Top             =   7560
      Width           =   1695
   End
   Begin VB.CommandButton btnNuevo 
      BackColor       =   &H00FFFFFF&
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   360
      Picture         =   "AL_Cat_Almacen.frx":0996
      Style           =   1  'Graphical
      TabIndex        =   4
      Top             =   7560
      Width           =   1695
   End
   Begin VB.CommandButton btnImprimir 
      BackColor       =   &H00FFFFFF&
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   4080
      Picture         =   "AL_Cat_Almacen.frx":1024
      Style           =   1  'Graphical
      TabIndex        =   7
      Top             =   7560
      Width           =   1695
   End
   Begin VB.CommandButton btnEliminar 
      BackColor       =   &H00FFFFFF&
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   3960
      Picture         =   "AL_Cat_Almacen.frx":173F
      Style           =   1  'Graphical
      TabIndex        =   6
      Top             =   7560
      Visible         =   0   'False
      Width           =   1695
   End
   Begin TabDlg.SSTab SSTab 
      Height          =   7215
      Left            =   120
      TabIndex        =   9
      Top             =   120
      Width           =   12255
      _ExtentX        =   21616
      _ExtentY        =   12726
      _Version        =   393216
      Tabs            =   2
      Tab             =   1
      TabsPerRow      =   2
      TabHeight       =   520
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      TabCaption(0)   =   "Movimientos de Almacén"
      TabPicture(0)   =   "AL_Cat_Almacen.frx":1E4F
      Tab(0).ControlEnabled=   0   'False
      Tab(0).Control(0)=   "FrmOpt(1)"
      Tab(0).Control(1)=   "LblOpt(0)"
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "Asignación de Familias a Movimientos"
      TabPicture(1)   =   "AL_Cat_Almacen.frx":1E6B
      Tab(1).ControlEnabled=   -1  'True
      Tab(1).Control(0)=   "LblOpt(3)"
      Tab(1).Control(0).Enabled=   0   'False
      Tab(1).Control(1)=   "FrmOpt(0)"
      Tab(1).Control(1).Enabled=   0   'False
      Tab(1).ControlCount=   2
      Begin VB.Frame FrmOpt 
         BackColor       =   &H00FFFFFF&
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   11.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   6855
         Index           =   1
         Left            =   -75000
         TabIndex        =   13
         Top             =   360
         Width           =   12255
         Begin VB.OptionButton OptES 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Salida"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Index           =   1
            Left            =   9240
            TabIndex        =   3
            Top             =   480
            Width           =   1215
         End
         Begin VB.OptionButton OptES 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Entrada"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Index           =   0
            Left            =   8040
            TabIndex        =   2
            Top             =   480
            Width           =   975
         End
         Begin VB.TextBox TxtMovimiento 
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   1200
            TabIndex        =   1
            Top             =   480
            Width           =   6495
         End
         Begin VB.TextBox TxtIdMovimiento 
            Alignment       =   2  'Center
            Enabled         =   0   'False
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   240
            Locked          =   -1  'True
            MaxLength       =   5
            TabIndex        =   0
            Top             =   480
            Width           =   855
         End
         Begin MSComctlLib.ListView LstMovimientos 
            Height          =   5775
            Left            =   240
            TabIndex        =   17
            Top             =   960
            Width           =   11895
            _ExtentX        =   20981
            _ExtentY        =   10186
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
         Begin VB.Label Label6 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Movimiento"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Left            =   1200
            TabIndex        =   15
            Top             =   240
            Width           =   975
         End
         Begin VB.Label Label5 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Clave"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   240
            TabIndex        =   14
            Top             =   240
            Width           =   855
         End
      End
      Begin VB.Frame FrmOpt 
         BackColor       =   &H00FFFFFF&
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   11.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   6855
         Index           =   0
         Left            =   0
         TabIndex        =   10
         Top             =   360
         Width           =   12255
         Begin MSComctlLib.ListView LstMovsFams 
            Height          =   5415
            Left            =   240
            TabIndex        =   18
            Top             =   1320
            Width           =   11895
            _ExtentX        =   20981
            _ExtentY        =   9551
            View            =   3
            LabelEdit       =   1
            LabelWrap       =   -1  'True
            HideSelection   =   0   'False
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
         Begin VB.Label Label1 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Familias Asignadas al Movimiento"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Left            =   480
            TabIndex        =   20
            Top             =   960
            Width           =   2955
         End
         Begin VB.Label LblMovimiento 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Movimiento"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   12
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000000C0&
            Height          =   270
            Left            =   360
            TabIndex        =   19
            Top             =   480
            Width           =   1200
         End
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Movimientos de Almacén"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   0
         Left            =   -75000
         TabIndex        =   12
         Top             =   0
         Width           =   6140
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Asignación de Familias a Movimientos"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   3
         Left            =   6120
         TabIndex        =   11
         Top             =   0
         Width           =   6140
      End
   End
   Begin VB.Label LblEdicion 
      AutoSize        =   -1  'True
      BackColor       =   &H00FFFFFF&
      Caption         =   "Consultar"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000080&
      Height          =   210
      Left            =   5880
      TabIndex        =   16
      Top             =   7680
      Width           =   810
   End
   Begin VB.Image Image1 
      Height          =   30
      Left            =   120
      Picture         =   "AL_Cat_Almacen.frx":1E87
      Stretch         =   -1  'True
      Top             =   495
      Visible         =   0   'False
      Width           =   13740
   End
   Begin VB.Image Image2 
      Height          =   285
      Left            =   10560
      Picture         =   "AL_Cat_Almacen.frx":24C4
      Top             =   135
      Visible         =   0   'False
      Width           =   3315
   End
   Begin VB.Label LblTitulo 
      AutoSize        =   -1  'True
      BackColor       =   &H00FFFFFF&
      Caption         =   "Titulo de la Pantalla"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000C0&
      Height          =   285
      Left            =   720
      TabIndex        =   8
      Top             =   120
      Visible         =   0   'False
      Width           =   2220
   End
End
Attribute VB_Name = "AL_Cat_Almacen"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDMovimientos, LstDMovsFams, IdTipoMovimiento, Nuevo As Boolean

Private Sub btnActualizar_Click()
Dim TIPOVENDEDOR As Integer
    
On Error GoTo Err_TTipoMovG:

If LblEdicion.Caption = "Consultar" And Nuevo Then Exit Sub
    
    Select Case SSTab.Tab
            Case 0: If Not ValidaModulo("CATALMMOVS", True) Then Exit Sub
            Case 1: If Not ValidaModulo("CATALMMOVSF", True) Then Exit Sub
    End Select
    
    Select Case SSTab.Tab
        Case 0:
            If Trim(TxtIdMovimiento.Text) = "" Or Trim(TxtMovimiento.Text) = "" Or (OptES(0).Value = False And OptES(1).Value = False) Then
                MsgBox "¡ Teclee los Datos para Actualizar !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        
            StrCmd = "execute up_TipoMovimiento " & IdCedis & ", " & Trim(TxtIdMovimiento.Text) & ", '" & UCase(Trim(TxtMovimiento.Text)) & "', '" & IIf(OptES(0).Value, "E", "S") & "', " & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraMovimientos
            
            StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", 0, 0, 0, 0, '', " & Trim(TxtIdMovimiento.Text) & ", '19000101', 0, 0, '', 0, " & _
            "'" & IIf(Nuevo, "Insertar", "Actualizar") & "', 'Movimientos Almacén. IdMovimiento " & Trim(TxtIdMovimiento.Text) & " - " & UCase(Trim(TxtMovimiento.Text)) & ", " & IIf(OptES(0).Value, OptES(0).Caption, OptES(1).Caption) & "', 9"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            
            Nuevo = False
        
        Case 1
            If MsgBox("¿Estás seguro que quieres Actualizar la información ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
            For i = 1 To LstMovsFams.ListItems.Count
                StrCmd = "execute up_TipoMovimiento " & IdCedis & ", " & IdTipoMovimiento & ", '" & LstMovsFams.ListItems(i) & "', '" & IIf(LstMovsFams.ListItems(i).Checked, "A", "B") & "', 3"
                If Rs.State Then Rs.Close
                Rs.Open StrCmd, Cnn
            Next i
            
            StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", 0, 0, 0, 0, '', " & Trim(TxtIdMovimiento.Text) & ", '19000101', 0, 0, '', 0, " & _
            "'Actualizar', 'Asignación de Familias a Movimientos Almacén. IdMovimiento " & Trim(TxtIdMovimiento.Text) & "', 9"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            
            MuestraMovsFams
            Nuevo = False
            
    End Select

No_Err_TTipoMovG:
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
    LblEdicion.Caption = "Consultar"
    Exit Sub
        
Err_TTipoMovG:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_TTipoMovG:
End Sub

Private Sub btnImprimir_Click()
On Error GoTo Err_TipoMovI:

   Select Case SSTab.Tab
        Case 0:
            With AL_RptCatMovimientos
                .Caption = "Catálogo de Movimientos de Almacén"
                .LblTitulo.Caption = "Catálogo de Movimientos de Almacén"
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                StrCmd = "execute sel_TipoMovimiento2 " & IdCedis & ", 0, 2"
                If Rs.State Then Rs.Close
                Rs.Open StrCmd, Cnn
        
                If Not Rs.EOF Then
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = Rs
                    .Printer.PaperSize = 1
                    .Printer.Orientation = ddOPortrait
                    .Show
                End If
            End With
            
        Case 1:
            With AL_RptCatMovimientosFamilias
                .Caption = "Familias Asignadas a los Movimientos de Almacén"
                .LblTitulo.Caption = "Familias Asignadas a los Movimientos de Almacén"
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                StrCmd = "execute sel_MovimientosFamilias " & IdCedis & ", " & IdTipoMovimiento & ", 0, 3"
                If Rs.State Then Rs.Close
                Rs.Open StrCmd, Cnn
        
                If Not Rs.EOF Then
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = Rs
                    .Printer.Orientation = ddOPortrait
                    .Printer.PaperSize = 1
                    .Show
                End If
            End With
    End Select

No_Err_TipoMovI:
    LblEdicion.Caption = "Consultar"
    Exit Sub
        
Err_TipoMovI:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_TipoMovI:
End Sub

Private Sub btnNuevo_Click()
On Error GoTo Err_TipoMovN:
    
    Select Case SSTab.Tab
            Case 0: If Not ValidaModulo("CATALMMOVS", True) Then Exit Sub
            Case 1: If Not ValidaModulo("CATALMMOVSF", True) Then Exit Sub
    End Select
    
    Select Case SSTab.Tab
        Case 0:
            TxtIdMovimiento.Text = "": TxtMovimiento.Text = "": OptES(0).Value = False: OptES(1).Value = False
            If Rs.State Then Rs.Close
            Rs.Open "SELECT ISNULL(MAX(IdTipoMovimiento),0)+1 AS MAXI From TipoMovimiento where idcedis = " & IdCedis, Cnn
            TxtIdMovimiento.Text = Rs!MAXI
            Nuevo = True
            TxtMovimiento.SetFocus
        Case 1
            MsgBox "¡ Opción inválida !" & Chr(13) & Chr(10) & "Selecciona las Familias y da clic en 'Guardar Cambios'", vbInformation + vbOKOnly, App.Title
            
    End Select

No_Err_TipoMovN:
    LblEdicion.Caption = "Nuevo"
    Exit Sub
        
Err_TipoMovN:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_TipoMovN:

End Sub

Sub MuestraMovimientos()
On Error Resume Next
    IdTipoMovimiento = 0
    StrCmd = "execute sel_TipoMovimiento2 " & IdCedis & ", 0, 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDMovimientos = GetDataLVL(Rs, LstMovimientos, 0, 2, "0|0|0")
End Sub

Sub MuestraMovsFams()
On Error Resume Next

    StrCmd = "execute sel_MovimientosFamilias " & IdCedis & ", " & IdTipoMovimiento & ", 0, 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDMovsFams = GetDataLVL(Rs, LstMovsFams, 0, 1, "0|0")
    
    StrCmd = "execute sel_MovimientosFamilias " & IdCedis & ", " & IdTipoMovimiento & ", 0, 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    i = 0
    While Not Rs.EOF
        i = i + 1
        LstMovsFams.ListItems(i).Checked = IIf(Rs.Fields(2) > 0, True, False)
        Rs.MoveNext
    Wend
End Sub

Private Sub Form_Activate()
On Error Resume Next
    SSTab.Tab = 0
End Sub

Private Sub Form_Load()
On Error Resume Next
    Nuevo = False
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    SSTab.Tab = 0: IdTipoMovimiento = 0
    MuestraMovimientos
End Sub


Private Sub TxtTipoVend_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub LstMovimientos_DblClick()
On Error Resume Next

If LstMovimientos.ListItems.Count <= 0 Then Exit Sub

    Nuevo = False
    LblEdicion.Caption = "Actualizar"

End Sub

Private Sub LstMovimientos_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next

    If LstMovimientos.ListItems.Count <= 0 Then Exit Sub
    
    TxtIdMovimiento.Text = LstMovimientos.SelectedItem
    TxtMovimiento.Text = LstMovimientos.SelectedItem.ListSubItems(1).Text
    If Mid(LstMovimientos.SelectedItem.ListSubItems(2), 1, 1) = "E" Then
        OptES(0).Value = True
    Else
        OptES(1).Value = True
    End If
    IdTipoMovimiento = LstMovimientos.SelectedItem
    LblMovimiento.Caption = LstMovimientos.SelectedItem & " - " & LstMovimientos.SelectedItem.ListSubItems(1) & " (" & LstMovimientos.SelectedItem.ListSubItems(2) & ")"
    
    Nuevo = False
    LblEdicion.Caption = "Consultar"

End Sub

Private Sub SSTab_Click(PreviousTab As Integer)
On Error Resume Next
    Select Case SSTab.Tab
        Case 0:
            If Not ValidaModulo("CATALMMOVS", True) Then
                Unload Me
            End If
            MuestraMovimientos
        Case 1:
            If Not ValidaModulo("CATALMMOVSF", True) Then
                SSTab.Tab = 0
                Exit Sub
            End If
            If IdTipoMovimiento = 0 Then
                MsgBox "¡ Seleccione un Movimiento !", vbInformation + vbOKOnly, App.Title
                SSTab.Tab = 0
                Exit Sub
            End If
            MuestraMovsFams
    End Select
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub TxtMovimiento_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub
