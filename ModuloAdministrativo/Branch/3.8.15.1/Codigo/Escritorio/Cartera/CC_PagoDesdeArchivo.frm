VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form CC_PagoDesdeArchivo 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Pago Desde Archivo"
   ClientHeight    =   7920
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   12585
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   7920
   ScaleWidth      =   12585
   ShowInTaskbar   =   0   'False
   Begin VB.Frame FrmOpt 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Detalles del Movimiento"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   7695
      Index           =   2
      Left            =   120
      TabIndex        =   15
      Top             =   120
      Width           =   12375
      Begin VB.TextBox TxtArchivo 
         Height          =   375
         Left            =   1920
         MaxLength       =   20
         TabIndex        =   0
         Text            =   "Pagos"
         Top             =   360
         Width           =   2175
      End
      Begin VB.CommandButton btnDelete 
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
         Left            =   6120
         Picture         =   "CC_PagoDesdeArchivo.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   3
         Top             =   240
         Visible         =   0   'False
         Width           =   495
      End
      Begin VB.CommandButton btnArchivo 
         BackColor       =   &H00FFFFFF&
         Height          =   495
         Left            =   4080
         Picture         =   "CC_PagoDesdeArchivo.frx":0425
         Style           =   1  'Graphical
         TabIndex        =   1
         Top             =   240
         Width           =   1935
      End
      Begin VB.TextBox TxtTipoDocumento 
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
         Left            =   6720
         Locked          =   -1  'True
         TabIndex        =   28
         Text            =   "Tipo de Pago"
         Top             =   360
         Visible         =   0   'False
         Width           =   5295
      End
      Begin VB.Frame Frame2 
         BackColor       =   &H00FFFFFF&
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   4215
         Left            =   120
         TabIndex        =   26
         Top             =   720
         Width           =   12135
         Begin MSComctlLib.ListView LstPartidas 
            Height          =   3855
            Left            =   120
            TabIndex        =   27
            Top             =   240
            Width           =   11895
            _ExtentX        =   20981
            _ExtentY        =   6800
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
      Begin VB.TextBox TxtNoCargados 
         Height          =   1935
         Left            =   120
         Locked          =   -1  'True
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   2
         Top             =   5520
         Width           =   8775
      End
      Begin VB.TextBox TxtResultado 
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
         Height          =   495
         Left            =   360
         Locked          =   -1  'True
         TabIndex        =   18
         Text            =   "Resultado de la Aplicación"
         Top             =   5040
         Width           =   8295
      End
      Begin VB.TextBox TxtCliente 
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
         Left            =   360
         Locked          =   -1  'True
         TabIndex        =   17
         Text            =   "Pagos Cargados correctamente"
         Top             =   840
         Width           =   3135
      End
      Begin VB.Frame Frame1 
         BackColor       =   &H00FFFFFF&
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   1455
         Left            =   9120
         TabIndex        =   19
         Top             =   4800
         Width           =   3135
         Begin VB.Label LblTotal 
            Alignment       =   1  'Right Justify
            Appearance      =   0  'Flat
            BackColor       =   &H80000005&
            BorderStyle     =   1  'Fixed Single
            Caption         =   "$ 0.00"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H80000008&
            Height          =   345
            Left            =   1215
            TabIndex        =   25
            Top             =   960
            Width           =   1635
         End
         Begin VB.Label LblIva 
            Alignment       =   1  'Right Justify
            Appearance      =   0  'Flat
            BackColor       =   &H80000005&
            BorderStyle     =   1  'Fixed Single
            Caption         =   "$ 0.00"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H80000008&
            Height          =   345
            Left            =   1215
            TabIndex        =   24
            Top             =   600
            Width           =   1635
         End
         Begin VB.Label LblSubtotal 
            Alignment       =   1  'Right Justify
            Appearance      =   0  'Flat
            BackColor       =   &H80000005&
            BorderStyle     =   1  'Fixed Single
            Caption         =   "$ 0.00"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H80000008&
            Height          =   345
            Left            =   1215
            TabIndex        =   23
            Top             =   240
            Width           =   1635
         End
         Begin VB.Label Label2 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Total:"
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
            Left            =   540
            TabIndex        =   22
            Top             =   960
            Width           =   450
         End
         Begin VB.Label Label4 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Iva:"
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
            Left            =   675
            TabIndex        =   21
            Top             =   600
            Width           =   270
         End
         Begin VB.Label Label6 
            Alignment       =   1  'Right Justify
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Subtotal:"
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
            Left            =   255
            TabIndex        =   20
            Top             =   240
            Width           =   720
         End
      End
      Begin VB.Label Label13 
         BackColor       =   &H00FFFFFF&
         Caption         =   "Nombre del Archivo"
         Height          =   255
         Left            =   360
         TabIndex        =   16
         Top             =   360
         Width           =   1455
      End
   End
   Begin VB.Frame Frame3 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Datos del Movimiento"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1215
      Left            =   120
      TabIndex        =   4
      Top             =   120
      Visible         =   0   'False
      Width           =   12375
      Begin VB.TextBox Txt12 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   4440
         TabIndex        =   14
         Text            =   "Documento"
         Top             =   360
         Width           =   1095
      End
      Begin VB.TextBox Text5 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   240
         Locked          =   -1  'True
         TabIndex        =   13
         Text            =   "Cedis"
         Top             =   360
         Width           =   615
      End
      Begin VB.TextBox TxtCedis 
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
         Left            =   960
         Locked          =   -1  'True
         TabIndex        =   12
         Top             =   360
         Width           =   3255
      End
      Begin VB.TextBox TxtDocumentos 
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
         Left            =   5640
         Locked          =   -1  'True
         TabIndex        =   11
         Top             =   360
         Width           =   4695
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
         Left            =   1080
         Locked          =   -1  'True
         TabIndex        =   10
         Top             =   720
         Width           =   1455
      End
      Begin VB.TextBox Text2 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   240
         Locked          =   -1  'True
         TabIndex        =   9
         Text            =   "Fecha"
         Top             =   720
         Width           =   615
      End
      Begin VB.TextBox TxtReferencia 
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
         Left            =   3960
         Locked          =   -1  'True
         TabIndex        =   8
         Top             =   720
         Width           =   1455
      End
      Begin VB.TextBox Text3 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   2760
         Locked          =   -1  'True
         TabIndex        =   7
         Text            =   "Referencia"
         Top             =   720
         Width           =   975
      End
      Begin VB.TextBox TxtReferenciaBancos 
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
         Left            =   7680
         Locked          =   -1  'True
         TabIndex        =   6
         Top             =   720
         Width           =   1935
      End
      Begin VB.TextBox Text6 
         Appearance      =   0  'Flat
         BorderStyle     =   0  'None
         ForeColor       =   &H00000000&
         Height          =   255
         Left            =   5640
         Locked          =   -1  'True
         TabIndex        =   5
         Text            =   "Referencia Bancos"
         Top             =   720
         Width           =   1935
      End
   End
End
Attribute VB_Name = "CC_PagoDesdeArchivo"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public Mes As Integer, Agno As Integer  ' IdCedis, IdMovimiento, IdDocumento, IdTipoDocumento, CargoAbono, Fecha
Dim LstDPartidas, IdMovs

Private Sub btnArchivo_Click()
Dim FPagos As String, NfPagos, Linea, Datos, Saldo, FPagosNo As String, NfPagosNo, FPagosFolios As String, NfPagosFolios
Dim TotalCargados As Integer, TotalNoCargados As Integer, TotalPagosParciales, TotalPorPago
Dim Fecha As Date, IdDoc, IdTipoDoc, Ref, RefBancos, IdCed, Serie, Insertado As Boolean, CargoA, IdMov, Mensj, IdTipoV

On Error GoTo Err_Archivo:

    If MsgBox("Una vez iniciado el proceso, los datos del Archivo se aplicarán en automático. ¿ Estás seguro que deseas continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
        ' If MsgBox("No habrá forma de cancelar los pagos. ¿ Estás seguro que deseas continuar ?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub
    
    If Trim(TxtArchivo.Text) = "" Then
        MsgBox "¡ Teclee el nombre del archivo !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    FPagos = App.Path & "\" & Trim(TxtArchivo.Text) & ".csv"
    FPagosNo = App.Path & "\" & Trim(TxtArchivo.Text) & "No.csv"
    FPagosFolios = App.Path & "\" & Trim(TxtArchivo.Text) & "Folios.csv"
    
    If FileExists(FPagosNo) Then Kill FPagosNo
    If FileExists(FPagosFolios) Then Kill FPagosFolios
        
    If Not FileExists(FPagos) Then
        MsgBox "¡ Archivo: " & FPagos & " no encontrado !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If
    
    MousePointer = 11
    TxtNoCargados.Text = "": TotalCargados = 0: TotalNoCargados = 0: TotalPagosParciales = 0
    
    NfPagos = FreeFile
    Open FPagos For Input As #NfPagos ' Lectura
    
    NfPagosNo = FreeFile
    Open FPagosNo For Output As #NfPagosNo ' Escritura
    NfPagosFolios = FreeFile
    Open FPagosFolios For Output As #NfPagosFolios ' Escritura
    
    Fecha = "01/01/1900": IdDoc = "": IdTipoDoc = "": Ref = "": RefBancos = ""
    IdCed = 0: Serie = "": Insertado = False: IdMov = 0: Mensj = "": IdTipoV = 0
    IdMovs = "": TotalPorPago = 0
    
    While Not EOF(NfPagos)
        Line Input #NfPagos, Linea
        Datos = Split(Linea, ",")
        
        'Si hay cambios en alguna de las variables de control, inserta un nuevo movimiento
        If Fecha <> Trim(Datos(0)) Or IdDoc <> Trim(Datos(1)) Or IdTipoDoc <> Trim(Datos(2)) Or Ref <> Trim(Datos(3)) Or RefBancos <> Trim(Datos(4)) Or Serie <> Trim(Datos(5)) Then
        
            Insertado = True: Mensj = ""
            
            If UBound(Datos, 1) <> 9 Then
                Insertado = False
                Mensj = " Línea de datos incorrecta ": GoTo ValidacionTerminada
            End If
            
            'valida la fecha
            If Not IsDate(Trim(Datos(0))) Then
                Insertado = False
                Mensj = " Fecha no válida ": GoTo ValidacionTerminada
            End If
            
            Fecha = Trim(Datos(0)): IdDoc = Trim(Datos(1)): IdTipoDoc = Trim(Datos(2)): Ref = Trim(Datos(3)): RefBancos = Trim(Datos(4)): Serie = Trim(Datos(5))
            
            'validar idcedis con serie de fact
            StrCmd = " select top 1 IdCedis, IdTipoVenta from Ventas where Serie = '" & Trim(Datos(5)) & "'"
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
            If RsC.EOF Then
                Insertado = False
                Mensj = " Serie de Facturación no válida ": GoTo ValidacionTerminada
            Else
                IdCed = RsC.Fields(0)
                IdTipoV = RsC.Fields(1)
            End If
            
            'valido el periodo
            If Not ValidaPeriodo(IdCed, Year(Fecha), Month(Fecha), "C", "", 1) Then
                Insertado = False
                Mensj = " El Periodo " & Format(Month(Fecha), "MMMM") & " de " & Year(Fecha) & " está CERRADO ": GoTo ValidacionTerminada
            End If
            
            'validar iddoc, idtipodoc existan
            StrCmd = " select IdDocumento, CargoAbono from Documentos where Status = 'A' and IdDocumento = '" & Trim(Datos(1)) & "'"
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
            If RsC.EOF Then
                Insertado = False
                Mensj = " Clave de Documento no válida ": GoTo ValidacionTerminada
            Else
                CargoA = Trim(RsC.Fields(1))
            End If
            
            StrCmd = " select IdTipoDocumento from DocumentosTipo where Status = 'A' and IdTipoDocumento = '" & Trim(Datos(2)) & "'"
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
            If RsC.EOF Then
                Insertado = False
                Mensj = " Clave de Tipo de Documento no válida ": GoTo ValidacionTerminada
            End If
            
            'validar ref y refbancos
            If Not (CargoA = "A" And Mid(Trim(Datos(1)), 1, 1) = "P") Then
                StrCmd = "execute sel_Referencia " & IdCed & ", '" & Trim(Datos(3)) & "', 1"
                If RsC.State Then RsC.Close
                RsC.Open StrCmd, Cnn
                If Not RsC.EOF Then
                    Insertado = False
                    Mensj = " Refrencia ya existe ": GoTo ValidacionTerminada
                End If
    
                StrCmd = "execute sel_Referencia " & IdCed & ", '" & Trim(Datos(4)) & "', 2"
                If RsC.State Then RsC.Close
                RsC.Open StrCmd, Cnn
                If Not RsC.EOF Then
                    Insertado = False
                    Mensj = " Refrencia de Bancos ya existe ": GoTo ValidacionTerminada
                End If
            End If
            
            If Insertado Then
            
                ' Obtiene el Nuevo Documento para Asignar los Movimientos
                StrCmd = " select isnull( max(IdMovimiento)+ 1, 1) from Movimientos where IdCedis = " & IdCed
                If RsC.State Then RsC.Close
                RsC.Open StrCmd, Cnn
                IdMov = RsC.Fields(0)
                
                ' inserta el movimiento...
                StrCmd = "execute up_Movimientos " & IdCed & ", " & IdMov & ", '" & IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy")) & "', '" & IdDoc & "', '" & CargoA & "', 0, '" & Ref & "', '" & RefBancos & "', '" & Trim(Datos(9)) & "', '', '" & Usuario & "', 1"
                If RsC.State Then RsC.Close
                RsC.Open StrCmd, Cnn
                
                IdMovs = IdMovs & "( MovimientosFacturas.IdCedis = " & IdCed & " and MovimientosFacturas.IdMovimiento = " & IdMov & ") or "
                Print #NfPagosFolios, IdCed & ", " & IdMov & ", " & IdDoc & ", " & Ref & ", " & RefBancos & ", " & TotalPorPago
                TotalPorPago = 0
                
            End If
            
ValidacionTerminada:
            
        End If
        
        If Insertado Then

            If UBound(Datos, 1) <> 9 Then
                TxtNoCargados.Text = TxtNoCargados.Text & Linea & "  , Motivo: Línea de datos incorrecta." & Chr(13) & Chr(10)
                Print #NfPagosNo, Linea & ", Motivo: Línea de datos incorrecta."
                TotalNoCargados = TotalNoCargados + 1
            Else
            
                If Not IsNumeric(Datos(6)) Or Not IsNumeric(Datos(7)) Or Not IsNumeric(Datos(8)) Then
                    TxtNoCargados.Text = TxtNoCargados.Text & Linea & "  , Motivo: Las columnas 7, 8 y 9 deben ser numéricas." & Chr(13) & Chr(10)
                    Print #NfPagosNo, Linea & ", Motivo: Las columnas 7, 8 y 9  deben ser numéricas."
                    TotalNoCargados = TotalNoCargados + 1
                Else
                    'busco la factura
                    StrCmd = "execute sel_Ventas " & IdCed & ", 0, '" & Trim(Datos(5)) & "', " & Trim(Datos(6)) & ", 1"
                    If Rs.State Then Rs.Close
                    Rs.Open StrCmd, Cnn
                    Saldo = 0
                    
                    If Rs.EOF Then
                        TxtNoCargados.Text = TxtNoCargados.Text & Linea & "  , Motivo: La Venta no existe." & Chr(13) & Chr(10)
                        Print #NfPagosNo, Linea & ", Motivo: La Venta no existe."
                        TotalNoCargados = TotalNoCargados + 1
                    Else
                        If Rs.Fields(7) = 0 And CargoA = "A" Then
                            TxtNoCargados.Text = TxtNoCargados.Text & Linea & "  , Motivo: La Venta no tiene Saldo pendiente de Aplicar." & Chr(13) & Chr(10)
                            Print #NfPagosNo, Linea & ", Motivo: La Venta no tiene Saldo pendiente de Aplicar."
                            TotalNoCargados = TotalNoCargados + 1
                        Else
                            Saldo = Rs.Fields(7) 'valido pago<=saldo de la factura
                            If CDbl(Saldo) < (CDbl(Datos(7)) + CDbl(Datos(8))) And CargoA = "A" Then
                                
                                StrCmd = "execute up_MovimientosFacturas " & IdCed & ", " & IdTipoV & ", '" & Serie & "', " & Trim(Datos(6)) & ", " & IdMov & ", '" & IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy")) & "', 0, '" & IdDoc & "', '" & IdTipoDoc & "', '" & CargoA & "', " & Saldo & ", 0, 'A', '" & Usuario & "', 1"
                                If Rs.State Then Rs.Close
                                Rs.Open StrCmd, Cnn
                                
                                TxtNoCargados.Text = TxtNoCargados.Text & Linea & "  , Aviso: El Pago fue mayor al Saldo de la Venta. Se Aplicó un abono por " & Saldo & ", Aplicado " & Chr(13) & Chr(10)
                                Print #NfPagosNo, Linea & ", Aviso: El Pago fue mayor al Saldo de la Venta. Se Aplicó un abono por, " & Saldo & ", Aplicado "
                                TotalPagosParciales = TotalPagosParciales + 1
                                'TotalNoCargados = TotalNoCargados + 1
                            Else
                                StrCmd = "execute up_MovimientosFacturas " & IdCed & ", " & IdTipoV & ", '" & Serie & "', " & Trim(Datos(6)) & ", " & IdMov & ", '" & IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy")) & "', 0, '" & IdDoc & "', '" & IdTipoDoc & "', '" & CargoA & "', " & Trim(Datos(7)) & ", " & Trim(Datos(8)) & ", 'A', '" & Usuario & "', 1"
                                If Rs.State Then Rs.Close
                                Rs.Open StrCmd, Cnn
                                TotalCargados = TotalCargados + 1
                                TotalPorPago = TotalPorPago + CDbl(Trim(Datos(7))) + CDbl(Trim(Datos(8)))
                            End If
                        End If
                    End If
                End If
            End If
            
        Else
        
            TxtNoCargados.Text = TxtNoCargados.Text & Linea & "  , Motivo: " & Mensj & Chr(13) & Chr(10)
            Print #NfPagosNo, Linea & ", Motivo: " & Mensj
            TotalNoCargados = TotalNoCargados + 1
            
        End If ' insertado
    Wend
    
    If Len(Trim(IdMovs)) > 5 Then
        IdMovs = Mid(IdMovs, 1, Len(IdMovs) - 4)
    End If

    Close #NfPagos
    Close #NfPagosNo
    Close #NfPagosFolios
    
    TxtResultado.Text = "Resultado de la Aplicación de Archivo: Aplicados = " & TotalCargados & ", Aplicados Parcialmente = " & TotalPagosParciales & ", NO Aplicados = " & TotalNoCargados & "."
    MuestraDetalleArchivo
    MuestraTotalesArchivo
    
No_Err_Archivo:
    MousePointer = 0
    MsgBox "¡ Proceso terminado !", vbInformation + vbOKOnly, App.Title
    Exit Sub
    
Err_Archivo:
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_Err_Archivo:
End Sub

Sub MuestraDetalleArchivo()
On Error Resume Next
    If Trim(IdMovs) <> "" Then
        StrCmd = "execute sel_MovimientosFacturasArchivo '" & IdMovs & "', 1"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If Not Rep Then LstDPartidas = GetDataLVL(RsC, LstPartidas, 1, 9, "0|0|1|9|9|9|9|9|0")
    Else
        LstDPartidas = Empty: LstPartidas.ListItems.Clear
    End If
End Sub

Sub MuestraTotalesArchivo()
On Error Resume Next
    If Trim(IdMovs) <> "" Then
        StrCmd = "execute sel_MovimientosFacturasArchivo '" & IdMovs & "', 2"
        If RsC.State Then RsC.Close
        If Not Rep Then
            RsC.Open StrCmd, Cnn
            LblSubtotal.Caption = FormatCurrency(RsC.Fields(0), 2, vbTrue)
            LblIva.Caption = FormatCurrency(RsC.Fields(1), 2, vbTrue)
            LblTotal.Caption = FormatCurrency(RsC.Fields(2), 2, vbTrue)
        End If
    Else
        LblSubtotal.Caption = FormatCurrency(0, 2, vbTrue)
        LblIva.Caption = FormatCurrency(0, 2, vbTrue)
        LblTotal.Caption = FormatCurrency(0, 2, vbTrue)
    End If
End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    MousePointer = 11
    CC_Movimientos.MuestraMovimientos
    MousePointer = 0
End Sub

Private Sub LstPartidas_DblClick()
On Error Resume Next
    If IsEmpty(LstDPartidas) Then Exit Sub
    DetalleDeFactura IdCedis, LstDPartidas(11, LstPartidas.SelectedItem.Index - 1), LstDPartidas(2, LstPartidas.SelectedItem.Index - 1), LstDPartidas(3, LstPartidas.SelectedItem.Index - 1), Me.Top, Me.Left, Me.Width, Me.Height, 0
End Sub

