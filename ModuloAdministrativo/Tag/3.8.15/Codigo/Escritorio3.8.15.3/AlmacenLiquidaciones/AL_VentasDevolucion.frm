VERSION 5.00
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form AL_VentasDevolucion 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Devoluciones de Venta"
   ClientHeight    =   7440
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   11520
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
   ScaleHeight     =   7440
   ScaleWidth      =   11520
   ShowInTaskbar   =   0   'False
   Begin TabDlg.SSTab SSTab 
      Height          =   7215
      Left            =   120
      TabIndex        =   10
      Top             =   120
      Width           =   11295
      _ExtentX        =   19923
      _ExtentY        =   12726
      _Version        =   393216
      Tabs            =   2
      TabHeight       =   520
      BackColor       =   16777215
      TabCaption(0)   =   "&Seleccionar Venta"
      TabPicture(0)   =   "AL_VentasDevolucion.frx":0000
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "LblOpt(6)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "FrmOpt(2)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).ControlCount=   2
      TabCaption(1)   =   "&Detalle de la Devolución"
      TabPicture(1)   =   "AL_VentasDevolucion.frx":001C
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "LblOpt(0)"
      Tab(1).Control(1)=   "FrmOpt(3)"
      Tab(1).ControlCount=   2
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
         Height          =   6870
         Index           =   3
         Left            =   -75000
         TabIndex        =   19
         Top             =   345
         Width           =   11295
         Begin VB.Frame Frame5 
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
            Height          =   750
            Left            =   8520
            TabIndex        =   23
            Top             =   2040
            Visible         =   0   'False
            Width           =   2655
            Begin VB.Label Label19 
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
               Left            =   180
               TabIndex        =   25
               Top             =   240
               Width           =   450
            End
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
               Left            =   855
               TabIndex        =   24
               Top             =   240
               Width           =   1635
            End
         End
         Begin VB.Frame Frame3 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Selecciona el Folio de Devolución"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000000&
            Height          =   2055
            Left            =   120
            TabIndex        =   34
            Top             =   720
            Width           =   8295
            Begin VB.CommandButton btnImprimeC 
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
               Left            =   6480
               Picture         =   "AL_VentasDevolucion.frx":0038
               Style           =   1  'Graphical
               TabIndex        =   38
               Top             =   1440
               Width           =   1695
            End
            Begin VB.CommandButton btnNueva 
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
               Left            =   6480
               Picture         =   "AL_VentasDevolucion.frx":0753
               Style           =   1  'Graphical
               TabIndex        =   36
               Top             =   240
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
               Left            =   6480
               Picture         =   "AL_VentasDevolucion.frx":0DE1
               Style           =   1  'Graphical
               TabIndex        =   35
               Top             =   840
               Width           =   1695
            End
            Begin MSComctlLib.ListView LstFoliosDevolucion 
               Height          =   1695
               Left            =   120
               TabIndex        =   37
               Top             =   240
               Width           =   6255
               _ExtentX        =   11033
               _ExtentY        =   2990
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
         Begin VB.Frame FrmOpt 
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
            Height          =   3975
            Index           =   0
            Left            =   120
            TabIndex        =   22
            Top             =   2760
            Width           =   11055
            Begin VB.TextBox TxtDevolucion 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   7440
               MaxLength       =   8
               TabIndex        =   45
               Text            =   "0"
               Top             =   480
               Width           =   975
            End
            Begin VB.TextBox TxtCantidad 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   6360
               Locked          =   -1  'True
               MaxLength       =   8
               TabIndex        =   44
               Text            =   "0"
               Top             =   480
               Width           =   975
            End
            Begin VB.TextBox TxtIdProdD 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   120
               MaxLength       =   8
               TabIndex        =   43
               Top             =   480
               Width           =   975
            End
            Begin VB.TextBox TxtOtrasDev 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   8520
               Locked          =   -1  'True
               MaxLength       =   8
               TabIndex        =   42
               Text            =   "0"
               Top             =   480
               Width           =   975
            End
            Begin VB.TextBox TxtTotalDev 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   9600
               Locked          =   -1  'True
               MaxLength       =   8
               TabIndex        =   40
               Text            =   "0"
               Top             =   480
               Width           =   975
            End
            Begin VB.TextBox TxtDesc 
               Height          =   375
               Left            =   1200
               TabIndex        =   8
               Top             =   480
               Width           =   5055
            End
            Begin MSComctlLib.ListView LstPartidas 
               Height          =   2910
               Left            =   120
               TabIndex        =   26
               Top             =   960
               Width           =   10815
               _ExtentX        =   19076
               _ExtentY        =   5133
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
            Begin VB.Label Label7 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Cve."
               Height          =   255
               Left            =   240
               TabIndex        =   47
               Top             =   240
               Width           =   735
            End
            Begin VB.Label Label6 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Devolución"
               Height          =   255
               Left            =   7440
               TabIndex        =   46
               Top             =   240
               Width           =   975
            End
            Begin VB.Label Label5 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Total Dev."
               Height          =   255
               Left            =   9600
               TabIndex        =   41
               Top             =   240
               Width           =   975
            End
            Begin VB.Label Label4 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Otras Dev."
               Height          =   255
               Left            =   8520
               TabIndex        =   39
               Top             =   240
               Width           =   975
            End
            Begin VB.Label Label14 
               Alignment       =   1  'Right Justify
               BackColor       =   &H00FFFFFF&
               Caption         =   "Venta"
               Height          =   255
               Left            =   6240
               TabIndex        =   28
               Top             =   240
               Width           =   975
            End
            Begin VB.Label Label12 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Descripción del Producto"
               Height          =   255
               Left            =   1320
               TabIndex        =   27
               Top             =   240
               Width           =   3735
            End
         End
         Begin VB.Label LblSurtido 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Liquidación"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   12
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000080&
            Height          =   270
            Index           =   0
            Left            =   360
            TabIndex        =   20
            Top             =   240
            Width           =   1215
         End
         Begin VB.Line Line1 
            X1              =   120
            X2              =   11100
            Y1              =   600
            Y2              =   600
         End
      End
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
         Height          =   6870
         Index           =   2
         Left            =   0
         TabIndex        =   12
         Top             =   345
         Width           =   11295
         Begin VB.Frame Frame2 
            BackColor       =   &H00FFFFFF&
            Caption         =   "Datos de la Venta"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   9
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   3375
            Left            =   120
            TabIndex        =   14
            Top             =   720
            Width           =   11055
            Begin VB.CommandButton btnBuscar 
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
               Left            =   5760
               Picture         =   "AL_VentasDevolucion.frx":14F1
               Style           =   1  'Graphical
               TabIndex        =   7
               Top             =   1080
               Width           =   1575
            End
            Begin VB.TextBox TxtRazonSocial 
               Height          =   375
               Left            =   1200
               TabIndex        =   5
               Top             =   1200
               Width           =   2295
            End
            Begin VB.TextBox TxtRFC 
               Height          =   375
               Left            =   3600
               TabIndex        =   4
               Top             =   1200
               Width           =   1815
            End
            Begin VB.TextBox TxtIdCliente 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   120
               TabIndex        =   6
               Top             =   1200
               Width           =   975
            End
            Begin VB.TextBox TxtRuta 
               Alignment       =   1  'Right Justify
               Height          =   375
               Left            =   5520
               MaxLength       =   5
               TabIndex        =   2
               Top             =   360
               Width           =   975
            End
            Begin VB.ComboBox cmbTipoVenta 
               Height          =   360
               Left            =   7560
               Style           =   2  'Dropdown List
               TabIndex        =   3
               Top             =   360
               Width           =   1815
            End
            Begin MSComCtl2.DTPicker DTPFechaI 
               Height          =   375
               Left            =   960
               TabIndex        =   0
               Top             =   360
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
               Format          =   86966273
               CurrentDate     =   39376
            End
            Begin MSComCtl2.DTPicker DTPFechaF 
               Height          =   375
               Left            =   3360
               TabIndex        =   1
               Top             =   360
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
               Format          =   86966273
               CurrentDate     =   39376
            End
            Begin MSComctlLib.ListView LstClientes 
               Height          =   1575
               Left            =   120
               TabIndex        =   29
               Top             =   1680
               Width           =   9975
               _ExtentX        =   17595
               _ExtentY        =   2778
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
            Begin VB.Label Label22 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "Sucursal"
               Height          =   240
               Left            =   3600
               TabIndex        =   32
               Top             =   960
               Width           =   765
            End
            Begin VB.Label Label21 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Razón Social ( Cliente )"
               Height          =   255
               Left            =   1200
               TabIndex        =   31
               Top             =   960
               Width           =   2295
            End
            Begin VB.Label Label20 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "No. Cliente"
               Height          =   240
               Left            =   120
               TabIndex        =   30
               Top             =   960
               Width           =   960
            End
            Begin VB.Label Label3 
               BackColor       =   &H00FFFFFF&
               Caption         =   "F. Final"
               Height          =   255
               Left            =   2640
               TabIndex        =   18
               Top             =   480
               Width           =   735
            End
            Begin VB.Label Label2 
               BackColor       =   &H00FFFFFF&
               Caption         =   "F. Inicial"
               Height          =   255
               Left            =   120
               TabIndex        =   17
               Top             =   480
               Width           =   735
            End
            Begin VB.Label Label1 
               BackColor       =   &H00FFFFFF&
               Caption         =   "Ruta"
               Height          =   255
               Left            =   4920
               TabIndex        =   16
               Top             =   480
               Width           =   495
            End
            Begin VB.Label Label17 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               Caption         =   "T. Venta"
               Height          =   240
               Left            =   6720
               TabIndex        =   15
               Top             =   480
               Width           =   735
            End
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
            Height          =   2655
            Left            =   120
            TabIndex        =   13
            Top             =   4080
            Width           =   11055
            Begin MSComctlLib.ListView LstVentas 
               Height          =   2295
               Left            =   120
               TabIndex        =   9
               Top             =   240
               Width           =   10815
               _ExtentX        =   19076
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
         End
         Begin VB.Line Line2 
            X1              =   120
            X2              =   11100
            Y1              =   600
            Y2              =   600
         End
         Begin VB.Label LblSurtido 
            AutoSize        =   -1  'True
            BackColor       =   &H00FFFFFF&
            Caption         =   "Liquidación"
            BeginProperty Font 
               Name            =   "Arial"
               Size            =   12
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000080&
            Height          =   270
            Index           =   1
            Left            =   360
            TabIndex        =   33
            Top             =   240
            Width           =   1215
         End
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FFFFFF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Detalle de la Devolucion"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   0
         Left            =   -71250
         TabIndex        =   21
         Top             =   0
         Width           =   3795
      End
      Begin VB.Label LblOpt 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00FFFFFF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   "Seleccionar Venta"
         ForeColor       =   &H80000008&
         Height          =   375
         Index           =   6
         Left            =   0
         TabIndex        =   11
         Top             =   0
         Width           =   3780
      End
   End
End
Attribute VB_Name = "AL_VentasDevolucion"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim LstDVentas, LstDTipoVenta, LstDPartidas, LstDClientes, LstDDevoluciones, Cancela As Boolean, IdDevolucion, IdCliente, IdSucursal
Dim IdTipoVenta, Precio As Double, IdLista As Long, Iva As Double, Dec As Boolean, IdRutaPedido As Long, Dcto As Double, DctoImp As Double, DevAct
Dim IdSur, IdTipoV, Fol, Ser
Public IdSurD, IdTipoVD, FolD, SerD, TipoDevolucion
Public Ventas As Boolean

Private Sub btnBuscar_Click()
On Error Resume Next
    MuestraVentas
End Sub

Private Sub btnEliminar_Click()
On Error Resume Next

    If Not ValidaDiaySurtido(IdCedis, CLng(IdSurD), Fecha) Then Exit Sub
    If Not ValidaModulo("DEVVTAS", True) Then Exit Sub

    If Trim(TipoDevolucion) = "F" Then
        MsgBox "¡ No puedes Eliminar una Devoloución que ha sido creada por la Diferencia entre el Producto Facturado y el Entregado !", vbInformation + vbOKOnly, App.Title
        MousePointer = 0
        Exit Sub
    End If
    
    If Not IsEmpty(LstDDevoluciones) Then
        If MsgBox("¿ Está seguro que desea Eliminar la Devolución " & SerD & " - " & FolD & " ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
'                If MsgBox("La información se perderá. ¿ Desea continuar ?", vbQuestion + vbYesNo, App.Title) = vbYes Then
        MousePointer = 11
                StrCmd = "execute up_Ventas " & IdCedis & ", " & IdSurD & ", " & _
                        IdTipoVD & ", " & _
                        FolD & ", '" & SerD & "', '" & FormatDate(Fecha) & "', 0, 0, 3"
                If Rs.State Then Rs.Close
                Rs.Open StrCmd, Cnn
                
                'valida kardex antes de ...
                StrCmd = "exec up_ActualizaKardex " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurD & ", 2"
                If Rs.State Then Rs.Close
                Rs.Open StrCmd, Cnn
        
                StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", " & IdSurtido & ", 0, 0, " & IdTipoVD & ", '" & SerD & "', " & FolD & ", '" & _
                FormatDate(Fecha) & "', " & IdRuta & ", 0, '', 0, 'Eliminar', 'Liquidación " & IdSurtido & ", Devolución " & SerD & " " & FolD & "', 10"
                If Rs.State Then Rs.Close
                Rs.Open StrCmd, Cnn
        
        MousePointer = 0
                MuestraDevoluciones
                If IsEmpty(LstDDevoluciones) Then LstPartidas.ListItems.Clear
'                    MsgBox "¡ Factura Eliminada !", vbInformation + vbOKOnly, App.Title
'                End If
        End If
    End If

End Sub

Private Sub btnImprimeC_Click()
On Error GoTo ImpDev:
    
    If IsEmpty(LstDDevoluciones) Then Exit Sub
    
    With AL_RptFactura
        
        If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
        StrCmd = "execute sel_VentasDetalle " & IdCedis & ", " & IdSurD & ", " & IdTipoVD & ", " & FolD & ", 4"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        
        If Not RsC.EOF Then
            .LblControl.Caption = "Ced" & IdCedis & "Liq" & IdSurD & "Dcto" & SerD & "-" & FolD
            .object.DataSrc.DataSourceName = Cnn
            .object.DataSrc.Recordset = RsC
            .Printer.Orientation = ddOPortrait
            .Printer.PaperSize = 1
            .Show
        End If
    End With
    
No_ImpDev:
    MousePointer = 0
    Exit Sub
    
ImpDev:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbInformation + vbOKOnly, App.Title
    GoTo No_ImpDev:

End Sub

Private Sub btnNueva_Click()
On Error Resume Next

    If Not ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then Exit Sub
    If Not ValidaModulo("DEVVTAS", True) Then Exit Sub

    StrCmd = "execute sel_ExistenciaValidaDev " & IdCedis & ", " & IdSurD & ", " & IdTipoVD & ", " & FolD & ", " & IdSur & ", " & IdTipoV & ", " & Fol & ", 0, 0, 0, 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Rs.EOF Then
        MsgBox "¡ La Venta no tiene Producto Pendiente por Devolver !", vbInformation + vbOKOnly, App.Title
        Exit Sub
    End If

    If MsgBox("¿ Estás seguro que quieres dar de Alta una nueva Devolución para la " & LblSurtido(0).Caption & "?", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Sub

    StrCmd = "execute up_VentasDevoluciones " & IdCedis & ", " & IdSur & ", " & IdTipoV & ", " & Fol & ", " & IdSurtido & ", " & IdTipoVD & ", " & FolD & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
    MuestraDevoluciones
    LstFoliosDevolucion.SelectedItem.Index = LstFoliosDevolucion.ListItems.Count
    If Not IsEmpty(LstDDevoluciones) Then LstFoliosDevolucion_ItemClick LstFoliosDevolucion.SelectedItem
    
    StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", " & IdSurtido & ", 0, 0, " & IdTipoVD & ", '" & SerD & "', " & FolD & ", '" & _
    FormatDate(Fecha) & "', " & IdRuta & ", 0, '', 0, 'Insertar', 'Liquidación " & IdSurtido & ", Devolución " & LstFoliosDevolucion.ListItems.Item(LstFoliosDevolucion.ListItems.Count).ListSubItems(2) & " " & LstFoliosDevolucion.ListItems.Item(LstFoliosDevolucion.ListItems.Count).ListSubItems(3) & "', 10"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    
End Sub

Private Sub cmbTipoVenta_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then btnBuscar_Click
End Sub

Private Sub DTPFechaI_Change()
On Error Resume Next
    DTPFechaF.MinDate = DTPFechaI.Value
End Sub

Private Sub Form_Activate()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    LlenaComboVentas
    IdCliente = 0: IdSucursal = ""
    SSTab.Tab = 0
    If Ventas Then MuestraVentas
End Sub

Private Sub Form_Load()
On Error Resume Next
    If Not Cnn.State Then OpenConn Server, Db, UserDB, PasswordDB
    DTPFechaI.Value = Fecha - 1
    DTPFechaF.MinDate = Fecha - 1
    IdCliente = 0: IdSucursal = ""
    SSTab.Tab = 0
End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    If ValidaDiaySurtido(IdCedis, IdSurtido, Fecha) Then
        StrCmd = "exec up_ActualizaKardex " & IdCedis & ", '" & FormatDate(FechaSel) & "', " & IdSurtido & ", 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
    End If
    AL_Liquidacion.MuestraFacturas
End Sub

Private Sub LstClientes_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    If Not IsEmpty(LstDClientes) And LstClientes.ListItems.Count > 0 Then
        IdCliente = Trim(LstClientes.SelectedItem)
        IdSucursal = LstDClientes(10, LstClientes.SelectedItem.Index - 1)
    End If
End Sub

Private Sub LstFoliosDevolucion_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    If IsEmpty(LstDDevoluciones) Then Exit Sub
    IdSurD = LstDDevoluciones(1, LstFoliosDevolucion.SelectedItem.Index - 1)
    IdTipoVD = LstDDevoluciones(2, LstFoliosDevolucion.SelectedItem.Index - 1)
    FolD = LstDDevoluciones(4, LstFoliosDevolucion.SelectedItem.Index - 1)
    SerD = LstDDevoluciones(3, LstFoliosDevolucion.SelectedItem.Index - 1)
    TipoDevolucion = LstDDevoluciones(6, LstFoliosDevolucion.SelectedItem.Index - 1)
    MuestraDetalle
End Sub

Private Sub LstVentas_ItemClick(ByVal Item As MSComctlLib.ListItem)
On Error Resume Next
    If Not IsEmpty(LstVentas) Then
        IdSur = LstDVentas(1, LstVentas.SelectedItem.Index - 1)
        IdTipoV = LstDVentas(2, LstVentas.SelectedItem.Index - 1)
        Fol = LstDVentas(4, LstVentas.SelectedItem.Index - 1)
        Ser = LstDVentas(3, LstVentas.SelectedItem.Index - 1)
        IdCliente = LstDVentas(6, LstVentas.SelectedItem.Index - 1)
        IdSucursal = LstDVentas(14, LstVentas.SelectedItem.Index - 1)
        LblSurtido(0).Caption = "Venta de " & LstDVentas(5, LstVentas.SelectedItem.Index - 1) & " " & Ser & "-" & Format(Fol, "00000") & ""
    Else
        IdSur = 0: IdTipoV = 0: Fol = 0
        Exit Sub
    End If

End Sub

Private Sub SSTab_Click(PreviousTab As Integer)
On Error Resume Next
    If IsEmpty(IdSur) Then IdSur = 0
    If SSTab.Tab >= 1 And (IsEmpty(LstDVentas) Or IdSur = 0) Then
        MsgBox "¡ Selecciona una Venta para Devolución !", vbInformation + vbOKOnly, App.Title
        SSTab.Tab = 0
        Exit Sub
    End If
    
    Select Case SSTab.Tab
        Case 0:
            LlenaComboVentas
        Case 1:
            MuestraDevoluciones
            If Not IsEmpty(LstDDevoluciones) Then LstFoliosDevolucion_ItemClick LstFoliosDevolucion.SelectedItem
            TxtIdProdD.SetFocus
    End Select
End Sub

Private Sub TxtIdCliente_Change()
On Error Resume Next
    FiltraClientes 1
End Sub

Private Sub TxtIdCliente_GotFocus()
On Error Resume Next
    SelText TxtIdCliente
End Sub

Private Sub TxtIdCliente_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtIdProdD_Change()
On Error Resume Next
    TxtDesc.Text = "¡ Producto no econtrado !": TxtCantidad.Text = 0: TxtDevolucion.Text = 0: TxtOtrasDev.Text = 0: TxtTotalDev.Text = 0
End Sub

Private Sub TxtIdProdD_GotFocus()
On Error Resume Next
    SelText TxtIdProdD
End Sub

Private Sub TxtIdProdD_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = 13 Then
        If Trim(TxtIdProdD.Text) = "0" Then
            With AL_ProductosBusqueda
                .Left = Me.Left + 500
                .Top = Me.Top + 500
                .Opc = 9
                .Show
            End With
            Exit Sub
        End If
        ValidaProductoVenta
        TxtDevolucion.SetFocus
        Exit Sub
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtRazonSocial_Change()
On Error Resume Next
    TxtIdCliente.Text = ""
    FiltraClientes 1
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
    TxtIdCliente.Text = ""
    FiltraClientes 1
End Sub

Private Sub TxtRFC_GotFocus()
On Error Resume Next
    SelText TxtRFC
End Sub

Private Sub TxtRFC_KeyPress(KeyAscii As Integer)
On Error Resume Next
    KeyAscii = itString(KeyAscii)
End Sub

Sub LlenaComboVentas()
On Error Resume Next
    StrCmd = "execute sel_VentasTipo "
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDTipoVenta = GetDataCBL(Rs, cmbTipoVenta, "Tipo de Venta", "No existen Tipos de Venta definidos")
End Sub

Sub MuestraVentas()
On Error Resume Next
Dim IdTipoVenta
    If Ventas Then
        StrCmd = "execute sel_VentasDevolucion " & IdCedis & ", '19000101', '19000101', " & IdSurD & ", " & IdTipoVD & ", " & FolD & ", '', 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        LstDVentas = GetDataLVL(Rs, LstVentas, 3, 13, "0|1|0|1|0|7|7|7|7|0|0")
        LstVentas_ItemClick LstVentas.SelectedItem
        SSTab.Tab = 1
    Else
        If IsEmpty(IdCliente) Then
            IdCliente = 0: IdSucursal = ""
        End If
        If Trim(TxtRuta.Text) = "" Then TxtRuta.Text = "0"
        If cmbTipoVenta.ListIndex = 0 Then
            IdTipoVenta = 0
        Else
            IdTipoVenta = LstDTipoVenta(0, cmbTipoVenta.ListIndex - 1)
        End If
             
        StrCmd = "execute sel_VentasDevolucion " & IdCedis & ", '" & FormatDate(DTPFechaI.Value) & "', '" & FormatDate(DTPFechaF.Value) & "', " & TxtRuta.Text & ", " & IdTipoVenta & ", " & IdCliente & ", '" & IdSucursal & "', 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        LstDVentas = GetDataLVL(Rs, LstVentas, 3, 13, "0|1|0|1|0|7|7|7|7|0|0")
        'LstVentas_ItemClick LstVentas.SelectedItem
    End If
End Sub

Sub FiltraClientes(Opc As Integer)
On Error Resume Next
'    LblCliente(0).Caption = "": LblCliente(1).Caption = ""
    IdCliente = 0: IdSucursal = ""
    If Opc = 1 Then
        StrCmd = "execute sel_ClientesFacturas " & IdCedis & ",'" & IIf(Trim(TxtIdCliente.Text) = "", 0, Trim(TxtIdCliente.Text)) & "','" & Trim(TxtRFC.Text) & "','" & Trim(TxtRazonSocial.Text) & "', " & Opc
    Else
        StrCmd = "execute sel_ClientesFacturas " & IdCedis & ",'" & LstDVentas(9, LstVentas.SelectedItem.Index - 1) & "','','" & LstDVentas(17, LstVentas.SelectedItem.Index - 1) & "', " & Opc
    End If
    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
'Debug.Print StrCmd
    LstDClientes = GetDataLVL(RsC, LstClientes, 1, 4, "0|0|0|0")
End Sub

Private Sub TxtRuta_GotFocus()
On Error Resume Next
    SelText TxtRuta
End Sub

Private Sub TxtRuta_KeyPress(KeyAscii As Integer)
On Error Resume Next
    If KeyAscii = "13" Then
        cmbTipoVenta.SetFocus
        Exit Sub
    End If
    KeyAscii = itEntero(KeyAscii)
End Sub

Private Sub TxtRuta_Validate(Cancel As Boolean)
On Error Resume Next
    ValidaRutaVenta TxtRuta
End Sub

Sub ValidaRutaVenta(Txt As TextBox)
    If Trim(Txt.Text) = "" Then Txt.Text = "0"
    StrCmd = "execute sel_ExisteRuta " & IdCedis & ", " & Txt.Text
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Rs.EOF Then
        MsgBox "¡ La Ruta " & Txt.Text & " no existe !", vbInformation + vbOKOnly, App.Title
        Txt.Text = "0"
        Txt.SetFocus
        Exit Sub
    End If
End Sub

Private Sub TxtDevolucion_GotFocus()
On Error Resume Next
    SelText TxtDevolucion
End Sub

Private Sub TxtDevolucion_KeyPress(KeyAscii As Integer)
On Error Resume Next

    If KeyAscii = "13" Then
        
        If Not ValidaDiaySurtido(IdCedis, CLng(IdSurD), Fecha) Then Exit Sub
        If Not ValidaModulo("DEVVTAS", True) Then Exit Sub
        
        If Trim(TipoDevolucion) = "F" Then
            MsgBox "¡ No puedes Modificar una Devoloución que ha sido creada por la diferencia entre el Producto Facturado y el Entregado !", vbInformation + vbOKOnly, App.Title
            MousePointer = 0
            Exit Sub
        End If
        
        If Dec Then
            If KeyAscii <> "42" Then KeyAscii = itDecimal(KeyAscii)
        Else
            If KeyAscii <> "42" Then KeyAscii = itEntero(KeyAscii)
        End If
        
        If TxtIdProdD.Text = "0" Or TxtIdProdD.Text = "" Then
            TxtIdProdD.SetFocus
            Exit Sub
        End If
        
        If CDbl(TxtCantidad.Text) + DevAct - CDbl(TxtTotalDev.Text) - CDbl(TxtDevolucion.Text) < 0 Then
            MsgBox "¡ Sólo puedes Devolver el Total de Producto Registrado en la Venta !", vbInformation + vbOKOnly, App.Title
            TxtDevolucion.Text = 0: TxtIdProdD.SetFocus
            Exit Sub
        End If
            
        If Not ValidaInventario(TxtIdProdD) Then
            MsgBox "¡ No se puede aplicar la devolución por que ya existen ventas !", vbInformation + vbOKOnly, App.Title
            Exit Sub
        End If
            
        StrCmd = "execute up_VentasDetalle " & IdCedis & ", " & IdSurD & ", " & IdTipoVD & ", " & FolD & ", '" & SerD & "', '" & FormatDate(Fecha) & "', " & TxtIdProdD.Text & _
            ", " & CDbl(TxtDevolucion.Text) & ", " & Precio & ", " & Iva & ", 0, " & CDbl(Dcto) / 100 & ", " & CDbl(DctoImp) & ", 0, 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        StrCmd = "execute up_Bitacora '" & Usuario & "', " & IdCedis & ", " & IdSurtido & ", 0, 0, " & IdTipoVD & ", '" & SerD & "', " & FolD & ", '" & _
        FormatDate(Fecha) & "', " & IdRuta & ", 0, '', " & TxtIdProdD.Text & ", 'Actualizar', 'Liquidación " & IdSurtido & ", Devolución " & SerD & " " & FolD & ". Producto " & TxtIdProdD.Text & ", Cantidad " & CDbl(TxtDevolucion.Text) & ", Precio " & Precio & ", Iva" & Iva & ", Dcto. Porc. " & Dcto & "%, Dcto. Importe " & DctoImp & "', 10"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        TxtIdProdD.Text = "": TxtIdProdD.SetFocus
        
        MuestraDetalle
    End If

    If Dec Then
        If KeyAscii <> "42" Then KeyAscii = itDecimal(KeyAscii)
    Else
        If KeyAscii <> "42" Then KeyAscii = itEntero(KeyAscii)
    End If
End Sub

Sub ValidaProductoVenta()
On Error Resume Next
    If Trim(TxtIdProdD.Text) <> "" Then
        
        ' valido si el producto ya está registrado en la Venta y obtiene nuevos datos
        StrCmd = "execute sel_ExistenciaValidaDev " & IdCedis & ", " & IdSurD & ", " & IdTipoVD & ", " & FolD & ", " & IdSur & ", " & IdTipoV & ", " & Fol & ", " & TxtIdProdD.Text & ", 0, 0, 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            TxtDesc.Text = Rs.Fields(1)
            TxtCantidad.Text = FormatNumber(Rs.Fields(2), 3)
            TxtDevolucion.Text = FormatNumber(Rs.Fields(9), 3)
            TxtOtrasDev.Text = FormatNumber(Rs.Fields(10), 3)
            TxtTotalDev.Text = FormatNumber(Rs.Fields(11), 3)
            
            Precio = Rs.Fields(3)
            Iva = Rs.Fields(5)
            Dcto = Rs.Fields(7)
            DctoImp = Rs.Fields(8)
            DevAct = Rs.Fields(9)
            
            Dec = IIf(Rs.Fields(12) = 1, True, False)
        Else
            TxtDesc.Text = "¡ Producto no Encontado !"
            TxtCantidad.Text = 0
            TxtDevolucion.Text = 0: TxtOtrasDev.Text = 0: TxtTotalDev.Text = 0
            TxtIdProdD.Text = 0
            TxtIdProdD.SetFocus
            
            Precio = 0
            Iva = 0
            Dcto = 0
            DctoImp = 0
            DevAct = 0
            Dec = False
        End If
    Else
        TxtDesc.Text = "": TxtCantidad.Text = 0: TxtDevolucion.Text = 0: TxtOtrasDev.Text = 0: TxtTotalDev.Text = 0
    End If
    TxtDevolucion.SetFocus
End Sub

Sub MuestraDevoluciones()
On Error Resume Next
         
    If IsEmpty(IdSurD) Then
        IdSurD = 0: IdTipoVD = 0: FolD = 0: SerD = ""
    End If
         
    StrCmd = "execute sel_VentasDevoluciones " & IdCedis & ", " & IdSur & ", " & IdTipoV & ", " & Fol & ", " & IdSurD & ", " & IdTipoVD & ", " & FolD & ", 1"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDDevoluciones = GetDataLVL(Rs, LstFoliosDevolucion, 1, 4, "0|0|0|0")
End Sub

Sub MuestraDetalle()
On Error Resume Next
         
    If IsEmpty(IdSurD) Then
        IdSurD = 0: IdTipoVD = 0: FolD = 0: SerD = ""
    End If
    
    If IsEmpty(LstDDevoluciones) Then
        LstPartidas.ListItems.Clear
        Exit Sub
    End If
         
    StrCmd = "execute sel_VentasDevoluciones " & IdCedis & ", " & IdSur & ", " & IdTipoV & ", " & Fol & ", " & IdSurD & ", " & IdTipoVD & ", " & FolD & ", 2"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    LstDPartidas = GetDataLVL(Rs, LstPartidas, 4, 15, "1|0|3|3|3|3|7|7|7|7|7|7")
End Sub

Function ValidaInventario(IdProducto As Integer) As Boolean
    ValidaInventario = False
    Dim RsTmp As New ADODB.Recordset, TmpRecs As Variant, i As Integer
    StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSur & ", " & IdProducto & ", 17"
    If RsTmp.State Then RsTmp.Close
    RsTmp.Open StrCmd, Cnn
    'devolucion menor a la anterior, checar ventas
    If TxtDevolucion < TxtTotalDev Then
        If (RsTmp("Inv. Final") - (TxtTotalDev - TxtDevolucion)) < 0 Then
            ValidaInventario = False
        Else
            ValidaInventario = True
        End If
    Else
        ValidaInventario = True
    End If
End Function
