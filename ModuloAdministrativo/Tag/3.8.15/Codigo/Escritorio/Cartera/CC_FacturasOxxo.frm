VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_FacturasOxxo 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Facturación Global"
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
      TabIndex        =   6
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
         Left            =   5280
         Picture         =   "CC_FacturasOxxo.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   28
         Top             =   7680
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
         Left            =   3600
         Picture         =   "CC_FacturasOxxo.frx":071B
         Style           =   1  'Graphical
         TabIndex        =   27
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
         Left            =   1920
         Picture         =   "CC_FacturasOxxo.frx":0DB2
         Style           =   1  'Graphical
         TabIndex        =   26
         Top             =   7680
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
         Picture         =   "CC_FacturasOxxo.frx":14C2
         Style           =   1  'Graphical
         TabIndex        =   25
         Top             =   7680
         Width           =   1575
      End
      Begin VB.OptionButton OptImprime 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Productos Con Iva"
         Height          =   255
         Index           =   1
         Left            =   7080
         TabIndex        =   24
         Top             =   7920
         Visible         =   0   'False
         Width           =   2055
      End
      Begin VB.OptionButton OptImprime 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Productos Sin Iva"
         Height          =   255
         Index           =   0
         Left            =   7080
         TabIndex        =   23
         Top             =   7560
         Value           =   -1  'True
         Visible         =   0   'False
         Width           =   2055
      End
      Begin VB.Frame Frame1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Datos de la Factura Global"
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
         TabIndex        =   13
         Top             =   2040
         Width           =   4455
         Begin VB.Label Label8 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Ventas"
            Height          =   240
            Left            =   390
            TabIndex        =   21
            Top             =   480
            Width           =   615
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
            TabIndex        =   20
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
            TabIndex        =   19
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
            TabIndex        =   18
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
            TabIndex        =   17
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
            TabIndex        =   16
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
            TabIndex        =   15
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
            TabIndex        =   14
            Top             =   1080
            Width           =   1635
         End
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
         TabIndex        =   3
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
         Format          =   16842755
         CurrentDate     =   39448
         MaxDate         =   39813
         MinDate         =   39448
      End
      Begin MSComctlLib.ListView LstCedis 
         Height          =   615
         Left            =   120
         TabIndex        =   1
         Top             =   3240
         Width           =   7215
         _ExtentX        =   12726
         _ExtentY        =   1085
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
         TabIndex        =   4
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
         Format          =   16842753
         CurrentDate     =   39376
      End
      Begin MSComCtl2.DTPicker DTPFechaFinal 
         Height          =   375
         Left            =   10320
         TabIndex        =   5
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
         Format          =   16842753
         CurrentDate     =   39376
      End
      Begin MSComctlLib.ListView LstCadenas 
         Height          =   2295
         Left            =   120
         TabIndex        =   0
         Top             =   840
         Width           =   6255
         _ExtentX        =   11033
         _ExtentY        =   4048
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
         TabIndex        =   22
         Top             =   480
         Width           =   7095
      End
      Begin VB.Label Label1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Del"
         Height          =   255
         Left            =   7920
         TabIndex        =   9
         Top             =   1560
         Width           =   375
      End
      Begin VB.Label Label3 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Al"
         Height          =   255
         Left            =   9960
         TabIndex        =   8
         Top             =   1560
         Width           =   375
      End
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Seleccione el mes"
         Height          =   255
         Left            =   240
         TabIndex        =   7
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
Attribute VB_Name = "CC_FacturasOxxo"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDCedis, FechaInicial, FechaFinal, LstDFacturasOxxo, LstDCadenas, IdCadenaOxxo, SerieOxxo
Dim bMarcandoFactura As Boolean

Private Sub btnAplica_Click()
Dim IdDocumento, IdTipoDocumento, CargoAbono, IdMovimiento, FechaMovimiento
    On Error GoTo Err_AplicaFOxxo:
    
    If IsEmpty(LstDFacturasOxxo) Then Exit Sub
    
    If Trim(UCase(LstFacturasOxxo.SelectedItem.ListSubItems(8))) <> UCase(Usuario) Then
        MousePointer = 0
        MsgBox "¡ La Factura Global solo puede ser modificada por el Usuario """ & LstFacturasOxxo.SelectedItem.ListSubItems(8) & """ !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Not ValidaPeriodo(CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1) Then
        MsgBox "¡ " & strPeriodo & " !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    If Trim(UCase(LstFacturasOxxo.SelectedItem.ListSubItems(7))) = "GENERADA" Then
        Dim bFacturada As Boolean
        StrCmd = "execute sel_VentasFacturaCFD " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & ", 0, " & CLng(LstDFacturasOxxo(13, LstFacturasOxxo.SelectedItem.Index - 1)) & ", '" & Trim(LstFacturasOxxo.SelectedItem) & "', " & CLng(LstFacturasOxxo.SelectedItem.SubItems(1)) & ", 1, 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If Not RsC.EOF Then
            TransProdIDFactura = RsC.Fields(6): TransProdID = RsC.Fields(7):
            If TransProdIDFactura <> "" And TransProdID <> "" And IsNull(RsC.Fields(9)) Then
                Facturada = ValidaFactura(1, LstDFacturasOxxo(1, LstFacturasOxxo.SelectedItem.Index - 1), LstDFacturasOxxo(2, LstFacturasOxxo.SelectedItem.Index - 1))
                StrCmd = "execute up_FacturaOxxo " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & ", " & LstDFacturasOxxo(13, LstFacturasOxxo.SelectedItem.Index - 1) & ", '" & Trim(LstFacturasOxxo.SelectedItem) & "', " & CLng(LstFacturasOxxo.SelectedItem.ListSubItems(1)) & ", '01/01/1900', 0, 0, '" & Usuario & "', " & IIf(CFDCedis = "1" And Facturada, 6, 4)
                If Rs.State Then Rs.Close
                Rs.Open StrCmd, Cnn
                MsgBox "¡ Datos Actualizados !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        End If

        MsgBox "¡ La Factura está Aplicada !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    If IsEmpty(LstDFacturasOxxo) Then
        MsgBox "¡ Seleccione la Factura a Aplicar !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
          
    MousePointer = 11
    
    IdCadenaOxxo = Trim(LstCadenas.SelectedItem)
    
    FechaMovimiento = FormatDate(CDate(LstFacturasOxxo.SelectedItem.ListSubItems(2))) 'IIf(BIdioma = "us_english", Format(CDate(LstFacturasOxxo.SelectedItem.ListSubItems(2)), "mm/dd/yyyy"), Format(CDate(LstFacturasOxxo.SelectedItem.ListSubItems(2)), "dd/mm/yyyy"))
    
    StrCmd = "execute sel_FacturasOxxoDetalle  " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & ", '01/01/1900', '01/01/1900', " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & ", " & LstDFacturasOxxo(13, LstFacturasOxxo.SelectedItem.Index - 1) & ", '" & Trim(LstFacturasOxxo.SelectedItem) & "', " & CLng(LstFacturasOxxo.SelectedItem.ListSubItems(1)) & ", 0, '', 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    If Rs.EOF Then
        MousePointer = 0
        MsgBox "¡ No hay Documentos asignados a la Factura Global!", vbInformation + vbOKOnly, App.Title
        Exit Sub
    Else
        If MsgBox("¿ Deseas Aplicar la Factura Global " & Trim(LstFacturasOxxo.SelectedItem) & " - " & CLng(LstFacturasOxxo.SelectedItem.ListSubItems(1)) & " del " & LstFacturasOxxo.SelectedItem.ListSubItems(2) & " ?", vbQuestion + vbYesNo, App.Title) = vbNo Then
            Exit Sub
        Else
            If MsgBox("Una vez Aplicado el Documento ya no podrás hacer cambios. ¿ Deseas continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        End If
        ' Obtiene los tipos de documentos
        StrCmd = " execute sel_TipoDocumentoOxxo " & IdCadenaOxxo
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If RsC.EOF Then
            MousePointer = 0
            MsgBox "¡ No se ha definido el Tipo de Documento para saldar las Facturas Global!", vbInformation + vbOKOnly, App.Title
            Exit Sub
        Else
            IdDocumento = RsC.Fields(0): IdTipoDocumento = RsC.Fields(1): CargoAbono = RsC.Fields(2)
        End If
        
        ' Obtiene el Nuevo Documento para Asignar los Movimientos
        StrCmd = " select isnull( max(Folio)+ 1, 1) from Folio "
        'where IdCedis = " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1))
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
        StrCmd = "execute up_Folio " & IdMovimiento & ", '" & FechaMovimiento & "', 0, 'Notas de Crédito para saldar Ventas de " & Trim(LstCadenas.SelectedItem.ListSubItems(2)) & "', '', '" & Usuario & "', 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        
    End If
    
    While Not Rs.EOF
        StrCmd = "execute up_MovimientosFacturas " & IdMovimiento & ", " & Rs.Fields(0) & ", " & Rs.Fields(16) & ", '" & Rs.Fields(1) & "', " & Rs.Fields(2) & ", " & IdMovimiento & ", '" & FechaMovimiento & "', 0, '" & IdDocumento & "', '" & IdTipoDocumento & "', '" & CargoAbono & "', '', '', " & Rs.Fields(13) & ", 0, 'A', '" & Usuario & "', 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        Rs.MoveNext
    Wend
    
    Facturada = ValidaFactura(1, LstDFacturasOxxo(1, LstFacturasOxxo.SelectedItem.Index - 1), LstDFacturasOxxo(2, LstFacturasOxxo.SelectedItem.Index - 1))
    StrCmd = "execute up_FacturaOxxo " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & ", " & LstDFacturasOxxo(13, LstFacturasOxxo.SelectedItem.Index - 1) & ", '" & Trim(LstFacturasOxxo.SelectedItem) & "', " & CLng(LstFacturasOxxo.SelectedItem.ListSubItems(1)) & ", '01/01/1900', 0, 0, '" & Usuario & "', " & IIf(CFDCedis = "1" And Facturada, 6, 4)
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
        
    StrCmd = "execute up_Folio " & IdMovimiento & ", '" & FechaMovimiento & "', 0, '', '', '" & Usuario & "', 5"
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
        
    MousePointer = 0
        
    MsgBox "¡ Datos actualizados !", vbInformation + vbOKOnly, App.Title

No_Err_AplicaFOxxo:
    MuestraFacturas
    MousePointer = 0
    Exit Sub
    
Err_AplicaFOxxo:
    MousePointer = 0
    MsgBox "¡ Error al Aplicar la Factura Global !. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_AplicaFOxxo:

End Sub

Private Sub btnClose_Click()
On Error Resume Next
    FrmFacturas.Visible = False
End Sub

Private Sub btnEliminar_Click()
    On Error GoTo Err_BajaFOxxo:
    
    If IsEmpty(LstDFacturasOxxo) Then Exit Sub
    
    If Trim(UCase(LstFacturasOxxo.SelectedItem.ListSubItems(8))) <> UCase(Usuario) Then
        MousePointer = 0
        MsgBox "¡ La Factura Global solo puede ser modificada por el Usuario """ & LstFacturasOxxo.SelectedItem.ListSubItems(8) & """ !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Not ValidaPeriodo(CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1) Then
        MsgBox "¡ " & strPeriodo & " !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Trim(UCase(LstFacturasOxxo.SelectedItem.ListSubItems(7))) = "GENERADA" Then
        If MsgBox("¡ La Factura está Aplicada !" & Chr(13) & Chr(10) & "¿ Deseas dar de Baja la Factura Global  " & Trim(LstFacturasOxxo.SelectedItem) & " - " & CLng(LstFacturasOxxo.SelectedItem.ListSubItems(1)) & " del " & LstFacturasOxxo.SelectedItem.ListSubItems(2) & " ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    Else
        If MsgBox("¿ Deseas dar de Baja la Factura Global  " & Trim(LstFacturasOxxo.SelectedItem) & " - " & CLng(LstFacturasOxxo.SelectedItem.ListSubItems(1)) & " del " & LstFacturasOxxo.SelectedItem.ListSubItems(2) & " ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    End If
        
    If IsEmpty(LstDFacturasOxxo) Then
        MsgBox "¡ Seleccione la Factura a Eliminar !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
        MousePointer = 11
        
            If Not IsNull(LstFacturasOxxo.SelectedItem) Then
        If CFDCedis = "1" Then
            StrIdCedis = CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1))
            StrIdTipoVenta = CLng(LstDFacturasOxxo(13, LstFacturasOxxo.SelectedItem.Index - 1))
            StrSerie = Trim(LstFacturasOxxo.SelectedItem)
            StrFolio = CLng(LstFacturasOxxo.SelectedItem.SubItems(1))
            ImpCount = ImpCount + 1
        Else
            StrIdCedis = StrIdCedis & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & ", "
            StrIdTipoVenta = StrIdTipoVenta & CLng(LstDFacturasOxxo(13, LstFacturasOxxo.SelectedItem.Index - 1)) & ", "
            StrSerie = StrSerie & "''" & Trim(LstFacturasOxxo.SelectedItem) & "'', "
            StrFolio = StrFolio & CLng(LstFacturasOxxo.SelectedItem.SubItems(1)) & ", "
            StrFoliosImpresos = StrFoliosImpresos & Trim(LstFacturasOxxo.SelectedItem) & "-" & CLng(LstFacturasOxxo.SelectedItem.SubItems(1)) & ", "
            
            StrSql1 = StrSql1 & " ( Ventas.IdCedis = " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & " and Ventas.IdTipoVenta = " & CLng(LstDFacturasOxxo(13, LstFacturasOxxo.SelectedItem.Index - 1)) & " and Ventas.Serie = ''" & Trim(LstFacturasOxxo.SelectedItem) & "'' and Ventas.Folio = " & CLng(LstFacturasOxxo.SelectedItem.SubItems(1)) & " ) or "
            StrSql2 = StrSql2 & " ( VentasDetalle.IdCedis = " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & " and VentasDetalle.IdTipoVenta = " & CLng(LstDFacturasOxxo(13, LstFacturasOxxo.SelectedItem.Index - 1)) & " and VentasDetalle.Serie = ''" & Trim(LstFacturasOxxo.SelectedItem) & "'' and VentasDetalle.Folio = " & CLng(LstFacturasOxxo.SelectedItem.SubItems(1)) & " ) or "
            StrSql3 = StrSql3 & " ( FacturasOxxo.IdCedisOX = " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & " and FacturasOxxo.IdTipoVentaOX = " & CLng(LstDFacturasOxxo(13, LstFacturasOxxo.SelectedItem.Index - 1)) & " and FacturasOxxo.SerieOX = ''" & Trim(LstFacturasOxxo.SelectedItem) & "'' and FacturasOxxo.FolioOX = " & CLng(LstFacturasOxxo.SelectedItem.SubItems(1)) & " ) or "
        End If
        ImpCount = ImpCount + 1
    Else
        Exit Sub
    End If
    
    If CFDCedis <> "1" Then
    
        StrIdCedis = Mid(StrIdCedis, 1, Len(StrIdCedis) - 2) & "'"
        StrIdTipoVenta = Mid(StrIdTipoVenta, 1, Len(StrIdTipoVenta) - 2) & "'"
        StrSerie = Mid(StrSerie, 1, Len(StrSerie) - 2) & "'"
        StrFolio = Mid(StrFolio, 1, Len(StrFolio) - 2) & "'"
        StrFoliosImpresos = Mid(StrFoliosImpresos, 1, Len(StrFoliosImpresos) - 2)
        
        StrSql1 = Mid(StrSql1, 1, Len(StrSql1) - 4) & " "
        StrSql2 = Mid(StrSql2, 1, Len(StrSql2) - 4) & " "
        StrSql3 = Mid(StrSql3, 1, Len(StrSql3) - 4) & " "
    End If
    
        
         StrCmd = "execute sel_VentasFacturaCFD " & StrIdCedis & ", 0, " & StrIdTipoVenta & ", '" & StrSerie & "', " & StrFolio & ", 1, 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If Not RsC.EOF Then
            TransProdIDFactura = RsC.Fields(6): TransProdID = RsC.Fields(7)
            If TransProdIDFactura = "" Then
                GoTo Continua:
            End If
            'Si la fase es nulo, no esta en Route, ya que la fase se toma de TransProd
            If IsNull(RsC.Fields(9)) Then
                GoTo Continua:
            End If
            
            If Not IsNull(RsC.Fields(8)) Then
            
            
                     Set ClaseCFDADM = New LbCFDADM.LbCFDADM
                    MensajeCFD = ClaseCFDADM.LlamarCFDADM(PathRouteDesktop, TransProdIDFactura, RutaXML, 4)
                    
                    If StringStartsWith(MensajeCFD, "202", vbTextCompare) Then
                   
                    MsgBox MensajeCFD
                     GoTo Continua:
                    End If
                    
                    If Trim(MensajeCFD) <> "" Then
                  
                    GoTo Err_CancelacionCFDI:
                    End If
                    
            End If
                    
                    
        End If
        
        

Continua:


    

    StrCmd = "execute up_FacturaOxxo " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & ", " & LstDFacturasOxxo(13, LstFacturasOxxo.SelectedItem.Index - 1) & ", '" & Trim(LstFacturasOxxo.SelectedItem) & "', " & CLng(LstFacturasOxxo.SelectedItem.ListSubItems(1)) & ", '01/01/1900', 0, 0, '" & Usuario & "', 3"
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
        
Err_CancelacionCFDI:
    MousePointer = 0
    MsgBox "Error: " & MensajeCFD, vbInformation + vbOKOnly, App.Title
GoTo No_Err_BajaFOxxo
End Sub

Private Sub btnImprimeFactura_Click()
Dim ImpCount, StrIdCedis, StrIdTipoVenta, StrSerie, StrFolio, FoliosCount, StrFoliosImpresos, StrSql1, StrSql2, StrSql3
On Error GoTo Err_FacturaGlobal:
    MensajeCFD = ""
    
      Dim utilWeb As UtileriaWeb
    Set utilWeb = New UtileriaWeb
    Dim mensajePing As String
    mensajePing = ""
    If Not utilWeb.VerificarServicioTimbrado(Cnn, Rs, mensajePing) Then
                MsgBox mensajePing
                Exit Sub
        End If
            
    
    ImpCount = 0: StrIdCedis = "'": StrIdTipoVenta = "'": StrSerie = "'": StrFolio = "'": StrFoliosImpresos = ""
    StrSql1 = "": StrSql2 = "": StrSql3 = ""
    If Not IsNull(LstFacturasOxxo.SelectedItem) Then
        If CFDCedis = "1" Then
            StrIdCedis = CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1))
            StrIdTipoVenta = CLng(LstDFacturasOxxo(13, LstFacturasOxxo.SelectedItem.Index - 1))
            StrSerie = Trim(LstFacturasOxxo.SelectedItem)
            StrFolio = CLng(LstFacturasOxxo.SelectedItem.SubItems(1))
            ImpCount = ImpCount + 1
        Else
            StrIdCedis = StrIdCedis & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & ", "
            StrIdTipoVenta = StrIdTipoVenta & CLng(LstDFacturasOxxo(13, LstFacturasOxxo.SelectedItem.Index - 1)) & ", "
            StrSerie = StrSerie & "''" & Trim(LstFacturasOxxo.SelectedItem) & "'', "
            StrFolio = StrFolio & CLng(LstFacturasOxxo.SelectedItem.SubItems(1)) & ", "
            StrFoliosImpresos = StrFoliosImpresos & Trim(LstFacturasOxxo.SelectedItem) & "-" & CLng(LstFacturasOxxo.SelectedItem.SubItems(1)) & ", "
            
            StrSql1 = StrSql1 & " ( Ventas.IdCedis = " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & " and Ventas.IdTipoVenta = " & CLng(LstDFacturasOxxo(13, LstFacturasOxxo.SelectedItem.Index - 1)) & " and Ventas.Serie = ''" & Trim(LstFacturasOxxo.SelectedItem) & "'' and Ventas.Folio = " & CLng(LstFacturasOxxo.SelectedItem.SubItems(1)) & " ) or "
            StrSql2 = StrSql2 & " ( VentasDetalle.IdCedis = " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & " and VentasDetalle.IdTipoVenta = " & CLng(LstDFacturasOxxo(13, LstFacturasOxxo.SelectedItem.Index - 1)) & " and VentasDetalle.Serie = ''" & Trim(LstFacturasOxxo.SelectedItem) & "'' and VentasDetalle.Folio = " & CLng(LstFacturasOxxo.SelectedItem.SubItems(1)) & " ) or "
            StrSql3 = StrSql3 & " ( FacturasOxxo.IdCedisOX = " & CLng(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & " and FacturasOxxo.IdTipoVentaOX = " & CLng(LstDFacturasOxxo(13, LstFacturasOxxo.SelectedItem.Index - 1)) & " and FacturasOxxo.SerieOX = ''" & Trim(LstFacturasOxxo.SelectedItem) & "'' and FacturasOxxo.FolioOX = " & CLng(LstFacturasOxxo.SelectedItem.SubItems(1)) & " ) or "
        End If
        ImpCount = ImpCount + 1
    Else
        Exit Sub
    End If
    
    If CFDCedis <> "1" Then
    
        StrIdCedis = Mid(StrIdCedis, 1, Len(StrIdCedis) - 2) & "'"
        StrIdTipoVenta = Mid(StrIdTipoVenta, 1, Len(StrIdTipoVenta) - 2) & "'"
        StrSerie = Mid(StrSerie, 1, Len(StrSerie) - 2) & "'"
        StrFolio = Mid(StrFolio, 1, Len(StrFolio) - 2) & "'"
        StrFoliosImpresos = Mid(StrFoliosImpresos, 1, Len(StrFoliosImpresos) - 2)
        
        StrSql1 = Mid(StrSql1, 1, Len(StrSql1) - 4) & " "
        StrSql2 = Mid(StrSql2, 1, Len(StrSql2) - 4) & " "
        StrSql3 = Mid(StrSql3, 1, Len(StrSql3) - 4) & " "
    End If
        
    If ImpCount <= 0 Then
        MsgBox "¡ Seleccione con las casillas de verificación las Facturas Globales a imprimir !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If CFDCedis = "1" Then
        Dim bFacturada As Boolean
        StrCmd = "execute sel_VentasFacturaCFD " & StrIdCedis & ", 0, " & StrIdTipoVenta & ", '" & StrSerie & "', " & StrFolio & ", 1, 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If Not RsC.EOF Then
            TransProdIDFactura = RsC.Fields(6): TransProdID = RsC.Fields(7)
            If TransProdIDFactura = "" Then
                GoTo Falta_Aplicar:
            End If
            'Si la fase es nulo, no esta en Route, ya que la fase se toma de TransProd
            If IsNull(RsC.Fields(9)) Then
                GoTo Falta_Aplicar:
            End If
            
            If IsNull(RsC.Fields(8)) Then
                Set ClaseCFDADM = New LbCFDADM.LbCFDADM
                MensajeCFD = ClaseCFDADM.LlamarCFDADM(PathRouteDesktop, TransProdIDFactura, RutaXML, 3)
                If Trim(MensajeCFD) <> "" Then GoTo Err_FacturaGlobal:
            Else
                Set ClaseCFDADM = New LbCFDADM.LbCFDADM
                MensajeCFD = ClaseCFDADM.LlamarCFDADM(PathRouteDesktop, TransProdIDFactura, RutaXML, 2)
                If Trim(MensajeCFD) <> "" Then GoTo Err_FacturaGlobal:
            End If
            
        Else
            TransProdIDFactura = ""
            StrSql2 = " ( VentasDetalle.IdCedis = " & StrIdCedis & " and VentasDetalle.IdTipoVenta = " & StrIdTipoVenta & " and VentasDetalle.Serie = ''" & StrSerie & "'' and VentasDetalle.Folio = " & StrFolio & " ) "
            GoTo Falta_Aplicar:
        End If
        
        GoTo No_Err_FacturaGlobal
        
    Else
ImprimeFGlobal:
        With CC_RptFactura
            StrCmd = "execute Rep_FacturasOxxo '" & StrSql2 & "', '', '', '', 5"
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
            
            If Not RsC.EOF Then
                .LblControl.Caption = StrFoliosImpresos
                .object.DataSrc.DataSourceName = Cnn
                .object.DataSrc.Recordset = RsC
                .Printer.Orientation = ddOPortrait
                .Printer.PaperSize = 1
                .Show
            End If
        End With
    End If

Falta_Aplicar:
    MousePointer = 0
    MsgBox "El documento no ha sido Aplicado!"
Exit Sub

No_Err_FacturaGlobal:
    MousePointer = 0
    Exit Sub
    
Err_FacturaGlobal:
    MousePointer = 0
    If Trim(MensajeCFD) = "" Then
        MsgBox "Error al crear " & IIf(CFDCedis = "1", " el CFDI", "la Factura") & " : " & Err.Description, vbInformation + vbOKOnly, App.Title
    Else
        MsgBox MensajeCFD, vbInformation + vbOKOnly, App.Title
    End If
    GoTo No_Err_FacturaGlobal:
    
Exit Sub
    
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
    RptFacturaOxxo.LblFolios.Caption = "ESTA FACTURA SUSTITUYE A LAS SIGUIENTES VENTAS: " & Chr(13) & Chr(10)
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
            .Show
        End With
    End If
End Sub

Private Sub btnNuevo_Click()
On Error Resume Next
    If Not ValidaPeriodo(CLng(LstCedis.SelectedItem), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1) Then
        MsgBox "¡ " & strPeriodo & " !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    With CC_FacturasOxxoAlta
        
        .TxtSerie.Text = "": .TxtFolio.Text = "": .TxtRFC.Text = "": .TxtCliente.Text = "": .TxtDiasCredito.Text = ""
        
        If Month(DTPPeriodo.Value) = 12 Then
            .DTPFecha.MaxDate = CDate(Year(DTPPeriodo.Value) & "-" & Month(DTPPeriodo.Value) & "-" & "31")
        Else
            .DTPFecha.MaxDate = CDate(Year(DTPPeriodo.Value) & "-" & (Month(DTPPeriodo.Value) + 1) & "-" & "01") - 1
        End If
        .DTPFecha.MinDate = CDate(Year(DTPPeriodo.Value) & "-" & Format(Month(DTPPeriodo.Value), "00") & "-" & "01")
        .DTPFecha.Value = CDate(Year(DTPPeriodo.Value) & "-" & Format(Month(DTPPeriodo.Value), "00") & "-" & "01")
        If Month(DTPPeriodo.Value) = 12 Then
            .DTPFecha.MaxDate = CDate(Year(DTPPeriodo.Value) & "-" & Month(DTPPeriodo.Value) & "-" & "31")
        Else
            .DTPFecha.MaxDate = CDate(Year(DTPPeriodo.Value) & "-" & (Month(DTPPeriodo.Value) + 1) & "-" & "01") - 1
        End If
        
        .IdCedis = CLng(LstCedis.SelectedItem)
        .IdCadenaOxxo = IdCadenaOxxo 'CLng(LstCadenas.SelectedItem)
        .SerieOxxo = SerieOxxo
        
        .TxtCedis.Text = CLng(LstCedis.SelectedItem) & " - " & Trim(LstCedis.SelectedItem.ListSubItems(1))
        .Top = Me.Top + ((Me.Height - .Height) / 2)
        .Left = Me.Left + ((Me.Width - .Width) / 2)
        .Show
    End With
End Sub

Private Sub DTPPeriodo_Change()
On Error Resume Next
        
    ValidaPeriodo CLng(LstCedis.SelectedItem), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1
    LblPeriodo.Caption = strPeriodo
    MuestraFacturas
End Sub

Private Sub Form_Activate()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
End Sub

Private Sub Form_Load()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    
    DTPPeriodo.MinDate = CDate("01/" & Month(Date) & "/" & Year(Date) - 1)
    DTPPeriodo.MaxDate = CDate("01/01/" & Year(Date) + 1) - 1
    DTPPeriodo.Value = Date

    DTPFechaInicial.Value = CDate("01/" & Month(Date) & "/" & Year(Date))
    DTPFechaFinal.Value = Date
    
    MuestraCadenas
    MuestraCedis
    If Not ValidaPeriodo(CLng(LstCedis.SelectedItem), Year(DTPPeriodo.Value), Month(DTPPeriodo.Value), "C", "", 1) Then MsgBox "¡ Periodo CERRADO para el manejo de Cartera !", vbInformation + vbOKOnly, App.Title
    LblPeriodo.Caption = strPeriodo
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
On Error Resume Next
    
    StrCmd = "execute sel_CedisUsuarios '" & Usuario & "', 6"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDCedis = GetDataLVL(Rs, LstCedis, 1, 2, "0|0")

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
    
    StrCmd = "execute sel_FacturasOxxo '" & StrCedis & "', " & Month(DTPPeriodo.Value) & ", '" & Trim(LstCadenas.SelectedItem.ListSubItems(1).Text) & "', '" & LstCadenas.SelectedItem & "', '" & Usuario & "', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    LstDFacturasOxxo = GetDataLVL(Rs, LstFacturasOxxo, 1, 10, "0|0|0|9|9|9|9|0|0|0")
    If LstFacturasOxxo.ListItems.Count > 0 Then
        LstFacturasOxxo.ListItems(1).Checked = True
    End If
    
    LstFacturasOxxo_Click
End Sub

Sub MuestraFacturasDetalle()
On Error GoTo Err_MuestraFacturasDetalle:

Dim j
    
    MousePointer = 11

    FechaInicial = FormatDate(DTPFechaInicial.Value)
    FechaFinal = FormatDate(DTPFechaFinal.Value)

    With CC_FacturasOxxoDetalle
        
        .LstFacturas.CheckBoxes = IIf(LstFacturasOxxo.SelectedItem.ListSubItems(7) = "Pendiente", True, False)
        .btnSeleccionar.Enabled = .LstFacturas.CheckBoxes
        SerieOxxo = Trim(LstFacturasOxxo.SelectedItem)
        
        StrCmd = "execute sel_FacturasOxxoDetalle " & CInt(LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)) & ", '" & FechaInicial & "', '" & FechaFinal & "', " & .IdCedisOX & ", " & .IdTipoVentaOX & ",'" & .SerieOX & "', " & .FolioOX & ", '" & IdCadenaOxxo & "', '" & SerieOxxo & "', " & IIf(.LstFacturas.CheckBoxes, 1, 2)
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        LstDFacturas = GetDataLVL(Rs, .LstFacturas, 1, 13, "0|0|0|0|0|0|0|9|9|9|9|9|9")

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
        .Show
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
On Error Resume Next
    If IsEmpty(LstDCadenas) Or IsEmpty(LstDCedis) Then Exit Sub
    IdCadenaOxxo = LstCadenas.SelectedItem
    SerieOxxo = Trim(LstCadenas.SelectedItem.ListSubItems(1))
    MuestraFacturas
End Sub

Private Sub LstCadenas_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    LstCadenas_Click
End Sub

Private Sub LstCedis_Click()
    On Error Resume Next
    SerieOxxo = Trim(LstCadenas.SelectedItem.ListSubItems(1)) '& Trim(LstCedis.SelectedItem)
End Sub

Private Sub LstCedis_ItemCheck(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    MuestraFacturas
End Sub

Private Sub LstFacturasOxxo_Click()
    On Error Resume Next
    
    LblNoFacturas.Caption = FormatNumber(LstDFacturasOxxo(14, LstFacturasOxxo.SelectedItem.Index - 1), 0, vbTrue)
    LblSubtotal.Caption = FormatNumber(LstDFacturasOxxo(11, LstFacturasOxxo.SelectedItem.Index - 1), 2, vbTrue)
    LblIva.Caption = FormatNumber(LstDFacturasOxxo(12, LstFacturasOxxo.SelectedItem.Index - 1), 2, vbTrue)
    LblTotal.Caption = FormatNumber(LstDFacturasOxxo(4, LstFacturasOxxo.SelectedItem.Index - 1), 2, vbTrue)
End Sub

Private Sub LstFacturasOxxo_DblClick()
    On Error Resume Next
    
    If IsEmpty(LstDFacturasOxxo) Then Exit Sub
    
    If Trim(UCase(LstFacturasOxxo.SelectedItem.ListSubItems(8))) <> UCase(Usuario) Then
        MousePointer = 0
        MsgBox "¡ La Factura Global solo puede ser modificada por el Usuario """ & LstFacturasOxxo.SelectedItem.ListSubItems(8) & """ !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    With CC_FacturasOxxoDetalle
        .IdCedisOX = LstDFacturasOxxo(0, LstFacturasOxxo.SelectedItem.Index - 1)
        .IdTipoVentaOX = LstDFacturasOxxo(13, LstFacturasOxxo.SelectedItem.Index - 1)
        .SerieOX = LstFacturasOxxo.SelectedItem
        .FolioOX = LstFacturasOxxo.SelectedItem.ListSubItems(1)
    
        ' TOTALES
        .LblSubtotal.Caption = FormatNumber(LstDFacturasOxxo(11, LstFacturasOxxo.SelectedItem.Index - 1), 2, vbTrue)
        .LblIva.Caption = FormatNumber(LstDFacturasOxxo(12, LstFacturasOxxo.SelectedItem.Index - 1), 2, vbTrue)
        .LblTotal.Caption = FormatNumber(LstDFacturasOxxo(4, LstFacturasOxxo.SelectedItem.Index - 1), 2, vbTrue)
    
    End With
    MuestraFacturasDetalle
    
End Sub

Private Sub LstFacturasOxxo_ItemCheck(ByVal Item As MSComctlLib.ListItem)
        If bMarcando = True Then
            Exit Sub
        End If
        bMarcando = True
        MarcarElemento LstFacturasOxxo, Item.Checked, Item.Index
        bMarcando = False
End Sub
Public Sub MarcarElemento(ByRef refListView As ListView, ByVal bValor As Boolean, ByVal iIndex As Integer)
    Dim i As Integer
    If bValor = True Then
       For i = 1 To refListView.ListItems.Count
            If i = iIndex Then
                refListView.ListItems(i).Checked = True
                refListView.ListItems(i).Selected = True
            Else
                refListView.ListItems(i).Checked = False
            End If
        Next
    End If
End Sub
Private Sub LstFacturasOxxo_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    LstFacturasOxxo_Click
    If Not IsNull(LstFacturasOxxo.SelectedItem) Then
        DesmarcarItems
        LstFacturasOxxo.SelectedItem.Checked = True
    End If
End Sub

Private Sub DesmarcarItems()
    For i = 1 To LstFacturasOxxo.ListItems.Count
        LstFacturasOxxo.ListItems(i).Checked = False
    Next
End Sub
