Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Collections
Imports System.IO.Ports

Public Class FrmTouchCK
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents LblAhorro As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblFolio As System.Windows.Forms.Label
    Friend WithEvents LblFechaHora As System.Windows.Forms.Label
    Friend WithEvents LblTitulo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBorrarTodo As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnQuitarProducto As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCerrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnNegados As Janus.Windows.EditControls.UIButton
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents LblCantidadPuntos As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblCantidadArticulos As System.Windows.Forms.Label
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents LblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents LblSubTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents SpdetalleopenBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SellingDataSet As Selling.SellingDataSet
    Friend WithEvents Sp_detalle_openTableAdapter As Selling.SellingDataSetTableAdapters.sp_detalle_openTableAdapter
    Friend WithEvents CtxCliente As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ItemEditarCte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemNuevoCte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnEditar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnModelo As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblConsecutivo As System.Windows.Forms.Label
    Friend WithEvents pnlModelo As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btnCatalogo As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnMisPedidos As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTouchCK))
        Dim GridDetalle_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblCantidadPuntos = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.LblTipoCambio = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblAhorro = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblConsecutivo = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblFolio = New System.Windows.Forms.Label()
        Me.LblFechaHora = New System.Windows.Forms.Label()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblCantidadArticulos = New System.Windows.Forms.Label()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.BtnCerrar = New Janus.Windows.EditControls.UIButton()
        Me.BtnNegados = New Janus.Windows.EditControls.UIButton()
        Me.btnQuitarProducto = New Janus.Windows.EditControls.UIButton()
        Me.btnBorrarTodo = New Janus.Windows.EditControls.UIButton()
        Me.LblSubTitulo = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlModelo = New System.Windows.Forms.Panel()
        Me.btnModelo = New Janus.Windows.EditControls.UIButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CtxCliente = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ItemEditarCte = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemNuevoCte = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnEditar = New Janus.Windows.EditControls.UIButton()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.SellingDataSet = New Selling.SellingDataSet()
        Me.SpdetalleopenBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Sp_detalle_openTableAdapter = New Selling.SellingDataSetTableAdapters.sp_detalle_openTableAdapter()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnCatalogo = New Janus.Windows.EditControls.UIButton()
        Me.btnMisPedidos = New Janus.Windows.EditControls.UIButton()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.pnlModelo.SuspendLayout()
        Me.CtxCliente.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SellingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SpdetalleopenBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Red
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(8, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 24)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "PUNTOS"
        Me.Label3.Visible = False
        '
        'LblCantidadPuntos
        '
        Me.LblCantidadPuntos.BackColor = System.Drawing.Color.Red
        Me.LblCantidadPuntos.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidadPuntos.ForeColor = System.Drawing.Color.White
        Me.LblCantidadPuntos.Location = New System.Drawing.Point(108, 68)
        Me.LblCantidadPuntos.Name = "LblCantidadPuntos"
        Me.LblCantidadPuntos.Size = New System.Drawing.Size(120, 32)
        Me.LblCantidadPuntos.TabIndex = 10
        Me.LblCantidadPuntos.Text = "14"
        Me.LblCantidadPuntos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LblCantidadPuntos.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.Red
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.LblTotal)
        Me.Panel3.Controls.Add(Me.LblCantidadPuntos)
        Me.Panel3.Controls.Add(Me.LblTipoCambio)
        Me.Panel3.ForeColor = System.Drawing.Color.White
        Me.Panel3.Location = New System.Drawing.Point(975, 332)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(240, 130)
        Me.Panel3.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(13, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "TOTAL"
        '
        'LblTotal
        '
        Me.LblTotal.BackColor = System.Drawing.Color.Transparent
        Me.LblTotal.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.Color.White
        Me.LblTotal.Location = New System.Drawing.Point(4, 28)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(230, 40)
        Me.LblTotal.TabIndex = 8
        Me.LblTotal.Text = "$353.45 M.N"
        Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTipoCambio.BackColor = System.Drawing.Color.Transparent
        Me.LblTipoCambio.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipoCambio.ForeColor = System.Drawing.Color.White
        Me.LblTipoCambio.Location = New System.Drawing.Point(0, 97)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(229, 24)
        Me.LblTipoCambio.TabIndex = 41
        Me.LblTipoCambio.Text = "PUNTO DE VENTA"
        Me.LblTipoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.LblAhorro)
        Me.Panel4.Location = New System.Drawing.Point(975, 278)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(240, 48)
        Me.Panel4.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(11, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 32)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "AHORRO"
        '
        'LblAhorro
        '
        Me.LblAhorro.BackColor = System.Drawing.Color.Transparent
        Me.LblAhorro.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAhorro.ForeColor = System.Drawing.Color.Black
        Me.LblAhorro.Location = New System.Drawing.Point(98, 8)
        Me.LblAhorro.Name = "LblAhorro"
        Me.LblAhorro.Size = New System.Drawing.Size(136, 32)
        Me.LblAhorro.TabIndex = 9
        Me.LblAhorro.Text = "$353.45"
        Me.LblAhorro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Controls.Add(Me.lblConsecutivo)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.LblFolio)
        Me.Panel5.Location = New System.Drawing.Point(974, 2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(240, 57)
        Me.Panel5.TabIndex = 9
        '
        'lblConsecutivo
        '
        Me.lblConsecutivo.BackColor = System.Drawing.Color.Transparent
        Me.lblConsecutivo.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsecutivo.ForeColor = System.Drawing.Color.Black
        Me.lblConsecutivo.Location = New System.Drawing.Point(100, 1)
        Me.lblConsecutivo.Name = "lblConsecutivo"
        Me.lblConsecutivo.Size = New System.Drawing.Size(138, 34)
        Me.lblConsecutivo.TabIndex = 9
        Me.lblConsecutivo.Text = "-"
        Me.lblConsecutivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(14, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 23)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "PEDIDO"
        '
        'LblFolio
        '
        Me.LblFolio.BackColor = System.Drawing.Color.Transparent
        Me.LblFolio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFolio.ForeColor = System.Drawing.Color.Black
        Me.LblFolio.Location = New System.Drawing.Point(2, 39)
        Me.LblFolio.Name = "LblFolio"
        Me.LblFolio.Size = New System.Drawing.Size(236, 14)
        Me.LblFolio.TabIndex = 8
        Me.LblFolio.Text = "-"
        Me.LblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblFechaHora
        '
        Me.LblFechaHora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFechaHora.BackColor = System.Drawing.Color.Transparent
        Me.LblFechaHora.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFechaHora.ForeColor = System.Drawing.Color.Black
        Me.LblFechaHora.Location = New System.Drawing.Point(686, 67)
        Me.LblFechaHora.Name = "LblFechaHora"
        Me.LblFechaHora.Size = New System.Drawing.Size(282, 17)
        Me.LblFechaHora.TabIndex = 11
        Me.LblFechaHora.Text = "Lunes, 31 Marzo"
        Me.LblFechaHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.Red
        Me.LblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblTitulo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(4, 2)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(186, 57)
        Me.LblTitulo.TabIndex = 12
        Me.LblTitulo.Text = "Selling"
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(5, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 29)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "AFILIADO:"
        '
        'LblCliente
        '
        Me.LblCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCliente.BackColor = System.Drawing.Color.Transparent
        Me.LblCliente.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCliente.ForeColor = System.Drawing.Color.Black
        Me.LblCliente.Location = New System.Drawing.Point(137, 67)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(581, 29)
        Me.LblCliente.TabIndex = 15
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.BackColor = System.Drawing.Color.Red
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.LblCantidadArticulos)
        Me.Panel6.Location = New System.Drawing.Point(975, 223)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(240, 49)
        Me.Panel6.TabIndex = 37
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(8, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(137, 22)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = " POSICIONES"
        '
        'LblCantidadArticulos
        '
        Me.LblCantidadArticulos.BackColor = System.Drawing.Color.Transparent
        Me.LblCantidadArticulos.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidadArticulos.ForeColor = System.Drawing.Color.White
        Me.LblCantidadArticulos.Location = New System.Drawing.Point(112, 4)
        Me.LblCantidadArticulos.Name = "LblCantidadArticulos"
        Me.LblCantidadArticulos.Size = New System.Drawing.Size(120, 32)
        Me.LblCantidadArticulos.TabIndex = 10
        Me.LblCantidadArticulos.Text = "14"
        Me.LblCantidadArticulos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblStatus
        '
        Me.LblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblStatus.BackColor = System.Drawing.Color.White
        Me.LblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblStatus.Font = New System.Drawing.Font("Arial", 17.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStatus.ForeColor = System.Drawing.Color.Black
        Me.LblStatus.Location = New System.Drawing.Point(189, 2)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(782, 57)
        Me.LblStatus.TabIndex = 40
        Me.LblStatus.Text = "P U N T O - D E - V E N T A"
        Me.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCerrar.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Icon = CType(resources.GetObject("BtnCerrar.Icon"), System.Drawing.Icon)
        Me.BtnCerrar.ImageSize = New System.Drawing.Size(18, 18)
        Me.BtnCerrar.Location = New System.Drawing.Point(0, 3)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnCerrar.Office2007CustomColor = System.Drawing.Color.Yellow
        Me.BtnCerrar.Size = New System.Drawing.Size(240, 140)
        Me.BtnCerrar.TabIndex = 11
        Me.BtnCerrar.Text = "Surtir"
        Me.BtnCerrar.ToolTipText = "Cierra el Documento Actual"
        Me.BtnCerrar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnNegados
        '
        Me.BtnNegados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNegados.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNegados.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNegados.Icon = CType(resources.GetObject("BtnNegados.Icon"), System.Drawing.Icon)
        Me.BtnNegados.Location = New System.Drawing.Point(661, 98)
        Me.BtnNegados.Name = "BtnNegados"
        Me.BtnNegados.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Silver
        Me.BtnNegados.Size = New System.Drawing.Size(110, 60)
        Me.BtnNegados.TabIndex = 12
        Me.BtnNegados.Text = "Negados"
        Me.BtnNegados.ToolTipText = "Crea una Pedido o Venta "
        Me.BtnNegados.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnQuitarProducto
        '
        Me.btnQuitarProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuitarProducto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitarProducto.Icon = CType(resources.GetObject("btnQuitarProducto.Icon"), System.Drawing.Icon)
        Me.btnQuitarProducto.Location = New System.Drawing.Point(236, 98)
        Me.btnQuitarProducto.Name = "btnQuitarProducto"
        Me.btnQuitarProducto.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Silver
        Me.btnQuitarProducto.Size = New System.Drawing.Size(110, 60)
        Me.btnQuitarProducto.TabIndex = 7
        Me.btnQuitarProducto.Text = "Quitar "
        Me.btnQuitarProducto.ToolTipText = "Elimina el producto seleccionado"
        Me.btnQuitarProducto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnBorrarTodo
        '
        Me.btnBorrarTodo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBorrarTodo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrarTodo.Icon = CType(resources.GetObject("btnBorrarTodo.Icon"), System.Drawing.Icon)
        Me.btnBorrarTodo.Location = New System.Drawing.Point(120, 98)
        Me.btnBorrarTodo.Name = "btnBorrarTodo"
        Me.btnBorrarTodo.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Silver
        Me.btnBorrarTodo.Size = New System.Drawing.Size(110, 60)
        Me.btnBorrarTodo.TabIndex = 6
        Me.btnBorrarTodo.Text = "Borrar Todo"
        Me.btnBorrarTodo.ToolTipText = "Elimina todos los productos del documento"
        Me.btnBorrarTodo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblSubTitulo
        '
        Me.LblSubTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSubTitulo.BackColor = System.Drawing.Color.White
        Me.LblSubTitulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubTitulo.ForeColor = System.Drawing.Color.White
        Me.LblSubTitulo.Location = New System.Drawing.Point(205, 41)
        Me.LblSubTitulo.Name = "LblSubTitulo"
        Me.LblSubTitulo.Size = New System.Drawing.Size(753, 16)
        Me.LblSubTitulo.TabIndex = 46
        Me.LblSubTitulo.Text = "Presione <Ctrl+T> para Convertir a otro Tipo de Documento"
        Me.LblSubTitulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel8.BackColor = System.Drawing.Color.Red
        Me.Panel8.Controls.Add(Me.Label11)
        Me.Panel8.Controls.Add(Me.pnlModelo)
        Me.Panel8.Controls.Add(Me.Label10)
        Me.Panel8.Location = New System.Drawing.Point(974, 65)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(241, 152)
        Me.Panel8.TabIndex = 55
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(11, 128)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(211, 19)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Escribe el Modelo y presiona el botón [Enter]"
        '
        'pnlModelo
        '
        Me.pnlModelo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlModelo.BackColor = System.Drawing.Color.Transparent
        Me.pnlModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlModelo.Controls.Add(Me.btnModelo)
        Me.pnlModelo.ForeColor = System.Drawing.Color.Red
        Me.pnlModelo.Location = New System.Drawing.Point(11, 34)
        Me.pnlModelo.Name = "pnlModelo"
        Me.pnlModelo.Size = New System.Drawing.Size(218, 90)
        Me.pnlModelo.TabIndex = 1
        '
        'btnModelo
        '
        Me.btnModelo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnModelo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnModelo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModelo.Icon = CType(resources.GetObject("btnModelo.Icon"), System.Drawing.Icon)
        Me.btnModelo.ImageSize = New System.Drawing.Size(30, 30)
        Me.btnModelo.Location = New System.Drawing.Point(0, 0)
        Me.btnModelo.Name = "btnModelo"
        Me.btnModelo.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.btnModelo.Office2007CustomColor = System.Drawing.Color.Yellow
        Me.btnModelo.Size = New System.Drawing.Size(218, 90)
        Me.btnModelo.TabIndex = 84
        Me.btnModelo.Text = "Agregar Modelo"
        Me.btnModelo.ToolTipText = "Agregar Modelo"
        Me.btnModelo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(15, 7)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(175, 19)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "!COMIENZA AQUí!"
        '
        'CtxCliente
        '
        Me.CtxCliente.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemEditarCte, Me.ItemNuevoCte})
        Me.CtxCliente.Name = "CtxDocumentos"
        Me.CtxCliente.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.CtxCliente.Size = New System.Drawing.Size(126, 48)
        Me.CtxCliente.Text = "Cliente"
        '
        'ItemEditarCte
        '
        Me.ItemEditarCte.Image = CType(resources.GetObject("ItemEditarCte.Image"), System.Drawing.Image)
        Me.ItemEditarCte.Name = "ItemEditarCte"
        Me.ItemEditarCte.Size = New System.Drawing.Size(125, 22)
        Me.ItemEditarCte.Text = "Modificar"
        Me.ItemEditarCte.ToolTipText = "Editar la información del cliente"
        '
        'ItemNuevoCte
        '
        Me.ItemNuevoCte.Image = Global.Selling.My.Resources.Resources._1399173015_106230
        Me.ItemNuevoCte.Name = "ItemNuevoCte"
        Me.ItemNuevoCte.Size = New System.Drawing.Size(125, 22)
        Me.ItemNuevoCte.Text = "Nuevo"
        Me.ItemNuevoCte.ToolTipText = "Agrega un nuevo cliente"
        '
        'BtnModificar
        '
        Me.BtnModificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnModificar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnModificar.Icon = CType(resources.GetObject("BtnModificar.Icon"), System.Drawing.Icon)
        Me.BtnModificar.Location = New System.Drawing.Point(352, 98)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Silver
        Me.BtnModificar.Size = New System.Drawing.Size(110, 60)
        Me.BtnModificar.TabIndex = 60
        Me.BtnModificar.Text = "Modificar"
        Me.BtnModificar.ToolTipText = "Agregar o Modificar Información Complementaria"
        Me.BtnModificar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnSalir
        '
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Icon = CType(resources.GetObject("btnSalir.Icon"), System.Drawing.Icon)
        Me.btnSalir.Location = New System.Drawing.Point(4, 99)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.btnSalir.Office2007CustomColor = System.Drawing.Color.IndianRed
        Me.btnSalir.Size = New System.Drawing.Size(110, 60)
        Me.btnSalir.TabIndex = 81
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.ToolTipText = "Cerrar Punto  de Venta"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'btnEditar
        '
        Me.btnEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Icon = CType(resources.GetObject("btnEditar.Icon"), System.Drawing.Icon)
        Me.btnEditar.Location = New System.Drawing.Point(545, 98)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.btnEditar.Office2007CustomColor = System.Drawing.Color.LightYellow
        Me.btnEditar.Size = New System.Drawing.Size(110, 60)
        Me.btnEditar.TabIndex = 83
        Me.btnEditar.Text = "Datos"
        Me.btnEditar.ToolTipText = "Modificar Información Cuenta"
        Me.btnEditar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridDetalle
        '
        Me.GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.DataMember = "sp_detalle_open"
        Me.GridDetalle.DataSource = Me.SellingDataSet
        GridDetalle_DesignTimeLayout.LayoutString = resources.GetString("GridDetalle_DesignTimeLayout.LayoutString")
        Me.GridDetalle.DesignTimeLayout = GridDetalle_DesignTimeLayout
        Me.GridDetalle.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.GroupByBoxVisible = False
        Me.GridDetalle.Location = New System.Drawing.Point(4, 164)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Silver
        Me.GridDetalle.Office2007CustomColor = System.Drawing.SystemColors.ActiveCaption
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(969, 448)
        Me.GridDetalle.TabIndex = 56
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'SellingDataSet
        '
        Me.SellingDataSet.DataSetName = "SellingDataSet"
        Me.SellingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SpdetalleopenBindingSource
        '
        Me.SpdetalleopenBindingSource.DataMember = "sp_detalle_open"
        Me.SpdetalleopenBindingSource.DataSource = Me.SellingDataSet
        '
        'Sp_detalle_openTableAdapter
        '
        Me.Sp_detalle_openTableAdapter.ClearBeforeFill = True
        '
        'Panel7
        '
        Me.Panel7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.BtnCerrar)
        Me.Panel7.ForeColor = System.Drawing.Color.Red
        Me.Panel7.Location = New System.Drawing.Point(976, 468)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(240, 142)
        Me.Panel7.TabIndex = 84
        '
        'btnCatalogo
        '
        Me.btnCatalogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCatalogo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCatalogo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCatalogo.Icon = CType(resources.GetObject("btnCatalogo.Icon"), System.Drawing.Icon)
        Me.btnCatalogo.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnCatalogo.Location = New System.Drawing.Point(777, 98)
        Me.btnCatalogo.Name = "btnCatalogo"
        Me.btnCatalogo.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.btnCatalogo.Office2007CustomColor = System.Drawing.Color.Tomato
        Me.btnCatalogo.Size = New System.Drawing.Size(194, 60)
        Me.btnCatalogo.TabIndex = 85
        Me.btnCatalogo.Text = "Agregar Catálogos"
        Me.btnCatalogo.ToolTipText = "Agregar Catálogos"
        Me.btnCatalogo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnMisPedidos
        '
        Me.btnMisPedidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMisPedidos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMisPedidos.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMisPedidos.Icon = CType(resources.GetObject("btnMisPedidos.Icon"), System.Drawing.Icon)
        Me.btnMisPedidos.Location = New System.Drawing.Point(429, 98)
        Me.btnMisPedidos.Name = "btnMisPedidos"
        Me.btnMisPedidos.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.btnMisPedidos.Office2007CustomColor = System.Drawing.Color.DeepSkyBlue
        Me.btnMisPedidos.Size = New System.Drawing.Size(110, 60)
        Me.btnMisPedidos.TabIndex = 86
        Me.btnMisPedidos.Text = "Mis Pedidos"
        Me.btnMisPedidos.ToolTipText = "Consultar Mis Pedidos"
        Me.btnMisPedidos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmTouchCK
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1217, 613)
        Me.Controls.Add(Me.btnMisPedidos)
        Me.Controls.Add(Me.btnCatalogo)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.BtnModificar)
        Me.Controls.Add(Me.GridDetalle)
        Me.Controls.Add(Me.LblSubTitulo)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.BtnNegados)
        Me.Controls.Add(Me.btnQuitarProducto)
        Me.Controls.Add(Me.btnBorrarTodo)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.LblCliente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.LblFechaHora)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmTouchCK"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Punto de Venta"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.pnlModelo.ResumeLayout(False)
        Me.CtxCliente.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SellingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SpdetalleopenBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private AccesoAutorizado As Boolean = False
    Private LimitaCompraEmp As Integer = 0
    Private CerrarSesion As Boolean = False
    Public TipoCanal As Integer = 0

    Public Enum iEstado
        Original = -1
        Abierto = 1
        Cerrado = 2
        Pagado = 3
        Cancelada = 4
        'Facturado = 5
        'Espera = 6
        Picking = 7
        Remoto = 9
        BackOrder = 11
    End Enum

    Private Enum TipoMov
        Entrada = 1
        Salida = 2
    End Enum

    Public VentaAbierta As Boolean = False
    Private AplicaPromocionFinal As Integer = 1
    Public Remoto As Integer = 0
    Public BloquearPrecio As Integer = 0
    Public ImprimirRemoto As Integer = 0
    Public sFrase As String
    Public MaxCaracteres As Integer
    Public NoLineas As Integer
    Public ActivarCotizacion As Boolean = True
    Public Picking, Packing, ticketPicking As Boolean
    Public SurtidoRF As Boolean
    Public MostradorRF As Boolean
    Private TipoSucursal As Integer
    Private SucursalPadre, TIKClave As String

    Public CreditoGeneral As String 'Cliente Credito General
    Public ActivaDevolucion As Boolean  'Permite Devolucion sin caja activa
    Public ALMClave As String 'Clave del Almacen Origen
    Public AlmacenOpen As String
    Public AlmacenClave As String
    Public AlmacenNombre As String
    Public SucursalSurtido As String
    Public PDVClave As String 'Clave de Punto de Venta
    Public Referencia As String 'Referencia de Punto de Venta
    Public PuntodeVenta As String 'Descripcion de Punto de Venta
    Public Supervisor As String 'Supervisor de Punto de Venta
    Public ValidaInventario As Boolean = False
    Public PrintGeneric As Boolean
    Public Impresora As String 'Impresora de Tickets
    Public Ticket As String 'Plantilla de Ticket
    Public NumCopias As Integer 'Determina el numero de copias a imprimir para documentos nuevos
    Public Caja As Boolean ' Activa al punto de venta con su caja
    Public CAJClave As String 'Clave de la Caja

    Public CambiaPrecio As Boolean 'Muestra pantalla para elegir precio
    Public ModificaPrecioServicio As Boolean ' Muestra pantalla para cambiar presio de productos tipo servicio
    Public Agotamiento As Boolean 'Notificar agotamiento de productos
    Public ImpRedondeo As Double 'Importe del redondeo
    Public Url_Redondeo As String 'Url de imagen de redondeo
    Public AtiendeClave, ReferenciaUsr As String ' Identificador del Cajero
    Public PorcMaxDesc As Double 'Porcentaje Maximo descuento del vendedor
    Public USRCambiaPrecio As Boolean 'Si se le permite cambiar precios al vendedor
    Public AtiendeNombre As String ' Nombre del Cajero
    Private ClienteSAP As String

    Private DescuentoDirecto As Double

    Public CTEClaveInicial As String 'Identificador de Cliente Inicial
    Public CTENombreInicial As String 'Nombre de Cliente Inicial

    Public CTEClaveActual As String 'Identificador de Cliente Actual
    Public CtaMaestra As String
    Public CreditoDisp As Decimal
    Public LimiteCredito As Decimal
    Public DiasCredito As Integer
    Public SaldoCte As Decimal

    Public DCTEClave As String
    Public CTENombreActual As String 'Nombre de Cliente Actual
    Public NumeroAfiliado As String

    Public Folio As Integer = -1

    Public GeneraMovSalida As Boolean = False
    Public SolicitaVendedor As Boolean 'Solicita vendedor al crear venta
    Public VENClave As String = "" 'Identificador de la Venta
    Public SaldoVenta As Double = 0.0
    Public TotalAhorro As Double = 0.0
    Public TotalArticulos As Double = 0.0
    Public TotalPuntos As Double = 0.0
    Public TotalVenta As Double = 0.0
    Public VentaCerrada As Boolean = True
    Public ListaPrecio As String
    Public TImpuesto As Integer
    Public NivelDesc As String
    Public PorcDescCliente As Double
    Public TotalRecibido As Double = 0.0
    Public TotalCambio As Double = 0.0
    'Public FormaPago As Integer
    Public TipoDesCte As Integer
    Public DESClave As String
    Public TipoDocumento As Integer
    Public EstadoDocumento As Integer
    Public sFolio As String = "-"

    Private dtCombo As DataTable

    Private AlmacenSurtido As String  'Clave del almacén surtido
    Private SUCClave As String = "" 'SUCURSAL
    Private bLoad As Boolean = False
    Private Cantidad As Double = 1
    ' Private PorcImpProducto As Double
    Private Autoriza As String

    Private CreditoDisponible As Double = 0.0
    Private sGTIN As String = ""
    Private NotaCreditos As String = ""
    Private MonedaCambio As String
    Private InterfazSalida As String = ""
    Private Moneda As String
    Private MonedaRef, MonRefCambio As String
    Private TipoCambio As Double = 1
    Private MonTipoCambio As Double = 1

    Private mySerialPort As New SerialPort
    Private sAlmacen As String = ""
    Private url_imagen As String
    Private Periodo, Mes As Integer
    Private bCierreApertura As Boolean = False
    Private dtPedidoDetalle As DataTable
    '  Private bComplemento As Boolean = False
    Private iDesglosarPrecio As Integer = 0
    Private UltimoCodigo As String = ""
    Private MaskCte As Integer = 0
    Private TallaColor As Integer = 0
    Private SincronizaCte As Integer = 0
    Private FolioTmp As Integer = 0
    Private bMessage As Boolean = True
    Public UBCClave As String = ""
    Private FormatoPedido As String
    Private Logo2 As Image
    Private BuscaNegados As Integer = 0


    Public Sub btnVentaPerformClick(ByVal Buscar As String)
        sGTIN = Buscar
        Me.BtnNegados.PerformClick()
    End Sub

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

    Private Sub ObtenerFolio(ByVal tmp As Boolean)
        If tmp = False Then
            Dim dt As DataTable
            dt = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 1, "@PDVClave", PDVClave)

            If dt Is Nothing Then
                ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 1, "@PDVClave", PDVClave)
                Folio = 1
                Periodo = Today.Year
                Mes = Today.Month
            Else

                Folio = CInt(dt.Rows(0)("UltimoConsecutivo")) + 1
                Periodo = dt.Rows(0)("Periodo")
                Mes = dt.Rows(0)("Mes")
                ModPOS.Ejecuta("sp_act_folio", "@Tipo", 1, "@PDVClave", PDVClave, "@Incremento", 1)

                dt.Dispose()
            End If

            LblFolio.Text = Referencia & Microsoft.VisualBasic.Right(CStr(Periodo), 2) & Microsoft.VisualBasic.Right("0" & CStr(Mes), 2) & "-" & CStr(Folio)
            lblConsecutivo.Text = CStr(Folio)
        Else

            Dim dtventa As DataTable

            dtventa = ModPOS.Recupera_Tabla("st_recupera_foliotmp", "@PDVClave", PDVClave, "@Prefijo", "T" & ReferenciaUsr & Referencia & CStr(Today.DayOfYear) & "-")
            If dtventa.Rows.Count > 0 Then
                If dtventa.Rows(0)("Folio").GetType.Name <> "DBNull" Then
                    FolioTmp = dtventa.Rows(0)("Folio")
                End If
            End If
            dtventa.Dispose()


            FolioTmp += 1
            LblFolio.Text = "T" & ReferenciaUsr & Referencia & CStr(Today.DayOfYear) & "-" & CStr(FolioTmp)

            lblConsecutivo.Text = CStr(FolioTmp)
        End If

    End Sub

    Private Sub VentaContado()
        If VentaCerrada Then

            Dim dt As DataTable

            If AlmacenSurtido = "" OrElse AlmacenSurtido Is Nothing Then
                Beep()
                MessageBox.Show("No es posible crear una nueva venta debido a que no se ha especificado el Almacen para surtido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Exit Sub
            End If



            If SolicitaVendedor Then
                Dim a As New FrmSolicitaUsuario
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    Me.AtiendeNombre = a.AtiendeNombre
                    Me.ReferenciaUsr = a.ReferenciaUsr
                    Me.AtiendeClave = a.AtiendeClave

                Else
                    MessageBox.Show("No es posible crear una nueva venta debido a que no se ha sido registrado un Vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                a.Dispose()

            End If

            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
            MonedaRef = dt.Rows(0)("Referencia")
            TipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
            dt.Dispose()


            If Moneda <> MonedaCambio Then
                dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
                MonRefCambio = dt.Rows(0)("Referencia")
                MonTipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
                dt.Dispose()

            Else
                MonRefCambio = MonedaRef
                MonTipoCambio = TipoCambio
            End If


            TipoDocumento = 1

            EstadoDocumento = 1

            modificaStatus(TipoDocumento, EstadoDocumento)


            ObtenerFolio(True)

            VENClave = ModPOS.obtenerLlave()

            dt = ModPOS.Recupera_Tabla("st_valida_llave", "@Tipo", 1, "@id", VENClave)
            If dt.Rows.Count = 1 Then
                VENClave = ModPOS.obtenerLlave
            End If
            dt.Dispose()

            ModPOS.Ejecuta("sp_crea_venta", _
            "@VENClave", VENClave, _
            "@PDVClave", PDVClave, _
            "@Folio", LblFolio.Text, _
            "@Cliente", CTEClaveActual, _
            "@Cajero", AtiendeClave, _
            "@CAJClave", CAJClave, _
            "@Tipo", TipoDocumento, _
            "@ALMClave", AlmacenSurtido, _
            "@TipoCanal", TipoCanal, _
            "@Usuario", ModPOS.UsuarioActual)




            btnQuitarProducto.Enabled = True
            btnBorrarTodo.Enabled = True

            BtnCerrar.Enabled = True

            VentaCerrada = False
            GeneraMovSalida = True


            dtPedidoDetalle.Clear()

            TotalArticulos = 0
            TotalPuntos = 0
            TotalVenta = 0
            TotalRecibido = 0
            TotalCambio = 0
            TotalAhorro = 0

            LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
            LblCantidadArticulos.Text = CStr(TotalArticulos)
            LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
            LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

            If Moneda <> MonedaCambio Then
                If MonTipoCambio > 0 Then
                    LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                End If
            Else
                LblTipoCambio.Text = ""
            End If

            If sGTIN <> "" Then
                AgregaGTIN(True, sGTIN, False, False)
                sGTIN = ""
            End If



        Else
            Beep()
            MessageBox.Show("No es posible crear una nueva venta debido a que la venta actual no ha sido Cerrada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub VentaCredito()
        If VentaCerrada Then

            If AlmacenSurtido = "" OrElse AlmacenSurtido Is Nothing Then
                Beep()
                MessageBox.Show("No es posible crear una nueva venta debido a que no se ha especificado el Almacen para surtido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim dt As DataTable

            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
            MonedaRef = dt.Rows(0)("Referencia")
            TipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
            dt.Dispose()


            If Moneda <> MonedaCambio Then
                dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
                MonRefCambio = dt.Rows(0)("Referencia")
                MonTipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
                dt.Dispose()

            Else
                MonRefCambio = MonedaRef
                MonTipoCambio = TipoCambio
            End If

            TipoDocumento = 3

            EstadoDocumento = 1


            modificaStatus(TipoDocumento, EstadoDocumento)


            ObtenerFolio(True)

            VENClave = ModPOS.obtenerLlave()

            dt = ModPOS.Recupera_Tabla("st_valida_llave", "@Tipo", 1, "@id", VENClave)
            If dt.Rows.Count = 1 Then
                VENClave = ModPOS.obtenerLlave
            End If
            dt.Dispose()

            ModPOS.Ejecuta("sp_crea_venta", _
            "@VENClave", VENClave, _
            "@PDVClave", PDVClave, _
            "@Folio", LblFolio.Text, _
            "@Cliente", CTEClaveActual, _
            "@Cajero", AtiendeClave, _
            "@CAJClave", CAJClave, _
            "@Tipo", TipoDocumento, _
            "@ALMClave", AlmacenSurtido, _
            "@TipoCanal", TipoCanal, _
            "@Usuario", ModPOS.UsuarioActual)


            btnQuitarProducto.Enabled = True
            btnBorrarTodo.Enabled = True

            BtnCerrar.Enabled = True

            VentaCerrada = False
            GeneraMovSalida = True

            dtPedidoDetalle.Clear()

            TotalArticulos = 0
            TotalPuntos = 0
            TotalVenta = 0
            TotalRecibido = 0
            TotalCambio = 0
            TotalAhorro = 0

            LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
            LblCantidadArticulos.Text = CStr(TotalArticulos)
            LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
            LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")


            If Moneda <> MonedaCambio Then
                If MonTipoCambio > 0 Then
                    LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                End If
            Else
                LblTipoCambio.Text = ""
            End If

            If sGTIN <> "" Then
                AgregaGTIN(True, sGTIN, False, False)
                sGTIN = ""
            End If

        Else
            Beep()
            MessageBox.Show("No es posible crear una nueva venta debido a que la venta actual no ha sido Cerrada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub FrmTouchCK_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
       If CerrarSesion = True Then
            ModPOS.TouchCK = Nothing
            ModPOS.Ejecuta("sp_actualiza_caja", "@PDVClave", PDVClave, "@Fase", 0)
        End If
    End Sub

    Private Function validaExistencia() As Boolean
        Dim dtVentaDetalle, dtDisponible As DataTable
        Dim Disponible As Double
        Dim result As Boolean = True

        dtVentaDetalle = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)

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

                    Dim msg As New FrmMsgTouch
                    msg.TxtTiulo = "ERROR"
                    msg.TxtMsg = "La cantidad registrada del producto " & CStr(dtVentaDetalle.Rows(i)("Clave")) & " excede la cantidad disponible (" & CStr(Disponible) & "), por lo que no es posible cambiar el tipo de documento"
                    msg.btnCancel.Visible = False
                    msg.btnOK.Text = "OK"
                    msg.ShowDialog()
                    If msg.DialogResult = DialogResult.OK Then
                    End If

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
        dtVentaDetalle = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)
        If Not dtVentaDetalle Is Nothing AndAlso dtVentaDetalle.Rows.Count > 0 Then
            Dim i As Integer = 0
            For i = 0 To dtVentaDetalle.Rows.Count - 1
                ModPOS.Ejecuta("sp_actualiza_exist_producto", "@ALMClave", ALMClave, "@PROClave", dtVentaDetalle.Rows(i)("PROClave"), "@TProducto", dtVentaDetalle.Rows(i)("TProducto"), "@Cantidad", dtVentaDetalle.Rows(i)("Cantidad"), "@Mov", Tipo)
            Next
            dtVentaDetalle.Dispose()
        End If
    End Sub



    Private Sub TouchCK_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtCombo = ModPOS.CrearTabla("Combo", _
                                    "Clave", "System.String", _
                                    "Cantidad", "System.Decimal", _
                                     "Precio", "System.Decimal", _
                                     "PREClave", "System.String"
                                    )


        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_obtener_usuario", "@USRClave", ModPOS.UsuarioActual)

        AtiendeClave = dt.Rows(0)("USRClave")
        ReferenciaUsr = dt.Rows(0)("Referencia")
        AtiendeNombre = dt.Rows(0)("Nombre")
        USRCambiaPrecio = dt.Rows(0)("CambiaPrecio")
        PorcMaxDesc = dt.Rows(0)("PorcMaxDesc")

        dt.Dispose()

        LblFolio.Text = sFolio
        LblCantidadArticulos.Text = "0"
        LblCantidadPuntos.Text = "0"
        LblAhorro.Text = "$0.00"
        LblTotal.Text = "$0.00"

        If sFolio.Split("-").Length > 1 Then
            Dim iArray As Integer = sFolio.Split("-").Length - 1
            If IsNumeric(sFolio.Split("-")(iArray)) = True Then
                lblConsecutivo.Text = CStr(sFolio.Split("-")(iArray))
            Else
                lblConsecutivo.Text = ""
            End If
        Else
            lblConsecutivo.Text = ""
        End If

        dtPedidoDetalle = ModPOS.Recupera_Tabla("sp_detalle_open", "@VENClave", "")
        GridDetalle.DataSource = dtPedidoDetalle

        GridDetalle.RootTable.Columns("Cantidad").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Precio").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Importe").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("% Desc").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Desc").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Impts").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far




        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Desc"), Janus.Windows.GridEX.ConditionOperator.GreaterThan, 0)
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridDetalle.RootTable.FormatConditions.Add(fc)


        Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
        fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc1.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc1.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridDetalle.RootTable.FormatConditions.Add(fc1)


        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "FormatPedido"
                        FormatoPedido = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dt.Rows(i)("Valor"))

                    Case "Moneda"
                        Moneda = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "MonedaCambio"
                        MonedaCambio = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "Imagenes"
                        url_imagen = CStr(dt.Rows(i)("Valor"))
                        If Not url_imagen.Substring(url_imagen.Length - 1, 1) = "\" Then
                            url_imagen &= "\"
                        End If
                    Case "InterfazSalida"
                        InterfazSalida = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "PrecioBase"
                        iDesglosarPrecio = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                    Case "MascaraCte"
                        MaskCte = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))

                    Case "SincronizaCliente"
                        SincronizaCte = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                    Case "TallaColor"
                        TallaColor = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))

                    Case "BuscaNegados"
                        BuscaNegados = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))

                    Case "AplicaPromocionFinal"
                        AplicaPromocionFinal = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 1, dt.Rows(i)("Valor"))

                    Case "LimitaCompraEmp"
                        LimitaCompraEmp = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))

                End Select
            Next
        End With
        dt.Dispose()


        dt = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)
        If Not dt.Rows(0)("Logo2") Is System.DBNull.Value Then
            Logo2 = ModPOS.RecuperaIcono(CType(dt.Rows(0)("Logo2"), Byte()))
        End If
        dt.Dispose()


        SUCClave = SucursalSurtido

        AlmacenSurtido = ALMClave
        sAlmacen = AlmacenClave & " - " & AlmacenNombre

        dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)
        TipoSucursal = dt.Rows(0)("Tipo")
        SucursalPadre = IIf(dt.Rows(0)("SUCClavePadre").GetType.Name = "DBNull", "", dt.Rows(0)("SUCClavePadre"))
        Picking = IIf(dt.Rows(0)("Picking").GetType.Name = "DBNull", False, dt.Rows(0)("Picking"))
        SurtidoRF = IIf(dt.Rows(0)("SurtidoRF").GetType.Name = "DBNull", False, dt.Rows(0)("SurtidoRF"))
        MostradorRF = IIf(dt.Rows(0)("SurtidoRFMostrador").GetType.Name = "DBNull", False, dt.Rows(0)("SurtidoRFMostrador"))
        Packing = IIf(dt.Rows(0)("Packing").GetType.Name = "DBNull", False, dt.Rows(0)("Packing"))
        ticketPicking = IIf(dt.Rows(0)("ticketPicking").GetType.Name = "DBNull", False, dt.Rows(0)("ticketPicking"))
        TIKClave = IIf(dt.Rows(0)("TIKClave").GetType.Name = "DBNull", "", dt.Rows(0)("TIKClave"))
        dt.Dispose()


        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
        MonedaRef = dt.Rows(0)("Referencia")
        TipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
        dt.Dispose()


        If Moneda <> MonedaCambio Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
            MonRefCambio = dt.Rows(0)("Referencia")
            MonTipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
            dt.Dispose()

        Else
            MonRefCambio = MonedaRef
            MonTipoCambio = TipoCambio
        End If


        LblTitulo.Text = PuntodeVenta

        LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
        LblCantidadArticulos.Text = CStr(TotalArticulos)
        LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
        LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
        Me.LblFechaHora.Text = DateTime.Today.ToLongDateString & " " & DateTime.Now.ToShortTimeString 'ToString("MMMM dd, yyyy")

        If Moneda <> MonedaCambio Then
            If MonTipoCambio > 0 Then
                LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
            Else
                LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
            End If
        Else
            LblTipoCambio.Text = ""
        End If


        bLoad = True

        LblCliente.Text = ""
        AccesoAutorizado = False

        While AccesoAutorizado = False
            Dim b As New FrmObtieneAfiliado
            b.Imagen = Logo2
            b.SUCClave = SUCClave
            b.MaskCte = MaskCte
            b.WindowState = FormWindowState.Maximized
            b.BringToFront()
            b.ShowDialog()
            If b.DialogResult = DialogResult.OK Then
                If b.CTEClave = "111111111" Then
                    CerrarSesion = True
                    Me.Close()
                    Exit Sub
                End If



                AccesoAutorizado = cambiaCliente(b.CTEClave)
            Else
                MessageBox.Show("No es posible iniciar debido a que no se ha especificado al cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            b.Dispose()


        End While

        Clock.Start()

    End Sub

    Private Sub Clock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock.Tick
        Me.LblFechaHora.Text = DateTime.Today.ToLongDateString & " " & DateTime.Now.ToShortTimeString 'ToString("MMMM dd, yyyy")
    End Sub


    Private Sub cambiaStatus(ByVal Texto As String, ByVal Status As Integer)
        Select Case Status
            Case -1
                LblStatus.BackColor = Color.White
                LblStatus.ForeColor = Color.Black
                LblStatus.Text = "P U N T O - D E - V E N T A"
                LblSubTitulo.BackColor = Color.White

            Case 1
                LblStatus.BackColor = Color.Green
                LblStatus.ForeColor = Color.White
                LblStatus.Text = Texto
                LblSubTitulo.BackColor = Color.Green



            Case 2
                LblStatus.BackColor = Color.Red
                LblStatus.ForeColor = Color.White
                LblStatus.Text = Texto
                LblSubTitulo.BackColor = Color.Red

            Case 3
                LblStatus.BackColor = Color.LightBlue
                LblStatus.ForeColor = Color.Black
                LblStatus.Text = Texto
                LblSubTitulo.BackColor = Color.LightBlue

            Case 4
                LblStatus.BackColor = Color.Black
                LblStatus.ForeColor = Color.White
                LblStatus.Text = Texto
                LblSubTitulo.BackColor = Color.Black

            Case 6
                LblStatus.BackColor = Color.Green
                LblStatus.ForeColor = Color.White
                LblStatus.Text = Texto
                LblSubTitulo.BackColor = Color.Green



            Case 7, 11
                LblStatus.BackColor = Color.Orange
                LblStatus.ForeColor = Color.Black
                LblStatus.Text = Texto
                LblSubTitulo.BackColor = Color.Orange
            Case 9
                LblStatus.BackColor = Color.Black
                LblStatus.ForeColor = Color.White
                LblStatus.Text = Texto
                LblSubTitulo.BackColor = Color.Black
        End Select
    End Sub


    Public Function AddCombo(ByVal sPROClave As String, ByVal sClave As String, ByVal dCantidad As Decimal, ByVal dPrecio As Decimal, ByVal sPREClave As String, ByVal bPreventa As Boolean) As Boolean
        Dim Disponible, Existencia, Apartado, Bloqueado As Decimal

        If bPreventa = True Then
            'Agrega a Combo
            Dim row1 As DataRow
            row1 = dtCombo.NewRow()
            'declara el nombre de la fila
            row1.Item("Clave") = sClave
            row1.Item("Precio") = dPrecio
            row1.Item("Cantidad") = dCantidad
            row1.Item("PREClave") = sPREClave

            dtCombo.Rows.Add(row1)
            Return True
        Else
            Dim dtDisponible As DataTable
            dtDisponible = ModPOS.SiExisteRecupera("sp_search_existencia", "@PROClave", sPROClave, "@ALMClave", AlmacenSurtido)
            If Not dtDisponible Is Nothing AndAlso dtDisponible.Rows.Count > 0 Then
                Disponible = dtDisponible.Rows(0)("Disponible")
                Existencia = dtDisponible.Rows(0)("Existencia")
                Apartado = dtDisponible.Rows(0)("Apartado")
                Bloqueado = dtDisponible.Rows(0)("Bloqueado")
                dtDisponible.Dispose()
            Else
                Disponible = 0
            End If

            If Disponible = 0 Then
                If BuscaNegados = 1 Then
                    ' Validar el tipo de sucursal, si es express solicita solo de su sucursal
                    If TipoSucursal <> 5 Then
                        Dim dtCluster As DataTable
                        dtCluster = Recupera_Tabla("st_recupera_cluster", "@SUCClave", SUCClave)
                        If dtCluster.Rows.Count > 0 Then

                            Dim k As Integer
                            For k = 0 To dtCluster.Rows.Count - 1
                                ' busca existencia en otra sucursal 
                                dtDisponible = recuperaEjecucion("stpr_ValidaExistencia", "@SUCClave", dtCluster.Rows(k)("Cluster"), "@PROClave", sPROClave)
                                If Not dtDisponible Is Nothing AndAlso dtDisponible.Rows.Count > 0 Then
                                    Disponible = dtDisponible.Rows(0)("Disponible")
                                    Existencia = dtDisponible.Rows(0)("Existencia")
                                    Apartado = dtDisponible.Rows(0)("Apartado")
                                    Bloqueado = dtDisponible.Rows(0)("Bloqueado")
                                    dtDisponible.Dispose()
                                End If

                                If Disponible > dCantidad Then
                                    Exit For
                                End If
                            Next
                        End If
                    ElseIf SucursalPadre <> "" Then
                        ' Si es una sucursal tipo Express
                        dtDisponible = recuperaEjecucion("stpr_ValidaExistencia", "@SUCClave", SucursalPadre, "@PROClave", sPROClave)
                        If Not dtDisponible Is Nothing AndAlso dtDisponible.Rows.Count > 0 Then
                            Disponible = dtDisponible.Rows(0)("Disponible")
                            Existencia = dtDisponible.Rows(0)("Existencia")
                            Apartado = dtDisponible.Rows(0)("Apartado")
                            Bloqueado = dtDisponible.Rows(0)("Bloqueado")
                            dtDisponible.Dispose()
                        End If
                    End If

                End If
            End If


            If Disponible >= dCantidad Then

                'Agrega a Combo
                Dim row1 As DataRow
                row1 = dtCombo.NewRow()
                'declara el nombre de la fila
                row1.Item("Clave") = sClave
                row1.Item("Precio") = dPrecio
                row1.Item("Cantidad") = dCantidad
                row1.Item("PREClave") = sPREClave

                dtCombo.Rows.Add(row1)
                Return True
            Else
                Return False
            End If

        End If

    End Function




    Private Function leeCodigoBarras(ByVal centroSuministro As String, ByVal Cantidad As Integer, ByVal Codigo As String, ByVal Suma As Boolean, ByVal Busca As Boolean, ByVal bRecalcular As Boolean, ByVal bValidaOpen As Boolean, ByVal bShortCut As Boolean, ByVal sDVEClave As String, ByRef ProductoClave As String, ByRef dFaltante As Decimal, ByVal TC As Boolean, Optional PREClaveKIT As String = "", Optional PrecioBrutoKIT As Decimal = 0, Optional IdKit As String = "", Optional PROClaveKIT As String = "") As Boolean
        If VentaCerrada = False Then
            Dim dt As DataTable

            If bValidaOpen = True Then
                dt = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", VENClave)
                If dt.Rows.Count > 0 Then
                    EstadoDocumento = dt.Rows(0)("Estado")
                    LblFolio.Text = dt.Rows(0)("Folio")
                    TotalVenta = dt.Rows(0)("Saldo")
                    SaldoVenta = dt.Rows(0)("Total")
                    TipoDocumento = dt.Rows(0)("Tipo")
                    If TotalArticulos = 0 AndAlso TotalVenta > 0 Then
                        TotalArticulos = 1
                    End If

                    sFolio = LblFolio.Text

                    If sFolio.Split("-").Length > 1 Then
                        Dim iArray As Integer = sFolio.Split("-").Length - 1
                        If IsNumeric(sFolio.Split("-")(iArray)) = True Then
                            lblConsecutivo.Text = CStr(sFolio.Split("-")(iArray))
                        Else
                            lblConsecutivo.Text = ""
                        End If
                    Else
                        lblConsecutivo.Text = ""
                    End If


                    VentaCerrada = True
                    modificaStatus(TipoDocumento, EstadoDocumento)
                    Dim msg As New FrmMsgTouch
                    msg.TxtTiulo = "ERROR"
                    msg.TxtMsg = "No se puede agregar producto ya que el Documento actual no se encuentra Abierto"
                    msg.btnCancel.Visible = False
                    msg.btnOK.Text = "OK"
                    msg.ShowDialog()
                    If msg.DialogResult = DialogResult.OK Then
                    End If

                    dt.Dispose()
                    Return False
                End If
                dt.Dispose()
            End If

            'Valida que el campo producto no se encuentre vacio
            If Not Codigo = vbNullString Then
                'Si el campo cantidad esta vacio lo cambia a 1 por defecto

                Dim sCliente As String

                If SincronizaCte = 1 AndAlso MaskCte = 1 Then
                    sCliente = CTEClaveActual
                Else
                    If ClienteSAP <> "" AndAlso CTEClaveActual <> ClienteSAP Then
                        sCliente = ClienteSAP
                    Else
                        sCliente = CTEClaveActual
                    End If
                End If


                'Si es el primer articulo, recupera la lista de precio del cliente actual
                If TotalArticulos = 0 Then
                    Dim dtCliente As DataTable
                    dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", sCliente, "@TipoCanal", TipoCanal)
                    ListaPrecio = dtCliente.Rows(0)("PREClave")
                    TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                    dtCliente.Dispose()
                End If
                'Busca y recupera los datos del producto

                dt = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 2, "@Busca", Codigo, "@SUCClave", SUCClave, "@PREClave", ListaPrecio, "@CTEClave", sCliente, "@Cantidad", Cantidad, "@Char", cReplace, "@TallaColor", TallaColor)


                If dt Is Nothing Then
                    Beep()

                    Dim msg As New FrmMsgTouch
                    msg.TxtTiulo = "ERROR"
                    msg.TxtMsg = "El Código no corresponde a un Producto Existente o Activo"
                    msg.btnCancel.Visible = False
                    msg.btnOK.Text = "OK"
                    msg.ShowDialog()
                    If msg.DialogResult = DialogResult.OK Then
                    End If

                    Return False
                Else
                    Dim BacktoSearh As Boolean = False

                    Dim sPROClave As String = dt.Rows(0)("PROClave")
                    Dim sClave As String = CStr(dt.Rows(0)("Clave"))
                    Dim sAlterno2 As String = CStr(dt.Rows(0)("Alterno2"))
                    Dim sNombre As String = dt.Rows(0)("Nombre")
                    Dim dCosto As Decimal = dt.Rows(0)("Costo") / TipoCambio
                    Dim dPrecioUnitario As Decimal = dt.Rows(0)("PrecioBruto") / TipoCambio
                    Dim dDescPorc As Decimal = dt.Rows(0)("DescPorc")
                    Dim dDescGeneralPor As Decimal = dt.Rows(0)("DescGeneral")

                    Dim iTProducto As Integer = dt.Rows(0)("TProducto")
                    Dim iSeguimiento As Integer = dt.Rows(0)("Seguimiento")
                    Dim iDiasGarantia As Integer = dt.Rows(0)("DiasGarantia")
                    Dim iNumDecimales As Integer = dt.Rows(0)("Num_Decimales")

                    Dim dGeneralNeto As Decimal = TruncateToDecimal(dt.Rows(0)("PrecioNeto") / TipoCambio, 6)
                    Dim dMinimoNeto As Decimal = TruncateToDecimal(dt.Rows(0)("MinimoNeto") / TipoCambio, 6)

                    Dim iKgLt As Integer = IIf(dt.Rows(0)("KgLt").GetType.FullName = "System.DBNull", 0, dt.Rows(0)("KgLt"))
                    Dim dPeso As Decimal = IIf(dt.Rows(0)("Peso").GetType.FullName = "System.DBNull", 0, dt.Rows(0)("Peso"))

                    Dim bVtaPaquete As Boolean = dt.Rows(0)("vtaPaquete")
                    Dim bPreventa As Boolean = dt.Rows(0)("Preventa")

                    Dim dBackOrder As Decimal = 0
                    Dim dCantidad As Decimal = dt.Rows(0)("Cantidad")
                    Dim dOriginal As Decimal = 0
                    Dim dPendiente As Decimal = 0
                    Dim iGrupoMaterial As Integer = 0
                    Dim iSector As Integer = 0
                    Dim iPartida As Integer
                    Dim dVolumen As Decimal = 0
                    Dim dVolumenImp As Decimal = 0

                    Dim bValidaMinimo As Boolean = IIf(dGeneralNeto = dMinimoNeto, False, True)

                    Dim PorcImpProducto As Decimal = ModPOS.RecuperaImpuesto(SUCClave, sPROClave, TImpuesto)

                    Dim sTalla As String = dt.Rows(0)("Talla")
                    Dim sTallaUSA As String = dt.Rows(0)("TallaUSA")
                    Dim sColor As String = dt.Rows(0)("Color")

                    Dim sModelo As String = dt.Rows(0)("Modelo")

                    If sTallaUSA <> "" Then
                        sTalla &= " (" & sTallaUSA & ")"
                    End If

                    If dCantidad <= 0 Then
                        Cantidad = 1

                        Dim msg As New FrmMsgTouch
                        msg.TxtTiulo = "ERROR"
                        msg.TxtMsg = "El producto " & sModelo & " " & sColor & " " & sTalla & " no permite decimales o la cantidad debe ser mayor a cero"
                        msg.btnCancel.Visible = False
                        msg.btnOK.Text = "OK"
                        msg.ShowDialog()
                        If msg.DialogResult = DialogResult.OK Then
                        End If


                        dt.Dispose()
                        Return Busca
                    End If


                    If iTProducto >= 7 Then
                        AddModelo(sModelo)
                        Return Busca
                    End If

                    If bVtaPaquete = True AndAlso IdKit = "" Then

                        Dim sPaquetes As String = ""

                        Dim dtPaq As DataTable = ModPOS.Recupera_Tabla("st_recupera_clave_kit", "@PROClave", sPROClave, "@TallaColor", TallaColor)

                        If dtPaq.Rows.Count = 1 Then
                            sPaquetes = dtPaq.Rows(0)("Paquetes")
                        End If

                        Dim msg As New FrmMsgTouch
                        msg.TxtTiulo = "INFORMACIÓN"
                        msg.TxtMsg = "El producto " & sModelo & " " & sColor & " " & sTalla & ", su venta es exclusiva en Paquete(s): " & sPaquetes
                        msg.btnCancel.Visible = False
                        msg.btnOK.Text = "OK"
                        msg.ShowDialog()
                        If msg.DialogResult = DialogResult.OK Then
                        End If

                        dt.Dispose()
                        Return Busca
                    End If


                    If CDec(dt.Rows(0)("PrecioBruto")) = 0 Then

                        Dim msg As New FrmMsgTouch
                        msg.TxtTiulo = "ERROR"
                        msg.TxtMsg = "El producto " & sModelo & " " & sColor & " " & sTalla & " no cuenta con precio definido. Contacta a un Asesor"
                        msg.btnCancel.Visible = False
                        msg.btnOK.Text = "OK"
                        msg.ShowDialog()
                        If msg.DialogResult = DialogResult.OK Then
                        End If

                        dt.Dispose()
                        Return Busca
                    End If


                    Dim UnidadesKilo As Double

                    If iKgLt = 1 Then
                        If dPeso > 0 Then
                            UnidadesKilo = dCantidad / dPeso
                        Else
                            UnidadesKilo = 1
                        End If
                    Else
                        UnidadesKilo = 0
                    End If

                    Dim foundRows() As System.Data.DataRow

                    If IdKit = "" Then
                        If sDVEClave = "" Then
                            foundRows = dtPedidoDetalle.Select(" PROClave = '" & sPROClave & "' and Baja = 0 and idKit='' and centroSuministro='" & centroSuministro & "'")
                        Else
                            foundRows = dtPedidoDetalle.Select(" DVEClave = '" & sDVEClave & "' and Baja = 0 ")
                        End If
                    End If

                    If Not foundRows Is Nothing AndAlso foundRows.Length > 1 Then

                        Dim b As New FrmConsultaT
                        b.Text = "Selecciona la Partida que desea Modificar"
                        b.Campo = "DVEClave"
                        b.GridConsultaGen.Font = New Font("Arial", 14)
                        ModPOS.ActualizaGrid(False, b.GridConsultaGen, "st_recupera_partida_prod", "@VENClave", VENClave, "@PROClave", sPROClave)
                        b.GridConsultaGen.RootTable.Columns("DVEClave").Visible = False
                        b.ShowDialog()
                        If b.DialogResult = DialogResult.OK Then
                            If b.ID <> "" Then
                                sDVEClave = b.ID
                            Else
                                Return Busca
                            End If
                        End If
                        b.Dispose()

                        foundRows = dtPedidoDetalle.Select(" DVEClave = '" & sDVEClave & "' and Baja = 0")
                    End If

                    If Not foundRows Is Nothing AndAlso foundRows.Length = 1 Then

                        dOriginal = foundRows(0)("Cantidad")
                        sDVEClave = foundRows(0)("DVEClave")
                        dPrecioUnitario = foundRows(0)("Precio")

                        If Suma = True Then
                            dCantidad += foundRows(0)("Cantidad")
                            UnidadesKilo += foundRows(0)("UndKilo")
                        ElseIf bShortCut = False Then
                            dCantidad = foundRows(0)("Cantidad")
                            UnidadesKilo = foundRows(0)("UndKilo")
                        End If

                        centroSuministro = IIf(foundRows(0)("centroSuministro").GetType.FullName = "System.DBNull", "", foundRows(0)("centroSuministro"))

                        iGrupoMaterial = foundRows(0)("GrupoMaterial")
                        iSector = foundRows(0)("Sector")

                        If foundRows(0)("Desc") > 0 Then
                            Dim dtDescuento As DataTable = ModPOS.SiExisteRecupera("sp_descuento_partida_open", "@DVEClave", sDVEClave)
                            If Not dtDescuento Is Nothing Then
                                'Descuento General
                                foundRows = dtDescuento.Select(" Tipo = 1 ")
                                If foundRows.Length = 1 Then
                                    dDescGeneralPor = foundRows(0)("DescuentoPorc") * 100
                                End If

                                'Descuento Volumen
                                foundRows = dtDescuento.Select(" Tipo = 2")
                                If foundRows.Length = 1 Then
                                    dVolumen = foundRows(0)("DescuentoPorc") * 100
                                End If

                                'Descuento Gerencial
                                foundRows = dtDescuento.Select(" Tipo = 3 ")
                                If foundRows.Length = 1 Then
                                    dDescPorc = foundRows(0)("DescuentoPorc") * 100
                                End If
                                dtDescuento.Dispose()
                            End If
                        End If

                    Else

                        Dim dtProducto As DataTable
                        'Recupera GrupoMaterial
                        dtProducto = Recupera_Tabla("st_grupo_producto", "@TGrupo", 1, "@PROClave", sPROClave) 'GrupoMaterial
                        If dtProducto.Rows.Count = 1 Then
                            iGrupoMaterial = IIf(dtProducto.Rows(0)("CLAClave").GetType.FullName = "System.DBNull", 0, dtProducto.Rows(0)("CLAClave"))
                        End If
                        dtProducto.Dispose()
                        'Recupera Sector
                        dtProducto = Recupera_Tabla("st_grupo_producto", "@TGrupo", 3, "@PROClave", sPROClave) 'Sector
                        If dtProducto.Rows.Count = 1 Then
                            iSector = IIf(dtProducto.Rows(0)("CLAClave").GetType.FullName = "System.DBNull", 0, dtProducto.Rows(0)("CLAClave"))
                        End If
                        dtProducto.Dispose()


                    End If


                    If IdKit <> "" Then
                        dPrecioUnitario = PrecioBrutoKIT
                    End If


                    Dim oVolumen As Decimal = dVolumen

                    Dim StrucVol As DescVol
                    Dim sTipoDesc As String

                    Dim dBase As Decimal

                    dBase = Math.Round(dPrecioUnitario * dCantidad, 2)

                    Dim dDescGeneralImp As Decimal = Math.Round(dBase * (dDescGeneralPor / 100), 2)

                    StrucVol = obtenerDescuentoVolumen(CTEClaveActual, iGrupoMaterial, iSector, VENClave, sPROClave, dBase - dDescGeneralImp)

                    dVolumen = StrucVol.Descuento
                    sTipoDesc = StrucVol.Tipo

                    If dVolumen > 0 Then
                        dVolumenImp = Math.Round((dBase - dDescGeneralImp) * (dVolumen / 100), 2)
                    Else
                        dVolumenImp = 0
                    End If

                    Dim dDescuentoImp As Decimal = Math.Round((dBase - dDescGeneralImp - dVolumenImp) * (dDescPorc / 100), 2)
                    Dim dImpuestoImp As Decimal = Math.Round((dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp) * PorcImpProducto, 2)

                    Dim dImporteNeto As Decimal = dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp + dImpuestoImp

                    If TC = True Then
                        Dim a As New FrmAgregaModelo
                        a.url_imagen = Me.url_imagen
                        a.VENClave = VENClave
                        a.CTEClave = CTEClaveActual
                        a.GrupoMaterial = iGrupoMaterial
                        a.Sector = iSector
                        a.PROClave = sPROClave

                        a.dBase = dBase
                        a.Clave = sClave
                        a.Modelo = sModelo
                        a.Nombre = sNombre
                        a.Talla = sTalla
                        a.Color = sColor
                        a.KgLt = iKgLt
                        a.UnidadesKilo = UnidadesKilo
                        a.Peso = dPeso

                        a.dPrecioUnitario = dPrecioUnitario
                        a.dCantidad = dCantidad
                        a.DescGeneral = dDescGeneralPor
                        a.DescGeneralImporte = dDescGeneralImp
                        a.dVolumen = dVolumen
                        a.dVolumenImp = dVolumenImp
                        a.PorcDesc = dDescPorc
                        a.DescImp = dDescuentoImp
                        a.FactorImpuesto = PorcImpProducto
                        a.dImpuestoimp = dImpuestoImp
                        a.ImporteNeto = dImporteNeto

                        a.sTipoDesc = sTipoDesc
                        a.WindowState = FormWindowState.Maximized
                        a.ShowDialog()
                        If a.DialogResult = DialogResult.OK Then
                            UnidadesKilo = a.UnidadesKilo
                            sTipoDesc = a.sTipoDesc
                            dCantidad = a.dCantidad
                            dPrecioUnitario = a.dPrecioUnitario
                            dBase = a.dBase
                            dDescGeneralImp = a.DescGeneralImporte
                            dVolumen = a.dVolumen
                            dVolumenImp = a.dVolumenImp
                            dDescPorc = a.PorcDesc
                            dDescuentoImp = a.DescImp
                            dImpuestoImp = a.dImpuestoimp
                            dImporteNeto = a.ImporteNeto

                            a.Dispose()
                        Else
                            a.Dispose()
                            Cantidad = 1
                            dPeso = 0

                            Return Busca
                        End If
                    End If

                    If dCantidad > dOriginal Then
                        dPendiente = dCantidad - dOriginal
                    Else
                        dPendiente = 0
                    End If


                    If LimitaCompraEmp > 0 AndAlso dPendiente > 0 Then
                        If TallaColor = 0 OrElse (TallaColor = 1 AndAlso sAlterno2 <> "CKLASS LIBROS" AndAlso sAlterno2 <> "CKLASS MULTIMARCAS" AndAlso iSector <> 509 AndAlso iSector <> 510 AndAlso iSector <> 511) Then

                            'valida si el cliente es empleado
                            Dim Acumulado As Decimal

                            If IdKit <> "" Then
                                Acumulado = 1
                            Else
                                Acumulado = dPendiente
                            End If


                            Dim esEmpleado As Boolean = False


                            Dim dtEmpleado As DataTable = ModPOS.Recupera_Tabla("st_valida_compra_emp", "@CTEClave", CTEClaveActual, "@IDKIT", IdKit)

                            If dtEmpleado.Rows.Count > 0 Then
                                esEmpleado = True
                                Acumulado += CDec(dtEmpleado.Rows(0)("Acumulado"))
                            End If

                            If esEmpleado = True AndAlso Acumulado > LimitaCompraEmp Then
                                Dim msg As New FrmMsgTouch
                                msg.TxtTiulo = "INFORMACIÓN"
                                msg.TxtMsg = "Lo sentimos, la cantidad solicitada excede el número de compras permitidas por mes para Empleados"
                                msg.btnCancel.Visible = False
                                msg.btnOK.Text = "OK"
                                msg.ShowDialog()
                                If msg.DialogResult = DialogResult.OK Then
                                End If
                                Return Busca
                            End If
                        End If
                    End If

                    If bRecalcular = True AndAlso dPendiente > 0 Then
                        If ValidaInventario = True AndAlso TipoDocumento <> 2 AndAlso Not (iTProducto = 3 OrElse iTProducto = 4) Then
                            If bPreventa = False Then
                                If centroSuministro = "" Then

                                    Dim Disponible, Existencia, Apartado, Bloqueado, dCantNegada As Decimal

                                    Dim dtDisponible As DataTable
                                    dtDisponible = ModPOS.SiExisteRecupera("sp_search_existencia", "@PROClave", sPROClave, "@ALMClave", AlmacenSurtido)
                                    If Not dtDisponible Is Nothing AndAlso dtDisponible.Rows.Count > 0 Then
                                        Disponible = dtDisponible.Rows(0)("Disponible")
                                        Existencia = dtDisponible.Rows(0)("Existencia")
                                        Apartado = dtDisponible.Rows(0)("Apartado")
                                        Bloqueado = dtDisponible.Rows(0)("Bloqueado")
                                        dtDisponible.Dispose()
                                    Else
                                        Disponible = 0
                                    End If

                                    If Disponible > 0 Then
                                        ' ajusta la disponibilidad por ubicacion
                                        Disponible -= validaBloqueado(AlmacenSurtido, Disponible, sPROClave, sClave)
                                    End If

                                    If Disponible >= dPendiente AndAlso Not (iTProducto = 3 OrElse iTProducto = 4) Then

                                        BacktoSearh = AgregaPartida(sDVEClave, iPartida, sPROClave, sClave, sNombre, sModelo, sColor, sTalla, sTallaUSA, iTProducto, iSeguimiento, iDiasGarantia, iKgLt, dCosto, dPrecioUnitario, dBase, dDescGeneralPor, dDescGeneralImp, dVolumen, dVolumenImp, sTipoDesc, dDescPorc, dDescuentoImp, dImpuestoImp, UnidadesKilo, PorcImpProducto, dImporteNeto, dCantidad, dOriginal, iGrupoMaterial, iSector, centroSuministro, False, PREClaveKIT, IdKit, PROClaveKIT, bRecalcular)
                                        dPendiente = 0
                                    ElseIf Not (iTProducto = 3 OrElse iTProducto = 4) AndAlso Disponible > 0 AndAlso dPendiente > Disponible Then

                                        Dim msg As New FrmMsgTouch
                                        msg.TxtTiulo = "INFORMACIÓN"
                                        msg.TxtMsg = "La cantidad solicitada excede el disponible, solo se cuenta con : " & CStr(Disponible) & " del Producto: " & sModelo & " " & sColor & " " & sTalla & ", ¿Desea agregar el disponible?"
                                        msg.btnCancel.Visible = False
                                        msg.btnOK.Text = "SÍ"
                                        msg.ShowDialog()
                                        If msg.DialogResult = DialogResult.OK Then
                                            dCantidad = dOriginal + Disponible
                                            dPendiente -= Disponible
                                            BacktoSearh = AgregaPartida(sDVEClave, iPartida, sPROClave, sClave, sNombre, sModelo, sColor, sTalla, sTallaUSA, iTProducto, iSeguimiento, iDiasGarantia, iKgLt, dCosto, dPrecioUnitario, dBase, dDescGeneralPor, dDescGeneralImp, dVolumen, dVolumenImp, sTipoDesc, dDescPorc, dDescuentoImp, dImpuestoImp, UnidadesKilo, PorcImpProducto, dImporteNeto, dCantidad, dOriginal, iGrupoMaterial, iSector, centroSuministro, False, PREClaveKIT, IdKit, PROClaveKIT, bRecalcular)

                                        End If
                                    End If


                                    If dPendiente > 0 AndAlso Not (iTProducto = 3 OrElse iTProducto = 4) Then

                                        If TallaColor = 1 Then
                                            ' Muestra otras tallas del mismo color
                                            Dim dtTallas As DataTable = ModPOS.Recupera_Tabla("st_consulta_otras_tallas", "@PROClave", sPROClave, "@ALMClave", AlmacenSurtido, "@Cantidad", dPendiente)
                                            If dtTallas.Rows.Count > 0 Then
                                                Dim dtColores As DataTable = ModPOS.Recupera_Tabla("st_obtener_color", "@PROClave", sPROClave)
                                                Dim a As New FrmAgregaMTC
                                                a.lblMsg.Visible = True
                                                a.lblMsg.Text = "NO CONTAMOS CON ESA TALLA. TE PODEMOS OFRECER LAS SIGUIENTES: "
                                                a.Cantidad = dPendiente
                                                a.BloqueaCantidad = False
                                                a.SUCClave = SUCClave
                                                a.url_imagen = Me.url_imagen
                                                a.VENClave = VENClave
                                                a.CTEClave = CTEClaveActual
                                                a.TImpuesto = TImpuesto
                                                a.PREClave = ListaPrecio
                                                a.dtColores = dtColores
                                                a.dtTallas = dtTallas
                                                a.sModelo = sModelo
                                                a.ALMClave = ALMClave
                                                a.WindowState = FormWindowState.Maximized
                                                a.ShowDialog()
                                                If a.DialogResult = Windows.Forms.DialogResult.OK Then
                                                    Dim nuevoFaltante As Decimal = 0
                                                    leeCodigoBarras(centroSuministro, a.Cantidad, a.Clave, True, Busca, True, bValidaOpen, False, "", sPROClave, nuevoFaltante, False)

                                                    dPendiente -= (a.Cantidad - nuevoFaltante)

                                                    If dPendiente < 0 Then
                                                        dPendiente = 0
                                                    End If

                                                End If
                                                dtColores.Dispose()
                                            ElseIf BuscaNegados = 0 Then
                                                Dim msg As New FrmMsgTouch
                                                msg.TxtTiulo = "INFORMACIÓN"
                                                msg.TxtMsg = "Lo sentimos en la sucural no contamos con existencia disponible del producto: " & sModelo & " " & sColor & " " & sTalla
                                                msg.btnCancel.Visible = False
                                                msg.btnOK.Text = "SÍ"
                                                msg.ShowDialog()
                                                If msg.DialogResult = DialogResult.OK Then

                                                End If
                                            End If
                                            dtTallas.Dispose()
                                        End If

                                        dCantNegada = dPendiente
                                        ' Validar el tipo de sucursal, si es express solicita solo de su sucursal

                                        If BuscaNegados = 1 Then

                                            If TipoSucursal <> 5 Then
                                                Dim dtCluster As DataTable
                                                dtCluster = Recupera_Tabla("st_recupera_cluster", "@SUCClave", SUCClave)
                                                If dtCluster.Rows.Count > 0 Then
                                                    Dim msg As New FrmMsgTouch
                                                    msg.TxtTiulo = "PREGUNTA"
                                                    msg.TxtMsg = "Lo sentimos no contamos con: " & String.Format("{0:0}", dCantNegada) & " unidades del: " & sModelo & " " & sColor & " " & sTalla & ", ¿Desea solicitarlo a otra Sucursal?"
                                                    msg.btnCancel.Text = "NO"
                                                    msg.btnOK.Text = "SÍ"
                                                    msg.ShowDialog()
                                                    If msg.DialogResult = DialogResult.OK Then
                                                        Dim dtResult As DataTable
                                                        Dim k As Integer
                                                        Dim dCantRemoto, dOriginalRemoto As Decimal

                                                        For k = 0 To dtCluster.Rows.Count - 1
                                                            ' busca existencia en otra sucursal 
                                                            dtResult = recuperaEjecucion("stpr_solicitaTraslado", "@SUCClave", dtCluster.Rows(k)("Cluster"), "@Destino", SUCClave, "@ALMDestino", AlmacenSurtido, "@VENClave", VENClave, "@PROClave", sPROClave, "@TProducto", iTProducto, "@Solicitado", dCantNegada, "@Usuario", ModPOS.UsuarioActual)
                                                            If Not dtResult Is Nothing Then
                                                                If dtResult.Rows.Count > 0 Then
                                                                    If dtResult.Rows(0)("Pendiente") < dCantNegada Then
                                                                        dCantNegada = dtResult.Rows(0)("Pendiente")
                                                                        dBackOrder += dtResult.Rows(0)("Surtido")


                                                                        If centroSuministro <> dtCluster.Rows(k)("Cluster") Then
                                                                            centroSuministro = dtCluster.Rows(k)("Cluster")
                                                                            If sDVEClave <> "" Then
                                                                                foundRows = dtPedidoDetalle.Select(" DVEClave = '" & sDVEClave & "' and Baja = 0 and centroSuministro='" & centroSuministro & "'")
                                                                                If Not foundRows Is Nothing AndAlso foundRows.Length = 1 Then

                                                                                    dOriginalRemoto = dOriginal
                                                                                Else
                                                                                    sDVEClave = ""
                                                                                    dOriginalRemoto = 0
                                                                                End If
                                                                            End If
                                                                            If sDVEClave = "" Then
                                                                                foundRows = dtPedidoDetalle.Select(" PROClave = '" & sPROClave & "' and Baja = 0 and IdKit='' and centroSuministro='" & centroSuministro & "'")
                                                                                If Not foundRows Is Nothing AndAlso foundRows.Length = 1 Then
                                                                                    sDVEClave = foundRows(0)("DVEClave")
                                                                                    dOriginalRemoto = foundRows(0)("Cantidad")
                                                                                Else
                                                                                    dOriginalRemoto = 0
                                                                                End If
                                                                            End If
                                                                            dCantRemoto = dOriginalRemoto + dtResult.Rows(0)("Surtido")
                                                                        End If

                                                                        ' Agrega producto a Detalle
                                                                        BacktoSearh = AgregaPartida(sDVEClave, iPartida, sPROClave, sClave, sNombre, sModelo, sColor, sTalla, sTallaUSA, iTProducto, iSeguimiento, iDiasGarantia, iKgLt, dCosto, dPrecioUnitario, dBase, dDescGeneralPor, dDescGeneralImp, dVolumen, dVolumenImp, sTipoDesc, dDescPorc, dDescuentoImp, dImpuestoImp, UnidadesKilo, PorcImpProducto, dImporteNeto, dCantRemoto, dOriginalRemoto, iGrupoMaterial, iSector, dtCluster.Rows(k)("Cluster"), True, PREClaveKIT, IdKit, PROClaveKIT, bRecalcular)

                                                                        dtResult.Dispose()
                                                                    End If
                                                                Else
                                                                    dtResult.Dispose()
                                                                End If
                                                            End If

                                                            If dCantNegada = 0 Then
                                                                Exit For
                                                            End If
                                                        Next


                                                        If dCantNegada > 0 Then
                                                            Dim msg1 As New FrmMsgTouch
                                                            msg1.TxtTiulo = "INFORMACIÓN"
                                                            msg1.TxtMsg = "Lo sentimos, no se encontraron : " & String.Format("{0:0}", dCantNegada) & " disponibles del Producto: " & sModelo & " " & sColor & " " & sTalla & " en las Sucursales cercanas"
                                                            msg1.btnCancel.Visible = False
                                                            msg1.btnOK.Text = "OK"
                                                            msg1.ShowDialog()
                                                            If msg1.DialogResult = DialogResult.OK Then
                                                            End If
                                                            BacktoSearh = False
                                                        End If
                                                    End If

                                                Else
                                                    Dim msg As New FrmMsgTouch
                                                    msg.TxtTiulo = "INFORMACIÓN"
                                                    msg.TxtMsg = "Lo sentimos en la sucural no contamos con existencia disponible del producto: " & sModelo & " " & sColor & " " & sTalla
                                                    msg.btnCancel.Visible = False
                                                    msg.btnOK.Text = "OK"
                                                    msg.ShowDialog()
                                                    If msg.DialogResult = DialogResult.OK Then
                                                    End If



                                                End If
                                            ElseIf SucursalPadre <> "" Then
                                                ' Si es una sucursal tipo Express
                                                Dim dtResult As DataTable
                                                Dim dCantRemoto, dOriginalRemoto As Decimal

                                                dtResult = recuperaEjecucion("stpr_solicitaTraslado", "@SUCClave", SucursalPadre, "@Destino", SUCClave, "@ALMDestino", AlmacenSurtido, "@VENClave", VENClave, "@PROClave", sPROClave, "@TProducto", iTProducto, "@Solicitado", dCantNegada, "@Usuario", ModPOS.UsuarioActual)

                                                If Not dtResult Is Nothing Then
                                                    If dtResult.Rows.Count > 0 Then
                                                        If dtResult.Rows(0)("Pendiente") < dCantNegada Then
                                                            dCantNegada = dtResult.Rows(0)("Pendiente")
                                                            dBackOrder += dtResult.Rows(0)("Surtido")

                                                            If centroSuministro <> SucursalPadre Then
                                                                centroSuministro = SucursalPadre
                                                                If sDVEClave <> "" Then
                                                                    foundRows = dtPedidoDetalle.Select(" DVEClave = '" & sDVEClave & "' and Baja = 0 and centroSuministro='" & centroSuministro & "'")
                                                                    If Not foundRows Is Nothing AndAlso foundRows.Length = 1 Then
                                                                        dOriginalRemoto = dOriginal
                                                                    Else
                                                                        sDVEClave = ""
                                                                        dOriginalRemoto = 0
                                                                    End If
                                                                End If
                                                                If sDVEClave = "" Then
                                                                    foundRows = dtPedidoDetalle.Select(" PROClave = '" & sPROClave & "' and Baja = 0 and IdKit='' and centroSuministro='" & centroSuministro & "'")
                                                                    If Not foundRows Is Nothing AndAlso foundRows.Length = 1 Then
                                                                        sDVEClave = foundRows(0)("DVEClave")
                                                                        dOriginalRemoto = foundRows(0)("Cantidad")
                                                                    Else
                                                                        dOriginalRemoto = 0
                                                                    End If
                                                                End If
                                                                dCantRemoto = dOriginalRemoto + dtResult.Rows(0)("Surtido")
                                                            End If

                                                            BacktoSearh = AgregaPartida(sDVEClave, iPartida, sPROClave, sClave, sNombre, sModelo, sColor, sTalla, sTallaUSA, iTProducto, iSeguimiento, iDiasGarantia, iKgLt, dCosto, dPrecioUnitario, dBase, dDescGeneralPor, dDescGeneralImp, dVolumen, dVolumenImp, sTipoDesc, dDescPorc, dDescuentoImp, dImpuestoImp, UnidadesKilo, PorcImpProducto, dImporteNeto, dCantRemoto, dOriginalRemoto, iGrupoMaterial, iSector, SucursalPadre, True, PREClaveKIT, IdKit, PROClaveKIT, bRecalcular)

                                                            If dtResult.Rows(0)("Pendiente") > 0 Then
                                                                Dim msg As New FrmMsgTouch
                                                                msg.TxtTiulo = "INFORMACIÓN"
                                                                msg.TxtMsg = "Lo sentimos, no se encontraron : " & dtResult.Rows(0)("Pendiente") & " disponibles del Producto: " & sModelo & " " & sColor & " " & sTalla & " en las Sucursal remota"
                                                                msg.btnCancel.Visible = False
                                                                msg.btnOK.Text = "OK"
                                                                msg.ShowDialog()
                                                                If msg.DialogResult = DialogResult.OK Then
                                                                End If


                                                                BacktoSearh = False
                                                            End If
                                                            dtResult.Dispose()

                                                        Else
                                                            dtResult.Dispose()
                                                            Dim msg As New FrmMsgTouch
                                                            msg.TxtTiulo = "INFORMACIÓN"
                                                            msg.TxtMsg = "Lo sentimos, el producto " & sModelo & " " & sColor & " " & sTalla & ", no cuenta disponibilidad en la sucursal remota"
                                                            msg.btnCancel.Visible = False
                                                            msg.btnOK.Text = "OK"
                                                            msg.ShowDialog()
                                                            If msg.DialogResult = DialogResult.OK Then
                                                            End If
                                                            BacktoSearh = False
                                                        End If

                                                    Else

                                                        dtResult.Dispose()
                                                        Dim msg As New FrmMsgTouch
                                                        msg.TxtTiulo = "INFORMACIÓN"
                                                        msg.TxtMsg = "Lo sentimos, No se pudo contactar a la sucursal remota"
                                                        msg.btnCancel.Visible = False
                                                        msg.btnOK.Text = "OK"
                                                        msg.ShowDialog()
                                                        If msg.DialogResult = DialogResult.OK Then
                                                        End If
                                                        BacktoSearh = False

                                                    End If


                                                Else
                                                    Dim msg As New FrmMsgTouch
                                                    msg.TxtTiulo = "ERROR"
                                                    msg.TxtMsg = "Lo sentimos, no fue posible comprobar la disponibilidad del producto " & sModelo & " " & sColor & " " & sTalla & " en la sucursal remota"
                                                    msg.btnCancel.Visible = False
                                                    msg.btnOK.Text = "OK"
                                                    msg.ShowDialog()
                                                    If msg.DialogResult = DialogResult.OK Then
                                                    End If

                                                    BacktoSearh = False
                                                End If

                                            End If
                                        End If


                                        If dCantNegada > 0 Then

                                            ' se crea negado del cliente, producto  y dia 
                                            Dim dImporteNegado As Decimal = Math.Round(dPrecioUnitario * dCantNegada, 2)
                                            Dim dGeneralNegado As Decimal = Math.Round(dImporteNegado * (dDescGeneralPor / 100), 2)
                                            Dim dVolumenNegado As Decimal = Math.Round((dImporteNegado - dGeneralNegado) * (dVolumen / 100), 2)
                                            Dim dDescuentoNegado As Decimal = Math.Round((dImporteNegado - dGeneralNegado - dVolumenNegado) * (dDescPorc / 100), 2)
                                            Dim dImpuestoNegado As Decimal = Math.Round((dImporteNegado - dGeneralNegado - dVolumenNegado - dDescuentoNegado) * PorcImpProducto, 2)

                                            dDescuentoNegado += dGeneralNegado + dVolumenNegado

                                            Dim bSolicitar As Boolean = False
                                            If BuscaNegados = 0 Then

                                                Dim msg As New FrmMsgNegado
                                                msg.TxtTiulo = "¿Pregunta?"
                                                msg.TxtMsg = "Se negaron " & CStr(dCantNegada) & " unidades del producto: " & sClave & ", la existencia Disponible: " & CStr(Disponible) & ", Apartados: " & CStr(Apartado) & ", Bloqueados: " & CStr(Bloqueado) & ", ¿Desea registrar Producto Negado?"
                                                If msg.ShowDialog = Windows.Forms.DialogResult.Yes Then
                                                    bSolicitar = msg.chkNegados.Checked
                                                    ModPOS.Ejecuta("sp_registra_negado", "@SUCClave", SUCClave, "@CTEClave", CTEClaveActual, "@VENClave", VENClave, "@PROClave", sPROClave, "@TProducto", iTProducto, "@Costo", dCosto, "@Precio", dPrecioUnitario, "@Importe", dImporteNegado, "@Descuento", dDescuentoNegado, "Impuesto", dImpuestoNegado, "@Cantidad", dCantNegada, "@Existencia", Existencia, "@Disponible", Disponible, "@Apartado", Apartado, "@Bloqueado", Bloqueado, "@Motivo", 3, "@Solicitar", bSolicitar, "@Usuario", AtiendeClave)
                                                End If
                                            Else

                                                ModPOS.Ejecuta("sp_registra_negado", "@SUCClave", SUCClave, "@CTEClave", CTEClaveActual, "@VENClave", VENClave, "@PROClave", sPROClave, "@TProducto", iTProducto, "@Costo", dCosto, "@Precio", dPrecioUnitario, "@Importe", dImporteNegado, "@Descuento", dDescuentoNegado, "Impuesto", dImpuestoNegado, "@Cantidad", dCantNegada, "@Existencia", Existencia, "@Disponible", Disponible, "@Apartado", Apartado, "@Bloqueado", Bloqueado, "@Motivo", 3, "@Solicitar", bSolicitar, "@Usuario", AtiendeClave)

                                            End If

                                        End If

                                        dFaltante = dCantNegada

                                    End If


                                Else
                                    'Si el centro de suministro es  diferente

                                    ' busca en SucursalPadre
                                    Dim dtResult As DataTable

                                    dtResult = recuperaEjecucion("stpr_solicitaTraslado", "@SUCClave", centroSuministro, "@Destino", SUCClave, "@ALMDestino", AlmacenSurtido, "@VENClave", VENClave, "@PROClave", sPROClave, "@TProducto", iTProducto, "@Solicitado", dPendiente, "@Usuario", ModPOS.UsuarioActual)

                                    If Not dtResult Is Nothing Then
                                        If dtResult.Rows.Count > 0 Then
                                            If dtResult.Rows(0)("Pendiente") < dPendiente Then

                                                BacktoSearh = AgregaPartida(sDVEClave, iPartida, sPROClave, sClave, sNombre, sModelo, sColor, sTalla, sTallaUSA, iTProducto, iSeguimiento, iDiasGarantia, iKgLt, dCosto, dPrecioUnitario, dBase, dDescGeneralPor, dDescGeneralImp, dVolumen, dVolumenImp, sTipoDesc, dDescPorc, dDescuentoImp, dImpuestoImp, UnidadesKilo, PorcImpProducto, dImporteNeto, dtResult.Rows(0)("Surtido") + dOriginal, dOriginal, iGrupoMaterial, iSector, SucursalPadre, True, PREClaveKIT, IdKit, PROClaveKIT, bRecalcular)

                                                If dtResult.Rows(0)("Pendiente") = 0 Then
                                                    dt.Dispose()
                                                    dtResult.Dispose()
                                                    Return BacktoSearh
                                                Else
                                                    dFaltante = dtResult.Rows(0)("Pendiente")

                                                    Dim msg As New FrmMsgTouch
                                                    msg.TxtTiulo = "INFORMACIÓN"
                                                    msg.TxtMsg = "Lo sentimos, no se encontraron : " & dtResult.Rows(0)("Pendiente") & " disponibles del Producto: " & sClave & " en las Sucursal remota"
                                                    msg.btnCancel.Visible = False
                                                    msg.btnOK.Text = "OK"
                                                    msg.ShowDialog()
                                                    If msg.DialogResult = DialogResult.OK Then
                                                    End If


                                                    dt.Dispose()
                                                    dtResult.Dispose()
                                                    Return Busca
                                                End If
                                            Else
                                                dtResult.Dispose()
                                                dFaltante = dPendiente

                                                Dim msg As New FrmMsgTouch
                                                msg.TxtTiulo = "INFORMACIÓN"
                                                msg.TxtMsg = "Lo sentimos, el producto " & sModelo & " " & sColor & " " & sTalla & ", no cuenta disponibilidad en la sucursal remota"
                                                msg.btnCancel.Visible = False
                                                msg.btnOK.Text = "OK"
                                                msg.ShowDialog()
                                                If msg.DialogResult = DialogResult.OK Then
                                                End If

                                                dt.Dispose()
                                                Return Busca
                                            End If

                                        Else
                                            dtResult.Dispose()
                                            Dim msg As New FrmMsgTouch
                                            msg.TxtTiulo = "INFORMACIÓN"
                                            msg.TxtMsg = "Lo sentimos, No se pudo contactar a la sucursal remota"
                                            msg.btnCancel.Visible = False
                                            msg.btnOK.Text = "OK"
                                            msg.ShowDialog()
                                            If msg.DialogResult = DialogResult.OK Then
                                            End If
                                            dt.Dispose()
                                            Return Busca

                                        End If


                                    Else
                                        dFaltante = dPendiente

                                        Dim msg As New FrmMsgTouch
                                        msg.TxtTiulo = "INFORMACIÓN"
                                        msg.TxtMsg = "Lo sentimos, no fue posible comprobar la disponibilidad del producto " & sModelo & " " & sColor & " " & sTalla & " en la sucursal remota"
                                        msg.btnCancel.Visible = False
                                        msg.btnOK.Text = "OK"
                                        msg.ShowDialog()
                                        If msg.DialogResult = DialogResult.OK Then
                                        End If

                                        dt.Dispose()
                                        dtResult.Dispose()
                                        Return Busca
                                    End If
                                End If
                            Else
                                ' Agrega BackOrder
                                BacktoSearh = AgregaPartida(sDVEClave, iPartida, sPROClave, sClave, sNombre, sModelo, sColor, sTalla, sTallaUSA, iTProducto, iSeguimiento, iDiasGarantia, iKgLt, dCosto, dPrecioUnitario, dBase, dDescGeneralPor, dDescGeneralImp, dVolumen, dVolumenImp, sTipoDesc, dDescPorc, dDescuentoImp, dImpuestoImp, UnidadesKilo, PorcImpProducto, dImporteNeto, dCantidad, dOriginal, iGrupoMaterial, iSector, centroSuministro, True, PREClaveKIT, IdKit, PROClaveKIT, bRecalcular)
                            End If
                        Else
                            ' No valida el Inventario
                            BacktoSearh = AgregaPartida(sDVEClave, iPartida, sPROClave, sClave, sNombre, sModelo, sColor, sTalla, sTallaUSA, iTProducto, iSeguimiento, iDiasGarantia, iKgLt, dCosto, dPrecioUnitario, dBase, dDescGeneralPor, dDescGeneralImp, dVolumen, dVolumenImp, sTipoDesc, dDescPorc, dDescuentoImp, dImpuestoImp, UnidadesKilo, PorcImpProducto, dImporteNeto, dCantidad, dOriginal, iGrupoMaterial, iSector, centroSuministro, False, PREClaveKIT, IdKit, PROClaveKIT, bRecalcular)
                        End If
                    Else
                        ' No recalcula existencia
                        BacktoSearh = AgregaPartida(sDVEClave, iPartida, sPROClave, sClave, sNombre, sModelo, sColor, sTalla, sTallaUSA, iTProducto, iSeguimiento, iDiasGarantia, iKgLt, dCosto, dPrecioUnitario, dBase, dDescGeneralPor, dDescGeneralImp, dVolumen, dVolumenImp, sTipoDesc, dDescPorc, dDescuentoImp, dImpuestoImp, UnidadesKilo, PorcImpProducto, dImporteNeto, dCantidad, dOriginal, iGrupoMaterial, iSector, centroSuministro, False, PREClaveKIT, IdKit, PROClaveKIT, bRecalcular)
                    End If

                    dt.Dispose()

                    Return BacktoSearh

                End If
            End If
        End If
    End Function

    Public Sub AddModelo(ByVal Modelo As String, Optional ByVal dCantidad As Decimal = 1, Optional ByVal TC As Boolean = True)
        If VentaCerrada = False Then

            If IsNumeric(Modelo) = True AndAlso Modelo.Length < 6 Then
                Modelo = String.Format("{0:000000}", Modelo)
            End If

            Dim sCliente As String

            If SincronizaCte = 1 AndAlso MaskCte = 1 Then
                sCliente = CTEClaveActual
            Else
                If ClienteSAP <> "" AndAlso CTEClaveActual <> ClienteSAP Then
                    sCliente = ClienteSAP
                Else
                    sCliente = CTEClaveActual
                End If
            End If

            'Si es el primer articulo, recupera la lista de precio del cliente actual
            If TotalArticulos = 0 Then
                Dim dtCliente As DataTable
                dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", sCliente, "@TipoCanal", TipoCanal)
                ListaPrecio = dtCliente.Rows(0)("PREClave")
                TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                dtCliente.Dispose()
            End If
            'Busca y recupera los datos del producto


            Dim dt As DataTable

            Dim PROClaveKIT As String = ""

            If Modelo <> "" Then
                dt = ModPOS.Recupera_Tabla("st_valida_modelo", "@COMClave", ModPOS.CompanyActual, "@Modelo", Modelo)
                If dt.Rows.Count > 0 Then
                    ' Valida si es producto es un combo o kit o duo
                    If CInt(dt.Rows(0)("TProducto")) >= 7 Then

                        PROClaveKIT = CStr(dt.Rows(0)("PROClave"))
                        Dim dtMultiproducto As DataTable = ModPOS.Recupera_Tabla("sp_muestra_multiproductos", "@ProductoPadre", dt.Rows(0)("PROClave"))
                        ' Si el produto es combo  TProducto = 7
                        If dtMultiproducto.Rows.Count > 0 Then
                            Dim q As Integer
                            For q = 0 To dCantidad - 1

                                Dim j, iTalla As Integer
                                Dim dPendienteSurtir As Integer = dtMultiproducto.Rows.Count
                                Dim ListaCombo As String
                                Dim dtListaCombo As DataTable = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)

                                ListaCombo = IIf(dtListaCombo.Rows(0)("PREClave").GetType.Name = "DBNull", "", dtListaCombo.Rows(0)("PREClave"))
                                dtListaCombo.Dispose()

                                dtCombo.Clear()
                                Dim dtProducto As DataTable
                                'Recorremos cada uno de los detalles del producto
                                For j = 0 To dtMultiproducto.Rows.Count - 1

                                    dtProducto = ModPOS.Recupera_Tabla("st_venta_modelo", "@Modelo", dtMultiproducto.Rows(j)("Modelo"), "@SUCClave", SUCClave, "@PREClave", ListaCombo, "@CTEClave", sCliente)

                                    'Si es Combo
                                    If CInt(dt.Rows(0)("TProducto")) = 7 Then

                                        If dtProducto.Rows.Count = 1 Then


                                            If AddCombo(dtProducto.Rows(0)("PROClave"), dtProducto.Rows(0)("Clave"), dtMultiproducto.Rows(j)("Cantidad"), dtProducto.Rows(0)("PrecioBruto"), ListaCombo, dtProducto.Rows(0)("Preventa")) = False Then
                                                dtCombo.Clear()
                                                Exit For
                                            End If

                                        Else

                                            Dim a As New FrmAgregaMTC
                                            a.TipoSucursal = TipoSucursal
                                            a.BloqueaCantidad = True
                                            a.bMuestraAgotados = True
                                            a.iColorFijo = dtMultiproducto.Rows(j)("iColor")
                                            a.Cantidad = dtMultiproducto.Rows(j)("Cantidad")
                                            a.SUCClave = SUCClave
                                            a.url_imagen = Me.url_imagen
                                            a.VENClave = VENClave
                                            a.CTEClave = CTEClaveActual
                                            a.TImpuesto = TImpuesto
                                            a.PREClave = ListaCombo
                                            a.sModelo = dtMultiproducto.Rows(j)("Modelo")
                                            a.ALMClave = ALMClave
                                            a.WindowState = FormWindowState.Maximized
                                            a.ShowDialog()
                                            If a.DialogResult = Windows.Forms.DialogResult.OK Then
                                                'Valida existencia 
                                                If AddCombo(a.PROClave, a.Clave, a.Cantidad, a.PrecioBruto, ListaCombo, a.Preventa) = False Then
                                                    dtCombo.Clear()
                                                    Exit For
                                                End If
                                            Else
                                                dtCombo.Clear()
                                                Exit For
                                            End If
                                        End If
                                    Else
                                        If j = 0 Then
                                            If dtProducto.Rows.Count = 1 Then

                                                If AddCombo(dtProducto.Rows(0)("PROClave"), dtProducto.Rows(0)("Clave"), dtMultiproducto.Rows(j)("Cantidad"), dtProducto.Rows(0)("PrecioBruto"), ListaCombo, dtProducto.Rows(0)("Preventa")) = False Then
                                                    dtCombo.Clear()
                                                    Exit For
                                                End If

                                            Else

                                                Dim a As New FrmAgregaMTC
                                                a.TipoSucursal = TipoSucursal
                                                a.BloqueaCantidad = True
                                                a.bMuestraAgotados = True
                                                a.iColorFijo = dtMultiproducto.Rows(j)("iColor")
                                                a.Cantidad = dtMultiproducto.Rows(j)("Cantidad")
                                                a.SUCClave = SUCClave
                                                a.url_imagen = Me.url_imagen
                                                a.VENClave = VENClave
                                                a.CTEClave = CTEClaveActual
                                                a.TImpuesto = TImpuesto
                                                a.PREClave = ListaCombo
                                                a.sModelo = dtMultiproducto.Rows(j)("Modelo")
                                                a.ALMClave = ALMClave
                                                a.WindowState = FormWindowState.Maximized
                                                a.ShowDialog()
                                                If a.DialogResult = Windows.Forms.DialogResult.OK Then
                                                    iTalla = a.Talla
                                                    'Valida existencia 
                                                    If AddCombo(a.PROClave, a.Clave, a.Cantidad, a.PrecioBruto, ListaCombo, a.Preventa) = False Then
                                                        dtCombo.Clear()
                                                        Exit For
                                                    End If
                                                Else
                                                    dtCombo.Clear()
                                                    Exit For
                                                End If

                                            End If
                                        Else
                                            'Recupera el valor de la talla del otro producto
                                            Dim dtProd As DataTable = ModPOS.Recupera_Tabla("st_recupera_modelo", "@Modelo", dtMultiproducto.Rows(j)("Modelo"), "@Talla", iTalla, "@Color", dtMultiproducto.Rows(j)("iColor"), "@SUCClave", SUCClave, "@PREClave", ListaCombo, "@CTEClave", CTEClaveActual)

                                            If dtProd.Rows.Count > 0 Then
                                                If AddCombo(dtProd.Rows(0)("PROClave"), dtProd.Rows(0)("Clave"), dtMultiproducto.Rows(j)("Cantidad"), dtProd.Rows(0)("PrecioBruto"), ListaCombo, dtProd.Rows(0)("Preventa")) = False Then
                                                    dtProd.Dispose()
                                                    dtCombo.Clear()
                                                    Exit For
                                                End If
                                            Else
                                                dtProd.Dispose()
                                                dtCombo.Clear()
                                                Exit For
                                            End If
                                            dtProd.Dispose()

                                        End If



                                    End If
                                Next

                                dtProducto.Dispose()

                                'Si se completa el combo entonces 
                                If dtCombo.Rows.Count = dPendienteSurtir Then
                                    Dim IdKit As String = ModPOS.obtenerLlave
                                    Dim frmStatusMessage As New frmStatus

                                    frmStatusMessage.Show("Estamos procesando su solicitud...")
                                    frmStatusMessage.BringToFront()

                                    For j = 0 To dtCombo.Rows.Count - 1
                                        AgregaGTIN(False, dtCombo.Rows(j)("Clave"), False, True, dtCombo.Rows(j)("Cantidad"), #1/1/1900#, #1/1/1900#, dtCombo.Rows(j)("PREClave"), dtCombo.Rows(j)("Precio"), IdKit, PROClaveKIT)
                                    Next
                                    frmStatusMessage.Dispose()

                                Else
                                    dtCombo.Clear()
                                    'Manda Mensaje de Existencia
                                    Dim msg As New FrmMsgTouch
                                    msg.TxtTiulo = "INFORMACIÓN"
                                    msg.TxtMsg = "LO SENTIMOS, NO CONTAMOS CON EXISTENCIA DISPONIBLE.."
                                    msg.btnCancel.Visible = False
                                    msg.btnOK.Text = "OK"
                                    msg.ShowDialog()
                                    If msg.DialogResult = DialogResult.OK Then
                                    End If


                                End If

                            Next

                        Else
                           
                            Dim msg As New FrmMsgTouch
                            msg.TxtTiulo = "ERROR"
                            msg.TxtMsg = "Contacta a un asesor, el Modelo tiene un error en la configuración de producto..."
                            msg.btnCancel.Visible = False
                            msg.btnOK.Text = "OK"
                            msg.ShowDialog()
                            If msg.DialogResult = DialogResult.OK Then
                            End If


                        End If
                    Else
                        'Si es un producto convencional 

                        If CDbl(dt.Rows(0)("Talla")) = 0 AndAlso CDbl(dt.Rows(0)("Color")) = 0 Then
                            AgregaGTIN(TC, CStr(dt.Rows(0)("Clave")), False, True, dCantidad)
                        Else
                            Dim a As New FrmAgregaMTC
                            a.TipoSucursal = TipoSucursal
                            a.SUCClave = SUCClave
                            a.url_imagen = Me.url_imagen
                            a.VENClave = VENClave
                            a.CTEClave = CTEClaveActual
                            a.TImpuesto = TImpuesto
                            a.PREClave = ListaPrecio
                            a.sModelo = dt.Rows(0)("Modelo")
                            a.ALMClave = ALMClave
                            a.WindowState = FormWindowState.Maximized
                            a.ShowDialog()
                            If a.DialogResult = Windows.Forms.DialogResult.OK Then
                                AgregaGTIN(False, a.Clave, False, True, a.Cantidad)
                            End If
                        End If
                    End If
                Else
                    
                    Dim msg As New FrmMsgTouch
                    msg.TxtTiulo = "ERROR"
                    msg.TxtMsg = "El Modelo no es valido o no existe"
                    msg.btnCancel.Visible = False
                    msg.btnOK.Text = "OK"
                    msg.ShowDialog()
                    If msg.DialogResult = DialogResult.OK Then
                    End If

                End If
            Else
                Dim msg As New FrmMsgTouch
                msg.TxtTiulo = "ERROR"
                msg.TxtMsg = "Debe de capturar el Modelo"
                msg.btnCancel.Visible = False
                msg.btnOK.Text = "OK"
                msg.ShowDialog()
                If msg.DialogResult = DialogResult.OK Then
                End If

            End If
        End If
    End Sub

    Public Function AgregaGTIN(ByVal TC As Boolean, ByVal sGTIN As String, ByVal Busca As Boolean, ByVal bValidaOpen As Boolean, Optional ByVal dCant As Decimal = 1, Optional ByVal dInicio_Negado As DateTime = #1/1/1900#, Optional ByVal dFin_Negado As DateTime = #1/1/1900#, Optional ByVal PREClaveKIT As String = "", Optional ByVal PrecioBrutoKIT As Decimal = 0, Optional ByVal IdKit As String = "", Optional ByVal PROClaveKIT As String = "") As Boolean
        Dim backToSearch As Boolean
        Dim dFaltante As Decimal = 0
        Dim sPROClave As String = ""

        backToSearch = leeCodigoBarras("", dCant, sGTIN, True, Busca, True, bValidaOpen, False, "", sPROClave, dFaltante, TC, PREClaveKIT, PrecioBrutoKIT, IdKit, PROClaveKIT)
        'Sugerido
        If (dCant - dFaltante) > 0 AndAlso dInicio_Negado > #1/1/1900# AndAlso dFin_Negado > #1/1/1900# Then
            'Quita Negado
            ModPOS.Ejecuta("st_quita_negado", "@ALMClave", AlmacenSurtido, "@CTEClave", CTEClaveActual, "@PROClave", sPROClave, "@Inicio", dInicio_Negado, "@Fin", dFin_Negado, "@Cantidad", (dCant - dFaltante))
        End If

        If dFaltante = 0 Then
            'sugerido(sPROClave, AlmacenSurtido, VENClave, Picking)
        Else
            'Equivalente
            'Dim dtEquivalente As DataTable = ModPOS.Recupera_Tabla("st_recupera_equivalente", "@PROClave", sPROClave, "@ALMClave", AlmacenSurtido)
            'If dtEquivalente.Rows.Count > 0 Then

            '    Dim a As New FrmConsulta
            '    a.Campo = "PROClave"
            '    a.Campo2 = "Clave"
            '    ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_recupera_equivalente", "@PROClave", sPROClave, "@ALMClave", AlmacenSurtido)
            '    a.GridConsultaGen.RootTable.Columns("PROClave").Visible = False
            '    a.ShowDialog()
            '    If a.DialogResult = DialogResult.OK Then
            '        If a.ID <> "" Then
            '            AgregaGTIN(TC, a.ID2, False, True, dFaltante)
            '        End If
            '    End If
            '    a.Dispose()

            'End If
            'dtEquivalente.Dispose()
        End If

        Return backToSearch
    End Function

    Private Function validaBloqueado(ByVal sALMClave As String, ByVal dCantidad As Double, ByVal sPROClave As String, ByVal sClave As String) As Decimal

        Dim Cantidad As Double = dCantidad

        'Busca existencia en un Stage
        Dim dtUbicacion As DataTable
        Dim x As Integer

        dtUbicacion = ModPOS.Recupera_Tabla("sp_obtener_exist_uba", "@ALMClave", sALMClave, "@PROClave", sPROClave, "@TESTClave", 2)
        If dtUbicacion.Rows.Count > 0 Then
            For x = 0 To dtUbicacion.Rows.Count - 1
                If dtUbicacion.Rows(x)("Existencia") >= Cantidad AndAlso Cantidad > 0 Then
                    Cantidad = 0
                    Exit For
                ElseIf Cantidad > 0 Then
                    Cantidad -= dtUbicacion.Rows(x)("Existencia")
                End If
            Next
        End If

        'Busca en la ubicación de Picking que se asigno al producto
        If Cantidad > 0 Then
            dtUbicacion = ModPOS.Recupera_Tabla("sp_obtener_estrategia", "@ALMClave", sALMClave, "@PROClave", sPROClave)
            If dtUbicacion.Rows.Count > 0 Then
                If dtUbicacion.Rows(0)("Existencia") >= Cantidad Then
                    Cantidad = 0
                Else
                    Cantidad -= dtUbicacion.Rows(0)("Existencia")
                End If
            End If
        End If

        'Se busca en cualquier ubicacion de almacenaje
        If Cantidad > 0 Then
            dtUbicacion = ModPOS.Recupera_Tabla("sp_obtener_exist_uba", "@ALMClave", sALMClave, "@PROClave", sPROClave, "@TESTClave", 1)
            If dtUbicacion.Rows.Count > 0 Then
                For x = 0 To dtUbicacion.Rows.Count - 1
                    If dtUbicacion.Rows(x)("Existencia") >= Cantidad AndAlso Cantidad > 0 Then
                        Cantidad = 0
                        Exit For
                    ElseIf Cantidad > 0 Then
                        Cantidad -= dtUbicacion.Rows(x)("Existencia")
                    End If
                Next
            End If
        End If



        Return Cantidad
    End Function

    Public Function AgregaPartida(ByVal sDVEClave As String, _
                                  ByVal iPartida As Integer, _
                                  ByVal sPROClave As String, _
                                  ByVal sClave As String, _
                                  ByVal sNombre As String, _
                                  ByVal sModelo As String, _
                                  ByVal sColor As String, _
                                  ByVal sTalla As String, _
                                  ByVal sTallaUSA As String, _
                                  ByVal iTProducto As Integer, _
                                  ByVal iSeguimiento As Integer, _
                                  ByVal iDiasGarantia As Integer, _
                                  ByVal iKgLt As Integer, _
                                  ByVal dCosto As Decimal, _
                                  ByVal dPrecioUnitario As Decimal, _
                                  ByVal dBase As Decimal, _
                                  ByVal dDescGeneralPor As Decimal, _
                                  ByVal dDescGeneralImp As Decimal, _
                                  ByVal dVolumen As Decimal, _
                                  ByVal dVolumenImp As Decimal, _
                                  ByVal sTipoDesc As String, _
                                  ByVal dDescPorc As Decimal, _
                                  ByVal dDescuentoImp As Decimal, _
                                  ByVal dImpuestoImp As Decimal, _
                                  ByVal UnidadesKilo As Double, _
                                  ByVal PorcImpProducto As Decimal, _
                                  ByVal dImporteNeto As Decimal, _
                                  ByVal dCantidad As Decimal, _
                                  ByVal dOriginal As Decimal, _
                                  ByVal iGrupoMaterial As Integer, _
                                  ByVal iSector As Integer, _
                                  ByVal centroSuministro As String, _
                                  ByVal bBackOrder As Boolean, _
                                  ByVal sPREClaveKIT As String, _
                                  ByVal sIdKIT As String, _
                                  ByVal sPROClaveKIT As String, _
                                  ByVal bRecalcular As Boolean) As Boolean

        UltimoCodigo = sClave

        Dim oVolumen As Decimal = dVolumen

        'Bloquea al cliente para no permitir que se modifique la lista de precios cuando ya hay productos en la venta

        If dOriginal < dCantidad Then

            dBase = Math.Round(dPrecioUnitario * dCantidad, 2)
            dDescGeneralImp = Math.Round(dBase * (dDescGeneralPor / 100), 2)

            Dim StrucVol As DescVol
            StrucVol = obtenerDescuentoVolumen(CTEClaveActual, iGrupoMaterial, iSector, VENClave, sPROClave, dBase - dDescGeneralImp)
            dVolumen = StrucVol.Descuento
            sTipoDesc = StrucVol.Tipo

            If dVolumen > 0 Then
                dVolumenImp = Math.Round((dBase - dDescGeneralImp) * (dVolumen / 100), 2)
            Else
                dVolumenImp = 0
            End If

            dDescuentoImp = Math.Round((dBase - dDescGeneralImp - dVolumenImp) * (dDescPorc / 100), 2)
            dImpuestoImp = Math.Round((dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp) * PorcImpProducto, 2)
            dImporteNeto = dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp + dImpuestoImp
        End If

        Dim Suma As Boolean

        If dCantidad > dOriginal Then
            Suma = True
        Else
            Suma = False
        End If

        'Actualiza apartado
        If bRecalcular = True Then
            If dCantidad > dOriginal Then
                If centroSuministro <> "" Then

                    ModPOS.Ejecuta("st_act_exist_vta_remoto", _
                                   "@ALMClave", ALMClave, _
                                   "@PROClave", sPROClave, _
                                   "@TipoDoc", TipoDocumento, _
                                   "@TProducto", iTProducto, _
                                   "@Cantidad", dCantidad - dOriginal, _
                                   "@VENClave", VENClave)

                ElseIf bBackOrder = False Then
                    ModPOS.Ejecuta("st_act_exist_vta", _
                                    "@ALMClave", ALMClave, _
                                    "@PROClave", sPROClave, _
                                    "@TipoDoc", TipoDocumento, _
                                    "@TProducto", iTProducto, _
                                    "@Cantidad", dCantidad - dOriginal, _
                                    "@VENClave", VENClave)

                End If
            ElseIf dCantidad < dOriginal Then
                'quita apartado
                If centroSuministro <> "" Then
                    ModPOS.Ejecuta("stpr_remueveTraslado", "@SUCClave", centroSuministro, "@Destino", SUCClave, "@VENClave", VENClave, "@PROClave", sPROClave, "@Cantidad", dOriginal - dCantidad)
                ElseIf bBackOrder = False Then
                    ModPOS.Ejecuta("sp_actualiza_partida", _
                                                    "@ALMClave", ALMClave, _
                                                    "@VENClave", VENClave, _
                                                    "@DVEClave", sDVEClave, _
                                                    "@Producto", sPROClave, _
                                                    "@Cantidad", dOriginal - dCantidad, _
                                                    "@TipoDoc", TipoDocumento, _
                                                    "@TProducto", iTProducto, _
                                                    "@Picking", Picking)
                End If

            End If
        End If

        Dim dBackOrder As Decimal = 0
        If bBackOrder = True Then
            dBackOrder = dCantidad
        End If

        If sDVEClave <> "" Then

            'Actualiza Cantidad de producto
            'IIf(dOriginal >= dCantidad, dCantidad, dCantidad - dOriginal), _
            ModPOS.Ejecuta("sp_actualiza_detalle", _
            "@ALMClave", AlmacenSurtido, _
            "@VENTA", VENClave, _
            "@PROClave", sPROClave, _
            "@PrecioBruto", dPrecioUnitario, _
            "@Cantidad", dCantidad, _
            "@Importe", dBase, _
            "@DescGenPor", dDescGeneralPor / 100, _
            "@DescGenImp", dDescGeneralImp, _
            "@DescVolPor", dVolumen / 100, _
            "@DescVolImp", dVolumenImp, _
            "@DescuentoPor", dDescPorc / 100, _
            "@DescuentoImp", dDescuentoImp, _
            "@ImpuestoImp", dImpuestoImp, _
            "@TProducto", iTProducto, _
            "@TipoDoc", TipoDocumento, _
            "@Picking", Picking, _
            "@UndKilo", UnidadesKilo, _
            "@DVEClave", sDVEClave, _
            "@PorcImp", PorcImpProducto, _
            "@Usuario", ModPOS.UsuarioActual, _
            "@TipoDesc", sTipoDesc, _
            "@Autoriza", "", _
            "@Total", dImporteNeto, _
            "@centroSuministro", centroSuministro, _
            "@BackOrder", dBackOrder, _
            "@PREClaveKIT", sPREClaveKIT, _
            "@IdKIT", sIdKIT, _
            "@PROClaveKIT", sPROClaveKIT)


            Dim dtDet As DataTable
            dtDet = ModPOS.SiExisteRecupera("sp_vent_det_open", "@DVEClave", sDVEClave)
            If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
                ModPOS.RecalculaImpuesto(dtDet, TImpuesto, SUCClave, 0)
                dtDet.Dispose()
            End If

        Else
            'Inserta Producto
            sDVEClave = ModPOS.obtenerLlave

            If dtPedidoDetalle.Compute("MAX(Partida)", "BAJA=0").GetType.FullName = "System.DBNull" Then
                iPartida = 10
            Else
                iPartida = CInt(dtPedidoDetalle.Compute("MAX(Partida)", "BAJA=0")) + 10
            End If

            ModPOS.Ejecuta("sp_inserta_detalle", _
            "@DVEClave", sDVEClave, _
            "@VENTA", VENClave, _
            "@PROClave", sPROClave, _
            "@Costo", dCosto, _
            "@PREClave", ListaPrecio, _
            "@PrecioBruto", dPrecioUnitario, _
            "@Cantidad", dCantidad, _
            "@Importe", dBase, _
            "@DescGenPor", dDescGeneralPor / 100, _
            "@DescGenImp", dDescGeneralImp, _
            "@DescVolPor", dVolumen / 100, _
            "@DescVolImp", dVolumenImp, _
            "@DescuentoPor", dDescPorc / 100, _
            "@DescuentoImp", dDescuentoImp, _
            "@PorcImp", PorcImpProducto, _
            "@ImpuestoImp", dImpuestoImp, _
            "@Total", dImporteNeto, _
            "@ALMClave", ALMClave, _
            "@TipoDoc", TipoDocumento, _
            "@TProducto", iTProducto, _
            "@Picking", Picking, _
            "@Autoriza", "", _
            "@UndKilo", UnidadesKilo, _
            "@GrupoMaterial", iGrupoMaterial, _
            "@Sector", iSector, _
            "@Partida", iPartida, _
            "@TipoDesc", sTipoDesc, _
            "@centroSuministro", centroSuministro, _
            "@BackOrder", dBackOrder, _
            "@PREClaveKIT", sPREClaveKIT, _
            "@IdKIT", sIdKIT, _
            "@PROClaveKIT", sPROClaveKIT, _
            "@Usuario", ModPOS.UsuarioActual)

            'Inserta detalle de Impuestos por partida
            ModPOS.InsertaImpuesto(sDVEClave, sPROClave, (dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp), TImpuesto, SUCClave)

            TotalArticulos += 1

            If TotalArticulos = 1 Then
                ModPOS.Ejecuta("st_actualiza_canal_vta", "@VENClave", VENClave, "@TipoCanal", TipoCanal)
            End If

        End If




        ' AGREGAR PRODUCTO A LISTA


        Dim Recalcular As Boolean = True
        'recalcula productos que tengan descuento de volumen
        If oVolumen <> dVolumen Then
            Dim dtVolumen As DataTable
            dtVolumen = Recupera_Tabla("st_recupera_partida", "@VENClave", VENClave, "@Tipo", sTipoDesc, "@Grupo", iGrupoMaterial, "@Sector", iSector, "@PROClave", sPROClave)
            If dtVolumen.Rows.Count > 0 Then
                Dim y As Integer
                Dim dtDet As DataTable
                For y = 0 To dtVolumen.Rows.Count - 1
                    ModPOS.Ejecuta("st_recalcular_detalle", "@DVEClave", dtVolumen.Rows(y)("DVEClave"), "@DesVol", dVolumen / 100, "@TipoDesc", sTipoDesc, "@Autoriza ", ModPOS.UsuarioActual)

                    dtDet = ModPOS.SiExisteRecupera("sp_vent_det_open", "@DVEClave", dtVolumen.Rows(y)("DVEClave"))
                    If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
                        ModPOS.RecalculaImpuesto(dtDet, TImpuesto, SUCClave, 0)
                        dtDet.Dispose()
                    End If

                Next



                Recalcular = False
            End If
        End If


        If bRecalcular = True AndAlso AplicaPromocionFinal = 0 AndAlso TipoDocumento <> 2 Then
            ModPOS.Ejecuta("st_aplicar_promociones", _
                           "@CTEClave", CTEClaveActual, _
                           "@SUCClave", SUCClave, _
                           "@TImpuesto", TImpuesto, _
                           "@VENClave", VENClave, _
                           "@Usuario", ModPOS.UsuarioActual)
        End If


        ActualizaDetalle(VENClave, True)

        Cantidad = 1
        Return False
    End Function

    Public Sub ActualizaDetalle(ByVal VENClave As String, ByVal Recalcular As Boolean)

        If Not dtPedidoDetalle Is Nothing Then
            dtPedidoDetalle.Dispose()
        End If

        dtPedidoDetalle = ModPOS.Recupera_Tabla("sp_detalle_open", "@VENClave", VENClave)
        GridDetalle.DataSource = dtPedidoDetalle

        GridDetalle.RootTable.Columns("Cantidad").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Precio").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Importe").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("% Desc").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Desc").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Impts").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far



        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Desc"), Janus.Windows.GridEX.ConditionOperator.GreaterThan, 0)
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridDetalle.RootTable.FormatConditions.Add(fc)


        Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
        fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc1.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc1.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridDetalle.RootTable.FormatConditions.Add(fc1)

        If dtPedidoDetalle.Rows.Count > 0 Then
            TotalArticulos = dtPedidoDetalle.Compute("Sum(Cantidad)", "")
            TotalVenta = dtPedidoDetalle.Compute("Sum(Total)", "")
            TotalAhorro = dtPedidoDetalle.Compute("Sum(Desc)", "")
            TotalPuntos = dtPedidoDetalle.Compute("Sum(Puntos)", "")
        Else
            TotalArticulos = 0
            TotalPuntos = 0
            TotalAhorro = 0
            TotalVenta = 0
        End If

        LblCantidadPuntos.Text = ModPOS.TruncateToDecimal(TotalPuntos, 2).ToString("#,##0.00")
        LblCantidadArticulos.Text = CStr(TotalArticulos)
        LblAhorro.Text = Format(CStr(ModPOS.TruncateToDecimal(TotalAhorro, 2)), "Currency")
        LblTotal.Text = Format(CStr(ModPOS.TruncateToDecimal(TotalVenta, 2)), "Currency")


        If SaldoVenta = -1 OrElse Recalcular = True Then
            SaldoVenta = TotalVenta
        End If

        If Moneda <> MonedaCambio Then
            If MonTipoCambio > 0 Then
                LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
            Else
                LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
            End If
        Else
            LblTipoCambio.Text = ""
        End If



    End Sub




    'Public Sub AgregarProducto(ByVal DVEClave As String, ByVal PROClave As String, ByVal GTIN As String, ByVal Nombre As String, ByVal Modelo As String, ByVal Color As String, ByVal Talla As String, ByVal TallaUSA As String, ByVal Cantidad As Decimal, ByVal Precio As Decimal, ByVal ImpuestoPor As Decimal, ByVal Descuento As Decimal, ByVal kglt As Integer, ByVal UnidadesKilo As Double, ByVal GrupoMaterial As Integer, ByVal Sector As Integer, ByVal Partida As Integer, ByVal centroSuministro As String, ByVal dBackOrder As Decimal, ByVal IdKIT As String)
    '    Dim dBase, dImpts, dTotal, DescPor As Decimal

    '    dBase = Math.Round(Precio * Cantidad, 2)
    '    dImpts = Math.Round((dBase - Descuento) * ImpuestoPor, 2)
    '    dTotal = dBase - Descuento + dImpts

    '    DescPor = (Descuento / dBase) * 100

    '    Dim foundRows() As System.Data.DataRow
    '    foundRows = dtPedidoDetalle.Select(" DVEClave = '" & DVEClave & "'")

    '    If foundRows.Length = 1 Then

    '        If kglt = 1 Then
    '            Nombre &= " " & CStr(UnidadesKilo) & "Unds"
    '        End If

    '        foundRows(0)("Nombre") = Nombre
    '        foundRows(0)("Cantidad") = Cantidad
    '        foundRows(0)("UndKilo") = UnidadesKilo
    '        foundRows(0)("Precio") = TruncateToDecimal(Precio, 2)
    '        foundRows(0)("Importe") = dBase
    '        foundRows(0)("% Desc") = TruncateToDecimal(DescPor, 2)
    '        foundRows(0)("Desc") = Descuento
    '        foundRows(0)("Impts") = dImpts
    '        foundRows(0)("Total") = dTotal
    '        foundRows(0)("BackOrder") = dBackOrder
    '        foundRows(0)("IdKIT") = IdKIT
    '    Else

    '        Dim row1 As DataRow
    '        row1 = dtPedidoDetalle.NewRow()
    '        'declara el nombre de la fila
    '        row1.Item("DVEClave") = DVEClave
    '        row1.Item("PROClave") = PROClave
    '        row1.Item("Clave") = GTIN

    '        If kglt = 1 Then
    '            Nombre &= " " & CStr(UnidadesKilo) & "Unds"
    '        End If

    '        row1.Item("Nombre") = Nombre

    '        row1.Item("Modelo") = Modelo
    '        row1.Item("Color") = Color
    '        row1.Item("Talla") = Talla
    '        row1.Item("TallaUSA") = TallaUSA

    '        row1.Item("Cantidad") = Cantidad
    '        row1.Item("Precio") = TruncateToDecimal(Precio, 2)
    '        row1.Item("Importe") = dBase
    '        row1.Item("Desc") = Descuento
    '        row1.Item("% Desc") = TruncateToDecimal(DescPor, 2)
    '        row1.Item("Impts") = dImpts
    '        row1.Item("Total") = dTotal
    '        row1.Item("GrupoMaterial") = GrupoMaterial
    '        row1.Item("Sector") = Sector
    '        row1.Item("Partida") = Partida
    '        row1.Item("Baja") = 0
    '        row1.Item("UndKilo") = UnidadesKilo
    '        row1.Item("centroSuministro") = centroSuministro
    '        row1.Item("BackOrder") = dBackOrder
    '        row1.Item("IdKIT") = IdKIT
    '        dtPedidoDetalle.Rows.Add(row1)
    '    End If




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

    Public Sub modificaStatus(ByVal iTipoDocumento As Integer, ByVal Status As Integer)

        Dim sTexto As String = ""

        Select Case Status
            Case 1
                sTexto = "ABIERTA"
            Case 2
                sTexto = "CERRADA"
            Case 3
                sTexto = "PAGADA"
            Case 4
                sTexto = "CANCELADA"
            Case 6
                sTexto = "ABIERTA"
            Case 7
                sTexto = "PICKING"
            Case 9
                sTexto = "REMOTO"
            Case 11
                sTexto = "BACKORDER"
        End Select

        Select Case iTipoDocumento
            Case 1
                cambiaStatus("VTA. CONTADO (" & sTexto & ")", Status)
            Case 2
                cambiaStatus("COTIZACIÓN (" & sTexto & ")", Status)
            Case 3
                cambiaStatus("VTA. CRÉDITO (" & sTexto & ")", Status)
            Case 4
                cambiaStatus("APARTADO (" & sTexto & ")", Status)
        End Select

    End Sub

    Private Function ValidaComplemento(ByVal VENClave As String) As Boolean
        Dim dt As DataTable
        Dim bError As Boolean = False

        dt = ModPOS.Recupera_Tabla("st_recupera_extra", "@VENClave", VENClave)

        If dt.Rows.Count = 0 Then
            dt.Dispose()
            bError = True
        Else
            Dim fila As Integer

            Dim foundRows() As DataRow
            foundRows = dt.Select("Descripcion = '' and Requerido = True")
            If foundRows.GetLength(0) > 0 Then
                dt.Dispose()
                bError = True
            Else
                Cursor.Current = Cursors.WaitCursor
                For fila = 0 To dt.Rows.Count - 1
                    Select Case CInt(dt.Rows(fila)("Tipo"))
                        Case Is = 2
                            If Not IsNumeric(dt.Rows(fila)("Descripcion")) Then
                                bError = True
                                Exit For
                            End If
                        Case Is = 3
                            If Not IsDate(dt.Rows(fila)("Descripcion")) Then
                                bError = True
                                Exit For
                            End If
                    End Select
                Next
                dt.Dispose()
                Cursor.Current = Cursors.Default
            End If
        End If

        If bError = True Then
            MessageBox.Show("!Existe información complementaria pendiente de llenar¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        Else
            Return True
        End If

    End Function


    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If TotalArticulos > 0 Then
            'Si la venta no ha sido cerrada
            If VentaCerrada = False Then


                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", VENClave)
                If dt.Rows.Count > 0 Then
                    EstadoDocumento = dt.Rows(0)("Estado")
                    LblFolio.Text = dt.Rows(0)("Folio")
                    TipoDocumento = dt.Rows(0)("Tipo")
                    VentaCerrada = True

                    sFolio = LblFolio.Text

                    If sFolio.Split("-").Length > 1 Then
                        Dim iArray As Integer = sFolio.Split("-").Length - 1
                        If IsNumeric(sFolio.Split("-")(iArray)) = True Then
                            lblConsecutivo.Text = CStr(sFolio.Split("-")(iArray))
                        Else
                            lblConsecutivo.Text = ""
                        End If
                    Else
                        lblConsecutivo.Text = ""
                    End If

                    modificaStatus(TipoDocumento, EstadoDocumento)

                    Dim msg As New FrmMsgTouch
                    msg.TxtTiulo = "ERROR"
                    msg.TxtMsg = "No es posible Cerrar el documento debido a que ya fue procesado anteriormente"
                    msg.btnCancel.Visible = False
                    msg.btnOK.Text = "OK"
                    msg.ShowDialog()
                    If msg.DialogResult = DialogResult.OK Then
                    End If

                    Exit Sub
                End If


                'valida preventa para ser agregado 

                Dim dtPreventa As DataTable = ModPOS.Recupera_Tabla("st_recupera_preventa_faltante", "@VENClave", VENClave, "@SUCClave", SUCClave, "@CTEClave", CTEClaveActual, "@PREClave", ListaPrecio)

                If dtPreventa.Rows.Count > 0 Then
                    Dim a As New FrmAgregaPreventa
                    a.Padre = "Touch"
                    a.url_imagen = Me.url_imagen
                    a.VENClave = VENClave
                    a.TipoCambio = TipoCambio
                    a.CTEClave = CTEClaveActual
                    a.SUCClave = SUCClave
                    a.TImpuesto = TImpuesto
                    a.dtPreventa = dtPreventa
                    a.WindowState = FormWindowState.Maximized
                    If a.ShowDialog() = Windows.Forms.DialogResult.Abort Then
                        Exit Sub
                    End If
                End If


                If TipoDocumento = 1 OrElse TipoDocumento = 3 Then
                    If UBCClave = "" Then
                        MessageBox.Show("El punto de venta no tiene un Stage de Surtido asociado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                End If

                Dim dtAuditoria As DataTable
                dtAuditoria = ModPOS.Recupera_Tabla("st_auditoria_venta", "@VENClave", VENClave)
                If dtAuditoria.Rows.Count > 0 Then
                 
                    Dim msg As New FrmMsgTouch
                    msg.TxtTiulo = "ERROR"
                    msg.TxtMsg = "El producto " & dtAuditoria.Rows(0)("Clave") & " cuenta con una inconsistencia de precio, eliminelo del pedido e intente nuevamente"
                    msg.btnCancel.Visible = False
                    msg.btnOK.Text = "OK"
                    msg.ShowDialog()
                    If msg.DialogResult = DialogResult.OK Then
                    End If

                    Exit Sub
                End If


                If AplicaPromocionFinal = 1 AndAlso TipoDocumento <> 2 Then
                    ModPOS.Ejecuta("st_aplicar_promociones", _
                                   "@CTEClave", CTEClaveActual, _
                                   "@SUCClave", SUCClave, _
                                   "@TImpuesto", TImpuesto, _
                                   "@VENClave", VENClave, _
                                   "@Usuario", ModPOS.UsuarioActual)

                    'actualiza detalle de la venta
                    ActualizaDetalle(VENClave, True)
                End If

                If ValidaInventario = True AndAlso TipoDocumento <> 2 Then
                    If VerificaExistencia(1, VENClave, AlmacenSurtido, True) = False Then
                        Exit Sub
                    End If
                End If

                'Validar Limite de Credito
                If TipoDocumento = 3 Then
                    Dim iValidaCredito As Integer

                    iValidaCredito = ModPOS.ValidaCredido(CtaMaestra, LimiteCredito, DiasCredito, TotalVenta, TipoCambio)

                    If iValidaCredito = 0 Then
                        Exit Sub
                    ElseIf iValidaCredito = -1 Then
                        CreditoDisponible = ModPOS.recuperaDatosCredito(CtaMaestra)
                        If CreditoDisponible < (TotalVenta * TipoCambio) Then
                          
                            Dim msg As New FrmMsgTouch
                            msg.TxtTiulo = "ERROR"
                            msg.TxtMsg = "El limite de crédito disponible es de " & Format(CStr(ModPOS.Redondear(CreditoDisponible, 2)), "Currency") & ", la venta actual lo sobrepasa por " & Format(CStr(ModPOS.Redondear((TotalVenta * TipoCambio) - CreditoDisponible, 2)), "Currency")
                            msg.btnCancel.Visible = False
                            msg.btnOK.Text = "OK"
                            msg.ShowDialog()
                            If msg.DialogResult = DialogResult.OK Then
                            End If

                            Exit Sub
                        End If
                    End If
                End If

                Dim foundRows() As System.Data.DataRow
                foundRows = dtPedidoDetalle.Select(" Baja = 1")

                If foundRows.Length <> 0 Then
                    foundRows = dtPedidoDetalle.Select(" Baja = 0")
                    Dim i As Integer
                    For i = 0 To foundRows.Length - 1
                        ModPOS.Ejecuta("st_act_partida_venta", "@DVEClave", foundRows(i)("DVEClave"), "@Partida", (i + 1) * 10)
                    Next

                End If






                BtnCerrar.Enabled = False

                If Remoto = 1 Then
                    If TipoDocumento = 1 OrElse TipoDocumento = 3 Then
                        EstadoDocumento = iEstado.Remoto
                    Else
                        EstadoDocumento = iEstado.Cerrado
                    End If
                Else
                    If Picking = False Then
                        EstadoDocumento = iEstado.Cerrado
                    Else
                        If TipoDocumento = 1 OrElse TipoDocumento = 3 Then
                            If ALMClave = AlmacenSurtido Then
                                EstadoDocumento = iEstado.Picking
                            Else
                                EstadoDocumento = iEstado.Remoto
                            End If
                        Else
                            EstadoDocumento = iEstado.Cerrado
                        End If
                    End If
                End If

                ModPOS.Ejecuta("sp_inserta_envio", _
               "@ENVClave", ModPOS.obtenerLlave, _
               "@VENClave", VENClave, _
               "@tipoEntrega", 1, _
               "@DCTEClave", DCTEClave, _
               "@formaEnvio", 0, _
               "@Observaciones", "", _
               "@fechaPrevista", Today.Date, _
               "@ZonaReparto", -1, _
               "@Referencia", "", _
               "@VentaCerrada", False, _
               "@UBCClave", UBCClave, _
                "@Packing", Packing, _
               "@Usuario", ModPOS.UsuarioActual)


                'Valida si el pedido actual tiene posiciones en BackOrder a otras Sucursales

                foundRows = dtPedidoDetalle.Select("centroSuministro <> '' and Baja = 0")
                Dim nVENClave As String = ""
                Dim nEstadoDocumento As Integer = 0
                Dim nTotalVenta As Decimal = 0

                If foundRows.Length > 0 Then
                    foundRows = dtPedidoDetalle.Select("centroSuministro = '' and Baja = 0")
                    If foundRows.Length > 0 Then
                        Dim msgg As New FrmMsgGral
                        msgg.ShowDialog()
                        If msgg.DialogResult = DialogResult.OK Then
                            If msgg.Dividir = True Then
                                ' Dividir Pedido
                                Dim dtResult As DataTable
                                dtResult = recuperaEjecucion("stpr_split_pedido", "@PDVClave", PDVClave, "@Picking", Picking, "@VENClave", VENClave, "@ALMClave", AlmacenSurtido, "@TipoCambio", TipoCambio)
                                If Not dtResult Is Nothing Then
                                    nVENClave = dtResult.Rows(0)("VENClave")
                                    nTotalVenta = dtResult.Rows(0)("Total")
                                    nEstadoDocumento = EstadoDocumento
                                    EstadoDocumento = iEstado.BackOrder
                                End If
                            Else
                                ' El Pedido se cambia a Estado BackOrder
                                EstadoDocumento = iEstado.BackOrder
                            End If
                        End If
                    Else
                        ' El Pedido se cambia a Estado BackOrder
                        EstadoDocumento = iEstado.BackOrder
                    End If
                End If


                ObtenerFolio(False)

                ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", EstadoDocumento, "@ALMClave", AlmacenSurtido, "@Folio", LblFolio.Text, "@MONClave", Moneda, "@TipoCambio", TipoCambio, "@TipoImpuesto", TImpuesto)

                ModPOS.Ejecuta("sp_agrega_venta", "@VENClave", VENClave)

                If nVENClave <> "" Then
                    EstadoDocumento = nEstadoDocumento
                    VENClave = nVENClave
                    TotalVenta = nTotalVenta
                    SaldoVenta = TotalVenta
                End If

                modificaStatus(TipoDocumento, EstadoDocumento)

                If (TipoDocumento <> 2) AndAlso Picking = False Then '= 3 OrElse TipoDocumento = 4)
                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", CTEClaveActual, "@Importe", TotalVenta)
                End If

                If Remoto = 0 Then
                    If Picking = False Then
                        If (TipoDocumento = 1 OrElse TipoDocumento = 3) AndAlso GeneraMovSalida Then
                            ModPOS.GeneraMovInv(2, 1, 1, VENClave, AlmacenSurtido, LblFolio.Text, Nothing, Picking)
                            GeneraMovSalida = False
                        End If
                    ElseIf TipoDocumento = 1 OrElse TipoDocumento = 3 Then

                        If EstadoDocumento = iEstado.Picking Then


                            ModPOS.calculaRecoleccion(1, VENClave, AlmacenSurtido, "", 0)
                        End If
                    End If
                Else
                    If TipoDocumento = 1 OrElse TipoDocumento = 3 Then
                        If InterfazSalida <> "" Then
                            Dim sFecha As String
                            Dim dtInterfaz As DataTable
                            sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                            dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Pedido", "@COMClave", ModPOS.CompanyActual)
                            If dtInterfaz.Rows.Count > 0 Then
                                ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", VENClave, "@TipoDocumento", 0, "@Path", InterfazSalida, "@Fecha", sFecha)
                            End If

                        End If
                    End If
                End If

            End If ' Si VentaCerrada=False

            If VentaCerrada = True Then

                If EstadoDocumento = 1 Then

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtPedidoDetalle.Select("centroSuministro <> '' and BackOrder > 0 Baja = 0")

                    If foundRows.Length > 0 Then
                        EstadoDocumento = iEstado.BackOrder
                    End If

                    If EstadoDocumento <> iEstado.BackOrder Then
                        If Remoto = 1 Then
                            EstadoDocumento = iEstado.Remoto
                        Else

                            If Picking = False Then
                                EstadoDocumento = iEstado.Cerrado
                            Else
                                If TipoDocumento = 1 OrElse TipoDocumento = 3 Then
                                    If ALMClave = AlmacenSurtido Then
                                        EstadoDocumento = iEstado.Picking
                                    Else
                                        EstadoDocumento = iEstado.Remoto
                                    End If
                                Else
                                    EstadoDocumento = iEstado.Cerrado
                                End If
                            End If
                        End If
                    End If
                End If

                ModPOS.Ejecuta("sp_actualiza_venta_cerrada", "@VENClave", VENClave, "@Estado", EstadoDocumento, "@ActSaldo", 0)

                modificaStatus(TipoDocumento, EstadoDocumento)

            End If

            Dim frmStatusMessage As New frmStatus

            If Remoto = 0 AndAlso EstadoDocumento <> iEstado.BackOrder Then
                If Picking = False OrElse TipoDocumento = 2 OrElse TipoDocumento = 4 Then


                    frmStatusMessage.Show("Imprimiendo...")

                    ImprimirPedido(VENClave, EstadoDocumento, TotalVenta)


                    'Ciclo para impresion de copias
                    If NumCopias > 0 Then
                        Dim i As Integer
                        For i = 1 To NumCopias

                            ImprimirPedido(VENClave, EstadoDocumento, TotalVenta)

                        Next
                    End If

                    frmStatusMessage.Dispose()



                Else
                    If TipoDocumento = 1 OrElse TipoDocumento = 3 Then
                        'Imprime hoja de picking
                        If EstadoDocumento = iEstado.Picking Then
                            Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_venta", "@VENClave", VENClave)
                            Dim Prioridad As Integer = 1
                            If dt.Rows.Count > 0 Then
                                Prioridad = dt.Rows(0)("Prioridad")
                            End If
                            dt.Dispose()

                            If Prioridad = 1 AndAlso MostradorRF = True Then
                                ModPOS.Ejecuta("st_act_tipo_surtido", "@Tipo", 1, "@DOCClave", VENClave, "@SurtidoRF", 1)
                            ElseIf Prioridad > 1 AndAlso SurtidoRF = True Then
                                ModPOS.Ejecuta("st_act_tipo_surtido", "@Tipo", 1, "@DOCClave", VENClave, "@SurtidoRF", 1)
                            Else
                                ModPOS.Ejecuta("st_act_tipo_surtido", "@Tipo", 1, "@DOCClave", VENClave, "@SurtidoRF", 0)
                            End If

                            If (Prioridad = 1 AndAlso MostradorRF = False) OrElse (Prioridad <> 1 AndAlso SurtidoRF = False) Then



                                If ImprimirRemoto = 0 Then
                                    ModPOS.ImprimirSurtido(1, VENClave, False, True, SUCClave, TIKClave, ticketPicking, TallaColor)
                                Else
                                    ModPOS.Ejecuta("st_inserta_printspooler", "@TipoDocumento", 1, "@DOCClave", VENClave, "@Reimpresion", False, "@Usuario", ModPOS.UsuarioActual)
                                End If

                            End If
                        End If
                    End If
                End If
            End If

            VentaCerrada = True


            btnQuitarProducto.Enabled = False
            btnBorrarTodo.Enabled = False
            BtnCerrar.Enabled = False
            GeneraMovSalida = False
            dtPedidoDetalle.Clear()
            TotalArticulos = 0
            TotalPuntos = 0
            TotalVenta = 0
            TotalRecibido = 0
            TotalCambio = 0
            TotalAhorro = 0
            LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
            LblCantidadArticulos.Text = CStr(TotalArticulos)
            LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
            LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

            If Moneda <> MonedaCambio Then
                If MonTipoCambio > 0 Then
                    LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                End If
            Else
                LblTipoCambio.Text = ""
            End If

            LblFolio.Text = Referencia & Microsoft.VisualBasic.Right(CStr(Periodo), 2) & Microsoft.VisualBasic.Right("0" & CStr(Mes), 2) & "-0"
            lblConsecutivo.Text = ""
            cambiaStatus("", iEstado.Original)


            Dim bSalir As Boolean = True

            Dim dtVenta = ModPOS.Recupera_Tabla("sp_recupera_ventawait", "@PDVClave", PDVClave, "@CTEClave", CTEClaveActual)
            If dtVenta.Rows.Count > 0 Then

                Dim msg As New FrmMsgTouch
                msg.TxtTiulo = "PREGUNTA"
                msg.TxtMsg = "Tiene pedidos en Espera. ¿Desea Salir y Cerrar Sesión?"
                msg.btnCancel.Text = "No"
                msg.btnOK.Text = "Sí"
                msg.ShowDialog()
                If msg.DialogResult = DialogResult.Cancel Then
                    AccesoAutorizado = cambiaCliente(CTEClaveActual, True)
                    bSalir = False
                End If
            End If

            If bSalir = True Then
                LblCliente.Text = ""
                AccesoAutorizado = False

                While AccesoAutorizado = False
                    Dim b As New FrmObtieneAfiliado
                    b.Imagen = Logo2
                    b.SUCClave = SUCClave
                    b.MaskCte = MaskCte
                    b.WindowState = FormWindowState.Maximized
                    b.BringToFront()
                    b.ShowDialog()

                    If b.DialogResult = DialogResult.OK Then
                        If b.CTEClave = "111111111" Then
                            CerrarSesion = True
                            Me.Close()
                            Exit Sub
                        End If
                        AccesoAutorizado = cambiaCliente(b.CTEClave)

                    Else
                        MessageBox.Show("No es posible iniciar debido a que no se ha especificado al cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    b.Dispose()
                End While

            End If


        Else
            Beep()
            Dim msg As New FrmMsgTouch
            msg.TxtTiulo = "ERROR"
            msg.TxtMsg = "El documento actual no puede ser cerrado sin productos"
            msg.btnCancel.Visible = False
            msg.btnOK.Text = "OK"
            msg.ShowDialog()
            If msg.DialogResult = DialogResult.OK Then
            End If

        End If
    End Sub



    Private Function imprimeCancelado(ByVal Venta As String, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String, ByVal Redondeo As Double, ByVal Saldo As Double, ByVal NuevaVenta As Boolean) As Boolean
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

        If NuevaVenta = False Then
            Tickets.AddHeaderLine("REIMPRESION", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
            lineasImpresas += 1
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

        Tickets.AddTotal(Redondeo, dTotalVenta, dTotalPuntos, dTotalAhorro, dArticulos, TotalRecibido, TotalCambio, Saldo, 1)

        lineasImpresas += 5


        'Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        'parametro de tipo string que debe de ser el nombre de la impresora. 
        Tickets.PrintTicket(Impresora, 70, lineasImpresas)

    End Function

    Private Sub ImprimirPedido(ByVal Venta As String, ByVal Estado As Integer, ByVal Total As Double)

        previewPedido(FormatoPedido, Venta, Total, SUCClave)
    End Sub

    Private Sub EsperaPedido()
        If Not VentaCerrada Then

            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", VENClave)
            If dt.Rows.Count > 0 Then
                EstadoDocumento = dt.Rows(0)("Estado")
                LblFolio.Text = dt.Rows(0)("Folio")
                TotalVenta = dt.Rows(0)("Saldo")
                SaldoVenta = dt.Rows(0)("Total")
                TipoDocumento = dt.Rows(0)("Tipo")
                If TotalArticulos = 0 AndAlso TotalVenta > 0 Then
                    TotalArticulos = 1
                End If

                sFolio = LblFolio.Text

                If sFolio.Split("-").Length > 1 Then
                    Dim iArray As Integer = sFolio.Split("-").Length - 1
                    If IsNumeric(sFolio.Split("-")(iArray)) = True Then
                        lblConsecutivo.Text = CStr(sFolio.Split("-")(iArray))
                    Else
                        lblConsecutivo.Text = ""
                    End If
                Else
                    lblConsecutivo.Text = ""
                End If


                VentaCerrada = True
                modificaStatus(TipoDocumento, EstadoDocumento)
                If dt.Rows(0)("Estado") = 8 OrElse dt.Rows(0)("Estado") = 7 OrElse dt.Rows(0)("Estado") = 4 Then

                    Dim msg As New FrmMsgTouch
                    msg.TxtTiulo = "ERROR"
                    msg.TxtMsg = "El pedido seleccionado No puede ser Cancelado debido a que se encuentra en proceso de recolección o ya ha sido cancelado"
                    msg.btnCancel.Visible = False
                    msg.btnOK.Text = "OK"
                    msg.ShowDialog()
                    If msg.DialogResult = DialogResult.OK Then
                    End If
                    Exit Sub
                End If
            End If
            dt.Dispose()

            If TotalArticulos > 0 Then
                ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", EstadoDocumento, "@ALMClave", AlmacenSurtido, "@Folio", LblFolio.Text, "@MONClave", Moneda, "@TipoCambio", TipoCambio, "@TipoImpuesto", TImpuesto)
                ModPOS.Ejecuta("sp_venta_wait", "@VENClave", VENClave)

            Else

                EstadoDocumento = iEstado.Cancelada
                Dim strFolio As String
                strFolio = "T" & ReferenciaUsr & Referencia & CStr(Today.DayOfYear) & "-" & CStr(FolioTmp)

                If LblFolio.Text = strFolio Then
                    ' ModPOS.Ejecuta("sp_act_folio", "@PDVClave", PDVClave, "@Incremento", -1, "@Tipo", 1)
                    FolioTmp -= 1
                    ModPOS.Ejecuta("sp_elimina_venta", "@VENClave", VENClave)
                Else
                    ObtenerFolio(False)
                    ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", EstadoDocumento, "@ALMClave", AlmacenSurtido, "@Folio", LblFolio.Text, "@MONClave", Moneda, "@TipoCambio", TipoCambio, "@TipoImpuesto", TImpuesto)
                    ModPOS.Ejecuta("sp_cancela_ticket", "@VENClave", VENClave, "@ALMClave", AlmacenSurtido, "@TipoDoc", TipoDocumento, "@Motivo", -1, "@Autoriza", ModPOS.UsuarioActual)
                    ModPOS.Ejecuta("sp_agrega_venta", "@VENClave", VENClave)
                End If

            End If


            VentaCerrada = True

            btnQuitarProducto.Enabled = False
            btnBorrarTodo.Enabled = False
            BtnCerrar.Enabled = False
            GeneraMovSalida = False
            dtPedidoDetalle.Clear()
            TotalArticulos = 0
            TotalPuntos = 0
            TotalVenta = 0
            TotalRecibido = 0
            TotalCambio = 0
            TotalAhorro = 0
            LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
            LblCantidadArticulos.Text = CStr(TotalArticulos)
            LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
            LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

            If Moneda <> MonedaCambio Then
                If MonTipoCambio > 0 Then
                    LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                End If
            Else
                LblTipoCambio.Text = ""
            End If

            LblFolio.Text = Referencia & Microsoft.VisualBasic.Right(CStr(Periodo), 2) & Microsoft.VisualBasic.Right("0" & CStr(Mes), 2) & "-0"
            lblConsecutivo.Text = ""
            cambiaStatus("", iEstado.Original)




        End If
    End Sub


    Private Sub CancelaPedido()
        If Not VentaCerrada Then
            Dim SeCancela As Boolean = False
            Dim bmotivo As Boolean = False
            Dim motCancelacion As Integer = -1

            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", VENClave)
            If dt.Rows.Count > 0 Then
                EstadoDocumento = dt.Rows(0)("Estado")
                LblFolio.Text = dt.Rows(0)("Folio")
                TotalVenta = dt.Rows(0)("Saldo")
                SaldoVenta = dt.Rows(0)("Total")
                TipoDocumento = dt.Rows(0)("Tipo")
                If TotalArticulos = 0 AndAlso TotalVenta > 0 Then
                    TotalArticulos = 1
                End If

                sFolio = LblFolio.Text

                If sFolio.Split("-").Length > 1 Then
                    Dim iArray As Integer = sFolio.Split("-").Length - 1
                    If IsNumeric(sFolio.Split("-")(iArray)) = True Then
                        lblConsecutivo.Text = CStr(sFolio.Split("-")(iArray))
                    Else
                        lblConsecutivo.Text = ""
                    End If
                Else
                    lblConsecutivo.Text = ""
                End If


                VentaCerrada = True
                modificaStatus(TipoDocumento, EstadoDocumento)
                If dt.Rows(0)("Estado") = 8 OrElse dt.Rows(0)("Estado") = 7 OrElse dt.Rows(0)("Estado") = 4 Then
                  
                    Dim msg As New FrmMsgTouch
                    msg.TxtTiulo = "ERROR"
                    msg.TxtMsg = "El pedido seleccionado No puede ser Cancelado debido a que se encuentra en proceso de recolección o ya ha sido cancelado"
                    msg.btnCancel.Visible = False
                    msg.btnOK.Text = "OK"
                    msg.ShowDialog()
                    If msg.DialogResult = DialogResult.OK Then
                    End If
                    Exit Sub
                End If
            End If
            dt.Dispose()

            If TotalArticulos > 0 Then

                EstadoDocumento = iEstado.Cancelada
                ObtenerFolio(False)
                ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", EstadoDocumento, "@ALMClave", AlmacenSurtido, "@Folio", LblFolio.Text, "@MONClave", Moneda, "@TipoCambio", TipoCambio, "@TipoImpuesto", TImpuesto)

                'valida si existe pedidos remotos
                Dim foundRows() As DataRow
                foundRows = dtPedidoDetalle.Select("centroSuministro <> '' ")
                If foundRows.GetLength(0) > 0 Then
                    Dim j As Integer
                    For j = 0 To foundRows.GetUpperBound(0)
                        ModPOS.Ejecuta("stpr_remueveTraslado", "@SUCClave", foundRows(j)("centroSuministro"), "@Destino", SUCClave, "@VENClave", VENClave, "@PROClave", foundRows(j)("PROClave"), "@Cantidad", foundRows(j)("Cantidad"))
                    Next
                End If

                ModPOS.Ejecuta("sp_cancela_ticket", "@VENClave", VENClave, "@ALMClave", AlmacenSurtido, "@TipoDoc", TipoDocumento, "@Motivo", motCancelacion, "@Autoriza", Autoriza)
                ModPOS.Ejecuta("sp_agrega_venta", "@VENClave", VENClave)

                SeCancela = True
            Else

                EstadoDocumento = iEstado.Cancelada
                Dim strFolio As String
                strFolio = "T" & ReferenciaUsr & Referencia & CStr(Today.DayOfYear) & "-" & CStr(FolioTmp)

                If LblFolio.Text = strFolio Then
                    ' ModPOS.Ejecuta("sp_act_folio", "@PDVClave", PDVClave, "@Incremento", -1, "@Tipo", 1)
                    FolioTmp -= 1
                    ModPOS.Ejecuta("sp_elimina_venta", "@VENClave", VENClave)
                Else
                    ObtenerFolio(False)
                    ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", EstadoDocumento, "@ALMClave", AlmacenSurtido, "@Folio", LblFolio.Text, "@MONClave", Moneda, "@TipoCambio", TipoCambio, "@TipoImpuesto", TImpuesto)
                    ModPOS.Ejecuta("sp_cancela_ticket", "@VENClave", VENClave, "@ALMClave", AlmacenSurtido, "@TipoDoc", TipoDocumento, "@Motivo", motCancelacion, "@Autoriza", ModPOS.UsuarioActual)
                    ModPOS.Ejecuta("sp_agrega_venta", "@VENClave", VENClave)
                End If
                SeCancela = True
            End If

            If SeCancela Then
                VentaCerrada = True

                btnQuitarProducto.Enabled = False
                btnBorrarTodo.Enabled = False
                BtnCerrar.Enabled = False
                GeneraMovSalida = False
                dtPedidoDetalle.Clear()
                TotalArticulos = 0
                TotalPuntos = 0
                TotalVenta = 0
                TotalRecibido = 0
                TotalCambio = 0
                TotalAhorro = 0
                LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
                LblCantidadArticulos.Text = CStr(TotalArticulos)
                LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

                If Moneda <> MonedaCambio Then
                    If MonTipoCambio > 0 Then
                        LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                    End If
                Else
                    LblTipoCambio.Text = ""
                End If

                LblFolio.Text = Referencia & Microsoft.VisualBasic.Right(CStr(Periodo), 2) & Microsoft.VisualBasic.Right("0" & CStr(Mes), 2) & "-0"
                lblConsecutivo.Text = ""
                cambiaStatus("", iEstado.Original)



            End If
        End If
    End Sub

    Private Sub btnBorrarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrarTodo.Click
        If Not VentaCerrada Then

            If TotalArticulos > 0 Then

                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", VENClave)
                If dt.Rows.Count > 0 Then
                    EstadoDocumento = dt.Rows(0)("Estado")
                    LblFolio.Text = dt.Rows(0)("Folio")
                    TotalVenta = dt.Rows(0)("Saldo")
                    SaldoVenta = dt.Rows(0)("Total")
                    TipoDocumento = dt.Rows(0)("Tipo")
                    If TotalArticulos = 0 AndAlso TotalVenta > 0 Then
                        TotalArticulos = 1
                    End If
                    sFolio = LblFolio.Text

                    If sFolio.Split("-").Length > 1 Then
                        Dim iArray As Integer = sFolio.Split("-").Length - 1
                        If IsNumeric(sFolio.Split("-")(iArray)) = True Then
                            lblConsecutivo.Text = CStr(sFolio.Split("-")(iArray))
                        Else
                            lblConsecutivo.Text = ""
                        End If
                    Else
                        lblConsecutivo.Text = ""
                    End If


                    VentaCerrada = True
                    modificaStatus(TipoDocumento, EstadoDocumento)
                    MessageBox.Show("No es posible modificar el Documento, ya que No se encuentra Abierto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                dt.Dispose()

                Dim msg As New FrmMsgTouch
                msg.TxtTiulo = "PREGUNTA"
                msg.TxtMsg = "¿Esta seguro que desea eliminar todos los Productos del documento actual?"
                msg.btnCancel.Text = "NO"
                msg.btnOK.Text = "Sí"
                msg.ShowDialog()
                If msg.DialogResult = DialogResult.Cancel Then
                    Exit Sub
                End If


                cancelaProducto(VENClave, TipoDocumento, "")

                ActualizaDetalle(VENClave, True)

                TotalAhorro = 0
                TotalVenta = 0

                If dtPedidoDetalle.Rows.Count > 0 Then
                    TotalAhorro = IIf(dtPedidoDetalle.Compute("SUM(Desc)", "Baja=0").GetType.Name = "DBNull", 0, dtPedidoDetalle.Compute("SUM(Desc)", "Baja=0"))
                    TotalVenta = IIf(dtPedidoDetalle.Compute("SUM(Total)", "Baja=0").GetType.Name = "DBNull", 0, dtPedidoDetalle.Compute("SUM(Total)", "Baja=0"))
                End If

                SaldoVenta = TotalVenta

                LblCantidadPuntos.Text = ModPOS.TruncateToDecimal(TotalPuntos, 2).ToString("#,##0.00")
                LblCantidadArticulos.Text = CStr(TotalArticulos)
                LblAhorro.Text = Format(CStr(ModPOS.TruncateToDecimal(TotalAhorro, 2)), "Currency")
                LblTotal.Text = Format(CStr(ModPOS.TruncateToDecimal(TotalVenta, 2)), "Currency")

                If Moneda <> MonedaCambio Then
                    If MonTipoCambio > 0 Then
                        LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                    End If
                Else
                    LblTipoCambio.Text = ""
                End If

            Else
                MsgBox("El documento no contiene productos", MsgBoxStyle.Information, "Información")
            End If
        End If

    End Sub

    Private Sub cancelaProducto(ByVal VENClave As String, ByVal TipoDoc As Integer, ByVal DVEClave As String)

        Dim dtDetalle As DataTable = ModPOS.Recupera_Tabla("sp_search_producto_detalle", "@Venta", VENClave)

        Dim foundRows() As DataRow

        If DVEClave <> "" Then
            foundRows = dtDetalle.Select("DVEClave ='" & DVEClave & "'")
        Else
            foundRows = dtDetalle.Select()
        End If

        If foundRows.GetLength(0) > 0 Then
            Dim i As Integer

            Dim dCantidad, oVolumen, dVolumen, dVolumenImp, dBase, dPrecioUnitario, UnidadesKilo, dDescGeneralPorc, dDescGeneralImp, dDescPorc, dPorcImp As Decimal
            Dim iGrupoMaterial, iSector, iPartida As Integer
            Dim centroSuministro As String = ""

            Dim iKgLt As Integer
            Dim sTipoDesc As String = ""

            For i = 0 To foundRows.GetUpperBound(0)

                iGrupoMaterial = foundRows(i)("GrupoMaterial")
                iSector = foundRows(i)("Sector")
                iPartida = foundRows(i)("Partida")
                dPrecioUnitario = foundRows(i)("PrecioBruto")
                dPorcImp = foundRows(i)("PorcImp")
                dCantidad = foundRows(i)("Cantidad")
                centroSuministro = foundRows(i)("centroSuministro")



                If foundRows(i)("UndKilo") > 0 Then
                    iKgLt = 1
                Else
                    iKgLt = 0
                End If
                UnidadesKilo = 0
                dBase = 0

                If DVEClave <> "" Then
                    Dim dtDescuento As DataTable = ModPOS.SiExisteRecupera("sp_descuento_partida_open", "@DVEClave", foundRows(i)("DVEClave"))
                    If Not dtDescuento Is Nothing Then
                        'Descuento General
                        Dim foundRows1() As DataRow
                        'foundRows1 = dtDescuento.Select(" Tipo = 1 ")
                        'If foundRows1.Length = 1 Then
                        '    dDescGeneralPorc = foundRows1(0)("DescuentoPorc")
                        'Else
                        dDescGeneralPorc = 0
                        'End If

                        'Descuento Volumen
                        foundRows1 = dtDescuento.Select(" Tipo = 2")
                        If foundRows1.Length = 1 Then
                            oVolumen = foundRows1(0)("DescuentoPorc")
                        Else
                            oVolumen = 0
                        End If


                        'Descuento Gerencial
                        'foundRows1 = dtDescuento.Select(" Tipo = 3 ")
                        'If foundRows1.Length = 1 Then
                        '    dDescPorc = foundRows1(0)("DescuentoPorc")
                        'Else
                        '    dDescPorc = 0
                        'End If
                        dtDescuento.Dispose()
                    End If
                Else
                    dDescPorc = 0
                    oVolumen = 0
                    dDescGeneralPorc = 0
                End If

                dDescGeneralImp = 0

                If oVolumen > 0 Then

                    Dim StrucVol As DescVol


                    StrucVol = obtenerDescuentoVolumen(CTEClaveActual, iGrupoMaterial, iSector, VENClave, foundRows(i)("PROClave"), dBase - dDescGeneralImp)

                    dVolumen = StrucVol.Descuento
                    sTipoDesc = StrucVol.Tipo

                    If dVolumen > 0 Then
                        dVolumenImp = Math.Round((dBase - dDescGeneralImp) * dVolumen, 2)
                    Else
                        dVolumenImp = 0
                    End If


                    'recalcula productos que tengan descuento de volumen
                    If oVolumen <> dVolumen Then
                        Dim dtVolumen As DataTable
                        dtVolumen = Recupera_Tabla("st_recupera_partida", "@VENClave", VENClave, "@Tipo", sTipoDesc, "@Grupo", iGrupoMaterial, "@Sector", iSector, "@PROClave", "")
                        If dtVolumen.Rows.Count > 0 Then
                            Dim y As Integer
                            For y = 0 To dtVolumen.Rows.Count - 1
                                ModPOS.Ejecuta("st_recalcular_detalle", "@DVEClave", dtVolumen.Rows(y)("DVEClave"), "@DesVol", dVolumen, "@TipoDesc", sTipoDesc, "@Autoriza ", ModPOS.UsuarioActual)
                            Next



                        End If
                    End If
                End If

                'dDescuentoImp = Math.Round((dBase - dDescGeneralImp - dVolumenImp) * dDescPorc, 2)
                'dImpuestoImp = Math.Round((dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp) * dPorcImp, 2)
                'dImporteNeto = dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp + dImpuestoImp

                Dim bRemoto As Boolean = False

                If centrosuministro <> "" Then
                    ModPOS.Ejecuta("stpr_remueveTraslado", "@SUCClave", centroSuministro, "@Destino", SUCClave, "@VENClave", VENClave, "@PROClave", foundRows(i)("PROClave"), "@Cantidad", foundRows(i)("Cantidad"))
                    bRemoto = True
                End If


                'Elimina partida y libera apartado
                ModPOS.Ejecuta("sp_elimina_partida", _
                "@ALMClave", ALMClave, _
                "@VENClave", VENClave, _
                "@DVEClave", foundRows(i)("DVEClave"), _
                "@Producto", foundRows(i)("PROClave"), _
                "@Cantidad", foundRows(i)("Cantidad"), _
                "@TipoDoc", TipoDoc, _
                "@TProducto", foundRows(i)("TProducto"), _
                "@Picking", Picking, _
                "@Remoto", bRemoto)




                If Picking = False Then
                    'SI REQUIERE SEGUIMIENTO DE SERIAL
                    If foundRows(i)("Seguimiento") = 2 Then
                        Dim SerialReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = dCantidad
                        Do
                            Dim b As New FrmSerial
                            b.DOCClave = VENClave
                            b.PROClave = foundRows(i)("PROClave")
                            b.Clave = foundRows(i)("Clave")
                            b.Nombre = foundRows(i)("Nombre")
                            b.Cantidad = PorRegistrar
                            b.Dias = foundRows(i)("DiasGarantia")
                            b.TipoDoc = 1
                            b.TipoMov = 1
                            b.ShowDialog()
                            SerialReg = SerialReg + b.NumSerialRegistrados
                            PorRegistrar = PorRegistrar - b.NumSerialRegistrados
                            b.Dispose()
                        Loop Until SerialReg = dCantidad OrElse PorRegistrar = 0
                    End If

                    'SI REQUIERE SEGUIMIENTO DE LOTE
                    If foundRows(i)("Seguimiento") = 3 Then
                        Dim LoteReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = dCantidad
                        Do
                            Dim b As New FrmLote
                            b.DOCClave = VENClave
                            b.PROClave = foundRows(i)("PROClave")
                            b.Clave = foundRows(i)("Clave")
                            b.Nombre = foundRows(i)("Nombre")
                            b.CantXRegistrar = PorRegistrar
                            b.TipoDoc = 1
                            b.TipoMov = 1
                            b.ShowDialog()
                            LoteReg = LoteReg + b.NumSerialRegistrados
                            PorRegistrar = PorRegistrar - b.NumSerialRegistrados
                            b.Dispose()
                        Loop Until LoteReg = dCantidad OrElse PorRegistrar = 0
                    End If

                End If



            Next



        Else
            Beep()
            MessageBox.Show("No se ha especificado la cantidad de producto que desea eliminar de la venta actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub BtnQuitarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarProducto.Click
        If Not VentaCerrada Then

            If TotalArticulos > 0 AndAlso Not GridDetalle.GetValue("DVEClave") Is Nothing Then

                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", VENClave)
                If dt.Rows.Count > 0 Then
                    EstadoDocumento = dt.Rows(0)("Estado")
                    LblFolio.Text = dt.Rows(0)("Folio")
                    TotalVenta = dt.Rows(0)("Saldo")
                    SaldoVenta = dt.Rows(0)("Total")
                    TipoDocumento = dt.Rows(0)("Tipo")
                    If TotalArticulos = 0 AndAlso TotalVenta > 0 Then
                        TotalArticulos = 1
                    End If

                    sFolio = LblFolio.Text

                    If sFolio.Split("-").Length > 1 Then
                        Dim iArray As Integer = sFolio.Split("-").Length - 1
                        If IsNumeric(sFolio.Split("-")(iArray)) = True Then
                            lblConsecutivo.Text = CStr(sFolio.Split("-")(iArray))
                        Else
                            lblConsecutivo.Text = ""
                        End If
                    Else
                        lblConsecutivo.Text = ""
                    End If


                    VentaCerrada = True
                    modificaStatus(TipoDocumento, EstadoDocumento)
                  
                    Dim msg As New FrmMsgTouch
                    msg.TxtTiulo = "ERROR"
                    msg.TxtMsg = "No es posible modificar el Documento, ya que No se encuentra Abierto"
                    msg.btnCancel.Visible = False
                    msg.btnOK.Text = "OK"
                    msg.ShowDialog()
                    If msg.DialogResult = DialogResult.OK Then
                    End If
                    Exit Sub
                End If
                dt.Dispose()

                Dim msg1 As New FrmMsgTouch
                msg1.TxtTiulo = "PREGUNTA"
                msg1.TxtMsg = "¿Esta seguro que desea eliminar el Producto: " & GridDetalle.GetValue("Modelo") & " " & GridDetalle.GetValue("Color") & " " & GridDetalle.GetValue("Talla") & " ?"
                msg1.btnCancel.Text = "NO"
                msg1.btnOK.Text = "Sí"
                msg1.ShowDialog()
                If msg1.DialogResult = DialogResult.Cancel Then
                    Exit Sub
                End If

            
                If GridDetalle.GetValue("IdKIT") = "" Then
                    cancelaProducto(VENClave, TipoDocumento, GridDetalle.GetValue("DVEClave"))
                Else
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtPedidoDetalle.Select("IdKIT = '" & GridDetalle.GetValue("IdKIT") & "'")

                    Dim x As Integer
                    For x = 0 To foundRows.Length - 1
                        cancelaProducto(VENClave, TipoDocumento, foundRows(x)("DVEClave"))
                    Next

                End If

                If AplicaPromocionFinal = 0 AndAlso TipoDocumento <> 2 Then
                    ModPOS.Ejecuta("st_aplicar_promociones", _
                                   "@CTEClave", CTEClaveActual, _
                                   "@SUCClave", SUCClave, _
                                   "@TImpuesto", TImpuesto, _
                                   "@VENClave", VENClave, _
                                   "@Usuario", ModPOS.UsuarioActual)
                End If

                ActualizaDetalle(VENClave, True)


                TotalAhorro = 0
                TotalVenta = 0

                If dtPedidoDetalle.Rows.Count > 0 Then
                    TotalAhorro = IIf(dtPedidoDetalle.Compute("SUM(Desc)", "Baja=0").GetType.Name = "DBNull", 0, dtPedidoDetalle.Compute("SUM(Desc)", "Baja=0"))
                    TotalVenta = IIf(dtPedidoDetalle.Compute("SUM(Total)", "Baja=0").GetType.Name = "DBNull", 0, dtPedidoDetalle.Compute("SUM(Total)", "Baja=0"))
                End If

                SaldoVenta = TotalVenta

                LblCantidadPuntos.Text = ModPOS.TruncateToDecimal(TotalPuntos, 2).ToString("#,##0.00")
                LblCantidadArticulos.Text = CStr(TotalArticulos)
                LblAhorro.Text = Format(CStr(ModPOS.TruncateToDecimal(TotalAhorro, 2)), "Currency")
                LblTotal.Text = Format(CStr(ModPOS.TruncateToDecimal(TotalVenta, 2)), "Currency")

                If Moneda <> MonedaCambio Then
                    If MonTipoCambio > 0 Then
                        LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                    End If
                Else
                    LblTipoCambio.Text = ""
                End If


            Else
                MsgBox("El documento no contiene productos", MsgBoxStyle.Information, "Información")
            End If
        End If

    End Sub

    Public Sub recuperaVentaOpen( _
    ByVal sVENClave As String, _
    ByVal sFolio As String, _
    ByVal sCTEClave As String, _
    ByVal sRazonSocial As String, _
    ByVal sCajero As String, _
    ByVal sReferenciaCaj As String, _
    ByVal sNombreUsuario As String, _
    ByVal dSaldo As Double, _
    ByVal Total As Double, _
    ByVal iTipo As Integer, _
    ByVal iEstado As Integer, _
    ByVal Limite As Double, _
    ByVal Dias As Double, _
    ByVal SaldoCliente As Double, _
    ByVal sAlmacen As String)


        Dim dt, dtVta As DataTable
        Dim FechaVenta As DateTime = Today.Date

        dtVta = ModPOS.SiExisteRecupera("sp_recupera_vta_open", "@VENClave", sVENClave)

        If Not dtVta Is Nothing Then
            CTEClaveActual = sCTEClave
            FechaVenta = CDate(dtVta.Rows(0)("Fecha"))
            ClienteSAP = dtVta.Rows(0)("ClienteSAP")
            Moneda = IIf(dtVta.Rows(0)("MONClave").GetType.Name = "DBNull", Moneda, dtVta.Rows(0)("MONCLave"))
            TipoCambio = dtVta.Rows(0)("TipoCambio")
        End If

        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
        MonedaRef = dt.Rows(0)("Referencia")
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_alm", "@ALMClave", sAlmacen)

        If dt.Rows.Count > 0 Then
            bLoad = False

            AlmacenSurtido = dt.Rows(0)("ALMClave")
            sAlmacen = dt.Rows(0)("Clave") & " - " & dt.Rows(0)("Nombre")
            bLoad = True
        End If
        dt.Dispose()

        If sVENClave = "" Then
            Exit Sub
        End If

        VENClave = sVENClave




        btnQuitarProducto.Enabled = True
        btnBorrarTodo.Enabled = True

        BtnCerrar.Enabled = True


        With Me
            TotalArticulos = 0
            TotalPuntos = 0
            TotalVenta = 0
            TotalRecibido = 0
            TotalCambio = 0
            TotalAhorro = 0
            TotalVenta = 0



            .VentaCerrada = False
            .GeneraMovSalida = True

            .LblFolio.Text = sFolio

            Dim sFol As String = sFolio

            Dim iArray As Integer = sFol.Split("-").Length - 1

            Folio = CInt(sFol.Split("-")(iArray))
            If sFol.Substring(0, 1) = "T" Then
                .FolioTmp = .Folio
            End If

            lblConsecutivo.Text = CStr(Folio)

            .AtiendeClave = sCajero
            .ReferenciaUsr = sReferenciaCaj
            .AtiendeNombre = sNombreUsuario

            .TipoDocumento = iTipo


            If FechaVenta.Date <> Today.Date Then

                'recupera partida
                Dim dtventadetalle As DataTable

                dtventadetalle = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", sVENClave)

                .SaldoVenta = 0
                .TotalVenta = 0
                .EstadoDocumento = 1


                Dim frmstatusmessage As frmStatus = Nothing

                frmstatusmessage = New frmStatus
                frmstatusmessage.Show("Estamos recalculando el documento debido a que tiene más de un día de antiguedad ...")

                'reinicializa venta
                ModPOS.Ejecuta("st_reinicia_venta", "@VENClave", .VENClave)

                If Not dtventadetalle Is Nothing Then
                    Dim i As Integer = 0

                    For i = 0 To dtventadetalle.Rows.Count - 1
                        If CStr(dtventadetalle.Rows(i)("centroSuministro")) = "" Then
                            leeCodigoBarras("", dtventadetalle.Rows(i)("Cantidad"), dtventadetalle.Rows(i)("Clave"), True, False, False, False, False, "", "", 0, False, dtventadetalle.Rows(i)("PREClaveKIT"), dtventadetalle.Rows(i)("PrecioBruto"), dtventadetalle.Rows(i)("IdKit"))
                        End If
                    Next
                    dtventadetalle.Dispose()

                End If

                frmstatusmessage.Close()
            Else


                Dim sCliente As String

                If SincronizaCte = 1 AndAlso MaskCte = 1 Then
                    sCliente = CTEClaveActual
                Else
                    If ClienteSAP <> "" AndAlso CTEClaveActual <> ClienteSAP Then
                        sCliente = ClienteSAP
                    Else
                        sCliente = CTEClaveActual
                    End If
                End If

                Dim dtCliente As DataTable
                dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", sCliente, "@TipoCanal", TipoCanal)
                .ListaPrecio = dtCliente.Rows(0)("PREClave")
                .TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                dtCliente.Dispose()

                .SaldoVenta = dSaldo

                .EstadoDocumento = iEstado

                ActualizaDetalle(VENClave, False)

                ModPOS.Ejecuta("sp_venta_estado", "@VENClave", VENClave, "@Estado", 1)


                'Valida Disponibilidad
                Dim i As Integer
                Dim Disponible, dEliminar As Decimal
                Dim dtEliminar As DataTable
                dtEliminar = ModPOS.Recupera_Tabla("sp_search_producto_detalle", "@Venta", VENClave)

                Dim foundRows() As System.Data.DataRow


                For i = 0 To dtPedidoDetalle.Rows.Count - 1
                    If dtPedidoDetalle.Rows(i)("centroSuministro") = "" Then
                        Disponible = dtPedidoDetalle.Rows(i)("Cantidad")
                        Disponible -= validaBloqueado(AlmacenSurtido, dtPedidoDetalle.Rows(i)("Cantidad"), dtPedidoDetalle.Rows(i)("PROClave"), dtPedidoDetalle.Rows(i)("Clave"))
                        If Disponible < dtPedidoDetalle.Rows(i)("Cantidad") Then
                            dEliminar = CDec(dtPedidoDetalle.Rows(i)("Cantidad")) - Disponible
                            foundRows = dtEliminar.Select("DVEClave = '" & CStr(dtPedidoDetalle.Rows(i)("DVEClave")) & "'")
                            foundRows(0)("Eliminar") = dEliminar
                            MessageBox.Show("Lo sentimos hubo un cambio en la disponibilidad del producto " & CStr(dtPedidoDetalle.Rows(i)("Clave")) & " " & CStr(dtPedidoDetalle.Rows(i)("Nombre")) & ", por lo que se eliminaran: " & CStr(dEliminar), "Información", MessageBoxButtons.OK)
                        End If
                    End If
                Next


                Dim foundRows2() As DataRow

                foundRows = dtEliminar.Select("Eliminar > 0 and Cantidad >= Eliminar and IdKIT <> '' ")
                If foundRows.GetLength(0) > 0 Then
                    Dim j As Integer
                    Dim sIdKIT As String = ""
                    For i = 0 To foundRows.GetUpperBound(0)

                        If sIdKIT <> foundRows(i)("IdKIT") Then
                            sIdKIT = foundRows(i)("IdKIT")
                            foundRows2 = dtEliminar.Select("Eliminar = 0 and IdKIT = '" & foundRows(i)("IdKIT") & "' ")
                            If foundRows.Length > 0 Then
                                For j = 0 To foundRows2.GetUpperBound(0)
                                    foundRows2(j)("Eliminar") = foundRows2(j)("Cantidad")
                                Next
                            End If
                        End If
                    Next
                End If


                foundRows = dtEliminar.Select("Eliminar > 0 and Cantidad >= Eliminar")

                If foundRows.GetLength(0) > 0 Then
                    Dim SeBorra As Boolean

                    Dim dCantidad, oVolumen, dVolumen, dVolumenImp, dBase, dPrecioUnitario, UnidadesKilo, dDescGeneralPorc, dDescGeneralImp, dDescPorc, dPorcImp, dDescuentoImp, dImpuestoImp, dImporteNeto As Decimal
                    Dim iGrupoMaterial, iSector, iPartida As Integer

                    Dim iKgLt As Integer
                    Dim sTipoDesc As String = ""

                    Dim CantidadEliminar, CantidadOrigen As Decimal


                    For i = 0 To foundRows.GetUpperBound(0)

                        iGrupoMaterial = foundRows(i)("GrupoMaterial")
                        iSector = foundRows(i)("Sector")
                        iPartida = foundRows(i)("Partida")

                        CantidadEliminar = foundRows(i)("Eliminar")
                        CantidadOrigen = foundRows(i)("Cantidad")
                        dPrecioUnitario = foundRows(i)("PrecioBruto")
                        dPorcImp = foundRows(i)("PorcImp")

                        dCantidad = CantidadOrigen - CantidadEliminar

                        If foundRows(i)("UndKilo") > 0 AndAlso dCantidad > 0 Then
                            iKgLt = 1
                            UnidadesKilo = dCantidad / (CantidadOrigen / foundRows(i)("UndKilo"))
                        Else
                            iKgLt = 0
                            UnidadesKilo = 0
                        End If

                        dBase = Math.Round(dPrecioUnitario * dCantidad, 2)


                        Dim dtDescuento As DataTable = ModPOS.SiExisteRecupera("sp_descuento_partida_open", "@DVEClave", foundRows(i)("DVEClave"))
                        If Not dtDescuento Is Nothing Then
                            'Descuento General
                            Dim foundRows1() As DataRow = dtDescuento.Select(" Tipo = 1 ")
                            If foundRows1.Length = 1 Then
                                dDescGeneralPorc = foundRows1(0)("DescuentoPorc")
                            Else
                                dDescGeneralPorc = 0
                            End If

                            'Descuento Volumen
                            foundRows1 = dtDescuento.Select(" Tipo = 2")
                            If foundRows1.Length = 1 Then
                                oVolumen = foundRows1(0)("DescuentoPorc")
                            Else
                                oVolumen = 0
                            End If


                            'Descuento Gerencial
                            foundRows1 = dtDescuento.Select(" Tipo = 3 ")
                            If foundRows1.Length = 1 Then
                                dDescPorc = foundRows1(0)("DescuentoPorc")
                            Else
                                dDescPorc = 0
                            End If
                            dtDescuento.Dispose()
                        Else
                            dDescPorc = 0
                            oVolumen = 0
                            dDescGeneralPorc = 0
                        End If

                        dDescGeneralImp = Math.Round(dBase * dDescGeneralPorc, 2)

                        If oVolumen > 0 Then

                            Dim StrucVol As DescVol


                            StrucVol = obtenerDescuentoVolumen(CTEClaveActual, iGrupoMaterial, iSector, VENClave, foundRows(i)("PROClave"), dBase - dDescGeneralImp)

                            dVolumen = StrucVol.Descuento
                            sTipoDesc = StrucVol.Tipo

                            If dVolumen > 0 Then
                                dVolumenImp = Math.Round((dBase - dDescGeneralImp) * dVolumen, 2)
                            Else
                                dVolumenImp = 0
                            End If


                            'recalcula productos que tengan descuento de volumen
                            If oVolumen <> dVolumen Then
                                Dim dtVolumen As DataTable
                                dtVolumen = Recupera_Tabla("st_recupera_partida", "@VENClave", VENClave, "@Tipo", sTipoDesc, "@Grupo", iGrupoMaterial, "@Sector", iSector, "@PROClave", "")
                                If dtVolumen.Rows.Count > 0 Then
                                    Dim y As Integer
                                    For y = 0 To dtVolumen.Rows.Count - 1
                                        ModPOS.Ejecuta("st_recalcular_detalle", "@DVEClave", dtVolumen.Rows(y)("DVEClave"), "@DesVol", dVolumen, "@TipoDesc", sTipoDesc, "@Autoriza ", ModPOS.UsuarioActual)
                                    Next


                                End If
                            End If
                        End If

                        dDescuentoImp = Math.Round((dBase - dDescGeneralImp - dVolumenImp) * dDescPorc, 2)
                        dImpuestoImp = Math.Round((dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp) * dPorcImp, 2)
                        dImporteNeto = dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp + dImpuestoImp


                        Dim SeCancela As Boolean = False
                        Dim bRemoto As Boolean
                        Select Case CantidadEliminar
                            Case Is = CantidadOrigen
                                SeCancela = True
                                SeBorra = True

                                bRemoto = False
                                If foundRows(i)("centroSuministro") <> "" Then
                                    bRemoto = True
                                End If

                                'Elimina partida y libera apartado
                                ModPOS.Ejecuta("sp_elimina_partida", _
                                "@ALMClave", ALMClave, _
                                "@VENClave", VENClave, _
                                "@DVEClave", foundRows(i)("DVEClave"), _
                                "@Producto", foundRows(i)("PROClave"), _
                                "@Cantidad", foundRows(i)("Cantidad"), _
                                "@TipoDoc", TipoDocumento, _
                                "@TProducto", foundRows(i)("TProducto"), _
                                "@Picking", Picking, _
                                "@Remoto", bRemoto)



                            Case Is < CantidadOrigen
                                SeBorra = False
                                SeCancela = True
                                'Actualiza total de la partida y libera apartado

                                ModPOS.Ejecuta("sp_actualiza_detalle", _
                                                  "@ALMClave", ALMClave, _
                                                  "@VENTA", VENClave, _
                                                  "@PROClave", foundRows(i)("PROClave"), _
                                                  "@PrecioBruto", dPrecioUnitario, _
                                                  "@Cantidad", dCantidad, _
                                                  "@Importe", dBase, _
                                                  "@DescGenPor", dDescGeneralPorc, _
                                                  "@DescGenImp", dDescGeneralImp, _
                                                  "@DescVolPor", dVolumen, _
                                                  "@DescVolImp", dVolumenImp, _
                                                  "@DescuentoPor", dDescPorc, _
                                                  "@DescuentoImp", dDescuentoImp, _
                                                  "@ImpuestoImp", dImpuestoImp, _
                                                  "@TProducto", foundRows(i)("TProducto"), _
                                                  "@TipoDoc", TipoDocumento, _
                                                  "@Picking", Picking, _
                                                  "@UndKilo", UnidadesKilo, _
                                                  "@DVEClave", foundRows(i)("DVEClave"), _
                                                  "@PorcImp", dPorcImp, _
                                                  "@Usuario", ModPOS.UsuarioActual, _
                                                  "@TipoDesc", sTipoDesc, _
                                                  "@Autoriza", "", _
                                                  "@Total", dImporteNeto, _
                                                  "@centroSuministro", foundRows(i)("centroSuministro"))

                                If foundRows(i)("centroSuministro") = "" Then
                                    ModPOS.Ejecuta("sp_actualiza_partida", _
                                                            "@ALMClave", ALMClave, _
                                                            "@VENClave", VENClave, _
                                                            "@DVEClave", foundRows(i)("DVEClave"), _
                                                            "@Producto", foundRows(i)("PROClave"), _
                                                            "@Cantidad", CantidadEliminar, _
                                                            "@TipoDoc", TipoDocumento, _
                                                            "@TProducto", foundRows(i)("TProducto"), _
                                                            "@Picking", Picking)

                                End If

                        End Select

                        If Picking = False Then
                            'SI REQUIERE SEGUIMIENTO DE SERIAL
                            If foundRows(i)("Seguimiento") = 2 Then
                                Dim SerialReg As Integer = 0
                                Dim PorRegistrar As Double
                                PorRegistrar = CantidadEliminar
                                Do
                                    Dim b As New FrmSerial
                                    b.DOCClave = VENClave
                                    b.PROClave = foundRows(i)("PROClave")
                                    b.Clave = foundRows(i)("Clave")
                                    b.Nombre = foundRows(i)("Nombre")
                                    b.Cantidad = PorRegistrar
                                    b.Dias = foundRows(i)("DiasGarantia")
                                    b.TipoDoc = 1
                                    b.TipoMov = 1
                                    b.ShowDialog()
                                    SerialReg = SerialReg + b.NumSerialRegistrados
                                    PorRegistrar = PorRegistrar - b.NumSerialRegistrados
                                    b.Dispose()
                                Loop Until SerialReg = CantidadEliminar OrElse PorRegistrar = 0
                            End If

                            'SI REQUIERE SEGUIMIENTO DE LOTE
                            If foundRows(i)("Seguimiento") = 3 Then
                                Dim LoteReg As Integer = 0
                                Dim PorRegistrar As Double
                                PorRegistrar = CantidadEliminar
                                Do
                                    Dim b As New FrmLote
                                    b.DOCClave = VENClave
                                    b.PROClave = foundRows(i)("PROClave")
                                    b.Clave = foundRows(i)("Clave")
                                    b.Nombre = foundRows(i)("Nombre")
                                    b.CantXRegistrar = PorRegistrar
                                    b.TipoDoc = 1
                                    b.TipoMov = 1
                                    b.ShowDialog()
                                    LoteReg = LoteReg + b.NumSerialRegistrados
                                    PorRegistrar = PorRegistrar - b.NumSerialRegistrados
                                    b.Dispose()
                                Loop Until LoteReg = CantidadEliminar OrElse PorRegistrar = 0
                            End If

                        End If



                    Next



                    If AplicaPromocionFinal = 0 AndAlso TipoDocumento <> 2 Then
                        Dim msg As String = ModPOS.Ejecuta("st_aplicar_promociones", _
                                       "@CTEClave", CTEClaveActual, _
                                       "@SUCClave", SUCClave, _
                                       "@TImpuesto", TImpuesto, _
                                       "@VENClave", VENClave, _
                                       "@Usuario", ModPOS.UsuarioActual)
                    End If


                    ActualizaDetalle(VENClave, True)


                End If



            End If

            modificaStatus(TipoDocumento, EstadoDocumento)
            If TotalArticulos = 0 Then

                Dim msg As New FrmMsgTouch
                msg.TxtTiulo = "INFORMACIÓN"
                msg.TxtMsg = "El documento en espera ha sido recuperado exitosamente"
                msg.btnCancel.Visible = False
                msg.btnOK.Text = "OK"
                msg.ShowDialog()
                If msg.DialogResult = DialogResult.OK Then
                End If
            End If
        End With
    End Sub

    Public Sub recuperaTicket(ByVal Tipo As Integer, ByVal Cadena As String)

        'Tipo 1 = Folio 2= VENClave

        Dim dtVenta As DataTable = ModPOS.SiExisteRecupera("sp_recupera_venta_cerrada", "@Tipo", Tipo, "@Cadena", Cadena)

        If Not dtVenta Is Nothing Then
            btnQuitarProducto.Enabled = False
            btnBorrarTodo.Enabled = True
            BtnCerrar.Enabled = True

            VentaCerrada = True
            GeneraMovSalida = False


            dtPedidoDetalle.Clear()
            'recupera ticket

            VENClave = dtVenta.Rows(0)("VENClave")
            LblFolio.Text = dtVenta.Rows(0)("Folio")
            CTEClaveActual = dtVenta.Rows(0)("CTEClave")
            CTENombreActual = dtVenta.Rows(0)("RazonSocial")
            TipoDocumento = dtVenta.Rows(0)("Tipo")
            SaldoVenta = dtVenta.Rows(0)("Saldo")
            TotalVenta = dtVenta.Rows(0)("Total")
            TotalPuntos = dtVenta.Rows(0)("PuntosTot")
            TotalRecibido = TotalVenta - SaldoVenta
            TotalCambio = 0
            Periodo = dtVenta.Rows(0)("Periodo")
            Mes = dtVenta.Rows(0)("Mes")
            EstadoDocumento = dtVenta.Rows(0)("Estado")

            ClienteSAP = dtVenta.Rows(0)("ClienteSAP")

            modificaStatus(TipoDocumento, EstadoDocumento)

            sFolio = LblFolio.Text

            If sFolio.Split("-").Length > 1 Then
                Dim iArray As Integer = sFolio.Split("-").Length - 1
                If IsNumeric(sFolio.Split("-")(iArray)) = True Then
                    lblConsecutivo.Text = CStr(sFolio.Split("-")(iArray))
                Else
                    lblConsecutivo.Text = ""
                End If
            Else
                lblConsecutivo.Text = ""
            End If


            Dim sCliente As String

            If SincronizaCte = 1 AndAlso MaskCte = 1 Then
                sCliente = CTEClaveActual
            Else
                If ClienteSAP <> "" AndAlso CTEClaveActual <> ClienteSAP Then
                    sCliente = ClienteSAP
                Else
                    sCliente = CTEClaveActual
                End If
            End If

            Dim dtCliente As DataTable
            dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", sCliente, "@TipoCanal", TipoCanal)
            ListaPrecio = dtCliente.Rows(0)("PREClave")
            TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
            dtCliente.Dispose()



            'recupera partida
            dtVenta.Dispose()

            ActualizaDetalle(VENClave, False)


            ModPOS.Ejecuta("sp_agrega_tmp_venta", "@VENClave", VENClave, "@PDVClave", PDVClave)
        Else
            MessageBox.Show("El ticket que intenta recuperar no existe o se encuentra totalmente pagado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    'Private Sub ItemApartado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    '    If AlmacenSurtido = "" OrElse AlmacenSurtido Is Nothing Then
    '        Beep()
    '        MessageBox.Show("No es posible crear el documento debido a que no se ha especificado el Almacen para surtido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Exit Sub
    '    End If

    '    Dim b As New FrmSolicitaCliente
    '    b.ClienteInicial = CTEClaveInicial
    '    b.ShowDialog()
    '    If b.DialogResult = DialogResult.OK Then
    '        CTEClaveActual = b.ClienteClave
    '        CTENombreActual = b.ClienteNombre
    '        LblCliente.Text = CTENombreActual
    '    Else
    '        CTEClaveActual = CTEClaveInicial
    '        CTENombreActual = CTENombreInicial
    '        LblCliente.Text = CTENombreActual
    '        MessageBox.Show("No es posible crear el apartado debido a que no se ha especificado al cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Exit Sub
    '    End If
    '    b.Dispose()

    '    If SolicitaVendedor Then
    '        Dim a As New FrmSolicitaUsuario
    '        a.ShowDialog()
    '        If a.DialogResult = DialogResult.OK Then
    '            Me.AtiendeNombre = a.AtiendeNombre
    '            Me.ReferenciaUsr = a.ReferenciaUsr
    '            Me.AtiendeClave = a.AtiendeClave

    '        Else
    '            CTEClaveActual = CTEClaveInicial
    '            CTENombreActual = CTENombreInicial
    '            LblCliente.Text = CTENombreActual
    '            MessageBox.Show("No es posible crear una nueva venta debido a que no se ha sido registrado un Vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Exit Sub
    '        End If
    '        a.Dispose()
    '    End If


    '    Dim dt As DataTable

    '    dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
    '    MonedaRef = dt.Rows(0)("Referencia")
    '    TipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
    '    dt.Dispose()


    '    If Moneda <> MonedaCambio Then
    '        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
    '        MonRefCambio = dt.Rows(0)("Referencia")
    '        MonTipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
    '        dt.Dispose()

    '    Else
    '        MonRefCambio = MonedaRef
    '        MonTipoCambio = TipoCambio
    '    End If




    '    ObtenerFolio(True)

    '    TipoDocumento = 4
    '    EstadoDocumento = 1


    '    modificaStatus(TipoDocumento, EstadoDocumento)

    '    VENClave = ModPOS.obtenerLlave()

    '    dt = ModPOS.Recupera_Tabla("st_valida_llave", "@Tipo", 1, "@id", VENClave)
    '    If dt.Rows.Count = 1 Then
    '        VENClave = ModPOS.obtenerLlave
    '    End If
    '    dt.Dispose()

    '    ModPOS.Ejecuta("sp_crea_venta", _
    '    "@VENClave", VENClave, _
    '    "@PDVClave", PDVClave, _
    '    "@Folio", LblFolio.Text, _
    '    "@Cliente", CTEClaveActual, _
    '    "@Cajero", AtiendeClave, _
    '    "@CAJClave", CAJClave, _
    '    "@Tipo", TipoDocumento, _
    '      "@ALMClave", AlmacenSurtido, _
    '      "@TipoCanal", TipoCanal, _
    '    "@Usuario", ModPOS.UsuarioActual)


    '    btnQuitarProducto.Enabled = True
    '    btnBorrarTodo.Enabled = True

    '    BtnCerrar.Enabled = True

    '    VentaCerrada = False
    '    GeneraMovSalida = False



    '    dtPedidoDetalle.Clear()

    '    TotalArticulos = 0
    '    TotalPuntos = 0
    '    TotalVenta = 0
    '    TotalRecibido = 0
    '    TotalCambio = 0
    '    TotalAhorro = 0

    '    LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
    '    LblCantidadArticulos.Text = CStr(TotalArticulos)
    '    LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
    '    LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

    '    If Moneda <> MonedaCambio Then
    '        If MonTipoCambio > 0 Then
    '            LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
    '        Else
    '            LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
    '        End If
    '    Else
    '        LblTipoCambio.Text = ""
    '    End If

    'End Sub

    'Private Sub ItemCotizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If AlmacenSurtido = "" OrElse AlmacenSurtido Is Nothing Then
    '        Beep()
    '        MessageBox.Show("No es posible crear el documento debido a que no se ha especificado el Almacen para surtido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Exit Sub
    '    End If

    '    If ActivarCotizacion = True Then
    '        If SolicitaVendedor Then

    '            Dim a As New FrmSolicitaUsuario
    '            a.ShowDialog()
    '            If a.DialogResult = DialogResult.OK Then
    '                Me.AtiendeNombre = a.AtiendeNombre
    '                Me.ReferenciaUsr = a.ReferenciaUsr
    '                Me.AtiendeClave = a.AtiendeClave

    '            Else
    '                MessageBox.Show("No es posible crear una nueva venta debido a que no se ha sido registrado un Vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                Exit Sub
    '            End If
    '            a.Dispose()

    '        End If

    '        Dim dt As DataTable

    '        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
    '        MonedaRef = dt.Rows(0)("Referencia")
    '        TipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
    '        dt.Dispose()


    '        If Moneda <> MonedaCambio Then
    '            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
    '            MonRefCambio = dt.Rows(0)("Referencia")
    '            MonTipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
    '            dt.Dispose()

    '        Else
    '            MonRefCambio = MonedaRef
    '            MonTipoCambio = TipoCambio
    '        End If


    '        CTEClaveActual = CTEClaveInicial
    '        CTENombreActual = CTENombreInicial
    '        LblCliente.Text = CTENombreActual



    '        ObtenerFolio(True)

    '        TipoDocumento = 2

    '        EstadoDocumento = 1


    '        modificaStatus(TipoDocumento, EstadoDocumento)


    '        VENClave = ModPOS.obtenerLlave()

    '        dt = ModPOS.Recupera_Tabla("st_valida_llave", "@Tipo", 1, "@id", VENClave)
    '        If dt.Rows.Count = 1 Then
    '            VENClave = ModPOS.obtenerLlave
    '        End If
    '        dt.Dispose()

    '        ModPOS.Ejecuta("sp_crea_venta", _
    '        "@VENClave", VENClave, _
    '        "@PDVClave", PDVClave, _
    '        "@Folio", LblFolio.Text, _
    '        "@Cliente", CTEClaveActual, _
    '        "@Cajero", AtiendeClave, _
    '        "@CAJClave", CAJClave, _
    '        "@Tipo", TipoDocumento, _
    '         "@ALMClave", AlmacenSurtido, _
    '          "@TipoCanal", TipoCanal, _
    '        "@Usuario", ModPOS.UsuarioActual)



    '        btnQuitarProducto.Enabled = True
    '        btnBorrarTodo.Enabled = True

    '        BtnCerrar.Enabled = True

    '        VentaCerrada = False
    '        GeneraMovSalida = False


    '        dtPedidoDetalle.Clear()

    '        TotalArticulos = 0
    '        TotalPuntos = 0
    '        TotalVenta = 0
    '        TotalRecibido = 0
    '        TotalCambio = 0
    '        TotalAhorro = 0

    '        LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
    '        LblCantidadArticulos.Text = CStr(TotalArticulos)
    '        LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
    '        LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

    '        If Moneda <> MonedaCambio Then
    '            If MonTipoCambio > 0 Then
    '                LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
    '            Else
    '                LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
    '            End If
    '        Else
    '            LblTipoCambio.Text = ""
    '        End If
    '    End If
    'End Sub

    'Private Sub ItemCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    '    If Caja Then
    '        Dim a As New FrmCambios
    '        a.CAJClave = CAJClave
    '        a.PDVClave = PDVClave
    '        a.SUCClave = SUCClave
    '        a.ClienteActual = Me.CTEClaveActual
    '        a.NombreClienteActual = Me.CTENombreActual
    '        a.Almacen = ALMClave
    '        a.Generic = Me.PrintGeneric
    '        a.Ticket = Me.Ticket
    '        a.Impresora = Me.Impresora

    '        a.Referencia = Me.Referencia
    '        a.ShowDialog()
    '        a.Dispose()
    '    Else
    '        MessageBox.Show("El punto de venta no cuenta con una Caja asignada por lo que no es posible realizar el cambio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    'End Sub

    Private Sub picSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub GridDetalle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.DoubleClick
        BtnModificar.PerformClick()
    End Sub

    Private Function cambiaCliente(ByVal sCTEClave As String, Optional ByVal Autorizado As Boolean = False) As Boolean
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", sCTEClave)
        If dt.Rows.Count = 0 Then


            Dim msg As New FrmMsgTouch
            msg.TxtTiulo = "ERROR"
            msg.TxtMsg = "Error al intentar cargar información de domicilios del cliente"
            msg.btnCancel.Visible = False
            msg.btnOK.Text = "OK"
            msg.ShowDialog()
            If msg.DialogResult = DialogResult.OK Then
            End If

            dt.Dispose()
            Return False
        End If

        If CInt(dt.Rows(0)("Estado")) = 0 Then

            Dim msg As New FrmMsgTouch
            msg.TxtTiulo = "ERROR"
            msg.TxtMsg = "Error al intentar cargar información del cliente, ya que se encuentra Inactivo"
            msg.btnCancel.Visible = False
            msg.btnOK.Text = "OK"
            msg.ShowDialog()
            If msg.DialogResult = DialogResult.OK Then
            End If

            Return False
        End If

        Dim Tel1 As String = dt.Rows(0)("Tel1")
        Dim eMail As String = dt.Rows(0)("Email")

        Dim NIP As String = IIf(dt.Rows(0)("Password").GetType.Name = "DBNull", "", dt.Rows(0)("Password"))

        NivelDesc = IIf(dt.Rows(0)("NivelDesc").GetType.Name = "DBNull", "", dt.Rows(0)("NivelDesc"))
        CTEClaveActual = sCTEClave
        CtaMaestra = dt.Rows(0)("CtaMaestra")
        DCTEClave = dt.Rows(0)("DCTEClave")
        ClienteSAP = IIf(dt.Rows(0)("ClienteSAP").GetType.Name = "DBNull", "", dt.Rows(0)("ClienteSAP"))
        CTENombreActual = dt.Rows(0)("RazonSocial")
        NumeroAfiliado = dt.Rows(0)("Clave")
        CreditoDisp = dt.Rows(0)("Disponible")
        LimiteCredito = dt.Rows(0)("LimiteCredito")
        DiasCredito = dt.Rows(0)("DiasCredito")
        SaldoCte = dt.Rows(0)("Saldo")
        Dim fechaNacimiento As Date = IIf(dt.Rows(0)("fechaNacimiento").GetType.Name = "DBNull", Today.Date, dt.Rows(0)("fechaNacimiento"))
        Dim Genero As Integer = IIf(dt.Rows(0)("Genero").GetType.Name = "DBNull", 1, dt.Rows(0)("Genero"))
        Dim tipoTel1 As Integer = IIf(dt.Rows(0)("tipoTel1").GetType.Name = "DBNull", 1, dt.Rows(0)("tipoTel1"))

        Dim codigoPostal As String = IIf(dt.Rows(0)("codigoPostal").GetType.Name = "DBNull", "", dt.Rows(0)("codigoPostal"))

        dt.Dispose()

        If CTEClaveActual <> CtaMaestra Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", CtaMaestra)
            CreditoDisp = dt.Rows(0)("Disponible")
            LimiteCredito = dt.Rows(0)("LimiteCredito")
            DiasCredito = dt.Rows(0)("DiasCredito")
            SaldoCte = dt.Rows(0)("Saldo")
            dt.Dispose()
        End If

        Dim AccesoCorrecto As Boolean = Autorizado

        If AccesoCorrecto = False Then

            Dim Abortar As Boolean = False
            If NIP = "" Then
                Do
                    Dim b As New FrmConfirmaDatos
                    b.CodigoPostal = codigoPostal
                    b.TipoTel = tipoTel1
                    b.Genero = Genero
                    b.FecNacimiento = fechaNacimiento
                    b.CTEClave = CTEClaveActual
                    b.Telefono = Tel1
                    b.Correo = eMail
                    b.ShowDialog()
                    If b.DialogResult = DialogResult.OK Then
                        If Tel1 <> b.Telefono OrElse eMail <> b.Correo OrElse NIP <> b.NIP Then
                            ModPOS.Ejecuta("st_act_datos_afiliado", "@CTEClave", sCTEClave, "@NIP", b.NIP, "@Tel", b.Telefono, "@Mail", b.Correo, "@Pass", "Duxst4r.", "@fechaNacimiento", b.FecNacimiento, "@Genero", b.Genero, "@tipoTel1", b.TipoTel, "@CodigoPostal", b.CodigoPostal)
                            NIP = b.NIP
                            AccesoCorrecto = True
                        End If
                    Else
                        Abortar = True
                    End If
                    b.Dispose()
                Loop Until NIP <> "" OrElse Abortar = True

                If AccesoCorrecto = False Then

                    Dim msg As New FrmMsgTouch
                    msg.TxtTiulo = "INFORMACIÓN"
                    msg.TxtMsg = "El registro de NIP es obligatorio. Vuelva a Ingresar"
                    msg.btnCancel.Visible = False
                    msg.btnOK.Text = "OK"
                    msg.ShowDialog()
                    If msg.DialogResult = DialogResult.OK Then
                    End If

                    Return False
                End If

            Else
                ' Solicita Pin 
                Dim b As New FrmSolicitaNIP
                b.Imagen = Logo2
                b.CTEClave = CTEClaveActual
                b.WindowState = FormWindowState.Maximized
                b.ShowDialog()
                If b.DialogResult = DialogResult.OK Then
                    AccesoCorrecto = b.Acceso
                Else
                    Abortar = True
                End If
                b.Dispose()

                If AccesoCorrecto = False Then
                    If Abortar = False Then

                        Dim msg As New FrmMsgTouch
                        msg.TxtTiulo = "ERROR"
                        msg.TxtMsg = "Acceso Denegado, favor de contactar a un asesor"
                        msg.btnCancel.Visible = False
                        msg.btnOK.Text = "OK"
                        msg.ShowDialog()
                        If msg.DialogResult = DialogResult.OK Then
                        End If

                    End If
                    Return False
                End If

            End If

        End If

        If AccesoCorrecto = True Then
            LblCliente.Text = NumeroAfiliado & "  " & CTENombreActual & " " & NivelDesc

            'Tendra que recuperar la venta abierta si esta en el mismo punto de venta y cliente 

            VentaAbierta = False

            Dim dtVenta As DataTable = Recupera_Tabla("sp_recupera_ventaopen", "@PDVClave", "", "@CTEClave", CTEClaveActual)
            If dtVenta.Rows.Count > 0 Then
                With Me
                    .VentaAbierta = True
                    .VENClave = dtVenta.Rows(0)("VENClave")
                    .sFolio = dtVenta.Rows(0)("Folio")
                    .AtiendeClave = dtVenta.Rows(0)("Cajero")
                    .ReferenciaUsr = dtVenta.Rows(0)("Referencia")
                    .AtiendeNombre = dtVenta.Rows(0)("NombreUsuario")
                    .SaldoVenta = dtVenta.Rows(0)("Saldo")
                    .TotalVenta = dtVenta.Rows(0)("Total")
                    .TipoDocumento = dtVenta.Rows(0)("Tipo")
                    .EstadoDocumento = dtVenta.Rows(0)("Estado")
                    .AlmacenOpen = IIf(dtVenta.Rows(0)("ALMClave").GetType.Name = "DBNull", .ALMClave, dtVenta.Rows(0)("ALMClave"))
                End With
                dtVenta.Dispose()


                recuperaVentaOpen(VENClave, sFolio, CTEClaveActual, CTENombreActual, AtiendeClave, ReferenciaUsr, AtiendeNombre, SaldoVenta, TotalVenta, TipoDocumento, EstadoDocumento, LimiteCredito, DiasCredito, SaldoCte, AlmacenOpen)

            Else


                ' Recupera pedidos en espera
                dtVenta = ModPOS.Recupera_Tabla("sp_recupera_ventawait", "@PDVClave", PDVClave, "@CTEClave", CTEClaveActual)
                If dtVenta.Rows.Count > 0 Then

                    If dtVenta.Rows.Count > 1 Then

                        Dim a As New FrmConsultaTouch
                        a.GridConsultaGen.Font = New Font("Arial", 17.25!)
                        a.Text = "Mis Pedidos en esta Sucursal"
                        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_consulta_mispedidos", "@SUCClave", SUCClave, "@CTEClave", CTEClaveActual)
                        a.GridConsultaGen.RootTable.Columns("Piezas").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                        a.GridConsultaGen.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                        a.GridConsultaGen.RootTable.Columns("Total").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
                        a.GridConsultaGen.RootTable.Columns("Total").TotalFormatString = "c"

                        a.GridConsultaGen.RootTable.Columns("VENClave").Visible = False
                        a.GridConsultaGen.GroupByBoxVisible = False

                        a.GridConsultaGen.FilterMode = Janus.Windows.GridEX.FilterMode.None
                        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
                        fc = New Janus.Windows.GridEX.GridEXFormatCondition(a.GridConsultaGen.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "Abierto")
                        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
                        a.GridConsultaGen.RootTable.FormatConditions.Add(fc)

                        a.WindowState = FormWindowState.Maximized
                        a.ShowDialog()
                        If a.DialogResult = Windows.Forms.DialogResult.OK Then
                            Dim esTemporal As Boolean = True
                            Dim EstadoNvo As Integer

                            Dim dtNvo As DataTable = ModPOS.Recupera_Tabla("sp_recupera_venta_closed", "@VENClave", a.VENClave)
                            If dtNvo.Rows.Count > 0 Then
                                EstadoNvo = dtNvo.Rows(0)("Estado")
                                esTemporal = False
                            Else
                                dtNvo = ModPOS.Recupera_Tabla("sp_recupera_vta_open", "@VENClave", a.VENClave)
                                EstadoNvo = dtNvo.Rows(0)("Estado")
                                esTemporal = True
                            End If

                            If esTemporal = True AndAlso (EstadoNvo = 1 OrElse EstadoNvo = 6) Then
                                Dim sALMClave As String
                                If dtNvo.Rows(0)("ALMClave") = "" Then
                                    sALMClave = AlmacenSurtido
                                Else
                                    sALMClave = dtNvo.Rows(0)("ALMClave")
                                End If
                                recuperaVentaOpen(a.VENClave, dtNvo.Rows(0)("Folio"), CTEClaveActual, CTENombreActual, AtiendeClave, ReferenciaUsr, AtiendeNombre, dtNvo.Rows(0)("Saldo"), dtNvo.Rows(0)("Total"), dtNvo.Rows(0)("Tipo"), dtNvo.Rows(0)("Estado"), LimiteCredito, DiasCredito, SaldoCte, sALMClave)
                                VentaAbierta = True
                            Else
                                Dim msg As New FrmMsgTouch
                                msg.TxtTiulo = "INFORMACIÓN"
                                msg.TxtMsg = "Solo se pueden recuperar documentos Abiertos o En Espera"
                                msg.btnCancel.Visible = False
                                msg.btnOK.Text = "OK"
                                msg.ShowDialog()
                                If msg.DialogResult = DialogResult.OK Then
                                End If

                            End If
                        End If
                        a.Dispose()

                    Else
                        If dtVenta.Rows(0)("ALMClave").GetType.Name = "DBNull" Then
                            AlmacenSurtido = ALMClave
                        Else
                            AlmacenSurtido = dtVenta.Rows(0)("ALMClave")
                        End If
                        recuperaVentaOpen(dtVenta.Rows(0)("VENClave"), dtVenta.Rows(0)("Folio"), dtVenta.Rows(0)("Cliente"), dtVenta.Rows(0)("RazonSocial"), dtVenta.Rows(0)("Cajero"), dtVenta.Rows(0)("Referencia"), dtVenta.Rows(0)("NombreUsuario"), dtVenta.Rows(0)("Saldo"), dtVenta.Rows(0)("Total"), dtVenta.Rows(0)("Tipo"), dtVenta.Rows(0)("Estado"), dtVenta.Rows(0)("LimiteCredito"), dtVenta.Rows(0)("DiasCredito"), dtVenta.Rows(0)("SaldoCliente"), AlmacenSurtido)
                        VentaAbierta = True
                    End If
                End If
                dtVenta.Dispose()
            End If

            If VentaAbierta = False Then
                If LimiteCredito > 0 AndAlso DiasCredito > 0 Then
                    VentaCredito()
                Else
                    VentaContado()
                End If
            End If
        End If

        Return AccesoCorrecto

    End Function

    'Private Sub ItemEspera_Click(sender As Object, e As EventArgs)
    '    If VentaCerrada = True Then
    '        Dim a As New FrmConsulta
    '        a.Intro = False
    '        a.Campo = "VENClave"
    '        a.Campo2 = "PDVClave"
    '        a.AutoSizeForm = False
    '        a.BtnPicking.Visible = True
    '        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_recupera_venta_wait", "@PDVClave", PDVClave)
    '        a.GridConsultaGen.RootTable.Columns("VENClave").Visible = False
    '        a.GridConsultaGen.RootTable.Columns("Fecha").Width = 60
    '        a.GridConsultaGen.RootTable.Columns("Clave").Width = 70
    '        a.GridConsultaGen.RootTable.Columns("RazonSocial").Width = 220
    '        a.GridConsultaGen.RootTable.Columns("Folio").Width = 50
    '        a.GridConsultaGen.RootTable.Columns("PDV").Width = 50
    '        a.GridConsultaGen.RootTable.Columns("PDV").Width = 80
    '        a.GridConsultaGen.RootTable.Columns("PDVClave").Visible = False
    '        a.GridConsultaGen.ScrollBars = Janus.Windows.GridEX.ScrollBars.Horizontal
    '        a.ShowDialog()
    '        If a.DialogResult = DialogResult.OK Then
    '            If a.ID <> "" Then
    '                Select Case MessageBox.Show("¿Esta seguro de importar el documento seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '                    Case DialogResult.Yes

    '                        Dim dt As DataTable

    '                        dt = ModPOS.Recupera_Tabla("st_valida_wait", "@VENClave", a.ID, "@PDVClave", a.ID2)

    '                        If dt.Rows.Count > 0 Then
    '                            ModPOS.Ejecuta("st_importa_wait", "@VENClave", a.ID, "@PDVClave", PDVClave, "@Usuario", ModPOS.UsuarioActual)



    '                            dt = ModPOS.Recupera_Tabla("st_venta_wait", "@VENClave", a.ID)
    '                            recuperaVentaOpen(dt.Rows(0)("VENClave"), dt.Rows(0)("Folio"), dt.Rows(0)("Cliente"), dt.Rows(0)("RazonSocial"), dt.Rows(0)("Cajero"), dt.Rows(0)("Referencia"), dt.Rows(0)("NombreUsuario"), dt.Rows(0)("Saldo"), dt.Rows(0)("Total"), dt.Rows(0)("Tipo"), dt.Rows(0)("Estado"), dt.Rows(0)("LimiteCredito"), dt.Rows(0)("DiasCredito"), dt.Rows(0)("SaldoCliente"), dt.Rows(0)("ALMClave"))
    '                        Else
    '                            MessageBox.Show("El documento seleccionado ya fue importado por otro usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        End If
    '                End Select
    '            End If
    '        End If
    '        a.Dispose()
    '    Else
    '        Beep()
    '        MessageBox.Show("No es posible Importar una venta en espera debido a que la venta actual no ha sido Cerrada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    End If
    'End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If Not VentaCerrada Then
            EsperaPedido()

        End If

        LblCliente.Text = ""
        AccesoAutorizado = False

        While AccesoAutorizado = False
            Dim b As New FrmObtieneAfiliado
            b.Imagen = Logo2
            b.SUCClave = SUCClave
            b.MaskCte = MaskCte
            b.WindowState = FormWindowState.Maximized
            b.BringToFront()
            b.ShowDialog()
            If b.DialogResult = DialogResult.OK Then
                If b.CTEClave = "111111111" Then
                    CerrarSesion = True
                    Me.Close()
                    Exit Sub
                End If
                AccesoAutorizado = cambiaCliente(b.CTEClave)
            Else
                MessageBox.Show("No es posible iniciar debido a que no se ha especificado al cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            b.Dispose()
        End While



    End Sub

    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        If Not VentaCerrada Then
            If GridDetalle.GetValue("IdKIT").GetType.Name = "DBNull" OrElse GridDetalle.GetValue("IdKIT") = "" Then
                If TotalArticulos > 0 AndAlso Not GridDetalle.GetValue("DVEClave") Is Nothing Then
                    leeCodigoBarras(GridDetalle.GetValue("centroSuministro"), GridDetalle.GetValue("Cantidad"), GridDetalle.GetValue("Clave"), False, False, True, True, False, GridDetalle.GetValue("DVEClave"), "", 0, True)
                Else
                    MsgBox("El documento no contiene productos", MsgBoxStyle.Information, "Información")
                End If
            Else
                MsgBox("El Producto Seleccionado pertenece a un Paquete el cual no es editable", MsgBoxStyle.Information, "Información")
            End If

        End If

    End Sub

    Private Sub BtnNegados_Click(sender As Object, e As EventArgs) Handles BtnNegados.Click
        Dim a As New FrmConsultaNegados
        a.Padre = "Touch"
        a.ALMClave = AlmacenSurtido
        a.TipoVenta = 1
        a.VentaCerrada = VentaCerrada
        a.numMostrador = 0
        a.TouchCK = True
        a.CTEClave = CTEClaveActual
        a.WindowState = FormWindowState.Maximized
        a.ShowDialog()
        a.Dispose()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", CTEClaveActual)
        Dim Tel1 As String = dt.Rows(0)("Tel1")
        Dim eMail As String = dt.Rows(0)("Email")
        Dim NIP As String = IIf(dt.Rows(0)("Password").GetType.Name = "DBNull", "", dt.Rows(0)("Password"))
        Dim fechaNacimiento As Date = IIf(dt.Rows(0)("fechaNacimiento").GetType.Name = "DBNull", Today.Date, dt.Rows(0)("fechaNacimiento"))
        Dim Genero As Integer = IIf(dt.Rows(0)("Genero").GetType.Name = "DBNull", 1, dt.Rows(0)("Genero"))
        Dim tipoTel1 As Integer = IIf(dt.Rows(0)("tipoTel1").GetType.Name = "DBNull", 1, dt.Rows(0)("tipoTel1"))
        Dim codigoPostal As String = IIf(dt.Rows(0)("codigoPostal").GetType.Name = "DBNull", "", dt.Rows(0)("codigoPostal"))

        dt.Dispose()

        Dim b As New FrmConfirmaDatos
        b.CodigoPostal = codigoPostal
        b.TipoTel = tipoTel1
        b.Genero = Genero
        b.FecNacimiento = fechaNacimiento
        b.CTEClave = CTEClaveActual
        b.Telefono = Tel1
        b.Correo = eMail
        b.ShowDialog()
        If b.DialogResult = DialogResult.OK Then
            If Tel1 <> b.Telefono OrElse eMail <> b.Correo OrElse NIP <> b.NIP Then
                ModPOS.Ejecuta("st_act_datos_afiliado", "@CTEClave", CTEClaveActual, "@NIP", b.NIP, "@Tel", b.Telefono, "@Mail", b.Correo, "@Pass", "Duxst4r.", "@fechaNacimiento", b.FecNacimiento, "@Genero", b.Genero, "@tipoTel1", b.TipoTel, "@CodigoPostal", b.CodigoPostal)
            End If
        End If
        b.Dispose()

    End Sub

    Private Sub btnModelo_Click(sender As Object, e As EventArgs) Handles btnModelo.Click
        Dim a As New FrmTecladoNum
        a.OcultarSignos = True
        a.Text = "Modelo"
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            AddModelo(CStr(a.Cantidad))
        End If
    End Sub

    Private Sub btnCatalogo_Click(sender As Object, e As EventArgs) Handles btnCatalogo.Click

        If VentaCerrada = False Then

            Dim sCliente As String

            If SincronizaCte = 1 AndAlso MaskCte = 1 Then
                sCliente = CTEClaveActual
            Else
                If ClienteSAP <> "" AndAlso CTEClaveActual <> ClienteSAP Then
                    sCliente = ClienteSAP
                Else
                    sCliente = CTEClaveActual
                End If
            End If

            'Si es el primer articulo, recupera la lista de precio del cliente actual
            If TotalArticulos = 0 Then
                Dim dtCliente As DataTable
                dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", sCliente, "@TipoCanal", TipoCanal)
                ListaPrecio = dtCliente.Rows(0)("PREClave")
                TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                dtCliente.Dispose()
            End If
            'Busca y recupera los datos del producto

            Dim dtPreventa As DataTable = ModPOS.Recupera_Tabla("st_recupera_preventa", "@SUCClave", SUCClave, "@CTEClave", CTEClaveActual, "@PREClave", ListaPrecio)

            If dtPreventa.Rows.Count > 0 Then
                Dim a As New FrmAgregaPreventa
                a.Padre = "Touch"
                a.url_imagen = Me.url_imagen
                a.VENClave = VENClave
                a.TipoCambio = TipoCambio
                a.CTEClave = CTEClaveActual
                a.SUCClave = SUCClave
                a.TImpuesto = TImpuesto
                a.dtPreventa = dtPreventa
                a.WindowState = FormWindowState.Maximized
                a.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnMisPedidos_Click(sender As Object, e As EventArgs) Handles btnMisPedidos.Click

        Dim a As New FrmConsultaTouch
        a.GridConsultaGen.Font = New Font("Arial", 17.25!)
        a.Text = "Mis Pedidos en esta Sucursal"
        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_consulta_mispedidos", "@SUCClave", SUCClave, "@CTEClave", CTEClaveActual)
        a.GridConsultaGen.RootTable.Columns("Piezas").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        a.GridConsultaGen.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        a.GridConsultaGen.RootTable.Columns("Total").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        a.GridConsultaGen.RootTable.Columns("Total").TotalFormatString = "c"

        a.GridConsultaGen.RootTable.Columns("VENClave").Visible = False
       
        a.GridConsultaGen.GroupByBoxVisible = False

        a.GridConsultaGen.FilterMode = Janus.Windows.GridEX.FilterMode.None
        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(a.GridConsultaGen.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "Abierto")
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        a.GridConsultaGen.RootTable.FormatConditions.Add(fc)

        a.WindowState = FormWindowState.Maximized
        a.ShowDialog()
        If a.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim esTemporal As Boolean = True
            Dim EstadoNvo As Integer

            Dim dtNvo As DataTable = ModPOS.Recupera_Tabla("sp_recupera_venta_closed", "@VENClave", a.VENClave)
            If dtNvo.Rows.Count > 0 Then
                EstadoNvo = dtNvo.Rows(0)("Estado")
                esTemporal = False
            Else
                dtNvo = ModPOS.Recupera_Tabla("sp_recupera_vta_open", "@VENClave", a.VENClave)
                EstadoNvo = dtNvo.Rows(0)("Estado")
                esTemporal = True
            End If


            If esTemporal = True AndAlso (EstadoNvo = 1 OrElse EstadoNvo = 6) Then

                If VentaAbierta = True Then
                    Dim dt As DataTable

                    dt = ModPOS.Recupera_Tabla("sp_recupera_venta_closed", "@VENClave", VENClave)
                    If dt.Rows.Count > 0 Then
                        EstadoDocumento = dt.Rows(0)("Estado")
                        esTemporal = False
                    Else
                        dt = ModPOS.Recupera_Tabla("sp_recupera_vta_open", "@VENClave", VENClave)
                        EstadoDocumento = dt.Rows(0)("Estado")
                        esTemporal = True
                    End If


                    If EstadoDocumento = 1 Then
                        If esTemporal = True Then
                            ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", EstadoDocumento, "@ALMClave", AlmacenSurtido, "@Folio", LblFolio.Text, "@MONClave", Moneda, "@TipoCambio", TipoCambio, "@TipoImpuesto", TImpuesto)

                            Dim dtDet As DataTable = ModPOS.Recupera_Tabla("sp_detalle_open", "@VENClave", VENClave)
                            'Valida si hay  producto en el pedido actual
                            If dtDet.Rows.Count > 0 Then
                                ModPOS.Ejecuta("sp_venta_wait", "@VENClave", VENClave)
                            End If

                        End If
                    End If
                End If


                Dim sALMClave As String
                If dtNvo.Rows(0)("ALMClave") = "" Then
                    sALMClave = AlmacenSurtido
                Else
                    sALMClave = dtNvo.Rows(0)("ALMClave")
                End If
                recuperaVentaOpen(a.VENClave, dtNvo.Rows(0)("Folio"), CTEClaveActual, CTENombreActual, AtiendeClave, ReferenciaUsr, AtiendeNombre, dtNvo.Rows(0)("Saldo"), dtNvo.Rows(0)("Total"), dtNvo.Rows(0)("Tipo"), dtNvo.Rows(0)("Estado"), LimiteCredito, DiasCredito, SaldoCte, sALMClave)
                VentaAbierta = True

            Else
                Dim msg As New FrmMsgTouch
                msg.TxtTiulo = "INFORMACIÓN"
                msg.TxtMsg = "Solo se pueden recuperar documentos Abiertos o En Espera"
                msg.btnCancel.Visible = False
                msg.btnOK.Text = "OK"
                msg.ShowDialog()
                If msg.DialogResult = DialogResult.OK Then
                End If
            End If
        End If
        a.Dispose()
    End Sub

   
End Class
