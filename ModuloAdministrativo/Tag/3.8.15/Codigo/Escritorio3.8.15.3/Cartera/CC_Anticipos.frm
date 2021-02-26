VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "Mscomctl.ocx"
Begin VB.Form CC_Anticipos 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Aplicación de Anticipos"
   ClientHeight    =   8685
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   11250
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
   MinButton       =   0   'False
   ScaleHeight     =   8685
   ScaleWidth      =   11250
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
      Height          =   8655
      Index           =   0
      Left            =   120
      TabIndex        =   16
      Top             =   0
      Width           =   11055
      Begin VB.CommandButton btnSeleccionar 
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
         Left            =   600
         Picture         =   "CC_Anticipos.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   31
         Top             =   8040
         Visible         =   0   'False
         Width           =   1695
      End
      Begin VB.Frame Frame3 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Datos del Cliente"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   3015
         Left            =   120
         TabIndex        =   24
         Top             =   2160
         Width           =   10815
         Begin VB.TextBox TxtIdCliente 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   1800
            TabIndex        =   6
            Top             =   480
            Width           =   975
         End
         Begin VB.TextBox TxtRFC 
            Height          =   375
            Left            =   120
            TabIndex        =   5
            Top             =   480
            Width           =   1575
         End
         Begin VB.TextBox TxtRazonSocial 
            Height          =   375
            Left            =   2880
            TabIndex        =   7
            Top             =   480
            Width           =   2295
         End
         Begin MSComctlLib.ListView LstClientes 
            Height          =   2055
            Left            =   120
            TabIndex        =   8
            Top             =   915
            Width           =   10575
            _ExtentX        =   18653
            _ExtentY        =   3625
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
         Begin VB.Label Label26 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cliente Seleccionado"
            Height          =   240
            Left            =   5280
            TabIndex        =   29
            Top             =   240
            Width           =   1830
         End
         Begin VB.Label LblCliente 
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
            Height          =   450
            Left            =   5400
            TabIndex        =   28
            Top             =   480
            Width           =   5205
         End
         Begin VB.Label Label20 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Id Sucursal"
            Height          =   240
            Left            =   1800
            TabIndex        =   27
            Top             =   240
            Width           =   975
         End
         Begin VB.Label Label21 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Sucursal"
            Height          =   255
            Left            =   2880
            TabIndex        =   26
            Top             =   240
            Width           =   1695
         End
         Begin VB.Label Label22 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cliente"
            Height          =   240
            Left            =   120
            TabIndex        =   25
            Top             =   240
            Width           =   600
         End
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
         Left            =   3480
         Picture         =   "CC_Anticipos.frx":0752
         Style           =   1  'Graphical
         TabIndex        =   12
         Top             =   8040
         Width           =   1575
      End
      Begin VB.Frame FrmDatos 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Datos del Anticipo"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   1815
         Left            =   120
         TabIndex        =   17
         Top             =   240
         Width           =   10815
         Begin VB.TextBox TxtSaldo 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   960
            Locked          =   -1  'True
            TabIndex        =   3
            Top             =   1320
            Width           =   1095
         End
         Begin VB.TextBox TxtObs 
            Height          =   375
            Left            =   3600
            TabIndex        =   4
            Top             =   1320
            Width           =   6975
         End
         Begin VB.ComboBox cmbCedis 
            Height          =   360
            Left            =   4800
            Style           =   2  'Dropdown List
            TabIndex        =   1
            Top             =   840
            Width           =   3855
         End
         Begin VB.TextBox TxtImporte 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   9480
            TabIndex        =   2
            Top             =   840
            Width           =   1095
         End
         Begin VB.TextBox TxtFolio 
            Alignment       =   2  'Center
            Height          =   375
            Left            =   720
            Locked          =   -1  'True
            TabIndex        =   15
            Text            =   "000000"
            Top             =   840
            Width           =   1095
         End
         Begin MSComCtl2.DTPicker DTPFecha 
            Height          =   375
            Left            =   2640
            TabIndex        =   0
            Top             =   840
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
            Format          =   88276993
            CurrentDate     =   39376
         End
         Begin MSComCtl2.DTPicker DTPPeriodo 
            Height          =   375
            Left            =   2040
            TabIndex        =   32
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
            Format          =   88276995
            CurrentDate     =   39448
            MaxDate         =   73050
            MinDate         =   39448
         End
         Begin VB.Label Label2 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Seleccione el mes"
            Height          =   255
            Left            =   240
            TabIndex        =   34
            Top             =   360
            Width           =   1695
         End
         Begin VB.Label LblPeriodo 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Estatus del Periodo"
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
            Height          =   255
            Left            =   4560
            TabIndex        =   33
            Top             =   480
            Width           =   5655
         End
         Begin VB.Label Label1 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Saldo"
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
            TabIndex        =   30
            Top             =   1320
            Width           =   480
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
            Left            =   2160
            TabIndex        =   23
            Top             =   1320
            Width           =   1245
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
            Left            =   4200
            TabIndex        =   22
            Top             =   840
            Width           =   615
         End
         Begin VB.Label Label7 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Importe"
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
            Left            =   8760
            TabIndex        =   20
            Top             =   840
            Width           =   630
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
            TabIndex        =   19
            Top             =   840
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
            TabIndex        =   18
            Top             =   840
            Width           =   510
         End
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
         Left            =   120
         Picture         =   "CC_Anticipos.frx":10E8
         Style           =   1  'Graphical
         TabIndex        =   10
         Top             =   8040
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
         Left            =   1800
         Picture         =   "CC_Anticipos.frx":1776
         Style           =   1  'Graphical
         TabIndex        =   11
         Top             =   8040
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
         Left            =   5160
         Picture         =   "CC_Anticipos.frx":1E86
         Style           =   1  'Graphical
         TabIndex        =   13
         Top             =   8040
         Width           =   1575
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
         Left            =   6840
         Picture         =   "CC_Anticipos.frx":251D
         Style           =   1  'Graphical
         TabIndex        =   14
         Top             =   8040
         Width           =   1575
      End
      Begin MSComctlLib.ListView LstAnticipo 
         Height          =   2775
         Left            =   120
         TabIndex        =   9
         Top             =   5280
         Width           =   10815
         _ExtentX        =   19076
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
         Left            =   8640
         TabIndex        =   21
         Top             =   8160
         Width           =   1935
      End
   End
End
Attribute VB_Name = "CC_Anticipos"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public Seleccionar As Boolean
Dim LstDCedis, LstDAnticipos, LstDClientes, IdCliente, IdSucursal, Folio As Long, Fecha As Date, Mes, IdCedis

Sub MuestraCedis()
    StrCmd = "execute sel_CedisUsuarios '" & Usuario & "', 5"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCedis = GetDataCBL(Rs, cmbCedis, "Seleccione un Cedis", "No hay Cedis asigandos")
End Sub

Private Sub btnActualizar_Click()
On Error GoTo Err_NuevoAnt:
    
    If LblEdicion.Caption <> "Consulta" Then
    
        If Not ValidaModulo("ANTI", True) Then Exit Sub
        
        Fecha = DTPFecha.Value
        
        Folio = Trim(TxtFolio.Text)
        
        If Trim(TxtImporte.Text) = "" Then
            MsgBox "¡ Proporciona el Importe del Anticipo !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
    
        If CDbl(TxtImporte.Text) <= 0 Then
            MsgBox "¡ Proporciona el Importe del Anticipo !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
    
        If cmbCedis.ListIndex = 0 Then
            MsgBox "¡ Selecciona un Cedis !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If IdCliente = "0" Or IdSucursal = "" Then
            MsgBox "¡ Selecciona un Cliente !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
    
        If Not ValidaPeriodo(IdCedis, Year(Fecha), Month(Fecha), "C", "A", 1) Then
            MsgBox "¡ " & strPeriodo & " !", vbInformation + vbOKOnly, App.Title
            TxtFolio.Text = "": TxtObs.Text = "": TxtImporte.Text = "0.00"
            MousePointer = 0
            Exit Sub
        End If
    
        MousePointer = 11
        
        ' inserta el anticipo...
        StrCmd = "execute up_Anticipos " & IdCedis & ", " & Folio & ", '" & FormatDate(Fecha) & "', '" & IdCliente & "', '" & IdSucursal & "', " & TxtImporte.Text & ", '" & Trim(TxtObs.Text) & "', '', '" & Usuario & "', 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
            
        MuestraAnticipos
        LblEdicion.Caption = "Consulta"
    End If
    
No_Err_NuevoAnt:
    MousePointer = 0
    Exit Sub
    
Err_NuevoAnt:
    MousePointer = 0
    If Err.Number = -2147217873 Then
        MsgBox "¡ El Folio ya ha sido asignado a otro Usuario !", vbInformation + vbOKOnly, App.Title
        StrCmd = "execute sel_Anticipos 0, '" & Usuario & "', 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            Folio = Rs.Fields(0)
        End If
        
        TxtFolio.Text = Format(Folio, "000000")
    Else
        MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    End If
    GoTo No_Err_NuevoAnt:
    
End Sub

Private Sub btnAplica_Click()
On Error GoTo Err_AplicaAnt:
    
    If IsEmpty(LstDAnticipos) Then Exit Sub

    If Not ValidaModulo("ANTI", True) Then Exit Sub
    
    If Trim(UCase(LstAnticipo.SelectedItem.ListSubItems(10))) <> UCase(Usuario) Then
        MousePointer = 0
        MsgBox "¡ El Anticipo " & LstAnticipo.SelectedItem & " solo puede ser modificado por el Usuario """ & LstAnticipo.SelectedItem.ListSubItems(10) & """ !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Trim(UCase(LstAnticipo.SelectedItem.ListSubItems(9))) = "APLICADO" Or Trim(UCase(LstAnticipo.SelectedItem.ListSubItems(9))) = "BAJA" Then
        MousePointer = 0
        MsgBox "¡ El Anticipo " & LstAnticipo.SelectedItem & " tiene Status """ & LstAnticipo.SelectedItem.ListSubItems(9) & """ !. No puede ejecutar esta acción. ", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Not ValidaPeriodo(IdCedis, Year(Fecha), Month(Fecha), "C", "A", 1) Then
        MsgBox "¡ " & strPeriodo & " !", vbInformation + vbOKOnly, App.Title
        MousePointer = 0
        Exit Sub
    End If
    
    If MsgBox("Una vez Aplicado el Anticipo " & LstAnticipo.SelectedItem & " ya NO podrá modificarse. ¿Desea continuar?", vbQuestion + vbYesNo, App.Title) = vbNo Then
        MousePointer = 0
        Exit Sub
    End If

    MousePointer = 11
    
    StrCmd = "execute up_Anticipos " & IdCedis & ", " & Folio & ", '" & FormatDate(Fecha) & "', '" & LstDAnticipos(5, LstAnticipo.SelectedItem.Index - 1) & "', '" & LstDAnticipos(7, LstAnticipo.SelectedItem.Index - 1) & "', " & LstDAnticipos(3, LstAnticipo.SelectedItem.Index - 1) & ", '', '', '" & Usuario & "', 5"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    
    MuestraAnticipos
    MsgBox "¡ Anticipo Aplicado !", vbInformation + vbOKOnly, App.Title

No_Err_AplicaAnt:
    MousePointer = 0
    Exit Sub
    
Err_AplicaAnt:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_AplicaAnt:

End Sub

Private Sub btnEliminar_Click()
On Error GoTo Err_EliminarAnt:

    If LblEdicion.Caption = "Nuevo" Then
        TxtFolio.Text = "000000": TxtObs.Text = ""
        TxtImporte.Text = "0.00"
        DTPFecha.Value = Date
        
        LblEdicion.Caption = "Consulta"
        Exit Sub
    Else
        
        If Not ValidaModulo("ANTI", True) Then Exit Sub
        If IsEmpty(LstDAnticipos) Then Exit Sub
        
        If Trim(UCase(LstAnticipo.SelectedItem.ListSubItems(10))) <> UCase(Usuario) Then
            MousePointer = 0
            MsgBox "¡ El Anticipo " & LstAnticipo.SelectedItem & " solo puede ser modificado por el Usuario """ & LstAnticipo.SelectedItem.ListSubItems(10) & """ !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If Trim(UCase(LstAnticipo.SelectedItem.ListSubItems(9))) = "APLICADO" Or Trim(UCase(LstAnticipo.SelectedItem.ListSubItems(9))) = "BAJA" Then
            MousePointer = 0
            MsgBox "¡ El Anticipo " & LstAnticipo.SelectedItem & " tiene Status """ & LstAnticipo.SelectedItem.ListSubItems(9) & """ !. No puede ejecutar esta acción. ", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If Not ValidaPeriodo(IdCedis, Year(Fecha), Month(Fecha), "C", "A", 1) Then
            MsgBox "¡ " & strPeriodo & " !", vbInformation + vbOKOnly, App.Title
            TxtFolio.Text = "": TxtObs.Text = "": TxtImporte.Text = "0.00": TxtSaldo.Text = "0.00"
            MousePointer = 0
            Exit Sub
        End If
        
        If MsgBox("El Anticipo " & LstAnticipo.SelectedItem & " ya NO podrá modificarse. ¿Desea continuar?", vbQuestion + vbYesNo, App.Title) = vbNo Then
            MousePointer = 0
            Exit Sub
        End If
        
        MousePointer = 11
        StrCmd = "execute up_Anticipos 0, " & LstAnticipo.SelectedItem & ", '19000101', 0, '', 0, '', 'B', '" & Usuario & "',  3"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        
        MuestraAnticipos
        MsgBox "¡ Anticipo Cancelado !", vbInformation + vbOKOnly, App.Title
        
    End If

No_Err_EliminarAnt:
    MousePointer = 0
    Exit Sub
    
Err_EliminarAnt:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_EliminarAnt:
    

End Sub

Private Sub btnImprimeFactura_Click()
    
    If IsEmpty(LstDAnticipos) Then Exit Sub
    
    If Trim(UCase(LstAnticipo.SelectedItem.ListSubItems(9))) = "BAJA" Then
        MousePointer = 0
        MsgBox "¡ El Anticipo " & LstAnticipo.SelectedItem & " tiene Status """ & LstAnticipo.SelectedItem.ListSubItems(9) & """ !. No puede ejecutar esta acción. ", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    With CC_RptMovimientoAnt
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
        .LblTitulo.Caption = "REPORTE DE MOVIMIENTOS DEL ANTICIPO"
        
        StrCmd = "execute Rep_Movimientos " & Folio & ", '01/01/1900', '01/01/1900', 2"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If Not RsC.EOF Then
            .object.DataSrc.DataSourceName = Cnn
            .object.DataSrc.Recordset = RsC
        End If
        
        .Printer.Orientation = ddOPortrait
        .Printer.PaperSize = 1
        .Show vbModal
    End With

End Sub

Private Sub btnNuevo_Click()
On Error Resume Next
    
    If Not ValidaModulo("ANTI", True) Then Exit Sub
    
    If Not ValidaPeriodo(LstDCedis(0, cmbCedis.ListIndex - 1), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1) Then
        MsgBox "¡ " & strPeriodo & " !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    StrCmd = "execute sel_Anticipos 0, '" & Usuario & "', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        Folio = Rs.Fields(0)
    End If
    
    TxtFolio.Text = Format(Folio, "000000"): TxtObs.Text = ""
    DTPFecha.Value = Date: TxtImporte.Text = "0.00": TxtSaldo.Text = "0.00"
    
    LblEdicion.Caption = "Nuevo"
End Sub

Private Sub btnSeleccionar_Click()
On Error Resume Next
    LstAnticipo_DblClick
End Sub

Private Sub cmbCedis_Click()
On Error Resume Next
    If cmbCedis.ListIndex = 0 Then
        IdCedis = 0
        Exit Sub
    Else
        IdCedis = LstDCedis(0, cmbCedis.ListIndex - 1)
    End If
    Val_PeriodoAnticipo
    'FiltraClientes
End Sub

Private Sub DTPFecha_Change()
On Error Resume Next
    Fecha = DTPFecha.Value
End Sub

Private Sub DTPPeriodo_Change()
On Error Resume Next
    Val_PeriodoAnticipo
    MuestraAnticipos
End Sub

Private Sub Form_Activate()
On Error Resume Next
    DTPPeriodo.Value = Date
    DTPFecha.Value = Date
    MuestraCedis
    cmbCedis.ListIndex = 1
    MuestraAnticipos
End Sub

Private Sub LstAnticipo_Click()
On Error Resume Next
    LblEdicion.Caption = "Consulta"
    
    TxtFolio.Text = LstAnticipo.SelectedItem
    Folio = CLng(LstAnticipo.SelectedItem)
    DTPFecha.Value = LstDAnticipos(2, LstAnticipo.SelectedItem.Index - 1)
    Fecha = LstDAnticipos(2, LstAnticipo.SelectedItem.Index - 1)
    TxtImporte.Text = LstDAnticipos(3, LstAnticipo.SelectedItem.Index - 1)
    TxtSaldo.Text = FormatNumber(LstDAnticipos(4, LstAnticipo.SelectedItem.Index - 1), 2, vbTrue)
    TxtObs.Text = LstDAnticipos(9, LstAnticipo.SelectedItem.Index - 1)
    IdCedis = LstDAnticipos(13, LstAnticipo.SelectedItem.Index - 1)
    cmbCedis.ListIndex = SearchInList(LstDCedis, CStr(LstDAnticipos(13, LstAnticipo.SelectedItem.Index - 1)), 0)
'    TxtRFC.Text = LstDAnticipos(4, LstAnticipo.SelectedItem.Index - 1): TxtRazonSocial.Text = LstDAnticipos(6, LstAnticipo.SelectedItem.Index - 1)
End Sub

Private Sub LstAnticipo_DblClick()
On Error Resume Next
    If IsEmpty(LstDAnticipos) And Seleccionar Then
        With CC_MovimientosDetalle
            .FolioAnticipo = 0: .SaldoAnticipo = 0
            .TxtAnticipo.Text = "": .TxtSaldoAnt.Text = ""
            .TxtClienteAnt.Text = ""
            .TxtSucursalAnt.Text = ""
        End With
        Unload Me
        Exit Sub
    End If

    If Seleccionar Then
        If Mid(UCase(LstDAnticipos(10, LstAnticipo.SelectedItem.Index - 1)), 1, 1) <> "A" Then
            MsgBox "¡ No puedes seleccionar un Anticipo que no ha sido Aplicado !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
    
        With CC_MovimientosDetalle
            .FolioAnticipo = CLng(LstAnticipo.SelectedItem): .SaldoAnticipo = CDbl(LstDAnticipos(4, LstAnticipo.SelectedItem.Index - 1))
            .TxtAnticipo.Text = LstAnticipo.SelectedItem & " - " & LstDAnticipos(2, LstAnticipo.SelectedItem.Index - 1) & " || Monto: " & FormatNumber(LstDAnticipos(3, LstAnticipo.SelectedItem.Index - 1), 2, vbTrue)
            .TxtSaldoAnt.Text = "Saldo: " & FormatNumber(LstDAnticipos(4, LstAnticipo.SelectedItem.Index - 1), 2, vbTrue)
            .TxtClienteAnt.Text = LstDAnticipos(5, LstAnticipo.SelectedItem.Index - 1) & " - " & LstDAnticipos(6, LstAnticipo.SelectedItem.Index - 1)
            .TxtSucursalAnt.Text = LstDAnticipos(7, LstAnticipo.SelectedItem.Index - 1) & " - " & LstDAnticipos(8, LstAnticipo.SelectedItem.Index - 1)
        End With
        Unload Me
    End If
End Sub

Private Sub LstClientes_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    If IsEmpty(LstDClientes) Then
        IdCliente = 0: IdSucursal = "": LblCliente.Caption = ""
    End If
    
    Folio = LstAnticipo.SelectedItem
    IdCliente = LstDClientes(2, LstClientes.SelectedItem.Index - 1)
    IdSucursal = LstDClientes(4, LstClientes.SelectedItem.Index - 1)
    LblCliente.Caption = LstDClientes(2, LstClientes.SelectedItem.Index - 1) & " - " & LstDClientes(3, LstClientes.SelectedItem.Index - 1) & Chr(13) & Chr(10) & LstDClientes(4, LstClientes.SelectedItem.Index - 1) & " - " & LstDClientes(5, LstClientes.SelectedItem.Index - 1)
End Sub

Private Sub TxtIdCliente_Change()
On Error Resume Next
    FiltraClientes
End Sub

Private Sub TxtIdCliente_GotFocus()
On Error Resume Next
    SelText TxtIdCliente
End Sub

Private Sub TxtIdCliente_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtImporte_Change()
On Error Resume Next
    TxtSaldo.Text = FormatNumber(TxtImporte.Text, 2, vbTrue)
End Sub

Private Sub TxtImporte_GotFocus()
On Error Resume Next
    SelText TxtImporte
End Sub

Private Sub TxtImporte_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itDecimal(KeyAscii)
End Sub

Private Sub TxtImporte_Validate(Cancel As Boolean)
On Error Resume Next
    TxtImporte.Text = itFlotante(TxtImporte.Text)
End Sub

Private Sub TxtObs_GotFocus()
On Error Resume Next
    SelText TxtObs
End Sub

Private Sub TxtObs_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtRazonSocial_Change()
On Error Resume Next
    TxtIdCliente.Text = ""
    FiltraClientes
End Sub

Private Sub TxtRazonSocial_GotFocus()
On Error Resume Next
    SelText TxtRazonSocial
End Sub

Private Sub TxtRazonSocial_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Private Sub TxtRFC_Change()
On Error Resume Next
    FiltraClientes
End Sub

Private Sub TxtRFC_GotFocus()
On Error Resume Next
    SelText TxtRFC
End Sub

Private Sub TxtRFC_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Sub FiltraClientes()
On Error Resume Next
    If IsEmpty(LstDCedis) Then Exit Sub
    
    LstAnticipo.ListItems.Clear: LstDAnticipos = Empty
    LblCliente.Caption = ""
    
    If cmbCedis.ListIndex = 0 Then
        MsgBox "¡ Selecciona un Cedis !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Trim(TxtIdCliente.Text) = "" And Trim(TxtRFC.Text) = "" And Trim(TxtRazonSocial.Text) = "" Then Exit Sub
    
    StrCmd = "execute sel_ClientesFacturas " & CLng(LstDCedis(0, cmbCedis.ListIndex - 1)) & ",'" & Trim(TxtIdCliente.Text) & "','" & Trim(TxtRFC.Text) & "','" & Trim(TxtRazonSocial.Text) & "', 6"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDClientes = GetDataLVL(RsC, LstClientes, 0, 5, "0|0|0|0|0|0")
End Sub

Sub MuestraAnticipos()
On Error Resume Next
        
    If IsEmpty(Mes) Then Mes = Month(Date)
        
    StrCmd = "execute sel_Anticipos " & Mes & ", '" & Usuario & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDAnticipos = GetDataLVL(Rs, LstAnticipo, 1, 12, "0|0|9|9|0|0|0|0|0|0|0|0")
    'LstAnticipo_ItemClick LstAnticipo.SelectedItem
    
End Sub

Sub Val_PeriodoAnticipo()
On Error Resume Next
    ValidaPeriodo IdCedis, Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1
    LblPeriodo.Caption = strPeriodo
    DTPFecha.MinDate = CDate("01/" & Month(DTPPeriodo.Value) & "/" & Year(DTPPeriodo.Value))
    DTPFecha.MaxDate = CDate("01/" & Month(DTPPeriodo.Value) + 1 & "/" & Year(DTPPeriodo.Value)) - 1
    DTPFecha.Value = DTPPeriodo.Value
    Mes = Month(DTPPeriodo.Value)
End Sub
