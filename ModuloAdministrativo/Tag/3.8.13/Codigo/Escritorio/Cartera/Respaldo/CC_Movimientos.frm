VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_Movimientos 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Aplicación de Movimientos a Facturas"
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
      TabIndex        =   8
      Top             =   0
      Width           =   12375
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
         Picture         =   "CC_Movimientos.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   32
         Top             =   7560
         Width           =   1575
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
         Picture         =   "CC_Movimientos.frx":071B
         Style           =   1  'Graphical
         TabIndex        =   31
         Top             =   7560
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
         Picture         =   "CC_Movimientos.frx":0DB2
         Style           =   1  'Graphical
         TabIndex        =   30
         Top             =   7560
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
         Picture         =   "CC_Movimientos.frx":14C2
         Style           =   1  'Graphical
         TabIndex        =   29
         Top             =   7560
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
         Picture         =   "CC_Movimientos.frx":1B50
         Style           =   1  'Graphical
         TabIndex        =   28
         Top             =   7560
         Width           =   1575
      End
      Begin VB.CommandButton btnArchivo 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Aplicar desde Archivo"
         Height          =   375
         Left            =   9720
         Style           =   1  'Graphical
         TabIndex        =   25
         Top             =   600
         Width           =   2415
      End
      Begin VB.ComboBox CmbTipoDocumento 
         Height          =   360
         Left            =   7800
         Style           =   2  'Dropdown List
         TabIndex        =   21
         Top             =   480
         Visible         =   0   'False
         Width           =   4335
      End
      Begin VB.Frame FrmDatos 
         BackColor       =   &H00FFFFFF&
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   2055
         Left            =   120
         TabIndex        =   14
         Top             =   960
         Width           =   12135
         Begin VB.ComboBox CmbDocumento 
            Height          =   360
            Left            =   6240
            Style           =   2  'Dropdown List
            TabIndex        =   26
            Top             =   360
            Width           =   4335
         End
         Begin VB.CommandButton btnFacturas 
            BackColor       =   &H00FFFFFF&
            Height          =   495
            Left            =   10800
            Picture         =   "CC_Movimientos.frx":24E6
            Style           =   1  'Graphical
            TabIndex        =   24
            Top             =   240
            Width           =   495
         End
         Begin VB.ComboBox cmbCedis 
            Height          =   360
            Left            =   960
            Style           =   2  'Dropdown List
            TabIndex        =   1
            Top             =   360
            Width           =   3855
         End
         Begin VB.TextBox TxtObs 
            Height          =   375
            Left            =   1560
            TabIndex        =   6
            Top             =   1560
            Width           =   10095
         End
         Begin VB.TextBox TxtReferenciaBancos 
            Alignment       =   1  'Right Justify
            Enabled         =   0   'False
            Height          =   375
            Left            =   8160
            TabIndex        =   5
            Top             =   960
            Width           =   1095
         End
         Begin VB.TextBox TxtReferencia 
            Alignment       =   1  'Right Justify
            Enabled         =   0   'False
            Height          =   375
            Left            =   5160
            TabIndex        =   4
            Top             =   960
            Width           =   1095
         End
         Begin VB.TextBox TxtFolio 
            Alignment       =   2  'Center
            Height          =   375
            Left            =   720
            Locked          =   -1  'True
            TabIndex        =   2
            Text            =   "000000"
            Top             =   960
            Width           =   1095
         End
         Begin MSComCtl2.DTPicker DTPFecha 
            Height          =   375
            Left            =   2640
            TabIndex        =   3
            Top             =   960
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
            Format          =   125501441
            CurrentDate     =   39376
         End
         Begin VB.Label Label1 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Documento"
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
            Left            =   5160
            TabIndex        =   27
            Top             =   360
            Width           =   960
         End
         Begin VB.Label Label4 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cedis"
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
            TabIndex        =   23
            Top             =   360
            Width           =   615
         End
         Begin VB.Label Label9 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Observaciones"
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
            TabIndex        =   19
            Top             =   1560
            Width           =   1245
         End
         Begin VB.Label Label8 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Referencia Bancos"
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
            Left            =   6480
            TabIndex        =   18
            Top             =   960
            Width           =   1575
         End
         Begin VB.Label Label7 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Referencia"
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
            Left            =   4200
            TabIndex        =   17
            Top             =   960
            Width           =   900
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
            TabIndex        =   16
            Top             =   960
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
            TabIndex        =   15
            Top             =   960
            Width           =   510
         End
      End
      Begin MSComctlLib.ListView LstMovimientos 
         Height          =   4095
         Left            =   120
         TabIndex        =   7
         Top             =   3120
         Width           =   12135
         _ExtentX        =   21405
         _ExtentY        =   7223
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
      Begin MSComCtl2.DTPicker DTPPeriodo 
         Height          =   375
         Left            =   2040
         TabIndex        =   0
         Top             =   360
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
         Format          =   125501443
         CurrentDate     =   39448
         MaxDate         =   39813
         MinDate         =   39448
      End
      Begin VB.Label Label3 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Tipo de Documento"
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
         Left            =   7920
         TabIndex        =   22
         Top             =   240
         Visible         =   0   'False
         Width           =   1620
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
         ForeColor       =   &H000000C0&
         Height          =   255
         Left            =   8880
         TabIndex        =   20
         Top             =   7680
         Width           =   2295
      End
      Begin VB.Label LblPeriodo 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Estatus del Periodo"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9.75
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000000C0&
         Height          =   255
         Left            =   4560
         TabIndex        =   13
         Top             =   360
         Width           =   6615
      End
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Seleccione el mes"
         Height          =   255
         Left            =   240
         TabIndex        =   9
         Top             =   360
         Width           =   1695
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
      TabIndex        =   10
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
         TabIndex        =   11
         Top             =   0
         Width           =   1335
      End
      Begin MSComctlLib.ListView LstFacturas 
         Height          =   6615
         Left            =   120
         TabIndex        =   12
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
Dim lstDCedis, LstDDocumento, LstDTipoDocumento, LstDMovimientos, IdMovimiento, CargoAbono
Dim IdDocSaldar, IdTipoDocSaldar, TipoDocSaldar

Private Sub btnActualizar_Click()
On eror GoTo Err_NuevoMov:
    
    If Not ValidaPeriodo(lstDCedis(0, cmbCedis.ListIndex - 1), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1) Then
        MsgBox "¡ " & StrPeriodo & " !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If LblEdicion.Caption <> "Consulta" Then
        If cmbCedis.ListIndex = 0 Or CmbDocumento.ListIndex = 0 Then
            MsgBox "¡ Seleccione un Cedis y un Documento !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
                
        MousePointer = 11
        
        If Mid(LstDDocumento(0, CmbDocumento.ListIndex - 1), 1, 1) = "P" And (Trim(TxtReferencia.Text) = "" Or Trim(TxtReferenciaBancos.Text) = "") Then
            MsgBox "¡ Debes capturar una Referencia y Referencia de Bancos para poder Aplicar un Pago !", vbInformation + vbOKOnly, App.Title
            MousePointer = 0
            Exit Sub
        End If
                
        ' Obtiene el Nuevo Documento para Asignar los Movimientos
        StrCmd = " select isnull( max(IdMovimiento)+ 1, 1) from Movimientos where IdCedis = " & CLng(lstDCedis(0, cmbCedis.ListIndex - 1))
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If RsC.EOF Then
            MousePointer = 0
            MsgBox "¡ No se encontró un nuevo Folio de Movimiento !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        Else
            IdMovimiento = RsC.Fields(0)
            CargoAbono = Trim(LstDDocumento(2, CmbDocumento.ListIndex - 1))
        End If
        
        ' inserta el movimiento...
        StrCmd = "execute up_Movimientos " & CLng(lstDCedis(0, cmbCedis.ListIndex - 1)) & ", " & IdMovimiento & ", '" & IIf(BIdioma = "us_english", Format(DTPFecha.Value, "mm/dd/yyyy"), Format(DTPFecha.Value, "dd/mm/yyyy")) & "', '" & Trim(LstDDocumento(0, CmbDocumento.ListIndex - 1)) & "', '" & CargoAbono & "', 0, '" & Trim(TxtReferencia.Text) & "', '" & Trim(TxtReferenciaBancos.Text) & "', '" & Trim(TxtObs.Text) & "', '', '" & Usuario & "', 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        
        MuestraMovimientos
        
        If Trim(LstDDocumento(0, CmbDocumento.ListIndex - 1)) = IdDocSaldar Then
            With CC_SaldarFacturas
            
                .Top = Me.Top + ((Me.Height - .Height) / 2)
                .Left = Me.Left + ((Me.Width - .Width) / 2)
        
                .TxtCedis.Text = lstDCedis(0, cmbCedis.ListIndex - 1) & " - " & lstDCedis(1, cmbCedis.ListIndex - 1)
                .TxtDocumentos.Text = "Folio: " & Format(IdMovimiento, "000000") & ". Documento: " & LstDDocumento(0, CmbDocumento.ListIndex - 1) & ".- " & CmbDocumento.Text
                .TxtFecha.Text = DTPFecha.Value
                
                .IdCedis = CLng(lstDCedis(0, cmbCedis.ListIndex - 1))
                .IdDocumento = IdDocSaldar
                .IdTipoDocumento = IdTipoDocSaldar
                .IdMovimiento = IdMovimiento
                .TxtDocumentos.Text = IdTipoDocSaldar & ".- " & TipoDocSaldar
                
                .Fecha = CDate(DTPFecha.Value)
                .CargoAbono = CargoAbono
                
                .DTPFechaInicial.Value = CDate(DTPFecha.Value)
                .DTPFechaFinal.Value = CDate(DTPFecha.Value)
                                
                MousePointer = 0
                .Show
            End With
        Else
            With CC_MovimientosDetalle
            
                .Top = Me.Top + ((Me.Height - .Height) / 2)
                .Left = Me.Left + ((Me.Width - .Width) / 2)
                
                .Inicio = True
        
                .TxtCedis.Text = lstDCedis(0, cmbCedis.ListIndex - 1) & " - " & lstDCedis(1, cmbCedis.ListIndex - 1)
                .TxtDocumentos.Text = "Folio: " & Format(IdMovimiento, "000000") & ". Documento: " & LstDDocumento(0, CmbDocumento.ListIndex - 1) & ".- " & CmbDocumento.Text
                .TxtFecha.Text = DTPFecha.Value
                .TxtReferencia.Text = Trim(TxtReferencia.Text)
                .TxtReferenciaBancos.Text = Trim(TxtReferenciaBancos.Text)
                
                .IdCedis = CLng(lstDCedis(0, cmbCedis.ListIndex - 1))
                .IdDocumento = Trim(LstDDocumento(0, CmbDocumento.ListIndex - 1))
                .IdMovimiento = IdMovimiento
                .Fecha = CDate(DTPFecha.Value)
                .CargoAbono = CargoAbono
                
                '.btnArchivo.Visible = IIf(Mid(Trim(LstDDocumento(0, CmbDocumento.ListIndex - 1)), 1, 1) = "P", True, False)
                
                MousePointer = 0
                .Show
            End With
        End If
    End If
    
No_Err_NuevoMov:
    MousePointer = 0
    Exit Sub
    
Err_NuevoMov:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_NuevoMov:
End Sub

Private Sub btnAplica_Click()
On Error GoTo Err_btnAplica:
    
    If IsEmpty(LstDMovimientos) Then Exit Sub

    If Not ValidaPeriodo(lstDCedis(0, cmbCedis.ListIndex - 1), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1) Then
        MsgBox "¡ " & StrPeriodo & " !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    If UCase(Trim(LstMovimientos.SelectedItem.ListSubItems(6))) = "APLICADO" Then
        MsgBox "¡ Documento Aplicado. No se puede modificar !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    If MsgBox("Una vez Aplicado el Movimiento " & LstMovimientos.SelectedItem & " ya NO podrá modificarse. ¿Desea continuar?", vbQuestion + vbYesNo, App.Title) = vbYes Then
        If MsgBox("El Movimiento " & LstMovimientos.SelectedItem & " ya NO podrá modificarse. ¿Desea continuar?", vbQuestion + vbYesNo, App.Title) = vbNo Then
            MousePointer = 0
            Exit Sub
        End If
    Else
            MousePointer = 0
            Exit Sub
    End If

    MousePointer = 11
    
    StrCmd = "execute up_Movimientos " & lstDCedis(0, cmbCedis.ListIndex - 1) & ", " & CLng(LstMovimientos.SelectedItem) & ", '" & IIf(BIdioma = "us_english", Format(CDate(LstMovimientos.SelectedItem.ListSubItems(1)), "mm/dd/yyyy"), Format(CDate(LstMovimientos.SelectedItem.ListSubItems(1)), "dd/mm/yyyy")) & "', '', '', 0, '', '', '', 'A', '" & Usuario & "',  5"
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

Private Sub btnEliminar_Click()
On Error GoTo Err_btnEliminar:

    If btnEliminar.Caption = "&Cancelar" Then
        TxtFolio.Text = "000000": TxtObs.Text = ""
        TxtReferencia.Text = "": TxtReferenciaBancos.Text = ""
        DTPFecha.Value = Date
        
        LblEdicion.Caption = "Consulta"
        btnEliminar.Caption = "&Eliminar"
        Exit Sub
    Else
        
        If Not ValidaModulo("BAJA", True) Then Exit Sub
        If IsEmpty(LstDMovimientos) Then Exit Sub
        
        If Not ValidaPeriodo(lstDCedis(0, cmbCedis.ListIndex - 1), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1) Then
            MsgBox "¡ " & StrPeriodo & " !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
    
'        If UCase(Trim(LstMovimientos.SelectedItem.ListSubItems(6))) = "APLICADO" Then
'            MsgBox "¡ Documento Aplicado. No se puede modificar !", vbInformation + vbOKOnly, App.Title
'            Exit Sub
'        End If
    
        If MsgBox("El Movimiento " & LstMovimientos.SelectedItem & " ya NO podrá modificarse. ¿Desea continuar?", vbQuestion + vbYesNo, App.Title) = vbNo Then
            MousePointer = 0
            Exit Sub
        End If
        
        MousePointer = 11
    
'        StrCmd = "execute sel_MovimientosFacturas " & LstDCedis(0, cmbCedis.ListIndex - 1) & ", " & CLng(LstMovimientos.SelectedItem) & ", '" & IIf(BIdioma = "us_english", Format(CDate(LstMovimientos.SelectedItem.ListSubItems(1)), "mm/dd/yyyy"), Format(CDate(LstMovimientos.SelectedItem.ListSubItems(1)), "dd/mm/yyyy")) & "', '" & Trim(LstDDocumento(0, CmbDocumento.ListIndex - 1)) & "', 1"
'        If RsC.State Then RsC.Close
'        RsC.Open StrCmd, Cnn
'        If Not RsC.EOF Then
'            MousePointer = 0
'            MsgBox "¡ El Movimiento tiene documentos generados. Elimina los Movimientos antes de continuar !", vbInformation + vbOKOnly, App.Title
'            Exit Sub
'        End If
        
        StrCmd = "execute up_Movimientos " & lstDCedis(0, cmbCedis.ListIndex - 1) & ", " & CLng(LstMovimientos.SelectedItem) & ", '" & IIf(BIdioma = "us_english", Format(CDate(LstMovimientos.SelectedItem.ListSubItems(1)), "mm/dd/yyyy"), Format(CDate(LstMovimientos.SelectedItem.ListSubItems(1)), "dd/mm/yyyy")) & "', '', '', 0, '', '', '', 'B', '" & Usuario & "',  3"
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

Private Sub btnFacturas_Click()
On Error Resume Next
    BusquedaDeFactura Top, Left, Width, Height
End Sub

Private Sub btnImprimeFactura_Click()
    If IsEmpty(LstMovimientos) Then Exit Sub

On Error GoTo btnImprimeFactura:
    With CC_RptMovimiento
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
        .LblTitulo.Caption = "REPORTE DE MOVIMIENTOS A FACTURAS"
        .LblDatos.Caption = "Tipo de Movimiento: " & LstMovimientos.SelectedItem.ListSubItems(2) & " - " & LstMovimientos.SelectedItem.ListSubItems(3) & "     " & Format(LstMovimientos.SelectedItem.ListSubItems(1), ctFechaLarga)
        .LblCedis.Caption = lstDCedis(0, cmbCedis.ListIndex - 1) & " - " & lstDCedis(1, cmbCedis.ListIndex - 1)
        
        StrCmd = "execute Rep_Movimientos " & CLng(LstDMovimientos(0, LstMovimientos.SelectedItem.Index - 1)) & ", " & CLng(LstDMovimientos(1, LstMovimientos.SelectedItem.Index - 1)) & ", '01/01/1900', '01/01/1900', 1"
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
    
No_btnImprimeFactura:
    MousePointer = 0
    Exit Sub
    
btnImprimeFactura:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_btnImprimeFactura:
    
End Sub

Private Sub btnNuevo_Click()
On Error Resume Next
    
    If Not ValidaPeriodo(lstDCedis(0, cmbCedis.ListIndex - 1), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1) Then
        MsgBox "¡ " & StrPeriodo & " !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If IsEmpty(lstDCedis) Then
        MsgBox "¡ Seleccione un Cedis !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    Else
        If cmbCedis.ListIndex = 0 Then
            MsgBox "¡ Seleccione un Cedis !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
    End If
    
    TxtFolio.Text = "000000": TxtObs.Text = ""
    TxtReferencia.Text = "": TxtReferenciaBancos.Text = ""
    DTPFecha.Value = Date
    
    LblPeriodo.Caption = StrPeriodo
    LblEdicion.Caption = "Nuevo Movimiento"
    btnEliminar.Caption = "&Cancelar"
End Sub

Private Sub cmbCedis_Click()
On Error Resume Next
    If IsEmpty(lstDCedis) Then Exit Sub
       
    If Not ValidaPeriodo(lstDCedis(0, cmbCedis.ListIndex - 1), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1) Then
        MsgBox "¡ No se pueden hacer movimientos en un periodo que ya está cerrado !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    LblPeriodo.Caption = StrPeriodo
End Sub

Private Sub CmbDocumento_Click()
On Error Resume Next
    If IsEmpty(LstDDocumento) Or IsEmpty(lstDCedis) Then Exit Sub
    If cmbCedis.ListIndex = 0 Or CmbDocumento.ListIndex = 0 Then
        MsgBox "¡ Seleccione un Cedis y un Documento !", vbInformation + vbOKOnly, App.Title
        LstMovimientos.ListItems.Clear
        Exit Sub
    End If
    MuestraMovimientos
End Sub

Private Sub DTPPeriodo_Change()
On Error Resume Next
    ValidaPeriodo lstDCedis(0, cmbCedis.ListIndex - 1), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1
    LblPeriodo.Caption = StrPeriodo
    DTPFecha.MinDate = CDate("01/" & Month(DTPPeriodo.Value) & "/" & Year(DTPPeriodo.Value))
    If Month(DTPPeriodo.Value) = 12 Then
        DTPFecha.MaxDate = CDate("01/01/" & Year(DTPPeriodo.Value) + 1) - 1
    Else
        DTPFecha.MaxDate = CDate("01/" & Month(DTPPeriodo.Value) + 1 & "/" & Year(DTPPeriodo.Value)) - 1
    End If
    DTPFecha.Value = DTPPeriodo.Value
    
    MuestraMovimientos
End Sub

Private Sub Form_Activate()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
End Sub

Private Sub Form_Load()
On Error Resume Next
    
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    Date = Date
    
    DTPPeriodo.MinDate = CDate("01/" & Month(Date) & "/" & Year(Date) - 1)
    DTPPeriodo.MaxDate = CDate("01/01/" & Year(Date) + 1) - 1
    DTPPeriodo.Value = CDate("01/" & Month(Date) & "/" & Year(Date))
    
    DTPFecha.MinDate = CDate("01/" & Month(Date) & "/" & Year(Date))
    If Month(Date) = 12 Then
        DTPFecha.MaxDate = CDate("01/01/" & Year(Date) + 1) - 1
    Else
        DTPFecha.MaxDate = CDate("01/" & Month(Date) + 1 & "/" & Year(Date)) - 1
    End If
    
    btnArchivo.Enabled = ValidaModulo("ARCH", False)
    
    MuestraCedis
    MuestraDocumentos
    DocumentoSaldarFacturas
    
End Sub

Sub MuestraCedis()
On Error Resume Next
    StrCmd = "execute sel_CedisUsuarios '" & Usuario & "', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    lstDCedis = GetDataCBL(Rs, cmbCedis, "Seleccione un Cedis", "No hay Cedis asigandos")
End Sub

Sub MuestraDocumentos()
On Error Resume Next
    StrCmd = "execute sel_Documentos '" & Usuario & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDDocumento = GetDataCBL(Rs, CmbDocumento, "Seleccione un Documento", "No hay Documentos")
End Sub

Sub MuestraMovimientos()
On Error Resume Next
    If CmbDocumento.ListIndex > 0 Then
        TxtReferencia.Text = IIf(Mid(LstDDocumento(0, CmbDocumento.ListIndex - 1), 1, 1) = "P", TxtReferencia.Text, "")
        TxtReferenciaBancos.Text = IIf(Mid(LstDDocumento(0, CmbDocumento.ListIndex - 1), 1, 1) = "P", TxtReferenciaBancos.Text, "")
        TxtReferencia.Enabled = IIf(Mid(LstDDocumento(0, CmbDocumento.ListIndex - 1), 1, 1) = "P", True, False)
        TxtReferenciaBancos.Enabled = IIf(Mid(LstDDocumento(0, CmbDocumento.ListIndex - 1), 1, 1) = "P", True, False)
        StrCmd = "execute sel_Movimientos " & Month(DTPPeriodo.Value) & ", " & CLng(lstDCedis(0, cmbCedis.ListIndex - 1)) & ", '" & LstDDocumento(0, CmbDocumento.ListIndex - 1) & "', 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        LstDMovimientos = GetDataLVL(Rs, LstMovimientos, 1, 7, "0|0|0|0|0|3|0")
    Else
        LstDMovimientos = Empty: LstMovimientos.ListItems.Clear
    End If
End Sub

Private Sub LstMovimientos_Click()
On Error Resume Next
    If IsEmpty(LstDMovimientos) Then Exit Sub
    
    TxtFolio.Text = LstMovimientos.SelectedItem
    DTPFecha.Value = LstMovimientos.SelectedItem.ListSubItems(1)
    TxtObs.Text = LstDMovimientos(8, LstMovimientos.SelectedItem.Index - 1)
    TxtReferencia.Text = LstDMovimientos(9, LstMovimientos.SelectedItem.Index - 1)
    TxtReferenciaBancos.Text = LstDMovimientos(10, LstMovimientos.SelectedItem.Index - 1)
End Sub

Private Sub LstMovimientos_DblClick()
On Error Resume Next
If IsEmpty(LstDMovimientos) Then Exit Sub

    If Trim(LstMovimientos.SelectedItem.ListSubItems(2)) = IdDocSaldar Then
        With CC_SaldarFacturas
        
            .Top = Me.Top + ((Me.Height - .Height) / 2)
            .Left = Me.Left + ((Me.Width - .Width) / 2)
    
            .TxtCedis.Text = lstDCedis(0, cmbCedis.ListIndex - 1) & " - " & lstDCedis(1, cmbCedis.ListIndex - 1)
            .TxtDocumentos.Text = "Folio: " & Format(CLng(LstMovimientos.SelectedItem), "000000") & ". Documento: " & LstDDocumento(0, CmbDocumento.ListIndex - 1) & ".- " & CmbDocumento.Text
            .TxtFecha.Text = DTPFecha.Value
            
            .DTPFechaInicial.Value = CDate("01/" & Month(DTPFecha.Value) & "/" & Year(DTPFecha.Value))
            .DTPFechaFinal.Value = DTPFecha.Value
            
            .IdCedis = CLng(lstDCedis(0, cmbCedis.ListIndex - 1))
            .IdDocumento = IdDocSaldar
            .IdTipoDocumento = IdTipoDocSaldar
            .IdMovimiento = CLng(LstMovimientos.SelectedItem)
            .TxtDocumentos.Text = IdTipoDocSaldar & ".- " & TipoDocSaldar
            
            .Fecha = CDate(DTPFecha.Value)
            .CargoAbono = CargoAbono
            .Aplicado = IIf(Trim(UCase(LstMovimientos.SelectedItem.ListSubItems(6))) = "APLICADO" Or Trim(UCase(LstMovimientos.SelectedItem.ListSubItems(6))) = "BAJA", True, False)
            
            MousePointer = 0
            .Show
        End With
    Else
        With CC_MovimientosDetalle
        
            .Top = Me.Top + ((Me.Height - .Height) / 2)
            .Left = Me.Left + ((Me.Width - .Width) / 2)
            
            .Inicio = True
    
            .TxtCedis.Text = lstDCedis(0, cmbCedis.ListIndex - 1) & " - " & lstDCedis(1, cmbCedis.ListIndex - 1)
            .TxtDocumentos.Text = "Folio: " & Format(CLng(LstMovimientos.SelectedItem), "000000") & ". Documento: " & LstDDocumento(0, CmbDocumento.ListIndex - 1) & ".- " & CmbDocumento.Text
            .TxtFecha.Text = DTPFecha.Value
            .TxtReferencia.Text = LstDMovimientos(9, LstMovimientos.SelectedItem.Index - 1)
            .TxtReferenciaBancos.Text = LstDMovimientos(10, LstMovimientos.SelectedItem.Index - 1)
            
            .IdCedis = CLng(lstDCedis(0, cmbCedis.ListIndex - 1))
            .IdDocumento = Trim(LstDDocumento(0, CmbDocumento.ListIndex - 1))
            .IdMovimiento = CLng(LstMovimientos.SelectedItem)
            .Fecha = CDate(LstMovimientos.SelectedItem.ListSubItems(1))
            .CargoAbono = Mid(Trim(LstMovimientos.SelectedItem.ListSubItems(4)), 1, 1)
            .Aplicado = IIf(Trim(UCase(LstMovimientos.SelectedItem.ListSubItems(6))) = "APLICADO" Or Trim(UCase(LstMovimientos.SelectedItem.ListSubItems(6))) = "BAJA", True, False)
            
            '.btnArchivo.Visible = IIf(Mid(Trim(LstDDocumento(0, CmbDocumento.ListIndex - 1)), 1, 1) = "P", True, False)
            
            .Show
        End With
    End If
End Sub

Sub DocumentoSaldarFacturas()
On Error Resume Next
    StrCmd = "select isnull(Configuracion.IdDocumentoSaldar, ''), isnull(Configuracion.IdTipoDocumentoSaldar, ''), isnull(TipoDocumento, '') from Configuracion inner join DocumentosTipo on Configuracion.IdTipoDocumentoSaldar = DocumentosTipo.IdTipoDocumento and Configuracion.IdDocumentoSaldar = DocumentosTipo.IdDocumento "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        IdDocSaldar = Rs.Fields(0)
        IdTipoDocSaldar = Rs.Fields(1)
        TipoDocSaldar = Rs.Fields(2)
    End If
End Sub

Private Sub LstMovimientos_KeyUp(KeyCode As Integer, Shift As Integer)
On Error Resume Next
    LstMovimientos_Click
End Sub

Private Sub TxtReferencia_Validate(Cancel As Boolean)
On Error Resume Next
    If LblEdicion.Caption = "Nuevo Movimiento" Then ValidaReferencia 1
End Sub

Function ValidaReferencia(Opc As Integer) As Boolean
On Error Resume Next
    
    If Mid(LstDDocumento(0, CmbDocumento.ListIndex - 1), 1, 1) <> "P" Then
        If Opc = 1 Then TxtReferencia.Text = ""
        If Opc = 2 Then TxtReferenciaBancos.Text = ""
    End If
    
    StrCmd = "execute sel_Referencia " & CLng(lstDCedis(0, cmbCedis.ListIndex - 1)) & ", '" & IIf(Opc = 1, Trim(TxtReferencia.Text), Trim(TxtReferenciaBancos.Text)) & "', " & Opc
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        MsgBox "¡ La " & IIf(Opc = 1, "Referencia " & Trim(TxtReferencia.Text), "Referencia Bancos " & Trim(TxtReferenciaBancos.Text)) & " ya existe. Teclee otra. !", vbInformation + vbOKOnly, App.Title
        TxtReferencia.Text = "": TxtReferenciaBancos.Text = ""
    End If

End Function

Private Sub TxtReferenciaBancos_Validate(Cancel As Boolean)
On Error Resume Next
    If LblEdicion.Caption = "Nuevo Movimiento" Then ValidaReferencia 2
End Sub

Private Sub btnArchivo_Click()
On Error Resume Next
    
'    If Not ValidaPeriodo(LstDCedis(0, cmbCedis.ListIndex - 1), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1) Then
'        MsgBox "¡ " & StrPeriodo & " !", vbInformation + vbOKOnly, App.Title
'        Exit Sub
'    End If

    With CC_PagoDesdeArchivo
        
        .Top = Me.Top + ((Me.Height - .Height) / 2)
        .Left = Me.Left + ((Me.Width - .Width) / 2)
        
        .Mes = Month(DTPPeriodo.Value)
        .Agno = Year(DTPPeriodo.Value)
        
        .Show
    End With
End Sub

