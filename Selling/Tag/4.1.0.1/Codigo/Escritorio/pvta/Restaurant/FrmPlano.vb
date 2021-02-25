Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Collections

Public Class FrmPlano
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents LblFechaHora As System.Windows.Forms.Label
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents BtnActualizar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnIzqSub As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDerSub As Janus.Windows.EditControls.UIButton
    Friend WithEvents pnlPisos As System.Windows.Forms.Panel
    Friend WithEvents grpMesas As System.Windows.Forms.GroupBox
    Friend WithEvents btnUltProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnIniProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAntProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSigProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BtnUnir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnMover As Janus.Windows.EditControls.UIButton
    Friend WithEvents pnlMesas As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPlano))
        Me.LblFechaHora = New System.Windows.Forms.Label()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.BtnActualizar = New Janus.Windows.EditControls.UIButton()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnIzqSub = New Janus.Windows.EditControls.UIButton()
        Me.btnDerSub = New Janus.Windows.EditControls.UIButton()
        Me.pnlPisos = New System.Windows.Forms.Panel()
        Me.grpMesas = New System.Windows.Forms.GroupBox()
        Me.BtnUnir = New Janus.Windows.EditControls.UIButton()
        Me.BtnMover = New Janus.Windows.EditControls.UIButton()
        Me.btnUltProd = New Janus.Windows.EditControls.UIButton()
        Me.btnIniProd = New Janus.Windows.EditControls.UIButton()
        Me.btnAntProd = New Janus.Windows.EditControls.UIButton()
        Me.btnSigProd = New Janus.Windows.EditControls.UIButton()
        Me.pnlMesas = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.grpMesas.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblFechaHora
        '
        Me.LblFechaHora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFechaHora.BackColor = System.Drawing.Color.Transparent
        Me.LblFechaHora.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LblFechaHora.ForeColor = System.Drawing.Color.Black
        Me.LblFechaHora.Location = New System.Drawing.Point(797, 4)
        Me.LblFechaHora.Name = "LblFechaHora"
        Me.LblFechaHora.Size = New System.Drawing.Size(225, 34)
        Me.LblFechaHora.TabIndex = 11
        Me.LblFechaHora.Text = "Lunes, 31 Marzo"
        Me.LblFechaHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnActualizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnActualizar.Icon = CType(resources.GetObject("BtnActualizar.Icon"), System.Drawing.Icon)
        Me.BtnActualizar.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnActualizar.Location = New System.Drawing.Point(881, 12)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(64, 75)
        Me.BtnActualizar.TabIndex = 49
        Me.BtnActualizar.ToolTipText = "Actualizar Mesas"
        Me.BtnActualizar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.BtnSalir.Location = New System.Drawing.Point(948, 11)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnSalir.Office2007CustomColor = System.Drawing.Color.Red
        Me.BtnSalir.Size = New System.Drawing.Size(64, 75)
        Me.BtnSalir.TabIndex = 52
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.ToolTipText = "Cerrar el punto de venta"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnIzqSub)
        Me.GroupBox2.Controls.Add(Me.btnDerSub)
        Me.GroupBox2.Controls.Add(Me.BtnSalir)
        Me.GroupBox2.Controls.Add(Me.pnlPisos)
        Me.GroupBox2.Controls.Add(Me.BtnActualizar)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 40)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1015, 92)
        Me.GroupBox2.TabIndex = 68
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pisos"
        '
        'btnIzqSub
        '
        Me.btnIzqSub.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIzqSub.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIzqSub.Icon = CType(resources.GetObject("btnIzqSub.Icon"), System.Drawing.Icon)
        Me.btnIzqSub.ImageVerticalAlignment = Janus.Windows.EditControls.ImageVerticalAlignment.TopOfText
        Me.btnIzqSub.Location = New System.Drawing.Point(2, 11)
        Me.btnIzqSub.Name = "btnIzqSub"
        Me.btnIzqSub.Size = New System.Drawing.Size(52, 77)
        Me.btnIzqSub.TabIndex = 61
        Me.btnIzqSub.ToolTipText = "Anterior"
        Me.btnIzqSub.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnDerSub
        '
        Me.btnDerSub.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDerSub.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDerSub.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDerSub.Icon = CType(resources.GetObject("btnDerSub.Icon"), System.Drawing.Icon)
        Me.btnDerSub.Location = New System.Drawing.Point(827, 11)
        Me.btnDerSub.Name = "btnDerSub"
        Me.btnDerSub.Size = New System.Drawing.Size(50, 77)
        Me.btnDerSub.TabIndex = 60
        Me.btnDerSub.ToolTipText = "Siguiente"
        Me.btnDerSub.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'pnlPisos
        '
        Me.pnlPisos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPisos.AutoScroll = True
        Me.pnlPisos.Location = New System.Drawing.Point(57, 11)
        Me.pnlPisos.Name = "pnlPisos"
        Me.pnlPisos.Size = New System.Drawing.Size(766, 77)
        Me.pnlPisos.TabIndex = 0
        '
        'grpMesas
        '
        Me.grpMesas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMesas.Controls.Add(Me.BtnUnir)
        Me.grpMesas.Controls.Add(Me.BtnMover)
        Me.grpMesas.Controls.Add(Me.btnUltProd)
        Me.grpMesas.Controls.Add(Me.btnIniProd)
        Me.grpMesas.Controls.Add(Me.btnAntProd)
        Me.grpMesas.Controls.Add(Me.btnSigProd)
        Me.grpMesas.Controls.Add(Me.pnlMesas)
        Me.grpMesas.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.grpMesas.Location = New System.Drawing.Point(3, 137)
        Me.grpMesas.Name = "grpMesas"
        Me.grpMesas.Size = New System.Drawing.Size(1016, 574)
        Me.grpMesas.TabIndex = 69
        Me.grpMesas.TabStop = False
        Me.grpMesas.Text = "Mesas"
        '
        'BtnUnir
        '
        Me.BtnUnir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnUnir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnUnir.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.BtnUnir.Location = New System.Drawing.Point(952, 318)
        Me.BtnUnir.Name = "BtnUnir"
        Me.BtnUnir.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnUnir.Office2007CustomColor = System.Drawing.Color.Gold
        Me.BtnUnir.Size = New System.Drawing.Size(61, 56)
        Me.BtnUnir.TabIndex = 65
        Me.BtnUnir.Text = "Unir"
        Me.BtnUnir.ToolTipText = "Unir Mesas"
        Me.BtnUnir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnMover
        '
        Me.BtnMover.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMover.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnMover.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.BtnMover.Location = New System.Drawing.Point(952, 258)
        Me.BtnMover.Name = "BtnMover"
        Me.BtnMover.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnMover.Office2007CustomColor = System.Drawing.Color.Green
        Me.BtnMover.Size = New System.Drawing.Size(61, 56)
        Me.BtnMover.TabIndex = 64
        Me.BtnMover.Text = "Mover"
        Me.BtnMover.ToolTipText = "Cambiar cuenta de Mesa"
        Me.BtnMover.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnUltProd
        '
        Me.btnUltProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUltProd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUltProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUltProd.Icon = CType(resources.GetObject("btnUltProd.Icon"), System.Drawing.Icon)
        Me.btnUltProd.Location = New System.Drawing.Point(952, 199)
        Me.btnUltProd.Name = "btnUltProd"
        Me.btnUltProd.Size = New System.Drawing.Size(61, 55)
        Me.btnUltProd.TabIndex = 63
        Me.btnUltProd.ToolTipText = "Ir al Ultimo"
        Me.btnUltProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnIniProd
        '
        Me.btnIniProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIniProd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIniProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIniProd.Icon = CType(resources.GetObject("btnIniProd.Icon"), System.Drawing.Icon)
        Me.btnIniProd.Location = New System.Drawing.Point(952, 20)
        Me.btnIniProd.Name = "btnIniProd"
        Me.btnIniProd.Size = New System.Drawing.Size(61, 56)
        Me.btnIniProd.TabIndex = 62
        Me.btnIniProd.ToolTipText = "Ir al Primero"
        Me.btnIniProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnAntProd
        '
        Me.btnAntProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAntProd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAntProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAntProd.Icon = CType(resources.GetObject("btnAntProd.Icon"), System.Drawing.Icon)
        Me.btnAntProd.ImageVerticalAlignment = Janus.Windows.EditControls.ImageVerticalAlignment.TopOfText
        Me.btnAntProd.Location = New System.Drawing.Point(952, 80)
        Me.btnAntProd.Name = "btnAntProd"
        Me.btnAntProd.Size = New System.Drawing.Size(61, 55)
        Me.btnAntProd.TabIndex = 61
        Me.btnAntProd.ToolTipText = "Anterior"
        Me.btnAntProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnSigProd
        '
        Me.btnSigProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSigProd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSigProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSigProd.Icon = CType(resources.GetObject("btnSigProd.Icon"), System.Drawing.Icon)
        Me.btnSigProd.Location = New System.Drawing.Point(952, 139)
        Me.btnSigProd.Name = "btnSigProd"
        Me.btnSigProd.Size = New System.Drawing.Size(61, 56)
        Me.btnSigProd.TabIndex = 60
        Me.btnSigProd.ToolTipText = "Siguiente"
        Me.btnSigProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'pnlMesas
        '
        Me.pnlMesas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMesas.AutoScroll = True
        Me.pnlMesas.Location = New System.Drawing.Point(6, 20)
        Me.pnlMesas.Name = "pnlMesas"
        Me.pnlMesas.Size = New System.Drawing.Size(940, 549)
        Me.pnlMesas.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.MintCream
        Me.Panel5.Controls.Add(Me.LblTitulo)
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Location = New System.Drawing.Point(4, 6)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(733, 32)
        Me.Panel5.TabIndex = 70
        '
        'LblTitulo
        '
        Me.LblTitulo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitulo.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblTitulo.Location = New System.Drawing.Point(3, 5)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(367, 21)
        Me.LblTitulo.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label16.Location = New System.Drawing.Point(447, 7)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(144, 15)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "<Ctrl+R> para retiro de Caja"
        '
        'FrmPlano
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(1024, 745)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.grpMesas)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LblFechaHora)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmPlano"
        Me.Text = "Punto de Venta"
        Me.GroupBox2.ResumeLayout(False)
        Me.grpMesas.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private PISClave As String = ""
    Private Mesa As String = ""
    Private Piso As String = ""
    Private CLAClave As Integer
    Private cMesaOcupada As Integer
    Private cMesaDisponible As Integer
    Private cMesaSucia As Integer
    Private ImgDisponible As System.Drawing.Image
    Private ImgOcupada As System.Drawing.Image

    Public CorteDetallado As Integer = 0
    Public iColorMesa As Integer
    Public ActivaDevolucion As Boolean

    Public SUCClave As String
    Public Frase As String

    Private iAvanceMenu, iAvanceSubmenu, iAvanceProductos As Integer


    Public NombreBarraCaliente As String
    Public NombreBarraFria As String


    Public ALMClave As String 'Clave del Almacen
    Public PDVClave As String 'Clave de Punto de Venta
    Public Referencia As String 'Referencia de Punto de Venta
    Public PuntodeVenta As String 'Descripcion de Punto de Venta
    Public Supervisor As String 'Supervisor de Punto de Venta

    Private Autoriza As String

    Public ValidaInventario As Boolean = False

    Private MaxEfectivo As Double 'Maximo Efectivo en Caja
    Private MaxCheques As Double 'Maximo Cheques en Caja
    Private MaxVales As Double 'Maximo Vales en Caja

    Private CajaClave As String
    Private CajaTICDevolucion As String

    Private CajaNombre As String
    Private Manual As Integer
    Private Cajon As Boolean = False

    Public PrintGeneric As Boolean
    Public Impresora As String 'Impresora de Tickets
    Public Ticket As String 'Plantilla de Ticket
    Public NumCopias As Integer 'Determina el numero de copias a imprimir para documentos nuevos
    Public Caja As Boolean ' Activa al punto de venta con su caja
    Public CAJClave As String 'Clave de la Caja
    Public Redondeo As Boolean 'Aplica programa de redondeo
    Public CambiaPrecio As Boolean 'Muestra pantalla para elegir precio

    Public Agotamiento As Boolean 'Notificar agotamiento de productos
    Public ImpRedondeo As Double 'Importe del redondeo
    Public Url_Redondeo As String 'Url de imagen de redondeo
    Public PorcMaxDesc As Double 'Porcentaje Maximo descuento del vendedor
    Public USRCambiaPrecio As Boolean 'Si se le permite cambiar precios al vendedor

    Public CajeroClave As String ' Identificador del Cajero
    Public CajeroNombre As String ' Nombre del Cajero
    Public MeseroClave As String ' Identificador del Cajero
    Public MeseroNombre As String

    Public CTEClaveInicial As String 'Identificador de Cliente Inicial
    Public CTENombreInicial As String 'Nombre de Cliente Inicial
    Public CTEClaveActual As String 'Identificador de Cliente Actual
    Public CTENombreActual As String 'Nombre de Cliente Actual
    Public Folio As Integer = -1
    Public ComandaNueva As Boolean = True
    Public GeneraMovSalida As Boolean = False
    Public SolicitaVendedor As Boolean 'Solicita vendedor al crear venta

    Public CMDClave As String 'Identificador de la Comanda

    Public SaldoVenta As Double = 0.0
    Public TotalAhorro As Double = 0.0
    Public TotalArticulos As Double = 0.0
    Public TotalPuntos As Double = 0.0
    Public TotalVenta As Double = 0.0
    Public ComandaCerrada As Boolean = True
    Public ListaPrecio As String
    Public TImpuesto As Integer
    Public DescuentoCliente As Integer
    Public PorcDescCliente As Double
    Public TotalRecibido As Double = 0.0
    Public TotalCambio As Double = 0.0
    Public FormaPago As Integer
    Public TipoDesCte As Integer
    Public DESClave As String

    Public CambiarCliente As Boolean = False
    Private Cantidad As Double = 1
    Private PorcImpProducto As Double

    'Private CreditoDisponible As Double = 0.0

    Private sGTIN As String = ""

    'Private NotaCreditos As String = ""

    Public sFolio As String = "-"

    Private MonedaCambio As String
    Private Moneda As String
    Private MonedaRef As String
    Private TipoCambio As Double
    Public dtComandaDetalle As DataTable
    Private bCierreApertura As Boolean = False


    Private Sub llenaPisos(ByVal sSUCClave As String)

        pnlPisos.Controls.Clear()

        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim dr As System.Data.SqlClient.SqlDataReader
        Dim myCommand As System.Data.SqlClient.SqlCommand


        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MessageBox.Show("No se puede conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        myCommand = New System.Data.SqlClient.SqlCommand("sp_obtener_pisos", Cnx)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.CommandTimeout = ModPOS.myTimeOut
        myCommand.Parameters.Add("@SUCClave", SqlDbType.VarChar).Value = sSUCClave

        dr = myCommand.ExecuteReader()

        Dim x, y As Integer
        x = 2
        y = 2



        While dr.Read
            Dim btn As Janus.Windows.EditControls.UIButton
            btn = New Janus.Windows.EditControls.UIButton
            btn.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
            btn.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
            btn.Office2007CustomColor = System.Drawing.Color.FromArgb(CInt(dr("ColorPiso")))
            btn.Name = dr("PISClave")
            btn.Text = dr("Descripcion")
            btn.ToolTipText = dr("Clave")
            btn.Width = 90
            btn.Height = 60
            btn.Location = New Point(x, y)
            x += 95
            pnlPisos.Controls.Add(btn)
            AddHandler btn.Click, AddressOf Piso_Click
        End While

        myCommand.Dispose()
        dr.Close()

        pnlPisos.HorizontalScroll.Enabled = False
        pnlPisos.HorizontalScroll.Visible = False

        If pnlPisos.Controls.Count > 0 Then
            Piso = pnlPisos.Controls.Item(0).Text
            grpMesas.Text = Piso
            llenaMesas(pnlPisos.Controls.Item(0).Name)
        End If

        iAvanceSubmenu = pnlPisos.HorizontalScroll.LargeChange

    End Sub

    Private Sub llenaMesas(ByVal sPISClave As String)

        PISClave = sPISClave

        Dim cColorPiso As Integer
        Dim dtPiso As DataTable
        dtPiso = ModPOS.Recupera_Tabla("sp_recupera_piso", "@Piso", sPISClave)
        cMesaOcupada = dtPiso.Rows(0)("cMesaOcupada")
        cMesaDisponible = dtPiso.Rows(0)("cMesaDisponible")
        cMesaSucia = dtPiso.Rows(0)("cMesaSucia")
        cColorPiso = dtPiso.Rows(0)("ColorPiso")

        If Not dtPiso.Rows(0)("ImagenDisponible") Is System.DBNull.Value Then
            ImgDisponible = ModPOS.RecuperaIcono(CType(dtPiso.Rows(0)("ImagenDisponible"), Byte()))
        End If

        If Not dtPiso.Rows(0)("ImagenOcupada") Is System.DBNull.Value Then
            ImgOcupada = ModPOS.RecuperaIcono(CType(dtPiso.Rows(0)("ImagenOcupada"), Byte()))
        End If


        dtPiso.Dispose()

        Me.pnlMesas.BackColor = System.Drawing.Color.FromArgb(cColorPiso)

        pnlMesas.Controls.Clear()

        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim dr As System.Data.SqlClient.SqlDataReader
        Dim myCommand As System.Data.SqlClient.SqlCommand


        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MessageBox.Show("No se puede conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        myCommand = New System.Data.SqlClient.SqlCommand("sp_muestra_mesas", Cnx)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.CommandTimeout = ModPOS.myTimeOut
        myCommand.Parameters.Add("@PISClave", SqlDbType.VarChar).Value = sPISClave

        dr = myCommand.ExecuteReader()

        Dim x, y As Integer
        x = 2
        y = 2

        Dim MaxCol, Col As Integer

        MaxCol = Math.Truncate(pnlMesas.Width / 95)


        While dr.Read

            If Col = MaxCol Then
                y += 65
                x = 2
                Col = 0
            End If
            Dim btn As BtnMesa
            btn = New BtnMesa
            btn.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
            btn.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
            btn.ImageSize = BtnActualizar.ImageSize

            Select Case CInt(dr("iEstado"))
                Case 1
                    btn.Office2007CustomColor = System.Drawing.Color.FromArgb(cMesaDisponible)
                    btn.Image = ImgDisponible
                Case 2
                    btn.Office2007CustomColor = System.Drawing.Color.FromArgb(cMesaOcupada)
                    btn.Image = ImgOcupada
                Case 3
                    btn.Office2007CustomColor = System.Drawing.Color.FromArgb(cMesaSucia)
                    btn.Image = ImgDisponible
            End Select

            btn.Name = dr("Principal")
            btn.Text = dr("PrincipalName")
            btn.ToolTipText = dr("Clave")
            btn.setMESClave = dr("MESClave")
            btn.setClave = dr("Clave")
            btn.Width = 90
            btn.Height = 60
            btn.Location = New Point(x, y)
            x += 95
            Col += 1
            pnlMesas.Controls.Add(btn)
            AddHandler btn.Click, AddressOf Mesa_Click
        End While

        myCommand.Dispose()
        dr.Close()

        pnlMesas.VerticalScroll.Enabled = False
        pnlMesas.VerticalScroll.Visible = False

        iAvanceProductos = pnlMesas.VerticalScroll.LargeChange
    End Sub

    Private Sub Piso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Janus.Windows.EditControls.UIButton
        btn = sender
        Piso = btn.Text
        grpMesas.Text = Piso
        llenaMesas(btn.Name)
    End Sub

    Private Sub Mesa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Janus.Windows.EditControls.UIButton
        btn = sender

        If ModPOS.Touch Is Nothing Then
            ModPOS.Touch = New FrmTouch

            With ModPOS.Touch

                Dim dtComanda, dtComandaDetalle As DataTable
                Dim sFrase As String
                .Tipo = 5
                .MESClave = btn.Name
                .Mesa = btn.Text
                .Piso = Piso
                .Comensales = 0
                .ALMClave = ALMClave
                .PDVClave = PDVClave
                .PuntodeVenta = PuntodeVenta
                .Referencia = Referencia
                .Impresora = Impresora
                .Ticket = Ticket
                .Supervisor = Supervisor
                .SUCClave = SUCClave
                .Caja = Caja

                .CAJClave = CAJClave
                .CTEClaveInicial = CTEClaveInicial
                .CTENombreInicial = CTENombreInicial
                .ActivaDevolucion = ActivaDevolucion
                .CajeroClave = CajeroClave
                .CajeroNombre = CajeroNombre

                .MeseroClave = MeseroClave
                .MeseroNombre = MeseroNombre

                .USRCambiaPrecio = USRCambiaPrecio
                .PorcMaxDesc = PorcMaxDesc
                .CambiaPrecio = CambiaPrecio
                .Redondeo = Redondeo
                .Agotamiento = Agotamiento
                .SolicitaVendedor = SolicitaVendedor
                .Url_Redondeo = Url_Redondeo
                .LblFolio.Text = Referencia & "- "
                .PrintGeneric = PrintGeneric
                sFrase = Frase
                .NumCopias = NumCopias

                .ValidaInventario = ValidaInventario


                'dtComanda = ModPOS.SiExisteRecupera("sp_recupera_comandawait", "@PDVClave", .PDVClave)

                'If Not dtComanda Is Nothing Then
                '    .BtnEspera.Text = "Espera(1)"
                'End If

                dtComanda = ModPOS.SiExisteRecupera("sp_recupera_comandaopen", "@PDVClave", .PDVClave, "@MESClave", .MESClave, "@Tipo", 5)

                If dtComanda Is Nothing Then

                    'Dim a As New FrmTecladoNum
                    'a.Text = "Numero de Comensales"
                    'a.ShowDialog()

                    'If a.DialogResult = DialogResult.OK Then
                    '    If a.Cantidad = "" Then
                    '        .Comensales = 1
                    '    Else
                    '        .Comensales = a.Cantidad
                    '    End If
                    'Else
                    .Comensales = 1
                    'End If

                    .activaBotones(4, False)
                    .cambiaStatus("BIENVENIDO", FrmTouch.Status.Original)
                Else
                    'recupera comanda
                    .activaBotones(5, True)

                    .TotalArticulos = 0
                    .TotalPuntos = 0
                    .TotalVenta = 0
                    .TotalAhorro = 0


                    'recupera ticket

                    .CMDClave = dtComanda.Rows(0)("CMDClave")
                    .LblFolio.Text = dtComanda.Rows(0)("Folio")
                    .CTEClaveActual = dtComanda.Rows(0)("CTEClave")
                    .CTENombreActual = dtComanda.Rows(0)("RazonSocial")
                    .LblCliente.Text = .CTENombreActual

                    .MeseroClave = dtComanda.Rows(0)("Mesero")
                    .MeseroNombre = dtComanda.Rows(0)("NombreMesero")

                    .CajeroClave = dtComanda.Rows(0)("Cajero")
                    .CajeroNombre = dtComanda.Rows(0)("NombreCajero")

                    .LblCajero.Text = .CajeroNombre
                    .LblMesero.Text = .MeseroNombre

                    Dim dtCliente As DataTable
                    dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", .CTEClaveActual)
                    .ListaPrecio = dtCliente.Rows(0)("PREClave")
                    .TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                    dtCliente.Dispose()


                    'Descuento cliente
                        .DescuentoCliente = -1
                        .PorcDescCliente = 0
              
                    If .CambiarCliente = False Then
                        .BtnCliente.Enabled = False
                        .TxtCliente.Enabled = False
                    End If

                    .cambiaStatus("COMANDA (ABIERTA)", -1)

                    .ComandaCerrada = False
                    .ComandaNueva = True
                    .GeneraMovSalida = True

                    dtComanda.Dispose()

                    dtComandaDetalle = ModPOS.Recupera_Tabla("sp_comandadetalle_open", "@CMDClave", .CMDClave)

                    .TotalArticulos = dtComandaDetalle.Rows.Count

                    Dim i As Integer

                    For i = 0 To dtComandaDetalle.Rows.Count - 1
                        .TotalAhorro += ((dtComandaDetalle.Rows(i)("Descuento") * (1 + dtComandaDetalle.Rows(i)("PorcImpuesto"))) * dtComandaDetalle.Rows(i)("Cant."))
                        .TotalPuntos += (dtComandaDetalle.Rows(i)("Puntos") * dtComandaDetalle.Rows(i)("Cant."))
                        .TotalVenta += (dtComandaDetalle.Rows(i)("Subtotal"))
                    Next
                    dtComandaDetalle.Dispose()

                    .LblTotal.Text = Format(CStr(ModPOS.Redondear(.TotalVenta, 2)), "Currency")
                    .LblCantidadPuntos.Text = CStr(ModPOS.Redondear(.TotalPuntos, 2))
                    .LblAhorro.Text = Format(CStr(ModPOS.Redondear(.TotalAhorro, 2)), "Currency")


                End If

            End With
        End If

        ModPOS.Touch.Width = Screen.PrimaryScreen.Bounds.Width
        ModPOS.Touch.Height = Screen.PrimaryScreen.Bounds.Height
        ModPOS.Touch.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Touch.ShowDialog()

        If iColorMesa >= 1 Then
            llenaMesas(PISClave)
        End If

        'Select Case iColorMesa
        '    Case 1
        '        btn.Office2007CustomColor = System.Drawing.Color.FromArgb(cMesaDisponible)
        '        btn.Image = ImgDisponible
        '    Case 2
        '        btn.Office2007CustomColor = System.Drawing.Color.FromArgb(cMesaOcupada)
        '        btn.Image = ImgOcupada
        '    Case 3
        '        btn.Office2007CustomColor = System.Drawing.Color.FromArgb(cMesaSucia)
        '        btn.Image = ImgDisponible
        'End Select



    End Sub

    Private Sub FrmTPDV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        llenaPisos(SUCClave)

        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "Moneda"
                        Moneda = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "MonedaCambio"
                        MonedaCambio = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                End Select
            Next
        End With

        dt.Dispose()

        If Moneda <> MonedaCambio Then

            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
            MonedaRef = dt.Rows(0)("Referencia")
            TipoCambio = dt.Rows(0)("TipoCambio")
            dt.Dispose()
        End If

        If Caja Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
            CajaTICDevolucion = dt.Rows(0)("TICDevolucion")
            CajaClave = dt.Rows(0)("Clave")
            CajaNombre = dt.Rows(0)("Nombre")
            Manual = IIf(dt.Rows(0)("Manual").GetType.Name = "DBNull", 0, dt.Rows(0)("Manual"))
            Cajon = IIf(dt.Rows(0)("Cajon").GetType.Name = "DBNull", False, dt.Rows(0)("Cajon"))
            CorteDetallado = IIf(dt.Rows(0)("CorteDetallado").GetType.Name = "DBNull", 0, dt.Rows(0)("CorteDetallado"))

            dt.Dispose()

            dt = ModPOS.Recupera_Tabla("sp_busca_corteCaja", "@CAJClave", CAJClave)

            Dim IDCorte As String = ""
            Dim sFechaApertura As String = ""
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    IDCorte = dt.Rows(0)("ID")
                    sFechaApertura = dt.Rows(0)("FechaApertura").ToString
                Else
                    IDCorte = ""
                End If
                dt.Dispose()
            End If

            If Manual = 1 AndAlso IDCorte <> "" Then
                Dim ac As New FrmCerrarCaja
                ac.TxtLeyenda.Text = "La caja se encuentra abierta desde el " & sFechaApertura
                ac.StartPosition = FormStartPosition.CenterScreen
                ac.ShowDialog()
                If ac.DialogResult = System.Windows.Forms.DialogResult.OK AndAlso ac.Accion = "Corte" Then
                    
                    If CorteDetallado = 1 Then
                        Dim a As New FrmAperturaCaja
                        a.LBTitulo.Text = "Corte de Caja al Cierre"
                        a.Accion = "Cierre"
                        a.CAJClave = CAJClave
                        a.Impresora = Impresora
                        a.Generic = PrintGeneric
                        a.Recibo = Ticket
                        a.IDCorte = IDCorte
                        a.BtnCancelar.Visible = False
                        a.Cajon = Cajon
                        a.ShowDialog()
                        If a.DialogResult = Windows.Forms.DialogResult.OK Then
                            Me.bCierreApertura = True
                            Me.Close()
                        End If
                    Else
                        Dim a As New FrmAperturaSimple
                        a.LBTitulo.Text = "Corte de Caja al Cierre"
                        a.Accion = "Cierre"
                        a.CAJClave = CAJClave
                        a.Impresora = Impresora
                        a.Generic = PrintGeneric
                        a.Recibo = Ticket
                        a.IDCorte = IDCorte
                        a.BtnCancelar.Visible = False
                        a.Cajon = Cajon
                        a.ShowDialog()
                        If a.DialogResult = Windows.Forms.DialogResult.OK Then
                            Me.bCierreApertura = True
                            Me.Close()
                        End If
                    End If

                   
                ElseIf ac.Accion = "PreCorte" Then
                    Dim StopPrint As Boolean = False

                    Dim sPrintMessage As String = "¿Desea Reimprimir el Pre Corte de Caja?"
                    Do

                        imprimeTicketPreCorte(IDCorte, Impresora, PrintGeneric, Ticket)

                        Select Case MessageBox.Show(sPrintMessage, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            Case DialogResult.No
                                StopPrint = True
                        End Select

                    Loop While Not StopPrint

                ElseIf ac.Accion = "" Then
                    Me.Close()
                End If
            Else
                
                If CorteDetallado = 1 Then
                    Dim a As New FrmAperturaCaja
                    a.Accion = "Apertura"
                    a.IDCorte = IDCorte
                    a.CAJClave = CAJClave
                    a.Cajon = Cajon
                    a.Generic = PrintGeneric
                    a.Recibo = Ticket
                    a.Impresora = Impresora
                    a.ShowDialog()
                Else
                    Dim a As New FrmAperturaSimple
                    a.Accion = "Apertura"
                    a.IDCorte = IDCorte
                    a.CAJClave = CAJClave
                    a.Cajon = Cajon
                    a.Generic = PrintGeneric
                    a.Recibo = Ticket
                    a.Impresora = Impresora
                    a.ShowDialog()
                End If

               
            End If
        End If

        If ComandaCerrada = True Then

            '     llenaGrid("")

            CTEClaveActual = CTEClaveInicial
            CTENombreActual = CTENombreInicial
        Else
            '     llenaGrid(CMDClave)
        End If

        Me.LblFechaHora.Text = DateTime.Today.ToLongDateString & " " & DateTime.Now.ToShortTimeString 'ToString("MMMM dd, yyyy")

        Clock.Start()

    End Sub

    Private Sub FrmPlano_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        ModPOS.Ejecuta("sp_actualiza_caja", "@PDVClave", PDVClave, "@Fase", 0)
        If Caja Then
            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_busca_corteCaja", "@CAJClave", CAJClave)

            Dim IDCorte As String = ""
            Dim sFechaApertura As String = ""

            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    IDCorte = dt.Rows(0)("ID")
                    sFechaApertura = dt.Rows(0)("FechaApertura").ToString
                Else
                    IDCorte = ""
                End If
                dt.Dispose()
            End If

            If Manual = 1 AndAlso IDCorte <> "" Then
                Dim ac As New FrmCerrarCaja
                ac.TxtLeyenda.Text = "La caja se encuentra abierta desde el " & sFechaApertura
                ac.StartPosition = FormStartPosition.CenterScreen
                ac.ShowDialog()
                If ac.DialogResult = System.Windows.Forms.DialogResult.OK AndAlso ac.Accion = "Corte" Then
                    
                    If CorteDetallado = 1 Then
                        Dim a As New FrmAperturaCaja
                        a.LBTitulo.Text = "Corte de Caja al Cierre"
                        a.Accion = "Cierre"
                        a.CAJClave = CAJClave
                        a.Impresora = Impresora
                        a.Generic = PrintGeneric
                        a.Recibo = Ticket
                        a.IDCorte = IDCorte
                        a.BtnCancelar.Visible = True
                        a.Cajon = Cajon
                        a.ShowDialog()
                        If a.DialogResult = Windows.Forms.DialogResult.Cancel Then
                            e.Cancel = True
                            Exit Sub
                        End If
                    Else
                        Dim a As New FrmAperturaSimple
                        a.LBTitulo.Text = "Corte de Caja al Cierre"
                        a.Accion = "Cierre"
                        a.CAJClave = CAJClave
                        a.Impresora = Impresora
                        a.Generic = PrintGeneric
                        a.Recibo = Ticket
                        a.IDCorte = IDCorte
                        a.BtnCancelar.Visible = True
                        a.Cajon = Cajon
                        a.ShowDialog()
                        If a.DialogResult = Windows.Forms.DialogResult.Cancel Then
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If

                    
                ElseIf ac.Accion = "PreCorte" Then
                    Dim StopPrint As Boolean = False

                    Dim sPrintMessage As String = "¿Desea Reimprimir el Pre Corte de Caja?"
                    Do

                        imprimeTicketPreCorte(IDCorte, Impresora, PrintGeneric, Ticket)

                        Select Case MessageBox.Show(sPrintMessage, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            Case DialogResult.No
                                StopPrint = True
                        End Select

                    Loop While Not StopPrint

                    e.Cancel = True
                    Exit Sub
                ElseIf ac.Accion = "" Then
                    e.Cancel = True
                    Exit Sub

                End If
            ElseIf bCierreApertura = False Then

                If CorteDetallado = 1 Then
                    Dim a As New FrmAperturaCaja
                    a.LBTitulo.Text = "Corte de Caja al Cierre"
                    a.Accion = "Cierre"
                    a.CAJClave = CAJClave
                    a.Impresora = Impresora
                    a.Generic = PrintGeneric
                    a.Recibo = Ticket
                    a.IDCorte = IDCorte
                    a.BtnCancelar.Visible = True
                    a.Cajon = Cajon
                    a.ShowDialog()
                    If a.DialogResult = Windows.Forms.DialogResult.Cancel Then
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    Dim a As New FrmAperturaSimple
                    a.LBTitulo.Text = "Corte de Caja al Cierre"
                    a.Accion = "Cierre"
                    a.CAJClave = CAJClave
                    a.Impresora = Impresora
                    a.Generic = PrintGeneric
                    a.Recibo = Ticket
                    a.IDCorte = IDCorte
                    a.BtnCancelar.Visible = True
                    a.Cajon = Cajon
                    a.ShowDialog()
                    If a.DialogResult = Windows.Forms.DialogResult.Cancel Then
                        e.Cancel = True
                        Exit Sub
                    End If
                End If

               
            End If

        End If

        ModPOS.Plano.Dispose()
        ModPOS.Plano = Nothing
    End Sub

    Private Sub Clock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock.Tick
        Me.LblFechaHora.Text = DateTime.Today.ToLongDateString & " " & DateTime.Now.ToShortTimeString 'ToString("MMMM dd, yyyy")
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        llenaMesas(PISClave)
    End Sub

    Private Sub BtnMover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMover.Click
        Dim a As New FrmCambiarMesa
        a.PDVClave = Me.PDVClave
        a.PISClave = Me.PISClave
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            llenaMesas(PISClave)
        End If
    End Sub

    Private Sub BtnUnir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnir.Click
        Dim a As New FrmUnirMesa
        a.PDVClave = Me.PDVClave
        a.PISClave = Me.PISClave
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            llenaMesas(PISClave)
        End If
    End Sub
End Class


