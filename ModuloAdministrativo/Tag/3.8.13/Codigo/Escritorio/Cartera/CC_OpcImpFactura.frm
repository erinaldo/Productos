VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_OpcImpFactura 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   6720
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
   ScaleHeight     =   6720
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
      Height          =   6660
      Index           =   2
      Left            =   120
      TabIndex        =   14
      Top             =   0
      Width           =   4575
      Begin VB.TextBox TxtFolio 
         Height          =   360
         Left            =   2160
         TabIndex        =   2
         Top             =   1120
         Width           =   975
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
         Top             =   5160
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
         Top             =   4560
         Width           =   3855
      End
      Begin VB.Frame Frame2 
         BackColor       =   &H00FFFFFF&
         BorderStyle     =   0  'None
         Height          =   375
         Left            =   120
         TabIndex        =   17
         Top             =   4080
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
         Width           =   2415
         Begin VB.OptionButton OptPiezas 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Piezas"
            Height          =   240
            Index           =   0
            Left            =   0
            TabIndex        =   6
            Top             =   120
            Value           =   -1  'True
            Width           =   975
         End
         Begin VB.OptionButton OptPiezas 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cajas"
            Height          =   240
            Index           =   1
            Left            =   1080
            TabIndex        =   7
            Top             =   120
            Width           =   975
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
         Top             =   6000
         Width           =   1815
      End
      Begin MSComctlLib.ListView LstImpuestos 
         Height          =   855
         Left            =   120
         TabIndex        =   8
         Top             =   3240
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
         Format          =   105840643
         CurrentDate     =   39376
      End
      Begin VB.Label Label4 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Folio del Documento"
         Height          =   255
         Left            =   240
         TabIndex        =   20
         Top             =   1200
         Width           =   1815
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
         Top             =   4920
         Width           =   2055
      End
      Begin VB.Label Label1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Impuestos a desglosar"
         Height          =   255
         Left            =   360
         TabIndex        =   15
         Top             =   3000
         Width           =   2055
      End
   End
End
Attribute VB_Name = "CC_OpcImpFactura"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDImpuestos
Public strIds, strFolios, OptCons, ReporteFactura As DDActiveReports.ActiveReport, Ventana As Boolean, IdPedido As Long

Private Sub btnImprimir_Click()
On Error GoTo Err_ImpFactOpc:

    If Trim(TxtFolio.Text) = "" And ChkImpresion(3).Value Then
        MsgBox "¡ Capture el Folio del Documento en el que se va a Imprimir !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    OpenConn Server, "RouteADM", UserDB, PasswordDB
    
    'OptCons = 0 Factura Global de Contado del Día
    'OptCons = 1 Ventas desde módulo de Facturación
    'OptCons = 2 Pedidos Route desde módulo de Facturación
    'OptCons = 5 Pedidos ADM
    
    Select Case LstConfiguraLiquidacion(8)
        
        Case "MODELOORIENTE":
            With CC_RptFacturaModelo
            
                .LblFecha.Caption = Format(DTPFecha.Value, "DD"" de ""MMMM"" de "" YYYY")
                
                If ChkImpresion(3) Then
                    Select Case OptCons
                    Case 1, 2:
                        StrCmd = "exec up_FacturasImpresion '" & strIds & "', '" & Trim(TxtFolio.Text) & "', " & OptCons
                        If Rs.State Then Rs.Close
                        Rs.Open StrCmd, Cnn
                    Case 5:
                        StrCmd = "exec up_FacturasImpresion '''C" & Format(IdCedis, "00") & "Ped" & Format(IdPedido, "000000000") & "''', '" & Trim(TxtFolio.Text) & "', " & OptCons
                        If Rs.State Then Rs.Close
                        Rs.Open StrCmd, Cnn
                    Case 0
                        StrCmd = "exec up_VentasContado " & IdCedis & ", '" & FormatDate(CDate(strIds)) & "', '" & Trim(strFolios) & "', '', '" & Trim(TxtFolio.Text) & "', 2"
                        If Rs.State Then Rs.Close
                        Rs.Open StrCmd, Cnn
                    End Select
                End If
                
                Select Case OptCons
                Case 1, 2, 5:
                    StrCmd = "exec sel_FacturasImpresion '" & strIds & "', " & IIf(OptPiezas(0).Value, 1, 2) & ", " & IIf(OptDatos(0).Value, 3, 4)
                Case 0
                    StrCmd = "exec sel_FacturasImpresion '" & strIds & "', " & IIf(OptPiezas(0).Value, 1, 2) & ", 5"
                End Select
                If Rs.State Then Rs.Close
                Rs.Open StrCmd, Cnn
                If Not Rs.EOF Then
                    .LblRFC.Caption = Rs.Fields(1)
                    .LblNombre.Caption = Rs.Fields(2)
                    .LblDireccion.Caption = Rs.Fields(3)
                End If
                    
                .LblObservaciones.Caption = ""
                If Trim(TxtObservaciones.Text) <> "" Then .LblObservaciones.Caption = TxtObservaciones.Text
                
                Select Case OptCons
                Case 1, 2, 5:
                    If ChkImpresion(4).Value Then .LblObservaciones.Caption = .LblObservaciones.Caption & Chr(13) & Chr(10) & strFolios
                    If ChkImpresion(2).Value Then
                        StrCmd = "exec sel_FacturasImpresion '" & strIds & "', " & IIf(OptPiezas(0).Value, 1, 2) & ", 4"
                        If Rs.State Then Rs.Close
                        Rs.Open StrCmd, Cnn
                        .LblObservaciones.Caption = .LblObservaciones.Caption & Chr(13) & Chr(10) & Rs.Fields(1)
                    End If
                End Select
                
                StrCmd = "exec sel_FacturasImpresion '" & strIds & "', " & IIf(OptPiezas(0).Value, 1, 2) & ", " & OptCons
                If Rs.State Then Rs.Close
                Rs.Open StrCmd, Cnn
                
                If Not Rs.EOF Then
                    .LblCaja.Caption = IIf(OptPiezas(0).Value, OptPiezas(0).Caption, OptPiezas(1).Caption)
                    
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = Rs
                    .Printer.Orientation = ddOPortrait
                    .Printer.PaperSize = 1
                    .Show
                End If
            End With
        
        Case "ARACELI":
            With CC_RptFacturaAraceli
            
                .LblFecha.Caption = Format(DTPFecha.Value, "dd-Mmm-yyyy")
                
                If ChkImpresion(3) Then
                    Select Case OptCons
                    Case 1, 2:
                        StrCmd = "exec up_FacturasImpresion '" & strIds & "', '" & Trim(TxtFolio.Text) & "', " & OptCons
                        If Rs.State Then Rs.Close
                        Rs.Open StrCmd, Cnn
                    Case 5:
                        StrCmd = "exec up_FacturasImpresion '''C" & Format(IdCedis, "00") & "Ped" & Format(IdPedido, "000000000") & "''', '" & Trim(TxtFolio.Text) & "', " & OptCons
                        If Rs.State Then Rs.Close
                        Rs.Open StrCmd, Cnn
                    Case 0
                        StrCmd = "exec up_VentasContado " & IdCedis & ", '" & FormatDate(CDate(strIds)) & "', '" & Trim(strFolios) & "', '', '" & Trim(TxtFolio.Text) & "', 2"
                        If Rs.State Then Rs.Close
                        Rs.Open StrCmd, Cnn
                    End Select
                End If
                
                Select Case OptCons
                Case 1, 2, 5:
                    StrCmd = "exec sel_FacturasImpresion '" & strIds & "', " & IIf(OptPiezas(0).Value, 1, 2) & ", " & IIf(OptDatos(0).Value, 3, 4)
                Case 0
                    StrCmd = "exec sel_FacturasImpresion '" & CDate(strIds) & "', " & IIf(OptPiezas(0).Value, 1, 2) & ", 7"
                End Select
                If Rs.State Then Rs.Close
                Rs.Open StrCmd, Cnn
                If Not Rs.EOF Then
                    .LblRFC.Caption = Rs.Fields(1)
                    .LblNombre.Caption = Rs.Fields(2)
                    .LblDireccion.Caption = Rs.Fields(3)
                End If
                    
                .LblObservaciones.Caption = ""
                If Trim(TxtObservaciones.Text) <> "" Then .LblObservaciones.Caption = TxtObservaciones.Text
                Select Case OptCons
                Case 1, 2, 5:
                    If ChkImpresion(4).Value Then .LblObservaciones.Caption = .LblObservaciones.Caption & Chr(13) & Chr(10) & strFolios
                    If ChkImpresion(2).Value Then
                        StrCmd = "exec sel_FacturasImpresion '" & strIds & "', " & IIf(OptPiezas(0).Value, 1, 2) & ", 4"
                        If Rs.State Then Rs.Close
                        Rs.Open StrCmd, Cnn
                        .LblObservaciones.Caption = .LblObservaciones.Caption & Chr(13) & Chr(10) & Rs.Fields(0) & " - " & Rs.Fields(4)
                    End If
                End Select
                
                Select Case OptCons
                Case 1, 2, 5:
                    StrCmd = "exec sel_FacturasImpresion '" & strIds & "', " & IIf(OptPiezas(0).Value, 1, 2) & ", " & OptCons
                Case 0
                    StrCmd = "exec sel_VentasContado " & IdCedis & ", '" & FormatDate(CDate(strIds)) & "', " & IIf(OptPiezas(0).Value, 2, 3)
                End Select
                If Rs.State Then Rs.Close
                Rs.Open StrCmd, Cnn
                
                If Not Rs.EOF Then
                    .LblCaja.Caption = IIf(OptPiezas(0).Value, OptPiezas(0).Caption, OptPiezas(1).Caption)
                    .object.DataSrc.DataSourceName = Cnn
                    .object.DataSrc.Recordset = Rs
                    .Printer.Orientation = ddOPortrait
                    .Printer.PaperSize = 1
                    .Show
                End If
            End With
    End Select
    
No_Err_ImpFactOpc:
    MousePointer = 0
    Exit Sub
    
Err_ImpFactOpc:
    MousePointer = 0
    MsgBox "Error al Imprimir la Factura. Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_ImpFactOpc::

End Sub

Private Sub Form_Load()
On Error Resume Next
    MuestraImpuestos
    DTPFecha.Value = Date
End Sub

Sub MuestraImpuestos()
On Error Resume Next
'    StrCmd = "select 'IVA16' as Id, 'IVA 16%' as Impuesto, 0.16 as Valor"
'    If Rs.State Then Rs.Close
'    Rs.Open StrCmd, Cnn
'    LstDImpuestos = GetDataLVL(Rs, LstImpuestos, 0, 2, "0|0|9")
LstDImpuestos = Empty
End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    If OptCons <> 5 And Ventana Then
        CC_FacturasBusqueda.btnArchivo_Click
    End If
    OpenConn Server, Db, UserDB, PasswordDB
End Sub
