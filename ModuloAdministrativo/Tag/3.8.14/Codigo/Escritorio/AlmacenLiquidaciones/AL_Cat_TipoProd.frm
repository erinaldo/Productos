VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form AL_Cat_TipoProd 
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
      Picture         =   "AL_Cat_TipoProd.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   7
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
      Picture         =   "AL_Cat_TipoProd.frx":0996
      Style           =   1  'Graphical
      TabIndex        =   6
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
      Left            =   5760
      Picture         =   "AL_Cat_TipoProd.frx":1024
      Style           =   1  'Graphical
      TabIndex        =   9
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
      Picture         =   "AL_Cat_TipoProd.frx":173F
      Style           =   1  'Graphical
      TabIndex        =   8
      Top             =   7560
      Width           =   1695
   End
   Begin TabDlg.SSTab SSTab 
      Height          =   7215
      Left            =   120
      TabIndex        =   11
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
      TabCaption(0)   =   "Presentaciones"
      TabPicture(0)   =   "AL_Cat_TipoProd.frx":1E4F
      Tab(0).ControlEnabled=   0   'False
      Tab(0).Control(0)=   "LblOpt(0)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "FrmOpt(1)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "Tipos de Devolución Mala"
      TabPicture(1)   =   "AL_Cat_TipoProd.frx":1E6B
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
         TabIndex        =   17
         Top             =   360
         Width           =   12255
         Begin VB.TextBox TxtConver 
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
            Left            =   5040
            TabIndex        =   2
            Top             =   480
            Width           =   1455
         End
         Begin VB.TextBox TxtPresentacion 
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
            Width           =   3735
         End
         Begin VB.TextBox TxtIdPres 
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
         Begin MSComctlLib.ListView LstPresentacion 
            Height          =   5775
            Left            =   240
            TabIndex        =   23
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
            Caption         =   "Presentación"
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
            TabIndex        =   20
            Top             =   240
            Width           =   1140
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
            TabIndex        =   19
            Top             =   240
            Width           =   855
         End
         Begin VB.Label Label4 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Conversión"
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
            Left            =   5040
            TabIndex        =   18
            Top             =   240
            Width           =   945
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
         TabIndex        =   12
         Top             =   360
         Width           =   12255
         Begin VB.TextBox TxtOrden 
            Alignment       =   2  'Center
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
            Left            =   8040
            TabIndex        =   5
            Top             =   480
            Width           =   2175
         End
         Begin VB.TextBox TxtIdMerma 
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
            TabIndex        =   3
            Top             =   480
            Width           =   855
         End
         Begin VB.TextBox TxtMerma 
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
            TabIndex        =   4
            Top             =   480
            Width           =   6735
         End
         Begin MSComctlLib.ListView LstTipoMerma 
            Height          =   5775
            Left            =   240
            TabIndex        =   24
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
         Begin VB.Label Label3 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Orden Reporte de Caga"
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
            Left            =   8040
            TabIndex        =   21
            Top             =   240
            Width           =   2040
         End
         Begin VB.Label Label2 
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
         Begin VB.Label Label1 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Tipo de Devolución"
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
            TabIndex        =   13
            Top             =   240
            Width           =   1620
         End
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Presentaciones"
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
         TabIndex        =   16
         Top             =   0
         Width           =   6140
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Tipos de Devolución Mala"
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
         TabIndex        =   15
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
      Left            =   7560
      TabIndex        =   22
      Top             =   7680
      Width           =   810
   End
   Begin VB.Image Image1 
      Height          =   30
      Left            =   120
      Picture         =   "AL_Cat_TipoProd.frx":1E87
      Stretch         =   -1  'True
      Top             =   495
      Visible         =   0   'False
      Width           =   13740
   End
   Begin VB.Image Image2 
      Height          =   285
      Left            =   10560
      Picture         =   "AL_Cat_TipoProd.frx":24C4
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
      TabIndex        =   10
      Top             =   120
      Visible         =   0   'False
      Width           =   2220
   End
End
Attribute VB_Name = "AL_Cat_TipoProd"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDCanales, LstDCadenas, Nuevo As Boolean

Private Sub btnActualizar_Click()
Dim TIPOVENDEDOR As Integer
    
On Error GoTo Err_TProdsG:

If LblEdicion.Caption = "Consultar" Then Exit Sub
    
    Select Case SSTab.Tab
        Case 0: If Not ValidaModulo("CATPRODOTRPRES", True) Then Exit Sub
        Case 1: If Not ValidaModulo("CATPRODOTRMERM", True) Then Exit Sub
    End Select
    
    Select Case SSTab.Tab
        Case 0:
            If Trim(TxtIdPres.Text) = "" Or Trim(TxtPresentacion.Text) = "" Or Trim(TxtConver.Text) = "" Then
                MsgBox "¡ Teclee los Datos para Actualizar !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        
            StrCmd = "execute up_Presentacion " & Trim(TxtIdPres.Text) & ", '" & UCase(Trim(TxtPresentacion.Text)) & "', '" & UCase(Trim(TxtConver.Text)) & "','" & FormatDate(Date) & "'," & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraPresentacion
            Nuevo = False
            
        Case 1:
            If Trim(TxtIdMerma.Text) = "" Or Trim(TxtMerma.Text) = "" Or Trim(TxtOrden.Text) = "" Then
                MsgBox "¡ Teclee los Datos para Actualizar !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
            
            If Rs.State Then Rs.Close
            Rs.Open "SELECT * FROM TIPOMERMA WHERE ORDEN = " & Trim(TxtOrden.Text) & "", Cnn
            If Not Rs.EOF Then MsgBox ("Ya existe este número de orden para la Merma")
            
            StrCmd = "execute up_TipoMerma " & Trim(TxtIdMerma.Text) & ",'" & UCase(Trim(TxtMerma.Text)) & "', " & Trim(TxtOrden.Text) & ",'" & FormatDate(Date) & "'," & IIf(Nuevo, 1, 2)
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraTipoMerma
            Nuevo = False
    End Select

No_Err_TProdsG:
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
    LblEdicion.Caption = "Consultar"
    Exit Sub
        
Err_TProdsG:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_TProdsG:
End Sub

Private Sub btnEliminar_Click()
On Error GoTo Err_TProdsE:
    
    Select Case SSTab.Tab
        Case 0: If Not ValidaModulo("CATPRODOTRPRES", True) Then Exit Sub
        Case 1: If Not ValidaModulo("CATPRODOTRMERM", True) Then Exit Sub
    End Select
    
    Select Case SSTab.Tab
        
        Case 0:
            If Trim(TxtIdPres.Text) = "" Then
                MsgBox "¡ Seleccione el registro a dar de Baja !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If

            StrCmd = "execute up_Presentacion " & Trim(TxtIdPres.Text) & ",'','','',3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraPresentacion
            Nuevo = False
                    
        Case 1:
            If Trim(TxtIdMerma.Text) = "" Then
                MsgBox "¡ Seleccione el registro a dar de Baja !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If

            StrCmd = "execute up_TipoMerma  " & Trim(TxtIdMerma.Text) & ",'','','',3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            MuestraTipoMerma
            Nuevo = False
            
    End Select
    

No_Err_TProdsE:
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
    LblEdicion.Caption = "Consultar"
    Exit Sub
        
Err_TProdsE:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_TProdsE:
End Sub

Private Sub btnImprimir_Click()
On Error GoTo Err_TProdsI:

   Select Case SSTab.Tab
        Case 0:
            With AL_RptCatPresentacion
                .Caption = "Catálogo de Presentaciones"
                .LblTitulo.Caption = "Catálogo de Presentaciones"
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                StrCmd = "select IdPresentacion, Presentacion, Conversion, " _
                        & " Case Status " _
                        & " when 'A' then 'Activo' " _
                        & " Else 'Baja' " _
                        & " end as 'Estatus' from presentacion"
                    If RsC.State Then RsC.Close
                    RsC.Open StrCmd, Cnn
        
                If Not RsC.EOF Then
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = RsC
                    .Printer.PaperSize = 1
                    .Printer.Orientation = ddOPortrait
                    .Show
                End If
            End With
            
        Case 1:
            With AL_RptCatTipoMerma
                .Caption = "Catálogo de Tipos de Devolución Mala"
                .LblTitulo.Caption = "Catálogo de Tipos de Devolución Mala"
                .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
                StrCmd = "select IdTipoMerma, TipoMerma, Orden, " _
                        & " Case Status " _
                        & " when 'A' then 'Activo' " _
                        & " Else 'Baja' " _
                        & " end as 'Estatus' " _
                        & " from tipomerma"
                    If RsC.State Then RsC.Close
                    RsC.Open StrCmd, Cnn
        
                If Not RsC.EOF Then
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = RsC
                    .Printer.Orientation = ddOPortrait
                    .Printer.PaperSize = 1
                    .Show
                End If
            End With
    End Select

No_Err_TProdsI:
    LblEdicion.Caption = "Consultar"
    Exit Sub
        
Err_TProdsI:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_TProdsI:
End Sub

Private Sub btnNuevo_Click()
On Error GoTo Err_TProdsN:
    
    Select Case SSTab.Tab
        Case 0: If Not ValidaModulo("CATPRODOTRPRES", True) Then Exit Sub
        Case 1: If Not ValidaModulo("CATPRODOTRMERM", True) Then Exit Sub
    End Select
    
    Select Case SSTab.Tab
        Case 0:
            TxtIdPres.Text = "": TxtPresentacion.Text = "": TxtConver.Text = ""
            If Rs.State Then Rs.Close
            Rs.Open "SELECT ISNULL(MAX(IdPresentacion),0)+1 AS MAXI From presentacion", Cnn
            TxtIdPres.Text = Rs!MAXI
            Nuevo = True
            TxtPresentacion.SetFocus
            
        Case 1:
            TxtIdMerma.Text = "": TxtMerma.Text = "": TxtOrden.Text = ""
            If Rs.State Then Rs.Close
            Rs.Open "SELECT ISNULL(MAX(IdTipoMerma),0)+1 AS MAXI From tipomerma", Cnn
            TxtIdMerma.Text = Rs!MAXI
            Nuevo = True
            TxtMerma.SetFocus
            
    End Select

No_Err_TProdsN:
    LblEdicion.Caption = "Nuevo"
    Exit Sub
        
Err_TProdsN:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_TProdsN:

End Sub

Sub MuestraPresentacion()
On Error Resume Next
    StrCmd = "execute sel_Presentacion"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCanales = GetDataLVL(Rs, LstPresentacion, 0, 4, "1|0|0|0|0")
End Sub

Sub MuestraTipoMerma()
On Error Resume Next
    StrCmd = "execute sel_TipoMermas"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCanales = GetDataLVL(Rs, LstTipoMerma, 0, 4, "1|0|0|0|0")
End Sub

Private Sub Form_Load()
On Error Resume Next
    Nuevo = False
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    MuestraTipoMerma
    SSTab.Tab = 1
End Sub


Private Sub LstRuta_DblClick()
On Error Resume Next
    TxtIdRuta.Text = LstRuta.ListItems(LstRuta.SelectedItem.Index).Text
    TxtRuta.Text = LstRuta.ListItems(LstRuta.SelectedItem.Index).SubItems(1)
    CboTipo.Text = LstRuta.ListItems(LstRuta.SelectedItem.Index).SubItems(2)
    Nuevo = False
End Sub

Private Sub LsTTipoVen_DblClick()
On Error Resume Next
    TxtIdTipoVen.Text = LsTTipoVen.ListItems(LsTTipoVen.SelectedItem.Index).Text
    TxtTipoVend.Text = LsTTipoVen.ListItems(LsTTipoVen.SelectedItem.Index).SubItems(1)
    Nuevo = False
End Sub

Private Sub LstUnidades_DblClick()
On Error Resume Next
    TxtIdUnidad.Text = LstUnidades.ListItems(LstUnidades.SelectedItem.Index).Text
    TxtNoEcon.Text = LstUnidades.ListItems(LstUnidades.SelectedItem.Index).SubItems(1)
    TxtNoSerie.Text = LstUnidades.ListItems(LstUnidades.SelectedItem.Index).SubItems(2)
    CboModelo.Text = LstUnidades.ListItems(LstUnidades.SelectedItem.Index).SubItems(3)
    TxtMarca.Text = LstUnidades.ListItems(LstUnidades.SelectedItem.Index).SubItems(4)
    Nuevo = False
End Sub

Private Sub LstVendedor_DblClick()
On Error Resume Next
    TxtIdVendedor.Text = LstVendedor.ListItems(LstVendedor.SelectedItem.Index).Text
    TxtNomina.Text = LstVendedor.ListItems(LstVendedor.SelectedItem.Index).SubItems(1)
    TxtApPat.Text = LstVendedor.ListItems(LstVendedor.SelectedItem.Index).SubItems(3)
    TxtApMat.Text = LstVendedor.ListItems(LstVendedor.SelectedItem.Index).SubItems(4)
    TxtNombre.Text = LstVendedor.ListItems(LstVendedor.SelectedItem.Index).SubItems(2)
    CboTipoVen.Text = LstVendedor.ListItems(LstVendedor.SelectedItem.Index).SubItems(5)
    Nuevo = False
End Sub

Private Sub LstVendedor_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtApMat_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtApPat_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtCadena_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtMarca_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtNombre_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtRuta_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtTipoVend_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub LstPresentacion_Click()
On Error Resume Next

If LstPresentacion.ListItems.Count <= 0 Then Exit Sub

    TxtIdPres.Text = LstPresentacion.ListItems.Item(LstPresentacion.SelectedItem.Index).Text
    TxtPresentacion.Text = LstPresentacion.ListItems.Item(LstPresentacion.SelectedItem.Index).SubItems(1)
    TxtConver.Text = LstPresentacion.ListItems.Item(LstPresentacion.SelectedItem.Index).SubItems(2)
    Nuevo = False
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub LstPresentacion_DblClick()
On Error Resume Next

If LstPresentacion.ListItems.Count <= 0 Then Exit Sub

    Nuevo = False
    LblEdicion.Caption = "Actualizar"
End Sub

Private Sub LstPresentacion_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstPresentacion_DblClick
End Sub

Private Sub LstTipoMerma_Click()
On Error Resume Next

If LstTipoMerma.ListItems.Count <= 0 Then Exit Sub
    
    TxtIdMerma.Text = LstTipoMerma.ListItems.Item(LstTipoMerma.SelectedItem.Index).Text
    TxtMerma.Text = LstTipoMerma.ListItems.Item(LstTipoMerma.SelectedItem.Index).SubItems(1)
    TxtOrden.Text = LstTipoMerma.ListItems.Item(LstTipoMerma.SelectedItem.Index).SubItems(2)
    Nuevo = False
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub LstTipoMerma_DblClick()
On Error Resume Next

If LstTipoMerma.ListItems.Count <= 0 Then Exit Sub
    
    Nuevo = False
    LblEdicion.Caption = "Actualizar"
End Sub

Private Sub LstTipoMerma_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstTipoMerma_DblClick
End Sub

Private Sub SSTab_Click(PreviousTab As Integer)
On Error Resume Next
    Select Case SSTab.Tab
        Case 0:
            MuestraPresentacion
        Case 1:
            MuestraTipoMerma
    End Select
    LblEdicion.Caption = "Consultar"
End Sub

Private Sub TxtMerma_KeyPress(KeyAscii As Integer)
On Error Resume Next
        KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub

Private Sub TxtPresentacion_KeyPress(KeyAscii As Integer)
On Error Resume Next
        KeyAscii = Asc(UCase(Chr(KeyAscii)))
End Sub
