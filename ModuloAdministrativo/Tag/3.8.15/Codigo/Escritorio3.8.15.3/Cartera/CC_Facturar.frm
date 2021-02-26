VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_Facturar 
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
   Icon            =   "CC_Facturar.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
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
         Picture         =   "CC_Facturar.frx":16B2
         Style           =   1  'Graphical
         TabIndex        =   3
         Top             =   2280
         Width           =   1815
      End
      Begin VB.CommandButton btnFinaliza 
         BackColor       =   &H00FFFFFF&
         Height          =   495
         Left            =   4080
         Picture         =   "CC_Facturar.frx":1DED
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
Attribute VB_Name = "CC_Facturar"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public IdCedis, IdTipoVenta, Serie, Folio, LstDSeries, Actividad As Integer, IdPedido

Private Sub btnEnd_Click()
    Unload Me
End Sub

Private Sub btnFinaliza_Click()
On Error GoTo Err_Factura_Venta:
    MensajeCFD = ""

    If Facturada = "1" Then
        MsgBox "El CFDI " & Serie & Format(Folio, "000000") & " ya ha sido creado. " & Chr(13) & Chr(10) & "No puede modificarse, deberá cancelarlo y crear uno nuevo.", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    If Facturada = "0" Then
        If MsgBox("Esta Venta tiene un CFDI dado de BAJA. " & Chr(13) & Chr(10) & "¿ Deseas ejecutar un NUEVO proceso de timbrado ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    End If
    
    If Facturada = "2" Then
        If MsgBox("Esta Venta no tiene un CFDI asignado. " & Chr(13) & Chr(10) & "¿ Deseas ejecutar el proceso de timbrado ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
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
        Select Case Actividad
            Case 1: Act = "Saldo"
        End Select
        
        If Facturada <> "1" Then
            StrCmd = "execute up_VentasFactura " & IdCedis & ", " & IdTipoVenta & ", " & Folio & ", '" & Serie & "', 0, '', " & Actividad & ", 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
        
            StrCmd = "execute sel_VentasFacturaCFD " & IdCedis & ", 0, " & IdTipoVenta & ", '" & Serie & "', " & Folio & ", " & Actividad & ", 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            If Not Rs.EOF Then
                TxtFolio.Text = Rs.Fields(5): TransProdIDFactura = Rs.Fields(6)
            End If

            StrCmd = "execute up_VentasFactura " & IdCedis & ", " & IdTipoVenta & ", " & Folio & ", '" & Serie & "', 0, '', " & Actividad & ", 5"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
'        Else
'            StrCmd = "execute sel_VentasFacturaCFD " & IdCedis & ", 0, " & IdTipoVenta & ", '" & Serie & "', " & Folio & ", " & Actividad & ", 2"
'            If Rs.State Then Rs.Close
'            Rs.Open StrCmd, Cnn
'            If Not Rs.EOF Then
'                TxtFolio.Text = Rs.Fields(5): TransProdIDFactura = Rs.Fields(6): TransProdID = Rs.Fields(7)
'            End If
'
'            Select Case Actividad
'                Case 1: StrCmd = "execute Route.dbo.sp_importDatoFiscalCPC " & IdCedis & ", " & IdTipoVenta & ", " & Folio & ", '" & Serie & "', '" & TransProdID & "', '" & TransProdIDFactura & "', 'CFDCed1', 0"
'            End Select
'            If Rs.State Then Rs.Close
'            Rs.Open StrCmd, Cnn
        End If
        
        Set ClaseCFDADM = New LbCFDADM.LbCFDADM
        MensajeCFD = ClaseCFDADM.LlamarCFDADM(PathRouteDesktop, TransProdIDFactura, RutaXML, 1)
        If Trim(MensajeCFD) <> "" Then GoTo Err_Factura_Venta:
        
    MousePointer = 0
    MsgBox "¡ " & IIf(CFDCedis = "1", "CFDI creado", "Factura creada") & " con éxito !", vbInformation + vbOKOnly, App.Title

No_Err_Factura_Venta:
    Select Case Actividad
        Case 1: CC_Cat_CxC.MuestraVentas
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

Private Sub Form_Activate()
On Error Resume Next
    If CFDCedis = "1" Then
        AccionCFDCedis
    End If
End Sub

Private Sub TxtFolio_GotFocus()
On Error Resume Next
    SelText TxtFolio
End Sub

Sub AccionCFDCedis()
On Error Resume Next
    TxtFolio.Locked = True
    
    StrCmd = "execute sel_VentasFacturaCFD " & IdCedis & ", 0, " & IdTipoVenta & ", '" & Serie & "', " & Folio & ", 1, 2"
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
    
    StrCmd = "execute RouteADM.dbo.sel_SeriesCFD 1, 0, 1, 1, 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        TxtFolio.Text = IIf(Facturada = "", Rs.Fields(4), Folio)
        LstDSeries = GetDataLVL(Rs, LstPartidas, 1, 2, "0|0")
    End If
    
    btnFinaliza.SetFocus
End Sub
