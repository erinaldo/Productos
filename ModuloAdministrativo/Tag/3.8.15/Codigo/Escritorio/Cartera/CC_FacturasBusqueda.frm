VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_FacturasBusqueda 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Búsqueda de Ventas"
   ClientHeight    =   8490
   ClientLeft      =   2400
   ClientTop       =   3030
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
   ScaleHeight     =   8490
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
      TabIndex        =   19
      Top             =   0
      Width           =   12375
      Begin VB.CommandButton btnEnd 
         BackColor       =   &H00FFFFFF&
         Cancel          =   -1  'True
         Height          =   495
         Left            =   2160
         Picture         =   "CC_FacturasBusqueda.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   18
         Top             =   7840
         Width           =   1575
      End
      Begin VB.CommandButton btnImprimir 
         BackColor       =   &H00FFFFFF&
         Height          =   495
         Left            =   240
         Picture         =   "CC_FacturasBusqueda.frx":073B
         Style           =   1  'Graphical
         TabIndex        =   17
         Top             =   7840
         Width           =   1815
      End
      Begin VB.CheckBox ChkVentas 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Seleccionar todas las Ventas"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   360
         TabIndex        =   15
         Top             =   4280
         Width           =   2775
      End
      Begin VB.Frame Frame2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Opciones de Consulta"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   2175
         Left            =   8040
         TabIndex        =   28
         Top             =   840
         Width           =   4215
         Begin VB.CommandButton btnBuscar 
            BackColor       =   &H00FFFFFF&
            Height          =   495
            Left            =   1440
            Picture         =   "CC_FacturasBusqueda.frx":0E56
            Style           =   1  'Graphical
            TabIndex        =   11
            Top             =   1440
            Width           =   1455
         End
         Begin VB.OptionButton OptConsulta 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Venta"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   1
            Left            =   240
            TabIndex        =   7
            Top             =   360
            Value           =   -1  'True
            Width           =   975
         End
         Begin VB.OptionButton OptConsulta 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Preventa"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   2
            Left            =   1320
            TabIndex        =   8
            Top             =   360
            Width           =   1095
         End
         Begin MSComCtl2.DTPicker DTPFechaInicial 
            Height          =   375
            Left            =   600
            TabIndex        =   9
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
            Format          =   54460417
            CurrentDate     =   39376
         End
         Begin MSComCtl2.DTPicker DTPFechaFinal 
            Height          =   375
            Left            =   2520
            TabIndex        =   10
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
            Format          =   54460417
            CurrentDate     =   39376
         End
         Begin VB.Label Label3 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Al"
            Height          =   255
            Left            =   2160
            TabIndex        =   30
            Top             =   840
            Width           =   375
         End
         Begin VB.Label Label1 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Del"
            Height          =   255
            Left            =   120
            TabIndex        =   29
            Top             =   840
            Width           =   375
         End
      End
      Begin VB.Frame Frame1 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Opciones de Facturación"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   855
         Left            =   8040
         TabIndex        =   25
         Top             =   2880
         Visible         =   0   'False
         Width           =   4215
         Begin VB.CheckBox ChkFact 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Una Factura por Cedis"
            Height          =   240
            Index           =   1
            Left            =   120
            TabIndex        =   12
            Top             =   405
            Width           =   3975
         End
         Begin VB.CheckBox ChkFact 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Una Factura por Día"
            Height          =   240
            Index           =   2
            Left            =   120
            TabIndex        =   13
            Top             =   680
            Value           =   1  'Checked
            Width           =   3975
         End
         Begin VB.CheckBox ChkFact 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Asignar Folios automáticamente"
            Height          =   240
            Index           =   0
            Left            =   120
            TabIndex        =   14
            Top             =   940
            Value           =   1  'Checked
            Width           =   3975
         End
         Begin VB.TextBox TxtFolio 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   1320
            MaxLength       =   9
            TabIndex        =   26
            Top             =   1680
            Visible         =   0   'False
            Width           =   1335
         End
         Begin VB.Label Label4 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Folio de Factura"
            Height          =   240
            Left            =   1320
            TabIndex        =   27
            Top             =   1440
            Visible         =   0   'False
            Width           =   1410
         End
      End
      Begin VB.Frame Frame3 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Datos del Cliente"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   3855
         Left            =   120
         TabIndex        =   20
         Top             =   240
         Width           =   7815
         Begin VB.OptionButton OptConsulta 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Por Cliente"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   4
            Left            =   360
            TabIndex        =   0
            Top             =   360
            Value           =   -1  'True
            Width           =   1215
         End
         Begin VB.OptionButton OptConsulta 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Por Sucursal"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   240
            Index           =   3
            Left            =   1800
            TabIndex        =   1
            Top             =   360
            Width           =   1455
         End
         Begin VB.CheckBox ChkSeleccionar 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Seleccionar todos"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   8.25
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   5400
            TabIndex        =   5
            Top             =   960
            Width           =   1815
         End
         Begin VB.TextBox TxtRazonSocial 
            Height          =   375
            Left            =   3000
            TabIndex        =   4
            Top             =   960
            Width           =   2295
         End
         Begin VB.TextBox TxtRFC 
            Height          =   375
            Left            =   240
            TabIndex        =   2
            Top             =   960
            Width           =   1575
         End
         Begin VB.TextBox TxtIdCliente 
            Alignment       =   1  'Right Justify
            Height          =   375
            Left            =   1920
            TabIndex        =   3
            Top             =   960
            Width           =   975
         End
         Begin MSComctlLib.ListView LstClientes 
            Height          =   2295
            Left            =   120
            TabIndex        =   6
            Top             =   1395
            Width           =   7575
            _ExtentX        =   13361
            _ExtentY        =   4048
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
         Begin VB.Label Label22 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Cliente"
            Height          =   240
            Left            =   240
            TabIndex        =   24
            Top             =   720
            Width           =   600
         End
         Begin VB.Label Label21 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Sucursal"
            Height          =   255
            Left            =   3000
            TabIndex        =   23
            Top             =   720
            Width           =   1695
         End
         Begin VB.Label Label20 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Id Sucursal"
            Height          =   240
            Left            =   1920
            TabIndex        =   22
            Top             =   720
            Width           =   975
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
            Height          =   210
            Left            =   5280
            TabIndex        =   21
            Top             =   600
            Visible         =   0   'False
            Width           =   2325
         End
      End
      Begin MSComctlLib.ListView LstFacturas 
         Height          =   3255
         Left            =   120
         TabIndex        =   16
         Top             =   4560
         Width           =   12015
         _ExtentX        =   21193
         _ExtentY        =   5741
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
      Begin VB.Label Label9 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Total:"
         Height          =   240
         Left            =   10080
         TabIndex        =   38
         Top             =   7920
         Width           =   480
      End
      Begin VB.Label LblTotal 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "$ 0.00"
         ForeColor       =   &H80000008&
         Height          =   345
         Left            =   10665
         TabIndex        =   37
         Top             =   7920
         Width           =   1395
      End
      Begin VB.Label Label7 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Iva:"
         Height          =   240
         Left            =   8160
         TabIndex        =   36
         Top             =   7920
         Width           =   285
      End
      Begin VB.Label LblIva 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "$ 0.00"
         ForeColor       =   &H80000008&
         Height          =   345
         Left            =   8595
         TabIndex        =   35
         Top             =   7920
         Width           =   1395
      End
      Begin VB.Label Label6 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Subtotal:"
         Height          =   240
         Left            =   5760
         TabIndex        =   34
         Top             =   7920
         Width           =   780
      End
      Begin VB.Label LblSubtotal 
         Alignment       =   1  'Right Justify
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "$ 0.00"
         ForeColor       =   &H80000008&
         Height          =   345
         Left            =   6660
         TabIndex        =   33
         Top             =   7920
         Width           =   1395
      End
      Begin VB.Label Label8 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Ventas"
         Height          =   240
         Left            =   4110
         TabIndex        =   32
         Top             =   7920
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
         Left            =   4800
         TabIndex        =   31
         Top             =   7920
         Width           =   915
      End
   End
End
Attribute VB_Name = "CC_FacturasBusqueda"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDClientes, LstDFacturas, Base As Integer
Public strIds, strFolios
Dim bPedidoSel As Boolean
Dim bFacturaSel As Boolean

Public Sub btnBuscar_Click()
Dim Opc, IdCte, Folio, StrRutas

On Error GoTo Err_btnBuscar:

    MousePointer = 11

    Folio = ""
    
    If IsEmpty(LstDClientes) Then
        MousePointer = 0
        MsgBox "¡ Selecciona los clientes para Imprimir Facturas !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    IdCte = ""
    For i = 1 To LstClientes.ListItems.Count
        If LstClientes.ListItems(i).Checked Then
            IdCte = IdCte & "''" & LstClientes.ListItems(i).ListSubItems(2) & "'', "
        End If
    Next
    If Len(IdCte) > 0 Then
        IdCte = Mid(IdCte, 1, Len(IdCte) - 2)
    Else
        MousePointer = 0
        MsgBox "¡ Selecciona los clientes para Imprimir Facturas !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    StrRutas = ""
'    For i = 1 To LstRutas.ListItems.Count
'        If LstRutas.ListItems(i).Checked Then
'            If OptConsulta(1).Value Then
'                StrRutas = StrRutas & LstRutas.ListItems(i) & ", "
'            Else
'                StrRutas = StrRutas & "''" & LstRutas.ListItems(i) & "'', "
'            End If
'        End If
'    Next
'    If Len(StrRutas) > 0 Then StrRutas = Mid(StrRutas, 1, Len(StrRutas) - 2)
    
    Opc = IIf(OptConsulta(1).Value, 1, 2)
        
'    OpenConn Server, "RouteADM", UserDB, PasswordDB
    StrCmd = "execute sel_FacturasBusqueda 0, '" & IdCte & "', '', '', '" & FormatDate(DTPFechaInicial.Value) & "', '" & FormatDate(DTPFechaFinal.Value) & "', " & Opc
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Rs.EOF Then MsgBox "¡ Ventas no encontradas con los criterios seleccionados !", vbInformation + vbOKOnly, App.Title
    LstDFacturas = GetDataLVL(Rs, LstFacturas, 2, 20, "0|4|0|0|0|4|4|4|0|0|0|0|0|0|0|0|9|9|3")
    ChkVentas.Value = 0
    OpenConn Server, Db, UserDB, PasswordDB
    
    
No_Err_btnBuscar:
    MousePointer = 0
    Exit Sub
        
Err_btnBuscar:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_btnBuscar:
End Sub

Private Function RegistroSeleccionado() As Boolean
    bFacturaSel = False
    bPedidoSel = False
    For i = 1 To LstFacturas.ListItems.Count
        If bFacturaSel And bPedidoSel Then Exit For
        If LstFacturas.ListItems(i).Checked Then
            If Trim(LstDFacturas(2, i - 1)) <> "N" Then
                bFacturaSel = True
            Else
                bPedidoSel = True
            End If
        End If
    Next
    RegistroSeleccionado = (bFacturaSel Or bPedidoSel)
End Function

Private Sub btnEnd_Click()
On Error GoTo Err_CancelaDiaria:
Dim SerieN, FolioN
    
    If Not RegistroSeleccionado Then
        MsgBox "¡Seleccione con las casillas de verificación las Facturas a cancelar!", vbInformation + vbOKOnly, App.Title
        Exit Sub
    ElseIf bPedidoSel And Not bFacturaSel Then
        MsgBox "¡Las Remisiones no pueden ser canceladas! Seleccione con las casillas de verificación las Facturas a cancelar.", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    strIds = "": strFolios = ""
    
    If CFDCedis = "1" Then
        MensajeCFD = ""

        Dim sMensaje As String
        If bPedidoSel Then
            sMensaje = "Las remisiones no pueden ser canceladas, solo se cancelarán las facturas. Esta operacion puede tardar varios minutos ¿desea continuar?"
        Else
            sMensaje = "La cancelación de los CFDI puede tardar varios minutos. ¿ Deseas continuar ?"
        End If

        If MsgBox(sMensaje, vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
            
        MousePointer = 11
        Actividad = 1
        
        For i = 1 To LstFacturas.ListItems.Count
            If LstFacturas.ListItems(i).Checked Then
                If Trim(LstDFacturas(2, i - 1)) <> "N" Then
                
                
                            Set ClaseCFDADM = New LbCFDADM.LbCFDADM
                    MensajeCFD = ClaseCFDADM.LlamarCFDADM(PathRouteDesktop, LstDFacturas(21, i - 1), RutaXML, 4)
                    
                    If StringStartsWith(MensajeCFD, "202", vbTextCompare) Then
                    MensajeCFD = LstDFacturas(2, i - 1) & ": " & MensajeCFD
                    MsgBox MensajeCFD
                     GoTo Continua:
                    End If
                    
                    If Trim(MensajeCFD) <> "" Then
                    MensajeCFD = LstDFacturas(2, i - 1) & ": " & MensajeCFD
                    GoTo Err_CancelacionCFDI:
                    End If
Continua:
                
                
                    StrCmd = "execute up_VentasFactura " & LstDFacturas(0, i - 1) & ", " & LstDFacturas(1, i - 1) & ", " & LstDFacturas(6, i - 1) & ", '" & LstDFacturas(5, i - 1) & "', 0, '', " & Actividad & ", 4"
                    If Rs.State Then Rs.Close
                    Rs.Open StrCmd, Cnn
                End If
            End If
        Next
        btnBuscar_Click
    End If
    
No_Err_CancelaDiaria:
    MousePointer = 0
    MsgBox "¡ Proceso de Cancelación Finalizado !", vbInformation + vbOKOnly, App.Title
    Exit Sub
    
Err_CancelaDiaria:
    MousePointer = 0
    If Trim(MensajeCFD) = "" Then
        MsgBox "Error al crear " & IIf(CFDCedis = "1", " el CFDI", "la Factura") & " : " & Err.Description, vbInformation + vbOKOnly, App.Title
    Else
        MsgBox MensajeCFD, vbInformation + vbOKOnly, App.Title
        btnBuscar_Click
    End If
    GoTo No_Err_CancelaDiaria:
    
    
Err_CancelacionCFDI:
    MousePointer = 0
    MsgBox "Error: " & MensajeCFD, vbInformation + vbOKOnly, App.Title
 
    

End Sub

Private Sub btnImprimir_Click()
On Error GoTo Err_FacturaDiaria:
Dim SerieN, FolioN

    strIds = "": strFolios = ""
    
    If CFDCedis = "1" Then
    
        MensajeCFD = ""
        Dim bPorFacturar As Boolean
        bPorFacturar = False
        'Revisar si al menos una no esta timbrada
        For i = 1 To LstFacturas.ListItems.Count
            If LstFacturas.ListItems(i).Checked Then
                If Trim(LstDFacturas(2, i - 1)) = "N" Then
                    bPorFacturar = True
                End If
            End If
        Next
        
        If (bPorFacturar) Then
            If MsgBox("La creación de los CFDI puede tardar varios minutos. ¿ Deseas continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
            
            Dim utilWeb As UtileriaWeb
            Set utilWeb = New UtileriaWeb
            Dim mensajePing As String
            mensajePing = ""
            
            If Not utilWeb.VerificarServicioTimbrado(Cnn, Rs, mensajePing) Then
                MsgBox mensajePing
                Exit Sub
            End If
        End If
        
        MousePointer = 11
        Actividad = 1
        
         For i = 1 To LstFacturas.ListItems.Count
            If LstFacturas.ListItems(i).Checked Then
                If Trim(LstDFacturas(2, i - 1)) <> "N" Then 'Si ya fue facturada y solo es reeimpresion
                
                    StrCmd = "execute sel_VentasFacturaCFD " & LstDFacturas(0, i - 1) & ", 0, " & LstDFacturas(1, i - 1) & ", '" & LstDFacturas(5, i - 1) & "', " & LstDFacturas(6, i - 1) & ", 1, 1"
                    If RsC.State Then RsC.Close
                    RsC.Open StrCmd, Cnn
                    If Not RsC.EOF Then
                        TransProdIDFactura = RsC.Fields(6)
                    Else
                        TransProdIDFactura = ""
                        GoTo ImpFactDiaria:
                    End If
                
                    
                    Set ClaseCFDADM = New LbCFDADM.LbCFDADM
                    MensajeCFD = ClaseCFDADM.LlamarCFDADM(PathRouteDesktop, TransProdIDFactura, RutaXML, 2)
                    If Trim(MensajeCFD) <> "" Then GoTo Err_FacturaDiaria:
                
                Else
                    StrCmd = "execute up_VentasFactura " & LstDFacturas(0, i - 1) & ", " & LstDFacturas(1, i - 1) & ", " & LstDFacturas(6, i - 1) & ", '" & LstDFacturas(5, i - 1) & "', 0, '', " & Actividad & ", 1"
                    If Rs.State Then Rs.Close
                    Rs.Open StrCmd, Cnn
                    
                    StrCmd = "execute sel_VentasFacturaCFD " & LstDFacturas(0, i - 1) & ", 0, " & LstDFacturas(1, i - 1) & ", '" & LstDFacturas(5, i - 1) & "', " & LstDFacturas(6, i - 1) & ", 1, 3"
                    If RsC.State Then RsC.Close
                    RsC.Open StrCmd, Cnn
                    If Not RsC.EOF Then
                        TransProdIDFactura = RsC.Fields(6)
    
                    Else
                        TransProdIDFactura = ""
                        GoTo ImpFactDiaria:
                    End If
                
                    
                    Set ClaseCFDADM = New LbCFDADM.LbCFDADM
                    MensajeCFD = ClaseCFDADM.LlamarCFDADM(PathRouteDesktop, TransProdIDFactura, RutaXML, 1)
                    If Trim(MensajeCFD) <> "" Then GoTo Err_FacturaDiaria:
                
                    StrCmd = "execute up_VentasFactura " & LstDFacturas(0, i - 1) & ", " & LstDFacturas(1, i - 1) & ", " & LstDFacturas(6, i - 1) & ", '" & LstDFacturas(5, i - 1) & "', 0, '', " & Actividad & ", 6"
                    If Rs.State Then Rs.Close
                    Rs.Open StrCmd, Cnn

                End If
            End If
        Next
        If bPorFacturar Then
            btnBuscar_Click
        End If
        GoTo No_Err_FacturaDiaria
            
    Else
        For i = 1 To LstFacturas.ListItems.Count
            If LstFacturas.ListItems(i).Checked Then
                If OptConsulta(1).Value Then
                    strIds = strIds & " ( Ventas.IdCedis = " & LstDFacturas(0, i - 1) & " and Ventas.IdTipoVenta = " & LstDFacturas(1, i - 1) & " and Ventas.Serie = ''" & LstDFacturas(5, i - 1) & "'' and Ventas.Folio = " & LstDFacturas(6, i - 1) & ") or "
                    strFolios = strFolios & LstDFacturas(5, i - 1) & " - " & LstDFacturas(6, i - 1) & ", "
                Else
                    strIds = strIds & "''" & LstDFacturas(15, i - 1) & "'', "
                    strFolios = strFolios & LstDFacturas(15, i - 1) & ", "
                End If
            End If
        Next
        If Len(strIds) > 0 Then
            strIds = IIf(Not OptConsulta(1).Value, "t.transprodid in (", "") & Mid(strIds, 1, Len(strIds) - IIf(OptConsulta(1).Value, 3, 2)) & IIf(Not OptConsulta(1).Value, ")", "")
            strFolios = Mid(strFolios, 1, Len(strFolios) - 2)
        Else
            MsgBox "¡ Selecciona los Documentos a Imprimir !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
ImpFactDiaria:
        With CC_OpcImpFactura
            .OptPiezas(0).Caption = Etiqueta01
            .OptPiezas(1).Caption = Etiqueta02
            .Left = Me.Left + (Me.Width - .Width) / 2
            .Top = Me.Top + (Me.Height - .Height) / 2
            .Show
        End With
    End If
    
No_Err_FacturaDiaria:
    MousePointer = 0
    If bPorFacturar Then
        MsgBox "¡ Proceso de Facturación Finalizado !", vbInformation + vbOKOnly, App.Title
    Else
        MsgBox "¡ Proceso de Impresión Finalizado !", vbInformation + vbOKOnly, App.Title
    End If
    Exit Sub
    
Err_FacturaDiaria:
    MousePointer = 0
    If Trim(MensajeCFD) = "" Then
        MsgBox "Error al crear " & IIf(CFDCedis = "1", " el CFDI", "la Factura") & " : " & Err.Description, vbInformation + vbOKOnly, App.Title
    Else
        MsgBox MensajeCFD, vbInformation + vbOKOnly, App.Title
        btnBuscar_Click
    End If
    GoTo No_Err_FacturaDiaria:
    
End Sub

Private Sub Check1_Click()

End Sub

Private Sub ChkSeleccionar_Click()
On Error Resume Next
    Select Case ChkSeleccionar.Value
        Case 0, 1     'caso de no seleccionar o seleccionar todo
            For i = 1 To LstClientes.ListItems.Count
                LstClientes.ListItems(i).Checked = ChkSeleccionar.Value
            Next
    End Select
End Sub

Private Sub ChkVentas_Click()
On Error Resume Next
    Select Case ChkVentas.Value
        Case 0, 1     'caso de no seleccionar o seleccionar todo
            For i = 1 To LstFacturas.ListItems.Count
                LstFacturas.ListItems(i).Checked = ChkVentas.Value
            Next
            LstFacturas_ItemCheck LstFacturas.ListItems(1)
    End Select
End Sub

Private Sub Form_Activate()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
End Sub

Private Sub Form_Load()
On Error Resume Next
    DTPFechaInicial.Value = Date: DTPFechaFinal.Value = Date
    Base = 0
End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    CC_MovimientosDetalle.Inicio = False
End Sub

Private Sub LstClientes_Click()
On Error Resume Next
    If IsEmpty(LstDClientes) Then Exit Sub
    LblCliente.Caption = Trim(LstClientes.SelectedItem) & " - " & Trim(LstClientes.SelectedItem.ListSubItems(2))
End Sub

Private Sub LstClientes_ItemCheck(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next

    Dim ConteoRegistrosChecados As Integer
    
    ConteoRegistrosChecados = 0
    
    For i = 1 To LstClientes.ListItems.Count
        If LstClientes.ListItems(i).Checked Then
            
            ConteoRegistrosChecados = ConteoRegistrosChecados + 1
        End If
    Next
    
    Select Case ConteoRegistrosChecados
        Case Is = 0
            ChkSeleccionar.Value = 0
        
        Case Is = LstClientes.ListItems.Count
            ChkSeleccionar.Value = 1
        
        Case Is < LstClientes.ListItems.Count
            ChkSeleccionar.Value = 2
    
    End Select

End Sub

Private Sub LstFacturas_DblClick()
On Error Resume Next
    If IsEmpty(LstDFacturas) Then Exit Sub
    DetalleDeFactura LstDFacturas(0, LstFacturas.SelectedItem.Index - 1), LstDFacturas(1, LstFacturas.SelectedItem.Index - 1), LstDFacturas(5, LstFacturas.SelectedItem.Index - 1), LstDFacturas(6, LstFacturas.SelectedItem.Index - 1), Me.Top, Me.Left, Me.Width, Me.Height, Base
End Sub

Private Sub LstFacturas_ItemCheck(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    Dim i, j, k
    Dim Total, SubTotal, Iva
    
    Total = 0: SubTotal = 0: Iva = 0
    For i = 1 To LstFacturas.ListItems.Count
        If LstFacturas.ListItems(i).Checked Then
            SubTotal = SubTotal + CDbl(LstDFacturas(18, LstFacturas.ListItems(i).Index - 1))
            Iva = Iva + CDbl(LstDFacturas(19, LstFacturas.ListItems(i).Index - 1))
            Total = Total + CDbl(LstDFacturas(20, LstFacturas.ListItems(i).Index - 1))
            j = j + 1
        End If
    Next
    LblNoFacturas.Caption = FormatNumber(j, 0, vbTrue)
    LblSubtotal.Caption = FormatNumber(SubTotal, 2, vbTrue)
    LblIva.Caption = FormatNumber(Iva, 2, vbTrue)
    LblTotal.Caption = FormatNumber(Total, 2, vbTrue)
    
    Dim ConteoRegistrosChecados As Integer
    
    ConteoRegistrosChecados = 0
    
    For i = 1 To LstFacturas.ListItems.Count
        If LstFacturas.ListItems(i).Checked Then
            
            ConteoRegistrosChecados = ConteoRegistrosChecados + 1
        End If
    Next
    
    Select Case ConteoRegistrosChecados
        Case Is = 0
            ChkVentas.Value = 0
        
        Case Is = LstFacturas.ListItems.Count
            ChkVentas.Value = 1
        
        Case Is < LstFacturas.ListItems.Count
            ChkVentas.Value = 2
    
    End Select

End Sub

Private Sub TxtFolio_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itEntero(KeyAscii)
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
    
    LstFacturas.ListItems.Clear: LstDFacturas = Empty
    
    If Trim(TxtIdCliente.Text) = "" And Trim(TxtRFC.Text) = "" And Trim(TxtRazonSocial.Text) = "" Then Exit Sub
    
    StrCmd = "execute sel_ClientesFacturas 0,'" & Trim(TxtIdCliente.Text) & "','" & Trim(TxtRFC.Text) & "','" & Trim(TxtRazonSocial.Text) & "', " & IIf(OptConsulta(4).Value, 4, 5)
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LstDClientes = GetDataLVL(RsC, LstClientes, 0, IIf(OptConsulta(4).Value, 3, 5), IIf(OptConsulta(4).Value, "0|0|0|0", "0|0|0|0|0|0"))
End Sub

