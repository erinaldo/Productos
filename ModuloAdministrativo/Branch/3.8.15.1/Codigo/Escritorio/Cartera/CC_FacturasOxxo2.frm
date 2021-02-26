VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Begin VB.Form CC_FacturasOxxo2 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Facturación de Oxxo"
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
      TabIndex        =   10
      Top             =   0
      Width           =   12375
      Begin VB.OptionButton OptImprime 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Productos Con Iva"
         Height          =   255
         Index           =   1
         Left            =   6960
         TabIndex        =   28
         Top             =   7920
         Width           =   2055
      End
      Begin VB.OptionButton OptImprime 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Productos Sin Iva"
         Height          =   255
         Index           =   0
         Left            =   6960
         TabIndex        =   27
         Top             =   7560
         Value           =   -1  'True
         Width           =   2055
      End
      Begin VB.Frame Frame1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Monto de la Factura"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   1695
         Left            =   7680
         TabIndex        =   17
         Top             =   2040
         Width           =   4455
         Begin VB.Label Label8 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Facturas"
            Height          =   240
            Left            =   240
            TabIndex        =   25
            Top             =   480
            Width           =   765
         End
         Begin VB.Label LblNoFacturas 
            Alignment       =   1  'Right Justify
            Appearance      =   0  'Flat
            BackColor       =   &H80000005&
            BorderStyle     =   1  'Fixed Single
            Caption         =   "0"
            ForeColor       =   &H80000008&
            Height          =   345
            Left            =   240
            TabIndex        =   24
            Top             =   840
            Width           =   915
         End
         Begin VB.Label Label6 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subtotal:"
            Height          =   240
            Left            =   1635
            TabIndex        =   23
            Top             =   360
            Width           =   780
         End
         Begin VB.Label Label5 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Iva:"
            Height          =   240
            Left            =   2100
            TabIndex        =   22
            Top             =   720
            Width           =   285
         End
         Begin VB.Label Label4 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Total:"
            Height          =   240
            Left            =   1950
            TabIndex        =   21
            Top             =   1080
            Width           =   480
         End
         Begin VB.Label LblSubtotal 
            Alignment       =   1  'Right Justify
            Appearance      =   0  'Flat
            BackColor       =   &H80000005&
            BorderStyle     =   1  'Fixed Single
            Caption         =   "$ 0.00"
            ForeColor       =   &H80000008&
            Height          =   345
            Left            =   2535
            TabIndex        =   20
            Top             =   360
            Width           =   1635
         End
         Begin VB.Label LblIva 
            Alignment       =   1  'Right Justify
            Appearance      =   0  'Flat
            BackColor       =   &H80000005&
            BorderStyle     =   1  'Fixed Single
            Caption         =   "$ 0.00"
            ForeColor       =   &H80000008&
            Height          =   345
            Left            =   2535
            TabIndex        =   19
            Top             =   720
            Width           =   1635
         End
         Begin VB.Label LblTotal 
            Alignment       =   1  'Right Justify
            Appearance      =   0  'Flat
            BackColor       =   &H80000005&
            BorderStyle     =   1  'Fixed Single
            Caption         =   "$ 0.00"
            ForeColor       =   &H80000008&
            Height          =   345
            Left            =   2535
            TabIndex        =   18
            Top             =   1080
            Width           =   1635
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
         Picture         =   "CC_FacturasOxxo2.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   3
         Top             =   7680
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
         Picture         =   "CC_FacturasOxxo2.frx":068E
         Style           =   1  'Graphical
         TabIndex        =   4
         Top             =   7680
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
         Left            =   3480
         Picture         =   "CC_FacturasOxxo2.frx":0D9E
         Style           =   1  'Graphical
         TabIndex        =   5
         Top             =   7680
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
         Left            =   5160
         Picture         =   "CC_FacturasOxxo2.frx":1435
         Style           =   1  'Graphical
         TabIndex        =   6
         Top             =   7680
         Width           =   1575
      End
      Begin MSComctlLib.ListView LstFacturasOxxo 
         Height          =   3375
         Left            =   120
         TabIndex        =   2
         Top             =   3960
         Width           =   12015
         _ExtentX        =   21193
         _ExtentY        =   5953
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
      Begin MSComCtl2.DTPicker DTPPeriodo 
         Height          =   375
         Left            =   2040
         TabIndex        =   7
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
         Format          =   73465859
         CurrentDate     =   39448
         MaxDate         =   39813
         MinDate         =   39448
      End
      Begin MSComctlLib.ListView LstCedis 
         Height          =   1815
         Left            =   120
         TabIndex        =   1
         Top             =   2040
         Width           =   7215
         _ExtentX        =   12726
         _ExtentY        =   3201
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
      Begin MSComCtl2.DTPicker DTPFechaInicial 
         Height          =   375
         Left            =   8400
         TabIndex        =   8
         Top             =   1560
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
         Format          =   73465857
         CurrentDate     =   39376
      End
      Begin MSComCtl2.DTPicker DTPFechaFinal 
         Height          =   375
         Left            =   10320
         TabIndex        =   9
         Top             =   1560
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
         Format          =   73465857
         CurrentDate     =   39376
      End
      Begin MSComctlLib.ListView LstCadenas 
         Height          =   1095
         Left            =   120
         TabIndex        =   0
         Top             =   840
         Width           =   6255
         _ExtentX        =   11033
         _ExtentY        =   1931
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
         Left            =   4440
         TabIndex        =   26
         Top             =   360
         Width           =   7095
      End
      Begin VB.Label Label1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Del"
         Height          =   255
         Left            =   7920
         TabIndex        =   13
         Top             =   1560
         Width           =   375
      End
      Begin VB.Label Label3 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Al"
         Height          =   255
         Left            =   9960
         TabIndex        =   12
         Top             =   1560
         Width           =   375
      End
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Seleccione el mes"
         Height          =   255
         Left            =   240
         TabIndex        =   11
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
      TabIndex        =   14
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
         TabIndex        =   15
         Top             =   0
         Width           =   1335
      End
      Begin MSComctlLib.ListView LstFacturas 
         Height          =   6615
         Left            =   120
         TabIndex        =   16
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
Attribute VB_Name = "CC_FacturasOxxo2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim lstDCedis, FechaInicial, FechaFinal, LstDFacturasOxxo, LstDCadenas, IdCadenaOxxo, SerieOxxo

Private Sub btnAplica_Click()
Dim IdDocumento, IdTipoDocumento, CargoAbono, IdMovimiento, FechaMovimiento
    'On Error GoTo Err_AplicaFOxxo:
    
    If Not ValidaPeriodo(CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1) Then
        MsgBox "¡ " & StrPeriodo & " !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    If Trim(UCase(LstFacturasOxxo.SelectedItem.ListSubItems(7))) = "GENERADA" Then
        MsgBox "¡ La Factura está Aplicada !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    If MsgBox("¿ Deseas dar de Aplicar la Factura Oxxo  " & Trim(LstFacturasOxxo.SelectedItem) & " - " & CLng(LstFacturasOxxo.SelectedItem.ListSubItems(1)) & " del " & LstFacturasOxxo.SelectedItem.ListSubItems(2) & " ?", vbQuestion + vbYesNo, App.Title) = vbNo Then
        Exit Sub
    Else
        If MsgBox("Una vez Aplicado el Documento ya no podrás hacer cambios. ¿ Deseas continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    End If
        
    If IsEmpty(LstDFacturasOxxo) Then
        MsgBox "¡ Seleccione la Factura a Aplicar !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    MousePointer = 11
    
    IdCadenaOxxo = Trim(LstCadenas.SelectedItem)
    
    FechaMovimiento = IIf(BIdioma = "us_english", Format(CDate(LstFacturasOxxo.SelectedItem.ListSubItems(2)), "mm/dd/yyyy"), Format(CDate(LstFacturasOxxo.SelectedItem.ListSubItems(2)), "dd/mm/yyyy"))
    
    StrCmd = "execute sel_FacturasOxxoDetalle  " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & ", '01/01/1900', '01/01/1900', " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & ", " & LstDFacturasOxxo(11, LstFacturasOxxo.SelectedItem.Index - 1) & ", '" & Trim(LstFacturasOxxo.SelectedItem) & "', " & CLng(LstFacturasOxxo.SelectedItem.ListSubItems(1)) & ", 0, '', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    If Rs.EOF Then
        MousePointer = 0
        MsgBox "¡ No hay Documentos asignados a la Factura de Oxxo!", vbInformation + vbOKOnly, App.Title
        Exit Sub
    Else
        ' Obtiene los tipos de documentos
        StrCmd = " execute sel_TipoDocumentoOxxo " & IdCadenaOxxo
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If RsC.EOF Then
            MousePointer = 0
            MsgBox "¡ No se ha definido el Tipo de Documento para saldar las Facturas de Oxxo!", vbInformation + vbOKOnly, App.Title
            Exit Sub
        Else
            IdDocumento = RsC.Fields(0): IdTipoDocumento = RsC.Fields(1): CargoAbono = RsC.Fields(2)
        End If
        
        ' Obtiene el Nuevo Documento para Asignar los Movimientos
        StrCmd = " select isnull( max(IdMovimiento)+ 1, 1) from Movimientos where IdCedis = " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1))
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If RsC.EOF Then
            MousePointer = 0
            MsgBox "¡ No se encontró un nuevo Folio de Movimiento !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        Else
            IdMovimiento = RsC.Fields(0)
        End If
        
        ' inserta el movimiento...
        StrCmd = "execute up_Movimientos " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & ", " & IdMovimiento & ", '" & FechaMovimiento & "', '" & IdDocumento & "', '" & CargoAbono & "', 0, '', '', 'Notas de Crédito para saldar facturas de " & Trim(LstCadenas.SelectedItem.ListSubItems(2)) & "', 'C', '" & Usuario & "', 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        
    End If
    
    While Not Rs.EOF
        StrCmd = "execute up_MovimientosFacturas " & Rs.Fields(0) & ", " & Rs.Fields(12) & ", '" & Rs.Fields(1) & "', " & Rs.Fields(2) & ", " & IdMovimiento & ", '" & FechaMovimiento & "', 0, '" & IdDocumento & "', '" & IdTipoDocumento & "', '" & CargoAbono & "', " & Rs.Fields(9) & ", 0, 'A', '" & Usuario & "', 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        Rs.MoveNext
    Wend
    StrCmd = "execute up_FacturaOxxo " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & ", " & LstDFacturasOxxo(11, LstFacturasOxxo.SelectedItem.Index - 1) & ", '" & Trim(LstFacturasOxxo.SelectedItem) & "', " & CLng(LstFacturasOxxo.SelectedItem.ListSubItems(1)) & ", '01/01/1900', 0, '" & Usuario & "', 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
        
    MuestraFacturas
    MousePointer = 0
        
    MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title

No_Err_AplicaFOxxo:
    MousePointer = 0
    Exit Sub
    
Err_AplicaFOxxo:
    MousePointer = 0
    MsgBox "¡ Error al Aplicar la Factura de Oxxo !. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_AplicaFOxxo:

End Sub

Private Sub btnClose_Click()
    FrmFacturas.Visible = False
End Sub

Private Sub btnEliminar_Click()
    On Error GoTo Err_BajaFOxxo:
    
    If Not ValidaPeriodo(CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1) Then
        MsgBox "¡ " & StrPeriodo & " !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Trim(UCase(LstFacturasOxxo.SelectedItem.ListSubItems(7))) = "GENERADA" Then
        MsgBox "¡ La Factura está Aplicada !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If MsgBox("¿ Deseas dar de Baja la Factura Oxxo  " & Trim(LstFacturasOxxo.SelectedItem) & " - " & CLng(LstFacturasOxxo.SelectedItem.ListSubItems(1)) & " del " & LstFacturasOxxo.SelectedItem.ListSubItems(2) & " ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        
    If IsEmpty(LstDFacturasOxxo) Then
        MsgBox "¡ Seleccione la Factura a Eliminar !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    MousePointer = 11
    StrCmd = "execute up_FacturaOxxo " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & ", " & LstDFacturasOxxo(11, LstFacturasOxxo.SelectedItem.Index - 1) & ", '" & Trim(LstFacturasOxxo.SelectedItem) & "', " & CLng(LstFacturasOxxo.SelectedItem.ListSubItems(1)) & ", '01/01/1900', 0, '" & Usuario & "', 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    MuestraFacturas
    MousePointer = 0
        
    MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title
    
No_Err_BajaFOxxo:
    MousePointer = 0
    Exit Sub
    
Err_BajaFOxxo:
    MousePointer = 0
    MsgBox "¡ Error !. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_BajaFOxxo:
        

End Sub

Private Sub btnImprimeFactura_Click()
Dim ImpCount, StrIdCedis, StrIdTipoVenta, StrSerie, StrFolio, FoliosCount, StrFoliosImpresos, StrSql1, StrSql2, StrSql3
On Error Resume Next

    ImpCount = 0: StrIdCedis = "'": StrIdTipoVenta = "'": StrSerie = "'": StrFolio = "'": StrFoliosImpresos = ""
    StrSql1 = "": StrSql2 = "": StrSql3 = ""
    For i = 1 To LstFacturasOxxo.ListItems.Count
        If LstFacturasOxxo.ListItems(i).Checked Then
            StrIdCedis = StrIdCedis & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.ListItems(i).Index - 1)) & ", "
            StrIdTipoVenta = StrIdTipoVenta & CLng(LstDFacturasOxxo(11, LstFacturasOxxo.ListItems(i).Index - 1)) & ", "
            StrSerie = StrSerie & "''" & Trim(LstFacturasOxxo.ListItems(i)) & "'', "
            StrFolio = StrFolio & CLng(LstFacturasOxxo.ListItems(i).ListSubItems(1)) & ", "
            StrFoliosImpresos = StrFoliosImpresos & Trim(LstFacturasOxxo.ListItems(i)) & "-" & CLng(LstFacturasOxxo.ListItems(i).ListSubItems(1)) & ", "
            
            StrSql1 = StrSql1 & " ( Ventas.IdCedis = " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.ListItems(i).Index - 1)) & " and Ventas.IdTipoVenta = " & CLng(LstDFacturasOxxo(11, LstFacturasOxxo.ListItems(i).Index - 1)) & " and Ventas.Serie = ''" & Trim(LstFacturasOxxo.ListItems(i)) & "'' and Ventas.Folio = " & CLng(LstFacturasOxxo.ListItems(i).ListSubItems(1)) & " ) or "
            StrSql2 = StrSql2 & " ( VentasDetalle.IdCedis = " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.ListItems(i).Index - 1)) & " and VentasDetalle.IdTipoVenta = " & CLng(LstDFacturasOxxo(11, LstFacturasOxxo.ListItems(i).Index - 1)) & " and VentasDetalle.Serie = ''" & Trim(LstFacturasOxxo.ListItems(i)) & "'' and VentasDetalle.Folio = " & CLng(LstFacturasOxxo.ListItems(i).ListSubItems(1)) & " ) or "
            StrSql3 = StrSql3 & " ( FacturasOxxo.IdCedisOX = " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.ListItems(i).Index - 1)) & " and FacturasOxxo.IdTipoVentaOX = " & CLng(LstDFacturasOxxo(11, LstFacturasOxxo.ListItems(i).Index - 1)) & " and FacturasOxxo.SerieOX = ''" & Trim(LstFacturasOxxo.ListItems(i)) & "'' and FacturasOxxo.FolioOX = " & CLng(LstFacturasOxxo.ListItems(i).ListSubItems(1)) & " ) or "
            
            ImpCount = ImpCount + 1
        End If
    Next i
    
    StrIdCedis = Mid(StrIdCedis, 1, Len(StrIdCedis) - 2) & "'"
    StrIdTipoVenta = Mid(StrIdTipoVenta, 1, Len(StrIdTipoVenta) - 2) & "'"
    StrSerie = Mid(StrSerie, 1, Len(StrSerie) - 2) & "'"
    StrFolio = Mid(StrFolio, 1, Len(StrFolio) - 2) & "'"
    StrFoliosImpresos = Mid(StrFoliosImpresos, 1, Len(StrFoliosImpresos) - 2)
    
    StrSql1 = Mid(StrSql1, 1, Len(StrSql1) - 4) & " "
    StrSql2 = Mid(StrSql2, 1, Len(StrSql2) - 4) & " "
    StrSql3 = Mid(StrSql3, 1, Len(StrSql3) - 4) & " "
    
    If ImpCount <= 0 Then
        MsgBox "¡ Seleccione con las casillas de verificación las Facturas de Oxxo a imprimir !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
           
    ' StrCmd = "execute Rep_FacturasOxxo " & StrIdCedis & ", " & StrIdTipoVenta & ", " & StrSerie & ", " & StrFolio & ", 1"
    StrCmd = "execute Rep_FacturasOxxo '" & StrSql1 & "', '', '', '', 1"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    
    With CC_RptFacturaOxxo
        .LblFolio.Caption = StrFoliosImpresos
        .LblFecha.Caption = RsC.Fields(4): .LblRFC.Caption = RsC.Fields(6)
        .LblNombre.Caption = RsC.Fields(7): .LblDireccion.Caption = RsC.Fields(8)
    End With
    
    ' StrCmd = "execute Rep_FacturasOxxo " & StrIdCedis & ", " & StrIdTipoVenta & ", " & StrSerie & ", " & StrFolio & ", 3"
    StrCmd = "execute Rep_FacturasOxxo '" & StrSql3 & "', '', '', '', 3"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    CC_RptFacturaOxxo.LblFolios.Caption = "ESTA FACTURA SUSTITUYE A LAS SIGUIENTES FACTURAS: " & Chr(13) & Chr(10)
    FoliosCount = 0
    While Not RsC.EOF
        CC_RptFacturaOxxo.LblFolios.Caption = CC_RptFacturaOxxo.LblFolios.Caption & RsC.Fields(0) & "   "
        FoliosCount = FoliosCount + 1
        RsC.MoveNext
    Wend
    
    FoliosCount = CInt(FoliosCount / 10)
    With CC_RptFacturaOxxo
        .GroupFooterFolios.Height = 650 + (FoliosCount * 200) - 200
        .LblFolios.Height = IIf(FoliosCount < 6, 2500, FoliosCount * 200)
    End With
        
    ' StrCmd = "execute Rep_FacturasOxxo " & StrIdCedis & ", " & StrIdTipoVenta & ", " & StrSerie & ", " & StrFolio & ", " & IIf(OptImprime(0).Value, 2, 4)
    StrCmd = "execute Rep_FacturasOxxo '" & StrSql2 & "', '', '', '', " & IIf(OptImprime(0).Value, 2, 4)
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
       
    If Not Rs.EOF Then
        With CC_RptFacturaOxxo
            .LblIva.Caption = IIf(OptImprime(1).Value, "15.00 %", "0.00 %")
            .Printer.Orientation = ddOPortrait: .Printer.PaperSize = 1
            .DataSrc.DataSourceName = Cnn: .DataSrc.Recordset = Rs
            .Show 1
        End With
    End If
End Sub

Private Sub btnNuevo_Click()
    If Not ValidaPeriodo(CLng(LstCedis.SelectedItem), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1) Then
        MsgBox "¡ " & StrPeriodo & " !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    With CC_FacturasOxxoAlta
        
        .DTPFecha.MinDate = "01/" & Month(DTPPeriodo.Value) & "/" & Year(DTPPeriodo.Value)
        .DTPFecha.Value = "01/" & Month(DTPPeriodo.Value) & "/" & Year(DTPPeriodo.Value)
        .DTPFecha.MaxDate = CDate("01/" & Month(DTPPeriodo.Value) + 1 & "/" & Year(DTPPeriodo.Value)) - 1
        
        .IdCedis = CLng(LstCedis.SelectedItem)
        .IdCadenaOxxo = IdCadenaOxxo 'CLng(LstCadenas.SelectedItem)
        .SerieOxxo = SerieOxxo
        
        .TxtCedis.Text = CLng(LstCedis.SelectedItem) & " - " & Trim(LstCedis.SelectedItem.ListSubItems(1))
        .Top = Me.Top + ((Me.Height - .Height) / 2)
        .Left = Me.Left + ((Me.Width - .Width) / 2)
        .Show vbModal
    End With
End Sub

Private Sub DTPPeriodo_Change()
    ValidaPeriodo CLng(LstCedis.SelectedItem), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1
    LblPeriodo.Caption = StrPeriodo
    MuestraFacturas
End Sub

Private Sub Form_Activate()
    If Not Cnn.State Then OpenConn Server, Db, "ITAPDC", "itapdc"
End Sub

Private Sub Form_Load()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, "ITAPDC", "itapdc"
    DTPPeriodo.Value = Date
    DTPFechaInicial.Value = CDate("01/" & Month(Date) & "/" & Year(Date))
    DTPFechaFinal.Value = Date
    
    MuestraCadenas
    MuestraCedis
    If Not ValidaPeriodo(CLng(LstCedis.SelectedItem), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1) Then MsgBox "¡ Periodo CERRADO para el manejo de Cartera !", vbInformation + vbOKOnly, App.Title
    LblPeriodo.Caption = StrPeriodo
    MuestraFacturas
End Sub

Private Sub MuestraCadenas()
On Error Resume Next
    
    StrCmd = "execute sel_FacturacionGlobal " '& Usuario & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCadenas = GetDataLVL(Rs, LstCadenas, 1, 3, "0|0|0")
    IdCadenaOxxo = CLng(LstCadenas.SelectedItem)
    
End Sub

Private Sub MuestraCedis()
    
    StrCmd = "execute sel_CedisUsuarios '" & Usuario & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    lstDCedis = GetDataLVL(Rs, LstCedis, 1, 2, "0|0")

End Sub

Public Sub MuestraFacturas()
On Error Resume Next

    Dim StrCedis
    StrCedis = ""
        
    For i = 1 To LstCedis.ListItems.Count
        If LstCedis.ListItems(i).Checked Then StrCedis = StrCedis & "" & LstCedis.ListItems(i) & ", "
    Next
    
    StrCedis = Mid(StrCedis, 1, Len(StrCedis) - 2)
    
    If Trim(StrCedis) = "" Then
        LstFacturasOxxo.ListItems.Clear
        Exit Sub
    End If
    
    StrCmd = "execute sel_FacturasOxxo '" & StrCedis & "', " & Month(DTPPeriodo.Value) & ", '" & Trim(LstCadenas.SelectedItem.ListSubItems(1).Text) & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    LstDFacturasOxxo = GetDataLVL(Rs, LstFacturasOxxo, 1, 8, "0|0|0|3|3|3|3|0")
    LstFacturasOxxo_Click
End Sub

Sub MuestraFacturasDetalle()
On Error GoTo Err_MuestraFacturasDetalle:

Dim j
    
    MousePointer = 11

    FechaInicial = IIf(BIdioma = "us_english", Format(DTPFechaInicial.Value, "mm/dd/yyyy"), Format(DTPFechaInicial.Value, "dd/mm/yyyy"))
    FechaFinal = IIf(BIdioma = "us_english", Format(DTPFechaFinal.Value, "mm/dd/yyyy"), Format(DTPFechaFinal.Value, "dd/mm/yyyy"))

    With CC_FacturasOxxoDetalle
        
        .LstFacturas.CheckBoxes = IIf(LstFacturasOxxo.SelectedItem.ListSubItems(7) = "Pendiente", True, False)
        .btnSeleccionar.Enabled = .LstFacturas.CheckBoxes
        
        StrCmd = "execute sel_FacturasOxxoDetalle " & CInt(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & ", '" & FechaInicial & "', '" & FechaFinal & "', " & .IdCedisOX & ", " & .IdTipoVentaOX & ",'" & .SerieOX & "', " & .FolioOX & ", '" & IdCadenaOxxo & "', '" & SerieOxxo & "', " & IIf(.LstFacturas.CheckBoxes, 1, 2)
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        LstDFacturas = GetDataLVL(Rs, .LstFacturas, 1, 9, "0|0|0|3|3|3|3|3|3")

        If .LstFacturas.CheckBoxes Then ' factura pendiente
            
            StrCmd = "select Folio from FacturasOxxo where IdCedisOX = " & .IdCedisOX & " and idTipoVentaOX =  " & .IdTipoVentaOX & " and SerieOX =  '" & .SerieOX & "' and FolioOx = " & .FolioOX
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
            
            j = 0
            While Not RsC.EOF
                For i = 1 To .LstFacturas.ListItems.Count
                    If CLng(.LstFacturas.ListItems(i).ListSubItems(1)) = CLng(RsC.Fields(0)) Then
                        .LstFacturas.ListItems(i).Checked = True
                        j = j + 1
                        Exit For
                    End If
                Next
                RsC.MoveNext
            Wend
            .LblNoFacturas.Caption = j
        End If
        
        MousePointer = 0
        
        .Top = Me.Top + ((Me.Height - .Height) / 2)
        .Left = Me.Left + ((Me.Width - .Width) / 2)
        .Show vbModal
    End With

No_Err_MuestraFacturasDetalle:
    MousePointer = 0
    Exit Sub
    
Err_MuestraFacturasDetalle:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_MuestraFacturasDetalle:
End Sub

Private Sub LstCadenas_Click()
    If IsEmpty(LstDCadenas) Or IsEmpty(lstDCedis) Then Exit Sub
    IdCadenaOxxo = LstCadenas.SelectedItem
    SerieOxxo = Trim(LstCadenas.SelectedItem.ListSubItems(1)) & Trim(LstCedis.SelectedItem)
    MuestraFacturas
End Sub

Private Sub LstCadenas_KeyUp(KeyCode As Integer, Shift As Integer)
    LstCadenas_Click
End Sub

Private Sub LstCedis_Click()
    On Error Resume Next
    SerieOxxo = Trim(LstCadenas.SelectedItem.ListSubItems(1)) & Trim(LstCedis.SelectedItem)
End Sub

Private Sub LstCedis_ItemCheck(ByVal Item As MSComctlLib.ListItem)
    MuestraFacturas
End Sub

Private Sub LstFacturasOxxo_Click()
    On Error Resume Next
    LblNoFacturas.Caption = FormatNumber(LstDFacturasOxxo(12, LstFacturasOxxo.SelectedItem.Index - 1), 0, vbTrue)
    LblSubtotal.Caption = FormatNumber(LstDFacturasOxxo(9, LstFacturasOxxo.SelectedItem.Index - 1), 2, vbTrue)
    LblIva.Caption = FormatNumber(LstDFacturasOxxo(10, LstFacturasOxxo.SelectedItem.Index - 1), 2, vbTrue)
    LblTotal.Caption = FormatNumber(LstDFacturasOxxo(4, LstFacturasOxxo.SelectedItem.Index - 1), 2, vbTrue)
End Sub

Private Sub LstFacturasOxxo_DblClick()
    On Error Resume Next
    With CC_FacturasOxxoDetalle
        .IdCedisOX = LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)
        .IdTipoVentaOX = LstDFacturasOxxo(11, LstFacturasOxxo.SelectedItem.Index - 1)
        .SerieOX = LstFacturasOxxo.SelectedItem
        .FolioOX = LstFacturasOxxo.SelectedItem.ListSubItems(1)
    
        ' TOTALES
        .LblSubtotal.Caption = FormatNumber(LstDFacturasOxxo(9, LstFacturasOxxo.SelectedItem.Index - 1), 2, vbTrue)
        .LblIva.Caption = FormatNumber(LstDFacturasOxxo(10, LstFacturasOxxo.SelectedItem.Index - 1), 2, vbTrue)
        .LblTotal.Caption = FormatNumber(LstDFacturasOxxo(4, LstFacturasOxxo.SelectedItem.Index - 1), 2, vbTrue)
    
    End With
    MuestraFacturasDetalle
    
End Sub

Private Sub LstFacturasOxxo_KeyDown(KeyCode As Integer, Shift As Integer)
    LstFacturasOxxo_Click
End Sub

Private Sub LstFacturasOxxo_KeyPress(KeyAscii As Integer)
    LstFacturasOxxo_Click
End Sub

Private Sub LstFacturasOxxo_KeyUp(KeyCode As Integer, Shift As Integer)
    LstFacturasOxxo_Click
End Sub
