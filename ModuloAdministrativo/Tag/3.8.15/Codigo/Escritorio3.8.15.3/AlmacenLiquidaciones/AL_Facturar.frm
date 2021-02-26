VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form AL_Facturar 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   ClientHeight    =   3210
   ClientLeft      =   150
   ClientTop       =   420
   ClientWidth     =   9240
   BeginProperty Font 
      Name            =   "Arial"
      Size            =   9.75
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "AL_Facturar.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   3210
   ScaleWidth      =   9240
   ShowInTaskbar   =   0   'False
   Begin VB.Frame Frame1 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Asignación de Serie y Folio"
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
      TabIndex        =   5
      Top             =   120
      Width           =   9015
      Begin VB.TextBox TxtStatus 
         BorderStyle     =   0  'None
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
         Left            =   5640
         Locked          =   -1  'True
         TabIndex        =   16
         Top             =   1680
         Width           =   2535
      End
      Begin MSComctlLib.ListView LstPartidas 
         Height          =   1110
         Left            =   120
         TabIndex        =   0
         Top             =   1680
         Width           =   3855
         _ExtentX        =   6800
         _ExtentY        =   1958
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
      Begin VB.TextBox TxtDatos 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         TabIndex        =   15
         Text            =   "Datos de la Remisión"
         Top             =   960
         Width           =   1935
      End
      Begin VB.TextBox TxtRemision 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   2160
         Locked          =   -1  'True
         TabIndex        =   14
         Top             =   960
         Width           =   5535
      End
      Begin VB.TextBox Text6 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         TabIndex        =   13
         Text            =   "Sucursal"
         Top             =   645
         Width           =   855
      End
      Begin VB.TextBox TxtSucursal 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   1080
         Locked          =   -1  'True
         TabIndex        =   12
         Top             =   645
         Width           =   7575
      End
      Begin VB.TextBox TxtCliente 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Left            =   3480
         Locked          =   -1  'True
         TabIndex        =   11
         Top             =   360
         Width           =   5175
      End
      Begin VB.TextBox TxtRFC 
         BorderStyle     =   0  'None
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   210
         Left            =   840
         Locked          =   -1  'True
         TabIndex        =   10
         Top             =   360
         Width           =   1575
      End
      Begin VB.TextBox Text5 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   120
         Locked          =   -1  'True
         TabIndex        =   9
         Text            =   "R.F.C."
         Top             =   360
         Width           =   615
      End
      Begin VB.TextBox Txt12 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   2640
         TabIndex        =   8
         Text            =   "Cliente"
         Top             =   360
         Width           =   735
      End
      Begin VB.CommandButton btnEnd 
         BackColor       =   &H00FFFFFF&
         Cancel          =   -1  'True
         Height          =   495
         Left            =   6000
         Picture         =   "AL_Facturar.frx":16B2
         Style           =   1  'Graphical
         TabIndex        =   3
         Top             =   2280
         Width           =   1815
      End
      Begin VB.CommandButton btnFinaliza 
         BackColor       =   &H00FFFFFF&
         Height          =   495
         Left            =   4080
         Picture         =   "AL_Facturar.frx":1DED
         Style           =   1  'Graphical
         TabIndex        =   2
         Top             =   2280
         Width           =   1815
      End
      Begin VB.TextBox TxtFolio 
         Alignment       =   1  'Right Justify
         Height          =   375
         Left            =   4080
         TabIndex        =   1
         Top             =   1680
         Width           =   1335
      End
      Begin VB.ComboBox CmbSeries 
         Height          =   360
         Left            =   240
         Style           =   2  'Dropdown List
         TabIndex        =   4
         Top             =   2280
         Visible         =   0   'False
         Width           =   2055
      End
      Begin VB.Label Label1 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         Caption         =   "Folio"
         Height          =   240
         Left            =   4200
         TabIndex        =   7
         Top             =   1320
         Width           =   420
      End
      Begin VB.Label Label6 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Serie"
         Height          =   255
         Left            =   240
         TabIndex        =   6
         Top             =   1320
         Width           =   1815
      End
   End
End
Attribute VB_Name = "AL_Facturar"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public IdTipoVenta, Serie, Folio, LstDSeries, Actividad As Integer, IdPedido

Private Sub btnEnd_Click()
On Error GoTo Err_Factura_VentaCancela:

    If Actividad = 1 Then
        If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then
            If Trim(TxtStatus.Text) = "" Then
                Unload Me
            Else
                If Mid(TxtStatus.Text, 1, 1) = "B" Then
                    Unload Me
                Else
                    If MsgBox("¿ Deseas Cancelar la Factura ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
                        If MsgBox("La Factura cambiará a un status de Cancelada. ¿ Deseas continuar ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
                            StrCmd = "execute up_Ventas " & IdCedis & ", " & IdSurtido & ", " & IdTipoVenta & ", " & Folio & ", '" & Serie & "', '" & FormatDate(Fecha) & "', 0, 0, 6"
                            If Rs.State Then Rs.Close
                            Rs.Open StrCmd, Cnn
                        
                            Select Case Actividad
                                Case 1: AL_Liquidacion.MuestraFacturas
                                Case 2: AL_Pedidos.MuestraPedidos
                            End Select
                            MsgBox "¡ Factura Cancelada con éxito !", vbInformation + vbOKOnly, App.Title
                        End If
                    End If
                End If
            End If
        End If
    End If

No_Err_Factura_VentaCancela:
    Unload Me
    Exit Sub
    
Err_Factura_VentaCancela:
    MousePointer = 0
    If Trim(MensajeCFD) = "" Then
        MsgBox "Error al Cancelar " & IIf(CFDCedis = "1", " el CFDI", "la Factura") & " : " & Err.Description, vbInformation + vbOKOnly, App.Title
    Else
        MsgBox MensajeCFD, vbInformation + vbOKOnly, App.Title
    End If
    GoTo No_Err_Factura_VentaCancela:

End Sub

Private Sub btnFinaliza_Click()
On Error GoTo Err_Factura_Venta:
    MensajeCFD = ""


    If CFDCedis = "1" Then
    
        If Facturada = "1" Then
            MsgBox "El CFDI " & Serie & Format(Folio, "000000") & " ya ha sido creado. " & Chr(13) & Chr(10) & "No puede modificarse, deberá cancelarlo y crear uno nuevo.", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If Facturada = "0" Then
            If MsgBox(IIf(Actividad = "1", "Esta Venta", "Este Pedido") & " tiene un CFDI dado de BAJA. " & Chr(13) & Chr(10) & "¿ Deseas ejecutar un NUEVO proceso de timbrado ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        End If
        
        If Facturada = "2" Then
            If MsgBox(IIf(Actividad = "1", "Esta Venta", "Este Pedido") & " no tiene un CFDI asignado. " & Chr(13) & Chr(10) & "¿ Deseas ejecutar el proceso de timbrado ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        End If
        
        If MsgBox("El proceso de creación del CFDI puede tardar algunos minutos. " & Chr(13) & Chr(10) & "¿ Deseas continuar con la creación del CFDI ?", vbQuestion + vbYesNo, App.Title) = vbNo Then GoTo No_Err_Factura_Venta:
        
        Dim utilWeb As UtileriaWeb
        Set utilWeb = New UtileriaWeb
        Dim mensajePing As String
        mensajePing = ""
        If Not utilWeb.VerificarServicioTimbrado(Cnn, Rs, mensajePing) Then
            MsgBox mensajePing
            Exit Sub
        End If
    
    MousePointer = 11
        Dim IdSurt, Act
        Select Case Actividad
            Case 1: IdSurt = IdSurtido: Act = "Venta"
            Case 2: IdSurt = IdPedido: Act = "Pedido"
            Case 3: IdSurt = 0: Act = "Factura PG"
        End Select
        
        If Facturada <> "1" Then
            StrCmd = "execute up_VentasFactura " & IdCedis & ", " & IdSurt & ", " & IdTipoVenta & ", " & Folio & ", '" & Serie & "', 0, '', " & Actividad & ", 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
        
            StrCmd = "execute sel_VentasFacturaCFD " & IdCedis & ", " & IdSurt & ", " & IdTipoVenta & ", '" & Serie & "', " & Folio & ", " & Actividad & ", 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            If Not Rs.EOF Then
                TxtFolio.Text = Rs.Fields(5): TransProdIDFactura = Rs.Fields(6)
            End If
            
'        Else
'            StrCmd = "execute sel_VentasFacturaCFD " & IdCedis & ", " & IdSurt & ", " & IdTipoVenta & ", '" & Serie & "', " & Folio & ", " & Actividad & ", 2"
'            If Rs.State Then Rs.Close
'            Rs.Open StrCmd, Cnn
'            If Not Rs.EOF Then
'                TxtFolio.Text = Rs.Fields(5): TransProdIDFactura = Rs.Fields(6): TransProdID = Rs.Fields(7)
'            End If
'
'            Select Case Actividad
'                Case 1: StrCmd = "execute Route.dbo.sp_importDatoFiscalADM " & IdCedis & ", " & IdSurt & ", " & IdTipoVenta & ", " & Folio & ", '" & Serie & "', '" & TransProdID & "', '" & TransProdIDFactura & "', '" & "CFDCed" & IdCedis & "', 0"
'                Case 2: StrCmd = "execute Route.dbo.sp_importDatoFiscalPedidosADM " & IdCedis & ", " & IdSurt & ", " & IdTipoVenta & ", " & Folio & ", '" & Serie & "', '" & TransProdID & "', '" & TransProdIDFactura & "', '" & "CFDCed" & IdCedis & "', 0"
'            End Select
'            If Rs.State Then Rs.Close
'            Rs.Open StrCmd, Cnn
        End If
        
        Set ClaseCFDADM = New LbCFDADM.LbCFDADM
        MensajeCFD = ClaseCFDADM.LlamarCFDADM(PathRouteDesktop, TransProdIDFactura, RutaXML, 1)
        If Trim(MensajeCFD) <> "" Then GoTo Err_Factura_Venta:
        
        StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", " & IdSurt & ", 0, 0, " & IdTipoVenta & ", '" & LstDSeries(0, LstPartidas.SelectedItem.Index - 1) & "', " & Trim(TxtFolio.Text) & ", '" & _
        FormatDate(Fecha) & "', " & IdRuta & ", 0, '', 0, 'Facturar', '" & IIf(Actividad = 1, " Liquidación " & IdSurt & ". " & Act & " " & Serie & " " & Folio, " Pedido " & IdSurt) & ". Factura " & LstDSeries(0, LstPartidas.SelectedItem.Index - 1) & " " & Trim(TxtFolio.Text) & "', 5"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
    Else
        
    MousePointer = 11
        
        TxtFolio_Validate False
        
        If Trim(TxtFolio.Text) = "0" Or Trim(TxtFolio.Text) = "" Then
            MousePointer = 0
            MsgBox "¡ Teclea un Folio de Factura !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        StrCmd = "execute up_VentasFactura " & IdCedis & ", " & IdSurtido & ", " & IdTipoVenta & ", " & Folio & ", '" & Serie & "', " & Trim(TxtFolio.Text) & ", '" & LstDSeries(0, LstPartidas.SelectedItem.Index - 1) & "', 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            If CLng(Rs.Fields(0)) <> CLng(Rs.Fields(1)) Then
                MousePointer = 0
                MsgBox "¡ Selecciona la Serie de Facturación que corresponde a los Productos registrados en la Venta !", vbInformation + vbOKOnly, App.Title
                Exit Sub
            End If
        Else
            MousePointer = 0
            MsgBox "¡ Selecciona la Serie de Facturación que corresponde a los Productos registrados en la Venta !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
        
        If LstDSeries(3, LstPartidas.SelectedItem.Index - 1) = 1 Then
            If Not ValidaDatosCFD(IdCedis, IdSurtido, IdTipoVenta, Folio, 1) Then
                MousePointer = 0
                Exit Sub
            End If
            If Not ValidaDatosCFD(IdCedis, IdSurtido, IdTipoVenta, Folio, 2) Then
                MousePointer = 0
                Exit Sub
            End If
        End If
        
        StrCmd = "execute up_VentasFactura " & IdCedis & ", " & IdSurtido & ", " & IdTipoVenta & ", " & Folio & ", '" & Serie & "', " & Trim(TxtFolio.Text) & ", '" & LstDSeries(0, LstPartidas.SelectedItem.Index - 1) & "', 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Rs.Fields.Count > 0 Then
            If Not Rs.EOF Then
                MsgBox "¡ Se asignó el Folio " & Format(Rs.Fields(0), "00000") & " !", vbInformation + vbOKOnly, App.Title
                TxtFolio.Text = Rs.Fields(0)
            End If
        End If
'        If LstDSeries(3, LstPartidas.SelectedItem.Index - 1) = 1 Then
'            If Not ValidaDatosCFD(IdCedis, IdSurtido, IdTipoVenta, Trim(TxtFolio.Text), 3) Then Exit Sub
'            If Trim(GenerarCadenaOriginal(CStr(Format(Fecha, "yyyy-mm-dd""T""hh:mm:ss")), IdCedis, IdSurtido, IdTipoVenta, Trim(TxtFolio.Text), LstDSeries(0, LstPartidas.SelectedItem.Index - 1))) = "" Then
'                MousePointer = 0
'                MsgBox "¡ Error al Crear la Cadena Original !", vbInformation + vbOKOnly, App.Title
'                Exit Sub
'            End If
'            If Trim(GenerarSelloDigital(Trim(TxtFolio.Text), LstDSeries(0, LstPartidas.SelectedItem.Index - 1))) = "" Then
'                MousePointer = 0
'                MsgBox "¡ Error al Crear el Sello Digital !", vbInformation + vbOKOnly, App.Title
'                Exit Sub
'            End If
'            If Not CrearXML(CStr(Format(Fecha, "yyyy-mm-dd""T""hh:mm:ss")), CStr(ElSello), Trim(TxtFolio.Text), LstDSeries(0, LstPartidas.SelectedItem.Index - 1), IdTipoVenta) Then
'                MousePointer = 0
'                MsgBox "¡ Error al Crear el XML !", vbInformation + vbOKOnly, App.Title
'                Exit Sub
'            End If
'        End If
        
        StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", " & IdSurtido & ", 0, 0, " & IdTipoVenta & ", '" & LstDSeries(0, LstPartidas.SelectedItem.Index - 1) & "', " & Trim(TxtFolio.Text) & ", '" & _
        FormatDate(Fecha) & "', " & IdRuta & ", 0, '', 0, 'Facturar', 'Liquidación " & IdSurtido & ". Remisión " & Serie & " " & Folio & ". Factura " & LstDSeries(0, LstPartidas.SelectedItem.Index - 1) & " " & Trim(TxtFolio.Text) & "', 5"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
    End If
    
    MousePointer = 0
    MsgBox "¡ " & IIf(CFDCedis = "1", "CFDI creado", "Factura creada") & " con éxito !", vbInformation + vbOKOnly, App.Title
    
No_Err_Factura_Venta:
    Select Case Actividad
        Case 1: AL_Liquidacion.MuestraFacturas
        Case 2: AL_Pedidos.MuestraPedidos
    End Select
    Unload Me
    Exit Sub
    
Err_Factura_Venta:
    MousePointer = 0
    If Trim(MensajeCFD) = "" Then
        MsgBox "Error al crear " & IIf(CFDCedis = "1", " el CFDI", "la Factura") & " : " & Err.Description, vbInformation + vbOKOnly, App.Title
    Else
        MsgBox MensajeCFD, vbInformation + vbOKOnly, App.Title
    End If
    GoTo No_Err_Factura_Venta:

End Sub

Private Sub CmbSeries_Click()
On Error Resume Next
    
    StrCmd = "execute sel_Folios " & IdCedis & ", " & IIf(IdTipoVenta = "", 0, IdTipoVenta) & ", 0, 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    If Not Rs.EOF Then
        TxtFolio.Text = Rs.Fields(1)
    Else
        TxtFolio.Text = "0"
    End If
    
End Sub

Private Sub Form_Activate()
On Error Resume Next
    If CFDCedis = "1" Then
        AccionCFDCedis
    Else
        TxtFolio.Locked = False
        LlenaSeries
        LstPartidas_ItemClick LstPartidas.SelectedItem
        TxtFolio.SetFocus
    End If
End Sub

Sub LlenaSeries()
On Error Resume Next

    StrCmd = "execute sel_Series " & IdCedis & ", " & IdRuta & ", '', '', 0, '19000101', 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDSeries = GetDataLVL(Rs, LstPartidas, 1, 2, "0|0")
    TxtFolio.Locked = IIf(LstDSeries(3, LstPartidas.SelectedItem.Index - 1) = 1, True, False)

End Sub

Private Sub LstPartidas_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    If CFDCedis <> "1" Then
        StrCmd = "execute sel_Series " & IdCedis & ", " & IdRuta & ", '" & LstDSeries(3, LstPartidas.SelectedItem.Index - 1) & "', '" & LstDSeries(0, LstPartidas.SelectedItem.Index - 1) & "', 0, '19000101', 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            TxtFolio.Text = Rs.Fields(1)
        End If
    End If
End Sub

Private Sub TxtFolio_GotFocus()
On Error Resume Next
    SelText TxtFolio
End Sub

Private Sub TxtFolio_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtFolio_Validate(Cancel As Boolean)
On Error Resume Next

'    StrCmd = "execute sel_Folios " & IdCedis & ", " & IdTipoVenta & ", " & TxtFolio.Text & ", 7"
'    If Rs.State Then Rs.Close
'    Rs.Open StrCmd, Cnn
'    If Not Rs.EOF Then
'        If Rs.Fields(0) > CLng(TxtFolio.Text) Then
'            MsgBox "¡ El Folio de Factura debe ser mayor al Folio Inicial " & Rs.Fields(0) & " !", vbInformation + vbOKOnly, App.Title
'            TxtFolio.Text = ""
'            TxtFolio.SetFocus
'            Exit Sub
'        Else
'            If Rs.Fields(1) <> 0 Then
'                MsgBox "¡ El Folio " & TxtFolio.Text & " ya existe !. Teclee otro Folio.", vbInformation + vbOKOnly, App.Title
'                TxtFolio.Text = ""
'                TxtFolio.SetFocus
'                Exit Sub
'            End If
'        End If
'    Else
'        MsgBox "¡ Teclea un Folio de Factura Válido !", vbInformation + vbOKOnly, App.Title
'        TxtFolio.Text = ""
'        TxtFolio.SetFocus
'    End If

    StrCmd = "execute sel_Series " & IdCedis & ", " & IdRuta & ", '" & LstDSeries(3, LstPartidas.SelectedItem.Index - 1) & "', '" & LstDSeries(0, LstPartidas.SelectedItem.Index - 1) & "', " & TxtFolio.Text & ", '19000101', 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        If Rs.Fields(3) = "S" Then
            If Rs.Fields(2) <= Rs.Fields(1) Then
                MsgBox "¡ Teclea un Folio de Factura Válido !", vbInformation + vbOKOnly, App.Title
                TxtFolio.Text = ""
                TxtFolio.SetFocus
            End If
        Else
            If Rs.Fields(4) <> 0 Then
                MsgBox "¡ El Folio de Factura: " & TxtFolio.Text & " ya se ha Registrado Previamente !", vbInformation + vbOKOnly, App.Title
                TxtFolio.Text = ""
                TxtFolio.SetFocus
            End If
        End If
    End If

End Sub

Sub AccionCFDCedis()
On Error Resume Next
    
    If IsEmpty(IdRuta) Then IdRuta = 0
        
    TxtFolio.Locked = True
    
    Dim IdSurt, Act
    Select Case Actividad
        Case 1: IdSurt = IdSurtido: Act = "Venta"
        Case 2: IdSurt = IdPedido: Act = "Pedido"
        Case 3: IdSurt = 0: Act = "Factura PG"
    End Select
    
    StrCmd = "execute sel_VentasFacturaCFD " & IdCedis & ", " & IdSurt & ", " & IdTipoVenta & ", '" & Serie & "', " & Folio & ", " & Actividad & ", " & IIf(Actividad = "1", 2, 1)
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    Facturada = ""
    If Not RsC.EOF Then
        Facturada = RsC.Fields(9)
        If IsNull(Facturada) Then
            Facturada = ""
            TxtStatus.Text = ""
        Else
            If Facturada = "0" Then
                TxtStatus.Text = "B. Baja"
            Else
                If Facturada <> "0" And Not IsNull(RsC.Fields(8)) Then
                    Facturada = "1"
                    TxtStatus.Text = "E. Emitida"
                Else
                    Facturada = "2"
                    TxtStatus.Text = "P. Pendiente"
                End If
            End If
        End If
        If Not IsNull(RsC.Fields(8)) Then
            If Trim(RsC.Fields(6)) <> "" Then Facturada = "1"
        End If
    Else
        Facturada = ""
        TxtStatus.Text = ""
    End If
    
    StrCmd = "execute sel_SeriesCFD " & IdCedis & ", " & IdRuta & ", 1, 1, 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        TxtFolio.Text = IIf(Facturada = "", Rs.Fields(4), Folio)
        LstDSeries = GetDataLVL(Rs, LstPartidas, 1, 2, "0|0")
    End If
    
'    StrCmd = "execute sel_SeriesCFD " & IdCedis & ", " & IdRuta & ", 1, 1, 2"
'    If Rs.State Then Rs.Close
'    Rs.Open StrCmd, Cnn
'    If Not Rs.EOF Then
'        If Folio <= Rs.Fields(4) And Folio > 0 And Serie = Rs.Fields(0) Then
'            Facturada = True
'            TxtFolio.Text = Folio
'            LstDSeries = GetDataLVL(Rs, LstPartidas, 1, 2, "0|0")
'        Else
'            StrCmd = "execute sel_SeriesCFD " & IdCedis & ", " & IdRuta & ", 1, 1, 1"
'            If Rs.State Then Rs.Close
'            Rs.Open StrCmd, Cnn
'            If Not Rs.EOF Then
'                TxtFolio.Text = Rs.Fields(4)
'                LstDSeries = GetDataLVL(Rs, LstPartidas, 1, 2, "0|0")
'            End If
'            Facturada = False
'        End If
'    End If
    btnFinaliza.SetFocus
End Sub

