VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomctl.ocx"
Begin VB.Form AL_Devoluciones 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Consignación de Productos"
   ClientHeight    =   8010
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
   ScaleHeight     =   8010
   ScaleWidth      =   12660
   ShowInTaskbar   =   0   'False
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
      Height          =   7935
      Left            =   120
      TabIndex        =   0
      Top             =   0
      Width           =   12375
      Begin VB.CommandButton cmdAccion 
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
         Index           =   2
         Left            =   3840
         Picture         =   "AL_Devoluciones.frx":0000
         Style           =   1  'Graphical
         TabIndex        =   36
         Top             =   7320
         Width           =   1695
      End
      Begin VB.TextBox TxtDatos 
         Alignment       =   1  'Right Justify
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   330
         Index           =   8
         Left            =   10800
         MaxLength       =   8
         TabIndex        =   34
         Top             =   4470
         Width           =   825
      End
      Begin VB.TextBox TxtDatos 
         Alignment       =   1  'Right Justify
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   330
         Index           =   7
         Left            =   9750
         MaxLength       =   8
         TabIndex        =   12
         Top             =   4470
         Width           =   945
      End
      Begin VB.TextBox TxtDatos 
         Alignment       =   1  'Right Justify
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   330
         Index           =   0
         Left            =   90
         Locked          =   -1  'True
         TabIndex        =   11
         Top             =   1200
         Width           =   885
      End
      Begin VB.TextBox TxtDatos 
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   2640
         Index           =   4
         Left            =   120
         MaxLength       =   5000
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   10
         Top             =   4470
         Width           =   2775
      End
      Begin VB.TextBox TxtDatos 
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   330
         Index           =   3
         Left            =   2880
         TabIndex        =   9
         Top             =   1980
         Width           =   2055
      End
      Begin VB.TextBox TxtDatos 
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   330
         Index           =   2
         Left            =   1290
         TabIndex        =   8
         Top             =   1980
         Width           =   1485
      End
      Begin VB.TextBox TxtDatos 
         Alignment       =   1  'Right Justify
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   330
         Index           =   1
         Left            =   90
         TabIndex        =   7
         Top             =   1980
         Width           =   1095
      End
      Begin VB.TextBox TxtDatos 
         Alignment       =   1  'Right Justify
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   330
         Index           =   5
         Left            =   3000
         MaxLength       =   5
         TabIndex        =   6
         Top             =   4470
         Width           =   795
      End
      Begin VB.TextBox TxtDatos 
         BackColor       =   &H00FFFFFF&
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   330
         Index           =   6
         Left            =   3930
         Locked          =   -1  'True
         TabIndex        =   5
         Top             =   4470
         Width           =   5685
      End
      Begin VB.CommandButton cmdAccion 
         BackColor       =   &H00FFFFFF&
         Caption         =   "&Aceptar"
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
         Index           =   3
         Left            =   10410
         Style           =   1  'Graphical
         TabIndex        =   4
         Top             =   7320
         Visible         =   0   'False
         Width           =   1695
      End
      Begin VB.CommandButton cmdAccion 
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
         Index           =   1
         Left            =   2070
         Picture         =   "AL_Devoluciones.frx":05FE
         Style           =   1  'Graphical
         TabIndex        =   3
         Top             =   7320
         Width           =   1695
      End
      Begin VB.CommandButton cmdAccion 
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
         Index           =   4
         Left            =   5580
         Picture         =   "AL_Devoluciones.frx":0F94
         Style           =   1  'Graphical
         TabIndex        =   2
         Top             =   7320
         Width           =   1695
      End
      Begin VB.CommandButton cmdAccion 
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
         Index           =   0
         Left            =   240
         Picture         =   "AL_Devoluciones.frx":16AF
         Style           =   1  'Graphical
         TabIndex        =   1
         Top             =   7320
         Width           =   1695
      End
      Begin MSComCtl2.DTPicker DTPFecha 
         Height          =   345
         Index           =   0
         Left            =   1080
         TabIndex        =   13
         Top             =   1200
         Width           =   3510
         _ExtentX        =   6191
         _ExtentY        =   609
         _Version        =   393216
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         CustomFormat    =   "dddd, dd 'de' MMMM 'de' yyyy"
         Format          =   148766723
         CurrentDate     =   39376
      End
      Begin MSComCtl2.DTPicker DTPFecha 
         Height          =   345
         Index           =   1
         Left            =   4710
         TabIndex        =   14
         Top             =   1200
         Width           =   3510
         _ExtentX        =   6191
         _ExtentY        =   609
         _Version        =   393216
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         CustomFormat    =   "dddd, dd 'de' MMMM 'de' yyyy"
         Format          =   148766723
         CurrentDate     =   39376
      End
      Begin MSComctlLib.ListView LstVDatos 
         Height          =   1635
         Index           =   0
         Left            =   90
         TabIndex        =   15
         Top             =   2370
         Width           =   11565
         _ExtentX        =   20399
         _ExtentY        =   2884
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
      Begin MSComctlLib.ListView LstVDatos 
         Height          =   2265
         Index           =   1
         Left            =   3000
         TabIndex        =   16
         Top             =   4830
         Width           =   8655
         _ExtentX        =   15266
         _ExtentY        =   3995
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         FullRowSelect   =   -1  'True
         _Version        =   393217
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
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
      Begin VB.Label LblDatos 
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BackStyle       =   0  'Transparent
         Caption         =   "Tipo de Accion a Realizar"
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
         Height          =   270
         Index           =   4
         Left            =   7710
         TabIndex        =   31
         Top             =   7500
         Width           =   2610
      End
      Begin VB.Line Line3 
         X1              =   120
         X2              =   12255
         Y1              =   600
         Y2              =   600
      End
      Begin VB.Label Label11 
         BackColor       =   &H00FFFFFF&
         BackStyle       =   0  'Transparent
         Caption         =   "Cantidad"
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
         Left            =   10800
         TabIndex        =   35
         Top             =   4170
         Width           =   945
      End
      Begin VB.Label Label6 
         BackColor       =   &H00FFFFFF&
         BackStyle       =   0  'Transparent
         Caption         =   "Existencias"
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
         Left            =   9750
         TabIndex        =   33
         Top             =   4170
         Width           =   945
      End
      Begin VB.Label Label5 
         BackColor       =   &H00FFFFFF&
         BackStyle       =   0  'Transparent
         Caption         =   "Estatus de la Consigna"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   8430
         TabIndex        =   32
         Top             =   690
         Width           =   2685
      End
      Begin VB.Label LblDatos 
         Appearance      =   0  'Flat
         AutoSize        =   -1  'True
         BackColor       =   &H80000005&
         BackStyle       =   0  'Transparent
         Caption         =   "Estatus del Movimiento"
         ForeColor       =   &H00000080&
         Height          =   240
         Index           =   2
         Left            =   8550
         TabIndex        =   30
         Top             =   1050
         Width           =   2025
      End
      Begin VB.Label Label4 
         BackColor       =   &H00FFFFFF&
         BackStyle       =   0  'Transparent
         Caption         =   "Folio"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   120
         TabIndex        =   29
         Top             =   900
         Width           =   615
      End
      Begin VB.Label Label7 
         BackColor       =   &H00FFFFFF&
         BackStyle       =   0  'Transparent
         Caption         =   "Observaciones"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   150
         TabIndex        =   28
         Top             =   4170
         Width           =   1695
      End
      Begin VB.Label LblDatos 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         BackStyle       =   0  'Transparent
         Caption         =   "Surtido para entrega"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   11.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Index           =   0
         Left            =   360
         TabIndex        =   27
         Top             =   240
         Width           =   1980
      End
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         BackStyle       =   0  'Transparent
         Caption         =   "Fecha de Entrega programada"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   1110
         TabIndex        =   26
         Top             =   900
         Width           =   2445
      End
      Begin VB.Label Label3 
         BackColor       =   &H00FFFFFF&
         BackStyle       =   0  'Transparent
         Caption         =   "Fecha de Devolución"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   4740
         TabIndex        =   25
         Top             =   900
         Width           =   2685
      End
      Begin VB.Label LblDatos 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         BackStyle       =   0  'Transparent
         Caption         =   "Surtido para Devolucion"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   11.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   255
         Index           =   1
         Left            =   6240
         TabIndex        =   24
         Top             =   240
         Width           =   2325
      End
      Begin VB.Label LblDatos 
         BackColor       =   &H00FFFFFF&
         BorderStyle     =   1  'Fixed Single
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   330
         Index           =   3
         Left            =   5040
         TabIndex        =   23
         Top             =   1980
         Width           =   6615
      End
      Begin VB.Label Label12 
         BackColor       =   &H00FFFFFF&
         BackStyle       =   0  'Transparent
         Caption         =   "Clave"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   3000
         TabIndex        =   22
         Top             =   4170
         Width           =   705
      End
      Begin VB.Label Label1 
         BackColor       =   &H00FFFFFF&
         BackStyle       =   0  'Transparent
         Caption         =   "Descripción del Producto"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   3810
         TabIndex        =   21
         Top             =   4170
         Width           =   2265
      End
      Begin VB.Label Label22 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         BackStyle       =   0  'Transparent
         Caption         =   "Sucursal"
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
         Left            =   1290
         TabIndex        =   20
         Top             =   1680
         Width           =   735
      End
      Begin VB.Label Label21 
         BackColor       =   &H00FFFFFF&
         BackStyle       =   0  'Transparent
         Caption         =   "Razón Social ( Cliente )"
         BeginProperty Font 
            Name            =   "Arial"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   2910
         TabIndex        =   19
         Top             =   1680
         Width           =   2295
      End
      Begin VB.Label Label20 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         BackStyle       =   0  'Transparent
         Caption         =   "No. Cliente"
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
         Left            =   120
         TabIndex        =   18
         Top             =   1680
         Width           =   915
      End
      Begin VB.Label Label26 
         AutoSize        =   -1  'True
         BackColor       =   &H00FFFFFF&
         BackStyle       =   0  'Transparent
         Caption         =   "Cliente Seleccionado"
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
         Left            =   5790
         TabIndex        =   17
         Top             =   1680
         Width           =   1755
      End
   End
End
Attribute VB_Name = "AL_Devoluciones"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'variables de entrada para el registro de consigna
Public IdRutaConsigna As Long
Public IdSurtidoConsigna As Long
Public Accion As String
Public ControlFormas As Boolean

Dim IdRutaEntrega As Long, IdSurtidoEntrega As Long
Dim IdRutaDevolucion As Long, IdSurtidoDevolucion As Long

Dim IdConsigna As Long
Dim FechaEntrega As Date, FechaDevolucion As Date
Dim IdCliente As Long, IdSucursal As String  ', IdListaCliente As Long
Dim NombreCliente As String, NombreSucursal As String
Dim Observaciones As String
Dim StatusConsigna As String, DescripcionStatus As String
Dim IdMovimientoEntrega As Long, IdMovimientoDevolucion As Long
Dim FolioMovimientoEntrega As String, FolioMovimientoDevolucion As String

Const ctColorBloqueado = &HFFFFFF '&HE0E0E0
Const ctColorDesbloqueado = &HFFFFFF

Const ctProductosRegistro = "LISTAPRODUCTOSREGISTRO"
Dim ListaDeProductosRegistro As Variant
Const ctProductosDevolucion = "LISTAPRODUCTOSDEVOLUCION"
Dim ListaDeProductosDevolucion As Variant
Const ctProductosConsulta = "LISTAPRODUCTOSCONSULTA"
Dim ListaDeProductosConsulta As Variant

Dim IdProducto, DescripcionProducto, CantidadSurtidaConsigna
Dim CantidadSurtida, Venta, Obsequios, DevolucionBuena, DevolucionMala, Existencias
Dim ConsignasPendientes, ConsignaActual

Const ctClientes = "LISTACLIENTES"
Dim ListaDeClientes As Variant

'Constantes y variables para el tipo de movimiento que se realizará
Const ctTipoMovimientoSalida = "Salida_EntregaConsigna"
Const ctTipoMovimientoEntrada = "Entrada_DevuelveConsigna"
    Dim vTipoMovimiento As String

'Constantes y variables de accion que se llevarà a cabo en pantalla
Const ctNuevaConsigna = "Registrar una Nueva Consigna"
Const ctEditaConsignaSurtido = "Editar los Detalles del Surtido"
Const ctEditaConsignaCliente = "Editar los Datos del Cliente"
Const ctConsultaConsigna = "Consultar una Consigna"
Const ctDevolverConsigna = "Registrar las Devoluciones de la Consigna"
Const ctCancelaConsigna = "Cancelar una Consigna"

'''Const ctAplicarConsigna = "AplicaMovimientosConsigna"
    Dim vAccionConsigna As String
         
'variable publica para controlar el tipo de edicion de una consigna
    Public vTipoEdicionConsigna As Integer
    Public vCancel As Boolean
         
Sub PreparaDatos(TipoLista As String)

    On Error GoTo ErrConexion2
    
    If Rs.State Then Rs.Close
    
    Select Case TipoLista
    
        Case ctClientes
        
            StrCmd = "execute sel_ClientesFacturas " & IdCedis & ",'" & IIf(Trim(TxtDatos(1).Text) = "", 0, Trim(TxtDatos(1).Text)) & "','" & Trim(TxtDatos(2).Text) & "','" & Trim(TxtDatos(3).Text) & "', 1"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
'            Debug.Print StrCmd
            ListaDeClientes = GetDataLVL(Rs, LstVDatos(0), 1, 4, "0|0|0|0")
        
        Case ctProductosConsulta

            StrCmd = "execute sel_ConsignasDetalle " & IdCedis & "," & IdConsigna & ", 0, 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            ListaDeProductosRegistro = GetDataLVL(Rs, LstVDatos(1), 1, 8, "1|0|9|9|9|3|3|3")
        
        Case ctProductosRegistro

            StrCmd = "execute sel_ConsignasDetalle " & IdCedis & "," & IdConsigna & ", 0, 3"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            ListaDeProductosRegistro = GetDataLVL(Rs, LstVDatos(1), 1, 3, "1|0|9")
        
        Case ctProductosDevolucion

            StrCmd = "execute sel_ConsignasDetalle " & IdCedis & "," & IdConsigna & ", 0, 4"
            If Rs.State Then Rs.Close
            Rs.Open StrCmd, Cnn
            ListaDeProductosRegistro = GetDataLVL(Rs, LstVDatos(1), 1, 8, "1|0|9|9|9|9|9|9")

    End Select
    
    Exit Sub
ErrConexion2:
    MsgBox "Error al Preparar Consultar Información. " & Chr(13) & Chr(10) & Err.Description, vbExclamation, "Error del Módulo...."
    
    MousePointer = 0
    Exit Sub
End Sub

Sub HabilitaObjetos(TipoMovimiento As String, Accion As String)
    
    'On Error Resume Next
    
    'Bloquea Todos los objetos de la seccion de Socio

    For i = 0 To 1: DTPFecha(i).Enabled = False: Next
    For i = 0 To 1: LstVDatos(i).Enabled = False: Next
    For i = 0 To 8: TxtDatos(i).Locked = True: TxtDatos(i).BackColor = ctColorBloqueado: Next

    For i = 0 To 4: cmdAccion(i).Enabled = False: Next
    
    Select Case Accion
        Case ctNuevaConsigna
            For i = 1 To 1: DTPFecha(i).Enabled = True: Next
            For i = 0 To 0: LstVDatos(i).Enabled = True: Next
            For i = 1 To 4: TxtDatos(i).Locked = False: TxtDatos(i).BackColor = ctColorDesbloqueado: Next
    
            For i = 1 To 2: cmdAccion(i).Enabled = True: Next
                    
            DTPFecha(1).SetFocus
                    
        Case ctEditaConsignaSurtido
            For i = 1 To 1: LstVDatos(i).Enabled = True: Next
            For i = 5 To 8: TxtDatos(i).Locked = False: TxtDatos(i).BackColor = ctColorDesbloqueado: Next
    
            For i = 1 To 2: cmdAccion(i).Enabled = True: Next
        
            TxtDatos(5).SetFocus
        
        Case ctEditaConsignaCliente
            For i = 1 To 1: DTPFecha(i).Enabled = True: Next
            For i = 0 To 0: LstVDatos(i).Enabled = True: Next
            For i = 1 To 4: TxtDatos(i).Locked = False: TxtDatos(i).BackColor = ctColorDesbloqueado: Next
    
            For i = 1 To 2: cmdAccion(i).Enabled = True: Next
        
            DTPFecha(1).SetFocus
        
        Case ctDevolverConsigna
            For i = 1 To 1: LstVDatos(i).Enabled = True: Next
            For i = 5 To 8: TxtDatos(i).Locked = False: TxtDatos(i).BackColor = ctColorDesbloqueado: Next
    
            For i = 1 To 2: cmdAccion(i).Enabled = True: Next
            
            TxtDatos(5).SetFocus
            
        Case ctConsultaConsigna
            For i = 0 To 1: LstVDatos(i).Enabled = True: Next
            'TxtDatos(0).Locked = False: TxtDatos(0).BackColor = ctColorDesbloqueado
    
            'CmdAccion(0).Enabled = True:
            cmdAccion(4).Enabled = True
            
            'TxtDatos(0).SetFocus
            
    End Select
        
    'los objetos para la descripcion del producto y existencias siempre se encuentran bloqueados
    For i = 6 To 7: TxtDatos(i).Locked = True: TxtDatos(i).BackColor = ctColorBloqueado: Next
    
End Sub

Sub LimpiaObjetos(TipoMovimiento As String, Accion As String)

    Dim RutaSurtidoRegistro As String
    Dim RutaSurtidoDevolucion As String

    RutaSurtidoRegistro = IIf(IdSurtidoEntrega = 0, "", "Surtido " & Format(IdSurtidoEntrega, "0000000") & " - Ruta " & IdRutaEntrega)
    RutaSurtidoDevolucion = IIf(IdSurtidoDevolucion = 0, "", "Surtido " & Format(IdSurtidoDevolucion, "0000000") & " - Ruta " & IdRutaDevolucion)
    
    Select Case Accion
        Case ctConsultaConsigna, ctNuevaConsigna, ctEditaConsignaSurtido, _
            ctEditaConsignaCliente, ctDevolverConsigna
            
            GoSub LimpiaDetallesRutaSurtido
            GoSub LimpiaDetallesConsigna
            
    End Select

    LblDatos(4).Caption = Accion

    Exit Sub

LimpiaDetallesRutaSurtido:
    LblDatos(0).Caption = RutaSurtidoRegistro: DTPFecha(0).Value = Fecha ': DTPFecha(0).MinDate = Date
    LblDatos(1).Caption = RutaSurtidoDevolucion: DTPFecha(1).Value = Fecha ': DTPFecha(1).MinDate = Date
    Return

LimpiaDetallesConsigna:
    LblDatos(2).Caption = "": LblDatos(3).Caption = ""
    For i = 1 To 8: TxtDatos(i).Text = "": Next
    For i = 0 To 1: LstVDatos(i).ColumnHeaders.Clear: LstVDatos(i).ListItems.Clear: Next
    Return
    
End Sub
    
Sub LimpiaVariablesConsigna()

    'Limpia las variables de datos ----------------------
    
    IdSurtidoEntrega = 0: IdRutaEntrega = 0
    IdSurtidoDevolucion = 0: IdRutaDevolucion = 0
    '''IdConsigna = 0
    FechaEntrega = Fecha: FechaDevolucion = Fecha
    IdCliente = 0: IdSucursal = "":
    NombreCliente = "": NombreSucursal = ""
    Observaciones = ""
    StatusConsigna = "": DescripcionStatus = ""
    IdMovimientoEntrega = 0: IdMovimientoDevolucion = 0
    FolioMovimientoEntrega = "": FolioMovimientoDevolucion = ""

End Sub

Private Sub CmdAccion_Click(Index As Integer)

On Error GoTo ErrorHandler

    Select Case Index
        Case 0          'caso de Nueva Consigna
            
            LimpiaVariablesConsigna
            
            vTipoMovimiento = ctTipoMovimientoSalida
            IdRutaEntrega = IdRutaConsigna: IdSurtidoEntrega = IdSurtidoConsigna
            IdRutaDevolucion = 0: IdSurtidoDevolucion = 0

            vAccionConsigna = ctNuevaConsigna
            LimpiaObjetos vTipoMovimiento, vAccionConsigna
            HabilitaObjetos vTipoMovimiento, vAccionConsigna
        
            LblDatos(2).Caption = "Nueva Consigna"

        Case 1          'caso de guardar nueva consigna o cambios a una consigna
        
            '----------- Validaciones comunes por tipo de accion ------------------
        
            Select Case vAccionConsigna
                Case ctNuevaConsigna, ctEditaConsignaCliente
                
                    ' valida la seleccion del cliente
                    If IdCliente = 0 Or IdSucursal = 0 Then
                        MsgBox "¡ Seleccione un Cliente y una Sucursal a quien se asignará la Consigna !", vbInformation + vbOKOnly, App.Title
                        Exit Sub
                    End If

                    'Valida la fecha de devolucion registrada (propuesta para mejora posterior)

            End Select
                            
            Select Case vAccionConsigna
                Case ctEditaConsignaSurtido
                
                    ' valida si la lista tiene productos capturados
                    If LstVDatos(1).ListItems.Count = 0 Then
                        If MsgBox("No se han capturado productos, ¿Desea Continuar?", vbQuestion + vbYesNo + vbDefaultButton1, App.Title) = vbNo Then Exit Sub
                    End If
                
            End Select
                              
            '----------- Mensajes de aceptación de accion --------------------------
               
            Select Case vAccionConsigna
                Case ctNuevaConsigna
                    
                    If MsgBox("Se registrará una nueva consigna, ¿ Desea continuar ?", vbQuestion + vbYesNo + vbDefaultButton1, App.Title) = vbNo Then Exit Sub
                
                Case ctEditaConsignaCliente
                
                    If MsgBox("Se guardarán las modificaciones al cliente asignado, ¿ Desea continuar ?", vbQuestion + vbYesNo + vbDefaultButton1, App.Title) = vbNo Then Exit Sub
                
                Case ctEditaConsignaSurtido
                
                    If MsgBox("Se registrarán las movimientos de la consigna para la ruta " & IdRutaEntrega & ", surtido " & IdSurtidoEntrega & ", ¿ Desea continuar ?", vbQuestion + vbYesNo + vbDefaultButton1, App.Title) = vbNo Then Exit Sub
                
                Case ctDevolverConsigna
                
                    If MsgBox("Se registrarán las ventas de la consigna para la ruta " & IdRutaDevolucion & ", surtido " & IdSurtidoDevolucion & ", ¿ Desea continuar ?", vbQuestion + vbYesNo + vbDefaultButton1, App.Title) = vbNo Then Exit Sub

            End Select
            
            '----------- Ejecución de Acciones --------------------------------------
            
            Select Case vAccionConsigna
                Case ctNuevaConsigna
                    'insertar los datos de la consigna (cliente y surtido)
                        IdRutaEntrega = IdRutaConsigna
                        IdSurtidoEntrega = IdSurtidoConsigna
                    
                        'se debe generar el folio de la consigna
                        StrCmd = "execute sel_Consignas " & IdCedis & ",0,0,'',0"

                        If Rs.State Then Rs.Close
                        Rs.Open StrCmd, Cnn
                        
                        IdConsigna = Rs.Fields("IdConsigna").Value
                        TxtDatos(0).Text = IdConsigna
                        
                        'se debe generar el registro de la consigna
                        StrCmd = "execute up_Consignas " & IdCedis & "," & IdConsigna & "," & IdCliente & ",'" & _
                                                        IdSucursal & "'," & IdRutaEntrega & "," & IdSurtidoEntrega & _
                                                        ",'" & FormatDate(DTPFecha(0).Value) & "',0,0,0,'" & FormatDate(DTPFecha(1).Value) & "',0,0,'','" & Trim(TxtDatos(4).Text) & "','P',1"
                        If Rs.State Then Rs.Close
                        Rs.Open StrCmd, Cnn
                                                
                        MsgBox "Se registró la consigna correctamente, continue con la captura de productos.", vbInformation + vbOKOnly, App.Title
                        
                        vTipoMovimiento = ctTipoMovimientoSalida
                        IdRutaDevolucion = 0: IdSurtidoDevolucion = 0
                        vAccionConsigna = ctEditaConsignaSurtido
                                                
                        HabilitaObjetos vTipoMovimiento, vAccionConsigna
                        
                        Exit Sub
                        
                Case ctEditaConsignaSurtido
                    'Aplica la captura de productos de la consigna en el surtido de la ruta y en el inventario
                    IdRutaEntrega = IdRutaConsigna
                    IdSurtidoEntrega = IdSurtidoConsigna

                    'actualizar el status de la consigna a "R - Consigna Registrada"
                    StrCmd = "execute up_Consignas " & IdCedis & ", " & IdConsigna & ",0,''," & IdRutaEntrega & "," & _
                                                    IdSurtidoEntrega & ",'" & FormatDate(Fecha) & "',0,0,0,'',0,0,'','','R',3"
                    If Rs.State Then Rs.Close
                    Rs.Open StrCmd, Cnn
                                            
                    MsgBox "Se registró la consigna correctamente.", vbInformation + vbOKOnly, App.Title
                    
                Case ctEditaConsignaCliente
                    
                    'Actualizar los datos del cliente de la consigna
                    StrCmd = "execute up_Consignas " & IdCedis & "," & IdConsigna & "," & IdCliente & ",'" & _
                                                    IdSucursal & "'," & IdRutaEntrega & "," & _
                                                    IdSurtidoEntrega & ",'',0,0,0,'" & FormatDate(DTPFecha(1).Value) & "',0,0,'','" & Trim(TxtDatos(4).Text) & "','',2"
                    If Rs.State Then Rs.Close
                    Rs.Open StrCmd, Cnn
                    
                    'se debe emitir mensaje de movimiento realizado
                    MsgBox "Se cambiaron los datos correctamente.", vbInformation + vbOKOnly, App.Title
                                                                                        
                Case ctDevolverConsigna
                    'Registra las ventas de productos de la consigna
                    
                    'actualizar el status de la consigna a "D - En Registro  de Devoluciones"
                    StrCmd = "execute up_Consignas " & IdCedis & ", " & IdConsigna & "," & IdCliente & ",'" & _
                                                    IdSucursal & "',0,0,'',0," & _
                                                    IdRutaDevolucion & "," & IdSurtidoDevolucion & ",'" & FormatDate(Fecha) & "',0,0,'','','D',3"
                    If Rs.State Then Rs.Close
                    Rs.Open StrCmd, Cnn
                    
                    MsgBox "Se registró la devolución correctamente.", vbInformation + vbOKOnly, App.Title
                
            End Select
        
            vAccionConsigna = ctConsultaConsigna
            LimpiaObjetos vTipoMovimiento, vAccionConsigna
            HabilitaObjetos vTipoMovimiento, vAccionConsigna
        
            Unload Me
        Case 2          'caso de cancelar una accion
        
'''            'Mensajes previos a la Cancelación
'''            Dim MSGCancelaAccion As String
'''
'''            Select Case vAccionConsigna
'''                Case ctNuevaConsigna
'''                    MSGCancelaAccion = "Se cancelará el Registro de la Consigna..."
'''
'''                Case ctEditaConsignaSurtido, ctEditaConsignaCliente
'''                    MSGCancelaAccion = "Se cancelará la Edición de la Consigna..."
'''
'''            End Select
        
'''            vAccionConsigna = ctConsultaConsigna
'''            LimpiaObjetos vTipoMovimiento, vAccionConsigna
'''            HabilitaObjetos vTipoMovimiento, vAccionConsigna
            
            Unload Me
        
        Case 3
            
'''            vAccionConsigna = ctConsultaConsigna
'''            LimpiaObjetos vTipoMovimiento, vAccionConsigna
'''            HabilitaObjetos vTipoMovimiento, vAccionConsigna
            Unload Me
            
        Case 4          'caso de impresion de reporte
        
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
    
    End Select
    
    Exit Sub
    
ErrorHandler:
    MsgBox "Error al ejecutar la acción seleccionada: " & Err.Description, vbCritical + vbOKOnly, App.Title
    Exit Sub
        
End Sub

Private Sub cmdCerrarVentana_Click()
    Unload Me
End Sub

Private Sub DTPFecha_Change(Index As Integer)

    Select Case Index
    
        Case 0      'caso de fecha de entrega
            DTPFecha(1).MinDate = DTPFecha(0).Value
            
        Case 1      'caso de fecha de devolucion
     
    End Select

End Sub

Private Sub Form_Activate()
'On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    Screen.MousePointer = vbDefault
    
    If Not ControlFormas Then Exit Sub
    
    Select Case Accion
        Case "N"
            CmdAccion_Click 0
            
        Case "E"    'viene de una consigna que ya existe y se va a editar o consultar
            TxtDatos_KeyPress 0, 13
            
        Case "D"    'se va a devolver una consigna ya seleccionada
'''            vAccionConsigna = ctConsultaConsigna
'''            LimpiaObjetos vTipoMovimiento, vAccionConsigna
'''            HabilitaObjetos vTipoMovimiento, vAccionConsigna
            TxtDatos_KeyPress 0, 13
    End Select

End Sub

Private Sub Form_Load()

    On Error GoTo ErrorHandler

    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    Screen.MousePointer = vbDefault
    
    Exit Sub
    
ErrorHandler:

    MsgBox "Error al abrir el módulo de consignas", vbCritical, "Error...."

    Exit Sub

End Sub

Private Sub Form_Unload(Cancel As Integer)

    If Rs.State Then Rs.Close
    
    CSG_ConsignasInicial.PreparaDatos "ConsignasPorStatus"

End Sub

Private Sub LstVDatos_Click(Index As Integer)

    'On Error Resume Next

    If LstVDatos(Index).ListItems.Count > 0 Then

        Select Case Index
    
            Case 0      'caso de lista de clientes
                If Not IsEmpty(ListaDeClientes) Then
                
                    'TxtDatos(1).Text = Trim(LstVDatos(0).SelectedItem)
                    IdCliente = Trim(LstVDatos(0).SelectedItem)
                    IdSucursal = ListaDeClientes(10, LstVDatos(0).SelectedItem.Index - 1)
                    'IdListaCliente = ListaDeClientes(8, LstVDatos(0).SelectedItem.Index - 1)
                    LblDatos(3).Caption = LstVDatos(0).SelectedItem & " , " & LstVDatos(0).SelectedItem.ListSubItems(1).Text & Chr(13) & Chr(10) & LstVDatos(0).SelectedItem.ListSubItems(2).Text & " , " & LstVDatos(0).SelectedItem.ListSubItems(3).Text
                End If
            
            Case 1      'caso de lista de  Productos
            
                
    
        End Select
        
    End If
    
End Sub


Private Sub LstVDatos_ItemClick(Index As Integer, ByVal Item As MSComctlLib.ListItem)

    LstVDatos_Click Index

End Sub

Private Sub TxtDatos_Change(Index As Integer)
    
    If TxtDatos(Index).Locked = True Then Exit Sub
    
    Select Case Index
        
        Case 0      'caso de Folio
        
        Case 1      'caso de IdCliente
    
            LblDatos(3).Caption = ""
            PreparaDatos ctClientes
       
        Case 2      'caso de Sucursal
            LblDatos(3).Caption = ""
            PreparaDatos ctClientes
        
        Case 3      'caso de Razon Social
            TxtDatos(1).Text = ""
            LblDatos(3).Caption = ""
            PreparaDatos ctClientes
        
        Case 4      'caso de Observaciones
        
        Case 5      'Caso de Clave de Producto
            TxtDatos(6).Text = "":
            TxtDatos(7).Text = 0

        Case 6      'Caso de Descripcion de Producto

        Case 7      'Caso de Existencia de Producto

        Case 8      'Caso de Cantidad de Producto

    End Select
    
End Sub

Private Sub TxtDatos_GotFocus(Index As Integer)

    SelText TxtDatos(Index)
    
End Sub

Private Sub TxtDatos_KeyPress(Index As Integer, KeyAscii As Integer)
    
    Dim vEsDevolucion As Boolean
    
    Select Case Index
        
        Case 0      'caso de Folio
            If Trim(TxtDatos(0).Text) = "0" Then
                'CSG_busquedaConsigna.Show vbModal
            End If
            
            KeyAscii = itString(KeyAscii)
            If KeyAscii = "13" Then
            
                LimpiaVariablesConsigna
                
                'valida la existencia de la consigna para traer los datos a pantalla
                StrCmd = "execute sel_Consignas " & IdCedis & "," & TxtDatos(0).Text & ",0,'',1"
                If Rs.State Then Rs.Close
                Rs.Open StrCmd, Cnn
                
                If Rs.EOF Then
                    MsgBox "No se encontró la consigna con el número de folio introducido.", vbInformation + vbOKOnly, App.Title
                    Exit Sub
                End If
                
                IdRutaEntrega = Rs.Fields("IdRutaEntrega").Value
                IdSurtidoEntrega = Rs.Fields("IdSurtidoEntrega").Value
                IdRutaDevolucion = Rs.Fields("IdRutaDevolucion").Value
                IdSurtidoDevolucion = Rs.Fields("IdSurtidoDevolucion").Value
                
                IdConsigna = Rs.Fields("IdConsigna").Value
                FechaEntrega = Rs.Fields("FechaEntrega").Value
                FechaDevolucion = Rs.Fields("FechaDevolucion").Value
                IdCliente = Rs.Fields("IdCliente").Value
                NombreCliente = Rs.Fields("NombreCliente").Value
                IdSucursal = Rs.Fields("IdSucursal").Value
                NombreSucursal = Rs.Fields("NombreSucursal").Value
                'IdListaCliente = Rs.Fields("IdListaCliente").Value
                Observaciones = Rs.Fields("Observaciones").Value
                StatusConsigna = Rs.Fields("StatusConsigna").Value
                DescripcionStatus = Rs.Fields("DescripcionStatus").Value
                IdMovimientoEntrega = Rs.Fields("IdMovimientoEntrega").Value
                IdMovimientoDevolucion = Rs.Fields("IdMovimientoDevolucion").Value

                If StatusConsigna = "D" Or StatusConsigna = "R" Or StatusConsigna = "V" Then

                    'Si el estatus de la Consigna es Devoluciones solo se consulta informacion
                    
                    vTipoEdicionConsigna = 1

                Else
                
                    'Si no esta en proceso de devolucion, Pregunta si la consigna se va a editar o se registrarà una nueva devoluciòn
                    vCancel = True
                    With CSG_ConsignaTipoEdicion
                        .StatusConsigna = StatusConsigna
                        .Left = AL_Liquidacion.Left + (AL_Liquidacion.Width - .Width) / 2
                        .Top = AL_Liquidacion.Top + (AL_Liquidacion.Height - .Height) / 2
                        .Show vbModal
                    End With
                    If vCancel = True Then Exit Sub
                    
                    If vTipoEdicionConsigna = 0 Then
                        IdRutaDevolucion = IdRutaConsigna: IdSurtidoDevolucion = IdSurtidoConsigna
                    End If
                End If
                
                'habilita los controles de la pantalla segun la opcion seleccionada
                Select Case vTipoEdicionConsigna
                    Case 0      'caso de registro de devoluciones
                        ''IdRutaDevolucion = IdRutaConsigna: IdSurtidoDevolucion = IdSurtidoConsigna
                        vTipoMovimiento = ctTipoMovimientoEntrada
                        vAccionConsigna = ctDevolverConsigna
                    
                    Case 1      'caso de solo mostrar los detalles de la consigna
                        vTipoMovimiento = ctTipoMovimientoSalida
                        ''IdRutaDevolucion = 0: IdSurtidoDevolucion = 0
                        vAccionConsigna = ctConsultaConsigna
                    
                    Case 2      'caso de cambios en el surtido de la consigna
                        vTipoMovimiento = ctTipoMovimientoSalida
                        ''IdRutaDevolucion = 0: IdSurtidoDevolucion = 0
                        vAccionConsigna = ctEditaConsignaSurtido
                    
                    Case 3      'caso de cambios en los datos de cliente
                        vTipoMovimiento = ctTipoMovimientoSalida
                        ''IdRutaDevolucion = 0: IdSurtidoDevolucion = 0
                        vAccionConsigna = ctEditaConsignaCliente
                    
                End Select
                
                LimpiaObjetos vTipoMovimiento, vAccionConsigna
                HabilitaObjetos vTipoMovimiento, vAccionConsigna
                
                'muestra los datos de la consigna
                
                DTPFecha(0).Value = FechaEntrega
                DTPFecha(1).Value = FechaDevolucion
                LblDatos(2).Caption = DescripcionStatus
                LblDatos(3).Caption = NombreCliente
                LblDatos(3).Caption = IdCliente & " , " & NombreCliente & ", Suc: " & IdSucursal & " , " & NombreSucursal
                TxtDatos(4).Text = Observaciones
                
                'carga los datos de los productos
                Select Case vAccionConsigna
                    Case ctDevolverConsigna
                        PreparaDatos ctProductosDevolucion
                    Case ctEditaConsignaSurtido, ctEditaConsignaCliente
                        PreparaDatos ctProductosRegistro
                    Case ctConsultaConsigna
                        PreparaDatos ctProductosConsulta
                    
                End Select
                
            End If
                
        Case 1      'caso de IdCliente
            KeyAscii = itEntero(KeyAscii)
            
        Case 2, 3, 4    'caso de Sucursal, Razon Social, Observaciones
            KeyAscii = itString(KeyAscii)
       
        Case 5      'Caso de Clave de Producto
            If KeyAscii = "13" Then
                TxtDatos_Validate 5, False
                '''TxtDatos(8).SetFocus
            End If
            KeyAscii = itEntero(KeyAscii)

        Case 6      'Caso de Descripcion de Producto

        Case 7      'Caso de Existencia de Producto

        Case 8      'Caso de Cantidad de Producto
            If KeyAscii = "13" Then
                
                Dim Faltante As Double
                              
                Select Case vAccionConsigna
                    
                    Case ctEditaConsignaSurtido     'caso de registro de entrega de consigna
                    
                        ValFaltante = False
                        
                        If TxtDatos(8).Text <> "" Then
                            Faltante = CantidadSurtida - CDbl(TxtDatos(8).Text) - Venta - Obsequios - DevolucionBuena - DevolucionMala - ConsignasPendientes + ConsignaActual
                            If FormatNumber(Faltante, 4, 0) < 0 Then
                                ValFaltante = False
                                MsgBox "¡Existencias insuficientes! Verifique el registro de Ventas, Devoluciones y Obsequios.", vbInformation + vbOKOnly, App.Title
                                TxtDatos(8).Text = ""
                                '''Faltante = CDbl(TxtCargaD.Text) - CDbl(TxtVentaD.Text) - CDbl(TxtObsequiosD.Text) - CDbl(TxtBuenaD.Text) - CDbl(TxtMalaD.Text)
                                ''TxtDatos(7).Text = Faltante
                                TxtDatos(8).SetFocus
                            Else
                                ValFaltante = True
                                TxtDatos(7).Text = FormatNumber(Faltante, 4, 0)
                            End If
                        End If
                        
                        If ValFaltante Then
                            
                            'agrega o actualiza la cantidad del surtido de la consigna, se debe considerar el precio de venta al cliente
                            StrCmd = "execute up_ConsignasDetalle " & IdCedis & "," & IdCliente & "," & _
                                                        IdRutaEntrega & "," & IdSurtidoEntrega & "," & _
                                                        IdConsigna & "," & IdProducto & "," & CDbl(TxtDatos(8).Text) & ",0,1"
                            If Rs.State Then Rs.Close
                            Rs.Open StrCmd, Cnn
                            
                            '''MsgBox "se actualiza el producto en registro"
                            TxtDatos(5).Text = ""
                            TxtDatos(6).Text = ""
                            TxtDatos(7).Text = ""
                            TxtDatos(8).Text = ""
                            TxtDatos(5).SetFocus
                        
                            'carga la lista de productos para la consigna
                            PreparaDatos ctProductosRegistro
                        
                        End If
                                        
                    Case ctDevolverConsigna         'caso de registro de devolucion de consigna
                
                        ValFaltante = False
                        
                        If TxtDatos(8).Text <> "" Then
                            Faltante = CantidadSurtida - CDbl(TxtDatos(8).Text)
                            If FormatNumber(Faltante, 4, 0) < 0 Then
                                ValFaltante = False
                                MsgBox "¡Existencias insuficientes! Verifique el registro de la Consigna.", vbInformation + vbOKOnly, App.Title
                                TxtDatos(8).Text = ""
                                '''Faltante = CDbl(TxtCargaD.Text) - CDbl(TxtVentaD.Text) - CDbl(TxtObsequiosD.Text) - CDbl(TxtBuenaD.Text) - CDbl(TxtMalaD.Text)
                                TxtDatos(7).Text = Faltante
                                TxtDatos(8).SetFocus
                            Else
                                ValFaltante = True
                                TxtDatos(7).Text = FormatNumber(Faltante, 4, 0)
                            End If
                        End If
                        
                        If ValFaltante Then
                            
                            'actualiza la cantidad de la devolucion de la consigna
                            StrCmd = "execute up_ConsignasDetalle " & IdCedis & "," & IdCliente & "," & _
                                                        IdRutaDevolucion & "," & IdSurtidoDevolucion & "," & _
                                                        IdConsigna & "," & IdProducto & ",0," & CDbl(TxtDatos(8).Text) & ",2"
                            If Rs.State Then Rs.Close
                            Rs.Open StrCmd, Cnn
                            
                            'MsgBox "se actualiza el producto en devolucion"
                            TxtDatos(5).Text = ""
                            TxtDatos(6).Text = ""
                            TxtDatos(7).Text = ""
                            TxtDatos(8).Text = ""
                            TxtDatos(5).SetFocus
                        
                            'carga la lista de productos para la devolucion
                            PreparaDatos ctProductosDevolucion
                        
                        End If
                                
                End Select
                
            End If
            
            If Dec Then
                KeyAscii = itDecimal(KeyAscii)
            Else
                KeyAscii = itEntero(KeyAscii)
            End If

    End Select

End Sub

Private Sub TxtDatos_Validate(Index As Integer, Cancel As Boolean)

    Select Case Index
        
        Case 5      'Caso de Clave de Producto
        
            Dim IdMov As Long
            
            
            Dec = False
            Opc = 1
            
            If Trim(TxtDatos(5).Text) <> "" Then
            
                Select Case vAccionConsigna
                    
                    Case ctEditaConsignaSurtido     'caso de registro de entrega de consigna
                    
                        'checar el sig query, para que solo tome el surtido y devoluciones originales de
                        'la ruta ruta y no tome encuenta lo que ya se capturo en consignas
                        
                        StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & _
                                "', " & IdSurtidoConsigna & ", " & Trim(TxtDatos(5).Text) & ", 15"
                        If Rs.State Then Rs.Close
                        Rs.Open StrCmd, Cnn
                        If Rs.EOF Then
                            MsgBox "¡ El producto " & Trim(TxtDatos(5).Text) & " no fue registrado en la carga de la Ruta !", vbInformation + vbOKOnly, App.Title
                            TxtDatos(5).SetFocus
                            Exit Sub
                        Else
                            IdProducto = Trim(Rs.Fields(1))
                            TxtDatos(6).Text = Rs.Fields(2): DescProducto = Rs.Fields(2)
                            CantidadSurtida = FormatNumber(Rs.Fields(3), 3, vbTrue)
                            Venta = FormatNumber(Rs.Fields(4), 3, vbTrue)
                            Obsequios = Rs.Fields(7)
                            DevolucionBuena = Rs.Fields(5)
                            DevolucionMala = Rs.Fields(6)
                            Existencias = FormatNumber(Rs.Fields(8), 3, vbTrue)
                            ConsignasPendientes = Rs.Fields(15)
                            TxtDatos(7).Text = Existencias
        
                            Dec = IIf(Rs.Fields(13) = 1, True, False)
                            '''IdFamiliaRejas = CDbl(Rs.Fields(14))
                            TxtDatos(8).SetFocus
                        End If
                    
                        StrCmd = "execute sel_ConsignasDetalle " & IdCedis & ", " & IdConsigna & ", " & Trim(TxtDatos(5).Text) & ", 2"
                        If Rs.State Then Rs.Close
                        Rs.Open StrCmd, Cnn
                        If Not Rs.EOF Then
                            Existencias = FormatNumber((CDbl(Existencias) + Rs.Fields(3)), 3, vbTrue)
                            ConsignaActual = FormatNumber(Rs.Fields(3), 3, vbTrue)
                            TxtDatos(7).Text = Existencias
                        End If
                        
                    Case ctDevolverConsigna         'caso de registro de devolucion de consigna
                    
                        'validar el registro del producto en la consigna
                        StrCmd = "execute sel_ConsignasDetalle " & IdCedis & ", " & IdConsigna & ", " & Trim(TxtDatos(5).Text) & ", 2"
                        If Rs.State Then Rs.Close
                        Rs.Open StrCmd, Cnn
                        If Rs.EOF Then
                            MsgBox "¡ El producto " & Trim(TxtDatos(5).Text) & " no fue registrado en la consigna !", vbInformation + vbOKOnly, App.Title
                            TxtDatos(5).SetFocus
                            Exit Sub
                        Else
                            IdProducto = Rs.Fields("IdProducto")
                            TxtDatos(6).Text = Rs.Fields("Producto"): DescProducto = Rs.Fields("Producto")
                            CantidadSurtida = FormatNumber(Rs.Fields("Surtido"), 3, vbTrue)
                            Venta = FormatNumber(Rs.Fields("Venta"), 3, vbTrue)
                            Obsequios = 0
                            DevolucionBuena = Rs.Fields("Devolucion")
                            DevolucionMala = 0
                            Existencias = FormatNumber(Rs.Fields("Existencias"), 3, vbTrue)
                            TxtDatos(7).Text = Existencias
        
                            Dec = IIf(Rs.Fields("Decimales") = 1, True, False)
                            '''IdFamiliaRejas = CDbl(Rs.Fields(14))
                            TxtDatos(8).SetFocus
                        End If
                    
                End Select
            
            Else
            
                TxtDatos(6).Text = "": TxtDatos(7).Text = "": TxtDatos(8).Text = 0
                
            End If
            
        Case 8      'Caso de Cantidad de Producto
            If Dec Then
                TxtDatos(8).Text = CStr(itFlotante(TxtDatos(8).Text))
                If Trim(TxtDatos(8).Text) = "0" Then Exit Sub
            End If

    End Select

End Sub


