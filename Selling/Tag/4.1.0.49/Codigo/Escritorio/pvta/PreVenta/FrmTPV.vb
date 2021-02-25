Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Collections
Imports System.IO.Ports

Public Class FrmTPV
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
    Friend WithEvents lblTotMon As System.Windows.Forms.Label
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
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtProducto As System.Windows.Forms.TextBox
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents BtnCancelaTicket As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnBusquedaProducto As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelaProducto As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCerrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnVenta As Janus.Windows.EditControls.UIButton
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents LblCantidadPuntos As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblCantidadArticulos As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BtnWait As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents LblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents LblSubTitulo As System.Windows.Forms.Label
    Friend WithEvents btnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnEnvio As Janus.Windows.EditControls.UIButton
    Friend WithEvents picKeyboard As System.Windows.Forms.PictureBox
    Friend WithEvents txtLimite As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtDias As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents txtSaldo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents SpdetalleopenBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SellingDataSet As Selling.SellingDataSet
    Friend WithEvents Sp_detalle_openTableAdapter As Selling.SellingDataSetTableAdapters.sp_detalle_openTableAdapter
    Friend WithEvents btnCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents CtxCliente As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ItemEditarCte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemNuevoCte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbSucursal As Selling.StoreCombo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnAddenda As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnConvertir As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtVendedor As System.Windows.Forms.TextBox
    Friend WithEvents btnPreview As Janus.Windows.EditControls.UIButton
    Friend WithEvents ItemEdoCuenta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CtxTC As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents BtnTC As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCortar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnPegar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoCanal As Selling.StoreCombo
    Friend WithEvents lblNivelDesc As System.Windows.Forms.Label
    Friend WithEvents lblCteClave As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTPV))
        Dim GridDetalle_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblCantidadPuntos = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblTotMon = New System.Windows.Forms.Label()
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
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.TxtProducto = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblCantidadArticulos = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BtnWait = New Janus.Windows.EditControls.UIButton()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.BtnCerrar = New Janus.Windows.EditControls.UIButton()
        Me.BtnVenta = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelaProducto = New Janus.Windows.EditControls.UIButton()
        Me.BtnBusquedaProducto = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelaTicket = New Janus.Windows.EditControls.UIButton()
        Me.LblSubTitulo = New System.Windows.Forms.Label()
        Me.btnEnvio = New Janus.Windows.EditControls.UIButton()
        Me.txtLimite = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtDias = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.txtSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.BtnTC = New Janus.Windows.EditControls.UIButton()
        Me.CtxTC = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.lblCteClave = New System.Windows.Forms.Label()
        Me.btnCliente = New Janus.Windows.EditControls.UIButton()
        Me.CtxCliente = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ItemEditarCte = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemNuevoCte = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemEdoCuenta = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.SpdetalleopenBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SellingDataSet = New Selling.SellingDataSet()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BtnAddenda = New Janus.Windows.EditControls.UIButton()
        Me.btnBuscaCte = New Janus.Windows.EditControls.UIButton()
        Me.Sp_detalle_openTableAdapter = New Selling.SellingDataSetTableAdapters.sp_detalle_openTableAdapter()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.BtnConvertir = New Janus.Windows.EditControls.UIButton()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.btnPreview = New Janus.Windows.EditControls.UIButton()
        Me.cmbSucursal = New Selling.StoreCombo()
        Me.btnCortar = New Janus.Windows.EditControls.UIButton()
        Me.btnPegar = New Janus.Windows.EditControls.UIButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbTipoCanal = New Selling.StoreCombo()
        Me.lblNivelDesc = New System.Windows.Forms.Label()
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
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.MintCream
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LblCantidadPuntos)
        Me.Panel1.Location = New System.Drawing.Point(974, 441)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(240, 33)
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
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(8, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 24)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "PUNTOS"
        '
        'LblCantidadPuntos
        '
        Me.LblCantidadPuntos.BackColor = System.Drawing.Color.Transparent
        Me.LblCantidadPuntos.Font = New System.Drawing.Font("Lucida Sans Unicode", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidadPuntos.ForeColor = System.Drawing.Color.MidnightBlue
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
        Me.Panel3.BackColor = System.Drawing.Color.MintCream
        Me.Panel3.Controls.Add(Me.lblTotMon)
        Me.Panel3.Controls.Add(Me.LblTotal)
        Me.Panel3.Controls.Add(Me.picKeyboard)
        Me.Panel3.Controls.Add(Me.LblTipoCambio)
        Me.Panel3.Location = New System.Drawing.Point(974, 515)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(240, 86)
        Me.Panel3.TabIndex = 7
        '
        'lblTotMon
        '
        Me.lblTotMon.BackColor = System.Drawing.Color.Transparent
        Me.lblTotMon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotMon.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblTotMon.Location = New System.Drawing.Point(3, 2)
        Me.lblTotMon.Name = "lblTotMon"
        Me.lblTotMon.Size = New System.Drawing.Size(228, 16)
        Me.lblTotMon.TabIndex = 7
        Me.lblTotMon.Text = "TOTAL"
        '
        'LblTotal
        '
        Me.LblTotal.BackColor = System.Drawing.Color.Transparent
        Me.LblTotal.Font = New System.Drawing.Font("Lucida Sans Unicode", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblTotal.Location = New System.Drawing.Point(4, 21)
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
        Me.picKeyboard.Location = New System.Drawing.Point(3, 197)
        Me.picKeyboard.Name = "picKeyboard"
        Me.picKeyboard.Size = New System.Drawing.Size(42, 35)
        Me.picKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picKeyboard.TabIndex = 49
        Me.picKeyboard.TabStop = False
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTipoCambio.BackColor = System.Drawing.Color.MintCream
        Me.LblTipoCambio.Font = New System.Drawing.Font("Lucida Sans Unicode", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipoCambio.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblTipoCambio.Location = New System.Drawing.Point(5, 59)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(229, 24)
        Me.LblTipoCambio.TabIndex = 41
        Me.LblTipoCambio.Text = "PUNTO DE VENTA"
        Me.LblTipoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.MintCream
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.LblAhorro)
        Me.Panel4.Location = New System.Drawing.Point(974, 477)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(240, 35)
        Me.Panel4.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Lucida Sans Unicode", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(8, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 32)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "AHORRO"
        '
        'LblAhorro
        '
        Me.LblAhorro.BackColor = System.Drawing.Color.Transparent
        Me.LblAhorro.Font = New System.Drawing.Font("Lucida Sans Unicode", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAhorro.ForeColor = System.Drawing.Color.MidnightBlue
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
        Me.Panel5.BackColor = System.Drawing.Color.MintCream
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
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(4, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 23)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "TICKET"
        '
        'LblFolio
        '
        Me.LblFolio.BackColor = System.Drawing.Color.Transparent
        Me.LblFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFolio.ForeColor = System.Drawing.Color.MidnightBlue
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
        Me.LblFechaHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LblFechaHora.ForeColor = System.Drawing.Color.White
        Me.LblFechaHora.Location = New System.Drawing.Point(671, 60)
        Me.LblFechaHora.Name = "LblFechaHora"
        Me.LblFechaHora.Size = New System.Drawing.Size(299, 17)
        Me.LblFechaHora.TabIndex = 11
        Me.LblFechaHora.Text = "Lunes, 31 Marzo"
        Me.LblFechaHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.LightSteelBlue
        Me.LblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.Black
        Me.LblTitulo.Location = New System.Drawing.Point(2, 2)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(186, 57)
        Me.LblTitulo.TabIndex = 12
        Me.LblTitulo.Text = "Selling"
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(4, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 17)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "ATIENDE:"
        '
        'LblUsuario
        '
        Me.LblUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblUsuario.BackColor = System.Drawing.Color.Transparent
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LblUsuario.ForeColor = System.Drawing.Color.White
        Me.LblUsuario.Location = New System.Drawing.Point(203, 66)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(466, 17)
        Me.LblUsuario.TabIndex = 15
        Me.LblUsuario.Text = "JUAN PEREZ"
        '
        'TxtCliente
        '
        Me.TxtCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCliente.Location = New System.Drawing.Point(1014, 112)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(95, 20)
        Me.TxtCliente.TabIndex = 2
        '
        'TxtProducto
        '
        Me.TxtProducto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtProducto.Location = New System.Drawing.Point(1045, 352)
        Me.TxtProducto.Name = "TxtProducto"
        Me.TxtProducto.Size = New System.Drawing.Size(120, 20)
        Me.TxtProducto.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(971, 331)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 16)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "CANT."
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(1046, 331)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 16)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "PRODUCTO:"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(1024, 352)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(16, 16)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "X"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCantidad.Location = New System.Drawing.Point(975, 351)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(48, 20)
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
        'Panel6
        '
        Me.Panel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.BackColor = System.Drawing.Color.MintCream
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.LblCantidadArticulos)
        Me.Panel6.Location = New System.Drawing.Point(974, 394)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(240, 45)
        Me.Panel6.TabIndex = 37
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label9.Location = New System.Drawing.Point(8, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 40)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "CANTIDAD PRODUCTOS"
        '
        'LblCantidadArticulos
        '
        Me.LblCantidadArticulos.BackColor = System.Drawing.Color.Transparent
        Me.LblCantidadArticulos.Font = New System.Drawing.Font("Lucida Sans Unicode", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidadArticulos.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblCantidadArticulos.Location = New System.Drawing.Point(112, 4)
        Me.LblCantidadArticulos.Name = "LblCantidadArticulos"
        Me.LblCantidadArticulos.Size = New System.Drawing.Size(120, 32)
        Me.LblCantidadArticulos.TabIndex = 10
        Me.LblCantidadArticulos.Text = "14"
        Me.LblCantidadArticulos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(976, 375)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(232, 16)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "Presione <TAB> para modificar cantidad."
        '
        'BtnWait
        '
        Me.BtnWait.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnWait.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnWait.Icon = CType(resources.GetObject("BtnWait.Icon"), System.Drawing.Icon)
        Me.BtnWait.Location = New System.Drawing.Point(695, 603)
        Me.BtnWait.Name = "BtnWait"
        Me.BtnWait.Size = New System.Drawing.Size(110, 30)
        Me.BtnWait.TabIndex = 39
        Me.BtnWait.Text = "F1- Espera"
        Me.BtnWait.ToolTipText = "Venta o Cotización en Espera"
        Me.BtnWait.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblStatus
        '
        Me.LblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblStatus.BackColor = System.Drawing.Color.White
        Me.LblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!)
        Me.LblStatus.ForeColor = System.Drawing.Color.Black
        Me.LblStatus.Location = New System.Drawing.Point(189, 2)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(782, 57)
        Me.LblStatus.TabIndex = 40
        Me.LblStatus.Text = "P U N T O - D E - V E N T A"
        Me.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(749, 82)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(221, 16)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "Presione <Ctrl+R> para retiro de Caja"
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCerrar.Icon = CType(resources.GetObject("BtnCerrar.Icon"), System.Drawing.Icon)
        Me.BtnCerrar.Location = New System.Drawing.Point(974, 603)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(110, 30)
        Me.BtnCerrar.TabIndex = 11
        Me.BtnCerrar.Text = "F9- Cerrar"
        Me.BtnCerrar.ToolTipText = "Cierra el Documento Actual"
        Me.BtnCerrar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnVenta
        '
        Me.BtnVenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnVenta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnVenta.Icon = CType(resources.GetObject("BtnVenta.Icon"), System.Drawing.Icon)
        Me.BtnVenta.Location = New System.Drawing.Point(579, 603)
        Me.BtnVenta.Name = "BtnVenta"
        Me.BtnVenta.Size = New System.Drawing.Size(110, 30)
        Me.BtnVenta.TabIndex = 12
        Me.BtnVenta.Text = "F5-  Venta"
        Me.BtnVenta.ToolTipText = "Crea una Pedido o Venta "
        Me.BtnVenta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelaProducto
        '
        Me.BtnCancelaProducto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelaProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancelaProducto.Icon = CType(resources.GetObject("BtnCancelaProducto.Icon"), System.Drawing.Icon)
        Me.BtnCancelaProducto.Location = New System.Drawing.Point(117, 603)
        Me.BtnCancelaProducto.Name = "BtnCancelaProducto"
        Me.BtnCancelaProducto.Size = New System.Drawing.Size(110, 30)
        Me.BtnCancelaProducto.TabIndex = 7
        Me.BtnCancelaProducto.Text = "F12- Deshacer"
        Me.BtnCancelaProducto.ToolTipText = "Cancela Productos del Ticket"
        Me.BtnCancelaProducto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnBusquedaProducto
        '
        Me.BtnBusquedaProducto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBusquedaProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBusquedaProducto.Icon = CType(resources.GetObject("BtnBusquedaProducto.Icon"), System.Drawing.Icon)
        Me.BtnBusquedaProducto.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnBusquedaProducto.Location = New System.Drawing.Point(1168, 342)
        Me.BtnBusquedaProducto.Name = "BtnBusquedaProducto"
        Me.BtnBusquedaProducto.Size = New System.Drawing.Size(46, 31)
        Me.BtnBusquedaProducto.TabIndex = 8
        Me.BtnBusquedaProducto.Text = "F2"
        Me.BtnBusquedaProducto.ToolTipText = "Busqueda y seleccion de producto"
        Me.BtnBusquedaProducto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelaTicket
        '
        Me.BtnCancelaTicket.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelaTicket.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancelaTicket.Icon = CType(resources.GetObject("BtnCancelaTicket.Icon"), System.Drawing.Icon)
        Me.BtnCancelaTicket.Location = New System.Drawing.Point(2, 603)
        Me.BtnCancelaTicket.Name = "BtnCancelaTicket"
        Me.BtnCancelaTicket.Size = New System.Drawing.Size(110, 30)
        Me.BtnCancelaTicket.TabIndex = 6
        Me.BtnCancelaTicket.Text = "F7- Cancelar"
        Me.BtnCancelaTicket.ToolTipText = "Cancela el Ticket"
        Me.BtnCancelaTicket.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblSubTitulo
        '
        Me.LblSubTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSubTitulo.BackColor = System.Drawing.Color.White
        Me.LblSubTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubTitulo.ForeColor = System.Drawing.Color.White
        Me.LblSubTitulo.Location = New System.Drawing.Point(205, 41)
        Me.LblSubTitulo.Name = "LblSubTitulo"
        Me.LblSubTitulo.Size = New System.Drawing.Size(753, 16)
        Me.LblSubTitulo.TabIndex = 46
        Me.LblSubTitulo.Text = "Presione <Ctrl+T> para Convertir a otro Tipo de Documento"
        Me.LblSubTitulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnEnvio
        '
        Me.btnEnvio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEnvio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEnvio.Icon = CType(resources.GetObject("btnEnvio.Icon"), System.Drawing.Icon)
        Me.btnEnvio.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnEnvio.Location = New System.Drawing.Point(347, 603)
        Me.btnEnvio.Name = "btnEnvio"
        Me.btnEnvio.Size = New System.Drawing.Size(110, 30)
        Me.btnEnvio.TabIndex = 48
        Me.btnEnvio.Text = "F8- Entrega"
        Me.btnEnvio.ToolTipText = "Agregar datos de Entrega"
        Me.btnEnvio.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtLimite
        '
        Me.txtLimite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLimite.Enabled = False
        Me.txtLimite.Location = New System.Drawing.Point(136, 183)
        Me.txtLimite.Name = "txtLimite"
        Me.txtLimite.Size = New System.Drawing.Size(94, 20)
        Me.txtLimite.TabIndex = 52
        Me.txtLimite.Text = "0.00"
        Me.txtLimite.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtLimite.Value = 0.0R
        Me.txtLimite.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'txtDias
        '
        Me.txtDias.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDias.Enabled = False
        Me.txtDias.Location = New System.Drawing.Point(136, 210)
        Me.txtDias.Name = "txtDias"
        Me.txtDias.Size = New System.Drawing.Size(48, 20)
        Me.txtDias.TabIndex = 53
        Me.txtDias.Text = "0"
        Me.txtDias.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtDias.Value = 0
        Me.txtDias.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'txtSaldo
        '
        Me.txtSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSaldo.Enabled = False
        Me.txtSaldo.Location = New System.Drawing.Point(136, 237)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(94, 20)
        Me.txtSaldo.TabIndex = 54
        Me.txtSaldo.Text = "0.00"
        Me.txtSaldo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.txtSaldo.Value = 0.0R
        Me.txtSaldo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel8.BackColor = System.Drawing.Color.MintCream
        Me.Panel8.Controls.Add(Me.lblNivelDesc)
        Me.Panel8.Controls.Add(Me.lblMoneda)
        Me.Panel8.Controls.Add(Me.BtnTC)
        Me.Panel8.Controls.Add(Me.lblCteClave)
        Me.Panel8.Controls.Add(Me.btnCliente)
        Me.Panel8.Controls.Add(Me.Label10)
        Me.Panel8.Controls.Add(Me.lblSaldo)
        Me.Panel8.Controls.Add(Me.Label17)
        Me.Panel8.Controls.Add(Me.Label1)
        Me.Panel8.Controls.Add(Me.LblCliente)
        Me.Panel8.Controls.Add(Me.txtSaldo)
        Me.Panel8.Controls.Add(Me.txtLimite)
        Me.Panel8.Controls.Add(Me.txtDias)
        Me.Panel8.Location = New System.Drawing.Point(974, 62)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(241, 266)
        Me.Panel8.TabIndex = 55
        '
        'lblMoneda
        '
        Me.lblMoneda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMoneda.BackColor = System.Drawing.Color.Transparent
        Me.lblMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblMoneda.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblMoneda.Location = New System.Drawing.Point(5, 18)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(101, 20)
        Me.lblMoneda.TabIndex = 114
        Me.lblMoneda.Text = "MONEDA"
        '
        'BtnTC
        '
        Me.BtnTC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnTC.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton
        Me.BtnTC.ContextMenuStrip = Me.CtxTC
        Me.BtnTC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTC.Location = New System.Drawing.Point(112, 10)
        Me.BtnTC.Name = "BtnTC"
        Me.BtnTC.Size = New System.Drawing.Size(126, 28)
        Me.BtnTC.TabIndex = 113
        Me.BtnTC.Text = "MXN"
        Me.BtnTC.ToolTipText = "Elejir Moneda"
        Me.BtnTC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CtxTC
        '
        Me.CtxTC.Name = "CtxDocumentos"
        Me.CtxTC.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.CtxTC.Size = New System.Drawing.Size(61, 4)
        '
        'lblCteClave
        '
        Me.lblCteClave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCteClave.BackColor = System.Drawing.Color.Transparent
        Me.lblCteClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCteClave.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblCteClave.Location = New System.Drawing.Point(3, 109)
        Me.lblCteClave.Name = "lblCteClave"
        Me.lblCteClave.Size = New System.Drawing.Size(205, 24)
        Me.lblCteClave.TabIndex = 59
        '
        'btnCliente
        '
        Me.btnCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCliente.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton
        Me.btnCliente.ContextMenuStrip = Me.CtxCliente
        Me.btnCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCliente.Icon = CType(resources.GetObject("btnCliente.Icon"), System.Drawing.Icon)
        Me.btnCliente.Location = New System.Drawing.Point(186, 44)
        Me.btnCliente.Name = "btnCliente"
        Me.btnCliente.Size = New System.Drawing.Size(52, 32)
        Me.btnCliente.TabIndex = 58
        Me.btnCliente.ToolTipText = "Agrega / Editar Cliente"
        Me.btnCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CtxCliente
        '
        Me.CtxCliente.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemEditarCte, Me.ItemNuevoCte, Me.ItemEdoCuenta})
        Me.CtxCliente.Name = "CtxDocumentos"
        Me.CtxCliente.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.CtxCliente.Size = New System.Drawing.Size(139, 70)
        Me.CtxCliente.Text = "Cliente"
        '
        'ItemEditarCte
        '
        Me.ItemEditarCte.Image = CType(resources.GetObject("ItemEditarCte.Image"), System.Drawing.Image)
        Me.ItemEditarCte.Name = "ItemEditarCte"
        Me.ItemEditarCte.Size = New System.Drawing.Size(138, 22)
        Me.ItemEditarCte.Text = "Modificar"
        Me.ItemEditarCte.ToolTipText = "Editar la información del cliente"
        '
        'ItemNuevoCte
        '
        Me.ItemNuevoCte.Image = Global.Selling.My.Resources.Resources._1399173015_106230
        Me.ItemNuevoCte.Name = "ItemNuevoCte"
        Me.ItemNuevoCte.Size = New System.Drawing.Size(138, 22)
        Me.ItemNuevoCte.Text = "Nuevo"
        Me.ItemNuevoCte.ToolTipText = "Agrega un nuevo cliente"
        '
        'ItemEdoCuenta
        '
        Me.ItemEdoCuenta.Image = Global.Selling.My.Resources.Resources._1431714849_application
        Me.ItemEdoCuenta.Name = "ItemEdoCuenta"
        Me.ItemEdoCuenta.Size = New System.Drawing.Size(138, 22)
        Me.ItemEdoCuenta.Text = "Edo. Cuenta"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label10.Location = New System.Drawing.Point(1, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 20)
        Me.Label10.TabIndex = 56
        Me.Label10.Text = "CTE:"
        '
        'lblSaldo
        '
        Me.lblSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSaldo.BackColor = System.Drawing.Color.Transparent
        Me.lblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblSaldo.Location = New System.Drawing.Point(3, 237)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(115, 24)
        Me.lblSaldo.TabIndex = 56
        Me.lblSaldo.Text = "Saldo "
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label17.Location = New System.Drawing.Point(3, 210)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(115, 24)
        Me.Label17.TabIndex = 56
        Me.Label17.Text = "Días Crédito"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(3, 183)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 24)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Limite Crédito"
        '
        'LblCliente
        '
        Me.LblCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCliente.BackColor = System.Drawing.Color.Transparent
        Me.LblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblCliente.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblCliente.Location = New System.Drawing.Point(3, 138)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(236, 40)
        Me.LblCliente.TabIndex = 56
        Me.LblCliente.Text = "JUAN PEREZ "
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
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.GridDetalle.GroupByBoxVisible = False
        Me.GridDetalle.Location = New System.Drawing.Point(2, 116)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(969, 485)
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
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(4, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 17)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "SURTIR EN:"
        '
        'BtnAddenda
        '
        Me.BtnAddenda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAddenda.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAddenda.Enabled = False
        Me.BtnAddenda.Image = Global.Selling.My.Resources.Resources._1452579623_paper_clip
        Me.BtnAddenda.Location = New System.Drawing.Point(233, 603)
        Me.BtnAddenda.Name = "BtnAddenda"
        Me.BtnAddenda.Size = New System.Drawing.Size(110, 30)
        Me.BtnAddenda.TabIndex = 60
        Me.BtnAddenda.Text = "Complemento"
        Me.BtnAddenda.ToolTipText = "Agregar o Modificar Información Complementaria"
        Me.BtnAddenda.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnBuscaCte
        '
        Me.btnBuscaCte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscaCte.Icon = CType(resources.GetObject("btnBuscaCte.Icon"), System.Drawing.Icon)
        Me.btnBuscaCte.Image = CType(resources.GetObject("btnBuscaCte.Image"), System.Drawing.Image)
        Me.btnBuscaCte.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnBuscaCte.Location = New System.Drawing.Point(1113, 106)
        Me.btnBuscaCte.Name = "btnBuscaCte"
        Me.btnBuscaCte.Size = New System.Drawing.Size(44, 32)
        Me.btnBuscaCte.TabIndex = 47
        Me.btnBuscaCte.Text = "F3"
        Me.btnBuscaCte.ToolTipText = "Busqueda de Cliente"
        Me.btnBuscaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Sp_detalle_openTableAdapter
        '
        Me.Sp_detalle_openTableAdapter.ClearBeforeFill = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.Icon = CType(resources.GetObject("btnSalir.Icon"), System.Drawing.Icon)
        Me.btnSalir.Location = New System.Drawing.Point(1104, 603)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(110, 30)
        Me.btnSalir.TabIndex = 81
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.ToolTipText = "Cerrar Punto  de Venta"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnConvertir
        '
        Me.BtnConvertir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnConvertir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConvertir.Icon = CType(resources.GetObject("BtnConvertir.Icon"), System.Drawing.Icon)
        Me.BtnConvertir.Location = New System.Drawing.Point(463, 603)
        Me.BtnConvertir.Name = "BtnConvertir"
        Me.BtnConvertir.Size = New System.Drawing.Size(110, 30)
        Me.BtnConvertir.TabIndex = 82
        Me.BtnConvertir.Text = "F4- Cambiar"
        Me.BtnConvertir.ToolTipText = "Cambiar Tipo de documento"
        Me.BtnConvertir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'txtVendedor
        '
        Me.txtVendedor.Location = New System.Drawing.Point(102, 64)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Size = New System.Drawing.Size(95, 20)
        Me.txtVendedor.TabIndex = 83
        '
        'btnPreview
        '
        Me.btnPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPreview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPreview.Icon = CType(resources.GetObject("btnPreview.Icon"), System.Drawing.Icon)
        Me.btnPreview.Location = New System.Drawing.Point(811, 603)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(39, 30)
        Me.btnPreview.TabIndex = 84
        Me.btnPreview.ToolTipText = "Exporta el detalle del documento a Excel"
        Me.btnPreview.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbSucursal
        '
        Me.cmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSucursal.Enabled = False
        Me.cmbSucursal.Location = New System.Drawing.Point(101, 89)
        Me.cmbSucursal.MaximumSize = New System.Drawing.Size(298, 0)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(298, 21)
        Me.cmbSucursal.TabIndex = 58
        '
        'btnCortar
        '
        Me.btnCortar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCortar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCortar.Icon = CType(resources.GetObject("btnCortar.Icon"), System.Drawing.Icon)
        Me.btnCortar.Location = New System.Drawing.Point(856, 603)
        Me.btnCortar.Name = "btnCortar"
        Me.btnCortar.Size = New System.Drawing.Size(39, 30)
        Me.btnCortar.TabIndex = 85
        Me.btnCortar.ToolTipText = "Corta todos los productos del documento actual"
        Me.btnCortar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnPegar
        '
        Me.btnPegar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPegar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPegar.Icon = CType(resources.GetObject("btnPegar.Icon"), System.Drawing.Icon)
        Me.btnPegar.Location = New System.Drawing.Point(901, 603)
        Me.btnPegar.Name = "btnPegar"
        Me.btnPegar.Size = New System.Drawing.Size(39, 30)
        Me.btnPegar.TabIndex = 86
        Me.btnPegar.ToolTipText = "Pega todos los productos cortados"
        Me.btnPegar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(449, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 17)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "CANAL"
        '
        'cmbTipoCanal
        '
        Me.cmbTipoCanal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTipoCanal.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoCanal.ItemHeight = 13
        Me.cmbTipoCanal.Location = New System.Drawing.Point(510, 87)
        Me.cmbTipoCanal.Name = "cmbTipoCanal"
        Me.cmbTipoCanal.Size = New System.Drawing.Size(204, 21)
        Me.cmbTipoCanal.TabIndex = 87
        '
        'lblNivelDesc
        '
        Me.lblNivelDesc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNivelDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblNivelDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNivelDesc.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblNivelDesc.Location = New System.Drawing.Point(5, 82)
        Me.lblNivelDesc.Name = "lblNivelDesc"
        Me.lblNivelDesc.Size = New System.Drawing.Size(227, 24)
        Me.lblNivelDesc.TabIndex = 115
        '
        'FrmTPV
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1217, 634)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbTipoCanal)
        Me.Controls.Add(Me.btnPegar)
        Me.Controls.Add(Me.btnCortar)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.txtVendedor)
        Me.Controls.Add(Me.BtnConvertir)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.BtnAddenda)
        Me.Controls.Add(Me.cmbSucursal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GridDetalle)
        Me.Controls.Add(Me.btnEnvio)
        Me.Controls.Add(Me.btnBuscaCte)
        Me.Controls.Add(Me.LblSubTitulo)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.BtnWait)
        Me.Controls.Add(Me.TxtCantidad)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtProducto)
        Me.Controls.Add(Me.TxtCliente)
        Me.Controls.Add(Me.BtnCerrar)
        Me.Controls.Add(Me.BtnVenta)
        Me.Controls.Add(Me.BtnCancelaProducto)
        Me.Controls.Add(Me.BtnCancelaTicket)
        Me.Controls.Add(Me.BtnBusquedaProducto)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.LblFechaHora)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmTPV"
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    'Public Enum Status
    '    Original = -1
    '    Cerrado = 0
    '    Abierto = 1
    '    Picking = 2
    'End Enum
    Public Padre As String
    Private AplicaPromocionFinal As Integer = 1

    Private bMessage As Boolean = True
    Private dtPortaPapeles As DataTable
    Private LimitaCompraEmp As Integer = 0


    Public numMostrador As Integer

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
    Private TallaColor As Integer = 0
    Private MaskCte As Integer = 0
    Private SincronizaCte As Integer = 0
    Private BuscaNegados As Integer = 0

    Private Enum TipoMov
        Entrada = 1
        Salida = 2
    End Enum

    Public TipoCanal As Integer = 0
    Private ValorMaxPedido As Decimal
    Public VentaAbierta As Boolean = False
    Public ConfirmarAbono As Integer = 0
    Public Remoto As Integer = 0
    Public BloquearPrecio As Integer = 0
    Public ImprimirRemoto As Integer = 0
    Public sFrase As String
    Public Display As Boolean = False
    Public BaudRate As Integer
    Public MaxCaracteres As Integer
    Public NoLineas As Integer
    Public Port As String
    Public ActivarCotizacion As Boolean = True
    Public Picking, Packing, ticketPicking As Boolean
    Public SurtidoRF As Boolean
    Public MostradorRF As Boolean
    Private TipoSucursal As Integer
    Private SucursalPadre, TIKClave, SucursalClave As String
    Public TImpuesto As Integer
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
    Public TipoVenta As Integer 'Determina si la venta predeterminada es Contado=0 o Credito=1
    Public PrintGeneric As Boolean
    Public Impresora As String 'Impresora de Tickets
    Public Ticket As String 'Plantilla de Ticket
    Public NumCopias As Integer 'Determina el numero de copias a imprimir para documentos nuevos
    Public Caja As Boolean ' Activa al punto de venta con su caja
    Public CAJClave As String 'Clave de la Caja
    Public Redondeo As Boolean 'Aplica programa de redondeo
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
    Public CTEClaveInicial As String 'Identificador de Cliente Inicial
    Public CTENombreInicial As String 'Nombre de Cliente Inicial
    Public CTEClaveActual As String 'Identificador de Cliente Actual
    Public CTENombreActual As String 'Nombre de Cliente Actual
    Public Folio As Integer = -1
    Public VentaNueva As Boolean = True
    Public GeneraMovSalida As Boolean = False
    Public SolicitaVendedor As Boolean 'Solicita vendedor al crear venta
    Public VENClave As String = "" 'Identificador de la Venta
    Public SaldoVenta As Double = 0.0
    Public TotalAhorro As Double = 0.0
    Public TotalArticulos As Double = 0.0
    Public TotalPuntos As Decimal = 0.0
    Public TotalVenta As Decimal = 0.0
    Public VentaCerrada As Boolean = True
    Public ListaPrecio As String
    Public DescuentoCliente As Integer
    Public PorcDescCliente As Double
    Public TotalRecibido As Double = 0.0
    Public TotalCambio As Double = 0.0
    'Public FormaPago As Integer
    Public TipoDesCte As Integer
    Public DESClave As String
    Public TipoDocumento As Integer
    Public EstadoDocumento As Integer

    Public Vendedor As String
    Public CtaMaestra As String
    Public LimiteCredito As Decimal
    Public DiasCredito As Integer
    Public SaldoCte As Decimal
    Public CobranzaVenta As Boolean = False
    Public sFolio As String = "-"

    Private CambiarCliente As Boolean = False
    Private TipoEntrega As Integer = 1
    Private AlmacenSurtido As String  'Clave del almacén surtido
    Private SUCClave As String = "" 'SUCURSAL
    Private bLoad As Boolean = False
    Private Cantidad As Double = 1
    ' Private PorcImpProducto As Double
    Private Autoriza As String
    Private MaxEfectivo As Double 'Maximo Efectivo en Caja
    Private MaxCheques As Double 'Maximo Cheques en Caja
    Private MaxVales As Double 'Maximo Vales en Caja
    Private CajaClave As String
    Private CajaTICDevolucion As String
    Private CajaNombre As String
    Private Cajon As Boolean = False
    Private CreditoDisponible As Double = 0.0
    Private sGTIN As String = ""
    Private NotaCreditos As String = ""
    Private MonedaCambio As String
    Private InterfazSalida As String = ""
    Private Moneda, MonedaActual As String
    Private MonedaRef, MonRefBase, MonedaDesc, MonDescCambio, MonRefCambio As String
    Private TipoCambio, MonTipoCambio As Decimal
    Private Aplicacion As String = ""
    Private mySerialPort As New SerialPort
    Private sAlmacen As String = ""
    Private url_imagen As String
    Private Periodo, Mes As Integer
    Private bCierreApertura As Boolean = False
    Private dtPedidoDetalle As DataTable
    Private bComplemento As Boolean = False
    Private iDesglosarPrecio As Integer = 0
    Private UltimoCodigo As String = ""
    Private FormatoPedido As String
    Private dtCombo As DataTable

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

    Private Function AddModelo(ByVal Modelo As String, ByVal dCantidad As Double) As Boolean
        Dim msg As String = ""
        Dim esModelo As Boolean = False

        If cmbSucursal.SelectedValue Is Nothing Then
            msg = "!Debe especificar la sucursal que realizara el surtido¡"
            esModelo = True


        ElseIf cmbTipoCanal.SelectedValue Is Nothing Then
            msg = "!Debe seleccionar un Canal de Venta¡"
            esModelo = True

        ElseIf VentaCerrada = False Then

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

                        Dim r As Integer
                        For r = 1 To dCantidad
                            ' dCantidad = 1
                            PROClaveKIT = CStr(dt.Rows(0)("PROClave"))
                            Dim dtMultiproducto As DataTable = ModPOS.Recupera_Tabla("sp_muestra_multiproductos", "@ProductoPadre", dt.Rows(0)("PROClave"))
                            ' Si el produto es combo  TProducto = 7
                            If dtMultiproducto.Rows.Count > 0 Then
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
                                            Dim a As New FrmTallaColor
                                            a.iColorFijo = dtMultiproducto.Rows(j)("iColor")
                                            a.SUCClave = SUCClave
                                            a.CTEClave = CTEClaveActual
                                            a.PREClave = ListaCombo
                                            a.sModelo = dtMultiproducto.Rows(j)("Modelo")
                                            a.ALMClave = ALMClave
                                            a.ShowDialog()
                                            If a.DialogResult = Windows.Forms.DialogResult.OK Then
                                                'Valida existencia 
                                                If AddCombo(a.PROClave, a.Clave, dtMultiproducto.Rows(j)("Cantidad"), a.PrecioBruto, ListaCombo, a.Preventa) = False Then
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
                                                Dim a As New FrmTallaColor
                                                a.iColorFijo = dtMultiproducto.Rows(j)("iColor")
                                                a.SUCClave = SUCClave
                                                a.CTEClave = CTEClaveActual
                                                a.PREClave = ListaCombo
                                                a.sModelo = dtMultiproducto.Rows(j)("Modelo")
                                                a.ALMClave = ALMClave
                                                a.ShowDialog()
                                                If a.DialogResult = Windows.Forms.DialogResult.OK Then
                                                    iTalla = a.Talla
                                                    'Valida existencia 
                                                    If AddCombo(a.PROClave, a.Clave, dtMultiproducto.Rows(j)("Cantidad"), a.PrecioBruto, ListaCombo, a.Preventa) = False Then
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
                                        AgregaGTIN(dtCombo.Rows(j)("Clave"), True, False, True, dtCombo.Rows(j)("Cantidad"), #1/1/1900#, #1/1/1900#, True, True, 0, "", dtCombo.Rows(j)("PREClave"), dtCombo.Rows(j)("Precio"), IdKit, PROClaveKIT)
                                    Next

                                    frmStatusMessage.Dispose()
                                    msg = "OK"
                                Else
                                    dtCombo.Clear()
                                    msg = "No se encontro existencia disponible suficiente para el paquete actual"
                                End If
                                esModelo = True
                            Else
                                msg = "El Modelo no cuenta con detalle de productos definidos"
                                esModelo = True
                            End If
                        Next
                    Else
                        'Si es un producto convencional 

                        If CDbl(dt.Rows(0)("Talla")) = 0 AndAlso CDbl(dt.Rows(0)("Color")) = 0 Then
                            AgregaGTIN(CStr(dt.Rows(0)("Clave")), True, False, True, dCantidad)
                            msg = "OK"
                            esModelo = True
                        Else
                            Dim a As New FrmTallaColor
                            a.SUCClave = SUCClave
                            a.CTEClave = CTEClaveActual
                            a.PREClave = ListaPrecio
                            a.sModelo = dt.Rows(0)("Modelo")
                            a.ALMClave = ALMClave
                            a.ShowDialog()
                            If a.DialogResult = Windows.Forms.DialogResult.OK Then
                                AgregaGTIN(a.Clave, True, False, True, dCantidad, #1/1/1900#, #1/1/1900#, True, True)
                                msg = "OK"
                                esModelo = True
                            End If
                        End If
                    End If
                Else
                    msg = "El Modelo no es valido o no existe"
                    esModelo = False
                End If
            Else
                msg = "No se ha especificado algun Producto o Modelo"
                esModelo = True
            End If

        Else
            msg = "El Pedido se encuentra Cerrado"
            esModelo = True
        End If

        If esModelo = True AndAlso msg <> "OK" Then
            MessageBox.Show(msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return esModelo

    End Function

    Public Sub btnVentaPerformClick(ByVal Buscar As String)
        sGTIN = Buscar
        Me.BtnVenta.PerformClick()
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

    Private Sub ObtenerFolio()
        ' If tmp = False Then
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
        'Else
        '    FolioTmp += 1
        '    LblFolio.Text = "T-" & Referencia & "-" & CStr(numMostrador + 1) & "-" & CStr(Today.DayOfYear) & "-" & CStr(FolioTmp)
        'End If

    End Sub

    Private Sub VentaContado()
        If VentaCerrada Then

            Dim dt As DataTable

            If AlmacenSurtido = "" OrElse AlmacenSurtido Is Nothing Then
                Beep()
                MessageBox.Show("No es posible crear una nueva venta debido a que no se ha especificado el Almacen para surtido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Exit Sub
            End If


            cmbTipoCanal.SelectedValue = TipoCanal

            If cmbTipoCanal.SelectedValue Is Nothing Then
                Beep()
                MessageBox.Show("No es posible crear una nueva venta debido a que no se ha especificado el Canal de Venta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            If SolicitaVendedor Then
                Dim a As New FrmSolicitaUsuario
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    Me.AtiendeNombre = a.AtiendeNombre
                    Me.ReferenciaUsr = a.ReferenciaUsr
                    Me.AtiendeClave = a.AtiendeClave
                    LblUsuario.Text = AtiendeNombre
                Else
                    MessageBox.Show("No es posible crear una nueva venta debido a que no se ha sido registrado un Vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                a.Dispose()

            End If

            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
            BtnTC.Text = dt.Rows(0)("Referencia")
            MonedaRef = dt.Rows(0)("Referencia")
            MonedaDesc = dt.Rows(0)("Descripcion")
            TipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
            dt.Dispose()


            If Moneda <> MonedaCambio Then
                dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
                MonRefCambio = dt.Rows(0)("Referencia")
                MonDescCambio = dt.Rows(0)("Descripcion")
                MonTipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
                dt.Dispose()

            Else
                MonRefCambio = MonedaRef
                MonDescCambio = MonedaDesc
                MonTipoCambio = TipoCambio
            End If


            MonedaActual = Moneda


            TipoDocumento = 1

            EstadoDocumento = 1

            modificaStatus(TipoDocumento, EstadoDocumento)

            If CambiarCliente = False Then
                btnBuscaCte.Enabled = True
                TxtCliente.Enabled = True
                cmbTipoCanal.Enabled = True
                BtnTC.Enabled = True
                CambiarCliente = True
            End If

            recuperaCliente(CTEClaveActual)

            ObtenerFolio()

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
            "@TipoCanal", cmbTipoCanal.SelectedValue, _
            "@Usuario", ModPOS.UsuarioActual)



            btnBuscaCte.Enabled = True
            BtnCancelaProducto.Enabled = True
            BtnCancelaTicket.Enabled = True
            btnEnvio.Enabled = True
            BtnCerrar.Enabled = True
            TxtCantidad.Enabled = True
            TxtProducto.Enabled = True
            TxtCliente.Enabled = True
            cmbTipoCanal.Enabled = True
            BtnTC.Enabled = True
            VentaCerrada = False
            GeneraMovSalida = True
            VentaNueva = True
            BtnConvertir.Enabled = True
            BtnWait.Enabled = True
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


            lblMoneda.Text = "T.C. " & Format(CStr(ModPOS.Redondear(TipoCambio, 2)), "Currency")
            lblTotMon.Text = "TOTAL (" & MonedaRef.ToUpper.Trim & ")"
            If Moneda <> MonedaCambio Then
                If MonedaActual <> Moneda Then

                    If TipoCambio > 0 Then
                        LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                    End If
                Else
                    If MonTipoCambio > 0 Then
                        LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                    End If
                End If
            Else
                If MonedaActual <> Moneda Then

                    If TipoCambio > 0 Then
                        LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                    End If
                Else
                    LblTipoCambio.Text = ""
                End If
            End If

           


            If sGTIN <> "" Then
                AgregaGTIN(sGTIN, True, False, False)
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

            cmbTipoCanal.SelectedValue = TipoCanal

            If cmbTipoCanal.SelectedValue Is Nothing Then
                Beep()
                MessageBox.Show("No es posible crear una nueva venta debido a que no se ha especificado el Canal de Venta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            Dim dt As DataTable

            If SolicitaVendedor Then
                Dim a As New FrmSolicitaUsuario
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    Me.AtiendeNombre = a.AtiendeNombre
                    Me.ReferenciaUsr = a.ReferenciaUsr
                    Me.AtiendeClave = a.AtiendeClave
                    LblUsuario.Text = AtiendeNombre
                Else
                    CTEClaveActual = CTEClaveInicial
                    CTENombreActual = CTENombreInicial
                    LblCliente.Text = CTENombreActual
                    MessageBox.Show("No es posible crear una nueva venta debido a que no se ha sido registrado un Vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                a.Dispose()

            End If

            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
            BtnTC.Text = dt.Rows(0)("Referencia")
            MonedaRef = dt.Rows(0)("Referencia")
            MonedaDesc = dt.Rows(0)("Descripcion")
            TipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
            dt.Dispose()


            If Moneda <> MonedaCambio Then
                dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
                MonRefCambio = dt.Rows(0)("Referencia")
                MonDescCambio = dt.Rows(0)("Descripcion")
                MonTipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
                dt.Dispose()

            Else
                MonRefCambio = MonedaRef
                MonDescCambio = MonedaDesc
                MonTipoCambio = TipoCambio
            End If


            MonedaActual = Moneda



            TipoDocumento = 3

            EstadoDocumento = 1


            modificaStatus(TipoDocumento, EstadoDocumento)


            If CambiarCliente = False Then
                btnBuscaCte.Enabled = True
                TxtCliente.Enabled = True
                cmbTipoCanal.Enabled = True
                BtnTC.Enabled = True
                CambiarCliente = True
            End If

            ObtenerFolio()

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
            "@TipoCanal", cmbTipoCanal.SelectedValue, _
            "@Usuario", ModPOS.UsuarioActual)

            btnBuscaCte.Enabled = True
            BtnCancelaProducto.Enabled = True
            BtnCancelaTicket.Enabled = True
            btnEnvio.Enabled = True
            BtnCerrar.Enabled = True
            TxtCantidad.Enabled = True
            TxtProducto.Enabled = True
            TxtCliente.Enabled = True
            cmbTipoCanal.Enabled = True
            BtnTC.Enabled = True
            VentaCerrada = False
            GeneraMovSalida = True
            VentaNueva = True
            BtnConvertir.Enabled = True
            BtnWait.Enabled = True
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


            lblMoneda.Text = "T.C. " & Format(CStr(ModPOS.Redondear(TipoCambio, 2)), "Currency")
            lblTotMon.Text = "TOTAL (" & MonedaRef.ToUpper.Trim & ")"
            If Moneda <> MonedaCambio Then
                If MonedaActual <> Moneda Then

                    If TipoCambio > 0 Then
                        LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                    End If
                Else
                    If MonTipoCambio > 0 Then
                        LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                    End If
                End If
            Else
                If MonedaActual <> Moneda Then

                    If TipoCambio > 0 Then
                        LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                    End If
                Else
                    LblTipoCambio.Text = ""
                End If
            End If

            If TallaColor = 0 Then
                If CTEClaveActual = CreditoGeneral Then
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


                        recuperaCliente(CTEClaveActual)

                        If NotaCreditos <> "" Then
                            ModPOS.Ejecuta("sp_actualiza_notavta", "@VENClave", VENClave, "@Nota", NotaCreditos)
                        End If

                    Else
                        CTEClaveActual = CTEClaveInicial
                        CTENombreActual = CTENombreInicial
                        LblCliente.Text = CTENombreActual
                        MessageBox.Show("No es posible crear una venta a crédito debido a que no se ha especificado al cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    b.Dispose()
                End If

            End If

           If TipoVenta <> 0 Then
                If convierteDocumento(3) = False Then
                    MessageBox.Show("No se cumplieron las condiciones para crear una venta a Crédito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    convierteDocumento(1)
                End If
            End If

            If sGTIN <> "" Then
                AgregaGTIN(sGTIN, True, False, False)
                sGTIN = ""
            End If

        Else
            Beep()
            MessageBox.Show("No es posible crear una nueva venta debido a que la venta actual no ha sido Cerrada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        TxtProducto.Focus()
    End Sub

    Private Sub FrmTPDV_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not VentaCerrada Then
            Beep()
            Select Case MessageBox.Show("La Venta actual no ha sido Cerrada, ¿Desea Cancelarla?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.No
                    e.Cancel = True
                Case DialogResult.Yes
                    BtnCancelaTicket.PerformClick()
                    If Not VentaCerrada Then
                        e.Cancel = True
                    Else
                        ModPOS.PreVenta = Nothing
                        If Not MtoVenta Is Nothing Then
                            MtoVenta.ActualizaGridTransac()
                        End If
                    End If

            End Select
        Else
            ModPOS.PreVenta = Nothing
            If Not MtoVenta Is Nothing Then
                MtoVenta.ActualizaGridTransac()
            End If
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

                    btnEnvio.Enabled = True

                    TipoDocumento = 1

                    ModPOS.Ejecuta("sp_actualiza_venta_open", _
                    "@VENClave", VENClave, _
                    "@Cliente", CTEClaveActual, _
                    "@Tipo", TipoDocumento)



                    modificaStatus(TipoDocumento, EstadoDocumento)
                    'cambiaStatus("VTA. CONTADO (ABIERTA)", Status.Abierto)

                ElseIf TipoDocumento = 2 Then

                    ConvierteCotizacion(1)

                End If

            Case 2
                If VentaCerrada = False Then
                    actualizaExistencia(TipoMov.Salida)

                    TipoDocumento = 2


                    ModPOS.Ejecuta("sp_actualiza_venta_open", _
                    "@VENClave", VENClave, _
                    "@Cliente", CTEClaveActual, _
                    "@Tipo", TipoDocumento)


                    btnEnvio.Enabled = True

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
                        
                        recuperaCliente(CTEClaveActual)

                        'Validar Limite de Credito

                        Dim iValidaCredito As Integer

                        iValidaCredito = ModPOS.ValidaCredido(CtaMaestra, LimiteCredito, DiasCredito, TotalVenta, TipoCambio)

                        If iValidaCredito = 0 Then
                            Return False
                        ElseIf iValidaCredito = -1 Then
                            CreditoDisponible = ModPOS.recuperaDatosCredito(CtaMaestra)
                            If CreditoDisponible < (TotalVenta * TipoCambio) Then
                                MessageBox.Show("El limite de crédito disponible es de " & Format(CStr(ModPOS.Redondear(CreditoDisponible, 2)), "Currency") & ", la venta actual lo sobrepasa por " & Format(CStr(ModPOS.Redondear((TotalVenta * TipoCambio) - CreditoDisponible, 2)), "Currency"), "Información", MessageBoxButtons.OK)
                                Return False
                            End If

                            If DiasCredito <= 0 Then
                                MessageBox.Show("El Cliente no cuenta con dias de credito definidos", "Información", MessageBoxButtons.OK)
                                Return False
                            End If



                        End If



                    End If

                    If TipoDocumento = 2 Then
                        actualizaExistencia(TipoMov.Entrada)
                    End If


                    btnEnvio.Enabled = True

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

                    btnEnvio.Enabled = False

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
                End If
        End Select

        Return True
    End Function

    Private Sub GridDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles GridDetalle.KeyDown, TxtProducto.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            If VentaCerrada = False Then
                If Clipboard.GetText.Split(vbNewLine)(0).Split(vbTab).Length = 2 Then
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
                        MessageBox.Show("No se puede agregar producto ya que el Documento actual no se encuentra Abierto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dt.Dispose()
                        Exit Sub
                    End If
                    dt.Dispose()

                    Dim item() As String
                    Dim frmStatusMessage As New frmStatus
                    Try
                        frmStatusMessage.Show("Procesando información...")
                        For Each linea As String In Clipboard.GetText.Split(vbNewLine)
                            item = linea.Trim.Split(vbTab)

                            If item.Length > 0 Then
                                If item.Length = 2 Then
                                    If Not IsDBNull(item(0)) AndAlso Not IsDBNull(item(1)) Then
                                        If IsNumeric(item(1)) Then
                                           
                                            AgregaGTIN(CStr(item(0)).Trim, True, False, False, CDbl(item(1)), #1/1/1900#, #1/1/1900#, True, True)
                                           
                                        Else
                                            frmStatusMessage.Close()
                                            MessageBox.Show("La informacion de la segunda columna no es un valor numerico valido, el sistema espera que se proporcione la Cantidad de producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            Exit For
                                        End If
                                    End If

                                End If
                            End If

                        Next
                        frmStatusMessage.Close()
                    Catch ex As Exception
                        frmStatusMessage.Close()
                        MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try
                End If
            Else
                MessageBox.Show("Solo se puede agregar producto a un Documento que se encuentra Abierto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        ElseIf e.Control AndAlso e.KeyCode = Keys.Oemplus Then
            If VentaCerrada = False Then
                If GridDetalle.GetValue("Baja") = 0 Then
                  
                    AgregaGTIN(GridDetalle.GetValue("Clave"), True, False, True, 1, #1/1/1900#, #1/1/1900#, True, True, 0, GridDetalle.GetValue("DVEClave"))
            
                End If
            End If
        ElseIf e.Control AndAlso e.KeyCode = Keys.OemMinus Then
            If VentaCerrada = False Then
                If GridDetalle.GetValue("Baja") = 0 AndAlso GridDetalle.GetValue("Cantidad") > 1 Then

                    AgregaGTIN(GridDetalle.GetValue("Clave"), False, False, True, GridDetalle.GetValue("Cantidad") - 1, #1/1/1900#, #1/1/1900#, True, True, 0, GridDetalle.GetValue("DVEClave"))

                End If
            End If
        End If
    End Sub

    Private Sub Controls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, BtnBusquedaProducto.KeyUp, BtnCancelaProducto.KeyUp, BtnCerrar.KeyUp, BtnVenta.KeyUp, TxtCantidad.KeyUp, TxtCliente.KeyUp, BtnCancelaTicket.KeyUp, btnBuscaCte.KeyUp, TxtProducto.KeyUp, BtnWait.KeyUp, btnEnvio.KeyUp, GridDetalle.KeyUp

        If e.Control = True AndAlso e.KeyCode = Keys.T AndAlso (VentaCerrada = False OrElse TipoDocumento = 2) Then

            If cmbSucursal.SelectedValue Is Nothing Then
                MessageBox.Show("!Debe especificar la sucursal que realizara el surtido¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim a As New FrmMenuT
            a.TipoDocumento = Me.TipoDocumento
            a.ActivarCotizacion = Me.ActivarCotizacion
            If a.ShowDialog = Windows.Forms.DialogResult.OK Then

                If VentaCerrada = True AndAlso (Periodo <> Today.Year OrElse Mes <> Today.Month) Then
                    MessageBox.Show("Solo es posible convertir documento dentro del mismo Año y Mes que fueron creados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                convierteDocumento(a.NewTipoDocumento)
            End If
            Exit Sub
        End If

        If Caja AndAlso e.Control = True AndAlso e.KeyCode = Keys.R Then

                Dim a As New FrmRetiroCaja
                a.SUCClave = SucursalSurtido
                a.ALMClave = ALMClave
                a.CAJClave = CAJClave
                a.Referencia = CajaClave
                a.Impresora = Impresora
                a.Generic = PrintGeneric
                a.Ticket = Ticket
                a.Cajon = Cajon
                a.ShowDialog()
           
        ElseIf e.KeyCode = Keys.Space Then
            If TxtProducto.Text = " " AndAlso UltimoCodigo <> "" Then
                TxtProducto.Text = UltimoCodigo
            End If
        Else
            Select Case e.KeyCode
                Case Is = Keys.Escape
                    Me.Close()
                Case Is = Keys.F1
                    Me.BtnWait.PerformClick()
                Case Is = Keys.F2
                    Me.BtnBusquedaProducto.PerformClick()
                Case Is = Keys.F3
                    Me.btnBuscaCte.PerformClick()
                Case Is = Keys.F4
                    Me.BtnConvertir.PerformClick()
                Case Is = Keys.F5
                    Me.BtnVenta.PerformClick()
                Case Is = Keys.F7
                    Me.BtnCancelaTicket.PerformClick()
                Case Is = Keys.F8
                    Me.btnEnvio.PerformClick()
                Case Is = Keys.F9
                    BtnCerrar.PerformClick()
                Case Is = Keys.F12
                    Me.BtnCancelaProducto.PerformClick()
                Case Is = Keys.Right
                    If CStr(sender.Name) = "TxtProducto" Then
                        If VentaCerrada = False Then
                            'Si el campo cantidad esta vacio lo cambia a 1 por defecto
                            If TxtCantidad.Text = vbNullString OrElse CDbl(TxtCantidad.Text) <= 0 Then
                                Cantidad = 1
                                TxtCantidad.Text = "1"
                            End If
                            'Si es el primer articulo, recupera la lista de precio del cliente actual

                            If cmbTipoCanal.SelectedValue Is Nothing Then
                                MessageBox.Show("Debe seleccionar un Canal de Venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
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


                            If TotalArticulos = 0 Then
                                Dim dtCliente As DataTable
                                dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", sCliente, "@TipoCanal", cmbTipoCanal.SelectedValue)
                                If dtCliente.Rows.Count > 0 Then
                                    ListaPrecio = dtCliente.Rows(0)("PREClave")
                                    ' TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                                    dtCliente.Dispose()
                                Else
                                    dtCliente.Dispose()
                                    MessageBox.Show("El Cliente No cuenta con Precio para el Canal de Venta seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                End If

                                'Recupera los descuentos de cliente

                                '    DescuentoCliente = -1
                                '    PorcDescCliente = 0
                                '    TipoDesCte = 0
                                '    DESClave = ""

                            End If
                            'Busca y recupera los datos del producto

                            Dim a As New FrmBuscaProducto
                            a.TipoCambio = TipoCambio
                            a.bVentaConvencional = True
                            a.numMostrador = Me.numMostrador
                            a.url_imagen = Me.url_imagen
                            a.SUCClave = Me.SUCClave
                            a.ClienteActual = sCliente
                            a.PuntodeVenta = PDVClave
                            a.Almacen = AlmacenSurtido
                            a.ListadePrecio = ListaPrecio
                            a.StatusVenta = VentaCerrada
                            a.TImpuesto = TImpuesto
                            a.BusquedaInicial = True
                            a.Busqueda = TxtProducto.Text.Trim.ToUpper
                            a.TxtAlmacen.Text = sAlmacen
                            a.bMessage = Me.bMessage
                            a.ModificaPrecioServicio = Me.ModificaPrecioServicio
                            a.ShowDialog()
                            a.Dispose()
                            TxtProducto.Focus()

                            Me.bMessage = False

                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub FrmTPDV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtCombo = ModPOS.CrearTabla("Combo", _
                                  "Clave", "System.String", _
                                  "Cantidad", "System.Decimal", _
                                   "Precio", "System.Decimal", _
                                   "PREClave", "System.String"
                                  )


        dtPortaPapeles = ModPOS.CrearTabla("PortaPapeles", _
         "Clave", "System.String", _
         "Cantidad", "System.Double", _
         "Descuento", "System.Double")


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


        Dim i As Integer



        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me

            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "CobranzaVenta"
                        CobranzaVenta = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", False, dt.Rows(i)("Valor"))
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
                    Case "TallaColor"
                        TallaColor = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))

                    Case "MascaraCte"
                        MaskCte = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))

                    Case "SincronizaCliente"
                        SincronizaCte = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
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


        If TallaColor = 1 Then
            BtnCerrar.Text = "F9-Surtir"
        Else
            lblNivelDesc.Visible = False
        End If


        With Me.cmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        With cmbTipoCanal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoCanal"
            .llenar()
        End With

        cmbTipoCanal.SelectedValue = TipoCanal

        SUCClave = SucursalSurtido
        cmbSucursal.SelectedValue = SUCClave
        AlmacenSurtido = ALMClave
        sAlmacen = AlmacenClave & " - " & AlmacenNombre

        bLoad = True



        dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)
        SucursalClave = dt.Rows(0)("Clave")
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
        BtnTC.Text = dt.Rows(0)("Referencia")
        MonedaRef = dt.Rows(0)("Referencia")
        MonedaDesc = dt.Rows(0)("Descripcion")
        TipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
        dt.Dispose()


        If Moneda <> MonedaCambio Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
            MonRefCambio = dt.Rows(0)("Referencia")
            MonDescCambio = dt.Rows(0)("Descripcion")
            MonTipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
            dt.Dispose()

        Else
            MonRefCambio = MonedaRef
            MonDescCambio = MonedaDesc
            MonTipoCambio = TipoCambio
        End If



        MonedaActual = Moneda
        MonRefBase = MonedaRef




        dt = ModPOS.Recupera_Tabla("sp_muestra_monedas", Nothing)

        For i = 0 To dt.Rows.Count - 1
            Me.CtxTC.Items.Add(dt.Rows(i)("Referencia"))
        Next
        dt.Dispose()


        If Caja Then

            dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
            CajaTICDevolucion = dt.Rows(0)("TICDevolucion")
            CajaClave = dt.Rows(0)("Clave")
            CajaNombre = dt.Rows(0)("Nombre")
            Cajon = IIf(dt.Rows(0)("Cajon").GetType.Name = "DBNull", False, dt.Rows(0)("Cajon"))
            Aplicacion = IIf(dt.Rows(0)("url_aplicacion").GetType.Name = "DBNull", "", dt.Rows(0)("url_aplicacion"))
            ConfirmarAbono = IIf(dt.Rows(0)("ConfirmaAbono").GetType.Name <> "DBNull", dt.Rows(0)("ConfirmaAbono"), 0)
            dt.Dispose()

        End If


        LblTitulo.Text = PuntodeVenta

        If Caja = False And ActivaDevolucion = True Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
            CajaTICDevolucion = dt.Rows(0)("TICDevolucion")
            MaxEfectivo = dt.Rows(0)("LimiteEfectivo")
            MaxCheques = dt.Rows(0)("LimiteCheque")
            MaxVales = dt.Rows(0)("LimiteVale")
            CajaClave = dt.Rows(0)("Clave")
            CajaNombre = dt.Rows(0)("Nombre")
            Cajon = IIf(dt.Rows(0)("Cajon").GetType.Name = "DBNull", False, dt.Rows(0)("Cajon"))
            dt.Dispose()
        End If

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
                    .lblCteClave.Text = dtVenta.Rows(0)("Clave")
                    .lblNivelDesc.Text = IIf(dtVenta.Rows(0)("NivelDesc").GetType.Name = "DBNull", "", dtVenta.Rows(0)("NivelDesc"))
                    .txtLimite.Text = dtVenta.Rows(0)("LimiteCredito")
                    .txtDias.Text = dtVenta.Rows(0)("DiasCredito")
                    .txtSaldo.Text = dtVenta.Rows(0)("SaldoCliente")
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
                    .lblCteClave.Text = dtVenta.Rows(0)("Clave")
                    .lblNivelDesc.Text = IIf(dtVenta.Rows(0)("NivelDesc").GetType.Name = "DBNull", "", dtVenta.Rows(0)("NivelDesc"))
                    .txtLimite.Text = dtVenta.Rows(0)("LimiteCredito")
                    .txtDias.Text = dtVenta.Rows(0)("DiasCredito")
                    .txtSaldo.Text = dtVenta.Rows(0)("SaldoCliente")
                    .AlmacenOpen = IIf(dtVenta.Rows(0)("ALMClave").GetType.Name = "DBNull", .ALMClave, dtVenta.Rows(0)("ALMClave"))
                End With

                MonedaActual = IIf(dtVenta.Rows(0)("MONClave").GetType.Name = "DBNull", Moneda, dtVenta.Rows(0)("MONCLave"))

                dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaActual)
                MonedaRef = dt.Rows(0)("Referencia")
                MonedaDesc = dt.Rows(0)("Descripcion")
                dt.Dispose()
                BtnTC.Text = MonedaRef
                TipoCambio = dtVenta.Rows(0)("TipoCambio")

            End If
            dtVenta.Dispose()

        End If

        If VentaAbierta = True Then
            recuperaVentaOpen(VENClave, sFolio, CTEClaveActual, CTENombreActual, AtiendeClave, ReferenciaUsr, AtiendeNombre, SaldoVenta, TotalVenta, TipoDocumento, EstadoDocumento, txtLimite.Text, txtDias.Text, txtSaldo.Text, AlmacenOpen)
            obtenerValorMaxPedido(CTEClaveActual)
        ElseIf VentaNueva Then
            CTEClaveActual = CTEClaveInicial
            recuperaCliente(CTEClaveActual)
        End If

        LblCliente.Text = CTENombreActual
        LblUsuario.Text = AtiendeNombre
        LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
        LblCantidadArticulos.Text = CStr(TotalArticulos)
        LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
        LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
        TxtCantidad.Text = CStr(ModPOS.Redondear(Cantidad, 2))
        Me.LblFechaHora.Text = DateTime.Today.ToLongDateString & " " & DateTime.Now.ToShortTimeString 'ToString("MMMM dd, yyyy")

        If CTEClaveActual = CTEClaveInicial Then
            txtSaldo.Visible = False
            lblSaldo.Visible = False
        Else
            txtSaldo.Visible = True
            lblSaldo.Visible = True
        End If


        lblMoneda.Text = "T.C. " & Format(CStr(ModPOS.Redondear(TipoCambio, 2)), "Currency")
        lblTotMon.Text = "TOTAL (" & MonedaRef.ToUpper.Trim & ")"
        If Moneda <> MonedaCambio Then
            If MonedaActual <> Moneda Then

                If TipoCambio > 0 Then
                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                End If
            Else
                If MonTipoCambio > 0 Then
                    LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                End If
            End If
        Else
            If MonedaActual <> Moneda Then

                If TipoCambio > 0 Then
                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                End If
            Else
                LblTipoCambio.Text = ""
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

    Private Sub Clock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock.Tick
        Me.LblFechaHora.Text = DateTime.Today.ToLongDateString & " " & DateTime.Now.ToShortTimeString 'ToString("MMMM dd, yyyy")
    End Sub

    'Public Sub recalcularPartidas()
    '    With Me

    '        dtPedidoDetalle.Clear()

    '        Dim dtventadetalle As DataTable = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", .VENClave)
    '        If Not dtventadetalle Is Nothing Then
    '            Dim i As Integer = 0
    '            .TotalArticulos = dtventadetalle.Rows.Count

    '            For i = 0 To .TotalArticulos - 1
    '                Dim sDVEClave As String = dtventadetalle.Rows(i)("DVEClave")
    '                Dim sPROClave As String = dtventadetalle.Rows(i)("PROClave")
    '                Dim sGTIN As String = dtventadetalle.Rows(i)("Clave")
    '                Dim sNombre As String = dtventadetalle.Rows(i)("Nombre")
    '                Dim dCantidad As Double = dtventadetalle.Rows(i)("Cantidad")
    '                Dim dPrecioBruto As Double = dtventadetalle.Rows(i)("PrecioBruto")
    '                Dim dImpuestoPorc As Double = dtventadetalle.Rows(i)("ImpuestoPorc")
    '                Dim dImpuestoImp As Double = dtventadetalle.Rows(i)("ImpuestoImp")
    '                Dim dDescuentoImp As Double = dtventadetalle.Rows(i)("DescuentoImp")
    '                Dim dPuntosImp As Double = dtventadetalle.Rows(i)("PuntosImp")
    '                Dim dTotal As Double = dtventadetalle.Rows(i)("TotalPartida")

    '                Dim iGrupoMaterial As Integer = IIf(dtventadetalle.Rows(0)("GrupoMaterial").GetType.FullName = "System.DBNull", 0, dtventadetalle.Rows(0)("GrupoMaterial"))
    '                Dim iSector As Integer = IIf(dtventadetalle.Rows(0)("Sector").GetType.FullName = "System.DBNull", 0, dtventadetalle.Rows(0)("Sector"))
    '                Dim iPartida As Integer = IIf(dtventadetalle.Rows(0)("Partida").GetType.FullName = "System.DBNull", i + 1, dtventadetalle.Rows(0)("Partida"))
    '                Dim scentroSuministro As String = IIf(dtventadetalle.Rows(0)("centroSuministro").GetType.FullName = "System.DBNull", "", dtventadetalle.Rows(0)("centroSuministro"))
    '                Dim dBackOrder As Decimal = dtventadetalle.Rows(i)("BackOrder")




    '                ' Dim dImporteNeto As Double = TruncateToDecimal((dPrecioBruto - dDescuentoImp) * (1 + dImpuestoPorc), 2)


    '                Dim iKgLt As Integer = IIf(dtventadetalle.Rows(0)("KgLt").GetType.FullName = "System.DBNull", 0, dtventadetalle.Rows(0)("KgLt"))
    '                Dim dUndKilo As Double = IIf(dtventadetalle.Rows(0)("UndKilo").GetType.FullName = "System.DBNull", 0, dtventadetalle.Rows(0)("UndKilo"))

    '                ' AGREGAR PRODUCTO A LISTA
    '                .AgregarProducto(sDVEClave, sPROClave, sGTIN, sNombre, dCantidad, dPrecioBruto, dImpuestoPorc, dDescuentoImp, iKgLt, dUndKilo, iGrupoMaterial, iSector, iPartida, scentroSuministro, dBackOrder)
    '                .TotalAhorro += dDescuentoImp
    '                .TotalPuntos += (dPuntosImp * dCantidad)
    '                .TotalVenta += (dTotal)
    '            Next
    '            dtventadetalle.Dispose()

    '            If .SaldoVenta = -1 Then
    '                .SaldoVenta = .TotalVenta
    '            End If

    '            LblCantidadPuntos.Text = ModPOS.Redondear(.TotalPuntos, 2).ToString("#,##0.00")
    '            LblCantidadArticulos.Text = CStr(.TotalArticulos)
    '            LblAhorro.Text = Format(CStr(ModPOS.Redondear(.TotalAhorro, 2)), "Currency")
    '            LblTotal.Text = Format(CStr(ModPOS.Redondear(.TotalVenta, 2)), "Currency")
    '        End If
    '    End With

    'End Sub

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

    Private Sub BtnVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVenta.Click

        cmbSucursal.SelectedValue = SucursalSurtido

        If cmbSucursal.SelectedValue Is Nothing Then
            MessageBox.Show("!Debe especificar la sucursal que realizara el surtido¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If TipoVenta = 0 Then
            If CTEClaveActual <> CTEClaveInicial Then
                recuperaCliente(CTEClaveInicial)
            End If
        End If

        If CDbl(txtLimite.Text) > 0 Then
            VentaCredito()
        Else
            VentaContado()
        End If
    End Sub

    Private Sub obtenerValorMaxPedido(ByVal sCliente As String)
        Dim dtCliente As DataTable = ModPOS.Recupera_Tabla("st_muestra_riesgo", "@CTEClave", sCliente)
        If dtCliente.Rows.Count > 0 Then

            Dim dtRiesgo As DataTable = ModPOS.Recupera_Tabla("st_recupera_riesgo", "@IdRiesgo", CStr(dtCliente.Rows(0)("Riesgo")))
            If dtRiesgo.Rows.Count > 0 Then
                If CDec(dtRiesgo.Rows(0)("ValorPedido")) >= 0 Then
                    ValorMaxPedido = CDec(dtRiesgo.Rows(0)("ValorPedido"))
                Else
                    ValorMaxPedido = -1
                End If
            Else
                ValorMaxPedido = -1
            End If
            dtRiesgo.Dispose()

        Else
            ValorMaxPedido = -1
        End If
        dtCliente.Dispose()
    End Sub

    Private Function leeCodigoBarras(ByVal centroSuministro As String, ByVal Codigo As String, ByVal Suma As Boolean, ByVal Busca As Boolean, ByVal bRecalcular As Boolean, ByVal bValidaOpen As Boolean, ByVal bShortCut As Boolean, ByVal dDescuento As Double, ByVal sDVEClave As String, ByRef ProductoClave As String, ByRef dFaltante As Decimal, Optional ByVal dCant As Decimal = 0, Optional ByVal PREClaveKIT As String = "", Optional ByVal PrecioBrutoKIT As Decimal = 0, Optional ByVal IdKit As String = "", Optional ByVal PROClaveKIT As String = "") As Boolean
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

                If dCant = 0 Then
                    If TxtCantidad.Text = vbNullString OrElse CDbl(TxtCantidad.Text) <= 0 Then
                        Cantidad = 1
                        TxtCantidad.Text = "1"
                    Else
                        Cantidad = CDbl(TxtCantidad.Text)
                    End If
                Else
                    Cantidad = dCant
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
                    dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", sCliente, "@TipoCanal", cmbTipoCanal.SelectedValue)
                    If dtCliente.Rows.Count > 0 Then
                        ListaPrecio = dtCliente.Rows(0)("PREClave")
                        ' TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                        dtCliente.Dispose()
                    Else
                        dtCliente.Dispose()
                        MessageBox.Show("El Cliente No cuenta con Precio para el Canal de Venta seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                    obtenerValorMaxPedido(sCliente)

                End If
                'Busca y recupera los datos del producto

                dt = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 1, "@Busca", Codigo, "@SUCClave", SUCClave, "@PREClave", ListaPrecio, "@CTEClave", sCliente, "@Cantidad", Cantidad, "@Char", cReplace, "@Servicio", ModificaPrecioServicio, "@TallaColor", TallaColor)

                If dt Is Nothing Then
                    Beep()
                    MessageBox.Show("El Código " & Codigo & " no corresponde a un Producto Existente o Activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                        TxtProducto.Text = ""
                        Cantidad = 1
                        TxtCantidad.Text = "1"
                        MessageBox.Show("El producto " & sClave & " no permite decimales o la cantidad debe ser mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dt.Dispose()
                        Return Busca
                    End If

                    If iTProducto >= 7 Then
                        AddModelo(sModelo, dCantidad)
                        Return Busca
                    End If


                    If bVtaPaquete = True AndAlso IdKit = "" Then

                        Dim sPaquetes As String = ""

                        Dim dtPaq As DataTable = ModPOS.Recupera_Tabla("st_recupera_clave_kit", "@PROClave", sPROClave, "@TallaColor", TallaColor)

                        If dtPaq.Rows.Count = 1 Then
                            sPaquetes = dtPaq.Rows(0)("Paquetes")
                        End If

                        MessageBox.Show("El producto " & sClave & ", su venta es exclusiva en Paquete(s): " & sPaquetes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        dt.Dispose()
                        Return Busca
                    End If


                    If CDec(dt.Rows(0)("PrecioBruto")) = 0 Then
                        MessageBox.Show("El producto " & sClave & " no cuenta con precio definido en la lista de precios actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                            foundRows = dtPedidoDetalle.Select(" PROClave = '" & sPROClave & "' and Baja = 0 and IdKit='' and centroSuministro='" & centroSuministro & "'")
                        Else
                            foundRows = dtPedidoDetalle.Select(" DVEClave = '" & sDVEClave & "' and Baja = 0")
                        End If
                    End If

                    If Not foundRows Is Nothing AndAlso foundRows.Length > 1 Then

                        Dim a As New FrmConsultaT
                        a.Text = "Selecciona la Partida que desea Modificar"
                        a.Campo = "DVEClave"
                        a.GridConsultaGen.Font = New Font("Arial", 14)
                        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_recupera_partida_prod", "@VENClave", VENClave, "@PROClave", sPROClave)
                        a.GridConsultaGen.RootTable.Columns("DVEClave").Visible = False
                        a.ShowDialog()
                        If a.DialogResult = DialogResult.OK Then
                            If a.ID <> "" Then
                                sDVEClave = a.ID
                            Else
                                Return Busca
                            End If
                        End If
                        a.Dispose()

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


                    Dim sAutoriza As String = ""

                    If bShortCut = False Then


                        If ModificaPrecioServicio AndAlso iTProducto >= 4 AndAlso iTProducto < 7 Then
                            Dim a As New FrmAddProducto
                            a.SUCClave = Me.SUCClave
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
                                TxtCantidad.Text = "1"
                                sAutoriza = ""
                                TxtProducto.Focus()
                                dPeso = 0
                                Return Busca
                            End If

                        ElseIf CambiaPrecio = True Then

                            If sModelo <> "" AndAlso TallaColor = 1 Then
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
                                    TxtProducto.Focus()
                                Else
                                    a.Dispose()
                                    TxtProducto.Text = ""
                                    Cantidad = 1
                                    TxtProducto.Focus()
                                    dPeso = 0

                                    Return Busca
                                End If

                            Else

                                'Si Cambia Precio = True 
                                Dim a As New FrmAddProducto
                                a.SUCClave = Me.SUCClave
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
                                a.iKgLt = iKgLt
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
                                    TxtCantidad.Text = "1"
                                    sAutoriza = ""
                                    TxtProducto.Focus()
                                    dPeso = 0

                                    Return Busca
                                End If
                            End If
                        End If
                    End If

                    If dCantidad > dOriginal Then
                        dPendiente = dCantidad - dOriginal
                    Else
                        dPendiente = 0
                    End If

                    ProductoClave = sPROClave


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
                                MessageBox.Show("Lo sentimos, la cantidad solicitada excede el número de compras permitidas por mes para Empleados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

                                        BacktoSearh = AgregaPartida(sDVEClave, iPartida, sPROClave, sClave, sNombre, iTProducto, iSeguimiento, iDiasGarantia, iKgLt, dCosto, dPrecioUnitario, dBase, dDescGeneralPor, dDescGeneralImp, dVolumen, dVolumenImp, sTipoDesc, dDescPorc, dDescuentoImp, dImpuestoImp, UnidadesKilo, PorcImpProducto, dImporteNeto, dCantidad, dOriginal, iGrupoMaterial, iSector, centroSuministro, False, sAutoriza, PREClaveKIT, IdKit, PROClaveKIT, bRecalcular)
                                        dPendiente = 0
                                    ElseIf Not (iTProducto = 3 OrElse iTProducto = 4) AndAlso Disponible > 0 AndAlso dPendiente > Disponible Then
                                        If MessageBox.Show("La cantidad solicitada excede el disponible, solo se cuenta con : " & CStr(Disponible) & " del Producto: " & sClave & ", ¿Desea agregar el disponible?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                                            dCantidad = dOriginal + Disponible
                                            dPendiente -= Disponible
                                            BacktoSearh = AgregaPartida(sDVEClave, iPartida, sPROClave, sClave, sNombre, iTProducto, iSeguimiento, iDiasGarantia, iKgLt, dCosto, dPrecioUnitario, dBase, dDescGeneralPor, dDescGeneralImp, dVolumen, dVolumenImp, sTipoDesc, dDescPorc, dDescuentoImp, dImpuestoImp, UnidadesKilo, PorcImpProducto, dImporteNeto, dCantidad, dOriginal, iGrupoMaterial, iSector, centroSuministro, False, sAutoriza, PREClaveKIT, IdKit, PROClaveKIT, bRecalcular)
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
                                                a.lblMsg.Text = "NO SE CONTAMOS CON ESA TALLA. TE PODEMOS OFRECER LAS SIGUIENTES: "
                                                a.Cantidad = dPendiente
                                                a.BloqueaCantidad = True
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
                                                a.ShowDialog()
                                                If a.DialogResult = Windows.Forms.DialogResult.OK Then
                                                    Dim nuevoFaltante As Decimal = 0
                                                    leeCodigoBarras(centroSuministro, a.Clave, True, Busca, True, bValidaOpen, True, 0, "", sPROClave, nuevoFaltante, a.Cantidad)
                                                    dPendiente -= (a.Cantidad - nuevoFaltante)
                                                End If
                                                dtColores.Dispose()
                                            ElseIf BuscaNegados = 0 Then
                                                MessageBox.Show("Lo sentimos en la sucural no contamos con existencia disponible del producto: " & sModelo & " " & sColor & " " & sTalla, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                                            End If
                                            dtTallas.Dispose()
                                        End If

                                        dCantNegada = dPendiente

                                        If BuscaNegados = 1 Then
                                            ' Validar el tipo de sucursal, si es express solicita solo de su sucursal
                                            If TipoSucursal <> 5 Then
                                                Dim dtCluster As DataTable
                                                dtCluster = Recupera_Tabla("st_recupera_cluster", "@SUCClave", SUCClave)
                                                If dtCluster.Rows.Count > 0 Then
                                                    Dim mensaje As String = ""
                                                    If TallaColor Then
                                                        mensaje = "Lo sentimos en la sucural no contamos con : " & String.Format("{0:0}", dCantNegada) & " unidades del droducto: " & sModelo & " " & sColor & " " & sTalla & ", ¿Desea solicitar la cantidad faltante a otra Sucursal cercana?"
                                                    Else
                                                        mensaje = "Lo sentimos en la sucural no contamos con : " & CStr(dCantNegada) & " unidades del droducto: " & sClave & ", ¿Desea solicitar la cantidad faltante a otra Sucursal cercana?"
                                                    End If
                                                    If MessageBox.Show(mensaje, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
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
                                                                        BacktoSearh = AgregaPartida(sDVEClave, iPartida, sPROClave, sClave, sNombre, iTProducto, iSeguimiento, iDiasGarantia, iKgLt, dCosto, dPrecioUnitario, dBase, dDescGeneralPor, dDescGeneralImp, dVolumen, dVolumenImp, sTipoDesc, dDescPorc, dDescuentoImp, dImpuestoImp, UnidadesKilo, PorcImpProducto, dImporteNeto, dCantRemoto, dOriginalRemoto, iGrupoMaterial, iSector, dtCluster.Rows(k)("Cluster"), True, sAutoriza, PREClaveKIT, IdKit, PROClaveKIT, bRecalcular)
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

                                                            If TallaColor = 1 Then
                                                                mensaje = "Lo sentimos, no se encontraron : " & String.Format("{0:0}", dCantNegada) & " disponibles del Producto: " & sModelo & " " & sColor & " " & sTalla & " en las Sucursales cercanas"
                                                            Else
                                                                mensaje = "Lo sentimos, no se encontraron : " & CStr(dCantNegada) & " disponibles del Producto: " & sClave & " en las Sucursales cercanas"
                                                            End If
                                                            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                            BacktoSearh = False
                                                        End If

                                                    End If
                                                Else
                                                    MessageBox.Show("Lo sentimos en la sucural no contamos con existencia disponible del producto: " & sModelo & " " & sColor & " " & sTalla, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)

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

                                                            BacktoSearh = AgregaPartida(sDVEClave, iPartida, sPROClave, sClave, sNombre, iTProducto, iSeguimiento, iDiasGarantia, iKgLt, dCosto, dPrecioUnitario, dBase, dDescGeneralPor, dDescGeneralImp, dVolumen, dVolumenImp, sTipoDesc, dDescPorc, dDescuentoImp, dImpuestoImp, UnidadesKilo, PorcImpProducto, dImporteNeto, dCantRemoto, dOriginalRemoto, iGrupoMaterial, iSector, SucursalPadre, True, sAutoriza, PREClaveKIT, IdKit, PROClaveKIT, bRecalcular)
                                                            If dtResult.Rows(0)("Pendiente") > 0 Then
                                                                MessageBox.Show("Lo sentimos, no se encontraron : " & dtResult.Rows(0)("Pendiente") & " disponibles del Producto: " & sClave & " en las Sucursal remota", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                                BacktoSearh = False
                                                            End If
                                                            dtResult.Dispose()

                                                        Else
                                                            dtResult.Dispose()
                                                            MessageBox.Show("Lo sentimos, el producto " & sClave & ", no cuenta disponibilidad en la sucursal remota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                            BacktoSearh = False
                                                        End If
                                                    Else
                                                        dtResult.Dispose()
                                                        MessageBox.Show("Lo sentimos, No se pudo contactar a la sucursal remota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                        BacktoSearh = Busca
                                                    End If
                                                Else
                                                    MessageBox.Show("Lo sentimos, no fue posible comprobar la disponibilidad del producto " & sClave & " en la sucursal remota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                                                BacktoSearh = AgregaPartida(sDVEClave, iPartida, sPROClave, sClave, sNombre, iTProducto, iSeguimiento, iDiasGarantia, iKgLt, dCosto, dPrecioUnitario, dBase, dDescGeneralPor, dDescGeneralImp, dVolumen, dVolumenImp, sTipoDesc, dDescPorc, dDescuentoImp, dImpuestoImp, UnidadesKilo, PorcImpProducto, dImporteNeto, dtResult.Rows(0)("Surtido") + dOriginal, dOriginal, iGrupoMaterial, iSector, SucursalPadre, True, sAutoriza, PREClaveKIT, IdKit, PROClaveKIT, bRecalcular)

                                                If dtResult.Rows(0)("Pendiente") = 0 Then
                                                    dt.Dispose()
                                                    dtResult.Dispose()
                                                    Return BacktoSearh
                                                Else
                                                    dFaltante = dtResult.Rows(0)("Pendiente")
                                                    MessageBox.Show("Lo sentimos, no se encontraron : " & dFaltante & " disponibles del Producto: " & sClave & " en las Sucursal remota", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                    dt.Dispose()
                                                    dtResult.Dispose()
                                                    Return Busca
                                                End If
                                            Else
                                                dtResult.Dispose()
                                                dFaltante = dPendiente
                                                MessageBox.Show("Lo sentimos, el producto " & sClave & ", no cuenta disponibilidad en la sucursal remota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                dt.Dispose()
                                                Return Busca
                                            End If

                                        Else
                                            dtResult.Dispose()
                                            dFaltante = dPendiente
                                            MessageBox.Show("Lo sentimos, No se pudo contactar a la sucursal remota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            dt.Dispose()
                                            Return Busca
                                        End If

                                    Else
                                        dFaltante = dPendiente
                                        MessageBox.Show("Lo sentimos, no fue posible comprobar la disponibilidad del producto " & sClave & " en la sucursal remota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        dt.Dispose()
                                        dtResult.Dispose()
                                        Return Busca
                                    End If
                                End If
                            Else
                                ' Agrega BackOrder
                                BacktoSearh = AgregaPartida(sDVEClave, iPartida, sPROClave, sClave, sNombre, iTProducto, iSeguimiento, iDiasGarantia, iKgLt, dCosto, dPrecioUnitario, dBase, dDescGeneralPor, dDescGeneralImp, dVolumen, dVolumenImp, sTipoDesc, dDescPorc, dDescuentoImp, dImpuestoImp, UnidadesKilo, PorcImpProducto, dImporteNeto, dCantidad, dOriginal, iGrupoMaterial, iSector, centroSuministro, True, sAutoriza, PREClaveKIT, IdKit, PROClaveKIT, bRecalcular)

                            End If
                        Else
                            ' No valida el Inventario
                            BacktoSearh = AgregaPartida(sDVEClave, iPartida, sPROClave, sClave, sNombre, iTProducto, iSeguimiento, iDiasGarantia, iKgLt, dCosto, dPrecioUnitario, dBase, dDescGeneralPor, dDescGeneralImp, dVolumen, dVolumenImp, sTipoDesc, dDescPorc, dDescuentoImp, dImpuestoImp, UnidadesKilo, PorcImpProducto, dImporteNeto, dCantidad, dOriginal, iGrupoMaterial, iSector, centroSuministro, False, sAutoriza, PREClaveKIT, IdKit, PROClaveKIT, bRecalcular)

                        End If
                    Else
                        ' No recalcula existencia
                        BacktoSearh = AgregaPartida(sDVEClave, iPartida, sPROClave, sClave, sNombre, iTProducto, iSeguimiento, iDiasGarantia, iKgLt, dCosto, dPrecioUnitario, dBase, dDescGeneralPor, dDescGeneralImp, dVolumen, dVolumenImp, sTipoDesc, dDescPorc, dDescuentoImp, dImpuestoImp, UnidadesKilo, PorcImpProducto, dImporteNeto, dCantidad, dOriginal, iGrupoMaterial, iSector, centroSuministro, False, sAutoriza, PREClaveKIT, IdKit, PROClaveKIT, bRecalcular)

                    End If

                    dt.Dispose()

                    Return BacktoSearh

                End If

            End If
        End If
    End Function

    Private Sub TxtProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProducto.KeyPress
        If Asc(e.KeyChar) = 13 Then

            If Not TxtCantidad.Text = vbNullString Then
                If CDbl(TxtCantidad.Text) <= 0 Then
                    Cantidad = 1
                    TxtCantidad.Text = CStr(Cantidad)
                ElseIf CDbl(TxtCantidad.Text) <> Cantidad Then
                    Cantidad = Math.Abs(CDbl(TxtCantidad.Text))
                End If
            Else
                Cantidad = 1
                TxtCantidad.Text = CStr(Cantidad)
            End If

            If TallaColor = 1 Then
                If AddModelo(TxtProducto.Text.Trim.ToUpper.Replace("'", "''"), Cantidad) = False Then
                    AgregaGTIN(TxtProducto.Text.Trim.ToUpper.Replace("'", "''"), True, False, True, Cantidad)
                End If
            Else
                AgregaGTIN(TxtProducto.Text.Trim.ToUpper.Replace("'", "''"), True, False, True, Cantidad)
            End If

        End If
    End Sub

    Public Function AgregaGTIN(ByVal Codigo As String, ByVal Suma As Boolean, ByVal Busca As Boolean, ByVal bValidaOpen As Boolean, Optional ByVal dCant As Decimal = 0, Optional ByVal dInicio_Negado As DateTime = #1/1/1900#, Optional ByVal dFin_Negado As DateTime = #1/1/1900#, Optional ByVal bRecalcular As Boolean = True, Optional ByVal bShortCut As Boolean = False, Optional ByVal dDescuento As Decimal = 0, Optional ByVal sDVEClave As String = "", Optional ByVal PREClaveKIT As String = "", Optional ByVal PrecioBrutoKIT As Decimal = 0, Optional ByVal IdKit As String = "", Optional ByVal PROClaveKIT As String = "") As Boolean
        Dim backToSearch As Boolean

        Dim dFaltante As Decimal = 0
        Dim sPROClave As String = ""


        If cmbSucursal.SelectedValue Is Nothing Then
            MessageBox.Show("!Debe especificar la sucursal que realizara el surtido¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cmbTipoCanal.SelectedValue Is Nothing Then
            MessageBox.Show("!Debe seleccionar un Canal de Venta¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If


        backToSearch = leeCodigoBarras("", Codigo, Suma, Busca, bRecalcular, bValidaOpen, bShortCut, dDescuento, sDVEClave, sPROClave, dFaltante, dCant, PREClaveKIT, PrecioBrutoKIT, IdKit, PROClaveKIT)

        If (dCant - dFaltante) > 0 AndAlso dInicio_Negado > #1/1/1900# AndAlso dFin_Negado > #1/1/1900# Then
            'Quita Negado
            ModPOS.Ejecuta("st_quita_negado", "@ALMClave", AlmacenSurtido, "@CTEClave", CTEClaveActual, "@PROClave", sPROClave, "@Inicio", dInicio_Negado, "@Fin", dFin_Negado, "@Cantidad", (dCant - dFaltante))
        End If

        'Sugerido
        If dFaltante = 0 Then
            sugerido(sPROClave, AlmacenSurtido, VENClave, Picking)
        Else
            'Equivalente
            Dim dtEquivalente As DataTable = ModPOS.Recupera_Tabla("st_recupera_equivalente", "@PROClave", sPROClave, "@ALMClave", AlmacenSurtido)
            If dtEquivalente.Rows.Count > 0 Then

                Dim a As New FrmConsulta
                a.Text = "Productos Equivalente o Sustitutos"
                a.Campo = "PROClave"
                a.Campo2 = "Clave"
                ModPOS.ActualizaGrid(False, a.GridConsultaGen, "st_recupera_equivalente", "@PROClave", sPROClave, "@ALMClave", AlmacenSurtido)
                a.GridConsultaGen.RootTable.Columns("PROClave").Visible = False
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If a.ID <> "" Then
                        AgregaGTIN(a.ID2, True, False, True, dFaltante)
                    End If
                End If
                a.Dispose()

            End If
            dtEquivalente.Dispose()
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

    Private Function AgregaPartida(ByVal sDVEClave As String, _
                                  ByVal iPartida As Integer, _
                                  ByVal sPROClave As String, _
                                  ByVal sClave As String, _
                                  ByVal sNombre As String, _
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
                                  ByVal sAutoriza As String, _
                                   ByVal sPREClaveKIT As String, _
                                  ByVal sIdKIT As String, _
                                  ByVal sPROClaveKIT As String, _
                                  ByVal bRecalcular As Boolean) As Boolean

        UltimoCodigo = sClave

        Dim oVolumen As Decimal = dVolumen

        'Bloquea al cliente para no permitir que se modifique la lista de precios cuando ya hay productos en la venta
        If CambiarCliente = True Then
            btnBuscaCte.Enabled = False
            TxtCliente.Enabled = False
            cmbTipoCanal.Enabled = False
            BtnTC.Enabled = False
            CambiarCliente = False
        End If

        If dCantidad <> dOriginal Then

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
                If centroSuministro <> "" Then

                    ModPOS.Ejecuta("stpr_remueveTraslado", "@SUCClave", centroSuministro, "@Destino", SUCClave, "@VENClave", VENClave, "@PROClave", sPROClave, "@Cantidad", dOriginal - dCantidad)

                ElseIf bBackOrder = False Then
                    'quitar apartado

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
            "@Autoriza", sAutoriza, _
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
            "@Autoriza", sAutoriza, _
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
                ModPOS.Ejecuta("st_actualiza_canal_vta", "@VENClave", VENClave, "@TipoCanal", cmbTipoCanal.SelectedValue)
            End If


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

                Dim dSubtotal As Decimal
                dSubtotal = TruncateToDecimal((dImporteNeto / dCantidad), 2)

                Linea2 = FormateaCadena(False, ModPOS.Redondear(dCantidad, 2).ToString, 2) & _
                " @ " & _
                FormateaCadena(False, Format(dSubtotal.ToString, "Currency"), 7) & _
                FormateaCadena(False, Format((dImporteNeto).ToString, "Currency"), 8)

                mySerialPort.Write(Linea2)

            Catch ex As Exception
            End Try
        End If


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

        If Agotamiento Then
            Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_agotamiento", "@ALMClave", AlmacenSurtido, "@PROClave", sPROClave, "@Cantidad", dCantidad)
            If Not dt Is Nothing Then
                MessageBox.Show(sClave & ", " & sNombre & "se ha agotado, solicitar al proveedor: " & CStr(Redondear(dCantidad, 2)), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dt.Dispose()
            End If
        End If

        If TotalVenta > 0 AndAlso ValorMaxPedido >= 0 Then
            If TotalVenta > ValorMaxPedido Then
                MessageBox.Show("El Importe del documento excede lo permitido (" & Format(CStr(ValorMaxPedido), "Currency") & ") para el cliente actual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If


        TxtProducto.Text = ""
        Cantidad = 1
        TxtCantidad.Text = "1"
        Return False
    End Function

    Private Sub sugerido(ByVal sPROClave As String, ByVal sALMClave As String, ByVal sVENClave As String, ByVal bPicking As Boolean)
        Dim dataSetPortafolio As DataSet = ModPOS.recuperaTabla_DTS("sp_recupera_portafolio_prod", "Portafolio", "@PROClave", sPROClave)
        If dataSetPortafolio.Tables(0).Rows.Count > 0 Then
            Dim a As New FrmSugerido
            a.Padre = "Preventa"
            a.numMostrador = Me.numMostrador
            a.VENClave = sVENClave
            a.ALMClave = sALMClave
            a.Picking = bPicking
            a.ListaPrecio = ListaPrecio
            a.dataSetPortafolio = dataSetPortafolio
            a.ShowDialog()
            a.Dispose()
        End If
        dataSetPortafolio.Dispose()
    End Sub

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
            If MonedaActual <> Moneda Then

                If TipoCambio > 0 Then
                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                End If
            Else
                If MonTipoCambio > 0 Then
                    LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                End If
            End If
        Else
            If MonedaActual <> Moneda Then

                If TipoCambio > 0 Then
                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                End If
            Else
                LblTipoCambio.Text = ""
            End If
        End If


    End Sub

    'Public Sub AgregarProducto(ByVal DVEClave As String, ByVal PROClave As String, ByVal GTIN As String, ByVal Nombre As String, ByVal Cantidad As Decimal, ByVal Precio As Decimal, ByVal ImpuestoPor As Decimal, ByVal Descuento As Decimal, ByVal kglt As Integer, ByVal UnidadesKilo As Double, ByVal GrupoMaterial As Integer, ByVal Sector As Integer, ByVal Partida As Integer, ByVal centroSuministro As String, ByVal dBackOrder As Decimal)
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
    '        dtPedidoDetalle.Rows.Add(row1)
    '    End If


    '    If Display = True Then
    '        Try
    '            'limpiar
    '            Dim LimpiarDisplay As String = Chr(12)
    '            mySerialPort.Write(LimpiarDisplay)

    '            If NoLineas > 1 Then
    '                mySerialPort.Write(FormateaCadena(True, Nombre, MaxCaracteres))

    '                'Bajar Cursor
    '                Dim BajarCursor As String = Chr(10)
    '                mySerialPort.Write(BajarCursor)

    '            End If


    '            'Recorrer Izq
    '            Dim MoverIzq As String = Chr(13)
    '            mySerialPort.Write(MoverIzq)

    '            'Escribe segunda linea
    '            Dim Linea2 As String

    '            Dim dSubtotal As Decimal
    '            dSubtotal = TruncateToDecimal((dTotal / Cantidad), 2)

    '            Linea2 = FormateaCadena(False, ModPOS.Redondear(Cantidad, 2).ToString, 2) & _
    '            " @ " & _
    '            FormateaCadena(False, Format(dSubtotal.ToString, "Currency"), 7) & _
    '            FormateaCadena(False, Format((dTotal).ToString, "Currency"), 8)

    '            mySerialPort.Write(Linea2)

    '        Catch ex As Exception
    '        End Try
    '    End If

    'End Sub

    Public Sub AgregaCancelado(ByVal sDVEClave As String, ByVal sDescripcion As String, ByVal dPrecio As Decimal, ByVal dCantidad As Decimal, ByVal dTotalPuntos As Decimal)

        TotalArticulos -= 1
        TotalPuntos -= dTotalPuntos

        Dim foundRows() As System.Data.DataRow
        foundRows = dtPedidoDetalle.Select(" DVEClave = '" & sDVEClave & "'")

        If foundRows.Length <> 0 Then
            foundRows(0)("Baja") = 1
        End If




        If Display = True Then
            Try
                'limpiar
                Dim LimpiarDisplay As String = Chr(12)
                mySerialPort.Write(LimpiarDisplay)

                If NoLineas > 1 Then
                    mySerialPort.Write(FormateaCadena(True, "CANCELADO " & sDescripcion, MaxCaracteres))

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

    Private Sub TxtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCliente.KeyPress
        If (Asc(e.KeyChar)) = 13 Then
            If Not TxtCliente.Text = vbNullString Then

                If MaskCte = 1 Then
                    If TxtCliente.Text.Split("-").Length = 2 Then
                        If IsNumeric(TxtCliente.Text.Split("-")(0)) AndAlso IsNumeric(TxtCliente.Text.Split("-")(1)) Then

                            Dim sSucursal As String
                            Dim sClaveCte As String

                            sSucursal = String.Format("{0:000}", Val(CDbl(TxtCliente.Text.Split("-")(0))))
                            sClaveCte = String.Format("{0:0000000}", Val(CDbl(TxtCliente.Text.Split("-")(1))))

                            TxtCliente.Text = sSucursal & "-" & sClaveCte
                        End If
                    End If
                End If

                Dim dt As DataTable
                dt = ModPOS.SiExisteRecupera("sp_recupera_clavecte", "@Clave", TxtCliente.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual, "@SUCClave", SUCClave)
                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                    changeClient(dt.Rows(0)("CTEClave"))
                    dt.Dispose()
                Else
                    MessageBox.Show("No se encontro registro que coincida con la clave proporcionada", "Información", MessageBoxButtons.OK)
                End If
            End If
        End If
    End Sub

    Private Sub TxtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidad.KeyPress

        If Asc(e.KeyChar) = 13 Then
            If Not TxtCantidad.Text = vbNullString Then
                If CDbl(TxtCantidad.Text) <= 0 Then
                    Cantidad = 1
                    TxtCantidad.Text = CStr(Cantidad)
                Else
                    Cantidad = Math.Abs(CDbl(TxtCantidad.Text))
                End If
            Else
                Cantidad = 1
                TxtCantidad.Text = CStr(Cantidad)
            End If
            TxtProducto.Focus()

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

    Private Sub recalculaDocumento()
        Dim dtventadetalle As DataTable

        dtventadetalle = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)

        Dim frmstatusmessage As frmStatus = Nothing

        frmstatusmessage = New frmStatus
        frmstatusmessage.Show("Estamos recalculando el documento debido a que el Tipo de Impuesto del Destino ha cambiado ...")

        'reinicializa venta
        ModPOS.Ejecuta("st_reinicia_venta", "@VENClave", VENClave)


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


        If Not dtventadetalle Is Nothing Then
            Dim i As Integer = 0

            For i = 0 To dtventadetalle.Rows.Count - 1
                If CStr(dtventadetalle.Rows(i)("centroSuministro")) = "" Then
                    AgregaGTIN(dtventadetalle.Rows(i)("Clave"), True, False, False, dtventadetalle.Rows(i)("Cantidad"), #1/1/1900#, #1/1/1900#, False, True)
                End If
            Next
            dtventadetalle.Dispose()

        End If

        frmstatusmessage.Close()

    End Sub


    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Dim NoPagar As Boolean = False

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

                If cmbSucursal.SelectedValue Is Nothing Then
                    MessageBox.Show("!Debe especificar la sucursal que realizara el surtido¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

              

                If TipoDocumento = 1 OrElse TipoDocumento = 3 Then
                    If ModPOS.ValidaEnvio(Packing, True, VENClave, CTEClaveActual, VentaCerrada, ALMClave, "TPV") = False Then
                        Exit Sub
                    End If

                    Dim dtFletera As DataTable

                    dtFletera = ModPOS.Recupera_Tabla("st_valida_cobertura_paqueteria", "@VENClave", VENClave)

                    If dtFletera.Rows.Count = 1 Then
                        Dim foundRows2() As System.Data.DataRow
                        foundRows2 = dtPedidoDetalle.Select(" PROClave = '" & CStr(dtFletera.Rows(0)("productoFlete")) & "' and Baja = 0 ")

                        If foundRows2 Is Nothing OrElse foundRows2.Length = 0 Then


                            MessageBox.Show("!Se realizará un Cargo por la paqueteria seleccionada¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)



                            'Valida cobertura
                            If CInt(dtFletera.Rows(0)("ZonaCobertura")) = -1 Then
                                MessageBox.Show("!El Código Postal se encuentra fuera de cobertura para la Paqueteria seeleccionada¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            ModPOS.Ejecuta("st_agregar_flete", _
                                           "@VENClave", VENClave, _
                                           "@PAQClave", dtFletera.Rows(0)("PAQClave"), _
                                           "@Zona", dtFletera.Rows(0)("ZonaCobertura"), _
                                           "@codigoPostal", dtFletera.Rows(0)("codigoPostal"))

                            ActualizaDetalle(VENClave, True)

                            Exit Sub
                        End If
                    End If

                    If Picking = True Then
                        Dim TipoImpuesto As Integer
                        Dim dti As DataTable
                        dti = ModPOS.Recupera_Tabla("sp_recupera_envio", "@VENClave", VENClave)

                        TipoImpuesto = IIf(dti.Rows(0)("TipoImpuesto").GetType.Name = "DBNull", TImpuesto, dti.Rows(0)("TipoImpuesto"))
                        dti.Dispose()

                        If TipoImpuesto <> TImpuesto Then
                            TImpuesto = TipoImpuesto
                            recalculaDocumento()
                            Exit Sub
                        End If
                    End If

                    If bComplemento = True Then
                        If ValidaComplemento(VENClave) = False Then
                            BtnAddenda.PerformClick()
                            Exit Sub
                        End If
                    End If
                End If

                Dim dtAuditoria As DataTable

                dtAuditoria = ModPOS.Recupera_Tabla("st_auditoria_venta", "@VENClave", VENClave)
                If dtAuditoria.Rows.Count > 0 Then
                    MessageBox.Show("El producto " & dtAuditoria.Rows(0)("Clave") & " cuenta con una inconsistencia de precio, eliminelo del pedido e intente nuevametne", "Información", MessageBoxButtons.OK)
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

                'If ValidaInventario = True AndAlso TipoDocumento <> 2 Then
                '    If VerificaExistencia(1, VENClave, AlmacenSurtido) = False Then
                '        Exit Sub
                '    End If
                'End If

                'Validar Limite de Credito
                If TipoDocumento = 3 Then
                    Dim iValidaCredito As Integer

                    iValidaCredito = ModPOS.ValidaCredido(CtaMaestra, LimiteCredito, DiasCredito, TotalVenta, TipoCambio)

                    If iValidaCredito = 0 Then
                        Exit Sub
                    ElseIf iValidaCredito = -1 Then
                        CreditoDisponible = ModPOS.recuperaDatosCredito(CtaMaestra)
                        If CreditoDisponible < (TotalVenta * TipoCambio) Then
                            MessageBox.Show("El limite de crédito disponible es de " & Format(CStr(ModPOS.Redondear(CreditoDisponible, 2)), "Currency") & ", la venta actual lo sobrepasa por " & Format(CStr(ModPOS.Redondear((TotalVenta * TipoCambio) - CreditoDisponible, 2)), "Currency"), "Información", MessageBoxButtons.OK)
                            Exit Sub
                        End If
                        If CInt(txtDias.Text) <= 0 Then
                            MessageBox.Show("El Cliente no cuenta con dias de credito definidos", "Información", MessageBoxButtons.OK)
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


                'Valida si el pedido actual tiene posiciones en BackOrder a otras Sucursales

                foundRows = dtPedidoDetalle.Select("centroSuministro <> '' and Baja = 0")
                Dim nVENClave As String = ""
                Dim nEstadoDocumento As Integer = 0
                Dim nTotalVenta As Decimal = 0

                If foundRows.Length > 0 Then
                    foundRows = dtPedidoDetalle.Select("centroSuministro = '' and Baja = 0")
                    If foundRows.Length > 0 Then
                        Dim msg As New FrmMsgGral
                        msg.ShowDialog()
                        If msg.DialogResult = DialogResult.OK Then
                            If msg.Dividir = True Then
                                ' Dividir Pedido
                                Dim dtResult As DataTable
                                dtResult = recuperaEjecucion("stpr_split_pedido", "@PDVClave", PDVClave, "@Picking", Picking, "@VENClave", VENClave, "@ALMClave", AlmacenSurtido, "@MONClave", MonedaActual, "@TipoCambio", TipoCambio)
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

                ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", EstadoDocumento, "@ALMClave", AlmacenSurtido, "@Folio", LblFolio.Text, "@MONClave", MonedaActual, "@TipoCambio", TipoCambio, "@TipoImpuesto", TImpuesto)

                ModPOS.Ejecuta("sp_agrega_venta", "@VENClave", VENClave)

                If VentaNueva AndAlso (TipoDocumento <> 2) AndAlso Picking = False Then '= 3 OrElse TipoDocumento = 4)
                    ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", CTEClaveActual, "@Importe", (TotalVenta * TipoCambio))
                End If


                If nVENClave <> "" Then
                    EstadoDocumento = nEstadoDocumento
                    VENClave = nVENClave
                    TotalVenta = nTotalVenta
                    SaldoVenta = TotalVenta
                End If

                modificaStatus(TipoDocumento, EstadoDocumento)


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

                    'Si la venta es de tipo Contado
                    If TipoDocumento = 1 Then
                        'Valida si tiene Anticipos pendientes de Aplicar
                        Dim dtAnticipos As DataTable = ModPOS.Recupera_Tabla("st_recupera_anticipo", "@CTEClave", CTEClaveActual)
                        If dtAnticipos.Rows.Count > 0 Then

                            'Validar Promociones Pago
                            Dim i As Integer
                            Dim dtPromo As DataTable

                            dtPromo = ModPOS.Recupera_Tabla("st_valida_pago_promo", "@VENClave", VENClave)


                            If dtPromo.Rows.Count = 0 Then

                                Dim b As New FrmAbnPendiente
                                b.BtnCancel.Text = "Ignorar"
                                b.MonRef = MonRefBase
                                b.Abonos = dtAnticipos
                                b.SaldoDocumento = TotalVenta * TipoCambio
                                b.ShowDialog()
                                If b.DialogResult = DialogResult.OK Then



                                    If Not b.drAbonos Is Nothing AndAlso b.drAbonos.Length > 0 Then

                                        Dim dtOrdenada As DataTable
                                        dtOrdenada = b.drAbonos.CopyToDataTable()
                                        Dim SaldoBase As Decimal = TotalVenta * TipoCambio

                                        For Each row As DataRow In dtOrdenada.Select("", "SaldoBase ASC")

                                            If CDec(row("SaldoBase")) >= SaldoBase Then
                                                ModPOS.Ejecuta("st_abn_pendiente", "@VENClave", VENClave, "@ABNClave", row("ID"), "@Importe", SaldoBase)
                                                SaldoBase = 0

                                            Else
                                                ModPOS.Ejecuta("st_abn_pendiente", "@VENClave", VENClave, "@ABNClave", row("ID"), "@Importe", CDec(row("SaldoBase")))
                                                SaldoBase -= CDec(row("SaldoBase"))
                                            End If
                                            If SaldoBase <= 0 Then
                                                Exit For
                                            End If

                                        Next
                                        dtOrdenada.Dispose()

                                    End If
                                End If

                            Else

                                MessageBox.Show("El documento, tiene promociones que limitan esta forma de pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            End If

                        End If
                            dtAnticipos.Dispose()
                        End If


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


            If Picking = False AndAlso Remoto = 0 AndAlso EstadoDocumento <> iEstado.BackOrder Then
                If ((TipoDocumento = 3 AndAlso VentaNueva = False) OrElse (TipoDocumento = 1 OrElse TipoDocumento = 4)) AndAlso Caja AndAlso SaldoVenta > 0 Then

                    Dim idEvento As String = ""
                    Do
                        Dim a As New FrmAbono
                        a.SUCClave = SUCClave
                        a.Aplicacion = Aplicacion
                        a.TipoDocumento = 1
                        a.CAJA = CAJClave
                        a.ClaveCaja = CajaClave
                        a.ClaveCte = CTEClaveActual
                        a.ClaveDocumento = VENClave
                        a.AperturaCajon = Cajon
                        a.ImpresoraCajon = Impresora
                        a.ConfirmarAbono = ConfirmarAbono
                        a.SaldoAcumulado = TruncateToDecimal(SaldoVenta * TipoCambio, 2)
                        a.ShowDialog()
                        If a.DialogResult = DialogResult.OK Then
                            If a.detallePago.Rows.Count > 0 Then
                                Dim i As Integer
                                idEvento = IIf(idEvento = "", a.id_evento, idEvento)
                                TotalRecibido += (a.TotalAbono / TipoCambio)
                                TotalCambio += (a.TotalCambio / TipoCambio)
                                SaldoVenta -= ((a.TotalAbono - a.TotalCambio) / TipoCambio)


                                Dim dtVenta As DataTable = ModPOS.CrearTabla("Venta", _
                                                                           "ID", "System.String", _
                                                                           "TipoDocumento", "System.Int32", _
                                                                           "SaldoBase", "System.Decimal", _
                                                                           "TipoCambio", "System.Decimal")
                                Dim row1 As DataRow
                                row1 = dtVenta.NewRow()
                                row1.Item("ID") = VENClave
                                row1.Item("TipoDocumento") = 1
                                row1.Item("SaldoBase") = a.SaldoVenta
                                row1.Item("TipoCambio") = TipoCambio

                                dtVenta.Rows.Add(row1)

                                For i = 0 To a.detallePago.Rows.Count - 1
                                    ModPOS.Aplica_Pagos(dtVenta, CTEClaveActual, a.detallePago.Rows(i)("ABNClave"), a.detallePago.Rows(i)("TipoPago"), a.detallePago.Rows(i)("SaldoBase"), CAJClave, 1, a.detallePago.Rows(i)("FechaPago"), idEvento)
                                Next
                                a.Dispose()
                            Else
                                a.Dispose()
                            End If

                            If SaldoVenta > 0 Then
                                If TipoDocumento <> 1 Then
                                    Select Case MessageBox.Show("La venta actual no ha sido totalmente pagada, su saldo es: " & Format(CStr(ModPOS.Redondear(SaldoVenta, 2)), "Currency") & ", ¿Desea pagar el saldo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                        Case DialogResult.Yes
                                            NoPagar = False
                                        Case Else
                                            NoPagar = True
                                            Exit Do
                                    End Select
                                Else
                                    NoPagar = False
                                End If
                            End If
                        End If
                    Loop While TruncateToDecimal(SaldoVenta, 2) > 0 AndAlso Not NoPagar

                    If TotalRecibido > 0 Then

                        EstadoDocumento = iEstado.Pagado

                        modificaStatus(TipoDocumento, EstadoDocumento)

                        Dim msg As New FrmMeMsg

                        msg.TxtTiulo = "Su Cambio es:"

                        msg.TxtMsg = MonRefBase & " " & Format(CStr(Math.Round(TotalCambio, 2)), "Currency")
                        msg.TxtMsg2 = Letras(CStr(Math.Round(TotalCambio, 2))).ToUpper & " " & MonRefBase
                        msg.StartPosition = FormStartPosition.CenterScreen
                        msg.BringToFront()
                        msg.ShowDialog()
                        msg.Dispose()


                        If Display = True Then
                            Try
                                'limpiar
                                Dim LimpiarDisplay As String = Chr(12)
                                mySerialPort.Write(LimpiarDisplay)
                                mySerialPort.Write("RECIBIDO: " & Format(CStr(ModPOS.TruncateToDecimal(TotalRecibido, 2)), "Currency") & " " & MonRefBase)
                                If NoLineas > 1 AndAlso TotalAhorro > 0 Then
                                    Dim BajarCursor As String = Chr(10)
                                    mySerialPort.Write(BajarCursor)
                                    'Recorrer Izq
                                    Dim MoverIzq As String = Chr(13)
                                    mySerialPort.Write(MoverIzq)
                                    mySerialPort.Write("CAMBIO: " & Format(CStr(Math.Round(TotalCambio, 2)), "Currency") & " " & MonRefBase)
                                End If
                            Catch ex As Exception
                            End Try
                        End If

                    End If

                End If

            End If

            Dim frmStatusMessage As New frmStatus

            If Remoto = 0 Then
                If Picking = False OrElse TipoDocumento = 2 OrElse TipoDocumento = 4 Then


                    Select Case MessageBox.Show("¿Desea Imprimir el Documento?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.Yes
                            frmStatusMessage.Show("Imprimiendo...")

                            ImprimirPedido(VENClave, EstadoDocumento, TotalVenta)

                            frmStatusMessage.Dispose()
                    End Select


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
                                        If Packing = True Then
                                            Dim dtp As DataTable
                                            dtp = ModPOS.Recupera_Tabla("sp_recupera_envio", "@VENClave", VENClave)
                                            TipoEntrega = dtp.Rows(0)("tipoEntrega")
                                            dtp.Dispose()
                                        End If

                                        If Not (Packing = True AndAlso TipoEntrega = 3) Then
                                            ModPOS.ImprimirSurtido(1, VENClave, False, True, SUCClave, TIKClave, ticketPicking, TallaColor)
                                        End If
                                    Else
                                        ModPOS.Ejecuta("st_inserta_printspooler", "@TipoDocumento", 1, "@DOCClave", VENClave, "@Reimpresion", False, "@Usuario", ModPOS.UsuarioActual)
                                    End If
                                Else
                                    Select Case MessageBox.Show("¿Desea Reimprimir la Hoja de Recolección?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                        Case DialogResult.Yes

                                            If ImprimirRemoto = 0 Then
                                                If Packing = True Then
                                                    Dim dtp As DataTable
                                                    dtp = ModPOS.Recupera_Tabla("sp_recupera_envio", "@VENClave", VENClave)
                                                    TipoEntrega = dtp.Rows(0)("tipoEntrega")
                                                    dtp.Dispose()
                                                End If

                                                If Not (Packing = True AndAlso TipoEntrega = 3) Then
                                                    ModPOS.ImprimirSurtido(1, VENClave, True, True, SUCClave, TIKClave, ticketPicking, TallaColor)
                                                End If
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
            CambiarCliente = False
            btnBuscaCte.Enabled = False
            BtnCancelaProducto.Enabled = False
            BtnCancelaTicket.Enabled = False
            btnEnvio.Enabled = False
            TxtCantidad.Enabled = False
            TxtProducto.Enabled = False
            TxtCliente.Enabled = False
            cmbTipoCanal.Enabled = False
            BtnTC.Enabled = False
            VentaNueva = False
            BtnCerrar.Enabled = True
            BtnConvertir.Enabled = False
            BtnWait.Enabled = False

            'Solicita Retiro de Caja
            If Picking = False And Remoto = 0 Then
                If VentaCerrada AndAlso Caja AndAlso TotalRecibido > 0 AndAlso MaxEfectivo > 0 Then

                    Dim dt As DataTable

                    dt = ModPOS.Recupera_Tabla("sp_busca_corteCaja", "@CAJClave", CAJClave)
                    Dim IDCorte As String = dt.Rows(0)("ID")

                    dt = Recupera_Tabla("st_recupera_efectivo", "@IDCorte", IDCorte)
                    Dim MontoEfectivo As Decimal = 0
                    Dim FondoCaja As Decimal = 0
                    If dt.Rows.Count > 0 Then
                        MontoEfectivo = CDec(dt.Rows(0)("Efectivo")) - CDec(dt.Rows(0)("FondoCaja"))
                        dt.Dispose()
                    End If

                    If MontoEfectivo >= MaxEfectivo Then
                        MessageBox.Show("El monto de fectivo maximo recomendado (" & Strings.Format(Redondear(MaxEfectivo, 2).ToString, "Currency") & ") se ha excedido. Le recordamos realizar el retiro de fectivo de caja", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Dim a As New FrmRetiroCaja
                        a.bRetiroProgramado = True
                        a.SUCClave = SucursalSurtido
                        a.ALMClave = ALMClave
                        a.CAJClave = CAJClave
                        a.Referencia = CajaClave
                        a.Impresora = Impresora
                        a.Generic = PrintGeneric
                        a.Ticket = Ticket
                        a.Cajon = Cajon
                        If a.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        End If
                    End If

                End If
            End If
        Else
            Beep()
            MessageBox.Show("El documento actual no puede ser cerrado sin productos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Dejar(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCliente.Leave
        TxtProducto.Focus()
    End Sub

    Private Sub TxtCantidad_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCantidad.Leave
        If Not TxtCantidad.Text = vbNullString Then
            If CDbl(TxtCantidad.Text) <= 0 Then
                Cantidad = 1
                TxtCantidad.Text = CStr(Cantidad)
            Else
                Cantidad = Math.Abs(CDbl(TxtCantidad.Text))
            End If

        Else
            Cantidad = 1
            TxtCantidad.Text = CStr(Cantidad)
        End If

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


    Private Sub BtnCancelaTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelaTicket.Click
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
                MessageBox.Show("El documento seleccionado No puede ser Cancelado debido a que se encuentra en proceso de recolección o ya ha sido cancelado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
        dt.Dispose()

        If EstadoDocumento = 2 AndAlso Caja = False Then
            MessageBox.Show("El documento No puede ser Cancelado debido a que se encuentra cerrado y no se tiene una Caja Activa", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If TotalArticulos > 0 Then

            If TotalVenta = SaldoVenta Then

                If TipoDocumento <> 2 Then
                    Dim a As New MeAutorizacion
                    a.Sucursal = SucursalSurtido
                    a.MontodeAutorizacion = TotalVenta * TipoCambio
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If Not a.Autorizado Then
                            a.Dispose()

                            Exit Sub
                        End If
                        Autoriza = a.Autoriza
                    ElseIf a.DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                        a.Dispose()
                        Exit Sub
                    End If
                    a.Dispose()
                Else
                    Autoriza = ModPOS.UsuarioActual
                End If

                If TipoDocumento <> 2 Then
                    Do
                        Dim m As New FrmMotivo
                        m.Tabla = "Venta"
                        m.Campo = "Cancelacion"
                        m.ShowDialog()
                        If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                            bmotivo = True
                            motCancelacion = m.Motivo
                        End If
                        m.Dispose()
                    Loop While bmotivo = False
                End If

                If Not VentaCerrada Then

                    If EstadoDocumento = 9 Then
                        'Libera Apatados
                        ModPOS.Ejecuta("st_libera_apartado", "@VENClave", VENClave, "@ALMClave", AlmacenSurtido, "@Usuario", ModPOS.UsuarioActual)
                    End If


                    EstadoDocumento = iEstado.Cancelada

                    ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", EstadoDocumento, "@ALMClave", AlmacenSurtido, "@Folio", LblFolio.Text, "@MONClave", MonedaActual, "@TipoCambio", TipoCambio, "@TipoImpuesto", TImpuesto)

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
                Else
                    ModPOS.Ejecuta("sp_cancela_venta", "@VENClave", VENClave, "@TipoDoc", TipoDocumento, "@Motivo", motCancelacion, "@Autoriza", Autoriza)

                    If (TipoDocumento = 1 OrElse TipoDocumento = 3) Then
                        If Picking = False Then
                            ModPOS.GeneraMovInv(1, 5, 1, VENClave, AlmacenSurtido, LblFolio.Text, Autoriza, Picking)
                        ElseIf ALMClave = AlmacenSurtido Then
                            If EstadoDocumento = 9 Then
                                'Libera Apatados
                                ModPOS.Ejecuta("st_libera_apartado", "@VENClave", VENClave, "@ALMClave", AlmacenSurtido, "@Usuario", ModPOS.UsuarioActual)
                            Else
                                ModPOS.Ejecuta("sp_cancela_picking", "@Tipo", 1, "@DOCClave", VENClave, "@ALMClave", ALMClave, "@Usuario", ModPOS.UsuarioActual)
                            End If
                        End If
                    End If

                    If TipoDocumento <> 2 Then
                        ModPOS.Ejecuta("sp_cancela_puntos", "@Documento", VENClave, "@Tipo", 1)
                        If EstadoDocumento = 2 AndAlso (TipoDocumento = 1 OrElse TipoDocumento = 3 OrElse TipoDocumento = 4) Then
                            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", CTEClaveActual, "@Importe", (TotalVenta * TipoCambio))
                        End If
                    End If

                    EstadoDocumento = iEstado.Cancelada
                End If



                SeCancela = True

            Else
                MsgBox("No se puede cancelar el ticket debido a que tiene pagos aplicados. Realice una devolución de producto", MsgBoxStyle.Information, "Información")
                Exit Sub
            End If
        Else

            EstadoDocumento = iEstado.Cancelada
            Dim strFolio As String
            strFolio = Referencia & Microsoft.VisualBasic.Right(CStr(Periodo), 2) & Microsoft.VisualBasic.Right("0" & CStr(Mes), 2) & "-" & CStr(Folio)

            If LblFolio.Text = strFolio Then
                ModPOS.Ejecuta("sp_act_folio", "@PDVClave", PDVClave, "@Incremento", -1, "@Tipo", 1)
                ModPOS.Ejecuta("sp_elimina_venta", "@VENClave", VENClave)
            Else
                Do
                    Dim m As New FrmMotivo
                    m.Tabla = "Venta"
                    m.Campo = "Cancelacion"
                    m.ShowDialog()
                    If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                        bmotivo = True
                        motCancelacion = m.Motivo
                    End If
                    m.Dispose()
                Loop While bmotivo = False


                ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", EstadoDocumento, "@ALMClave", AlmacenSurtido, "@Folio", LblFolio.Text, "@MONClave", MonedaActual, "@TipoCambio", TipoCambio, "@TipoImpuesto", TImpuesto)
                ModPOS.Ejecuta("sp_cancela_ticket", "@VENClave", VENClave, "@ALMClave", AlmacenSurtido, "@TipoDoc", TipoDocumento, "@Motivo", motCancelacion, "@Autoriza", ModPOS.UsuarioActual)
                ModPOS.Ejecuta("sp_agrega_venta", "@VENClave", VENClave)
            End If
            SeCancela = True
        End If

        If SeCancela Then
            VentaCerrada = True
            CambiarCliente = False
            btnBuscaCte.Enabled = False
            BtnCancelaProducto.Enabled = False
            BtnCancelaTicket.Enabled = False
            btnEnvio.Enabled = False
            BtnCerrar.Enabled = False
            TxtCantidad.Enabled = False
            TxtProducto.Enabled = False
            TxtCliente.Enabled = False
            cmbTipoCanal.Enabled = False
            BtnTC.Enabled = False
            GeneraMovSalida = False
            BtnConvertir.Enabled = False
            BtnWait.Enabled = False
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
                If MonedaActual <> Moneda Then

                    If TipoCambio > 0 Then
                        LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                    End If
                Else
                    If MonTipoCambio > 0 Then
                        LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                    End If
                End If
            Else
                If MonedaActual <> Moneda Then

                    If TipoCambio > 0 Then
                        LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                    End If
                Else
                    LblTipoCambio.Text = ""
                End If
            End If

            LblFolio.Text = Referencia & Microsoft.VisualBasic.Right(CStr(Periodo), 2) & Microsoft.VisualBasic.Right("0" & CStr(Mes), 2) & "-0"

            cambiaStatus("", iEstado.Original)

            MsgBox("La Venta o Cotización ha sido cancelada exitosamente", MsgBoxStyle.Information, "Información")


        End If
    End Sub

    Private Sub BtnCancelaProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelaProducto.Click
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
                VentaCerrada = True
                modificaStatus(TipoDocumento, EstadoDocumento)
                MessageBox.Show("No es posible modificar el Documento, ya que No se encuentra Abierto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            dt.Dispose()

            If TotalArticulos > 0 Then
                Dim a As New FrmCancelaProducto
                a.SucursalPadre = Me.SucursalPadre
                a.SUCClave = SUCClave
                a.bVentaConvencional = True
                a.TipoDoc = TipoDocumento
                a.ALMClave = AlmacenSurtido
                a.VENClave = VENClave
                a.Picking = Me.Picking
                a.CTEClaveActual = Me.CTEClaveActual
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If a.SeCancela Then


                        If AplicaPromocionFinal = 0 AndAlso TipoDocumento <> 2 Then
                            Dim msg As String = ModPOS.Ejecuta("st_aplicar_promociones", _
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
                            If MonedaActual <> Moneda Then

                                If TipoCambio > 0 Then
                                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                                Else
                                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                                End If
                            Else
                                If MonTipoCambio > 0 Then
                                    LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                                Else
                                    LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                                End If
                            End If
                        Else
                            If MonedaActual <> Moneda Then

                                If TipoCambio > 0 Then
                                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                                Else
                                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                                End If
                            Else
                                LblTipoCambio.Text = ""
                            End If
                        End If


                        If TotalArticulos = 0 Then
                            CambiarCliente = True
                            btnBuscaCte.Enabled = True
                            TxtCliente.Enabled = True
                            cmbTipoCanal.Enabled = True
                            BtnTC.Enabled = True
                        End If


                    End If
                ElseIf a.DialogResult = Windows.Forms.DialogResult.Cancel Then
                    a.Dispose()
                    Exit Sub
                End If
                a.Dispose()
            Else
                MsgBox("La venta o Cotización actual no tiene productos", MsgBoxStyle.Information, "Información")
            End If
        End If
        TxtProducto.Focus()

    End Sub

    Private Sub BtnBusquedaProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBusquedaProducto.Click


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


        If cmbTipoCanal.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar un Canal de Venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If VentaCerrada OrElse TotalArticulos = 0 Then
            Dim dtCliente As DataTable
            dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", sCliente, "@TipoCanal", cmbTipoCanal.SelectedValue)
            If dtCliente.Rows.Count > 0 Then
                ListaPrecio = dtCliente.Rows(0)("PREClave")
                ' TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                dtCliente.Dispose()
            Else
                dtCliente.Dispose()
                MessageBox.Show("El Cliente No cuenta con Precio para el Canal de Venta seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        Dim a As New FrmBuscaProducto
        a.TipoCambio = TipoCambio
        a.bVentaConvencional = True
        a.numMostrador = Me.numMostrador
        a.url_imagen = Me.url_imagen
        a.SUCClave = Me.SUCClave
        a.ClienteActual = sCliente
        a.PuntodeVenta = PDVClave
        a.Almacen = AlmacenSurtido
        a.ListadePrecio = ListaPrecio
        a.StatusVenta = VentaCerrada
        a.TImpuesto = TImpuesto
        a.BusquedaInicial = True
        a.Busqueda = TxtProducto.Text.Trim.ToUpper
        a.TxtAlmacen.Text = sAlmacen
        a.bMessage = Me.bMessage
        a.ModificaPrecioServicio = Me.ModificaPrecioServicio
        a.ShowDialog()
        a.Dispose()

        TxtProducto.Focus()

        Me.bMessage = False

    End Sub






    Private Sub BtnWait_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWait.Click
        If Not VentaCerrada Then
            If TotalArticulos > 0 Then

                If TipoDocumento = 1 OrElse TipoDocumento = 3 Then
                    If ModPOS.ValidaEnvio(Packing, True, VENClave, CTEClaveActual, VentaCerrada, ALMClave, "TPV") = False Then
                        Exit Sub
                    End If

                    If bComplemento = True Then
                        If ValidaComplemento(VENClave) = False Then
                            BtnAddenda.PerformClick()
                            Exit Sub
                        End If
                    End If
                End If

                ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", 6, "@ALMClave", ALMClave, "@MONClave", MonedaActual, "@TipoCambio", TipoCambio, "@TipoImpuesto", TImpuesto)

                VentaCerrada = True
                CambiarCliente = False
                btnBuscaCte.Enabled = False
                BtnCancelaProducto.Enabled = False
                BtnCancelaTicket.Enabled = False
                btnEnvio.Enabled = False
                BtnCerrar.Enabled = False
                TxtCantidad.Enabled = False
                TxtProducto.Enabled = False
                TxtCliente.Enabled = False
                cmbTipoCanal.Enabled = False
                BtnTC.Enabled = False
                GeneraMovSalida = False
                BtnConvertir.Enabled = False
                BtnWait.Enabled = False
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
                    If MonedaActual <> Moneda Then

                        If TipoCambio > 0 Then
                            LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                        Else
                            LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                        End If
                    Else
                        If MonTipoCambio > 0 Then
                            LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                        Else
                            LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                        End If
                    End If
                Else
                    If MonedaActual <> Moneda Then

                        If TipoCambio > 0 Then
                            LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                        Else
                            LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                        End If
                    Else
                        LblTipoCambio.Text = ""
                    End If
                End If

                LblFolio.Text = Referencia & Microsoft.VisualBasic.Right(CStr(Periodo), 2) & Microsoft.VisualBasic.Right("0" & CStr(Mes), 2) & "-0"

                cambiaStatus("", iEstado.Original)



                MsgBox("El documento ha sido guarado y puesto en Espera exitosamente", MsgBoxStyle.Information, "Información")
            Else
                MsgBox("Debe agregar productos al documento para poder ponerlo en Espera", MsgBoxStyle.Information, "Información")
            End If
        Else
            MsgBox("Los documentos en estado Cerrado o Cancelado no pueden ser puestos en Espera", MsgBoxStyle.Information, "Información")
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
        Dim iTipoCanal As Integer = 0
        dtVta = ModPOS.SiExisteRecupera("sp_recupera_vta_open", "@VENClave", sVENClave)

        If Not dtVta Is Nothing Then
            FechaVenta = CDate(dtVta.Rows(0)("Fecha"))
            MonedaActual = IIf(dtVta.Rows(0)("MONClave").GetType.Name = "DBNull", Moneda, dtVta.Rows(0)("MONCLave"))
            iTipoCanal = dtVta.Rows(0)("TipoCanal")
            cmbTipoCanal.SelectedValue = iTipoCanal
        End If


        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaActual)
        MonedaRef = dt.Rows(0)("Referencia")
        MonedaDesc = dt.Rows(0)("Descripcion")
        dt.Dispose()

        BtnTC.Text = MonedaRef
        TipoCambio = dtVta.Rows(0)("TipoCambio")

        dt = ModPOS.Recupera_Tabla("sp_recupera_alm", "@ALMClave", sAlmacen)

        If dt.Rows.Count > 0 Then
            bLoad = False
            cmbSucursal.SelectedValue = dt.Rows(0)("SUCClave")
            AlmacenSurtido = dt.Rows(0)("ALMClave")
            sAlmacen = dt.Rows(0)("Clave") & " - " & dt.Rows(0)("Nombre")
            bLoad = True
        End If
        dt.Dispose()

        If sVENClave = "" Then
            Exit Sub
        End If

        VENClave = sVENClave

      
        recuperaCliente(sCTEClave)

        BtnCancelaProducto.Enabled = True
        BtnCancelaTicket.Enabled = True
        btnEnvio.Enabled = True
        BtnCerrar.Enabled = True
        TxtCantidad.Enabled = True
        TxtProducto.Enabled = True
        BtnConvertir.Enabled = True
        BtnWait.Enabled = True

        txtLimite.Text = Limite
        txtDias.Text = Dias
        txtSaldo.Text = SaldoCliente

        If CTEClaveActual = CTEClaveInicial Then
            txtSaldo.Visible = False
            lblSaldo.Visible = False
        Else
            txtSaldo.Visible = True
            lblSaldo.Visible = True
        End If

        With Me
            TotalArticulos = 0
            TotalPuntos = 0
            TotalVenta = 0
            TotalRecibido = 0
            TotalCambio = 0
            TotalAhorro = 0
            TotalVenta = 0

          
            .VentaNueva = True
            .VentaCerrada = False
            .GeneraMovSalida = True

            .LblFolio.Text = sFolio

            Dim sFol As String = sFolio


            Dim iArray As Integer = sFol.Split("-").Length - 1

            Folio = CInt(sFol.Split("-")(iArray))

            .AtiendeClave = sCajero
            .ReferenciaUsr = sReferenciaCaj
            .AtiendeNombre = sNombreUsuario
            .LblUsuario.Text = .AtiendeNombre
            .TipoDocumento = iTipo


           


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
            dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", sCliente, "@TipoCanal", iTipoCanal)
            .ListaPrecio = dtCliente.Rows(0)("PREClave")
            ' .TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
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
                            'Elimina partida y libera apartado

                            bRemoto = False
                            If foundRows(i)("centroSuministro") <> "" Then
                                bRemoto = True
                            End If

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


                            AgregaCancelado(foundRows(i)("DVEClave"), foundRows(i)("Clave") & " " & foundRows(i)("Nombre"), foundRows(i)("Total") / CantidadEliminar, CantidadEliminar, foundRows(i)("PuntosImp"))



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




            'End If 'Recalcular

            If TotalArticulos > 0 Then
                CambiarCliente = False
                btnBuscaCte.Enabled = False
                TxtCliente.Enabled = False
                BtnTC.Enabled = False
                cmbTipoCanal.Enabled = False
            Else
                CambiarCliente = True
                btnBuscaCte.Enabled = True
                TxtCliente.Enabled = True
                BtnTC.Enabled = True
                cmbTipoCanal.Enabled = True
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

        Dim iTipoCanal As Integer = 0
        If Not dtVenta Is Nothing Then


            btnBuscaCte.Enabled = False
            BtnCancelaProducto.Enabled = False
            BtnCancelaTicket.Enabled = True

            btnEnvio.Enabled = True
            BtnCerrar.Enabled = True

            TxtCantidad.Enabled = False
            TxtProducto.Enabled = False

            TxtCliente.Enabled = False
            cmbTipoCanal.Enabled = False
            BtnTC.Enabled = False
            VentaCerrada = True
            GeneraMovSalida = False
            VentaNueva = False

            dtPedidoDetalle.Clear()
            'recupera ticket
            iTipoCanal = dtVenta.Rows(0)("TipoCanal")
            cmbTipoCanal.SelectedValue = iTipoCanal

            VENClave = dtVenta.Rows(0)("VENClave")
            LblFolio.Text = dtVenta.Rows(0)("Folio")
            CTEClaveActual = dtVenta.Rows(0)("CTEClave")

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
            TxtCliente.Text = ""

            recuperaCliente(CTEClaveActual)

            modificaStatus(TipoDocumento, EstadoDocumento)


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
            dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Sucursal", SUCClave, "@Cliente", sCliente, "@TipoCanal", iTipoCanal)
            ListaPrecio = dtCliente.Rows(0)("PREClave")
            ' TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
            dtCliente.Dispose()

            If TipoDocumento = 2 OrElse TipoDocumento = 4 Then
                btnEnvio.Enabled = False
            End If


            'recupera partida
            dtVenta.Dispose()

            ActualizaDetalle(VENClave, False)

            If dtPedidoDetalle.Rows.Count > 0 Then
                CambiarCliente = False
                btnBuscaCte.Enabled = False
                TxtCliente.Enabled = False
                BtnTC.Enabled = False
                cmbTipoCanal.Enabled = False
            End If

            ModPOS.Ejecuta("sp_agrega_tmp_venta", "@VENClave", VENClave, "@PDVClave", PDVClave)
        Else
            MessageBox.Show("El ticket que intenta recuperar no existe o se encuentra totalmente pagado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub ItemApartado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        cmbSucursal.SelectedValue = SucursalSurtido

        If cmbSucursal.SelectedValue Is Nothing Then
            MessageBox.Show("!Debe especificar la sucursal que realizara el surtido¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If AlmacenSurtido = "" OrElse AlmacenSurtido Is Nothing Then
            Beep()
            MessageBox.Show("No es posible crear el documento debido a que no se ha especificado el Almacen para surtido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        cmbTipoCanal.SelectedValue = TipoCanal

        If cmbTipoCanal.SelectedValue Is Nothing Then
            Beep()
            MessageBox.Show("No es posible crear una nueva venta debido a que no se ha especificado el Canal de Venta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                Me.ReferenciaUsr = a.ReferenciaUsr
                Me.AtiendeClave = a.AtiendeClave
                LblUsuario.Text = AtiendeNombre
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


        If CambiarCliente = False Then
            btnBuscaCte.Enabled = True
            TxtCliente.Enabled = True
            cmbTipoCanal.Enabled = True
            BtnTC.Enabled = True
            CambiarCliente = True
        End If

        ObtenerFolio()

        TipoDocumento = 4
        EstadoDocumento = 1


        modificaStatus(TipoDocumento, EstadoDocumento)

        VENClave = ModPOS.obtenerLlave()

        dt = ModPOS.Recupera_Tabla("st_valida_llave", "@Tipo", 1, "@id", VENClave)
        If dt.Rows.Count = 1 Then
            VENClave = ModPOS.obtenerLlave
        End If
        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
        BtnTC.Text = dt.Rows(0)("Referencia")
        MonedaRef = dt.Rows(0)("Referencia")
        MonedaDesc = dt.Rows(0)("Descripcion")
        TipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
        dt.Dispose()


        If Moneda <> MonedaCambio Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
            MonRefCambio = dt.Rows(0)("Referencia")
            MonDescCambio = dt.Rows(0)("Descripcion")
            MonTipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
            dt.Dispose()

        Else
            MonRefCambio = MonedaRef
            MonDescCambio = MonedaDesc
            MonTipoCambio = TipoCambio
        End If


        MonedaActual = Moneda

        ModPOS.Ejecuta("sp_crea_venta", _
        "@VENClave", VENClave, _
        "@PDVClave", PDVClave, _
        "@Folio", LblFolio.Text, _
        "@Cliente", CTEClaveActual, _
        "@Cajero", AtiendeClave, _
        "@CAJClave", CAJClave, _
        "@Tipo", TipoDocumento, _
        "@ALMClave", AlmacenSurtido, _
        "@TipoCanal", cmbTipoCanal.SelectedValue, _
        "@Usuario", ModPOS.UsuarioActual)

        btnBuscaCte.Enabled = True
        BtnCancelaProducto.Enabled = True
        BtnCancelaTicket.Enabled = True
        btnEnvio.Enabled = False
        BtnCerrar.Enabled = True
        TxtCantidad.Enabled = True
        TxtProducto.Enabled = True
        TxtCliente.Enabled = True
        cmbTipoCanal.Enabled = True
        BtnTC.Enabled = True
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
            If MonedaActual <> Moneda Then

                If TipoCambio > 0 Then
                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                End If
            Else
                If MonTipoCambio > 0 Then
                    LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                End If
            End If
        Else
            If MonedaActual <> Moneda Then

                If TipoCambio > 0 Then
                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                End If
            Else
                LblTipoCambio.Text = ""
            End If
        End If

        TxtProducto.Focus()
    End Sub

    Private Sub ItemCotizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cmbSucursal.SelectedValue = SucursalSurtido

        If cmbSucursal.SelectedValue Is Nothing Then
            MessageBox.Show("!Debe especificar la sucursal que realizara el surtido¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If AlmacenSurtido = "" OrElse AlmacenSurtido Is Nothing Then
            Beep()
            MessageBox.Show("No es posible crear el documento debido a que no se ha especificado el Almacen para surtido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        cmbTipoCanal.SelectedValue = TipoCanal

        If cmbTipoCanal.SelectedValue Is Nothing Then
            Beep()
            MessageBox.Show("No es posible crear una nueva venta debido a que no se ha especificado el Canal de Venta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If ActivarCotizacion = True Then
            If SolicitaVendedor Then

                Dim a As New FrmSolicitaUsuario
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    Me.AtiendeNombre = a.AtiendeNombre
                    Me.ReferenciaUsr = a.ReferenciaUsr
                    Me.AtiendeClave = a.AtiendeClave
                    LblUsuario.Text = AtiendeNombre
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

            If CambiarCliente = False Then
                btnBuscaCte.Enabled = True
                TxtCliente.Enabled = True
                cmbTipoCanal.Enabled = True
                BtnTC.Enabled = True
                CambiarCliente = True
            End If

            ObtenerFolio()

            TipoDocumento = 2

            EstadoDocumento = 1


            modificaStatus(TipoDocumento, EstadoDocumento)


            VENClave = ModPOS.obtenerLlave()

            dt = ModPOS.Recupera_Tabla("st_valida_llave", "@Tipo", 1, "@id", VENClave)
            If dt.Rows.Count = 1 Then
                VENClave = ModPOS.obtenerLlave
            End If
            dt.Dispose()

            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", Moneda)
            BtnTC.Text = dt.Rows(0)("Referencia")
            MonedaRef = dt.Rows(0)("Referencia")
            MonedaDesc = dt.Rows(0)("Descripcion")
            TipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
            dt.Dispose()


            If Moneda <> MonedaCambio Then
                dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
                MonRefCambio = dt.Rows(0)("Referencia")
                MonDescCambio = dt.Rows(0)("Descripcion")
                MonTipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
                dt.Dispose()

            Else
                MonRefCambio = MonedaRef
                MonDescCambio = MonedaDesc
                MonTipoCambio = TipoCambio
            End If


            MonedaActual = Moneda

            ModPOS.Ejecuta("sp_crea_venta", _
            "@VENClave", VENClave, _
            "@PDVClave", PDVClave, _
            "@Folio", LblFolio.Text, _
            "@Cliente", CTEClaveActual, _
            "@Cajero", AtiendeClave, _
            "@CAJClave", CAJClave, _
            "@Tipo", TipoDocumento, _
             "@ALMClave", AlmacenSurtido, _
             "@TipoCanal", cmbTipoCanal.SelectedValue, _
            "@Usuario", ModPOS.UsuarioActual)

            btnBuscaCte.Enabled = True
        
            BtnCancelaProducto.Enabled = True
            BtnCancelaTicket.Enabled = True
            btnEnvio.Enabled = True
            BtnCerrar.Enabled = True
            TxtCantidad.Enabled = True
            TxtProducto.Enabled = True
            TxtCliente.Enabled = True
            cmbTipoCanal.Enabled = True
            BtnTC.Enabled = True
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
                If MonedaActual <> Moneda Then

                    If TipoCambio > 0 Then
                        LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                    End If
                Else
                    If MonTipoCambio > 0 Then
                        LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                    End If
                End If
            Else
                If MonedaActual <> Moneda Then

                    If TipoCambio > 0 Then
                        LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                    End If
                Else
                    LblTipoCambio.Text = ""
                End If
            End If
        End If
        TxtProducto.Focus()
    End Sub



    

    Private Sub ItemCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cmbSucursal.SelectedValue = SucursalSurtido

        If cmbSucursal.SelectedValue Is Nothing Then
            MessageBox.Show("!Debe especificar la sucursal que realizara el surtido¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


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
            a.Cajero = Me.LblUsuario.Text
            a.Referencia = Me.Referencia
            a.ShowDialog()
            a.Dispose()
        Else
            MessageBox.Show("El punto de venta no cuenta con una Caja asignada por lo que no es posible realizar el cambio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnBuscaCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaCte.Click
        Dim a As New MeSearch
        a.MaskCte = MaskCte
        a.Prefijo = SucursalClave
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                If Not VentaCerrada Then
                    If TotalArticulos = 0 Then
                        changeClient(a.valor)
                    Else
                        MessageBox.Show("No es posible cambiar el cliente debido a que existen productos en el documento actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        End If
        a.Dispose()

    End Sub

    Private Sub btnEnvio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnvio.Click
        If VentaCerrada = False Then
            If ModPOS.Envio Is Nothing Then
                ModPOS.Envio = New FrmEnvio
                With ModPOS.Envio
                    .Packing = Packing
                    .Tipo = "TPV"
                    .VENClave = Me.VENClave
                    .CTEClave = Me.CTEClaveActual
                    .ALMClave = Me.AlmacenSurtido
                    .VentaCerrada = Me.VentaCerrada
                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                    .Dispose()
                End With
                ModPOS.Envio = Nothing

                Dim TipoImpuesto As Integer
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_envio", "@VENClave", VENClave)

                TipoImpuesto = IIf(dt.Rows(0)("TImpuesto").GetType.Name = "DBNull", TImpuesto, dt.Rows(0)("TImpuesto"))
                dt.Dispose()

                If TipoImpuesto <> TImpuesto Then
                    TImpuesto = TipoImpuesto
                    recalculaDocumento()
                End If

            End If
        Else
            Beep()
            MessageBox.Show("No es posible modificar los datos de Entrega debido a que la venta actual ha sido Cerrada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    Private Sub picSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub GridDetalle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.DoubleClick
        If GridDetalle.GetValue("Baja") = 0 AndAlso CambiaPrecio = True OrElse ModificaPrecioServicio = True Then

            AgregaGTIN(GridDetalle.GetValue("Clave"), False, False, True, GridDetalle.GetValue("Cantidad"), #1/1/1900#, #1/1/1900#, True, False, 0, GridDetalle.GetValue("DVEClave"))
        End If
    End Sub

    Private Sub btnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCliente.Click
        btnCliente.ContextMenuStrip.Show(btnCliente, New Point(0, 0), ToolStripDropDownDirection.BelowLeft)
    End Sub

    Private Sub ItemEditarCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemEditarCte.Click
        If ModPOS.Cliente Is Nothing Then

            ModPOS.Cliente = New FrmCliente
            With ModPOS.Cliente
                .numMostrador = Me.numMostrador
                .CambiarCliente = Me.CambiarCliente
                .Text = "Modificar Cliente"
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Modificar"
                .TxtClave.ReadOnly = True
                .fromForm = "Preventa"
                .CmbTipo.Enabled = False
                .TxtLimite.Enabled = False
                .TxtDiasCredito.Enabled = False
                .cmbTipoCanal.Enabled = False
                .cmbListaPrecio.Enabled = False
                .cmbResponsable.Enabled = False
                .TxtCtaContable.Enabled = False
                .cmbDirecto.Enabled = False
                .cmbPostVenta.Enabled = False
                .btnDirecto.Enabled = False
                .btnPostventa.Enabled = False
                .GrpClase.Enabled = False
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", CTEClaveActual)
                .TipoOrigen = IIf(dt.Rows(0)("TipoOrigen").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoOrigen"))
                .RegFiscal = IIf(dt.Rows(0)("NumRegIdTrib").GetType.Name = "DBNull", "", dt.Rows(0)("NumRegIdTrib"))
                .CTEClave = dt.Rows(0)("CTEClave")
                .TPersona = dt.Rows(0)("TPersona")
                .Clave = dt.Rows(0)("Clave")
                .NombreCorto = dt.Rows(0)("NombreCorto")
                .RazonSocial = dt.Rows(0)("RazonSocial")
                .RFC = dt.Rows(0)("id_Fiscal")
                .CURP = dt.Rows(0)("CURP")
                .TipoCanal = IIf(dt.Rows(0)("TipoCanal").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoCanal"))
                .listaPrecio = IIf(dt.Rows(0)("PREClave").GetType.Name = "DBNull", "", dt.Rows(0)("PREClave"))
                .Responsable = IIf(dt.Rows(0)("Responsable").GetType.Name = "DBNull", 0, dt.Rows(0)("Responsable"))
                .CtaContable = IIf(dt.Rows(0)("CtaContable").GetType.Name = "DBNull", "", dt.Rows(0)("CtaContable"))

                .FechaReg = dt.Rows(0)("FechaRegistro")
                .Estado = dt.Rows(0)("Estado")
                .Alterno = IIf(dt.Rows(0)("Alterno").GetType.Name = "DBNull", "", dt.Rows(0)("Alterno"))
                .GLN = IIf(dt.Rows(0)("GLN").GetType.Name = "DBNull", "", dt.Rows(0)("GLN"))
                .Ramo = IIf(dt.Rows(0)("Ramo").GetType.Name = "DBNull", 0, dt.Rows(0)("Ramo"))
                .DesglosaIVA = dt.Rows(0)("DesglosaIVA")
                .ImprimirFac = IIf(dt.Rows(0)("ImprimirFac").GetType.Name = "DBNull", True, dt.Rows(0)("ImprimirFac"))
                .Facturable = IIf(dt.Rows(0)("facturable").GetType.Name = "DBNull", True, dt.Rows(0)("facturable"))
               
                .TipoImpuesto = dt.Rows(0)("TipoImpuesto")
                .LCredito = dt.Rows(0)("LimiteCredito")
                .DiasCredito = dt.Rows(0)("DiasCredito")

                .PaisF = dt.Rows(0)("Pais")
                .EntidadF = dt.Rows(0)("Entidad")
                .MnpioF = dt.Rows(0)("Municipio")
                .ColoniaF = dt.Rows(0)("Colonia")
                .CalleF = dt.Rows(0)("Calle")
                .LocalidadF = dt.Rows(0)("Localidad")
                .referenciaF = dt.Rows(0)("referencia")
                .noExteriorF = dt.Rows(0)("noExterior")
                .noInteriorF = dt.Rows(0)("noInterior")
                .codigoPostalF = dt.Rows(0)("codigoPostal")
                .ZonaVentaF = IIf(dt.Rows(0)("ZonaVenta").GetType.Name = "DBNull", 0, dt.Rows(0)("ZonaVenta"))
                .ZonaRepartoF = IIf(dt.Rows(0)("ZonaReparto").GetType.Name = "DBNull", 0, dt.Rows(0)("ZonaReparto"))

                .Contacto = dt.Rows(0)("Contacto")
                .fechaNacimiento = IIf(dt.Rows(0)("fechaNacimiento").GetType.Name = "DBNull", Today.Date, dt.Rows(0)("fechaNacimiento"))
                .Genero = IIf(dt.Rows(0)("Genero").GetType.Name = "DBNull", 0, dt.Rows(0)("Genero"))
                .tipoTel1 = IIf(dt.Rows(0)("tipoTel1").GetType.Name = "DBNull", 1, dt.Rows(0)("tipoTel1"))
                .tipoTel2 = IIf(dt.Rows(0)("tipoTel2").GetType.Name = "DBNull", 1, dt.Rows(0)("tipoTel2"))

                .Tel1 = dt.Rows(0)("Tel1")
                .Tel2 = dt.Rows(0)("Tel2")
                .email = dt.Rows(0)("Email")

                .Saldo = dt.Rows(0)("Saldo")
                .CreditoDisponible = dt.Rows(0)("Disponible")

                .DCTEClaveFiscal = IIf(dt.Rows(0)("DCTEClave").GetType.Name = "DBNull", "", dt.Rows(0)("DCTEClave"))

                .DescuentoDirecto = IIf(dt.Rows(0)("DescuentoDirecto").GetType.Name = "DBNull", -1, dt.Rows(0)("DescuentoDirecto"))
                .DescuentoPostVenta = IIf(dt.Rows(0)("DescuentoPostVenta").GetType.Name = "DBNull", -1, dt.Rows(0)("DescuentoPostVenta"))
                .Vendedor = IIf(dt.Rows(0)("Vendedor").GetType.Name = "DBNull", "", dt.Rows(0)("Vendedor"))
                .ClienteSAP = IIf(dt.Rows(0)("ClienteSAP").GetType.Name = "DBNull", "", dt.Rows(0)("ClienteSAP"))
                .UsoCFDI = IIf(dt.Rows(0)("UsoCFDI").GetType.Name = "DBNull", "G03", dt.Rows(0)("UsoCFDI"))
                .AccesoWeb = IIf(dt.Rows(0)("AccesoWeb").GetType.Name = "DBNull", False, dt.Rows(0)("AccesoWeb"))
                .CtaMaestra = IIf(dt.Rows(0)("CtaMaestra").GetType.Name = "DBNull", dt.Rows(0)("CTEClave"), dt.Rows(0)("CtaMaestra"))
                dt.Dispose()

            End With
        End If

        ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
        ModPOS.Cliente.Show()
        ModPOS.Cliente.BringToFront()

    End Sub

    Private Sub ItemNuevoCte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemNuevoCte.Click
        If CambiarCliente = True Then
            If ModPOS.Cliente Is Nothing Then
                ModPOS.Cliente = New FrmCliente
                With ModPOS.Cliente
                    .Text = "Agregar Cliente"
                    .StartPosition = FormStartPosition.CenterScreen
                    .Padre = "Agregar"
                    .numMostrador = Me.numMostrador
                    .UiTabSaldos.Enabled = False
                    .fromForm = "Preventa"
                    .TxtClave.Enabled = False
                    .ClienteInicial = Me.CTEClaveInicial

                End With
            End If
            ModPOS.Cliente.StartPosition = FormStartPosition.CenterScreen
            ModPOS.Cliente.Show()
            ModPOS.Cliente.BringToFront()
        Else
            MessageBox.Show("No es posible crear un cliente ya que existe una transacción o documento actual en proceso de captura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub changeClient(ByVal sCTEClave As String)
        If cambiaCliente(sCTEClave) = False Then
            cambiaCliente(CTEClaveInicial)
        End If
    End Sub


    Private Function recuperaCliente(ByVal sCTEClave As String) As Boolean
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", sCTEClave)

        If dt.Rows.Count = 0 Then
            MessageBox.Show("Error al intentar cargar información de domicilios del cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        If CInt(dt.Rows(0)("Estado")) = 0 Then
            MessageBox.Show("Error al intentar cargar información del cliente, ya que se encuentra Inactivo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        TImpuesto = dt.Rows(0)("TipoImpuesto")

        TxtCliente.Text = ""
        CTEClaveActual = sCTEClave
        CtaMaestra = dt.Rows(0)("CtaMaestra")
        ClienteSAP = IIf(dt.Rows(0)("ClienteSAP").GetType.Name = "DBNull", "", dt.Rows(0)("ClienteSAP"))
        CTENombreActual = dt.Rows(0)("RazonSocial")
        LblCliente.Text = CTENombreActual
        lblCteClave.Text = dt.Rows(0)("Clave")
        lblNivelDesc.Text = IIf(dt.Rows(0)("NivelDesc").GetType.Name = "DBNull", "", dt.Rows(0)("NivelDesc"))

        LimiteCredito = dt.Rows(0)("LimiteCredito")
        DiasCredito = dt.Rows(0)("DiasCredito")
        SaldoCte = dt.Rows(0)("Saldo")

        Vendedor = IIf(dt.Rows(0)("Vendedor").GetType.Name = "DBNull", "", dt.Rows(0)("Vendedor"))

        dt.Dispose()

        dt = ModPOS.Recupera_Tabla("st_existe_complemento", "@CTEClave", sCTEClave)
        If dt.Rows.Count > 0 Then
            bComplemento = True
            BtnAddenda.Enabled = True
        Else
            bComplemento = False
            BtnAddenda.Enabled = False
        End If
        dt.Dispose()



        Dim foundRows() As System.Data.DataRow
        dt = Recupera_Tabla("sp_recupera_domiciliocte", "@CTEClave", sCTEClave)
        foundRows = dt.Select("TImpuesto <> " & CStr(TImpuesto))

        If Picking = True AndAlso foundRows.Length >= 1 Then
            ' Muestra para que seleccione un Consignatario
            Dim dt1 As DataTable
            dt1 = ModPOS.Recupera_Tabla("sp_recupera_envio", "@VENClave", VENClave)

            If dt1.Rows.Count = 0 Then
                'Solicita Consignatario o Destino de forma obligatoria
                Dim bEnvio As Boolean = False
                Do
                    bEnvio = ModPOS.ValidaEnvio(Packing, Picking, VENClave, CTEClaveActual, VentaCerrada, ALMClave, "")
                Loop While Not bEnvio

                dt1 = ModPOS.Recupera_Tabla("sp_recupera_envio", "@VENClave", VENClave)

                TImpuesto = dt1.Rows(0)("TImpuesto")

            Else
                TImpuesto = dt1.Rows(0)("TImpuesto")
            End If
            dt1.Dispose()

        End If



        If CTEClaveActual <> CtaMaestra Then
            dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", CtaMaestra)
            LimiteCredito = dt.Rows(0)("LimiteCredito")
            DiasCredito = dt.Rows(0)("DiasCredito")
            SaldoCte = dt.Rows(0)("Saldo")
            dt.Dispose()
        End If

        txtLimite.Text = LimiteCredito
        txtDias.Text = DiasCredito

        txtSaldo.Text = SaldoCte


        If CTEClaveActual = CTEClaveInicial Then
            txtSaldo.Visible = False
            lblSaldo.Visible = False
        Else
            txtSaldo.Visible = True
            lblSaldo.Visible = True
        End If

        Return True
    End Function
    

    Private Function cambiaCliente(ByVal sCTEClave As String) As Boolean

        ModPOS.Ejecuta("st_elimina_envio", "@VENClave", VENClave)


        If recuperaCliente(sCTEClave) = False Then
            Return False
        End If

        If TipoDocumento = 1 OrElse TipoDocumento = 3 Then
            If LimiteCredito > 0 Then

                If convierteDocumento(3) = False Then
                    Select Case MessageBox.Show("No se cumplieron las condiciones para crear una venta a Crédito ¿Desea continuar y crear la venta de Contado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case Windows.Forms.DialogResult.No
                            Return False
                        Case Windows.Forms.DialogResult.Yes
                            If TipoDocumento <> 1 Then
                                convierteDocumento(1)
                            End If
                    End Select
                End If
            Else
                If convierteDocumento(1) = False Then
                    Return False
                End If
            End If
        End If

        If SolicitaVendedor = False Then

            If Vendedor <> "" Then
                Dim dtUsr As DataTable
                dtUsr = ModPOS.Recupera_Tabla("sp_recupera_UsuarioActual", "@Usuario", Vendedor)
                If dtUsr.Rows.Count > 0 Then
                    AtiendeClave = dtUsr.Rows(0)("USRClave")
                    ReferenciaUsr = dtUsr.Rows(0)("Referencia")
                    AtiendeNombre = dtUsr.Rows(0)("Nombre")
                    LblUsuario.Text = AtiendeNombre

                End If
                dtUsr.Dispose()
            End If
        End If



        ModPOS.Ejecuta("sp_actualiza_PDVCliente", _
                       "@Cajero", AtiendeClave, _
                       "@VENClave", VENClave, _
                       "@Cliente", CTEClaveActual, _
                       "@Usuario", ModPOS.UsuarioActual)


        If CTEClaveActual = CreditoGeneral AndAlso NotaCreditos = "" Then
            Dim b As New FrmSolicitaCte
            b.ShowDialog()
            If b.DialogResult = DialogResult.OK Then
                NotaCreditos = b.Nota
                If NotaCreditos <> "" Then
                    ModPOS.Ejecuta("sp_actualiza_notavta", "@VENClave", VENClave, "@Nota", NotaCreditos)
                End If
            Else
                MessageBox.Show("No se pudo realizar la venta a Crédito ya que usted esta intentado asignar un cliente general, por lo que debe especificar el nombre del cliente en el campo notas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        End If


     
        TxtProducto.Focus()

        Return True
    End Function

    Private Sub CmbSucursal_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSucursal.SelectedValueChanged
        If bLoad = True Then
            If Not cmbSucursal.SelectedValue Is Nothing Then

                If cmbSucursal.SelectedValue = SucursalSurtido Then
                    SUCClave = SucursalSurtido
                    AlmacenSurtido = ALMClave
                    sAlmacen = AlmacenClave & " - " & AlmacenNombre
                Else
                    SUCClave = cmbSucursal.SelectedValue

                    Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_almacensurtido", "@SUCClave", SUCClave)

                    If dt.Rows.Count > 0 Then
                        AlmacenSurtido = dt.Rows(0)("ALMClave")
                        sAlmacen = dt.Rows(0)("Clave") & " - " & dt.Rows(0)("Nombre")
                    End If
                    dt.Dispose()
                End If
            End If
        End If
    End Sub



    Private Sub BtnAddenda_Click(sender As Object, e As EventArgs) Handles BtnAddenda.Click
        Dim a As New FrmExtra
        a.VENClave = Me.VENClave
        a.CTEClave = Me.CTEClaveActual
        a.StartPosition = FormStartPosition.CenterScreen
        a.ShowDialog()
        a.Dispose()
    End Sub

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

        If iTipoDocumento = 3 AndAlso CDbl(txtLimite.Text) <= 0 Then
            MessageBox.Show("El cliente actual no cuenta con limite de crédito.", "Error", MessageBoxButtons.OK)
            Exit Sub
        End If

        Select Case MessageBox.Show("Esta apunto de crear una venta a partir de la cotización. ¿Esta usted de acuerdo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Case DialogResult.Yes

                Dim dt, dtventadetalle As DataTable

                dtventadetalle = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)

                If AlmacenSurtido = "" OrElse AlmacenSurtido Is Nothing Then
                    Beep()
                    MessageBox.Show("No es posible crear una nueva venta debido a que no se ha especificado el Almacen para surtido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If cmbTipoCanal.SelectedValue Is Nothing Then
                    Beep()
                    MessageBox.Show("No es posible crear una nueva venta debido a que no se ha especificado el Canal de Venta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                        Me.ReferenciaUsr = a.ReferenciaUsr
                        Me.AtiendeClave = a.AtiendeClave
                        LblUsuario.Text = AtiendeNombre
                    Else
                        MessageBox.Show("No es posible crear una nueva venta debido a que no se ha sido registrado un Vendedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    a.Dispose()
                End If

                If iTipoDocumento >= 3 AndAlso CDbl(txtLimite.Text) > 0 Then
                    TipoDocumento = 3
                    EstadoDocumento = 1
                Else
                    TipoDocumento = 1
                    EstadoDocumento = 1
                End If

                modificaStatus(TipoDocumento, EstadoDocumento)

                ObtenerFolio()

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
                "@TipoCanal", cmbTipoCanal.SelectedValue, _
                "@Usuario", ModPOS.UsuarioActual)

                If CambiarCliente = False Then
                    btnBuscaCte.Enabled = True
                    TxtCliente.Enabled = True
                    cmbTipoCanal.Enabled = True
                    BtnTC.Enabled = True
                    CambiarCliente = True
                End If

                btnBuscaCte.Enabled = True
                BtnCancelaProducto.Enabled = True
                BtnCancelaTicket.Enabled = True
                btnEnvio.Enabled = True
                BtnCerrar.Enabled = True
                TxtCantidad.Enabled = True
                TxtProducto.Enabled = True
                TxtCliente.Enabled = True
                cmbTipoCanal.Enabled = True
                BtnTC.Enabled = True
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
                    If MonedaActual <> Moneda Then

                        If TipoCambio > 0 Then
                            LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                        Else
                            LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                        End If
                    Else
                        If MonTipoCambio > 0 Then
                            LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                        Else
                            LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                        End If
                    End If
                Else
                    If MonedaActual <> Moneda Then

                        If TipoCambio > 0 Then
                            LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                        Else
                            LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                        End If
                    Else
                        LblTipoCambio.Text = ""
                    End If
                End If

                If Not dtventadetalle Is Nothing Then
                    Dim i As Integer = 0

                    For i = 0 To dtventadetalle.Rows.Count - 1
                        AgregaGTIN(dtventadetalle.Rows(i)("Clave"), True, False, False, dtventadetalle.Rows(i)("Cantidad"), #1/1/1900#, #1/1/1900#, True, True)
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
                                recuperaVentaOpen(dt.Rows(0)("VENClave"), dt.Rows(0)("Folio"), dt.Rows(0)("Cliente"), dt.Rows(0)("RazonSocial"), dt.Rows(0)("Cajero"), dt.Rows(0)("Referencia"), dt.Rows(0)("NombreUsuario"), dt.Rows(0)("Saldo"), dt.Rows(0)("Total"), dt.Rows(0)("Tipo"), dt.Rows(0)("Estado"), dt.Rows(0)("LimiteCredito"), dt.Rows(0)("DiasCredito"), dt.Rows(0)("SaldoCliente"), dt.Rows(0)("ALMClave"))
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
        Me.Close()
    End Sub

    Private Sub BtnConvertir_Click(sender As Object, e As EventArgs) Handles BtnConvertir.Click
        If (VentaCerrada = False OrElse TipoDocumento = 2) Then

            If cmbSucursal.SelectedValue Is Nothing Then
                MessageBox.Show("!Debe especificar la sucursal que realizara el surtido¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim a As New FrmMenuT
            a.TipoDocumento = Me.TipoDocumento
            a.ActivarCotizacion = Me.ActivarCotizacion
            If a.ShowDialog = Windows.Forms.DialogResult.OK Then

                If VentaCerrada = True AndAlso (Periodo <> Today.Year OrElse Mes <> Today.Month) Then
                    MessageBox.Show("Solo es posible convertir documento dentro del mismo Año y Mes que fueron creados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                convierteDocumento(a.NewTipoDocumento)
            End If
            Exit Sub
        End If

    End Sub


    Private Sub txtVendedor_KeyUp(sender As Object, e As KeyEventArgs) Handles txtVendedor.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If txtVendedor.Text <> "" Then
                    Dim dt As DataTable
                    dt = ModPOS.Recupera_Tabla("sp_recupera_usuario", "@Usuario", txtVendedor.Text.Trim.ToUpper.Replace("'", "''"))
                    If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                        If AtiendeClave <> dt.Rows(0)("USRClave") Then
                            AtiendeClave = dt.Rows(0)("USRClave")
                            ReferenciaUsr = dt.Rows(0)("Referencia")
                            AtiendeNombre = dt.Rows(0)("Nombre")
                            LblUsuario.Text = AtiendeNombre

                            ModPOS.Ejecuta("sp_actualiza_PDVCliente", _
                                            "@Cajero", AtiendeClave, _
                                            "@VENClave", VENClave, _
                                            "@Cliente", CTEClaveActual, _
                                            "@Usuario", ModPOS.UsuarioActual)
                            txtVendedor.Text = ""
                        End If
                        dt.Dispose()
                    End If
                End If
        End Select
    End Sub


    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        If VENClave <> "" Then

            Dim sPath As String
            Dim a As New System.Windows.Forms.FolderBrowserDialog
            If (a.ShowDialog() = DialogResult.OK) Then
                If a.SelectedPath.Length <= 3 Then
                    sPath = a.SelectedPath
                Else
                    sPath = a.SelectedPath & "\"
                End If
            Else
                Exit Sub
            End If

            Dim frmStatusMessage As New frmStatus
            frmStatusMessage.Show("Solicitando Información...")
            'Recupera impresoras por area de surtido

            Dim OpenReport As New Report
            Dim pvtaDataSet As New DataSet
            pvtaDataSet.DataSetName = "pvtaDataSet"
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_vw_ventadetalle", "@VENClave", VENClave))
            Try
                OpenReport.PrintExcel(True, "CRVwPedido.rpt", pvtaDataSet, "", sPath & LblFolio.Text & ".xls")
                MessageBox.Show("Exportado Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            frmStatusMessage.Dispose()
        End If
    End Sub

    Private Sub ItemEdoCuenta_Click(sender As Object, e As EventArgs) Handles ItemEdoCuenta.Click
        Dim a As New MeFiltroCte
        a.Text = "Reporte de Estado de Cuenta"
        a.CargaDatosCliente(CTEClaveActual)
        a.ShowDialog()
        If a.DialogResult = System.Windows.Forms.DialogResult.OK Then
            Dim OpenReport As New Report
            Dim pvtaDataSet As New DataSet
            pvtaDataSet.DataSetName = "pvtaDataSet"
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_edocta_enc", "@CTEClave", a.Cliente))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_edocta_detalle", "@CTEClave", a.Cliente, "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_rango", "@Inicial", CDate(a.FechaInicio), "@Final", CDate(a.FechaFinal)))
            OpenReport.PrintPreview("Reporte de Estado de Cuenta del Cliente", "CREdoCte.rpt", pvtaDataSet, "")
        End If
        a.Dispose()
    End Sub


    Private Sub CtxTC_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles CtxTC.ItemClicked
        BtnTC.Text = e.ClickedItem.Text

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_tipocambio", "@Moneda", e.ClickedItem.Text)
        MonedaActual = dt.Rows(0)("MONClave")
        MonedaRef = dt.Rows(0)("Referencia")
        MonedaDesc = dt.Rows(0)("Descripcion")
        TipoCambio = IIf(dt.Rows(0)("TipoCambioVenta").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoCambioVenta"))
        dt.Dispose()

        lblMoneda.Text = "T.C. " & Format(CStr(ModPOS.Redondear(TipoCambio, 2)), "Currency")
        lblTotMon.Text = "TOTAL (" & MonedaRef.ToUpper.Trim & ")"
        If Moneda <> MonedaCambio Then
            If MonedaActual <> Moneda Then

                If TipoCambio > 0 Then
                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                End If
            Else
                If MonTipoCambio > 0 Then
                    LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                End If
            End If
        Else
            If MonedaActual <> Moneda Then

                If TipoCambio > 0 Then
                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                End If
            Else
                LblTipoCambio.Text = ""
            End If
        End If


        SendKeys.Send("{TAB}")

    End Sub

    Private Sub BtnTC_Click(sender As Object, e As EventArgs) Handles BtnTC.Click
        BtnTC.ContextMenuStrip.Show(BtnTC, New Point(0, 0), ToolStripDropDownDirection.AboveRight)
    End Sub

    Private Sub btnCortar_Click(sender As Object, e As EventArgs) Handles btnCortar.Click
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
                VentaCerrada = True
                modificaStatus(TipoDocumento, EstadoDocumento)
                MessageBox.Show("No es posible cortar, ya que No se encuentra Abierto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            dt.Dispose()

            If TotalArticulos > 0 Then

                Dim dtDetalle As DataTable = ModPOS.Recupera_Tabla("sp_search_producto_detalle", "@Venta", VENClave)

                If dtDetalle.Rows.Count > 0 Then
                    Dim i As Integer
                    Dim dDescPorc As Decimal

                    Dim frmStatusMessage As New frmStatus
                     frmStatusMessage.Show("Procesando información...")

                        For i = 0 To dtDetalle.Rows.Count - 1

                            Dim dtDescuento As DataTable = ModPOS.SiExisteRecupera("sp_descuento_partida_open", "@DVEClave", dtDetalle.Rows(i)("DVEClave"))
                            If Not dtDescuento Is Nothing Then

                                'Descuento Gerencial
                                Dim foundRows1() As DataRow = dtDescuento.Select(" Tipo = 3 ")
                                If foundRows1.Length = 1 Then
                                    dDescPorc = foundRows1(0)("DescuentoPorc")
                                Else
                                    dDescPorc = 0
                                End If
                                dtDescuento.Dispose()
                            Else
                                dDescPorc = 0
                            End If

                            'insertar en la estructura de copiado
                            Dim row1 As DataRow
                            row1 = dtPortaPapeles.NewRow()
                            row1.Item("Clave") = dtDetalle.Rows(i)("Clave")
                            row1.Item("Cantidad") = dtDetalle.Rows(i)("Cantidad")
                            row1.Item("Descuento") = dDescPorc * 100
                            dtPortaPapeles.Rows.Add(row1)

                            'elimina del pedido actual

                            ModPOS.Ejecuta("sp_elimina_partida", _
                                 "@ALMClave", ALMClave, _
                                 "@VENClave", VENClave, _
                                 "@DVEClave", dtDetalle.Rows(i)("DVEClave"), _
                                 "@Producto", dtDetalle.Rows(i)("PROClave"), _
                                 "@Cantidad", dtDetalle.Rows(i)("Cantidad"), _
                                 "@TipoDoc", TipoDocumento, _
                                 "@TProducto", dtDetalle.Rows(i)("TProducto"), _
                                 "@Picking", Picking)


                        Next

                    frmStatusMessage.Close()


                    dtPedidoDetalle.Clear()


                    TotalArticulos = 0
                    TotalPuntos = 0
                    TotalVenta = 0
                    TotalRecibido = 0
                    TotalCambio = 0
                    TotalAhorro = 0

                    CambiarCliente = True
                    btnBuscaCte.Enabled = True
                    TxtCliente.Enabled = True
                    cmbTipoCanal.Enabled = True
                    BtnTC.Enabled = True

                    LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
                    LblCantidadArticulos.Text = CStr(TotalArticulos)
                    LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                    LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

                    If Moneda <> MonedaCambio Then
                        If MonedaActual <> Moneda Then

                            If TipoCambio > 0 Then
                                LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                            Else
                                LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                            End If
                        Else
                            If MonTipoCambio > 0 Then
                                LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta / MonTipoCambio, 0), 2)), "Currency")
                            Else
                                LblTipoCambio.Text = MonRefCambio.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                            End If
                        End If
                    Else
                        If MonedaActual <> Moneda Then

                            If TipoCambio > 0 Then
                                LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta * TipoCambio, 0), 2)), "Currency")
                            Else
                                LblTipoCambio.Text = MonRefBase.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(IIf(TotalVenta > 0, TotalVenta, 0), 2)), "Currency")
                            End If
                        Else
                            LblTipoCambio.Text = ""
                        End If
                    End If




                End If

            Else
                Beep()
                MessageBox.Show("No se encontro producto en el documento actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If
        End If
    End Sub

    Private Sub btnPegar_Click(sender As Object, e As EventArgs) Handles btnPegar.Click
        If Not VentaCerrada Then
            If dtPortaPapeles.Rows.Count > 0 Then

                Dim i As Integer
                Dim frmStatusMessage As New frmStatus
                frmStatusMessage.Show("Procesando información...")
                For i = 0 To dtPortaPapeles.Rows.Count - 1
                    AgregaGTIN(dtPortaPapeles.Rows(i)("Clave"), True, False, False, dtPortaPapeles.Rows(i)("Cantidad"), #1/1/1900#, #1/1/1900#, True, True, dtPortaPapeles.Rows(i)("Descuento"))
                Next
                frmStatusMessage.Close()
                dtPortaPapeles.Clear()
            End If
        End If
    End Sub
End Class
