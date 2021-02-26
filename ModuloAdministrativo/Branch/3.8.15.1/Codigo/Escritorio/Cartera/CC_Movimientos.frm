VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "Mscomctl.ocx"
Begin VB.Form CC_Movimientos 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Aplicación de Movimientos"
   ClientHeight    =   8430
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   12660
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
   ScaleHeight     =   8430
   ScaleWidth      =   12660
   ShowInTaskbar   =   0   'False
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
      Height          =   8415
      Index           =   0
      Left            =   120
      TabIndex        =   14
      Top             =   0
      Width           =   12375
      Begin VB.CommandButton btnBuscar 
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
         Left            =   8640
         Picture         =   "CC_Movimientos.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   12
         Top             =   240
         Width           =   1575
      End
      Begin VB.CommandButton btnCxC 
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
         Left            =   10320
         Picture         =   "CC_Movimientos.frx":06EB
         Style           =   1  'Graphical
         TabIndex        =   13
         Top             =   240
         Width           =   1695
      End
      Begin VB.CommandButton btnAnticipo 
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
         Left            =   10440
         Picture         =   "CC_Movimientos.frx":0CBE
         Style           =   1  'Graphical
         TabIndex        =   11
         Top             =   7800
         Width           =   1695
      End
      Begin VB.Frame Frame2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Datos del Folio"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   6975
         Left            =   120
         TabIndex        =   19
         Top             =   720
         Width           =   12135
         Begin VB.Frame Frame1 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Detalle del Folio"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   2895
            Left            =   120
            TabIndex        =   23
            Top             =   3960
            Width           =   11895
            Begin MSComctlLib.ListView LstMovimientos 
               Height          =   2415
               Left            =   120
               TabIndex        =   5
               Top             =   360
               Width           =   11655
               _ExtentX        =   20558
               _ExtentY        =   4260
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
         End
         Begin VB.TextBox TxtObs 
            Height          =   375
            Left            =   5640
            TabIndex        =   3
            Top             =   480
            Width           =   6135
         End
         Begin VB.TextBox TxtFolio 
            Alignment       =   2  'Center
            Height          =   375
            Left            =   840
            Locked          =   -1  'True
            TabIndex        =   1
            Text            =   "000000"
            Top             =   480
            Width           =   1095
         End
         Begin MSComCtl2.DTPicker DTPFecha 
            Height          =   375
            Left            =   2640
            TabIndex        =   2
            Top             =   480
            Width           =   1455
            _ExtentX        =   2566
            _ExtentY        =   661
            _Version        =   393216
            BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
               Name            =   "Arial"
               Size            =   9.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Format          =   86441985
            CurrentDate     =   39376
         End
         Begin MSComctlLib.ListView LstFolios 
            Height          =   2775
            Left            =   120
            TabIndex        =   4
            Top             =   1080
            Width           =   11895
            _ExtentX        =   20981
            _ExtentY        =   4895
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
         Begin VB.Label Label9 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Descripción"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   225
            Left            =   4440
            TabIndex        =   22
            Top             =   480
            Width           =   990
         End
         Begin VB.Label Label6 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Folio"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   225
            Left            =   240
            TabIndex        =   21
            Top             =   480
            Width           =   405
         End
         Begin VB.Label Label5 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Fecha"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   225
            Left            =   2040
            TabIndex        =   20
            Top             =   480
            Width           =   510
         End
      End
      Begin VB.CommandButton btnImprimeFactura 
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
         Left            =   6960
         Picture         =   "CC_Movimientos.frx":12B6
         Style           =   1  'Graphical
         TabIndex        =   10
         Top             =   7800
         Width           =   1695
      End
      Begin VB.CommandButton btnAplica 
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
         Left            =   5280
         Picture         =   "CC_Movimientos.frx":19D1
         Style           =   1  'Graphical
         TabIndex        =   9
         Top             =   7800
         Width           =   1575
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
         Left            =   1920
         Picture         =   "CC_Movimientos.frx":2068
         Style           =   1  'Graphical
         TabIndex        =   7
         Top             =   7800
         Width           =   1575
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
         Left            =   240
         Picture         =   "CC_Movimientos.frx":2778
         Style           =   1  'Graphical
         TabIndex        =   6
         Top             =   7800
         Width           =   1575
      End
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
         Left            =   3600
         Picture         =   "CC_Movimientos.frx":2E06
         Style           =   1  'Graphical
         TabIndex        =   8
         Top             =   7800
         Width           =   1575
      End
      Begin MSComCtl2.DTPicker DTPPeriodo 
         Height          =   375
         Left            =   2640
         TabIndex        =   0
         Top             =   240
         Width           =   2295
         _ExtentX        =   4048
         _ExtentY        =   661
         _Version        =   393216
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         CustomFormat    =   "MMMM yyyy"
         Format          =   86441987
         CurrentDate     =   39448
         MaxDate         =   73050
         MinDate         =   2
      End
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Seleccione el mes"
         Height          =   255
         Left            =   840
         TabIndex        =   24
         Top             =   240
         Width           =   1695
      End
      Begin VB.Label LblEdicion 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Consulta"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   8880
         TabIndex        =   18
         Top             =   7920
         Width           =   1455
      End
   End
   Begin VB.Frame FrmFacturas 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Documentos Facturados"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   7095
      Left            =   960
      TabIndex        =   15
      Top             =   720
      Visible         =   0   'False
      Width           =   10575
      Begin VB.CommandButton btnClose 
         BackColor       =   &H00FFFFFF&
         Caption         =   "X Cerrar"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   2400
         Style           =   1  'Graphical
         TabIndex        =   16
         Top             =   0
         Width           =   1335
      End
      Begin MSComctlLib.ListView LstFacturas 
         Height          =   6615
         Left            =   120
         TabIndex        =   17
         Top             =   360
         Width           =   10215
         _ExtentX        =   18018
         _ExtentY        =   11668
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
   End
End
Attribute VB_Name = "CC_Movimientos"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Folio As Long, LstDMovimientos, CargoAbono, LstDFolios, Mes, OpcEdita As Boolean

Private Sub btnActualizar_Click()
On Error GoTo Err_NuevoMov:
    
    If LblEdicion.Caption <> "Consulta" Then
        MousePointer = 11
        
        If Trim(TxtObs.Text) = "" Then
            MsgBox "¡ La Descripción del Folio es requerida !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        StrCmd = "execute sel_Periodo 0, " & Year(DTPPeriodo.Value) & ",  " & Month(DTPPeriodo.Value) & ", '', '', 4"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Rs.EOF Then
            MousePointer = 0
            MsgBox "¡ Todos los Periodos están cerrados para todos los Cedis en el mes " & Format(Month(DTPPeriodo.Value), "Mmmm") & " de " & Year(DTPPeriodo.Value) & " !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        ' inserta el movimiento...
        StrCmd = "execute up_Folio " & Folio & ", '" & FormatDate(DTPFecha.Value) & "', 0, '" & Trim(TxtObs.Text) & "', '', '" & Usuario & "', 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
            
        With CC_MovimientosDetalle
        
            .Top = Me.Top + ((Me.Height - .Height) / 2)
            .Left = Me.Left + ((Me.Width - .Width) / 2)
            
            .Inicio = True
            .TxtFecha.Text = TxtFolio.Text & " - " & DTPFecha.Value
            .Folio = Folio
            .Fecha = DTPFecha.Value
            .Aplicado = False
            .Show
        End With
        
        MuestraMovimientos
        LblEdicion.Caption = "Consulta"
    End If
    
No_Err_NuevoMov:
    MousePointer = 0
    Exit Sub
    
Err_NuevoMov:
    MousePointer = 0
    If Err.Number = -2147217873 Then
        MsgBox "¡ El Folio ya ha sido asignado a otro Usuario !", vbInformation + vbOKOnly, App.Title
        StrCmd = "execute sel_Folios 0, '" & Usuario & "', 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            Folio = Rs.Fields(0)
        End If
        
        TxtFolio.Text = Format(Folio, "000000")
    Else
        MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    End If
    GoTo No_Err_NuevoMov:
End Sub

Private Sub btnAnticipo_Click()
On Error Resume Next
    With CC_Anticipos
        .Top = Me.Top + ((Me.Height - .Height) / 2)
        .Left = Me.Left + ((Me.Width - .Width) / 2)
        .Seleccionar = False
        .btnNuevo.Visible = True: .btnActualizar.Visible = True: .btnEliminar.Visible = True
        .btnImprimeFactura.Visible = True: .btnAplica.Visible = True
        .btnSeleccionar.Visible = False
        .Show vbModal
    End With
End Sub

Private Sub btnAplica_Click()
On Error GoTo Err_btnAplica:
    
    If IsEmpty(LstDFolios) Then Exit Sub

    If Trim(UCase(LstFolios.SelectedItem.ListSubItems(5))) <> UCase(Usuario) Then
        MousePointer = 0
        MsgBox "¡ El Movimiento " & LstFolios.SelectedItem & " solo puede ser modificado por el Usuario """ & LstFolios.SelectedItem.ListSubItems(5) & """ !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Trim(UCase(LstFolios.SelectedItem.ListSubItems(4))) = "APLICADO" Or Trim(UCase(LstFolios.SelectedItem.ListSubItems(4))) = "BAJA" Then
        MousePointer = 0
        MsgBox "¡ El Movimiento " & LstFolios.SelectedItem & " tiene Status """ & LstFolios.SelectedItem.ListSubItems(4) & """ !. No puede ejecutar esta acción. ", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    StrCmd = "execute sel_MovimientosFacturas 0, " & LstFolios.SelectedItem & ", '19000101', '', 3"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    While Not RsC.EOF
        If Not ValidaPeriodo(RsC.Fields(0), Year(RsC.Fields(1)), Month(RsC.Fields(1)), "C", "", 1) Then
            MsgBox "Cedis " & RsC.Fields(0) & " - " & RsC.Fields(2) & ". ¡ " & strPeriodo & " !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
    RsC.MoveNext
    Wend
    
    If MsgBox("Una vez Aplicado el Movimiento " & LstFolios.SelectedItem & " ya NO podrá modificarse. ¿Desea continuar?", vbQuestion + vbYesNo, App.Title) = vbNo Then
        MousePointer = 0
        Exit Sub
    End If

    MousePointer = 11
    
    StrCmd = "execute up_Folio " & LstFolios.SelectedItem & ", '19000101', 0, '', 'B', '" & Usuario & "',  5"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    
    MuestraMovimientos
    MsgBox "¡ Movimiento Aplicado !", vbInformation + vbOKOnly, App.Title

No_Err_btnAplica:
    MousePointer = 0
    Exit Sub
    
Err_btnAplica:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_btnAplica:
End Sub

Private Sub btnBuscar_Click()
    With CC_ListaVentas
        .LstDVentas = Empty
        .LstVentas.ListItems.Clear
        .TxtFolio.Text = "": .TxtSerie.Text = ""
        .TxtFolioCliente.Text = "": .TxtFolioEntrega.Text = ""
        .TxtFactura.Text = "": .TxtRemision.Text = ""
        .Tag = "1"
        .Top = Me.Top + ((Me.Height - .Height) / 2)
        .Left = Me.Left + ((Me.Width - .Width) / 2)
        .Show vbModal
    End With
End Sub

Private Sub btnCxC_Click()
On Error Resume Next
    With CC_Cat_CxC
        .Top = Me.Top + ((Me.Height - .Height) / 2)
        .Left = Me.Left + ((Me.Width - .Width) / 2)
        .Show vbModal
    End With
End Sub

Private Sub btnEliminar_Click()
On Error GoTo Err_btnEliminar:

    If LblEdicion.Caption = "Nuevo" Then
        TxtFolio.Text = "000000": TxtObs.Text = ""
        TxtReferencia.Text = "": TxtReferenciaBancos.Text = ""
        DTPFecha.Value = Date
        
        LblEdicion.Caption = "Consulta"
        Exit Sub
    Else
        
        If Not ValidaModulo("BAJA", True) Then Exit Sub
        If IsEmpty(LstDFolios) Then Exit Sub
        
        If Trim(UCase(LstFolios.SelectedItem.ListSubItems(5))) <> UCase(Usuario) Then
            MousePointer = 0
            MsgBox "¡ El Movimiento " & LstFolios.SelectedItem & " solo puede ser modificado por el Usuario """ & LstFolios.SelectedItem.ListSubItems(5) & """ !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If Trim(UCase(LstFolios.SelectedItem.ListSubItems(4))) = "APLICADO" Or Trim(UCase(LstFolios.SelectedItem.ListSubItems(4))) = "BAJA" Then
            MousePointer = 0
            MsgBox "¡ El Movimiento " & LstFolios.SelectedItem & " tiene Status """ & LstFolios.SelectedItem.ListSubItems(4) & """ !. No puede ejecutar esta acción. ", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        StrCmd = "execute sel_MovimientosFacturas 0, " & LstFolios.SelectedItem & ", '19000101', '', 3"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        While Not RsC.EOF
            If Not ValidaPeriodo(RsC.Fields(0), Year(RsC.Fields(1)), Month(RsC.Fields(1)), "C", "", 1) Then
                MsgBox "Cedis " & RsC.Fields(0) & " - " & RsC.Fields(2) & ". ¡ " & strPeriodo & " !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        RsC.MoveNext
        Wend
        
        If MsgBox("El Movimiento " & LstFolios.SelectedItem & " ya NO podrá modificarse. ¿Desea continuar?", vbQuestion + vbYesNo, App.Title) = vbNo Then
            MousePointer = 0
            Exit Sub
        End If
        
        MousePointer = 11
        StrCmd = "execute up_Folio " & LstFolios.SelectedItem & ", '19000101', 0, '', 'B', '" & Usuario & "',  3"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        
        MuestraMovimientos
        MsgBox "¡ Movimiento Cancelado !", vbInformation + vbOKOnly, App.Title
        
    End If

No_Err_btnEliminar:
    MousePointer = 0
    Exit Sub
    
Err_btnEliminar:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_btnEliminar:
    
End Sub

Private Sub btnImprimeFactura_Click()
On Error GoTo btnImprimeMovimiento:
    
    If IsEmpty(LstMovimientos) Then Exit Sub
    
    If Trim(UCase(LstFolios.SelectedItem.ListSubItems(4))) = "BAJA" Then
        MousePointer = 0
        MsgBox "¡ El Movimiento " & LstFolios.SelectedItem & " tiene Status """ & LstFolios.SelectedItem.ListSubItems(4) & """ !. No puede ejecutar esta acción. ", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    With CC_RptMovimiento
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
        .LblTitulo.Caption = "REPORTE DE MOVIMIENTOS A VENTAS"
        
        StrCmd = "execute Rep_Movimientos " & Folio & ", '01/01/1900', '01/01/1900', 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If Not RsC.EOF Then
            .object.DataSrc.DataSourceName = Cnn
            .object.DataSrc.Recordset = RsC
        End If
        
        .Printer.Orientation = ddOPortrait
        .Printer.PaperSize = 1
        .Show
    End With
    
No_btnImprimeMovimiento:
    MousePointer = 0
    Exit Sub
    
btnImprimeMovimiento:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_btnImprimeMovimiento:
    
End Sub

Private Sub btnNuevo_Click()
On Error Resume Next
    
    StrCmd = "execute sel_Folios 0, '" & Usuario & "', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        Folio = Rs.Fields(0)
    End If
    
    TxtFolio.Text = Format(Folio, "000000"): TxtObs.Text = ""
    DTPFecha.Value = Date
    
    LblEdicion.Caption = "Nuevo"
End Sub

Private Sub Command1_Click()

End Sub

Private Sub DTPPeriodo_Change()
On Error Resume Next
    Mes = Month(DTPPeriodo.Value)
    If Month(DTPPeriodo.Value) = 12 Then
        DTPFecha.MaxDate = CDate(Year(DTPPeriodo.Value) & "-" & Month(DTPPeriodo.Value) & "-" & "31")
    Else
        DTPFecha.MaxDate = CDate(Year(DTPPeriodo.Value) & "-" & (Month(DTPPeriodo.Value) + 1) & "-" & "01") - 1
    End If
    DTPFecha.MinDate = CDate(Year(DTPPeriodo.Value) & "-" & Format(Month(DTPPeriodo.Value), "00") & "-" & "01")
    DTPFecha.Value = CDate(Year(DTPPeriodo.Value) & "-" & Format(Month(DTPPeriodo.Value), "00") & "-" & "01")
    If Month(DTPPeriodo.Value) = 12 Then
        DTPFecha.MaxDate = CDate(Year(DTPPeriodo.Value) & "-" & Month(DTPPeriodo.Value) & "-" & "31")
    Else
        DTPFecha.MaxDate = CDate(Year(DTPPeriodo.Value) & "-" & (Month(DTPPeriodo.Value) + 1) & "-" & "01") - 1
    End If
    MuestraMovimientos
End Sub

Private Sub Form_Load()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    DTPPeriodo.Value = Date
    Mes = Month(DTPPeriodo.Value)
    If Month(DTPPeriodo.Value) = 12 Then
        DTPFecha.MaxDate = CDate(Year(DTPPeriodo.Value) & "-" & Month(DTPPeriodo.Value) & "-" & "31")
    Else
        DTPFecha.MaxDate = CDate(Year(DTPPeriodo.Value) & "-" & (Month(DTPPeriodo.Value) + 1) & "-" & "01") - 1
    End If
    DTPFecha.MinDate = CDate(Year(DTPPeriodo.Value) & "-" & Format(Month(DTPPeriodo.Value), "00") & "-" & "01")
    DTPFecha.Value = CDate(Year(DTPPeriodo.Value) & "-" & Format(Month(DTPPeriodo.Value), "00") & "-" & "01")
    If Month(DTPPeriodo.Value) = 12 Then
        DTPFecha.MaxDate = CDate(Year(DTPPeriodo.Value) & "-" & Month(DTPPeriodo.Value) & "-" & "31")
    Else
        DTPFecha.MaxDate = CDate(Year(DTPPeriodo.Value) & "-" & (Month(DTPPeriodo.Value) + 1) & "-" & "01") - 1
    End If
    MuestraMovimientos
End Sub

Sub MuestraMovimientos()
On Error Resume Next
        
    If IsEmpty(Mes) Then Mes = Month(Date)
        
    StrCmd = "execute sel_Folios " & Mes & ", '" & Usuario & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDFolios = GetDataLVL(Rs, LstFolios, 1, 7, "0|0|9|0|0|0|0")
    LstFolios_ItemClick LstFolios.SelectedItem
    
End Sub

Private Sub LstFolios_DblClick()
On Error Resume Next

        If Mid(LstFolios.SelectedItem.ListSubItems(4), 1, 1) = "B" Then Exit Sub

        With CC_MovimientosDetalle
        
            .Top = Me.Top + ((Me.Height - .Height) / 2)
            .Left = Me.Left + ((Me.Width - .Width) / 2)
            
            .Inicio = True
    
            .TxtFecha.Text = TxtFolio.Text & " - " & DTPFecha.Value
            .Folio = CLng(LstFolios.SelectedItem)
            .Fecha = CDate(LstFolios.SelectedItem.ListSubItems(1))
            .Aplicado = IIf(Trim(UCase(LstFolios.SelectedItem.ListSubItems(4))) = "APLICADO" Or Trim(UCase(LstFolios.SelectedItem.ListSubItems(4))) = "BAJA", True, False)
            
            .Show vbModal
        End With
End Sub

Private Sub LstFolios_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    Folio = 0
    If IsEmpty(LstDFolios) Then
        LstMovimientos.ListItems.Clear
        LstDMovimientos = Empty
        Exit Sub
    End If
    
    TxtFolio.Text = LstDFolios(1, LstFolios.SelectedItem.Index - 1)
    Folio = LstDFolios(1, LstFolios.SelectedItem.Index - 1)
    DTPFecha.Value = LstDFolios(2, LstFolios.SelectedItem.Index - 1)
    TxtObs.Text = LstDFolios(4, LstFolios.SelectedItem.Index - 1)
    LblEdicion.Caption = "Consulta"
    
    StrCmd = "execute sel_Movimientos " & Mes & ", " & Folio & ", '" & Usuario & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDMovimientos = GetDataLVL(Rs, LstMovimientos, 0, 8, "0|0|0|0|0|0|0|9|0")
    
End Sub

Private Sub LstMovimientos_Click()
On Error Resume Next
    LblEdicion.Caption = "Consulta"
End Sub

Private Sub TxtObs_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

