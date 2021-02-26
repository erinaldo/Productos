VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_OpcImpFactura 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   5280
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   4770
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
   ScaleHeight     =   5280
   ScaleWidth      =   4770
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
      Height          =   5220
      Index           =   2
      Left            =   120
      TabIndex        =   14
      Top             =   0
      Width           =   4575
      Begin VB.TextBox TxtFolio 
         Height          =   360
         Left            =   1920
         TabIndex        =   2
         Top             =   1120
         Width           =   1575
      End
      Begin VB.CheckBox ChkImpresion 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Imprimir serie y folio del sistema"
         Height          =   240
         Index           =   4
         Left            =   120
         TabIndex        =   3
         Top             =   1560
         Value           =   1  'Checked
         Width           =   3975
      End
      Begin VB.TextBox TxtObservaciones 
         Height          =   735
         Left            =   120
         MultiLine       =   -1  'True
         TabIndex        =   12
         Top             =   3720
         Width           =   4335
      End
      Begin VB.CheckBox ChkImpresion 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Marcar documentos como facturados"
         Height          =   240
         Index           =   3
         Left            =   120
         TabIndex        =   1
         Top             =   840
         Value           =   1  'Checked
         Width           =   3975
      End
      Begin VB.CheckBox ChkImpresion 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Imprimir el nombre de la sucursal"
         Height          =   240
         Index           =   2
         Left            =   240
         TabIndex        =   11
         Top             =   3120
         Width           =   3855
      End
      Begin VB.Frame Frame2 
         BackColor       =   &H00FFFFFF&
         BorderStyle     =   0  'None
         Height          =   375
         Left            =   120
         TabIndex        =   17
         Top             =   2640
         Width           =   4215
         Begin VB.OptionButton OptDatos 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Datos del cliente"
            Height          =   240
            Index           =   0
            Left            =   0
            TabIndex        =   9
            Top             =   120
            Value           =   -1  'True
            Width           =   1815
         End
         Begin VB.OptionButton OptDatos 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Datos de la sucursal"
            Height          =   240
            Index           =   1
            Left            =   1920
            TabIndex        =   10
            Top             =   120
            Width           =   2175
         End
      End
      Begin VB.Frame Frame1 
         BackColor       =   &H00FFFFFF&
         BorderStyle     =   0  'None
         Height          =   375
         Left            =   120
         TabIndex        =   16
         Top             =   2520
         Width           =   3015
         Begin VB.OptionButton OptPiezas 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Piezas"
            Height          =   240
            Index           =   0
            Left            =   0
            TabIndex        =   6
            Top             =   120
            Value           =   -1  'True
            Width           =   1215
         End
         Begin VB.OptionButton OptPiezas 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cajas"
            Height          =   240
            Index           =   1
            Left            =   1320
            TabIndex        =   7
            Top             =   120
            Width           =   1335
         End
      End
      Begin VB.CheckBox ChkImpresion 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Especificar descuentos"
         Height          =   240
         Index           =   1
         Left            =   120
         TabIndex        =   5
         Top             =   2280
         Width           =   4215
      End
      Begin VB.CheckBox ChkImpresion 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Una partida por cada precio de venta"
         Height          =   240
         Index           =   0
         Left            =   120
         TabIndex        =   4
         Top             =   1920
         Width           =   4215
      End
      Begin VB.CommandButton btnImprimir 
         BackColor       =   &H00FFFFFF&
         Height          =   495
         Left            =   1320
         Picture         =   "CC_OpcImpFactura.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   13
         Top             =   4560
         Width           =   1815
      End
      Begin MSComctlLib.ListView LstImpuestos 
         Height          =   855
         Left            =   840
         TabIndex        =   8
         Top             =   6000
         Width           =   4335
         _ExtentX        =   7646
         _ExtentY        =   1508
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
      Begin MSComCtl2.DTPicker DTPFecha 
         Height          =   375
         Left            =   960
         TabIndex        =   0
         Top             =   360
         Width           =   3375
         _ExtentX        =   5953
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
         CustomFormat    =   "dddd dd MMM yyyy"
         Format          =   54722563
         CurrentDate     =   39376
      End
      Begin VB.Label Label4 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Folio de Factura"
         Height          =   255
         Left            =   240
         TabIndex        =   20
         Top             =   1200
         Width           =   1455
      End
      Begin VB.Label Label3 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Fecha:"
         Height          =   255
         Left            =   120
         TabIndex        =   19
         Top             =   360
         Width           =   615
      End
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Observaciones"
         Height          =   255
         Left            =   360
         TabIndex        =   18
         Top             =   3480
         Width           =   2055
      End
      Begin VB.Label Label1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Impuestos a desglosar"
         Height          =   255
         Left            =   1080
         TabIndex        =   15
         Top             =   5760
         Width           =   2055
      End
   End
End
Attribute VB_Name = "CC_OpcImpFactura"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDImpuestos, LstDVentasFacturar

Private Sub btnImprimir_Click()
On Error Resume Next

Dim OpcFact, IdCedisAnt, FechaAnt As Date
Dim LstDStrIds, FolioFactura, tempStrIds, LstDstrFolios, tempStrFolios

    If Trim(TxtFolio.Text) = "" And ChkImpresion(3).Value Then
        MsgBox "¡ Capture el Folio del Documento en el que se va a Imprimir !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    
    OpenConn Server, "RouteADM", UserDB, PasswordDB

    FolioFactura = TxtFolio.Text

'    OpcFact = 0
'    With CC_FacturasBusqueda
'        If .ChkFact(1).Value And Not .ChkFact(2).Value Then OpcFact = 1
'        If Not .ChkFact(1).Value And .ChkFact(2).Value Then OpcFact = 2
'        If .ChkFact(1).Value And .ChkFact(2).Value Then OpcFact = 3
'    End With

    OpcFact = 1
    
    ReDim LstDStrIds(0): ReDim LstDstrFolios(0)
    i = 0: tempStrIds = "": tempStrFolios = ""
    StrCmd = "exec sel_FacturasImpresion '" & CC_FacturasBusqueda.strIds & "', " & OpcFact & ", 11"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
'    IdCedisAnt = Rs.Fields(0): FechaAnt = Rs.Fields(4)
    If Rs.State Then
    While Not Rs.EOF
        
        tempStrIds = tempStrIds & " ( Ventas.IdCedis = " & Rs.Fields(0) & " and Ventas.IdTipoVenta = " & Rs.Fields(1) & " and Ventas.Serie = ''" & Rs.Fields(2) & "'' and Ventas.Folio = " & Rs.Fields(3) & ") or "
        tempStrFolios = tempStrFolios & Rs.Fields(2) & " - " & Rs.Fields(3) & ", "
        
        If i > 0 Then
            ReDim Preserve LstDStrIds(i)
            ReDim Preserve LstDstrFolios(i)
        End If
        LstDStrIds(i) = Mid(tempStrIds, 1, Len(tempStrIds) - 3)
        LstDstrFolios(i) = Mid(tempStrFolios, 1, Len(tempStrFolios) - 2)

        If ChkImpresion(3) Then
            StrCmd = "exec up_FacturasImpresion '" & LstDStrIds(i) & "', '" & FolioFactura & "', 1"
            If RsC2.State Then RsC2.Close
            RsC2.Open StrCmd, Cnn
        End If
        ImprimeFactura LstDStrIds(i), LstDstrFolios(i)

        i = i + 1: tempStrIds = "": tempStrFolios = ""
        FolioFactura = FolioFactura + 1
        'If CC_FacturasBusqueda.ChkFact(0).Value Then FolioFactura = FolioFactura + 1

'        If IdCedisAnt <> Rs.Fields(0) And (OpcFact = 1 Or OpcFact = 3) Then
'            IdCedisAnt = Rs.Fields(0)
'            If i > 0 Then
'                ReDim Preserve LstDStrIds(i)
'                ReDim Preserve LstDstrFolios(i)
'            End If
'            LstDStrIds(i) = Mid(tempStrIds, 1, Len(tempStrIds) - 3)
'            LstDstrFolios(i) = Mid(tempStrFolios, 1, Len(tempStrFolios) - 2)
'
'            If ChkImpresion(3) Then
'                StrCmd = "exec up_FacturasImpresion '" & LstDStrIds(i) & "', '" & FolioFactura & "', 1"
'                If RsC2.State Then RsC2.Close
'                RsC2.Open StrCmd, Cnn
'            End If
'            ImprimeFactura LstDStrIds(i), LstDstrFolios(i)
'
'            i = i + 1: tempStrIds = "": tempStrFolios = ""
'            If CC_FacturasBusqueda.ChkFact(0).Value Then FolioFactura = FolioFactura + 1
'        End If
'
'        If FechaAnt <> CDate(Rs.Fields(4)) And (OpcFact = 2 Or OpcFact = 3) Then
'            FechaAnt = CDate(Rs.Fields(4))
'            If i > 0 Then
'                ReDim Preserve LstDStrIds(i)
'                ReDim Preserve LstDstrFolios(i)
'            End If
'            LstDStrIds(i) = Mid(tempStrIds, 1, Len(tempStrIds) - 3)
'            LstDstrFolios(i) = Mid(tempStrFolios, 1, Len(tempStrFolios) - 2)
'
'            If ChkImpresion(3) Then
'                StrCmd = "exec up_FacturasImpresion '" & LstDStrIds(i) & "', '" & FolioFactura & "', 1"
'                If RsC2.State Then RsC2.Close
'                RsC2.Open StrCmd, Cnn
'            End If
'            ImprimeFactura LstDStrIds(i), LstDstrFolios(i)
'
'            i = i + 1: tempStrIds = "": tempStrFolios = ""
'            If CC_FacturasBusqueda.ChkFact(0).Value Then FolioFactura = FolioFactura + 1
'        End If
        
        Rs.MoveNext
    Wend
    End If
'    If i > 0 Then
'        ReDim Preserve LstDStrIds(i)
'        ReDim Preserve LstDstrFolios(i)
'    End If
'    LstDStrIds(i) = Mid(tempStrIds, 1, Len(tempStrIds) - 3)
'    LstDstrFolios(i) = Mid(tempStrFolios, 1, Len(tempStrFolios) - 2)
'
'    If ChkImpresion(3) Then
'        StrCmd = "exec up_FacturasImpresion '" & LstDStrIds(i) & "', '" & FolioFactura & "', 1"
'        If RsC2.State Then RsC2.Close
'        RsC2.Open StrCmd, Cnn
'    End If
'    ImprimeFactura LstDStrIds(i), LstDstrFolios(i)

End Sub

Sub ImprimeFactura(strIds, strFolios)
    
    With CC_RptFacturaD
        .LblFecha.Caption = Format(DTPFecha.Value, "dd-Mmm-yyyy")
        .LblFechaL.Caption = Format(DTPFecha.Value, "dd-Mmm-yyyy")
        
        StrCmd = "exec sel_FacturasImpresion '" & strIds & "', " & IIf(OptPiezas(0).Value, 1, 2) & ", " & IIf(OptDatos(0).Value, 3, 4)
        If Rs2.State Then Rs2.Close
        Rs2.Open StrCmd, Cnn
        If Not Rs2.EOF Then
            .LblRFC.Caption = Rs2.Fields(1)
            .LblNombre.Caption = Rs2.Fields(2)
            .LblDireccion.Caption = Rs2.Fields(3)
        End If
            
        .LblObservaciones = ""
        If Trim(TxtObservaciones.Text) <> "" Then .LblObservaciones.Caption = TxtObservaciones.Text
        If ChkImpresion(4).Value Then .LblObservaciones.Caption = .LblObservaciones.Caption & Chr(13) & Chr(10) & strFolios
        If ChkImpresion(2).Value Then
            StrCmd = "exec sel_FacturasImpresion '" & strIds & "', " & IIf(OptPiezas(0).Value, 1, 2) & ", 4"
            If Rs2.State Then Rs2.Close
            Rs2.Open StrCmd, Cnn
            .LblObservaciones.Caption = .LblObservaciones.Caption & Chr(13) & Chr(10) & Rs2.Fields(1)
        End If
        
        '.LblCaja.Caption = IIf(OptPiezas(0).Value, OptPiezas(0).Caption, OptPiezas(1).Caption)
'        .LblSubtotal.Caption = FormatCurrency(CC_FacturasBusqueda.LblSubtotal, 2, vbTrue)
'        .LblIva.Caption = FormatCurrency(CC_FacturasBusqueda.LblIva, 2, vbTrue)
'        .LblTotal.Caption = FormatCurrency(CC_FacturasBusqueda.LblTotal, 2, vbTrue)
            
        StrCmd = "exec sel_FacturasImpresion '" & strIds & "', " & IIf(OptPiezas(0).Value, 1, 2) & ", " & IIf(CC_FacturasBusqueda.OptConsulta(1).Value, 1, 2)
        If Rs2.State Then Rs2.Close
        Rs2.Open StrCmd, Cnn
        
        If Not Rs2.EOF Then
            .object.DataSrc.DataSourceName = Cnn
            .object.DataSrc.Recordset = Rs2
        End If
        
        .Printer.Orientation = ddOPortrait
        .Printer.PaperSize = 1
        .Show
        '.PrintReport False
    End With

End Sub

Private Sub Form_Load()
On Error Resume Next
    MuestraImpuestos
    DTPFecha.Value = Date
End Sub

Sub MuestraImpuestos()
On Error Resume Next
    StrCmd = "select 'IVA11' as Id, 'IVA 11%' as Impuesto, 0.11 as Valor"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDImpuestos = GetDataLVL(Rs, LstImpuestos, 0, 2, "0|0|9")
End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    CC_FacturasBusqueda.btnBuscar_Click
    OpenConn Server, Db, UserDB, PasswordDB
End Sub

Private Sub TxtFolio_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itEntero(KeyAscii)
End Sub
