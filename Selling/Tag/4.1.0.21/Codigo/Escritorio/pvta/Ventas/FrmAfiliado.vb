Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Collections
Imports System.IO.Ports

Public Class FrmAfiliado
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
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
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtProducto As System.Windows.Forms.TextBox
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
    Friend WithEvents picKeyboard As System.Windows.Forms.PictureBox
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
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMesa As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BtnModificar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAfiliado))
        Dim GridDetalle_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblCantidadPuntos = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.picKeyboard = New System.Windows.Forms.PictureBox()
        Me.LblTipoCambio = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblAhorro = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblFolio = New System.Windows.Forms.Label()
        Me.LblFechaHora = New System.Windows.Forms.Label()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.TxtProducto = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
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
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CtxCliente = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ItemEditarCte = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemNuevoCte = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.SpdetalleopenBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SellingDataSet = New Selling.SellingDataSet()
        Me.Sp_detalle_openTableAdapter = New Selling.SellingDataSetTableAdapters.sp_detalle_openTableAdapter()
        Me.BtnModificar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMesa = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.CtxCliente.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SpdetalleopenBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SellingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LblCantidadPuntos)
        Me.Panel1.Location = New System.Drawing.Point(974, 299)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(240, 40)
        Me.Panel1.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gold
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(8, 112)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 64)
        Me.Panel2.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(8, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 40)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "CANTIDAD PRODUCTOS"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(14, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 24)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "PUNTOS"
        '
        'LblCantidadPuntos
        '
        Me.LblCantidadPuntos.BackColor = System.Drawing.Color.Transparent
        Me.LblCantidadPuntos.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidadPuntos.ForeColor = System.Drawing.Color.Black
        Me.LblCantidadPuntos.Location = New System.Drawing.Point(112, 2)
        Me.LblCantidadPuntos.Name = "LblCantidadPuntos"
        Me.LblCantidadPuntos.Size = New System.Drawing.Size(120, 32)
        Me.LblCantidadPuntos.TabIndex = 10
        Me.LblCantidadPuntos.Text = "14"
        Me.LblCantidadPuntos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.LblTotal)
        Me.Panel3.Controls.Add(Me.picKeyboard)
        Me.Panel3.Controls.Add(Me.LblTipoCambio)
        Me.Panel3.Location = New System.Drawing.Point(975, 399)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(240, 137)
        Me.Panel3.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
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
        Me.LblTotal.ForeColor = System.Drawing.Color.Black
        Me.LblTotal.Location = New System.Drawing.Point(4, 36)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(230, 40)
        Me.LblTotal.TabIndex = 8
        Me.LblTotal.Text = "$353.45 M.N"
        Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picKeyboard
        '
        Me.picKeyboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picKeyboard.BackColor = System.Drawing.Color.Transparent
        Me.picKeyboard.Image = Global.Selling.My.Resources.Resources._1403657593_519640_141_Keyboard
        Me.picKeyboard.Location = New System.Drawing.Point(3, 248)
        Me.picKeyboard.Name = "picKeyboard"
        Me.picKeyboard.Size = New System.Drawing.Size(42, 35)
        Me.picKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picKeyboard.TabIndex = 49
        Me.picKeyboard.TabStop = False
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTipoCambio.BackColor = System.Drawing.Color.Transparent
        Me.LblTipoCambio.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipoCambio.ForeColor = System.Drawing.Color.Black
        Me.LblTipoCambio.Location = New System.Drawing.Point(2, 102)
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
        Me.Panel4.Location = New System.Drawing.Point(974, 345)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(240, 48)
        Me.Panel4.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(14, 4)
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
        Me.LblAhorro.Location = New System.Drawing.Point(96, 4)
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
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.LblFolio)
        Me.Panel5.Location = New System.Drawing.Point(974, 2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(240, 57)
        Me.Panel5.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.IndianRed
        Me.Label8.Location = New System.Drawing.Point(14, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 23)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "PEDIDO"
        '
        'LblFolio
        '
        Me.LblFolio.BackColor = System.Drawing.Color.Transparent
        Me.LblFolio.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFolio.ForeColor = System.Drawing.Color.Black
        Me.LblFolio.Location = New System.Drawing.Point(2, 24)
        Me.LblFolio.Name = "LblFolio"
        Me.LblFolio.Size = New System.Drawing.Size(236, 29)
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
        Me.LblFechaHora.Location = New System.Drawing.Point(686, 71)
        Me.LblFechaHora.Name = "LblFechaHora"
        Me.LblFechaHora.Size = New System.Drawing.Size(282, 17)
        Me.LblFechaHora.TabIndex = 11
        Me.LblFechaHora.Text = "Lunes, 31 Marzo"
        Me.LblFechaHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.IndianRed
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
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.IndianRed
        Me.Label2.Location = New System.Drawing.Point(5, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 17)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "AFILIADO:"
        '
        'LblCliente
        '
        Me.LblCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCliente.BackColor = System.Drawing.Color.Transparent
        Me.LblCliente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCliente.ForeColor = System.Drawing.Color.Black
        Me.LblCliente.Location = New System.Drawing.Point(99, 71)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(581, 17)
        Me.LblCliente.TabIndex = 15
        Me.LblCliente.Text = "JUAN PEREZ"
        '
        'TxtProducto
        '
        Me.TxtProducto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtProducto.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProducto.Location = New System.Drawing.Point(16, 50)
        Me.TxtProducto.Name = "TxtProducto"
        Me.TxtProducto.Size = New System.Drawing.Size(208, 29)
        Me.TxtProducto.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(14, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(114, 16)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "MODELO"
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.LblCantidadArticulos)
        Me.Panel6.Location = New System.Drawing.Point(975, 244)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(240, 49)
        Me.Panel6.TabIndex = 37
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
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
        Me.LblCantidadArticulos.ForeColor = System.Drawing.Color.Black
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
        Me.BtnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCerrar.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Icon = CType(resources.GetObject("BtnCerrar.Icon"), System.Drawing.Icon)
        Me.BtnCerrar.ImageSize = New System.Drawing.Size(18, 18)
        Me.BtnCerrar.Location = New System.Drawing.Point(978, 545)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
        Me.BtnCerrar.Office2007CustomColor = System.Drawing.Color.Green
        Me.BtnCerrar.Size = New System.Drawing.Size(234, 60)
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
        Me.BtnNegados.Location = New System.Drawing.Point(861, 99)
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
        Me.btnQuitarProducto.Location = New System.Drawing.Point(239, 98)
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
        Me.btnBorrarTodo.Location = New System.Drawing.Point(123, 98)
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
        Me.Panel8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel8.Controls.Add(Me.Label11)
        Me.Panel8.Controls.Add(Me.Label10)
        Me.Panel8.Controls.Add(Me.Label12)
        Me.Panel8.Controls.Add(Me.TxtProducto)
        Me.Panel8.Location = New System.Drawing.Point(974, 65)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(241, 107)
        Me.Panel8.TabIndex = 55
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.IndianRed
        Me.Label11.Location = New System.Drawing.Point(20, 87)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(211, 19)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Escribe el Modelo y presiona el botón [Enter]"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.IndianRed
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
        Me.GridDetalle.DataSource = Me.SpdetalleopenBindingSource
        GridDetalle_DesignTimeLayout.LayoutString = resources.GetString("GridDetalle_DesignTimeLayout.LayoutString")
        Me.GridDetalle.DesignTimeLayout = GridDetalle_DesignTimeLayout
        Me.GridDetalle.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.GroupByBoxVisible = False
        Me.GridDetalle.Location = New System.Drawing.Point(4, 164)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Silver
        Me.GridDetalle.Office2007CustomColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(969, 448)
        Me.GridDetalle.TabIndex = 56
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'SpdetalleopenBindingSource
        '
        Me.SpdetalleopenBindingSource.DataMember = "sp_detalle_open"
        Me.SpdetalleopenBindingSource.DataSource = Me.SellingDataSet
        '
        'SellingDataSet
        '
        Me.SellingDataSet.DataSetName = "SellingDataSet"
        Me.SellingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Sp_detalle_openTableAdapter
        '
        Me.Sp_detalle_openTableAdapter.ClearBeforeFill = True
        '
        'BtnModificar
        '
        Me.BtnModificar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnModificar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnModificar.Icon = CType(resources.GetObject("BtnModificar.Icon"), System.Drawing.Icon)
        Me.BtnModificar.Location = New System.Drawing.Point(355, 98)
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
        'Panel7
        '
        Me.Panel7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel7.Controls.Add(Me.PictureBox1)
        Me.Panel7.Controls.Add(Me.Label7)
        Me.Panel7.Controls.Add(Me.txtMesa)
        Me.Panel7.Controls.Add(Me.Label1)
        Me.Panel7.Location = New System.Drawing.Point(975, 178)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(240, 60)
        Me.Panel7.TabIndex = 82
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(136, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox1.TabIndex = 93
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(13, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 16)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "MESA"
        '
        'txtMesa
        '
        Me.txtMesa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMesa.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMesa.Location = New System.Drawing.Point(80, 23)
        Me.txtMesa.Name = "txtMesa"
        Me.txtMesa.Size = New System.Drawing.Size(140, 29)
        Me.txtMesa.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.IndianRed
        Me.Label1.Location = New System.Drawing.Point(14, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 19)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "ENTREGAR EN "
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'FrmAfiliado
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1217, 613)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.BtnModificar)
        Me.Controls.Add(Me.GridDetalle)
        Me.Controls.Add(Me.LblSubTitulo)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.BtnCerrar)
        Me.Controls.Add(Me.BtnNegados)
        Me.Controls.Add(Me.btnQuitarProducto)
        Me.Controls.Add(Me.btnBorrarTodo)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.LblCliente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.LblFechaHora)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmAfiliado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Punto de Venta"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.CtxCliente.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SpdetalleopenBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SellingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Padre As String

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
    End Enum

    Private Enum TipoMov
        Entrada = 1
        Salida = 2
    End Enum

    Public VentaAbierta As Boolean = False

    Public Remoto As Integer = 0
    Public BloquearPrecio As Integer = 0
    Public ImprimirRemoto As Integer = 0
    Public sFrase As String
    Public MaxCaracteres As Integer
    Public NoLineas As Integer
    Public ActivarCotizacion As Boolean = True
    Public Picking As Boolean
    Public SurtidoRF As Boolean
    Public MostradorRF As Boolean

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
    Public AtiendeClave As String ' Identificador del Cajero
    Public PorcMaxDesc As Double 'Porcentaje Maximo descuento del vendedor
    Public USRCambiaPrecio As Boolean 'Si se le permite cambiar precios al vendedor
    Public AtiendeNombre As String ' Nombre del Cajero
    Private ClienteSAP As String

    Public CTEClaveInicial As String 'Identificador de Cliente Inicial
    Public CTENombreInicial As String 'Nombre de Cliente Inicial

    Public CTEClaveActual As String 'Identificador de Cliente Actual
    Public DCTEClave As String
    Public CTENombreActual As String 'Nombre de Cliente Actual
    Public NumeroAfiliado As String

    Public Folio As Integer = -1
    Public VentaNueva As Boolean = True
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
    Public DescuentoCliente As Integer
    Public PorcDescCliente As Double
    Public TotalRecibido As Double = 0.0
    Public TotalCambio As Double = 0.0
    'Public FormaPago As Integer
    Public TipoDesCte As Integer
    Public DESClave As String
    Public TipoDocumento As Integer
    Public EstadoDocumento As Integer
    Public sFolio As String = "-"

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
    Private MonedaRef As String
    Private TipoCambio As Double

    Private mySerialPort As New SerialPort
    Private sAlmacen As String = ""
    Private url_imagen As String
    Private Periodo, Mes As Integer
    Private bCierreApertura As Boolean = False
    Private dtPedidoDetalle As DataTable
    Private bComplemento As Boolean = False
    Private iDesglosarPrecio As Integer = 0
    Private UltimoCodigo As String = ""

    Private FolioTmp As Integer = 0
    Private bMessage As Boolean = True
    Private alerta(0) As PictureBox
    Private reloj As parpadea
    Private UBCClave As String
    Private FormatoPedido As String

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

            LblFolio.Text = Referencia & "-" & CStr(Periodo) & CStr(Mes) & "-" & CStr(Folio)
        Else

            Dim dtventa As DataTable

            dtventa = ModPOS.Recupera_Tabla("st_recupera_foliotmp", "@PDVClave", PDVClave, "@Prefijo", "T-" & Referencia & "-" & CStr(Today.DayOfYear) & "-")
            If dtventa.Rows.Count > 0 Then
                If dtventa.Rows(0)("Folio").GetType.Name <> "DBNull" Then
                    FolioTmp = dtventa.Rows(0)("Folio")
                End If
            End If
            dtventa.Dispose()


            FolioTmp += 1
            LblFolio.Text = "T-" & Referencia & "-" & CStr(Today.DayOfYear) & "-" & CStr(FolioTmp)
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
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    Me.AtiendeNombre = a.AtiendeNombre
                    Me.AtiendeClave = a.AtiendeClave

                Else
                    MessageBox.Show("No es posible crear una nueva venta debido a que no se ha sido registrado un Vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                a.Dispose()

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
            "@Usuario", ModPOS.UsuarioActual)




            btnQuitarProducto.Enabled = True
            btnBorrarTodo.Enabled = True

            BtnCerrar.Enabled = True
            TxtProducto.Enabled = True

            VentaCerrada = False
            GeneraMovSalida = True
            VentaNueva = True

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
                If TotalVenta > 0 Then
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                End If
            End If

            If sGTIN <> "" Then
                AgregaGTIN(sGTIN, False, False)
                sGTIN = ""
            End If



        Else
            Beep()
            MessageBox.Show("No es posible crear una nueva venta debido a que la venta actual no ha sido Cerrada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        TxtProducto.Focus()
    End Sub

    Private Sub VentaCredito()
        If VentaCerrada Then

            If AlmacenSurtido = "" OrElse AlmacenSurtido Is Nothing Then
                Beep()
                MessageBox.Show("No es posible crear una nueva venta debido a que no se ha especificado el Almacen para surtido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim dt As DataTable



            If Moneda <> MonedaCambio Then
                dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
                MonedaRef = dt.Rows(0)("Referencia")
                TipoCambio = dt.Rows(0)("TipoCambio")
                dt.Dispose()
            Else
                LblTipoCambio.Text = ""
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
            "@Usuario", ModPOS.UsuarioActual)


            btnQuitarProducto.Enabled = True
            btnBorrarTodo.Enabled = True

            BtnCerrar.Enabled = True
            TxtProducto.Enabled = True

            VentaCerrada = False
            GeneraMovSalida = True
            VentaNueva = True

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
                If TotalVenta > 0 Then
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                End If
            End If






        Else
            Beep()
            MessageBox.Show("No es posible crear una nueva venta debido a que la venta actual no ha sido Cerrada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        TxtProducto.Focus()
    End Sub

    Private Sub FrmAfiliado_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not VentaCerrada Then
            Beep()
            Select Case MessageBox.Show("El Documento actual no ha sido Cerrado, ¿Desea Cancelarlo?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.No
                    e.Cancel = True
                Case DialogResult.Yes
                    CancelaPedido()
                    ModPOS.Afiliado = Nothing
                    ModPOS.Ejecuta("sp_actualiza_caja", "@PDVClave", PDVClave, "@Fase", 0)
            End Select
        Else
            ModPOS.Afiliado = Nothing
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
                    MessageBox.Show("La cantidad registrada del producto " & CStr(dtVentaDetalle.Rows(i)("Clave")) & " excede la cantidad disponible (" & CStr(Disponible) & "), por lo que no es posible cambiar el tipo de documento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Function convierteDocumento(ByVal NuevoDocumento As Integer) As Boolean

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
            VentaCerrada = True
            modificaStatus(TipoDocumento, EstadoDocumento)
            If TipoDocumento <> 2 Then
                MessageBox.Show("No es posible modificar el Tipo de Documento, ya que No se encuentra Abierto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dt.Dispose()
                Return False
            End If
        End If
        dt.Dispose()

        Select Case NuevoDocumento
            Case 1

                If VentaCerrada = False Then

                    If TipoDocumento = 2 Then
                        If ValidaInventario = True Then
                            If validaExistencia() = False Then
                                Return False
                            End If

                            If VerificaExistencia(1, VENClave, AlmacenSurtido) = False Then
                                Return False
                            End If

                        End If
                        actualizaExistencia(TipoMov.Entrada)
                    End If



                    TipoDocumento = 1

                    ModPOS.Ejecuta("sp_actualiza_venta_open", _
                    "@VENClave", VENClave, _
                    "@Cliente", CTEClaveActual, _
                    "@Tipo", TipoDocumento)



                    modificaStatus(TipoDocumento, EstadoDocumento)
                    'cambiaStatus("VTA. CONTADO (ABIERTA)", Status.Abierto)

                ElseIf TipoDocumento = 2 Then

                    ConvierteCotizacion(1)

                    'If ModPOS.ValidaEnvio(Picking, VENClave, CTEClaveActual, VentaCerrada, ALMClave) = True Then
                    '    TipoDocumento = 1

                    '    aplicarPromociones(SUCClave)

                    '    ModPOS.Ejecuta("sp_actualiza_venta_closed", _
                    '    "@VENClave", VENClave, _
                    '    "@Cliente", CTEClaveActual, _
                    '    "@Tipo", TipoDocumento, _
                    '    "@Cajero", AtiendeClave, _
                    '    "@CAJClave", CAJClave, _
                    '    "@Usuario", ModPOS.UsuarioActual)

                    '    ModPOS.Ejecuta("sp_act_fecha_vta", "@VENClave", VENClave)


                    '    If Picking = False Then
                    '        ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", CTEClaveActual, "@Importe", TotalVenta)

                    '        ModPOS.GeneraMovInv(2, 1, 1, VENClave, ALMClave, LblFolio.Text, Nothing)
                    '        ModPOS.ActualizaExistAlm(2, 1, VENClave, ALMClave)
                    '        ModPOS.ActualizaExistUbc(2, 1, VENClave, ALMClave)
                    '    Else
                    '        EstadoDocumento = iEstado.Picking
                    '        ModPOS.Ejecuta("sp_actualiza_edo_vta", "@VENClave", VENClave, "@Estado", 7)

                    '        ModPOS.calculaRecoleccion(1, VENClave, ALMClave, "")

                    '    End If

                    '    modificaStatus(TipoDocumento, EstadoDocumento)
                    '    'cambiaStatus("VTA. CONTADO (CERRADA)", Status.Cerrado)


                    'End If

                End If

            Case 2
                If VentaCerrada = False Then
                    actualizaExistencia(TipoMov.Salida)

                    TipoDocumento = 2


                    ModPOS.Ejecuta("sp_actualiza_venta_open", _
                    "@VENClave", VENClave, _
                    "@Cliente", CTEClaveActual, _
                    "@Tipo", TipoDocumento)




                    modificaStatus(TipoDocumento, EstadoDocumento)
                    'cambiaStatus("COTIZACIÓN (ABIERTA)", Status.Abierto)

                End If
            Case 3

                If VentaCerrada = False Then

                    If TipoDocumento = 2 Then
                        If ValidaInventario = True Then
                            If validaExistencia() = False Then
                                Return False
                            End If

                            If VerificaExistencia(1, VENClave, AlmacenSurtido) = False Then
                                Return False
                            End If
                        End If
                    End If

                    If CTEClaveActual = CTEClaveInicial Then
                        Dim b As New FrmSolicitaCliente
                        b.ClienteInicial = CTEClaveInicial
                        b.ValidaCredito = True
                        b.CreditoGeneral = CreditoGeneral
                        b.ShowDialog()
                        If b.DialogResult = DialogResult.OK Then
                            CTEClaveActual = b.ClienteClave
                            CTENombreActual = b.ClienteNombre
                            LblCliente.Text = CTENombreActual
                            NotaCreditos = b.Nota
                            If NotaCreditos <> "" Then
                                ModPOS.Ejecuta("sp_actualiza_notavta", "@VENClave", VENClave, "@Nota", NotaCreditos)
                            End If
                        Else
                            MessageBox.Show("No es posible crear una venta a crédito debido a que no se ha especificado al cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return False
                        End If
                        b.Dispose()
                    Else
                        Dim CreditoDisp As Double
                        Dim LimiteCred As Double

                        dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", Me.CTEClaveActual)
                        CreditoDisp = dt.Rows(0)("Disponible")
                        LimiteCred = dt.Rows(0)("LimiteCredito")
                        dt.Dispose()


                        'Validar Limite de Credito


                        'If iValidaCredito = 0 Then
                        '    Return False
                        'ElseIf iValidaCredito = -1 Then
                        '    recuperaDatosCredito(CTEClaveActual)
                        '    If CreditoDisponible < TotalVenta Then
                        '        MessageBox.Show("El limite de crédito disponible es de " & Format(CStr(ModPOS.Redondear(CreditoDisponible, 2)), "Currency") & ", la venta actual lo sobrepasa por " & Format(CStr(ModPOS.Redondear(TotalVenta - CreditoDisponible, 2)), "Currency"), "Información", MessageBoxButtons.OK)
                        '        Return False
                        '    End If
                        'End If



                    End If

                    If TipoDocumento = 2 Then
                        actualizaExistencia(TipoMov.Entrada)
                    End If



                    '  If VentaCerrada = False Then

                    TipoDocumento = 3

                    ModPOS.Ejecuta("sp_actualiza_venta_open", _
                    "@VENClave", VENClave, _
                    "@Cliente", CTEClaveActual, _
                    "@Tipo", TipoDocumento)

                    modificaStatus(TipoDocumento, EstadoDocumento)
                    'cambiaStatus("VTA. CRÉDITO (ABIERTA)", Status.Abierto)
                ElseIf TipoDocumento = 2 Then

                    ConvierteCotizacion(3)
                    'If ModPOS.ValidaEnvio(Picking, VENClave, CTEClaveActual, VentaCerrada, ALMClave) = True Then
                    '    TipoDocumento = 3

                    '    aplicarPromociones(SUCClave)

                    '    ModPOS.Ejecuta("sp_actualiza_venta_closed", _
                    '                        "@VENClave", VENClave, _
                    '                        "@Cliente", CTEClaveActual, _
                    '                        "@Tipo", TipoDocumento, _
                    '                        "@Cajero", AtiendeClave, _
                    '                        "@CAJClave", CAJClave, _
                    '                        "@Usuario", ModPOS.UsuarioActual)

                    '    ModPOS.Ejecuta("sp_act_fecha_vta", "@VENClave", VENClave)




                    '    If Picking = False Then
                    '        ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", CTEClaveActual, "@Importe", TotalVenta)
                    '        ModPOS.GeneraMovInv(2, 1, 1, VENClave, ALMClave, LblFolio.Text, Nothing)
                    '        ModPOS.ActualizaExistAlm(2, 1, VENClave, ALMClave)
                    '        ModPOS.ActualizaExistUbc(2, 1, VENClave, ALMClave)
                    '    Else

                    '        EstadoDocumento = iEstado.Picking
                    '        ModPOS.Ejecuta("sp_actualiza_edo_vta", "@VENClave", VENClave, "@Estado", 7)

                    '        ModPOS.calculaRecoleccion(1, VENClave, ALMClave, "")

                    '    End If

                    '    modificaStatus(TipoDocumento, EstadoDocumento)
                    '    'cambiaStatus("VTA. CRÉDITO (CERRADA)", Status.Cerrado)


                    'End If
                End If
            Case 4
                If VentaCerrada = False Then

                    If TipoDocumento = 2 Then
                        If ValidaInventario = True Then
                            If validaExistencia() = False Then
                                Return False
                            End If
                        End If
                    End If


                    If CTEClaveActual = CTEClaveInicial Then
                        Dim b As New FrmSolicitaCliente
                        b.ClienteInicial = CTEClaveInicial
                        b.ShowDialog()
                        If b.DialogResult = DialogResult.OK Then
                            CTEClaveActual = b.ClienteClave
                            CTENombreActual = b.ClienteNombre
                            LblCliente.Text = CTENombreActual
                        Else
                            MessageBox.Show("No es posible crear el apartado debido a que no se ha especificado al cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return False
                        End If
                        b.Dispose()

                    End If



                    If TipoDocumento = 2 Then
                        actualizaExistencia(TipoMov.Entrada)
                    End If


                    ' If VentaCerrada = False Then
                    TipoDocumento = 4

                    ModPOS.Ejecuta("sp_actualiza_venta_open", _
                    "@VENClave", VENClave, _
                    "@Cliente", CTEClaveActual, _
                    "@Tipo", TipoDocumento)

                    modificaStatus(TipoDocumento, EstadoDocumento)
                    'cambiaStatus("APARTADO (ABIERTO)", Status.Abierto)
                ElseIf TipoDocumento = 2 Then
                    ConvierteCotizacion(4)
                    'If ModPOS.ValidaEnvio(Picking, VENClave, CTEClaveActual, VentaCerrada, ALMClave) = True Then
                    '    TipoDocumento = 4



                    '    aplicarPromociones(SUCClave)

                    '    ModPOS.Ejecuta("sp_actualiza_venta_closed", _
                    '                        "@VENClave", VENClave, _
                    '                        "@Cliente", CTEClaveActual, _
                    '                        "@Tipo", TipoDocumento, _
                    '                        "@Cajero", AtiendeClave, _
                    '                        "@CAJClave", CAJClave, _
                    '                        "@Usuario", ModPOS.UsuarioActual)

                    '    ModPOS.Ejecuta("sp_act_fecha_vta", "@VENClave", VENClave)



                    '    If Picking = False Then
                    '        ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", CTEClaveActual, "@Importe", TotalVenta)
                    '        ModPOS.GeneraMovInv(2, 1, 1, VENClave, ALMClave, LblFolio.Text, Nothing)
                    '        ModPOS.ActualizaExistAlm(2, 1, VENClave, ALMClave)
                    '        ModPOS.ActualizaExistUbc(2, 1, VENClave, ALMClave)
                    '    Else
                    '        EstadoDocumento = iEstado.Picking
                    '        ModPOS.Ejecuta("sp_actualiza_edo_vta", "@VENClave", VENClave, "@Estado", 7)

                    '        ModPOS.calculaRecoleccion(1, VENClave, ALMClave, "")

                    '    End If

                    '    modificaStatus(TipoDocumento, EstadoDocumento)
                    '    'cambiaStatus("APARTADO (CERRADO)", Status.Cerrado)
                    'End If
                End If
        End Select

        Return True
    End Function

    Private Sub FrmTPDV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        alerta(0) = Me.PictureBox1
        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_obtener_usuario", "@USRClave", ModPOS.UsuarioActual)

        AtiendeClave = dt.Rows(0)("USRClave")
        AtiendeNombre = dt.Rows(0)("Nombre")
        USRCambiaPrecio = dt.Rows(0)("CambiaPrecio")
        PorcMaxDesc = dt.Rows(0)("PorcMaxDesc")

        dt.Dispose()

        LblFolio.Text = sFolio
        LblCantidadArticulos.Text = "0"
        LblCantidadPuntos.Text = "0"
        LblAhorro.Text = "$0.00"
        LblTotal.Text = "$0.00"



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
                End Select
            Next
        End With
        dt.Dispose()



        SUCClave = SucursalSurtido

        AlmacenSurtido = ALMClave
        sAlmacen = AlmacenClave & " - " & AlmacenNombre

        bLoad = True



        dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)
        Picking = IIf(dt.Rows(0)("Picking").GetType.Name = "DBNull", False, dt.Rows(0)("Picking"))
        SurtidoRF = IIf(dt.Rows(0)("SurtidoRF").GetType.Name = "DBNull", False, dt.Rows(0)("SurtidoRF"))
        MostradorRF = IIf(dt.Rows(0)("SurtidoRFMostrador").GetType.Name = "DBNull", False, dt.Rows(0)("SurtidoRFMostrador"))




        If Moneda <> MonedaCambio Then

            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
            MonedaRef = dt.Rows(0)("Referencia")
            TipoCambio = dt.Rows(0)("TipoCambio")
            dt.Dispose()
        Else
            LblTipoCambio.Text = ""
        End If




        LblTitulo.Text = PuntodeVenta



        If Padre = "Nuevo" Then
            Dim dtVenta As DataTable = Recupera_Tabla("sp_recupera_ventaopen", "@PDVClave", PDVClave)
            If dtVenta.Rows.Count > 0 Then
                With Me
                    .VentaAbierta = True
                    .VENClave = dtVenta.Rows(0)("VENClave")
                    .sFolio = dtVenta.Rows(0)("Folio")
                    .CTEClaveActual = dtVenta.Rows(0)("Cliente")
                    .CTENombreActual = dtVenta.Rows(0)("RazonSocial")
                    .AtiendeClave = dtVenta.Rows(0)("Cajero")
                    .AtiendeNombre = dtVenta.Rows(0)("NombreUsuario")
                    .SaldoVenta = dtVenta.Rows(0)("Saldo")
                    .TotalVenta = dtVenta.Rows(0)("Total")
                    .TipoDocumento = dtVenta.Rows(0)("Tipo")
                    .EstadoDocumento = dtVenta.Rows(0)("Estado")

                    .AlmacenOpen = IIf(dtVenta.Rows(0)("ALMClave").GetType.Name = "DBNull", .ALMClave, dtVenta.Rows(0)("ALMClave"))
                End With
                dtVenta.Dispose()

            End If
        Else
            Dim dtVenta As DataTable = ModPOS.Recupera_Tabla("sp_recupera_ventawait", "@PDVClave", PDVClave, "@VENClave", VENClave)
            If dtVenta.Rows.Count > 0 Then
                With Me
                    .sFolio = dtVenta.Rows(0)("Folio")
                    .CTEClaveActual = dtVenta.Rows(0)("Cliente")
                    .CTENombreActual = dtVenta.Rows(0)("RazonSocial")
                    .AtiendeClave = dtVenta.Rows(0)("Cajero")
                    .AtiendeNombre = dtVenta.Rows(0)("NombreUsuario")
                    .SaldoVenta = dtVenta.Rows(0)("Saldo")
                    .TotalVenta = dtVenta.Rows(0)("Total")
                    .TipoDocumento = dtVenta.Rows(0)("Tipo")
                    .EstadoDocumento = dtVenta.Rows(0)("Estado")

                    .AlmacenOpen = IIf(dtVenta.Rows(0)("ALMClave").GetType.Name = "DBNull", .ALMClave, dtVenta.Rows(0)("ALMClave"))
                End With
            End If
            dtVenta.Dispose()

        End If

        LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
        LblCantidadArticulos.Text = CStr(TotalArticulos)
        LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
        LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
        Me.LblFechaHora.Text = DateTime.Today.ToLongDateString & " " & DateTime.Now.ToShortTimeString 'ToString("MMMM dd, yyyy")



        If Moneda <> MonedaCambio Then
            If TotalVenta > 0 Then
                LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
            Else
                LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
            End If
        End If

        If VentaAbierta = True Then
            '  recuperaVentaOpen(VENClave, sFolio, CTEClaveActual, CTENombreActual, AtiendeClave, AtiendeNombre, SaldoVenta, TotalVenta, TipoDocumento, EstadoDocumento, txtLimite.Text, txtDias.Text, txtSaldo.Text, AlmacenOpen)
        ElseIf VentaNueva Then

            Dim b As New FrmObtieneAfiliado
            b.ShowDialog()
            If b.DialogResult = DialogResult.OK Then
                If b.CTEClave = "12345" Then
                    Me.Close()
                    Exit Sub
                End If
                cambiaCliente(b.CTEClave)
            Else
                MessageBox.Show("No es posible iniciar debido a que no se ha especificado al cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            b.Dispose()


        End If








        Clock.Start()

    End Sub

    Private Sub Clock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock.Tick
        Me.LblFechaHora.Text = DateTime.Today.ToLongDateString & " " & DateTime.Now.ToShortTimeString 'ToString("MMMM dd, yyyy")
    End Sub

    Public Sub recalcularPartidas()
        With Me

            dtPedidoDetalle.Clear()

            Dim dtventadetalle As DataTable = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", .VENClave)
            If Not dtventadetalle Is Nothing Then
                Dim i As Integer = 0
                .TotalArticulos = dtventadetalle.Rows.Count

                For i = 0 To .TotalArticulos - 1
                    Dim sDVEClave As String = dtventadetalle.Rows(i)("DVEClave")
                    Dim sPROClave As String = dtventadetalle.Rows(i)("PROClave")
                    Dim sGTIN As String = dtventadetalle.Rows(i)("Clave")
                    Dim sNombre As String = dtventadetalle.Rows(i)("Nombre")
                    Dim dCantidad As Double = dtventadetalle.Rows(i)("Cantidad")
                    Dim dPrecioBruto As Double = dtventadetalle.Rows(i)("PrecioBruto")
                    Dim dImpuestoPorc As Double = dtventadetalle.Rows(i)("ImpuestoPorc")
                    Dim dImpuestoImp As Double = dtventadetalle.Rows(i)("ImpuestoImp")
                    Dim dDescuentoImp As Double = dtventadetalle.Rows(i)("DescuentoImp")
                    Dim dPuntosImp As Double = dtventadetalle.Rows(i)("PuntosImp")
                    Dim dTotal As Double = dtventadetalle.Rows(i)("TotalPartida")

                    Dim iGrupoMaterial As Integer = IIf(dtventadetalle.Rows(0)("GrupoMaterial").GetType.FullName = "System.DBNull", 0, dtventadetalle.Rows(0)("GrupoMaterial"))
                    Dim iSector As Integer = IIf(dtventadetalle.Rows(0)("Sector").GetType.FullName = "System.DBNull", 0, dtventadetalle.Rows(0)("Sector"))
                    Dim iPartida As Integer = IIf(dtventadetalle.Rows(0)("Partida").GetType.FullName = "System.DBNull", i + 1, dtventadetalle.Rows(0)("Partida"))




                    ' Dim dImporteNeto As Double = TruncateToDecimal((dPrecioBruto - dDescuentoImp) * (1 + dImpuestoPorc), 2)


                    Dim iKgLt As Integer = IIf(dtventadetalle.Rows(0)("KgLt").GetType.FullName = "System.DBNull", 0, dtventadetalle.Rows(0)("KgLt"))
                    Dim dUndKilo As Double = IIf(dtventadetalle.Rows(0)("UndKilo").GetType.FullName = "System.DBNull", 0, dtventadetalle.Rows(0)("UndKilo"))

                    ' AGREGAR PRODUCTO A LISTA
                    .AgregarProducto(sDVEClave, sPROClave, sGTIN, sNombre, dCantidad, dPrecioBruto, dImpuestoPorc, dDescuentoImp, iKgLt, dUndKilo, iGrupoMaterial, iSector, iPartida)
                    .TotalAhorro += dDescuentoImp
                    .TotalPuntos += (dPuntosImp * dCantidad)
                    .TotalVenta += (dTotal)
                Next
                dtventadetalle.Dispose()

                If .SaldoVenta = -1 Then
                    .SaldoVenta = .TotalVenta
                End If

                LblCantidadPuntos.Text = ModPOS.Redondear(.TotalPuntos, 2).ToString("#,##0.00")
                LblCantidadArticulos.Text = CStr(.TotalArticulos)
                LblAhorro.Text = Format(CStr(ModPOS.Redondear(.TotalAhorro, 2)), "Currency")
                LblTotal.Text = Format(CStr(ModPOS.Redondear(.TotalVenta, 2)), "Currency")
            End If
        End With

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



            Case 7
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



    Private Function leeCodigoBarras(ByVal Cantidad As Integer, ByVal Codigo As String, ByVal Suma As Boolean, ByVal Busca As Boolean, ByVal bCopy As Boolean, ByVal bRecalcular As Boolean, ByVal bValidaOpen As Boolean, ByVal bShortCut As Boolean) As Boolean
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
                    VentaCerrada = True
                    modificaStatus(TipoDocumento, EstadoDocumento)
                    MessageBox.Show("No se puede agregar producto ya que el Documento actual no se encuentra Abierto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dt.Dispose()
                    Return False
                End If
                dt.Dispose()
            End If



            'Valida que el campo producto no se encuentre vacio
            If Not Codigo = vbNullString Then
                'Si el campo cantidad esta vacio lo cambia a 1 por defecto

                Dim sCliente As String

                If ClienteSAP <> "" AndAlso CTEClaveActual <> ClienteSAP Then
                    sCliente = ClienteSAP
                Else
                    sCliente = CTEClaveActual
                End If

                'Si es el primer articulo, recupera la lista de precio del cliente actual
                If TotalArticulos = 0 Then
                    Dim dtCliente As DataTable
                    dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", sCliente)
                    ListaPrecio = dtCliente.Rows(0)("PREClave")
                    TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                    dtCliente.Dispose()
                End If
                'Busca y recupera los datos del producto
                Dim BacktoSearh As Boolean
                dt = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 1, "@Busca", Codigo, "@SUCClave", SUCClave, "@PREClave", ListaPrecio, "@CTEClave", sCliente, "@Cantidad", Cantidad, "@Char", cReplace)

                BacktoSearh = AgregaPartida(dt, Suma, Busca, bCopy, bRecalcular, bShortCut)


                If Not dt Is Nothing Then
                    dt.Dispose()
                End If

                Return BacktoSearh

            End If
        End If
    End Function

    Private Sub AddModelo(ByVal Modelo As String)
        If Modelo <> "" Then
            Dim dt As DataTable = ModPOS.Recupera_Tabla("st_valida_modelo", "@COMClave", ModPOS.CompanyActual, "@Modelo", Modelo)
            If dt.Rows.Count > 0 Then
                Dim a As New FrmTallaColor
                a.sModelo = dt.Rows(0)("Modelo")
                a.ALMClave = ALMClave
                a.ShowDialog()
                If a.DialogResult = Windows.Forms.DialogResult.OK Then
                    AgregaGTIN(a.Clave, False, True)
                End If
            Else
                MessageBox.Show("El Modelo no es valido o no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Debe de capturar el Modelo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub TxtProducto_Click(sender As Object, e As EventArgs) Handles TxtProducto.Click
        Dim a As New FrmTecladoNum
        a.Text = "Modelo"
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.TxtProducto.Text = CStr(a.Cantidad)
            AddModelo(TxtProducto.Text.Trim)
        End If
    End Sub

    Private Sub TxtProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProducto.KeyPress
        If Asc(e.KeyChar) = 13 Then
            AddModelo(TxtProducto.Text.Trim)
        End If
    End Sub

    Public Function AgregaGTIN(ByVal sGTIN As String, ByVal Busca As Boolean, ByVal bValidaOpen As Boolean) As Boolean
        Dim backToSearch As Boolean
        backToSearch = leeCodigoBarras(1, sGTIN, True, Busca, False, True, bValidaOpen, False)
        Return backToSearch
    End Function

    Private Function validaBloqueado(ByVal sALMClave As String, ByVal dCantidad As Double, ByVal sPROClave As String, ByVal sClave As String) As Boolean

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

        If Cantidad > 0 Then

            MessageBox.Show("El producto: " & sClave & ", no cuenta con existencia disponible o se encuentra bloqueada. Quita la cantidad de " & CStr(Cantidad) & " pieza(s) de este pedido para continuar.")
            Return False

        End If

        Return True
    End Function

    Public Function AgregaPartida(ByVal dtProducto As DataTable, ByVal Suma As Boolean, ByVal Busca As Boolean, ByVal bCopy As Boolean, ByVal bRecalculaInventario As Boolean, ByVal bShortCut As Boolean) As Boolean
        Dim dt As DataTable

        If Not dtProducto Is Nothing Then
            Dim YaExiste As Boolean = False
            Dim DVEClave As String = ""
            Dim sAutoriza As String = Nothing
            Dim sSUCClave As String = dtProducto.Rows(0)("SUCClave")
            Dim sPROClave As String = dtProducto.Rows(0)("PROClave")
            Dim sClave As String = dtProducto.Rows(0)("Clave")
            Dim sNombre As String = dtProducto.Rows(0)("Nombre")
            Dim dCosto As Decimal = dtProducto.Rows(0)("Costo")
            Dim dCantidad As Decimal = dtProducto.Rows(0)("Cantidad")
            Dim dApartar As Decimal = dCantidad
            Dim dPrecioUnitario As Decimal = dtProducto.Rows(0)("PrecioBruto")
            Dim dDescPorc As Decimal = dtProducto.Rows(0)("DescPorc")
            Dim dDescGeneralPor As Decimal = dtProducto.Rows(0)("DescGeneral")

            Dim iTProducto As Integer = dtProducto.Rows(0)("TProducto")
            Dim iSeguimiento As Integer = dtProducto.Rows(0)("Seguimiento")
            Dim iDiasGarantia As Integer = dtProducto.Rows(0)("DiasGarantia")
            Dim iNumDecimales As Integer = dtProducto.Rows(0)("Num_Decimales")

            Dim dGeneralNeto As Decimal = TruncateToDecimal(dtProducto.Rows(0)("PrecioNeto"), 6)
            Dim dMinimoNeto As Decimal = TruncateToDecimal(dtProducto.Rows(0)("MinimoNeto"), 6)

            Dim iKgLt As Integer = IIf(dtProducto.Rows(0)("KgLt").GetType.FullName = "System.DBNull", 0, dtProducto.Rows(0)("KgLt"))
            Dim dPeso As Decimal = IIf(dtProducto.Rows(0)("Peso").GetType.FullName = "System.DBNull", 0, dtProducto.Rows(0)("Peso"))

            dtProducto.Dispose()

            If dCantidad <= 0 Then
                TxtProducto.Text = ""
                Cantidad = 1
                MessageBox.Show("El producto " & sClave & " no permite decimales o la cantidad debe ser mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If


            Dim bValidaMinimo As Boolean = IIf(dGeneralNeto = dMinimoNeto, False, True)

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

            Dim iGrupoMaterial As Integer = 0
            Dim iSector As Integer = 0
            Dim iPartida As Integer
            Dim dVolumen As Decimal = 0
            Dim dVolumenImp As Decimal = 0
            Dim PorcImpProducto As Decimal = ModPOS.RecuperaImpuesto(sSUCClave, sPROClave, TImpuesto)

            If dPrecioUnitario = 0 Then
                MessageBox.Show("El producto " & sClave & " no cuenta con precio definido en la lista de precios actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

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

            Dim dOriginal As Decimal


            Dim foundRows() As System.Data.DataRow
            foundRows = dtPedidoDetalle.Select(" PROClave = '" & sPROClave & "' and Baja = 0")

            If foundRows.Length = 1 Then
                YaExiste = True
                DVEClave = foundRows(0)("DVEClave")

                dOriginal = foundRows(0)("Cantidad")

                If Suma = True Then
                    dCantidad += foundRows(0)("Cantidad")
                    UnidadesKilo += foundRows(0)("UndKilo")
                ElseIf bShortCut = False Then
                    dCantidad = foundRows(0)("Cantidad")
                    UnidadesKilo = foundRows(0)("UndKilo")
                End If

                dPrecioUnitario = foundRows(0)("Precio")
                ' dImporteNeto = foundRows(0)("Subtotal") / dCantidad

                If foundRows(0)("Desc") > 0 Then
                    Dim dtDescuento As DataTable = ModPOS.SiExisteRecupera("sp_descuento_partida_open", "@DVEClave", DVEClave)
                    If Not dtDescuento Is Nothing Then
                        'Descuento General
                        foundRows = dtDescuento.Select(" Tipo = 1 ")
                        If foundRows.Length = 1 Then
                            dDescGeneralPor = foundRows(0)("DescuentoPorc") * 100
                            '   dDescGeneralImp = foundRows(0)("DescuentoImp")
                        End If

                        'Descuento Volumen
                        foundRows = dtDescuento.Select(" Tipo = 2")
                        If foundRows.Length = 1 Then
                            dVolumen = foundRows(0)("DescuentoPorc") * 100
                            '    dVolumenImp = foundRows(0)("DescuentoImp")
                        End If


                        'Descuento Gerencial
                        foundRows = dtDescuento.Select(" Tipo = 3 ")
                        If foundRows.Length = 1 Then
                            dDescPorc = foundRows(0)("DescuentoPorc") * 100
                            '     dDescuentoImp = foundRows(0)("DescuentoImp")
                        End If
                        dtDescuento.Dispose()
                    End If
                End If
            Else
                YaExiste = False
            End If


          
            If YaExiste = False Then
                dOriginal = 0
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

            If bShortCut = False Then

                If ModificaPrecioServicio AndAlso iTProducto >= 4 Then
                    Dim a As New FrmAddProducto
                    a.VENClave = VENClave
                    a.NumDecimal = iNumDecimales
                    a.ModificaPrecioServicio = Me.ModificaPrecioServicio
                    a.iTProducto = iTProducto
                    a.CambiaPrecio = USRCambiaPrecio
                    a.PorcMaxDesc = PorcMaxDesc
                    a.CTEClave = CTEClaveActual
                    a.GrupoMaterial = iGrupoMaterial
                    a.Sector = iSector
                    a.PDVClave = PDVClave
                    a.TImpuesto = TImpuesto
                    a.PREClave = ListaPrecio
                    a.PROClave = sPROClave
                    a.sTipoDesc = sTipoDesc
                    a.NombreCliente = CTENombreActual
                    a.Clave = sClave
                    a.Nombre = sNombre
                    a.Costo = dCosto
                    a.UnidadesKilo = a.UnidadesKilo
                    a.dPrecioUnitario = dPrecioUnitario
                    a.dCantidad = dCantidad
                    a.dBase = dBase
                    a.DescGeneral = dDescGeneralPor
                    a.DescGeneralImporte = dDescGeneralImp
                    a.dVolumen = dVolumen
                    a.dVolumenImp = dVolumenImp
                    a.DescImp = dDescuentoImp
                    a.PorcDesc = dDescPorc
                    a.FactorImpuesto = PorcImpProducto
                    a.dImpuestoimp = dImpuestoImp
                    a.ImporteNeto = dImporteNeto
                    a.MinimoNeto = dMinimoNeto
                    a.bValidaMinimo = bValidaMinimo
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        sAutoriza = a.sAutoriza
                        UnidadesKilo = a.UnidadesKilo
                        sTipoDesc = a.sTipoDesc
                        dPrecioUnitario = a.dPrecioUnitario
                        dCantidad = a.dCantidad
                        dBase = a.dBase
                        dDescGeneralImp = a.DescGeneralImporte
                        dVolumen = a.dVolumen
                        dVolumenImp = a.dVolumenImp
                        dDescPorc = a.PorcDesc
                        dDescuentoImp = a.DescImp 'a.ImporteNeto * a.PorcDesc
                        dImpuestoImp = a.dImpuestoimp
                        dImporteNeto = a.ImporteNeto

                        a.Dispose()
                        TxtProducto.Focus()
                    Else
                        a.Dispose()
                        TxtProducto.Text = ""
                        Cantidad = 1
                        sAutoriza = ""
                        TxtProducto.Focus()
                        dPeso = 0
                        Return Busca
                    End If
                ElseIf CambiaPrecio AndAlso bCopy = False Then
                    'Si Cambia Precio = True 
                    Dim a As New FrmAgregaModelo
                    a.SUCClave = SucursalSurtido
                    a.ALMClave = AlmacenSurtido
                    a.PDVClave = PDVClave
                    a.VENClave = VENClave
                    a.CambiaPrecio = USRCambiaPrecio
                    a.PorcMaxDesc = PorcMaxDesc
                    a.ModificaPrecioServicio = Me.ModificaPrecioServicio
                    a.BloquearPrecio = BloquearPrecio
                    a.TImpuesto = TImpuesto
                    a.CTEClave = CTEClaveActual
                    a.NombreCliente = CTENombreActual
                    a.PREClave = ListaPrecio
                    a.PROClave = sPROClave
                    a.GrupoMaterial = iGrupoMaterial
                    a.Sector = iSector
                    a.NumDecimal = iNumDecimales
                    a.url_imagen = Me.url_imagen
                    a.iTProducto = iTProducto
                    a.KgLt = iKgLt
                    a.Peso = dPeso
                    a.sTipoDesc = sTipoDesc
                    a.Clave = sClave
                    a.Nombre = sNombre
                    a.Costo = dCosto
                    a.dPrecioUnitario = dPrecioUnitario
                    a.dCantidad = dCantidad
                    a.dBase = dBase
                    a.DescGeneral = dDescGeneralPor
                    a.DescGeneralImporte = dDescGeneralImp
                    a.dVolumen = dVolumen
                    a.dVolumenImp = dVolumenImp
                    a.PorcDesc = dDescPorc
                    a.DescImp = dDescuentoImp
                    a.FactorImpuesto = PorcImpProducto
                    a.dImpuestoimp = dImpuestoImp
                    a.ImporteNeto = dImporteNeto
                    a.MinimoNeto = dMinimoNeto
                    a.bValidaMinimo = bValidaMinimo
                    a.UnidadesKilo = UnidadesKilo
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        sAutoriza = a.sAutoriza
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
                        TxtProducto.Focus()
                    Else
                        a.Dispose()
                        TxtProducto.Text = ""
                        Cantidad = 1
                        sAutoriza = ""
                        TxtProducto.Focus()
                        dPeso = 0

                        Return Busca
                    End If
                End If

            End If

            'SI VALIDA INVENTARIO

            Dim bRecalculaVolumen As Boolean = False

            If bRecalculaInventario = True Then
                If ValidaInventario = True AndAlso TipoDocumento <> 2 AndAlso Not (iTProducto = 3 OrElse iTProducto = 4) Then

                    Dim Disponible, Existencia, Apartado, Bloqueado As Double
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

                    If (dCantidad - dOriginal) > Disponible AndAlso Not (iTProducto = 3 OrElse iTProducto = 4) Then

                        Dim dCantNegada As Decimal = (dCantidad - dOriginal) - Disponible
                        Dim dImporteNegado As Decimal = Math.Round(dPrecioUnitario * dCantNegada, 2)
                        Dim dGeneralNegado As Decimal = Math.Round(dImporteNegado * (dDescGeneralPor / 100), 2)
                        Dim dVolumenNegado As Decimal = Math.Round((dImporteNegado - dGeneralNegado) * (dVolumen / 100), 2)
                        Dim dDescuentoNegado As Decimal = Math.Round((dImporteNegado - dGeneralNegado - dVolumenNegado) * (dDescPorc / 100), 2)
                        Dim dImpuestoNegado As Decimal = Math.Round((dImporteNegado - dGeneralNegado - dVolumenNegado - dDescuentoNegado) * PorcImpProducto, 2)

                        dDescuentoNegado += dGeneralNegado + dVolumenNegado

                        Dim bSolicitar As Boolean = False

                        If bCopy = False Then
                            Dim a As FrmSolicitaNegado = New FrmSolicitaNegado
                            a.lblExistencia.Text = "Disponible: " & CStr(Disponible)
                            a.ShowDialog()
                            If a.ShowDialog = Windows.Forms.DialogResult.OK Then
                                If a.Accion = "Negado" Then
                                    ModPOS.Ejecuta("sp_registra_negado", "@SUCClave", sSUCClave, "@CTEClave", CTEClaveActual, "@VENClave", VENClave, "@PROClave", sPROClave, "@TProducto", iTProducto, "@Costo", dCosto, "@Precio", dPrecioUnitario, "@Importe", dImporteNegado, "@Descuento", dDescuentoNegado, "Impuesto", dImpuestoNegado, "@Cantidad", dCantNegada, "@Existencia", Existencia, "@Disponible", Disponible, "@Apartado", Apartado, "@Bloqueado", Bloqueado, "@Motivo", 3, "@Solicitar", bSolicitar, "@Usuario", AtiendeClave)

                                End If
                            End If
                            'If MessageBox.Show("La cantidad solicitada del producto " & sClave & " excede la existencia disponible (" & CStr(Disponible) & "), ¿Desea registrar el Producto Negado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                            '    ''Registro de Producto Negado
                            '    'If MessageBox.Show("¿Desea Solicitar el Faltante?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            '    '    bSolicitar = True
                            '    'Else
                            '    '    bSolicitar = False
                            '    'End If


                            ' End If
                            bRecalculaVolumen = True
                        Else


                            If MessageBox.Show("La cantidad solicitada del producto " & sClave & " excede el disponible (" & CStr(Disponible) & "), ¿Desea registrar el Producto Negado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                                ModPOS.Ejecuta("sp_registra_negado", "@SUCClave", sSUCClave, "@CTEClave", CTEClaveActual, "@VENClave", VENClave, "@PROClave", sPROClave, "@TProducto", iTProducto, "@Costo", dCosto, "@Precio", dPrecioUnitario, "@Importe", dImporteNegado, "@Descuento", dDescuentoNegado, "Impuesto", dImpuestoNegado, "@Cantidad", (dCantidad - dOriginal) - Disponible, "@Existencia", Existencia, "@Disponible", Disponible, "@Apartado", Apartado, "@Bloqueado", Bloqueado, "@Motivo", 3, "@Solicitar", bSolicitar, "@Usuario", AtiendeClave)
                            End If
                            bRecalculaVolumen = True
                        End If

                        If Disponible <= 0 Then
                            Return False
                        Else
                            dCantidad = dOriginal + Disponible
                        End If
                    ElseIf Not (iTProducto = 3 OrElse iTProducto = 4) Then
                        'Valida ubicacion
                        If validaBloqueado(AlmacenSurtido, dCantidad - dOriginal, sPROClave, sClave) = False Then
                            Return False
                        End If
                    End If

                End If
            End If

            UltimoCodigo = sClave

            'Bloquea al cliente para no permitir que se modifique la lista de precios cuando ya hay productos en la venta


            If bRecalculaVolumen = True Then

               
                    dBase = Math.Round(dPrecioUnitario * dCantidad, 2)


                dDescGeneralImp = Math.Round(dBase * (dDescGeneralPor / 100), 2)

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

            If dCantidad > dOriginal Then
                Suma = True
            Else
                Suma = False
            End If

            'Actualiza apartado
            If bRecalculaInventario = True Then
                ModPOS.Ejecuta("st_act_exist_vta", _
                                "@ALMClave", ALMClave, _
                                "@PROClave", sPROClave, _
                                "@TipoDoc", TipoDocumento, _
                                "@TProducto", iTProducto, _
                                "@Cantidad", dCantidad - dOriginal, _
                                "@VENClave", VENClave)
            End If

            If YaExiste Then

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
                "@DVEClave", DVEClave, _
                "@PorcImp", PorcImpProducto, _
                "@Usuario", ModPOS.UsuarioActual, _
                "@TipoDesc", sTipoDesc, _
                "@Autoriza", sAutoriza, _
                "@Total", dImporteNeto)


                Dim dtDet As DataTable
                dtDet = ModPOS.SiExisteRecupera("sp_vent_det_open", "@DVEClave", DVEClave)
                If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
                    ModPOS.RecalculaImpuesto(dtDet, TImpuesto, sSUCClave, 0)
                    dtDet.Dispose()
                End If

            Else
                'Inserta Producto
                DVEClave = ModPOS.obtenerLlave

                If dtPedidoDetalle.Compute("MAX(Partida)", "BAJA=0").GetType.FullName = "System.DBNull" Then
                    iPartida = 10
                Else
                    iPartida = CInt(dtPedidoDetalle.Compute("MAX(Partida)", "BAJA=0")) + 10
                End If

                ModPOS.Ejecuta("sp_inserta_detalle", _
                "@DVEClave", DVEClave, _
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
                "@Autoriza", sAutoriza, _
                "@UndKilo", UnidadesKilo, _
                "@GrupoMaterial", iGrupoMaterial, _
                "@Sector", iSector, _
                "@Partida", iPartida, _
                "@TipoDesc", sTipoDesc, _
                "@Usuario", ModPOS.UsuarioActual)

                'Inserta detalle de Impuestos por partida
                ModPOS.InsertaImpuesto(DVEClave, sPROClave, (dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp), TImpuesto, sSUCClave)

                TotalArticulos += 1

            End If

            If Picking = False Then

                'SI REQUIERE SEGUIMIENTO DE SERIAL
                If iSeguimiento = 2 Then
                    Dim SerialReg As Integer = 0
                    Dim PorRegistrar As Double
                    PorRegistrar = dCantidad
                    Do
                        Dim a As New FrmSerial
                        a.DOCClave = VENClave
                        a.PROClave = sPROClave
                        a.Clave = sClave
                        a.Nombre = sNombre
                        a.Cantidad = PorRegistrar
                        a.Dias = iDiasGarantia
                        a.TipoDoc = 1
                        a.TipoMov = 2
                        a.ShowDialog()
                        SerialReg = SerialReg + a.NumSerialRegistrados
                        PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                        a.Dispose()
                    Loop Until SerialReg = dCantidad OrElse PorRegistrar = 0
                End If

                'SI REQUIERE SEGUIMIENTO DE LOTE
                If iSeguimiento = 3 Then
                    Dim LoteReg As Integer = 0
                    Dim PorRegistrar As Double
                    PorRegistrar = dCantidad
                    Do
                        Dim a As New FrmLote
                        a.DOCClave = VENClave
                        a.PROClave = sPROClave
                        a.Clave = sClave
                        a.Nombre = sNombre
                        a.CantXRegistrar = PorRegistrar
                        a.TipoDoc = 1
                        a.TipoMov = 2
                        a.ShowDialog()
                        LoteReg = LoteReg + a.NumSerialRegistrados
                        PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                        a.Dispose()
                    Loop Until LoteReg = dCantidad OrElse PorRegistrar = 0
                End If
            End If

            ' AGREGAR PRODUCTO A LISTA
            AgregarProducto(DVEClave, sPROClave, sClave, sNombre, dCantidad, dPrecioUnitario, PorcImpProducto, dDescGeneralImp + dVolumenImp + dDescuentoImp, iKgLt, UnidadesKilo, iGrupoMaterial, iSector, iPartida)

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
                            ModPOS.RecalculaImpuesto(dtDet, TImpuesto, sSUCClave, 0)
                            dtDet.Dispose()
                        End If

                    Next

                    recalcularPartidas()
                    Recalcular = False
                End If
            End If

            If Recalcular Then

                TotalAhorro = 0
                TotalVenta = 0
                If dtPedidoDetalle.Rows.Count > 0 Then
                    TotalAhorro = dtPedidoDetalle.Compute("SUM(Desc)", "Baja=0")
                    TotalVenta = dtPedidoDetalle.Compute("SUM(Total)", "Baja=0")
                End If
                'For i = 0 To dtPedidoDetalle.Rows.Count - 1
                '    If dtPedidoDetalle.Rows(i)("Baja") = 0 Then
                '        TotalAhorro += dtPedidoDetalle.Rows(i)("Desc") * dtPedidoDetalle.Rows(i)("Cantidad")
                '        TotalVenta += dtPedidoDetalle.Rows(i)("Total")
                '    End If
                'Next


                SaldoVenta = TotalVenta


                LblCantidadPuntos.Text = ModPOS.TruncateToDecimal(TotalPuntos, 2).ToString("#,##0.00")
                LblCantidadArticulos.Text = CStr(TotalArticulos)
                LblAhorro.Text = Format(CStr(ModPOS.TruncateToDecimal(TotalAhorro, 2)), "Currency")
                LblTotal.Text = Format(CStr(ModPOS.TruncateToDecimal(TotalVenta, 2)), "Currency")
            End If

            If Moneda <> MonedaCambio Then
                If TotalVenta > 0 Then
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.TruncateToDecimal(TotalVenta / TipoCambio, 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.TruncateToDecimal(TotalVenta, 2)), "Currency")
                End If
            End If


            If Agotamiento Then
                dt = ModPOS.SiExisteRecupera("sp_recupera_agotamiento", "@ALMClave", AlmacenSurtido, "@PROClave", sPROClave, "@Cantidad", dCantidad)
                If Not dt Is Nothing Then
                    MessageBox.Show(sClave & ", " & sNombre & "se ha agotado, solicitar al proveedor: " & CStr(Redondear(dCantidad, 2)), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dt.Dispose()
                End If
            End If

        Else
            Beep()
            MessageBox.Show("El Código no corresponde a un Producto Existente o Activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        TxtProducto.Text = ""
        Cantidad = 1
        Return False
    End Function


    Public Sub AgregarProducto(ByVal DVEClave As String, ByVal PROClave As String, ByVal GTIN As String, ByVal Nombre As String, ByVal Cantidad As Decimal, ByVal Precio As Decimal, ByVal ImpuestoPor As Decimal, ByVal Descuento As Decimal, ByVal kglt As Integer, ByVal UnidadesKilo As Double, ByVal GrupoMaterial As Integer, ByVal Sector As Integer, ByVal Partida As Integer)
        Dim dBase, dImpts, dTotal, DescPor As Decimal

        dBase = Math.Round(Precio * Cantidad, 2)
        dImpts = Math.Round((dBase - Descuento) * ImpuestoPor, 2)
        dTotal = dBase - Descuento + dImpts

        DescPor = (Descuento / dBase) * 100

        Dim foundRows() As System.Data.DataRow
        foundRows = dtPedidoDetalle.Select(" DVEClave = '" & DVEClave & "'")

        If foundRows.Length = 1 Then

            If kglt = 1 Then
                Nombre &= " " & CStr(UnidadesKilo) & "Unds"
            End If

            foundRows(0)("Nombre") = Nombre
            foundRows(0)("Cantidad") = Cantidad
            foundRows(0)("UndKilo") = UnidadesKilo
            foundRows(0)("Precio") = TruncateToDecimal(Precio, 2)
            foundRows(0)("Importe") = dBase
            foundRows(0)("% Desc") = TruncateToDecimal(DescPor, 2)
            foundRows(0)("Desc") = Descuento
            foundRows(0)("Impts") = dImpts
            foundRows(0)("Total") = dTotal

        Else

            Dim row1 As DataRow
            row1 = dtPedidoDetalle.NewRow()
            'declara el nombre de la fila
            row1.Item("DVEClave") = DVEClave
            row1.Item("PROClave") = PROClave
            row1.Item("Clave") = GTIN

            If kglt = 1 Then
                Nombre &= " " & CStr(UnidadesKilo) & "Unds"
            End If

            row1.Item("Nombre") = Nombre

            row1.Item("Cantidad") = Cantidad
            row1.Item("Precio") = TruncateToDecimal(Precio, 2)
            row1.Item("Importe") = dBase
            row1.Item("Desc") = Descuento
            row1.Item("% Desc") = TruncateToDecimal(DescPor, 2)
            row1.Item("Impts") = dImpts
            row1.Item("Total") = dTotal
            row1.Item("GrupoMaterial") = GrupoMaterial
            row1.Item("Sector") = Sector
            row1.Item("Partida") = Partida
            row1.Item("Baja") = 0
            row1.Item("UndKilo") = UnidadesKilo
            dtPedidoDetalle.Rows.Add(row1)
        End If




    End Sub


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

    Private Sub AplicaPromociones(ByVal Tipo As Integer, ByRef dt As DataTable, ByVal sSUCClave As String)
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

                    'ImportePromocion = Numero * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("Precio"))
                    'TotalImportePromocion += ImportePromocion
                    'TotalImporteNetoPromocion += Numero * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("PrecioNeto"))

                    If dt.Rows(i)("Promocion") > 0 Then
                        ModPOS.Ejecuta("sp_aplica_promocion", _
                                        "@PRMClave", dt.Rows(i)("PRMClave"), _
                                        "@VENTA", VENClave, _
                                        "@DVEClave", dt.Rows(i)("DVEClave"), _
                                        "@PROClave", dt.Rows(i)("PROClave"), _
                                        "@Tipo", Tipo, _
                                        "@Porcentaje", ImportePromocion / (dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")), _
                                        "@Importe", ImportePromocion / dt.Rows(i)("Cantidad"), _
                                        "@Usuario", ModPOS.UsuarioActual)

                        Dim dtDet As DataTable
                        dtDet = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)
                        If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
                            ModPOS.RecalculaImpuesto(dtDet, TImpuesto, sSUCClave, 0)
                            dtDet.Dispose()
                        End If

                    End If
                Next

                TotalAhorro += TotalImporteNetoPromocion
                TotalVenta -= TotalImporteNetoPromocion
                SaldoVenta = TotalVenta

                LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

                If Moneda <> MonedaCambio Then
                    If TotalVenta > 0 Then
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                    End If
                End If

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
                        ModPOS.Ejecuta("sp_aplica_promocion", _
                                        "@PRMClave", dt.Rows(i)("PRMClave"), _
                                        "@VENTA", VENClave, _
                                        "@DVEClave", dt.Rows(i)("DVEClave"), _
                                        "@PROClave", dt.Rows(i)("PROClave"), _
                                        "@Tipo", Tipo, _
                                        "@Porcentaje", ImportePromocion / (dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")), _
                                        "@Importe", ImportePromocion / dt.Rows(i)("Cantidad"), _
                                        "@Usuario", ModPOS.UsuarioActual)

                        Dim dtDet As DataTable
                        dtDet = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)
                        If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
                            ModPOS.RecalculaImpuesto(dtDet, TImpuesto, sSUCClave, 0)
                            dtDet.Dispose()
                        End If

                    End If
                Next

                TotalAhorro += TotalImportePromocion
                TotalVenta -= TotalImportePromocion
                SaldoVenta = TotalVenta

                LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

                If Moneda <> MonedaCambio Then
                    If TotalVenta > 0 Then
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                    End If
                End If


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

                Dim dtRegalo As DataTable = ModPOS.SiExisteRecupera("sp_recupera_regalo", "@SUCClave", sSUCClave, "@PRMClave", dt.Rows(0)("PRMClave"))

                Dim j As Integer

                Dim DVEClave As String = ""
                Dim iPartida As Integer

                For j = 0 To dtRegalo.Rows.Count - 1

                    Dim dtDetalle As DataTable = ModPOS.SiExisteRecupera("sp_recupera_detalle", "@VENTA", VENClave, "@PROClave", dtRegalo.Rows(j)("PROClave"), "@Subtotal", 0)

                    If Not dtDetalle Is Nothing Then
                        'Actualiza Cantidad de producto
                        iPartida = dtDetalle.Rows(0)("Partida")


                        ModPOS.Ejecuta("sp_actualiza_detalle", _
                        "@ALMClave", AlmacenSurtido, _
                         "@VENTA", VENClave, _
                        "@PROClave", dtRegalo.Rows(j)("PROClave"), _
                        "@TProducto", dtRegalo.Rows(j)("TProducto"), _
                        "@Cantidad", dMonto * dtRegalo.Rows(j)("Cantidad"), _
                        "@TipoDoc", TipoDocumento, _
                        "@Picking", Picking,
                        "@DVEClave", dtDetalle.Rows(0)("DVEClave"),
                        "@Usuario", ModPOS.UsuarioActual)

                        dtDetalle.Dispose()
                    Else
                        'Inserta Producto

                        iPartida = 0
                        DVEClave = ModPOS.obtenerLlave

                        ModPOS.Ejecuta("sp_inserta_detalle", _
                        "@DVEClave", DVEClave, _
                        "@VENTA", VENClave, _
                        "@PROClave", dtRegalo.Rows(j)("PROClave"), _
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
                        "@TipoDoc", TipoDocumento, _
                        "@TProducto", dtRegalo.Rows(j)("TProducto"), _
                        "@Picking", Picking, _
                        "@Partida", iPartida, _
                        "@Usuario", ModPOS.UsuarioActual)

                        TotalArticulos += 1
                        LblCantidadArticulos.Text = CStr(TotalArticulos)
                    End If




                    'SI REQUIERE SEGUIMIENTO DE SERIAL
                    If dtRegalo.Rows(j)("Seguimiento") = 2 Then
                        Dim SerialReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = dMonto * dtRegalo.Rows(j)("Promocion")
                        Do
                            Dim a As New FrmSerial
                            a.DOCClave = VENClave
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
                            a.DOCClave = VENClave
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



                    AgregarProducto(DVEClave, dtRegalo.Rows(j)("PROClave"), dtRegalo.Rows(j)("Clave"), dtRegalo.Rows(j)("Nombre"), dMonto * dtRegalo.Rows(j)("Cantidad"), 0, 0, 0, 0, 0, 0, 0, iPartida)


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
                        ModPOS.Ejecuta("sp_aplica_promocion", _
                                        "@PRMClave", dt.Rows(i)("PRMClave"), _
                                        "@VENTA", VENClave, _
                                        "@DVEClave", dt.Rows(i)("DVEClave"), _
                                        "@PROClave", dt.Rows(i)("PROClave"), _
                                        "@Tipo", Tipo, _
                                        "@Porcentaje", ImportePromocion / (dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")), _
                                        "@Importe", ImportePromocion / dt.Rows(i)("Cantidad"), _
                                        "@Usuario", ModPOS.UsuarioActual)
                    End If
                Next

                TotalPuntos += ImportePromocion

                ModPOS.Ejecuta("sp_add_puntos", "@CTEClave", CTEClaveActual, "@Cantidad", TotalPuntos)

                LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")

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
                        ModPOS.Ejecuta("sp_aplica_promocion", _
                                        "@PRMClave", dt.Rows(i)("PRMClave"), _
                                        "@VENTA", VENClave, _
                                        "@DVEClave", dt.Rows(i)("DVEClave"), _
                                        "@PROClave", dt.Rows(i)("PROClave"), _
                                        "@Tipo", Tipo, _
                                        "@Porcentaje", ImportePromocion / (dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")), _
                                        "@Importe", ImportePromocion / dt.Rows(i)("Cantidad"), _
                                        "@Usuario", ModPOS.UsuarioActual)

                        Dim dtDet As DataTable
                        dtDet = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)
                        If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
                            ModPOS.RecalculaImpuesto(dtDet, TImpuesto, sSUCClave, 0)
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

                LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

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

    Private Sub verificaPromocion(ByVal dtPromocion As DataTable, ByVal sSUCClave As String)
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
            dtPromDet = ModPOS.Recupera_Tabla("sp_recupera_detalle_promocion", "@PRMClave", dtPromocion.Rows(y)("PRMClave"), "@VENClave", VENClave)

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
                AplicaPromociones(CInt(dtPromocion.Rows(y)("Tipo")), dtAplicaPromo, sSUCClave)


            End If

            If dtPromocion.Rows(y)("Cascada") = 0 Then ' Si no aplica cascada termina 
                Exit For
            End If

        Next

        dtPromocion.Dispose()
        dtAplicaPromo.Dispose()

    End Sub

    Private Sub aplicarPromociones(ByVal sSUCClave As String)
        'Recupera promociones vigentes
        Dim dtPromocion As DataTable = ModPOS.SiExisteRecupera("sp_promocion_vigente", "CTEClave", CTEClaveActual, "@VENClave", VENClave)
        If Not dtPromocion Is Nothing AndAlso dtPromocion.Rows.Count > 0 Then
            verificaPromocion(dtPromocion, sSUCClave)
            dtPromocion.Dispose()
        End If


        'Recupera los descuentos vigentes
        'Dim dtDescCte As DataTable = ModPOS.SiExisteRecupera("sp_venta_descuento", "@Cliente", CTEClaveActual)
        'If Not dtDescCte Is Nothing Then
        'Dim i As Integer = 0

        'Dim TipoAplicacion As Integer
        'Dim ImporteInicial As Double
        'Dim ImporteFinal As Double
        'Dim GerarquiaDesc As Integer

        'For i = 0 To dtDescCte.Rows.Count - 1

        '    DESClave = dtDescCte.Rows(i)("DESClave")
        '    TipoAplicacion = dtDescCte.Rows(i)("Tipo")
        '    TipoDesCte = dtDescCte.Rows(i)("TipoAplicacion")
        '    PorcDescCliente = dtDescCte.Rows(i)("DescuentoPorc")
        '    DescuentoCliente = Math.Abs(CInt(dtDescCte.Rows(i)("Cascada")))
        '    ImporteInicial = dtDescCte.Rows(i)("ImporteInicial")
        '    ImporteFinal = dtDescCte.Rows(i)("ImporteFinal")
        '    GerarquiaDesc = dtDescCte.Rows(i)("Gerarquia")

        '    If TotalVenta >= ImporteInicial AndAlso TotalVenta <= ImporteFinal Then
        '        Select Case TipoAplicacion
        '            Case Is = 1 'Descuento

        '                Dim ImpDesCte As Double = PorcDescCliente * TotalVenta

        '                TotalAhorro += ImpDesCte
        '                TotalVenta -= ImpDesCte
        '                SaldoVenta = TotalVenta

        '                LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
        '                LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

        '                If Moneda <> MonedaCambio Then
        '                    If TotalVenta > 0 Then
        '                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
        '                    Else
        '                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
        '                    End If
        '                End If

        '                If GridView = 0 Then
        '                    LstVenta.Items.Add(FormateaCadena(True, ModPOS.Redondear(PorcDescCliente * 100, 2).ToString & "%-", 8) & "DESC. CTE." & FormateaCadena(False, "", 21) & FormateaCadena(False, Format(ModPOS.Redondear(ImpDesCte, 2).ToString, "Currency"), 12))
        '                    LstVenta.Items(LstVenta.Items.Count - 1).ForeColor = System.Drawing.Color.Red
        '                End If

        '                ModPOS.Ejecuta("sp_aplica_descte", "@VENTA", VENClave, "@Tipo", TipoAplicacion, "@DESClave", DESClave, "@DescuentoPor", PorcDescCliente, "@Usuario", ModPOS.UsuarioActual)

        '                Dim dt As DataTable
        '                dt = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)
        '                If Not dt Is Nothing AndAlso dt.Rows.Count() > 0 Then
        '                    ModPOS.RecalculaImpuesto(dt, TImpuesto, sSUCClave)
        '                    dt.Dispose()
        '                End If

        '            Case Is = 2 'Bonificación
        '                Dim Porcentaje As Double = PorcDescCliente / TotalVenta

        '                TotalAhorro += PorcDescCliente
        '                TotalVenta -= PorcDescCliente
        '                SaldoVenta = TotalVenta

        '                LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
        '                LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

        '                If Moneda <> MonedaCambio Then
        '                    If TotalVenta > 0 Then
        '                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
        '                    Else
        '                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
        '                    End If
        '                End If

        '                If GridView = 0 Then
        '                    LstVenta.Items.Add(FormateaCadena(True, ModPOS.Redondear(Porcentaje * 100, 2).ToString & "%-", 8) & "BONI. CTE." & FormateaCadena(False, "", 21) & FormateaCadena(False, Format(ModPOS.Redondear(PorcDescCliente, 2).ToString, "Currency"), 12))
        '                    LstVenta.Items(LstVenta.Items.Count - 1).ForeColor = System.Drawing.Color.Red
        '                End If

        '                ModPOS.Ejecuta("sp_aplica_descte", "@VENTA", VENClave, "@Tipo", TipoAplicacion, "@DESClave", DESClave, "@DescuentoPor", Porcentaje, "@Usuario", ModPOS.UsuarioActual)

        '                Dim dt As DataTable
        '                dt = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)
        '                If Not dt Is Nothing AndAlso dt.Rows.Count() > 0 Then
        '                    ModPOS.RecalculaImpuesto(dt, TImpuesto, sSUCClave)
        '                    dt.Dispose()
        '                End If

        '            Case Is = 3 'Puntos
        '                Dim ImpPuntos As Double = PorcDescCliente * TotalVenta

        '                TotalPuntos += ImpPuntos
        '                LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")

        '                ModPOS.Ejecuta("sp_aplica_descte", "@VENTA", VENClave, "@Tipo", TipoAplicacion, "@DESClave", DESClave, "@DescuentoPor", PorcDescCliente, "@Usuario", ModPOS.UsuarioActual)

        '                '      LstVenta.Items.Add(FormateaCadena(True, ModPOS.Redondear(PorcDescCliente * 100, 2).ToString & "%-", 8) & "PTOS. CTE." & FormateaCadena(False, "", 27) & FormateaCadena(False, Format(ModPOS.Redondear(ImpPuntos, 2).ToString, "Currency"), 12))
        '                '     LstVenta.Items(LstVenta.Items.Count - 1).ForeColor = System.Drawing.Color.Red

        '        End Select

        '        ' Si no aplica en cascada deja de aplicar descuentos
        '        If DescuentoCliente = 0 Then
        '            Exit For
        '        End If

        '    End If
        'Next
        'dtDescCte.Dispose()
        'Else
        DescuentoCliente = -1
        PorcDescCliente = 0
        TipoDesCte = 0
        DESClave = ""
        'End If


        'Si el descuento se aplica 1 sola vez por venta se elimina al cliente de dicho descuento despues de aplicarlo
        If TipoDocumento <> 2 AndAlso TipoDesCte = 1 Then
            ModPOS.Ejecuta("sp_elimina_descte", _
                           "@DESClave", DESClave, _
                           "@CTEClave", CTEClaveActual)
        End If




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
                sTexto = "PIKING"
            Case 9
                sTexto = "REMOTO"
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

    Private Function ValidaStage(ByVal Stage As String) As Boolean

        If Stage <> "" Then
            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_valida_ubicacion", "@ALMClave", ALMClave, "@Ubicacion", Stage.Trim)

            If dt.Rows.Count > 0 Then
                UBCClave = dt.Rows(0)("UBCClave")
            Else
                UBCClave = ""
                MessageBox.Show("La clave de ubicación no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            dt.Dispose()
        Else
            UBCClave = ""
            MessageBox.Show("La ubicación de Entrega de Mercancia es requerida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


        Dim i As Integer

        If UBCClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
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
                    modificaStatus(TipoDocumento, EstadoDocumento)
                    MessageBox.Show("No es posible Cerrar el docuemtno debido a que ya fue procesado anteriormente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If



                If TipoDocumento = 1 OrElse TipoDocumento = 3 Then
                    If ValidaStage(txtMesa.Text) = False Then
                        Exit Sub
                    End If

                End If

                Dim dtAuditoria As DataTable
                dtAuditoria = ModPOS.Recupera_Tabla("st_auditoria_venta", "@VENClave", VENClave)
                If dtAuditoria.Rows.Count > 0 Then
                    MessageBox.Show("El producto " & dtAuditoria.Rows(0)("Clave") & " cuenta con una inconsistencia de precio, eliminelo del pedido e intente nuevametne", "Información", MessageBoxButtons.OK)
                    Exit Sub
                End If

                If ValidaInventario = True AndAlso TipoDocumento <> 2 Then
                    If VerificaExistencia(1, VENClave, AlmacenSurtido) = False Then
                        Exit Sub
                    End If
                End If

                'Validar Limite de Credito
                If TipoDocumento = 3 Then
                    Dim iValidaCredito As Integer

                    ' iValidaCredito = ModPOS.ValidaCredido(CTEClaveActual, CDbl(txtLimite.Text), TotalVenta)

                    If iValidaCredito = 0 Then
                        Exit Sub
                    ElseIf iValidaCredito = -1 Then
                        recuperaDatosCredito(CTEClaveActual)
                        If CreditoDisponible < TotalVenta Then
                            MessageBox.Show("El limite de crédito disponible es de " & Format(CStr(ModPOS.Redondear(CreditoDisponible, 2)), "Currency") & ", la venta actual lo sobrepasa por " & Format(CStr(ModPOS.Redondear(TotalVenta - CreditoDisponible, 2)), "Currency"), "Información", MessageBoxButtons.OK)
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


                If TipoDocumento <> 2 Then
                    aplicarPromociones(SUCClave)
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
               "@Usuario", ModPOS.UsuarioActual)


                ObtenerFolio(False)

                ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", EstadoDocumento, "@ALMClave", AlmacenSurtido, "@Folio", LblFolio.Text)

                ModPOS.Ejecuta("sp_agrega_venta", "@VENClave", VENClave)

                modificaStatus(TipoDocumento, EstadoDocumento)

                If VentaNueva AndAlso (TipoDocumento <> 2) AndAlso Picking = False Then '= 3 OrElse TipoDocumento = 4)
                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", CTEClaveActual, "@Importe", TotalVenta)
                End If

                If Remoto = 0 Then
                    If Picking = False Then
                        If (TipoDocumento = 1 OrElse TipoDocumento = 3) AndAlso GeneraMovSalida Then
                            ModPOS.GeneraMovInv(2, 1, 1, VENClave, AlmacenSurtido, LblFolio.Text, Nothing)
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

                ModPOS.Ejecuta("sp_actualiza_venta_cerrada", "@VENClave", VENClave, "@Estado", EstadoDocumento, "@ActSaldo", 0)

                modificaStatus(TipoDocumento, EstadoDocumento)

            End If

            Dim frmStatusMessage As New frmStatus

            If Remoto = 0 Then
                If Picking = False OrElse TipoDocumento = 2 OrElse TipoDocumento = 4 Then

                    If VentaNueva Then
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
                        Select Case MessageBox.Show("¿Desea Reimprimir el Documento?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            Case DialogResult.Yes
                                frmStatusMessage.Show("Imprimiendo...")

                                ImprimirPedido(VENClave, EstadoDocumento, TotalVenta)

                                frmStatusMessage.Dispose()
                        End Select
                    End If

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


                                If VentaNueva Then
                                    If ImprimirRemoto = 0 Then
                                        ModPOS.ImprimirSurtido(1, VENClave, False, True)
                                    Else
                                        ModPOS.Ejecuta("st_inserta_printspooler", "@TipoDocumento", 1, "@DOCClave", VENClave, "@Reimpresion", False, "@Usuario", ModPOS.UsuarioActual)
                                    End If
                                Else
                                    Select Case MessageBox.Show("¿Desea Reimprimir la Hoja de Recolección?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                        Case DialogResult.Yes

                                            If ImprimirRemoto = 0 Then
                                                ModPOS.ImprimirSurtido(1, VENClave, True, True)
                                            Else
                                                ModPOS.Ejecuta("st_inserta_printspooler", "@TipoDocumento", 1, "@DOCClave", VENClave, "@Reimpresion", True, "@Usuario", ModPOS.UsuarioActual)
                                            End If

                                    End Select
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            VentaCerrada = True

            Dim msg As New FrmMeMsg

            msg.TxtTiulo = "PEDIDO"
            msg.btnOK.Visible = True
            msg.Height = 285
            msg.Width = 588
            msg.lblPie.Text = ""
            msg.TxtMsg = LblFolio.Text
            msg.TxtMsg2 = "MESA " & txtMesa.Text
            msg.ShowDialog()
            msg.Dispose()

            If MessageBox.Show("¿Desea registrar otro Pedido?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cambiaCliente(CTEClaveActual)
            Else
                btnQuitarProducto.Enabled = False
                btnBorrarTodo.Enabled = False
                BtnCerrar.Enabled = False
                TxtProducto.Enabled = False
                GeneraMovSalida = False
                dtPedidoDetalle.Clear()
                TotalArticulos = 0
                TotalPuntos = 0
                TotalVenta = 0
                TotalRecibido = 0
                TotalCambio = 0
                TotalAhorro = 0
                txtMesa.Text = ""
                LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
                LblCantidadArticulos.Text = CStr(TotalArticulos)
                LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

                If Moneda <> MonedaCambio Then
                    If TotalVenta > 0 Then
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim
                    End If
                End If

                LblFolio.Text = Referencia & "-0"

                cambiaStatus("", iEstado.Original)



                Dim b As New FrmObtieneAfiliado
                b.ShowDialog()
                If b.DialogResult = DialogResult.OK Then
                    If b.CTEClave = "12345" Then
                        Me.Close()
                        Exit Sub
                    End If
                    cambiaCliente(b.CTEClave)
                Else
                    MessageBox.Show("No es posible iniciar debido a que no se ha especificado al cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                b.Dispose()

            End If


        Else
            Beep()
            MessageBox.Show("El documento actual no puede ser cerrado sin productos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Dejar(ByVal sender As Object, ByVal e As System.EventArgs)
        TxtProducto.Focus()
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

    'Private Function imprimeTicket(ByVal TipoDoc As Integer, ByVal Venta As String, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String, ByVal Redondeo As Double, ByVal Saldo As Double, ByVal NuevaVenta As Boolean) As Boolean



    '    Dim dTotalAhorro, dTotalPuntos, dTotalVenta, dArticulos As Double

    '    Dim lineasImpresas As Integer = 6

    '    Dim Tickets As Imprimir = New Imprimir 'PrintTicket.Ticket()
    '    Tickets.Generic = Generic
    '    Dim dtTicket As DataTable
    '    dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

    '    If Not dtTicket Is Nothing Then
    '        Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
    '        Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
    '        Tickets.LetraName = dtTicket.Rows(0)("FontName")
    '        If dtTicket.Rows(0)("url_imagen") <> "" Then
    '            Tickets.ImgHeader = ModPOS.RecuperaImagen(dtTicket.Rows(0)("url_imagen"))
    '        End If
    '        dtTicket.Dispose()
    '    End If


    '    If TipoDoc = 2 Then
    '        Tickets.AddHeaderLine("*** COTIZACION ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
    '        lineasImpresas += 1
    '    ElseIf TipoDoc = 3 Then
    '        Tickets.AddHeaderLine("***  CREDITO  ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
    '        lineasImpresas += 1
    '    ElseIf TipoDoc = 4 Then
    '        Tickets.AddHeaderLine("***  APARTADO  ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
    '        lineasImpresas += 1
    '    End If

    '    Dim dtHeadTicket As DataTable
    '    dtHeadTicket = ModPOS.SiExisteRecupera("sp_filtra_encabezado", "@TIKClave", Ticket)



    '    If Not dtHeadTicket Is Nothing Then

    '        lineasImpresas += dtHeadTicket.Rows.Count

    '        Dim i As Integer
    '        For i = 0 To dtHeadTicket.Rows.Count - 1
    '            Tickets.AddHeaderLine(CStr(dtHeadTicket.Rows(i)("Texto")), Math.Abs(CInt(dtHeadTicket.Rows(i)("Negrita"))), CInt(dtHeadTicket.Rows(i)("Alinear")))
    '        Next
    '        dtHeadTicket.Dispose()
    '    End If

    '    If NuevaVenta = False Then
    '        Tickets.AddHeaderLine("REIMPRESION", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
    '        lineasImpresas += 1
    '    End If

    '    'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
    '    'de que al final de cada linea agrega una linea punteada "==========" 

    '    Dim dtVenta As DataTable = ModPOS.SiExisteRecupera("sp_recupera_vta_open", "@VENClave", Venta)


    '    Tickets.AddSubHeaderLine(" TICKET # " & dtVenta.Rows(0)("Folio"), 1, 3)
    '    lineasImpresas += 1

    '    If TipoDoc = 3 AndAlso CTEClaveActual = CreditoGeneral AndAlso NotaCreditos <> "" Then
    '        Tickets.AddSubHeaderLine("CTE: " & NotaCreditos, 0, 3)
    '        lineasImpresas += 1
    '    Else
    '        Tickets.AddSubHeaderLine("CTE: " & dtVenta.Rows(0)("RazonSocial"), 0, 3)
    '        lineasImpresas += 1
    '    End If

    '    Tickets.AddSubHeaderLine("LE ATENDIO: " & dtVenta.Rows(0)("NombreUsuario"), 0, 3)
    '    lineasImpresas += 1

    '    Dim tFecha As DateTime
    '    tFecha = dtVenta.Rows(0)("Fecha")

    '    dtVenta.Dispose()

    '    Tickets.AddSubHeaderLine(tFecha.ToShortDateString() & " " & tFecha.ToShortTimeString(), 0, 3)
    '    lineasImpresas += 1

    '    'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
    '    'del producto y el tercero es el precio 
    '    Dim dtVentaDetalle As DataTable
    '    dtVentaDetalle = ModPOS.SiExisteRecupera("st_ventadetalle_ticket", "@VENClave", Venta)

    '    lineasImpresas += (dtVentaDetalle.Rows.Count() * 2)



    '    If Not dtVentaDetalle Is Nothing Then
    '        Dim i As Integer = 0
    '        dArticulos = dtVentaDetalle.Rows.Count()
    '        For i = 0 To dArticulos - 1
    '            Dim sDVEClave As String = dtVentaDetalle.Rows(i)("DVEClave")
    '            Dim sGTIN As String = dtVentaDetalle.Rows(i)("Clave")
    '            Dim sNombre As String = dtVentaDetalle.Rows(i)("Nombre")
    '            Dim dCantidad As Double = dtVentaDetalle.Rows(i)("Cantidad")
    '            Dim dSubtotal As Double = dtVentaDetalle.Rows(i)("SubtotalPartida")
    '            Dim dImpuestoImp As Double = dtVentaDetalle.Rows(i)("ImpuestoImp")
    '            Dim dDescuentoImp As Double = dtVentaDetalle.Rows(i)("DescuentoImp")
    '            Dim dTotal As Double = dtVentaDetalle.Rows(i)("TotalPartida")
    '            Dim dImpuestoPorc As Double = dtVentaDetalle.Rows(i)("ImpuestoPorc")
    '            Dim kglt As Integer = dtVentaDetalle.Rows(i)("KgLt")
    '            Dim UnidadesKilo As Double = dtVentaDetalle.Rows(i)("UndKilo")

    '            If kglt = 1 Then
    '                sNombre &= " " & CStr(UnidadesKilo) & "Und(s)"
    '            End If

    '            Dim dImporteNeto As Double
    '            If iDesglosarPrecio = 1 Then
    '                dImporteNeto = Math.Round(dSubtotal * (1 + dImpuestoPorc), 2) / dCantidad
    '                dDescuentoImp = ModPOS.Redondear((dDescuentoImp * (1 + dImpuestoPorc)) / dCantidad, 2)
    '            Else
    '                dImporteNeto = dTotal / dCantidad
    '                dDescuentoImp = 0
    '            End If

    '            ' AGREGAR PRODUCTO A LISTA
    '            Tickets.AddItem(sDVEClave, sGTIN, sNombre, dCantidad, dImporteNeto, dDescuentoImp)

    '            dTotalAhorro += dDescuentoImp
    '            ' dTotalPuntos += (dPuntosImp * dCantidad)
    '            dTotalVenta += (dTotal)
    '        Next
    '        dtVentaDetalle.Dispose()
    '    End If

    '    dTotalVenta += Redondeo

    '    Tickets.AddTotal(Redondeo, dTotalVenta, dTotalPuntos, dTotalAhorro, dArticulos, TotalRecibido, Math.Round(TotalCambio, 2), Saldo, 1)

    '    lineasImpresas += 5

    '    If TotalRecibido > 0 Then
    '        Dim i As Integer
    '        Dim sTipo, sReferencia, sMonto As String
    '        Dim dtMetodospago As DataTable
    '        dtMetodospago = ModPOS.Recupera_Tabla("sp_metodospago_venta", "@VENClave", Venta)
    '        For i = 0 To dtMetodospago.Rows.Count - 1

    '            sTipo = dtMetodospago.Rows(i)("Tipo")
    '            '  sBanco = IIf(dtMetodospago.Rows(i)("Banco").GetType.Name = "DBNull", "", dtMetodospago.Rows(i)("Banco"))
    '            sReferencia = IIf(dtMetodospago.Rows(i)("Referencia").GetType.Name = "DBNull", "", dtMetodospago.Rows(i)("Referencia"))
    '            sMonto = Strings.Format(TruncateToDecimal(dtMetodospago.Rows(i)("Importe"), 2).ToString, "Currency")

    '            Tickets.AddMetodoPago(sTipo, sReferencia, sMonto, i)

    '            lineasImpresas += 2
    '        Next
    '        dtMetodospago.Dispose()
    '    End If

    '    'El metodo AddFooterLine funciona igual que la cabecera 

    '    Dim dtPieTicket As DataTable
    '    dtPieTicket = ModPOS.SiExisteRecupera("sp_filtra_pie", "@TIKClave", Ticket)

    '    If Not dtPieTicket Is Nothing Then
    '        Dim i As Integer

    '        lineasImpresas += dtPieTicket.Rows.Count

    '        For i = 0 To dtPieTicket.Rows.Count - 1
    '            Tickets.AddFooterLine(CStr(dtPieTicket.Rows(i)("Texto")), Math.Abs(CInt(dtPieTicket.Rows(i)("Negrita"))), CInt(dtPieTicket.Rows(i)("Alinear")))
    '        Next
    '        Tickets.AddFooterLine("http://sellingsoft.com.mx/", 1, 3)

    '        dtPieTicket.Dispose()
    '    End If

    '    'Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
    '    'parametro de tipo string que debe de ser el nombre de la impresora. 
    '    Tickets.PrintTicket(Impresora, 70, lineasImpresas)

    'End Function

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
                VentaCerrada = True
                modificaStatus(TipoDocumento, EstadoDocumento)
                If dt.Rows(0)("Estado") = 8 OrElse dt.Rows(0)("Estado") = 7 OrElse dt.Rows(0)("Estado") = 4 Then
                    MessageBox.Show("El pedido seleccionado No puede ser Cancelado debido a que se encuentra en proceso de recolección o ya ha sido cancelado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If
            dt.Dispose()

            If TotalArticulos > 0 Then

                EstadoDocumento = iEstado.Cancelada
                ObtenerFolio(False)
                ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", EstadoDocumento, "@ALMClave", AlmacenSurtido, "@Folio", LblFolio.Text)
                ModPOS.Ejecuta("sp_cancela_ticket", "@VENClave", VENClave, "@ALMClave", AlmacenSurtido, "@TipoDoc", TipoDocumento, "@Motivo", motCancelacion, "@Autoriza", Autoriza)
                ModPOS.Ejecuta("sp_agrega_venta", "@VENClave", VENClave)

                SeCancela = True
            Else

                EstadoDocumento = iEstado.Cancelada
                Dim strFolio As String
                strFolio = "T-" & Referencia & "-" & CStr(Today.DayOfYear) & "-" & CStr(FolioTmp)

                If LblFolio.Text = strFolio Then
                    ' ModPOS.Ejecuta("sp_act_folio", "@PDVClave", PDVClave, "@Incremento", -1, "@Tipo", 1)
                    FolioTmp -= 1
                    ModPOS.Ejecuta("sp_elimina_venta", "@VENClave", VENClave)
                Else
                    ObtenerFolio(False)
                    ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", EstadoDocumento, "@ALMClave", AlmacenSurtido, "@Folio", LblFolio.Text)
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
                TxtProducto.Enabled = False
                GeneraMovSalida = False
                dtPedidoDetalle.Clear()
                TotalArticulos = 0
                TotalPuntos = 0
                TotalVenta = 0
                TotalRecibido = 0
                TotalCambio = 0
                TotalAhorro = 0
                txtMesa.Text = ""
                LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
                LblCantidadArticulos.Text = CStr(TotalArticulos)
                LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

                If Moneda <> MonedaCambio Then
                    If TotalVenta > 0 Then
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim
                    End If
                End If

                LblFolio.Text = Referencia & "-0"

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
                    VentaCerrada = True
                    modificaStatus(TipoDocumento, EstadoDocumento)
                    MessageBox.Show("No es posible modificar el Documento, ya que No se encuentra Abierto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                dt.Dispose()

                If MessageBox.Show("¿Esta seguro que desea eliminar todos los Productos del documento actual?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If


                cancelaProducto(VENClave, TipoDocumento, "")

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
                    If TotalVenta > 0 Then
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.TruncateToDecimal(TotalVenta / TipoCambio, 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.TruncateToDecimal(TotalVenta, 2)), "Currency")
                    End If
                End If


            Else
                MsgBox("El documento no contiene productos", MsgBoxStyle.Information, "Información")
            End If
        End If
        TxtProducto.Focus()

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

            Dim iKgLt As Integer
            Dim sTipoDesc As String = ""

            For i = 0 To foundRows.GetUpperBound(0)

                iGrupoMaterial = foundRows(i)("GrupoMaterial")
                iSector = foundRows(i)("Sector")
                iPartida = foundRows(i)("Partida")
                dPrecioUnitario = foundRows(i)("PrecioBruto")
                dPorcImp = foundRows(i)("PorcImp")
                dCantidad = foundRows(i)("Cantidad")

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

                            recalcularPartidas()

                        End If
                    End If
                End If

                'dDescuentoImp = Math.Round((dBase - dDescGeneralImp - dVolumenImp) * dDescPorc, 2)
                'dImpuestoImp = Math.Round((dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp) * dPorcImp, 2)
                'dImporteNeto = dBase - dDescGeneralImp - dVolumenImp - dDescuentoImp + dImpuestoImp


                'Elimina partida y libera apartado
                ModPOS.Ejecuta("sp_elimina_partida", _
                "@ALMClave", ALMClave, _
                "@VENClave", VENClave, _
                "@DVEClave", foundRows(i)("DVEClave"), _
                "@Producto", foundRows(i)("PROClave"), _
                "@Cantidad", foundRows(i)("Cantidad"), _
                "@TipoDoc", TipoDoc, _
                "@TProducto", foundRows(i)("TProducto"), _
                "@Picking", Picking)


                TotalArticulos -= 1
                TotalPuntos -= foundRows(i)("PuntosImp")

                Dim fr() As System.Data.DataRow
                fr = dtPedidoDetalle.Select(" DVEClave = '" & foundRows(i)("DVEClave") & "'")

                dtPedidoDetalle.Rows.Remove(fr(0))


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
                    VentaCerrada = True
                    modificaStatus(TipoDocumento, EstadoDocumento)
                    MessageBox.Show("No es posible modificar el Documento, ya que No se encuentra Abierto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                dt.Dispose()

                If MessageBox.Show("¿Esta seguro que desea eliminar el Producto " & GridDetalle.GetValue("Clave") & " ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then

                    Exit Sub
                End If



                cancelaProducto(VENClave, TipoDocumento, GridDetalle.GetValue("DVEClave"))

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
                    If TotalVenta > 0 Then
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.TruncateToDecimal(TotalVenta / TipoCambio, 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.TruncateToDecimal(TotalVenta, 2)), "Currency")
                    End If
                End If


            Else
                MsgBox("El documento no contiene productos", MsgBoxStyle.Information, "Información")
            End If
        End If
        TxtProducto.Focus()

    End Sub

    'Private Sub BtnBusquedaProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBusquedaProducto.Click

    '    Dim sCliente As String

    '    If ClienteSAP <> "" AndAlso CTEClaveActual <> ClienteSAP Then
    '        sCliente = ClienteSAP
    '    Else
    '        sCliente = CTEClaveActual
    '    End If

    '    If VentaCerrada OrElse TotalArticulos = 0 Then
    '        Dim dtCliente As DataTable
    '        dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Cliente", sCliente)
    '        ListaPrecio = dtCliente.Rows(0)("PREClave")
    '        TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
    '        dtCliente.Dispose()
    '    End If
    '    Dim a As New FrmBuscaProducto
    '    a.bVentaConvencional = True
    '    a.url_imagen = Me.url_imagen
    '    a.SUCClave = Me.SUCClave
    '    a.ClienteActual = sCliente
    '    a.PuntodeVenta = PDVClave
    '    a.Almacen = AlmacenSurtido
    '    a.ListadePrecio = ListaPrecio
    '    a.StatusVenta = VentaCerrada
    '    a.TImpuesto = TImpuesto
    '    a.BusquedaInicial = True
    '    a.Busqueda = TxtProducto.Text.Trim.ToUpper
    '    a.TxtAlmacen.Text = sAlmacen
    '    a.bMessage = Me.bMessage
    '    a.Padre = "Afiliado"

    '    a.ShowDialog()
    '    a.Dispose()

    '    TxtProducto.Focus()

    '    Me.bMessage = False

    'End Sub







    Public Sub recuperaVentaOpen( _
    ByVal sVENClave As String, _
    ByVal sFolio As String, _
    ByVal sCTEClave As String, _
    ByVal sRazonSocial As String, _
    ByVal sCajero As String, _
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
            FechaVenta = CDate(dtVta.Rows(0)("Fecha"))
        End If

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

        'recupera partida
        Dim dtventadetalle As DataTable

        dtventadetalle = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", sVENClave)




        btnQuitarProducto.Enabled = True
        btnBorrarTodo.Enabled = True

        BtnCerrar.Enabled = True
        TxtProducto.Enabled = True


        With Me
            TotalArticulos = 0
            TotalPuntos = 0
            TotalVenta = 0
            TotalRecibido = 0
            TotalCambio = 0
            TotalAhorro = 0
            TotalVenta = 0

            dtPedidoDetalle.Clear()

            .VentaNueva = True
            .VentaCerrada = False
            .GeneraMovSalida = True

            .VENClave = sVENClave
            .LblFolio.Text = sFolio

            Dim sFol As String = sFolio

            .Folio = CInt(sFol.Split("-")(1))

            .AtiendeClave = sCajero
            .AtiendeNombre = sNombreUsuario

            .TipoDocumento = iTipo





            If FechaVenta.Date <> Today.Date Then

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
                        leeCodigoBarras(dtventadetalle.Rows(i)("Cantidad"), dtventadetalle.Rows(i)("Clave"), True, False, True, False, False, False)

                    Next
                    dtventadetalle.Dispose()

                End If

                frmstatusmessage.Close()
            Else

                Dim dtCliente As DataTable
                dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", .CTEClaveActual)
                .ListaPrecio = dtCliente.Rows(0)("PREClave")
                .TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                dtCliente.Dispose()

                .SaldoVenta = dSaldo

                .EstadoDocumento = iEstado

                If Not dtventadetalle Is Nothing Then
                    Dim i As Integer = 0
                    .TotalArticulos = dtventadetalle.Rows.Count

                    For i = 0 To .TotalArticulos - 1
                        Dim sDVEClave As String = dtventadetalle.Rows(i)("DVEClave")
                        Dim sPROClave As String = dtventadetalle.Rows(i)("PROClave")
                        Dim sGTIN As String = dtventadetalle.Rows(i)("Clave")
                        Dim sNombre As String = dtventadetalle.Rows(i)("Nombre")
                        Dim dCantidad As Double = dtventadetalle.Rows(i)("Cantidad")
                        Dim dPrecioBruto As Double = dtventadetalle.Rows(i)("PrecioBruto")
                        Dim dImpuestoPorc As Double = dtventadetalle.Rows(i)("ImpuestoPorc")
                        Dim dImpuestoImp As Double = IIf(dtventadetalle.Rows(i)("ImpuestoImp").GetType.FullName <> "System.DBNull", dtventadetalle.Rows(i)("ImpuestoImp"), 0)
                        Dim dDescuentoImp As Double = dtventadetalle.Rows(i)("DescuentoImp")
                        Dim dPuntosImp As Double = dtventadetalle.Rows(i)("PuntosImp")
                        Dim dSubtotal As Double = dtventadetalle.Rows(i)("SubTotalPartida")
                        Dim dTotal As Double = dtventadetalle.Rows(i)("TotalPartida")

                        Dim iGrupoMaterial As Integer = IIf(dtventadetalle.Rows(0)("GrupoMaterial").GetType.FullName = "System.DBNull", 0, dtventadetalle.Rows(0)("GrupoMaterial"))
                        Dim iSector As Integer = IIf(dtventadetalle.Rows(0)("Sector").GetType.FullName = "System.DBNull", 0, dtventadetalle.Rows(0)("Sector"))
                        Dim iPartida As Integer = IIf(dtventadetalle.Rows(0)("Partida").GetType.FullName = "System.DBNull", (i + 1) * 10, dtventadetalle.Rows(0)("Partida"))



                        Dim iKgLt As Integer = IIf(dtventadetalle.Rows(0)("KgLt").GetType.FullName = "System.DBNull", 0, dtventadetalle.Rows(0)("KgLt"))
                        Dim dUndKilo As Double = IIf(dtventadetalle.Rows(0)("UndKilo").GetType.FullName = "System.DBNull", 0, dtventadetalle.Rows(0)("UndKilo"))

                        ' AGREGAR PRODUCTO A LISTA
                        .AgregarProducto(sDVEClave, sPROClave, sGTIN, sNombre, dCantidad, dPrecioBruto, dImpuestoPorc, dDescuentoImp, iKgLt, dUndKilo, iGrupoMaterial, iSector, iPartida)
                        .TotalAhorro += dDescuentoImp
                        .TotalPuntos += (dPuntosImp * dCantidad)
                        .TotalVenta += (dTotal)
                    Next
                    dtventadetalle.Dispose()
                End If

                If .SaldoVenta = -1 Then
                    .SaldoVenta = .TotalVenta
                End If

                LblCantidadPuntos.Text = ModPOS.TruncateToDecimal(.TotalPuntos, 2).ToString("#,##0.00")
                LblCantidadArticulos.Text = CStr(.TotalArticulos)
                LblAhorro.Text = Format(CStr(ModPOS.TruncateToDecimal(.TotalAhorro, 2)), "Currency")
                LblTotal.Text = Format(CStr(ModPOS.TruncateToDecimal(.TotalVenta, 2)), "Currency")

                If Moneda <> MonedaCambio Then
                    If TotalVenta > 0 Then
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.TruncateToDecimal(TotalVenta / TipoCambio, 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.TruncateToDecimal(TotalVenta, 2)), "Currency")
                    End If
                End If

                ModPOS.Ejecuta("sp_venta_estado", "@VENClave", VENClave, "@Estado", 1)


            End If



            modificaStatus(TipoDocumento, EstadoDocumento)
            If Padre = "Nuevo" Then
                MsgBox("El documento en espera ha sido recuperado exitosamente", MsgBoxStyle.Information, "Información")
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

            TxtProducto.Enabled = False


            VentaCerrada = True
            GeneraMovSalida = False
            VentaNueva = False

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



            modificaStatus(TipoDocumento, EstadoDocumento)

            Dim dtCliente As DataTable
            dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", CTEClaveActual)
            ListaPrecio = dtCliente.Rows(0)("PREClave")
            TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
            dtCliente.Dispose()



            'recupera partida
            dtVenta.Dispose()

            Dim dtVentaDetalle As DataTable = ModPOS.SiExisteRecupera("sp_ventadetalle_cerrada", "@VENClave", VENClave)
            If Not dtVentaDetalle Is Nothing Then
                Dim i As Integer = 0
                TotalArticulos = dtVentaDetalle.Rows.Count
                TotalAhorro = 0
                For i = 0 To TotalArticulos - 1
                    Dim sDVEClave As String = dtVentaDetalle.Rows(i)("DVEClave")
                    Dim sPROClave As String = dtVentaDetalle.Rows(i)("PROClave")
                    Dim sGTIN As String = dtVentaDetalle.Rows(i)("Clave")
                    Dim sNombre As String = dtVentaDetalle.Rows(i)("Nombre")
                    Dim dCantidad As Double = dtVentaDetalle.Rows(i)("Cantidad")
                    Dim dPrecioBruto As Double = dtVentaDetalle.Rows(i)("PrecioBruto")
                    Dim dImpuestoPorc As Double = dtVentaDetalle.Rows(i)("ImpuestoPorc")
                    Dim dImpuestoImp As Double = IIf(dtVentaDetalle.Rows(i)("ImpuestoImp").GetType.FullName <> "System.DBNull", dtVentaDetalle.Rows(i)("ImpuestoImp"), 0)
                    Dim dDescuentoImp As Double = dtVentaDetalle.Rows(i)("DescuentoImp")
                    Dim dPuntosImp As Double = dtVentaDetalle.Rows(i)("PuntosImp")
                    Dim dTotal As Double = dtVentaDetalle.Rows(i)("TotalPartida")

                    Dim iGrupoMaterial As Integer = IIf(dtVentaDetalle.Rows(0)("GrupoMaterial").GetType.FullName = "System.DBNull", 0, dtVentaDetalle.Rows(0)("GrupoMaterial"))
                    Dim iSector As Integer = IIf(dtVentaDetalle.Rows(0)("Sector").GetType.FullName = "System.DBNull", 0, dtVentaDetalle.Rows(0)("Sector"))
                    Dim iPartida As Integer = IIf(dtVentaDetalle.Rows(0)("Partida").GetType.FullName = "System.DBNull", (i + 1) * 10, dtVentaDetalle.Rows(0)("Partida"))

                    Dim iKgLt As Integer = IIf(dtVentaDetalle.Rows(0)("KgLt").GetType.FullName = "System.DBNull", 0, dtVentaDetalle.Rows(0)("KgLt"))
                    Dim dPeso As Double = IIf(dtVentaDetalle.Rows(0)("Peso").GetType.FullName = "System.DBNull", 0, dtVentaDetalle.Rows(0)("Peso"))

                    ' AGREGAR PRODUCTO A LISTA
                    AgregarProducto(sDVEClave, sPROClave, sGTIN, sNombre, dCantidad, dPrecioBruto, dImpuestoPorc, dDescuentoImp, iKgLt, dPeso, iGrupoMaterial, iSector, iPartida)
                    TotalAhorro += ((dDescuentoImp * (1 + dImpuestoPorc)) * dCantidad)

                Next



                dtVentaDetalle.Dispose()

                LblCantidadPuntos.Text = ModPOS.TruncateToDecimal(TotalPuntos, 2).ToString("#,##0.00")
                LblCantidadArticulos.Text = CStr(TotalArticulos)
                LblAhorro.Text = Format(CStr(ModPOS.TruncateToDecimal(TotalAhorro, 2)), "Currency")
                LblTotal.Text = Format(CStr(ModPOS.TruncateToDecimal(TotalVenta, 2)), "Currency")

                If Moneda <> MonedaCambio Then
                    If TotalVenta > 0 Then
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.TruncateToDecimal(TotalVenta / TipoCambio, 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.TruncateToDecimal(TotalVenta, 2)), "Currency")
                    End If
                End If
            End If





            ModPOS.Ejecuta("sp_agrega_tmp_venta", "@VENClave", VENClave, "@PDVClave", PDVClave)
        Else
            MessageBox.Show("El ticket que intenta recuperar no existe o se encuentra totalmente pagado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub ItemApartado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        If AlmacenSurtido = "" OrElse AlmacenSurtido Is Nothing Then
            Beep()
            MessageBox.Show("No es posible crear el documento debido a que no se ha especificado el Almacen para surtido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim b As New FrmSolicitaCliente
        b.ClienteInicial = CTEClaveInicial
        b.ShowDialog()
        If b.DialogResult = DialogResult.OK Then
            CTEClaveActual = b.ClienteClave
            CTENombreActual = b.ClienteNombre
            LblCliente.Text = CTENombreActual
        Else
            CTEClaveActual = CTEClaveInicial
            CTENombreActual = CTENombreInicial
            LblCliente.Text = CTENombreActual
            MessageBox.Show("No es posible crear el apartado debido a que no se ha especificado al cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        b.Dispose()

        If SolicitaVendedor Then
            Dim a As New FrmSolicitaUsuario
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                Me.AtiendeNombre = a.AtiendeNombre
                Me.AtiendeClave = a.AtiendeClave

            Else
                CTEClaveActual = CTEClaveInicial
                CTENombreActual = CTENombreInicial
                LblCliente.Text = CTENombreActual
                MessageBox.Show("No es posible crear una nueva venta debido a que no se ha sido registrado un Vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            a.Dispose()
        End If


        Dim dt As DataTable

        If Moneda <> MonedaCambio Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
            MonedaRef = dt.Rows(0)("Referencia")
            TipoCambio = dt.Rows(0)("TipoCambio")
            dt.Dispose()
        Else
            LblTipoCambio.Text = ""
        End If



        ObtenerFolio(True)

        TipoDocumento = 4
        EstadoDocumento = 1


        modificaStatus(TipoDocumento, EstadoDocumento)

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
        "@Usuario", ModPOS.UsuarioActual)


        btnQuitarProducto.Enabled = True
        btnBorrarTodo.Enabled = True

        BtnCerrar.Enabled = True
        TxtProducto.Enabled = True

        VentaCerrada = False
        GeneraMovSalida = False
        VentaNueva = True


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
            If TotalVenta > 0 Then
                LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
            Else
                LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
            End If
        End If

        TxtProducto.Focus()
    End Sub

    Private Sub ItemCotizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If AlmacenSurtido = "" OrElse AlmacenSurtido Is Nothing Then
            Beep()
            MessageBox.Show("No es posible crear el documento debido a que no se ha especificado el Almacen para surtido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If ActivarCotizacion = True Then
            If SolicitaVendedor Then

                Dim a As New FrmSolicitaUsuario
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    Me.AtiendeNombre = a.AtiendeNombre
                    Me.AtiendeClave = a.AtiendeClave

                Else
                    MessageBox.Show("No es posible crear una nueva venta debido a que no se ha sido registrado un Vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                a.Dispose()

            End If

            Dim dt As DataTable

            If Moneda <> MonedaCambio Then
                dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
                MonedaRef = dt.Rows(0)("Referencia")
                TipoCambio = dt.Rows(0)("TipoCambio")
                dt.Dispose()
            Else
                LblTipoCambio.Text = ""
            End If

            CTEClaveActual = CTEClaveInicial
            CTENombreActual = CTENombreInicial
            LblCliente.Text = CTENombreActual



            ObtenerFolio(True)

            TipoDocumento = 2

            EstadoDocumento = 1


            modificaStatus(TipoDocumento, EstadoDocumento)


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
            "@Usuario", ModPOS.UsuarioActual)



            btnQuitarProducto.Enabled = True
            btnBorrarTodo.Enabled = True

            BtnCerrar.Enabled = True
            TxtProducto.Enabled = True

            VentaCerrada = False
            GeneraMovSalida = False
            VentaNueva = True

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
                If TotalVenta > 0 Then
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                End If
            End If
        End If
        TxtProducto.Focus()
    End Sub



    Private Sub recuperaDatosCredito(ByVal Cliente As String)
        Dim dt As DataTable

        dt = ModPOS.SiExisteRecupera("sp_recupera_credito", "@CTEClave", Cliente)

        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                CreditoDisponible = dt.Rows(0)("Disponible")
            Else
                CreditoDisponible = 0.0

            End If
            dt.Dispose()
        Else
            CreditoDisponible = 0.0
        End If
    End Sub

    Private Sub ItemCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        If Caja Then
            Dim a As New FrmCambios
            a.CAJClave = CAJClave
            a.PDVClave = PDVClave
            a.SUCClave = SUCClave
            a.ClienteActual = Me.CTEClaveActual
            a.NombreClienteActual = Me.CTENombreActual
            a.Almacen = ALMClave
            a.Generic = Me.PrintGeneric
            a.Ticket = Me.Ticket
            a.Impresora = Me.Impresora

            a.Referencia = Me.Referencia
            a.ShowDialog()
            a.Dispose()
        Else
            MessageBox.Show("El punto de venta no cuenta con una Caja asignada por lo que no es posible realizar el cambio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub picSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub GridDetalle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.DoubleClick
        BtnModificar.PerformClick()
    End Sub

    Private Function cambiaCliente(ByVal sCTEClave As String) As Boolean
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", sCTEClave)
        If dt.Rows.Count = 0 Then
            MessageBox.Show("Error al intentar cargar información de domicilios del cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        Dim Tel1 As String = dt.Rows(0)("Tel1")
        Dim eMail As String = dt.Rows(0)("Email")

        Dim b As New FrmConfirmaDatos
        b.txtTelefono.Text = Tel1
        b.txtCorreo.Text = eMail
        b.ShowDialog()
        If b.DialogResult = DialogResult.OK Then
            If Tel1 <> b.Telefono OrElse eMail <> b.Correo Then
                ModPOS.Ejecuta("st_act_datos_afiliado", "@CTEClave", sCTEClave, "@Tel", b.Telefono, "@Mail", b.Correo)
            End If
        End If
        b.Dispose()


        Dim CreditoDisp As Double
        Dim LimiteCred As Double

        CTEClaveActual = sCTEClave
        DCTEClave = dt.Rows(0)("DCTEClave")
        ClienteSAP = IIf(dt.Rows(0)("ClienteSAP").GetType.Name = "DBNull", "", dt.Rows(0)("ClienteSAP"))
        CTENombreActual = dt.Rows(0)("RazonSocial")
        NumeroAfiliado = dt.Rows(0)("Clave")
        CreditoDisp = dt.Rows(0)("Disponible")
        LimiteCred = dt.Rows(0)("LimiteCredito")
        LblCliente.Text = NumeroAfiliado & "  " & CTENombreActual
        dt.Dispose()

        If LimiteCred > 0 Then
            VentaCredito()
        Else
            VentaContado()
        End If

        TxtProducto.Focus()

        Return True

    End Function






    Private Sub GridDetalle_MouseDown(sender As Object, e As MouseEventArgs) Handles GridDetalle.MouseDown
        If e.Button = MouseButtons.Right Then
            If Not GridDetalle.GetValue(0) Is Nothing AndAlso GridDetalle.GetValue("Baja") = 0 Then
                Dim a As New FrmConsultaGen
                a.Text = "Desglose de Precio"
                ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_desglose_precio", "@DVEClave", GridDetalle.GetValue("DVEClave"))
                a.GridConsultaGen.GroupByBoxVisible = False
                a.GridConsultaGen.FilterMode = Janus.Windows.GridEX.FilterMode.None
                a.GridConsultaGen.RootTable.Columns("Importe").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                a.ShowDialog()
                a.Dispose()
            End If
        End If
    End Sub

    Private Sub ConvierteCotizacion(ByVal iTipoDocumento As Integer)

        'If iTipoDocumento = 3 AndAlso CDbl(txtLimite.Text) <= 0 Then
        '    MessageBox.Show("El cliente actual no cuenta con limite de crédito.", "Error", MessageBoxButtons.OK)
        '    Exit Sub
        'End If

        Select Case MessageBox.Show("Esta apunto de crear una venta a partir de la cotización. ¿Esta usted de acuerdo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Case DialogResult.Yes

                Dim dt, dtventadetalle As DataTable

                dtventadetalle = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)

                If AlmacenSurtido = "" OrElse AlmacenSurtido Is Nothing Then
                    Beep()
                    MessageBox.Show("No es posible crear una nueva venta debido a que no se ha especificado el Almacen para surtido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

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
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        Me.AtiendeNombre = a.AtiendeNombre
                        Me.AtiendeClave = a.AtiendeClave

                    Else
                        MessageBox.Show("No es posible crear una nueva venta debido a que no se ha sido registrado un Vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    a.Dispose()
                End If

                'If iTipoDocumento >= 3 AndAlso CDbl(txtLimite.Text) > 0 Then
                '    TipoDocumento = 3
                '    EstadoDocumento = 1
                'Else
                '    TipoDocumento = 1
                '    EstadoDocumento = 1
                'End If

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
                "@Usuario", ModPOS.UsuarioActual)




                btnQuitarProducto.Enabled = True
                btnBorrarTodo.Enabled = True

                BtnCerrar.Enabled = True
                TxtProducto.Enabled = True

                VentaCerrada = False
                GeneraMovSalida = True
                VentaNueva = True


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
                    If TotalVenta > 0 Then
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                    End If
                End If

                If Not dtventadetalle Is Nothing Then
                    Dim i As Integer = 0

                    For i = 0 To dtventadetalle.Rows.Count - 1
                        leeCodigoBarras(dtventadetalle.Rows(i)("Cantidad"), dtventadetalle.Rows(i)("Clave"), True, False, True, True, False, False)
                    Next
                    dtventadetalle.Dispose()

                End If
        End Select

    End Sub

    Private Sub ItemEspera_Click(sender As Object, e As EventArgs)
        If VentaCerrada = True Then
            Dim a As New FrmConsulta
            a.Intro = False
            a.Campo = "VENClave"
            a.Campo2 = "PDVClave"
            a.AutoSizeForm = False
            a.BtnPicking.Visible = True
            ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_recupera_venta_wait", "@PDVClave", PDVClave)
            a.GridConsultaGen.RootTable.Columns("VENClave").Visible = False
            a.GridConsultaGen.RootTable.Columns("Fecha").Width = 60
            a.GridConsultaGen.RootTable.Columns("Clave").Width = 70
            a.GridConsultaGen.RootTable.Columns("RazonSocial").Width = 220
            a.GridConsultaGen.RootTable.Columns("Folio").Width = 50
            a.GridConsultaGen.RootTable.Columns("PDV").Width = 50
            a.GridConsultaGen.RootTable.Columns("PDV").Width = 80
            a.GridConsultaGen.RootTable.Columns("PDVClave").Visible = False
            a.GridConsultaGen.ScrollBars = Janus.Windows.GridEX.ScrollBars.Horizontal
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If a.ID <> "" Then
                    Select Case MessageBox.Show("¿Esta seguro de importar el documento seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.Yes

                            Dim dt As DataTable

                            dt = ModPOS.Recupera_Tabla("st_valida_wait", "@VENClave", a.ID, "@PDVClave", a.ID2)

                            If dt.Rows.Count > 0 Then
                                ModPOS.Ejecuta("st_importa_wait", "@VENClave", a.ID, "@PDVClave", PDVClave, "@Usuario", ModPOS.UsuarioActual)



                                dt = ModPOS.Recupera_Tabla("st_venta_wait", "@VENClave", a.ID)
                                recuperaVentaOpen(dt.Rows(0)("VENClave"), dt.Rows(0)("Folio"), dt.Rows(0)("Cliente"), dt.Rows(0)("RazonSocial"), dt.Rows(0)("Cajero"), dt.Rows(0)("NombreUsuario"), dt.Rows(0)("Saldo"), dt.Rows(0)("Total"), dt.Rows(0)("Tipo"), dt.Rows(0)("Estado"), dt.Rows(0)("LimiteCredito"), dt.Rows(0)("DiasCredito"), dt.Rows(0)("SaldoCliente"), dt.Rows(0)("ALMClave"))
                            Else
                                MessageBox.Show("El documento seleccionado ya fue importado por otro usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                    End Select
                End If
            End If
            a.Dispose()
        Else
            Beep()
            MessageBox.Show("No es posible Importar una venta en espera debido a que la venta actual no ha sido Cerrada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        TxtProducto.Focus()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If Not VentaCerrada Then
            Beep()
            Select Case MessageBox.Show("El Documento actual no ha sido Cerrado, ¿Desea Cancelarlo?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.No
                    Exit Sub
                Case DialogResult.Yes
                    CancelaPedido()
            End Select
        End If

        Dim b As New FrmObtieneAfiliado
        b.ShowDialog()
        If b.DialogResult = DialogResult.OK Then
            If b.CTEClave = "12345" Then
                Me.Close()
                Exit Sub
            End If
            cambiaCliente(b.CTEClave)
        Else
            MessageBox.Show("No es posible iniciar debido a que no se ha especificado al cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        b.Dispose()


    End Sub

    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click
        If Not VentaCerrada Then
            If TotalArticulos > 0 AndAlso Not GridDetalle.GetValue("DVEClave") Is Nothing Then
                leeCodigoBarras(GridDetalle.GetValue("Cantidad"), GridDetalle.GetValue("Clave"), False, False, False, True, True, False)
            Else
                MsgBox("El documento no contiene productos", MsgBoxStyle.Information, "Información")
            End If
        End If
        TxtProducto.Focus()

    End Sub




    Private Sub txtMesa_Click(sender As Object, e As EventArgs) Handles txtMesa.Click
        Dim a As New FrmTecladoNum
        a.Text = "Mesa"
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.txtMesa.Text = CStr(a.Cantidad)
            SendKeys.Send("{TAB}")
        End If
    End Sub




    
    Private Sub BtnNegados_Click(sender As Object, e As EventArgs) Handles BtnNegados.Click
        Dim a As New FrmConsultaGen
        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_obtener_modelonegado", "@CTEClave", CTEClaveActual)
        a.ShowDialog()
        a.Dispose()
    End Sub
End Class
