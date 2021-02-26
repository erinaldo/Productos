VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CSG_ConsignasInicial 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Resumen de Liquidación"
   ClientHeight    =   6915
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   12000
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
   ScaleHeight     =   6915
   ScaleWidth      =   12000
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton btnImprimir 
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
      Height          =   495
      Left            =   5760
      Picture         =   "CSG_ConsignasInicial.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   12
      Top             =   6300
      Width           =   1695
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
      Left            =   7560
      Picture         =   "CSG_ConsignasInicial.frx":071B
      Style           =   1  'Graphical
      TabIndex        =   10
      Top             =   6300
      Visible         =   0   'False
      Width           =   1695
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
      Picture         =   "CSG_ConsignasInicial.frx":0E56
      Style           =   1  'Graphical
      TabIndex        =   8
      Top             =   6300
      Width           =   1695
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
      Left            =   2040
      Picture         =   "CSG_ConsignasInicial.frx":14E4
      Style           =   1  'Graphical
      TabIndex        =   9
      Top             =   6300
      Width           =   1695
   End
   Begin VB.Frame Frame2 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Datos de la Liquidación"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   735
      Left            =   90
      TabIndex        =   18
      Top             =   120
      Width           =   11775
      Begin VB.TextBox TxtLiquidacion 
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
         Left            =   1770
         Locked          =   -1  'True
         TabIndex        =   13
         Top             =   300
         Width           =   1335
      End
      Begin VB.TextBox TxtRuta 
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
         Left            =   4050
         Locked          =   -1  'True
         TabIndex        =   14
         Top             =   300
         Width           =   615
      End
      Begin VB.TextBox TxtFecha 
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
         Left            =   5820
         Locked          =   -1  'True
         TabIndex        =   15
         Top             =   300
         Width           =   4725
      End
      Begin VB.TextBox Text2 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   225
         Locked          =   -1  'True
         TabIndex        =   21
         Text            =   "No. Liquidación"
         Top             =   300
         Width           =   1400
      End
      Begin VB.TextBox Text3 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   3390
         TabIndex        =   20
         Text            =   "Ruta"
         Top             =   300
         Width           =   555
      End
      Begin VB.TextBox Text4 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   4980
         Locked          =   -1  'True
         TabIndex        =   19
         Text            =   "Fecha"
         Top             =   300
         Width           =   555
      End
   End
   Begin VB.CommandButton btnSalir 
      BackColor       =   &H00FFFFFF&
      Cancel          =   -1  'True
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
      Left            =   5820
      Picture         =   "CSG_ConsignasInicial.frx":1BCE
      Style           =   1  'Graphical
      TabIndex        =   16
      Top             =   7320
      Width           =   1455
   End
   Begin VB.Frame FrmOpt 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Consignas"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   5235
      Index           =   2
      Left            =   90
      TabIndex        =   17
      Top             =   960
      Width           =   11775
      Begin VB.OptionButton OptStatus 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Canceladas"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   405
         Index           =   6
         Left            =   10350
         TabIndex        =   6
         Top             =   300
         Width           =   1275
      End
      Begin VB.OptionButton OptStatus 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Finalizadas"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   405
         Index           =   5
         Left            =   9000
         TabIndex        =   5
         Top             =   300
         Width           =   1245
      End
      Begin VB.OptionButton OptStatus 
         BackColor       =   &H00FFFFFF&
         Caption         =   "En Proceso de Devolución"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   405
         Index           =   4
         Left            =   6420
         TabIndex        =   4
         Top             =   300
         Width           =   2535
      End
      Begin VB.OptionButton OptStatus 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Por Devolver"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   405
         Index           =   3
         Left            =   4920
         TabIndex        =   3
         Top             =   300
         Width           =   1395
      End
      Begin VB.OptionButton OptStatus 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Registradas"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   405
         Index           =   2
         Left            =   3480
         TabIndex        =   2
         Top             =   300
         Width           =   1365
      End
      Begin VB.OptionButton OptStatus 
         BackColor       =   &H00FFFFFF&
         Caption         =   "En Proceso de Registro"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   405
         Index           =   1
         Left            =   1080
         TabIndex        =   1
         Top             =   300
         Width           =   2265
      End
      Begin VB.OptionButton OptStatus 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Todas"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   405
         Index           =   0
         Left            =   120
         TabIndex        =   0
         Top             =   300
         Width           =   885
      End
      Begin MSComctlLib.ListView LstVConsignas 
         Height          =   4350
         Left            =   120
         TabIndex        =   7
         Top             =   810
         Width           =   11535
         _ExtentX        =   20346
         _ExtentY        =   7673
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
   End
   Begin VB.CommandButton btnNuevaDev 
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
      Left            =   3840
      Picture         =   "CSG_ConsignasInicial.frx":2125
      Style           =   1  'Graphical
      TabIndex        =   11
      Top             =   6300
      Width           =   1815
   End
End
Attribute VB_Name = "CSG_ConsignasInicial"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDConsignas
Dim Accion As String
Dim EstatusConsigna As String
Public IdConsigna As Long
Public CancelaDevolverConsigna As Boolean

Dim CadenaStatus As String

Const ctConsignasStatus = "ConsignasPorStatus"
Const ctConsignasPorDevolver = "ConsignasPorDevolver"

Sub PreparaDatos(TipoLista As String)
    
    On Error GoTo ErrConexion2
    
    If Rs.State Then Rs.Close
    
    Select Case TipoLista
        
        Case ctConsignasPorDevolver
            StrCmd = "execute sel_Consignas " & IdCedis & ",0,0,'',3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            
            LstDConsignas = GetDataLVL(Rs, LstVConsignas, 0, 4, "1|0|0|0|0")
            
            If Not IsEmpty(LstDConsignas) Then LstVConsignas_ItemClick LstVConsignas.SelectedItem
    
        Case ctConsignasStatus
        
            StrCmd = "execute sel_Consignas " & IdCedis & ",0," & IdSurtido & "," & CadenaStatus & ",4"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            
            LstDConsignas = GetDataLVL(Rs, LstVConsignas, 0, 4, "1|0|0|0|0")
            
            If Not IsEmpty(LstDConsignas) Then LstVConsignas_ItemClick LstVConsignas.SelectedItem
                    
    End Select

    Exit Sub
ErrConexion2:
    MsgBox "Error al Consultar Información. " & Chr(13) & Chr(10) & Err.Description, vbExclamation, "Error del Módulo...."
    
    MousePointer = 0
    Exit Sub
End Sub


Private Sub btnActualizar_Click()
    If IsEmpty(LstDConsignas) Then Exit Sub

    Accion = "E"        'asignar segun la accion que se requiera realizar
    '"N" es nueva consigna
    '"E" es para abrir una consigna que ya esta ligada a una ruta y surtido
    '"D" para registrar una devolucion de consigna

    With CSG_Consignas
        .ControlFormas = True
        .IdRutaConsigna = IdRuta
        .IdSurtidoConsigna = IdSurtido
        .TxtDatos(0).Text = IdConsigna
        .Accion = Accion
        .Left = AL_Liquidacion.Left + (AL_Liquidacion.Width - .Width) / 2
        .Top = AL_Liquidacion.Top + (AL_Liquidacion.Height - .Height) / 2
        .Show
        .ZOrder 0
    End With
End Sub

Private Sub btnEliminar_Click()
    Dim IdRutaEntrega As Long, IdSurtidoEntrega As Long
    Dim IdRutaDevolucion As Long, IdSurtidoDevolucion As Long
    Dim FechaEntrega As Date, FechaDevolucion As Date
    Dim StatusConsigna As String, DescripcionStatus As String
    Dim Folio As Long, Serie As String

    Dim EstadoCancelacion As String
    
    If Not ValidaDiaySurtido(IdCedis, 0, Fecha) Then Exit Sub
    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    
    If IsEmpty(LstDConsignas) Then Exit Sub
    
    'valida la existencia de la consigna para traer los datos a pantalla, es logico que la consinga debe existitir para esta ruta y surtido
    StrCmd = "execute sel_Consignas " & IdCedis & "," & IdConsigna & ",0,'',1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    If Rs.EOF Then
        MsgBox "No se encontró la consigna con el número de folio seleccionado.", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    IdRutaEntrega = Rs.Fields("IdRutaEntrega").Value
    IdSurtidoEntrega = Rs.Fields("IdSurtidoEntrega").Value
    IdRutaDevolucion = Rs.Fields("IdRutaDevolucion").Value
    IdSurtidoDevolucion = Rs.Fields("IdSurtidoDevolucion").Value
    FechaEntrega = Rs.Fields("FechaEntrega").Value
    FechaDevolucion = Rs.Fields("FechaDevolucion").Value
    StatusConsigna = Rs.Fields("StatusConsigna").Value
    DescripcionStatus = Rs.Fields("DescripcionStatus").Value
    Folio = Rs.Fields("Folio").Value
    Serie = Rs.Fields("Serie").Value
        
    'Evalua el estado de la consigna
    Select Case StatusConsigna
        Case "P", "R"       'caso de consigna en estado:  "En Proceso de Registro" o "Registrada"
            
            'Mensaje para confirmar la cancelacion total de la consigna
        
            If MsgBox("Se cancelará el registro completo de la consigna " & IdConsigna & ", de la ruta " & IdRuta & " y surtido " & IdSurtido & ", ¿ Desea continuar ?", vbQuestion + vbYesNo + vbDefaultButton2, App.Title) = vbNo Then Exit Sub
            
            EstadoCancelacion = "C"
            
        Case "D"       'caso de consigna en estado: "En consigna, Pendiente por Devolver" o "Devolucion y Ventas Registradas"
            
            'Mensaje para confirmar la cancelaciòn de la consigna, no se cancela totalmente
            'solo se quita de la ruta y surtido de devoluciòn
            
            If MsgBox("Se cancelará la devolución de la consigna " & IdConsigna & ", de la ruta " & IdRuta & " y surtido " & IdSurtido & ", ¿ Desea continuar ?", vbQuestion + vbYesNo + vbDefaultButton2, App.Title) = vbNo Then Exit Sub
        
            EstadoCancelacion = "S"
            
        Case "E", "V"
        
            MsgBox "No se puede cancelar la consigna " & IdConsigna & ", de la ruta " & IdRuta & " y surtido " & IdSurtido & ".", vbInformation + vbOKOnly, App.Title
            Exit Sub
            
    End Select
    
    'se realiza la cancelacion de la consigna segun la accion evaluada
    StrCmd = "execute up_Consignas " & IdCedis & ", " & IdConsigna & ",0,''," & _
                                    IdRutaEntrega & "," & IdSurtidoEntrega & ",'" & FechaEntrega & "',0," & _
                                    IdRutaDevolucion & "," & IdSurtidoDevolucion & ",'" & FechaDevolucion & "',0," & _
                                    Folio & ",'" & Serie & "','','" & EstadoCancelacion & "',3"
        
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
                            
    MsgBox "La cancelación de la consigna se realizó correctamente.", vbInformation + vbOKOnly, App.Title

    PreparaDatos ctConsignasStatus
    'MuestraConsignas

End Sub

Private Sub btnImprimir_Click()

    With AL_RptCargaConsigna
        .ImgLogo.Picture = LoadPicture(App.Path & "\LogoEmpresa.jpg")
        .LblCedis.Caption = IdCedis & " - " & NomCedis
        
        StrCmd = "execute sel_Consignas " & IdCedis & "," & IdConsigna & ",0,'',1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        If Not Rs.EOF Then
            .object.DataSrc.DataSourceName = Cnn
            .object.DataSrc.Recordset = Rs
        End If
        
        .Printer.Orientation = ddOPortrait
        .Printer.PaperSize = 1
        .Show 1
    End With

End Sub

Private Sub btnNuevaDev_Click()
    
'''    CancelaDevolverConsigna = True
'''    CSG_BusquedaConsigna.Show vbModal
'''    If CancelaDevolverConsigna = True Then Exit Sub

    

    'si ya pasó este paso, se lleva a cabo la devolución
    If Not ValidaDiaySurtido(IdCedis, 0, Fecha) Then Exit Sub
    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    
    Accion = "D"        'asignar segun la accion que se requiera realizar
    '"N" es nueva consigna
    '"E" es para abrir una consigna que ya esta ligada a una ruta y surtido
    '"D" para registrar una devolucion de consigna

    With CSG_Consignas
        .ControlFormas = True
        .IdRutaConsigna = IdRuta
        .IdSurtidoConsigna = IdSurtido
        .TxtDatos(0).Text = IdConsigna
        .Accion = Accion
        .Left = AL_Liquidacion.Left + (AL_Liquidacion.Width - .Width) / 2
        .Top = AL_Liquidacion.Top + (AL_Liquidacion.Height - .Height) / 2
        .Show
        .ZOrder 0
    End With

End Sub

Private Sub btnNuevo_Click()
    
    If Not ValidaDiaySurtido(IdCedis, 0, Fecha) Then Exit Sub
    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    
    Accion = "N"        'asignar segun la accion que se requiera realizar
    IdConsigna = 0      'Temporal, sustituir por el Id de la consigna que se va a abrir
    '"N" es nueva consigna
    '"E" es para abrir una consigna que ya esta ligada a una ruta y surtido
    '"D" para registrar una devolucion de consigna

    With CSG_Consignas
        .ControlFormas = True
        .IdRutaConsigna = IdRuta
        .IdSurtidoConsigna = IdSurtido
        .TxtDatos(0).Text = IdConsigna
        .Accion = Accion
        .Left = AL_Liquidacion.Left + (AL_Liquidacion.Width - .Width) / 2
        .Top = AL_Liquidacion.Top + (AL_Liquidacion.Height - .Height) / 2
        .Show
        .ZOrder 0
    End With
End Sub

Private Sub btnSalir_Click()
'On error Resume Next
    Unload Me
End Sub

Private Sub Form_Load()
On Error Resume Next

    TxtLiquidacion.Text = IdSurtido
    TxtRuta.Text = IdRuta
    TxtFecha = Format(Fecha, ctFechaLarga)
    
    OptStatus(0).Value = True

    'MuestraConsignas
End Sub

Public Sub MuestraConsignas()
'On error Resume Next
End Sub

Private Sub LstVConsignas_Click()
    On Error Resume Next

    Dim ItemSeleccionado

    'btnNuevo.Enabled = False
    btnActualizar.Enabled = False
    btnEliminar.Enabled = False
    btnNuevaDev.Enabled = False
    btnImprimir.Enabled = False

    If LstVConsignas.ListItems.Count > 0 Then
        If Not IsEmpty(LstDConsignas) Then
            
            ItemSeleccionado = LstVConsignas.SelectedItem.Index
            
            IdConsigna = Trim(LstVConsignas.SelectedItem)
            EstatusConsigna = LstDConsignas(12, ItemSeleccionado - 1)
            
            Select Case EstatusConsigna
                
                Case "P", "R"       'caso de Consigna en Proceso de registro y Consigna Registrada
                    btnActualizar.Enabled = True
                    btnEliminar.Enabled = True
                    btnImprimir.Enabled = True
                
                Case "E"        'caso de Consigna Pendiente por Devolver
                    btnNuevaDev.Enabled = True
                    btnImprimir.Enabled = True
                
                Case "D"        'caso de Consigna en Proceso de Devolucion
                    btnActualizar.Enabled = True
                    btnEliminar.Enabled = True
                    btnImprimir.Enabled = True
                    
                Case "V", "C"       'caso de Consigna Finalizada y consigna cancelada
                    btnImprimir.Enabled = True
                    
            End Select
            
        End If
    End If
End Sub

Private Sub LstVConsignas_DblClick()
On Error Resume Next
    If IsEmpty(LstDConsignas) Then Exit Sub
    btnActualizar_Click
End Sub

Private Sub LstVConsignas_ItemClick(ByVal Item As MSComctlLib.ListItem)
    LstVConsignas_Click
End Sub

Private Sub OptStatus_Click(Index As Integer)

    Select Case Index
        Case 0      'caso de Todas las consignas
            CadenaStatus = "'''P'',''R'',''E'',''D'',''V'',''C'''"
            
        Case 1      'caso de las consignas en Proceso de registro
            CadenaStatus = "'''P'''"
            
        Case 2      'caso de las consignas registradas
            CadenaStatus = "'''R'''"
        
        Case 3      'caso de las consignas pendientes de devolucion
            CadenaStatus = "'''E'''"
        
        Case 4      'caso de las consignas en Proceso de Devolución
            CadenaStatus = "'''D'''"
        
        Case 5      'caso de las consignas canceladas
            CadenaStatus = "'''V'''"
        
        Case 6      'caso de las consignas canceladas
            CadenaStatus = "'''C'''"
        
    End Select

    Select Case Index
        Case 0, 1, 2, 4, 5, 6
            PreparaDatos ctConsignasStatus
        
        Case 3      'caso de las consignas pendientes de devolucion
            PreparaDatos ctConsignasPorDevolver
        
    End Select



End Sub
