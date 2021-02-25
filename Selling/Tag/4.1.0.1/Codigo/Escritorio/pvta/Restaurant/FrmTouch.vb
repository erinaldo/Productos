Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Collections
Imports System.IO.Ports

Public Class FrmTouch
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
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblFolio As System.Windows.Forms.Label
    Friend WithEvents LblFechaHora As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnBorrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCerrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnNueva As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnConsultar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BtnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnBorrarTodo As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEspera As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnResumen As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnTicketAnt As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnRepetir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnRestar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSumar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnPrimero As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSiguiente As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAnterior As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnUltimo As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents BtnCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnIzqMenu As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDerMenu As Janus.Windows.EditControls.UIButton
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents grpSub As System.Windows.Forms.GroupBox
    Friend WithEvents btnIzqSub As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDerSub As Janus.Windows.EditControls.UIButton
    Friend WithEvents pnlSubmenu As System.Windows.Forms.Panel
    Friend WithEvents grpProd As System.Windows.Forms.GroupBox
    Friend WithEvents btnUltProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnIniProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnAntProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSigProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents pnlProductos As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblCajero As System.Windows.Forms.Label
    Friend WithEvents PnlStatus As System.Windows.Forms.Panel
    Friend WithEvents LblAtiende As System.Windows.Forms.Label
    Friend WithEvents LblMesero As System.Windows.Forms.Label
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents LblInfoMesa As System.Windows.Forms.Label
    Friend WithEvents grpMod As System.Windows.Forms.GroupBox
    Friend WithEvents btnIzqMod As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDerMod As Janus.Windows.EditControls.UIButton
    Friend WithEvents pnlMod As System.Windows.Forms.Panel
    Friend WithEvents BtnDisminuir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnDevolucion As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnNotas As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblCantidadPuntos As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblAhorro As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTouch))
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblCajero = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblFolio = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LblFechaHora = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.BtnConsultar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCerrar = New Janus.Windows.EditControls.UIButton()
        Me.BtnNueva = New Janus.Windows.EditControls.UIButton()
        Me.BtnBorrar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.BtnBorrarTodo = New Janus.Windows.EditControls.UIButton()
        Me.BtnEspera = New Janus.Windows.EditControls.UIButton()
        Me.BtnResumen = New Janus.Windows.EditControls.UIButton()
        Me.BtnTicketAnt = New Janus.Windows.EditControls.UIButton()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.BtnRepetir = New Janus.Windows.EditControls.UIButton()
        Me.BtnRestar = New Janus.Windows.EditControls.UIButton()
        Me.BtnSumar = New Janus.Windows.EditControls.UIButton()
        Me.BtnPrimero = New Janus.Windows.EditControls.UIButton()
        Me.BtnSiguiente = New Janus.Windows.EditControls.UIButton()
        Me.BtnAnterior = New Janus.Windows.EditControls.UIButton()
        Me.BtnUltimo = New Janus.Windows.EditControls.UIButton()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.BtnCliente = New Janus.Windows.EditControls.UIButton()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LblTipoCambio = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnIzqMenu = New Janus.Windows.EditControls.UIButton()
        Me.btnDerMenu = New Janus.Windows.EditControls.UIButton()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.grpSub = New System.Windows.Forms.GroupBox()
        Me.btnIzqSub = New Janus.Windows.EditControls.UIButton()
        Me.btnDerSub = New Janus.Windows.EditControls.UIButton()
        Me.pnlSubmenu = New System.Windows.Forms.Panel()
        Me.grpProd = New System.Windows.Forms.GroupBox()
        Me.btnUltProd = New Janus.Windows.EditControls.UIButton()
        Me.btnIniProd = New Janus.Windows.EditControls.UIButton()
        Me.btnAntProd = New Janus.Windows.EditControls.UIButton()
        Me.btnSigProd = New Janus.Windows.EditControls.UIButton()
        Me.pnlProductos = New System.Windows.Forms.Panel()
        Me.PnlStatus = New System.Windows.Forms.Panel()
        Me.LblAtiende = New System.Windows.Forms.Label()
        Me.LblMesero = New System.Windows.Forms.Label()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.LblInfoMesa = New System.Windows.Forms.Label()
        Me.grpMod = New System.Windows.Forms.GroupBox()
        Me.btnIzqMod = New Janus.Windows.EditControls.UIButton()
        Me.btnDerMod = New Janus.Windows.EditControls.UIButton()
        Me.pnlMod = New System.Windows.Forms.Panel()
        Me.BtnDisminuir = New Janus.Windows.EditControls.UIButton()
        Me.BtnDevolucion = New Janus.Windows.EditControls.UIButton()
        Me.BtnNotas = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblCantidadPuntos = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblAhorro = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpSub.SuspendLayout()
        Me.grpProd.SuspendLayout()
        Me.PnlStatus.SuspendLayout()
        Me.grpMod.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.MintCream
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.LblCajero)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.LblFolio)
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Location = New System.Drawing.Point(2, 2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(390, 52)
        Me.Panel5.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(6, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 17)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "CAJERO:"
        '
        'LblCajero
        '
        Me.LblCajero.BackColor = System.Drawing.Color.Transparent
        Me.LblCajero.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.LblCajero.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblCajero.Location = New System.Drawing.Point(83, 32)
        Me.LblCajero.Name = "LblCajero"
        Me.LblCajero.Size = New System.Drawing.Size(228, 17)
        Me.LblCajero.TabIndex = 47
        Me.LblCajero.Text = "JUAN PEREZ"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(3, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 21)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "COMANDA"
        '
        'LblFolio
        '
        Me.LblFolio.BackColor = System.Drawing.Color.Transparent
        Me.LblFolio.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
        Me.LblFolio.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblFolio.Location = New System.Drawing.Point(103, 2)
        Me.LblFolio.Name = "LblFolio"
        Me.LblFolio.Size = New System.Drawing.Size(117, 27)
        Me.LblFolio.TabIndex = 8
        Me.LblFolio.Text = "1-0001"
        Me.LblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label16.Location = New System.Drawing.Point(220, 6)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(168, 14)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "<Ctrl+R> para retiro de Caja"
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
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(239, 231)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 20)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "CANTIDAD"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCantidad.Location = New System.Drawing.Point(239, 249)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(75, 38)
        Me.TxtCantidad.TabIndex = 1
        Me.TxtCantidad.Text = "0.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 0.0R
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsultar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConsultar.Location = New System.Drawing.Point(2, 231)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnConsultar.Office2007CustomColor = System.Drawing.Color.Orange
        Me.BtnConsultar.Size = New System.Drawing.Size(75, 56)
        Me.BtnConsultar.TabIndex = 9
        Me.BtnConsultar.Text = "Consultar"
        Me.BtnConsultar.ToolTipText = "Consulta de Precio"
        Me.BtnConsultar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCerrar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Location = New System.Drawing.Point(237, 113)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnCerrar.Office2007CustomColor = System.Drawing.Color.RoyalBlue
        Me.BtnCerrar.Size = New System.Drawing.Size(155, 56)
        Me.BtnCerrar.TabIndex = 11
        Me.BtnCerrar.Text = "Cerrar"
        Me.BtnCerrar.ToolTipText = "Cierra el Documento Actual"
        Me.BtnCerrar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnNueva
        '
        Me.BtnNueva.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNueva.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNueva.Location = New System.Drawing.Point(237, 55)
        Me.BtnNueva.Name = "BtnNueva"
        Me.BtnNueva.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnNueva.Office2007CustomColor = System.Drawing.Color.ForestGreen
        Me.BtnNueva.Size = New System.Drawing.Size(155, 55)
        Me.BtnNueva.TabIndex = 12
        Me.BtnNueva.Text = "Nueva"
        Me.BtnNueva.ToolTipText = "Crea una Comanda"
        Me.BtnNueva.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnBorrar
        '
        Me.BtnBorrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBorrar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBorrar.Location = New System.Drawing.Point(2, 113)
        Me.BtnBorrar.Name = "BtnBorrar"
        Me.BtnBorrar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnBorrar.Office2007CustomColor = System.Drawing.Color.Red
        Me.BtnBorrar.Size = New System.Drawing.Size(75, 56)
        Me.BtnBorrar.TabIndex = 7
        Me.BtnBorrar.Text = "Borrar"
        Me.BtnBorrar.ToolTipText = "Borra el producto seleccionado"
        Me.BtnBorrar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancelar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Location = New System.Drawing.Point(159, 55)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnCancelar.Office2007CustomColor = System.Drawing.Color.Red
        Me.BtnCancelar.Size = New System.Drawing.Size(75, 55)
        Me.BtnCancelar.TabIndex = 6
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.ToolTipText = "Cancela la Comanda"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAceptar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAceptar.Location = New System.Drawing.Point(237, 172)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnAceptar.Office2007CustomColor = System.Drawing.Color.Yellow
        Me.BtnAceptar.Size = New System.Drawing.Size(155, 55)
        Me.BtnAceptar.TabIndex = 47
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.ToolTipText = "Aceptar"
        Me.BtnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnBorrarTodo
        '
        Me.BtnBorrarTodo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBorrarTodo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBorrarTodo.Location = New System.Drawing.Point(81, 113)
        Me.BtnBorrarTodo.Name = "BtnBorrarTodo"
        Me.BtnBorrarTodo.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnBorrarTodo.Office2007CustomColor = System.Drawing.Color.Red
        Me.BtnBorrarTodo.Size = New System.Drawing.Size(75, 56)
        Me.BtnBorrarTodo.TabIndex = 48
        Me.BtnBorrarTodo.Text = "Borrar Todo"
        Me.BtnBorrarTodo.ToolTipText = "Borra todos los productos "
        Me.BtnBorrarTodo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnEspera
        '
        Me.BtnEspera.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEspera.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEspera.Location = New System.Drawing.Point(81, 231)
        Me.BtnEspera.Name = "BtnEspera"
        Me.BtnEspera.Size = New System.Drawing.Size(75, 56)
        Me.BtnEspera.TabIndex = 49
        Me.BtnEspera.Text = "Espera"
        Me.BtnEspera.ToolTipText = "Comanda en Espera"
        Me.BtnEspera.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnResumen
        '
        Me.BtnResumen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnResumen.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnResumen.Location = New System.Drawing.Point(81, 172)
        Me.BtnResumen.Name = "BtnResumen"
        Me.BtnResumen.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnResumen.Office2007CustomColor = System.Drawing.Color.Orange
        Me.BtnResumen.Size = New System.Drawing.Size(75, 55)
        Me.BtnResumen.TabIndex = 50
        Me.BtnResumen.Text = "Resumen"
        Me.BtnResumen.ToolTipText = "Resumen de la Compra o Consumo"
        Me.BtnResumen.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnTicketAnt
        '
        Me.BtnTicketAnt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTicketAnt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTicketAnt.Location = New System.Drawing.Point(81, 55)
        Me.BtnTicketAnt.Name = "BtnTicketAnt"
        Me.BtnTicketAnt.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.BtnTicketAnt.Size = New System.Drawing.Size(75, 55)
        Me.BtnTicketAnt.TabIndex = 51
        Me.BtnTicketAnt.Text = "Ticket Ant."
        Me.BtnTicketAnt.ToolTipText = "Reimprime el Ticket de una Venta Anterior"
        Me.BtnTicketAnt.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Location = New System.Drawing.Point(2, 55)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnSalir.Office2007CustomColor = System.Drawing.Color.Red
        Me.BtnSalir.Size = New System.Drawing.Size(75, 55)
        Me.BtnSalir.TabIndex = 52
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.ToolTipText = "Cerrar el punto de venta"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnRepetir
        '
        Me.BtnRepetir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRepetir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRepetir.Location = New System.Drawing.Point(159, 172)
        Me.BtnRepetir.Name = "BtnRepetir"
        Me.BtnRepetir.Size = New System.Drawing.Size(75, 55)
        Me.BtnRepetir.TabIndex = 53
        Me.BtnRepetir.Text = "Repetir"
        Me.BtnRepetir.ToolTipText = "Agrega la ultima selección"
        Me.BtnRepetir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnRestar
        '
        Me.BtnRestar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRestar.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRestar.Location = New System.Drawing.Point(159, 231)
        Me.BtnRestar.Name = "BtnRestar"
        Me.BtnRestar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnRestar.Office2007CustomColor = System.Drawing.Color.Yellow
        Me.BtnRestar.Size = New System.Drawing.Size(75, 56)
        Me.BtnRestar.TabIndex = 54
        Me.BtnRestar.Text = "-"
        Me.BtnRestar.ToolTipText = "Disminuye la cantidad"
        Me.BtnRestar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSumar
        '
        Me.BtnSumar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSumar.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSumar.Location = New System.Drawing.Point(317, 231)
        Me.BtnSumar.Name = "BtnSumar"
        Me.BtnSumar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnSumar.Office2007CustomColor = System.Drawing.Color.RoyalBlue
        Me.BtnSumar.Size = New System.Drawing.Size(75, 56)
        Me.BtnSumar.TabIndex = 55
        Me.BtnSumar.Text = "+"
        Me.BtnSumar.ToolTipText = "Incrementa la cantidad"
        Me.BtnSumar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnPrimero
        '
        Me.BtnPrimero.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnPrimero.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPrimero.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrimero.Icon = CType(resources.GetObject("BtnPrimero.Icon"), System.Drawing.Icon)
        Me.BtnPrimero.Location = New System.Drawing.Point(3, 686)
        Me.BtnPrimero.Name = "BtnPrimero"
        Me.BtnPrimero.Size = New System.Drawing.Size(50, 55)
        Me.BtnPrimero.TabIndex = 57
        Me.BtnPrimero.ToolTipText = "Ir al Primero"
        Me.BtnPrimero.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSiguiente
        '
        Me.BtnSiguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSiguiente.Icon = CType(resources.GetObject("BtnSiguiente.Icon"), System.Drawing.Icon)
        Me.BtnSiguiente.Location = New System.Drawing.Point(116, 686)
        Me.BtnSiguiente.Name = "BtnSiguiente"
        Me.BtnSiguiente.Size = New System.Drawing.Size(50, 55)
        Me.BtnSiguiente.TabIndex = 58
        Me.BtnSiguiente.ToolTipText = "Siguiente"
        Me.BtnSiguiente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAnterior
        '
        Me.BtnAnterior.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAnterior.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAnterior.Icon = CType(resources.GetObject("BtnAnterior.Icon"), System.Drawing.Icon)
        Me.BtnAnterior.Location = New System.Drawing.Point(59, 686)
        Me.BtnAnterior.Name = "BtnAnterior"
        Me.BtnAnterior.Size = New System.Drawing.Size(50, 55)
        Me.BtnAnterior.TabIndex = 59
        Me.BtnAnterior.ToolTipText = "Anterior"
        Me.BtnAnterior.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnUltimo
        '
        Me.BtnUltimo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnUltimo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnUltimo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUltimo.Icon = CType(resources.GetObject("BtnUltimo.Icon"), System.Drawing.Icon)
        Me.BtnUltimo.Location = New System.Drawing.Point(172, 686)
        Me.BtnUltimo.Name = "BtnUltimo"
        Me.BtnUltimo.Size = New System.Drawing.Size(50, 55)
        Me.BtnUltimo.TabIndex = 60
        Me.BtnUltimo.ToolTipText = "Ir al Ultimo"
        Me.BtnUltimo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtCliente
        '
        Me.TxtCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCliente.Font = New System.Drawing.Font("Arial", 16.0!)
        Me.TxtCliente.Location = New System.Drawing.Point(437, 4)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(301, 32)
        Me.TxtCliente.TabIndex = 61
        '
        'BtnCliente
        '
        Me.BtnCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCliente.Icon = CType(resources.GetObject("BtnCliente.Icon"), System.Drawing.Icon)
        Me.BtnCliente.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnCliente.Location = New System.Drawing.Point(743, 4)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(49, 32)
        Me.BtnCliente.TabIndex = 62
        Me.BtnCliente.ToolTipText = "Busqueda de Cliente"
        Me.BtnCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblCliente
        '
        Me.LblCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCliente.BackColor = System.Drawing.Color.Transparent
        Me.LblCliente.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.LblCliente.ForeColor = System.Drawing.Color.Black
        Me.LblCliente.Location = New System.Drawing.Point(437, 41)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(577, 17)
        Me.LblCliente.TabIndex = 64
        Me.LblCliente.Text = "JUAN PEREZ "
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(397, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 23)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "CTE:"
        '
        'GridDetalle
        '
        Me.GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Enabled = False
        Me.GridDetalle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(2, 348)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(390, 311)
        Me.GridDetalle.TabIndex = 65
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(2, -1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 15)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "TOTAL"
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.BackColor = System.Drawing.Color.Transparent
        Me.LblTotal.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblTotal.Location = New System.Drawing.Point(1, 12)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(160, 23)
        Me.LblTotal.TabIndex = 8
        Me.LblTotal.Text = "$353.45 M.N"
        Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.MintCream
        Me.Panel3.Controls.Add(Me.LblTipoCambio)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.LblTotal)
        Me.Panel3.Location = New System.Drawing.Point(229, 686)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(162, 55)
        Me.Panel3.TabIndex = 66
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTipoCambio.BackColor = System.Drawing.Color.MintCream
        Me.LblTipoCambio.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipoCambio.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblTipoCambio.Location = New System.Drawing.Point(1, 36)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(156, 17)
        Me.LblTipoCambio.TabIndex = 42
        Me.LblTipoCambio.Text = "PUNTO DE VENTA"
        Me.LblTipoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnIzqMenu)
        Me.GroupBox1.Controls.Add(Me.btnDerMenu)
        Me.GroupBox1.Controls.Add(Me.pnlMenu)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(395, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(625, 102)
        Me.GroupBox1.TabIndex = 67
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Menú"
        '
        'btnIzqMenu
        '
        Me.btnIzqMenu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIzqMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIzqMenu.Icon = CType(resources.GetObject("btnIzqMenu.Icon"), System.Drawing.Icon)
        Me.btnIzqMenu.ImageVerticalAlignment = Janus.Windows.EditControls.ImageVerticalAlignment.TopOfText
        Me.btnIzqMenu.Location = New System.Drawing.Point(3, 11)
        Me.btnIzqMenu.Name = "btnIzqMenu"
        Me.btnIzqMenu.Size = New System.Drawing.Size(50, 85)
        Me.btnIzqMenu.TabIndex = 61
        Me.btnIzqMenu.ToolTipText = "Anterior"
        Me.btnIzqMenu.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnDerMenu
        '
        Me.btnDerMenu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDerMenu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDerMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDerMenu.Icon = CType(resources.GetObject("btnDerMenu.Icon"), System.Drawing.Icon)
        Me.btnDerMenu.Location = New System.Drawing.Point(571, 11)
        Me.btnDerMenu.Name = "btnDerMenu"
        Me.btnDerMenu.Size = New System.Drawing.Size(50, 85)
        Me.btnDerMenu.TabIndex = 60
        Me.btnDerMenu.ToolTipText = "Siguiente"
        Me.btnDerMenu.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'pnlMenu
        '
        Me.pnlMenu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMenu.AutoScroll = True
        Me.pnlMenu.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlMenu.Location = New System.Drawing.Point(56, 11)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(512, 87)
        Me.pnlMenu.TabIndex = 0
        '
        'grpSub
        '
        Me.grpSub.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSub.Controls.Add(Me.btnIzqSub)
        Me.grpSub.Controls.Add(Me.btnDerSub)
        Me.grpSub.Controls.Add(Me.pnlSubmenu)
        Me.grpSub.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSub.ForeColor = System.Drawing.Color.Black
        Me.grpSub.Location = New System.Drawing.Point(395, 165)
        Me.grpSub.Name = "grpSub"
        Me.grpSub.Size = New System.Drawing.Size(625, 92)
        Me.grpSub.TabIndex = 68
        Me.grpSub.TabStop = False
        Me.grpSub.Text = "Submenu"
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
        Me.btnDerSub.Location = New System.Drawing.Point(571, 11)
        Me.btnDerSub.Name = "btnDerSub"
        Me.btnDerSub.Size = New System.Drawing.Size(50, 77)
        Me.btnDerSub.TabIndex = 60
        Me.btnDerSub.ToolTipText = "Siguiente"
        Me.btnDerSub.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'pnlSubmenu
        '
        Me.pnlSubmenu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSubmenu.AutoScroll = True
        Me.pnlSubmenu.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSubmenu.Location = New System.Drawing.Point(57, 11)
        Me.pnlSubmenu.Name = "pnlSubmenu"
        Me.pnlSubmenu.Size = New System.Drawing.Size(512, 77)
        Me.pnlSubmenu.TabIndex = 0
        '
        'grpProd
        '
        Me.grpProd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpProd.Controls.Add(Me.btnUltProd)
        Me.grpProd.Controls.Add(Me.btnIniProd)
        Me.grpProd.Controls.Add(Me.btnAntProd)
        Me.grpProd.Controls.Add(Me.btnSigProd)
        Me.grpProd.Controls.Add(Me.pnlProductos)
        Me.grpProd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpProd.ForeColor = System.Drawing.Color.Black
        Me.grpProd.Location = New System.Drawing.Point(394, 261)
        Me.grpProd.Name = "grpProd"
        Me.grpProd.Size = New System.Drawing.Size(625, 379)
        Me.grpProd.TabIndex = 69
        Me.grpProd.TabStop = False
        Me.grpProd.Text = "Productos"
        '
        'btnUltProd
        '
        Me.btnUltProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUltProd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUltProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUltProd.Icon = CType(resources.GetObject("btnUltProd.Icon"), System.Drawing.Icon)
        Me.btnUltProd.Location = New System.Drawing.Point(568, 195)
        Me.btnUltProd.Name = "btnUltProd"
        Me.btnUltProd.Size = New System.Drawing.Size(50, 55)
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
        Me.btnIniProd.Location = New System.Drawing.Point(568, 19)
        Me.btnIniProd.Name = "btnIniProd"
        Me.btnIniProd.Size = New System.Drawing.Size(50, 56)
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
        Me.btnAntProd.Location = New System.Drawing.Point(568, 78)
        Me.btnAntProd.Name = "btnAntProd"
        Me.btnAntProd.Size = New System.Drawing.Size(50, 55)
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
        Me.btnSigProd.Location = New System.Drawing.Point(568, 136)
        Me.btnSigProd.Name = "btnSigProd"
        Me.btnSigProd.Size = New System.Drawing.Size(50, 56)
        Me.btnSigProd.TabIndex = 60
        Me.btnSigProd.ToolTipText = "Siguiente"
        Me.btnSigProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'pnlProductos
        '
        Me.pnlProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlProductos.AutoScroll = True
        Me.pnlProductos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlProductos.Location = New System.Drawing.Point(7, 19)
        Me.pnlProductos.Name = "pnlProductos"
        Me.pnlProductos.Size = New System.Drawing.Size(546, 349)
        Me.pnlProductos.TabIndex = 0
        '
        'PnlStatus
        '
        Me.PnlStatus.BackColor = System.Drawing.Color.ForestGreen
        Me.PnlStatus.Controls.Add(Me.LblAtiende)
        Me.PnlStatus.Controls.Add(Me.LblMesero)
        Me.PnlStatus.Controls.Add(Me.LblStatus)
        Me.PnlStatus.Controls.Add(Me.LblInfoMesa)
        Me.PnlStatus.Location = New System.Drawing.Point(2, 289)
        Me.PnlStatus.Name = "PnlStatus"
        Me.PnlStatus.Size = New System.Drawing.Size(390, 58)
        Me.PnlStatus.TabIndex = 72
        '
        'LblAtiende
        '
        Me.LblAtiende.BackColor = System.Drawing.Color.Transparent
        Me.LblAtiende.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAtiende.ForeColor = System.Drawing.Color.Transparent
        Me.LblAtiende.Location = New System.Drawing.Point(4, 36)
        Me.LblAtiende.Name = "LblAtiende"
        Me.LblAtiende.Size = New System.Drawing.Size(85, 18)
        Me.LblAtiende.TabIndex = 72
        Me.LblAtiende.Text = "ATIENDE:"
        '
        'LblMesero
        '
        Me.LblMesero.BackColor = System.Drawing.Color.Transparent
        Me.LblMesero.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMesero.ForeColor = System.Drawing.Color.White
        Me.LblMesero.Location = New System.Drawing.Point(98, 36)
        Me.LblMesero.Name = "LblMesero"
        Me.LblMesero.Size = New System.Drawing.Size(286, 18)
        Me.LblMesero.TabIndex = 73
        Me.LblMesero.Text = "JUAN PEREZ"
        '
        'LblStatus
        '
        Me.LblStatus.BackColor = System.Drawing.Color.Transparent
        Me.LblStatus.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStatus.ForeColor = System.Drawing.Color.White
        Me.LblStatus.Location = New System.Drawing.Point(3, 3)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(384, 21)
        Me.LblStatus.TabIndex = 7
        Me.LblStatus.Text = "COMANDA"
        Me.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblInfoMesa
        '
        Me.LblInfoMesa.BackColor = System.Drawing.Color.Transparent
        Me.LblInfoMesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LblInfoMesa.ForeColor = System.Drawing.Color.White
        Me.LblInfoMesa.Location = New System.Drawing.Point(2, 23)
        Me.LblInfoMesa.Name = "LblInfoMesa"
        Me.LblInfoMesa.Size = New System.Drawing.Size(387, 15)
        Me.LblInfoMesa.TabIndex = 45
        Me.LblInfoMesa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpMod
        '
        Me.grpMod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMod.Controls.Add(Me.btnIzqMod)
        Me.grpMod.Controls.Add(Me.btnDerMod)
        Me.grpMod.Controls.Add(Me.pnlMod)
        Me.grpMod.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpMod.ForeColor = System.Drawing.Color.Black
        Me.grpMod.Location = New System.Drawing.Point(462, 646)
        Me.grpMod.Name = "grpMod"
        Me.grpMod.Size = New System.Drawing.Size(557, 95)
        Me.grpMod.TabIndex = 73
        Me.grpMod.TabStop = False
        Me.grpMod.Text = "Modificadores"
        '
        'btnIzqMod
        '
        Me.btnIzqMod.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIzqMod.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIzqMod.Icon = CType(resources.GetObject("btnIzqMod.Icon"), System.Drawing.Icon)
        Me.btnIzqMod.ImageVerticalAlignment = Janus.Windows.EditControls.ImageVerticalAlignment.TopOfText
        Me.btnIzqMod.Location = New System.Drawing.Point(2, 13)
        Me.btnIzqMod.Name = "btnIzqMod"
        Me.btnIzqMod.Size = New System.Drawing.Size(52, 77)
        Me.btnIzqMod.TabIndex = 61
        Me.btnIzqMod.ToolTipText = "Anterior"
        Me.btnIzqMod.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnDerMod
        '
        Me.btnDerMod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDerMod.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDerMod.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDerMod.Icon = CType(resources.GetObject("btnDerMod.Icon"), System.Drawing.Icon)
        Me.btnDerMod.Location = New System.Drawing.Point(503, 11)
        Me.btnDerMod.Name = "btnDerMod"
        Me.btnDerMod.Size = New System.Drawing.Size(50, 77)
        Me.btnDerMod.TabIndex = 60
        Me.btnDerMod.ToolTipText = "Siguiente"
        Me.btnDerMod.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'pnlMod
        '
        Me.pnlMod.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMod.AutoScroll = True
        Me.pnlMod.Location = New System.Drawing.Point(57, 11)
        Me.pnlMod.Name = "pnlMod"
        Me.pnlMod.Size = New System.Drawing.Size(444, 80)
        Me.pnlMod.TabIndex = 0
        '
        'BtnDisminuir
        '
        Me.BtnDisminuir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDisminuir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDisminuir.Location = New System.Drawing.Point(159, 113)
        Me.BtnDisminuir.Name = "BtnDisminuir"
        Me.BtnDisminuir.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnDisminuir.Office2007CustomColor = System.Drawing.Color.Orange
        Me.BtnDisminuir.Size = New System.Drawing.Size(75, 56)
        Me.BtnDisminuir.TabIndex = 74
        Me.BtnDisminuir.Text = "Disminuir"
        Me.BtnDisminuir.ToolTipText = "Disminuye la ultima selección"
        Me.BtnDisminuir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnDevolucion
        '
        Me.BtnDevolucion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDevolucion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDevolucion.Location = New System.Drawing.Point(2, 172)
        Me.BtnDevolucion.Name = "BtnDevolucion"
        Me.BtnDevolucion.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnDevolucion.Office2007CustomColor = System.Drawing.Color.RoyalBlue
        Me.BtnDevolucion.Size = New System.Drawing.Size(75, 55)
        Me.BtnDevolucion.TabIndex = 75
        Me.BtnDevolucion.Text = "Devolución"
        Me.BtnDevolucion.ToolTipText = "Registra la Devolución de una Venta Cobrada"
        Me.BtnDevolucion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnNotas
        '
        Me.BtnNotas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnNotas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNotas.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNotas.Location = New System.Drawing.Point(396, 661)
        Me.BtnNotas.Name = "BtnNotas"
        Me.BtnNotas.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnNotas.Office2007CustomColor = System.Drawing.Color.Yellow
        Me.BtnNotas.Size = New System.Drawing.Size(61, 77)
        Me.BtnNotas.TabIndex = 76
        Me.BtnNotas.Text = "Notas"
        Me.BtnNotas.ToolTipText = "Disminuye la cantidad"
        Me.BtnNotas.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(2, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 22)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "PUNTOS"
        '
        'LblCantidadPuntos
        '
        Me.LblCantidadPuntos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblCantidadPuntos.BackColor = System.Drawing.Color.Transparent
        Me.LblCantidadPuntos.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidadPuntos.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblCantidadPuntos.Location = New System.Drawing.Point(80, 1)
        Me.LblCantidadPuntos.Name = "LblCantidadPuntos"
        Me.LblCantidadPuntos.Size = New System.Drawing.Size(79, 20)
        Me.LblCantidadPuntos.TabIndex = 10
        Me.LblCantidadPuntos.Text = "14"
        Me.LblCantidadPuntos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.MintCream
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LblCantidadPuntos)
        Me.Panel1.Location = New System.Drawing.Point(3, 661)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(163, 22)
        Me.Panel1.TabIndex = 77
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gold
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(7, 104)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(166, 59)
        Me.Panel2.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(7, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 37)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "CANTIDAD PRODUCTOS"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(4, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "AHORRO"
        '
        'LblAhorro
        '
        Me.LblAhorro.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblAhorro.BackColor = System.Drawing.Color.Transparent
        Me.LblAhorro.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAhorro.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblAhorro.Location = New System.Drawing.Point(97, 3)
        Me.LblAhorro.Name = "LblAhorro"
        Me.LblAhorro.Size = New System.Drawing.Size(114, 18)
        Me.LblAhorro.TabIndex = 9
        Me.LblAhorro.Text = "$353.45"
        Me.LblAhorro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.MintCream
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.LblAhorro)
        Me.Panel4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(172, 661)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(219, 23)
        Me.Panel4.TabIndex = 78
        '
        'FrmTouch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(1024, 745)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtnNotas)
        Me.Controls.Add(Me.BtnDevolucion)
        Me.Controls.Add(Me.BtnDisminuir)
        Me.Controls.Add(Me.grpMod)
        Me.Controls.Add(Me.grpProd)
        Me.Controls.Add(Me.grpSub)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.GridDetalle)
        Me.Controls.Add(Me.TxtCliente)
        Me.Controls.Add(Me.BtnCliente)
        Me.Controls.Add(Me.LblCliente)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.BtnUltimo)
        Me.Controls.Add(Me.BtnAnterior)
        Me.Controls.Add(Me.BtnSiguiente)
        Me.Controls.Add(Me.BtnPrimero)
        Me.Controls.Add(Me.BtnSumar)
        Me.Controls.Add(Me.BtnRestar)
        Me.Controls.Add(Me.BtnRepetir)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.BtnTicketAnt)
        Me.Controls.Add(Me.BtnResumen)
        Me.Controls.Add(Me.BtnEspera)
        Me.Controls.Add(Me.BtnBorrarTodo)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.TxtCantidad)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.BtnConsultar)
        Me.Controls.Add(Me.BtnBorrar)
        Me.Controls.Add(Me.BtnNueva)
        Me.Controls.Add(Me.BtnCerrar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.LblFechaHora)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.PnlStatus)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmTouch"
        Me.Text = "Punto de Venta"
        Me.Panel5.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.grpSub.ResumeLayout(False)
        Me.grpProd.ResumeLayout(False)
        Me.PnlStatus.ResumeLayout(False)
        Me.grpMod.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Enum Status
        Original = -1
        Cerrado = 0
        Abierto = 1
    End Enum

    Public Tipo As Integer

    Private Enum TipoMov
        Entrada = 1
        Salida = 2
    End Enum

    ' Public CreditoGeneral As String 'Cliente Credito General
    Public CorteDetallado As Integer = 0
    Public sFrase As String
    Public Display As Boolean = False
    Public BaudRate As Integer
    Public MaxCaracteres As Integer
    Public NoLineas As Integer
    Public Port As String

    Public Aplicacion As String = ""
    Public MESClave As String = ""
    Public Mesa As String = ""
    Public Piso As String = ""
    Public Comensales As Integer = 0
    Private CLAClave As Integer
    Public ActivaDevolucion As Boolean

    Private iAvanceMenu, iAvanceSubmenu, iAvanceProductos, iAvanceMod As Integer
    Private sClaveProducto As String = ""

    Public NombreBarraCaliente As String
    Public NombreBarraFria As String

    Public SUCClave, ClaveCaja As String
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
    Private sTicketResumen As String = ""
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

    Private mySerialPort As New SerialPort
    Private bCierreApertura As Boolean = False

    Private Periodo As Integer
    Private Mes As Integer


    Private Sub CommPortSetup(ByVal Port As String, ByVal Baud As Integer)
        With mySerialPort
            .PortName = Port
            .BaudRate = Baud
            .DataBits = 8
            .Parity = Parity.None
            .StopBits = StopBits.One
            .Handshake = Handshake.None
        End With
    End Sub

    Public Sub llenaGrid(ByVal sCMDClave As String)

        If sCMDClave = "" Then
            dtComandaDetalle = ModPOS.CrearTabla("ComandaDetalle", _
                                         "DCMClave", "System.String", _
                                         "PROClave", "System.String", _
                                         "Modificador", "System.String", _
                                         "TProducto", "System.Int32", _
                                         "Unidad", "System.String", _
                                         "Cant.", "System.Double", _
                                         "Clave", "System.String", _
                                         "Nombre", "System.String", _
                                         "Precio", "System.Double", _
                                         "PorcDescuento", "System.Double", _
                                         "Descuento", "System.Double", _
                                         "PorcImpuesto", "System.Double", _
                                         "PorcPuntos", "System.Double", _
                                         "Puntos", "System.Double", _
                                         "Subtotal", "System.Double", _
                                         "Fase", "System.Int32", _
                                         "CLAClave", "System.Int32")

            GridDetalle.DataSource = dtComandaDetalle
        Else
            dtComandaDetalle = ModPOS.Recupera_Tabla("sp_comandadetalle_open", "@CMDClave", sCMDClave)
            GridDetalle.DataSource = dtComandaDetalle
        End If
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("DCMClave").Visible = False
        GridDetalle.RootTable.Columns("PROClave").Visible = False
        GridDetalle.RootTable.Columns("Modificador").Visible = False
        GridDetalle.RootTable.Columns("TProducto").Visible = False
        GridDetalle.RootTable.Columns("Unidad").Visible = False
        GridDetalle.RootTable.Columns("Clave").Visible = False
        GridDetalle.RootTable.Columns("PorcDescuento").Visible = False
        GridDetalle.RootTable.Columns("Descuento").Visible = False
        GridDetalle.RootTable.Columns("PorcImpuesto").Visible = False
        GridDetalle.RootTable.Columns("PorcPuntos").Visible = False
        GridDetalle.RootTable.Columns("Puntos").Visible = False
        GridDetalle.RootTable.Columns("Fase").Visible = False
        GridDetalle.RootTable.Columns("CLAClave").Visible = False

        GridDetalle.RootTable.Columns("Cant.").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Precio").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Subtotal").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Cant.").Width = 20
        GridDetalle.RootTable.Columns("Precio").Width = 40
        GridDetalle.RootTable.Columns("Subtotal").Width = 50

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Fase"), Janus.Windows.GridEX.ConditionOperator.GreaterThan, 0)

        ' fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridDetalle.RootTable.FormatConditions.Add(fc)

        GridDetalle.MoveLast()
        If GridDetalle.RowCount > 0 Then
            sClaveProducto = GridDetalle.GetValue("Clave")
        End If
    End Sub

    Private Function validaExistencia() As Boolean
        Dim dtVentaDetalle, dtDisponible As DataTable
        Dim Disponible As Double
        Dim result As Boolean = True

        dtVentaDetalle = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@CMDClave", CMDClave)

        If Not dtVentaDetalle Is Nothing AndAlso dtVentaDetalle.Rows.Count > 0 Then
            Dim i As Integer = 0
            For i = 0 To dtVentaDetalle.Rows.Count - 1

                dtDisponible = ModPOS.SiExisteRecupera("sp_search_existencia", "@PROClave", dtVentaDetalle.Rows(i)("PROClave"), "@ALMClave", ALMClave)

                If Not dtDisponible Is Nothing AndAlso dtDisponible.Rows.Count > 0 Then
                    Disponible = dtDisponible.Rows(0)("Disponible")
                    dtDisponible.Dispose()
                Else
                    Disponible = 0
                End If

                If dtVentaDetalle.Rows(i)("Cantidad") > Disponible Then
                    result = False
                    MessageBox.Show("La cantidad registrada del producto " & CStr(dtVentaDetalle.Rows(i)("Clave")) & " excede la cantidad disponible en el almacén la cual es: " & CStr(Disponible) & ", por lo que no es posible cambiar el tipo de documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit For
                Else
                    result = True
                End If
            Next
            dtVentaDetalle.Dispose()
        End If

        Return result

    End Function

    Private Sub actualizaExistencia(ByVal Tipo As Integer)
        Dim dtVentaDetalle As DataTable
        dtVentaDetalle = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@CMDClave", CMDClave)
        If Not dtVentaDetalle Is Nothing AndAlso dtVentaDetalle.Rows.Count > 0 Then
            Dim i As Integer = 0
            For i = 0 To dtVentaDetalle.Rows.Count - 1
                ModPOS.Ejecuta("sp_actualiza_exist_producto", "@ALMClave", ALMClave, "@PROClave", dtVentaDetalle.Rows(i)("PROClave"), "@TProducto", dtVentaDetalle.Rows(i)("TProducto"), "@Cantidad", dtVentaDetalle.Rows(i)("Cantidad"), "@Mov", Tipo)
            Next
            dtVentaDetalle.Dispose()
        End If
    End Sub

    Public Sub cambiaStatus(ByVal Texto As String, ByVal Status As Status)
        Select Case Status
            Case FrmTouch.Status.Original
                PnlStatus.BackColor = Color.MintCream
                LblStatus.ForeColor = Color.MidnightBlue
                LblStatus.Text = Texto
                LblAtiende.BackColor = Color.MintCream
                LblMesero.BackColor = Color.MintCream
                LblAtiende.ForeColor = Color.MidnightBlue
                LblMesero.ForeColor = Color.MidnightBlue
                LblInfoMesa.ForeColor = Color.MidnightBlue
            Case FrmTouch.Status.Abierto
                PnlStatus.BackColor = Color.ForestGreen
                LblStatus.ForeColor = Color.White
                LblStatus.Text = Texto

                LblAtiende.BackColor = Color.Green
                LblMesero.BackColor = Color.Green
                LblAtiende.ForeColor = Color.White
                LblMesero.ForeColor = Color.White
                LblInfoMesa.ForeColor = Color.White

                If Display = True Then
                    If mySerialPort.IsOpen = True Then
                        Try
                            mySerialPort.Write(Chr(CInt("&H" & "0C")))
                            mySerialPort.Write(sFrase.Substring(0, NoLineas * MaxCaracteres))
                        Catch z As Exception
                            MessageBox.Show(z.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                End If

            Case FrmTouch.Status.Cerrado
                PnlStatus.BackColor = Color.Red
                LblStatus.ForeColor = Color.White
                LblStatus.Text = Texto
                LblAtiende.BackColor = Color.Red
                LblMesero.BackColor = Color.Red
                LblAtiende.ForeColor = Color.White
                LblMesero.ForeColor = Color.White
                LblInfoMesa.ForeColor = Color.White
        End Select
    End Sub

    Public Sub activaBotones(ByVal iTipo As String, ByVal bEnabled As Boolean)

        If bEnabled = False Then
            BtnAceptar.Enabled = False
            BtnCerrar.Enabled = False
            BtnCancelar.Enabled = False
            ' BtnEspera.Enabled = False
            BtnResumen.Enabled = False
            BtnTicketAnt.Enabled = True
            BtnBorrar.Enabled = False
            BtnBorrarTodo.Enabled = False
            BtnConsultar.Enabled = False
            BtnRepetir.Enabled = False
            BtnDisminuir.Enabled = False
            BtnRestar.Enabled = False
            BtnSumar.Enabled = False
            BtnCliente.Enabled = False
            TxtCantidad.Enabled = False
            TxtCliente.Enabled = False
            BtnDevolucion.Enabled = True
        Else

            If iTipo = 5 Then
                BtnAceptar.Enabled = True
                BtnResumen.Enabled = True
            End If
            BtnTicketAnt.Enabled = True
            BtnCerrar.Enabled = True
            BtnCancelar.Enabled = True
            'BtnEspera.Enabled = True
            BtnBorrar.Enabled = True
            BtnBorrarTodo.Enabled = True
            BtnConsultar.Enabled = True
            BtnRepetir.Enabled = True
            BtnDisminuir.Enabled = True
            BtnRestar.Enabled = True
            BtnSumar.Enabled = True
            BtnCliente.Enabled = True
            BtnDevolucion.Enabled = True
            TxtCantidad.Enabled = True
            TxtCliente.Enabled = True
        End If

    End Sub

    Public Sub AgregarProducto(ByVal sDCMClave As String, ByVal sPROClave As String, ByVal sAbreviatura As String, ByVal iTProducto As Integer, ByVal sClave As String, ByVal sNombre As String, ByVal dCantidad As Double, ByVal dPrecio As Double, ByVal dPorcImpuesto As Double, ByVal dPorcDescuento As Double, ByVal dDescuento As Double, ByVal dPorcPuntos As Double, ByVal dPuntos As Double, ByVal iCLAClave As Integer)

        Dim foundRows() As System.Data.DataRow
        If sAbreviatura = "" Then
            foundRows = dtComandaDetalle.Select("PROClave = '" & sPROClave & "' and Precio = " & CStr(dPrecio) & " and Fase = 0")
        Else
            foundRows = dtComandaDetalle.Select("PROClave = '" & sPROClave & "' and Precio = " & CStr(dPrecio) & " and Modificador = '" & sAbreviatura & "' and Fase = 0")
        End If

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtComandaDetalle.NewRow()
            'declara el nombre de la fila
            row1.Item("DCMClave") = sDCMClave
            row1.Item("PROClave") = sPROClave
            row1.Item("TProducto") = iTProducto
            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_unidad_prod", "@PROClave", sPROClave)
            row1.Item("Unidad") = dt.Rows(0)("Unidad")
            dt.Dispose()
            row1.Item("Cant.") = dCantidad
            row1.Item("Clave") = sClave
            row1.Item("Nombre") = sNombre
            row1.Item("Modificador") = sAbreviatura
            row1.Item("Precio") = Redondear(dPrecio, 2)
            row1.Item("PorcDescuento") = dPorcDescuento
            row1.Item("Descuento") = dDescuento
            row1.Item("PorcImpuesto") = dPorcImpuesto
            row1.Item("PorcPuntos") = dPorcPuntos
            row1.Item("Puntos") = dPuntos
            row1.Item("Subtotal") = Redondear(dCantidad * dPrecio, 2)
            row1.Item("Fase") = 0
            row1.Item("CLAClave") = iCLAClave


            dtComandaDetalle.Rows.Add(row1)
            'agrega la fila completo a la tabla
            TotalArticulos += 1
        Else
            'actualiza
            foundRows(0)("Cant.") += dCantidad
            foundRows(0)("Subtotal") += Redondear(dCantidad * dPrecio, 2)
        End If

        GridDetalle.MoveLast()

        If Display = True Then
            Try
                'limpiar
                Dim LimpiarDisplay As String = Chr(12)
                mySerialPort.Write(LimpiarDisplay)

                If NoLineas > 1 Then
                    mySerialPort.Write(FormateaCadena(True, sNombre, MaxCaracteres))

                    'Bajar Cursor
                    Dim BajarCursor As String = Chr(10)
                    mySerialPort.Write(BajarCursor)

                End If


                'Recorrer Izq
                Dim MoverIzq As String = Chr(13)
                mySerialPort.Write(MoverIzq)

                'Escribe segunda linea
                Dim Linea2 As String

                Linea2 = FormateaCadena(False, ModPOS.Redondear(dCantidad, 2).ToString, 2) & _
                " @ " & _
                FormateaCadena(False, Format(ModPOS.Redondear(dPrecio, 2).ToString, "Currency"), 7) & _
                FormateaCadena(False, Format(ModPOS.Redondear((dPrecio * dCantidad), 2).ToString, "Currency"), 8)

                mySerialPort.Write(Linea2)

            Catch ex As Exception
            End Try
        End If

    End Sub


    Private Sub Notas()
        If GridDetalle.GetValue("Fase") = 0 Then

            Dim a As New FrmNota
            a.CMDClave = Me.CMDClave
            a.DCMClave = GridDetalle.GetValue("DCMClave")
            a.PROClave = GridDetalle.GetValue("PROClave")
            a.Clave = GridDetalle.GetValue("Clave")
            a.Nombre = GridDetalle.GetValue("Nombre")
            a.ShowDialog()
            a.Dispose()

        Else
            MessageBox.Show("No es posible agregar nota al registro seleccionado debido a que ya fue impreso", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub Borrar()
        If GridDetalle.GetValue("Fase") = 0 Then
            ModPOS.Ejecuta("sp_elimina_ComandaPartida", _
                       "@ALMClave", ALMClave, _
                       "@CMDClave", CMDClave, _
                       "@DCMClave", GridDetalle.GetValue("DCMClave"), _
                       "@PROClave", GridDetalle.GetValue("PROClave"), _
                       "@Cantidad", GridDetalle.GetValue("Cant."))

            'Actualiza Comanda

            TotalPuntos -= GridDetalle.GetValue("Puntos") * GridDetalle.GetValue("Cant.")
            TotalAhorro -= (GridDetalle.GetValue("Descuento") * (1 + GridDetalle.GetValue("PorcImpuesto"))) * GridDetalle.GetValue("Cant.")
            TotalVenta -= GridDetalle.GetValue("Precio") * GridDetalle.GetValue("Cant.")
            SaldoVenta = TotalVenta
            TotalArticulos -= 1


            Dim foundRows() As System.Data.DataRow
            foundRows = dtComandaDetalle.Select("DCMClave = '" & GridDetalle.GetValue("DCMClave") & "'")
            If foundRows.Length > 0 Then
                dtComandaDetalle.Rows.Remove(foundRows(0))
                GridDetalle.MoveLast()
            End If
            LblCantidadPuntos.Text = CStr(ModPOS.Redondear(TotalPuntos, 2))
            LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
            LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

            If Moneda <> MonedaCambio Then
                If TotalVenta > 0 Then
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                End If
            End If

        Else
            MessageBox.Show("No es posible borrar el registro seleccionado debido a que ya fue impreso", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BorrarTodo()
        Dim foundRows() As System.Data.DataRow
        foundRows = dtComandaDetalle.Select("Fase = 0 ")
        If foundRows.Length > 0 Then
            'inserta metodos de pago
            Dim z As Integer
            For z = 0 To foundRows.GetUpperBound(0)
                ModPOS.Ejecuta("sp_elimina_ComandaPartida", _
                       "@ALMClave", ALMClave, _
                       "@CMDClave", CMDClave, _
                       "@DCMClave", foundRows(z)("DCMClave"), _
                       "@PROClave", foundRows(z)("PROClave"), _
                       "@Cantidad", foundRows(z)("Cant."))

                'Actualiza Comanda



                TotalPuntos -= foundRows(z)("Puntos") * foundRows(z)("Cant.")
                TotalAhorro -= (foundRows(z)("Descuento") * (1 + foundRows(z)("PorcImpuesto"))) * foundRows(z)("Cant.")
                TotalVenta -= foundRows(z)("Precio") * foundRows(z)("Cant.")
                SaldoVenta = TotalVenta
                TotalArticulos -= 1

                dtComandaDetalle.Rows.Remove(foundRows(z))

            Next

            GridDetalle.MoveLast()

            LblCantidadPuntos.Text = CStr(ModPOS.Redondear(TotalPuntos, 2))
            LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
            LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

            If Moneda <> MonedaCambio Then
                If TotalVenta > 0 Then
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                End If
            End If

        Else
            MessageBox.Show("No es posible borrar todos los registros debido a que ya han sido impresos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Function AgregaPartida(ByVal dtProducto As DataTable, ByVal sAbreviatura As String) As Boolean

        If Not dtProducto Is Nothing Then
            'Bloquea al cliente para no permitir que se modifique la lista de precios cuando ya hay productos en la venta


            Dim sPROClave As String = dtProducto.Rows(0)("PROClave")
            Dim sClave As String = dtProducto.Rows(0)("Clave")
            Dim sNombre As String = dtProducto.Rows(0)("Nombre") & " " & sAbreviatura
            Dim dCantidad As Double = dtProducto.Rows(0)("Cantidad")
            Dim dCosto As Double = dtProducto.Rows(0)("Costo")
            Dim dPrecioBruto As Double = dtProducto.Rows(0)("PrecioBruto")
            Dim dDescPorc As Double = dtProducto.Rows(0)("DescPorc")
            Dim iTProducto As Integer = dtProducto.Rows(0)("TProducto")
            Dim iSeguimiento As Integer = dtProducto.Rows(0)("Seguimiento")
            Dim iDiasGarantia As Integer = dtProducto.Rows(0)("DiasGarantia")
            Dim iNumDecimales As Integer = dtProducto.Rows(0)("Num_Decimales")


            Dim dGeneralNeto As Double = TruncateToDecimal(dtProducto.Rows(0)("PrecioNeto"), 2)
            Dim dMinimoNeto As Double = TruncateToDecimal(dtProducto.Rows(0)("MinimoNeto"), 2)
            Dim bValidaMinimo As Boolean = IIf(dGeneralNeto = dMinimoNeto, False, True)

            dtProducto.Dispose()

            If dCantidad = 0 Then
                Cantidad = 1
                TxtCantidad.Text = "1"
                MessageBox.Show("El producto no permite decimales o la cantidad debe ser mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If

            PorcImpProducto = ModPOS.RecuperaImpuesto(SUCClave, sPROClave, TImpuesto)

            Dim dImporteNeto As Double

            If TImpuesto = 1 Then
                dImporteNeto = dGeneralNeto
            End If

            ' Dim dImporteNeto As Double = ModPOS.Redondear(dPrecioBruto * (1 + PorcImpProducto), 2)
            Dim dDescuentoImp As Double = dImporteNeto * dDescPorc

            If CambiaPrecio Then

                Dim a As New FrmAddProducto
                a.SUCClave = SUCClave
                a.ALMClave = ALMClave
                a.PDVClave = PDVClave
                a.TImpuesto = TImpuesto
                a.PREClave = ListaPrecio
                a.PROClave = sPROClave
                a.CTEClave = CTEClaveActual
                a.NombreCliente = CTENombreActual
                a.Clave = sClave
                a.Nombre = sNombre
                a.ImporteNeto = dImporteNeto
                a.dCantidad = dCantidad
                a.Costo = dCosto
                a.dPrecioUnitario = dPrecioBruto
                a.FactorImpuesto = PorcImpProducto
                a.DescImp = dDescuentoImp
                a.PorcDesc = dDescPorc
                a.NumDecimal = iNumDecimales
                a.ModificaPrecioServicio = False
                a.iTProducto = iTProducto
                a.CambiaPrecio = USRCambiaPrecio
                a.PorcMaxDesc = PorcMaxDesc
                a.MinimoNeto = dMinimoNeto
                a.bValidaMinimo = bValidaMinimo

                'a.dVolumen = dVolumen
                'a.dVolumenImp = dVolumenImp
                'a.VENClave = VENClave
                'a.GrupoMaterial = iGrupoMaterial
                'a.Sector = iSector
                'a.DescGeneral = dDescGeneralPor
                'a.DescGeneralImporte = dDescGeneralImp
                'a.KgLt = iKgLt
                'a.Peso = dPeso
                'a.sTipoDesc = sTipoDesc
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    dCantidad = a.dCantidad
                   
                    dDescPorc = a.PorcDesc
                    dDescuentoImp = a.DescImp
                    dImporteNeto = a.ImporteNeto
                    dPrecioBruto = a.dPrecioUnitario
                    'sAutoriza = a.sAutoriza
                    'UnidadesKilo = a.UnidadesKilo
                    'sTipoDesc = a.sTipoDesc
                    'dDescGeneralImp = a.DescGeneralImporte
                    'dVolumen = a.dVolumen
                    'dVolumenImp = a.dVolumenImp
                    a.Dispose()

                Else
                    a.Dispose()

                    Cantidad = 1
                    TxtCantidad.Text = "1"
                    'sAutoriza = ""
                    'dPeso = 0

                    '  Return Busca
                End If
                'Si Cambia Precio = True 
                
            End If

            'SI VALIDA INVENTARIO

            If ValidaInventario = True Then

                Dim Disponible As Double
                Dim dtDisponible As DataTable
                dtDisponible = ModPOS.SiExisteRecupera("sp_search_existencia", "@PROClave", sPROClave, "@ALMClave", ALMClave)
                If Not dtDisponible Is Nothing AndAlso dtDisponible.Rows.Count > 0 Then
                    Disponible = dtDisponible.Rows(0)("Disponible")
                    dtDisponible.Dispose()
                Else
                    Disponible = 0
                End If

                If dCantidad > Disponible Then
                    MessageBox.Show("La cantidad registrada excede la cantidad disponible en el almacén origen, el disponible actual es de: " & CStr(Disponible), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Function
                End If

            End If

            Dim YaExiste As Boolean = False
            Dim DCMClave As String = ""

            Dim dtDetalle As DataTable = ModPOS.SiExisteRecupera("sp_comanda_detalle", "@CMDClave", CMDClave, "@PROClave", sPROClave, "@Subtotal", (dImporteNeto - dDescuentoImp), "@Abreviatura", sAbreviatura)


            If dtDetalle Is Nothing Then
                YaExiste = False
            Else

                DCMClave = dtDetalle.Rows(0)("DCMClave")
                YaExiste = True
                dtDetalle.Dispose()
            End If


            If CambiarCliente = True Then
                BtnCliente.Enabled = False
                TxtCliente.Enabled = False
                CambiarCliente = False
            End If

            ' AGREGAR PRODUCTO A LISTA

            Dim dPrecioNeto As Double = ModPOS.Redondear((dPrecioBruto - (dPrecioBruto * dDescPorc)) * (1 + PorcImpProducto), 2)


            If YaExiste Then

                'Actualiza Cantidad de producto
                ModPOS.Ejecuta("sp_act_ComandaDetalle", _
                "@ALMClave", ALMClave, _
                "@CMDClave", CMDClave, _
                "@DCMClave", DCMClave, _
                "@PROClave", sPROClave, _
                "@TProducto", iTProducto, _
                "@Cantidad", dCantidad)

            Else
                'Inserta Producto
                DCMClave = ModPOS.obtenerLlave

                ModPOS.Ejecuta("sp_inserta_ComandaDetalle", _
                "@DCMClave", DCMClave, _
                "@CMDClave", CMDClave, _
                "@PROClave", sPROClave, _
                "@Modificador", sAbreviatura, _
                "@Costo", dCosto, _
                "@PrecioBruto", dPrecioBruto, _
                "@PuntosPor", 0, _
                "@PuntosImp", 0, _
                "@PorcImp", PorcImpProducto, _
                "@DescuentoPor", dDescPorc, _
                "@DescuentoImp", dPrecioBruto * dDescPorc, _
                "@ImpuestoImp", (dPrecioBruto - (dPrecioBruto * dDescPorc)) * PorcImpProducto, _
                "@Cantidad", dCantidad, _
                "@ALMClave", ALMClave, _
                "@TProducto", iTProducto, _
                "@CLAClave", CLAClave, _
                "@Usuario", ModPOS.UsuarioActual)

                'Inserta detalle de Impuestos por partida
                ModPOS.InsertaComandaImpuesto(DCMClave, sPROClave, dPrecioBruto - (dPrecioBruto * dDescPorc), TImpuesto, SUCClave)

            End If

            AgregarProducto(DCMClave, sPROClave, sAbreviatura, iTProducto, sClave, sNombre, dCantidad, dPrecioNeto, PorcImpProducto, dDescPorc, dDescuentoImp, 0, 0, CLAClave)

            TotalPuntos += (0)
            TotalAhorro += ((dDescuentoImp * (1 + PorcImpProducto)) * dCantidad)
            TotalVenta += dPrecioNeto * dCantidad
            SaldoVenta = TotalVenta

            LblCantidadPuntos.Text = CStr(ModPOS.Redondear(TotalPuntos, 2))
            LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
            LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

            If Moneda <> MonedaCambio Then
                If TotalVenta > 0 Then
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                End If
            End If

            If Agotamiento Then
                Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_agotamiento", "@ALMClave", ALMClave, "@PROClave", sPROClave, "@Cantidad", dCantidad)
                If Not dt Is Nothing Then
                    MessageBox.Show(sClave & ", " & sNombre & "se ha agotado, solicitar al proveedor: " & CStr(Redondear(dCantidad, 2)), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dt.Dispose()
                End If
            End If

        Else
            Beep()
            MessageBox.Show("El Código no corresponde a un Producto Existente o Activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Cantidad = 1
        TxtCantidad.Text = "1"
        Return False
    End Function

    Private Sub AgregaPlatillo(ByVal Codigo As String, ByVal sAbreviatura As String)
        If ComandaCerrada = False Then
            'Valida que el campo producto no se encuentre vacio
            If Not Codigo = vbNullString Then
                'Si el campo cantidad esta vacio lo cambia a 1 por defecto
                If TxtCantidad.Text = vbNullString OrElse CDbl(TxtCantidad.Text) = 0 Then
                    Cantidad = 1
                    TxtCantidad.Text = "1"
                Else
                    Cantidad = CDbl(TxtCantidad.Text)
                End If
                'Si es el primer articulo, recupera la lista de precio del cliente actual
                If TotalArticulos = 0 Then
                    Dim dtCliente As DataTable
                    dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", CTEClaveActual)
                    ListaPrecio = dtCliente.Rows(0)("PREClave")
                    TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                    dtCliente.Dispose()
                End If
                'Busca y recupera los datos del producto
                Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 1, "@Busca", Codigo, "@SUCClave", SUCClave, "@PREClave", ListaPrecio, "@CTEClave", CTEClaveActual, "@Cantidad", Cantidad, "@Char", cReplace)
                AgregaPartida(dt, sAbreviatura)
                If Not dt Is Nothing Then
                    dt.Dispose()
                End If
            End If
        End If
    End Sub

    Private Sub BtnNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNueva.Click
        If ComandaCerrada Then

            Dim dt As DataTable

            If Moneda <> MonedaCambio Then
                dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
                MonedaRef = dt.Rows(0)("Referencia")
                TipoCambio = dt.Rows(0)("TipoCambio")
                dt.Dispose()
            Else
                LblTipoCambio.Text = ""
            End If

            If SolicitaVendedor Then
                Dim a As New FrmSolicitaUsuario
                a.bTouch = True
                a.LblAtiende.Text = "Mesero que Atiende"
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    Me.MeseroClave = a.AtiendeClave
                    Me.MeseroNombre = a.AtiendeNombre
                    LblMesero.Text = MeseroNombre
                Else
                    MessageBox.Show("No es posible crear una nueva comanda debido a que no ha sido registrado el usuario que Atiende", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                a.Dispose()
            End If


            CTEClaveActual = CTEClaveInicial
            CTENombreActual = CTENombreInicial
            LblCliente.Text = CTENombreActual

            cambiaStatus("COMANDA (ABIERTA)", Status.Abierto)


            If Tipo = 5 Then
                ModPOS.Ejecuta("sp_act_edo_mesa", "@MESClave", MESClave, "@Estado", 2)
                If Not ModPOS.Plano Is Nothing Then
                    ModPOS.Plano.iColorMesa = 2
                End If
            End If

            dtComandaDetalle.Clear()

            If CambiarCliente = False Then
                BtnCliente.Enabled = True
                TxtCliente.Enabled = True
                CambiarCliente = True
            End If

            dt = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 1, "@PDVClave", PDVClave)

            If dt Is Nothing Then
                ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 1, "@PDVClave", PDVClave)
                Folio = 1
                Periodo = Today.Year
                Mes = Today.Month
            Else
                Periodo = dt.Rows(0)("Periodo")
                Mes = dt.Rows(0)("Mes")
                Folio = CInt(dt.Rows(0)("UltimoConsecutivo")) + 1
                ModPOS.Ejecuta("sp_act_folio", "@Tipo", 1, "@PDVClave", PDVClave, "@Incremento", 1)

                dt.Dispose()
            End If

            LblFolio.Text = Referencia & "-" & CStr(Folio) & "-" & CStr(Periodo) & CStr(Mes)


            CMDClave = ModPOS.obtenerLlave()

            CajeroClave = ModPOS.UsuarioActual

            ModPOS.Ejecuta("sp_borra_Comanda", "@PDVClave", PDVClave, "@MESClave", MESClave, "@Tipo", Tipo)

            ModPOS.Ejecuta("sp_crea_comanda", _
            "@CMDClave", CMDClave, _
            "@PDVClave", PDVClave, _
            "@MESClave", MESClave, _
            "@Comensales", Comensales, _
            "@CAJClave", CAJClave, _
            "@Folio", LblFolio.Text, _
            "@CTEClave", CTEClaveActual, _
            "@Mesero", MeseroClave, _
            "@Cajero", CajeroClave, _
            "@Usuario", ModPOS.UsuarioActual)

            activaBotones(Tipo, True)

            ComandaCerrada = False
            GeneraMovSalida = True
            ComandaNueva = True


            TotalArticulos = 0
            TotalPuntos = 0
            TotalVenta = 0
            TotalRecibido = 0
            TotalCambio = 0
            TotalAhorro = 0

            If Moneda <> MonedaCambio Then
                If TotalVenta > 0 Then
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                End If
            End If


        Else
            Beep()
            MessageBox.Show("No es posible crear una nueva comanda debido a que la comanda actual no ha sido Cerrada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub TxtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidad.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtCantidad.Text = vbNullString Then
                If CDbl(TxtCantidad.Text) = 0 Then
                    Cantidad = 1
                    TxtCantidad.Text = CStr(Cantidad)
                Else
                    Cantidad = Math.Abs(CDbl(TxtCantidad.Text))
                End If
            Else
                Cantidad = 1
                TxtCantidad.Text = CStr(Cantidad)
            End If
        End If
    End Sub

    'Private Sub agregaRow(ByVal dt As DataTable, ByVal PRMClave As String, ByVal TipoCalculoBase As Integer, ByVal Clave As String, ByVal Descripcion As String, ByVal DCMClave As String, ByVal PROClave As String, ByVal Cantidad As Double, ByVal Promocion As Double, ByVal Precio As Double, ByVal PrecioNeto As Double, ByVal TotalPartida As Double)
    '    Dim row1 As DataRow
    '    row1 = dt.NewRow()
    '    row1.Item("PRMClave") = PRMClave
    '    row1.Item("TipoCalculoBase") = TipoCalculoBase
    '    row1.Item("Clave") = Clave
    '    row1.Item("Descripcion") = Descripcion
    '    row1.Item("DCMClave") = DCMClave
    '    row1.Item("PROClave") = PROClave
    '    row1.Item("Cantidad") = Cantidad
    '    row1.Item("Promocion") = Promocion
    '    row1.Item("Precio") = Precio
    '    row1.Item("PrecioNeto") = PrecioNeto
    '    row1.Item("TotalPartida") = TotalPartida
    '    dt.Rows.Add(row1)
    'End Sub

    Private Sub agregaRow(ByRef dt As DataTable, ByVal PRMClave As String, ByVal Inicial As Integer, ByVal Final As Integer, ByVal TipoCalculoBase As Integer, ByVal Clave As String, ByVal Descripcion As String, ByVal DVEClave As String, ByVal PROClave As String, ByVal Cantidad As Double, ByVal Promocion As Double, ByVal Precio As Double, ByVal PrecioNeto As Double, ByVal TotalPartida As Double, ByVal MaxNumPromo As Integer, ByVal Saldo As Double, ByVal Iguales As Boolean)
        Dim row1 As DataRow
        row1 = dt.NewRow()
        row1.Item("PRMClave") = PRMClave
        row1.Item("Inicial") = Inicial
        row1.Item("Final") = Final
        row1.Item("TipoCalculoBase") = TipoCalculoBase
        row1.Item("Clave") = Clave
        row1.Item("Descripcion") = Descripcion
        row1.Item("DVEClave") = DVEClave
        row1.Item("PROClave") = PROClave
        row1.Item("Cantidad") = Cantidad
        row1.Item("Promocion") = Promocion
        row1.Item("Precio") = Precio
        row1.Item("PrecioNeto") = PrecioNeto
        row1.Item("TotalPartida") = TotalPartida
        row1.Item("MaxNumPromo") = MaxNumPromo
        row1.Item("Saldo") = Saldo
        row1.Item("Iguales") = Iguales
        dt.Rows.Add(row1)
    End Sub


    Private Sub eliminaRow(ByVal dt As DataTable, ByVal PRMClave As String)
        Dim foundRows() As System.Data.DataRow
        foundRows = dt.Select("PRMClave Like '" & PRMClave & "'")
        dt.Rows.Remove(foundRows(0))
    End Sub

    'Private Sub AplicaPromociones(ByVal PRMClave As String, ByVal Tipo As Integer, ByVal dt As DataTable, ByVal Numero As Integer)
    '    Dim TotalImportePromocion As Double = 0
    '    Dim TotalImporteNetoPromocion As Double = 0
    '    Dim ImportePromocion As Double = 0
    '    Dim i As Integer

    '    Select Case Tipo
    '        Case Is = 1 'Descuentos
    '            'recuperar promocion detalle
    '            Dim dtPromDet As DataTable
    '            Dim CantidadInicial As Double
    '            Dim CantidadFinal As Double

    '            dtPromDet = ModPOS.Recupera_Tabla("sp_detalle_promocion", "@PRMClave", PRMClave)

    '            For i = 0 To dt.Rows.Count - 1

    '                Dim foundRows() As System.Data.DataRow
    '                foundRows = dtPromDet.Select("PROClave Like '" & dt.Rows(i)("PROClave") & "'")

    '                If foundRows.Length > 0 Then
    '                    CantidadInicial = foundRows(0)("Cantidad")
    '                    CantidadFinal = foundRows(0)("CantidadFinal")
    '                Else
    '                    CantidadInicial = 1
    '                    CantidadFinal = 1
    '                End If

    '                If dt.Rows(i)("TipoCalculoBase") = 1 Then
    '                    ImportePromocion = (Numero * CantidadInicial) * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("Precio"))
    '                    TotalImportePromocion += ImportePromocion
    '                    TotalImporteNetoPromocion += (Numero * CantidadInicial) * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("PrecioNeto"))
    '                Else
    '                    If dt.Rows(i)("Cantidad") > CantidadFinal Then
    '                        ImportePromocion = (Numero * CantidadFinal) * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("Precio"))
    '                        TotalImportePromocion += ImportePromocion
    '                        TotalImporteNetoPromocion += (Numero * CantidadFinal) * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("PrecioNeto"))
    '                    Else
    '                        ImportePromocion = (Numero * dt.Rows(i)("Cantidad")) * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("Precio"))
    '                        TotalImportePromocion += ImportePromocion
    '                        TotalImporteNetoPromocion += (Numero * dt.Rows(i)("Cantidad")) * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("PrecioNeto"))
    '                    End If
    '                End If

    '                'ImportePromocion = Numero * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("Precio"))
    '                'TotalImportePromocion += ImportePromocion
    '                'TotalImporteNetoPromocion += Numero * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("PrecioNeto"))

    '                If dt.Rows(i)("Promocion") > 0 Then
    '                    ModPOS.Ejecuta("sp_aplica_promocion_comanda", _
    '                                    "@PRMClave", dt.Rows(i)("PRMClave"), _
    '                                    "@CMDClave", CMDClave, _
    '                                    "@DCMClave", dt.Rows(i)("DCMClave"), _
    '                                    "@PROClave", dt.Rows(i)("PROClave"), _
    '                                    "@Tipo", Tipo, _
    '                                    "@Porcentaje", ImportePromocion / (dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")), _
    '                                    "@Importe", ImportePromocion / dt.Rows(i)("Cantidad"), _
    '                                    "@Usuario", ModPOS.UsuarioActual)

    '                    Dim dtDet As DataTable
    '                    dtDet = ModPOS.SiExisteRecupera("sp_comandadetalle_all", "@CMDClave", CMDClave)
    '                    If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
    '                        ModPOS.RecalculaImpuestoComanda(dtDet, TImpuesto)
    '                        dtDet.Dispose()
    '                    End If

    '                End If
    '            Next

    '            TotalAhorro += TotalImporteNetoPromocion
    '            TotalVenta -= TotalImporteNetoPromocion
    '            SaldoVenta = TotalVenta


    '            'If Moneda <> MonedaCambio Then
    '            '    If TotalVenta > 0 Then
    '            '        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
    '            '    Else
    '            '        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
    '            '    End If
    '            'End If



    '        Case Is = 2 'Bonificacion
    '            For i = 0 To dt.Rows.Count - 1
    '                ImportePromocion = Numero * dt.Rows(i)("Promocion")
    '                TotalImportePromocion += ImportePromocion

    '                If dt.Rows(i)("Promocion") > 0 Then
    '                    ModPOS.Ejecuta("sp_aplica_promocion_comanda", _
    '                                    "@PRMClave", dt.Rows(i)("PRMClave"), _
    '                                    "@CMDClave", CMDClave, _
    '                                    "@DCMClave", dt.Rows(i)("DCMClave"), _
    '                                    "@PROClave", dt.Rows(i)("PROClave"), _
    '                                    "@Tipo", Tipo, _
    '                                    "@Porcentaje", ImportePromocion / (dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")), _
    '                                    "@Importe", ImportePromocion / dt.Rows(i)("Cantidad"), _
    '                                    "@Usuario", ModPOS.UsuarioActual)

    '                    Dim dtDet As DataTable
    '                    dtDet = ModPOS.SiExisteRecupera("sp_comandadetalle_all", "@CMDClave", CMDClave)
    '                    If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
    '                        ModPOS.RecalculaImpuestoComanda(dtDet, TImpuesto)
    '                        dtDet.Dispose()
    '                    End If

    '                End If
    '            Next

    '            TotalAhorro += TotalImportePromocion
    '            TotalVenta -= TotalImportePromocion
    '            SaldoVenta = TotalVenta


    '            'If Moneda <> MonedaCambio Then
    '            '    If TotalVenta > 0 Then
    '            '        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
    '            '    Else
    '            '        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
    '            '    End If
    '            'End If


    '        Case Is = 3 'Productos
    '            ' recupera producto promocion
    '            Dim dtRegalo As DataTable = ModPOS.SiExisteRecupera("sp_recupera_regalo", "PRMClave", PRMClave)

    '            For i = 0 To dtRegalo.Rows.Count - 1

    '                Dim dtDetalle As DataTable = ModPOS.SiExisteRecupera("sp_recupera_detalle_comanda", "@CMDClave", CMDClave, "@PROClave", dtRegalo.Rows(j)("PROClave"), "@Subtotal", 0)

    '                If Not dtDetalle Is Nothing Then
    '                    'Actualiza Cantidad de producto
    '                    ModPOS.Ejecuta("sp_actualiza_ComandaDetalle", _
    '                    "@ALMClave", ALMClave, _
    '                    "@CMDClave", CMDClave, _
    '                    "@PROClave", dtRegalo.Rows(j)("PROClave"), _
    '                    "@TProducto", dtRegalo.Rows(j)("TProducto"), _
    '                    "@Cantidad", Numero * dtRegalo.Rows(j)("Cantidad"))

    '                    dtDetalle.Dispose()
    '                Else
    '                    'Inserta Producto
    '                    Dim DCMClave As String = ModPOS.obtenerLlave

    '                    ModPOS.Ejecuta("sp_inserta_ComandaDetalle", _
    '                    "@DCMClave", DCMClave, _
    '                    "@CMDClave", CMDClave, _
    '                    "@PROClave", dtRegalo.Rows(j)("PROClave"), _
    '                    "@Costo", dtRegalo.Rows(j)("Costo"), _
    '                    "@PrecioBruto", 0, _
    '                    "@PuntosPor", 0, _
    '                    "@PuntosImp", 0, _
    '                    "@DescuentoPor", 0, _
    '                    "@DescuentoImp", 0, _
    '                    "@ImpuestoImp", 0, _
    '                    "@PorcImp", 0, _
    '                    "@Cantidad", Numero * dtRegalo.Rows(j)("Cantidad"), _
    '                    "@ALMClave", ALMClave, _
    '                    "@TProducto", dtRegalo.Rows(j)("TProducto"), _
    '                    "@Usuario", ModPOS.UsuarioActual)

    '                    TotalArticulos += 1

    '                End If


    '            Next

    '            dtRegalo.Dispose()

    '        Case Is = 4 'Puntos

    '            For i = 0 To dt.Rows.Count - 1
    '                ImportePromocion = Numero * dt.Rows(i)("Promocion")
    '                TotalImporteNetoPromocion += ImportePromocion

    '                If dt.Rows(i)("Promocion") > 0 Then
    '                    ModPOS.Ejecuta("sp_aplica_promocion_comanda", _
    '                                    "@PRMClave", dt.Rows(i)("PRMClave"), _
    '                                    "@CMDClave", CMDClave, _
    '                                    "@DCMClave", dt.Rows(i)("DVEClave"), _
    '                                    "@PROClave", dt.Rows(i)("PROClave"), _
    '                                    "@Tipo", Tipo, _
    '                                    "@Porcentaje", ImportePromocion / (dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")), _
    '                                    "@Importe", ImportePromocion / dt.Rows(i)("Cantidad"), _
    '                                    "@Usuario", ModPOS.UsuarioActual)
    '                End If
    '            Next

    '            TotalPuntos += ImportePromocion
    '    End Select
    '    dt.Dispose()
    'End Sub

    Private Sub AplicaPromociones(ByVal Tipo As Integer, ByRef dt As DataTable)
        Dim TotalImportePromocion As Double = 0
        Dim TotalImporteNetoPromocion As Double = 0
        Dim ImportePromocion As Double = 0
        Dim i As Integer

        Select Case Tipo
            Case Is = 1 'Descuentos
                'recuperar promocion detalle

                For i = 0 To dt.Rows.Count - 1

                    If dt.Rows(i)("TipoCalculoBase") = 1 Then
                        If dt.Rows(i)("Iguales") = True Then
                            ImportePromocion = (dt.Rows(i)("MaxNumPromo") * dt.Rows(i)("Inicial")) * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("Precio"))
                            TotalImportePromocion += ImportePromocion
                            TotalImporteNetoPromocion += (dt.Rows(i)("MaxNumPromo") * dt.Rows(i)("Inicial")) * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("PrecioNeto"))
                        Else
                            ImportePromocion = dt.Rows(i)("Saldo") * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("Precio"))
                            TotalImportePromocion += ImportePromocion
                            TotalImporteNetoPromocion += dt.Rows(i)("Saldo") * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("PrecioNeto"))
                        End If
                    Else
                        If dt.Rows(i)("Iguales") = True Then
                            ImportePromocion = dt.Rows(i)("Cantidad") * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("Precio"))
                            TotalImportePromocion += ImportePromocion
                            TotalImporteNetoPromocion += dt.Rows(i)("Cantidad") * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("PrecioNeto"))
                        Else
                            ImportePromocion = dt.Rows(i)("Saldo") * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("Precio"))
                            TotalImportePromocion += ImportePromocion
                            TotalImporteNetoPromocion += dt.Rows(i)("Saldo") * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("PrecioNeto"))

                        End If

                    End If

                    If dt.Rows(i)("Promocion") > 0 Then
                        ModPOS.Ejecuta("sp_aplica_promocion_comanda", _
                                        "@PRMClave", dt.Rows(i)("PRMClave"), _
                                        "@CMDClave", CMDClave, _
                                        "@DCMClave", dt.Rows(i)("DVEClave"), _
                                        "@PROClave", dt.Rows(i)("PROClave"), _
                                        "@Tipo", Tipo, _
                                        "@Porcentaje", ImportePromocion / (dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")), _
                                        "@Importe", ImportePromocion / dt.Rows(i)("Cantidad"), _
                                        "@Usuario", ModPOS.UsuarioActual)

                        Dim dtDet As DataTable
                        dtDet = ModPOS.SiExisteRecupera("sp_comandadetalle_all", "@CMDClave", CMDClave)
                        If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
                            ModPOS.RecalculaImpuesto(dtDet, TImpuesto, SUCClave)
                            dtDet.Dispose()
                        End If

                    End If
                Next

                TotalAhorro += TotalImporteNetoPromocion
                TotalVenta -= TotalImporteNetoPromocion
                SaldoVenta = TotalVenta

            Case Is = 2 'Bonificacion
                For i = 0 To dt.Rows.Count - 1
                    If dt.Rows(i)("Iguales") = True Then
                        ImportePromocion = dt.Rows(i)("MaxNumPromo") * dt.Rows(i)("Promocion")
                    Else
                        Dim dPorcentaje As Double
                        dPorcentaje = dt.Rows(i)("Saldo") / dt.Rows(i)("MaxNumPromo")
                        If dt.Rows(i)("TipoCalculoBase") = 1 Then ' si Cantidad
                            ImportePromocion = (dt.Rows(i)("MaxNumPromo") * dt.Rows(i)("Promocion")) * dPorcentaje
                        Else ' Si rango
                            ImportePromocion = dt.Rows(i)("Promocion") * dPorcentaje
                        End If
                    End If

                    TotalImportePromocion += ImportePromocion

                    If dt.Rows(i)("Promocion") > 0 Then
                        ModPOS.Ejecuta("sp_aplica_promocion_comanda", _
                                        "@PRMClave", dt.Rows(i)("PRMClave"), _
                                        "@CMDClave", CMDClave, _
                                        "@DCMClave", dt.Rows(i)("DVEClave"), _
                                        "@PROClave", dt.Rows(i)("PROClave"), _
                                        "@Tipo", Tipo, _
                                        "@Porcentaje", ImportePromocion / (dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")), _
                                        "@Importe", ImportePromocion / dt.Rows(i)("Cantidad"), _
                                        "@Usuario", ModPOS.UsuarioActual)

                        Dim dtDet As DataTable
                        dtDet = ModPOS.SiExisteRecupera("sp_comandadetalle_all", "@CMDClave", CMDClave)
                        If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
                            ModPOS.RecalculaImpuesto(dtDet, TImpuesto, SUCClave)
                            dtDet.Dispose()
                        End If

                    End If
                Next

                TotalAhorro += TotalImportePromocion
                TotalVenta -= TotalImportePromocion
                SaldoVenta = TotalVenta


            Case Is = 3 'Productos
                ' recupera producto promocion

                Dim dMonto As Double

                If dt.Rows(0)("Iguales") = True Then
                    dMonto = IIf(dt.Compute("Sum(MaxNumPromo)", "MaxNumPromo > 0") Is System.DBNull.Value, 0, dt.Compute("Sum(MaxNumPromo)", "MaxNumPromo > 0"))
                Else
                    If dt.Rows(0)("TipoCalculoBase") = 1 Then ' si Cantidad
                        dMonto = dt.Rows(0)("MaxNumPromo")
                    Else 'Rango
                        dMonto = 1
                    End If
                End If

                Dim dtRegalo As DataTable = ModPOS.SiExisteRecupera("sp_recupera_regalo", "@SUCClave", SUCClave, "@PRMClave", dt.Rows(0)("PRMClave"))

                Dim j As Integer
                For j = 0 To dtRegalo.Rows.Count - 1

                    Dim DCMClave As String
                    Dim dtDetalle As DataTable = ModPOS.SiExisteRecupera("sp_recupera_detalle_comanda", "@CMDClave", CMDClave, "@PROClave", dtRegalo.Rows(j)("PROClave"), "@Subtotal", 0)

                    If Not dtDetalle Is Nothing Then

                        DCMClave = dtDetalle.Rows(0)("DCMClave")

                        'Actualiza Cantidad de producto
                        ModPOS.Ejecuta("sp_actualiza_ComandaDetalle", _
                        "@ALMClave", ALMClave, _
                        "@CMDClave", CMDClave, _
                        "@PROClave", dtRegalo.Rows(j)("PROClave"), _
                        "@TProducto", dtRegalo.Rows(j)("TProducto"), _
                        "@Cantidad", dMonto * dtRegalo.Rows(j)("Cantidad"))

                        dtDetalle.Dispose()
                    Else
                        'Inserta Producto
                        DCMClave = ModPOS.obtenerLlave

                        ModPOS.Ejecuta("sp_inserta_ComandaDetalle", _
                        "@DCMClave", DCMClave, _
                        "@CMDClave", CMDClave, _
                        "@PROClave", dtRegalo.Rows(j)("PROClave"), _
                        "@Modificador", "", _
                        "@Costo", dtRegalo.Rows(j)("Costo"), _
                        "@PrecioBruto", 0, _
                        "@PuntosPor", 0, _
                        "@PuntosImp", 0, _
                        "@DescuentoPor", 0, _
                        "@DescuentoImp", 0, _
                        "@ImpuestoImp", 0, _
                        "@PorcImp", 0, _
                        "@Cantidad", dMonto * dtRegalo.Rows(j)("Cantidad"), _
                        "@ALMClave", ALMClave, _
                        "@TProducto", dtRegalo.Rows(j)("TProducto"), _
                        "@Usuario", ModPOS.UsuarioActual)

                        TotalArticulos += 1

                    End If


                    'SI REQUIERE SEGUIMIENTO DE SERIAL
                    If dtRegalo.Rows(j)("Seguimiento") = 2 Then
                        Dim SerialReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = dMonto * dtRegalo.Rows(j)("Promocion")
                        Do
                            Dim a As New FrmSerial
                            a.DOCClave = CMDClave
                            a.PROClave = dtRegalo.Rows(j)("PROClave")
                            a.Clave = dtRegalo.Rows(j)("Clave")
                            a.Nombre = dtRegalo.Rows(j)("Nombre")
                            a.Cantidad = PorRegistrar
                            a.Dias = dtRegalo.Rows(j)("Dias")
                            a.TipoDoc = 1
                            a.TipoMov = 2
                            a.ShowDialog()
                            SerialReg = SerialReg + a.NumSerialRegistrados
                            PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                            a.Dispose()
                        Loop Until SerialReg = dMonto * dtRegalo.Rows(j)("Promocion") OrElse PorRegistrar = 0
                    End If

                    'SI REQUIERE SEGUIMIENTO DE LOTE
                    If dtRegalo.Rows(j)("Seguimiento") = 3 Then
                        Dim LoteReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = dMonto * dtRegalo.Rows(j)("Promocion")
                        Do
                            Dim a As New FrmLote
                            a.DOCClave = CMDClave
                            a.PROClave = dtRegalo.Rows(j)("PROClave")
                            a.Clave = dtRegalo.Rows(j)("Clave")
                            a.Nombre = dtRegalo.Rows(j)("Nombre")
                            a.CantXRegistrar = PorRegistrar
                            a.TipoDoc = 1
                            a.TipoMov = 2
                            a.ShowDialog()
                            LoteReg = LoteReg + a.NumSerialRegistrados
                            PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                            a.Dispose()
                        Loop Until LoteReg = dMonto * dtRegalo.Rows(j)("Promocion") OrElse PorRegistrar = 0
                    End If


                    Dim dtPro As DataTable

                    dtPro = ModPOS.Recupera_Tabla("sp_recupera_linea", "@PROClave", dtRegalo.Rows(j)("PROClave"))

                    Dim iCLAClave As Integer
                    If dtPro.Rows.Count > 0 Then
                        iCLAClave = dtPro.Rows(0)("CLAClave")
                    Else
                        iCLAClave = 0
                    End If

                    AgregarProducto(DCMClave, dtRegalo.Rows(j)("PROClave"), "", dtRegalo.Rows(j)("TProducto"), dtRegalo.Rows(j)("Clave"), dtRegalo.Rows(j)("Nombre"), dMonto * dtRegalo.Rows(j)("Cantidad"), 0, 0, 0, 0, 0, 0, iCLAClave)

                Next

                dtRegalo.Dispose()

            Case Is = 4 'Puntos

                For i = 0 To dt.Rows.Count - 1

                    If dt.Rows(i)("Iguales") = True Then
                        ImportePromocion = dt.Rows(i)("MaxNumPromo") * dt.Rows(i)("Promocion")
                    Else
                        Dim dPorcentaje As Double
                        dPorcentaje = dt.Rows(i)("Saldo") / dt.Rows(i)("MaxNumPromo")
                        If dt.Rows(i)("TipoCalculoBase") = 1 Then ' si Cantidad
                            ImportePromocion = (dt.Rows(i)("MaxNumPromo") * dt.Rows(i)("Promocion")) * dPorcentaje
                        Else 'Rango
                            ImportePromocion = dt.Rows(i)("Promocion") * dPorcentaje
                        End If
                    End If

                    TotalImporteNetoPromocion += ImportePromocion

                    If dt.Rows(i)("Promocion") > 0 Then
                        ModPOS.Ejecuta("sp_aplica_promocion_comanda", _
                                        "@PRMClave", dt.Rows(i)("PRMClave"), _
                                        "@CMDClave", CMDClave, _
                                        "@DCMClave", dt.Rows(i)("DVEClave"), _
                                        "@PROClave", dt.Rows(i)("PROClave"), _
                                        "@Tipo", Tipo, _
                                        "@Porcentaje", ImportePromocion / (dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")), _
                                        "@Importe", ImportePromocion / dt.Rows(i)("Cantidad"), _
                                        "@Usuario", ModPOS.UsuarioActual)
                    End If
                Next

                TotalPuntos += ImportePromocion

                ModPOS.Ejecuta("sp_add_puntos", "@CTEClave", CTEClaveActual, "@Cantidad", TotalPuntos)

            Case Is = 5 'Menor Precio


                Dim dMonto As Double

                If dt.Rows(i)("Iguales") = True Then
                    dMonto = IIf(dt.Compute("Sum(MaxNumPromo)", "MaxNumPromo > 0") Is System.DBNull.Value, 0, dt.Compute("Sum(MaxNumPromo)", "MaxNumPromo > 0"))
                Else
                    If dt.Rows(i)("TipoCalculoBase") = 1 Then ' si Cantidad
                        dMonto = dt.Rows(i)("MaxNumPromo")
                    Else 'Rango
                        dMonto = 1
                    End If
                End If


                For i = 0 To dt.Rows.Count - 1

                    If dMonto >= dt.Rows(i)("Cantidad") Then
                        ImportePromocion = dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")
                        TotalImportePromocion += ImportePromocion
                        TotalImporteNetoPromocion += dt.Rows(i)("PrecioNeto") * dt.Rows(i)("Cantidad")
                        dMonto -= dt.Rows(i)("Cantidad")
                    Else
                        ImportePromocion = dt.Rows(i)("Precio") * dMonto
                        TotalImportePromocion += ImportePromocion
                        TotalImporteNetoPromocion += dt.Rows(i)("PrecioNeto") * dMonto
                        dMonto = 0
                    End If

                    If ImportePromocion > 0 Then
                        ModPOS.Ejecuta("sp_aplica_promocion_comanda", _
                                      "@PRMClave", dt.Rows(i)("PRMClave"), _
                                      "@CMDClave", CMDClave, _
                                      "@DCMClave", dt.Rows(i)("DVEClave"), _
                                      "@PROClave", dt.Rows(i)("PROClave"), _
                                      "@Tipo", Tipo, _
                                      "@Porcentaje", ImportePromocion / (dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")), _
                                      "@Importe", ImportePromocion / dt.Rows(i)("Cantidad"), _
                                      "@Usuario", ModPOS.UsuarioActual)


                        Dim dtDet As DataTable
                        dtDet = ModPOS.SiExisteRecupera("sp_comandadetalle_all", "@CMDClave", CMDClave)
                        If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
                            ModPOS.RecalculaImpuesto(dtDet, TImpuesto, SUCClave)
                            dtDet.Dispose()
                        End If

                    End If


                    If dMonto <= 0 Then
                        Exit For
                    End If

                Next

                TotalAhorro += TotalImporteNetoPromocion
                TotalVenta -= TotalImporteNetoPromocion
                SaldoVenta = TotalVenta

                If Moneda <> MonedaCambio Then
                    If TotalVenta > 0 Then
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                    End If
                End If

        End Select
        dt.Dispose()
    End Sub


    Private Sub verificaPromocion(ByVal dtPromocion As DataTable)
        Dim y, x As Integer
        Dim AplicaPromocion As Boolean = False
        Dim dtPromDet, dtAplicaPromo As DataTable
        Dim MaxNumPromocion As Integer = 0
        Dim iCantidad, iSaldo, dImporte As Double

        dtAplicaPromo = ModPOS.CrearTabla("AplicaPromocion", _
                          "PRMClave", "System.String", _
                          "Inicial", "System.Int32", _
                          "Final", "System.Int32", _
                          "TipoCalculoBase", "System.Int32", _
                          "Clave", "System.String", _
                          "Descripcion", "System.String", _
                          "DVEClave", "System.String", _
                          "PROClave", "System.String", _
                          "Cantidad", "System.Double", _
                          "Promocion", "System.Double", _
                          "Precio", "System.Double", _
                          "PrecioNeto", "System.Double", _
                          "TotalPartida", "System.Double", _
                          "MaxNumPromo", "System.Int32", _
                          "Saldo", "System.Double", _
                          "Iguales", "System.Boolean")

        'Para cada promocion que se encuentre donde algun producto de la venta coincida con algun producto del detalle de la promocion
        For y = 0 To dtPromocion.Rows.Count - 1
            'Recupera detalle promocion
            dtPromDet = ModPOS.Recupera_Tabla("sp_comanda_detalle_promocion", "@PRMClave", dtPromocion.Rows(y)("PRMClave"), "@CMDClave", CMDClave)

            If dtPromocion.Rows(y)("Iguales") = True Then

                For x = 0 To dtPromDet.Rows.Count - 1

                    Select Case CInt(dtPromocion.Rows(y)("TipoAPlicacion"))
                        Case Is = 1 'Cantidad
                            If dtPromocion.Rows(y)("TipoCalculoBase") = 1 Then 'si la base es por cantidad

                                If dtPromDet.Rows(x)("Cantidad") >= dtPromDet.Rows(x)("CantidadInicial") Then
                                    MaxNumPromocion = Int(dtPromDet.Rows(x)("Cantidad") / dtPromDet.Rows(x)("CantidadInicial"))
                                    If MaxNumPromocion > 0 Then
                                        'agrega partida promocion
                                        'If CInt(dtPromocion.Rows(y)("Tipo")) <> 3 Then
                                        agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), MaxNumPromocion, MaxNumPromocion, dtPromocion.Rows(y)("Iguales"))
                                        'End If

                                        AplicaPromocion = True

                                    End If
                                End If

                            Else 'Si la base es rango
                                If dtPromDet.Rows(x)("Cantidad") >= dtPromDet.Rows(x)("CantidadInicial") AndAlso dtPromDet.Rows(x)("Cantidad") <= dtPromDet.Rows(x)("CantidadFinal") Then
                                    'If CInt(dtPromocion.Rows(y)("Tipo")) <> 3 Then
                                    agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), 1, 1, dtPromocion.Rows(y)("Iguales"))
                                    'End If

                                    AplicaPromocion = True

                                End If
                            End If


                        Case Is = 2 'Importe

                            If dtPromocion.Rows(y)("TipoCalculoBase") = 1 Then 'si la base es por cantidad


                                If dtPromDet.Rows(x)("Importe") >= dtPromDet.Rows(x)("CantidadInicial") Then
                                    MaxNumPromocion = Int(dtPromDet.Rows(x)("Importe") / dtPromDet.Rows(x)("CantidadInicial"))
                                    If MaxNumPromocion > 0 Then
                                        'agrega partida promocion
                                        '       If CInt(dtPromocion.Rows(y)("Tipo")) <> 3 Then
                                        agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), MaxNumPromocion, MaxNumPromocion, dtPromocion.Rows(y)("Iguales"))
                                        'End If
                                        AplicaPromocion = True
                                    End If
                                End If


                            Else 'Si la base es rango
                                If dtPromDet.Rows(x)("Importe") >= dtPromDet.Rows(x)("CantidadInicial") AndAlso dtPromDet.Rows(x)("Importe") <= dtPromDet.Rows(x)("CantidadFinal") Then

                                    'If CInt(dtPromocion.Rows(y)("Tipo")) <> 3 Then
                                    agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), 1, 1, dtPromocion.Rows(y)("Iguales"))
                                    'End If

                                    AplicaPromocion = True
                                End If
                            End If


                    End Select
                Next
            Else
                If dtPromocion.Rows(y)("TipoAplicacion") = 1 Then

                    iCantidad = IIf(dtPromDet.Compute("Sum(Cantidad)", "Cantidad > 0") Is System.DBNull.Value, 0, dtPromDet.Compute("Sum(Cantidad)", "Cantidad > 0"))


                    If dtPromocion.Rows(y)("TipoCalculoBase") = 1 Then ' si la base es por cantidad
                        If iCantidad >= dtPromDet.Rows(0)("CantidadInicial") Then
                            MaxNumPromocion = Int(iCantidad / dtPromDet.Rows(0)("CantidadInicial"))
                            If MaxNumPromocion > 0 Then

                                If CInt(dtPromocion.Rows(y)("Tipo")) = 1 Then
                                    iSaldo = MaxNumPromocion * dtPromDet.Rows(0)("CantidadInicial")
                                Else
                                    iSaldo = MaxNumPromocion
                                End If

                                For x = 0 To dtPromDet.Rows.Count - 1

                                    If dtPromDet.Rows(x)("Cantidad") <= iSaldo Then
                                        agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), MaxNumPromocion, dtPromDet.Rows(x)("Cantidad"), dtPromocion.Rows(y)("Iguales"))
                                        iSaldo -= dtPromDet.Rows(x)("Cantidad")
                                        AplicaPromocion = True

                                    Else
                                        agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), MaxNumPromocion, iSaldo, dtPromocion.Rows(y)("Iguales"))
                                        iSaldo = 0
                                        AplicaPromocion = True

                                    End If

                                    If iSaldo = 0 Then
                                        Exit For
                                    End If

                                Next


                            End If
                        End If
                    Else ' si la base es por rango
                        If iCantidad >= dtPromDet.Rows(0)("CantidadInicial") AndAlso iCantidad <= dtPromDet.Rows(x)("CantidadFinal") Then

                            iSaldo = iCantidad

                            For x = 0 To dtPromDet.Rows.Count - 1

                                If dtPromDet.Rows(x)("Cantidad") <= iSaldo Then
                                    agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), iCantidad, dtPromDet.Rows(x)("Cantidad"), dtPromocion.Rows(y)("Iguales"))
                                    iSaldo -= dtPromDet.Rows(x)("Cantidad")
                                    AplicaPromocion = True

                                Else
                                    agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), iCantidad, iSaldo, dtPromocion.Rows(y)("Iguales"))
                                    iSaldo = 0
                                    AplicaPromocion = True

                                End If

                                If iSaldo = 0 Then
                                    Exit For
                                End If

                            Next
                        End If
                    End If

                ElseIf dtPromocion.Rows(y)("TipoAplicacion") = 2 Then 'Importe


                    dImporte = IIf(dtPromDet.Compute("Sum(Importe)", "Importe > 0") Is System.DBNull.Value, 0, dtPromDet.Compute("Sum(Importe)", "Importe > 0"))

            
                    If dtPromocion.Rows(y)("TipoCalculoBase") = 1 Then 'si la base es por cantidad
                        If dImporte >= dtPromDet.Rows(0)("CantidadInicial") Then
                            MaxNumPromocion = Int(dImporte / dtPromDet.Rows(0)("CantidadInicial"))
                            If MaxNumPromocion > 0 Then

                                If CInt(dtPromocion.Rows(y)("Tipo")) = 1 Then
                                    iSaldo = MaxNumPromocion * dtPromDet.Rows(0)("CantidadInicial")
                                Else
                                    iSaldo = MaxNumPromocion
                                End If

                                For x = 0 To dtPromDet.Rows.Count - 1

                                    If dtPromDet.Rows(x)("Importe") <= iSaldo Then
                                        agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), MaxNumPromocion, dtPromDet.Rows(x)("Cantidad"), dtPromocion.Rows(y)("Iguales"))
                                        iSaldo -= dtPromDet.Rows(x)("Importe")
                                        AplicaPromocion = True

                                    Else
                                        agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), MaxNumPromocion, iSaldo, dtPromocion.Rows(y)("Iguales"))
                                        iSaldo = 0
                                        AplicaPromocion = True

                                    End If

                                    If iSaldo = 0 Then
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    Else ' si la base es por rango
                        If dImporte >= dtPromDet.Rows(0)("CantidadInicial") AndAlso dImporte <= dtPromDet.Rows(x)("CantidadFinal") Then

                            iSaldo = dImporte

                            For x = 0 To dtPromDet.Rows.Count - 1

                                If dtPromDet.Rows(x)("Importe") <= iSaldo Then
                                    agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), dImporte, dtPromDet.Rows(x)("Importe"), dtPromocion.Rows(y)("Iguales"))
                                    iSaldo -= dtPromDet.Rows(x)("Importe")
                                    AplicaPromocion = True

                                Else
                                    agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), dImporte, iSaldo, dtPromocion.Rows(y)("Iguales"))
                                    iSaldo = 0
                                    AplicaPromocion = True

                                End If

                                If iSaldo = 0 Then
                                    Exit For
                                End If

                            Next
                        End If



                    End If
                End If
                
            End If


            dtPromDet.Dispose()

            If AplicaPromocion Then  ' Si Aplica la promocion
                AplicaPromociones(CInt(dtPromocion.Rows(y)("Tipo")), dtAplicaPromo)
            End If

            If dtPromocion.Rows(y)("Cascada") = 0 Then ' Si no aplica cascada termina 
                Exit For
            End If

        Next

        dtPromocion.Dispose()
        dtAplicaPromo.Dispose()

    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Dim NoPagar As Boolean = False

        If TotalArticulos > 0 Then

            'Si la venta no ha sido cerrada
            If ComandaCerrada = False Then

                SaldoVenta = TotalVenta

                If Tipo = 4 Then
                    Dim bPrimeraVez As Boolean = True
                    Dim frmStatusMessage1 As New frmStatus
                    frmStatusMessage1.Show("Imprimiendo...")
                    Do
                        If bPrimeraVez = True Then
                            If MessageBox.Show("¿Desea imprimir el ticket de comanda?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                                imprimeComanda(Ticket)
                                bPrimeraVez = False
                            Else
                                Exit Do
                            End If
                        Else
                            imprimeComanda(Ticket)
                            bPrimeraVez = False
                        End If
                    Loop While MessageBox.Show("¿Desea reimprimir la comanda actual?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes
                    frmStatusMessage1.Dispose()
                End If

                'Recupera promociones vigentes

                Dim dtPromocion As DataTable = ModPOS.SiExisteRecupera("sp_promocion_vigente_comanda", "CTEClave", CTEClaveActual, "@CMDClave", CMDClave)
                If Not dtPromocion Is Nothing AndAlso dtPromocion.Rows.Count > 0 Then
                    verificaPromocion(dtPromocion)
                    dtPromocion.Dispose()
                End If


                    DescuentoCliente = -1
                    PorcDescCliente = 0
                    TipoDesCte = 0
                    DESClave = ""
               

                LblCantidadPuntos.Text = CStr(ModPOS.Redondear(TotalPuntos, 2))
                LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")


                If Moneda <> MonedaCambio Then
                    If TotalVenta > 0 Then
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                    End If
                End If

                'Si el descuento se aplica 1 sola vez por venta se elimina al cliente de dicho descuento despues de aplicarlo
                If ComandaCerrada = False AndAlso TipoDesCte = 1 Then
                    ModPOS.Ejecuta("sp_elimina_descte", _
                                   "@DESClave", DESClave, _
                                   "@CTEClave", CTEClaveActual)
                End If

                If Display = True Then
                    Try
                        'limpiar
                        Dim LimpiarDisplay As String = Chr(12)
                        mySerialPort.Write(LimpiarDisplay)
                        mySerialPort.Write("TOTAL: " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency"))
                        If NoLineas > 1 AndAlso TotalAhorro > 0 Then
                            Dim BajarCursor As String = Chr(10)
                            mySerialPort.Write(BajarCursor)
                            'Recorrer Izq
                            Dim MoverIzq As String = Chr(13)
                            mySerialPort.Write(MoverIzq)
                            mySerialPort.Write("AHORRO: " & Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency"))
                        End If
                    Catch ex As Exception
                    End Try
                End If

                'If Redondeo Then
                '    Dim a As New FrmSplashRedondeo
                '    a.url_imagen = Me.Url_Redondeo
                '    a.VENClave = CMDClave
                '    a.ShowDialog()
                '    If a.DialogResult = DialogResult.OK Then
                '        ImpRedondeo = a.ImpRedondeo
                '    Else
                '        ImpRedondeo = 0
                '    End If
                '    a.Dispose()
                'End If

                ModPOS.Ejecuta("sp_comanda_estado", "@CMDClave", CMDClave, "@Estado", 2)

                ModPOS.Ejecuta("sp_agrega_comanda", "@CMDClave", CMDClave)

                If GeneraMovSalida Then
                    ModPOS.GeneraMovInv(2, 1, 1, CMDClave, ALMClave, LblFolio.Text, Nothing)
                    ModPOS.ActualizaExistAlm(2, 1, CMDClave, ALMClave)
                    ModPOS.ActualizaExistUbc(2, 1, CMDClave, ALMClave)
                    GeneraMovSalida = False
                End If

            End If


            If ComandaCerrada = True Then
                ModPOS.Ejecuta("sp_actualiza_venta_cerrada", "@VENClave", CMDClave, "@Estado", 2)
            End If

            If Caja AndAlso SaldoVenta > 0 Then
                Do
                    Dim a As New FrmAbono
                    a.Aplicacion = Aplicacion
                    a.bTouch = True
                    a.TipoDocumento = 1
                    a.CAJA = CAJClave
                    a.ClaveCaja = ClaveCaja
                    a.ClaveCte = CTEClaveActual
                    a.ClaveDocumento = CMDClave
                    a.AperturaCajon = Cajon
                    a.ImpresoraCajon = Impresora
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then

                        Dim i As Integer

                       
                        TotalRecibido += a.TotalAbono
                        TotalCambio += a.TotalCambio
                        SaldoVenta -= (a.TotalAbono - a.TotalCambio)

                        Dim dtVenta As DataTable = ModPOS.CrearTabla("Venta", _
                                                                          "ID", "System.String", _
                                                                          "TipoDocumento", "System.Int32", _
                                                                          "Saldo", "System.Double")
                        Dim row1 As DataRow
                        row1 = dtVenta.NewRow()
                        row1.Item("ID") = CMDClave
                        row1.Item("TipoDocumento") = 1
                        row1.Item("Saldo") = a.SaldoVenta
                        dtVenta.Rows.Add(row1)


                        For i = 0 To a.detallePago.Rows.Count - 1
                            ModPOS.Aplica_Pagos(dtVenta, CTEClaveActual, a.detallePago.Rows(i)("ABNClave"), a.detallePago.Rows(i)("TipoPago"), a.detallePago.Rows(i)("Saldo"), CAJClave, 1)
                        Next

                        a.Dispose()
                    Else

                        a.Dispose()
                        '     Exit Sub
                    End If

                    If SaldoVenta > 0 Then
                        Select Case MessageBox.Show("La venta actual no ha sido totalmente pagada, su saldo es: " & Format(CStr(ModPOS.Redondear(SaldoVenta, 2)), "Currency") & ", ¿Desea pagar el saldo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            Case DialogResult.Yes
                                NoPagar = False
                            Case Else
                                NoPagar = True
                                Exit Do
                        End Select
                    End If

                Loop While SaldoVenta > 0 AndAlso Not NoPagar

                If TotalRecibido > 0 Then
                    Dim msg As New FrmMeMsg
                    msg.TxtTiulo = "Su Cambio es:"
                    msg.TxtMsg = Format(CStr(Math.Round(TotalCambio, 2)), "Currency")
                    msg.TxtMsg2 = Letras(CStr(Math.Round(TotalCambio, 2))).ToUpper
                    msg.ShowDialog()
                    msg.Dispose()


                End If

            End If


            Dim frmStatusMessage As New frmStatus

            If ComandaNueva Then
                If Tipo = 4 Then
                    frmStatusMessage.Show("Imprimiendo...")
                    imprimeTicket(CMDClave, Impresora, PrintGeneric, Ticket, ImpRedondeo, TotalVenta, SaldoVenta, ComandaNueva)

                    'Ciclo para impresion de copias
                    If NumCopias > 0 Then
                        Dim i As Integer
                        For i = 1 To NumCopias
                            imprimeTicket(CMDClave, Impresora, PrintGeneric, Ticket, ImpRedondeo, TotalVenta, SaldoVenta, ComandaNueva)
                        Next
                    End If

                    frmStatusMessage.Dispose()
                Else
                    Select Case MessageBox.Show("¿Desea imprimir el Ticket de Venta?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.Yes
                            frmStatusMessage.Show("Imprimiendo...")
                            imprimeTicket(CMDClave, Impresora, PrintGeneric, Ticket, ImpRedondeo, TotalVenta, SaldoVenta, ComandaNueva)

                            'Ciclo para impresion de copias
                            If NumCopias > 0 Then
                                Dim i As Integer
                                For i = 1 To NumCopias
                                    imprimeTicket(CMDClave, Impresora, PrintGeneric, Ticket, ImpRedondeo, TotalVenta, SaldoVenta, ComandaNueva)
                                Next
                            End If

                            frmStatusMessage.Dispose()
                    End Select
                End If
            Else
                Select Case MessageBox.Show("¿Desea Reimprimir el Ticket de Venta?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        frmStatusMessage.Show("Imprimiendo...")
                        imprimeTicket(CMDClave, Impresora, PrintGeneric, Ticket, ImpRedondeo, TotalVenta, SaldoVenta, ComandaNueva)
                        frmStatusMessage.Dispose()
                End Select
            End If



                ComandaCerrada = True
                BtnCliente.Enabled = False
                BtnBorrar.Enabled = False
                BtnCancelar.Enabled = False
                TxtCantidad.Enabled = False
                TxtCliente.Enabled = False
                ComandaNueva = False

                cambiaStatus("COMANDA (CERRADA)", Status.Cerrado)

                If Tipo = 5 Then
                    ModPOS.Ejecuta("sp_act_edo_mesa", "@MESClave", MESClave, "@Estado", 1)
                    If Not ModPOS.Plano Is Nothing Then
                        ModPOS.Plano.iColorMesa = 1
                    End If
                End If


                'Solicita Retiro de Caja
                If ComandaCerrada AndAlso Caja AndAlso TotalRecibido > 0 Then
                    If MaxEfectivo > 0 OrElse MaxCheques > 0 OrElse MaxVales > 0 Then
                        Dim dt As DataTable
                        dt = SiExisteRecupera("sp_limite_caja", "@CAJClave", CAJClave, "@Fecha", Today)
                        Dim bRetirar As Boolean = False
                        Dim MontoEfectivo, MontoCheques, MontoVales As Double
                        Dim retiroEfectivo, retiroCheques, retiroVales As Double
                        Dim aperturaEfectivo, aperturaCheques, aperturaVales As Double

                        If Not dt Is Nothing Then
                            Dim fila As Integer
                            For fila = 0 To dt.Rows.Count - 1
                                Select Case CInt(dt.Rows(fila)("TipoPago"))
                                    Case Is = 1
                                        If MaxEfectivo < (CDbl(dt.Rows(fila)("Monto")) - CDbl(dt.Rows(fila)("Retiro"))) Then
                                            MontoEfectivo = CDbl(dt.Rows(fila)("Monto"))
                                            retiroEfectivo = CDbl(dt.Rows(fila)("Retiro"))
                                            aperturaEfectivo = CDbl(dt.Rows(fila)("Apertura"))

                                            bRetirar = True

                                        End If
                                    Case Is = 2
                                        If MaxCheques < (CDbl(dt.Rows(fila)("Monto")) - CDbl(dt.Rows(fila)("Retiro"))) Then
                                            MontoCheques = CDbl(dt.Rows(fila)("Monto"))
                                            retiroCheques = CDbl(dt.Rows(fila)("Retiro"))
                                            aperturaCheques = CDbl(dt.Rows(fila)("Apertura"))

                                            bRetirar = True

                                        End If
                                    Case Is = 4
                                        If MaxVales < (CDbl(dt.Rows(fila)("Monto")) - CDbl(dt.Rows(fila)("Retiro"))) Then
                                            MontoVales = CDbl(dt.Rows(fila)("Monto"))
                                            retiroVales = CDbl(dt.Rows(fila)("Retiro"))
                                            aperturaVales = CDbl(dt.Rows(fila)("Apertura"))

                                            bRetirar = True

                                        End If
                                End Select
                            Next
                            If bRetirar Then
                            Dim a As New FrmRetiroCaja
                            a.SUCClave = SUCClave
                                a.ALMClave = ALMClave
                                a.CAJClave = CAJClave
                                a.Impresora = Impresora
                                a.Generic = PrintGeneric
                                a.Ticket = Ticket
                                a.MontoEfectivo = MontoEfectivo + aperturaEfectivo
                                a.MontoCheques = MontoCheques + aperturaCheques
                                a.MontoVales = MontoVales + aperturaVales
                                a.retiroEfectivo = retiroEfectivo
                                a.retiroCheques = retiroCheques
                                a.retiroVales = retiroVales
                                a.Cajon = Cajon
                                a.ShowDialog()
                            End If
                        End If
                    End If
                End If

            Else
                Beep()
                MessageBox.Show("El documento actual no puede ser cerrado sin productos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
    End Sub

    Private Sub TxtCantidad_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCantidad.Leave
        If Not TxtCantidad.Text = vbNullString Then
            If CDbl(TxtCantidad.Text) = 0 Then
                Cantidad = 1
                TxtCantidad.Text = CStr(Cantidad)
            Else
                Cantidad = Math.Abs(CDbl(TxtCantidad.Text))
            End If

        Else
            Cantidad = 1
            TxtCantidad.Text = CStr(Cantidad)
        End If

    End Sub

    Private Function imprimeCancelado(ByVal Venta As String, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String) As Boolean
        Dim dTotalAhorro, dTotalPuntos, dTotalVenta, dArticulos As Double

        Dim lineasImpresas As Integer = 6

        Dim Tickets As Imprimir = New Imprimir 'PrintTicket.Ticket()
        Tickets.Generic = Generic
        Dim dtTicket As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            If dtTicket.Rows(0)("url_imagen") <> "" Then
                Tickets.ImgHeader = ModPOS.RecuperaImagen(dtTicket.Rows(0)("url_imagen"))
            End If
            dtTicket.Dispose()
        End If


        Tickets.AddHeaderLine("*** CANCELADO ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        lineasImpresas += 1


        Dim dtHeadTicket As DataTable
        dtHeadTicket = ModPOS.SiExisteRecupera("sp_filtra_encabezado", "@TIKClave", Ticket)



        If Not dtHeadTicket Is Nothing Then

            lineasImpresas += dtHeadTicket.Rows.Count

            Dim i As Integer
            For i = 0 To dtHeadTicket.Rows.Count - 1
                Tickets.AddHeaderLine(CStr(dtHeadTicket.Rows(i)("Texto")), Math.Abs(CInt(dtHeadTicket.Rows(i)("Negrita"))), CInt(dtHeadTicket.Rows(i)("Alinear")))
            Next
            dtHeadTicket.Dispose()
        End If

        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 

        Dim dtVenta As DataTable = ModPOS.SiExisteRecupera("sp_recupera_venta_closed", "@VENClave", Venta)


        Tickets.AddSubHeaderLine(" T. CANCELADO # " & dtVenta.Rows(0)("Folio"), 1, 3)
        lineasImpresas += 1

        Tickets.AddSubHeaderLine("CTE: " & dtVenta.Rows(0)("RazonSocial"), 0, 3)
        lineasImpresas += 1

        Tickets.AddSubHeaderLine("CANCELADO POR: " & dtVenta.Rows(0)("NombreUsuario"), 0, 3)
        lineasImpresas += 1

        Dim tFecha As DateTime
        tFecha = dtVenta.Rows(0)("Fecha")

        dtVenta.Dispose()

        Tickets.AddSubHeaderLine(tFecha.ToShortDateString() & " " & tFecha.ToShortTimeString(), 0, 3)
        lineasImpresas += 1

        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
        'del producto y el tercero es el precio 
        Dim dtVentaDetalle As DataTable
        dtVentaDetalle = ModPOS.SiExisteRecupera("sp_ventadetalle_cerrada", "@VENClave", Venta)

        lineasImpresas += (dtVentaDetalle.Rows.Count() * 2)

        If Not dtVentaDetalle Is Nothing Then
            Dim i As Integer = 0
            dArticulos = dtVentaDetalle.Rows.Count()
            For i = 0 To dArticulos - 1
                Dim sDVEClave As String = dtVentaDetalle.Rows(i)("DVEClave")
                Dim sGTIN As String = dtVentaDetalle.Rows(i)("Clave")
                Dim sNombre As String = dtVentaDetalle.Rows(i)("Nombre")
                Dim dCantidad As Double = dtVentaDetalle.Rows(i)("Cantidad")
                Dim dPrecioBruto As Double = dtVentaDetalle.Rows(i)("PrecioBruto")
                Dim dImpuestoImp As Double = dtVentaDetalle.Rows(i)("ImpuestoImp")
                Dim dDescuentoImp As Double = dtVentaDetalle.Rows(i)("DescuentoImp")
                Dim dPuntosImp As Double = dtVentaDetalle.Rows(i)("PuntosImp")
                Dim dTotal As Double = dtVentaDetalle.Rows(i)("TotalPartida")
                Dim dImpuestoPorc As Double = dtVentaDetalle.Rows(i)("ImpuestoPorc")

                Dim dImporteNeto As Double = ModPOS.Redondear(dPrecioBruto * (1 + dImpuestoPorc), 2)

                ' AGREGAR PRODUCTO A LISTA
                Tickets.AddItem(sDVEClave, sGTIN, sNombre, dCantidad, dImporteNeto, dDescuentoImp)

                dTotalAhorro += ((dDescuentoImp * (1 + dImpuestoPorc)) * dCantidad)
                dTotalPuntos += (dPuntosImp * dCantidad)
                dTotalVenta += (dTotal)
            Next
            dtVentaDetalle.Dispose()
        End If


        dTotalVenta += Redondeo

        Tickets.AddTotal(Redondeo, dTotalVenta, dTotalPuntos, dTotalAhorro, dArticulos, TotalRecibido, TotalCambio, dTotalVenta, 1)

        lineasImpresas += 5


        'Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        'parametro de tipo string que debe de ser el nombre de la impresora. 
        Tickets.PrintTicket(Impresora, 70, lineasImpresas)

    End Function

    Private Function imprimeTicket(ByVal Comanda As String, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String, ByVal Redondeo As Double, ByVal Total As Double, ByVal Saldo As Double, ByVal NuevaVenta As Boolean) As Boolean
        Dim dTotalAhorro, dTotalPuntos, dTotalVenta, dArticulos As Double

        Dim lineasImpresas As Integer = 6

        Dim Tickets As Imprimir = New Imprimir 'PrintTicket.Ticket()
        Tickets.Generic = Generic
        Dim dtTicket As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            If dtTicket.Rows(0)("url_imagen") <> "" Then
                Tickets.ImgHeader = ModPOS.RecuperaImagen(dtTicket.Rows(0)("url_imagen"))
            End If
            dtTicket.Dispose()
        End If


        Dim dtHeadTicket As DataTable
        dtHeadTicket = ModPOS.SiExisteRecupera("sp_filtra_encabezado", "@TIKClave", Ticket)

        
        If Not dtHeadTicket Is Nothing Then

            lineasImpresas += dtHeadTicket.Rows.Count

            Dim i As Integer
            For i = 0 To dtHeadTicket.Rows.Count - 1
                Tickets.AddHeaderLine(CStr(dtHeadTicket.Rows(i)("Texto")), Math.Abs(CInt(dtHeadTicket.Rows(i)("Negrita"))), CInt(dtHeadTicket.Rows(i)("Alinear")))
            Next
            dtHeadTicket.Dispose()

        End If

        If NuevaVenta = False Then
            Tickets.AddHeaderLine("REIMPRESION", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
            lineasImpresas += 1
        End If

        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 

        Dim dtVenta As DataTable = ModPOS.SiExisteRecupera("sp_recupera_cmd_open", "@CMDClave", Comanda)


        Tickets.AddSubHeaderLine(" TICKET # " & dtVenta.Rows(0)("Folio"), 1, 3)
        lineasImpresas += 1

        Tickets.AddSubHeaderLine("CTE: " & dtVenta.Rows(0)("RazonSocial"), 0, 3)
        lineasImpresas += 1

        Tickets.AddSubHeaderLine("LE ATENDIO: " & dtVenta.Rows(0)("NombreUsuario"), 0, 3)
        lineasImpresas += 1

        Dim tFecha As DateTime
        tFecha = dtVenta.Rows(0)("Fecha")

        dtVenta.Dispose()

        Tickets.AddSubHeaderLine(tFecha.ToShortDateString() & " " & tFecha.ToShortTimeString(), 0, 3)
        lineasImpresas += 1

        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
        'del producto y el tercero es el precio 
        Dim dtVentaDetalle As DataTable
        dtVentaDetalle = ModPOS.Recupera_Tabla("sp_comandadetalle_all", "@CMDClave", Comanda)

        lineasImpresas += (dtVentaDetalle.Rows.Count() * 2)

        If Not dtVentaDetalle Is Nothing AndAlso dtVentaDetalle.Rows.Count > 0 Then
            Dim i As Integer = 0
            dArticulos = dtVentaDetalle.Rows.Count()
            For i = 0 To dArticulos - 1
                Dim sDCMClave As String = dtVentaDetalle.Rows(i)("DCMClave")
                Dim sGTIN As String = dtVentaDetalle.Rows(i)("Clave")
                Dim sNombre As String = dtVentaDetalle.Rows(i)("Nombre")
                Dim dCantidad As Double = dtVentaDetalle.Rows(i)("Cantidad")
                Dim dPrecioBruto As Double = dtVentaDetalle.Rows(i)("PrecioBruto")
                Dim dImpuestoImp As Double = dtVentaDetalle.Rows(i)("ImpuestoImp")
                Dim dDescuentoImp As Double = dtVentaDetalle.Rows(i)("DescuentoImp")
                Dim dPuntosImp As Double = dtVentaDetalle.Rows(i)("PuntosImp")
                Dim dTotal As Double = dtVentaDetalle.Rows(i)("TotalPartida")
                Dim dImpuestoPorc As Double = dtVentaDetalle.Rows(i)("ImpuestoPorc")

                Dim dImporteNeto As Double = ModPOS.Redondear(dPrecioBruto * (1 + dImpuestoPorc), 2)

                ' AGREGAR PRODUCTO A LISTA
                Tickets.AddItem(sDCMClave, sGTIN, sNombre, dCantidad, dImporteNeto, dDescuentoImp)

                dTotalAhorro += ((dDescuentoImp * (1 + dImpuestoPorc)) * dCantidad)
                dTotalPuntos += (dPuntosImp * dCantidad)
                dTotalVenta += (dTotal)
            Next
        End If

        dtVentaDetalle.Dispose()

     
        dTotalVenta += Redondeo

        Tickets.AddTotal(Redondeo, dTotalVenta, dTotalPuntos, dTotalAhorro, dArticulos, TotalRecibido, Math.Round(TotalCambio, 2), Saldo, 1)

        lineasImpresas += 5

        If TotalRecibido > 0 Then
            Dim i As Integer
            Dim sTipo, sMonto, sReferencia As String
            Dim dtMetodospago As DataTable
            dtMetodospago = ModPOS.Recupera_Tabla("sp_metodospago_venta", "@VENClave", Comanda)
            For i = 0 To dtMetodospago.Rows.Count - 1

                sTipo = dtMetodospago.Rows(i)("Tipo")
                sReferencia = IIf(dtMetodospago.Rows(i)("Referencia").GetType.Name = "DBNull", "", dtMetodospago.Rows(i)("Referencia"))
                sMonto = Strings.Format(Redondear(dtMetodospago.Rows(i)("Importe"), 2).ToString, "Currency")

                Tickets.AddMetodoPago(sTipo, sReferencia, sMonto, i)

                lineasImpresas += 2

            Next
            dtMetodospago.Dispose()
        End If


        'El metodo AddFooterLine funciona igual que la cabecera 

        Dim dtPieTicket As DataTable
        dtPieTicket = ModPOS.SiExisteRecupera("sp_filtra_pie", "@TIKClave", Ticket)

        If Not dtPieTicket Is Nothing Then
            Dim i As Integer

            lineasImpresas += dtPieTicket.Rows.Count

            For i = 0 To dtPieTicket.Rows.Count - 1
                Tickets.AddFooterLine(CStr(dtPieTicket.Rows(i)("Texto")), Math.Abs(CInt(dtPieTicket.Rows(i)("Negrita"))), CInt(dtPieTicket.Rows(i)("Alinear")))
            Next
            dtPieTicket.Dispose()
        End If

        'Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        'parametro de tipo string que debe de ser el nombre de la impresora. 
        Tickets.PrintTicket(Impresora, 70, lineasImpresas)

    End Function

    Private Sub BtnCancelaTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Dim SeCancela As Boolean = False
        If TotalArticulos > 0 Then
            If ComandaCerrada = False Then
                Dim a As New MeAutorizacion
                a.Sucursal = SUCClave
                a.MontodeAutorizacion = TotalVenta
                a.StartPosition = FormStartPosition.CenterScreen
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If Not a.Autorizado Then
                        a.Dispose()
                        Exit Sub
                    End If
                    Autoriza = a.Autoriza
                ElseIf a.DialogResult = Windows.Forms.DialogResult.Cancel Then
                    a.Dispose()
                    Exit Sub
                End If
                a.Dispose()

                ModPOS.Ejecuta("sp_cancela_comanda", "@CMDClave", CMDClave, "@ALMClave", ALMClave)
                ModPOS.Ejecuta("sp_agrega_comanda", "@CMDClave", CMDClave)

            
                Dim frmStatusMessage As New frmStatus

                frmStatusMessage.Show("Imprimiendo...")
                imprimeCancelado(CMDClave, Impresora, PrintGeneric, Ticket)

                frmStatusMessage.Dispose()


                SeCancela = True

                If Tipo = 5 Then
                    ModPOS.Ejecuta("sp_act_edo_mesa", "@MESClave", MESClave, "@Estado", 1)
                    If Not ModPOS.Plano Is Nothing Then
                        ModPOS.Plano.iColorMesa = 1
                    End If
                End If

            Else
                MsgBox("No se puede cancelar la comanda debido a que ya ha sido cerrada. Busque la venta en caja para cancelarla", MsgBoxStyle.Information, "Información")
                Exit Sub
            End If

        Else

            Dim NextFolio As Integer
            Dim strFolio() As String = Split(LblFolio.Text, "-")
            Dim iFolio As Integer = CInt(strFolio(1))

            Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 1, "@PDVClave", PDVClave)

            If Not dt Is Nothing Then
                NextFolio = CInt(dt.Rows(0)("UltimoConsecutivo"))
                dt.Dispose()
            End If


            If NextFolio = iFolio Then
                ModPOS.Ejecuta("sp_act_folio", "@PDVClave", PDVClave, "@Incremento", -1, "@Tipo", 1)
                ModPOS.Ejecuta("sp_elimina_comanda", "@CMDClave", CMDClave)
            Else
                ModPOS.Ejecuta("sp_cancela_comanda", "@CMDClave", CMDClave, "@ALMClave", ALMClave)
                ModPOS.Ejecuta("sp_agrega_comanda", "@CMDClave", CMDClave)
            End If

            SeCancela = True
        End If

        If SeCancela Then
            ComandaCerrada = True
            activaBotones(Tipo, False)
            GeneraMovSalida = False

            TotalArticulos = 0
            TotalPuntos = 0
            TotalVenta = 0
            TotalRecibido = 0
            TotalCambio = 0
            TotalAhorro = 0

            If Moneda <> MonedaCambio Then
                If TotalVenta > 0 Then
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                End If
            End If

            If Not dtComandaDetalle Is Nothing AndAlso dtComandaDetalle.Rows.Count > 0 Then
                dtComandaDetalle.Clear()
            End If

            LblFolio.Text = Referencia & "- "

            cambiaStatus("", Status.Original)

            If Tipo = 5 Then
                ModPOS.Ejecuta("sp_act_edo_mesa", "@MESClave", MESClave, "@Estado", 1)
                If Not ModPOS.Plano Is Nothing Then
                    ModPOS.Plano.iColorMesa = 1
                End If
            End If

            MsgBox("La Comanda ha sido cancelada exitosamente", MsgBoxStyle.Information, "Información")

        End If
    End Sub

    Private Sub BtnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBorrar.Click
        If Not ComandaCerrada Then
            If TotalArticulos > 0 Then
                Borrar()
            Else
                MsgBox("La comanda actual no tiene productos", MsgBoxStyle.Information, "Información")
            End If
        End If
    End Sub

    Private Sub BtnConsultaPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        Dim a As New FrmConsultaPrecio
        a.ClienteActual = Me.CTEClaveActual
        a.Almacen = ALMClave
        a.SUCClave = SUCClave
        If dtComandaDetalle.Rows.Count > 0 Then
            a.Producto = GridDetalle.GetValue("PROClave")
            a.Cant = GridDetalle.GetValue("Cant.")
            a.TipoDisplay = 4
            a.dPuntos = GridDetalle.GetValue("Puntos")
            a.dAhorro = GridDetalle.GetValue("Descuento") * (1 + GridDetalle.GetValue("PorcImpuesto"))
            a.dPrecioNeto = GridDetalle.GetValue("Precio")
            a.dNormal = a.dPrecioNeto + a.dAhorro
        End If

        a.ShowDialog()
        a.Dispose()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnSumar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSumar.Click
        TxtCantidad.Text = CStr(CDbl(TxtCantidad.Text) + 1)
    End Sub

    Private Sub BtnRestar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRestar.Click
        TxtCantidad.Text = CStr(IIf((CDbl(TxtCantidad.Text) - 1) < 0, 0, CDbl(TxtCantidad.Text) - 1))
    End Sub

    Private Sub BtnUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUltimo.Click
        GridDetalle.MoveLast()
    End Sub

    Private Sub BtnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSiguiente.Click
        GridDetalle.MoveNext()
    End Sub

    Private Sub BtnAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnterior.Click
        GridDetalle.MovePrevious()
    End Sub

    Private Sub BtnPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrimero.Click
        GridDetalle.MoveFirst()
    End Sub

    Private Sub BtnCliente_Click_(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCliente.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                TxtCliente.Text = ""
                CTEClaveActual = a.valor
                CTENombreActual = a.Descripcion2
                LblCliente.Text = CTENombreActual
                ModPOS.Ejecuta("sp_actualiza_CMDCliente", _
                "@CMDClave", CMDClave, _
                "@Cliente", CTEClaveActual, _
                "@Usuario", ModPOS.UsuarioActual)
            End If
        End If
        a.Dispose()

    End Sub

    Private Sub llenaMenu()
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

        myCommand = New System.Data.SqlClient.SqlCommand("sp_obtener_lineas", Cnx)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.Parameters.Add("@COMClave", SqlDbType.VarChar).Value = ModPOS.CompanyActual
        myCommand.CommandTimeout = ModPOS.myTimeOut
        '  myCommand.Parameters.Add("@Perfil", SqlDbType.VarChar).Value = sperfil

        dr = myCommand.ExecuteReader()

        Dim x, y As Integer
        x = 2
        y = 2

        While dr.Read
            Dim btn As Janus.Windows.EditControls.UIButton
            btn = New Janus.Windows.EditControls.UIButton
            btn.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
            btn.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
            btn.Office2007CustomColor = Color.Yellow
            btn.Name = dr("CLAClave")
            btn.Text = dr("Nombre")
            btn.ToolTipText = dr("Referencia")
            btn.Width = 90
            btn.Height = 60
            btn.Location = New Point(x, y)
            x += 95
            pnlMenu.Controls.Add(btn)
            AddHandler btn.Click, AddressOf Menu_Click
            AddHandler btn.KeyUp, AddressOf Controls_KeyUp
        End While

        myCommand.Dispose()
        dr.Close()

        pnlMenu.HorizontalScroll.Enabled = False
        pnlMenu.HorizontalScroll.Visible = False

        If pnlMenu.Controls.Count > 0 Then
            grpSub.Text = pnlMenu.Controls.Item(0).Text
            llenaSubmenu(CInt(pnlMenu.Controls.Item(0).Name))
        End If

        iAvanceMenu = pnlMenu.HorizontalScroll.LargeChange
    End Sub

    Private Sub llenaSubmenu(ByVal iPadre As Integer)

        pnlSubmenu.Controls.Clear()

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

        myCommand = New System.Data.SqlClient.SqlCommand("sp_obtener_sublineas", Cnx)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.CommandTimeout = ModPOS.myTimeOut
        myCommand.Parameters.Add("@CLAClavePadre", SqlDbType.Int).Value = iPadre

        dr = myCommand.ExecuteReader()

        Dim x, y As Integer
        x = 2
        y = 2



        While dr.Read
            Dim btn As Janus.Windows.EditControls.UIButton
            btn = New Janus.Windows.EditControls.UIButton
            btn.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
            btn.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
            btn.Office2007CustomColor = Color.ForestGreen
            btn.Name = dr("CLAClave")
            btn.Text = dr("Nombre")
            btn.ToolTipText = dr("Referencia")
            btn.Width = 90
            btn.Height = 60
            btn.Location = New Point(x, y)
            x += 95
            pnlSubmenu.Controls.Add(btn)
            AddHandler btn.Click, AddressOf SubMenu_Click
            AddHandler btn.KeyUp, AddressOf Controls_KeyUp

        End While

        myCommand.Dispose()
        dr.Close()

        pnlSubmenu.HorizontalScroll.Enabled = False
        pnlSubmenu.HorizontalScroll.Visible = False

        If pnlSubmenu.Controls.Count > 0 Then
            grpProd.Text = pnlSubmenu.Controls.Item(0).Text
            llenaProductos(CInt(pnlSubmenu.Controls.Item(0).Name), ALMClave)
        Else
            grpProd.Text = grpSub.Text
            llenaProductos(iPadre, ALMClave)
        End If

        CLAClave = iPadre


        iAvanceSubmenu = pnlSubmenu.HorizontalScroll.LargeChange
    End Sub

    Private Sub llenaProductos(ByVal iCLAClave As Integer, ByVal sALMClave As String)

        pnlProductos.Controls.Clear()

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

        myCommand = New System.Data.SqlClient.SqlCommand("sp_obtener_productos", Cnx)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.CommandTimeout = ModPOS.myTimeOut
        myCommand.Parameters.Add("@ALMClave", SqlDbType.VarChar).Value = sALMClave
        myCommand.Parameters.Add("@CLAClave", SqlDbType.Int).Value = iCLAClave

        dr = myCommand.ExecuteReader()

        Dim x, y As Integer
        x = 2
        y = 2

        Dim MaxCol, Col As Integer

        MaxCol = Math.Truncate(pnlProductos.Width / 95)


        While dr.Read

            If Col = MaxCol Then
                y += 65
                x = 2
                Col = 0
            End If
            Dim btn As Janus.Windows.EditControls.UIButton
            btn = New Janus.Windows.EditControls.UIButton
            btn.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
            btn.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
            btn.Office2007CustomColor = Color.DodgerBlue
            btn.Name = dr("Clave")
            btn.Text = dr("Nombre")
            btn.ToolTipText = dr("Descripcion")
            btn.Width = 90
            btn.Height = 60
            btn.Location = New Point(x, y)
            x += 95
            Col += 1
            pnlProductos.Controls.Add(btn)
            AddHandler btn.Click, AddressOf Productos_Click
            AddHandler btn.KeyUp, AddressOf Controls_KeyUp

        End While

        myCommand.Dispose()
        dr.Close()

        pnlProductos.VerticalScroll.Enabled = False
        pnlProductos.VerticalScroll.Visible = False

        If pnlProductos.Controls.Count > 0 Then
            llenaMod(CStr(pnlProductos.Controls.Item(0).Name), pnlProductos.Controls.Item(0).Text)
        Else
            grpMod.Text = grpSub.Text
        End If

        iAvanceProductos = pnlProductos.VerticalScroll.LargeChange
    End Sub

    Private Sub llenaMod(ByVal sProducto As String, ByVal sText As String)

        sClaveProducto = sProducto

        If grpMod.Text = sText Then
            Exit Sub
        Else
            grpMod.Text = sText
        End If

        pnlMod.Controls.Clear()

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

        myCommand = New System.Data.SqlClient.SqlCommand("sp_obtener_modificadores", Cnx)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.CommandTimeout = ModPOS.myTimeOut
        myCommand.Parameters.Add("@Clave", SqlDbType.VarChar).Value = sProducto

        dr = myCommand.ExecuteReader()

        Dim x, y As Integer
        x = 2
        y = 2



        While dr.Read
            Dim btn As Janus.Windows.EditControls.UIButton
            btn = New Janus.Windows.EditControls.UIButton
            btn.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
            btn.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
            btn.Office2007CustomColor = Color.RoyalBlue
            btn.Name = dr("DMDClave")
            btn.Text = dr("Descripcion")
            btn.ToolTipText = dr("Abreviatura")
            btn.Width = 90
            btn.Height = 60
            btn.Location = New Point(x, y)
            x += 95
            pnlMod.Controls.Add(btn)
            AddHandler btn.Click, AddressOf Modificadores_Click
            AddHandler btn.KeyUp, AddressOf Controls_KeyUp

        End While

        myCommand.Dispose()
        dr.Close()

        pnlMod.HorizontalScroll.Enabled = False
        pnlMod.HorizontalScroll.Visible = False


        iAvanceMod = pnlMod.HorizontalScroll.LargeChange
    End Sub


    Private Sub FrmTouch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dt As DataTable
        dt = ModPOS.SiExisteRecupera("sp_recupera_tikclave_tipo", "@SUCClave", SUCClave, "@Tipo", 4)
        If Not dt Is Nothing Then
            sTicketResumen = dt.Rows(0)("TIKClave")
            dt.Dispose()
        End If


        llenaMenu()

        If Tipo = 5 Then
            LblInfoMesa.Text = Piso & " | MESA " & Mesa & " | No. COMENSALES " & CStr(Comensales)
            BtnEspera.Enabled = False
        Else
            Me.BtnResumen.Enabled = False
        End If


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
        Else
            LblTipoCambio.Text = ""
        End If


        BtnDevolucion.Enabled = Caja

        If (Caja = False And ActivaDevolucion = True) OrElse (Caja = True And Tipo = 5) Then
            BtnDevolucion.Enabled = True
            dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
            ClaveCaja = dt.Rows(0)("Clave")
            CajaTICDevolucion = dt.Rows(0)("TICDevolucion")
            MaxEfectivo = dt.Rows(0)("LimiteEfectivo")
            MaxCheques = dt.Rows(0)("LimiteCheque")
            MaxVales = dt.Rows(0)("LimiteVale")
            CajaClave = dt.Rows(0)("Clave")
            CajaNombre = dt.Rows(0)("Nombre")
            Cajon = IIf(dt.Rows(0)("Cajon").GetType.Name = "DBNull", False, dt.Rows(0)("Cajon"))
            Aplicacion = IIf(dt.Rows(0)("url_aplicacion").GetType.Name = "DBNull", "", dt.Rows(0)("url_aplicacion"))
            dt.Dispose()
        End If


        If Caja AndAlso Tipo = 4 Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
            ClaveCaja = dt.Rows(0)("Clave")
            CajaTICDevolucion = dt.Rows(0)("TICDevolucion")
            CajaClave = dt.Rows(0)("Clave")
            CajaNombre = dt.Rows(0)("Nombre")
            Manual = IIf(dt.Rows(0)("Manual").GetType.Name = "DBNull", 0, dt.Rows(0)("Manual"))
            Cajon = IIf(dt.Rows(0)("Cajon").GetType.Name = "DBNull", False, dt.Rows(0)("Cajon"))
            Aplicacion = IIf(dt.Rows(0)("url_aplicacion").GetType.Name = "DBNull", "", dt.Rows(0)("url_aplicacion"))
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
            LblFolio.Text = sFolio
            LblCantidadPuntos.Text = "0"
            LblAhorro.Text = "$0.00"
            LblTotal.Text = "$0.00"

            llenaGrid("")

            CTEClaveActual = CTEClaveInicial
            CTENombreActual = CTENombreInicial
        Else
            llenaGrid(CMDClave)
        End If

        LblCliente.Text = CTENombreActual
        LblMesero.Text = MeseroNombre
        LblCajero.Text = CajeroNombre
        TxtCantidad.Text = CStr(ModPOS.Redondear(Cantidad, 2))
        Me.LblFechaHora.Text = DateTime.Today.ToLongDateString & " " & DateTime.Now.ToShortTimeString 'ToString("MMMM dd, yyyy")

        If Moneda <> MonedaCambio Then
            If TotalVenta > 0 Then
                LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
            Else
                LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
            End If
        End If

        If Display = True Then
            If mySerialPort.IsOpen = True Then
                Try
                    mySerialPort.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If

            CommPortSetup(Port, BaudRate)

            Try
                mySerialPort.Open()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

        Clock.Start()

    End Sub

    Private Sub FrmTouch_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Tipo = 4 Then
            If ComandaCerrada Then
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
                ModPOS.Touch.Dispose()
                ModPOS.Touch = Nothing

            Else
                Beep()
                Select Case MessageBox.Show("La Comanda actual no ha sido Cerrada, ¿Desea Cancelarla?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    Case DialogResult.No
                        e.Cancel = True
                    Case DialogResult.Yes
                        BtnCancelar.PerformClick()
                        If ComandaCerrada Then
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
                            ModPOS.Touch.Dispose()
                            ModPOS.Touch = Nothing
                        Else
                            e.Cancel = True
                        End If
                End Select

            End If
        Else
            ModPOS.Touch.Dispose()
            ModPOS.Touch = Nothing
        End If
    End Sub

    Private Sub Clock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock.Tick
        Me.LblFechaHora.Text = DateTime.Today.ToLongDateString & " " & DateTime.Now.ToShortTimeString 'ToString("MMMM dd, yyyy")
    End Sub

    Private Sub btnIzqMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIzqMenu.Click
        If pnlMenu.HorizontalScroll.Value > 0 AndAlso (pnlMenu.HorizontalScroll.Value - iAvanceMenu) >= pnlMenu.HorizontalScroll.Minimum Then
            pnlMenu.HorizontalScroll.Value -= iAvanceMenu
        Else
            pnlMenu.HorizontalScroll.Value = pnlMenu.HorizontalScroll.Minimum
        End If
    End Sub

    Private Sub btnDerMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDerMenu.Click
        If (pnlMenu.HorizontalScroll.Value + iAvanceMenu) <= pnlMenu.HorizontalScroll.Maximum Then
            pnlMenu.HorizontalScroll.Value += iAvanceMenu
        Else
            pnlMenu.HorizontalScroll.Value = pnlMenu.HorizontalScroll.Maximum
        End If
    End Sub

    Private Sub Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Janus.Windows.EditControls.UIButton
        btn = sender
        grpSub.Text = btn.Text
        Me.llenaSubmenu(CInt(btn.Name))

    End Sub

    Private Sub SubMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Janus.Windows.EditControls.UIButton
        btn = sender
        grpProd.Text = btn.Text
        llenaProductos(CInt(btn.Name), ALMClave)
    End Sub

    Private Sub Productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Janus.Windows.EditControls.UIButton
        btn = sender
        llenaMod(btn.Name, btn.Text)
        If pnlMod.Controls.Count = 0 Then
            AgregaPlatillo(btn.Name, "")
        End If
    End Sub

    Private Sub Modificadores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Janus.Windows.EditControls.UIButton
        btn = sender
        AgregaPlatillo(sClaveProducto, btn.ToolTipText)
    End Sub


    Private Sub btnIzqSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIzqSub.Click
        If pnlSubmenu.HorizontalScroll.Value > 0 AndAlso (pnlSubmenu.HorizontalScroll.Value - iAvanceSubmenu) >= pnlSubmenu.HorizontalScroll.Minimum Then
            pnlSubmenu.HorizontalScroll.Value -= iAvanceSubmenu
        Else
            pnlSubmenu.HorizontalScroll.Value = pnlSubmenu.HorizontalScroll.Minimum
        End If
    End Sub

    Private Sub btnDerSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDerSub.Click
        If (pnlSubmenu.HorizontalScroll.Value + iAvanceSubmenu) <= pnlSubmenu.HorizontalScroll.Maximum Then
            pnlSubmenu.HorizontalScroll.Value += iAvanceSubmenu
        Else
            pnlSubmenu.HorizontalScroll.Value = pnlSubmenu.HorizontalScroll.Maximum
        End If

    End Sub

    Private Sub btnIniProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIniProd.Click
        pnlProductos.VerticalScroll.Value = pnlProductos.VerticalScroll.Minimum
    End Sub

    Private Sub btnAntProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAntProd.Click
        If pnlProductos.VerticalScroll.Value > 0 AndAlso (pnlProductos.VerticalScroll.Value - iAvanceProductos) >= pnlProductos.VerticalScroll.Minimum Then
            pnlProductos.VerticalScroll.Value -= iAvanceProductos
        Else
            pnlProductos.VerticalScroll.Value = pnlProductos.VerticalScroll.Minimum
        End If
    End Sub

    Private Sub btnSigProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSigProd.Click
        If (pnlProductos.VerticalScroll.Value + iAvanceProductos) <= pnlProductos.VerticalScroll.Maximum Then
            pnlProductos.VerticalScroll.Value += iAvanceProductos
        Else
            pnlProductos.VerticalScroll.Value = pnlProductos.VerticalScroll.Maximum
        End If
    End Sub

    Private Sub btnUltProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUltProd.Click
        pnlProductos.VerticalScroll.Value = pnlProductos.VerticalScroll.Maximum
    End Sub

    Private Sub BtnBorrarTodo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBorrarTodo.Click
        If Not ComandaCerrada Then
            If TotalArticulos > 0 Then
                BorrarTodo()
            Else
                MsgBox("La comanda actual no tiene productos", MsgBoxStyle.Information, "Información")
            End If
        End If
    End Sub



    Private Sub BtnEspera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEspera.Click
        If Tipo = 4 Then
            Dim dtComanda As DataTable

            dtComanda = ModPOS.SiExisteRecupera("sp_recupera_comandawait", "@PDVClave", PDVClave)

            With Me
                If dtComanda Is Nothing OrElse dtComanda.Rows.Count = 0 Then
                    If Not ComandaCerrada AndAlso TotalArticulos > 0 Then

                        ModPOS.Ejecuta("sp_comanda_estado", "@CMDClave", CMDClave, "@Estado", 4)

                        ComandaCerrada = True

                        activaBotones(4, False)

                        dtComandaDetalle.Clear()

                        cambiaStatus("BIENVENIDO", FrmTouch.Status.Original)

                        LblFolio.Text = Referencia & "- "

                        CTEClaveActual = CTEClaveInicial
                        CTENombreActual = CTENombreInicial
                        LblCliente.Text = CTENombreActual

                        BtnEspera.Text = "Espera(1)"

                        MsgBox("La Comanda ha sido puesta en espera exitosamente", MsgBoxStyle.Information, "Información")

                    Else
                        MsgBox("No se encontro una Comanda abierta para poner en espera", MsgBoxStyle.Information, "Información")
                    End If
                Else
                    If ComandaCerrada Then


                        activaBotones(4, True)

                        TotalArticulos = 0
                        TotalPuntos = 0
                        TotalVenta = 0
                        TotalRecibido = 0
                        TotalCambio = 0
                        TotalAhorro = 0


                        'recupera ticket
                        .ComandaNueva = False
                        .CMDClave = dtComanda.Rows(0)("CMDClave")
                        .LblFolio.Text = dtComanda.Rows(0)("Folio")
                        .CTEClaveActual = dtComanda.Rows(0)("CTEClave")
                        .CTENombreActual = dtComanda.Rows(0)("RazonSocial")
                        .LblCliente.Text = .CTENombreActual

                        .CajeroClave = dtComanda.Rows(0)("Cajero")
                        .CajeroNombre = dtComanda.Rows(0)("NombreCajero")
                        .MeseroClave = dtComanda.Rows(0)("Mesero")
                        .MeseroNombre = dtComanda.Rows(0)("NombreMesero")
                        .LblCajero.Text = .CajeroNombre
                        .LblMesero.Text = .MeseroNombre


                        Dim dtCliente As DataTable
                        dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", CTEClaveActual)
                        .ListaPrecio = dtCliente.Rows(0)("PREClave")
                        .TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                        dtCliente.Dispose()


                        'Recupera los descuentos de cliente
                     
                            .DescuentoCliente = -1
                            .PorcDescCliente = 0
                     
                        If .CambiarCliente = False Then
                            .BtnCliente.Enabled = False
                            .TxtCliente.Enabled = False
                        End If

                        cambiaStatus("COMANDA (ABIERTA)", Status.Abierto)

                        llenaGrid(CMDClave)


                        dtComanda.Dispose()


                        .TotalArticulos = dtComandaDetalle.Rows.Count

                        Dim i As Integer

                        For i = 0 To dtComandaDetalle.Rows.Count - 1
                            .TotalAhorro += ((dtComandaDetalle.Rows(i)("Descuento") * (1 + dtComandaDetalle.Rows(i)("PorcImpuesto"))) * dtComandaDetalle.Rows(i)("Cant."))
                            .TotalPuntos += (dtComandaDetalle.Rows(i)("Puntos") * dtComandaDetalle.Rows(i)("Cant."))
                            .TotalVenta += (dtComandaDetalle.Rows(i)("Subtotal"))
                        Next

                        LblCantidadPuntos.Text = CStr(ModPOS.Redondear(.TotalPuntos, 2))
                        LblAhorro.Text = Format(CStr(ModPOS.Redondear(.TotalAhorro, 2)), "Currency")
                        LblTotal.Text = Format(CStr(ModPOS.Redondear(.TotalVenta, 2)), "Currency")

                        If Moneda <> MonedaCambio Then
                            If TotalVenta > 0 Then
                                LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                            Else
                                LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                            End If
                        End If

                        ModPOS.Ejecuta("sp_comanda_estado", "@CMDClave", CMDClave, "@Estado", 1)

                        ComandaCerrada = False
                        ComandaNueva = True
                        GeneraMovSalida = True
                        MsgBox("La Comanda en espera ha sido recuperada exitosamente", MsgBoxStyle.Information, "Información")
                        BtnEspera.Text = "Espera"
                    Else
                        MsgBox("No es posible recuperar la Comanda debido a que existe una Comanda abierta o en uso", MsgBoxStyle.Information, "Información")
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub BtnRepetir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRepetir.Click
        If ComandaCerrada = False Then
            If dtComandaDetalle.Rows.Count > 0 Then

                'actualiza
                Dim foundRows() As System.Data.DataRow
                foundRows = dtComandaDetalle.Select("PROClave = '" & GridDetalle.GetValue("PROClave") & "' and Precio = " & CStr(Redondear(GridDetalle.GetValue("Precio"), 2)) & " and Fase = 0")

                If foundRows.Length > 0 Then
                    foundRows(0)("Cant.") += 1
                    foundRows(0)("Subtotal") += Redondear(GridDetalle.GetValue("Precio"), 2)

                    ModPOS.Ejecuta("sp_actualiza_ComandaDetalle", _
                    "@ALMClave", ALMClave, _
                    "@CMDClave", CMDClave, _
                    "@DCMClave", GridDetalle.GetValue("DCMClave"), _
                    "@PROClave", GridDetalle.GetValue("PROClave"), _
                    "@TProducto", GridDetalle.GetValue("TProducto"), _
                    "@Cantidad", GridDetalle.GetValue("Cant."))

                    TotalPuntos += ((GridDetalle.GetValue("Precio") * GridDetalle.GetValue("PorcPuntos")))
                    TotalAhorro += ((GridDetalle.GetValue("Descuento") * (1 + GridDetalle.GetValue("PorcImpuesto"))))
                    TotalVenta += GridDetalle.GetValue("Precio")
                    SaldoVenta = TotalVenta

                    LblCantidadPuntos.Text = CStr(ModPOS.Redondear(TotalPuntos, 2))
                    LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                    LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

                    If Moneda <> MonedaCambio Then
                        If TotalVenta > 0 Then
                            LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                        Else
                            LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                        End If
                    End If

                End If
            End If
        End If
    End Sub


    Private Function imprimeComanda(ByVal Ticket As String) As Boolean
        Dim i As Integer = 0
        Dim Generic As Boolean

        If dtComandaDetalle.Rows.Count > 0 Then

            Dim dtPrint As DataTable

            dtPrint = ModPOS.Recupera_Tabla("sp_recupera_print_comanda", "@CMDClave", CMDClave)

            If dtPrint.Rows.Count = 0 Then
                dtPrint.Dispose()
                MessageBox.Show("No se encontraron Lineas o Menus asociados a alguna Impresora en la configuración de Impresoras", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
                Exit Function
            End If

            Dim Reimprimir As Boolean = False

            Dim FaseMax, FaseImpresion As Integer

            FaseMax = dtComandaDetalle.Compute("Max(Fase)", "")

            Dim foundBarra() As System.Data.DataRow

            foundBarra = dtComandaDetalle.Select("Fase = 0 ")

            If foundBarra.Length = 0 Then
                Reimprimir = True
                FaseImpresion = FaseMax
            Else
                FaseImpresion = FaseMax + 1
            End If

            Dim z As Integer

            For z = 0 To dtPrint.Rows.Count - 1

                Generic = dtPrint.Rows(z)("Generic")

                If Reimprimir = False Then
                    foundBarra = dtComandaDetalle.Select("Fase = 0 and CLAClave =" & CStr(dtPrint.Rows(z)("CLAClave")))
                Else
                    foundBarra = dtComandaDetalle.Select("Fase =" & CStr(FaseMax) & " and CLAClave=" & CStr(dtPrint.Rows(z)("CLAClave")))
                End If

                If foundBarra.Length > 0 Then


                    Dim NombreClase As String = dtPrint.Rows(z)("Nombre")

                    Dim dArticulos As Double

                    Dim lineasImpresas As Integer = 6

                    Dim Tickets As Imprimir = New Imprimir 'PrintTicket.Ticket()
                    Tickets.Generic = Generic

                    Dim dtTicket As DataTable
                    dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

                    If Not dtTicket Is Nothing Then
                        Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
                        Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
                        Tickets.LetraName = dtTicket.Rows(0)("FontName")
                        If dtTicket.Rows(0)("url_imagen") <> "" Then
                            Tickets.ImgHeader = ModPOS.RecuperaImagen(dtTicket.Rows(0)("url_imagen"))
                        End If
                        dtTicket.Dispose()
                    End If

                    Tickets.AddHeaderLine("*** COMANDA ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
                    Tickets.AddSubHeaderLine(NombreClase, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

                    lineasImpresas += 2

                    If Reimprimir = True Then
                        Tickets.AddSubHeaderLine("REIMPRESION", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
                        lineasImpresas += 1
                    End If


                    Tickets.AddHeaderLine("COMANDA # " & LblFolio.Text, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)

                    If Tipo = 5 Then
                        Tickets.AddHeaderLine(Piso & ", MESA " & Mesa, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    End If

                
                    Tickets.AddHeaderLine("ORDEN # " & CStr(FaseImpresion), Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderLine(DateTime.Today.ToShortDateString & " " & DateTime.Now.ToShortTimeString, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                    Tickets.AddSubHeaderLine("ATIENDE: " & MeseroNombre, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                    lineasImpresas += 4


                    dArticulos = foundBarra.Length

                    lineasImpresas += (dArticulos * 2)

                    Dim dtNota As DataTable

                    For i = 0 To dArticulos - 1
                        Dim sGTIN As String = foundBarra(i)("Clave")
                        Dim sNombre As String = foundBarra(i)("Nombre")
                        Dim dCantidad As Double = foundBarra(i)("Cant.")
                        Dim sUnidad As String = foundBarra(i)("Unidad")


                        ' AGREGAR PRODUCTO A LISTA
                        Tickets.AddItemTransferencia(sGTIN, sNombre, sUnidad, dCantidad)

                        'AGREGAR COMENTARIO A Comanda
                        dtNota = ModPOS.Recupera_Tabla("sp_recupera_nota_cmd", "@DCMClave", foundBarra(i)("DCMClave"))
                        If dtNota.Rows.Count > 0 Then
                            If (dtNota.Rows(0)("Nota") <> "") Then
                                If i < dArticulos - 1 Then
                                    Tickets.AddItemNota(dtNota.Rows(0)("Nota"), "----------------------------------------")
                                Else
                                    Tickets.AddItemNota(dtNota.Rows(0)("Nota"), "")
                                End If
                            End If
                        End If
                        dtNota.Dispose()

                    Next

                    Tickets.AddFooterLine("", 0, 1)

                    lineasImpresas += 2

                    Tickets.PrintTicket(dtPrint.Rows(z)("Referencia"), 70, lineasImpresas)
                End If


            Next

            Dim foundRows() As System.Data.DataRow

            foundRows = dtComandaDetalle.Select("Fase = 0 ")

            For i = 0 To foundRows.Length - 1
                ModPOS.Ejecuta("sp_act_comandadetalle_edo", "@DCMClave", foundRows(i)("DCMClave"), "@Fase", FaseMax + 1)
                foundRows(i)("Fase") = FaseMax + 1
            Next

            Return True
        Else
            MessageBox.Show("No se encontraron productos disponibles para imprimir en la comanda actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Function

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Dim frmStatusMessage As New frmStatus
        frmStatusMessage.Show("Imprimiendo...")
        imprimeComanda(Ticket)
        frmStatusMessage.Dispose()
    End Sub

    Private Function imprimeResumen(ByVal Venta As String, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String, ByVal Redondeo As Double) As Boolean
        If ComandaCerrada = False AndAlso dtComandaDetalle.Rows.Count > 0 Then

            Dim dTotalAhorro, dTotalPuntos, dTotalVenta, dArticulos As Double

            Dim lineasImpresas As Integer = 6

            Dim Tickets As Imprimir = New Imprimir 'PrintTicket.Ticket()
            Tickets.Generic = Generic
            Dim dtTicket As DataTable
            dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

            If Not dtTicket Is Nothing Then
                Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
                Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
                Tickets.LetraName = dtTicket.Rows(0)("FontName")
                If dtTicket.Rows(0)("url_imagen") <> "" Then
                    Tickets.ImgHeader = ModPOS.RecuperaImagen(dtTicket.Rows(0)("url_imagen"))
                End If
                dtTicket.Dispose()
            End If

            Dim dtHeadTicket As DataTable
            dtHeadTicket = ModPOS.SiExisteRecupera("sp_filtra_encabezado", "@TIKClave", Ticket)


            If Not dtHeadTicket Is Nothing Then

                lineasImpresas += dtHeadTicket.Rows.Count

                Dim i As Integer

                For i = 0 To dtHeadTicket.Rows.Count - 1
                    Tickets.AddHeaderLine(CStr(dtHeadTicket.Rows(i)("Texto")), Math.Abs(CInt(dtHeadTicket.Rows(i)("Negrita"))), CInt(dtHeadTicket.Rows(i)("Alinear")))
                Next
                dtHeadTicket.Dispose()
            End If

            Tickets.AddHeaderLine("*** RESUMEN DE CUENTA ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

            If Tipo = 5 Then
                Tickets.AddHeaderLine(Piso & ", MESA " & Mesa, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

                lineasImpresas += 1

            End If

            Tickets.AddHeaderLine("COMANDA # " & LblFolio.Text, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
            Tickets.AddHeaderLine(DateTime.Today.ToShortDateString() & " " & DateTime.Today.ToShortTimeString(), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
            Tickets.AddSubHeaderLine("ATIENDE: " & MeseroNombre, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
            lineasImpresas += 4


            lineasImpresas += (dtComandaDetalle.Rows.Count() * 2)

            If Not dtComandaDetalle Is Nothing Then
                Dim i As Integer = 0
                dArticulos = dtComandaDetalle.Rows.Count()
                For i = 0 To dArticulos - 1
                    Dim sDVEClave As String = dtComandaDetalle.Rows(i)("DCMClave")
                    Dim sGTIN As String = dtComandaDetalle.Rows(i)("Clave")
                    Dim sNombre As String = dtComandaDetalle.Rows(i)("Nombre")
                    Dim dCantidad As Double = dtComandaDetalle.Rows(i)("Cant.")
                    Dim dPrecioNeto As Double = dtComandaDetalle.Rows(i)("Precio")
                    Dim dDescuentoImp As Double = dtComandaDetalle.Rows(i)("Descuento")
                    Dim dPuntosImp As Double = dtComandaDetalle.Rows(i)("Puntos")
                    Dim dTotal As Double = dtComandaDetalle.Rows(i)("Subtotal")
                    Dim dImpuestoPorc As Double = dtComandaDetalle.Rows(i)("PorcImpuesto")

                    Dim dImporteNeto As Double = dPrecioNeto + (dDescuentoImp * (1 + dImpuestoPorc))
                    ' AGREGAR PRODUCTO A LISTA
                    Tickets.AddItemComanda(sDVEClave, sGTIN, sNombre, dCantidad, dImporteNeto, dDescuentoImp)
                    dTotalAhorro += ((dDescuentoImp * (1 + dImpuestoPorc)) * dCantidad)
                    dTotalPuntos += (dPuntosImp * dCantidad)
                    dTotalVenta += (dTotal)
                Next
            End If

          

            dTotalVenta += Redondeo

            Tickets.AddTotal(Redondeo, dTotalVenta, dTotalPuntos, dTotalAhorro, dArticulos, 0, 0, dTotalVenta, 1)

            lineasImpresas += 5

            Dim dtPieTicket As DataTable
            dtPieTicket = ModPOS.SiExisteRecupera("sp_filtra_pie", "@TIKClave", Ticket)

            If Not dtPieTicket Is Nothing Then
                Dim i As Integer

                lineasImpresas += dtPieTicket.Rows.Count

                For i = 0 To dtPieTicket.Rows.Count - 1
                    Tickets.AddFooterLine(CStr(dtPieTicket.Rows(i)("Texto")), Math.Abs(CInt(dtPieTicket.Rows(i)("Negrita"))), CInt(dtPieTicket.Rows(i)("Alinear")))
                Next
                dtPieTicket.Dispose()
            End If

            Tickets.PrintTicket(Impresora, 70, lineasImpresas)

        Else
            MessageBox.Show("No es posible generar el resumen debido a que no se encontraron productos en la comanda actual o ya ha sido cerrada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Function

    Private Sub BtnResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnResumen.Click
        If sTicketResumen <> "" Then
            Dim frmStatusMessage As New frmStatus
            frmStatusMessage.Show("Imprimiendo...")

            imprimeResumen(CMDClave, Impresora, PrintGeneric, sTicketResumen, ImpRedondeo)
            frmStatusMessage.Dispose()
        Else
            MessageBox.Show("No se encontro un ticket de Resumen Activo para la Sucursal Actual")
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub TxtCantidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCantidad.Click
        Dim a As New FrmTecladoNum
        a.Text = "Cantidad de Productos"
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.TxtCantidad.Text = a.Cantidad
        End If
    End Sub

    Private Sub TxtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCliente.KeyPress
        If (Asc(e.KeyChar)) = 13 Then
            If Not TxtCliente.Text = vbNullString Then
                Dim dt As DataTable
                dt = ModPOS.SiExisteRecupera("sp_recupera_clavecte", "@Clave", TxtCliente.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                    CTEClaveActual = dt.Rows(0)("CTEClave")
                    CTENombreActual = dt.Rows(0)("RazonSocial")
                    LblCliente.Text = CTENombreActual
                    TxtCliente.Text = ""
                    dt.Dispose()
                    ModPOS.Ejecuta("sp_actualiza_CMDCliente", _
                                                "@CMDClave", CMDClave, _
                                                "@Cliente", CTEClaveActual, _
                                                "@Usuario", ModPOS.UsuarioActual)

                Else
                    LblCliente.Text = ""
                    TxtCliente.Text = ""
                End If
            End If
        End If
    End Sub


    Private Sub Controls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnAceptar.KeyUp, BtnAnterior.KeyUp, btnAntProd.KeyUp, BtnBorrar.KeyUp, BtnBorrarTodo.KeyUp, BtnCancelar.KeyUp, BtnCerrar.KeyUp, BtnCliente.KeyUp, BtnConsultar.KeyUp, btnDerMenu.KeyUp, btnDerSub.KeyUp, BtnEspera.KeyUp, btnIniProd.KeyUp, btnIzqMenu.KeyUp, btnIzqSub.KeyUp, BtnTicketAnt.KeyUp, BtnNueva.KeyUp, BtnPrimero.KeyUp, BtnRepetir.KeyUp, BtnRestar.KeyUp, BtnResumen.KeyUp, BtnSalir.KeyUp, btnSigProd.KeyUp, BtnSiguiente.KeyUp, BtnSumar.KeyUp, BtnUltimo.KeyUp, btnUltProd.KeyUp, TxtCantidad.KeyUp, TxtCliente.KeyUp, BtnDevolucion.KeyUp, BtnDisminuir.KeyUp, BtnNotas.KeyUp
        If Caja AndAlso e.Control = True AndAlso e.KeyCode = Keys.R Then
            Dim dt As DataTable
            dt = SiExisteRecupera("sp_limite_caja", "@CAJClave", CAJClave, "@Fecha", Today)

            Dim MontoEfectivo, MontoCheques, MontoVales As Double
            Dim retiroEfectivo, retiroCheques, retiroVales As Double
            Dim aperturaEfectivo, aperturaCheques, aperturaVales As Double

            If Not dt Is Nothing Then
                Dim fila As Integer
                For fila = 0 To dt.Rows.Count - 1
                    Select Case CInt(dt.Rows(fila)("TipoPago"))
                        Case Is = 1
                            MontoEfectivo = CDbl(dt.Rows(fila)("Monto"))
                            retiroEfectivo = CDbl(dt.Rows(fila)("Retiro"))
                            aperturaEfectivo = CDbl(dt.Rows(fila)("Apertura"))

                        Case Is = 2
                            MontoCheques = CDbl(dt.Rows(fila)("Monto"))
                            retiroCheques = CDbl(dt.Rows(fila)("Retiro"))
                            aperturaCheques = CDbl(dt.Rows(fila)("Apertura"))

                        Case Is = 4
                            MontoVales = CDbl(dt.Rows(fila)("Monto"))
                            retiroVales = CDbl(dt.Rows(fila)("Retiro"))
                            aperturaVales = CDbl(dt.Rows(fila)("Apertura"))

                    End Select
                Next

                Dim a As New FrmRetiroCaja
                a.SUCClave = SUCClave
                a.ALMClave = ALMClave
                a.CAJClave = CAJClave
                a.Impresora = Impresora
                a.Generic = PrintGeneric
                a.Ticket = Ticket
                a.MontoEfectivo = MontoEfectivo + aperturaEfectivo
                a.MontoCheques = MontoCheques + aperturaCheques
                a.MontoVales = MontoVales + aperturaVales
                a.retiroEfectivo = retiroEfectivo
                a.retiroCheques = retiroCheques
                a.retiroVales = retiroVales
                a.Cajon = Cajon
                a.ShowDialog()
            Else
                MessageBox.Show("No se han registrado ingresos en la caja el día actual para ser retirados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnDerMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDerMod.Click
        If (pnlMod.HorizontalScroll.Value + iAvanceMod) <= pnlMod.HorizontalScroll.Maximum Then
            pnlMod.HorizontalScroll.Value += iAvanceMod
        Else
            pnlMod.HorizontalScroll.Value = pnlMod.HorizontalScroll.Maximum
        End If
    End Sub

    Private Sub btnIzqMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIzqMod.Click
        If pnlMod.HorizontalScroll.Value > 0 AndAlso (pnlMod.HorizontalScroll.Value - iAvanceMod) >= pnlMod.HorizontalScroll.Minimum Then
            pnlMod.HorizontalScroll.Value -= iAvanceMod
        Else
            pnlMod.HorizontalScroll.Value = pnlMod.HorizontalScroll.Minimum
        End If
    End Sub

    Private Sub BtnDisminuir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDisminuir.Click
        If ComandaCerrada = False Then
            If dtComandaDetalle.Rows.Count > 0 Then
        
                'actualiza
                Dim foundRows() As System.Data.DataRow
                foundRows = dtComandaDetalle.Select("PROClave = '" & GridDetalle.GetValue("PROClave") & "' and Precio = " & CStr(Redondear(GridDetalle.GetValue("Precio"), 2)) & " and Fase = 0")

                If foundRows.Length > 0 Then
                    If foundRows(0)("Cant.") > 1 Then
                        foundRows(0)("Cant.") -= 1
                        foundRows(0)("Subtotal") -= Redondear(GridDetalle.GetValue("Precio"), 2)

                        ModPOS.Ejecuta("sp_actualiza_ComandaDetalle", _
                              "@ALMClave", ALMClave, _
                              "@CMDClave", CMDClave, _
                              "@DCMClave", GridDetalle.GetValue("DCMClave"), _
                              "@PROClave", GridDetalle.GetValue("PROClave"), _
                              "@TProducto", GridDetalle.GetValue("TProducto"), _
                              "@Cantidad", GridDetalle.GetValue("Cant."))

                        TotalPuntos -= ((GridDetalle.GetValue("Precio") * GridDetalle.GetValue("PorcPuntos")))
                        TotalAhorro -= ((GridDetalle.GetValue("Descuento") * (1 + GridDetalle.GetValue("PorcImpuesto"))))
                        TotalVenta -= GridDetalle.GetValue("Precio")
                        SaldoVenta = TotalVenta

                        LblCantidadPuntos.Text = CStr(ModPOS.Redondear(TotalPuntos, 2))
                        LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                        LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

                        If Moneda <> MonedaCambio Then
                            If TotalVenta > 0 Then
                                LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                            Else
                                LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                            End If
                        End If

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BtnDevolucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDevolucion.Click
        If ModPOS.Devolucion Is Nothing Then
            ModPOS.Devolucion = New FrmDevolucion
            ModPOS.Devolucion.CAJClave = CAJClave
            ModPOS.Devolucion.Referencia = CajaClave
            ModPOS.Devolucion.LblDescripcion.Text = CajaNombre
            ModPOS.Devolucion.LblUsuario.Text = MPrincipal.StUsuario.Text
            ModPOS.Devolucion.SUCClave = SUCClave
            ModPOS.Devolucion.ALMClave = ALMClave
            ModPOS.Devolucion.Impresora = Impresora
            ModPOS.Devolucion.TicketDev = CajaTICDevolucion
            ModPOS.Devolucion.Caja = CajaNombre
            ModPOS.Devolucion.Cajon = Cajon
            ModPOS.Devolucion.ActivaDevolucion = True
        End If
        ModPOS.Devolucion.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Devolucion.ShowDialog()

    End Sub

    Private Sub BtnTicketAnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTicketAnt.Click
        Dim a As New MeSearchDate
        a.ProcedimientoAlmacenado = "sp_search_ticket_comanda"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Dim dtVenta As DataTable = ModPOS.SiExisteRecupera("sp_recupera_comanda_cerrada", "@CMDClave", a.valor)

            ModPOS.Ejecuta("sp_agrega_tmp_comanda", "@CMDClave", dtVenta.Rows(0)("VENClave"), "@PDVClave", PDVClave, "@MESClave", MESClave)

            Dim frmStatusMessage As New frmStatus
            frmStatusMessage.Show("Imprimiendo...")

            imprimeTicket(dtVenta.Rows(0)("VENClave"), Impresora, PrintGeneric, Ticket, ImpRedondeo, dtVenta.Rows(0)("Total"), dtVenta.Rows(0)("Saldo"), False)

            'Ciclo para impresion de copias

            dtVenta.Dispose()

            frmStatusMessage.Dispose()



        Else
            Exit Sub
        End If

        a.Dispose()

        'Dim a As New FrmTecladoNum
        'a.Text = "No. Ticket para Reimpresión"
        'a.ShowDialog()
        'If a.DialogResult = DialogResult.OK Then
        '    sTicket = a.Cantidad
        'Else
        '    Exit Sub
        'End If


    End Sub

    Private Sub BtnNotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNotas.Click
        If Not ComandaCerrada Then
            If TotalArticulos > 0 Then
                Notas()
            Else
                MsgBox("La comanda actual no tiene productos", MsgBoxStyle.Information, "Información")
            End If
        End If
    End Sub

   
End Class


