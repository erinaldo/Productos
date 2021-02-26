VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form Cat_Periodos 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   5745
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   9510
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
   ScaleHeight     =   5745
   ScaleWidth      =   9510
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
      Height          =   5580
      Index           =   2
      Left            =   120
      TabIndex        =   3
      Top             =   120
      Width           =   9255
      Begin VB.CommandButton btnAbrir 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Abrir / Cerrar"
         Height          =   375
         Left            =   7200
         Style           =   1  'Graphical
         TabIndex        =   6
         Top             =   600
         Width           =   1695
      End
      Begin VB.ComboBox cmbCedis 
         Height          =   360
         Left            =   2520
         Style           =   2  'Dropdown List
         TabIndex        =   1
         Top             =   600
         Width           =   4335
      End
      Begin MSComCtl2.DTPicker DTPPeriodo 
         Height          =   375
         Left            =   240
         TabIndex        =   0
         Top             =   600
         Width           =   2055
         _ExtentX        =   3625
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
         Format          =   16711683
         CurrentDate     =   39448
         MaxDate         =   39813
         MinDate         =   39448
      End
      Begin MSComctlLib.ListView LstPeriodos 
         Height          =   4335
         Left            =   120
         TabIndex        =   2
         Top             =   1080
         Width           =   9015
         _ExtentX        =   15901
         _ExtentY        =   7646
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   -1  'True
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
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Mes de Trabajo"
         Height          =   255
         Left            =   360
         TabIndex        =   5
         Top             =   360
         Width           =   1335
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
         Left            =   2640
         TabIndex        =   4
         Top             =   360
         Width           =   615
      End
   End
End
Attribute VB_Name = "Cat_Periodos"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDCedis, LstDPeriodos, Periodo

Private Sub btnAbrir_Click()
    If cmbCedis.ListIndex = 0 Then Exit Sub
        
    If MsgBox("¿ Estás seguro que deseas " & btnAbrir.Caption & " el mes seleccionado ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        'If MsgBox("Al abrir el periodo se podrán modificar los movimientos. ¿ Estás seguro que deseas continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        'Else
    
    'valida q no haya más periodos abiertos....
    StrCmd = "execute sel_Periodo " & CLng(LstDCedis(0, cmbCedis.ListIndex - 1)) & ", " & Year(DTPPeriodo.Value) & ", " & Periodo & ", 'C', 'A', 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF And btnAbrir.Caption = "Abrir Mes" Then
        MsgBox "¡ Solo puedes Abrir un periodo a la vez. Cierra los periodos abiertos para continuar. !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Not btnAbrir.Caption = "Abrir Mes" Then
        'valida q estén aplicados todos los movimientos y facturas de oxxo
        StrCmd = "execute sel_MovimientosNoAplicados " & CLng(LstDCedis(0, cmbCedis.ListIndex - 1)) & ", " & Year(DTPPeriodo.Value) & ", " & Month(DTPPeriodo.Value) & ", 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        If Not Rs.EOF Then
            MsgBox "¡ No puedes Cerrar el Periodo cuando todavía existen Movimientos o Facturas Oxxo sin Aplicar. !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
    End If
    
    StrCmd = "execute up_Periodos " & CLng(LstDCedis(0, cmbCedis.ListIndex - 1)) & ", " & Year(DTPPeriodo.Value) & ", " & Periodo & ", 'C', '" & IIf(btnAbrir.Caption = "Abrir Mes", "A", "C") & "', " & IIf(btnAbrir.Caption = "Abrir Mes", 1, 2)
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MuestraPeriodos
    MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
    
End Sub

Private Sub cmbCedis_Click()
    MuestraPeriodos
End Sub

Private Sub DTPPeriodo_Change()
    Periodo = Month(DTPPeriodo.Value)
    MuestraPeriodos
End Sub

Private Sub Form_Load()
    DTPPeriodo.Value = Date
    MuestraCedis
    MuestraPeriodos
    Periodo = Month(DTPPeriodo.Value)
End Sub

Sub MuestraCedis()
    StrCmd = "execute sel_CedisUsuarios '" & Usuario & "', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCedis = GetDataCBL(Rs, cmbCedis, "Seleccione un Cedis", "No hay Cedis asigandos")
End Sub


Sub MuestraPeriodos()

    If cmbCedis.ListIndex = 0 Then
        LstPeriodos.ListItems.Clear
        LstDPeriodos = Empty
        Exit Sub
    End If
    
    StrCmd = "execute sel_Periodo " & CLng(LstDCedis(0, cmbCedis.ListIndex - 1)) & ", " & Year(DTPPeriodo.Value) & ",  0, '', '', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDPeriodos = GetDataLVL(Rs, LstPeriodos, 1, 3, "0|0|0")
    
    btnAbrir.Caption = "Abrir Mes"
    
    If Not IsEmpty(LstDPeriodos) Then
        For i = 0 To UBound(LstDPeriodos, 2)
            If Month(DTPPeriodo.Value) = LstDPeriodos(4, i) Then
                btnAbrir.Caption = IIf(Trim(UCase(LstDPeriodos(3, i))) = "CERRADO", "Abrir Mes", "Cerrar Mes")
                Exit For
            End If
        Next
    End If
End Sub

Private Sub LstPeriodos_Click()
    btnAbrir.Caption = "Abrir Mes"
    
    If Not IsEmpty(LstDPeriodos) Then
        For i = 0 To UBound(LstDPeriodos, 2)
            If LstDPeriodos(4, LstPeriodos.SelectedItem.Index - 1) = LstDPeriodos(4, i) Then
                Periodo = LstDPeriodos(4, LstPeriodos.SelectedItem.Index - 1)
                DTPPeriodo.Value = CDate("01/" & Periodo & "/" & Year(DTPPeriodo.Value))
                btnAbrir.Caption = IIf(Trim(UCase(LstDPeriodos(3, i))) = "CERRADO", "Abrir Mes", "Cerrar Mes")
                Exit For
            End If
        Next
    End If

End Sub

Private Sub LstPeriodos_KeyUp(KeyCode As Integer, Shift As Integer)
    LstPeriodos_Click
End Sub
